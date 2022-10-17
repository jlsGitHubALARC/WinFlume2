<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComplexTrapezoidControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComplexTrapezoidControl))
        Me.Z1Single = New WinFlume.ctl_Single()
        Me.Z1Key = New WinFlume.ctl_Label()
        Me.BinSingle = New WinFlume.ctl_SingleUnits()
        Me.BinKey = New WinFlume.ctl_Label()
        Me.Thumbnail = New WinFlume.ctl_PictureBox()
        Me.Z2Key = New WinFlume.ctl_Label()
        Me.Z2Single = New WinFlume.ctl_Single()
        Me.D1Key = New WinFlume.ctl_Label()
        Me.D1Label = New WinFlume.ctl_Label()
        Me.D1Single = New WinFlume.ctl_SingleUnits()
        Me.Z1Label = New WinFlume.ctl_Label()
        Me.Z2Label = New WinFlume.ctl_Label()
        Me.D2Key = New WinFlume.ctl_Label()
        Me.Z3Key = New WinFlume.ctl_Label()
        Me.BoutKey = New WinFlume.ctl_Label()
        Me.D2Label = New WinFlume.ctl_Label()
        Me.D2Single = New WinFlume.ctl_SingleUnits()
        Me.BoutSingle = New WinFlume.ctl_SingleUnits()
        Me.Z3Label = New WinFlume.ctl_Label()
        Me.Z3Single = New WinFlume.ctl_Single()
        Me.EditInnerCheckBox = New WinFlume.ctl_CheckBox()
        Me.EditOuterCheckBox = New WinFlume.ctl_CheckBox()
        Me.BinLabel = New WinFlume.ctl_Label()
        Me.BoutLabel = New WinFlume.ctl_Label()
        Me.TwKey = New WinFlume.ctl_Label()
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
        'BinSingle
        '
        resources.ApplyResources(Me.BinSingle, "BinSingle")
        Me.BinSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BinSingle.FormatStyle = "0.0###"
        Me.BinSingle.IsReadOnly = False
        Me.BinSingle.Label = "Single Value"
        Me.BinSingle.Name = "BinSingle"
        Me.BinSingle.ReadOnlyMsgBox = Nothing
        Me.BinSingle.SiDefaultValue = 0!
        Me.BinSingle.SiMin = -1.401298E-45!
        Me.BinSingle.SiUnits = "m"
        Me.BinSingle.SiValue = 0.3!
        Me.BinSingle.UndoEnabled = True
        '
        'BinKey
        '
        resources.ApplyResources(Me.BinKey, "BinKey")
        Me.BinKey.Name = "BinKey"
        '
        'Thumbnail
        '
        Me.Thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Thumbnail.Image = Global.WinFlume.My.Resources.Resources.CTRAP
        resources.ApplyResources(Me.Thumbnail, "Thumbnail")
        Me.Thumbnail.Name = "Thumbnail"
        Me.Thumbnail.TabStop = False
        '
        'Z2Key
        '
        resources.ApplyResources(Me.Z2Key, "Z2Key")
        Me.Z2Key.Name = "Z2Key"
        '
        'Z2Single
        '
        resources.ApplyResources(Me.Z2Single, "Z2Single")
        Me.Z2Single.FormatStyle = "0.0###"
        Me.Z2Single.IsReadOnly = False
        Me.Z2Single.Label = "Single Value"
        Me.Z2Single.Name = "Z2Single"
        Me.Z2Single.ReadOnlyMsgBox = Nothing
        Me.Z2Single.SiDefaultValue = 0!
        Me.Z2Single.SiMin = -1.401298E-45!
        Me.Z2Single.SiValue = 1.0!
        Me.Z2Single.UiValue = 1.0!
        Me.Z2Single.UndoEnabled = True
        '
        'D1Key
        '
        resources.ApplyResources(Me.D1Key, "D1Key")
        Me.D1Key.Name = "D1Key"
        '
        'D1Label
        '
        resources.ApplyResources(Me.D1Label, "D1Label")
        Me.D1Label.Name = "D1Label"
        '
        'D1Single
        '
        resources.ApplyResources(Me.D1Single, "D1Single")
        Me.D1Single.BackColor = System.Drawing.SystemColors.ControlLight
        Me.D1Single.FormatStyle = "0.0###"
        Me.D1Single.IsReadOnly = False
        Me.D1Single.Label = "Single Value"
        Me.D1Single.Name = "D1Single"
        Me.D1Single.ReadOnlyMsgBox = Nothing
        Me.D1Single.SiDefaultValue = 0!
        Me.D1Single.SiMin = -1.401298E-45!
        Me.D1Single.SiUnits = ""
        Me.D1Single.SiValue = 1.0!
        Me.D1Single.UndoEnabled = True
        '
        'Z1Label
        '
        resources.ApplyResources(Me.Z1Label, "Z1Label")
        Me.Z1Label.Name = "Z1Label"
        '
        'Z2Label
        '
        resources.ApplyResources(Me.Z2Label, "Z2Label")
        Me.Z2Label.Name = "Z2Label"
        '
        'D2Key
        '
        resources.ApplyResources(Me.D2Key, "D2Key")
        Me.D2Key.Name = "D2Key"
        '
        'Z3Key
        '
        resources.ApplyResources(Me.Z3Key, "Z3Key")
        Me.Z3Key.Name = "Z3Key"
        '
        'BoutKey
        '
        resources.ApplyResources(Me.BoutKey, "BoutKey")
        Me.BoutKey.Name = "BoutKey"
        '
        'D2Label
        '
        resources.ApplyResources(Me.D2Label, "D2Label")
        Me.D2Label.Name = "D2Label"
        '
        'D2Single
        '
        resources.ApplyResources(Me.D2Single, "D2Single")
        Me.D2Single.BackColor = System.Drawing.SystemColors.ControlLight
        Me.D2Single.FormatStyle = "0.0###"
        Me.D2Single.IsReadOnly = False
        Me.D2Single.Label = "Single Value"
        Me.D2Single.Name = "D2Single"
        Me.D2Single.ReadOnlyMsgBox = Nothing
        Me.D2Single.SiDefaultValue = 0!
        Me.D2Single.SiMin = -1.401298E-45!
        Me.D2Single.SiUnits = ""
        Me.D2Single.SiValue = 1.0!
        Me.D2Single.UndoEnabled = True
        '
        'BoutSingle
        '
        resources.ApplyResources(Me.BoutSingle, "BoutSingle")
        Me.BoutSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BoutSingle.FormatStyle = "0.0###"
        Me.BoutSingle.IsReadOnly = False
        Me.BoutSingle.Label = "Single Value"
        Me.BoutSingle.Name = "BoutSingle"
        Me.BoutSingle.ReadOnlyMsgBox = Nothing
        Me.BoutSingle.SiDefaultValue = 0!
        Me.BoutSingle.SiMin = -1.401298E-45!
        Me.BoutSingle.SiUnits = "m"
        Me.BoutSingle.SiValue = 0.3!
        Me.BoutSingle.UndoEnabled = True
        '
        'Z3Label
        '
        resources.ApplyResources(Me.Z3Label, "Z3Label")
        Me.Z3Label.Name = "Z3Label"
        '
        'Z3Single
        '
        resources.ApplyResources(Me.Z3Single, "Z3Single")
        Me.Z3Single.FormatStyle = "0.0###"
        Me.Z3Single.IsReadOnly = False
        Me.Z3Single.Label = "Single Value"
        Me.Z3Single.Name = "Z3Single"
        Me.Z3Single.ReadOnlyMsgBox = Nothing
        Me.Z3Single.SiDefaultValue = 0!
        Me.Z3Single.SiMin = -1.401298E-45!
        Me.Z3Single.SiValue = 1.0!
        Me.Z3Single.UiValue = 1.0!
        Me.Z3Single.UndoEnabled = True
        '
        'EditInnerCheckBox
        '
        resources.ApplyResources(Me.EditInnerCheckBox, "EditInnerCheckBox")
        Me.EditInnerCheckBox.Checked = True
        Me.EditInnerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EditInnerCheckBox.HandleCheckedChanged = True
        Me.EditInnerCheckBox.Name = "EditInnerCheckBox"
        Me.EditInnerCheckBox.UndoEnabled = True
        Me.EditInnerCheckBox.UseVisualStyleBackColor = True
        Me.EditInnerCheckBox.Value = True
        '
        'EditOuterCheckBox
        '
        resources.ApplyResources(Me.EditOuterCheckBox, "EditOuterCheckBox")
        Me.EditOuterCheckBox.Checked = True
        Me.EditOuterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EditOuterCheckBox.HandleCheckedChanged = True
        Me.EditOuterCheckBox.Name = "EditOuterCheckBox"
        Me.EditOuterCheckBox.UndoEnabled = True
        Me.EditOuterCheckBox.UseVisualStyleBackColor = True
        Me.EditOuterCheckBox.Value = True
        '
        'BinLabel
        '
        resources.ApplyResources(Me.BinLabel, "BinLabel")
        Me.BinLabel.Name = "BinLabel"
        '
        'BoutLabel
        '
        resources.ApplyResources(Me.BoutLabel, "BoutLabel")
        Me.BoutLabel.Name = "BoutLabel"
        '
        'TwKey
        '
        resources.ApplyResources(Me.TwKey, "TwKey")
        Me.TwKey.Name = "TwKey"
        '
        'ComplexTrapezoidControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TwKey)
        Me.Controls.Add(Me.BoutLabel)
        Me.Controls.Add(Me.BinLabel)
        Me.Controls.Add(Me.EditOuterCheckBox)
        Me.Controls.Add(Me.EditInnerCheckBox)
        Me.Controls.Add(Me.Z3Label)
        Me.Controls.Add(Me.Z3Single)
        Me.Controls.Add(Me.BoutSingle)
        Me.Controls.Add(Me.D2Label)
        Me.Controls.Add(Me.D2Single)
        Me.Controls.Add(Me.D2Key)
        Me.Controls.Add(Me.Z3Key)
        Me.Controls.Add(Me.BoutKey)
        Me.Controls.Add(Me.Z2Label)
        Me.Controls.Add(Me.Z1Label)
        Me.Controls.Add(Me.D1Label)
        Me.Controls.Add(Me.D1Single)
        Me.Controls.Add(Me.D1Key)
        Me.Controls.Add(Me.Z2Single)
        Me.Controls.Add(Me.Z2Key)
        Me.Controls.Add(Me.Z1Single)
        Me.Controls.Add(Me.Z1Key)
        Me.Controls.Add(Me.BinSingle)
        Me.Controls.Add(Me.BinKey)
        Me.Controls.Add(Me.Thumbnail)
        Me.Name = "ComplexTrapezoidControl"
        CType(Me.Thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Z1Single As ctl_Single
    Friend WithEvents Z1Key As ctl_Label
    Friend WithEvents BinSingle As ctl_SingleUnits
    Friend WithEvents BinKey As ctl_Label
    Friend WithEvents Thumbnail As ctl_PictureBox
    Friend WithEvents Z2Key As ctl_Label
    Friend WithEvents Z2Single As ctl_Single
    Friend WithEvents D1Key As ctl_Label
    Friend WithEvents D1Label As ctl_Label
    Friend WithEvents D1Single As ctl_SingleUnits
    Friend WithEvents Z1Label As ctl_Label
    Friend WithEvents Z2Label As ctl_Label
    Friend WithEvents D2Key As ctl_Label
    Friend WithEvents Z3Key As ctl_Label
    Friend WithEvents BoutKey As ctl_Label
    Friend WithEvents D2Label As ctl_Label
    Friend WithEvents D2Single As ctl_SingleUnits
    Friend WithEvents BoutSingle As ctl_SingleUnits
    Friend WithEvents Z3Label As ctl_Label
    Friend WithEvents Z3Single As ctl_Single
    Friend WithEvents EditInnerCheckBox As ctl_CheckBox
    Friend WithEvents EditOuterCheckBox As ctl_CheckBox
    Friend WithEvents BinLabel As ctl_Label
    Friend WithEvents BoutLabel As ctl_Label
    Friend WithEvents TwKey As ctl_Label
End Class
