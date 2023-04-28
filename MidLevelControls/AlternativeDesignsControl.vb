
'*************************************************************************************************************
' Class AlternativeDesignsControl - UserControl for reviewing a set of alternative Designs
'
' Note - this control operates in two modes dependant on the value of DialogMode:
'       1) DialogMode - user changes are limited to the control and may be applied to the Flume.dll by the
'                       calling method if the user closes the Dialog via the 'Ok' button.
'       2) Application Mode - user changes are applied immediately to the Flume.dll
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog    ' Unit conversion support
Imports WinFlume.WinFlumeSectionType

Public Class AlternativeDesignsControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume data
    '
    Private mFlume As Flume.FlumeType = Nothing             ' Current working Flume
    Private mAltFlume As Flume.FlumeType = Nothing          ' Last Flume used for Alternative Designs
    '
    ' Flume Design object
    '
    Private mWinFlumeDesign As WinFlumeDesign = Nothing
    '
    ' Column indeces
    '
    Public Const MinPrimaryCol As Integer = 2
    Public Const MaxPrimaryCol As Integer = 5
    Public Const MinSecondaryCol As Integer = 6
    Public Const MaxSecondaryCol As Integer = 7
    '
    ' Visible changed flag
    '
    Private mVisibleChanged As Boolean = False

#End Region

#Region " Properties "

    Public Property Dialog As Windows.Forms.Form = Nothing      ' Dialog to use with "View as Dialog"

    Public Property SelectedRowIndex As Integer = 0             ' User selected row in table

    Public Property ShowDesignNotFound As Boolean = True        ' Flag indicating if a design was found

    Public Property SelectedFlume As FlumeType = Nothing        ' Current Flume data

    Public Property ExactMatch As Boolean = False

#End Region

#Region " Constructor(s) "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mWinFlumeDesign = New WinFlumeDesign

    End Sub

    Public Sub New(ByVal FlumeForm As WinFlumeForm)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mWinFlumeForm = FlumeForm
        mFlume = WinFlumeForm.Flume

        mWinFlumeDesign = New WinFlumeDesign

    End Sub

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Function CurrentFlume() - return FlumeType for selected alternate design
    '*********************************************************************************************************
    Public Function CurrentFlume() As FlumeType
        CurrentFlume = Nothing
        Dim curRow As DataGridViewRow = ReviewDesignsTable.CurrentRow
        If (curRow IsNot Nothing) Then

            CurrentFlume = mWinFlumeDesign.EvaluationFlumes(SelectedRowIndex + 1)
        End If
    End Function

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Design Evaluation Options
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal FlumeForm As WinFlumeForm)
        mWinFlumeForm = FlumeForm
        Me.UpdateUI()
    End Sub

    Public Function BriefDesignReview() As String
        ' Keep index within bounds
        Dim idx As Integer = SelectedRowIndex + 1
        If (idx < 0) Then
            idx = 0
        ElseIf (idx >= mWinFlumeDesign.DesignRpts.Length) Then
            idx = mWinFlumeDesign.DesignRpts.Length - 1
        End If

        BriefDesignReview = mWinFlumeDesign.DesignRpts(idx)
    End Function

    Private mUpdatingUI As Boolean = False
    Private Sub UpdateUI()

        ' Don't update UI until control is visible and initialization is complete
        If (Not (Me.Visible)) Then
            Return
        End If

        mFlume = WinFlumeForm.Flume
        If (mFlume Is Nothing) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Return
        End If
        mUpdatingUI = True

        Dim NumGood As Integer
        Dim DesignStillPossible, UserCanceled As Boolean

        Try
            ' Update Control Section selection
            Dim controlShape As Integer = mFlume.Section(cControl).Shape
            Dim shapeText As String = SectionString(controlShape)
            Me.ControlSectionShape.Text = shapeText

            If (FlumeType.ChangedFlume(mFlume, mAltFlume)) Then

                ' Update table headers
                Dim Lunits As String = "(" & UiLengthUnitsText() & ")"
                For Each col As DataGridViewColumn In Me.ReviewDesignsTable.Columns
                    If (col.Name = "SillHeightColumn") Then
                        If (mFlume.CrestType = StationaryCrest) Then
                            col.HeaderText = GenColumnHeader(My.Resources.SillHeight, 3) & Lunits
                        Else
                            col.HeaderText = GenColumnHeader(My.Resources.OperatingUpstreamDepth, 3) & Lunits
                        End If

                        col.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight
                        col.Frozen = True
                    ElseIf (col.Name = "ControlWidthColumn") Then
                        Select Case controlShape
                            Case shParabola, shSillInParabola
                                col.HeaderText = GenColumnHeader(My.Resources.ControlFocalDistance, 3) & Lunits
                            Case shCircle, shUShaped, shSillInCircle, shSillInUShaped
                                col.HeaderText = GenColumnHeader(My.Resources.ControlDiameter, 3) & Lunits
                            Case Else
                                col.HeaderText = GenColumnHeader(My.Resources.ControlWidth, 3) & Lunits
                        End Select

                        col.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight
                        col.Frozen = True
                    End If
                    XlateColumnHeader(col, Lunits)
                Next col

                ' Check design evaluation increment
                Dim CD As Single = mFlume.ChannelDepth
                Dim DesInc As Single = mFlume.DesignIncrementValue
                If (DesInc > CD) Then
                    Dim msg As String = My.Resources.DesignIncrementWarning
                    MsgBox(msg)
                End If

                ' Clear previous alternative designs display
                Me.ReviewDesignsTable.Rows.Clear()

                ' Update display of alternative designs
                mWinFlumeDesign.EvaluateDesigns(mFlume, NumGood, DesignStillPossible, UserCanceled)

                If NumGood > 0 Then
                    ShowDesignNotFound = True
                    Call mWinFlumeDesign.InsertDesign(mFlume, NumGood)
                    Call ShowDesignResults(mFlume)
                ElseIf UserCanceled Then
                    ShowDesignNotFound = True
                    'Do nothing else...let this routine exit
                Else
                    Dim msg As String = My.Resources.DesignNotFoundLine1 & " " & My.Resources.DesignNotFoundLine2
                    If (ShowDesignNotFound) Then
                        ShowDesignNotFound = False
                        MsgBox(msg)
                    End If
                    'Call ShowDesignResults(mFlume)
                End If

                ' Update selected row's details
                If (0 < Me.ReviewDesignsTable.Rows.Count) Then

                    If ((SelectedRowIndex < 0) Or (ReviewDesignsTable.Rows.Count <= SelectedRowIndex)) Then
                        SelectedRowIndex = 0
                    End If

                    Me.ReviewDesignsTable.CurrentCell = Me.ReviewDesignsTable.Rows(SelectedRowIndex).Cells(0)
                End If

                mAltFlume = New FlumeType(mFlume)

            End If ' ChangedFlume

            '
            ' Make sure the Selected Row in the table matches the current design.  This entails finding the
            ' nearest row that matches both the Sill Height and the Control Width.  Note, if the current
            ' design's values are outside the range of Alternative Designs, the first row is selected.
            '

            ' Get Current Design's Sill Height and Control Width
            Dim cdSH As Single = mFlume.SillHeight
            Dim cdCW As Single = mFlume.Section(cControl).BottomWidth

            Dim Shape As Integer = mFlume.Section(cControl).Shape
            Select Case Shape
                Case shCircle, shUShaped, shSillInCircle, shSillInUShaped, shParabola, shSillInParabola,
                         shCircleInCircle, shParabolaInParabola, shUShapedInUShaped
                    cdCW = mFlume.Section(cControl).DiameterFocalD
                Case shVShaped, shVShapedInVShaped
                    cdCW = 0
            End Select

            ' Get first and last rows from Alternative Designs table
            Dim rowCount As Integer = ReviewDesignsTable.Rows.Count

            If (rowCount < 1) Then
                Return
            End If

            Dim firstRow As DataGridViewRow = ReviewDesignsTable.Rows(0)
            Dim lastRow As DataGridViewRow = ReviewDesignsTable.Rows(rowCount - 1)

            Dim frSH, frCW, lrSH, lrCW As Single

            Try
                frSH = Single.Parse(firstRow.Cells(0).Value.ToString)
                frCW = Single.Parse(firstRow.Cells(1).Value.ToString)
                lrSH = Single.Parse(lastRow.Cells(0).Value.ToString)
                lrCW = Single.Parse(lastRow.Cells(1).Value.ToString)
            Catch ex As Exception
                Debug.Assert(False, ex.Message)
            End Try

            Dim rdx As Integer

            Dim lSH As Single = Single.MaxValue
            Dim lCW As Single = Single.MaxValue

            ReviewDesignsTable.Rows(0).Selected = False

            If (cdSH < frSH - 0.001 Or lrSH + 0.001 < cdSH) Then
                ' Current Design's Sill Height is outside the range of Alternative Designs table
                SelectedRowIndex = 0 ' Select the first row in the table
                ExactMatch = False
            Else
                ' Scan Review Designs Taable look for an 'exact' match
                For rdx = 0 To rowCount - 1
                    Dim row As DataGridViewRow = ReviewDesignsTable.Rows(rdx)

                    Dim rSH As Single = Single.Parse(row.Cells(0).Value.ToString)
                    Dim rCW As Single = Single.Parse(row.Cells(1).Value.ToString)

                    If ThisClose(rSH, cdSH, 0.001) And ThisClose(rCW, cdCW, 0.001) Then ' Row is exact match

                        SelectedRowIndex = rdx
                        ReviewDesignsTable.Rows(rdx).Selected = True
                        ExactMatch = True

                        Exit For
                    End If

                Next rdx
            End If

            If (Me.Dialog IsNot Nothing) Then ' Being displayed in a Dialog
                Me.ViewAsDialogButton.Hide()
                Me.FormInstructions.Hide()
                Me.DialogInstructions.Show()
                Me.StatusLabel.Text = ""
            Else
                Me.ViewAsDialogButton.Show()
                Me.FormInstructions.Show()
                Me.DialogInstructions.Hide()
            End If

            Me.ReviewDesignsTable.Rows(SelectedRowIndex).Selected = True

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        mUpdatingUI = False
    End Sub

    '*********************************************************************************************************
    ' Function GenColumnHeader() - generate formatted column header string from unformatted heading text
    '
    ' Input(s):     Heading     - unformatted heading text
    '               NumLines    - number of lines for column header
    '
    ' Returns:      String      - formatted column header
    '*********************************************************************************************************
    Private Function GenColumnHeader(ByVal Heading As String, ByVal NumLines As Integer) As String
        GenColumnHeader = ""

        If (Heading IsNot Nothing) Then
            ' Split heading into individual words
            Dim tokens As String() = Heading.Split(" ".ToCharArray)
            Dim numTokens As Integer = Math.Min(tokens.Length, NumLines)

            If (1 < numTokens) Then
                ' If less words than lines, add some blank lines
                If (numTokens < NumLines) Then
                    For ldx As Integer = 1 To NumLines - numTokens
                        GenColumnHeader &= "\n"
                    Next ldx
                End If
                ' Add the words, one per line
                For tdx As Integer = 0 To numTokens - 1
                    Dim token As String = tokens(tdx)
                    GenColumnHeader &= token & "\n"
                Next tdx
            End If
        End If

    End Function

    '*********************************************************************************************************
    ' Sub XlateColumnHeader() - translate column header for format required by HeaderText
    '
    ' Input(s):     DesignColumn    - column containing HeaderText to translate
    '               UiLenUnits      - UI Length Units string
    '*********************************************************************************************************
    Private Sub XlateColumnHeader(ByVal DesignColumn As DataGridViewColumn, ByVal UiLenUnits As String)
        ' Determine width to use when expanding special text sequences
        Dim siz As Size = TextRenderer.MeasureText("CRITERIA", Me.Font)
        Dim spclWidth As Integer = siz.Width

        ' Change "\n" to vbCrLf and expand special text
        Dim heading As String = DesignColumn.HeaderText
        If (heading.Contains("\n")) Then
            ' Change "\n" to vbCrLf
            Dim pos As Integer
            Dim pre As String
            While (heading.Contains("\n"))
                pos = heading.IndexOf("\n")
                pre = heading.Substring(0, pos)
                heading = pre & vbCrLf & heading.Substring(pos + 2)
            End While

            ' Update Length units
            If (heading.Contains("(m)")) Then
                pos = heading.IndexOf("(m)")
                pre = heading.Substring(0, pos)
                heading = pre & UiLenUnits & heading.Substring(pos + 3)
            End If

            ' Expand special text
            ExpandSpecialText(heading, "---", spclWidth)
            ExpandSpecialText(heading, "<--", spclWidth)
            ExpandSpecialText(heading, "-->", spclWidth)

            DesignColumn.HeaderText = heading
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub ExpandSpecialText() - expand special text strings within column heading
    '
    ' Input(s):     Heading     - column header text
    '               SpclTxt     - special text to expand (e.g. "<--" to "<-----------")
    '               ExpWidth    - width to expand text to
    '*********************************************************************************************************
    Private Sub ExpandSpecialText(ByRef Heading As String, ByVal SpclTxt As String, ByVal ExpWidth As Integer)
        ' Check for multiple occurances of special text
        Dim pos As Integer = Heading.IndexOf(SpclTxt)
        While (0 <= pos)
            Dim expnTxt As String = SpclTxt
            Dim pre As String = Heading.Substring(0, pos)
            Dim siz As Size = TextRenderer.MeasureText(expnTxt, Me.Font)

            ' Expand text until display width is met
            Do While (siz.Width < ExpWidth)
                If (SpclTxt = "-->") Then
                    expnTxt = "-" & expnTxt
                Else
                    expnTxt = expnTxt & "-"
                End If
                siz = TextRenderer.MeasureText(expnTxt, Me.Font)
            Loop

            ' Replace abbreviated text with expanded text
            Heading = pre & expnTxt & Heading.Substring(pos + 3)

            ' Check for another occurance of special text
            pos = Heading.IndexOf(SpclTxt, pre.Length + expnTxt.Length)
        End While
    End Sub

    '*********************************************************************************************************
    ' Sub ShowDesignResults()
    '
    ' Input(s):     WorkingFlume        - the current Flume
    '*********************************************************************************************************
    Private Sub ShowDesignResults(ByVal WorkingFlume As FlumeType)
        Dim i%, j%, N%, Fmt$, Fmt3$
        Dim c%
        Dim Shape%
        Dim DesignOK As Boolean
        Dim siValue!, uiValue!
        Dim SubmergenceProtection!, SubmergenceProtectionMax!, SubmergenceProtectionMin!

        Dim rowString(13) As String

        Fmt = "######0.00"
        Fmt3 = "######0.000"
        N = UBound(mWinFlumeDesign.EvaluationFlumes)

        For i = 1 To N - 1
            c = i

            'Sill height, width/diameter
            With mWinFlumeDesign.EvaluationFlumes(i)

                If WorkingFlume.CrestType = StationaryCrest Then
                    siValue = .SillHeight
                Else
                    siValue = .OperatingDepth
                End If
                uiValue = UiLengthValue(siValue, UiLengthUnits)
                rowString(0) = TrimmedFormat(uiValue, Fmt3)

                Shape = WorkingFlume.Section(cControl).Shape
                Select Case Shape
                    Case shCircle, shUShaped, shSillInCircle, shSillInUShaped, shParabola, shSillInParabola,
                         shCircleInCircle, shParabolaInParabola, shUShapedInUShaped
                        siValue = .Section(cControl).DiameterFocalD
                        uiValue = UiLengthValue(siValue, UiLengthUnits)
                        rowString(1) = TrimmedFormat(uiValue, Fmt3)
                    Case shVShaped, shVShapedInVShaped
                        rowString(1) = "0"
                    Case Else
                        siValue = .Section(cControl).BottomWidth
                        uiValue = UiLengthValue(siValue, UiLengthUnits)
                        rowString(1) = TrimmedFormat(uiValue, Fmt3)
                End Select
            End With

            'Design criteria results
            DesignOK = True
            For j = 1 To 6
                If mWinFlumeDesign.BooleanResults(mWinFlumeDesign.CriteriaDisplayOrder(j), i) Then
                    rowString(j + 1) = My.Resources.OK
                Else
                    rowString(j + 1) = My.Resources.NotOK
                    DesignOK = False
                End If
            Next j

            'Actual performance data and headloss comments
            With mWinFlumeDesign.QuantitativeResults(i)
                SubmergenceProtectionMax = .AllowedTailwaterDepthAtQMax - .MaxTailwater
                SubmergenceProtectionMin = .AllowedTailwaterDepthAtQMin - .MinTailwater
                SubmergenceProtection = minsingle(SubmergenceProtectionMin, SubmergenceProtectionMax)
                If i = 1 Then
                    'Candidate for a min-headloss design
                    If (SubmergenceProtection < .MaxTailwater / 100) Then
                        mWinFlumeDesign.HLComment(i) = My.Resources.Minimum
                    End If
                End If
                If i = N Then
                    'Candidate for a max-headloss design
                    If (.ActualFreeboard - .RequiredFreeboard < .MaxTailwater / 100) Then
                        mWinFlumeDesign.HLComment(i) = My.Resources.Maximum
                    End If
                End If
                'Headloss comments
                If DesignOK Then
                    rowString(8) = mWinFlumeDesign.HLComment(i)
                Else
                    rowString(8) = "---"
                End If

                'Actual headloss
                If mWinFlumeDesign.EvaluationFlumes(i).CrestType = StationaryCrest Then
                    siValue = mWinFlumeDesign.EvaluationFlumes(i).SillHeight
                    siValue += mWinFlumeDesign.EvaluationFlumes(i).BedDrop
                    siValue += .SMALLh1atQMax
                    siValue -= .MaxTailwater
                Else        'Movable crest
                    siValue = mWinFlumeDesign.EvaluationFlumes(i).OperatingDepth
                    siValue += mWinFlumeDesign.EvaluationFlumes(i).BedDrop
                    siValue -= .MinTailwater
                End If
                uiValue = UiLengthValue(siValue, UiLengthUnits)
                rowString(9) = Format$(uiValue, Fmt)

                'Froude number
                rowString(10) = Format$(.FroudeNumberMax, Fmt)

                'Extra freeboard
                siValue = .ActualFreeboard - .RequiredFreeboard
                uiValue = UiLengthValue(siValue, UiLengthUnits)
                rowString(11) = Format$(uiValue, Fmt)

                'Extra head loss (i.e., submergence protection)
                siValue = SubmergenceProtection
                uiValue = UiLengthValue(siValue, UiLengthUnits)
                rowString(12) = Format$(uiValue, Fmt)

                'Error at Qmax and Qmin
                rowString(13) = "± " & Format$(.FlowRateMeasurementErrorAtQMax, "######0.00 ") & "to " &
                                   Format$(.FlowRateMeasurementErrorAtQMin, "######0.00 ") & "%"
            End With

            Me.ReviewDesignsTable.Rows.Add(rowString)

            Debug.Assert(i = c)
        Next i

        ' Highlight the "Not OK" cells
        For row As Integer = 0 To Me.ReviewDesignsTable.Rows.Count - 1
            For col As Integer = 0 To Me.ReviewDesignsTable.Columns.Count - 1
                Dim cell As DataGridViewCell = Me.ReviewDesignsTable.Item(col, row)
                Dim obj As Object = cell.Value
                If (obj IsNot Nothing) Then
                    If (obj.GetType = GetType(String)) Then
                        Dim str As String = DirectCast(obj, String)
                        If (str = My.Resources.NotOK) Then
                            If ((MinPrimaryCol <= col) And (col <= MaxPrimaryCol)) Then
                                cell.Style.BackColor = Color.FromArgb(255, 255, 128, 128) ' Medium Red
                            ElseIf ((MinSecondaryCol <= col) And (col <= MaxSecondaryCol)) Then
                                cell.Style.BackColor = Color.FromArgb(255, 255, 255, 128) ' Medium Yellow
                            End If
                        End If
                    End If
                Else
                    Debug.Assert(False)
                End If
            Next col
        Next row

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Sub MyBase_VisibleChanged() - update UI whenever Visible state changes
    '*********************************************************************************************************
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.VisibleChanged
        mVisibleChanged = True

        mFlume = WinFlumeForm.Flume

        If (mFlume Is Nothing) Then
            Return
        End If

        UpdateUI()

    End Sub

    '*********************************************************************************************************
    ' Sub ReviewDesignsTable_SelectionChanged() - display selected row's Design Report
    '*********************************************************************************************************
    Private Sub ReviewDesignsTable_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ReviewDesignsTable.SelectionChanged

        If (Me.Dialog Is Nothing) Then ' Running in WinFlume control
            If Not (mUpdatingUI) Then
                Dim curRow As DataGridViewRow = ReviewDesignsTable.CurrentRow
                SelectedRowIndex = curRow.Index
                If (mWinFlumeDesign IsNot Nothing) Then
                    ' Display Control Section selection for selected design
                    Dim controlShape As Integer = mFlume.Section(cControl).Shape

                    Select Case (controlShape)
                        Case shSillInTrapezoid, shSillInRectangle, shSillInVShaped,
                             shTrapezoidInTrapezoid, shTrapezoidInVShaped, shTrapezoidInRectangle,
                             shRectangleInRectangle,
                             shCircleInCircle,
                             shParabolaInParabola,
                             shUShapedInUShaped,
                             shVShapedInVShaped

                            ' Leave as is
                        Case Else
                            Dim evalDesign As FlumeType = mWinFlumeDesign.EvaluationFlumes(SelectedRowIndex + 1)
                            Dim evalShape As Integer = evalDesign.Section(cControl).Shape
                            Dim shapeText As String = SectionString(evalShape)
                            Me.ControlSectionShape.Text = shapeText
                    End Select

                End If

                MakeSelectedCurrent()

                mWinFlumeForm.GetDesignControl.SideBarControl.UpdateUI(mWinFlumeForm)

            End If
        End If

    End Sub

    '*********************************************************************************************************
    ' Make Selected Design the Current Design button event handlers
    '*********************************************************************************************************
    Friend Sub MakeSelectedCurrent()

        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing) And (mWinFlumeDesign IsNot Nothing)) Then

            ReviewDesignsTable.AddUndoItem(mFlume, "Alternate Selection Changed")

            Dim curRow As DataGridViewRow = ReviewDesignsTable.CurrentRow
            If (curRow IsNot Nothing) Then

                Dim msg, title As String

                ' If not within a Dialog; setup Undo/Redo
                If (Me.Dialog Is Nothing) Then
                    WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
                End If

                ' Match Control to Approach state must be maintained
                Dim oldCtrlSection = mFlume.Section(cControl)
                Dim oldCtrlShape As Integer = oldCtrlSection.Shape
                Dim oldContraction As Integer = mFlume.ContractionAdjustment

                ' Get newly selected Flume
                SelectedRowIndex = curRow.Index
                mFlume = mWinFlumeDesign.EvaluationFlumes(SelectedRowIndex + 1)
                Dim newCtrlSection = mFlume.Section(cControl)
                Dim newCtrlShape As Integer = newCtrlSection.Shape
                Dim newContraction As Integer = mFlume.ContractionAdjustment

                If (oldCtrlSection.GetType Is GetType(WinFlumeSectionType)) Then

                    ' Update new Flume from Flume.DLL to maintain WinFlume state
                    Dim oldWinFlumeSection = DirectCast(oldCtrlSection, WinFlumeSectionType)
                    Dim newWinFlumeSection = New WinFlumeSectionType(oldWinFlumeSection)
                    newWinFlumeSection.LoadFlumeSectionType(newCtrlSection)
                    Dim matchConstraints As Integer = newWinFlumeSection.MatchConstraints
                    If (BitSet(matchConstraints, MatchConstraint.InnerSillHeightMatchesProfileSillHeight)) Then
                        newWinFlumeSection.D1 = mFlume.SillHeight
                    End If
                    newWinFlumeSection.Shape = oldCtrlShape
                    mFlume.Section(cControl) = newWinFlumeSection
                    mFlume.ContractionAdjustment = oldContraction

                    Select Case (newWinFlumeSection.Shape)
                        Case shTrapezoidInCircle, shTrapezoidInParabola, shTrapezoidInUShaped,
                             shTrapezoidInRectangle, shTrapezoidInTrapezoid, shTrapezoidInVShaped,
                             shRectangleInRectangle

                            Dim BW As Single = newWinFlumeSection.BottomWidth
                            Dim D1 As Single = newWinFlumeSection.D1

                            Dim apprSection = mFlume.Section(cApproach)
                            Dim apprTWatD1 As Single = apprSection.TopWidth(D1, False)

                            If (BW >= apprTWatD1) Then

                                msg = My.Resources.BottomWidthLimited & vbCrLf & vbCrLf
                                msg &= My.Resources.SimplifyToSill
                                title = My.Resources.BottomWidth

                                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                                If (result = MsgBoxResult.Yes) Then
                                    ' A change from Trapezoid-In-Shape to Sill-In-Shape has been requested
                                    Select Case (newWinFlumeSection.Shape)
                                        Case shTrapezoidInCircle
                                            mFlume.Section(cControl).Shape = shSillInCircle
                                        Case shTrapezoidInParabola
                                            mFlume.Section(cControl).Shape = shSillInParabola
                                        Case shTrapezoidInUShaped
                                            mFlume.Section(cControl).Shape = shSillInUShaped
                                        Case shTrapezoidInRectangle
                                            mFlume.Section(cControl).Shape = shSillInRectangle
                                        Case shTrapezoidInTrapezoid
                                            mFlume.Section(cControl).Shape = shSillInTrapezoid
                                        Case shTrapezoidInVShaped
                                            mFlume.Section(cControl).Shape = shSillInVShaped
                                        Case shRectangleInRectangle
                                            mFlume.Section(cControl).Shape = shSillInRectangle
                                    End Select
                                End If
                            End If
                    End Select

                Else ' (oldCtrlSection.GetType Is GetType(Flume.SectionType))

                    Select Case (newCtrlSection.Shape)
                        Case shTrapezoidInCircle, shTrapezoidInParabola, shTrapezoidInUShaped

                            Dim BW As Single = newCtrlSection.BottomWidth
                            Dim D1 As Single = newCtrlSection.D1

                            Dim apprSection = mFlume.Section(cApproach)
                            Dim apprTWatD1 As Single = apprSection.TopWidth(D1, False)

                            If (BW >= apprTWatD1) Then

                                msg = My.Resources.BottomWidthLimited & vbCrLf & vbCrLf
                                msg &= My.Resources.SimplifyToSill
                                title = My.Resources.BottomWidth

                                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                                If (result = MsgBoxResult.Yes) Then
                                    ' A change from Trapezoid-In-Shape to Sill-In-Shape has been requested
                                    Select Case (newCtrlSection.Shape)
                                        Case shTrapezoidInCircle
                                            newCtrlSection.Shape = shSillInCircle
                                        Case shTrapezoidInParabola
                                            newCtrlSection.Shape = shSillInParabola
                                        Case shTrapezoidInUShaped
                                            newCtrlSection.Shape = shSillInUShaped
                                    End Select
                                End If
                            End If
                    End Select
                End If

                Me.SelectedFlume = mFlume
                WinFlumeForm.SetFlume(mFlume) ' Set new Flume
                mWinFlumeForm.RaiseFlumeDataChanged() ' Inform others of change

            End If ' (curRow IsNot Nothing)
        End If
    End Sub

    Private Sub ReviewDesignsTable_UndoTableEvent(ByVal UndoValue As Object) _
        Handles ReviewDesignsTable.UndoTableEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (Me.Dialog IsNot Nothing) Then
                Debug.Assert(False)
            Else
                If (UndoValue.GetType Is GetType(FlumeType)) Then
                    ' Set Flume for Redo point
                    ReviewDesignsTable.AddRedoItem(mFlume)
                    ' Restore Flume object
                    mFlume = DirectCast(UndoValue, FlumeType)
                    WinFlumeForm.SetFlume(mFlume)
                    mWinFlumeForm.RaiseFlumeDataChanged()
                Else
                    Debug.Assert(False, "Undo - Invalid value type")
                End If
            End If
        End If
    End Sub

    Private Sub ReviewDesignsTable_RedoTableEvent(ByVal RedoValue As Object) _
        Handles ReviewDesignsTable.RedoTableEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (Me.Dialog IsNot Nothing) Then
                Debug.Assert(False)
            Else
                If (RedoValue.GetType Is GetType(FlumeType)) Then
                    ' Set Flume for Undo point
                    ReviewDesignsTable.AddUndoItem(mFlume)
                    ' Restore Flume table
                    mFlume = DirectCast(RedoValue, FlumeType)
                    WinFlumeForm.SetFlume(mFlume)
                    mWinFlumeForm.RaiseFlumeDataChanged()
                Else
                    Debug.Assert(False, "Redo - Invalid value type")
                End If
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub AlternativeDesignsControl_Load() - runtime initialization of control
    '*********************************************************************************************************
    Private Sub AlternativeDesignsControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.ReviewDesignsTable
            ' Use 9-point / bold font for header text
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 67
            .ColumnHeadersDefaultCellStyle.Font = New Font(Me.Font.FontFamily, 9, FontStyle.Bold)

            ' Minimize column widths
            Dim numCols As Integer = .Columns.Count
            Dim colWidths() As Integer = {55, 55, 85, 85, 85, 85, 85, 85, 90, 65, 65, 90, 110, 122}

            Debug.Assert(numCols = colWidths.Length)

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            For cdx As Integer = 0 To numCols - 1
                Dim col As DataGridViewColumn = .Columns(cdx)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                col.Width = colWidths(cdx)
            Next cdx
        End With

    End Sub

    '*********************************************************************************************************
    ' Sub ViewAsDialogButton_Click() - display table/graph as dialog box
    '*********************************************************************************************************
    Private Sub ViewAsDialogButton_Click_1(sender As Object, e As EventArgs) _
        Handles ViewAsDialogButton.Click
        mWinFlumeForm.AlternativeDesignsAsDialog()
    End Sub

#End Region

End Class
