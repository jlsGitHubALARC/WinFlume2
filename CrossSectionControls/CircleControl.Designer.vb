<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CircleControl
    Inherits WinFlume.CrossSectionControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DiameterSingle = New WinFlume.ctl_SingleUnits()
        Me.DiameterKey = New WinFlume.ctl_Label()
        Me.Thumbnail = New WinFlume.ctl_PictureBox()
        Me.TwKey = New WinFlume.ctl_Label()
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DiameterSingle
        '
        Me.DiameterSingle.AutoSize = True
        Me.DiameterSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DiameterSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DiameterSingle.FormatStyle = "0.0###"
        Me.DiameterSingle.IsReadOnly = False
        Me.DiameterSingle.Label = "Single Value"
        Me.DiameterSingle.Location = New System.Drawing.Point(225, 36)
        Me.DiameterSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.DiameterSingle.Name = "DiameterSingle"
        Me.DiameterSingle.ReadOnlyMsgBox = Nothing
        Me.DiameterSingle.SiDefaultValue = 0!
        Me.DiameterSingle.SiMin = -1.401298E-45!
        Me.DiameterSingle.SiUnits = ""
        Me.DiameterSingle.SiValue = 1.0!
        Me.DiameterSingle.Size = New System.Drawing.Size(81, 31)
        Me.DiameterSingle.TabIndex = 1
        Me.DiameterSingle.UndoEnabled = True
        '
        'DiameterKey
        '
        Me.DiameterKey.AutoSize = True
        Me.DiameterKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DiameterKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DiameterKey.Location = New System.Drawing.Point(2, 36)
        Me.DiameterKey.Name = "DiameterKey"
        Me.DiameterKey.Size = New System.Drawing.Size(65, 17)
        Me.DiameterKey.TabIndex = 0
        Me.DiameterKey.Text = "&Diameter"
        Me.DiameterKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Thumbnail
        '
        Me.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thumbnail.Image = Global.WinFlume.My.Resources.Resources.CIRC
        Me.Thumbnail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Thumbnail.Location = New System.Drawing.Point(5, 135)
        Me.Thumbnail.Name = "Thumbnail"
        Me.Thumbnail.Size = New System.Drawing.Size(103, 78)
        Me.Thumbnail.TabIndex = 3
        Me.Thumbnail.TabStop = False
        '
        'TwKey
        '
        Me.TwKey.AutoSize = True
        Me.TwKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TwKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TwKey.Location = New System.Drawing.Point(2, 87)
        Me.TwKey.Name = "TwKey"
        Me.TwKey.Size = New System.Drawing.Size(73, 17)
        Me.TwKey.TabIndex = 21
        Me.TwKey.Text = "Top Width"
        Me.TwKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CircleControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.TwKey)
        Me.Controls.Add(Me.Thumbnail)
        Me.Controls.Add(Me.DiameterSingle)
        Me.Controls.Add(Me.DiameterKey)
        Me.Name = "CircleControl"
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DiameterSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents DiameterKey As WinFlume.ctl_Label
    Friend WithEvents Thumbnail As WinFlume.ctl_PictureBox
    Friend WithEvents TwKey As ctl_Label
End Class
