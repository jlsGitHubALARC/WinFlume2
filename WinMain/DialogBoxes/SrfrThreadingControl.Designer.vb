<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SrfrThreadingControl
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.AbortThreadControl = New Srfr.AbortThreadControl()
        Me.SuspendLayout()
        '
        'AbortThreadControl1
        '
        Me.AbortThreadControl.BackColor = System.Drawing.SystemColors.Control
        Me.AbortThreadControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AbortThreadControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AbortThreadControl.Location = New System.Drawing.Point(13, 13)
        Me.AbortThreadControl.Margin = New System.Windows.Forms.Padding(4)
        Me.AbortThreadControl.Name = "AbortThreadControl1"
        Me.AbortThreadControl.Size = New System.Drawing.Size(300, 150)
        Me.AbortThreadControl.TabIndex = 0
        '
        'SrfrThreadingControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 174)
        Me.Controls.Add(Me.AbortThreadControl)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SrfrThreadingControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SRFR Threading Control"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AbortThreadControl As Srfr.AbortThreadControl
End Class
