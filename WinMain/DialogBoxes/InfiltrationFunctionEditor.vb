
'*************************************************************************************************************
' Class InfiltrationFunctionEditor - Infiltration Function Editor Dialog Box
'*************************************************************************************************************
Imports DataStore
Imports Srfr

Public Class InfiltrationFunctionEditor
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal MatchType As MatchTypes)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mMatchType = MatchType

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
    Friend WithEvents KostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents ModifiedKostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents ModifiedKostiakovFormula As System.Windows.Forms.Label
    Friend WithEvents CharacteristicInfiltrationPanel As DataStore.ctl_Panel
    Friend WithEvents TimeRatedIntakePanel As DataStore.ctl_Panel
    Friend WithEvents BranchFunctionPanel As DataStore.ctl_Panel
    Friend WithEvents TrifDepth As System.Windows.Forms.Label
    Friend WithEvents TrifA As System.Windows.Forms.Label
    Friend WithEvents TrifK As System.Windows.Forms.Label
    Friend WithEvents KcitALabel As System.Windows.Forms.Label
    Friend WithEvents MkosALabel As System.Windows.Forms.Label
    Friend WithEvents MkosKLabel As System.Windows.Forms.Label
    Friend WithEvents MkosACLabel As System.Windows.Forms.Label
    Friend WithEvents MkosABLabel As System.Windows.Forms.Label
    Friend WithEvents BranKLabel As System.Windows.Forms.Label
    Friend WithEvents BranBLabel As System.Windows.Forms.Label
    Friend WithEvents BranCLabel As System.Windows.Forms.Label
    Friend WithEvents BranALabel As System.Windows.Forms.Label
    Friend WithEvents HelpText As DataStore.ctl_Label
    Friend WithEvents KITimeLabel As DataStore.ctl_Label
    Friend WithEvents KIDepthLabel As DataStore.ctl_Label
    Friend WithEvents TRTimeLabel As DataStore.ctl_Label
    Friend WithEvents TRDepthLabel As DataStore.ctl_Label
    Friend WithEvents SaveButton As DataStore.ctl_Button
    Friend WithEvents GreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents GAcLabel As DataStore.ctl_Label
    Friend WithEvents GAHydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents GAPressureHeadLabel As DataStore.ctl_Label
    Friend WithEvents GAInitialWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents GAEffectivePorosityLabel As DataStore.ctl_Label
    Friend WithEvents MkosKUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents ColHeaderMK As DataStore.ctl_Label
    Friend WithEvents ColumnHeadersKF As DataStore.ctl_Label
    Friend WithEvents MkosAUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents MkosCUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents BranCUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents BranAUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents BranKUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents BranBUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents BranColHeaders As DataStore.ctl_Label
    Friend WithEvents KcitAUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents KcitTimeUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents KcitDepthUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents TrifTimeUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents GaEffectivePorosityUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents GaInitialWaterContentUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents GaColHeaders As DataStore.ctl_Label
    Friend WithEvents GaHydraulicConductivityUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents GaPressureHeadUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents GaCUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents WarrickGreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents WgaCUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents WgaHydraulicConductivityUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents WgaPressureHeadUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents WgaInitialWaterContentUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents WgaColHeaders As DataStore.ctl_Label
    Friend WithEvents WgaSaturatedWaterContentUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents WgacLabel As DataStore.ctl_Label
    Friend WithEvents WgaHydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents WgaPressureHeadLabel As DataStore.ctl_Label
    Friend WithEvents WgaInitialWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents WgaSatWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents InfiltrationGraph As WinMain.grf_XYGraph
    Friend WithEvents WettedPerimeterControl As DataStore.ctl_SelectParameter
    Friend WithEvents InfiltrationEquationControl As DataStore.ctl_SelectParameter
    Friend WithEvents WettedPerimeterLabel As DataStore.ctl_Label
    Friend WithEvents InfiltrationEquationLabel As DataStore.ctl_Label
    Friend WithEvents NrcsIntakePanel As DataStore.ctl_Panel
    Friend WithEvents NrcsC As System.Windows.Forms.Label
    Friend WithEvents NrcsA As System.Windows.Forms.Label
    Friend WithEvents NrcsK As System.Windows.Forms.Label
    Friend WithEvents NrcsFamily400Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily300Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily090Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily200Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily150Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily100Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily080Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily070Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily060Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily050Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily045Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily040Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily035Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily030Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily025Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily020Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily015Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily010Button As DataStore.ctl_RadioButton
    Friend WithEvents NrcsFamily005Button As DataStore.ctl_RadioButton
    Friend WithEvents KostiakovFormula As System.Windows.Forms.Label
    Friend WithEvents KostAUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents KostKUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents KostALabel As System.Windows.Forms.Label
    Friend WithEvents KostKLabel As System.Windows.Forms.Label
    Friend WithEvents KcitK As System.Windows.Forms.Label
    Friend WithEvents MatchButton As DataStore.ctl_Button
    Friend WithEvents HydrusPanel As DataStore.ctl_Panel
    Friend WithEvents HydrusNotSupportedLabel As DataStore.ctl_Label
    Friend WithEvents BranchTime As DataStore.ctl_Label
    Friend WithEvents BranchTimeUpDown As DataStore.ctl_DoubleIncDecParameter
    Friend WithEvents BranchTimeEnable As DataStore.ctl_CheckParameter
    Friend WithEvents MkosBUpDown As DataStore.ctl_DoubleIncDecParameter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfiltrationFunctionEditor))
        Me.CancelNewButton = New DataStore.ctl_Button
        Me.KostiakovPanel = New DataStore.ctl_Panel
        Me.KostiakovFormula = New System.Windows.Forms.Label
        Me.KostAUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.KostKUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.KostALabel = New System.Windows.Forms.Label
        Me.KostKLabel = New System.Windows.Forms.Label
        Me.ColumnHeadersKF = New DataStore.ctl_Label
        Me.ModifiedKostiakovPanel = New DataStore.ctl_Panel
        Me.MkosCUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.MkosBUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.MkosAUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.ColHeaderMK = New DataStore.ctl_Label
        Me.MkosKUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.ModifiedKostiakovFormula = New System.Windows.Forms.Label
        Me.MkosALabel = New System.Windows.Forms.Label
        Me.MkosKLabel = New System.Windows.Forms.Label
        Me.MkosACLabel = New System.Windows.Forms.Label
        Me.MkosABLabel = New System.Windows.Forms.Label
        Me.CharacteristicInfiltrationPanel = New DataStore.ctl_Panel
        Me.KcitDepthUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.KcitTimeUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.KcitAUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.KcitK = New System.Windows.Forms.Label
        Me.KITimeLabel = New DataStore.ctl_Label
        Me.KcitALabel = New System.Windows.Forms.Label
        Me.KIDepthLabel = New DataStore.ctl_Label
        Me.TimeRatedIntakePanel = New DataStore.ctl_Panel
        Me.TrifTimeUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.TrifDepth = New System.Windows.Forms.Label
        Me.TrifA = New System.Windows.Forms.Label
        Me.TrifK = New System.Windows.Forms.Label
        Me.TRTimeLabel = New DataStore.ctl_Label
        Me.TRDepthLabel = New DataStore.ctl_Label
        Me.BranchFunctionPanel = New DataStore.ctl_Panel
        Me.BranchTimeEnable = New DataStore.ctl_CheckParameter
        Me.BranchTimeUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.BranchTime = New DataStore.ctl_Label
        Me.BranCUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.BranAUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.BranKUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.BranBUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.BranColHeaders = New DataStore.ctl_Label
        Me.BranKLabel = New System.Windows.Forms.Label
        Me.BranBLabel = New System.Windows.Forms.Label
        Me.BranCLabel = New System.Windows.Forms.Label
        Me.BranALabel = New System.Windows.Forms.Label
        Me.SaveButton = New DataStore.ctl_Button
        Me.HelpText = New DataStore.ctl_Label
        Me.GreenAmptPanel = New DataStore.ctl_Panel
        Me.GaCUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.GaHydraulicConductivityUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.GaPressureHeadUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.GaInitialWaterContentUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.GaColHeaders = New DataStore.ctl_Label
        Me.GaEffectivePorosityUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.GAcLabel = New DataStore.ctl_Label
        Me.GAHydraulicConductivityLabel = New DataStore.ctl_Label
        Me.GAPressureHeadLabel = New DataStore.ctl_Label
        Me.GAInitialWaterContentLabel = New DataStore.ctl_Label
        Me.GAEffectivePorosityLabel = New DataStore.ctl_Label
        Me.WarrickGreenAmptPanel = New DataStore.ctl_Panel
        Me.WgaCUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.WgaHydraulicConductivityUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.WgaPressureHeadUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.WgaInitialWaterContentUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.WgaColHeaders = New DataStore.ctl_Label
        Me.WgaSaturatedWaterContentUpDown = New DataStore.ctl_DoubleIncDecParameter
        Me.WgacLabel = New DataStore.ctl_Label
        Me.WgaHydraulicConductivityLabel = New DataStore.ctl_Label
        Me.WgaPressureHeadLabel = New DataStore.ctl_Label
        Me.WgaInitialWaterContentLabel = New DataStore.ctl_Label
        Me.WgaSatWaterContentLabel = New DataStore.ctl_Label
        Me.WettedPerimeterControl = New DataStore.ctl_SelectParameter
        Me.InfiltrationEquationControl = New DataStore.ctl_SelectParameter
        Me.WettedPerimeterLabel = New DataStore.ctl_Label
        Me.InfiltrationEquationLabel = New DataStore.ctl_Label
        Me.NrcsIntakePanel = New DataStore.ctl_Panel
        Me.NrcsC = New System.Windows.Forms.Label
        Me.NrcsA = New System.Windows.Forms.Label
        Me.NrcsK = New System.Windows.Forms.Label
        Me.NrcsFamily400Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily300Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily090Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily200Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily150Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily100Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily080Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily070Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily060Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily050Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily045Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily040Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily035Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily030Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily025Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily020Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily015Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily010Button = New DataStore.ctl_RadioButton
        Me.NrcsFamily005Button = New DataStore.ctl_RadioButton
        Me.MatchButton = New DataStore.ctl_Button
        Me.HydrusPanel = New DataStore.ctl_Panel
        Me.HydrusNotSupportedLabel = New DataStore.ctl_Label
        Me.InfiltrationGraph = New WinMain.grf_XYGraph
        Me.KostiakovPanel.SuspendLayout()
        Me.ModifiedKostiakovPanel.SuspendLayout()
        Me.CharacteristicInfiltrationPanel.SuspendLayout()
        Me.TimeRatedIntakePanel.SuspendLayout()
        Me.BranchFunctionPanel.SuspendLayout()
        Me.GreenAmptPanel.SuspendLayout()
        Me.WarrickGreenAmptPanel.SuspendLayout()
        Me.NrcsIntakePanel.SuspendLayout()
        Me.HydrusPanel.SuspendLayout()
        CType(Me.InfiltrationGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelNewButton
        '
        Me.CancelNewButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelNewButton.Location = New System.Drawing.Point(384, 535)
        Me.CancelNewButton.Name = "CancelNewButton"
        Me.CancelNewButton.Size = New System.Drawing.Size(75, 24)
        Me.CancelNewButton.TabIndex = 22
        Me.CancelNewButton.Text = "&Cancel"
        '
        'KostiakovPanel
        '
        Me.KostiakovPanel.AccessibleDescription = "Parameters defining infiltration using the Kostiakov formula:  z = k(T ^ a)"
        Me.KostiakovPanel.AccessibleName = "Kostiakov Parameters"
        Me.KostiakovPanel.Controls.Add(Me.KostiakovFormula)
        Me.KostiakovPanel.Controls.Add(Me.KostAUpDown)
        Me.KostiakovPanel.Controls.Add(Me.KostKUpDown)
        Me.KostiakovPanel.Controls.Add(Me.KostALabel)
        Me.KostiakovPanel.Controls.Add(Me.KostKLabel)
        Me.KostiakovPanel.Controls.Add(Me.ColumnHeadersKF)
        Me.KostiakovPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostiakovPanel.Location = New System.Drawing.Point(9, 373)
        Me.KostiakovPanel.Name = "KostiakovPanel"
        Me.KostiakovPanel.Size = New System.Drawing.Size(450, 160)
        Me.KostiakovPanel.TabIndex = 6
        '
        'KostiakovFormula
        '
        Me.KostiakovFormula.AccessibleDescription = "Zn = k * T^a"
        Me.KostiakovFormula.AccessibleName = "Kostiakov Formula"
        Me.KostiakovFormula.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostiakovFormula.Location = New System.Drawing.Point(75, 10)
        Me.KostiakovFormula.Name = "KostiakovFormula"
        Me.KostiakovFormula.Size = New System.Drawing.Size(282, 23)
        Me.KostiakovFormula.TabIndex = 0
        Me.KostiakovFormula.Text = "Zn = k * T^a"
        Me.KostiakovFormula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KostAUpDown
        '
        Me.KostAUpDown.DisplayUnits = "None"
        Me.KostAUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostAUpDown.IncDecPlaces = 0
        Me.KostAUpDown.Location = New System.Drawing.Point(136, 80)
        Me.KostAUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.KostAUpDown.Name = "KostAUpDown"
        Me.KostAUpDown.PropName = "KF a"
        Me.KostAUpDown.Size = New System.Drawing.Size(220, 24)
        Me.KostAUpDown.TabIndex = 5
        Me.KostAUpDown.UpDownValue = 0
        '
        'KostKUpDown
        '
        Me.KostKUpDown.DisplayUnits = "None"
        Me.KostKUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostKUpDown.IncDecPlaces = 0
        Me.KostKUpDown.Location = New System.Drawing.Point(136, 56)
        Me.KostKUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.KostKUpDown.Name = "KostKUpDown"
        Me.KostKUpDown.PropName = "KF k"
        Me.KostKUpDown.Size = New System.Drawing.Size(220, 24)
        Me.KostKUpDown.TabIndex = 3
        Me.KostKUpDown.UpDownValue = 0
        '
        'KostALabel
        '
        Me.KostALabel.Location = New System.Drawing.Point(111, 78)
        Me.KostALabel.Name = "KostALabel"
        Me.KostALabel.Size = New System.Drawing.Size(24, 23)
        Me.KostALabel.TabIndex = 4
        Me.KostALabel.Text = "a"
        Me.KostALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KostKLabel
        '
        Me.KostKLabel.Location = New System.Drawing.Point(111, 54)
        Me.KostKLabel.Name = "KostKLabel"
        Me.KostKLabel.Size = New System.Drawing.Size(24, 23)
        Me.KostKLabel.TabIndex = 2
        Me.KostKLabel.Text = "k"
        Me.KostKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ColumnHeadersKF
        '
        Me.ColumnHeadersKF.Location = New System.Drawing.Point(136, 32)
        Me.ColumnHeadersKF.Name = "ColumnHeadersKF"
        Me.ColumnHeadersKF.Size = New System.Drawing.Size(220, 24)
        Me.ColumnHeadersKF.TabIndex = 1
        Me.ColumnHeadersKF.Text = "Increment        Value"
        Me.ColumnHeadersKF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ModifiedKostiakovPanel
        '
        Me.ModifiedKostiakovPanel.AccessibleDescription = "Parameters defining infiltration using the Modified Kostiakov formula:  z = k(T ^" & _
            " a) + b(T) + c"
        Me.ModifiedKostiakovPanel.AccessibleName = "Modified Kostiakov Parameters"
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosCUpDown)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosBUpDown)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosAUpDown)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.ColHeaderMK)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosKUpDown)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.ModifiedKostiakovFormula)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosALabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosKLabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosACLabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MkosABLabel)
        Me.ModifiedKostiakovPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModifiedKostiakovPanel.Location = New System.Drawing.Point(9, 373)
        Me.ModifiedKostiakovPanel.Name = "ModifiedKostiakovPanel"
        Me.ModifiedKostiakovPanel.Size = New System.Drawing.Size(450, 160)
        Me.ModifiedKostiakovPanel.TabIndex = 6
        '
        'MkosCUpDown
        '
        Me.MkosCUpDown.DisplayUnits = "None"
        Me.MkosCUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MkosCUpDown.IncDecPlaces = 0
        Me.MkosCUpDown.Location = New System.Drawing.Point(136, 128)
        Me.MkosCUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.MkosCUpDown.Name = "MkosCUpDown"
        Me.MkosCUpDown.PropName = "MK c"
        Me.MkosCUpDown.Size = New System.Drawing.Size(220, 24)
        Me.MkosCUpDown.TabIndex = 9
        Me.MkosCUpDown.UpDownValue = 0
        '
        'MkosBUpDown
        '
        Me.MkosBUpDown.DisplayUnits = "None"
        Me.MkosBUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MkosBUpDown.IncDecPlaces = 0
        Me.MkosBUpDown.Location = New System.Drawing.Point(136, 104)
        Me.MkosBUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.MkosBUpDown.Name = "MkosBUpDown"
        Me.MkosBUpDown.PropName = "MK b"
        Me.MkosBUpDown.Size = New System.Drawing.Size(220, 24)
        Me.MkosBUpDown.TabIndex = 7
        Me.MkosBUpDown.UpDownValue = 0
        '
        'MkosAUpDown
        '
        Me.MkosAUpDown.DisplayUnits = "None"
        Me.MkosAUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MkosAUpDown.IncDecPlaces = 0
        Me.MkosAUpDown.Location = New System.Drawing.Point(136, 80)
        Me.MkosAUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.MkosAUpDown.Name = "MkosAUpDown"
        Me.MkosAUpDown.PropName = "MK a"
        Me.MkosAUpDown.Size = New System.Drawing.Size(220, 24)
        Me.MkosAUpDown.TabIndex = 5
        Me.MkosAUpDown.UpDownValue = 0
        '
        'ColHeaderMK
        '
        Me.ColHeaderMK.Location = New System.Drawing.Point(136, 32)
        Me.ColHeaderMK.Name = "ColHeaderMK"
        Me.ColHeaderMK.Size = New System.Drawing.Size(220, 24)
        Me.ColHeaderMK.TabIndex = 1
        Me.ColHeaderMK.Text = "Increment        Value"
        Me.ColHeaderMK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MkosKUpDown
        '
        Me.MkosKUpDown.DisplayUnits = "None"
        Me.MkosKUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MkosKUpDown.IncDecPlaces = 0
        Me.MkosKUpDown.Location = New System.Drawing.Point(136, 56)
        Me.MkosKUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.MkosKUpDown.Name = "MkosKUpDown"
        Me.MkosKUpDown.PropName = "MK k"
        Me.MkosKUpDown.Size = New System.Drawing.Size(220, 24)
        Me.MkosKUpDown.TabIndex = 3
        Me.MkosKUpDown.UpDownValue = 0
        '
        'ModifiedKostiakovFormula
        '
        Me.ModifiedKostiakovFormula.AccessibleDescription = "Zn = k * T^a + (b * T) + c"
        Me.ModifiedKostiakovFormula.AccessibleName = "Modified Kostiakov Formula"
        Me.ModifiedKostiakovFormula.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModifiedKostiakovFormula.Location = New System.Drawing.Point(75, 9)
        Me.ModifiedKostiakovFormula.Name = "ModifiedKostiakovFormula"
        Me.ModifiedKostiakovFormula.Size = New System.Drawing.Size(282, 23)
        Me.ModifiedKostiakovFormula.TabIndex = 0
        Me.ModifiedKostiakovFormula.Text = "Zn = k * T^a + (b * T) + c"
        Me.ModifiedKostiakovFormula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MkosALabel
        '
        Me.MkosALabel.Location = New System.Drawing.Point(111, 78)
        Me.MkosALabel.Name = "MkosALabel"
        Me.MkosALabel.Size = New System.Drawing.Size(24, 23)
        Me.MkosALabel.TabIndex = 4
        Me.MkosALabel.Text = "a"
        Me.MkosALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MkosKLabel
        '
        Me.MkosKLabel.Location = New System.Drawing.Point(111, 54)
        Me.MkosKLabel.Name = "MkosKLabel"
        Me.MkosKLabel.Size = New System.Drawing.Size(24, 23)
        Me.MkosKLabel.TabIndex = 2
        Me.MkosKLabel.Text = "k"
        Me.MkosKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MkosACLabel
        '
        Me.MkosACLabel.Location = New System.Drawing.Point(111, 126)
        Me.MkosACLabel.Name = "MkosACLabel"
        Me.MkosACLabel.Size = New System.Drawing.Size(24, 23)
        Me.MkosACLabel.TabIndex = 8
        Me.MkosACLabel.Text = "c"
        Me.MkosACLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MkosABLabel
        '
        Me.MkosABLabel.Location = New System.Drawing.Point(111, 102)
        Me.MkosABLabel.Name = "MkosABLabel"
        Me.MkosABLabel.Size = New System.Drawing.Size(24, 23)
        Me.MkosABLabel.TabIndex = 6
        Me.MkosABLabel.Text = "b"
        Me.MkosABLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CharacteristicInfiltrationPanel
        '
        Me.CharacteristicInfiltrationPanel.AccessibleDescription = "Parameters defining infiltration using the Characteristic Infiltration Time metho" & _
            "d."
        Me.CharacteristicInfiltrationPanel.AccessibleName = "Characteristic Infiltration Time Parameters"
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitDepthUpDown)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitTimeUpDown)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitAUpDown)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitK)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KITimeLabel)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KcitALabel)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KIDepthLabel)
        Me.CharacteristicInfiltrationPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CharacteristicInfiltrationPanel.Location = New System.Drawing.Point(9, 373)
        Me.CharacteristicInfiltrationPanel.Name = "CharacteristicInfiltrationPanel"
        Me.CharacteristicInfiltrationPanel.Size = New System.Drawing.Size(450, 160)
        Me.CharacteristicInfiltrationPanel.TabIndex = 6
        '
        'KcitDepthUpDown
        '
        Me.KcitDepthUpDown.DisplayUnits = "None"
        Me.KcitDepthUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KcitDepthUpDown.IncDecPlaces = 0
        Me.KcitDepthUpDown.Location = New System.Drawing.Point(136, 56)
        Me.KcitDepthUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.KcitDepthUpDown.Name = "KcitDepthUpDown"
        Me.KcitDepthUpDown.PropName = "CT D"
        Me.KcitDepthUpDown.Size = New System.Drawing.Size(220, 24)
        Me.KcitDepthUpDown.TabIndex = 3
        Me.KcitDepthUpDown.UpDownValue = 0
        '
        'KcitTimeUpDown
        '
        Me.KcitTimeUpDown.DisplayUnits = "None"
        Me.KcitTimeUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KcitTimeUpDown.IncDecPlaces = 0
        Me.KcitTimeUpDown.Location = New System.Drawing.Point(136, 80)
        Me.KcitTimeUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.KcitTimeUpDown.Name = "KcitTimeUpDown"
        Me.KcitTimeUpDown.PropName = "CT T"
        Me.KcitTimeUpDown.Size = New System.Drawing.Size(220, 24)
        Me.KcitTimeUpDown.TabIndex = 5
        Me.KcitTimeUpDown.UpDownValue = 0
        '
        'KcitAUpDown
        '
        Me.KcitAUpDown.DisplayUnits = "None"
        Me.KcitAUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KcitAUpDown.IncDecPlaces = 0
        Me.KcitAUpDown.Location = New System.Drawing.Point(136, 104)
        Me.KcitAUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.KcitAUpDown.Name = "KcitAUpDown"
        Me.KcitAUpDown.PropName = "CT a"
        Me.KcitAUpDown.Size = New System.Drawing.Size(220, 24)
        Me.KcitAUpDown.TabIndex = 7
        Me.KcitAUpDown.UpDownValue = 0
        '
        'KcitK
        '
        Me.KcitK.AccessibleDescription = "This k value is calculated using the formula:  Zn = k * T^a"
        Me.KcitK.AccessibleName = "k"
        Me.KcitK.Location = New System.Drawing.Point(115, 8)
        Me.KcitK.Name = "KcitK"
        Me.KcitK.Size = New System.Drawing.Size(192, 23)
        Me.KcitK.TabIndex = 0
        Me.KcitK.Text = "k = "
        Me.KcitK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KITimeLabel
        '
        Me.KITimeLabel.Location = New System.Drawing.Point(16, 80)
        Me.KITimeLabel.Name = "KITimeLabel"
        Me.KITimeLabel.Size = New System.Drawing.Size(119, 23)
        Me.KITimeLabel.TabIndex = 4
        Me.KITimeLabel.Text = "Char. Time"
        Me.KITimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KcitALabel
        '
        Me.KcitALabel.Location = New System.Drawing.Point(111, 100)
        Me.KcitALabel.Name = "KcitALabel"
        Me.KcitALabel.Size = New System.Drawing.Size(24, 23)
        Me.KcitALabel.TabIndex = 6
        Me.KcitALabel.Text = "a"
        Me.KcitALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KIDepthLabel
        '
        Me.KIDepthLabel.Location = New System.Drawing.Point(16, 56)
        Me.KIDepthLabel.Name = "KIDepthLabel"
        Me.KIDepthLabel.Size = New System.Drawing.Size(119, 23)
        Me.KIDepthLabel.TabIndex = 2
        Me.KIDepthLabel.Text = "Char. Depth"
        Me.KIDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TimeRatedIntakePanel
        '
        Me.TimeRatedIntakePanel.AccessibleDescription = resources.GetString("TimeRatedIntakePanel.AccessibleDescription")
        Me.TimeRatedIntakePanel.AccessibleName = "Time Rated Intake Parameters"
        Me.TimeRatedIntakePanel.Controls.Add(Me.TrifTimeUpDown)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TrifDepth)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TrifA)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TrifK)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TRTimeLabel)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TRDepthLabel)
        Me.TimeRatedIntakePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeRatedIntakePanel.Location = New System.Drawing.Point(9, 373)
        Me.TimeRatedIntakePanel.Name = "TimeRatedIntakePanel"
        Me.TimeRatedIntakePanel.Size = New System.Drawing.Size(450, 160)
        Me.TimeRatedIntakePanel.TabIndex = 6
        '
        'TrifTimeUpDown
        '
        Me.TrifTimeUpDown.DisplayUnits = "None"
        Me.TrifTimeUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrifTimeUpDown.IncDecPlaces = 0
        Me.TrifTimeUpDown.Location = New System.Drawing.Point(136, 80)
        Me.TrifTimeUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.TrifTimeUpDown.Name = "TrifTimeUpDown"
        Me.TrifTimeUpDown.PropName = "TR T"
        Me.TrifTimeUpDown.Size = New System.Drawing.Size(220, 24)
        Me.TrifTimeUpDown.TabIndex = 5
        Me.TrifTimeUpDown.UpDownValue = 0
        '
        'TrifDepth
        '
        Me.TrifDepth.AccessibleDescription = "This depth is fixed at 100mm (3.94in) for the Time Rated Intake Family Method."
        Me.TrifDepth.AccessibleName = "Characteristic Infiltration Depth"
        Me.TrifDepth.Location = New System.Drawing.Point(263, 55)
        Me.TrifDepth.Name = "TrifDepth"
        Me.TrifDepth.Size = New System.Drawing.Size(84, 23)
        Me.TrifDepth.TabIndex = 3
        Me.TrifDepth.Text = "100 mm"
        Me.TrifDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrifA
        '
        Me.TrifA.AccessibleDescription = "Exponent (a) in the formula:  Zn = k * (T ^ a).  Kostiakov a is calculated based " & _
            "on the Characteristic Infiltration Time (T)."
        Me.TrifA.AccessibleName = "Kostiakov a"
        Me.TrifA.Location = New System.Drawing.Point(230, 8)
        Me.TrifA.Name = "TrifA"
        Me.TrifA.Size = New System.Drawing.Size(160, 23)
        Me.TrifA.TabIndex = 1
        Me.TrifA.Text = "a = "
        Me.TrifA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrifK
        '
        Me.TrifK.AccessibleDescription = "Coefficient (k) in the formula:  Zn = k * (T ^ a) as calculated by WinSRFR."
        Me.TrifK.AccessibleName = "k"
        Me.TrifK.Location = New System.Drawing.Point(54, 8)
        Me.TrifK.Name = "TrifK"
        Me.TrifK.Size = New System.Drawing.Size(168, 23)
        Me.TrifK.TabIndex = 0
        Me.TrifK.Text = "k = "
        Me.TrifK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TRTimeLabel
        '
        Me.TRTimeLabel.Location = New System.Drawing.Point(20, 80)
        Me.TRTimeLabel.Name = "TRTimeLabel"
        Me.TRTimeLabel.Size = New System.Drawing.Size(112, 23)
        Me.TRTimeLabel.TabIndex = 4
        Me.TRTimeLabel.Text = "Corr. Time"
        Me.TRTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TRDepthLabel
        '
        Me.TRDepthLabel.Location = New System.Drawing.Point(20, 56)
        Me.TRDepthLabel.Name = "TRDepthLabel"
        Me.TRDepthLabel.Size = New System.Drawing.Size(112, 23)
        Me.TRDepthLabel.TabIndex = 2
        Me.TRDepthLabel.Text = "Char. Depth"
        Me.TRDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BranchFunctionPanel
        '
        Me.BranchFunctionPanel.AccessibleDescription = "Parameters defining infiltration using the Branch Function formula:  z = k(Tb ^ a" & _
            ") + b(T - Tb) + c"
        Me.BranchFunctionPanel.AccessibleName = "Branch Function Parameters"
        Me.BranchFunctionPanel.Controls.Add(Me.BranchTimeEnable)
        Me.BranchFunctionPanel.Controls.Add(Me.BranchTime)
        Me.BranchFunctionPanel.Controls.Add(Me.BranCUpDown)
        Me.BranchFunctionPanel.Controls.Add(Me.BranAUpDown)
        Me.BranchFunctionPanel.Controls.Add(Me.BranKUpDown)
        Me.BranchFunctionPanel.Controls.Add(Me.BranBUpDown)
        Me.BranchFunctionPanel.Controls.Add(Me.BranColHeaders)
        Me.BranchFunctionPanel.Controls.Add(Me.BranKLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BranBLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BranCLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BranALabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BranchTimeUpDown)
        Me.BranchFunctionPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchFunctionPanel.Location = New System.Drawing.Point(9, 373)
        Me.BranchFunctionPanel.Name = "BranchFunctionPanel"
        Me.BranchFunctionPanel.Size = New System.Drawing.Size(450, 160)
        Me.BranchFunctionPanel.TabIndex = 6
        '
        'BranchTimeEnable
        '
        Me.BranchTimeEnable.AlwaysChecked = False
        Me.BranchTimeEnable.ErrorMessage = Nothing
        Me.BranchTimeEnable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchTimeEnable.Location = New System.Drawing.Point(8, 128)
        Me.BranchTimeEnable.Name = "BranchTimeEnable"
        Me.BranchTimeEnable.Size = New System.Drawing.Size(121, 24)
        Me.BranchTimeEnable.TabIndex = 11
        Me.BranchTimeEnable.Text = "Branch Time"
        Me.BranchTimeEnable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BranchTimeEnable.UncheckAttemptMessage = Nothing
        '
        'BranchTimeUpDown
        '
        Me.BranchTimeUpDown.DisplayUnits = "None"
        Me.BranchTimeUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchTimeUpDown.IncDecPlaces = 0
        Me.BranchTimeUpDown.Location = New System.Drawing.Point(136, 128)
        Me.BranchTimeUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.BranchTimeUpDown.Name = "BranchTimeUpDown"
        Me.BranchTimeUpDown.PropName = "BF c"
        Me.BranchTimeUpDown.Size = New System.Drawing.Size(220, 24)
        Me.BranchTimeUpDown.TabIndex = 12
        Me.BranchTimeUpDown.UpDownValue = 0
        '
        'BranchTime
        '
        Me.BranchTime.AccessibleDescription = "Time at which the Branch Function switches from non-linear to linear."
        Me.BranchTime.AccessibleName = "Branch Time"
        Me.BranchTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchTime.Location = New System.Drawing.Point(208, 128)
        Me.BranchTime.Name = "BranchTime"
        Me.BranchTime.Size = New System.Drawing.Size(83, 23)
        Me.BranchTime.TabIndex = 14
        Me.BranchTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BranCUpDown
        '
        Me.BranCUpDown.DisplayUnits = "None"
        Me.BranCUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranCUpDown.IncDecPlaces = 0
        Me.BranCUpDown.Location = New System.Drawing.Point(136, 104)
        Me.BranCUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.BranCUpDown.Name = "BranCUpDown"
        Me.BranCUpDown.PropName = "BF c"
        Me.BranCUpDown.Size = New System.Drawing.Size(220, 24)
        Me.BranCUpDown.TabIndex = 10
        Me.BranCUpDown.UpDownValue = 0
        '
        'BranAUpDown
        '
        Me.BranAUpDown.DisplayUnits = "None"
        Me.BranAUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranAUpDown.IncDecPlaces = 0
        Me.BranAUpDown.Location = New System.Drawing.Point(136, 56)
        Me.BranAUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.BranAUpDown.Name = "BranAUpDown"
        Me.BranAUpDown.PropName = "BF a"
        Me.BranAUpDown.Size = New System.Drawing.Size(220, 24)
        Me.BranAUpDown.TabIndex = 6
        Me.BranAUpDown.UpDownValue = 0
        '
        'BranKUpDown
        '
        Me.BranKUpDown.DisplayUnits = "None"
        Me.BranKUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranKUpDown.IncDecPlaces = 0
        Me.BranKUpDown.Location = New System.Drawing.Point(136, 32)
        Me.BranKUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.BranKUpDown.Name = "BranKUpDown"
        Me.BranKUpDown.PropName = "BF k"
        Me.BranKUpDown.Size = New System.Drawing.Size(220, 24)
        Me.BranKUpDown.TabIndex = 4
        Me.BranKUpDown.UpDownValue = 0
        '
        'BranBUpDown
        '
        Me.BranBUpDown.DisplayUnits = "None"
        Me.BranBUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranBUpDown.IncDecPlaces = 0
        Me.BranBUpDown.Location = New System.Drawing.Point(136, 80)
        Me.BranBUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.BranBUpDown.Name = "BranBUpDown"
        Me.BranBUpDown.PropName = "BF b"
        Me.BranBUpDown.Size = New System.Drawing.Size(220, 24)
        Me.BranBUpDown.TabIndex = 8
        Me.BranBUpDown.UpDownValue = 0
        '
        'BranColHeaders
        '
        Me.BranColHeaders.Location = New System.Drawing.Point(136, 8)
        Me.BranColHeaders.Name = "BranColHeaders"
        Me.BranColHeaders.Size = New System.Drawing.Size(220, 24)
        Me.BranColHeaders.TabIndex = 2
        Me.BranColHeaders.Text = "Increment        Value"
        Me.BranColHeaders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranKLabel
        '
        Me.BranKLabel.Location = New System.Drawing.Point(111, 30)
        Me.BranKLabel.Name = "BranKLabel"
        Me.BranKLabel.Size = New System.Drawing.Size(24, 23)
        Me.BranKLabel.TabIndex = 3
        Me.BranKLabel.Text = "k"
        Me.BranKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranBLabel
        '
        Me.BranBLabel.Location = New System.Drawing.Point(111, 78)
        Me.BranBLabel.Name = "BranBLabel"
        Me.BranBLabel.Size = New System.Drawing.Size(24, 23)
        Me.BranBLabel.TabIndex = 7
        Me.BranBLabel.Text = "b"
        Me.BranBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranCLabel
        '
        Me.BranCLabel.Location = New System.Drawing.Point(111, 102)
        Me.BranCLabel.Name = "BranCLabel"
        Me.BranCLabel.Size = New System.Drawing.Size(24, 23)
        Me.BranCLabel.TabIndex = 9
        Me.BranCLabel.Text = "c"
        Me.BranCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranALabel
        '
        Me.BranALabel.Location = New System.Drawing.Point(111, 54)
        Me.BranALabel.Name = "BranALabel"
        Me.BranALabel.Size = New System.Drawing.Size(24, 23)
        Me.BranALabel.TabIndex = 5
        Me.BranALabel.Text = "a"
        Me.BranALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SaveButton
        '
        Me.SaveButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SaveButton.Location = New System.Drawing.Point(302, 535)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 24)
        Me.SaveButton.TabIndex = 21
        Me.SaveButton.Text = "&Save"
        Me.SaveButton.UseVisualStyleBackColor = False
        '
        'HelpText
        '
        Me.HelpText.BackColor = System.Drawing.SystemColors.Info
        Me.HelpText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpText.ForeColor = System.Drawing.SystemColors.InfoText
        Me.HelpText.Location = New System.Drawing.Point(6, 6)
        Me.HelpText.Name = "HelpText"
        Me.HelpText.Size = New System.Drawing.Size(462, 52)
        Me.HelpText.TabIndex = 0
        Me.HelpText.Text = "Help text."
        '
        'GreenAmptPanel
        '
        Me.GreenAmptPanel.Controls.Add(Me.GaCUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GaHydraulicConductivityUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GaPressureHeadUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GaInitialWaterContentUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GaColHeaders)
        Me.GreenAmptPanel.Controls.Add(Me.GaEffectivePorosityUpDown)
        Me.GreenAmptPanel.Controls.Add(Me.GAcLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GAHydraulicConductivityLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GAPressureHeadLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GAInitialWaterContentLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GAEffectivePorosityLabel)
        Me.GreenAmptPanel.Location = New System.Drawing.Point(9, 373)
        Me.GreenAmptPanel.Name = "GreenAmptPanel"
        Me.GreenAmptPanel.Size = New System.Drawing.Size(450, 160)
        Me.GreenAmptPanel.TabIndex = 6
        '
        'GaCUpDown
        '
        Me.GaCUpDown.DisplayUnits = "None"
        Me.GaCUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GaCUpDown.IncDecPlaces = 0
        Me.GaCUpDown.Location = New System.Drawing.Point(224, 130)
        Me.GaCUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.GaCUpDown.Name = "GaCUpDown"
        Me.GaCUpDown.PropName = "GA c"
        Me.GaCUpDown.Size = New System.Drawing.Size(220, 24)
        Me.GaCUpDown.TabIndex = 11
        Me.GaCUpDown.UpDownValue = 0
        '
        'GaHydraulicConductivityUpDown
        '
        Me.GaHydraulicConductivityUpDown.DisplayUnits = "None"
        Me.GaHydraulicConductivityUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GaHydraulicConductivityUpDown.IncDecPlaces = 0
        Me.GaHydraulicConductivityUpDown.Location = New System.Drawing.Point(224, 105)
        Me.GaHydraulicConductivityUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.GaHydraulicConductivityUpDown.Name = "GaHydraulicConductivityUpDown"
        Me.GaHydraulicConductivityUpDown.PropName = "GA Ks"
        Me.GaHydraulicConductivityUpDown.Size = New System.Drawing.Size(220, 24)
        Me.GaHydraulicConductivityUpDown.TabIndex = 9
        Me.GaHydraulicConductivityUpDown.UpDownValue = 0
        '
        'GaPressureHeadUpDown
        '
        Me.GaPressureHeadUpDown.DisplayUnits = "None"
        Me.GaPressureHeadUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GaPressureHeadUpDown.IncDecPlaces = 0
        Me.GaPressureHeadUpDown.Location = New System.Drawing.Point(224, 80)
        Me.GaPressureHeadUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.GaPressureHeadUpDown.Name = "GaPressureHeadUpDown"
        Me.GaPressureHeadUpDown.PropName = "GA hf"
        Me.GaPressureHeadUpDown.Size = New System.Drawing.Size(220, 24)
        Me.GaPressureHeadUpDown.TabIndex = 7
        Me.GaPressureHeadUpDown.UpDownValue = 0
        '
        'GaInitialWaterContentUpDown
        '
        Me.GaInitialWaterContentUpDown.DisplayUnits = "None"
        Me.GaInitialWaterContentUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GaInitialWaterContentUpDown.IncDecPlaces = 0
        Me.GaInitialWaterContentUpDown.Location = New System.Drawing.Point(224, 55)
        Me.GaInitialWaterContentUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.GaInitialWaterContentUpDown.Name = "GaInitialWaterContentUpDown"
        Me.GaInitialWaterContentUpDown.PropName = "GA Theta0"
        Me.GaInitialWaterContentUpDown.Size = New System.Drawing.Size(220, 24)
        Me.GaInitialWaterContentUpDown.TabIndex = 5
        Me.GaInitialWaterContentUpDown.UpDownValue = 0
        '
        'GaColHeaders
        '
        Me.GaColHeaders.Location = New System.Drawing.Point(224, 3)
        Me.GaColHeaders.Name = "GaColHeaders"
        Me.GaColHeaders.Size = New System.Drawing.Size(220, 24)
        Me.GaColHeaders.TabIndex = 0
        Me.GaColHeaders.Text = "Increment        Value"
        Me.GaColHeaders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GaEffectivePorosityUpDown
        '
        Me.GaEffectivePorosityUpDown.DisplayUnits = "None"
        Me.GaEffectivePorosityUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GaEffectivePorosityUpDown.IncDecPlaces = 0
        Me.GaEffectivePorosityUpDown.Location = New System.Drawing.Point(224, 30)
        Me.GaEffectivePorosityUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.GaEffectivePorosityUpDown.Name = "GaEffectivePorosityUpDown"
        Me.GaEffectivePorosityUpDown.PropName = "GA ThetaS"
        Me.GaEffectivePorosityUpDown.Size = New System.Drawing.Size(220, 24)
        Me.GaEffectivePorosityUpDown.TabIndex = 3
        Me.GaEffectivePorosityUpDown.UpDownValue = 0
        '
        'GAcLabel
        '
        Me.GAcLabel.Location = New System.Drawing.Point(11, 130)
        Me.GAcLabel.Name = "GAcLabel"
        Me.GAcLabel.Size = New System.Drawing.Size(205, 23)
        Me.GAcLabel.TabIndex = 10
        Me.GAcLabel.Text = "Macropore Infiltration"
        Me.GAcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GAHydraulicConductivityLabel
        '
        Me.GAHydraulicConductivityLabel.Location = New System.Drawing.Point(11, 105)
        Me.GAHydraulicConductivityLabel.Name = "GAHydraulicConductivityLabel"
        Me.GAHydraulicConductivityLabel.Size = New System.Drawing.Size(205, 23)
        Me.GAHydraulicConductivityLabel.TabIndex = 8
        Me.GAHydraulicConductivityLabel.Text = "Hydraulic Conductivity"
        Me.GAHydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GAPressureHeadLabel
        '
        Me.GAPressureHeadLabel.Location = New System.Drawing.Point(11, 80)
        Me.GAPressureHeadLabel.Name = "GAPressureHeadLabel"
        Me.GAPressureHeadLabel.Size = New System.Drawing.Size(205, 23)
        Me.GAPressureHeadLabel.TabIndex = 6
        Me.GAPressureHeadLabel.Text = "Wetting Front Pressure Head"
        Me.GAPressureHeadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GAInitialWaterContentLabel
        '
        Me.GAInitialWaterContentLabel.Location = New System.Drawing.Point(11, 55)
        Me.GAInitialWaterContentLabel.Name = "GAInitialWaterContentLabel"
        Me.GAInitialWaterContentLabel.Size = New System.Drawing.Size(205, 23)
        Me.GAInitialWaterContentLabel.TabIndex = 4
        Me.GAInitialWaterContentLabel.Text = "Initial Water Content"
        Me.GAInitialWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GAEffectivePorosityLabel
        '
        Me.GAEffectivePorosityLabel.Location = New System.Drawing.Point(11, 30)
        Me.GAEffectivePorosityLabel.Name = "GAEffectivePorosityLabel"
        Me.GAEffectivePorosityLabel.Size = New System.Drawing.Size(205, 23)
        Me.GAEffectivePorosityLabel.TabIndex = 2
        Me.GAEffectivePorosityLabel.Text = "Effective Porosity"
        Me.GAEffectivePorosityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WarrickGreenAmptPanel
        '
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaCUpDown)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaHydraulicConductivityUpDown)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaPressureHeadUpDown)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaInitialWaterContentUpDown)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaColHeaders)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaSaturatedWaterContentUpDown)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgacLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaHydraulicConductivityLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaPressureHeadLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaInitialWaterContentLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WgaSatWaterContentLabel)
        Me.WarrickGreenAmptPanel.Location = New System.Drawing.Point(9, 373)
        Me.WarrickGreenAmptPanel.Name = "WarrickGreenAmptPanel"
        Me.WarrickGreenAmptPanel.Size = New System.Drawing.Size(450, 160)
        Me.WarrickGreenAmptPanel.TabIndex = 6
        '
        'WgaCUpDown
        '
        Me.WgaCUpDown.DisplayUnits = "None"
        Me.WgaCUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WgaCUpDown.IncDecPlaces = 0
        Me.WgaCUpDown.Location = New System.Drawing.Point(224, 130)
        Me.WgaCUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.WgaCUpDown.Name = "WgaCUpDown"
        Me.WgaCUpDown.PropName = "WGA c"
        Me.WgaCUpDown.Size = New System.Drawing.Size(220, 24)
        Me.WgaCUpDown.TabIndex = 11
        Me.WgaCUpDown.UpDownValue = 0
        '
        'WgaHydraulicConductivityUpDown
        '
        Me.WgaHydraulicConductivityUpDown.DisplayUnits = "None"
        Me.WgaHydraulicConductivityUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WgaHydraulicConductivityUpDown.IncDecPlaces = 0
        Me.WgaHydraulicConductivityUpDown.Location = New System.Drawing.Point(224, 105)
        Me.WgaHydraulicConductivityUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.WgaHydraulicConductivityUpDown.Name = "WgaHydraulicConductivityUpDown"
        Me.WgaHydraulicConductivityUpDown.PropName = "WGA Ks"
        Me.WgaHydraulicConductivityUpDown.Size = New System.Drawing.Size(220, 24)
        Me.WgaHydraulicConductivityUpDown.TabIndex = 9
        Me.WgaHydraulicConductivityUpDown.UpDownValue = 0
        '
        'WgaPressureHeadUpDown
        '
        Me.WgaPressureHeadUpDown.DisplayUnits = "None"
        Me.WgaPressureHeadUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WgaPressureHeadUpDown.IncDecPlaces = 0
        Me.WgaPressureHeadUpDown.Location = New System.Drawing.Point(224, 80)
        Me.WgaPressureHeadUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.WgaPressureHeadUpDown.Name = "WgaPressureHeadUpDown"
        Me.WgaPressureHeadUpDown.PropName = "WGA hf"
        Me.WgaPressureHeadUpDown.Size = New System.Drawing.Size(220, 24)
        Me.WgaPressureHeadUpDown.TabIndex = 7
        Me.WgaPressureHeadUpDown.UpDownValue = 0
        '
        'WgaInitialWaterContentUpDown
        '
        Me.WgaInitialWaterContentUpDown.DisplayUnits = "None"
        Me.WgaInitialWaterContentUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WgaInitialWaterContentUpDown.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.WgaInitialWaterContentUpDown.IncDecPlaces = 0
        Me.WgaInitialWaterContentUpDown.Location = New System.Drawing.Point(224, 55)
        Me.WgaInitialWaterContentUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.WgaInitialWaterContentUpDown.Name = "WgaInitialWaterContentUpDown"
        Me.WgaInitialWaterContentUpDown.PropName = "WGA Theta0"
        Me.WgaInitialWaterContentUpDown.Size = New System.Drawing.Size(220, 24)
        Me.WgaInitialWaterContentUpDown.TabIndex = 5
        Me.WgaInitialWaterContentUpDown.UpDownValue = 0
        '
        'WgaColHeaders
        '
        Me.WgaColHeaders.Location = New System.Drawing.Point(224, 3)
        Me.WgaColHeaders.Name = "WgaColHeaders"
        Me.WgaColHeaders.Size = New System.Drawing.Size(220, 24)
        Me.WgaColHeaders.TabIndex = 0
        Me.WgaColHeaders.Text = "Increment        Value"
        Me.WgaColHeaders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WgaSaturatedWaterContentUpDown
        '
        Me.WgaSaturatedWaterContentUpDown.DisplayUnits = "None"
        Me.WgaSaturatedWaterContentUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WgaSaturatedWaterContentUpDown.IncDecPlaces = 0
        Me.WgaSaturatedWaterContentUpDown.Location = New System.Drawing.Point(224, 30)
        Me.WgaSaturatedWaterContentUpDown.Margin = New System.Windows.Forms.Padding(4)
        Me.WgaSaturatedWaterContentUpDown.Name = "WgaSaturatedWaterContentUpDown"
        Me.WgaSaturatedWaterContentUpDown.PropName = "WGA ThetaS"
        Me.WgaSaturatedWaterContentUpDown.Size = New System.Drawing.Size(220, 24)
        Me.WgaSaturatedWaterContentUpDown.TabIndex = 3
        Me.WgaSaturatedWaterContentUpDown.UpDownValue = 0
        '
        'WgacLabel
        '
        Me.WgacLabel.Location = New System.Drawing.Point(11, 130)
        Me.WgacLabel.Name = "WgacLabel"
        Me.WgacLabel.Size = New System.Drawing.Size(205, 23)
        Me.WgacLabel.TabIndex = 10
        Me.WgacLabel.Text = "Macropore Infiltration"
        Me.WgacLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WgaHydraulicConductivityLabel
        '
        Me.WgaHydraulicConductivityLabel.Location = New System.Drawing.Point(11, 105)
        Me.WgaHydraulicConductivityLabel.Name = "WgaHydraulicConductivityLabel"
        Me.WgaHydraulicConductivityLabel.Size = New System.Drawing.Size(205, 23)
        Me.WgaHydraulicConductivityLabel.TabIndex = 8
        Me.WgaHydraulicConductivityLabel.Text = "Hydraulic Conductivity"
        Me.WgaHydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WgaPressureHeadLabel
        '
        Me.WgaPressureHeadLabel.Location = New System.Drawing.Point(11, 80)
        Me.WgaPressureHeadLabel.Name = "WgaPressureHeadLabel"
        Me.WgaPressureHeadLabel.Size = New System.Drawing.Size(205, 23)
        Me.WgaPressureHeadLabel.TabIndex = 6
        Me.WgaPressureHeadLabel.Text = "Wetting Front Pressure Head"
        Me.WgaPressureHeadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WgaInitialWaterContentLabel
        '
        Me.WgaInitialWaterContentLabel.Location = New System.Drawing.Point(11, 55)
        Me.WgaInitialWaterContentLabel.Name = "WgaInitialWaterContentLabel"
        Me.WgaInitialWaterContentLabel.Size = New System.Drawing.Size(205, 23)
        Me.WgaInitialWaterContentLabel.TabIndex = 4
        Me.WgaInitialWaterContentLabel.Text = "Initial Water Content"
        Me.WgaInitialWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WgaSatWaterContentLabel
        '
        Me.WgaSatWaterContentLabel.Location = New System.Drawing.Point(11, 30)
        Me.WgaSatWaterContentLabel.Name = "WgaSatWaterContentLabel"
        Me.WgaSatWaterContentLabel.Size = New System.Drawing.Size(205, 23)
        Me.WgaSatWaterContentLabel.TabIndex = 2
        Me.WgaSatWaterContentLabel.Text = "Sat. Water Content"
        Me.WgaSatWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WettedPerimeterControl
        '
        Me.WettedPerimeterControl.AccessibleDescription = "Selects the method for describing the wetted perimeter."
        Me.WettedPerimeterControl.AccessibleName = "Wetted Perimeter"
        Me.WettedPerimeterControl.ApplicationValue = -1
        Me.WettedPerimeterControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WettedPerimeterControl.EnableSaveActions = False
        Me.WettedPerimeterControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WettedPerimeterControl.IsCalculated = False
        Me.WettedPerimeterControl.Location = New System.Drawing.Point(187, 322)
        Me.WettedPerimeterControl.Name = "WettedPerimeterControl"
        Me.WettedPerimeterControl.SelectedIndexSet = False
        Me.WettedPerimeterControl.Size = New System.Drawing.Size(238, 24)
        Me.WettedPerimeterControl.TabIndex = 3
        '
        'InfiltrationEquationControl
        '
        Me.InfiltrationEquationControl.AccessibleDescription = "Selects the Infiltration Function for entering the infiltration parameters.  The " & _
            "Dialogs tab under User Preferences controls operation when a new method is selec" & _
            "ted."
        Me.InfiltrationEquationControl.AccessibleName = "Infiltration Function"
        Me.InfiltrationEquationControl.ApplicationValue = -1
        Me.InfiltrationEquationControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InfiltrationEquationControl.EnableSaveActions = False
        Me.InfiltrationEquationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationEquationControl.IsCalculated = False
        Me.InfiltrationEquationControl.Location = New System.Drawing.Point(187, 348)
        Me.InfiltrationEquationControl.Name = "InfiltrationEquationControl"
        Me.InfiltrationEquationControl.SelectedIndexSet = False
        Me.InfiltrationEquationControl.Size = New System.Drawing.Size(238, 24)
        Me.InfiltrationEquationControl.TabIndex = 5
        '
        'WettedPerimeterLabel
        '
        Me.WettedPerimeterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WettedPerimeterLabel.Location = New System.Drawing.Point(47, 322)
        Me.WettedPerimeterLabel.Name = "WettedPerimeterLabel"
        Me.WettedPerimeterLabel.Size = New System.Drawing.Size(134, 23)
        Me.WettedPerimeterLabel.TabIndex = 2
        Me.WettedPerimeterLabel.Text = "&Wetted Perimeter"
        Me.WettedPerimeterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InfiltrationEquationLabel
        '
        Me.InfiltrationEquationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationEquationLabel.Location = New System.Drawing.Point(47, 348)
        Me.InfiltrationEquationLabel.Name = "InfiltrationEquationLabel"
        Me.InfiltrationEquationLabel.Size = New System.Drawing.Size(134, 23)
        Me.InfiltrationEquationLabel.TabIndex = 4
        Me.InfiltrationEquationLabel.Text = "&Infiltration Equation"
        Me.InfiltrationEquationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NrcsIntakePanel
        '
        Me.NrcsIntakePanel.AccessibleDescription = "Radio buttons to select the infiltration rate from an NRCS Intake Family."
        Me.NrcsIntakePanel.AccessibleName = "NRCS Intake Parameters"
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsC)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsA)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsK)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily400Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily300Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily090Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily200Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily150Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily100Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily080Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily070Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily060Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily050Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily045Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily040Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily035Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily030Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily025Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily020Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily015Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily010Button)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsFamily005Button)
        Me.NrcsIntakePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsIntakePanel.Location = New System.Drawing.Point(9, 373)
        Me.NrcsIntakePanel.Name = "NrcsIntakePanel"
        Me.NrcsIntakePanel.Size = New System.Drawing.Size(450, 160)
        Me.NrcsIntakePanel.TabIndex = 6
        '
        'NrcsC
        '
        Me.NrcsC.Location = New System.Drawing.Point(288, 8)
        Me.NrcsC.Name = "NrcsC"
        Me.NrcsC.Size = New System.Drawing.Size(72, 23)
        Me.NrcsC.TabIndex = 22
        Me.NrcsC.Text = "c = "
        Me.NrcsC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsA
        '
        Me.NrcsA.Location = New System.Drawing.Point(192, 8)
        Me.NrcsA.Name = "NrcsA"
        Me.NrcsA.Size = New System.Drawing.Size(72, 23)
        Me.NrcsA.TabIndex = 20
        Me.NrcsA.Text = "a = "
        Me.NrcsA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsK
        '
        Me.NrcsK.Location = New System.Drawing.Point(24, 8)
        Me.NrcsK.Name = "NrcsK"
        Me.NrcsK.Size = New System.Drawing.Size(152, 23)
        Me.NrcsK.TabIndex = 19
        Me.NrcsK.Text = "k = "
        Me.NrcsK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsFamily400Button
        '
        Me.NrcsFamily400Button.Location = New System.Drawing.Point(288, 110)
        Me.NrcsFamily400Button.Name = "NrcsFamily400Button"
        Me.NrcsFamily400Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily400Button.TabIndex = 18
        Me.NrcsFamily400Button.Text = "4.00"
        '
        'NrcsFamily300Button
        '
        Me.NrcsFamily300Button.Location = New System.Drawing.Point(288, 86)
        Me.NrcsFamily300Button.Name = "NrcsFamily300Button"
        Me.NrcsFamily300Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily300Button.TabIndex = 17
        Me.NrcsFamily300Button.Text = "3.00"
        '
        'NrcsFamily090Button
        '
        Me.NrcsFamily090Button.Location = New System.Drawing.Point(192, 110)
        Me.NrcsFamily090Button.Name = "NrcsFamily090Button"
        Me.NrcsFamily090Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily090Button.TabIndex = 13
        Me.NrcsFamily090Button.Text = "0.90"
        '
        'NrcsFamily200Button
        '
        Me.NrcsFamily200Button.Location = New System.Drawing.Point(288, 62)
        Me.NrcsFamily200Button.Name = "NrcsFamily200Button"
        Me.NrcsFamily200Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily200Button.TabIndex = 16
        Me.NrcsFamily200Button.Text = "2.00"
        '
        'NrcsFamily150Button
        '
        Me.NrcsFamily150Button.Location = New System.Drawing.Point(288, 38)
        Me.NrcsFamily150Button.Name = "NrcsFamily150Button"
        Me.NrcsFamily150Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily150Button.TabIndex = 15
        Me.NrcsFamily150Button.Text = "1.50"
        '
        'NrcsFamily100Button
        '
        Me.NrcsFamily100Button.Location = New System.Drawing.Point(192, 134)
        Me.NrcsFamily100Button.Name = "NrcsFamily100Button"
        Me.NrcsFamily100Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily100Button.TabIndex = 14
        Me.NrcsFamily100Button.Text = "1.00"
        '
        'NrcsFamily080Button
        '
        Me.NrcsFamily080Button.Location = New System.Drawing.Point(192, 86)
        Me.NrcsFamily080Button.Name = "NrcsFamily080Button"
        Me.NrcsFamily080Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily080Button.TabIndex = 12
        Me.NrcsFamily080Button.Text = "0.80"
        '
        'NrcsFamily070Button
        '
        Me.NrcsFamily070Button.Location = New System.Drawing.Point(192, 62)
        Me.NrcsFamily070Button.Name = "NrcsFamily070Button"
        Me.NrcsFamily070Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily070Button.TabIndex = 11
        Me.NrcsFamily070Button.Text = "0.70"
        '
        'NrcsFamily060Button
        '
        Me.NrcsFamily060Button.Location = New System.Drawing.Point(192, 38)
        Me.NrcsFamily060Button.Name = "NrcsFamily060Button"
        Me.NrcsFamily060Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily060Button.TabIndex = 10
        Me.NrcsFamily060Button.Text = "0.60"
        '
        'NrcsFamily050Button
        '
        Me.NrcsFamily050Button.Location = New System.Drawing.Point(96, 134)
        Me.NrcsFamily050Button.Name = "NrcsFamily050Button"
        Me.NrcsFamily050Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily050Button.TabIndex = 9
        Me.NrcsFamily050Button.Text = "0.50"
        '
        'NrcsFamily045Button
        '
        Me.NrcsFamily045Button.Location = New System.Drawing.Point(96, 110)
        Me.NrcsFamily045Button.Name = "NrcsFamily045Button"
        Me.NrcsFamily045Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily045Button.TabIndex = 8
        Me.NrcsFamily045Button.Text = "0.45"
        '
        'NrcsFamily040Button
        '
        Me.NrcsFamily040Button.Location = New System.Drawing.Point(96, 86)
        Me.NrcsFamily040Button.Name = "NrcsFamily040Button"
        Me.NrcsFamily040Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily040Button.TabIndex = 7
        Me.NrcsFamily040Button.Text = "0.40"
        '
        'NrcsFamily035Button
        '
        Me.NrcsFamily035Button.Location = New System.Drawing.Point(96, 62)
        Me.NrcsFamily035Button.Name = "NrcsFamily035Button"
        Me.NrcsFamily035Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily035Button.TabIndex = 6
        Me.NrcsFamily035Button.Text = "0.35"
        '
        'NrcsFamily030Button
        '
        Me.NrcsFamily030Button.Location = New System.Drawing.Point(96, 38)
        Me.NrcsFamily030Button.Name = "NrcsFamily030Button"
        Me.NrcsFamily030Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily030Button.TabIndex = 5
        Me.NrcsFamily030Button.Text = "0.30"
        '
        'NrcsFamily025Button
        '
        Me.NrcsFamily025Button.Location = New System.Drawing.Point(24, 134)
        Me.NrcsFamily025Button.Name = "NrcsFamily025Button"
        Me.NrcsFamily025Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily025Button.TabIndex = 4
        Me.NrcsFamily025Button.Text = "0.25"
        '
        'NrcsFamily020Button
        '
        Me.NrcsFamily020Button.Location = New System.Drawing.Point(24, 110)
        Me.NrcsFamily020Button.Name = "NrcsFamily020Button"
        Me.NrcsFamily020Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily020Button.TabIndex = 3
        Me.NrcsFamily020Button.Text = "0.20"
        '
        'NrcsFamily015Button
        '
        Me.NrcsFamily015Button.Location = New System.Drawing.Point(24, 86)
        Me.NrcsFamily015Button.Name = "NrcsFamily015Button"
        Me.NrcsFamily015Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily015Button.TabIndex = 2
        Me.NrcsFamily015Button.Text = "0.15"
        '
        'NrcsFamily010Button
        '
        Me.NrcsFamily010Button.Location = New System.Drawing.Point(24, 62)
        Me.NrcsFamily010Button.Name = "NrcsFamily010Button"
        Me.NrcsFamily010Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily010Button.TabIndex = 1
        Me.NrcsFamily010Button.Text = "0.10"
        '
        'NrcsFamily005Button
        '
        Me.NrcsFamily005Button.Location = New System.Drawing.Point(24, 38)
        Me.NrcsFamily005Button.Name = "NrcsFamily005Button"
        Me.NrcsFamily005Button.Size = New System.Drawing.Size(64, 24)
        Me.NrcsFamily005Button.TabIndex = 0
        Me.NrcsFamily005Button.Text = "0.05"
        '
        'MatchButton
        '
        Me.MatchButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MatchButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MatchButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.MatchButton.Location = New System.Drawing.Point(8, 535)
        Me.MatchButton.Name = "MatchButton"
        Me.MatchButton.Size = New System.Drawing.Size(220, 24)
        Me.MatchButton.TabIndex = 20
        Me.MatchButton.Text = "&Match to Volume Balance"
        Me.MatchButton.UseVisualStyleBackColor = False
        '
        'HydrusPanel
        '
        Me.HydrusPanel.AccessibleDescription = "HYDRUS is not supported"
        Me.HydrusPanel.AccessibleName = "HYDRUS"
        Me.HydrusPanel.Controls.Add(Me.HydrusNotSupportedLabel)
        Me.HydrusPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HydrusPanel.Location = New System.Drawing.Point(9, 373)
        Me.HydrusPanel.Name = "HydrusPanel"
        Me.HydrusPanel.Size = New System.Drawing.Size(450, 160)
        Me.HydrusPanel.TabIndex = 41
        '
        'HydrusNotSupportedLabel
        '
        Me.HydrusNotSupportedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HydrusNotSupportedLabel.Location = New System.Drawing.Point(3, 69)
        Me.HydrusNotSupportedLabel.Name = "HydrusNotSupportedLabel"
        Me.HydrusNotSupportedLabel.Size = New System.Drawing.Size(441, 23)
        Me.HydrusNotSupportedLabel.TabIndex = 3
        Me.HydrusNotSupportedLabel.Text = "HYDRUS is not supported"
        Me.HydrusNotSupportedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfiltrationGraph
        '
        Me.InfiltrationGraph.AccessibleDescription = "A copyable bitmap image"
        Me.InfiltrationGraph.AccessibleName = "Bitmap Diagram"
        Me.InfiltrationGraph.BottomTitleAdjY = 0.0!
        Me.InfiltrationGraph.CopyDataSet = Nothing
        Me.InfiltrationGraph.CurveControlIsOn = False
        Me.InfiltrationGraph.DisplayKey = False
        Me.InfiltrationGraph.FontAdjustment = 0.0!
        Me.InfiltrationGraph.FontName = "Microsoft Sans Serif"
        Me.InfiltrationGraph.FontSize = 10.0!
        Me.InfiltrationGraph.GraphSymbols = Nothing
        Me.InfiltrationGraph.HorizontalKeys = False
        Me.InfiltrationGraph.HorzLines = Nothing
        Me.InfiltrationGraph.LastCurve = -1
        Me.InfiltrationGraph.LeftTitleAdjX = 0.0!
        Me.InfiltrationGraph.Location = New System.Drawing.Point(6, 62)
        Me.InfiltrationGraph.MaxX = 0
        Me.InfiltrationGraph.MaxY = 0
        Me.InfiltrationGraph.MinX = 0
        Me.InfiltrationGraph.MinY = 0
        Me.InfiltrationGraph.Name = "InfiltrationGraph"
        Me.InfiltrationGraph.NewHotspotKeys = True
        Me.InfiltrationGraph.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.InfiltrationGraph.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.InfiltrationGraph.RightTitleAdjX = 0.0!
        Me.InfiltrationGraph.Size = New System.Drawing.Size(462, 258)
        Me.InfiltrationGraph.TabIndex = 10
        Me.InfiltrationGraph.TabStop = False
        Me.InfiltrationGraph.Text = "Bitmap Diagram"
        Me.InfiltrationGraph.TextLines = Nothing
        Me.InfiltrationGraph.TitleAdjY = 0.0!
        Me.InfiltrationGraph.TopTitleAdjY = 0.0!
        Me.InfiltrationGraph.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.InfiltrationGraph.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.InfiltrationGraph.VertLabels = Nothing
        Me.InfiltrationGraph.VertLines = Nothing
        Me.InfiltrationGraph.VLabelPos = Nothing
        '
        'InfiltrationFunctionEditor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelNewButton
        Me.ClientSize = New System.Drawing.Size(474, 562)
        Me.Controls.Add(Me.BranchFunctionPanel)
        Me.Controls.Add(Me.CharacteristicInfiltrationPanel)
        Me.Controls.Add(Me.HydrusPanel)
        Me.Controls.Add(Me.KostiakovPanel)
        Me.Controls.Add(Me.MatchButton)
        Me.Controls.Add(Me.WettedPerimeterControl)
        Me.Controls.Add(Me.InfiltrationEquationControl)
        Me.Controls.Add(Me.WettedPerimeterLabel)
        Me.Controls.Add(Me.InfiltrationEquationLabel)
        Me.Controls.Add(Me.InfiltrationGraph)
        Me.Controls.Add(Me.HelpText)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.CancelNewButton)
        Me.Controls.Add(Me.NrcsIntakePanel)
        Me.Controls.Add(Me.WarrickGreenAmptPanel)
        Me.Controls.Add(Me.GreenAmptPanel)
        Me.Controls.Add(Me.ModifiedKostiakovPanel)
        Me.Controls.Add(Me.TimeRatedIntakePanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InfiltrationFunctionEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Infiltration Function Editor"
        Me.KostiakovPanel.ResumeLayout(False)
        Me.ModifiedKostiakovPanel.ResumeLayout(False)
        Me.CharacteristicInfiltrationPanel.ResumeLayout(False)
        Me.TimeRatedIntakePanel.ResumeLayout(False)
        Me.BranchFunctionPanel.ResumeLayout(False)
        Me.GreenAmptPanel.ResumeLayout(False)
        Me.WarrickGreenAmptPanel.ResumeLayout(False)
        Me.NrcsIntakePanel.ResumeLayout(False)
        Me.HydrusPanel.ResumeLayout(False)
        CType(Me.InfiltrationGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Language translation Dictionary
    '
    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' WinSRFR DataStore objects
    '
    Private mUnit As Unit = Nothing
    Private mWinSRFR As WinSRFR = Nothing
    Private mInflowManagement As InflowManagement = Nothing
    Private mSystemGeometry As SystemGeometry = Nothing
    Private mSoilCropProperties As SoilCropProperties = Nothing

    Private mMyStore As DataStore.ObjectNode
    '
    ' SRFR objects
    '
    Private mSrfrInfiltration As Srfr.Infiltration = Nothing
    Private mSrfrCrossSection As Srfr.CrossSection = Nothing
    Private mSrfrRoughness As Srfr.Roughness = Nothing
    Private mSrfrInflow As Srfr.Inflow = Nothing
    '
    ' Infiltration Function Editor data
    '
    Private mInitialized As Boolean = False     ' Editor has been initialized

    Public Enum MatchTypes                      ' Infiltration Depth vs. Volume matching
        MatchDepths
        MatchVolumes
    End Enum

    Private mMatchType As MatchTypes = MatchTypes.MatchDepths ' Set within New()

    Private mNrcsIntakeFamily As NrcsIntakeFamilies = NrcsIntakeFamilies.Family005

    Private mAddUpstreamDepthText As Boolean = False

#End Region

#Region " Properties "
    '
    ' WinSRFR objects
    '
    Private mAnalysis As Analysis
    Public Property WinSrfrAnalysis() As Analysis
        Get
            Return mAnalysis
        End Get
        Set(ByVal value As Analysis)
            mAnalysis = value
            InitializeInfiltrationFunctionEditor()
        End Set
    End Property

    Public Property WinSrfrUnit() As Unit
        Get
            Return mUnit
        End Get
        Set(ByVal value As Unit)
            mUnit = value

            If (mUnit IsNot Nothing) Then
                mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef

                mInflowManagement = mUnit.InflowManagementRef
                mSystemGeometry = mUnit.SystemGeometryRef
                mSoilCropProperties = mUnit.SoilCropPropertiesRef

                mSrfrInflow = SrfrAPI.SrfrInflow(mUnit.InflowManagementRef)
                mSrfrRoughness = SrfrAPI.SrfrRoughness(mUnit.SoilCropPropertiesRef)
                mSrfrCrossSection = SrfrAPI.SrfrCrossSection(mUnit.SystemGeometryRef)

                mMyStore = mUnit.MyStore
            End If

            InitializeInfiltrationFunctionEditor()
        End Set
    End Property
    '
    ' Upstream Depth for upstream wetted perimeter calculations
    '
    Private mUpstreamDepth As Double = Double.NaN
    Public Property UpstreamDepth() As Double
        Get
            If ((mUnit IsNot Nothing) And (Double.IsNaN(mUpstreamDepth))) Then
                mUpstreamDepth = mUnit.UpstreamDepth()
            End If
            Return mUpstreamDepth
        End Get
        Set(ByVal value As Double)
            mUpstreamDepth = value
        End Set
    End Property
    '
    ' Flow Hydrographs for local wetted perimeter calculations
    '
    Private mFlowHydrographs As DataTable = Nothing
    Public Property FlowHydrographs() As DataTable
        Get
            Return mFlowHydrographs
        End Get
        Set(ByVal value As DataTable)
            mFlowHydrographs = value
        End Set
    End Property
    '
    ' Reference SRFR object for local wetted perimeter calculations
    '
    Private mRefSrfrAPI As Srfr.SrfrAPI = Nothing
    Public Property RefSrfrAPI() As Srfr.SrfrAPI
        Get
            Return mRefSrfrAPI
        End Get
        Set(ByVal value As Srfr.SrfrAPI)
            mRefSrfrAPI = value
        End Set
    End Property

#End Region

#Region " Graphics Methods "

    Private Sub UpdateGraphics()
        If (mInitialized) Then

            ' Reset SRFR object references
            mSrfrInfiltration.RefInflow = mSrfrInflow
            mSrfrInfiltration.RefRoughness = mSrfrRoughness
            mSrfrInfiltration.RefCrossSection = mSrfrCrossSection

            ' Update Depth | Volume graph as appropriate
            If (mMatchType = MatchTypes.MatchDepths) Then
                UpdateDepthGraphs()
            Else ' MatchTypes.MatchVolumes
                UpdateVolumeGraphs()
            End If

        End If
    End Sub

    Private Sub UpdateDepthGraphs()
        Try
            Dim currentVsNew As DataSet = New DataSet(mDictionary.tInfiltratedDepths.Translated) ' data for graph

            ' For most infiltration methods, Zn = Required Depth
            Dim Zn As Double = mInflowManagement.RequiredDepth.Value
            Dim c As Double = mSoilCropProperties.KostiakovC

            ' Time to infiltrate to Required Depth (Zn)
            Dim Tn As Double = mSoilCropProperties.InfiltrationTime(Zn)

            ' Time to infiltrate to 2 * Zn
            Dim Tn2 As Double = 0.0
            If (c < Zn) Then
                Zn *= 2.0
            Else
                Zn = c * 2.0
            End If
            Tn2 = mSoilCropProperties.InfiltrationTime(Zn)

            ' Limit infiltration curve to Tn*2 on X-axis or Zn*2 on Y-axis; whichever comes first
            Dim Tend As Double = Math.Min(Tn * 2.0, Tn2)

            Dim Dreq As Double = mInflowManagement.RequiredDepth.Value          ' Target infiltration depth
            Dim dreqTab As DataTable = DreqTable(Dreq, sTimeX, Tend)
            dreqTab.ExtendedProperties.Add("Color", Drawing.Color.Blue)
            '
            ' Get current Infiltration curve
            '
            Dim currentPoint As PointF = New PointF(0, 0)
            Dim currentInfiltration As DataTable = mSoilCropProperties.InfiltrationFunctionDataTable(Tend, 100)
            If (currentInfiltration IsNot Nothing) Then
                currentInfiltration.TableName = "Previous"
                currentInfiltration.Columns(1).ColumnName = "Infiltration (mm)"
                currentInfiltration.ExtendedProperties.Add("Key", True)
                currentInfiltration.ExtendedProperties.Add("Key Text", "Previous")
                currentInfiltration.ExtendedProperties.Add("Line", True)
                currentInfiltration.ExtendedProperties.Add("Color", Drawing.Color.Black)

                If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.BranchFunction) Then
                    currentPoint.X = mSoilCropProperties.BranchTime
                    currentPoint.Y = DataColumnValue(currentInfiltration, 0, currentPoint.X, 1)
                End If

                currentVsNew.Tables.Add(currentInfiltration)
            End If
            '
            ' Get new Infiltration curve
            '
            Dim newPoint As PointF = New PointF(0, 0)
            Dim newInfiltration As DataTable = Nothing

            Dim curIEtxt As String = InfiltrationEquationControl.SelectedItem
            ' Show only the selected one
            Select Case (curIEtxt)
                Case sGreenAmpt, sWarrickGreenAmpt
                    Dim h0 As Double = mUnit.UpstreamDepth() ' Use Upstream Depth for h0
                    newInfiltration = SrfrAPI.InfiltrationFunction(Tend, h0, 100, mSrfrInfiltration)
                Case Else
                    newInfiltration = SrfrAPI.InfiltrationFunction(Tend, 100, mSrfrInfiltration)
            End Select

            If (newInfiltration IsNot Nothing) Then
                newInfiltration.TableName = "Edited"
                newInfiltration.ExtendedProperties.Add("Key", True)
                newInfiltration.ExtendedProperties.Add("Key Text", "Edited")
                newInfiltration.ExtendedProperties.Add("Line", True)
                newInfiltration.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                If (curIEtxt = sBranchFunction) Then
                    Dim Tb As Double = 0.0

                    If (Me.BranchTimeEnable.Checked) Then
                        Dim TbUnits As Units = mSoilCropProperties.BranchTime_BF.DisplayUnits
                        Tb = SiValue(Me.BranchTimeUpDown.UpDownValue, TbUnits)
                    Else
                        Dim a As Double = BranAUpDown.UpDownValue

                        Dim b As Double = BranBUpDown.UpDownValue
                        Dim bParam As DoubleParameter = mSoilCropProperties.BranchB_BF
                        Dim bUnits As Units = bParam.DisplayUnits
                        b = SiVelocity(b, bUnits)

                        Dim k As Double = BranKUpDown.UpDownValue
                        Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
                        k = KostiakovKParameter.SiKostiakovK(k, a, kUnits)

                        Tb = Srfr.SrfrAPI.BranchTime(k, a, b)
                    End If

                    newPoint.X = Tb
                    newPoint.Y = DataColumnValue(newInfiltration, 0, newPoint.X, 1)
                End If

                currentVsNew.Tables.Add(newInfiltration)
            End If
            '
            ' Add Dreq line graph
            '
            currentVsNew.Tables.Add(dreqTab)
            '
            ' Set the graph's properties & draw it
            '
            Me.InfiltrationGraph.NewHotspotKeys = True
            Me.InfiltrationGraph.InitializeGraph2D(currentVsNew)
            Me.InfiltrationGraph.UnitsX = Units.Seconds
            Me.InfiltrationGraph.UnitsY = Units.Millimeters
            Me.InfiltrationGraph.DisplayKey = True
            Me.InfiltrationGraph.HorizontalKeys = True
            Me.InfiltrationGraph.FontAdjustment = 1
            Me.InfiltrationGraph.TitleAdjY = -5
            Me.InfiltrationGraph.LeftTitleAdjX = -5
            Me.InfiltrationGraph.BottomTitleAdjY = -5
            Me.InfiltrationGraph.ClearVertLines()
            Me.InfiltrationGraph.ClearTextLines()
            Me.InfiltrationGraph.ClearGraphSymbols()

            If (0 < currentPoint.X) Then
                Me.InfiltrationGraph.AddGraphSymbol(currentPoint.X, currentPoint.Y, "o", Drawing.Color.Black, 3)
            End If

            If (0 < newPoint.X) Then
                Me.InfiltrationGraph.AddGraphSymbol(newPoint.X, newPoint.Y, "o", Drawing.Color.Blue, 3)
            End If

            ' Add Upstream depth text, if appropriate
            If (mAddUpstreamDepthText) Then
                Dim textLine As String = "Based on upstream depth of " & DepthString(UpstreamDepth)
                Me.InfiltrationGraph.AddTextLine(Tend / 5, Zn / 10, textLine, Drawing.Color.Blue)
            End If

            ' Draw graph
            Me.InfiltrationGraph.DrawImage()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdateVolumeGraphs()
        Try
            Dim measuredVsPredicted As DataSet = New DataSet(mDictionary.tInfiltratedVolume.Translated) ' data for graph

            ' Have the specified event analysis compute the infiltration tables
            Dim measuredInfiltration As DataTable = mAnalysis.MeasuredInfiltrationVolumeTable
            Dim predictedInfiltration As DataTable = mAnalysis.PredictedInfiltrationVolumeTable(mSrfrInfiltration)

            Dim maxMeasTime As Double = 0.0 ' Maximum times for X-axis
            Dim maxPredTime As Double = 0.0
            Dim maxMeasVol As Double = 0.0  ' Maximum volumes for Y-axis
            Dim maxPredVol As Double = 0.0

            ' Display Measured vs. Predicted Infiltration Graph
            If (measuredInfiltration IsNot Nothing) Then
                measuredInfiltration.TableName = "Estimated"
                measuredInfiltration.ExtendedProperties.Add("Key", True)
                measuredInfiltration.ExtendedProperties.Add("Key Text", "Volume Balance")
                measuredInfiltration.ExtendedProperties.Add("Symbol", "O")
                measuredInfiltration.ExtendedProperties.Add("Line", True)
                measuredInfiltration.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                measuredVsPredicted.Tables.Add(measuredInfiltration)

                maxMeasTime = DataStore.Utilities.DataColumnMax(measuredInfiltration, nTimeX)
                maxMeasVol = DataStore.Utilities.DataColumnMax(measuredInfiltration, nInfiltrationX)
            End If

            If (predictedInfiltration IsNot Nothing) Then
                predictedInfiltration.ExtendedProperties.Add("Key", True)
                predictedInfiltration.ExtendedProperties.Add("Key Text", "Predicted")
                predictedInfiltration.ExtendedProperties.Add("Symbol", "X")
                predictedInfiltration.ExtendedProperties.Add("Line", True)
                predictedInfiltration.ExtendedProperties.Add("Color", Drawing.Color.DarkOrange)

                measuredVsPredicted.Tables.Add(predictedInfiltration)

                maxPredTime = DataStore.Utilities.DataColumnMax(predictedInfiltration, nTimeX)
                maxPredVol = DataStore.Utilities.DataColumnMax(predictedInfiltration, nInfiltrationX)
            End If

            Dim maxGraphTime As Double = Math.Max(maxMeasTime, maxPredTime) ' Maximum time for graph (X-axis)
            Dim maxGraphVol As Double = Math.Max(maxMeasVol, maxPredVol)    '    "    volume "   "   (Y-axis)

            ' Determine if, and where, TL and/or Tco vertical lines can be drawn on graph
            Dim TL As Double = mInflowManagement.TL
            Dim Tco As Double = mInflowManagement.Cutoff

            Dim TlPos As Double = Double.NaN
            Dim TcoPos As Double = Double.NaN

            If (Not Double.IsNaN(TL)) Then
                If (TL < maxGraphTime) Then
                    If (TL < maxGraphTime / 2.0) Then ' left half of graph
                        TlPos = 0.15 ' text toward bottom of graph
                    Else ' right half of graph
                        TlPos = 0.85 ' text toward top of graph
                    End If
                ElseIf (TL = maxGraphTime) Then
                    TlPos = 0.9
                End If
            End If

            If (Not Double.IsNaN(Tco)) Then
                If (Tco < maxGraphTime) Then
                    If (Tco < maxGraphTime / 2.0) Then
                        TcoPos = 0.15
                    Else
                        TcoPos = 0.85
                    End If
                ElseIf (Tco = maxGraphTime) Then
                    TcoPos = 0.9
                End If
            End If

            Me.InfiltrationGraph.NewHotspotKeys = True
            Me.InfiltrationGraph.InitializeGraph2D(measuredVsPredicted)
            Me.InfiltrationGraph.UnitsX = Units.Seconds
            Me.InfiltrationGraph.UnitsY = Units.CubicMeters
            Me.InfiltrationGraph.DisplayKey = True
            Me.InfiltrationGraph.HorizontalKeys = True
            Me.InfiltrationGraph.FontAdjustment = 1
            Me.InfiltrationGraph.TitleAdjY = -5
            Me.InfiltrationGraph.LeftTitleAdjX = -5
            Me.InfiltrationGraph.BottomTitleAdjY = -5
            Me.InfiltrationGraph.ClearVertLines()

            ' Add TL & Tco vertical lines, if on graph
            If (Not Double.IsNaN(TlPos)) Then
                Me.InfiltrationGraph.AddVertLine(TL, "TL", TlPos)
            End If

            If (Not Double.IsNaN(TcoPos)) Then
                Me.InfiltrationGraph.AddVertLine(Tco, "Tco", TcoPos)
            End If

            ' Compute & display sum-of-squares for measured vs. predicted
            Dim SS As Double = Double.NaN
            If ((measuredInfiltration IsNot Nothing) And (predictedInfiltration IsNot Nothing)) Then
                SS = SumOfSquares(measuredInfiltration, predictedInfiltration, nTimeX, nInfiltrationX)
            End If

            Me.InfiltrationGraph.ClearTextLines()
            If (predictedInfiltration Is Nothing) Then
                Me.InfiltrationGraph.AddTextLine(maxGraphTime * 0.1, maxGraphVol * 0.9, mDictionary.tNoPredictedInfiltration.ToString, Color.Black)
            ElseIf (Not Double.IsNaN(SS)) Then
                Dim ssText As String = mDictionary.tSumOfSquares.Translated & " = " & Format(SS, "0.00#e+00") ' l²
                Me.InfiltrationGraph.AddTextLine(maxGraphTime * 0.1, maxGraphVol * 0.9, ssText, Color.Black)
            End If

            ' Draw graph
            Me.InfiltrationGraph.DrawImage()

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " UI Methods "

#Region " Infiltration Function Editor "
    '
    ' Initialization starts here; chains through properties
    '
    Private Sub InitializeInfiltrationFunctionEditor()

        Select Case mMatchType
            Case MatchTypes.MatchDepths
                Me.HelpText.Text = mDictionary.tInfiltrationEditorDepthsHelpText.Translated
            Case Else
                Me.HelpText.Text = mDictionary.tInfiltrationEditorVolumeHelpText.Translated
        End Select

        ' Initialization continues with wetted perimeter
        InitializeWettedPerimeterMethod()

    End Sub

#End Region

#Region " Wetted Perimeter "
    '
    ' Initialize display of Wetted Perimeter Method
    '
    Private Sub InitializeWettedPerimeterMethod()

        If ((mUnit IsNot Nothing) And (mAnalysis IsNot Nothing)) Then

            ' Wetted Perimeter only applies to Furrows
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

                Dim curWPval As Integer = mSoilCropProperties.WettedPerimeterMethod.Value
                Dim curWPtxt As String = WettedPerimeterMethodSelections(curWPval).Value

                ' Update selection list
                mAnalysis.LoadWettedPerimeterControl(WettedPerimeterControl)

                For idx As Integer = 0 To WettedPerimeterControl.Items.Count - 1
                    Dim txt As String = WettedPerimeterControl.Items(idx)
                    If (txt = curWPtxt) Then
                        WettedPerimeterControl.SelectedIndex = idx
                        Exit For
                    End If
                Next idx

                WettedPerimeterLabel.Show()
                WettedPerimeterControl.Show()

            Else ' Basin / Border

                Me.WettedPerimeterLabel.Hide()
                Me.WettedPerimeterControl.Hide()

            End If

            ' Initialization continues with infiltratino equation
            InitializeInfiltrationEquationMethod()

            mInitialized = True

            UpdateInfiltrationParameters()
        End If

    End Sub

#End Region

#Region " Infiltration Equation "
    '
    ' Initialize display of Infiltration Equation Method
    '
    Private Sub InitializeInfiltrationEquationMethod()

        If (mUnit IsNot Nothing) Then

            Dim curWPtxt As String = WettedPerimeterControl.SelectedItem
            Dim curWPval As WettedPerimeterMethods = Globals.WettedPerimeterMethod(curWPtxt)

            Dim curIEval As Integer = mSoilCropProperties.InfiltrationFunction.Value
            Dim curIEtxt As String = InfiltrationFunctionSelections(curIEval).Value

            ' Update selection list
            mAnalysis.LoadInfiltrationEquationControl(InfiltrationEquationControl, curWPval, 0, False)

            ' Remove unsupported Infiltration Equations (e.g. HYDRUS-1D)
            For idx As Integer = 0 To InfiltrationEquationControl.Items.Count - 1
                Dim txt As String = InfiltrationEquationControl.Items(idx)
                If (txt = sHydrus1D) Then
                    InfiltrationEquationControl.Items.RemoveAt(idx)
                    Exit For
                End If
            Next idx

            ' Select current Infiltration Equation
            For idx As Integer = 0 To InfiltrationEquationControl.Items.Count - 1
                Dim txt As String = InfiltrationEquationControl.Items(idx)
                If (txt = curIEtxt) Then
                    InfiltrationEquationControl.SelectedIndex = idx
                    Exit For
                End If
            Next idx

            If (InfiltrationEquationControl.SelectedIndex < 0) Then
                InfiltrationEquationControl.SelectedIndex = 0
            End If

            ' Initialize individual infiltration equation options
            InitializeCharacteristicInfiltrationTime()
            InitializeTimeRatedIntakeFamily()
            InitializeNrcsIntakeFamily()
            InitializeKostiakovFormula()
            InitializeModifiedKostiakov()
            InitializeBranchFunction()
            InitializeGreenAmpt()
            InitializeWarrickGreenAmpt()

            UpdateInfiltrationParameters()
        End If

    End Sub
    '
    ' Update display of Infiltration Equation Method
    '
    Private Sub UpdateInfiltrationEquationMethod()

        If (mUnit IsNot Nothing) Then

            Dim curWPtxt As String = WettedPerimeterControl.SelectedItem
            Dim curWPval As WettedPerimeterMethods = Globals.WettedPerimeterMethod(curWPtxt)

            Dim curIEval As Integer = mSoilCropProperties.InfiltrationFunction.Value
            Dim curIEtxt As String = InfiltrationFunctionSelections(curIEval).Value
            If (0 <= InfiltrationEquationControl.SelectedIndex) Then
                curIEtxt = InfiltrationEquationControl.SelectedItem
            End If

            ' Update selection list
            mAnalysis.LoadInfiltrationEquationControl(InfiltrationEquationControl, curWPval, 0, False)

            For idx As Integer = 0 To InfiltrationEquationControl.Items.Count - 1
                Dim txt As String = InfiltrationEquationControl.Items(idx)
                If (txt = curIEtxt) Then
                    InfiltrationEquationControl.SelectedIndex = idx
                    Exit For
                End If
            Next idx

            If (InfiltrationEquationControl.SelectedIndex < 0) Then
                InfiltrationEquationControl.SelectedIndex = 0
            End If
        End If

    End Sub

#End Region

#Region " Infiltration Parameters "
    '
    ' Update display of Infiltration Parameters
    '
    Private Sub UpdateInfiltrationParameters()

        ' Get currently selected Infiltration Equation
        Dim curIEtxt As String = InfiltrationEquationControl.SelectedItem

        ' Hide all panels
        Me.BranchFunctionPanel.Hide()
        Me.CharacteristicInfiltrationPanel.Hide()
        Me.KostiakovPanel.Hide()
        Me.ModifiedKostiakovPanel.Hide()
        Me.TimeRatedIntakePanel.Hide()
        Me.NrcsIntakePanel.Hide()
        Me.GreenAmptPanel.Hide()
        Me.WarrickGreenAmptPanel.Hide()
        Me.HydrusPanel.Hide()

        If (curIEtxt IsNot Nothing) Then
            ' Show only selected one
            Select Case (curIEtxt)
                Case sKostiakovFormula
                    Me.MatchButton.Show()
                    Me.KostiakovPanel.Show()
                    UpdateKostiakovFormula()
                Case sModifiedKostiakovFormula
                    Me.MatchButton.Show()
                    Me.ModifiedKostiakovPanel.Show()
                    UpdateModifiedKostiakov()
                Case sBranchFunction
                    Me.MatchButton.Hide()
                    Me.BranchFunctionPanel.Show()
                    UpdateBranchFunction()
                Case sCharacteristicInfiltrationTime
                    Me.MatchButton.Show()
                    Me.CharacteristicInfiltrationPanel.Show()
                    UpdateCharacteristicInfiltrationTime()
                Case sTimeRatedIntakeFamily
                    Me.MatchButton.Show()
                    Me.TimeRatedIntakePanel.Show()
                    UpdateTimeRatedIntakeFamily()
                Case sNrcsIntakeFamily
                    Me.MatchButton.Show()
                    Me.NrcsIntakePanel.Show()
                    UpdateNrcsIntakeFamily()
                Case sGreenAmpt
                    Me.MatchButton.Hide()
                    Me.GreenAmptPanel.Show()
                    UpdateGreenAmpt()
                Case sWarrickGreenAmpt
                    Me.MatchButton.Hide()
                    Me.WarrickGreenAmptPanel.Show()
                    UpdateWarrickGreenAmpt()
                Case sHydrus1D
                    Me.MatchButton.Hide()
                    Me.HydrusPanel.Show()
                Case Else
                    Debug.Assert(False)
            End Select
        End If

    End Sub

#End Region

#Region " Characteristic Infiltration Time "

    Private Sub InitializeCharacteristicInfiltrationTime()
        If (mSoilCropProperties IsNot Nothing) Then
            '
            ' Load WinSRFR's Characteristic Infiltration Time parameters into editor
            '
            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_KT
            Dim a As Double = aParam.Value

            Dim dParam As DoubleParameter = mSoilCropProperties.InfiltrationDepth_KT
            Dim d As Double = dParam.Value
            Dim dUnits As Units = dParam.DisplayUnits

            Dim tParam As DoubleParameter = mSoilCropProperties.InfiltrationTime_KT
            Dim t As Double = tParam.Value
            Dim tUnits As Units = tParam.DisplayUnits

            Me.KcitAUpDown.UpDownValue = a
            Me.KcitAUpDown.DisplayUnits = aParam.UnitsString

            Me.KcitDepthUpDown.UpDownValue = UnitDepth(d, dUnits)
            Me.KcitDepthUpDown.DisplayUnits = dParam.UnitsString

            Me.KcitTimeUpDown.UpDownValue = UnitTime(t, tUnits)
            Me.KcitTimeUpDown.DisplayUnits = tParam.UnitsString
        End If
    End Sub

    Private Sub UpdateCharacteristicInfiltrationTime()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load WinSRFR's Characteristic Infiltration Time parameters into SRFR Infiltration object
            '
            Dim srfrInf As Srfr.CharacteristicInfiltrationTime = SrfrAPI.SrfrCharacteristicInfiltrationTime(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            Dim a As Double = Me.KcitAUpDown.UpDownValue
            srfrInf.a = a

            Dim UiD As Double = Me.KcitDepthUpDown.UpDownValue
            Dim dParam As DoubleParameter = mSoilCropProperties.InfiltrationDepth_KT
            Dim dUnits As Units = dParam.DisplayUnits
            Dim SiD As Double = SiDepth(UiD, dUnits)
            srfrInf.CharInfiltrationDepth = SiD

            Dim UiT As Double = Me.KcitTimeUpDown.UpDownValue
            Dim tParam As DoubleParameter = mSoilCropProperties.InfiltrationTime_KT
            Dim tUnits As Units = tParam.DisplayUnits
            Dim SiT As Double = SiTime(UiT, tUnits)
            srfrInf.CharInfiltrationTime = SiT

            ' Update display
            Dim Tn As Double = srfrInf.CharInfiltrationTime ' SI units
            Dim k As Double = Srfr.SrfrAPI.KostiakovK(SiD, Tn, a)
            Dim kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

            Me.KcitK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, kunits)

            mSrfrInfiltration = srfrInf

            mAddUpstreamDepthText = False

            UpdateGraphics()
        End If
    End Sub

    Private Sub MatchCharacteristicInfiltrationTime()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then

            ' Load WinSRFR's infiltration parameters & object data into SRFR Infiltration object
            Dim srfrInf As Srfr.CharacteristicInfiltrationTime = SrfrCharacteristicInfiltrationTime(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            srfrInf.RefCrossSection = mSrfrCrossSection
            srfrInf.RefInflow = mSrfrInflow
            srfrInf.RefRoughness = mSrfrRoughness

            ' Get Infiltration Depth from the WinSRFR's infiltration function
            Dim DepthSI As Double = mInflowManagement.RequiredDepth.Value

            ' Get Infiltration Time for Depth from the WinSRFR's infiltration function
            Dim TimeSI As Double = mSoilCropProperties.InfiltrationTime(DepthSI)

            Select Case (srfrInf.WettedPerimeterMethod)
                Case Srfr.Infiltration.WettedPerimeterMethods.BorderWidth, _
                     Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing

                    ' Load editor's Kostiakov a into SRFR Infiltration object
                    Dim a As Double = Me.KcitAUpDown.UpDownValue
                    srfrInf.a = a

                    ' Load editor's Characteristic Depth into SRFR Infiltration object
                    Dim UnitsUI As String = Me.KcitDepthUpDown.DisplayUnits ' UI Units for Time
                    Dim UnitsEN As Units = UnitsFromString(UnitsUI) ' Enumerated Units
                    Dim ZnUI As Double = Me.KcitDepthUpDown.UpDownValue ' UI depth
                    Dim Zn As Double = SiDepth(ZnUI, UnitsEN) ' SI depth
                    srfrInf.CharInfiltrationDepth = Zn

                    ' Calculate Infiltration Time for editor's Characteristic Depth
                    Dim Tn As Double = srfrInf.CalcCharInfiltrationTime(DepthSI, TimeSI) ' Infiltration Time in SI units

                    ' Save Infiltration Time as new Characteristic Infiltration Time
                    UnitsUI = Me.KcitTimeUpDown.DisplayUnits ' UI Units for Time
                    UnitsEN = UnitsFromString(UnitsUI) ' Enumerated Units
                    Dim TnUI As Double = UnitTime(Tn, UnitsEN) ' Infiltration Time in UI units
                    KcitTimeUpDown.UpDownValue = TnUI

                    ' Update display
                    UpdateCharacteristicInfiltrationTime()

                Case Else ' Others are not compatible with Characteristic Infiltration Time
                    Debug.Assert(False)
            End Select

        End If
    End Sub

    Private Sub SaveCharacteristicInfiltrationTime()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Save editor's Characteristic Infiltration Time parameters into WinSRFR's DataStore
            '
            mMyStore.MarkForUndo("Characteristic Infiltration Time Edits")

            mSoilCropProperties.MyStore.EventsEnabled = False

            ' Save Infiltration Equation then Wetted Perimeter
            SaveInfiltrationEquation()
            SaveWettedPerimeter()

            ' Save Infiltration Parameters
            Dim a As Double = Me.KcitAUpDown.UpDownValue
            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_KT
            aParam.Value = a
            aParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovA_KT = aParam

            Dim d As Double = Me.KcitDepthUpDown.UpDownValue
            Dim dParam As DoubleParameter = mSoilCropProperties.InfiltrationDepth_KT
            Dim dUnits As Units = dParam.DisplayUnits
            dParam.Value = SiDepth(d, dUnits)
            dParam.Source = ValueSources.UserEntered
            mSoilCropProperties.InfiltrationDepth_KT = dParam

            mSoilCropProperties.MyStore.EventsEnabled = True

            Dim t As Double = Me.KcitTimeUpDown.UpDownValue
            Dim tParam As DoubleParameter = mSoilCropProperties.InfiltrationTime_KT
            Dim tUnits As Units = tParam.DisplayUnits
            tParam.Value = SiTime(t, tUnits)
            tParam.Source = ValueSources.UserEntered
            mSoilCropProperties.InfiltrationTime_KT = tParam
        End If
    End Sub

#End Region

#Region " Time-Rated Intake Family "

    Private Sub InitializeTimeRatedIntakeFamily()
        If (mSoilCropProperties IsNot Nothing) Then
            '
            ' Load WinSRFR's Time-Rated Intake Family parameters into editor
            '
            Dim tParam As DoubleParameter = mSoilCropProperties.InfiltrationTime_TR
            Dim t As Double = tParam.Value
            Dim tUnits As Units = tParam.DisplayUnits

            Me.TrifTimeUpDown.UpDownValue = UnitTime(t, tUnits)
            Me.TrifTimeUpDown.DisplayUnits = tParam.UnitsString
        End If
    End Sub

    Private Sub UpdateTimeRatedIntakeFamily()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load WinSRFR's Time-Rated Intake Family parameters into SRFR Infiltration object
            '
            Dim srfrInf As Srfr.TimeRatedIntakeFamily = SrfrAPI.SrfrTimeRatedIntakeFamily(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            Dim t As Double = Me.TrifTimeUpDown.UpDownValue
            Dim tParam As DoubleParameter = mSoilCropProperties.InfiltrationTime_TR
            Dim tUnits As Units = tParam.DisplayUnits
            srfrInf.CorrInfiltrationTime = SiTime(t, tUnits)

            ' Update display
            Dim Tn As Double = srfrInf.CorrInfiltrationTime ' SI units
            Dim a As Double = Srfr.SrfrAPI.NrcsA(Tn)
            Dim k As Double = Srfr.SrfrAPI.KostiakovK(Depth100mm, Tn, a)
            Dim kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

            Me.TrifA.Text = "a = " + Format(a, "0.00#")
            Me.TrifK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, kunits)

            mSrfrInfiltration = srfrInf

            mAddUpstreamDepthText = True

            UpdateGraphics()
        End If
    End Sub

    Private Sub MatchTimeRatedIntakeFamily()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then

            ' Load WinSRFR's infiltration parameters & object data into SRFR Infiltration object
            Dim srfrInf As Srfr.TimeRatedIntakeFamily = SrfrTimeRatedIntakeFamily(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            srfrInf.RefCrossSection = mSrfrCrossSection
            srfrInf.RefInflow = mSrfrInflow
            srfrInf.RefRoughness = mSrfrRoughness

            ' Get Infiltration Depth from the WinSRFR's infiltration function
            Dim DepthSI As Double = mInflowManagement.RequiredDepth.Value

            ' Get Infiltration Time for Depth from the WinSRFR's infiltration function
            Dim TimeSI As Double = mSoilCropProperties.InfiltrationTime(DepthSI, UpstreamDepth)

            Select Case (srfrInf.WettedPerimeterMethod)
                Case Srfr.Infiltration.WettedPerimeterMethods.BorderWidth, _
                     Srfr.Infiltration.WettedPerimeterMethods.Local, _
                     Srfr.Infiltration.WettedPerimeterMethods.RepresentativeUpstream

                    Dim Tn As Double = srfrInf.CalcCorrInfiltrationTime(DepthSI, TimeSI, UpstreamDepth)

                    ' Save Characteristic Infiltration Time as new Time-Rated Intake Family Time
                    Dim UnitsUI As String = Me.TrifTimeUpDown.DisplayUnits ' UI Units for Time
                    Dim UnitsEN As Units = UnitsFromString(UnitsUI) ' Enumerated Units
                    Dim TnUI As Double = UnitTime(Tn, UnitsEN) ' Characteristic Infiltration Time in UI units
                    Me.TrifTimeUpDown.UpDownValue = TnUI

                    ' Update display
                    UpdateTimeRatedIntakeFamily()

                Case Else ' Others are not compatible with Time-Rated Intake Family
                    Debug.Assert(False)
            End Select

        End If
    End Sub

    Private Sub SaveTimeRatedIntakeFamily()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Save Time-Rated Intake Family parameters into the DataStore
            '
            mMyStore.MarkForUndo("Time-Rated Intake Family Edits")

            ' Save Infiltration Equation then Wetted Perimeter
            SaveInfiltrationEquation()
            SaveWettedPerimeter()

            ' Save Infiltration Parameters
            Dim t As Double = Me.TrifTimeUpDown.UpDownValue
            Dim tParam As DoubleParameter = mSoilCropProperties.InfiltrationTime_TR
            Dim tUnits As Units = tParam.DisplayUnits
            tParam.Value = SiTime(t, tUnits)
            tParam.Source = ValueSources.UserEntered
            mSoilCropProperties.InfiltrationTime_TR = tParam
        End If
    End Sub

#End Region

#Region " NRCS Intake Family "

    Private Sub InitializeNrcsIntakeFamily()
        If (mSoilCropProperties IsNot Nothing) Then
            '
            ' Load WinSRFR's NRCS Intake Family parameters into the editor
            '
            Dim nrcsParam As IntegerParameter = mSoilCropProperties.NrcsIntakeFamily
            mNrcsIntakeFamily = nrcsParam.Value
            Me.CheckNrcsIntakeFamilyButton()
        End If
    End Sub

    Private Sub CheckNrcsIntakeFamilyButton()

        Select Case (mNrcsIntakeFamily)
            Case NrcsIntakeFamilies.Family005
                NrcsFamily005Button.Checked = True
            Case NrcsIntakeFamilies.Family010
                NrcsFamily010Button.Checked = True
            Case NrcsIntakeFamilies.Family015
                NrcsFamily015Button.Checked = True
            Case NrcsIntakeFamilies.Family020
                NrcsFamily020Button.Checked = True
            Case NrcsIntakeFamilies.Family025
                NrcsFamily025Button.Checked = True
            Case NrcsIntakeFamilies.Family030
                NrcsFamily030Button.Checked = True
            Case NrcsIntakeFamilies.Family035
                NrcsFamily035Button.Checked = True
            Case NrcsIntakeFamilies.Family040
                NrcsFamily040Button.Checked = True
            Case NrcsIntakeFamilies.Family045
                NrcsFamily045Button.Checked = True
            Case NrcsIntakeFamilies.Family050
                NrcsFamily050Button.Checked = True
            Case NrcsIntakeFamilies.Family060
                NrcsFamily060Button.Checked = True
            Case NrcsIntakeFamilies.Family070
                NrcsFamily070Button.Checked = True
            Case NrcsIntakeFamilies.Family080
                NrcsFamily080Button.Checked = True
            Case NrcsIntakeFamilies.Family090
                NrcsFamily090Button.Checked = True
            Case NrcsIntakeFamilies.Family100
                NrcsFamily100Button.Checked = True
            Case NrcsIntakeFamilies.Family150
                NrcsFamily150Button.Checked = True
            Case NrcsIntakeFamilies.Family200
                NrcsFamily200Button.Checked = True
            Case NrcsIntakeFamilies.Family300
                NrcsFamily300Button.Checked = True
            Case NrcsIntakeFamilies.Family400
                NrcsFamily400Button.Checked = True
        End Select

    End Sub

    Private Sub UpdateNrcsIntakeFamily()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load WinSRFR's NRCS Intake Family parameters into SRFR Infiltration object
            '
            Dim nrcsOption As Srfr.NrcsIntakeFamily.NrcsIntakeOptions = mSoilCropProperties.NrcsToKostiakovMethod.Value
            Dim nrcsValues As Srfr.NrcsIntakeFamily.NrcsIntakeValues = Srfr.NrcsIntakeFamily.NrcsIntakeFamilyValues(mNrcsIntakeFamily, nrcsOption)
            Dim k As Double = nrcsValues.k
            Dim a As Double = nrcsValues.a

            Dim c As Double = 0.0
            Select Case (nrcsOption)
                Case Srfr.NrcsIntakeFamily.NrcsIntakeOptions.ApproximateByBestFit
                    c = 0.0
                Case Else ' Assume NrcsToKostiakovMethods.DescribeByNrcsFormula
                    c = Depth7mm
            End Select

            Dim srfrInf As Srfr.NrcsIntakeFamily = SrfrAPI.SrfrNrcsIntakeFamily(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            srfrInf.NrcsFamily = mNrcsIntakeFamily
            srfrInf.NrcsOption = nrcsOption
            srfrInf.c = c

            ' Update display
            Dim kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            NrcsK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, kunits)
            NrcsA.Text = "a = " + Format(a, "0.00#")
            NrcsC.Text = "c = " + DepthString(c)

            mSrfrInfiltration = srfrInf

            mAddUpstreamDepthText = False

            UpdateGraphics()
        End If
    End Sub

    Private Sub MatchNrcsIntakeFamily()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then

            ' Load WinSRFR's infiltration parameters & object data into SRFR Infiltration object
            Dim srfrInf As Srfr.NrcsIntakeFamily = SrfrNrcsIntakeFamily(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            srfrInf.RefCrossSection = mSrfrCrossSection
            srfrInf.RefInflow = mSrfrInflow
            srfrInf.RefRoughness = mSrfrRoughness

            ' Get Infiltration Depth from the WinSRFR's infiltration function
            Dim DepthSI As Double = mInflowManagement.RequiredDepth.Value

            ' Get Infiltration Time for Depth from the WinSRFR's infiltration function
            Dim TimeSI As Double = mSoilCropProperties.InfiltrationTime(DepthSI, UpstreamDepth)

            Select Case (srfrInf.WettedPerimeterMethod)
                Case Srfr.Infiltration.WettedPerimeterMethods.BorderWidth, _
                     Srfr.Infiltration.WettedPerimeterMethods.NRCS

                    Dim Df As Double = Double.MaxValue

                    Dim tableSize As Integer = Srfr.NrcsIntakeFamily.NrcsIntakeFamilyTableSize

                    Dim nrcsOption As Srfr.NrcsIntakeFamily.NrcsIntakeOptions = mSoilCropProperties.NrcsToKostiakovMethod.Value
                    Dim nrcsFamily As Srfr.NrcsIntakeFamily.NrcsIntakeFamilies

                    Dim Zr As Double = mInflowManagement.RequiredDepth.Value
                    Dim Zl As Double = Zr / 2.0
                    Dim Tr As Double = mSoilCropProperties.InfiltrationTime(Zr)
                    Dim Tl As Double = mSoilCropProperties.InfiltrationTime(Zl)

                    For nrcsFamily = 0 To tableSize - 1

                        srfrInf.NrcsFamily = nrcsFamily
                        srfrInf.NrcsOption = nrcsOption

                        Dim Dr As Double = srfrInf.InfiltrationDepth(Tr)
                        Dim Dl As Double = srfrInf.InfiltrationDepth(Tl)

                        Dim Dd As Double = (Math.Abs(Zr - Dr) + Math.Abs(Zl - Dl))

                        If (Dd < Df) Then
                            mNrcsIntakeFamily = nrcsFamily
                            Df = Dd
                        End If
                    Next nrcsFamily

                    Me.CheckNrcsIntakeFamilyButton()
                    Me.UpdateNrcsIntakeFamily()

                Case Else ' Others are not compatible with NRCS Intake Family
                    Debug.Assert(False)
            End Select

        End If
    End Sub

    Private Sub SaveNrcsIntakeFamily()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Save NRCS Intake Family parameters into the DataStore
            '
            mMyStore.MarkForUndo("NRCS Intake Family Edits")

            ' Save Infiltration Equation then Wetted Perimeter
            SaveInfiltrationEquation()
            SaveWettedPerimeter()

            ' Save Infiltration Parameters
            Dim nrcsParam As IntegerParameter = mSoilCropProperties.NrcsIntakeFamily
            nrcsParam.Value = mNrcsIntakeFamily
            nrcsParam.Source = ValueSources.UserEntered
            mSoilCropProperties.NrcsIntakeFamily = nrcsParam
        End If

    End Sub

#End Region

#Region " Kostiakov Formula "

    Private Sub InitializeKostiakovFormula()
        If (mSoilCropProperties IsNot Nothing) Then
            '
            ' Load Kostiakov Formula parameters into the editor
            '
            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_KF
            Dim a As Double = aParam.Value

            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_KF
            Dim k As Double = kParam.Value

            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

            Me.KostAUpDown.UpDownValue = a
            Me.KostAUpDown.DisplayUnits = aParam.UnitsString

            Me.KostKUpDown.UpDownValue = KostiakovKParameter.UnitKostiakovK(k, a, kUnits)
            Me.KostKUpDown.DisplayUnits = KostiakovKParameter.K_UnitsText(kUnits)
        End If
    End Sub

    Private Sub UpdateKostiakovFormula()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load Kostiakov Formula parameters into the SRFR Infiltration object
            '
            Dim srfrInf As Srfr.KostiakovFormula = SrfrAPI.SrfrKostiakovFormula(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            Dim a As Double = KostAUpDown.UpDownValue
            srfrInf.a = a

            Dim k As Double = KostKUpDown.UpDownValue
            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_KF
            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            srfrInf.k = KostiakovKParameter.SiKostiakovK(k, a, kUnits)

            mSrfrInfiltration = srfrInf

            Select Case (srfrInf.WettedPerimeterMethod)
                Case Srfr.Infiltration.WettedPerimeterMethods.BorderWidth, _
                     Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing
                    mAddUpstreamDepthText = False
                Case Srfr.Infiltration.WettedPerimeterMethods.Local, _
                     Srfr.Infiltration.WettedPerimeterMethods.RepresentativeUpstream
                    mAddUpstreamDepthText = True
                Case Else ' Others are not compatible with Kostiakov Formula
                    Debug.Assert(False)
            End Select

            UpdateGraphics()
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub MatchKostiakov() - general match method for Kostiakov a & k
    '
    ' Input(s):     srfrInf     - reference to Srfr.Infiltration object
    '               c           - Kostiakov c
    '
    ' Output(s):    a           - Kostiakov a
    '               k           -     "     k
    '
    ' Note - calculation is Furrow Spacing / Border Width based so an adjustment to k is required for
    '        wetted perimeter infiltration
    '*********************************************************************************************************
    Private Sub MatchKostiakov(ByVal srfrInf As Srfr.Infiltration, ByVal c As Double, _
                               ByRef a As Double, ByRef k As Double)

        Dim Zr As Double = mInflowManagement.RequiredDepth.Value - c
        Dim Zl As Double = Zr / 2.0
        Dim Tr As Double = mSoilCropProperties.InfiltrationTime(Zr)
        Dim Tl As Double = mSoilCropProperties.InfiltrationTime(Zl)

        ' Furrow spacing / Border width calculation
        a = (Math.Log(Zr) - Math.Log(Zl)) / (Math.Log(Tr) - Math.Log(Tl))
        k = Zr / (Tr ^ a)

        Select Case (srfrInf.WettedPerimeterMethod)
            Case Srfr.Infiltration.WettedPerimeterMethods.BorderWidth, _
                 Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing

                ' No adjustment required

            Case Srfr.Infiltration.WettedPerimeterMethods.Local, _
                 Srfr.Infiltration.WettedPerimeterMethods.RepresentativeUpstream

                ' Check for overflow conditions which may limit match results
                Dim Y0 As Double = mUnit.UpstreamDepth()
                If (Y0 > mSystemGeometry.MaximumDepth.Value) Then ' Upstream depth overflow

                    Dim title As String = mDictionary.tInfiltrationFunctionEditor.Translated

                    Dim msg As String = mDictionary.tOverflowMayExist.Translated & Chr(10)
                    msg &= Chr(10)
                    msg &= mDictionary.tVerifyMatchResults.Translated & Chr(10)

                    MsgBox(msg, MsgBoxStyle.Exclamation, title)
                End If

                ' Parameters for Wetted Perimeter adjustment
                Dim WP As Double = mUnit.UpstreamWettedPerimeter()
                Dim FS As Double = mSystemGeometry.FurrowSpacing.Value

                ' Adjust for wetted perimeter infiltration
                k *= FS / WP ' adjust for WP change

            Case Else ' Others are not compatible with Kostiakov Formula
                Debug.Assert(False)
        End Select

    End Sub

    Private Sub MatchKostiakovFormula()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then

            ' Load WinSRFR's infiltration parameters & object data into SRFR Infiltration object
            Dim srfrInf As Srfr.KostiakovFormula = SrfrKostiakovFormula(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            srfrInf.RefCrossSection = mSrfrCrossSection
            srfrInf.RefInflow = mSrfrInflow
            srfrInf.RefRoughness = mSrfrRoughness

            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

            ' Match Kostiakov a & k to original infiltration
            Dim a, k As Double
            Dim c As Double = 0.0
            MatchKostiakov(srfrInf, c, a, k)

            ' Update display
            Me.KostAUpDown.UpDownValue = a

            Me.KostKUpDown.UpDownValue = KostiakovKParameter.UnitKostiakovK(k, a, kUnits)
            Me.KostKUpDown.DisplayUnits = KostiakovKParameter.K_UnitsText(kUnits)

            UpdateKostiakovFormula()

        End If
    End Sub

    Private Sub SaveKostiakovFormula()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Save Modified Kostiakov parameters into the DataStore
            '
            mMyStore.MarkForUndo("Kostiakov Edits")

            mSoilCropProperties.MyStore.EventsEnabled = False

            ' Save Infiltration Equation then Wetted Perimeter
            SaveInfiltrationEquation()
            SaveWettedPerimeter()

            ' Save Infiltration Parameters
            Dim k As Double = KostKUpDown.UpDownValue ' save k first
            Dim aOld As Double = mSoilCropProperties.KostiakovA_KF.Value

            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_KF
            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            kParam.Value = KostiakovKParameter.SiKostiakovK(k, aOld, kUnits)
            kParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovK_KF = kParam

            mSoilCropProperties.MyStore.EventsEnabled = True

            Dim a As Double = KostAUpDown.UpDownValue ' then a
            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_KF
            aParam.Value = a
            aParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovA_KF = aParam
        End If
    End Sub

#End Region

#Region " Modified Kostiakov Formula "

    Private Sub InitializeModifiedKostiakov()
        If (mSoilCropProperties IsNot Nothing) Then
            '
            ' Load the Modified Kostiakov parameters into the editor
            '
            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_MK
            Dim a As Double = aParam.Value

            Dim bParam As DoubleParameter = mSoilCropProperties.KostiakovB_MK
            Dim b As Double = bParam.Value
            Dim bUnits As Units = bParam.DisplayUnits

            Dim cParam As DoubleParameter = mSoilCropProperties.KostiakovC_MK
            Dim c As Double = cParam.Value
            Dim cUnits As Units = cParam.DisplayUnits

            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_MK
            Dim k As Double = kParam.Value
            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

            MkosAUpDown.UpDownValue = a
            MkosAUpDown.DisplayUnits = aParam.UnitsString

            MkosBUpDown.UpDownValue = UnitVelocity(b, bUnits)
            MkosBUpDown.DisplayUnits = bParam.UnitsString

            MkosCUpDown.UpDownValue = UnitDepth(c, cUnits)
            MkosCUpDown.DisplayUnits = cParam.UnitsString

            MkosKUpDown.UpDownValue = KostiakovKParameter.UnitKostiakovK(k, a, kUnits)
            MkosKUpDown.DisplayUnits = KostiakovKParameter.K_UnitsText(kUnits)
        End If
    End Sub

    Private Sub UpdateModifiedKostiakov()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load Modified Kostiakov parameters into the SRFR Infiltration object
            '
            Dim srfrInf As Srfr.ModifiedKostiakov = SrfrAPI.SrfrModifiedKostiakov(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            Dim a As Double = MkosAUpDown.UpDownValue
            srfrInf.a = a

            Dim b As Double = MkosBUpDown.UpDownValue
            Dim bParam As DoubleParameter = mSoilCropProperties.KostiakovB_MK
            Dim bUnits As Units = bParam.DisplayUnits
            srfrInf.b = SiVelocity(b, bUnits)

            Dim c As Double = MkosCUpDown.UpDownValue
            Dim cParam As DoubleParameter = mSoilCropProperties.KostiakovC_MK
            Dim cUnits As Units = cParam.DisplayUnits
            srfrInf.c = SiDepth(c, cUnits)

            Dim k As Double = MkosKUpDown.UpDownValue
            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_MK
            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            srfrInf.k = KostiakovKParameter.SiKostiakovK(k, a, kUnits)

            mSrfrInfiltration = srfrInf

            Select Case (srfrInf.WettedPerimeterMethod)
                Case Srfr.Infiltration.WettedPerimeterMethods.BorderWidth, _
                     Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing
                    mAddUpstreamDepthText = False
                Case Srfr.Infiltration.WettedPerimeterMethods.Local, _
                     Srfr.Infiltration.WettedPerimeterMethods.RepresentativeUpstream
                    mAddUpstreamDepthText = True
                Case Else ' Others are not compatible with Kostiakov Formula
                    Debug.Assert(False)
            End Select

            UpdateGraphics()
        End If
    End Sub

    Private Sub MatchModifiedKostiakov()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then

            ' Load WinSRFR's infiltration parameters & object data into SRFR Infiltration object
            Dim srfrInf As Srfr.ModifiedKostiakov = SrfrModifiedKostiakov(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            srfrInf.RefCrossSection = mSrfrCrossSection
            srfrInf.RefInflow = mSrfrInflow
            srfrInf.RefRoughness = mSrfrRoughness

            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            Dim bUnits As Units = mSoilCropProperties.KostiakovB_MK.DisplayUnits
            Dim cUnits As Units = mSoilCropProperties.KostiakovC_MK.DisplayUnits

            Dim Q0 As Double = mInflowManagement.AverageInflowRateForCrossSection
            Dim S0 As Double = mSystemGeometry.AverageSlope
            Dim Beta As Double = mUnit.Beta(S0)

            If (PreviousIsModifiedKostiakovBased()) Then

                If (WettedPerimetersMatch(srfrInf)) Then
                    ' Use values loaded above
                Else ' Wetted Perimeter changing; match required
                    Dim wpMethod As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value

                    Select Case (wpMethod)
                        Case WettedPerimeterMethods.FurrowSpacing
                            Select Case (srfrInf.WettedPerimeterMethod)
                                Case Srfr.Infiltration.WettedPerimeterMethods.RepresentativeUpstream
                                    srfrInf.ConvertFS2WP0(Q0, Beta) ' FS -> WP0
                                Case Else
                                    Debug.Assert(False) ' FS -> ???
                            End Select
                        Case WettedPerimeterMethods.LocalWettedPerimeter
                            Debug.Assert(False) ' LWP -> ???
                        Case WettedPerimeterMethods.NrcsEmpiricalFunction
                            Debug.Assert(False) ' NRCS -> ???
                        Case Else ' RUWP
                            Select Case (srfrInf.WettedPerimeterMethod)
                                Case Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing
                                    srfrInf.ConvertWP02FS(Q0, Beta) ' WP0 -> FS
                                Case Else
                                    Debug.Assert(False) ' WP0 -> ???
                            End Select
                    End Select
                End If

            Else ' If (PreviousIsBranchFunctionBased()) Then

                ' Match Kostiakov a & k to original infiltration
                Dim a, k As Double
                srfrInf.b = 0.0
                srfrInf.c = 0.0
                MatchKostiakov(srfrInf, srfrInf.c, a, k)

                srfrInf.a = a
                srfrInf.k = k

                'Debug.Assert(False) ' BF -> ???
                'Return
                'ElseIf (PreviousIsGreenAmptBased()) Then
                '    Debug.Assert(False) ' GA -> ???
                '    Return
                'ElseIf (PreviousIsWarrickGreenAmptBased()) Then
                '    Debug.Assert(False) ' WGA -> ???
                '    Return
                'Else
                '    Debug.Assert(False)
                '    Return
            End If

            Me.MkosKUpDown.UpDownValue = KostiakovKParameter.UnitKostiakovK(srfrInf.k, srfrInf.a, kUnits)
            Me.MkosKUpDown.DisplayUnits = KostiakovKParameter.K_UnitsText(kUnits)

            Me.MkosCUpDown.UpDownValue = UnitValue(srfrInf.c, cUnits)
            Me.MkosCUpDown.DisplayUnits = UnitsText(cUnits)

            Me.MkosBUpDown.UpDownValue = UnitValue(srfrInf.b, bUnits)
            Me.MkosBUpDown.DisplayUnits = UnitsText(bUnits)

            Me.MkosAUpDown.UpDownValue = srfrInf.a

            Me.UpdateModifiedKostiakov()

        End If
    End Sub

    Private Sub SaveModifiedKostiakov()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Save Modified Kostiakov parameters into the DataStore
            '
            mMyStore.MarkForUndo("Modified Kostiakov Edits")

            mSoilCropProperties.MyStore.EventsEnabled = False

            ' Save Infiltration Equation then Wetted Perimeter
            SaveInfiltrationEquation()
            SaveWettedPerimeter()

            ' Save Infiltration Parameters

            Dim k As Double = MkosKUpDown.UpDownValue ' save k first
            Dim aOld As Double = mSoilCropProperties.KostiakovA_MK.Value

            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_MK
            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            kParam.Value = KostiakovKParameter.SiKostiakovK(k, aOld, kUnits)
            kParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovK_MK = kParam

            Dim a As Double = MkosAUpDown.UpDownValue ' then a
            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_MK
            aParam.Value = a
            aParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovA_MK = aParam

            Dim b As Double = MkosBUpDown.UpDownValue
            Dim bParam As DoubleParameter = mSoilCropProperties.KostiakovB_MK
            Dim bUnits As Units = bParam.DisplayUnits
            bParam.Value = SiVelocity(b, bUnits)
            bParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovB_MK = bParam

            mSoilCropProperties.MyStore.EventsEnabled = True

            Dim c As Double = MkosCUpDown.UpDownValue
            Dim cParam As DoubleParameter = mSoilCropProperties.KostiakovC_MK
            Dim cUnits As Units = cParam.DisplayUnits
            cParam.Value = SiDepth(c, cUnits)
            cParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovC_MK = cParam
        End If
    End Sub

#End Region

#Region " Branch Function "

    Private Sub InitializeBranchFunction()
        If (mSoilCropProperties IsNot Nothing) Then
            '
            ' Load the Branch Function parameters into the editor
            '
            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_BF
            Dim a As Double = aParam.Value

            Dim bParam As DoubleParameter = mSoilCropProperties.BranchB_BF
            Dim b As Double = bParam.Value
            Dim bUnits As Units = bParam.DisplayUnits

            Dim cParam As DoubleParameter = mSoilCropProperties.KostiakovC_BF
            Dim c As Double = cParam.Value
            Dim cUnits As Units = cParam.DisplayUnits

            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_BF
            Dim k As Double = kParam.Value
            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

            Dim BtSetParam As BooleanParameter = mSoilCropProperties.BranchTimeSet
            Dim BtSet As Boolean = BtSetParam.Value

            Dim BtParam As DoubleParameter = mSoilCropProperties.BranchTime_BF
            Dim Bt As Double = BtParam.Value
            Dim tUnits As Units = BtParam.DisplayUnits

            BranAUpDown.UpDownValue = a
            BranAUpDown.DisplayUnits = aParam.UnitsString

            BranBUpDown.UpDownValue = UnitVelocity(b, bUnits)
            BranBUpDown.DisplayUnits = bParam.UnitsString

            BranCUpDown.UpDownValue = UnitDepth(c, cUnits)
            BranCUpDown.DisplayUnits = cParam.UnitsString

            BranKUpDown.UpDownValue = KostiakovKParameter.UnitKostiakovK(k, a, kUnits)
            BranKUpDown.DisplayUnits = KostiakovKParameter.K_UnitsText(kUnits)

            BranchTimeEnable.Checked = BtSet

            BranchTimeUpDown.UpDownValue = UnitTime(Bt, tUnits)
            BranchTimeUpDown.DisplayUnits = BtParam.UnitsString
        End If
    End Sub

    Private Sub UpdateBranchFunction()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load Branch Function parameters into the SRFR Infiltration object
            '
            If (Me.BranchTimeEnable.Checked) Then ' user input
                UpdateBranchFunction2()
                Me.BranchTime.Hide()
                Me.BranchTimeUpDown.Show()
            Else
                UpdateBranchFunction1()
                Me.BranchTimeUpDown.Hide()
                Me.BranchTime.Show()
            End If

            Select Case (mSrfrInfiltration.WettedPerimeterMethod)
                Case Srfr.Infiltration.WettedPerimeterMethods.BorderWidth, _
                     Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing
                    mAddUpstreamDepthText = False
                Case Srfr.Infiltration.WettedPerimeterMethods.Local, _
                     Srfr.Infiltration.WettedPerimeterMethods.RepresentativeUpstream
                    mAddUpstreamDepthText = True
                Case Else ' Others are not compatible with Kostiakov Formula
                    Debug.Assert(False)
            End Select

            UpdateGraphics()
        End If
    End Sub

    ' When Branch Time is calculated
    Private Sub UpdateBranchFunction1()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load Branch Function parameters into the SRFR Infiltration object
            '
            Dim srfrInf As Srfr.BranchFunction = SrfrAPI.SrfrBranchFunction(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            Dim a As Double = BranAUpDown.UpDownValue
            srfrInf.a = a

            Dim b As Double = BranBUpDown.UpDownValue
            Dim bParam As DoubleParameter = mSoilCropProperties.BranchB_BF
            Dim bUnits As Units = bParam.DisplayUnits
            srfrInf.b = SiVelocity(b, bUnits)

            Dim c As Double = BranCUpDown.UpDownValue
            Dim cParam As DoubleParameter = mSoilCropProperties.KostiakovC_BF
            Dim cUnits As Units = cParam.DisplayUnits
            srfrInf.c = SiDepth(c, cUnits)

            Dim k As Double = BranKUpDown.UpDownValue
            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_BF
            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            srfrInf.k = KostiakovKParameter.SiKostiakovK(k, a, kUnits)

            mSrfrInfiltration = srfrInf

            Dim bt As Double = Srfr.SrfrAPI.BranchTime(srfrInf.k, srfrInf.a, srfrInf.b)
            Me.BranchTime.Text = TimeString(bt)

        End If
    End Sub

    ' When Branch Time is user input
    Private Sub UpdateBranchFunction2()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load Branch Function parameters into the SRFR Infiltration object
            '
            Dim srfrInf As Srfr.BranchFunction2 = SrfrAPI.SrfrBranchFunction2(mSoilCropProperties)
            UpdateWettedPerimeter(srfrInf)

            Dim a As Double = BranAUpDown.UpDownValue
            srfrInf.a = a

            Dim b As Double = BranBUpDown.UpDownValue
            Dim bParam As DoubleParameter = mSoilCropProperties.BranchB_BF
            Dim bUnits As Units = bParam.DisplayUnits
            srfrInf.b = SiVelocity(b, bUnits)

            Dim c As Double = BranCUpDown.UpDownValue
            Dim cParam As DoubleParameter = mSoilCropProperties.KostiakovC_BF
            Dim cUnits As Units = cParam.DisplayUnits
            srfrInf.c = SiDepth(c, cUnits)

            Dim k As Double = BranKUpDown.UpDownValue
            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_BF
            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            srfrInf.k = KostiakovKParameter.SiKostiakovK(k, a, kUnits)

            Dim Tb As Double = BranchTimeUpDown.UpDownValue
            Dim TbParam As DoubleParameter = mSoilCropProperties.BranchTime_BF
            Dim TbUnits As Units = TbParam.DisplayUnits
            srfrInf.Tb = SiTime(Tb, TbUnits)

            mSrfrInfiltration = srfrInf

        End If
    End Sub

    Private Sub SaveBranchFunction()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Save Branch Function parameters into the DataStore
            '
            mMyStore.MarkForUndo("Branch Function Edits")

            mSoilCropProperties.MyStore.EventsEnabled = False

            ' Save Infiltration Equation then Wetted Perimeter
            SaveInfiltrationEquation()
            SaveWettedPerimeter()

            ' Save Infiltration Parameters
            Dim k As Double = BranKUpDown.UpDownValue ' save k first
            Dim aOld As Double = mSoilCropProperties.KostiakovA_BF.Value

            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_BF
            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            kParam.Value = KostiakovKParameter.SiKostiakovK(k, aOld, kUnits)
            kParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovK_BF = kParam

            Dim a As Double = BranAUpDown.UpDownValue ' then a
            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_BF
            aParam.Value = a
            aParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovA_BF = aParam

            Dim b As Double = BranBUpDown.UpDownValue
            Dim bParam As DoubleParameter = mSoilCropProperties.BranchB_BF
            Dim bUnits As Units = bParam.DisplayUnits
            bParam.Value = SiVelocity(b, bUnits)
            bParam.Source = ValueSources.UserEntered
            mSoilCropProperties.BranchB_BF = bParam

            mSoilCropProperties.MyStore.EventsEnabled = True

            Dim c As Double = BranCUpDown.UpDownValue
            Dim cParam As DoubleParameter = mSoilCropProperties.KostiakovC_BF
            Dim cUnits As Units = cParam.DisplayUnits
            cParam.Value = SiDepth(c, cUnits)
            cParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovC_BF = cParam

            Dim BtSet As Boolean = BranchTimeEnable.Checked
            Dim BtSetParam As BooleanParameter = mSoilCropProperties.BranchTimeSet
            BtSetParam.Value = BtSet
            BtSetParam.Source = ValueSources.UserEntered
            mSoilCropProperties.BranchTimeSet = BtSetParam

            Dim Bt As Double = BranchTimeUpDown.UpDownValue
            Dim BtParam As DoubleParameter = mSoilCropProperties.BranchTime_BF
            Dim BtUnits As Units = BtParam.DisplayUnits
            BtParam.Value = SiTime(Bt, BtUnits)
            BtParam.Source = ValueSources.UserEntered
            mSoilCropProperties.BranchTime_BF = BtParam
        End If
    End Sub

#End Region

#Region " Green-Ampt "

    Private Sub InitializeGreenAmpt()
        If (mSoilCropProperties IsNot Nothing) Then
            '
            ' Load the Green-Ampt parameters into the editor
            '
            Dim phiParam As DoubleParameter = mSoilCropProperties.EffectivePorosityGA
            Dim phi As Double = phiParam.Value
            Dim phiUnits As Units = phiParam.DisplayUnits

            Dim theta0Param As DoubleParameter = mSoilCropProperties.InitialWaterContentGA
            Dim theta0 As Double = theta0Param.Value
            Dim theta0Units As Units = theta0Param.DisplayUnits

            Dim hfParam As DoubleParameter = mSoilCropProperties.WettingFrontPressureHeadGA
            Dim hf As Double = hfParam.Value
            Dim hfUnits As Units = hfParam.DisplayUnits

            Dim ksParam As DoubleParameter = mSoilCropProperties.HydraulicConductivityGA
            Dim ks As Double = ksParam.Value
            Dim ksUnits As Units = ksParam.DisplayUnits

            Dim cParam As DoubleParameter = mSoilCropProperties.GreenAmptC
            Dim c As Double = cParam.Value
            Dim cUnits As Units = cParam.DisplayUnits

            GaEffectivePorosityUpDown.UpDownValue = phi
            GaEffectivePorosityUpDown.DisplayUnits = phiParam.UnitsString

            GaInitialWaterContentUpDown.UpDownValue = theta0
            GaInitialWaterContentUpDown.DisplayUnits = theta0Param.UnitsString

            GaPressureHeadUpDown.UpDownValue = UnitDepth(hf, hfUnits)
            GaPressureHeadUpDown.DisplayUnits = hfParam.UnitsString

            GaHydraulicConductivityUpDown.UpDownValue = UnitVelocity(ks, ksUnits)
            GaHydraulicConductivityUpDown.DisplayUnits = ksParam.UnitsString

            GaCUpDown.UpDownValue = UnitDepth(c, cUnits)
            GaCUpDown.DisplayUnits = cParam.UnitsString
        End If
    End Sub

    Private Sub UpdateGreenAmpt()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load Green-Ampt parameters into the SRFR Infiltration object
            '
            Dim srfrInf As Srfr.GreenAmpt = SrfrAPI.SrfrGreenAmpt(mSoilCropProperties)

            Dim thetaS As Double = GaEffectivePorosityUpDown.UpDownValue
            Dim thetaSParam As DoubleParameter = mSoilCropProperties.EffectivePorosityGA
            Dim thetaSUnits As Units = thetaSParam.DisplayUnits
            srfrInf.ThetaS = thetaS

            Dim theta0 As Double = GaInitialWaterContentUpDown.UpDownValue
            Dim theta0Param As DoubleParameter = mSoilCropProperties.InitialWaterContentGA
            Dim theta0Units As Units = theta0Param.DisplayUnits
            srfrInf.Theta0 = theta0

            Dim hf As Double = GaPressureHeadUpDown.UpDownValue
            Dim hfParam As DoubleParameter = mSoilCropProperties.WettingFrontPressureHeadGA
            Dim hfUnits As Units = hfParam.DisplayUnits
            srfrInf.hf = SiDepth(hf, hfUnits)

            Dim ks As Double = GaHydraulicConductivityUpDown.UpDownValue
            Dim ksParam As DoubleParameter = mSoilCropProperties.HydraulicConductivityGA
            Dim ksUnits As Units = ksParam.DisplayUnits
            srfrInf.Ks = SiVelocity(ks, ksUnits)

            Dim c As Double = GaCUpDown.UpDownValue
            Dim cParam As DoubleParameter = mSoilCropProperties.GreenAmptC
            Dim cUnits As Units = cParam.DisplayUnits
            srfrInf.c = SiDepth(c, cUnits)

            mSrfrInfiltration = srfrInf

            mAddUpstreamDepthText = False

            UpdateGraphics()
        End If
    End Sub

    Private Function GreenAmptChanged() As Boolean

        Dim ieChanged As Boolean = InfiltrationEquationChanged()
        Dim wpChanged As Boolean = WettedPerimeterChanged()
        GreenAmptChanged = ieChanged Or wpChanged

        ' Check Infiltration Parameters
        Dim phi As Double = GaEffectivePorosityUpDown.UpDownValue
        Dim phiParam As DoubleParameter = mSoilCropProperties.EffectivePorosityGA
        If Not (phiParam.Value = phi) Then
            GreenAmptChanged = True
        End If

        Dim theta0 As Double = GaInitialWaterContentUpDown.UpDownValue
        Dim theta0Param As DoubleParameter = mSoilCropProperties.InitialWaterContentGA
        If Not (theta0Param.Value = theta0) Then
            GreenAmptChanged = True
        End If

        Dim hf As Double = GaPressureHeadUpDown.UpDownValue
        Dim hfParam As DoubleParameter = mSoilCropProperties.WettingFrontPressureHeadGA
        Dim hfUnits As Units = hfParam.DisplayUnits
        If Not (hfParam.Value = SiDepth(hf, hfUnits)) Then
            GreenAmptChanged = True
        End If

        Dim ks As Double = GaHydraulicConductivityUpDown.UpDownValue
        Dim ksParam As DoubleParameter = mSoilCropProperties.HydraulicConductivityGA
        Dim ksUnits As Units = ksParam.DisplayUnits
        If Not (ksParam.Value = SiVelocity(ks, ksUnits)) Then
            GreenAmptChanged = True
        End If

        Dim c As Double = GaCUpDown.UpDownValue
        Dim cParam As DoubleParameter = mSoilCropProperties.GreenAmptC
        Dim cUnits As Units = cParam.DisplayUnits
        If Not (cParam.Value = SiDepth(c, cUnits)) Then
            GreenAmptChanged = True
        End If

    End Function

    Private Sub SaveGreenAmpt()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then

            If Not (GreenAmptChanged()) Then
                Exit Sub
            End If
            '
            ' Save Green-Ampt parameters into the DataStore
            '
            mMyStore.MarkForUndo("Green-Ampt Edits")

            ' Save Infiltration Equation; no Wetted Perimeter for Green-Ampt
            SaveInfiltrationEquation()

            ' Save Infiltration Parameters
            Dim phi As Double = GaEffectivePorosityUpDown.UpDownValue
            Dim phiParam As DoubleParameter = mSoilCropProperties.EffectivePorosityGA
            If Not (phiParam.Value = phi) Then
                phiParam.Value = phi
                phiParam.Source = ValueSources.UserEntered
                mSoilCropProperties.EffectivePorosityGA = phiParam
            End If

            Dim theta0 As Double = GaInitialWaterContentUpDown.UpDownValue
            Dim theta0Param As DoubleParameter = mSoilCropProperties.InitialWaterContentGA
            If Not (theta0Param.Value = theta0) Then
                theta0Param.Value = theta0
                theta0Param.Source = ValueSources.UserEntered
                mSoilCropProperties.InitialWaterContentGA = theta0Param
            End If

            Dim hf As Double = GaPressureHeadUpDown.UpDownValue
            Dim hfParam As DoubleParameter = mSoilCropProperties.WettingFrontPressureHeadGA
            Dim hfUnits As Units = hfParam.DisplayUnits
            If Not (hfParam.Value = SiDepth(hf, hfUnits)) Then
                hfParam.Value = SiDepth(hf, hfUnits)
                hfParam.Source = ValueSources.UserEntered
                mSoilCropProperties.WettingFrontPressureHeadGA = hfParam
            End If

            Dim ks As Double = GaHydraulicConductivityUpDown.UpDownValue
            Dim ksParam As DoubleParameter = mSoilCropProperties.HydraulicConductivityGA
            Dim ksUnits As Units = ksParam.DisplayUnits
            If Not (ksParam.Value = SiVelocity(ks, ksUnits)) Then
                ksParam.Value = SiVelocity(ks, ksUnits)
                ksParam.Source = ValueSources.UserEntered
                mSoilCropProperties.HydraulicConductivityGA = ksParam
            End If

            Dim c As Double = GaCUpDown.UpDownValue
            Dim cParam As DoubleParameter = mSoilCropProperties.GreenAmptC
            Dim cUnits As Units = cParam.DisplayUnits
            If Not (cParam.Value = SiDepth(c, cUnits)) Then
                cParam.Value = SiDepth(c, cUnits)
                cParam.Source = ValueSources.UserEntered
                mSoilCropProperties.GreenAmptC = cParam
            End If
        End If
    End Sub

#End Region

#Region " Warrick / Green-Ampt "

    Private Sub InitializeWarrickGreenAmpt()
        If (mSoilCropProperties IsNot Nothing) Then
            '
            ' Load the Warrick / Green-Ampt parameters into the editor
            '
            Dim thetaSParam As DoubleParameter = mSoilCropProperties.SaturatedWaterContentWGA
            Dim thetaS As Double = thetaSParam.Value
            Dim thetaSUnits As Units = thetaSParam.DisplayUnits

            Dim theta0Param As DoubleParameter = mSoilCropProperties.InitialWaterContentWGA
            Dim theta0 As Double = theta0Param.Value
            Dim theta0Units As Units = theta0Param.DisplayUnits

            Dim hfParam As DoubleParameter = mSoilCropProperties.WettingFrontPressureHeadWGA
            Dim hf As Double = hfParam.Value
            Dim hfUnits As Units = hfParam.DisplayUnits

            Dim ksParam As DoubleParameter = mSoilCropProperties.HydraulicConductivityWGA
            Dim ks As Double = ksParam.Value
            Dim ksUnits As Units = ksParam.DisplayUnits

            Dim cParam As DoubleParameter = mSoilCropProperties.WarrickGreenAmptC
            Dim c As Double = cParam.Value
            Dim cUnits As Units = cParam.DisplayUnits

            WgaSaturatedWaterContentUpDown.UpDownValue = thetaS
            WgaSaturatedWaterContentUpDown.DisplayUnits = thetaSParam.UnitsString

            WgaInitialWaterContentUpDown.UpDownValue = theta0
            WgaInitialWaterContentUpDown.DisplayUnits = theta0Param.UnitsString

            WgaPressureHeadUpDown.UpDownValue = UnitDepth(hf, hfUnits)
            WgaPressureHeadUpDown.DisplayUnits = hfParam.UnitsString

            WgaHydraulicConductivityUpDown.UpDownValue = UnitVelocity(ks, ksUnits)
            WgaHydraulicConductivityUpDown.DisplayUnits = ksParam.UnitsString

            WgaCUpDown.UpDownValue = UnitDepth(c, cUnits)
            WgaCUpDown.DisplayUnits = cParam.UnitsString
        End If
    End Sub

    Private Sub UpdateWarrickGreenAmpt()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then
            '
            ' Load Warrick/Green-Ampt parameters into the SRFR Infiltration object
            '
            Dim srfrInf As Srfr.WarrickGreenAmpt = SrfrAPI.SrfrWarrickGreenAmpt(mSoilCropProperties)

            Dim thetaS As Double = WgaSaturatedWaterContentUpDown.UpDownValue
            Dim thetaSParam As DoubleParameter = mSoilCropProperties.SaturatedWaterContentWGA
            Dim thetaSUnits As Units = thetaSParam.DisplayUnits
            srfrInf.ThetaS = thetaS

            Dim theta0 As Double = WgaInitialWaterContentUpDown.UpDownValue
            Dim theta0Param As DoubleParameter = mSoilCropProperties.InitialWaterContentWGA
            Dim theta0Units As Units = theta0Param.DisplayUnits
            srfrInf.Theta0 = theta0

            Dim hf As Double = WgaPressureHeadUpDown.UpDownValue
            Dim hfParam As DoubleParameter = mSoilCropProperties.WettingFrontPressureHeadWGA
            Dim hfUnits As Units = hfParam.DisplayUnits
            srfrInf.hf = SiDepth(hf, hfUnits)

            Dim ks As Double = WgaHydraulicConductivityUpDown.UpDownValue
            Dim ksParam As DoubleParameter = mSoilCropProperties.HydraulicConductivityWGA
            Dim ksUnits As Units = ksParam.DisplayUnits
            srfrInf.Ks = SiVelocity(ks, ksUnits)

            Dim c As Double = WgaCUpDown.UpDownValue
            Dim cParam As DoubleParameter = mSoilCropProperties.WarrickGreenAmptC
            Dim cUnits As Units = cParam.DisplayUnits
            srfrInf.c = SiDepth(c, cUnits)

            mSrfrInfiltration = srfrInf

            mAddUpstreamDepthText = False

            UpdateGraphics()
        End If
    End Sub

    Private Function WarrickGreenAmptChanged() As Boolean

        Dim ieChanged As Boolean = InfiltrationEquationChanged()
        Dim wpChanged As Boolean = WettedPerimeterChanged()
        WarrickGreenAmptChanged = ieChanged Or wpChanged

        ' Check Infiltration Parameters
        Dim thetaS As Double = WgaSaturatedWaterContentUpDown.UpDownValue
        Dim thetaSParam As DoubleParameter = mSoilCropProperties.SaturatedWaterContentWGA
        If Not (thetaSParam.Value = thetaS) Then
            WarrickGreenAmptChanged = True
        End If

        Dim theta0 As Double = WgaInitialWaterContentUpDown.UpDownValue
        Dim theta0Param As DoubleParameter = mSoilCropProperties.InitialWaterContentWGA
        If Not (theta0Param.Value = theta0) Then
            WarrickGreenAmptChanged = True
        End If

        Dim hf As Double = WgaPressureHeadUpDown.UpDownValue
        Dim hfParam As DoubleParameter = mSoilCropProperties.WettingFrontPressureHeadWGA
        Dim hfUnits As Units = hfParam.DisplayUnits
        If Not (hfParam.Value = SiDepth(hf, hfUnits)) Then
            WarrickGreenAmptChanged = True
        End If

        Dim ks As Double = WgaHydraulicConductivityUpDown.UpDownValue
        Dim ksParam As DoubleParameter = mSoilCropProperties.HydraulicConductivityWGA
        Dim ksUnits As Units = ksParam.DisplayUnits
        If Not (ksParam.Value = SiVelocity(ks, ksUnits)) Then
            WarrickGreenAmptChanged = True
        End If

        Dim c As Double = WgaCUpDown.UpDownValue
        Dim cParam As DoubleParameter = mSoilCropProperties.WarrickGreenAmptC
        Dim cUnits As Units = cParam.DisplayUnits
        If Not (cParam.Value = SiDepth(c, cUnits)) Then
            WarrickGreenAmptChanged = True
        End If

    End Function

    Private Sub SaveWarrickGreenAmpt()
        If ((mInitialized) And (mSoilCropProperties IsNot Nothing)) Then

            If Not (WarrickGreenAmptChanged()) Then
                Exit Sub
            End If
            '
            ' Save Warrick / Green-Ampt parameters into the DataStore
            '
            mMyStore.MarkForUndo("Warrick / Green-Ampt Edits")

            ' Save Infiltration Equation then Wetted Perimeter
            SaveInfiltrationEquation()
            SaveWettedPerimeter()

            ' Save Infiltration Parameters
            Dim thetaS As Double = WgaSaturatedWaterContentUpDown.UpDownValue
            Dim thetaSParam As DoubleParameter = mSoilCropProperties.SaturatedWaterContentWGA
            If Not (thetaSParam.Value = thetaS) Then
                thetaSParam.Value = thetaS
                thetaSParam.Source = ValueSources.UserEntered
                mSoilCropProperties.SaturatedWaterContentWGA = thetaSParam
            End If

            Dim theta0 As Double = WgaInitialWaterContentUpDown.UpDownValue
            Dim theta0Param As DoubleParameter = mSoilCropProperties.InitialWaterContentWGA
            If Not (theta0Param.Value = theta0) Then
                theta0Param.Value = theta0
                theta0Param.Source = ValueSources.UserEntered
                mSoilCropProperties.InitialWaterContentWGA = theta0Param
            End If

            Dim hf As Double = WgaPressureHeadUpDown.UpDownValue
            Dim hfParam As DoubleParameter = mSoilCropProperties.WettingFrontPressureHeadWGA
            Dim hfUnits As Units = hfParam.DisplayUnits
            If Not (hfParam.Value = SiDepth(hf, hfUnits)) Then
                hfParam.Value = SiDepth(hf, hfUnits)
                hfParam.Source = ValueSources.UserEntered
                mSoilCropProperties.WettingFrontPressureHeadWGA = hfParam
            End If

            Dim ks As Double = WgaHydraulicConductivityUpDown.UpDownValue
            Dim ksParam As DoubleParameter = mSoilCropProperties.HydraulicConductivityWGA
            Dim ksUnits As Units = ksParam.DisplayUnits
            If Not (ksParam.Value = SiVelocity(ks, ksUnits)) Then
                ksParam.Value = SiVelocity(ks, ksUnits)
                ksParam.Source = ValueSources.UserEntered
                mSoilCropProperties.HydraulicConductivityWGA = ksParam
            End If

            Dim c As Double = WgaCUpDown.UpDownValue
            Dim cParam As DoubleParameter = mSoilCropProperties.WarrickGreenAmptC
            Dim cUnits As Units = cParam.DisplayUnits
            If Not (cParam.Value = SiDepth(c, cUnits)) Then
                cParam.Value = SiDepth(c, cUnits)
                cParam.Source = ValueSources.UserEntered
                mSoilCropProperties.WarrickGreenAmptC = cParam
            End If
        End If
    End Sub

#End Region

#Region " Wetted Perimeter / Infiltration Equation "

    Private Sub UpdateWettedPerimeter(ByVal SrfrInfiltration As Srfr.Infiltration)

        ' Load Wetted Perimeter
        If (mUnit.CrossSection = CrossSections.Furrow) Then

            ' Get Wetted Perimeter value from UI control
            Dim wpTxt As String = WettedPerimeterControl.SelectedItem
            Dim wpVal As WettedPerimeterMethods = WettedPerimeterMethodEnum(wpTxt)

            Select Case (wpVal)
                Case WettedPerimeterMethods.FurrowSpacing
                    SrfrInfiltration.WettedPerimeterMethod = Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing
                Case WettedPerimeterMethods.LocalWettedPerimeter
                    SrfrInfiltration.WettedPerimeterMethod = Srfr.Infiltration.WettedPerimeterMethods.Local
                Case WettedPerimeterMethods.NrcsEmpiricalFunction
                    SrfrInfiltration.WettedPerimeterMethod = Srfr.Infiltration.WettedPerimeterMethods.NRCS
                Case Else ' RUWP
                    SrfrInfiltration.WettedPerimeterMethod = Srfr.Infiltration.WettedPerimeterMethods.RepresentativeUpstream
            End Select
        Else
            SrfrInfiltration.WettedPerimeterMethod = Srfr.Infiltration.WettedPerimeterMethods.BorderWidth
        End If

    End Sub

    Private Function WettedPerimeterChanged() As Boolean
        WettedPerimeterChanged = False

        ' Save Wetted Perimeter
        If (mUnit.CrossSection = CrossSections.Furrow) Then

            ' Get Wetted Perimeter value from UI control
            Dim wpTxt As String = WettedPerimeterControl.SelectedItem
            Dim wpVal As WettedPerimeterMethods = WettedPerimeterMethodEnum(wpTxt)
            If (wpVal = WettedPerimeterMethods.LowLimit) Then
                Exit Function
            End If

            ' Get Wetted Perimeter value from DataStore
            Dim wpParam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod

            ' Check if it has changed
            If Not (wpParam.Value = wpVal) Then
                WettedPerimeterChanged = True
            End If
        End If

    End Function

    Private Sub SaveWettedPerimeter()

        ' Save Wetted Perimeter
        If (mUnit.CrossSection = CrossSections.Furrow) Then

            ' Get Wetted Perimeter value from UI control
            Dim wpTxt As String = WettedPerimeterControl.SelectedItem
            Dim wpVal As WettedPerimeterMethods = WettedPerimeterMethodEnum(wpTxt)
            If (wpVal = WettedPerimeterMethods.LowLimit) Then
                Exit Sub
            End If

            ' Get Wetted Perimeter value from DataStore
            Dim wpParam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod

            ' If it has changed, save new value
            If Not (wpParam.Value = wpVal) Then
                wpParam.Value = wpVal
                wpParam.Source = ValueSources.UserEntered
                mSoilCropProperties.WettedPerimeterMethod = wpParam
            End If
        End If

    End Sub

    Private Function InfiltrationEquationChanged() As Boolean
        InfiltrationEquationChanged = False

        ' Get Infiltration Equation value from UI control
        Dim ieTxt As String = InfiltrationEquationControl.SelectedItem
        Dim ieVal As InfiltrationFunctions = InfiltrationFunctionEnum(ieTxt)
        If (ieVal = InfiltrationFunctions.LowLimit) Then
            Exit Function
        End If

        ' Get Infiltration Equation value from DataStore
        Dim ieParam As IntegerParameter = mSoilCropProperties.InfiltrationFunction

        ' Check if it has changed
        If Not (ieParam.Value = ieVal) Then
            InfiltrationEquationChanged = True
        End If

    End Function

    Private Sub SaveInfiltrationEquation()

        ' Get Infiltration Equation value from UI control
        Dim ieTxt As String = InfiltrationEquationControl.SelectedItem
        Dim ieVal As InfiltrationFunctions = InfiltrationFunctionEnum(ieTxt)
        If (ieVal = InfiltrationFunctions.LowLimit) Then
            Exit Sub
        End If

        ' Get Infiltration Equation value from DataStore
        Dim ieParam As IntegerParameter = mSoilCropProperties.InfiltrationFunction

        ' If it has changed, save new value
        If Not (ieParam.Value = ieVal) Then
            ieParam.Value = ieVal
            ieParam.Source = ValueSources.UserEntered
            mSoilCropProperties.InfiltrationFunction = ieParam
        End If

    End Sub

    Private Function PreviousIsModifiedKostiakovBased() As Boolean
        PreviousIsModifiedKostiakovBased = False

        Dim orgEquation As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value

        Select Case (orgEquation)
            ' These Infiltration Functions are Modified Kostiakov based
            Case InfiltrationFunctions.CharacteristicInfiltrationTime, _
                 InfiltrationFunctions.KostiakovFormula, _
                 InfiltrationFunctions.ModifiedKostiakovFormula, _
                 InfiltrationFunctions.NRCSIntakeFamily, _
                 InfiltrationFunctions.TimeRatedIntakeFamily
                PreviousIsModifiedKostiakovBased = True
        End Select

    End Function

    Private Function PreviousIsBranchFunctionBased() As Boolean
        PreviousIsBranchFunctionBased = False

        Dim orgEquation As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value

        Select Case (orgEquation)
            Case InfiltrationFunctions.BranchFunction
                PreviousIsBranchFunctionBased = True
        End Select

    End Function

    Private Function PreviousIsGreenAmptBased() As Boolean
        PreviousIsGreenAmptBased = False

        Dim orgEquation As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value

        Select Case (orgEquation)
            Case InfiltrationFunctions.GreenAmpt
                PreviousIsGreenAmptBased = True
        End Select

    End Function

    Private Function PreviousIsWarrickGreenAmptBased() As Boolean
        PreviousIsWarrickGreenAmptBased = False

        Dim orgEquation As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value

        Select Case (orgEquation)
            Case InfiltrationFunctions.WarrickGreenAmpt
                PreviousIsWarrickGreenAmptBased = True
        End Select

    End Function

    Private Function PreviousIsHydrus1DBased() As Boolean
        PreviousIsHydrus1DBased = False

        Dim orgEquation As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value

        Select Case (orgEquation)
            Case InfiltrationFunctions.Hydrus1D
                PreviousIsHydrus1DBased = True
        End Select

    End Function

    Private Function PreviousIsWettedPerimeterBased() As Boolean
        PreviousIsWettedPerimeterBased = True

        If (mUnit.CrossSection = CrossSections.Furrow) Then ' might be
            Dim wpMethod As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value
            If (wpMethod = WettedPerimeterMethods.FurrowSpacing) Then
                PreviousIsWettedPerimeterBased = False
            End If
        Else ' Basin/Border
            PreviousIsWettedPerimeterBased = False
        End If

    End Function

    Private Function WettedPerimetersMatch(ByVal srfrInf As Srfr.Infiltration) As Boolean
        WettedPerimetersMatch = True

        If (mUnit.CrossSection = CrossSections.Furrow) Then ' might not match
            Dim wpMethod As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value
            Select Case (srfrInf.WettedPerimeterMethod)
                Case Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing
                    If Not (wpMethod = WettedPerimeterMethods.FurrowSpacing) Then
                        WettedPerimetersMatch = False
                    End If
                Case Srfr.Infiltration.WettedPerimeterMethods.NRCS
                    If Not (wpMethod = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
                        WettedPerimetersMatch = False
                    End If
                Case Else
                    Select Case (wpMethod)
                        Case WettedPerimeterMethods.FurrowSpacing
                            WettedPerimetersMatch = False
                        Case WettedPerimeterMethods.NrcsEmpiricalFunction
                            WettedPerimetersMatch = False
                    End Select
            End Select
        End If

    End Function

#End Region

#End Region

#Region " UI Event Handlers "

#Region " Infiltration Function "

    Private Sub WettedPerimeterControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WettedPerimeterControl.SelectedIndexChanged
        UpdateInfiltrationEquationMethod()
    End Sub

    Private Sub InfiltrationEquationControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles InfiltrationEquationControl.SelectedIndexChanged
        UpdateInfiltrationParameters()
    End Sub

#End Region

#Region " Characteristic Infiltration Time "

    Private Sub KcitDepthUpDown_ValueChanged() Handles KcitDepthUpDown.ValueChanged
        UpdateCharacteristicInfiltrationTime()
    End Sub

    Private Sub KcitTimeUpDown_ValueChanged() Handles KcitTimeUpDown.ValueChanged
        UpdateCharacteristicInfiltrationTime()
    End Sub

    Private Sub KcitAUpDown_ValueChanged() Handles KcitAUpDown.ValueChanged
        UpdateCharacteristicInfiltrationTime()
    End Sub

#End Region

#Region " Time-Rated Intake Family "

    Private Sub TrifTimeUpDown_ValueChanged() Handles TrifTimeUpDown.ValueChanged
        UpdateTimeRatedIntakeFamily()
    End Sub

#End Region

#Region " NRCS Intake Family "

    Private Sub NrcsFamily005Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily005Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family005
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily010Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily010Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family010
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily015Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily015Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family015
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily020Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily020Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family020
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily025Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily025Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family025
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily030Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily030Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family030
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily035Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily035Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family035
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily040Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily040Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family040
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily045Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily045Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family045
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily050Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily050Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family050
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily060Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily060Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family060
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily070Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily070Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family070
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily080Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily080Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family080
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily090Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily090Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family090
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily100Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily100Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family100
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily150Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily150Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family150
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily200Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily200Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family200
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily300Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily300Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family300
        UpdateNrcsIntakeFamily()
    End Sub

    Private Sub NrcsFamily400Button_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsFamily400Button.CheckedChanged
        mNrcsIntakeFamily = NrcsIntakeFamilies.Family400
        UpdateNrcsIntakeFamily()
    End Sub

#End Region

#Region " Kostiakov Formula "

    Private Sub KostKUpDown_ValueChanged() Handles KostKUpDown.ValueChanged
        UpdateKostiakovFormula()
    End Sub

    Private Sub KostAUpDown_ValueChanged() Handles KostAUpDown.ValueChanged
        UpdateKostiakovFormula()
    End Sub

#End Region

#Region " Modified Kostiakov Formula "

    Private Sub MkosKUpDown_ValueChanged() Handles MkosKUpDown.ValueChanged
        UpdateModifiedKostiakov()
    End Sub

    Private Sub MkosAUpDown_ValueChanged() Handles MkosAUpDown.ValueChanged
        UpdateModifiedKostiakov()
    End Sub

    Private Sub MkosBUpDown_ValueChanged() Handles MkosBUpDown.ValueChanged
        UpdateModifiedKostiakov()
    End Sub

    Private Sub MkosCUpDown_ValueChanged() Handles MkosCUpDown.ValueChanged
        UpdateModifiedKostiakov()
    End Sub

#End Region

#Region " Branch Formula "

    Private Sub BranKUpDown_ValueChanged() Handles BranKUpDown.ValueChanged
        UpdateBranchFunction()
    End Sub

    Private Sub BranAUpDown_ValueChanged() Handles BranAUpDown.ValueChanged
        UpdateBranchFunction()
    End Sub

    Private Sub BranBUpDown_ValueChanged() Handles BranBUpDown.ValueChanged
        UpdateBranchFunction()
    End Sub

    Private Sub BranCUpDown_ValueChanged() Handles BranCUpDown.ValueChanged
        UpdateBranchFunction()
    End Sub

    Private Sub BranchTimeEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BranchTimeEnable.CheckedChanged
        UpdateBranchFunction()
    End Sub

    Private Sub BranchTime_ValueChanged() Handles BranchTimeUpDown.ValueChanged
        UpdateBranchFunction()
    End Sub

#End Region

#Region " Green-Ampt "

    Private Sub GaCUpDown_ValueChanged() Handles GaCUpDown.ValueChanged
        UpdateGreenAmpt()
    End Sub

    Private Sub GaEffectivePorosityUpDown_ValueChanged() Handles GaEffectivePorosityUpDown.ValueChanged
        UpdateGreenAmpt()
    End Sub

    Private Sub GaInitialWaterContentUpDown_ValueChanged() Handles GaInitialWaterContentUpDown.ValueChanged
        UpdateGreenAmpt()
    End Sub

    Private Sub GaPressureHeadUpDown_ValueChanged() Handles GaPressureHeadUpDown.ValueChanged
        UpdateGreenAmpt()
    End Sub

    Private Sub GAHydraulicConductivityUpDown_ValueChanged() Handles GaHydraulicConductivityUpDown.ValueChanged
        UpdateGreenAmpt()
    End Sub

#End Region

#Region " Warrick / Green-Ampt "

    Private Sub WgaCUpDown_ValueChanged() Handles WgaCUpDown.ValueChanged
        UpdateWarrickGreenAmpt()
    End Sub

    Private Sub WgaEffectivePorosityUpDown_ValueChanged() Handles WgaSaturatedWaterContentUpDown.ValueChanged
        UpdateWarrickGreenAmpt()
    End Sub

    Private Sub WgaInitialWaterContentUpDown_ValueChanged() Handles WgaInitialWaterContentUpDown.ValueChanged
        UpdateWarrickGreenAmpt()
    End Sub

    Private Sub WgaPressureHeadUpDown_ValueChanged() Handles WgaPressureHeadUpDown.ValueChanged
        UpdateWarrickGreenAmpt()
    End Sub

    Private Sub WgaHydraulicConductivityUpDown_ValueChanged() Handles WgaHydraulicConductivityUpDown.ValueChanged
        UpdateWarrickGreenAmpt()
    End Sub

#End Region

#Region " Buttons "

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SaveButton.Click

        Dim curIEtxt As String = InfiltrationEquationControl.SelectedItem

        If (curIEtxt IsNot Nothing) Then
            ' Save only the selected one
            Select Case (curIEtxt)
                Case sCharacteristicInfiltrationTime
                    SaveCharacteristicInfiltrationTime()
                Case sTimeRatedIntakeFamily
                    SaveTimeRatedIntakeFamily()
                Case sKostiakovFormula
                    SaveKostiakovFormula()
                Case sModifiedKostiakovFormula
                    SaveModifiedKostiakov()
                Case sBranchFunction
                    SaveBranchFunction()
                Case sNrcsIntakeFamily
                    SaveNrcsIntakeFamily()
                Case sGreenAmpt
                    SaveGreenAmpt()
                Case sWarrickGreenAmpt
                    SaveWarrickGreenAmpt()
                Case sHydrus1D
                Case Else
                    Debug.Assert(False)
            End Select
        End If

        ' Set OK result & close the dialog box
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub MatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MatchButton.Click

        Dim curIEtxt As String = InfiltrationEquationControl.SelectedItem

        If (curIEtxt IsNot Nothing) Then
            ' Match only the selected one
            Select Case (curIEtxt)
                Case sCharacteristicInfiltrationTime
                    MatchCharacteristicInfiltrationTime()
                Case sTimeRatedIntakeFamily
                    MatchTimeRatedIntakeFamily()
                Case sKostiakovFormula
                    MatchKostiakovFormula()
                Case sModifiedKostiakovFormula
                    MatchModifiedKostiakov()
                Case sNrcsIntakeFamily
                    MatchNrcsIntakeFamily()
                Case Else
                    Debug.Assert(False)
            End Select
        End If

    End Sub

    Private Sub InfiltrationFunctionEditor_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:InfiltrationFunctionEditor", 0)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:InfiltrationFunctionEditor", 0)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#End Region

End Class
