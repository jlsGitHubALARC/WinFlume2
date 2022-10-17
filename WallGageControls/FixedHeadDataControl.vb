
'*************************************************************************************************************
' Class FixedHeadDataControl - UserControl for generating the Fixed-Head Interval Wall Gage data
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog    ' Unit conversion support

Public Class FixedHeadDataControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mSection As Flume.SectionType = Nothing
    '
    ' Wall Gage Options data
    '
    Private Const DesiredLines As Integer = 30                  ' Rating Table entries after Smart Range

    Private Class SmartRangeUndoRedo                            ' Smart Range Undo/Redo data
        Public RangeMin As Single
        Public RangeMax As Single
        Public RangeInc As Single
        Public Sub New(ByVal Min As Single, ByVal Max As Single, ByVal Inc As Single)
            Me.RangeMin = Min
            Me.RangeMax = Max
            Me.RangeInc = Inc
        End Sub
    End Class

#End Region

#Region " Data Methods "

    Public Sub ValidateHeadSmartRange(ByVal Flume As FlumeType)

        If (Flume IsNot Nothing) Then

            Dim Hmin As Single = Flume.WGageHMin
            Dim Hmax As Single = Flume.WGageHMax
            Dim Hinc As Single = Flume.WGageHInc

            If ((Hmin <= 0) And (Hmax <= 0) And (Hinc <= 0)) Then
                Flume.SmartRange(Hmin, Hmax, Hinc, HQTable, DesiredLines, False)
                Flume.WGageHMin = Hmin
                Flume.WGageHMax = Hmax
                Flume.WGageHInc = Hinc
            End If
        End If

    End Sub

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display the Fixed-Head Interval Wall Gage options & data
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data
        If ((mFlume Is Nothing) Or (Not (Me.Visible))) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Debug.Assert(False)
            Return
        End If
        mUpdatingUI = True

        ValidateHeadSmartRange(mFlume)

        Dim Hmin As Single = mFlume.WGageHMin
        Dim Hmax As Single = mFlume.WGageHMax
        Dim Hinc As Single = mFlume.WGageHInc
        Dim P1 As Single = mFlume.SillHeight

        ' Update Fixed-Head Interval parameters
        Me.MinimumHeadSingle.SiUnits = LengthUnitsAbbreviations(0)
        Me.MinimumHeadSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageHMin
        Me.MinimumHeadSingle.SiValue = Hmin
        Me.MinimumHeadSingle.Label = Me.MinimumHeadLabel.Text

        Me.MaximumHeadSingle.SiUnits = LengthUnitsAbbreviations(0)
        Me.MaximumHeadSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageHMax
        Me.MaximumHeadSingle.SiValue = Hmax
        Me.MaximumHeadSingle.Label = Me.MaximumHeadLabel.Text

        Me.HeadIncrementSingle.SiUnits = LengthUnitsAbbreviations(0)
        Me.HeadIncrementSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageHInc
        Me.HeadIncrementSingle.SiValue = Hinc
        Me.HeadIncrementSingle.Label = Me.HeadIncrementLabel.Text

        ' Update Wall Gage Options
        Me.SillReferencedButton.Label = Me.GageReferenceGroup.Text
        Me.SillReferencedButton.RbValue = WallGageRefTopOfSill
        Me.SillReferencedButton.UiValue = mFlume.WGageRef

        Me.UpstreamChannellBottomButton.Label = Me.GageReferenceGroup.Text
        Me.UpstreamChannellBottomButton.RbValue = WallGageRefApproachBottom
        Me.UpstreamChannellBottomButton.UiValue = mFlume.WGageRef

        Me.GageSlopeSingle.SiUnits = ""
        Me.GageSlopeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageZ
        Me.GageSlopeSingle.SiValue = mFlume.WGageZ
        Me.GageSlopeSingle.Label = "Z"

        ' Update Wall Gage table column headers
        Dim UiLunits As String = UiLengthUnitsText()
        Dim UiQunits As String = UiDischargeUnitsText()

        Dim headColumnText As String = ""
        Dim distanceColumnText As String = ""
        Dim dischargeColumnText As String = ""
        Dim zRatio As String = mFlume.WGageZ.ToString & ":1"

        If (mFlume.WGageRef = WallGageRefTopOfSill) Then ' Sill-Referenced
            headColumnText = My.Resources.SillReferenced
            distanceColumnText = My.Resources.SillReferenced
        Else ' Bottom-Referenced
            headColumnText = My.Resources.BottomReferenced
            distanceColumnText = My.Resources.BottomReferenced
        End If

        headColumnText &= vbCrLf & My.Resources.Head & " (" & UiLunits & ")"
        headColumnText &= vbCrLf & My.Resources.Vertical.ToLower

        distanceColumnText &= vbCrLf & My.Resources.Distance & " (" & UiLunits & ")"
        distanceColumnText &= vbCrLf & My.Resources.Slope.ToLower & " " & zRatio

        dischargeColumnText &= vbCrLf & My.Resources.Discharge
        dischargeColumnText &= vbCrLf & "(" & UiQunits & ")"

        Me.FixedHeadIntervalTable.Columns(0).HeaderText = headColumnText
        Me.FixedHeadIntervalTable.Columns(1).HeaderText = distanceColumnText
        Me.FixedHeadIntervalTable.Columns(2).HeaderText = dischargeColumnText

        ' Update Wall Gage table data
        Dim RatingResults(1) As RatingResultsType
        Dim TableErrors(MaxHydErrors) As Boolean
        Dim uiValue As Single = 0
        Dim formatStyle As String = "0.000"

        mFlume.MakeRating(HQTable, False, Hmin, Hmax, Hinc, RatingResults, TableErrors)

        Me.FixedHeadIntervalTable.Rows.Clear()

        For Each RatingResult As RatingResultsType In RatingResults
            If (RatingResult IsNot Nothing) Then

                Dim rowString(2) As String

                Dim h1 As Single = RatingResult.SMALLh1
                Dim Q As Single = RatingResult.Q

                Dim TotalH As Single = h1
                If (mFlume.WGageRef = WallGageRefApproachBottom) Then ' Bottom-Referenced; add Sill Height
                    TotalH += P1
                End If
                Dim Dist As Single = CSng(TotalH * Math.Sqrt(1 + mFlume.WGageZ ^ 2))

                uiValue = UiLengthValue(TotalH, UiLengthUnits)      ' Head
                rowString(0) = Format(uiValue, formatStyle)

                uiValue = UiLengthValue(Dist, UiLengthUnits)        ' Distance
                rowString(1) = Format(uiValue, formatStyle)

                uiValue = UiDischargeValue(Q, UiDischargeUnits)     ' Discharge
                rowString(2) = Format(uiValue, formatStyle)

                If (RatingResult.FatalError Or RatingResult.NonFatalError) Then
                    rowString(0) &= "*"
                End If

                Me.FixedHeadIntervalTable.Rows.Add(rowString)

            End If
        Next RatingResult

        ' Update status
        Me.StatusPanel.Title.Text = My.Resources.AllWarningMessagesForThisTable
        Me.StatusPanel.StatusBox.Clear()

        Dim edx As Integer = 0
        Dim errText As String = ""
        For Each errBool In TableErrors
            If (errBool) Then
                If (edx < 10) Then
                    errText &= " "
                End If
                errText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
            End If
            edx += 1
        Next errBool

        Me.StatusPanel.StatusBox.Text = errText

        mUpdatingUI = False
    End Sub

#End Region

#Region " Event Handlers "

#Region " Wall Gage Options "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub MyBase_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub SillReferencedButton_ValueChanged(NewValue As Integer) _
        Handles SillReferencedButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageRef = NewValue) Then
                mFlume.WGageRef = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub UpstreamChannellBottomButton_ValueChanged(NewValue As Integer) _
        Handles UpstreamChannellBottomButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageRef = NewValue) Then
                mFlume.WGageRef = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub GageSlopeSingle_ValueChanged() _
        Handles GageSlopeSingle.ValueChanged
        Dim GageZ As Single = Me.GageSlopeSingle.SiValue
        If Not (mFlume.WGageZ = GageZ) Then
            mFlume.WGageZ = GageZ
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub Mybase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize

        Dim dataWidth As Integer = Me.DataPanel.Width
        Dim dataHeight As Integer = Me.DataPanel.Height
        Dim boxWidth As Integer = dataWidth - Me.WallGageOptionsBox.Width - Me.Margin.Horizontal * 2
        Dim boxHeight As Integer = dataHeight - Me.Margin.Vertical

        Me.WallGageDataBox.Width = boxWidth
        Me.WallGageDataBox.Height = boxHeight
    End Sub

#End Region

#Region " Fixed-Head Interval "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub MinimumHeadRange_ValueChanged() Handles MinimumHeadSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hmin As Single = Me.MinimumHeadSingle.SiValue
            If Not (mFlume.WGageHMin = Hmin) Then
                mFlume.WGageHMin = Hmin
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MaximumHeadRange_ValueChanged() Handles MaximumHeadSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hmax As Single = Me.MaximumHeadSingle.SiValue
            If Not (mFlume.WGageHMax = Hmax) Then
                mFlume.WGageHMax = Hmax
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadIncrementSingle_ValueChanged() Handles HeadIncrementSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hinc As Single = Me.HeadIncrementSingle.SiValue
            If Not (mFlume.WGageHInc = Hinc) Then
                mFlume.WGageHInc = Hinc
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Button event handlers - Click, UndoButtonEvent, RedoButtonEvent
    '
    ' Note - Undo/Redo handling is specific to each Button since the action taken is not known to ctl_Button.
    '*********************************************************************************************************
    Private Sub HeadSmartRangeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles HeadSmartRangeButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Set current selections as Undo point
            Dim Hmin As Single = mFlume.WGageHMin
            Dim Hmax As Single = mFlume.WGageHMax
            Dim Hinc As Single = mFlume.WGageHInc
            Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
            HeadSmartRangeButton.AddUndoItem(SmartRangeUndo)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
            ' Set Smart Range values
            mFlume.SmartRange(Hmin, Hmax, Hinc, HQTable, DesiredLines, True)
            mFlume.WGageHMin = Hmin
            mFlume.WGageHMax = Hmax
            mFlume.WGageHInc = Hinc

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub HeadSmartRangeButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles HeadSmartRangeButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Redo point
                Dim Hmin As Single = mFlume.WGageHMin
                Dim Hmax As Single = mFlume.WGageHMax
                Dim Hinc As Single = mFlume.WGageHInc
                Dim SmartRangeRedo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
                HeadSmartRangeButton.AddRedoItem(SmartRangeRedo)
                ' Get Undo point's selections
                Dim SmartRangeUndo As SmartRangeUndoRedo = DirectCast(UndoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageHMin = SmartRangeUndo.RangeMin
                mFlume.WGageHMax = SmartRangeUndo.RangeMax
                mFlume.WGageHInc = SmartRangeUndo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub HeadSmartRangeButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles HeadSmartRangeButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Undo point
                Dim Hmin As Single = mFlume.WGageHMin
                Dim Hmax As Single = mFlume.WGageHMax
                Dim Hinc As Single = mFlume.WGageHInc
                Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
                HeadSmartRangeButton.AddUndoItem(SmartRangeUndo)
                ' Get Redo point's selections
                Dim SmartRangeRedo As SmartRangeUndoRedo = DirectCast(RedoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageHMin = SmartRangeRedo.RangeMin
                mFlume.WGageHMax = SmartRangeRedo.RangeMax
                mFlume.WGageHInc = SmartRangeRedo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#End Region

End Class
