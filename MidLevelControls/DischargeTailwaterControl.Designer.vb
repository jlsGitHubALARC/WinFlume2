<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DischargeTailwaterControl
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
        Me.TailwaterCalculationsBox = New WinFlume.ctl_GroupBox()
        Me.TailwaterBasisPanel = New WinFlume.ctl_Panel()
        Me.TailwaterMethod = New WinFlume.ctl_ComboBox()
        Me.TailwaterMethodLabel = New WinFlume.ctl_Label()
        Me.FlumeOperationRangeBox = New WinFlume.ctl_GroupBox()
        Me.MaxTailwaterLevel = New WinFlume.ctl_SingleUnits()
        Me.MaxDischarge = New WinFlume.ctl_SingleUnits()
        Me.MaxFlowLabel = New WinFlume.ctl_Label()
        Me.MinTailwaterLevel = New WinFlume.ctl_SingleUnits()
        Me.MinDischarge = New WinFlume.ctl_SingleUnits()
        Me.MinFlowLabel = New WinFlume.ctl_Label()
        Me.TailwaterLevelLabel = New WinFlume.ctl_Label()
        Me.DischargeLabel = New WinFlume.ctl_Label()
        Me.TailwaterCalculationsBox.SuspendLayout()
        Me.FlumeOperationRangeBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'TailwaterCalculationsBox
        '
        Me.TailwaterCalculationsBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TailwaterCalculationsBox.Controls.Add(Me.TailwaterBasisPanel)
        Me.TailwaterCalculationsBox.Controls.Add(Me.TailwaterMethod)
        Me.TailwaterCalculationsBox.Controls.Add(Me.TailwaterMethodLabel)
        Me.TailwaterCalculationsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TailwaterCalculationsBox.Location = New System.Drawing.Point(4, 100)
        Me.TailwaterCalculationsBox.Margin = New System.Windows.Forms.Padding(2)
        Me.TailwaterCalculationsBox.Name = "TailwaterCalculationsBox"
        Me.TailwaterCalculationsBox.Padding = New System.Windows.Forms.Padding(2)
        Me.TailwaterCalculationsBox.Size = New System.Drawing.Size(459, 145)
        Me.TailwaterCalculationsBox.TabIndex = 1
        Me.TailwaterCalculationsBox.TabStop = False
        Me.TailwaterCalculationsBox.Text = "Ta&ilwater Calculations"
        '
        'TailwaterBasisPanel
        '
        Me.TailwaterBasisPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TailwaterBasisPanel.Location = New System.Drawing.Point(4, 47)
        Me.TailwaterBasisPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.TailwaterBasisPanel.Name = "TailwaterBasisPanel"
        Me.TailwaterBasisPanel.Size = New System.Drawing.Size(451, 94)
        Me.TailwaterBasisPanel.TabIndex = 2
        '
        'TailwaterMethod
        '
        Me.TailwaterMethod.BackColor = System.Drawing.SystemColors.Window
        Me.TailwaterMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TailwaterMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TailwaterMethod.FormattingEnabled = True
        Me.TailwaterMethod.Location = New System.Drawing.Point(137, 18)
        Me.TailwaterMethod.Name = "TailwaterMethod"
        Me.TailwaterMethod.Size = New System.Drawing.Size(316, 24)
        Me.TailwaterMethod.TabIndex = 1
        Me.TailwaterMethod.Value = -1
        '
        'TailwaterMethodLabel
        '
        Me.TailwaterMethodLabel.AutoSize = True
        Me.TailwaterMethodLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TailwaterMethodLabel.Location = New System.Drawing.Point(78, 20)
        Me.TailwaterMethodLabel.Name = "TailwaterMethodLabel"
        Me.TailwaterMethodLabel.Size = New System.Drawing.Size(55, 17)
        Me.TailwaterMethodLabel.TabIndex = 0
        Me.TailwaterMethodLabel.Text = "Method"
        Me.TailwaterMethodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlumeOperationRangeBox
        '
        Me.FlumeOperationRangeBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FlumeOperationRangeBox.Controls.Add(Me.MaxTailwaterLevel)
        Me.FlumeOperationRangeBox.Controls.Add(Me.MaxDischarge)
        Me.FlumeOperationRangeBox.Controls.Add(Me.MaxFlowLabel)
        Me.FlumeOperationRangeBox.Controls.Add(Me.MinTailwaterLevel)
        Me.FlumeOperationRangeBox.Controls.Add(Me.MinDischarge)
        Me.FlumeOperationRangeBox.Controls.Add(Me.MinFlowLabel)
        Me.FlumeOperationRangeBox.Controls.Add(Me.TailwaterLevelLabel)
        Me.FlumeOperationRangeBox.Controls.Add(Me.DischargeLabel)
        Me.FlumeOperationRangeBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlumeOperationRangeBox.Location = New System.Drawing.Point(4, 4)
        Me.FlumeOperationRangeBox.Name = "FlumeOperationRangeBox"
        Me.FlumeOperationRangeBox.Size = New System.Drawing.Size(459, 90)
        Me.FlumeOperationRangeBox.TabIndex = 0
        Me.FlumeOperationRangeBox.TabStop = False
        Me.FlumeOperationRangeBox.Text = "&Range of Flume Operation"
        '
        'MaxTailwaterLevel
        '
        Me.MaxTailwaterLevel.AutoSize = True
        Me.MaxTailwaterLevel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MaxTailwaterLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxTailwaterLevel.FormatStyle = "0.0###"
        Me.MaxTailwaterLevel.Label = "Single Value"
        Me.MaxTailwaterLevel.Location = New System.Drawing.Point(358, 56)
        Me.MaxTailwaterLevel.Margin = New System.Windows.Forms.Padding(2)
        Me.MaxTailwaterLevel.Name = "MaxTailwaterLevel"
        Me.MaxTailwaterLevel.SiMin = -1.401298E-45!
        Me.MaxTailwaterLevel.SiUnits = "m"
        Me.MaxTailwaterLevel.SiValue = 0!
        Me.MaxTailwaterLevel.Size = New System.Drawing.Size(96, 27)
        Me.MaxTailwaterLevel.TabIndex = 7
        '
        'MaxDischarge
        '
        Me.MaxDischarge.AutoSize = True
        Me.MaxDischarge.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MaxDischarge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxDischarge.FormatStyle = "0.0###"
        Me.MaxDischarge.Label = "Single Value"
        Me.MaxDischarge.Location = New System.Drawing.Point(225, 56)
        Me.MaxDischarge.Margin = New System.Windows.Forms.Padding(2)
        Me.MaxDischarge.Name = "MaxDischarge"
        Me.MaxDischarge.SiMin = -1.401298E-45!
        Me.MaxDischarge.SiUnits = "cms"
        Me.MaxDischarge.SiValue = 0!
        Me.MaxDischarge.Size = New System.Drawing.Size(96, 27)
        Me.MaxDischarge.TabIndex = 6
        '
        'MaxFlowLabel
        '
        Me.MaxFlowLabel.AutoSize = True
        Me.MaxFlowLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxFlowLabel.Location = New System.Drawing.Point(23, 61)
        Me.MaxFlowLabel.Name = "MaxFlowLabel"
        Me.MaxFlowLabel.Size = New System.Drawing.Size(201, 17)
        Me.MaxFlowLabel.TabIndex = 5
        Me.MaxFlowLabel.Text = "Maximum Flow to be Measured"
        Me.MaxFlowLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MinTailwaterLevel
        '
        Me.MinTailwaterLevel.AutoSize = True
        Me.MinTailwaterLevel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinTailwaterLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinTailwaterLevel.FormatStyle = "0.0###"
        Me.MinTailwaterLevel.Label = "Single Value"
        Me.MinTailwaterLevel.Location = New System.Drawing.Point(358, 31)
        Me.MinTailwaterLevel.Margin = New System.Windows.Forms.Padding(2)
        Me.MinTailwaterLevel.Name = "MinTailwaterLevel"
        Me.MinTailwaterLevel.SiMin = -1.401298E-45!
        Me.MinTailwaterLevel.SiUnits = "m"
        Me.MinTailwaterLevel.SiValue = 0!
        Me.MinTailwaterLevel.Size = New System.Drawing.Size(96, 27)
        Me.MinTailwaterLevel.TabIndex = 4
        '
        'MinDischarge
        '
        Me.MinDischarge.AutoSize = True
        Me.MinDischarge.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinDischarge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinDischarge.FormatStyle = "0.0###"
        Me.MinDischarge.Label = "Single Value"
        Me.MinDischarge.Location = New System.Drawing.Point(225, 31)
        Me.MinDischarge.Margin = New System.Windows.Forms.Padding(2)
        Me.MinDischarge.Name = "MinDischarge"
        Me.MinDischarge.SiMin = -1.401298E-45!
        Me.MinDischarge.SiUnits = "cms"
        Me.MinDischarge.SiValue = 0!
        Me.MinDischarge.Size = New System.Drawing.Size(96, 27)
        Me.MinDischarge.TabIndex = 3
        '
        'MinFlowLabel
        '
        Me.MinFlowLabel.AutoSize = True
        Me.MinFlowLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinFlowLabel.Location = New System.Drawing.Point(26, 36)
        Me.MinFlowLabel.Name = "MinFlowLabel"
        Me.MinFlowLabel.Size = New System.Drawing.Size(198, 17)
        Me.MinFlowLabel.TabIndex = 2
        Me.MinFlowLabel.Text = "Minimum Flow to be Measured"
        Me.MinFlowLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TailwaterLevelLabel
        '
        Me.TailwaterLevelLabel.AutoSize = True
        Me.TailwaterLevelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TailwaterLevelLabel.Location = New System.Drawing.Point(328, 12)
        Me.TailwaterLevelLabel.Name = "TailwaterLevelLabel"
        Me.TailwaterLevelLabel.Size = New System.Drawing.Size(126, 17)
        Me.TailwaterLevelLabel.TabIndex = 1
        Me.TailwaterLevelLabel.Text = "Tailwater Level, y2"
        '
        'DischargeLabel
        '
        Me.DischargeLabel.AutoSize = True
        Me.DischargeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DischargeLabel.Location = New System.Drawing.Point(225, 12)
        Me.DischargeLabel.Name = "DischargeLabel"
        Me.DischargeLabel.Size = New System.Drawing.Size(72, 17)
        Me.DischargeLabel.TabIndex = 0
        Me.DischargeLabel.Text = "Discharge"
        '
        'DischargeTailwaterControl
        '
        Me.AccessibleDescription = "Define the range of flume operation and the tailwater calculation method"
        Me.AccessibleName = "Discharge and Tailwater"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.TailwaterCalculationsBox)
        Me.Controls.Add(Me.FlumeOperationRangeBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "DischargeTailwaterControl"
        Me.Size = New System.Drawing.Size(466, 248)
        Me.TailwaterCalculationsBox.ResumeLayout(False)
        Me.TailwaterCalculationsBox.PerformLayout()
        Me.FlumeOperationRangeBox.ResumeLayout(False)
        Me.FlumeOperationRangeBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlumeOperationRangeBox As WinFlume.ctl_GroupBox
    Friend WithEvents TailwaterCalculationsBox As WinFlume.ctl_GroupBox
    Friend WithEvents MinDischarge As WinFlume.ctl_SingleUnits
    Friend WithEvents MinFlowLabel As WinFlume.ctl_Label
    Friend WithEvents TailwaterLevelLabel As WinFlume.ctl_Label
    Friend WithEvents DischargeLabel As WinFlume.ctl_Label
    Friend WithEvents MinTailwaterLevel As WinFlume.ctl_SingleUnits
    Friend WithEvents MaxTailwaterLevel As WinFlume.ctl_SingleUnits
    Friend WithEvents MaxDischarge As WinFlume.ctl_SingleUnits
    Friend WithEvents MaxFlowLabel As WinFlume.ctl_Label
    Friend WithEvents TailwaterMethod As WinFlume.ctl_ComboBox
    Friend WithEvents TailwaterMethodLabel As WinFlume.ctl_Label
    Friend WithEvents TailwaterBasisPanel As WinFlume.ctl_Panel

End Class
