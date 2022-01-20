
'**********************************************************************************************
' ctl_SystemGeometry - UI for viewing & editing the System Geometry data
'
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI
Imports Srfr

Public Class ctl_SystemGeometry
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
    Friend WithEvents TitlePanel As System.Windows.Forms.Panel
    Friend WithEvents SystemGeometryLabel As System.Windows.Forms.Label
    Friend WithEvents FurrowShapeBox As DataStore.ctl_GroupBox
    Friend WithEvents PowerLawPanel As DataStore.ctl_Panel
    Friend WithEvents PowerLawExponentLabel As DataStore.ctl_Label
    Friend WithEvents WidthAt100mmLabel As DataStore.ctl_Label
    Friend WithEvents BorderWidthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BorderWidthLabel As DataStore.ctl_Label
    Friend WithEvents PowerLawExponentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WidthAt100mmControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BottomDescriptionBox As DataStore.ctl_GroupBox
    Friend WithEvents AverageSlopePanel As DataStore.ctl_Panel
    Friend WithEvents SlopePanel As DataStore.ctl_Panel
    Friend WithEvents SlopeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SlopeLabel As DataStore.ctl_Label
    Friend WithEvents FurrowShapeControl As DataStore.ctl_SelectParameter
    Friend WithEvents FurrowSpacingControl As DataStore.ctl_DoubleParameter
    Friend WithEvents FurrowSpacingLabel As DataStore.ctl_Label
    Friend WithEvents TrapezoidPanel As DataStore.ctl_Panel
    Friend WithEvents SideSlopeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BottomWidthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SideSlopeLabel As DataStore.ctl_Label
    Friend WithEvents BottomWidthLabel As DataStore.ctl_Label
    Friend WithEvents BottomDescriptionControl As DataStore.ctl_SelectParameter
    Friend WithEvents EditSlopeTableButton As DataStore.ctl_Button
    Friend WithEvents FurrowLengthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents FurrowLengthLabel As DataStore.ctl_Label
    Friend WithEvents BorderLengthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BorderLengthLabel As DataStore.ctl_Label
    Friend WithEvents BorderDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BorderDepthLabel As DataStore.ctl_Label
    Friend WithEvents SystemGeometryGraphics As GraphingUI.ex_PictureBox
    Friend WithEvents VaryByDistanceLabel As DataStore.ctl_Label
    Friend WithEvents VaryByDistanceTimeLabel As DataStore.ctl_Label
    Friend WithEvents EditFurrowShapeButton As DataStore.ctl_Button
    Friend WithEvents PowerLawConstantLabel As DataStore.ctl_Label
    Friend WithEvents PowerLawDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents PowerLawDepthLabel As DataStore.ctl_Label
    Friend WithEvents TrapezoidDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents TrapezoidDepthLabel As DataStore.ctl_Label
    Friend WithEvents FurrowsPerSetLabel As DataStore.ctl_Label
    Friend WithEvents FurrowsPerSetControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BorderDimensionsBox As DataStore.ctl_GroupBox
    Friend WithEvents AverageSlopeLabel As DataStore.ctl_Label
    Friend WithEvents TopWidthLabel As DataStore.ctl_Label
    Friend WithEvents TabulatedFurrowSelect As DataStore.ctl_CheckParameter
    Friend WithEvents TrapezoidTablePanel As DataStore.ctl_Panel
    Friend WithEvents TrapezoidTableControl As ctl_TrapezoidTable
    Friend WithEvents PowerLawTablePanel As DataStore.ctl_Panel
    Friend WithEvents PowerLawTableControl As ctl_PowerLawTable
    Friend WithEvents BorderDepthTableControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedBorderDepthSelect As DataStore.ctl_CheckParameter
    Friend WithEvents CrossSectionLabel As DataStore.ctl_Label
    Friend WithEvents SetWidthLabel As DataStore.ctl_Label
    Friend WithEvents SetWidthValue As System.Windows.Forms.Label
    Friend WithEvents PowerLawConstantControl As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.TitlePanel = New System.Windows.Forms.Panel
        Me.SystemGeometryLabel = New System.Windows.Forms.Label
        Me.FurrowShapeBox = New DataStore.ctl_GroupBox
        Me.PowerLawPanel = New DataStore.ctl_Panel
        Me.PowerLawConstantControl = New DataStore.ctl_Label
        Me.PowerLawConstantLabel = New DataStore.ctl_Label
        Me.PowerLawExponentControl = New DataStore.ctl_DoubleParameter
        Me.PowerLawDepthControl = New DataStore.ctl_DoubleParameter
        Me.WidthAt100mmControl = New DataStore.ctl_DoubleParameter
        Me.PowerLawDepthLabel = New DataStore.ctl_Label
        Me.PowerLawExponentLabel = New DataStore.ctl_Label
        Me.WidthAt100mmLabel = New DataStore.ctl_Label
        Me.SetWidthValue = New System.Windows.Forms.Label
        Me.SetWidthLabel = New DataStore.ctl_Label
        Me.TrapezoidPanel = New DataStore.ctl_Panel
        Me.TrapezoidDepthControl = New DataStore.ctl_DoubleParameter
        Me.SideSlopeControl = New DataStore.ctl_DoubleParameter
        Me.BottomWidthControl = New DataStore.ctl_DoubleParameter
        Me.TrapezoidDepthLabel = New DataStore.ctl_Label
        Me.SideSlopeLabel = New DataStore.ctl_Label
        Me.BottomWidthLabel = New DataStore.ctl_Label
        Me.CrossSectionLabel = New DataStore.ctl_Label
        Me.TopWidthLabel = New DataStore.ctl_Label
        Me.PowerLawTablePanel = New DataStore.ctl_Panel
        Me.TrapezoidTablePanel = New DataStore.ctl_Panel
        Me.FurrowsPerSetControl = New DataStore.ctl_DoubleParameter
        Me.FurrowsPerSetLabel = New DataStore.ctl_Label
        Me.FurrowLengthControl = New DataStore.ctl_DoubleParameter
        Me.FurrowLengthLabel = New DataStore.ctl_Label
        Me.FurrowSpacingControl = New DataStore.ctl_DoubleParameter
        Me.FurrowSpacingLabel = New DataStore.ctl_Label
        Me.EditFurrowShapeButton = New DataStore.ctl_Button
        Me.TabulatedFurrowSelect = New DataStore.ctl_CheckParameter
        Me.FurrowShapeControl = New DataStore.ctl_SelectParameter
        Me.BorderDimensionsBox = New DataStore.ctl_GroupBox
        Me.BorderDepthTableControl = New DataStore.ctl_DataTableParameter
        Me.TabulatedBorderDepthSelect = New DataStore.ctl_CheckParameter
        Me.BorderDepthControl = New DataStore.ctl_DoubleParameter
        Me.BorderLengthControl = New DataStore.ctl_DoubleParameter
        Me.BorderDepthLabel = New DataStore.ctl_Label
        Me.BorderLengthLabel = New DataStore.ctl_Label
        Me.BorderWidthControl = New DataStore.ctl_DoubleParameter
        Me.BorderWidthLabel = New DataStore.ctl_Label
        Me.BottomDescriptionBox = New DataStore.ctl_GroupBox
        Me.EditSlopeTableButton = New DataStore.ctl_Button
        Me.BottomDescriptionControl = New DataStore.ctl_SelectParameter
        Me.VaryByDistanceLabel = New DataStore.ctl_Label
        Me.VaryByDistanceTimeLabel = New DataStore.ctl_Label
        Me.SlopePanel = New DataStore.ctl_Panel
        Me.SlopeControl = New DataStore.ctl_DoubleParameter
        Me.SlopeLabel = New DataStore.ctl_Label
        Me.AverageSlopePanel = New DataStore.ctl_Panel
        Me.AverageSlopeLabel = New DataStore.ctl_Label
        Me.SystemGeometryGraphics = New GraphingUI.ex_PictureBox
        Me.PowerLawTableControl = New WinMain.ctl_PowerLawTable
        Me.TrapezoidTableControl = New WinMain.ctl_TrapezoidTable
        Me.TitlePanel.SuspendLayout()
        Me.FurrowShapeBox.SuspendLayout()
        Me.PowerLawPanel.SuspendLayout()
        Me.TrapezoidPanel.SuspendLayout()
        Me.PowerLawTablePanel.SuspendLayout()
        Me.TrapezoidTablePanel.SuspendLayout()
        Me.BorderDimensionsBox.SuspendLayout()
        CType(Me.BorderDepthTableControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BottomDescriptionBox.SuspendLayout()
        Me.SlopePanel.SuspendLayout()
        Me.AverageSlopePanel.SuspendLayout()
        CType(Me.SystemGeometryGraphics, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PowerLawTableControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrapezoidTableControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TitlePanel
        '
        Me.TitlePanel.Controls.Add(Me.SystemGeometryLabel)
        Me.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitlePanel.Location = New System.Drawing.Point(0, 0)
        Me.TitlePanel.Name = "TitlePanel"
        Me.TitlePanel.Size = New System.Drawing.Size(780, 24)
        Me.TitlePanel.TabIndex = 1
        '
        'SystemGeometryLabel
        '
        Me.SystemGeometryLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemGeometryLabel.Location = New System.Drawing.Point(8, 2)
        Me.SystemGeometryLabel.Name = "SystemGeometryLabel"
        Me.SystemGeometryLabel.Size = New System.Drawing.Size(360, 20)
        Me.SystemGeometryLabel.TabIndex = 0
        Me.SystemGeometryLabel.Text = "System Geometry"
        '
        'FurrowShapeBox
        '
        Me.FurrowShapeBox.AccessibleDescription = "Set of parameters that define the shape and dimensions of the furrow."
        Me.FurrowShapeBox.AccessibleName = "Furrow Shape & Dimensions"
        Me.FurrowShapeBox.Controls.Add(Me.SetWidthValue)
        Me.FurrowShapeBox.Controls.Add(Me.SetWidthLabel)
        Me.FurrowShapeBox.Controls.Add(Me.TrapezoidPanel)
        Me.FurrowShapeBox.Controls.Add(Me.CrossSectionLabel)
        Me.FurrowShapeBox.Controls.Add(Me.TopWidthLabel)
        Me.FurrowShapeBox.Controls.Add(Me.PowerLawTablePanel)
        Me.FurrowShapeBox.Controls.Add(Me.TrapezoidTablePanel)
        Me.FurrowShapeBox.Controls.Add(Me.FurrowsPerSetControl)
        Me.FurrowShapeBox.Controls.Add(Me.FurrowsPerSetLabel)
        Me.FurrowShapeBox.Controls.Add(Me.FurrowLengthControl)
        Me.FurrowShapeBox.Controls.Add(Me.FurrowLengthLabel)
        Me.FurrowShapeBox.Controls.Add(Me.FurrowSpacingControl)
        Me.FurrowShapeBox.Controls.Add(Me.FurrowSpacingLabel)
        Me.FurrowShapeBox.Controls.Add(Me.EditFurrowShapeButton)
        Me.FurrowShapeBox.Controls.Add(Me.TabulatedFurrowSelect)
        Me.FurrowShapeBox.Controls.Add(Me.FurrowShapeControl)
        Me.FurrowShapeBox.Controls.Add(Me.PowerLawPanel)
        Me.FurrowShapeBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowShapeBox.Location = New System.Drawing.Point(8, 30)
        Me.FurrowShapeBox.Name = "FurrowShapeBox"
        Me.FurrowShapeBox.Size = New System.Drawing.Size(360, 292)
        Me.FurrowShapeBox.TabIndex = 2
        Me.FurrowShapeBox.TabStop = False
        Me.FurrowShapeBox.Text = "Furrow"
        '
        'PowerLawPanel
        '
        Me.PowerLawPanel.AccessibleDescription = "Set of parameters that define the dimensions of a power law furrow."
        Me.PowerLawPanel.AccessibleName = "Power Law Furrow Parameters"
        Me.PowerLawPanel.Controls.Add(Me.PowerLawConstantControl)
        Me.PowerLawPanel.Controls.Add(Me.PowerLawConstantLabel)
        Me.PowerLawPanel.Controls.Add(Me.PowerLawExponentControl)
        Me.PowerLawPanel.Controls.Add(Me.PowerLawDepthControl)
        Me.PowerLawPanel.Controls.Add(Me.WidthAt100mmControl)
        Me.PowerLawPanel.Controls.Add(Me.PowerLawDepthLabel)
        Me.PowerLawPanel.Controls.Add(Me.PowerLawExponentLabel)
        Me.PowerLawPanel.Controls.Add(Me.WidthAt100mmLabel)
        Me.PowerLawPanel.Location = New System.Drawing.Point(8, 150)
        Me.PowerLawPanel.Name = "PowerLawPanel"
        Me.PowerLawPanel.Size = New System.Drawing.Size(344, 136)
        Me.PowerLawPanel.TabIndex = 10
        '
        'PowerLawConstantControl
        '
        Me.PowerLawConstantControl.AccessibleDescription = "Displays computed Power Law Constant."
        Me.PowerLawConstantControl.AccessibleName = "Power Law Constant"
        Me.PowerLawConstantControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawConstantControl.Location = New System.Drawing.Point(168, 80)
        Me.PowerLawConstantControl.Name = "PowerLawConstantControl"
        Me.PowerLawConstantControl.Size = New System.Drawing.Size(152, 23)
        Me.PowerLawConstantControl.TabIndex = 7
        Me.PowerLawConstantControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PowerLawConstantLabel
        '
        Me.PowerLawConstantLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawConstantLabel.Location = New System.Drawing.Point(8, 80)
        Me.PowerLawConstantLabel.Name = "PowerLawConstantLabel"
        Me.PowerLawConstantLabel.Size = New System.Drawing.Size(143, 23)
        Me.PowerLawConstantLabel.TabIndex = 6
        Me.PowerLawConstantLabel.Text = "Constant, &C"
        Me.PowerLawConstantLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PowerLawExponentControl
        '
        Me.PowerLawExponentControl.AccessibleDescription = "Specifies power law exponent."
        Me.PowerLawExponentControl.AccessibleName = "Power Law Exponent"
        Me.PowerLawExponentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.PowerLawExponentControl.IsCalculated = False
        Me.PowerLawExponentControl.IsInteger = False
        Me.PowerLawExponentControl.Location = New System.Drawing.Point(160, 56)
        Me.PowerLawExponentControl.Name = "PowerLawExponentControl"
        Me.PowerLawExponentControl.Size = New System.Drawing.Size(160, 24)
        Me.PowerLawExponentControl.TabIndex = 5
        Me.PowerLawExponentControl.ToBeCalculated = True
        Me.PowerLawExponentControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.PowerLawExponentControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.PowerLawExponentControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.PowerLawExponentControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.PowerLawExponentControl.ValueText = ""
        '
        'PowerLawDepthControl
        '
        Me.PowerLawDepthControl.AccessibleDescription = "Specifies maximum depth of the power law furrow."
        Me.PowerLawDepthControl.AccessibleName = "Maximum Depth"
        Me.PowerLawDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.PowerLawDepthControl.IsCalculated = False
        Me.PowerLawDepthControl.IsInteger = False
        Me.PowerLawDepthControl.Location = New System.Drawing.Point(160, 8)
        Me.PowerLawDepthControl.Name = "PowerLawDepthControl"
        Me.PowerLawDepthControl.Size = New System.Drawing.Size(160, 24)
        Me.PowerLawDepthControl.TabIndex = 1
        Me.PowerLawDepthControl.ToBeCalculated = True
        Me.PowerLawDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.PowerLawDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.PowerLawDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.PowerLawDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.PowerLawDepthControl.ValueText = ""
        '
        'WidthAt100mmControl
        '
        Me.WidthAt100mmControl.AccessibleDescription = "Specifies width of a power law furrow at a depth of 100mm or 4 in from the furrow" & _
            "'s bottom."
        Me.WidthAt100mmControl.AccessibleName = "Width at 100mm or 4in"
        Me.WidthAt100mmControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WidthAt100mmControl.IsCalculated = False
        Me.WidthAt100mmControl.IsInteger = False
        Me.WidthAt100mmControl.Location = New System.Drawing.Point(160, 32)
        Me.WidthAt100mmControl.Name = "WidthAt100mmControl"
        Me.WidthAt100mmControl.Size = New System.Drawing.Size(160, 24)
        Me.WidthAt100mmControl.TabIndex = 3
        Me.WidthAt100mmControl.ToBeCalculated = True
        Me.WidthAt100mmControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WidthAt100mmControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WidthAt100mmControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WidthAt100mmControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WidthAt100mmControl.ValueText = ""
        '
        'PowerLawDepthLabel
        '
        Me.PowerLawDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawDepthLabel.Location = New System.Drawing.Point(8, 8)
        Me.PowerLawDepthLabel.Name = "PowerLawDepthLabel"
        Me.PowerLawDepthLabel.Size = New System.Drawing.Size(143, 23)
        Me.PowerLawDepthLabel.TabIndex = 0
        Me.PowerLawDepthLabel.Text = "Maximum Depth, &Y"
        Me.PowerLawDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PowerLawExponentLabel
        '
        Me.PowerLawExponentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawExponentLabel.Location = New System.Drawing.Point(11, 56)
        Me.PowerLawExponentLabel.Name = "PowerLawExponentLabel"
        Me.PowerLawExponentLabel.Size = New System.Drawing.Size(140, 23)
        Me.PowerLawExponentLabel.TabIndex = 4
        Me.PowerLawExponentLabel.Text = "Exponent, &M"
        Me.PowerLawExponentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WidthAt100mmLabel
        '
        Me.WidthAt100mmLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WidthAt100mmLabel.Location = New System.Drawing.Point(8, 32)
        Me.WidthAt100mmLabel.Name = "WidthAt100mmLabel"
        Me.WidthAt100mmLabel.Size = New System.Drawing.Size(143, 23)
        Me.WidthAt100mmLabel.TabIndex = 2
        Me.WidthAt100mmLabel.Text = "&Width at 100 mm"
        Me.WidthAt100mmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SetWidthValue
        '
        Me.SetWidthValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetWidthValue.Location = New System.Drawing.Point(270, 65)
        Me.SetWidthValue.Name = "SetWidthValue"
        Me.SetWidthValue.Size = New System.Drawing.Size(85, 17)
        Me.SetWidthValue.TabIndex = 12
        Me.SetWidthValue.Text = "25 m"
        Me.SetWidthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SetWidthLabel
        '
        Me.SetWidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetWidthLabel.Location = New System.Drawing.Point(270, 48)
        Me.SetWidthLabel.Name = "SetWidthLabel"
        Me.SetWidthLabel.Size = New System.Drawing.Size(85, 17)
        Me.SetWidthLabel.TabIndex = 11
        Me.SetWidthLabel.Text = "Set Width"
        Me.SetWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TrapezoidPanel
        '
        Me.TrapezoidPanel.AccessibleDescription = "Set of parameters that define the dimensions of a trapezoidal furrow."
        Me.TrapezoidPanel.AccessibleName = "Trapezoid Furrow Parameters"
        Me.TrapezoidPanel.Controls.Add(Me.TrapezoidDepthControl)
        Me.TrapezoidPanel.Controls.Add(Me.SideSlopeControl)
        Me.TrapezoidPanel.Controls.Add(Me.BottomWidthControl)
        Me.TrapezoidPanel.Controls.Add(Me.TrapezoidDepthLabel)
        Me.TrapezoidPanel.Controls.Add(Me.SideSlopeLabel)
        Me.TrapezoidPanel.Controls.Add(Me.BottomWidthLabel)
        Me.TrapezoidPanel.Location = New System.Drawing.Point(8, 150)
        Me.TrapezoidPanel.Name = "TrapezoidPanel"
        Me.TrapezoidPanel.Size = New System.Drawing.Size(344, 136)
        Me.TrapezoidPanel.TabIndex = 10
        '
        'TrapezoidDepthControl
        '
        Me.TrapezoidDepthControl.AccessibleDescription = "Specifies maximum depth of the trapezoidal furrow."
        Me.TrapezoidDepthControl.AccessibleName = "Maximum Depth"
        Me.TrapezoidDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.TrapezoidDepthControl.IsCalculated = False
        Me.TrapezoidDepthControl.IsInteger = False
        Me.TrapezoidDepthControl.Location = New System.Drawing.Point(160, 8)
        Me.TrapezoidDepthControl.Name = "TrapezoidDepthControl"
        Me.TrapezoidDepthControl.Size = New System.Drawing.Size(160, 24)
        Me.TrapezoidDepthControl.TabIndex = 1
        Me.TrapezoidDepthControl.ToBeCalculated = True
        Me.TrapezoidDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.TrapezoidDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.TrapezoidDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.TrapezoidDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.TrapezoidDepthControl.ValueText = ""
        '
        'SideSlopeControl
        '
        Me.SideSlopeControl.AccessibleDescription = "Specifies slope of the trapezoidal furrow's sides as Horz / Vert (e.g. run/rise)"
        Me.SideSlopeControl.AccessibleName = "Side Slope"
        Me.SideSlopeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SideSlopeControl.IsCalculated = False
        Me.SideSlopeControl.IsInteger = False
        Me.SideSlopeControl.Location = New System.Drawing.Point(160, 56)
        Me.SideSlopeControl.Name = "SideSlopeControl"
        Me.SideSlopeControl.Size = New System.Drawing.Size(160, 24)
        Me.SideSlopeControl.TabIndex = 5
        Me.SideSlopeControl.ToBeCalculated = True
        Me.SideSlopeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SideSlopeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SideSlopeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SideSlopeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SideSlopeControl.ValueText = ""
        '
        'BottomWidthControl
        '
        Me.BottomWidthControl.AccessibleDescription = "Specifies width of the bottom of the trapezoidal furrow."
        Me.BottomWidthControl.AccessibleName = "Bottom Width"
        Me.BottomWidthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BottomWidthControl.IsCalculated = False
        Me.BottomWidthControl.IsInteger = False
        Me.BottomWidthControl.Location = New System.Drawing.Point(160, 32)
        Me.BottomWidthControl.Name = "BottomWidthControl"
        Me.BottomWidthControl.Size = New System.Drawing.Size(160, 24)
        Me.BottomWidthControl.TabIndex = 3
        Me.BottomWidthControl.ToBeCalculated = True
        Me.BottomWidthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BottomWidthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BottomWidthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BottomWidthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BottomWidthControl.ValueText = ""
        '
        'TrapezoidDepthLabel
        '
        Me.TrapezoidDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrapezoidDepthLabel.Location = New System.Drawing.Point(8, 8)
        Me.TrapezoidDepthLabel.Name = "TrapezoidDepthLabel"
        Me.TrapezoidDepthLabel.Size = New System.Drawing.Size(143, 23)
        Me.TrapezoidDepthLabel.TabIndex = 0
        Me.TrapezoidDepthLabel.Text = "Maximum Depth, &Y"
        Me.TrapezoidDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SideSlopeLabel
        '
        Me.SideSlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SideSlopeLabel.Location = New System.Drawing.Point(8, 56)
        Me.SideSlopeLabel.Name = "SideSlopeLabel"
        Me.SideSlopeLabel.Size = New System.Drawing.Size(143, 23)
        Me.SideSlopeLabel.TabIndex = 4
        Me.SideSlopeLabel.Text = "Side Slope, &SS"
        Me.SideSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BottomWidthLabel
        '
        Me.BottomWidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BottomWidthLabel.Location = New System.Drawing.Point(8, 32)
        Me.BottomWidthLabel.Name = "BottomWidthLabel"
        Me.BottomWidthLabel.Size = New System.Drawing.Size(143, 23)
        Me.BottomWidthLabel.TabIndex = 2
        Me.BottomWidthLabel.Text = "Bottom Width, &BW"
        Me.BottomWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CrossSectionLabel
        '
        Me.CrossSectionLabel.AccessibleDescription = "Displays calculated Top Width of the furrow."
        Me.CrossSectionLabel.AccessibleName = "Top Width"
        Me.CrossSectionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrossSectionLabel.Location = New System.Drawing.Point(8, 95)
        Me.CrossSectionLabel.Name = "CrossSectionLabel"
        Me.CrossSectionLabel.Size = New System.Drawing.Size(130, 23)
        Me.CrossSectionLabel.TabIndex = 7
        Me.CrossSectionLabel.Text = "&Cross Section"
        Me.CrossSectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TopWidthLabel
        '
        Me.TopWidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopWidthLabel.Location = New System.Drawing.Point(138, 95)
        Me.TopWidthLabel.Name = "TopWidthLabel"
        Me.TopWidthLabel.Size = New System.Drawing.Size(215, 23)
        Me.TopWidthLabel.TabIndex = 9
        Me.TopWidthLabel.Text = "Top Width, TW = BW + 2*Y*SS"
        Me.TopWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PowerLawTablePanel
        '
        Me.PowerLawTablePanel.Controls.Add(Me.PowerLawTableControl)
        Me.PowerLawTablePanel.Location = New System.Drawing.Point(8, 150)
        Me.PowerLawTablePanel.Name = "PowerLawTablePanel"
        Me.PowerLawTablePanel.Size = New System.Drawing.Size(344, 136)
        Me.PowerLawTablePanel.TabIndex = 10
        '
        'TrapezoidTablePanel
        '
        Me.TrapezoidTablePanel.Controls.Add(Me.TrapezoidTableControl)
        Me.TrapezoidTablePanel.Location = New System.Drawing.Point(8, 150)
        Me.TrapezoidTablePanel.Name = "TrapezoidTablePanel"
        Me.TrapezoidTablePanel.Size = New System.Drawing.Size(344, 136)
        Me.TrapezoidTablePanel.TabIndex = 10
        '
        'FurrowsPerSetControl
        '
        Me.FurrowsPerSetControl.AccessibleDescription = "Specifies number of furrows included in the furrow set."
        Me.FurrowsPerSetControl.AccessibleName = "Furrows Per Set"
        Me.FurrowsPerSetControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.FurrowsPerSetControl.IsCalculated = False
        Me.FurrowsPerSetControl.IsInteger = False
        Me.FurrowsPerSetControl.Location = New System.Drawing.Point(168, 67)
        Me.FurrowsPerSetControl.Name = "FurrowsPerSetControl"
        Me.FurrowsPerSetControl.Size = New System.Drawing.Size(96, 24)
        Me.FurrowsPerSetControl.TabIndex = 5
        Me.FurrowsPerSetControl.ToBeCalculated = True
        Me.FurrowsPerSetControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.FurrowsPerSetControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.FurrowsPerSetControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.FurrowsPerSetControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.FurrowsPerSetControl.ValueText = ""
        '
        'FurrowsPerSetLabel
        '
        Me.FurrowsPerSetLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowsPerSetLabel.Location = New System.Drawing.Point(6, 67)
        Me.FurrowsPerSetLabel.Name = "FurrowsPerSetLabel"
        Me.FurrowsPerSetLabel.Size = New System.Drawing.Size(154, 20)
        Me.FurrowsPerSetLabel.TabIndex = 4
        Me.FurrowsPerSetLabel.Text = "Number &Per Set"
        Me.FurrowsPerSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FurrowLengthControl
        '
        Me.FurrowLengthControl.AccessibleDescription = "Specifies length of the furrow."
        Me.FurrowLengthControl.AccessibleName = "Field Length"
        Me.FurrowLengthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.FurrowLengthControl.IsCalculated = False
        Me.FurrowLengthControl.IsInteger = False
        Me.FurrowLengthControl.Location = New System.Drawing.Point(168, 19)
        Me.FurrowLengthControl.Name = "FurrowLengthControl"
        Me.FurrowLengthControl.Size = New System.Drawing.Size(96, 24)
        Me.FurrowLengthControl.TabIndex = 1
        Me.FurrowLengthControl.ToBeCalculated = True
        Me.FurrowLengthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.FurrowLengthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.FurrowLengthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.FurrowLengthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.FurrowLengthControl.ValueText = ""
        '
        'FurrowLengthLabel
        '
        Me.FurrowLengthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowLengthLabel.Location = New System.Drawing.Point(3, 19)
        Me.FurrowLengthLabel.Name = "FurrowLengthLabel"
        Me.FurrowLengthLabel.Size = New System.Drawing.Size(157, 23)
        Me.FurrowLengthLabel.TabIndex = 0
        Me.FurrowLengthLabel.Text = "Length, &L"
        Me.FurrowLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FurrowSpacingControl
        '
        Me.FurrowSpacingControl.AccessibleDescription = "Specifies center spacing between two adjacent furrows."
        Me.FurrowSpacingControl.AccessibleName = "Furrow Spacing"
        Me.FurrowSpacingControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.FurrowSpacingControl.IsCalculated = False
        Me.FurrowSpacingControl.IsInteger = False
        Me.FurrowSpacingControl.Location = New System.Drawing.Point(168, 43)
        Me.FurrowSpacingControl.Name = "FurrowSpacingControl"
        Me.FurrowSpacingControl.Size = New System.Drawing.Size(96, 24)
        Me.FurrowSpacingControl.TabIndex = 3
        Me.FurrowSpacingControl.ToBeCalculated = True
        Me.FurrowSpacingControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.FurrowSpacingControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.FurrowSpacingControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.FurrowSpacingControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.FurrowSpacingControl.ValueText = ""
        '
        'FurrowSpacingLabel
        '
        Me.FurrowSpacingLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowSpacingLabel.Location = New System.Drawing.Point(3, 43)
        Me.FurrowSpacingLabel.Name = "FurrowSpacingLabel"
        Me.FurrowSpacingLabel.Size = New System.Drawing.Size(157, 23)
        Me.FurrowSpacingLabel.TabIndex = 2
        Me.FurrowSpacingLabel.Text = "Spacing, &FS"
        Me.FurrowSpacingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EditFurrowShapeButton
        '
        Me.EditFurrowShapeButton.AccessibleDescription = "Displays dialog box for editing the furrow shape table."
        Me.EditFurrowShapeButton.AccessibleName = "Edit Furrow Shape Table"
        Me.EditFurrowShapeButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EditFurrowShapeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EditFurrowShapeButton.Location = New System.Drawing.Point(240, 120)
        Me.EditFurrowShapeButton.Name = "EditFurrowShapeButton"
        Me.EditFurrowShapeButton.Size = New System.Drawing.Size(109, 23)
        Me.EditFurrowShapeButton.TabIndex = 9
        Me.EditFurrowShapeButton.Text = "&Edit Data"
        Me.EditFurrowShapeButton.UseVisualStyleBackColor = False
        '
        'TabulatedFurrowSelect
        '
        Me.TabulatedFurrowSelect.AccessibleDescription = "Selects whether or not the furrow shape is represented by a table of dimensions."
        Me.TabulatedFurrowSelect.AccessibleName = "Tabulated Furrow Shape Selection"
        Me.TabulatedFurrowSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedFurrowSelect.Location = New System.Drawing.Point(240, 122)
        Me.TabulatedFurrowSelect.Name = "TabulatedFurrowSelect"
        Me.TabulatedFurrowSelect.Size = New System.Drawing.Size(109, 23)
        Me.TabulatedFurrowSelect.TabIndex = 9
        Me.TabulatedFurrowSelect.Text = "&Tabulated"
        Me.TabulatedFurrowSelect.UseVisualStyleBackColor = True
        '
        'FurrowShapeControl
        '
        Me.FurrowShapeControl.AccessibleDescription = "Selects cross sectional shape of the furrow."
        Me.FurrowShapeControl.AccessibleName = "Furrow Shape"
        Me.FurrowShapeControl.ApplicationValue = -1
        Me.FurrowShapeControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FurrowShapeControl.EnableSaveActions = False
        Me.FurrowShapeControl.IsCalculated = False
        Me.FurrowShapeControl.Location = New System.Drawing.Point(11, 120)
        Me.FurrowShapeControl.Name = "FurrowShapeControl"
        Me.FurrowShapeControl.SelectedIndexSet = False
        Me.FurrowShapeControl.Size = New System.Drawing.Size(223, 24)
        Me.FurrowShapeControl.TabIndex = 8
        '
        'BorderDimensionsBox
        '
        Me.BorderDimensionsBox.AccessibleDescription = "Set of parameters that define the dimensions of the border."
        Me.BorderDimensionsBox.AccessibleName = "Border Dimensions"
        Me.BorderDimensionsBox.Controls.Add(Me.BorderDepthTableControl)
        Me.BorderDimensionsBox.Controls.Add(Me.TabulatedBorderDepthSelect)
        Me.BorderDimensionsBox.Controls.Add(Me.BorderDepthControl)
        Me.BorderDimensionsBox.Controls.Add(Me.BorderLengthControl)
        Me.BorderDimensionsBox.Controls.Add(Me.BorderDepthLabel)
        Me.BorderDimensionsBox.Controls.Add(Me.BorderLengthLabel)
        Me.BorderDimensionsBox.Controls.Add(Me.BorderWidthControl)
        Me.BorderDimensionsBox.Controls.Add(Me.BorderWidthLabel)
        Me.BorderDimensionsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BorderDimensionsBox.Location = New System.Drawing.Point(8, 36)
        Me.BorderDimensionsBox.Name = "BorderDimensionsBox"
        Me.BorderDimensionsBox.Size = New System.Drawing.Size(360, 292)
        Me.BorderDimensionsBox.TabIndex = 2
        Me.BorderDimensionsBox.TabStop = False
        Me.BorderDimensionsBox.Text = "Border"
        '
        'BorderDepthTableControl
        '
        Me.BorderDepthTableControl.AccessibleDescription = "Specifies the distance varying border depths down a basin or border field."
        Me.BorderDepthTableControl.AccessibleName = "Border Depth Table"
        Me.BorderDepthTableControl.AllRowsFixed = False
        Me.BorderDepthTableControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.BorderDepthTableControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.BorderDepthTableControl.CaptionText = "Border Depth Table"
        Me.BorderDepthTableControl.ColumnWidthRatios = Nothing
        Me.BorderDepthTableControl.DataMember = ""
        Me.BorderDepthTableControl.EnableSaveActions = False
        Me.BorderDepthTableControl.FirstColumnIncreases = True
        Me.BorderDepthTableControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.BorderDepthTableControl.FirstColumnMinimum = 0
        Me.BorderDepthTableControl.FirstRowFixed = True
        Me.BorderDepthTableControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BorderDepthTableControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.BorderDepthTableControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.BorderDepthTableControl.Location = New System.Drawing.Point(16, 124)
        Me.BorderDepthTableControl.MaxRows = 50
        Me.BorderDepthTableControl.MinRows = 0
        Me.BorderDepthTableControl.Name = "BorderDepthTableControl"
        Me.BorderDepthTableControl.SecondColumnIncreases = False
        Me.BorderDepthTableControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.BorderDepthTableControl.SecondColumnMinimum = 0
        Me.BorderDepthTableControl.Size = New System.Drawing.Size(327, 159)
        Me.BorderDepthTableControl.TabIndex = 7
        Me.BorderDepthTableControl.TableReadonly = False
        '
        'TabulatedBorderDepthSelect
        '
        Me.TabulatedBorderDepthSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedBorderDepthSelect.Location = New System.Drawing.Point(260, 96)
        Me.TabulatedBorderDepthSelect.Name = "TabulatedBorderDepthSelect"
        Me.TabulatedBorderDepthSelect.Size = New System.Drawing.Size(96, 21)
        Me.TabulatedBorderDepthSelect.TabIndex = 6
        Me.TabulatedBorderDepthSelect.Text = "&Tabulated"
        Me.TabulatedBorderDepthSelect.UseVisualStyleBackColor = True
        '
        'BorderDepthControl
        '
        Me.BorderDepthControl.AccessibleDescription = "Specifies depth created by the border's edge berms."
        Me.BorderDepthControl.AccessibleName = "Maximum Depth"
        Me.BorderDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BorderDepthControl.IsCalculated = False
        Me.BorderDepthControl.IsInteger = False
        Me.BorderDepthControl.Location = New System.Drawing.Point(158, 94)
        Me.BorderDepthControl.Name = "BorderDepthControl"
        Me.BorderDepthControl.Size = New System.Drawing.Size(92, 24)
        Me.BorderDepthControl.TabIndex = 5
        Me.BorderDepthControl.ToBeCalculated = True
        Me.BorderDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BorderDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BorderDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BorderDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BorderDepthControl.ValueText = ""
        '
        'BorderLengthControl
        '
        Me.BorderLengthControl.AccessibleDescription = "Specifies length of the border."
        Me.BorderLengthControl.AccessibleName = "Border Length"
        Me.BorderLengthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BorderLengthControl.IsCalculated = False
        Me.BorderLengthControl.IsInteger = False
        Me.BorderLengthControl.Location = New System.Drawing.Point(158, 32)
        Me.BorderLengthControl.Name = "BorderLengthControl"
        Me.BorderLengthControl.Size = New System.Drawing.Size(92, 24)
        Me.BorderLengthControl.TabIndex = 1
        Me.BorderLengthControl.ToBeCalculated = True
        Me.BorderLengthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BorderLengthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BorderLengthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BorderLengthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BorderLengthControl.ValueText = ""
        '
        'BorderDepthLabel
        '
        Me.BorderDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BorderDepthLabel.Location = New System.Drawing.Point(6, 94)
        Me.BorderDepthLabel.Name = "BorderDepthLabel"
        Me.BorderDepthLabel.Size = New System.Drawing.Size(143, 23)
        Me.BorderDepthLabel.TabIndex = 4
        Me.BorderDepthLabel.Text = "Maximum Depth, &Y"
        Me.BorderDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BorderLengthLabel
        '
        Me.BorderLengthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BorderLengthLabel.Location = New System.Drawing.Point(6, 32)
        Me.BorderLengthLabel.Name = "BorderLengthLabel"
        Me.BorderLengthLabel.Size = New System.Drawing.Size(143, 23)
        Me.BorderLengthLabel.TabIndex = 0
        Me.BorderLengthLabel.Text = "Length, &L"
        Me.BorderLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BorderWidthControl
        '
        Me.BorderWidthControl.AccessibleDescription = "Specifies width of the border."
        Me.BorderWidthControl.AccessibleName = "Border Width"
        Me.BorderWidthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BorderWidthControl.IsCalculated = False
        Me.BorderWidthControl.IsInteger = False
        Me.BorderWidthControl.Location = New System.Drawing.Point(158, 56)
        Me.BorderWidthControl.Name = "BorderWidthControl"
        Me.BorderWidthControl.Size = New System.Drawing.Size(92, 24)
        Me.BorderWidthControl.TabIndex = 3
        Me.BorderWidthControl.ToBeCalculated = True
        Me.BorderWidthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BorderWidthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BorderWidthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BorderWidthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BorderWidthControl.ValueText = ""
        '
        'BorderWidthLabel
        '
        Me.BorderWidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BorderWidthLabel.Location = New System.Drawing.Point(6, 56)
        Me.BorderWidthLabel.Name = "BorderWidthLabel"
        Me.BorderWidthLabel.Size = New System.Drawing.Size(143, 23)
        Me.BorderWidthLabel.TabIndex = 2
        Me.BorderWidthLabel.Text = "Width, &W"
        Me.BorderWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BottomDescriptionBox
        '
        Me.BottomDescriptionBox.AccessibleDescription = "Set of parameters that define the bottom slope of the border."
        Me.BottomDescriptionBox.AccessibleName = "Bottom Description"
        Me.BottomDescriptionBox.Controls.Add(Me.EditSlopeTableButton)
        Me.BottomDescriptionBox.Controls.Add(Me.BottomDescriptionControl)
        Me.BottomDescriptionBox.Controls.Add(Me.VaryByDistanceLabel)
        Me.BottomDescriptionBox.Controls.Add(Me.VaryByDistanceTimeLabel)
        Me.BottomDescriptionBox.Controls.Add(Me.SlopePanel)
        Me.BottomDescriptionBox.Controls.Add(Me.AverageSlopePanel)
        Me.BottomDescriptionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BottomDescriptionBox.Location = New System.Drawing.Point(8, 330)
        Me.BottomDescriptionBox.Name = "BottomDescriptionBox"
        Me.BottomDescriptionBox.Size = New System.Drawing.Size(360, 88)
        Me.BottomDescriptionBox.TabIndex = 11
        Me.BottomDescriptionBox.TabStop = False
        Me.BottomDescriptionBox.Text = "&Bottom Description"
        '
        'EditSlopeTableButton
        '
        Me.EditSlopeTableButton.AccessibleDescription = "Displays dialog box for editing the slope or elevation table."
        Me.EditSlopeTableButton.AccessibleName = "Edit Bottom Description Table"
        Me.EditSlopeTableButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EditSlopeTableButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EditSlopeTableButton.Location = New System.Drawing.Point(240, 20)
        Me.EditSlopeTableButton.Name = "EditSlopeTableButton"
        Me.EditSlopeTableButton.Size = New System.Drawing.Size(109, 23)
        Me.EditSlopeTableButton.TabIndex = 1
        Me.EditSlopeTableButton.Text = "Edit &Table"
        Me.EditSlopeTableButton.UseVisualStyleBackColor = False
        '
        'BottomDescriptionControl
        '
        Me.BottomDescriptionControl.AccessibleDescription = "Selects method for describing the border's slope.  The selection list is dependen" & _
            "t on the Cross Section and the User Level."
        Me.BottomDescriptionControl.AccessibleName = "Bottom Description"
        Me.BottomDescriptionControl.ApplicationValue = -1
        Me.BottomDescriptionControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BottomDescriptionControl.EnableSaveActions = False
        Me.BottomDescriptionControl.IsCalculated = False
        Me.BottomDescriptionControl.Items.AddRange(New Object() {"Average Slope from Elevation Table"})
        Me.BottomDescriptionControl.Location = New System.Drawing.Point(16, 20)
        Me.BottomDescriptionControl.Name = "BottomDescriptionControl"
        Me.BottomDescriptionControl.SelectedIndexSet = False
        Me.BottomDescriptionControl.Size = New System.Drawing.Size(218, 24)
        Me.BottomDescriptionControl.TabIndex = 0
        '
        'VaryByDistanceLabel
        '
        Me.VaryByDistanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VaryByDistanceLabel.Location = New System.Drawing.Point(239, 48)
        Me.VaryByDistanceLabel.Name = "VaryByDistanceLabel"
        Me.VaryByDistanceLabel.Size = New System.Drawing.Size(107, 32)
        Me.VaryByDistanceLabel.TabIndex = 4
        Me.VaryByDistanceLabel.Text = "Vary By Distance Only"
        Me.VaryByDistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VaryByDistanceTimeLabel
        '
        Me.VaryByDistanceTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VaryByDistanceTimeLabel.Location = New System.Drawing.Point(240, 48)
        Me.VaryByDistanceTimeLabel.Name = "VaryByDistanceTimeLabel"
        Me.VaryByDistanceTimeLabel.Size = New System.Drawing.Size(88, 32)
        Me.VaryByDistanceTimeLabel.TabIndex = 5
        Me.VaryByDistanceTimeLabel.Text = "Vary By     Dist. && Time"
        Me.VaryByDistanceTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SlopePanel
        '
        Me.SlopePanel.Controls.Add(Me.SlopeControl)
        Me.SlopePanel.Controls.Add(Me.SlopeLabel)
        Me.SlopePanel.Location = New System.Drawing.Point(8, 48)
        Me.SlopePanel.Name = "SlopePanel"
        Me.SlopePanel.Size = New System.Drawing.Size(341, 32)
        Me.SlopePanel.TabIndex = 2
        '
        'SlopeControl
        '
        Me.SlopeControl.AccessibleDescription = "Specifies slope of the border to be irrigated."
        Me.SlopeControl.AccessibleName = "Field Slope"
        Me.SlopeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SlopeControl.IsCalculated = False
        Me.SlopeControl.IsInteger = False
        Me.SlopeControl.Location = New System.Drawing.Point(160, 4)
        Me.SlopeControl.Name = "SlopeControl"
        Me.SlopeControl.Size = New System.Drawing.Size(160, 24)
        Me.SlopeControl.TabIndex = 1
        Me.SlopeControl.ToBeCalculated = True
        Me.SlopeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SlopeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SlopeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SlopeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SlopeControl.ValueText = ""
        '
        'SlopeLabel
        '
        Me.SlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SlopeLabel.Location = New System.Drawing.Point(8, 4)
        Me.SlopeLabel.Name = "SlopeLabel"
        Me.SlopeLabel.Size = New System.Drawing.Size(143, 23)
        Me.SlopeLabel.TabIndex = 0
        Me.SlopeLabel.Text = "Slope, &S0"
        Me.SlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AverageSlopePanel
        '
        Me.AverageSlopePanel.Controls.Add(Me.AverageSlopeLabel)
        Me.AverageSlopePanel.Location = New System.Drawing.Point(8, 48)
        Me.AverageSlopePanel.Name = "AverageSlopePanel"
        Me.AverageSlopePanel.Size = New System.Drawing.Size(328, 32)
        Me.AverageSlopePanel.TabIndex = 2
        '
        'AverageSlopeLabel
        '
        Me.AverageSlopeLabel.AccessibleDescription = "Displays Elevation or Slope average from the Slope table."
        Me.AverageSlopeLabel.AccessibleName = "Average Slope"
        Me.AverageSlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AverageSlopeLabel.Location = New System.Drawing.Point(16, 4)
        Me.AverageSlopeLabel.Name = "AverageSlopeLabel"
        Me.AverageSlopeLabel.Size = New System.Drawing.Size(192, 23)
        Me.AverageSlopeLabel.TabIndex = 0
        Me.AverageSlopeLabel.Text = "Average Slope"
        Me.AverageSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SystemGeometryGraphics
        '
        Me.SystemGeometryGraphics.AccessibleDescription = "A copyable bitmap image"
        Me.SystemGeometryGraphics.AccessibleName = "Bitmap Diagram"
        Me.SystemGeometryGraphics.Location = New System.Drawing.Point(376, 34)
        Me.SystemGeometryGraphics.Name = "SystemGeometryGraphics"
        Me.SystemGeometryGraphics.Size = New System.Drawing.Size(400, 384)
        Me.SystemGeometryGraphics.TabIndex = 32
        Me.SystemGeometryGraphics.TabStop = False
        Me.SystemGeometryGraphics.Text = "Bitmap Diagram"
        '
        'PowerLawTableControl
        '
        Me.PowerLawTableControl.AccessibleDescription = "Table of parameters that define the dimensions of a distance varying power law fu" & _
            "rrow."
        Me.PowerLawTableControl.AccessibleName = "Power Law Table"
        Me.PowerLawTableControl.AllRowsFixed = False
        Me.PowerLawTableControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.PowerLawTableControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.PowerLawTableControl.CaptionText = "Cross Section Table"
        Me.PowerLawTableControl.ColumnWidthRatios = Nothing
        Me.PowerLawTableControl.DataMember = ""
        Me.PowerLawTableControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PowerLawTableControl.EnableSaveActions = False
        Me.PowerLawTableControl.FirstColumnIncreases = True
        Me.PowerLawTableControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.PowerLawTableControl.FirstColumnMinimum = 0
        Me.PowerLawTableControl.FirstRowFixed = True
        Me.PowerLawTableControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawTableControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.PowerLawTableControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.PowerLawTableControl.Location = New System.Drawing.Point(0, 0)
        Me.PowerLawTableControl.MaxRows = 50
        Me.PowerLawTableControl.MinRows = 0
        Me.PowerLawTableControl.Name = "PowerLawTableControl"
        Me.PowerLawTableControl.SecondColumnIncreases = False
        Me.PowerLawTableControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.PowerLawTableControl.SecondColumnMinimum = 0
        Me.PowerLawTableControl.Size = New System.Drawing.Size(344, 136)
        Me.PowerLawTableControl.TabIndex = 10
        Me.PowerLawTableControl.TableReadonly = False
        Me.PowerLawTableControl.Unit = Nothing
        '
        'TrapezoidTableControl
        '
        Me.TrapezoidTableControl.AccessibleDescription = "Table of parameters that define the dimensions of a distance varying trapezoidal " & _
            "furrow."
        Me.TrapezoidTableControl.AccessibleName = "Trapezoid Furrow Table"
        Me.TrapezoidTableControl.AllRowsFixed = False
        Me.TrapezoidTableControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TrapezoidTableControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TrapezoidTableControl.CaptionText = "Cross Section Table"
        Me.TrapezoidTableControl.ColumnWidthRatios = Nothing
        Me.TrapezoidTableControl.DataMember = ""
        Me.TrapezoidTableControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrapezoidTableControl.EnableSaveActions = False
        Me.TrapezoidTableControl.FirstColumnIncreases = True
        Me.TrapezoidTableControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.TrapezoidTableControl.FirstColumnMinimum = 0
        Me.TrapezoidTableControl.FirstRowFixed = True
        Me.TrapezoidTableControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrapezoidTableControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TrapezoidTableControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TrapezoidTableControl.Location = New System.Drawing.Point(0, 0)
        Me.TrapezoidTableControl.MaxRows = 50
        Me.TrapezoidTableControl.MinRows = 0
        Me.TrapezoidTableControl.Name = "TrapezoidTableControl"
        Me.TrapezoidTableControl.SecondColumnIncreases = False
        Me.TrapezoidTableControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.TrapezoidTableControl.SecondColumnMinimum = 0
        Me.TrapezoidTableControl.Size = New System.Drawing.Size(344, 136)
        Me.TrapezoidTableControl.TabIndex = 10
        Me.TrapezoidTableControl.TableReadonly = False
        Me.TrapezoidTableControl.Unit = Nothing
        '
        'ctl_SystemGeometry
        '
        Me.Controls.Add(Me.SystemGeometryGraphics)
        Me.Controls.Add(Me.TitlePanel)
        Me.Controls.Add(Me.BottomDescriptionBox)
        Me.Controls.Add(Me.FurrowShapeBox)
        Me.Controls.Add(Me.BorderDimensionsBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_SystemGeometry"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.TitlePanel.ResumeLayout(False)
        Me.FurrowShapeBox.ResumeLayout(False)
        Me.PowerLawPanel.ResumeLayout(False)
        Me.TrapezoidPanel.ResumeLayout(False)
        Me.PowerLawTablePanel.ResumeLayout(False)
        Me.TrapezoidTablePanel.ResumeLayout(False)
        Me.BorderDimensionsBox.ResumeLayout(False)
        CType(Me.BorderDepthTableControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BottomDescriptionBox.ResumeLayout(False)
        Me.SlopePanel.ResumeLayout(False)
        Me.AverageSlopePanel.ResumeLayout(False)
        CType(Me.SystemGeometryGraphics, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PowerLawTableControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrapezoidTableControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mUnit As Unit = Nothing
    Private mWorld As World = Nothing
    Private mField As Field = Nothing
    Private mFarm As Farm = Nothing
    Private mDictionary As Dictionary = Nothing
    Private mMyStore As DataStore.ObjectNode = Nothing

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mSoilCropProperties As SoilCropProperties

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow)

        Debug.Assert(Not (_unit Is Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        mWorldWindow = worldWindow

        ' Link the contained controls to their models & store
        BottomDescriptionControl.LinkToModel(mMyStore, mSystemGeometry.BottomDescriptionProperty)

        SlopeControl.LinkToModel(mMyStore, mSystemGeometry.SlopeProperty)
        BorderDepthControl.LinkToModel(mMyStore, mSystemGeometry.DepthProperty)
        BorderLengthControl.LinkToModel(mMyStore, mSystemGeometry.LengthProperty)
        BorderWidthControl.LinkToModel(mMyStore, mSystemGeometry.WidthProperty)

        TabulatedBorderDepthSelect.LinkToModel(mMyStore, mSystemGeometry.EnableTabulatedBorderDepthProperty)

        BorderDepthTableControl.LinkToModel(mMyStore, mSystemGeometry.BorderDepthTableProperty)
        BorderDepthTableControl.FirstRowFixed = True

        FurrowLengthControl.LinkToModel(mMyStore, mSystemGeometry.LengthProperty)
        FurrowSpacingControl.LinkToModel(mMyStore, mSystemGeometry.FurrowSpacingProperty)
        FurrowsPerSetControl.IsInteger = True
        FurrowsPerSetControl.LinkToModel(mMyStore, mSystemGeometry.FurrowsPerSetProperty)

        FurrowShapeControl.LinkToModel(mMyStore, mSystemGeometry.FurrowShapeProperty)

        TabulatedFurrowSelect.LinkToModel(mMyStore, mSystemGeometry.EnableTabulatedFurrowShapeProperty)

        TrapezoidTableControl.LinkToModel(mMyStore, mSystemGeometry.TrapezoidTableProperty)
        TrapezoidTableControl.FirstRowFixed = True
        TrapezoidTableControl.Unit = mUnit

        PowerLawTableControl.LinkToModel(mMyStore, mSystemGeometry.PowerLawTableProperty)
        PowerLawTableControl.FirstRowFixed = True
        PowerLawTableControl.Unit = mUnit

        BottomWidthControl.LinkToModel(mMyStore, mSystemGeometry.BottomWidthProperty)
        SideSlopeControl.LinkToModel(mMyStore, mSystemGeometry.SideSlopeProperty)
        TrapezoidDepthControl.LinkToModel(mMyStore, mSystemGeometry.MaximumDepthProperty)

        WidthAt100mmControl.LinkToModel(mMyStore, mSystemGeometry.WidthAt100mmProperty)
        PowerLawExponentControl.LinkToModel(mMyStore, mSystemGeometry.PowerLawExponentProperty)
        PowerLawDepthControl.LinkToModel(mMyStore, mSystemGeometry.MaximumDepthProperty)

        ' Update language translation
        UpdateLanguage()

        ' Update the control's User Interface
        Me.Dock = DockStyle.Fill

        UpdateUI()

    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        ' Update the UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then
            UpdateCrossSection()
            UpdateBottomDescription()
            UpdateBorderDepthDescription()
            UpdateFurrowShape()
            UpdateDimensions()

            UpdateGraphics()
        End If
    End Sub
    '
    ' Update the Cross Section selection list & selection
    '
    Private Sub UpdateCrossSection()

        ' Update System Type description
        Me.SystemGeometryLabel.Text = mDictionary.tSystemGeometry.Translated

        ' Hide/Show controls
        Select Case (mSystemGeometry.CrossSection.Value)
            Case CrossSections.Basin, CrossSections.Border
                FurrowShapeBox.Hide()
                BorderDimensionsBox.Show()
            Case Else
                BorderDimensionsBox.Hide()
                FurrowShapeBox.Show()
        End Select

        UpdateDimensions()

    End Sub
    '
    ' Update Bottom Description selection list & selection
    '
    Private Sub UpdateBottomDescription()

        ' Update selection list
        BottomDescriptionControl.Clear()
        Dim _sel As String = mSystemGeometry.GetFirstBottomDescriptionSelection
        Dim _idx As Integer = 0
        While Not (_sel Is Nothing)
            If Not (_sel = String.Empty) Then
                BottomDescriptionControl.Add(_sel, _idx)
            End If
            _sel = mSystemGeometry.GetNextBottomDescriptionSelection
            _idx += 1
        End While

        ' Update selection
        BottomDescriptionControl.UpdateUI()

        ' Hide/Show controls
        Select Case (mSystemGeometry.BottomDescription.Value)

            Case BottomDescriptions.SlopeTable

                If (mSystemGeometry.SlopeVariation.Value = VaryByLocTime.Variations.VaryWithDistance) Then
                    VaryByDistanceTimeLabel.Hide()
                    VaryByDistanceLabel.Show()
                Else
                    VaryByDistanceLabel.Hide()
                    VaryByDistanceTimeLabel.Show()
                End If

                SlopePanel.Hide()
                AverageSlopePanel.Show()
                EditSlopeTableButton.Show()

            Case BottomDescriptions.ElevationTable

                If (mSystemGeometry.ElevationVariation.Value = VaryByLocTime.Variations.VaryWithDistance) Then
                    VaryByDistanceTimeLabel.Hide()
                    VaryByDistanceLabel.Show()
                Else
                    VaryByDistanceLabel.Hide()
                    VaryByDistanceTimeLabel.Show()
                End If

                SlopePanel.Hide()
                AverageSlopePanel.Show()
                EditSlopeTableButton.Show()

            Case BottomDescriptions.AvgFromSlopeTable

                If (mSystemGeometry.SlopeVariation.Value = VaryByLocTime.Variations.VaryWithDistance) Then
                    VaryByDistanceTimeLabel.Hide()
                    VaryByDistanceLabel.Show()
                Else
                    VaryByDistanceLabel.Hide()
                    VaryByDistanceTimeLabel.Show()
                End If

                SlopePanel.Hide()
                AverageSlopePanel.Show()
                EditSlopeTableButton.Show()

            Case BottomDescriptions.AvgFromElevTable

                If (mSystemGeometry.ElevationVariation.Value = VaryByLocTime.Variations.VaryWithDistance) Then
                    VaryByDistanceTimeLabel.Hide()
                    VaryByDistanceLabel.Show()
                Else
                    VaryByDistanceLabel.Hide()
                    VaryByDistanceTimeLabel.Show()
                End If

                SlopePanel.Hide()
                AverageSlopePanel.Show()
                EditSlopeTableButton.Show()

            Case Else ' Assume Slope

                VaryByDistanceLabel.Hide()
                VaryByDistanceTimeLabel.Hide()

                AverageSlopePanel.Hide()
                EditSlopeTableButton.Hide()
                SlopePanel.Show()

        End Select

        If (AverageSlopePanel.Visible) Then
            Dim _averageSlope As Double = mSystemGeometry.AverageSlopeFromElevationTable
            AverageSlopeLabel.Text = mDictionary.tAverageSlope.Translated + " = " + SlopeString(_averageSlope, 0)
        End If

    End Sub
    '
    ' Update Border Depth Description selection options
    '
    Private Sub UpdateBorderDepthDescription()

        Dim worldType As WorldTypes = mSystemGeometry.Unit.UnitType.Value

        If (worldType = WorldTypes.SimulationWorld) Then ' Tabulated Border Depth might be available

            If (mWinSRFR.UserLevel = UserLevels.Standard) Then ' Tabulated Border Depth is not available
                TabulatedBorderDepthSelect.Hide()

                BorderDepthTableControl.Hide()
                BorderDepthLabel.Show()
                BorderDepthControl.Show()

            Else ' Advanced | Research
                TabulatedBorderDepthSelect.Show()

                If (mSystemGeometry.EnableTabulatedBorderDepth.Value) Then
                    BorderDepthLabel.Hide()
                    BorderDepthControl.Hide()

                    BorderDepthTableControl.UpdateUI()
                    BorderDepthTableControl.Show()
                Else
                    BorderDepthTableControl.Hide()

                    BorderDepthLabel.Show()
                    BorderDepthControl.Show()
                End If
            End If

        Else ' not Simulation World; Tabulated Border Depth not available

            TabulatedBorderDepthSelect.Hide()

            BorderDepthTableControl.Hide()
            BorderDepthLabel.Show()
            BorderDepthControl.Show()

        End If

    End Sub
    '
    ' Update Furrow Shape selection list & selection
    '
    Private Sub UpdateFurrowShape()

        ' Update selection list
        FurrowShapeControl.Clear()
        Dim _sel As String = mSystemGeometry.GetFirstFurrowShapeSelection
        Dim _idx As Integer = 0
        While Not (_sel Is Nothing)
            If Not (_sel = String.Empty) Then
                FurrowShapeControl.Add(_sel, _idx)
            End If
            _sel = mSystemGeometry.GetNextFurrowShapeSelection
            _idx += 1
        End While

        ' Update selection
        FurrowShapeControl.UpdateUI()

        ' Hide/Show controls
        Select Case (mSystemGeometry.FurrowShape.Value)
            Case FurrowShapes.PowerLawFromFieldData
                TrapezoidPanel.Hide()
                TrapezoidTablePanel.Hide()
                PowerLawTablePanel.Hide()
                TabulatedFurrowSelect.Hide()

                EditFurrowShapeButton.Show()
                PowerLawPanel.Show()

                Select Case (mUnitsSystem.UnitSystem)
                    Case UnitsDefinition.UnitSystems.English
                        WidthAt100mmLabel.Text = "&" + mDictionary.tWidthAt.Translated & " 4in"
                    Case Else ' Assume UnitsDefinition.UnitSystems.Metric
                        WidthAt100mmLabel.Text = "&" + mDictionary.tWidthAt.Translated & " 100mm"
                End Select

            Case FurrowShapes.TrapezoidFromFieldData
                PowerLawPanel.Hide()
                TrapezoidTablePanel.Hide()
                PowerLawTablePanel.Hide()
                TabulatedFurrowSelect.Hide()

                EditFurrowShapeButton.Show()
                TrapezoidPanel.Show()

            Case FurrowShapes.PowerLaw
                TrapezoidPanel.Hide()
                TrapezoidTablePanel.Hide()
                EditFurrowShapeButton.Hide()

                Dim worldType As WorldTypes = mSystemGeometry.Unit.UnitType.Value

                If (worldType = WorldTypes.SimulationWorld) Then ' Tabulated Furrow Shape might be available

                    If (mWinSRFR.UserLevel = UserLevels.Standard) Then ' Tabulated Furrow Shape is not available
                        TabulatedFurrowSelect.Hide()
                    Else
                        TabulatedFurrowSelect.Show()
                    End If

                    If (mSystemGeometry.EnableTabulatedFurrowShape.Value) Then ' Tabulated Furrow shape is selected
                        PowerLawPanel.Hide()
                        PowerLawTableControl.UpdateUI()
                        PowerLawTablePanel.Show()
                    Else
                        PowerLawTablePanel.Hide()
                        PowerLawPanel.Show()

                        Select Case (mUnitsSystem.UnitSystem)
                            Case UnitsDefinition.UnitSystems.English
                                WidthAt100mmLabel.Text = "&" + mDictionary.tWidthAt.Translated & " 4in"
                            Case Else ' Assume UnitsDefinition.UnitSystems.Metric
                                WidthAt100mmLabel.Text = "&" + mDictionary.tWidthAt.Translated & " 100mm"
                        End Select
                    End If

                Else

                    TabulatedFurrowSelect.Hide()

                    PowerLawTablePanel.Hide()
                    PowerLawPanel.Show()

                    Select Case (mUnitsSystem.UnitSystem)
                        Case UnitsDefinition.UnitSystems.English
                            WidthAt100mmLabel.Text = "&" + mDictionary.tWidthAt.Translated & " 4in"
                        Case Else ' Assume UnitsDefinition.UnitSystems.Metric
                            WidthAt100mmLabel.Text = "&" + mDictionary.tWidthAt.Translated & " 100mm"
                    End Select

                End If

            Case Else ' Assume Trapezoid
                PowerLawPanel.Hide()
                PowerLawTablePanel.Hide()
                EditFurrowShapeButton.Hide()

                Dim worldType As WorldTypes = mSystemGeometry.Unit.UnitType.Value

                If (worldType = WorldTypes.SimulationWorld) Then ' Tabulated Furrow Shape might be available

                    If (mWinSRFR.UserLevel = UserLevels.Standard) Then ' Tabulated Furrow Shape is not available
                        TabulatedFurrowSelect.Hide()
                    Else
                        TabulatedFurrowSelect.Show()
                    End If

                    If (mSystemGeometry.EnableTabulatedFurrowShape.Value) Then ' Tabulated Furrow shape is selected
                        TrapezoidPanel.Hide()
                        TrapezoidTableControl.UpdateUI()
                        TrapezoidTablePanel.Show()
                    Else
                        TrapezoidTablePanel.Hide()
                        TrapezoidPanel.Show()
                    End If

                Else

                    TabulatedFurrowSelect.Hide()

                    TrapezoidTablePanel.Hide()
                    TrapezoidPanel.Show()

                End If
        End Select

    End Sub

    Private Sub UpdateDimensions()
        ' Update Power Law Constant value
        Me.PowerLawConstantControl.Text = mSystemGeometry.PowerLawConstantString

        Me.TopWidthLabel.Text = mDictionary.tTopWidth.Translated
        Select Case (mSystemGeometry.FurrowShape.Value)
            Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData
                Me.TopWidthLabel.Text &= ", TW = C * Y^M"
            Case FurrowShapes.Trapezoid, FurrowShapes.TrapezoidFromFieldData
                Me.TopWidthLabel.Text &= ", TW = BW + 2*Y*SS"
        End Select

        Me.SetWidthValue.Text = mSystemGeometry.Width.ValueString
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me)
        UpdateUI()
    End Sub

#End Region

#Region " System Geometry Graphics "
    '
    ' Update the System Geometry graphics
    '
    Private Sub UpdateGraphics()

        ' Enclose all graphics code in Try Catch block to ignore exceptions
        Try
            ' Get the dimensions of the System Geomtry graphics area
            Dim _width As Integer = SystemGeometryGraphics.Width
            Dim _height As Integer = SystemGeometryGraphics.Height

            ' Create a bitmap for the graphics
            Dim _bitmap As Bitmap = New Bitmap(_width, _height)

            ' Fill the bitmap with the background color
            Dim _graphics As Graphics = Graphics.FromImage(_bitmap)
            Dim _brush As Brush = New SolidBrush(Me.BackColor)

            _graphics.FillRectangle(_brush, 0, 0, _width, _height)

            ' What is drawn depends on the Cross Section
            Select Case mSystemGeometry.CrossSection.Value
                Case CrossSections.Basin, CrossSections.Border

                    ' For Basin & Border graphics, divide the graphics region into two
                    ' rectangles for the top & side views
                    Dim _rectSize As Size = New Size(_width, CInt(_height / 3))

                    ' Top View (2/3 of graphic height)
                    Dim _topPos As Point = New Point(0, 0)
                    Dim _topRect As Rectangle = New Rectangle(_topPos, _rectSize)
                    _topRect.Height += _rectSize.Height

                    Dim _topView As Rectangle = DrawTopView(_graphics, _topRect)

                    ' Side View (1/3 of graphic height)
                    Dim _sidePos As Point = New Point(0, _topRect.Height)
                    Dim _sideRect As Rectangle = New Rectangle(_sidePos, _rectSize)

                    DrawSideView(_graphics, _sideRect, _topView)

                Case Else ' Assume Furrow

                    ' For Furrow graphics, divide the graphics region into three
                    ' rectangles for top, side & end views
                    Dim _rectSize As Size = New Size(_width, CInt(_height / 4))

                    ' Top View (1/4 of graphic height)
                    Dim _topPos As Point = New Point(0, 0)
                    Dim _topRect As Rectangle = New Rectangle(_topPos, _rectSize)

                    Dim _topView As Rectangle = DrawTopView(_graphics, _topRect)

                    ' Side View (1/4 of graphic height)
                    Dim _sidePos As Point = New Point(0, _topRect.Height)
                    Dim _sideRect As Rectangle = New Rectangle(_sidePos, _rectSize)

                    DrawSideView(_graphics, _sideRect, _topView)

                    ' End View (1/2 of graphic height)
                    Dim _endPos As Point = New Point(0, _topRect.Height + _sideRect.Height)
                    Dim _endRect As Rectangle = New Rectangle(_endPos, _rectSize)
                    _endRect.Height += _rectSize.Height

                    DrawEndView(_graphics, _endRect)

            End Select

            ' Copy the new bitmap into the image after drawing it (this prevents flicker)
            If (SystemGeometryGraphics.Image IsNot Nothing) Then
                SystemGeometryGraphics.Image.Dispose()
                SystemGeometryGraphics.Image = Nothing
            End If

            SystemGeometryGraphics.Image = _bitmap

        Catch ex As Exception
            ' Ignore exceptions
        End Try

    End Sub
    '
    ' Draw the Top View (Basin, Border & Furrow)
    '
    Private Function DrawTopView(ByVal _graphics As Graphics, ByVal _rect As Rectangle) As Rectangle

        ' Top View
        Dim _title As String = mDictionary.tTopView.Translated
        Dim _xLabel As String
        Dim _yLabel As String

        ' Get size of font
        Dim _bold As Font = New Font(Me.Font, FontStyle.Bold)
        Dim _size As SizeF = _graphics.MeasureString(_title, _bold)
        Dim _margin As Integer = CInt(_size.Height + 1)

        ' Compute graphics area for top view rectangle; leave room for labels
        Dim _topRect As Rectangle = New Rectangle(_rect.X + _margin, _
                                                  _rect.Y + _margin, _
                                                  _rect.Width - (2 * _margin), _
                                                  _rect.Height - (2 * _margin))

        ' Get drawing tools
        Dim _blackPen As Pen = BlackPen1()
        Dim _grayBrush As SolidBrush = DarkGraySolidBrush()
        Dim _blackBrush As SolidBrush = BlackSolidBrush()
        Dim _vertical As New StringFormat(StringFormatFlags.DirectionVertical)

        ' What is drawn depends on the Cross Section
        _graphics.DrawString(_title, _bold, _blackBrush, _rect.X, _rect.Y)

        Select Case mSystemGeometry.CrossSection.Value
            Case CrossSections.Basin, CrossSections.Border

                ' For Basin & Border graphics, top view is entire field
                If (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                    _xLabel = mDictionary.tLength.Translated + " = TBD"
                Else
                    _xLabel = mDictionary.tLength.Translated + " = " + mSystemGeometry.Length.ValueString
                End If

                If (mSystemGeometry.WidthProperty.ToBeCalculated) Then
                    _yLabel = mDictionary.tWidth.Translated + " = TBD"
                Else
                    _yLabel = mDictionary.tWidth.Translated + " = " + mSystemGeometry.Width.ValueString
                End If

                Dim _fieldLength As Double = mSystemGeometry.Length.Value
                Dim _fieldWidth As Double = mSystemGeometry.Width.Value
                Dim _area As Double = mSystemGeometry.FieldArea

                ' Display Area as addition info
                Dim _areaUnits As Units = Units.Hectares

                If (mSystemGeometry.Length.DisplayUnits = Units.Feet) Then
                    _areaUnits = Units.Acres
                End If

                Dim _aLabel As String

                If ((_xLabel = mDictionary.tLength.Translated + " = TBD") _
                 Or (_yLabel = mDictionary.tWidth.Translated + " = TBD")) Then
                    _aLabel = mDictionary.tArea.Translated + " = TDB"
                Else
                    _aLabel = mDictionary.tArea.Translated + " = " + UnitTextWithUnits(_area, _areaUnits, 6)
                End If

                Dim _ratio As Double = (_topRect.Width * 1.0) / (_topRect.Height * 1.0)

                If (_ratio < (_fieldLength / _fieldWidth)) Then
                    ' Length is limited
                    _topRect.Height = CInt(Math.Max(_topRect.Width * (_fieldWidth / _fieldLength), 3))
                    _topRect.Y = CInt(_rect.Y + ((_rect.Height - _topRect.Height) / 2))
                Else
                    ' Width is limited
                    _topRect.Width = CInt(Math.Max(_topRect.Height * (_fieldLength / _fieldWidth), 3))
                    _topRect.X = CInt(_rect.X + ((_rect.Width - _topRect.Width) / 2))
                End If

                ' Draw top view field rectangle & labels
                _graphics.DrawRectangle(_blackPen, _topRect)

                _size = _graphics.MeasureString(_xLabel, Me.Font)
                _graphics.DrawString(_xLabel, Me.Font, _grayBrush, _
                                    (_rect.Width - _size.Width) / 2, _
                                    _topRect.Y + _topRect.Height + 1)

                _size = _graphics.MeasureString(_yLabel, Me.Font)
                _graphics.DrawString(_yLabel, Me.Font, _grayBrush, _
                                    _topRect.X - _size.Height - 1, _
                                    (_rect.Height - _size.Width + 8) / 2, _
                                    _vertical)

                _size = _graphics.MeasureString(_aLabel, Me.Font)
                _graphics.DrawString(_aLabel, Me.Font, _grayBrush, _
                                    _rect.Width - _size.Width, _rect.Y)

            Case Else ' Assume Furrow

                ' For Furrow graphics, top view is two furrows
                If (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                    _xLabel = mDictionary.tFurrowLength.Translated + " = TBD"
                Else
                    _xLabel = mDictionary.tFurrowLength.Translated + " = " + mSystemGeometry.Length.ValueString
                End If

                ' Display Area as addition info
                Dim _area As Double = mSystemGeometry.FieldArea
                Dim _areaUnits As Units = Units.Hectares

                If (mSystemGeometry.Length.DisplayUnits = Units.Feet) Then
                    _areaUnits = Units.Acres
                End If

                Dim _aLabel As String = mDictionary.tArea.Translated + " = " + UnitTextWithUnits(_area, _areaUnits, 6)

                ' Draw top view of two furrows & labels
                _topRect.Y = CInt((_rect.Height / 2) - 20)
                _topRect.Height = 5

                _graphics.DrawRectangle(_blackPen, _topRect)
                _topRect.Y += 15
                _graphics.DrawRectangle(_blackPen, _topRect)
                _topRect.Y += 15
                _graphics.DrawRectangle(_blackPen, _topRect)

                _size = _graphics.MeasureString(_xLabel, Me.Font)
                _graphics.DrawString(_xLabel, Me.Font, _grayBrush, _
                                    (_rect.Width - _size.Width) / 2, _
                                    _topRect.Y + _topRect.Height + 1)

                _size = _graphics.MeasureString(_aLabel, Me.Font)
                _graphics.DrawString(_aLabel, Me.Font, _grayBrush, _
                                    _rect.Width - _size.Width, _rect.Y)

        End Select

        Return _topRect

    End Function
    '
    ' Draw the Side View (Basin & Border)
    '
    Private Sub DrawSideView(ByVal _graphics As Graphics, ByVal _rect As Rectangle, ByVal _topView As Rectangle)

        ' Side View
        Dim _title As String = mDictionary.tSideView.Translated

        ' Get size of font
        Dim _bold As Font = New Font(Me.Font, FontStyle.Bold)
        Dim _size As SizeF = _graphics.MeasureString(_title, _bold)
        Dim _margin As Integer = CInt(_size.Height + 1)

        ' Get drawing tools
        Dim _blackPen As Pen = BlackPen1()
        Dim _grayBrush As SolidBrush = DarkGraySolidBrush()
        Dim _blackBrush As SolidBrush = BlackSolidBrush()
        Dim _vertical As New StringFormat(StringFormatFlags.DirectionVertical)

        ' What is drawn depends on the World & Cross Section
        _graphics.DrawString(_title, _bold, _blackBrush, _rect.X, _rect.Y + _margin - 1)

        Dim _upstream As UpstreamConditions = CType(mSystemGeometry.UpstreamCondition.Value, UpstreamConditions)
        Dim _downstream As DownstreamConditions = CType(mSystemGeometry.DownstreamCondition.Value, DownstreamConditions)
        Dim _bottom As BottomDescriptions = CType(mSystemGeometry.BottomDescription.Value, BottomDescriptions)
        Dim _slope As Double = mSystemGeometry.AverageSlope
        Dim _slopeText As String = SlopeString(_slope, 0)

        ' Draw slope
        Dim _sLabel As String
        Dim _sideView As Rectangle = New Rectangle(_topView.X, CInt(_rect.Y + (_rect.Height * 3) / 4), _
                                                   _topView.Width, 6)

        Dim _side1 As Point = New Point(_sideView.X, _sideView.Y)
        Dim _side2 As Point = New Point(_side1.X + _sideView.Width, _side1.Y)
        Dim _side3 As Point = New Point(_side2.X, _side2.Y + _sideView.Height)
        Dim _side4 As Point = New Point(_side1.X, _side3.Y)

        Select Case (_bottom)
            Case Globals.BottomDescriptions.SlopeTable, Globals.BottomDescriptions.AvgFromSlopeTable

                If (_slope < 0.0) Then
                    _sLabel = mDictionary.tNegativeAverageSlope.Translated + " = " + _slopeText
                    _side1.Y += _sideView.Height
                    _side4.Y += _sideView.Height
                ElseIf (_slope = 0.0) Then
                    _sLabel = mDictionary.tSlopeIsLevel.Translated
                Else ' Slope is positive
                    _sLabel = mDictionary.tAverageSlope.Translated + " = " + _slopeText
                    _side2.Y += _sideView.Height
                    _side3.Y += _sideView.Height
                End If

            Case Globals.BottomDescriptions.ElevationTable, Globals.BottomDescriptions.AvgFromElevTable

                If (_slope < 0.0) Then
                    _sLabel = mDictionary.tNegativeAverageSlope.Translated + " = " + _slopeText
                    _side1.Y += _sideView.Height
                    _side4.Y += _sideView.Height
                ElseIf (_slope = 0.0) Then
                    _sLabel = mDictionary.tSlopeIsLevel.Translated
                Else ' Slope is positive
                    _sLabel = mDictionary.tAverageSlope.Translated + " = " + _slopeText
                    _side2.Y += _sideView.Height
                    _side3.Y += _sideView.Height
                End If

            Case Else ' Assume Globals.BottomDescriptions.Slope

                If (_slope < 0.0) Then
                    _sLabel = mDictionary.tNegativeSlope.Translated + " = " + _slopeText
                    _side1.Y += _sideView.Height
                    _side4.Y += _sideView.Height
                ElseIf (_slope = 0.0) Then
                    _sLabel = mDictionary.tSlopeIsLevel.Translated
                Else ' Slope is positive
                    _sLabel = mDictionary.tSlope.Translated + " = " + _slopeText
                    _side2.Y += _sideView.Height
                    _side3.Y += _sideView.Height
                End If
        End Select

        Dim _sidePoly As Point() = {_side1, _side2, _side3, _side4}
        _graphics.DrawPolygon(_blackPen, _sidePoly)

        _size = _graphics.MeasureString(_sLabel, Me.Font) ' Slope (top-right)
        _graphics.DrawString(_sLabel, Me.Font, _grayBrush, _
                            _rect.Width - _size.Width, _rect.Y + _margin - 1)

        ' Draw upstream & downstream conditions
        Dim _wLabel As String
        If (0.0 <= _slope) Then
            _wLabel = "-- " + mDictionary.tWaterFlow.Translated + " ->"
        Else
            _wLabel = "<- " + mDictionary.tWaterFlow.Translated + " --"
        End If
        _size = _graphics.MeasureString(_wLabel, Me.Font) ' Water Flow (middle)
        Dim _wLoc As Integer = CInt((_rect.Width - _size.Width) / 2)
        _graphics.DrawString(_wLabel, Me.Font, _grayBrush, _wLoc, _side1.Y - _margin)

        ' Draw upstream condition
        Dim _x As Integer = Math.Min(_side1.X, _wLoc - 30)

        If (0.0 <= _slope) Then
            If (_upstream = Globals.UpstreamConditions.NoDrainback) Then
                Dim _rightArrow As Point() = GetArrowPoly(_x - 4, _side1.Y - 16, ArrowType.Right)
                _graphics.DrawPolygon(_blackPen, _rightArrow)
            Else ' Assume Drainback
                Dim _bothArrow As Point() = GetArrowPoly(_x - 6, _side1.Y - 16, ArrowType.Both)
                _graphics.DrawPolygon(_blackPen, _bothArrow)
            End If
        Else ' Negative
            Dim _leftArrow As Point() = GetArrowPoly(_x - 6, _side1.Y - 16, ArrowType.Left)
            _graphics.DrawPolygon(_blackPen, _leftArrow)
        End If

        ' Draw downstream condition
        _x = CInt(Math.Max(_side2.X, _wLoc + _size.Width + 20))

        If (0.0 <= _slope) Then
            If (_downstream = Globals.DownstreamConditions.OpenEnd) Then
                Dim _rightArrow As Point() = GetArrowPoly(_x - 12, _side2.Y - 16, ArrowType.Right)
                _graphics.DrawPolygon(_blackPen, _rightArrow)
            End If
        End If

    End Sub
    '
    ' Get point array that will draw the requested arrow
    '
    Private Enum ArrowType
        Left
        Right
        Both
    End Enum

    Private Function GetArrowPoly(ByVal _x As Integer, ByVal _y As Integer, ByVal _type As ArrowType) As Point()

        Dim _size As Integer = 8
        Dim _arrowHeight As Integer = CInt((_size * 3) / 2)

        Dim _arrow0 As Point = New Point(_x, _y)
        Dim _arrow1 As Point = New Point(_arrow0.X + (_size * 2), _arrow0.Y)
        Dim _arrow2 As Point = New Point(_arrow1.X, _arrow1.Y - _size)
        Dim _arrow3 As Point = New Point(_arrow2.X + _arrowHeight, _arrow2.Y + _arrowHeight)
        Dim _arrow4 As Point = New Point(_arrow3.X - _arrowHeight, _arrow3.Y + _arrowHeight)
        Dim _arrow5 As Point = New Point(_arrow4.X, _arrow4.Y - _size)
        Dim _arrow6 As Point = New Point(_arrow5.X - (_size * 2), _arrow5.Y)
        Dim _arrow7 As Point = New Point(_arrow6.X, _arrow6.Y + _size)
        Dim _arrow8 As Point = New Point(_arrow7.X - _arrowHeight, _arrow7.Y - _arrowHeight)
        Dim _arrow9 As Point = New Point(_arrow8.X + _arrowHeight, _arrow8.Y - _arrowHeight)

        Dim poly As Point() = Nothing

        Select Case _type

            Case ArrowType.Both

                Dim _bothPoly As Point() = {_arrow0, _arrow1, _arrow2, _arrow3, _arrow4, _
                                            _arrow5, _arrow6, _arrow7, _arrow8, _arrow9}
                poly = _bothPoly

            Case ArrowType.Left

                Dim _leftPoly As Point() = {_arrow5, _arrow6, _arrow7, _arrow8, _arrow9, _
                                            _arrow0, _arrow1}
                poly = _leftPoly

            Case ArrowType.Right

                Dim _rightPoly As Point() = {_arrow0, _arrow1, _arrow2, _arrow3, _arrow4, _
                                             _arrow5, _arrow6}
                poly = _rightPoly

        End Select

        Return poly
    End Function
    '
    ' Draw the End View (Furrow)
    '
    Private Sub DrawEndView(ByVal _graphics As Graphics, ByVal _rect As Rectangle)

        ' End View
        Dim _title As String = mDictionary.tCrossSection.Translated

        ' Get size of font
        Dim _bold As Font = New Font(Me.Font, FontStyle.Bold)
        Dim _size As SizeF = _graphics.MeasureString(_title, _bold)
        Dim _margin As Integer = CInt(_size.Height + 1)

        ' Compute graphics area for end view rectangle; leave room for labels
        Dim _endRect As Rectangle = New Rectangle(_rect.X + _margin, _
                                                  _rect.Y + (2 * _margin), _
                                                  _rect.Width - (2 * _margin), _
                                                  _rect.Height - (3 * _margin))

        ' Get drawing tools
        Dim _grayPen As Pen = DarkGrayPen()
        Dim _blackPen As Pen = BlackPen1()
        Dim _grayBrush As SolidBrush = DarkGraySolidBrush()
        Dim _blackBrush As SolidBrush = BlackSolidBrush()
        Dim _vertical As New StringFormat(StringFormatFlags.DirectionVertical)

        ' What is drawn depends on the Cross Section
        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

            Select Case (mSystemGeometry.FurrowShape.Value)

                Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData
                    '
                    ' Power Law Equation:  W = C * Y^E
                    '

                    ' Start with non-tabulated power law dimensions
                    Dim _widthAt100mm As Double = mSystemGeometry.WidthAt100mm.Value ' W@100mm
                    Dim _M As Double = mSystemGeometry.PowerLawExponent.Value ' E
                    Dim _Y As Double = mSystemGeometry.MaximumDepth.Value ' Y

                    ' Replace with tabulated dimensions, if selected
                    If (mSystemGeometry.EnableTabulatedFurrowShape.Value) Then
                        Dim tdx As Integer = Me.PowerLawTableControl.RowSelected
                        Dim row As DataRow = mSystemGeometry.PowerLawTable.Value.Rows(tdx)

                        _widthAt100mm = CDbl(row.Item(Srfr.Globals.sW100mm))
                        _M = CDbl(row.Item(Srfr.Globals.sM))
                        _Y = CDbl(row.Item(Srfr.Globals.sDepthMM))
                    End If

                    Dim _C As Double = _widthAt100mm / (0.1 ^ _M)
                    Dim _TW As Double = _C * (_Y ^ _M)

                    Dim _wLabel As String
                    Select Case (mUnitsSystem.UnitSystem)
                        Case UnitsDefinition.UnitSystems.English
                            _wLabel = "- - - " + mDictionary.tWidthAt.Translated & " 4in = " + ShapeString(_widthAt100mm)
                        Case Else ' Assume UnitsDefinition.UnitSystems.Metric
                            _wLabel = "- - - " + mDictionary.tWidthAt.Translated & " 100mm = " + ShapeString(_widthAt100mm)
                    End Select

                    Dim _mLabel As String = mDictionary.tExponent.Translated & " = " + Format(_M, "0.0###")
                    Dim _dLabel As String = mDictionary.tDepth.Translated & " = " + ShapeString(_Y)
                    Dim _twLabel As String = mDictionary.tTopWidth.Translated & " = " & ShapeString(_TW)

                    ' Determine optimum enclosing rectanble for graphics
                    Dim _ratio As Double = (_endRect.Width * 1.0) / (_endRect.Height * 1.0)

                    If (_ratio < (_TW / _Y)) Then
                        ' Width is limited
                        _endRect.Height = CInt(_endRect.Width * (_Y / _TW))
                        _endRect.Y = CInt(_rect.Y + ((_rect.Height - _endRect.Height + _margin) / 2))
                    Else
                        ' Depth is limited
                        _endRect.Width = CInt(_endRect.Height * (_TW / _Y))
                        _endRect.X = CInt(_rect.X + ((_rect.Width - _endRect.Width) / 2))
                    End If

                    ' Compute & draw power law furrow
                    Dim _depthPoints As Integer = _endRect.Height
                    Dim _widthPoints As Integer = _endRect.Width

                    Dim _center As Integer = CInt(_endRect.X + (_endRect.Width / 2))  ' Center of furrow
                    Dim _bottom As Integer = _endRect.Y + _endRect.Height       ' Bottom of furrow

                    Dim x1l As Integer = _center    ' x - left half
                    Dim x1r As Integer = _center    ' x - right half
                    Dim x2l, x2r As Integer

                    Dim y1 As Integer = _bottom
                    Dim y2 As Integer

                    For _pt As Integer = 1 To _depthPoints
                        Dim _d As Double = (_Y * _pt) / _depthPoints
                        Dim _w As Double = (_C * (_d ^ _M)) / 2.0

                        Dim _dw As Integer = CInt((_w * _widthPoints) / _TW)

                        y2 = _bottom - _pt

                        ' Draw left half of power law curve
                        x2l = _center - _dw
                        _graphics.DrawLine(_blackPen, x1l, y1, x2l, y2)

                        ' Draw right half of power law curve
                        x2r = _center + _dw
                        _graphics.DrawLine(_blackPen, x1r, y1, x2r, y2)

                        x1l = x2l
                        x1r = x2r
                        y1 = y2
                    Next

                    ' Draw 100mm depth line
                    If (0.1 <= _Y) Then
                        Dim _d As Double = 0.1 ' 100mm
                        Dim _w As Double = (_C * (_d ^ _M)) / 2.0

                        Dim _dw As Integer = CInt((_w * _widthPoints) / _TW)

                        y1 = CInt(_bottom - ((_d * _depthPoints) / _Y))

                        x1l = _center - _dw
                        x1r = _center + _dw

                        _grayPen.DashStyle = Drawing2D.DashStyle.Dash
                        _graphics.DrawLine(_grayPen, x1l, y1, x1r, y1)
                    End If

                    ' Add dimension labels
                    _size = _graphics.MeasureString(_wLabel, Me.Font) ' Width at 100mm (bottom-center)
                    _graphics.DrawString(_wLabel, Me.Font, _grayBrush, _
                                        (_rect.Width - _size.Width) / 2, _
                                        _endRect.Y + _endRect.Height + 1)

                    _size = _graphics.MeasureString(_dLabel, Me.Font) ' Depth
                    _graphics.DrawString(_dLabel, Me.Font, _grayBrush, _
                                        _endRect.X - _size.Height - 2, _
                                        _endRect.Y + ((_endRect.Height - _size.Width) / 2), _
                                        _vertical)

                    _size = _graphics.MeasureString(_mLabel, Me.Font)   ' Exponent (top-right)
                    _graphics.DrawString(_mLabel, Me.Font, _grayBrush, _
                                        _rect.Width - _size.Width, _
                                        _rect.Y + _margin - 1)

                    _size = _graphics.MeasureString(_twLabel, Me.Font)   ' Top Width (top-center)
                    _graphics.DrawString(_twLabel, Me.Font, _grayBrush, _
                                        (_rect.Width - _size.Width) / 2, _
                                        _rect.Y + _margin - 1)

                Case Else ' Assume Trapezoid

                    ' Start with non-tabulated trapezoid dimensions
                    Dim _BW As Double = mSystemGeometry.BottomWidth.Value
                    Dim _SS As Double = mSystemGeometry.SideSlope.Value
                    Dim _Y As Double = mSystemGeometry.MaximumDepth.Value

                    ' Replace with tabulated dimensions, if selected
                    If (mSystemGeometry.EnableTabulatedFurrowShape.Value) Then
                        Dim tdx As Integer = Me.TrapezoidTableControl.RowSelected
                        Dim row As DataRow = mSystemGeometry.TrapezoidTable.Value.Rows(tdx)

                        _BW = CDbl(row.Item(Srfr.Globals.sBWmm))
                        _SS = CDbl(row.Item(Srfr.Globals.sSS))
                        _Y = CDbl(row.Item(Srfr.Globals.sDepthMM))
                    End If

                    Dim _Top As Double = _BW + (2 * _Y * _SS)

                    Dim _bwLabel As String = mDictionary.tBottomWidth.Translated + " = " + ShapeString(_BW)
                    Dim _ssLabel As String = mDictionary.tSideSlope.Translated + " = " + SideSlopeString(_SS)
                    Dim _yLabel As String = mDictionary.tDepth.Translated + " = " + ShapeString(_Y)
                    Dim _twLabel As String = mDictionary.tTopWidth.Translated & " = " & ShapeString(_Top)

                    ' Compute top width
                    Dim _topWidth As Double = Math.Max(_BW, _BW + (2.0 * (_Y * _SS)))

                    ' Determine optimum enclosing rectangle for graphics
                    Dim _ratio As Double = (_endRect.Width * 1.0) / (_endRect.Height * 1.0)

                    If (_ratio < (_topWidth / _Y)) Then
                        ' Width is limited
                        _endRect.Height = CInt(_endRect.Width * (_Y / _topWidth))
                        _endRect.Y = CInt(_rect.Y + ((_rect.Height - _endRect.Height + _margin) / 2))
                    Else
                        ' Depth is limited
                        _endRect.Width = CInt(_endRect.Height * (_topWidth / _Y))
                        _endRect.X = CInt(_rect.X + ((_rect.Width - _endRect.Width) / 2))
                    End If

                    ' Compute trapezoid furrow
                    Dim _sw As Integer = CInt(_endRect.Height * _SS) ' Side width
                    Dim _tw As Integer = _endRect.X + _endRect.Width    ' Top width
                    Dim _d As Integer = _endRect.Y + _endRect.Height    ' Depth

                    Dim _point1 As Point = New Point(_endRect.X, _endRect.Y) ' 1 <-------tw------> 4
                    Dim _point2 As Point = New Point(_endRect.X + _sw, _d)   '   *     |         *
                    Dim _point3 As Point = New Point(_tw - _sw, _d)          '     *   |d      *
                    Dim _point4 As Point = New Point(_tw, _endRect.Y)        ' <-sw->2 ***** 3<-sw->

                    ' Draw trapezoid
                    Dim _trapezoid As Point() = {_point1, _point2, _point3, _point4}

                    _graphics.DrawLines(_blackPen, _trapezoid)

                    ' Add dimension labels
                    _size = _graphics.MeasureString(_bwLabel, Me.Font) ' Bottom Width (bottom-center)
                    _graphics.DrawString(_bwLabel, Me.Font, _grayBrush, _
                                        (_rect.Width - _size.Width) / 2, _
                                        _d + 1)

                    _size = _graphics.MeasureString(_yLabel, Me.Font) ' Depth (center)
                    If (_endRect.Height < _size.Width) Then
                        _graphics.DrawString(_yLabel, Me.Font, _grayBrush, _
                                            (_rect.Width - _size.Width) / 2, _
                                            _d - (2 * _margin))
                    Else
                        _graphics.DrawString(_yLabel, Me.Font, _grayBrush, _
                                            (_rect.Width - _size.Height) / 2, _
                                            _d - _size.Width, _
                                            _vertical)
                    End If

                    _size = _graphics.MeasureString(_ssLabel, Me.Font) ' Side Slope (top-right)
                    _graphics.DrawString(_ssLabel, Me.Font, _grayBrush, _
                                        _rect.Width - _size.Width, _
                                        _rect.Y + _margin - 1)

                    _size = _graphics.MeasureString(_twLabel, Me.Font) ' Top Width (top-center)
                    _graphics.DrawString(_twLabel, Me.Font, _grayBrush, _
                                            (_rect.Width - _size.Width) / 2, _
                                        _rect.Y + _margin - 1)

            End Select

            ' Draw the furrow shape label
            _size = _graphics.MeasureString(_title, _bold)
            _graphics.DrawString(_title, _bold, _blackBrush, _rect.X, _rect.Y + _margin - 1)

        End If

    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated
        Select Case reason
            Case WinSRFR.Reasons.Language
                UpdateLanguage()
        End Select
    End Sub
    '
    ' Update the graphics when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        ' Don't allow event driven updates prior to initialization
        If Not (mSystemGeometry Is Nothing) Then
            UpdateUI()
        End If
    End Sub
    '
    ' Update UI when any System Geometry Property value changes
    '
    Public Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateUI()
    End Sub

#End Region

#Region " UI Event Handlers "
    '
    ' Field width must be updated when either Furrow Spacing or Furrows per Set change
    '
    Private Sub FurrowSpacingControl_ControlValueChanged() _
    Handles FurrowSpacingControl.ControlValueChanged
        Dim width As DoubleParameter = mSystemGeometry.Width
        width.Value = mSystemGeometry.FurrowSpacing.Value * mSystemGeometry.FurrowsPerSet.Value
        width.Source = mSystemGeometry.FurrowSpacing.Source
        mSystemGeometry.Width = width
    End Sub

    Private Sub FurrowsPerSetControl_ControlValueChanged() _
    Handles FurrowsPerSetControl.ControlValueChanged
        Dim width As DoubleParameter = mSystemGeometry.Width
        width.Value = mSystemGeometry.FurrowSpacing.Value * mSystemGeometry.FurrowsPerSet.Value
        width.Source = mSystemGeometry.FurrowsPerSet.Source
        mSystemGeometry.Width = width
    End Sub
    '
    ' Table value changes require graph to be redrawn
    '
    Private Sub PowerLawTableControl_ControlValueChanged() _
    Handles PowerLawTableControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub PowerLawTableControl_RowChanged() _
    Handles PowerLawTableControl.RowChanged
        UpdateGraphics()
    End Sub

    Private Sub TrapezoidTableControl_ControlValueChanged() _
    Handles TrapezoidTableControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub TrapezoidTableControl_RowChanged() _
    Handles TrapezoidTableControl.RowChanged
        UpdateGraphics()
    End Sub
    '
    ' Slope changes can effect Cell Density, Solution Model & DMLMOD
    '
    Private Sub BottomDescriptionControl_ControlValueChanged() _
    Handles BottomDescriptionControl.ControlValueChanged
        mUnit.SrfrCriteriaRef.CheckCellDensity(CellDensities.Medium)
        mUnit.SrfrCriteriaRef.CheckSolutionModel()
    End Sub

    Private Sub SlopeControl_ControlValueChanged() _
    Handles SlopeControl.ControlValueChanged
        mUnit.SrfrCriteriaRef.CheckCellDensity(CellDensities.Medium)
        mUnit.SrfrCriteriaRef.CheckSolutionModel()
    End Sub
    '
    ' User wants to edit Slope or Elevation table
    '
    Private Sub EditSlopeTableButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditSlopeTableButton.Click

        Dim db As VaryWithDialogBox
        Dim variation As VaryByLocTime.Variations
        Dim result As DialogResult = DialogResult.None
        Dim markedForUndo As Boolean = False

        Dim bottomDesc As BottomDescriptions = CType(mSystemGeometry.BottomDescription.Value, BottomDescriptions)

        Select Case (bottomDesc)
            Case Globals.BottomDescriptions.SlopeTable, _
                 Globals.BottomDescriptions.AvgFromSlopeTable

                ' Get the Elevation Table
                Dim elevationParam As DataSetParameter = mSystemGeometry.ElevationTable
                Dim elevationTableSet As DataSet = elevationParam.Value
                Dim elevationTable As DataTable = elevationTableSet.Tables(0)

                Dim elevRowCount As Integer = elevationTable.Rows.Count
                Dim elevationRow As DataRow = elevationTable.Rows(elevRowCount - 1)
                Dim lastElevation As Double = elevationRow.Item(1)

                If (0.0 < lastElevation) Then ' Elevation data has been entered
                    ' Warn user elevations will be lost when edited as slopes
                    Dim title As String = mDictionary.tEditingSlopeTable.Translated
                    Dim msg As String = mDictionary.tElevationTableEntered.Translated
                    msg &= Chr(10) & Chr(10) & mDictionary.tEditingSlopeWillLoseData.Translated
                    msg &= Chr(10) & Chr(10) & mDictionary.tDoYouWantToContinue.Translated

                    Dim yesno As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo Or MsgBoxStyle.Information, title)
                    If (yesno = MsgBoxResult.No) Then
                        Exit Sub
                    End If
                End If

                ' Get the Slope Table and its Variation
                Dim slopeParam As DataSetParameter = mSystemGeometry.SlopeTable
                Dim slopeTableSet As DataSet = slopeParam.Value

                Dim slopeVariation As IntegerParameter = mSystemGeometry.SlopeVariation
                variation = CType(slopeVariation.Value, VaryByLocTime.Variations)

                ' Initialize & display the Vary By dialog box to allow editing
                While Not (result = DialogResult.OK)

                    db = New VaryWithDialogBox(slopeTableSet, variation)
                    UpdateTranslation(db)
                    db.Text = mDictionary.tSlopeTableEditor.Translated
                    db.FieldLength = mSystemGeometry.Length.Value
                    db.MinDistances = 1

                    result = db.ShowDialog

                    If (result = DialogResult.OK) Then

                        ' Get the original Slope Table
                        slopeParam = mSystemGeometry.SlopeTable

                        ' Compare it to the new one
                        If (DataSetsAreDifferent(slopeParam.Value, slopeTableSet)) Then
                            ' If different, save the new one
                            If Not (markedForUndo) Then
                                markedForUndo = True
                                mMyStore.MarkForUndo(mDictionary.tSlopeTableChange.Translated)
                            End If

                            slopeParam.Source = DataStore.Globals.ValueSources.UserEntered
                            slopeParam.Value = slopeTableSet
                            mSystemGeometry.SlopeTable = slopeParam

                            ' Replace the Elevation Table with a translated Slope Table
                            elevationTableSet = mSystemGeometry.ElevationTableFromSlopeTable(slopeTableSet)

                            elevationParam = mSystemGeometry.ElevationTable
                            elevationParam.Source = DataStore.Globals.ValueSources.UserEntered
                            elevationParam.Value = elevationTableSet
                            mSystemGeometry.ElevationTable = elevationParam
                        End If

                        ' Check for Vary By change
                        If Not (variation = db.Variation) Then

                            Debug.Assert(False, "Vary By change") ' This code must be verified

                            If Not (markedForUndo) Then
                                markedForUndo = True
                                mMyStore.MarkForUndo(mDictionary.tSlopeTableChange.Translated)
                            End If

                            slopeVariation.Source = DataStore.Globals.ValueSources.UserEntered
                            slopeVariation.Value = db.Variation
                            mSystemGeometry.SlopeVariation = slopeVariation

                            ' Replace the Elevation Variation with the Slope Variation
                            Dim elevationVariation As IntegerParameter = mSystemGeometry.ElevationVariation
                            elevationVariation.Source = DataStore.Globals.ValueSources.UserEntered
                            elevationVariation.Value = db.Variation
                            mSystemGeometry.ElevationVariation = elevationVariation

                        End If

                        ' Slope changes can effect Cell Density, Solution Model & DMLMOD
                        mUnit.SrfrCriteriaRef.CheckCellDensity(CellDensities.Medium)
                        mUnit.SrfrCriteriaRef.CheckSolutionModel()

                    ElseIf (result = DialogResult.Cancel) Then
                        Return
                    End If
                End While

            Case Globals.BottomDescriptions.ElevationTable, _
                 Globals.BottomDescriptions.AvgFromElevTable

                ' Get the Elevation Table and its Variation
                Dim elevationParam As DataSetParameter = mSystemGeometry.ElevationTable
                Dim elevationTableSet As DataSet = elevationParam.Value
                Dim elevationTable As DataTable = elevationTableSet.Tables(0)

                If (elevationTable.Columns(1).ExtendedProperties.Contains("Format")) Then
                    elevationTable.Columns(1).ExtendedProperties.Remove("Format")
                End If
                elevationTable.Columns(1).ExtendedProperties.Add("Format", "0.00#")

                Dim elevationVariation As IntegerParameter = mSystemGeometry.ElevationVariation
                variation = CType(elevationVariation.Value, VaryByLocTime.Variations)

                ' Initialize & display the Vary By dialog box to allow editing
                While Not (result = DialogResult.OK)

                    db = New VaryWithDialogBox(elevationTableSet, variation)
                    UpdateTranslation(db)
                    db.Text = mDictionary.tElevationTableEditor.Translated
                    db.FieldLength = mSystemGeometry.Length.Value
                    db.MinDistances = 2

                    result = db.ShowDialog

                    If (result = DialogResult.OK) Then

                        ' Get the original Elevation Table
                        elevationParam = mSystemGeometry.ElevationTable

                        ' Compare it to the new one
                        If (DataSetsAreDifferent(elevationParam.Value, elevationTableSet)) Then
                            ' If different, save the new one
                            If Not (markedForUndo) Then
                                markedForUndo = True
                                mMyStore.MarkForUndo(mDictionary.tElevationTableChange.Translated)
                            End If

                            elevationParam.Source = DataStore.Globals.ValueSources.UserEntered
                            elevationParam.Value = elevationTableSet
                            mSystemGeometry.ElevationTable = elevationParam

                            ' Replace the Slope Table with a translated Elevation Table
                            elevationTableSet = mSystemGeometry.SlopeTableFromElevationTable(elevationTableSet)

                            Dim slopeTable As DataSetParameter = mSystemGeometry.SlopeTable
                            slopeTable.Source = DataStore.Globals.ValueSources.UserEntered
                            slopeTable.Value = elevationTableSet
                            mSystemGeometry.SlopeTable = slopeTable

                        End If

                        ' Check for Vary By change
                        If Not (variation = db.Variation) Then

                            Debug.Assert(False, "Vary By change") ' This code must be verified

                            If Not (markedForUndo) Then
                                markedForUndo = True
                                mMyStore.MarkForUndo(mDictionary.tElevationTableChange.Translated)
                            End If

                            elevationVariation.Source = DataStore.Globals.ValueSources.UserEntered
                            elevationVariation.Value = db.Variation
                            mSystemGeometry.ElevationVariation = elevationVariation

                            ' Replace the Slope Variation with the Elevation Variation
                            Dim slopeVariation As IntegerParameter = mSystemGeometry.SlopeVariation
                            slopeVariation.Source = DataStore.Globals.ValueSources.UserEntered
                            slopeVariation.Value = db.Variation
                            mSystemGeometry.SlopeVariation = slopeVariation

                        End If

                        ' Slope changes can effect Cell Density, Solution Model & DMLMOD
                        mUnit.SrfrCriteriaRef.CheckCellDensity(CellDensities.Medium)
                        mUnit.SrfrCriteriaRef.CheckSolutionModel()

                    ElseIf (result = DialogResult.Cancel) Then
                        Return
                    End If
                End While

            Case Else
                Debug.Assert(False, "Edit Table not compatible with Slope selection")
        End Select

        ' Update the UI to reflect any changes
        UpdateBottomDescription()

    End Sub
    '
    ' User wants to edit Furrow Shape
    '
    Private Sub EditFurrowShapeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditFurrowShapeButton.Click

        Dim furrowShape As FurrowShapes = CType(mSystemGeometry.FurrowShape.Value, FurrowShapes)

        Select Case (furrowShape)

            ' Setup dialog box for editing Furrow Shape table
            Case FurrowShapes.PowerLawFromFieldData, _
                 FurrowShapes.TrapezoidFromFieldData

                Dim fieldData As FurrowFieldData = New FurrowFieldData(mUnit)

                ' Load dialog with values in current display units
                fieldData.FurrowShape = CType(mSystemGeometry.FurrowShape.Value, FurrowShapes)

                fieldData.TopSectionWidth = mSystemGeometry.TopSectionWidth.GetValue
                fieldData.MiddleSectionWidth = mSystemGeometry.MiddleSectionWidth.GetValue
                fieldData.BottomSectionWidth = mSystemGeometry.BottomSectionWidth.GetValue
                fieldData.SectionDepth = mSystemGeometry.SectionDepth.GetValue

                fieldData.ProfilometerTable = mSystemGeometry.ProfilometerTable.Value
                fieldData.NumberOfRods = mSystemGeometry.NoOfRods.Value
                fieldData.RodSpacing = mSystemGeometry.RodSpacing.GetValue

                fieldData.DepthWidthTable = mSystemGeometry.DepthWidthTable.Value

                fieldData.TrapezoidBottomWidth = mSystemGeometry.BottomWidth.GetValue
                fieldData.TrapezoidSideSlope = mSystemGeometry.SideSlope.Value
                fieldData.TrapezoidMaximumDepth = mSystemGeometry.MaximumDepth.GetValue

                fieldData.PowerLawExponent = mSystemGeometry.PowerLawExponent.Value
                fieldData.PowerLawWidthAt100mm = mSystemGeometry.WidthAt100mm.GetValue
                fieldData.PowerLawMaximumDepth = mSystemGeometry.MaximumDepth.GetValue
                '
                ' At some point, the Field Data Type for this dialog may have been reset.
                '
                ' Check if Top/Middle/Bottom is selected but contains default values.
                '
                Dim DepthWidthTableDefault As Boolean = False
                If ((mSystemGeometry.TopSectionWidth.Value = DefaultTopSectionWidth) _
                And (mSystemGeometry.MiddleSectionWidth.Value = DefaultMiddleSectionWidth) _
                And (mSystemGeometry.BottomSectionWidth.Value = DefaultBottomSectionWidth) _
                And (mSystemGeometry.SectionDepth.Value = DefaultSectionDepth)) Then
                    DepthWidthTableDefault = True
                End If

                ' Are Top/Middle/Bottom values default and selected as input type?
                fieldData.FurrowFieldDataType = CType(mSystemGeometry.FurrowFieldDataType.Value, FurrowFieldDataTypes)
                If (DepthWidthTableDefault And (fieldData.FurrowFieldDataType = FurrowFieldDataTypes.DepthWidthTable)) Then
                    ' Check if input type should actually be Profilometer data.
                    If Not (fieldData.NumberOfRods = DefaultNoOfRods) Then
                        fieldData.FurrowFieldDataType = FurrowFieldDataTypes.ProfilometerTable
                    End If
                End If

                UpdateTranslation(fieldData)

                ' Display dialog box to user
                Dim result As DialogResult = fieldData.ShowDialog
                If (result = DialogResult.OK) Then

                    Dim dblParam As DoubleParameter = Nothing
                    Dim intParam As IntegerParameter = Nothing
                    Dim tblParam As DataTableParameter = Nothing

                    mMyStore.MarkForUndo(mDictionary.tCrossSectionChange.Translated)

                    ' Save the DB's Furrow Field Data Type
                    intParam = mSystemGeometry.FurrowFieldDataType
                    intParam.Value = fieldData.FurrowFieldDataType
                    intParam.Source = ValueSources.UserEntered
                    mSystemGeometry.FurrowFieldDataType = intParam

                    ' Save the selected field type's data
                    Select Case (fieldData.FurrowFieldDataType)

                        Case FurrowFieldDataTypes.WidthTable

                            dblParam = mSystemGeometry.TopSectionWidth
                            dblParam.SetValue(fieldData.TopSectionWidth)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.TopSectionWidth = dblParam

                            dblParam = mSystemGeometry.MiddleSectionWidth
                            dblParam.SetValue(fieldData.MiddleSectionWidth)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.MiddleSectionWidth = dblParam

                            dblParam = mSystemGeometry.BottomSectionWidth
                            dblParam.SetValue(fieldData.BottomSectionWidth)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.BottomSectionWidth = dblParam

                            dblParam = mSystemGeometry.SectionDepth
                            dblParam.SetValue(fieldData.SectionDepth)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.SectionDepth = dblParam

                        Case FurrowFieldDataTypes.ProfilometerTable

                            tblParam = mSystemGeometry.ProfilometerTable
                            tblParam.Value = fieldData.ProfilometerTable
                            tblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.ProfilometerTable = tblParam

                            intParam = mSystemGeometry.NoOfRods
                            intParam.Value = fieldData.NumberOfRods
                            intParam.Source = ValueSources.UserEntered
                            mSystemGeometry.NoOfRods = intParam

                            dblParam = mSystemGeometry.RodSpacing
                            dblParam.SetValue(fieldData.RodSpacing)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.RodSpacing = dblParam

                        Case FurrowFieldDataTypes.DepthWidthTable

                            tblParam = mSystemGeometry.DepthWidthTable
                            tblParam.Value = fieldData.DepthWidthTable
                            tblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.DepthWidthTable = tblParam

                    End Select

                    ' Save the DB's selected Furrow Shape
                    Dim tabulatedShape As FurrowShapes = fieldData.FurrowShape
                    Select Case (tabulatedShape)
                        Case FurrowShapes.Trapezoid
                            tabulatedShape = FurrowShapes.TrapezoidFromFieldData
                        Case Else
                            tabulatedShape = FurrowShapes.PowerLawFromFieldData
                    End Select

                    intParam = mSystemGeometry.FurrowShape
                    intParam.Value = tabulatedShape
                    intParam.Source = ValueSources.UserEntered
                    mSystemGeometry.FurrowShape = intParam

                    ' Save the selected furrow shape's data
                    Select Case (tabulatedShape)

                        Case FurrowShapes.TrapezoidFromFieldData

                            dblParam = mSystemGeometry.BottomWidth
                            dblParam.SetValue(fieldData.TrapezoidBottomWidth)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.BottomWidth = dblParam

                            dblParam = mSystemGeometry.SideSlope
                            dblParam.SetValue(fieldData.TrapezoidSideSlope)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.SideSlope = dblParam

                            dblParam = mSystemGeometry.MaximumDepth
                            dblParam.SetValue(fieldData.TrapezoidMaximumDepth)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.MaximumDepth = dblParam

                        Case FurrowShapes.PowerLawFromFieldData

                            dblParam = mSystemGeometry.PowerLawExponent
                            dblParam.SetValue(fieldData.PowerLawExponent)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.PowerLawExponent = dblParam

                            dblParam = mSystemGeometry.WidthAt100mm
                            dblParam.SetValue(fieldData.PowerLawWidthAt100mm)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.WidthAt100mm = dblParam

                            dblParam = mSystemGeometry.MaximumDepth
                            dblParam.SetValue(fieldData.PowerLawMaximumDepth)
                            dblParam.Source = ValueSources.UserEntered
                            mSystemGeometry.MaximumDepth = dblParam

                    End Select
                End If
        End Select

    End Sub
    '
    ' Make sure UI is up to date whenever it become visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        ' Bottom Description
        Dim btmLoc As Point = New Point(Me.BottomDescriptionBox.Location.X, Me.Height - Me.BottomDescriptionBox.Height - 4)
        BottomDescriptionBox.Location = btmLoc

        Dim boxLoc As Point = New Point(Me.BorderDimensionsBox.Location.X, Me.TitlePanel.Height + 4)

        ' Border
        Me.BorderDimensionsBox.Location = boxLoc
        Me.BorderDimensionsBox.Height = btmLoc.Y - boxLoc.Y

        Me.BorderDepthTableControl.Height = Me.BorderDimensionsBox.Height - Me.BorderDepthTableControl.Location.Y - 8

        ' Furrow
        Me.FurrowShapeBox.Location = boxLoc
        Me.FurrowShapeBox.Height = btmLoc.Y - boxLoc.Y

        Me.PowerLawTablePanel.Height = Me.FurrowShapeBox.Height - Me.PowerLawTablePanel.Location.Y - 8

        Me.TrapezoidTablePanel.Height = Me.FurrowShapeBox.Height - Me.TrapezoidTablePanel.Location.Y - 8

        ' Graphics
        SystemGeometryGraphics.Height = Me.Height - Me.SystemGeometryGraphics.Location.Y - 4
        SystemGeometryGraphics.Width = Me.Width - Me.SystemGeometryGraphics.Location.X - 4
        UpdateGraphics()

    End Sub

#End Region

End Class
