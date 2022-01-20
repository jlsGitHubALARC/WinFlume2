
'*************************************************************************************************************
' ctl_EvaluationWorld - Evaluation World Tab UI
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_EvaluationWorld
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
    Friend WithEvents EventWorldHelp As System.Windows.Forms.RichTextBox
    Friend WithEvents EventAnalysisBox As DataStore.ctl_GroupBox
    Friend WithEvents ElliotWalkerButton As DataStore.ctl_RadioButton
    Friend WithEvents MerriamKellerButton As DataStore.ctl_RadioButton
    Friend WithEvents InfiltratedProfileButton As DataStore.ctl_RadioButton
    Friend WithEvents SystemTypeGroup As DataStore.ctl_GroupBox
    Friend WithEvents FurrowButton As DataStore.ctl_RadioButton
    Friend WithEvents BasinBorderButton As DataStore.ctl_RadioButton
    Friend WithEvents AnalysisWorldUsage As System.Windows.Forms.RichTextBox
    Friend WithEvents IrrigationWaterUseBox As DataStore.ctl_GroupBox
    Friend WithEvents UnitWaterCostControl As DataStore.ctl_DoubleParameter
    Friend WithEvents UnitWaterCostLabel As DataStore.ctl_Label
    Friend WithEvents RequiredDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RequiredDepthLabel As DataStore.ctl_Label
    Friend WithEvents EvalueButton As DataStore.ctl_RadioButton
    Friend WithEvents IHaveDataLabel As DataStore.ctl_Label
    Friend WithEvents RecessionTimesCheck As DataStore.ctl_CheckParameter
    Friend WithEvents AdvanceTimesCheck As DataStore.ctl_CheckParameter
    Friend WithEvents RunoffHydrographCheck As DataStore.ctl_CheckParameter
    Friend WithEvents InflowHydrographCheck As DataStore.ctl_CheckParameter
    Friend WithEvents FlowDepthCheck As DataStore.ctl_CheckParameter
    Friend WithEvents DownstreamRunoffGroup As DataStore.ctl_GroupBox
    Friend WithEvents OpenEndButton As DataStore.ctl_RadioButton
    Friend WithEvents BlockedEndButton As DataStore.ctl_RadioButton
    Friend WithEvents UseForVbLabel As DataStore.ctl_Label
    Friend WithEvents UseFlowDepthsCheck As DataStore.ctl_CheckParameter
    Friend WithEvents UseRecessionCheck As DataStore.ctl_CheckParameter
    Friend WithEvents UseRunoffCheck As DataStore.ctl_CheckParameter
    Friend WithEvents EventWorldTitle As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_EvaluationWorld))
        Me.EventWorldHelp = New System.Windows.Forms.RichTextBox()
        Me.EventAnalysisBox = New DataStore.ctl_GroupBox()
        Me.UseFlowDepthsCheck = New DataStore.ctl_CheckParameter()
        Me.UseRecessionCheck = New DataStore.ctl_CheckParameter()
        Me.UseRunoffCheck = New DataStore.ctl_CheckParameter()
        Me.UseForVbLabel = New DataStore.ctl_Label()
        Me.FlowDepthCheck = New DataStore.ctl_CheckParameter()
        Me.RecessionTimesCheck = New DataStore.ctl_CheckParameter()
        Me.AdvanceTimesCheck = New DataStore.ctl_CheckParameter()
        Me.RunoffHydrographCheck = New DataStore.ctl_CheckParameter()
        Me.InflowHydrographCheck = New DataStore.ctl_CheckParameter()
        Me.IHaveDataLabel = New DataStore.ctl_Label()
        Me.EvalueButton = New DataStore.ctl_RadioButton()
        Me.ElliotWalkerButton = New DataStore.ctl_RadioButton()
        Me.MerriamKellerButton = New DataStore.ctl_RadioButton()
        Me.InfiltratedProfileButton = New DataStore.ctl_RadioButton()
        Me.SystemTypeGroup = New DataStore.ctl_GroupBox()
        Me.FurrowButton = New DataStore.ctl_RadioButton()
        Me.BasinBorderButton = New DataStore.ctl_RadioButton()
        Me.AnalysisWorldUsage = New System.Windows.Forms.RichTextBox()
        Me.EventWorldTitle = New DataStore.ctl_Label()
        Me.IrrigationWaterUseBox = New DataStore.ctl_GroupBox()
        Me.UnitWaterCostControl = New DataStore.ctl_DoubleParameter()
        Me.UnitWaterCostLabel = New DataStore.ctl_Label()
        Me.RequiredDepthControl = New DataStore.ctl_DoubleParameter()
        Me.RequiredDepthLabel = New DataStore.ctl_Label()
        Me.DownstreamRunoffGroup = New DataStore.ctl_GroupBox()
        Me.OpenEndButton = New DataStore.ctl_RadioButton()
        Me.BlockedEndButton = New DataStore.ctl_RadioButton()
        Me.EventAnalysisBox.SuspendLayout()
        Me.SystemTypeGroup.SuspendLayout()
        Me.IrrigationWaterUseBox.SuspendLayout()
        Me.DownstreamRunoffGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'EventWorldHelp
        '
        Me.EventWorldHelp.AccessibleDescription = "Provides help on the functionality and required inputs for an irrigation analysis" &
    "."
        Me.EventWorldHelp.AccessibleName = "Event Analysis Help"
        Me.EventWorldHelp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.EventWorldHelp.Location = New System.Drawing.Point(437, 152)
        Me.EventWorldHelp.Name = "EventWorldHelp"
        Me.EventWorldHelp.ReadOnly = True
        Me.EventWorldHelp.Size = New System.Drawing.Size(333, 268)
        Me.EventWorldHelp.TabIndex = 6
        Me.EventWorldHelp.TabStop = False
        Me.EventWorldHelp.Text = ""
        '
        'EventAnalysisBox
        '
        Me.EventAnalysisBox.AccessibleDescription = "Selects the particular irrigation analysis method to use and indicates what field" &
    " measurements are available for this analysis."
        Me.EventAnalysisBox.AccessibleName = "Irrigation Event Analysis"
        Me.EventAnalysisBox.Controls.Add(Me.UseFlowDepthsCheck)
        Me.EventAnalysisBox.Controls.Add(Me.UseRecessionCheck)
        Me.EventAnalysisBox.Controls.Add(Me.UseRunoffCheck)
        Me.EventAnalysisBox.Controls.Add(Me.UseForVbLabel)
        Me.EventAnalysisBox.Controls.Add(Me.FlowDepthCheck)
        Me.EventAnalysisBox.Controls.Add(Me.RecessionTimesCheck)
        Me.EventAnalysisBox.Controls.Add(Me.AdvanceTimesCheck)
        Me.EventAnalysisBox.Controls.Add(Me.RunoffHydrographCheck)
        Me.EventAnalysisBox.Controls.Add(Me.InflowHydrographCheck)
        Me.EventAnalysisBox.Controls.Add(Me.IHaveDataLabel)
        Me.EventAnalysisBox.Controls.Add(Me.EvalueButton)
        Me.EventAnalysisBox.Controls.Add(Me.ElliotWalkerButton)
        Me.EventAnalysisBox.Controls.Add(Me.MerriamKellerButton)
        Me.EventAnalysisBox.Controls.Add(Me.InfiltratedProfileButton)
        Me.EventAnalysisBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventAnalysisBox.Location = New System.Drawing.Point(10, 145)
        Me.EventAnalysisBox.Name = "EventAnalysisBox"
        Me.EventAnalysisBox.Size = New System.Drawing.Size(421, 275)
        Me.EventAnalysisBox.TabIndex = 5
        Me.EventAnalysisBox.TabStop = False
        Me.EventAnalysisBox.Text = "Select Event Analysis"
        '
        'UseFlowDepthsCheck
        '
        Me.UseFlowDepthsCheck.AlwaysChecked = False
        Me.UseFlowDepthsCheck.AutoSize = True
        Me.UseFlowDepthsCheck.ErrorMessage = Nothing
        Me.UseFlowDepthsCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseFlowDepthsCheck.Location = New System.Drawing.Point(262, 232)
        Me.UseFlowDepthsCheck.Name = "UseFlowDepthsCheck"
        Me.UseFlowDepthsCheck.Size = New System.Drawing.Size(104, 21)
        Me.UseFlowDepthsCheck.TabIndex = 14
        Me.UseFlowDepthsCheck.Text = "Flow Depths"
        Me.UseFlowDepthsCheck.UncheckAttemptMessage = Nothing
        Me.UseFlowDepthsCheck.UseVisualStyleBackColor = True
        '
        'UseRecessionCheck
        '
        Me.UseRecessionCheck.AlwaysChecked = False
        Me.UseRecessionCheck.AutoSize = True
        Me.UseRecessionCheck.ErrorMessage = Nothing
        Me.UseRecessionCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseRecessionCheck.Location = New System.Drawing.Point(262, 212)
        Me.UseRecessionCheck.Name = "UseRecessionCheck"
        Me.UseRecessionCheck.Size = New System.Drawing.Size(93, 21)
        Me.UseRecessionCheck.TabIndex = 13
        Me.UseRecessionCheck.Text = "Recession"
        Me.UseRecessionCheck.UncheckAttemptMessage = Nothing
        Me.UseRecessionCheck.UseVisualStyleBackColor = True
        '
        'UseRunoffCheck
        '
        Me.UseRunoffCheck.AlwaysChecked = False
        Me.UseRunoffCheck.AutoSize = True
        Me.UseRunoffCheck.ErrorMessage = Nothing
        Me.UseRunoffCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseRunoffCheck.Location = New System.Drawing.Point(262, 192)
        Me.UseRunoffCheck.Name = "UseRunoffCheck"
        Me.UseRunoffCheck.Size = New System.Drawing.Size(69, 21)
        Me.UseRunoffCheck.TabIndex = 12
        Me.UseRunoffCheck.Text = "Runoff"
        Me.UseRunoffCheck.UncheckAttemptMessage = Nothing
        Me.UseRunoffCheck.UseVisualStyleBackColor = True
        '
        'UseForVbLabel
        '
        Me.UseForVbLabel.AutoSize = True
        Me.UseForVbLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseForVbLabel.Location = New System.Drawing.Point(252, 168)
        Me.UseForVbLabel.Name = "UseForVbLabel"
        Me.UseForVbLabel.Size = New System.Drawing.Size(165, 17)
        Me.UseForVbLabel.TabIndex = 12
        Me.UseForVbLabel.Text = "&Use for VB analysis..."
        Me.UseForVbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FlowDepthCheck
        '
        Me.FlowDepthCheck.AlwaysChecked = False
        Me.FlowDepthCheck.AutoSize = True
        Me.FlowDepthCheck.ErrorMessage = Nothing
        Me.FlowDepthCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowDepthCheck.Location = New System.Drawing.Point(35, 232)
        Me.FlowDepthCheck.Name = "FlowDepthCheck"
        Me.FlowDepthCheck.Size = New System.Drawing.Size(183, 21)
        Me.FlowDepthCheck.TabIndex = 11
        Me.FlowDepthCheck.Text = "Flow Depth Hydrographs"
        Me.FlowDepthCheck.UncheckAttemptMessage = Nothing
        Me.FlowDepthCheck.UseVisualStyleBackColor = True
        '
        'RecessionTimesCheck
        '
        Me.RecessionTimesCheck.AlwaysChecked = False
        Me.RecessionTimesCheck.AutoSize = True
        Me.RecessionTimesCheck.ErrorMessage = Nothing
        Me.RecessionTimesCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecessionTimesCheck.Location = New System.Drawing.Point(35, 212)
        Me.RecessionTimesCheck.Name = "RecessionTimesCheck"
        Me.RecessionTimesCheck.Size = New System.Drawing.Size(135, 21)
        Me.RecessionTimesCheck.TabIndex = 10
        Me.RecessionTimesCheck.Text = "Recession Times"
        Me.RecessionTimesCheck.UncheckAttemptMessage = Nothing
        Me.RecessionTimesCheck.UseVisualStyleBackColor = True
        '
        'AdvanceTimesCheck
        '
        Me.AdvanceTimesCheck.AlwaysChecked = False
        Me.AdvanceTimesCheck.AutoSize = True
        Me.AdvanceTimesCheck.ErrorMessage = Nothing
        Me.AdvanceTimesCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvanceTimesCheck.Location = New System.Drawing.Point(35, 173)
        Me.AdvanceTimesCheck.Name = "AdvanceTimesCheck"
        Me.AdvanceTimesCheck.Size = New System.Drawing.Size(124, 21)
        Me.AdvanceTimesCheck.TabIndex = 8
        Me.AdvanceTimesCheck.Text = "Advance Times"
        Me.AdvanceTimesCheck.UncheckAttemptMessage = Nothing
        Me.AdvanceTimesCheck.UseVisualStyleBackColor = True
        '
        'RunoffHydrographCheck
        '
        Me.RunoffHydrographCheck.AlwaysChecked = False
        Me.RunoffHydrographCheck.AutoSize = True
        Me.RunoffHydrographCheck.ErrorMessage = Nothing
        Me.RunoffHydrographCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunoffHydrographCheck.Location = New System.Drawing.Point(35, 192)
        Me.RunoffHydrographCheck.Name = "RunoffHydrographCheck"
        Me.RunoffHydrographCheck.Size = New System.Drawing.Size(148, 21)
        Me.RunoffHydrographCheck.TabIndex = 9
        Me.RunoffHydrographCheck.Text = "Runoff Hydrograph"
        Me.RunoffHydrographCheck.UncheckAttemptMessage = Nothing
        Me.RunoffHydrographCheck.UseVisualStyleBackColor = True
        '
        'InflowHydrographCheck
        '
        Me.InflowHydrographCheck.AlwaysChecked = False
        Me.InflowHydrographCheck.AutoSize = True
        Me.InflowHydrographCheck.ErrorMessage = Nothing
        Me.InflowHydrographCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowHydrographCheck.Location = New System.Drawing.Point(35, 153)
        Me.InflowHydrographCheck.Name = "InflowHydrographCheck"
        Me.InflowHydrographCheck.Size = New System.Drawing.Size(141, 21)
        Me.InflowHydrographCheck.TabIndex = 7
        Me.InflowHydrographCheck.Text = "Inflow Hydrograph"
        Me.InflowHydrographCheck.UncheckAttemptMessage = Nothing
        Me.InflowHydrographCheck.UseVisualStyleBackColor = True
        '
        'IHaveDataLabel
        '
        Me.IHaveDataLabel.AutoSize = True
        Me.IHaveDataLabel.Location = New System.Drawing.Point(25, 130)
        Me.IHaveDataLabel.Name = "IHaveDataLabel"
        Me.IHaveDataLabel.Size = New System.Drawing.Size(204, 17)
        Me.IHaveDataLabel.TabIndex = 6
        Me.IHaveDataLabel.Text = "&Available measurements ..."
        Me.IHaveDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EvalueButton
        '
        Me.EvalueButton.AutoSize = True
        Me.EvalueButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvalueButton.Location = New System.Drawing.Point(20, 99)
        Me.EvalueButton.Name = "EvalueButton"
        Me.EvalueButton.Size = New System.Drawing.Size(183, 21)
        Me.EvalueButton.TabIndex = 4
        Me.EvalueButton.Text = "E&VALUE volume balance"
        '
        'ElliotWalkerButton
        '
        Me.ElliotWalkerButton.AutoSize = True
        Me.ElliotWalkerButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElliotWalkerButton.Location = New System.Drawing.Point(20, 79)
        Me.ElliotWalkerButton.Name = "ElliotWalkerButton"
        Me.ElliotWalkerButton.Size = New System.Drawing.Size(221, 21)
        Me.ElliotWalkerButton.TabIndex = 3
        Me.ElliotWalkerButton.Text = "&Elliott-Walker two-point method"
        '
        'MerriamKellerButton
        '
        Me.MerriamKellerButton.AutoSize = True
        Me.MerriamKellerButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MerriamKellerButton.Location = New System.Drawing.Point(20, 59)
        Me.MerriamKellerButton.Name = "MerriamKellerButton"
        Me.MerriamKellerButton.Size = New System.Drawing.Size(312, 21)
        Me.MerriamKellerButton.TabIndex = 2
        Me.MerriamKellerButton.Text = "&Merriam-Keller post-irrigation volume balance"
        '
        'InfiltratedProfileButton
        '
        Me.InfiltratedProfileButton.AutoSize = True
        Me.InfiltratedProfileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltratedProfileButton.Location = New System.Drawing.Point(20, 28)
        Me.InfiltratedProfileButton.Name = "InfiltratedProfileButton"
        Me.InfiltratedProfileButton.Size = New System.Drawing.Size(195, 21)
        Me.InfiltratedProfileButton.TabIndex = 1
        Me.InfiltratedProfileButton.Text = "&Probe penetration analysis"
        '
        'SystemTypeGroup
        '
        Me.SystemTypeGroup.AccessibleDescription = "Selects the fundamental field type."
        Me.SystemTypeGroup.AccessibleName = "System Type"
        Me.SystemTypeGroup.Controls.Add(Me.FurrowButton)
        Me.SystemTypeGroup.Controls.Add(Me.BasinBorderButton)
        Me.SystemTypeGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemTypeGroup.Location = New System.Drawing.Point(10, 68)
        Me.SystemTypeGroup.Name = "SystemTypeGroup"
        Me.SystemTypeGroup.Size = New System.Drawing.Size(200, 73)
        Me.SystemTypeGroup.TabIndex = 2
        Me.SystemTypeGroup.TabStop = False
        Me.SystemTypeGroup.Text = "System Type"
        '
        'FurrowButton
        '
        Me.FurrowButton.AutoSize = True
        Me.FurrowButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowButton.Location = New System.Drawing.Point(11, 43)
        Me.FurrowButton.Name = "FurrowButton"
        Me.FurrowButton.Size = New System.Drawing.Size(69, 21)
        Me.FurrowButton.TabIndex = 2
        Me.FurrowButton.Text = "&Furrow"
        '
        'BasinBorderButton
        '
        Me.BasinBorderButton.AutoSize = True
        Me.BasinBorderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BasinBorderButton.Location = New System.Drawing.Point(11, 21)
        Me.BasinBorderButton.Name = "BasinBorderButton"
        Me.BasinBorderButton.Size = New System.Drawing.Size(116, 21)
        Me.BasinBorderButton.TabIndex = 1
        Me.BasinBorderButton.Text = "&Basin / Border"
        '
        'AnalysisWorldUsage
        '
        Me.AnalysisWorldUsage.BackColor = System.Drawing.SystemColors.Control
        Me.AnalysisWorldUsage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AnalysisWorldUsage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnalysisWorldUsage.Location = New System.Drawing.Point(8, 30)
        Me.AnalysisWorldUsage.Name = "AnalysisWorldUsage"
        Me.AnalysisWorldUsage.ReadOnly = True
        Me.AnalysisWorldUsage.Size = New System.Drawing.Size(760, 38)
        Me.AnalysisWorldUsage.TabIndex = 1
        Me.AnalysisWorldUsage.TabStop = False
        Me.AnalysisWorldUsage.Text = resources.GetString("AnalysisWorldUsage.Text")
        '
        'EventWorldTitle
        '
        Me.EventWorldTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventWorldTitle.Location = New System.Drawing.Point(8, 5)
        Me.EventWorldTitle.Name = "EventWorldTitle"
        Me.EventWorldTitle.Size = New System.Drawing.Size(760, 23)
        Me.EventWorldTitle.TabIndex = 0
        Me.EventWorldTitle.Text = "Event Analysis World"
        Me.EventWorldTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'IrrigationWaterUseBox
        '
        Me.IrrigationWaterUseBox.AccessibleDescription = "Sets the required infiltration depth and unit water cost."
        Me.IrrigationWaterUseBox.AccessibleName = "Irrigation Water Use"
        Me.IrrigationWaterUseBox.Controls.Add(Me.UnitWaterCostControl)
        Me.IrrigationWaterUseBox.Controls.Add(Me.UnitWaterCostLabel)
        Me.IrrigationWaterUseBox.Controls.Add(Me.RequiredDepthControl)
        Me.IrrigationWaterUseBox.Controls.Add(Me.RequiredDepthLabel)
        Me.IrrigationWaterUseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IrrigationWaterUseBox.Location = New System.Drawing.Point(437, 68)
        Me.IrrigationWaterUseBox.Name = "IrrigationWaterUseBox"
        Me.IrrigationWaterUseBox.Size = New System.Drawing.Size(333, 73)
        Me.IrrigationWaterUseBox.TabIndex = 4
        Me.IrrigationWaterUseBox.TabStop = False
        Me.IrrigationWaterUseBox.Text = "Irrigation Water Use"
        '
        'UnitWaterCostControl
        '
        Me.UnitWaterCostControl.AccessibleDescription = "The cost of the irrigation water."
        Me.UnitWaterCostControl.AccessibleName = "Unit Water Cost"
        Me.UnitWaterCostControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.UnitWaterCostControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitWaterCostControl.IsCalculated = False
        Me.UnitWaterCostControl.IsInteger = False
        Me.UnitWaterCostControl.Location = New System.Drawing.Point(164, 45)
        Me.UnitWaterCostControl.MaxErrMsg = ""
        Me.UnitWaterCostControl.MinErrMsg = ""
        Me.UnitWaterCostControl.Name = "UnitWaterCostControl"
        Me.UnitWaterCostControl.Size = New System.Drawing.Size(121, 24)
        Me.UnitWaterCostControl.TabIndex = 3
        Me.UnitWaterCostControl.ToBeCalculated = True
        Me.UnitWaterCostControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.UnitWaterCostControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.UnitWaterCostControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.UnitWaterCostControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.UnitWaterCostControl.ValueText = ""
        '
        'UnitWaterCostLabel
        '
        Me.UnitWaterCostLabel.AccessibleDescription = "Cost per unit of irrigation water applied to field."
        Me.UnitWaterCostLabel.AccessibleName = "Unit Water Cost"
        Me.UnitWaterCostLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitWaterCostLabel.Location = New System.Drawing.Point(9, 45)
        Me.UnitWaterCostLabel.Name = "UnitWaterCostLabel"
        Me.UnitWaterCostLabel.Size = New System.Drawing.Size(149, 23)
        Me.UnitWaterCostLabel.TabIndex = 2
        Me.UnitWaterCostLabel.Text = "Unit Water &Cost"
        Me.UnitWaterCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RequiredDepthControl
        '
        Me.RequiredDepthControl.AccessibleDescription = "Defines the desired depth the irrigation water should infiltrate the soil."
        Me.RequiredDepthControl.AccessibleName = "Required Depth"
        Me.RequiredDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RequiredDepthControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredDepthControl.IsCalculated = False
        Me.RequiredDepthControl.IsInteger = False
        Me.RequiredDepthControl.Location = New System.Drawing.Point(164, 20)
        Me.RequiredDepthControl.MaxErrMsg = ""
        Me.RequiredDepthControl.MinErrMsg = ""
        Me.RequiredDepthControl.Name = "RequiredDepthControl"
        Me.RequiredDepthControl.Size = New System.Drawing.Size(121, 24)
        Me.RequiredDepthControl.TabIndex = 1
        Me.RequiredDepthControl.ToBeCalculated = True
        Me.RequiredDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.RequiredDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.RequiredDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.RequiredDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.RequiredDepthControl.ValueText = ""
        '
        'RequiredDepthLabel
        '
        Me.RequiredDepthLabel.AccessibleDescription = "Required infiltration depth, Dreq, for this irrigation."
        Me.RequiredDepthLabel.AccessibleName = "Required Depth"
        Me.RequiredDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredDepthLabel.Location = New System.Drawing.Point(6, 19)
        Me.RequiredDepthLabel.Name = "RequiredDepthLabel"
        Me.RequiredDepthLabel.Size = New System.Drawing.Size(152, 23)
        Me.RequiredDepthLabel.TabIndex = 0
        Me.RequiredDepthLabel.Text = "Required &Depth"
        Me.RequiredDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DownstreamRunoffGroup
        '
        Me.DownstreamRunoffGroup.AccessibleDescription = "Selects whether or not runoff is allowed."
        Me.DownstreamRunoffGroup.AccessibleName = "Downstream Condition"
        Me.DownstreamRunoffGroup.Controls.Add(Me.OpenEndButton)
        Me.DownstreamRunoffGroup.Controls.Add(Me.BlockedEndButton)
        Me.DownstreamRunoffGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownstreamRunoffGroup.Location = New System.Drawing.Point(215, 68)
        Me.DownstreamRunoffGroup.Name = "DownstreamRunoffGroup"
        Me.DownstreamRunoffGroup.Size = New System.Drawing.Size(216, 73)
        Me.DownstreamRunoffGroup.TabIndex = 3
        Me.DownstreamRunoffGroup.TabStop = False
        Me.DownstreamRunoffGroup.Text = "Downstream Condition"
        '
        'OpenEndButton
        '
        Me.OpenEndButton.AutoSize = True
        Me.OpenEndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenEndButton.Location = New System.Drawing.Point(11, 21)
        Me.OpenEndButton.Name = "OpenEndButton"
        Me.OpenEndButton.Size = New System.Drawing.Size(90, 21)
        Me.OpenEndButton.TabIndex = 0
        Me.OpenEndButton.Text = "&Open End"
        '
        'BlockedEndButton
        '
        Me.BlockedEndButton.AutoSize = True
        Me.BlockedEndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockedEndButton.Location = New System.Drawing.Point(11, 43)
        Me.BlockedEndButton.Name = "BlockedEndButton"
        Me.BlockedEndButton.Size = New System.Drawing.Size(76, 21)
        Me.BlockedEndButton.TabIndex = 1
        Me.BlockedEndButton.Text = "Bloc&ked"
        '
        'ctl_EvaluationWorld
        '
        Me.AccessibleDescription = "Select the system type and the irrigation event analysis."
        Me.AccessibleName = "Event Analysis World"
        Me.Controls.Add(Me.DownstreamRunoffGroup)
        Me.Controls.Add(Me.IrrigationWaterUseBox)
        Me.Controls.Add(Me.EventWorldHelp)
        Me.Controls.Add(Me.EventAnalysisBox)
        Me.Controls.Add(Me.SystemTypeGroup)
        Me.Controls.Add(Me.AnalysisWorldUsage)
        Me.Controls.Add(Me.EventWorldTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_EvaluationWorld"
        Me.Size = New System.Drawing.Size(780, 420)
        Me.EventAnalysisBox.ResumeLayout(False)
        Me.EventAnalysisBox.PerformLayout()
        Me.SystemTypeGroup.ResumeLayout(False)
        Me.SystemTypeGroup.PerformLayout()
        Me.IrrigationWaterUseBox.ResumeLayout(False)
        Me.DownstreamRunoffGroup.ResumeLayout(False)
        Me.DownstreamRunoffGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm

    Private mDictionary As Dictionary
    Private mMyStore As DataStore.ObjectNode

    Private WithEvents mWinSRFR As WinSRFR
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mBorderCriteria As BorderCriteria
    Private WithEvents mEventCriteria As EventCriteria
    Private WithEvents mErosion As Erosion

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Public Sub LinkToModel(ByVal _unit As Unit)

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
        mBorderCriteria = mUnit.BorderCriteriaRef
        mEventCriteria = mUnit.EventCriteriaRef

        mErosion = mUnit.ErosionRef

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        ' Link contained controls to their models & store
        RequiredDepthControl.LinkToModel(mMyStore, mInflowManagement.RequiredDepthProperty)
        UnitWaterCostControl.LinkToModel(mMyStore, mInflowManagement.UnitWaterCostProperty)

        BasinBorderButton.LinkToModel(mMyStore, mSystemGeometry.CrossSectionProperty, CrossSections.Border)
        FurrowButton.LinkToModel(mMyStore, mSystemGeometry.CrossSectionProperty, CrossSections.Furrow)

        OpenEndButton.LinkToModel(mMyStore, mSystemGeometry.DownstreamConditionProperty, DownstreamConditions.OpenEnd)
        BlockedEndButton.LinkToModel(mMyStore, mSystemGeometry.DownstreamConditionProperty, DownstreamConditions.BlockedEnd)

        InfiltratedProfileButton.LinkToModel(mMyStore, mEventCriteria.EventAnalysisTypeProperty, EventAnalysisTypes.InfiltratedProfileAnalysis)
        MerriamKellerButton.LinkToModel(mMyStore, mEventCriteria.EventAnalysisTypeProperty, EventAnalysisTypes.MerriamKellerAnalysis)
        ElliotWalkerButton.LinkToModel(mMyStore, mEventCriteria.EventAnalysisTypeProperty, EventAnalysisTypes.TwoPointAnalysis)
        EvalueButton.LinkToModel(mMyStore, mEventCriteria.EventAnalysisTypeProperty, EventAnalysisTypes.EvalueAnalysis)

        InflowHydrographCheck.LinkToModel(mMyStore, mInflowManagement.InflowMeasuredProperty)
        RunoffHydrographCheck.LinkToModel(mMyStore, mInflowManagement.RunoffMeasuredProperty)
        AdvanceTimesCheck.LinkToModel(mMyStore, mInflowManagement.AdvanceMeasuredProperty)
        RecessionTimesCheck.LinkToModel(mMyStore, mInflowManagement.RecessionMeasuredProperty)
        FlowDepthCheck.LinkToModel(mMyStore, mInflowManagement.FlowDepthsMeasuredProperty)

        UseRunoffCheck.LinkToModel(mMyStore, mInflowManagement.RunoffUsedProperty)
        UseRecessionCheck.LinkToModel(mMyStore, mInflowManagement.RecessionUsedProperty)
        UseFlowDepthsCheck.LinkToModel(mMyStore, mInflowManagement.FlowDepthsUsedProperty)

        ' Update language translation
        UpdateTranslation(Me)

        ' Update the control's User Interface
        UpdateUI()

    End Sub
    '
    ' WinSRFR changes
    '
    Public Sub SystemGeometry_PropertyChanged(ByVal reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        Me.UpdateUI()
    End Sub

    Public Sub SoilCropProperties_PropertyChanged(ByVal reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        Me.UpdateUI()
    End Sub

    Public Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        Me.UpdateUI()
    End Sub

    Public Sub EventCriteria_PropertyChanged(ByVal reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        Me.UpdateUI()
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateUI()
    End Sub

#End Region

#Region " Update UI Methods "

#Region " System Type "
    '
    ' Update the UI's Event Analysis Criteria
    '
    Private Sub UpdateEventAnalysisCriteria()
        If (mEventCriteria IsNot Nothing) Then
            '
            ' Display world usage instructions
            '
            Me.AnalysisWorldUsage.Text = mDictionary.tEventWorldUsage.Translated & "  "
            Me.AnalysisWorldUsage.Text &= mDictionary.tProceedDownTabs.Translated

            ' Update the Event Analysis UI
            Select Case (mEventCriteria.EventAnalysisType.Value)

                Case EventAnalysisTypes.InfiltratedProfileAnalysis
                    Me.InfiltratedProfileButton.Checked = True

                    InflowMeasured(EventCriteria.Prerequisites.Required)
                    RunoffMeasured(EventCriteria.Prerequisites.Useful)
                    AdvanceMeasured(EventCriteria.Prerequisites.NotUsed)
                    RecessionMeasured(EventCriteria.Prerequisites.NotUsed)
                    FlowDepthsMeasured(EventCriteria.Prerequisites.NotUsed)

                    Me.UseForVbLabel.Visible = False
                    Me.UseRunoffCheck.Visible = False
                    Me.UseRecessionCheck.Visible = False
                    Me.UseFlowDepthsCheck.Visible = False

                Case EventAnalysisTypes.TwoPointAnalysis
                    Me.ElliotWalkerButton.Checked = True

                    InflowMeasured(EventCriteria.Prerequisites.Required)
                    RunoffMeasured(EventCriteria.Prerequisites.Useful)
                    AdvanceMeasured(EventCriteria.Prerequisites.RequiredVB)
                    RecessionMeasured(EventCriteria.Prerequisites.NotUsed)
                    FlowDepthsMeasured(EventCriteria.Prerequisites.NotUsed)

                    Me.UseForVbLabel.Visible = False
                    Me.UseRunoffCheck.Visible = False
                    Me.UseRecessionCheck.Visible = False
                    Me.UseFlowDepthsCheck.Visible = False

                Case EventAnalysisTypes.MerriamKellerAnalysis
                    Me.MerriamKellerButton.Checked = True

                    InflowMeasured(EventCriteria.Prerequisites.Required)

                    If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
                        RunoffMeasured(EventCriteria.Prerequisites.Required)
                    Else ' BlockedEnd
                        RunoffMeasured(EventCriteria.Prerequisites.NotUsed)
                    End If

                    AdvanceMeasured(EventCriteria.Prerequisites.RequiredVB)
                    RecessionMeasured(EventCriteria.Prerequisites.RequiredVB)
                    FlowDepthsMeasured(EventCriteria.Prerequisites.NotUsed)

                    Me.UseForVbLabel.Visible = False
                    Me.UseRunoffCheck.Visible = False
                    Me.UseRecessionCheck.Visible = False
                    Me.UseFlowDepthsCheck.Visible = False

                Case EventAnalysisTypes.EvalueAnalysis
                    Me.EvalueButton.Checked = True

                    InflowMeasured(EventCriteria.Prerequisites.Required)

                    If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
                        RunoffMeasured(EventCriteria.Prerequisites.UsefulVB)
                    Else ' BlockedEnd
                        RunoffMeasured(EventCriteria.Prerequisites.NotUsed)
                    End If

                    AdvanceMeasured(EventCriteria.Prerequisites.RequiredVB)
                    RecessionMeasured(EventCriteria.Prerequisites.UsefulVB)
                    FlowDepthsMeasured(EventCriteria.Prerequisites.UsefulVB)

                    Me.UseForVbLabel.Visible = True

                Case EventAnalysisTypes.ErosionAnalysis
                    'Me.ErosionButton.Checked = True

                    InflowMeasured(EventCriteria.Prerequisites.Required)
                    RunoffMeasured(EventCriteria.Prerequisites.NotUsed)
                    AdvanceMeasured(EventCriteria.Prerequisites.NotUsed)
                    RecessionMeasured(EventCriteria.Prerequisites.NotUsed)
                    FlowDepthsMeasured(EventCriteria.Prerequisites.NotUsed)

                    Me.UseForVbLabel.Visible = False
                    Me.UseRunoffCheck.Visible = False
                    Me.UseRecessionCheck.Visible = False
                    Me.UseFlowDepthsCheck.Visible = False

                Case Else
                    Debug.Assert(False, "Support for this Event Analysis Type must be added")
            End Select

            ' Update the Event World Help text
            UpdateEventWorldHelp()

        End If
    End Sub

    Private Sub InflowMeasured(ByVal Prerequisite As EventCriteria.Prerequisites)

        mEventCriteria.InflowPrereq = Prerequisite

        Dim measured As Boolean = mInflowManagement.InflowMeasured.Value

        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.Required, EventCriteria.Prerequisites.RequiredVB

                Me.InflowHydrographCheck.Enabled = True
                Me.InflowHydrographCheck.Visible = True
                Me.InflowHydrographCheck.AlwaysChecked = True ' set uncheck message also
                Me.InflowHydrographCheck.UncheckAttemptMessage = mDictionary.tInflowRequired.Translated
                If (Not measured) Then
                    Me.InflowHydrographCheck.ErrorMessage = mDictionary.tInflowRequired.Translated
                Else
                    Me.InflowHydrographCheck.ErrorMessage = ""
                End If

            Case EventCriteria.Prerequisites.Useful, EventCriteria.Prerequisites.UsefulVB

                Me.InflowHydrographCheck.Enabled = True
                Me.InflowHydrographCheck.Visible = True
                Me.InflowHydrographCheck.AlwaysChecked = False
                Me.InflowHydrographCheck.ErrorMessage = ""

            Case EventCriteria.Prerequisites.NotUsed

                Me.InflowHydrographCheck.Enabled = False
                Me.InflowHydrographCheck.Visible = False
                Me.InflowHydrographCheck.AlwaysChecked = False
                Me.InflowHydrographCheck.ErrorMessage = ""

            Case Else
                Debug.Assert(False)
        End Select

    End Sub

    Private Sub RunoffMeasured(ByVal Prerequisite As EventCriteria.Prerequisites)

        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
            Prerequisite = EventCriteria.Prerequisites.NotUsed
        End If

        mEventCriteria.RunoffPrereq = Prerequisite

        Dim measured As Boolean = mInflowManagement.RunoffMeasured.Value
        Dim used As Boolean = True ' Used control is only for EVALUE
        If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.EvalueAnalysis) Then
            used = mInflowManagement.RunoffUsed.Value
        End If

        ' Control the display / use of the Measured checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.Required, EventCriteria.Prerequisites.RequiredVB

                Me.RunoffHydrographCheck.Enabled = True
                Me.RunoffHydrographCheck.Visible = True
                Me.RunoffHydrographCheck.AlwaysChecked = True ' set uncheck message also
                Me.RunoffHydrographCheck.UncheckAttemptMessage = mDictionary.tRunoffRequired.Translated

                If ((Not measured) Or (Not used)) Then
                    Me.RunoffHydrographCheck.ErrorMessage = mDictionary.tRunoffRequired.Translated
                Else
                    Me.RunoffHydrographCheck.ErrorMessage = ""
                End If

            Case EventCriteria.Prerequisites.Useful, EventCriteria.Prerequisites.UsefulVB

                Me.RunoffHydrographCheck.Enabled = True
                Me.RunoffHydrographCheck.Visible = True
                Me.RunoffHydrographCheck.AlwaysChecked = False
                Me.RunoffHydrographCheck.ErrorMessage = ""

            Case Else ' EventCriteria.Prerequisites.NotUsed

                Me.RunoffHydrographCheck.Enabled = False
                Me.RunoffHydrographCheck.Visible = False
                Me.RunoffHydrographCheck.AlwaysChecked = False
                Me.RunoffHydrographCheck.ErrorMessage = ""

        End Select

        ' Control the display / use of the Used checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.RequiredVB

                Me.UseRunoffCheck.Enabled = True
                Me.UseRunoffCheck.Visible = True
                Me.UseRunoffCheck.AlwaysChecked = True ' set uncheck message also
                Me.UseRunoffCheck.UncheckAttemptMessage = Me.RunoffHydrographCheck.UncheckAttemptMessage

            Case EventCriteria.Prerequisites.UsefulVB

                Me.UseRunoffCheck.Enabled = Me.RunoffHydrographCheck.Enabled And Me.RunoffHydrographCheck.Checked
                Me.UseRunoffCheck.Visible = Me.RunoffHydrographCheck.Enabled And Me.RunoffHydrographCheck.Checked
                Me.UseRunoffCheck.AlwaysChecked = False

            Case Else

                Me.UseRunoffCheck.Enabled = False
                Me.UseRunoffCheck.Visible = False
                Me.UseRunoffCheck.AlwaysChecked = False

        End Select

    End Sub

    Private Sub AdvanceMeasured(ByVal Prerequisite As EventCriteria.Prerequisites)

        mEventCriteria.AdvancePrereq = Prerequisite

        Dim measured As Boolean = mInflowManagement.AdvanceMeasured.Value

        ' Control the display / use of the Measured checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.Required, EventCriteria.Prerequisites.RequiredVB

                Me.AdvanceTimesCheck.Enabled = True
                Me.AdvanceTimesCheck.Visible = True
                Me.AdvanceTimesCheck.AlwaysChecked = True ' set uncheck message also
                Me.AdvanceTimesCheck.UncheckAttemptMessage = mDictionary.tAdvanceRequired.Translated

                If (Not measured) Then
                    Me.AdvanceTimesCheck.ErrorMessage = mDictionary.tAdvanceRequired.Translated
                Else
                    Me.AdvanceTimesCheck.ErrorMessage = ""
                End If

            Case EventCriteria.Prerequisites.Useful, EventCriteria.Prerequisites.UsefulVB

                Me.AdvanceTimesCheck.Enabled = True
                Me.AdvanceTimesCheck.Visible = True
                Me.AdvanceTimesCheck.AlwaysChecked = False
                Me.AdvanceTimesCheck.ErrorMessage = ""

            Case Else ' EventCriteria.Prerequisites.NotUsed

                Me.AdvanceTimesCheck.Enabled = False
                Me.AdvanceTimesCheck.Visible = False
                Me.AdvanceTimesCheck.AlwaysChecked = False
                Me.AdvanceTimesCheck.ErrorMessage = ""

        End Select

    End Sub

    Private Sub RecessionMeasured(ByVal Prerequisite As EventCriteria.Prerequisites)

        mEventCriteria.RecessionPrereq = Prerequisite

        Dim measured As Boolean = mInflowManagement.RecessionMeasured.Value
        Dim used As Boolean = True ' Used control is only for EVALUE
        If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.EvalueAnalysis) Then
            used = mInflowManagement.RecessionUsed.Value
        End If

        ' Control the display / use of the Measured checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.Required, EventCriteria.Prerequisites.RequiredVB

                Me.RecessionTimesCheck.Enabled = True
                Me.RecessionTimesCheck.Visible = True
                Me.RecessionTimesCheck.AlwaysChecked = True ' set uncheck message also
                Me.RecessionTimesCheck.UncheckAttemptMessage = mDictionary.tRecessionRequired.Translated

                If ((Not measured) Or (Not used)) Then
                    Me.RecessionTimesCheck.ErrorMessage = mDictionary.tRecessionRequired.Translated
                Else
                    Me.RecessionTimesCheck.ErrorMessage = ""
                End If

            Case EventCriteria.Prerequisites.Useful, EventCriteria.Prerequisites.UsefulVB

                Me.RecessionTimesCheck.Enabled = True
                Me.RecessionTimesCheck.Visible = True
                Me.RecessionTimesCheck.AlwaysChecked = False
                Me.RecessionTimesCheck.ErrorMessage = ""

            Case Else ' EventCriteria.Prerequisites.NotUsed

                Me.RecessionTimesCheck.Enabled = False
                Me.RecessionTimesCheck.Visible = False
                Me.RecessionTimesCheck.AlwaysChecked = False
                Me.RecessionTimesCheck.ErrorMessage = ""

        End Select

        ' Control the display / use of the Used checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.RequiredVB

                Me.UseRecessionCheck.Enabled = True
                Me.UseRecessionCheck.Visible = True
                Me.UseRecessionCheck.AlwaysChecked = True ' set uncheck message also
                Me.UseRecessionCheck.UncheckAttemptMessage = Me.RecessionTimesCheck.UncheckAttemptMessage

            Case EventCriteria.Prerequisites.UsefulVB

                Me.UseRecessionCheck.Enabled = Me.RecessionTimesCheck.Enabled And Me.RecessionTimesCheck.Checked
                Me.UseRecessionCheck.Visible = Me.RecessionTimesCheck.Enabled And Me.RecessionTimesCheck.Checked
                Me.UseRecessionCheck.AlwaysChecked = False

            Case Else

                Me.UseRecessionCheck.Enabled = False
                Me.UseRecessionCheck.Visible = False
                Me.UseRecessionCheck.AlwaysChecked = False

        End Select

    End Sub

    Private Sub FlowDepthsMeasured(ByVal Prerequisite As EventCriteria.Prerequisites)

        mEventCriteria.FlowDepthsPrereq = Prerequisite

        Dim measured As Boolean = mInflowManagement.FlowDepthsMeasured.Value
        Dim used As Boolean = True ' Used control is only for EVALUE
        If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.EvalueAnalysis) Then
            used = mInflowManagement.FlowDepthsUsed.Value
        End If

        ' Control the display / use of the Measured checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.Required, EventCriteria.Prerequisites.RequiredVB

                Me.FlowDepthCheck.Enabled = True
                Me.FlowDepthCheck.Visible = True
                Me.FlowDepthCheck.AlwaysChecked = True ' set uncheck message also
                Me.FlowDepthCheck.UncheckAttemptMessage = mDictionary.tFlowDepthsRequired.Translated

                If ((Not measured) Or (Not used)) Then
                    Me.FlowDepthCheck.ErrorMessage = mDictionary.tFlowDepthsRequired.Translated
                Else
                    Me.FlowDepthCheck.ErrorMessage = ""
                End If

            Case EventCriteria.Prerequisites.Useful, EventCriteria.Prerequisites.UsefulVB

                Me.FlowDepthCheck.Enabled = True
                Me.FlowDepthCheck.Visible = True
                Me.FlowDepthCheck.AlwaysChecked = False
                Me.FlowDepthCheck.ErrorMessage = ""

            Case Else ' EventCriteria.Prerequisites.NotUsed

                Me.FlowDepthCheck.Enabled = True
                Me.FlowDepthCheck.Visible = False
                Me.FlowDepthCheck.AlwaysChecked = False
                Me.FlowDepthCheck.ErrorMessage = ""

        End Select

        ' Control the display / use of the Used checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.RequiredVB

                Me.UseFlowDepthsCheck.Enabled = True
                Me.UseFlowDepthsCheck.Visible = True
                Me.UseFlowDepthsCheck.AlwaysChecked = True ' set uncheck message also
                Me.UseFlowDepthsCheck.UncheckAttemptMessage = Me.FlowDepthCheck.UncheckAttemptMessage

            Case EventCriteria.Prerequisites.UsefulVB

                Me.UseFlowDepthsCheck.Enabled = Me.FlowDepthCheck.Enabled And Me.FlowDepthCheck.Checked
                Me.UseFlowDepthsCheck.Visible = Me.FlowDepthCheck.Enabled And Me.FlowDepthCheck.Checked
                Me.UseFlowDepthsCheck.AlwaysChecked = False

            Case Else

                Me.UseFlowDepthsCheck.Enabled = False
                Me.UseFlowDepthsCheck.Visible = False
                Me.UseFlowDepthsCheck.AlwaysChecked = False

        End Select

    End Sub

#End Region

#Region " Event Analysis "
    '
    ' Update the Event Analysis World's UI
    '
    Public Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mUnit IsNot Nothing) Then
            '
            ' Set controls to their correct color
            '
            If (SystemInformation.HighContrast) Then
                EventWorldHelp.BackColor = System.Drawing.SystemColors.Window
                EventWorldHelp.ForeColor = System.Drawing.SystemColors.WindowText
            Else
                EventWorldHelp.BackColor = mWinSRFR.EventBackColor
                EventWorldHelp.ForeColor = mWinSRFR.EventForeColor
            End If

            ' Limit Erosion Analysis to Advanced User Level only
            'If (mWinSRFR.UserLevel = UserLevels.Standard) Then
            '    Me.ErosionButton.Text = mDictionary.tErosionParameterEstimation.Translated & " (" & mDictionary.tAdvancedUserLevelOnly.Translated & ")"
            '    Me.ErosionButton.Enabled = False
            '    Me.ErosionButton.TabStop = False
            'Else ' Advanced or Research
            '    Me.ErosionButton.Text = mDictionary.tErosionParameterEstimation.Translated
            '    Me.ErosionButton.Enabled = True
            '    Me.ErosionButton.TabStop = True
            'End If

            '' JLS - Temporarily disable Erosion
            'If Not (WinSRFR.IsResearchLevel) Then
            '    Me.ErosionButton.Visible = False
            '    Me.ErosionButton.TabStop = False
            '    If (Me.ErosionButton.Checked) Then
            '        Me.ElliotWalkerButton.Checked = True
            '    End If
            'End If

            ' Update the Event Analysis Criteria
            UpdateEventAnalysisCriteria()
        End If

    End Sub

#End Region

#Region " Event World Help "

    Private Sub UpdateEventWorldHelp()

        EventWorldHelp.Clear()
        EventWorldHelp.SelectionAlignment = HorizontalAlignment.Center

        Select Case (mEventCriteria.EventAnalysisType.Value)

            Case EventAnalysisTypes.InfiltratedProfileAnalysis
                AppendBoldUnderlineLine(EventWorldHelp, mDictionary.tInfiltratedProfileAnalysis.Translated)
                AdvanceLine(EventWorldHelp)

                EventWorldHelp.SelectionAlignment = HorizontalAlignment.Left

                AppendLine(EventWorldHelp, mDictionary.tEvalInfiltratedProfile.Translated)

            Case EventAnalysisTypes.MerriamKellerAnalysis
                AppendBoldUnderlineLine(EventWorldHelp, "Merriam-Keller " & mDictionary.tAnalysis.Translated)
                AdvanceLine(EventWorldHelp)

                EventWorldHelp.SelectionAlignment = HorizontalAlignment.Left

                AppendLine(EventWorldHelp, mDictionary.tEvalMerriamKellerDescr.Translated)
                AdvanceLine(EventWorldHelp)
                AppendLine(EventWorldHelp, mDictionary.tEvalMerriamKellerNotes.Translated)

            Case EventAnalysisTypes.TwoPointAnalysis
                AppendBoldUnderlineLine(EventWorldHelp, "Elliott-Walker 2-Point Method")
                AdvanceLine(EventWorldHelp)

                EventWorldHelp.SelectionAlignment = HorizontalAlignment.Left

                AppendLine(EventWorldHelp, mDictionary.tEvalTwoPointDescr.Translated)
                AdvanceLine(EventWorldHelp)
                AppendLine(EventWorldHelp, mDictionary.tEvalTwoPointNotes.Translated)

            Case EventAnalysisTypes.ErosionAnalysis
                AppendBoldUnderlineLine(EventWorldHelp, mDictionary.tErosionParameterEstimation.Translated)
                AdvanceLine(EventWorldHelp)

                EventWorldHelp.SelectionAlignment = HorizontalAlignment.Left

                AppendLine(EventWorldHelp, mDictionary.tEvalErosionParams.Translated)

            Case EventAnalysisTypes.EvalueAnalysis
                AppendBoldUnderlineLine(EventWorldHelp, "EVALUE " & mDictionary.tAnalysis.Translated)
                AdvanceLine(EventWorldHelp)

                EventWorldHelp.SelectionAlignment = HorizontalAlignment.Left

                AppendLine(EventWorldHelp, mDictionary.tEvalEvalueDescr.Translated)

            Case Else
                Debug.Assert(False) ' Support for Event Analysis must be added

        End Select
        '
        ' Add error / warning messages
        '
        If (mEventCriteria.InflowPrereq = EventCriteria.Prerequisites.RequiredVB) Then
            If Not (mInflowManagement.InflowMeasured.Value) Then
                AdvanceLine(EventWorldHelp)
                AppendBoldText(EventWorldHelp, mDictionary.tError.Translated)
                AppendLine(EventWorldHelp, " - " & mDictionary.tAnalysisWoInflow.Translated)
            End If
        End If

        If (mEventCriteria.RunoffPrereq = EventCriteria.Prerequisites.RequiredVB) Then
            If Not (mInflowManagement.RunoffMeasured.Value) Then
                AdvanceLine(EventWorldHelp)
                AppendBoldText(EventWorldHelp, mDictionary.tError.Translated)
                AppendLine(EventWorldHelp, " - " & mDictionary.tRunoffRequired.Translated)
            End If
        ElseIf (mEventCriteria.RunoffPrereq = EventCriteria.Prerequisites.UsefulVB) Then
            If Not (mInflowManagement.RunoffMeasured.Value) Then
                AdvanceLine(EventWorldHelp)
                AppendBoldText(EventWorldHelp, mDictionary.tWarning.Translated)
                AppendLine(EventWorldHelp, " - " & mDictionary.tVolumeBalanceWoRunoff.Translated)
            End If
        End If

        If (mEventCriteria.AdvancePrereq = EventCriteria.Prerequisites.RequiredVB) Then
            If Not (mInflowManagement.AdvanceMeasured.Value) Then
                AdvanceLine(EventWorldHelp)
                AppendBoldText(EventWorldHelp, mDictionary.tError.Translated)
                AppendLine(EventWorldHelp, " - " & mDictionary.tAdvanceRequired.Translated)
            End If
        ElseIf (mEventCriteria.AdvancePrereq = EventCriteria.Prerequisites.UsefulVB) Then
            If Not (mInflowManagement.AdvanceMeasured.Value) Then
                AdvanceLine(EventWorldHelp)
                AppendBoldText(EventWorldHelp, mDictionary.tWarning.Translated)
                AppendLine(EventWorldHelp, " - " & mDictionary.tAdvanceRequired.Translated)
            End If
        End If

        If (mEventCriteria.RecessionPrereq = EventCriteria.Prerequisites.RequiredVB) Then
            If Not (mInflowManagement.RecessionMeasured.Value) Then
                AdvanceLine(EventWorldHelp)
                AppendBoldText(EventWorldHelp, mDictionary.tError.Translated)
                AppendLine(EventWorldHelp, " - " & mDictionary.tRecessionRequired.Translated)
            End If
        ElseIf (mEventCriteria.RecessionPrereq = EventCriteria.Prerequisites.UsefulVB) Then
            If Not (mInflowManagement.RecessionMeasured.Value) Then
                AdvanceLine(EventWorldHelp)
                AppendBoldText(EventWorldHelp, mDictionary.tWarning.Translated)
                AppendLine(EventWorldHelp, " - " & mDictionary.tRecessionUseful.Translated)
            End If
        End If

        If (mEventCriteria.FlowDepthsPrereq = EventCriteria.Prerequisites.RequiredVB) Then
            If Not (mInflowManagement.FlowDepthsMeasured.Value) Then
                AdvanceLine(EventWorldHelp)
                AppendBoldText(EventWorldHelp, mDictionary.tError.Translated)
                AppendLine(EventWorldHelp, " - " & mDictionary.tFlowDepthsRequired.Translated)
            End If
        ElseIf (mEventCriteria.FlowDepthsPrereq = EventCriteria.Prerequisites.UsefulVB) Then
            If Not (mInflowManagement.FlowDepthsMeasured.Value) Then
                AdvanceLine(EventWorldHelp)
                AppendBoldText(EventWorldHelp, mDictionary.tWarning.Translated)
                AppendLine(EventWorldHelp, " - " & mDictionary.tFlowDepthsUseful.Translated)
            End If
        End If

    End Sub

#End Region

#End Region

#Region " UI Event Handlers "

    Private Sub ctl_EvaluationWorld_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        Me.EventWorldTitle.Width = Me.Width - Me.EventWorldTitle.Location.X
        Me.AnalysisWorldUsage.Width = Me.Width - Me.AnalysisWorldUsage.Location.X

        Me.IrrigationWaterUseBox.Width = Me.Width - Me.IrrigationWaterUseBox.Location.X - 4

        Me.EventAnalysisBox.Height = Me.Height - Me.EventAnalysisBox.Location.Y - 4

        Me.EventWorldHelp.Height = Me.Height - Me.EventWorldHelp.Location.Y - 4
        Me.EventWorldHelp.Width = Me.Width - Me.EventWorldHelp.Location.X - 4

    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

End Class
