
'**********************************************************************************************
' WorldWindow - base form (Window) for WinSRFR's Worlds.
'
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows

Imports DataStore
Imports GraphingUI
Imports PrintingUI

Public Class WorldWindow
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private components As System.ComponentModel.IContainer

    'Required by the Windows Form Designer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents WorldMainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents FileCloseItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents FileSaveItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents PrintResultsItem As System.Windows.Forms.MenuItem
    Friend WithEvents PreviewResultsItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditUndoItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditRedoItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents EditSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents EditUnitsItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewProjectWindowItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewResultsAsItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpWhatsThisItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents ToolbarImageList As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents SaveButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents PrintButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarSeparator1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents UndoButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents RedoButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarSeparator2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ViewProjectWindowButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarSeparator3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents WhatsThisButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarSeparator4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents StatusImageList As System.Windows.Forms.ImageList
    Friend WithEvents StatusIcon As GraphingUI.ex_PictureBox
    Friend WithEvents UserLevelPanel As System.Windows.Forms.StatusBarPanel
    Protected Friend WithEvents WorldStatusBar As System.Windows.Forms.StatusBar
    Protected Friend WithEvents TitleBox As System.Windows.Forms.RichTextBox
    Protected Friend WithEvents WorldPanel As System.Windows.Forms.Panel
    Friend WithEvents ViewGraphsOnlyItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditCopyBitmapItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditCopyDataItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewPdfManualItem As System.Windows.Forms.MenuItem
    Protected Friend WithEvents WorldToolbar As System.Windows.Forms.ToolBar
    Friend WithEvents WorldStatusPanel As System.Windows.Forms.StatusBarPanel
    Protected Friend WithEvents FileMenu As System.Windows.Forms.MenuItem
    Protected Friend WithEvents EditMenu As System.Windows.Forms.MenuItem
    Protected Friend WithEvents ViewMenu As System.Windows.Forms.MenuItem
    Protected Friend WithEvents HelpMenu As System.Windows.Forms.MenuItem
    Protected Friend WithEvents WorldMenu As System.Windows.Forms.MenuItem
    Friend WithEvents ViewFullPageItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewRefreshItem As System.Windows.Forms.MenuItem
    Friend WithEvents ProgressBarPanel As System.Windows.Forms.StatusBarPanel
    Friend WithEvents UndoContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents RedoContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents FileExportImageItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator3 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewDebugWindowsItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents FileScriptingItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator4 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSimulationNetworkItem As System.Windows.Forms.MenuItem
    Friend WithEvents UsdaLabel As System.Windows.Forms.Label
    Friend WithEvents ViewAnimationWindowItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSizeItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSize800x600 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSize900x675 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSize949x768 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSize1024x768 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSelectCurvesItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSeparator3 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewShowFirstCurveItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewShowNextCurveItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewShowLastCurveItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewShowPrevCurveItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileExportSrfrInputsItem As MenuItem
    Friend WithEvents ViewShowAllCurvesItem As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorldWindow))
        Me.WorldMainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.FileMenu = New System.Windows.Forms.MenuItem()
        Me.FileCloseItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator1 = New System.Windows.Forms.MenuItem()
        Me.FileSaveItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator2 = New System.Windows.Forms.MenuItem()
        Me.FileExportImageItem = New System.Windows.Forms.MenuItem()
        Me.FileExportSrfrInputsItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator3 = New System.Windows.Forms.MenuItem()
        Me.FileScriptingItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator4 = New System.Windows.Forms.MenuItem()
        Me.PrintResultsItem = New System.Windows.Forms.MenuItem()
        Me.PreviewResultsItem = New System.Windows.Forms.MenuItem()
        Me.EditMenu = New System.Windows.Forms.MenuItem()
        Me.EditUndoItem = New System.Windows.Forms.MenuItem()
        Me.EditRedoItem = New System.Windows.Forms.MenuItem()
        Me.EditSeparator1 = New System.Windows.Forms.MenuItem()
        Me.EditCopyBitmapItem = New System.Windows.Forms.MenuItem()
        Me.EditCopyDataItem = New System.Windows.Forms.MenuItem()
        Me.EditSeparator2 = New System.Windows.Forms.MenuItem()
        Me.EditUnitsItem = New System.Windows.Forms.MenuItem()
        Me.ViewMenu = New System.Windows.Forms.MenuItem()
        Me.ViewProjectWindowItem = New System.Windows.Forms.MenuItem()
        Me.ViewSeparator1 = New System.Windows.Forms.MenuItem()
        Me.ViewResultsAsItem = New System.Windows.Forms.MenuItem()
        Me.ViewFullPageItem = New System.Windows.Forms.MenuItem()
        Me.ViewGraphsOnlyItem = New System.Windows.Forms.MenuItem()
        Me.ViewRefreshItem = New System.Windows.Forms.MenuItem()
        Me.ViewSizeItem = New System.Windows.Forms.MenuItem()
        Me.ViewSize800x600 = New System.Windows.Forms.MenuItem()
        Me.ViewSize900x675 = New System.Windows.Forms.MenuItem()
        Me.ViewSize949x768 = New System.Windows.Forms.MenuItem()
        Me.ViewSize1024x768 = New System.Windows.Forms.MenuItem()
        Me.ViewSeparator2 = New System.Windows.Forms.MenuItem()
        Me.ViewDebugWindowsItem = New System.Windows.Forms.MenuItem()
        Me.ViewSimulationNetworkItem = New System.Windows.Forms.MenuItem()
        Me.ViewAnimationWindowItem = New System.Windows.Forms.MenuItem()
        Me.ViewSeparator3 = New System.Windows.Forms.MenuItem()
        Me.ViewSelectCurvesItem = New System.Windows.Forms.MenuItem()
        Me.ViewShowFirstCurveItem = New System.Windows.Forms.MenuItem()
        Me.ViewShowNextCurveItem = New System.Windows.Forms.MenuItem()
        Me.ViewShowLastCurveItem = New System.Windows.Forms.MenuItem()
        Me.ViewShowPrevCurveItem = New System.Windows.Forms.MenuItem()
        Me.ViewShowAllCurvesItem = New System.Windows.Forms.MenuItem()
        Me.WorldMenu = New System.Windows.Forms.MenuItem()
        Me.HelpMenu = New System.Windows.Forms.MenuItem()
        Me.HelpWhatsThisItem = New System.Windows.Forms.MenuItem()
        Me.HelpSeparator1 = New System.Windows.Forms.MenuItem()
        Me.ViewPdfManualItem = New System.Windows.Forms.MenuItem()
        Me.WorldToolbar = New System.Windows.Forms.ToolBar()
        Me.SaveButton = New System.Windows.Forms.ToolBarButton()
        Me.PrintButton = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarSeparator1 = New System.Windows.Forms.ToolBarButton()
        Me.UndoButton = New System.Windows.Forms.ToolBarButton()
        Me.UndoContextMenu = New System.Windows.Forms.ContextMenu()
        Me.RedoButton = New System.Windows.Forms.ToolBarButton()
        Me.RedoContextMenu = New System.Windows.Forms.ContextMenu()
        Me.ToolBarSeparator2 = New System.Windows.Forms.ToolBarButton()
        Me.ViewProjectWindowButton = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarSeparator3 = New System.Windows.Forms.ToolBarButton()
        Me.WhatsThisButton = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarSeparator4 = New System.Windows.Forms.ToolBarButton()
        Me.ToolbarImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.WorldStatusBar = New System.Windows.Forms.StatusBar()
        Me.WorldStatusPanel = New System.Windows.Forms.StatusBarPanel()
        Me.ProgressBarPanel = New System.Windows.Forms.StatusBarPanel()
        Me.UserLevelPanel = New System.Windows.Forms.StatusBarPanel()
        Me.StatusImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusIcon = New GraphingUI.ex_PictureBox()
        Me.TitleBox = New System.Windows.Forms.RichTextBox()
        Me.WorldPanel = New System.Windows.Forms.Panel()
        Me.UsdaLabel = New System.Windows.Forms.Label()
        CType(Me.WorldStatusPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserLevelPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WorldMainMenu
        '
        Me.WorldMainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileMenu, Me.EditMenu, Me.ViewMenu, Me.WorldMenu, Me.HelpMenu})
        '
        'FileMenu
        '
        Me.FileMenu.Index = 0
        Me.FileMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileCloseItem, Me.FileSeparator1, Me.FileSaveItem, Me.FileSeparator2, Me.FileExportImageItem, Me.FileExportSrfrInputsItem, Me.FileSeparator3, Me.FileScriptingItem, Me.FileSeparator4, Me.PrintResultsItem, Me.PreviewResultsItem})
        Me.FileMenu.Text = "&File"
        '
        'FileCloseItem
        '
        Me.FileCloseItem.Index = 0
        Me.FileCloseItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftC
        Me.FileCloseItem.Text = "&Close"
        '
        'FileSeparator1
        '
        Me.FileSeparator1.Index = 1
        Me.FileSeparator1.Text = "-"
        '
        'FileSaveItem
        '
        Me.FileSaveItem.Index = 2
        Me.FileSaveItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.FileSaveItem.Text = "&Save"
        '
        'FileSeparator2
        '
        Me.FileSeparator2.Index = 3
        Me.FileSeparator2.Text = "-"
        '
        'FileExportImageItem
        '
        Me.FileExportImageItem.Index = 4
        Me.FileExportImageItem.Text = "&Export graph Image"
        '
        'FileExportSrfrInputsItem
        '
        Me.FileExportSrfrInputsItem.Index = 5
        Me.FileExportSrfrInputsItem.Text = "Export SRFR &Inputs ..."
        '
        'FileSeparator3
        '
        Me.FileSeparator3.Index = 6
        Me.FileSeparator3.Text = "-"
        '
        'FileScriptingItem
        '
        Me.FileScriptingItem.Enabled = False
        Me.FileScriptingItem.Index = 7
        Me.FileScriptingItem.Text = "Sc&ripting"
        '
        'FileSeparator4
        '
        Me.FileSeparator4.Index = 8
        Me.FileSeparator4.Text = "-"
        '
        'PrintResultsItem
        '
        Me.PrintResultsItem.Index = 9
        Me.PrintResultsItem.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.PrintResultsItem.Text = "&Print Results ..."
        '
        'PreviewResultsItem
        '
        Me.PreviewResultsItem.Index = 10
        Me.PreviewResultsItem.Text = "Print Pre&view Results ..."
        '
        'EditMenu
        '
        Me.EditMenu.Index = 1
        Me.EditMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.EditUndoItem, Me.EditRedoItem, Me.EditSeparator1, Me.EditCopyBitmapItem, Me.EditCopyDataItem, Me.EditSeparator2, Me.EditUnitsItem})
        Me.EditMenu.Text = "&Edit"
        '
        'EditUndoItem
        '
        Me.EditUndoItem.Enabled = False
        Me.EditUndoItem.Index = 0
        Me.EditUndoItem.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
        Me.EditUndoItem.Text = "&Undo"
        '
        'EditRedoItem
        '
        Me.EditRedoItem.Enabled = False
        Me.EditRedoItem.Index = 1
        Me.EditRedoItem.Shortcut = System.Windows.Forms.Shortcut.CtrlY
        Me.EditRedoItem.Text = "&Redo"
        '
        'EditSeparator1
        '
        Me.EditSeparator1.Index = 2
        Me.EditSeparator1.Text = "-"
        '
        'EditCopyBitmapItem
        '
        Me.EditCopyBitmapItem.Index = 3
        Me.EditCopyBitmapItem.Text = "Copy graph &Bitmap"
        '
        'EditCopyDataItem
        '
        Me.EditCopyDataItem.Index = 4
        Me.EditCopyDataItem.Text = "Copy graph &Data"
        '
        'EditSeparator2
        '
        Me.EditSeparator2.Index = 5
        Me.EditSeparator2.Text = "-"
        '
        'EditUnitsItem
        '
        Me.EditUnitsItem.Index = 6
        Me.EditUnitsItem.Shortcut = System.Windows.Forms.Shortcut.CtrlU
        Me.EditUnitsItem.Text = "&Units ..."
        '
        'ViewMenu
        '
        Me.ViewMenu.Index = 2
        Me.ViewMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewProjectWindowItem, Me.ViewSeparator1, Me.ViewResultsAsItem, Me.ViewRefreshItem, Me.ViewSizeItem, Me.ViewSeparator2, Me.ViewDebugWindowsItem, Me.ViewSimulationNetworkItem, Me.ViewAnimationWindowItem, Me.ViewSeparator3, Me.ViewSelectCurvesItem})
        Me.ViewMenu.Text = "&View"
        '
        'ViewProjectWindowItem
        '
        Me.ViewProjectWindowItem.Index = 0
        Me.ViewProjectWindowItem.Shortcut = System.Windows.Forms.Shortcut.CtrlW
        Me.ViewProjectWindowItem.Text = "Project Management &Window"
        '
        'ViewSeparator1
        '
        Me.ViewSeparator1.Index = 1
        Me.ViewSeparator1.Text = "-"
        '
        'ViewResultsAsItem
        '
        Me.ViewResultsAsItem.Index = 2
        Me.ViewResultsAsItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewFullPageItem, Me.ViewGraphsOnlyItem})
        Me.ViewResultsAsItem.Text = "&Results as"
        '
        'ViewFullPageItem
        '
        Me.ViewFullPageItem.Index = 0
        Me.ViewFullPageItem.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.ViewFullPageItem.Text = "&Full Page"
        '
        'ViewGraphsOnlyItem
        '
        Me.ViewGraphsOnlyItem.Index = 1
        Me.ViewGraphsOnlyItem.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.ViewGraphsOnlyItem.Text = "&Graphs Only"
        '
        'ViewRefreshItem
        '
        Me.ViewRefreshItem.Index = 3
        Me.ViewRefreshItem.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.ViewRefreshItem.Text = "Re&fresh"
        '
        'ViewSizeItem
        '
        Me.ViewSizeItem.Index = 4
        Me.ViewSizeItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewSize800x600, Me.ViewSize900x675, Me.ViewSize949x768, Me.ViewSize1024x768})
        Me.ViewSizeItem.Text = "Si&ze"
        '
        'ViewSize800x600
        '
        Me.ViewSize800x600.Index = 0
        Me.ViewSize800x600.Text = "&800x600"
        '
        'ViewSize900x675
        '
        Me.ViewSize900x675.Index = 1
        Me.ViewSize900x675.Text = "&900x675"
        '
        'ViewSize949x768
        '
        Me.ViewSize949x768.Index = 2
        Me.ViewSize949x768.Text = "9&49x768"
        '
        'ViewSize1024x768
        '
        Me.ViewSize1024x768.Index = 3
        Me.ViewSize1024x768.Text = "&1024x768"
        '
        'ViewSeparator2
        '
        Me.ViewSeparator2.Index = 5
        Me.ViewSeparator2.Text = "-"
        '
        'ViewDebugWindowsItem
        '
        Me.ViewDebugWindowsItem.Index = 6
        Me.ViewDebugWindowsItem.Shortcut = System.Windows.Forms.Shortcut.F6
        Me.ViewDebugWindowsItem.Text = "Simulation &Debug Windows"
        '
        'ViewSimulationNetworkItem
        '
        Me.ViewSimulationNetworkItem.Index = 7
        Me.ViewSimulationNetworkItem.Shortcut = System.Windows.Forms.Shortcut.F7
        Me.ViewSimulationNetworkItem.Text = "Simulation &Network"
        '
        'ViewAnimationWindowItem
        '
        Me.ViewAnimationWindowItem.Index = 8
        Me.ViewAnimationWindowItem.Shortcut = System.Windows.Forms.Shortcut.F8
        Me.ViewAnimationWindowItem.Text = "&Simulation Animation Window"
        '
        'ViewSeparator3
        '
        Me.ViewSeparator3.Index = 9
        Me.ViewSeparator3.Text = "-"
        '
        'ViewSelectCurvesItem
        '
        Me.ViewSelectCurvesItem.Index = 10
        Me.ViewSelectCurvesItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewShowFirstCurveItem, Me.ViewShowNextCurveItem, Me.ViewShowLastCurveItem, Me.ViewShowPrevCurveItem, Me.ViewShowAllCurvesItem})
        Me.ViewSelectCurvesItem.Text = "Select Graph &Curves"
        '
        'ViewShowFirstCurveItem
        '
        Me.ViewShowFirstCurveItem.Index = 0
        Me.ViewShowFirstCurveItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftF
        Me.ViewShowFirstCurveItem.Text = "Show &first curve"
        '
        'ViewShowNextCurveItem
        '
        Me.ViewShowNextCurveItem.Index = 1
        Me.ViewShowNextCurveItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftN
        Me.ViewShowNextCurveItem.Text = "Show &next curve"
        '
        'ViewShowLastCurveItem
        '
        Me.ViewShowLastCurveItem.Index = 2
        Me.ViewShowLastCurveItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftL
        Me.ViewShowLastCurveItem.Text = "Show &last curve"
        '
        'ViewShowPrevCurveItem
        '
        Me.ViewShowPrevCurveItem.Index = 3
        Me.ViewShowPrevCurveItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftP
        Me.ViewShowPrevCurveItem.Text = "Show &prev curve"
        '
        'ViewShowAllCurvesItem
        '
        Me.ViewShowAllCurvesItem.Index = 4
        Me.ViewShowAllCurvesItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftA
        Me.ViewShowAllCurvesItem.Text = "Show &all curves"
        '
        'WorldMenu
        '
        Me.WorldMenu.Index = 3
        Me.WorldMenu.Text = "&World"
        '
        'HelpMenu
        '
        Me.HelpMenu.Index = 4
        Me.HelpMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.HelpWhatsThisItem, Me.HelpSeparator1, Me.ViewPdfManualItem})
        Me.HelpMenu.Text = "&Help"
        '
        'HelpWhatsThisItem
        '
        Me.HelpWhatsThisItem.Index = 0
        Me.HelpWhatsThisItem.Text = "&What's This?"
        '
        'HelpSeparator1
        '
        Me.HelpSeparator1.Index = 1
        Me.HelpSeparator1.Text = "-"
        '
        'ViewPdfManualItem
        '
        Me.ViewPdfManualItem.Index = 2
        Me.ViewPdfManualItem.Text = "&View PDF Manual"
        '
        'WorldToolbar
        '
        Me.WorldToolbar.AccessibleDescription = "Contains buttons for quick access to commonly used functions."
        Me.WorldToolbar.AccessibleName = "Tool Bar"
        Me.WorldToolbar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.WorldToolbar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.SaveButton, Me.PrintButton, Me.ToolBarSeparator1, Me.UndoButton, Me.RedoButton, Me.ToolBarSeparator2, Me.ViewProjectWindowButton, Me.ToolBarSeparator3, Me.WhatsThisButton, Me.ToolBarSeparator4})
        Me.WorldToolbar.DropDownArrows = True
        Me.WorldToolbar.ImageList = Me.ToolbarImageList
        Me.WorldToolbar.Location = New System.Drawing.Point(0, 0)
        Me.WorldToolbar.Name = "WorldToolbar"
        Me.WorldToolbar.ShowToolTips = True
        Me.WorldToolbar.Size = New System.Drawing.Size(792, 28)
        Me.WorldToolbar.TabIndex = 0
        '
        'SaveButton
        '
        Me.SaveButton.ImageIndex = 0
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.ToolTipText = "Save File"
        '
        'PrintButton
        '
        Me.PrintButton.ImageIndex = 1
        Me.PrintButton.Name = "PrintButton"
        Me.PrintButton.ToolTipText = "Print Results"
        '
        'ToolBarSeparator1
        '
        Me.ToolBarSeparator1.Name = "ToolBarSeparator1"
        Me.ToolBarSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'UndoButton
        '
        Me.UndoButton.DropDownMenu = Me.UndoContextMenu
        Me.UndoButton.ImageIndex = 2
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.UndoButton.ToolTipText = "Undo"
        '
        'UndoContextMenu
        '
        '
        'RedoButton
        '
        Me.RedoButton.DropDownMenu = Me.RedoContextMenu
        Me.RedoButton.ImageIndex = 3
        Me.RedoButton.Name = "RedoButton"
        Me.RedoButton.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.RedoButton.ToolTipText = "Redo"
        '
        'RedoContextMenu
        '
        '
        'ToolBarSeparator2
        '
        Me.ToolBarSeparator2.Name = "ToolBarSeparator2"
        Me.ToolBarSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ViewProjectWindowButton
        '
        Me.ViewProjectWindowButton.ImageIndex = 4
        Me.ViewProjectWindowButton.Name = "ViewProjectWindowButton"
        Me.ViewProjectWindowButton.ToolTipText = "View Project Management Window"
        '
        'ToolBarSeparator3
        '
        Me.ToolBarSeparator3.Name = "ToolBarSeparator3"
        Me.ToolBarSeparator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'WhatsThisButton
        '
        Me.WhatsThisButton.ImageIndex = 5
        Me.WhatsThisButton.Name = "WhatsThisButton"
        Me.WhatsThisButton.ToolTipText = "What's This Help"
        '
        'ToolBarSeparator4
        '
        Me.ToolBarSeparator4.Name = "ToolBarSeparator4"
        Me.ToolBarSeparator4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ToolbarImageList
        '
        Me.ToolbarImageList.ImageStream = CType(resources.GetObject("ToolbarImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ToolbarImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ToolbarImageList.Images.SetKeyName(0, "")
        Me.ToolbarImageList.Images.SetKeyName(1, "")
        Me.ToolbarImageList.Images.SetKeyName(2, "")
        Me.ToolbarImageList.Images.SetKeyName(3, "")
        Me.ToolbarImageList.Images.SetKeyName(4, "")
        Me.ToolbarImageList.Images.SetKeyName(5, "")
        '
        'WorldStatusBar
        '
        Me.WorldStatusBar.AccessibleDescription = "Contains usage & run status and the current User Level."
        Me.WorldStatusBar.AccessibleName = "Status Bar"
        Me.WorldStatusBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorldStatusBar.Location = New System.Drawing.Point(0, 531)
        Me.WorldStatusBar.Name = "WorldStatusBar"
        Me.WorldStatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.WorldStatusPanel, Me.ProgressBarPanel, Me.UserLevelPanel})
        Me.WorldStatusBar.ShowPanels = True
        Me.WorldStatusBar.Size = New System.Drawing.Size(792, 22)
        Me.WorldStatusBar.TabIndex = 1
        Me.WorldStatusBar.Text = "StatusBar"
        '
        'WorldStatusPanel
        '
        Me.WorldStatusPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.WorldStatusPanel.Name = "WorldStatusPanel"
        Me.WorldStatusPanel.ToolTipText = "WinSRFR Status"
        Me.WorldStatusPanel.Width = 547
        '
        'ProgressBarPanel
        '
        Me.ProgressBarPanel.Name = "ProgressBarPanel"
        Me.ProgressBarPanel.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw
        Me.ProgressBarPanel.ToolTipText = "Run Progress"
        Me.ProgressBarPanel.Width = 73
        '
        'UserLevelPanel
        '
        Me.UserLevelPanel.MinWidth = 100
        Me.UserLevelPanel.Name = "UserLevelPanel"
        Me.UserLevelPanel.Text = "Level: Standard"
        Me.UserLevelPanel.Width = 155
        '
        'StatusImageList
        '
        Me.StatusImageList.ImageStream = CType(resources.GetObject("StatusImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.StatusImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.StatusImageList.Images.SetKeyName(0, "")
        Me.StatusImageList.Images.SetKeyName(1, "")
        Me.StatusImageList.Images.SetKeyName(2, "")
        '
        'StatusIcon
        '
        Me.StatusIcon.AccessibleDescription = "A copyable bitmap image"
        Me.StatusIcon.AccessibleName = "Bitmap Diagram"
        Me.StatusIcon.Image = CType(resources.GetObject("StatusIcon.Image"), System.Drawing.Image)
        Me.StatusIcon.Location = New System.Drawing.Point(768, 8)
        Me.StatusIcon.Name = "StatusIcon"
        Me.StatusIcon.Size = New System.Drawing.Size(16, 16)
        Me.StatusIcon.TabIndex = 9
        Me.StatusIcon.TabStop = False
        Me.StatusIcon.Text = "Bitmap Diagram"
        '
        'TitleBox
        '
        Me.TitleBox.AccessibleDescription = "Displays the identification for this WinSRFR World."
        Me.TitleBox.AccessibleName = "WinSRFR World Identification"
        Me.TitleBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TitleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TitleBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitleBox.Location = New System.Drawing.Point(0, 28)
        Me.TitleBox.Name = "TitleBox"
        Me.TitleBox.ReadOnly = True
        Me.TitleBox.Size = New System.Drawing.Size(792, 40)
        Me.TitleBox.TabIndex = 2
        Me.TitleBox.TabStop = False
        Me.TitleBox.Text = ""
        '
        'WorldPanel
        '
        Me.WorldPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorldPanel.Location = New System.Drawing.Point(0, 68)
        Me.WorldPanel.Name = "WorldPanel"
        Me.WorldPanel.Size = New System.Drawing.Size(792, 463)
        Me.WorldPanel.TabIndex = 10
        '
        'UsdaLabel
        '
        Me.UsdaLabel.AutoSize = True
        Me.UsdaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsdaLabel.Location = New System.Drawing.Point(595, 6)
        Me.UsdaLabel.Name = "UsdaLabel"
        Me.UsdaLabel.Size = New System.Drawing.Size(161, 17)
        Me.UsdaLabel.TabIndex = 11
        Me.UsdaLabel.Text = "USDA / ARS / ALARC"
        '
        'WorldWindow
        '
        Me.AccessibleDescription = "Window for a WinSRFR World."
        Me.AccessibleName = "WinSRFR World Window"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 553)
        Me.Controls.Add(Me.UsdaLabel)
        Me.Controls.Add(Me.WorldPanel)
        Me.Controls.Add(Me.TitleBox)
        Me.Controls.Add(Me.StatusIcon)
        Me.Controls.Add(Me.WorldStatusBar)
        Me.Controls.Add(Me.WorldToolbar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.WorldMainMenu
        Me.MinimumSize = New System.Drawing.Size(500, 400)
        Me.Name = "WorldWindow"
        Me.Text = "WinSRFR - World Window"
        CType(Me.WorldStatusPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserLevelPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Member Data "
    '
    ' References passed or derived via initialization
    '
    Protected WithEvents mWinSRFR As WinSRFR
    Protected WithEvents mFarm As Farm
    Protected WithEvents mField As Field
    Protected WithEvents mWorld As World

    Protected mDictionary As Dictionary = Dictionary.Instance
    Protected mMyStore As DataStore.ObjectNode

    Protected WithEvents mUnitControl As UnitControl
    Protected WithEvents mSystemGeometry As SystemGeometry
    Protected WithEvents mSoilCropProperties As SoilCropProperties
    Protected WithEvents mInflowManagement As InflowManagement
    Protected WithEvents mEventCriteria As EventCriteria
    Protected WithEvents mSubsurfaceFlow As SubsurfaceFlow
    Protected WithEvents mSurfaceFlow As SurfaceFlow
    Protected WithEvents mSrfrCriteria As SrfrCriteria
    Protected WithEvents mErosion As Erosion
    Protected WithEvents mFertigation As Fertigation

    Protected WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    '
    ' Windows messages redefined from WinUser.h
    '
    Protected Const HTCLIENT As Integer = &H1
    Protected Const HTCAPTION As Integer = &H2
    Protected Const WM_WINDOWPOSCHANGING As Integer = &H46
    Protected Const WM_NCLBUTTONDOWN As Integer = &HA1

    Protected Const WM_MOUSEMOVE As Integer = &H200
    Protected Const WM_LBUTTONDOWN As Integer = &H201
    Protected Const WM_LBUTTONUP As Integer = &H202
    Protected Const WM_LBUTTONDBLCLK As Integer = &H203
    Protected Const WM_RBUTTONDOWN As Integer = &H204
    Protected Const WM_RBUTTONUP As Integer = &H205
    Protected Const WM_RBUTTONDBLCLK As Integer = &H206
    Protected Const WM_MBUTTONDOWN As Integer = &H207
    Protected Const WM_MBUTTONUP As Integer = &H208
    Protected Const WM_MBUTTONDBLCLK As Integer = &H209
    '
    ' UI support
    '
    Protected mWhatsThisHelp As Boolean = False
    Protected mResultsAreValid As Boolean = False
    Protected mWindowSizeSet As Boolean = False

    Protected FileMenuPopupSeparator As MenuItem = New MenuItem("-")
    Protected EditMenuPopupSeparator As MenuItem = New MenuItem("-")

    Protected mWorldWindowState As Windows.Forms.FormWindowState
    Protected mProgressBar As ProgressBar = New ProgressBar
    Protected mOldCursor As Cursor

    Protected WithEvents mScriptRecorder As ScriptRecorder
    Public ReadOnly Property ScriptRecorder() As ScriptRecorder
        Get
            Return mScriptRecorder
        End Get
    End Property
    '
    ' Status Icon indeces
    '
    Protected Enum StatusIcons
        NoResults
        Warning
        Results
    End Enum

    '*********************************************************************************************************
    ' SRFR Irrigation Animation Data
    '
    Protected WithEvents mSolutionModel As Srfr.SolutionModel
    Protected mIrrigationAnimation As DataSet
    Protected mAnimationFrame As DataTable

    Protected mMaxInfiltration As Double
    Protected mMaxErosion As Double

#End Region

#Region " SRFR Access "

    ' SRFR API
    Private mSrfrAPI As Srfr.SrfrAPI
    Protected Friend Function SrfrAPI() As Srfr.SrfrAPI
        Return mSrfrAPI
    End Function

    Protected Friend Function SimulationAvailable(ByVal SimName As String) As Boolean
        SimulationAvailable = False

        If (mSrfrAPI IsNot Nothing) Then ' Reference to SRFR API available; has simulation been run?
            Dim srfrIrrigation As Srfr.Irrigation = mSrfrAPI.Irrigation
            If (srfrIrrigation IsNot Nothing) Then ' Simulation run available; is it the right one?
                If (mSrfrAPI.SimName = SimName) Then ' Yes
                    SimulationAvailable = True
                End If
            End If
        End If

    End Function

    Protected Friend Sub ClearSrfrResults()
        If (mSrfrAPI IsNot Nothing) Then
            Dim irrigation As Srfr.Irrigation = mSrfrAPI.Irrigation
            If (irrigation IsNot Nothing) Then
                irrigation.ClearResults()
            End If
        End If
    End Sub

    ' SRFR Debug / Network Viewers
    Private mIrrigationViewer As Srfr.IrrigationViewer
    Protected Function IrrigationViewer() As Srfr.IrrigationViewer
        Return mIrrigationViewer
    End Function

    Private mStreamViewer As Srfr.StreamViewer
    Protected Function StreamViewer() As Srfr.StreamViewer
        Return mStreamViewer
    End Function

    Private mCellViewer As Srfr.CellViewer
    Protected Function CellViewer() As Srfr.CellViewer
        Return mCellViewer
    End Function

    Private mHydrographViewer As Srfr.HydrographViewer
    Protected Function HydrographViewer() As Srfr.HydrographViewer
        Return mHydrographViewer
    End Function

    Private mProfileViewer As Srfr.ProfileViewer
    Protected Function ProfileViewer() As Srfr.ProfileViewer
        Return mProfileViewer
    End Function

    ' SRFR Animation Viewer
    Private mAnimationViewer As Srfr.AnimationViewer
    Protected Friend Function AnimationViewer() As Srfr.AnimationViewer
        Return mAnimationViewer
    End Function

#End Region

#Region " Properties "
    '
    ' The WinSRFR Application
    '
    Public ReadOnly Property WinSrfr() As WinSRFR
        Get
            Return mWinSRFR
        End Get
    End Property
    '
    ' The Unit currently being displayed by this window
    '
    Protected WithEvents mUnit As Unit
    Public ReadOnly Property DisplayedUnit() As Unit
        Get
            Return mUnit
        End Get
    End Property
    '
    ' Currently Selected Analysis
    '
    Protected mAnalysis As Analysis
    Public Overridable ReadOnly Property CurrentAnalysis() As Analysis
        Get
            Return mAnalysis
        End Get
    End Property
    '
    ' Water Distribution Diagram Dialog Box
    '
    Protected mWDD As WaterDistributionDiagram
    Public Property WDD() As WaterDistributionDiagram
        Get
            Return mWDD
        End Get
        Set(ByVal Value As WaterDistributionDiagram)
            mWDD = Value
        End Set
    End Property
    '
    ' Design / Contour overlay selections
    '
    Protected mContourOverlay As BorderContourOverlay
    Public ReadOnly Property ContourOverlay() As BorderContourOverlay
        Get
            Return mContourOverlay
        End Get
    End Property
    '
    ' Execution run state & progress
    '
    Protected mRunning As Boolean = False
    Public Property Running() As Boolean
        Get
            Return mRunning
        End Get
        Set(ByVal Value As Boolean)
            mRunning = Value
        End Set
    End Property

    Protected mRunProgress As Integer
    Public Property RunProgress() As Integer
        Get
            Return mRunProgress
        End Get
        Set(ByVal Value As Integer)
            mRunProgress = Value
            ProgressBarPanel.Style = StatusBarPanelStyle.OwnerDraw
            With mProgressBar
                .Show()
                .Minimum = 0
                .Step = 10
                .Maximum = 100
                .Value = mRunProgress
            End With
        End Set
    End Property

    ' The SRFR thread control must have a form parent so InvokeRequired & Invoke work
    ' They both need a Windows Handle which WorldWindow has
    Protected WithEvents mSrfrThreadingControl As SrfrThreadingControl
    Public ReadOnly Property SrfrThreadingControl As SrfrThreadingControl
        Get
            Return mSrfrThreadingControl
        End Get
    End Property
    '
    ' Status Bar's messages
    '
    Public Property WorldStatusMessage() As String
        Get
            Return WorldStatusPanel.Text
        End Get
        Set(ByVal Value As String)
            WorldStatusPanel.Text = Value
            Dim obj As Object = ActiveForm
            If (obj Is Nothing) Then ' there is no Active Form for this Application, so...
                Application.DoEvents() ' keep the UI updating (i.e. re-painting)
            ElseIf (obj Is AnimationViewer()) Then
                Application.DoEvents() ' keep the UI updating (i.e. re-painting)
            ElseIf ((AnimationViewer.Visible) And (mRunning)) Then
                AnimationViewer.Activate()
            End If
        End Set
    End Property

    Public Property ProgressMessage() As String
        Get
            Return ProgressBarPanel.Text
        End Get
        Set(ByVal Value As String)
            mProgressBar.Hide()
            ProgressBarPanel.Style = StatusBarPanelStyle.Text
            ProgressBarPanel.Text = Value
        End Set
    End Property
    '
    ' Override this property to implement Results View
    '
    Protected mResultsView As ResultsViews = Globals.ResultsViews.GraphsOnly
    Protected Overridable Property ResultsView() As ResultsViews
        Get
            Return mResultsView
        End Get
        Set(ByVal Value As ResultsViews)
            mResultsView = Value
        End Set
    End Property
    '
    ' Fixed width fonts to use by UI
    '
    Protected mFixedFontName As String = "Courier New"
    Protected mFixedFontSize As Single = 11.0!

    Protected mFixedFontWidth As Single = 104.619339!       ' Sizes based on "Courier New", 11.0! string
    Protected mFixedFontHeight As Single = 18.4479122!

    Public ReadOnly Property FixedFont() As Font
        Get
            ' Create un-scaled Font
            FixedFont = New Font(mFixedFontName, mFixedFontSize, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

            ' Determine if scaling might be necessary to accomodate current DPI resolution
            Dim _bitmap As Bitmap = New Bitmap(10, 10)
            Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

            Dim regSize As SizeF = _graphics.MeasureString(mFixedFontName, FixedFont)

            Dim scaledWidth As Single = Math.Round((mFixedFontWidth * mFixedFontSize / regSize.Width), 3)
            Dim scaledHeight As Single = Math.Round((mFixedFontHeight * mFixedFontSize / regSize.Height), 3)
            Debug.Assert(scaledWidth = scaledHeight)

            ' Create DPI scaled Font
            FixedFont = New Font(mFixedFontName, scaledWidth, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        End Get
    End Property

    Public ReadOnly Property FixedBold() As Font
        Get
            Dim fixedRegular As Font = Me.FixedFont
            FixedBold = New Font(fixedRegular, FontStyle.Bold)
        End Get
    End Property

#End Region

#Region " Initialization "
    '
    ' Called by New() to initialize the World Window
    '
    Protected Sub InitializeWorldWindow(ByVal _winSRFR As WinSRFR)

        ' Save reference to WinSRFR application
        If (_winSRFR IsNot Nothing) Then
            mWinSRFR = _winSRFR
        Else
            Debug.Assert(False, "WinSRFR is Nothing")
        End If

        'Me.AutoScaleMode = Windows.Forms.AutoScaleMode.Dpi

        ' Merge derived Window's MainMenu, if one exists, into the base MainMenu
        If Not (Me.Menu Is Me.WorldMainMenu) Then
            ' Scan each base menu in the MainMenu looking for its derived mate
            For Each _worldMenu As MenuItem In Me.WorldMainMenu.MenuItems
                For Each _derivedMenu As MenuItem In Me.Menu.MenuItems
                    ' If menu names match, append derived menu to base menu
                    If (_worldMenu.Text = _derivedMenu.Text) Then
                        ' Append menu separator
                        If (0 < _worldMenu.MenuItems.Count) Then
                            _worldMenu.MenuItems.Add("-")
                        End If
                        ' Move derived menu items to base menu
                        While (0 < _derivedMenu.MenuItems.Count)
                            Dim _item As MenuItem = _derivedMenu.MenuItems(0)
                            If Not (_item Is Nothing) Then
                                _worldMenu.MenuItems.Add(_item)
                            End If
                        End While
                    End If
                Next
            Next
        End If

        ' Add the dynamic popup menu item separators
        Me.FileMenu.MenuItems.Add(Me.FileMenuPopupSeparator)
        Me.EditMenu.MenuItems.Add(Me.EditMenuPopupSeparator)

        ' Set the MainMenu to be this modified menu
        Me.Menu = Me.WorldMainMenu

        ' Add the ProgressBar to the StatusBar
        Me.WorldStatusBar.Controls.Add(mProgressBar)

        ' Instantiate the SRFR Threading Control
        mSrfrThreadingControl = New SrfrThreadingControl

        ' Instantiate the Border Contour Overlay dialog box
        mContourOverlay = New BorderContourOverlay(Nothing)

        ' Instantiate the translation dictionary
        mDictionary = Dictionary.Instance

        mWorldWindowState = Me.WindowState

        ' Instantiate API to SRFR
        NewSrfrAPI()

    End Sub
    '
    ' Instantiate a new SrfrAPI object
    '
    Friend Sub NewSrfrAPI()
        mSrfrAPI = Nothing
        Try
            mSrfrAPI = New Srfr.SrfrAPI

            If (mSrfrAPI Is Nothing) Then
                WinSrfr.CriticalError("InitializeWinSRFR[New Srfr.SrfrAPI]", "SrfrAPI Is Nothing")
            End If

            ' Instantiate the SRFR Animation Viewer(s)
            mAnimationViewer = New Srfr.AnimationViewer()
            AnimationViewer.InitializeAnimationViewer("SRFR " & mDictionary.tSimulationAnimation.Translated)

        Catch ex As Exception
            WinSrfr.CriticalException("InitializeWinSRFR[New Srfr.SrfrAPI]", ex)
            mSrfrAPI = Nothing
        End Try
    End Sub
    '
    ' Display the World Window for the specified Unit
    '
    Public Overridable Sub DisplayWorldWindow(ByVal _unit As Unit)

        If (Me.WDD IsNot Nothing) Then
            Me.WDD.Hide()
            Me.WDD.Dispose()
            Me.WDD = Nothing
        End If

        If (_unit IsNot Nothing) Then
            ' Save references to Unit & its containing object
            mUnit = _unit
            mWorld = mUnit.WorldRef
            mField = mWorld.FieldRef
            mFarm = mField.FarmRef

            Debug.Assert(mWinSRFR Is mFarm.WinSrfrRef, "WinSRFR References don't match")

            ' Get a reference to this Unit's DataStore
            mMyStore = mUnit.MyStore

            mUnitControl = mUnit.UnitControlRef
            mSystemGeometry = mUnit.SystemGeometryRef
            mSoilCropProperties = mUnit.SoilCropPropertiesRef
            mInflowManagement = mUnit.InflowManagementRef
            mEventCriteria = mUnit.EventCriteriaRef
            mErosion = mUnit.ErosionRef
            mFertigation = mUnit.FertigationRef
            mSubsurfaceFlow = mUnit.SubsurfaceFlowRef
            mSurfaceFlow = mUnit.SurfaceFlowRef
            mSrfrCriteria = mUnit.SrfrCriteriaRef

            ' Add enumerations from radio button controls within World Window
            Dim crossSection As PropertyNode = mSystemGeometry.CrossSectionProperty
            Dim sel As String = mSystemGeometry.GetFirstCrossSectionSelection
            Dim idx As Integer = 0
            crossSection.ClearEnums()
            While (sel IsNot Nothing)
                If Not (sel = String.Empty) Then
                    crossSection.AddEnumItem(sel, idx, True)
                End If
                sel = mSystemGeometry.GetNextCrossSectionSelection
                idx += 1
            End While

            Dim downstream As PropertyNode = mSystemGeometry.DownstreamConditionProperty
            sel = mSystemGeometry.GetFirstDownstreamConditionSelection
            idx = 0
            downstream.ClearEnums()
            While (sel IsNot Nothing)
                If Not (sel = String.Empty) Then
                    downstream.AddEnumItem(sel, idx, True)
                End If
                sel = mSystemGeometry.GetNextDownstreamConditionSelection
                idx += 1
            End While

            ' Display initial status message
            WorldStatusMessage = "===> " & mDictionary.tProceedDownTabs.Translated & " ===>"
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If

    End Sub

    Public Overridable Sub ShowWorldWindow()
        ' Show the window at its previous size / location
        If (Me.WindowState = FormWindowState.Minimized) Then
            Me.WindowState = mWorldWindowState
        End If

        Me.Show()
        Me.Activate()
        Me.BringToFront()
        'Me.RefreshUI()
    End Sub

#End Region

#Region " Methods "

#Region " User Interface "
    '
    ' Update the World's UI
    '
    Public Overridable Sub UpdateUI()

        If (mUnit IsNot Nothing) Then

            ' Display Farm/Field & World/Analysis ID in the Title Box
            TitleBox.Clear()
            TitleBox.SelectionAlignment = HorizontalAlignment.Center

            AppendFieldIdText(TitleBox, mUnit, 120)     ' Farm/Field | Project/Case
            AdvanceLine(TitleBox)
            AppendUnitIdText(TitleBox, mUnit, 120)      ' World/Analysis

            ' Display User Level in the Status Bar
            Me.UserLevelPanel.Text = mDictionary.tLevel.Translated & ": " + UserLevelText(mWinSRFR.UserLevel)

            ' Fix Window Size for (800, 200) selection
            Select Case mWinSRFR.WindowSize
                Case WindowSizes.S800x600
                    If (Me.Size = New Size(800, 620)) Then
                        Me.Size = New Size(800, 600)
                    End If
            End Select
        End If

    End Sub
    '
    ' Refresh the World's UI
    '
    Public Overridable Sub RefreshUI()
        UpdateUI()
        For Each control As Control In Me.Controls
            Me.UpdateControls(control)
        Next
    End Sub

    Public Overridable Sub UpdateSetupErrorsWarnings()
    End Sub

#End Region

#Region " Execution "
    '
    ' Code that should be run at the start/end of a Run
    '
    ' Note - No changes to DataStore should be made in StartRun().
    '
    Public Sub StartRun()
        '
        ' Draw Focus away from other UI controls; this forces the LostFocus event to occur
        ' on any control that had Focus causing it to update & enter its input
        '
        Me.StatusIcon.Focus()
        '
        ' Save current cursor & display the wait (hourglass) cursor while Run is executing
        '
        mOldCursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor
        '
        ' Take down Water Distribution Diagram, if it is being displayed
        '
        If (mWDD IsNot Nothing) Then
            mWDD.Close()
            mWDD = Nothing
        End If
        '
        ' Take down the SRFR Diagnostic & Network Viewers, if they are being displayed
        '
        DeleteDebugViewers()
        DeleteNetworkViewers()
        '
        ' Clear all Execution Errors and/or Warnings
        '
        CurrentAnalysis.ClearExecutionErrors()
        CurrentAnalysis.ClearExecutionWarnings()

    End Sub

    Public Sub EndRun()
        ' Take done wait (hourglass) cursor by restoring saved cursor
        Me.Cursor = mOldCursor
    End Sub
    '
    ' Calculate the Analysis Solution
    '
    Public Overridable Sub CalculateSolution()
        ' Calculate the Analysis' Solution
        CurrentAnalysis.Running = True
        CurrentAnalysis.CalculateSolution()
        CurrentAnalysis.Running = False
        ' Save new Run Time
        Dim runTime As DateTimeParameter = mUnit.UnitControlRef.RunDateTime
        runTime.Value = System.DateTime.Now
        runTime.Source = DataStore.Globals.ValueSources.Calculated
        mUnit.UnitControlRef.RunDateTime = runTime
        ' All values are known
        SetKnown()
        ' Re-display the results
        UpdateResultsControls()
    End Sub
    '
    ' Set all calculatable parameters to 'Known'
    '
    Protected Overridable Sub SetKnown()

        ' Set all parameters to known
        mSystemGeometry.LengthProperty.ToBeCalculated = False
        mSystemGeometry.WidthProperty.ToBeCalculated = False
        mSystemGeometry.FurrowsPerSetProperty.ToBeCalculated = False

        mInflowManagement.CutoffLocationRatioProperty.ToBeCalculated = False
        mInflowManagement.CutoffTimeProperty.ToBeCalculated = False
        mInflowManagement.CutbackTimeRatioProperty.ToBeCalculated = False
        mInflowManagement.InflowRateProperty.ToBeCalculated = False

        mSubsurfaceFlow.DUProperty.ToBeCalculated = False
        mSubsurfaceFlow.DUlqProperty.ToBeCalculated = False
        mSubsurfaceFlow.DUminProperty.ToBeCalculated = False

    End Sub

#End Region

#Region " Toolbar & Status Bar "
    '
    ' Update the Toolbar icons
    '
    Protected Overridable Sub UpdateToolbar()
        If Not ((mWinSRFR Is Nothing) And (mUnit Is Nothing)) Then
            ' Update the 'available' appearance of the Toolbar buttons
            Me.SaveButton.Enabled = mWinSRFR.DataHasChanged
            Me.UndoButton.Enabled = mMyStore.CanUndo()
            Me.RedoButton.Enabled = mMyStore.CanRedo()

            ' Also update the Project Management Window's Toolbar
            mWinSRFR.UpdateToolbar()
        End If
    End Sub
    '
    ' Update the Status Bar message
    '
    Protected Overridable Sub UpdateStatusBar()
        If Not (mUnit Is Nothing) Then
            ' Are the results valid?
            If (mUnit.ResultsAreValid) Then
                If (0 = mUnit.PerformanceResultsRef.ErrorCount.Value) Then
                    Me.StatusIcon.Image = StatusImageList.Images(StatusIcons.Results)
                    Me.StatusIcon.AccessibleName = mDictionary.tResultsAreAvailable.Translated
                    Me.StatusIcon.AccessibleDescription = mDictionary.tViewUsingResultsTab.Translated
                Else
                    Me.StatusIcon.Image = StatusImageList.Images(StatusIcons.Warning)
                    Me.StatusIcon.AccessibleName = mDictionary.tErrOccurredDuringRun.Translated
                    Me.StatusIcon.AccessibleDescription = mDictionary.tViewUsingResultsTab.Translated
                End If
            Else
                Me.StatusIcon.Image = StatusImageList.Images(StatusIcons.NoResults)
                Me.StatusIcon.AccessibleName = mDictionary.tNoResultsAreAvailable.Translated
                Me.StatusIcon.AccessibleDescription = mDictionary.tRunAnalysisToGenerateResults.Translated
                RunProgress = 0
            End If

            ' Update tooltip to match current Status Icon
            Dim _msg As String = Me.StatusIcon.AccessibleName + "; " _
                               + Me.StatusIcon.AccessibleDescription

            Me.StatusIcon.ToolTip.SetToolTip(StatusIcon, _msg)
            Me.StatusIcon.ToolTip.AutoPopDelay = 5000

            ' If changed, set the new Results Are Valid state
            If Not (mResultsAreValid = mUnit.ResultsAreValid) Then
                WorldStatusMessage = _msg
            End If
        End If
    End Sub
    '
    ' Update the Results Controls & Status Messages
    '
    Public Overridable Sub UpdateResultsControls()
        UpdateToolbar()
        UpdateStatusBar()
    End Sub

#End Region

#Region " Printing "

    '*********************************************************************************************************
    ' Override these methods to implement Print & Print Preview
    '*********************************************************************************************************
    Protected Overridable Sub Print(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Protected Overridable Sub PrintPreview(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    '*********************************************************************************************************
    ' Function PrintResults() - common function across all worlds for displaying the PrintDialog
    '
    ' Input(s):     PrintDialog     - the specific Print Dialog unique to each derived world
    '               CurrentPage     - page number for the CurrentPage option
    '               PageRange()     - 2 entry array containing the First/Last page numbers to print
    '
    ' Output(s):    PageRange()     - array containing the selected page numbers to print
    '
    ' Returns:      Boolean         - True if print selection is valid
    '*********************************************************************************************************
    Friend Function PrintResults(ByVal PrintDialog As Forms.PrintDialog, ByVal CurrentPage As Integer,
                                 ByRef PageRange() As Integer) As Boolean

        If ((PrintDialog Is Nothing) Or (PageRange.Length < 2)) Then ' invalid parameters
            Debug.Assert(False)
            Return False
        End If

        ' Start with full page range
        Dim FromPage As Integer = PageRange(0)
        Dim ToPage As Integer = PageRange(1)

        If (ToPage < FromPage) Then ' there is nothing to print
            Return False
        End If

        ' Display the PrintDialog
        PrintDialog.UseEXDialog = True
        PrintDialog.AllowCurrentPage = True
        PrintDialog.AllowPrintToFile = True
        PrintDialog.AllowSelection = True
        PrintDialog.AllowSomePages = True
        PrintDialog.PrinterSettings.FromPage = FromPage
        PrintDialog.PrinterSettings.ToPage = ToPage

        If (PrintDialog.ShowDialog() = DialogResult.OK) Then

            If (PrintDialog.PrinterSettings.PrintRange = PrintRange.AllPages) Then
                ' Full range of pages
                ReDim PageRange(ToPage - FromPage)
                For pdx As Integer = 0 To PageRange.Length - 1
                    PageRange(pdx) = FromPage + pdx
                Next pdx

            ElseIf (PrintDialog.PrinterSettings.PrintRange = PrintRange.SomePages) Then
                ' Start of range
                If (0 < PrintDialog.PrinterSettings.FromPage) Then
                    If (PrintDialog.PrinterSettings.FromPage <= ToPage) Then
                        FromPage = PrintDialog.PrinterSettings.FromPage
                    End If
                End If
                ' End of range
                If (0 < PrintDialog.PrinterSettings.ToPage) Then
                    If (PrintDialog.PrinterSettings.ToPage <= ToPage) Then
                        ToPage = PrintDialog.PrinterSettings.ToPage
                    End If
                End If
                ' Order range correctly
                If (ToPage < FromPage) Then
                    Swap(ToPage, FromPage)
                End If

                ' Partial range of pages
                ReDim PageRange(ToPage - FromPage)
                For pdx As Integer = 0 To PageRange.Length - 1
                    PageRange(pdx) = FromPage + pdx
                Next pdx

            ElseIf (PrintDialog.PrinterSettings.PrintRange = PrintRange.Selection) Then
                ' Range is a set of pages
                Dim getSelection As db_GetStringValue = New db_GetStringValue("")
                getSelection.Title = mDictionary.tPrintSelection.Translated
                getSelection.Instructions = mDictionary.tEnterPageSelection.Translated & "  "
                getSelection.Instructions &= mDictionary.tExample.Translated & ":  1,3,5-7"

                While (True)
                    Dim dlgResults As DialogResult = getSelection.ShowDialog()
                    If (dlgResults = Forms.DialogResult.OK) Then
                        ' Validate selection; Exit Try when error is found
                        Try
                            Dim selection As String = getSelection.Value.Trim
                            Dim ranges() As String = selection.Split(",")

                            ReDim PageRange(-1)
                            For Each range As String In ranges
                                range = range.Trim
                                If (range = "") Then ' nothing between ,,
                                    Exit Try
                                Else
                                    Dim pages() As String = range.Split("-")
                                    If (pages.Length = 0) Then ' only a '-'
                                        Exit Try
                                    ElseIf (pages.Length = 1) Then ' a single page
                                        Dim pageNo As Integer = Integer.Parse(pages(0))
                                        Dim numPages As Integer = PageRange.Length
                                        ReDim Preserve PageRange(numPages)
                                        PageRange(numPages) = pageNo
                                    ElseIf (pages.Length = 2) Then ' a page range
                                        Dim fromNo As Integer = Integer.Parse(pages(0))
                                        Dim toNo As Integer = Integer.Parse(pages(1))
                                        If (fromNo < toNo) Then
                                            For pdx As Integer = fromNo To toNo
                                                Dim numPages As Integer = PageRange.Length
                                                ReDim Preserve PageRange(numPages)
                                                PageRange(numPages) = pdx
                                            Next pdx
                                        ElseIf (fromNo = toNo) Then
                                            Dim numPages As Integer = PageRange.Length
                                            ReDim Preserve PageRange(numPages)
                                            PageRange(numPages) = fromNo
                                        Else ' toNo < fromNo
                                            Exit Try
                                        End If
                                    Else ' 3+ number in range
                                        Exit Try
                                    End If
                                End If
                            Next range

                            Exit While ' no errors in selections

                        Catch ex As Exception
                        End Try

                        getSelection.Instructions = mDictionary.tErrorPageSelection.Translated & "      "
                        getSelection.Instructions &= mDictionary.tExample.Translated & ":  1,3,5-7"

                    ElseIf (dlgResults = Forms.DialogResult.Cancel) Then
                        Return False
                    End If
                End While ' (True)

            ElseIf (PrintDialog.PrinterSettings.PrintRange = PrintRange.CurrentPage) Then
                ' Range is one page
                ReDim PageRange(0)
                PageRange(0) = CurrentPage
            End If

        Else ' not DialogResult.OK
            Return False
        End If

        Return True

    End Function

#End Region

#Region " SRFR Methods "
    '
    ' Dispose & delete all SRFR Debug Viewers
    '
    Public Sub DeleteDebugViewers()

        ' Delete the SRFR Diagnostics Viewers
        If (mIrrigationViewer IsNot Nothing) Then
            mIrrigationViewer.Close()
            mIrrigationViewer.Dispose()
            mIrrigationViewer = Nothing
        End If

        If (mStreamViewer IsNot Nothing) Then
            mStreamViewer.Close()
            mStreamViewer.Dispose()
            mStreamViewer = Nothing
        End If

        If (mCellViewer IsNot Nothing) Then
            mCellViewer.Close()
            mCellViewer.Dispose()
            mCellViewer = Nothing
        End If

    End Sub
    '
    ' Initialize all SRFR Debug Viewers
    '
    Public Sub InitDebugViewers()
        DeleteDebugViewers()

        mIrrigationViewer = New Srfr.IrrigationViewer
        mStreamViewer = New Srfr.StreamViewer
        mCellViewer = New Srfr.CellViewer
    End Sub
    '
    ' Dispose & delete all SRFR Computational Network Viewers
    '
    Public Sub DeleteNetworkViewers()

        ' Delete the SRFR Computational Network Viewers
        If (mIrrigationViewer IsNot Nothing) Then
            mIrrigationViewer.Close()
            mIrrigationViewer.Dispose()
            mIrrigationViewer = Nothing
        End If

        If (mHydrographViewer IsNot Nothing) Then
            mHydrographViewer.Close()
            mHydrographViewer.Dispose()
            mHydrographViewer = Nothing
        End If

        If (mProfileViewer IsNot Nothing) Then
            mProfileViewer.Close()
            mProfileViewer.Dispose()
            mProfileViewer = Nothing
        End If

    End Sub
    '
    ' Initialize all SRFR Computational Network Viewers
    '
    Public Sub InitNetworkViewers()
        DeleteNetworkViewers()

        mIrrigationViewer = New Srfr.IrrigationViewer
        mHydrographViewer = New Srfr.HydrographViewer
        mProfileViewer = New Srfr.ProfileViewer
    End Sub

#End Region

#End Region

#Region " SRFR Animation "

    Public Sub RemoveSrfrStatusHandler()
        If (mSolutionModel IsNot Nothing) Then
            RemoveHandler mSolutionModel.SrfrStatus, AddressOf SolutionModel_SrfrStatus
        End If
    End Sub

    Public Sub AddSrfrStatusHandler()
        If (mSolutionModel IsNot Nothing) Then
            AddHandler mSolutionModel.SrfrStatus, AddressOf SolutionModel_SrfrStatus
        End If
    End Sub

    '*********************************************************************************************************
    ' InitSrfrAnimation() - define data to be displayed by the SRFR Simulation Animation Viewer
    '*********************************************************************************************************
    Public Sub InitSrfrAnimation()
        '
        ' SrfrStatus event is handled by SolutionModel
        '
        RemoveSrfrStatusHandler()                           ' Remove SrfrStatus handler from old SolutionModel
        mSolutionModel = CurrentAnalysis.SolutionModel      ' Get new SolutionModel
        AddSrfrStatusHandler()                              ' Add SrfrStatus handler to new SolutionModel
        '
        ' Build new animation DataSet for the Animation View
        '
        If (mIrrigationAnimation IsNot Nothing) Then
            mIrrigationAnimation.Clear()
            mIrrigationAnimation.Dispose()
            mIrrigationAnimation = Nothing
        End If

        mIrrigationAnimation = New DataSet(mUnit.Name.Value)
        '
        ' Build DataTable structure for an animation frame
        '
        mAnimationFrame = New DataTable

        Dim lengthUnits As Units = mUnitsSystem.LengthUnits
        Dim lengthUnitsText As String = "(" & UnitsText(lengthUnits) & ")"

        Dim depthUnits As Units = mUnitsSystem.DepthUnits
        Dim depthUnitsText As String = "(" & UnitsText(depthUnits) & ")"

        Dim areaUnits As Units = mUnitsSystem.FlowAreaUnits
        Dim areaUnitsText As String = "(" & UnitsText(areaUnits) & ")"

        Dim flowUnits As Units = mUnitsSystem.FlowRateUnits
        Dim flowUnitsText As String = "(" & UnitsText(flowUnits) & ")"

        Dim rateUnits As Units = mUnitsSystem.DisplayUnits(Units.MetersPerSecond)
        Dim rateUnitsText As String = "(" & UnitsText(rateUnits) & ")"

        Dim velocityUnits As Units
        Dim velocityUnitsText As String
        If (mUnitsSystem.UnitSystem = UnitSystems.English) Then
            velocityUnits = Units.FeetPerHour
            velocityUnitsText = "(ft/hr)"
        Else ' Metric
            velocityUnits = Units.MetersPerHour
            velocityUnitsText = "(m/hr)"
        End If

        Dim column As DataColumn = Nothing

        ' 1st column is Distance down the field (X)
        Dim Xmin As Double = 0.0
        Dim Xmax As Double = UnitLength(mSystemGeometry.Length.Value, lengthUnits)
        Dim XcolTitle As String = mDictionary.tDistance.Translated & " " & lengthUnitsText
        column = New DataColumn(XcolTitle, GetType(Double))
        AddExtendedProperty(column, "Min", Xmin)
        AddExtendedProperty(column, "Max", Xmax)
        mAnimationFrame.Columns.Add(column)

        ' 2nd column is Flow Depth (Y)
        Dim MinDepth As Double = 0.0
        Dim MaxDepth As Double = UnitDepth(mSystemGeometry.Depth.Value, depthUnits)
        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
            MaxDepth = UnitDepth(mSystemGeometry.MaximumDepth.Value, depthUnits)
        End If
        Dim YcolTitle As String = mDictionary.tFlowDepth.Translated & " " & depthUnitsText
        column = New DataColumn(YcolTitle, GetType(Double))
        AddExtendedProperty(column, "Min", MinDepth)
        AddExtendedProperty(column, "Max", MaxDepth * 1.1)
        AddExtendedProperty(column, "HorzLine", MaxDepth)
        AddExtendedProperty(column, "HorzLineLabel", "Maximum Depth")
        AddExtendedProperty(column, "Fill", Drawing.Color.SkyBlue)
        mAnimationFrame.Columns.Add(column)

        ' Infiltrated Depth (Zwp)
        Dim Dreq As Double = UnitDepth(mInflowManagement.RequiredDepth.Value, depthUnits)
        Dim Zmin As Double = 0.0
        Dim Zmax As Double = Dreq
        Dim ZcolTitle As String = mDictionary.tInfiltratedDepth.Translated & " " & depthUnitsText
        column = New DataColumn(ZcolTitle, GetType(Double))
        AddExtendedProperty(column, "PosDown", True)
        AddExtendedProperty(column, "Min", Zmin)
        AddExtendedProperty(column, "Max", Zmax * 1.1)
        AddExtendedProperty(column, "HorzLine", Dreq)
        AddExtendedProperty(column, "HorzLineLabel", "Dreq")
        AddExtendedProperty(column, "Fill", Drawing.Color.Peru)
        AddExtendedProperty(column, "FillHL", Drawing.Color.Brown)
        mAnimationFrame.Columns.Add(column)

        ' Flow Elevation (H)
        Dim Hmin As Double = UnitLength(mSystemGeometry.MinimumElevation, lengthUnits)
        Dim Hmax As Double = Hmin + MaxDepth * 0.0011
        Dim HcolTitle As String = mDictionary.tWaterSurfaceElevation.Translated & " " & lengthUnitsText
        column = New DataColumn(HcolTitle, GetType(Double))
        AddExtendedProperty(column, "Min", Hmin)
        AddExtendedProperty(column, "Max", Hmax)
        AddExtendedProperty(column, "Curves", 1)      ' One additional Curve
        mAnimationFrame.Columns.Add(column)

        column = New DataColumn("Z0", GetType(Double))  ' Z0 (bottom elevation): additional Curve for H (flow elevation)
        mAnimationFrame.Columns.Add(column)

        ' Flow Rate (Q)
        Dim furrowsPerSet As Double = 1.0
        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
            furrowsPerSet = mSystemGeometry.FurrowsPerSet.Value
        End If
        Dim Qmin As Double = 0.0
        Dim Qmax As Double = UnitFlowRate(mInflowManagement.MaximumInflowRateForField / furrowsPerSet, flowUnits) * 1.1
        If (mSystemGeometry.UpstreamCondition.Value = UpstreamConditions.DrainbackAfterCutoff) Then
            Qmin = -Qmax
        End If
        Dim QcolTitle As String = mDictionary.tFlowRate.Translated & " " & flowUnitsText
        column = New DataColumn(QcolTitle, GetType(Double))
        AddExtendedProperty(column, "Min", Qmin)
        AddExtendedProperty(column, "Max", Qmax * 1.1)
        mAnimationFrame.Columns.Add(column)

        ' Velocity (V)
        Dim VcolTitle As String = mDictionary.tFlowVelocity.Translated & " " & velocityUnitsText
        column = New DataColumn(VcolTitle, GetType(Double))
        mAnimationFrame.Columns.Add(column)
        '
        ' Initialize the Animation Viewer
        '
        AnimationViewer.AnimationData = Nothing ' Will be set in SolutionModel_SrfrStatus()
        AnimationViewer.XMin = Xmin
        AnimationViewer.XMax = Xmax

        Dim graph1 As Srfr.AnimationViewer.Graph = New Srfr.AnimationViewer.Graph(YcolTitle, MinDepth, MaxDepth * 1.1)
        AnimationViewer.Graph1 = graph1

        Dim graph2 As Srfr.AnimationViewer.Graph = New Srfr.AnimationViewer.Graph(ZcolTitle, Zmin, Zmax * 1.1)
        AnimationViewer.Graph2 = graph2

        Dim graph3 As Srfr.AnimationViewer.Graph = New Srfr.AnimationViewer.Graph(QcolTitle, Qmin, Qmax * 1.1)
        AnimationViewer.Graph3 = graph3

        AnimationViewer.Graph3Enabled = False

        AnimationViewer.InitializeAnimationViewer("SRFR " & mDictionary.tSimulationAnimation.Translated)

    End Sub

    '*********************************************************************************************************
    ' Sub SolutionModel_SrfrStatus() - handler for SRFR Solution Model's SrfrStatus event
    '
    ' This event collects SRFR simulation data (timestep by timestep) to be displayed by the SRFR
    ' Animation Viewer.
    '
    ' The SrfrStatus event is generated after each Timestep's calculations have completed
    '*********************************************************************************************************
    Protected Sub SolutionModel_SrfrStatus(ByVal timestep As Srfr.Timestep)
        'Handles mSolutionModel.SrfrStatus

        Dim lengthUnits As Units = mUnitsSystem.LengthUnits
        Dim depthUnits As Units = mUnitsSystem.DepthUnits
        Dim areaUnits As Units = mUnitsSystem.FlowAreaUnits
        Dim flowUnits As Units = mUnitsSystem.FlowRateUnits
        Dim rateUnits As Units = mUnitsSystem.DisplayUnits(Units.MetersPerSecond)

        Dim velocityUnits As Units
        If (mUnitsSystem.UnitSystem = UnitSystems.English) Then
            velocityUnits = Units.FeetPerHour
        Else ' Metric
            velocityUnits = Units.MetersPerHour
        End If
        '
        ' Build & add the animation frame for Timestep
        '
        Dim frame As DataTable = mAnimationFrame.Clone
        Dim T As Double = timestep.T

        Dim name As String = mDictionary.tTimestep.Translated & " " & timestep.TimestepNumber.ToString _
                    & "; " & mDictionary.tTime.Translated & " = " & Srfr.Utilities.HHMMSSFF(T)
        frame.TableName = name
        AddExtendedProperty(frame, "Time", T)

        For Each tNode As Srfr.Node In timestep.Nodes
            Dim X As Double = UnitLength(tNode.X, lengthUnits)
            Dim Y As Double = UnitDepth(tNode.Y, depthUnits)
            Dim Zwp As Double = UnitDepth(tNode.Zwp, depthUnits)
            Dim H As Double = UnitLength(tNode.H, lengthUnits)
            Dim Z0 As Double = UnitLength(tNode.Z0, lengthUnits)
            Dim Q As Double = UnitFlowRate(tNode.Q, flowUnits)
            Dim V As Double = UnitVelocity(tNode.V, velocityUnits)

            Dim row As DataRow = frame.NewRow
            row(0) = X
            row(1) = Y
            row(2) = Zwp
            row(3) = H
            row(4) = Z0
            row(5) = Q
            row(6) = V
            frame.Rows.Add(row)
        Next

        mIrrigationAnimation.Tables.Add(frame)

        ' If not already done, initialize Animation Viewer's DataSet
        If (AnimationViewer.AnimationData Is Nothing) Then
            AnimationViewer.AnimationData = mIrrigationAnimation
            AnimationViewer.FrameNumber = 0
        End If

        AnimationViewer.FrameNumber = mIrrigationAnimation.Tables.Count - 1
        '
        ' If Animation Viewer is being displayed; have it show the newly added frame
        '
        If (AnimationViewer.Visible = True) Then
            AnimationViewer.UpdateUI()
        End If

    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' Farm changes
    '
    Private Sub Farm_Updated(ByVal _reason As Farm.Reasons) _
    Handles mFarm.FarmUpdated
        ' Did the containing Farm's Field list change?
        If (_reason = Farm.Reasons.FieldList) Then
            ' Yes, is this Field still in it?
            If (mField IsNot Nothing) Then
                If (mFarm.GetFieldByID(mField.MyID) IsNot mField) Then
                    ' No, this Window is no longer valid; hide it
                    Me.HideWindow()
                End If
            End If
        Else
            UpdateUI()
        End If
    End Sub
    '
    ' Field changes
    '
    Private Sub Field_Updated(ByVal _reason As Field.Reasons) _
    Handles mField.FieldUpdated
        ' Did the containing Field's World list change?
        If (_reason = Field.Reasons.WorldList) Then
            ' Yes, is this World still in it?
            If (mWorld IsNot Nothing) Then
                If (mField.GetWorldByID(mWorld.MyID) IsNot mWorld) Then
                    ' No, this Window is no longer valid; hide it
                    Me.HideWindow()
                End If
            End If
        Else
            UpdateUI()
        End If
    End Sub
    '
    ' World changes
    '
    Private Sub World_Updated(ByVal _reason As World.Reasons) _
    Handles mWorld.WorldUpdated
        ' Did the containing World's Analysis list change?
        If (_reason = World.Reasons.AnalysisList) Then
            ' Yes, is this Analysis still in it?
            If (mUnit IsNot Nothing) Then
                If (mWorld.GetAnalysisByID(mUnit.MyID) IsNot mUnit) Then
                    ' No, this Window is no longer valid; hide it
                    Me.HideWindow()
                End If
            End If
        Else
            UpdateUI()
        End If
    End Sub
    '
    ' Unit changes
    '
    Private Sub Unit_Updated(ByVal _reason As Unit.Reasons) _
    Handles mUnit.UnitUpdated
        Select Case (_reason)
            Case Unit.Reasons.Name
                UpdateUI()
        End Select
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        RefreshUI()
    End Sub
    '
    ' System Geometry changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        If Not (Running) Then
            UpdateUI()
            UpdateResultsControls()
        End If
    End Sub
    '
    ' Soil Crop Properties changes
    '
    Private Sub SoilCropProperties_PropertyChanged(ByVal _reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        If Not (Running) Then
            UpdateUI()
            UpdateResultsControls()
        End If
    End Sub
    '
    ' Inflow Management changes
    '
    Private Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        If Not (Running) Then
            UpdateUI()
            UpdateResultsControls()
        End If
    End Sub
    '
    ' Erosion changes
    '
    Private Sub Erosion_PropertyChanged(ByVal _reason As Erosion.Reasons) _
    Handles mErosion.PropertyDataChanged
        If Not (Running) Then
            UpdateUI()
            UpdateResultsControls()
        End If
    End Sub
    '
    ' Fertigation changes
    '
    Private Sub Fertigation_PropertyChanged(ByVal _reason As Fertigation.Reasons) _
    Handles mFertigation.PropertyDataChanged
        If Not (Running) Then
            UpdateUI()
            UpdateResultsControls()
        End If
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " File Menu "
    '
    ' Clear previously added popup menu items
    '
    Private Sub ClearFileMenuPopupItems()
        ' Delete all menu items after the FileMenuPopupSeparator
        For _idx As Integer = Me.FileMenu.MenuItems.Count - 1 To 0 Step -1
            Dim _menuItem As MenuItem = Me.FileMenu.MenuItems(_idx)
            If (_menuItem Is Me.FileMenuPopupSeparator) Then
                Exit For
            Else
                Me.FileMenu.MenuItems.RemoveAt(_idx)
            End If
        Next
    End Sub
    '
    ' Recursive method for adding sub-items to the File Menu
    '
    Private Sub AddFileMenuPopupItems(ByVal _control As Control)

        If Not (_control Is Nothing) Then
            If (_control.Visible) Then
                ' DataTableParameter controls have sub-items
                If ((_control.GetType Is GetType(ctl_DataTableParameter)) _
                 Or (_control.GetType.IsSubclassOf(GetType(ctl_DataTableParameter)))) Then
                    ' Make separator visible
                    FileMenuPopupSeparator.Visible = True
                    ' Get reference to DataTable control
                    Dim _dataTableCtrl As ctl_DataTableParameter = DirectCast(_control, ctl_DataTableParameter)
                    ' Add item to File Menu for this DataTable
                    Dim _fileMenuItem As MenuItem = FileMenu.MenuItems.Add(_dataTableCtrl.CaptionText)
                    ' Add the sub-items for this DataTable
                    _dataTableCtrl.FileMenu_Popup(_fileMenuItem)

                ElseIf ((_control.GetType Is GetType(ctl_DataSetParameter)) _
                 Or (_control.GetType.IsSubclassOf(GetType(ctl_DataSetParameter)))) Then
                    ' Make separator visible
                    FileMenuPopupSeparator.Visible = True
                    ' Get reference to DataSet control
                    Dim _dataSetCtrl As ctl_DataSetParameter = DirectCast(_control, ctl_DataSetParameter)
                    ' Add item to File Menu for this DataTable
                    Dim _fileMenuItem As MenuItem = FileMenu.MenuItems.Add(_dataSetCtrl.CaptionText)
                    ' Add the sub-items for this DataTable
                    _dataSetCtrl.FileMenu_Popup(_fileMenuItem)
                Else
                    ' Recursively call method to scan contained controls
                    For Each _ctrl As Control In _control.Controls
                        AddFileMenuPopupItems(_ctrl)
                    Next
                End If
            End If
        End If

    End Sub
    '
    ' Adjust File Menu to match current display
    '
    Private Sub FileMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileMenu.Popup
        ' Get Focus to force update of pending user data changes.  Most controls use LostFocus
        ' as a signal to save user data changes.
        Me.StatusIcon.Focus()

        ' Enable / disable File Menu items
        FileSaveItem.Enabled = mWinSRFR.DataHasChanged()

        PrintResultsItem.Enabled = mUnit.ResultsAreValid
        PreviewResultsItem.Enabled = mUnit.ResultsAreValid

        ' Add File submenus
        FileMenuPopupSeparator.Visible = False
        ClearFileMenuPopupItems()
        AddFileMenuPopupItems(Me)

        ' Build the 'Save Image' items
        FileExportImageItem.MenuItems.Clear()
        AddPictureBoxSaveItems(FileExportImageItem, Me)

        If (0 < FileExportImageItem.MenuItems.Count) Then
            FileExportImageItem.Enabled = True
        Else
            FileExportImageItem.Enabled = False
        End If

        ' Show Export SRFR Inputs if running under debugger
        FileExportSrfrInputsItem.Visible = WinSRFR.DebuggerIsAttached

    End Sub
    '
    ' Close
    '
    Protected Sub HideWindow()

        ' Delete the SRFR Diagnostic & Network Viewers
        DeleteDebugViewers()
        DeleteNetworkViewers()

        ' Don't close the World Window; hide it instead
        If (Me.WindowState = FormWindowState.Minimized) Then
            Me.WindowState = mWorldWindowState
        End If
        Me.Hide()
    End Sub

    Private Sub FileCloseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileCloseItem.Click
        HideWindow()
    End Sub

    Private Sub Window_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        HideWindow()
        e.Cancel = True
    End Sub
    '
    ' Save
    '
    Private Sub FileSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileSaveItem.Click
        mWinSRFR.Save()
        UpdateToolbar()
    End Sub
    '
    ' Print / Print Preview
    '
    Private Sub PrintResultsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PrintResultsItem.Click
        Print(sender, e)
    End Sub

    Private Sub PreviewResultsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PreviewResultsItem.Click
        PrintPreview(sender, e)
    End Sub
    '
    ' Script Recording & Execution
    '
    Private Sub FileScriptingItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileScriptingItem.Click

        ' Send the Default Data flow to the DataStore
        DataStore.DataStore.DefaultFilepath = WinSRFR.UserPreferences.DefaultDataFolder

        ' Show the Script Recorder
        If (mScriptRecorder Is Nothing) Then
            mScriptRecorder = New ScriptRecorder
            mScriptRecorder.ObjectNode = mMyStore

            mScriptRecorder.ScriptLoadMenu.DropDownItems.Add("&System Geometry", Nothing, AddressOf LoadSystemGeometryItem_Click)
            mScriptRecorder.ScriptLoadMenu.DropDownItems.Add("&Roughness", Nothing, AddressOf LoadRoughnessItem_Click)
            mScriptRecorder.ScriptLoadMenu.DropDownItems.Add("&Infiltration", Nothing, AddressOf LoadInfiltrationItem_Click)
            mScriptRecorder.ScriptLoadMenu.DropDownItems.Add("In&flow", Nothing, AddressOf LoadInflowItem_Click)
        End If

        Try ' to show Script Recorder
            mScriptRecorder.Show()
        Catch ex1 As Exception
            mScriptRecorder = Nothing
            mScriptRecorder = New ScriptRecorder
            mScriptRecorder.ObjectNode = mMyStore

            mScriptRecorder.ScriptLoadMenu.DropDownItems.Add("&System Geometry", Nothing, AddressOf LoadSystemGeometryItem_Click)
            mScriptRecorder.ScriptLoadMenu.DropDownItems.Add("&Roughness", Nothing, AddressOf LoadRoughnessItem_Click)
            mScriptRecorder.ScriptLoadMenu.DropDownItems.Add("&Infiltration", Nothing, AddressOf LoadInfiltrationItem_Click)
            mScriptRecorder.ScriptLoadMenu.DropDownItems.Add("In&flow", Nothing, AddressOf LoadInflowItem_Click)

            Try ' again
                mScriptRecorder.Show()
            Catch ex2 As Exception
                mScriptRecorder = Nothing
            End Try
        End Try

    End Sub

    Private Sub ScriptRecorder_RemoteCommand(ByVal command As String, ByRef result As Integer) _
    Handles mScriptRecorder.RemoteCommand
        result = DataStore.Globals.ParseError.ParseOK

        If (command IsNot Nothing) Then
            If Not (command = String.Empty) Then
                Dim commandInterface As CommandInterface = mWinSRFR.CommandInterface
                If (commandInterface IsNot Nothing) Then
                    result = commandInterface.ParseCommand(command)
                End If
            End If
        End If
    End Sub

    Private Sub LoadSystemGeometryItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim command As String = String.Empty

        DataStore.DataStore.EnableScriptRecording = True
        '
        ' Record common System Geometry parameters
        '
        mScriptRecorder.RecordCommand("'")
        mScriptRecorder.RecordCommand("' System Geometry parameters")
        mScriptRecorder.RecordCommand("'")

        command = mSystemGeometry.CrossSectionProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSystemGeometry.LengthProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSystemGeometry.WidthProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSystemGeometry.DepthProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSystemGeometry.BottomDescriptionProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSystemGeometry.SlopeProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)
        '
        ' Record Cross Section specific parameters (i.e. Furrow parameters)
        '
        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

            command = mSystemGeometry.FurrowSpacingProperty.RemoteCommand
            mScriptRecorder.RecordCommand(command)

            command = mSystemGeometry.FurrowsPerSetProperty.RemoteCommand
            mScriptRecorder.RecordCommand(command)

            command = mSystemGeometry.FurrowShapeProperty.RemoteCommand
            mScriptRecorder.RecordCommand(command)

            command = mSystemGeometry.MaximumDepthProperty.RemoteCommand
            mScriptRecorder.RecordCommand(command)

            Select Case (mSystemGeometry.FurrowShape.Value)
                Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData

                    command = mSystemGeometry.WidthAt100mmProperty.RemoteCommand
                    mScriptRecorder.RecordCommand(command)

                    command = mSystemGeometry.PowerLawExponentProperty.RemoteCommand
                    mScriptRecorder.RecordCommand(command)

                Case FurrowShapes.Trapezoid, FurrowShapes.TrapezoidFromFieldData

                    command = mSystemGeometry.BottomWidthProperty.RemoteCommand
                    mScriptRecorder.RecordCommand(command)

                    command = mSystemGeometry.SideSlopeProperty.RemoteCommand
                    mScriptRecorder.RecordCommand(command)

            End Select

            command = mSystemGeometry.EnableTabulatedFurrowShapeProperty.RemoteCommand
            mScriptRecorder.RecordCommand(command)

        Else ' Border specific parameters

            command = mSystemGeometry.EnableTabulatedBorderDepthProperty.RemoteCommand
            mScriptRecorder.RecordCommand(command)
        End If

        DataStore.DataStore.EnableScriptRecording = False

    End Sub

    Private Sub LoadRoughnessItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim command As String = String.Empty

        DataStore.DataStore.EnableScriptRecording = True

        mScriptRecorder.RecordCommand("'")
        mScriptRecorder.RecordCommand("' Roughness parameters")
        mScriptRecorder.RecordCommand("'")
        '
        ' Record common Roughness parameters
        '
        command = mSoilCropProperties.RoughnessMethodProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSoilCropProperties.EnableVegetativeDensityProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSoilCropProperties.VegetativeDensityProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)
        '
        ' Record Roughness Method specific parameters
        '
        Select Case (mSoilCropProperties.RoughnessMethod.Value)

            Case RoughnessMethods.ManningCnAn

                command = mSoilCropProperties.ManningCnProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.ManningAnProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case RoughnessMethods.SayreAlbertson

                command = mSoilCropProperties.SayreChiProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case Else ' RoughnessMethods.ManningN, RoughnessMethods.NrcsSuggestedManningN

                command = mSoilCropProperties.NrcsSuggestedManningNProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.UsersManningNProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

        End Select

        command = mSoilCropProperties.EnableTabulatedRoughnessProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        DataStore.DataStore.EnableScriptRecording = False

    End Sub

    Private Sub LoadInfiltrationItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim command As String = String.Empty

        DataStore.DataStore.EnableScriptRecording = True

        mScriptRecorder.RecordCommand("'")
        mScriptRecorder.RecordCommand("' Infiltration parameters")
        mScriptRecorder.RecordCommand("'")
        '
        ' Record common Infiltration parameters
        '
        command = mSoilCropProperties.WettedPerimeterMethodProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSoilCropProperties.InfiltrationFunctionProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSoilCropProperties.EnableLimitingDepthProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSoilCropProperties.LimitingDepthProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)
        '
        ' Record Wetted Perimeter specific parameters
        '
        Dim wpMethod As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value
        Select Case (wpMethod)
            Case WettedPerimeterMethods.LocalWettedPerimeter,
                 WettedPerimeterMethods.NrcsEmpiricalFunction,
                 WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter,
                 WettedPerimeterMethods.UpstreamWettedPerimeter

                command = mEventCriteria.ReferenceFlowRateSetProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mEventCriteria.ReferenceFlowRateProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)
        End Select
        '
        ' Record Infiltration Method specific parameters
        '
        Dim infFunc As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value
        Select Case (infFunc)

            Case InfiltrationFunctions.BranchFunction

                command = mSoilCropProperties.KostiakovK_BFProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.KostiakovA_BFProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.BranchB_BFProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.KostiakovC_BFProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.BranchTimeSetProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.BranchTime_BFProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case InfiltrationFunctions.CharacteristicInfiltrationTime

                command = mSoilCropProperties.InfiltrationDepth_KTProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.InfiltrationTime_KTProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.KostiakovA_KTProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case InfiltrationFunctions.KostiakovFormula

                command = mSoilCropProperties.KostiakovK_KFProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.KostiakovA_KFProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case InfiltrationFunctions.ModifiedKostiakovFormula

                command = mSoilCropProperties.KostiakovK_MKProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.KostiakovA_MKProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.KostiakovB_MKProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.KostiakovC_MKProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case InfiltrationFunctions.NRCSIntakeFamily

                command = mSoilCropProperties.NrcsIntakeFamilyProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.NrcsToKostiakovMethodProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case InfiltrationFunctions.TimeRatedIntakeFamily

                command = mSoilCropProperties.InfiltrationTime_TRProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case InfiltrationFunctions.Hydrus1D

                command = mSoilCropProperties.HydrusProjectProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.SyncHydrusOptionProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case InfiltrationFunctions.GreenAmpt

                command = mSoilCropProperties.SoilTextureSelectionGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.EffectivePorosityGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.InitialWaterContentGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.WettingFrontPressureHeadGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.HydraulicConductivityGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.GreenAmptC_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case InfiltrationFunctions.WarrickGreenAmpt

                command = mSoilCropProperties.SoilTextureSelectionWGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.SaturatedWaterContentWGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.InitialWaterContentWGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.WettingFrontPressureHeadWGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.HydraulicConductivityWGA_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.WarrickGreenAmptC_Property.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mSoilCropProperties.WarrickGreenAmptGammaProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

        End Select

        command = mSoilCropProperties.EnableTabulatedInfiltrationProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        DataStore.DataStore.EnableScriptRecording = False

    End Sub

    Private Sub LoadInflowItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim command As String = String.Empty

        DataStore.DataStore.EnableScriptRecording = True

        mScriptRecorder.RecordCommand("'")
        mScriptRecorder.RecordCommand("' Inflow parameters")
        mScriptRecorder.RecordCommand("'")
        '
        ' Record common Inflow parameters
        '
        command = mInflowManagement.UnitWaterCostProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mInflowManagement.RequiredDepthProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mInflowManagement.InflowMethodProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)
        '
        ' Record Inflow Method specific parameters
        '
        Dim infMethod As InflowMethods = mInflowManagement.InflowMethod.Value

        Select Case (infMethod)

            Case InflowMethods.StandardHydrograph

                command = mInflowManagement.InflowRateProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mInflowManagement.CutoffMethodProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                Select Case (mInflowManagement.CutoffMethod.Value)

                    Case CutoffMethods.DistanceBased

                        command = mInflowManagement.CutoffLocationRatioProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                    Case CutoffMethods.DistanceInfDepth

                        command = mInflowManagement.CutoffLocationRatioProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                        command = mInflowManagement.CutoffInfiltrationDepthProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                    Case CutoffMethods.DistanceOppTime

                        command = mInflowManagement.CutoffLocationRatioProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                        command = mInflowManagement.CutoffOpportunityTimeProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                    Case CutoffMethods.TimeBased

                        command = mInflowManagement.CutoffTimeProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                    Case CutoffMethods.UpstreamInfDepth

                        command = mInflowManagement.CutoffUpstreamDepthProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                End Select

                command = mInflowManagement.CutbackMethodProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                Select Case (mInflowManagement.CutbackMethod.Value)

                    Case CutbackMethods.DistanceBased

                        command = mInflowManagement.CutbackLocationRatioProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                        command = mInflowManagement.CutbackRateRatioProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                    Case CutbackMethods.TimeBased

                        command = mInflowManagement.CutbackTimeRatioProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                        command = mInflowManagement.CutbackRateRatioProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                End Select

            Case InflowMethods.TabulatedInflow

                ' JLS - Tabulated Time/Inflow

            Case InflowMethods.Cablegation

                command = mInflowManagement.TotalInflowProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mInflowManagement.PipeDiameterProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mInflowManagement.PipeSlopeProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mInflowManagement.HazenWilliamsPipeCoefficientProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mInflowManagement.OrificeOptionProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                Select Case (mInflowManagement.OrificeOption.Value)

                    Case OrificeOptions.EquivalentDiameter
                        command = mInflowManagement.OrificeDiameterProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                    Case OrificeOptions.PeakFlow
                        command = mInflowManagement.PeakOrificeFlowProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)
                End Select

                command = mInflowManagement.CutoffFlowProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mInflowManagement.OrificeSpacingProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mInflowManagement.PlugSpeedProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

            Case InflowMethods.Surge

                ' Commands common to all Surge strategies
                command = mInflowManagement.SurgeStrategyProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                command = mInflowManagement.SurgeInflowRateProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

                ' Commands common to most Surge strategies
                If Not (mInflowManagement.SurgeStrategy.Value = SurgeStrategies.TabulatedTime) Then

                    command = mInflowManagement.SurgeOnTimeProperty.RemoteCommand
                    mScriptRecorder.RecordCommand(command)

                    command = mInflowManagement.SurgeCutoffTimeProperty.RemoteCommand
                    mScriptRecorder.RecordCommand(command)

                End If

                ' Commands specific to Surge strategy
                Select Case (mInflowManagement.SurgeStrategy.Value)

                    Case SurgeStrategies.UniformTime

                    Case SurgeStrategies.UniformLocation

                        command = mInflowManagement.NumberOfSurgesProperty.RemoteCommand
                        mScriptRecorder.RecordCommand(command)

                    Case SurgeStrategies.TabulatedTime

                        ' JLS - Surge Tabulated On/Off 

                    Case SurgeStrategies.TabulatedLocation

                        ' JLS - Surge Tabulated Locations

                End Select ' SurgeStrategy

                command = mSoilCropProperties.Surge2InfiltrationMethodProperty.RemoteCommand
                mScriptRecorder.RecordCommand(command)

        End Select ' InflowMethod

        ' Note that these two properties are still under SystemGeometry for storage purposes.
        command = mSystemGeometry.UpstreamConditionProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        command = mSystemGeometry.DownstreamConditionProperty.RemoteCommand
        mScriptRecorder.RecordCommand(command)

        If (mSystemGeometry.UpstreamCondition.Value = UpstreamConditions.DrainbackAfterCutoff) Then
            command = mInflowManagement.DrawDownTimeProperty.RemoteCommand
            mScriptRecorder.RecordCommand(command)
        End If

        DataStore.DataStore.EnableScriptRecording = False

    End Sub

    Private Sub FileExportSrfrInputsItem_Click(sender As Object, e As EventArgs) _
        Handles FileExportSrfrInputsItem.Click
        SaveAsSrfrInputs()
    End Sub
    '
    ' Save the project using the filename provided by the user via the SaveFileDialog
    '
    Friend Function SaveAsSrfrInputs() As Boolean

        ' Create / Initialize SaveFileDialog to specify SRFR extensions
        Dim saveFile As New SaveFileDialog With {
            .FileName = "SrfrInputs",
            .DefaultExt = "*.srfrin",
            .Filter = Application.ProductName + " Files|*.srfrin"
        }

        ' Let user choose SRFR file to open
        Dim result As DialogResult = saveFile.ShowDialog()
        If (result = DialogResult.OK) Then
            If (0 < saveFile.FileName.Length) Then
                Return SaveSrfrInputs(saveFile.FileName)
            End If
        End If

        Return False
    End Function
    '
    ' Save the project using the specified filename
    '
    Friend Function SaveSrfrInputs(ByVal FilePath As String) As Boolean

        If (FilePath IsNot Nothing) Then
            If (FilePath <> String.Empty) Then

                ' Can't save to ReadOnly files
                Try
                    If (Dir(FilePath) <> String.Empty) Then
                        ' File exists
                        If ((GetAttr(FilePath) And vbReadOnly) = vbReadOnly) Then
                            ' File exists and is ReadOnly; it can't be written to
                            MsgBox(FilePath, MsgBoxStyle.OkOnly, "Save Error - File Is Read Only")
                            Return False
                        End If
                    End If
                Catch ex As Exception
                    ' File exists but can't be written to
                    MsgBox(FilePath, MsgBoxStyle.OkOnly, "Save Error - File Cannot Be Written")
                    Return False
                End Try

                ' Save the file
                Dim FileStream = New FileStream(FilePath, FileMode.Create)
                SrfrAPI.WriteInputsToFile(FileStream)
                FileStream.Close()
            End If
        End If

        Return False
    End Function

#End Region

#Region " Edit Menu "
    '
    ' Clear the previously popup added menu items
    '
    Private Sub ClearEditMenuPopupItems()
        ' Delete all menu items after the EditMenuPopupSeparator
        For _idx As Integer = Me.EditMenu.MenuItems.Count - 1 To 0 Step -1
            Dim _menuItem As MenuItem = Me.EditMenu.MenuItems(_idx)
            If (_menuItem Is Me.EditMenuPopupSeparator) Then
                Exit For
            Else
                Me.EditMenu.MenuItems.RemoveAt(_idx)
            End If
        Next
    End Sub
    '
    ' Recursive method for adding sub-items to the Edit Menu
    '
    Private Sub AddEditMenuPopupItems(ByVal _control As Control)

        If Not (_control Is Nothing) Then
            If (_control.Visible) Then
                ' DataTableParameter controls have sub-items
                If ((_control.GetType Is GetType(ctl_DataTableParameter)) _
                 Or (_control.GetType.IsSubclassOf(GetType(ctl_DataTableParameter)))) Then
                    ' Make separator visible
                    EditMenuPopupSeparator.Visible = True
                    ' Get reference to DataTable control
                    Dim _dataTableCtrl As ctl_DataTableParameter = DirectCast(_control, ctl_DataTableParameter)
                    ' Add item to Edit Menu for this DataTable
                    Dim _editMenuItem As MenuItem = EditMenu.MenuItems.Add(_dataTableCtrl.CaptionText)
                    ' Add the sub-items for this DataTable
                    _dataTableCtrl.EditMenu_Popup(_editMenuItem)

                ElseIf ((_control.GetType Is GetType(ctl_DataSetParameter)) _
                     Or (_control.GetType.IsSubclassOf(GetType(ctl_DataSetParameter)))) Then
                    ' Make separator visible
                    EditMenuPopupSeparator.Visible = True
                    ' Get reference to DataSet control
                    Dim _dataSetCtrl As ctl_DataSetParameter = DirectCast(_control, ctl_DataSetParameter)
                    ' Add item to Edit Menu for this DataTable
                    Dim _editMenuItem As MenuItem = EditMenu.MenuItems.Add(_dataSetCtrl.CaptionText)
                    ' Add the sub-items for this DataTable
                    _dataSetCtrl.EditMenu_Popup(_editMenuItem)
                Else
                    ' Recursively call method to scan contained controls
                    For Each _ctrl As Control In _control.Controls
                        AddEditMenuPopupItems(_ctrl)
                    Next
                End If
            End If
        End If

    End Sub
    '
    ' Adjust Edit Menu to match current display
    '
    Private Sub EditMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMenu.Popup
        Me.StatusIcon.Focus()

        Dim _reason As String = String.Empty

        ' Enable / disable 'Undo' item
        If (mMyStore.CanUndo(_reason)) Then
            EditUndoItem.Enabled = True
            EditUndoItem.Text = mDictionary.tUndo.Translated & " " & _reason
        Else
            EditUndoItem.Enabled = False
            EditUndoItem.Text = mDictionary.tUndo.Translated
        End If

        ' Enable / disable 'Redo' item
        If (mMyStore.CanRedo(_reason)) Then
            EditRedoItem.Enabled = True
            EditRedoItem.Text = mDictionary.tRedo.Translated & " " & _reason
        Else
            EditRedoItem.Enabled = False
            EditRedoItem.Text = mDictionary.tRedo.Translated
        End If

        ' Build the 'Copy Bitmap' items
        EditCopyBitmapItem.MenuItems.Clear()
        AddPictureBoxCopyItems(EditCopyBitmapItem, Me)

        If (0 < EditCopyBitmapItem.MenuItems.Count) Then
            EditCopyBitmapItem.Enabled = True
        Else
            EditCopyBitmapItem.Enabled = False
        End If

        ' Build the 'Copy Data' items
        EditCopyDataItem.MenuItems.Clear()
        AddCtlGraph2DCopyItems(EditCopyDataItem, Me)
        AddCtlContour2DCopyItems(EditCopyDataItem, Me)

        If (0 < EditCopyDataItem.MenuItems.Count) Then
            EditCopyDataItem.Enabled = True
        Else
            EditCopyDataItem.Enabled = False
        End If

        ' Add edit submenus
        ClearEditMenuPopupItems()
        EditMenuPopupSeparator.Visible = False
        AddEditMenuPopupItems(Me)

    End Sub
    '
    ' Undo / Redo
    '
    Private Sub Undo()

        Try
            If (mMyStore.CanUndo()) Then
                Me.StatusIcon.Focus()
                mMyStore.Undo()
                Me.BringToFront()

                ' Update the results controls & tab page
                UpdateResultsControls()
            End If
        Catch ex As Exception
            Dim _msg As String = "An unexpected error occurred during Undo"
            mWinSRFR.SeriousException(_msg, ex)
        End Try

    End Sub

    Private Sub Redo()

        Try
            If (mMyStore.CanRedo()) Then
                Me.StatusIcon.Focus()
                mMyStore.Redo()
                Me.BringToFront()

                ' Update the results controls & tab page
                UpdateResultsControls()
            End If
        Catch ex As Exception
            Dim _msg As String = "An unexpected error occurred during Redo"
            mWinSRFR.SeriousException(_msg, ex)
        End Try

    End Sub

    Private Sub UndoContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles UndoContextMenu.Popup
        UndoContextMenu.MenuItems.Clear()

        Dim undoList As ArrayList = mMyStore.UndoList

        If Not (undoList Is Nothing) Then
            For Each reason As String In undoList
                UndoContextMenu.MenuItems.Add(reason, AddressOf EditUndoItems_Click)
            Next
            UndoContextMenu.MenuItems.Add("-")
        End If

        UndoContextMenu.MenuItems.Add("Undo 1 Action", AddressOf EditUndoItem_Click)

    End Sub

    Private Sub RedoContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RedoContextMenu.Popup
        RedoContextMenu.MenuItems.Clear()

        Dim redoList As ArrayList = mMyStore.RedoList

        If Not (redoList Is Nothing) Then
            For Each reason As String In redoList
                RedoContextMenu.MenuItems.Add(reason, AddressOf EditRedoItems_Click)
            Next
            RedoContextMenu.MenuItems.Add("-")
        End If

        RedoContextMenu.MenuItems.Add("Redo 1 Action", AddressOf EditRedoItem_Click)

    End Sub

    Private Sub EditUndoItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditUndoItem.Click
        Undo()
    End Sub

    Private Sub EditUndoItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Handles EditUndoItems.Click
        If (sender.GetType Is GetType(MenuItem)) Then
            Dim item As MenuItem = DirectCast(sender, MenuItem)

            For cnt As Integer = 0 To item.Index
                Undo()
            Next
        End If
    End Sub

    Private Sub EditRedoItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditRedoItem.Click
        Redo()
    End Sub

    Private Sub EditRedoItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Handles EditRedoItems.Click
        If (sender.GetType Is GetType(MenuItem)) Then
            Dim item As MenuItem = DirectCast(sender, MenuItem)

            For cnt As Integer = 0 To item.Index
                Redo()
            Next
        End If
    End Sub
    '
    ' Units
    '
    Private Sub EditUnitsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditUnitsItem.Click
        Dim db As UnitsDialogBox = WinSRFR.UnitsDialogBox
        If (db.Visible) Then
            db.BringToFront()
        Else
            db.InitDialogBox()
            db.Show()
        End If
    End Sub

#End Region

#Region " View Menu "

    Private Sub ViewMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewMenu.Popup

        ' Is simulation run available for this world's analysis?
        Dim simAvail As Boolean = False
        If (mUnit IsNot Nothing) Then
            Dim simName As String = Me.SrfrAPI.SimName
            Dim srfrID As String = mUnit.SrfrID.Value
            If (Me.SrfrAPI.SimName = mUnit.SrfrID.Value) Then
                simAvail = True
            End If
        End If

        ' Simulation Network windows are available to Advanced & Research level users
        If ((Not mWinSRFR.UserLevel = UserLevels.Standard) _
         Or (WinSRFR.DebuggerIsAttached)) Then
            ViewSimulationNetworkItem.Enabled = simAvail
            ViewSimulationNetworkItem.Visible = True
        Else
            ViewSimulationNetworkItem.Enabled = False
            ViewSimulationNetworkItem.Visible = False
        End If

        ' Simulation Debug windows are available to Research level users
        If ((WinSrfr.IsResearchLevel) Or (WinSRFR.DebuggerIsAttached)) Then
            ViewDebugWindowsItem.Enabled = simAvail
            ViewDebugWindowsItem.Visible = True
        Else
            ViewDebugWindowsItem.Enabled = False
            ViewDebugWindowsItem.Visible = False
        End If

        ' Enable / Disable Animation Viewer
        If (mWorld.WorldType.Value = WorldTypes.EventWorld) Then
            Me.ViewAnimationWindowItem.Enabled = False
            Me.ViewAnimationWindowItem.Visible = False
        Else ' Design | Operations | Simulation
            Me.ViewAnimationWindowItem.Enabled = simAvail
            Me.ViewAnimationWindowItem.Visible = True
        End If

        ' Enable the 'Select Graph Curve' items
        Dim graph2D As ctl_Graph2D = FindCtlGraph2D(Me)
        If (graph2D IsNot Nothing) Then
            ViewSelectCurvesItem.Enabled = True
        Else
            ViewSelectCurvesItem.Enabled = False
        End If

    End Sub

    Private Sub ViewShowFirstCurveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewShowFirstCurveItem.Click
        Dim graph2D As ctl_Graph2D = FindCtlGraph2D(Me)
        If (graph2D IsNot Nothing) Then
            graph2D.ShowFirstCurve()
        End If
    End Sub

    Private Sub ViewShowNextCurveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewShowNextCurveItem.Click
        Dim graph2D As ctl_Graph2D = FindCtlGraph2D(Me)
        If (graph2D IsNot Nothing) Then
            graph2D.ShowNextCurve()
        End If
    End Sub

    Private Sub ViewShowLastCurveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewShowLastCurveItem.Click
        Dim graph2D As ctl_Graph2D = FindCtlGraph2D(Me)
        If (graph2D IsNot Nothing) Then
            graph2D.ShowLastCurve()
        End If
    End Sub

    Private Sub ViewShowPrevCurveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewShowPrevCurveItem.Click
        Dim graph2D As ctl_Graph2D = FindCtlGraph2D(Me)
        If (graph2D IsNot Nothing) Then
            graph2D.ShowPrevCurve()
        End If
    End Sub

    Private Sub ViewShowAllCurvesItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewShowAllCurvesItem.Click
        Dim graph2D As ctl_Graph2D = FindCtlGraph2D(Me)
        If (graph2D IsNot Nothing) Then
            graph2D.ShowAllCurves()
        End If
    End Sub

    Private Sub ViewAnimationWindowItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewAnimationWindowItem.Click
        If (mResultsAreValid) Then ' there is an animation to display
            AnimationViewer.FrameNumber = 0
            AnimationViewer.UpdateUI()
            AnimationViewer.Show()
            AnimationViewer.BringToFront()
        End If
    End Sub

    Private Sub ViewProjectWindowItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewProjectWindowItem.Click
        mWinSRFR.ShowWinSRFR()
    End Sub

    Private Sub ViewResultsAsItem_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewResultsAsItem.Popup
        Select Case (ResultsView)
            Case ResultsViews.PortraitPage
                ViewFullPageItem.Checked = True
                ViewGraphsOnlyItem.Checked = False
            Case Else ' Assume GraphsOnly
                ViewFullPageItem.Checked = False
                ViewGraphsOnlyItem.Checked = True
        End Select

    End Sub

    Private Sub ViewPortraitPageItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewFullPageItem.Click
        ResultsView = ResultsViews.PortraitPage
    End Sub

    Private Sub ViewGraphsOnlyItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewGraphsOnlyItem.Click
        ResultsView = ResultsViews.GraphsOnly
    End Sub

    Private Sub ViewRefreshItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewRefreshItem.Click
        RefreshUI()
    End Sub

    Private Sub ViewSizeItem_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSizeItem.Popup
        ' Check the appropriate Window Size menu item
        ViewSize800x600.Checked = False
        ViewSize900x675.Checked = False
        ViewSize949x768.Checked = False
        ViewSize1024x768.Checked = False

        If (Me.Size = New Size(800, 600)) Then
            ViewSize800x600.Checked = True
        ElseIf (Me.Size = New Size(900, 675)) Then
            ViewSize900x675.Checked = True
        ElseIf (Me.Size = New Size(949, 768)) Then
            ViewSize949x768.Checked = True
        ElseIf (Me.Size = New Size(1024, 768)) Then
            ViewSize1024x768.Checked = True
        End If

        ViewSize949x768.Visible = WinSRFR.DebuggerIsAttached
    End Sub

    Private Sub ViewSize800x600_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSize800x600.Click
        mWinSRFR.WindowSize = WindowSizes.S800x600
        Me.Size = New Size(800, 600)
    End Sub

    Private Sub ViewSize900x675_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSize900x675.Click
        mWinSRFR.WindowSize = WindowSizes.S900x675
        Me.Size = New Size(900, 675)
    End Sub

    Private Sub ViewSize949x768_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSize949x768.Click
        mWinSRFR.WindowSize = WindowSizes.S949x768
        Me.Size = New Size(949, 768)
    End Sub

    Private Sub ViewSize1024x768_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSize1024x768.Click
        mWinSRFR.WindowSize = WindowSizes.S1024x768
        Me.Size = New Size(1024, 768)
    End Sub

    Private Sub ViewDebugWindowsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewDebugWindowsItem.Click
        '
        ' Instantiate the SRFR Debug Viewers
        '
        InitDebugViewers()
        '
        ' Get current screen sizes
        '
        Dim screenHeight As Integer = My.Computer.Screen.WorkingArea.Height
        Dim screenWidth As Integer = My.Computer.Screen.WorkingArea.Width
        '
        ' Get current window sizes
        '
        Dim iHeight As Integer = IrrigationViewer.Size.Height
        Dim iWidth As Integer = IrrigationViewer.Size.Width

        Dim sHeight As Integer = StreamViewer.Size.Height
        Dim sWidth As Integer = StreamViewer.Size.Width

        Dim cHeight As Integer = CellViewer.Size.Height
        Dim cWidth As Integer = CellViewer.Size.Width
        '
        ' Calculate tiled layout
        '
        Dim totalHeight As Integer = Math.Min(sHeight + cHeight, screenHeight)
        Dim totalWidth As Integer = iWidth + cWidth

        Dim xMargin As Integer = Math.Max(CInt((screenWidth - totalWidth) / 2), 0)
        Dim yMargin As Integer = Math.Max(CInt((screenHeight - totalHeight) / 2), 0)

        If (screenWidth <= totalWidth) Then ' Screen is too narrow for tiling horizontally
            iWidth = Math.Max(screenWidth - sWidth, CInt(iWidth / 3))
        End If

        If (screenHeight <= totalHeight) Then ' Screen is too short for tiling vertically
            cHeight = Math.Max(screenHeight - sHeight, CInt(cHeight / 2))
        End If
        '
        ' Get data to view
        '
        Dim irrigation As Srfr.Irrigation = SrfrAPI.Irrigation
        Dim cell0 As Srfr.Cell = Nothing
        If (irrigation IsNot Nothing) Then
            For Each tStep As Srfr.Timestep In irrigation.Timesteps
                cell0 = tStep.Cell0
                If (cell0 IsNot Nothing) Then
                    Exit For
                End If
            Next
        End If
        '
        ' Initialize, tile & display the Viewers
        '
        IrrigationViewer.StreamViewer = StreamViewer()
        IrrigationViewer.CellViewer = CellViewer()
        IrrigationViewer.Irrigation = irrigation
        IrrigationViewer.StartPosition = FormStartPosition.Manual
        IrrigationViewer.SetDesktopLocation(xMargin, yMargin)
        IrrigationViewer.Height = totalHeight

        StreamViewer.IrrigationViewer = IrrigationViewer()
        StreamViewer.CellViewer = CellViewer()
        StreamViewer.Irrigation = irrigation
        StreamViewer.StartPosition = FormStartPosition.Manual
        StreamViewer.SetDesktopLocation(xMargin + iWidth, yMargin + cHeight)

        CellViewer.IrrigationViewer = IrrigationViewer()
        CellViewer.StreamViewer = StreamViewer()
        CellViewer.SelectedCell = cell0
        CellViewer.StartPosition = FormStartPosition.Manual
        CellViewer.SetDesktopLocation(xMargin + iWidth, yMargin)
        '
        ' Activate desired Viewer
        '
        Select Case WinSrfr.UserLevel
            Case UserLevels.Standard
                IrrigationViewer.UserLevel = Srfr.IrrigationViewer.UserLevels.Standard
            Case UserLevels.Advanced
                IrrigationViewer.UserLevel = Srfr.IrrigationViewer.UserLevels.Advanced
            Case UserLevels.Research
                IrrigationViewer.UserLevel = Srfr.IrrigationViewer.UserLevels.Research
        End Select

        IrrigationViewer.Show()
        CellViewer.Show()
        StreamViewer.Show()
        StreamViewer.Activate()

    End Sub

    Private Sub ViewSimulationNetworkItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSimulationNetworkItem.Click
        '
        ' Instantiate the SRFR Computational Network Viewers
        '
        InitNetworkViewers()
        '
        ' Get current screen sizes
        '
        Dim screenHeight As Integer = My.Computer.Screen.WorkingArea.Height
        Dim screenWidth As Integer = My.Computer.Screen.WorkingArea.Width
        '
        ' Get current window sizes
        '
        Dim iHeight As Integer = IrrigationViewer.Size.Height
        Dim iWidth As Integer = IrrigationViewer.Size.Width

        Dim hHeight As Integer = HydrographViewer.Size.Height
        Dim hWidth As Integer = HydrographViewer.Size.Width

        Dim pHeight As Integer = ProfileViewer.Size.Height
        Dim pWidth As Integer = ProfileViewer.Size.Width
        '
        ' Calculate tiled layout
        '
        Dim xMargin As Integer = screenWidth / 50
        Dim yMargin As Integer = screenHeight / 50

        iWidth = screenWidth / 2 - xMargin
        iHeight = screenHeight - 2 * yMargin
        Dim iSize As Size = New Size(iWidth, iHeight)

        hWidth = iWidth
        hHeight = iHeight / 2

        pWidth = iWidth
        pHeight = iHeight / 2

        IrrigationViewer.Size = iSize
        IrrigationViewer.StartPosition = FormStartPosition.Manual
        IrrigationViewer.SetDesktopLocation(xMargin, yMargin)
        IrrigationViewer.Irrigation = SrfrAPI.Irrigation
        IrrigationViewer.Transport = SrfrAPI.ConstituentTransport
        '
        ' Activate desired Viewer
        '
        Select Case WinSrfr.UserLevel
            Case UserLevels.Standard
                IrrigationViewer.UserLevel = Srfr.IrrigationViewer.UserLevels.Standard
            Case UserLevels.Advanced
                IrrigationViewer.UserLevel = Srfr.IrrigationViewer.UserLevels.Advanced
            Case UserLevels.Research
                IrrigationViewer.UserLevel = Srfr.IrrigationViewer.UserLevels.Research
        End Select

        IrrigationViewer.Show()
        IrrigationViewer.ShowHydrographViewer(xMargin + iWidth, yMargin, hWidth, hHeight)
        IrrigationViewer.ShowProfileViewer(xMargin + iWidth, yMargin + hHeight, pWidth, pHeight)
        IrrigationViewer.Activate()

    End Sub

    Private Sub UpdateControls(ByVal control As Control)

        For Each ctrl As Control In control.Controls
            If (ctrl.GetType Is GetType(ctl_SystemGeometry)) Then
                Dim tabCtrl As ctl_SystemGeometry = DirectCast(ctrl, ctl_SystemGeometry)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_SoilCropProperties)) Then
                Dim tabCtrl As ctl_SoilCropProperties = DirectCast(ctrl, ctl_SoilCropProperties)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_InflowManagement)) Then
                Dim tabCtrl As ctl_InflowManagement = DirectCast(ctrl, ctl_InflowManagement)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_InflowRunoff)) Then
                Dim tabCtrl As ctl_InflowRunoff = DirectCast(ctrl, ctl_InflowRunoff)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_AdvanceRecession)) Then
                Dim tabCtrl As ctl_AdvanceRecession = DirectCast(ctrl, ctl_AdvanceRecession)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_InfiltratedProfile)) Then
                Dim tabCtrl As ctl_InfiltratedProfile = DirectCast(ctrl, ctl_InfiltratedProfile)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_FlowDepths)) Then
                Dim tabCtrl As ctl_FlowDepths = DirectCast(ctrl, ctl_FlowDepths)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_VolumeBalances)) Then
                Dim tabCtrl As ctl_VolumeBalances = DirectCast(ctrl, ctl_VolumeBalances)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_SurfaceVolumeEstimated)) Then
                Dim tabCtrl As ctl_SurfaceVolumeEstimated = DirectCast(ctrl, ctl_SurfaceVolumeEstimated)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_SurfaceVolumeMeasured)) Then
                Dim tabCtrl As ctl_SurfaceVolumeMeasured = DirectCast(ctrl, ctl_SurfaceVolumeMeasured)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_EvaluationInfiltration)) Then
                Dim tabCtrl As ctl_EvaluationInfiltration = DirectCast(ctrl, ctl_EvaluationInfiltration)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_EvalueRoughnessFlowDepths)) Then
                Dim tabCtrl As ctl_EvalueRoughnessFlowDepths = DirectCast(ctrl, ctl_EvalueRoughnessFlowDepths)
                tabCtrl.UpdateUI()
            End If

            If (ctrl.GetType Is GetType(ctl_Results)) Then
                Dim tabCtrl As ctl_Results = DirectCast(ctrl, ctl_Results)
                tabCtrl.UpdateUI(mResultsAreValid)
            End If

            If (ctrl.GetType Is GetType(ctl_EvaluationResults)) Then
                Dim tabCtrl As ctl_EvaluationResults = DirectCast(ctrl, ctl_EvaluationResults)
                tabCtrl.UpdateUI(mResultsAreValid)
            End If

            If (ctrl.GetType Is GetType(ctl_SimulationResults)) Then
                Dim tabCtrl As ctl_SimulationResults = DirectCast(ctrl, ctl_SimulationResults)
                tabCtrl.UpdateUI(mResultsAreValid)
            End If

            Me.UpdateControls(ctrl)

        Next

    End Sub

#End Region

#Region " Help Menu "
    '
    ' What's This help
    '
    Private Sub HelpWhatsThisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles HelpWhatsThisItem.Click
        mWhatsThisHelp = True
        mWinSRFR.StartWhatsThisHelp(Me)
    End Sub
    '
    ' Stop What's This Help when window is de-activated
    '  Note - Mouse capture is lost when window is de-activated
    '
    Protected Overrides Sub OnDeactivate(ByVal e As EventArgs)
        ' If What's This Help is active; stop it
        If (mWhatsThisHelp) Then
            mWinSRFR.StopWhatsThisHelp(Me)
        End If
        ' Call base class method to continue Windows message processing
        MyBase.OnDeactivate(e)
    End Sub
    '
    ' WndProc() - override of WndProc for intercepting Windows messages
    '
    Protected Overrides Sub WndProc(ByRef m As Message)
        ' Override WndProc() to intercept Windows messages
        ' This intercepts all Windows messages prior to system handling
        Select Case (m.Msg)
            Case WM_LBUTTONUP, WM_RBUTTONUP, WM_MBUTTONUP ' Button up messages
                '  Mouse button events of interest

                If (mWhatsThisHelp = True) Then
                    ' Process the What's This Help request
                    mWhatsThisHelp = mWinSRFR.WhatsThisHelp(m, Me)

                    If (mWhatsThisHelp) Then
                        mWinSRFR.PauseWhatsThisHelp(Me)
                    Else
                        mWinSRFR.StopWhatsThisHelp(Me)
                    End If

                    ' Absorb this event; don't let system process it
                    Return
                End If
        End Select

        ' Call base class method to continue Windows message processing
        MyBase.WndProc(m)
    End Sub
    '
    ' Help Items
    '
    Private Sub ViewPdfManualItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewPdfManualItem.Click
        WinSRFR.ViewPdfManual()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            HelpF1()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Protected Overridable Sub HelpF1()
        WinSrfr.ShowPdfHelpManual("ch:Welcome")
    End Sub

#End Region

#Region " Toolbar Buttons "

    Private Sub WindowToolBar_ButtonClick(ByVal sender As System.Object,
                                              ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) _
    Handles WorldToolbar.ButtonClick

        Select Case WorldToolbar.Buttons.IndexOf(e.Button)

            Case 0 ' Save File
                mWinSRFR.Save()
                UpdateToolbar()

            Case 1 ' Print
                Print(sender, e)

            Case 2 ' Separator
                Debug.Assert(False, "Separator being used as button")

            Case 3 ' Undo
                Undo()
            Case 4 ' Redo
                Redo()

            Case 5 ' Separator
                Debug.Assert(False, "Separator being used as button")

            Case 6 ' Show WinSRFR Project Management window
                mWinSRFR.ShowWinSRFR()

            Case 7 ' Separator
                Debug.Assert(False, "Separator being used as button")

            Case 8 ' What's This Help
                mWhatsThisHelp = True
                mWinSRFR.StartWhatsThisHelp(Me)

            Case Else
                Debug.Assert(False, "Invalid toolbar button")

        End Select

    End Sub

#End Region

#Region " Status Bar "

    Private Sub WorldStatusBar_DrawItem(ByVal sender As Object, ByVal sbdevent As StatusBarDrawItemEventArgs) _
    Handles WorldStatusBar.DrawItem

        If (sbdevent.Panel Is ProgressBarPanel) Then
            With mProgressBar
                .SetBounds(sbdevent.Bounds.X, sbdevent.Bounds.Y, sbdevent.Bounds.Width, sbdevent.Bounds.Height)
            End With
        End If

    End Sub

#End Region

#Region " MyBase Events "
    '
    ' Resize - Redraw graphics to match new frame size
    '
    Private Sub MyBase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize

        ' Keep Status Icon located at right edge of window's toolbar
        Dim X As Integer = Me.Size.Width - Me.StatusIcon.Size.Width - 20
        Dim Y As Integer = Me.UsdaLabel.Location.Y

        If ((0 < X) And (0 < Y)) Then
            Dim IconLoc As Point = New Point(X, Y)
            Me.StatusIcon.Location = IconLoc
        End If

        ' Keep USDA label located immediately left of Status Icon
        X -= Me.UsdaLabel.Size.Width + 12

        If ((0 < X) And (0 < Y)) Then
            Dim UsdaLoc As Point = New Point(X, Y)
            Me.UsdaLabel.Location = UsdaLoc
        End If

        If Not (Me.WindowState = FormWindowState.Minimized) Then
            mWorldWindowState = Me.WindowState
        End If
    End Sub

#End Region

#End Region

End Class
