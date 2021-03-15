<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_FlowDepths
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
        Me.FlowDepthsBox = New DataStore.ctl_GroupBox
        Me.SelectStationsButton = New DataStore.ctl_Button
        Me.FlowDepthsControl = New DataStore.ctl_DataSetParameter
        Me.MeasStationsControl = New DataStore.ctl_DataTableParameter
        Me.FlowDepthsInstructions = New System.Windows.Forms.RichTextBox
        Me.StationsFlowGraph = New WinMain.grf_XYGraph
        Me.FlowDepthsBox.SuspendLayout()
        CType(Me.FlowDepthsControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MeasStationsControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StationsFlowGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowDepthsBox
        '
        Me.FlowDepthsBox.AccessibleDescription = "Tables for entering the Flow Depths at each Measurement Station"
        Me.FlowDepthsBox.AccessibleName = "Flow Depths by Station"
        Me.FlowDepthsBox.Controls.Add(Me.SelectStationsButton)
        Me.FlowDepthsBox.Controls.Add(Me.FlowDepthsControl)
        Me.FlowDepthsBox.Controls.Add(Me.MeasStationsControl)
        Me.FlowDepthsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowDepthsBox.Location = New System.Drawing.Point(4, 6)
        Me.FlowDepthsBox.Name = "FlowDepthsBox"
        Me.FlowDepthsBox.Size = New System.Drawing.Size(282, 410)
        Me.FlowDepthsBox.TabIndex = 1
        Me.FlowDepthsBox.TabStop = False
        Me.FlowDepthsBox.Text = "Flow Depths &by Station"
        '
        'SelectStationsButton
        '
        Me.SelectStationsButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SelectStationsButton.Location = New System.Drawing.Point(6, 190)
        Me.SelectStationsButton.Name = "SelectStationsButton"
        Me.SelectStationsButton.Size = New System.Drawing.Size(270, 23)
        Me.SelectStationsButton.TabIndex = 2
        Me.SelectStationsButton.Text = "&Select Measurement Stations"
        Me.SelectStationsButton.UseVisualStyleBackColor = False
        '
        'FlowDepthsControl
        '
        Me.FlowDepthsControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.FlowDepthsControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.FlowDepthsControl.CaptionText = "Flow Depths"
        Me.FlowDepthsControl.ColumnWidthRatios = Nothing
        Me.FlowDepthsControl.DataMember = ""
        Me.FlowDepthsControl.EnableSaveActions = False
        Me.FlowDepthsControl.FirstColumnIncreases = True
        Me.FlowDepthsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowDepthsControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.FlowDepthsControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.FlowDepthsControl.Location = New System.Drawing.Point(6, 230)
        Me.FlowDepthsControl.MaxRows = 250
        Me.FlowDepthsControl.MinRows = 0
        Me.FlowDepthsControl.Name = "FlowDepthsControl"
        Me.FlowDepthsControl.SecondColumnIncreases = False
        Me.FlowDepthsControl.Size = New System.Drawing.Size(270, 174)
        Me.FlowDepthsControl.TabIndex = 3
        Me.FlowDepthsControl.TableReadonly = False
        Me.FlowDepthsControl.TableSelected = 0
        '
        'MeasStationsControl
        '
        Me.MeasStationsControl.AllRowsFixed = False
        Me.MeasStationsControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.MeasStationsControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.MeasStationsControl.CaptionText = "Measurement Stations"
        Me.MeasStationsControl.CausesValidation = False
        Me.MeasStationsControl.ColumnWidthRatios = Nothing
        Me.MeasStationsControl.DataMember = ""
        Me.MeasStationsControl.EnableSaveActions = False
        Me.MeasStationsControl.FirstColumnIncreases = True
        Me.MeasStationsControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.MeasStationsControl.FirstColumnMinimum = 0
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
        Me.MeasStationsControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.MeasStationsControl.SecondColumnMinimum = 0
        Me.MeasStationsControl.Size = New System.Drawing.Size(270, 163)
        Me.MeasStationsControl.TabIndex = 1
        Me.MeasStationsControl.TableReadonly = False
        '
        'FlowDepthsInstructions
        '
        Me.FlowDepthsInstructions.AccessibleDescription = "Instructions and help for entering station flow depth data"
        Me.FlowDepthsInstructions.AccessibleName = "Flow Depth Measurements Instructions"
        Me.FlowDepthsInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.FlowDepthsInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowDepthsInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowDepthsInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.FlowDepthsInstructions.Location = New System.Drawing.Point(292, 236)
        Me.FlowDepthsInstructions.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowDepthsInstructions.Name = "FlowDepthsInstructions"
        Me.FlowDepthsInstructions.ReadOnly = True
        Me.FlowDepthsInstructions.Size = New System.Drawing.Size(474, 180)
        Me.FlowDepthsInstructions.TabIndex = 3
        Me.FlowDepthsInstructions.TabStop = False
        Me.FlowDepthsInstructions.Text = ""
        '
        'StationsFlowGraph
        '
        Me.StationsFlowGraph.AccessibleDescription = "A copyable bitmap image"
        Me.StationsFlowGraph.AccessibleName = ""
        Me.StationsFlowGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StationsFlowGraph.BottomTitleAdjY = 0.0!
        Me.StationsFlowGraph.CopyDataSet = Nothing
        Me.StationsFlowGraph.CurveControlIsOn = False
        Me.StationsFlowGraph.DisplayKey = False
        Me.StationsFlowGraph.FontAdjustment = 0.0!
        Me.StationsFlowGraph.FontName = "Microsoft Sans Serif"
        Me.StationsFlowGraph.FontSize = 10.0!
        Me.StationsFlowGraph.GraphSymbols = Nothing
        Me.StationsFlowGraph.HorizontalKeys = False
        Me.StationsFlowGraph.HorzLines = Nothing
        Me.StationsFlowGraph.LastCurve = -1
        Me.StationsFlowGraph.LeftTitleAdjX = 0.0!
        Me.StationsFlowGraph.Location = New System.Drawing.Point(292, 6)
        Me.StationsFlowGraph.MaxX = 0
        Me.StationsFlowGraph.MaxY = 0
        Me.StationsFlowGraph.MinX = 0
        Me.StationsFlowGraph.MinY = 0
        Me.StationsFlowGraph.Name = "StationsFlowGraph"
        Me.StationsFlowGraph.NewHotspotKeys = True
        Me.StationsFlowGraph.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.StationsFlowGraph.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.StationsFlowGraph.RightTitleAdjX = 0.0!
        Me.StationsFlowGraph.Size = New System.Drawing.Size(474, 223)
        Me.StationsFlowGraph.TabIndex = 4
        Me.StationsFlowGraph.TabStop = False
        Me.StationsFlowGraph.Text = "Bitmap Diagram"
        Me.StationsFlowGraph.TextLines = Nothing
        Me.StationsFlowGraph.TitleAdjY = 0.0!
        Me.StationsFlowGraph.TopTitleAdjY = 0.0!
        Me.StationsFlowGraph.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.StationsFlowGraph.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.StationsFlowGraph.VertLabels = Nothing
        Me.StationsFlowGraph.VertLines = Nothing
        Me.StationsFlowGraph.VLabelPos = Nothing
        '
        'ctl_FlowDepths
        '
        Me.AccessibleDescription = "Input flow depth measurements at various stations down the field."
        Me.AccessibleName = "Flow Depths"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FlowDepthsInstructions)
        Me.Controls.Add(Me.FlowDepthsBox)
        Me.Controls.Add(Me.StationsFlowGraph)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_FlowDepths"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.FlowDepthsBox.ResumeLayout(False)
        CType(Me.FlowDepthsControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MeasStationsControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StationsFlowGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StationsFlowGraph As WinMain.grf_XYGraph
    Friend WithEvents FlowDepthsBox As DataStore.ctl_GroupBox
    Friend WithEvents FlowDepthsInstructions As System.Windows.Forms.RichTextBox
    Friend WithEvents MeasStationsControl As DataStore.ctl_DataTableParameter
    Friend WithEvents FlowDepthsControl As DataStore.ctl_DataSetParameter
    Friend WithEvents SelectStationsButton As DataStore.ctl_Button

End Class
