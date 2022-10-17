<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewFlumeDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewFlumeDialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.InitializationGroup = New WinFlume.ctl_GroupBox()
        Me.DefaultFlumeButton = New WinFlume.ctl_RadioButton()
        Me.CopyOfFlumeButton = New WinFlume.ctl_RadioButton()
        Me.FlumeWizardBox = New WinFlume.ctl_GroupBox()
        Me.UseFlumeWizardCheckBox = New WinFlume.ctl_CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.InitializationGroup.SuspendLayout()
        Me.FlumeWizardBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'InitializationGroup
        '
        Me.InitializationGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.InitializationGroup.Controls.Add(Me.DefaultFlumeButton)
        Me.InitializationGroup.Controls.Add(Me.CopyOfFlumeButton)
        resources.ApplyResources(Me.InitializationGroup, "InitializationGroup")
        Me.InitializationGroup.Name = "InitializationGroup"
        Me.InitializationGroup.TabStop = False
        '
        'DefaultFlumeButton
        '
        resources.ApplyResources(Me.DefaultFlumeButton, "DefaultFlumeButton")
        Me.DefaultFlumeButton.Checked = True
        Me.DefaultFlumeButton.Label = ""
        Me.DefaultFlumeButton.Name = "DefaultFlumeButton"
        Me.DefaultFlumeButton.RbValue = -1
        Me.DefaultFlumeButton.TabStop = True
        Me.DefaultFlumeButton.UiValue = -1
        Me.DefaultFlumeButton.UseVisualStyleBackColor = True
        '
        'CopyOfFlumeButton
        '
        resources.ApplyResources(Me.CopyOfFlumeButton, "CopyOfFlumeButton")
        Me.CopyOfFlumeButton.Label = ""
        Me.CopyOfFlumeButton.Name = "CopyOfFlumeButton"
        Me.CopyOfFlumeButton.RbValue = -1
        Me.CopyOfFlumeButton.UiValue = -1
        Me.CopyOfFlumeButton.UseVisualStyleBackColor = True
        '
        'FlumeWizardBox
        '
        Me.FlumeWizardBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FlumeWizardBox.Controls.Add(Me.UseFlumeWizardCheckBox)
        resources.ApplyResources(Me.FlumeWizardBox, "FlumeWizardBox")
        Me.FlumeWizardBox.Name = "FlumeWizardBox"
        Me.FlumeWizardBox.TabStop = False
        '
        'UseFlumeWizardCheckBox
        '
        resources.ApplyResources(Me.UseFlumeWizardCheckBox, "UseFlumeWizardCheckBox")
        Me.UseFlumeWizardCheckBox.Name = "UseFlumeWizardCheckBox"
        Me.UseFlumeWizardCheckBox.UseVisualStyleBackColor = True
        Me.UseFlumeWizardCheckBox.Value = False
        '
        'NewFlumeDialog
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.FlumeWizardBox)
        Me.Controls.Add(Me.InitializationGroup)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewFlumeDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.InitializationGroup.ResumeLayout(False)
        Me.InitializationGroup.PerformLayout()
        Me.FlumeWizardBox.ResumeLayout(False)
        Me.FlumeWizardBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents InitializationGroup As ctl_GroupBox
    Friend WithEvents DefaultFlumeButton As ctl_RadioButton
    Friend WithEvents CopyOfFlumeButton As ctl_RadioButton
    Friend WithEvents FlumeWizardBox As ctl_GroupBox
    Friend WithEvents UseFlumeWizardCheckBox As ctl_CheckBox
End Class
