<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ControlViewerDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlViewerDialog))
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.OkCancelPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileCloseItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMenuSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileExportGraphImageItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileExportTableDataItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMenuSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FileExitItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCopyGraphBtimapItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCopyGraphDataItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCopyTableDataItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewerPanel = New WinFlume.ctl_Panel()
        Me.ControlPanel.SuspendLayout()
        Me.OkCancelPanel.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.OkCancelPanel)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'OkCancelPanel
        '
        resources.ApplyResources(Me.OkCancelPanel, "OkCancelPanel")
        Me.OkCancelPanel.Controls.Add(Me.OK_Button, 0, 0)
        Me.OkCancelPanel.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.OkCancelPanel.Name = "OkCancelPanel"
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
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu})
        resources.ApplyResources(Me.MenuStrip, "MenuStrip")
        Me.MenuStrip.Name = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileCloseItem, Me.FileMenuSeparator1, Me.FileExportGraphImageItem, Me.FileExportTableDataItem, Me.FileMenuSeparator2, Me.FileExitItem})
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
        'FileExportGraphImageItem
        '
        Me.FileExportGraphImageItem.Name = "FileExportGraphImageItem"
        resources.ApplyResources(Me.FileExportGraphImageItem, "FileExportGraphImageItem")
        '
        'FileExportTableDataItem
        '
        Me.FileExportTableDataItem.Name = "FileExportTableDataItem"
        resources.ApplyResources(Me.FileExportTableDataItem, "FileExportTableDataItem")
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
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditCopyGraphBtimapItem, Me.EditCopyGraphDataItem, Me.EditCopyTableDataItem})
        Me.EditMenu.Name = "EditMenu"
        resources.ApplyResources(Me.EditMenu, "EditMenu")
        '
        'EditCopyGraphBtimapItem
        '
        Me.EditCopyGraphBtimapItem.Name = "EditCopyGraphBtimapItem"
        resources.ApplyResources(Me.EditCopyGraphBtimapItem, "EditCopyGraphBtimapItem")
        '
        'EditCopyGraphDataItem
        '
        Me.EditCopyGraphDataItem.Name = "EditCopyGraphDataItem"
        resources.ApplyResources(Me.EditCopyGraphDataItem, "EditCopyGraphDataItem")
        '
        'EditCopyTableDataItem
        '
        Me.EditCopyTableDataItem.Name = "EditCopyTableDataItem"
        resources.ApplyResources(Me.EditCopyTableDataItem, "EditCopyTableDataItem")
        '
        'ViewerPanel
        '
        resources.ApplyResources(Me.ViewerPanel, "ViewerPanel")
        Me.ViewerPanel.Name = "ViewerPanel"
        '
        'ControlViewerDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Controls.Add(Me.ViewerPanel)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.ControlPanel)
        Me.MinimizeBox = False
        Me.Name = "ControlViewerDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ControlPanel.ResumeLayout(False)
        Me.OkCancelPanel.ResumeLayout(False)
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ControlPanel As ctl_Panel
    Friend WithEvents OkCancelPanel As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents FileMenu As ToolStripMenuItem
    Friend WithEvents FileCloseItem As ToolStripMenuItem
    Friend WithEvents FileMenuSeparator1 As ToolStripSeparator
    Friend WithEvents FileExportGraphImageItem As ToolStripMenuItem
    Friend WithEvents FileExportTableDataItem As ToolStripMenuItem
    Friend WithEvents FileMenuSeparator2 As ToolStripSeparator
    Friend WithEvents FileExitItem As ToolStripMenuItem
    Friend WithEvents EditMenu As ToolStripMenuItem
    Friend WithEvents EditCopyGraphBtimapItem As ToolStripMenuItem
    Friend WithEvents EditCopyGraphDataItem As ToolStripMenuItem
    Friend WithEvents EditCopyTableDataItem As ToolStripMenuItem
    Friend WithEvents ViewerPanel As ctl_Panel
End Class
