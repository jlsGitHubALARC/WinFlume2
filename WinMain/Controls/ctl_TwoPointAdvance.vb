
'*************************************************************************************************************
' ctl_TwoPointAdvance
'
'   Provides the UI for viewing & editing Two-Point Advance data:
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_TwoPointAdvance
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeTwoPointAdvance()

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
    Friend WithEvents ReadOnlyLabel As DataStore.ctl_Label
    Friend WithEvents ErrorsAndWarnings As WinMain.ErrorRichTextBox
    Friend WithEvents TwoPointBox As DataStore.ctl_GroupBox
    Friend WithEvents Point2UpstreamDepth As System.Windows.Forms.Label
    Friend WithEvents Point1UpstreamDepth As System.Windows.Forms.Label
    Friend WithEvents UpstreamDepthLabel As DataStore.ctl_Label
    Friend WithEvents Point2InfiltratedVolume As System.Windows.Forms.Label
    Friend WithEvents Point1InfiltratedVolume As System.Windows.Forms.Label
    Friend WithEvents InfiltratedVolumeLabel As DataStore.ctl_Label
    Friend WithEvents Point2InflowVolume As System.Windows.Forms.Label
    Friend WithEvents Point1InflowVolume As System.Windows.Forms.Label
    Friend WithEvents InflowVolumeLabel As DataStore.ctl_Label
    Friend WithEvents Point2SurfaceVolume As System.Windows.Forms.Label
    Friend WithEvents Point1SurfaceVolume As System.Windows.Forms.Label
    Friend WithEvents SurfaceVolumeLabel As DataStore.ctl_Label
    Friend WithEvents PowerAdvanceExponent As DataStore.ctl_Label
    Friend WithEvents PowerAdvanceExponentLabel As DataStore.ctl_Label
    Friend WithEvents Point2ElevationDrop As System.Windows.Forms.Label
    Friend WithEvents Point1ElevationDrop As System.Windows.Forms.Label
    Friend WithEvents ElevationDropLabel As DataStore.ctl_Label
    Friend WithEvents Time2Control As DataStore.ctl_DoubleParameter
    Friend WithEvents Time1Control As DataStore.ctl_DoubleParameter
    Friend WithEvents Dist2Control As DataStore.ctl_DoubleParameter
    Friend WithEvents Dist1Control As DataStore.ctl_DoubleParameter
    Friend WithEvents TimeLabel As DataStore.ctl_Label
    Friend WithEvents DistanceLabel As DataStore.ctl_Label
    Friend WithEvents Point2Label As DataStore.ctl_Label
    Friend WithEvents Point1Label As DataStore.ctl_Label
    Friend WithEvents StarLabel9 As System.Windows.Forms.Label
    Friend WithEvents StarLabel1 As System.Windows.Forms.Label
    Friend WithEvents StarLabel2 As System.Windows.Forms.Label
    Friend WithEvents StarLabel3 As System.Windows.Forms.Label
    Friend WithEvents StarLabel4 As System.Windows.Forms.Label
    Friend WithEvents StarLabel5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ReadOnlyLabel = New DataStore.ctl_Label
        Me.ErrorsAndWarnings = New WinMain.ErrorRichTextBox
        Me.TwoPointBox = New DataStore.ctl_GroupBox
        Me.StarLabel5 = New System.Windows.Forms.Label
        Me.StarLabel4 = New System.Windows.Forms.Label
        Me.StarLabel3 = New System.Windows.Forms.Label
        Me.StarLabel2 = New System.Windows.Forms.Label
        Me.StarLabel1 = New System.Windows.Forms.Label
        Me.Point2UpstreamDepth = New System.Windows.Forms.Label
        Me.Point1UpstreamDepth = New System.Windows.Forms.Label
        Me.UpstreamDepthLabel = New DataStore.ctl_Label
        Me.Point2InfiltratedVolume = New System.Windows.Forms.Label
        Me.Point1InfiltratedVolume = New System.Windows.Forms.Label
        Me.InfiltratedVolumeLabel = New DataStore.ctl_Label
        Me.Point2InflowVolume = New System.Windows.Forms.Label
        Me.Point1InflowVolume = New System.Windows.Forms.Label
        Me.InflowVolumeLabel = New DataStore.ctl_Label
        Me.Point2SurfaceVolume = New System.Windows.Forms.Label
        Me.Point1SurfaceVolume = New System.Windows.Forms.Label
        Me.SurfaceVolumeLabel = New DataStore.ctl_Label
        Me.PowerAdvanceExponent = New DataStore.ctl_Label
        Me.PowerAdvanceExponentLabel = New DataStore.ctl_Label
        Me.Point2ElevationDrop = New System.Windows.Forms.Label
        Me.Point1ElevationDrop = New System.Windows.Forms.Label
        Me.ElevationDropLabel = New DataStore.ctl_Label
        Me.Time2Control = New DataStore.ctl_DoubleParameter
        Me.Time1Control = New DataStore.ctl_DoubleParameter
        Me.Dist2Control = New DataStore.ctl_DoubleParameter
        Me.Dist1Control = New DataStore.ctl_DoubleParameter
        Me.TimeLabel = New DataStore.ctl_Label
        Me.DistanceLabel = New DataStore.ctl_Label
        Me.Point2Label = New DataStore.ctl_Label
        Me.Point1Label = New DataStore.ctl_Label
        Me.StarLabel9 = New System.Windows.Forms.Label
        Me.TwoPointBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReadOnlyLabel
        '
        Me.ReadOnlyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReadOnlyLabel.Location = New System.Drawing.Point(616, 400)
        Me.ReadOnlyLabel.Name = "ReadOnlyLabel"
        Me.ReadOnlyLabel.Size = New System.Drawing.Size(160, 23)
        Me.ReadOnlyLabel.TabIndex = 19
        Me.ReadOnlyLabel.Text = "Calculated by WinSRFR"
        Me.ReadOnlyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorsAndWarnings
        '
        Me.ErrorsAndWarnings.BackColor = System.Drawing.SystemColors.Info
        Me.ErrorsAndWarnings.ForeColor = System.Drawing.SystemColors.InfoText
        Me.ErrorsAndWarnings.Location = New System.Drawing.Point(8, 170)
        Me.ErrorsAndWarnings.Name = "ErrorsAndWarnings"
        Me.ErrorsAndWarnings.ReadOnly = True
        Me.ErrorsAndWarnings.Size = New System.Drawing.Size(760, 224)
        Me.ErrorsAndWarnings.TabIndex = 18
        Me.ErrorsAndWarnings.Text = "Error:" & Global.Microsoft.VisualBasic.ChrW(10) & "Warning:" & Global.Microsoft.VisualBasic.ChrW(10) & "Warning:" & Global.Microsoft.VisualBasic.ChrW(10) & "Warning:" & Global.Microsoft.VisualBasic.ChrW(10) & "Warning:"
        '
        'TwoPointBox
        '
        Me.TwoPointBox.AccessibleDescription = "Enter the surface flow advance times for two distances down the field."
        Me.TwoPointBox.AccessibleName = "Two-Point Advance"
        Me.TwoPointBox.Controls.Add(Me.StarLabel5)
        Me.TwoPointBox.Controls.Add(Me.StarLabel4)
        Me.TwoPointBox.Controls.Add(Me.StarLabel3)
        Me.TwoPointBox.Controls.Add(Me.StarLabel2)
        Me.TwoPointBox.Controls.Add(Me.StarLabel1)
        Me.TwoPointBox.Controls.Add(Me.Point2UpstreamDepth)
        Me.TwoPointBox.Controls.Add(Me.Point1UpstreamDepth)
        Me.TwoPointBox.Controls.Add(Me.UpstreamDepthLabel)
        Me.TwoPointBox.Controls.Add(Me.Point2InfiltratedVolume)
        Me.TwoPointBox.Controls.Add(Me.Point1InfiltratedVolume)
        Me.TwoPointBox.Controls.Add(Me.InfiltratedVolumeLabel)
        Me.TwoPointBox.Controls.Add(Me.Point2InflowVolume)
        Me.TwoPointBox.Controls.Add(Me.Point1InflowVolume)
        Me.TwoPointBox.Controls.Add(Me.InflowVolumeLabel)
        Me.TwoPointBox.Controls.Add(Me.Point2SurfaceVolume)
        Me.TwoPointBox.Controls.Add(Me.Point1SurfaceVolume)
        Me.TwoPointBox.Controls.Add(Me.SurfaceVolumeLabel)
        Me.TwoPointBox.Controls.Add(Me.PowerAdvanceExponent)
        Me.TwoPointBox.Controls.Add(Me.PowerAdvanceExponentLabel)
        Me.TwoPointBox.Controls.Add(Me.Point2ElevationDrop)
        Me.TwoPointBox.Controls.Add(Me.Point1ElevationDrop)
        Me.TwoPointBox.Controls.Add(Me.ElevationDropLabel)
        Me.TwoPointBox.Controls.Add(Me.Time2Control)
        Me.TwoPointBox.Controls.Add(Me.Time1Control)
        Me.TwoPointBox.Controls.Add(Me.Dist2Control)
        Me.TwoPointBox.Controls.Add(Me.Dist1Control)
        Me.TwoPointBox.Controls.Add(Me.TimeLabel)
        Me.TwoPointBox.Controls.Add(Me.DistanceLabel)
        Me.TwoPointBox.Controls.Add(Me.Point2Label)
        Me.TwoPointBox.Controls.Add(Me.Point1Label)
        Me.TwoPointBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TwoPointBox.Location = New System.Drawing.Point(8, 8)
        Me.TwoPointBox.Name = "TwoPointBox"
        Me.TwoPointBox.Size = New System.Drawing.Size(760, 152)
        Me.TwoPointBox.TabIndex = 17
        Me.TwoPointBox.TabStop = False
        Me.TwoPointBox.Text = "Two-Point Advance"
        '
        'StarLabel5
        '
        Me.StarLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StarLabel5.Location = New System.Drawing.Point(712, 32)
        Me.StarLabel5.Name = "StarLabel5"
        Me.StarLabel5.Size = New System.Drawing.Size(16, 23)
        Me.StarLabel5.TabIndex = 39
        Me.StarLabel5.Text = "*"
        '
        'StarLabel4
        '
        Me.StarLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StarLabel4.Location = New System.Drawing.Point(616, 32)
        Me.StarLabel4.Name = "StarLabel4"
        Me.StarLabel4.Size = New System.Drawing.Size(16, 23)
        Me.StarLabel4.TabIndex = 38
        Me.StarLabel4.Text = "*"
        '
        'StarLabel3
        '
        Me.StarLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StarLabel3.Location = New System.Drawing.Point(520, 32)
        Me.StarLabel3.Name = "StarLabel3"
        Me.StarLabel3.Size = New System.Drawing.Size(16, 23)
        Me.StarLabel3.TabIndex = 37
        Me.StarLabel3.Text = "*"
        '
        'StarLabel2
        '
        Me.StarLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StarLabel2.Location = New System.Drawing.Point(432, 32)
        Me.StarLabel2.Name = "StarLabel2"
        Me.StarLabel2.Size = New System.Drawing.Size(16, 23)
        Me.StarLabel2.TabIndex = 36
        Me.StarLabel2.Text = "*"
        '
        'StarLabel1
        '
        Me.StarLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StarLabel1.Location = New System.Drawing.Point(352, 32)
        Me.StarLabel1.Name = "StarLabel1"
        Me.StarLabel1.Size = New System.Drawing.Size(16, 23)
        Me.StarLabel1.TabIndex = 35
        Me.StarLabel1.Text = "*"
        '
        'Point2UpstreamDepth
        '
        Me.Point2UpstreamDepth.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point2UpstreamDepth.Location = New System.Drawing.Point(384, 88)
        Me.Point2UpstreamDepth.Name = "Point2UpstreamDepth"
        Me.Point2UpstreamDepth.Size = New System.Drawing.Size(72, 23)
        Me.Point2UpstreamDepth.TabIndex = 19
        Me.Point2UpstreamDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Point1UpstreamDepth
        '
        Me.Point1UpstreamDepth.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point1UpstreamDepth.Location = New System.Drawing.Point(384, 56)
        Me.Point1UpstreamDepth.Name = "Point1UpstreamDepth"
        Me.Point1UpstreamDepth.Size = New System.Drawing.Size(72, 23)
        Me.Point1UpstreamDepth.TabIndex = 11
        Me.Point1UpstreamDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UpstreamDepthLabel
        '
        Me.UpstreamDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpstreamDepthLabel.Location = New System.Drawing.Point(376, 16)
        Me.UpstreamDepthLabel.Name = "UpstreamDepthLabel"
        Me.UpstreamDepthLabel.Size = New System.Drawing.Size(64, 32)
        Me.UpstreamDepthLabel.TabIndex = 3
        Me.UpstreamDepthLabel.Text = "Upstream Depth"
        Me.UpstreamDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Point2InfiltratedVolume
        '
        Me.Point2InfiltratedVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point2InfiltratedVolume.Location = New System.Drawing.Point(656, 88)
        Me.Point2InfiltratedVolume.Name = "Point2InfiltratedVolume"
        Me.Point2InfiltratedVolume.Size = New System.Drawing.Size(88, 23)
        Me.Point2InfiltratedVolume.TabIndex = 22
        Me.Point2InfiltratedVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Point1InfiltratedVolume
        '
        Me.Point1InfiltratedVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point1InfiltratedVolume.Location = New System.Drawing.Point(656, 56)
        Me.Point1InfiltratedVolume.Name = "Point1InfiltratedVolume"
        Me.Point1InfiltratedVolume.Size = New System.Drawing.Size(88, 23)
        Me.Point1InfiltratedVolume.TabIndex = 14
        Me.Point1InfiltratedVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InfiltratedVolumeLabel
        '
        Me.InfiltratedVolumeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltratedVolumeLabel.Location = New System.Drawing.Point(640, 16)
        Me.InfiltratedVolumeLabel.Name = "InfiltratedVolumeLabel"
        Me.InfiltratedVolumeLabel.Size = New System.Drawing.Size(88, 32)
        Me.InfiltratedVolumeLabel.TabIndex = 6
        Me.InfiltratedVolumeLabel.Text = "Infiltrated Volume"
        Me.InfiltratedVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Point2InflowVolume
        '
        Me.Point2InflowVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point2InflowVolume.Location = New System.Drawing.Point(464, 88)
        Me.Point2InflowVolume.Name = "Point2InflowVolume"
        Me.Point2InflowVolume.Size = New System.Drawing.Size(88, 23)
        Me.Point2InflowVolume.TabIndex = 20
        Me.Point2InflowVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Point1InflowVolume
        '
        Me.Point1InflowVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point1InflowVolume.Location = New System.Drawing.Point(464, 56)
        Me.Point1InflowVolume.Name = "Point1InflowVolume"
        Me.Point1InflowVolume.Size = New System.Drawing.Size(88, 23)
        Me.Point1InflowVolume.TabIndex = 12
        Me.Point1InflowVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InflowVolumeLabel
        '
        Me.InflowVolumeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowVolumeLabel.Location = New System.Drawing.Point(448, 16)
        Me.InflowVolumeLabel.Name = "InflowVolumeLabel"
        Me.InflowVolumeLabel.Size = New System.Drawing.Size(88, 32)
        Me.InflowVolumeLabel.TabIndex = 4
        Me.InflowVolumeLabel.Text = "Inflow Volume"
        Me.InflowVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Point2SurfaceVolume
        '
        Me.Point2SurfaceVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point2SurfaceVolume.Location = New System.Drawing.Point(560, 88)
        Me.Point2SurfaceVolume.Name = "Point2SurfaceVolume"
        Me.Point2SurfaceVolume.Size = New System.Drawing.Size(88, 23)
        Me.Point2SurfaceVolume.TabIndex = 21
        Me.Point2SurfaceVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Point1SurfaceVolume
        '
        Me.Point1SurfaceVolume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point1SurfaceVolume.Location = New System.Drawing.Point(560, 56)
        Me.Point1SurfaceVolume.Name = "Point1SurfaceVolume"
        Me.Point1SurfaceVolume.Size = New System.Drawing.Size(88, 23)
        Me.Point1SurfaceVolume.TabIndex = 13
        Me.Point1SurfaceVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SurfaceVolumeLabel
        '
        Me.SurfaceVolumeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurfaceVolumeLabel.Location = New System.Drawing.Point(544, 16)
        Me.SurfaceVolumeLabel.Name = "SurfaceVolumeLabel"
        Me.SurfaceVolumeLabel.Size = New System.Drawing.Size(88, 32)
        Me.SurfaceVolumeLabel.TabIndex = 5
        Me.SurfaceVolumeLabel.Text = "Surface Volume"
        Me.SurfaceVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PowerAdvanceExponent
        '
        Me.PowerAdvanceExponent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerAdvanceExponent.Location = New System.Drawing.Point(200, 120)
        Me.PowerAdvanceExponent.Name = "PowerAdvanceExponent"
        Me.PowerAdvanceExponent.Size = New System.Drawing.Size(104, 23)
        Me.PowerAdvanceExponent.TabIndex = 24
        Me.PowerAdvanceExponent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PowerAdvanceExponentLabel
        '
        Me.PowerAdvanceExponentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerAdvanceExponentLabel.Location = New System.Drawing.Point(16, 120)
        Me.PowerAdvanceExponentLabel.Name = "PowerAdvanceExponentLabel"
        Me.PowerAdvanceExponentLabel.Size = New System.Drawing.Size(176, 23)
        Me.PowerAdvanceExponentLabel.TabIndex = 23
        Me.PowerAdvanceExponentLabel.Text = "Power Advance Exponent"
        Me.PowerAdvanceExponentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Point2ElevationDrop
        '
        Me.Point2ElevationDrop.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point2ElevationDrop.Location = New System.Drawing.Point(304, 88)
        Me.Point2ElevationDrop.Name = "Point2ElevationDrop"
        Me.Point2ElevationDrop.Size = New System.Drawing.Size(72, 23)
        Me.Point2ElevationDrop.TabIndex = 18
        Me.Point2ElevationDrop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Point1ElevationDrop
        '
        Me.Point1ElevationDrop.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Point1ElevationDrop.Location = New System.Drawing.Point(304, 56)
        Me.Point1ElevationDrop.Name = "Point1ElevationDrop"
        Me.Point1ElevationDrop.Size = New System.Drawing.Size(72, 23)
        Me.Point1ElevationDrop.TabIndex = 10
        Me.Point1ElevationDrop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ElevationDropLabel
        '
        Me.ElevationDropLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElevationDropLabel.Location = New System.Drawing.Point(296, 16)
        Me.ElevationDropLabel.Name = "ElevationDropLabel"
        Me.ElevationDropLabel.Size = New System.Drawing.Size(72, 32)
        Me.ElevationDropLabel.TabIndex = 2
        Me.ElevationDropLabel.Text = "Elevation Drop"
        Me.ElevationDropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Time2Control
        '
        Me.Time2Control.AccessibleDescription = "Time the water advance reached the Point 2 Distance."
        Me.Time2Control.AccessibleName = "Point 2 Time"
        Me.Time2Control.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.Time2Control.IsCalculated = False
        Me.Time2Control.IsInteger = False
        Me.Time2Control.Location = New System.Drawing.Point(200, 88)
        Me.Time2Control.Name = "Time2Control"
        Me.Time2Control.Size = New System.Drawing.Size(96, 24)
        Me.Time2Control.TabIndex = 17
        Me.Time2Control.ToBeCalculated = True
        Me.Time2Control.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.Time2Control.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.Time2Control.ValueBackColor = System.Drawing.SystemColors.Window
        Me.Time2Control.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.Time2Control.ValueText = ""
        '
        'Time1Control
        '
        Me.Time1Control.AccessibleDescription = "Time the water advance reached the Point 1 Distance."
        Me.Time1Control.AccessibleName = "Point 1 Time"
        Me.Time1Control.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.Time1Control.IsCalculated = False
        Me.Time1Control.IsInteger = False
        Me.Time1Control.Location = New System.Drawing.Point(200, 56)
        Me.Time1Control.Name = "Time1Control"
        Me.Time1Control.Size = New System.Drawing.Size(96, 24)
        Me.Time1Control.TabIndex = 9
        Me.Time1Control.ToBeCalculated = True
        Me.Time1Control.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.Time1Control.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.Time1Control.ValueBackColor = System.Drawing.SystemColors.Window
        Me.Time1Control.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.Time1Control.ValueText = ""
        '
        'Dist2Control
        '
        Me.Dist2Control.AccessibleDescription = "Distance from the head of the field for the second point in the two-point analysi" & _
            "s."
        Me.Dist2Control.AccessibleName = "Point 2 Distance"
        Me.Dist2Control.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.Dist2Control.IsCalculated = False
        Me.Dist2Control.IsInteger = False
        Me.Dist2Control.Location = New System.Drawing.Point(88, 88)
        Me.Dist2Control.Name = "Dist2Control"
        Me.Dist2Control.Size = New System.Drawing.Size(104, 24)
        Me.Dist2Control.TabIndex = 16
        Me.Dist2Control.ToBeCalculated = True
        Me.Dist2Control.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.Dist2Control.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.Dist2Control.ValueBackColor = System.Drawing.SystemColors.Window
        Me.Dist2Control.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.Dist2Control.ValueText = ""
        '
        'Dist1Control
        '
        Me.Dist1Control.AccessibleDescription = "Distance from the head of the field for the first point in the two-point analysis" & _
            "."
        Me.Dist1Control.AccessibleName = "Point 1 Distance"
        Me.Dist1Control.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.Dist1Control.IsCalculated = False
        Me.Dist1Control.IsInteger = False
        Me.Dist1Control.Location = New System.Drawing.Point(88, 56)
        Me.Dist1Control.Name = "Dist1Control"
        Me.Dist1Control.Size = New System.Drawing.Size(104, 24)
        Me.Dist1Control.TabIndex = 8
        Me.Dist1Control.ToBeCalculated = True
        Me.Dist1Control.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.Dist1Control.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.Dist1Control.ValueBackColor = System.Drawing.SystemColors.Window
        Me.Dist1Control.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.Dist1Control.ValueText = ""
        '
        'TimeLabel
        '
        Me.TimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLabel.Location = New System.Drawing.Point(200, 32)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(88, 23)
        Me.TimeLabel.TabIndex = 1
        Me.TimeLabel.Text = "Time"
        Me.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DistanceLabel
        '
        Me.DistanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DistanceLabel.Location = New System.Drawing.Point(88, 32)
        Me.DistanceLabel.Name = "DistanceLabel"
        Me.DistanceLabel.Size = New System.Drawing.Size(96, 23)
        Me.DistanceLabel.TabIndex = 0
        Me.DistanceLabel.Text = "Distance"
        Me.DistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Point2Label
        '
        Me.Point2Label.Location = New System.Drawing.Point(16, 88)
        Me.Point2Label.Name = "Point2Label"
        Me.Point2Label.Size = New System.Drawing.Size(64, 23)
        Me.Point2Label.TabIndex = 15
        Me.Point2Label.Text = "Point &2"
        Me.Point2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Point1Label
        '
        Me.Point1Label.Location = New System.Drawing.Point(16, 56)
        Me.Point1Label.Name = "Point1Label"
        Me.Point1Label.Size = New System.Drawing.Size(64, 23)
        Me.Point1Label.TabIndex = 7
        Me.Point1Label.Text = "Point &1"
        Me.Point1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StarLabel9
        '
        Me.StarLabel9.Location = New System.Drawing.Point(600, 400)
        Me.StarLabel9.Name = "StarLabel9"
        Me.StarLabel9.Size = New System.Drawing.Size(16, 23)
        Me.StarLabel9.TabIndex = 35
        Me.StarLabel9.Text = "*"
        Me.StarLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctl_TwoPointAdvance
        '
        Me.Controls.Add(Me.StarLabel9)
        Me.Controls.Add(Me.ReadOnlyLabel)
        Me.Controls.Add(Me.ErrorsAndWarnings)
        Me.Controls.Add(Me.TwoPointBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_TwoPointAdvance"
        Me.Size = New System.Drawing.Size(780, 430)
        Me.TwoPointBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Control heights/locations for re-sizing
    '
    Private mMinTwoPointHeight As Integer
    Private mTwoPointHeight As Integer
    Private mMinErrorsAndWarningsHeight As Integer

    Private mMinReadOnlyLabelLocation As System.Drawing.Point
    Private mMinStarLabel9Location As System.Drawing.Point

    Private mFormLoaded As Boolean = False

#End Region

#Region " Initialization "

    Private Sub InitializeTwoPointAdvance()
        '
        ' Save initial control heights/locations for later re-sizing
        '
        mMinTwoPointHeight = MyBase.Height
        mTwoPointHeight = MyBase.Height
        mMinErrorsAndWarningsHeight = Me.ErrorsAndWarnings.Height

        mMinReadOnlyLabelLocation = Me.ReadOnlyLabel.Location
        mMinStarLabel9Location = Me.StarLabel9.Location

        mFormLoaded = True

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Field data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    Private mMyStore As DataStore.ObjectNode
    '
    ' Supported analyses
    '
    Private mElliotWalker As ElliotWalkerTwoPoint
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow)

        Debug.Assert((_unit IsNot Nothing), "Unit is Nothing")
        '
        ' Link this control to its data model and store
        '
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef

        mWorldWindow = worldWindow

        mMyStore = mUnit.MyStore
        '
        ' Elliot-Walker Two-Point Analysis
        '
        mElliotWalker = New ElliotWalkerTwoPoint(mUnit, mWorldWindow)

        ' Point 1
        Dist1Control.LinkToModel(mMyStore, mInflowManagement.Point1DistanceProperty)
        Time1Control.LinkToModel(mMyStore, mInflowManagement.Point1TimeProperty)

        ' Point 2
        Dist2Control.LinkToModel(mMyStore, mInflowManagement.Point2DistanceProperty)
        Time2Control.LinkToModel(mMyStore, mInflowManagement.Point2TimeProperty)

        UpdateUI()

    End Sub

#End Region

#Region " UI Update Methods "

    Private Sub ctl_TwoPointAdvance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        UpdateUI()
    End Sub

    Public Sub UpdateUI()
        If ((Me.Parent IsNot Nothing) And (mElliotWalker IsNot Nothing)) Then
            ' Perform the Elliot-Walker Two-Point analysis
            mElliotWalker.PerformTwoPointAnalysis()
            ' Then estimate Kostiakov k & a
            mElliotWalker.EstimateKostiakov()
            ' Check Warnings & Errors
            mElliotWalker.CheckSetupErrorsAndWarnings()

            ' Calculate & display the Two-Point Elevation Drops
            Dim _pt1Dist As Double = mInflowManagement.Point1Distance.Value
            Dim _pt1Time As Double = mInflowManagement.Point1Time.Value
            Dim _depth As Double = mSystemGeometry.FieldDepthAtDistance(_pt1Dist)
            Me.Point1ElevationDrop.Text = DepthString(_depth, 0)

            Dim _pt2Dist As Double = mInflowManagement.Point2Distance.Value
            Dim _pt2Time As Double = mInflowManagement.Point2Time.Value
            _depth = mSystemGeometry.FieldDepthAtDistance(_pt2Dist)
            Me.Point2ElevationDrop.Text = DepthString(_depth, 0)

            ' Normal Depths
            Dim _depth1 As Double = mElliotWalker.UpstreamDepthT1
            Dim _depth2 As Double = mElliotWalker.UpstreamDepthT2
            Me.Point1UpstreamDepth.Text = DepthString(_depth1, 0)
            Me.Point2UpstreamDepth.Text = DepthString(_depth2, 0)

            ' Display Volumes
            Dim _vol1 As Double = mElliotWalker.InflowVolumeT1
            Dim _vol2 As Double = mElliotWalker.InflowVolumeT2
            Me.Point1InflowVolume.Text = FieldVolumeString(_vol1, 0)
            Me.Point2InflowVolume.Text = FieldVolumeString(_vol2, 0)

            _vol1 = mElliotWalker.SurfaceVolumeT1
            _vol2 = mElliotWalker.SurfaceVolumeT2
            Me.Point1SurfaceVolume.Text = FieldVolumeString(_vol1, 0)
            Me.Point2SurfaceVolume.Text = FieldVolumeString(_vol2, 0)

            _vol1 = mElliotWalker.InfiltratedVolumeT1
            _vol2 = mElliotWalker.InfiltratedVolumeT2
            Me.Point1InfiltratedVolume.Text = FieldVolumeString(_vol1, 0)
            Me.Point2InfiltratedVolume.Text = FieldVolumeString(_vol2, 0)

            ' Power Advance
            Dim _r As Double = Math.Log(_pt1Dist / _pt2Dist) / Math.Log(_pt1Time / _pt2Time)
            Me.PowerAdvanceExponent.Text = UnitText(_r, Units.None, 0)

            If (1.0 < _r) Then
                Me.PowerAdvanceExponent.BackColor = DataStore.BackColor_Errored
            Else
                Me.PowerAdvanceExponent.BackColor = SystemColors.Control
            End If

            ' Update UI display of Errors & Warnings
            If (mElliotWalker.CheckSetupWarnings) Then
                Me.ErrorsAndWarnings.Show()
                Me.ErrorsAndWarnings.Clear()
                Me.ErrorsAndWarnings.DisplayWarnings(mElliotWalker, True)
            Else
                Me.ErrorsAndWarnings.Hide()
            End If
        End If
    End Sub

    Private Sub ctl_TwoPointAdvance_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        ResizeUI()
    End Sub

    Public Sub ResizeUI()
        If (mFormLoaded) Then
            ' Get change in Height for Two Point control
            Dim _deltaHeight As Integer = mTwoPointHeight - MyBase.Height

            ' Adjust contained controls to maintain relative positions
            Dim _locX As Integer
            Dim _locY As Integer

            _locX = Me.StarLabel9.Location.X
            _locY = Math.Max(mMinStarLabel9Location.Y, Me.StarLabel9.Location.Y - _deltaHeight)
            Me.StarLabel9.Location = New Point(_locX, _locY)

            _locX = Me.ReadOnlyLabel.Location.X
            _locY = Math.Max(mMinReadOnlyLabelLocation.Y, Me.ReadOnlyLabel.Location.Y - _deltaHeight)
            Me.ReadOnlyLabel.Location = New Point(_locX, _locY)

            ' Adjust contained controls to match new height (with limits on minimum heights)
            Me.ErrorsAndWarnings.Height = _
                Math.Max(mMinErrorsAndWarningsHeight, Me.ErrorsAndWarnings.Height - _deltaHeight)

            ' Save new height of this control
            If (mMinTwoPointHeight < MyBase.Height) Then
                mTwoPointHeight = MyBase.Height
            End If
        End If

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' Update the UI when System Geometry changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        If Not (mWorldWindow.Running) Then
            UpdateUI()
        End If
    End Sub
    '
    ' Update the UI when Inflow Management data changes
    '
    Private Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        If Not (mWorldWindow.Running) Then
            UpdateUI()
        End If
    End Sub
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
        If (mSystemGeometry IsNot Nothing) Then
            UpdateUI()
        End If
    End Sub

#End Region

End Class
