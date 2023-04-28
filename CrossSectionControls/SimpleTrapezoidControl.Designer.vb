<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SimpleTrapezoidControl
    Inherits WinFlume.CrossSectionControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimpleTrapezoidControl))
        Me.Z1Single = New WinFlume.ctl_Single()
        Me.Z1Key = New WinFlume.ctl_Label()
        Me.BottomWidthSingle = New WinFlume.ctl_SingleUnits()
        Me.BottomWidthKey = New WinFlume.ctl_Label()
        Me.Thumbnail = New WinFlume.ctl_PictureBox()
        Me.TwKey = New WinFlume.ctl_Label()
        Me.ControlWidthKey = New WinFlume.ctl_Label()
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Z1Single
        '
        resources.ApplyResources(Me.Z1Single, "Z1Single")
        Me.Z1Single.FormatStyle = "0.0###"
        Me.Z1Single.IsReadOnly = False
        Me.Z1Single.Label = "Single Value"
        Me.Z1Single.Name = "Z1Single"
        Me.Z1Single.ReadOnlyMsgBox = Nothing
        Me.Z1Single.SiDefaultValue = 0!
        Me.Z1Single.SiMin = -1.401298E-45!
        Me.Z1Single.SiValue = 1.0!
        Me.Z1Single.UiValue = 1.0!
        Me.Z1Single.UndoEnabled = True
        '
        'Z1Key
        '
        resources.ApplyResources(Me.Z1Key, "Z1Key")
        Me.Z1Key.Name = "Z1Key"
        '
        'BottomWidthSingle
        '
        resources.ApplyResources(Me.BottomWidthSingle, "BottomWidthSingle")
        Me.BottomWidthSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BottomWidthSingle.FormatStyle = "0.0###"
        Me.BottomWidthSingle.IsReadOnly = False
        Me.BottomWidthSingle.Label = "Single Value"
        Me.BottomWidthSingle.Name = "BottomWidthSingle"
        Me.BottomWidthSingle.ReadOnlyMsgBox = Nothing
        Me.BottomWidthSingle.SiDefaultValue = 0!
        Me.BottomWidthSingle.SiMin = -1.401298E-45!
        Me.BottomWidthSingle.SiUnits = "m"
        Me.BottomWidthSingle.SiValue = 0.3!
        Me.BottomWidthSingle.UndoEnabled = True
        '
        'BottomWidthKey
        '
        resources.ApplyResources(Me.BottomWidthKey, "BottomWidthKey")
        Me.BottomWidthKey.Name = "BottomWidthKey"
        '
        'Thumbnail
        '
        Me.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thumbnail.Image = Global.WinFlume.My.Resources.Resources.TRAP
        resources.ApplyResources(Me.Thumbnail, "Thumbnail")
        Me.Thumbnail.Name = "Thumbnail"
        Me.Thumbnail.TabStop = False
        '
        'TwKey
        '
        resources.ApplyResources(Me.TwKey, "TwKey")
        Me.TwKey.Name = "TwKey"
        '
        'ControlWidthKey
        '
        resources.ApplyResources(Me.ControlWidthKey, "ControlWidthKey")
        Me.ControlWidthKey.Name = "ControlWidthKey"
        '
        'SimpleTrapezoidControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.ControlWidthKey)
        Me.Controls.Add(Me.TwKey)
        Me.Controls.Add(Me.Z1Single)
        Me.Controls.Add(Me.Z1Key)
        Me.Controls.Add(Me.BottomWidthSingle)
        Me.Controls.Add(Me.BottomWidthKey)
        Me.Controls.Add(Me.Thumbnail)
        Me.Name = "SimpleTrapezoidControl"
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Thumbnail As WinFlume.ctl_PictureBox
    Friend WithEvents BottomWidthKey As WinFlume.ctl_Label
    Friend WithEvents BottomWidthSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents Z1Key As WinFlume.ctl_Label
    Friend WithEvents Z1Single As WinFlume.ctl_Single
    Friend WithEvents TwKey As ctl_Label
    Friend WithEvents ControlWidthKey As ctl_Label
End Class
