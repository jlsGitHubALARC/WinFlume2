<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_VolumeBalances
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
        Me.VolumeBalanceNotes = New System.Windows.Forms.RichTextBox()
        Me.SuggestTimesButton = New DataStore.ctl_Button()
        Me.ElliotWalkerBox = New DataStore.ctl_GroupBox()
        Me.ElliotWalkerNotes = New System.Windows.Forms.RichTextBox()
        Me.ElliotWalkerVolumeBalanceTable = New DataStore.ctl_DataTableParameter()
        Me.MerriamKellerBox = New DataStore.ctl_GroupBox()
        Me.MerriamKellerNotes = New System.Windows.Forms.RichTextBox()
        Me.MerriamKellerVolumeBalanceTable = New DataStore.ctl_DataTableParameter()
        Me.EvalueBox = New DataStore.ctl_GroupBox()
        Me.EvalueVolumeBalanceTable = New DataStore.ctl_DataTableParameter()
        Me.HydraulicSummaryTitle = New DataStore.ctl_Label()
        Me.MassBalanceTimesGraph = New WinMain.grf_SurfaceFlowSummary()
        Me.ElliotWalkerBox.SuspendLayout()
        CType(Me.ElliotWalkerVolumeBalanceTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MerriamKellerBox.SuspendLayout()
        CType(Me.MerriamKellerVolumeBalanceTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EvalueBox.SuspendLayout()
        CType(Me.EvalueVolumeBalanceTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MassBalanceTimesGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VolumeBalanceNotes
        '
        Me.VolumeBalanceNotes.AccessibleDescription = "Summary of Volume Balance calculations and associated errors."
        Me.VolumeBalanceNotes.AccessibleName = "Volume Balance Summary"
        Me.VolumeBalanceNotes.BackColor = System.Drawing.SystemColors.Info
        Me.VolumeBalanceNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VolumeBalanceNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolumeBalanceNotes.ForeColor = System.Drawing.SystemColors.InfoText
        Me.VolumeBalanceNotes.Location = New System.Drawing.Point(373, 210)
        Me.VolumeBalanceNotes.Margin = New System.Windows.Forms.Padding(4)
        Me.VolumeBalanceNotes.Name = "VolumeBalanceNotes"
        Me.VolumeBalanceNotes.ReadOnly = True
        Me.VolumeBalanceNotes.Size = New System.Drawing.Size(403, 206)
        Me.VolumeBalanceNotes.TabIndex = 2
        Me.VolumeBalanceNotes.TabStop = False
        Me.VolumeBalanceNotes.Text = ""
        '
        'SuggestTimesButton
        '
        Me.SuggestTimesButton.AccessibleDescription = "Press to have WinSRFR suggest appropriate times for volume balance calculations."
        Me.SuggestTimesButton.AccessibleName = "Suggest Times for Volume Balance Calculations"
        Me.SuggestTimesButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SuggestTimesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuggestTimesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SuggestTimesButton.Location = New System.Drawing.Point(10, 20)
        Me.SuggestTimesButton.Name = "SuggestTimesButton"
        Me.SuggestTimesButton.Size = New System.Drawing.Size(340, 24)
        Me.SuggestTimesButton.TabIndex = 0
        Me.SuggestTimesButton.Text = "&Calculation Times"
        Me.SuggestTimesButton.UseVisualStyleBackColor = False
        '
        'ElliotWalkerBox
        '
        Me.ElliotWalkerBox.AccessibleDescription = "Times and volume balance calculations for the Elliott-Walker Two-Point analysis"
        Me.ElliotWalkerBox.AccessibleName = "Elliott-Walker Two-Point Analysis"
        Me.ElliotWalkerBox.Controls.Add(Me.ElliotWalkerNotes)
        Me.ElliotWalkerBox.Controls.Add(Me.ElliotWalkerVolumeBalanceTable)
        Me.ElliotWalkerBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElliotWalkerBox.Location = New System.Drawing.Point(4, 4)
        Me.ElliotWalkerBox.Name = "ElliotWalkerBox"
        Me.ElliotWalkerBox.Size = New System.Drawing.Size(354, 412)
        Me.ElliotWalkerBox.TabIndex = 1
        Me.ElliotWalkerBox.TabStop = False
        Me.ElliotWalkerBox.Text = "&Elliott-Walker Two-Point Analysis"
        '
        'ElliotWalkerNotes
        '
        Me.ElliotWalkerNotes.BackColor = System.Drawing.SystemColors.Info
        Me.ElliotWalkerNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ElliotWalkerNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElliotWalkerNotes.ForeColor = System.Drawing.SystemColors.InfoText
        Me.ElliotWalkerNotes.Location = New System.Drawing.Point(6, 147)
        Me.ElliotWalkerNotes.Margin = New System.Windows.Forms.Padding(4)
        Me.ElliotWalkerNotes.Name = "ElliotWalkerNotes"
        Me.ElliotWalkerNotes.ReadOnly = True
        Me.ElliotWalkerNotes.Size = New System.Drawing.Size(341, 258)
        Me.ElliotWalkerNotes.TabIndex = 3
        Me.ElliotWalkerNotes.TabStop = False
        Me.ElliotWalkerNotes.Text = ""
        '
        'ElliotWalkerVolumeBalanceTable
        '
        Me.ElliotWalkerVolumeBalanceTable.AccessibleDescription = "Table showing volume balance calculations for specified times."
        Me.ElliotWalkerVolumeBalanceTable.AccessibleName = "Volume Balance Table"
        Me.ElliotWalkerVolumeBalanceTable.AllRowsFixed = False
        Me.ElliotWalkerVolumeBalanceTable.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.ElliotWalkerVolumeBalanceTable.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.ElliotWalkerVolumeBalanceTable.CaptionText = "Volume Balances"
        Me.ElliotWalkerVolumeBalanceTable.CausesValidation = False
        Me.ElliotWalkerVolumeBalanceTable.ColumnWidthRatios = Nothing
        Me.ElliotWalkerVolumeBalanceTable.DataMember = ""
        Me.ElliotWalkerVolumeBalanceTable.EnableSaveActions = False
        Me.ElliotWalkerVolumeBalanceTable.FirstColumnIncreases = True
        Me.ElliotWalkerVolumeBalanceTable.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.ElliotWalkerVolumeBalanceTable.FirstColumnMinimum = 0R
        Me.ElliotWalkerVolumeBalanceTable.FirstRowFixed = False
        Me.ElliotWalkerVolumeBalanceTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElliotWalkerVolumeBalanceTable.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.ElliotWalkerVolumeBalanceTable.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.ElliotWalkerVolumeBalanceTable.Location = New System.Drawing.Point(6, 20)
        Me.ElliotWalkerVolumeBalanceTable.MaxRows = 50
        Me.ElliotWalkerVolumeBalanceTable.MinRows = 2
        Me.ElliotWalkerVolumeBalanceTable.Name = "ElliotWalkerVolumeBalanceTable"
        Me.ElliotWalkerVolumeBalanceTable.PasteDisabled = False
        Me.ElliotWalkerVolumeBalanceTable.SecondColumnIncreases = False
        Me.ElliotWalkerVolumeBalanceTable.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.ElliotWalkerVolumeBalanceTable.SecondColumnMinimum = 0R
        Me.ElliotWalkerVolumeBalanceTable.Size = New System.Drawing.Size(342, 120)
        Me.ElliotWalkerVolumeBalanceTable.TabIndex = 1
        Me.ElliotWalkerVolumeBalanceTable.TableReadonly = False
        '
        'MerriamKellerBox
        '
        Me.MerriamKellerBox.AccessibleDescription = "Times and volume balance calculations for the Merriam-Keller analysis"
        Me.MerriamKellerBox.AccessibleName = "Merriam-Keller Analysis"
        Me.MerriamKellerBox.Controls.Add(Me.MerriamKellerNotes)
        Me.MerriamKellerBox.Controls.Add(Me.MerriamKellerVolumeBalanceTable)
        Me.MerriamKellerBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MerriamKellerBox.Location = New System.Drawing.Point(4, 4)
        Me.MerriamKellerBox.Name = "MerriamKellerBox"
        Me.MerriamKellerBox.Size = New System.Drawing.Size(354, 412)
        Me.MerriamKellerBox.TabIndex = 2
        Me.MerriamKellerBox.TabStop = False
        Me.MerriamKellerBox.Text = "&Merriam-Keller Analysis"
        '
        'MerriamKellerNotes
        '
        Me.MerriamKellerNotes.BackColor = System.Drawing.SystemColors.Info
        Me.MerriamKellerNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MerriamKellerNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MerriamKellerNotes.ForeColor = System.Drawing.SystemColors.InfoText
        Me.MerriamKellerNotes.Location = New System.Drawing.Point(6, 147)
        Me.MerriamKellerNotes.Margin = New System.Windows.Forms.Padding(4)
        Me.MerriamKellerNotes.Name = "MerriamKellerNotes"
        Me.MerriamKellerNotes.ReadOnly = True
        Me.MerriamKellerNotes.Size = New System.Drawing.Size(341, 258)
        Me.MerriamKellerNotes.TabIndex = 3
        Me.MerriamKellerNotes.TabStop = False
        Me.MerriamKellerNotes.Text = ""
        '
        'MerriamKellerVolumeBalanceTable
        '
        Me.MerriamKellerVolumeBalanceTable.AccessibleDescription = "Table showing volume balance calculations for specified times."
        Me.MerriamKellerVolumeBalanceTable.AccessibleName = "Volume Balance Table"
        Me.MerriamKellerVolumeBalanceTable.AllRowsFixed = False
        Me.MerriamKellerVolumeBalanceTable.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.MerriamKellerVolumeBalanceTable.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.MerriamKellerVolumeBalanceTable.CaptionText = "Volume Balances"
        Me.MerriamKellerVolumeBalanceTable.CausesValidation = False
        Me.MerriamKellerVolumeBalanceTable.ColumnWidthRatios = Nothing
        Me.MerriamKellerVolumeBalanceTable.DataMember = ""
        Me.MerriamKellerVolumeBalanceTable.EnableSaveActions = False
        Me.MerriamKellerVolumeBalanceTable.FirstColumnIncreases = True
        Me.MerriamKellerVolumeBalanceTable.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.MerriamKellerVolumeBalanceTable.FirstColumnMinimum = 0R
        Me.MerriamKellerVolumeBalanceTable.FirstRowFixed = False
        Me.MerriamKellerVolumeBalanceTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MerriamKellerVolumeBalanceTable.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.MerriamKellerVolumeBalanceTable.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.MerriamKellerVolumeBalanceTable.Location = New System.Drawing.Point(6, 20)
        Me.MerriamKellerVolumeBalanceTable.MaxRows = 50
        Me.MerriamKellerVolumeBalanceTable.MinRows = 2
        Me.MerriamKellerVolumeBalanceTable.Name = "MerriamKellerVolumeBalanceTable"
        Me.MerriamKellerVolumeBalanceTable.PasteDisabled = False
        Me.MerriamKellerVolumeBalanceTable.SecondColumnIncreases = False
        Me.MerriamKellerVolumeBalanceTable.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.MerriamKellerVolumeBalanceTable.SecondColumnMinimum = 0R
        Me.MerriamKellerVolumeBalanceTable.Size = New System.Drawing.Size(342, 120)
        Me.MerriamKellerVolumeBalanceTable.TabIndex = 1
        Me.MerriamKellerVolumeBalanceTable.TableReadonly = False
        '
        'EvalueBox
        '
        Me.EvalueBox.AccessibleDescription = "Times and volume balance calculations for the EVALUE analysis"
        Me.EvalueBox.AccessibleName = "EVALUE Analysis"
        Me.EvalueBox.Controls.Add(Me.EvalueVolumeBalanceTable)
        Me.EvalueBox.Controls.Add(Me.SuggestTimesButton)
        Me.EvalueBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvalueBox.Location = New System.Drawing.Point(4, 4)
        Me.EvalueBox.Name = "EvalueBox"
        Me.EvalueBox.Size = New System.Drawing.Size(362, 412)
        Me.EvalueBox.TabIndex = 3
        Me.EvalueBox.TabStop = False
        Me.EvalueBox.Text = "&EVALUE Analysis"
        '
        'EvalueVolumeBalanceTable
        '
        Me.EvalueVolumeBalanceTable.AccessibleDescription = "Table showing volume balance calculations for specified times."
        Me.EvalueVolumeBalanceTable.AccessibleName = "Volume Balance Table"
        Me.EvalueVolumeBalanceTable.AllRowsFixed = False
        Me.EvalueVolumeBalanceTable.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.EvalueVolumeBalanceTable.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.EvalueVolumeBalanceTable.CaptionText = "Volume Balances"
        Me.EvalueVolumeBalanceTable.CausesValidation = False
        Me.EvalueVolumeBalanceTable.ColumnWidthRatios = Nothing
        Me.EvalueVolumeBalanceTable.DataMember = ""
        Me.EvalueVolumeBalanceTable.EnableSaveActions = True
        Me.EvalueVolumeBalanceTable.FirstColumnIncreases = True
        Me.EvalueVolumeBalanceTable.FirstColumnMaximum = 1.7976931348623157E+308R
        Me.EvalueVolumeBalanceTable.FirstColumnMinimum = 0R
        Me.EvalueVolumeBalanceTable.FirstRowFixed = False
        Me.EvalueVolumeBalanceTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvalueVolumeBalanceTable.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.EvalueVolumeBalanceTable.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EvalueVolumeBalanceTable.Location = New System.Drawing.Point(10, 50)
        Me.EvalueVolumeBalanceTable.MaxRows = 50
        Me.EvalueVolumeBalanceTable.MinRows = 0
        Me.EvalueVolumeBalanceTable.Name = "EvalueVolumeBalanceTable"
        Me.EvalueVolumeBalanceTable.PasteDisabled = False
        Me.EvalueVolumeBalanceTable.SecondColumnIncreases = False
        Me.EvalueVolumeBalanceTable.SecondColumnMaximum = 1.7976931348623157E+308R
        Me.EvalueVolumeBalanceTable.SecondColumnMinimum = 0R
        Me.EvalueVolumeBalanceTable.Size = New System.Drawing.Size(340, 247)
        Me.EvalueVolumeBalanceTable.TabIndex = 1
        Me.EvalueVolumeBalanceTable.TableReadonly = False
        '
        'HydraulicSummaryTitle
        '
        Me.HydraulicSummaryTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HydraulicSummaryTitle.Location = New System.Drawing.Point(373, 5)
        Me.HydraulicSummaryTitle.Name = "HydraulicSummaryTitle"
        Me.HydraulicSummaryTitle.Size = New System.Drawing.Size(404, 17)
        Me.HydraulicSummaryTitle.TabIndex = 7
        Me.HydraulicSummaryTitle.Text = "Hydraulic Summary"
        Me.HydraulicSummaryTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MassBalanceTimesGraph
        '
        Me.MassBalanceTimesGraph.AccessibleDescription = "Graphical depiction of selected Mass Balance Times"
        Me.MassBalanceTimesGraph.AccessibleName = "Surface Flow Diagram"
        Me.MassBalanceTimesGraph.AdvanceRecession = Nothing
        Me.MassBalanceTimesGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MassBalanceTimesGraph.BottomTitleAdjY = 0!
        Me.MassBalanceTimesGraph.CopyDataSet = Nothing
        Me.MassBalanceTimesGraph.CurveControlIsOn = False
        Me.MassBalanceTimesGraph.DisplayKey = False
        Me.MassBalanceTimesGraph.FontAdjustment = 0!
        Me.MassBalanceTimesGraph.FontName = "Microsoft Sans Serif"
        Me.MassBalanceTimesGraph.FontSize = 10.0!
        Me.MassBalanceTimesGraph.GraphSymbols = Nothing
        Me.MassBalanceTimesGraph.HighlightLine = -1
        Me.MassBalanceTimesGraph.HorizontalKeys = False
        Me.MassBalanceTimesGraph.HorzLines = Nothing
        Me.MassBalanceTimesGraph.Inflow = Nothing
        Me.MassBalanceTimesGraph.LastCurve = -1
        Me.MassBalanceTimesGraph.LeftTitleAdjX = 0!
        Me.MassBalanceTimesGraph.Length = 0R
        Me.MassBalanceTimesGraph.Location = New System.Drawing.Point(373, 25)
        Me.MassBalanceTimesGraph.MaxX = 0R
        Me.MassBalanceTimesGraph.MaxY = 0R
        Me.MassBalanceTimesGraph.MinX = 0R
        Me.MassBalanceTimesGraph.MinY = 0R
        Me.MassBalanceTimesGraph.Name = "MassBalanceTimesGraph"
        Me.MassBalanceTimesGraph.NewHotspotKeys = True
        Me.MassBalanceTimesGraph.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.MassBalanceTimesGraph.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.MassBalanceTimesGraph.RightTitleAdjX = 0!
        Me.MassBalanceTimesGraph.Runoff = Nothing
        Me.MassBalanceTimesGraph.Size = New System.Drawing.Size(404, 178)
        Me.MassBalanceTimesGraph.TabIndex = 6
        Me.MassBalanceTimesGraph.TabStop = False
        Me.MassBalanceTimesGraph.Text = "Bitmap Diagram"
        Me.MassBalanceTimesGraph.TextLines = Nothing
        Me.MassBalanceTimesGraph.TimeLines = Nothing
        Me.MassBalanceTimesGraph.TitleAdjY = 0!
        Me.MassBalanceTimesGraph.TopTitleAdjY = 0!
        Me.MassBalanceTimesGraph.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.MassBalanceTimesGraph.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.MassBalanceTimesGraph.VertLabels = Nothing
        Me.MassBalanceTimesGraph.VertLines = Nothing
        Me.MassBalanceTimesGraph.VLabelPos = Nothing
        '
        'ctl_VolumeBalances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.HydraulicSummaryTitle)
        Me.Controls.Add(Me.VolumeBalanceNotes)
        Me.Controls.Add(Me.MassBalanceTimesGraph)
        Me.Controls.Add(Me.EvalueBox)
        Me.Controls.Add(Me.MerriamKellerBox)
        Me.Controls.Add(Me.ElliotWalkerBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_VolumeBalances"
        Me.Size = New System.Drawing.Size(780, 420)
        Me.ElliotWalkerBox.ResumeLayout(False)
        CType(Me.ElliotWalkerVolumeBalanceTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MerriamKellerBox.ResumeLayout(False)
        CType(Me.MerriamKellerVolumeBalanceTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EvalueBox.ResumeLayout(False)
        CType(Me.EvalueVolumeBalanceTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MassBalanceTimesGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MassBalanceTimesGraph As WinMain.grf_SurfaceFlowSummary
    Friend WithEvents VolumeBalanceNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents SuggestTimesButton As DataStore.ctl_Button
    Friend WithEvents ElliotWalkerBox As DataStore.ctl_GroupBox
    Friend WithEvents ElliotWalkerNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents ElliotWalkerVolumeBalanceTable As DataStore.ctl_DataTableParameter
    Friend WithEvents MerriamKellerBox As DataStore.ctl_GroupBox
    Friend WithEvents MerriamKellerNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents MerriamKellerVolumeBalanceTable As DataStore.ctl_DataTableParameter
    Friend WithEvents EvalueBox As DataStore.ctl_GroupBox
    Friend WithEvents EvalueVolumeBalanceTable As DataStore.ctl_DataTableParameter
    Friend WithEvents HydraulicSummaryTitle As DataStore.ctl_Label
End Class
