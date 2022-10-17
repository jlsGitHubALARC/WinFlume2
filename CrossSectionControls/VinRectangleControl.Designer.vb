<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VinRectangleControl
    Inherits CrossSectionControl

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
        Me.BottomWidthSingle = New WinFlume.ctl_SingleUnits()
        Me.BwKey = New WinFlume.ctl_Label()
        Me.Z1Key = New WinFlume.ctl_Label()
        Me.Z1Single = New WinFlume.ctl_Single()
        Me.D1Key = New WinFlume.ctl_Label()
        Me.SillHeightSingle = New WinFlume.ctl_SingleUnits()
        Me.TwKey = New WinFlume.ctl_Label()
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Thumbnail
        '
        Me.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thumbnail.Image = Global.WinFlume.My.Resources.Resources.VRECT
        Me.Thumbnail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Thumbnail.Location = New System.Drawing.Point(5, 135)
        Me.Thumbnail.Name = "Thumbnail"
        Me.Thumbnail.Size = New System.Drawing.Size(103, 78)
        Me.Thumbnail.TabIndex = 6
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
        Me.BottomWidthSingle.TabIndex = 5
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
        Me.BwKey.TabIndex = 4
        Me.BwKey.Text = "&Bottom Width"
        Me.BwKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Z1Key
        '
        Me.Z1Key.AutoSize = True
        Me.Z1Key.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Z1Key.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Z1Key.Location = New System.Drawing.Point(2, 19)
        Me.Z1Key.Name = "Z1Key"
        Me.Z1Key.Size = New System.Drawing.Size(25, 17)
        Me.Z1Key.TabIndex = 8
        Me.Z1Key.Text = "&Z1"
        Me.Z1Key.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.Z1Single.TabIndex = 9
        Me.Z1Single.UiValue = 1.0!
        Me.Z1Single.UndoEnabled = True
        '
        'D1Key
        '
        Me.D1Key.AutoSize = True
        Me.D1Key.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.D1Key.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.D1Key.Location = New System.Drawing.Point(2, 36)
        Me.D1Key.Name = "D1Key"
        Me.D1Key.Size = New System.Drawing.Size(107, 17)
        Me.D1Key.TabIndex = 10
        Me.D1Key.Text = "&Inner Sill Height"
        Me.D1Key.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SillHeightSingle
        '
        Me.SillHeightSingle.AutoSize = True
        Me.SillHeightSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SillHeightSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.SillHeightSingle.FormatStyle = "0.0###"
        Me.SillHeightSingle.IsReadOnly = False
        Me.SillHeightSingle.Label = "Single Value"
        Me.SillHeightSingle.Location = New System.Drawing.Point(355, 113)
        Me.SillHeightSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.SillHeightSingle.Name = "SillHeightSingle"
        Me.SillHeightSingle.ReadOnlyMsgBox = Nothing
        Me.SillHeightSingle.SiDefaultValue = 0!
        Me.SillHeightSingle.SiMin = -1.401298E-45!
        Me.SillHeightSingle.SiUnits = "m"
        Me.SillHeightSingle.SiValue = 0.3!
        Me.SillHeightSingle.Size = New System.Drawing.Size(81, 31)
        Me.SillHeightSingle.TabIndex = 11
        Me.SillHeightSingle.UndoEnabled = True
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
        'VinRectangleControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TwKey)
        Me.Controls.Add(Me.SillHeightSingle)
        Me.Controls.Add(Me.D1Key)
        Me.Controls.Add(Me.Z1Single)
        Me.Controls.Add(Me.Z1Key)
        Me.Controls.Add(Me.Thumbnail)
        Me.Controls.Add(Me.BottomWidthSingle)
        Me.Controls.Add(Me.BwKey)
        Me.Name = "VinRectangleControl"
        Me.Size = New System.Drawing.Size(440, 218)
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Thumbnail As ctl_PictureBox
    Friend WithEvents BottomWidthSingle As ctl_SingleUnits
    Friend WithEvents BwKey As ctl_Label
    Friend WithEvents Z1Key As ctl_Label
    Friend WithEvents Z1Single As ctl_Single
    Friend WithEvents D1Key As ctl_Label
    Friend WithEvents SillHeightSingle As ctl_SingleUnits
    Friend WithEvents TwKey As ctl_Label
End Class
