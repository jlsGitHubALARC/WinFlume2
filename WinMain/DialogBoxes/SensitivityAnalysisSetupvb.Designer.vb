<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SensitivityAnalysisSetupvb
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
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.SA_TabControl = New DataStore.ctl_TabControl()
        Me.InputsTab = New System.Windows.Forms.TabPage()
        Me.ResultsTab = New System.Windows.Forms.TabPage()
        Me.MenuStrip.SuspendLayout()
        Me.SA_TabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(725, 30)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip.Location = New System.Drawing.Point(0, 30)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(725, 31)
        Me.ToolStrip.TabIndex = 1
        Me.ToolStrip.Text = "ToolStrip"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 26)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Location = New System.Drawing.Point(0, 740)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(725, 22)
        Me.StatusStrip.TabIndex = 2
        Me.StatusStrip.Text = "StatusStrip"
        '
        'SA_TabControl
        '
        Me.SA_TabControl.AccessibleDescription = ""
        Me.SA_TabControl.AccessibleName = ""
        Me.SA_TabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.SA_TabControl.Controls.Add(Me.InputsTab)
        Me.SA_TabControl.Controls.Add(Me.ResultsTab)
        Me.SA_TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SA_TabControl.Location = New System.Drawing.Point(0, 61)
        Me.SA_TabControl.Name = "SA_TabControl"
        Me.SA_TabControl.SelectedIndex = 0
        Me.SA_TabControl.Size = New System.Drawing.Size(725, 679)
        Me.SA_TabControl.TabIndex = 3
        '
        'InputsTab
        '
        Me.InputsTab.Location = New System.Drawing.Point(4, 4)
        Me.InputsTab.Name = "InputsTab"
        Me.InputsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.InputsTab.Size = New System.Drawing.Size(717, 646)
        Me.InputsTab.TabIndex = 0
        Me.InputsTab.Text = "Inputs"
        Me.InputsTab.UseVisualStyleBackColor = True
        '
        'ResultsTab
        '
        Me.ResultsTab.Location = New System.Drawing.Point(4, 4)
        Me.ResultsTab.Name = "ResultsTab"
        Me.ResultsTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ResultsTab.Size = New System.Drawing.Size(717, 646)
        Me.ResultsTab.TabIndex = 1
        Me.ResultsTab.Text = "Results"
        Me.ResultsTab.UseVisualStyleBackColor = True
        '
        'SensitivityAnalysisSetupvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 762)
        Me.Controls.Add(Me.SA_TabControl)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SensitivityAnalysisSetupvb"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sensitivity Analysis Setup"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.SA_TabControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents SA_TabControl As DataStore.ctl_TabControl
    Friend WithEvents InputsTab As TabPage
    Friend WithEvents ResultsTab As TabPage
End Class
