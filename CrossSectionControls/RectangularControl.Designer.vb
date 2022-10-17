<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RectangularControl
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
        Me.Thumbnail = New WinFlume.ctl_PictureBox()
        Me.BottomWidthSingle = New WinFlume.ctl_SingleUnits()
        Me.BwKey = New WinFlume.ctl_Label()
        Me.TwKey = New WinFlume.ctl_Label()
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Thumbnail
        '
        Me.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thumbnail.Image = Global.WinFlume.My.Resources.Resources.RECT
        Me.Thumbnail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Thumbnail.Location = New System.Drawing.Point(5, 135)
        Me.Thumbnail.Name = "Thumbnail"
        Me.Thumbnail.Size = New System.Drawing.Size(103, 78)
        Me.Thumbnail.TabIndex = 3
        Me.Thumbnail.TabStop = False
        '
        'BottomWidthSingle
        '
        Me.BottomWidthSingle.AutoSize = True
        Me.BottomWidthSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BottomWidthSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.BottomWidthSingle.FormatStyle = "0.0###"
        Me.BottomWidthSingle.IsReadOnly = False
        Me.BottomWidthSingle.Label = "Single Value"
        Me.BottomWidthSingle.Location = New System.Drawing.Point(252, 165)
        Me.BottomWidthSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.BottomWidthSingle.Name = "BottomWidthSingle"
        Me.BottomWidthSingle.ReadOnlyMsgBox = Nothing
        Me.BottomWidthSingle.SiDefaultValue = 0!
        Me.BottomWidthSingle.SiMin = -1.401298E-45!
        Me.BottomWidthSingle.SiUnits = "m"
        Me.BottomWidthSingle.SiValue = 0.3!
        Me.BottomWidthSingle.Size = New System.Drawing.Size(81, 31)
        Me.BottomWidthSingle.TabIndex = 1
        Me.BottomWidthSingle.UndoEnabled = True
        '
        'BwKey
        '
        Me.BwKey.AutoSize = True
        Me.BwKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BwKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BwKey.Location = New System.Drawing.Point(2, 2)
        Me.BwKey.Name = "BwKey"
        Me.BwKey.Size = New System.Drawing.Size(92, 17)
        Me.BwKey.TabIndex = 0
        Me.BwKey.Text = "&Bottom Width"
        Me.BwKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'RectangularControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TwKey)
        Me.Controls.Add(Me.Thumbnail)
        Me.Controls.Add(Me.BottomWidthSingle)
        Me.Controls.Add(Me.BwKey)
        Me.Name = "RectangularControl"
        Me.Size = New System.Drawing.Size(440, 218)
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BwKey As WinFlume.ctl_Label
    Friend WithEvents BottomWidthSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents Thumbnail As WinFlume.ctl_PictureBox
    Friend WithEvents TwKey As ctl_Label
End Class
