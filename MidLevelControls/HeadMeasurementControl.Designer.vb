<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HeadMeasurementControl
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
        Me.TotalizingAveragingBox = New WinFlume.ctl_GroupBox()
        Me.DurationUnits = New WinFlume.ctl_ComboBox()
        Me.MeasurementIntervalUnits = New WinFlume.ctl_ComboBox()
        Me.Duration = New WinFlume.ctl_Single()
        Me.MeasurementInterval = New WinFlume.ctl_Single()
        Me.DurationLabel = New WinFlume.ctl_Label()
        Me.MeasurementIntervalLabel = New WinFlume.ctl_Label()
        Me.MeasurementUncertaintyBox = New WinFlume.ctl_GroupBox()
        Me.NoteLabel = New WinFlume.ctl_Label()
        Me.AtMaximumFlow = New WinFlume.ctl_SingleUnits()
        Me.AtMinimumFlow = New WinFlume.ctl_SingleUnits()
        Me.AtMaximumFlowLabel = New WinFlume.ctl_Label()
        Me.AtMinimumFlowLabel = New WinFlume.ctl_Label()
        Me.HeadMeasurementMethodGroup = New WinFlume.ctl_GroupBox()
        Me.CustomExpectedUncertainty = New WinFlume.ctl_Single6Units()
        Me.StandardExpectedUncertainty = New WinFlume.ctl_Single6Units()
        Me.CustomMethodTextBox = New WinFlume.ctl_TextBox()
        Me.CustomButton = New WinFlume.ctl_RadioButton()
        Me.StandardButton = New WinFlume.ctl_RadioButton()
        Me.StandardMethodComboBox = New WinFlume.ctl_ComboBox()
        Me.UncertaintyLabel = New WinFlume.ctl_Label()
        Me.TotalizingAveragingBox.SuspendLayout()
        Me.MeasurementUncertaintyBox.SuspendLayout()
        Me.HeadMeasurementMethodGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'TotalizingAveragingBox
        '
        Me.TotalizingAveragingBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TotalizingAveragingBox.Controls.Add(Me.DurationUnits)
        Me.TotalizingAveragingBox.Controls.Add(Me.MeasurementIntervalUnits)
        Me.TotalizingAveragingBox.Controls.Add(Me.Duration)
        Me.TotalizingAveragingBox.Controls.Add(Me.MeasurementInterval)
        Me.TotalizingAveragingBox.Controls.Add(Me.DurationLabel)
        Me.TotalizingAveragingBox.Controls.Add(Me.MeasurementIntervalLabel)
        Me.TotalizingAveragingBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalizingAveragingBox.Location = New System.Drawing.Point(3, 174)
        Me.TotalizingAveragingBox.Name = "TotalizingAveragingBox"
        Me.TotalizingAveragingBox.Size = New System.Drawing.Size(460, 72)
        Me.TotalizingAveragingBox.TabIndex = 2
        Me.TotalizingAveragingBox.TabStop = False
        Me.TotalizingAveragingBox.Text = "Totali&zing or Averaging"
        '
        'DurationUnits
        '
        Me.DurationUnits.BackColor = System.Drawing.SystemColors.Window
        Me.DurationUnits.DefaultValue = 0
        Me.DurationUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DurationUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DurationUnits.FormattingEnabled = True
        Me.DurationUnits.Location = New System.Drawing.Point(235, 18)
        Me.DurationUnits.Name = "DurationUnits"
        Me.DurationUnits.Size = New System.Drawing.Size(121, 24)
        Me.DurationUnits.TabIndex = 2
        Me.DurationUnits.UndoEnabled = True
        Me.DurationUnits.Value = -1
        '
        'MeasurementIntervalUnits
        '
        Me.MeasurementIntervalUnits.BackColor = System.Drawing.SystemColors.Window
        Me.MeasurementIntervalUnits.DefaultValue = 0
        Me.MeasurementIntervalUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MeasurementIntervalUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MeasurementIntervalUnits.FormattingEnabled = True
        Me.MeasurementIntervalUnits.Location = New System.Drawing.Point(235, 42)
        Me.MeasurementIntervalUnits.Name = "MeasurementIntervalUnits"
        Me.MeasurementIntervalUnits.Size = New System.Drawing.Size(121, 24)
        Me.MeasurementIntervalUnits.TabIndex = 5
        Me.MeasurementIntervalUnits.UndoEnabled = True
        Me.MeasurementIntervalUnits.Value = -1
        '
        'Duration
        '
        Me.Duration.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Duration.FormatStyle = "0.0###"
        Me.Duration.IsReadOnly = False
        Me.Duration.Label = "Single Value"
        Me.Duration.Location = New System.Drawing.Point(170, 19)
        Me.Duration.Margin = New System.Windows.Forms.Padding(2)
        Me.Duration.Name = "Duration"
        Me.Duration.ReadOnlyMsgBox = Nothing
        Me.Duration.SiDefaultValue = 0!
        Me.Duration.SiMin = -1.401298E-45!
        Me.Duration.SiValue = 0!
        Me.Duration.Size = New System.Drawing.Size(59, 27)
        Me.Duration.TabIndex = 1
        Me.Duration.UiValue = 0!
        Me.Duration.UndoEnabled = True
        '
        'MeasurementInterval
        '
        Me.MeasurementInterval.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MeasurementInterval.FormatStyle = "0.0###"
        Me.MeasurementInterval.IsReadOnly = False
        Me.MeasurementInterval.Label = "Single Value"
        Me.MeasurementInterval.Location = New System.Drawing.Point(170, 43)
        Me.MeasurementInterval.Margin = New System.Windows.Forms.Padding(2)
        Me.MeasurementInterval.Name = "MeasurementInterval"
        Me.MeasurementInterval.ReadOnlyMsgBox = Nothing
        Me.MeasurementInterval.SiDefaultValue = 0!
        Me.MeasurementInterval.SiMin = -1.401298E-45!
        Me.MeasurementInterval.SiValue = 0!
        Me.MeasurementInterval.Size = New System.Drawing.Size(59, 27)
        Me.MeasurementInterval.TabIndex = 4
        Me.MeasurementInterval.UiValue = 0!
        Me.MeasurementInterval.UndoEnabled = True
        '
        'DurationLabel
        '
        Me.DurationLabel.AutoSize = True
        Me.DurationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DurationLabel.Location = New System.Drawing.Point(104, 22)
        Me.DurationLabel.Name = "DurationLabel"
        Me.DurationLabel.Size = New System.Drawing.Size(62, 17)
        Me.DurationLabel.TabIndex = 0
        Me.DurationLabel.Text = "Duration"
        Me.DurationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MeasurementIntervalLabel
        '
        Me.MeasurementIntervalLabel.AutoSize = True
        Me.MeasurementIntervalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MeasurementIntervalLabel.Location = New System.Drawing.Point(22, 46)
        Me.MeasurementIntervalLabel.Name = "MeasurementIntervalLabel"
        Me.MeasurementIntervalLabel.Size = New System.Drawing.Size(144, 17)
        Me.MeasurementIntervalLabel.TabIndex = 3
        Me.MeasurementIntervalLabel.Text = "Measurement Interval"
        Me.MeasurementIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MeasurementUncertaintyBox
        '
        Me.MeasurementUncertaintyBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MeasurementUncertaintyBox.Controls.Add(Me.NoteLabel)
        Me.MeasurementUncertaintyBox.Controls.Add(Me.AtMaximumFlow)
        Me.MeasurementUncertaintyBox.Controls.Add(Me.AtMinimumFlow)
        Me.MeasurementUncertaintyBox.Controls.Add(Me.AtMaximumFlowLabel)
        Me.MeasurementUncertaintyBox.Controls.Add(Me.AtMinimumFlowLabel)
        Me.MeasurementUncertaintyBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MeasurementUncertaintyBox.Location = New System.Drawing.Point(3, 100)
        Me.MeasurementUncertaintyBox.Name = "MeasurementUncertaintyBox"
        Me.MeasurementUncertaintyBox.Size = New System.Drawing.Size(460, 70)
        Me.MeasurementUncertaintyBox.TabIndex = 1
        Me.MeasurementUncertaintyBox.TabStop = False
        Me.MeasurementUncertaintyBox.Text = "Allowa&ble Flow Measurement Uncertainty"
        '
        'NoteLabel
        '
        Me.NoteLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoteLabel.Location = New System.Drawing.Point(305, 18)
        Me.NoteLabel.Name = "NoteLabel"
        Me.NoteLabel.Size = New System.Drawing.Size(149, 43)
        Me.NoteLabel.TabIndex = 4
        Me.NoteLabel.Text = "95% uncertainty of a single measurement"
        Me.NoteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AtMaximumFlow
        '
        Me.AtMaximumFlow.AutoSize = True
        Me.AtMaximumFlow.BackColor = System.Drawing.SystemColors.ControlLight
        Me.AtMaximumFlow.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AtMaximumFlow.FormatStyle = "0.0###"
        Me.AtMaximumFlow.IsReadOnly = False
        Me.AtMaximumFlow.Label = "Single Value"
        Me.AtMaximumFlow.Location = New System.Drawing.Point(170, 41)
        Me.AtMaximumFlow.Margin = New System.Windows.Forms.Padding(2)
        Me.AtMaximumFlow.Name = "AtMaximumFlow"
        Me.AtMaximumFlow.ReadOnlyMsgBox = Nothing
        Me.AtMaximumFlow.SiDefaultValue = 0!
        Me.AtMaximumFlow.SiMin = -1.401298E-45!
        Me.AtMaximumFlow.SiUnits = "%"
        Me.AtMaximumFlow.SiValue = 0!
        Me.AtMaximumFlow.Size = New System.Drawing.Size(83, 27)
        Me.AtMaximumFlow.TabIndex = 3
        Me.AtMaximumFlow.UndoEnabled = True
        '
        'AtMinimumFlow
        '
        Me.AtMinimumFlow.AutoSize = True
        Me.AtMinimumFlow.BackColor = System.Drawing.SystemColors.ControlLight
        Me.AtMinimumFlow.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AtMinimumFlow.FormatStyle = "0.0###"
        Me.AtMinimumFlow.IsReadOnly = False
        Me.AtMinimumFlow.Label = "Single Value"
        Me.AtMinimumFlow.Location = New System.Drawing.Point(170, 17)
        Me.AtMinimumFlow.Margin = New System.Windows.Forms.Padding(2)
        Me.AtMinimumFlow.Name = "AtMinimumFlow"
        Me.AtMinimumFlow.ReadOnlyMsgBox = Nothing
        Me.AtMinimumFlow.SiDefaultValue = 0!
        Me.AtMinimumFlow.SiMin = -1.401298E-45!
        Me.AtMinimumFlow.SiUnits = "%"
        Me.AtMinimumFlow.SiValue = 0!
        Me.AtMinimumFlow.Size = New System.Drawing.Size(83, 27)
        Me.AtMinimumFlow.TabIndex = 2
        Me.AtMinimumFlow.UndoEnabled = True
        '
        'AtMaximumFlowLabel
        '
        Me.AtMaximumFlowLabel.AutoSize = True
        Me.AtMaximumFlowLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AtMaximumFlowLabel.Location = New System.Drawing.Point(49, 44)
        Me.AtMaximumFlowLabel.Name = "AtMaximumFlowLabel"
        Me.AtMaximumFlowLabel.Size = New System.Drawing.Size(115, 17)
        Me.AtMaximumFlowLabel.TabIndex = 1
        Me.AtMaximumFlowLabel.Text = "At Maximum Flow"
        Me.AtMaximumFlowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AtMinimumFlowLabel
        '
        Me.AtMinimumFlowLabel.AutoSize = True
        Me.AtMinimumFlowLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AtMinimumFlowLabel.Location = New System.Drawing.Point(52, 22)
        Me.AtMinimumFlowLabel.Name = "AtMinimumFlowLabel"
        Me.AtMinimumFlowLabel.Size = New System.Drawing.Size(112, 17)
        Me.AtMinimumFlowLabel.TabIndex = 0
        Me.AtMinimumFlowLabel.Text = "At Minimum Flow"
        Me.AtMinimumFlowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HeadMeasurementMethodGroup
        '
        Me.HeadMeasurementMethodGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HeadMeasurementMethodGroup.Controls.Add(Me.CustomExpectedUncertainty)
        Me.HeadMeasurementMethodGroup.Controls.Add(Me.StandardExpectedUncertainty)
        Me.HeadMeasurementMethodGroup.Controls.Add(Me.CustomMethodTextBox)
        Me.HeadMeasurementMethodGroup.Controls.Add(Me.CustomButton)
        Me.HeadMeasurementMethodGroup.Controls.Add(Me.StandardButton)
        Me.HeadMeasurementMethodGroup.Controls.Add(Me.StandardMethodComboBox)
        Me.HeadMeasurementMethodGroup.Controls.Add(Me.UncertaintyLabel)
        Me.HeadMeasurementMethodGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.HeadMeasurementMethodGroup.Location = New System.Drawing.Point(3, 3)
        Me.HeadMeasurementMethodGroup.Name = "HeadMeasurementMethodGroup"
        Me.HeadMeasurementMethodGroup.Size = New System.Drawing.Size(460, 92)
        Me.HeadMeasurementMethodGroup.TabIndex = 0
        Me.HeadMeasurementMethodGroup.TabStop = False
        Me.HeadMeasurementMethodGroup.Text = "Head Measurement &Method"
        '
        'CustomExpectedUncertainty
        '
        Me.CustomExpectedUncertainty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CustomExpectedUncertainty.FormatStyle = "0.0#####"
        Me.CustomExpectedUncertainty.IsReadOnly = False
        Me.CustomExpectedUncertainty.Label = "Single Value"
        Me.CustomExpectedUncertainty.Location = New System.Drawing.Point(354, 61)
        Me.CustomExpectedUncertainty.Margin = New System.Windows.Forms.Padding(2)
        Me.CustomExpectedUncertainty.Name = "CustomExpectedUncertainty"
        Me.CustomExpectedUncertainty.ReadOnlyMsgBox = Nothing
        Me.CustomExpectedUncertainty.SiDefaultValue = 0!
        Me.CustomExpectedUncertainty.SiMin = -1.401298E-45!
        Me.CustomExpectedUncertainty.SiUnits = "m"
        Me.CustomExpectedUncertainty.SiValue = 0!
        Me.CustomExpectedUncertainty.Size = New System.Drawing.Size(100, 27)
        Me.CustomExpectedUncertainty.TabIndex = 6
        Me.CustomExpectedUncertainty.UndoEnabled = True
        '
        'StandardExpectedUncertainty
        '
        Me.StandardExpectedUncertainty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.StandardExpectedUncertainty.FormatStyle = "0.0#####"
        Me.StandardExpectedUncertainty.IsReadOnly = False
        Me.StandardExpectedUncertainty.Label = "Single Value"
        Me.StandardExpectedUncertainty.Location = New System.Drawing.Point(354, 35)
        Me.StandardExpectedUncertainty.Margin = New System.Windows.Forms.Padding(2)
        Me.StandardExpectedUncertainty.Name = "StandardExpectedUncertainty"
        Me.StandardExpectedUncertainty.ReadOnlyMsgBox = Nothing
        Me.StandardExpectedUncertainty.SiDefaultValue = 0!
        Me.StandardExpectedUncertainty.SiMin = -1.401298E-45!
        Me.StandardExpectedUncertainty.SiUnits = "m"
        Me.StandardExpectedUncertainty.SiValue = 0!
        Me.StandardExpectedUncertainty.Size = New System.Drawing.Size(100, 27)
        Me.StandardExpectedUncertainty.TabIndex = 5
        Me.StandardExpectedUncertainty.UndoEnabled = True
        '
        'CustomMethodTextBox
        '
        Me.CustomMethodTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CustomMethodTextBox.Label = ""
        Me.CustomMethodTextBox.Location = New System.Drawing.Point(95, 64)
        Me.CustomMethodTextBox.Name = "CustomMethodTextBox"
        Me.CustomMethodTextBox.Size = New System.Drawing.Size(254, 23)
        Me.CustomMethodTextBox.TabIndex = 3
        Me.CustomMethodTextBox.Value = ""
        '
        'CustomButton
        '
        Me.CustomButton.AutoSize = True
        Me.CustomButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CustomButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CustomButton.Label = ""
        Me.CustomButton.Location = New System.Drawing.Point(7, 66)
        Me.CustomButton.Name = "CustomButton"
        Me.CustomButton.RbValue = -1
        Me.CustomButton.Size = New System.Drawing.Size(73, 21)
        Me.CustomButton.TabIndex = 1
        Me.CustomButton.Text = "Custom"
        Me.CustomButton.UiValue = -1
        Me.CustomButton.UseVisualStyleBackColor = True
        '
        'StandardButton
        '
        Me.StandardButton.AutoSize = True
        Me.StandardButton.Checked = True
        Me.StandardButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.StandardButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.StandardButton.Label = ""
        Me.StandardButton.Location = New System.Drawing.Point(7, 37)
        Me.StandardButton.Name = "StandardButton"
        Me.StandardButton.RbValue = -1
        Me.StandardButton.Size = New System.Drawing.Size(84, 21)
        Me.StandardButton.TabIndex = 0
        Me.StandardButton.TabStop = True
        Me.StandardButton.Text = "Standard"
        Me.StandardButton.UiValue = -1
        Me.StandardButton.UseVisualStyleBackColor = True
        '
        'StandardMethodComboBox
        '
        Me.StandardMethodComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.StandardMethodComboBox.DefaultValue = 0
        Me.StandardMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StandardMethodComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.StandardMethodComboBox.FormattingEnabled = True
        Me.StandardMethodComboBox.Location = New System.Drawing.Point(95, 37)
        Me.StandardMethodComboBox.Name = "StandardMethodComboBox"
        Me.StandardMethodComboBox.Size = New System.Drawing.Size(254, 24)
        Me.StandardMethodComboBox.TabIndex = 2
        Me.StandardMethodComboBox.UndoEnabled = True
        Me.StandardMethodComboBox.Value = -1
        '
        'UncertaintyLabel
        '
        Me.UncertaintyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.UncertaintyLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UncertaintyLabel.Location = New System.Drawing.Point(328, 13)
        Me.UncertaintyLabel.Name = "UncertaintyLabel"
        Me.UncertaintyLabel.Size = New System.Drawing.Size(120, 19)
        Me.UncertaintyLabel.TabIndex = 4
        Me.UncertaintyLabel.Text = "Uncertainty"
        Me.UncertaintyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HeadMeasurementControl
        '
        Me.AccessibleDescription = "Define the head measurement method and parameters"
        Me.AccessibleName = "Head Measurement"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.TotalizingAveragingBox)
        Me.Controls.Add(Me.MeasurementUncertaintyBox)
        Me.Controls.Add(Me.HeadMeasurementMethodGroup)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "HeadMeasurementControl"
        Me.Size = New System.Drawing.Size(466, 248)
        Me.TotalizingAveragingBox.ResumeLayout(False)
        Me.TotalizingAveragingBox.PerformLayout()
        Me.MeasurementUncertaintyBox.ResumeLayout(False)
        Me.MeasurementUncertaintyBox.PerformLayout()
        Me.HeadMeasurementMethodGroup.ResumeLayout(False)
        Me.HeadMeasurementMethodGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HeadMeasurementMethodGroup As WinFlume.ctl_GroupBox
    Friend WithEvents CustomExpectedUncertainty As WinFlume.ctl_Single6Units
    Friend WithEvents StandardExpectedUncertainty As WinFlume.ctl_Single6Units
    Friend WithEvents CustomMethodTextBox As WinFlume.ctl_TextBox
    Friend WithEvents CustomButton As WinFlume.ctl_RadioButton
    Friend WithEvents StandardButton As WinFlume.ctl_RadioButton
    Friend WithEvents StandardMethodComboBox As WinFlume.ctl_ComboBox
    Friend WithEvents UncertaintyLabel As WinFlume.ctl_Label
    Friend WithEvents MeasurementUncertaintyBox As WinFlume.ctl_GroupBox
    Friend WithEvents AtMaximumFlowLabel As WinFlume.ctl_Label
    Friend WithEvents AtMinimumFlowLabel As WinFlume.ctl_Label
    Friend WithEvents AtMaximumFlow As WinFlume.ctl_SingleUnits
    Friend WithEvents AtMinimumFlow As WinFlume.ctl_SingleUnits
    Friend WithEvents NoteLabel As WinFlume.ctl_Label
    Friend WithEvents TotalizingAveragingBox As WinFlume.ctl_GroupBox
    Friend WithEvents DurationLabel As WinFlume.ctl_Label
    Friend WithEvents MeasurementIntervalLabel As WinFlume.ctl_Label
    Friend WithEvents Duration As WinFlume.ctl_Single
    Friend WithEvents MeasurementInterval As WinFlume.ctl_Single
    Friend WithEvents DurationUnits As WinFlume.ctl_ComboBox
    Friend WithEvents MeasurementIntervalUnits As WinFlume.ctl_ComboBox

End Class
