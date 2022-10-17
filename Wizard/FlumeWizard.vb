
'*************************************************************************************************************
' Class FlumeWizard - Dialog for handling the Wizard's steps
'
' Note - each step is a UserControl subclassed from WizardStep
'*************************************************************************************************************
Public Class FlumeWizard

#Region " Member Data "

    Private mWinFlume As WinFlumeForm           ' WinFlume UI data & methods
    Private mFlume As Flume.FlumeType           ' Flume.dll data

    Private mWizardSteps() As WizardStep        ' Array of Wizard's steps

    Private mCurStep As WizardStep = Nothing    ' Current Wizard step

    Private mTopRatio As Double                 ' Ratio of StepPanel1.Height to Me.Height

#End Region

#Region " Constructor(s) "

    Public Sub New(ByVal WinFlume As WinFlumeForm, ByVal Flume As Flume.FlumeType)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        mWinFlume = WinFlume
        mFlume = Flume

        mTopRatio = Me.StepPanel1.Height / Me.Height
    End Sub

#End Region

#Region " Wizard Methods "

    '*********************************************************************************************************
    ' Function PrevStep() - go back one step, if possible
    ' Function NextStep() - advance one step, if possible
    '
    ' Input(s):     CurStep     - current Wizard Step
    '
    ' Returns:      WizardStep  - previous/next step in the Wizard's sequence (Nothing if at end of list)
    '*********************************************************************************************************
    Public Function PrevStep(ByVal CurStep As WizardStep) As WizardStep
        PrevStep = Nothing
        For sdx As Integer = 1 To mWizardSteps.Length - 1
            Dim wizStep As WizardStep = mWizardSteps(sdx)
            If (wizStep Is CurStep) Then
                PrevStep = mWizardSteps(sdx - 1)
                Exit Function
            End If
        Next sdx
    End Function

    Public Function NextStep(ByVal CurStep As WizardStep) As WizardStep
        NextStep = Nothing
        If (CurStep Is Nothing) Then    ' no current step
            NextStep = mWizardSteps(0)  ' return the first step
        Else
            For sdx As Integer = 0 To mWizardSteps.Length - 2
                Dim wizStep As WizardStep = mWizardSteps(sdx)
                If (wizStep Is CurStep) Then
                    NextStep = mWizardSteps(sdx + 1)
                    Exit Function
                End If
            Next sdx
        End If
    End Function

    '*********************************************************************************************************
    ' Function StepNum()    - return step number
    '
    ' Input(s):     CurStep - current Wizard Step
    '
    ' Returns:      Integer - steo number of specified Wizard Step
    '*********************************************************************************************************
    Public Function StepNum(ByVal CurStep As WizardStep) As Integer
        StepNum = 0
        For sdx As Integer = 0 To mWizardSteps.Length - 1
            Dim wizStep As WizardStep = mWizardSteps(sdx)
            If (wizStep Is CurStep) Then
                StepNum = sdx + 1
                Exit Function
            End If
        Next sdx
    End Function

    '*********************************************************************************************************
    ' Sub UpdateWizardMenu() - update the Wizard's step menu to reflect current step
    '
    ' Input(s):     StepNo  - current Wizard Step number
    '               Cntrl   - Control is UI hierarchy
    '
    ' Note - the current Wizard Step is reflected by the menu's ctl_CheckBox list
    '*********************************************************************************************************
    Private Sub UpdateWizardMenu(ByVal StepNo As Integer, ByVal Cntrl As Control)
        For Each ctrl As Control In Cntrl.Controls ' search for all ctl_CheckBox's
            If (ctrl.GetType Is GetType(ctl_CheckBox)) Then ' found one
                Dim chkBox As ctl_CheckBox = DirectCast(ctrl, ctl_CheckBox)
                If (chkBox.Tag IsNot Nothing) Then
                    If (chkBox.Tag.GetType Is GetType(String)) Then
                        Try
                            Dim tagStr As String = CStr(chkBox.Tag)
                            Dim tagInt As Integer = Integer.Parse(tagStr)
                            If (0 < tagInt) Then ' check & remove highlights before current Step
                                If (tagInt < StepNo) Then
                                    chkBox.Checked = True
                                    chkBox.BackColor = SystemColors.ControlLight
                                    chkBox.ForeColor = SystemColors.ControlText
                                ElseIf (tagInt = StepNo) Then ' uncheck & highlight current Step
                                    chkBox.Checked = False
                                    chkBox.BackColor = Color.WhiteSmoke
                                    chkBox.ForeColor = Color.DarkBlue
                                Else ' uncheck & remove highlights after current Step
                                    chkBox.Checked = False
                                    chkBox.BackColor = SystemColors.ControlLight
                                    chkBox.ForeColor = SystemColors.ControlText
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Else ' continue search within contained controls
                UpdateWizardMenu(StepNo, ctrl)
            End If
        Next ctrl
    End Sub

    '*********************************************************************************************************
    ' Sub StepWizard() - update the Wizard's menu & step panels to reflect current step
    '
    ' Input(s):     WizStep - Wizard Step to show
    '
    ' Note - the current Wizard Step is reflected by the menu's ctl_CheckBox list
    '*********************************************************************************************************
    Public Sub StepWizard(ByVal WizStep As WizardStep)
        If (mCurStep IsNot Nothing) Then    ' there is a current step
            mCurStep.EndStep()              ' end it
        End If
        If (WizStep IsNot Nothing) Then    ' there is a next step
            mCurStep = WizStep             ' save it as the current step

            ' Update steps' checkboxes to reflect progress & current step
            Dim stepNo As Integer = StepNum(mCurStep)
            UpdateWizardMenu(stepNo, Me)

            ' Update UI to show the current step
            Dim numStr As String = My.Resources.StepStr & " " & stepNo.ToString
            Me.StepDescriptionLabel.Text = My.Resources.Instructions & ": " & numStr

            Me.StepPanel1.SuspendLayout()
            Me.StepPanel2.SuspendLayout()
            Me.SuspendLayout()

            Me.StepPanel1.Controls.Clear()          ' Load Panel 1 from Wizard Step
            Dim panel1 As Panel = WizStep.Panel1
            Me.StepPanel1.Controls.Add(panel1)

            Me.StepPanel2.Controls.Clear()          ' Load Panel 2 from Wizard Step
            Dim panel2 As Panel = WizStep.Panel2
            Me.StepPanel2.Controls.Add(panel2)

            Me.StepPanel1.ResumeLayout()
            Me.StepPanel2.ResumeLayout()
            Me.ResumeLayout()

            If (stepNo = 1) Then
                Me.PrevStepButton.Visible = False
            Else
                Me.PrevStepButton.Visible = True
            End If

            If (stepNo = mWizardSteps.Length) Then
                Me.NextStepButton.Visible = False
            Else
                Me.NextStepButton.Visible = True
            End If

            mCurStep.StartStep()                    ' Start the step
        End If
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Sub MyBase_Load() - Load event handler: initialize & start the Wizard
    '*********************************************************************************************************
    Private Sub MyBase_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load
        Try
            ' Define the Wizard's sequence of steps
            ReDim mWizardSteps(10)

            mWizardSteps(0) = New GettingStarted(mWinFlume, mFlume)
            mWizardSteps(1) = New SystemOfUnits(mWinFlume, mFlume)
            mWizardSteps(2) = New ProjectDescription(mWinFlume, mFlume)
            mWizardSteps(3) = New EditBottomProfile(mWinFlume, mFlume)
            mWizardSteps(4) = New DefineApproachChannel(mWinFlume, mFlume)
            mWizardSteps(5) = New DefineTailwaterChannel(mWinFlume, mFlume)
            mWizardSteps(6) = New DefineDischargeTailwater(mWinFlume, mFlume)
            mWizardSteps(7) = New DefineFreeboardRequirements(mWinFlume, mFlume)
            mWizardSteps(8) = New DefineFlumeCrest(mWinFlume, mFlume)
            mWizardSteps(9) = New DefineHeadMeasDevice(mWinFlume, mFlume)
            mWizardSteps(10) = New DefineControlSection(mWinFlume, mFlume)

            ' Initialize and run the Wizard from step 1
            mCurStep = Nothing
            StepWizard(mWizardSteps(0))

            ' Set Focus to the Menu Panel
            Me.Show()
            Me.MenuPanel.Select()

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub MyBase_Resize(sender As Object, e As EventArgs) _
        Handles MyBase.Resize
        If (0 < mTopRatio) Then
            Me.StepPanel1.Height = CInt(Me.Height * mTopRatio)
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub ...Button_Click() - Button Click event handlers: perform user requested action
    '*********************************************************************************************************
    Private Sub StepHelpButton_Click(sender As Object, e As EventArgs) _
        Handles StepHelpButton.Click
        If (mCurStep IsNot Nothing) Then ' step displays appropriate Help
            mCurStep.HelpButton()
        End If
    End Sub

    Private Sub PrevStepButton_Click(sender As Object, e As EventArgs) _
        Handles PrevStepButton.Click
        If (mCurStep IsNot Nothing) Then ' allow step to perform 'Prev' actions
            mCurStep.PrevButton()
        End If
        Dim wizStep As WizardStep = PrevStep(mCurStep)
        StepWizard(wizStep)
    End Sub

    Private Sub NextStepButton_Click(sender As Object, e As EventArgs) _
        Handles NextStepButton.Click
        If (mCurStep IsNot Nothing) Then ' allow step to perform 'Next' actions
            mCurStep.NextButton()
        End If
        Dim wizStep As WizardStep = NextStep(mCurStep)
        StepWizard(wizStep)
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) _
        Handles CloseButton.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub MyBase_FormClosing(sender As Object, e As FormClosingEventArgs) _
        Handles MyBase.FormClosing
        mWinFlume.VerifySaved()
        Me.DialogResult = DialogResult.OK
    End Sub

    '*********************************************************************************************************
    ' Sub ...CheckBox_Click() - Click event handlers for individual steps
    '
    ' User has selected a particular step
    '*********************************************************************************************************
    Private Sub GettingStartedCheckBox_Click(sender As Object, e As EventArgs) _
        Handles GettingStartedCheckBox.Click
        SelectStep(GettingStartedCheckBox.Tag)
    End Sub

    Private Sub SystemOfUnitsCheckBox_Click(sender As Object, e As EventArgs) _
        Handles SystemOfUnitsCheckBox.Click
        SelectStep(SystemOfUnitsCheckBox.Tag)
    End Sub

    Private Sub ProjectDecriptionCheckBox_Click(sender As Object, e As EventArgs) _
        Handles ProjectDecriptionCheckBox.Click
        SelectStep(ProjectDecriptionCheckBox.Tag)
    End Sub
    '
    ' Define Canal steps
    '
    Private Sub ChannelDepthCheckBox_Click(sender As Object, e As EventArgs) _
        Handles ChannelDepthCheckBox.Click
        SelectStep(ChannelDepthCheckBox.Tag)
    End Sub

    Private Sub ApproachChannelCheckBox_Click(sender As Object, e As EventArgs) _
        Handles ApproachChannelCheckBox.Click
        SelectStep(ApproachChannelCheckBox.Tag)
    End Sub

    Private Sub TailwaterChannelCheckBox_Click(sender As Object, e As EventArgs) _
        Handles TailwaterChannelCheckBox.Click
        SelectStep(TailwaterChannelCheckBox.Tag)
    End Sub

    Private Sub DischargeTailwaterCheckBox_Click(sender As Object, e As EventArgs) _
        Handles DischargeTailwaterCheckBox.Click
        SelectStep(DischargeTailwaterCheckBox.Tag)
    End Sub

    Private Sub FreeboardRequirementsCheckBox_Click(sender As Object, e As EventArgs) _
        Handles FreeboardRequirementsCheckBox.Click
        SelectStep(FreeboardRequirementsCheckBox.Tag)
    End Sub
    '
    ' Define Control steps
    '
    Private Sub FlumeCrestCheckBox_Click(sender As Object, e As EventArgs) _
        Handles FlumeCrestCheckBox.Click
        SelectStep(FlumeCrestCheckBox.Tag)
    End Sub

    Private Sub HeadMeasurementCheckBox_Click(sender As Object, e As EventArgs) _
        Handles HeadMeasurementCheckBox.Click
        SelectStep(HeadMeasurementCheckBox.Tag)
    End Sub

    Private Sub ControlSectionCheckBox_Click(sender As Object, e As EventArgs) _
        Handles ControlSectionCheckBox.Click
        SelectStep(ControlSectionCheckBox.Tag)
    End Sub

    '*********************************************************************************************************
    ' Sub SelectStep() - select the Wizard Step to show
    '
    ' Input(s):     Obj - Object specifying the Step Number to show
    '
    ' Note - Obj should be an a control's Tag which is a String containing an Integer number
    '*********************************************************************************************************
    Private Sub SelectStep(ByVal Obj As Object)
        If (Obj IsNot Nothing) Then
            If (Obj.GetType Is GetType(String)) Then ' Obj is of type String; try to parse it as an Integer
                Try ' Integer.Parse may cause an exception
                    Dim objStr As String = CStr(Obj)
                    Dim stepNo As Integer = Integer.Parse(objStr)
                    If ((1 <= stepNo) And (stepNo <= mWizardSteps.Length)) Then ' valid Step Number
                        ' Show the selected Wizard Step
                        Dim wizStep As WizardStep = mWizardSteps(stepNo - 1)
                        StepWizard(wizStep)
                    End If
                Catch ex As Exception
                    Debug.Assert(False, ex.Message)
                End Try
            End If
        End If
    End Sub

#End Region

End Class