<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SillInParabolaControl
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
        Me.FocalDistanceSingle = New WinFlume.ctl_SingleUnits()
        Me.FdKey = New WinFlume.ctl_Label()
        Me.SillHeightSingle = New WinFlume.ctl_SingleUnits()
        Me.D1Key = New WinFlume.ctl_Label()
        Me.FdLabel = New WinFlume.ctl_Label()
        Me.D1Label = New WinFlume.ctl_Label()
        Me.CwKey = New WinFlume.ctl_Label()
        Me.TwKey = New WinFlume.ctl_Label()
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Thumbnail
        '
        Me.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thumbnail.Image = Global.WinFlume.My.Resources.Resources.SILLPARA
        Me.Thumbnail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Thumbnail.Location = New System.Drawing.Point(5, 135)
        Me.Thumbnail.Name = "Thumbnail"
        Me.Thumbnail.Size = New System.Drawing.Size(103, 78)
        Me.Thumbnail.TabIndex = 9
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
        Me.FocalDistanceSingle.Location = New System.Drawing.Point(225, 35)
        Me.FocalDistanceSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.FocalDistanceSingle.Name = "FocalDistanceSingle"
        Me.FocalDistanceSingle.ReadOnlyMsgBox = Nothing
        Me.FocalDistanceSingle.SiDefaultValue = 0!
        Me.FocalDistanceSingle.SiMin = -1.401298E-45!
        Me.FocalDistanceSingle.SiUnits = ""
        Me.FocalDistanceSingle.SiValue = 1.0!
        Me.FocalDistanceSingle.Size = New System.Drawing.Size(81, 31)
        Me.FocalDistanceSingle.TabIndex = 1
        Me.FocalDistanceSingle.UndoEnabled = True
        '
        'FdKey
        '
        Me.FdKey.AutoSize = True
        Me.FdKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FdKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FdKey.Location = New System.Drawing.Point(2, 35)
        Me.FdKey.Name = "FdKey"
        Me.FdKey.Size = New System.Drawing.Size(101, 17)
        Me.FdKey.TabIndex = 0
        Me.FdKey.Text = "Focal &Distance"
        Me.FdKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SillHeightSingle
        '
        Me.SillHeightSingle.AutoSize = True
        Me.SillHeightSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SillHeightSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.SillHeightSingle.FormatStyle = "0.0###"
        Me.SillHeightSingle.IsReadOnly = False
        Me.SillHeightSingle.Label = "Single Value"
        Me.SillHeightSingle.Location = New System.Drawing.Point(311, 125)
        Me.SillHeightSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.SillHeightSingle.Name = "SillHeightSingle"
        Me.SillHeightSingle.ReadOnlyMsgBox = Nothing
        Me.SillHeightSingle.SiDefaultValue = 0!
        Me.SillHeightSingle.SiMin = -1.401298E-45!
        Me.SillHeightSingle.SiUnits = ""
        Me.SillHeightSingle.SiValue = 1.0!
        Me.SillHeightSingle.Size = New System.Drawing.Size(81, 25)
        Me.SillHeightSingle.TabIndex = 3
        Me.SillHeightSingle.UndoEnabled = True
        '
        'D1Key
        '
        Me.D1Key.AutoSize = True
        Me.D1Key.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.D1Key.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.D1Key.Location = New System.Drawing.Point(2, 52)
        Me.D1Key.Name = "D1Key"
        Me.D1Key.Size = New System.Drawing.Size(107, 17)
        Me.D1Key.TabIndex = 2
        Me.D1Key.Text = "&Inner Sill Height"
        Me.D1Key.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FdLabel
        '
        Me.FdLabel.AutoSize = True
        Me.FdLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FdLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FdLabel.Location = New System.Drawing.Point(203, 38)
        Me.FdLabel.Name = "FdLabel"
        Me.FdLabel.Size = New System.Drawing.Size(20, 17)
        Me.FdLabel.TabIndex = 10
        Me.FdLabel.Text = "2f"
        Me.FdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'D1Label
        '
        Me.D1Label.AutoSize = True
        Me.D1Label.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.D1Label.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.D1Label.Location = New System.Drawing.Point(284, 128)
        Me.D1Label.Name = "D1Label"
        Me.D1Label.Size = New System.Drawing.Size(26, 17)
        Me.D1Label.TabIndex = 11
        Me.D1Label.Text = "D1"
        Me.D1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CwKey
        '
        Me.CwKey.AutoSize = True
        Me.CwKey.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CwKey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CwKey.Location = New System.Drawing.Point(2, 104)
        Me.CwKey.Name = "CwKey"
        Me.CwKey.Size = New System.Drawing.Size(66, 17)
        Me.CwKey.TabIndex = 12
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
        Me.TwKey.TabIndex = 23
        Me.TwKey.Text = "Top Width"
        Me.TwKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SillInParabolaControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TwKey)
        Me.Controls.Add(Me.CwKey)
        Me.Controls.Add(Me.D1Label)
        Me.Controls.Add(Me.FdLabel)
        Me.Controls.Add(Me.SillHeightSingle)
        Me.Controls.Add(Me.D1Key)
        Me.Controls.Add(Me.Thumbnail)
        Me.Controls.Add(Me.FocalDistanceSingle)
        Me.Controls.Add(Me.FdKey)
        Me.Name = "SillInParabolaControl"
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Thumbnail As ctl_PictureBox
    Friend WithEvents FocalDistanceSingle As ctl_SingleUnits
    Friend WithEvents FdKey As ctl_Label
    Friend WithEvents SillHeightSingle As ctl_SingleUnits
    Friend WithEvents D1Key As ctl_Label
    Friend WithEvents FdLabel As ctl_Label
    Friend WithEvents D1Label As ctl_Label
    Friend WithEvents CwKey As ctl_Label
    Friend WithEvents TwKey As ctl_Label
End Class
