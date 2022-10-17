<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_Precision
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
        Me.PrecisionUpDown = New System.Windows.Forms.DomainUpDown()
        Me.PrecisionUnits = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PrecisionUpDown
        '
        Me.PrecisionUpDown.Items.Add("0.1")
        Me.PrecisionUpDown.Items.Add("0.01")
        Me.PrecisionUpDown.Items.Add("0.001")
        Me.PrecisionUpDown.Location = New System.Drawing.Point(0, 0)
        Me.PrecisionUpDown.Name = "PrecisionUpDown"
        Me.PrecisionUpDown.ReadOnly = True
        Me.PrecisionUpDown.Size = New System.Drawing.Size(65, 23)
        Me.PrecisionUpDown.TabIndex = 1
        Me.PrecisionUpDown.Text = "0.001"
        '
        'PrecisionUnits
        '
        Me.PrecisionUnits.AutoSize = True
        Me.PrecisionUnits.Location = New System.Drawing.Point(67, 2)
        Me.PrecisionUnits.Name = "PrecisionUnits"
        Me.PrecisionUnits.Size = New System.Drawing.Size(16, 17)
        Me.PrecisionUnits.TabIndex = 2
        Me.PrecisionUnits.Text = "ft"
        Me.PrecisionUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctl_Precision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PrecisionUnits)
        Me.Controls.Add(Me.PrecisionUpDown)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_Precision"
        Me.Size = New System.Drawing.Size(150, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrecisionUpDown As DomainUpDown
    Friend WithEvents PrecisionUnits As Label
End Class
