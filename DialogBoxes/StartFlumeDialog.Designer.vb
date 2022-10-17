<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartFlumeDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartFlumeDialog))
        Me.StartGroup = New WinFlume.ctl_GroupBox()
        Me.CreateNewFlumeButton = New WinFlume.ctl_RadioButton()
        Me.OpenOtherFlumeButton = New WinFlume.ctl_RadioButton()
        Me.OpenLastFlumeButton = New WinFlume.ctl_RadioButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.StartGroup.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartGroup
        '
        Me.StartGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.StartGroup.Controls.Add(Me.CreateNewFlumeButton)
        Me.StartGroup.Controls.Add(Me.OpenOtherFlumeButton)
        Me.StartGroup.Controls.Add(Me.OpenLastFlumeButton)
        resources.ApplyResources(Me.StartGroup, "StartGroup")
        Me.StartGroup.Name = "StartGroup"
        Me.StartGroup.TabStop = False
        '
        'CreateNewFlumeButton
        '
        resources.ApplyResources(Me.CreateNewFlumeButton, "CreateNewFlumeButton")
        Me.CreateNewFlumeButton.Label = ""
        Me.CreateNewFlumeButton.Name = "CreateNewFlumeButton"
        Me.CreateNewFlumeButton.RbValue = -1
        Me.CreateNewFlumeButton.UiValue = -1
        Me.CreateNewFlumeButton.UseVisualStyleBackColor = True
        '
        'OpenOtherFlumeButton
        '
        resources.ApplyResources(Me.OpenOtherFlumeButton, "OpenOtherFlumeButton")
        Me.OpenOtherFlumeButton.Label = ""
        Me.OpenOtherFlumeButton.Name = "OpenOtherFlumeButton"
        Me.OpenOtherFlumeButton.RbValue = -1
        Me.OpenOtherFlumeButton.UiValue = -1
        Me.OpenOtherFlumeButton.UseVisualStyleBackColor = True
        '
        'OpenLastFlumeButton
        '
        resources.ApplyResources(Me.OpenLastFlumeButton, "OpenLastFlumeButton")
        Me.OpenLastFlumeButton.Checked = True
        Me.OpenLastFlumeButton.Label = ""
        Me.OpenLastFlumeButton.Name = "OpenLastFlumeButton"
        Me.OpenLastFlumeButton.RbValue = -1
        Me.OpenLastFlumeButton.TabStop = True
        Me.OpenLastFlumeButton.UiValue = -1
        Me.OpenLastFlumeButton.UseVisualStyleBackColor = True
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
        'StartFlumeDialog
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.StartGroup)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StartFlumeDialog"
        Me.StartGroup.ResumeLayout(False)
        Me.StartGroup.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StartGroup As ctl_GroupBox
    Friend WithEvents OpenOtherFlumeButton As ctl_RadioButton
    Friend WithEvents OpenLastFlumeButton As ctl_RadioButton
    Friend WithEvents CreateNewFlumeButton As ctl_RadioButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
End Class
