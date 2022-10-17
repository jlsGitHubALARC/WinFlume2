<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrapezoidInRectangleControl
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
        Me.TwKey = New WinFlume.ctl_Label()
        Me.Z1Single = New WinFlume.ctl_Single()
        Me.Z1Key = New WinFlume.ctl_Label()
        Me.BottomWidthSingle = New WinFlume.ctl_SingleUnits()
        Me.BottomWidthKey = New WinFlume.ctl_Label()
        Me.Thumbnail = New WinFlume.ctl_PictureBox()
        Me.D1Label = New WinFlume.ctl_Label()
        Me.D1Single = New WinFlume.ctl_SingleUnits()
        Me.D1Key = New WinFlume.ctl_Label()
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TwKey
        '
        Me.TwKey.AutoSize = True
        Me.TwKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TwKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TwKey.Location = New System.Drawing.Point(2, 87)
        Me.TwKey.Name = "TwKey"
        Me.TwKey.Size = New System.Drawing.Size(73, 17)
        Me.TwKey.TabIndex = 26
        Me.TwKey.Text = "Top Width"
        Me.TwKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Z1Single
        '
        Me.Z1Single.AutoSize = True
        Me.Z1Single.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Z1Single.FormatStyle = "0.0###"
        Me.Z1Single.IsReadOnly = False
        Me.Z1Single.Label = "Single Value"
        Me.Z1Single.Location = New System.Drawing.Point(320, 75)
        Me.Z1Single.Margin = New System.Windows.Forms.Padding(4)
        Me.Z1Single.Name = "Z1Single"
        Me.Z1Single.ReadOnlyMsgBox = Nothing
        Me.Z1Single.SiDefaultValue = 0!
        Me.Z1Single.SiMin = -1.401298E-45!
        Me.Z1Single.SiValue = 1.0!
        Me.Z1Single.Size = New System.Drawing.Size(63, 31)
        Me.Z1Single.TabIndex = 25
        Me.Z1Single.UiValue = 1.0!
        Me.Z1Single.UndoEnabled = True
        '
        'Z1Key
        '
        Me.Z1Key.AutoSize = True
        Me.Z1Key.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Z1Key.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Z1Key.Location = New System.Drawing.Point(2, 19)
        Me.Z1Key.Name = "Z1Key"
        Me.Z1Key.Size = New System.Drawing.Size(25, 17)
        Me.Z1Key.TabIndex = 23
        Me.Z1Key.Text = "&Z1"
        Me.Z1Key.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.BottomWidthSingle.TabIndex = 22
        Me.BottomWidthSingle.UndoEnabled = True
        '
        'BottomWidthKey
        '
        Me.BottomWidthKey.AutoSize = True
        Me.BottomWidthKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BottomWidthKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BottomWidthKey.Location = New System.Drawing.Point(2, 2)
        Me.BottomWidthKey.Name = "BottomWidthKey"
        Me.BottomWidthKey.Size = New System.Drawing.Size(92, 17)
        Me.BottomWidthKey.TabIndex = 21
        Me.BottomWidthKey.Text = "&Bottom Width"
        Me.BottomWidthKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Thumbnail
        '
        Me.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thumbnail.Image = Global.WinFlume.My.Resources.Resources.TRAPRECT
        Me.Thumbnail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Thumbnail.Location = New System.Drawing.Point(5, 135)
        Me.Thumbnail.Name = "Thumbnail"
        Me.Thumbnail.Size = New System.Drawing.Size(103, 78)
        Me.Thumbnail.TabIndex = 24
        Me.Thumbnail.TabStop = False
        '
        'D1Label
        '
        Me.D1Label.AutoSize = True
        Me.D1Label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.D1Label.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.D1Label.Location = New System.Drawing.Point(256, 126)
        Me.D1Label.Name = "D1Label"
        Me.D1Label.Size = New System.Drawing.Size(26, 17)
        Me.D1Label.TabIndex = 28
        Me.D1Label.Text = "D1"
        Me.D1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'D1Single
        '
        Me.D1Single.AutoSize = True
        Me.D1Single.BackColor = System.Drawing.SystemColors.ControlLight
        Me.D1Single.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.D1Single.FormatStyle = "0.0###"
        Me.D1Single.IsReadOnly = False
        Me.D1Single.Label = "Single Value"
        Me.D1Single.Location = New System.Drawing.Point(283, 123)
        Me.D1Single.Margin = New System.Windows.Forms.Padding(4)
        Me.D1Single.Name = "D1Single"
        Me.D1Single.ReadOnlyMsgBox = Nothing
        Me.D1Single.SiDefaultValue = 0!
        Me.D1Single.SiMin = -1.401298E-45!
        Me.D1Single.SiUnits = ""
        Me.D1Single.SiValue = 1.0!
        Me.D1Single.Size = New System.Drawing.Size(81, 25)
        Me.D1Single.TabIndex = 27
        Me.D1Single.UndoEnabled = True
        '
        'D1Key
        '
        Me.D1Key.AutoSize = True
        Me.D1Key.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.D1Key.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.D1Key.Location = New System.Drawing.Point(2, 52)
        Me.D1Key.Name = "D1Key"
        Me.D1Key.Size = New System.Drawing.Size(107, 17)
        Me.D1Key.TabIndex = 29
        Me.D1Key.Text = "&Inner Sill Height"
        Me.D1Key.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TrapezoidInRectangleControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Controls.Add(Me.D1Key)
        Me.Controls.Add(Me.D1Label)
        Me.Controls.Add(Me.D1Single)
        Me.Controls.Add(Me.TwKey)
        Me.Controls.Add(Me.Z1Single)
        Me.Controls.Add(Me.Z1Key)
        Me.Controls.Add(Me.BottomWidthSingle)
        Me.Controls.Add(Me.BottomWidthKey)
        Me.Controls.Add(Me.Thumbnail)
        Me.Name = "TrapezoidInRectangleControl"
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TwKey As ctl_Label
    Friend WithEvents Z1Single As ctl_Single
    Friend WithEvents Z1Key As ctl_Label
    Friend WithEvents BottomWidthSingle As ctl_SingleUnits
    Friend WithEvents BottomWidthKey As ctl_Label
    Friend WithEvents Thumbnail As ctl_PictureBox
    Friend WithEvents D1Label As ctl_Label
    Friend WithEvents D1Single As ctl_SingleUnits
    Friend WithEvents D1Key As ctl_Label
End Class
