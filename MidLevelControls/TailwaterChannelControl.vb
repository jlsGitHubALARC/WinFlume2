
'*************************************************************************************************************
' Class TailwaterChannelControl - UserControl for displaying & editing the Tailwater Channel
'*************************************************************************************************************
Imports System.Windows
Imports Flume
Imports Flume.Globals

Public Class TailwaterChannelControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mApproachChannel As Flume.SectionType = Nothing
    Private mTailwaterChannel As Flume.SectionType = Nothing
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
    ' Sub UpdateUI() - Update UI to display selected Tailwater cross section
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                 ' Flume accessor

        If ((mFlume IsNot Nothing) And (0 < Me.TailwaterCrossSection.Items.Count)) Then

            mTailwaterChannel = mFlume.Section(cTailwater)          ' Tailwater Section data

            ' Load cross section selections
            TailwaterCrossSection_Load()

            Me.MatchTailwaterToApproachCheckBox.Value = WinFlumeForm.TailwaterMatchedToApproach

            ' Update cross section selection to match Section data
            Me.TailwaterCrossSection.Value = mTailwaterChannel.Shape - 1

            Select Case (mTailwaterChannel.Shape)

                Case shSimpleTrapezoid

                    If (stCtrl Is Nothing) Then
                        stCtrl = New SimpleTrapezoidControl(Flume.cTailwater)
                    End If

                    UpdateCrossSection(stCtrl)
                    stCtrl.UpdateUI(mWinFlumeForm)

                Case shRectangular

                    If (reCtrl Is Nothing) Then
                        reCtrl = New RectangularControl(Flume.cTailwater)
                    End If

                    UpdateCrossSection(reCtrl)
                    reCtrl.UpdateUI(mWinFlumeForm)

                Case shVShaped

                    If (vsCtrl Is Nothing) Then
                        vsCtrl = New VShapedControl(Flume.cTailwater)
                    End If

                    UpdateCrossSection(vsCtrl)
                    vsCtrl.UpdateUI(mWinFlumeForm)

                Case shCircle

                    If (ciCtrl Is Nothing) Then
                        ciCtrl = New CircleControl(Flume.cTailwater)
                    End If

                    UpdateCrossSection(ciCtrl)
                    ciCtrl.UpdateUI(mWinFlumeForm)

                Case shUShaped

                    If (usCtrl Is Nothing) Then
                        usCtrl = New UShapedControl(Flume.cTailwater)
                    End If

                    UpdateCrossSection(usCtrl)
                    usCtrl.UpdateUI(mWinFlumeForm)

                Case shParabola

                    If (paCtrl Is Nothing) Then
                        paCtrl = New ParabolaControl(Flume.cTailwater)
                    End If

                    UpdateCrossSection(paCtrl)
                    paCtrl.UpdateUI(mWinFlumeForm)

                Case shComplexTrapezoid

                    If (ctCtrl Is Nothing) Then
                        ctCtrl = New ComplexTrapezoidControl(Flume.cTailwater)
                    End If

                    UpdateCrossSection(ctCtrl)
                    ctCtrl.UpdateUI(mWinFlumeForm)

                Case Else
                    Debug.Assert(False, "Invalid cross section shape")
            End Select

        End If

    End Sub

    '*********************************************************************************************************
    ' Sub UpdateCrossSection() - ensure cross section control is being displayed
    '
    ' Input(s):         Ctrl    - control that should be displayed
    '*********************************************************************************************************
    Protected Sub UpdateCrossSection(ByVal Ctrl As Control)

        If (0 = Me.CrossSectionPanel.Controls.Count) Then ' No controls are displayed
            Me.CrossSectionPanel.Controls.Add(Ctrl) ' Add requested one
        ElseIf (Me.CrossSectionPanel.Controls(0) IsNot Ctrl) Then ' Requested control is not displayed
            Me.CrossSectionPanel.Controls.Clear()   ' Clear current control(s)
            Me.CrossSectionPanel.Controls.Add(Ctrl) ' Add requested one
        End If

        ' Add back the 'Match Tailwater to Approach' controls
        Me.CrossSectionPanel.Controls.Add(Me.MatchTailwaterToApproachCheckBox)
        Me.MatchTailwaterToApproachCheckBox.BringToFront()
        Me.MatchTailwaterToApproachCheckBox.Show()

        ' Add back the 'Make Identical...' button
        'Me.CrossSectionPanel.Controls.Add(Me.MakeIdenticalToButton)
        'Me.MakeIdenticalToButton.BringToFront()

        Ctrl.Dock = DockStyle.Fill              ' Set styles

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls
    '*********************************************************************************************************
    Protected Sub PositionControls()

        ' Cross Section selection
        Dim loc As Point = Me.TailwaterCrossSection.Location
        loc.X = Me.Width - Me.TailwaterCrossSection.Width
        Me.TailwaterCrossSection.Location = loc

        loc = Me.MatchTailwaterToApproachCheckBox.Location
        loc.X = Me.Width - Me.MatchTailwaterToApproachCheckBox.Width - Me.Margin.Horizontal
        loc.Y = Me.Margin.Vertical
        Me.MatchTailwaterToApproachCheckBox.Location = loc

        'loc = Me.MakeIdenticalToButton.Location
        'loc.X = Me.Width - Me.MakeIdenticalToButton.Width - Me.Margin.Horizontal
        'loc.Y = Margin.Vertical
        'Me.MakeIdenticalToButton.Location = loc
        'Me.MakeIdenticalToButton.BringToFront()

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
    ' Sub TailwaterChannelControl_Load() - handle Load event to initialize contained Controls
    '*********************************************************************************************************
    Private Sub TailwaterChannelControl_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Load

        ' Load cross section selections
        TailwaterCrossSection_Load()

        ' Default to NO Tailwater to Approach matching
        Me.MatchTailwaterToApproachCheckBox.Value = False
        Me.MatchTailwaterToApproachCheckBox.HandleCheckedChanged = False

        ' Default to Simple Trapezoid cross section
        stCtrl = New SimpleTrapezoidControl(Flume.cTailwater)
        UpdateCrossSection(stCtrl)
        stCtrl.UpdateUI(mWinFlumeForm)

    End Sub

    Private Sub TailwaterCrossSection_Load()
        ' Load cross section selections
        Me.TailwaterCrossSection.Items.Clear()

        If (WinFlumeForm.TailwaterMatchedToApproach) Then
            mApproachChannel = mFlume.Section(cApproach)
            Me.TailwaterCrossSection.Items.Add(SectionString(mApproachChannel.Shape))
            Me.TailwaterCrossSection.SelectedIndex = 0
            Me.TailwaterCrossSection.BackColor = Color.LightBlue
        Else
            Me.TailwaterCrossSection.Items.Add(SectionString(shSimpleTrapezoid))
            Me.TailwaterCrossSection.Items.Add(SectionString(shRectangular))
            Me.TailwaterCrossSection.Items.Add(SectionString(shVShaped))
            Me.TailwaterCrossSection.Items.Add(SectionString(shCircle))
            Me.TailwaterCrossSection.Items.Add(SectionString(shUShaped))
            Me.TailwaterCrossSection.Items.Add(SectionString(shParabola))
            Me.TailwaterCrossSection.Items.Add(SectionString(shComplexTrapezoid))
            Me.TailwaterCrossSection.BackColor = SystemColors.Window
        End If
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub TailwaterCrossSection_ValueChanged() Handles TailwaterCrossSection.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            mTailwaterChannel = mFlume.Section(cTailwater)                       ' Section data
            mTailwaterChannel.Shape = Me.TailwaterCrossSection.Value + 1 ' Save new cross section selection
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub TailwaterChannelControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub TailwaterChannelControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize
        Dim ctrlSize As Size = New Size(Me.Width, Me.Height - Me.CrossSectionPanel.Location.Y)
        Me.CrossSectionPanel.Size = ctrlSize
    End Sub

    '*********************************************************************************************************
    ' Handlers for 'Make Tailwater Section Identical To..' button/drop-down context menu
    '*********************************************************************************************************
    Private Sub MakeIdenticalToButton_Click(sender As Object, e As EventArgs) _
        Handles MakeIdenticalToButton.Click
        If (mFlume.Section(cControl).Shape <= shComplexTrapezoid) Then
            Me.MakeIdenticalMenu.Items(1).Enabled = True
        Else
            Me.MakeIdenticalMenu.Items(1).Enabled = False
        End If

        Dim loc As New Point(0, Me.MakeIdenticalToButton.Height)
        loc = Me.MakeIdenticalToButton.PointToScreen(loc)
        Me.MakeIdenticalMenu.Show(loc)
    End Sub

    Private Sub ApproachSectionItem_Click(sender As Object, e As EventArgs) _
        Handles ApproachSectionItem.Click
        Dim undoRedo As Flume.SectionType = New Flume.SectionType(mFlume.Section(cTailwater))
        Me.MakeIdenticalToButton.AddUndoItem(undoRedo)

        WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
        mFlume.Section(cTailwater) = New Flume.SectionType(mFlume.Section(cApproach))
        mWinFlumeForm.RaiseFlumeDataChanged()
    End Sub

    Private Sub ControlChannelItem_Click(sender As Object, e As EventArgs) _
        Handles ControlChannelItem.Click
        Dim undoRedo As Flume.SectionType = New Flume.SectionType(mFlume.Section(cTailwater))
        Me.MakeIdenticalToButton.AddUndoItem(undoRedo)

        WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
        mFlume.Section(cTailwater) = New Flume.SectionType(mFlume.Section(cControl))
        mWinFlumeForm.RaiseFlumeDataChanged()
    End Sub

    Private Sub MakeIdenticalToButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles MakeIdenticalToButton.UndoButtonEvent

        ' Set current selection as Redo point
        Dim makeRedo As Flume.SectionType = New Flume.SectionType(mFlume.Section(cTailwater))
        MakeIdenticalToButton.AddRedoItem(makeRedo)

        ' Get Undo point's selection
        Dim makeUndo As Flume.SectionType = DirectCast(UndoValue, Flume.SectionType)
        mFlume.Section(cTailwater) = makeUndo

        mWinFlumeForm.RaiseFlumeDataChanged()
    End Sub

    Private Sub MakeIdenticalToButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles MakeIdenticalToButton.RedoButtonEvent

        ' Set current selection as Undo point
        Dim makeUndo As Flume.SectionType = New Flume.SectionType(mFlume.Section(cTailwater))
        MakeIdenticalToButton.AddUndoItem(makeUndo)

        ' Get Redo point's selection
        Dim makeRedo As Flume.SectionType = DirectCast(RedoValue, Flume.SectionType)
        mFlume.Section(cTailwater) = makeRedo

        mWinFlumeForm.RaiseFlumeDataChanged()
    End Sub

    '*********************************************************************************************************
    ' Handler for 'Match Tailwater to Approach' button
    '*********************************************************************************************************
    Private Sub MatchTailwaterToApproachCheckBox_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles MatchTailwaterToApproachCheckBox.MouseDown

        If (Me.MatchTailwaterToApproachCheckBox.Value = True) Then ' Match is checked

            ' Set current Flume object as Undo point; new Flume object must be created for new data
            MatchTailwaterToApproachCheckBox.AddUndoItem(mFlume)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Instantiate new Flume object
            mFlume = WinFlumeForm.NewFlumeType(mFlume)
            mFlume.TailwaterMatchedToApproach = False

            WinFlumeForm.SetFlume(mFlume)
            mWinFlumeForm.RaiseFlumeDataChanged()

        Else ' Match is not checked; show Match Tailwater to Approach dialog

            Dim db As MatchTailwaterDialog = New MatchTailwaterDialog()
            Dim result As DialogResult = db.ShowDialog
            If (result = DialogResult.OK) Then

                ' Set current Flume object as Undo point; new Flume object must be created for new data
                MatchTailwaterToApproachCheckBox.AddUndoItem(mFlume)
                WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

                ' Create new Flume object
                mFlume = WinFlumeForm.NewFlumeType(mFlume)
                mFlume.TailwaterMatchedToApproach = True

                ' Load Tailwater SectionType with Approach SectionType
                mFlume.Section(cTailwater) = New Flume.SectionType(mFlume.Section(cApproach))

                ' Make new Flume object known to rest of WinFlume
                WinFlumeForm.SetFlume(mFlume)
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If

    End Sub

    Private Sub MatchTailwaterToApproachCheckBox_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles MatchTailwaterToApproachCheckBox.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(FlumeType)) Then
                ' Set Flume for Redo point
                MatchTailwaterToApproachCheckBox.AddRedoItem(mFlume)
                ' Restore Flume object
                mFlume = DirectCast(UndoValue, FlumeType)
                WinFlumeForm.SetFlume(mFlume)
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub MatchTailwaterToApproachCheckBox_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles MatchTailwaterToApproachCheckBox.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(FlumeType)) Then
                ' Set Flume for Undo point
                MatchTailwaterToApproachCheckBox.AddUndoItem(mFlume)
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
