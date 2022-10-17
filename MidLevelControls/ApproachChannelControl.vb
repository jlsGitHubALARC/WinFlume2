
'*************************************************************************************************************
' Class ApproachChannelControl - UserControl for displaying & editing the Approach Channel
'*************************************************************************************************************
Imports System.Windows

Imports Flume
Imports Flume.Globals

Imports WinFlume.WinFlumeSectionType

Public Class ApproachChannelControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mApproachSection As Flume.SectionType = Nothing
    '
    ' Cross section controls
    '
    Private stCtrl As SimpleTrapezoidControl = Nothing
    Private reCtrl As RectangularControl = Nothing
    Private vsCtrl As VShapedControl = Nothing
    Private ciCtrl As CircleControl = Nothing
    Private usCtrl As UShapedControl = Nothing
    Private paCtrl As ParabolaControl = Nothing
    Private ctCtrl As ComplexTrapezoidControl = Nothing

    Public Function GetCrossSectionControl(ByVal SectionIdx As Integer) As CrossSectionControl
        Dim crossSectionCtrl As CrossSectionControl = Nothing
        Select Case SectionIdx
            Case shSimpleTrapezoid
                crossSectionCtrl = stCtrl
            Case shRectangular
                crossSectionCtrl = reCtrl
            Case shVShaped
                crossSectionCtrl = vsCtrl
            Case shCircle
                crossSectionCtrl = ciCtrl
            Case shUShaped
                crossSectionCtrl = usCtrl
            Case shParabola
                crossSectionCtrl = paCtrl
            Case shComplexTrapezoid
                crossSectionCtrl = ctCtrl
            Case Else
                Debug.Assert(False)
        End Select
        Return crossSectionCtrl
    End Function

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Approach cross section
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data

        If ((mFlume IsNot Nothing) And (0 < Me.ApproachCrossSection.Items.Count)) Then

            mApproachSection = mFlume.Section(cApproach)                    ' Approach Section data

            ' Update value of Control / Approach matching
            Me.ControlMatchedToApproachCheckBox.Value = WinFlumeForm.ControlMatchedToApproach
            Me.ControlMatchedToApproachCheckBox.Visible = WinFlumeForm.ControlMatchedToApproach

            ' Update cross section control to match Section data
            Select Case (mApproachSection.Shape)

                Case shSimpleTrapezoid

                    If (stCtrl Is Nothing) Then
                        stCtrl = New SimpleTrapezoidControl(Flume.cApproach)
                    End If

                    UpdateCrossSection(stCtrl)
                    stCtrl.UpdateUI(mWinFlumeForm)

                Case shRectangular

                    If (reCtrl Is Nothing) Then
                        reCtrl = New RectangularControl(Flume.cApproach)
                    End If

                    UpdateCrossSection(reCtrl)
                    reCtrl.UpdateUI(mWinFlumeForm)

                Case shVShaped

                    If (vsCtrl Is Nothing) Then
                        vsCtrl = New VShapedControl(Flume.cApproach)
                    End If

                    UpdateCrossSection(vsCtrl)
                    vsCtrl.UpdateUI(mWinFlumeForm)

                Case shCircle

                    If (ciCtrl Is Nothing) Then
                        ciCtrl = New CircleControl(Flume.cApproach)
                    End If

                    UpdateCrossSection(ciCtrl)
                    ciCtrl.UpdateUI(mWinFlumeForm)

                Case shUShaped

                    If (usCtrl Is Nothing) Then
                        usCtrl = New UShapedControl(Flume.cApproach)
                    End If

                    UpdateCrossSection(usCtrl)
                    usCtrl.UpdateUI(mWinFlumeForm)

                Case shParabola

                    If (paCtrl Is Nothing) Then
                        paCtrl = New ParabolaControl(Flume.cApproach)
                    End If

                    UpdateCrossSection(paCtrl)
                    paCtrl.UpdateUI(mWinFlumeForm)

                Case shComplexTrapezoid

                    If (ctCtrl Is Nothing) Then
                        ctCtrl = New ComplexTrapezoidControl(Flume.cApproach)
                    End If

                    UpdateCrossSection(ctCtrl)
                    ctCtrl.UpdateUI(mWinFlumeForm)

                Case Else
                    Debug.Assert(False, "Invalid cross section shape")
            End Select

            ' Update cross section selection to match Section data
            ApproachChannelControl_Load()
            Me.ApproachCrossSection.Value = mApproachSection.Shape - 1
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub UpdateCrossSection()  - ensure cross section control is being displayed
    '
    ' Input(s):         Ctrl    - Cross-Section control that should be displayed
    '*********************************************************************************************************
    Protected Sub UpdateCrossSection(ByVal Ctrl As CrossSectionControl)

        If (mFlume IsNot Nothing) Then
            Dim ControlSection As Flume.SectionType = mFlume.Section(cControl)

            If (0 = Me.CrossSectionPanel.Controls.Count) Then ' No controls are displayed
                Me.CrossSectionPanel.Controls.Add(Ctrl) ' Add requested one
            ElseIf (Me.CrossSectionPanel.Controls(0) IsNot Ctrl) Then ' Requested control is not displayed
                Me.CrossSectionPanel.Controls.Clear()   ' Clear current control(s)
                Me.CrossSectionPanel.Controls.Add(Ctrl) ' Add requested one
            End If

            ' Add back the 'Control is Matched to Approach' button
            Me.CrossSectionPanel.Controls.Add(Me.ControlMatchedToApproachCheckBox)
            Me.ControlMatchedToApproachCheckBox.BringToFront()

            If (ControlSection.GetType Is GetType(WinFlumeSectionType)) Then
                ' Set behavior of the Cross-Section Control for the Approach Channel
                Dim sectionType As WinFlumeSectionType = DirectCast(ControlSection, WinFlumeSectionType)
                Dim matchConstraints As Integer = sectionType.MatchConstraints

                If (BitSet(matchConstraints, MatchConstraint.OuterShapeMatchesApproachChannel)) Then
                    Ctrl.OuterIsReadOnly = True
                Else
                    Ctrl.OuterIsReadOnly = False
                End If
            Else
                Ctrl.OuterIsReadOnly = False
            End If

            Ctrl.Dock = DockStyle.Fill
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls()    - position contained Controls
    '*********************************************************************************************************
    Protected Sub PositionControls()

        ' Cross Section selection
        Dim loc As Point = Me.ApproachCrossSection.Location
        loc.X = Me.Width - Me.ApproachCrossSection.Width
        Me.ApproachCrossSection.Location = loc

        If (WinFlumeForm.ControlMatchedToApproach) Then
            loc = Me.ControlMatchedToApproachCheckBox.Location
            loc.X = Me.Width - Me.ControlMatchedToApproachCheckBox.Width - Me.Margin.Horizontal
            loc.Y = Margin.Vertical
            Me.ControlMatchedToApproachCheckBox.Location = loc
            Me.ControlMatchedToApproachCheckBox.BringToFront()
        End If

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Sub OnPaint() - ensure contained Controls are correctly positioned when Control is re-painted
    '*********************************************************************************************************
    Protected Overrides Sub OnPaint(ByVal e As Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.PositionControls()
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Sub ApproachChannelControl_Load() - handle Load event to initialize contained Controls
    '*********************************************************************************************************
    Private Sub ApproachChannelControl_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Load
        ' Load cross section selections
        ApproachChannelControl_Load()

        ' Default to NO Control to Approach matching
        Me.ControlMatchedToApproachCheckBox.Value = False
        Me.ControlMatchedToApproachCheckBox.HandleCheckedChanged = False

        ' Default to Simple Trapezoid cross section
        stCtrl = New SimpleTrapezoidControl(Flume.cApproach)
        UpdateCrossSection(stCtrl)
        stCtrl.UpdateUI(mWinFlumeForm)

    End Sub

    Private Sub ApproachChannelControl_Load()

        ' Load cross section selections
        Me.ApproachCrossSection.Items.Clear()
        If (WinFlumeForm.ControlMatchedToApproach) Then
            If (mFlume IsNot Nothing) Then
                Dim section As Flume.SectionType = mFlume.Section(cApproach)
                Me.ApproachCrossSection.Items.Add(SectionString(section.Shape))
            Else
                Me.ApproachCrossSection.Items.Add(SectionString(shSimpleTrapezoid))
            End If
            Me.ApproachCrossSection.Value = 0
        Else
            Me.ApproachCrossSection.Items.Add(SectionString(shSimpleTrapezoid))
            Me.ApproachCrossSection.Items.Add(SectionString(shRectangular))
            Me.ApproachCrossSection.Items.Add(SectionString(shVShaped))
            Me.ApproachCrossSection.Items.Add(SectionString(shCircle))
            Me.ApproachCrossSection.Items.Add(SectionString(shUShaped))
            Me.ApproachCrossSection.Items.Add(SectionString(shParabola))
            Me.ApproachCrossSection.Items.Add(SectionString(shComplexTrapezoid))
        End If
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub ApproachCrossSection_ValueChanged() Handles ApproachCrossSection.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            mApproachSection = mFlume.Section(cApproach)                ' Section data
            mApproachSection.Shape = Me.ApproachCrossSection.Value + 1  ' Save new cross section selection

            If (WinFlumeForm.TailwaterMatchedToApproach) Then
                Dim tailSection As SectionType = mFlume.Section(cTailwater)
                tailSection.Shape = mApproachSection.Shape
            End If

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub ApproachChannelControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub ApproachChannelControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize
        Dim ctrlSize As Size = New Size(Me.Width, Me.Height - Me.CrossSectionPanel.Location.Y)
        Me.CrossSectionPanel.Size = ctrlSize
    End Sub

    '*********************************************************************************************************
    ' Handlers for 'Match Control To Approach' check box
    '*********************************************************************************************************
    Private Sub MatchControlToApproachCheckBox_MouseDown(sender As Object, e As EventArgs) _
        Handles ControlMatchedToApproachCheckBox.MouseDown

        If (Me.ControlMatchedToApproachCheckBox.Value = True) Then ' Match is checked

            Debug.Assert(mFlume.Section(cControl).GetType Is GetType(WinFlumeSectionType))

            ' Set current Flume object as Undo point; new Flume object must be created for new data
            ControlMatchedToApproachCheckBox.AddUndoItem(mFlume)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Instantiate new Flume object
            mFlume = WinFlumeForm.NewFlumeType(mFlume)
            mFlume.ControlMatchedToApproach = False
            mFlume.MatchedControlShape = 0

            ' Demote WinFlumeSectionType to Flume.SectionType
            mFlume.Section(cControl) = New Flume.SectionType(mFlume.Section(cControl))

            ' Generate 'non-matched' equivalent Control cross-section
            With mFlume.Section(cControl)
                Select Case (.Shape)
                    Case shSillInTrapezoid, shSillInVShaped
                        .BottomWidth = .TopWidth(0, False)
                        .Shape = shSimpleTrapezoid
                    Case shTrapezoidInTrapezoid, shTrapezoidInVShaped
                        .Shape = shSimpleTrapezoid
                    Case shSillInRectangle, shRectangleInRectangle
                        .Shape = shRectangular
                    Case shCircleInCircle
                        .Shape = shCircle
                    Case shParabolaInParabola
                        .Shape = shParabola
                    Case shUShapedInUShaped
                        .Shape = shUShaped
                    Case shVShapedInVShaped
                        .Shape = shVShaped
                    Case shTrapezoidInRectangle
                        .Shape = shComplexTrapezoid
                End Select
            End With

            WinFlumeForm.SetFlume(mFlume)
            mWinFlumeForm.RaiseFlumeDataChanged()

        Else ' Match is not checked; show Match Control to Approach dialog
            Debug.Assert(False)
        End If

    End Sub

    Private Sub MatchControlToApproachCheckBox_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles ControlMatchedToApproachCheckBox.UndoButtonEvent

        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(FlumeType)) Then
                ' Set Flume for Redo point
                ControlMatchedToApproachCheckBox.AddRedoItem(mFlume)
                ' Restore Flume object
                mFlume = DirectCast(UndoValue, FlumeType)
                WinFlumeForm.SetFlume(mFlume)
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub MatchControlToApproachCheckBox_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles ControlMatchedToApproachCheckBox.RedoButtonEvent

        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(FlumeType)) Then
                ' Set Flume for Undo point
                ControlMatchedToApproachCheckBox.AddUndoItem(mFlume)
                ' Restore Flume table
                mFlume = DirectCast(RedoValue, FlumeType)
                WinFlumeForm.SetFlume(mFlume)
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

#End Region

End Class
