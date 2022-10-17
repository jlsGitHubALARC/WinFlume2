<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FlumeWizard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FlumeWizard))
        Me.WizardPanel = New WinFlume.ctl_Panel()
        Me.MenuPanel = New WinFlume.ctl_Panel()
        Me.Step02Label = New WinFlume.ctl_Label()
        Me.SystemOfUnitsCheckBox = New WinFlume.ctl_CheckBox()
        Me.Step03Label = New WinFlume.ctl_Label()
        Me.ProjectDecriptionCheckBox = New WinFlume.ctl_CheckBox()
        Me.HeadMeasurementCheckBox = New WinFlume.ctl_CheckBox()
        Me.Step10Label = New WinFlume.ctl_Label()
        Me.Step11Label = New WinFlume.ctl_Label()
        Me.FlumeCrestCheckBox = New WinFlume.ctl_CheckBox()
        Me.Step08Label = New WinFlume.ctl_Label()
        Me.DefineControlLabel2 = New WinFlume.ctl_Label()
        Me.ChannelDepthCheckBox = New WinFlume.ctl_CheckBox()
        Me.Step07Label = New WinFlume.ctl_Label()
        Me.Step06Label = New WinFlume.ctl_Label()
        Me.FreeboardRequirementsCheckBox = New WinFlume.ctl_CheckBox()
        Me.Step05Label = New WinFlume.ctl_Label()
        Me.DischargeTailwaterCheckBox = New WinFlume.ctl_CheckBox()
        Me.Step04Label = New WinFlume.ctl_Label()
        Me.TailwaterChannelCheckBox = New WinFlume.ctl_CheckBox()
        Me.Step09Label = New WinFlume.ctl_Label()
        Me.ControlSectionCheckBox = New WinFlume.ctl_CheckBox()
        Me.Step01Label = New WinFlume.ctl_Label()
        Me.ApproachChannelCheckBox = New WinFlume.ctl_CheckBox()
        Me.DefineCanalLabel = New WinFlume.ctl_Label()
        Me.GettingStartedCheckBox = New WinFlume.ctl_CheckBox()
        Me.StepPanel2 = New WinFlume.ctl_Panel()
        Me.StepPanel1 = New WinFlume.ctl_Panel()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.CloseButton = New WinFlume.ctl_Button()
        Me.StepHelpButton = New WinFlume.ctl_Button()
        Me.PrevStepButton = New WinFlume.ctl_Button()
        Me.NextStepButton = New WinFlume.ctl_Button()
        Me.StepDescriptionLabel = New WinFlume.ctl_Label()
        Me.WizardPanel.SuspendLayout()
        Me.MenuPanel.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'WizardPanel
        '
        Me.WizardPanel.Controls.Add(Me.MenuPanel)
        Me.WizardPanel.Controls.Add(Me.StepPanel2)
        Me.WizardPanel.Controls.Add(Me.StepPanel1)
        resources.ApplyResources(Me.WizardPanel, "WizardPanel")
        Me.WizardPanel.Name = "WizardPanel"
        '
        'MenuPanel
        '
        Me.MenuPanel.Controls.Add(Me.Step02Label)
        Me.MenuPanel.Controls.Add(Me.SystemOfUnitsCheckBox)
        Me.MenuPanel.Controls.Add(Me.Step03Label)
        Me.MenuPanel.Controls.Add(Me.ProjectDecriptionCheckBox)
        Me.MenuPanel.Controls.Add(Me.HeadMeasurementCheckBox)
        Me.MenuPanel.Controls.Add(Me.Step10Label)
        Me.MenuPanel.Controls.Add(Me.Step11Label)
        Me.MenuPanel.Controls.Add(Me.FlumeCrestCheckBox)
        Me.MenuPanel.Controls.Add(Me.Step08Label)
        Me.MenuPanel.Controls.Add(Me.DefineControlLabel2)
        Me.MenuPanel.Controls.Add(Me.ChannelDepthCheckBox)
        Me.MenuPanel.Controls.Add(Me.Step07Label)
        Me.MenuPanel.Controls.Add(Me.Step06Label)
        Me.MenuPanel.Controls.Add(Me.FreeboardRequirementsCheckBox)
        Me.MenuPanel.Controls.Add(Me.Step05Label)
        Me.MenuPanel.Controls.Add(Me.DischargeTailwaterCheckBox)
        Me.MenuPanel.Controls.Add(Me.Step04Label)
        Me.MenuPanel.Controls.Add(Me.TailwaterChannelCheckBox)
        Me.MenuPanel.Controls.Add(Me.Step09Label)
        Me.MenuPanel.Controls.Add(Me.ControlSectionCheckBox)
        Me.MenuPanel.Controls.Add(Me.Step01Label)
        Me.MenuPanel.Controls.Add(Me.ApproachChannelCheckBox)
        Me.MenuPanel.Controls.Add(Me.DefineCanalLabel)
        Me.MenuPanel.Controls.Add(Me.GettingStartedCheckBox)
        resources.ApplyResources(Me.MenuPanel, "MenuPanel")
        Me.MenuPanel.Name = "MenuPanel"
        '
        'Step02Label
        '
        resources.ApplyResources(Me.Step02Label, "Step02Label")
        Me.Step02Label.Name = "Step02Label"
        '
        'SystemOfUnitsCheckBox
        '
        Me.SystemOfUnitsCheckBox.AutoCheck = False
        resources.ApplyResources(Me.SystemOfUnitsCheckBox, "SystemOfUnitsCheckBox")
        Me.SystemOfUnitsCheckBox.HandleCheckedChanged = True
        Me.SystemOfUnitsCheckBox.Name = "SystemOfUnitsCheckBox"
        Me.SystemOfUnitsCheckBox.Tag = "2"
        Me.SystemOfUnitsCheckBox.UndoEnabled = True
        Me.SystemOfUnitsCheckBox.UseVisualStyleBackColor = True
        Me.SystemOfUnitsCheckBox.Value = False
        '
        'Step03Label
        '
        resources.ApplyResources(Me.Step03Label, "Step03Label")
        Me.Step03Label.Name = "Step03Label"
        '
        'ProjectDecriptionCheckBox
        '
        Me.ProjectDecriptionCheckBox.AutoCheck = False
        resources.ApplyResources(Me.ProjectDecriptionCheckBox, "ProjectDecriptionCheckBox")
        Me.ProjectDecriptionCheckBox.HandleCheckedChanged = True
        Me.ProjectDecriptionCheckBox.Name = "ProjectDecriptionCheckBox"
        Me.ProjectDecriptionCheckBox.Tag = "3"
        Me.ProjectDecriptionCheckBox.UndoEnabled = True
        Me.ProjectDecriptionCheckBox.UseVisualStyleBackColor = True
        Me.ProjectDecriptionCheckBox.Value = False
        '
        'HeadMeasurementCheckBox
        '
        Me.HeadMeasurementCheckBox.AutoCheck = False
        resources.ApplyResources(Me.HeadMeasurementCheckBox, "HeadMeasurementCheckBox")
        Me.HeadMeasurementCheckBox.HandleCheckedChanged = True
        Me.HeadMeasurementCheckBox.Name = "HeadMeasurementCheckBox"
        Me.HeadMeasurementCheckBox.Tag = "10"
        Me.HeadMeasurementCheckBox.UndoEnabled = True
        Me.HeadMeasurementCheckBox.UseVisualStyleBackColor = True
        Me.HeadMeasurementCheckBox.Value = False
        '
        'Step10Label
        '
        resources.ApplyResources(Me.Step10Label, "Step10Label")
        Me.Step10Label.Name = "Step10Label"
        '
        'Step11Label
        '
        resources.ApplyResources(Me.Step11Label, "Step11Label")
        Me.Step11Label.Name = "Step11Label"
        '
        'FlumeCrestCheckBox
        '
        Me.FlumeCrestCheckBox.AutoCheck = False
        resources.ApplyResources(Me.FlumeCrestCheckBox, "FlumeCrestCheckBox")
        Me.FlumeCrestCheckBox.HandleCheckedChanged = True
        Me.FlumeCrestCheckBox.Name = "FlumeCrestCheckBox"
        Me.FlumeCrestCheckBox.Tag = "9"
        Me.FlumeCrestCheckBox.UndoEnabled = True
        Me.FlumeCrestCheckBox.UseVisualStyleBackColor = True
        Me.FlumeCrestCheckBox.Value = False
        '
        'Step08Label
        '
        resources.ApplyResources(Me.Step08Label, "Step08Label")
        Me.Step08Label.Name = "Step08Label"
        '
        'DefineControlLabel2
        '
        resources.ApplyResources(Me.DefineControlLabel2, "DefineControlLabel2")
        Me.DefineControlLabel2.Name = "DefineControlLabel2"
        '
        'ChannelDepthCheckBox
        '
        Me.ChannelDepthCheckBox.AutoCheck = False
        resources.ApplyResources(Me.ChannelDepthCheckBox, "ChannelDepthCheckBox")
        Me.ChannelDepthCheckBox.HandleCheckedChanged = True
        Me.ChannelDepthCheckBox.Name = "ChannelDepthCheckBox"
        Me.ChannelDepthCheckBox.Tag = "4"
        Me.ChannelDepthCheckBox.UndoEnabled = True
        Me.ChannelDepthCheckBox.UseVisualStyleBackColor = True
        Me.ChannelDepthCheckBox.Value = False
        '
        'Step07Label
        '
        resources.ApplyResources(Me.Step07Label, "Step07Label")
        Me.Step07Label.Name = "Step07Label"
        '
        'Step06Label
        '
        resources.ApplyResources(Me.Step06Label, "Step06Label")
        Me.Step06Label.Name = "Step06Label"
        '
        'FreeboardRequirementsCheckBox
        '
        Me.FreeboardRequirementsCheckBox.AutoCheck = False
        resources.ApplyResources(Me.FreeboardRequirementsCheckBox, "FreeboardRequirementsCheckBox")
        Me.FreeboardRequirementsCheckBox.HandleCheckedChanged = True
        Me.FreeboardRequirementsCheckBox.Name = "FreeboardRequirementsCheckBox"
        Me.FreeboardRequirementsCheckBox.Tag = "8"
        Me.FreeboardRequirementsCheckBox.UndoEnabled = True
        Me.FreeboardRequirementsCheckBox.UseVisualStyleBackColor = True
        Me.FreeboardRequirementsCheckBox.Value = False
        '
        'Step05Label
        '
        resources.ApplyResources(Me.Step05Label, "Step05Label")
        Me.Step05Label.Name = "Step05Label"
        '
        'DischargeTailwaterCheckBox
        '
        Me.DischargeTailwaterCheckBox.AutoCheck = False
        resources.ApplyResources(Me.DischargeTailwaterCheckBox, "DischargeTailwaterCheckBox")
        Me.DischargeTailwaterCheckBox.HandleCheckedChanged = True
        Me.DischargeTailwaterCheckBox.Name = "DischargeTailwaterCheckBox"
        Me.DischargeTailwaterCheckBox.Tag = "7"
        Me.DischargeTailwaterCheckBox.UndoEnabled = True
        Me.DischargeTailwaterCheckBox.UseVisualStyleBackColor = True
        Me.DischargeTailwaterCheckBox.Value = False
        '
        'Step04Label
        '
        resources.ApplyResources(Me.Step04Label, "Step04Label")
        Me.Step04Label.Name = "Step04Label"
        '
        'TailwaterChannelCheckBox
        '
        Me.TailwaterChannelCheckBox.AutoCheck = False
        resources.ApplyResources(Me.TailwaterChannelCheckBox, "TailwaterChannelCheckBox")
        Me.TailwaterChannelCheckBox.HandleCheckedChanged = True
        Me.TailwaterChannelCheckBox.Name = "TailwaterChannelCheckBox"
        Me.TailwaterChannelCheckBox.Tag = "6"
        Me.TailwaterChannelCheckBox.UndoEnabled = True
        Me.TailwaterChannelCheckBox.UseVisualStyleBackColor = True
        Me.TailwaterChannelCheckBox.Value = False
        '
        'Step09Label
        '
        resources.ApplyResources(Me.Step09Label, "Step09Label")
        Me.Step09Label.Name = "Step09Label"
        '
        'ControlSectionCheckBox
        '
        Me.ControlSectionCheckBox.AutoCheck = False
        resources.ApplyResources(Me.ControlSectionCheckBox, "ControlSectionCheckBox")
        Me.ControlSectionCheckBox.HandleCheckedChanged = True
        Me.ControlSectionCheckBox.Name = "ControlSectionCheckBox"
        Me.ControlSectionCheckBox.Tag = "11"
        Me.ControlSectionCheckBox.UndoEnabled = True
        Me.ControlSectionCheckBox.UseVisualStyleBackColor = True
        Me.ControlSectionCheckBox.Value = False
        '
        'Step01Label
        '
        resources.ApplyResources(Me.Step01Label, "Step01Label")
        Me.Step01Label.Name = "Step01Label"
        '
        'ApproachChannelCheckBox
        '
        Me.ApproachChannelCheckBox.AutoCheck = False
        resources.ApplyResources(Me.ApproachChannelCheckBox, "ApproachChannelCheckBox")
        Me.ApproachChannelCheckBox.HandleCheckedChanged = True
        Me.ApproachChannelCheckBox.Name = "ApproachChannelCheckBox"
        Me.ApproachChannelCheckBox.Tag = "5"
        Me.ApproachChannelCheckBox.UndoEnabled = True
        Me.ApproachChannelCheckBox.UseVisualStyleBackColor = True
        Me.ApproachChannelCheckBox.Value = False
        '
        'DefineCanalLabel
        '
        resources.ApplyResources(Me.DefineCanalLabel, "DefineCanalLabel")
        Me.DefineCanalLabel.Name = "DefineCanalLabel"
        '
        'GettingStartedCheckBox
        '
        Me.GettingStartedCheckBox.AutoCheck = False
        resources.ApplyResources(Me.GettingStartedCheckBox, "GettingStartedCheckBox")
        Me.GettingStartedCheckBox.HandleCheckedChanged = True
        Me.GettingStartedCheckBox.Name = "GettingStartedCheckBox"
        Me.GettingStartedCheckBox.Tag = "1"
        Me.GettingStartedCheckBox.UndoEnabled = True
        Me.GettingStartedCheckBox.UseVisualStyleBackColor = True
        Me.GettingStartedCheckBox.Value = False
        '
        'StepPanel2
        '
        resources.ApplyResources(Me.StepPanel2, "StepPanel2")
        Me.StepPanel2.Name = "StepPanel2"
        '
        'StepPanel1
        '
        resources.ApplyResources(Me.StepPanel1, "StepPanel1")
        Me.StepPanel1.Name = "StepPanel1"
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.CloseButton)
        Me.ControlPanel.Controls.Add(Me.StepHelpButton)
        Me.ControlPanel.Controls.Add(Me.PrevStepButton)
        Me.ControlPanel.Controls.Add(Me.NextStepButton)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'CloseButton
        '
        Me.CloseButton.BackColor = System.Drawing.SystemColors.Control
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.CloseButton, "CloseButton")
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.UseVisualStyleBackColor = False
        '
        'StepHelpButton
        '
        Me.StepHelpButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.StepHelpButton, "StepHelpButton")
        Me.StepHelpButton.Name = "StepHelpButton"
        Me.StepHelpButton.UseVisualStyleBackColor = False
        '
        'PrevStepButton
        '
        Me.PrevStepButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.PrevStepButton, "PrevStepButton")
        Me.PrevStepButton.Name = "PrevStepButton"
        Me.PrevStepButton.UseVisualStyleBackColor = False
        '
        'NextStepButton
        '
        Me.NextStepButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.NextStepButton, "NextStepButton")
        Me.NextStepButton.Name = "NextStepButton"
        Me.NextStepButton.UseVisualStyleBackColor = False
        '
        'StepDescriptionLabel
        '
        resources.ApplyResources(Me.StepDescriptionLabel, "StepDescriptionLabel")
        Me.StepDescriptionLabel.Name = "StepDescriptionLabel"
        '
        'FlumeWizard
        '
        Me.AcceptButton = Me.NextStepButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.CloseButton
        Me.Controls.Add(Me.WizardPanel)
        Me.Controls.Add(Me.ControlPanel)
        Me.Controls.Add(Me.StepDescriptionLabel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FlumeWizard"
        Me.ShowIcon = False
        Me.TopMost = True
        Me.WizardPanel.ResumeLayout(False)
        Me.MenuPanel.ResumeLayout(False)
        Me.MenuPanel.PerformLayout()
        Me.ControlPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StepDescriptionLabel As ctl_Label
    Friend WithEvents ControlPanel As ctl_Panel
    Friend WithEvents CloseButton As ctl_Button
    Friend WithEvents StepHelpButton As ctl_Button
    Friend WithEvents PrevStepButton As ctl_Button
    Friend WithEvents NextStepButton As ctl_Button
    Friend WithEvents WizardPanel As ctl_Panel
    Friend WithEvents StepPanel2 As ctl_Panel
    Friend WithEvents StepPanel1 As ctl_Panel
    Friend WithEvents MenuPanel As ctl_Panel
    Friend WithEvents Step06Label As ctl_Label
    Friend WithEvents FreeboardRequirementsCheckBox As ctl_CheckBox
    Friend WithEvents Step05Label As ctl_Label
    Friend WithEvents DischargeTailwaterCheckBox As ctl_CheckBox
    Friend WithEvents Step04Label As ctl_Label
    Friend WithEvents TailwaterChannelCheckBox As ctl_CheckBox
    Friend WithEvents Step09Label As ctl_Label
    Friend WithEvents ControlSectionCheckBox As ctl_CheckBox
    Friend WithEvents Step01Label As ctl_Label
    Friend WithEvents ApproachChannelCheckBox As ctl_CheckBox
    Friend WithEvents DefineCanalLabel As ctl_Label
    Friend WithEvents GettingStartedCheckBox As ctl_CheckBox
    Friend WithEvents ChannelDepthCheckBox As ctl_CheckBox
    Friend WithEvents Step07Label As ctl_Label
    Friend WithEvents Step11Label As ctl_Label
    Friend WithEvents HeadMeasurementCheckBox As ctl_CheckBox
    Friend WithEvents DefineControlLabel2 As ctl_Label
    Friend WithEvents FlumeCrestCheckBox As ctl_CheckBox
    Friend WithEvents Step08Label As ctl_Label
    Friend WithEvents Step10Label As ctl_Label
    Friend WithEvents Step02Label As ctl_Label
    Friend WithEvents SystemOfUnitsCheckBox As ctl_CheckBox
    Friend WithEvents Step03Label As ctl_Label
    Friend WithEvents ProjectDecriptionCheckBox As ctl_CheckBox
End Class
