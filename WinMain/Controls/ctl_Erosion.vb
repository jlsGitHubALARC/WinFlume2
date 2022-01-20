
'**********************************************************************************************
' UserControl class: ctl_Erosion
'
'   ctl_Erosion provides the UI for viewing & editing Erosion data
'
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI
Imports Srfr.SrfrAPI

Public Class ctl_Erosion
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ErosionBox As DataStore.ctl_GroupBox
    Friend WithEvents SoilErodibilityBox As DataStore.ctl_GroupBox
    Friend WithEvents ErodibilityBetaLabel As DataStore.ctl_Label
    Friend WithEvents ErodibilityTaucLabel As DataStore.ctl_Label
    Friend WithEvents ErodibilityBLabel As DataStore.ctl_Label
    Friend WithEvents ErodibilityALabel As DataStore.ctl_Label
    Friend WithEvents ToDescription As DataStore.ctl_Label
    Friend WithEvents KRequation As System.Windows.Forms.Label
    Friend WithEvents TaucDescription As DataStore.ctl_Label
    Friend WithEvents DRequation As System.Windows.Forms.Label
    Friend WithEvents KinematicViscosityControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KinematicViscosityLabel As DataStore.ctl_Label
    Friend WithEvents SedimentComponentsControl As DataStore.ctl_DataTableParameter
    Friend WithEvents ErodibilityBetaControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ErodibilityTaucControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ErodibilityBControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ErodibilityAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ParticleSizeDistributionBox As DataStore.ctl_GroupBox
    Friend WithEvents ResolutionLabel As DataStore.ctl_Label
    Friend WithEvents ResolutionControl As DataStore.ctl_SelectParameter
    Friend WithEvents FitLabel As DataStore.ctl_Label
    Friend WithEvents FitControl As DataStore.ctl_SelectParameter
    Friend WithEvents ProgrammerPanel As System.Windows.Forms.Panel
    Friend WithEvents ErosionCoefficientControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ErosionCoefficientLabel As DataStore.ctl_Label
    Friend WithEvents FullScaleGControl As DataStore.ctl_DoubleParameter
    Friend WithEvents FullScaleGLabel As DataStore.ctl_Label
    Friend WithEvents ComputeTauCBeta As System.Windows.Forms.Button
    Friend WithEvents EditSandSiltClayTable As System.Windows.Forms.Button
    Friend WithEvents TemperatureControl As DataStore.ctl_DoubleParameter
    Friend WithEvents TemperatureLabel As DataStore.ctl_Label
    Friend WithEvents IrrigationWaterBox As DataStore.ctl_GroupBox
    Friend WithEvents ErosionMeasurementsBox As DataStore.ctl_GroupBox
    Friend WithEvents CGmLabel As DataStore.ctl_Label
    Friend WithEvents CGmControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SedimentDistanceControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SedimentDistanceLabel As DataStore.ctl_Label
    Friend WithEvents SedimentTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SedimentTimeeLabel As DataStore.ctl_Label
    Friend WithEvents SedimentLocationLabel As DataStore.ctl_Label
    Friend WithEvents Test_Panel As DataStore.ctl_Panel
    Friend WithEvents Ds_Label As DataStore.ctl_Label
    Friend WithEvents DsControl As DataStore.ctl_DoubleParameter
    Friend WithEvents Kr_Label As DataStore.ctl_Label
    Friend WithEvents KrControl As DataStore.ctl_DoubleParameter
    Friend WithEvents Sg_Label As DataStore.ctl_Label
    Friend WithEvents SgControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SedimentParticleBox As DataStore.ctl_GroupBox
    Friend WithEvents CriticalShearBox As DataStore.ctl_GroupBox
    Friend WithEvents TcsControl As DataStore.ctl_DoubleParameter
    Friend WithEvents UserEnterCriticalShear As DataStore.ctl_CheckParameter
    Friend WithEvents KrBetaUnits As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_Erosion))
        Me.ErosionBox = New DataStore.ctl_GroupBox
        Me.Test_Panel = New DataStore.ctl_Panel
        Me.SedimentParticleBox = New DataStore.ctl_GroupBox
        Me.CriticalShearBox = New DataStore.ctl_GroupBox
        Me.UserEnterCriticalShear = New DataStore.ctl_CheckParameter
        Me.TcsControl = New DataStore.ctl_DoubleParameter
        Me.SgControl = New DataStore.ctl_DoubleParameter
        Me.Kr_Label = New DataStore.ctl_Label
        Me.DsControl = New DataStore.ctl_DoubleParameter
        Me.KrControl = New DataStore.ctl_DoubleParameter
        Me.Ds_Label = New DataStore.ctl_Label
        Me.Sg_Label = New DataStore.ctl_Label
        Me.IrrigationWaterBox = New DataStore.ctl_GroupBox
        Me.TemperatureControl = New DataStore.ctl_DoubleParameter
        Me.TemperatureLabel = New DataStore.ctl_Label
        Me.KinematicViscosityControl = New DataStore.ctl_DoubleParameter
        Me.KinematicViscosityLabel = New DataStore.ctl_Label
        Me.ErosionMeasurementsBox = New DataStore.ctl_GroupBox
        Me.SedimentLocationLabel = New DataStore.ctl_Label
        Me.SedimentDistanceControl = New DataStore.ctl_DoubleParameter
        Me.SedimentDistanceLabel = New DataStore.ctl_Label
        Me.SedimentTimeControl = New DataStore.ctl_DoubleParameter
        Me.SedimentTimeeLabel = New DataStore.ctl_Label
        Me.CGmControl = New DataStore.ctl_DoubleParameter
        Me.CGmLabel = New DataStore.ctl_Label
        Me.EditSandSiltClayTable = New System.Windows.Forms.Button
        Me.ProgrammerPanel = New System.Windows.Forms.Panel
        Me.FullScaleGControl = New DataStore.ctl_DoubleParameter
        Me.FullScaleGLabel = New DataStore.ctl_Label
        Me.ErosionCoefficientControl = New DataStore.ctl_DoubleParameter
        Me.ErosionCoefficientLabel = New DataStore.ctl_Label
        Me.ParticleSizeDistributionBox = New DataStore.ctl_GroupBox
        Me.FitControl = New DataStore.ctl_SelectParameter
        Me.FitLabel = New DataStore.ctl_Label
        Me.ResolutionControl = New DataStore.ctl_SelectParameter
        Me.ResolutionLabel = New DataStore.ctl_Label
        Me.SoilErodibilityBox = New DataStore.ctl_GroupBox
        Me.KrBetaUnits = New System.Windows.Forms.PictureBox
        Me.ComputeTauCBeta = New System.Windows.Forms.Button
        Me.ErodibilityBetaControl = New DataStore.ctl_DoubleParameter
        Me.ErodibilityBetaLabel = New DataStore.ctl_Label
        Me.ErodibilityTaucControl = New DataStore.ctl_DoubleParameter
        Me.ErodibilityTaucLabel = New DataStore.ctl_Label
        Me.ErodibilityBControl = New DataStore.ctl_DoubleParameter
        Me.ErodibilityBLabel = New DataStore.ctl_Label
        Me.ErodibilityAControl = New DataStore.ctl_DoubleParameter
        Me.ErodibilityALabel = New DataStore.ctl_Label
        Me.ToDescription = New DataStore.ctl_Label
        Me.KRequation = New System.Windows.Forms.Label
        Me.TaucDescription = New DataStore.ctl_Label
        Me.DRequation = New System.Windows.Forms.Label
        Me.SedimentComponentsControl = New DataStore.ctl_DataTableParameter
        Me.ErosionBox.SuspendLayout()
        Me.Test_Panel.SuspendLayout()
        Me.SedimentParticleBox.SuspendLayout()
        Me.CriticalShearBox.SuspendLayout()
        Me.IrrigationWaterBox.SuspendLayout()
        Me.ErosionMeasurementsBox.SuspendLayout()
        Me.ProgrammerPanel.SuspendLayout()
        Me.ParticleSizeDistributionBox.SuspendLayout()
        Me.SoilErodibilityBox.SuspendLayout()
        CType(Me.KrBetaUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SedimentComponentsControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErosionBox
        '
        Me.ErosionBox.AccessibleDescription = "Controls for specifying erosion parameters."
        Me.ErosionBox.AccessibleName = "Erosion"
        Me.ErosionBox.Controls.Add(Me.Test_Panel)
        Me.ErosionBox.Controls.Add(Me.ErosionMeasurementsBox)
        Me.ErosionBox.Controls.Add(Me.EditSandSiltClayTable)
        Me.ErosionBox.Controls.Add(Me.ProgrammerPanel)
        Me.ErosionBox.Controls.Add(Me.ParticleSizeDistributionBox)
        Me.ErosionBox.Controls.Add(Me.SoilErodibilityBox)
        Me.ErosionBox.Controls.Add(Me.SedimentComponentsControl)
        Me.ErosionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErosionBox.Location = New System.Drawing.Point(8, 8)
        Me.ErosionBox.Name = "ErosionBox"
        Me.ErosionBox.Size = New System.Drawing.Size(760, 416)
        Me.ErosionBox.TabIndex = 0
        Me.ErosionBox.TabStop = False
        Me.ErosionBox.Text = "Erosion"
        '
        'Test_Panel
        '
        Me.Test_Panel.Controls.Add(Me.SedimentParticleBox)
        Me.Test_Panel.Controls.Add(Me.IrrigationWaterBox)
        Me.Test_Panel.Location = New System.Drawing.Point(7, 16)
        Me.Test_Panel.Name = "Test_Panel"
        Me.Test_Panel.Size = New System.Drawing.Size(747, 394)
        Me.Test_Panel.TabIndex = 7
        '
        'SedimentParticleBox
        '
        Me.SedimentParticleBox.AccessibleDescription = "Parameters describing the viscosity of the irrigation water."
        Me.SedimentParticleBox.AccessibleName = "Irrigation Water"
        Me.SedimentParticleBox.Controls.Add(Me.CriticalShearBox)
        Me.SedimentParticleBox.Controls.Add(Me.SgControl)
        Me.SedimentParticleBox.Controls.Add(Me.Kr_Label)
        Me.SedimentParticleBox.Controls.Add(Me.DsControl)
        Me.SedimentParticleBox.Controls.Add(Me.KrControl)
        Me.SedimentParticleBox.Controls.Add(Me.Ds_Label)
        Me.SedimentParticleBox.Controls.Add(Me.Sg_Label)
        Me.SedimentParticleBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SedimentParticleBox.Location = New System.Drawing.Point(28, 131)
        Me.SedimentParticleBox.Name = "SedimentParticleBox"
        Me.SedimentParticleBox.Size = New System.Drawing.Size(320, 190)
        Me.SedimentParticleBox.TabIndex = 6
        Me.SedimentParticleBox.TabStop = False
        Me.SedimentParticleBox.Text = "Sediment Particle"
        '
        'CriticalShearBox
        '
        Me.CriticalShearBox.Controls.Add(Me.UserEnterCriticalShear)
        Me.CriticalShearBox.Controls.Add(Me.TcsControl)
        Me.CriticalShearBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CriticalShearBox.Location = New System.Drawing.Point(10, 117)
        Me.CriticalShearBox.Name = "CriticalShearBox"
        Me.CriticalShearBox.Size = New System.Drawing.Size(300, 63)
        Me.CriticalShearBox.TabIndex = 6
        Me.CriticalShearBox.TabStop = False
        Me.CriticalShearBox.Text = "&Critial Shear"
        '
        'UserEnterCriticalShear
        '
        Me.UserEnterCriticalShear.Location = New System.Drawing.Point(20, 26)
        Me.UserEnterCriticalShear.Name = "UserEnterCriticalShear"
        Me.UserEnterCriticalShear.Size = New System.Drawing.Size(130, 23)
        Me.UserEnterCriticalShear.TabIndex = 0
        Me.UserEnterCriticalShear.Text = "User Entered"
        Me.UserEnterCriticalShear.UseVisualStyleBackColor = True
        '
        'TcsControl
        '
        Me.TcsControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.TcsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcsControl.IsCalculated = False
        Me.TcsControl.IsInteger = False
        Me.TcsControl.Location = New System.Drawing.Point(155, 25)
        Me.TcsControl.Name = "TcsControl"
        Me.TcsControl.Size = New System.Drawing.Size(140, 24)
        Me.TcsControl.TabIndex = 1
        Me.TcsControl.ToBeCalculated = True
        Me.TcsControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.TcsControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.TcsControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.TcsControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.TcsControl.ValueText = ""
        '
        'SgControl
        '
        Me.SgControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SgControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SgControl.IsCalculated = False
        Me.SgControl.IsInteger = False
        Me.SgControl.Location = New System.Drawing.Point(165, 53)
        Me.SgControl.Name = "SgControl"
        Me.SgControl.Size = New System.Drawing.Size(144, 24)
        Me.SgControl.TabIndex = 3
        Me.SgControl.ToBeCalculated = True
        Me.SgControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SgControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SgControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SgControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SgControl.ValueText = ""
        '
        'Kr_Label
        '
        Me.Kr_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Kr_Label.Location = New System.Drawing.Point(15, 85)
        Me.Kr_Label.Name = "Kr_Label"
        Me.Kr_Label.Size = New System.Drawing.Size(141, 23)
        Me.Kr_Label.TabIndex = 4
        Me.Kr_Label.Text = "&Kr"
        Me.Kr_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DsControl
        '
        Me.DsControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.DsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DsControl.IsCalculated = False
        Me.DsControl.IsInteger = False
        Me.DsControl.Location = New System.Drawing.Point(165, 21)
        Me.DsControl.Name = "DsControl"
        Me.DsControl.Size = New System.Drawing.Size(144, 24)
        Me.DsControl.TabIndex = 1
        Me.DsControl.ToBeCalculated = True
        Me.DsControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.DsControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.DsControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.DsControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.DsControl.ValueText = ""
        '
        'KrControl
        '
        Me.KrControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KrControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KrControl.IsCalculated = False
        Me.KrControl.IsInteger = False
        Me.KrControl.Location = New System.Drawing.Point(165, 85)
        Me.KrControl.Name = "KrControl"
        Me.KrControl.Size = New System.Drawing.Size(144, 24)
        Me.KrControl.TabIndex = 5
        Me.KrControl.ToBeCalculated = True
        Me.KrControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KrControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KrControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KrControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KrControl.ValueText = ""
        '
        'Ds_Label
        '
        Me.Ds_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ds_Label.Location = New System.Drawing.Point(15, 21)
        Me.Ds_Label.Name = "Ds_Label"
        Me.Ds_Label.Size = New System.Drawing.Size(141, 23)
        Me.Ds_Label.TabIndex = 0
        Me.Ds_Label.Text = "&Diameter"
        Me.Ds_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Sg_Label
        '
        Me.Sg_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sg_Label.Location = New System.Drawing.Point(15, 53)
        Me.Sg_Label.Name = "Sg_Label"
        Me.Sg_Label.Size = New System.Drawing.Size(141, 23)
        Me.Sg_Label.TabIndex = 2
        Me.Sg_Label.Text = "&Specific Gravity"
        Me.Sg_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'IrrigationWaterBox
        '
        Me.IrrigationWaterBox.AccessibleDescription = "Parameters describing the viscosity of the irrigation water."
        Me.IrrigationWaterBox.AccessibleName = "Irrigation Water"
        Me.IrrigationWaterBox.Controls.Add(Me.TemperatureControl)
        Me.IrrigationWaterBox.Controls.Add(Me.TemperatureLabel)
        Me.IrrigationWaterBox.Controls.Add(Me.KinematicViscosityControl)
        Me.IrrigationWaterBox.Controls.Add(Me.KinematicViscosityLabel)
        Me.IrrigationWaterBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IrrigationWaterBox.Location = New System.Drawing.Point(28, 24)
        Me.IrrigationWaterBox.Name = "IrrigationWaterBox"
        Me.IrrigationWaterBox.Size = New System.Drawing.Size(320, 88)
        Me.IrrigationWaterBox.TabIndex = 4
        Me.IrrigationWaterBox.TabStop = False
        Me.IrrigationWaterBox.Text = "Irrigation Water"
        '
        'TemperatureControl
        '
        Me.TemperatureControl.AccessibleDescription = "Temperature of the irrigation water."
        Me.TemperatureControl.AccessibleName = "Temperature"
        Me.TemperatureControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.TemperatureControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TemperatureControl.IsCalculated = False
        Me.TemperatureControl.IsInteger = False
        Me.TemperatureControl.Location = New System.Drawing.Point(165, 23)
        Me.TemperatureControl.Name = "TemperatureControl"
        Me.TemperatureControl.Size = New System.Drawing.Size(144, 24)
        Me.TemperatureControl.TabIndex = 1
        Me.TemperatureControl.ToBeCalculated = True
        Me.TemperatureControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.TemperatureControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.TemperatureControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.TemperatureControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.TemperatureControl.ValueText = ""
        '
        'TemperatureLabel
        '
        Me.TemperatureLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TemperatureLabel.Location = New System.Drawing.Point(16, 23)
        Me.TemperatureLabel.Name = "TemperatureLabel"
        Me.TemperatureLabel.Size = New System.Drawing.Size(141, 23)
        Me.TemperatureLabel.TabIndex = 0
        Me.TemperatureLabel.Text = "&Temperature"
        Me.TemperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KinematicViscosityControl
        '
        Me.KinematicViscosityControl.AccessibleDescription = "Calculated based on Temperature."
        Me.KinematicViscosityControl.AccessibleName = "Kinematic Viscosity"
        Me.KinematicViscosityControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KinematicViscosityControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KinematicViscosityControl.IsCalculated = True
        Me.KinematicViscosityControl.IsInteger = False
        Me.KinematicViscosityControl.Location = New System.Drawing.Point(165, 55)
        Me.KinematicViscosityControl.Name = "KinematicViscosityControl"
        Me.KinematicViscosityControl.Size = New System.Drawing.Size(144, 24)
        Me.KinematicViscosityControl.TabIndex = 3
        Me.KinematicViscosityControl.ToBeCalculated = True
        Me.KinematicViscosityControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KinematicViscosityControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KinematicViscosityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KinematicViscosityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KinematicViscosityControl.ValueText = ""
        '
        'KinematicViscosityLabel
        '
        Me.KinematicViscosityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KinematicViscosityLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KinematicViscosityLabel.Location = New System.Drawing.Point(16, 55)
        Me.KinematicViscosityLabel.Name = "KinematicViscosityLabel"
        Me.KinematicViscosityLabel.Size = New System.Drawing.Size(141, 23)
        Me.KinematicViscosityLabel.TabIndex = 2
        Me.KinematicViscosityLabel.Text = "Kinematic &Viscosity"
        Me.KinematicViscosityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ErosionMeasurementsBox
        '
        Me.ErosionMeasurementsBox.AccessibleDescription = "Field measurement required to estimate the Soil Erodibility parameters."
        Me.ErosionMeasurementsBox.AccessibleName = "Erosion Measurements"
        Me.ErosionMeasurementsBox.Controls.Add(Me.SedimentLocationLabel)
        Me.ErosionMeasurementsBox.Controls.Add(Me.SedimentDistanceControl)
        Me.ErosionMeasurementsBox.Controls.Add(Me.SedimentDistanceLabel)
        Me.ErosionMeasurementsBox.Controls.Add(Me.SedimentTimeControl)
        Me.ErosionMeasurementsBox.Controls.Add(Me.SedimentTimeeLabel)
        Me.ErosionMeasurementsBox.Controls.Add(Me.CGmControl)
        Me.ErosionMeasurementsBox.Controls.Add(Me.CGmLabel)
        Me.ErosionMeasurementsBox.Location = New System.Drawing.Point(472, 216)
        Me.ErosionMeasurementsBox.Name = "ErosionMeasurementsBox"
        Me.ErosionMeasurementsBox.Size = New System.Drawing.Size(272, 112)
        Me.ErosionMeasurementsBox.TabIndex = 5
        Me.ErosionMeasurementsBox.TabStop = False
        Me.ErosionMeasurementsBox.Text = "Erosion Measurements"
        '
        'SedimentLocationLabel
        '
        Me.SedimentLocationLabel.Location = New System.Drawing.Point(56, 72)
        Me.SedimentLocationLabel.Name = "SedimentLocationLabel"
        Me.SedimentLocationLabel.Size = New System.Drawing.Size(32, 23)
        Me.SedimentLocationLabel.TabIndex = 6
        Me.SedimentLocationLabel.Text = "At:"
        Me.SedimentLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SedimentDistanceControl
        '
        Me.SedimentDistanceControl.AccessibleDescription = "Distance at which CGm was measured.  Currently fixed at 1/4 of the length of the " & _
            "field."
        Me.SedimentDistanceControl.AccessibleName = "Distance"
        Me.SedimentDistanceControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SedimentDistanceControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SedimentDistanceControl.IsCalculated = False
        Me.SedimentDistanceControl.IsInteger = False
        Me.SedimentDistanceControl.Location = New System.Drawing.Point(152, 80)
        Me.SedimentDistanceControl.Name = "SedimentDistanceControl"
        Me.SedimentDistanceControl.Size = New System.Drawing.Size(112, 24)
        Me.SedimentDistanceControl.TabIndex = 5
        Me.SedimentDistanceControl.ToBeCalculated = True
        Me.SedimentDistanceControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SedimentDistanceControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SedimentDistanceControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SedimentDistanceControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SedimentDistanceControl.ValueText = ""
        '
        'SedimentDistanceLabel
        '
        Me.SedimentDistanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SedimentDistanceLabel.Location = New System.Drawing.Point(88, 80)
        Me.SedimentDistanceLabel.Name = "SedimentDistanceLabel"
        Me.SedimentDistanceLabel.Size = New System.Drawing.Size(64, 23)
        Me.SedimentDistanceLabel.TabIndex = 4
        Me.SedimentDistanceLabel.Text = "Distance"
        Me.SedimentDistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SedimentTimeControl
        '
        Me.SedimentTimeControl.AccessibleDescription = "Time at which CGm was measured."
        Me.SedimentTimeControl.AccessibleName = "Time"
        Me.SedimentTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SedimentTimeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SedimentTimeControl.IsCalculated = False
        Me.SedimentTimeControl.IsInteger = False
        Me.SedimentTimeControl.Location = New System.Drawing.Point(152, 56)
        Me.SedimentTimeControl.Name = "SedimentTimeControl"
        Me.SedimentTimeControl.Size = New System.Drawing.Size(112, 24)
        Me.SedimentTimeControl.TabIndex = 3
        Me.SedimentTimeControl.ToBeCalculated = True
        Me.SedimentTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SedimentTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SedimentTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SedimentTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SedimentTimeControl.ValueText = ""
        '
        'SedimentTimeeLabel
        '
        Me.SedimentTimeeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SedimentTimeeLabel.Location = New System.Drawing.Point(88, 56)
        Me.SedimentTimeeLabel.Name = "SedimentTimeeLabel"
        Me.SedimentTimeeLabel.Size = New System.Drawing.Size(64, 23)
        Me.SedimentTimeeLabel.TabIndex = 2
        Me.SedimentTimeeLabel.Text = "T&ime"
        Me.SedimentTimeeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CGmControl
        '
        Me.CGmControl.AccessibleDescription = "Measured amount of soil (grams per liter) in the irrigation water."
        Me.CGmControl.AccessibleName = "CGm"
        Me.CGmControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CGmControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CGmControl.IsCalculated = False
        Me.CGmControl.IsInteger = False
        Me.CGmControl.Location = New System.Drawing.Point(64, 24)
        Me.CGmControl.Name = "CGmControl"
        Me.CGmControl.Size = New System.Drawing.Size(112, 24)
        Me.CGmControl.TabIndex = 1
        Me.CGmControl.ToBeCalculated = True
        Me.CGmControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CGmControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CGmControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CGmControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CGmControl.ValueText = ""
        '
        'CGmLabel
        '
        Me.CGmLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CGmLabel.Location = New System.Drawing.Point(16, 24)
        Me.CGmLabel.Name = "CGmLabel"
        Me.CGmLabel.Size = New System.Drawing.Size(48, 23)
        Me.CGmLabel.TabIndex = 0
        Me.CGmLabel.Text = "CG&m"
        Me.CGmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EditSandSiltClayTable
        '
        Me.EditSandSiltClayTable.AccessibleDescription = "Displays dialog box for editing a Sediment Components table using Sand / Silt / C" & _
            "lay components."
        Me.EditSandSiltClayTable.AccessibleName = "Edit Sediment Components Table"
        Me.EditSandSiltClayTable.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EditSandSiltClayTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditSandSiltClayTable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EditSandSiltClayTable.Location = New System.Drawing.Point(16, 200)
        Me.EditSandSiltClayTable.Name = "EditSandSiltClayTable"
        Me.EditSandSiltClayTable.Size = New System.Drawing.Size(440, 23)
        Me.EditSandSiltClayTable.TabIndex = 1
        Me.EditSandSiltClayTable.Text = "&Edit Sand / Silt / Clay Sediment Components Table ..."
        Me.EditSandSiltClayTable.UseVisualStyleBackColor = False
        '
        'ProgrammerPanel
        '
        Me.ProgrammerPanel.AccessibleDescription = "Programmer level parameters"
        Me.ProgrammerPanel.AccessibleName = "Erosion Coefficient and Full Scale G"
        Me.ProgrammerPanel.Controls.Add(Me.FullScaleGControl)
        Me.ProgrammerPanel.Controls.Add(Me.FullScaleGLabel)
        Me.ProgrammerPanel.Controls.Add(Me.ErosionCoefficientControl)
        Me.ProgrammerPanel.Controls.Add(Me.ErosionCoefficientLabel)
        Me.ProgrammerPanel.Location = New System.Drawing.Point(472, 336)
        Me.ProgrammerPanel.Name = "ProgrammerPanel"
        Me.ProgrammerPanel.Size = New System.Drawing.Size(272, 64)
        Me.ProgrammerPanel.TabIndex = 6
        '
        'FullScaleGControl
        '
        Me.FullScaleGControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.FullScaleGControl.IsCalculated = False
        Me.FullScaleGControl.IsInteger = False
        Me.FullScaleGControl.Location = New System.Drawing.Point(152, 32)
        Me.FullScaleGControl.Name = "FullScaleGControl"
        Me.FullScaleGControl.Size = New System.Drawing.Size(104, 24)
        Me.FullScaleGControl.TabIndex = 3
        Me.FullScaleGControl.ToBeCalculated = True
        Me.FullScaleGControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.FullScaleGControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.FullScaleGControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.FullScaleGControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.FullScaleGControl.ValueText = ""
        '
        'FullScaleGLabel
        '
        Me.FullScaleGLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FullScaleGLabel.Location = New System.Drawing.Point(48, 32)
        Me.FullScaleGLabel.Name = "FullScaleGLabel"
        Me.FullScaleGLabel.Size = New System.Drawing.Size(104, 23)
        Me.FullScaleGLabel.TabIndex = 2
        Me.FullScaleGLabel.Text = "Full Scale &G"
        Me.FullScaleGLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErosionCoefficientControl
        '
        Me.ErosionCoefficientControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ErosionCoefficientControl.IsCalculated = False
        Me.ErosionCoefficientControl.IsInteger = False
        Me.ErosionCoefficientControl.Location = New System.Drawing.Point(152, 8)
        Me.ErosionCoefficientControl.Name = "ErosionCoefficientControl"
        Me.ErosionCoefficientControl.Size = New System.Drawing.Size(112, 24)
        Me.ErosionCoefficientControl.TabIndex = 1
        Me.ErosionCoefficientControl.ToBeCalculated = True
        Me.ErosionCoefficientControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ErosionCoefficientControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ErosionCoefficientControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ErosionCoefficientControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ErosionCoefficientControl.ValueText = ""
        '
        'ErosionCoefficientLabel
        '
        Me.ErosionCoefficientLabel.Location = New System.Drawing.Point(8, 8)
        Me.ErosionCoefficientLabel.Name = "ErosionCoefficientLabel"
        Me.ErosionCoefficientLabel.Size = New System.Drawing.Size(144, 23)
        Me.ErosionCoefficientLabel.TabIndex = 0
        Me.ErosionCoefficientLabel.Text = "Erosion C&oefficient"
        Me.ErosionCoefficientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ParticleSizeDistributionBox
        '
        Me.ParticleSizeDistributionBox.AccessibleName = "Particle Size Distribution"
        Me.ParticleSizeDistributionBox.Controls.Add(Me.FitControl)
        Me.ParticleSizeDistributionBox.Controls.Add(Me.FitLabel)
        Me.ParticleSizeDistributionBox.Controls.Add(Me.ResolutionControl)
        Me.ParticleSizeDistributionBox.Controls.Add(Me.ResolutionLabel)
        Me.ParticleSizeDistributionBox.Location = New System.Drawing.Point(472, 16)
        Me.ParticleSizeDistributionBox.Name = "ParticleSizeDistributionBox"
        Me.ParticleSizeDistributionBox.Size = New System.Drawing.Size(272, 96)
        Me.ParticleSizeDistributionBox.TabIndex = 3
        Me.ParticleSizeDistributionBox.TabStop = False
        Me.ParticleSizeDistributionBox.Text = "Particle Size Distribution"
        '
        'FitControl
        '
        Me.FitControl.ApplicationValue = -1
        Me.FitControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FitControl.EnableSaveActions = False
        Me.FitControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FitControl.IsCalculated = False
        Me.FitControl.Location = New System.Drawing.Point(96, 56)
        Me.FitControl.Name = "FitControl"
        Me.FitControl.SelectedIndexSet = False
        Me.FitControl.Size = New System.Drawing.Size(160, 24)
        Me.FitControl.TabIndex = 3
        '
        'FitLabel
        '
        Me.FitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FitLabel.Location = New System.Drawing.Point(16, 56)
        Me.FitLabel.Name = "FitLabel"
        Me.FitLabel.Size = New System.Drawing.Size(80, 23)
        Me.FitLabel.TabIndex = 2
        Me.FitLabel.Text = "&Fit"
        Me.FitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ResolutionControl
        '
        Me.ResolutionControl.ApplicationValue = -1
        Me.ResolutionControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ResolutionControl.EnableSaveActions = False
        Me.ResolutionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResolutionControl.IsCalculated = False
        Me.ResolutionControl.Location = New System.Drawing.Point(96, 24)
        Me.ResolutionControl.Name = "ResolutionControl"
        Me.ResolutionControl.SelectedIndexSet = False
        Me.ResolutionControl.Size = New System.Drawing.Size(160, 24)
        Me.ResolutionControl.TabIndex = 1
        '
        'ResolutionLabel
        '
        Me.ResolutionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResolutionLabel.Location = New System.Drawing.Point(16, 24)
        Me.ResolutionLabel.Name = "ResolutionLabel"
        Me.ResolutionLabel.Size = New System.Drawing.Size(80, 23)
        Me.ResolutionLabel.TabIndex = 0
        Me.ResolutionLabel.Text = "&Resolution"
        Me.ResolutionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SoilErodibilityBox
        '
        Me.SoilErodibilityBox.AccessibleDescription = "Parameters descibing the erodibility of the field's soil."
        Me.SoilErodibilityBox.AccessibleName = "Soil Erodibility"
        Me.SoilErodibilityBox.Controls.Add(Me.KrBetaUnits)
        Me.SoilErodibilityBox.Controls.Add(Me.ComputeTauCBeta)
        Me.SoilErodibilityBox.Controls.Add(Me.ErodibilityBetaControl)
        Me.SoilErodibilityBox.Controls.Add(Me.ErodibilityBetaLabel)
        Me.SoilErodibilityBox.Controls.Add(Me.ErodibilityTaucControl)
        Me.SoilErodibilityBox.Controls.Add(Me.ErodibilityTaucLabel)
        Me.SoilErodibilityBox.Controls.Add(Me.ErodibilityBControl)
        Me.SoilErodibilityBox.Controls.Add(Me.ErodibilityBLabel)
        Me.SoilErodibilityBox.Controls.Add(Me.ErodibilityAControl)
        Me.SoilErodibilityBox.Controls.Add(Me.ErodibilityALabel)
        Me.SoilErodibilityBox.Controls.Add(Me.ToDescription)
        Me.SoilErodibilityBox.Controls.Add(Me.KRequation)
        Me.SoilErodibilityBox.Controls.Add(Me.TaucDescription)
        Me.SoilErodibilityBox.Controls.Add(Me.DRequation)
        Me.SoilErodibilityBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoilErodibilityBox.Location = New System.Drawing.Point(16, 240)
        Me.SoilErodibilityBox.Name = "SoilErodibilityBox"
        Me.SoilErodibilityBox.Size = New System.Drawing.Size(440, 160)
        Me.SoilErodibilityBox.TabIndex = 2
        Me.SoilErodibilityBox.TabStop = False
        Me.SoilErodibilityBox.Text = "Soil Erodibility"
        '
        'KrBetaUnits
        '
        Me.KrBetaUnits.Image = CType(resources.GetObject("KrBetaUnits.Image"), System.Drawing.Image)
        Me.KrBetaUnits.Location = New System.Drawing.Point(114, 64)
        Me.KrBetaUnits.Name = "KrBetaUnits"
        Me.KrBetaUnits.Size = New System.Drawing.Size(136, 24)
        Me.KrBetaUnits.TabIndex = 13
        Me.KrBetaUnits.TabStop = False
        '
        'ComputeTauCBeta
        '
        Me.ComputeTauCBeta.AccessibleDescription = "Causes WinSRFR to compute TauC and Beta based on field data."
        Me.ComputeTauCBeta.AccessibleName = "Compute TauC & Beta"
        Me.ComputeTauCBeta.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ComputeTauCBeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComputeTauCBeta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ComputeTauCBeta.Location = New System.Drawing.Point(264, 124)
        Me.ComputeTauCBeta.Name = "ComputeTauCBeta"
        Me.ComputeTauCBeta.Size = New System.Drawing.Size(160, 23)
        Me.ComputeTauCBeta.TabIndex = 12
        Me.ComputeTauCBeta.Text = "&Compute TauC && Beta"
        Me.ComputeTauCBeta.UseVisualStyleBackColor = False
        '
        'ErodibilityBetaControl
        '
        Me.ErodibilityBetaControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ErodibilityBetaControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErodibilityBetaControl.IsCalculated = False
        Me.ErodibilityBetaControl.IsInteger = False
        Me.ErodibilityBetaControl.Location = New System.Drawing.Point(320, 92)
        Me.ErodibilityBetaControl.Name = "ErodibilityBetaControl"
        Me.ErodibilityBetaControl.Size = New System.Drawing.Size(112, 24)
        Me.ErodibilityBetaControl.TabIndex = 11
        Me.ErodibilityBetaControl.ToBeCalculated = True
        Me.ErodibilityBetaControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ErodibilityBetaControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ErodibilityBetaControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ErodibilityBetaControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ErodibilityBetaControl.ValueText = ""
        '
        'ErodibilityBetaLabel
        '
        Me.ErodibilityBetaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErodibilityBetaLabel.Location = New System.Drawing.Point(264, 92)
        Me.ErodibilityBetaLabel.Name = "ErodibilityBetaLabel"
        Me.ErodibilityBetaLabel.Size = New System.Drawing.Size(48, 23)
        Me.ErodibilityBetaLabel.TabIndex = 10
        Me.ErodibilityBetaLabel.Text = "B&eta"
        Me.ErodibilityBetaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErodibilityTaucControl
        '
        Me.ErodibilityTaucControl.AccessibleDescription = "Threshhold value of shear below which no soil detachment takes place."
        Me.ErodibilityTaucControl.AccessibleName = "TauC"
        Me.ErodibilityTaucControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ErodibilityTaucControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErodibilityTaucControl.IsCalculated = False
        Me.ErodibilityTaucControl.IsInteger = False
        Me.ErodibilityTaucControl.Location = New System.Drawing.Point(320, 68)
        Me.ErodibilityTaucControl.Name = "ErodibilityTaucControl"
        Me.ErodibilityTaucControl.Size = New System.Drawing.Size(112, 24)
        Me.ErodibilityTaucControl.TabIndex = 9
        Me.ErodibilityTaucControl.ToBeCalculated = True
        Me.ErodibilityTaucControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ErodibilityTaucControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ErodibilityTaucControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ErodibilityTaucControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ErodibilityTaucControl.ValueText = ""
        '
        'ErodibilityTaucLabel
        '
        Me.ErodibilityTaucLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErodibilityTaucLabel.Location = New System.Drawing.Point(264, 68)
        Me.ErodibilityTaucLabel.Name = "ErodibilityTaucLabel"
        Me.ErodibilityTaucLabel.Size = New System.Drawing.Size(48, 23)
        Me.ErodibilityTaucLabel.TabIndex = 8
        Me.ErodibilityTaucLabel.Text = "&TauC"
        Me.ErodibilityTaucLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErodibilityBControl
        '
        Me.ErodibilityBControl.AccessibleName = ""
        Me.ErodibilityBControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ErodibilityBControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErodibilityBControl.IsCalculated = False
        Me.ErodibilityBControl.IsInteger = False
        Me.ErodibilityBControl.Location = New System.Drawing.Point(48, 92)
        Me.ErodibilityBControl.Name = "ErodibilityBControl"
        Me.ErodibilityBControl.Size = New System.Drawing.Size(112, 24)
        Me.ErodibilityBControl.TabIndex = 7
        Me.ErodibilityBControl.ToBeCalculated = True
        Me.ErodibilityBControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ErodibilityBControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ErodibilityBControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ErodibilityBControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ErodibilityBControl.ValueText = ""
        '
        'ErodibilityBLabel
        '
        Me.ErodibilityBLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErodibilityBLabel.Location = New System.Drawing.Point(16, 92)
        Me.ErodibilityBLabel.Name = "ErodibilityBLabel"
        Me.ErodibilityBLabel.Size = New System.Drawing.Size(32, 23)
        Me.ErodibilityBLabel.TabIndex = 6
        Me.ErodibilityBLabel.Text = "&B"
        Me.ErodibilityBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErodibilityAControl
        '
        Me.ErodibilityAControl.AccessibleName = ""
        Me.ErodibilityAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ErodibilityAControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErodibilityAControl.IsCalculated = False
        Me.ErodibilityAControl.IsInteger = False
        Me.ErodibilityAControl.Location = New System.Drawing.Point(48, 68)
        Me.ErodibilityAControl.Name = "ErodibilityAControl"
        Me.ErodibilityAControl.Size = New System.Drawing.Size(112, 24)
        Me.ErodibilityAControl.TabIndex = 5
        Me.ErodibilityAControl.ToBeCalculated = True
        Me.ErodibilityAControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ErodibilityAControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ErodibilityAControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ErodibilityAControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ErodibilityAControl.ValueText = ""
        '
        'ErodibilityALabel
        '
        Me.ErodibilityALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErodibilityALabel.Location = New System.Drawing.Point(16, 68)
        Me.ErodibilityALabel.Name = "ErodibilityALabel"
        Me.ErodibilityALabel.Size = New System.Drawing.Size(32, 23)
        Me.ErodibilityALabel.TabIndex = 4
        Me.ErodibilityALabel.Text = "&A"
        Me.ErodibilityALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToDescription
        '
        Me.ToDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDescription.Location = New System.Drawing.Point(264, 40)
        Me.ToDescription.Name = "ToDescription"
        Me.ToDescription.Size = New System.Drawing.Size(160, 23)
        Me.ToDescription.TabIndex = 3
        Me.ToDescription.Text = "To:       Wetting time"
        '
        'KRequation
        '
        Me.KRequation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KRequation.Location = New System.Drawing.Point(16, 40)
        Me.KRequation.Name = "KRequation"
        Me.KRequation.Size = New System.Drawing.Size(160, 23)
        Me.KRequation.TabIndex = 2
        Me.KRequation.Text = "KR = A + B * Ln(To)"
        '
        'TaucDescription
        '
        Me.TaucDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaucDescription.Location = New System.Drawing.Point(264, 20)
        Me.TaucDescription.Name = "TaucDescription"
        Me.TaucDescription.Size = New System.Drawing.Size(160, 23)
        Me.TaucDescription.TabIndex = 1
        Me.TaucDescription.Text = "TauC:  Critical shear stress"
        '
        'DRequation
        '
        Me.DRequation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DRequation.Location = New System.Drawing.Point(16, 20)
        Me.DRequation.Name = "DRequation"
        Me.DRequation.Size = New System.Drawing.Size(160, 23)
        Me.DRequation.TabIndex = 0
        Me.DRequation.Text = "DR = KR * (Tau-TauC)^Beta"
        '
        'SedimentComponentsControl
        '
        Me.SedimentComponentsControl.AccessibleDescription = "Table specifying the component makeup of the soil."
        Me.SedimentComponentsControl.AccessibleName = "Sediment Components"
        Me.SedimentComponentsControl.AllRowsFixed = False
        Me.SedimentComponentsControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.SedimentComponentsControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.SedimentComponentsControl.CaptionText = "Sediment Components"
        Me.SedimentComponentsControl.DataMember = ""
        Me.SedimentComponentsControl.EnableSaveActions = False
        Me.SedimentComponentsControl.FirstColumnIncreases = False
        Me.SedimentComponentsControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.SedimentComponentsControl.FirstColumnMinimum = 0
        Me.SedimentComponentsControl.FirstRowFixed = False
        Me.SedimentComponentsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SedimentComponentsControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.SedimentComponentsControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.SedimentComponentsControl.Location = New System.Drawing.Point(16, 24)
        Me.SedimentComponentsControl.MaxRows = 50
        Me.SedimentComponentsControl.MinRows = 1
        Me.SedimentComponentsControl.Name = "SedimentComponentsControl"
        Me.SedimentComponentsControl.SecondColumnIncreases = False
        Me.SedimentComponentsControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.SedimentComponentsControl.SecondColumnMinimum = 0
        Me.SedimentComponentsControl.Size = New System.Drawing.Size(440, 168)
        Me.SedimentComponentsControl.TabIndex = 0
        Me.SedimentComponentsControl.TableReadonly = False
        '
        'ctl_Erosion
        '
        Me.AccessibleDescription = "Controls for specifying erosion parameters."
        Me.AccessibleName = "Erosion"
        Me.Controls.Add(Me.ErosionBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_Erosion"
        Me.Size = New System.Drawing.Size(780, 430)
        Me.ErosionBox.ResumeLayout(False)
        Me.Test_Panel.ResumeLayout(False)
        Me.SedimentParticleBox.ResumeLayout(False)
        Me.CriticalShearBox.ResumeLayout(False)
        Me.IrrigationWaterBox.ResumeLayout(False)
        Me.ErosionMeasurementsBox.ResumeLayout(False)
        Me.ProgrammerPanel.ResumeLayout(False)
        Me.ParticleSizeDistributionBox.ResumeLayout(False)
        Me.SoilErodibilityBox.ResumeLayout(False)
        CType(Me.KrBetaUnits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SedimentComponentsControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Field data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm

    Private mMyStore As DataStore.ObjectNode
    Private WithEvents mWinSRFR As WinSRFR

    Private WithEvents mEventCriteria As EventCriteria
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Private WithEvents mErosion As Erosion
    Private WithEvents mUnitControl As UnitControl
    '
    ' Supported analysis
    '
    Private mAnalysis As Analysis
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mUserPreferences As UserPreferences = UserPreferences.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow, _
                           ByVal _analysis As Analysis)

        Debug.Assert(Not (_unit Is Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mMyStore = mUnit.MyStore

        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mEventCriteria = mUnit.EventCriteriaRef
        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mErosion = mUnit.ErosionRef
        mUnitControl = mUnit.UnitControlRef

        mWorldWindow = worldWindow

        If (_analysis Is Nothing) Then
            mAnalysis = New ErosionAnalysis(mUnit, mWorldWindow)
        Else
            mAnalysis = _analysis
        End If

        ' Link the contained controls to their models & store
        Me.ErodibilityAControl.LinkToModel(mMyStore, mSoilCropProperties.ErodibilityAProperty)
        Me.ErodibilityBControl.LinkToModel(mMyStore, mSoilCropProperties.ErodibilityBProperty)
        Me.ErodibilityTaucControl.LinkToModel(mMyStore, mSoilCropProperties.ErodibilityTaucProperty)
        Me.ErodibilityBetaControl.LinkToModel(mMyStore, mSoilCropProperties.ErodibilityBetaProperty)
        Me.FullScaleGControl.LinkToModel(mMyStore, mSoilCropProperties.FullScaleGProperty)

        Me.ResolutionControl.LinkToModel(mMyStore, mSoilCropProperties.ErosionResolutionProperty)
        Me.FitControl.LinkToModel(mMyStore, mSoilCropProperties.ErosionFitProperty)
        Me.ErosionCoefficientControl.LinkToModel(mMyStore, mSoilCropProperties.ErosionCoefficientProperty)

        Me.TemperatureControl.LinkToModel(mMyStore, mErosion.WaterTempProperty)
        Me.KinematicViscosityControl.LinkToModel(mMyStore, mErosion.KinematicViscosityProperty)

        Me.DsControl.LinkToModel(mMyStore, mErosion.ParticleDiameterProperty)
        Me.SgControl.LinkToModel(mMyStore, mErosion.SpecificGravityProperty)
        Me.TcsControl.LinkToModel(mMyStore, mErosion.CriticalShearProperty)
        Me.KrControl.LinkToModel(mMyStore, mErosion.KrProperty)
        Me.UserEnterCriticalShear.LinkToModel(mMyStore, mErosion.EnableCriticalShearProperty)

        Me.CGmControl.LinkToModel(mMyStore, mSoilCropProperties.SedimentConcentrationProperty)
        Me.SedimentTimeControl.LinkToModel(mMyStore, mSoilCropProperties.SedimentTimeProperty)
        Me.SedimentDistanceControl.LinkToModel(mMyStore, mSoilCropProperties.SedimentDistanceProperty)

        ' Sediment Components table
        Me.SedimentComponentsControl.LinkToModel(mMyStore, mSoilCropProperties.SedimentComponentsProperty)
        Me.SedimentComponentsControl.UpdateUI()

        ' Update the control's User Interface
        UpdateUI()

    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model objects
    '
    Public Sub UpdateUI()
        ' Update the UI only if it is linked to a model object
        If Not (mUnit Is Nothing) Then

            If (mErosion.EnableCriticalShear.Value) Then
                Me.TcsControl.Show()
            Else
                Me.TcsControl.Hide()
            End If

            ' Update selection lists
            Me.ResolutionControl.Clear()
            Dim _sel As String = mSoilCropProperties.GetFirstErosionResolutionSelection
            Dim _idx As Integer = 0
            While Not (_sel Is Nothing)
                If Not (_sel = String.Empty) Then
                    Me.ResolutionControl.Add(_sel, _idx)
                End If
                _sel = mSoilCropProperties.GetNextErosionResolutionSelection
                _idx += 1
            End While

            Me.FitControl.Clear()
            _sel = mSoilCropProperties.GetFirstErosionFitSelection
            _idx = 0
            While Not (_sel Is Nothing)
                If Not (_sel = String.Empty) Then
                    Me.FitControl.Add(_sel, _idx)
                End If
                _sel = mSoilCropProperties.GetNextErosionFitSelection
                _idx += 1
            End While

            ' Update selections
            Me.ResolutionControl.UpdateUI()
            Me.FitControl.UpdateUI()

            ' Make World adjustments
            Select Case (mWorld.WorldType.Value)
                Case WorldTypes.EventWorld
                    Me.ComputeTauCBeta.Hide()
                    Me.ErosionMeasurementsBox.Show()

                    ' Update calculated fields
                    If (mSoilCropProperties.ErodibilityA.Source = ValueSources.Defaulted) Then
                        mSoilCropProperties.ErodibilityAProperty.ToBeCalculated = True
                    End If

                    If (mSoilCropProperties.ErodibilityB.Source = ValueSources.Defaulted) Then
                        mSoilCropProperties.ErodibilityBProperty.ToBeCalculated = True
                    End If

                    If (mSoilCropProperties.ErodibilityTauc.Source = ValueSources.Defaulted) Then
                        mSoilCropProperties.ErodibilityTaucProperty.ToBeCalculated = True
                    End If

                    If (mSoilCropProperties.ErodibilityBeta.Source = ValueSources.Defaulted) Then
                        mSoilCropProperties.ErodibilityBetaProperty.ToBeCalculated = True
                    End If

                Case WorldTypes.SimulationWorld
                    Me.ComputeTauCBeta.Show()
                    Me.ErosionMeasurementsBox.Hide()
                Case Else
                    Debug.Assert(False, "Support for World must be added")
            End Select

            ' Make Programmer / non-Programmer adjustments
            If (WinSRFR.IsResearchLevel) Then
                Me.KRequation.Show()
                Me.ToDescription.Show()
                Me.ErodibilityALabel.Text = "&A"
                Me.ErodibilityBLabel.Show()
                Me.ErodibilityBControl.Show()
                Me.ProgrammerPanel.Show()
            Else
                Me.KRequation.Hide()
                Me.ToDescription.Hide()
                Me.ErodibilityALabel.Text = "&KR"
                Me.ErodibilityBLabel.Hide()
                Me.ErodibilityBControl.Hide()
                Me.ProgrammerPanel.Hide()
            End If

            ' Units display for KR/A vary depending on Beta
            If (mSoilCropProperties.ErodibilityBeta.Value = 1.0) Then
                Me.KrBetaUnits.Hide()
            Else
                Me.KrBetaUnits.Show()
            End If

        End If
    End Sub

    Private Sub WaterTempControl_ControlValueChanged() _
    Handles TemperatureControl.ControlValueChanged
        ' Update Kinematic Viscosity to match
        Dim tempC As Double = mErosion.WaterTemp.Value
        Dim v As Double = KinematicViscosity(tempC)

        Dim parameter As DoubleParameter = mErosion.KinematicViscosity
        parameter.Value = v
        parameter.Source = ValueSources.Calculated
        mErosion.KinematicViscosity = parameter

    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal _reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated
        ' Update the UI to reflect the new User Level
        UpdateUI()
    End Sub
    '
    ' Update UI when any Soil/Crop Property value changes
    '
    Private Sub SoilCropProperties_PropertyChanged(ByVal _reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when any Erosion Property value changes
    '
    Private Sub Erosion_PropertyChanged(ByVal _reason As Erosion.Reasons) _
    Handles mErosion.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        ' Don't allow event driven updates prior to initialization
        If Not (mSoilCropProperties Is Nothing) Then
            UpdateUI()
        End If
    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub ComputeTauCBeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ComputeTauCBeta.Click
        ' Set this as Undo point
        mUnit.MyStore.MarkForUndo(mDictionary.tComputeTauCBeta.Translated)

        ' Compute & save TauC
        Dim TauC As Double = mSoilCropProperties.ComputedErodibilityTauC

        Dim parameter As DoubleParameter = mSoilCropProperties.ErodibilityTauc
        parameter.Value = TauC
        parameter.Source = ValueSources.Calculated
        mSoilCropProperties.ErodibilityTauc = parameter

        mSoilCropProperties.ErodibilityTaucProperty.ToBeCalculated = False

        ' Save default Beta
        parameter = mSoilCropProperties.ErodibilityBeta
        parameter.Value = DefaultErodibilityBeta
        parameter.Source = ValueSources.Calculated
        mSoilCropProperties.ErodibilityBeta = parameter

        mSoilCropProperties.ErodibilityBetaProperty.ToBeCalculated = False
    End Sub

    Private Sub EditSandSiltClayTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditSandSiltClayTable.Click
        Dim db As SandSiltClayTable = New SandSiltClayTable(mUnit)

        UpdateTranslation(db)

        Dim result As DialogResult = DialogResult.None
        result = db.ShowDialog
    End Sub

    Private Sub SedimentComponentsControl_ControlValueChanged() _
    Handles SedimentComponentsControl.ControlValueChanged
        mAnalysis.CheckSetupErrors()
        If (mAnalysis.HasSetupErrors) Then
            Dim errorList As ArrayList = mAnalysis.SetupErrorItems
            Dim errorItem As Analysis.ErrorWarningItem = errorList(0)
            Dim errID As String = errorItem.ID
            SedimentComponentsControl.ErrorProvider.SetError(SedimentComponentsControl, errID)
        End If
    End Sub

#End Region

End Class
