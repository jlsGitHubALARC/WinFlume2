<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BasisPower2QHControl
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
        Me.TailwaterLevel2 = New WinFlume.ctl_SingleUnits
        Me.Discharge2 = New WinFlume.ctl_SingleUnits
        Me.FlowCondition2Label = New WinFlume.ctl_Label
        Me.HelpLabel = New WinFlume.ctl_Label
        Me.TailwaterLevel1 = New WinFlume.ctl_SingleUnits
        Me.Discharge1 = New WinFlume.ctl_SingleUnits
        Me.FlowCondition1Label = New WinFlume.ctl_Label
        Me.TailwaterLevel0 = New WinFlume.ctl_SingleUnits
        Me.Discharge0 = New WinFlume.ctl_SingleUnits
        Me.FlowCondition0Label = New WinFlume.ctl_Label
        Me.TailwaterLevelLabel = New WinFlume.ctl_Label
        Me.DischargeLabel = New WinFlume.ctl_Label
        Me.SuspendLayout()
        '
        'TailwaterLevel2
        '
        Me.TailwaterLevel2.AutoSize = True
        Me.TailwaterLevel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TailwaterLevel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TailwaterLevel2.FormatStyle = "0.0###"
        Me.TailwaterLevel2.Label = "Single Value"
        Me.TailwaterLevel2.Location = New System.Drawing.Point(347, 71)
        Me.TailwaterLevel2.Margin = New System.Windows.Forms.Padding(2)
        Me.TailwaterLevel2.Name = "TailwaterLevel2"
        Me.TailwaterLevel2.SiUnits = "m"
        Me.TailwaterLevel2.SiValue = 0.0!
        Me.TailwaterLevel2.Size = New System.Drawing.Size(96, 23)
        Me.TailwaterLevel2.TabIndex = 30
        '
        'Discharge2
        '
        Me.Discharge2.AutoSize = True
        Me.Discharge2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Discharge2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Discharge2.FormatStyle = "0.0###"
        Me.Discharge2.Label = "Single Value"
        Me.Discharge2.Location = New System.Drawing.Point(214, 71)
        Me.Discharge2.Margin = New System.Windows.Forms.Padding(2)
        Me.Discharge2.Name = "Discharge2"
        Me.Discharge2.SiUnits = "cms"
        Me.Discharge2.SiValue = 0.0!
        Me.Discharge2.Size = New System.Drawing.Size(96, 23)
        Me.Discharge2.TabIndex = 29
        '
        'FlowCondition2Label
        '
        Me.FlowCondition2Label.AutoSize = True
        Me.FlowCondition2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowCondition2Label.Location = New System.Drawing.Point(102, 76)
        Me.FlowCondition2Label.Name = "FlowCondition2Label"
        Me.FlowCondition2Label.Size = New System.Drawing.Size(111, 17)
        Me.FlowCondition2Label.TabIndex = 28
        Me.FlowCondition2Label.Text = "Flow Condition 2"
        Me.FlowCondition2Label.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'HelpLabel
        '
        Me.HelpLabel.BackColor = System.Drawing.SystemColors.Info
        Me.HelpLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HelpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpLabel.Location = New System.Drawing.Point(0, 100)
        Me.HelpLabel.Name = "HelpLabel"
        Me.HelpLabel.Size = New System.Drawing.Size(447, 40)
        Me.HelpLabel.TabIndex = 31
        Me.HelpLabel.Text = "Tailwater levels should be specified relative to the invert of the downstream cha" & _
            "nnel"
        Me.HelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TailwaterLevel1
        '
        Me.TailwaterLevel1.AutoSize = True
        Me.TailwaterLevel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TailwaterLevel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TailwaterLevel1.FormatStyle = "0.0###"
        Me.TailwaterLevel1.Label = "Single Value"
        Me.TailwaterLevel1.Location = New System.Drawing.Point(347, 46)
        Me.TailwaterLevel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TailwaterLevel1.Name = "TailwaterLevel1"
        Me.TailwaterLevel1.SiUnits = "m"
        Me.TailwaterLevel1.SiValue = 0.0!
        Me.TailwaterLevel1.Size = New System.Drawing.Size(96, 27)
        Me.TailwaterLevel1.TabIndex = 27
        '
        'Discharge1
        '
        Me.Discharge1.AutoSize = True
        Me.Discharge1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Discharge1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Discharge1.FormatStyle = "0.0###"
        Me.Discharge1.Label = "Single Value"
        Me.Discharge1.Location = New System.Drawing.Point(214, 46)
        Me.Discharge1.Margin = New System.Windows.Forms.Padding(2)
        Me.Discharge1.Name = "Discharge1"
        Me.Discharge1.SiUnits = "cms"
        Me.Discharge1.SiValue = 0.0!
        Me.Discharge1.Size = New System.Drawing.Size(96, 27)
        Me.Discharge1.TabIndex = 26
        '
        'FlowCondition1Label
        '
        Me.FlowCondition1Label.AutoSize = True
        Me.FlowCondition1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowCondition1Label.Location = New System.Drawing.Point(102, 51)
        Me.FlowCondition1Label.Name = "FlowCondition1Label"
        Me.FlowCondition1Label.Size = New System.Drawing.Size(111, 17)
        Me.FlowCondition1Label.TabIndex = 25
        Me.FlowCondition1Label.Text = "Flow Condition 1"
        Me.FlowCondition1Label.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TailwaterLevel0
        '
        Me.TailwaterLevel0.AutoSize = True
        Me.TailwaterLevel0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TailwaterLevel0.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TailwaterLevel0.FormatStyle = "0.0###"
        Me.TailwaterLevel0.Label = "Single Value"
        Me.TailwaterLevel0.Location = New System.Drawing.Point(347, 21)
        Me.TailwaterLevel0.Margin = New System.Windows.Forms.Padding(2)
        Me.TailwaterLevel0.Name = "TailwaterLevel0"
        Me.TailwaterLevel0.SiUnits = "m"
        Me.TailwaterLevel0.SiValue = 0.0!
        Me.TailwaterLevel0.Size = New System.Drawing.Size(96, 27)
        Me.TailwaterLevel0.TabIndex = 24
        '
        'Discharge0
        '
        Me.Discharge0.AutoSize = True
        Me.Discharge0.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Discharge0.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Discharge0.FormatStyle = "0.0###"
        Me.Discharge0.Label = "Single Value"
        Me.Discharge0.Location = New System.Drawing.Point(214, 21)
        Me.Discharge0.Margin = New System.Windows.Forms.Padding(2)
        Me.Discharge0.Name = "Discharge0"
        Me.Discharge0.SiUnits = "cms"
        Me.Discharge0.SiValue = 0.0!
        Me.Discharge0.Size = New System.Drawing.Size(96, 27)
        Me.Discharge0.TabIndex = 23
        '
        'FlowCondition0Label
        '
        Me.FlowCondition0Label.AutoSize = True
        Me.FlowCondition0Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowCondition0Label.Location = New System.Drawing.Point(43, 26)
        Me.FlowCondition0Label.Name = "FlowCondition0Label"
        Me.FlowCondition0Label.Size = New System.Drawing.Size(169, 17)
        Me.FlowCondition0Label.TabIndex = 22
        Me.FlowCondition0Label.Text = "Flow Condition 0 (implied)"
        Me.FlowCondition0Label.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TailwaterLevelLabel
        '
        Me.TailwaterLevelLabel.AutoSize = True
        Me.TailwaterLevelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TailwaterLevelLabel.Location = New System.Drawing.Point(317, 2)
        Me.TailwaterLevelLabel.Name = "TailwaterLevelLabel"
        Me.TailwaterLevelLabel.Size = New System.Drawing.Size(126, 17)
        Me.TailwaterLevelLabel.TabIndex = 21
        Me.TailwaterLevelLabel.Text = "Tailwater Level, y2"
        '
        'DischargeLabel
        '
        Me.DischargeLabel.AutoSize = True
        Me.DischargeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DischargeLabel.Location = New System.Drawing.Point(212, 2)
        Me.DischargeLabel.Name = "DischargeLabel"
        Me.DischargeLabel.Size = New System.Drawing.Size(72, 17)
        Me.DischargeLabel.TabIndex = 20
        Me.DischargeLabel.Text = "Discharge"
        '
        'BasisPower2QHControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.TailwaterLevel2)
        Me.Controls.Add(Me.Discharge2)
        Me.Controls.Add(Me.FlowCondition2Label)
        Me.Controls.Add(Me.HelpLabel)
        Me.Controls.Add(Me.TailwaterLevel1)
        Me.Controls.Add(Me.Discharge1)
        Me.Controls.Add(Me.FlowCondition1Label)
        Me.Controls.Add(Me.TailwaterLevel0)
        Me.Controls.Add(Me.Discharge0)
        Me.Controls.Add(Me.FlowCondition0Label)
        Me.Controls.Add(Me.TailwaterLevelLabel)
        Me.Controls.Add(Me.DischargeLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "BasisPower2QHControl"
        Me.Size = New System.Drawing.Size(447, 140)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpLabel As WinFlume.ctl_Label
    Friend WithEvents TailwaterLevel1 As WinFlume.ctl_SingleUnits
    Friend WithEvents Discharge1 As WinFlume.ctl_SingleUnits
    Friend WithEvents FlowCondition1Label As WinFlume.ctl_Label
    Friend WithEvents TailwaterLevel0 As WinFlume.ctl_SingleUnits
    Friend WithEvents Discharge0 As WinFlume.ctl_SingleUnits
    Friend WithEvents FlowCondition0Label As WinFlume.ctl_Label
    Friend WithEvents TailwaterLevelLabel As WinFlume.ctl_Label
    Friend WithEvents DischargeLabel As WinFlume.ctl_Label
    Friend WithEvents TailwaterLevel2 As WinFlume.ctl_SingleUnits
    Friend WithEvents Discharge2 As WinFlume.ctl_SingleUnits
    Friend WithEvents FlowCondition2Label As WinFlume.ctl_Label

End Class
