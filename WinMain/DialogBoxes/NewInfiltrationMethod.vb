
'**********************************************************************************************
' New Infiltration Method Dialog Box
'
Imports DataStore
Imports Srfr
Imports Srfr.SrfrAPI

Public Class NewInfiltrationMethod
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal ctl As ctl_Infiltration, ByVal method As InfiltrationFunctions, _
                                                  ByVal nrcsOption As NrcsToKostiakovMethods)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeNewInfiltrationMethod(ctl, method, nrcsOption)

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
    Friend WithEvents CancelNewButton As DataStore.ctl_Button
    Friend WithEvents NrcsIntakePanel As DataStore.ctl_Panel
    Friend WithEvents Sel_400 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_300 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_090 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_200 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_150 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_100 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_080 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_070 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_060 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_050 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_045 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_040 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_035 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_030 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_025 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_020 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_015 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_010 As System.Windows.Forms.RadioButton
    Friend WithEvents Sel_005 As System.Windows.Forms.RadioButton
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents KostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents KostiakovFormula As System.Windows.Forms.Label
    Friend WithEvents ModifiedKostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents ModifiedKostiakovFormula As System.Windows.Forms.Label
    Friend WithEvents CharacteristicInfiltrationPanel As DataStore.ctl_Panel
    Friend WithEvents TimeRatedIntakePanel As DataStore.ctl_Panel
    Friend WithEvents BranchFunctionPanel As DataStore.ctl_Panel
    Friend WithEvents KostALabel As System.Windows.Forms.Label
    Friend WithEvents KostKLabel As System.Windows.Forms.Label
    Friend WithEvents KostKUpDown As ExNumericUpDown
    Friend WithEvents KostKUnits As System.Windows.Forms.Label
    Friend WithEvents KostAUpDown As ExNumericUpDown
    Friend WithEvents TrifDepth As System.Windows.Forms.Label
    Friend WithEvents TrifA As System.Windows.Forms.Label
    Friend WithEvents TrifK As System.Windows.Forms.Label
    Friend WithEvents TrifTimeUpDown As ExNumericUpDown
    Friend WithEvents TrifTimeUnits As System.Windows.Forms.Label
    Friend WithEvents KcitK As System.Windows.Forms.Label
    Friend WithEvents KcitALabel As System.Windows.Forms.Label
    Friend WithEvents KcitTimeUnits As System.Windows.Forms.Label
    Friend WithEvents KcitTimeUpDown As ExNumericUpDown
    Friend WithEvents KcitDepthUnits As System.Windows.Forms.Label
    Friend WithEvents KcitDepthUpDown As ExNumericUpDown
    Friend WithEvents KcitAUpDown As ExNumericUpDown
    Friend WithEvents MkosALabel As System.Windows.Forms.Label
    Friend WithEvents MkosKLabel As System.Windows.Forms.Label
    Friend WithEvents MkosACLabel As System.Windows.Forms.Label
    Friend WithEvents MkosABLabel As System.Windows.Forms.Label
    Friend WithEvents MkosAUpDown As ExNumericUpDown
    Friend WithEvents MkosKUnits As System.Windows.Forms.Label
    Friend WithEvents MkosKUpDown As ExNumericUpDown
    Friend WithEvents MkosBUnits As System.Windows.Forms.Label
    Friend WithEvents MkosBUpDown As ExNumericUpDown
    Friend WithEvents MkosCUnits As System.Windows.Forms.Label
    Friend WithEvents MkosCUpDown As ExNumericUpDown
    Friend WithEvents BranKLabel As System.Windows.Forms.Label
    Friend WithEvents BranBLabel As System.Windows.Forms.Label
    Friend WithEvents BranCLabel As System.Windows.Forms.Label
    Friend WithEvents BranALabel As System.Windows.Forms.Label
    Friend WithEvents BranCUnits As System.Windows.Forms.Label
    Friend WithEvents BranCUpDown As ExNumericUpDown
    Friend WithEvents BranBUnits As System.Windows.Forms.Label
    Friend WithEvents BranBUpDown As ExNumericUpDown
    Friend WithEvents BranAUpDown As ExNumericUpDown
    Friend WithEvents BranKUnits As System.Windows.Forms.Label
    Friend WithEvents BranKUpDown As ExNumericUpDown
    Friend WithEvents NrcsA As System.Windows.Forms.Label
    Friend WithEvents NrcsK As System.Windows.Forms.Label
    Friend WithEvents DisableLabel As DataStore.ctl_Label
    Friend WithEvents HelpLabel As DataStore.ctl_Label
    Friend WithEvents BranchTime As System.Windows.Forms.Label
    Friend WithEvents NrcsC As System.Windows.Forms.Label
    Friend WithEvents KITimeLabel As DataStore.ctl_Label
    Friend WithEvents KIDepthLabel As DataStore.ctl_Label
    Friend WithEvents TRTimeLabel As DataStore.ctl_Label
    Friend WithEvents TRDepthLabel As DataStore.ctl_Label
    Friend WithEvents BranchFormula1 As System.Windows.Forms.Label
    Friend WithEvents WPwarning As DataStore.ctl_Label
    Friend WithEvents BranchFormula2 As System.Windows.Forms.Label
    Friend WithEvents BranchesToLabel As DataStore.ctl_Label
    Friend WithEvents OkButton As DataStore.ctl_Button
    Friend WithEvents GreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents SoilTextureLabel As DataStore.ctl_Label
    Friend WithEvents SoilTextureControl As System.Windows.Forms.ComboBox
    Friend WithEvents GAcLabel As DataStore.ctl_Label
    Friend WithEvents GAHydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents GAPressureHeadLabel As DataStore.ctl_Label
    Friend WithEvents GAInitialWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents GAEffectivePorosityLabel As DataStore.ctl_Label
    Friend WithEvents GACUpDown As WinMain.ExNumericUpDown
    Friend WithEvents GACUnits As System.Windows.Forms.Label
    Friend WithEvents GAEffectivePorosityUnits As System.Windows.Forms.Label
    Friend WithEvents GAEffectivePorosityUpDown As WinMain.ExNumericUpDown
    Friend WithEvents GAInitialWaterContentUnits As System.Windows.Forms.Label
    Friend WithEvents GAInitialWaterContentUpDown As WinMain.ExNumericUpDown
    Friend WithEvents GAPressureHeadUnits As System.Windows.Forms.Label
    Friend WithEvents GAPressureHeadUpDown As WinMain.ExNumericUpDown
    Friend WithEvents GAHydraulicConductivityUnits As System.Windows.Forms.Label
    Friend WithEvents GAHydraulicConductivityUpDown As WinMain.ExNumericUpDown
    Friend WithEvents BranchTimeLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewInfiltrationMethod))
        Me.CancelNewButton = New DataStore.ctl_Button
        Me.NrcsIntakePanel = New DataStore.ctl_Panel
        Me.NrcsC = New System.Windows.Forms.Label
        Me.NrcsA = New System.Windows.Forms.Label
        Me.NrcsK = New System.Windows.Forms.Label
        Me.Sel_400 = New System.Windows.Forms.RadioButton
        Me.Sel_300 = New System.Windows.Forms.RadioButton
        Me.Sel_090 = New System.Windows.Forms.RadioButton
        Me.Sel_200 = New System.Windows.Forms.RadioButton
        Me.Sel_150 = New System.Windows.Forms.RadioButton
        Me.Sel_100 = New System.Windows.Forms.RadioButton
        Me.Sel_080 = New System.Windows.Forms.RadioButton
        Me.Sel_070 = New System.Windows.Forms.RadioButton
        Me.Sel_060 = New System.Windows.Forms.RadioButton
        Me.Sel_050 = New System.Windows.Forms.RadioButton
        Me.Sel_045 = New System.Windows.Forms.RadioButton
        Me.Sel_040 = New System.Windows.Forms.RadioButton
        Me.Sel_035 = New System.Windows.Forms.RadioButton
        Me.Sel_030 = New System.Windows.Forms.RadioButton
        Me.Sel_025 = New System.Windows.Forms.RadioButton
        Me.Sel_020 = New System.Windows.Forms.RadioButton
        Me.Sel_015 = New System.Windows.Forms.RadioButton
        Me.Sel_010 = New System.Windows.Forms.RadioButton
        Me.Sel_005 = New System.Windows.Forms.RadioButton
        Me.TitleLabel = New System.Windows.Forms.Label
        Me.DisableLabel = New DataStore.ctl_Label
        Me.KostiakovPanel = New DataStore.ctl_Panel
        Me.KostKUnits = New System.Windows.Forms.Label
        Me.KostiakovFormula = New System.Windows.Forms.Label
        Me.KostALabel = New System.Windows.Forms.Label
        Me.KostKLabel = New System.Windows.Forms.Label
        Me.ModifiedKostiakovPanel = New DataStore.ctl_Panel
        Me.MkosCUnits = New System.Windows.Forms.Label
        Me.MkosBUnits = New System.Windows.Forms.Label
        Me.MkosKUnits = New System.Windows.Forms.Label
        Me.ModifiedKostiakovFormula = New System.Windows.Forms.Label
        Me.MkosALabel = New System.Windows.Forms.Label
        Me.MkosKLabel = New System.Windows.Forms.Label
        Me.MkosACLabel = New System.Windows.Forms.Label
        Me.MkosABLabel = New System.Windows.Forms.Label
        Me.CharacteristicInfiltrationPanel = New DataStore.ctl_Panel
        Me.KcitDepthUnits = New System.Windows.Forms.Label
        Me.KcitTimeUnits = New System.Windows.Forms.Label
        Me.KcitK = New System.Windows.Forms.Label
        Me.KITimeLabel = New DataStore.ctl_Label
        Me.KcitALabel = New System.Windows.Forms.Label
        Me.KIDepthLabel = New DataStore.ctl_Label
        Me.TimeRatedIntakePanel = New DataStore.ctl_Panel
        Me.TrifTimeUnits = New System.Windows.Forms.Label
        Me.TrifDepth = New System.Windows.Forms.Label
        Me.TrifA = New System.Windows.Forms.Label
        Me.TrifK = New System.Windows.Forms.Label
        Me.TRTimeLabel = New DataStore.ctl_Label
        Me.TRDepthLabel = New DataStore.ctl_Label
        Me.BranchFunctionPanel = New DataStore.ctl_Panel
        Me.BranchesToLabel = New DataStore.ctl_Label
        Me.BranchFormula2 = New System.Windows.Forms.Label
        Me.BranchTime = New System.Windows.Forms.Label
        Me.BranCUnits = New System.Windows.Forms.Label
        Me.BranBUnits = New System.Windows.Forms.Label
        Me.BranKUnits = New System.Windows.Forms.Label
        Me.BranchFormula1 = New System.Windows.Forms.Label
        Me.BranKLabel = New System.Windows.Forms.Label
        Me.BranchTimeLabel = New DataStore.ctl_Label
        Me.BranBLabel = New System.Windows.Forms.Label
        Me.BranCLabel = New System.Windows.Forms.Label
        Me.BranALabel = New System.Windows.Forms.Label
        Me.OkButton = New DataStore.ctl_Button
        Me.HelpLabel = New DataStore.ctl_Label
        Me.WPwarning = New DataStore.ctl_Label
        Me.GreenAmptPanel = New DataStore.ctl_Panel
        Me.GAEffectivePorosityUnits = New System.Windows.Forms.Label
        Me.GAInitialWaterContentUnits = New System.Windows.Forms.Label
        Me.GAPressureHeadUnits = New System.Windows.Forms.Label
        Me.GAHydraulicConductivityUnits = New System.Windows.Forms.Label
        Me.GACUnits = New System.Windows.Forms.Label
        Me.GAcLabel = New DataStore.ctl_Label
        Me.GAHydraulicConductivityLabel = New DataStore.ctl_Label
        Me.GAPressureHeadLabel = New DataStore.ctl_Label
        Me.GAInitialWaterContentLabel = New DataStore.ctl_Label
        Me.GAEffectivePorosityLabel = New DataStore.ctl_Label
        Me.SoilTextureControl = New System.Windows.Forms.ComboBox
        Me.SoilTextureLabel = New DataStore.ctl_Label
        Me.GAEffectivePorosityUpDown = New WinMain.ExNumericUpDown
        Me.GAInitialWaterContentUpDown = New WinMain.ExNumericUpDown
        Me.GAPressureHeadUpDown = New WinMain.ExNumericUpDown
        Me.GAHydraulicConductivityUpDown = New WinMain.ExNumericUpDown
        Me.GACUpDown = New WinMain.ExNumericUpDown
        Me.BranCUpDown = New WinMain.ExNumericUpDown
        Me.BranBUpDown = New WinMain.ExNumericUpDown
        Me.BranAUpDown = New WinMain.ExNumericUpDown
        Me.BranKUpDown = New WinMain.ExNumericUpDown
        Me.TrifTimeUpDown = New WinMain.ExNumericUpDown
        Me.KcitAUpDown = New WinMain.ExNumericUpDown
        Me.KcitDepthUpDown = New WinMain.ExNumericUpDown
        Me.KcitTimeUpDown = New WinMain.ExNumericUpDown
        Me.MkosCUpDown = New WinMain.ExNumericUpDown
        Me.MkosBUpDown = New WinMain.ExNumericUpDown
        Me.MkosAUpDown = New WinMain.ExNumericUpDown
        Me.MkosKUpDown = New WinMain.ExNumericUpDown
        Me.KostAUpDown = New WinMain.ExNumericUpDown
        Me.KostKUpDown = New WinMain.ExNumericUpDown
        Me.NrcsIntakePanel.SuspendLayout()
        Me.KostiakovPanel.SuspendLayout()
        Me.ModifiedKostiakovPanel.SuspendLayout()
        Me.CharacteristicInfiltrationPanel.SuspendLayout()
        Me.TimeRatedIntakePanel.SuspendLayout()
        Me.BranchFunctionPanel.SuspendLayout()
        Me.GreenAmptPanel.SuspendLayout()
        CType(Me.GAEffectivePorosityUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAInitialWaterContentUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAPressureHeadUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GAHydraulicConductivityUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GACUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BranCUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BranBUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BranAUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BranKUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrifTimeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KcitAUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KcitDepthUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KcitTimeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MkosCUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MkosBUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MkosAUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MkosKUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KostAUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KostKUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelNewButton
        '
        Me.CancelNewButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelNewButton.Location = New System.Drawing.Point(294, 400)
        Me.CancelNewButton.Name = "CancelNewButton"
        Me.CancelNewButton.Size = New System.Drawing.Size(75, 24)
        Me.CancelNewButton.TabIndex = 5
        Me.CancelNewButton.Text = "&Cancel"
        '
        'NrcsIntakePanel
        '
        Me.NrcsIntakePanel.AccessibleDescription = "Thess radio buttons select the infiltration rate from an NRCS Intake Family."
        Me.NrcsIntakePanel.AccessibleName = "NRCS Intake Parameters"
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsC)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsA)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsK)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_400)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_300)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_090)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_200)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_150)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_100)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_080)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_070)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_060)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_050)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_045)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_040)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_035)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_030)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_025)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_020)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_015)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_010)
        Me.NrcsIntakePanel.Controls.Add(Me.Sel_005)
        Me.NrcsIntakePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsIntakePanel.Location = New System.Drawing.Point(9, 128)
        Me.NrcsIntakePanel.Name = "NrcsIntakePanel"
        Me.NrcsIntakePanel.Size = New System.Drawing.Size(360, 160)
        Me.NrcsIntakePanel.TabIndex = 2
        '
        'NrcsC
        '
        Me.NrcsC.AccessibleDescription = "This Kostiakov a value is selected from a table using the NRCS Family selection."
        Me.NrcsC.AccessibleName = "Kostiakov a"
        Me.NrcsC.Location = New System.Drawing.Point(280, 8)
        Me.NrcsC.Name = "NrcsC"
        Me.NrcsC.Size = New System.Drawing.Size(72, 23)
        Me.NrcsC.TabIndex = 21
        Me.NrcsC.Text = "c = "
        Me.NrcsC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsA
        '
        Me.NrcsA.AccessibleDescription = "This Kostiakov a value is selected from a table using the NRCS Family selection."
        Me.NrcsA.AccessibleName = "Kostiakov a"
        Me.NrcsA.Location = New System.Drawing.Point(184, 8)
        Me.NrcsA.Name = "NrcsA"
        Me.NrcsA.Size = New System.Drawing.Size(88, 23)
        Me.NrcsA.TabIndex = 20
        Me.NrcsA.Text = "a = "
        Me.NrcsA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsK
        '
        Me.NrcsK.AccessibleDescription = "This k value is selected from a table using the NRCS Family selection."
        Me.NrcsK.AccessibleName = "k"
        Me.NrcsK.Location = New System.Drawing.Point(16, 8)
        Me.NrcsK.Name = "NrcsK"
        Me.NrcsK.Size = New System.Drawing.Size(136, 23)
        Me.NrcsK.TabIndex = 19
        Me.NrcsK.Text = "k = "
        Me.NrcsK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Sel_400
        '
        Me.Sel_400.Location = New System.Drawing.Point(280, 136)
        Me.Sel_400.Name = "Sel_400"
        Me.Sel_400.Size = New System.Drawing.Size(64, 24)
        Me.Sel_400.TabIndex = 18
        Me.Sel_400.Text = "4.00"
        '
        'Sel_300
        '
        Me.Sel_300.Location = New System.Drawing.Point(280, 104)
        Me.Sel_300.Name = "Sel_300"
        Me.Sel_300.Size = New System.Drawing.Size(64, 24)
        Me.Sel_300.TabIndex = 17
        Me.Sel_300.Text = "3.00"
        '
        'Sel_090
        '
        Me.Sel_090.Location = New System.Drawing.Point(184, 112)
        Me.Sel_090.Name = "Sel_090"
        Me.Sel_090.Size = New System.Drawing.Size(64, 24)
        Me.Sel_090.TabIndex = 13
        Me.Sel_090.Text = "0.90"
        '
        'Sel_200
        '
        Me.Sel_200.Location = New System.Drawing.Point(280, 72)
        Me.Sel_200.Name = "Sel_200"
        Me.Sel_200.Size = New System.Drawing.Size(64, 24)
        Me.Sel_200.TabIndex = 16
        Me.Sel_200.Text = "2.00"
        '
        'Sel_150
        '
        Me.Sel_150.Location = New System.Drawing.Point(280, 40)
        Me.Sel_150.Name = "Sel_150"
        Me.Sel_150.Size = New System.Drawing.Size(64, 24)
        Me.Sel_150.TabIndex = 15
        Me.Sel_150.Text = "1.50"
        '
        'Sel_100
        '
        Me.Sel_100.Location = New System.Drawing.Point(184, 136)
        Me.Sel_100.Name = "Sel_100"
        Me.Sel_100.Size = New System.Drawing.Size(64, 24)
        Me.Sel_100.TabIndex = 14
        Me.Sel_100.Text = "1.00"
        '
        'Sel_080
        '
        Me.Sel_080.Location = New System.Drawing.Point(184, 88)
        Me.Sel_080.Name = "Sel_080"
        Me.Sel_080.Size = New System.Drawing.Size(64, 24)
        Me.Sel_080.TabIndex = 12
        Me.Sel_080.Text = "0.80"
        '
        'Sel_070
        '
        Me.Sel_070.Location = New System.Drawing.Point(184, 64)
        Me.Sel_070.Name = "Sel_070"
        Me.Sel_070.Size = New System.Drawing.Size(64, 24)
        Me.Sel_070.TabIndex = 11
        Me.Sel_070.Text = "0.70"
        '
        'Sel_060
        '
        Me.Sel_060.Location = New System.Drawing.Point(184, 40)
        Me.Sel_060.Name = "Sel_060"
        Me.Sel_060.Size = New System.Drawing.Size(64, 24)
        Me.Sel_060.TabIndex = 10
        Me.Sel_060.Text = "0.60"
        '
        'Sel_050
        '
        Me.Sel_050.Location = New System.Drawing.Point(88, 136)
        Me.Sel_050.Name = "Sel_050"
        Me.Sel_050.Size = New System.Drawing.Size(64, 24)
        Me.Sel_050.TabIndex = 9
        Me.Sel_050.Text = "0.50"
        '
        'Sel_045
        '
        Me.Sel_045.Location = New System.Drawing.Point(88, 112)
        Me.Sel_045.Name = "Sel_045"
        Me.Sel_045.Size = New System.Drawing.Size(64, 24)
        Me.Sel_045.TabIndex = 8
        Me.Sel_045.Text = "0.45"
        '
        'Sel_040
        '
        Me.Sel_040.Location = New System.Drawing.Point(88, 88)
        Me.Sel_040.Name = "Sel_040"
        Me.Sel_040.Size = New System.Drawing.Size(64, 24)
        Me.Sel_040.TabIndex = 7
        Me.Sel_040.Text = "0.40"
        '
        'Sel_035
        '
        Me.Sel_035.Location = New System.Drawing.Point(88, 64)
        Me.Sel_035.Name = "Sel_035"
        Me.Sel_035.Size = New System.Drawing.Size(64, 24)
        Me.Sel_035.TabIndex = 6
        Me.Sel_035.Text = "0.35"
        '
        'Sel_030
        '
        Me.Sel_030.Location = New System.Drawing.Point(88, 40)
        Me.Sel_030.Name = "Sel_030"
        Me.Sel_030.Size = New System.Drawing.Size(64, 24)
        Me.Sel_030.TabIndex = 5
        Me.Sel_030.Text = "0.30"
        '
        'Sel_025
        '
        Me.Sel_025.Location = New System.Drawing.Point(16, 136)
        Me.Sel_025.Name = "Sel_025"
        Me.Sel_025.Size = New System.Drawing.Size(64, 24)
        Me.Sel_025.TabIndex = 4
        Me.Sel_025.Text = "0.25"
        '
        'Sel_020
        '
        Me.Sel_020.Location = New System.Drawing.Point(16, 112)
        Me.Sel_020.Name = "Sel_020"
        Me.Sel_020.Size = New System.Drawing.Size(64, 24)
        Me.Sel_020.TabIndex = 3
        Me.Sel_020.Text = "0.20"
        '
        'Sel_015
        '
        Me.Sel_015.Location = New System.Drawing.Point(16, 88)
        Me.Sel_015.Name = "Sel_015"
        Me.Sel_015.Size = New System.Drawing.Size(64, 24)
        Me.Sel_015.TabIndex = 2
        Me.Sel_015.Text = "0.15"
        '
        'Sel_010
        '
        Me.Sel_010.Location = New System.Drawing.Point(16, 64)
        Me.Sel_010.Name = "Sel_010"
        Me.Sel_010.Size = New System.Drawing.Size(64, 24)
        Me.Sel_010.TabIndex = 1
        Me.Sel_010.Text = "0.10"
        '
        'Sel_005
        '
        Me.Sel_005.Location = New System.Drawing.Point(16, 40)
        Me.Sel_005.Name = "Sel_005"
        Me.Sel_005.Size = New System.Drawing.Size(64, 24)
        Me.Sel_005.TabIndex = 0
        Me.Sel_005.Text = "0.05"
        '
        'TitleLabel
        '
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(16, 96)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(352, 23)
        Me.TitleLabel.TabIndex = 1
        Me.TitleLabel.Text = "Infiltration Function"
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DisableLabel
        '
        Me.DisableLabel.Location = New System.Drawing.Point(8, 368)
        Me.DisableLabel.Name = "DisableLabel"
        Me.DisableLabel.Size = New System.Drawing.Size(360, 24)
        Me.DisableLabel.TabIndex = 3
        Me.DisableLabel.Text = "Disable dialog box using User Preferences' Dialogs tab."
        Me.DisableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KostiakovPanel
        '
        Me.KostiakovPanel.AccessibleDescription = "Set of parameters defining infiltration using the Kostiakov formula:  z = k(T ^ a" & _
            ")"
        Me.KostiakovPanel.AccessibleName = "Modified Kostiakov Parameters"
        Me.KostiakovPanel.Controls.Add(Me.KostAUpDown)
        Me.KostiakovPanel.Controls.Add(Me.KostKUnits)
        Me.KostiakovPanel.Controls.Add(Me.KostKUpDown)
        Me.KostiakovPanel.Controls.Add(Me.KostiakovFormula)
        Me.KostiakovPanel.Controls.Add(Me.KostALabel)
        Me.KostiakovPanel.Controls.Add(Me.KostKLabel)
        Me.KostiakovPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostiakovPanel.Location = New System.Drawing.Point(9, 128)
        Me.KostiakovPanel.Name = "KostiakovPanel"
        Me.KostiakovPanel.Size = New System.Drawing.Size(360, 160)
        Me.KostiakovPanel.TabIndex = 2
        '
        'KostKUnits
        '
        Me.KostKUnits.Location = New System.Drawing.Point(224, 48)
        Me.KostKUnits.Name = "KostKUnits"
        Me.KostKUnits.Size = New System.Drawing.Size(80, 23)
        Me.KostKUnits.TabIndex = 3
        Me.KostKUnits.Text = "Units"
        Me.KostKUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KostiakovFormula
        '
        Me.KostiakovFormula.AccessibleDescription = "Zn = k * T^a"
        Me.KostiakovFormula.AccessibleName = "Kostiakov Formula"
        Me.KostiakovFormula.Location = New System.Drawing.Point(16, 8)
        Me.KostiakovFormula.Name = "KostiakovFormula"
        Me.KostiakovFormula.Size = New System.Drawing.Size(328, 23)
        Me.KostiakovFormula.TabIndex = 0
        Me.KostiakovFormula.Text = "Zn = k * T^a"
        Me.KostiakovFormula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KostALabel
        '
        Me.KostALabel.Location = New System.Drawing.Point(120, 72)
        Me.KostALabel.Name = "KostALabel"
        Me.KostALabel.Size = New System.Drawing.Size(24, 23)
        Me.KostALabel.TabIndex = 3
        Me.KostALabel.Text = "a"
        Me.KostALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KostKLabel
        '
        Me.KostKLabel.Location = New System.Drawing.Point(120, 48)
        Me.KostKLabel.Name = "KostKLabel"
        Me.KostKLabel.Size = New System.Drawing.Size(24, 23)
        Me.KostKLabel.TabIndex = 1
        Me.KostKLabel.Text = "k"
        Me.KostKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ModifiedKostiakovPanel
        '
        Me.ModifiedKostiakovPanel.AccessibleDescription = "Set of parameters defining infiltration using the Modified Kostiakov formula:  z " & _
            "= k(T ^ a) + b(T) + c"
        Me.ModifiedKostiakovPanel.AccessibleName = "Modified Kostiakov Parameters"
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosCUnits)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosCUpDown)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosBUnits)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosBUpDown)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosAUpDown)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosKUnits)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosKUpDown)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.ModifiedKostiakovFormula)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosALabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosKLabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosACLabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosABLabel)
        Me.ModifiedKostiakovPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModifiedKostiakovPanel.Location = New System.Drawing.Point(9, 128)
        Me.ModifiedKostiakovPanel.Name = "ModifiedKostiakovPanel"
        Me.ModifiedKostiakovPanel.Size = New System.Drawing.Size(360, 160)
        Me.ModifiedKostiakovPanel.TabIndex = 2
        '
        'MkosCUnits
        '
        Me.MkosCUnits.Location = New System.Drawing.Point(208, 120)
        Me.MkosCUnits.Name = "MkosCUnits"
        Me.MkosCUnits.Size = New System.Drawing.Size(80, 23)
        Me.MkosCUnits.TabIndex = 11
        Me.MkosCUnits.Text = "mm"
        Me.MkosCUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MkosBUnits
        '
        Me.MkosBUnits.Location = New System.Drawing.Point(208, 96)
        Me.MkosBUnits.Name = "MkosBUnits"
        Me.MkosBUnits.Size = New System.Drawing.Size(80, 23)
        Me.MkosBUnits.TabIndex = 8
        Me.MkosBUnits.Text = "mm/hr"
        Me.MkosBUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MkosKUnits
        '
        Me.MkosKUnits.Location = New System.Drawing.Point(208, 48)
        Me.MkosKUnits.Name = "MkosKUnits"
        Me.MkosKUnits.Size = New System.Drawing.Size(80, 23)
        Me.MkosKUnits.TabIndex = 3
        Me.MkosKUnits.Text = "Units"
        Me.MkosKUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ModifiedKostiakovFormula
        '
        Me.ModifiedKostiakovFormula.AccessibleDescription = "Zn = k * T^a + (b * T) + c"
        Me.ModifiedKostiakovFormula.AccessibleName = "Modified Kostiakov Formula"
        Me.ModifiedKostiakovFormula.Location = New System.Drawing.Point(16, 8)
        Me.ModifiedKostiakovFormula.Name = "ModifiedKostiakovFormula"
        Me.ModifiedKostiakovFormula.Size = New System.Drawing.Size(328, 23)
        Me.ModifiedKostiakovFormula.TabIndex = 0
        Me.ModifiedKostiakovFormula.Text = "Zn = k * T^a + (b * T) + c"
        Me.ModifiedKostiakovFormula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MkosALabel
        '
        Me.MkosALabel.Location = New System.Drawing.Point(104, 72)
        Me.MkosALabel.Name = "MkosALabel"
        Me.MkosALabel.Size = New System.Drawing.Size(24, 23)
        Me.MkosALabel.TabIndex = 4
        Me.MkosALabel.Text = "a"
        Me.MkosALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MkosKLabel
        '
        Me.MkosKLabel.Location = New System.Drawing.Point(104, 48)
        Me.MkosKLabel.Name = "MkosKLabel"
        Me.MkosKLabel.Size = New System.Drawing.Size(24, 23)
        Me.MkosKLabel.TabIndex = 1
        Me.MkosKLabel.Text = "k"
        Me.MkosKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MkosACLabel
        '
        Me.MkosACLabel.Location = New System.Drawing.Point(104, 120)
        Me.MkosACLabel.Name = "MkosACLabel"
        Me.MkosACLabel.Size = New System.Drawing.Size(24, 23)
        Me.MkosACLabel.TabIndex = 9
        Me.MkosACLabel.Text = "c"
        Me.MkosACLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MkosABLabel
        '
        Me.MkosABLabel.Location = New System.Drawing.Point(104, 96)
        Me.MkosABLabel.Name = "MkosABLabel"
        Me.MkosABLabel.Size = New System.Drawing.Size(24, 23)
        Me.MkosABLabel.TabIndex = 6
        Me.MkosABLabel.Text = "b"
        Me.MkosABLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CharacteristicInfiltrationPanel
        '
        Me.CharacteristicInfiltrationPanel.AccessibleDescription = "Set of parameters defining infiltration using the Characteristic Infiltrati" & _
            "on Time method."
        Me.CharacteristicInfiltrationPanel.AccessibleName = "Characteristic Infiltration Time Parameters"
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitAUpDown)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitDepthUnits)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitDepthUpDown)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitTimeUnits)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitTimeUpDown)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitK)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KITimeLabel)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitALabel)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KIDepthLabel)
        Me.CharacteristicInfiltrationPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CharacteristicInfiltrationPanel.Location = New System.Drawing.Point(9, 128)
        Me.CharacteristicInfiltrationPanel.Name = "CharacteristicInfiltrationPanel"
        Me.CharacteristicInfiltrationPanel.Size = New System.Drawing.Size(360, 160)
        Me.CharacteristicInfiltrationPanel.TabIndex = 2
        '
        'KcitDepthUnits
        '
        Me.KcitDepthUnits.Location = New System.Drawing.Point(296, 48)
        Me.KcitDepthUnits.Name = "KcitDepthUnits"
        Me.KcitDepthUnits.Size = New System.Drawing.Size(64, 23)
        Me.KcitDepthUnits.TabIndex = 3
        Me.KcitDepthUnits.Text = "Units"
        Me.KcitDepthUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KcitTimeUnits
        '
        Me.KcitTimeUnits.Location = New System.Drawing.Point(296, 72)
        Me.KcitTimeUnits.Name = "KcitTimeUnits"
        Me.KcitTimeUnits.Size = New System.Drawing.Size(64, 23)
        Me.KcitTimeUnits.TabIndex = 6
        Me.KcitTimeUnits.Text = "Units"
        Me.KcitTimeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KcitK
        '
        Me.KcitK.AccessibleDescription = "This k value is calculated using the formula:  Zn = k * T^a"
        Me.KcitK.AccessibleName = "k"
        Me.KcitK.Location = New System.Drawing.Point(96, 8)
        Me.KcitK.Name = "KcitK"
        Me.KcitK.Size = New System.Drawing.Size(192, 23)
        Me.KcitK.TabIndex = 0
        Me.KcitK.Text = "k = "
        Me.KcitK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KITimeLabel
        '
        Me.KITimeLabel.Location = New System.Drawing.Point(16, 72)
        Me.KITimeLabel.Name = "KITimeLabel"
        Me.KITimeLabel.Size = New System.Drawing.Size(200, 23)
        Me.KITimeLabel.TabIndex = 4
        Me.KITimeLabel.Text = "Characteristic Infiltration Time"
        Me.KITimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KcitALabel
        '
        Me.KcitALabel.Location = New System.Drawing.Point(192, 96)
        Me.KcitALabel.Name = "KcitALabel"
        Me.KcitALabel.Size = New System.Drawing.Size(24, 23)
        Me.KcitALabel.TabIndex = 7
        Me.KcitALabel.Text = "a"
        Me.KcitALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KIDepthLabel
        '
        Me.KIDepthLabel.Location = New System.Drawing.Point(16, 48)
        Me.KIDepthLabel.Name = "KIDepthLabel"
        Me.KIDepthLabel.Size = New System.Drawing.Size(200, 23)
        Me.KIDepthLabel.TabIndex = 1
        Me.KIDepthLabel.Text = "Characteristic Infiltration Depth"
        Me.KIDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimeRatedIntakePanel
        '
        Me.TimeRatedIntakePanel.AccessibleDescription = resources.GetString("TimeRatedIntakePanel.AccessibleDescription")
        Me.TimeRatedIntakePanel.AccessibleName = "Time Rated Intake Parameters"
        Me.TimeRatedIntakePanel.Controls.Add(Me.TrifTimeUnits)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TrifTimeUpDown)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TrifDepth)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TrifA)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TrifK)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TRTimeLabel)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TRDepthLabel)
        Me.TimeRatedIntakePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeRatedIntakePanel.Location = New System.Drawing.Point(9, 128)
        Me.TimeRatedIntakePanel.Name = "TimeRatedIntakePanel"
        Me.TimeRatedIntakePanel.Size = New System.Drawing.Size(360, 160)
        Me.TimeRatedIntakePanel.TabIndex = 2
        '
        'TrifTimeUnits
        '
        Me.TrifTimeUnits.Location = New System.Drawing.Point(296, 72)
        Me.TrifTimeUnits.Name = "TrifTimeUnits"
        Me.TrifTimeUnits.Size = New System.Drawing.Size(56, 23)
        Me.TrifTimeUnits.TabIndex = 6
        Me.TrifTimeUnits.Text = "Units"
        Me.TrifTimeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrifDepth
        '
        Me.TrifDepth.AccessibleDescription = "This depth is fixed at 100mm (3.94in) for the Time Rated Intake Family Method."
        Me.TrifDepth.AccessibleName = "Characteristic Infiltration Depth"
        Me.TrifDepth.Location = New System.Drawing.Point(224, 48)
        Me.TrifDepth.Name = "TrifDepth"
        Me.TrifDepth.Size = New System.Drawing.Size(128, 23)
        Me.TrifDepth.TabIndex = 3
        Me.TrifDepth.Text = "100 mm"
        Me.TrifDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrifA
        '
        Me.TrifA.AccessibleDescription = "Exponent (a) in the formula:  Zn = k * (T ^ a).  Kostiakov a is calculated based " & _
            "on the Corresponding Infiltration Time (T)."
        Me.TrifA.AccessibleName = "Kostiakov a"
        Me.TrifA.Location = New System.Drawing.Point(192, 8)
        Me.TrifA.Name = "TrifA"
        Me.TrifA.Size = New System.Drawing.Size(160, 23)
        Me.TrifA.TabIndex = 1
        Me.TrifA.Text = "a = "
        Me.TrifA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrifK
        '
        Me.TrifK.AccessibleDescription = "Coefficient (k) in the formula:  Zn = k * (T ^ a).  Kostiakov k is calculated by " & _
            "WinSRFR."
        Me.TrifK.AccessibleName = "k"
        Me.TrifK.Location = New System.Drawing.Point(16, 8)
        Me.TrifK.Name = "TrifK"
        Me.TrifK.Size = New System.Drawing.Size(168, 23)
        Me.TrifK.TabIndex = 0
        Me.TrifK.Text = "k = "
        Me.TrifK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TRTimeLabel
        '
        Me.TRTimeLabel.Location = New System.Drawing.Point(16, 72)
        Me.TRTimeLabel.Name = "TRTimeLabel"
        Me.TRTimeLabel.Size = New System.Drawing.Size(200, 23)
        Me.TRTimeLabel.TabIndex = 4
        Me.TRTimeLabel.Text = "Corresponding Infiltration Time"
        Me.TRTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TRDepthLabel
        '
        Me.TRDepthLabel.Location = New System.Drawing.Point(16, 48)
        Me.TRDepthLabel.Name = "TRDepthLabel"
        Me.TRDepthLabel.Size = New System.Drawing.Size(200, 23)
        Me.TRDepthLabel.TabIndex = 2
        Me.TRDepthLabel.Text = "Characteristic Infiltration Depth"
        Me.TRDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranchFunctionPanel
        '
        Me.BranchFunctionPanel.AccessibleDescription = "Set of parameters defining infiltration using the Branch Function formula:  z = k" & _
            "(Tb ^ a) + b(T - Tb) + c"
        Me.BranchFunctionPanel.AccessibleName = "Branch Function Parameters"
        Me.BranchFunctionPanel.Controls.Add(Me.BranchesToLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BranchFormula2)
        Me.BranchFunctionPanel.Controls.Add(Me.BranchTime)
        Me.BranchFunctionPanel.Controls.Add(Me.BranCUnits)
        Me.BranchFunctionPanel.Controls.Add(Me.BranCUpDown)
        Me.BranchFunctionPanel.Controls.Add(Me.BranBUnits)
        Me.BranchFunctionPanel.Controls.Add(Me.BranBUpDown)
        Me.BranchFunctionPanel.Controls.Add(Me.BranAUpDown)
        Me.BranchFunctionPanel.Controls.Add(Me.BranKUnits)
        Me.BranchFunctionPanel.Controls.Add(Me.BranKUpDown)
        Me.BranchFunctionPanel.Controls.Add(Me.BranchFormula1)
        Me.BranchFunctionPanel.Controls.Add(Me.BranKLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BranchTimeLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BranBLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BranCLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BranALabel)
        Me.BranchFunctionPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchFunctionPanel.Location = New System.Drawing.Point(9, 128)
        Me.BranchFunctionPanel.Name = "BranchFunctionPanel"
        Me.BranchFunctionPanel.Size = New System.Drawing.Size(360, 160)
        Me.BranchFunctionPanel.TabIndex = 2
        '
        'BranchesToLabel
        '
        Me.BranchesToLabel.Location = New System.Drawing.Point(120, 8)
        Me.BranchesToLabel.Name = "BranchesToLabel"
        Me.BranchesToLabel.Size = New System.Drawing.Size(112, 23)
        Me.BranchesToLabel.TabIndex = 1
        Me.BranchesToLabel.Text = "branches to"
        Me.BranchesToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BranchFormula2
        '
        Me.BranchFormula2.AccessibleDescription = "Zn = k * T^a + c  branches to  Zn = Zb + (b * T)   at the Branch Time."
        Me.BranchFormula2.AccessibleName = "Branch Function"
        Me.BranchFormula2.Location = New System.Drawing.Point(232, 8)
        Me.BranchFormula2.Name = "BranchFormula2"
        Me.BranchFormula2.Size = New System.Drawing.Size(112, 23)
        Me.BranchFormula2.TabIndex = 2
        Me.BranchFormula2.Text = "Zn = Zb + (b * T)"
        Me.BranchFormula2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BranchTime
        '
        Me.BranchTime.Location = New System.Drawing.Point(152, 136)
        Me.BranchTime.Name = "BranchTime"
        Me.BranchTime.Size = New System.Drawing.Size(144, 23)
        Me.BranchTime.TabIndex = 15
        Me.BranchTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranCUnits
        '
        Me.BranCUnits.Location = New System.Drawing.Point(224, 88)
        Me.BranCUnits.Name = "BranCUnits"
        Me.BranCUnits.Size = New System.Drawing.Size(80, 23)
        Me.BranCUnits.TabIndex = 10
        Me.BranCUnits.Text = "mm"
        Me.BranCUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranBUnits
        '
        Me.BranBUnits.Location = New System.Drawing.Point(224, 112)
        Me.BranBUnits.Name = "BranBUnits"
        Me.BranBUnits.Size = New System.Drawing.Size(80, 23)
        Me.BranBUnits.TabIndex = 13
        Me.BranBUnits.Text = "mm/hr"
        Me.BranBUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranKUnits
        '
        Me.BranKUnits.Location = New System.Drawing.Point(224, 40)
        Me.BranKUnits.Name = "BranKUnits"
        Me.BranKUnits.Size = New System.Drawing.Size(80, 23)
        Me.BranKUnits.TabIndex = 5
        Me.BranKUnits.Text = "Units"
        Me.BranKUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranchFormula1
        '
        Me.BranchFormula1.AccessibleDescription = "Zn = k * T^a + c  branches to  Zn = Zb + (b * T)   at the Branch Time."
        Me.BranchFormula1.AccessibleName = "Branch Function"
        Me.BranchFormula1.Location = New System.Drawing.Point(16, 8)
        Me.BranchFormula1.Name = "BranchFormula1"
        Me.BranchFormula1.Size = New System.Drawing.Size(104, 23)
        Me.BranchFormula1.TabIndex = 0
        Me.BranchFormula1.Text = "Zn = k * T^a + c"
        Me.BranchFormula1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranKLabel
        '
        Me.BranKLabel.Location = New System.Drawing.Point(120, 40)
        Me.BranKLabel.Name = "BranKLabel"
        Me.BranKLabel.Size = New System.Drawing.Size(24, 23)
        Me.BranKLabel.TabIndex = 3
        Me.BranKLabel.Text = "k"
        Me.BranKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranchTimeLabel
        '
        Me.BranchTimeLabel.Location = New System.Drawing.Point(56, 136)
        Me.BranchTimeLabel.Name = "BranchTimeLabel"
        Me.BranchTimeLabel.Size = New System.Drawing.Size(88, 23)
        Me.BranchTimeLabel.TabIndex = 14
        Me.BranchTimeLabel.Text = "Branch Time"
        Me.BranchTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranBLabel
        '
        Me.BranBLabel.Location = New System.Drawing.Point(120, 112)
        Me.BranBLabel.Name = "BranBLabel"
        Me.BranBLabel.Size = New System.Drawing.Size(24, 23)
        Me.BranBLabel.TabIndex = 11
        Me.BranBLabel.Text = "b"
        Me.BranBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranCLabel
        '
        Me.BranCLabel.Location = New System.Drawing.Point(120, 88)
        Me.BranCLabel.Name = "BranCLabel"
        Me.BranCLabel.Size = New System.Drawing.Size(24, 23)
        Me.BranCLabel.TabIndex = 8
        Me.BranCLabel.Text = "c"
        Me.BranCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranALabel
        '
        Me.BranALabel.Location = New System.Drawing.Point(120, 64)
        Me.BranALabel.Name = "BranALabel"
        Me.BranALabel.Size = New System.Drawing.Size(24, 23)
        Me.BranALabel.TabIndex = 6
        Me.BranALabel.Text = "a"
        Me.BranALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OkButton
        '
        Me.OkButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OkButton.Location = New System.Drawing.Point(14, 400)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 24)
        Me.OkButton.TabIndex = 4
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = False
        '
        'HelpLabel
        '
        Me.HelpLabel.Location = New System.Drawing.Point(16, 8)
        Me.HelpLabel.Name = "HelpLabel"
        Me.HelpLabel.Size = New System.Drawing.Size(352, 80)
        Me.HelpLabel.TabIndex = 0
        Me.HelpLabel.Text = resources.GetString("HelpLabel.Text")
        '
        'WPwarning
        '
        Me.WPwarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WPwarning.Location = New System.Drawing.Point(8, 304)
        Me.WPwarning.Name = "WPwarning"
        Me.WPwarning.Size = New System.Drawing.Size(368, 56)
        Me.WPwarning.TabIndex = 7
        Me.WPwarning.Text = "This conversion does not account for Wetted Perimeter changes that may require ad" & _
            "ditional adjustments to the infiltration parameters."
        '
        'GreenAmptPanel
        '
        Me.GreenAmptPanel.Controls.Add(Me.GAEffectivePorosityUnits)
        Me.GreenAmptPanel.Controls.Add(Me.GAEffectivePorosityUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GAInitialWaterContentUnits)
        Me.GreenAmptPanel.Controls.Add(Me.GAInitialWaterContentUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GAPressureHeadUnits)
        Me.GreenAmptPanel.Controls.Add(Me.GAPressureHeadUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GAHydraulicConductivityUnits)
        Me.GreenAmptPanel.Controls.Add(Me.GAHydraulicConductivityUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GACUnits)
        Me.GreenAmptPanel.Controls.Add(Me.GACUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GAcLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GAHydraulicConductivityLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GAPressureHeadLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GAInitialWaterContentLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GAEffectivePorosityLabel)
        Me.GreenAmptPanel.Controls.Add(Me.SoilTextureControl)
        Me.GreenAmptPanel.Controls.Add(Me.SoilTextureLabel)
        Me.GreenAmptPanel.Location = New System.Drawing.Point(9, 128)
        Me.GreenAmptPanel.Name = "GreenAmptPanel"
        Me.GreenAmptPanel.Size = New System.Drawing.Size(360, 160)
        Me.GreenAmptPanel.TabIndex = 8
        '
        'GAEffectivePorosityUnits
        '
        Me.GAEffectivePorosityUnits.AutoSize = True
        Me.GAEffectivePorosityUnits.Location = New System.Drawing.Point(293, 41)
        Me.GAEffectivePorosityUnits.Name = "GAEffectivePorosityUnits"
        Me.GAEffectivePorosityUnits.Size = New System.Drawing.Size(48, 17)
        Me.GAEffectivePorosityUnits.TabIndex = 5
        Me.GAEffectivePorosityUnits.Text = "cm/cm"
        '
        'GAInitialWaterContentUnits
        '
        Me.GAInitialWaterContentUnits.AutoSize = True
        Me.GAInitialWaterContentUnits.Location = New System.Drawing.Point(293, 63)
        Me.GAInitialWaterContentUnits.Name = "GAInitialWaterContentUnits"
        Me.GAInitialWaterContentUnits.Size = New System.Drawing.Size(48, 17)
        Me.GAInitialWaterContentUnits.TabIndex = 8
        Me.GAInitialWaterContentUnits.Text = "cm/cm"
        '
        'GAPressureHeadUnits
        '
        Me.GAPressureHeadUnits.AutoSize = True
        Me.GAPressureHeadUnits.Location = New System.Drawing.Point(293, 85)
        Me.GAPressureHeadUnits.Name = "GAPressureHeadUnits"
        Me.GAPressureHeadUnits.Size = New System.Drawing.Size(26, 17)
        Me.GAPressureHeadUnits.TabIndex = 11
        Me.GAPressureHeadUnits.Text = "cm"
        '
        'GAHydraulicConductivityUnits
        '
        Me.GAHydraulicConductivityUnits.AutoSize = True
        Me.GAHydraulicConductivityUnits.Location = New System.Drawing.Point(293, 107)
        Me.GAHydraulicConductivityUnits.Name = "GAHydraulicConductivityUnits"
        Me.GAHydraulicConductivityUnits.Size = New System.Drawing.Size(43, 17)
        Me.GAHydraulicConductivityUnits.TabIndex = 15
        Me.GAHydraulicConductivityUnits.Text = "cm/hr"
        '
        'GACUnits
        '
        Me.GACUnits.AutoSize = True
        Me.GACUnits.Location = New System.Drawing.Point(293, 129)
        Me.GACUnits.Name = "GACUnits"
        Me.GACUnits.Size = New System.Drawing.Size(26, 17)
        Me.GACUnits.TabIndex = 18
        Me.GACUnits.Text = "cm"
        '
        'GAcLabel
        '
        Me.GAcLabel.Location = New System.Drawing.Point(11, 127)
        Me.GAcLabel.Name = "GAcLabel"
        Me.GAcLabel.Size = New System.Drawing.Size(205, 23)
        Me.GAcLabel.TabIndex = 16
        Me.GAcLabel.Text = "Instantaneous Infiltration"
        Me.GAcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GAHydraulicConductivityLabel
        '
        Me.GAHydraulicConductivityLabel.Location = New System.Drawing.Point(11, 105)
        Me.GAHydraulicConductivityLabel.Name = "GAHydraulicConductivityLabel"
        Me.GAHydraulicConductivityLabel.Size = New System.Drawing.Size(205, 23)
        Me.GAHydraulicConductivityLabel.TabIndex = 13
        Me.GAHydraulicConductivityLabel.Text = "Hydraulic Conductivity"
        Me.GAHydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GAPressureHeadLabel
        '
        Me.GAPressureHeadLabel.Location = New System.Drawing.Point(11, 83)
        Me.GAPressureHeadLabel.Name = "GAPressureHeadLabel"
        Me.GAPressureHeadLabel.Size = New System.Drawing.Size(205, 23)
        Me.GAPressureHeadLabel.TabIndex = 9
        Me.GAPressureHeadLabel.Text = "Wetting Front Pressure Head"
        Me.GAPressureHeadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GAInitialWaterContentLabel
        '
        Me.GAInitialWaterContentLabel.Location = New System.Drawing.Point(11, 63)
        Me.GAInitialWaterContentLabel.Name = "GAInitialWaterContentLabel"
        Me.GAInitialWaterContentLabel.Size = New System.Drawing.Size(207, 23)
        Me.GAInitialWaterContentLabel.TabIndex = 6
        Me.GAInitialWaterContentLabel.Text = "Initial Water Content"
        Me.GAInitialWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GAEffectivePorosityLabel
        '
        Me.GAEffectivePorosityLabel.Location = New System.Drawing.Point(11, 41)
        Me.GAEffectivePorosityLabel.Name = "GAEffectivePorosityLabel"
        Me.GAEffectivePorosityLabel.Size = New System.Drawing.Size(207, 23)
        Me.GAEffectivePorosityLabel.TabIndex = 3
        Me.GAEffectivePorosityLabel.Text = "Effective Porosity"
        Me.GAEffectivePorosityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SoilTextureControl
        '
        Me.SoilTextureControl.FormattingEnabled = True
        Me.SoilTextureControl.Location = New System.Drawing.Point(131, 10)
        Me.SoilTextureControl.Name = "SoilTextureControl"
        Me.SoilTextureControl.Size = New System.Drawing.Size(160, 24)
        Me.SoilTextureControl.TabIndex = 2
        '
        'SoilTextureLabel
        '
        Me.SoilTextureLabel.Location = New System.Drawing.Point(3, 13)
        Me.SoilTextureLabel.Name = "SoilTextureLabel"
        Me.SoilTextureLabel.Size = New System.Drawing.Size(125, 21)
        Me.SoilTextureLabel.TabIndex = 1
        Me.SoilTextureLabel.Text = "Soil Texture"
        Me.SoilTextureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GAEffectivePorosityUpDown
        '
        Me.GAEffectivePorosityUpDown.DecimalPlaces = 3
        Me.GAEffectivePorosityUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.GAEffectivePorosityUpDown.Location = New System.Drawing.Point(224, 40)
        Me.GAEffectivePorosityUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 196608})
        Me.GAEffectivePorosityUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.GAEffectivePorosityUpDown.Name = "GAEffectivePorosityUpDown"
        Me.GAEffectivePorosityUpDown.Size = New System.Drawing.Size(67, 23)
        Me.GAEffectivePorosityUpDown.TabIndex = 4
        Me.GAEffectivePorosityUpDown.Value = New Decimal(New Integer() {1, 0, 0, 196608})
        '
        'GAInitialWaterContentUpDown
        '
        Me.GAInitialWaterContentUpDown.DecimalPlaces = 3
        Me.GAInitialWaterContentUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.GAInitialWaterContentUpDown.Location = New System.Drawing.Point(224, 62)
        Me.GAInitialWaterContentUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 196608})
        Me.GAInitialWaterContentUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.GAInitialWaterContentUpDown.Name = "GAInitialWaterContentUpDown"
        Me.GAInitialWaterContentUpDown.Size = New System.Drawing.Size(67, 23)
        Me.GAInitialWaterContentUpDown.TabIndex = 7
        Me.GAInitialWaterContentUpDown.Value = New Decimal(New Integer() {1, 0, 0, 196608})
        '
        'GAPressureHeadUpDown
        '
        Me.GAPressureHeadUpDown.DecimalPlaces = 2
        Me.GAPressureHeadUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.GAPressureHeadUpDown.Location = New System.Drawing.Point(224, 84)
        Me.GAPressureHeadUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.GAPressureHeadUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GAPressureHeadUpDown.Name = "GAPressureHeadUpDown"
        Me.GAPressureHeadUpDown.Size = New System.Drawing.Size(67, 23)
        Me.GAPressureHeadUpDown.TabIndex = 10
        Me.GAPressureHeadUpDown.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'GAHydraulicConductivityUpDown
        '
        Me.GAHydraulicConductivityUpDown.DecimalPlaces = 2
        Me.GAHydraulicConductivityUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.GAHydraulicConductivityUpDown.Location = New System.Drawing.Point(224, 106)
        Me.GAHydraulicConductivityUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.GAHydraulicConductivityUpDown.Name = "GAHydraulicConductivityUpDown"
        Me.GAHydraulicConductivityUpDown.Size = New System.Drawing.Size(67, 23)
        Me.GAHydraulicConductivityUpDown.TabIndex = 14
        Me.GAHydraulicConductivityUpDown.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'GACUpDown
        '
        Me.GACUpDown.DecimalPlaces = 2
        Me.GACUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.GACUpDown.Location = New System.Drawing.Point(224, 128)
        Me.GACUpDown.Name = "GACUpDown"
        Me.GACUpDown.Size = New System.Drawing.Size(67, 23)
        Me.GACUpDown.TabIndex = 17
        '
        'BranCUpDown
        '
        Me.BranCUpDown.DecimalPlaces = 2
        Me.BranCUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.BranCUpDown.Location = New System.Drawing.Point(152, 88)
        Me.BranCUpDown.Name = "BranCUpDown"
        Me.BranCUpDown.Size = New System.Drawing.Size(72, 23)
        Me.BranCUpDown.TabIndex = 9
        '
        'BranBUpDown
        '
        Me.BranBUpDown.DecimalPlaces = 2
        Me.BranBUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.BranBUpDown.Location = New System.Drawing.Point(152, 112)
        Me.BranBUpDown.Name = "BranBUpDown"
        Me.BranBUpDown.Size = New System.Drawing.Size(72, 23)
        Me.BranBUpDown.TabIndex = 12
        '
        'BranAUpDown
        '
        Me.BranAUpDown.DecimalPlaces = 3
        Me.BranAUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.BranAUpDown.Location = New System.Drawing.Point(152, 64)
        Me.BranAUpDown.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.BranAUpDown.Name = "BranAUpDown"
        Me.BranAUpDown.Size = New System.Drawing.Size(72, 23)
        Me.BranAUpDown.TabIndex = 7
        '
        'BranKUpDown
        '
        Me.BranKUpDown.DecimalPlaces = 3
        Me.BranKUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.BranKUpDown.Location = New System.Drawing.Point(152, 40)
        Me.BranKUpDown.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.BranKUpDown.Name = "BranKUpDown"
        Me.BranKUpDown.Size = New System.Drawing.Size(72, 23)
        Me.BranKUpDown.TabIndex = 4
        '
        'TrifTimeUpDown
        '
        Me.TrifTimeUpDown.DecimalPlaces = 2
        Me.TrifTimeUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.TrifTimeUpDown.Location = New System.Drawing.Point(224, 72)
        Me.TrifTimeUpDown.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.TrifTimeUpDown.Name = "TrifTimeUpDown"
        Me.TrifTimeUpDown.Size = New System.Drawing.Size(72, 23)
        Me.TrifTimeUpDown.TabIndex = 5
        '
        'KcitAUpDown
        '
        Me.KcitAUpDown.DecimalPlaces = 3
        Me.KcitAUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.KcitAUpDown.Location = New System.Drawing.Point(224, 96)
        Me.KcitAUpDown.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.KcitAUpDown.Name = "KcitAUpDown"
        Me.KcitAUpDown.Size = New System.Drawing.Size(72, 23)
        Me.KcitAUpDown.TabIndex = 8
        '
        'KcitDepthUpDown
        '
        Me.KcitDepthUpDown.DecimalPlaces = 2
        Me.KcitDepthUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.KcitDepthUpDown.Location = New System.Drawing.Point(224, 48)
        Me.KcitDepthUpDown.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.KcitDepthUpDown.Name = "KcitDepthUpDown"
        Me.KcitDepthUpDown.Size = New System.Drawing.Size(72, 23)
        Me.KcitDepthUpDown.TabIndex = 2
        '
        'KcitTimeUpDown
        '
        Me.KcitTimeUpDown.DecimalPlaces = 2
        Me.KcitTimeUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.KcitTimeUpDown.Location = New System.Drawing.Point(224, 72)
        Me.KcitTimeUpDown.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.KcitTimeUpDown.Name = "KcitTimeUpDown"
        Me.KcitTimeUpDown.Size = New System.Drawing.Size(72, 23)
        Me.KcitTimeUpDown.TabIndex = 5
        '
        'MkosCUpDown
        '
        Me.MkosCUpDown.DecimalPlaces = 2
        Me.MkosCUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.MkosCUpDown.Location = New System.Drawing.Point(136, 120)
        Me.MkosCUpDown.Name = "MkosCUpDown"
        Me.MkosCUpDown.Size = New System.Drawing.Size(72, 23)
        Me.MkosCUpDown.TabIndex = 10
        '
        'MkosBUpDown
        '
        Me.MkosBUpDown.DecimalPlaces = 2
        Me.MkosBUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.MkosBUpDown.Location = New System.Drawing.Point(136, 96)
        Me.MkosBUpDown.Name = "MkosBUpDown"
        Me.MkosBUpDown.Size = New System.Drawing.Size(72, 23)
        Me.MkosBUpDown.TabIndex = 7
        '
        'MkosAUpDown
        '
        Me.MkosAUpDown.DecimalPlaces = 3
        Me.MkosAUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.MkosAUpDown.Location = New System.Drawing.Point(136, 72)
        Me.MkosAUpDown.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MkosAUpDown.Name = "MkosAUpDown"
        Me.MkosAUpDown.Size = New System.Drawing.Size(72, 23)
        Me.MkosAUpDown.TabIndex = 5
        '
        'MkosKUpDown
        '
        Me.MkosKUpDown.DecimalPlaces = 3
        Me.MkosKUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.MkosKUpDown.Location = New System.Drawing.Point(136, 48)
        Me.MkosKUpDown.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.MkosKUpDown.Name = "MkosKUpDown"
        Me.MkosKUpDown.Size = New System.Drawing.Size(72, 23)
        Me.MkosKUpDown.TabIndex = 2
        '
        'KostAUpDown
        '
        Me.KostAUpDown.DecimalPlaces = 3
        Me.KostAUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.KostAUpDown.Location = New System.Drawing.Point(152, 72)
        Me.KostAUpDown.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.KostAUpDown.Name = "KostAUpDown"
        Me.KostAUpDown.Size = New System.Drawing.Size(72, 23)
        Me.KostAUpDown.TabIndex = 5
        '
        'KostKUpDown
        '
        Me.KostKUpDown.DecimalPlaces = 3
        Me.KostKUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.KostKUpDown.Location = New System.Drawing.Point(152, 48)
        Me.KostKUpDown.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.KostKUpDown.Name = "KostKUpDown"
        Me.KostKUpDown.Size = New System.Drawing.Size(72, 23)
        Me.KostKUpDown.TabIndex = 2
        '
        'NewInfiltrationMethod
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelNewButton
        Me.ClientSize = New System.Drawing.Size(378, 431)
        Me.Controls.Add(Me.WPwarning)
        Me.Controls.Add(Me.HelpLabel)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.DisableLabel)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.CancelNewButton)
        Me.Controls.Add(Me.GreenAmptPanel)
        Me.Controls.Add(Me.BranchFunctionPanel)
        Me.Controls.Add(Me.TimeRatedIntakePanel)
        Me.Controls.Add(Me.CharacteristicInfiltrationPanel)
        Me.Controls.Add(Me.ModifiedKostiakovPanel)
        Me.Controls.Add(Me.KostiakovPanel)
        Me.Controls.Add(Me.NrcsIntakePanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewInfiltrationMethod"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Infiltration Function Editor"
        Me.NrcsIntakePanel.ResumeLayout(False)
        Me.KostiakovPanel.ResumeLayout(False)
        Me.ModifiedKostiakovPanel.ResumeLayout(False)
        Me.CharacteristicInfiltrationPanel.ResumeLayout(False)
        Me.TimeRatedIntakePanel.ResumeLayout(False)
        Me.BranchFunctionPanel.ResumeLayout(False)
        Me.GreenAmptPanel.ResumeLayout(False)
        Me.GreenAmptPanel.PerformLayout()
        CType(Me.GAEffectivePorosityUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAInitialWaterContentUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAPressureHeadUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GAHydraulicConductivityUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GACUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BranCUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BranBUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BranAUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BranKUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrifTimeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KcitAUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KcitDepthUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KcitTimeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MkosCUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MkosBUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MkosAUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MkosKUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KostAUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KostKUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Units System
    '
    Private mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    '
    ' Associated Infiltration Control
    '
    Private mInfiltrationControl As ctl_Infiltration
    '
    ' Infiltration Method & Options
    '
    Private mInfiltrationFunction As InfiltrationFunctions
    Private mNrcsOption As NrcsToKostiakovMethods

    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' Resolve constant duplications
    '
    Private Const SecondsPerHour As Double = Srfr.SecondsPerHour
    Private Const CentimetersPerMeter As Double = Srfr.CentimetersPerMeter
    Private Const InchesPerMeter As Double = Srfr.InchesPerMeter

#End Region

#Region " Properties "

#Region " Characteristic Time / Time-Rated "

    Private mInfiltrationDepth As Double = DefaultInfiltrationDepth
    Public Property InfiltrationDepth() As Double
        Get
            Return mInfiltrationDepth
        End Get
        Set(ByVal Value As Double)
            If (Value < Me.KcitDepthUpDown.Maximum) Then
                mInfiltrationDepth = Value
            Else
                mInfiltrationDepth = Me.KcitDepthUpDown.Maximum
            End If

            Me.KcitDepthUpDown.Value = CDec(mInfiltrationDepth)
        End Set
    End Property

    Private mInfiltrationDepthUnits As Units = DefaultInfiltrationDepthUnits
    Public Property InfiltrationDepthUnits() As Units
        Get
            Return mInfiltrationDepthUnits
        End Get
        Set(ByVal Value As Units)
            mInfiltrationDepthUnits = Value
            Me.KcitDepthUnits.Text = UnitsText(mInfiltrationDepthUnits)
            Me.TrifDepth.Text = UnitTextWithUnits(Depth100mm, mInfiltrationDepthUnits)

            Select Case mInfiltrationDepthUnits
                Case Units.Inches
                    Me.KcitDepthUpDown.DecimalPlaces = 2
                    Me.KcitDepthUpDown.Increment = 0.01D
                Case Else
                    Me.KcitDepthUpDown.DecimalPlaces = 0
                    Me.KcitDepthUpDown.Increment = 1D
            End Select
        End Set
    End Property

    Private mInfiltrationTime As Double = DefaultInfiltrationTime
    Public Property InfiltrationTime() As Double
        Get
            Return mInfiltrationTime
        End Get
        Set(ByVal Value As Double)
            If (Value < Me.KcitTimeUpDown.Maximum) Then
                mInfiltrationTime = Value
            Else
                mInfiltrationTime = Me.KcitTimeUpDown.Maximum
            End If

            Me.KcitTimeUpDown.Value = CDec(mInfiltrationTime)
            Me.TrifTimeUpDown.Value = CDec(mInfiltrationTime)
        End Set
    End Property

    Private mInfiltrationTimeUnits As Units = DefaultInfiltrationTimeUnits
    Public Property InfiltrationTimeUnits() As Units
        Get
            Return mInfiltrationTimeUnits
        End Get
        Set(ByVal Value As Units)
            mInfiltrationTimeUnits = Value
            Me.KcitTimeUnits.Text = UnitsText(mInfiltrationTimeUnits)
            Me.TrifTimeUnits.Text = UnitsText(mInfiltrationTimeUnits)

            Select Case mInfiltrationTimeUnits
                Case Units.Hours
                    Me.KcitTimeUpDown.DecimalPlaces = 2
                    Me.KcitTimeUpDown.Increment = 0.01D
                    Me.TrifTimeUpDown.DecimalPlaces = 2
                    Me.TrifTimeUpDown.Increment = 0.01D
                Case Else
                    Me.KcitTimeUpDown.DecimalPlaces = 0
                    Me.KcitTimeUpDown.Increment = 1D
                    Me.TrifTimeUpDown.DecimalPlaces = 0
                    Me.TrifTimeUpDown.Increment = 1D
            End Select
        End Set
    End Property

#End Region

#Region " (Modified) Kostiakov Formula / Branch Function "

    Private mKostiakovK As Double = DefaultKostiakovK
    Public Property KostiakovK() As Double
        Get
            Return mKostiakovK
        End Get
        Set(ByVal Value As Double)
            If (Value < Me.MkosKUpDown.Maximum) Then
                mKostiakovK = Value
            Else
                mKostiakovK = Me.MkosKUpDown.Maximum
            End If

            Me.KostKUpDown.Value = CDec(mKostiakovK)
            Me.MkosKUpDown.Value = CDec(mKostiakovK)
            Me.BranKUpDown.Value = CDec(mKostiakovK)
        End Set
    End Property

    Private mKostiakovKUnits As KostiakovKParameter.K_Units = DefaultKostiakovKUnits
    Public Property KostiakovKUnits() As KostiakovKParameter.K_Units
        Get
            Return mKostiakovKUnits
        End Get
        Set(ByVal Value As KostiakovKParameter.K_Units)
            mKostiakovKUnits = Value
            Me.KostKUnits.Text = KostiakovKParameter.K_UnitsText(mKostiakovKUnits)
            Me.MkosKUnits.Text = KostiakovKParameter.K_UnitsText(mKostiakovKUnits)
            Me.BranKUnits.Text = KostiakovKParameter.K_UnitsText(mKostiakovKUnits)
        End Set
    End Property

    Private mKostiakovA As Double = DefaultKostiakovA
    Public Property KostiakovA() As Double
        Get
            Return mKostiakovA
        End Get
        Set(ByVal Value As Double)
            If (Value < Me.MkosAUpDown.Minimum) Then
                mKostiakovA = Me.MkosAUpDown.Minimum
            ElseIf (Value < Me.MkosAUpDown.Maximum) Then
                mKostiakovA = Value
            Else
                mKostiakovA = Me.MkosAUpDown.Maximum
            End If

            Me.KcitAUpDown.Value = CDec(mKostiakovA)
            Me.KostAUpDown.Value = CDec(mKostiakovA)
            Me.MkosAUpDown.Value = CDec(mKostiakovA)
            Me.BranAUpDown.Value = CDec(mKostiakovA)
        End Set
    End Property

    Private mKostiakovB As Double = DefaultKostiakovB
    Public Property KostiakovB() As Double
        Get
            Return mKostiakovB
        End Get
        Set(ByVal Value As Double)
            If (Value < Me.MkosBUpDown.Maximum) Then
                mKostiakovB = Value
            Else
                mKostiakovB = Me.MkosBUpDown.Maximum
            End If

            Me.MkosBUpDown.Value = CDec(mKostiakovB)
            Me.BranBUpDown.Value = CDec(mKostiakovB)
        End Set
    End Property

    Private mKostiakovBUnits As Units = DefaultKostiakovBUnits
    Public Property KostiakovBUnits() As Units
        Get
            Return mKostiakovBUnits
        End Get
        Set(ByVal Value As Units)
            mKostiakovBUnits = Value
            Me.MkosBUnits.Text = UnitsText(mKostiakovBUnits)
            Me.BranBUnits.Text = UnitsText(mKostiakovBUnits)
        End Set
    End Property

    Private mKostiakovC As Double = DefaultKostiakovC
    Public Property KostiakovC() As Double
        Get
            Return mKostiakovC
        End Get
        Set(ByVal Value As Double)
            If (Value < Me.MkosCUpDown.Maximum) Then
                mKostiakovC = Value
            Else
                mKostiakovC = Me.MkosCUpDown.Maximum
            End If

            Me.MkosCUpDown.Value = CDec(mKostiakovC)
            Me.BranCUpDown.Value = CDec(mKostiakovC)
        End Set
    End Property

    Private mKostiakovCUnits As Units = DefaultKostiakovCUnits
    Public Property KostiakovCUnits() As Units
        Get
            Return mKostiakovCUnits
        End Get
        Set(ByVal Value As Units)
            mKostiakovCUnits = Value
            Me.MkosCUnits.Text = UnitsText(mKostiakovCUnits)
            Me.BranCUnits.Text = UnitsText(mKostiakovCUnits)
        End Set
    End Property

#End Region

#Region " NRCS Suggested "

    Private mNrcsIntakeFamily As NrcsIntakeFamilies = DefaultNrcsIntakeFamily
    Public Property NrcsIntakeFamily() As NrcsIntakeFamilies
        Get
            Return mNrcsIntakeFamily
        End Get
        Set(ByVal Value As NrcsIntakeFamilies)
            mNrcsIntakeFamily = Value
            Select Case mNrcsIntakeFamily
                Case Globals.NrcsIntakeFamilies.Family005
                    Sel_005.Checked = True
                Case Globals.NrcsIntakeFamilies.Family010
                    Sel_010.Checked = True
                Case Globals.NrcsIntakeFamilies.Family015
                    Sel_015.Checked = True
                Case Globals.NrcsIntakeFamilies.Family020
                    Sel_020.Checked = True
                Case Globals.NrcsIntakeFamilies.Family025
                    Sel_025.Checked = True
                Case Globals.NrcsIntakeFamilies.Family030
                    Sel_030.Checked = True
                Case Globals.NrcsIntakeFamilies.Family035
                    Sel_035.Checked = True
                Case Globals.NrcsIntakeFamilies.Family040
                    Sel_040.Checked = True
                Case Globals.NrcsIntakeFamilies.Family045
                    Sel_045.Checked = True
                Case Globals.NrcsIntakeFamilies.Family050
                    Sel_050.Checked = True
                Case Globals.NrcsIntakeFamilies.Family060
                    Sel_060.Checked = True
                Case Globals.NrcsIntakeFamilies.Family070
                    Sel_070.Checked = True
                Case Globals.NrcsIntakeFamilies.Family080
                    Sel_080.Checked = True
                Case Globals.NrcsIntakeFamilies.Family090
                    Sel_090.Checked = True
                Case Globals.NrcsIntakeFamilies.Family100
                    Sel_100.Checked = True
                Case Globals.NrcsIntakeFamilies.Family150
                    Sel_150.Checked = True
                Case Globals.NrcsIntakeFamilies.Family200
                    Sel_200.Checked = True
                Case Globals.NrcsIntakeFamilies.Family300
                    Sel_300.Checked = True
                Case Globals.NrcsIntakeFamilies.Family400
                    Sel_400.Checked = True
                Case Else
                    Debug.Assert(False)
            End Select
        End Set
    End Property

#End Region

#Region " Green-Ampt "

    Private mSoilTexture As Srfr.Infiltration.SoilTextures
    Public Property SoilTexture() As Srfr.Infiltration.SoilTextures
        Get
            Return mSoilTexture
        End Get
        Set(ByVal value As Srfr.Infiltration.SoilTextures)
            mSoilTexture = value
            Me.SoilTextureControl.SelectedIndex = mSoilTexture
        End Set
    End Property

    Private mGreenAmptC As Double
    Public Property GreenAmptC() As Double
        Get
            Return mGreenAmptC
        End Get
        Set(ByVal value As Double)
            If (value < Me.GACUpDown.Maximum) Then
                mGreenAmptC = value
            Else
                mGreenAmptC = Me.GACUpDown.Maximum
            End If

            Me.GACUpDown.Value = CDec(mGreenAmptC)
        End Set
    End Property

    Private mGreenCUnits As Units = DefaultKostiakovCUnits
    Public Property GreenCUnits() As Units
        Get
            Return mGreenCUnits
        End Get
        Set(ByVal Value As Units)
            mGreenCUnits = Value
            Me.GACUnits.Text = UnitsText(mGreenCUnits)
        End Set
    End Property

    Private mEffectivePorosity As Double
    Public Property EffectivePorosity() As Double
        Get
            Return mEffectivePorosity
        End Get
        Set(ByVal value As Double)
            mEffectivePorosity = value

            Me.GAEffectivePorosityUpDown.Value = CDec(mEffectivePorosity)
        End Set
    End Property

    Private mPorosityUnits As Units = DefaultPorosityUnits
    Public Property PorsosityUnits() As Units
        Get
            Return mPorosityUnits
        End Get
        Set(ByVal value As Units)
            mPorosityUnits = value
            Me.GAEffectivePorosityUnits.Text = UnitsText(mPorosityUnits)
            Me.GAInitialWaterContentUnits.Text = UnitsText(mPorosityUnits)
        End Set
    End Property

    Private mInitialWaterContent As Double
    Public Property InitialWaterContent() As Double
        Get
            Return mInitialWaterContent
        End Get
        Set(ByVal value As Double)
            mInitialWaterContent = value
        End Set
    End Property

    Private mPressureHead As Double
    Public Property PressureHead() As Double
        Get
            Return mPressureHead
        End Get
        Set(ByVal value As Double)
            mPressureHead = value
        End Set
    End Property

    Private mPressureHeadUnits As Units = DefaultPressureHeadUnits
    Public Property PressureHeadUnits() As Units
        Get
            Return mPressureHeadUnits
        End Get
        Set(ByVal value As Units)
            mPressureHeadUnits = value
            Me.GAPressureHeadUnits.Text = UnitsText(mPressureHeadUnits)
        End Set
    End Property

    Private mHydraulicConductivity As Double
    Public Property HydraulicConductivity() As Double
        Get
            Return mHydraulicConductivity
        End Get
        Set(ByVal value As Double)
            mHydraulicConductivity = value
        End Set
    End Property

    Private mHydraulicConductivityUnits As Units = DefaultHydraulicConductivityUnits
    Public Property HydraulicConductivityUnits() As Units
        Get
            Return mHydraulicConductivityUnits
        End Get
        Set(ByVal value As Units)
            mHydraulicConductivityUnits = value
            Me.GAHydraulicConductivityUnits.Text = UnitsText(mHydraulicConductivityUnits)
        End Set
    End Property

#End Region

#End Region

#Region " Initialization "

    Private Sub InitializeNewInfiltrationMethod(ByVal infiltrationControl As ctl_Infiltration, _
                                                ByVal infiltrationSelection As InfiltrationFunctions, _
                                                ByVal nrcsOption As NrcsToKostiakovMethods)

        If (infiltrationControl IsNot Nothing) Then
            mInfiltrationControl = infiltrationControl
            mInfiltrationFunction = infiltrationSelection
            mNrcsOption = nrcsOption

            Me.Text = mDictionary.ControlText(Me)
            TitleLabel.Text = InfiltrationFunctionSelections(mInfiltrationFunction).Value

            ' Hide all panels
            Me.BranchFunctionPanel.Hide()
            Me.CharacteristicInfiltrationPanel.Hide()
            Me.KostiakovPanel.Hide()
            Me.ModifiedKostiakovPanel.Hide()
            Me.NrcsIntakePanel.Hide()
            Me.TimeRatedIntakePanel.Hide()
            Me.GreenAmptPanel.Hide()

            Me.WPwarning.Show()

            ' Show only the selected one
            Select Case (mInfiltrationFunction)
                Case Globals.InfiltrationFunctions.BranchFunction
                    Me.BranchFunctionPanel.Show()
                Case Globals.InfiltrationFunctions.CharacteristicInfiltrationTime
                    Me.CharacteristicInfiltrationPanel.Show()
                Case Globals.InfiltrationFunctions.KostiakovFormula
                    Me.KostiakovPanel.Show()
                Case Globals.InfiltrationFunctions.ModifiedKostiakovFormula
                    Me.ModifiedKostiakovPanel.Show()
                Case Globals.InfiltrationFunctions.NRCSIntakeFamily
                    Me.NrcsIntakePanel.Show()
                Case Globals.InfiltrationFunctions.TimeRatedIntakeFamily
                    Me.TimeRatedIntakePanel.Show()
                Case Globals.InfiltrationFunctions.GreenAmpt
                    Me.GreenAmptPanel.Show()
                    Me.WPwarning.Hide()
                Case Globals.InfiltrationFunctions.Hydrus1D
                Case Globals.InfiltrationFunctions.WarrickGreenAmpt
                Case Else
                    Debug.Assert(False)
                    Me.NrcsIntakePanel.Show()
            End Select

            ' Load the Green-Ampt soil textures combo box
            Dim soil As Srfr.Infiltration.SoilProperties
            For Each soil In Srfr.Infiltration.SoilPropertiesTable
                Me.SoilTextureControl.Items.Add(soil.SoilTexture)
            Next
        End If

        Me.KeyPreview = True    ' Enable Form's ability to handle Key events

    End Sub

#End Region

#Region " UI Event Handlers "

#Region " Characteristic Infiltration Time "

    Private Sub UpdateCharacteristicIntakeFamily()
        ' Update Kostiakov k
        Dim Zn As Double = SiDepth(mInfiltrationDepth, mInfiltrationDepthUnits)
        Dim Tn As Double = SiTime(mInfiltrationTime, mInfiltrationTimeUnits)

        Dim a As Double = mKostiakovA
        Dim k As Double = Srfr.SrfrAPI.KostiakovK(Zn, Tn, a) ' Calc k using Kostiakov equation

        KcitK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, KostiakovKUnits, 0)
    End Sub

    Private Sub GraphCharacteristicInfiltration()
        If Not (mInfiltrationControl Is Nothing) Then
            If (mInfiltrationFunction = InfiltrationFunctions.CharacteristicInfiltrationTime) Then
                '
                ' User defined parameters:  Zn, Tn, a
                ' Calculations required:    k
                '   
                Dim Zn As Double = SiDepth(mInfiltrationDepth, mInfiltrationDepthUnits)
                Dim Tn As Double = SiTime(mInfiltrationTime, mInfiltrationTimeUnits)
                Dim a As Double = mKostiakovA
                Dim k As Double = Srfr.SrfrAPI.KostiakovK(Zn, Tn, a) ' Calc k using Kostiakov equation

                ' Compute the Matching Curve
                mInfiltrationControl.MatchingCurve = SoilCropProperties.KostiakovArrayList(k, a, 0.0, 0.0, _
                                                     mInfiltrationControl.CurveTime, _
                                                     mInfiltrationControl.Points, _
                                                     mInfiltrationControl.TimeOffsetC)
            End If
        End If
    End Sub

    Private Sub KcitDepthUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KcitDepthUpDown.ValueChanged
        ' Save the new Infiltration Depth
        mInfiltrationDepth = KcitDepthUpDown.Value
        UpdateCharacteristicIntakeFamily()
        GraphCharacteristicInfiltration()
    End Sub

    Private Sub KcitDepthUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KcitDepthUpDown.Leave
        ' Save the new Infiltration Depth
        mInfiltrationDepth = KcitDepthUpDown.Value
        UpdateCharacteristicIntakeFamily()
        GraphCharacteristicInfiltration()
    End Sub

    Private Sub KcitTimeUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KcitTimeUpDown.ValueChanged
        ' Save the new Infiltration Time
        mInfiltrationTime = KcitTimeUpDown.Value
        UpdateCharacteristicIntakeFamily()
        GraphCharacteristicInfiltration()
    End Sub

    Private Sub KcitTimeUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KcitTimeUpDown.Leave
        ' Save the new Infiltration Time
        mInfiltrationTime = KcitTimeUpDown.Value
        UpdateCharacteristicIntakeFamily()
        GraphCharacteristicInfiltration()
    End Sub

    Private Sub KcitAUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KcitAUpDown.ValueChanged
        ' Save the new Kostiakov a
        mKostiakovA = KcitAUpDown.Value
        UpdateCharacteristicIntakeFamily()
        GraphCharacteristicInfiltration()
    End Sub

    Private Sub KcitAUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KcitAUpDown.Leave
        ' Save the new Kostiakov a
        mKostiakovA = KcitAUpDown.Value
        UpdateCharacteristicIntakeFamily()
        GraphCharacteristicInfiltration()
    End Sub

#End Region

#Region " NRCS Intake Family "

    Private Sub UpdateNrcsIntakeFamily()
        '
        ' User defined parameters:   k, a, c
        '
        Dim k, a, c As Double
        Select Case (mNrcsOption)
            Case NrcsToKostiakovMethods.ApproximateByBestFit
                k = NrcsApproxValuesTable(NrcsIntakeFamily).k
                a = NrcsApproxValuesTable(NrcsIntakeFamily).a
                c = 0.0
            Case Else ' Assume NrcsToKostiakovMethods.DescribeByNrcsFormula
                k = NrcsIntakeValuesTable(NrcsIntakeFamily).k
                a = NrcsIntakeValuesTable(NrcsIntakeFamily).a
                c = Depth7mm
        End Select

        NrcsK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, KostiakovKUnits, 0)
        NrcsA.Text = "a = " + Format(a, "0.00#")
        NrcsC.Text = "c = " + DepthString(c, 0)
    End Sub

    Private Sub GraphNrcsIntakeFamily()
        If Not (mInfiltrationControl Is Nothing) Then
            If (mInfiltrationFunction = InfiltrationFunctions.NRCSIntakeFamily) Then
                '
                ' User defined parameters:   k, a, c
                '   
                Dim k, a, c As Double
                Select Case (mNrcsOption)
                    Case NrcsToKostiakovMethods.ApproximateByBestFit
                        k = NrcsApproxValuesTable(NrcsIntakeFamily).k
                        a = NrcsApproxValuesTable(NrcsIntakeFamily).a
                        c = 0.0
                    Case Else ' Assume NrcsToKostiakovMethods.DescribeByNrcsFormula
                        k = NrcsIntakeValuesTable(NrcsIntakeFamily).k
                        a = NrcsIntakeValuesTable(NrcsIntakeFamily).a
                        c = Depth7mm
                End Select

                ' Compute the Matching Curve
                mInfiltrationControl.MatchingCurve = SoilCropProperties.KostiakovArrayList(k, a, 0.0, c, _
                                                     mInfiltrationControl.CurveTime, _
                                                     mInfiltrationControl.Points, _
                                                     mInfiltrationControl.TimeOffsetC)
            End If
        End If
    End Sub

    Private Sub Sel_005_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_005.CheckedChanged
        If (Sel_005.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family005
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_010_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_010.CheckedChanged
        If (Sel_010.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family010
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_015_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_015.CheckedChanged
        If (Sel_015.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family015
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_020_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_020.CheckedChanged
        If (Sel_020.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family020
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_025_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_025.CheckedChanged
        If (Sel_025.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family025
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_030_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_030.CheckedChanged
        If (Sel_030.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family030
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_035_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_035.CheckedChanged
        If (Sel_035.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family035
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_040_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_040.CheckedChanged
        If (Sel_040.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family040
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_045_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_045.CheckedChanged
        If (Sel_045.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family045
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_050_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_050.CheckedChanged
        If (Sel_050.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family050
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_060_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_060.CheckedChanged
        If (Sel_060.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family060
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_070_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_070.CheckedChanged
        If (Sel_070.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family070
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_080_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_080.CheckedChanged
        If (Sel_080.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family080
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_090_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_090.CheckedChanged
        If (Sel_090.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family090
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_100_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_100.CheckedChanged
        If (Sel_100.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family100
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_150_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_150.CheckedChanged
        If (Sel_150.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family150
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_200_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_200.CheckedChanged
        If (Sel_200.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family200
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_300_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_300.CheckedChanged
        If (Sel_300.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family300
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

    Private Sub Sel_400_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Sel_400.CheckedChanged
        If (Sel_400.Checked) Then
            NrcsIntakeFamily = Globals.NrcsIntakeFamilies.Family400
            UpdateNrcsIntakeFamily()
            GraphNrcsIntakeFamily()
        End If
    End Sub

#End Region

#Region " Time-Rated Intake Family "

    Private Sub UpdateTimeRatedIntakeFamily()
        ' Update Kostiakov a & k
        Dim Zn As Double = Depth100mm
        Dim Tn As Double = SiTime(mInfiltrationTime, mInfiltrationTimeUnits)

        Dim a As Double = Srfr.SrfrAPI.NrcsA(Tn)
        Dim k As Double = Srfr.SrfrAPI.KostiakovK(Zn, Tn, a)

        TrifA.Text = "a = " + Format(a, "0.00#")
        TrifK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, KostiakovKUnits, 0)
    End Sub

    Private Sub GraphTimeRatedIntakeFamily()
        If Not (mInfiltrationControl Is Nothing) Then
            If (mInfiltrationFunction = InfiltrationFunctions.TimeRatedIntakeFamily) Then
                '
                ' User defined parameters:  Zn, Tn
                ' Calculations required:    a, k
                '   
                Dim Zn As Double = Depth100mm
                'Dim Zn As Double = SiDepth(mInfiltrationDepth, mInfiltrationDepthUnits)
                Dim Tn As Double = SiTime(mInfiltrationTime, mInfiltrationTimeUnits)
                Dim a As Double = Srfr.SrfrAPI.NrcsA(Tn) ' Calc A using SCS empirical formula
                Dim k As Double = Srfr.SrfrAPI.KostiakovK(Zn, Tn, a) ' Calc k using Kostiakov equation

                'Dim Tn As Double = CalcKostiakovTn(Zn, _siNrcsK, _nrcsA)

                ' Compute the Matching Curve
                mInfiltrationControl.MatchingCurve = SoilCropProperties.KostiakovArrayList(k, a, 0.0, 0.0, _
                                                     mInfiltrationControl.CurveTime, _
                                                     mInfiltrationControl.Points, _
                                                     mInfiltrationControl.TimeOffsetC)
            End If
        End If
    End Sub

    Private Sub TrifTimeUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TrifTimeUpDown.ValueChanged
        ' Save the new Infiltration Time
        mInfiltrationTime = TrifTimeUpDown.Value
        UpdateTimeRatedIntakeFamily()
        GraphTimeRatedIntakeFamily()
    End Sub

    Private Sub TrifTimeUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TrifTimeUpDown.Leave
        ' Save the new Infiltration Time
        mInfiltrationTime = TrifTimeUpDown.Value
        UpdateTimeRatedIntakeFamily()
        GraphTimeRatedIntakeFamily()
    End Sub

#End Region

#Region " Kostiakov Formula "

    Private Sub GraphKostiakovFormula()
        If Not (mInfiltrationControl Is Nothing) Then
            If (mInfiltrationFunction = InfiltrationFunctions.KostiakovFormula) Then
                '
                ' User defined parameters:  k, a (b & c assumed to be 0.0)
                '
                Dim k As Double = KostiakovKParameter.SiKostiakovK(mKostiakovK, mKostiakovA, mKostiakovKUnits)
                Dim a As Double = mKostiakovA

                ' Compute the Matching Curve
                mInfiltrationControl.MatchingCurve = SoilCropProperties.KostiakovArrayList(k, a, 0.0, 0.0, _
                                                     mInfiltrationControl.CurveTime, _
                                                     mInfiltrationControl.Points, _
                                                     mInfiltrationControl.TimeOffsetC)
            End If
        End If
    End Sub

    Private Sub KostKUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KostKUpDown.ValueChanged
        ' Save the new Kostiakov k
        mKostiakovK = KostKUpDown.Value
        GraphKostiakovFormula()
    End Sub

    Private Sub KostKUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KostKUpDown.Leave
        ' Save the new Kostiakov k
        mKostiakovK = KostKUpDown.Value
        GraphKostiakovFormula()
    End Sub

    Private Sub KostAUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KostAUpDown.ValueChanged
        ' Save the new Kostiakov a
        mKostiakovA = KostAUpDown.Value
        GraphKostiakovFormula()
    End Sub

    Private Sub KostAUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KostAUpDown.Leave
        ' Save the new Kostiakov a
        mKostiakovA = KostAUpDown.Value
        GraphKostiakovFormula()
    End Sub

#End Region

#Region " Modified Kostiakov Formula "

    Private Sub GraphModifiedKostiakov()
        If Not (mInfiltrationControl Is Nothing) Then
            If (mInfiltrationFunction = InfiltrationFunctions.ModifiedKostiakovFormula) Then
                '
                ' Zn = k * (Tn^a)
                '
                ' User defined parameters:  Zn, k, a, b & c 
                ' Calculations required:    Tn
                '
                Dim k As Double = KostiakovKParameter.SiKostiakovK(mKostiakovK, mKostiakovA, mKostiakovKUnits)
                Dim a As Double = mKostiakovA
                Dim b As Double = SiVelocity(mKostiakovB, mKostiakovBUnits)
                Dim c As Double = SiDepth(mKostiakovC, mKostiakovCUnits)

                ' Compute the Matching Curve
                mInfiltrationControl.MatchingCurve = SoilCropProperties.KostiakovArrayList(k, a, b, c, _
                                                     mInfiltrationControl.CurveTime, _
                                                     mInfiltrationControl.Points, _
                                                     mInfiltrationControl.TimeOffsetC)
            End If
        End If
    End Sub

    Private Sub MkosKUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MkosKUpDown.ValueChanged
        ' Save the new Kostiakov k
        mKostiakovK = MkosKUpDown.Value
        GraphModifiedKostiakov()
    End Sub

    Private Sub MkosKUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MkosKUpDown.Leave
        ' Save the new Kostiakov k
        mKostiakovK = MkosKUpDown.Value
        GraphModifiedKostiakov()
    End Sub

    Private Sub MkosAUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MkosAUpDown.ValueChanged
        ' Save the new Kostiakov a
        mKostiakovA = MkosAUpDown.Value
        GraphModifiedKostiakov()
    End Sub

    Private Sub MkosAUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MkosAUpDown.Leave
        ' Save the new Kostiakov a
        mKostiakovA = MkosAUpDown.Value
        GraphModifiedKostiakov()
    End Sub

    Private Sub MkosBUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MkosBUpDown.ValueChanged
        ' Save the new Kostiakov b
        mKostiakovB = MkosBUpDown.Value
        GraphModifiedKostiakov()
    End Sub

    Private Sub MkosBUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MkosBUpDown.Leave
        ' Save the new Kostiakov b
        mKostiakovB = MkosBUpDown.Value
        GraphModifiedKostiakov()
    End Sub

    Private Sub MkosCUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MkosCUpDown.ValueChanged
        ' Save the new Kostiakov c
        mKostiakovC = MkosCUpDown.Value
        GraphModifiedKostiakov()
    End Sub

    Private Sub MkosCUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MkosCUpDown.Leave
        ' Save the new Kostiakov c
        mKostiakovC = MkosCUpDown.Value
        GraphModifiedKostiakov()
    End Sub

#End Region

#Region " Branch Formula "

    Private Sub GraphBranchFunction()
        If Not (mInfiltrationControl Is Nothing) Then
            If (mInfiltrationFunction = InfiltrationFunctions.BranchFunction) Then
                '
                ' User defined parameters:  Zn, Kostiakov k, a, c & Branch b, Time
                ' Calculations required:    Tn
                '
                Dim k As Double = KostiakovKParameter.SiKostiakovK(mKostiakovK, mKostiakovA, mKostiakovKUnits)
                Dim a As Double = mKostiakovA
                Dim b As Double = SiVelocity(mKostiakovB, mKostiakovBUnits)
                Dim c As Double = SiDepth(mKostiakovC, mKostiakovCUnits)

                Dim Tb As Double = Srfr.SrfrAPI.BranchTime(k, a, b)

                BranchTime.Text = TimeString(Tb, 0)

                ' Compute the Matching Curve
                mInfiltrationControl.MatchingCurve = SoilCropProperties.BranchArrayList(k, a, b, c, _
                                                     mInfiltrationControl.CurveTime, Tb, _
                                                     mInfiltrationControl.Points, _
                                                     mInfiltrationControl.TimeOffsetC)
            End If
        End If
    End Sub

    Private Sub BranKUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BranKUpDown.ValueChanged
        ' Save the new Kostiakov k
        mKostiakovK = BranKUpDown.Value
        GraphBranchFunction()
    End Sub

    Private Sub BranKUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BranKUpDown.Leave
        ' Save the new Kostiakov k
        mKostiakovK = BranKUpDown.Value
        GraphBranchFunction()
    End Sub

    Private Sub BranAUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BranAUpDown.ValueChanged
        ' Save the new Kostiakov a
        mKostiakovA = BranAUpDown.Value
        GraphBranchFunction()
    End Sub

    Private Sub BranAUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BranAUpDown.Leave
        ' Save the new Kostiakov a
        mKostiakovA = BranAUpDown.Value
        GraphBranchFunction()
    End Sub

    Private Sub BranBUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BranBUpDown.ValueChanged
        ' Save the new Kostiakov b
        mKostiakovB = BranBUpDown.Value
        GraphBranchFunction()
    End Sub

    Private Sub BranBUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BranBUpDown.Leave
        ' Save the new Kostiakov b
        mKostiakovB = BranBUpDown.Value
        GraphBranchFunction()
    End Sub

    Private Sub BranCUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BranCUpDown.ValueChanged
        ' Save the new Kostiakov c
        mKostiakovC = BranCUpDown.Value
        GraphBranchFunction()
    End Sub

    Private Sub BranCUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BranCUpDown.Leave
        ' Save the new Kostiakov c
        mKostiakovC = BranCUpDown.Value
        GraphBranchFunction()
    End Sub

#End Region

#Region " Green-Ampt "

    Private Sub UpdateGreenAmpt()
        ' Update Green-Ampt values
        Dim soil As Srfr.Infiltration.SoilProperties = Srfr.Infiltration.SoilPropertiesTable(Me.SoilTexture)

        ' First, get values in Metric
        Me.GAEffectivePorosityUpDown.Value = soil.EffectivePorosity
        Me.GAInitialWaterContentUpDown.Value = soil.InitialWaterContent

        Me.GAPressureHeadUpDown.Value = soil.WettingFrontPressureHead * CentimetersPerMeter
        Me.GAHydraulicConductivityUpDown.Value = soil.HydraulicConductivity * CentimetersPerMeter * SecondsPerHour

        ' Convert to English, if necessary
        If (mUnitsSystem.UnitSystem = UnitSystems.English) Then
            Me.GAPressureHeadUpDown.Value = soil.WettingFrontPressureHead * InchesPerMeter
            Me.GAHydraulicConductivityUpDown.Value = soil.HydraulicConductivity * InchesPerMeter * SecondsPerHour
        End If

    End Sub

    Private Sub GraphGreenAmpt()
        If Not (mInfiltrationControl Is Nothing) Then
            If (mInfiltrationFunction = InfiltrationFunctions.GreenAmpt) Then

                Dim Phi As Double = mEffectivePorosity
                Dim Theta0 As Double = mInitialWaterContent

                Dim hf As Double = mPressureHead / CentimetersPerMeter
                Dim Ks As Double = mHydraulicConductivity / CentimetersPerMeter / SecondsPerHour
                Dim c As Double = mGreenAmptC / CentimetersPerMeter

                If (mUnitsSystem.UnitSystem = UnitSystems.English) Then
                    hf = mPressureHead / InchesPerMeter
                    Ks = mHydraulicConductivity / InchesPerMeter / SecondsPerHour
                    c = mGreenAmptC / InchesPerMeter
                End If

                Dim SWD As Double = Phi - Theta0                    ' soil water deficit
                Dim h0 As Double = 0.075                            ' fix water depth at 75 mm

                ' Compute the Matching Curve
                mInfiltrationControl.MatchingCurve = SoilCropProperties.GreenAmptArrayList(SWD, h0, hf, Ks, c, _
                                                     mInfiltrationControl.CurveTime, _
                                                     mInfiltrationControl.Points)
            End If
        End If
    End Sub

    Private Sub SoilTextureControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SoilTextureControl.SelectedIndexChanged
        Me.SoilTexture = Me.SoilTextureControl.SelectedIndex
        UpdateGreenAmpt()
        GraphGreenAmpt()
    End Sub

    Private Sub GACUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GACUpDown.ValueChanged
        mGreenAmptC = Me.GACUpDown.Value
        GraphGreenAmpt()
    End Sub

    Private Sub GACUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GACUpDown.Leave
        mGreenAmptC = Me.GACUpDown.Value
        GraphGreenAmpt()
    End Sub

    Private Sub GAPorosityUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GAEffectivePorosityUpDown.ValueChanged
        mEffectivePorosity = Me.GAEffectivePorosityUpDown.Value
        GraphGreenAmpt()
    End Sub

    Private Sub GAPorosityUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GAEffectivePorosityUpDown.Leave
        mEffectivePorosity = Me.GAEffectivePorosityUpDown.Value
        GraphGreenAmpt()
    End Sub

    Private Sub GAWaterContentUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GAInitialWaterContentUpDown.ValueChanged
        mInitialWaterContent = Me.GAInitialWaterContentUpDown.Value
        GraphGreenAmpt()
    End Sub

    Private Sub GAWaterContentUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GAInitialWaterContentUpDown.Leave
        mInitialWaterContent = Me.GAInitialWaterContentUpDown.Value
        GraphGreenAmpt()
    End Sub

    Private Sub GAAirEntryPressureUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GAPressureHeadUpDown.ValueChanged
        mPressureHead = Me.GAPressureHeadUpDown.Value
        GraphGreenAmpt()
    End Sub

    Private Sub GAAirEntryPressureUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GAPressureHeadUpDown.Leave
        mPressureHead = Me.GAPressureHeadUpDown.Value
        GraphGreenAmpt()
    End Sub

    Private Sub GAHydraulicConductivityUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GAHydraulicConductivityUpDown.ValueChanged
        mHydraulicConductivity = Me.GAHydraulicConductivityUpDown.Value
        GraphGreenAmpt()
    End Sub

    Private Sub GAHydraulicConductivityUpDown_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GAHydraulicConductivityUpDown.Leave
        mHydraulicConductivity = Me.GAHydraulicConductivityUpDown.Value
        GraphGreenAmpt()
    End Sub

#End Region

#Region " Buttons "

    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click
        ' Set OK result & close the dialog box
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub NewInfiltrationMethod_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        Help.ShowHelp(Me, WinSRFR.HelpFilePath, HelpNavigator.KeywordIndex, "Infiltration Formula Matching")
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        If (e.KeyCode = Keys.F1) Then
            Help.ShowHelp(Me, WinSRFR.HelpFilePath, HelpNavigator.KeywordIndex, "Infiltration Formula Matching")
        End If
    End Sub

#End Region

#End Region

End Class
