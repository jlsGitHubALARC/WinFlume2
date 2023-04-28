<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TableChoicesControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TableChoicesControl))
        Me.RatingTableOutputsBox = New WinFlume.ctl_GroupBox()
        Me.H2H1Label = New WinFlume.ctl_Label()
        Me.y2Label = New WinFlume.ctl_Label()
        Me.h2Label2 = New WinFlume.ctl_Label()
        Me.h2Label1 = New WinFlume.ctl_Label()
        Me.CvLabel = New WinFlume.ctl_Label()
        Me.CdLabel = New WinFlume.ctl_Label()
        Me.V1Table = New WinFlume.ctl_Label()
        Me.y1Label = New WinFlume.ctl_Label()
        Me.H1Label = New WinFlume.ctl_Label()
        Me.H1LLabel = New WinFlume.ctl_Label()
        Me.H1H2Label = New WinFlume.ctl_Label()
        Me.FrLabel = New WinFlume.ctl_Label()
        Me.ModularLimitCheckBox = New WinFlume.ctl_CheckBox()
        Me.SubmergenceRatioCheckBox = New WinFlume.ctl_CheckBox()
        Me.ActualTailwaterDepthCheckBox = New WinFlume.ctl_CheckBox()
        Me.ActualTailwaterHeadCheckBox = New WinFlume.ctl_CheckBox()
        Me.MaxAllowableTailwaterHeadCheckBox = New WinFlume.ctl_CheckBox()
        Me.ClearAllButton = New WinFlume.ctl_Button()
        Me.SelectAllButton = New WinFlume.ctl_Button()
        Me.VelocityCoefficientCheckBox = New WinFlume.ctl_CheckBox()
        Me.DischargeCoefficientCheckBox = New WinFlume.ctl_CheckBox()
        Me.UpstreamVelocityCheckBox = New WinFlume.ctl_CheckBox()
        Me.UpstreamDepthCheckBox = New WinFlume.ctl_CheckBox()
        Me.UpstreamEnergyHeadCheckBox = New WinFlume.ctl_CheckBox()
        Me.HeadToCrestLengthRatioCheckBox = New WinFlume.ctl_CheckBox()
        Me.RequiredHeadLossCheckBox = New WinFlume.ctl_CheckBox()
        Me.FroudeNumberCheckBox = New WinFlume.ctl_CheckBox()
        Me.RangeBox = New WinFlume.ctl_GroupBox()
        Me.SmartRangeButton = New WinFlume.ctl_Button()
        Me.RangeIncrementSingle = New WinFlume.ctl_SingleUnits()
        Me.RangeIncrementLabel = New WinFlume.ctl_Label()
        Me.MaximumRangeSingle = New WinFlume.ctl_SingleUnits()
        Me.MaximumRangeLabel = New WinFlume.ctl_Label()
        Me.MinimumRangeSingle = New WinFlume.ctl_SingleUnits()
        Me.MinimumRangeLabel = New WinFlume.ctl_Label()
        Me.RatingTableTypeGroup = New WinFlume.ctl_GroupBox()
        Me.QHLabel = New WinFlume.ctl_Label()
        Me.HQLabel = New WinFlume.ctl_Label()
        Me.DischargeHeadButton = New WinFlume.ctl_RadioButton()
        Me.HeadDischargeButton = New WinFlume.ctl_RadioButton()
        Me.RatingTableOutputsBox.SuspendLayout()
        Me.RangeBox.SuspendLayout()
        Me.RatingTableTypeGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'RatingTableOutputsBox
        '
        Me.RatingTableOutputsBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RatingTableOutputsBox.Controls.Add(Me.H2H1Label)
        Me.RatingTableOutputsBox.Controls.Add(Me.y2Label)
        Me.RatingTableOutputsBox.Controls.Add(Me.h2Label2)
        Me.RatingTableOutputsBox.Controls.Add(Me.h2Label1)
        Me.RatingTableOutputsBox.Controls.Add(Me.CvLabel)
        Me.RatingTableOutputsBox.Controls.Add(Me.CdLabel)
        Me.RatingTableOutputsBox.Controls.Add(Me.V1Table)
        Me.RatingTableOutputsBox.Controls.Add(Me.y1Label)
        Me.RatingTableOutputsBox.Controls.Add(Me.H1Label)
        Me.RatingTableOutputsBox.Controls.Add(Me.H1LLabel)
        Me.RatingTableOutputsBox.Controls.Add(Me.H1H2Label)
        Me.RatingTableOutputsBox.Controls.Add(Me.FrLabel)
        Me.RatingTableOutputsBox.Controls.Add(Me.ModularLimitCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.SubmergenceRatioCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.ActualTailwaterDepthCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.ActualTailwaterHeadCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.MaxAllowableTailwaterHeadCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.ClearAllButton)
        Me.RatingTableOutputsBox.Controls.Add(Me.SelectAllButton)
        Me.RatingTableOutputsBox.Controls.Add(Me.VelocityCoefficientCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.DischargeCoefficientCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.UpstreamVelocityCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.UpstreamDepthCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.UpstreamEnergyHeadCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.HeadToCrestLengthRatioCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.RequiredHeadLossCheckBox)
        Me.RatingTableOutputsBox.Controls.Add(Me.FroudeNumberCheckBox)
        resources.ApplyResources(Me.RatingTableOutputsBox, "RatingTableOutputsBox")
        Me.RatingTableOutputsBox.Name = "RatingTableOutputsBox"
        Me.RatingTableOutputsBox.TabStop = False
        '
        'H2H1Label
        '
        resources.ApplyResources(Me.H2H1Label, "H2H1Label")
        Me.H2H1Label.Name = "H2H1Label"
        Me.H2H1Label.Tag = "13"
        '
        'y2Label
        '
        resources.ApplyResources(Me.y2Label, "y2Label")
        Me.y2Label.Name = "y2Label"
        Me.y2Label.Tag = "12"
        '
        'h2Label2
        '
        resources.ApplyResources(Me.h2Label2, "h2Label2")
        Me.h2Label2.Name = "h2Label2"
        Me.h2Label2.Tag = "11"
        '
        'h2Label1
        '
        resources.ApplyResources(Me.h2Label1, "h2Label1")
        Me.h2Label1.Name = "h2Label1"
        Me.h2Label1.Tag = "10"
        '
        'CvLabel
        '
        resources.ApplyResources(Me.CvLabel, "CvLabel")
        Me.CvLabel.Name = "CvLabel"
        Me.CvLabel.Tag = "9"
        '
        'CdLabel
        '
        resources.ApplyResources(Me.CdLabel, "CdLabel")
        Me.CdLabel.Name = "CdLabel"
        Me.CdLabel.Tag = "8"
        '
        'V1Table
        '
        resources.ApplyResources(Me.V1Table, "V1Table")
        Me.V1Table.Name = "V1Table"
        Me.V1Table.Tag = "7"
        '
        'y1Label
        '
        resources.ApplyResources(Me.y1Label, "y1Label")
        Me.y1Label.Name = "y1Label"
        Me.y1Label.Tag = "6"
        '
        'H1Label
        '
        resources.ApplyResources(Me.H1Label, "H1Label")
        Me.H1Label.Name = "H1Label"
        Me.H1Label.Tag = "5"
        '
        'H1LLabel
        '
        resources.ApplyResources(Me.H1LLabel, "H1LLabel")
        Me.H1LLabel.Name = "H1LLabel"
        Me.H1LLabel.Tag = "4"
        '
        'H1H2Label
        '
        resources.ApplyResources(Me.H1H2Label, "H1H2Label")
        Me.H1H2Label.Name = "H1H2Label"
        Me.H1H2Label.Tag = "3"
        '
        'FrLabel
        '
        resources.ApplyResources(Me.FrLabel, "FrLabel")
        Me.FrLabel.Name = "FrLabel"
        Me.FrLabel.Tag = "2"
        '
        'ModularLimitCheckBox
        '
        resources.ApplyResources(Me.ModularLimitCheckBox, "ModularLimitCheckBox")
        Me.ModularLimitCheckBox.HandleCheckedChanged = True
        Me.ModularLimitCheckBox.Name = "ModularLimitCheckBox"
        Me.ModularLimitCheckBox.Tag = "14"
        Me.ModularLimitCheckBox.UndoEnabled = True
        Me.ModularLimitCheckBox.UseVisualStyleBackColor = True
        Me.ModularLimitCheckBox.Value = False
        '
        'SubmergenceRatioCheckBox
        '
        resources.ApplyResources(Me.SubmergenceRatioCheckBox, "SubmergenceRatioCheckBox")
        Me.SubmergenceRatioCheckBox.HandleCheckedChanged = True
        Me.SubmergenceRatioCheckBox.Name = "SubmergenceRatioCheckBox"
        Me.SubmergenceRatioCheckBox.Tag = "13"
        Me.SubmergenceRatioCheckBox.UndoEnabled = True
        Me.SubmergenceRatioCheckBox.UseVisualStyleBackColor = True
        Me.SubmergenceRatioCheckBox.Value = False
        '
        'ActualTailwaterDepthCheckBox
        '
        resources.ApplyResources(Me.ActualTailwaterDepthCheckBox, "ActualTailwaterDepthCheckBox")
        Me.ActualTailwaterDepthCheckBox.HandleCheckedChanged = True
        Me.ActualTailwaterDepthCheckBox.Name = "ActualTailwaterDepthCheckBox"
        Me.ActualTailwaterDepthCheckBox.Tag = "12"
        Me.ActualTailwaterDepthCheckBox.UndoEnabled = True
        Me.ActualTailwaterDepthCheckBox.UseVisualStyleBackColor = True
        Me.ActualTailwaterDepthCheckBox.Value = False
        '
        'ActualTailwaterHeadCheckBox
        '
        resources.ApplyResources(Me.ActualTailwaterHeadCheckBox, "ActualTailwaterHeadCheckBox")
        Me.ActualTailwaterHeadCheckBox.HandleCheckedChanged = True
        Me.ActualTailwaterHeadCheckBox.Name = "ActualTailwaterHeadCheckBox"
        Me.ActualTailwaterHeadCheckBox.Tag = "11"
        Me.ActualTailwaterHeadCheckBox.UndoEnabled = True
        Me.ActualTailwaterHeadCheckBox.UseVisualStyleBackColor = True
        Me.ActualTailwaterHeadCheckBox.Value = False
        '
        'MaxAllowableTailwaterHeadCheckBox
        '
        resources.ApplyResources(Me.MaxAllowableTailwaterHeadCheckBox, "MaxAllowableTailwaterHeadCheckBox")
        Me.MaxAllowableTailwaterHeadCheckBox.HandleCheckedChanged = True
        Me.MaxAllowableTailwaterHeadCheckBox.Name = "MaxAllowableTailwaterHeadCheckBox"
        Me.MaxAllowableTailwaterHeadCheckBox.Tag = "10"
        Me.MaxAllowableTailwaterHeadCheckBox.UndoEnabled = True
        Me.MaxAllowableTailwaterHeadCheckBox.UseVisualStyleBackColor = True
        Me.MaxAllowableTailwaterHeadCheckBox.Value = False
        '
        'ClearAllButton
        '
        Me.ClearAllButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.ClearAllButton, "ClearAllButton")
        Me.ClearAllButton.Name = "ClearAllButton"
        Me.ClearAllButton.UseVisualStyleBackColor = False
        '
        'SelectAllButton
        '
        Me.SelectAllButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.SelectAllButton, "SelectAllButton")
        Me.SelectAllButton.Name = "SelectAllButton"
        Me.SelectAllButton.UseVisualStyleBackColor = False
        '
        'VelocityCoefficientCheckBox
        '
        resources.ApplyResources(Me.VelocityCoefficientCheckBox, "VelocityCoefficientCheckBox")
        Me.VelocityCoefficientCheckBox.HandleCheckedChanged = True
        Me.VelocityCoefficientCheckBox.Name = "VelocityCoefficientCheckBox"
        Me.VelocityCoefficientCheckBox.Tag = "9"
        Me.VelocityCoefficientCheckBox.UndoEnabled = True
        Me.VelocityCoefficientCheckBox.UseVisualStyleBackColor = True
        Me.VelocityCoefficientCheckBox.Value = False
        '
        'DischargeCoefficientCheckBox
        '
        resources.ApplyResources(Me.DischargeCoefficientCheckBox, "DischargeCoefficientCheckBox")
        Me.DischargeCoefficientCheckBox.HandleCheckedChanged = True
        Me.DischargeCoefficientCheckBox.Name = "DischargeCoefficientCheckBox"
        Me.DischargeCoefficientCheckBox.Tag = "8"
        Me.DischargeCoefficientCheckBox.UndoEnabled = True
        Me.DischargeCoefficientCheckBox.UseVisualStyleBackColor = True
        Me.DischargeCoefficientCheckBox.Value = False
        '
        'UpstreamVelocityCheckBox
        '
        resources.ApplyResources(Me.UpstreamVelocityCheckBox, "UpstreamVelocityCheckBox")
        Me.UpstreamVelocityCheckBox.HandleCheckedChanged = True
        Me.UpstreamVelocityCheckBox.Name = "UpstreamVelocityCheckBox"
        Me.UpstreamVelocityCheckBox.Tag = "7"
        Me.UpstreamVelocityCheckBox.UndoEnabled = True
        Me.UpstreamVelocityCheckBox.UseVisualStyleBackColor = True
        Me.UpstreamVelocityCheckBox.Value = False
        '
        'UpstreamDepthCheckBox
        '
        resources.ApplyResources(Me.UpstreamDepthCheckBox, "UpstreamDepthCheckBox")
        Me.UpstreamDepthCheckBox.HandleCheckedChanged = True
        Me.UpstreamDepthCheckBox.Name = "UpstreamDepthCheckBox"
        Me.UpstreamDepthCheckBox.Tag = "6"
        Me.UpstreamDepthCheckBox.UndoEnabled = True
        Me.UpstreamDepthCheckBox.UseVisualStyleBackColor = True
        Me.UpstreamDepthCheckBox.Value = False
        '
        'UpstreamEnergyHeadCheckBox
        '
        resources.ApplyResources(Me.UpstreamEnergyHeadCheckBox, "UpstreamEnergyHeadCheckBox")
        Me.UpstreamEnergyHeadCheckBox.HandleCheckedChanged = True
        Me.UpstreamEnergyHeadCheckBox.Name = "UpstreamEnergyHeadCheckBox"
        Me.UpstreamEnergyHeadCheckBox.Tag = "5"
        Me.UpstreamEnergyHeadCheckBox.UndoEnabled = True
        Me.UpstreamEnergyHeadCheckBox.UseVisualStyleBackColor = True
        Me.UpstreamEnergyHeadCheckBox.Value = False
        '
        'HeadToCrestLengthRatioCheckBox
        '
        resources.ApplyResources(Me.HeadToCrestLengthRatioCheckBox, "HeadToCrestLengthRatioCheckBox")
        Me.HeadToCrestLengthRatioCheckBox.HandleCheckedChanged = True
        Me.HeadToCrestLengthRatioCheckBox.Name = "HeadToCrestLengthRatioCheckBox"
        Me.HeadToCrestLengthRatioCheckBox.Tag = "4"
        Me.HeadToCrestLengthRatioCheckBox.UndoEnabled = True
        Me.HeadToCrestLengthRatioCheckBox.UseVisualStyleBackColor = True
        Me.HeadToCrestLengthRatioCheckBox.Value = False
        '
        'RequiredHeadLossCheckBox
        '
        resources.ApplyResources(Me.RequiredHeadLossCheckBox, "RequiredHeadLossCheckBox")
        Me.RequiredHeadLossCheckBox.HandleCheckedChanged = True
        Me.RequiredHeadLossCheckBox.Name = "RequiredHeadLossCheckBox"
        Me.RequiredHeadLossCheckBox.Tag = "3"
        Me.RequiredHeadLossCheckBox.UndoEnabled = True
        Me.RequiredHeadLossCheckBox.UseVisualStyleBackColor = True
        Me.RequiredHeadLossCheckBox.Value = False
        '
        'FroudeNumberCheckBox
        '
        resources.ApplyResources(Me.FroudeNumberCheckBox, "FroudeNumberCheckBox")
        Me.FroudeNumberCheckBox.HandleCheckedChanged = True
        Me.FroudeNumberCheckBox.Name = "FroudeNumberCheckBox"
        Me.FroudeNumberCheckBox.Tag = "2"
        Me.FroudeNumberCheckBox.UndoEnabled = True
        Me.FroudeNumberCheckBox.UseVisualStyleBackColor = True
        Me.FroudeNumberCheckBox.Value = False
        '
        'RangeBox
        '
        Me.RangeBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.RangeBox, "RangeBox")
        Me.RangeBox.Controls.Add(Me.SmartRangeButton)
        Me.RangeBox.Controls.Add(Me.RangeIncrementSingle)
        Me.RangeBox.Controls.Add(Me.RangeIncrementLabel)
        Me.RangeBox.Controls.Add(Me.MaximumRangeSingle)
        Me.RangeBox.Controls.Add(Me.MaximumRangeLabel)
        Me.RangeBox.Controls.Add(Me.MinimumRangeSingle)
        Me.RangeBox.Controls.Add(Me.MinimumRangeLabel)
        Me.RangeBox.Name = "RangeBox"
        Me.RangeBox.TabStop = False
        '
        'SmartRangeButton
        '
        Me.SmartRangeButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.SmartRangeButton, "SmartRangeButton")
        Me.SmartRangeButton.Name = "SmartRangeButton"
        Me.SmartRangeButton.UseVisualStyleBackColor = False
        '
        'RangeIncrementSingle
        '
        resources.ApplyResources(Me.RangeIncrementSingle, "RangeIncrementSingle")
        Me.RangeIncrementSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RangeIncrementSingle.FormatStyle = "0.0###"
        Me.RangeIncrementSingle.IsReadOnly = False
        Me.RangeIncrementSingle.Label = ""
        Me.RangeIncrementSingle.Name = "RangeIncrementSingle"
        Me.RangeIncrementSingle.ReadOnlyMsgBox = Nothing
        Me.RangeIncrementSingle.SiDefaultValue = 0!
        Me.RangeIncrementSingle.SiMin = -1.401298E-45!
        Me.RangeIncrementSingle.SiUnits = ""
        Me.RangeIncrementSingle.SiValue = 0!
        Me.RangeIncrementSingle.UndoEnabled = True
        '
        'RangeIncrementLabel
        '
        resources.ApplyResources(Me.RangeIncrementLabel, "RangeIncrementLabel")
        Me.RangeIncrementLabel.Name = "RangeIncrementLabel"
        '
        'MaximumRangeSingle
        '
        resources.ApplyResources(Me.MaximumRangeSingle, "MaximumRangeSingle")
        Me.MaximumRangeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MaximumRangeSingle.FormatStyle = "0.0###"
        Me.MaximumRangeSingle.IsReadOnly = False
        Me.MaximumRangeSingle.Label = ""
        Me.MaximumRangeSingle.Name = "MaximumRangeSingle"
        Me.MaximumRangeSingle.ReadOnlyMsgBox = Nothing
        Me.MaximumRangeSingle.SiDefaultValue = 0!
        Me.MaximumRangeSingle.SiMin = -1.401298E-45!
        Me.MaximumRangeSingle.SiUnits = ""
        Me.MaximumRangeSingle.SiValue = 0!
        Me.MaximumRangeSingle.UndoEnabled = True
        '
        'MaximumRangeLabel
        '
        resources.ApplyResources(Me.MaximumRangeLabel, "MaximumRangeLabel")
        Me.MaximumRangeLabel.Name = "MaximumRangeLabel"
        '
        'MinimumRangeSingle
        '
        resources.ApplyResources(Me.MinimumRangeSingle, "MinimumRangeSingle")
        Me.MinimumRangeSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinimumRangeSingle.FormatStyle = "0.0###"
        Me.MinimumRangeSingle.IsReadOnly = False
        Me.MinimumRangeSingle.Label = ""
        Me.MinimumRangeSingle.Name = "MinimumRangeSingle"
        Me.MinimumRangeSingle.ReadOnlyMsgBox = Nothing
        Me.MinimumRangeSingle.SiDefaultValue = 0!
        Me.MinimumRangeSingle.SiMin = -1.401298E-45!
        Me.MinimumRangeSingle.SiUnits = ""
        Me.MinimumRangeSingle.SiValue = 0!
        Me.MinimumRangeSingle.UndoEnabled = True
        '
        'MinimumRangeLabel
        '
        resources.ApplyResources(Me.MinimumRangeLabel, "MinimumRangeLabel")
        Me.MinimumRangeLabel.Name = "MinimumRangeLabel"
        '
        'RatingTableTypeGroup
        '
        Me.RatingTableTypeGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RatingTableTypeGroup.Controls.Add(Me.QHLabel)
        Me.RatingTableTypeGroup.Controls.Add(Me.HQLabel)
        Me.RatingTableTypeGroup.Controls.Add(Me.DischargeHeadButton)
        Me.RatingTableTypeGroup.Controls.Add(Me.HeadDischargeButton)
        resources.ApplyResources(Me.RatingTableTypeGroup, "RatingTableTypeGroup")
        Me.RatingTableTypeGroup.Name = "RatingTableTypeGroup"
        Me.RatingTableTypeGroup.TabStop = False
        '
        'QHLabel
        '
        resources.ApplyResources(Me.QHLabel, "QHLabel")
        Me.QHLabel.Name = "QHLabel"
        '
        'HQLabel
        '
        resources.ApplyResources(Me.HQLabel, "HQLabel")
        Me.HQLabel.Name = "HQLabel"
        '
        'DischargeHeadButton
        '
        resources.ApplyResources(Me.DischargeHeadButton, "DischargeHeadButton")
        Me.DischargeHeadButton.Label = ""
        Me.DischargeHeadButton.Name = "DischargeHeadButton"
        Me.DischargeHeadButton.RbValue = -1
        Me.DischargeHeadButton.TabStop = True
        Me.DischargeHeadButton.UiValue = -1
        Me.DischargeHeadButton.UseVisualStyleBackColor = True
        '
        'HeadDischargeButton
        '
        resources.ApplyResources(Me.HeadDischargeButton, "HeadDischargeButton")
        Me.HeadDischargeButton.Label = ""
        Me.HeadDischargeButton.Name = "HeadDischargeButton"
        Me.HeadDischargeButton.RbValue = -1
        Me.HeadDischargeButton.TabStop = True
        Me.HeadDischargeButton.UiValue = -1
        Me.HeadDischargeButton.UseVisualStyleBackColor = True
        '
        'TableChoicesControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.RatingTableOutputsBox)
        Me.Controls.Add(Me.RangeBox)
        Me.Controls.Add(Me.RatingTableTypeGroup)
        Me.Name = "TableChoicesControl"
        Me.RatingTableOutputsBox.ResumeLayout(False)
        Me.RatingTableOutputsBox.PerformLayout()
        Me.RangeBox.ResumeLayout(False)
        Me.RangeBox.PerformLayout()
        Me.RatingTableTypeGroup.ResumeLayout(False)
        Me.RatingTableTypeGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RatingTableTypeGroup As WinFlume.ctl_GroupBox
    Friend WithEvents RangeBox As WinFlume.ctl_GroupBox
    Friend WithEvents DischargeHeadButton As WinFlume.ctl_RadioButton
    Friend WithEvents HeadDischargeButton As WinFlume.ctl_RadioButton
    Friend WithEvents RatingTableOutputsBox As WinFlume.ctl_GroupBox
    Friend WithEvents QHLabel As WinFlume.ctl_Label
    Friend WithEvents HQLabel As WinFlume.ctl_Label
    Friend WithEvents MinimumRangeSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents MinimumRangeLabel As WinFlume.ctl_Label
    Friend WithEvents SmartRangeButton As WinFlume.ctl_Button
    Friend WithEvents RangeIncrementSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents RangeIncrementLabel As WinFlume.ctl_Label
    Friend WithEvents MaximumRangeSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents MaximumRangeLabel As WinFlume.ctl_Label
    Friend WithEvents FroudeNumberCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents MaxAllowableTailwaterHeadCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents HeadToCrestLengthRatioCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents RequiredHeadLossCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents UpstreamEnergyHeadCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents VelocityCoefficientCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents DischargeCoefficientCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents UpstreamVelocityCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents UpstreamDepthCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents ClearAllButton As WinFlume.ctl_Button
    Friend WithEvents SelectAllButton As WinFlume.ctl_Button
    Friend WithEvents ActualTailwaterHeadCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents ActualTailwaterDepthCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents ModularLimitCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents SubmergenceRatioCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents FrLabel As WinFlume.ctl_Label
    Friend WithEvents H1Label As WinFlume.ctl_Label
    Friend WithEvents H1LLabel As WinFlume.ctl_Label
    Friend WithEvents H1H2Label As WinFlume.ctl_Label
    Friend WithEvents y1Label As WinFlume.ctl_Label
    Friend WithEvents CdLabel As WinFlume.ctl_Label
    Friend WithEvents V1Table As WinFlume.ctl_Label
    Friend WithEvents CvLabel As WinFlume.ctl_Label
    Friend WithEvents h2Label1 As WinFlume.ctl_Label
    Friend WithEvents h2Label2 As WinFlume.ctl_Label
    Friend WithEvents H2H1Label As WinFlume.ctl_Label
    Friend WithEvents y2Label As WinFlume.ctl_Label

End Class
