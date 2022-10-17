<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RatingTableControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RatingTableControl))
        Me.DataPanel = New WinFlume.ctl_Panel()
        Me.StatusPanel = New WinFlume.ctl_StatusPanel()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.GraphControlPanel = New WinFlume.ctl_Panel()
        Me.RightAxisBox = New WinFlume.ctl_GroupBox()
        Me.SyncYAxesSelect = New WinFlume.ctl_CheckBox()
        Me.RightAxisSelect1 = New WinFlume.ctl_ComboBox()
        Me.LeftAxisBox = New WinFlume.ctl_GroupBox()
        Me.LeftAxisSelect2 = New WinFlume.ctl_ComboBox()
        Me.LeftAxisSelect1 = New WinFlume.ctl_ComboBox()
        Me.ShowGroup = New WinFlume.ctl_GroupBox()
        Me.ShowGraphButton = New WinFlume.ctl_RadioButton()
        Me.ShowTableButton = New WinFlume.ctl_RadioButton()
        Me.TableControlPanel = New WinFlume.ctl_Panel()
        Me.HorizontalSplitter = New System.Windows.Forms.SplitContainer()
        Me.ViewAsDialogButton = New WinFlume.ctl_Button()
        Me.ControlPanel.SuspendLayout()
        Me.GraphControlPanel.SuspendLayout()
        Me.RightAxisBox.SuspendLayout()
        Me.LeftAxisBox.SuspendLayout()
        Me.ShowGroup.SuspendLayout()
        Me.TableControlPanel.SuspendLayout()
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HorizontalSplitter.Panel1.SuspendLayout()
        Me.HorizontalSplitter.Panel2.SuspendLayout()
        Me.HorizontalSplitter.SuspendLayout()
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
        Me.ControlPanel.Controls.Add(Me.TableControlPanel)
        Me.ControlPanel.Controls.Add(Me.GraphControlPanel)
        Me.ControlPanel.Controls.Add(Me.ShowGroup)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'GraphControlPanel
        '
        Me.GraphControlPanel.Controls.Add(Me.RightAxisBox)
        Me.GraphControlPanel.Controls.Add(Me.LeftAxisBox)
        resources.ApplyResources(Me.GraphControlPanel, "GraphControlPanel")
        Me.GraphControlPanel.Name = "GraphControlPanel"
        '
        'RightAxisBox
        '
        Me.RightAxisBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RightAxisBox.Controls.Add(Me.SyncYAxesSelect)
        Me.RightAxisBox.Controls.Add(Me.RightAxisSelect1)
        resources.ApplyResources(Me.RightAxisBox, "RightAxisBox")
        Me.RightAxisBox.Name = "RightAxisBox"
        Me.RightAxisBox.TabStop = False
        '
        'SyncYAxesSelect
        '
        resources.ApplyResources(Me.SyncYAxesSelect, "SyncYAxesSelect")
        Me.SyncYAxesSelect.HandleCheckedChanged = True
        Me.SyncYAxesSelect.Name = "SyncYAxesSelect"
        Me.SyncYAxesSelect.UndoEnabled = True
        Me.SyncYAxesSelect.UseVisualStyleBackColor = True
        Me.SyncYAxesSelect.Value = False
        '
        'RightAxisSelect1
        '
        Me.RightAxisSelect1.BackColor = System.Drawing.SystemColors.Window
        Me.RightAxisSelect1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.RightAxisSelect1, "RightAxisSelect1")
        Me.RightAxisSelect1.FormattingEnabled = True
        Me.RightAxisSelect1.Name = "RightAxisSelect1"
        Me.RightAxisSelect1.UndoEnabled = True
        Me.RightAxisSelect1.Value = -1
        '
        'LeftAxisBox
        '
        Me.LeftAxisBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LeftAxisBox.Controls.Add(Me.LeftAxisSelect2)
        Me.LeftAxisBox.Controls.Add(Me.LeftAxisSelect1)
        resources.ApplyResources(Me.LeftAxisBox, "LeftAxisBox")
        Me.LeftAxisBox.Name = "LeftAxisBox"
        Me.LeftAxisBox.TabStop = False
        '
        'LeftAxisSelect2
        '
        Me.LeftAxisSelect2.BackColor = System.Drawing.SystemColors.Window
        Me.LeftAxisSelect2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.LeftAxisSelect2, "LeftAxisSelect2")
        Me.LeftAxisSelect2.FormattingEnabled = True
        Me.LeftAxisSelect2.Name = "LeftAxisSelect2"
        Me.LeftAxisSelect2.UndoEnabled = True
        Me.LeftAxisSelect2.Value = -1
        '
        'LeftAxisSelect1
        '
        Me.LeftAxisSelect1.BackColor = System.Drawing.SystemColors.Window
        Me.LeftAxisSelect1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.LeftAxisSelect1, "LeftAxisSelect1")
        Me.LeftAxisSelect1.FormattingEnabled = True
        Me.LeftAxisSelect1.Name = "LeftAxisSelect1"
        Me.LeftAxisSelect1.UndoEnabled = True
        Me.LeftAxisSelect1.Value = -1
        '
        'ShowGroup
        '
        Me.ShowGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ShowGroup.Controls.Add(Me.ShowGraphButton)
        Me.ShowGroup.Controls.Add(Me.ShowTableButton)
        resources.ApplyResources(Me.ShowGroup, "ShowGroup")
        Me.ShowGroup.Name = "ShowGroup"
        Me.ShowGroup.TabStop = False
        '
        'ShowGraphButton
        '
        resources.ApplyResources(Me.ShowGraphButton, "ShowGraphButton")
        Me.ShowGraphButton.Label = ""
        Me.ShowGraphButton.Name = "ShowGraphButton"
        Me.ShowGraphButton.RbValue = -1
        Me.ShowGraphButton.UiValue = -1
        Me.ShowGraphButton.UseVisualStyleBackColor = True
        '
        'ShowTableButton
        '
        resources.ApplyResources(Me.ShowTableButton, "ShowTableButton")
        Me.ShowTableButton.Checked = True
        Me.ShowTableButton.Label = ""
        Me.ShowTableButton.Name = "ShowTableButton"
        Me.ShowTableButton.RbValue = -1
        Me.ShowTableButton.TabStop = True
        Me.ShowTableButton.UiValue = -1
        Me.ShowTableButton.UseVisualStyleBackColor = True
        '
        'TableControlPanel
        '
        Me.TableControlPanel.Controls.Add(Me.ViewAsDialogButton)
        resources.ApplyResources(Me.TableControlPanel, "TableControlPanel")
        Me.TableControlPanel.Name = "TableControlPanel"
        '
        'HorizontalSplitter
        '
        resources.ApplyResources(Me.HorizontalSplitter, "HorizontalSplitter")
        Me.HorizontalSplitter.Name = "HorizontalSplitter"
        '
        'HorizontalSplitter.Panel1
        '
        Me.HorizontalSplitter.Panel1.Controls.Add(Me.DataPanel)
        '
        'HorizontalSplitter.Panel2
        '
        Me.HorizontalSplitter.Panel2.Controls.Add(Me.StatusPanel)
        '
        'ViewAsDialgogButton
        '
        resources.ApplyResources(Me.ViewAsDialogButton, "ViewAsDialgogButton")
        Me.ViewAsDialogButton.Name = "ViewAsDialgogButton"
        Me.ViewAsDialogButton.UseVisualStyleBackColor = True
        '
        'RatingTableControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.HorizontalSplitter)
        Me.Controls.Add(Me.ControlPanel)
        Me.Name = "RatingTableControl"
        Me.ControlPanel.ResumeLayout(False)
        Me.GraphControlPanel.ResumeLayout(False)
        Me.RightAxisBox.ResumeLayout(False)
        Me.RightAxisBox.PerformLayout()
        Me.LeftAxisBox.ResumeLayout(False)
        Me.ShowGroup.ResumeLayout(False)
        Me.ShowGroup.PerformLayout()
        Me.TableControlPanel.ResumeLayout(False)
        Me.HorizontalSplitter.Panel1.ResumeLayout(False)
        Me.HorizontalSplitter.Panel2.ResumeLayout(False)
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HorizontalSplitter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ControlPanel As WinFlume.ctl_Panel
    Friend WithEvents ShowGroup As WinFlume.ctl_GroupBox
    Friend WithEvents ShowGraphButton As WinFlume.ctl_RadioButton
    Friend WithEvents ShowTableButton As WinFlume.ctl_RadioButton
    Friend WithEvents StatusPanel As WinFlume.ctl_StatusPanel
    Friend WithEvents DataPanel As WinFlume.ctl_Panel
    Friend WithEvents GraphControlPanel As WinFlume.ctl_Panel
    Friend WithEvents LeftAxisBox As WinFlume.ctl_GroupBox
    Friend WithEvents TableControlPanel As WinFlume.ctl_Panel
    Friend WithEvents RightAxisBox As WinFlume.ctl_GroupBox
    Friend WithEvents LeftAxisSelect1 As WinFlume.ctl_ComboBox
    Friend WithEvents RightAxisSelect1 As WinFlume.ctl_ComboBox
    Friend WithEvents LeftAxisSelect2 As WinFlume.ctl_ComboBox
    Friend WithEvents SyncYAxesSelect As WinFlume.ctl_CheckBox
    Friend WithEvents HorizontalSplitter As SplitContainer
    Friend WithEvents ViewAsDialogButton As ctl_Button
End Class
