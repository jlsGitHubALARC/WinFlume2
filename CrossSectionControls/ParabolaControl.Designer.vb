<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParabolaControl
    Inherits WinFlume.CrossSectionControl

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
        Me.Thumbnail = New WinFlume.ctl_PictureBox()
        Me.FocalDistanceSingle = New WinFlume.ctl_SingleUnits()
        Me.FdKey = New WinFlume.ctl_Label()
        Me.FdLabel = New WinFlume.ctl_Label()
        Me.TwKey = New WinFlume.ctl_Label()
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Thumbnail
        '
        Me.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thumbnail.Image = Global.WinFlume.My.Resources.Resources.PARA
        Me.Thumbnail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Thumbnail.Location = New System.Drawing.Point(5, 135)
        Me.Thumbnail.Name = "Thumbnail"
        Me.Thumbnail.Size = New System.Drawing.Size(103, 78)
        Me.Thumbnail.TabIndex = 6
        Me.Thumbnail.TabStop = False
        '
        'FocalDistanceSingle
        '
        Me.FocalDistanceSingle.AutoSize = True
        Me.FocalDistanceSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FocalDistanceSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.FocalDistanceSingle.FormatStyle = "0.0###"
        Me.FocalDistanceSingle.IsReadOnly = False
        Me.FocalDistanceSingle.Label = "Single Value"
        Me.FocalDistanceSingle.Location = New System.Drawing.Point(225, 36)
        Me.FocalDistanceSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.FocalDistanceSingle.Name = "FocalDistanceSingle"
        Me.FocalDistanceSingle.ReadOnlyMsgBox = Nothing
        Me.FocalDistanceSingle.SiDefaultValue = 0!
        Me.FocalDistanceSingle.SiMin = -1.401298E-45!
        Me.FocalDistanceSingle.SiUnits = ""
        Me.FocalDistanceSingle.SiValue = 1.0!
        Me.FocalDistanceSingle.Size = New System.Drawing.Size(81, 31)
        Me.FocalDistanceSingle.TabIndex = 5
        Me.FocalDistanceSingle.UndoEnabled = True
        '
        'FdKey
        '
        Me.FdKey.AutoSize = True
        Me.FdKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FdKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FdKey.Location = New System.Drawing.Point(2, 36)
        Me.FdKey.Name = "FdKey"
        Me.FdKey.Size = New System.Drawing.Size(101, 17)
        Me.FdKey.TabIndex = 4
        Me.FdKey.Text = "Focal &Distance"
        Me.FdKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FdLabel
        '
        Me.FdLabel.AutoSize = True
        Me.FdLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FdLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FdLabel.Location = New System.Drawing.Point(203, 39)
        Me.FdLabel.Name = "FdLabel"
        Me.FdLabel.Size = New System.Drawing.Size(20, 17)
        Me.FdLabel.TabIndex = 7
        Me.FdLabel.Text = "2f"
        Me.FdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TwKey
        '
        Me.TwKey.AutoSize = True
        Me.TwKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TwKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TwKey.Location = New System.Drawing.Point(2, 87)
        Me.TwKey.Name = "TwKey"
        Me.TwKey.Size = New System.Drawing.Size(73, 17)
        Me.TwKey.TabIndex = 23
        Me.TwKey.Text = "Top Width"
        Me.TwKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ParabolaControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TwKey)
        Me.Controls.Add(Me.FdLabel)
        Me.Controls.Add(Me.Thumbnail)
        Me.Controls.Add(Me.FocalDistanceSingle)
        Me.Controls.Add(Me.FdKey)
        Me.Name = "ParabolaControl"
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Thumbnail As WinFlume.ctl_PictureBox
    Friend WithEvents FocalDistanceSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents FdKey As WinFlume.ctl_Label
    Friend WithEvents FdLabel As ctl_Label
    Friend WithEvents TwKey As ctl_Label
End Class
