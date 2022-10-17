<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WallGageViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WallGageViewer))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.ViewGroup = New WinFlume.ctl_GroupBox()
        Me.PageNumberUpDown = New System.Windows.Forms.NumericUpDown()
        Me.ViewAsPagesButton = New System.Windows.Forms.RadioButton()
        Me.ViewAsGageButton = New System.Windows.Forms.RadioButton()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileCloseItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMenuSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileExportImageItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMenuSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileExitItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCopyBtimapItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WallGagePanel = New WinFlume.ctl_Panel()
        Me.ControlPanel.SuspendLayout()
        Me.ViewGroup.SuspendLayout()
        CType(Me.PageNumberUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.ViewGroup)
        Me.ControlPanel.Controls.Add(Me.Cancel_Button)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'ViewGroup
        '
        Me.ViewGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ViewGroup.Controls.Add(Me.PageNumberUpDown)
        Me.ViewGroup.Controls.Add(Me.ViewAsPagesButton)
        Me.ViewGroup.Controls.Add(Me.ViewAsGageButton)
        resources.ApplyResources(Me.ViewGroup, "ViewGroup")
        Me.ViewGroup.Name = "ViewGroup"
        Me.ViewGroup.TabStop = False
        '
        'PageNumberUpDown
        '
        resources.ApplyResources(Me.PageNumberUpDown, "PageNumberUpDown")
        Me.PageNumberUpDown.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.PageNumberUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PageNumberUpDown.Name = "PageNumberUpDown"
        Me.PageNumberUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ViewAsPagesButton
        '
        resources.ApplyResources(Me.ViewAsPagesButton, "ViewAsPagesButton")
        Me.ViewAsPagesButton.Name = "ViewAsPagesButton"
        Me.ViewAsPagesButton.TabStop = True
        Me.ViewAsPagesButton.UseVisualStyleBackColor = True
        '
        'ViewAsGageButton
        '
        resources.ApplyResources(Me.ViewAsGageButton, "ViewAsGageButton")
        Me.ViewAsGageButton.Name = "ViewAsGageButton"
        Me.ViewAsGageButton.TabStop = True
        Me.ViewAsGageButton.UseVisualStyleBackColor = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu})
        resources.ApplyResources(Me.MenuStrip, "MenuStrip")
        Me.MenuStrip.Name = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileCloseItem, Me.FileMenuSeparator1, Me.FileExportImageItem, Me.FileMenuSeparator2, Me.FileExitItem})
        Me.FileMenu.Name = "FileMenu"
        resources.ApplyResources(Me.FileMenu, "FileMenu")
        '
        'FileCloseItem
        '
        Me.FileCloseItem.Name = "FileCloseItem"
        resources.ApplyResources(Me.FileCloseItem, "FileCloseItem")
        '
        'FileMenuSeparator1
        '
        Me.FileMenuSeparator1.Name = "FileMenuSeparator1"
        resources.ApplyResources(Me.FileMenuSeparator1, "FileMenuSeparator1")
        '
        'FileExportImageItem
        '
        Me.FileExportImageItem.Name = "FileExportImageItem"
        resources.ApplyResources(Me.FileExportImageItem, "FileExportImageItem")
        '
        'FileMenuSeparator2
        '
        Me.FileMenuSeparator2.Name = "FileMenuSeparator2"
        resources.ApplyResources(Me.FileMenuSeparator2, "FileMenuSeparator2")
        '
        'FileExitItem
        '
        Me.FileExitItem.Name = "FileExitItem"
        resources.ApplyResources(Me.FileExitItem, "FileExitItem")
        '
        'EditMenu
        '
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditCopyBtimapItem})
        Me.EditMenu.Name = "EditMenu"
        resources.ApplyResources(Me.EditMenu, "EditMenu")
        '
        'EditCopyBtimapItem
        '
        Me.EditCopyBtimapItem.Name = "EditCopyBtimapItem"
        resources.ApplyResources(Me.EditCopyBtimapItem, "EditCopyBtimapItem")
        '
        'WallGagePanel
        '
        resources.ApplyResources(Me.WallGagePanel, "WallGagePanel")
        Me.WallGagePanel.Name = "WallGagePanel"
        '
        'WallGageViewer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.WallGagePanel)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.ControlPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WallGageViewer"
        Me.ShowInTaskbar = False
        Me.ControlPanel.ResumeLayout(False)
        Me.ViewGroup.ResumeLayout(False)
        Me.ViewGroup.PerformLayout()
        CType(Me.PageNumberUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ControlPanel As ctl_Panel
    Friend WithEvents ViewGroup As ctl_GroupBox
    Friend WithEvents ViewAsPagesButton As RadioButton
    Friend WithEvents ViewAsGageButton As RadioButton
    Friend WithEvents PageNumberUpDown As NumericUpDown
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents FileMenu As ToolStripMenuItem
    Friend WithEvents FileCloseItem As ToolStripMenuItem
    Friend WithEvents FileMenuSeparator1 As ToolStripSeparator
    Friend WithEvents FileExportImageItem As ToolStripMenuItem
    Friend WithEvents FileMenuSeparator2 As ToolStripSeparator
    Friend WithEvents FileExitItem As ToolStripMenuItem
    Friend WithEvents EditMenu As ToolStripMenuItem
    Friend WithEvents EditCopyBtimapItem As ToolStripMenuItem
    Friend WithEvents WallGagePanel As ctl_Panel
End Class
