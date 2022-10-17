<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FixedDischargePlotControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FixedDischargePlotControl))
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
        Me.DischargeFirstLabelOffsetControl.UndoEnabled = True
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
        Me.DischargeDecimalsToShowControl.UndoEnabled = True
        '
        'DischargeLabeledTickIntervalControl
        '
        Me.DischargeLabeledTickIntervalControl.BackColor = System.Drawing.SystemColors.Window
        Me.DischargeLabeledTickIntervalControl.DefaultValue = 0
        Me.DischargeLabeledTickIntervalControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.DischargeLabeledTickIntervalControl, "DischargeLabeledTickIntervalControl")
        Me.DischargeLabeledTickIntervalControl.FormattingEnabled = True
        Me.DischargeLabeledTickIntervalControl.Items.AddRange(New Object() {resources.GetString("DischargeLabeledTickIntervalControl.Items"), resources.GetString("DischargeLabeledTickIntervalControl.Items1"), resources.GetString("DischargeLabeledTickIntervalControl.Items2"), resources.GetString("DischargeLabeledTickIntervalControl.Items3"), resources.GetString("DischargeLabeledTickIntervalControl.Items4")})
        Me.DischargeLabeledTickIntervalControl.Name = "DischargeLabeledTickIntervalControl"
        Me.DischargeLabeledTickIntervalControl.UndoEnabled = True
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
        Me.DischargeLabelSizeFactorUpDown.UndoEnabled = True
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
        'PrintWallGageDialog
        '
        Me.PrintWallGageDialog.UseEXDialog = True
        '
        'PrintWallGageDocument
        '
        '
        'FixedDischargePlotControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.FixedDischargeIntervalBox)
        Me.Name = "FixedDischargePlotControl"
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FixedDischargeIntervalBox As ctl_GroupBox
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
