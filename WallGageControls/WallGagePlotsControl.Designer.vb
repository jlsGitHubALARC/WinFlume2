<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WallGagePlotsControl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WallGagePlotsControl))
        Me.FixedDischargeIntervalBox = New WinFlume.ctl_GroupBox()
        Me.FixedDischargeGagePanel = New WinFlume.ctl_Panel()
        Me.FixedDischargeThumbnailLabel = New WinFlume.ctl_Label()
        Me.FixedDischargeGagePlot = New WinFlume.ctl_Canvas2D()
        Me.FixedDischargeControlPanel = New WinFlume.ctl_Panel()
        Me.DischargeFirstLabelOffsetLabel = New WinFlume.ctl_Label()
        Me.DischargeFirstLabelOffsetControl = New WinFlume.ctl_SingleUpDown()
        Me.DischargeDecimalsToShowLabel = New WinFlume.ctl_Label()
        Me.DischargeDecimalsToShowControl = New WinFlume.ctl_SingleUpDown()
        Me.DischargeLabeledTickIntervalControl = New WinFlume.ctl_ComboBox()
        Me.DischargeLabeledTickIntervalLabel = New WinFlume.ctl_Label()
        Me.DischargeLabelSizeFactorLabel = New WinFlume.ctl_Label()
        Me.DischargeLabelSizeFactorUpDown = New WinFlume.ctl_SingleUpDown()
        Me.ViewDischargeGageButton = New WinFlume.ctl_Button()
        Me.DischargeGageTypePanel = New WinFlume.ctl_Panel()
        Me.VerticalDischargeGageButton = New WinFlume.ctl_RadioButton()
        Me.SlopedDischargeGageButton = New WinFlume.ctl_RadioButton()
        Me.FixedHeadIntervalBox = New WinFlume.ctl_GroupBox()
        Me.FixedHeadPlotPanel = New WinFlume.ctl_Panel()
        Me.FixedHeadGagePanel = New WinFlume.ctl_Panel()
        Me.FixedHeadThumbnailLabel = New WinFlume.ctl_Label()
        Me.FixedHeadGagePlot = New WinFlume.ctl_Canvas2D()
        Me.FixedHeadControlPanel = New WinFlume.ctl_Panel()
        Me.HeadFirstLabelOffsetLabel = New WinFlume.ctl_Label()
        Me.HeadFirstLabelOffsetControl = New WinFlume.ctl_SingleUpDown()
        Me.LabelsTypePanel = New WinFlume.ctl_Panel()
        Me.FlowLabelsButton = New WinFlume.ctl_RadioButton()
        Me.HeadLabelsButton = New WinFlume.ctl_RadioButton()
        Me.HeadDecimalsToShowLabel = New WinFlume.ctl_Label()
        Me.HeadDecimalsToShowControl = New WinFlume.ctl_SingleUpDown()
        Me.HeadLabeledTickIntervalControl = New WinFlume.ctl_ComboBox()
        Me.HeadLabeledTickIntervalLabel = New WinFlume.ctl_Label()
        Me.HeadLabelSizeFactorLabel = New WinFlume.ctl_Label()
        Me.HeadLabelSizeFactorUpDown = New WinFlume.ctl_SingleUpDown()
        Me.ViewHeadGageButton = New WinFlume.ctl_Button()
        Me.HeadGageTypePanel = New WinFlume.ctl_Panel()
        Me.VerticalHeadGageButton = New WinFlume.ctl_RadioButton()
        Me.SlopedHeadGageButton = New WinFlume.ctl_RadioButton()
        Me.PrintWallGageDialog = New System.Windows.Forms.PrintDialog()
        Me.PrintWallGageDocument = New System.Drawing.Printing.PrintDocument()
        Me.FixedDischargeIntervalBox.SuspendLayout()
        Me.FixedDischargeGagePanel.SuspendLayout()
        CType(Me.FixedDischargeGagePlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FixedDischargeControlPanel.SuspendLayout()
        CType(Me.DischargeFirstLabelOffsetControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DischargeDecimalsToShowControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DischargeLabelSizeFactorUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DischargeGageTypePanel.SuspendLayout()
        Me.FixedHeadIntervalBox.SuspendLayout()
        Me.FixedHeadPlotPanel.SuspendLayout()
        Me.FixedHeadGagePanel.SuspendLayout()
        CType(Me.FixedHeadGagePlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FixedHeadControlPanel.SuspendLayout()
        CType(Me.HeadFirstLabelOffsetControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LabelsTypePanel.SuspendLayout()
        CType(Me.HeadDecimalsToShowControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HeadLabelSizeFactorUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeadGageTypePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'FixedDischargeIntervalBox
        '
        Me.FixedDischargeIntervalBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedDischargeIntervalBox, "FixedDischargeIntervalBox")
        Me.FixedDischargeIntervalBox.Controls.Add(Me.FixedDischargeGagePanel)
        Me.FixedDischargeIntervalBox.Controls.Add(Me.FixedDischargeControlPanel)
        Me.FixedDischargeIntervalBox.Name = "FixedDischargeIntervalBox"
        Me.FixedDischargeIntervalBox.TabStop = False
        '
        'FixedDischargeGagePanel
        '
        Me.FixedDischargeGagePanel.Controls.Add(Me.FixedDischargeThumbnailLabel)
        Me.FixedDischargeGagePanel.Controls.Add(Me.FixedDischargeGagePlot)
        resources.ApplyResources(Me.FixedDischargeGagePanel, "FixedDischargeGagePanel")
        Me.FixedDischargeGagePanel.Name = "FixedDischargeGagePanel"
        '
        'FixedDischargeThumbnailLabel
        '
        resources.ApplyResources(Me.FixedDischargeThumbnailLabel, "FixedDischargeThumbnailLabel")
        Me.FixedDischargeThumbnailLabel.Name = "FixedDischargeThumbnailLabel"
        '
        'FixedDischargeGagePlot
        '
        resources.ApplyResources(Me.FixedDischargeGagePlot, "FixedDischargeGagePlot")
        Me.FixedDischargeGagePlot.Name = "FixedDischargeGagePlot"
        Me.FixedDischargeGagePlot.TabStop = False
        '
        'FixedDischargeControlPanel
        '
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeFirstLabelOffsetLabel)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeFirstLabelOffsetControl)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeDecimalsToShowLabel)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeDecimalsToShowControl)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeLabeledTickIntervalControl)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeLabeledTickIntervalLabel)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeLabelSizeFactorLabel)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeLabelSizeFactorUpDown)
        Me.FixedDischargeControlPanel.Controls.Add(Me.ViewDischargeGageButton)
        Me.FixedDischargeControlPanel.Controls.Add(Me.DischargeGageTypePanel)
        resources.ApplyResources(Me.FixedDischargeControlPanel, "FixedDischargeControlPanel")
        Me.FixedDischargeControlPanel.Name = "FixedDischargeControlPanel"
        '
        'DischargeFirstLabelOffsetLabel
        '
        resources.ApplyResources(Me.DischargeFirstLabelOffsetLabel, "DischargeFirstLabelOffsetLabel")
        Me.DischargeFirstLabelOffsetLabel.Name = "DischargeFirstLabelOffsetLabel"
        '
        'DischargeFirstLabelOffsetControl
        '
        Me.DischargeFirstLabelOffsetControl.FormatStyle = "0"
        Me.DischargeFirstLabelOffsetControl.Label = ""
        resources.ApplyResources(Me.DischargeFirstLabelOffsetControl, "DischargeFirstLabelOffsetControl")
        Me.DischargeFirstLabelOffsetControl.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.DischargeFirstLabelOffsetControl.Minimum = New Decimal(New Integer() {9999, 0, 0, -2147483648})
        Me.DischargeFirstLabelOffsetControl.Name = "DischargeFirstLabelOffsetControl"
        Me.DischargeFirstLabelOffsetControl.SiValue = 0!
        Me.DischargeFirstLabelOffsetControl.UiValue = 0!
        '
        'DischargeDecimalsToShowLabel
        '
        resources.ApplyResources(Me.DischargeDecimalsToShowLabel, "DischargeDecimalsToShowLabel")
        Me.DischargeDecimalsToShowLabel.Name = "DischargeDecimalsToShowLabel"
        '
        'DischargeDecimalsToShowControl
        '
        Me.DischargeDecimalsToShowControl.FormatStyle = "0"
        Me.DischargeDecimalsToShowControl.Label = ""
        resources.ApplyResources(Me.DischargeDecimalsToShowControl, "DischargeDecimalsToShowControl")
        Me.DischargeDecimalsToShowControl.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.DischargeDecimalsToShowControl.Name = "DischargeDecimalsToShowControl"
        Me.DischargeDecimalsToShowControl.SiValue = 0!
        Me.DischargeDecimalsToShowControl.UiValue = 0!
        '
        'DischargeLabeledTickIntervalControl
        '
        Me.DischargeLabeledTickIntervalControl.BackColor = System.Drawing.SystemColors.Window
        Me.DischargeLabeledTickIntervalControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.DischargeLabeledTickIntervalControl, "DischargeLabeledTickIntervalControl")
        Me.DischargeLabeledTickIntervalControl.FormattingEnabled = True
        Me.DischargeLabeledTickIntervalControl.Items.AddRange(New Object() {resources.GetString("DischargeLabeledTickIntervalControl.Items"), resources.GetString("DischargeLabeledTickIntervalControl.Items1"), resources.GetString("DischargeLabeledTickIntervalControl.Items2"), resources.GetString("DischargeLabeledTickIntervalControl.Items3"), resources.GetString("DischargeLabeledTickIntervalControl.Items4")})
        Me.DischargeLabeledTickIntervalControl.Name = "DischargeLabeledTickIntervalControl"
        Me.DischargeLabeledTickIntervalControl.Value = -1
        '
        'DischargeLabeledTickIntervalLabel
        '
        resources.ApplyResources(Me.DischargeLabeledTickIntervalLabel, "DischargeLabeledTickIntervalLabel")
        Me.DischargeLabeledTickIntervalLabel.Name = "DischargeLabeledTickIntervalLabel"
        '
        'DischargeLabelSizeFactorLabel
        '
        resources.ApplyResources(Me.DischargeLabelSizeFactorLabel, "DischargeLabelSizeFactorLabel")
        Me.DischargeLabelSizeFactorLabel.Name = "DischargeLabelSizeFactorLabel"
        '
        'DischargeLabelSizeFactorUpDown
        '
        Me.DischargeLabelSizeFactorUpDown.DecimalPlaces = 2
        Me.DischargeLabelSizeFactorUpDown.FormatStyle = "0.0###"
        Me.DischargeLabelSizeFactorUpDown.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.DischargeLabelSizeFactorUpDown.Label = ""
        resources.ApplyResources(Me.DischargeLabelSizeFactorUpDown, "DischargeLabelSizeFactorUpDown")
        Me.DischargeLabelSizeFactorUpDown.Maximum = New Decimal(New Integer() {205, 0, 0, 131072})
        Me.DischargeLabelSizeFactorUpDown.Minimum = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.DischargeLabelSizeFactorUpDown.Name = "DischargeLabelSizeFactorUpDown"
        Me.DischargeLabelSizeFactorUpDown.SiValue = 0.05!
        Me.DischargeLabelSizeFactorUpDown.UiValue = 0.05!
        Me.DischargeLabelSizeFactorUpDown.Value = New Decimal(New Integer() {5, 0, 0, 131072})
        '
        'ViewDischargeGageButton
        '
        Me.ViewDischargeGageButton.BackColor = System.Drawing.SystemColors.Control
        Me.ViewDischargeGageButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.ViewDischargeGageButton, "ViewDischargeGageButton")
        Me.ViewDischargeGageButton.Name = "ViewDischargeGageButton"
        Me.ViewDischargeGageButton.UseVisualStyleBackColor = False
        '
        'DischargeGageTypePanel
        '
        Me.DischargeGageTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DischargeGageTypePanel.Controls.Add(Me.VerticalDischargeGageButton)
        Me.DischargeGageTypePanel.Controls.Add(Me.SlopedDischargeGageButton)
        resources.ApplyResources(Me.DischargeGageTypePanel, "DischargeGageTypePanel")
        Me.DischargeGageTypePanel.Name = "DischargeGageTypePanel"
        '
        'VerticalDischargeGageButton
        '
        resources.ApplyResources(Me.VerticalDischargeGageButton, "VerticalDischargeGageButton")
        Me.VerticalDischargeGageButton.Label = ""
        Me.VerticalDischargeGageButton.Name = "VerticalDischargeGageButton"
        Me.VerticalDischargeGageButton.RbValue = -1
        Me.VerticalDischargeGageButton.TabStop = True
        Me.VerticalDischargeGageButton.UiValue = -1
        Me.VerticalDischargeGageButton.UseVisualStyleBackColor = True
        '
        'SlopedDischargeGageButton
        '
        resources.ApplyResources(Me.SlopedDischargeGageButton, "SlopedDischargeGageButton")
        Me.SlopedDischargeGageButton.Label = ""
        Me.SlopedDischargeGageButton.Name = "SlopedDischargeGageButton"
        Me.SlopedDischargeGageButton.RbValue = -1
        Me.SlopedDischargeGageButton.TabStop = True
        Me.SlopedDischargeGageButton.UiValue = -1
        Me.SlopedDischargeGageButton.UseVisualStyleBackColor = True
        '
        'FixedHeadIntervalBox
        '
        Me.FixedHeadIntervalBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.FixedHeadIntervalBox, "FixedHeadIntervalBox")
        Me.FixedHeadIntervalBox.Controls.Add(Me.FixedHeadPlotPanel)
        Me.FixedHeadIntervalBox.Controls.Add(Me.FixedHeadControlPanel)
        Me.FixedHeadIntervalBox.Name = "FixedHeadIntervalBox"
        Me.FixedHeadIntervalBox.TabStop = False
        '
        'FixedHeadPlotPanel
        '
        Me.FixedHeadPlotPanel.Controls.Add(Me.FixedHeadGagePanel)
        resources.ApplyResources(Me.FixedHeadPlotPanel, "FixedHeadPlotPanel")
        Me.FixedHeadPlotPanel.Name = "FixedHeadPlotPanel"
        '
        'FixedHeadGagePanel
        '
        Me.FixedHeadGagePanel.Controls.Add(Me.FixedHeadThumbnailLabel)
        Me.FixedHeadGagePanel.Controls.Add(Me.FixedHeadGagePlot)
        resources.ApplyResources(Me.FixedHeadGagePanel, "FixedHeadGagePanel")
        Me.FixedHeadGagePanel.Name = "FixedHeadGagePanel"
        '
        'FixedHeadThumbnailLabel
        '
        resources.ApplyResources(Me.FixedHeadThumbnailLabel, "FixedHeadThumbnailLabel")
        Me.FixedHeadThumbnailLabel.Name = "FixedHeadThumbnailLabel"
        '
        'FixedHeadGagePlot
        '
        resources.ApplyResources(Me.FixedHeadGagePlot, "FixedHeadGagePlot")
        Me.FixedHeadGagePlot.Name = "FixedHeadGagePlot"
        Me.FixedHeadGagePlot.TabStop = False
        '
        'FixedHeadControlPanel
        '
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadFirstLabelOffsetLabel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadFirstLabelOffsetControl)
        Me.FixedHeadControlPanel.Controls.Add(Me.LabelsTypePanel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadDecimalsToShowLabel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadDecimalsToShowControl)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadLabeledTickIntervalControl)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadLabeledTickIntervalLabel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadLabelSizeFactorLabel)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadLabelSizeFactorUpDown)
        Me.FixedHeadControlPanel.Controls.Add(Me.ViewHeadGageButton)
        Me.FixedHeadControlPanel.Controls.Add(Me.HeadGageTypePanel)
        resources.ApplyResources(Me.FixedHeadControlPanel, "FixedHeadControlPanel")
        Me.FixedHeadControlPanel.Name = "FixedHeadControlPanel"
        '
        'HeadFirstLabelOffsetLabel
        '
        resources.ApplyResources(Me.HeadFirstLabelOffsetLabel, "HeadFirstLabelOffsetLabel")
        Me.HeadFirstLabelOffsetLabel.Name = "HeadFirstLabelOffsetLabel"
        '
        'HeadFirstLabelOffsetControl
        '
        Me.HeadFirstLabelOffsetControl.FormatStyle = "0"
        Me.HeadFirstLabelOffsetControl.Label = ""
        resources.ApplyResources(Me.HeadFirstLabelOffsetControl, "HeadFirstLabelOffsetControl")
        Me.HeadFirstLabelOffsetControl.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.HeadFirstLabelOffsetControl.Minimum = New Decimal(New Integer() {9999, 0, 0, -2147483648})
        Me.HeadFirstLabelOffsetControl.Name = "HeadFirstLabelOffsetControl"
        Me.HeadFirstLabelOffsetControl.SiValue = 0!
        Me.HeadFirstLabelOffsetControl.UiValue = 0!
        '
        'LabelsTypePanel
        '
        Me.LabelsTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelsTypePanel.Controls.Add(Me.FlowLabelsButton)
        Me.LabelsTypePanel.Controls.Add(Me.HeadLabelsButton)
        resources.ApplyResources(Me.LabelsTypePanel, "LabelsTypePanel")
        Me.LabelsTypePanel.Name = "LabelsTypePanel"
        '
        'FlowLabelsButton
        '
        resources.ApplyResources(Me.FlowLabelsButton, "FlowLabelsButton")
        Me.FlowLabelsButton.Label = ""
        Me.FlowLabelsButton.Name = "FlowLabelsButton"
        Me.FlowLabelsButton.RbValue = -1
        Me.FlowLabelsButton.TabStop = True
        Me.FlowLabelsButton.UiValue = -1
        Me.FlowLabelsButton.UseVisualStyleBackColor = True
        '
        'HeadLabelsButton
        '
        resources.ApplyResources(Me.HeadLabelsButton, "HeadLabelsButton")
        Me.HeadLabelsButton.Label = ""
        Me.HeadLabelsButton.Name = "HeadLabelsButton"
        Me.HeadLabelsButton.RbValue = -1
        Me.HeadLabelsButton.TabStop = True
        Me.HeadLabelsButton.UiValue = -1
        Me.HeadLabelsButton.UseVisualStyleBackColor = True
        '
        'HeadDecimalsToShowLabel
        '
        resources.ApplyResources(Me.HeadDecimalsToShowLabel, "HeadDecimalsToShowLabel")
        Me.HeadDecimalsToShowLabel.Name = "HeadDecimalsToShowLabel"
        '
        'HeadDecimalsToShowControl
        '
        Me.HeadDecimalsToShowControl.FormatStyle = "0"
        Me.HeadDecimalsToShowControl.Label = ""
        resources.ApplyResources(Me.HeadDecimalsToShowControl, "HeadDecimalsToShowControl")
        Me.HeadDecimalsToShowControl.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.HeadDecimalsToShowControl.Name = "HeadDecimalsToShowControl"
        Me.HeadDecimalsToShowControl.SiValue = 0!
        Me.HeadDecimalsToShowControl.UiValue = 0!
        '
        'HeadLabeledTickIntervalControl
        '
        Me.HeadLabeledTickIntervalControl.BackColor = System.Drawing.SystemColors.Window
        Me.HeadLabeledTickIntervalControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.HeadLabeledTickIntervalControl, "HeadLabeledTickIntervalControl")
        Me.HeadLabeledTickIntervalControl.FormattingEnabled = True
        Me.HeadLabeledTickIntervalControl.Items.AddRange(New Object() {resources.GetString("HeadLabeledTickIntervalControl.Items"), resources.GetString("HeadLabeledTickIntervalControl.Items1"), resources.GetString("HeadLabeledTickIntervalControl.Items2"), resources.GetString("HeadLabeledTickIntervalControl.Items3"), resources.GetString("HeadLabeledTickIntervalControl.Items4")})
        Me.HeadLabeledTickIntervalControl.Name = "HeadLabeledTickIntervalControl"
        Me.HeadLabeledTickIntervalControl.Value = -1
        '
        'HeadLabeledTickIntervalLabel
        '
        resources.ApplyResources(Me.HeadLabeledTickIntervalLabel, "HeadLabeledTickIntervalLabel")
        Me.HeadLabeledTickIntervalLabel.Name = "HeadLabeledTickIntervalLabel"
        '
        'HeadLabelSizeFactorLabel
        '
        resources.ApplyResources(Me.HeadLabelSizeFactorLabel, "HeadLabelSizeFactorLabel")
        Me.HeadLabelSizeFactorLabel.Name = "HeadLabelSizeFactorLabel"
        '
        'HeadLabelSizeFactorUpDown
        '
        Me.HeadLabelSizeFactorUpDown.DecimalPlaces = 2
        Me.HeadLabelSizeFactorUpDown.FormatStyle = "0.0###"
        Me.HeadLabelSizeFactorUpDown.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.HeadLabelSizeFactorUpDown.Label = ""
        resources.ApplyResources(Me.HeadLabelSizeFactorUpDown, "HeadLabelSizeFactorUpDown")
        Me.HeadLabelSizeFactorUpDown.Maximum = New Decimal(New Integer() {205, 0, 0, 131072})
        Me.HeadLabelSizeFactorUpDown.Minimum = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.HeadLabelSizeFactorUpDown.Name = "HeadLabelSizeFactorUpDown"
        Me.HeadLabelSizeFactorUpDown.SiValue = 0.05!
        Me.HeadLabelSizeFactorUpDown.UiValue = 0.05!
        Me.HeadLabelSizeFactorUpDown.Value = New Decimal(New Integer() {5, 0, 0, 131072})
        '
        'ViewHeadGageButton
        '
        Me.ViewHeadGageButton.BackColor = System.Drawing.SystemColors.Control
        Me.ViewHeadGageButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.ViewHeadGageButton, "ViewHeadGageButton")
        Me.ViewHeadGageButton.Name = "ViewHeadGageButton"
        Me.ViewHeadGageButton.UseVisualStyleBackColor = False
        '
        'HeadGageTypePanel
        '
        Me.HeadGageTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HeadGageTypePanel.Controls.Add(Me.VerticalHeadGageButton)
        Me.HeadGageTypePanel.Controls.Add(Me.SlopedHeadGageButton)
        resources.ApplyResources(Me.HeadGageTypePanel, "HeadGageTypePanel")
        Me.HeadGageTypePanel.Name = "HeadGageTypePanel"
        '
        'VerticalHeadGageButton
        '
        resources.ApplyResources(Me.VerticalHeadGageButton, "VerticalHeadGageButton")
        Me.VerticalHeadGageButton.Label = ""
        Me.VerticalHeadGageButton.Name = "VerticalHeadGageButton"
        Me.VerticalHeadGageButton.RbValue = -1
        Me.VerticalHeadGageButton.TabStop = True
        Me.VerticalHeadGageButton.UiValue = -1
        Me.VerticalHeadGageButton.UseVisualStyleBackColor = True
        '
        'SlopedHeadGageButton
        '
        resources.ApplyResources(Me.SlopedHeadGageButton, "SlopedHeadGageButton")
        Me.SlopedHeadGageButton.Label = ""
        Me.SlopedHeadGageButton.Name = "SlopedHeadGageButton"
        Me.SlopedHeadGageButton.RbValue = -1
        Me.SlopedHeadGageButton.TabStop = True
        Me.SlopedHeadGageButton.UiValue = -1
        Me.SlopedHeadGageButton.UseVisualStyleBackColor = True
        '
        'PrintWallGageDialog
        '
        Me.PrintWallGageDialog.UseEXDialog = True
        '
        'PrintWallGageDocument
        '
        '
        'WallGagePlotsControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.FixedDischargeIntervalBox)
        Me.Controls.Add(Me.FixedHeadIntervalBox)
        Me.Name = "WallGagePlotsControl"
        Me.FixedDischargeIntervalBox.ResumeLayout(False)
        Me.FixedDischargeGagePanel.ResumeLayout(False)
        CType(Me.FixedDischargeGagePlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FixedDischargeControlPanel.ResumeLayout(False)
        Me.FixedDischargeControlPanel.PerformLayout()
        CType(Me.DischargeFirstLabelOffsetControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DischargeDecimalsToShowControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DischargeLabelSizeFactorUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DischargeGageTypePanel.ResumeLayout(False)
        Me.DischargeGageTypePanel.PerformLayout()
        Me.FixedHeadIntervalBox.ResumeLayout(False)
        Me.FixedHeadPlotPanel.ResumeLayout(False)
        Me.FixedHeadGagePanel.ResumeLayout(False)
        CType(Me.FixedHeadGagePlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FixedHeadControlPanel.ResumeLayout(False)
        Me.FixedHeadControlPanel.PerformLayout()
        CType(Me.HeadFirstLabelOffsetControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LabelsTypePanel.ResumeLayout(False)
        Me.LabelsTypePanel.PerformLayout()
        CType(Me.HeadDecimalsToShowControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HeadLabelSizeFactorUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeadGageTypePanel.ResumeLayout(False)
        Me.HeadGageTypePanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FixedHeadIntervalBox As ctl_GroupBox
    Friend WithEvents FixedDischargeIntervalBox As ctl_GroupBox
    Friend WithEvents FixedHeadControlPanel As ctl_Panel
    Friend WithEvents FixedHeadPlotPanel As ctl_Panel
    Friend WithEvents FixedHeadGagePanel As ctl_Panel
    Friend WithEvents FixedHeadGagePlot As ctl_Canvas2D
    Friend WithEvents HeadGageTypePanel As ctl_Panel
    Friend WithEvents VerticalHeadGageButton As ctl_RadioButton
    Friend WithEvents SlopedHeadGageButton As ctl_RadioButton
    Friend WithEvents ViewHeadGageButton As ctl_Button
    Friend WithEvents FixedHeadThumbnailLabel As ctl_Label
    Friend WithEvents HeadLabelSizeFactorUpDown As ctl_SingleUpDown
    Friend WithEvents HeadLabelSizeFactorLabel As ctl_Label
    Friend WithEvents HeadLabeledTickIntervalControl As ctl_ComboBox
    Friend WithEvents HeadLabeledTickIntervalLabel As ctl_Label
    Friend WithEvents HeadDecimalsToShowLabel As ctl_Label
    Friend WithEvents HeadDecimalsToShowControl As ctl_SingleUpDown
    Friend WithEvents HeadFirstLabelOffsetLabel As ctl_Label
    Friend WithEvents HeadFirstLabelOffsetControl As ctl_SingleUpDown
    Friend WithEvents LabelsTypePanel As ctl_Panel
    Friend WithEvents FlowLabelsButton As ctl_RadioButton
    Friend WithEvents HeadLabelsButton As ctl_RadioButton
    Friend WithEvents FixedDischargeControlPanel As ctl_Panel
    Friend WithEvents DischargeFirstLabelOffsetLabel As ctl_Label
    Friend WithEvents DischargeFirstLabelOffsetControl As ctl_SingleUpDown
    Friend WithEvents DischargeDecimalsToShowLabel As ctl_Label
    Friend WithEvents DischargeDecimalsToShowControl As ctl_SingleUpDown
    Friend WithEvents DischargeLabeledTickIntervalControl As ctl_ComboBox
    Friend WithEvents DischargeLabeledTickIntervalLabel As ctl_Label
    Friend WithEvents DischargeLabelSizeFactorLabel As ctl_Label
    Friend WithEvents DischargeLabelSizeFactorUpDown As ctl_SingleUpDown
    Friend WithEvents ViewDischargeGageButton As ctl_Button
    Friend WithEvents DischargeGageTypePanel As ctl_Panel
    Friend WithEvents VerticalDischargeGageButton As ctl_RadioButton
    Friend WithEvents SlopedDischargeGageButton As ctl_RadioButton
    Friend WithEvents FixedDischargeGagePanel As ctl_Panel
    Friend WithEvents FixedDischargeThumbnailLabel As ctl_Label
    Friend WithEvents FixedDischargeGagePlot As ctl_Canvas2D
    Friend WithEvents PrintWallGageDialog As PrintDialog
    Friend WithEvents PrintWallGageDocument As Printing.PrintDocument
End Class
