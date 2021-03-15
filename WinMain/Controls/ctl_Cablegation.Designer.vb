<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_Cablegation
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
        Me.TotalInflowLabel = New DataStore.ctl_Label
        Me.TotalInflowControl = New DataStore.ctl_DoubleParameter
        Me.PipeDiameterControl = New DataStore.ctl_DoubleParameter
        Me.PipeDiameterLabel = New DataStore.ctl_Label
        Me.HazenWilliamsControl = New DataStore.ctl_DoubleParameter
        Me.HazenWilleamsLabel = New DataStore.ctl_Label
        Me.PipeSlopeControl = New DataStore.ctl_DoubleParameter
        Me.PipeSlopeLabel = New DataStore.ctl_Label
        Me.EnterOneGroup = New DataStore.ctl_GroupBox
        Me.PeakFlowControl = New DataStore.ctl_DoubleParameter
        Me.PeakFlowButton = New DataStore.ctl_RadioButton
        Me.OrificeEquivalentDiameterControl = New DataStore.ctl_DoubleParameter
        Me.OrificeEquivalentDiameterButton = New DataStore.ctl_RadioButton
        Me.PlugSpeedControl = New DataStore.ctl_DoubleParameter
        Me.PlugSpeedLabel = New DataStore.ctl_Label
        Me.OrificeSpacingControl = New DataStore.ctl_DoubleParameter
        Me.OrificeSpacingLabel = New DataStore.ctl_Label
        Me.CutoffFlowControl = New DataStore.ctl_DoubleParameter
        Me.CutoffFlowLabel = New DataStore.ctl_Label
        Me.EnterOneGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'TotalInflowLabel
        '
        Me.TotalInflowLabel.Location = New System.Drawing.Point(4, 4)
        Me.TotalInflowLabel.Name = "TotalInflowLabel"
        Me.TotalInflowLabel.Size = New System.Drawing.Size(215, 23)
        Me.TotalInflowLabel.TabIndex = 0
        Me.TotalInflowLabel.Text = "&Total Inflow to Cablegation Pipe"
        Me.TotalInflowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TotalInflowControl
        '
        Me.TotalInflowControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.TotalInflowControl.IsCalculated = False
        Me.TotalInflowControl.IsInteger = False
        Me.TotalInflowControl.Location = New System.Drawing.Point(225, 5)
        Me.TotalInflowControl.MaxErrMsg = ""
        Me.TotalInflowControl.MinErrMsg = ""
        Me.TotalInflowControl.Name = "TotalInflowControl"
        Me.TotalInflowControl.Size = New System.Drawing.Size(100, 24)
        Me.TotalInflowControl.TabIndex = 1
        Me.TotalInflowControl.ToBeCalculated = True
        Me.TotalInflowControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.TotalInflowControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.TotalInflowControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.TotalInflowControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.TotalInflowControl.ValueText = ""
        '
        'PipeDiameterControl
        '
        Me.PipeDiameterControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.PipeDiameterControl.IsCalculated = False
        Me.PipeDiameterControl.IsInteger = False
        Me.PipeDiameterControl.Location = New System.Drawing.Point(225, 34)
        Me.PipeDiameterControl.MaxErrMsg = ""
        Me.PipeDiameterControl.MinErrMsg = ""
        Me.PipeDiameterControl.Name = "PipeDiameterControl"
        Me.PipeDiameterControl.Size = New System.Drawing.Size(100, 24)
        Me.PipeDiameterControl.TabIndex = 3
        Me.PipeDiameterControl.ToBeCalculated = True
        Me.PipeDiameterControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.PipeDiameterControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.PipeDiameterControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.PipeDiameterControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.PipeDiameterControl.ValueText = ""
        '
        'PipeDiameterLabel
        '
        Me.PipeDiameterLabel.Location = New System.Drawing.Point(4, 33)
        Me.PipeDiameterLabel.Name = "PipeDiameterLabel"
        Me.PipeDiameterLabel.Size = New System.Drawing.Size(215, 23)
        Me.PipeDiameterLabel.TabIndex = 2
        Me.PipeDiameterLabel.Text = "Pipe &Diameter"
        Me.PipeDiameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HazenWilliamsControl
        '
        Me.HazenWilliamsControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.HazenWilliamsControl.IsCalculated = False
        Me.HazenWilliamsControl.IsInteger = False
        Me.HazenWilliamsControl.Location = New System.Drawing.Point(225, 92)
        Me.HazenWilliamsControl.MaxErrMsg = ""
        Me.HazenWilliamsControl.MinErrMsg = ""
        Me.HazenWilliamsControl.Name = "HazenWilliamsControl"
        Me.HazenWilliamsControl.Size = New System.Drawing.Size(100, 24)
        Me.HazenWilliamsControl.TabIndex = 7
        Me.HazenWilliamsControl.ToBeCalculated = True
        Me.HazenWilliamsControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.HazenWilliamsControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.HazenWilliamsControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.HazenWilliamsControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.HazenWilliamsControl.ValueText = ""
        '
        'HazenWilleamsLabel
        '
        Me.HazenWilleamsLabel.Location = New System.Drawing.Point(4, 91)
        Me.HazenWilleamsLabel.Name = "HazenWilleamsLabel"
        Me.HazenWilleamsLabel.Size = New System.Drawing.Size(215, 23)
        Me.HazenWilleamsLabel.TabIndex = 6
        Me.HazenWilleamsLabel.Text = "&Hazen-Willams Pipe Coefficient"
        Me.HazenWilleamsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PipeSlopeControl
        '
        Me.PipeSlopeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.PipeSlopeControl.IsCalculated = False
        Me.PipeSlopeControl.IsInteger = False
        Me.PipeSlopeControl.Location = New System.Drawing.Point(225, 63)
        Me.PipeSlopeControl.MaxErrMsg = ""
        Me.PipeSlopeControl.MinErrMsg = ""
        Me.PipeSlopeControl.Name = "PipeSlopeControl"
        Me.PipeSlopeControl.Size = New System.Drawing.Size(100, 24)
        Me.PipeSlopeControl.TabIndex = 5
        Me.PipeSlopeControl.ToBeCalculated = True
        Me.PipeSlopeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.PipeSlopeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.PipeSlopeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.PipeSlopeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.PipeSlopeControl.ValueText = ""
        '
        'PipeSlopeLabel
        '
        Me.PipeSlopeLabel.Location = New System.Drawing.Point(4, 62)
        Me.PipeSlopeLabel.Name = "PipeSlopeLabel"
        Me.PipeSlopeLabel.Size = New System.Drawing.Size(215, 23)
        Me.PipeSlopeLabel.TabIndex = 4
        Me.PipeSlopeLabel.Text = "Pipe &Slope"
        Me.PipeSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EnterOneGroup
        '
        Me.EnterOneGroup.Controls.Add(Me.PeakFlowControl)
        Me.EnterOneGroup.Controls.Add(Me.PeakFlowButton)
        Me.EnterOneGroup.Controls.Add(Me.OrificeEquivalentDiameterControl)
        Me.EnterOneGroup.Controls.Add(Me.OrificeEquivalentDiameterButton)
        Me.EnterOneGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnterOneGroup.Location = New System.Drawing.Point(7, 118)
        Me.EnterOneGroup.Name = "EnterOneGroup"
        Me.EnterOneGroup.Size = New System.Drawing.Size(323, 80)
        Me.EnterOneGroup.TabIndex = 8
        Me.EnterOneGroup.TabStop = False
        Me.EnterOneGroup.Text = "Enter one of the following ..."
        '
        'PeakFlowControl
        '
        Me.PeakFlowControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.PeakFlowControl.IsCalculated = False
        Me.PeakFlowControl.IsInteger = False
        Me.PeakFlowControl.Location = New System.Drawing.Point(218, 47)
        Me.PeakFlowControl.MaxErrMsg = ""
        Me.PeakFlowControl.MinErrMsg = ""
        Me.PeakFlowControl.Name = "PeakFlowControl"
        Me.PeakFlowControl.Size = New System.Drawing.Size(100, 24)
        Me.PeakFlowControl.TabIndex = 3
        Me.PeakFlowControl.ToBeCalculated = True
        Me.PeakFlowControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.PeakFlowControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.PeakFlowControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.PeakFlowControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.PeakFlowControl.ValueText = ""
        '
        'PeakFlowButton
        '
        Me.PeakFlowButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PeakFlowButton.Location = New System.Drawing.Point(7, 47)
        Me.PeakFlowButton.Name = "PeakFlowButton"
        Me.PeakFlowButton.Size = New System.Drawing.Size(205, 23)
        Me.PeakFlowButton.TabIndex = 1
        Me.PeakFlowButton.TabStop = True
        Me.PeakFlowButton.Text = "Peak &Flow Into Furrow"
        Me.PeakFlowButton.UseVisualStyleBackColor = True
        '
        'OrificeEquivalentDiameterControl
        '
        Me.OrificeEquivalentDiameterControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.OrificeEquivalentDiameterControl.IsCalculated = False
        Me.OrificeEquivalentDiameterControl.IsInteger = False
        Me.OrificeEquivalentDiameterControl.Location = New System.Drawing.Point(218, 23)
        Me.OrificeEquivalentDiameterControl.MaxErrMsg = ""
        Me.OrificeEquivalentDiameterControl.MinErrMsg = ""
        Me.OrificeEquivalentDiameterControl.Name = "OrificeEquivalentDiameterControl"
        Me.OrificeEquivalentDiameterControl.Size = New System.Drawing.Size(100, 24)
        Me.OrificeEquivalentDiameterControl.TabIndex = 2
        Me.OrificeEquivalentDiameterControl.ToBeCalculated = True
        Me.OrificeEquivalentDiameterControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.OrificeEquivalentDiameterControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.OrificeEquivalentDiameterControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.OrificeEquivalentDiameterControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.OrificeEquivalentDiameterControl.ValueText = ""
        '
        'OrificeEquivalentDiameterButton
        '
        Me.OrificeEquivalentDiameterButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrificeEquivalentDiameterButton.Location = New System.Drawing.Point(7, 23)
        Me.OrificeEquivalentDiameterButton.Name = "OrificeEquivalentDiameterButton"
        Me.OrificeEquivalentDiameterButton.Size = New System.Drawing.Size(205, 23)
        Me.OrificeEquivalentDiameterButton.TabIndex = 0
        Me.OrificeEquivalentDiameterButton.TabStop = True
        Me.OrificeEquivalentDiameterButton.Text = "Orifice &Equivalent Diameter"
        Me.OrificeEquivalentDiameterButton.UseVisualStyleBackColor = True
        '
        'PlugSpeedControl
        '
        Me.PlugSpeedControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.PlugSpeedControl.IsCalculated = False
        Me.PlugSpeedControl.IsInteger = False
        Me.PlugSpeedControl.Location = New System.Drawing.Point(225, 265)
        Me.PlugSpeedControl.MaxErrMsg = ""
        Me.PlugSpeedControl.MinErrMsg = ""
        Me.PlugSpeedControl.Name = "PlugSpeedControl"
        Me.PlugSpeedControl.Size = New System.Drawing.Size(100, 24)
        Me.PlugSpeedControl.TabIndex = 14
        Me.PlugSpeedControl.ToBeCalculated = True
        Me.PlugSpeedControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.PlugSpeedControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.PlugSpeedControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.PlugSpeedControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.PlugSpeedControl.ValueText = ""
        '
        'PlugSpeedLabel
        '
        Me.PlugSpeedLabel.Location = New System.Drawing.Point(4, 264)
        Me.PlugSpeedLabel.Name = "PlugSpeedLabel"
        Me.PlugSpeedLabel.Size = New System.Drawing.Size(215, 23)
        Me.PlugSpeedLabel.TabIndex = 13
        Me.PlugSpeedLabel.Text = "&Plug Speed"
        Me.PlugSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OrificeSpacingControl
        '
        Me.OrificeSpacingControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.OrificeSpacingControl.IsCalculated = False
        Me.OrificeSpacingControl.IsInteger = False
        Me.OrificeSpacingControl.Location = New System.Drawing.Point(225, 236)
        Me.OrificeSpacingControl.MaxErrMsg = ""
        Me.OrificeSpacingControl.MinErrMsg = ""
        Me.OrificeSpacingControl.Name = "OrificeSpacingControl"
        Me.OrificeSpacingControl.Size = New System.Drawing.Size(100, 24)
        Me.OrificeSpacingControl.TabIndex = 12
        Me.OrificeSpacingControl.ToBeCalculated = True
        Me.OrificeSpacingControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.OrificeSpacingControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.OrificeSpacingControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.OrificeSpacingControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.OrificeSpacingControl.ValueText = ""
        '
        'OrificeSpacingLabel
        '
        Me.OrificeSpacingLabel.Location = New System.Drawing.Point(4, 235)
        Me.OrificeSpacingLabel.Name = "OrificeSpacingLabel"
        Me.OrificeSpacingLabel.Size = New System.Drawing.Size(215, 23)
        Me.OrificeSpacingLabel.TabIndex = 11
        Me.OrificeSpacingLabel.Text = "O&rifice Spacing"
        Me.OrificeSpacingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutoffFlowControl
        '
        Me.CutoffFlowControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutoffFlowControl.IsCalculated = False
        Me.CutoffFlowControl.IsInteger = False
        Me.CutoffFlowControl.Location = New System.Drawing.Point(225, 207)
        Me.CutoffFlowControl.MaxErrMsg = ""
        Me.CutoffFlowControl.MinErrMsg = ""
        Me.CutoffFlowControl.Name = "CutoffFlowControl"
        Me.CutoffFlowControl.Size = New System.Drawing.Size(100, 24)
        Me.CutoffFlowControl.TabIndex = 10
        Me.CutoffFlowControl.ToBeCalculated = True
        Me.CutoffFlowControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutoffFlowControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutoffFlowControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutoffFlowControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutoffFlowControl.ValueText = ""
        '
        'CutoffFlowLabel
        '
        Me.CutoffFlowLabel.Location = New System.Drawing.Point(4, 206)
        Me.CutoffFlowLabel.Name = "CutoffFlowLabel"
        Me.CutoffFlowLabel.Size = New System.Drawing.Size(215, 23)
        Me.CutoffFlowLabel.TabIndex = 9
        Me.CutoffFlowLabel.Text = "&Cutoff Flow"
        Me.CutoffFlowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ctl_Cablegation
        '
        Me.AccessibleDescription = "Display and edit cablegation inflow parameters"
        Me.AccessibleName = "Cablegation Inflow"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PlugSpeedControl)
        Me.Controls.Add(Me.PlugSpeedLabel)
        Me.Controls.Add(Me.OrificeSpacingControl)
        Me.Controls.Add(Me.OrificeSpacingLabel)
        Me.Controls.Add(Me.CutoffFlowControl)
        Me.Controls.Add(Me.CutoffFlowLabel)
        Me.Controls.Add(Me.EnterOneGroup)
        Me.Controls.Add(Me.HazenWilliamsControl)
        Me.Controls.Add(Me.HazenWilleamsLabel)
        Me.Controls.Add(Me.PipeSlopeControl)
        Me.Controls.Add(Me.PipeSlopeLabel)
        Me.Controls.Add(Me.PipeDiameterControl)
        Me.Controls.Add(Me.PipeDiameterLabel)
        Me.Controls.Add(Me.TotalInflowControl)
        Me.Controls.Add(Me.TotalInflowLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_Cablegation"
        Me.Size = New System.Drawing.Size(335, 295)
        Me.EnterOneGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TotalInflowLabel As DataStore.ctl_Label
    Friend WithEvents TotalInflowControl As DataStore.ctl_DoubleParameter
    Friend WithEvents PipeDiameterControl As DataStore.ctl_DoubleParameter
    Friend WithEvents PipeDiameterLabel As DataStore.ctl_Label
    Friend WithEvents HazenWilliamsControl As DataStore.ctl_DoubleParameter
    Friend WithEvents HazenWilleamsLabel As DataStore.ctl_Label
    Friend WithEvents PipeSlopeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents PipeSlopeLabel As DataStore.ctl_Label
    Friend WithEvents EnterOneGroup As DataStore.ctl_GroupBox
    Friend WithEvents OrificeEquivalentDiameterControl As DataStore.ctl_DoubleParameter
    Friend WithEvents OrificeEquivalentDiameterButton As DataStore.ctl_RadioButton
    Friend WithEvents PeakFlowControl As DataStore.ctl_DoubleParameter
    Friend WithEvents PeakFlowButton As DataStore.ctl_RadioButton
    Friend WithEvents PlugSpeedControl As DataStore.ctl_DoubleParameter
    Friend WithEvents PlugSpeedLabel As DataStore.ctl_Label
    Friend WithEvents OrificeSpacingControl As DataStore.ctl_DoubleParameter
    Friend WithEvents OrificeSpacingLabel As DataStore.ctl_Label
    Friend WithEvents CutoffFlowControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffFlowLabel As DataStore.ctl_Label

End Class
