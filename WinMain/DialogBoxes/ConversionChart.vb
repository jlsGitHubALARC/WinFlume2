
'*************************************************************************************************************
' ConversionChart - tool for converting values between English & Metric units
'*************************************************************************************************************
Imports DataStore

Public Class ConversionChart
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitConversionChart()

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents ButtonPanel As System.Windows.Forms.Panel
    Friend WithEvents OkayButton As DataStore.ctl_Button
    Friend WithEvents ConversionCharts As DataStore.ctl_TabControl
    Friend WithEvents LengthTabPage As System.Windows.Forms.TabPage
    Friend WithEvents AreaTabPage As System.Windows.Forms.TabPage
    Friend WithEvents DepthTabPage As System.Windows.Forms.TabPage
    Friend WithEvents VolumeTabPage As System.Windows.Forms.TabPage
    Friend WithEvents FlowRateTabPage As System.Windows.Forms.TabPage
    Friend WithEvents EnglishLengthLabel As DataStore.ctl_Label
    Friend WithEvents MetricLengthLabel As DataStore.ctl_Label
    Friend WithEvents Feet As WinMain.ExNumericUpDown
    Friend WithEvents Yards As WinMain.ExNumericUpDown
    Friend WithEvents Miles As WinMain.ExNumericUpDown
    Friend WithEvents Meters As WinMain.ExNumericUpDown
    Friend WithEvents Kilometers As WinMain.ExNumericUpDown
    Friend WithEvents MiKmLabel As System.Windows.Forms.Label
    Friend WithEvents FtmLabel As System.Windows.Forms.Label
    Friend WithEvents YdmLabel As System.Windows.Forms.Label
    Friend WithEvents MimLabel As System.Windows.Forms.Label
    Friend WithEvents KmFtLabel As System.Windows.Forms.Label
    Friend WithEvents MftLabel As System.Windows.Forms.Label
    Friend WithEvents KmMiLabel As System.Windows.Forms.Label
    Friend WithEvents KmYdLabel As System.Windows.Forms.Label
    Friend WithEvents MydLabel As System.Windows.Forms.Label
    Friend WithEvents LengthLabel As System.Windows.Forms.Label
    Friend WithEvents Acm2Label As System.Windows.Forms.Label
    Friend WithEvents Ftm2Label As System.Windows.Forms.Label
    Friend WithEvents AreaLabel As System.Windows.Forms.Label
    Friend WithEvents Hectares As WinMain.ExNumericUpDown
    Friend WithEvents SquareMeters As WinMain.ExNumericUpDown
    Friend WithEvents SquareMiles As WinMain.ExNumericUpDown
    Friend WithEvents Acres As WinMain.ExNumericUpDown
    Friend WithEvents SquareFeet As WinMain.ExNumericUpDown
    Friend WithEvents MetricAreaLabel As DataStore.ctl_Label
    Friend WithEvents EnglishAreaLabel As DataStore.ctl_Label
    Friend WithEvents SquareKilometers As WinMain.ExNumericUpDown
    Friend WithEvents LengthHeadingsLabel As System.Windows.Forms.Label
    Friend WithEvents HaAcLabel As System.Windows.Forms.Label
    Friend WithEvents KmFt2Label As System.Windows.Forms.Label
    Friend WithEvents HaMi2Label As System.Windows.Forms.Label
    Friend WithEvents HaFt2Label As System.Windows.Forms.Label
    Friend WithEvents Mft2Label As System.Windows.Forms.Label
    Friend WithEvents MiKm2Label As System.Windows.Forms.Label
    Friend WithEvents Mim2Label As System.Windows.Forms.Label
    Friend WithEvents MiHaLabel As System.Windows.Forms.Label
    Friend WithEvents AcHaLabel As System.Windows.Forms.Label
    Friend WithEvents AcKm2Label As System.Windows.Forms.Label
    Friend WithEvents KmAcLabel As System.Windows.Forms.Label
    Friend WithEvents KmMi2Label As System.Windows.Forms.Label
    Friend WithEvents LengthTitleLabel As DataStore.ctl_Label
    Friend WithEvents AreaTitleLabel As DataStore.ctl_Label
    Friend WithEvents DepthTitleLabel As DataStore.ctl_Label
    Friend WithEvents MetricDepthLabel As DataStore.ctl_Label
    Friend WithEvents EnglishDepthLabel As DataStore.ctl_Label
    Friend WithEvents VolumeTitleLabel As DataStore.ctl_Label
    Friend WithEvents MetricVolumeLabel As DataStore.ctl_Label
    Friend WithEvents EnglishVolumeLabel As DataStore.ctl_Label
    Friend WithEvents FlowRateTitleLabel As DataStore.ctl_Label
    Friend WithEvents MetricFlowRateLabel As DataStore.ctl_Label
    Friend WithEvents EnglishFlowRateLabel As DataStore.ctl_Label
    Friend WithEvents AreaHeadingsLabel As System.Windows.Forms.Label
    Friend WithEvents MdYdLabel As System.Windows.Forms.Label
    Friend WithEvents MdFtLabel As System.Windows.Forms.Label
    Friend WithEvents FtMdLabel As System.Windows.Forms.Label
    Friend WithEvents FtCmLabel As System.Windows.Forms.Label
    Friend WithEvents YdCmLabel As System.Windows.Forms.Label
    Friend WithEvents DepthHeadingsLabel As System.Windows.Forms.Label
    Friend WithEvents MetersDepth As WinMain.ExNumericUpDown
    Friend WithEvents CmFtLabel As System.Windows.Forms.Label
    Friend WithEvents MdInLabel As System.Windows.Forms.Label
    Friend WithEvents CmYdLabel As System.Windows.Forms.Label
    Friend WithEvents CmInLabel As System.Windows.Forms.Label
    Friend WithEvents MmInLabel As System.Windows.Forms.Label
    Friend WithEvents YdMdLabel As System.Windows.Forms.Label
    Friend WithEvents YdMmLabel As System.Windows.Forms.Label
    Friend WithEvents FtMmLabel As System.Windows.Forms.Label
    Friend WithEvents InMmLabel As System.Windows.Forms.Label
    Friend WithEvents DepthsLabel As System.Windows.Forms.Label
    Friend WithEvents Centimeters As WinMain.ExNumericUpDown
    Friend WithEvents Millimeters As WinMain.ExNumericUpDown
    Friend WithEvents YardsDepth As WinMain.ExNumericUpDown
    Friend WithEvents FeetDepth As WinMain.ExNumericUpDown
    Friend WithEvents Inches As WinMain.ExNumericUpDown
    Friend WithEvents InCmLabel As System.Windows.Forms.Label
    Friend WithEvents MlAfLabel As System.Windows.Forms.Label
    Friend WithEvents MlGalLabel As System.Windows.Forms.Label
    Friend WithEvents GalLiLabel As System.Windows.Forms.Label
    Friend WithEvents AfLiLabel As System.Windows.Forms.Label
    Friend WithEvents VolumeHeadingsLabel As System.Windows.Forms.Label
    Friend WithEvents LiGalLabel As System.Windows.Forms.Label
    Friend WithEvents MlFtLabel As System.Windows.Forms.Label
    Friend WithEvents LiFtLabel As System.Windows.Forms.Label
    Friend WithEvents M3FtLabel As System.Windows.Forms.Label
    Friend WithEvents AfMlLabel As System.Windows.Forms.Label
    Friend WithEvents AfM3Label As System.Windows.Forms.Label
    Friend WithEvents GalM3Label As System.Windows.Forms.Label
    Friend WithEvents VolumesLabel As System.Windows.Forms.Label
    Friend WithEvents Gallons As WinMain.ExNumericUpDown
    Friend WithEvents CubicFeet As WinMain.ExNumericUpDown
    Friend WithEvents MegaLiters As WinMain.ExNumericUpDown
    Friend WithEvents Liters As WinMain.ExNumericUpDown
    Friend WithEvents CubicMeters As WinMain.ExNumericUpDown
    Friend WithEvents AcreFeet As WinMain.ExNumericUpDown
    Friend WithEvents FtM3Label As System.Windows.Forms.Label
    Friend WithEvents FtLiLabel As System.Windows.Forms.Label
    Friend WithEvents M3GalLabel As System.Windows.Forms.Label
    Friend WithEvents CfsLpmLabel As System.Windows.Forms.Label
    Friend WithEvents GpmLpmLabel As System.Windows.Forms.Label
    Friend WithEvents FlowRateHeadingsLabel As System.Windows.Forms.Label
    Friend WithEvents CMS As WinMain.ExNumericUpDown
    Friend WithEvents GpmLpsLabel As System.Windows.Forms.Label
    Friend WithEvents CfsLpsLabel As System.Windows.Forms.Label
    Friend WithEvents FlowRatesLabel As System.Windows.Forms.Label
    Friend WithEvents LPM As WinMain.ExNumericUpDown
    Friend WithEvents LPS As WinMain.ExNumericUpDown
    Friend WithEvents GPM As WinMain.ExNumericUpDown
    Friend WithEvents CFS As WinMain.ExNumericUpDown
    Friend WithEvents GpmCmsLabel As System.Windows.Forms.Label
    Friend WithEvents CfsCmsLabel As System.Windows.Forms.Label
    Friend WithEvents LpsGpmLabel As System.Windows.Forms.Label
    Friend WithEvents CmsGpmLabel As System.Windows.Forms.Label
    Friend WithEvents LpmGpmLabel As System.Windows.Forms.Label
    Friend WithEvents CmsCfsLabel As System.Windows.Forms.Label
    Friend WithEvents LpmCfsLabel As System.Windows.Forms.Label
    Friend WithEvents LpsCfsLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        Me.OkayButton = New DataStore.ctl_Button()
        Me.ConversionCharts = New DataStore.ctl_TabControl()
        Me.LengthTabPage = New System.Windows.Forms.TabPage()
        Me.LengthTitleLabel = New DataStore.ctl_Label()
        Me.LengthHeadingsLabel = New System.Windows.Forms.Label()
        Me.KmYdLabel = New System.Windows.Forms.Label()
        Me.MydLabel = New System.Windows.Forms.Label()
        Me.KmMiLabel = New System.Windows.Forms.Label()
        Me.KmFtLabel = New System.Windows.Forms.Label()
        Me.MftLabel = New System.Windows.Forms.Label()
        Me.MiKmLabel = New System.Windows.Forms.Label()
        Me.MimLabel = New System.Windows.Forms.Label()
        Me.YdmLabel = New System.Windows.Forms.Label()
        Me.FtmLabel = New System.Windows.Forms.Label()
        Me.LengthLabel = New System.Windows.Forms.Label()
        Me.Kilometers = New WinMain.ExNumericUpDown()
        Me.Meters = New WinMain.ExNumericUpDown()
        Me.Miles = New WinMain.ExNumericUpDown()
        Me.Yards = New WinMain.ExNumericUpDown()
        Me.Feet = New WinMain.ExNumericUpDown()
        Me.MetricLengthLabel = New DataStore.ctl_Label()
        Me.EnglishLengthLabel = New DataStore.ctl_Label()
        Me.AreaTabPage = New System.Windows.Forms.TabPage()
        Me.AreaTitleLabel = New DataStore.ctl_Label()
        Me.KmMi2Label = New System.Windows.Forms.Label()
        Me.KmAcLabel = New System.Windows.Forms.Label()
        Me.AcKm2Label = New System.Windows.Forms.Label()
        Me.AcHaLabel = New System.Windows.Forms.Label()
        Me.MiHaLabel = New System.Windows.Forms.Label()
        Me.AreaHeadingsLabel = New System.Windows.Forms.Label()
        Me.HaAcLabel = New System.Windows.Forms.Label()
        Me.KmFt2Label = New System.Windows.Forms.Label()
        Me.HaMi2Label = New System.Windows.Forms.Label()
        Me.HaFt2Label = New System.Windows.Forms.Label()
        Me.Mft2Label = New System.Windows.Forms.Label()
        Me.MiKm2Label = New System.Windows.Forms.Label()
        Me.Mim2Label = New System.Windows.Forms.Label()
        Me.Acm2Label = New System.Windows.Forms.Label()
        Me.Ftm2Label = New System.Windows.Forms.Label()
        Me.AreaLabel = New System.Windows.Forms.Label()
        Me.MetricAreaLabel = New DataStore.ctl_Label()
        Me.EnglishAreaLabel = New DataStore.ctl_Label()
        Me.SquareKilometers = New WinMain.ExNumericUpDown()
        Me.Hectares = New WinMain.ExNumericUpDown()
        Me.SquareMeters = New WinMain.ExNumericUpDown()
        Me.SquareMiles = New WinMain.ExNumericUpDown()
        Me.Acres = New WinMain.ExNumericUpDown()
        Me.SquareFeet = New WinMain.ExNumericUpDown()
        Me.DepthTabPage = New System.Windows.Forms.TabPage()
        Me.InCmLabel = New System.Windows.Forms.Label()
        Me.MdYdLabel = New System.Windows.Forms.Label()
        Me.MdFtLabel = New System.Windows.Forms.Label()
        Me.FtMdLabel = New System.Windows.Forms.Label()
        Me.FtCmLabel = New System.Windows.Forms.Label()
        Me.YdCmLabel = New System.Windows.Forms.Label()
        Me.DepthHeadingsLabel = New System.Windows.Forms.Label()
        Me.CmFtLabel = New System.Windows.Forms.Label()
        Me.MdInLabel = New System.Windows.Forms.Label()
        Me.CmYdLabel = New System.Windows.Forms.Label()
        Me.CmInLabel = New System.Windows.Forms.Label()
        Me.MmInLabel = New System.Windows.Forms.Label()
        Me.YdMdLabel = New System.Windows.Forms.Label()
        Me.YdMmLabel = New System.Windows.Forms.Label()
        Me.FtMmLabel = New System.Windows.Forms.Label()
        Me.InMmLabel = New System.Windows.Forms.Label()
        Me.DepthsLabel = New System.Windows.Forms.Label()
        Me.DepthTitleLabel = New DataStore.ctl_Label()
        Me.MetricDepthLabel = New DataStore.ctl_Label()
        Me.EnglishDepthLabel = New DataStore.ctl_Label()
        Me.MetersDepth = New WinMain.ExNumericUpDown()
        Me.Centimeters = New WinMain.ExNumericUpDown()
        Me.Millimeters = New WinMain.ExNumericUpDown()
        Me.YardsDepth = New WinMain.ExNumericUpDown()
        Me.FeetDepth = New WinMain.ExNumericUpDown()
        Me.Inches = New WinMain.ExNumericUpDown()
        Me.VolumeTabPage = New System.Windows.Forms.TabPage()
        Me.M3GalLabel = New System.Windows.Forms.Label()
        Me.FtLiLabel = New System.Windows.Forms.Label()
        Me.MlAfLabel = New System.Windows.Forms.Label()
        Me.MlGalLabel = New System.Windows.Forms.Label()
        Me.GalLiLabel = New System.Windows.Forms.Label()
        Me.AfLiLabel = New System.Windows.Forms.Label()
        Me.VolumeHeadingsLabel = New System.Windows.Forms.Label()
        Me.LiGalLabel = New System.Windows.Forms.Label()
        Me.MlFtLabel = New System.Windows.Forms.Label()
        Me.LiFtLabel = New System.Windows.Forms.Label()
        Me.M3FtLabel = New System.Windows.Forms.Label()
        Me.AfMlLabel = New System.Windows.Forms.Label()
        Me.AfM3Label = New System.Windows.Forms.Label()
        Me.GalM3Label = New System.Windows.Forms.Label()
        Me.FtM3Label = New System.Windows.Forms.Label()
        Me.VolumesLabel = New System.Windows.Forms.Label()
        Me.VolumeTitleLabel = New DataStore.ctl_Label()
        Me.MetricVolumeLabel = New DataStore.ctl_Label()
        Me.EnglishVolumeLabel = New DataStore.ctl_Label()
        Me.MegaLiters = New WinMain.ExNumericUpDown()
        Me.Liters = New WinMain.ExNumericUpDown()
        Me.CubicMeters = New WinMain.ExNumericUpDown()
        Me.AcreFeet = New WinMain.ExNumericUpDown()
        Me.Gallons = New WinMain.ExNumericUpDown()
        Me.CubicFeet = New WinMain.ExNumericUpDown()
        Me.FlowRateTabPage = New System.Windows.Forms.TabPage()
        Me.GpmCmsLabel = New System.Windows.Forms.Label()
        Me.CfsCmsLabel = New System.Windows.Forms.Label()
        Me.LpsGpmLabel = New System.Windows.Forms.Label()
        Me.CfsLpmLabel = New System.Windows.Forms.Label()
        Me.CmsGpmLabel = New System.Windows.Forms.Label()
        Me.GpmLpmLabel = New System.Windows.Forms.Label()
        Me.FlowRateHeadingsLabel = New System.Windows.Forms.Label()
        Me.LpmGpmLabel = New System.Windows.Forms.Label()
        Me.CmsCfsLabel = New System.Windows.Forms.Label()
        Me.LpmCfsLabel = New System.Windows.Forms.Label()
        Me.LpsCfsLabel = New System.Windows.Forms.Label()
        Me.GpmLpsLabel = New System.Windows.Forms.Label()
        Me.CfsLpsLabel = New System.Windows.Forms.Label()
        Me.FlowRatesLabel = New System.Windows.Forms.Label()
        Me.FlowRateTitleLabel = New DataStore.ctl_Label()
        Me.MetricFlowRateLabel = New DataStore.ctl_Label()
        Me.EnglishFlowRateLabel = New DataStore.ctl_Label()
        Me.CMS = New WinMain.ExNumericUpDown()
        Me.LPM = New WinMain.ExNumericUpDown()
        Me.LPS = New WinMain.ExNumericUpDown()
        Me.GPM = New WinMain.ExNumericUpDown()
        Me.CFS = New WinMain.ExNumericUpDown()
        Me.ButtonPanel.SuspendLayout()
        Me.ConversionCharts.SuspendLayout()
        Me.LengthTabPage.SuspendLayout()
        CType(Me.Kilometers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Meters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Miles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Yards, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Feet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AreaTabPage.SuspendLayout()
        CType(Me.SquareKilometers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Hectares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SquareMeters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SquareMiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Acres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SquareFeet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DepthTabPage.SuspendLayout()
        CType(Me.MetersDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Centimeters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Millimeters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.YardsDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FeetDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Inches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VolumeTabPage.SuspendLayout()
        CType(Me.MegaLiters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Liters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CubicMeters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AcreFeet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gallons, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CubicFeet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowRateTabPage.SuspendLayout()
        CType(Me.CMS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LPS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CFS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonPanel
        '
        Me.ButtonPanel.Controls.Add(Me.OkayButton)
        Me.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonPanel.Location = New System.Drawing.Point(0, 255)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(650, 40)
        Me.ButtonPanel.TabIndex = 1
        '
        'OkayButton
        '
        Me.OkayButton.AccessibleDescription = "Closes Conversion Chart"
        Me.OkayButton.AccessibleName = "OK Button"
        Me.OkayButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OkayButton.Location = New System.Drawing.Point(566, 8)
        Me.OkayButton.Name = "OkayButton"
        Me.OkayButton.Size = New System.Drawing.Size(72, 24)
        Me.OkayButton.TabIndex = 0
        Me.OkayButton.Text = "&Close"
        '
        'ConversionCharts
        '
        Me.ConversionCharts.AccessibleDescription = ""
        Me.ConversionCharts.AccessibleName = ""
        Me.ConversionCharts.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.ConversionCharts.Controls.Add(Me.LengthTabPage)
        Me.ConversionCharts.Controls.Add(Me.AreaTabPage)
        Me.ConversionCharts.Controls.Add(Me.DepthTabPage)
        Me.ConversionCharts.Controls.Add(Me.VolumeTabPage)
        Me.ConversionCharts.Controls.Add(Me.FlowRateTabPage)
        Me.ConversionCharts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConversionCharts.Location = New System.Drawing.Point(0, 0)
        Me.ConversionCharts.Name = "ConversionCharts"
        Me.ConversionCharts.SelectedIndex = 0
        Me.ConversionCharts.Size = New System.Drawing.Size(650, 255)
        Me.ConversionCharts.TabIndex = 0
        '
        'LengthTabPage
        '
        Me.LengthTabPage.AccessibleDescription = "Shows relationships between English & Metric lengths."
        Me.LengthTabPage.AccessibleName = "Length Conversion Chart"
        Me.LengthTabPage.Controls.Add(Me.LengthTitleLabel)
        Me.LengthTabPage.Controls.Add(Me.LengthHeadingsLabel)
        Me.LengthTabPage.Controls.Add(Me.KmYdLabel)
        Me.LengthTabPage.Controls.Add(Me.MydLabel)
        Me.LengthTabPage.Controls.Add(Me.KmMiLabel)
        Me.LengthTabPage.Controls.Add(Me.KmFtLabel)
        Me.LengthTabPage.Controls.Add(Me.MftLabel)
        Me.LengthTabPage.Controls.Add(Me.MiKmLabel)
        Me.LengthTabPage.Controls.Add(Me.MimLabel)
        Me.LengthTabPage.Controls.Add(Me.YdmLabel)
        Me.LengthTabPage.Controls.Add(Me.FtmLabel)
        Me.LengthTabPage.Controls.Add(Me.LengthLabel)
        Me.LengthTabPage.Controls.Add(Me.Kilometers)
        Me.LengthTabPage.Controls.Add(Me.Meters)
        Me.LengthTabPage.Controls.Add(Me.Miles)
        Me.LengthTabPage.Controls.Add(Me.Yards)
        Me.LengthTabPage.Controls.Add(Me.Feet)
        Me.LengthTabPage.Controls.Add(Me.MetricLengthLabel)
        Me.LengthTabPage.Controls.Add(Me.EnglishLengthLabel)
        Me.LengthTabPage.Location = New System.Drawing.Point(4, 4)
        Me.LengthTabPage.Name = "LengthTabPage"
        Me.LengthTabPage.Size = New System.Drawing.Size(642, 226)
        Me.LengthTabPage.TabIndex = 0
        Me.LengthTabPage.Text = "Length"
        '
        'LengthTitleLabel
        '
        Me.LengthTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LengthTitleLabel.Location = New System.Drawing.Point(264, 8)
        Me.LengthTitleLabel.Name = "LengthTitleLabel"
        Me.LengthTitleLabel.Size = New System.Drawing.Size(112, 23)
        Me.LengthTitleLabel.TabIndex = 18
        Me.LengthTitleLabel.Text = "LENGTH"
        Me.LengthTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LengthHeadingsLabel
        '
        Me.LengthHeadingsLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LengthHeadingsLabel.Location = New System.Drawing.Point(24, 56)
        Me.LengthHeadingsLabel.Name = "LengthHeadingsLabel"
        Me.LengthHeadingsLabel.Size = New System.Drawing.Size(504, 23)
        Me.LengthHeadingsLabel.TabIndex = 2
        Me.LengthHeadingsLabel.Text = "1 ft =        1 yd =       1 mi =              1 m =        1 km ="
        Me.LengthHeadingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KmYdLabel
        '
        Me.KmYdLabel.Location = New System.Drawing.Point(448, 104)
        Me.KmYdLabel.Name = "KmYdLabel"
        Me.KmYdLabel.Size = New System.Drawing.Size(80, 23)
        Me.KmYdLabel.TabIndex = 10
        Me.KmYdLabel.Text = "xx.xx yd"
        Me.KmYdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MydLabel
        '
        Me.MydLabel.Location = New System.Drawing.Point(352, 104)
        Me.MydLabel.Name = "MydLabel"
        Me.MydLabel.Size = New System.Drawing.Size(88, 23)
        Me.MydLabel.TabIndex = 8
        Me.MydLabel.Text = "xx.xx yd"
        Me.MydLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KmMiLabel
        '
        Me.KmMiLabel.Location = New System.Drawing.Point(448, 128)
        Me.KmMiLabel.Name = "KmMiLabel"
        Me.KmMiLabel.Size = New System.Drawing.Size(80, 23)
        Me.KmMiLabel.TabIndex = 11
        Me.KmMiLabel.Text = "xx.xx mi"
        Me.KmMiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KmFtLabel
        '
        Me.KmFtLabel.Location = New System.Drawing.Point(448, 80)
        Me.KmFtLabel.Name = "KmFtLabel"
        Me.KmFtLabel.Size = New System.Drawing.Size(80, 23)
        Me.KmFtLabel.TabIndex = 9
        Me.KmFtLabel.Text = "xx.xx ft"
        Me.KmFtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MftLabel
        '
        Me.MftLabel.Location = New System.Drawing.Point(352, 80)
        Me.MftLabel.Name = "MftLabel"
        Me.MftLabel.Size = New System.Drawing.Size(88, 23)
        Me.MftLabel.TabIndex = 7
        Me.MftLabel.Text = "xx.xx ft"
        Me.MftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MiKmLabel
        '
        Me.MiKmLabel.Location = New System.Drawing.Point(216, 104)
        Me.MiKmLabel.Name = "MiKmLabel"
        Me.MiKmLabel.Size = New System.Drawing.Size(88, 23)
        Me.MiKmLabel.TabIndex = 6
        Me.MiKmLabel.Text = "xx.xx km"
        Me.MiKmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MimLabel
        '
        Me.MimLabel.Location = New System.Drawing.Point(216, 80)
        Me.MimLabel.Name = "MimLabel"
        Me.MimLabel.Size = New System.Drawing.Size(88, 23)
        Me.MimLabel.TabIndex = 5
        Me.MimLabel.Text = "xx.xx m"
        Me.MimLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'YdmLabel
        '
        Me.YdmLabel.Location = New System.Drawing.Point(120, 80)
        Me.YdmLabel.Name = "YdmLabel"
        Me.YdmLabel.Size = New System.Drawing.Size(88, 23)
        Me.YdmLabel.TabIndex = 4
        Me.YdmLabel.Text = "xx.xx m"
        Me.YdmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FtmLabel
        '
        Me.FtmLabel.Location = New System.Drawing.Point(24, 80)
        Me.FtmLabel.Name = "FtmLabel"
        Me.FtmLabel.Size = New System.Drawing.Size(88, 23)
        Me.FtmLabel.TabIndex = 3
        Me.FtmLabel.Text = "xx.xx m"
        Me.FtmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LengthLabel
        '
        Me.LengthLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LengthLabel.Location = New System.Drawing.Point(48, 168)
        Me.LengthLabel.Name = "LengthLabel"
        Me.LengthLabel.Size = New System.Drawing.Size(488, 23)
        Me.LengthLabel.TabIndex = 12
        Me.LengthLabel.Text = "Feet        Yards         Miles              Meters      Kilometers"
        Me.LengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Kilometers
        '
        Me.Kilometers.DecimalPlaces = 3
        Me.Kilometers.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.Kilometers.Location = New System.Drawing.Point(448, 192)
        Me.Kilometers.Name = "Kilometers"
        Me.Kilometers.Size = New System.Drawing.Size(80, 23)
        Me.Kilometers.TabIndex = 17
        '
        'Meters
        '
        Me.Meters.DecimalPlaces = 2
        Me.Meters.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Meters.Location = New System.Drawing.Point(352, 192)
        Me.Meters.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.Meters.Name = "Meters"
        Me.Meters.Size = New System.Drawing.Size(80, 23)
        Me.Meters.TabIndex = 16
        '
        'Miles
        '
        Me.Miles.DecimalPlaces = 3
        Me.Miles.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.Miles.Location = New System.Drawing.Point(216, 192)
        Me.Miles.Maximum = New Decimal(New Integer() {621372, 0, 0, 262144})
        Me.Miles.Name = "Miles"
        Me.Miles.Size = New System.Drawing.Size(80, 23)
        Me.Miles.TabIndex = 15
        '
        'Yards
        '
        Me.Yards.DecimalPlaces = 2
        Me.Yards.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Yards.Location = New System.Drawing.Point(120, 192)
        Me.Yards.Maximum = New Decimal(New Integer() {109362, 0, 0, 0})
        Me.Yards.Name = "Yards"
        Me.Yards.Size = New System.Drawing.Size(80, 23)
        Me.Yards.TabIndex = 14
        '
        'Feet
        '
        Me.Feet.DecimalPlaces = 2
        Me.Feet.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Feet.Location = New System.Drawing.Point(24, 192)
        Me.Feet.Maximum = New Decimal(New Integer() {328085, 0, 0, 0})
        Me.Feet.Name = "Feet"
        Me.Feet.Size = New System.Drawing.Size(80, 23)
        Me.Feet.TabIndex = 13
        '
        'MetricLengthLabel
        '
        Me.MetricLengthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricLengthLabel.Location = New System.Drawing.Point(448, 24)
        Me.MetricLengthLabel.Name = "MetricLengthLabel"
        Me.MetricLengthLabel.Size = New System.Drawing.Size(80, 23)
        Me.MetricLengthLabel.TabIndex = 1
        Me.MetricLengthLabel.Text = "Metric"
        Me.MetricLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EnglishLengthLabel
        '
        Me.EnglishLengthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishLengthLabel.Location = New System.Drawing.Point(120, 24)
        Me.EnglishLengthLabel.Name = "EnglishLengthLabel"
        Me.EnglishLengthLabel.Size = New System.Drawing.Size(80, 23)
        Me.EnglishLengthLabel.TabIndex = 0
        Me.EnglishLengthLabel.Text = "English"
        Me.EnglishLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AreaTabPage
        '
        Me.AreaTabPage.AccessibleDescription = "Shows relationships between English & Metric areas."
        Me.AreaTabPage.AccessibleName = "Area Conversion Chart"
        Me.AreaTabPage.Controls.Add(Me.AreaTitleLabel)
        Me.AreaTabPage.Controls.Add(Me.KmMi2Label)
        Me.AreaTabPage.Controls.Add(Me.KmAcLabel)
        Me.AreaTabPage.Controls.Add(Me.AcKm2Label)
        Me.AreaTabPage.Controls.Add(Me.AcHaLabel)
        Me.AreaTabPage.Controls.Add(Me.MiHaLabel)
        Me.AreaTabPage.Controls.Add(Me.AreaHeadingsLabel)
        Me.AreaTabPage.Controls.Add(Me.HaAcLabel)
        Me.AreaTabPage.Controls.Add(Me.KmFt2Label)
        Me.AreaTabPage.Controls.Add(Me.HaMi2Label)
        Me.AreaTabPage.Controls.Add(Me.HaFt2Label)
        Me.AreaTabPage.Controls.Add(Me.Mft2Label)
        Me.AreaTabPage.Controls.Add(Me.MiKm2Label)
        Me.AreaTabPage.Controls.Add(Me.Mim2Label)
        Me.AreaTabPage.Controls.Add(Me.Acm2Label)
        Me.AreaTabPage.Controls.Add(Me.Ftm2Label)
        Me.AreaTabPage.Controls.Add(Me.AreaLabel)
        Me.AreaTabPage.Controls.Add(Me.MetricAreaLabel)
        Me.AreaTabPage.Controls.Add(Me.EnglishAreaLabel)
        Me.AreaTabPage.Controls.Add(Me.SquareKilometers)
        Me.AreaTabPage.Controls.Add(Me.Hectares)
        Me.AreaTabPage.Controls.Add(Me.SquareMeters)
        Me.AreaTabPage.Controls.Add(Me.SquareMiles)
        Me.AreaTabPage.Controls.Add(Me.Acres)
        Me.AreaTabPage.Controls.Add(Me.SquareFeet)
        Me.AreaTabPage.Location = New System.Drawing.Point(4, 4)
        Me.AreaTabPage.Name = "AreaTabPage"
        Me.AreaTabPage.Size = New System.Drawing.Size(642, 226)
        Me.AreaTabPage.TabIndex = 1
        Me.AreaTabPage.Text = "Area"
        '
        'AreaTitleLabel
        '
        Me.AreaTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AreaTitleLabel.Location = New System.Drawing.Point(264, 8)
        Me.AreaTitleLabel.Name = "AreaTitleLabel"
        Me.AreaTitleLabel.Size = New System.Drawing.Size(112, 23)
        Me.AreaTitleLabel.TabIndex = 24
        Me.AreaTitleLabel.Text = "AREA"
        Me.AreaTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KmMi2Label
        '
        Me.KmMi2Label.Location = New System.Drawing.Point(536, 128)
        Me.KmMi2Label.Name = "KmMi2Label"
        Me.KmMi2Label.Size = New System.Drawing.Size(96, 23)
        Me.KmMi2Label.TabIndex = 16
        Me.KmMi2Label.Text = "xx.xx mi²"
        Me.KmMi2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.KmMi2Label.Visible = False
        '
        'KmAcLabel
        '
        Me.KmAcLabel.Location = New System.Drawing.Point(536, 104)
        Me.KmAcLabel.Name = "KmAcLabel"
        Me.KmAcLabel.Size = New System.Drawing.Size(96, 23)
        Me.KmAcLabel.TabIndex = 15
        Me.KmAcLabel.Text = "xx.xx acre"
        Me.KmAcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.KmAcLabel.Visible = False
        '
        'AcKm2Label
        '
        Me.AcKm2Label.Location = New System.Drawing.Point(120, 128)
        Me.AcKm2Label.Name = "AcKm2Label"
        Me.AcKm2Label.Size = New System.Drawing.Size(88, 23)
        Me.AcKm2Label.TabIndex = 6
        Me.AcKm2Label.Text = "xx.xx km²"
        Me.AcKm2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AcKm2Label.Visible = False
        '
        'AcHaLabel
        '
        Me.AcHaLabel.Location = New System.Drawing.Point(120, 104)
        Me.AcHaLabel.Name = "AcHaLabel"
        Me.AcHaLabel.Size = New System.Drawing.Size(88, 23)
        Me.AcHaLabel.TabIndex = 5
        Me.AcHaLabel.Text = "xx.xx ha"
        Me.AcHaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MiHaLabel
        '
        Me.MiHaLabel.Location = New System.Drawing.Point(216, 104)
        Me.MiHaLabel.Name = "MiHaLabel"
        Me.MiHaLabel.Size = New System.Drawing.Size(112, 23)
        Me.MiHaLabel.TabIndex = 8
        Me.MiHaLabel.Text = "xx.xx ha"
        Me.MiHaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MiHaLabel.Visible = False
        '
        'AreaHeadingsLabel
        '
        Me.AreaHeadingsLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AreaHeadingsLabel.Location = New System.Drawing.Point(24, 56)
        Me.AreaHeadingsLabel.Name = "AreaHeadingsLabel"
        Me.AreaHeadingsLabel.Size = New System.Drawing.Size(600, 23)
        Me.AreaHeadingsLabel.TabIndex = 2
        Me.AreaHeadingsLabel.Text = "1 ft² =      1 acre =                          1 m² =        1 ha =      "
        Me.AreaHeadingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HaAcLabel
        '
        Me.HaAcLabel.Location = New System.Drawing.Point(448, 104)
        Me.HaAcLabel.Name = "HaAcLabel"
        Me.HaAcLabel.Size = New System.Drawing.Size(80, 23)
        Me.HaAcLabel.TabIndex = 12
        Me.HaAcLabel.Text = "xx.xx acre"
        Me.HaAcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KmFt2Label
        '
        Me.KmFt2Label.Location = New System.Drawing.Point(536, 80)
        Me.KmFt2Label.Name = "KmFt2Label"
        Me.KmFt2Label.Size = New System.Drawing.Size(96, 23)
        Me.KmFt2Label.TabIndex = 14
        Me.KmFt2Label.Text = "xx.xx ft²"
        Me.KmFt2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.KmFt2Label.Visible = False
        '
        'HaMi2Label
        '
        Me.HaMi2Label.Location = New System.Drawing.Point(448, 128)
        Me.HaMi2Label.Name = "HaMi2Label"
        Me.HaMi2Label.Size = New System.Drawing.Size(80, 23)
        Me.HaMi2Label.TabIndex = 13
        Me.HaMi2Label.Text = "xx.xx mi²"
        Me.HaMi2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.HaMi2Label.Visible = False
        '
        'HaFt2Label
        '
        Me.HaFt2Label.Location = New System.Drawing.Point(448, 80)
        Me.HaFt2Label.Name = "HaFt2Label"
        Me.HaFt2Label.Size = New System.Drawing.Size(80, 23)
        Me.HaFt2Label.TabIndex = 11
        Me.HaFt2Label.Text = "xx.xx ft²"
        Me.HaFt2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Mft2Label
        '
        Me.Mft2Label.Location = New System.Drawing.Point(352, 80)
        Me.Mft2Label.Name = "Mft2Label"
        Me.Mft2Label.Size = New System.Drawing.Size(88, 23)
        Me.Mft2Label.TabIndex = 10
        Me.Mft2Label.Text = "xx.xx ft²"
        Me.Mft2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MiKm2Label
        '
        Me.MiKm2Label.Location = New System.Drawing.Point(216, 128)
        Me.MiKm2Label.Name = "MiKm2Label"
        Me.MiKm2Label.Size = New System.Drawing.Size(112, 23)
        Me.MiKm2Label.TabIndex = 9
        Me.MiKm2Label.Text = "xx.xx km²"
        Me.MiKm2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MiKm2Label.Visible = False
        '
        'Mim2Label
        '
        Me.Mim2Label.Location = New System.Drawing.Point(216, 80)
        Me.Mim2Label.Name = "Mim2Label"
        Me.Mim2Label.Size = New System.Drawing.Size(112, 23)
        Me.Mim2Label.TabIndex = 7
        Me.Mim2Label.Text = "xx.xx m²"
        Me.Mim2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Mim2Label.Visible = False
        '
        'Acm2Label
        '
        Me.Acm2Label.Location = New System.Drawing.Point(120, 80)
        Me.Acm2Label.Name = "Acm2Label"
        Me.Acm2Label.Size = New System.Drawing.Size(88, 23)
        Me.Acm2Label.TabIndex = 4
        Me.Acm2Label.Text = "xx.xx m²"
        Me.Acm2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Ftm2Label
        '
        Me.Ftm2Label.Location = New System.Drawing.Point(24, 80)
        Me.Ftm2Label.Name = "Ftm2Label"
        Me.Ftm2Label.Size = New System.Drawing.Size(88, 23)
        Me.Ftm2Label.TabIndex = 3
        Me.Ftm2Label.Text = "xx.xx m²"
        Me.Ftm2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AreaLabel
        '
        Me.AreaLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AreaLabel.Location = New System.Drawing.Point(32, 168)
        Me.AreaLabel.Name = "AreaLabel"
        Me.AreaLabel.Size = New System.Drawing.Size(608, 23)
        Me.AreaLabel.TabIndex = 17
        Me.AreaLabel.Text = "Sq. Feet       Acres                         Sq. Meters     Hectares    "
        Me.AreaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MetricAreaLabel
        '
        Me.MetricAreaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricAreaLabel.Location = New System.Drawing.Point(448, 24)
        Me.MetricAreaLabel.Name = "MetricAreaLabel"
        Me.MetricAreaLabel.Size = New System.Drawing.Size(80, 23)
        Me.MetricAreaLabel.TabIndex = 1
        Me.MetricAreaLabel.Text = "Metric"
        Me.MetricAreaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EnglishAreaLabel
        '
        Me.EnglishAreaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishAreaLabel.Location = New System.Drawing.Point(120, 24)
        Me.EnglishAreaLabel.Name = "EnglishAreaLabel"
        Me.EnglishAreaLabel.Size = New System.Drawing.Size(80, 23)
        Me.EnglishAreaLabel.TabIndex = 0
        Me.EnglishAreaLabel.Text = "English"
        Me.EnglishAreaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SquareKilometers
        '
        Me.SquareKilometers.DecimalPlaces = 3
        Me.SquareKilometers.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.SquareKilometers.Location = New System.Drawing.Point(544, 192)
        Me.SquareKilometers.Name = "SquareKilometers"
        Me.SquareKilometers.Size = New System.Drawing.Size(80, 23)
        Me.SquareKilometers.TabIndex = 23
        Me.SquareKilometers.Visible = False
        '
        'Hectares
        '
        Me.Hectares.DecimalPlaces = 3
        Me.Hectares.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.Hectares.Location = New System.Drawing.Point(448, 192)
        Me.Hectares.Name = "Hectares"
        Me.Hectares.Size = New System.Drawing.Size(80, 23)
        Me.Hectares.TabIndex = 22
        '
        'SquareMeters
        '
        Me.SquareMeters.DecimalPlaces = 2
        Me.SquareMeters.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.SquareMeters.Location = New System.Drawing.Point(352, 192)
        Me.SquareMeters.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.SquareMeters.Name = "SquareMeters"
        Me.SquareMeters.Size = New System.Drawing.Size(80, 23)
        Me.SquareMeters.TabIndex = 21
        '
        'SquareMiles
        '
        Me.SquareMiles.DecimalPlaces = 3
        Me.SquareMiles.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.SquareMiles.Location = New System.Drawing.Point(216, 192)
        Me.SquareMiles.Maximum = New Decimal(New Integer() {621372, 0, 0, 262144})
        Me.SquareMiles.Name = "SquareMiles"
        Me.SquareMiles.Size = New System.Drawing.Size(80, 23)
        Me.SquareMiles.TabIndex = 20
        Me.SquareMiles.Visible = False
        '
        'Acres
        '
        Me.Acres.DecimalPlaces = 2
        Me.Acres.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Acres.Location = New System.Drawing.Point(120, 192)
        Me.Acres.Maximum = New Decimal(New Integer() {109362, 0, 0, 0})
        Me.Acres.Name = "Acres"
        Me.Acres.Size = New System.Drawing.Size(80, 23)
        Me.Acres.TabIndex = 19
        '
        'SquareFeet
        '
        Me.SquareFeet.DecimalPlaces = 2
        Me.SquareFeet.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.SquareFeet.Location = New System.Drawing.Point(16, 192)
        Me.SquareFeet.Maximum = New Decimal(New Integer() {328085, 0, 0, 0})
        Me.SquareFeet.Name = "SquareFeet"
        Me.SquareFeet.Size = New System.Drawing.Size(88, 23)
        Me.SquareFeet.TabIndex = 18
        '
        'DepthTabPage
        '
        Me.DepthTabPage.AccessibleDescription = "Shows relationships between English & Metric depths."
        Me.DepthTabPage.AccessibleName = "Depth Conversion Chart"
        Me.DepthTabPage.Controls.Add(Me.InCmLabel)
        Me.DepthTabPage.Controls.Add(Me.MdYdLabel)
        Me.DepthTabPage.Controls.Add(Me.MdFtLabel)
        Me.DepthTabPage.Controls.Add(Me.FtMdLabel)
        Me.DepthTabPage.Controls.Add(Me.FtCmLabel)
        Me.DepthTabPage.Controls.Add(Me.YdCmLabel)
        Me.DepthTabPage.Controls.Add(Me.DepthHeadingsLabel)
        Me.DepthTabPage.Controls.Add(Me.CmFtLabel)
        Me.DepthTabPage.Controls.Add(Me.MdInLabel)
        Me.DepthTabPage.Controls.Add(Me.CmYdLabel)
        Me.DepthTabPage.Controls.Add(Me.CmInLabel)
        Me.DepthTabPage.Controls.Add(Me.MmInLabel)
        Me.DepthTabPage.Controls.Add(Me.YdMdLabel)
        Me.DepthTabPage.Controls.Add(Me.YdMmLabel)
        Me.DepthTabPage.Controls.Add(Me.FtMmLabel)
        Me.DepthTabPage.Controls.Add(Me.InMmLabel)
        Me.DepthTabPage.Controls.Add(Me.DepthsLabel)
        Me.DepthTabPage.Controls.Add(Me.DepthTitleLabel)
        Me.DepthTabPage.Controls.Add(Me.MetricDepthLabel)
        Me.DepthTabPage.Controls.Add(Me.EnglishDepthLabel)
        Me.DepthTabPage.Controls.Add(Me.MetersDepth)
        Me.DepthTabPage.Controls.Add(Me.Centimeters)
        Me.DepthTabPage.Controls.Add(Me.Millimeters)
        Me.DepthTabPage.Controls.Add(Me.YardsDepth)
        Me.DepthTabPage.Controls.Add(Me.FeetDepth)
        Me.DepthTabPage.Controls.Add(Me.Inches)
        Me.DepthTabPage.Location = New System.Drawing.Point(4, 4)
        Me.DepthTabPage.Name = "DepthTabPage"
        Me.DepthTabPage.Size = New System.Drawing.Size(642, 229)
        Me.DepthTabPage.TabIndex = 2
        Me.DepthTabPage.Text = "Depth"
        '
        'InCmLabel
        '
        Me.InCmLabel.Location = New System.Drawing.Point(24, 104)
        Me.InCmLabel.Name = "InCmLabel"
        Me.InCmLabel.Size = New System.Drawing.Size(80, 23)
        Me.InCmLabel.TabIndex = 5
        Me.InCmLabel.Text = "xx.xx cm"
        Me.InCmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MdYdLabel
        '
        Me.MdYdLabel.Location = New System.Drawing.Point(544, 128)
        Me.MdYdLabel.Name = "MdYdLabel"
        Me.MdYdLabel.Size = New System.Drawing.Size(80, 23)
        Me.MdYdLabel.TabIndex = 18
        Me.MdYdLabel.Text = "xx.xx yd"
        Me.MdYdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MdFtLabel
        '
        Me.MdFtLabel.Location = New System.Drawing.Point(544, 104)
        Me.MdFtLabel.Name = "MdFtLabel"
        Me.MdFtLabel.Size = New System.Drawing.Size(96, 23)
        Me.MdFtLabel.TabIndex = 17
        Me.MdFtLabel.Text = "xx.xx ft"
        Me.MdFtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FtMdLabel
        '
        Me.FtMdLabel.Location = New System.Drawing.Point(120, 128)
        Me.FtMdLabel.Name = "FtMdLabel"
        Me.FtMdLabel.Size = New System.Drawing.Size(80, 23)
        Me.FtMdLabel.TabIndex = 8
        Me.FtMdLabel.Text = "xx.xx m"
        Me.FtMdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FtCmLabel
        '
        Me.FtCmLabel.Location = New System.Drawing.Point(120, 104)
        Me.FtCmLabel.Name = "FtCmLabel"
        Me.FtCmLabel.Size = New System.Drawing.Size(80, 23)
        Me.FtCmLabel.TabIndex = 7
        Me.FtCmLabel.Text = "xx.xx cm"
        Me.FtCmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'YdCmLabel
        '
        Me.YdCmLabel.Location = New System.Drawing.Point(216, 104)
        Me.YdCmLabel.Name = "YdCmLabel"
        Me.YdCmLabel.Size = New System.Drawing.Size(80, 23)
        Me.YdCmLabel.TabIndex = 10
        Me.YdCmLabel.Text = "xx.xx cm"
        Me.YdCmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepthHeadingsLabel
        '
        Me.DepthHeadingsLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthHeadingsLabel.Location = New System.Drawing.Point(24, 56)
        Me.DepthHeadingsLabel.Name = "DepthHeadingsLabel"
        Me.DepthHeadingsLabel.Size = New System.Drawing.Size(568, 23)
        Me.DepthHeadingsLabel.TabIndex = 3
        Me.DepthHeadingsLabel.Text = "1 in =        1 ft =       1 yd =              1 mm =       1 cm =        1 m ="
        Me.DepthHeadingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmFtLabel
        '
        Me.CmFtLabel.Location = New System.Drawing.Point(448, 104)
        Me.CmFtLabel.Name = "CmFtLabel"
        Me.CmFtLabel.Size = New System.Drawing.Size(80, 23)
        Me.CmFtLabel.TabIndex = 14
        Me.CmFtLabel.Text = "xx.xx ft"
        Me.CmFtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MdInLabel
        '
        Me.MdInLabel.Location = New System.Drawing.Point(544, 80)
        Me.MdInLabel.Name = "MdInLabel"
        Me.MdInLabel.Size = New System.Drawing.Size(96, 23)
        Me.MdInLabel.TabIndex = 16
        Me.MdInLabel.Text = "xx.xx in"
        Me.MdInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmYdLabel
        '
        Me.CmYdLabel.Location = New System.Drawing.Point(448, 128)
        Me.CmYdLabel.Name = "CmYdLabel"
        Me.CmYdLabel.Size = New System.Drawing.Size(80, 23)
        Me.CmYdLabel.TabIndex = 15
        Me.CmYdLabel.Text = "xx.xx yd"
        Me.CmYdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmInLabel
        '
        Me.CmInLabel.Location = New System.Drawing.Point(448, 80)
        Me.CmInLabel.Name = "CmInLabel"
        Me.CmInLabel.Size = New System.Drawing.Size(80, 23)
        Me.CmInLabel.TabIndex = 13
        Me.CmInLabel.Text = "xx.xx in"
        Me.CmInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MmInLabel
        '
        Me.MmInLabel.Location = New System.Drawing.Point(352, 80)
        Me.MmInLabel.Name = "MmInLabel"
        Me.MmInLabel.Size = New System.Drawing.Size(80, 23)
        Me.MmInLabel.TabIndex = 12
        Me.MmInLabel.Text = "xx.xx in"
        Me.MmInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'YdMdLabel
        '
        Me.YdMdLabel.Location = New System.Drawing.Point(216, 128)
        Me.YdMdLabel.Name = "YdMdLabel"
        Me.YdMdLabel.Size = New System.Drawing.Size(80, 23)
        Me.YdMdLabel.TabIndex = 11
        Me.YdMdLabel.Text = "xx.xx m"
        Me.YdMdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'YdMmLabel
        '
        Me.YdMmLabel.Location = New System.Drawing.Point(216, 80)
        Me.YdMmLabel.Name = "YdMmLabel"
        Me.YdMmLabel.Size = New System.Drawing.Size(112, 23)
        Me.YdMmLabel.TabIndex = 9
        Me.YdMmLabel.Text = "xx.xx mm"
        Me.YdMmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FtMmLabel
        '
        Me.FtMmLabel.Location = New System.Drawing.Point(120, 80)
        Me.FtMmLabel.Name = "FtMmLabel"
        Me.FtMmLabel.Size = New System.Drawing.Size(80, 23)
        Me.FtMmLabel.TabIndex = 6
        Me.FtMmLabel.Text = "xx.xx mm"
        Me.FtMmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InMmLabel
        '
        Me.InMmLabel.Location = New System.Drawing.Point(24, 80)
        Me.InMmLabel.Name = "InMmLabel"
        Me.InMmLabel.Size = New System.Drawing.Size(80, 23)
        Me.InMmLabel.TabIndex = 4
        Me.InMmLabel.Text = "xx.xx mm"
        Me.InMmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepthsLabel
        '
        Me.DepthsLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthsLabel.Location = New System.Drawing.Point(40, 168)
        Me.DepthsLabel.Name = "DepthsLabel"
        Me.DepthsLabel.Size = New System.Drawing.Size(584, 23)
        Me.DepthsLabel.TabIndex = 19
        Me.DepthsLabel.Text = "Inches        Feet         Yards            Millimeters   Centimeters     Meters"
        Me.DepthsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepthTitleLabel
        '
        Me.DepthTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthTitleLabel.Location = New System.Drawing.Point(264, 8)
        Me.DepthTitleLabel.Name = "DepthTitleLabel"
        Me.DepthTitleLabel.Size = New System.Drawing.Size(112, 23)
        Me.DepthTitleLabel.TabIndex = 0
        Me.DepthTitleLabel.Text = "DEPTH"
        Me.DepthTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MetricDepthLabel
        '
        Me.MetricDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricDepthLabel.Location = New System.Drawing.Point(448, 24)
        Me.MetricDepthLabel.Name = "MetricDepthLabel"
        Me.MetricDepthLabel.Size = New System.Drawing.Size(80, 23)
        Me.MetricDepthLabel.TabIndex = 2
        Me.MetricDepthLabel.Text = "Metric"
        Me.MetricDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EnglishDepthLabel
        '
        Me.EnglishDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishDepthLabel.Location = New System.Drawing.Point(120, 24)
        Me.EnglishDepthLabel.Name = "EnglishDepthLabel"
        Me.EnglishDepthLabel.Size = New System.Drawing.Size(80, 23)
        Me.EnglishDepthLabel.TabIndex = 1
        Me.EnglishDepthLabel.Text = "English"
        Me.EnglishDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MetersDepth
        '
        Me.MetersDepth.DecimalPlaces = 3
        Me.MetersDepth.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.MetersDepth.Location = New System.Drawing.Point(544, 192)
        Me.MetersDepth.Name = "MetersDepth"
        Me.MetersDepth.Size = New System.Drawing.Size(80, 23)
        Me.MetersDepth.TabIndex = 25
        '
        'Centimeters
        '
        Me.Centimeters.DecimalPlaces = 2
        Me.Centimeters.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Centimeters.Location = New System.Drawing.Point(448, 192)
        Me.Centimeters.Name = "Centimeters"
        Me.Centimeters.Size = New System.Drawing.Size(80, 23)
        Me.Centimeters.TabIndex = 24
        '
        'Millimeters
        '
        Me.Millimeters.DecimalPlaces = 2
        Me.Millimeters.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Millimeters.Location = New System.Drawing.Point(352, 192)
        Me.Millimeters.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.Millimeters.Name = "Millimeters"
        Me.Millimeters.Size = New System.Drawing.Size(80, 23)
        Me.Millimeters.TabIndex = 23
        '
        'YardsDepth
        '
        Me.YardsDepth.DecimalPlaces = 3
        Me.YardsDepth.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.YardsDepth.Location = New System.Drawing.Point(216, 192)
        Me.YardsDepth.Maximum = New Decimal(New Integer() {621372, 0, 0, 262144})
        Me.YardsDepth.Name = "YardsDepth"
        Me.YardsDepth.Size = New System.Drawing.Size(80, 23)
        Me.YardsDepth.TabIndex = 22
        '
        'FeetDepth
        '
        Me.FeetDepth.DecimalPlaces = 2
        Me.FeetDepth.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.FeetDepth.Location = New System.Drawing.Point(120, 192)
        Me.FeetDepth.Maximum = New Decimal(New Integer() {109362, 0, 0, 0})
        Me.FeetDepth.Name = "FeetDepth"
        Me.FeetDepth.Size = New System.Drawing.Size(80, 23)
        Me.FeetDepth.TabIndex = 21
        '
        'Inches
        '
        Me.Inches.DecimalPlaces = 2
        Me.Inches.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Inches.Location = New System.Drawing.Point(24, 192)
        Me.Inches.Maximum = New Decimal(New Integer() {328085, 0, 0, 0})
        Me.Inches.Name = "Inches"
        Me.Inches.Size = New System.Drawing.Size(80, 23)
        Me.Inches.TabIndex = 20
        '
        'VolumeTabPage
        '
        Me.VolumeTabPage.AccessibleDescription = "Shows relationships between English & Metric volumes."
        Me.VolumeTabPage.AccessibleName = "Volume Conversion Chart"
        Me.VolumeTabPage.Controls.Add(Me.M3GalLabel)
        Me.VolumeTabPage.Controls.Add(Me.FtLiLabel)
        Me.VolumeTabPage.Controls.Add(Me.MlAfLabel)
        Me.VolumeTabPage.Controls.Add(Me.MlGalLabel)
        Me.VolumeTabPage.Controls.Add(Me.GalLiLabel)
        Me.VolumeTabPage.Controls.Add(Me.AfLiLabel)
        Me.VolumeTabPage.Controls.Add(Me.VolumeHeadingsLabel)
        Me.VolumeTabPage.Controls.Add(Me.LiGalLabel)
        Me.VolumeTabPage.Controls.Add(Me.MlFtLabel)
        Me.VolumeTabPage.Controls.Add(Me.LiFtLabel)
        Me.VolumeTabPage.Controls.Add(Me.M3FtLabel)
        Me.VolumeTabPage.Controls.Add(Me.AfMlLabel)
        Me.VolumeTabPage.Controls.Add(Me.AfM3Label)
        Me.VolumeTabPage.Controls.Add(Me.GalM3Label)
        Me.VolumeTabPage.Controls.Add(Me.FtM3Label)
        Me.VolumeTabPage.Controls.Add(Me.VolumesLabel)
        Me.VolumeTabPage.Controls.Add(Me.VolumeTitleLabel)
        Me.VolumeTabPage.Controls.Add(Me.MetricVolumeLabel)
        Me.VolumeTabPage.Controls.Add(Me.EnglishVolumeLabel)
        Me.VolumeTabPage.Controls.Add(Me.MegaLiters)
        Me.VolumeTabPage.Controls.Add(Me.Liters)
        Me.VolumeTabPage.Controls.Add(Me.CubicMeters)
        Me.VolumeTabPage.Controls.Add(Me.AcreFeet)
        Me.VolumeTabPage.Controls.Add(Me.Gallons)
        Me.VolumeTabPage.Controls.Add(Me.CubicFeet)
        Me.VolumeTabPage.Location = New System.Drawing.Point(4, 4)
        Me.VolumeTabPage.Name = "VolumeTabPage"
        Me.VolumeTabPage.Size = New System.Drawing.Size(642, 229)
        Me.VolumeTabPage.TabIndex = 3
        Me.VolumeTabPage.Text = "Volume"
        '
        'M3GalLabel
        '
        Me.M3GalLabel.Location = New System.Drawing.Point(448, 80)
        Me.M3GalLabel.Name = "M3GalLabel"
        Me.M3GalLabel.Size = New System.Drawing.Size(80, 23)
        Me.M3GalLabel.TabIndex = 13
        Me.M3GalLabel.Text = "xx.xx gal"
        Me.M3GalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FtLiLabel
        '
        Me.FtLiLabel.Location = New System.Drawing.Point(120, 80)
        Me.FtLiLabel.Name = "FtLiLabel"
        Me.FtLiLabel.Size = New System.Drawing.Size(80, 23)
        Me.FtLiLabel.TabIndex = 6
        Me.FtLiLabel.Text = "xx.xx l"
        Me.FtLiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MlAfLabel
        '
        Me.MlAfLabel.Location = New System.Drawing.Point(536, 128)
        Me.MlAfLabel.Name = "MlAfLabel"
        Me.MlAfLabel.Size = New System.Drawing.Size(88, 23)
        Me.MlAfLabel.TabIndex = 17
        Me.MlAfLabel.Text = "xx.xx af"
        Me.MlAfLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MlGalLabel
        '
        Me.MlGalLabel.Location = New System.Drawing.Point(536, 80)
        Me.MlGalLabel.Name = "MlGalLabel"
        Me.MlGalLabel.Size = New System.Drawing.Size(96, 23)
        Me.MlGalLabel.TabIndex = 15
        Me.MlGalLabel.Text = "xx.xx gal"
        Me.MlGalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GalLiLabel
        '
        Me.GalLiLabel.Location = New System.Drawing.Point(24, 80)
        Me.GalLiLabel.Name = "GalLiLabel"
        Me.GalLiLabel.Size = New System.Drawing.Size(80, 23)
        Me.GalLiLabel.TabIndex = 4
        Me.GalLiLabel.Text = "xx.xx l"
        Me.GalLiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AfLiLabel
        '
        Me.AfLiLabel.Location = New System.Drawing.Point(216, 80)
        Me.AfLiLabel.Name = "AfLiLabel"
        Me.AfLiLabel.Size = New System.Drawing.Size(80, 23)
        Me.AfLiLabel.TabIndex = 8
        Me.AfLiLabel.Text = "xx.xx l"
        Me.AfLiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VolumeHeadingsLabel
        '
        Me.VolumeHeadingsLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolumeHeadingsLabel.Location = New System.Drawing.Point(24, 56)
        Me.VolumeHeadingsLabel.Name = "VolumeHeadingsLabel"
        Me.VolumeHeadingsLabel.Size = New System.Drawing.Size(592, 23)
        Me.VolumeHeadingsLabel.TabIndex = 3
        Me.VolumeHeadingsLabel.Text = "1 gal =      1 ft³ =       1 acre-foot =      1 liter =     1 m³ =       1 ML ="
        Me.VolumeHeadingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LiGalLabel
        '
        Me.LiGalLabel.Location = New System.Drawing.Point(352, 80)
        Me.LiGalLabel.Name = "LiGalLabel"
        Me.LiGalLabel.Size = New System.Drawing.Size(80, 23)
        Me.LiGalLabel.TabIndex = 11
        Me.LiGalLabel.Text = "xx.xx gal"
        Me.LiGalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MlFtLabel
        '
        Me.MlFtLabel.Location = New System.Drawing.Point(536, 104)
        Me.MlFtLabel.Name = "MlFtLabel"
        Me.MlFtLabel.Size = New System.Drawing.Size(96, 23)
        Me.MlFtLabel.TabIndex = 16
        Me.MlFtLabel.Text = "xx.xx ft³"
        Me.MlFtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LiFtLabel
        '
        Me.LiFtLabel.Location = New System.Drawing.Point(352, 104)
        Me.LiFtLabel.Name = "LiFtLabel"
        Me.LiFtLabel.Size = New System.Drawing.Size(80, 23)
        Me.LiFtLabel.TabIndex = 12
        Me.LiFtLabel.Text = "xx.xx ft³"
        Me.LiFtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'M3FtLabel
        '
        Me.M3FtLabel.Location = New System.Drawing.Point(448, 104)
        Me.M3FtLabel.Name = "M3FtLabel"
        Me.M3FtLabel.Size = New System.Drawing.Size(80, 23)
        Me.M3FtLabel.TabIndex = 14
        Me.M3FtLabel.Text = "xx.xx ft³"
        Me.M3FtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AfMlLabel
        '
        Me.AfMlLabel.Location = New System.Drawing.Point(216, 128)
        Me.AfMlLabel.Name = "AfMlLabel"
        Me.AfMlLabel.Size = New System.Drawing.Size(80, 23)
        Me.AfMlLabel.TabIndex = 10
        Me.AfMlLabel.Text = "xx.xx ML"
        Me.AfMlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AfM3Label
        '
        Me.AfM3Label.Location = New System.Drawing.Point(216, 104)
        Me.AfM3Label.Name = "AfM3Label"
        Me.AfM3Label.Size = New System.Drawing.Size(112, 23)
        Me.AfM3Label.TabIndex = 9
        Me.AfM3Label.Text = "xx.xx m³"
        Me.AfM3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GalM3Label
        '
        Me.GalM3Label.Location = New System.Drawing.Point(24, 104)
        Me.GalM3Label.Name = "GalM3Label"
        Me.GalM3Label.Size = New System.Drawing.Size(80, 23)
        Me.GalM3Label.TabIndex = 5
        Me.GalM3Label.Text = "xx.xx m³"
        Me.GalM3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FtM3Label
        '
        Me.FtM3Label.Location = New System.Drawing.Point(120, 104)
        Me.FtM3Label.Name = "FtM3Label"
        Me.FtM3Label.Size = New System.Drawing.Size(80, 23)
        Me.FtM3Label.TabIndex = 7
        Me.FtM3Label.Text = "xx.xx m³"
        Me.FtM3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VolumesLabel
        '
        Me.VolumesLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolumesLabel.Location = New System.Drawing.Point(32, 168)
        Me.VolumesLabel.Name = "VolumesLabel"
        Me.VolumesLabel.Size = New System.Drawing.Size(608, 23)
        Me.VolumesLabel.TabIndex = 18
        Me.VolumesLabel.Text = "Gallons      Cu. Feet      Acre-Feet           Liters      Cu. Meters    Megalite" &
    "rs"
        Me.VolumesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VolumeTitleLabel
        '
        Me.VolumeTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolumeTitleLabel.Location = New System.Drawing.Point(264, 8)
        Me.VolumeTitleLabel.Name = "VolumeTitleLabel"
        Me.VolumeTitleLabel.Size = New System.Drawing.Size(112, 23)
        Me.VolumeTitleLabel.TabIndex = 0
        Me.VolumeTitleLabel.Text = "VOLUME"
        Me.VolumeTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MetricVolumeLabel
        '
        Me.MetricVolumeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricVolumeLabel.Location = New System.Drawing.Point(448, 24)
        Me.MetricVolumeLabel.Name = "MetricVolumeLabel"
        Me.MetricVolumeLabel.Size = New System.Drawing.Size(80, 23)
        Me.MetricVolumeLabel.TabIndex = 2
        Me.MetricVolumeLabel.Text = "Metric"
        Me.MetricVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EnglishVolumeLabel
        '
        Me.EnglishVolumeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishVolumeLabel.Location = New System.Drawing.Point(120, 24)
        Me.EnglishVolumeLabel.Name = "EnglishVolumeLabel"
        Me.EnglishVolumeLabel.Size = New System.Drawing.Size(80, 23)
        Me.EnglishVolumeLabel.TabIndex = 1
        Me.EnglishVolumeLabel.Text = "English"
        Me.EnglishVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MegaLiters
        '
        Me.MegaLiters.DecimalPlaces = 3
        Me.MegaLiters.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.MegaLiters.Location = New System.Drawing.Point(544, 192)
        Me.MegaLiters.Name = "MegaLiters"
        Me.MegaLiters.Size = New System.Drawing.Size(80, 23)
        Me.MegaLiters.TabIndex = 24
        '
        'Liters
        '
        Me.Liters.DecimalPlaces = 2
        Me.Liters.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Liters.Location = New System.Drawing.Point(352, 192)
        Me.Liters.Name = "Liters"
        Me.Liters.Size = New System.Drawing.Size(80, 23)
        Me.Liters.TabIndex = 22
        '
        'CubicMeters
        '
        Me.CubicMeters.DecimalPlaces = 2
        Me.CubicMeters.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.CubicMeters.Location = New System.Drawing.Point(448, 192)
        Me.CubicMeters.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.CubicMeters.Name = "CubicMeters"
        Me.CubicMeters.Size = New System.Drawing.Size(80, 23)
        Me.CubicMeters.TabIndex = 23
        '
        'AcreFeet
        '
        Me.AcreFeet.DecimalPlaces = 3
        Me.AcreFeet.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.AcreFeet.Location = New System.Drawing.Point(216, 192)
        Me.AcreFeet.Maximum = New Decimal(New Integer() {621372, 0, 0, 262144})
        Me.AcreFeet.Name = "AcreFeet"
        Me.AcreFeet.Size = New System.Drawing.Size(80, 23)
        Me.AcreFeet.TabIndex = 21
        '
        'Gallons
        '
        Me.Gallons.DecimalPlaces = 2
        Me.Gallons.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Gallons.Location = New System.Drawing.Point(24, 192)
        Me.Gallons.Maximum = New Decimal(New Integer() {109362, 0, 0, 0})
        Me.Gallons.Name = "Gallons"
        Me.Gallons.Size = New System.Drawing.Size(80, 23)
        Me.Gallons.TabIndex = 19
        '
        'CubicFeet
        '
        Me.CubicFeet.DecimalPlaces = 2
        Me.CubicFeet.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.CubicFeet.Location = New System.Drawing.Point(120, 192)
        Me.CubicFeet.Maximum = New Decimal(New Integer() {328085, 0, 0, 0})
        Me.CubicFeet.Name = "CubicFeet"
        Me.CubicFeet.Size = New System.Drawing.Size(80, 23)
        Me.CubicFeet.TabIndex = 20
        '
        'FlowRateTabPage
        '
        Me.FlowRateTabPage.AccessibleDescription = "Shows relationships between English & Metric flow rates."
        Me.FlowRateTabPage.AccessibleName = "Flow Rate Conversion Chart"
        Me.FlowRateTabPage.Controls.Add(Me.GpmCmsLabel)
        Me.FlowRateTabPage.Controls.Add(Me.CfsCmsLabel)
        Me.FlowRateTabPage.Controls.Add(Me.LpsGpmLabel)
        Me.FlowRateTabPage.Controls.Add(Me.CfsLpmLabel)
        Me.FlowRateTabPage.Controls.Add(Me.CmsGpmLabel)
        Me.FlowRateTabPage.Controls.Add(Me.GpmLpmLabel)
        Me.FlowRateTabPage.Controls.Add(Me.FlowRateHeadingsLabel)
        Me.FlowRateTabPage.Controls.Add(Me.LpmGpmLabel)
        Me.FlowRateTabPage.Controls.Add(Me.CmsCfsLabel)
        Me.FlowRateTabPage.Controls.Add(Me.LpmCfsLabel)
        Me.FlowRateTabPage.Controls.Add(Me.LpsCfsLabel)
        Me.FlowRateTabPage.Controls.Add(Me.GpmLpsLabel)
        Me.FlowRateTabPage.Controls.Add(Me.CfsLpsLabel)
        Me.FlowRateTabPage.Controls.Add(Me.FlowRatesLabel)
        Me.FlowRateTabPage.Controls.Add(Me.FlowRateTitleLabel)
        Me.FlowRateTabPage.Controls.Add(Me.MetricFlowRateLabel)
        Me.FlowRateTabPage.Controls.Add(Me.EnglishFlowRateLabel)
        Me.FlowRateTabPage.Controls.Add(Me.CMS)
        Me.FlowRateTabPage.Controls.Add(Me.LPM)
        Me.FlowRateTabPage.Controls.Add(Me.LPS)
        Me.FlowRateTabPage.Controls.Add(Me.GPM)
        Me.FlowRateTabPage.Controls.Add(Me.CFS)
        Me.FlowRateTabPage.Location = New System.Drawing.Point(4, 4)
        Me.FlowRateTabPage.Name = "FlowRateTabPage"
        Me.FlowRateTabPage.Size = New System.Drawing.Size(642, 229)
        Me.FlowRateTabPage.TabIndex = 4
        Me.FlowRateTabPage.Text = "Flow Rate"
        '
        'GpmCmsLabel
        '
        Me.GpmCmsLabel.Location = New System.Drawing.Point(24, 128)
        Me.GpmCmsLabel.Name = "GpmCmsLabel"
        Me.GpmCmsLabel.Size = New System.Drawing.Size(80, 23)
        Me.GpmCmsLabel.TabIndex = 6
        Me.GpmCmsLabel.Text = "xx.xx m³/s"
        Me.GpmCmsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CfsCmsLabel
        '
        Me.CfsCmsLabel.Location = New System.Drawing.Point(120, 128)
        Me.CfsCmsLabel.Name = "CfsCmsLabel"
        Me.CfsCmsLabel.Size = New System.Drawing.Size(80, 23)
        Me.CfsCmsLabel.TabIndex = 9
        Me.CfsCmsLabel.Text = "xx.xx m³/s"
        Me.CfsCmsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LpsGpmLabel
        '
        Me.LpsGpmLabel.Location = New System.Drawing.Point(448, 80)
        Me.LpsGpmLabel.Name = "LpsGpmLabel"
        Me.LpsGpmLabel.Size = New System.Drawing.Size(80, 23)
        Me.LpsGpmLabel.TabIndex = 12
        Me.LpsGpmLabel.Text = "xx.xx gpm"
        Me.LpsGpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CfsLpmLabel
        '
        Me.CfsLpmLabel.Location = New System.Drawing.Point(120, 80)
        Me.CfsLpmLabel.Name = "CfsLpmLabel"
        Me.CfsLpmLabel.Size = New System.Drawing.Size(80, 23)
        Me.CfsLpmLabel.TabIndex = 7
        Me.CfsLpmLabel.Text = "xx.xx lpm"
        Me.CfsLpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmsGpmLabel
        '
        Me.CmsGpmLabel.Location = New System.Drawing.Point(536, 80)
        Me.CmsGpmLabel.Name = "CmsGpmLabel"
        Me.CmsGpmLabel.Size = New System.Drawing.Size(96, 23)
        Me.CmsGpmLabel.TabIndex = 14
        Me.CmsGpmLabel.Text = "xx.xx gpm"
        Me.CmsGpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GpmLpmLabel
        '
        Me.GpmLpmLabel.Location = New System.Drawing.Point(24, 80)
        Me.GpmLpmLabel.Name = "GpmLpmLabel"
        Me.GpmLpmLabel.Size = New System.Drawing.Size(80, 23)
        Me.GpmLpmLabel.TabIndex = 4
        Me.GpmLpmLabel.Text = "xx.xx lpm"
        Me.GpmLpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowRateHeadingsLabel
        '
        Me.FlowRateHeadingsLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowRateHeadingsLabel.Location = New System.Drawing.Point(24, 56)
        Me.FlowRateHeadingsLabel.Name = "FlowRateHeadingsLabel"
        Me.FlowRateHeadingsLabel.Size = New System.Drawing.Size(584, 23)
        Me.FlowRateHeadingsLabel.TabIndex = 3
        Me.FlowRateHeadingsLabel.Text = "1 gpm =       1 cfs =                          1 lpm =      1 lps =      1 m³/s =" &
    ""
        Me.FlowRateHeadingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LpmGpmLabel
        '
        Me.LpmGpmLabel.Location = New System.Drawing.Point(352, 80)
        Me.LpmGpmLabel.Name = "LpmGpmLabel"
        Me.LpmGpmLabel.Size = New System.Drawing.Size(80, 23)
        Me.LpmGpmLabel.TabIndex = 10
        Me.LpmGpmLabel.Text = "xx.xx gpm"
        Me.LpmGpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CmsCfsLabel
        '
        Me.CmsCfsLabel.Location = New System.Drawing.Point(536, 104)
        Me.CmsCfsLabel.Name = "CmsCfsLabel"
        Me.CmsCfsLabel.Size = New System.Drawing.Size(96, 23)
        Me.CmsCfsLabel.TabIndex = 15
        Me.CmsCfsLabel.Text = "xx.xx cfs"
        Me.CmsCfsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LpmCfsLabel
        '
        Me.LpmCfsLabel.Location = New System.Drawing.Point(352, 104)
        Me.LpmCfsLabel.Name = "LpmCfsLabel"
        Me.LpmCfsLabel.Size = New System.Drawing.Size(80, 23)
        Me.LpmCfsLabel.TabIndex = 11
        Me.LpmCfsLabel.Text = "xx.xx cfs"
        Me.LpmCfsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LpsCfsLabel
        '
        Me.LpsCfsLabel.Location = New System.Drawing.Point(448, 104)
        Me.LpsCfsLabel.Name = "LpsCfsLabel"
        Me.LpsCfsLabel.Size = New System.Drawing.Size(80, 23)
        Me.LpsCfsLabel.TabIndex = 13
        Me.LpsCfsLabel.Text = "xx.xx cfs"
        Me.LpsCfsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GpmLpsLabel
        '
        Me.GpmLpsLabel.Location = New System.Drawing.Point(24, 104)
        Me.GpmLpsLabel.Name = "GpmLpsLabel"
        Me.GpmLpsLabel.Size = New System.Drawing.Size(80, 23)
        Me.GpmLpsLabel.TabIndex = 5
        Me.GpmLpsLabel.Text = "xx.xx lps"
        Me.GpmLpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CfsLpsLabel
        '
        Me.CfsLpsLabel.Location = New System.Drawing.Point(120, 104)
        Me.CfsLpsLabel.Name = "CfsLpsLabel"
        Me.CfsLpsLabel.Size = New System.Drawing.Size(80, 23)
        Me.CfsLpsLabel.TabIndex = 8
        Me.CfsLpsLabel.Text = "xx.xx lps"
        Me.CfsLpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowRatesLabel
        '
        Me.FlowRatesLabel.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowRatesLabel.Location = New System.Drawing.Point(32, 168)
        Me.FlowRatesLabel.Name = "FlowRatesLabel"
        Me.FlowRatesLabel.Size = New System.Drawing.Size(600, 23)
        Me.FlowRatesLabel.TabIndex = 16
        Me.FlowRatesLabel.Text = "Gal / Min   Cu. Ft / Sec                     Liter / Min   Liter / Sec   Cu. M / " &
    "Sec"
        Me.FlowRatesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowRateTitleLabel
        '
        Me.FlowRateTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowRateTitleLabel.Location = New System.Drawing.Point(264, 8)
        Me.FlowRateTitleLabel.Name = "FlowRateTitleLabel"
        Me.FlowRateTitleLabel.Size = New System.Drawing.Size(112, 23)
        Me.FlowRateTitleLabel.TabIndex = 0
        Me.FlowRateTitleLabel.Text = "FLOW RATE"
        Me.FlowRateTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MetricFlowRateLabel
        '
        Me.MetricFlowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricFlowRateLabel.Location = New System.Drawing.Point(448, 24)
        Me.MetricFlowRateLabel.Name = "MetricFlowRateLabel"
        Me.MetricFlowRateLabel.Size = New System.Drawing.Size(80, 23)
        Me.MetricFlowRateLabel.TabIndex = 2
        Me.MetricFlowRateLabel.Text = "Metric"
        Me.MetricFlowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EnglishFlowRateLabel
        '
        Me.EnglishFlowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFlowRateLabel.Location = New System.Drawing.Point(120, 24)
        Me.EnglishFlowRateLabel.Name = "EnglishFlowRateLabel"
        Me.EnglishFlowRateLabel.Size = New System.Drawing.Size(80, 23)
        Me.EnglishFlowRateLabel.TabIndex = 1
        Me.EnglishFlowRateLabel.Text = "English"
        Me.EnglishFlowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CMS
        '
        Me.CMS.DecimalPlaces = 3
        Me.CMS.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.CMS.Location = New System.Drawing.Point(544, 192)
        Me.CMS.Name = "CMS"
        Me.CMS.Size = New System.Drawing.Size(80, 23)
        Me.CMS.TabIndex = 21
        '
        'LPM
        '
        Me.LPM.DecimalPlaces = 2
        Me.LPM.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.LPM.Location = New System.Drawing.Point(352, 192)
        Me.LPM.Name = "LPM"
        Me.LPM.Size = New System.Drawing.Size(80, 23)
        Me.LPM.TabIndex = 19
        '
        'LPS
        '
        Me.LPS.DecimalPlaces = 2
        Me.LPS.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.LPS.Location = New System.Drawing.Point(448, 192)
        Me.LPS.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.LPS.Name = "LPS"
        Me.LPS.Size = New System.Drawing.Size(80, 23)
        Me.LPS.TabIndex = 20
        '
        'GPM
        '
        Me.GPM.DecimalPlaces = 2
        Me.GPM.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.GPM.Location = New System.Drawing.Point(24, 192)
        Me.GPM.Maximum = New Decimal(New Integer() {109362, 0, 0, 0})
        Me.GPM.Name = "GPM"
        Me.GPM.Size = New System.Drawing.Size(80, 23)
        Me.GPM.TabIndex = 17
        '
        'CFS
        '
        Me.CFS.DecimalPlaces = 2
        Me.CFS.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.CFS.Location = New System.Drawing.Point(120, 192)
        Me.CFS.Maximum = New Decimal(New Integer() {328085, 0, 0, 0})
        Me.CFS.Name = "CFS"
        Me.CFS.Size = New System.Drawing.Size(80, 23)
        Me.CFS.TabIndex = 18
        '
        'ConversionChart
        '
        Me.AccessibleDescription = "Shows common conversion ratios; provides conversion calculator."
        Me.AccessibleName = "Conversion Chart"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.OkayButton
        Me.ClientSize = New System.Drawing.Size(650, 295)
        Me.Controls.Add(Me.ConversionCharts)
        Me.Controls.Add(Me.ButtonPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConversionChart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conversion Chart"
        Me.ButtonPanel.ResumeLayout(False)
        Me.ConversionCharts.ResumeLayout(False)
        Me.LengthTabPage.ResumeLayout(False)
        CType(Me.Kilometers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Meters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Miles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Yards, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Feet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AreaTabPage.ResumeLayout(False)
        CType(Me.SquareKilometers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Hectares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SquareMeters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SquareMiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Acres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SquareFeet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DepthTabPage.ResumeLayout(False)
        CType(Me.MetersDepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Centimeters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Millimeters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.YardsDepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FeetDepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Inches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VolumeTabPage.ResumeLayout(False)
        CType(Me.MegaLiters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Liters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CubicMeters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AcreFeet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gallons, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CubicFeet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowRateTabPage.ResumeLayout(False)
        CType(Me.CMS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LPS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CFS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Initialization "

    Private Sub InitConversionChart()

        Me.Text = mDictionary.ControlText(Me)

        InitLengthTab()
        InitAreaTab()
        InitDepthTab()
        InitVolumeTab()
        InitFlowRateTab()

    End Sub

#End Region

#Region " Length Tab "

#Region " Initialization "

    Private Sub InitLengthTab()

        ' Display the English conversion factors
        FtmLabel.Text = Format(1.0 / FeetPerMeter, "0.000 m")

        YdmLabel.Text = Format(FeetPerYard / FeetPerMeter, "0.000 m")

        MimLabel.Text = Format(MetersPerMile, "0.0 m")
        MiKmLabel.Text = Format(MetersPerMile / MetersPerKilometer, "0.000 km")

        ' Display the Metric conversion factors
        MftLabel.Text = Format(FeetPerMeter, "0.000 ft")
        MydLabel.Text = Format(FeetPerMeter / FeetPerYard, "0.000 yd")

        KmFtLabel.Text = Format(FeetPerMeter * MetersPerKilometer, "0.0 ft")
        KmYdLabel.Text = Format(FeetPerMeter * MetersPerKilometer / FeetPerYard, "0.0 yd")
        KmMiLabel.Text = Format(MetersPerKilometer / MetersPerMile, "0.0000 mi")

        ' Maximum value for length
        Feet.Maximum = 99999999
        Yards.Maximum = CDec(Feet.Maximum / FeetPerYard)
        Miles.Maximum = CDec(Feet.Maximum / FeetPerMile)

        Meters.Maximum = CDec(Feet.Maximum / FeetPerMeter)
        Kilometers.Maximum = CDec(Meters.Maximum / MetersPerKilometer)

        ' Start the length conversion calculator at 1 mile
        Miles.Value = 1

    End Sub

#End Region

#Region " UI Event Handlers "

    Private LengthUpdating As Boolean = False

    Private WriteOnly Property SiLength() As Double
        Set(ByVal Value As Double)
            LengthUpdating = True
            Value = Math.Min(Value, Meters.Maximum)
            Try
                ' English values
                Dim _feet As Decimal = CDec(Value * FeetPerMeter)
                If (10000.0 <= _feet) Then
                    Feet.DecimalPlaces = 0
                    Feet.Increment = 1
                ElseIf (1000.0 <= _feet) Then
                    Feet.DecimalPlaces = 1
                    Feet.Increment = 0.1D
                ElseIf (100.0 <= _feet) Then
                    Feet.DecimalPlaces = 2
                    Feet.Increment = 0.01D
                Else
                    Feet.DecimalPlaces = 3
                    Feet.Increment = 0.001D
                End If
                Feet.Value = _feet

                Dim _yards As Decimal = CDec(Value * FeetPerMeter / FeetPerYard)
                If (10000.0 <= _yards) Then
                    Yards.DecimalPlaces = 0
                    Yards.Increment = 1
                ElseIf (1000.0 <= _yards) Then
                    Yards.DecimalPlaces = 1
                    Yards.Increment = 0.1D
                ElseIf (100.0 <= _yards) Then
                    Yards.DecimalPlaces = 2
                    Yards.Increment = 0.01D
                Else
                    Yards.DecimalPlaces = 3
                    Yards.Increment = 0.001D
                End If
                Yards.Value = _yards

                Dim _miles As Decimal = CDec(Value / MetersPerMile)
                If (10.0 <= _miles) Then
                    Miles.DecimalPlaces = 2
                    Miles.Increment = 0.01D
                ElseIf (1.0 <= _miles) Then
                    Miles.DecimalPlaces = 3
                    Miles.Increment = 0.001D
                Else
                    Miles.DecimalPlaces = 4
                    Miles.Increment = 0.0001D
                End If
                Miles.Value = _miles

                ' Metric values
                Dim _meters As Decimal = CDec(Value)
                If (10000.0 <= _meters) Then
                    Meters.DecimalPlaces = 0
                    Meters.Increment = 1
                ElseIf (1000.0 <= _meters) Then
                    Meters.DecimalPlaces = 1
                    Meters.Increment = 0.1D
                ElseIf (100.0 <= _meters) Then
                    Meters.DecimalPlaces = 2
                    Meters.Increment = 0.01D
                Else
                    Meters.DecimalPlaces = 3
                    Meters.Increment = 0.001D
                End If
                Meters.Value = _meters

                Dim _kilos As Decimal = CDec(Value / MetersPerKilometer)
                If (10.0 <= _kilos) Then
                    Kilometers.DecimalPlaces = 2
                    Kilometers.Increment = 0.01D
                ElseIf (1.0 <= _kilos) Then
                    Kilometers.DecimalPlaces = 3
                    Kilometers.Increment = 0.001D
                Else
                    Kilometers.DecimalPlaces = 4
                    Kilometers.Increment = 0.0001D
                End If
                Kilometers.Value = _kilos

            Catch ex As Exception
                ' Set to maximums
                Kilometers.Value = Kilometers.Maximum
                Meters.Value = CDec(Kilometers.Value * MetersPerKilometer)

                Miles.Value = CDec(Meters.Value / MetersPerMile)
                Yards.Value = CDec(Miles.Value * YardsPerMile)
                Feet.Value = CDec(Yards.Value * FeetPerYard)
            Finally
                LengthUpdating = False
            End Try
        End Set
    End Property
    '
    ' Feet
    '
    Private Sub Feet_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Feet.ValueChanged
        If Not (LengthUpdating) Then
            SiLength = Feet.Value / FeetPerMeter
        End If
    End Sub

    Private Sub Feet_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Feet.LostFocus
        If Not (LengthUpdating) Then
            SiLength = Feet.Value / FeetPerMeter
        End If
    End Sub
    '
    ' Yards
    '
    Private Sub Yards_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Yards.ValueChanged
        If Not (LengthUpdating) Then
            SiLength = Yards.Value * FeetPerYard / FeetPerMeter
        End If
    End Sub

    Private Sub Yards_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Yards.LostFocus
        If Not (LengthUpdating) Then
            SiLength = Yards.Value * FeetPerYard / FeetPerMeter
        End If
    End Sub
    '
    ' Miles
    '
    Private Sub Miles_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Miles.ValueChanged
        If Not (LengthUpdating) Then
            SiLength = Miles.Value * MetersPerMile
        End If
    End Sub

    Private Sub Miles_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Miles.LostFocus
        If Not (LengthUpdating) Then
            SiLength = Miles.Value * MetersPerMile
        End If
    End Sub
    '
    ' Meters
    '
    Private Sub Meters_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Meters.ValueChanged
        If Not (LengthUpdating) Then
            SiLength = Meters.Value
        End If
    End Sub

    Private Sub Meters_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Meters.LostFocus
        If Not (LengthUpdating) Then
            SiLength = Meters.Value
        End If
    End Sub
    '
    ' Kilometers
    '
    Private Sub Kilometers_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Kilometers.ValueChanged
        If Not (LengthUpdating) Then
            SiLength = Kilometers.Value * MetersPerKilometer
        End If
    End Sub

    Private Sub Kilometers_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Kilometers.LostFocus
        If Not (LengthUpdating) Then
            SiLength = Kilometers.Value * MetersPerKilometer
        End If
    End Sub

#End Region

#End Region

#Region " Area Tab "

#Region " Initialization "

    Private Sub InitAreaTab()

        ' Display the English conversion factors
        Ftm2Label.Text = Format(1.0 / SquareFeetPerSquareMeter, "0.000 m²")

        Acm2Label.Text = Format(SquareMetersPerAcre, "0.0 m²")
        AcHaLabel.Text = Format(HectaresPerAcre, "0.000 ha")
        AcKm2Label.Text = Format(SquareKilometersPerAcre, "0.0000 km²")

        Mim2Label.Text = Format(SquareMetersPerSquareMile, "0 m²")
        MiHaLabel.Text = Format(HectaresPerSquareMile, "0.00 ha")
        MiKm2Label.Text = Format(SquareKilometersPerSquareMile, "0.000 km²")

        ' Display the Metric conversion factors
        Mft2Label.Text = Format(SquareFeetPerSquareMeter, "0.000 ft²")

        HaFt2Label.Text = Format(SquareFeetPerHectare, "0 ft²")
        HaAcLabel.Text = Format(AcresPerHectare, "0.000 acres")
        HaMi2Label.Text = Format(1.0 / HectaresPerSquareMile, "0.0000 mi²")

        KmFt2Label.Text = Format(SquareFeetPerSquareKilometer, "0 ft²")
        KmAcLabel.Text = Format(AcresPerSquareKilometer, "0.00 acres")
        KmMi2Label.Text = Format(1.0 / SquareKilometersPerSquareMile, "0.0000 mi²")

        ' Maximum value for area
        SquareFeet.Maximum = 999999999
        Acres.Maximum = CDec(SquareFeet.Maximum / SquareFeetPerAcre)
        SquareMiles.Maximum = CDec(SquareFeet.Maximum / SquareFeetPerSquareMile)

        SquareKilometers.Maximum = CDec(SquareMiles.Maximum * SquareKilometersPerSquareMile)
        Hectares.Maximum = CDec(SquareKilometers.Maximum * HectaresPerSquareKilometer)
        SquareMeters.Maximum = CDec(SquareKilometers.Maximum * SquareMetersPerSquareKilometer)

        ' Start the area conversion calculator at 1 acre
        Acres.Value = 1

    End Sub

#End Region

#Region " UI Event Handlers "

    Private AreaUpdating As Boolean = False

    Private WriteOnly Property SiArea() As Double
        Set(ByVal Value As Double)
            AreaUpdating = True
            Value = Math.Min(Value, SquareMeters.Maximum)
            Try
                ' English values
                Dim _sqFeet As Decimal = CDec(Value * SquareFeetPerSquareMeter)
                If (10000.0 <= _sqFeet) Then
                    SquareFeet.DecimalPlaces = 0
                    SquareFeet.Increment = 1
                ElseIf (1000.0 <= _sqFeet) Then
                    SquareFeet.DecimalPlaces = 1
                    SquareFeet.Increment = 0.1D
                ElseIf (100.0 <= _sqFeet) Then
                    SquareFeet.DecimalPlaces = 2
                    SquareFeet.Increment = 0.01D
                Else
                    SquareFeet.DecimalPlaces = 3
                    SquareFeet.Increment = 0.001D
                End If
                SquareFeet.Value = _sqFeet

                Dim _acres As Decimal = CDec(Value / SquareMetersPerAcre)
                If (10000.0 <= _acres) Then
                    Acres.DecimalPlaces = 0
                    Acres.Increment = 1
                ElseIf (1000.0 <= _acres) Then
                    Acres.DecimalPlaces = 1
                    Acres.Increment = 0.1D
                ElseIf (100.0 <= _acres) Then
                    Acres.DecimalPlaces = 2
                    Acres.Increment = 0.01D
                Else
                    Acres.DecimalPlaces = 3
                    Acres.Increment = 0.001D
                End If
                Acres.Value = _acres

                Dim _sqMiles As Decimal = CDec(Value / SquareMetersPerSquareMile)
                If (10.0 <= _sqMiles) Then
                    SquareMiles.DecimalPlaces = 2
                    SquareMiles.Increment = 0.01D
                ElseIf (1.0 <= _sqMiles) Then
                    SquareMiles.DecimalPlaces = 3
                    SquareMiles.Increment = 0.001D
                Else
                    SquareMiles.DecimalPlaces = 4
                    SquareMiles.Increment = 0.0001D
                End If
                SquareMiles.Value = _sqMiles

                ' Metric values
                Dim _sqMeters As Decimal = CDec(Value)
                If (10000.0 <= _sqMeters) Then
                    SquareMeters.DecimalPlaces = 0
                    SquareMeters.Increment = 1
                ElseIf (1000.0 <= _sqMeters) Then
                    SquareMeters.DecimalPlaces = 1
                    SquareMeters.Increment = 0.1D
                ElseIf (100.0 <= _sqMeters) Then
                    SquareMeters.DecimalPlaces = 2
                    SquareMeters.Increment = 0.01D
                Else
                    SquareMeters.DecimalPlaces = 3
                    SquareMeters.Increment = 0.001D
                End If
                SquareMeters.Value = _sqMeters

                Dim _hectares As Decimal = CDec(Value / SquareMetersPerHectare)
                If (10000.0 <= _hectares) Then
                    Hectares.DecimalPlaces = 0
                    Hectares.Increment = 1
                ElseIf (1000.0 <= _hectares) Then
                    Hectares.DecimalPlaces = 1
                    Hectares.Increment = 0.1D
                ElseIf (100.0 <= _hectares) Then
                    Hectares.DecimalPlaces = 2
                    Hectares.Increment = 0.01D
                Else
                    Hectares.DecimalPlaces = 3
                    Hectares.Increment = 0.001D
                End If
                Hectares.Value = _hectares

                Dim _sqKilos As Decimal = CDec(Value / SquareMetersPerSquareKilometer)
                If (10.0 <= _sqKilos) Then
                    SquareKilometers.DecimalPlaces = 2
                    SquareKilometers.Increment = 0.01D
                ElseIf (1.0 <= _sqKilos) Then
                    SquareKilometers.DecimalPlaces = 3
                    SquareKilometers.Increment = 0.001D
                Else
                    SquareKilometers.DecimalPlaces = 4
                    SquareKilometers.Increment = 0.0001D
                End If
                SquareKilometers.Value = _sqKilos

            Catch ex As Exception
                ' Set to maximums
                SquareKilometers.Value = CDec(SquareKilometers.Maximum)
                Hectares.Value = CDec(SquareKilometers.Value * HectaresPerSquareKilometer)
                SquareMeters.Value = CDec(SquareKilometers.Value * SquareMetersPerSquareKilometer)

                SquareMiles.Value = CDec(SquareKilometers.Value / SquareKilometersPerSquareMile)
                Acres.Value = CDec(SquareMiles.Value * AcresPerSquareMile)
                SquareFeet.Value = CDec(SquareMiles.Value * SquareFeetPerSquareMile)
            Finally
                AreaUpdating = False
            End Try
        End Set
    End Property
    '
    ' Feet²
    '
    Private Sub SquareFeet_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SquareFeet.ValueChanged
        If Not (AreaUpdating) Then
            SiArea = SquareFeet.Value / SquareFeetPerSquareMeter
        End If
    End Sub

    Private Sub SquareFeet_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SquareFeet.LostFocus
        If Not (AreaUpdating) Then
            SiArea = SquareFeet.Value / SquareFeetPerSquareMeter
        End If
    End Sub
    '
    ' Acres
    '
    Private Sub Acres_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Acres.ValueChanged
        If Not (AreaUpdating) Then
            SiArea = Acres.Value * SquareMetersPerAcre
        End If
    End Sub

    Private Sub Acres_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Acres.LostFocus
        If Not (AreaUpdating) Then
            SiArea = Acres.Value * SquareMetersPerAcre
        End If
    End Sub
    '
    ' Miles²
    '
    Private Sub SquareMiles_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SquareMiles.ValueChanged
        If Not (AreaUpdating) Then
            SiArea = SquareMiles.Value * SquareMetersPerSquareMile
        End If
    End Sub

    Private Sub SquareMiles_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SquareMiles.LostFocus
        If Not (AreaUpdating) Then
            SiArea = SquareMiles.Value * SquareMetersPerSquareMile
        End If
    End Sub
    '
    ' Meters²
    '
    Private Sub SquareMeters_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SquareMeters.ValueChanged
        If Not (AreaUpdating) Then
            SiArea = SquareMeters.Value
        End If
    End Sub

    Private Sub SquareMeters_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SquareMeters.LostFocus
        If Not (AreaUpdating) Then
            SiArea = SquareMeters.Value
        End If
    End Sub
    '
    ' Hectares
    '
    Private Sub Hectares_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Hectares.ValueChanged
        If Not (AreaUpdating) Then
            SiArea = Hectares.Value * SquareMetersPerHectare
        End If
    End Sub

    Private Sub Hectares_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Hectares.LostFocus
        If Not (AreaUpdating) Then
            SiArea = Hectares.Value * SquareMetersPerHectare
        End If
    End Sub
    '
    ' Kilometers²
    '
    Private Sub SquareKilometers_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SquareKilometers.ValueChanged
        If Not (AreaUpdating) Then
            SiArea = SquareKilometers.Value * SquareMetersPerSquareKilometer
        End If
    End Sub

    Private Sub SquareKilometers_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SquareKilometers.LostFocus
        If Not (AreaUpdating) Then
            SiArea = SquareKilometers.Value * SquareMetersPerSquareKilometer
        End If
    End Sub

#End Region

#End Region

#Region " Depth Tab "

#Region " Initialization "

    Private Sub InitDepthTab()

        ' Display the English conversion factors
        InMmLabel.Text = Format(MillimetersPerInch, "0.000 mm")
        InCmLabel.Text = Format(CentimetersPerInch, "0.000 cm")

        FtMmLabel.Text = Format(MillimetersPerInch * InchesPerFoot, "0.00 mm")
        FtCmLabel.Text = Format(CentimetersPerInch * InchesPerFoot, "0.00 cm")
        FtMdLabel.Text = Format(MetersPerFoot, "0.000 m")

        YdMmLabel.Text = Format(MillimetersPerInch * InchesPerYard, "0.00 mm")
        YdCmLabel.Text = Format(CentimetersPerInch * InchesPerYard, "0.00 cm")
        YdMdLabel.Text = Format(MetersPerYard, "0.000 m")

        ' Display the Metric conversion factors
        MmInLabel.Text = Format(InchesPerMillimeter, "0.000 in")

        CmInLabel.Text = Format(InchesPerCentimeter, "0.000 in")
        CmFtLabel.Text = Format(InchesPerCentimeter / InchesPerFoot, "0.000 ft")
        CmYdLabel.Text = Format(InchesPerCentimeter / InchesPerYard, "0.000 yd")

        MdInLabel.Text = Format(InchesPerMeter, "0.000 in")
        MdFtLabel.Text = Format(InchesPerMeter / InchesPerFoot, "0.000 ft")
        MdYdLabel.Text = Format(InchesPerMeter / InchesPerYard, "0.00 yd")

        ' Maximum value for meters
        Millimeters.Maximum = 9999999
        Centimeters.Maximum = CDec(Millimeters.Maximum / 10.0)
        MetersDepth.Maximum = CDec(Millimeters.Maximum / MillimetersPerMeter)

        YardsDepth.Maximum = CDec(MetersDepth.Maximum / MetersPerYard)
        FeetDepth.Maximum = CDec(MetersDepth.Maximum / MetersPerFoot)
        Inches.Maximum = CDec(MetersDepth.Maximum / MetersPerInch)

        ' Start the depth conversion calculator at 100 mm
        Millimeters.Value = 100

    End Sub

#End Region

#Region " UI Event Handlers "

    Private DepthUpdating As Boolean = False

    Private WriteOnly Property SiDepth() As Double
        Set(ByVal Value As Double)
            DepthUpdating = True
            Value = Math.Min(Value, Millimeters.Maximum)
            Try
                ' English values
                Dim _inches As Decimal = CDec(Value / MillimetersPerInch)
                If (10000.0 <= _inches) Then
                    Inches.DecimalPlaces = 0
                    Inches.Increment = 1
                ElseIf (1000.0 <= _inches) Then
                    Inches.DecimalPlaces = 1
                    Inches.Increment = 0.1D
                ElseIf (100.0 <= _inches) Then
                    Inches.DecimalPlaces = 2
                    Inches.Increment = 0.01D
                Else
                    Inches.DecimalPlaces = 3
                    Inches.Increment = 0.001D
                End If
                Inches.Value = _inches

                Dim _feet As Decimal = CDec(Value / InchesPerFoot / MillimetersPerInch)
                If (10000.0 <= _feet) Then
                    FeetDepth.DecimalPlaces = 0
                    FeetDepth.Increment = 1
                ElseIf (1000.0 <= _feet) Then
                    FeetDepth.DecimalPlaces = 1
                    FeetDepth.Increment = 0.1D
                ElseIf (100.0 <= _feet) Then
                    FeetDepth.DecimalPlaces = 2
                    FeetDepth.Increment = 0.01D
                Else
                    FeetDepth.DecimalPlaces = 3
                    FeetDepth.Increment = 0.001D
                End If
                FeetDepth.Value = _feet

                Dim _yards As Decimal = CDec(Value / InchesPerYard / MillimetersPerInch)
                If (1.0 <= _yards) Then
                    YardsDepth.DecimalPlaces = 2
                    YardsDepth.Increment = 0.01D
                Else
                    YardsDepth.DecimalPlaces = 3
                    YardsDepth.Increment = 0.001D
                End If
                YardsDepth.Value = _yards

                ' Metric values
                Dim _millimeters As Decimal = CDec(Value)
                If (10000.0 <= _millimeters) Then
                    Millimeters.DecimalPlaces = 0
                    Millimeters.Increment = 1
                ElseIf (1000.0 <= _millimeters) Then
                    Millimeters.DecimalPlaces = 1
                    Millimeters.Increment = 0.1D
                ElseIf (100.0 <= _millimeters) Then
                    Millimeters.DecimalPlaces = 2
                    Millimeters.Increment = 0.01D
                Else
                    Millimeters.DecimalPlaces = 3
                    Millimeters.Increment = 0.001D
                End If
                Millimeters.Value = _millimeters

                Dim _centimeters As Decimal = CDec(Value / 10.0)
                If (1000.0 <= _centimeters) Then
                    Centimeters.DecimalPlaces = 0
                    Centimeters.Increment = 1
                ElseIf (100.0 <= _centimeters) Then
                    Centimeters.DecimalPlaces = 1
                    Centimeters.Increment = 0.1D
                ElseIf (10.0 <= _centimeters) Then
                    Centimeters.DecimalPlaces = 2
                    Centimeters.Increment = 0.01D
                Else
                    Centimeters.DecimalPlaces = 3
                    Centimeters.Increment = 0.001D
                End If
                Centimeters.Value = _centimeters

                Dim _meters As Decimal = CDec(Value / 1000.0)
                If (1.0 <= _meters) Then
                    MetersDepth.DecimalPlaces = 2
                    MetersDepth.Increment = 0.01D
                Else
                    MetersDepth.DecimalPlaces = 3
                    MetersDepth.Increment = 0.001D
                End If
                MetersDepth.Value = _meters

            Catch ex As Exception
                ' Set to maximums
                MetersDepth.Value = MetersDepth.Maximum
                Centimeters.Value = MetersDepth.Value * 100
                Millimeters.Value = MetersDepth.Value * 1000

                YardsDepth.Value = CDec(MetersDepth.Value / MetersPerYard)
                FeetDepth.Value = CDec(YardsDepth.Value * FeetPerYard)
                Inches.Value = CDec(YardsDepth.Value * InchesPerYard)
            Finally
                DepthUpdating = False
            End Try
        End Set
    End Property
    '
    ' Inches
    '
    Private Sub Inches_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Inches.ValueChanged
        If Not (DepthUpdating) Then
            SiDepth = Inches.Value * MillimetersPerInch
        End If
    End Sub

    Private Sub Inches_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Inches.LostFocus
        If Not (DepthUpdating) Then
            SiDepth = Inches.Value * MillimetersPerInch
        End If
    End Sub
    '
    ' Feet
    '
    Private Sub FeetDepth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FeetDepth.ValueChanged
        If Not (DepthUpdating) Then
            SiDepth = FeetDepth.Value * InchesPerFoot * MillimetersPerInch
        End If
    End Sub

    Private Sub FeetDepth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FeetDepth.LostFocus
        If Not (DepthUpdating) Then
            SiDepth = FeetDepth.Value * InchesPerFoot * MillimetersPerInch
        End If
    End Sub
    '
    ' Yards
    '
    Private Sub YardsDepth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles YardsDepth.ValueChanged
        If Not (DepthUpdating) Then
            SiDepth = YardsDepth.Value * FeetPerYard * InchesPerFoot * MillimetersPerInch
        End If
    End Sub

    Private Sub YardsDepth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles YardsDepth.LostFocus
        If Not (DepthUpdating) Then
            SiDepth = YardsDepth.Value * FeetPerYard * InchesPerFoot * MillimetersPerInch
        End If
    End Sub
    '
    ' Millimeters
    '
    Private Sub Millimeters_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Millimeters.ValueChanged
        If Not (DepthUpdating) Then
            SiDepth = Millimeters.Value
        End If
    End Sub

    Private Sub Millimeters_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Millimeters.LostFocus
        If Not (DepthUpdating) Then
            SiDepth = Millimeters.Value
        End If
    End Sub
    '
    ' Centimeters
    '
    Private Sub Centimeters_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Centimeters.ValueChanged
        If Not (DepthUpdating) Then
            SiDepth = Centimeters.Value * 10.0
        End If
    End Sub

    Private Sub Centimeters_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Centimeters.LostFocus
        If Not (DepthUpdating) Then
            SiDepth = Centimeters.Value * 10.0
        End If
    End Sub
    '
    ' Meters
    '
    Private Sub MetersDepth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetersDepth.ValueChanged
        If Not (DepthUpdating) Then
            SiDepth = MetersDepth.Value * 1000.0
        End If
    End Sub

    Private Sub MetersDepth_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetersDepth.LostFocus
        If Not (DepthUpdating) Then
            SiDepth = MetersDepth.Value * 1000.0
        End If
    End Sub

#End Region

#End Region

#Region " Volume Tab "

#Region " Initialization "

    Private Sub InitVolumeTab()

        ' Display the English conversion factors
        GalLiLabel.Text = Format(1.0 / GallonsPerLiter, "0.000 l")
        GalM3Label.Text = Format(1.0 / GallonsPerCubicMeter, "0.0000 m³")

        FtLiLabel.Text = Format(1.0 / CubicFeetPerLiter, "0.000 l")
        FtM3Label.Text = Format(1.0 / CubicFeetPerCubicMeter, "0.0000 m³")

        AfLiLabel.Text = Format(LitersPerCubicMeter * CubicMetersPerAcreFt, "0 l")
        AfM3Label.Text = Format(CubicMetersPerAcreFt, "0.00 m³")
        AfMlLabel.Text = Format(MegaLitersPerAcreFt, "0.000 ML")

        ' Display the Metric conversion factors
        LiGalLabel.Text = Format(GallonsPerLiter, "0.000 gal")
        LiFtLabel.Text = Format(CubicFeetPerLiter, "0.000 ft³")

        M3GalLabel.Text = Format(GallonsPerCubicMeter, "0.00 gal")
        M3FtLabel.Text = Format(CubicFeetPerCubicMeter, "0.000 ft³")

        MlGalLabel.Text = Format(GallonsPerCubicMeter * CubicMetersPerMegaLiter, "0 gal")
        MlFtLabel.Text = Format(CubicFeetPerCubicMeter * CubicMetersPerMegaLiter, "0 ft³")
        MlAfLabel.Text = Format(1.0 / MegaLitersPerAcreFt, "0.0000 af")

        ' Maximum value for acrefoot
        Liters.Maximum = 99999999
        MegaLiters.Maximum = CDec(Liters.Maximum / LitersPerMegaLiter)
        CubicMeters.Maximum = CDec(Liters.Maximum / LitersPerCubicMeter)

        AcreFeet.Maximum = CDec(CubicMeters.Maximum * AcreFeetPerCubicMeter)
        CubicFeet.Maximum = CDec(AcreFeet.Maximum * AcreFt)
        Gallons.Maximum = CDec(CubicFeet.Maximum * GallonsPerCubicFoot)

        ' Start the volume conversion calculator at 1 acrefoot
        AcreFeet.Value = 1

    End Sub

#End Region

#Region " UI Event Handlers "

    Private VolumeUpdating As Boolean = False

    Private WriteOnly Property SiVolume() As Double
        Set(ByVal Value As Double)
            VolumeUpdating = True
            Value = Math.Min(Value, CubicFeet.Maximum)
            Try
                ' English values
                Dim _gallons As Decimal = CDec(Value * GallonsPerCubicMeter)
                If (10000.0 <= _gallons) Then
                    Gallons.DecimalPlaces = 0
                    Gallons.Increment = 1
                ElseIf (1000.0 <= _gallons) Then
                    Gallons.DecimalPlaces = 1
                    Gallons.Increment = 0.1D
                ElseIf (100.0 <= _gallons) Then
                    Gallons.DecimalPlaces = 2
                    Gallons.Increment = 0.01D
                Else
                    Gallons.DecimalPlaces = 3
                    Gallons.Increment = 0.001D
                End If
                Gallons.Value = _gallons

                Dim _cubicfeet As Decimal = CDec(Value * CubicFeetPerCubicMeter)
                If (10000.0 <= _cubicfeet) Then
                    CubicFeet.DecimalPlaces = 0
                    CubicFeet.Increment = 1
                ElseIf (1000.0 <= _cubicfeet) Then
                    CubicFeet.DecimalPlaces = 1
                    CubicFeet.Increment = 0.1D
                ElseIf (100.0 <= _cubicfeet) Then
                    CubicFeet.DecimalPlaces = 2
                    CubicFeet.Increment = 0.01D
                Else
                    CubicFeet.DecimalPlaces = 3
                    CubicFeet.Increment = 0.001D
                End If
                CubicFeet.Value = _cubicfeet

                Dim _acrefeet As Decimal = CDec(Value / CubicMetersPerAcreFt)
                If (10.0 <= _acrefeet) Then
                    AcreFeet.DecimalPlaces = 2
                    AcreFeet.Increment = 0.01D
                ElseIf (1.0 <= _acrefeet) Then
                    AcreFeet.DecimalPlaces = 3
                    AcreFeet.Increment = 0.001D
                Else
                    AcreFeet.DecimalPlaces = 4
                    AcreFeet.Increment = 0.0001D
                End If
                AcreFeet.Value = _acrefeet

                ' Metric values
                Dim _liter As Decimal = CDec(Value * LitersPerCubicMeter)
                If (10000.0 <= _liter) Then
                    Liters.DecimalPlaces = 0
                    Liters.Increment = 1
                ElseIf (1000.0 <= _liter) Then
                    Liters.DecimalPlaces = 1
                    Liters.Increment = 0.1D
                ElseIf (100.0 <= _liter) Then
                    Liters.DecimalPlaces = 2
                    Liters.Increment = 0.01D
                Else
                    Liters.DecimalPlaces = 3
                    Liters.Increment = 0.001D
                End If
                Liters.Value = _liter

                Dim _cubicMeters As Decimal = CDec(Value)
                If (10000.0 <= _cubicMeters) Then
                    CubicMeters.DecimalPlaces = 1
                    CubicMeters.Increment = 0.1D
                ElseIf (1000.0 <= _cubicMeters) Then
                    CubicMeters.DecimalPlaces = 2
                    CubicMeters.Increment = 0.01D
                ElseIf (100.0 <= _cubicMeters) Then
                    CubicMeters.DecimalPlaces = 3
                    CubicMeters.Increment = 0.001D
                Else
                    CubicMeters.DecimalPlaces = 4
                    CubicMeters.Increment = 0.0001D
                End If
                CubicMeters.Value = _cubicMeters

                Dim _megaliter As Decimal = CDec(Value / CubicMetersPerMegaLiter)
                If (10.0 <= _megaliter) Then
                    MegaLiters.DecimalPlaces = 2
                    MegaLiters.Increment = 0.01D
                ElseIf (1.0 <= _megaliter) Then
                    MegaLiters.DecimalPlaces = 3
                    MegaLiters.Increment = 0.001D
                Else
                    MegaLiters.DecimalPlaces = 4
                    MegaLiters.Increment = 0.0001D
                End If
                MegaLiters.Value = _megaliter

            Catch ex As Exception
                ' Set to maximums
                MegaLiters.Value = MegaLiters.Maximum
                CubicMeters.Value = CDec(MegaLiters.Maximum * CubicMetersPerMegaLiter)
                Liters.Value = CDec(CubicMeters.Maximum * LitersPerCubicMeter)

                AcreFeet.Value = CDec(MegaLiters.Maximum / MegaLitersPerAcreFt)
                CubicFeet.Value = CDec(AcreFeet.Maximum * AcreFt)
                Gallons.Value = CDec(CubicFeet.Maximum * GallonsPerCubicFoot)
            Finally
                VolumeUpdating = False
            End Try
        End Set
    End Property
    '
    ' Gallons
    '
    Private Sub Gallons_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Gallons.ValueChanged
        If Not (VolumeUpdating) Then
            SiVolume = Gallons.Value / GallonsPerCubicMeter
        End If
    End Sub

    Private Sub Gallons_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Gallons.LostFocus
        If Not (VolumeUpdating) Then
            SiVolume = Gallons.Value / GallonsPerCubicMeter
        End If
    End Sub
    '
    ' Feet³
    '
    Private Sub CubicFeet_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CubicFeet.ValueChanged
        If Not (VolumeUpdating) Then
            SiVolume = CubicFeet.Value / CubicFeetPerCubicMeter
        End If
    End Sub

    Private Sub CubicFeet_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CubicFeet.LostFocus
        If Not (VolumeUpdating) Then
            SiVolume = CubicFeet.Value / CubicFeetPerCubicMeter
        End If
    End Sub
    '
    ' Acre Feet
    '
    Private Sub AcreFeet_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AcreFeet.ValueChanged
        If Not (VolumeUpdating) Then
            SiVolume = AcreFeet.Value * CubicMetersPerAcreFt
        End If
    End Sub

    Private Sub AcreFeet_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AcreFeet.LostFocus
        If Not (VolumeUpdating) Then
            SiVolume = AcreFeet.Value * CubicMetersPerAcreFt
        End If
    End Sub
    '
    ' Liters
    '
    Private Sub Liters_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Liters.ValueChanged
        If Not (VolumeUpdating) Then
            SiVolume = Liters.Value / LitersPerCubicMeter
        End If
    End Sub

    Private Sub Liters_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Liters.LostFocus
        If Not (VolumeUpdating) Then
            SiVolume = Liters.Value / LitersPerCubicMeter
        End If
    End Sub
    '
    ' Meters³
    '
    Private Sub CubicMeters_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CubicMeters.ValueChanged
        If Not (VolumeUpdating) Then
            SiVolume = CubicMeters.Value
        End If
    End Sub

    Private Sub CubicMeters_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CubicMeters.LostFocus
        If Not (VolumeUpdating) Then
            SiVolume = CubicMeters.Value
        End If
    End Sub
    '
    ' MegaLiters
    '
    Private Sub MegaLiters_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MegaLiters.ValueChanged
        If Not (VolumeUpdating) Then
            SiVolume = MegaLiters.Value * CubicMetersPerMegaLiter
        End If
    End Sub

    Private Sub MegaLiters_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MegaLiters.LostFocus
        If Not (VolumeUpdating) Then
            SiVolume = MegaLiters.Value * CubicMetersPerMegaLiter
        End If
    End Sub

#End Region

#End Region

#Region " Flow Rate Tab "

#Region " Initialization "

    Private Sub InitFlowRateTab()

        ' Display the English conversion factors
        GpmLpmLabel.Text = Format(LitersPerGallon, "0.000 lpm")
        GpmLpsLabel.Text = Format(LitersPerGallon / SecondsPerMinute, "0.000 lps")
        GpmCmsLabel.Text = Format(1.0 / GallonsPerCubicMeter / SecondsPerMinute, "0.0000 m³/s")

        CfsLpmLabel.Text = Format(LitersPerCubicFoot * SecondsPerMinute, "0.0 lpm")
        CfsLpsLabel.Text = Format(LitersPerCubicFoot, "0.000 lps")
        CfsCmsLabel.Text = Format(1.0 / CubicFeetPerCubicMeter, "0.0000 m³/s")

        ' Display the Metric conversion factors
        LpmGpmLabel.Text = Format(GallonsPerLiter, "0.000 gpm")
        LpmCfsLabel.Text = Format(CubicFeetPerLiter / SecondsPerMinute, "0.000 cfs")

        LpsGpmLabel.Text = Format(GallonsPerLiter * SecondsPerMinute, "0.000 gpm")
        LpsCfsLabel.Text = Format(CubicFeetPerLiter, "0.000 cfs")

        CmsGpmLabel.Text = Format(GallonsPerCubicMeter * SecondsPerMinute, "0 gpm")
        CmsCfsLabel.Text = Format(CubicFeetPerCubicMeter, "0.000 cfs")

        ' Maximum value for m³/s
        LPM.Maximum = 99999999
        LPS.Maximum = CDec(LPM.Maximum / SecondsPerMinute)
        CMS.Maximum = CDec(LPS.Maximum * CubicMetersPerLiter)

        GPM.Maximum = CDec(CMS.Maximum * GallonsPerCubicMeter * SecondsPerMinute)
        CFS.Maximum = CDec(CMS.Maximum * CubicFeetPerCubicMeter)

        ' Start the volume conversion calculator at 1 m³/s
        CMS.Value = 1

    End Sub

#End Region

#Region " UI Event Handlers "

    Private FlowRateUpdating As Boolean = False

    Private WriteOnly Property SiFlowRate() As Double
        Set(ByVal Value As Double)
            FlowRateUpdating = True
            Value = Math.Min(Value, CMS.Maximum)
            Try
                ' English values
                Dim _gpm As Decimal = CDec(Value * GallonsPerCubicMeter * SecondsPerMinute)
                If (10000.0 <= _gpm) Then
                    GPM.DecimalPlaces = 0
                    GPM.Increment = 1
                ElseIf (1000.0 <= _gpm) Then
                    GPM.DecimalPlaces = 1
                    GPM.Increment = 0.1D
                ElseIf (100.0 <= _gpm) Then
                    GPM.DecimalPlaces = 2
                    GPM.Increment = 0.01D
                Else
                    GPM.DecimalPlaces = 3
                    GPM.Increment = 0.01D
                End If
                GPM.Value = _gpm

                Dim _cfs As Decimal = CDec(Value * CubicFeetPerCubicMeter)
                If (10000.0 <= _cfs) Then
                    CFS.DecimalPlaces = 0
                    CFS.Increment = 1
                ElseIf (1000.0 <= _cfs) Then
                    CFS.DecimalPlaces = 1
                    CFS.Increment = 0.1D
                ElseIf (100.0 <= _cfs) Then
                    CFS.DecimalPlaces = 2
                    CFS.Increment = 0.01D
                Else
                    CFS.DecimalPlaces = 3
                    CFS.Increment = 0.001D
                End If
                CFS.Value = _cfs

                ' Metric values
                Dim _lpm As Decimal = CDec(Value * LitersPerCubicMeter * SecondsPerMinute)
                If (10000.0 <= _lpm) Then
                    LPM.DecimalPlaces = 0
                    LPM.Increment = 1
                ElseIf (1000.0 <= _lpm) Then
                    LPM.DecimalPlaces = 1
                    LPM.Increment = 0.1D
                ElseIf (100.0 <= _lpm) Then
                    LPM.DecimalPlaces = 2
                    LPM.Increment = 0.01D
                Else
                    LPM.DecimalPlaces = 3
                    LPM.Increment = 0.001D
                End If
                LPM.Value = _lpm

                Dim _lps As Decimal = CDec(Value * LitersPerCubicMeter)
                If (10000.0 <= _lps) Then
                    LPS.DecimalPlaces = 0
                    LPS.Increment = 1
                ElseIf (1000.0 <= _lps) Then
                    LPS.DecimalPlaces = 1
                    LPS.Increment = 0.1D
                ElseIf (100.0 <= _lps) Then
                    LPS.DecimalPlaces = 2
                    LPS.Increment = 0.01D
                Else
                    LPS.DecimalPlaces = 3
                    LPS.Increment = 0.001D
                End If
                LPS.Value = _lps

                Dim _cms As Decimal = CDec(Value)
                If (10000.0 <= _cms) Then
                    CMS.DecimalPlaces = 1
                    CMS.Increment = 0.1D
                ElseIf (1000.0 <= _cms) Then
                    CMS.DecimalPlaces = 2
                    CMS.Increment = 0.01D
                ElseIf (100.0 <= _cms) Then
                    CMS.DecimalPlaces = 3
                    CMS.Increment = 0.001D
                Else
                    CMS.DecimalPlaces = 4
                    CMS.Increment = 0.0001D
                End If
                CMS.Value = _cms

            Catch ex As Exception
                ' Set to maximums
                CMS.Value = CMS.Maximum
                LPS.Value = CDec(CMS.Maximum * LitersPerCubicMeter)
                LPM.Value = CDec(LPS.Maximum * SecondsPerMinute)

                GPM.Value = CDec(CMS.Maximum * GallonsPerCubicMeter * SecondsPerMinute)
                CFS.Value = CDec(CMS.Maximum * CubicFeetPerCubicMeter)
            Finally
                FlowRateUpdating = False
            End Try
        End Set
    End Property
    '
    ' Gallons/min
    '
    Private Sub GPM_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GPM.ValueChanged
        If Not (FlowRateUpdating) Then
            SiFlowRate = GPM.Value / GallonsPerCubicMeter / SecondsPerMinute
        End If
    End Sub

    Private Sub GPM_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GPM.LostFocus
        If Not (FlowRateUpdating) Then
            SiFlowRate = GPM.Value / GallonsPerCubicMeter / SecondsPerMinute
        End If
    End Sub
    '
    ' ft³/sec
    '
    Private Sub CFS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CFS.ValueChanged
        If Not (FlowRateUpdating) Then
            SiFlowRate = CFS.Value / CubicFeetPerCubicMeter
        End If
    End Sub

    Private Sub CFS_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CFS.LostFocus
        If Not (FlowRateUpdating) Then
            SiFlowRate = CFS.Value / CubicFeetPerCubicMeter
        End If
    End Sub
    '
    ' Liters/min
    '
    Private Sub LPM_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles LPM.ValueChanged
        If Not (FlowRateUpdating) Then
            SiFlowRate = LPM.Value / LitersPerCubicMeter / SecondsPerMinute
        End If
    End Sub

    Private Sub LPM_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles LPM.LostFocus
        If Not (FlowRateUpdating) Then
            SiFlowRate = LPM.Value / LitersPerCubicMeter / SecondsPerMinute
        End If
    End Sub
    '
    ' Liters/sec
    '
    Private Sub LPS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles LPS.ValueChanged
        If Not (FlowRateUpdating) Then
            SiFlowRate = LPS.Value / LitersPerCubicMeter
        End If
    End Sub

    Private Sub LPS_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles LPS.LostFocus
        If Not (FlowRateUpdating) Then
            SiFlowRate = LPS.Value / LitersPerCubicMeter
        End If
    End Sub
    '
    ' m³/s
    '
    Private Sub CMS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CMS.ValueChanged
        If Not (FlowRateUpdating) Then
            SiFlowRate = CMS.Value
        End If
    End Sub

    Private Sub CMS_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CMS.LostFocus
        If Not (FlowRateUpdating) Then
            SiFlowRate = CMS.Value
        End If
    End Sub

#End Region

#End Region

#Region " UI Event Handlers "

    Private Sub ConversionChart_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:UnitsConversionChart")
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:UnitsConversionChart")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub ConversionChart_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub OkayButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles OkayButton.Click
        Me.Hide()
    End Sub

#End Region

End Class
