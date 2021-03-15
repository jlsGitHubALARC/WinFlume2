<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_SurfaceVolumeMeasured
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
        Me.SurfaceVolumeInstructions = New WinMain.ErrorRichTextBox()
        Me.ShowFlowDepthsBox = New DataStore.ctl_GroupBox()
        Me.DepthProfileButton = New DataStore.ctl_RadioButton()
        Me.ElevationProfileButton = New DataStore.ctl_RadioButton()
        Me.DepthHydrographButton = New DataStore.ctl_RadioButton()
        Me.StationsFlowGraph = New WinMain.grf_XYGraph()
        Me.VolumeBalanceBox = New DataStore.ctl_GroupBox()
        Me.SurfaceVolumesControl = New DataStore.ctl_DataTableParameter()
        Me.MeasStationsControl = New DataStore.ctl_DataTableParameter()
        Me.ShowFlowDepthsBox.SuspendLayout()
        CType(Me.StationsFlowGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VolumeBalanceBox.SuspendLayout()
        CType(Me.SurfaceVolumesControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeasStationsControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SurfaceVolumeInstructions
        '
        Me.SurfaceVolumeInstructions.AccessibleDescription = "Instructions and help for adjusting the Measurement Station elevationsl."
        Me.SurfaceVolumeInstructions.AccessibleName = "Surface Flow Instructions"
        Me.SurfaceVolumeInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.SurfaceVolumeInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SurfaceVolumeInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurfaceVolumeInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.SurfaceVolumeInstructions.Location = New System.Drawing.Point(352, 236)
        Me.SurfaceVolumeInstructions.Margin = New System.Windows.Forms.Padding(4)
        Me.SurfaceVolumeInstructions.Name = "SurfaceVolumeInstructions"
        Me.SurfaceVolumeInstructions.ReadOnly = True
        Me.SurfaceVolumeInstructions.Size = New System.Drawing.Size(414, 180)
        Me.SurfaceVolumeInstructions.TabIndex = 3
        Me.SurfaceVolumeInstructions.TabStop = False
        Me.SurfaceVolumeInstructions.Text = ""
        '
        'ShowFlowDepthsBox
        '
        Me.ShowFlowDepthsBox.AccessibleDescription = "Graphical view of the flow depths at each measurement station."
        Me.ShowFlowDepthsBox.AccessibleName = "Flow Depths Graphs"
        Me.ShowFlowDepthsBox.Controls.Add(Me.DepthProfileButton)
        Me.ShowFlowDepthsBox.Controls.Add(Me.ElevationProfileButton)
        Me.ShowFlowDepthsBox.Controls.Add(Me.DepthHydrographButton)
        Me.ShowFlowDepthsBox.Controls.Add(Me.StationsFlowGraph)
        Me.ShowFlowDepthsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowFlowDepthsBox.Location = New System.Drawing.Point(352, 6)
        Me.ShowFlowDepthsBox.Name = "ShowFlowDepthsBox"
        Me.ShowFlowDepthsBox.Size = New System.Drawing.Size(414, 223)
        Me.ShowFlowDepthsBox.TabIndex = 2
        Me.ShowFlowDepthsBox.TabStop = False
        Me.ShowFlowDepthsBox.Text = "Show"
        '
        'DepthProfileButton
        '
        Me.DepthProfileButton.AutoSize = True
        Me.DepthProfileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthProfileButton.Location = New System.Drawing.Point(160, 20)
        Me.DepthProfileButton.Name = "DepthProfileButton"
        Me.DepthProfileButton.Size = New System.Drawing.Size(115, 21)
        Me.DepthProfileButton.TabIndex = 2
        Me.DepthProfileButton.Text = "Depth &Profiles"
        Me.DepthProfileButton.UseVisualStyleBackColor = True
        '
        'ElevationProfileButton
        '
        Me.ElevationProfileButton.AutoSize = True
        Me.ElevationProfileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElevationProfileButton.Location = New System.Drawing.Point(280, 20)
        Me.ElevationProfileButton.Name = "ElevationProfileButton"
        Me.ElevationProfileButton.Size = New System.Drawing.Size(135, 21)
        Me.ElevationProfileButton.TabIndex = 3
        Me.ElevationProfileButton.Text = "Ele&vation Profiles"
        Me.ElevationProfileButton.UseVisualStyleBackColor = True
        '
        'DepthHydrographButton
        '
        Me.DepthHydrographButton.AutoSize = True
        Me.DepthHydrographButton.Checked = True
        Me.DepthHydrographButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthHydrographButton.Location = New System.Drawing.Point(6, 20)
        Me.DepthHydrographButton.Name = "DepthHydrographButton"
        Me.DepthHydrographButton.Size = New System.Drawing.Size(150, 21)
        Me.DepthHydrographButton.TabIndex = 1
        Me.DepthHydrographButton.TabStop = True
        Me.DepthHydrographButton.Text = "Depth &Hydrographs"
        Me.DepthHydrographButton.UseVisualStyleBackColor = True
        '
        'StationsFlowGraph
        '
        Me.StationsFlowGraph.AccessibleDescription = "A copyable bitmap image"
        Me.StationsFlowGraph.AccessibleName = ""
        Me.StationsFlowGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StationsFlowGraph.BottomTitleAdjY = 0!
        Me.StationsFlowGraph.CopyDataSet = Nothing
        Me.StationsFlowGraph.CurveControlIsOn = False
        Me.StationsFlowGraph.DisplayKey = False
        Me.StationsFlowGraph.FontAdjustment = 0!
        Me.StationsFlowGraph.FontName = "Microsoft Sans Serif"
        Me.StationsFlowGraph.FontSize = 10.0!
        Me.StationsFlowGraph.GraphSymbols = Nothing
        Me.StationsFlowGraph.HorizontalKeys = False
        Me.StationsFlowGraph.HorzLines = Nothing
        Me.StationsFlowGraph.LastCurve = -1
        Me.StationsFlowGraph.LeftTitleAdjX = 0!
        Me.StationsFlowGraph.Location = New System.Drawing.Point(6, 45)
        Me.StationsFlowGraph.MaxX = 0R
        Me.StationsFlowGraph.MaxY = 0R
        Me.StationsFlowGraph.MinX = 0R
        Me.StationsFlowGraph.MinY = 0R
        Me.StationsFlowGraph.Name = "StationsFlowGraph"
        Me.StationsFlowGraph.NewHotspotKeys = True
        Me.StationsFlowGraph.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.StationsFlowGraph.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.StationsFlowGraph.RightTitleAdjX = 0!
        Me.StationsFlowGraph.Size = New System.Drawing.Size(402, 168)
        Me.StationsFlowGraph.TabIndex = 4
        Me.StationsFlowGraph.TabStop = False
        Me.StationsFlowGraph.Text = "Bitmap Diagram"
        Me.StationsFlowGraph.TextLines = Nothing
        Me.StationsFlowGraph.TitleAdjY = 0!
        Me.StationsFlowGraph.TopTitleAdjY = 0!
        Me.StationsFlowGraph.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.StationsFlowGraph.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.StationsFlowGraph.VertLabels = Nothing
        Me.StationsFlowGraph.VertLines = Nothing
        Me.StationsFlowGraph.VLabelPos = Nothing
        '
        'VolumeBalanceBox
        '
        Me.VolumeBalanceBox.Controls.Add(Me.SurfaceVolumesControl)
        Me.VolumeBalanceBox.Controls.Add(Me.MeasStationsControl)
        Me.VolumeBalanceBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolumeBalanceBox.Location = New System.Drawing.Point(4, 6)
        Me.VolumeBalanceBox.Name = "VolumeBalanceBox"
        Me.VolumeBalanceBox.Size = New System.Drawing.Size(341, 410)
        Me.VolumeBalanceBox.TabIndex = 1
        Me.VolumeBalanceBox.TabStop = False
        Me.VolumeBalanceBox.Text = "Surface Volumes from &Station Flow Depths"
        '
        'SurfaceVolumesControl
        '
        Me.SurfaceVolumesControl.AccessibleDescription = "Table showing the calculated surface volumes at various times during the irrigati" &
    "on."
        Me.SurfaceVolumesControl.AccessibleName = "Surface Volumes"
        Me.SurfaceVolumesControl.AllRowsFixed = False
        Me.SurfaceVolumesControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.SurfaceVolumesControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.SurfaceVolumesControl.CaptionText = "Surface Volumes"
        Me.SurfaceVolumesControl.CausesValidation = False
        Me.SurfaceVolumesControl.ColumnWidthRatios = Nothing
        Me.SurfaceVolumesControl.DataMember = ""
        Me.SurfaceVolumesControl.EnableSaveActions = False
        Me.SurfaceVolumesControl.FirstColumnIncreases = True
        Me.SurfaceVolumesControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.SurfaceVolumesControl.FirstColumnMinimum = 0R
        Me.SurfaceVolumesControl.FirstRowFixed = True
        Me.SurfaceVolumesControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurfaceVolumesControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.SurfaceVolumesControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.SurfaceVolumesControl.Location = New System.Drawing.Point(6, 214)
        Me.SurfaceVolumesControl.MaxRows = 250
        Me.SurfaceVolumesControl.MinRows = 0
        Me.SurfaceVolumesControl.Name = "SurfaceVolumesControl"
        Me.SurfaceVolumesControl.PasteDisabled = False
        Me.SurfaceVolumesControl.SecondColumnIncreases = False
        Me.SurfaceVolumesControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.SurfaceVolumesControl.SecondColumnMinimum = 0R
        Me.SurfaceVolumesControl.Size = New System.Drawing.Size(329, 190)
        Me.SurfaceVolumesControl.TabIndex = 2
        Me.SurfaceVolumesControl.TableReadonly = True
        '
        'MeasStationsControl
        '
        Me.MeasStationsControl.AccessibleDescription = "Table of Measurement Stations used to adjust their elevations, if needed."
        Me.MeasStationsControl.AccessibleName = "Measurement Stations"
        Me.MeasStationsControl.AllRowsFixed = False
        Me.MeasStationsControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.MeasStationsControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.MeasStationsControl.CaptionText = "Measurement Stations"
        Me.MeasStationsControl.CausesValidation = False
        Me.MeasStationsControl.ColumnWidthRatios = Nothing
        Me.MeasStationsControl.DataMember = ""
        Me.MeasStationsControl.EnableSaveActions = False
        Me.MeasStationsControl.FirstColumnIncreases = True
        Me.MeasStationsControl.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.MeasStationsControl.FirstColumnMinimum = 0R
        Me.MeasStationsControl.FirstRowFixed = False
        Me.MeasStationsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MeasStationsControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.MeasStationsControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.MeasStationsControl.Location = New System.Drawing.Point(6, 20)
        Me.MeasStationsControl.MaxRows = 250
        Me.MeasStationsControl.MinRows = 0
        Me.MeasStationsControl.Name = "MeasStationsControl"
        Me.MeasStationsControl.PasteDisabled = False
        Me.MeasStationsControl.SecondColumnIncreases = False
        Me.MeasStationsControl.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.MeasStationsControl.SecondColumnMinimum = 0R
        Me.MeasStationsControl.Size = New System.Drawing.Size(329, 190)
        Me.MeasStationsControl.TabIndex = 1
        Me.MeasStationsControl.TableReadonly = False
        '
        'ctl_SurfaceVolumeMeasured
        '
        Me.AccessibleDescription = "Surface volumes measured at various times during the irrigation."
        Me.AccessibleName = "Surface Volume (Measured)"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SurfaceVolumeInstructions)
        Me.Controls.Add(Me.ShowFlowDepthsBox)
        Me.Controls.Add(Me.VolumeBalanceBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_SurfaceVolumeMeasured"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.ShowFlowDepthsBox.ResumeLayout(False)
        Me.ShowFlowDepthsBox.PerformLayout()
        CType(Me.StationsFlowGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VolumeBalanceBox.ResumeLayout(False)
        CType(Me.SurfaceVolumesControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeasStationsControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StationsFlowGraph As WinMain.grf_XYGraph
    Friend WithEvents DepthHydrographButton As DataStore.ctl_RadioButton
    Friend WithEvents ElevationProfileButton As DataStore.ctl_RadioButton
    Friend WithEvents VolumeBalanceBox As DataStore.ctl_GroupBox
    Friend WithEvents ShowFlowDepthsBox As DataStore.ctl_GroupBox
    Friend WithEvents SurfaceVolumeInstructions As WinMain.ErrorRichTextBox
    Friend WithEvents DepthProfileButton As DataStore.ctl_RadioButton
    Friend WithEvents MeasStationsControl As DataStore.ctl_DataTableParameter
    Friend WithEvents SurfaceVolumesControl As DataStore.ctl_DataTableParameter

End Class
