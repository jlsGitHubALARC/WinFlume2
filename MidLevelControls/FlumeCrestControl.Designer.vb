<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FlumeCrestControl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FlumeCrestControl))
        Me.FlumeConstructionMaterialGroup = New WinFlume.ctl_GroupBox()
        Me.CustomRoughnessHeight = New WinFlume.ctl_Single6Units()
        Me.StandardRoughnessHeight = New WinFlume.ctl_Single6Units()
        Me.CustomMaterialTextBox = New WinFlume.ctl_TextBox()
        Me.CustomButton = New WinFlume.ctl_RadioButton()
        Me.StandardButton = New WinFlume.ctl_RadioButton()
        Me.StandardMaterialComboBox = New WinFlume.ctl_ComboBox()
        Me.RoughnessHeightLabel = New WinFlume.ctl_Label()
        Me.MovableCrestButton = New WinFlume.ctl_RadioButton()
        Me.StationaryCrestButton = New WinFlume.ctl_RadioButton()
        Me.CrestTypeGroup = New WinFlume.ctl_GroupBox()
        Me.FlumeConstructionMaterialGroup.SuspendLayout()
        Me.CrestTypeGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlumeConstructionMaterialGroup
        '
        Me.FlumeConstructionMaterialGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FlumeConstructionMaterialGroup.Controls.Add(Me.CustomRoughnessHeight)
        Me.FlumeConstructionMaterialGroup.Controls.Add(Me.StandardRoughnessHeight)
        Me.FlumeConstructionMaterialGroup.Controls.Add(Me.CustomMaterialTextBox)
        Me.FlumeConstructionMaterialGroup.Controls.Add(Me.CustomButton)
        Me.FlumeConstructionMaterialGroup.Controls.Add(Me.StandardButton)
        Me.FlumeConstructionMaterialGroup.Controls.Add(Me.StandardMaterialComboBox)
        Me.FlumeConstructionMaterialGroup.Controls.Add(Me.RoughnessHeightLabel)
        resources.ApplyResources(Me.FlumeConstructionMaterialGroup, "FlumeConstructionMaterialGroup")
        Me.FlumeConstructionMaterialGroup.Name = "FlumeConstructionMaterialGroup"
        Me.FlumeConstructionMaterialGroup.TabStop = False
        '
        'CustomRoughnessHeight
        '
        resources.ApplyResources(Me.CustomRoughnessHeight, "CustomRoughnessHeight")
        Me.CustomRoughnessHeight.FormatStyle = "0.0#####"
        Me.CustomRoughnessHeight.IsReadOnly = False
        Me.CustomRoughnessHeight.Label = "Single Value"
        Me.CustomRoughnessHeight.Name = "CustomRoughnessHeight"
        Me.CustomRoughnessHeight.ReadOnlyMsgBox = Nothing
        Me.CustomRoughnessHeight.SiDefaultValue = 0!
        Me.CustomRoughnessHeight.SiMin = -1.401298E-45!
        Me.CustomRoughnessHeight.SiUnits = "m"
        Me.CustomRoughnessHeight.SiValue = 0!
        Me.CustomRoughnessHeight.UndoEnabled = True
        '
        'StandardRoughnessHeight
        '
        resources.ApplyResources(Me.StandardRoughnessHeight, "StandardRoughnessHeight")
        Me.StandardRoughnessHeight.FormatStyle = "0.0#####"
        Me.StandardRoughnessHeight.IsReadOnly = False
        Me.StandardRoughnessHeight.Label = "Single Value"
        Me.StandardRoughnessHeight.Name = "StandardRoughnessHeight"
        Me.StandardRoughnessHeight.ReadOnlyMsgBox = Nothing
        Me.StandardRoughnessHeight.SiDefaultValue = 0!
        Me.StandardRoughnessHeight.SiMin = -1.401298E-45!
        Me.StandardRoughnessHeight.SiUnits = "m"
        Me.StandardRoughnessHeight.SiValue = 0!
        Me.StandardRoughnessHeight.UndoEnabled = True
        '
        'CustomMaterialTextBox
        '
        resources.ApplyResources(Me.CustomMaterialTextBox, "CustomMaterialTextBox")
        Me.CustomMaterialTextBox.Label = ""
        Me.CustomMaterialTextBox.Name = "CustomMaterialTextBox"
        Me.CustomMaterialTextBox.Value = ""
        '
        'CustomButton
        '
        resources.ApplyResources(Me.CustomButton, "CustomButton")
        Me.CustomButton.Label = ""
        Me.CustomButton.Name = "CustomButton"
        Me.CustomButton.RbValue = -1
        Me.CustomButton.UiValue = -1
        Me.CustomButton.UseVisualStyleBackColor = True
        '
        'StandardButton
        '
        resources.ApplyResources(Me.StandardButton, "StandardButton")
        Me.StandardButton.Checked = True
        Me.StandardButton.Label = ""
        Me.StandardButton.Name = "StandardButton"
        Me.StandardButton.RbValue = -1
        Me.StandardButton.TabStop = True
        Me.StandardButton.UiValue = -1
        Me.StandardButton.UseVisualStyleBackColor = True
        '
        'StandardMaterialComboBox
        '
        Me.StandardMaterialComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.StandardMaterialComboBox.DefaultValue = 0
        Me.StandardMaterialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.StandardMaterialComboBox, "StandardMaterialComboBox")
        Me.StandardMaterialComboBox.FormattingEnabled = True
        Me.StandardMaterialComboBox.Name = "StandardMaterialComboBox"
        Me.StandardMaterialComboBox.UndoEnabled = True
        Me.StandardMaterialComboBox.Value = -1
        '
        'RoughnessHeightLabel
        '
        resources.ApplyResources(Me.RoughnessHeightLabel, "RoughnessHeightLabel")
        Me.RoughnessHeightLabel.Name = "RoughnessHeightLabel"
        '
        'MovableCrestButton
        '
        resources.ApplyResources(Me.MovableCrestButton, "MovableCrestButton")
        Me.MovableCrestButton.Label = ""
        Me.MovableCrestButton.Name = "MovableCrestButton"
        Me.MovableCrestButton.RbValue = -1
        Me.MovableCrestButton.UiValue = -1
        Me.MovableCrestButton.UseVisualStyleBackColor = True
        '
        'StationaryCrestButton
        '
        resources.ApplyResources(Me.StationaryCrestButton, "StationaryCrestButton")
        Me.StationaryCrestButton.Checked = True
        Me.StationaryCrestButton.Label = ""
        Me.StationaryCrestButton.Name = "StationaryCrestButton"
        Me.StationaryCrestButton.RbValue = -1
        Me.StationaryCrestButton.TabStop = True
        Me.StationaryCrestButton.UiValue = -1
        Me.StationaryCrestButton.UseVisualStyleBackColor = True
        '
        'CrestTypeGroup
        '
        Me.CrestTypeGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CrestTypeGroup.Controls.Add(Me.MovableCrestButton)
        Me.CrestTypeGroup.Controls.Add(Me.StationaryCrestButton)
        resources.ApplyResources(Me.CrestTypeGroup, "CrestTypeGroup")
        Me.CrestTypeGroup.Name = "CrestTypeGroup"
        Me.CrestTypeGroup.TabStop = False
        '
        'FlumeCrestControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.CrestTypeGroup)
        Me.Controls.Add(Me.FlumeConstructionMaterialGroup)
        Me.Name = "FlumeCrestControl"
        Me.FlumeConstructionMaterialGroup.ResumeLayout(False)
        Me.FlumeConstructionMaterialGroup.PerformLayout()
        Me.CrestTypeGroup.ResumeLayout(False)
        Me.CrestTypeGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StationaryCrestButton As WinFlume.ctl_RadioButton
    Friend WithEvents MovableCrestButton As WinFlume.ctl_RadioButton
    Friend WithEvents StandardMaterialComboBox As WinFlume.ctl_ComboBox
    Friend WithEvents RoughnessHeightLabel As WinFlume.ctl_Label
    Friend WithEvents FlumeConstructionMaterialGroup As WinFlume.ctl_GroupBox
    Friend WithEvents CustomButton As WinFlume.ctl_RadioButton
    Friend WithEvents StandardButton As WinFlume.ctl_RadioButton
    Friend WithEvents CustomMaterialTextBox As WinFlume.ctl_TextBox
    Friend WithEvents StandardRoughnessHeight As WinFlume.ctl_Single6Units
    Friend WithEvents CustomRoughnessHeight As WinFlume.ctl_Single6Units
    Friend WithEvents CrestTypeGroup As ctl_GroupBox
End Class
