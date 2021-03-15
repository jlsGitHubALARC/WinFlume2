<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_EvaluationInfiltration
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
        Me.EvalueInfiltrationInstructions = New System.Windows.Forms.RichTextBox
        Me.UpdateShapeFactors = New DataStore.ctl_Button
        Me.MeasuredVsPredictedGraph = New WinMain.grf_XYGraph
        Me.EvalueControl = New WinMain.ctl_Evalue
        Me.MerriamKellerControl = New WinMain.ctl_MerriamKeller
        Me.ElliotWalkerControl = New WinMain.ctl_ElliotWalkerTwoPoint
        CType(Me.MeasuredVsPredictedGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EvalueInfiltrationInstructions
        '
        Me.EvalueInfiltrationInstructions.AccessibleDescription = "Summary of solution's measurement usage and errors."
        Me.EvalueInfiltrationInstructions.AccessibleName = "Solution summary"
        Me.EvalueInfiltrationInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.EvalueInfiltrationInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EvalueInfiltrationInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvalueInfiltrationInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.EvalueInfiltrationInstructions.Location = New System.Drawing.Point(390, 213)
        Me.EvalueInfiltrationInstructions.Margin = New System.Windows.Forms.Padding(4)
        Me.EvalueInfiltrationInstructions.Name = "EvalueInfiltrationInstructions"
        Me.EvalueInfiltrationInstructions.ReadOnly = True
        Me.EvalueInfiltrationInstructions.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.EvalueInfiltrationInstructions.Size = New System.Drawing.Size(386, 205)
        Me.EvalueInfiltrationInstructions.TabIndex = 3
        Me.EvalueInfiltrationInstructions.TabStop = False
        Me.EvalueInfiltrationInstructions.Text = "EVALUE Infiltration Instructions"
        '
        'UpdateShapeFactors
        '
        Me.UpdateShapeFactors.AccessibleDescription = "Run a simulation to improve the Sigma Y values used in the surface volume estimat" & _
            "es."
        Me.UpdateShapeFactors.AccessibleName = "Refine surface volume estimates"
        Me.UpdateShapeFactors.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.UpdateShapeFactors.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateShapeFactors.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.UpdateShapeFactors.Location = New System.Drawing.Point(14, 398)
        Me.UpdateShapeFactors.Name = "UpdateShapeFactors"
        Me.UpdateShapeFactors.Size = New System.Drawing.Size(358, 24)
        Me.UpdateShapeFactors.TabIndex = 2
        Me.UpdateShapeFactors.Text = "&Update Shape Factors"
        Me.UpdateShapeFactors.UseVisualStyleBackColor = False
        '
        'MeasuredVsPredictedGraph
        '
        Me.MeasuredVsPredictedGraph.AccessibleDescription = "A copyable bitmap image"
        Me.MeasuredVsPredictedGraph.AccessibleName = "Infiltration Function Graph"
        Me.MeasuredVsPredictedGraph.BottomTitleAdjY = 0.0!
        Me.MeasuredVsPredictedGraph.CopyDataSet = Nothing
        Me.MeasuredVsPredictedGraph.CurveControlIsOn = False
        Me.MeasuredVsPredictedGraph.DisplayKey = False
        Me.MeasuredVsPredictedGraph.FontAdjustment = 0.0!
        Me.MeasuredVsPredictedGraph.FontName = "Microsoft Sans Serif"
        Me.MeasuredVsPredictedGraph.FontSize = 10.0!
        Me.MeasuredVsPredictedGraph.GraphSymbols = Nothing
        Me.MeasuredVsPredictedGraph.HorizontalKeys = False
        Me.MeasuredVsPredictedGraph.HorzLines = Nothing
        Me.MeasuredVsPredictedGraph.LastCurve = -1
        Me.MeasuredVsPredictedGraph.LeftTitleAdjX = 0.0!
        Me.MeasuredVsPredictedGraph.Location = New System.Drawing.Point(389, 3)
        Me.MeasuredVsPredictedGraph.MaxX = 0
        Me.MeasuredVsPredictedGraph.MaxY = 0
        Me.MeasuredVsPredictedGraph.MinX = 0
        Me.MeasuredVsPredictedGraph.MinY = 0
        Me.MeasuredVsPredictedGraph.Name = "MeasuredVsPredictedGraph"
        Me.MeasuredVsPredictedGraph.NewHotspotKeys = True
        Me.MeasuredVsPredictedGraph.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.MeasuredVsPredictedGraph.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.MeasuredVsPredictedGraph.RightTitleAdjX = 0.0!
        Me.MeasuredVsPredictedGraph.Size = New System.Drawing.Size(387, 187)
        Me.MeasuredVsPredictedGraph.TabIndex = 11
        Me.MeasuredVsPredictedGraph.TabStop = False
        Me.MeasuredVsPredictedGraph.Text = "Bitmap Diagram"
        Me.MeasuredVsPredictedGraph.TextLines = Nothing
        Me.MeasuredVsPredictedGraph.TitleAdjY = 0.0!
        Me.MeasuredVsPredictedGraph.TopTitleAdjY = 0.0!
        Me.MeasuredVsPredictedGraph.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.MeasuredVsPredictedGraph.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.MeasuredVsPredictedGraph.VertLabels = Nothing
        Me.MeasuredVsPredictedGraph.VertLines = Nothing
        Me.MeasuredVsPredictedGraph.VLabelPos = Nothing
        '
        'EvalueControl
        '
        Me.EvalueControl.AccessibleDescription = ""
        Me.EvalueControl.AccessibleName = ""
        Me.EvalueControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvalueControl.Location = New System.Drawing.Point(4, 4)
        Me.EvalueControl.Margin = New System.Windows.Forms.Padding(4)
        Me.EvalueControl.Name = "EvalueControl"
        Me.EvalueControl.Size = New System.Drawing.Size(379, 400)
        Me.EvalueControl.TabIndex = 1
        '
        'MerriamKellerControl
        '
        Me.MerriamKellerControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MerriamKellerControl.Location = New System.Drawing.Point(4, 4)
        Me.MerriamKellerControl.Name = "MerriamKellerControl"
        Me.MerriamKellerControl.Size = New System.Drawing.Size(379, 420)
        Me.MerriamKellerControl.TabIndex = 1
        '
        'ElliotWalkerControl
        '
        Me.ElliotWalkerControl.Location = New System.Drawing.Point(4, 4)
        Me.ElliotWalkerControl.Name = "ElliotWalkerControl"
        Me.ElliotWalkerControl.Size = New System.Drawing.Size(379, 390)
        Me.ElliotWalkerControl.TabIndex = 1
        '
        'ctl_EvaluationInfiltration
        '
        Me.AccessibleDescription = "Estimate a field's infiltration parameters."
        Me.AccessibleName = "Evaluation Infiltration"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UpdateShapeFactors)
        Me.Controls.Add(Me.MeasuredVsPredictedGraph)
        Me.Controls.Add(Me.EvalueInfiltrationInstructions)
        Me.Controls.Add(Me.ElliotWalkerControl)
        Me.Controls.Add(Me.EvalueControl)
        Me.Controls.Add(Me.MerriamKellerControl)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_EvaluationInfiltration"
        Me.Size = New System.Drawing.Size(780, 430)
        CType(Me.MeasuredVsPredictedGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EvalueInfiltrationInstructions As System.Windows.Forms.RichTextBox
    Friend WithEvents ElliotWalkerControl As WinMain.ctl_ElliotWalkerTwoPoint
    Friend WithEvents MerriamKellerControl As WinMain.ctl_MerriamKeller
    Friend WithEvents EvalueControl As WinMain.ctl_Evalue
    Friend WithEvents MeasuredVsPredictedGraph As WinMain.grf_XYGraph
    Friend WithEvents UpdateShapeFactors As DataStore.ctl_Button

End Class
