<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RatingComparisonControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RatingComparisonControl))
        Me.DataPanel = New WinFlume.ctl_Panel()
        Me.StatusPanel = New WinFlume.ctl_StatusPanel()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.ViewAsDialogButton = New WinFlume.ctl_Button()
        Me.ShowGroup = New WinFlume.ctl_GroupBox()
        Me.ShowGraphButton = New WinFlume.ctl_RadioButton()
        Me.ShowTableButton = New WinFlume.ctl_RadioButton()
        Me.ControlPanel.SuspendLayout()
        Me.ShowGroup.SuspendLayout()
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
        Me.ControlPanel.Controls.Add(Me.ShowGroup)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'ViewAsDialgogButton
        '
        resources.ApplyResources(Me.ViewAsDialogButton, "ViewAsDialgogButton")
        Me.ViewAsDialogButton.Name = "ViewAsDialgogButton"
        Me.ViewAsDialogButton.UseVisualStyleBackColor = True
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
        'RatingComparisonControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataPanel)
        Me.Controls.Add(Me.StatusPanel)
        Me.Controls.Add(Me.ControlPanel)
        Me.Name = "RatingComparisonControl"
        Me.ControlPanel.ResumeLayout(False)
        Me.ShowGroup.ResumeLayout(False)
        Me.ShowGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ControlPanel As ctl_Panel
    Friend WithEvents ShowGroup As ctl_GroupBox
    Friend WithEvents ShowGraphButton As ctl_RadioButton
    Friend WithEvents ShowTableButton As ctl_RadioButton
    Friend WithEvents StatusPanel As ctl_StatusPanel
    Friend WithEvents DataPanel As ctl_Panel
    Friend WithEvents ViewAsDialogButton As ctl_Button
End Class
