<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DitchridersTableControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DitchridersTableControl))
        Me.DataPanel = New WinFlume.ctl_Panel()
        Me.StatusPanel = New WinFlume.ctl_StatusPanel()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.ViewAsDialogButton = New WinFlume.ctl_Button()
        Me.TableCaption = New WinFlume.ctl_Label()
        Me.ColumnIncrement = New WinFlume.ctl_Precision()
        Me.ShowSlopeDistsCheckBox = New WinFlume.ctl_CheckBox()
        Me.Z_Label = New WinFlume.ctl_Label()
        Me.GageSlopeSingle = New WinFlume.ctl_Single()
        Me.ColumnIncrementLabel = New WinFlume.ctl_Label()
        Me.MaximumHeadSingle = New WinFlume.ctl_SingleUnits()
        Me.MaximumHeadLabel = New WinFlume.ctl_Label()
        Me.MinimumHeadSingle = New WinFlume.ctl_SingleUnits()
        Me.MinimumHeadLabel = New WinFlume.ctl_Label()
        Me.ControlPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataPanel
        '
        resources.ApplyResources(Me.DataPanel, "DataPanel")
        Me.DataPanel.Name = "DataPanel"
        '
        'StatusPanel
        '
        Me.StatusPanel.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.StatusPanel, "StatusPanel")
        Me.StatusPanel.Name = "StatusPanel"
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.ViewAsDialogButton)
        Me.ControlPanel.Controls.Add(Me.TableCaption)
        Me.ControlPanel.Controls.Add(Me.ColumnIncrement)
        Me.ControlPanel.Controls.Add(Me.ShowSlopeDistsCheckBox)
        Me.ControlPanel.Controls.Add(Me.Z_Label)
        Me.ControlPanel.Controls.Add(Me.GageSlopeSingle)
        Me.ControlPanel.Controls.Add(Me.ColumnIncrementLabel)
        Me.ControlPanel.Controls.Add(Me.MaximumHeadSingle)
        Me.ControlPanel.Controls.Add(Me.MaximumHeadLabel)
        Me.ControlPanel.Controls.Add(Me.MinimumHeadSingle)
        Me.ControlPanel.Controls.Add(Me.MinimumHeadLabel)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'ViewAsDialgogButton
        '
        resources.ApplyResources(Me.ViewAsDialogButton, "ViewAsDialgogButton")
        Me.ViewAsDialogButton.Name = "ViewAsDialgogButton"
        Me.ViewAsDialogButton.UseVisualStyleBackColor = True
        '
        'TableCaption
        '
        resources.ApplyResources(Me.TableCaption, "TableCaption")
        Me.TableCaption.Name = "TableCaption"
        '
        'ColumnIncrement
        '
        resources.ApplyResources(Me.ColumnIncrement, "ColumnIncrement")
        Me.ColumnIncrement.Label = ""
        Me.ColumnIncrement.Name = "ColumnIncrement"
        Me.ColumnIncrement.Precision = 0.01!
        Me.ColumnIncrement.UndoEnabled = True
        Me.ColumnIncrement.UnitsText = "ft"
        '
        'ShowSlopeDistsCheckBox
        '
        resources.ApplyResources(Me.ShowSlopeDistsCheckBox, "ShowSlopeDistsCheckBox")
        Me.ShowSlopeDistsCheckBox.HandleCheckedChanged = True
        Me.ShowSlopeDistsCheckBox.Name = "ShowSlopeDistsCheckBox"
        Me.ShowSlopeDistsCheckBox.UndoEnabled = True
        Me.ShowSlopeDistsCheckBox.UseVisualStyleBackColor = True
        Me.ShowSlopeDistsCheckBox.Value = False
        '
        'Z_Label
        '
        resources.ApplyResources(Me.Z_Label, "Z_Label")
        Me.Z_Label.Name = "Z_Label"
        '
        'GageSlopeSingle
        '
        resources.ApplyResources(Me.GageSlopeSingle, "GageSlopeSingle")
        Me.GageSlopeSingle.FormatStyle = "0.0###"
        Me.GageSlopeSingle.IsReadOnly = False
        Me.GageSlopeSingle.Label = "Single Value"
        Me.GageSlopeSingle.Name = "GageSlopeSingle"
        Me.GageSlopeSingle.ReadOnlyMsgBox = Nothing
        Me.GageSlopeSingle.SiDefaultValue = 0!
        Me.GageSlopeSingle.SiMin = -1.401298E-45!
        Me.GageSlopeSingle.SiValue = 0!
        Me.GageSlopeSingle.UiValue = 0!
        Me.GageSlopeSingle.UndoEnabled = True
        '
        'ColumnIncrementLabel
        '
        resources.ApplyResources(Me.ColumnIncrementLabel, "ColumnIncrementLabel")
        Me.ColumnIncrementLabel.Name = "ColumnIncrementLabel"
        '
        'MaximumHeadSingle
        '
        resources.ApplyResources(Me.MaximumHeadSingle, "MaximumHeadSingle")
        Me.MaximumHeadSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MaximumHeadSingle.FormatStyle = "0.0###"
        Me.MaximumHeadSingle.IsReadOnly = False
        Me.MaximumHeadSingle.Label = ""
        Me.MaximumHeadSingle.Name = "MaximumHeadSingle"
        Me.MaximumHeadSingle.ReadOnlyMsgBox = Nothing
        Me.MaximumHeadSingle.SiDefaultValue = 0!
        Me.MaximumHeadSingle.SiMin = -1.401298E-45!
        Me.MaximumHeadSingle.SiUnits = ""
        Me.MaximumHeadSingle.SiValue = 0!
        Me.MaximumHeadSingle.UndoEnabled = True
        '
        'MaximumHeadLabel
        '
        resources.ApplyResources(Me.MaximumHeadLabel, "MaximumHeadLabel")
        Me.MaximumHeadLabel.Name = "MaximumHeadLabel"
        '
        'MinimumHeadSingle
        '
        resources.ApplyResources(Me.MinimumHeadSingle, "MinimumHeadSingle")
        Me.MinimumHeadSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinimumHeadSingle.FormatStyle = "0.0###"
        Me.MinimumHeadSingle.IsReadOnly = False
        Me.MinimumHeadSingle.Label = ""
        Me.MinimumHeadSingle.Name = "MinimumHeadSingle"
        Me.MinimumHeadSingle.ReadOnlyMsgBox = Nothing
        Me.MinimumHeadSingle.SiDefaultValue = 0!
        Me.MinimumHeadSingle.SiMin = -1.401298E-45!
        Me.MinimumHeadSingle.SiUnits = ""
        Me.MinimumHeadSingle.SiValue = 0!
        Me.MinimumHeadSingle.UndoEnabled = True
        '
        'MinimumHeadLabel
        '
        resources.ApplyResources(Me.MinimumHeadLabel, "MinimumHeadLabel")
        Me.MinimumHeadLabel.Name = "MinimumHeadLabel"
        '
        'DitchridersTableControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.DataPanel)
        Me.Controls.Add(Me.StatusPanel)
        Me.Controls.Add(Me.ControlPanel)
        Me.Name = "DitchridersTableControl"
        Me.ControlPanel.ResumeLayout(False)
        Me.ControlPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ControlPanel As ctl_Panel
    Friend WithEvents StatusPanel As ctl_StatusPanel
    Friend WithEvents DataPanel As ctl_Panel
    Friend WithEvents ColumnIncrementLabel As ctl_Label
    Friend WithEvents MaximumHeadSingle As ctl_SingleUnits
    Friend WithEvents MaximumHeadLabel As ctl_Label
    Friend WithEvents MinimumHeadSingle As ctl_SingleUnits
    Friend WithEvents MinimumHeadLabel As ctl_Label
    Friend WithEvents Z_Label As ctl_Label
    Friend WithEvents GageSlopeSingle As ctl_Single
    Friend WithEvents ShowSlopeDistsCheckBox As ctl_CheckBox
    Friend WithEvents ColumnIncrement As ctl_Precision
    Friend WithEvents TableCaption As ctl_Label
    Friend WithEvents ViewAsDialogButton As ctl_Button
End Class
