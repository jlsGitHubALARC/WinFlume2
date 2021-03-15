<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_EvalueRoughnessFlowVolumes
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
        Me.components = New System.ComponentModel.Container
        Me.RoughnessBox = New DataStore.ctl_GroupBox
        Me.RoughnessMethodLabel = New DataStore.ctl_Label
        Me.RoughnessMethodControl = New DataStore.ctl_SelectParameter
        Me.NrcsManningNPanel = New DataStore.ctl_Panel
        Me.UsersManningNControl = New DataStore.ctl_DoubleParameter
        Me.Sel_UserEntered = New DataStore.ctl_RadioButton
        Me.Sel_025 = New DataStore.ctl_RadioButton
        Me.Sel_020 = New DataStore.ctl_RadioButton
        Me.Sel_015 = New DataStore.ctl_RadioButton
        Me.Sel_010 = New DataStore.ctl_RadioButton
        Me.Sel_004 = New DataStore.ctl_RadioButton
        Me.SayreChiPanel = New DataStore.ctl_Panel
        Me.SayreChiControl = New DataStore.ctl_DoubleParameter
        Me.SayreChiLabel = New DataStore.ctl_Label
        Me.ManningCnAnPanel = New DataStore.ctl_Panel
        Me.ManningAnControl = New DataStore.ctl_DoubleParameter
        Me.ManningAnLabel = New DataStore.ctl_Label
        Me.ManningCnControl = New DataStore.ctl_DoubleParameter
        Me.ManningCnLabel = New DataStore.ctl_Label
        Me.SurfaceVolumeSummaryTable = New DataStore.ctl_DataTableParameter
        Me.SurfaceFlowVolumeGraph = New WinMain.grf_XYGraph
        Me.RoughnessBox.SuspendLayout()
        Me.NrcsManningNPanel.SuspendLayout()
        Me.SayreChiPanel.SuspendLayout()
        Me.ManningCnAnPanel.SuspendLayout()
        CType(Me.SurfaceVolumeSummaryTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SurfaceFlowVolumeGraph, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RoughnessBox.Location = New System.Drawing.Point(0, 1)
        Me.RoughnessBox.Name = "RoughnessBox"
        Me.RoughnessBox.Size = New System.Drawing.Size(365, 175)
        Me.RoughnessBox.TabIndex = 3
        Me.RoughnessBox.TabStop = False
        Me.RoughnessBox.Text = "Roughness"
        '
        'RoughnessMethodLabel
        '
        Me.RoughnessMethodLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessMethodLabel.Location = New System.Drawing.Point(3, 17)
        Me.RoughnessMethodLabel.Name = "RoughnessMethodLabel"
        Me.RoughnessMethodLabel.Size = New System.Drawing.Size(148, 23)
        Me.RoughnessMethodLabel.TabIndex = 1
        Me.RoughnessMethodLabel.Text = "&Roughness Method"
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
        Me.RoughnessMethodControl.Location = New System.Drawing.Point(155, 17)
        Me.RoughnessMethodControl.Name = "RoughnessMethodControl"
        Me.RoughnessMethodControl.SelectedIndexSet = False
        Me.RoughnessMethodControl.Size = New System.Drawing.Size(200, 24)
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
        Me.NrcsManningNPanel.Size = New System.Drawing.Size(345, 125)
        Me.NrcsManningNPanel.TabIndex = 5
        '
        'UsersManningNControl
        '
        Me.UsersManningNControl.AccessibleDescription = "Specifies surface roughness using Manning n value."
        Me.UsersManningNControl.AccessibleName = "Manning n"
        Me.UsersManningNControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.UsersManningNControl.IsCalculated = False
        Me.UsersManningNControl.IsInteger = False
        Me.UsersManningNControl.Location = New System.Drawing.Point(210, 97)
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
        Me.Sel_UserEntered.Location = New System.Drawing.Point(10, 98)
        Me.Sel_UserEntered.Name = "Sel_UserEntered"
        Me.Sel_UserEntered.Size = New System.Drawing.Size(188, 23)
        Me.Sel_UserEntered.TabIndex = 6
        Me.Sel_UserEntered.TabStop = True
        Me.Sel_UserEntered.Text = "&User Entered Value:"
        Me.Sel_UserEntered.UseVisualStyleBackColor = True
        '
        'Sel_025
        '
        Me.Sel_025.Location = New System.Drawing.Point(10, 74)
        Me.Sel_025.Name = "Sel_025"
        Me.Sel_025.Size = New System.Drawing.Size(330, 24)
        Me.Sel_025.TabIndex = 5
        Me.Sel_025.Text = "0.25 - Dense crops or small grain drilled crosswise"
        '
        'Sel_020
        '
        Me.Sel_020.Location = New System.Drawing.Point(10, 56)
        Me.Sel_020.Name = "Sel_020"
        Me.Sel_020.Size = New System.Drawing.Size(330, 24)
        Me.Sel_020.TabIndex = 4
        Me.Sel_020.Text = "0.20 - Alfalfa, dense or on long fields"
        '
        'Sel_015
        '
        Me.Sel_015.Location = New System.Drawing.Point(10, 38)
        Me.Sel_015.Name = "Sel_015"
        Me.Sel_015.Size = New System.Drawing.Size(330, 24)
        Me.Sel_015.TabIndex = 3
        Me.Sel_015.Text = "0.15 - Alfalfa, Mint or Broadcast Small Grain"
        '
        'Sel_010
        '
        Me.Sel_010.Location = New System.Drawing.Point(10, 20)
        Me.Sel_010.Name = "Sel_010"
        Me.Sel_010.Size = New System.Drawing.Size(330, 24)
        Me.Sel_010.TabIndex = 2
        Me.Sel_010.Text = "0.10 - Small Grain (drilled lengthwise)"
        '
        'Sel_004
        '
        Me.Sel_004.Location = New System.Drawing.Point(10, 2)
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
        Me.SayreChiPanel.Size = New System.Drawing.Size(345, 125)
        Me.SayreChiPanel.TabIndex = 5
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
        Me.ManningCnAnPanel.Size = New System.Drawing.Size(345, 125)
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
        'SurfaceVolumeSummaryTable
        '
        Me.SurfaceVolumeSummaryTable.AccessibleDescription = "Tabulated comparison of measured vs. predicted surface volumes at selected advanc" & _
            "e distances."
        Me.SurfaceVolumeSummaryTable.AccessibleName = "Surface Volume Summary Table"
        Me.SurfaceVolumeSummaryTable.AllRowsFixed = False
        Me.SurfaceVolumeSummaryTable.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.SurfaceVolumeSummaryTable.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.SurfaceVolumeSummaryTable.CaptionText = "Surface Volume Summary"
        Me.SurfaceVolumeSummaryTable.CausesValidation = False
        Me.SurfaceVolumeSummaryTable.ColumnWidthRatios = Nothing
        Me.SurfaceVolumeSummaryTable.DataMember = ""
        Me.SurfaceVolumeSummaryTable.EnableSaveActions = True
        Me.SurfaceVolumeSummaryTable.FirstColumnIncreases = True
        Me.SurfaceVolumeSummaryTable.FirstColumnMaximum = 1.7976931348623157E+308
        Me.SurfaceVolumeSummaryTable.FirstColumnMinimum = 0
        Me.SurfaceVolumeSummaryTable.FirstRowFixed = False
        Me.SurfaceVolumeSummaryTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurfaceVolumeSummaryTable.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.SurfaceVolumeSummaryTable.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.SurfaceVolumeSummaryTable.Location = New System.Drawing.Point(0, 182)
        Me.SurfaceVolumeSummaryTable.MaxRows = 50
        Me.SurfaceVolumeSummaryTable.MinRows = 2
        Me.SurfaceVolumeSummaryTable.Name = "SurfaceVolumeSummaryTable"
        Me.SurfaceVolumeSummaryTable.SecondColumnIncreases = False
        Me.SurfaceVolumeSummaryTable.SecondColumnMaximum = 1.7976931348623157E+308
        Me.SurfaceVolumeSummaryTable.SecondColumnMinimum = 0
        Me.SurfaceVolumeSummaryTable.Size = New System.Drawing.Size(365, 126)
        Me.SurfaceVolumeSummaryTable.TabIndex = 7
        Me.SurfaceVolumeSummaryTable.TableReadonly = False
        '
        'SurfaceFlowVolumeGraph
        '
        Me.SurfaceFlowVolumeGraph.AccessibleDescription = "Graph comparing measured vs. predicted surface volumes."
        Me.SurfaceFlowVolumeGraph.AccessibleName = "Surface Volumes Graph"
        Me.SurfaceFlowVolumeGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SurfaceFlowVolumeGraph.BottomTitleAdjY = 0.0!
        Me.SurfaceFlowVolumeGraph.DisplayKey = False
        Me.SurfaceFlowVolumeGraph.FontAdjustment = 0.0!
        Me.SurfaceFlowVolumeGraph.FontName = "Microsoft Sans Serif"
        Me.SurfaceFlowVolumeGraph.FontSize = 10.0!
        Me.SurfaceFlowVolumeGraph.GraphSymbols = Nothing
        Me.SurfaceFlowVolumeGraph.HorizontalKeys = False
        Me.SurfaceFlowVolumeGraph.HorzLines = Nothing
        Me.SurfaceFlowVolumeGraph.LastCurve = -1
        Me.SurfaceFlowVolumeGraph.LeftTitleAdjX = 0.0!
        Me.SurfaceFlowVolumeGraph.Location = New System.Drawing.Point(370, 8)
        Me.SurfaceFlowVolumeGraph.MaxX = 0
        Me.SurfaceFlowVolumeGraph.MaxY = 0
        Me.SurfaceFlowVolumeGraph.MinX = 0
        Me.SurfaceFlowVolumeGraph.MinY = 0
        Me.SurfaceFlowVolumeGraph.Name = "SurfaceFlowVolumeGraph"
        Me.SurfaceFlowVolumeGraph.NewKeys = False
        Me.SurfaceFlowVolumeGraph.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.SurfaceFlowVolumeGraph.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.SurfaceFlowVolumeGraph.RightTitleAdjX = 0.0!
        Me.SurfaceFlowVolumeGraph.Size = New System.Drawing.Size(377, 299)
        Me.SurfaceFlowVolumeGraph.TabIndex = 6
        Me.SurfaceFlowVolumeGraph.TabStop = False
        Me.SurfaceFlowVolumeGraph.Text = "Bitmap Diagram"
        Me.SurfaceFlowVolumeGraph.TitleAdjY = 0.0!
        Me.SurfaceFlowVolumeGraph.TopTitleAdjY = 0.0!
        Me.SurfaceFlowVolumeGraph.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.SurfaceFlowVolumeGraph.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.SurfaceFlowVolumeGraph.VertLines = Nothing
        '
        'ctl_EvalueRoughnessFlowVolumes
        '
        Me.AccessibleDescription = "Estimate the field's roughness parameters using surface flow volumes."
        Me.AccessibleName = "Roughness Flow Volumes"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SurfaceVolumeSummaryTable)
        Me.Controls.Add(Me.SurfaceFlowVolumeGraph)
        Me.Controls.Add(Me.RoughnessBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_EvalueRoughnessFlowVolumes"
        Me.Size = New System.Drawing.Size(750, 315)
        Me.RoughnessBox.ResumeLayout(False)
        Me.NrcsManningNPanel.ResumeLayout(False)
        Me.SayreChiPanel.ResumeLayout(False)
        Me.ManningCnAnPanel.ResumeLayout(False)
        CType(Me.SurfaceVolumeSummaryTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SurfaceFlowVolumeGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RoughnessBox As DataStore.ctl_GroupBox
    Friend WithEvents RoughnessMethodLabel As DataStore.ctl_Label
    Friend WithEvents RoughnessMethodControl As DataStore.ctl_SelectParameter
    Friend WithEvents NrcsManningNPanel As DataStore.ctl_Panel
    Friend WithEvents UsersManningNControl As DataStore.ctl_DoubleParameter
    Friend WithEvents Sel_UserEntered As DataStore.ctl_RadioButton
    Friend WithEvents Sel_025 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_020 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_015 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_010 As DataStore.ctl_RadioButton
    Friend WithEvents Sel_004 As DataStore.ctl_RadioButton
    Friend WithEvents SayreChiPanel As DataStore.ctl_Panel
    Friend WithEvents SayreChiControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SayreChiLabel As DataStore.ctl_Label
    Friend WithEvents ManningCnAnPanel As DataStore.ctl_Panel
    Friend WithEvents ManningAnControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ManningAnLabel As DataStore.ctl_Label
    Friend WithEvents ManningCnControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ManningCnLabel As DataStore.ctl_Label
    Friend WithEvents SurfaceFlowVolumeGraph As WinMain.grf_XYGraph
    Friend WithEvents SurfaceVolumeSummaryTable As DataStore.ctl_DataTableParameter

End Class
