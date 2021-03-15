
'*****************************************************************************
' Data Summary control
'
' Desc: This control displays a summary of the User Data from:
'
'   System Geometry
'   Infiltration
'   Roughness
'   Inflow Management
'
Imports DataStore

Public Class ctl_DataSummary
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
    Friend WithEvents SystemGeometrySummary As DataStore.ctl_GroupBox
    Friend WithEvents InfiltrationSummary As DataStore.ctl_GroupBox
    Friend WithEvents RoughnessSummary As DataStore.ctl_GroupBox
    Friend WithEvents InflowManagementSummary As DataStore.ctl_GroupBox
    Friend WithEvents FurrowLabel As System.Windows.Forms.Label
    Friend WithEvents PowerLawPanel As DataStore.ctl_Panel
    Friend WithEvents ExponentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WidthAt100mmControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ExponentLabel As DataStore.ctl_Label
    Friend WithEvents WidthAt100mmLabel As System.Windows.Forms.Label
    Friend WithEvents TrapezoidPanel As DataStore.ctl_Panel
    Friend WithEvents SideSlopeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BottomWidthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SideSlopeLabel As DataStore.ctl_Label
    Friend WithEvents BottomWidthLabel As DataStore.ctl_Label
    Friend WithEvents FurrowLengthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents FurrowLengthLabel As DataStore.ctl_Label
    Friend WithEvents FurrowSpacingControl As DataStore.ctl_DoubleParameter
    Friend WithEvents FurrowSpacingLabel As DataStore.ctl_Label
    Friend WithEvents FurrowPanel As DataStore.ctl_Panel
    Friend WithEvents BasinBorderPanel As DataStore.ctl_Panel
    Friend WithEvents BasinBorderLabel As System.Windows.Forms.Label
    Friend WithEvents LengthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents LengthLabel As DataStore.ctl_Label
    Friend WithEvents WidthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WidthLabel As DataStore.ctl_Label
    Friend WithEvents DepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents DepthLabel As DataStore.ctl_Label
    Friend WithEvents BranchFunctionPanel As DataStore.ctl_Panel
    Friend WithEvents BF_KostiakovKControl As WinMain.ctl_KostiakovKParameter
    Friend WithEvents BF_KostiakovKLabel As System.Windows.Forms.Label
    Friend WithEvents BF_BranchBControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_KostiakovCControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_KostiakovAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_BranchTimeLabel As System.Windows.Forms.Label
    Friend WithEvents BF_KostiakovBLabel As System.Windows.Forms.Label
    Friend WithEvents BF_KostiakovCLabel As System.Windows.Forms.Label
    Friend WithEvents BF_KostiakovALabel As System.Windows.Forms.Label
    Friend WithEvents InfiltrationLabel As System.Windows.Forms.Label
    Friend WithEvents CharacteristicInfiltrationPanel As DataStore.ctl_Panel
    Friend WithEvents KT_KostiakovK As System.Windows.Forms.Label
    Friend WithEvents KT_InfiltrationTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_KostiakovAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_InfiltrationDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_InfiltrationTimeLabel As DataStore.ctl_Label
    Friend WithEvents KT_KostiakovALabel As System.Windows.Forms.Label
    Friend WithEvents KT_InfiltrationDepthLabel As DataStore.ctl_Label
    Friend WithEvents TimeRatedIntakePanel As DataStore.ctl_Panel
    Friend WithEvents TR_InfiltrationDepth As System.Windows.Forms.Label
    Friend WithEvents TR_KostiakovA As System.Windows.Forms.Label
    Friend WithEvents TR_KostiakovK As System.Windows.Forms.Label
    Friend WithEvents TR_InfiltrationTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents TR_InfiltrationTimeLabel As DataStore.ctl_Label
    Friend WithEvents TR_InfiltrationDepthLabel As DataStore.ctl_Label
    Friend WithEvents KostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents KF_KostiakovAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KF_KostiakovKControl As WinMain.ctl_KostiakovKParameter
    Friend WithEvents KF_KostiakovALabel As System.Windows.Forms.Label
    Friend WithEvents KF_KostiakovKLabel As System.Windows.Forms.Label
    Friend WithEvents ModifiedKostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents MK_KostiakovAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MK_KostiakovKControl As WinMain.ctl_KostiakovKParameter
    Friend WithEvents MK_KostiakovCControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MK_KostiakovBControl As WinMain.ctl_KostiakovBParameter
    Friend WithEvents MK_KostiakovALabel As System.Windows.Forms.Label
    Friend WithEvents MK_KostiakovKLabel As System.Windows.Forms.Label
    Friend WithEvents MK_KostiakovCLabel As System.Windows.Forms.Label
    Friend WithEvents MK_KostiakovBLabel As System.Windows.Forms.Label
    Friend WithEvents NrcsIntakePanel As DataStore.ctl_Panel
    Friend WithEvents NrcsCalculatedA As System.Windows.Forms.Label
    Friend WithEvents NrcsCalculatedK As System.Windows.Forms.Label
    Friend WithEvents SayreChiPanel As DataStore.ctl_Panel
    Friend WithEvents SayreChiControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SayreChiLabel As System.Windows.Forms.Label
    Friend WithEvents ManningCnAnPanel As DataStore.ctl_Panel
    Friend WithEvents ManningAnControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ManningAnLabel As System.Windows.Forms.Label
    Friend WithEvents ManningCnControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ManningCnLabel As System.Windows.Forms.Label
    Friend WithEvents RoughnessLabel As System.Windows.Forms.Label
    Friend WithEvents UnitWaterCostControl As DataStore.ctl_DoubleParameter
    Friend WithEvents UnitWaterCostLabel As DataStore.ctl_Label
    Friend WithEvents InflowManagementLabel As System.Windows.Forms.Label
    Friend WithEvents StandardHydrographPanel As DataStore.ctl_Panel
    Friend WithEvents CutbackPanel As DataStore.ctl_Panel
    Friend WithEvents CutbackRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutbackTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutbackLocationControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutbackLocationLabel As DataStore.ctl_Label
    Friend WithEvents CutbackRateLabel As DataStore.ctl_Label
    Friend WithEvents CutbackTimeLabel As DataStore.ctl_Label
    Friend WithEvents CutoffTimePanel As DataStore.ctl_Panel
    Friend WithEvents CutoffTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffTimeLabel As DataStore.ctl_Label
    Friend WithEvents CutoffLocationPanel As DataStore.ctl_Panel
    Friend WithEvents CutoffOpportunityTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffInfiltrationDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffLocationControl As DataStore.ctl_DoubleParameter
    Friend WithEvents OpportunityTimeLabel As DataStore.ctl_Label
    Friend WithEvents CutoffLocationLabel As DataStore.ctl_Label
    Friend WithEvents InfiltrationDepthLabel As DataStore.ctl_Label
    Friend WithEvents CutoffCutbackLabel As System.Windows.Forms.Label
    Friend WithEvents TabulatedPanel As DataStore.ctl_Panel
    Friend WithEvents CablegationPanel As DataStore.ctl_Panel
    Friend WithEvents SurgePanel As DataStore.ctl_Panel
    Friend WithEvents UpstreamDepthLabel As DataStore.ctl_Label
    Friend WithEvents CutoffUpstreamDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffUpstreamDepthPanel As DataStore.ctl_Panel
    Friend WithEvents SlopeLabel As DataStore.ctl_Label
    Friend WithEvents SlopeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents LevelSlopeLabel As DataStore.ctl_Label
    Friend WithEvents SlopeMessage As System.Windows.Forms.Label
    Friend WithEvents SlopeMessagePanel As DataStore.ctl_Panel
    Friend WithEvents SlopePanel As DataStore.ctl_Panel
    Friend WithEvents FurrowSlopePanel As DataStore.ctl_Panel
    Friend WithEvents FurrowSlopeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents FurrowSlopeLabel As DataStore.ctl_Label
    Friend WithEvents FurrowSlopeMessagePanel As DataStore.ctl_Panel
    Friend WithEvents FurrowSlopeMessage As System.Windows.Forms.Label
    Friend WithEvents InflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents InflowRateLabel As DataStore.ctl_Label
    Friend WithEvents NrcsSuggestedManningNPanel As DataStore.ctl_Panel
    Friend WithEvents Sel_004 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_010 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_015 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_020 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_025 As DataStore.ctl_RadioButton
    Friend WithEvents RequiredDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RequiredDepthLabel As DataStore.ctl_Label
    Friend WithEvents BF_BranchTime As System.Windows.Forms.Label
    Friend WithEvents TrapezoidDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents TrapezoidDepthLabel As DataStore.ctl_Label
    Friend WithEvents PowerLawDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents PowerLawDepthLabel As DataStore.ctl_Label
    Friend WithEvents CablegationLabel As DataStore.ctl_Label
    Friend WithEvents SurgeStrategyLabel As System.Windows.Forms.Label
    Friend WithEvents TabulatedInfiltrationPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedInfiltrationLabel As DataStore.ctl_Label
    Friend WithEvents TabulatedRoughnessPanel As DataStore.ctl_Panel
    Friend WithEvents GreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents GA_SWD As System.Windows.Forms.Label
    Friend WithEvents GA_cControl As DataStore.ctl_DoubleParameter
    Friend WithEvents GAcLabel As DataStore.ctl_Label
    Friend WithEvents GA_HydraulicConductivityControl As DataStore.ctl_DoubleParameter
    Friend WithEvents HydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents GA_WettingFrontControl As DataStore.ctl_DoubleParameter
    Friend WithEvents AirEntryPressureLabel As DataStore.ctl_Label
    Friend WithEvents GA_InitVolWaterContentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents InitVolWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents GA_PorosityControl As DataStore.ctl_DoubleParameter
    Friend WithEvents PorosityLabel As DataStore.ctl_Label
    Friend WithEvents TabulatedCrossSectionPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedCrossSectionLabel As DataStore.ctl_Label
    Friend WithEvents Sel_UserEntered As DataStore.ctl_RadioButton
    Friend WithEvents UsersManningNControl As DataStore.ctl_DoubleParameter
    Friend WithEvents HydrusPanel As DataStore.ctl_Panel
    Friend WithEvents HydrusImportLabel As DataStore.ctl_Label
    Friend WithEvents HydrusProject As DataStore.ctl_StringParameter
    Friend WithEvents WarrickGreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents WarrickGreenAmptCControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WarrickGreenAmptCLabel As DataStore.ctl_Label
    Friend WithEvents HydraulicConductivityWGAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents HydraulicConductivityWGALabel As DataStore.ctl_Label
    Friend WithEvents WettingFrontPressureWGAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WettingFrontPressureWGALabel As DataStore.ctl_Label
    Friend WithEvents InitialWaterContentWGAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents InitialWaterContentWGALabel As DataStore.ctl_Label
    Friend WithEvents SaturatedWaterContentWGAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SaturatedWaterContentWGALabel As DataStore.ctl_Label
    Friend WithEvents TabulatedRoughnessLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_DataSummary))
        Me.SystemGeometrySummary = New DataStore.ctl_GroupBox
        Me.FurrowPanel = New DataStore.ctl_Panel
        Me.FurrowLengthControl = New DataStore.ctl_DoubleParameter
        Me.FurrowLengthLabel = New DataStore.ctl_Label
        Me.FurrowSpacingControl = New DataStore.ctl_DoubleParameter
        Me.FurrowSpacingLabel = New DataStore.ctl_Label
        Me.FurrowLabel = New System.Windows.Forms.Label
        Me.FurrowSlopePanel = New DataStore.ctl_Panel
        Me.FurrowSlopeControl = New DataStore.ctl_DoubleParameter
        Me.FurrowSlopeLabel = New DataStore.ctl_Label
        Me.FurrowSlopeMessagePanel = New DataStore.ctl_Panel
        Me.FurrowSlopeMessage = New System.Windows.Forms.Label
        Me.TrapezoidPanel = New DataStore.ctl_Panel
        Me.TrapezoidDepthControl = New DataStore.ctl_DoubleParameter
        Me.SideSlopeControl = New DataStore.ctl_DoubleParameter
        Me.BottomWidthControl = New DataStore.ctl_DoubleParameter
        Me.TrapezoidDepthLabel = New DataStore.ctl_Label
        Me.SideSlopeLabel = New DataStore.ctl_Label
        Me.BottomWidthLabel = New DataStore.ctl_Label
        Me.TabulatedCrossSectionPanel = New DataStore.ctl_Panel
        Me.TabulatedCrossSectionLabel = New DataStore.ctl_Label
        Me.PowerLawPanel = New DataStore.ctl_Panel
        Me.ExponentControl = New DataStore.ctl_DoubleParameter
        Me.PowerLawDepthControl = New DataStore.ctl_DoubleParameter
        Me.WidthAt100mmControl = New DataStore.ctl_DoubleParameter
        Me.PowerLawDepthLabel = New DataStore.ctl_Label
        Me.ExponentLabel = New DataStore.ctl_Label
        Me.WidthAt100mmLabel = New System.Windows.Forms.Label
        Me.BasinBorderPanel = New DataStore.ctl_Panel
        Me.DepthControl = New DataStore.ctl_DoubleParameter
        Me.DepthLabel = New DataStore.ctl_Label
        Me.LengthControl = New DataStore.ctl_DoubleParameter
        Me.LengthLabel = New DataStore.ctl_Label
        Me.WidthControl = New DataStore.ctl_DoubleParameter
        Me.WidthLabel = New DataStore.ctl_Label
        Me.BasinBorderLabel = New System.Windows.Forms.Label
        Me.SlopePanel = New DataStore.ctl_Panel
        Me.SlopeLabel = New DataStore.ctl_Label
        Me.SlopeControl = New DataStore.ctl_DoubleParameter
        Me.LevelSlopeLabel = New DataStore.ctl_Label
        Me.SlopeMessagePanel = New DataStore.ctl_Panel
        Me.SlopeMessage = New System.Windows.Forms.Label
        Me.InfiltrationSummary = New DataStore.ctl_GroupBox
        Me.GreenAmptPanel = New DataStore.ctl_Panel
        Me.GA_SWD = New System.Windows.Forms.Label
        Me.GA_cControl = New DataStore.ctl_DoubleParameter
        Me.GAcLabel = New DataStore.ctl_Label
        Me.GA_HydraulicConductivityControl = New DataStore.ctl_DoubleParameter
        Me.HydraulicConductivityLabel = New DataStore.ctl_Label
        Me.GA_WettingFrontControl = New DataStore.ctl_DoubleParameter
        Me.AirEntryPressureLabel = New DataStore.ctl_Label
        Me.GA_InitVolWaterContentControl = New DataStore.ctl_DoubleParameter
        Me.InitVolWaterContentLabel = New DataStore.ctl_Label
        Me.GA_PorosityControl = New DataStore.ctl_DoubleParameter
        Me.PorosityLabel = New DataStore.ctl_Label
        Me.WarrickGreenAmptPanel = New DataStore.ctl_Panel
        Me.WarrickGreenAmptCControl = New DataStore.ctl_DoubleParameter
        Me.WarrickGreenAmptCLabel = New DataStore.ctl_Label
        Me.HydraulicConductivityWGAControl = New DataStore.ctl_DoubleParameter
        Me.HydraulicConductivityWGALabel = New DataStore.ctl_Label
        Me.WettingFrontPressureWGAControl = New DataStore.ctl_DoubleParameter
        Me.WettingFrontPressureWGALabel = New DataStore.ctl_Label
        Me.InitialWaterContentWGAControl = New DataStore.ctl_DoubleParameter
        Me.InitialWaterContentWGALabel = New DataStore.ctl_Label
        Me.SaturatedWaterContentWGAControl = New DataStore.ctl_DoubleParameter
        Me.SaturatedWaterContentWGALabel = New DataStore.ctl_Label
        Me.HydrusPanel = New DataStore.ctl_Panel
        Me.HydrusImportLabel = New DataStore.ctl_Label
        Me.HydrusProject = New DataStore.ctl_StringParameter
        Me.InfiltrationLabel = New System.Windows.Forms.Label
        Me.TimeRatedIntakePanel = New DataStore.ctl_Panel
        Me.TR_InfiltrationDepth = New System.Windows.Forms.Label
        Me.TR_KostiakovA = New System.Windows.Forms.Label
        Me.TR_KostiakovK = New System.Windows.Forms.Label
        Me.TR_InfiltrationTimeControl = New DataStore.ctl_DoubleParameter
        Me.TR_InfiltrationTimeLabel = New DataStore.ctl_Label
        Me.TR_InfiltrationDepthLabel = New DataStore.ctl_Label
        Me.CharacteristicInfiltrationPanel = New DataStore.ctl_Panel
        Me.KT_KostiakovK = New System.Windows.Forms.Label
        Me.KT_InfiltrationTimeControl = New DataStore.ctl_DoubleParameter
        Me.KT_KostiakovAControl = New DataStore.ctl_DoubleParameter
        Me.KT_InfiltrationDepthControl = New DataStore.ctl_DoubleParameter
        Me.KT_InfiltrationTimeLabel = New DataStore.ctl_Label
        Me.KT_KostiakovALabel = New System.Windows.Forms.Label
        Me.KT_InfiltrationDepthLabel = New DataStore.ctl_Label
        Me.TabulatedInfiltrationPanel = New DataStore.ctl_Panel
        Me.TabulatedInfiltrationLabel = New DataStore.ctl_Label
        Me.BranchFunctionPanel = New DataStore.ctl_Panel
        Me.BF_BranchTime = New System.Windows.Forms.Label
        Me.BF_KostiakovKControl = New WinMain.ctl_KostiakovKParameter
        Me.BF_KostiakovKLabel = New System.Windows.Forms.Label
        Me.BF_BranchBControl = New DataStore.ctl_DoubleParameter
        Me.BF_KostiakovCControl = New DataStore.ctl_DoubleParameter
        Me.BF_KostiakovAControl = New DataStore.ctl_DoubleParameter
        Me.BF_BranchTimeLabel = New System.Windows.Forms.Label
        Me.BF_KostiakovBLabel = New System.Windows.Forms.Label
        Me.BF_KostiakovCLabel = New System.Windows.Forms.Label
        Me.BF_KostiakovALabel = New System.Windows.Forms.Label
        Me.ModifiedKostiakovPanel = New DataStore.ctl_Panel
        Me.MK_KostiakovAControl = New DataStore.ctl_DoubleParameter
        Me.MK_KostiakovKControl = New WinMain.ctl_KostiakovKParameter
        Me.MK_KostiakovCControl = New DataStore.ctl_DoubleParameter
        Me.MK_KostiakovBControl = New WinMain.ctl_KostiakovBParameter
        Me.MK_KostiakovALabel = New System.Windows.Forms.Label
        Me.MK_KostiakovKLabel = New System.Windows.Forms.Label
        Me.MK_KostiakovCLabel = New System.Windows.Forms.Label
        Me.MK_KostiakovBLabel = New System.Windows.Forms.Label
        Me.KostiakovPanel = New DataStore.ctl_Panel
        Me.KF_KostiakovAControl = New DataStore.ctl_DoubleParameter
        Me.KF_KostiakovKControl = New WinMain.ctl_KostiakovKParameter
        Me.KF_KostiakovALabel = New System.Windows.Forms.Label
        Me.KF_KostiakovKLabel = New System.Windows.Forms.Label
        Me.NrcsIntakePanel = New DataStore.ctl_Panel
        Me.NrcsCalculatedA = New System.Windows.Forms.Label
        Me.NrcsCalculatedK = New System.Windows.Forms.Label
        Me.RoughnessSummary = New DataStore.ctl_GroupBox
        Me.RoughnessLabel = New System.Windows.Forms.Label
        Me.NrcsSuggestedManningNPanel = New DataStore.ctl_Panel
        Me.UsersManningNControl = New DataStore.ctl_DoubleParameter
        Me.Sel_UserEntered = New DataStore.ctl_RadioButton
        Me.Sel_025 = New DataStore.ctl_RadioButton
        Me.Sel_020 = New DataStore.ctl_RadioButton
        Me.Sel_015 = New DataStore.ctl_RadioButton
        Me.Sel_010 = New DataStore.ctl_RadioButton
        Me.Sel_004 = New DataStore.ctl_RadioButton
        Me.ManningCnAnPanel = New DataStore.ctl_Panel
        Me.ManningAnControl = New DataStore.ctl_DoubleParameter
        Me.ManningAnLabel = New System.Windows.Forms.Label
        Me.ManningCnControl = New DataStore.ctl_DoubleParameter
        Me.ManningCnLabel = New System.Windows.Forms.Label
        Me.SayreChiPanel = New DataStore.ctl_Panel
        Me.SayreChiControl = New DataStore.ctl_DoubleParameter
        Me.SayreChiLabel = New System.Windows.Forms.Label
        Me.TabulatedRoughnessPanel = New DataStore.ctl_Panel
        Me.TabulatedRoughnessLabel = New DataStore.ctl_Label
        Me.InflowManagementSummary = New DataStore.ctl_GroupBox
        Me.SurgePanel = New DataStore.ctl_Panel
        Me.SurgeStrategyLabel = New System.Windows.Forms.Label
        Me.InflowManagementLabel = New System.Windows.Forms.Label
        Me.RequiredDepthControl = New DataStore.ctl_DoubleParameter
        Me.UnitWaterCostControl = New DataStore.ctl_DoubleParameter
        Me.RequiredDepthLabel = New DataStore.ctl_Label
        Me.UnitWaterCostLabel = New DataStore.ctl_Label
        Me.StandardHydrographPanel = New DataStore.ctl_Panel
        Me.InflowRateControl = New DataStore.ctl_DoubleParameter
        Me.InflowRateLabel = New DataStore.ctl_Label
        Me.CutoffCutbackLabel = New System.Windows.Forms.Label
        Me.CutoffUpstreamDepthPanel = New DataStore.ctl_Panel
        Me.CutoffUpstreamDepthControl = New DataStore.ctl_DoubleParameter
        Me.UpstreamDepthLabel = New DataStore.ctl_Label
        Me.CutoffLocationPanel = New DataStore.ctl_Panel
        Me.CutoffInfiltrationDepthControl = New DataStore.ctl_DoubleParameter
        Me.CutoffOpportunityTimeControl = New DataStore.ctl_DoubleParameter
        Me.OpportunityTimeLabel = New DataStore.ctl_Label
        Me.CutoffLocationLabel = New DataStore.ctl_Label
        Me.InfiltrationDepthLabel = New DataStore.ctl_Label
        Me.CutoffLocationControl = New DataStore.ctl_DoubleParameter
        Me.CutoffTimePanel = New DataStore.ctl_Panel
        Me.CutoffTimeControl = New DataStore.ctl_DoubleParameter
        Me.CutoffTimeLabel = New DataStore.ctl_Label
        Me.CutbackPanel = New DataStore.ctl_Panel
        Me.CutbackTimeControl = New DataStore.ctl_DoubleParameter
        Me.CutbackLocationControl = New DataStore.ctl_DoubleParameter
        Me.CutbackRateControl = New DataStore.ctl_DoubleParameter
        Me.CutbackRateLabel = New DataStore.ctl_Label
        Me.CutbackTimeLabel = New DataStore.ctl_Label
        Me.CutbackLocationLabel = New DataStore.ctl_Label
        Me.TabulatedPanel = New DataStore.ctl_Panel
        Me.CablegationPanel = New DataStore.ctl_Panel
        Me.CablegationLabel = New DataStore.ctl_Label
        Me.SystemGeometrySummary.SuspendLayout()
        Me.FurrowPanel.SuspendLayout()
        Me.FurrowSlopePanel.SuspendLayout()
        Me.FurrowSlopeMessagePanel.SuspendLayout()
        Me.TrapezoidPanel.SuspendLayout()
        Me.TabulatedCrossSectionPanel.SuspendLayout()
        Me.PowerLawPanel.SuspendLayout()
        Me.BasinBorderPanel.SuspendLayout()
        Me.SlopePanel.SuspendLayout()
        Me.SlopeMessagePanel.SuspendLayout()
        Me.InfiltrationSummary.SuspendLayout()
        Me.GreenAmptPanel.SuspendLayout()
        Me.WarrickGreenAmptPanel.SuspendLayout()
        Me.HydrusPanel.SuspendLayout()
        Me.TimeRatedIntakePanel.SuspendLayout()
        Me.CharacteristicInfiltrationPanel.SuspendLayout()
        Me.TabulatedInfiltrationPanel.SuspendLayout()
        Me.BranchFunctionPanel.SuspendLayout()
        Me.ModifiedKostiakovPanel.SuspendLayout()
        Me.KostiakovPanel.SuspendLayout()
        Me.NrcsIntakePanel.SuspendLayout()
        Me.RoughnessSummary.SuspendLayout()
        Me.NrcsSuggestedManningNPanel.SuspendLayout()
        Me.ManningCnAnPanel.SuspendLayout()
        Me.SayreChiPanel.SuspendLayout()
        Me.TabulatedRoughnessPanel.SuspendLayout()
        Me.InflowManagementSummary.SuspendLayout()
        Me.SurgePanel.SuspendLayout()
        Me.StandardHydrographPanel.SuspendLayout()
        Me.CutoffUpstreamDepthPanel.SuspendLayout()
        Me.CutoffLocationPanel.SuspendLayout()
        Me.CutoffTimePanel.SuspendLayout()
        Me.CutbackPanel.SuspendLayout()
        Me.CablegationPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'SystemGeometrySummary
        '
        Me.SystemGeometrySummary.AccessibleDescription = "Summary of the System Geometry data"
        Me.SystemGeometrySummary.AccessibleName = "System Geometry"
        Me.SystemGeometrySummary.Controls.Add(Me.FurrowPanel)
        Me.SystemGeometrySummary.Controls.Add(Me.BasinBorderPanel)
        Me.SystemGeometrySummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemGeometrySummary.Location = New System.Drawing.Point(8, 8)
        Me.SystemGeometrySummary.Name = "SystemGeometrySummary"
        Me.SystemGeometrySummary.Size = New System.Drawing.Size(376, 216)
        Me.SystemGeometrySummary.TabIndex = 0
        Me.SystemGeometrySummary.TabStop = False
        Me.SystemGeometrySummary.Text = "System Geometry"
        '
        'FurrowPanel
        '
        Me.FurrowPanel.Controls.Add(Me.FurrowLengthControl)
        Me.FurrowPanel.Controls.Add(Me.FurrowLengthLabel)
        Me.FurrowPanel.Controls.Add(Me.FurrowSpacingControl)
        Me.FurrowPanel.Controls.Add(Me.FurrowSpacingLabel)
        Me.FurrowPanel.Controls.Add(Me.FurrowLabel)
        Me.FurrowPanel.Controls.Add(Me.FurrowSlopePanel)
        Me.FurrowPanel.Controls.Add(Me.FurrowSlopeMessagePanel)
        Me.FurrowPanel.Controls.Add(Me.TrapezoidPanel)
        Me.FurrowPanel.Controls.Add(Me.TabulatedCrossSectionPanel)
        Me.FurrowPanel.Controls.Add(Me.PowerLawPanel)
        Me.FurrowPanel.Location = New System.Drawing.Point(8, 16)
        Me.FurrowPanel.Name = "FurrowPanel"
        Me.FurrowPanel.Size = New System.Drawing.Size(360, 192)
        Me.FurrowPanel.TabIndex = 0
        '
        'FurrowLengthControl
        '
        Me.FurrowLengthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.FurrowLengthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowLengthControl.IsCalculated = False
        Me.FurrowLengthControl.IsInteger = False
        Me.FurrowLengthControl.Location = New System.Drawing.Point(183, 56)
        Me.FurrowLengthControl.MaxErrMsg = ""
        Me.FurrowLengthControl.MinErrMsg = ""
        Me.FurrowLengthControl.Name = "FurrowLengthControl"
        Me.FurrowLengthControl.Size = New System.Drawing.Size(160, 24)
        Me.FurrowLengthControl.TabIndex = 3
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
        Me.FurrowLengthLabel.Location = New System.Drawing.Point(3, 56)
        Me.FurrowLengthLabel.Name = "FurrowLengthLabel"
        Me.FurrowLengthLabel.Size = New System.Drawing.Size(174, 23)
        Me.FurrowLengthLabel.TabIndex = 2
        Me.FurrowLengthLabel.Text = "Furrow &Length"
        Me.FurrowLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FurrowSpacingControl
        '
        Me.FurrowSpacingControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.FurrowSpacingControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowSpacingControl.IsCalculated = False
        Me.FurrowSpacingControl.IsInteger = False
        Me.FurrowSpacingControl.Location = New System.Drawing.Point(183, 32)
        Me.FurrowSpacingControl.MaxErrMsg = ""
        Me.FurrowSpacingControl.MinErrMsg = ""
        Me.FurrowSpacingControl.Name = "FurrowSpacingControl"
        Me.FurrowSpacingControl.Size = New System.Drawing.Size(160, 24)
        Me.FurrowSpacingControl.TabIndex = 1
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
        Me.FurrowSpacingLabel.Location = New System.Drawing.Point(3, 32)
        Me.FurrowSpacingLabel.Name = "FurrowSpacingLabel"
        Me.FurrowSpacingLabel.Size = New System.Drawing.Size(174, 23)
        Me.FurrowSpacingLabel.TabIndex = 0
        Me.FurrowSpacingLabel.Text = "Furrow S&pacing"
        Me.FurrowSpacingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FurrowLabel
        '
        Me.FurrowLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowLabel.Location = New System.Drawing.Point(0, 8)
        Me.FurrowLabel.Name = "FurrowLabel"
        Me.FurrowLabel.Size = New System.Drawing.Size(360, 23)
        Me.FurrowLabel.TabIndex = 0
        Me.FurrowLabel.Text = "Power Law Furrow, Drainback After Cutoff, Blocked End"
        Me.FurrowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FurrowSlopePanel
        '
        Me.FurrowSlopePanel.Controls.Add(Me.FurrowSlopeControl)
        Me.FurrowSlopePanel.Controls.Add(Me.FurrowSlopeLabel)
        Me.FurrowSlopePanel.Location = New System.Drawing.Point(8, 80)
        Me.FurrowSlopePanel.Name = "FurrowSlopePanel"
        Me.FurrowSlopePanel.Size = New System.Drawing.Size(341, 28)
        Me.FurrowSlopePanel.TabIndex = 4
        '
        'FurrowSlopeControl
        '
        Me.FurrowSlopeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.FurrowSlopeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowSlopeControl.IsCalculated = False
        Me.FurrowSlopeControl.IsInteger = False
        Me.FurrowSlopeControl.Location = New System.Drawing.Point(175, 2)
        Me.FurrowSlopeControl.MaxErrMsg = ""
        Me.FurrowSlopeControl.MinErrMsg = ""
        Me.FurrowSlopeControl.Name = "FurrowSlopeControl"
        Me.FurrowSlopeControl.Size = New System.Drawing.Size(160, 24)
        Me.FurrowSlopeControl.TabIndex = 1
        Me.FurrowSlopeControl.ToBeCalculated = True
        Me.FurrowSlopeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.FurrowSlopeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.FurrowSlopeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.FurrowSlopeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.FurrowSlopeControl.ValueText = ""
        '
        'FurrowSlopeLabel
        '
        Me.FurrowSlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowSlopeLabel.Location = New System.Drawing.Point(3, 2)
        Me.FurrowSlopeLabel.Name = "FurrowSlopeLabel"
        Me.FurrowSlopeLabel.Size = New System.Drawing.Size(166, 23)
        Me.FurrowSlopeLabel.TabIndex = 0
        Me.FurrowSlopeLabel.Text = "&Slope"
        Me.FurrowSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FurrowSlopeMessagePanel
        '
        Me.FurrowSlopeMessagePanel.Controls.Add(Me.FurrowSlopeMessage)
        Me.FurrowSlopeMessagePanel.Location = New System.Drawing.Point(8, 80)
        Me.FurrowSlopeMessagePanel.Name = "FurrowSlopeMessagePanel"
        Me.FurrowSlopeMessagePanel.Size = New System.Drawing.Size(328, 28)
        Me.FurrowSlopeMessagePanel.TabIndex = 4
        '
        'FurrowSlopeMessage
        '
        Me.FurrowSlopeMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowSlopeMessage.Location = New System.Drawing.Point(48, 4)
        Me.FurrowSlopeMessage.Name = "FurrowSlopeMessage"
        Me.FurrowSlopeMessage.Size = New System.Drawing.Size(272, 20)
        Me.FurrowSlopeMessage.TabIndex = 0
        Me.FurrowSlopeMessage.Text = "Average Slope = "
        Me.FurrowSlopeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TrapezoidPanel
        '
        Me.TrapezoidPanel.AccessibleDescription = "This set of parameters defines the shape of a trapezoidal furrow."
        Me.TrapezoidPanel.AccessibleName = "Trapezoid Furrow Parameters"
        Me.TrapezoidPanel.Controls.Add(Me.TrapezoidDepthControl)
        Me.TrapezoidPanel.Controls.Add(Me.SideSlopeControl)
        Me.TrapezoidPanel.Controls.Add(Me.BottomWidthControl)
        Me.TrapezoidPanel.Controls.Add(Me.TrapezoidDepthLabel)
        Me.TrapezoidPanel.Controls.Add(Me.SideSlopeLabel)
        Me.TrapezoidPanel.Controls.Add(Me.BottomWidthLabel)
        Me.TrapezoidPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrapezoidPanel.Location = New System.Drawing.Point(8, 104)
        Me.TrapezoidPanel.Name = "TrapezoidPanel"
        Me.TrapezoidPanel.Size = New System.Drawing.Size(341, 88)
        Me.TrapezoidPanel.TabIndex = 5
        '
        'TrapezoidDepthControl
        '
        Me.TrapezoidDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.TrapezoidDepthControl.IsCalculated = False
        Me.TrapezoidDepthControl.IsInteger = False
        Me.TrapezoidDepthControl.Location = New System.Drawing.Point(175, 7)
        Me.TrapezoidDepthControl.MaxErrMsg = ""
        Me.TrapezoidDepthControl.MinErrMsg = ""
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
        Me.SideSlopeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SideSlopeControl.IsCalculated = False
        Me.SideSlopeControl.IsInteger = False
        Me.SideSlopeControl.Location = New System.Drawing.Point(175, 56)
        Me.SideSlopeControl.MaxErrMsg = ""
        Me.SideSlopeControl.MinErrMsg = ""
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
        Me.BottomWidthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BottomWidthControl.IsCalculated = False
        Me.BottomWidthControl.IsInteger = False
        Me.BottomWidthControl.Location = New System.Drawing.Point(175, 31)
        Me.BottomWidthControl.MaxErrMsg = ""
        Me.BottomWidthControl.MinErrMsg = ""
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
        Me.TrapezoidDepthLabel.Location = New System.Drawing.Point(3, 8)
        Me.TrapezoidDepthLabel.Name = "TrapezoidDepthLabel"
        Me.TrapezoidDepthLabel.Size = New System.Drawing.Size(169, 23)
        Me.TrapezoidDepthLabel.TabIndex = 0
        Me.TrapezoidDepthLabel.Text = "&Maximum Depth"
        Me.TrapezoidDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SideSlopeLabel
        '
        Me.SideSlopeLabel.Location = New System.Drawing.Point(3, 56)
        Me.SideSlopeLabel.Name = "SideSlopeLabel"
        Me.SideSlopeLabel.Size = New System.Drawing.Size(166, 23)
        Me.SideSlopeLabel.TabIndex = 4
        Me.SideSlopeLabel.Text = "Side S&lope"
        Me.SideSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BottomWidthLabel
        '
        Me.BottomWidthLabel.Location = New System.Drawing.Point(3, 32)
        Me.BottomWidthLabel.Name = "BottomWidthLabel"
        Me.BottomWidthLabel.Size = New System.Drawing.Size(169, 23)
        Me.BottomWidthLabel.TabIndex = 2
        Me.BottomWidthLabel.Text = "Bottom &Width"
        Me.BottomWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabulatedCrossSectionPanel
        '
        Me.TabulatedCrossSectionPanel.Controls.Add(Me.TabulatedCrossSectionLabel)
        Me.TabulatedCrossSectionPanel.Location = New System.Drawing.Point(8, 104)
        Me.TabulatedCrossSectionPanel.Name = "TabulatedCrossSectionPanel"
        Me.TabulatedCrossSectionPanel.Size = New System.Drawing.Size(341, 88)
        Me.TabulatedCrossSectionPanel.TabIndex = 5
        '
        'TabulatedCrossSectionLabel
        '
        Me.TabulatedCrossSectionLabel.AutoSize = True
        Me.TabulatedCrossSectionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedCrossSectionLabel.Location = New System.Drawing.Point(48, 36)
        Me.TabulatedCrossSectionLabel.Name = "TabulatedCrossSectionLabel"
        Me.TabulatedCrossSectionLabel.Size = New System.Drawing.Size(163, 17)
        Me.TabulatedCrossSectionLabel.TabIndex = 0
        Me.TabulatedCrossSectionLabel.Text = "Tabulated Cross Section"
        '
        'PowerLawPanel
        '
        Me.PowerLawPanel.AccessibleDescription = "This set of parameters defines the shape of a power law furrow."
        Me.PowerLawPanel.AccessibleName = "Power Law Furrow Parameters"
        Me.PowerLawPanel.Controls.Add(Me.ExponentControl)
        Me.PowerLawPanel.Controls.Add(Me.PowerLawDepthControl)
        Me.PowerLawPanel.Controls.Add(Me.WidthAt100mmControl)
        Me.PowerLawPanel.Controls.Add(Me.PowerLawDepthLabel)
        Me.PowerLawPanel.Controls.Add(Me.ExponentLabel)
        Me.PowerLawPanel.Controls.Add(Me.WidthAt100mmLabel)
        Me.PowerLawPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PowerLawPanel.Location = New System.Drawing.Point(8, 104)
        Me.PowerLawPanel.Name = "PowerLawPanel"
        Me.PowerLawPanel.Size = New System.Drawing.Size(341, 88)
        Me.PowerLawPanel.TabIndex = 5
        '
        'ExponentControl
        '
        Me.ExponentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ExponentControl.IsCalculated = False
        Me.ExponentControl.IsInteger = False
        Me.ExponentControl.Location = New System.Drawing.Point(175, 56)
        Me.ExponentControl.MaxErrMsg = ""
        Me.ExponentControl.MinErrMsg = ""
        Me.ExponentControl.Name = "ExponentControl"
        Me.ExponentControl.Size = New System.Drawing.Size(160, 24)
        Me.ExponentControl.TabIndex = 5
        Me.ExponentControl.ToBeCalculated = True
        Me.ExponentControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ExponentControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ExponentControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ExponentControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ExponentControl.ValueText = ""
        '
        'PowerLawDepthControl
        '
        Me.PowerLawDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.PowerLawDepthControl.IsCalculated = False
        Me.PowerLawDepthControl.IsInteger = False
        Me.PowerLawDepthControl.Location = New System.Drawing.Point(175, 8)
        Me.PowerLawDepthControl.MaxErrMsg = ""
        Me.PowerLawDepthControl.MinErrMsg = ""
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
        Me.WidthAt100mmControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WidthAt100mmControl.IsCalculated = False
        Me.WidthAt100mmControl.IsInteger = False
        Me.WidthAt100mmControl.Location = New System.Drawing.Point(175, 32)
        Me.WidthAt100mmControl.MaxErrMsg = ""
        Me.WidthAt100mmControl.MinErrMsg = ""
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
        Me.PowerLawDepthLabel.Location = New System.Drawing.Point(3, 8)
        Me.PowerLawDepthLabel.Name = "PowerLawDepthLabel"
        Me.PowerLawDepthLabel.Size = New System.Drawing.Size(166, 23)
        Me.PowerLawDepthLabel.TabIndex = 0
        Me.PowerLawDepthLabel.Text = "&Maximum Depth"
        Me.PowerLawDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ExponentLabel
        '
        Me.ExponentLabel.Location = New System.Drawing.Point(3, 56)
        Me.ExponentLabel.Name = "ExponentLabel"
        Me.ExponentLabel.Size = New System.Drawing.Size(166, 23)
        Me.ExponentLabel.TabIndex = 4
        Me.ExponentLabel.Text = "&Exponent"
        Me.ExponentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WidthAt100mmLabel
        '
        Me.WidthAt100mmLabel.Location = New System.Drawing.Point(3, 32)
        Me.WidthAt100mmLabel.Name = "WidthAt100mmLabel"
        Me.WidthAt100mmLabel.Size = New System.Drawing.Size(166, 23)
        Me.WidthAt100mmLabel.TabIndex = 2
        Me.WidthAt100mmLabel.Text = "&Width at ..."
        Me.WidthAt100mmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BasinBorderPanel
        '
        Me.BasinBorderPanel.AccessibleName = ""
        Me.BasinBorderPanel.Controls.Add(Me.DepthControl)
        Me.BasinBorderPanel.Controls.Add(Me.DepthLabel)
        Me.BasinBorderPanel.Controls.Add(Me.LengthControl)
        Me.BasinBorderPanel.Controls.Add(Me.LengthLabel)
        Me.BasinBorderPanel.Controls.Add(Me.WidthControl)
        Me.BasinBorderPanel.Controls.Add(Me.WidthLabel)
        Me.BasinBorderPanel.Controls.Add(Me.BasinBorderLabel)
        Me.BasinBorderPanel.Controls.Add(Me.SlopePanel)
        Me.BasinBorderPanel.Controls.Add(Me.SlopeMessagePanel)
        Me.BasinBorderPanel.Location = New System.Drawing.Point(8, 16)
        Me.BasinBorderPanel.Name = "BasinBorderPanel"
        Me.BasinBorderPanel.Size = New System.Drawing.Size(360, 192)
        Me.BasinBorderPanel.TabIndex = 0
        '
        'DepthControl
        '
        Me.DepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.DepthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthControl.IsCalculated = False
        Me.DepthControl.IsInteger = False
        Me.DepthControl.Location = New System.Drawing.Point(183, 136)
        Me.DepthControl.MaxErrMsg = ""
        Me.DepthControl.MinErrMsg = ""
        Me.DepthControl.Name = "DepthControl"
        Me.DepthControl.Size = New System.Drawing.Size(160, 24)
        Me.DepthControl.TabIndex = 8
        Me.DepthControl.ToBeCalculated = True
        Me.DepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.DepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.DepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.DepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.DepthControl.ValueText = ""
        '
        'DepthLabel
        '
        Me.DepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthLabel.Location = New System.Drawing.Point(8, 136)
        Me.DepthLabel.Name = "DepthLabel"
        Me.DepthLabel.Size = New System.Drawing.Size(169, 23)
        Me.DepthLabel.TabIndex = 7
        Me.DepthLabel.Text = "&Depth"
        Me.DepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LengthControl
        '
        Me.LengthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.LengthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LengthControl.IsCalculated = False
        Me.LengthControl.IsInteger = False
        Me.LengthControl.Location = New System.Drawing.Point(183, 80)
        Me.LengthControl.MaxErrMsg = ""
        Me.LengthControl.MinErrMsg = ""
        Me.LengthControl.Name = "LengthControl"
        Me.LengthControl.Size = New System.Drawing.Size(160, 24)
        Me.LengthControl.TabIndex = 4
        Me.LengthControl.ToBeCalculated = True
        Me.LengthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.LengthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.LengthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.LengthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.LengthControl.ValueText = ""
        '
        'LengthLabel
        '
        Me.LengthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LengthLabel.Location = New System.Drawing.Point(7, 80)
        Me.LengthLabel.Name = "LengthLabel"
        Me.LengthLabel.Size = New System.Drawing.Size(170, 23)
        Me.LengthLabel.TabIndex = 3
        Me.LengthLabel.Text = "&Length"
        Me.LengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WidthControl
        '
        Me.WidthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WidthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WidthControl.IsCalculated = False
        Me.WidthControl.IsInteger = False
        Me.WidthControl.Location = New System.Drawing.Point(183, 104)
        Me.WidthControl.MaxErrMsg = ""
        Me.WidthControl.MinErrMsg = ""
        Me.WidthControl.Name = "WidthControl"
        Me.WidthControl.Size = New System.Drawing.Size(160, 24)
        Me.WidthControl.TabIndex = 6
        Me.WidthControl.ToBeCalculated = True
        Me.WidthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WidthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WidthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WidthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WidthControl.ValueText = ""
        '
        'WidthLabel
        '
        Me.WidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WidthLabel.Location = New System.Drawing.Point(8, 104)
        Me.WidthLabel.Name = "WidthLabel"
        Me.WidthLabel.Size = New System.Drawing.Size(169, 23)
        Me.WidthLabel.TabIndex = 5
        Me.WidthLabel.Text = "&Width"
        Me.WidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BasinBorderLabel
        '
        Me.BasinBorderLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BasinBorderLabel.Location = New System.Drawing.Point(8, 8)
        Me.BasinBorderLabel.Name = "BasinBorderLabel"
        Me.BasinBorderLabel.Size = New System.Drawing.Size(344, 24)
        Me.BasinBorderLabel.TabIndex = 0
        Me.BasinBorderLabel.Text = "Basin / Border, Drainback after Cutoff, Blocked End"
        Me.BasinBorderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SlopePanel
        '
        Me.SlopePanel.Controls.Add(Me.SlopeLabel)
        Me.SlopePanel.Controls.Add(Me.SlopeControl)
        Me.SlopePanel.Controls.Add(Me.LevelSlopeLabel)
        Me.SlopePanel.Location = New System.Drawing.Point(8, 40)
        Me.SlopePanel.Name = "SlopePanel"
        Me.SlopePanel.Size = New System.Drawing.Size(344, 40)
        Me.SlopePanel.TabIndex = 1
        '
        'SlopeLabel
        '
        Me.SlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SlopeLabel.Location = New System.Drawing.Point(3, 8)
        Me.SlopeLabel.Name = "SlopeLabel"
        Me.SlopeLabel.Size = New System.Drawing.Size(166, 23)
        Me.SlopeLabel.TabIndex = 0
        Me.SlopeLabel.Text = "&Slope"
        Me.SlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SlopeControl
        '
        Me.SlopeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SlopeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SlopeControl.IsCalculated = False
        Me.SlopeControl.IsInteger = False
        Me.SlopeControl.Location = New System.Drawing.Point(175, 8)
        Me.SlopeControl.MaxErrMsg = ""
        Me.SlopeControl.MinErrMsg = ""
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
        'LevelSlopeLabel
        '
        Me.LevelSlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LevelSlopeLabel.Location = New System.Drawing.Point(175, 8)
        Me.LevelSlopeLabel.Name = "LevelSlopeLabel"
        Me.LevelSlopeLabel.Size = New System.Drawing.Size(160, 23)
        Me.LevelSlopeLabel.TabIndex = 12
        Me.LevelSlopeLabel.Text = "Level"
        Me.LevelSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SlopeMessagePanel
        '
        Me.SlopeMessagePanel.Controls.Add(Me.SlopeMessage)
        Me.SlopeMessagePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SlopeMessagePanel.Location = New System.Drawing.Point(8, 40)
        Me.SlopeMessagePanel.Name = "SlopeMessagePanel"
        Me.SlopeMessagePanel.Size = New System.Drawing.Size(344, 40)
        Me.SlopeMessagePanel.TabIndex = 1
        '
        'SlopeMessage
        '
        Me.SlopeMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SlopeMessage.Location = New System.Drawing.Point(48, 8)
        Me.SlopeMessage.Name = "SlopeMessage"
        Me.SlopeMessage.Size = New System.Drawing.Size(248, 23)
        Me.SlopeMessage.TabIndex = 0
        Me.SlopeMessage.Text = "Average Slope = "
        Me.SlopeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InfiltrationSummary
        '
        Me.InfiltrationSummary.AccessibleDescription = "Summary of the Infiltration data"
        Me.InfiltrationSummary.AccessibleName = "Infiltration"
        Me.InfiltrationSummary.Controls.Add(Me.BranchFunctionPanel)
        Me.InfiltrationSummary.Controls.Add(Me.GreenAmptPanel)
        Me.InfiltrationSummary.Controls.Add(Me.WarrickGreenAmptPanel)
        Me.InfiltrationSummary.Controls.Add(Me.HydrusPanel)
        Me.InfiltrationSummary.Controls.Add(Me.InfiltrationLabel)
        Me.InfiltrationSummary.Controls.Add(Me.TimeRatedIntakePanel)
        Me.InfiltrationSummary.Controls.Add(Me.CharacteristicInfiltrationPanel)
        Me.InfiltrationSummary.Controls.Add(Me.TabulatedInfiltrationPanel)
        Me.InfiltrationSummary.Controls.Add(Me.ModifiedKostiakovPanel)
        Me.InfiltrationSummary.Controls.Add(Me.KostiakovPanel)
        Me.InfiltrationSummary.Controls.Add(Me.NrcsIntakePanel)
        Me.InfiltrationSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationSummary.Location = New System.Drawing.Point(8, 232)
        Me.InfiltrationSummary.Name = "InfiltrationSummary"
        Me.InfiltrationSummary.Size = New System.Drawing.Size(376, 184)
        Me.InfiltrationSummary.TabIndex = 1
        Me.InfiltrationSummary.TabStop = False
        Me.InfiltrationSummary.Text = "Infiltration"
        '
        'GreenAmptPanel
        '
        Me.GreenAmptPanel.AccessibleDescription = "Summary of the Green-Ampt Infiltration data"
        Me.GreenAmptPanel.AccessibleName = "Green-Ampt Parameters"
        Me.GreenAmptPanel.Controls.Add(Me.GA_SWD)
        Me.GreenAmptPanel.Controls.Add(Me.GA_cControl)
        Me.GreenAmptPanel.Controls.Add(Me.GAcLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_HydraulicConductivityControl)
        Me.GreenAmptPanel.Controls.Add(Me.HydraulicConductivityLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_WettingFrontControl)
        Me.GreenAmptPanel.Controls.Add(Me.AirEntryPressureLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_InitVolWaterContentControl)
        Me.GreenAmptPanel.Controls.Add(Me.InitVolWaterContentLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_PorosityControl)
        Me.GreenAmptPanel.Controls.Add(Me.PorosityLabel)
        Me.GreenAmptPanel.Location = New System.Drawing.Point(8, 48)
        Me.GreenAmptPanel.Name = "GreenAmptPanel"
        Me.GreenAmptPanel.Size = New System.Drawing.Size(360, 128)
        Me.GreenAmptPanel.TabIndex = 3
        '
        'GA_SWD
        '
        Me.GA_SWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_SWD.Location = New System.Drawing.Point(294, 2)
        Me.GA_SWD.Name = "GA_SWD"
        Me.GA_SWD.Size = New System.Drawing.Size(63, 49)
        Me.GA_SWD.TabIndex = 33
        Me.GA_SWD.Text = " SWD  0.123 L/L"
        Me.GA_SWD.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GA_cControl
        '
        Me.GA_cControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_cControl.IsCalculated = False
        Me.GA_cControl.IsInteger = False
        Me.GA_cControl.Location = New System.Drawing.Point(184, 101)
        Me.GA_cControl.MaxErrMsg = ""
        Me.GA_cControl.MinErrMsg = ""
        Me.GA_cControl.Name = "GA_cControl"
        Me.GA_cControl.Size = New System.Drawing.Size(124, 24)
        Me.GA_cControl.TabIndex = 31
        Me.GA_cControl.ToBeCalculated = True
        Me.GA_cControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_cControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_cControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_cControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_cControl.ValueText = ""
        '
        'GAcLabel
        '
        Me.GAcLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GAcLabel.Location = New System.Drawing.Point(4, 100)
        Me.GAcLabel.Name = "GAcLabel"
        Me.GAcLabel.Size = New System.Drawing.Size(173, 21)
        Me.GAcLabel.TabIndex = 30
        Me.GAcLabel.Text = "&Macropore Infiltration"
        Me.GAcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_HydraulicConductivityControl
        '
        Me.GA_HydraulicConductivityControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_HydraulicConductivityControl.IsCalculated = False
        Me.GA_HydraulicConductivityControl.IsInteger = False
        Me.GA_HydraulicConductivityControl.Location = New System.Drawing.Point(184, 76)
        Me.GA_HydraulicConductivityControl.MaxErrMsg = ""
        Me.GA_HydraulicConductivityControl.MinErrMsg = ""
        Me.GA_HydraulicConductivityControl.Name = "GA_HydraulicConductivityControl"
        Me.GA_HydraulicConductivityControl.Size = New System.Drawing.Size(124, 24)
        Me.GA_HydraulicConductivityControl.TabIndex = 29
        Me.GA_HydraulicConductivityControl.ToBeCalculated = True
        Me.GA_HydraulicConductivityControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_HydraulicConductivityControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_HydraulicConductivityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_HydraulicConductivityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_HydraulicConductivityControl.ValueText = ""
        '
        'HydraulicConductivityLabel
        '
        Me.HydraulicConductivityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HydraulicConductivityLabel.Location = New System.Drawing.Point(4, 76)
        Me.HydraulicConductivityLabel.Name = "HydraulicConductivityLabel"
        Me.HydraulicConductivityLabel.Size = New System.Drawing.Size(173, 21)
        Me.HydraulicConductivityLabel.TabIndex = 28
        Me.HydraulicConductivityLabel.Text = "&Hydraulic Conductivity"
        Me.HydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_WettingFrontControl
        '
        Me.GA_WettingFrontControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_WettingFrontControl.IsCalculated = False
        Me.GA_WettingFrontControl.IsInteger = False
        Me.GA_WettingFrontControl.Location = New System.Drawing.Point(184, 51)
        Me.GA_WettingFrontControl.MaxErrMsg = ""
        Me.GA_WettingFrontControl.MinErrMsg = ""
        Me.GA_WettingFrontControl.Name = "GA_WettingFrontControl"
        Me.GA_WettingFrontControl.Size = New System.Drawing.Size(110, 24)
        Me.GA_WettingFrontControl.TabIndex = 27
        Me.GA_WettingFrontControl.ToBeCalculated = True
        Me.GA_WettingFrontControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_WettingFrontControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_WettingFrontControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_WettingFrontControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_WettingFrontControl.ValueText = ""
        '
        'AirEntryPressureLabel
        '
        Me.AirEntryPressureLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AirEntryPressureLabel.Location = New System.Drawing.Point(4, 52)
        Me.AirEntryPressureLabel.Name = "AirEntryPressureLabel"
        Me.AirEntryPressureLabel.Size = New System.Drawing.Size(173, 21)
        Me.AirEntryPressureLabel.TabIndex = 26
        Me.AirEntryPressureLabel.Text = "&Wetting Front Pressure"
        Me.AirEntryPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_InitVolWaterContentControl
        '
        Me.GA_InitVolWaterContentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_InitVolWaterContentControl.IsCalculated = False
        Me.GA_InitVolWaterContentControl.IsInteger = False
        Me.GA_InitVolWaterContentControl.Location = New System.Drawing.Point(184, 26)
        Me.GA_InitVolWaterContentControl.MaxErrMsg = ""
        Me.GA_InitVolWaterContentControl.MinErrMsg = ""
        Me.GA_InitVolWaterContentControl.Name = "GA_InitVolWaterContentControl"
        Me.GA_InitVolWaterContentControl.Size = New System.Drawing.Size(110, 24)
        Me.GA_InitVolWaterContentControl.TabIndex = 25
        Me.GA_InitVolWaterContentControl.ToBeCalculated = True
        Me.GA_InitVolWaterContentControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_InitVolWaterContentControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_InitVolWaterContentControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_InitVolWaterContentControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_InitVolWaterContentControl.ValueText = ""
        '
        'InitVolWaterContentLabel
        '
        Me.InitVolWaterContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InitVolWaterContentLabel.Location = New System.Drawing.Point(4, 28)
        Me.InitVolWaterContentLabel.Name = "InitVolWaterContentLabel"
        Me.InitVolWaterContentLabel.Size = New System.Drawing.Size(173, 21)
        Me.InitVolWaterContentLabel.TabIndex = 24
        Me.InitVolWaterContentLabel.Text = "Initial &Water Content"
        Me.InitVolWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_PorosityControl
        '
        Me.GA_PorosityControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_PorosityControl.IsCalculated = False
        Me.GA_PorosityControl.IsInteger = False
        Me.GA_PorosityControl.Location = New System.Drawing.Point(184, 1)
        Me.GA_PorosityControl.MaxErrMsg = ""
        Me.GA_PorosityControl.MinErrMsg = ""
        Me.GA_PorosityControl.Name = "GA_PorosityControl"
        Me.GA_PorosityControl.Size = New System.Drawing.Size(110, 24)
        Me.GA_PorosityControl.TabIndex = 23
        Me.GA_PorosityControl.ToBeCalculated = True
        Me.GA_PorosityControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_PorosityControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_PorosityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_PorosityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_PorosityControl.ValueText = ""
        '
        'PorosityLabel
        '
        Me.PorosityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PorosityLabel.Location = New System.Drawing.Point(4, 4)
        Me.PorosityLabel.Name = "PorosityLabel"
        Me.PorosityLabel.Size = New System.Drawing.Size(173, 21)
        Me.PorosityLabel.TabIndex = 22
        Me.PorosityLabel.Text = "&Saturated Water Content"
        Me.PorosityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WarrickGreenAmptPanel
        '
        Me.WarrickGreenAmptPanel.AccessibleDescription = "Summary of the Green-Ampt Infiltration data"
        Me.WarrickGreenAmptPanel.AccessibleName = "Green-Ampt Parameters"
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WarrickGreenAmptCControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WarrickGreenAmptCLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.HydraulicConductivityWGAControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.HydraulicConductivityWGALabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WettingFrontPressureWGAControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WettingFrontPressureWGALabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.InitialWaterContentWGAControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.InitialWaterContentWGALabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.SaturatedWaterContentWGAControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.SaturatedWaterContentWGALabel)
        Me.WarrickGreenAmptPanel.Location = New System.Drawing.Point(8, 48)
        Me.WarrickGreenAmptPanel.Name = "WarrickGreenAmptPanel"
        Me.WarrickGreenAmptPanel.Size = New System.Drawing.Size(360, 128)
        Me.WarrickGreenAmptPanel.TabIndex = 4
        '
        'WarrickGreenAmptCControl
        '
        Me.WarrickGreenAmptCControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WarrickGreenAmptCControl.IsCalculated = False
        Me.WarrickGreenAmptCControl.IsInteger = False
        Me.WarrickGreenAmptCControl.Location = New System.Drawing.Point(184, 101)
        Me.WarrickGreenAmptCControl.MaxErrMsg = ""
        Me.WarrickGreenAmptCControl.MinErrMsg = ""
        Me.WarrickGreenAmptCControl.Name = "WarrickGreenAmptCControl"
        Me.WarrickGreenAmptCControl.Size = New System.Drawing.Size(124, 24)
        Me.WarrickGreenAmptCControl.TabIndex = 31
        Me.WarrickGreenAmptCControl.ToBeCalculated = True
        Me.WarrickGreenAmptCControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WarrickGreenAmptCControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WarrickGreenAmptCControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WarrickGreenAmptCControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WarrickGreenAmptCControl.ValueText = ""
        '
        'WarrickGreenAmptCLabel
        '
        Me.WarrickGreenAmptCLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WarrickGreenAmptCLabel.Location = New System.Drawing.Point(4, 100)
        Me.WarrickGreenAmptCLabel.Name = "WarrickGreenAmptCLabel"
        Me.WarrickGreenAmptCLabel.Size = New System.Drawing.Size(173, 21)
        Me.WarrickGreenAmptCLabel.TabIndex = 30
        Me.WarrickGreenAmptCLabel.Text = "&Macropore Infiltration"
        Me.WarrickGreenAmptCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HydraulicConductivityWGAControl
        '
        Me.HydraulicConductivityWGAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.HydraulicConductivityWGAControl.IsCalculated = False
        Me.HydraulicConductivityWGAControl.IsInteger = False
        Me.HydraulicConductivityWGAControl.Location = New System.Drawing.Point(184, 76)
        Me.HydraulicConductivityWGAControl.MaxErrMsg = ""
        Me.HydraulicConductivityWGAControl.MinErrMsg = ""
        Me.HydraulicConductivityWGAControl.Name = "HydraulicConductivityWGAControl"
        Me.HydraulicConductivityWGAControl.Size = New System.Drawing.Size(124, 24)
        Me.HydraulicConductivityWGAControl.TabIndex = 29
        Me.HydraulicConductivityWGAControl.ToBeCalculated = True
        Me.HydraulicConductivityWGAControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.HydraulicConductivityWGAControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.HydraulicConductivityWGAControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.HydraulicConductivityWGAControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.HydraulicConductivityWGAControl.ValueText = ""
        '
        'HydraulicConductivityWGALabel
        '
        Me.HydraulicConductivityWGALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HydraulicConductivityWGALabel.Location = New System.Drawing.Point(4, 76)
        Me.HydraulicConductivityWGALabel.Name = "HydraulicConductivityWGALabel"
        Me.HydraulicConductivityWGALabel.Size = New System.Drawing.Size(173, 21)
        Me.HydraulicConductivityWGALabel.TabIndex = 28
        Me.HydraulicConductivityWGALabel.Text = "&Hydraulic Conductivity"
        Me.HydraulicConductivityWGALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WettingFrontPressureWGAControl
        '
        Me.WettingFrontPressureWGAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WettingFrontPressureWGAControl.IsCalculated = False
        Me.WettingFrontPressureWGAControl.IsInteger = False
        Me.WettingFrontPressureWGAControl.Location = New System.Drawing.Point(184, 51)
        Me.WettingFrontPressureWGAControl.MaxErrMsg = ""
        Me.WettingFrontPressureWGAControl.MinErrMsg = ""
        Me.WettingFrontPressureWGAControl.Name = "WettingFrontPressureWGAControl"
        Me.WettingFrontPressureWGAControl.Size = New System.Drawing.Size(110, 24)
        Me.WettingFrontPressureWGAControl.TabIndex = 27
        Me.WettingFrontPressureWGAControl.ToBeCalculated = True
        Me.WettingFrontPressureWGAControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WettingFrontPressureWGAControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WettingFrontPressureWGAControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WettingFrontPressureWGAControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WettingFrontPressureWGAControl.ValueText = ""
        '
        'WettingFrontPressureWGALabel
        '
        Me.WettingFrontPressureWGALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WettingFrontPressureWGALabel.Location = New System.Drawing.Point(4, 52)
        Me.WettingFrontPressureWGALabel.Name = "WettingFrontPressureWGALabel"
        Me.WettingFrontPressureWGALabel.Size = New System.Drawing.Size(173, 21)
        Me.WettingFrontPressureWGALabel.TabIndex = 26
        Me.WettingFrontPressureWGALabel.Text = "&Wetting Front Pressure"
        Me.WettingFrontPressureWGALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InitialWaterContentWGAControl
        '
        Me.InitialWaterContentWGAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.InitialWaterContentWGAControl.IsCalculated = False
        Me.InitialWaterContentWGAControl.IsInteger = False
        Me.InitialWaterContentWGAControl.Location = New System.Drawing.Point(184, 26)
        Me.InitialWaterContentWGAControl.MaxErrMsg = ""
        Me.InitialWaterContentWGAControl.MinErrMsg = ""
        Me.InitialWaterContentWGAControl.Name = "InitialWaterContentWGAControl"
        Me.InitialWaterContentWGAControl.Size = New System.Drawing.Size(110, 24)
        Me.InitialWaterContentWGAControl.TabIndex = 25
        Me.InitialWaterContentWGAControl.ToBeCalculated = True
        Me.InitialWaterContentWGAControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.InitialWaterContentWGAControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.InitialWaterContentWGAControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.InitialWaterContentWGAControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.InitialWaterContentWGAControl.ValueText = ""
        '
        'InitialWaterContentWGALabel
        '
        Me.InitialWaterContentWGALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InitialWaterContentWGALabel.Location = New System.Drawing.Point(4, 28)
        Me.InitialWaterContentWGALabel.Name = "InitialWaterContentWGALabel"
        Me.InitialWaterContentWGALabel.Size = New System.Drawing.Size(173, 21)
        Me.InitialWaterContentWGALabel.TabIndex = 24
        Me.InitialWaterContentWGALabel.Text = "&Initial Water Content"
        Me.InitialWaterContentWGALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SaturatedWaterContentWGAControl
        '
        Me.SaturatedWaterContentWGAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SaturatedWaterContentWGAControl.IsCalculated = False
        Me.SaturatedWaterContentWGAControl.IsInteger = False
        Me.SaturatedWaterContentWGAControl.Location = New System.Drawing.Point(184, 1)
        Me.SaturatedWaterContentWGAControl.MaxErrMsg = ""
        Me.SaturatedWaterContentWGAControl.MinErrMsg = ""
        Me.SaturatedWaterContentWGAControl.Name = "SaturatedWaterContentWGAControl"
        Me.SaturatedWaterContentWGAControl.Size = New System.Drawing.Size(110, 24)
        Me.SaturatedWaterContentWGAControl.TabIndex = 23
        Me.SaturatedWaterContentWGAControl.ToBeCalculated = True
        Me.SaturatedWaterContentWGAControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SaturatedWaterContentWGAControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SaturatedWaterContentWGAControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SaturatedWaterContentWGAControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SaturatedWaterContentWGAControl.ValueText = ""
        '
        'SaturatedWaterContentWGALabel
        '
        Me.SaturatedWaterContentWGALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaturatedWaterContentWGALabel.Location = New System.Drawing.Point(4, 4)
        Me.SaturatedWaterContentWGALabel.Name = "SaturatedWaterContentWGALabel"
        Me.SaturatedWaterContentWGALabel.Size = New System.Drawing.Size(173, 21)
        Me.SaturatedWaterContentWGALabel.TabIndex = 22
        Me.SaturatedWaterContentWGALabel.Text = "&Saturated Water Content"
        Me.SaturatedWaterContentWGALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HydrusPanel
        '
        Me.HydrusPanel.Controls.Add(Me.HydrusImportLabel)
        Me.HydrusPanel.Controls.Add(Me.HydrusProject)
        Me.HydrusPanel.Location = New System.Drawing.Point(8, 48)
        Me.HydrusPanel.Name = "HydrusPanel"
        Me.HydrusPanel.Size = New System.Drawing.Size(360, 128)
        Me.HydrusPanel.TabIndex = 1
        '
        'HydrusImportLabel
        '
        Me.HydrusImportLabel.AutoSize = True
        Me.HydrusImportLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HydrusImportLabel.Location = New System.Drawing.Point(4, 10)
        Me.HydrusImportLabel.Name = "HydrusImportLabel"
        Me.HydrusImportLabel.Size = New System.Drawing.Size(266, 17)
        Me.HydrusImportLabel.TabIndex = 3
        Me.HydrusImportLabel.Text = "HYDRUS Infiltration Table imported from:"
        '
        'HydrusProject
        '
        Me.HydrusProject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HydrusProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HydrusProject.Location = New System.Drawing.Point(8, 40)
        Me.HydrusProject.Name = "HydrusProject"
        Me.HydrusProject.ReadOnly = True
        Me.HydrusProject.Size = New System.Drawing.Size(340, 16)
        Me.HydrusProject.TabIndex = 2
        Me.HydrusProject.Text = "Use ""Select Hydrus Project..."" to select a HYDRUS project"
        Me.HydrusProject.WordWrap = False
        '
        'InfiltrationLabel
        '
        Me.InfiltrationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationLabel.Location = New System.Drawing.Point(8, 20)
        Me.InfiltrationLabel.Name = "InfiltrationLabel"
        Me.InfiltrationLabel.Size = New System.Drawing.Size(360, 28)
        Me.InfiltrationLabel.TabIndex = 0
        Me.InfiltrationLabel.Text = "Characteristic Infiltration Time"
        '
        'TimeRatedIntakePanel
        '
        Me.TimeRatedIntakePanel.AccessibleDescription = resources.GetString("TimeRatedIntakePanel.AccessibleDescription")
        Me.TimeRatedIntakePanel.AccessibleName = "Time Rated Intake Parameters"
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_InfiltrationDepth)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_KostiakovA)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_KostiakovK)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_InfiltrationTimeControl)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_InfiltrationTimeLabel)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_InfiltrationDepthLabel)
        Me.TimeRatedIntakePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeRatedIntakePanel.Location = New System.Drawing.Point(8, 48)
        Me.TimeRatedIntakePanel.Name = "TimeRatedIntakePanel"
        Me.TimeRatedIntakePanel.Size = New System.Drawing.Size(360, 128)
        Me.TimeRatedIntakePanel.TabIndex = 1
        '
        'TR_InfiltrationDepth
        '
        Me.TR_InfiltrationDepth.Location = New System.Drawing.Point(250, 56)
        Me.TR_InfiltrationDepth.Name = "TR_InfiltrationDepth"
        Me.TR_InfiltrationDepth.Size = New System.Drawing.Size(107, 23)
        Me.TR_InfiltrationDepth.TabIndex = 1
        Me.TR_InfiltrationDepth.Text = "100 mm"
        Me.TR_InfiltrationDepth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_KostiakovA
        '
        Me.TR_KostiakovA.Location = New System.Drawing.Point(208, 16)
        Me.TR_KostiakovA.Name = "TR_KostiakovA"
        Me.TR_KostiakovA.Size = New System.Drawing.Size(144, 23)
        Me.TR_KostiakovA.TabIndex = 5
        Me.TR_KostiakovA.Text = "Kostiakov a = "
        Me.TR_KostiakovA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_KostiakovK
        '
        Me.TR_KostiakovK.Location = New System.Drawing.Point(16, 16)
        Me.TR_KostiakovK.Name = "TR_KostiakovK"
        Me.TR_KostiakovK.Size = New System.Drawing.Size(192, 23)
        Me.TR_KostiakovK.TabIndex = 4
        Me.TR_KostiakovK.Text = "Kostiakov k = "
        Me.TR_KostiakovK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_InfiltrationTimeControl
        '
        Me.TR_InfiltrationTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.TR_InfiltrationTimeControl.IsCalculated = False
        Me.TR_InfiltrationTimeControl.IsInteger = False
        Me.TR_InfiltrationTimeControl.Location = New System.Drawing.Point(250, 80)
        Me.TR_InfiltrationTimeControl.MaxErrMsg = ""
        Me.TR_InfiltrationTimeControl.MinErrMsg = ""
        Me.TR_InfiltrationTimeControl.Name = "TR_InfiltrationTimeControl"
        Me.TR_InfiltrationTimeControl.Size = New System.Drawing.Size(107, 24)
        Me.TR_InfiltrationTimeControl.TabIndex = 3
        Me.TR_InfiltrationTimeControl.ToBeCalculated = True
        Me.TR_InfiltrationTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.TR_InfiltrationTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.TR_InfiltrationTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.TR_InfiltrationTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.TR_InfiltrationTimeControl.ValueText = ""
        '
        'TR_InfiltrationTimeLabel
        '
        Me.TR_InfiltrationTimeLabel.Location = New System.Drawing.Point(3, 80)
        Me.TR_InfiltrationTimeLabel.Name = "TR_InfiltrationTimeLabel"
        Me.TR_InfiltrationTimeLabel.Size = New System.Drawing.Size(245, 23)
        Me.TR_InfiltrationTimeLabel.TabIndex = 2
        Me.TR_InfiltrationTimeLabel.Text = "C&orresponding Infiltration Time"
        Me.TR_InfiltrationTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TR_InfiltrationDepthLabel
        '
        Me.TR_InfiltrationDepthLabel.Location = New System.Drawing.Point(3, 56)
        Me.TR_InfiltrationDepthLabel.Name = "TR_InfiltrationDepthLabel"
        Me.TR_InfiltrationDepthLabel.Size = New System.Drawing.Size(245, 23)
        Me.TR_InfiltrationDepthLabel.TabIndex = 0
        Me.TR_InfiltrationDepthLabel.Text = "Characteristic Infiltration Depth"
        Me.TR_InfiltrationDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CharacteristicInfiltrationPanel
        '
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_KostiakovK)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_InfiltrationTimeControl)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_KostiakovAControl)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_InfiltrationDepthControl)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_InfiltrationTimeLabel)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_KostiakovALabel)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_InfiltrationDepthLabel)
        Me.CharacteristicInfiltrationPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CharacteristicInfiltrationPanel.Location = New System.Drawing.Point(8, 48)
        Me.CharacteristicInfiltrationPanel.Name = "CharacteristicInfiltrationPanel"
        Me.CharacteristicInfiltrationPanel.Size = New System.Drawing.Size(360, 128)
        Me.CharacteristicInfiltrationPanel.TabIndex = 1
        '
        'KT_KostiakovK
        '
        Me.KT_KostiakovK.Location = New System.Drawing.Point(16, 16)
        Me.KT_KostiakovK.Name = "KT_KostiakovK"
        Me.KT_KostiakovK.Size = New System.Drawing.Size(192, 23)
        Me.KT_KostiakovK.TabIndex = 6
        Me.KT_KostiakovK.Text = "Kostiakov k = "
        Me.KT_KostiakovK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KT_InfiltrationTimeControl
        '
        Me.KT_InfiltrationTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KT_InfiltrationTimeControl.IsCalculated = False
        Me.KT_InfiltrationTimeControl.IsInteger = False
        Me.KT_InfiltrationTimeControl.Location = New System.Drawing.Point(250, 72)
        Me.KT_InfiltrationTimeControl.MaxErrMsg = ""
        Me.KT_InfiltrationTimeControl.MinErrMsg = ""
        Me.KT_InfiltrationTimeControl.Name = "KT_InfiltrationTimeControl"
        Me.KT_InfiltrationTimeControl.Size = New System.Drawing.Size(106, 24)
        Me.KT_InfiltrationTimeControl.TabIndex = 3
        Me.KT_InfiltrationTimeControl.ToBeCalculated = True
        Me.KT_InfiltrationTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KT_InfiltrationTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KT_InfiltrationTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KT_InfiltrationTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KT_InfiltrationTimeControl.ValueText = ""
        '
        'KT_KostiakovAControl
        '
        Me.KT_KostiakovAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KT_KostiakovAControl.IsCalculated = False
        Me.KT_KostiakovAControl.IsInteger = False
        Me.KT_KostiakovAControl.Location = New System.Drawing.Point(250, 96)
        Me.KT_KostiakovAControl.MaxErrMsg = ""
        Me.KT_KostiakovAControl.MinErrMsg = ""
        Me.KT_KostiakovAControl.Name = "KT_KostiakovAControl"
        Me.KT_KostiakovAControl.Size = New System.Drawing.Size(106, 24)
        Me.KT_KostiakovAControl.TabIndex = 5
        Me.KT_KostiakovAControl.ToBeCalculated = True
        Me.KT_KostiakovAControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KT_KostiakovAControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KT_KostiakovAControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KT_KostiakovAControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KT_KostiakovAControl.ValueText = ""
        '
        'KT_InfiltrationDepthControl
        '
        Me.KT_InfiltrationDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KT_InfiltrationDepthControl.IsCalculated = False
        Me.KT_InfiltrationDepthControl.IsInteger = False
        Me.KT_InfiltrationDepthControl.Location = New System.Drawing.Point(250, 48)
        Me.KT_InfiltrationDepthControl.MaxErrMsg = ""
        Me.KT_InfiltrationDepthControl.MinErrMsg = ""
        Me.KT_InfiltrationDepthControl.Name = "KT_InfiltrationDepthControl"
        Me.KT_InfiltrationDepthControl.Size = New System.Drawing.Size(106, 24)
        Me.KT_InfiltrationDepthControl.TabIndex = 1
        Me.KT_InfiltrationDepthControl.ToBeCalculated = True
        Me.KT_InfiltrationDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KT_InfiltrationDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KT_InfiltrationDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KT_InfiltrationDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KT_InfiltrationDepthControl.ValueText = ""
        '
        'KT_InfiltrationTimeLabel
        '
        Me.KT_InfiltrationTimeLabel.Location = New System.Drawing.Point(3, 72)
        Me.KT_InfiltrationTimeLabel.Name = "KT_InfiltrationTimeLabel"
        Me.KT_InfiltrationTimeLabel.Size = New System.Drawing.Size(245, 23)
        Me.KT_InfiltrationTimeLabel.TabIndex = 2
        Me.KT_InfiltrationTimeLabel.Text = "Characteristic Infiltration Time"
        Me.KT_InfiltrationTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KT_KostiakovALabel
        '
        Me.KT_KostiakovALabel.Location = New System.Drawing.Point(13, 96)
        Me.KT_KostiakovALabel.Name = "KT_KostiakovALabel"
        Me.KT_KostiakovALabel.Size = New System.Drawing.Size(235, 23)
        Me.KT_KostiakovALabel.TabIndex = 4
        Me.KT_KostiakovALabel.Text = "Kostiakov a"
        Me.KT_KostiakovALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KT_InfiltrationDepthLabel
        '
        Me.KT_InfiltrationDepthLabel.Location = New System.Drawing.Point(5, 48)
        Me.KT_InfiltrationDepthLabel.Name = "KT_InfiltrationDepthLabel"
        Me.KT_InfiltrationDepthLabel.Size = New System.Drawing.Size(243, 23)
        Me.KT_InfiltrationDepthLabel.TabIndex = 0
        Me.KT_InfiltrationDepthLabel.Text = "C&haracteristic Infiltration Depth"
        Me.KT_InfiltrationDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabulatedInfiltrationPanel
        '
        Me.TabulatedInfiltrationPanel.Controls.Add(Me.TabulatedInfiltrationLabel)
        Me.TabulatedInfiltrationPanel.Location = New System.Drawing.Point(8, 48)
        Me.TabulatedInfiltrationPanel.Name = "TabulatedInfiltrationPanel"
        Me.TabulatedInfiltrationPanel.Size = New System.Drawing.Size(360, 128)
        Me.TabulatedInfiltrationPanel.TabIndex = 2
        '
        'TabulatedInfiltrationLabel
        '
        Me.TabulatedInfiltrationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedInfiltrationLabel.Location = New System.Drawing.Point(56, 24)
        Me.TabulatedInfiltrationLabel.Name = "TabulatedInfiltrationLabel"
        Me.TabulatedInfiltrationLabel.Size = New System.Drawing.Size(192, 23)
        Me.TabulatedInfiltrationLabel.TabIndex = 0
        Me.TabulatedInfiltrationLabel.Text = "Tabulated Infiltration"
        Me.TabulatedInfiltrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BranchFunctionPanel
        '
        Me.BranchFunctionPanel.AccessibleDescription = "Set of parameters that defines the infiltration rate using the Branch Function."
        Me.BranchFunctionPanel.AccessibleName = "Branch Function Parameters"
        Me.BranchFunctionPanel.Controls.Add(Me.BF_BranchTime)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovKControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovKLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_BranchBControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovCControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovAControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_BranchTimeLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovBLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovCLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovALabel)
        Me.BranchFunctionPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchFunctionPanel.Location = New System.Drawing.Point(8, 48)
        Me.BranchFunctionPanel.Name = "BranchFunctionPanel"
        Me.BranchFunctionPanel.Size = New System.Drawing.Size(360, 128)
        Me.BranchFunctionPanel.TabIndex = 1
        '
        'BF_BranchTime
        '
        Me.BF_BranchTime.Location = New System.Drawing.Point(183, 104)
        Me.BF_BranchTime.Name = "BF_BranchTime"
        Me.BF_BranchTime.Size = New System.Drawing.Size(128, 23)
        Me.BF_BranchTime.TabIndex = 9
        Me.BF_BranchTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BF_KostiakovKControl
        '
        Me.BF_KostiakovKControl.Location = New System.Drawing.Point(183, 8)
        Me.BF_KostiakovKControl.Name = "BF_KostiakovKControl"
        Me.BF_KostiakovKControl.Size = New System.Drawing.Size(128, 24)
        Me.BF_KostiakovKControl.TabIndex = 1
        Me.BF_KostiakovKControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_KostiakovKControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_KostiakovKControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_KostiakovKControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_KostiakovKControl.ValueText = ""
        '
        'BF_KostiakovKLabel
        '
        Me.BF_KostiakovKLabel.Location = New System.Drawing.Point(6, 8)
        Me.BF_KostiakovKLabel.Name = "BF_KostiakovKLabel"
        Me.BF_KostiakovKLabel.Size = New System.Drawing.Size(171, 23)
        Me.BF_KostiakovKLabel.TabIndex = 0
        Me.BF_KostiakovKLabel.Text = "Kostiakov &k"
        Me.BF_KostiakovKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_BranchBControl
        '
        Me.BF_BranchBControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_BranchBControl.IsCalculated = False
        Me.BF_BranchBControl.IsInteger = False
        Me.BF_BranchBControl.Location = New System.Drawing.Point(183, 56)
        Me.BF_BranchBControl.MaxErrMsg = ""
        Me.BF_BranchBControl.MinErrMsg = ""
        Me.BF_BranchBControl.Name = "BF_BranchBControl"
        Me.BF_BranchBControl.Size = New System.Drawing.Size(128, 24)
        Me.BF_BranchBControl.TabIndex = 5
        Me.BF_BranchBControl.ToBeCalculated = True
        Me.BF_BranchBControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_BranchBControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_BranchBControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_BranchBControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_BranchBControl.ValueText = ""
        '
        'BF_KostiakovCControl
        '
        Me.BF_KostiakovCControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_KostiakovCControl.IsCalculated = False
        Me.BF_KostiakovCControl.IsInteger = False
        Me.BF_KostiakovCControl.Location = New System.Drawing.Point(183, 80)
        Me.BF_KostiakovCControl.MaxErrMsg = ""
        Me.BF_KostiakovCControl.MinErrMsg = ""
        Me.BF_KostiakovCControl.Name = "BF_KostiakovCControl"
        Me.BF_KostiakovCControl.Size = New System.Drawing.Size(128, 24)
        Me.BF_KostiakovCControl.TabIndex = 7
        Me.BF_KostiakovCControl.ToBeCalculated = True
        Me.BF_KostiakovCControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_KostiakovCControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_KostiakovCControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_KostiakovCControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_KostiakovCControl.ValueText = ""
        '
        'BF_KostiakovAControl
        '
        Me.BF_KostiakovAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_KostiakovAControl.IsCalculated = False
        Me.BF_KostiakovAControl.IsInteger = False
        Me.BF_KostiakovAControl.Location = New System.Drawing.Point(183, 32)
        Me.BF_KostiakovAControl.MaxErrMsg = ""
        Me.BF_KostiakovAControl.MinErrMsg = ""
        Me.BF_KostiakovAControl.Name = "BF_KostiakovAControl"
        Me.BF_KostiakovAControl.Size = New System.Drawing.Size(128, 24)
        Me.BF_KostiakovAControl.TabIndex = 3
        Me.BF_KostiakovAControl.ToBeCalculated = True
        Me.BF_KostiakovAControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_KostiakovAControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_KostiakovAControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_KostiakovAControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_KostiakovAControl.ValueText = ""
        '
        'BF_BranchTimeLabel
        '
        Me.BF_BranchTimeLabel.Location = New System.Drawing.Point(6, 104)
        Me.BF_BranchTimeLabel.Name = "BF_BranchTimeLabel"
        Me.BF_BranchTimeLabel.Size = New System.Drawing.Size(171, 23)
        Me.BF_BranchTimeLabel.TabIndex = 8
        Me.BF_BranchTimeLabel.Text = "Branch Time"
        Me.BF_BranchTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_KostiakovBLabel
        '
        Me.BF_KostiakovBLabel.Location = New System.Drawing.Point(6, 56)
        Me.BF_KostiakovBLabel.Name = "BF_KostiakovBLabel"
        Me.BF_KostiakovBLabel.Size = New System.Drawing.Size(171, 23)
        Me.BF_KostiakovBLabel.TabIndex = 4
        Me.BF_KostiakovBLabel.Text = "Branch b"
        Me.BF_KostiakovBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_KostiakovCLabel
        '
        Me.BF_KostiakovCLabel.Location = New System.Drawing.Point(8, 80)
        Me.BF_KostiakovCLabel.Name = "BF_KostiakovCLabel"
        Me.BF_KostiakovCLabel.Size = New System.Drawing.Size(169, 23)
        Me.BF_KostiakovCLabel.TabIndex = 6
        Me.BF_KostiakovCLabel.Text = "Kostiakov c"
        Me.BF_KostiakovCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_KostiakovALabel
        '
        Me.BF_KostiakovALabel.Location = New System.Drawing.Point(3, 32)
        Me.BF_KostiakovALabel.Name = "BF_KostiakovALabel"
        Me.BF_KostiakovALabel.Size = New System.Drawing.Size(174, 23)
        Me.BF_KostiakovALabel.TabIndex = 2
        Me.BF_KostiakovALabel.Text = "Kostiakov a"
        Me.BF_KostiakovALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ModifiedKostiakovPanel
        '
        Me.ModifiedKostiakovPanel.AccessibleDescription = "Set of parameters that defines the infiltration rate using the Modified Kostiakov" & _
            " method."
        Me.ModifiedKostiakovPanel.AccessibleName = "Modified Kostiakov Parameters"
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovAControl)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovKControl)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovCControl)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovBControl)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovALabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovKLabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovCLabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovBLabel)
        Me.ModifiedKostiakovPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModifiedKostiakovPanel.Location = New System.Drawing.Point(8, 48)
        Me.ModifiedKostiakovPanel.Name = "ModifiedKostiakovPanel"
        Me.ModifiedKostiakovPanel.Size = New System.Drawing.Size(360, 128)
        Me.ModifiedKostiakovPanel.TabIndex = 1
        '
        'MK_KostiakovAControl
        '
        Me.MK_KostiakovAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_KostiakovAControl.IsCalculated = False
        Me.MK_KostiakovAControl.IsInteger = False
        Me.MK_KostiakovAControl.Location = New System.Drawing.Point(183, 40)
        Me.MK_KostiakovAControl.MaxErrMsg = ""
        Me.MK_KostiakovAControl.MinErrMsg = ""
        Me.MK_KostiakovAControl.Name = "MK_KostiakovAControl"
        Me.MK_KostiakovAControl.Size = New System.Drawing.Size(128, 24)
        Me.MK_KostiakovAControl.TabIndex = 3
        Me.MK_KostiakovAControl.ToBeCalculated = True
        Me.MK_KostiakovAControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_KostiakovAControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_KostiakovAControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_KostiakovAControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_KostiakovAControl.ValueText = ""
        '
        'MK_KostiakovKControl
        '
        Me.MK_KostiakovKControl.Location = New System.Drawing.Point(183, 16)
        Me.MK_KostiakovKControl.Name = "MK_KostiakovKControl"
        Me.MK_KostiakovKControl.Size = New System.Drawing.Size(128, 24)
        Me.MK_KostiakovKControl.TabIndex = 1
        Me.MK_KostiakovKControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_KostiakovKControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_KostiakovKControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_KostiakovKControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_KostiakovKControl.ValueText = ""
        '
        'MK_KostiakovCControl
        '
        Me.MK_KostiakovCControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_KostiakovCControl.IsCalculated = False
        Me.MK_KostiakovCControl.IsInteger = False
        Me.MK_KostiakovCControl.Location = New System.Drawing.Point(183, 88)
        Me.MK_KostiakovCControl.MaxErrMsg = ""
        Me.MK_KostiakovCControl.MinErrMsg = ""
        Me.MK_KostiakovCControl.Name = "MK_KostiakovCControl"
        Me.MK_KostiakovCControl.Size = New System.Drawing.Size(128, 24)
        Me.MK_KostiakovCControl.TabIndex = 7
        Me.MK_KostiakovCControl.ToBeCalculated = True
        Me.MK_KostiakovCControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_KostiakovCControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_KostiakovCControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_KostiakovCControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_KostiakovCControl.ValueText = ""
        '
        'MK_KostiakovBControl
        '
        Me.MK_KostiakovBControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_KostiakovBControl.IsCalculated = False
        Me.MK_KostiakovBControl.IsInteger = False
        Me.MK_KostiakovBControl.Location = New System.Drawing.Point(183, 64)
        Me.MK_KostiakovBControl.MaxErrMsg = ""
        Me.MK_KostiakovBControl.MinErrMsg = ""
        Me.MK_KostiakovBControl.Name = "MK_KostiakovBControl"
        Me.MK_KostiakovBControl.Size = New System.Drawing.Size(128, 24)
        Me.MK_KostiakovBControl.TabIndex = 5
        Me.MK_KostiakovBControl.ToBeCalculated = True
        Me.MK_KostiakovBControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_KostiakovBControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_KostiakovBControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_KostiakovBControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_KostiakovBControl.ValueText = ""
        '
        'MK_KostiakovALabel
        '
        Me.MK_KostiakovALabel.Location = New System.Drawing.Point(9, 40)
        Me.MK_KostiakovALabel.Name = "MK_KostiakovALabel"
        Me.MK_KostiakovALabel.Size = New System.Drawing.Size(168, 23)
        Me.MK_KostiakovALabel.TabIndex = 2
        Me.MK_KostiakovALabel.Text = "Kostiakov a"
        Me.MK_KostiakovALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_KostiakovKLabel
        '
        Me.MK_KostiakovKLabel.Location = New System.Drawing.Point(9, 16)
        Me.MK_KostiakovKLabel.Name = "MK_KostiakovKLabel"
        Me.MK_KostiakovKLabel.Size = New System.Drawing.Size(168, 23)
        Me.MK_KostiakovKLabel.TabIndex = 0
        Me.MK_KostiakovKLabel.Text = "Kostiakov &k"
        Me.MK_KostiakovKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_KostiakovCLabel
        '
        Me.MK_KostiakovCLabel.Location = New System.Drawing.Point(8, 88)
        Me.MK_KostiakovCLabel.Name = "MK_KostiakovCLabel"
        Me.MK_KostiakovCLabel.Size = New System.Drawing.Size(169, 23)
        Me.MK_KostiakovCLabel.TabIndex = 6
        Me.MK_KostiakovCLabel.Text = "Kostiakov c"
        Me.MK_KostiakovCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_KostiakovBLabel
        '
        Me.MK_KostiakovBLabel.Location = New System.Drawing.Point(8, 64)
        Me.MK_KostiakovBLabel.Name = "MK_KostiakovBLabel"
        Me.MK_KostiakovBLabel.Size = New System.Drawing.Size(169, 23)
        Me.MK_KostiakovBLabel.TabIndex = 4
        Me.MK_KostiakovBLabel.Text = "Kostiakov b"
        Me.MK_KostiakovBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KostiakovPanel
        '
        Me.KostiakovPanel.AccessibleDescription = "This set of parameters defines the infiltration rate using the Modified Kostiakov" & _
            " method."
        Me.KostiakovPanel.AccessibleName = "Modified Kostiakov Parameters"
        Me.KostiakovPanel.Controls.Add(Me.KF_KostiakovAControl)
        Me.KostiakovPanel.Controls.Add(Me.KF_KostiakovKControl)
        Me.KostiakovPanel.Controls.Add(Me.KF_KostiakovALabel)
        Me.KostiakovPanel.Controls.Add(Me.KF_KostiakovKLabel)
        Me.KostiakovPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostiakovPanel.Location = New System.Drawing.Point(8, 48)
        Me.KostiakovPanel.Name = "KostiakovPanel"
        Me.KostiakovPanel.Size = New System.Drawing.Size(360, 128)
        Me.KostiakovPanel.TabIndex = 1
        '
        'KF_KostiakovAControl
        '
        Me.KF_KostiakovAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KF_KostiakovAControl.IsCalculated = False
        Me.KF_KostiakovAControl.IsInteger = False
        Me.KF_KostiakovAControl.Location = New System.Drawing.Point(183, 64)
        Me.KF_KostiakovAControl.MaxErrMsg = ""
        Me.KF_KostiakovAControl.MinErrMsg = ""
        Me.KF_KostiakovAControl.Name = "KF_KostiakovAControl"
        Me.KF_KostiakovAControl.Size = New System.Drawing.Size(128, 24)
        Me.KF_KostiakovAControl.TabIndex = 3
        Me.KF_KostiakovAControl.ToBeCalculated = True
        Me.KF_KostiakovAControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KF_KostiakovAControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KF_KostiakovAControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KF_KostiakovAControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KF_KostiakovAControl.ValueText = ""
        '
        'KF_KostiakovKControl
        '
        Me.KF_KostiakovKControl.Location = New System.Drawing.Point(183, 40)
        Me.KF_KostiakovKControl.Name = "KF_KostiakovKControl"
        Me.KF_KostiakovKControl.Size = New System.Drawing.Size(128, 24)
        Me.KF_KostiakovKControl.TabIndex = 1
        Me.KF_KostiakovKControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KF_KostiakovKControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KF_KostiakovKControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KF_KostiakovKControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KF_KostiakovKControl.ValueText = ""
        '
        'KF_KostiakovALabel
        '
        Me.KF_KostiakovALabel.Location = New System.Drawing.Point(8, 64)
        Me.KF_KostiakovALabel.Name = "KF_KostiakovALabel"
        Me.KF_KostiakovALabel.Size = New System.Drawing.Size(169, 23)
        Me.KF_KostiakovALabel.TabIndex = 2
        Me.KF_KostiakovALabel.Text = "Kostiakov a"
        Me.KF_KostiakovALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KF_KostiakovKLabel
        '
        Me.KF_KostiakovKLabel.Location = New System.Drawing.Point(8, 40)
        Me.KF_KostiakovKLabel.Name = "KF_KostiakovKLabel"
        Me.KF_KostiakovKLabel.Size = New System.Drawing.Size(169, 23)
        Me.KF_KostiakovKLabel.TabIndex = 0
        Me.KF_KostiakovKLabel.Text = "Kostiakov &k"
        Me.KF_KostiakovKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NrcsIntakePanel
        '
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsCalculatedA)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsCalculatedK)
        Me.NrcsIntakePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsIntakePanel.Location = New System.Drawing.Point(8, 48)
        Me.NrcsIntakePanel.Name = "NrcsIntakePanel"
        Me.NrcsIntakePanel.Size = New System.Drawing.Size(360, 128)
        Me.NrcsIntakePanel.TabIndex = 1
        '
        'NrcsCalculatedA
        '
        Me.NrcsCalculatedA.Location = New System.Drawing.Point(208, 16)
        Me.NrcsCalculatedA.Name = "NrcsCalculatedA"
        Me.NrcsCalculatedA.Size = New System.Drawing.Size(144, 23)
        Me.NrcsCalculatedA.TabIndex = 1
        Me.NrcsCalculatedA.Text = "Kostiakov a = "
        Me.NrcsCalculatedA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsCalculatedK
        '
        Me.NrcsCalculatedK.Location = New System.Drawing.Point(16, 16)
        Me.NrcsCalculatedK.Name = "NrcsCalculatedK"
        Me.NrcsCalculatedK.Size = New System.Drawing.Size(192, 23)
        Me.NrcsCalculatedK.TabIndex = 0
        Me.NrcsCalculatedK.Text = "Kostiakov k = "
        Me.NrcsCalculatedK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RoughnessSummary
        '
        Me.RoughnessSummary.AccessibleDescription = "Summary of the Roughness data"
        Me.RoughnessSummary.AccessibleName = "Roughness"
        Me.RoughnessSummary.Controls.Add(Me.RoughnessLabel)
        Me.RoughnessSummary.Controls.Add(Me.NrcsSuggestedManningNPanel)
        Me.RoughnessSummary.Controls.Add(Me.ManningCnAnPanel)
        Me.RoughnessSummary.Controls.Add(Me.SayreChiPanel)
        Me.RoughnessSummary.Controls.Add(Me.TabulatedRoughnessPanel)
        Me.RoughnessSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessSummary.Location = New System.Drawing.Point(392, 304)
        Me.RoughnessSummary.Name = "RoughnessSummary"
        Me.RoughnessSummary.Size = New System.Drawing.Size(376, 112)
        Me.RoughnessSummary.TabIndex = 3
        Me.RoughnessSummary.TabStop = False
        Me.RoughnessSummary.Text = "Roughness"
        '
        'RoughnessLabel
        '
        Me.RoughnessLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessLabel.Location = New System.Drawing.Point(8, 24)
        Me.RoughnessLabel.Name = "RoughnessLabel"
        Me.RoughnessLabel.Size = New System.Drawing.Size(360, 23)
        Me.RoughnessLabel.TabIndex = 0
        Me.RoughnessLabel.Text = "NRCS Suggested &Manning n"
        Me.RoughnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsSuggestedManningNPanel
        '
        Me.NrcsSuggestedManningNPanel.Controls.Add(Me.UsersManningNControl)
        Me.NrcsSuggestedManningNPanel.Controls.Add(Me.Sel_UserEntered)
        Me.NrcsSuggestedManningNPanel.Controls.Add(Me.Sel_025)
        Me.NrcsSuggestedManningNPanel.Controls.Add(Me.Sel_020)
        Me.NrcsSuggestedManningNPanel.Controls.Add(Me.Sel_015)
        Me.NrcsSuggestedManningNPanel.Controls.Add(Me.Sel_010)
        Me.NrcsSuggestedManningNPanel.Controls.Add(Me.Sel_004)
        Me.NrcsSuggestedManningNPanel.Location = New System.Drawing.Point(8, 48)
        Me.NrcsSuggestedManningNPanel.Name = "NrcsSuggestedManningNPanel"
        Me.NrcsSuggestedManningNPanel.Size = New System.Drawing.Size(360, 56)
        Me.NrcsSuggestedManningNPanel.TabIndex = 1
        '
        'UsersManningNControl
        '
        Me.UsersManningNControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.UsersManningNControl.IsCalculated = False
        Me.UsersManningNControl.IsInteger = False
        Me.UsersManningNControl.Location = New System.Drawing.Point(152, 31)
        Me.UsersManningNControl.MaxErrMsg = ""
        Me.UsersManningNControl.MinErrMsg = ""
        Me.UsersManningNControl.Name = "UsersManningNControl"
        Me.UsersManningNControl.Size = New System.Drawing.Size(144, 24)
        Me.UsersManningNControl.TabIndex = 6
        Me.UsersManningNControl.ToBeCalculated = True
        Me.UsersManningNControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.UsersManningNControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.UsersManningNControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.UsersManningNControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.UsersManningNControl.ValueText = ""
        '
        'Sel_UserEntered
        '
        Me.Sel_UserEntered.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_UserEntered.Location = New System.Drawing.Point(24, 30)
        Me.Sel_UserEntered.Name = "Sel_UserEntered"
        Me.Sel_UserEntered.Size = New System.Drawing.Size(134, 23)
        Me.Sel_UserEntered.TabIndex = 5
        Me.Sel_UserEntered.TabStop = True
        Me.Sel_UserEntered.Text = "User Entered"
        Me.Sel_UserEntered.UseVisualStyleBackColor = True
        '
        'Sel_025
        '
        Me.Sel_025.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_025.Location = New System.Drawing.Point(280, 4)
        Me.Sel_025.Name = "Sel_025"
        Me.Sel_025.Size = New System.Drawing.Size(56, 24)
        Me.Sel_025.TabIndex = 4
        Me.Sel_025.Text = "0.25"
        '
        'Sel_020
        '
        Me.Sel_020.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_020.Location = New System.Drawing.Point(216, 4)
        Me.Sel_020.Name = "Sel_020"
        Me.Sel_020.Size = New System.Drawing.Size(56, 24)
        Me.Sel_020.TabIndex = 3
        Me.Sel_020.Text = "0.20"
        '
        'Sel_015
        '
        Me.Sel_015.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_015.Location = New System.Drawing.Point(152, 4)
        Me.Sel_015.Name = "Sel_015"
        Me.Sel_015.Size = New System.Drawing.Size(56, 24)
        Me.Sel_015.TabIndex = 2
        Me.Sel_015.Text = "0.15"
        '
        'Sel_010
        '
        Me.Sel_010.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_010.Location = New System.Drawing.Point(88, 4)
        Me.Sel_010.Name = "Sel_010"
        Me.Sel_010.Size = New System.Drawing.Size(56, 24)
        Me.Sel_010.TabIndex = 1
        Me.Sel_010.Text = "0.10"
        '
        'Sel_004
        '
        Me.Sel_004.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_004.Location = New System.Drawing.Point(24, 4)
        Me.Sel_004.Name = "Sel_004"
        Me.Sel_004.Size = New System.Drawing.Size(56, 24)
        Me.Sel_004.TabIndex = 0
        Me.Sel_004.Text = "0.04"
        '
        'ManningCnAnPanel
        '
        Me.ManningCnAnPanel.AccessibleDescription = "Specifies surface roughness using Manning Cn & An values."
        Me.ManningCnAnPanel.AccessibleName = "Manning Cn & An"
        Me.ManningCnAnPanel.Controls.Add(Me.ManningAnControl)
        Me.ManningCnAnPanel.Controls.Add(Me.ManningAnLabel)
        Me.ManningCnAnPanel.Controls.Add(Me.ManningCnControl)
        Me.ManningCnAnPanel.Controls.Add(Me.ManningCnLabel)
        Me.ManningCnAnPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManningCnAnPanel.Location = New System.Drawing.Point(8, 48)
        Me.ManningCnAnPanel.Name = "ManningCnAnPanel"
        Me.ManningCnAnPanel.Size = New System.Drawing.Size(360, 56)
        Me.ManningCnAnPanel.TabIndex = 1
        '
        'ManningAnControl
        '
        Me.ManningAnControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ManningAnControl.IsCalculated = False
        Me.ManningAnControl.IsInteger = False
        Me.ManningAnControl.Location = New System.Drawing.Point(206, 32)
        Me.ManningAnControl.MaxErrMsg = ""
        Me.ManningAnControl.MinErrMsg = ""
        Me.ManningAnControl.Name = "ManningAnControl"
        Me.ManningAnControl.Size = New System.Drawing.Size(144, 24)
        Me.ManningAnControl.TabIndex = 3
        Me.ManningAnControl.ToBeCalculated = True
        Me.ManningAnControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ManningAnControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ManningAnControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ManningAnControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ManningAnControl.ValueText = ""
        '
        'ManningAnLabel
        '
        Me.ManningAnLabel.Location = New System.Drawing.Point(1, 32)
        Me.ManningAnLabel.Name = "ManningAnLabel"
        Me.ManningAnLabel.Size = New System.Drawing.Size(199, 23)
        Me.ManningAnLabel.TabIndex = 2
        Me.ManningAnLabel.Text = "Manning An"
        Me.ManningAnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ManningCnControl
        '
        Me.ManningCnControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ManningCnControl.IsCalculated = False
        Me.ManningCnControl.IsInteger = False
        Me.ManningCnControl.Location = New System.Drawing.Point(206, 8)
        Me.ManningCnControl.MaxErrMsg = ""
        Me.ManningCnControl.MinErrMsg = ""
        Me.ManningCnControl.Name = "ManningCnControl"
        Me.ManningCnControl.Size = New System.Drawing.Size(144, 24)
        Me.ManningCnControl.TabIndex = 1
        Me.ManningCnControl.ToBeCalculated = True
        Me.ManningCnControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ManningCnControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ManningCnControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ManningCnControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ManningCnControl.ValueText = ""
        '
        'ManningCnLabel
        '
        Me.ManningCnLabel.Location = New System.Drawing.Point(3, 8)
        Me.ManningCnLabel.Name = "ManningCnLabel"
        Me.ManningCnLabel.Size = New System.Drawing.Size(196, 23)
        Me.ManningCnLabel.TabIndex = 0
        Me.ManningCnLabel.Text = "Manning Cn"
        Me.ManningCnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SayreChiPanel
        '
        Me.SayreChiPanel.AccessibleDescription = "Specifies surface roughness using a Sayre-Albertson Chi value."
        Me.SayreChiPanel.AccessibleName = "Sayre-Albertson Chi"
        Me.SayreChiPanel.Controls.Add(Me.SayreChiControl)
        Me.SayreChiPanel.Controls.Add(Me.SayreChiLabel)
        Me.SayreChiPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SayreChiPanel.Location = New System.Drawing.Point(8, 48)
        Me.SayreChiPanel.Name = "SayreChiPanel"
        Me.SayreChiPanel.Size = New System.Drawing.Size(360, 56)
        Me.SayreChiPanel.TabIndex = 1
        '
        'SayreChiControl
        '
        Me.SayreChiControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SayreChiControl.IsCalculated = False
        Me.SayreChiControl.IsInteger = False
        Me.SayreChiControl.Location = New System.Drawing.Point(206, 16)
        Me.SayreChiControl.MaxErrMsg = ""
        Me.SayreChiControl.MinErrMsg = ""
        Me.SayreChiControl.Name = "SayreChiControl"
        Me.SayreChiControl.Size = New System.Drawing.Size(144, 24)
        Me.SayreChiControl.TabIndex = 1
        Me.SayreChiControl.ToBeCalculated = True
        Me.SayreChiControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SayreChiControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SayreChiControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SayreChiControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SayreChiControl.ValueText = ""
        '
        'SayreChiLabel
        '
        Me.SayreChiLabel.Location = New System.Drawing.Point(3, 16)
        Me.SayreChiLabel.Name = "SayreChiLabel"
        Me.SayreChiLabel.Size = New System.Drawing.Size(196, 23)
        Me.SayreChiLabel.TabIndex = 0
        Me.SayreChiLabel.Text = "Sayre-Albertson Chi"
        Me.SayreChiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabulatedRoughnessPanel
        '
        Me.TabulatedRoughnessPanel.Controls.Add(Me.TabulatedRoughnessLabel)
        Me.TabulatedRoughnessPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedRoughnessPanel.Location = New System.Drawing.Point(8, 48)
        Me.TabulatedRoughnessPanel.Name = "TabulatedRoughnessPanel"
        Me.TabulatedRoughnessPanel.Size = New System.Drawing.Size(360, 56)
        Me.TabulatedRoughnessPanel.TabIndex = 2
        '
        'TabulatedRoughnessLabel
        '
        Me.TabulatedRoughnessLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedRoughnessLabel.Location = New System.Drawing.Point(56, 17)
        Me.TabulatedRoughnessLabel.Name = "TabulatedRoughnessLabel"
        Me.TabulatedRoughnessLabel.Size = New System.Drawing.Size(192, 23)
        Me.TabulatedRoughnessLabel.TabIndex = 1
        Me.TabulatedRoughnessLabel.Text = "Tabulated Roughness"
        Me.TabulatedRoughnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InflowManagementSummary
        '
        Me.InflowManagementSummary.AccessibleDescription = "Summary of the Inflow and Runoff data"
        Me.InflowManagementSummary.AccessibleName = "Inflow / Runoff"
        Me.InflowManagementSummary.Controls.Add(Me.SurgePanel)
        Me.InflowManagementSummary.Controls.Add(Me.InflowManagementLabel)
        Me.InflowManagementSummary.Controls.Add(Me.RequiredDepthControl)
        Me.InflowManagementSummary.Controls.Add(Me.UnitWaterCostControl)
        Me.InflowManagementSummary.Controls.Add(Me.RequiredDepthLabel)
        Me.InflowManagementSummary.Controls.Add(Me.UnitWaterCostLabel)
        Me.InflowManagementSummary.Controls.Add(Me.StandardHydrographPanel)
        Me.InflowManagementSummary.Controls.Add(Me.TabulatedPanel)
        Me.InflowManagementSummary.Controls.Add(Me.CablegationPanel)
        Me.InflowManagementSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowManagementSummary.Location = New System.Drawing.Point(392, 8)
        Me.InflowManagementSummary.Name = "InflowManagementSummary"
        Me.InflowManagementSummary.Size = New System.Drawing.Size(376, 288)
        Me.InflowManagementSummary.TabIndex = 2
        Me.InflowManagementSummary.TabStop = False
        Me.InflowManagementSummary.Text = "Inflow / Runoff"
        '
        'SurgePanel
        '
        Me.SurgePanel.Controls.Add(Me.SurgeStrategyLabel)
        Me.SurgePanel.Location = New System.Drawing.Point(8, 104)
        Me.SurgePanel.Name = "SurgePanel"
        Me.SurgePanel.Size = New System.Drawing.Size(360, 176)
        Me.SurgePanel.TabIndex = 5
        '
        'SurgeStrategyLabel
        '
        Me.SurgeStrategyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurgeStrategyLabel.Location = New System.Drawing.Point(11, 72)
        Me.SurgeStrategyLabel.Name = "SurgeStrategyLabel"
        Me.SurgeStrategyLabel.Size = New System.Drawing.Size(337, 23)
        Me.SurgeStrategyLabel.TabIndex = 0
        Me.SurgeStrategyLabel.Text = "Surge Strategy"
        Me.SurgeStrategyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InflowManagementLabel
        '
        Me.InflowManagementLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowManagementLabel.Location = New System.Drawing.Point(8, 24)
        Me.InflowManagementLabel.Name = "InflowManagementLabel"
        Me.InflowManagementLabel.Size = New System.Drawing.Size(360, 23)
        Me.InflowManagementLabel.TabIndex = 0
        Me.InflowManagementLabel.Text = "Standard Hydrograph"
        Me.InflowManagementLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RequiredDepthControl
        '
        Me.RequiredDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RequiredDepthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredDepthControl.IsCalculated = False
        Me.RequiredDepthControl.IsInteger = False
        Me.RequiredDepthControl.Location = New System.Drawing.Point(215, 80)
        Me.RequiredDepthControl.MaxErrMsg = ""
        Me.RequiredDepthControl.MinErrMsg = ""
        Me.RequiredDepthControl.Name = "RequiredDepthControl"
        Me.RequiredDepthControl.Size = New System.Drawing.Size(152, 24)
        Me.RequiredDepthControl.TabIndex = 4
        Me.RequiredDepthControl.ToBeCalculated = True
        Me.RequiredDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.RequiredDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.RequiredDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.RequiredDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.RequiredDepthControl.ValueText = ""
        '
        'UnitWaterCostControl
        '
        Me.UnitWaterCostControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.UnitWaterCostControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitWaterCostControl.IsCalculated = False
        Me.UnitWaterCostControl.IsInteger = False
        Me.UnitWaterCostControl.Location = New System.Drawing.Point(215, 56)
        Me.UnitWaterCostControl.MaxErrMsg = ""
        Me.UnitWaterCostControl.MinErrMsg = ""
        Me.UnitWaterCostControl.Name = "UnitWaterCostControl"
        Me.UnitWaterCostControl.Size = New System.Drawing.Size(152, 24)
        Me.UnitWaterCostControl.TabIndex = 2
        Me.UnitWaterCostControl.ToBeCalculated = True
        Me.UnitWaterCostControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.UnitWaterCostControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.UnitWaterCostControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.UnitWaterCostControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.UnitWaterCostControl.ValueText = ""
        '
        'RequiredDepthLabel
        '
        Me.RequiredDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredDepthLabel.Location = New System.Drawing.Point(6, 80)
        Me.RequiredDepthLabel.Name = "RequiredDepthLabel"
        Me.RequiredDepthLabel.Size = New System.Drawing.Size(203, 23)
        Me.RequiredDepthLabel.TabIndex = 3
        Me.RequiredDepthLabel.Text = "Required &Depth"
        Me.RequiredDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UnitWaterCostLabel
        '
        Me.UnitWaterCostLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitWaterCostLabel.Location = New System.Drawing.Point(8, 56)
        Me.UnitWaterCostLabel.Name = "UnitWaterCostLabel"
        Me.UnitWaterCostLabel.Size = New System.Drawing.Size(201, 23)
        Me.UnitWaterCostLabel.TabIndex = 1
        Me.UnitWaterCostLabel.Text = "Unit Water &Cost"
        Me.UnitWaterCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StandardHydrographPanel
        '
        Me.StandardHydrographPanel.AccessibleDescription = "Define inflow onto the field using the Standard Hydrograph method"
        Me.StandardHydrographPanel.AccessibleName = "Standard Hydrograph"
        Me.StandardHydrographPanel.Controls.Add(Me.InflowRateControl)
        Me.StandardHydrographPanel.Controls.Add(Me.InflowRateLabel)
        Me.StandardHydrographPanel.Controls.Add(Me.CutoffCutbackLabel)
        Me.StandardHydrographPanel.Controls.Add(Me.CutoffUpstreamDepthPanel)
        Me.StandardHydrographPanel.Controls.Add(Me.CutoffLocationPanel)
        Me.StandardHydrographPanel.Controls.Add(Me.CutoffTimePanel)
        Me.StandardHydrographPanel.Controls.Add(Me.CutbackPanel)
        Me.StandardHydrographPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StandardHydrographPanel.Location = New System.Drawing.Point(8, 104)
        Me.StandardHydrographPanel.Name = "StandardHydrographPanel"
        Me.StandardHydrographPanel.Size = New System.Drawing.Size(360, 176)
        Me.StandardHydrographPanel.TabIndex = 7
        '
        'InflowRateControl
        '
        Me.InflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.InflowRateControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRateControl.IsCalculated = False
        Me.InflowRateControl.IsInteger = False
        Me.InflowRateControl.Location = New System.Drawing.Point(205, 31)
        Me.InflowRateControl.MaxErrMsg = ""
        Me.InflowRateControl.MinErrMsg = ""
        Me.InflowRateControl.Name = "InflowRateControl"
        Me.InflowRateControl.Size = New System.Drawing.Size(147, 24)
        Me.InflowRateControl.TabIndex = 2
        Me.InflowRateControl.ToBeCalculated = True
        Me.InflowRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.InflowRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.InflowRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.InflowRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.InflowRateControl.ValueText = ""
        '
        'InflowRateLabel
        '
        Me.InflowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRateLabel.Location = New System.Drawing.Point(3, 32)
        Me.InflowRateLabel.Name = "InflowRateLabel"
        Me.InflowRateLabel.Size = New System.Drawing.Size(198, 23)
        Me.InflowRateLabel.TabIndex = 1
        Me.InflowRateLabel.Text = "Inflow &Rate"
        Me.InflowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutoffCutbackLabel
        '
        Me.CutoffCutbackLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffCutbackLabel.Location = New System.Drawing.Point(8, 8)
        Me.CutoffCutbackLabel.Name = "CutoffCutbackLabel"
        Me.CutoffCutbackLabel.Size = New System.Drawing.Size(352, 23)
        Me.CutoffCutbackLabel.TabIndex = 0
        Me.CutoffCutbackLabel.Text = "Distance then Infiltration Depth, Distance-Based Cutback"
        '
        'CutoffUpstreamDepthPanel
        '
        Me.CutoffUpstreamDepthPanel.Controls.Add(Me.CutoffUpstreamDepthControl)
        Me.CutoffUpstreamDepthPanel.Controls.Add(Me.UpstreamDepthLabel)
        Me.CutoffUpstreamDepthPanel.Location = New System.Drawing.Point(3, 64)
        Me.CutoffUpstreamDepthPanel.Name = "CutoffUpstreamDepthPanel"
        Me.CutoffUpstreamDepthPanel.Size = New System.Drawing.Size(349, 56)
        Me.CutoffUpstreamDepthPanel.TabIndex = 3
        '
        'CutoffUpstreamDepthControl
        '
        Me.CutoffUpstreamDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutoffUpstreamDepthControl.IsCalculated = False
        Me.CutoffUpstreamDepthControl.IsInteger = False
        Me.CutoffUpstreamDepthControl.Location = New System.Drawing.Point(202, 15)
        Me.CutoffUpstreamDepthControl.MaxErrMsg = ""
        Me.CutoffUpstreamDepthControl.MinErrMsg = ""
        Me.CutoffUpstreamDepthControl.Name = "CutoffUpstreamDepthControl"
        Me.CutoffUpstreamDepthControl.Size = New System.Drawing.Size(144, 24)
        Me.CutoffUpstreamDepthControl.TabIndex = 1
        Me.CutoffUpstreamDepthControl.ToBeCalculated = True
        Me.CutoffUpstreamDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutoffUpstreamDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutoffUpstreamDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutoffUpstreamDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutoffUpstreamDepthControl.ValueText = ""
        '
        'UpstreamDepthLabel
        '
        Me.UpstreamDepthLabel.Location = New System.Drawing.Point(3, 16)
        Me.UpstreamDepthLabel.Name = "UpstreamDepthLabel"
        Me.UpstreamDepthLabel.Size = New System.Drawing.Size(195, 23)
        Me.UpstreamDepthLabel.TabIndex = 0
        Me.UpstreamDepthLabel.Text = "&Upstream Depth"
        Me.UpstreamDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutoffLocationPanel
        '
        Me.CutoffLocationPanel.Controls.Add(Me.CutoffInfiltrationDepthControl)
        Me.CutoffLocationPanel.Controls.Add(Me.CutoffOpportunityTimeControl)
        Me.CutoffLocationPanel.Controls.Add(Me.OpportunityTimeLabel)
        Me.CutoffLocationPanel.Controls.Add(Me.CutoffLocationLabel)
        Me.CutoffLocationPanel.Controls.Add(Me.InfiltrationDepthLabel)
        Me.CutoffLocationPanel.Controls.Add(Me.CutoffLocationControl)
        Me.CutoffLocationPanel.Location = New System.Drawing.Point(-2, 64)
        Me.CutoffLocationPanel.Name = "CutoffLocationPanel"
        Me.CutoffLocationPanel.Size = New System.Drawing.Size(354, 56)
        Me.CutoffLocationPanel.TabIndex = 3
        '
        'CutoffInfiltrationDepthControl
        '
        Me.CutoffInfiltrationDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutoffInfiltrationDepthControl.IsCalculated = False
        Me.CutoffInfiltrationDepthControl.IsInteger = False
        Me.CutoffInfiltrationDepthControl.Location = New System.Drawing.Point(207, 29)
        Me.CutoffInfiltrationDepthControl.MaxErrMsg = ""
        Me.CutoffInfiltrationDepthControl.MinErrMsg = ""
        Me.CutoffInfiltrationDepthControl.Name = "CutoffInfiltrationDepthControl"
        Me.CutoffInfiltrationDepthControl.Size = New System.Drawing.Size(144, 24)
        Me.CutoffInfiltrationDepthControl.TabIndex = 3
        Me.CutoffInfiltrationDepthControl.ToBeCalculated = True
        Me.CutoffInfiltrationDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutoffInfiltrationDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutoffInfiltrationDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutoffInfiltrationDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutoffInfiltrationDepthControl.ValueText = ""
        '
        'CutoffOpportunityTimeControl
        '
        Me.CutoffOpportunityTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutoffOpportunityTimeControl.IsCalculated = False
        Me.CutoffOpportunityTimeControl.IsInteger = False
        Me.CutoffOpportunityTimeControl.Location = New System.Drawing.Point(207, 31)
        Me.CutoffOpportunityTimeControl.MaxErrMsg = ""
        Me.CutoffOpportunityTimeControl.MinErrMsg = ""
        Me.CutoffOpportunityTimeControl.Name = "CutoffOpportunityTimeControl"
        Me.CutoffOpportunityTimeControl.Size = New System.Drawing.Size(144, 24)
        Me.CutoffOpportunityTimeControl.TabIndex = 3
        Me.CutoffOpportunityTimeControl.ToBeCalculated = True
        Me.CutoffOpportunityTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutoffOpportunityTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutoffOpportunityTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutoffOpportunityTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutoffOpportunityTimeControl.ValueText = ""
        '
        'OpportunityTimeLabel
        '
        Me.OpportunityTimeLabel.Location = New System.Drawing.Point(2, 32)
        Me.OpportunityTimeLabel.Name = "OpportunityTimeLabel"
        Me.OpportunityTimeLabel.Size = New System.Drawing.Size(199, 23)
        Me.OpportunityTimeLabel.TabIndex = 2
        Me.OpportunityTimeLabel.Text = "&& O&pportunity Time"
        Me.OpportunityTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutoffLocationLabel
        '
        Me.CutoffLocationLabel.Location = New System.Drawing.Point(2, 8)
        Me.CutoffLocationLabel.Name = "CutoffLocationLabel"
        Me.CutoffLocationLabel.Size = New System.Drawing.Size(199, 23)
        Me.CutoffLocationLabel.TabIndex = 0
        Me.CutoffLocationLabel.Text = "&Relative Cutoff Distance"
        Me.CutoffLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InfiltrationDepthLabel
        '
        Me.InfiltrationDepthLabel.Location = New System.Drawing.Point(2, 32)
        Me.InfiltrationDepthLabel.Name = "InfiltrationDepthLabel"
        Me.InfiltrationDepthLabel.Size = New System.Drawing.Size(199, 23)
        Me.InfiltrationDepthLabel.TabIndex = 4
        Me.InfiltrationDepthLabel.Text = "&& I&nfiltration Depth"
        Me.InfiltrationDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutoffLocationControl
        '
        Me.CutoffLocationControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutoffLocationControl.IsCalculated = False
        Me.CutoffLocationControl.IsInteger = False
        Me.CutoffLocationControl.Location = New System.Drawing.Point(207, 7)
        Me.CutoffLocationControl.MaxErrMsg = ""
        Me.CutoffLocationControl.MinErrMsg = ""
        Me.CutoffLocationControl.Name = "CutoffLocationControl"
        Me.CutoffLocationControl.Size = New System.Drawing.Size(144, 24)
        Me.CutoffLocationControl.TabIndex = 1
        Me.CutoffLocationControl.ToBeCalculated = True
        Me.CutoffLocationControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutoffLocationControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutoffLocationControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutoffLocationControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutoffLocationControl.ValueText = ""
        '
        'CutoffTimePanel
        '
        Me.CutoffTimePanel.Controls.Add(Me.CutoffTimeControl)
        Me.CutoffTimePanel.Controls.Add(Me.CutoffTimeLabel)
        Me.CutoffTimePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffTimePanel.Location = New System.Drawing.Point(1, 64)
        Me.CutoffTimePanel.Name = "CutoffTimePanel"
        Me.CutoffTimePanel.Size = New System.Drawing.Size(351, 56)
        Me.CutoffTimePanel.TabIndex = 3
        '
        'CutoffTimeControl
        '
        Me.CutoffTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutoffTimeControl.IsCalculated = False
        Me.CutoffTimeControl.IsInteger = False
        Me.CutoffTimeControl.Location = New System.Drawing.Point(204, 16)
        Me.CutoffTimeControl.MaxErrMsg = ""
        Me.CutoffTimeControl.MinErrMsg = ""
        Me.CutoffTimeControl.Name = "CutoffTimeControl"
        Me.CutoffTimeControl.Size = New System.Drawing.Size(144, 24)
        Me.CutoffTimeControl.TabIndex = 1
        Me.CutoffTimeControl.ToBeCalculated = True
        Me.CutoffTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutoffTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutoffTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutoffTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutoffTimeControl.ValueText = ""
        '
        'CutoffTimeLabel
        '
        Me.CutoffTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffTimeLabel.Location = New System.Drawing.Point(2, 16)
        Me.CutoffTimeLabel.Name = "CutoffTimeLabel"
        Me.CutoffTimeLabel.Size = New System.Drawing.Size(198, 23)
        Me.CutoffTimeLabel.TabIndex = 0
        Me.CutoffTimeLabel.Text = "Cutoff &Time"
        Me.CutoffTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutbackPanel
        '
        Me.CutbackPanel.Controls.Add(Me.CutbackTimeControl)
        Me.CutbackPanel.Controls.Add(Me.CutbackLocationControl)
        Me.CutbackPanel.Controls.Add(Me.CutbackRateControl)
        Me.CutbackPanel.Controls.Add(Me.CutbackRateLabel)
        Me.CutbackPanel.Controls.Add(Me.CutbackTimeLabel)
        Me.CutbackPanel.Controls.Add(Me.CutbackLocationLabel)
        Me.CutbackPanel.Location = New System.Drawing.Point(0, 120)
        Me.CutbackPanel.Name = "CutbackPanel"
        Me.CutbackPanel.Size = New System.Drawing.Size(352, 56)
        Me.CutbackPanel.TabIndex = 4
        '
        'CutbackTimeControl
        '
        Me.CutbackTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutbackTimeControl.IsCalculated = False
        Me.CutbackTimeControl.IsInteger = False
        Me.CutbackTimeControl.Location = New System.Drawing.Point(205, 8)
        Me.CutbackTimeControl.MaxErrMsg = ""
        Me.CutbackTimeControl.MinErrMsg = ""
        Me.CutbackTimeControl.Name = "CutbackTimeControl"
        Me.CutbackTimeControl.Size = New System.Drawing.Size(144, 24)
        Me.CutbackTimeControl.TabIndex = 1
        Me.CutbackTimeControl.ToBeCalculated = True
        Me.CutbackTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutbackTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutbackTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutbackTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutbackTimeControl.ValueText = ""
        '
        'CutbackLocationControl
        '
        Me.CutbackLocationControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutbackLocationControl.IsCalculated = False
        Me.CutbackLocationControl.IsInteger = False
        Me.CutbackLocationControl.Location = New System.Drawing.Point(206, 8)
        Me.CutbackLocationControl.MaxErrMsg = ""
        Me.CutbackLocationControl.MinErrMsg = ""
        Me.CutbackLocationControl.Name = "CutbackLocationControl"
        Me.CutbackLocationControl.Size = New System.Drawing.Size(142, 24)
        Me.CutbackLocationControl.TabIndex = 5
        Me.CutbackLocationControl.ToBeCalculated = True
        Me.CutbackLocationControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutbackLocationControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutbackLocationControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutbackLocationControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutbackLocationControl.ValueText = ""
        '
        'CutbackRateControl
        '
        Me.CutbackRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutbackRateControl.IsCalculated = False
        Me.CutbackRateControl.IsInteger = False
        Me.CutbackRateControl.Location = New System.Drawing.Point(205, 32)
        Me.CutbackRateControl.MaxErrMsg = ""
        Me.CutbackRateControl.MinErrMsg = ""
        Me.CutbackRateControl.Name = "CutbackRateControl"
        Me.CutbackRateControl.Size = New System.Drawing.Size(144, 24)
        Me.CutbackRateControl.TabIndex = 3
        Me.CutbackRateControl.ToBeCalculated = True
        Me.CutbackRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutbackRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutbackRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutbackRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutbackRateControl.ValueText = ""
        '
        'CutbackRateLabel
        '
        Me.CutbackRateLabel.Location = New System.Drawing.Point(3, 32)
        Me.CutbackRateLabel.Name = "CutbackRateLabel"
        Me.CutbackRateLabel.Size = New System.Drawing.Size(196, 23)
        Me.CutbackRateLabel.TabIndex = 2
        Me.CutbackRateLabel.Text = "Cutback R&ate"
        Me.CutbackRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutbackTimeLabel
        '
        Me.CutbackTimeLabel.Location = New System.Drawing.Point(3, 8)
        Me.CutbackTimeLabel.Name = "CutbackTimeLabel"
        Me.CutbackTimeLabel.Size = New System.Drawing.Size(196, 23)
        Me.CutbackTimeLabel.TabIndex = 0
        Me.CutbackTimeLabel.Text = "Cut&back Time"
        Me.CutbackTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutbackLocationLabel
        '
        Me.CutbackLocationLabel.Location = New System.Drawing.Point(6, 8)
        Me.CutbackLocationLabel.Name = "CutbackLocationLabel"
        Me.CutbackLocationLabel.Size = New System.Drawing.Size(195, 23)
        Me.CutbackLocationLabel.TabIndex = 0
        Me.CutbackLocationLabel.Text = "Cut&back Location"
        Me.CutbackLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabulatedPanel
        '
        Me.TabulatedPanel.Location = New System.Drawing.Point(8, 104)
        Me.TabulatedPanel.Name = "TabulatedPanel"
        Me.TabulatedPanel.Size = New System.Drawing.Size(360, 176)
        Me.TabulatedPanel.TabIndex = 5
        '
        'CablegationPanel
        '
        Me.CablegationPanel.Controls.Add(Me.CablegationLabel)
        Me.CablegationPanel.Location = New System.Drawing.Point(8, 104)
        Me.CablegationPanel.Name = "CablegationPanel"
        Me.CablegationPanel.Size = New System.Drawing.Size(360, 176)
        Me.CablegationPanel.TabIndex = 5
        '
        'CablegationLabel
        '
        Me.CablegationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CablegationLabel.Location = New System.Drawing.Point(4, 72)
        Me.CablegationLabel.Name = "CablegationLabel"
        Me.CablegationLabel.Size = New System.Drawing.Size(352, 46)
        Me.CablegationLabel.TabIndex = 0
        Me.CablegationLabel.Text = "See Inflow / Runoff Tab for Cablegation Parameters"
        Me.CablegationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctl_DataSummary
        '
        Me.AccessibleDescription = "Summary access to the major user inputs for a Simulation."
        Me.AccessibleName = "Data Summary"
        Me.AutoScroll = True
        Me.Controls.Add(Me.InflowManagementSummary)
        Me.Controls.Add(Me.RoughnessSummary)
        Me.Controls.Add(Me.InfiltrationSummary)
        Me.Controls.Add(Me.SystemGeometrySummary)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_DataSummary"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.SystemGeometrySummary.ResumeLayout(False)
        Me.FurrowPanel.ResumeLayout(False)
        Me.FurrowSlopePanel.ResumeLayout(False)
        Me.FurrowSlopeMessagePanel.ResumeLayout(False)
        Me.TrapezoidPanel.ResumeLayout(False)
        Me.TabulatedCrossSectionPanel.ResumeLayout(False)
        Me.TabulatedCrossSectionPanel.PerformLayout()
        Me.PowerLawPanel.ResumeLayout(False)
        Me.BasinBorderPanel.ResumeLayout(False)
        Me.SlopePanel.ResumeLayout(False)
        Me.SlopeMessagePanel.ResumeLayout(False)
        Me.InfiltrationSummary.ResumeLayout(False)
        Me.GreenAmptPanel.ResumeLayout(False)
        Me.WarrickGreenAmptPanel.ResumeLayout(False)
        Me.HydrusPanel.ResumeLayout(False)
        Me.HydrusPanel.PerformLayout()
        Me.TimeRatedIntakePanel.ResumeLayout(False)
        Me.CharacteristicInfiltrationPanel.ResumeLayout(False)
        Me.TabulatedInfiltrationPanel.ResumeLayout(False)
        Me.BranchFunctionPanel.ResumeLayout(False)
        Me.ModifiedKostiakovPanel.ResumeLayout(False)
        Me.KostiakovPanel.ResumeLayout(False)
        Me.NrcsIntakePanel.ResumeLayout(False)
        Me.RoughnessSummary.ResumeLayout(False)
        Me.NrcsSuggestedManningNPanel.ResumeLayout(False)
        Me.ManningCnAnPanel.ResumeLayout(False)
        Me.SayreChiPanel.ResumeLayout(False)
        Me.TabulatedRoughnessPanel.ResumeLayout(False)
        Me.InflowManagementSummary.ResumeLayout(False)
        Me.SurgePanel.ResumeLayout(False)
        Me.StandardHydrographPanel.ResumeLayout(False)
        Me.CutoffUpstreamDepthPanel.ResumeLayout(False)
        Me.CutoffLocationPanel.ResumeLayout(False)
        Me.CutoffTimePanel.ResumeLayout(False)
        Me.CutbackPanel.ResumeLayout(False)
        Me.CablegationPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mUnit As Unit = Nothing
    Private mMyStore As DataStore.ObjectNode = Nothing

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mSoilCropProperties As SoilCropProperties = Nothing
    Private WithEvents mInflowManagement As InflowManagement = Nothing

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Private mDictionary As Dictionary = Dictionary.Instance

    Public Sub LinkToModel(ByVal _unit As Unit)

        If (Not (_unit Is Nothing)) Then

            ' Link this control to its models
            mUnit = _unit
            mMyStore = _unit.MyStore

            mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef

            mSystemGeometry = _unit.SystemGeometryRef
            mSoilCropProperties = _unit.SoilCropPropertiesRef
            mInflowManagement = _unit.InflowManagementRef

            ' Link SystemGeometry controls to their models
            SlopeControl.LinkToModel(mMyStore, mSystemGeometry.SlopeProperty)
            FurrowSlopeControl.LinkToModel(mMyStore, mSystemGeometry.SlopeProperty)
            DepthControl.LinkToModel(mMyStore, mSystemGeometry.DepthProperty)
            LengthControl.LinkToModel(mMyStore, mSystemGeometry.LengthProperty)
            WidthControl.LinkToModel(mMyStore, mSystemGeometry.WidthProperty)

            FurrowSpacingControl.LinkToModel(mMyStore, mSystemGeometry.FurrowSpacingProperty)
            FurrowLengthControl.LinkToModel(mMyStore, mSystemGeometry.LengthProperty)

            BottomWidthControl.LinkToModel(mMyStore, mSystemGeometry.BottomWidthProperty)
            SideSlopeControl.LinkToModel(mMyStore, mSystemGeometry.SideSlopeProperty)
            TrapezoidDepthControl.LinkToModel(mMyStore, mSystemGeometry.MaximumDepthProperty)

            WidthAt100mmControl.LinkToModel(mMyStore, mSystemGeometry.WidthAt100mmProperty)
            ExponentControl.LinkToModel(mMyStore, mSystemGeometry.PowerLawExponentProperty)
            PowerLawDepthControl.LinkToModel(mMyStore, mSystemGeometry.MaximumDepthProperty)

            ' Link Infiltration controls to their models
            KT_InfiltrationDepthControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationDepth_KTProperty)
            KT_InfiltrationTimeControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationTime_KTProperty)
            KT_KostiakovAControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_KTProperty)

            KF_KostiakovKControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovK_KFProperty)
            KF_KostiakovAControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_KFProperty)

            MK_KostiakovKControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovK_MKProperty)
            MK_KostiakovAControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_MKProperty)
            MK_KostiakovBControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovB_MKProperty)
            MK_KostiakovCControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovC_MKProperty)

            TR_InfiltrationTimeControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationTime_TRProperty)

            BF_KostiakovKControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovK_BFProperty)
            BF_KostiakovAControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_BFProperty)
            BF_KostiakovCControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovC_BFProperty)
            BF_BranchBControl.LinkToModel(mMyStore, mSoilCropProperties.BranchB_BFProperty)

            GA_PorosityControl.LinkToModel(mMyStore, mSoilCropProperties.EffectivePorosityGA_Property)
            GA_InitVolWaterContentControl.LinkToModel(mMyStore, mSoilCropProperties.InitialWaterContentGA_Property)
            GA_WettingFrontControl.LinkToModel(mMyStore, mSoilCropProperties.WettingFrontPressureHeadGA_Property)
            GA_HydraulicConductivityControl.LinkToModel(mMyStore, mSoilCropProperties.HydraulicConductivityGA_Property)
            GA_cControl.LinkToModel(mMyStore, mSoilCropProperties.GreenAmptC_Property)

            HydrusProject.LinkToModel(mMyStore, mSoilCropProperties.HydrusProjectProperty)

            SaturatedWaterContentWGAControl.LinkToModel(mMyStore, mSoilCropProperties.SaturatedWaterContentWGA_Property)
            InitialWaterContentWGAControl.LinkToModel(mMyStore, mSoilCropProperties.InitialWaterContentWGA_Property)
            WettingFrontPressureWGAControl.LinkToModel(mMyStore, mSoilCropProperties.WettingFrontPressureHeadWGA_Property)
            HydraulicConductivityWGAControl.LinkToModel(mMyStore, mSoilCropProperties.HydraulicConductivityWGA_Property)
            WarrickGreenAmptCControl.LinkToModel(mMyStore, mSoilCropProperties.WarrickGreenAmptC_Property)

            ' Link Roughness controls to their models
            UsersManningNControl.LinkToModel(mMyStore, mSoilCropProperties.UsersManningNProperty)
            ManningCnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningCnProperty)
            ManningAnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningAnProperty)

            SayreChiControl.LinkToModel(mMyStore, mSoilCropProperties.SayreChiProperty)

            Sel_004.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.BareSoil)
            Sel_010.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.SmallGrain)
            Sel_015.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.AlfalfaMintBroadcast)
            Sel_020.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.AlfalfaDenseOrLong)
            Sel_025.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.DenseSodCrops)
            Sel_UserEntered.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.UserEntered)

            ' Link Inflow Management controls to their models
            UnitWaterCostControl.LinkToModel(mMyStore, mInflowManagement.UnitWaterCostProperty)
            RequiredDepthControl.LinkToModel(mMyStore, mInflowManagement.RequiredDepthProperty)

            InflowRateControl.LinkToModel(mMyStore, mInflowManagement.InflowRateProperty)

            CutoffTimeControl.LinkToModel(mMyStore, mInflowManagement.CutoffTimeProperty)
            CutoffLocationControl.LinkToModel(mMyStore, mInflowManagement.CutoffLocationRatioProperty)
            CutoffInfiltrationDepthControl.LinkToModel(mMyStore, mInflowManagement.CutoffInfiltrationDepthProperty)
            CutoffOpportunityTimeControl.LinkToModel(mMyStore, mInflowManagement.CutoffOpportunityTimeProperty)
            CutoffUpstreamDepthControl.LinkToModel(mMyStore, mInflowManagement.CutoffUpstreamDepthProperty)

            CutbackTimeControl.LinkToModel(mMyStore, mInflowManagement.CutbackTimeRatioProperty)
            CutbackLocationControl.LinkToModel(mMyStore, mInflowManagement.CutbackLocationRatioProperty)
            CutbackRateControl.LinkToModel(mMyStore, mInflowManagement.CutbackRateRatioProperty)

            ' Update this control's User Interface
            UpdateSystemGeometry()
            UpdateInfiltration()
            UpdateRoughness()
            UpdateInflow()

        End If
    End Sub
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated
        UpdateSystemGeometry()
        UpdateInfiltration()
        UpdateRoughness()
        UpdateInflow()
    End Sub

    Public Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateSystemGeometry()
        UpdateInflow()
    End Sub

    Public Sub SoilCropProperties_PropertyChanged(ByVal _reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        UpdateInfiltration()
        UpdateRoughness()
    End Sub

    Public Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateInflow()
    End Sub
    '
    ' Update the graphics when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        ' Don't allow event driven updates prior to initialization
        If Not (mSystemGeometry Is Nothing) Then
            UpdateSystemGeometry()
        End If
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Private Sub UpdateSystemGeometry()

        ' Update the UI only if it is linked to a model object
        If Not (mSystemGeometry Is Nothing) Then

            ' Get the geometric shape factors
            Dim _crossSection As CrossSections = CType(mSystemGeometry.CrossSection.Value, CrossSections)
            Dim _bottom As BottomDescriptions = CType(mSystemGeometry.BottomDescription.Value, BottomDescriptions)
            Dim _upstream As UpstreamConditions = CType(mSystemGeometry.UpstreamCondition.Value, UpstreamConditions)
            Dim _downstream As DownstreamConditions = CType(mSystemGeometry.DownstreamCondition.Value, DownstreamConditions)
            Dim _furrowShape As FurrowShapes = CType(mSystemGeometry.FurrowShape.Value, FurrowShapes)

            ' Start the description string
            Dim _desc As String = CrossSectionSelections(_crossSection).Value + ", "
            _desc += UpstreamConditionSelections(_upstream).Value + ", "
            _desc += DownstreamConditionSelections(_downstream).Value

            ' Show/hide UI sections that are dependent on the Bottom Description selection
            Select Case (_bottom)
                Case BottomDescriptions.AvgFromSlopeTable, BottomDescriptions.AvgFromElevTable
                    Dim _averageSlope As Double = mSystemGeometry.AverageSlopeFromElevationTable
                    Dim _slopeMessage As String = mDictionary.tAverageSlope.Translated & " = " & SlopeString(_averageSlope, 0)

                    FurrowSlopePanel.Hide()
                    FurrowSlopeMessagePanel.Show()
                    FurrowSlopeMessage.Text = _slopeMessage

                    SlopePanel.Hide()
                    SlopeMessagePanel.Show()
                    SlopeMessage.Text = _slopeMessage
                Case Globals.BottomDescriptions.SlopeTable
                    FurrowSlopePanel.Hide()
                    FurrowSlopeMessagePanel.Show()
                    FurrowSlopeMessage.Text = mDictionary.tSlopeDefinedBySlopeTable.Translated

                    SlopePanel.Hide()
                    SlopeMessagePanel.Show()
                    SlopeMessage.Text = mDictionary.tSlopeDefinedBySlopeTable.Translated
                Case Globals.BottomDescriptions.ElevationTable
                    FurrowSlopePanel.Hide()
                    FurrowSlopeMessagePanel.Show()
                    FurrowSlopeMessage.Text = mDictionary.tSlopeDefinedByElevationTable.Translated

                    SlopePanel.Hide()
                    SlopeMessagePanel.Show()
                    SlopeMessage.Text = mDictionary.tSlopeDefinedByElevationTable.Translated
                Case Else ' Assume Globals.BottomDescriptions.Slope
                    FurrowSlopeMessagePanel.Hide()
                    FurrowSlopePanel.Show()

                    SlopeMessagePanel.Hide()
                    SlopePanel.Show()
                    LevelSlopeLabel.Hide()
                    SlopeControl.Show()
            End Select

            ' Show/hide UI sections that are dependent on the Cross Section selection
            Dim worldType As WorldTypes = mSystemGeometry.Unit.UnitType.Value

            If (_crossSection = CrossSections.Furrow) Then

                Select Case (_furrowShape)
                    Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData

                        _desc = mDictionary.tPowerLaw.Translated & " " + _desc

                        If (worldType = WorldTypes.SimulationWorld) Then
                            If ((_furrowShape = FurrowShapes.PowerLaw) And (mSystemGeometry.EnableTabulatedFurrowShape.Value)) Then
                                PowerLawPanel.Hide()
                                TrapezoidPanel.Hide()
                                TabulatedCrossSectionPanel.Show()
                            Else
                                TrapezoidPanel.Hide()
                                TabulatedCrossSectionPanel.Hide()
                                PowerLawPanel.Show()

                                Select Case (mUnitsSystem.UnitSystem)
                                    Case UnitsDefinition.UnitSystems.English
                                        WidthAt100mmLabel.Text = mDictionary.tWidthAt.Translated & " 4in"
                                    Case Else ' Assume UnitsDefinition.UnitSystems.Metric
                                        WidthAt100mmLabel.Text = mDictionary.tWidthAt.Translated & " 100mm"
                                End Select
                            End If
                        Else
                            TrapezoidPanel.Hide()
                            TabulatedCrossSectionPanel.Hide()
                            PowerLawPanel.Show()

                            Select Case (mUnitsSystem.UnitSystem)
                                Case UnitsDefinition.UnitSystems.English
                                    WidthAt100mmLabel.Text = mDictionary.tWidthAt.Translated & " 4in"
                                Case Else ' Assume UnitsDefinition.UnitSystems.Metric
                                    WidthAt100mmLabel.Text = mDictionary.tWidthAt.Translated & " 100mm"
                            End Select

                        End If

                    Case Else ' Trapezoid Furrow

                        _desc = mDictionary.tTrapezoid.Translated & " " + _desc

                        If (worldType = WorldTypes.SimulationWorld) Then
                            If ((_furrowShape = FurrowShapes.Trapezoid) And (mSystemGeometry.EnableTabulatedFurrowShape.Value)) Then
                                PowerLawPanel.Hide()
                                TrapezoidPanel.Hide()
                                TabulatedCrossSectionPanel.Show()
                            Else
                                PowerLawPanel.Hide()
                                TabulatedCrossSectionPanel.Hide()
                                TrapezoidPanel.Show()
                            End If
                        Else
                            PowerLawPanel.Hide()
                            TabulatedCrossSectionPanel.Hide()
                            TrapezoidPanel.Show()
                        End If

                End Select

                FurrowLabel.Text = _desc
                BasinBorderPanel.Hide()
                FurrowPanel.Show()
            Else
                BasinBorderLabel.Text = _desc
                FurrowPanel.Hide()
                BasinBorderPanel.Show()

                If (worldType = WorldTypes.SimulationWorld) Then
                    If (mSystemGeometry.EnableTabulatedBorderDepth.Value) Then
                        DepthLabel.Hide()
                        DepthControl.Hide()
                    Else
                        DepthLabel.Show()
                        DepthControl.Show()
                    End If
                Else
                    DepthLabel.Show()
                    DepthControl.Show()
                End If
            End If
        End If

    End Sub

    Private Sub UpdateInfiltration()

        ' Update the UI only if it is linked to a model object
        If Not (mSoilCropProperties Is Nothing) Then

            Dim _crossSection As CrossSections = CType(mSystemGeometry.CrossSection.Value, CrossSections)
            Dim _infiltrationFunction As InfiltrationFunctions = CType(mSoilCropProperties.InfiltrationFunction.Value, InfiltrationFunctions)
            Dim _wettedPerimeterMethod As WettedPerimeterMethods = CType(mSoilCropProperties.WettedPerimeterMethod.Value, WettedPerimeterMethods)
            Dim _tabulated As Boolean = mSoilCropProperties.EnableTabulatedInfiltration.Value

            ' Start the description string
            Dim _desc As String = InfiltrationFunctionSelections(_infiltrationFunction).Value

            Dim aProp As PropertyNode

            ' Hide/Show controls
            If (_tabulated) Then
                TimeRatedIntakePanel.Hide()
                KostiakovPanel.Hide()
                ModifiedKostiakovPanel.Hide()
                BranchFunctionPanel.Hide()
                NrcsIntakePanel.Hide()
                CharacteristicInfiltrationPanel.Hide()
                HydrusPanel.Hide()
                WarrickGreenAmptPanel.Hide()

                TabulatedInfiltrationPanel.Show()
            Else
                TabulatedInfiltrationPanel.Hide()

                Dim a As Double = mSoilCropProperties.KostiakovA
                Dim k As Double = mSoilCropProperties.KostiakovK

                Dim _kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

                Select Case _infiltrationFunction

                    Case InfiltrationFunctions.CharacteristicInfiltrationTime
                        TimeRatedIntakePanel.Hide()
                        KostiakovPanel.Hide()
                        ModifiedKostiakovPanel.Hide()
                        BranchFunctionPanel.Hide()
                        NrcsIntakePanel.Hide()
                        GreenAmptPanel.Hide()
                        HydrusPanel.Hide()
                        WarrickGreenAmptPanel.Hide()
                        CharacteristicInfiltrationPanel.Show()

                        aProp = mSoilCropProperties.KostiakovA_KTProperty
                        KT_KostiakovAControl.CheckError()

                        ' Update Kostiakov k
                        KT_KostiakovK.Text = "Kostiakov k = " + KostiakovKParameter.KostiakovKString(k, a, _kunits, 0)

                    Case InfiltrationFunctions.KostiakovFormula
                        TimeRatedIntakePanel.Hide()
                        BranchFunctionPanel.Hide()
                        CharacteristicInfiltrationPanel.Hide()
                        NrcsIntakePanel.Hide()
                        ModifiedKostiakovPanel.Hide()
                        GreenAmptPanel.Hide()
                        HydrusPanel.Hide()
                        WarrickGreenAmptPanel.Hide()
                        KostiakovPanel.Show()

                        aProp = mSoilCropProperties.KostiakovA_KFProperty
                        KF_KostiakovAControl.CheckError()

                    Case InfiltrationFunctions.ModifiedKostiakovFormula
                        TimeRatedIntakePanel.Hide()
                        BranchFunctionPanel.Hide()
                        CharacteristicInfiltrationPanel.Hide()
                        NrcsIntakePanel.Hide()
                        KostiakovPanel.Hide()
                        GreenAmptPanel.Hide()
                        HydrusPanel.Hide()
                        WarrickGreenAmptPanel.Hide()
                        ModifiedKostiakovPanel.Show()

                        aProp = mSoilCropProperties.KostiakovA_MKProperty
                        MK_KostiakovAControl.CheckError()

                    Case InfiltrationFunctions.NRCSIntakeFamily
                        TimeRatedIntakePanel.Hide()
                        KostiakovPanel.Hide()
                        KostiakovPanel.Hide()
                        ModifiedKostiakovPanel.Hide()
                        BranchFunctionPanel.Hide()
                        CharacteristicInfiltrationPanel.Hide()
                        GreenAmptPanel.Hide()
                        HydrusPanel.Hide()
                        WarrickGreenAmptPanel.Hide()
                        NrcsIntakePanel.Show()

                        ' Update Kostiakov a & k
                        NrcsCalculatedA.Text = "Kostiakov a = " + Format(a, "0.000#")
                        NrcsCalculatedK.Text = "Kostiakov k = " + KostiakovKParameter.KostiakovKString(k, a, _kunits, 0)

                    Case InfiltrationFunctions.TimeRatedIntakeFamily
                        KostiakovPanel.Hide()
                        ModifiedKostiakovPanel.Hide()
                        BranchFunctionPanel.Hide()
                        CharacteristicInfiltrationPanel.Hide()
                        NrcsIntakePanel.Hide()
                        GreenAmptPanel.Hide()
                        HydrusPanel.Hide()
                        WarrickGreenAmptPanel.Hide()
                        TimeRatedIntakePanel.Show()

                        ' Update Kostiakov a & k
                        TR_KostiakovA.Text = "Kostiakov a = " + Format(a, "0.000#")
                        TR_KostiakovK.Text = "Kostiakov k = " + KostiakovKParameter.KostiakovKString(k, a, _kunits, 0)

                    Case InfiltrationFunctions.GreenAmpt
                        KostiakovPanel.Hide()
                        ModifiedKostiakovPanel.Hide()
                        BranchFunctionPanel.Hide()
                        CharacteristicInfiltrationPanel.Hide()
                        NrcsIntakePanel.Hide()
                        TimeRatedIntakePanel.Hide()
                        HydrusPanel.Hide()
                        WarrickGreenAmptPanel.Hide()
                        GreenAmptPanel.Show()

                        ' Update SWD calculation
                        Dim SWD As Double = mSoilCropProperties.EffectivePorosityGA.Value - mSoilCropProperties.InitialWaterContentGA.Value
                        Me.GA_SWD.Text = "SWD " + ConcentrationLengthString(SWD)

                    Case InfiltrationFunctions.Hydrus1D
                        KostiakovPanel.Hide()
                        ModifiedKostiakovPanel.Hide()
                        BranchFunctionPanel.Hide()
                        CharacteristicInfiltrationPanel.Hide()
                        NrcsIntakePanel.Hide()
                        TimeRatedIntakePanel.Hide()
                        GreenAmptPanel.Hide()
                        WarrickGreenAmptPanel.Hide()
                        HydrusPanel.Show()

                    Case InfiltrationFunctions.WarrickGreenAmpt
                        KostiakovPanel.Hide()
                        ModifiedKostiakovPanel.Hide()
                        BranchFunctionPanel.Hide()
                        CharacteristicInfiltrationPanel.Hide()
                        NrcsIntakePanel.Hide()
                        TimeRatedIntakePanel.Hide()
                        HydrusPanel.Hide()
                        GreenAmptPanel.Hide()
                        WarrickGreenAmptPanel.Show()

                    Case Else ' Assume Branch Function
                        TimeRatedIntakePanel.Hide()
                        KostiakovPanel.Hide()
                        ModifiedKostiakovPanel.Hide()
                        CharacteristicInfiltrationPanel.Hide()
                        NrcsIntakePanel.Hide()
                        GreenAmptPanel.Hide()
                        HydrusPanel.Hide()
                        WarrickGreenAmptPanel.Hide()
                        BranchFunctionPanel.Show()

                        aProp = mSoilCropProperties.KostiakovA_BFProperty
                        BF_KostiakovAControl.CheckError()

                        Dim bt As Double = mSoilCropProperties.BranchTime
                        BF_BranchTime.Text = TimeString(bt, 0)
                End Select
            End If

            ' For furrows, add the Wetted Perimeter Method
            If (_crossSection = CrossSections.Furrow) Then
                If (_infiltrationFunction = InfiltrationFunctions.WarrickGreenAmpt) Then
                Else
                    _desc += ", " + WettedPerimeterMethodSelections(_wettedPerimeterMethod).Value
                End If
            End If

            ' Display the description string
            InfiltrationLabel.Text = _desc

        End If
    End Sub

    Private Sub UpdateRoughness()

        ' Update the UI only if it is linked to a model object
        If Not (mSoilCropProperties Is Nothing) Then

            Dim _roughnessMethod As RoughnessMethods = CType(mSoilCropProperties.RoughnessMethod.Value, RoughnessMethods)
            Dim _tabulated As Boolean = mSoilCropProperties.EnableTabulatedRoughness.Value

            ' Start the description string
            Dim _desc As String = RoughnessMethodSelections(_roughnessMethod).Value

            ' Hide / Show correspnding UI panels
            If (_tabulated) Then
                SayreChiPanel.Hide()
                ManningCnAnPanel.Hide()
                NrcsSuggestedManningNPanel.Hide()

                TabulatedRoughnessPanel.Show()
            Else
                TabulatedRoughnessPanel.Hide()

                Select Case _roughnessMethod
                    Case RoughnessMethods.ManningN, RoughnessMethods.NrcsSuggestedManningN
                        SayreChiPanel.Hide()
                        ManningCnAnPanel.Hide()
                        NrcsSuggestedManningNPanel.Show()

                        ' Update which NRCS Manning N is checked
                        Select Case mSoilCropProperties.NrcsSuggestedManningN.Value
                            Case NrcsSuggestedManningN.BareSoil
                                Sel_004.Checked = True
                                UsersManningNControl.Enabled = False
                            Case NrcsSuggestedManningN.SmallGrain
                                Sel_010.Checked = True
                                UsersManningNControl.Enabled = False
                            Case NrcsSuggestedManningN.AlfalfaMintBroadcast
                                Sel_015.Checked = True
                                UsersManningNControl.Enabled = False
                            Case NrcsSuggestedManningN.AlfalfaDenseOrLong
                                Sel_020.Checked = True
                                UsersManningNControl.Enabled = False
                            Case NrcsSuggestedManningN.DenseSodCrops
                                Sel_025.Checked = True
                                UsersManningNControl.Enabled = False
                            Case Else ' Assume NrcsSuggestedManningN.UserEntered
                                Sel_UserEntered.Checked = True
                                UsersManningNControl.Enabled = True
                        End Select

                    Case RoughnessMethods.ManningCnAn
                        NrcsSuggestedManningNPanel.Hide()
                        SayreChiPanel.Hide()
                        ManningCnAnPanel.Show()

                    Case Else ' Assume Sayre-Albertson Chi
                        NrcsSuggestedManningNPanel.Hide()
                        ManningCnAnPanel.Hide()
                        SayreChiPanel.Show()
                End Select
            End If

            ' Display the description string
            RoughnessLabel.Text = _desc

        End If
    End Sub

    Private Sub UpdateInflow()

        ' Update the UI only if it is linked to a model object
        If Not (mInflowManagement Is Nothing) Then

            Dim _inflowMethod As InflowMethods = CType(mInflowManagement.InflowMethod.Value, InflowMethods)

            ' Start the description string
            Dim _desc As String = InflowMethodSelections(_inflowMethod).Value

            ' Hide / Show correspnding UI panels
            Select Case _inflowMethod

                Case InflowMethods.Surge
                    StandardHydrographPanel.Hide()
                    CablegationPanel.Hide()
                    TabulatedPanel.Hide()
                    SurgePanel.Show()

                    Dim surgeStrategy As SurgeStrategies = CType(mInflowManagement.SurgeStrategy.Value, SurgeStrategies)

                    Dim surgeText As String = SurgeStrategySelections(surgeStrategy).Value & " " & mDictionary.tSurge.Translated

                    ' Furrow Set | Border
                    If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                        surgeText &= " - " & mDictionary.tFurrowSet.Translated
                    Else
                        surgeText &= " - " & mDictionary.tBorder.Translated
                    End If

                    SurgeStrategyLabel.Text = surgeText

                Case InflowMethods.Cablegation
                    StandardHydrographPanel.Hide()
                    SurgePanel.Hide()
                    TabulatedPanel.Hide()
                    CablegationPanel.Show()

                Case InflowMethods.TabulatedInflow
                    StandardHydrographPanel.Hide()
                    SurgePanel.Hide()
                    CablegationPanel.Hide()
                    TabulatedPanel.Show()

                Case Else ' Assume StandardHydrograph
                    SurgePanel.Hide()
                    CablegationPanel.Hide()
                    TabulatedPanel.Hide()
                    StandardHydrographPanel.Show()

                    Dim _cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)
                    Dim _cutbackMethod As CutbackMethods = CType(mInflowManagement.CutbackMethod.Value, CutbackMethods)

                    ' Start the Cutoff / Cutback description string
                    Dim _cutdesc As String = CutoffMethodSelections(_cutoffMethod).Value
                    _cutdesc += ", " + CutbackMethodSelections(_cutbackMethod).Value
                    CutoffCutbackLabel.BackColor = Drawing.SystemColors.Control

                    ' Time-Based Cutback requires Time-Based Cutoff
                    If (_cutbackMethod = Globals.CutbackMethods.TimeBased) Then
                        If Not (_cutoffMethod = Globals.CutoffMethods.TimeBased) Then
                            _cutdesc = mDictionary.tError.Translated & ":  " & mDictionary.tCutoffDistanceBasedCutbackTimeBased.Translated
                            CutoffCutbackLabel.BackColor = Drawing.Color.LightPink
                        End If
                    End If

                    ' Hide / Show Cutoff panels & controls
                    Select Case _cutoffMethod

                        Case CutoffMethods.TimeBased
                            CutoffLocationPanel.Hide()
                            CutoffUpstreamDepthPanel.Hide()
                            CutoffTimePanel.Show()

                        Case CutoffMethods.DistanceBased
                            CutoffTimePanel.Hide()
                            CutoffUpstreamDepthPanel.Hide()
                            CutoffLocationPanel.Show()

                            InfiltrationDepthLabel.Hide()
                            CutoffInfiltrationDepthControl.Hide()
                            OpportunityTimeLabel.Hide()
                            CutoffOpportunityTimeControl.Hide()

                        Case CutoffMethods.DistanceInfDepth
                            CutoffTimePanel.Hide()
                            CutoffUpstreamDepthPanel.Hide()
                            CutoffLocationPanel.Show()

                            InfiltrationDepthLabel.Show()
                            CutoffInfiltrationDepthControl.Show()
                            OpportunityTimeLabel.Hide()
                            CutoffOpportunityTimeControl.Hide()

                        Case CutoffMethods.DistanceOppTime
                            CutoffTimePanel.Hide()
                            CutoffUpstreamDepthPanel.Hide()
                            CutoffLocationPanel.Show()

                            InfiltrationDepthLabel.Hide()
                            CutoffInfiltrationDepthControl.Hide()
                            OpportunityTimeLabel.Show()
                            CutoffOpportunityTimeControl.Show()

                        Case Else ' Assume Globals.CutoffMethods.UpstreamInfDepth
                            CutoffTimePanel.Hide()
                            CutoffLocationPanel.Hide()
                            CutoffUpstreamDepthPanel.Show()
                    End Select

                    Select Case mInflowManagement.Unit.UnitType.Value
                        Case WorldTypes.SimulationWorld, _
                             WorldTypes.EventWorld

                            ' Hide / Show UI panels & controls
                            Select Case mInflowManagement.CutbackMethod.Value

                                Case CutbackMethods.TimeBased
                                    CutbackPanel.Show()

                                    CutbackTimeLabel.Show()
                                    CutbackTimeControl.Show()
                                    CutbackLocationLabel.Hide()
                                    CutbackLocationControl.Hide()

                                Case CutbackMethods.DistanceBased
                                    CutbackPanel.Show()

                                    CutbackTimeLabel.Hide()
                                    CutbackTimeControl.Hide()
                                    CutbackLocationLabel.Show()
                                    CutbackLocationControl.Show()

                                Case Else ' No Cutback
                                    CutbackPanel.Hide()

                            End Select
                        Case Else
                            CutbackPanel.Hide()
                    End Select

                    ' Display the description string
                    CutoffCutbackLabel.Text = _cutdesc

            End Select

            ' Display the description string
            InflowManagementLabel.Text = _desc
            InflowManagementLabel.Show()

        End If

    End Sub

#End Region

#Region " UI Event Handlers "
    '
    ' Update NRCS Manning N selection
    '
    Private Sub SetNrcsManningN(ByVal _suggested As NrcsSuggestedManningN)
        If (mSoilCropProperties IsNot Nothing) Then
            Dim _double As DoubleParameter = mSoilCropProperties.ManningN
            If (_suggested = NrcsSuggestedManningN.UserEntered) Then
                _double.Value = mSoilCropProperties.UsersManningN.Value
            Else
                _double.Value = NrcsSuggestedManningNValues(_suggested)
            End If
            _double.Source = DataStore.Globals.ValueSources.UserEntered
            mSoilCropProperties.ManningN = _double
        End If
    End Sub

    Private Sub Sel_004_ControlValueChanged() Handles Sel_004.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.BareSoil)
    End Sub

    Private Sub Sel_010_ControlValueChanged() Handles Sel_010.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.SmallGrain)
    End Sub

    Private Sub Sel_015_ControlValueChanged() Handles Sel_015.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.AlfalfaMintBroadcast)
    End Sub

    Private Sub Sel_020_ControlValueChanged() Handles Sel_020.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.AlfalfaDenseOrLong)
    End Sub

    Private Sub Sel_025_ControlValueChanged() Handles Sel_025.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.DenseSodCrops)
    End Sub

    Private Sub Sel_UserEntered_ControlValueChanged() Handles Sel_UserEntered.ControlValueChanged
        If (mSoilCropProperties IsNot Nothing) Then
            Dim _double As DoubleParameter = mSoilCropProperties.ManningN
            _double.Value = mSoilCropProperties.UsersManningN.Value
            _double.Source = DataStore.Globals.ValueSources.UserEntered
            mSoilCropProperties.ManningN = _double
        End If
    End Sub

    Private Sub UserManningNControl_ControlValueChanged() Handles UsersManningNControl.ControlValueChanged
        If (mSoilCropProperties IsNot Nothing) Then
            Dim _double As DoubleParameter = mSoilCropProperties.ManningN
            _double.Value = mSoilCropProperties.UsersManningN.Value
            _double.Source = DataStore.Globals.ValueSources.UserEntered
            mSoilCropProperties.ManningN = _double
        End If
    End Sub

    Private Sub SlopeControl_ControlValueChanged() _
    Handles SlopeControl.ControlValueChanged
        ' Slope changes can effect Cell Density, Solution Model & DMLMOD
        mUnit.SrfrCriteriaRef.CheckCellDensity(CellDensities.Medium)
        mUnit.SrfrCriteriaRef.CheckSolutionModel()
    End Sub

#End Region

End Class
