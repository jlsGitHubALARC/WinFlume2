<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_Evalue
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
        Me.StandardInfiltrationGroup = New DataStore.ctl_GroupBox()
        Me.RefInflowPanel = New DataStore.ctl_Panel()
        Me.RefInflowLabel = New DataStore.ctl_Label()
        Me.RefInflowRateControl = New DataStore.ctl_DoubleParameter()
        Me.StdInfiltrationEquationControl = New DataStore.ctl_SelectParameter()
        Me.StdInfiltrationEquationLabel = New DataStore.ctl_Label()
        Me.StdWettedPerimeterLabel = New DataStore.ctl_Label()
        Me.ShowAdvancedFunctions = New DataStore.ctl_Button()
        Me.StdInfiltrationHelp = New DataStore.ctl_Button()
        Me.StdWettedPerimeterControl = New DataStore.ctl_SelectParameter()
        Me.EvalueBox = New DataStore.ctl_GroupBox()
        Me.UseInfiltrationEditorButton = New DataStore.ctl_Button()
        Me.AdvancedInfiltrationGroup = New DataStore.ctl_GroupBox()
        Me.AdvInfiltrationEquationControl = New DataStore.ctl_SelectParameter()
        Me.AdvInfiltrationEquationLabel = New DataStore.ctl_Label()
        Me.AdvWettedPerimeterLabel = New DataStore.ctl_Label()
        Me.AdvWettedPerimeterControl = New DataStore.ctl_SelectParameter()
        Me.ShowStandardFunctions = New DataStore.ctl_Button()
        Me.AdvInfiltrationHelp = New DataStore.ctl_Button()
        Me.BranchFunctionBox = New DataStore.ctl_GroupBox()
        Me.BF_BranchTimeControl = New DataStore.ctl_DoubleParameter()
        Me.BF_BranchTimeSet = New DataStore.ctl_CheckParameter()
        Me.BF_BranchTimeValue = New DataStore.ctl_Label()
        Me.BF_kControl = New WinMain.ctl_KostiakovKParameter()
        Me.BF_cControl = New DataStore.ctl_DoubleParameter()
        Me.BF_Instructions = New DataStore.ctl_Label()
        Me.BF_kLabel = New System.Windows.Forms.Label()
        Me.BF_bControl = New WinMain.ctl_KostiakovBParameter()
        Me.BF_aControl = New DataStore.ctl_DoubleParameter()
        Me.BF_cLabel = New System.Windows.Forms.Label()
        Me.BF_bLabel = New System.Windows.Forms.Label()
        Me.BF_aLabel = New System.Windows.Forms.Label()
        Me.TimeRatedFamilyBox = New DataStore.ctl_GroupBox()
        Me.TR_KostiakovA = New System.Windows.Forms.Label()
        Me.TR_KostiakovK = New System.Windows.Forms.Label()
        Me.TR_Instructions = New DataStore.ctl_Label()
        Me.TR_InfiltrationDepthControl = New DataStore.ctl_Label()
        Me.TR_InfiltrationTimeControl = New DataStore.ctl_DoubleParameter()
        Me.TR_InfiltrationTimeLabel = New DataStore.ctl_Label()
        Me.TR_InfiltrationDepthLabel = New DataStore.ctl_Label()
        Me.CharacteristicTimeBox = New DataStore.ctl_GroupBox()
        Me.KT_KostiakovK = New System.Windows.Forms.Label()
        Me.KT_WettedPerimeter = New DataStore.ctl_Label()
        Me.KT_Instructions = New DataStore.ctl_Label()
        Me.KT_InfiltrationTimeControl = New DataStore.ctl_DoubleParameter()
        Me.KT_KostiakovAControl = New DataStore.ctl_DoubleParameter()
        Me.KT_InfiltrationDepthControl = New DataStore.ctl_DoubleParameter()
        Me.KT_InfiltrationTimeLabel = New DataStore.ctl_Label()
        Me.KT_KostiakovALabel = New System.Windows.Forms.Label()
        Me.KT_InfiltrationDepthLabel = New DataStore.ctl_Label()
        Me.ModifiedKostiakovBox = New DataStore.ctl_GroupBox()
        Me.MK_aControl = New DataStore.ctl_DoubleParameter()
        Me.MK_kControl = New WinMain.ctl_KostiakovKParameter()
        Me.MK_cControl = New DataStore.ctl_DoubleParameter()
        Me.MK_Instructions = New DataStore.ctl_Label()
        Me.MK_kLabel = New System.Windows.Forms.Label()
        Me.MK_bControl = New WinMain.ctl_KostiakovBParameter()
        Me.MK_cLabel = New System.Windows.Forms.Label()
        Me.MK_bLabel = New System.Windows.Forms.Label()
        Me.MK_aLabel = New System.Windows.Forms.Label()
        Me.GreenAmptBox = New DataStore.ctl_GroupBox()
        Me.GA_Instructions = New DataStore.ctl_Label()
        Me.GA_cControl = New DataStore.ctl_DoubleParameter()
        Me.GAcLabel = New DataStore.ctl_Label()
        Me.GA_HydraulicConductivityControl = New DataStore.ctl_DoubleParameter()
        Me.HydraulicConductivityLabel = New DataStore.ctl_Label()
        Me.GA_WettingFrontControl = New DataStore.ctl_DoubleParameter()
        Me.AirEntryPressureLabel = New DataStore.ctl_Label()
        Me.GA_InitVolWaterContentControl = New DataStore.ctl_DoubleParameter()
        Me.InitVolWaterContentLabel = New DataStore.ctl_Label()
        Me.GA_PorosityControl = New DataStore.ctl_DoubleParameter()
        Me.EffectivePorosityLabel = New DataStore.ctl_Label()
        Me.WarrickGreenAmptBox = New DataStore.ctl_GroupBox()
        Me.WGA_Instructions = New DataStore.ctl_Label()
        Me.WGA_cControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_InstantaneousInfiltrationLabel = New DataStore.ctl_Label()
        Me.WGA_HydraulicConductivityControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_HydraulicConductivityLabel = New DataStore.ctl_Label()
        Me.WGA_WettingFrontControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_WettingFrontLabel = New DataStore.ctl_Label()
        Me.WGA_InitWaterContentControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_InitWaterContentLabel = New DataStore.ctl_Label()
        Me.WGA_SatWaterContentControl = New DataStore.ctl_DoubleParameter()
        Me.WGA_SatWaterContentLabel = New DataStore.ctl_Label()
        Me.NrcsIntakeFamilyGroup = New DataStore.ctl_GroupBox()
        Me.NrcsInstruction = New DataStore.ctl_Label()
        Me.NrcsOptionsButton = New DataStore.ctl_Button()
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
        Me.KostiakovFormulaBox = New DataStore.ctl_GroupBox()
        Me.KF_kControl = New WinMain.ctl_KostiakovKParameter()
        Me.KF_Instructions = New DataStore.ctl_Label()
        Me.KF_kLabel = New System.Windows.Forms.Label()
        Me.KF_aControl = New DataStore.ctl_DoubleParameter()
        Me.KF_aLabel = New System.Windows.Forms.Label()
        Me.StandardInfiltrationGroup.SuspendLayout()
        Me.RefInflowPanel.SuspendLayout()
        Me.EvalueBox.SuspendLayout()
        Me.AdvancedInfiltrationGroup.SuspendLayout()
        Me.BranchFunctionBox.SuspendLayout()
        Me.TimeRatedFamilyBox.SuspendLayout()
        Me.CharacteristicTimeBox.SuspendLayout()
        Me.ModifiedKostiakovBox.SuspendLayout()
        Me.GreenAmptBox.SuspendLayout()
        Me.WarrickGreenAmptBox.SuspendLayout()
        Me.NrcsIntakeFamilyGroup.SuspendLayout()
        Me.KostiakovFormulaBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'StandardInfiltrationGroup
        '
        Me.StandardInfiltrationGroup.AccessibleDescription = "Select the function to use for the estimation of the field's infiltration paramet" &
    "ers."
        Me.StandardInfiltrationGroup.AccessibleName = "EVALUE Infiltration Function"
        Me.StandardInfiltrationGroup.Controls.Add(Me.RefInflowPanel)
        Me.StandardInfiltrationGroup.Controls.Add(Me.StdInfiltrationEquationControl)
        Me.StandardInfiltrationGroup.Controls.Add(Me.StdInfiltrationEquationLabel)
        Me.StandardInfiltrationGroup.Controls.Add(Me.StdWettedPerimeterLabel)
        Me.StandardInfiltrationGroup.Controls.Add(Me.ShowAdvancedFunctions)
        Me.StandardInfiltrationGroup.Controls.Add(Me.StdInfiltrationHelp)
        Me.StandardInfiltrationGroup.Controls.Add(Me.StdWettedPerimeterControl)
        Me.StandardInfiltrationGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StandardInfiltrationGroup.Location = New System.Drawing.Point(6, 18)
        Me.StandardInfiltrationGroup.Name = "StandardInfiltrationGroup"
        Me.StandardInfiltrationGroup.Size = New System.Drawing.Size(358, 137)
        Me.StandardInfiltrationGroup.TabIndex = 0
        Me.StandardInfiltrationGroup.TabStop = False
        Me.StandardInfiltrationGroup.Text = "Select"
        '
        'RefInflowPanel
        '
        Me.RefInflowPanel.AccessibleDescription = ""
        Me.RefInflowPanel.AccessibleName = ""
        Me.RefInflowPanel.Controls.Add(Me.RefInflowLabel)
        Me.RefInflowPanel.Controls.Add(Me.RefInflowRateControl)
        Me.RefInflowPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowPanel.Location = New System.Drawing.Point(4, 72)
        Me.RefInflowPanel.Name = "RefInflowPanel"
        Me.RefInflowPanel.Size = New System.Drawing.Size(351, 30)
        Me.RefInflowPanel.TabIndex = 6
        '
        'RefInflowLabel
        '
        Me.RefInflowLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowLabel.Location = New System.Drawing.Point(2, 3)
        Me.RefInflowLabel.Name = "RefInflowLabel"
        Me.RefInflowLabel.Size = New System.Drawing.Size(238, 23)
        Me.RefInflowLabel.TabIndex = 1
        Me.RefInflowLabel.Text = "&Reference Inflow Rate"
        Me.RefInflowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RefInflowRateControl
        '
        Me.RefInflowRateControl.AccessibleDescription = "Specifies the reference inflow rate."
        Me.RefInflowRateControl.AccessibleName = "Reference Inflow Rate"
        Me.RefInflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RefInflowRateControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowRateControl.IsCalculated = False
        Me.RefInflowRateControl.IsInteger = False
        Me.RefInflowRateControl.Location = New System.Drawing.Point(246, 3)
        Me.RefInflowRateControl.MaxErrMsg = ""
        Me.RefInflowRateControl.MinErrMsg = ""
        Me.RefInflowRateControl.Name = "RefInflowRateControl"
        Me.RefInflowRateControl.Size = New System.Drawing.Size(102, 24)
        Me.RefInflowRateControl.TabIndex = 2
        Me.RefInflowRateControl.ToBeCalculated = True
        Me.RefInflowRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.RefInflowRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.RefInflowRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.RefInflowRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.RefInflowRateControl.ValueText = ""
        '
        'StdInfiltrationEquationControl
        '
        Me.StdInfiltrationEquationControl.AccessibleDescription = "Selects the Infiltration Equation for entering the infiltration parameters.  The " &
    "Dialogs tab under User Preferences controls operation when a new method is selec" &
    "ted."
        Me.StdInfiltrationEquationControl.AccessibleName = "Infiltration Equation"
        Me.StdInfiltrationEquationControl.ApplicationValue = -1
        Me.StdInfiltrationEquationControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StdInfiltrationEquationControl.EnableSaveActions = False
        Me.StdInfiltrationEquationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StdInfiltrationEquationControl.IsCalculated = False
        Me.StdInfiltrationEquationControl.Location = New System.Drawing.Point(134, 46)
        Me.StdInfiltrationEquationControl.Name = "StdInfiltrationEquationControl"
        Me.StdInfiltrationEquationControl.SelectedIndexSet = False
        Me.StdInfiltrationEquationControl.Size = New System.Drawing.Size(222, 24)
        Me.StdInfiltrationEquationControl.TabIndex = 5
        '
        'StdInfiltrationEquationLabel
        '
        Me.StdInfiltrationEquationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StdInfiltrationEquationLabel.Location = New System.Drawing.Point(1, 43)
        Me.StdInfiltrationEquationLabel.Name = "StdInfiltrationEquationLabel"
        Me.StdInfiltrationEquationLabel.Size = New System.Drawing.Size(130, 23)
        Me.StdInfiltrationEquationLabel.TabIndex = 4
        Me.StdInfiltrationEquationLabel.Text = "&Infiltration Equation"
        Me.StdInfiltrationEquationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StdWettedPerimeterLabel
        '
        Me.StdWettedPerimeterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StdWettedPerimeterLabel.Location = New System.Drawing.Point(1, 17)
        Me.StdWettedPerimeterLabel.Name = "StdWettedPerimeterLabel"
        Me.StdWettedPerimeterLabel.Size = New System.Drawing.Size(130, 23)
        Me.StdWettedPerimeterLabel.TabIndex = 1
        Me.StdWettedPerimeterLabel.Text = "&Wetted Perimeter"
        Me.StdWettedPerimeterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ShowAdvancedFunctions
        '
        Me.ShowAdvancedFunctions.AccessibleDescription = "Provides instructions for estimating Green-Ampt parameters"
        Me.ShowAdvancedFunctions.AccessibleName = "Green-Ampt Help"
        Me.ShowAdvancedFunctions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowAdvancedFunctions.Location = New System.Drawing.Point(12, 107)
        Me.ShowAdvancedFunctions.Name = "ShowAdvancedFunctions"
        Me.ShowAdvancedFunctions.Size = New System.Drawing.Size(255, 24)
        Me.ShowAdvancedFunctions.TabIndex = 10
        Me.ShowAdvancedFunctions.Text = "Show Depth-Dependent E&quations"
        Me.ShowAdvancedFunctions.UseVisualStyleBackColor = True
        '
        'StdInfiltrationHelp
        '
        Me.StdInfiltrationHelp.AccessibleDescription = "Provides instructions for estimating Green-Ampt parameters"
        Me.StdInfiltrationHelp.AccessibleName = "Green-Ampt Help"
        Me.StdInfiltrationHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StdInfiltrationHelp.Location = New System.Drawing.Point(275, 107)
        Me.StdInfiltrationHelp.Name = "StdInfiltrationHelp"
        Me.StdInfiltrationHelp.Size = New System.Drawing.Size(75, 24)
        Me.StdInfiltrationHelp.TabIndex = 11
        Me.StdInfiltrationHelp.Text = "&Help"
        Me.StdInfiltrationHelp.UseVisualStyleBackColor = True
        '
        'StdWettedPerimeterControl
        '
        Me.StdWettedPerimeterControl.AccessibleDescription = "Selects the method for describing the wetted perimeter."
        Me.StdWettedPerimeterControl.AccessibleName = "Wetted Perimeter"
        Me.StdWettedPerimeterControl.ApplicationValue = -1
        Me.StdWettedPerimeterControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StdWettedPerimeterControl.EnableSaveActions = False
        Me.StdWettedPerimeterControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StdWettedPerimeterControl.IsCalculated = False
        Me.StdWettedPerimeterControl.Location = New System.Drawing.Point(134, 19)
        Me.StdWettedPerimeterControl.Name = "StdWettedPerimeterControl"
        Me.StdWettedPerimeterControl.SelectedIndexSet = False
        Me.StdWettedPerimeterControl.Size = New System.Drawing.Size(222, 24)
        Me.StdWettedPerimeterControl.TabIndex = 2
        '
        'EvalueBox
        '
        Me.EvalueBox.AccessibleDescription = "Evaluates the performance of an irrigation to determine the field's infiltration " &
    "characteristics."
        Me.EvalueBox.AccessibleName = "EVALUE Solution"
        Me.EvalueBox.Controls.Add(Me.UseInfiltrationEditorButton)
        Me.EvalueBox.Controls.Add(Me.BranchFunctionBox)
        Me.EvalueBox.Controls.Add(Me.TimeRatedFamilyBox)
        Me.EvalueBox.Controls.Add(Me.CharacteristicTimeBox)
        Me.EvalueBox.Controls.Add(Me.ModifiedKostiakovBox)
        Me.EvalueBox.Controls.Add(Me.GreenAmptBox)
        Me.EvalueBox.Controls.Add(Me.WarrickGreenAmptBox)
        Me.EvalueBox.Controls.Add(Me.NrcsIntakeFamilyGroup)
        Me.EvalueBox.Controls.Add(Me.KostiakovFormulaBox)
        Me.EvalueBox.Controls.Add(Me.StandardInfiltrationGroup)
        Me.EvalueBox.Controls.Add(Me.AdvancedInfiltrationGroup)
        Me.EvalueBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvalueBox.Location = New System.Drawing.Point(4, 4)
        Me.EvalueBox.Name = "EvalueBox"
        Me.EvalueBox.Size = New System.Drawing.Size(370, 390)
        Me.EvalueBox.TabIndex = 0
        Me.EvalueBox.TabStop = False
        Me.EvalueBox.Text = "Infiltration Function"
        '
        'UseInfiltrationEditorButton
        '
        Me.UseInfiltrationEditorButton.AccessibleDescription = "Displays editor to match infiltration parameters."
        Me.UseInfiltrationEditorButton.AccessibleName = "Match Parameters"
        Me.UseInfiltrationEditorButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.UseInfiltrationEditorButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseInfiltrationEditorButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.UseInfiltrationEditorButton.Location = New System.Drawing.Point(6, 362)
        Me.UseInfiltrationEditorButton.Name = "UseInfiltrationEditorButton"
        Me.UseInfiltrationEditorButton.Size = New System.Drawing.Size(358, 24)
        Me.UseInfiltrationEditorButton.TabIndex = 12
        Me.UseInfiltrationEditorButton.Text = "Infiltration Function &Editor..."
        Me.UseInfiltrationEditorButton.UseVisualStyleBackColor = False
        '
        'AdvancedInfiltrationGroup
        '
        Me.AdvancedInfiltrationGroup.AccessibleDescription = "Select the function to use for the estimation of the field's infiltration paramet" &
    "ers."
        Me.AdvancedInfiltrationGroup.AccessibleName = "EVALUE Infiltration Function"
        Me.AdvancedInfiltrationGroup.Controls.Add(Me.AdvInfiltrationEquationControl)
        Me.AdvancedInfiltrationGroup.Controls.Add(Me.AdvInfiltrationEquationLabel)
        Me.AdvancedInfiltrationGroup.Controls.Add(Me.AdvWettedPerimeterLabel)
        Me.AdvancedInfiltrationGroup.Controls.Add(Me.AdvWettedPerimeterControl)
        Me.AdvancedInfiltrationGroup.Controls.Add(Me.ShowStandardFunctions)
        Me.AdvancedInfiltrationGroup.Controls.Add(Me.AdvInfiltrationHelp)
        Me.AdvancedInfiltrationGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvancedInfiltrationGroup.Location = New System.Drawing.Point(6, 18)
        Me.AdvancedInfiltrationGroup.Name = "AdvancedInfiltrationGroup"
        Me.AdvancedInfiltrationGroup.Size = New System.Drawing.Size(358, 137)
        Me.AdvancedInfiltrationGroup.TabIndex = 0
        Me.AdvancedInfiltrationGroup.TabStop = False
        Me.AdvancedInfiltrationGroup.Text = "Select"
        '
        'AdvInfiltrationEquationControl
        '
        Me.AdvInfiltrationEquationControl.AccessibleDescription = "Selects the Infiltration Equation for entering the infiltration parameters.  The " &
    "Dialogs tab under User Preferences controls operation when a new method is selec" &
    "ted."
        Me.AdvInfiltrationEquationControl.AccessibleName = "Infiltration Equation"
        Me.AdvInfiltrationEquationControl.ApplicationValue = -1
        Me.AdvInfiltrationEquationControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AdvInfiltrationEquationControl.EnableSaveActions = False
        Me.AdvInfiltrationEquationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvInfiltrationEquationControl.IsCalculated = False
        Me.AdvInfiltrationEquationControl.Location = New System.Drawing.Point(134, 46)
        Me.AdvInfiltrationEquationControl.Name = "AdvInfiltrationEquationControl"
        Me.AdvInfiltrationEquationControl.SelectedIndexSet = False
        Me.AdvInfiltrationEquationControl.Size = New System.Drawing.Size(222, 24)
        Me.AdvInfiltrationEquationControl.TabIndex = 4
        '
        'AdvInfiltrationEquationLabel
        '
        Me.AdvInfiltrationEquationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvInfiltrationEquationLabel.Location = New System.Drawing.Point(1, 43)
        Me.AdvInfiltrationEquationLabel.Name = "AdvInfiltrationEquationLabel"
        Me.AdvInfiltrationEquationLabel.Size = New System.Drawing.Size(130, 23)
        Me.AdvInfiltrationEquationLabel.TabIndex = 3
        Me.AdvInfiltrationEquationLabel.Text = "&Infiltration Equation"
        Me.AdvInfiltrationEquationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AdvWettedPerimeterLabel
        '
        Me.AdvWettedPerimeterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvWettedPerimeterLabel.Location = New System.Drawing.Point(1, 17)
        Me.AdvWettedPerimeterLabel.Name = "AdvWettedPerimeterLabel"
        Me.AdvWettedPerimeterLabel.Size = New System.Drawing.Size(130, 23)
        Me.AdvWettedPerimeterLabel.TabIndex = 1
        Me.AdvWettedPerimeterLabel.Text = "&Wetted Perimeter"
        Me.AdvWettedPerimeterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AdvWettedPerimeterControl
        '
        Me.AdvWettedPerimeterControl.AccessibleDescription = "Selects the method for describing the wetted perimeter."
        Me.AdvWettedPerimeterControl.AccessibleName = "Wetted Perimeter"
        Me.AdvWettedPerimeterControl.ApplicationValue = -1
        Me.AdvWettedPerimeterControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AdvWettedPerimeterControl.EnableSaveActions = False
        Me.AdvWettedPerimeterControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvWettedPerimeterControl.IsCalculated = False
        Me.AdvWettedPerimeterControl.Location = New System.Drawing.Point(134, 19)
        Me.AdvWettedPerimeterControl.Name = "AdvWettedPerimeterControl"
        Me.AdvWettedPerimeterControl.SelectedIndexSet = False
        Me.AdvWettedPerimeterControl.Size = New System.Drawing.Size(222, 24)
        Me.AdvWettedPerimeterControl.TabIndex = 2
        '
        'ShowStandardFunctions
        '
        Me.ShowStandardFunctions.AccessibleDescription = "Provides instructions for estimating Green-Ampt parameters"
        Me.ShowStandardFunctions.AccessibleName = "Green-Ampt Help"
        Me.ShowStandardFunctions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowStandardFunctions.Location = New System.Drawing.Point(8, 107)
        Me.ShowStandardFunctions.Name = "ShowStandardFunctions"
        Me.ShowStandardFunctions.Size = New System.Drawing.Size(259, 24)
        Me.ShowStandardFunctions.TabIndex = 10
        Me.ShowStandardFunctions.Text = "Show Standard E&quations"
        Me.ShowStandardFunctions.UseVisualStyleBackColor = True
        '
        'AdvInfiltrationHelp
        '
        Me.AdvInfiltrationHelp.AccessibleDescription = "Provides instructions for estimating Green-Ampt parameters"
        Me.AdvInfiltrationHelp.AccessibleName = "Green-Ampt Help"
        Me.AdvInfiltrationHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvInfiltrationHelp.Location = New System.Drawing.Point(275, 107)
        Me.AdvInfiltrationHelp.Name = "AdvInfiltrationHelp"
        Me.AdvInfiltrationHelp.Size = New System.Drawing.Size(75, 24)
        Me.AdvInfiltrationHelp.TabIndex = 11
        Me.AdvInfiltrationHelp.Text = "&Help"
        Me.AdvInfiltrationHelp.UseVisualStyleBackColor = True
        '
        'BranchFunctionBox
        '
        Me.BranchFunctionBox.AccessibleDescription = "Wetted perimeter and infiltration parameters."
        Me.BranchFunctionBox.AccessibleName = "Branch Function"
        Me.BranchFunctionBox.Controls.Add(Me.BF_BranchTimeControl)
        Me.BranchFunctionBox.Controls.Add(Me.BF_BranchTimeSet)
        Me.BranchFunctionBox.Controls.Add(Me.BF_BranchTimeValue)
        Me.BranchFunctionBox.Controls.Add(Me.BF_kControl)
        Me.BranchFunctionBox.Controls.Add(Me.BF_cControl)
        Me.BranchFunctionBox.Controls.Add(Me.BF_Instructions)
        Me.BranchFunctionBox.Controls.Add(Me.BF_kLabel)
        Me.BranchFunctionBox.Controls.Add(Me.BF_bControl)
        Me.BranchFunctionBox.Controls.Add(Me.BF_aControl)
        Me.BranchFunctionBox.Controls.Add(Me.BF_cLabel)
        Me.BranchFunctionBox.Controls.Add(Me.BF_bLabel)
        Me.BranchFunctionBox.Controls.Add(Me.BF_aLabel)
        Me.BranchFunctionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchFunctionBox.Location = New System.Drawing.Point(6, 160)
        Me.BranchFunctionBox.Name = "BranchFunctionBox"
        Me.BranchFunctionBox.Size = New System.Drawing.Size(358, 200)
        Me.BranchFunctionBox.TabIndex = 1
        Me.BranchFunctionBox.TabStop = False
        Me.BranchFunctionBox.Text = "Parameters"
        '
        'BF_BranchTimeControl
        '
        Me.BF_BranchTimeControl.AccessibleDescription = "Time at which the Branch Function switches from the 'k^a+c' term to the 'b' term." &
    ""
        Me.BF_BranchTimeControl.AccessibleName = "Branch Time"
        Me.BF_BranchTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_BranchTimeControl.IsCalculated = False
        Me.BF_BranchTimeControl.IsInteger = False
        Me.BF_BranchTimeControl.Location = New System.Drawing.Point(163, 168)
        Me.BF_BranchTimeControl.MaxErrMsg = ""
        Me.BF_BranchTimeControl.MinErrMsg = ""
        Me.BF_BranchTimeControl.Name = "BF_BranchTimeControl"
        Me.BF_BranchTimeControl.Size = New System.Drawing.Size(128, 24)
        Me.BF_BranchTimeControl.TabIndex = 12
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
        Me.BF_BranchTimeSet.Location = New System.Drawing.Point(30, 168)
        Me.BF_BranchTimeSet.Name = "BF_BranchTimeSet"
        Me.BF_BranchTimeSet.Size = New System.Drawing.Size(131, 23)
        Me.BF_BranchTimeSet.TabIndex = 11
        Me.BF_BranchTimeSet.Text = "Branch &Time"
        Me.BF_BranchTimeSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BF_BranchTimeSet.UncheckAttemptMessage = Nothing
        Me.BF_BranchTimeSet.UseVisualStyleBackColor = True
        '
        'BF_BranchTimeValue
        '
        Me.BF_BranchTimeValue.AccessibleDescription = "Time at which the Branch Function switches from non-linear to linear."
        Me.BF_BranchTimeValue.AccessibleName = "Branch Time"
        Me.BF_BranchTimeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_BranchTimeValue.Location = New System.Drawing.Point(163, 169)
        Me.BF_BranchTimeValue.Name = "BF_BranchTimeValue"
        Me.BF_BranchTimeValue.Size = New System.Drawing.Size(189, 23)
        Me.BF_BranchTimeValue.TabIndex = 12
        Me.BF_BranchTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BF_kControl
        '
        Me.BF_kControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_kControl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BF_kControl.Location = New System.Drawing.Point(163, 65)
        Me.BF_kControl.Name = "BF_kControl"
        Me.BF_kControl.Size = New System.Drawing.Size(120, 24)
        Me.BF_kControl.TabIndex = 4
        Me.BF_kControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_kControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_kControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_kControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_kControl.ValueText = ""
        '
        'BF_cControl
        '
        Me.BF_cControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_cControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_cControl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BF_cControl.IsCalculated = False
        Me.BF_cControl.IsInteger = False
        Me.BF_cControl.Location = New System.Drawing.Point(163, 142)
        Me.BF_cControl.MaxErrMsg = ""
        Me.BF_cControl.MinErrMsg = ""
        Me.BF_cControl.Name = "BF_cControl"
        Me.BF_cControl.Size = New System.Drawing.Size(120, 24)
        Me.BF_cControl.TabIndex = 10
        Me.BF_cControl.ToBeCalculated = True
        Me.BF_cControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_cControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_cControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_cControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_cControl.ValueText = ""
        '
        'BF_Instructions
        '
        Me.BF_Instructions.BackColor = System.Drawing.SystemColors.Info
        Me.BF_Instructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BF_Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_Instructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.BF_Instructions.Location = New System.Drawing.Point(6, 20)
        Me.BF_Instructions.Name = "BF_Instructions"
        Me.BF_Instructions.Size = New System.Drawing.Size(346, 40)
        Me.BF_Instructions.TabIndex = 0
        Me.BF_Instructions.Text = "Edit the Branch Function parameters to fit the predicted infiltration to the meas" &
    "ured infiltration."
        Me.BF_Instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BF_kLabel
        '
        Me.BF_kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_kLabel.Location = New System.Drawing.Point(131, 65)
        Me.BF_kLabel.Name = "BF_kLabel"
        Me.BF_kLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_kLabel.TabIndex = 3
        Me.BF_kLabel.Text = "&k"
        Me.BF_kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_bControl
        '
        Me.BF_bControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_bControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_bControl.IsCalculated = False
        Me.BF_bControl.IsInteger = False
        Me.BF_bControl.Location = New System.Drawing.Point(163, 116)
        Me.BF_bControl.MaxErrMsg = ""
        Me.BF_bControl.MinErrMsg = ""
        Me.BF_bControl.Name = "BF_bControl"
        Me.BF_bControl.Size = New System.Drawing.Size(120, 24)
        Me.BF_bControl.TabIndex = 8
        Me.BF_bControl.ToBeCalculated = True
        Me.BF_bControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_bControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_bControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_bControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_bControl.ValueText = ""
        '
        'BF_aControl
        '
        Me.BF_aControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_aControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_aControl.IsCalculated = False
        Me.BF_aControl.IsInteger = False
        Me.BF_aControl.Location = New System.Drawing.Point(163, 90)
        Me.BF_aControl.MaxErrMsg = ""
        Me.BF_aControl.MinErrMsg = ""
        Me.BF_aControl.Name = "BF_aControl"
        Me.BF_aControl.Size = New System.Drawing.Size(120, 24)
        Me.BF_aControl.TabIndex = 6
        Me.BF_aControl.ToBeCalculated = True
        Me.BF_aControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_aControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_aControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_aControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_aControl.ValueText = ""
        '
        'BF_cLabel
        '
        Me.BF_cLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_cLabel.Location = New System.Drawing.Point(131, 142)
        Me.BF_cLabel.Name = "BF_cLabel"
        Me.BF_cLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_cLabel.TabIndex = 9
        Me.BF_cLabel.Text = "&c"
        Me.BF_cLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_bLabel
        '
        Me.BF_bLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_bLabel.Location = New System.Drawing.Point(131, 116)
        Me.BF_bLabel.Name = "BF_bLabel"
        Me.BF_bLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_bLabel.TabIndex = 7
        Me.BF_bLabel.Text = "&b"
        Me.BF_bLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_aLabel
        '
        Me.BF_aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_aLabel.Location = New System.Drawing.Point(131, 90)
        Me.BF_aLabel.Name = "BF_aLabel"
        Me.BF_aLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_aLabel.TabIndex = 5
        Me.BF_aLabel.Text = "&a"
        Me.BF_aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TimeRatedFamilyBox
        '
        Me.TimeRatedFamilyBox.AccessibleDescription = "Infiltration parameters for Representative Upstream Wetted Perimeter only."
        Me.TimeRatedFamilyBox.AccessibleName = "Time Rated Family"
        Me.TimeRatedFamilyBox.Controls.Add(Me.TR_KostiakovA)
        Me.TimeRatedFamilyBox.Controls.Add(Me.TR_KostiakovK)
        Me.TimeRatedFamilyBox.Controls.Add(Me.TR_Instructions)
        Me.TimeRatedFamilyBox.Controls.Add(Me.TR_InfiltrationDepthControl)
        Me.TimeRatedFamilyBox.Controls.Add(Me.TR_InfiltrationTimeControl)
        Me.TimeRatedFamilyBox.Controls.Add(Me.TR_InfiltrationTimeLabel)
        Me.TimeRatedFamilyBox.Controls.Add(Me.TR_InfiltrationDepthLabel)
        Me.TimeRatedFamilyBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeRatedFamilyBox.Location = New System.Drawing.Point(6, 160)
        Me.TimeRatedFamilyBox.Name = "TimeRatedFamilyBox"
        Me.TimeRatedFamilyBox.Size = New System.Drawing.Size(358, 200)
        Me.TimeRatedFamilyBox.TabIndex = 1
        Me.TimeRatedFamilyBox.TabStop = False
        Me.TimeRatedFamilyBox.Text = "Parameters"
        '
        'TR_KostiakovA
        '
        Me.TR_KostiakovA.AccessibleDescription = "Exponent (a) in the formula:  Zn = k * (T ^ a).  Here, Kostiakov a is calculated " &
    "by WinSRFR based on the Characteristic Infiltration Time (T)."
        Me.TR_KostiakovA.AccessibleName = "Kostiakov a"
        Me.TR_KostiakovA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_KostiakovA.Location = New System.Drawing.Point(211, 76)
        Me.TR_KostiakovA.Name = "TR_KostiakovA"
        Me.TR_KostiakovA.Size = New System.Drawing.Size(136, 23)
        Me.TR_KostiakovA.TabIndex = 2
        Me.TR_KostiakovA.Text = "a = "
        Me.TR_KostiakovA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_KostiakovK
        '
        Me.TR_KostiakovK.AccessibleDescription = "Coefficient (k) in the formula:  Zn = k * (T ^ a).  In this case, k is calculated" &
    " by WinSRFR."
        Me.TR_KostiakovK.AccessibleName = "k"
        Me.TR_KostiakovK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_KostiakovK.Location = New System.Drawing.Point(11, 76)
        Me.TR_KostiakovK.Name = "TR_KostiakovK"
        Me.TR_KostiakovK.Size = New System.Drawing.Size(200, 23)
        Me.TR_KostiakovK.TabIndex = 1
        Me.TR_KostiakovK.Text = "k = "
        Me.TR_KostiakovK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_Instructions
        '
        Me.TR_Instructions.BackColor = System.Drawing.SystemColors.Info
        Me.TR_Instructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TR_Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_Instructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.TR_Instructions.Location = New System.Drawing.Point(6, 20)
        Me.TR_Instructions.Name = "TR_Instructions"
        Me.TR_Instructions.Size = New System.Drawing.Size(346, 40)
        Me.TR_Instructions.TabIndex = 0
        Me.TR_Instructions.Text = "Enter the time that best fits the predicted infiltration to the measured infiltra" &
    "tion."
        Me.TR_Instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_InfiltrationDepthControl
        '
        Me.TR_InfiltrationDepthControl.AccessibleDescription = "Depth is fixed at 100mm (3.94in) for the Time Rated Intake Family Method."
        Me.TR_InfiltrationDepthControl.AccessibleName = "Characteristic Infiltration Depth"
        Me.TR_InfiltrationDepthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_InfiltrationDepthControl.Location = New System.Drawing.Point(249, 114)
        Me.TR_InfiltrationDepthControl.Name = "TR_InfiltrationDepthControl"
        Me.TR_InfiltrationDepthControl.Size = New System.Drawing.Size(105, 23)
        Me.TR_InfiltrationDepthControl.TabIndex = 4
        Me.TR_InfiltrationDepthControl.Text = "100 mm"
        Me.TR_InfiltrationDepthControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_InfiltrationTimeControl
        '
        Me.TR_InfiltrationTimeControl.AccessibleDescription = "The time required for water to infiltrate to the Characteristic Infiltration Dept" &
    "h."
        Me.TR_InfiltrationTimeControl.AccessibleName = "Characteristic Infiltration Time"
        Me.TR_InfiltrationTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.TR_InfiltrationTimeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_InfiltrationTimeControl.IsCalculated = False
        Me.TR_InfiltrationTimeControl.IsInteger = False
        Me.TR_InfiltrationTimeControl.Location = New System.Drawing.Point(249, 140)
        Me.TR_InfiltrationTimeControl.MaxErrMsg = ""
        Me.TR_InfiltrationTimeControl.MinErrMsg = ""
        Me.TR_InfiltrationTimeControl.Name = "TR_InfiltrationTimeControl"
        Me.TR_InfiltrationTimeControl.Size = New System.Drawing.Size(105, 24)
        Me.TR_InfiltrationTimeControl.TabIndex = 6
        Me.TR_InfiltrationTimeControl.ToBeCalculated = True
        Me.TR_InfiltrationTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.TR_InfiltrationTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.TR_InfiltrationTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.TR_InfiltrationTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.TR_InfiltrationTimeControl.ValueText = ""
        '
        'TR_InfiltrationTimeLabel
        '
        Me.TR_InfiltrationTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_InfiltrationTimeLabel.Location = New System.Drawing.Point(5, 140)
        Me.TR_InfiltrationTimeLabel.Name = "TR_InfiltrationTimeLabel"
        Me.TR_InfiltrationTimeLabel.Size = New System.Drawing.Size(236, 23)
        Me.TR_InfiltrationTimeLabel.TabIndex = 5
        Me.TR_InfiltrationTimeLabel.Text = "Characteristic Infiltration &Time"
        Me.TR_InfiltrationTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TR_InfiltrationDepthLabel
        '
        Me.TR_InfiltrationDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_InfiltrationDepthLabel.Location = New System.Drawing.Point(5, 114)
        Me.TR_InfiltrationDepthLabel.Name = "TR_InfiltrationDepthLabel"
        Me.TR_InfiltrationDepthLabel.Size = New System.Drawing.Size(236, 23)
        Me.TR_InfiltrationDepthLabel.TabIndex = 3
        Me.TR_InfiltrationDepthLabel.Text = "Characteristic Infiltration Depth"
        Me.TR_InfiltrationDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CharacteristicTimeBox
        '
        Me.CharacteristicTimeBox.AccessibleDescription = "Infiltration parameters for Furrow Spacing only.  Wetted Perimeter is not used."
        Me.CharacteristicTimeBox.AccessibleName = "Characteristic Time"
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_KostiakovK)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_WettedPerimeter)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_Instructions)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_InfiltrationTimeControl)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_KostiakovAControl)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_InfiltrationDepthControl)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_InfiltrationTimeLabel)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_KostiakovALabel)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_InfiltrationDepthLabel)
        Me.CharacteristicTimeBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CharacteristicTimeBox.Location = New System.Drawing.Point(6, 160)
        Me.CharacteristicTimeBox.Name = "CharacteristicTimeBox"
        Me.CharacteristicTimeBox.Size = New System.Drawing.Size(358, 200)
        Me.CharacteristicTimeBox.TabIndex = 1
        Me.CharacteristicTimeBox.TabStop = False
        Me.CharacteristicTimeBox.Text = "Parameters"
        '
        'KT_KostiakovK
        '
        Me.KT_KostiakovK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_KostiakovK.Location = New System.Drawing.Point(83, 72)
        Me.KT_KostiakovK.Name = "KT_KostiakovK"
        Me.KT_KostiakovK.Size = New System.Drawing.Size(192, 23)
        Me.KT_KostiakovK.TabIndex = 9
        Me.KT_KostiakovK.Text = "k = "
        Me.KT_KostiakovK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KT_WettedPerimeter
        '
        Me.KT_WettedPerimeter.AutoSize = True
        Me.KT_WettedPerimeter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_WettedPerimeter.Location = New System.Drawing.Point(8, 78)
        Me.KT_WettedPerimeter.Name = "KT_WettedPerimeter"
        Me.KT_WettedPerimeter.Size = New System.Drawing.Size(0, 17)
        Me.KT_WettedPerimeter.TabIndex = 1
        Me.KT_WettedPerimeter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KT_Instructions
        '
        Me.KT_Instructions.BackColor = System.Drawing.SystemColors.Info
        Me.KT_Instructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.KT_Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_Instructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.KT_Instructions.Location = New System.Drawing.Point(6, 20)
        Me.KT_Instructions.Name = "KT_Instructions"
        Me.KT_Instructions.Size = New System.Drawing.Size(346, 40)
        Me.KT_Instructions.TabIndex = 0
        Me.KT_Instructions.Text = "Edit the Characteristic Time parameters to fit the predicted infiltration to the " &
    "measured infiltration."
        Me.KT_Instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KT_InfiltrationTimeControl
        '
        Me.KT_InfiltrationTimeControl.AccessibleDescription = "The time necessary to infiltrate to the Characteristic Infiltration Depth."
        Me.KT_InfiltrationTimeControl.AccessibleName = "Characteristic Infiltration Time"
        Me.KT_InfiltrationTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KT_InfiltrationTimeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_InfiltrationTimeControl.IsCalculated = False
        Me.KT_InfiltrationTimeControl.IsInteger = False
        Me.KT_InfiltrationTimeControl.Location = New System.Drawing.Point(249, 129)
        Me.KT_InfiltrationTimeControl.MaxErrMsg = ""
        Me.KT_InfiltrationTimeControl.MinErrMsg = ""
        Me.KT_InfiltrationTimeControl.Name = "KT_InfiltrationTimeControl"
        Me.KT_InfiltrationTimeControl.Size = New System.Drawing.Size(105, 24)
        Me.KT_InfiltrationTimeControl.TabIndex = 6
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
        Me.KT_KostiakovAControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_KostiakovAControl.IsCalculated = False
        Me.KT_KostiakovAControl.IsInteger = False
        Me.KT_KostiakovAControl.Location = New System.Drawing.Point(249, 155)
        Me.KT_KostiakovAControl.MaxErrMsg = ""
        Me.KT_KostiakovAControl.MinErrMsg = ""
        Me.KT_KostiakovAControl.Name = "KT_KostiakovAControl"
        Me.KT_KostiakovAControl.Size = New System.Drawing.Size(105, 24)
        Me.KT_KostiakovAControl.TabIndex = 8
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
        Me.KT_InfiltrationDepthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_InfiltrationDepthControl.IsCalculated = False
        Me.KT_InfiltrationDepthControl.IsInteger = False
        Me.KT_InfiltrationDepthControl.Location = New System.Drawing.Point(249, 103)
        Me.KT_InfiltrationDepthControl.MaxErrMsg = ""
        Me.KT_InfiltrationDepthControl.MinErrMsg = ""
        Me.KT_InfiltrationDepthControl.Name = "KT_InfiltrationDepthControl"
        Me.KT_InfiltrationDepthControl.Size = New System.Drawing.Size(105, 24)
        Me.KT_InfiltrationDepthControl.TabIndex = 4
        Me.KT_InfiltrationDepthControl.ToBeCalculated = True
        Me.KT_InfiltrationDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KT_InfiltrationDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KT_InfiltrationDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KT_InfiltrationDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KT_InfiltrationDepthControl.ValueText = ""
        '
        'KT_InfiltrationTimeLabel
        '
        Me.KT_InfiltrationTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_InfiltrationTimeLabel.Location = New System.Drawing.Point(5, 129)
        Me.KT_InfiltrationTimeLabel.Name = "KT_InfiltrationTimeLabel"
        Me.KT_InfiltrationTimeLabel.Size = New System.Drawing.Size(236, 23)
        Me.KT_InfiltrationTimeLabel.TabIndex = 5
        Me.KT_InfiltrationTimeLabel.Text = "Characteristic Infiltration &Time"
        Me.KT_InfiltrationTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KT_KostiakovALabel
        '
        Me.KT_KostiakovALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_KostiakovALabel.Location = New System.Drawing.Point(5, 155)
        Me.KT_KostiakovALabel.Name = "KT_KostiakovALabel"
        Me.KT_KostiakovALabel.Size = New System.Drawing.Size(236, 23)
        Me.KT_KostiakovALabel.TabIndex = 7
        Me.KT_KostiakovALabel.Text = "&a"
        Me.KT_KostiakovALabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KT_InfiltrationDepthLabel
        '
        Me.KT_InfiltrationDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_InfiltrationDepthLabel.Location = New System.Drawing.Point(5, 103)
        Me.KT_InfiltrationDepthLabel.Name = "KT_InfiltrationDepthLabel"
        Me.KT_InfiltrationDepthLabel.Size = New System.Drawing.Size(236, 23)
        Me.KT_InfiltrationDepthLabel.TabIndex = 3
        Me.KT_InfiltrationDepthLabel.Text = "Characteristic Infiltration &Depth"
        Me.KT_InfiltrationDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ModifiedKostiakovBox
        '
        Me.ModifiedKostiakovBox.AccessibleDescription = "Wetted perimeter and infiltration parameters."
        Me.ModifiedKostiakovBox.AccessibleName = "Modified Kostiakov"
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_aControl)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_kControl)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_cControl)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_Instructions)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_kLabel)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_bControl)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_cLabel)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_bLabel)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_aLabel)
        Me.ModifiedKostiakovBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModifiedKostiakovBox.Location = New System.Drawing.Point(6, 160)
        Me.ModifiedKostiakovBox.Name = "ModifiedKostiakovBox"
        Me.ModifiedKostiakovBox.Size = New System.Drawing.Size(358, 200)
        Me.ModifiedKostiakovBox.TabIndex = 1
        Me.ModifiedKostiakovBox.TabStop = False
        Me.ModifiedKostiakovBox.Text = "Parameters"
        '
        'MK_aControl
        '
        Me.MK_aControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_aControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_aControl.IsCalculated = False
        Me.MK_aControl.IsInteger = False
        Me.MK_aControl.Location = New System.Drawing.Point(163, 104)
        Me.MK_aControl.MaxErrMsg = ""
        Me.MK_aControl.MinErrMsg = ""
        Me.MK_aControl.Name = "MK_aControl"
        Me.MK_aControl.Size = New System.Drawing.Size(120, 24)
        Me.MK_aControl.TabIndex = 6
        Me.MK_aControl.ToBeCalculated = True
        Me.MK_aControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_aControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_aControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_aControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_aControl.ValueText = ""
        '
        'MK_kControl
        '
        Me.MK_kControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_kControl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MK_kControl.Location = New System.Drawing.Point(163, 79)
        Me.MK_kControl.Name = "MK_kControl"
        Me.MK_kControl.Size = New System.Drawing.Size(120, 24)
        Me.MK_kControl.TabIndex = 4
        Me.MK_kControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_kControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_kControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_kControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_kControl.ValueText = ""
        '
        'MK_cControl
        '
        Me.MK_cControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_cControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_cControl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MK_cControl.IsCalculated = False
        Me.MK_cControl.IsInteger = False
        Me.MK_cControl.Location = New System.Drawing.Point(163, 156)
        Me.MK_cControl.MaxErrMsg = ""
        Me.MK_cControl.MinErrMsg = ""
        Me.MK_cControl.Name = "MK_cControl"
        Me.MK_cControl.Size = New System.Drawing.Size(120, 24)
        Me.MK_cControl.TabIndex = 10
        Me.MK_cControl.ToBeCalculated = True
        Me.MK_cControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_cControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_cControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_cControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_cControl.ValueText = ""
        '
        'MK_Instructions
        '
        Me.MK_Instructions.BackColor = System.Drawing.SystemColors.Info
        Me.MK_Instructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MK_Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_Instructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.MK_Instructions.Location = New System.Drawing.Point(6, 20)
        Me.MK_Instructions.Name = "MK_Instructions"
        Me.MK_Instructions.Size = New System.Drawing.Size(346, 40)
        Me.MK_Instructions.TabIndex = 0
        Me.MK_Instructions.Text = "Edit the Modified Kostiakov parameters to fit the predicted infiltration to the m" &
    "easured infiltration."
        Me.MK_Instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MK_kLabel
        '
        Me.MK_kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_kLabel.Location = New System.Drawing.Point(131, 79)
        Me.MK_kLabel.Name = "MK_kLabel"
        Me.MK_kLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_kLabel.TabIndex = 3
        Me.MK_kLabel.Text = "&k"
        Me.MK_kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_bControl
        '
        Me.MK_bControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_bControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_bControl.IsCalculated = False
        Me.MK_bControl.IsInteger = False
        Me.MK_bControl.Location = New System.Drawing.Point(163, 130)
        Me.MK_bControl.MaxErrMsg = ""
        Me.MK_bControl.MinErrMsg = ""
        Me.MK_bControl.Name = "MK_bControl"
        Me.MK_bControl.Size = New System.Drawing.Size(120, 24)
        Me.MK_bControl.TabIndex = 8
        Me.MK_bControl.ToBeCalculated = True
        Me.MK_bControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_bControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_bControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_bControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_bControl.ValueText = ""
        '
        'MK_cLabel
        '
        Me.MK_cLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_cLabel.Location = New System.Drawing.Point(131, 156)
        Me.MK_cLabel.Name = "MK_cLabel"
        Me.MK_cLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_cLabel.TabIndex = 9
        Me.MK_cLabel.Text = "&c"
        Me.MK_cLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_bLabel
        '
        Me.MK_bLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_bLabel.Location = New System.Drawing.Point(131, 130)
        Me.MK_bLabel.Name = "MK_bLabel"
        Me.MK_bLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_bLabel.TabIndex = 7
        Me.MK_bLabel.Text = "&b"
        Me.MK_bLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_aLabel
        '
        Me.MK_aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_aLabel.Location = New System.Drawing.Point(131, 104)
        Me.MK_aLabel.Name = "MK_aLabel"
        Me.MK_aLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_aLabel.TabIndex = 5
        Me.MK_aLabel.Text = "&a"
        Me.MK_aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GreenAmptBox
        '
        Me.GreenAmptBox.AccessibleDescription = "Basin and border infiltration parameters."
        Me.GreenAmptBox.AccessibleName = "Green-Ampt"
        Me.GreenAmptBox.Controls.Add(Me.GA_Instructions)
        Me.GreenAmptBox.Controls.Add(Me.GA_cControl)
        Me.GreenAmptBox.Controls.Add(Me.GAcLabel)
        Me.GreenAmptBox.Controls.Add(Me.GA_HydraulicConductivityControl)
        Me.GreenAmptBox.Controls.Add(Me.HydraulicConductivityLabel)
        Me.GreenAmptBox.Controls.Add(Me.GA_WettingFrontControl)
        Me.GreenAmptBox.Controls.Add(Me.AirEntryPressureLabel)
        Me.GreenAmptBox.Controls.Add(Me.GA_InitVolWaterContentControl)
        Me.GreenAmptBox.Controls.Add(Me.InitVolWaterContentLabel)
        Me.GreenAmptBox.Controls.Add(Me.GA_PorosityControl)
        Me.GreenAmptBox.Controls.Add(Me.EffectivePorosityLabel)
        Me.GreenAmptBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GreenAmptBox.Location = New System.Drawing.Point(6, 160)
        Me.GreenAmptBox.Name = "GreenAmptBox"
        Me.GreenAmptBox.Size = New System.Drawing.Size(358, 200)
        Me.GreenAmptBox.TabIndex = 1
        Me.GreenAmptBox.TabStop = False
        Me.GreenAmptBox.Text = "Parameters"
        '
        'GA_Instructions
        '
        Me.GA_Instructions.BackColor = System.Drawing.SystemColors.Info
        Me.GA_Instructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GA_Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_Instructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.GA_Instructions.Location = New System.Drawing.Point(6, 20)
        Me.GA_Instructions.Name = "GA_Instructions"
        Me.GA_Instructions.Size = New System.Drawing.Size(346, 40)
        Me.GA_Instructions.TabIndex = 0
        Me.GA_Instructions.Text = "Edit the Green-Ampt parameters to fit the predicted infiltration to the measured " &
    "infiltration."
        Me.GA_Instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GA_cControl
        '
        Me.GA_cControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_cControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_cControl.IsCalculated = False
        Me.GA_cControl.IsInteger = False
        Me.GA_cControl.Location = New System.Drawing.Point(223, 170)
        Me.GA_cControl.MaxErrMsg = ""
        Me.GA_cControl.MinErrMsg = ""
        Me.GA_cControl.Name = "GA_cControl"
        Me.GA_cControl.Size = New System.Drawing.Size(124, 24)
        Me.GA_cControl.TabIndex = 10
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
        Me.GAcLabel.Location = New System.Drawing.Point(3, 173)
        Me.GAcLabel.Name = "GAcLabel"
        Me.GAcLabel.Size = New System.Drawing.Size(215, 21)
        Me.GAcLabel.TabIndex = 9
        Me.GAcLabel.Text = "&Macropore Infiltration"
        Me.GAcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_HydraulicConductivityControl
        '
        Me.GA_HydraulicConductivityControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_HydraulicConductivityControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_HydraulicConductivityControl.IsCalculated = False
        Me.GA_HydraulicConductivityControl.IsInteger = False
        Me.GA_HydraulicConductivityControl.Location = New System.Drawing.Point(223, 146)
        Me.GA_HydraulicConductivityControl.MaxErrMsg = ""
        Me.GA_HydraulicConductivityControl.MinErrMsg = ""
        Me.GA_HydraulicConductivityControl.Name = "GA_HydraulicConductivityControl"
        Me.GA_HydraulicConductivityControl.Size = New System.Drawing.Size(124, 24)
        Me.GA_HydraulicConductivityControl.TabIndex = 8
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
        Me.HydraulicConductivityLabel.Location = New System.Drawing.Point(3, 149)
        Me.HydraulicConductivityLabel.Name = "HydraulicConductivityLabel"
        Me.HydraulicConductivityLabel.Size = New System.Drawing.Size(215, 21)
        Me.HydraulicConductivityLabel.TabIndex = 7
        Me.HydraulicConductivityLabel.Text = "Hydraulic Conductivity, &Ks"
        Me.HydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_WettingFrontControl
        '
        Me.GA_WettingFrontControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_WettingFrontControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_WettingFrontControl.IsCalculated = False
        Me.GA_WettingFrontControl.IsInteger = False
        Me.GA_WettingFrontControl.Location = New System.Drawing.Point(223, 120)
        Me.GA_WettingFrontControl.MaxErrMsg = ""
        Me.GA_WettingFrontControl.MinErrMsg = ""
        Me.GA_WettingFrontControl.Name = "GA_WettingFrontControl"
        Me.GA_WettingFrontControl.Size = New System.Drawing.Size(124, 24)
        Me.GA_WettingFrontControl.TabIndex = 6
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
        Me.AirEntryPressureLabel.Location = New System.Drawing.Point(3, 123)
        Me.AirEntryPressureLabel.Name = "AirEntryPressureLabel"
        Me.AirEntryPressureLabel.Size = New System.Drawing.Size(215, 21)
        Me.AirEntryPressureLabel.TabIndex = 5
        Me.AirEntryPressureLabel.Text = "Wetting Front Pressure Head, &hf"
        Me.AirEntryPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_InitVolWaterContentControl
        '
        Me.GA_InitVolWaterContentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_InitVolWaterContentControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_InitVolWaterContentControl.IsCalculated = False
        Me.GA_InitVolWaterContentControl.IsInteger = False
        Me.GA_InitVolWaterContentControl.Location = New System.Drawing.Point(223, 94)
        Me.GA_InitVolWaterContentControl.MaxErrMsg = ""
        Me.GA_InitVolWaterContentControl.MinErrMsg = ""
        Me.GA_InitVolWaterContentControl.Name = "GA_InitVolWaterContentControl"
        Me.GA_InitVolWaterContentControl.Size = New System.Drawing.Size(120, 24)
        Me.GA_InitVolWaterContentControl.TabIndex = 4
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
        Me.InitVolWaterContentLabel.Location = New System.Drawing.Point(3, 97)
        Me.InitVolWaterContentLabel.Name = "InitVolWaterContentLabel"
        Me.InitVolWaterContentLabel.Size = New System.Drawing.Size(215, 21)
        Me.InitVolWaterContentLabel.TabIndex = 3
        Me.InitVolWaterContentLabel.Text = "Initial Water Content, Theta&0"
        Me.InitVolWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GA_PorosityControl
        '
        Me.GA_PorosityControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.GA_PorosityControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GA_PorosityControl.IsCalculated = False
        Me.GA_PorosityControl.IsInteger = False
        Me.GA_PorosityControl.Location = New System.Drawing.Point(223, 68)
        Me.GA_PorosityControl.MaxErrMsg = ""
        Me.GA_PorosityControl.MinErrMsg = ""
        Me.GA_PorosityControl.Name = "GA_PorosityControl"
        Me.GA_PorosityControl.Size = New System.Drawing.Size(120, 24)
        Me.GA_PorosityControl.TabIndex = 2
        Me.GA_PorosityControl.ToBeCalculated = True
        Me.GA_PorosityControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.GA_PorosityControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.GA_PorosityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.GA_PorosityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.GA_PorosityControl.ValueText = ""
        '
        'EffectivePorosityLabel
        '
        Me.EffectivePorosityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EffectivePorosityLabel.Location = New System.Drawing.Point(3, 71)
        Me.EffectivePorosityLabel.Name = "EffectivePorosityLabel"
        Me.EffectivePorosityLabel.Size = New System.Drawing.Size(215, 21)
        Me.EffectivePorosityLabel.TabIndex = 1
        Me.EffectivePorosityLabel.Text = "Sat. Water Content, Theta&S"
        Me.EffectivePorosityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WarrickGreenAmptBox
        '
        Me.WarrickGreenAmptBox.AccessibleDescription = "Furrow infiltration parameters."
        Me.WarrickGreenAmptBox.AccessibleName = "Warrick Green-Ampt"
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_Instructions)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_cControl)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_InstantaneousInfiltrationLabel)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_HydraulicConductivityControl)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_HydraulicConductivityLabel)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_WettingFrontControl)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_WettingFrontLabel)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_InitWaterContentControl)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_InitWaterContentLabel)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_SatWaterContentControl)
        Me.WarrickGreenAmptBox.Controls.Add(Me.WGA_SatWaterContentLabel)
        Me.WarrickGreenAmptBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WarrickGreenAmptBox.Location = New System.Drawing.Point(6, 160)
        Me.WarrickGreenAmptBox.Name = "WarrickGreenAmptBox"
        Me.WarrickGreenAmptBox.Size = New System.Drawing.Size(358, 200)
        Me.WarrickGreenAmptBox.TabIndex = 1
        Me.WarrickGreenAmptBox.TabStop = False
        Me.WarrickGreenAmptBox.Text = "Parameters"
        '
        'WGA_Instructions
        '
        Me.WGA_Instructions.BackColor = System.Drawing.SystemColors.Info
        Me.WGA_Instructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WGA_Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_Instructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.WGA_Instructions.Location = New System.Drawing.Point(6, 20)
        Me.WGA_Instructions.Name = "WGA_Instructions"
        Me.WGA_Instructions.Size = New System.Drawing.Size(348, 40)
        Me.WGA_Instructions.TabIndex = 0
        Me.WGA_Instructions.Text = "Edit the Warrick Green-Ampt parameters to fit the predicted infiltration to the m" &
    "easured infiltration."
        Me.WGA_Instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WGA_cControl
        '
        Me.WGA_cControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_cControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_cControl.IsCalculated = False
        Me.WGA_cControl.IsInteger = False
        Me.WGA_cControl.Location = New System.Drawing.Point(223, 168)
        Me.WGA_cControl.MaxErrMsg = ""
        Me.WGA_cControl.MinErrMsg = ""
        Me.WGA_cControl.Name = "WGA_cControl"
        Me.WGA_cControl.Size = New System.Drawing.Size(124, 24)
        Me.WGA_cControl.TabIndex = 10
        Me.WGA_cControl.ToBeCalculated = True
        Me.WGA_cControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_cControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_cControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_cControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_cControl.ValueText = ""
        '
        'WGA_InstantaneousInfiltrationLabel
        '
        Me.WGA_InstantaneousInfiltrationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_InstantaneousInfiltrationLabel.Location = New System.Drawing.Point(3, 171)
        Me.WGA_InstantaneousInfiltrationLabel.Name = "WGA_InstantaneousInfiltrationLabel"
        Me.WGA_InstantaneousInfiltrationLabel.Size = New System.Drawing.Size(215, 21)
        Me.WGA_InstantaneousInfiltrationLabel.TabIndex = 9
        Me.WGA_InstantaneousInfiltrationLabel.Text = "&Macropore Infiltration"
        Me.WGA_InstantaneousInfiltrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_HydraulicConductivityControl
        '
        Me.WGA_HydraulicConductivityControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_HydraulicConductivityControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_HydraulicConductivityControl.IsCalculated = False
        Me.WGA_HydraulicConductivityControl.IsInteger = False
        Me.WGA_HydraulicConductivityControl.Location = New System.Drawing.Point(223, 144)
        Me.WGA_HydraulicConductivityControl.MaxErrMsg = ""
        Me.WGA_HydraulicConductivityControl.MinErrMsg = ""
        Me.WGA_HydraulicConductivityControl.Name = "WGA_HydraulicConductivityControl"
        Me.WGA_HydraulicConductivityControl.Size = New System.Drawing.Size(124, 24)
        Me.WGA_HydraulicConductivityControl.TabIndex = 8
        Me.WGA_HydraulicConductivityControl.ToBeCalculated = True
        Me.WGA_HydraulicConductivityControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_HydraulicConductivityControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_HydraulicConductivityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_HydraulicConductivityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_HydraulicConductivityControl.ValueText = ""
        '
        'WGA_HydraulicConductivityLabel
        '
        Me.WGA_HydraulicConductivityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_HydraulicConductivityLabel.Location = New System.Drawing.Point(3, 147)
        Me.WGA_HydraulicConductivityLabel.Name = "WGA_HydraulicConductivityLabel"
        Me.WGA_HydraulicConductivityLabel.Size = New System.Drawing.Size(215, 21)
        Me.WGA_HydraulicConductivityLabel.TabIndex = 7
        Me.WGA_HydraulicConductivityLabel.Text = "Hydraulic Conductivity, &Ks"
        Me.WGA_HydraulicConductivityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_WettingFrontControl
        '
        Me.WGA_WettingFrontControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_WettingFrontControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_WettingFrontControl.IsCalculated = False
        Me.WGA_WettingFrontControl.IsInteger = False
        Me.WGA_WettingFrontControl.Location = New System.Drawing.Point(223, 118)
        Me.WGA_WettingFrontControl.MaxErrMsg = ""
        Me.WGA_WettingFrontControl.MinErrMsg = ""
        Me.WGA_WettingFrontControl.Name = "WGA_WettingFrontControl"
        Me.WGA_WettingFrontControl.Size = New System.Drawing.Size(124, 24)
        Me.WGA_WettingFrontControl.TabIndex = 6
        Me.WGA_WettingFrontControl.ToBeCalculated = True
        Me.WGA_WettingFrontControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_WettingFrontControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_WettingFrontControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_WettingFrontControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_WettingFrontControl.ValueText = ""
        '
        'WGA_WettingFrontLabel
        '
        Me.WGA_WettingFrontLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_WettingFrontLabel.Location = New System.Drawing.Point(3, 121)
        Me.WGA_WettingFrontLabel.Name = "WGA_WettingFrontLabel"
        Me.WGA_WettingFrontLabel.Size = New System.Drawing.Size(215, 21)
        Me.WGA_WettingFrontLabel.TabIndex = 5
        Me.WGA_WettingFrontLabel.Text = "Wetting Front Pressure Head, &hf"
        Me.WGA_WettingFrontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_InitWaterContentControl
        '
        Me.WGA_InitWaterContentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_InitWaterContentControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_InitWaterContentControl.IsCalculated = False
        Me.WGA_InitWaterContentControl.IsInteger = False
        Me.WGA_InitWaterContentControl.Location = New System.Drawing.Point(223, 92)
        Me.WGA_InitWaterContentControl.MaxErrMsg = ""
        Me.WGA_InitWaterContentControl.MinErrMsg = ""
        Me.WGA_InitWaterContentControl.Name = "WGA_InitWaterContentControl"
        Me.WGA_InitWaterContentControl.Size = New System.Drawing.Size(120, 24)
        Me.WGA_InitWaterContentControl.TabIndex = 4
        Me.WGA_InitWaterContentControl.ToBeCalculated = True
        Me.WGA_InitWaterContentControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_InitWaterContentControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_InitWaterContentControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_InitWaterContentControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_InitWaterContentControl.ValueText = ""
        '
        'WGA_InitWaterContentLabel
        '
        Me.WGA_InitWaterContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_InitWaterContentLabel.Location = New System.Drawing.Point(3, 95)
        Me.WGA_InitWaterContentLabel.Name = "WGA_InitWaterContentLabel"
        Me.WGA_InitWaterContentLabel.Size = New System.Drawing.Size(215, 21)
        Me.WGA_InitWaterContentLabel.TabIndex = 3
        Me.WGA_InitWaterContentLabel.Text = "Initial Water Content, Theta&0"
        Me.WGA_InitWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WGA_SatWaterContentControl
        '
        Me.WGA_SatWaterContentControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.WGA_SatWaterContentControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_SatWaterContentControl.IsCalculated = False
        Me.WGA_SatWaterContentControl.IsInteger = False
        Me.WGA_SatWaterContentControl.Location = New System.Drawing.Point(223, 66)
        Me.WGA_SatWaterContentControl.MaxErrMsg = ""
        Me.WGA_SatWaterContentControl.MinErrMsg = ""
        Me.WGA_SatWaterContentControl.Name = "WGA_SatWaterContentControl"
        Me.WGA_SatWaterContentControl.Size = New System.Drawing.Size(120, 24)
        Me.WGA_SatWaterContentControl.TabIndex = 2
        Me.WGA_SatWaterContentControl.ToBeCalculated = True
        Me.WGA_SatWaterContentControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.WGA_SatWaterContentControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.WGA_SatWaterContentControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.WGA_SatWaterContentControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.WGA_SatWaterContentControl.ValueText = ""
        '
        'WGA_SatWaterContentLabel
        '
        Me.WGA_SatWaterContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WGA_SatWaterContentLabel.Location = New System.Drawing.Point(3, 69)
        Me.WGA_SatWaterContentLabel.Name = "WGA_SatWaterContentLabel"
        Me.WGA_SatWaterContentLabel.Size = New System.Drawing.Size(215, 21)
        Me.WGA_SatWaterContentLabel.TabIndex = 1
        Me.WGA_SatWaterContentLabel.Text = "Sat. Water Content, Theta&S"
        Me.WGA_SatWaterContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NrcsIntakeFamilyGroup
        '
        Me.NrcsIntakeFamilyGroup.AccessibleDescription = "Selection uses NRCS Empirical Wetted Perimeter only."
        Me.NrcsIntakeFamilyGroup.AccessibleName = "NRCS Intake Family"
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.NrcsInstruction)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.NrcsOptionsButton)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_400)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_300)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_090)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_200)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_150)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_100)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_080)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_070)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_060)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_050)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_045)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_040)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_035)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_030)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_025)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_020)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_015)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_010)
        Me.NrcsIntakeFamilyGroup.Controls.Add(Me.Sel_005)
        Me.NrcsIntakeFamilyGroup.Location = New System.Drawing.Point(6, 160)
        Me.NrcsIntakeFamilyGroup.Name = "NrcsIntakeFamilyGroup"
        Me.NrcsIntakeFamilyGroup.Size = New System.Drawing.Size(358, 200)
        Me.NrcsIntakeFamilyGroup.TabIndex = 1
        Me.NrcsIntakeFamilyGroup.TabStop = False
        Me.NrcsIntakeFamilyGroup.Text = "&NRCS Intake Family"
        '
        'NrcsInstruction
        '
        Me.NrcsInstruction.BackColor = System.Drawing.SystemColors.Info
        Me.NrcsInstruction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NrcsInstruction.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsInstruction.ForeColor = System.Drawing.SystemColors.InfoText
        Me.NrcsInstruction.Location = New System.Drawing.Point(8, 20)
        Me.NrcsInstruction.Name = "NrcsInstruction"
        Me.NrcsInstruction.Size = New System.Drawing.Size(342, 40)
        Me.NrcsInstruction.TabIndex = 0
        Me.NrcsInstruction.Text = "Select the NRCS family that best fits the predicted infiltration to the measured " &
    "infiltration."
        Me.NrcsInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsOptionsButton
        '
        Me.NrcsOptionsButton.AccessibleDescription = "Press to edit the options associated with the NRCS Intake Family selection."
        Me.NrcsOptionsButton.AccessibleName = "NRCS Options Button"
        Me.NrcsOptionsButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.NrcsOptionsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsOptionsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.NrcsOptionsButton.Location = New System.Drawing.Point(253, 171)
        Me.NrcsOptionsButton.Name = "NrcsOptionsButton"
        Me.NrcsOptionsButton.Size = New System.Drawing.Size(96, 25)
        Me.NrcsOptionsButton.TabIndex = 20
        Me.NrcsOptionsButton.Text = "&Options ..."
        Me.NrcsOptionsButton.UseVisualStyleBackColor = False
        '
        'Sel_400
        '
        Me.Sel_400.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_400.Location = New System.Drawing.Point(265, 146)
        Me.Sel_400.Name = "Sel_400"
        Me.Sel_400.Size = New System.Drawing.Size(64, 24)
        Me.Sel_400.TabIndex = 19
        Me.Sel_400.Text = "4.00"
        '
        'Sel_300
        '
        Me.Sel_300.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_300.Location = New System.Drawing.Point(265, 120)
        Me.Sel_300.Name = "Sel_300"
        Me.Sel_300.Size = New System.Drawing.Size(64, 24)
        Me.Sel_300.TabIndex = 18
        Me.Sel_300.Text = "3.00"
        '
        'Sel_090
        '
        Me.Sel_090.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_090.Location = New System.Drawing.Point(180, 146)
        Me.Sel_090.Name = "Sel_090"
        Me.Sel_090.Size = New System.Drawing.Size(64, 24)
        Me.Sel_090.TabIndex = 14
        Me.Sel_090.Text = "0.90"
        '
        'Sel_200
        '
        Me.Sel_200.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_200.Location = New System.Drawing.Point(265, 94)
        Me.Sel_200.Name = "Sel_200"
        Me.Sel_200.Size = New System.Drawing.Size(64, 24)
        Me.Sel_200.TabIndex = 17
        Me.Sel_200.Text = "2.00"
        '
        'Sel_150
        '
        Me.Sel_150.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_150.Location = New System.Drawing.Point(265, 68)
        Me.Sel_150.Name = "Sel_150"
        Me.Sel_150.Size = New System.Drawing.Size(64, 24)
        Me.Sel_150.TabIndex = 16
        Me.Sel_150.Text = "1.50"
        '
        'Sel_100
        '
        Me.Sel_100.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_100.Location = New System.Drawing.Point(180, 172)
        Me.Sel_100.Name = "Sel_100"
        Me.Sel_100.Size = New System.Drawing.Size(64, 24)
        Me.Sel_100.TabIndex = 15
        Me.Sel_100.Text = "1.00"
        '
        'Sel_080
        '
        Me.Sel_080.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_080.Location = New System.Drawing.Point(180, 120)
        Me.Sel_080.Name = "Sel_080"
        Me.Sel_080.Size = New System.Drawing.Size(64, 24)
        Me.Sel_080.TabIndex = 13
        Me.Sel_080.Text = "0.80"
        '
        'Sel_070
        '
        Me.Sel_070.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_070.Location = New System.Drawing.Point(180, 94)
        Me.Sel_070.Name = "Sel_070"
        Me.Sel_070.Size = New System.Drawing.Size(64, 24)
        Me.Sel_070.TabIndex = 12
        Me.Sel_070.Text = "0.70"
        '
        'Sel_060
        '
        Me.Sel_060.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_060.Location = New System.Drawing.Point(180, 68)
        Me.Sel_060.Name = "Sel_060"
        Me.Sel_060.Size = New System.Drawing.Size(64, 24)
        Me.Sel_060.TabIndex = 11
        Me.Sel_060.Text = "0.60"
        '
        'Sel_050
        '
        Me.Sel_050.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_050.Location = New System.Drawing.Point(95, 172)
        Me.Sel_050.Name = "Sel_050"
        Me.Sel_050.Size = New System.Drawing.Size(64, 24)
        Me.Sel_050.TabIndex = 10
        Me.Sel_050.Text = "0.50"
        '
        'Sel_045
        '
        Me.Sel_045.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_045.Location = New System.Drawing.Point(95, 146)
        Me.Sel_045.Name = "Sel_045"
        Me.Sel_045.Size = New System.Drawing.Size(64, 24)
        Me.Sel_045.TabIndex = 9
        Me.Sel_045.Text = "0.45"
        '
        'Sel_040
        '
        Me.Sel_040.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_040.Location = New System.Drawing.Point(95, 120)
        Me.Sel_040.Name = "Sel_040"
        Me.Sel_040.Size = New System.Drawing.Size(64, 24)
        Me.Sel_040.TabIndex = 8
        Me.Sel_040.Text = "0.40"
        '
        'Sel_035
        '
        Me.Sel_035.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_035.Location = New System.Drawing.Point(95, 94)
        Me.Sel_035.Name = "Sel_035"
        Me.Sel_035.Size = New System.Drawing.Size(64, 24)
        Me.Sel_035.TabIndex = 7
        Me.Sel_035.Text = "0.35"
        '
        'Sel_030
        '
        Me.Sel_030.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_030.Location = New System.Drawing.Point(95, 68)
        Me.Sel_030.Name = "Sel_030"
        Me.Sel_030.Size = New System.Drawing.Size(64, 24)
        Me.Sel_030.TabIndex = 6
        Me.Sel_030.Text = "0.30"
        '
        'Sel_025
        '
        Me.Sel_025.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_025.Location = New System.Drawing.Point(10, 172)
        Me.Sel_025.Name = "Sel_025"
        Me.Sel_025.Size = New System.Drawing.Size(64, 24)
        Me.Sel_025.TabIndex = 5
        Me.Sel_025.Text = "0.25"
        '
        'Sel_020
        '
        Me.Sel_020.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_020.Location = New System.Drawing.Point(10, 146)
        Me.Sel_020.Name = "Sel_020"
        Me.Sel_020.Size = New System.Drawing.Size(64, 24)
        Me.Sel_020.TabIndex = 4
        Me.Sel_020.Text = "0.20"
        '
        'Sel_015
        '
        Me.Sel_015.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_015.Location = New System.Drawing.Point(10, 120)
        Me.Sel_015.Name = "Sel_015"
        Me.Sel_015.Size = New System.Drawing.Size(64, 24)
        Me.Sel_015.TabIndex = 3
        Me.Sel_015.Text = "0.15"
        '
        'Sel_010
        '
        Me.Sel_010.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_010.Location = New System.Drawing.Point(10, 94)
        Me.Sel_010.Name = "Sel_010"
        Me.Sel_010.Size = New System.Drawing.Size(64, 24)
        Me.Sel_010.TabIndex = 2
        Me.Sel_010.Text = "0.10"
        '
        'Sel_005
        '
        Me.Sel_005.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_005.Location = New System.Drawing.Point(10, 68)
        Me.Sel_005.Name = "Sel_005"
        Me.Sel_005.Size = New System.Drawing.Size(64, 24)
        Me.Sel_005.TabIndex = 1
        Me.Sel_005.Text = "0.05"
        '
        'KostiakovFormulaBox
        '
        Me.KostiakovFormulaBox.AccessibleDescription = "Wetted perimeter and infiltration parameters."
        Me.KostiakovFormulaBox.AccessibleName = "Kostiakov Formula"
        Me.KostiakovFormulaBox.Controls.Add(Me.KF_kControl)
        Me.KostiakovFormulaBox.Controls.Add(Me.KF_Instructions)
        Me.KostiakovFormulaBox.Controls.Add(Me.KF_kLabel)
        Me.KostiakovFormulaBox.Controls.Add(Me.KF_aControl)
        Me.KostiakovFormulaBox.Controls.Add(Me.KF_aLabel)
        Me.KostiakovFormulaBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostiakovFormulaBox.Location = New System.Drawing.Point(6, 160)
        Me.KostiakovFormulaBox.Name = "KostiakovFormulaBox"
        Me.KostiakovFormulaBox.Size = New System.Drawing.Size(358, 200)
        Me.KostiakovFormulaBox.TabIndex = 1
        Me.KostiakovFormulaBox.TabStop = False
        Me.KostiakovFormulaBox.Text = "Parameters"
        '
        'KF_kControl
        '
        Me.KF_kControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KF_kControl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.KF_kControl.Location = New System.Drawing.Point(163, 109)
        Me.KF_kControl.Name = "KF_kControl"
        Me.KF_kControl.Size = New System.Drawing.Size(120, 24)
        Me.KF_kControl.TabIndex = 4
        Me.KF_kControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KF_kControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KF_kControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KF_kControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KF_kControl.ValueText = ""
        '
        'KF_Instructions
        '
        Me.KF_Instructions.BackColor = System.Drawing.SystemColors.Info
        Me.KF_Instructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.KF_Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KF_Instructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.KF_Instructions.Location = New System.Drawing.Point(6, 20)
        Me.KF_Instructions.Name = "KF_Instructions"
        Me.KF_Instructions.Size = New System.Drawing.Size(346, 40)
        Me.KF_Instructions.TabIndex = 0
        Me.KF_Instructions.Text = "Edit the Kostiakov Formula parameters to fit the predicted infiltration to the me" &
    "asured infiltration."
        Me.KF_Instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KF_kLabel
        '
        Me.KF_kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KF_kLabel.Location = New System.Drawing.Point(131, 109)
        Me.KF_kLabel.Name = "KF_kLabel"
        Me.KF_kLabel.Size = New System.Drawing.Size(24, 23)
        Me.KF_kLabel.TabIndex = 3
        Me.KF_kLabel.Text = "&k"
        Me.KF_kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KF_aControl
        '
        Me.KF_aControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KF_aControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KF_aControl.IsCalculated = False
        Me.KF_aControl.IsInteger = False
        Me.KF_aControl.Location = New System.Drawing.Point(163, 134)
        Me.KF_aControl.MaxErrMsg = ""
        Me.KF_aControl.MinErrMsg = ""
        Me.KF_aControl.Name = "KF_aControl"
        Me.KF_aControl.Size = New System.Drawing.Size(120, 24)
        Me.KF_aControl.TabIndex = 6
        Me.KF_aControl.ToBeCalculated = True
        Me.KF_aControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KF_aControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KF_aControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KF_aControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KF_aControl.ValueText = ""
        '
        'KF_aLabel
        '
        Me.KF_aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KF_aLabel.Location = New System.Drawing.Point(131, 134)
        Me.KF_aLabel.Name = "KF_aLabel"
        Me.KF_aLabel.Size = New System.Drawing.Size(24, 23)
        Me.KF_aLabel.TabIndex = 5
        Me.KF_aLabel.Text = "&a"
        Me.KF_aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ctl_Evalue
        '
        Me.AccessibleDescription = ""
        Me.AccessibleName = ""
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.EvalueBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_Evalue"
        Me.Size = New System.Drawing.Size(379, 400)
        Me.StandardInfiltrationGroup.ResumeLayout(False)
        Me.RefInflowPanel.ResumeLayout(False)
        Me.EvalueBox.ResumeLayout(False)
        Me.AdvancedInfiltrationGroup.ResumeLayout(False)
        Me.BranchFunctionBox.ResumeLayout(False)
        Me.TimeRatedFamilyBox.ResumeLayout(False)
        Me.CharacteristicTimeBox.ResumeLayout(False)
        Me.CharacteristicTimeBox.PerformLayout()
        Me.ModifiedKostiakovBox.ResumeLayout(False)
        Me.GreenAmptBox.ResumeLayout(False)
        Me.WarrickGreenAmptBox.ResumeLayout(False)
        Me.NrcsIntakeFamilyGroup.ResumeLayout(False)
        Me.KostiakovFormulaBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StandardInfiltrationGroup As DataStore.ctl_GroupBox
    Friend WithEvents EvalueBox As DataStore.ctl_GroupBox
    Friend WithEvents WarrickGreenAmptBox As DataStore.ctl_GroupBox
    Friend WithEvents NrcsIntakeFamilyGroup As DataStore.ctl_GroupBox
    Friend WithEvents NrcsInstruction As DataStore.ctl_Label
    Friend WithEvents NrcsOptionsButton As DataStore.ctl_Button
    Friend WithEvents Sel_400 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_300 As DataStore.ctl_RadioButton
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
    Friend WithEvents TimeRatedFamilyBox As DataStore.ctl_GroupBox
    Friend WithEvents TR_Instructions As DataStore.ctl_Label
    Friend WithEvents TR_InfiltrationDepthControl As DataStore.ctl_Label
    Friend WithEvents TR_InfiltrationTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents TR_InfiltrationTimeLabel As DataStore.ctl_Label
    Friend WithEvents TR_InfiltrationDepthLabel As DataStore.ctl_Label
    Friend WithEvents CharacteristicTimeBox As DataStore.ctl_GroupBox
    Friend WithEvents KT_Instructions As DataStore.ctl_Label
    Friend WithEvents KT_InfiltrationTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_KostiakovAControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_InfiltrationDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_InfiltrationTimeLabel As DataStore.ctl_Label
    Friend WithEvents KT_KostiakovALabel As System.Windows.Forms.Label
    Friend WithEvents KT_InfiltrationDepthLabel As DataStore.ctl_Label
    Friend WithEvents KostiakovFormulaBox As DataStore.ctl_GroupBox
    Friend WithEvents KF_kControl As WinMain.ctl_KostiakovKParameter
    Friend WithEvents KF_Instructions As DataStore.ctl_Label
    Friend WithEvents KF_kLabel As System.Windows.Forms.Label
    Friend WithEvents KF_aControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KF_aLabel As System.Windows.Forms.Label
    Friend WithEvents ModifiedKostiakovBox As DataStore.ctl_GroupBox
    Friend WithEvents MK_kControl As WinMain.ctl_KostiakovKParameter
    Friend WithEvents MK_cControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MK_Instructions As DataStore.ctl_Label
    Friend WithEvents MK_kLabel As System.Windows.Forms.Label
    Friend WithEvents MK_bControl As WinMain.ctl_KostiakovBParameter
    Friend WithEvents MK_cLabel As System.Windows.Forms.Label
    Friend WithEvents MK_bLabel As System.Windows.Forms.Label
    Friend WithEvents MK_aLabel As System.Windows.Forms.Label
    Friend WithEvents BranchFunctionBox As DataStore.ctl_GroupBox
    Friend WithEvents BF_kControl As WinMain.ctl_KostiakovKParameter
    Friend WithEvents BF_cControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_Instructions As DataStore.ctl_Label
    Friend WithEvents BF_kLabel As System.Windows.Forms.Label
    Friend WithEvents BF_bControl As WinMain.ctl_KostiakovBParameter
    Friend WithEvents BF_aControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_cLabel As System.Windows.Forms.Label
    Friend WithEvents BF_bLabel As System.Windows.Forms.Label
    Friend WithEvents BF_aLabel As System.Windows.Forms.Label
    Friend WithEvents GreenAmptBox As DataStore.ctl_GroupBox
    Friend WithEvents GA_Instructions As DataStore.ctl_Label
    Friend WithEvents GA_cControl As DataStore.ctl_DoubleParameter
    Friend WithEvents GAcLabel As DataStore.ctl_Label
    Friend WithEvents GA_HydraulicConductivityControl As DataStore.ctl_DoubleParameter
    Friend WithEvents HydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents GA_WettingFrontControl As DataStore.ctl_DoubleParameter
    Friend WithEvents AirEntryPressureLabel As DataStore.ctl_Label
    Friend WithEvents GA_InitVolWaterContentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents InitVolWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents GA_PorosityControl As DataStore.ctl_DoubleParameter
    Friend WithEvents EffectivePorosityLabel As DataStore.ctl_Label
    Friend WithEvents WGA_Instructions As DataStore.ctl_Label
    Friend WithEvents WGA_cControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_InstantaneousInfiltrationLabel As DataStore.ctl_Label
    Friend WithEvents WGA_HydraulicConductivityControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_HydraulicConductivityLabel As DataStore.ctl_Label
    Friend WithEvents WGA_WettingFrontControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_WettingFrontLabel As DataStore.ctl_Label
    Friend WithEvents WGA_InitWaterContentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_InitWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents WGA_SatWaterContentControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WGA_SatWaterContentLabel As DataStore.ctl_Label
    Friend WithEvents StdInfiltrationHelp As DataStore.ctl_Button
    Friend WithEvents KT_WettedPerimeter As DataStore.ctl_Label
    Friend WithEvents MK_aControl As DataStore.ctl_DoubleParameter
    Friend WithEvents AdvancedInfiltrationGroup As DataStore.ctl_GroupBox
    Friend WithEvents AdvInfiltrationHelp As DataStore.ctl_Button
    Friend WithEvents ShowAdvancedFunctions As DataStore.ctl_Button
    Friend WithEvents ShowStandardFunctions As DataStore.ctl_Button
    Friend WithEvents StdInfiltrationEquationControl As DataStore.ctl_SelectParameter
    Friend WithEvents StdInfiltrationEquationLabel As DataStore.ctl_Label
    Friend WithEvents StdWettedPerimeterControl As DataStore.ctl_SelectParameter
    Friend WithEvents StdWettedPerimeterLabel As DataStore.ctl_Label
    Friend WithEvents AdvInfiltrationEquationControl As DataStore.ctl_SelectParameter
    Friend WithEvents AdvInfiltrationEquationLabel As DataStore.ctl_Label
    Friend WithEvents AdvWettedPerimeterLabel As DataStore.ctl_Label
    Friend WithEvents AdvWettedPerimeterControl As DataStore.ctl_SelectParameter
    Friend WithEvents UseInfiltrationEditorButton As DataStore.ctl_Button
    Friend WithEvents KT_KostiakovK As System.Windows.Forms.Label
    Friend WithEvents TR_KostiakovA As System.Windows.Forms.Label
    Friend WithEvents TR_KostiakovK As System.Windows.Forms.Label
    Friend WithEvents RefInflowPanel As DataStore.ctl_Panel
    Friend WithEvents RefInflowLabel As DataStore.ctl_Label
    Friend WithEvents RefInflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_BranchTimeValue As DataStore.ctl_Label
    Friend WithEvents BF_BranchTimeSet As DataStore.ctl_CheckParameter
    Friend WithEvents BF_BranchTimeControl As DataStore.ctl_DoubleParameter

End Class
