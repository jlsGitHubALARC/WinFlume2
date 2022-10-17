<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RatingEquationControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RatingEquationControl))
        Me.HorizontalSplitter = New System.Windows.Forms.SplitContainer()
        Me.DataPanel = New WinFlume.ctl_Panel()
        Me.StatusPanel = New WinFlume.ctl_StatusPanel()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.ViewAsDialogButton = New WinFlume.ctl_Button()
        Me.HoldK2eq0Label = New WinFlume.ctl_Label()
        Me.HoldK2eq0CheckBox = New WinFlume.ctl_CheckBox()
        Me.ShowGroup = New WinFlume.ctl_GroupBox()
        Me.ShowGraphButton = New WinFlume.ctl_RadioButton()
        Me.ShowTableButton = New WinFlume.ctl_RadioButton()
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HorizontalSplitter.Panel1.SuspendLayout()
        Me.HorizontalSplitter.Panel2.SuspendLayout()
        Me.HorizontalSplitter.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        Me.ShowGroup.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ControlPanel.Controls.Add(Me.HoldK2eq0Label)
        Me.ControlPanel.Controls.Add(Me.HoldK2eq0CheckBox)
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
        'HoldK2eq0Label
        '
        resources.ApplyResources(Me.HoldK2eq0Label, "HoldK2eq0Label")
        Me.HoldK2eq0Label.Name = "HoldK2eq0Label"
        '
        'HoldK2eq0CheckBox
        '
        resources.ApplyResources(Me.HoldK2eq0CheckBox, "HoldK2eq0CheckBox")
        Me.HoldK2eq0CheckBox.HandleCheckedChanged = True
        Me.HoldK2eq0CheckBox.Name = "HoldK2eq0CheckBox"
        Me.HoldK2eq0CheckBox.UndoEnabled = True
        Me.HoldK2eq0CheckBox.UseVisualStyleBackColor = True
        Me.HoldK2eq0CheckBox.Value = False
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
        'RatingEquationControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.HorizontalSplitter)
        Me.Controls.Add(Me.ControlPanel)
        Me.Name = "RatingEquationControl"
        Me.HorizontalSplitter.Panel1.ResumeLayout(False)
        Me.HorizontalSplitter.Panel2.ResumeLayout(False)
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HorizontalSplitter.ResumeLayout(False)
        Me.ControlPanel.ResumeLayout(False)
        Me.ControlPanel.PerformLayout()
        Me.ShowGroup.ResumeLayout(False)
        Me.ShowGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ControlPanel As WinFlume.ctl_Panel
    Friend WithEvents ShowGroup As WinFlume.ctl_GroupBox
    Friend WithEvents ShowGraphButton As WinFlume.ctl_RadioButton
    Friend WithEvents ShowTableButton As WinFlume.ctl_RadioButton
    Friend WithEvents StatusPanel As WinFlume.ctl_StatusPanel
    Friend WithEvents DataPanel As WinFlume.ctl_Panel
    Friend WithEvents HoldK2eq0Label As WinFlume.ctl_Label
    Friend WithEvents HoldK2eq0CheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents HorizontalSplitter As SplitContainer
    Friend WithEvents ViewAsDialogButton As ctl_Button
End Class
