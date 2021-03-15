<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_EvalueRoughness
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
        Me.EvalueRoughnessInstructions = New System.Windows.Forms.RichTextBox
        Me.EvalueRoughnessFlowDepths = New WinMain.ctl_EvalueRoughnessFlowDepths
        Me.SuspendLayout()
        '
        'EvalueRoughnessInstructions
        '
        Me.EvalueRoughnessInstructions.AccessibleDescription = "Summary of procedure for estimating a field's roughness parameters."
        Me.EvalueRoughnessInstructions.AccessibleName = "EVALUE Roughness Summary"
        Me.EvalueRoughnessInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.EvalueRoughnessInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EvalueRoughnessInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvalueRoughnessInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.EvalueRoughnessInstructions.Location = New System.Drawing.Point(10, 10)
        Me.EvalueRoughnessInstructions.Margin = New System.Windows.Forms.Padding(4)
        Me.EvalueRoughnessInstructions.Name = "EvalueRoughnessInstructions"
        Me.EvalueRoughnessInstructions.ReadOnly = True
        Me.EvalueRoughnessInstructions.Size = New System.Drawing.Size(760, 55)
        Me.EvalueRoughnessInstructions.TabIndex = 0
        Me.EvalueRoughnessInstructions.TabStop = False
        Me.EvalueRoughnessInstructions.Text = "EVALUE Roughness Instructions"
        '
        'EvalueRoughnessFlowDepths
        '
        Me.EvalueRoughnessFlowDepths.AccessibleDescription = "Estimate the field's roughness parameters using surface flow depths."
        Me.EvalueRoughnessFlowDepths.AccessibleName = "Roughness Flow Depths"
        Me.EvalueRoughnessFlowDepths.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvalueRoughnessFlowDepths.Location = New System.Drawing.Point(10, 73)
        Me.EvalueRoughnessFlowDepths.Margin = New System.Windows.Forms.Padding(4)
        Me.EvalueRoughnessFlowDepths.Name = "EvalueRoughnessFlowDepths"
        Me.EvalueRoughnessFlowDepths.Size = New System.Drawing.Size(760, 332)
        Me.EvalueRoughnessFlowDepths.TabIndex = 1
        '
        'ctl_EvalueRoughness
        '
        Me.AccessibleDescription = "Estimate a field's roughness parameters."
        Me.AccessibleName = "Evaluation Roughness"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.EvalueRoughnessFlowDepths)
        Me.Controls.Add(Me.EvalueRoughnessInstructions)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_EvalueRoughness"
        Me.Size = New System.Drawing.Size(780, 420)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EvalueRoughnessInstructions As System.Windows.Forms.RichTextBox
    Friend WithEvents EvalueRoughnessFlowDepths As WinMain.ctl_EvalueRoughnessFlowDepths

End Class
