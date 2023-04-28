<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SillInUShapedControl
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
        Me.D1Label = New WinFlume.ctl_Label()
        Me.SillHeightSingle = New WinFlume.ctl_SingleUnits()
        Me.D1Key = New WinFlume.ctl_Label()
        Me.Thumbnail = New WinFlume.ctl_PictureBox()
        Me.DiameterSingle = New WinFlume.ctl_SingleUnits()
        Me.DiameterKey = New WinFlume.ctl_Label()
        Me.DiaLabel = New WinFlume.ctl_Label()
        Me.CwKey = New WinFlume.ctl_Label()
        Me.TwKey = New WinFlume.ctl_Label()
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'D1Label
        '
        Me.D1Label.AutoSize = True
        Me.D1Label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.D1Label.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.D1Label.Location = New System.Drawing.Point(284, 129)
        Me.D1Label.Name = "D1Label"
        Me.D1Label.Size = New System.Drawing.Size(26, 17)
        Me.D1Label.TabIndex = 5
        Me.D1Label.Text = "D1"
        Me.D1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SillHeightSingle
        '
        Me.SillHeightSingle.AutoSize = True
        Me.SillHeightSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SillHeightSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.SillHeightSingle.FormatStyle = "0.0###"
        Me.SillHeightSingle.IsReadOnly = False
        Me.SillHeightSingle.Label = "Single Value"
        Me.SillHeightSingle.Location = New System.Drawing.Point(311, 126)
        Me.SillHeightSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.SillHeightSingle.Name = "SillHeightSingle"
        Me.SillHeightSingle.ReadOnlyMsgBox = Nothing
        Me.SillHeightSingle.SiDefaultValue = 0!
        Me.SillHeightSingle.SiMin = -1.401298E-45!
        Me.SillHeightSingle.SiUnits = ""
        Me.SillHeightSingle.SiValue = 1.0!
        Me.SillHeightSingle.Size = New System.Drawing.Size(81, 25)
        Me.SillHeightSingle.TabIndex = 4
        Me.SillHeightSingle.UndoEnabled = True
        '
        'D1Key
        '
        Me.D1Key.AutoSize = True
        Me.D1Key.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.D1Key.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.D1Key.Location = New System.Drawing.Point(2, 53)
        Me.D1Key.Name = "D1Key"
        Me.D1Key.Size = New System.Drawing.Size(107, 17)
        Me.D1Key.TabIndex = 3
        Me.D1Key.Text = "&Inner Sill Height"
        Me.D1Key.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Thumbnail
        '
        Me.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thumbnail.Image = Global.WinFlume.My.Resources.Resources.SILLU
        Me.Thumbnail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Thumbnail.InitialImage = Nothing
        Me.Thumbnail.Location = New System.Drawing.Point(5, 135)
        Me.Thumbnail.Name = "Thumbnail"
        Me.Thumbnail.Size = New System.Drawing.Size(103, 78)
        Me.Thumbnail.TabIndex = 17
        Me.Thumbnail.TabStop = False
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
        Me.DiameterSingle.Size = New System.Drawing.Size(80, 24)
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
        'DiaLabel
        '
        Me.DiaLabel.AutoSize = True
        Me.DiaLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DiaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DiaLabel.Location = New System.Drawing.Point(182, 39)
        Me.DiaLabel.Name = "DiaLabel"
        Me.DiaLabel.Size = New System.Drawing.Size(40, 17)
        Me.DiaLabel.TabIndex = 2
        Me.DiaLabel.Text = "Diam"
        Me.DiaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CwKey
        '
        Me.CwKey.AutoSize = True
        Me.CwKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CwKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CwKey.Location = New System.Drawing.Point(2, 104)
        Me.CwKey.Name = "CwKey"
        Me.CwKey.Size = New System.Drawing.Size(66, 17)
        Me.CwKey.TabIndex = 18
        Me.CwKey.Text = "Control Width"
        Me.CwKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TwKey
        '
        Me.TwKey.AutoSize = True
        Me.TwKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TwKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TwKey.Location = New System.Drawing.Point(2, 87)
        Me.TwKey.Name = "TwKey"
        Me.TwKey.Size = New System.Drawing.Size(73, 17)
        Me.TwKey.TabIndex = 19
        Me.TwKey.Text = "Top Width"
        Me.TwKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SillInUShapedControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TwKey)
        Me.Controls.Add(Me.CwKey)
        Me.Controls.Add(Me.DiaLabel)
        Me.Controls.Add(Me.D1Label)
        Me.Controls.Add(Me.SillHeightSingle)
        Me.Controls.Add(Me.D1Key)
        Me.Controls.Add(Me.Thumbnail)
        Me.Controls.Add(Me.DiameterSingle)
        Me.Controls.Add(Me.DiameterKey)
        Me.Name = "SillInUShapedControl"
        Me.Size = New System.Drawing.Size(438, 218)
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents D1Label As ctl_Label
    Friend WithEvents SillHeightSingle As ctl_SingleUnits
    Friend WithEvents D1Key As ctl_Label
    Friend WithEvents Thumbnail As ctl_PictureBox
    Friend WithEvents DiameterSingle As ctl_SingleUnits
    Friend WithEvents DiameterKey As ctl_Label
    Friend WithEvents DiaLabel As ctl_Label
    Friend WithEvents CwKey As ctl_Label
    Friend WithEvents TwKey As ctl_Label
End Class
