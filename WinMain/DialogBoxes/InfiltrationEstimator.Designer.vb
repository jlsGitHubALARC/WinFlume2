<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfiltrationEstimator
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
        Me.components = New System.ComponentModel.Container
        Me.InfiltrationGraphics = New GraphingUI.ex_PictureBox
        Me.GreenAmptPanel = New DataStore.ctl_Panel
        Me.GA_Ks_Estimate = New DataStore.ctl_DoubleUpDownParameter
        Me.GA_hf_Estimate = New DataStore.ctl_DoubleUpDownParameter
        Me.GA_c_Fixed = New DataStore.ctl_Label
        Me.GA_Ks_Fixed = New DataStore.ctl_Label
        Me.GA_hf_Fixed = New DataStore.ctl_Label
        Me.GA_Theta0_Fixed = New DataStore.ctl_Label
        Me.GA_ThetaS_Fixed = New DataStore.ctl_Label
        Me.GA_InstantaneousInfiltrationLabel = New DataStore.ctl_Label
        Me.GA_HydraulicConductivityLabel = New DataStore.ctl_Label
        Me.GA_WettingFrontLabel = New DataStore.ctl_Label
        Me.GA_InitWaterContentLabel = New DataStore.ctl_Label
        Me.GA_SatWaterContentLabel = New DataStore.ctl_Label
        Me.GreenAmptLabel = New DataStore.ctl_Label
        Me.ChooseLocationLabel = New DataStore.ctl_Label
        Me.OkMatchButton = New DataStore.ctl_Button
        Me.CancelMatchButton = New DataStore.ctl_Button
        Me.FieldLocationLabel = New DataStore.ctl_Label
        Me.FieldLocation = New System.Windows.Forms.ComboBox
        Me.WarrickGreenAmptPanel = New DataStore.ctl_Panel
        Me.WGA_Ks_Estimate = New DataStore.ctl_DoubleUpDownParameter
        Me.WGA_hf_Estimate = New DataStore.ctl_DoubleUpDownParameter
        Me.WGA_c_Fixed = New DataStore.ctl_Label
        Me.WGA_Ks_Fixed = New DataStore.ctl_Label
        Me.WGA_hf_Fixed = New DataStore.ctl_Label
        Me.WGA_Theta0_Fixed = New DataStore.ctl_Label
        Me.WGA_ThetaS_Fixed = New DataStore.ctl_Label
        Me.WGA_InstantaneousInfiltrationLabel = New DataStore.ctl_Label
        Me.WGA_HydraulicConductivityLabel = New DataStore.ctl_Label
        Me.WGA_WettingFrontLabel = New DataStore.ctl_Label
        Me.WGA_InitWaterContentLabel = New DataStore.ctl_Label
        Me.WGA_SatWaterContentLabel = New DataStore.ctl_Label
        Me.WarrickGreenAmptLabel = New DataStore.ctl_Label
        CType(Me.InfiltrationGraphics, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GreenAmptPanel.SuspendLayout()
        Me.WarrickGreenAmptPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'InfiltrationGraphics
        '
        Me.InfiltrationGraphics.AccessibleDescription = "A copyable bitmap image"
        Me.InfiltrationGraphics.AccessibleName = "Bitmap Diagram"
        Me.InfiltrationGraphics.BackColor = System.Drawing.SystemColors.Control
        Me.InfiltrationGraphics.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationGraphics.Location = New System.Drawing.Point(1, 1)
        Me.InfiltrationGraphics.Name = "InfiltrationGraphics"
        Me.InfiltrationGraphics.Size = New System.Drawing.Size(392, 150)
        Me.InfiltrationGraphics.TabIndex = 21
        Me.InfiltrationGraphics.TabStop = False
        Me.InfiltrationGraphics.Text = "Bitmap Diagram"
        '
        'GreenAmptPanel
        '
        Me.GreenAmptPanel.Controls.Add(Me.GA_Ks_Estimate)
        Me.GreenAmptPanel.Controls.Add(Me.GA_hf_Estimate)
        Me.GreenAmptPanel.Controls.Add(Me.GA_c_Fixed)
        Me.GreenAmptPanel.Controls.Add(Me.GA_Ks_Fixed)
        Me.GreenAmptPanel.Controls.Add(Me.GA_hf_Fixed)
        Me.GreenAmptPanel.Controls.Add(Me.GA_Theta0_Fixed)
        Me.GreenAmptPanel.Controls.Add(Me.GA_ThetaS_Fixed)
        Me.GreenAmptPanel.Controls.Add(Me.GA_InstantaneousInfiltrationLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_HydraulicConductivityLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_WettingFrontLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_InitWaterContentLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_SatWaterContentLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GreenAmptLabel)
        Me.GreenAmptPanel.Location = New System.Drawing.Point(1, 225)
        Me.GreenAmptPanel.Name = "GreenAmptPanel"
        Me.GreenAmptPanel.Size = New System.Drawing.Size(392, 160)
        Me.GreenAmptPanel.TabIndex = 4
        '
        'GA_Ks_Estimate
        '
        Me.GA_Ks_Estimate.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_Ks_Estimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_Ks_Estimate.IsCalculated = False
        Me.GA_Ks_Estimate.IsInteger = False
        Me.GA_Ks_Estimate.Location = New System.Drawing.Point(275, 112)
        Me.GA_Ks_Estimate.Margin = New System.Windows.Forms.Padding(4)
        Me.GA_Ks_Estimate.Name = "GA_Ks_Estimate"
        Me.GA_Ks_Estimate.Size = New System.Drawing.Size(115, 24)
        Me.GA_Ks_Estimate.TabIndex = 8
        Me.GA_Ks_Estimate.ToBeCalculated = True
        Me.GA_Ks_Estimate.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_Ks_Estimate.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_Ks_Estimate.ValueForeColor = System.Drawing.SystemColors.WindowText
        '
        'GA_hf_Estimate
        '
        Me.GA_hf_Estimate.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_hf_Estimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_hf_Estimate.IsCalculated = False
        Me.GA_hf_Estimate.IsInteger = False
        Me.GA_hf_Estimate.Location = New System.Drawing.Point(275, 87)
        Me.GA_hf_Estimate.Margin = New System.Windows.Forms.Padding(4)
        Me.GA_hf_Estimate.Name = "GA_hf_Estimate"
        Me.GA_hf_Estimate.Size = New System.Drawing.Size(115, 24)
        Me.GA_hf_Estimate.TabIndex = 6
        Me.GA_hf_Estimate.ToBeCalculated = True
        Me.GA_hf_Estimate.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_hf_Estimate.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_hf_Estimate.ValueForeColor = System.Drawing.SystemColors.WindowText
        '
        'GA_c_Fixed
        '
        Me.GA_c_Fixed.Location = New System.Drawing.Point(275, 137)
        Me.GA_c_Fixed.Name = "GA_c_Fixed"
        Me.GA_c_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.GA_c_Fixed.TabIndex = 10
        Me.GA_c_Fixed.Text = "c"
        '
        'GA_Ks_Fixed
        '
        Me.GA_Ks_Fixed.Location = New System.Drawing.Point(275, 113)
        Me.GA_Ks_Fixed.Name = "GA_Ks_Fixed"
        Me.GA_Ks_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.GA_Ks_Fixed.TabIndex = 8
        Me.GA_Ks_Fixed.Text = "Ks"
        '
        'GA_hf_Fixed
        '
        Me.GA_hf_Fixed.Location = New System.Drawing.Point(275, 87)
        Me.GA_hf_Fixed.Name = "GA_hf_Fixed"
        Me.GA_hf_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.GA_hf_Fixed.TabIndex = 6
        Me.GA_hf_Fixed.Text = "hf"
        '
        'GA_Theta0_Fixed
        '
        Me.GA_Theta0_Fixed.Location = New System.Drawing.Point(275, 61)
        Me.GA_Theta0_Fixed.Name = "GA_Theta0_Fixed"
        Me.GA_Theta0_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.GA_Theta0_Fixed.TabIndex = 4
        Me.GA_Theta0_Fixed.Text = "Theta0"
        '
        'GA_ThetaS_Fixed
        '
        Me.GA_ThetaS_Fixed.Location = New System.Drawing.Point(275, 35)
        Me.GA_ThetaS_Fixed.Name = "GA_ThetaS_Fixed"
        Me.GA_ThetaS_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.GA_ThetaS_Fixed.TabIndex = 2
        Me.GA_ThetaS_Fixed.Text = "ThetaS"
        '
        'GA_InstantaneousInfiltrationLabel
        '
        Me.GA_InstantaneousInfiltrationLabel.Location = New System.Drawing.Point(12, 135)
        Me.GA_InstantaneousInfiltrationLabel.Name = "GA_InstantaneousInfiltrationLabel"
        Me.GA_InstantaneousInfiltrationLabel.Size = New System.Drawing.Size(257, 21)
        Me.GA_InstantaneousInfiltrationLabel.TabIndex = 9
        Me.GA_InstantaneousInfiltrationLabel.Text = "Instantaneous Infiltration, c"
        Me.GA_InstantaneousInfiltrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_HydraulicConductivityLabel
        '
        Me.GA_HydraulicConductivityLabel.Location = New System.Drawing.Point(12, 111)
        Me.GA_HydraulicConductivityLabel.Name = "GA_HydraulicConductivityLabel"
        Me.GA_HydraulicConductivityLabel.Size = New System.Drawing.Size(257, 21)
        Me.GA_HydraulicConductivityLabel.TabIndex = 7
        Me.GA_HydraulicConductivityLabel.Text = "Hydraulic Conductivity, Ks"
        Me.GA_HydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_WettingFrontLabel
        '
        Me.GA_WettingFrontLabel.Location = New System.Drawing.Point(12, 85)
        Me.GA_WettingFrontLabel.Name = "GA_WettingFrontLabel"
        Me.GA_WettingFrontLabel.Size = New System.Drawing.Size(257, 21)
        Me.GA_WettingFrontLabel.TabIndex = 5
        Me.GA_WettingFrontLabel.Text = "Wetting Front Pressure Head, hf"
        Me.GA_WettingFrontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_InitWaterContentLabel
        '
        Me.GA_InitWaterContentLabel.Location = New System.Drawing.Point(12, 59)
        Me.GA_InitWaterContentLabel.Name = "GA_InitWaterContentLabel"
        Me.GA_InitWaterContentLabel.Size = New System.Drawing.Size(257, 21)
        Me.GA_InitWaterContentLabel.TabIndex = 3
        Me.GA_InitWaterContentLabel.Text = "Initial Water Content, Theta0"
        Me.GA_InitWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_SatWaterContentLabel
        '
        Me.GA_SatWaterContentLabel.Location = New System.Drawing.Point(12, 33)
        Me.GA_SatWaterContentLabel.Name = "GA_SatWaterContentLabel"
        Me.GA_SatWaterContentLabel.Size = New System.Drawing.Size(257, 21)
        Me.GA_SatWaterContentLabel.TabIndex = 1
        Me.GA_SatWaterContentLabel.Text = "Sat. Water Content, ThetaS"
        Me.GA_SatWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GreenAmptLabel
        '
        Me.GreenAmptLabel.AutoSize = True
        Me.GreenAmptLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GreenAmptLabel.ForeColor = System.Drawing.Color.Blue
        Me.GreenAmptLabel.Location = New System.Drawing.Point(4, 4)
        Me.GreenAmptLabel.Name = "GreenAmptLabel"
        Me.GreenAmptLabel.Size = New System.Drawing.Size(255, 17)
        Me.GreenAmptLabel.TabIndex = 0
        Me.GreenAmptLabel.Text = "Green-Ampt Parameter Estimation"
        '
        'ChooseLocationLabel
        '
        Me.ChooseLocationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChooseLocationLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChooseLocationLabel.Location = New System.Drawing.Point(1, 157)
        Me.ChooseLocationLabel.Name = "ChooseLocationLabel"
        Me.ChooseLocationLabel.Size = New System.Drawing.Size(392, 20)
        Me.ChooseLocationLabel.TabIndex = 0
        Me.ChooseLocationLabel.Text = "Choose field location for representative infiltration"
        Me.ChooseLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OkMatchButton
        '
        Me.OkMatchButton.Location = New System.Drawing.Point(25, 396)
        Me.OkMatchButton.Name = "OkMatchButton"
        Me.OkMatchButton.Size = New System.Drawing.Size(75, 25)
        Me.OkMatchButton.TabIndex = 5
        Me.OkMatchButton.Text = "Ok"
        Me.OkMatchButton.UseVisualStyleBackColor = True
        '
        'CancelMatchButton
        '
        Me.CancelMatchButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelMatchButton.Location = New System.Drawing.Point(291, 396)
        Me.CancelMatchButton.Name = "CancelMatchButton"
        Me.CancelMatchButton.Size = New System.Drawing.Size(75, 25)
        Me.CancelMatchButton.TabIndex = 6
        Me.CancelMatchButton.Text = "Cancel"
        Me.CancelMatchButton.UseVisualStyleBackColor = True
        '
        'FieldLocationLabel
        '
        Me.FieldLocationLabel.Location = New System.Drawing.Point(8, 185)
        Me.FieldLocationLabel.Name = "FieldLocationLabel"
        Me.FieldLocationLabel.Size = New System.Drawing.Size(262, 21)
        Me.FieldLocationLabel.TabIndex = 1
        Me.FieldLocationLabel.Text = "Field Location, X"
        Me.FieldLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FieldLocation
        '
        Me.FieldLocation.FormattingEnabled = True
        Me.FieldLocation.Location = New System.Drawing.Point(276, 185)
        Me.FieldLocation.Name = "FieldLocation"
        Me.FieldLocation.Size = New System.Drawing.Size(100, 24)
        Me.FieldLocation.TabIndex = 2
        Me.FieldLocation.Text = "9999.999 m"
        '
        'WarrickGreenAmptPanel
        '
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_Ks_Estimate)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_hf_Estimate)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_c_Fixed)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_Ks_Fixed)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_hf_Fixed)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_Theta0_Fixed)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_ThetaS_Fixed)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_InstantaneousInfiltrationLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_HydraulicConductivityLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_WettingFrontLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_InitWaterContentLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_SatWaterContentLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WarrickGreenAmptLabel)
        Me.WarrickGreenAmptPanel.Location = New System.Drawing.Point(1, 225)
        Me.WarrickGreenAmptPanel.Name = "WarrickGreenAmptPanel"
        Me.WarrickGreenAmptPanel.Size = New System.Drawing.Size(392, 160)
        Me.WarrickGreenAmptPanel.TabIndex = 4
        '
        'WGA_Ks_Estimate
        '
        Me.WGA_Ks_Estimate.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_Ks_Estimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_Ks_Estimate.IsCalculated = False
        Me.WGA_Ks_Estimate.IsInteger = False
        Me.WGA_Ks_Estimate.Location = New System.Drawing.Point(275, 112)
        Me.WGA_Ks_Estimate.Margin = New System.Windows.Forms.Padding(4)
        Me.WGA_Ks_Estimate.Name = "WGA_Ks_Estimate"
        Me.WGA_Ks_Estimate.Size = New System.Drawing.Size(115, 24)
        Me.WGA_Ks_Estimate.TabIndex = 8
        Me.WGA_Ks_Estimate.ToBeCalculated = True
        Me.WGA_Ks_Estimate.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_Ks_Estimate.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_Ks_Estimate.ValueForeColor = System.Drawing.SystemColors.WindowText
        '
        'WGA_hf_Estimate
        '
        Me.WGA_hf_Estimate.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_hf_Estimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_hf_Estimate.IsCalculated = False
        Me.WGA_hf_Estimate.IsInteger = False
        Me.WGA_hf_Estimate.Location = New System.Drawing.Point(275, 87)
        Me.WGA_hf_Estimate.Margin = New System.Windows.Forms.Padding(4)
        Me.WGA_hf_Estimate.Name = "WGA_hf_Estimate"
        Me.WGA_hf_Estimate.Size = New System.Drawing.Size(115, 24)
        Me.WGA_hf_Estimate.TabIndex = 6
        Me.WGA_hf_Estimate.ToBeCalculated = True
        Me.WGA_hf_Estimate.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_hf_Estimate.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_hf_Estimate.ValueForeColor = System.Drawing.SystemColors.WindowText
        '
        'WGA_c_Fixed
        '
        Me.WGA_c_Fixed.Location = New System.Drawing.Point(275, 137)
        Me.WGA_c_Fixed.Name = "WGA_c_Fixed"
        Me.WGA_c_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.WGA_c_Fixed.TabIndex = 10
        Me.WGA_c_Fixed.Text = "c"
        '
        'WGA_Ks_Fixed
        '
        Me.WGA_Ks_Fixed.Location = New System.Drawing.Point(275, 113)
        Me.WGA_Ks_Fixed.Name = "WGA_Ks_Fixed"
        Me.WGA_Ks_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.WGA_Ks_Fixed.TabIndex = 8
        Me.WGA_Ks_Fixed.Text = "Ks"
        '
        'WGA_hf_Fixed
        '
        Me.WGA_hf_Fixed.Location = New System.Drawing.Point(275, 87)
        Me.WGA_hf_Fixed.Name = "WGA_hf_Fixed"
        Me.WGA_hf_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.WGA_hf_Fixed.TabIndex = 6
        Me.WGA_hf_Fixed.Text = "hf"
        '
        'WGA_Theta0_Fixed
        '
        Me.WGA_Theta0_Fixed.Location = New System.Drawing.Point(275, 61)
        Me.WGA_Theta0_Fixed.Name = "WGA_Theta0_Fixed"
        Me.WGA_Theta0_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.WGA_Theta0_Fixed.TabIndex = 4
        Me.WGA_Theta0_Fixed.Text = "Theta0"
        '
        'WGA_ThetaS_Fixed
        '
        Me.WGA_ThetaS_Fixed.Location = New System.Drawing.Point(275, 35)
        Me.WGA_ThetaS_Fixed.Name = "WGA_ThetaS_Fixed"
        Me.WGA_ThetaS_Fixed.Size = New System.Drawing.Size(100, 21)
        Me.WGA_ThetaS_Fixed.TabIndex = 2
        Me.WGA_ThetaS_Fixed.Text = "ThetaS"
        '
        'WGA_InstantaneousInfiltrationLabel
        '
        Me.WGA_InstantaneousInfiltrationLabel.Location = New System.Drawing.Point(12, 135)
        Me.WGA_InstantaneousInfiltrationLabel.Name = "WGA_InstantaneousInfiltrationLabel"
        Me.WGA_InstantaneousInfiltrationLabel.Size = New System.Drawing.Size(257, 21)
        Me.WGA_InstantaneousInfiltrationLabel.TabIndex = 9
        Me.WGA_InstantaneousInfiltrationLabel.Text = "Instantaneous Infiltration, c"
        Me.WGA_InstantaneousInfiltrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_HydraulicConductivityLabel
        '
        Me.WGA_HydraulicConductivityLabel.Location = New System.Drawing.Point(12, 111)
        Me.WGA_HydraulicConductivityLabel.Name = "WGA_HydraulicConductivityLabel"
        Me.WGA_HydraulicConductivityLabel.Size = New System.Drawing.Size(257, 21)
        Me.WGA_HydraulicConductivityLabel.TabIndex = 7
        Me.WGA_HydraulicConductivityLabel.Text = "Hydraulic Conductivity, Ks"
        Me.WGA_HydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_WettingFrontLabel
        '
        Me.WGA_WettingFrontLabel.Location = New System.Drawing.Point(12, 85)
        Me.WGA_WettingFrontLabel.Name = "WGA_WettingFrontLabel"
        Me.WGA_WettingFrontLabel.Size = New System.Drawing.Size(257, 21)
        Me.WGA_WettingFrontLabel.TabIndex = 5
        Me.WGA_WettingFrontLabel.Text = "Wetting Front Pressure Head, hf"
        Me.WGA_WettingFrontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_InitWaterContentLabel
        '
        Me.WGA_InitWaterContentLabel.Location = New System.Drawing.Point(12, 59)
        Me.WGA_InitWaterContentLabel.Name = "WGA_InitWaterContentLabel"
        Me.WGA_InitWaterContentLabel.Size = New System.Drawing.Size(257, 21)
        Me.WGA_InitWaterContentLabel.TabIndex = 3
        Me.WGA_InitWaterContentLabel.Text = "Initial Water Content, Theta0"
        Me.WGA_InitWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_SatWaterContentLabel
        '
        Me.WGA_SatWaterContentLabel.Location = New System.Drawing.Point(12, 33)
        Me.WGA_SatWaterContentLabel.Name = "WGA_SatWaterContentLabel"
        Me.WGA_SatWaterContentLabel.Size = New System.Drawing.Size(257, 21)
        Me.WGA_SatWaterContentLabel.TabIndex = 1
        Me.WGA_SatWaterContentLabel.Text = "Sat. Water Content, ThetaS"
        Me.WGA_SatWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WarrickGreenAmptLabel
        '
        Me.WarrickGreenAmptLabel.AutoSize = True
        Me.WarrickGreenAmptLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WarrickGreenAmptLabel.ForeColor = System.Drawing.Color.Blue
        Me.WarrickGreenAmptLabel.Location = New System.Drawing.Point(4, 4)
        Me.WarrickGreenAmptLabel.Name = "WarrickGreenAmptLabel"
        Me.WarrickGreenAmptLabel.Size = New System.Drawing.Size(315, 17)
        Me.WarrickGreenAmptLabel.TabIndex = 0
        Me.WarrickGreenAmptLabel.Text = "Warrick Green-Ampt Parameter Estimation"
        '
        'InfiltrationEstimator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelMatchButton
        Me.ClientSize = New System.Drawing.Size(394, 432)
        Me.Controls.Add(Me.WarrickGreenAmptPanel)
        Me.Controls.Add(Me.FieldLocation)
        Me.Controls.Add(Me.FieldLocationLabel)
        Me.Controls.Add(Me.CancelMatchButton)
        Me.Controls.Add(Me.OkMatchButton)
        Me.Controls.Add(Me.ChooseLocationLabel)
        Me.Controls.Add(Me.GreenAmptPanel)
        Me.Controls.Add(Me.InfiltrationGraphics)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InfiltrationEstimator"
        Me.ShowIcon = False
        Me.Text = "Infiltration Estimator"
        CType(Me.InfiltrationGraphics, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GreenAmptPanel.ResumeLayout(False)
        Me.GreenAmptPanel.PerformLayout()
        Me.WarrickGreenAmptPanel.ResumeLayout(False)
        Me.WarrickGreenAmptPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InfiltrationGraphics As GraphingUI.ex_PictureBox
    Friend WithEvents GreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents ChooseLocationLabel As DataStore.ctl_Label
    Friend WithEvents OkMatchButton As DataStore.ctl_Button
    Friend WithEvents CancelMatchButton As DataStore.ctl_Button
    Friend WithEvents GreenAmptLabel As DataStore.ctl_Label
    Friend WithEvents GA_InstantaneousInfiltrationLabel As DataStore.ctl_Label
    Friend WithEvents GA_HydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents GA_WettingFrontLabel As DataStore.ctl_Label
    Friend WithEvents GA_InitWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents GA_SatWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents GA_c_Fixed As DataStore.ctl_Label
    Friend WithEvents GA_Ks_Fixed As DataStore.ctl_Label
    Friend WithEvents GA_hf_Fixed As DataStore.ctl_Label
    Friend WithEvents GA_Theta0_Fixed As DataStore.ctl_Label
    Friend WithEvents GA_ThetaS_Fixed As DataStore.ctl_Label
    Friend WithEvents FieldLocationLabel As DataStore.ctl_Label
    Friend WithEvents FieldLocation As System.Windows.Forms.ComboBox
    Friend WithEvents GA_Ks_Estimate As DataStore.ctl_DoubleUpDownParameter
    Friend WithEvents GA_hf_Estimate As DataStore.ctl_DoubleUpDownParameter
    Friend WithEvents WarrickGreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents WGA_Ks_Estimate As DataStore.ctl_DoubleUpDownParameter
    Friend WithEvents WGA_hf_Estimate As DataStore.ctl_DoubleUpDownParameter
    Friend WithEvents WGA_c_Fixed As DataStore.ctl_Label
    Friend WithEvents WGA_Ks_Fixed As DataStore.ctl_Label
    Friend WithEvents WGA_hf_Fixed As DataStore.ctl_Label
    Friend WithEvents WGA_Theta0_Fixed As DataStore.ctl_Label
    Friend WithEvents WGA_ThetaS_Fixed As DataStore.ctl_Label
    Friend WithEvents WGA_InstantaneousInfiltrationLabel As DataStore.ctl_Label
    Friend WithEvents WGA_HydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents WGA_WettingFrontLabel As DataStore.ctl_Label
    Friend WithEvents WGA_InitWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents WGA_SatWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents WarrickGreenAmptLabel As DataStore.ctl_Label
End Class
