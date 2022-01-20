
'*************************************************************************************************************
' UserControl:  ctl_Infiltration    - UI for viewing & editing Infiltration parameters
'
' ctl_Infiltration is combined with ctl_Roughness to form ctl_SoilCropProperties
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI

Imports Srfr
Imports Srfr.SrfrAPI

Imports HydrusAPI.Hydrus1D

Public Class ctl_Infiltration
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
    Friend WithEvents InfiltrationGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents InfiltrationGraphics As GraphingUI.ex_PictureBox
    Friend WithEvents InfiltrationEquationControl As DataStore.ctl_SelectParameter
    Friend WithEvents InfiltrationEquationLabel As DataStore.ctl_Label
    Friend WithEvents TimeRatedIntakePanel As DataStore.ctl_Panel
    Friend WithEvents TR_InfiltrationTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents TR_InfiltrationTimeLabel As DataStore.ctl_Label
    Friend WithEvents TR_InfiltrationDepthLabel As DataStore.ctl_Label
    Friend WithEvents BranchFunctionPanel As DataStore.ctl_Panel
    Friend WithEvents BF_KostiakovCControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_KostiakovAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_KostiakovBLabel As System.Windows.Forms.Label
    Friend WithEvents BF_KostiakovCLabel As System.Windows.Forms.Label
    Friend WithEvents BF_KostiakovALabel As System.Windows.Forms.Label
    Friend WithEvents NrcsIntakePanel As DataStore.ctl_Panel
    Friend WithEvents Sel_090 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_200 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_150 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_100 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_080 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_070 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_060 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_050 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_045 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_040 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_035 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_030 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_025 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_020 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_015 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_010 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_005 As DataStore.ctl_RadioButton
    Friend WithEvents ModifiedKostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents MK_KostiakovAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MK_KostiakovCControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MK_KostiakovALabel As System.Windows.Forms.Label
    Friend WithEvents MK_KostiakovKLabel As System.Windows.Forms.Label
    Friend WithEvents MK_KostiakovCLabel As System.Windows.Forms.Label
    Friend WithEvents MK_KostiakovBLabel As System.Windows.Forms.Label
    Friend WithEvents CharacteristicInfiltrationPanel As DataStore.ctl_Panel
    Friend WithEvents KT_InfiltrationTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_KostiakovAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_InfiltrationDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_InfiltrationTimeLabel As DataStore.ctl_Label
    Friend WithEvents KT_KostiakovALabel As System.Windows.Forms.Label
    Friend WithEvents KT_InfiltrationDepthLabel As DataStore.ctl_Label
    Friend WithEvents Sel_300 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_400 As DataStore.ctl_RadioButton
    Friend WithEvents BF_KostiakovKLabel As System.Windows.Forms.Label
    Friend WithEvents ModifiedKostiakovFormula As System.Windows.Forms.Label
    Friend WithEvents KostiakovFormula As System.Windows.Forms.Label
    Friend WithEvents BranchFormula As System.Windows.Forms.Label
    Friend WithEvents KostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents BF_BranchBControl As WinMain.ctl_KostiakovBParameter
    Friend WithEvents TR_InfiltrationDepthControl As DataStore.ctl_Label
    Friend WithEvents KF_KostiakovALabel As System.Windows.Forms.Label
    Friend WithEvents KF_KostiakovKLabel As System.Windows.Forms.Label
    Friend WithEvents KT_KostiakovK As System.Windows.Forms.Label
    Friend WithEvents TR_KostiakovA As System.Windows.Forms.Label
    Friend WithEvents TR_KostiakovK As System.Windows.Forms.Label
    Friend WithEvents KF_KostiakovAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WettedPerimeterControl As DataStore.ctl_SelectParameter
    Friend WithEvents WettedPerimeterLabel As DataStore.ctl_Label
    Friend WithEvents NrcsOptionsButton As DataStore.ctl_Button
    Friend WithEvents NrcsA As System.Windows.Forms.Label
    Friend WithEvents NrcsK As System.Windows.Forms.Label
    Friend WithEvents NrcsC As System.Windows.Forms.Label
    Friend WithEvents TabulatedKostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedKostiakovControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedModifiedKostiakovPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedModifiedKostiakovControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedBranchPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedBranchFunctionControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedNrcsIntakePanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedNrcsIntakeControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedCharacteristicTimePanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedCharacteristicTimeControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedTimeRatedPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedTimeRatedControl As DataStore.ctl_DataTableParameter
    Friend WithEvents KF_KostiakovKControl As WinMain.ctl_KostiakovKParameter
    Friend WithEvents MK_KostiakovKControl As WinMain.ctl_KostiakovKParameter
    Friend WithEvents MK_KostiakovBControl As WinMain.ctl_KostiakovBParameter
    Friend WithEvents GreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents GA_SatWaterContentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents GA_SatWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents GA_HydraulicConductivityControl As DataStore.ctl_DoubleParameter
    Friend WithEvents GA_HydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents GA_WettingFrontControl As DataStore.ctl_DoubleParameter
    Friend WithEvents GA_WettingFrontLabel As DataStore.ctl_Label
    Friend WithEvents GA_InitVolWaterContentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents GA_InitVolWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents GA_ModifiedLabel As DataStore.ctl_Label
    Friend WithEvents GA_SoilTextureControl As DataStore.ctl_SelectParameter
    Friend WithEvents GA_SoilTextureLabel As DataStore.ctl_Label
    Friend WithEvents TabulatedGreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedGreenAmptControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedHydrusPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedHydrusControl As WinMain.ctl_HydrusTableParameter
    Friend WithEvents GA_InstantaneousInfiltrationControl As DataStore.ctl_DoubleParameter
    Friend WithEvents GA_InstantaneousInfiltrationLabel As DataStore.ctl_Label
    Friend WithEvents GA_SWD As System.Windows.Forms.Label
    Friend WithEvents KostiakovCOptionControl As DataStore.ctl_CheckParameter
    Friend WithEvents BranchCOptionControl As DataStore.ctl_CheckParameter
    Friend WithEvents Hydrus1DPanel As DataStore.ctl_Panel
    Friend WithEvents SelectHydrusProjectButton As DataStore.ctl_Button
    Friend WithEvents HydrusProject As DataStore.ctl_StringParameter
    Friend WithEvents WarrickGreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents WGA_InstantaneousInfiltrationControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_InstantaneousInfiltrationLabel As DataStore.ctl_Label
    Friend WithEvents WGA_HydraulicConductivityControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_HydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents WGA_WettingFrontControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_WettingFrontLabel As DataStore.ctl_Label
    Friend WithEvents WGA_InitWaterContentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_InitWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents WGA_SatWaterContentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_SatWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents TabulatedWarrickGreenAmptPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedWarrickGreenAmptControl As DataStore.ctl_DataTableParameter
    Friend WithEvents UseInfiltrationEditorButton As DataStore.ctl_Button
    Friend WithEvents SimOptsPanel As DataStore.ctl_Panel
    Friend WithEvents LimitingDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents TabulatedInfiltrationSelect As DataStore.ctl_CheckParameter
    Friend WithEvents LimitingDepthSelect As DataStore.ctl_CheckParameter
    Friend WithEvents RefInflowPanel As DataStore.ctl_Panel
    Friend WithEvents RefInflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RefInflowRateSelect As DataStore.ctl_CheckParameter
    Friend WithEvents RefInflowDesc As DataStore.ctl_Label
    Friend WithEvents WGA_ModifiedLabel As DataStore.ctl_Label
    Friend WithEvents WGA_SoilTextureControl As DataStore.ctl_SelectParameter
    Friend WithEvents WGA_SoilTextureLabel As DataStore.ctl_Label
    Friend WithEvents WGA_SWD As System.Windows.Forms.Label
    Friend WithEvents WGA_GammaControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_GammaLabel As DataStore.ctl_Label
    Friend WithEvents InfiltrationFunctionPanel As DataStore.ctl_Panel
    Friend WithEvents BF_BranchTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_BranchTimeSet As DataStore.ctl_CheckParameter
    Friend WithEvents BF_BranchTimeValue As DataStore.ctl_Label
    Friend WithEvents BF_KostiakovKControl As WinMain.ctl_KostiakovKParameter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_Infiltration))
        Me.InfiltrationGroupBox = New DataStore.ctl_GroupBox()
        Me.BranchFunctionPanel = New DataStore.ctl_Panel()
        Me.BF_BranchTimeValue = New DataStore.ctl_Label()
        Me.BF_BranchTimeControl = New DataStore.ctl_DoubleParameter()
        Me.BF_BranchTimeSet = New DataStore.ctl_CheckParameter()
        Me.BranchCOptionControl = New DataStore.ctl_CheckParameter()
        Me.BF_KostiakovKControl = New WinMain.ctl_KostiakovKParameter()
        Me.BranchFormula = New System.Windows.Forms.Label()
        Me.BF_KostiakovKLabel = New System.Windows.Forms.Label()
        Me.BF_BranchBControl = New WinMain.ctl_KostiakovBParameter()
        Me.BF_KostiakovCControl = New DataStore.ctl_DoubleParameter()
        Me.BF_KostiakovAControl = New DataStore.ctl_DoubleParameter()
        Me.BF_KostiakovBLabel = New System.Windows.Forms.Label()
        Me.BF_KostiakovCLabel = New System.Windows.Forms.Label()
        Me.BF_KostiakovALabel = New System.Windows.Forms.Label()
        Me.WarrickGreenAmptPanel = New DataStore.ctl_Panel()
        Me.WGA_GammaControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_GammaLabel = New DataStore.ctl_Label()
        Me.WGA_SWD = New System.Windows.Forms.Label()
        Me.WGA_ModifiedLabel = New DataStore.ctl_Label()
        Me.WGA_SoilTextureControl = New DataStore.ctl_SelectParameter()
        Me.WGA_SoilTextureLabel = New DataStore.ctl_Label()
        Me.WGA_InstantaneousInfiltrationControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_InstantaneousInfiltrationLabel = New DataStore.ctl_Label()
        Me.WGA_HydraulicConductivityControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_HydraulicConductivityLabel = New DataStore.ctl_Label()
        Me.WGA_WettingFrontControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_WettingFrontLabel = New DataStore.ctl_Label()
        Me.WGA_InitWaterContentControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_InitWaterContentLabel = New DataStore.ctl_Label()
        Me.WGA_SatWaterContentControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_SatWaterContentLabel = New DataStore.ctl_Label()
        Me.InfiltrationFunctionPanel = New DataStore.ctl_Panel()
        Me.WettedPerimeterLabel = New DataStore.ctl_Label()
        Me.WettedPerimeterControl = New DataStore.ctl_SelectParameter()
        Me.RefInflowPanel = New DataStore.ctl_Panel()
        Me.RefInflowRateControl = New DataStore.ctl_DoubleParameter()
        Me.RefInflowDesc = New DataStore.ctl_Label()
        Me.RefInflowRateSelect = New DataStore.ctl_CheckParameter()
        Me.InfiltrationEquationControl = New DataStore.ctl_SelectParameter()
        Me.InfiltrationEquationLabel = New DataStore.ctl_Label()
        Me.UseInfiltrationEditorButton = New DataStore.ctl_Button()
        Me.GreenAmptPanel = New DataStore.ctl_Panel()
        Me.GA_SWD = New System.Windows.Forms.Label()
        Me.GA_InstantaneousInfiltrationControl = New DataStore.ctl_DoubleParameter()
        Me.GA_InstantaneousInfiltrationLabel = New DataStore.ctl_Label()
        Me.GA_ModifiedLabel = New DataStore.ctl_Label()
        Me.GA_SoilTextureControl = New DataStore.ctl_SelectParameter()
        Me.GA_SoilTextureLabel = New DataStore.ctl_Label()
        Me.GA_HydraulicConductivityControl = New DataStore.ctl_DoubleParameter()
        Me.GA_HydraulicConductivityLabel = New DataStore.ctl_Label()
        Me.GA_WettingFrontControl = New DataStore.ctl_DoubleParameter()
        Me.GA_WettingFrontLabel = New DataStore.ctl_Label()
        Me.GA_InitVolWaterContentControl = New DataStore.ctl_DoubleParameter()
        Me.GA_InitVolWaterContentLabel = New DataStore.ctl_Label()
        Me.GA_SatWaterContentControl = New DataStore.ctl_DoubleParameter()
        Me.GA_SatWaterContentLabel = New DataStore.ctl_Label()
        Me.TimeRatedIntakePanel = New DataStore.ctl_Panel()
        Me.TR_InfiltrationDepthControl = New DataStore.ctl_Label()
        Me.TR_KostiakovA = New System.Windows.Forms.Label()
        Me.TR_KostiakovK = New System.Windows.Forms.Label()
        Me.TR_InfiltrationTimeControl = New DataStore.ctl_DoubleParameter()
        Me.TR_InfiltrationTimeLabel = New DataStore.ctl_Label()
        Me.TR_InfiltrationDepthLabel = New DataStore.ctl_Label()
        Me.TabulatedWarrickGreenAmptPanel = New DataStore.ctl_Panel()
        Me.TabulatedWarrickGreenAmptControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedBranchPanel = New DataStore.ctl_Panel()
        Me.TabulatedBranchFunctionControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedGreenAmptPanel = New DataStore.ctl_Panel()
        Me.TabulatedGreenAmptControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedHydrusPanel = New DataStore.ctl_Panel()
        Me.TabulatedHydrusControl = New WinMain.ctl_HydrusTableParameter()
        Me.InfiltrationGraphics = New GraphingUI.ex_PictureBox()
        Me.TabulatedNrcsIntakePanel = New DataStore.ctl_Panel()
        Me.TabulatedNrcsIntakeControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedTimeRatedPanel = New DataStore.ctl_Panel()
        Me.TabulatedTimeRatedControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedCharacteristicTimePanel = New DataStore.ctl_Panel()
        Me.TabulatedCharacteristicTimeControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedKostiakovPanel = New DataStore.ctl_Panel()
        Me.TabulatedKostiakovControl = New DataStore.ctl_DataTableParameter()
        Me.TabulatedModifiedKostiakovPanel = New DataStore.ctl_Panel()
        Me.TabulatedModifiedKostiakovControl = New DataStore.ctl_DataTableParameter()
        Me.NrcsIntakePanel = New DataStore.ctl_Panel()
        Me.NrcsC = New System.Windows.Forms.Label()
        Me.NrcsOptionsButton = New DataStore.ctl_Button()
        Me.NrcsA = New System.Windows.Forms.Label()
        Me.NrcsK = New System.Windows.Forms.Label()
        Me.Sel_400 = New DataStore.ctl_RadioButton()
        Me.Sel_300 = New DataStore.ctl_RadioButton()
        Me.Sel_090 = New DataStore.ctl_RadioButton()
        Me.Sel_200 = New DataStore.ctl_RadioButton()
        Me.Sel_150 = New DataStore.ctl_RadioButton()
        Me.Sel_100 = New DataStore.ctl_RadioButton()
        Me.Sel_080 = New DataStore.ctl_RadioButton()
        Me.Sel_070 = New DataStore.ctl_RadioButton()
        Me.Sel_060 = New DataStore.ctl_RadioButton()
        Me.Sel_050 = New DataStore.ctl_RadioButton()
        Me.Sel_045 = New DataStore.ctl_RadioButton()
        Me.Sel_040 = New DataStore.ctl_RadioButton()
        Me.Sel_035 = New DataStore.ctl_RadioButton()
        Me.Sel_030 = New DataStore.ctl_RadioButton()
        Me.Sel_025 = New DataStore.ctl_RadioButton()
        Me.Sel_020 = New DataStore.ctl_RadioButton()
        Me.Sel_015 = New DataStore.ctl_RadioButton()
        Me.Sel_010 = New DataStore.ctl_RadioButton()
        Me.Sel_005 = New DataStore.ctl_RadioButton()
        Me.ModifiedKostiakovPanel = New DataStore.ctl_Panel()
        Me.MK_KostiakovBControl = New WinMain.ctl_KostiakovBParameter()
        Me.MK_KostiakovKControl = New WinMain.ctl_KostiakovKParameter()
        Me.ModifiedKostiakovFormula = New System.Windows.Forms.Label()
        Me.MK_KostiakovAControl = New DataStore.ctl_DoubleParameter()
        Me.MK_KostiakovCControl = New DataStore.ctl_DoubleParameter()
        Me.MK_KostiakovALabel = New System.Windows.Forms.Label()
        Me.MK_KostiakovKLabel = New System.Windows.Forms.Label()
        Me.MK_KostiakovCLabel = New System.Windows.Forms.Label()
        Me.MK_KostiakovBLabel = New System.Windows.Forms.Label()
        Me.KostiakovCOptionControl = New DataStore.ctl_CheckParameter()
        Me.KostiakovPanel = New DataStore.ctl_Panel()
        Me.KF_KostiakovKControl = New WinMain.ctl_KostiakovKParameter()
        Me.KostiakovFormula = New System.Windows.Forms.Label()
        Me.KF_KostiakovAControl = New DataStore.ctl_DoubleParameter()
        Me.KF_KostiakovALabel = New System.Windows.Forms.Label()
        Me.KF_KostiakovKLabel = New System.Windows.Forms.Label()
        Me.CharacteristicInfiltrationPanel = New DataStore.ctl_Panel()
        Me.KT_KostiakovK = New System.Windows.Forms.Label()
        Me.KT_InfiltrationTimeControl = New DataStore.ctl_DoubleParameter()
        Me.KT_KostiakovAControl = New DataStore.ctl_DoubleParameter()
        Me.KT_InfiltrationDepthControl = New DataStore.ctl_DoubleParameter()
        Me.KT_InfiltrationTimeLabel = New DataStore.ctl_Label()
        Me.KT_KostiakovALabel = New System.Windows.Forms.Label()
        Me.KT_InfiltrationDepthLabel = New DataStore.ctl_Label()
        Me.SimOptsPanel = New DataStore.ctl_Panel()
        Me.LimitingDepthControl = New DataStore.ctl_DoubleParameter()
        Me.TabulatedInfiltrationSelect = New DataStore.ctl_CheckParameter()
        Me.LimitingDepthSelect = New DataStore.ctl_CheckParameter()
        Me.Hydrus1DPanel = New DataStore.ctl_Panel()
        Me.HydrusProject = New DataStore.ctl_StringParameter()
        Me.SelectHydrusProjectButton = New DataStore.ctl_Button()
        Me.InfiltrationGroupBox.SuspendLayout()
        Me.BranchFunctionPanel.SuspendLayout()
        Me.WarrickGreenAmptPanel.SuspendLayout()
        Me.InfiltrationFunctionPanel.SuspendLayout()
        Me.RefInflowPanel.SuspendLayout()
        Me.GreenAmptPanel.SuspendLayout()
        Me.TimeRatedIntakePanel.SuspendLayout()
        Me.TabulatedWarrickGreenAmptPanel.SuspendLayout()
        CType(Me.TabulatedWarrickGreenAmptControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedBranchPanel.SuspendLayout()
        CType(Me.TabulatedBranchFunctionControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedGreenAmptPanel.SuspendLayout()
        CType(Me.TabulatedGreenAmptControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedHydrusPanel.SuspendLayout()
        CType(Me.TabulatedHydrusControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfiltrationGraphics, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedNrcsIntakePanel.SuspendLayout()
        CType(Me.TabulatedNrcsIntakeControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedTimeRatedPanel.SuspendLayout()
        CType(Me.TabulatedTimeRatedControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedCharacteristicTimePanel.SuspendLayout()
        CType(Me.TabulatedCharacteristicTimeControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedKostiakovPanel.SuspendLayout()
        CType(Me.TabulatedKostiakovControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedModifiedKostiakovPanel.SuspendLayout()
        CType(Me.TabulatedModifiedKostiakovControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NrcsIntakePanel.SuspendLayout()
        Me.ModifiedKostiakovPanel.SuspendLayout()
        Me.KostiakovPanel.SuspendLayout()
        Me.CharacteristicInfiltrationPanel.SuspendLayout()
        Me.SimOptsPanel.SuspendLayout()
        Me.Hydrus1DPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'InfiltrationGroupBox
        '
        Me.InfiltrationGroupBox.AccessibleDescription = "Inputs describing the infiltration of water into the soil."
        Me.InfiltrationGroupBox.AccessibleName = "Infiltration"
        Me.InfiltrationGroupBox.Controls.Add(Me.SimOptsPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.BranchFunctionPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.WarrickGreenAmptPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.InfiltrationFunctionPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.UseInfiltrationEditorButton)
        Me.InfiltrationGroupBox.Controls.Add(Me.GreenAmptPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.TimeRatedIntakePanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.TabulatedWarrickGreenAmptPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.TabulatedBranchPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.TabulatedGreenAmptPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.TabulatedHydrusPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.InfiltrationGraphics)
        Me.InfiltrationGroupBox.Controls.Add(Me.TabulatedNrcsIntakePanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.TabulatedTimeRatedPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.TabulatedCharacteristicTimePanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.TabulatedKostiakovPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.TabulatedModifiedKostiakovPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.NrcsIntakePanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.ModifiedKostiakovPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.KostiakovPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.CharacteristicInfiltrationPanel)
        Me.InfiltrationGroupBox.Controls.Add(Me.Hydrus1DPanel)
        Me.InfiltrationGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationGroupBox.Location = New System.Drawing.Point(0, 0)
        Me.InfiltrationGroupBox.Name = "InfiltrationGroupBox"
        Me.InfiltrationGroupBox.Size = New System.Drawing.Size(392, 446)
        Me.InfiltrationGroupBox.TabIndex = 0
        Me.InfiltrationGroupBox.TabStop = False
        Me.InfiltrationGroupBox.Text = "Infiltration"
        '
        'BranchFunctionPanel
        '
        Me.BranchFunctionPanel.AccessibleDescription = "Set of parameters that define the infiltration rate using the Branch Function met" &
    "hod."
        Me.BranchFunctionPanel.AccessibleName = "Branch Function Parameters"
        Me.BranchFunctionPanel.Controls.Add(Me.BF_BranchTimeValue)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_BranchTimeControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_BranchTimeSet)
        Me.BranchFunctionPanel.Controls.Add(Me.BranchCOptionControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovKControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BranchFormula)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovKLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_BranchBControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovCControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovAControl)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovBLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovCLabel)
        Me.BranchFunctionPanel.Controls.Add(Me.BF_KostiakovALabel)
        Me.BranchFunctionPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchFunctionPanel.Location = New System.Drawing.Point(8, 240)
        Me.BranchFunctionPanel.Name = "BranchFunctionPanel"
        Me.BranchFunctionPanel.Size = New System.Drawing.Size(376, 145)
        Me.BranchFunctionPanel.TabIndex = 7
        '
        'BF_BranchTimeValue
        '
        Me.BF_BranchTimeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_BranchTimeValue.Location = New System.Drawing.Point(152, 119)
        Me.BF_BranchTimeValue.Name = "BF_BranchTimeValue"
        Me.BF_BranchTimeValue.Size = New System.Drawing.Size(128, 24)
        Me.BF_BranchTimeValue.TabIndex = 9
        Me.BF_BranchTimeValue.Text = "Tb"
        Me.BF_BranchTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BF_BranchTimeControl
        '
        Me.BF_BranchTimeControl.AccessibleDescription = "Time at which the Branch Function switches from the 'k^a+c' term to the 'b' term." &
    ""
        Me.BF_BranchTimeControl.AccessibleName = "Branch Time"
        Me.BF_BranchTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_BranchTimeControl.IsCalculated = False
        Me.BF_BranchTimeControl.IsInteger = False
        Me.BF_BranchTimeControl.Location = New System.Drawing.Point(152, 119)
        Me.BF_BranchTimeControl.MaxErrMsg = ""
        Me.BF_BranchTimeControl.MinErrMsg = ""
        Me.BF_BranchTimeControl.Name = "BF_BranchTimeControl"
        Me.BF_BranchTimeControl.Size = New System.Drawing.Size(128, 24)
        Me.BF_BranchTimeControl.TabIndex = 9
        Me.BF_BranchTimeControl.ToBeCalculated = True
        Me.BF_BranchTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_BranchTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_BranchTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_BranchTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_BranchTimeControl.ValueText = ""
        '
        'BF_BranchTimeSet
        '
        Me.BF_BranchTimeSet.AccessibleDescription = "Selects whether the Branch Time is entered by the user or calculated by WinSRFR."
        Me.BF_BranchTimeSet.AccessibleName = "Branch Time Select"
        Me.BF_BranchTimeSet.AlwaysChecked = False
        Me.BF_BranchTimeSet.ErrorMessage = Nothing
        Me.BF_BranchTimeSet.Location = New System.Drawing.Point(20, 121)
        Me.BF_BranchTimeSet.Name = "BF_BranchTimeSet"
        Me.BF_BranchTimeSet.Size = New System.Drawing.Size(131, 23)
        Me.BF_BranchTimeSet.TabIndex = 8
        Me.BF_BranchTimeSet.Text = "Branch &Time"
        Me.BF_BranchTimeSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BF_BranchTimeSet.UncheckAttemptMessage = Nothing
        Me.BF_BranchTimeSet.UseVisualStyleBackColor = True
        '
        'BranchCOptionControl
        '
        Me.BranchCOptionControl.AlwaysChecked = False
        Me.BranchCOptionControl.ErrorMessage = Nothing
        Me.BranchCOptionControl.Location = New System.Drawing.Point(2, 97)
        Me.BranchCOptionControl.Name = "BranchCOptionControl"
        Me.BranchCOptionControl.Size = New System.Drawing.Size(112, 23)
        Me.BranchCOptionControl.TabIndex = 11
        Me.BranchCOptionControl.Text = "Time Offset"
        Me.BranchCOptionControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BranchCOptionControl.UncheckAttemptMessage = Nothing
        Me.BranchCOptionControl.UseVisualStyleBackColor = True
        '
        'BF_KostiakovKControl
        '
        Me.BF_KostiakovKControl.Location = New System.Drawing.Point(152, 27)
        Me.BF_KostiakovKControl.Name = "BF_KostiakovKControl"
        Me.BF_KostiakovKControl.Size = New System.Drawing.Size(160, 24)
        Me.BF_KostiakovKControl.TabIndex = 1
        Me.BF_KostiakovKControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_KostiakovKControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_KostiakovKControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_KostiakovKControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_KostiakovKControl.ValueText = ""
        '
        'BranchFormula
        '
        Me.BranchFormula.AccessibleDescription = "Zn = k * T^a + c  branches to  Zn = Zb + (b * T)   at the Branch Time."
        Me.BranchFormula.AccessibleName = "Branch Function"
        Me.BranchFormula.Location = New System.Drawing.Point(6, 2)
        Me.BranchFormula.Name = "BranchFormula"
        Me.BranchFormula.Size = New System.Drawing.Size(368, 23)
        Me.BranchFormula.TabIndex = 10
        Me.BranchFormula.Text = "Zn = k * T^a + c        branches to       Zn = Zb + (b * T)"
        Me.BranchFormula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BF_KostiakovKLabel
        '
        Me.BF_KostiakovKLabel.Location = New System.Drawing.Point(120, 27)
        Me.BF_KostiakovKLabel.Name = "BF_KostiakovKLabel"
        Me.BF_KostiakovKLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_KostiakovKLabel.TabIndex = 0
        Me.BF_KostiakovKLabel.Text = "&k"
        Me.BF_KostiakovKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BF_BranchBControl
        '
        Me.BF_BranchBControl.AccessibleDescription = "Defines the final infiltration rate (b) in the formula:  Zn = Zb + (b * t)."
        Me.BF_BranchBControl.AccessibleName = "Branch b"
        Me.BF_BranchBControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_BranchBControl.IsCalculated = False
        Me.BF_BranchBControl.IsInteger = False
        Me.BF_BranchBControl.Location = New System.Drawing.Point(152, 73)
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
        Me.BF_KostiakovCControl.Location = New System.Drawing.Point(152, 96)
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
        Me.BF_KostiakovAControl.Location = New System.Drawing.Point(152, 50)
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
        'BF_KostiakovBLabel
        '
        Me.BF_KostiakovBLabel.Location = New System.Drawing.Point(120, 73)
        Me.BF_KostiakovBLabel.Name = "BF_KostiakovBLabel"
        Me.BF_KostiakovBLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_KostiakovBLabel.TabIndex = 4
        Me.BF_KostiakovBLabel.Text = "&b"
        Me.BF_KostiakovBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BF_KostiakovCLabel
        '
        Me.BF_KostiakovCLabel.Location = New System.Drawing.Point(120, 96)
        Me.BF_KostiakovCLabel.Name = "BF_KostiakovCLabel"
        Me.BF_KostiakovCLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_KostiakovCLabel.TabIndex = 6
        Me.BF_KostiakovCLabel.Text = "&c"
        Me.BF_KostiakovCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BF_KostiakovALabel
        '
        Me.BF_KostiakovALabel.Location = New System.Drawing.Point(120, 50)
        Me.BF_KostiakovALabel.Name = "BF_KostiakovALabel"
        Me.BF_KostiakovALabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_KostiakovALabel.TabIndex = 2
        Me.BF_KostiakovALabel.Text = "&a"
        Me.BF_KostiakovALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WarrickGreenAmptPanel
        '
        Me.WarrickGreenAmptPanel.AccessibleDescription = "Set of parameters that define the infiltration rate using the Warrick / GreenAmpt" &
    " method."
        Me.WarrickGreenAmptPanel.AccessibleName = "Warrick / Green-Ampt Parameters"
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_GammaControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_GammaLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_SWD)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_ModifiedLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_SoilTextureControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_SoilTextureLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_InstantaneousInfiltrationControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_InstantaneousInfiltrationLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_HydraulicConductivityControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_HydraulicConductivityLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_WettingFrontControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_WettingFrontLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_InitWaterContentControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_InitWaterContentLabel)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_SatWaterContentControl)
        Me.WarrickGreenAmptPanel.Controls.Add(Me.WGA_SatWaterContentLabel)
        Me.WarrickGreenAmptPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WarrickGreenAmptPanel.Location = New System.Drawing.Point(8, 240)
        Me.WarrickGreenAmptPanel.Name = "WarrickGreenAmptPanel"
        Me.WarrickGreenAmptPanel.Size = New System.Drawing.Size(376, 145)
        Me.WarrickGreenAmptPanel.TabIndex = 31
        '
        'WGA_GammaControl
        '
        Me.WGA_GammaControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_GammaControl.IsCalculated = False
        Me.WGA_GammaControl.IsInteger = False
        Me.WGA_GammaControl.Location = New System.Drawing.Point(291, 121)
        Me.WGA_GammaControl.MaxErrMsg = ""
        Me.WGA_GammaControl.MinErrMsg = ""
        Me.WGA_GammaControl.Name = "WGA_GammaControl"
        Me.WGA_GammaControl.Size = New System.Drawing.Size(80, 24)
        Me.WGA_GammaControl.TabIndex = 24
        Me.WGA_GammaControl.ToBeCalculated = True
        Me.WGA_GammaControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_GammaControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_GammaControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_GammaControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_GammaControl.ValueText = ""
        '
        'WGA_GammaLabel
        '
        Me.WGA_GammaLabel.Location = New System.Drawing.Point(216, 123)
        Me.WGA_GammaLabel.Name = "WGA_GammaLabel"
        Me.WGA_GammaLabel.Size = New System.Drawing.Size(70, 21)
        Me.WGA_GammaLabel.TabIndex = 23
        Me.WGA_GammaLabel.Text = "&Gamma"
        Me.WGA_GammaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_SWD
        '
        Me.WGA_SWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_SWD.Location = New System.Drawing.Point(329, 26)
        Me.WGA_SWD.Name = "WGA_SWD"
        Me.WGA_SWD.Size = New System.Drawing.Size(46, 49)
        Me.WGA_SWD.TabIndex = 22
        Me.WGA_SWD.Text = "SWD 0.123 cm/cm"
        Me.WGA_SWD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WGA_ModifiedLabel
        '
        Me.WGA_ModifiedLabel.AutoSize = True
        Me.WGA_ModifiedLabel.Location = New System.Drawing.Point(292, 5)
        Me.WGA_ModifiedLabel.Name = "WGA_ModifiedLabel"
        Me.WGA_ModifiedLabel.Size = New System.Drawing.Size(71, 17)
        Me.WGA_ModifiedLabel.TabIndex = 2
        Me.WGA_ModifiedLabel.Text = "(modified)"
        Me.WGA_ModifiedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WGA_SoilTextureControl
        '
        Me.WGA_SoilTextureControl.AccessibleDescription = "Sets the soil properties from pre-defined soil texture classifications."
        Me.WGA_SoilTextureControl.AccessibleName = "Soil Texture"
        Me.WGA_SoilTextureControl.ApplicationValue = -1
        Me.WGA_SoilTextureControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WGA_SoilTextureControl.EnableSaveActions = False
        Me.WGA_SoilTextureControl.FormattingEnabled = True
        Me.WGA_SoilTextureControl.IsCalculated = False
        Me.WGA_SoilTextureControl.Location = New System.Drawing.Point(157, 2)
        Me.WGA_SoilTextureControl.Name = "WGA_SoilTextureControl"
        Me.WGA_SoilTextureControl.SelectedIndexSet = False
        Me.WGA_SoilTextureControl.Size = New System.Drawing.Size(132, 24)
        Me.WGA_SoilTextureControl.TabIndex = 1
        '
        'WGA_SoilTextureLabel
        '
        Me.WGA_SoilTextureLabel.Location = New System.Drawing.Point(6, 5)
        Me.WGA_SoilTextureLabel.Name = "WGA_SoilTextureLabel"
        Me.WGA_SoilTextureLabel.Size = New System.Drawing.Size(145, 21)
        Me.WGA_SoilTextureLabel.TabIndex = 0
        Me.WGA_SoilTextureLabel.Text = "Soil &Texture"
        Me.WGA_SoilTextureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_InstantaneousInfiltrationControl
        '
        Me.WGA_InstantaneousInfiltrationControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_InstantaneousInfiltrationControl.IsCalculated = False
        Me.WGA_InstantaneousInfiltrationControl.IsInteger = False
        Me.WGA_InstantaneousInfiltrationControl.Location = New System.Drawing.Point(122, 121)
        Me.WGA_InstantaneousInfiltrationControl.MaxErrMsg = ""
        Me.WGA_InstantaneousInfiltrationControl.MinErrMsg = ""
        Me.WGA_InstantaneousInfiltrationControl.Name = "WGA_InstantaneousInfiltrationControl"
        Me.WGA_InstantaneousInfiltrationControl.Size = New System.Drawing.Size(90, 24)
        Me.WGA_InstantaneousInfiltrationControl.TabIndex = 13
        Me.WGA_InstantaneousInfiltrationControl.ToBeCalculated = True
        Me.WGA_InstantaneousInfiltrationControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_InstantaneousInfiltrationControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_InstantaneousInfiltrationControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_InstantaneousInfiltrationControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_InstantaneousInfiltrationControl.ValueText = ""
        '
        'WGA_InstantaneousInfiltrationLabel
        '
        Me.WGA_InstantaneousInfiltrationLabel.Location = New System.Drawing.Point(3, 123)
        Me.WGA_InstantaneousInfiltrationLabel.Name = "WGA_InstantaneousInfiltrationLabel"
        Me.WGA_InstantaneousInfiltrationLabel.Size = New System.Drawing.Size(115, 21)
        Me.WGA_InstantaneousInfiltrationLabel.TabIndex = 12
        Me.WGA_InstantaneousInfiltrationLabel.Text = "&Macropore Inf."
        Me.WGA_InstantaneousInfiltrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_HydraulicConductivityControl
        '
        Me.WGA_HydraulicConductivityControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_HydraulicConductivityControl.IsCalculated = False
        Me.WGA_HydraulicConductivityControl.IsInteger = False
        Me.WGA_HydraulicConductivityControl.Location = New System.Drawing.Point(223, 97)
        Me.WGA_HydraulicConductivityControl.MaxErrMsg = ""
        Me.WGA_HydraulicConductivityControl.MinErrMsg = ""
        Me.WGA_HydraulicConductivityControl.Name = "WGA_HydraulicConductivityControl"
        Me.WGA_HydraulicConductivityControl.Size = New System.Drawing.Size(124, 24)
        Me.WGA_HydraulicConductivityControl.TabIndex = 11
        Me.WGA_HydraulicConductivityControl.ToBeCalculated = True
        Me.WGA_HydraulicConductivityControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_HydraulicConductivityControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_HydraulicConductivityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_HydraulicConductivityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_HydraulicConductivityControl.ValueText = ""
        '
        'WGA_HydraulicConductivityLabel
        '
        Me.WGA_HydraulicConductivityLabel.Location = New System.Drawing.Point(3, 100)
        Me.WGA_HydraulicConductivityLabel.Name = "WGA_HydraulicConductivityLabel"
        Me.WGA_HydraulicConductivityLabel.Size = New System.Drawing.Size(215, 21)
        Me.WGA_HydraulicConductivityLabel.TabIndex = 10
        Me.WGA_HydraulicConductivityLabel.Text = "Hydraulic Conductivity, &Ks"
        Me.WGA_HydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_WettingFrontControl
        '
        Me.WGA_WettingFrontControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_WettingFrontControl.IsCalculated = False
        Me.WGA_WettingFrontControl.IsInteger = False
        Me.WGA_WettingFrontControl.Location = New System.Drawing.Point(223, 74)
        Me.WGA_WettingFrontControl.MaxErrMsg = ""
        Me.WGA_WettingFrontControl.MinErrMsg = ""
        Me.WGA_WettingFrontControl.Name = "WGA_WettingFrontControl"
        Me.WGA_WettingFrontControl.Size = New System.Drawing.Size(124, 24)
        Me.WGA_WettingFrontControl.TabIndex = 9
        Me.WGA_WettingFrontControl.ToBeCalculated = True
        Me.WGA_WettingFrontControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_WettingFrontControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_WettingFrontControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_WettingFrontControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_WettingFrontControl.ValueText = ""
        '
        'WGA_WettingFrontLabel
        '
        Me.WGA_WettingFrontLabel.Location = New System.Drawing.Point(3, 77)
        Me.WGA_WettingFrontLabel.Name = "WGA_WettingFrontLabel"
        Me.WGA_WettingFrontLabel.Size = New System.Drawing.Size(215, 21)
        Me.WGA_WettingFrontLabel.TabIndex = 8
        Me.WGA_WettingFrontLabel.Text = "Wetting Front Pressure Head, &hf"
        Me.WGA_WettingFrontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_InitWaterContentControl
        '
        Me.WGA_InitWaterContentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_InitWaterContentControl.IsCalculated = False
        Me.WGA_InitWaterContentControl.IsInteger = False
        Me.WGA_InitWaterContentControl.Location = New System.Drawing.Point(223, 51)
        Me.WGA_InitWaterContentControl.MaxErrMsg = ""
        Me.WGA_InitWaterContentControl.MinErrMsg = ""
        Me.WGA_InitWaterContentControl.Name = "WGA_InitWaterContentControl"
        Me.WGA_InitWaterContentControl.Size = New System.Drawing.Size(120, 24)
        Me.WGA_InitWaterContentControl.TabIndex = 7
        Me.WGA_InitWaterContentControl.ToBeCalculated = True
        Me.WGA_InitWaterContentControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_InitWaterContentControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_InitWaterContentControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_InitWaterContentControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_InitWaterContentControl.ValueText = ""
        '
        'WGA_InitWaterContentLabel
        '
        Me.WGA_InitWaterContentLabel.Location = New System.Drawing.Point(3, 54)
        Me.WGA_InitWaterContentLabel.Name = "WGA_InitWaterContentLabel"
        Me.WGA_InitWaterContentLabel.Size = New System.Drawing.Size(215, 21)
        Me.WGA_InitWaterContentLabel.TabIndex = 6
        Me.WGA_InitWaterContentLabel.Text = "Initial Water Content, Theta&0"
        Me.WGA_InitWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_SatWaterContentControl
        '
        Me.WGA_SatWaterContentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_SatWaterContentControl.IsCalculated = False
        Me.WGA_SatWaterContentControl.IsInteger = False
        Me.WGA_SatWaterContentControl.Location = New System.Drawing.Point(223, 28)
        Me.WGA_SatWaterContentControl.MaxErrMsg = ""
        Me.WGA_SatWaterContentControl.MinErrMsg = ""
        Me.WGA_SatWaterContentControl.Name = "WGA_SatWaterContentControl"
        Me.WGA_SatWaterContentControl.Size = New System.Drawing.Size(120, 24)
        Me.WGA_SatWaterContentControl.TabIndex = 5
        Me.WGA_SatWaterContentControl.ToBeCalculated = True
        Me.WGA_SatWaterContentControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_SatWaterContentControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_SatWaterContentControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_SatWaterContentControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_SatWaterContentControl.ValueText = ""
        '
        'WGA_SatWaterContentLabel
        '
        Me.WGA_SatWaterContentLabel.Location = New System.Drawing.Point(3, 31)
        Me.WGA_SatWaterContentLabel.Name = "WGA_SatWaterContentLabel"
        Me.WGA_SatWaterContentLabel.Size = New System.Drawing.Size(215, 21)
        Me.WGA_SatWaterContentLabel.TabIndex = 4
        Me.WGA_SatWaterContentLabel.Text = "Sat. Water Content, Theta&S"
        Me.WGA_SatWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InfiltrationFunctionPanel
        '
        Me.InfiltrationFunctionPanel.Controls.Add(Me.WettedPerimeterLabel)
        Me.InfiltrationFunctionPanel.Controls.Add(Me.WettedPerimeterControl)
        Me.InfiltrationFunctionPanel.Controls.Add(Me.RefInflowPanel)
        Me.InfiltrationFunctionPanel.Controls.Add(Me.InfiltrationEquationControl)
        Me.InfiltrationFunctionPanel.Controls.Add(Me.InfiltrationEquationLabel)
        Me.InfiltrationFunctionPanel.Location = New System.Drawing.Point(5, 155)
        Me.InfiltrationFunctionPanel.Name = "InfiltrationFunctionPanel"
        Me.InfiltrationFunctionPanel.Size = New System.Drawing.Size(380, 90)
        Me.InfiltrationFunctionPanel.TabIndex = 1
        '
        'WettedPerimeterLabel
        '
        Me.WettedPerimeterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WettedPerimeterLabel.Location = New System.Drawing.Point(1, 6)
        Me.WettedPerimeterLabel.Name = "WettedPerimeterLabel"
        Me.WettedPerimeterLabel.Size = New System.Drawing.Size(134, 23)
        Me.WettedPerimeterLabel.TabIndex = 0
        Me.WettedPerimeterLabel.Text = "&Wetted Perimeter"
        Me.WettedPerimeterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WettedPerimeterControl
        '
        Me.WettedPerimeterControl.AccessibleDescription = "Selects the method for describing the wetted perimeter."
        Me.WettedPerimeterControl.AccessibleName = "Wetted Perimeter"
        Me.WettedPerimeterControl.ApplicationValue = -1
        Me.WettedPerimeterControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WettedPerimeterControl.EnableSaveActions = True
        Me.WettedPerimeterControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WettedPerimeterControl.IsCalculated = False
        Me.WettedPerimeterControl.Location = New System.Drawing.Point(142, 6)
        Me.WettedPerimeterControl.Name = "WettedPerimeterControl"
        Me.WettedPerimeterControl.SelectedIndexSet = False
        Me.WettedPerimeterControl.Size = New System.Drawing.Size(238, 24)
        Me.WettedPerimeterControl.TabIndex = 1
        '
        'RefInflowPanel
        '
        Me.RefInflowPanel.AccessibleDescription = ""
        Me.RefInflowPanel.AccessibleName = ""
        Me.RefInflowPanel.Controls.Add(Me.RefInflowRateControl)
        Me.RefInflowPanel.Controls.Add(Me.RefInflowDesc)
        Me.RefInflowPanel.Controls.Add(Me.RefInflowRateSelect)
        Me.RefInflowPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowPanel.Location = New System.Drawing.Point(1, 60)
        Me.RefInflowPanel.Name = "RefInflowPanel"
        Me.RefInflowPanel.Size = New System.Drawing.Size(380, 30)
        Me.RefInflowPanel.TabIndex = 4
        '
        'RefInflowRateControl
        '
        Me.RefInflowRateControl.AccessibleDescription = "Specifies the reference inflow rate."
        Me.RefInflowRateControl.AccessibleName = "Reference Inflow Rate"
        Me.RefInflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RefInflowRateControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowRateControl.IsCalculated = False
        Me.RefInflowRateControl.IsInteger = False
        Me.RefInflowRateControl.Location = New System.Drawing.Point(141, 3)
        Me.RefInflowRateControl.MaxErrMsg = ""
        Me.RefInflowRateControl.MinErrMsg = ""
        Me.RefInflowRateControl.Name = "RefInflowRateControl"
        Me.RefInflowRateControl.Size = New System.Drawing.Size(104, 24)
        Me.RefInflowRateControl.TabIndex = 1
        Me.RefInflowRateControl.ToBeCalculated = True
        Me.RefInflowRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.RefInflowRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.RefInflowRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.RefInflowRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.RefInflowRateControl.ValueText = ""
        '
        'RefInflowDesc
        '
        Me.RefInflowDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowDesc.Location = New System.Drawing.Point(206, 3)
        Me.RefInflowDesc.Name = "RefInflowDesc"
        Me.RefInflowDesc.Size = New System.Drawing.Size(170, 23)
        Me.RefInflowDesc.TabIndex = 2
        Me.RefInflowDesc.Text = "Not set (default)"
        Me.RefInflowDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RefInflowRateSelect
        '
        Me.RefInflowRateSelect.AccessibleDescription = "Selects whether there is reference inflow rate."
        Me.RefInflowRateSelect.AccessibleName = "Reference Inflow Rate"
        Me.RefInflowRateSelect.AlwaysChecked = False
        Me.RefInflowRateSelect.ErrorMessage = Nothing
        Me.RefInflowRateSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowRateSelect.Location = New System.Drawing.Point(2, 3)
        Me.RefInflowRateSelect.Name = "RefInflowRateSelect"
        Me.RefInflowRateSelect.Size = New System.Drawing.Size(136, 24)
        Me.RefInflowRateSelect.TabIndex = 0
        Me.RefInflowRateSelect.Text = "Re&f. Inflow Rate"
        Me.RefInflowRateSelect.UncheckAttemptMessage = Nothing
        '
        'InfiltrationEquationControl
        '
        Me.InfiltrationEquationControl.AccessibleDescription = "Selects the Infiltration Function for entering the infiltration parameters.  The " &
    "Dialogs tab under User Preferences controls operation when a new method is selec" &
    "ted."
        Me.InfiltrationEquationControl.AccessibleName = "Infiltration Function"
        Me.InfiltrationEquationControl.ApplicationValue = -1
        Me.InfiltrationEquationControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InfiltrationEquationControl.EnableSaveActions = False
        Me.InfiltrationEquationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationEquationControl.IsCalculated = False
        Me.InfiltrationEquationControl.Location = New System.Drawing.Point(142, 33)
        Me.InfiltrationEquationControl.Name = "InfiltrationEquationControl"
        Me.InfiltrationEquationControl.SelectedIndexSet = False
        Me.InfiltrationEquationControl.Size = New System.Drawing.Size(238, 24)
        Me.InfiltrationEquationControl.TabIndex = 3
        '
        'InfiltrationEquationLabel
        '
        Me.InfiltrationEquationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationEquationLabel.Location = New System.Drawing.Point(1, 32)
        Me.InfiltrationEquationLabel.Name = "InfiltrationEquationLabel"
        Me.InfiltrationEquationLabel.Size = New System.Drawing.Size(134, 23)
        Me.InfiltrationEquationLabel.TabIndex = 2
        Me.InfiltrationEquationLabel.Text = "&Infiltration Equation"
        Me.InfiltrationEquationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UseInfiltrationEditorButton
        '
        Me.UseInfiltrationEditorButton.AccessibleDescription = "Displays editor to match infiltration parameters."
        Me.UseInfiltrationEditorButton.AccessibleName = "Match Parameters"
        Me.UseInfiltrationEditorButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.UseInfiltrationEditorButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseInfiltrationEditorButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.UseInfiltrationEditorButton.Location = New System.Drawing.Point(6, 386)
        Me.UseInfiltrationEditorButton.Name = "UseInfiltrationEditorButton"
        Me.UseInfiltrationEditorButton.Size = New System.Drawing.Size(66, 24)
        Me.UseInfiltrationEditorButton.TabIndex = 36
        Me.UseInfiltrationEditorButton.Text = "&Editor..."
        Me.UseInfiltrationEditorButton.UseVisualStyleBackColor = False
        '
        'GreenAmptPanel
        '
        Me.GreenAmptPanel.AccessibleDescription = "Set of parameters that define the infiltration rate using the GreenAmpt method."
        Me.GreenAmptPanel.AccessibleName = "Green-Ampt Parameters"
        Me.GreenAmptPanel.Controls.Add(Me.GA_SWD)
        Me.GreenAmptPanel.Controls.Add(Me.GA_InstantaneousInfiltrationControl)
        Me.GreenAmptPanel.Controls.Add(Me.GA_InstantaneousInfiltrationLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_ModifiedLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_SoilTextureControl)
        Me.GreenAmptPanel.Controls.Add(Me.GA_SoilTextureLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_HydraulicConductivityControl)
        Me.GreenAmptPanel.Controls.Add(Me.GA_HydraulicConductivityLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_WettingFrontControl)
        Me.GreenAmptPanel.Controls.Add(Me.GA_WettingFrontLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_InitVolWaterContentControl)
        Me.GreenAmptPanel.Controls.Add(Me.GA_InitVolWaterContentLabel)
        Me.GreenAmptPanel.Controls.Add(Me.GA_SatWaterContentControl)
        Me.GreenAmptPanel.Controls.Add(Me.GA_SatWaterContentLabel)
        Me.GreenAmptPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GreenAmptPanel.Location = New System.Drawing.Point(8, 240)
        Me.GreenAmptPanel.Name = "GreenAmptPanel"
        Me.GreenAmptPanel.Size = New System.Drawing.Size(376, 145)
        Me.GreenAmptPanel.TabIndex = 28
        '
        'GA_SWD
        '
        Me.GA_SWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_SWD.Location = New System.Drawing.Point(329, 26)
        Me.GA_SWD.Name = "GA_SWD"
        Me.GA_SWD.Size = New System.Drawing.Size(46, 49)
        Me.GA_SWD.TabIndex = 21
        Me.GA_SWD.Text = "SWD 0.123 cm/cm"
        Me.GA_SWD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GA_InstantaneousInfiltrationControl
        '
        Me.GA_InstantaneousInfiltrationControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_InstantaneousInfiltrationControl.IsCalculated = False
        Me.GA_InstantaneousInfiltrationControl.IsInteger = False
        Me.GA_InstantaneousInfiltrationControl.Location = New System.Drawing.Point(223, 120)
        Me.GA_InstantaneousInfiltrationControl.MaxErrMsg = ""
        Me.GA_InstantaneousInfiltrationControl.MinErrMsg = ""
        Me.GA_InstantaneousInfiltrationControl.Name = "GA_InstantaneousInfiltrationControl"
        Me.GA_InstantaneousInfiltrationControl.Size = New System.Drawing.Size(124, 24)
        Me.GA_InstantaneousInfiltrationControl.TabIndex = 13
        Me.GA_InstantaneousInfiltrationControl.ToBeCalculated = True
        Me.GA_InstantaneousInfiltrationControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_InstantaneousInfiltrationControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_InstantaneousInfiltrationControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_InstantaneousInfiltrationControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_InstantaneousInfiltrationControl.ValueText = ""
        '
        'GA_InstantaneousInfiltrationLabel
        '
        Me.GA_InstantaneousInfiltrationLabel.Location = New System.Drawing.Point(3, 123)
        Me.GA_InstantaneousInfiltrationLabel.Name = "GA_InstantaneousInfiltrationLabel"
        Me.GA_InstantaneousInfiltrationLabel.Size = New System.Drawing.Size(215, 21)
        Me.GA_InstantaneousInfiltrationLabel.TabIndex = 12
        Me.GA_InstantaneousInfiltrationLabel.Text = "&Macropore Infiltration"
        Me.GA_InstantaneousInfiltrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_ModifiedLabel
        '
        Me.GA_ModifiedLabel.AutoSize = True
        Me.GA_ModifiedLabel.Location = New System.Drawing.Point(288, 6)
        Me.GA_ModifiedLabel.Name = "GA_ModifiedLabel"
        Me.GA_ModifiedLabel.Size = New System.Drawing.Size(71, 17)
        Me.GA_ModifiedLabel.TabIndex = 2
        Me.GA_ModifiedLabel.Text = "(modified)"
        Me.GA_ModifiedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GA_SoilTextureControl
        '
        Me.GA_SoilTextureControl.AccessibleDescription = "Sets the soil properties from pre-defined soil texture classifications."
        Me.GA_SoilTextureControl.AccessibleName = "Soil Texture"
        Me.GA_SoilTextureControl.ApplicationValue = -1
        Me.GA_SoilTextureControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GA_SoilTextureControl.EnableSaveActions = False
        Me.GA_SoilTextureControl.FormattingEnabled = True
        Me.GA_SoilTextureControl.IsCalculated = False
        Me.GA_SoilTextureControl.Location = New System.Drawing.Point(154, 3)
        Me.GA_SoilTextureControl.Name = "GA_SoilTextureControl"
        Me.GA_SoilTextureControl.SelectedIndexSet = False
        Me.GA_SoilTextureControl.Size = New System.Drawing.Size(132, 24)
        Me.GA_SoilTextureControl.TabIndex = 1
        '
        'GA_SoilTextureLabel
        '
        Me.GA_SoilTextureLabel.Location = New System.Drawing.Point(3, 6)
        Me.GA_SoilTextureLabel.Name = "GA_SoilTextureLabel"
        Me.GA_SoilTextureLabel.Size = New System.Drawing.Size(145, 21)
        Me.GA_SoilTextureLabel.TabIndex = 0
        Me.GA_SoilTextureLabel.Text = "Soil &Texture"
        Me.GA_SoilTextureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_HydraulicConductivityControl
        '
        Me.GA_HydraulicConductivityControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_HydraulicConductivityControl.IsCalculated = False
        Me.GA_HydraulicConductivityControl.IsInteger = False
        Me.GA_HydraulicConductivityControl.Location = New System.Drawing.Point(223, 97)
        Me.GA_HydraulicConductivityControl.MaxErrMsg = ""
        Me.GA_HydraulicConductivityControl.MinErrMsg = ""
        Me.GA_HydraulicConductivityControl.Name = "GA_HydraulicConductivityControl"
        Me.GA_HydraulicConductivityControl.Size = New System.Drawing.Size(124, 24)
        Me.GA_HydraulicConductivityControl.TabIndex = 11
        Me.GA_HydraulicConductivityControl.ToBeCalculated = True
        Me.GA_HydraulicConductivityControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_HydraulicConductivityControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_HydraulicConductivityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_HydraulicConductivityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_HydraulicConductivityControl.ValueText = ""
        '
        'GA_HydraulicConductivityLabel
        '
        Me.GA_HydraulicConductivityLabel.Location = New System.Drawing.Point(3, 100)
        Me.GA_HydraulicConductivityLabel.Name = "GA_HydraulicConductivityLabel"
        Me.GA_HydraulicConductivityLabel.Size = New System.Drawing.Size(215, 21)
        Me.GA_HydraulicConductivityLabel.TabIndex = 10
        Me.GA_HydraulicConductivityLabel.Text = "Hydraulic Conductivity, &Ks"
        Me.GA_HydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_WettingFrontControl
        '
        Me.GA_WettingFrontControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_WettingFrontControl.IsCalculated = False
        Me.GA_WettingFrontControl.IsInteger = False
        Me.GA_WettingFrontControl.Location = New System.Drawing.Point(223, 74)
        Me.GA_WettingFrontControl.MaxErrMsg = ""
        Me.GA_WettingFrontControl.MinErrMsg = ""
        Me.GA_WettingFrontControl.Name = "GA_WettingFrontControl"
        Me.GA_WettingFrontControl.Size = New System.Drawing.Size(124, 24)
        Me.GA_WettingFrontControl.TabIndex = 9
        Me.GA_WettingFrontControl.ToBeCalculated = True
        Me.GA_WettingFrontControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_WettingFrontControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_WettingFrontControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_WettingFrontControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_WettingFrontControl.ValueText = ""
        '
        'GA_WettingFrontLabel
        '
        Me.GA_WettingFrontLabel.Location = New System.Drawing.Point(3, 77)
        Me.GA_WettingFrontLabel.Name = "GA_WettingFrontLabel"
        Me.GA_WettingFrontLabel.Size = New System.Drawing.Size(215, 21)
        Me.GA_WettingFrontLabel.TabIndex = 8
        Me.GA_WettingFrontLabel.Text = "Wetting Front Pressure Head, &hf"
        Me.GA_WettingFrontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_InitVolWaterContentControl
        '
        Me.GA_InitVolWaterContentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_InitVolWaterContentControl.IsCalculated = False
        Me.GA_InitVolWaterContentControl.IsInteger = False
        Me.GA_InitVolWaterContentControl.Location = New System.Drawing.Point(223, 51)
        Me.GA_InitVolWaterContentControl.MaxErrMsg = ""
        Me.GA_InitVolWaterContentControl.MinErrMsg = ""
        Me.GA_InitVolWaterContentControl.Name = "GA_InitVolWaterContentControl"
        Me.GA_InitVolWaterContentControl.Size = New System.Drawing.Size(120, 24)
        Me.GA_InitVolWaterContentControl.TabIndex = 7
        Me.GA_InitVolWaterContentControl.ToBeCalculated = True
        Me.GA_InitVolWaterContentControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_InitVolWaterContentControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_InitVolWaterContentControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_InitVolWaterContentControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_InitVolWaterContentControl.ValueText = ""
        '
        'GA_InitVolWaterContentLabel
        '
        Me.GA_InitVolWaterContentLabel.Location = New System.Drawing.Point(3, 54)
        Me.GA_InitVolWaterContentLabel.Name = "GA_InitVolWaterContentLabel"
        Me.GA_InitVolWaterContentLabel.Size = New System.Drawing.Size(215, 21)
        Me.GA_InitVolWaterContentLabel.TabIndex = 6
        Me.GA_InitVolWaterContentLabel.Text = "Initial Water Content, Theta&0"
        Me.GA_InitVolWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_SatWaterContentControl
        '
        Me.GA_SatWaterContentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_SatWaterContentControl.IsCalculated = False
        Me.GA_SatWaterContentControl.IsInteger = False
        Me.GA_SatWaterContentControl.Location = New System.Drawing.Point(223, 28)
        Me.GA_SatWaterContentControl.MaxErrMsg = ""
        Me.GA_SatWaterContentControl.MinErrMsg = ""
        Me.GA_SatWaterContentControl.Name = "GA_SatWaterContentControl"
        Me.GA_SatWaterContentControl.Size = New System.Drawing.Size(120, 24)
        Me.GA_SatWaterContentControl.TabIndex = 5
        Me.GA_SatWaterContentControl.ToBeCalculated = True
        Me.GA_SatWaterContentControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_SatWaterContentControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_SatWaterContentControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_SatWaterContentControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_SatWaterContentControl.ValueText = ""
        '
        'GA_SatWaterContentLabel
        '
        Me.GA_SatWaterContentLabel.Location = New System.Drawing.Point(3, 31)
        Me.GA_SatWaterContentLabel.Name = "GA_SatWaterContentLabel"
        Me.GA_SatWaterContentLabel.Size = New System.Drawing.Size(215, 21)
        Me.GA_SatWaterContentLabel.TabIndex = 4
        Me.GA_SatWaterContentLabel.Text = "Sat. Water Content, Theta&S"
        Me.GA_SatWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TimeRatedIntakePanel
        '
        Me.TimeRatedIntakePanel.AccessibleDescription = resources.GetString("TimeRatedIntakePanel.AccessibleDescription")
        Me.TimeRatedIntakePanel.AccessibleName = "Time Rated Intake Parameters"
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_InfiltrationDepthControl)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_KostiakovA)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_KostiakovK)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_InfiltrationTimeControl)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_InfiltrationTimeLabel)
        Me.TimeRatedIntakePanel.Controls.Add(Me.TR_InfiltrationDepthLabel)
        Me.TimeRatedIntakePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeRatedIntakePanel.Location = New System.Drawing.Point(8, 240)
        Me.TimeRatedIntakePanel.Name = "TimeRatedIntakePanel"
        Me.TimeRatedIntakePanel.Size = New System.Drawing.Size(376, 145)
        Me.TimeRatedIntakePanel.TabIndex = 7
        '
        'TR_InfiltrationDepthControl
        '
        Me.TR_InfiltrationDepthControl.AccessibleDescription = "Depth is fixed at 100mm (3.94in) for the Time Rated Intake Family Method."
        Me.TR_InfiltrationDepthControl.AccessibleName = "Characteristic Infiltration Depth"
        Me.TR_InfiltrationDepthControl.Location = New System.Drawing.Point(247, 48)
        Me.TR_InfiltrationDepthControl.Name = "TR_InfiltrationDepthControl"
        Me.TR_InfiltrationDepthControl.Size = New System.Drawing.Size(128, 23)
        Me.TR_InfiltrationDepthControl.TabIndex = 1
        Me.TR_InfiltrationDepthControl.Text = "100 mm"
        Me.TR_InfiltrationDepthControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_KostiakovA
        '
        Me.TR_KostiakovA.AccessibleDescription = "Exponent (a) in the formula:  Zn = k * (T ^ a).  Here, Kostiakov a is calculated " &
    "by WinSRFR based on the Characteristic Infiltration Time (T)."
        Me.TR_KostiakovA.AccessibleName = "Kostiakov a"
        Me.TR_KostiakovA.Location = New System.Drawing.Point(224, 8)
        Me.TR_KostiakovA.Name = "TR_KostiakovA"
        Me.TR_KostiakovA.Size = New System.Drawing.Size(136, 23)
        Me.TR_KostiakovA.TabIndex = 5
        Me.TR_KostiakovA.Text = "a = "
        Me.TR_KostiakovA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_KostiakovK
        '
        Me.TR_KostiakovK.AccessibleDescription = "Coefficient (k) in the formula:  Zn = k * (T ^ a).  In this case, k is calculated" &
    " by WinSRFR."
        Me.TR_KostiakovK.AccessibleName = "k"
        Me.TR_KostiakovK.Location = New System.Drawing.Point(24, 8)
        Me.TR_KostiakovK.Name = "TR_KostiakovK"
        Me.TR_KostiakovK.Size = New System.Drawing.Size(200, 23)
        Me.TR_KostiakovK.TabIndex = 4
        Me.TR_KostiakovK.Text = "k = "
        Me.TR_KostiakovK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_InfiltrationTimeControl
        '
        Me.TR_InfiltrationTimeControl.AccessibleDescription = "Specifies the time required for water to infiltrate to the Characteristic Infiltr" &
    "ation Depth."
        Me.TR_InfiltrationTimeControl.AccessibleName = "Characteristic Infiltration Time"
        Me.TR_InfiltrationTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.TR_InfiltrationTimeControl.IsCalculated = False
        Me.TR_InfiltrationTimeControl.IsInteger = False
        Me.TR_InfiltrationTimeControl.Location = New System.Drawing.Point(247, 72)
        Me.TR_InfiltrationTimeControl.MaxErrMsg = ""
        Me.TR_InfiltrationTimeControl.MinErrMsg = ""
        Me.TR_InfiltrationTimeControl.Name = "TR_InfiltrationTimeControl"
        Me.TR_InfiltrationTimeControl.Size = New System.Drawing.Size(128, 24)
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
        Me.TR_InfiltrationTimeLabel.Location = New System.Drawing.Point(3, 72)
        Me.TR_InfiltrationTimeLabel.Name = "TR_InfiltrationTimeLabel"
        Me.TR_InfiltrationTimeLabel.Size = New System.Drawing.Size(236, 23)
        Me.TR_InfiltrationTimeLabel.TabIndex = 2
        Me.TR_InfiltrationTimeLabel.Text = "Characteristic Infiltration &Time"
        Me.TR_InfiltrationTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TR_InfiltrationDepthLabel
        '
        Me.TR_InfiltrationDepthLabel.Location = New System.Drawing.Point(3, 48)
        Me.TR_InfiltrationDepthLabel.Name = "TR_InfiltrationDepthLabel"
        Me.TR_InfiltrationDepthLabel.Size = New System.Drawing.Size(236, 23)
        Me.TR_InfiltrationDepthLabel.TabIndex = 0
        Me.TR_InfiltrationDepthLabel.Text = "Characteristic Infiltration Depth"
        Me.TR_InfiltrationDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabulatedWarrickGreenAmptPanel
        '
        Me.TabulatedWarrickGreenAmptPanel.Controls.Add(Me.TabulatedWarrickGreenAmptControl)
        Me.TabulatedWarrickGreenAmptPanel.Location = New System.Drawing.Point(8, 240)
        Me.TabulatedWarrickGreenAmptPanel.Name = "TabulatedWarrickGreenAmptPanel"
        Me.TabulatedWarrickGreenAmptPanel.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedWarrickGreenAmptPanel.TabIndex = 32
        '
        'TabulatedWarrickGreenAmptControl
        '
        Me.TabulatedWarrickGreenAmptControl.AccessibleDescription = "Parameters that define the infiltration rate for the Warrick / Green-Ampt method." &
    ""
        Me.TabulatedWarrickGreenAmptControl.AccessibleName = "Tabulated Warrick / Green-Ampt Parameters"
        Me.TabulatedWarrickGreenAmptControl.AllRowsFixed = False
        Me.TabulatedWarrickGreenAmptControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedWarrickGreenAmptControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedWarrickGreenAmptControl.CaptionText = "Infiltration Table"
        Me.TabulatedWarrickGreenAmptControl.CausesValidation = False
        Me.TabulatedWarrickGreenAmptControl.ColumnWidthRatios = Nothing
        Me.TabulatedWarrickGreenAmptControl.DataMember = ""
        Me.TabulatedWarrickGreenAmptControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedWarrickGreenAmptControl.EnableSaveActions = False
        Me.TabulatedWarrickGreenAmptControl.FirstColumnIncreases = True
        Me.TabulatedWarrickGreenAmptControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedWarrickGreenAmptControl.FirstColumnMinimum = 0R
        Me.TabulatedWarrickGreenAmptControl.FirstRowFixed = True
        Me.TabulatedWarrickGreenAmptControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedWarrickGreenAmptControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedWarrickGreenAmptControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedWarrickGreenAmptControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedWarrickGreenAmptControl.MaxRows = 50
        Me.TabulatedWarrickGreenAmptControl.MinRows = 0
        Me.TabulatedWarrickGreenAmptControl.Name = "TabulatedWarrickGreenAmptControl"
        Me.TabulatedWarrickGreenAmptControl.PasteDisabled = False
        Me.TabulatedWarrickGreenAmptControl.SecondColumnIncreases = False
        Me.TabulatedWarrickGreenAmptControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedWarrickGreenAmptControl.SecondColumnMinimum = 0R
        Me.TabulatedWarrickGreenAmptControl.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedWarrickGreenAmptControl.TabIndex = 0
        Me.TabulatedWarrickGreenAmptControl.TableReadonly = False
        '
        'TabulatedBranchPanel
        '
        Me.TabulatedBranchPanel.Controls.Add(Me.TabulatedBranchFunctionControl)
        Me.TabulatedBranchPanel.Location = New System.Drawing.Point(8, 240)
        Me.TabulatedBranchPanel.Name = "TabulatedBranchPanel"
        Me.TabulatedBranchPanel.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedBranchPanel.TabIndex = 24
        '
        'TabulatedBranchFunctionControl
        '
        Me.TabulatedBranchFunctionControl.AccessibleDescription = "Parameters that define the infiltration rate for the Branch Function method."
        Me.TabulatedBranchFunctionControl.AccessibleName = "Tabulated Branch Function Infiltration"
        Me.TabulatedBranchFunctionControl.AllRowsFixed = False
        Me.TabulatedBranchFunctionControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedBranchFunctionControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedBranchFunctionControl.CaptionText = "Infiltration Table"
        Me.TabulatedBranchFunctionControl.CausesValidation = False
        Me.TabulatedBranchFunctionControl.ColumnWidthRatios = Nothing
        Me.TabulatedBranchFunctionControl.DataMember = ""
        Me.TabulatedBranchFunctionControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedBranchFunctionControl.EnableSaveActions = False
        Me.TabulatedBranchFunctionControl.FirstColumnIncreases = True
        Me.TabulatedBranchFunctionControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedBranchFunctionControl.FirstColumnMinimum = 0R
        Me.TabulatedBranchFunctionControl.FirstRowFixed = True
        Me.TabulatedBranchFunctionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedBranchFunctionControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedBranchFunctionControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedBranchFunctionControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedBranchFunctionControl.MaxRows = 50
        Me.TabulatedBranchFunctionControl.MinRows = 1
        Me.TabulatedBranchFunctionControl.Name = "TabulatedBranchFunctionControl"
        Me.TabulatedBranchFunctionControl.PasteDisabled = False
        Me.TabulatedBranchFunctionControl.SecondColumnIncreases = False
        Me.TabulatedBranchFunctionControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedBranchFunctionControl.SecondColumnMinimum = 0R
        Me.TabulatedBranchFunctionControl.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedBranchFunctionControl.TabIndex = 0
        Me.TabulatedBranchFunctionControl.TableReadonly = False
        '
        'TabulatedGreenAmptPanel
        '
        Me.TabulatedGreenAmptPanel.Controls.Add(Me.TabulatedGreenAmptControl)
        Me.TabulatedGreenAmptPanel.Location = New System.Drawing.Point(8, 240)
        Me.TabulatedGreenAmptPanel.Name = "TabulatedGreenAmptPanel"
        Me.TabulatedGreenAmptPanel.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedGreenAmptPanel.TabIndex = 29
        '
        'TabulatedGreenAmptControl
        '
        Me.TabulatedGreenAmptControl.AccessibleDescription = "Parameters that define the infiltration rate for the Green-Ampt method."
        Me.TabulatedGreenAmptControl.AccessibleName = "Tabulated Green-Ampt Parameters"
        Me.TabulatedGreenAmptControl.AllRowsFixed = False
        Me.TabulatedGreenAmptControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedGreenAmptControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedGreenAmptControl.CaptionText = "Infiltration Table"
        Me.TabulatedGreenAmptControl.CausesValidation = False
        Me.TabulatedGreenAmptControl.ColumnWidthRatios = Nothing
        Me.TabulatedGreenAmptControl.DataMember = ""
        Me.TabulatedGreenAmptControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedGreenAmptControl.EnableSaveActions = False
        Me.TabulatedGreenAmptControl.FirstColumnIncreases = True
        Me.TabulatedGreenAmptControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedGreenAmptControl.FirstColumnMinimum = 0R
        Me.TabulatedGreenAmptControl.FirstRowFixed = True
        Me.TabulatedGreenAmptControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedGreenAmptControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedGreenAmptControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedGreenAmptControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedGreenAmptControl.MaxRows = 50
        Me.TabulatedGreenAmptControl.MinRows = 0
        Me.TabulatedGreenAmptControl.Name = "TabulatedGreenAmptControl"
        Me.TabulatedGreenAmptControl.PasteDisabled = False
        Me.TabulatedGreenAmptControl.SecondColumnIncreases = False
        Me.TabulatedGreenAmptControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedGreenAmptControl.SecondColumnMinimum = 0R
        Me.TabulatedGreenAmptControl.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedGreenAmptControl.TabIndex = 0
        Me.TabulatedGreenAmptControl.TableReadonly = False
        '
        'TabulatedHydrusPanel
        '
        Me.TabulatedHydrusPanel.Controls.Add(Me.TabulatedHydrusControl)
        Me.TabulatedHydrusPanel.Location = New System.Drawing.Point(8, 240)
        Me.TabulatedHydrusPanel.Name = "TabulatedHydrusPanel"
        Me.TabulatedHydrusPanel.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedHydrusPanel.TabIndex = 29
        '
        'TabulatedHydrusControl
        '
        Me.TabulatedHydrusControl.AccessibleDescription = "Parameters that define the infiltration rate for the HYDRUS method."
        Me.TabulatedHydrusControl.AccessibleName = "Tabulated HYDRUS Parameters"
        Me.TabulatedHydrusControl.AllRowsFixed = False
        Me.TabulatedHydrusControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedHydrusControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedHydrusControl.CaptionText = "HYDRUS Project Table"
        Me.TabulatedHydrusControl.CausesValidation = False
        Me.TabulatedHydrusControl.ColumnWidthRatios = Nothing
        Me.TabulatedHydrusControl.DataMember = ""
        Me.TabulatedHydrusControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedHydrusControl.EnableSaveActions = False
        Me.TabulatedHydrusControl.FirstColumnIncreases = True
        Me.TabulatedHydrusControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedHydrusControl.FirstColumnMinimum = 0R
        Me.TabulatedHydrusControl.FirstRowFixed = True
        Me.TabulatedHydrusControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedHydrusControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedHydrusControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedHydrusControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedHydrusControl.MaxRows = 50
        Me.TabulatedHydrusControl.MinRows = 0
        Me.TabulatedHydrusControl.Name = "TabulatedHydrusControl"
        Me.TabulatedHydrusControl.PasteDisabled = False
        Me.TabulatedHydrusControl.SecondColumnIncreases = False
        Me.TabulatedHydrusControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedHydrusControl.SecondColumnMinimum = 0R
        Me.TabulatedHydrusControl.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedHydrusControl.TabIndex = 0
        Me.TabulatedHydrusControl.TableReadonly = False
        '
        'InfiltrationGraphics
        '
        Me.InfiltrationGraphics.AccessibleDescription = "Graph of infiltration depth vs. time."
        Me.InfiltrationGraphics.AccessibleName = "Infiltration Graph"
        Me.InfiltrationGraphics.BackColor = System.Drawing.SystemColors.Control
        Me.InfiltrationGraphics.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationGraphics.Location = New System.Drawing.Point(8, 24)
        Me.InfiltrationGraphics.Name = "InfiltrationGraphics"
        Me.InfiltrationGraphics.Size = New System.Drawing.Size(376, 128)
        Me.InfiltrationGraphics.TabIndex = 20
        Me.InfiltrationGraphics.TabStop = False
        Me.InfiltrationGraphics.Text = "Bitmap Diagram"
        '
        'TabulatedNrcsIntakePanel
        '
        Me.TabulatedNrcsIntakePanel.Controls.Add(Me.TabulatedNrcsIntakeControl)
        Me.TabulatedNrcsIntakePanel.Location = New System.Drawing.Point(8, 240)
        Me.TabulatedNrcsIntakePanel.Name = "TabulatedNrcsIntakePanel"
        Me.TabulatedNrcsIntakePanel.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedNrcsIntakePanel.TabIndex = 25
        '
        'TabulatedNrcsIntakeControl
        '
        Me.TabulatedNrcsIntakeControl.AccessibleDescription = "Parameters that define the infiltration rate for the NRCS Intake Families method." &
    ""
        Me.TabulatedNrcsIntakeControl.AccessibleName = "Tabulated NRCS Intake Families"
        Me.TabulatedNrcsIntakeControl.AllRowsFixed = False
        Me.TabulatedNrcsIntakeControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedNrcsIntakeControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedNrcsIntakeControl.CaptionText = "Infiltration Table"
        Me.TabulatedNrcsIntakeControl.CausesValidation = False
        Me.TabulatedNrcsIntakeControl.ColumnWidthRatios = Nothing
        Me.TabulatedNrcsIntakeControl.DataMember = ""
        Me.TabulatedNrcsIntakeControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedNrcsIntakeControl.EnableSaveActions = False
        Me.TabulatedNrcsIntakeControl.FirstColumnIncreases = True
        Me.TabulatedNrcsIntakeControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedNrcsIntakeControl.FirstColumnMinimum = 0R
        Me.TabulatedNrcsIntakeControl.FirstRowFixed = True
        Me.TabulatedNrcsIntakeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedNrcsIntakeControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedNrcsIntakeControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedNrcsIntakeControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedNrcsIntakeControl.MaxRows = 50
        Me.TabulatedNrcsIntakeControl.MinRows = 1
        Me.TabulatedNrcsIntakeControl.Name = "TabulatedNrcsIntakeControl"
        Me.TabulatedNrcsIntakeControl.PasteDisabled = False
        Me.TabulatedNrcsIntakeControl.SecondColumnIncreases = False
        Me.TabulatedNrcsIntakeControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedNrcsIntakeControl.SecondColumnMinimum = 0R
        Me.TabulatedNrcsIntakeControl.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedNrcsIntakeControl.TabIndex = 0
        Me.TabulatedNrcsIntakeControl.TableReadonly = False
        '
        'TabulatedTimeRatedPanel
        '
        Me.TabulatedTimeRatedPanel.Controls.Add(Me.TabulatedTimeRatedControl)
        Me.TabulatedTimeRatedPanel.Location = New System.Drawing.Point(8, 240)
        Me.TabulatedTimeRatedPanel.Name = "TabulatedTimeRatedPanel"
        Me.TabulatedTimeRatedPanel.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedTimeRatedPanel.TabIndex = 27
        '
        'TabulatedTimeRatedControl
        '
        Me.TabulatedTimeRatedControl.AccessibleDescription = "Parameters that define the infiltration rate for the Time Rated Families method."
        Me.TabulatedTimeRatedControl.AccessibleName = "Tabulated Time Rated Infiltration Families"
        Me.TabulatedTimeRatedControl.AllRowsFixed = False
        Me.TabulatedTimeRatedControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedTimeRatedControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedTimeRatedControl.CaptionText = "Infiltration Table"
        Me.TabulatedTimeRatedControl.CausesValidation = False
        Me.TabulatedTimeRatedControl.ColumnWidthRatios = Nothing
        Me.TabulatedTimeRatedControl.DataMember = ""
        Me.TabulatedTimeRatedControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedTimeRatedControl.EnableSaveActions = False
        Me.TabulatedTimeRatedControl.FirstColumnIncreases = True
        Me.TabulatedTimeRatedControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedTimeRatedControl.FirstColumnMinimum = 0R
        Me.TabulatedTimeRatedControl.FirstRowFixed = True
        Me.TabulatedTimeRatedControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedTimeRatedControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedTimeRatedControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedTimeRatedControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedTimeRatedControl.MaxRows = 50
        Me.TabulatedTimeRatedControl.MinRows = 1
        Me.TabulatedTimeRatedControl.Name = "TabulatedTimeRatedControl"
        Me.TabulatedTimeRatedControl.PasteDisabled = False
        Me.TabulatedTimeRatedControl.SecondColumnIncreases = False
        Me.TabulatedTimeRatedControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedTimeRatedControl.SecondColumnMinimum = 0R
        Me.TabulatedTimeRatedControl.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedTimeRatedControl.TabIndex = 0
        Me.TabulatedTimeRatedControl.TableReadonly = False
        '
        'TabulatedCharacteristicTimePanel
        '
        Me.TabulatedCharacteristicTimePanel.Controls.Add(Me.TabulatedCharacteristicTimeControl)
        Me.TabulatedCharacteristicTimePanel.Location = New System.Drawing.Point(8, 240)
        Me.TabulatedCharacteristicTimePanel.Name = "TabulatedCharacteristicTimePanel"
        Me.TabulatedCharacteristicTimePanel.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedCharacteristicTimePanel.TabIndex = 26
        '
        'TabulatedCharacteristicTimeControl
        '
        Me.TabulatedCharacteristicTimeControl.AccessibleDescription = "Parameters that define the infiltration rate for the Characteristic Time method."
        Me.TabulatedCharacteristicTimeControl.AccessibleName = "Tabulated Characteristic Time Infiltration"
        Me.TabulatedCharacteristicTimeControl.AllRowsFixed = False
        Me.TabulatedCharacteristicTimeControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedCharacteristicTimeControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedCharacteristicTimeControl.CaptionText = "Infiltration Table"
        Me.TabulatedCharacteristicTimeControl.CausesValidation = False
        Me.TabulatedCharacteristicTimeControl.ColumnWidthRatios = Nothing
        Me.TabulatedCharacteristicTimeControl.DataMember = ""
        Me.TabulatedCharacteristicTimeControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedCharacteristicTimeControl.EnableSaveActions = False
        Me.TabulatedCharacteristicTimeControl.FirstColumnIncreases = True
        Me.TabulatedCharacteristicTimeControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedCharacteristicTimeControl.FirstColumnMinimum = 0R
        Me.TabulatedCharacteristicTimeControl.FirstRowFixed = True
        Me.TabulatedCharacteristicTimeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedCharacteristicTimeControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedCharacteristicTimeControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedCharacteristicTimeControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedCharacteristicTimeControl.MaxRows = 50
        Me.TabulatedCharacteristicTimeControl.MinRows = 1
        Me.TabulatedCharacteristicTimeControl.Name = "TabulatedCharacteristicTimeControl"
        Me.TabulatedCharacteristicTimeControl.PasteDisabled = False
        Me.TabulatedCharacteristicTimeControl.SecondColumnIncreases = False
        Me.TabulatedCharacteristicTimeControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedCharacteristicTimeControl.SecondColumnMinimum = 0R
        Me.TabulatedCharacteristicTimeControl.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedCharacteristicTimeControl.TabIndex = 0
        Me.TabulatedCharacteristicTimeControl.TableReadonly = False
        '
        'TabulatedKostiakovPanel
        '
        Me.TabulatedKostiakovPanel.Controls.Add(Me.TabulatedKostiakovControl)
        Me.TabulatedKostiakovPanel.Location = New System.Drawing.Point(8, 240)
        Me.TabulatedKostiakovPanel.Name = "TabulatedKostiakovPanel"
        Me.TabulatedKostiakovPanel.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedKostiakovPanel.TabIndex = 22
        '
        'TabulatedKostiakovControl
        '
        Me.TabulatedKostiakovControl.AccessibleDescription = "Parameters that define the infiltration rate for the Kostiakov Formula method."
        Me.TabulatedKostiakovControl.AccessibleName = "Tabulated Kostiakov Formula Infiltration"
        Me.TabulatedKostiakovControl.AllRowsFixed = False
        Me.TabulatedKostiakovControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedKostiakovControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedKostiakovControl.CaptionText = "Infiltration Table"
        Me.TabulatedKostiakovControl.CausesValidation = False
        Me.TabulatedKostiakovControl.ColumnWidthRatios = Nothing
        Me.TabulatedKostiakovControl.DataMember = ""
        Me.TabulatedKostiakovControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedKostiakovControl.EnableSaveActions = False
        Me.TabulatedKostiakovControl.FirstColumnIncreases = True
        Me.TabulatedKostiakovControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedKostiakovControl.FirstColumnMinimum = 0R
        Me.TabulatedKostiakovControl.FirstRowFixed = True
        Me.TabulatedKostiakovControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedKostiakovControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedKostiakovControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedKostiakovControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedKostiakovControl.MaxRows = 50
        Me.TabulatedKostiakovControl.MinRows = 1
        Me.TabulatedKostiakovControl.Name = "TabulatedKostiakovControl"
        Me.TabulatedKostiakovControl.PasteDisabled = False
        Me.TabulatedKostiakovControl.SecondColumnIncreases = False
        Me.TabulatedKostiakovControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedKostiakovControl.SecondColumnMinimum = 0R
        Me.TabulatedKostiakovControl.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedKostiakovControl.TabIndex = 0
        Me.TabulatedKostiakovControl.TableReadonly = False
        '
        'TabulatedModifiedKostiakovPanel
        '
        Me.TabulatedModifiedKostiakovPanel.Controls.Add(Me.TabulatedModifiedKostiakovControl)
        Me.TabulatedModifiedKostiakovPanel.Location = New System.Drawing.Point(8, 240)
        Me.TabulatedModifiedKostiakovPanel.Name = "TabulatedModifiedKostiakovPanel"
        Me.TabulatedModifiedKostiakovPanel.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedModifiedKostiakovPanel.TabIndex = 23
        '
        'TabulatedModifiedKostiakovControl
        '
        Me.TabulatedModifiedKostiakovControl.AccessibleDescription = "Parameters that define the infiltration rate for the Modified Kostiakov method."
        Me.TabulatedModifiedKostiakovControl.AccessibleName = "Tabulated Modified Kostiakov Infiltration"
        Me.TabulatedModifiedKostiakovControl.AllRowsFixed = False
        Me.TabulatedModifiedKostiakovControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedModifiedKostiakovControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedModifiedKostiakovControl.CaptionText = "Infiltration Table"
        Me.TabulatedModifiedKostiakovControl.CausesValidation = False
        Me.TabulatedModifiedKostiakovControl.ColumnWidthRatios = Nothing
        Me.TabulatedModifiedKostiakovControl.DataMember = ""
        Me.TabulatedModifiedKostiakovControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabulatedModifiedKostiakovControl.EnableSaveActions = False
        Me.TabulatedModifiedKostiakovControl.FirstColumnIncreases = True
        Me.TabulatedModifiedKostiakovControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedModifiedKostiakovControl.FirstColumnMinimum = 0R
        Me.TabulatedModifiedKostiakovControl.FirstRowFixed = True
        Me.TabulatedModifiedKostiakovControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedModifiedKostiakovControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedModifiedKostiakovControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedModifiedKostiakovControl.Location = New System.Drawing.Point(0, 0)
        Me.TabulatedModifiedKostiakovControl.MaxRows = 50
        Me.TabulatedModifiedKostiakovControl.MinRows = 1
        Me.TabulatedModifiedKostiakovControl.Name = "TabulatedModifiedKostiakovControl"
        Me.TabulatedModifiedKostiakovControl.PasteDisabled = False
        Me.TabulatedModifiedKostiakovControl.SecondColumnIncreases = False
        Me.TabulatedModifiedKostiakovControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.TabulatedModifiedKostiakovControl.SecondColumnMinimum = 0R
        Me.TabulatedModifiedKostiakovControl.Size = New System.Drawing.Size(376, 170)
        Me.TabulatedModifiedKostiakovControl.TabIndex = 0
        Me.TabulatedModifiedKostiakovControl.TableReadonly = False
        '
        'NrcsIntakePanel
        '
        Me.NrcsIntakePanel.AccessibleDescription = "Radio buttons to select the infiltration rate from an NRCS Intake Family."
        Me.NrcsIntakePanel.AccessibleName = "NRCS Intake Parameters"
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsC)
        Me.NrcsIntakePanel.Controls.Add(Me.NrcsOptionsButton)
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
        Me.NrcsIntakePanel.Location = New System.Drawing.Point(8, 240)
        Me.NrcsIntakePanel.Name = "NrcsIntakePanel"
        Me.NrcsIntakePanel.Size = New System.Drawing.Size(376, 145)
        Me.NrcsIntakePanel.TabIndex = 7
        '
        'NrcsC
        '
        Me.NrcsC.Location = New System.Drawing.Point(288, 2)
        Me.NrcsC.Name = "NrcsC"
        Me.NrcsC.Size = New System.Drawing.Size(72, 23)
        Me.NrcsC.TabIndex = 22
        Me.NrcsC.Text = "c = "
        Me.NrcsC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsOptionsButton
        '
        Me.NrcsOptionsButton.AccessibleDescription = "Press to edit the options associated with the NRCS Intake Family selection."
        Me.NrcsOptionsButton.AccessibleName = "NRCS Options Button"
        Me.NrcsOptionsButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.NrcsOptionsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.NrcsOptionsButton.Location = New System.Drawing.Point(272, 119)
        Me.NrcsOptionsButton.Name = "NrcsOptionsButton"
        Me.NrcsOptionsButton.Size = New System.Drawing.Size(96, 23)
        Me.NrcsOptionsButton.TabIndex = 21
        Me.NrcsOptionsButton.Text = "&Options ..."
        Me.NrcsOptionsButton.UseVisualStyleBackColor = False
        '
        'NrcsA
        '
        Me.NrcsA.Location = New System.Drawing.Point(192, 2)
        Me.NrcsA.Name = "NrcsA"
        Me.NrcsA.Size = New System.Drawing.Size(72, 23)
        Me.NrcsA.TabIndex = 20
        Me.NrcsA.Text = "a = "
        Me.NrcsA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsK
        '
        Me.NrcsK.Location = New System.Drawing.Point(24, 2)
        Me.NrcsK.Name = "NrcsK"
        Me.NrcsK.Size = New System.Drawing.Size(152, 23)
        Me.NrcsK.TabIndex = 19
        Me.NrcsK.Text = "k = "
        Me.NrcsK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Sel_400
        '
        Me.Sel_400.Location = New System.Drawing.Point(288, 96)
        Me.Sel_400.Name = "Sel_400"
        Me.Sel_400.Size = New System.Drawing.Size(64, 24)
        Me.Sel_400.TabIndex = 18
        Me.Sel_400.Text = "4.00"
        '
        'Sel_300
        '
        Me.Sel_300.Location = New System.Drawing.Point(288, 73)
        Me.Sel_300.Name = "Sel_300"
        Me.Sel_300.Size = New System.Drawing.Size(64, 24)
        Me.Sel_300.TabIndex = 17
        Me.Sel_300.Text = "3.00"
        '
        'Sel_090
        '
        Me.Sel_090.Location = New System.Drawing.Point(192, 96)
        Me.Sel_090.Name = "Sel_090"
        Me.Sel_090.Size = New System.Drawing.Size(64, 24)
        Me.Sel_090.TabIndex = 13
        Me.Sel_090.Text = "0.90"
        '
        'Sel_200
        '
        Me.Sel_200.Location = New System.Drawing.Point(288, 50)
        Me.Sel_200.Name = "Sel_200"
        Me.Sel_200.Size = New System.Drawing.Size(64, 24)
        Me.Sel_200.TabIndex = 16
        Me.Sel_200.Text = "2.00"
        '
        'Sel_150
        '
        Me.Sel_150.Location = New System.Drawing.Point(288, 27)
        Me.Sel_150.Name = "Sel_150"
        Me.Sel_150.Size = New System.Drawing.Size(64, 24)
        Me.Sel_150.TabIndex = 15
        Me.Sel_150.Text = "1.50"
        '
        'Sel_100
        '
        Me.Sel_100.Location = New System.Drawing.Point(192, 119)
        Me.Sel_100.Name = "Sel_100"
        Me.Sel_100.Size = New System.Drawing.Size(64, 24)
        Me.Sel_100.TabIndex = 14
        Me.Sel_100.Text = "1.00"
        '
        'Sel_080
        '
        Me.Sel_080.Location = New System.Drawing.Point(192, 73)
        Me.Sel_080.Name = "Sel_080"
        Me.Sel_080.Size = New System.Drawing.Size(64, 24)
        Me.Sel_080.TabIndex = 12
        Me.Sel_080.Text = "0.80"
        '
        'Sel_070
        '
        Me.Sel_070.Location = New System.Drawing.Point(192, 50)
        Me.Sel_070.Name = "Sel_070"
        Me.Sel_070.Size = New System.Drawing.Size(64, 24)
        Me.Sel_070.TabIndex = 11
        Me.Sel_070.Text = "0.70"
        '
        'Sel_060
        '
        Me.Sel_060.Location = New System.Drawing.Point(192, 27)
        Me.Sel_060.Name = "Sel_060"
        Me.Sel_060.Size = New System.Drawing.Size(64, 24)
        Me.Sel_060.TabIndex = 10
        Me.Sel_060.Text = "0.60"
        '
        'Sel_050
        '
        Me.Sel_050.Location = New System.Drawing.Point(96, 119)
        Me.Sel_050.Name = "Sel_050"
        Me.Sel_050.Size = New System.Drawing.Size(64, 24)
        Me.Sel_050.TabIndex = 9
        Me.Sel_050.Text = "0.50"
        '
        'Sel_045
        '
        Me.Sel_045.Location = New System.Drawing.Point(96, 96)
        Me.Sel_045.Name = "Sel_045"
        Me.Sel_045.Size = New System.Drawing.Size(64, 24)
        Me.Sel_045.TabIndex = 8
        Me.Sel_045.Text = "0.45"
        '
        'Sel_040
        '
        Me.Sel_040.Location = New System.Drawing.Point(96, 73)
        Me.Sel_040.Name = "Sel_040"
        Me.Sel_040.Size = New System.Drawing.Size(64, 24)
        Me.Sel_040.TabIndex = 7
        Me.Sel_040.Text = "0.40"
        '
        'Sel_035
        '
        Me.Sel_035.Location = New System.Drawing.Point(96, 50)
        Me.Sel_035.Name = "Sel_035"
        Me.Sel_035.Size = New System.Drawing.Size(64, 24)
        Me.Sel_035.TabIndex = 6
        Me.Sel_035.Text = "0.35"
        '
        'Sel_030
        '
        Me.Sel_030.Location = New System.Drawing.Point(96, 27)
        Me.Sel_030.Name = "Sel_030"
        Me.Sel_030.Size = New System.Drawing.Size(64, 24)
        Me.Sel_030.TabIndex = 5
        Me.Sel_030.Text = "0.30"
        '
        'Sel_025
        '
        Me.Sel_025.Location = New System.Drawing.Point(24, 119)
        Me.Sel_025.Name = "Sel_025"
        Me.Sel_025.Size = New System.Drawing.Size(64, 24)
        Me.Sel_025.TabIndex = 4
        Me.Sel_025.Text = "0.25"
        '
        'Sel_020
        '
        Me.Sel_020.Location = New System.Drawing.Point(24, 96)
        Me.Sel_020.Name = "Sel_020"
        Me.Sel_020.Size = New System.Drawing.Size(64, 24)
        Me.Sel_020.TabIndex = 3
        Me.Sel_020.Text = "0.20"
        '
        'Sel_015
        '
        Me.Sel_015.Location = New System.Drawing.Point(24, 73)
        Me.Sel_015.Name = "Sel_015"
        Me.Sel_015.Size = New System.Drawing.Size(64, 24)
        Me.Sel_015.TabIndex = 2
        Me.Sel_015.Text = "0.15"
        '
        'Sel_010
        '
        Me.Sel_010.Location = New System.Drawing.Point(24, 50)
        Me.Sel_010.Name = "Sel_010"
        Me.Sel_010.Size = New System.Drawing.Size(64, 24)
        Me.Sel_010.TabIndex = 1
        Me.Sel_010.Text = "0.10"
        '
        'Sel_005
        '
        Me.Sel_005.Location = New System.Drawing.Point(24, 27)
        Me.Sel_005.Name = "Sel_005"
        Me.Sel_005.Size = New System.Drawing.Size(64, 24)
        Me.Sel_005.TabIndex = 0
        Me.Sel_005.Text = "0.05"
        '
        'ModifiedKostiakovPanel
        '
        Me.ModifiedKostiakovPanel.AccessibleDescription = "Set of parameters that define the infiltration rate using the Modified Kostiakov " &
    "Formula."
        Me.ModifiedKostiakovPanel.AccessibleName = "Modified Kostiakov Parameters"
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovBControl)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovKControl)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.ModifiedKostiakovFormula)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovAControl)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovCControl)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovALabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovKLabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovCLabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.MK_KostiakovBLabel)
        Me.ModifiedKostiakovPanel.Controls.Add(Me.KostiakovCOptionControl)
        Me.ModifiedKostiakovPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModifiedKostiakovPanel.Location = New System.Drawing.Point(8, 240)
        Me.ModifiedKostiakovPanel.Name = "ModifiedKostiakovPanel"
        Me.ModifiedKostiakovPanel.Size = New System.Drawing.Size(376, 145)
        Me.ModifiedKostiakovPanel.TabIndex = 7
        '
        'MK_KostiakovBControl
        '
        Me.MK_KostiakovBControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_KostiakovBControl.IsCalculated = False
        Me.MK_KostiakovBControl.IsInteger = False
        Me.MK_KostiakovBControl.Location = New System.Drawing.Point(152, 91)
        Me.MK_KostiakovBControl.MaxErrMsg = ""
        Me.MK_KostiakovBControl.MinErrMsg = ""
        Me.MK_KostiakovBControl.Name = "MK_KostiakovBControl"
        Me.MK_KostiakovBControl.Size = New System.Drawing.Size(160, 24)
        Me.MK_KostiakovBControl.TabIndex = 5
        Me.MK_KostiakovBControl.ToBeCalculated = True
        Me.MK_KostiakovBControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_KostiakovBControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_KostiakovBControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_KostiakovBControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_KostiakovBControl.ValueText = ""
        '
        'MK_KostiakovKControl
        '
        Me.MK_KostiakovKControl.Location = New System.Drawing.Point(152, 43)
        Me.MK_KostiakovKControl.Name = "MK_KostiakovKControl"
        Me.MK_KostiakovKControl.Size = New System.Drawing.Size(160, 24)
        Me.MK_KostiakovKControl.TabIndex = 1
        Me.MK_KostiakovKControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_KostiakovKControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_KostiakovKControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_KostiakovKControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_KostiakovKControl.ValueText = ""
        '
        'ModifiedKostiakovFormula
        '
        Me.ModifiedKostiakovFormula.AccessibleDescription = "Zn = k * T^a + (b * T) + c"
        Me.ModifiedKostiakovFormula.AccessibleName = "Modified Kostiakov Formula"
        Me.ModifiedKostiakovFormula.Location = New System.Drawing.Point(24, 8)
        Me.ModifiedKostiakovFormula.Name = "ModifiedKostiakovFormula"
        Me.ModifiedKostiakovFormula.Size = New System.Drawing.Size(336, 23)
        Me.ModifiedKostiakovFormula.TabIndex = 10
        Me.ModifiedKostiakovFormula.Text = "Zn = k * T^a + (b * T) + c"
        Me.ModifiedKostiakovFormula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MK_KostiakovAControl
        '
        Me.MK_KostiakovAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_KostiakovAControl.IsCalculated = False
        Me.MK_KostiakovAControl.IsInteger = False
        Me.MK_KostiakovAControl.Location = New System.Drawing.Point(152, 67)
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
        'MK_KostiakovCControl
        '
        Me.MK_KostiakovCControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_KostiakovCControl.IsCalculated = False
        Me.MK_KostiakovCControl.IsInteger = False
        Me.MK_KostiakovCControl.Location = New System.Drawing.Point(152, 115)
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
        'MK_KostiakovALabel
        '
        Me.MK_KostiakovALabel.Location = New System.Drawing.Point(120, 67)
        Me.MK_KostiakovALabel.Name = "MK_KostiakovALabel"
        Me.MK_KostiakovALabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_KostiakovALabel.TabIndex = 2
        Me.MK_KostiakovALabel.Text = "&a"
        Me.MK_KostiakovALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MK_KostiakovKLabel
        '
        Me.MK_KostiakovKLabel.Location = New System.Drawing.Point(120, 43)
        Me.MK_KostiakovKLabel.Name = "MK_KostiakovKLabel"
        Me.MK_KostiakovKLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_KostiakovKLabel.TabIndex = 0
        Me.MK_KostiakovKLabel.Text = "&k"
        Me.MK_KostiakovKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MK_KostiakovCLabel
        '
        Me.MK_KostiakovCLabel.Location = New System.Drawing.Point(120, 115)
        Me.MK_KostiakovCLabel.Name = "MK_KostiakovCLabel"
        Me.MK_KostiakovCLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_KostiakovCLabel.TabIndex = 6
        Me.MK_KostiakovCLabel.Text = "&c"
        Me.MK_KostiakovCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MK_KostiakovBLabel
        '
        Me.MK_KostiakovBLabel.Location = New System.Drawing.Point(120, 91)
        Me.MK_KostiakovBLabel.Name = "MK_KostiakovBLabel"
        Me.MK_KostiakovBLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_KostiakovBLabel.TabIndex = 4
        Me.MK_KostiakovBLabel.Text = "&b"
        Me.MK_KostiakovBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KostiakovCOptionControl
        '
        Me.KostiakovCOptionControl.AlwaysChecked = False
        Me.KostiakovCOptionControl.ErrorMessage = Nothing
        Me.KostiakovCOptionControl.Location = New System.Drawing.Point(6, 117)
        Me.KostiakovCOptionControl.Name = "KostiakovCOptionControl"
        Me.KostiakovCOptionControl.Size = New System.Drawing.Size(112, 23)
        Me.KostiakovCOptionControl.TabIndex = 8
        Me.KostiakovCOptionControl.Text = "Time Offset"
        Me.KostiakovCOptionControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.KostiakovCOptionControl.UncheckAttemptMessage = Nothing
        Me.KostiakovCOptionControl.UseVisualStyleBackColor = True
        '
        'KostiakovPanel
        '
        Me.KostiakovPanel.AccessibleDescription = "Set of parameters that define the infiltration rate using the Kostiakov Formula."
        Me.KostiakovPanel.AccessibleName = "Kostiakov Formula Parameters"
        Me.KostiakovPanel.Controls.Add(Me.KF_KostiakovKControl)
        Me.KostiakovPanel.Controls.Add(Me.KostiakovFormula)
        Me.KostiakovPanel.Controls.Add(Me.KF_KostiakovAControl)
        Me.KostiakovPanel.Controls.Add(Me.KF_KostiakovALabel)
        Me.KostiakovPanel.Controls.Add(Me.KF_KostiakovKLabel)
        Me.KostiakovPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostiakovPanel.Location = New System.Drawing.Point(8, 240)
        Me.KostiakovPanel.Name = "KostiakovPanel"
        Me.KostiakovPanel.Size = New System.Drawing.Size(376, 145)
        Me.KostiakovPanel.TabIndex = 7
        '
        'KF_KostiakovKControl
        '
        Me.KF_KostiakovKControl.Location = New System.Drawing.Point(152, 48)
        Me.KF_KostiakovKControl.Name = "KF_KostiakovKControl"
        Me.KF_KostiakovKControl.Size = New System.Drawing.Size(160, 24)
        Me.KF_KostiakovKControl.TabIndex = 1
        Me.KF_KostiakovKControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KF_KostiakovKControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KF_KostiakovKControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KF_KostiakovKControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KF_KostiakovKControl.ValueText = ""
        '
        'KostiakovFormula
        '
        Me.KostiakovFormula.AccessibleDescription = "Zn = k * T^a"
        Me.KostiakovFormula.AccessibleName = "Kostiakov Formula"
        Me.KostiakovFormula.Location = New System.Drawing.Point(24, 8)
        Me.KostiakovFormula.Name = "KostiakovFormula"
        Me.KostiakovFormula.Size = New System.Drawing.Size(336, 23)
        Me.KostiakovFormula.TabIndex = 4
        Me.KostiakovFormula.Text = "Zn = k * T^a"
        Me.KostiakovFormula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KF_KostiakovAControl
        '
        Me.KF_KostiakovAControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KF_KostiakovAControl.IsCalculated = False
        Me.KF_KostiakovAControl.IsInteger = False
        Me.KF_KostiakovAControl.Location = New System.Drawing.Point(152, 72)
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
        'KF_KostiakovALabel
        '
        Me.KF_KostiakovALabel.Location = New System.Drawing.Point(120, 72)
        Me.KF_KostiakovALabel.Name = "KF_KostiakovALabel"
        Me.KF_KostiakovALabel.Size = New System.Drawing.Size(24, 23)
        Me.KF_KostiakovALabel.TabIndex = 2
        Me.KF_KostiakovALabel.Text = "&a"
        Me.KF_KostiakovALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KF_KostiakovKLabel
        '
        Me.KF_KostiakovKLabel.Location = New System.Drawing.Point(120, 48)
        Me.KF_KostiakovKLabel.Name = "KF_KostiakovKLabel"
        Me.KF_KostiakovKLabel.Size = New System.Drawing.Size(24, 23)
        Me.KF_KostiakovKLabel.TabIndex = 0
        Me.KF_KostiakovKLabel.Text = "&k"
        Me.KF_KostiakovKLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CharacteristicInfiltrationPanel
        '
        Me.CharacteristicInfiltrationPanel.AccessibleDescription = "Set of parameters that define the infiltration rate using the Characteristic Infi" &
    "ltration Time method."
        Me.CharacteristicInfiltrationPanel.AccessibleName = "Characteristic Infiltration Time Parameters"
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_KostiakovK)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_InfiltrationTimeControl)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_KostiakovAControl)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_InfiltrationDepthControl)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_InfiltrationTimeLabel)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_KostiakovALabel)
        Me.CharacteristicInfiltrationPanel.Controls.Add(Me.KT_InfiltrationDepthLabel)
        Me.CharacteristicInfiltrationPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CharacteristicInfiltrationPanel.Location = New System.Drawing.Point(8, 240)
        Me.CharacteristicInfiltrationPanel.Name = "CharacteristicInfiltrationPanel"
        Me.CharacteristicInfiltrationPanel.Size = New System.Drawing.Size(376, 145)
        Me.CharacteristicInfiltrationPanel.TabIndex = 7
        '
        'KT_KostiakovK
        '
        Me.KT_KostiakovK.Location = New System.Drawing.Point(200, 8)
        Me.KT_KostiakovK.Name = "KT_KostiakovK"
        Me.KT_KostiakovK.Size = New System.Drawing.Size(160, 23)
        Me.KT_KostiakovK.TabIndex = 6
        Me.KT_KostiakovK.Text = "k = "
        Me.KT_KostiakovK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KT_InfiltrationTimeControl
        '
        Me.KT_InfiltrationTimeControl.AccessibleDescription = "Specifies the time necessary to infiltrate to the Characteristic Infiltration Dep" &
    "th."
        Me.KT_InfiltrationTimeControl.AccessibleName = "Characteristic Infiltration Time"
        Me.KT_InfiltrationTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KT_InfiltrationTimeControl.IsCalculated = False
        Me.KT_InfiltrationTimeControl.IsInteger = False
        Me.KT_InfiltrationTimeControl.Location = New System.Drawing.Point(247, 72)
        Me.KT_InfiltrationTimeControl.MaxErrMsg = ""
        Me.KT_InfiltrationTimeControl.MinErrMsg = ""
        Me.KT_InfiltrationTimeControl.Name = "KT_InfiltrationTimeControl"
        Me.KT_InfiltrationTimeControl.Size = New System.Drawing.Size(126, 24)
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
        Me.KT_KostiakovAControl.Location = New System.Drawing.Point(247, 96)
        Me.KT_KostiakovAControl.MaxErrMsg = ""
        Me.KT_KostiakovAControl.MinErrMsg = ""
        Me.KT_KostiakovAControl.Name = "KT_KostiakovAControl"
        Me.KT_KostiakovAControl.Size = New System.Drawing.Size(126, 24)
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
        Me.KT_InfiltrationDepthControl.AccessibleDescription = "Specifies the depth infiltrated in the Characteristic Infiltration Time."
        Me.KT_InfiltrationDepthControl.AccessibleName = "Characteristic Infiltration Depth"
        Me.KT_InfiltrationDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KT_InfiltrationDepthControl.IsCalculated = False
        Me.KT_InfiltrationDepthControl.IsInteger = False
        Me.KT_InfiltrationDepthControl.Location = New System.Drawing.Point(247, 48)
        Me.KT_InfiltrationDepthControl.MaxErrMsg = ""
        Me.KT_InfiltrationDepthControl.MinErrMsg = ""
        Me.KT_InfiltrationDepthControl.Name = "KT_InfiltrationDepthControl"
        Me.KT_InfiltrationDepthControl.Size = New System.Drawing.Size(126, 24)
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
        Me.KT_InfiltrationTimeLabel.Size = New System.Drawing.Size(236, 23)
        Me.KT_InfiltrationTimeLabel.TabIndex = 2
        Me.KT_InfiltrationTimeLabel.Text = "Characteristic Infiltration &Time"
        Me.KT_InfiltrationTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KT_KostiakovALabel
        '
        Me.KT_KostiakovALabel.Location = New System.Drawing.Point(3, 96)
        Me.KT_KostiakovALabel.Name = "KT_KostiakovALabel"
        Me.KT_KostiakovALabel.Size = New System.Drawing.Size(236, 23)
        Me.KT_KostiakovALabel.TabIndex = 4
        Me.KT_KostiakovALabel.Text = "&a"
        Me.KT_KostiakovALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KT_InfiltrationDepthLabel
        '
        Me.KT_InfiltrationDepthLabel.Location = New System.Drawing.Point(3, 48)
        Me.KT_InfiltrationDepthLabel.Name = "KT_InfiltrationDepthLabel"
        Me.KT_InfiltrationDepthLabel.Size = New System.Drawing.Size(236, 23)
        Me.KT_InfiltrationDepthLabel.TabIndex = 0
        Me.KT_InfiltrationDepthLabel.Text = "Characteristic Infiltration &Depth"
        Me.KT_InfiltrationDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SimOptsPanel
        '
        Me.SimOptsPanel.AccessibleDescription = ""
        Me.SimOptsPanel.AccessibleName = ""
        Me.SimOptsPanel.Controls.Add(Me.LimitingDepthControl)
        Me.SimOptsPanel.Controls.Add(Me.TabulatedInfiltrationSelect)
        Me.SimOptsPanel.Controls.Add(Me.LimitingDepthSelect)
        Me.SimOptsPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimOptsPanel.Location = New System.Drawing.Point(5, 411)
        Me.SimOptsPanel.Name = "SimOptsPanel"
        Me.SimOptsPanel.Size = New System.Drawing.Size(380, 30)
        Me.SimOptsPanel.TabIndex = 37
        '
        'LimitingDepthControl
        '
        Me.LimitingDepthControl.AccessibleDescription = "Specifies the limit to the infiltrated depth."
        Me.LimitingDepthControl.AccessibleName = "Limiting Depth"
        Me.LimitingDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.LimitingDepthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LimitingDepthControl.IsCalculated = False
        Me.LimitingDepthControl.IsInteger = False
        Me.LimitingDepthControl.Location = New System.Drawing.Point(179, 5)
        Me.LimitingDepthControl.MaxErrMsg = ""
        Me.LimitingDepthControl.MinErrMsg = ""
        Me.LimitingDepthControl.Name = "LimitingDepthControl"
        Me.LimitingDepthControl.Size = New System.Drawing.Size(104, 24)
        Me.LimitingDepthControl.TabIndex = 8
        Me.LimitingDepthControl.ToBeCalculated = True
        Me.LimitingDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.LimitingDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.LimitingDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.LimitingDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.LimitingDepthControl.ValueText = ""
        '
        'TabulatedInfiltrationSelect
        '
        Me.TabulatedInfiltrationSelect.AccessibleDescription = "Selects whether the infiltration parameters varies by distance down the field."
        Me.TabulatedInfiltrationSelect.AccessibleName = "Tabulated"
        Me.TabulatedInfiltrationSelect.AlwaysChecked = False
        Me.TabulatedInfiltrationSelect.ErrorMessage = Nothing
        Me.TabulatedInfiltrationSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedInfiltrationSelect.Location = New System.Drawing.Point(289, 5)
        Me.TabulatedInfiltrationSelect.Name = "TabulatedInfiltrationSelect"
        Me.TabulatedInfiltrationSelect.Size = New System.Drawing.Size(91, 24)
        Me.TabulatedInfiltrationSelect.TabIndex = 9
        Me.TabulatedInfiltrationSelect.Text = "Tab&ulated"
        Me.TabulatedInfiltrationSelect.UncheckAttemptMessage = Nothing
        Me.TabulatedInfiltrationSelect.Visible = False
        '
        'LimitingDepthSelect
        '
        Me.LimitingDepthSelect.AccessibleDescription = "Selects whether there is a physical limit to the infiltration depth."
        Me.LimitingDepthSelect.AccessibleName = "Limiting Depth"
        Me.LimitingDepthSelect.AlwaysChecked = False
        Me.LimitingDepthSelect.ErrorMessage = Nothing
        Me.LimitingDepthSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LimitingDepthSelect.Location = New System.Drawing.Point(81, 5)
        Me.LimitingDepthSelect.Name = "LimitingDepthSelect"
        Me.LimitingDepthSelect.Size = New System.Drawing.Size(100, 24)
        Me.LimitingDepthSelect.TabIndex = 7
        Me.LimitingDepthSelect.Text = "Lim. &Depth"
        Me.LimitingDepthSelect.UncheckAttemptMessage = Nothing
        '
        'Hydrus1DPanel
        '
        Me.Hydrus1DPanel.AccessibleDescription = "HYDRUS Infiltration Data"
        Me.Hydrus1DPanel.AccessibleName = "Allows user to import infiltration from a HYDRUS generated output file."
        Me.Hydrus1DPanel.Controls.Add(Me.HydrusProject)
        Me.Hydrus1DPanel.Controls.Add(Me.SelectHydrusProjectButton)
        Me.Hydrus1DPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hydrus1DPanel.Location = New System.Drawing.Point(8, 240)
        Me.Hydrus1DPanel.Name = "Hydrus1DPanel"
        Me.Hydrus1DPanel.Size = New System.Drawing.Size(376, 170)
        Me.Hydrus1DPanel.TabIndex = 30
        '
        'HydrusProject
        '
        Me.HydrusProject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HydrusProject.Location = New System.Drawing.Point(8, 4)
        Me.HydrusProject.Name = "HydrusProject"
        Me.HydrusProject.ReadOnly = True
        Me.HydrusProject.Size = New System.Drawing.Size(360, 16)
        Me.HydrusProject.TabIndex = 1
        Me.HydrusProject.Text = "<Select a HYDRUS project to couple with WinSRFR>"
        Me.HydrusProject.WordWrap = False
        '
        'SelectHydrusProjectButton
        '
        Me.SelectHydrusProjectButton.Location = New System.Drawing.Point(6, 33)
        Me.SelectHydrusProjectButton.Name = "SelectHydrusProjectButton"
        Me.SelectHydrusProjectButton.Size = New System.Drawing.Size(362, 32)
        Me.SelectHydrusProjectButton.TabIndex = 2
        Me.SelectHydrusProjectButton.Text = "&Select HYDRUS Project ..."
        Me.SelectHydrusProjectButton.UseVisualStyleBackColor = True
        '
        'ctl_Infiltration
        '
        Me.Controls.Add(Me.InfiltrationGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_Infiltration"
        Me.Size = New System.Drawing.Size(400, 450)
        Me.InfiltrationGroupBox.ResumeLayout(False)
        Me.BranchFunctionPanel.ResumeLayout(False)
        Me.WarrickGreenAmptPanel.ResumeLayout(False)
        Me.WarrickGreenAmptPanel.PerformLayout()
        Me.InfiltrationFunctionPanel.ResumeLayout(False)
        Me.RefInflowPanel.ResumeLayout(False)
        Me.GreenAmptPanel.ResumeLayout(False)
        Me.GreenAmptPanel.PerformLayout()
        Me.TimeRatedIntakePanel.ResumeLayout(False)
        Me.TabulatedWarrickGreenAmptPanel.ResumeLayout(False)
        CType(Me.TabulatedWarrickGreenAmptControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedBranchPanel.ResumeLayout(False)
        CType(Me.TabulatedBranchFunctionControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedGreenAmptPanel.ResumeLayout(False)
        CType(Me.TabulatedGreenAmptControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedHydrusPanel.ResumeLayout(False)
        CType(Me.TabulatedHydrusControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfiltrationGraphics, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedNrcsIntakePanel.ResumeLayout(False)
        CType(Me.TabulatedNrcsIntakeControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedTimeRatedPanel.ResumeLayout(False)
        CType(Me.TabulatedTimeRatedControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedCharacteristicTimePanel.ResumeLayout(False)
        CType(Me.TabulatedCharacteristicTimeControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedKostiakovPanel.ResumeLayout(False)
        CType(Me.TabulatedKostiakovControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedModifiedKostiakovPanel.ResumeLayout(False)
        CType(Me.TabulatedModifiedKostiakovControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NrcsIntakePanel.ResumeLayout(False)
        Me.ModifiedKostiakovPanel.ResumeLayout(False)
        Me.KostiakovPanel.ResumeLayout(False)
        Me.CharacteristicInfiltrationPanel.ResumeLayout(False)
        Me.SimOptsPanel.ResumeLayout(False)
        Me.Hydrus1DPanel.ResumeLayout(False)
        Me.Hydrus1DPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish links to model objects and update UI with the model data
    '
    Private mUnit As Unit = Nothing
    Private mWorldWindow As WorldWindow
    Private mAnalysis As Analysis
    Private mWorld As World = Nothing
    Private mField As Field = Nothing
    Private mFarm As Farm = Nothing
    Private mWinSRFR As WinSRFR = Nothing
    Private mDictionary As Dictionary = Dictionary.Instance
    Private mMyStore As DataStore.ObjectNode = Nothing

    Private WithEvents mSystemGeometry As SystemGeometry = Nothing
    Private WithEvents mSoilCropProperties As SoilCropProperties = Nothing
    Private WithEvents mInflowManagement As InflowManagement = Nothing
    Private WithEvents mEventCriteria As EventCriteria = Nothing

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal _worldForm As WorldWindow)

        Debug.Assert(Not (_unit Is Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorldWindow = _worldForm
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        If (mWorldWindow IsNot Nothing) Then
            mAnalysis = mWorldWindow.CurrentAnalysis
        End If

        mSystemGeometry = mUnit.SystemGeometryRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        mMyStore = mUnit.MyStore

        ' Link the contained controls to their models & store
        WettedPerimeterControl.LinkToModel(mMyStore, mSoilCropProperties.WettedPerimeterMethodProperty)
        InfiltrationEquationControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationFunctionProperty)

        LimitingDepthSelect.LinkToModel(mMyStore, mSoilCropProperties.EnableLimitingDepthProperty)
        LimitingDepthControl.LinkToModel(mMyStore, mSoilCropProperties.LimitingDepthProperty)

        RefInflowRateSelect.LinkToModel(mMyStore, mEventCriteria.ReferenceFlowRateSetProperty)
        RefInflowRateControl.LinkToModel(mMyStore, mEventCriteria.ReferenceFlowRateProperty)

        Sel_005.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family005)
        Sel_010.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family010)
        Sel_015.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family015)
        Sel_020.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family020)
        Sel_025.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family025)
        Sel_030.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family030)
        Sel_035.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family035)
        Sel_040.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family040)
        Sel_045.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family045)
        Sel_050.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family050)
        Sel_060.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family060)
        Sel_070.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family070)
        Sel_080.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family080)
        Sel_090.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family090)
        Sel_100.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family100)
        Sel_150.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family150)
        Sel_200.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family200)
        Sel_300.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family300)
        Sel_400.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family400)

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
        BF_BranchTimeSet.LinkToModel(mMyStore, mSoilCropProperties.BranchTimeSetProperty)
        BF_BranchTimeControl.LinkToModel(mMyStore, mSoilCropProperties.BranchTime_BFProperty)

        HydrusProject.LinkToModel(mMyStore, mSoilCropProperties.HydrusProjectProperty)

        TabulatedInfiltrationSelect.LinkToModel(mMyStore, mSoilCropProperties.EnableTabulatedInfiltrationProperty)

        TabulatedCharacteristicTimeControl.LinkToModel(mMyStore, mSoilCropProperties.CharacteristicTimeTableProperty)
        TabulatedKostiakovControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovTableProperty)
        TabulatedModifiedKostiakovControl.LinkToModel(mMyStore, mSoilCropProperties.ModifiedKostiakovTableProperty)
        TabulatedBranchFunctionControl.LinkToModel(mMyStore, mSoilCropProperties.BranchFunctionTableProperty)
        TabulatedGreenAmptControl.LinkToModel(mMyStore, mSoilCropProperties.GreenAmptTableProperty)
        TabulatedWarrickGreenAmptControl.LinkToModel(mMyStore, mSoilCropProperties.WarrickGreenAmptTableProperty)

        TabulatedTimeRatedControl.LinkToModel(mMyStore, mSoilCropProperties.TimeRatedTableProperty)
        TabulatedTimeRatedControl.ReadonlyColumn(Srfr.Globals.sCharDepth) = True

        TabulatedNrcsIntakeControl.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeTableProperty)
        TabulatedNrcsIntakeControl.SelectionColumn(sNrcsFamily) = NrcsSelections

        TabulatedHydrusControl.LinkToModel(mMyStore, mSoilCropProperties.HydrusProjectTableProperty)

        GA_SoilTextureControl.LinkToModel(mMyStore, mSoilCropProperties.SoilTextureSelectionGA_Property)
        GA_SatWaterContentControl.LinkToModel(mMyStore, mSoilCropProperties.EffectivePorosityGA_Property)
        GA_InitVolWaterContentControl.LinkToModel(mMyStore, mSoilCropProperties.InitialWaterContentGA_Property)
        GA_WettingFrontControl.LinkToModel(mMyStore, mSoilCropProperties.WettingFrontPressureHeadGA_Property)
        GA_HydraulicConductivityControl.LinkToModel(mMyStore, mSoilCropProperties.HydraulicConductivityGA_Property)
        GA_InstantaneousInfiltrationControl.LinkToModel(mMyStore, mSoilCropProperties.GreenAmptC_Property)

        WGA_SoilTextureControl.LinkToModel(mMyStore, mSoilCropProperties.SoilTextureSelectionWGA_Property)
        WGA_SatWaterContentControl.LinkToModel(mMyStore, mSoilCropProperties.SaturatedWaterContentWGA_Property)
        WGA_InitWaterContentControl.LinkToModel(mMyStore, mSoilCropProperties.InitialWaterContentWGA_Property)
        WGA_WettingFrontControl.LinkToModel(mMyStore, mSoilCropProperties.WettingFrontPressureHeadWGA_Property)
        WGA_HydraulicConductivityControl.LinkToModel(mMyStore, mSoilCropProperties.HydraulicConductivityWGA_Property)
        WGA_InstantaneousInfiltrationControl.LinkToModel(mMyStore, mSoilCropProperties.WarrickGreenAmptC_Property)
        WGA_GammaControl.LinkToModel(mMyStore, mSoilCropProperties.WarrickGreenAmptGammaProperty)

        KostiakovCOptionControl.LinkToModel(mMyStore, mSoilCropProperties.TimeOffsetCProperty)
        BranchCOptionControl.LinkToModel(mMyStore, mSoilCropProperties.TimeOffsetCProperty)

        ' Add enumerations from radio button controls within Infiltration Control
        Dim nrcsFamily As PropertyNode = mSoilCropProperties.NrcsIntakeFamilyProperty
        nrcsFamily.ClearEnums()
        For Each item As NrcsIntakeValues In NrcsIntakeValuesTable
            Dim family As Integer = item.Family
            Dim name As String = item.Name
            nrcsFamily.AddEnumItem(name, family, True)
        Next

        Dim nrcsOption As PropertyNode = mSoilCropProperties.NrcsToKostiakovMethodProperty
        nrcsOption.ClearEnums()
        For idx As Integer = 0 To NrcsToKostiakovMethodSelections.Length - 1
            Dim method As String = NrcsToKostiakovMethodSelections(idx).Value
            nrcsOption.AddEnumItem(method, idx, True)
        Next

        ' Update language translation
        UpdateLanguage()

        ' Update the control's User Interface
        UpdateUI()

    End Sub
    '
    ' Update UI when referenced data changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub SoilCropProperties_PropertyChanged(ByVal _reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub EventCriteria_PropertyChanged(ByVal _reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateUI()
    End Sub

#End Region

#Region " Constants "
    '
    ' Resolve reference conflicts between DataStore & Srfr
    '
    Protected Const OneMillimeter As Double = Srfr.Globals.OneMillimeter
    Protected Const OneCentimeter As Double = Srfr.Globals.OneCentimeter
    Protected Const OneMeter As Double = Srfr.Globals.OneMeter

    Protected Const MillimetersPerMeter As Double = Srfr.Globals.MillimetersPerMeter
    Protected Const CentimetersPerMeter As Double = Srfr.CentimetersPerMeter
    Protected Const InchesPerMeter As Double = Srfr.InchesPerMeter

    Protected Const OneSecond As Double = Srfr.Globals.OneSecond
    Protected Const TenSeconds As Double = Srfr.Globals.TenSeconds
    Protected Const OneMinute As Double = Srfr.Globals.OneMinute
    Protected Const OneHour As Double = Srfr.Globals.OneHour
    Protected Const SecondsPerHour As Double = Srfr.Globals.SecondsPerHour

    Protected Const LiterPerSecond As Double = Srfr.Globals.LiterPerSecond

#End Region

#Region " Member Data "

    ' Infiltration Function Editor
    Private mInfFuncEditor As InfiltrationFunctionEditor = Nothing
    Private mInfFuncResult As DialogResult = DialogResult.None

    ' Characteristic Time / Time-Rated
    Private mInfiltrationDepth As Double = DefaultInfiltrationDepth
    Private mInfiltrationDepthUnits As Units

    Private mInfiltrationTime As Double = DefaultInfiltrationTime
    Private mInfiltrationTimeUnits As Units

    ' (Modified) Kostiakov Formula / Branch Function
    Private mKostiakovK As Double = DefaultKostiakovK
    Private mKostiakovKUnits As KostiakovKParameter.K_Units = KostiakovKParameter.K_Units.NoUnits

    Private mKostiakovA As Double = DefaultKostiakovA

    Private mKostiakovB As Double = DefaultKostiakovB
    Private mKostiakovBUnits As Units

    Private mKostiakovC As Double = DefaultKostiakovC
    Private mKostiakovCUnits As Units

    Private mBranchB As Double = DefaultBranchB
    Private mBranchBUnits As Units

    ' NRCS Suggested
    Private mNrcsIntakeFamily As NrcsIntakeFamilies = DefaultNrcsIntakeFamily

    ' Green-Ampt
    Private mGreenAmptSoilTexture As Srfr.Infiltration.SoilTextures

    Private mPhi As Double
    Private mTheta0 As Double
    Private mHf As Double
    Private mKs As Double

    Private mGreenAmptC As Double = DefaultKostiakovC
    Private mGreenAmptCUnits As Units

#End Region

#Region " Properties "

    Private mMatchingCurve As ArrayList
    Public Property MatchingCurve() As ArrayList
        Get
            Return mMatchingCurve
        End Get
        Set(ByVal Value As ArrayList)
            mMatchingCurve = Value
            UpdateGraphics()
        End Set
    End Property

    Private mPoints As Integer
    Public ReadOnly Property Points() As Integer
        Get
            Return mPoints
        End Get
    End Property

    Private mCurveTime As Double ' Max curve time
    Public ReadOnly Property CurveTime() As Double
        Get
            Return mCurveTime
        End Get
    End Property

    Public ReadOnly Property TimeOffsetC() As Boolean
        Get
            TimeOffsetC = False
            If (mSoilCropProperties IsNot Nothing) Then
                TimeOffsetC = mSoilCropProperties.TimeOffsetC.Value
            End If
        End Get
    End Property

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model objects
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        ' Update UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then

            ' Show/Hide World dependent UI
            Select Case mSoilCropProperties.Unit.UnitType.Value

                Case WorldTypes.SimulationWorld
                    SimOptsPanel.Show()

                    If (WinSRFR.UserLevel = UserLevels.Research) Then
                        If (mSoilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.FurrowSpacing) Then
                            RefInflowPanel.Hide()
                        Else
                            RefInflowPanel.Show()
                        End If
                    Else
                        RefInflowPanel.Hide()
                    End If
                Case WorldTypes.EventWorld
                    SimOptsPanel.Hide()
                    RefInflowPanel.Hide()
                Case Else ' assume Design or Operations
                    SimOptsPanel.Hide()

                    If (WinSRFR.UserLevel = UserLevels.Research) Then
                        If (mSoilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.FurrowSpacing) Then
                            RefInflowPanel.Hide()
                        Else
                            RefInflowPanel.Show()
                        End If
                    Else
                        RefInflowPanel.Hide()
                    End If
            End Select

            UpdateReferenceInflowRate()
            UpdateWettedPerimeterMethod()   ' WP now before Infiltration Equation (IE)
            UpdateInfiltrationEquation()    ' IE after WP
            UpdateLimitingDepth()
            UpdateNrcsIntakeFamily()
            UpdateSoilTextureSelection_GA()
            UpdateSoilTextureSelection_WGA()

            Dim aProp As PropertyNode
            aProp = mSoilCropProperties.KostiakovA_KTProperty
            aProp = mSoilCropProperties.KostiakovA_KFProperty
            aProp = mSoilCropProperties.KostiakovA_MKProperty
            aProp = mSoilCropProperties.KostiakovA_BFProperty

            KT_KostiakovAControl.CheckError()
            KF_KostiakovAControl.CheckError()
            MK_KostiakovAControl.CheckError()
            BF_KostiakovAControl.CheckError()

            UpdateGraphics()
        End If
    End Sub
    '
    ' Update display of Reference Inflow Rate
    '
    Private Sub UpdateReferenceInflowRate()

        ' Show/Hide/Update display of Reference Infow Rate
        If (mEventCriteria.ReferenceFlowRateSet.Value) Then
            RefInflowRateControl.Show()
            RefInflowDesc.Show()

            Select Case (mEventCriteria.ReferenceFlowRate.Source)
                Case ValueSources.Defaulted
                    RefInflowDesc.Text = mDictionary.tSetToDefault.Translated
                Case ValueSources.Calculated
                    RefInflowDesc.Text = mDictionary.tSetByEvent.Translated
                Case ValueSources.UserEntered, ValueSources.Remote
                    RefInflowDesc.Text = mDictionary.tSetByUser.Translated
                Case Else
                    RefInflowDesc.Text = ""
            End Select
        Else
            RefInflowRateControl.Hide()
            RefInflowDesc.Hide()
        End If

    End Sub
    '
    ' Update display of Wetted Perimeter Method
    '
    Private Sub UpdateWettedPerimeterMethod()

        If (mAnalysis IsNot Nothing) Then

            ' Wetted Perimeter only applies to Furrows
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

                mAnalysis.LoadWettedPerimeterControl(WettedPerimeterControl)

                WettedPerimeterLabel.Show()
                WettedPerimeterControl.UpdateUI()
                WettedPerimeterControl.Show()

            Else ' Basin / Border

                Me.WettedPerimeterLabel.Hide()
                Me.WettedPerimeterControl.Hide()

            End If
        End If

    End Sub
    '
    ' Update the Infiltration Equation selection list & selection
    '
    Private Sub UpdateInfiltrationEquation()

        ' Update selection
        If (mAnalysis IsNot Nothing) Then
            mAnalysis.LoadInfiltrationEquationControl(InfiltrationEquationControl)
            InfiltrationEquationControl.UpdateUI()
        End If

        ' Design & Operations don't support Tabulated Infiltration
        Dim supported As Boolean = False

        Select Case mSoilCropProperties.Unit.UnitType.Value

            Case WorldTypes.SimulationWorld
                TabulatedInfiltrationSelect.Show()
                supported = True

            Case WorldTypes.EventWorld

                Dim eventType As EventAnalysisTypes = mEventCriteria.EventAnalysisType.Value

                Select Case (eventType)
                    Case EventAnalysisTypes.ErosionAnalysis
                        TabulatedInfiltrationSelect.Show()
                        supported = True
                    Case Else
                        TabulatedInfiltrationSelect.Hide()
                End Select

            Case Else
                TabulatedInfiltrationSelect.Hide()
        End Select

        ' Get current Kostiakov parameter values
        Dim k As Double = mSoilCropProperties.KostiakovK
        Dim a As Double = mSoilCropProperties.KostiakovA
        Dim c As Double = mSoilCropProperties.KostiakovC

        Dim _kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
        Dim _cunits As Units = mUnitsSystem.DepthUnits

        ' Hide/Show controls & update values displayed
        Dim tabulated As Boolean = mSoilCropProperties.EnableTabulatedInfiltration.Value
        Dim limitingDepth As Boolean = mSoilCropProperties.EnableLimitingDepth.Value

        If ((supported) And (tabulated)) Then
            ' Tabulated Infiltration is selected
            TimeRatedIntakePanel.Hide()
            KostiakovPanel.Hide()
            ModifiedKostiakovPanel.Hide()
            BranchFunctionPanel.Hide()
            NrcsIntakePanel.Hide()
            CharacteristicInfiltrationPanel.Hide()
            GreenAmptPanel.Hide()
            Hydrus1DPanel.Hide()
            WarrickGreenAmptPanel.Hide()

            UseInfiltrationEditorButton.Hide()

            If (TabulatedInfiltrationSelect.Checked) Then
                Dim infiltrationFunction As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value

                Select Case (infiltrationFunction)
                    Case InfiltrationFunctions.CharacteristicInfiltrationTime
                        TabulatedTimeRatedPanel.Hide()
                        TabulatedBranchPanel.Hide()
                        TabulatedKostiakovPanel.Hide()
                        TabulatedModifiedKostiakovPanel.Hide()
                        TabulatedNrcsIntakePanel.Hide()
                        TabulatedGreenAmptPanel.Hide()
                        TabulatedHydrusPanel.Hide()
                        TabulatedWarrickGreenAmptPanel.Hide()

                        TabulatedCharacteristicTimePanel.Show()
                        If (limitingDepth) Then
                            TabulatedCharacteristicTimeControl.HiddenColumn(Srfr.Globals.sLimit) = False
                        Else
                            TabulatedCharacteristicTimeControl.HiddenColumn(Srfr.Globals.sLimit) = True
                        End If
                        TabulatedCharacteristicTimeControl.UpdateUI()

                    Case InfiltrationFunctions.TimeRatedIntakeFamily
                        TabulatedCharacteristicTimePanel.Hide()
                        TabulatedBranchPanel.Hide()
                        TabulatedKostiakovPanel.Hide()
                        TabulatedModifiedKostiakovPanel.Hide()
                        TabulatedNrcsIntakePanel.Hide()
                        TabulatedGreenAmptPanel.Hide()
                        TabulatedHydrusPanel.Hide()
                        TabulatedWarrickGreenAmptPanel.Hide()

                        TabulatedTimeRatedPanel.Show()
                        If (limitingDepth) Then
                            TabulatedTimeRatedControl.HiddenColumn(Srfr.Globals.sLimit) = False
                        Else
                            TabulatedTimeRatedControl.HiddenColumn(Srfr.Globals.sLimit) = True
                        End If
                        TabulatedTimeRatedControl.UpdateUI()

                    Case InfiltrationFunctions.NRCSIntakeFamily
                        TabulatedCharacteristicTimePanel.Hide()
                        TabulatedBranchPanel.Hide()
                        TabulatedKostiakovPanel.Hide()
                        TabulatedModifiedKostiakovPanel.Hide()
                        TabulatedTimeRatedPanel.Hide()
                        TabulatedGreenAmptPanel.Hide()
                        TabulatedHydrusPanel.Hide()
                        TabulatedWarrickGreenAmptPanel.Hide()

                        TabulatedNrcsIntakePanel.Show()
                        If (limitingDepth) Then
                            TabulatedNrcsIntakeControl.HiddenColumn(Srfr.Globals.sLimit) = False
                        Else
                            TabulatedNrcsIntakeControl.HiddenColumn(Srfr.Globals.sLimit) = True
                        End If
                        TabulatedNrcsIntakeControl.UpdateUI()

                    Case InfiltrationFunctions.BranchFunction
                        TabulatedCharacteristicTimePanel.Hide()
                        TabulatedTimeRatedPanel.Hide()
                        TabulatedKostiakovPanel.Hide()
                        TabulatedModifiedKostiakovPanel.Hide()
                        TabulatedNrcsIntakePanel.Hide()
                        TabulatedGreenAmptPanel.Hide()
                        TabulatedHydrusPanel.Hide()
                        TabulatedWarrickGreenAmptPanel.Hide()

                        TabulatedBranchPanel.Show()
                        If (limitingDepth) Then
                            TabulatedBranchFunctionControl.HiddenColumn(Srfr.Globals.sLimit) = False
                        Else
                            TabulatedBranchFunctionControl.HiddenColumn(Srfr.Globals.sLimit) = True
                        End If
                        TabulatedBranchFunctionControl.UpdateUI()

                    Case InfiltrationFunctions.KostiakovFormula
                        TabulatedCharacteristicTimePanel.Hide()
                        TabulatedTimeRatedPanel.Hide()
                        TabulatedBranchPanel.Hide()
                        TabulatedModifiedKostiakovPanel.Hide()
                        TabulatedNrcsIntakePanel.Hide()
                        TabulatedGreenAmptPanel.Hide()
                        TabulatedHydrusPanel.Hide()
                        TabulatedWarrickGreenAmptPanel.Hide()

                        TabulatedKostiakovPanel.Show()
                        If (limitingDepth) Then
                            TabulatedKostiakovControl.HiddenColumn(Srfr.Globals.sLimit) = False
                        Else
                            TabulatedKostiakovControl.HiddenColumn(Srfr.Globals.sLimit) = True
                        End If
                        TabulatedKostiakovControl.UpdateUI()

                    Case InfiltrationFunctions.GreenAmpt
                        TabulatedCharacteristicTimePanel.Hide()
                        TabulatedTimeRatedPanel.Hide()
                        TabulatedBranchPanel.Hide()
                        TabulatedKostiakovPanel.Hide()
                        TabulatedNrcsIntakePanel.Hide()
                        TabulatedModifiedKostiakovPanel.Hide()
                        TabulatedWarrickGreenAmptPanel.Hide()

                        TabulatedGreenAmptPanel.Show()
                        If (limitingDepth) Then
                            TabulatedGreenAmptControl.HiddenColumn(Srfr.Globals.sLimit) = False
                        Else
                            TabulatedGreenAmptControl.HiddenColumn(Srfr.Globals.sLimit) = True
                        End If
                        TabulatedGreenAmptControl.UpdateUI()

                    Case InfiltrationFunctions.Hydrus1D
                        TabulatedCharacteristicTimePanel.Hide()
                        TabulatedTimeRatedPanel.Hide()
                        TabulatedBranchPanel.Hide()
                        TabulatedKostiakovPanel.Hide()
                        TabulatedNrcsIntakePanel.Hide()
                        TabulatedModifiedKostiakovPanel.Hide()
                        TabulatedGreenAmptPanel.Hide()
                        TabulatedWarrickGreenAmptPanel.Hide()

                        TabulatedHydrusPanel.Show()
                        TabulatedHydrusControl.UpdateUI()

                    Case InfiltrationFunctions.WarrickGreenAmpt
                        TabulatedCharacteristicTimePanel.Hide()
                        TabulatedTimeRatedPanel.Hide()
                        TabulatedBranchPanel.Hide()
                        TabulatedKostiakovPanel.Hide()
                        TabulatedNrcsIntakePanel.Hide()
                        TabulatedModifiedKostiakovPanel.Hide()
                        TabulatedGreenAmptPanel.Hide()

                        TabulatedWarrickGreenAmptPanel.Show()
                        If (limitingDepth) Then
                            TabulatedWarrickGreenAmptControl.HiddenColumn(Srfr.Globals.sLimit) = False
                        Else
                            TabulatedWarrickGreenAmptControl.HiddenColumn(Srfr.Globals.sLimit) = True
                        End If
                        TabulatedWarrickGreenAmptControl.UpdateUI()

                    Case Else ' Assume InfiltrationFunctions.ModifiedKostiakovFormula
                        TabulatedCharacteristicTimePanel.Hide()
                        TabulatedTimeRatedPanel.Hide()
                        TabulatedBranchPanel.Hide()
                        TabulatedKostiakovPanel.Hide()
                        TabulatedNrcsIntakePanel.Hide()
                        TabulatedGreenAmptPanel.Hide()
                        TabulatedHydrusPanel.Hide()
                        TabulatedWarrickGreenAmptPanel.Hide()

                        TabulatedModifiedKostiakovPanel.Show()
                        If (limitingDepth) Then
                            TabulatedModifiedKostiakovControl.HiddenColumn(Srfr.Globals.sLimit) = False
                        Else
                            TabulatedModifiedKostiakovControl.HiddenColumn(Srfr.Globals.sLimit) = True
                        End If
                        TabulatedModifiedKostiakovControl.UpdateUI()
                End Select
            End If

        Else
            ' Normal Infiltration is selected
            TabulatedCharacteristicTimePanel.Hide()
            TabulatedTimeRatedPanel.Hide()
            TabulatedBranchPanel.Hide()
            TabulatedKostiakovPanel.Hide()
            TabulatedModifiedKostiakovPanel.Hide()
            TabulatedNrcsIntakePanel.Hide()
            TabulatedGreenAmptPanel.Hide()
            TabulatedHydrusPanel.Hide()
            TabulatedWarrickGreenAmptPanel.Hide()

            Me.UseInfiltrationEditorButton.Show()

            Dim _infiltrationFunction As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value

            Select Case _infiltrationFunction

                Case InfiltrationFunctions.CharacteristicInfiltrationTime
                    TimeRatedIntakePanel.Hide()
                    KostiakovPanel.Hide()
                    ModifiedKostiakovPanel.Hide()
                    BranchFunctionPanel.Hide()
                    NrcsIntakePanel.Hide()
                    GreenAmptPanel.Hide()
                    Hydrus1DPanel.Hide()
                    WarrickGreenAmptPanel.Hide()
                    CharacteristicInfiltrationPanel.Show()

                    ' Update Kostiakov k
                    KT_KostiakovK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, _kunits)

                Case InfiltrationFunctions.KostiakovFormula
                    TimeRatedIntakePanel.Hide()
                    BranchFunctionPanel.Hide()
                    CharacteristicInfiltrationPanel.Hide()
                    NrcsIntakePanel.Hide()
                    ModifiedKostiakovPanel.Hide()
                    GreenAmptPanel.Hide()
                    Hydrus1DPanel.Hide()
                    WarrickGreenAmptPanel.Hide()
                    KostiakovPanel.Show()

                Case InfiltrationFunctions.ModifiedKostiakovFormula
                    TimeRatedIntakePanel.Hide()
                    BranchFunctionPanel.Hide()
                    CharacteristicInfiltrationPanel.Hide()
                    NrcsIntakePanel.Hide()
                    KostiakovPanel.Hide()
                    GreenAmptPanel.Hide()
                    Hydrus1DPanel.Hide()
                    WarrickGreenAmptPanel.Hide()
                    ModifiedKostiakovPanel.Show()

                Case InfiltrationFunctions.NRCSIntakeFamily
                    TimeRatedIntakePanel.Hide()
                    KostiakovPanel.Hide()
                    KostiakovPanel.Hide()
                    ModifiedKostiakovPanel.Hide()
                    BranchFunctionPanel.Hide()
                    CharacteristicInfiltrationPanel.Hide()
                    GreenAmptPanel.Hide()
                    Hydrus1DPanel.Hide()
                    WarrickGreenAmptPanel.Hide()
                    NrcsIntakePanel.Show()

                    ' Update Kostiakov k, a & c
                    NrcsK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, _kunits)
                    NrcsA.Text = "a = " + Format(a, "0.00#")
                    NrcsC.Text = "c = " + DepthString(c)

                Case InfiltrationFunctions.TimeRatedIntakeFamily
                    KostiakovPanel.Hide()
                    ModifiedKostiakovPanel.Hide()
                    BranchFunctionPanel.Hide()
                    CharacteristicInfiltrationPanel.Hide()
                    NrcsIntakePanel.Hide()
                    GreenAmptPanel.Hide()
                    Hydrus1DPanel.Hide()
                    WarrickGreenAmptPanel.Hide()
                    TimeRatedIntakePanel.Show()

                    ' Update Kostiakov a & k
                    TR_KostiakovA.Text = "a = " + Format(a, "0.00#")
                    TR_KostiakovK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, _kunits)

                Case InfiltrationFunctions.GreenAmpt
                    TimeRatedIntakePanel.Hide()
                    BranchFunctionPanel.Hide()
                    CharacteristicInfiltrationPanel.Hide()
                    NrcsIntakePanel.Hide()
                    KostiakovPanel.Hide()
                    ModifiedKostiakovPanel.Hide()
                    Hydrus1DPanel.Hide()
                    WarrickGreenAmptPanel.Hide()
                    GreenAmptPanel.Show()

                Case InfiltrationFunctions.Hydrus1D
                    TimeRatedIntakePanel.Hide()
                    BranchFunctionPanel.Hide()
                    CharacteristicInfiltrationPanel.Hide()
                    NrcsIntakePanel.Hide()
                    KostiakovPanel.Hide()
                    ModifiedKostiakovPanel.Hide()
                    GreenAmptPanel.Hide()
                    WarrickGreenAmptPanel.Hide()
                    Hydrus1DPanel.Show()

                    UseInfiltrationEditorButton.Hide()

                Case InfiltrationFunctions.WarrickGreenAmpt
                    TimeRatedIntakePanel.Hide()
                    BranchFunctionPanel.Hide()
                    CharacteristicInfiltrationPanel.Hide()
                    NrcsIntakePanel.Hide()
                    KostiakovPanel.Hide()
                    ModifiedKostiakovPanel.Hide()
                    Hydrus1DPanel.Hide()
                    GreenAmptPanel.Hide()
                    WarrickGreenAmptPanel.Show()

                Case Else ' Assume Branch Function
                    TimeRatedIntakePanel.Hide()
                    KostiakovPanel.Hide()
                    ModifiedKostiakovPanel.Hide()
                    CharacteristicInfiltrationPanel.Hide()
                    NrcsIntakePanel.Hide()
                    GreenAmptPanel.Hide()
                    Hydrus1DPanel.Hide()
                    WarrickGreenAmptPanel.Hide()
                    BranchFunctionPanel.Show()

                    If (mSoilCropProperties.BranchTimeSet.Value) Then ' Branch Time is set by user
                        Me.BF_BranchTimeValue.Hide()
                        Me.BF_BranchTimeControl.Show()
                    Else ' Branch Time is calculated
                        Me.BF_BranchTimeControl.Hide()
                        Dim bt As Double = mSoilCropProperties.BranchTime
                        Me.BF_BranchTimeValue.Text = DataStore.TimeString(bt)
                        Me.BF_BranchTimeValue.Show()
                    End If

                    Me.BF_BranchBControl.CheckError()
                    Me.BF_BranchBControl.UpdateUI()
            End Select
        End If

        ' Research User has more options
        If (mWinSRFR.IsResearchLevel) Then
            BranchCOptionControl.Show()
            KostiakovCOptionControl.Show()
        Else
            BranchCOptionControl.Hide()
            KostiakovCOptionControl.Hide()
        End If

    End Sub
    '
    ' Update display of Limiting Depth
    '
    Private Sub UpdateLimitingDepth()
        ' Design & Operations don't support Limiting Depth
        Select Case mSoilCropProperties.Unit.UnitType.Value

            Case WorldTypes.SimulationWorld

                If (WinSRFR.UserLevel = UserLevels.Standard) Then

                    LimitingDepthSelect.Hide()
                    LimitingDepthControl.Hide()

                ElseIf (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then

                    LimitingDepthSelect.Hide()
                    LimitingDepthControl.Hide()
                Else

                    LimitingDepthSelect.Show()

                    ' Limiting Depth is column in Tabulated Infiltration
                    If (mSoilCropProperties.EnableTabulatedInfiltration.Value = True) Then
                        LimitingDepthControl.Hide()
                    Else
                        LimitingDepthControl.Show()
                    End If

                    If (mSoilCropProperties.EnableLimitingDepth.Value = True) Then
                        LimitingDepthControl.Enabled = True
                    Else
                        LimitingDepthControl.Enabled = False
                    End If
                End If

            Case Else
                LimitingDepthSelect.Hide()
                LimitingDepthControl.Hide()
        End Select

    End Sub
    '
    ' Update which NRCS Intake Family is checked
    '
    Private Sub UpdateNrcsIntakeFamily()
        Select Case mSoilCropProperties.NrcsIntakeFamily.Value
            Case NrcsIntakeFamilies.Family005
                Sel_005.Checked = True
            Case NrcsIntakeFamilies.Family010
                Sel_010.Checked = True
            Case NrcsIntakeFamilies.Family015
                Sel_015.Checked = True
            Case NrcsIntakeFamilies.Family020
                Sel_020.Checked = True
            Case NrcsIntakeFamilies.Family025
                Sel_025.Checked = True
            Case NrcsIntakeFamilies.Family030
                Sel_030.Checked = True
            Case NrcsIntakeFamilies.Family035
                Sel_035.Checked = True
            Case NrcsIntakeFamilies.Family040
                Sel_040.Checked = True
            Case NrcsIntakeFamilies.Family045
                Sel_045.Checked = True
            Case NrcsIntakeFamilies.Family050
                Sel_050.Checked = True
            Case NrcsIntakeFamilies.Family060
                Sel_060.Checked = True
            Case NrcsIntakeFamilies.Family070
                Sel_070.Checked = True
            Case NrcsIntakeFamilies.Family080
                Sel_080.Checked = True
            Case NrcsIntakeFamilies.Family090
                Sel_090.Checked = True
            Case NrcsIntakeFamilies.Family100
                Sel_100.Checked = True
            Case NrcsIntakeFamilies.Family150
                Sel_150.Checked = True
            Case NrcsIntakeFamilies.Family200
                Sel_200.Checked = True
            Case NrcsIntakeFamilies.Family300
                Sel_300.Checked = True
            Case NrcsIntakeFamilies.Family400
                Sel_400.Checked = True
        End Select

        If (WinSRFR.UserLevel = UserLevels.Standard) Then
            Me.NrcsOptionsButton.Hide()
        Else
            Me.NrcsOptionsButton.Show()
        End If
    End Sub
    '
    ' Update display of Soil Texture Selections
    '
    Private Sub UpdateSoilTextureSelection_GA()

        ' Get selection flags for current World, Cross Section & User Level
        Dim _worldType As WorldTypes = CType(mWorld.WorldType.Value, WorldTypes)
        Dim _crossSection As CrossSections = mUnit.CrossSection
        Dim _userLevel As UserLevels = mWinSRFR.UserLevel
        Dim _selFlags As Globals.SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        ' Update selection list
        Dim _sel As String = String.Empty
        Dim _idx As Integer = 0

        Me.GA_SoilTextureControl.Clear()

        Dim _selOk As Boolean = mSoilCropProperties.GetFirstSoilTextureSelectionGA(_sel)
        While Not (_sel Is Nothing)
            If (_selOk) Then
                Me.GA_SoilTextureControl.Add(_sel, _idx, True)
            End If
            _selOk = mSoilCropProperties.GetNextSoilTextureSelectionGA(_sel)
            _idx += 1
        End While

        ' Update controls
        Me.GA_SoilTextureControl.UpdateUI()

        ' Update display of "(modified)"
        Dim texture As Integer = mSoilCropProperties.SoilTextureSelectionGA.Value
        Dim soilProperties As Srfr.Infiltration.SoilProperties = Srfr.Infiltration.SoilPropertiesTable(texture)

        If ((mSoilCropProperties.EffectivePorosityGA.Value = soilProperties.EffectivePorosity) _
        And (mSoilCropProperties.InitialWaterContentGA.Value = soilProperties.InitialWaterContent) _
        And (mSoilCropProperties.WettingFrontPressureHeadGA.Value = soilProperties.WettingFrontPressureHead) _
        And (mSoilCropProperties.HydraulicConductivityGA.Value = soilProperties.HydraulicConductivity)) Then
            Me.GA_ModifiedLabel.Hide()
        Else
            Me.GA_ModifiedLabel.Show()
        End If

        ' Update SWD calculation
        Dim SWD As Double = mSoilCropProperties.EffectivePorosityGA.Value - mSoilCropProperties.InitialWaterContentGA.Value
        Me.GA_SWD.Text = "SWD " + ConcentrationLengthString(SWD)

    End Sub

    Private Sub UpdateSoilTextureSelection_WGA()

        ' Get selection flags for current World, Cross Section & User Level
        Dim _worldType As WorldTypes = CType(mWorld.WorldType.Value, WorldTypes)
        Dim _crossSection As CrossSections = mUnit.CrossSection
        Dim _userLevel As UserLevels = mWinSRFR.UserLevel
        Dim _selFlags As Globals.SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        ' Update selection list
        Dim _sel As String = String.Empty
        Dim _idx As Integer = 0

        Me.WGA_SoilTextureControl.Clear()

        Dim _selOk As Boolean = mSoilCropProperties.GetFirstSoilTextureSelectionWGA(_sel)
        While Not (_sel Is Nothing)
            If (_selOk) Then
                Me.WGA_SoilTextureControl.Add(_sel, _idx, True)
            End If
            _selOk = mSoilCropProperties.GetNextSoilTextureSelectionWGA(_sel)
            _idx += 1
        End While

        ' Update controls
        Me.WGA_SoilTextureControl.UpdateUI()

        ' Update display of "(modified)"
        Dim texture As Integer = mSoilCropProperties.SoilTextureSelectionWGA.Value
        Dim soilProperties As Srfr.Infiltration.SoilProperties = Srfr.Infiltration.SoilPropertiesTable(texture)

        If ((mSoilCropProperties.SaturatedWaterContentWGA.Value = soilProperties.EffectivePorosity) _
        And (mSoilCropProperties.InitialWaterContentWGA.Value = soilProperties.InitialWaterContent) _
        And (mSoilCropProperties.WettingFrontPressureHeadWGA.Value = soilProperties.WettingFrontPressureHead) _
        And (mSoilCropProperties.HydraulicConductivityWGA.Value = soilProperties.HydraulicConductivity)) Then
            Me.WGA_ModifiedLabel.Hide()
        Else
            Me.WGA_ModifiedLabel.Show()
        End If

        ' Update SWD calculation
        Dim SWD As Double = mSoilCropProperties.SaturatedWaterContentWGA.Value - mSoilCropProperties.InitialWaterContentWGA.Value
        Me.WGA_SWD.Text = "SWD " + ConcentrationLengthString(SWD)

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me)
        UpdateUI()
    End Sub

#End Region

#Region " Infiltration Graphics "
    '
    ' Calculate the HYDRUS function infiltration curve
    '
    Public Function HydrusCurve(ByVal RateTable As DataTable, ByVal Tn As Double, _
                                ByVal points As Integer) As ArrayList
        Debug.Assert(1 < points)

        HydrusCurve = New ArrayList ' Curve to return
        '
        ' Calculate the infiltration depth curve
        '
        Dim Zn As Double   ' Infiltration depth
        Dim Tau As Double    ' Infiltration time
        '
        ' The classic fence post problem: N fence posts = N-1 fence segments
        '
        ' Here: N points = N-1 time segments
        '
        Dim timeSegments As Integer = points - 1

        For pt As Integer = 0 To points - 1
            Tau = (Tn * pt) / timeSegments  ' Time represented by this point
            Zn = InfiltrationDepthTabRate(Tau, RateTable)
            HydrusCurve.Add(Zn)
        Next pt

    End Function
    '
    ' Draw the Infiltration Curve for the selected Infiltration Method
    '
    Private Sub UpdateGraphics()

        ' Skip update until initialization is complete
        If (mUnit Is Nothing) Then
            Return
        End If

        ' Create a bitmap for the graphics
        Dim _bitmap As Bitmap = New Bitmap(InfiltrationGraphics.Width, InfiltrationGraphics.Height)
        Dim _offset As Integer = 16 ' Offset into bitmap for axes
        Dim _quadrant As QuadrantSelections = QuadrantSelections.UpperRight

        ' Get drawing tools
        Dim _graphics As Graphics = Graphics.FromImage(_bitmap)
        Dim _blackBrush As Brush = BlackSolidBrush()
        Dim _blueBrush As Brush = BlueSolidBrush()
        Dim _black As Pen = BlackPen1()
        Dim _blue As Pen = BluePen1()
        Dim _gray As Pen = DarkGrayPen()

        Dim _noInfiltrationErrMsg As String = mDictionary.tNoInfiltration.Translated

        ' Fill the bitmap with the background color
        _graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, InfiltrationGraphics.Width, InfiltrationGraphics.Height)

        ' Enclose all graphics code in Try Catch block to ignore exceptions
        Try
            ' Compute the Curve for the user selected infiltration specification
            mPoints = InfiltrationGraphics.Width - _offset + 1 ' Points to plot
            Dim _curve As ArrayList = Nothing
            Dim _refCurve As ArrayList = Nothing
            Dim _refH0 As Double = 0.0

            ' For most infiltration methods, Zn = Required Depth
            Dim Zn As Double = mInflowManagement.RequiredDepth.Value
            Dim Zmax As Double ' Max curve depth

            ' Kostiakov / Branch parameters
            Dim a As Double = mSoilCropProperties.KostiakovA
            Dim b As Double = mSoilCropProperties.KostiakovB
            Dim c As Double = mSoilCropProperties.KostiakovC
            Dim k As Double = mSoilCropProperties.KostiakovK

            ' Green-Ampt parameters
            Dim PhiGA As Double = mSoilCropProperties.EffectivePorosityGA.Value
            Dim Theta0GA As Double = mSoilCropProperties.InitialWaterContentGA.Value
            Dim hfGA As Double = mSoilCropProperties.WettingFrontPressureHeadGA.Value
            Dim KsGA As Double = mSoilCropProperties.HydraulicConductivityGA.Value
            Dim cGA As Double = mSoilCropProperties.GreenAmptC.Value

            ' Warrick Green-Ampt parameters
            Dim ThetaSWGA As Double = mSoilCropProperties.SaturatedWaterContentWGA.Value
            Dim Theta0WGA As Double = mSoilCropProperties.InitialWaterContentWGA.Value
            Dim hfWGA As Double = mSoilCropProperties.WettingFrontPressureHeadWGA.Value
            Dim KsWGA As Double = mSoilCropProperties.HydraulicConductivityWGA.Value
            Dim cWGA As Double = mSoilCropProperties.WarrickGreenAmptC.Value

            ' Update parameters with tabulated values, if selected
            Dim tdx As Integer = -1
            Dim row As DataRow = Nothing
            If (mSoilCropProperties.EnableTabulatedInfiltration.Value) Then

                Select Case mSoilCropProperties.InfiltrationFunction.Value
                    Case InfiltrationFunctions.BranchFunction
                        tdx = Me.TabulatedBranchFunctionControl.RowSelected
                        row = mSoilCropProperties.BranchFunctionTable.Value.Rows(tdx)

                        LoadKostiakovFromDataRow(row, k, a, b, c)

                    Case InfiltrationFunctions.CharacteristicInfiltrationTime
                        tdx = Me.TabulatedCharacteristicTimeControl.RowSelected
                        row = mSoilCropProperties.CharacteristicTimeTable.Value.Rows(tdx)

                        Dim charDepth As Double = CDbl(row.Item(Srfr.Globals.sCharDepth))
                        Dim charTime As Double = CDbl(row.Item(Srfr.Globals.sCharTime))

                        LoadKostiakovFromDataRow(row, k, a, b, c)
                        b = 0.0
                        c = 0.0
                        k = Srfr.SrfrAPI.KostiakovK(charDepth, charTime, a)

                    Case InfiltrationFunctions.KostiakovFormula
                        tdx = Me.TabulatedKostiakovControl.RowSelected
                        row = mSoilCropProperties.KostiakovTable.Value.Rows(tdx)

                        LoadKostiakovFromDataRow(row, k, a, b, c)
                        b = 0.0
                        c = 0.0

                    Case InfiltrationFunctions.ModifiedKostiakovFormula
                        tdx = Me.TabulatedModifiedKostiakovControl.RowSelected
                        row = mSoilCropProperties.ModifiedKostiakovTable.Value.Rows(tdx)

                        LoadKostiakovFromDataRow(row, k, a, b, c)

                    Case InfiltrationFunctions.NRCSIntakeFamily
                        tdx = Me.TabulatedNrcsIntakeControl.RowSelected
                        row = mSoilCropProperties.NrcsIntakeTable.Value.Rows(tdx)

                        Dim nrcsFamilyName As String = CStr(row.Item(Srfr.Globals.sNrcsFamily))

                        Dim nrcsFamily As Srfr.NrcsIntakeFamily.NrcsIntakeFamilies = Srfr.NrcsIntakeFamily.FindNrcsIntakeFamily(nrcsFamilyName)
                        Dim nrcsOptions As Srfr.NrcsIntakeFamily.NrcsIntakeOptions = mSoilCropProperties.NrcsToKostiakovMethod.Value
                        Dim nrcsValues As Srfr.NrcsIntakeFamily.NrcsIntakeValues = Srfr.NrcsIntakeFamily.NrcsIntakeFamilyValues(nrcsFamily, nrcsOptions)

                        a = nrcsValues.a
                        b = 0.0
                        Select Case (nrcsOptions)
                            Case Srfr.NrcsIntakeFamily.NrcsIntakeOptions.ApproximateByBestFit
                                c = 0.0
                            Case Else ' Assume NrcsToKostiakovMethods.DescribeByNrcsFormula
                                c = Depth7mm
                        End Select
                        k = nrcsValues.k

                    Case InfiltrationFunctions.TimeRatedIntakeFamily
                        tdx = Me.TabulatedTimeRatedControl.RowSelected
                        row = mSoilCropProperties.TimeRatedTable.Value.Rows(tdx)

                        Dim corrTime As Double = CDbl(row.Item(Srfr.Globals.sCorrTime))

                        a = Srfr.SrfrAPI.NrcsA(corrTime)
                        b = 0.0
                        c = 0.0
                        k = Srfr.SrfrAPI.KostiakovK(Depth100mm, corrTime, a)

                    Case InfiltrationFunctions.GreenAmpt
                        tdx = Me.TabulatedGreenAmptControl.RowSelected
                        row = mSoilCropProperties.GreenAmptTable.Value.Rows(tdx)

                        PhiGA = CDbl(row.Item(Srfr.Globals.sPhi))
                        Theta0GA = CDbl(row.Item(Srfr.Globals.sTheta0))
                        hfGA = CDbl(row.Item(Srfr.Globals.sHf))
                        KsGA = CDbl(row.Item(Srfr.Globals.sKs))
                        cGA = CDbl(row.Item(Srfr.Globals.sC))

                    Case InfiltrationFunctions.WarrickGreenAmpt
                        tdx = Me.TabulatedWarrickGreenAmptControl.RowSelected
                        row = mSoilCropProperties.WarrickGreenAmptTable.Value.Rows(tdx)

                        ThetaSWGA = CDbl(row.Item(Srfr.Globals.sThetaS))
                        Theta0WGA = CDbl(row.Item(Srfr.Globals.sTheta0))
                        hfWGA = CDbl(row.Item(Srfr.Globals.sHf))
                        KsWGA = CDbl(row.Item(Srfr.Globals.sKs))
                        cWGA = CDbl(row.Item(Srfr.Globals.sC))

                    Case InfiltrationFunctions.Hydrus1D
                        Dim y As Double = _bitmap.Height / 2.0
                        DrawText(_bitmap, _quadrant, Nothing, _offset, Me.Font, 0, y, mDictionary.tHydrusGraphNotAvailable.Translated)

                        Exit Try

                End Select
            End If ' EnableTabulatedInfiltration

            ' Compute infiltration curves; end of curve is double Infiltration Time/Depth whichever is smaller
            Dim Tn As Double = 0.0
            Dim Tn2 As Double = 0.0
            Dim Tb As Double = Srfr.SrfrAPI.BranchTime(k, a, b)
            If (mSoilCropProperties.BranchTimeSet.Value) Then
                Tb = mSoilCropProperties.BranchTime_BF.Value
            End If

            Dim h0 As Double = mUnit.UpstreamDepth()    ' Use Upstream Depth for h0
            Dim nrcs0 As Double = mUnit.NrcsUpstreamWettedPerimeter()

            Select Case mSoilCropProperties.InfiltrationFunction.Value

                Case InfiltrationFunctions.Hydrus1D
                    Dim y As Double = _bitmap.Height / 2.0
                    DrawText(_bitmap, _quadrant, Nothing, _offset, Me.Font, 0, y, mDictionary.tHydrusGraphNotAvailable.Translated)

                    Exit Try

                Case Else ' All other infiltration functions

                    If (tdx < 0) Then ' scalar infiltration parameters
                        ' Time to infiltrate to Required Depth (Zn)
                        Tn = mSoilCropProperties.InfiltrationTime(Zn)
                        ' Time to infiltrate to 2 * Zn
                        If (c < Zn) Then
                            Tn2 = mSoilCropProperties.InfiltrationTime(Zn * 2.0)
                        Else
                            Tn2 = mSoilCropProperties.InfiltrationTime(c * 2.0)
                        End If
                    Else ' tabulated infiltration parameters
                        ' Time to infiltrate to Required Depth (Zn)
                        Tn = mSoilCropProperties.InfiltrationTime(Zn, tdx)
                        ' Time to infiltrate to 2 * Zn
                        If (c < Zn) Then
                            Tn2 = mSoilCropProperties.InfiltrationTime(Zn * 2.0, tdx)
                        Else
                            Tn2 = mSoilCropProperties.InfiltrationTime(c * 2.0, tdx)
                        End If
                    End If

                    ' Limit infiltration curve to Tn*2 on X-axis or Zn*2 on Y-axis; whichever comes first
                    mCurveTime = Math.Min(Tn * 2.0, Tn2)

                    If (tdx < 0) Then ' scalar infiltration parameters
                        _curve = mSoilCropProperties.InfiltrationFunctionArrayList(mCurveTime, mPoints)
                    Else ' tabulated infiltration parameters
                        _curve = mSoilCropProperties.InfiltrationFunctionArrayList(mCurveTime, tdx, mPoints)
                    End If

                    If (Me.RefInflowPanel.Visible) Then ' Reference inflow rate controls are visible
                        If (mEventCriteria.ReferenceFlowRateSet.Value) Then ' and selected
                            Select Case (mEventCriteria.ReferenceFlowRate.Source)
                                Case ValueSources.Calculated, ValueSources.Remote, ValueSources.UserEntered ' and valid
                                    Dim _refQ0 As Double = mEventCriteria.ReferenceFlowRate.Value
                                    _refCurve = mSoilCropProperties.InfiltrationFunctionArrayList(_refQ0, mCurveTime, mPoints)

                                    Dim S0 As Double = mUnit.SystemGeometryRef.AverageSlope
                                    Dim L As Double = mUnit.SystemGeometryRef.Length.Value
                                    Dim W As Double = mUnit.SystemGeometryRef.WidthForCrossSection
                                    _refH0 = mUnit.UpstreamDepth(_refQ0, L, W, S0) ' Use Upstream Depth for h0

                            End Select
                        End If
                    End If

            End Select

            If (_curve IsNot Nothing) Then
                If (_curve.Count < 1) Then
                    Throw New Exception(_noInfiltrationErrMsg)
                End If
            Else
                Throw New Exception(_noInfiltrationErrMsg)
            End If

            Zmax = CDbl(_curve(_curve.Count - 1))
            '
            ' Draw Axes for curve
            '
            Dim _xAxis, _yAxis As Axis

            ' X-axis information (Infiltration Time)
            _xAxis.AxisLabel = mDictionary.tInfiltrationTime.Translated & " "
            _xAxis.MaxValue = mCurveTime
            _xAxis.MaxLabel = DataStore.TimeString(mCurveTime)

            ' Y-axis information (Infiltration)
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                _yAxis.AxisLabel = "Az / FS "
            Else
                _yAxis.AxisLabel = "Az / BW "
            End If
            _yAxis.MaxValue = Zmax
            _yAxis.MaxLabel = DataStore.DepthString(Zmax)

            DrawAxes(_bitmap, _quadrant, _xAxis, _yAxis, _offset, Me.Font)
            '
            ' Add tic marks along the X-axis (usually, one hour increments)
            '
            Dim _ticIncr As Double = OneHour
            Dim _ticTime As Double = OneHour
            Dim _ticks As Double = mCurveTime / _ticIncr

            ' Limit the number of tick marks to be drawn
            While (10000 < _ticks)
                _ticIncr *= 10.0
                _ticks = mCurveTime / _ticIncr
            End While

            ' Draw the tic marks
            If (mCurveTime < Double.MaxValue) Then
                While (_ticTime < mCurveTime)
                    Dim _ticMark As Integer = CInt(((_ticTime * mPoints) + (mCurveTime / 2.0)) / mCurveTime)

                    Dim _x As Integer = _ticMark + _offset
                    Dim _y As Integer = _bitmap.Height - _offset

                    _graphics.DrawLine(_gray, _x, _y - 2, _x, _y + 2)

                    _ticTime += _ticIncr
                End While
            End If
            '
            ' Draw the infiltration curve(s) on the previouly drawn axes
            '
            If Not (MatchingCurve Is Nothing) Then
                DrawCurve(_bitmap, _quadrant, _gray, _xAxis, _yAxis, _offset, _curve)
                DrawCurve(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, MatchingCurve)
            Else
                If (_refCurve IsNot Nothing) Then
                    DrawCurve(_bitmap, _quadrant, _blue, _xAxis, _yAxis, _offset, _refCurve)
                End If
                DrawCurve(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _curve)
            End If
            '
            ' If the Limiting Depth is enabled, draw the limiting depth if it is on the graph
            '
            Dim _limit As Double = Double.MaxValue

            If ((LimitingDepthControl.Visible = True) And (LimitingDepthControl.Enabled = True)) Then
                ' Limiting Depth is enabled; is limiting depth on graph?
                _limit = mSoilCropProperties.LimitingDepth.Value

                If ((0.0 < _limit) And (_limit < Zmax)) Then
                    ' Yes, draw limiting depth line
                    DrawHLine(_bitmap, _quadrant, _gray, _xAxis, _yAxis, _offset, _limit)
                Else
                    _limit = Double.MaxValue
                End If
            End If
            '
            ' If Zn cannot be reached; add a warning label
            '
            If ((Zmax < Zn) Or (_limit < Zn)) Then
                Dim _depth As String = DepthString(Zn)
                Dim _msg As String = mDictionary.tUnableToInfiltrateToDreq.Translated & " (" & _depth & ")"
                Dim _sizeF As SizeF = _graphics.MeasureString(_msg, Me.Font)
                Dim _grayBrush As SolidBrush = DarkGraySolidBrush()
                _graphics.DrawString(_msg, Me.Font, _grayBrush, _
                                    (_bitmap.Width / 2) - (_sizeF.Width / 2), _bitmap.Height / 2)

            Else ' Zn can be reached
                '
                ' Draw the required infiltration depth (Zn) and time (Tn)
                '
                For _idx As Integer = 0 To mPoints - 1
                    If (Zn <= CDbl(_curve(_idx))) Then
                        ' Infiltration has been met at this point
                        Dim _pt1x As Integer = _offset
                        Dim _pt2x As Integer = _offset + _idx
                        Dim _pt1y As Integer = CInt((CDbl(_curve(_idx)) * (_bitmap.Height - _offset)) / _yAxis.MaxValue)
                        Dim _pt2y As Integer = 0

                        Select Case _quadrant
                            Case QuadrantSelections.UpperRight
                                _pt1y = _bitmap.Height - _offset - _pt1y
                                _pt2y = _bitmap.Height - _offset - _pt2y
                            Case QuadrantSelections.LowerRight
                                _pt1y = _offset + _pt1y
                                _pt2y = _offset + _pt2y
                        End Select

                        _gray.DashStyle = Drawing2D.DashStyle.Dash
                        _graphics.DrawLine(_gray, _pt1x, _pt1y, _pt2x, _pt1y)
                        _graphics.DrawLine(_gray, _pt2x, _pt1y, _pt2x, _pt2y)

                        ' Mark & label Target Infiltration point
                        Dim _time As String = DataStore.TimeString(Tn)
                        Dim _depth As String = DataStore.DepthString(Zn)
                        Dim _label As String = "(" + _depth + ", " + _time + ")"

                        Dim _y As Double = CDbl(_curve(_idx))

                        If (Zn < c) Then
                            _y = Zn
                        End If

                        DrawPoint(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, Me.Font, _idx, _y, _label)

                        Exit For
                    End If
                Next _idx
            End If
            '
            ' For the Branch Function method, draw a point at the Branch Time
            '
            If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.BranchFunction) Then
                Try
                    ' Compute curve index for Tb (round to nearest point)
                    Dim _idx As Integer = CInt(((Tb * mPoints) + (mCurveTime / 2.0)) / mCurveTime)

                    If ((0 < _idx) And (_idx < mPoints)) Then
                        Dim _y As Double = CDbl(_curve(_idx))
                        DrawPoint(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, Me.Font, _idx, _y, Nothing)
                    End If
                Catch ex As Exception
                End Try
            End If
            '
            ' For the depth-dependent functions, add a warning label
            '
            If ((mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.GreenAmpt) _
             Or (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.WarrickGreenAmpt) _
             Or (mSoilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.LocalWettedPerimeter) _
             Or (mSoilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter)) Then
                Dim _idx As Integer = mPoints
                Dim _y As Double = 0.0
                Dim _txt As String = mDictionary.tInfiltrationBasedOnUpstreamFlowDepth.Translated & ": " & DepthString(h0)
                DrawText(_bitmap, _quadrant, Nothing, _offset, Me.Font, _idx, _y, _txt)
            End If

            If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.NRCSIntakeFamily) Then
                Dim _idx As Integer = mPoints
                Dim _y As Double = 0.0
                h0 = mSystemGeometry.FurrowFlowDepth(nrcs0)
                Dim _txt As String = mDictionary.tInfiltrationBasedOnUpstreamFlowDepth.Translated & ": " & DepthString(h0)
                DrawText(_bitmap, _quadrant, Nothing, _offset, Me.Font, _idx, _y, _txt)
            End If

            If (_refCurve IsNot Nothing) Then
                Dim _idx As Integer = mPoints
                Dim _y As Double = 32.0
                Dim _txt As String = mDictionary.tReferenceUpstreamFlowDepth.Translated & ": " & DepthString(_refH0)
                DrawText(_bitmap, _quadrant, _blueBrush, _offset, Me.Font, _idx, _y, _txt)
            End If

        Catch ex As Exception
            ' Ignore exceptions
            Dim _msg As String = mDictionary.tUnableToCompleteGraph.Translated
            If (ex.Message = _noInfiltrationErrMsg) Then
                _msg &= "; " & _noInfiltrationErrMsg
            End If
            Dim _sizeF As SizeF = _graphics.MeasureString(_msg, Me.Font)
            Dim _grayBrush As SolidBrush = DarkGraySolidBrush()
            _graphics.DrawString(_msg, Me.Font, _grayBrush, _
                                (_bitmap.Width / 2) - (_sizeF.Width / 2), _bitmap.Height / 2)

        Finally

            ' Copy the new bitmap into the image (this prevents flicker)
            If (InfiltrationGraphics.Image IsNot Nothing) Then
                InfiltrationGraphics.Image.Dispose()
                InfiltrationGraphics.Image = Nothing
            End If

            InfiltrationGraphics.Image = _bitmap
        End Try

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub NrcsOptionsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsOptionsButton.Click
        Dim db As NrcsIntakeFamilyOptions = New NrcsIntakeFamilyOptions(mSoilCropProperties)

        UpdateTranslation(db)

        Dim _result As DialogResult = DialogResult.OK
        _result = db.ShowDialog

        If (_result = DialogResult.OK) Then

            Dim method As IntegerParameter = mSoilCropProperties.NrcsToKostiakovMethod

            If Not (method.Value = db.NrcsToKostiakovMethod) Then

                ' Mark current state as an Undo point
                mMyStore.MarkForUndo(mDictionary.tNrcsOptionChange.Translated)

                ' Set the new value
                method.Value = db.NrcsToKostiakovMethod
                method.Source = DataStore.Globals.ValueSources.UserEntered
                mSoilCropProperties.NrcsToKostiakovMethod = method

            End If
        End If
    End Sub

    Private Sub SelectHydrusProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SelectHydrusProjectButton.Click

        ' Get current HYDRUS project folder, if any
        Dim hydrusProject As StringParameter = mSoilCropProperties.HydrusProject
        Dim hydrusPath As String = hydrusProject.Value

        ' If none specified, or it's default, use WinSRFR project folder, if any
        If ((hydrusPath = "") Or (hydrusPath.Contains(DefaultHydrusInfiltrationFilename))) Then
            hydrusPath = WinSRFR.FilePath
            Dim lastBackslash As Integer = hydrusPath.LastIndexOf("\")
            If (0 < lastBackslash) Then
                hydrusPath = hydrusPath.Substring(0, lastBackslash)
            Else
                hydrusPath = ""
            End If
        End If

        ' Create/initialize FolderBrowserDialog so user can choose HYDRUS project folder
        Dim browser As FolderBrowserDialog = New FolderBrowserDialog
        browser.SelectedPath = hydrusPath

        ' Show browser dialog and get user's response
        Dim result As DialogResult = browser.ShowDialog

        ' Check if HYDRUS project folder was selected
        If (result = DialogResult.OK) Then
            ' Mark current state as an Undo point
            mMyStore.MarkForUndo(mDictionary.tHydrusProjectChange.Translated)

            ' Save HYDRUS project folder
            hydrusProject.Value = browser.SelectedPath
            hydrusProject.Source = ValueSources.UserEntered
            mSoilCropProperties.HydrusProject = hydrusProject
        End If

    End Sub

    Private Sub UseInfiltrationEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles UseInfiltrationEditorButton.Click

        ' Instantiate Infiltration Function Editor, link it to WinSRFR objects; then display it
        mInfFuncEditor = New InfiltrationFunctionEditor(InfiltrationFunctionEditor.MatchTypes.MatchDepths)
        mInfFuncEditor.WinSrfrAnalysis = mAnalysis
        mInfFuncEditor.WinSrfrUnit = mUnit

        Dim meLoc As Point = Me.PointToScreen(New Point(0, 0))

        meLoc.X -= mInfFuncEditor.Width + 16
        meLoc.X = Math.Max(8, meLoc.X)

        meLoc.Y -= (mInfFuncEditor.Height - Me.Height) / 2

        mInfFuncEditor.Location = meLoc

        mInfFuncResult = mInfFuncEditor.ShowDialog()

    End Sub

    Private Sub RefInflowRateSelect_ControlValueChanged() _
    Handles RefInflowRateSelect.ControlValueChanged
        If (RefInflowRateSelect.Checked) Then
            ' When user selects to use the Reference Inflow Rate; set Default -> User Entered
            Dim refFlowParam As DoubleParameter = mEventCriteria.ReferenceFlowRate
            If (refFlowParam.Source = ValueSources.Defaulted) Then
                refFlowParam.Source = ValueSources.UserEntered
                mEventCriteria.ReferenceFlowRate = refFlowParam
            End If
        End If
    End Sub

    Private Const MinInfiltrationGroupBoxHeight As Integer = 414

    Private Const MinInfiltrationGraphHeight As Integer = 128
    Private Const MinInfiltrationFunctionPanelHeight As Integer = 90
    Private Const MinInfiltrationEquationPanelHeight As Integer = 141

    Private Sub InfiltrationControl_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        ' Set new size of the InfiltrationGroupBox
        Dim boxHeight As Integer = MyBase.Height - Me.InfiltrationGroupBox.Margin.Top - Me.InfiltrationGroupBox.Margin.Bottom
        Dim boxWidth As Integer = MyBase.Width - Me.InfiltrationGroupBox.Margin.Left - Me.InfiltrationGroupBox.Margin.Right

        Me.InfiltrationGroupBox.Height = boxHeight
        Me.InfiltrationGroupBox.Width = boxWidth

        ' Set new location & size of editor button & simulation options panel
        Dim ctrlLoc As Point = New Point

        ctrlLoc.X = boxWidth - Me.SimOptsPanel.Width - 2
        ctrlLoc.Y = boxHeight - Me.SimOptsPanel.Height - 2
        Me.SimOptsPanel.Location = ctrlLoc

        If (MinInfiltrationGroupBoxHeight < Me.InfiltrationGroupBox.Height - Me.SimOptsPanel.Height) Then
            Me.UseInfiltrationEditorButton.AutoSize = True
            Me.UseInfiltrationEditorButton.Text = mDictionary.tUseInfiltrationFunctionEditor.Translated

            ctrlLoc.X = 6
            ctrlLoc.Y -= Me.SimOptsPanel.Height
            Me.UseInfiltrationEditorButton.Location = ctrlLoc
        Else
            Me.UseInfiltrationEditorButton.AutoSize = False
            Me.UseInfiltrationEditorButton.Text = mDictionary.tUseEditor.Translated

            ctrlLoc.X = 6
            Me.UseInfiltrationEditorButton.Location = ctrlLoc
            Me.UseInfiltrationEditorButton.Size = New Size(66, 24)
        End If

        ' Size/locate controls based on available space
        Dim availHeight As Integer = ctrlLoc.Y - Me.InfiltrationFunctionPanel.Height - 24
        Dim ctrlHeight As Integer = Math.Max(availHeight / 2, MinInfiltrationEquationPanelHeight)
        Dim ctrlWidth As Integer = boxWidth - 16
        Dim graphHeight As Integer = availHeight - ctrlHeight

        ' Size Infiltration Graphics
        Me.InfiltrationGraphics.Height = graphHeight
        Me.InfiltrationGraphics.Width = ctrlWidth
        Me.UpdateGraphics()

        ' Locate & Size Infiltration Function Panel
        ctrlLoc.X = ctrlWidth / 2 - Me.InfiltrationFunctionPanel.Width / 2 + 1
        ctrlLoc.Y = Me.InfiltrationGraphics.Location.Y + Me.InfiltrationGraphics.Height
        Me.InfiltrationFunctionPanel.Location = ctrlLoc

        ' Locate & Size Infiltration Equation Parameters controls
        ctrlLoc.X = ctrlWidth / 2 - Me.ModifiedKostiakovPanel.Width / 2
        ctrlLoc.Y = ctrlHeight / 2 - Me.ModifiedKostiakovPanel.Height / 2
        ctrlLoc.Y += Me.InfiltrationFunctionPanel.Location.Y + Me.InfiltrationFunctionPanel.Height

        Me.BranchFunctionPanel.Location = ctrlLoc
        Me.CharacteristicInfiltrationPanel.Location = ctrlLoc
        Me.GreenAmptPanel.Location = ctrlLoc
        Me.Hydrus1DPanel.Location = ctrlLoc
        Me.KostiakovPanel.Location = ctrlLoc
        Me.ModifiedKostiakovPanel.Location = ctrlLoc
        Me.NrcsIntakePanel.Location = ctrlLoc
        Me.TimeRatedIntakePanel.Location = ctrlLoc
        Me.WarrickGreenAmptPanel.Location = ctrlLoc

        ' Locate & Size Infiltration Table controls
        ctrlLoc.X = 3
        ctrlLoc.Y = Me.InfiltrationFunctionPanel.Location.Y + Me.InfiltrationFunctionPanel.Height

        If Not (Me.UseInfiltrationEditorButton.Location.Y = Me.SimOptsPanel.Location.Y) Then
            ctrlHeight += Me.UseInfiltrationEditorButton.Height
        End If

        Me.TabulatedBranchPanel.Location = ctrlLoc
        Me.TabulatedBranchPanel.Height = ctrlHeight
        Me.TabulatedBranchPanel.Width = ctrlWidth
        Me.TabulatedBranchFunctionControl.UpdateUI()

        Me.TabulatedCharacteristicTimePanel.Location = ctrlLoc
        Me.TabulatedCharacteristicTimePanel.Height = ctrlHeight
        Me.TabulatedCharacteristicTimePanel.Width = ctrlWidth
        Me.TabulatedCharacteristicTimeControl.UpdateUI()

        Me.TabulatedGreenAmptPanel.Location = ctrlLoc
        Me.TabulatedGreenAmptPanel.Height = ctrlHeight
        Me.TabulatedGreenAmptPanel.Width = ctrlWidth
        Me.TabulatedGreenAmptControl.UpdateUI()

        Me.TabulatedHydrusPanel.Location = ctrlLoc
        Me.TabulatedHydrusPanel.Height = ctrlHeight
        Me.TabulatedHydrusPanel.Width = ctrlWidth
        Me.TabulatedHydrusControl.UpdateUI()

        Me.TabulatedKostiakovPanel.Location = ctrlLoc
        Me.TabulatedKostiakovPanel.Height = ctrlHeight
        Me.TabulatedKostiakovPanel.Width = ctrlWidth
        Me.TabulatedKostiakovControl.UpdateUI()

        Me.TabulatedModifiedKostiakovPanel.Location = ctrlLoc
        Me.TabulatedModifiedKostiakovPanel.Height = ctrlHeight
        Me.TabulatedModifiedKostiakovPanel.Width = ctrlWidth
        Me.TabulatedModifiedKostiakovControl.UpdateUI()

        Me.TabulatedNrcsIntakePanel.Location = ctrlLoc
        Me.TabulatedNrcsIntakePanel.Height = ctrlHeight
        Me.TabulatedNrcsIntakePanel.Width = ctrlWidth
        Me.TabulatedNrcsIntakeControl.UpdateUI()

        Me.TabulatedTimeRatedPanel.Location = ctrlLoc
        Me.TabulatedTimeRatedPanel.Height = ctrlHeight
        Me.TabulatedTimeRatedPanel.Width = ctrlWidth
        Me.TabulatedTimeRatedControl.UpdateUI()

        Me.TabulatedWarrickGreenAmptPanel.Location = ctrlLoc
        Me.TabulatedWarrickGreenAmptPanel.Height = ctrlHeight
        Me.TabulatedWarrickGreenAmptPanel.Width = ctrlWidth
        Me.TabulatedWarrickGreenAmptControl.UpdateUI()

    End Sub
    '
    ' Make sure UI is up to date whenever it become visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

#Region " Tabulated Infiltration Handlers "
    '
    ' Enable Tabulated Infiltration
    '
    Private Sub TabulatedInfiltrationSelect_ControlValueChanged() _
    Handles TabulatedInfiltrationSelect.ControlValueChanged
        UpdateUI()
    End Sub
    '
    ' Characteristic Time
    '
    Private Sub TabulatedCharacteristicTimeControl_ControlValueChanged() _
    Handles TabulatedCharacteristicTimeControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub TabulatedCharacteristicTimeControl_RowChanged() _
    Handles TabulatedCharacteristicTimeControl.RowChanged
        UpdateGraphics()
    End Sub
    '
    ' NRCS Intake Family
    '
    Private Sub TabulatedNrcsIntakeControl_ControlValueChanged() _
    Handles TabulatedNrcsIntakeControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub TabulatedNrcsIntakeControl_RowChanged() _
    Handles TabulatedNrcsIntakeControl.RowChanged
        UpdateGraphics()
    End Sub
    '
    ' Time-Rated Intake Family
    '
    Private Sub TabulatedTimeRatedControl_ControlValueChanged() _
    Handles TabulatedTimeRatedControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub TabulatedTimeRatedControl_RowChanged() _
    Handles TabulatedTimeRatedControl.RowChanged
        UpdateGraphics()
    End Sub
    '
    ' Kostiakov Formula
    '
    Private Sub TabulatedKostiakovControl_ControlValueChanged() _
    Handles TabulatedKostiakovControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub TabulatedKostiakovControl_RowChanged() _
    Handles TabulatedKostiakovControl.RowChanged
        UpdateGraphics()
    End Sub
    '
    ' Modified Kostiakov
    '
    Private Sub TabulatedModifiedKostiakovControl_ControlValueChanged() _
    Handles TabulatedModifiedKostiakovControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub TabulatedModifiedKostiakovControl_RowChanged() _
    Handles TabulatedModifiedKostiakovControl.RowChanged
        UpdateGraphics()
    End Sub
    '
    ' Branch Function
    '
    Private Sub TabulatedBranchFunctionControl_ControlValueChanged() _
    Handles TabulatedBranchFunctionControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub TabulatedBranchFunctionControl_RowChanged() _
    Handles TabulatedBranchFunctionControl.RowChanged
        UpdateGraphics()
    End Sub
    '
    ' Green-Ampt
    '
    Private Sub TabulatedGreenAmptControl_ControlValueChanged() _
    Handles TabulatedGreenAmptControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub TabulatedGreenAmptControl_RowChanged() _
    Handles TabulatedGreenAmptControl.RowChanged
        UpdateGraphics()
    End Sub
    '
    ' Warrick / Green-Ampt
    '
    Private Sub TabulatedWarrickGreenAmptControl_ControlValueChanged() _
    Handles TabulatedWarrickGreenAmptControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub TabulatedWarrickGreenAmptControl_RowChanged() _
    Handles TabulatedWarrickGreenAmptControl.RowChanged
        UpdateGraphics()
    End Sub

#End Region

#Region " Infiltration Method Control Event Handlers "

    ' Update the calculated default Branch Time whenever a dependent variable changes
    Private Sub BF_BranchBControl_ControlValueChanged() _
    Handles BF_BranchBControl.ControlValueChanged
        Me.BF_BranchTimeControl.UpdateUI()
    End Sub

    Private Sub BF_KostiakovAControl_ControlValueChanged() _
    Handles BF_KostiakovAControl.ControlValueChanged
        Me.BF_BranchTimeControl.UpdateUI()
    End Sub

    Private Sub BF_KostiakovKControl_ControlValueChanged() _
    Handles BF_KostiakovKControl.ControlValueChanged
        Me.BF_BranchTimeControl.UpdateUI()
    End Sub

    ' Update Wetted Perimeter whenever Infiltration Equation changes
    Private Sub InfiltrationEquationControl_ControlValueChanged() _
    Handles InfiltrationEquationControl.ControlValueChanged

        ' For Furrows, Wetted Perimeter must match the Infiltration Method
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim _wettedPerimeter As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod

            Select Case (mSoilCropProperties.InfiltrationFunction.Value)

                Case InfiltrationFunctions.NRCSIntakeFamily
                    ' NRCS Intake Family should use NRCS Empirical Function
                    _wettedPerimeter.Value = WettedPerimeterMethods.NrcsEmpiricalFunction

                Case InfiltrationFunctions.CharacteristicInfiltrationTime
                    ' Characteristic Infiltration Time should use Furrow Spacing
                    _wettedPerimeter.Value = WettedPerimeterMethods.FurrowSpacing

                Case InfiltrationFunctions.TimeRatedIntakeFamily
                    ' Time-Rated Families should use Representative Upstream Wetted Perimeter
                    _wettedPerimeter.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter

                Case InfiltrationFunctions.Hydrus1D
                    Debug.Assert(False, "HYDRUS-1D not supported")

                Case InfiltrationFunctions.WarrickGreenAmpt
                    ' Warrick Green-Ampt handles Wetted Perimeter itself (i.e. Local)
                    _wettedPerimeter.Value = WettedPerimeterMethods.LocalWettedPerimeter

                Case Else ' Kostiakov, Branch, Green-Ampt, etc.
                    ' These should not use NRCS Wetted Perimeter
                    If (_wettedPerimeter.Value = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
                        _wettedPerimeter.Value = WettedPerimeterMethods.FurrowSpacing
                    End If
            End Select

            If Not (_wettedPerimeter.Value = mSoilCropProperties.WettedPerimeterMethod.Value) Then

                _wettedPerimeter.Source = DataStore.Globals.ValueSources.Calculated
                mSoilCropProperties.WettedPerimeterMethod = _wettedPerimeter

                mSoilCropProperties.WettedPerimeterMethodProperty.RecordCommand()

            End If
        End If

    End Sub

#End Region

#Region " Wetted Perimeter Control Event Handlers "
    '
    ' Selectively, display/match New Wetted Perimeter dialog box on Wetted Perimeter changes
    '
    Private Sub WettedPerimeterControl_PreSaveAction(ByRef selection As Integer, ByRef saveOk As Boolean) _
    Handles WettedPerimeterControl.PreSaveAction
        saveOk = False
        If (mAnalysis IsNot Nothing) Then
            mAnalysis.WettedPerimeterMessage(selection)
            saveOk = True
        End If
    End Sub

    Private Sub WettedPerimeterControl_ControlValueChanged() _
    Handles WettedPerimeterControl.ControlValueChanged
        Dim IEparam As IntegerParameter = mSoilCropProperties.InfiltrationFunction
        Dim IEvalue As Integer = IEparam.Value

        Dim WPparam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
        Dim WPmethod As WettedPerimeterMethods = WPparam.Value
        If (WPmethod = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
            If Not (IEvalue = InfiltrationFunctions.NRCSIntakeFamily) Then
                IEparam.Value = InfiltrationFunctions.NRCSIntakeFamily
                IEparam.Source = ValueSources.Calculated
                mSoilCropProperties.InfiltrationFunction = IEparam
            End If
        Else
            If (IEvalue = InfiltrationFunctions.NRCSIntakeFamily) Then
                IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula
                IEparam.Source = ValueSources.Calculated
                mSoilCropProperties.InfiltrationFunction = IEparam
            End If
        End If

        If (mAnalysis IsNot Nothing) Then
            mAnalysis.ConvertWettedPerimeter()
        End If
    End Sub

#End Region

#Region " Soil Texture Control Event Handlers "

    Private Sub GA_SoilTextureControl_ControlValueChanged() _
    Handles GA_SoilTextureControl.ControlValueChanged

        Dim texture As Integer = mSoilCropProperties.SoilTextureSelectionGA.Value
        Dim soilProperties As Srfr.Infiltration.SoilProperties = Srfr.Infiltration.SoilPropertiesTable(texture)
        Dim doubleParam As DoubleParameter = Nothing

        doubleParam = mSoilCropProperties.EffectivePorosityGA
        doubleParam.Value = soilProperties.EffectivePorosity
        doubleParam.Source = ValueSources.Defaulted
        mSoilCropProperties.EffectivePorosityGA = doubleParam

        doubleParam = mSoilCropProperties.InitialWaterContentGA
        doubleParam.Value = soilProperties.InitialWaterContent
        doubleParam.Source = ValueSources.Defaulted
        mSoilCropProperties.InitialWaterContentGA = doubleParam

        doubleParam = mSoilCropProperties.WettingFrontPressureHeadGA
        doubleParam.Value = soilProperties.WettingFrontPressureHead
        doubleParam.Source = ValueSources.Defaulted
        mSoilCropProperties.WettingFrontPressureHeadGA = doubleParam

        doubleParam = mSoilCropProperties.HydraulicConductivityGA
        doubleParam.Value = soilProperties.HydraulicConductivity
        doubleParam.Source = ValueSources.Defaulted
        mSoilCropProperties.HydraulicConductivityGA = doubleParam

    End Sub

    Private Sub WGA_SoilTextureControl_ControlValueChanged() _
    Handles WGA_SoilTextureControl.ControlValueChanged

        Dim texture As Integer = mSoilCropProperties.SoilTextureSelectionWGA.Value
        Dim soilProperties As Srfr.Infiltration.SoilProperties = Srfr.Infiltration.SoilPropertiesTable(texture)
        Dim doubleParam As DoubleParameter = Nothing

        doubleParam = mSoilCropProperties.SaturatedWaterContentWGA
        doubleParam.Value = soilProperties.EffectivePorosity
        doubleParam.Source = ValueSources.Defaulted
        mSoilCropProperties.SaturatedWaterContentWGA = doubleParam

        doubleParam = mSoilCropProperties.InitialWaterContentWGA
        doubleParam.Value = soilProperties.InitialWaterContent
        doubleParam.Source = ValueSources.Defaulted
        mSoilCropProperties.InitialWaterContentWGA = doubleParam

        doubleParam = mSoilCropProperties.WettingFrontPressureHeadWGA
        doubleParam.Value = soilProperties.WettingFrontPressureHead
        doubleParam.Source = ValueSources.Defaulted
        mSoilCropProperties.WettingFrontPressureHeadWGA = doubleParam

        doubleParam = mSoilCropProperties.HydraulicConductivityWGA
        doubleParam.Value = soilProperties.HydraulicConductivity
        doubleParam.Source = ValueSources.Defaulted
        mSoilCropProperties.HydraulicConductivityWGA = doubleParam

    End Sub

#End Region

End Class
