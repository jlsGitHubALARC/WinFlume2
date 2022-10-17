<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownstreamViewControl
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
        Me.DownstreamViewLabel = New WinFlume.ctl_Label()
        Me.SuspendLayout()
        '
        'DownstreamViewLabel
        '
        Me.DownstreamViewLabel.BackColor = System.Drawing.Color.Transparent
        Me.DownstreamViewLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.DownstreamViewLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DownstreamViewLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DownstreamViewLabel.Location = New System.Drawing.Point(0, 0)
        Me.DownstreamViewLabel.Name = "DownstreamViewLabel"
        Me.DownstreamViewLabel.Size = New System.Drawing.Size(265, 21)
        Me.DownstreamViewLabel.TabIndex = 2
        Me.DownstreamViewLabel.Text = "View from Downstream"
        Me.DownstreamViewLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DownstreamViewControl
        '
        Me.AccessibleDescription = "Cross section view of the flume from its downstream end"
        Me.AccessibleName = "Downstream View"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.DownstreamViewLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "DownstreamViewControl"
        Me.Size = New System.Drawing.Size(265, 65)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DownstreamViewLabel As WinFlume.ctl_Label

End Class
