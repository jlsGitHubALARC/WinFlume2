<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_EvalueRoughnessFlowDepths
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
        Me.components = New System.ComponentModel.Container()
        Me.RoughnessBox = New DataStore.ctl_GroupBox()
        Me.RoughnessMethodLabel = New DataStore.ctl_Label()
        Me.RoughnessMethodControl = New DataStore.ctl_SelectParameter()
        Me.NrcsManningNPanel = New DataStore.ctl_Panel()
        Me.UsersManningNControl = New DataStore.ctl_DoubleParameter()
        Me.Sel_UserEntered = New DataStore.ctl_RadioButton()
        Me.Sel_025 = New DataStore.ctl_RadioButton()
        Me.Sel_020 = New DataStore.ctl_RadioButton()
        Me.Sel_015 = New DataStore.ctl_RadioButton()
        Me.Sel_010 = New DataStore.ctl_RadioButton()
        Me.Sel_004 = New DataStore.ctl_RadioButton()
        Me.SayreChiPanel = New DataStore.ctl_Panel()
        Me.SayreChiControl = New DataStore.ctl_DoubleParameter()
        Me.SayreChiLabel = New DataStore.ctl_Label()
        Me.ManningCnAnPanel = New DataStore.ctl_Panel()
        Me.ManningAnControl = New DataStore.ctl_DoubleParameter()
        Me.ManningAnLabel = New DataStore.ctl_Label()
        Me.ManningCnControl = New DataStore.ctl_DoubleParameter()
        Me.ManningCnLabel = New DataStore.ctl_Label()
        Me.CalibrateHydrographs = New DataStore.ctl_Button()
        Me.EvalueRoughnessInstructions = New System.Windows.Forms.RichTextBox()
        Me.GoodnessOfFitGraph = New WinMain.grf_XYGraph()
        Me.FlowDepthHydrographs = New WinMain.grf_XYGraph()
        Me.RoughnessBox.SuspendLayout()
        Me.NrcsManningNPanel.SuspendLayout()
        Me.SayreChiPanel.SuspendLayout()
        Me.ManningCnAnPanel.SuspendLayout()
        CType(Me.GoodnessOfFitGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlowDepthHydrographs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoughnessBox
        '
        Me.RoughnessBox.AccessibleDescription = "Set of parameters that specify surface roughness parameters."
        Me.RoughnessBox.AccessibleName = "Roughness"
        Me.RoughnessBox.Controls.Add(Me.RoughnessMethodLabel)
        Me.RoughnessBox.Controls.Add(Me.RoughnessMethodControl)
        Me.RoughnessBox.Controls.Add(Me.NrcsManningNPanel)
        Me.RoughnessBox.Controls.Add(Me.SayreChiPanel)
        Me.RoughnessBox.Controls.Add(Me.ManningCnAnPanel)
        Me.RoughnessBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessBox.Location = New System.Drawing.Point(0, 0)
        Me.RoughnessBox.Name = "RoughnessBox"
        Me.RoughnessBox.Size = New System.Drawing.Size(365, 180)
        Me.RoughnessBox.TabIndex = 1
        Me.RoughnessBox.TabStop = False
        Me.RoughnessBox.Text = "Roughness"
        '
        'RoughnessMethodLabel
        '
        Me.RoughnessMethodLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessMethodLabel.Location = New System.Drawing.Point(54, 17)
        Me.RoughnessMethodLabel.Name = "RoughnessMethodLabel"
        Me.RoughnessMethodLabel.Size = New System.Drawing.Size(139, 23)
        Me.RoughnessMethodLabel.TabIndex = 1
        Me.RoughnessMethodLabel.Text = "Resistance E&quation"
        Me.RoughnessMethodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RoughnessMethodControl
        '
        Me.RoughnessMethodControl.AccessibleDescription = "Selects method for entering surface roughness parameters."
        Me.RoughnessMethodControl.AccessibleName = "Roughness Method"
        Me.RoughnessMethodControl.ApplicationValue = -1
        Me.RoughnessMethodControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RoughnessMethodControl.EnableSaveActions = False
        Me.RoughnessMethodControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessMethodControl.IsCalculated = False
        Me.RoughnessMethodControl.Location = New System.Drawing.Point(195, 16)
        Me.RoughnessMethodControl.Name = "RoughnessMethodControl"
        Me.RoughnessMethodControl.SelectedIndexSet = False
        Me.RoughnessMethodControl.Size = New System.Drawing.Size(160, 24)
        Me.RoughnessMethodControl.TabIndex = 2
        '
        'NrcsManningNPanel
        '
        Me.NrcsManningNPanel.AccessibleDescription = "Set of radio buttons that select Manning N from NRCS suggested values."
        Me.NrcsManningNPanel.AccessibleName = "Manning N"
        Me.NrcsManningNPanel.Controls.Add(Me.UsersManningNControl)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_UserEntered)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_025)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_020)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_015)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_010)
        Me.NrcsManningNPanel.Controls.Add(Me.Sel_004)
        Me.NrcsManningNPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsManningNPanel.Location = New System.Drawing.Point(8, 45)
        Me.NrcsManningNPanel.Name = "NrcsManningNPanel"
        Me.NrcsManningNPanel.Size = New System.Drawing.Size(347, 130)
        Me.NrcsManningNPanel.TabIndex = 5
        '
        'UsersManningNControl
        '
        Me.UsersManningNControl.AccessibleDescription = "Specifies surface roughness using Manning n value."
        Me.UsersManningNControl.AccessibleName = "Manning n"
        Me.UsersManningNControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.UsersManningNControl.IsCalculated = False
        Me.UsersManningNControl.IsInteger = False
        Me.UsersManningNControl.Location = New System.Drawing.Point(210, 99)
        Me.UsersManningNControl.MaxErrMsg = ""
        Me.UsersManningNControl.MinErrMsg = ""
        Me.UsersManningNControl.Name = "UsersManningNControl"
        Me.UsersManningNControl.Size = New System.Drawing.Size(108, 24)
        Me.UsersManningNControl.TabIndex = 7
        Me.UsersManningNControl.ToBeCalculated = True
        Me.UsersManningNControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.UsersManningNControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.UsersManningNControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.UsersManningNControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.UsersManningNControl.ValueText = ""
        '
        'Sel_UserEntered
        '
        Me.Sel_UserEntered.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sel_UserEntered.Location = New System.Drawing.Point(10, 100)
        Me.Sel_UserEntered.Name = "Sel_UserEntered"
        Me.Sel_UserEntered.Size = New System.Drawing.Size(188, 23)
        Me.Sel_UserEntered.TabIndex = 6
        Me.Sel_UserEntered.TabStop = True
        Me.Sel_UserEntered.Text = "&User Entered Value:"
        Me.Sel_UserEntered.UseVisualStyleBackColor = True
        '
        'Sel_025
        '
        Me.Sel_025.Location = New System.Drawing.Point(10, 76)
        Me.Sel_025.Name = "Sel_025"
        Me.Sel_025.Size = New System.Drawing.Size(330, 24)
        Me.Sel_025.TabIndex = 5
        Me.Sel_025.Text = "0.25 - Dense crops or small grain drilled crosswise"
        '
        'Sel_020
        '
        Me.Sel_020.Location = New System.Drawing.Point(10, 58)
        Me.Sel_020.Name = "Sel_020"
        Me.Sel_020.Size = New System.Drawing.Size(330, 24)
        Me.Sel_020.TabIndex = 4
        Me.Sel_020.Text = "0.20 - Alfalfa, dense or on long fields"
        '
        'Sel_015
        '
        Me.Sel_015.Location = New System.Drawing.Point(10, 40)
        Me.Sel_015.Name = "Sel_015"
        Me.Sel_015.Size = New System.Drawing.Size(330, 24)
        Me.Sel_015.TabIndex = 3
        Me.Sel_015.Text = "0.15 - Alfalfa, Mint or Broadcast Small Grain"
        '
        'Sel_010
        '
        Me.Sel_010.Location = New System.Drawing.Point(10, 22)
        Me.Sel_010.Name = "Sel_010"
        Me.Sel_010.Size = New System.Drawing.Size(330, 24)
        Me.Sel_010.TabIndex = 2
        Me.Sel_010.Text = "0.10 - Small Grain (drilled lengthwise)"
        '
        'Sel_004
        '
        Me.Sel_004.Location = New System.Drawing.Point(10, 4)
        Me.Sel_004.Name = "Sel_004"
        Me.Sel_004.Size = New System.Drawing.Size(330, 24)
        Me.Sel_004.TabIndex = 1
        Me.Sel_004.Text = "0.04 - Bare Soil"
        '
        'SayreChiPanel
        '
        Me.SayreChiPanel.AccessibleDescription = "Specifies surface roughness using a Sayre-Albertson Chi value."
        Me.SayreChiPanel.AccessibleName = "Sayre-Albertson Chi"
        Me.SayreChiPanel.Controls.Add(Me.SayreChiControl)
        Me.SayreChiPanel.Controls.Add(Me.SayreChiLabel)
        Me.SayreChiPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SayreChiPanel.Location = New System.Drawing.Point(8, 45)
        Me.SayreChiPanel.Name = "SayreChiPanel"
        Me.SayreChiPanel.Size = New System.Drawing.Size(347, 130)
        Me.SayreChiPanel.TabIndex = 6
        '
        'SayreChiControl
        '
        Me.SayreChiControl.AccessibleDescription = "Specifies surface roughness using a Sayre-Albertson Chi value."
        Me.SayreChiControl.AccessibleName = "Sayre-Albertson Chi"
        Me.SayreChiControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SayreChiControl.IsCalculated = False
        Me.SayreChiControl.IsInteger = False
        Me.SayreChiControl.Location = New System.Drawing.Point(147, 57)
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
        Me.SayreChiLabel.Location = New System.Drawing.Point(8, 57)
        Me.SayreChiLabel.Name = "SayreChiLabel"
        Me.SayreChiLabel.Size = New System.Drawing.Size(136, 23)
        Me.SayreChiLabel.TabIndex = 0
        Me.SayreChiLabel.Text = "&Sayre-Albertson Chi"
        Me.SayreChiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.ManningCnAnPanel.Location = New System.Drawing.Point(8, 45)
        Me.ManningCnAnPanel.Name = "ManningCnAnPanel"
        Me.ManningCnAnPanel.Size = New System.Drawing.Size(347, 130)
        Me.ManningCnAnPanel.TabIndex = 5
        '
        'ManningAnControl
        '
        Me.ManningAnControl.AccessibleDescription = "Specifies Manning An value."
        Me.ManningAnControl.AccessibleName = "Manning An"
        Me.ManningAnControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ManningAnControl.IsCalculated = False
        Me.ManningAnControl.IsInteger = False
        Me.ManningAnControl.Location = New System.Drawing.Point(147, 74)
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
        Me.ManningAnLabel.Location = New System.Drawing.Point(10, 74)
        Me.ManningAnLabel.Name = "ManningAnLabel"
        Me.ManningAnLabel.Size = New System.Drawing.Size(128, 23)
        Me.ManningAnLabel.TabIndex = 2
        Me.ManningAnLabel.Text = "Manning &An"
        Me.ManningAnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ManningCnControl
        '
        Me.ManningCnControl.AccessibleDescription = "Specifies Manning Cn value."
        Me.ManningCnControl.AccessibleName = "Manning Cn"
        Me.ManningCnControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ManningCnControl.IsCalculated = False
        Me.ManningCnControl.IsInteger = False
        Me.ManningCnControl.Location = New System.Drawing.Point(147, 41)
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
        Me.ManningCnLabel.Location = New System.Drawing.Point(10, 42)
        Me.ManningCnLabel.Name = "ManningCnLabel"
        Me.ManningCnLabel.Size = New System.Drawing.Size(128, 23)
        Me.ManningCnLabel.TabIndex = 0
        Me.ManningCnLabel.Text = "Manning &Cn"
        Me.ManningCnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CalibrateHydrographs
        '
        Me.CalibrateHydrographs.AccessibleDescription = "Calibrate flow depth hydrographs to simulation values."
        Me.CalibrateHydrographs.AccessibleName = "Calibrate"
        Me.CalibrateHydrographs.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.CalibrateHydrographs.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalibrateHydrographs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CalibrateHydrographs.Location = New System.Drawing.Point(10, 181)
        Me.CalibrateHydrographs.Name = "CalibrateHydrographs"
        Me.CalibrateHydrographs.Size = New System.Drawing.Size(337, 23)
        Me.CalibrateHydrographs.TabIndex = 6
        Me.CalibrateHydrographs.Text = "&Calibrate"
        Me.CalibrateHydrographs.UseVisualStyleBackColor = False
        '
        'EvalueRoughnessInstructions
        '
        Me.EvalueRoughnessInstructions.AccessibleDescription = "Instructions for adjusting surface flow roughness parameters."
        Me.EvalueRoughnessInstructions.AccessibleName = "EVALUE Roughness Instructions"
        Me.EvalueRoughnessInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.EvalueRoughnessInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EvalueRoughnessInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvalueRoughnessInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.EvalueRoughnessInstructions.Location = New System.Drawing.Point(370, 249)
        Me.EvalueRoughnessInstructions.Margin = New System.Windows.Forms.Padding(4)
        Me.EvalueRoughnessInstructions.Name = "EvalueRoughnessInstructions"
        Me.EvalueRoughnessInstructions.ReadOnly = True
        Me.EvalueRoughnessInstructions.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.EvalueRoughnessInstructions.Size = New System.Drawing.Size(366, 66)
        Me.EvalueRoughnessInstructions.TabIndex = 10
        Me.EvalueRoughnessInstructions.TabStop = False
        Me.EvalueRoughnessInstructions.Text = "EVALUE Roughness Instructions"
        '
        'GoodnessOfFitGraph
        '
        Me.GoodnessOfFitGraph.AccessibleDescription = "Graph depicting Goodness of Fit curve"
        Me.GoodnessOfFitGraph.AccessibleName = "Goodness of Fit graph"
        Me.GoodnessOfFitGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GoodnessOfFitGraph.BottomTitleAdjY = 0!
        Me.GoodnessOfFitGraph.CopyDataSet = Nothing
        Me.GoodnessOfFitGraph.CurveControlIsOn = False
        Me.GoodnessOfFitGraph.DisplayKey = False
        Me.GoodnessOfFitGraph.FontAdjustment = 0!
        Me.GoodnessOfFitGraph.FontName = "Microsoft Sans Serif"
        Me.GoodnessOfFitGraph.FontSize = 10.0!
        Me.GoodnessOfFitGraph.GraphSymbols = Nothing
        Me.GoodnessOfFitGraph.HorizontalKeys = False
        Me.GoodnessOfFitGraph.HorzLines = Nothing
        Me.GoodnessOfFitGraph.LastCurve = -1
        Me.GoodnessOfFitGraph.LeftTitleAdjX = 0!
        Me.GoodnessOfFitGraph.Location = New System.Drawing.Point(10, 207)
        Me.GoodnessOfFitGraph.MaxX = 0R
        Me.GoodnessOfFitGraph.MaxY = 0R
        Me.GoodnessOfFitGraph.MinX = 0R
        Me.GoodnessOfFitGraph.MinY = 0R
        Me.GoodnessOfFitGraph.Name = "GoodnessOfFitGraph"
        Me.GoodnessOfFitGraph.NewHotspotKeys = True
        Me.GoodnessOfFitGraph.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.GoodnessOfFitGraph.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.GoodnessOfFitGraph.RightTitleAdjX = 0!
        Me.GoodnessOfFitGraph.Size = New System.Drawing.Size(345, 115)
        Me.GoodnessOfFitGraph.TabIndex = 10
        Me.GoodnessOfFitGraph.TabStop = False
        Me.GoodnessOfFitGraph.Text = "Bitmap Diagram"
        Me.GoodnessOfFitGraph.TextLines = Nothing
        Me.GoodnessOfFitGraph.TitleAdjY = 0!
        Me.GoodnessOfFitGraph.TopTitleAdjY = 0!
        Me.GoodnessOfFitGraph.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.GoodnessOfFitGraph.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.GoodnessOfFitGraph.VertLabels = Nothing
        Me.GoodnessOfFitGraph.VertLines = Nothing
        Me.GoodnessOfFitGraph.VLabelPos = Nothing
        '
        'FlowDepthHydrographs
        '
        Me.FlowDepthHydrographs.AccessibleDescription = "Graphs comparing user entered and simulation flow depth hydrographs."
        Me.FlowDepthHydrographs.AccessibleName = "Flow Depth Hydrographs"
        Me.FlowDepthHydrographs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowDepthHydrographs.BottomTitleAdjY = 0!
        Me.FlowDepthHydrographs.CopyDataSet = Nothing
        Me.FlowDepthHydrographs.CurveControlIsOn = False
        Me.FlowDepthHydrographs.DisplayKey = False
        Me.FlowDepthHydrographs.FontAdjustment = 0!
        Me.FlowDepthHydrographs.FontName = "Microsoft Sans Serif"
        Me.FlowDepthHydrographs.FontSize = 10.0!
        Me.FlowDepthHydrographs.GraphSymbols = Nothing
        Me.FlowDepthHydrographs.HorizontalKeys = False
        Me.FlowDepthHydrographs.HorzLines = Nothing
        Me.FlowDepthHydrographs.LastCurve = -1
        Me.FlowDepthHydrographs.LeftTitleAdjX = 0!
        Me.FlowDepthHydrographs.Location = New System.Drawing.Point(370, 7)
        Me.FlowDepthHydrographs.MaxX = 0R
        Me.FlowDepthHydrographs.MaxY = 0R
        Me.FlowDepthHydrographs.MinX = 0R
        Me.FlowDepthHydrographs.MinY = 0R
        Me.FlowDepthHydrographs.Name = "FlowDepthHydrographs"
        Me.FlowDepthHydrographs.NewHotspotKeys = True
        Me.FlowDepthHydrographs.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.FlowDepthHydrographs.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.FlowDepthHydrographs.RightTitleAdjX = 0!
        Me.FlowDepthHydrographs.Size = New System.Drawing.Size(366, 235)
        Me.FlowDepthHydrographs.TabIndex = 5
        Me.FlowDepthHydrographs.TabStop = False
        Me.FlowDepthHydrographs.Text = "Bitmap Diagram"
        Me.FlowDepthHydrographs.TextLines = Nothing
        Me.FlowDepthHydrographs.TitleAdjY = 0!
        Me.FlowDepthHydrographs.TopTitleAdjY = 0!
        Me.FlowDepthHydrographs.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.FlowDepthHydrographs.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.FlowDepthHydrographs.VertLabels = Nothing
        Me.FlowDepthHydrographs.VertLines = Nothing
        Me.FlowDepthHydrographs.VLabelPos = Nothing
        '
        'ctl_EvalueRoughnessFlowDepths
        '
        Me.AccessibleDescription = "Estimate the field's roughness parameters using surface flow depths."
        Me.AccessibleName = "Roughness Flow Depths"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GoodnessOfFitGraph)
        Me.Controls.Add(Me.EvalueRoughnessInstructions)
        Me.Controls.Add(Me.FlowDepthHydrographs)
        Me.Controls.Add(Me.RoughnessBox)
        Me.Controls.Add(Me.CalibrateHydrographs)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_EvalueRoughnessFlowDepths"
        Me.Size = New System.Drawing.Size(750, 325)
        Me.RoughnessBox.ResumeLayout(False)
        Me.NrcsManningNPanel.ResumeLayout(False)
        Me.SayreChiPanel.ResumeLayout(False)
        Me.ManningCnAnPanel.ResumeLayout(False)
        CType(Me.GoodnessOfFitGraph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlowDepthHydrographs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RoughnessBox As DataStore.ctl_GroupBox
    Friend WithEvents RoughnessMethodLabel As DataStore.ctl_Label
    Friend WithEvents RoughnessMethodControl As DataStore.ctl_SelectParameter
    Friend WithEvents ManningCnAnPanel As DataStore.ctl_Panel
    Friend WithEvents ManningAnControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ManningAnLabel As DataStore.ctl_Label
    Friend WithEvents ManningCnControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ManningCnLabel As DataStore.ctl_Label
    Friend WithEvents NrcsManningNPanel As DataStore.ctl_Panel
    Friend WithEvents UsersManningNControl As DataStore.ctl_DoubleParameter
    Friend WithEvents Sel_UserEntered As DataStore.ctl_RadioButton
    Friend WithEvents Sel_025 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_020 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_015 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_010 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_004 As DataStore.ctl_RadioButton
    Friend WithEvents FlowDepthHydrographs As WinMain.grf_XYGraph
    Friend WithEvents CalibrateHydrographs As DataStore.ctl_Button
    Friend WithEvents EvalueRoughnessInstructions As System.Windows.Forms.RichTextBox
    Friend WithEvents GoodnessOfFitGraph As WinMain.grf_XYGraph
    Friend WithEvents SayreChiPanel As DataStore.ctl_Panel
    Friend WithEvents SayreChiControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SayreChiLabel As DataStore.ctl_Label
End Class
