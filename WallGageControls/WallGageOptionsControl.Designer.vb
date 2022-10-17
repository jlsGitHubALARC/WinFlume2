<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WallGageOptionsControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WallGageOptionsControl))
        Me.FixedHeadIntervalBox = New WinFlume.ctl_GroupBox()
        Me.EnableHead = New WinFlume.ctl_CheckBox()
        Me.HeadSmartRangeButton = New WinFlume.ctl_Button()
        Me.HeadIncrementSingle = New WinFlume.ctl_SingleUnits()
        Me.HeadIncrementLabel = New WinFlume.ctl_Label()
        Me.MaximumHeadSingle = New WinFlume.ctl_SingleUnits()
        Me.MaximumHeadLabel = New WinFlume.ctl_Label()
        Me.MinimumHeadSingle = New WinFlume.ctl_SingleUnits()
        Me.MinimumHeadLabel = New WinFlume.ctl_Label()
        Me.FixedDischargeIntervalBox = New WinFlume.ctl_GroupBox()
        Me.EnableDischarge = New WinFlume.ctl_CheckBox()
        Me.DischargeSmartRangeButton = New WinFlume.ctl_Button()
        Me.DischargeIncrementSingle = New WinFlume.ctl_SingleUnits()
        Me.DischargeIncrementLabel = New WinFlume.ctl_Label()
        Me.MaximumDischargeSingle = New WinFlume.ctl_SingleUnits()
        Me.MaximumDischargeLabel = New WinFlume.ctl_Label()
        Me.MinimumDischargeSingle = New WinFlume.ctl_SingleUnits()
        Me.MinimumDischargeLabel = New WinFlume.ctl_Label()
        Me.GageReferenceGroup = New WinFlume.ctl_GroupBox()
        Me.UpstreamChannellBottomButton = New WinFlume.ctl_RadioButton()
        Me.SillReferencedButton = New WinFlume.ctl_RadioButton()
        Me.GageSlopeSingle = New WinFlume.ctl_SingleUnits()
        Me.GageSlopeLabel = New WinFlume.ctl_Label()
        Me.FixedHeadIntervalBox.SuspendLayout()
        Me.FixedDischargeIntervalBox.SuspendLayout()
        Me.GageReferenceGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'FixedHeadIntervalBox
        '
        Me.FixedHeadIntervalBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedHeadIntervalBox, "FixedHeadIntervalBox")
        Me.FixedHeadIntervalBox.Controls.Add(Me.EnableHead)
        Me.FixedHeadIntervalBox.Controls.Add(Me.HeadSmartRangeButton)
        Me.FixedHeadIntervalBox.Controls.Add(Me.HeadIncrementSingle)
        Me.FixedHeadIntervalBox.Controls.Add(Me.HeadIncrementLabel)
        Me.FixedHeadIntervalBox.Controls.Add(Me.MaximumHeadSingle)
        Me.FixedHeadIntervalBox.Controls.Add(Me.MaximumHeadLabel)
        Me.FixedHeadIntervalBox.Controls.Add(Me.MinimumHeadSingle)
        Me.FixedHeadIntervalBox.Controls.Add(Me.MinimumHeadLabel)
        Me.FixedHeadIntervalBox.Name = "FixedHeadIntervalBox"
        Me.FixedHeadIntervalBox.TabStop = False
        '
        'EnableHead
        '
        resources.ApplyResources(Me.EnableHead, "EnableHead")
        Me.EnableHead.Checked = True
        Me.EnableHead.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EnableHead.Name = "EnableHead"
        Me.EnableHead.UseVisualStyleBackColor = True
        Me.EnableHead.Value = True
        '
        'HeadSmartRangeButton
        '
        Me.HeadSmartRangeButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.HeadSmartRangeButton, "HeadSmartRangeButton")
        Me.HeadSmartRangeButton.Name = "HeadSmartRangeButton"
        Me.HeadSmartRangeButton.UseVisualStyleBackColor = False
        '
        'HeadIncrementSingle
        '
        resources.ApplyResources(Me.HeadIncrementSingle, "HeadIncrementSingle")
        Me.HeadIncrementSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HeadIncrementSingle.FormatStyle = "0.0###"
        Me.HeadIncrementSingle.Label = ""
        Me.HeadIncrementSingle.Name = "HeadIncrementSingle"
        Me.HeadIncrementSingle.SiMin = -1.401298E-45!
        Me.HeadIncrementSingle.SiUnits = ""
        Me.HeadIncrementSingle.SiValue = 0!
        '
        'HeadIncrementLabel
        '
        resources.ApplyResources(Me.HeadIncrementLabel, "HeadIncrementLabel")
        Me.HeadIncrementLabel.Name = "HeadIncrementLabel"
        '
        'MaximumHeadSingle
        '
        resources.ApplyResources(Me.MaximumHeadSingle, "MaximumHeadSingle")
        Me.MaximumHeadSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MaximumHeadSingle.FormatStyle = "0.0###"
        Me.MaximumHeadSingle.Label = ""
        Me.MaximumHeadSingle.Name = "MaximumHeadSingle"
        Me.MaximumHeadSingle.SiMin = -1.401298E-45!
        Me.MaximumHeadSingle.SiUnits = ""
        Me.MaximumHeadSingle.SiValue = 0!
        '
        'MaximumHeadLabel
        '
        resources.ApplyResources(Me.MaximumHeadLabel, "MaximumHeadLabel")
        Me.MaximumHeadLabel.Name = "MaximumHeadLabel"
        '
        'MinimumHeadSingle
        '
        resources.ApplyResources(Me.MinimumHeadSingle, "MinimumHeadSingle")
        Me.MinimumHeadSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinimumHeadSingle.FormatStyle = "0.0###"
        Me.MinimumHeadSingle.Label = ""
        Me.MinimumHeadSingle.Name = "MinimumHeadSingle"
        Me.MinimumHeadSingle.SiMin = -1.401298E-45!
        Me.MinimumHeadSingle.SiUnits = ""
        Me.MinimumHeadSingle.SiValue = 0!
        '
        'MinimumHeadLabel
        '
        resources.ApplyResources(Me.MinimumHeadLabel, "MinimumHeadLabel")
        Me.MinimumHeadLabel.Name = "MinimumHeadLabel"
        '
        'FixedDischargeIntervalBox
        '
        Me.FixedDischargeIntervalBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedDischargeIntervalBox, "FixedDischargeIntervalBox")
        Me.FixedDischargeIntervalBox.Controls.Add(Me.EnableDischarge)
        Me.FixedDischargeIntervalBox.Controls.Add(Me.DischargeSmartRangeButton)
        Me.FixedDischargeIntervalBox.Controls.Add(Me.DischargeIncrementSingle)
        Me.FixedDischargeIntervalBox.Controls.Add(Me.DischargeIncrementLabel)
        Me.FixedDischargeIntervalBox.Controls.Add(Me.MaximumDischargeSingle)
        Me.FixedDischargeIntervalBox.Controls.Add(Me.MaximumDischargeLabel)
        Me.FixedDischargeIntervalBox.Controls.Add(Me.MinimumDischargeSingle)
        Me.FixedDischargeIntervalBox.Controls.Add(Me.MinimumDischargeLabel)
        Me.FixedDischargeIntervalBox.Name = "FixedDischargeIntervalBox"
        Me.FixedDischargeIntervalBox.TabStop = False
        '
        'EnableDischarge
        '
        resources.ApplyResources(Me.EnableDischarge, "EnableDischarge")
        Me.EnableDischarge.Checked = True
        Me.EnableDischarge.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EnableDischarge.Name = "EnableDischarge"
        Me.EnableDischarge.UseVisualStyleBackColor = True
        Me.EnableDischarge.Value = True
        '
        'DischargeSmartRangeButton
        '
        Me.DischargeSmartRangeButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.DischargeSmartRangeButton, "DischargeSmartRangeButton")
        Me.DischargeSmartRangeButton.Name = "DischargeSmartRangeButton"
        Me.DischargeSmartRangeButton.UseVisualStyleBackColor = False
        '
        'DischargeIncrementSingle
        '
        resources.ApplyResources(Me.DischargeIncrementSingle, "DischargeIncrementSingle")
        Me.DischargeIncrementSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DischargeIncrementSingle.FormatStyle = "0.0###"
        Me.DischargeIncrementSingle.Label = ""
        Me.DischargeIncrementSingle.Name = "DischargeIncrementSingle"
        Me.DischargeIncrementSingle.SiMin = -1.401298E-45!
        Me.DischargeIncrementSingle.SiUnits = ""
        Me.DischargeIncrementSingle.SiValue = 0!
        '
        'DischargeIncrementLabel
        '
        resources.ApplyResources(Me.DischargeIncrementLabel, "DischargeIncrementLabel")
        Me.DischargeIncrementLabel.Name = "DischargeIncrementLabel"
        '
        'MaximumDischargeSingle
        '
        resources.ApplyResources(Me.MaximumDischargeSingle, "MaximumDischargeSingle")
        Me.MaximumDischargeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MaximumDischargeSingle.FormatStyle = "0.0###"
        Me.MaximumDischargeSingle.Label = ""
        Me.MaximumDischargeSingle.Name = "MaximumDischargeSingle"
        Me.MaximumDischargeSingle.SiMin = -1.401298E-45!
        Me.MaximumDischargeSingle.SiUnits = ""
        Me.MaximumDischargeSingle.SiValue = 0!
        '
        'MaximumDischargeLabel
        '
        resources.ApplyResources(Me.MaximumDischargeLabel, "MaximumDischargeLabel")
        Me.MaximumDischargeLabel.Name = "MaximumDischargeLabel"
        '
        'MinimumDischargeSingle
        '
        resources.ApplyResources(Me.MinimumDischargeSingle, "MinimumDischargeSingle")
        Me.MinimumDischargeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinimumDischargeSingle.FormatStyle = "0.0###"
        Me.MinimumDischargeSingle.Label = ""
        Me.MinimumDischargeSingle.Name = "MinimumDischargeSingle"
        Me.MinimumDischargeSingle.SiMin = -1.401298E-45!
        Me.MinimumDischargeSingle.SiUnits = ""
        Me.MinimumDischargeSingle.SiValue = 0!
        '
        'MinimumDischargeLabel
        '
        resources.ApplyResources(Me.MinimumDischargeLabel, "MinimumDischargeLabel")
        Me.MinimumDischargeLabel.Name = "MinimumDischargeLabel"
        '
        'GageReferenceGroup
        '
        Me.GageReferenceGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GageReferenceGroup.Controls.Add(Me.UpstreamChannellBottomButton)
        Me.GageReferenceGroup.Controls.Add(Me.SillReferencedButton)
        resources.ApplyResources(Me.GageReferenceGroup, "GageReferenceGroup")
        Me.GageReferenceGroup.Name = "GageReferenceGroup"
        Me.GageReferenceGroup.TabStop = False
        '
        'UpstreamChannellBottomButton
        '
        resources.ApplyResources(Me.UpstreamChannellBottomButton, "UpstreamChannellBottomButton")
        Me.UpstreamChannellBottomButton.Label = ""
        Me.UpstreamChannellBottomButton.Name = "UpstreamChannellBottomButton"
        Me.UpstreamChannellBottomButton.RbValue = -1
        Me.UpstreamChannellBottomButton.TabStop = True
        Me.UpstreamChannellBottomButton.UiValue = -1
        Me.UpstreamChannellBottomButton.UseVisualStyleBackColor = True
        '
        'SillReferencedButton
        '
        resources.ApplyResources(Me.SillReferencedButton, "SillReferencedButton")
        Me.SillReferencedButton.Label = ""
        Me.SillReferencedButton.Name = "SillReferencedButton"
        Me.SillReferencedButton.RbValue = -1
        Me.SillReferencedButton.TabStop = True
        Me.SillReferencedButton.UiValue = -1
        Me.SillReferencedButton.UseVisualStyleBackColor = True
        '
        'GageSlopeSingle
        '
        resources.ApplyResources(Me.GageSlopeSingle, "GageSlopeSingle")
        Me.GageSlopeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GageSlopeSingle.FormatStyle = "0.0###"
        Me.GageSlopeSingle.Label = ""
        Me.GageSlopeSingle.Name = "GageSlopeSingle"
        Me.GageSlopeSingle.SiMin = -1.401298E-45!
        Me.GageSlopeSingle.SiUnits = ""
        Me.GageSlopeSingle.SiValue = 0!
        '
        'GageSlopeLabel
        '
        resources.ApplyResources(Me.GageSlopeLabel, "GageSlopeLabel")
        Me.GageSlopeLabel.Name = "GageSlopeLabel"
        '
        'WallGageOptionsControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.GageSlopeSingle)
        Me.Controls.Add(Me.GageSlopeLabel)
        Me.Controls.Add(Me.GageReferenceGroup)
        Me.Controls.Add(Me.FixedDischargeIntervalBox)
        Me.Controls.Add(Me.FixedHeadIntervalBox)
        Me.Name = "WallGageOptionsControl"
        Me.FixedHeadIntervalBox.ResumeLayout(False)
        Me.FixedHeadIntervalBox.PerformLayout()
        Me.FixedDischargeIntervalBox.ResumeLayout(False)
        Me.FixedDischargeIntervalBox.PerformLayout()
        Me.GageReferenceGroup.ResumeLayout(False)
        Me.GageReferenceGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FixedHeadIntervalBox As ctl_GroupBox
    Friend WithEvents HeadSmartRangeButton As ctl_Button
    Friend WithEvents HeadIncrementSingle As ctl_SingleUnits
    Friend WithEvents HeadIncrementLabel As ctl_Label
    Friend WithEvents MaximumHeadSingle As ctl_SingleUnits
    Friend WithEvents MaximumHeadLabel As ctl_Label
    Friend WithEvents MinimumHeadSingle As ctl_SingleUnits
    Friend WithEvents MinimumHeadLabel As ctl_Label
    Friend WithEvents FixedDischargeIntervalBox As ctl_GroupBox
    Friend WithEvents DischargeSmartRangeButton As ctl_Button
    Friend WithEvents DischargeIncrementSingle As ctl_SingleUnits
    Friend WithEvents DischargeIncrementLabel As ctl_Label
    Friend WithEvents MaximumDischargeSingle As ctl_SingleUnits
    Friend WithEvents MaximumDischargeLabel As ctl_Label
    Friend WithEvents MinimumDischargeSingle As ctl_SingleUnits
    Friend WithEvents MinimumDischargeLabel As ctl_Label
    Friend WithEvents EnableHead As ctl_CheckBox
    Friend WithEvents EnableDischarge As ctl_CheckBox
    Friend WithEvents GageReferenceGroup As ctl_GroupBox
    Friend WithEvents UpstreamChannellBottomButton As ctl_RadioButton
    Friend WithEvents SillReferencedButton As ctl_RadioButton
    Friend WithEvents GageSlopeSingle As ctl_SingleUnits
    Friend WithEvents GageSlopeLabel As ctl_Label
End Class
