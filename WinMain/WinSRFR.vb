
'*************************************************************************************************************
' Class: WinSRFR, the application object, is the top heirarchical object for both data and UI objects.
'
'                                          WinSRFR
'                                             |
'                                         Farm List
'                                             |
'                                     -----------------
'                                    /      /   \      \
'                                 Farm   Farm   Farm   Farm   ...
'                                                 |
'                                            Field List
'                                                 |
'                                         -----------------
'                                        /      /   \      \
'                                    Field  Field  Field  Field  ...
'                                      |
'                                 World List
'                                      |
'                              -----------------
'                             /      /   \      \
'                         World  World  World  World  ...
'                                                |
'                                          Analysis List
'                                                |
'                                         --------------- 
'                                        /       |       \
'                                   Analysis Analysis Analysis ...
'
'
' The UI object heirarchy begins with the four WinSRFR Worlds:
'
'   1) EventAnalysis
'   2) PhysicalDesign
'   3) OperationsAnalysis
'   4) Simulation
'*************************************************************************************************************
Imports System.IO
Imports System.Threading
Imports Microsoft.Win32 'For Registry Access

Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI
Imports Srfr

Public Class WinSRFR
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            InitializeWinSRFR()
        Catch ex As Exception
            CriticalException("InitializeWinSRFR()", ex)
        End Try

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents FileMenu As System.Windows.Forms.MenuItem
    Friend WithEvents EditMenu As System.Windows.Forms.MenuItem
    Friend WithEvents MainToolBar As System.Windows.Forms.ToolBar
    Friend WithEvents MainStatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents TimePanel As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusPanel As System.Windows.Forms.StatusBarPanel
    Friend WithEvents EditUnitsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditUserLevelItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditUnitsSeparator As System.Windows.Forms.MenuItem
    Friend WithEvents FileExitItem As System.Windows.Forms.MenuItem
    Friend WithEvents StandardUserLevelItem As System.Windows.Forms.MenuItem
    Friend WithEvents AdvancedUserLevelItem As System.Windows.Forms.MenuItem
    Friend WithEvents ResearchUserLevelItem As System.Windows.Forms.MenuItem
    Friend WithEvents ToolbarImageList As System.Windows.Forms.ImageList
    Friend WithEvents EditUndoItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditRedoItem As System.Windows.Forms.MenuItem
    Friend WithEvents UndoRedoSeparator As System.Windows.Forms.MenuItem
    Friend WithEvents FileNewProjectItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileOpenProjectItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileCloseProjectItem As System.Windows.Forms.MenuItem
    Friend WithEvents NewProjectButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents EditUserPreferencesItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileSaveItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileSaveAsItem As System.Windows.Forms.MenuItem
    Friend WithEvents OpenProjectButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents SaveProjectButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents UndoButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents RedoButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents HelpMenu As System.Windows.Forms.MenuItem
    Friend WithEvents WhatsThisItem As System.Windows.Forms.MenuItem
    Friend WithEvents AboutWinSrfrItem As System.Windows.Forms.MenuItem
    Friend WithEvents UserLevelPanel As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ToolbarSeparator1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents EditNomenclatureItem As System.Windows.Forms.MenuItem
    Friend WithEvents SelectProjectCaseItem As System.Windows.Forms.MenuItem
    Friend WithEvents SelectFarmFieldItem As System.Windows.Forms.MenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolbarSeparator2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents WhatsThisHelpButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents ProgrammerMenu As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator3 As System.Windows.Forms.MenuItem
    Friend WithEvents FileMruItem As System.Windows.Forms.MenuItem
    Friend WithEvents ShowDataStoreExplorerItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents HelpBasicsItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpProjectsScenariorItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewPdfManualItem As System.Windows.Forms.MenuItem
    Friend WithEvents WinSrfrAnalysisPanel As DataStore.ctl_Panel
    Friend WithEvents AnalysisPanelSplitter As System.Windows.Forms.Splitter
    Friend WithEvents AnalysisExplorer As WinMain.AnalysisExplorer
    Public WithEvents AnalysisDetails As WinMain.AnalysisDetails
    Friend WithEvents WinSrfrFunctionsPanel As DataStore.ctl_Panel
    Friend WithEvents ButtonInstructions As DataStore.ctl_Label
    Friend WithEvents WinSrfrWorldsLabel As DataStore.ctl_Label
    Friend WithEvents SimulationButton As DataStore.ctl_Button
    Friend WithEvents DesignButton As DataStore.ctl_Button
    Friend WithEvents OperationsButton As DataStore.ctl_Button
    Friend WithEvents EventButton As DataStore.ctl_Button
    Friend WithEvents TitleBox As System.Windows.Forms.RichTextBox
    Friend WithEvents HelpGuiItem As System.Windows.Forms.MenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.MenuItem
    Friend WithEvents ConversionChartItem As System.Windows.Forms.MenuItem
    Friend WithEvents DataComparisonItem As System.Windows.Forms.MenuItem
    Friend WithEvents ShowClipboardViewerItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpNotationItem As System.Windows.Forms.MenuItem
    Friend WithEvents USDA_ARS_Logo As System.Windows.Forms.PictureBox
    Friend WithEvents ALARC_Logo As System.Windows.Forms.PictureBox
    Friend WithEvents FileClearAllResultsItem As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator4 As System.Windows.Forms.MenuItem
    Friend WithEvents FileExamplesItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewMenu As System.Windows.Forms.MenuItem
    Friend WithEvents ViewRefreshItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSizeItem As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSize800x600 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSize900x675 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSize949x768 As System.Windows.Forms.MenuItem
    Friend WithEvents ViewSize1024x768 As System.Windows.Forms.MenuItem
    Friend WithEvents FileSeparator5 As System.Windows.Forms.MenuItem
    Friend WithEvents FilePropertiesItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpWelcomeToWinSrfrItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpFunctionalityItem As System.Windows.Forms.MenuItem
    Friend WithEvents EditLanguageItem As System.Windows.Forms.MenuItem
    Friend WithEvents SelectLanguageItem As System.Windows.Forms.MenuItem
    Friend WithEvents NewLanguageItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpScenariosItem As MenuItem
    Friend WithEvents BasicIrrigationPropertiesItem As MenuItem
    Friend WithEvents HelpSimulationItem As MenuItem
    Friend WithEvents HelpEvaluationItem As MenuItem
    Friend WithEvents HelpOperationsItem As MenuItem
    Friend WithEvents HelpDesignItem As MenuItem
    Friend WithEvents HelpOnHelptem As MenuItem
    Friend WithEvents WinSrfrPanel As DataStore.ctl_Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinSRFR))
        Me.MainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.FileMenu = New System.Windows.Forms.MenuItem()
        Me.FileNewProjectItem = New System.Windows.Forms.MenuItem()
        Me.FileOpenProjectItem = New System.Windows.Forms.MenuItem()
        Me.FileCloseProjectItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator1 = New System.Windows.Forms.MenuItem()
        Me.FileClearAllResultsItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator2 = New System.Windows.Forms.MenuItem()
        Me.FileSaveItem = New System.Windows.Forms.MenuItem()
        Me.FileSaveAsItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator3 = New System.Windows.Forms.MenuItem()
        Me.FileExamplesItem = New System.Windows.Forms.MenuItem()
        Me.FileMruItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator4 = New System.Windows.Forms.MenuItem()
        Me.FilePropertiesItem = New System.Windows.Forms.MenuItem()
        Me.FileSeparator5 = New System.Windows.Forms.MenuItem()
        Me.FileExitItem = New System.Windows.Forms.MenuItem()
        Me.EditMenu = New System.Windows.Forms.MenuItem()
        Me.EditUndoItem = New System.Windows.Forms.MenuItem()
        Me.EditRedoItem = New System.Windows.Forms.MenuItem()
        Me.UndoRedoSeparator = New System.Windows.Forms.MenuItem()
        Me.EditNomenclatureItem = New System.Windows.Forms.MenuItem()
        Me.SelectProjectCaseItem = New System.Windows.Forms.MenuItem()
        Me.SelectFarmFieldItem = New System.Windows.Forms.MenuItem()
        Me.EditUserLevelItem = New System.Windows.Forms.MenuItem()
        Me.StandardUserLevelItem = New System.Windows.Forms.MenuItem()
        Me.AdvancedUserLevelItem = New System.Windows.Forms.MenuItem()
        Me.ResearchUserLevelItem = New System.Windows.Forms.MenuItem()
        Me.EditUserPreferencesItem = New System.Windows.Forms.MenuItem()
        Me.EditLanguageItem = New System.Windows.Forms.MenuItem()
        Me.SelectLanguageItem = New System.Windows.Forms.MenuItem()
        Me.NewLanguageItem = New System.Windows.Forms.MenuItem()
        Me.EditUnitsSeparator = New System.Windows.Forms.MenuItem()
        Me.EditUnitsMenuItem = New System.Windows.Forms.MenuItem()
        Me.ViewMenu = New System.Windows.Forms.MenuItem()
        Me.ViewRefreshItem = New System.Windows.Forms.MenuItem()
        Me.ViewSizeItem = New System.Windows.Forms.MenuItem()
        Me.ViewSize800x600 = New System.Windows.Forms.MenuItem()
        Me.ViewSize900x675 = New System.Windows.Forms.MenuItem()
        Me.ViewSize949x768 = New System.Windows.Forms.MenuItem()
        Me.ViewSize1024x768 = New System.Windows.Forms.MenuItem()
        Me.ToolsMenu = New System.Windows.Forms.MenuItem()
        Me.DataComparisonItem = New System.Windows.Forms.MenuItem()
        Me.ConversionChartItem = New System.Windows.Forms.MenuItem()
        Me.HelpMenu = New System.Windows.Forms.MenuItem()
        Me.WhatsThisItem = New System.Windows.Forms.MenuItem()
        Me.AboutWinSrfrItem = New System.Windows.Forms.MenuItem()
        Me.HelpWelcomeToWinSrfrItem = New System.Windows.Forms.MenuItem()
        Me.HelpNotationItem = New System.Windows.Forms.MenuItem()
        Me.HelpSeparator1 = New System.Windows.Forms.MenuItem()
        Me.HelpBasicsItem = New System.Windows.Forms.MenuItem()
        Me.HelpFunctionalityItem = New System.Windows.Forms.MenuItem()
        Me.HelpProjectsScenariorItem = New System.Windows.Forms.MenuItem()
        Me.HelpGuiItem = New System.Windows.Forms.MenuItem()
        Me.HelpScenariosItem = New System.Windows.Forms.MenuItem()
        Me.BasicIrrigationPropertiesItem = New System.Windows.Forms.MenuItem()
        Me.HelpSimulationItem = New System.Windows.Forms.MenuItem()
        Me.HelpEvaluationItem = New System.Windows.Forms.MenuItem()
        Me.HelpOperationsItem = New System.Windows.Forms.MenuItem()
        Me.HelpDesignItem = New System.Windows.Forms.MenuItem()
        Me.HelpSeparator2 = New System.Windows.Forms.MenuItem()
        Me.ViewPdfManualItem = New System.Windows.Forms.MenuItem()
        Me.ProgrammerMenu = New System.Windows.Forms.MenuItem()
        Me.ShowDataStoreExplorerItem = New System.Windows.Forms.MenuItem()
        Me.ShowClipboardViewerItem = New System.Windows.Forms.MenuItem()
        Me.MainToolBar = New System.Windows.Forms.ToolBar()
        Me.NewProjectButton = New System.Windows.Forms.ToolBarButton()
        Me.OpenProjectButton = New System.Windows.Forms.ToolBarButton()
        Me.SaveProjectButton = New System.Windows.Forms.ToolBarButton()
        Me.ToolbarSeparator1 = New System.Windows.Forms.ToolBarButton()
        Me.UndoButton = New System.Windows.Forms.ToolBarButton()
        Me.RedoButton = New System.Windows.Forms.ToolBarButton()
        Me.ToolbarSeparator2 = New System.Windows.Forms.ToolBarButton()
        Me.WhatsThisHelpButton = New System.Windows.Forms.ToolBarButton()
        Me.ToolbarImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.MainStatusBar = New System.Windows.Forms.StatusBar()
        Me.StatusPanel = New System.Windows.Forms.StatusBarPanel()
        Me.UserLevelPanel = New System.Windows.Forms.StatusBarPanel()
        Me.TimePanel = New System.Windows.Forms.StatusBarPanel()
        Me.WinSrfrPanel = New DataStore.ctl_Panel()
        Me.WinSrfrAnalysisPanel = New DataStore.ctl_Panel()
        Me.AnalysisPanelSplitter = New System.Windows.Forms.Splitter()
        Me.AnalysisExplorer = New WinMain.AnalysisExplorer()
        Me.AnalysisDetails = New WinMain.AnalysisDetails()
        Me.WinSrfrFunctionsPanel = New DataStore.ctl_Panel()
        Me.ALARC_Logo = New System.Windows.Forms.PictureBox()
        Me.USDA_ARS_Logo = New System.Windows.Forms.PictureBox()
        Me.ButtonInstructions = New DataStore.ctl_Label()
        Me.WinSrfrWorldsLabel = New DataStore.ctl_Label()
        Me.SimulationButton = New DataStore.ctl_Button()
        Me.DesignButton = New DataStore.ctl_Button()
        Me.OperationsButton = New DataStore.ctl_Button()
        Me.EventButton = New DataStore.ctl_Button()
        Me.TitleBox = New System.Windows.Forms.RichTextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.HelpOnHelptem = New System.Windows.Forms.MenuItem()
        CType(Me.StatusPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserLevelPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimePanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WinSrfrPanel.SuspendLayout()
        Me.WinSrfrAnalysisPanel.SuspendLayout()
        Me.WinSrfrFunctionsPanel.SuspendLayout()
        CType(Me.ALARC_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USDA_ARS_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileMenu, Me.EditMenu, Me.ViewMenu, Me.ToolsMenu, Me.HelpMenu, Me.ProgrammerMenu})
        '
        'FileMenu
        '
        Me.FileMenu.Index = 0
        Me.FileMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.FileNewProjectItem, Me.FileOpenProjectItem, Me.FileCloseProjectItem, Me.FileSeparator1, Me.FileClearAllResultsItem, Me.FileSeparator2, Me.FileSaveItem, Me.FileSaveAsItem, Me.FileSeparator3, Me.FileExamplesItem, Me.FileMruItem, Me.FileSeparator4, Me.FilePropertiesItem, Me.FileSeparator5, Me.FileExitItem})
        resources.ApplyResources(Me.FileMenu, "FileMenu")
        '
        'FileNewProjectItem
        '
        Me.FileNewProjectItem.Index = 0
        resources.ApplyResources(Me.FileNewProjectItem, "FileNewProjectItem")
        '
        'FileOpenProjectItem
        '
        Me.FileOpenProjectItem.Index = 1
        resources.ApplyResources(Me.FileOpenProjectItem, "FileOpenProjectItem")
        '
        'FileCloseProjectItem
        '
        Me.FileCloseProjectItem.Index = 2
        resources.ApplyResources(Me.FileCloseProjectItem, "FileCloseProjectItem")
        '
        'FileSeparator1
        '
        Me.FileSeparator1.Index = 3
        resources.ApplyResources(Me.FileSeparator1, "FileSeparator1")
        '
        'FileClearAllResultsItem
        '
        Me.FileClearAllResultsItem.Index = 4
        resources.ApplyResources(Me.FileClearAllResultsItem, "FileClearAllResultsItem")
        '
        'FileSeparator2
        '
        Me.FileSeparator2.Index = 5
        resources.ApplyResources(Me.FileSeparator2, "FileSeparator2")
        '
        'FileSaveItem
        '
        Me.FileSaveItem.Index = 6
        resources.ApplyResources(Me.FileSaveItem, "FileSaveItem")
        '
        'FileSaveAsItem
        '
        Me.FileSaveAsItem.Index = 7
        resources.ApplyResources(Me.FileSaveAsItem, "FileSaveAsItem")
        '
        'FileSeparator3
        '
        Me.FileSeparator3.Index = 8
        resources.ApplyResources(Me.FileSeparator3, "FileSeparator3")
        '
        'FileExamplesItem
        '
        Me.FileExamplesItem.Index = 9
        resources.ApplyResources(Me.FileExamplesItem, "FileExamplesItem")
        '
        'FileMruItem
        '
        Me.FileMruItem.Index = 10
        resources.ApplyResources(Me.FileMruItem, "FileMruItem")
        '
        'FileSeparator4
        '
        Me.FileSeparator4.Index = 11
        resources.ApplyResources(Me.FileSeparator4, "FileSeparator4")
        '
        'FilePropertiesItem
        '
        Me.FilePropertiesItem.Index = 12
        resources.ApplyResources(Me.FilePropertiesItem, "FilePropertiesItem")
        '
        'FileSeparator5
        '
        Me.FileSeparator5.Index = 13
        resources.ApplyResources(Me.FileSeparator5, "FileSeparator5")
        '
        'FileExitItem
        '
        Me.FileExitItem.Index = 14
        resources.ApplyResources(Me.FileExitItem, "FileExitItem")
        '
        'EditMenu
        '
        Me.EditMenu.Index = 1
        Me.EditMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.EditUndoItem, Me.EditRedoItem, Me.UndoRedoSeparator, Me.EditNomenclatureItem, Me.EditUserLevelItem, Me.EditUserPreferencesItem, Me.EditLanguageItem, Me.EditUnitsSeparator, Me.EditUnitsMenuItem})
        resources.ApplyResources(Me.EditMenu, "EditMenu")
        '
        'EditUndoItem
        '
        resources.ApplyResources(Me.EditUndoItem, "EditUndoItem")
        Me.EditUndoItem.Index = 0
        '
        'EditRedoItem
        '
        resources.ApplyResources(Me.EditRedoItem, "EditRedoItem")
        Me.EditRedoItem.Index = 1
        '
        'UndoRedoSeparator
        '
        Me.UndoRedoSeparator.Index = 2
        resources.ApplyResources(Me.UndoRedoSeparator, "UndoRedoSeparator")
        '
        'EditNomenclatureItem
        '
        Me.EditNomenclatureItem.Index = 3
        Me.EditNomenclatureItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.SelectProjectCaseItem, Me.SelectFarmFieldItem})
        resources.ApplyResources(Me.EditNomenclatureItem, "EditNomenclatureItem")
        '
        'SelectProjectCaseItem
        '
        Me.SelectProjectCaseItem.Index = 0
        resources.ApplyResources(Me.SelectProjectCaseItem, "SelectProjectCaseItem")
        '
        'SelectFarmFieldItem
        '
        Me.SelectFarmFieldItem.Index = 1
        resources.ApplyResources(Me.SelectFarmFieldItem, "SelectFarmFieldItem")
        '
        'EditUserLevelItem
        '
        Me.EditUserLevelItem.Index = 4
        Me.EditUserLevelItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.StandardUserLevelItem, Me.AdvancedUserLevelItem, Me.ResearchUserLevelItem})
        resources.ApplyResources(Me.EditUserLevelItem, "EditUserLevelItem")
        '
        'StandardUserLevelItem
        '
        Me.StandardUserLevelItem.Index = 0
        resources.ApplyResources(Me.StandardUserLevelItem, "StandardUserLevelItem")
        '
        'AdvancedUserLevelItem
        '
        Me.AdvancedUserLevelItem.Index = 1
        resources.ApplyResources(Me.AdvancedUserLevelItem, "AdvancedUserLevelItem")
        '
        'ResearchUserLevelItem
        '
        Me.ResearchUserLevelItem.Index = 2
        resources.ApplyResources(Me.ResearchUserLevelItem, "ResearchUserLevelItem")
        '
        'EditUserPreferencesItem
        '
        Me.EditUserPreferencesItem.Index = 5
        resources.ApplyResources(Me.EditUserPreferencesItem, "EditUserPreferencesItem")
        '
        'EditLanguageItem
        '
        Me.EditLanguageItem.Index = 6
        Me.EditLanguageItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.SelectLanguageItem, Me.NewLanguageItem})
        resources.ApplyResources(Me.EditLanguageItem, "EditLanguageItem")
        '
        'SelectLanguageItem
        '
        Me.SelectLanguageItem.Index = 0
        resources.ApplyResources(Me.SelectLanguageItem, "SelectLanguageItem")
        '
        'NewLanguageItem
        '
        Me.NewLanguageItem.Index = 1
        resources.ApplyResources(Me.NewLanguageItem, "NewLanguageItem")
        '
        'EditUnitsSeparator
        '
        Me.EditUnitsSeparator.Index = 7
        resources.ApplyResources(Me.EditUnitsSeparator, "EditUnitsSeparator")
        '
        'EditUnitsMenuItem
        '
        Me.EditUnitsMenuItem.Index = 8
        resources.ApplyResources(Me.EditUnitsMenuItem, "EditUnitsMenuItem")
        '
        'ViewMenu
        '
        Me.ViewMenu.Index = 2
        Me.ViewMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewRefreshItem, Me.ViewSizeItem})
        resources.ApplyResources(Me.ViewMenu, "ViewMenu")
        '
        'ViewRefreshItem
        '
        Me.ViewRefreshItem.Index = 0
        resources.ApplyResources(Me.ViewRefreshItem, "ViewRefreshItem")
        '
        'ViewSizeItem
        '
        Me.ViewSizeItem.Index = 1
        Me.ViewSizeItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ViewSize800x600, Me.ViewSize900x675, Me.ViewSize949x768, Me.ViewSize1024x768})
        resources.ApplyResources(Me.ViewSizeItem, "ViewSizeItem")
        '
        'ViewSize800x600
        '
        Me.ViewSize800x600.Index = 0
        resources.ApplyResources(Me.ViewSize800x600, "ViewSize800x600")
        '
        'ViewSize900x675
        '
        Me.ViewSize900x675.Index = 1
        resources.ApplyResources(Me.ViewSize900x675, "ViewSize900x675")
        '
        'ViewSize949x768
        '
        Me.ViewSize949x768.Index = 2
        resources.ApplyResources(Me.ViewSize949x768, "ViewSize949x768")
        '
        'ViewSize1024x768
        '
        Me.ViewSize1024x768.Index = 3
        resources.ApplyResources(Me.ViewSize1024x768, "ViewSize1024x768")
        '
        'ToolsMenu
        '
        Me.ToolsMenu.Index = 3
        Me.ToolsMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.DataComparisonItem, Me.ConversionChartItem})
        resources.ApplyResources(Me.ToolsMenu, "ToolsMenu")
        '
        'DataComparisonItem
        '
        Me.DataComparisonItem.Index = 0
        resources.ApplyResources(Me.DataComparisonItem, "DataComparisonItem")
        '
        'ConversionChartItem
        '
        Me.ConversionChartItem.Index = 1
        resources.ApplyResources(Me.ConversionChartItem, "ConversionChartItem")
        '
        'HelpMenu
        '
        Me.HelpMenu.Index = 4
        Me.HelpMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.WhatsThisItem, Me.AboutWinSrfrItem, Me.HelpWelcomeToWinSrfrItem, Me.HelpOnHelptem, Me.HelpNotationItem, Me.HelpSeparator1, Me.HelpBasicsItem, Me.HelpScenariosItem, Me.HelpSeparator2, Me.ViewPdfManualItem})
        resources.ApplyResources(Me.HelpMenu, "HelpMenu")
        '
        'WhatsThisItem
        '
        Me.WhatsThisItem.Index = 0
        resources.ApplyResources(Me.WhatsThisItem, "WhatsThisItem")
        '
        'AboutWinSrfrItem
        '
        Me.AboutWinSrfrItem.Index = 1
        resources.ApplyResources(Me.AboutWinSrfrItem, "AboutWinSrfrItem")
        '
        'HelpWelcomeToWinSrfrItem
        '
        Me.HelpWelcomeToWinSrfrItem.Index = 2
        resources.ApplyResources(Me.HelpWelcomeToWinSrfrItem, "HelpWelcomeToWinSrfrItem")
        '
        'HelpNotationItem
        '
        Me.HelpNotationItem.Index = 4
        resources.ApplyResources(Me.HelpNotationItem, "HelpNotationItem")
        '
        'HelpSeparator1
        '
        Me.HelpSeparator1.Index = 5
        resources.ApplyResources(Me.HelpSeparator1, "HelpSeparator1")
        '
        'HelpBasicsItem
        '
        Me.HelpBasicsItem.Index = 6
        Me.HelpBasicsItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.HelpFunctionalityItem, Me.HelpProjectsScenariorItem, Me.HelpGuiItem})
        resources.ApplyResources(Me.HelpBasicsItem, "HelpBasicsItem")
        '
        'HelpFunctionalityItem
        '
        Me.HelpFunctionalityItem.Index = 0
        resources.ApplyResources(Me.HelpFunctionalityItem, "HelpFunctionalityItem")
        '
        'HelpProjectsScenariorItem
        '
        Me.HelpProjectsScenariorItem.Index = 1
        resources.ApplyResources(Me.HelpProjectsScenariorItem, "HelpProjectsScenariorItem")
        '
        'HelpGuiItem
        '
        Me.HelpGuiItem.Index = 2
        resources.ApplyResources(Me.HelpGuiItem, "HelpGuiItem")
        '
        'HelpScenariosItem
        '
        Me.HelpScenariosItem.Index = 7
        Me.HelpScenariosItem.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.BasicIrrigationPropertiesItem, Me.HelpSimulationItem, Me.HelpEvaluationItem, Me.HelpOperationsItem, Me.HelpDesignItem})
        resources.ApplyResources(Me.HelpScenariosItem, "HelpScenariosItem")
        '
        'BasicIrrigationPropertiesItem
        '
        Me.BasicIrrigationPropertiesItem.Index = 0
        resources.ApplyResources(Me.BasicIrrigationPropertiesItem, "BasicIrrigationPropertiesItem")
        '
        'HelpSimulationItem
        '
        Me.HelpSimulationItem.Index = 1
        resources.ApplyResources(Me.HelpSimulationItem, "HelpSimulationItem")
        '
        'HelpEvaluationItem
        '
        Me.HelpEvaluationItem.Index = 2
        resources.ApplyResources(Me.HelpEvaluationItem, "HelpEvaluationItem")
        '
        'HelpOperationsItem
        '
        Me.HelpOperationsItem.Index = 3
        resources.ApplyResources(Me.HelpOperationsItem, "HelpOperationsItem")
        '
        'HelpDesignItem
        '
        Me.HelpDesignItem.Index = 4
        resources.ApplyResources(Me.HelpDesignItem, "HelpDesignItem")
        '
        'HelpSeparator2
        '
        Me.HelpSeparator2.Index = 8
        resources.ApplyResources(Me.HelpSeparator2, "HelpSeparator2")
        '
        'ViewPdfManualItem
        '
        Me.ViewPdfManualItem.Index = 9
        resources.ApplyResources(Me.ViewPdfManualItem, "ViewPdfManualItem")
        '
        'ProgrammerMenu
        '
        Me.ProgrammerMenu.Index = 5
        Me.ProgrammerMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ShowDataStoreExplorerItem, Me.ShowClipboardViewerItem})
        resources.ApplyResources(Me.ProgrammerMenu, "ProgrammerMenu")
        '
        'ShowDataStoreExplorerItem
        '
        Me.ShowDataStoreExplorerItem.Index = 0
        resources.ApplyResources(Me.ShowDataStoreExplorerItem, "ShowDataStoreExplorerItem")
        '
        'ShowClipboardViewerItem
        '
        Me.ShowClipboardViewerItem.Index = 1
        resources.ApplyResources(Me.ShowClipboardViewerItem, "ShowClipboardViewerItem")
        '
        'MainToolBar
        '
        resources.ApplyResources(Me.MainToolBar, "MainToolBar")
        Me.MainToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.NewProjectButton, Me.OpenProjectButton, Me.SaveProjectButton, Me.ToolbarSeparator1, Me.UndoButton, Me.RedoButton, Me.ToolbarSeparator2, Me.WhatsThisHelpButton})
        Me.MainToolBar.ImageList = Me.ToolbarImageList
        Me.MainToolBar.Name = "MainToolBar"
        '
        'NewProjectButton
        '
        resources.ApplyResources(Me.NewProjectButton, "NewProjectButton")
        Me.NewProjectButton.Name = "NewProjectButton"
        '
        'OpenProjectButton
        '
        resources.ApplyResources(Me.OpenProjectButton, "OpenProjectButton")
        Me.OpenProjectButton.Name = "OpenProjectButton"
        '
        'SaveProjectButton
        '
        resources.ApplyResources(Me.SaveProjectButton, "SaveProjectButton")
        Me.SaveProjectButton.Name = "SaveProjectButton"
        '
        'ToolbarSeparator1
        '
        Me.ToolbarSeparator1.Name = "ToolbarSeparator1"
        Me.ToolbarSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'UndoButton
        '
        resources.ApplyResources(Me.UndoButton, "UndoButton")
        Me.UndoButton.Name = "UndoButton"
        '
        'RedoButton
        '
        resources.ApplyResources(Me.RedoButton, "RedoButton")
        Me.RedoButton.Name = "RedoButton"
        '
        'ToolbarSeparator2
        '
        Me.ToolbarSeparator2.Name = "ToolbarSeparator2"
        Me.ToolbarSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'WhatsThisHelpButton
        '
        resources.ApplyResources(Me.WhatsThisHelpButton, "WhatsThisHelpButton")
        Me.WhatsThisHelpButton.Name = "WhatsThisHelpButton"
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
        'MainStatusBar
        '
        resources.ApplyResources(Me.MainStatusBar, "MainStatusBar")
        Me.MainStatusBar.Name = "MainStatusBar"
        Me.MainStatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusPanel, Me.UserLevelPanel, Me.TimePanel})
        Me.MainStatusBar.ShowPanels = True
        '
        'StatusPanel
        '
        Me.StatusPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        resources.ApplyResources(Me.StatusPanel, "StatusPanel")
        '
        'UserLevelPanel
        '
        resources.ApplyResources(Me.UserLevelPanel, "UserLevelPanel")
        '
        'TimePanel
        '
        resources.ApplyResources(Me.TimePanel, "TimePanel")
        '
        'WinSrfrPanel
        '
        Me.WinSrfrPanel.Controls.Add(Me.WinSrfrAnalysisPanel)
        Me.WinSrfrPanel.Controls.Add(Me.WinSrfrFunctionsPanel)
        Me.WinSrfrPanel.Controls.Add(Me.TitleBox)
        resources.ApplyResources(Me.WinSrfrPanel, "WinSrfrPanel")
        Me.WinSrfrPanel.Name = "WinSrfrPanel"
        '
        'WinSrfrAnalysisPanel
        '
        resources.ApplyResources(Me.WinSrfrAnalysisPanel, "WinSrfrAnalysisPanel")
        Me.WinSrfrAnalysisPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WinSrfrAnalysisPanel.Controls.Add(Me.AnalysisPanelSplitter)
        Me.WinSrfrAnalysisPanel.Controls.Add(Me.AnalysisExplorer)
        Me.WinSrfrAnalysisPanel.Controls.Add(Me.AnalysisDetails)
        Me.WinSrfrAnalysisPanel.Name = "WinSrfrAnalysisPanel"
        '
        'AnalysisPanelSplitter
        '
        Me.AnalysisPanelSplitter.BackColor = System.Drawing.SystemColors.ControlDark
        resources.ApplyResources(Me.AnalysisPanelSplitter, "AnalysisPanelSplitter")
        Me.AnalysisPanelSplitter.Name = "AnalysisPanelSplitter"
        Me.AnalysisPanelSplitter.TabStop = False
        '
        'AnalysisExplorer
        '
        resources.ApplyResources(Me.AnalysisExplorer, "AnalysisExplorer")
        Me.AnalysisExplorer.Name = "AnalysisExplorer"
        '
        'AnalysisDetails
        '
        resources.ApplyResources(Me.AnalysisDetails, "AnalysisDetails")
        Me.AnalysisDetails.Name = "AnalysisDetails"
        '
        'WinSrfrFunctionsPanel
        '
        resources.ApplyResources(Me.WinSrfrFunctionsPanel, "WinSrfrFunctionsPanel")
        Me.WinSrfrFunctionsPanel.Controls.Add(Me.ALARC_Logo)
        Me.WinSrfrFunctionsPanel.Controls.Add(Me.USDA_ARS_Logo)
        Me.WinSrfrFunctionsPanel.Controls.Add(Me.ButtonInstructions)
        Me.WinSrfrFunctionsPanel.Controls.Add(Me.WinSrfrWorldsLabel)
        Me.WinSrfrFunctionsPanel.Controls.Add(Me.SimulationButton)
        Me.WinSrfrFunctionsPanel.Controls.Add(Me.DesignButton)
        Me.WinSrfrFunctionsPanel.Controls.Add(Me.OperationsButton)
        Me.WinSrfrFunctionsPanel.Controls.Add(Me.EventButton)
        Me.WinSrfrFunctionsPanel.Name = "WinSrfrFunctionsPanel"
        '
        'ALARC_Logo
        '
        resources.ApplyResources(Me.ALARC_Logo, "ALARC_Logo")
        Me.ALARC_Logo.Name = "ALARC_Logo"
        Me.ALARC_Logo.TabStop = False
        '
        'USDA_ARS_Logo
        '
        resources.ApplyResources(Me.USDA_ARS_Logo, "USDA_ARS_Logo")
        Me.USDA_ARS_Logo.Name = "USDA_ARS_Logo"
        Me.USDA_ARS_Logo.TabStop = False
        '
        'ButtonInstructions
        '
        resources.ApplyResources(Me.ButtonInstructions, "ButtonInstructions")
        Me.ButtonInstructions.Name = "ButtonInstructions"
        '
        'WinSrfrWorldsLabel
        '
        resources.ApplyResources(Me.WinSrfrWorldsLabel, "WinSrfrWorldsLabel")
        Me.WinSrfrWorldsLabel.Name = "WinSrfrWorldsLabel"
        '
        'SimulationButton
        '
        resources.ApplyResources(Me.SimulationButton, "SimulationButton")
        Me.SimulationButton.BackColor = System.Drawing.Color.Gray
        Me.SimulationButton.ForeColor = System.Drawing.Color.White
        Me.SimulationButton.Name = "SimulationButton"
        Me.ToolTip.SetToolTip(Me.SimulationButton, resources.GetString("SimulationButton.ToolTip"))
        Me.SimulationButton.UseVisualStyleBackColor = False
        '
        'DesignButton
        '
        resources.ApplyResources(Me.DesignButton, "DesignButton")
        Me.DesignButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.DesignButton.Name = "DesignButton"
        Me.ToolTip.SetToolTip(Me.DesignButton, resources.GetString("DesignButton.ToolTip"))
        Me.DesignButton.UseVisualStyleBackColor = False
        '
        'OperationsButton
        '
        resources.ApplyResources(Me.OperationsButton, "OperationsButton")
        Me.OperationsButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.OperationsButton.Name = "OperationsButton"
        Me.ToolTip.SetToolTip(Me.OperationsButton, resources.GetString("OperationsButton.ToolTip"))
        Me.OperationsButton.UseVisualStyleBackColor = False
        '
        'EventButton
        '
        resources.ApplyResources(Me.EventButton, "EventButton")
        Me.EventButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.EventButton.Name = "EventButton"
        Me.ToolTip.SetToolTip(Me.EventButton, resources.GetString("EventButton.ToolTip"))
        Me.EventButton.UseVisualStyleBackColor = False
        '
        'TitleBox
        '
        resources.ApplyResources(Me.TitleBox, "TitleBox")
        Me.TitleBox.Name = "TitleBox"
        Me.TitleBox.ReadOnly = True
        '
        'HelpOnHelptem
        '
        Me.HelpOnHelptem.Index = 3
        resources.ApplyResources(Me.HelpOnHelptem, "HelpOnHelptem")
        '
        'WinSRFR
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.WinSrfrPanel)
        Me.Controls.Add(Me.MainStatusBar)
        Me.Controls.Add(Me.MainToolBar)
        Me.HelpButton = True
        Me.Menu = Me.MainMenu
        Me.Name = "WinSRFR"
        CType(Me.StatusPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserLevelPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimePanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WinSrfrPanel.ResumeLayout(False)
        Me.WinSrfrAnalysisPanel.ResumeLayout(False)
        Me.WinSrfrFunctionsPanel.ResumeLayout(False)
        CType(Me.ALARC_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USDA_ARS_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Member Data "

#Region " UI Data "
    '
    ' Language Translation
    '
    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' World Windows
    '
    Private WithEvents mDesignWorld As DesignWorld = New DesignWorld(Me)
    Private WithEvents mEvaluationWorld As EvaluationWorld = New EvaluationWorld(Me)
    Private WithEvents mOperationsWorld As OperationsWorld = New OperationsWorld(Me)
    Private WithEvents mSimulationWorld As SimulationWorld = New SimulationWorld(Me)
    '
    ' Tools
    '
    Private mDataComparer As DataComparer = New DataComparer(Me)
    '
    ' Help & Manual
    '
    Private PdfViewerDb As PdfViewerDialog = Nothing
    Private PdfDialogViewerDb As PdfViewerDialog = Nothing
    '
    ' Units System
    '
    Private Shared mUnitsSystem As UnitsSystem = UnitsSystem.Instance()
    Private Shared mUnitsDialogBox As UnitsDialogBox = New UnitsDialogBox
    Public Shared ReadOnly Property UnitsDialogBox() As UnitsDialogBox
        Get
            Return mUnitsDialogBox
        End Get
    End Property
    '
    ' User Preferences
    '
    Private Shared mUserPreferences As UserPreferences = UserPreferences.Instance()
    Public Shared ReadOnly Property UserPreferences() As UserPreferences
        Get
            Return mUserPreferences
        End Get
    End Property
    '
    ' Title string for Window Title bar
    '
    Public ReadOnly Property Title() As String
        Get
            Title = WinSrfrName & " " & Version & " " & mDictionary.tProjectManagement.Translated
        End Get
    End Property
    '
    ' Build date & time
    '
    Public Shared ReadOnly Property BuildDateTime() As DateTime
        Get
            Return Microsoft.VisualBasic.FileDateTime(WinSrfrPath)
        End Get
    End Property
    '
    ' Project Nomenclature
    '
    Public Property ProjectNomenclature() As ProjectNomenclatures
        Get
            Return ReadProjectNomenclature()
        End Get
        Set(ByVal Value As ProjectNomenclatures)
            ' Save new Project Nomenclature in the Registry
            SaveProjectNomenclature(Value)

            UpdateUI()
            RaiseEvent WinSrfrUpdated(Reasons.Nomenclature)
        End Set
    End Property

    Public ReadOnly Property ProjectFarmText() As String
        Get
            If (ProjectNomenclature = Globals.ProjectNomenclatures.ProjectCase) Then
                Return mDictionary.tProject.Translated
            End If

            Return mDictionary.tFarm.Translated
        End Get
    End Property

    Public ReadOnly Property CaseFieldText() As String
        Get
            If (ProjectNomenclature = Globals.ProjectNomenclatures.ProjectCase) Then
                Return mDictionary.tCase.Translated
            End If

            Return mDictionary.tField.Translated
        End Get
    End Property
    '
    ' Project Nomenclature (Farm/Field vs. Project/Case)
    '
    Private Function ReadProjectNomenclature() As ProjectNomenclatures

        Dim _nomenclature As ProjectNomenclatures = DefaultProjectNomenclature

        ' Read the Nomenclature in the Registry
        Try
            ' Open the Current User / Software keys
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Read Nomenclature
                            Dim _integer As Integer = CInt(_regKey.GetValue(sProjectNomenclature, DefaultProjectNomenclature))
                            If ((ProjectNomenclatures.LowLimit < _integer) And (_integer < ProjectNomenclatures.HighLimit)) Then
                                _nomenclature = CType(_integer, ProjectNomenclatures)
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors; use the default Nomenclature
        End Try

        Return _nomenclature

    End Function

    Private Sub SaveProjectNomenclature(ByVal _nomenclature As ProjectNomenclatures)

        ' Save the Project Nomenclature in the Registry
        Try
            ' Open the Current User / Software key
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Write Project Nomenclature
                            Dim _integer As Integer = _nomenclature
                            _regKey.SetValue(sProjectNomenclature, _integer)

                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors
        End Try

    End Sub
    '
    ' Default window size
    '
    Public Property WindowSize() As WindowSizes
        Get
            Return ReadWindowSize()
        End Get
        Set(ByVal Value As WindowSizes)
            ' Save new Window Size in the Registry
            SaveWindowSize(Value)
        End Set
    End Property

    Private Function ReadWindowSize() As WindowSizes

        Dim _size As WindowSizes = DefaultWindowSize

        ' Read the Window Size in the Registry
        Try
            ' Open the Current User / Software keys
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Read Window Size
                            Dim _integer As Integer = CInt(_regKey.GetValue(sWindowSize, DefaultWindowSize))
                            If ((WindowSizes.LowLimit < _integer) And (_integer < WindowSizes.HighLimit)) Then
                                _size = CType(_integer, WindowSizes)
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors; use the default Window Size
            _size = DefaultWindowSize
        End Try

        Return _size

    End Function

    Private Sub SaveWindowSize(ByVal _size As WindowSizes)

        ' Save the Window Size in the Registry
        Try
            ' Open the Current User / Software key
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Write Project Nomenclature
                            Dim _integer As Integer = _size
                            _regKey.SetValue(sWindowSize, _integer)

                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors
        End Try

    End Sub
    '
    ' Language support
    '
    Public Property Language() As String
        Get
            Language = ReadLanguage()                               ' Read current language from Registry
            Dictionary.ForeignLanguage = Language                   ' Update Dictionary with current language
        End Get
        Set(ByVal Value As String)
            If (Value IsNot Nothing) Then
                If Not (Value = String.Empty) Then
                    SaveLanguage(Value)                             ' Save new language to Registry
                    Dictionary.ForeignLanguage = Value              ' Update Dictionary with new language
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property LanguageFamily() As String
        Get
            LanguageFamily = Me.Language
            LanguageFamily = LanguageFamily.Substring(0, LanguageFamily.IndexOf(" "))
        End Get
    End Property

    Private Function ReadLanguage() As String

        ' Read the Language in the Registry
        Dim language As String = sNativeLanguage

        Try
            ' Open the Current User / Software keys
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Read Language selection
                            language = CStr(_regKey.GetValue(sLanguage, sNativeLanguage))
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors
        End Try

        Return language
    End Function

    Private Sub SaveLanguage(ByVal language As String)

        ' Save the Language in the Registry
        Try
            ' Open the Current User / Software key
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then
                            ' Write Language
                            _regKey.SetValue(sLanguage, language)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors
        End Try

    End Sub

    Private Sub OpenLanguage(ByVal language As String)
        Dim errCode As Translator.ErrorCode

        ' Open (i.e. switch) to selected language
        If (language = sNativeLanguage) Then ' Native language selected; reset translation

            Me.Language = sNativeLanguage    ' Save language specified in Registry

        Else ' Foreign Language selected; load its translation file

            ' Get path to Languages directory
            Dim allUsersPath As String = Application.CommonAppDataPath
            Dim lastBackslash As Integer = allUsersPath.LastIndexOf("\")
            Dim allUsersWinSrfrPath As String = allUsersPath.Substring(0, lastBackslash)
            Dim languagesPath As String = allUsersWinSrfrPath & "\Languages"

            ' Create paths to possible Language files
            Dim languagePath As String = languagesPath & "\" & language
            Dim txtPath As String = languagePath & ".txt"
            Dim binPath As String = languagePath & ".bin"
            Dim Path As String = ""

            ' Open Language file
            If (File.Exists(txtPath)) Then
                Path = txtPath
                errCode = mDictionary.OpenForeignLanguage(Path)
            ElseIf (File.Exists(binPath)) Then
                Path = binPath
                errCode = mDictionary.OpenForeignLanguage(Path)
            Else
                errCode = Translator.ErrorCode.NoData
            End If

            ' Save selection as current Language in Registry
            If (Translator.ErrorCode.OK <= errCode) Then
                Me.Language = language
            Else
                Dim title As String = mDictionary.tFileReadError.Native
                Dim msg As String = Path
                msg &= Chr(13) & Chr(13)
                msg &= mDictionary.tInvalidTranslationFile.ToString & " (" & errCode.ToString & ")"
                msg &= Chr(13) & Chr(13)
                msg &= mDictionary.tResetingLanguageTo.Translated & ": " & sNativeLanguage
                MsgBox(msg, MsgBoxStyle.Exclamation, title)

                Me.Language = sNativeLanguage
            End If
        End If

        ' Update to the current language translation
        UpdateTranslation(Me, Me.Language)

        RaiseEvent WinSrfrUpdated(Reasons.Language)

        UpdateUI()

    End Sub
    '
    ' DataStore Explorer
    '
    Private mDataStoreExplorer As DataStoreExplorer = DataStoreExplorer.Instance()
    Public ReadOnly Property DataStoreExplorer() As DataStoreExplorer
        Get
            Return mDataStoreExplorer
        End Get
    End Property
    '
    ' Furrow Inflow Rate Enable Warning has been shown
    '
    Private mFurrowInflowRateWarning As Boolean = False
    Public Property FurrowInflowRateWarning() As Boolean
        Get
            Return mFurrowInflowRateWarning
        End Get
        Set(ByVal Value As Boolean)
            mFurrowInflowRateWarning = Value
        End Set
    End Property
    '
    ' Colors
    '
    Public ReadOnly Property DesignBackColor() As System.Drawing.Color
        Get
            Return DesignButton.BackColor
        End Get
    End Property
    Public ReadOnly Property DesignForeColor() As System.Drawing.Color
        Get
            Return DesignButton.ForeColor
        End Get
    End Property
    Public ReadOnly Property EventBackColor() As System.Drawing.Color
        Get
            Return EventButton.BackColor
        End Get
    End Property
    Public ReadOnly Property EventForeColor() As System.Drawing.Color
        Get
            Return EventButton.ForeColor
        End Get
    End Property
    Public ReadOnly Property OperationsBackColor() As System.Drawing.Color
        Get
            Return OperationsButton.BackColor
        End Get
    End Property
    Public ReadOnly Property OperationsForeColor() As System.Drawing.Color
        Get
            Return OperationsButton.ForeColor
        End Get
    End Property
    Public ReadOnly Property SimulationBackColor() As System.Drawing.Color
        Get
            Return SimulationButton.BackColor
        End Get
    End Property
    Public ReadOnly Property SimulationForeColor() As System.Drawing.Color
        Get
            Return SimulationButton.ForeColor
        End Get
    End Property
    '
    ' Windows messages redefined from WinUser.h
    '
    Private Const HTCLIENT As Integer = &H1
    Private Const HTCAPTION As Integer = &H2
    Private Const WM_WINDOWPOSCHANGING As Integer = &H46
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1

    Private Const WM_MOUSEMOVE As Integer = &H200
    Private Const WM_LBUTTONDOWN As Integer = &H201
    Private Const WM_LBUTTONUP As Integer = &H202
    Private Const WM_LBUTTONDBLCLK As Integer = &H203
    Private Const WM_RBUTTONDOWN As Integer = &H204
    Private Const WM_RBUTTONUP As Integer = &H205
    Private Const WM_RBUTTONDBLCLK As Integer = &H206
    Private Const WM_MBUTTONDOWN As Integer = &H207
    Private Const WM_MBUTTONUP As Integer = &H208
    Private Const WM_MBUTTONDBLCLK As Integer = &H209
    '
    ' Popup What's This? help
    '
    Private mWhatsThisHelp As Boolean = False
    Private mOldCursor As Cursor = Nothing
    Private mHelpPopup As Windows.Forms.RichTextBox = Nothing
    '
    ' Help
    '
    Private Shared mFirstHelpUse As Boolean = True

#End Region

#Region " CI Data "

    ' Class that parses & executes remote commands
    Private mCommandInterface As CommandInterface
    Public ReadOnly Property CommandInterface() As CommandInterface
        Get
            Return mCommandInterface
        End Get
    End Property

#End Region

#Region " File I/O Data "
    '
    ' WinSRFR filename, directory & path
    '
    Private Shared ReadOnly Property WinSrfrPath() As String
        Get
            Return Application.ExecutablePath
        End Get
    End Property

    Private Shared ReadOnly Property WinSrfrDirectory() As String
        Get
            ' Return the WinSRFR Directory including the ending "\"
            Return WinSrfrPath.Substring(0, WinSrfrPath.LastIndexOf("\") + 1)
        End Get
    End Property

    Private Shared ReadOnly Property WinSrfrFilename() As String
        Get
            Return WinSrfrPath.Substring(WinSrfrPath.LastIndexOf("\") + 1)
        End Get
    End Property
    '
    ' Default WinSRFR filename
    '
    Private Const mDefaultFileName As String = WinSrfrName + " Project.srfr"
    Public ReadOnly Property DefaultFileName() As String
        Get
            Return mDefaultFileName
        End Get
    End Property
    '
    ' PDF Manual filename & path
    '
    Public Const PdfFilename As String = "WinSRFR5.pdf"
    Public Shared ReadOnly Property PdfFilePath() As String
        Get
            Return WinSrfrDirectory() + PdfFilename
        End Get
    End Property
    '
    ' Data filenames & paths
    '
    Public ReadOnly Property LogDirectory() As String
        Get
            Return UserPreferences.DefaultLogFolder
        End Get
    End Property

    Public Const ErrorLogFilename As String = "WinSRFR.errlog"
    Public ReadOnly Property ErrorLogFilePath() As String
        Get
            Return LogDirectory() + "\" + ErrorLogFilename
        End Get
    End Property
    '
    ' Current and last file names
    '   File name is only the name; no path (may be "" for New Projects)
    '   File path is stored in registry for future program startup
    '
    Private mFileName As String = String.Empty
    Public ReadOnly Property FileName() As String
        Get
            Return mFileName
        End Get
    End Property

    Private mFilePath As String = String.Empty
    Public Property FilePath() As String
        Get
            Return mFilePath
        End Get
        Set(ByVal Value As String)
            mFileName = Value.Substring(Value.LastIndexOf("\") + 1)
            mFilePath = Value
        End Set
    End Property
    '
    ' Examples File List
    '
    Private mExamplesFileList As ArrayList = New ArrayList
    Public ReadOnly Property ExamplesFileList() As ArrayList
        Get
            Return mExamplesFileList
        End Get
    End Property
    '
    ' Most Recently Used (MRU) Project List (stored in the Registry)
    '
    Private Const mMaxMruFiles As Integer = 9
    Private mMruProjectList As ArrayList = New ArrayList
    Public ReadOnly Property MruProjectList() As ArrayList
        Get
            Return mMruProjectList
        End Get
    End Property
    '
    ' Languages List
    '
    Private mLanguagesList As ArrayList = New ArrayList
    Public ReadOnly Property LanguagesList() As ArrayList
        Get
            Return mLanguagesList
        End Get
    End Property
    '
    ' File Opened / Saved timestamp
    '
    Private mFileTimestamp As DateTime
    Private Property FileTimestamp() As DateTime
        Get
            Return mFileTimestamp
        End Get
        Set(ByVal Value As DateTime)
            mFileTimestamp = Value
        End Set
    End Property

#End Region

#Region " Selected Objects Data "
    '
    ' Selected Farm, Field, Function & Analysis
    '
    Private WithEvents mSelectedFarm As Farm
    Public Property SelectedFarm() As Farm
        Get
            Return mSelectedFarm
        End Get
        Set(ByVal Value As Farm)
            If Not (mSelectedFarm Is Value) Then
                mSelectedFarm = Value
                UpdateUI()
                AnalysisExplorer.SelectFarm(mSelectedFarm)
            End If
        End Set
    End Property

    Private WithEvents mSelectedField As Field
    Public Property SelectedField() As Field
        Get
            Return mSelectedField
        End Get
        Set(ByVal Value As Field)
            If Not (mSelectedField Is Value) Then
                mSelectedField = Value
                UpdateUI()
                AnalysisExplorer.SelectField(mSelectedField)
            End If
        End Set
    End Property

    Private WithEvents mSelectedWorld As World
    Public Property SelectedWorld() As World
        Get
            Return mSelectedWorld
        End Get
        Set(ByVal Value As World)
            If Not (mSelectedWorld Is Value) Then
                mSelectedWorld = Value
                If Not (mSelectedWorld Is Nothing) Then
                    mSelectedAnalysis = mSelectedWorld.GetFirstAnalysis
                Else
                    mSelectedAnalysis = Nothing
                End If
            End If
        End Set
    End Property

    Private mSelectedAnalysis As Unit
    Public Property SelectedAnalysis() As Unit
        Get
            Return mSelectedAnalysis
        End Get
        Set(ByVal Value As Unit)
            If Not (mSelectedAnalysis Is Value) Then
                mSelectedAnalysis = Value
            End If
        End Set
    End Property

#End Region

#Region " SRFR Access "

    ' SRFR API
    Private mSrfrAPI As Srfr.SrfrAPI
    Protected Friend Function SrfrAPI() As Srfr.SrfrAPI
        Return mSrfrAPI
    End Function

    ' Reference SRFR objects
    Private mRefSrfrAPIs As ArrayList
    Protected Friend Property RefSrfrAPI(ByVal SrfrID As String) As Srfr.SrfrAPI
        Get
            RefSrfrAPI = Nothing
            If (mRefSrfrAPIs IsNot Nothing) Then
                For Each obj As Object In mRefSrfrAPIs
                    If (obj.GetType Is GetType(Srfr.SrfrAPI)) Then
                        Dim srfrAPI As Srfr.SrfrAPI = DirectCast(obj, Srfr.SrfrAPI)
                        If (srfrAPI.SrfrID = SrfrID) Then
                            RefSrfrAPI = srfrAPI
                            Exit For
                        End If
                    End If
                Next obj
            End If
        End Get
        Set(ByVal value As Srfr.SrfrAPI)
            If (mRefSrfrAPIs Is Nothing) Then
                mRefSrfrAPIs = New ArrayList
            End If
            value.SrfrID = SrfrID
            value.IsRefSrfrAPI = True
            mRefSrfrAPIs.Add(value)
        End Set
    End Property

    Protected Friend Sub RemoveRefSrfrAPI(ByVal SrfrID As String)
        If (mRefSrfrAPIs IsNot Nothing) Then
            For Each obj As Object In mRefSrfrAPIs
                If (obj.GetType Is GetType(Srfr.SrfrAPI)) Then
                    Dim srfrAPI As Srfr.SrfrAPI = DirectCast(obj, Srfr.SrfrAPI)
                    If (srfrAPI.SrfrID = SrfrID) Then
                        mRefSrfrAPIs.Remove(obj)
                        Exit For
                    End If
                End If
            Next obj
        End If
    End Sub

#End Region

#End Region

#Region " Identification "
    '
    ' My ID
    '
    Public Shared ReadOnly Property MyID() As String
        Get
            Return Application.ProductName
        End Get
    End Property

    Public Shared ReadOnly Property Version() As String
        Get
            Version = Application.ProductVersion
        End Get
    End Property
    '
    ' My Environment
    '
    Public Shared ReadOnly Property DebuggerIsAttached() As Boolean
        Get
            Return System.Diagnostics.Debugger.IsAttached
        End Get
    End Property
    '
    ' Data Store
    '
    Private WithEvents mDataStore As DataStore.DataStore = DataStore.DataStore.Instance()
    Private WithEvents mMyStore As DataStore.ObjectNode = Nothing
    Public ReadOnly Property MyStore() As DataStore.ObjectNode
        Get
            Return mMyStore
        End Get
    End Property

    Public Sub LinkToDataStore()
        If Not (mDataStore Is Nothing) Then
            mMyStore = mDataStore.GetRoot(MyID)
            If (mMyStore Is Nothing) Then
                CriticalError("GetRoot(MyID) failed", "WinSRFR:LinkToDataStore()")
            End If
        Else
            CriticalError("DataStore Is Nothing", "WinSRFR:LinkToDataStore()")
        End If
    End Sub

#End Region

#Region " Serialized Properties "
    '
    ' Project Name & Version
    '
    Public Const sProductName As String = "Project Name"
    Public Const sProductVersion As String = "Project Version"
    '
    ' Farm Suffix
    '
    Private Const sFarmSuffix As String = "Farm Suffix"

    Private Property FarmSuffix() As IntegerParameter
        Get
            Return mMyStore.GetIntegerParameter(sFarmSuffix)
        End Get
        Set(ByVal Value As IntegerParameter)
            mMyStore.SetParameter(sFarmSuffix, Value)
        End Set
    End Property

#End Region

#Region " Farm List "

    Private mFarmList As New ArrayList
    '
    ' Add a Farm to the list
    '
    Public Function AddFarm() As Farm

        ' Generate a unique ID for the Farm
        Dim _integer As DataStore.IntegerParameter = FarmSuffix
        _integer.Value = _integer.Value + 1
        _integer.Source = DataStore.Globals.ValueSources.Calculated
        FarmSuffix = _integer

        Dim _farmID As String = String.Format("Farm{0}", FarmSuffix.Value)

        ' Create the Farm with a unique ID
        mDataStore.MarkForUndo(mDictionary.tAdd.Translated & " " & ProjectFarmText)

        Dim _farm As Farm = New Farm(_farmID, Me)

        If Not (_farm Is Nothing) Then

            ' Start with Farm Name/Owner from User Preferences, if possible
            Dim _name As StringParameter = _farm.Name
            If Not (UserPreferences.DefaultFarmName = String.Empty) Then
                ' Use farm name from User Preference if there is one
                _name.Value = UserPreferences.DefaultFarmName
            Else
                ' Use default farm name if not
                _name.Value = ProjectFarmText + " 1"
            End If
            _name.Source = DataStore.Globals.ValueSources.Calculated
            _farm.Name = _name

            ' Use default farm owner from User Preferences
            Dim _owner As StringParameter = _farm.Owner
            _owner.Value = UserPreferences.DefaultFarmOwner
            _farm.Owner = _owner

            ' Add the Farm to the Farm List
            mFarmList.Add(_farm)
            AnalysisExplorer.AddFarm(_farm)
        Else
            Debug.Assert(False, ProjectFarmText + " was not created")
            SeriousError("WinSRFR[AddFarm]", ProjectFarmText + " was not created")
        End If

        Return _farm

    End Function

    Public Function AddFarm(ByVal _farmObject As DataStore.ObjectNode) As Farm

        If Not (_farmObject Is Nothing) Then

            ' Generate a unique ID for the Farm
            Dim _integer As DataStore.IntegerParameter = FarmSuffix
            _integer.Value = _integer.Value + 1
            _integer.Source = DataStore.Globals.ValueSources.Calculated
            FarmSuffix = _integer

            _farmObject.MyID() = String.Format("Farm{0}", FarmSuffix.Value)

            ' Add it to the DataStore
            MyStore.AddObject(_farmObject)

            ' Create the Farm for the Farm Object
            Dim _farm As Farm = New Farm(_farmObject, Me)

            ' Add it to the Farm List
            If Not (_farm Is Nothing) Then
                mFarmList.Add(_farm)
                Return _farm
            Else
                Debug.Assert(False, "Farm is Nothing")
            End If
        Else
            Debug.Assert(False, "Farm Object is Nothing")
        End If

        Return Nothing

    End Function
    '
    ' Delete a Farm from the list
    '
    Private Sub DeleteFarm(ByVal _farm As Farm)

        If Not (_farm Is Nothing) Then
            ' Remove the Farm from the Farm List and from the DataStore
            mFarmList.Remove(_farm)
            _farm.Remove()
        End If
    End Sub
    '
    ' Return the number of Farms in the list
    '
    Public ReadOnly Property FarmCount() As Integer
        Get
            Return mFarmList.Count
        End Get
    End Property
    '
    ' Rebuild the Farm List to match the Data Store
    '
    Private Sub RebuildFarmList()

        ' Clear the current Farm List
        mFarmList.Clear()
        SelectedFarm = Nothing

        ' Rebuild it from the Data Store
        Dim _farmObject As DataStore.ObjectNode = mMyStore.GetFirstObject

        While Not (_farmObject Is Nothing)
            Debug.Assert(_farmObject.MyID.StartsWith("Farm"))

            ' Re-create the Farm
            Dim _farm As Farm = New Farm(_farmObject, Me)

            ' Add it to the Farm List
            If Not (_farm Is Nothing) Then
                mFarmList.Add(_farm)
                SelectedFarm = _farm
                SelectedField = _farm.GetFirstField
            Else
                Debug.Assert(False, "Farm is Nothing")
            End If

            _farmObject = mMyStore.GetNextObject
        End While
    End Sub
    '
    ' Get a reference to a Farm
    '
    Private mFarmEnum As System.Collections.IEnumerator

    Public Function GetFirstFarm() As Farm
        If Not (mFarmList Is Nothing) Then
            ' Reset list enumerator to start of list
            mFarmEnum = mFarmList.GetEnumerator()
            Return GetNextFarm()
        End If

        ' Return Nothing if no list
        Return Nothing
    End Function

    Public Function GetNextFarm() As Farm
        ' Return next Farm in list
        If (mFarmEnum.MoveNext) Then
            Dim _farm As Farm = CType(mFarmEnum.Current, Farm)
            Return _farm
        End If

        ' Return Nothing if at end of list
        Return Nothing
    End Function
    '
    ' Get a reference to a Farm by ID
    '
    Public Function GetFarmByID(ByVal _farmID As String) As Farm
        ' Define the enumerator to scan the Farm List
        Dim _enum As System.Collections.IEnumerator = mFarmList.GetEnumerator

        ' Scan the Farm List looking for a Farm with this name
        While (_enum.MoveNext)
            Dim _farm As Farm = CType(_enum.Current, Farm)

            If (_farmID = _farm.MyID) Then
                Return _farm
            End If
        End While

        ' Didn't find it!
        Return Nothing
    End Function
    '
    ' Get a reference to a Farm by Name
    '
    Public Function GetFarmByName(ByVal _farmName As String) As Farm
        ' Define the enumerator to scan the Farm List
        Dim _enum As System.Collections.IEnumerator = mFarmList.GetEnumerator

        ' Scan the Farm List looking for a Farm with this name
        While (_enum.MoveNext)
            Dim _farm As Farm = CType(_enum.Current, Farm)

            If (_farmName = _farm.Name.Value) Then
                Return _farm
            End If
        End While

        ' Didn't find it!
        Return Nothing
    End Function

#End Region

#Region " Initialization "

    Private Sub InitializeWinSRFR()

        StatusMessage = "Initialization started"

        ' Set window size; Title bar adds 20 to height but is not included in Size
        Select Case WindowSize
            Case WindowSizes.S800x600
                Me.Size = New Size(800, 600 - 20)
            Case WindowSizes.S900x675
                Me.Size = New Size(900, 675 - 20)
            Case WindowSizes.S949x768
                Me.Size = New Size(949, 768 - 20)
            Case Else
                Me.Size = New Size(1024, 768 - 20)
        End Select

        '*****************************************************************************************************
        ' Initialize the color scheme (to support High Contrast mode)
        '
        If (SystemInformation.HighContrast) Then
            EventButton.BackColor = System.Drawing.SystemColors.Window
            DesignButton.BackColor = System.Drawing.SystemColors.Window
            OperationsButton.BackColor = System.Drawing.SystemColors.Window
            SimulationButton.BackColor = System.Drawing.SystemColors.Window

            EventButton.ForeColor = System.Drawing.SystemColors.WindowText
            DesignButton.ForeColor = System.Drawing.SystemColors.WindowText
            OperationsButton.ForeColor = System.Drawing.SystemColors.WindowText
            SimulationButton.ForeColor = System.Drawing.SystemColors.WindowText
        End If

        '*****************************************************************************************************
        ' Initialize the Help system
        '
        ' Dir() can cause an exception if looking at CD Drive with no CD
        '
        Try
            If (Dir(PdfFilePath) = String.Empty) Then
                Me.SeriousError("PDF Manual not found", PdfFilePath)
            End If
        Catch ex As Exception
            Me.SeriousError("PDF Manual not found", PdfFilePath)
        End Try

        HelpAndManual.PdfFilePath = PdfFilePath

        '*****************************************************************************************************
        ' Initialize the Data Store
        '
        If (mDataStore IsNot Nothing) Then

            ' Disable Undo/Redo & Events during initialization
            mDataStore.EnableUndoRedo = False
            mDataStore.EventsEnabled = False

            ' Create WinSRFR's root node in the Data Store
            mMyStore = mDataStore.AddRoot(MyID)

            If (mMyStore Is Nothing) Then
                CriticalError("AddRoot(MyID) failed", "WinSRFR:InitializeWinSRFR()")
            End If
        Else
            CriticalError("DataStore Is Nothing", "WinSRFR:InitializeWinSRFR()")
        End If
        '
        ' Add serializable data
        '
        Dim _parameter As Parameter = Nothing
        Dim _success As Integer = 0
        Dim _count As Integer = 0
        '
        ' Product information
        '
        _parameter = New StringParameter(Application.ProductName)
        _success += CInt(mMyStore.AddProperty(sProductName, _parameter))
        _count += 1

        _parameter = New StringParameter(Application.ProductVersion)
        _success += CInt(mMyStore.AddProperty(sProductVersion, _parameter))
        _count += 1
        '
        ' Farm List data
        '
        _parameter = New IntegerParameter(0)
        _success += CInt(mMyStore.AddProperty(sFarmSuffix, _parameter))
        _count += 1

        ' Verify this worked
        Debug.Assert(Not _parameter Is Nothing, "Parameter was not created")
        Debug.Assert(_success = -_count, "All Properties were not added")

        ' Enable MyStore events
        mMyStore.EventsEnabled = True

        UpdateTranslation(mUnitsDialogBox, Me.Language)

        '*****************************************************************************************************
        ' Initialize Units from User Preferences
        '
        LoadUserPreferences()
        mUnitsDialogBox.InitDialogBox()

        '*****************************************************************************************************
        ' Load the Examples File List
        '
        LoadExamplesFileList()

        '*****************************************************************************************************
        ' Load the Most Recently Used (MRU) Project List
        '
        LoadMruProjectList()

        '*****************************************************************************************************
        ' Initialize language translation; build the Native Language DataSet
        '
        LoadLanguagesList()
        '
        ' Build Native Language DataSet
        '
        mDictionary.DefineNativeControlSet(sNativeLanguage)
        BuildNativeLanguageDataSet()
        ' 
        ' Save Native Language text file
        '
        Dim allUsersPath As String = Application.CommonAppDataPath
        Dim lastBackslash As Integer = allUsersPath.LastIndexOf("\")
        Dim allUsersWinSrfrPath As String = allUsersPath.Substring(0, lastBackslash)
        Dim languagesPath As String = allUsersWinSrfrPath + "\Languages"

        Try ' Create Languages directory if it doesn't exist
            MkDir(languagesPath)
        Catch ex As Exception
        End Try

        mDictionary.SaveNativeLanguage(languagesPath, sNativeLanguage)
        '
        ' Open currently selected Language
        '
        OpenLanguage(Language)

        '*****************************************************************************************************
        ' Enable DataStore
        '
        mDataStore.EnableUndoRedo = True
        mDataStore.EventsEnabled = True

        '*****************************************************************************************************
        ' Initialize the UI
        '
        AnalysisDetails.Initialize(Me)
        AnalysisExplorer.Initialize(Me, AnalysisDetails)

        '*****************************************************************************************************
        ' Determine how WinSRFR was started:
        '
        '   1) Double-click of WinSRFR.exe  - start with last project or default Project
        '   2) Double-click of a .srfr file - open user selected .srfr file
        '
        Dim _command As String = Microsoft.VisualBasic.Command.Trim

        If Not (_command Is Nothing) Then

            If (_command.StartsWith("""")) Then
                ' Remove enclosing quotes ("...")
                _command = _command.Substring(1, _command.Length - 2)
            End If

            ' Should previous project be opened?
            If (_command = String.Empty) Then
                If (UserPreferences.OpenPreviousFile) Then
                    If Not (FilePath = String.Empty) Then
                        _command = FilePath
                    End If
                End If
            End If

            If (_command = String.Empty) Then
                ' Start with default Project
                If Not (NewProject(True)) Then
                    SeriousError("InitializeWinSRFR:NewProject()", "New Project was not created")
                End If
            Else
                ' Open user selected .wsrfr file
                Me.Show()
                Me.Refresh()
                OpenProject(_command)
            End If
        End If

        '*****************************************************************************************************
        ' Initialize the remote Command Interface
        '
        mCommandInterface = New CommandInterface(Me)
        'If Not (mCommandInterface Is Nothing) Then
        '    If Not (mCommandInterface.SetupRemoteChannel()) Then
        '        mCommandInterface = Nothing
        '    End If
        'End If

        '*****************************************************************************************************
        ' Instantiate API to SRFR
        '
        Try
            mSrfrAPI = New Srfr.SrfrAPI

            If (mSrfrAPI Is Nothing) Then
                CriticalError("InitializeWinSRFR[New Srfr.SrfrAPI]", "SrfrAPI Is Nothing")
            End If

        Catch ex As Exception
            CriticalException("InitializeWinSRFR[New Srfr.SrfrAPI]", ex)
        End Try

        Console.WriteLine("InitWinSRFR completed")

        '*****************************************************************************************************
        ' Initialize the clock timer
        '
        Me.UpdateTime()
        mTickTimer = New Timer(New TimerCallback(AddressOf Me.Tick), Nothing,
                               TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))

    End Sub

#End Region

#Region " Methods "

#Region " User Level "
    '
    ' User Level
    '
    Private mUserLevel As UserLevels = DefaultUserLevel
    Public Property UserLevel() As UserLevels
        Get
            If (mUserLevel = Globals.UserLevels.Research) Then
                ' Research Level is not stored in Registry
                Return mUserLevel
            Else
                ' Read Standard / Advanced Level from Registry
                Return ReadUserLevel()
            End If
        End Get
        Set(ByVal Value As UserLevels)
            ' Save new value only if it has changed
            If Not (UserLevel = Value) Then
                Select Case Value
                    Case Globals.UserLevels.Research
                        ' Research Level is not stored in Registry
                        mUserLevel = Globals.UserLevels.Research
                    Case Globals.UserLevels.Advanced
                        ' Save Advanced User Level setting in Registry
                        mUserLevel = Globals.UserLevels.Advanced
                        SaveUserLevel(mUserLevel)
                    Case Else ' Assume Globals.UserLevels.Standard
                        ' Save Standard User Level setting in Registry
                        mUserLevel = Globals.UserLevels.Standard
                        SaveUserLevel(mUserLevel)
                End Select

                UpdateUI()
                RaiseEvent WinSrfrUpdated(Reasons.UserLevel)
            End If
        End Set
    End Property
    '
    ' This is a 'fast' way to check if Research level is enabled since no Registry read is necessary
    '
    Public Function IsResearchLevel() As Boolean
        IsResearchLevel = False
        If (mUserLevel = Globals.UserLevels.Research) Then
            ' Research Level is not stored in Registry
            IsResearchLevel = True
        End If
    End Function
    '
    ' Read / Write User level from / to Registry
    '
    Private Function ReadUserLevel() As UserLevels

        Dim _userLevel As UserLevels = DefaultUserLevel

        ' Read the User Level in the Registry
        Try
            ' Open the Current User / Software keys
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Read User Level
                            Dim _integer As Integer = CInt(_regKey.GetValue(sUserLevel, DefaultUserLevel))
                            If ((UserLevels.LowLimit < _integer) And (_integer < UserLevels.Research)) Then
                                _userLevel = CType(_integer, UserLevels)
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors; use the default User Level
        End Try

        ' Registry should only contain Standard / Advanced User Levels
        If (_userLevel = Globals.UserLevels.Advanced) Then
            Return Globals.UserLevels.Advanced
        Else
            Return Globals.UserLevels.Standard
        End If

    End Function

    Private Sub SaveUserLevel(ByVal _userLevel As UserLevels)

        ' Save the User Level in the Registry
        Try
            ' Open the Current User / Software key
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Write User Level
                            Dim _integer As Integer = _userLevel
                            _regKey.SetValue(sUserLevel, _integer)

                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore errors
        End Try

    End Sub
    '
    ' User Level dependent values
    '
    Public Function Nmin() As Double            ' Manning n
        Nmin = 0.01
        If (IsResearchLevel()) Then
            Nmin = Srfr.Nmin
        End If
    End Function

    Public Function Nmax() As Double
        Nmax = 0.4
        If (IsResearchLevel()) Then
            Nmax = Srfr.Nmax
        End If
    End Function

    Public Function CnMin() As Double           ' Manning Cn
        CnMin = 0.01
        If (IsResearchLevel()) Then
            CnMin = Srfr.CnMin
        End If
    End Function

    Public Function CnMax() As Double
        CnMax = 0.4
        If (IsResearchLevel()) Then
            CnMax = Srfr.CnMax
        End If
    End Function

    Public Function AnMin() As Double           ' Manning An
        AnMin = -(1.0 / 6.0)
        If (IsResearchLevel()) Then
            AnMin = Srfr.AnMin
        End If
    End Function

    Public Function AnMax() As Double
        AnMax = 1.0 / 6.0
        If (IsResearchLevel()) Then
            AnMax = Srfr.AnMax
        End If
    End Function

    Public Function ChiMin() As Double          ' Sayre-Albertson Chi
        ChiMin = 0.001
        If (IsResearchLevel()) Then
            ChiMin = Srfr.ChiMin
        End If
    End Function

    Public Function ChiMax() As Double
        ChiMax = 0.02
        If (IsResearchLevel()) Then
            ChiMax = Srfr.ChiMax
        End If
    End Function

    Public Function MinimumKostiakovA() As Double
        MinimumKostiakovA = 0.1
        If (IsResearchLevel()) Then
            MinimumKostiakovA = Srfr.Amin
        End If
    End Function

#End Region

#Region " User Preferences "
    '
    ' Load Units System from User Preferences
    '
    Public Shared Sub LoadUserPreferences()

        If (mUserPreferences IsNot Nothing) Then
            If (mUnitsSystem IsNot Nothing) Then

                ' Set Units System to User Preference selections
                If (mUserPreferences.EnglishOptionsEnabled) Then
                    mUnitsSystem.UnitSystem = UnitsDefinition.UnitSystems.English
                Else
                    mUnitsSystem.UnitSystem = UnitsDefinition.UnitSystems.Metric
                End If

                mUnitsSystem.EnglishDepthUnits = mUserPreferences.DefaultEnglishWaterDepth
                mUnitsSystem.EnglishShapeUnits = mUserPreferences.DefaultEnglishFurrowShape
                mUnitsSystem.EnglishSlopeUnits = mUserPreferences.DefaultEnglishFieldSlope
                mUnitsSystem.EnglishFlowRateUnits = mUserPreferences.DefaultEnglishFlowRate

                mUnitsSystem.MetricDepthUnits = mUserPreferences.DefaultMetricWaterDepth
                mUnitsSystem.MetricShapeUnits = mUserPreferences.DefaultMetricFurrowShape
                mUnitsSystem.MetricSlopeUnits = mUserPreferences.DefaultMetricFieldSlope
                mUnitsSystem.MetricFlowRateUnits = mUserPreferences.DefaultMetricFlowRate

                mUnitsSystem.TimeUnits = mUserPreferences.DefaultTimeUnits
            End If
        End If

    End Sub

#End Region

#Region " File I/O Methods "

#Region " Open/Read File "
    '
    ' Check if Data Store data has changed since the last file operation
    '
    Public Function DataHasChanged() As Boolean
        Return mDataStore.DataHasChangedSince(True, FileTimestamp)
    End Function
    '
    ' Use the Open File Dialog to get a file name then open that file
    '
    Friend Function OpenProject(ByVal verify As Boolean) As Boolean

        ' First verify current project changes have been saved
        If (VerifySaved(verify)) Then

            ' Create OpenFileDialog to request a path and file name to open
            Dim _openFile As New OpenFileDialog

            ' Initialize OpenFileDialog to specify SRFR extensions
            If (FileName = String.Empty) Then
                _openFile.FileName = DefaultFileName
            Else
                _openFile.FileName = FileName
            End If

            _openFile.DefaultExt = "*.srfr"
            _openFile.Filter = Application.ProductName + " Files|*.srfr"

            ' Let user choose WinSRFR file to open
            Dim result As DialogResult = _openFile.ShowDialog()

            ' Determine if the user selected a file name from the OpenFileDialog
            If (result = System.Windows.Forms.DialogResult.OK) Then
                If (0 < _openFile.FileName.Length) Then

                    ' Close the current project
                    If (CloseProject(False)) Then
                        ' Then try to open the user selected file
                        OpenProject(_openFile.FileName)
                    End If

                    Return True
                End If
            End If
        End If

        Return False
    End Function
    '
    ' Attempt to open the requested file
    '
    Friend Sub OpenProject(ByVal _filePath As String)

        ' Verify a file path was specified & the file exists
        If (_filePath IsNot Nothing) Then
            If Not (_filePath = String.Empty) Then
                '
                ' Dir() can cause an exception if _filePath points to a CD Drive with no CD
                '
                Try
                    If Not (Dir(_filePath) = String.Empty) Then

                        ' Save file path
                        FilePath = _filePath

                        ' Change status & cursor display
                        StatusMessage = String.Format("Reading - '{0}'", FilePath)

                        mOldCursor = Me.Cursor
                        Me.Cursor = Cursors.WaitCursor

                        ' Load the DataStore from the file
                        DataStore.ClearErrors()

                        Try
                            ' Attempt to open the file
                            Dim _fs As System.IO.FileStream
                            _fs = New FileStream(FilePath, FileMode.Open)

                            Try
                                ' Read the file into the DataStore
                                mDataStore.ReadFromFile(_fs)

                                ' Update older version files to current
                                UpdateOlderVersionFiles()

                                ' Save the date/time the file was read
                                FileTimestamp = DateTime.Now

                                ' Clear all Undo/Redo lists
                                ClearAllUndoRedo()

                                ' Add this file to the Most Recently Used (MRU) file list
                                AddFileToMruProjectList(FilePath)

                            Catch ex As Exception
                                UsageError("Open Project", "Read From File", "Unrecognized file contents")
                            Finally
                                If (_fs IsNot Nothing) Then
                                    _fs.Close()
                                End If
                            End Try
                        Catch ex As Exception
                            UsageError("Open Project", "Open File", ex.Message _
                                        + ChrW(10) + ChrW(10) + "Is this file ReadOnly?")
                        End Try

                        If (0 = DataStore.ErrorCount) Then
                            StatusMessage = String.Format("Open successful - '{0}'", FileName)
                        Else
                            StatusMessage = String.Format("Open caused errors - '{0}'", FileName)

                            UsageError("Open Project", "Read From File",
                                "Errors occurred during file read." + Chr(13) + Chr(13) +
                                "Carefully check your data!")
                        End If

                        ' Update the user interface to relect change
                        UpdateUI()

                        Me.AnalysisExplorer.Focus()

                    Else
                        UsageError("Open Project", "File does not exist!", FilePath)
                    End If

                Catch ex As Exception
                    UsageError("Open Project", "File does not exist!", FilePath)
                Finally
                    Me.Cursor = mOldCursor
                End Try
            End If
        End If

    End Sub
    '
    ' Update necessary values found in older version files
    '
    Private Sub UpdateOlderVersionFiles()

        ' Update older version files to current
        Dim _majorVersion As String = MajorVersion()
        Dim _minorVersion As String = MinorVersion()
        Dim _betaVersion As String = BetaVersion()
        '
        ' Scan through all Farms / Fields / Worlds / Units udpating old data as appropriate
        '
        Dim _farm As Farm = Me.GetFirstFarm
        While Not (_farm Is Nothing)
            Dim _field As Field = _farm.GetFirstField
            While Not (_field Is Nothing)
                Dim _world As World = _field.GetFirstWorld
                While Not (_world Is Nothing)
                    Dim _unit As Unit = _world.GetFirstAnalysis
                    While Not (_unit Is Nothing)
                        ' Get references to Unit data objects
                        Dim _systemGeometry As SystemGeometry = _unit.SystemGeometryRef
                        Dim _soilCropProperties As SoilCropProperties = _unit.SoilCropPropertiesRef
                        Dim _performanceResults As PerformanceResults = _unit.PerformanceResultsRef
                        '
                        ' Version 1 & prior versions used Inflow Rate as 'per furrow'
                        ' Versions 2+ uses Inflow Rate as 'per furrow set'
                        '
                        If (_majorVersion < "2") Then
                            If (_unit.CrossSection = CrossSections.Furrow) Then
                                ' Set Width to Furrow Spacing resulting in 1 furrow per furrow set
                                Dim _widthProperty As PropertyNode = _systemGeometry.WidthProperty
                                Dim _width As DoubleParameter = DirectCast(_widthProperty.GetParameter, DoubleParameter)
                                _width.Value = _systemGeometry.FurrowSpacing.Value
                            End If
                        End If
                        '
                        ' Furrow Spacing, Furrows Per Set & Furrow Set Width may be out-of-sync
                        '
                        If (("1" < _majorVersion) And (_majorVersion < "4")) Then
                            If (_unit.CrossSection = CrossSections.Furrow) Then
                                ' Set Width to Furrow Spacing * Furrows Per Set
                                Dim _furrowSpacing As Double = _systemGeometry.FurrowSpacing.Value
                                Dim _furrowsPerSet As Double = _systemGeometry.FurrowsPerSet.Value

                                Dim _widthProperty As PropertyNode = _systemGeometry.WidthProperty
                                Dim _width As DoubleParameter = DirectCast(_widthProperty.GetParameter, DoubleParameter)
                                _width.Value = _furrowSpacing * _furrowsPerSet
                            End If
                        End If
                        '
                        ' Version 4x added "cm/hr", "m/hr" & "ft/hr" as new velocity units in the Units Enum in WinLib's
                        ' UnitsDefinition module.  This pushed all following units up by three.  To compensate, all contours
                        ' that have units after the velocity units that are stored in older version files must be adjusted.
                        '
                        If (_majorVersion < "4") Then
                            If (_performanceResults IsNot Nothing) Then
                                Dim _contourProperty As PropertyNode = _performanceResults.DesignContourProperty
                                Dim _contourParameter As ContourParameter = DirectCast(_contourProperty.GetParameter, ContourParameter)

                                Dim _grid As ContourGrid = _contourParameter.Value
                                If (_grid IsNot Nothing) Then

                                    For Each obj As Object In _grid.MajorContours
                                        If (obj.GetType Is GetType(ContourPolygons)) Then
                                            Dim polygons As ContourPolygons = DirectCast(obj, ContourPolygons)
                                            Dim paramName As String = polygons.Name
                                            Dim paramSymbol As String = polygons.Symbol

                                            If ((paramSymbol.StartsWith("AE")) Or (paramSymbol.StartsWith("PAE"))) Then
                                                polygons.Units = Units.Percentage
                                            End If

                                            If (paramSymbol.StartsWith("RO")) Then
                                                polygons.Units = Units.Percentage
                                            End If

                                            If (paramSymbol.StartsWith("DP")) Then
                                                polygons.Units = Units.Percentage
                                            End If

                                            If (paramSymbol.StartsWith("DU")) Then
                                                polygons.Units = Units.Fraction
                                            End If

                                            If (paramSymbol.StartsWith("Cost")) Then
                                                polygons.Units = Units.DollarsPerHectare
                                            End If
                                        End If
                                    Next obj

                                End If
                            End If
                        End If
                        '
                        ' Update data names to reflect new values
                        '
                        Dim _idp As PropertyNode = _soilCropProperties.InfiltratedDepthProperty
                        Dim _dataTable As DataTableParameter = DirectCast(_idp.GetParameter, DataTableParameter)
                        For Each _col As DataColumn In _dataTable.Value.Columns
                            Const sProbeDepthX As String = "Probe Depth (m)"
                            If (_col.ColumnName = sProbeDepthX) Then
                                _col.ColumnName = sProbedDepthX ' "Probe Depth" -> "Probed Depth"
                            End If
                        Next

                        Dim _swp As PropertyNode = _soilCropProperties.SoilWaterDepletionProperty
                        _dataTable = DirectCast(_swp.GetParameter, DataTableParameter)
                        For Each _col As DataColumn In _dataTable.Value.Columns
                            Const sCumDepthX As String = "Cum. Depth (m)"
                            If (_col.ColumnName = sCumDepthX) Then
                                _col.ColumnName = sCumulativeDepthX ' "Cum. Depth" -> "Cum. Pr. Depth"
                            End If

                            Const sCumSwdX As String = "Cum. SWD (mm)"
                            If (_col.ColumnName = sCumSwdX) Then
                                _col.ColumnName = sCumulativeSwdX ' "Cum. SWD" -> "Cum. Pr. SWD"
                            End If
                        Next

                        _unit = _world.GetNextAnalysis
                    End While
                    _world = _field.GetNextWorld
                End While
                _field = _farm.GetNextField
            End While
            _farm = Me.GetNextFarm
        End While
        '
        ' Version 4x added "cm/hr", "m/hr" & "ft/hr" as new velocity units in the Units Enum in WinLib's
        ' UnitsDefinition module.  This pushed all following units up by three.  To compensate, all user
        ' selectable units after the velocity units that are stored in older version files must be adjusted.
        '
        Dim unitsSys As ObjectNode = mDataStore.GetRoot(DataStore.UnitsSystem.MyID)

        If (_majorVersion < "4") Then
            ' Only Flow Rate units are user selectable and follow CentimetersPerHour
            Dim flowRateUnits As IntegerParameter

            flowRateUnits = unitsSys.GetParameter(DataStore.UnitsSystem.sMetricFlowRateUnits)
            If ((flowRateUnits.Value < Units.FlowRateMetricLow) Or (Units.FlowRateMetricHigh < flowRateUnits.Value)) Then
                flowRateUnits.Value = mUserPreferences.DefaultMetricFlowRate
            End If

            flowRateUnits = unitsSys.GetParameter(DataStore.UnitsSystem.sEnglishFlowRateUnits)
            If ((flowRateUnits.Value < Units.FlowRateEnglishLow) Or (Units.FlowRateEnglishHigh < flowRateUnits.Value)) Then
                flowRateUnits.Value = mUserPreferences.DefaultEnglishFlowRate
            End If
        End If
        '
        ' Version 4x added Alternate Unit Sets that combine non-standard units together as a set.  Furrow
        ' Shape Unit Set is an example ('m', 'cm', 'mm').  These DataStore properties need to be added to
        ' earlier versions.
        '
        Dim unitSel As IntegerParameter = unitsSys.GetIntegerParameter(DataStore.UnitsSystem.sMetricDepthUnits)
        If (unitSel Is Nothing) Then
            mUnitsSystem.EnglishDepthUnits = mUserPreferences.DefaultEnglishWaterDepth
            mUnitsSystem.MetricDepthUnits = mUserPreferences.DefaultMetricWaterDepth
        End If

        unitSel = unitsSys.GetIntegerParameter(DataStore.UnitsSystem.sMetricShapeUnits)
        If (unitSel Is Nothing) Then
            mUnitsSystem.EnglishShapeUnits = mUserPreferences.DefaultEnglishFurrowShape
            mUnitsSystem.MetricShapeUnits = mUserPreferences.DefaultMetricFurrowShape
        End If

    End Sub

#End Region

#Region " Save/Close File "
    '
    ' Verify the file contains up to date data
    '
    Friend Function VerifySaved(ByVal verify As Boolean) As Boolean

        If (verify) Then
            ' If there is no Farm, there is nothing to save
            If (0 < mFarmList.Count) Then

                ' If the data in the Data Store has changed, ask if it should be saved
                If (DataHasChanged()) Then

                    ' Ask user if they want to save the currently unsaved data
                    ' Confirm delete
                    Dim _msg As String = mDictionary.tDoYouWantToSaveChangesToCurrentProject.Translated
                    Dim _title As String = mDictionary.tSaveProjectConfirmation.Translated
                    Dim _style As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel

                    ' Display message box
                    Dim _response As MsgBoxResult = MsgBox(_msg, _style, _title)

                    If (_response = MsgBoxResult.Yes) Then
                        ' User wants to save changes
                        If (FileName = String.Empty) Then
                            ' If no current file name, prompt for one
                            Return SaveAs()
                        Else
                            ' If current file name, use it
                            Return Save()
                        End If

                    ElseIf (_response = MsgBoxResult.No) Then
                        ' User does not want to save changes
                        Return True
                    Else
                        ' Must be Cancel
                        Return False
                    End If
                End If
            End If
        End If

        Return True

    End Function
    '
    ' Save the project using the filename provided by the user via the SaveFileDialog
    '
    Friend Function SaveAs() As Boolean

        ' Create a SaveFileDialog to request a path and file name to save to
        Dim _saveFile As New SaveFileDialog

        ' Initialize the SaveFileDialog to specify the SRFR extensions for the file
        If (FileName = String.Empty) Then
            _saveFile.FileName = DefaultFileName
        Else
            _saveFile.FileName = FilePath
        End If

        _saveFile.DefaultExt = "*.srfr"
        _saveFile.Filter = Application.ProductName + " Files|*.srfr"

        ' Determine if the user selected a file name from the OpenFileDialog
        If (_saveFile.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
            And (_saveFile.FileName.Length) > 0 Then

            Return SaveProject(_saveFile.FileName)
        End If

        Return False

    End Function
    '
    ' Save the project using the current filename
    '
    Friend Function Save() As Boolean
        Return SaveProject(FilePath)
    End Function
    '
    ' Save the project using the specified filename
    '
    Friend Function SaveProject(ByVal _filePath As String) As Boolean

        If Not (_filePath Is Nothing) Then
            If (_filePath = String.Empty) Then

                ' No file name has been specified; bring up Save Project Dialog
                Return SaveAs()
            Else

                ' Can't save to ReadOnly files
                Try
                    If Not (Dir(_filePath) = String.Empty) Then
                        ' File exists
                        If ((GetAttr(_filePath) And vbReadOnly) = vbReadOnly) Then
                            ' File exists and is ReadOnly; it can't be written to
                            MsgBox(_filePath, MsgBoxStyle.OkOnly, mDictionary.tSaveError.Translated & " - " & mDictionary.tFileIsReadOnly.Translated)
                            Return False
                        End If
                    End If
                Catch ex As Exception
                    ' File exists but can't be written to
                    MsgBox(_filePath, MsgBoxStyle.OkOnly, mDictionary.tSaveError.Translated & " - " & mDictionary.tFileCannotBeWritten.Translated)
                    Return False
                End Try

                ' Save file name as the Last File Name
                FilePath = _filePath

                ' Save original file, if one exists, as backup
                Dim dotPos As Integer = FilePath.LastIndexOf(".")
                Dim orgName As String = FilePath
                If (-1 < dotPos) Then
                    orgName = FilePath.Substring(0, dotPos)
                End If

                ' Delete old backup file
                Dim backupPath As String = orgName & ".sfbk"
                Try
                    Kill(backupPath)
                Catch ex As Exception
                End Try

                ' Rename original file as backup file
                Try
                    Rename(FilePath, backupPath)
                Catch ex As Exception
                End Try

                ' Save the file
                StatusMessage = String.Format(mDictionary.tSaving.Translated & " '{0}'", FileName)

                mOldCursor = Me.Cursor
                Me.Cursor = Cursors.WaitCursor

                Dim _fs As System.IO.FileStream = Nothing
                Try
                    _fs = New FileStream(FilePath, FileMode.Create)
                    mDataStore.WriteToFile(_fs)

                    ' Save the date/time the file was saved
                    FileTimestamp = DateTime.Now

                    AddFileToMruProjectList(FilePath)

                    StatusMessage = String.Format(mDictionary.tSaveComplete.Translated & ":  '{0}'", FileName)

                Catch ex As Exception
                    StatusMessage = String.Format(mDictionary.tSaveFailed.Translated & ":  '{0}' failed!", FileName)

                    Dim _title As String = mDictionary.tSaveFailed.Translated
                    Dim _style As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly
                    Dim _msg As String = mDictionary.tErrMessage.Translated & ": " & ex.Message & Chr(13) & Chr(13)
                    _msg &= mDictionary.tVerifyFileIsCorrect.Translated & ": " & FileName & Chr(13) & Chr(13)
                    _msg &= mDictionary.tBackupIsLocatedHere.Translated & ":  " & backupPath
                    MsgBox(_msg, _style, _title)

                Finally
                    If Not (_fs Is Nothing) Then
                        _fs.Close()
                    End If
                End Try

                Me.Cursor = mOldCursor

                ' Update the user interface to relect change
                UpdateUI()

                Return True

            End If
        End If

        Return False

    End Function
    '
    ' Close the current WinSRFR Project
    '
    ' If requested, checked if any unsaved data should be saved first
    '
    Friend Function CloseProject(ByVal verify As Boolean) As Boolean

        ' If requested, verify if any unsaved data should be saved before continuing
        If (VerifySaved(verify)) Then

            ' Remove the Farm(s)
SellTheFarm:
            Dim _farm As Farm = GetFirstFarm()
            While Not (_farm Is Nothing)
                DeleteFarm(_farm)
                GoTo SellTheFarm
            End While

            SelectedFarm = Nothing
            SelectedField = Nothing
            SelectedWorld = Nothing
            SelectedAnalysis = Nothing

            ' Clear the FilePath
            FilePath = String.Empty

            ' Clear the DataStore's Undo/Redo stack
            mDataStore.ClearUndoRedo()

            ' Save the date/time the project was closed
            FileTimestamp = DateTime.Now

            UpdateUI()

            mEvaluationWorld.ClearSrfrResults()
            mSimulationWorld.ClearSrfrResults()
            mOperationsWorld.ClearSrfrResults()
            mDesignWorld.ClearSrfrResults()

            Return True
        End If

        Return False

    End Function
    '
    ' Make sure the project exits cleanly
    '
    Friend Function ExitProgram(ByVal verify As Boolean) As Boolean

        ' Get focus to complete pending data input (via LostFocus event)
        Me.Focus()

        ' Properly close the project 
        If (CloseProject(verify)) Then

            ' Stop the Timer
            mTickTimer.Dispose()

            ' Terminate the debug output
            Debug.WriteLine("WinSRFR exiting")
            Debug.Flush()

            ' Exit the program
            Try
                Application.Exit()
            Catch ex As Exception
            End Try
        End If

        ' User canceled the Exit Program request
        Return False

    End Function

#End Region

#End Region

#Region " Examples File List "

    Private Sub LoadExamplesFileList()

        Dim examplesDirectory As String = Application.CommonAppDataPath & "\Examples"
        If Not (Directory.Exists(examplesDirectory)) Then
            examplesDirectory = WinSrfrDirectory & "\Examples"
        End If

        If (mExamplesFileList Is Nothing) Then
            mExamplesFileList = New ArrayList
        Else
            mExamplesFileList.Clear()
        End If

        If (Directory.Exists(examplesDirectory)) Then
            ' Create a reference to the Examples directory.
            Dim di As New DirectoryInfo(examplesDirectory)
            ' Create an array representing the files in the current directory.
            Dim fi As FileInfo() = di.GetFiles()
            ' Save the names of the files in the Examples directory.
            Dim fiTemp As FileInfo
            For Each fiTemp In fi
                If (fiTemp.Extension = ".srfr") Then
                    mExamplesFileList.Add(fiTemp.Name)
                End If
            Next fiTemp
        End If

    End Sub

#End Region

#Region " MRU Project List "
    '
    ' Add a file to the MRU list
    '
    Private Sub AddFileToMruProjectList(ByVal _mruFile As String)

        ' If file is already in the list; remove it
        For Each _file As String In mMruProjectList
            If (_mruFile = _file) Then
                mMruProjectList.Remove(_file)
                Exit For
            End If
        Next

        ' Add this new file to the head of the list
        mMruProjectList.Insert(0, _mruFile)

        ' Save the new list to the Registry
        SaveMruProjectList()

    End Sub
    '
    ' Load the MRU list from the Registry
    '
    Private Sub LoadMruProjectList()

        ' Clear the current MRU list
        mMruProjectList.Clear()

        ' Fill it with the list in the Registry
        Try
            ' Open the Current User / Software key
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Open MRU's key
                            _regKey = _regKey.CreateSubKey("MRU")

                            If Not (_regKey Is Nothing) Then

                                ' Read the MRU List
                                For _idx As Integer = 1 To mMaxMruFiles

                                    ' Get next file path
                                    Dim _mruFile As String = CStr(_regKey.GetValue(_idx.ToString, String.Empty))

                                    ' If file still exists, add it to the list
                                    If Not (_mruFile = String.Empty) Then
                                        If File.Exists(_mruFile) Then
                                            If Not (mMruProjectList.Contains(_mruFile)) Then
                                                mMruProjectList.Add(_mruFile)

                                                ' If requested, save previously opened file path
                                                If (UserPreferences.OpenPreviousFile) Then
                                                    If (FilePath = String.Empty) Then
                                                        FilePath = _mruFile
                                                    End If
                                                End If
                                            Else ' File already in list; delete it from the MRU list
                                                _regKey.DeleteValue(_idx.ToString)
                                            End If
                                        Else ' File doesn't exist; delete it from the MRU list
                                            _regKey.DeleteValue(_idx.ToString)
                                        End If
                                    End If
                                Next

                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore any errors; proceed without the MRU list
        End Try

    End Sub
    '
    ' Save the MRU list to the Registry
    '
    Private Sub SaveMruProjectList()

        ' Save the list in the Registry
        Try
            ' Open the Current User / Software key
            Dim _regKey As RegistryKey = Registry.CurrentUser
            If Not (_regKey Is Nothing) Then
                _regKey = _regKey.OpenSubKey("Software", True)
                If Not (_regKey Is Nothing) Then

                    ' Open the Company / Product keys
                    _regKey = _regKey.CreateSubKey(Application.CompanyName)
                    If Not (_regKey Is Nothing) Then
                        _regKey = _regKey.CreateSubKey(Application.ProductName)
                        If Not (_regKey Is Nothing) Then

                            ' Open MRU's key
                            _regKey = _regKey.CreateSubKey("MRU")

                            If Not (_regKey Is Nothing) Then

                                ' Write the MRU List (max of mMaxMruFiles entries)
                                Dim _idx As Integer = 1
                                For Each _mruFile As String In mMruProjectList

                                    _regKey.SetValue(_idx.ToString, _mruFile)
                                    _idx += 1

                                    If (mMaxMruFiles < _idx) Then
                                        Exit For
                                    End If

                                Next

                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' Ignore any errors; proceed without the MRU list
        End Try

    End Sub

#End Region

#Region " Languages List "

    Private Sub LoadLanguagesList()
        Dim languagesPath As String

        If (mLanguagesList Is Nothing) Then
            mLanguagesList = New ArrayList
        Else
            mLanguagesList.Clear()
        End If

        Dim allUsersPath As String = Application.CommonAppDataPath
        Dim lastBackslash As Integer = allUsersPath.LastIndexOf("\")
        Dim allUsersWinSrfrPath As String = allUsersPath.Substring(0, lastBackslash)
        languagesPath = allUsersWinSrfrPath & "\Languages"
        LoadLanguagesList(languagesPath, mLanguagesList)

    End Sub

    Private Sub LoadLanguagesList(ByVal LanguagesPath As String, ByVal LanguagesList As ArrayList)

        If (Directory.Exists(LanguagesPath)) Then
            ' Create a reference to the Languages directory.
            Dim di As New DirectoryInfo(LanguagesPath)
            ' Create an array representing the files in the current directory.
            Dim fi As FileInfo() = di.GetFiles()
            ' Save the names of the files in the Languages directory.
            Dim fiTemp As FileInfo
            For Each fiTemp In fi
                If ((fiTemp.Extension = ".bin") _
                 Or (fiTemp.Extension = ".txt")) Then
                    Dim language As String = fiTemp.Name
                    Dim lastDot As Integer = language.LastIndexOf(".")
                    If (0 < lastDot) Then
                        language = language.Substring(0, lastDot)
                    End If
                    If Not (LanguagesList.Contains(language)) Then
                        LanguagesList.Add(language)
                    End If
                End If
            Next fiTemp
        End If

    End Sub

#End Region

#Region " Native Language DataSet "
    '
    ' Add Control & Dialog native language string to Language DataSet
    '
    Public Sub BuildNativeLanguageDataSet()
        '*****************************************************************************************************
        ' Forms & their Controls
        '*****************************************************************************************************
        Dim ctrl As Control
        '
        ' Main WinSRFR Window
        '
        mDictionary.AddNativeControlTable(Me)
        '
        ' Worlds' baseclass
        '
        ctrl = New WorldWindow
        ctrl.Name = "WorldWindow"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing
        '
        ' Simulation World / Execution
        '
        ctrl = New SimulationWorld                      ' Simulation World Window
        ctrl.Name = "SimulationWorld"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_SimulationWorld                  ' Simulation World Tab
        ctrl.Name = "SimulationWorldControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_SimulationExecution              ' Simulation Execution Tab
        ctrl.Name = "SimulationExecutionControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_SystemGeometry                   ' System Geometry
        ctrl.Name = "SystemGeometryControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_SoilCropProperties               ' Soil Crop Properties
        ctrl.Name = "SoilCropPropertiesControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_InflowManagement                 ' Inflow Management
        ctrl.Name = "InflowManagementControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        'ctrl = New ctl_DataSummary                      ' Data Summary
        'ctrl.Name = "DataSummaryControl"
        'mDictionary.AddNativeControlTable(ctrl)
        'ctrl.Dispose()
        'ctrl = Nothing

        ctrl = New ctl_Erosion                          ' Erosion Data
        ctrl.Name = "ErosionControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_Fertigation                      ' Fertigation Data
        ctrl.Name = "FertigationControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing
        '
        ' Design World / Execution
        '
        ctrl = New DesignWorld                          ' Design World Window
        ctrl.Name = "DesignWorld"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_DesignWorld                      ' Design World Tab
        ctrl.Name = "DesignWorldControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_DesignExecution                  ' Design Execution Tab
        ctrl.Name = "DesignExecutionControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing
        '
        ' Operations World / Execution
        '
        ctrl = New OperationsWorld                      ' Operations World Window
        ctrl.Name = "OperationsWorld"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_OperationsWorld                  ' Operations World Tab
        ctrl.Name = "OperationsWorldControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_OperationsExecution              ' Operations Execution Tab
        ctrl.Name = "OperationsExecutionControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing
        '
        ' Evaluation World / Data / Execution
        '
        ctrl = New EvaluationWorld                      ' Evaluation World Window
        ctrl.Name = "EvaluationWorld"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_EvaluationWorld                  ' Evaluation World Tab
        ctrl.Name = "EvaluationWorldControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_EvaluationExecution              ' Evaluation Execution Tab
        ctrl.Name = "EvaluationExecutionControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ' Data Tabs
        ctrl = New ctl_InflowRunoff                     ' Inflow Runoff
        ctrl.Name = "InflowRunoffControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_InfiltratedProfile               ' Infiltrated Profile Data
        ctrl.Name = "InfiltratedProfileControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_AdvanceRecession                 ' Advance / Recession Data
        ctrl.Name = "AdvanceRecessionControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_FlowDepths                       ' Flow Depths
        ctrl.Name = "FlowDepthsControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ' Analysis Tabs
        ctrl = New ctl_VolumeBalances                   ' Volume Balances
        ctrl.Name = "VolumeBalances Control"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_EvaluationInfiltration           ' Evaluation Infiltration Tab
        ctrl.Name = "EvaluationInfiltrationControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_EvalueRoughness                  ' EVALUE Roughness
        ctrl.Name = "EvalueRoughnessControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_SurfaceVolumeEstimated           ' Surface Volume (Estimated)
        ctrl.Name = "SurfaceVolumeEstimatedControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        ctrl = New ctl_SurfaceVolumeMeasured            ' Surface Volume (Measured)
        ctrl.Name = "SurfaceVolumeMeasuredControl"
        mDictionary.AddNativeControlTable(ctrl)
        ctrl.Dispose()
        ctrl = Nothing

        '**************************************************************************************
        ' Dialog Boxes
        '**************************************************************************************
        Dim dialog As System.Windows.Forms.Form

        dialog = New AnimationViewer
        dialog.Name = "AnimationViewer"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New BorderContourOverlay(Nothing)
        dialog.Name = "BorderContourOverlay"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New ConversionChart
        dialog.Name = "ConversionChart"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New DataComparer(Me)
        dialog.Name = "DataComparer"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New FertigationOptions
        dialog.Name = "FertigationOptions"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New FurrowFieldData(Nothing)
        dialog.Name = "FurrowFieldData"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New InfiltrationFunctionEditor(InfiltrationFunctionEditor.MatchTypes.MatchDepths)
        dialog.Name = "InfiltrationFunctionEditor"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New NrcsIntakeFamilyOptions(Nothing)
        dialog.Name = "NrcsIntakeFamilyOptions"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New RoughnessGoodnessOfFit(Nothing)
        dialog.Name = "RoughnessGoodnessOfFit"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New RunMultiSimulations
        dialog.Name = "RunMultiSimulations"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New SandSiltClayTable(Nothing)
        dialog.Name = "SandSiltClayTable"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New SimCellDensityDialogBox(Nothing)
        dialog.Name = "SimCellDensityDialogBox"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New SimControlsDialogBox
        dialog.Name = "SimControlsDialogBox"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New SimGraphicsDialogBox(Nothing, UserLevels.Advanced)
        dialog.Name = "SimGraphicsDialogBox"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New UnitsDialogBox
        dialog.Name = "UnitsDialogBox"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        ' User Preference is already instantiated
        mDictionary.AddNativeControlTable(mUserPreferences)

        dialog = New VaryWithDialogBox(Nothing, VaryByLocTime.Variations.NoVariation)
        dialog.Name = "VaryWithDialogBox"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

        dialog = New WaterDistributionDiagram(Nothing, 0.0, 0.0)
        dialog.Name = "WaterDistributionDiagram"
        mDictionary.AddNativeControlTable(dialog)
        dialog.Dispose()
        dialog = Nothing

    End Sub

#End Region

#Region " New / Add Object Methods "
    '
    ' New Project/Farm method
    '
    ' Note - the default Project consists of a Farm, one Field, and a World Folder for
    '        each World type.
    '
    Public Function NewProject(ByVal verify As Boolean) As Boolean

        ' Make sure any changes have been saved if wanted
        If (VerifySaved(verify)) Then

            ' Sell the old Farm
            DeleteFarm(SelectedFarm)

            ' Reset Farm Suffix
            Dim _integer As DataStore.IntegerParameter = FarmSuffix
            _integer.Value = 0
            _integer.Source = DataStore.Globals.ValueSources.Calculated
            FarmSuffix = _integer

            ' Clear the Undo / Redo list (to complete the Delete Farm)
            mDataStore.ClearUndoRedo()

            ' Clear the FilePath
            FilePath = String.Empty

            ' Buy a new Farm
            SelectedFarm = AddFarm()

            ' Add a Field
            SelectedField = AddField(SelectedFarm)

            ' Add a World Folder for each World type
            SelectedWorld = AddWorld(SelectedField, Globals.WorldTypes.EventWorld)
            SelectedWorld = AddWorld(SelectedField, Globals.WorldTypes.DesignWorld)
            SelectedWorld = AddWorld(SelectedField, Globals.WorldTypes.OperationsWorld)
            SelectedWorld = AddWorld(SelectedField, Globals.WorldTypes.SimulationWorld)

            ' Select the Farm in the Analysis Explorer
            AnalysisExplorer.SelectFarm(SelectedFarm)

            ' Clear the Undo / Redo list (to erase changes made while creating the new farm)
            mDataStore.ClearUndoRedo()

            ' Save the date/time this project was created
            FileTimestamp = DateTime.Now

            ' Let the user know what happened
            StatusMessage = mDictionary.tNewProjectCreated.Translated

            UpdateUI()

            Return True

        End If

        Return False

    End Function
    '
    ' Add Field
    '
    Public Function AddField(ByVal _farm As Farm) As Field

        If Not (_farm Is Nothing) Then

            mDataStore.MarkForUndo(mDictionary.tAdd.Translated & " " & CaseFieldText)

            Dim _field As Field = _farm.AddField()

            ' Start with default Field Name
            For _sfx As Integer = 1 To _farm.FieldCount + 1

                Dim _fieldName As String = CaseFieldText & " " + _sfx.ToString

                If (_farm.GetFieldByName(_fieldName) Is Nothing) Then
                    ' This is a unique Field Name
                    Dim _name As StringParameter = _field.Name
                    _name.Value = _fieldName
                    _name.Source = DataStore.Globals.ValueSources.Calculated
                    _field.Name = _name

                    AnalysisExplorer.AddField(_field)

                    StatusMessage = mDictionary.tNewCaseFieldAdded.Translated

                    Return _field
                End If
            Next
        Else
            Debug.Assert(False) ' Farm is Nothing
        End If

        Return Nothing

    End Function
    '
    ' Add World
    '
    Public Function AddWorld(ByVal _field As Field, ByVal _worldType As WorldTypes) As World

        If (_field IsNot Nothing) Then

            mDataStore.MarkForUndo(mDictionary.tAdd.Translated & " " & WorldsText(_worldType) + " Folder")

            Dim _world As World = _field.AddWorld()

            ' Set its World Type
            Dim _type As IntegerParameter = _world.WorldType
            _type.Value = _worldType
            _type.Source = DataStore.Globals.ValueSources.Calculated
            _world.WorldType = _type

            ' Start with default World Name
            For _sfx As Integer = 1 To _field.WorldCount + 1

                Dim _worldName As String = mDictionary.tFolder.Translated & " " & _sfx.ToString

                If (_field.GetWorldByName(_worldType, _worldName) Is Nothing) Then
                    ' This is a unique World Name
                    Dim _name As StringParameter = _world.Name
                    _name.Value = _worldName
                    _name.Source = DataStore.Globals.ValueSources.Calculated
                    _world.Name = _name

                    AnalysisExplorer.AddWorld(_world)

                    StatusMessage = mDictionary.tNewFolderAdded.Translated

                    Return _world
                End If
            Next
        Else
            Debug.Assert(False) ' Field is Nothing
        End If

        Return Nothing

    End Function
    '
    ' Add Analysis / Simulation
    '
    Public Function AddAnalysis(ByVal _world As World) As Unit

        If (_world IsNot Nothing) Then

            Dim _worldType As WorldTypes = CType(_world.WorldType.Value, WorldTypes)

            mDataStore.MarkForUndo(mDictionary.tAdd.Translated & " " & AnalysesText(_worldType))

            Dim _analysis As Unit = _world.AddAnalysis()

            ' Start with default Analysis Name
            For _sfx As Integer = 1 To _world.AnalysisCount + 1

                Dim _analysisName As String = AnalysesText(_worldType) + " " + _sfx.ToString

                If (_world.GetAnalysisByName(_analysisName) Is Nothing) Then
                    ' This is a unique Analysis Name
                    Dim _name As StringParameter = _analysis.Name
                    _name.Value = _analysisName
                    _name.Source = DataStore.Globals.ValueSources.Calculated
                    _analysis.Name = _name

                    ' Start the Analysis' Data History
                    Dim _datetime As String = System.DateTime.Now.ToLongDateString _
                                            + " at " _
                                            + System.DateTime.Now.ToLongTimeString

                    Dim _dataHistory As ArrayListParameter = _analysis.DataHistory
                    If (_dataHistory IsNot Nothing) Then
                        _dataHistory.Source = DataStore.Globals.ValueSources.Calculated
                        _dataHistory.Array.Insert(0, " ")
                        _dataHistory.Array.Insert(0, "     In " + WorldsText(_world.WorldType.Value) + " Folder:  " + _world.Name.Value)
                        _dataHistory.Array.Insert(0, "     As:  " + _analysis.Name.Value)
                        _dataHistory.Array.Insert(0, "Created by " & _analysis.UnitControlRef.ProductVersion.Value & " - " + _datetime)
                        _analysis.DataHistory = _dataHistory
                    End If

                    ' Update the Analysis Explorer with this Analysis
                    AnalysisExplorer.AddAnalysis(_analysis)

                    ' Update the user's status message
                    StatusMessage = mDictionary.tNewAnalysisAdded.Translated

                    Return _analysis
                End If
            Next
        Else
            Debug.Assert(False) ' World is Nothing
        End If

        Return Nothing

    End Function

#End Region

#Region " Undo / Redo Methods "
    '
    ' Undo / Redo
    '
    Private Sub Undo()

        Try
            If (mDataStore.CanUndo()) Then
                Me.Focus()
                mDataStore.Undo()
                Me.BringToFront()

                UpdateUI()
            End If
        Catch ex As Exception
            Dim _msg As String = "An unexpected error occurred during Redo"
            SeriousException(_msg, ex)
        End Try

    End Sub

    Private Sub Redo()

        Try
            If (mDataStore.CanRedo()) Then
                Me.Focus()
                mDataStore.Redo()
                Me.BringToFront()

                UpdateUI()
            End If
        Catch ex As Exception
            Dim _msg As String = "An unexpected error occurred during Redo"
            SeriousException(_msg, ex)
        End Try

    End Sub

    Private Sub ClearAllUndoRedo()

        ' Clear the top-level Undo/Redo list
        mDataStore.ClearUndoRedo()

        ' Scan DataStore for all analyses
        Dim _farm As Farm = GetFirstFarm()
        While Not (_farm Is Nothing)
            Dim _field As Field = _farm.GetFirstField
            While Not (_field Is Nothing)
                Dim _world As World = _field.GetFirstWorld
                While Not (_world Is Nothing)
                    Dim _analysis As Unit = _world.GetFirstAnalysis
                    While Not (_analysis Is Nothing)
                        ' Clear each Analysis' Undo/Redo list
                        _analysis.MyStore.ClearUndoRedo()
                        _analysis = _world.GetNextAnalysis
                    End While
                    _world = _field.GetNextWorld
                End While
                _field = _farm.GetNextField
            End While
            _farm = GetNextFarm()
        End While

    End Sub

#End Region

#Region " Clipboard Methods "
    '
    ' Clipboard Data Formats
    '
    Private mFarmFormat As DataFormats.Format = DataFormats.GetFormat("WinSrfrFarm")
    Private mFieldFormat As DataFormats.Format = DataFormats.GetFormat("WinSrfrField")
    Private mWorldFormat As DataFormats.Format = DataFormats.GetFormat("WinSrfrWorld")
    Private mAnalysisFormat As DataFormats.Format = DataFormats.GetFormat("WinSrfrAnalysis")
    '
    ' Cut / Copy / Paste a Farm
    '
    Public Sub CutFarm(ByVal _farm As Farm)
        If (_farm IsNot Nothing) Then
            ' Mark the current Data Store state as an Undo point
            mDataStore.MarkForUndo(mDictionary.tRemove.Translated & " " & ProjectFarmText)
            ' Copy the Farm to the clipboard then delete it
            CopyFarm(_farm)
            DeleteFarm(_farm)
        End If
    End Sub

    Public Sub CopyFarm(ByVal _farm As Farm)
        ' Copy the Farm's DataStore ObjectNode to the Clipboard
        Dim _farmObject As New DataObject(mFarmFormat.Name, _farm.MyStore)
        Clipboard.SetDataObject(_farmObject, True)
        StatusMessage = ProjectFarmText + " - " & mDictionary.tCopiedToClipboard.Translated
    End Sub

    Public Sub PasteFarm()
        ' Get the current Data Object on the Clipboard
        Dim _iDataObject As IDataObject = Clipboard.GetDataObject
        If (_iDataObject IsNot Nothing) Then

            ' Get the Farm (as a DataStore ObjectNode)
            Dim _farmObject As DataStore.ObjectNode =
                CType(_iDataObject.GetData(mFarmFormat.Name), DataStore.ObjectNode)
            If (_farmObject IsNot Nothing) Then

                ' Ensure the Farm has a unique name in its new home
                Dim _farmName As StringParameter = _farmObject.GetStringParameter(Farm.sFarmName)
                If (_farmName IsNot Nothing) Then
                    Dim _sfx As Integer = 1
                    Dim _name As String = _farmName.Value
                    Dim _farm As Farm = GetFarmByName(_name)
                    While Not (_farm Is Nothing)
                        ' Append " (2)", " (3)", ... until unique name is found
                        _sfx += 1
                        _name = _farmName.Value + " (" + _sfx.ToString + ")"
                        _farm = GetFarmByName(_name)
                    End While
                    _farmName.Value = _name
                    _farmName.Source = DataStore.Globals.ValueSources.UserEntered
                    _farmObject.SetParameter(Farm.sFarmName, _farmName)
                End If

                ' Mark the current Data Store state as an Undo point
                mDataStore.MarkForUndo(mDictionary.tPaste.Translated & " " & ProjectFarmText)
                ' Add the Farm to the Project
                AddFarm(_farmObject)

                StatusMessage = ProjectFarmText + " pasted into Project"
            End If
        End If
    End Sub

    Public Function CanPasteFarm() As Boolean
        ' Get the current Data Object on the Clipboard
        Dim _iDataObject As IDataObject = Clipboard.GetDataObject
        ' Check if it is an Farm object
        If (_iDataObject IsNot Nothing) Then
            Dim _formats As String() = _iDataObject.GetFormats(False)
            For Each _format As String In _formats
                If (_format = mFarmFormat.Name) Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function
    '
    ' Cut / Copy / Paste a Field
    '
    Public Sub CutField(ByVal _field As Field)
        If (_field IsNot Nothing) Then
            ' Get reference to containing Farm
            Dim _farm As Farm = _field.FarmRef
            If (_farm IsNot Nothing) Then
                ' Mark the current Data Store state as an Undo point
                mDataStore.MarkForUndo(mDictionary.tRemove.Translated & " " & CaseFieldText)
                ' Copy Field to the cipboard then remove it from the Farm
                CopyField(_field)
                _farm.RemoveField(_field)
            Else
                _field.Remove()
            End If
        End If
    End Sub

    Public Sub CopyField(ByVal _field As Field)
        ' Copy the Field's DataStore ObjectNode to the Clipboard
        Dim _fieldObject As New DataObject(mFieldFormat.Name, _field.MyStore)
        Clipboard.SetDataObject(_fieldObject, True)
        StatusMessage = CaseFieldText & " - " & mDictionary.tCopiedToClipboard.Translated
    End Sub

    Public Sub PasteField(ByVal _farm As Farm)
        If (_farm IsNot Nothing) Then

            ' Get the current Data Object on the Clipboard
            Dim _iDataObject As IDataObject = Clipboard.GetDataObject
            If (_iDataObject IsNot Nothing) Then

                ' Get the Field (as a DataStore ObjectNode)
                Dim _fieldObject As DataStore.ObjectNode =
                    CType(_iDataObject.GetData(mFieldFormat.Name), DataStore.ObjectNode)
                If (_fieldObject IsNot Nothing) Then

                    ' Ensure the Field has a unique name in its new home
                    Dim _fieldName As StringParameter = _fieldObject.GetStringParameter(Field.sFieldName)
                    If (_fieldName IsNot Nothing) Then
                        Dim _sfx As Integer = 1
                        Dim _name As String = _fieldName.Value
                        Dim _field As Field = _farm.GetFieldByName(_name)
                        While Not (_field Is Nothing)
                            ' Append " (2)", " (3)", ... until unique name is found
                            _sfx += 1
                            _name = _fieldName.Value + " (" + _sfx.ToString + ")"
                            _field = _farm.GetFieldByName(_name)
                        End While
                        _fieldName.Value = _name
                        _fieldName.Source = DataStore.Globals.ValueSources.UserEntered
                        _fieldObject.SetParameter(Field.sFieldName, _fieldName)
                    End If

                    ' Mark the current Data Store state as an Undo point
                    mDataStore.MarkForUndo(mDictionary.tPaste.Translated & " " & CaseFieldText)
                    ' Add the Field to the selected Farm
                    _farm.AddField(_fieldObject)

                    StatusMessage = CaseFieldText + " pasted into " + ProjectFarmText
                End If
            End If
        End If
    End Sub

    Public Function CanPasteField() As Boolean
        ' Get the current Data Object on the Clipboard
        Dim _iDataObject As IDataObject = Clipboard.GetDataObject
        ' Check if it is an Field object
        If (_iDataObject IsNot Nothing) Then
            Dim _formats As String() = _iDataObject.GetFormats(False)
            For Each _format As String In _formats
                If (_format = mFieldFormat.Name) Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function
    '
    ' Cut / Copy / Paste a World Folder
    '
    Public Sub CutWorld(ByVal _world As World)
        If (_world IsNot Nothing) Then
            ' Get reference to containing Field
            Dim _field As Field = _world.FieldRef
            If (_field IsNot Nothing) Then
                ' Mark the current Data Store state as an Undo point
                mDataStore.MarkForUndo(mDictionary.tRemove.Translated & " " & WorldsText(_world.WorldType.Value) + " Folder")
                ' Copy Field to the Clipboard then remove it from the Field
                CopyWorld(_world)
                _field.RemoveWorld(_world)
            Else
                _world.Remove()
            End If
        End If
    End Sub

    Public Sub CopyWorld(ByVal _world As World)
        ' Copy the World's DataStore ObjectNode to the Clipboard
        Dim _worldObject As New DataObject(mWorldFormat.Name, _world.MyStore)
        Clipboard.SetDataObject(_worldObject, True)
        StatusMessage = mDictionary.tFolder.Translated & " - " & mDictionary.tCopiedToClipboard.Translated
    End Sub

    Public Sub PasteWorld(ByVal _field As Field)
        If (_field IsNot Nothing) Then

            ' Get the current Data Object on the Clipboard
            Dim _iDataObject As IDataObject = Clipboard.GetDataObject
            If (_iDataObject IsNot Nothing) Then

                ' Get the World (as a DataStore ObjectNode)
                Dim _worldObject As DataStore.ObjectNode =
                    CType(_iDataObject.GetData(mWorldFormat.Name), DataStore.ObjectNode)
                If (_worldObject IsNot Nothing) Then

                    ' Ensure the World has a unique name in its new home
                    Dim _worldType As IntegerParameter = _worldObject.GetIntegerParameter(World.sWorldType)
                    If (_worldType IsNot Nothing) Then
                        Dim _type As WorldTypes = CType(_worldType.Value, WorldTypes)

                        Dim _worldName As StringParameter = _worldObject.GetStringParameter(World.sWorldName)
                        If (_worldName IsNot Nothing) Then
                            Dim _sfx As Integer = 1
                            Dim _name As String = _worldName.Value
                            Dim _world As World = _field.GetWorldByName(_type, _name)
                            While Not (_world Is Nothing)
                                ' Append " (2)", " (3)", ... until unique name is found
                                _sfx += 1
                                _name = _worldName.Value + " (" + _sfx.ToString + ")"
                                _world = _field.GetWorldByName(_type, _name)
                            End While
                            _worldName.Value = _name
                            _worldName.Source = DataStore.Globals.ValueSources.UserEntered
                            _worldObject.SetParameter(World.sWorldName, _worldName)
                        Else
                            Debug.Assert(False, World.sWorldName + " is Nothing")
                            SeriousError("WinSRFR[PasteWorld]", World.sWorldName + " is Nothing")
                            Return
                        End If
                    Else
                        Debug.Assert(False, World.sWorldType + " is Nothing")
                        SeriousError("WinSRFR[PasteWorld]", World.sWorldType + " is Nothing")
                        Return
                    End If

                    ' Mark the current Data Store state as an Undo point
                    mDataStore.MarkForUndo(mDictionary.tPaste.Translated & " " & mDictionary.tFolder.Translated)
                    ' Add the World Folder to the selected Field
                    _field.AddWorld(_worldObject)

                    StatusMessage = "Folder pasted into " + CaseFieldText
                End If
            End If
        End If
    End Sub

    Public Function CanPasteWorld() As Boolean
        ' Get the current Data Object on the Clipboard
        Dim _iDataObject As IDataObject = Clipboard.GetDataObject
        ' Check if it is an World object
        If (_iDataObject IsNot Nothing) Then
            Dim _formats As String() = _iDataObject.GetFormats(False)
            For Each _format As String In _formats
                If (_format = mWorldFormat.Name) Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function
    '
    ' Cut / Copy / Paste an Analysis
    '
    Public Sub CutAnalysis(ByVal _analysis As Unit)
        If (_analysis IsNot Nothing) Then
            ' Get reference to containing World
            Dim _world As World = _analysis.WorldRef
            If (_world IsNot Nothing) Then
                ' Mark the current Data Store state as an Undo point
                mDataStore.MarkForUndo(mDictionary.tRemove.Translated & " " & AnalysesText(_world.WorldType.Value))
                ' Copy Analysis to clipboard then remove it from the World Folder
                CopyAnalysis(_analysis)
                _world.RemoveAnalysis(_analysis)
            Else
                _analysis.Remove()
            End If
        End If

    End Sub

    Public Sub CopyAnalysis(ByVal _analysis As Unit)
        ' Copy the Analysis' DataStore ObjectNode to the Clipboard
        Dim _analysisObject As New DataObject(mAnalysisFormat.Name, _analysis.MyStore)
        Clipboard.SetDataObject(_analysisObject, True)
        StatusMessage = AnalysesText(_analysis.UnitType.Value) & " - " & mDictionary.tCopiedToClipboard.Translated
    End Sub

    Public Sub PasteAnalysis(ByVal _world As World)
        If (_world IsNot Nothing) Then

            Dim _msg As String
            Dim _response As MsgBoxResult

            ' Get the current Data Object on the Clipboard
            Dim _iDataObject As IDataObject = Clipboard.GetDataObject
            If (_iDataObject IsNot Nothing) Then

                ' Get the Analysis (as a DataStore ObjectNode)
                Dim _analysisObject As DataStore.ObjectNode =
                    CType(_iDataObject.GetData(mAnalysisFormat.Name), DataStore.ObjectNode)
                If (_analysisObject IsNot Nothing) Then
                    '
                    ' Design & Operations Worlds only support:
                    '   Slope
                    '   Manning n roughness
                    '   Limited Infiltration Functions
                    '   Standard Hydrograph
                    '   Time-Based Cutoff / Cutback
                    '
                    Dim _systemGeometry As DataStore.ObjectNode = _analysisObject.GetObject(Unit.sSystemGeometry)
                    If (_systemGeometry IsNot Nothing) Then
                        ' Get bottom description
                        Dim _bottom As IntegerParameter = _systemGeometry.GetIntegerParameter(SystemGeometry.sBottomDescription)
                        If (_bottom IsNot Nothing) Then
                            '
                            ' If necessary, change from Slope / Elevation Table to Slope
                            '
                            Select Case (_bottom.Value)
                                Case BottomDescriptions.SlopeTable
                                    _msg = "Change Bottom Description to Average from Slope Table?"
                                    ' Design/Operations Worlds do not support Slope Table
                                    If ((_world.WorldType.Value = WorldTypes.DesignWorld) _
                                    Or (_world.WorldType.Value = WorldTypes.OperationsWorld)) Then
                                        _response = MsgBox(_msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel,
                                        WorldsText(_world.WorldType.Value) + " World does not support Slope Table")

                                        If (_response = MsgBoxResult.Cancel) Then
                                            Return
                                        End If

                                        ' Set Bottom Description to Average from Slope Table
                                        _bottom.Value = BottomDescriptions.AvgFromSlopeTable
                                        _bottom.Source = DataStore.Globals.ValueSources.Calculated
                                        _systemGeometry.SetParameter(SystemGeometry.sBottomDescription, _bottom)
                                    End If

                                Case BottomDescriptions.ElevationTable
                                    _msg = "Change Bottom Description to Average from Elevation Table?"
                                    ' Design/Operations Worlds do not support Elevation Table
                                    If ((_world.WorldType.Value = WorldTypes.DesignWorld) _
                                    Or (_world.WorldType.Value = WorldTypes.OperationsWorld)) Then
                                        _response = MsgBox(_msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel,
                                        WorldsText(_world.WorldType.Value) + " World does not support Elevation Table")

                                        If (_response = MsgBoxResult.Cancel) Then
                                            Return
                                        End If

                                        ' Set Bottom Description to Average from Elevation Table
                                        _bottom.Value = BottomDescriptions.AvgFromElevTable
                                        _bottom.Source = DataStore.Globals.ValueSources.Calculated
                                        _systemGeometry.SetParameter(SystemGeometry.sBottomDescription, _bottom)
                                    End If
                            End Select
                        End If
                    End If

                    Dim _soilCropProperties As DataStore.ObjectNode = _analysisObject.GetObject(Unit.sSoilCropProperties)
                    If (_soilCropProperties IsNot Nothing) Then
                        ' Get roughness methdo
                        Dim _roughMethod As IntegerParameter = _soilCropProperties.GetIntegerParameter(SoilCropProperties.sRoughnessMethod)
                        If (_roughMethod IsNot Nothing) Then
                            '
                            ' If necessary, report Roughness Method mismatch
                            '
                            Select Case (_roughMethod.Value)
                                Case RoughnessMethods.ManningN                              ' These are OK
                                Case RoughnessMethods.NrcsSuggestedManningN

                                Case Else
                                    If ((_world.WorldType.Value = WorldTypes.DesignWorld) _
                                     Or (_world.WorldType.Value = WorldTypes.OperationsWorld)) Then
                                        Dim _roughName As String = RoughnessMethodSelections(_roughMethod.Value).Value
                                        _msg = _roughName & " is not supported" & Chr(10) & Chr(10)
                                        _msg &= "The Roughness Method must be modified using the Soil Crop Properties tab."

                                        _response = MsgBox(_msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel,
                                        WorldsText(_world.WorldType.Value) + " World does not support " & _roughName)

                                        If (_response = MsgBoxResult.Cancel) Then
                                            Return
                                        End If
                                    End If
                            End Select
                        End If
                    End If

                    ' Get infiltration method
                    Dim _infMethod As IntegerParameter = _soilCropProperties.GetIntegerParameter(SoilCropProperties.sInfiltrationFunction)
                    If (_infMethod IsNot Nothing) Then
                        '
                        ' If necessary, report Infiltration Function mismatch
                        '
                        Select Case (_infMethod.Value)
                            Case InfiltrationFunctions.CharacteristicInfiltrationTime   ' These are OK
                            Case InfiltrationFunctions.KostiakovFormula
                            Case InfiltrationFunctions.ModifiedKostiakovFormula
                            Case InfiltrationFunctions.NRCSIntakeFamily
                            Case InfiltrationFunctions.GreenAmpt
                            Case InfiltrationFunctions.WarrickGreenAmpt

                            Case Else
                                If ((_world.WorldType.Value = WorldTypes.DesignWorld) _
                                 Or (_world.WorldType.Value = WorldTypes.OperationsWorld)) Then
                                    Dim _infName As String = InfiltrationFunctionSelections(_infMethod.Value).Value
                                    _msg = _infName & " is not supported" & Chr(10) & Chr(10)
                                    _msg &= "The Infiltration Function must be modified using the Soil Crop Properties tab."

                                    _response = MsgBox(_msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel,
                                    WorldsText(_world.WorldType.Value) + " World does not support " & _infName)

                                    If (_response = MsgBoxResult.Cancel) Then
                                        Return
                                    End If
                                End If
                        End Select
                    End If

                    Dim _inflowManagement As DataStore.ObjectNode = _analysisObject.GetObject(Unit.sInflowManagement)
                    If (_inflowManagement IsNot Nothing) Then

                        ' Get inflow description
                        Dim _inflow As IntegerParameter = _inflowManagement.GetIntegerParameter(InflowManagement.sInflowMethod)
                        If (_inflow IsNot Nothing) Then
                            '
                            ' If necessary, change to Standard Hydrograph
                            '
                            If Not (_inflow.Value = InflowMethods.StandardHydrograph) Then
                                Dim _method As String = InflowMethodSelections(_inflow.Value).Value
                                _msg = "Change to Standard Hydrograph?"

                                ' Design/Operations Worlds only supports Standard Hydrograph
                                If ((_world.WorldType.Value = WorldTypes.DesignWorld) _
                                Or (_world.WorldType.Value = WorldTypes.OperationsWorld)) Then
                                    _response = MsgBox(_msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel,
                                    WorldsText(_world.WorldType.Value) + " World does not support " + _method)

                                    If (_response = MsgBoxResult.Cancel) Then
                                        Return
                                    End If

                                    ' Set Inflow Method to Standard Hydrograph
                                    _inflow.Value = InflowMethods.StandardHydrograph
                                    _inflow.Source = DataStore.Globals.ValueSources.Calculated
                                    _inflowManagement.SetParameter(InflowManagement.sInflowMethod, _inflow)
                                End If
                            End If
                        End If

                        ' Get cutoff method
                        Dim _cutoff As IntegerParameter = _inflowManagement.GetIntegerParameter(InflowManagement.sCutoffMethod)
                        If (_cutoff IsNot Nothing) Then
                            '
                            ' If necessary, change to Time-Based Cutoff
                            '
                            Select Case (_cutoff.Value)
                                Case CutoffMethods.TimeBased
                                    ' These cutoff methods are ok
                                Case Else
                                    Dim _method As String = CutoffMethodSelections(_cutoff.Value).Value
                                    _msg = "Change to Time-Based Cutoff?"
                                    ' Design/Operations Worlds only supports Time / Distance-Based Cutoff
                                    If ((_world.WorldType.Value = WorldTypes.DesignWorld) _
                                    Or (_world.WorldType.Value = WorldTypes.OperationsWorld)) Then
                                        _response = MsgBox(_msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel,
                                        WorldsText(_world.WorldType.Value) + " World does not support " + _method)

                                        If (_response = MsgBoxResult.Cancel) Then
                                            Return
                                        End If

                                        ' Set Cutoff Method to Distance-Based
                                        _cutoff.Value = CutoffMethods.TimeBased
                                        _cutoff.Source = DataStore.Globals.ValueSources.Calculated
                                        _inflowManagement.SetParameter(InflowManagement.sCutoffMethod, _cutoff)
                                    End If
                            End Select
                        End If

                        ' Get cutback method
                        Dim _cutback As IntegerParameter = _inflowManagement.GetIntegerParameter(InflowManagement.sCutbackMethod)
                        If (_cutback IsNot Nothing) Then
                            '
                            ' If necessary, change to Time-Based Cutback
                            '
                            Select Case (_cutback.Value)
                                Case CutbackMethods.TimeBased, CutbackMethods.NoCutback
                                    ' These cutback methods are ok
                                Case Else
                                    Dim _method As String = CutbackMethodSelections(_cutback.Value).Value
                                    _msg = "Change to Time-Based Cutback?"
                                    ' Design/Operations Worlds only supports Time-Based Cutback
                                    If ((_world.WorldType.Value = WorldTypes.DesignWorld) _
                                    Or (_world.WorldType.Value = WorldTypes.OperationsWorld)) Then
                                        _response = MsgBox(_msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel,
                                        WorldsText(_world.WorldType.Value) + " World does not support " + _method)

                                        If (_response = MsgBoxResult.Cancel) Then
                                            Return
                                        End If

                                        ' Set Cutback Method to Distance-Based
                                        _cutback.Value = CutbackMethods.TimeBased
                                        _cutback.Source = DataStore.Globals.ValueSources.Calculated
                                        _inflowManagement.SetParameter(InflowManagement.sCutbackMethod, _cutback)
                                    End If
                            End Select
                        End If
                    End If

                    Dim _borderCriteria As DataStore.ObjectNode = _analysisObject.GetObject(Unit.sBorderCriteria)

                    If (_borderCriteria IsNot Nothing) Then

                        ' Set Design World's contour range so Solution Point is at the center of its right edge
                        If (_world.WorldType.Value = WorldTypes.DesignWorld) Then

                            ' Length (L)
                            Dim _l As DoubleParameter = _systemGeometry.GetDoubleParameter(SystemGeometry.sLength)

                            Dim _dp As DoubleParameter = _borderCriteria.GetDoubleParameter(BorderCriteria.sContourLengthPoint)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_l.Value, Units.Meters)
                                _dp.Source = _l.Source
                                _borderCriteria.AddProperty(BorderCriteria.sContourLengthPoint, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _l.Value) Then
                                        _dp.Value = _l.Value
                                        _dp.Source = _l.Source
                                        _borderCriteria.SetParameter(BorderCriteria.sContourLengthPoint, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMinContourLength)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(0.0, Units.Meters)
                                _dp.Source = ValueSources.Calculated
                                _borderCriteria.AddProperty(BorderCriteria.sMinContourLength, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = 0.0) Then
                                        _dp.Value = 0.0
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMinContourLength, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMaxContourLength)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_l.Value, Units.Meters)
                                _dp.Source = _l.Source
                                _borderCriteria.AddProperty(BorderCriteria.sMaxContourLength, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _l.Value) Then
                                        _dp.Value = _l.Value
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMaxContourLength, _dp)
                                    End If
                                End If
                            End If

                            ' Width (W)
                            Dim _w As DoubleParameter = _systemGeometry.GetDoubleParameter(SystemGeometry.sWidth)

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sContourWidthPoint)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_w.Value, Units.Meters)
                                _dp.Source = _w.Source
                                _borderCriteria.AddProperty(BorderCriteria.sContourWidthPoint, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _w.Value) Then
                                        _dp.Value = _w.Value
                                        _dp.Source = _w.Source
                                        _borderCriteria.SetParameter(BorderCriteria.sContourWidthPoint, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMinContourWidth)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(0.0, Units.Meters)
                                _dp.Source = ValueSources.Calculated
                                _borderCriteria.AddProperty(BorderCriteria.sMinContourWidth, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = 0.0) Then
                                        _dp.Value = 0.0
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMinContourWidth, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMaxContourWidth)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_w.Value * 2.0, Units.Meters)
                                _dp.Source = _w.Source
                                _borderCriteria.AddProperty(BorderCriteria.sMaxContourWidth, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _w.Value * 2.0) Then
                                        _dp.Value = _w.Value * 2.0
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMaxContourWidth, _dp)
                                    End If
                                End If
                            End If

                            ' Inflow Rate (Q)
                            Dim _q As DoubleParameter = _inflowManagement.GetDoubleParameter(InflowManagement.sInflowRate)

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sContourInflowRatePoint)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_q.Value, Units.Cms)
                                _dp.Source = _q.Source
                                _borderCriteria.AddProperty(BorderCriteria.sContourInflowRatePoint, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _q.Value) Then
                                        _dp.Value = _q.Value
                                        _dp.Source = _q.Source
                                        _borderCriteria.SetParameter(BorderCriteria.sContourInflowRatePoint, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMinContourInflowRate)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(0.0, Units.Cms)
                                _dp.Source = ValueSources.Calculated
                                _borderCriteria.AddProperty(BorderCriteria.sMinContourInflowRate, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = 0.0) Then
                                        _dp.Value = 0.0
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMinContourInflowRate, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMaxContourInflowRate)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_q.Value * 2.0, Units.Cms)
                                _dp.Source = _q.Source
                                _borderCriteria.AddProperty(BorderCriteria.sMaxContourInflowRate, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _q.Value * 2.0) Then
                                        _dp.Value = _q.Value * 2.0
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMaxContourInflowRate, _dp)
                                    End If
                                End If
                            End If
                        End If

                        ' Set Operations World's contour range so Solution Point is at its center
                        If (_world.WorldType.Value = WorldTypes.OperationsWorld) Then
                            ' Cutoff Time (Tco)
                            Dim _tco As DoubleParameter = _inflowManagement.GetDoubleParameter(InflowManagement.sCutoffTime)

                            Dim _dp As DoubleParameter = _borderCriteria.GetDoubleParameter(BorderCriteria.sContourCutoffTimePoint)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_tco.Value, Units.Seconds)
                                _dp.Source = _tco.Source
                                _borderCriteria.AddProperty(BorderCriteria.sContourCutoffTimePoint, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _tco.Value) Then
                                        _dp.Value = _tco.Value
                                        _dp.Source = _tco.Source
                                        _borderCriteria.SetParameter(BorderCriteria.sContourCutoffTimePoint, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMinContourCutoffTime)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(0.0, Units.Seconds)
                                _dp.Source = ValueSources.Calculated
                                _borderCriteria.AddProperty(BorderCriteria.sMinContourCutoffTime, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = 0.0) Then
                                        _dp.Value = 0.0
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMinContourCutoffTime, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMaxContourCutoffTime)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_tco.Value * 2.0, Units.Seconds)
                                _dp.Source = ValueSources.Calculated
                                _borderCriteria.AddProperty(BorderCriteria.sMaxContourCutoffTime, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _tco.Value * 2.0) Then
                                        _dp.Value = _tco.Value * 2.0
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMaxContourCutoffTime, _dp)
                                    End If
                                End If
                            End If

                            ' Inflow Rate (Q)
                            Dim _q As DoubleParameter = _inflowManagement.GetDoubleParameter(InflowManagement.sInflowRate)

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sContourInflowRatePoint)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_q.Value, Units.Cms)
                                _dp.Source = _q.Source
                                _borderCriteria.AddProperty(BorderCriteria.sContourInflowRatePoint, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _q.Value) Then
                                        _dp.Value = _q.Value
                                        _dp.Source = _q.Source
                                        _borderCriteria.SetParameter(BorderCriteria.sContourInflowRatePoint, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMinContourInflowRate)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(0.0, Units.Cms)
                                _dp.Source = ValueSources.Calculated
                                _borderCriteria.AddProperty(BorderCriteria.sMinContourInflowRate, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = 0.0) Then
                                        _dp.Value = 0.0
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMinContourInflowRate, _dp)
                                    End If
                                End If
                            End If

                            _dp = _borderCriteria.GetDoubleParameter(BorderCriteria.sMaxContourInflowRate)
                            If (_dp Is Nothing) Then
                                _dp = New DoubleParameter(_q.Value * 2.0, Units.Cms)
                                _dp.Source = _q.Source
                                _borderCriteria.AddProperty(BorderCriteria.sMaxContourInflowRate, _dp)
                            Else
                                If Not (_dp.Source = ValueSources.UserEntered) Then
                                    If Not (_dp.Value = _q.Value * 2.0) Then
                                        _dp.Value = _q.Value * 2.0
                                        _dp.Source = ValueSources.Calculated
                                        _borderCriteria.SetParameter(BorderCriteria.sMaxContourInflowRate, _dp)
                                    End If
                                End If
                            End If
                        End If
                    End If

                    ' Ensure the Analysis has a unique name in its new home
                    Dim _unitName As StringParameter = _analysisObject.GetStringParameter(Unit.sUnitName)
                    Dim _sfx As Integer = 1
                    Dim _name As String = _unitName.Value
                    Dim _analysis As Unit = _world.GetAnalysisByName(_name)
                    While Not (_analysis Is Nothing)
                        ' Append " (2)", " (3)", ... until unique name is found
                        _sfx += 1
                        _name = _unitName.Value + " (" + _sfx.ToString + ")"
                        _analysis = _world.GetAnalysisByName(_name)
                    End While
                    _unitName.Value = _name
                    _unitName.Source = DataStore.Globals.ValueSources.UserEntered
                    _analysisObject.SetParameter(Unit.sUnitName, _unitName)

                    ' Set the Analysis' type to match its new World Folder
                    Dim _unitType As IntegerParameter = _analysisObject.GetIntegerParameter(Unit.sUnitType)
                    Dim _oldType As WorldTypes = CType(_unitType.Value, WorldTypes)
                    _unitType.Value = _world.WorldType.Value
                    _unitType.Source = DataStore.Globals.ValueSources.UserEntered
                    _analysisObject.SetParameter(Unit.sUnitType, _unitType)

                    ' Set the Creation Date/Time as noe
                    Dim _dateTimeParameter As DateTimeParameter = _analysisObject.GetDateTimeParameter(Unit.sCreationDateTime)
                    _dateTimeParameter.Value = System.DateTime.Now
                    _dateTimeParameter.Source = DataStore.Globals.ValueSources.Calculated
                    _analysisObject.SetParameter(Unit.sCreationDateTime, _dateTimeParameter)

                    ' Mark Results as invalid
                    Dim _runControl As DataStore.ObjectNode = _analysisObject.GetObject(Unit.sUnitControl)
                    If (_runControl IsNot Nothing) Then

                        ' Set the Run Count to zero
                        Dim _runCount As IntegerParameter = _runControl.GetIntegerParameter(UnitControl.sRunCount)
                        _runCount.Value = 0
                        _runCount.Source = DataStore.Globals.ValueSources.Calculated
                        _runControl.SetParameter(UnitControl.sRunCount, _runCount)

                        ' Clear the Log
                        Dim _log As ArrayListParameter = _runControl.GetArrayListParameter(UnitControl.sLog)
                        If (_log IsNot Nothing) Then
                            _log.Array.Clear()
                            _log.Source = DataStore.Globals.ValueSources.Calculated
                            _runControl.SetParameter(UnitControl.sLog, _log)
                        End If
                    End If

                    ' Update the Analysis' Data History
                    Dim _datetime As String = System.DateTime.Now.ToLongDateString _
                                            + " at " _
                                            + System.DateTime.Now.ToLongTimeString

                    Dim _dataHistory As ArrayListParameter = _analysisObject.GetArrayListParameter(Unit.sDataHistory)
                    If (_dataHistory IsNot Nothing) Then
                        _dataHistory.Source = DataStore.Globals.ValueSources.Calculated
                        _dataHistory.Array.Insert(0, " ")
                        _dataHistory.Array.Insert(0, "     To " + WorldsText(_world.WorldType.Value) + " Folder: " + _world.Name.Value)
                        _dataHistory.Array.Insert(0, "Copy / Paste - " + _datetime)
                        _analysisObject.SetParameter(Unit.sDataHistory, _dataHistory)
                    End If

                    ' Mark the current Data Store state as an Undo point
                    mDataStore.MarkForUndo(mDictionary.tPaste.Translated & " " & AnalysesText(_world.WorldType.Value))

                    ' Add the Analysis to the selected World Folder
                    _world.AddAnalysisObject(_analysisObject)

                    StatusMessage = AnalysesText(_world.WorldType.Value) + " pasted into Folder"
                End If
            End If
        End If
    End Sub

    Public Function CanPasteAnalysis() As Boolean
        ' Get the current Data Object on the Clipboard
        Dim _iDataObject As IDataObject = Clipboard.GetDataObject
        ' Check if it is an Analysis object
        If (_iDataObject IsNot Nothing) Then
            Dim _formats As String() = _iDataObject.GetFormats(False)
            For Each _format As String In _formats
                If (_format = mAnalysisFormat.Name) Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

#End Region

#Region " Remove Object Methods (UI Support) "
    '
    ' Remove a Farm
    '
    ' Note - this method is intended to be called from a UI action
    '
    Public Sub RemoveFarm(ByVal _farm As Farm)

        If (_farm IsNot Nothing) Then
            ' Confirm delete
            Dim _msg As String = String.Format("Remove the " + ProjectFarmText + " named '{0}'?", _farm.Name.Value)
            Dim _title As String = "Remove Confirmation"
            Dim _style As MsgBoxStyle = MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
            Dim _response As MsgBoxResult = MsgBox(_msg, _style, _title)

            If (_response = MsgBoxResult.Yes) Then   ' User chose Yes
                ' Mark the current Data Store state as an Undo point
                mDataStore.MarkForUndo(mDictionary.tRemove.Translated & " " & ProjectFarmText)
                ' Delete Farm from Farm List
                DeleteFarm(_farm)
            End If
        End If

    End Sub
    '
    ' Remove a Field from a Farm
    '
    ' Note - this method is intended to be called from a UI action
    '
    Public Sub RemoveField(ByVal _field As Field)

        If (_field IsNot Nothing) Then

            ' Get reference to containing Farm
            Dim _farm As Farm = _field.FarmRef

            If (_farm IsNot Nothing) Then

                ' Confirm delete
                Dim _msg As String = String.Format("Remove the " + CaseFieldText + " named '{0}'?", _field.Name.Value)
                Dim _title As String = "Remove Confirmation"
                Dim _style As MsgBoxStyle = MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
                Dim _response As MsgBoxResult = MsgBox(_msg, _style, _title)

                If (_response = MsgBoxResult.Yes) Then   ' User chose Yes

                    ' Mark the current Data Store state as an Undo point
                    mDataStore.MarkForUndo(mDictionary.tRemove.Translated & " " & CaseFieldText)

                    ' Remove Field from Field List
                    _farm.RemoveField(_field)

                End If
            Else
                _field.Remove()
            End If
        End If

    End Sub
    '
    ' Remove a World from a Field
    '
    ' Note - this method is intended to be called from a UI action
    '
    Public Sub RemoveWorld(ByVal _world As World)

        If (_world IsNot Nothing) Then

            ' Get reference to containing Field
            Dim _field As Field = _world.FieldRef

            If (_field IsNot Nothing) Then

                ' Confirm delete
                Dim _msg As String = String.Format("Remove the " + WorldsText(_world.WorldType.Value) + " Folder named '{0}'?", _world.Name.Value)
                Dim _title As String = "Remove Confirmation"
                Dim _style As MsgBoxStyle = MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
                Dim response As MsgBoxResult = MsgBox(_msg, _style, _title)

                If (response = MsgBoxResult.Yes) Then   ' User chose Yes

                    ' Mark the current Data Store state as an Undo point
                    mDataStore.MarkForUndo(mDictionary.tRemove.Translated & " " & WorldsText(_world.WorldType.Value) + " Folder")

                    ' Remove World from World List
                    _field.RemoveWorld(_world)

                End If
            Else
                _world.Remove()
            End If
        End If

    End Sub
    '
    ' Remove an Analysis from a World
    '
    ' Note - this method is intended to be called from a UI action
    '
    Public Sub RemoveAnalysis(ByVal _analysis As Unit)

        If (_analysis IsNot Nothing) Then

            ' Get reference to containing World
            Dim _world As World = _analysis.WorldRef

            If (_world IsNot Nothing) Then

                ' Confirm delete
                Dim _msg As String = String.Format("Remove the Analysis named '{0}'?", _analysis.Name.Value)
                Dim _title As String = "Remove Confirmation"
                Dim _style As MsgBoxStyle = MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo
                Dim response As MsgBoxResult = MsgBox(_msg, _style, _title)

                If (response = MsgBoxResult.Yes) Then   ' User chose Yes.

                    ' Mark the current Data Store state as an Undo point
                    mDataStore.MarkForUndo(mDictionary.tRemove.Translated & " " & mDictionary.tAnalysis.Translated)

                    ' Remove Analysis from Analysis List
                    _world.RemoveAnalysis(_analysis)

                End If
            Else
                _analysis.Remove()
            End If
        End If

    End Sub

#End Region

#Region " Analysis Methods "
    '
    ' Run Analysis
    '
    Public Function RunAnalysis(ByVal unit As Unit,
                                Optional ByVal errorBox As ErrorRichTextBox = Nothing,
                                Optional ByVal runCount As Integer = 0) As Boolean

        Debug.Assert(unit IsNot Nothing)

        Dim analysisWasRun As Boolean = False

        If (unit IsNot Nothing) Then
            Dim analysis As Analysis = Nothing

            Dim world As World = unit.WorldRef
            If (world IsNot Nothing) Then

                Select Case (world.WorldType.Value)

                    Case WorldTypes.EventWorld

                        Dim eventCriteria As EventCriteria = unit.EventCriteriaRef

                        Select Case (eventCriteria.EventAnalysisType.Value)
                            Case EventAnalysisTypes.InfiltratedProfileAnalysis
                                analysis = New InfiltratedProfile(unit, Nothing)
                            Case EventAnalysisTypes.MerriamKellerAnalysis
                                analysis = New MerriamKeller(unit, Nothing)
                            Case EventAnalysisTypes.TwoPointAnalysis
                                analysis = New ElliotWalkerTwoPoint(unit, Nothing)
                            Case EventAnalysisTypes.ErosionAnalysis
                                analysis = New ErosionAnalysis(unit, Nothing)
                            Case EventAnalysisTypes.EvalueAnalysis
                                analysis = New EVALUE(unit, Nothing)
                        End Select

                    Case WorldTypes.DesignWorld

                        Select Case (unit.CrossSection)
                            Case CrossSections.Furrow
                                analysis = New FurrowDesign(unit, Nothing)
                            Case CrossSections.Basin, CrossSections.Border
                                analysis = New BasinBorderDesign(unit, Nothing)
                        End Select

                    Case WorldTypes.OperationsWorld

                        Select Case (unit.CrossSection)
                            Case CrossSections.Furrow
                                analysis = New FurrowOperations(unit, Nothing)
                            Case Else ' CrossSections.Basin/Border
                                analysis = New BasinBorderOperations(unit, Nothing)
                        End Select

                    Case WorldTypes.SimulationWorld

                        analysis = New SrfrSimulation(unit, Nothing)

                End Select

                Debug.Assert(analysis IsNot Nothing)

                analysisWasRun = RunAnalysis(analysis, errorBox, runCount)

                AnalysisExplorer.RefreshView()
                Application.DoEvents() ' keep the UI updating (i.e. re-painting)

            End If ' (_unit InNot Nothing)
        End If ' (_world IsNot Nothing)

        Return analysisWasRun
    End Function

    Public Function RunAnalysis(ByVal analysis As Analysis,
                                Optional ByVal errorBox As ErrorRichTextBox = Nothing,
                                Optional ByVal runCount As Integer = 0) As Boolean

        Debug.Assert(analysis IsNot Nothing)

        Dim analysisWasRun As Boolean = False
        Dim analysisName As String = analysis.Unit.Name.Value
        If (0 < runCount) Then
            analysisName &= " / " & runCount.ToString
        End If

        If (analysis IsNot Nothing) Then
            '
            ' Analysis may have a reference to the SRFR DLL set via a WorldWindow
            '
            If (analysis.SrfrAPI Is Nothing) Then ' If not, use WinSRFR's
                analysis.SrfrAPI = mSrfrAPI
            End If
            '
            ' Running an Analysis is a three step process:
            '   1) Verify the Analysis is capable of running (i.e. no setup errors)
            '   2) Run the Analysis
            '   3) Check Analysis for execution errors
            '
            Dim autoRunOk As Boolean = analysis.PreAutoRun()    ' 1) Verify Analysis can be run
            If (autoRunOk) Then
                StatusMessage = "Running " & analysisName

                analysis.AutoRun()                              ' 2) Run the Analysis
                analysis.PostAutoRun()                          ' 3) Check for execution errors
                analysisWasRun = True

                StatusMessage = "Run Complete "
            End If

            ' Display any errors/warning thay may be preset
            If ((analysis.HasSetupErrorsOrWarnings) Or
                (analysis.HasExecutionErrorsOrWarnings)) Then

                errorBox.DisplayBoldUnderlineLine(analysisName)
                errorBox.DisplayLine("")

                errorBox.DisplayErrors(analysis, True)
                errorBox.DisplayWarnings(analysis, True)
            End If
        End If

        Return analysisWasRun
    End Function
    '
    ' Clear All Results
    '
    Public Sub ClearAllResults()
        ' Scan through all Farms / Fields / Worlds / Units
        Dim _farm As Farm = Me.GetFirstFarm
        While (_farm IsNot Nothing)
            Dim _field As Field = _farm.GetFirstField
            While (_field IsNot Nothing)
                Dim _world As World = _field.GetFirstWorld
                While (_world IsNot Nothing)
                    Dim analysis As Unit = _world.GetFirstAnalysis
                    While (analysis IsNot Nothing)
                        ' Clear analysis's Results and Undo/Redo lists
                        analysis.ClearResults()
                        analysis.MyStore.ClearUndoRedo()
                        analysis = _world.GetNextAnalysis()
                    End While
                    _world.MyStore.ClearUndoRedo()
                    _world = _field.GetNextWorld
                End While
                _field.MyStore.ClearUndoRedo()
                _field = _farm.GetNextField
            End While
            _farm.MyStore.ClearUndoRedo()
            _farm = Me.GetNextFarm
        End While

        ' Clear date/time the file was saved since we know it has changed
        FileTimestamp = DateTime.MinValue
        ' Clear application's Undo/Redo list
        Me.MyStore.ClearUndoRedo()
        ' Update Save, Undo & Redo toolbar button status
        Me.UpdateToolbar()
        Me.Refresh()

        mDesignWorld.RefreshUI()
        mEvaluationWorld.RefreshUI()
        mOperationsWorld.RefreshUI()
        mSimulationWorld.RefreshUI()

    End Sub
    '
    ' Count Units within a WinSRFR World
    '
    Public Function UnitCount(ByVal _type As WorldTypes) As Integer

        Dim _count As Integer = 0

        ' Scan through all the Farms
        Dim _farm As Farm = Me.GetFirstFarm
        While (_farm IsNot Nothing)
            ' Scan through all the Farm's Fields
            Dim _field As Field = _farm.GetFirstField
            While (_field IsNot Nothing)
                ' Scan through all the Field's Worlds
                Dim _world As World = _field.GetFirstWorld
                While (_world IsNot Nothing)
                    ' Count all Units in this World
                    If (_world.WorldType.Value = _type) Then
                        _count += _world.AnalysisCount
                    End If
                    _world = _field.GetNextWorld
                End While
                _field = _farm.GetNextField
            End While
            _farm = Me.GetNextFarm
        End While

        Return _count

    End Function
    '
    ' Get first Unit within a WinSRFR World
    '
    Public Function GetFirstUnit(ByVal _type As WorldTypes) As Unit

        Dim _unit As Unit = Nothing

        ' Scan through all the Farms
        Dim _farm As Farm = Me.GetFirstFarm
        While (_farm IsNot Nothing)
            ' Scan through all the Farm's Fields
            Dim _field As Field = _farm.GetFirstField
            While (_field IsNot Nothing)
                ' Scan through all the Field's Worlds
                Dim _world As World = _field.GetFirstWorld
                While (_world IsNot Nothing)
                    ' If World is requested type, return it
                    If (_world.WorldType.Value = _type) Then ' Return first Unit in this World
                        _unit = _world.GetFirstAnalysis
                        If (_unit IsNot Nothing) Then
                            Return _unit
                        End If
                    End If
                    _world = _field.GetNextWorld
                End While
                _field = _farm.GetNextField
            End While
            _farm = Me.GetNextFarm
        End While

        Return Nothing

    End Function
    '
    ' Is a Unit currently being displayed?
    '
    Public Function IsUnitDisplayed(ByVal _unit As Unit) As Boolean

        If (_unit IsNot Nothing) Then
            ' Check if specified Unit is displayed in corresponding World Window
            Select Case (_unit.UnitType.Value)

                Case WorldTypes.EventWorld
                    If (mEvaluationWorld.DisplayedUnit Is _unit) Then
                        Return True
                    End If

                Case WorldTypes.DesignWorld
                    If (mDesignWorld.DisplayedUnit Is _unit) Then
                        Return True
                    End If

                Case WorldTypes.OperationsWorld
                    If (mOperationsWorld.DisplayedUnit Is _unit) Then
                        Return True
                    End If

                Case WorldTypes.SimulationWorld
                    If (mSimulationWorld.DisplayedUnit Is _unit) Then
                        Return True
                    End If
            End Select
        End If

        Return False
    End Function
    '
    ' Is a Unit currently being displayed?
    '
    Public Sub UpdateWorldUI(ByVal _unit As Unit)

        If (_unit IsNot Nothing) Then
            ' Check if specified Unit is displayed in corresponding World Window
            Select Case (_unit.UnitType.Value)

                Case WorldTypes.EventWorld
                    If (mEvaluationWorld.DisplayedUnit Is _unit) Then
                        mEvaluationWorld.UpdateResultsControls()
                        mEvaluationWorld.UpdateUI()
                    End If

                Case WorldTypes.DesignWorld
                    If (mDesignWorld.DisplayedUnit Is _unit) Then
                        mDesignWorld.UpdateResultsControls()
                        mDesignWorld.UpdateUI()
                    End If

                Case WorldTypes.OperationsWorld
                    If (mOperationsWorld.DisplayedUnit Is _unit) Then
                        mOperationsWorld.UpdateResultsControls()
                        mOperationsWorld.UpdateUI()
                    End If

                Case WorldTypes.SimulationWorld
                    If (mSimulationWorld.DisplayedUnit Is _unit) Then
                        mSimulationWorld.UpdateResultsControls()
                        mSimulationWorld.UpdateUI()
                    End If
            End Select
        End If

    End Sub
    '
    ' Show a Unit in its corresponding World Window
    '
    Public Sub ShowUnit(ByVal _unit As Unit)

        Debug.Assert((_unit IsNot Nothing), "Unit is Nothing")

        ' Save this Unit as the Selected Analysis
        SelectedAnalysis = _unit
        UpdateUI()

        Try
            ' Show the specified Unit is the corresponding World Window
            Select Case (_unit.UnitType.Value)

                Case WorldTypes.EventWorld
                    If (mEvaluationWorld.DisplayedUnit IsNot _unit) Then
                        mEvaluationWorld.DisplayWorldWindow(_unit)
                    End If
                    mEvaluationWorld.ShowWorldWindow()

                Case WorldTypes.DesignWorld
                    If (mDesignWorld.DisplayedUnit IsNot _unit) Then
                        mDesignWorld.DisplayWorldWindow(_unit)
                    End If
                    mDesignWorld.ShowWorldWindow()

                Case WorldTypes.OperationsWorld
                    If (mOperationsWorld.DisplayedUnit IsNot _unit) Then
                        mOperationsWorld.DisplayWorldWindow(_unit)
                    End If
                    mOperationsWorld.ShowWorldWindow()

                Case WorldTypes.SimulationWorld
                    If (mSimulationWorld.DisplayedUnit IsNot _unit) Then
                        mSimulationWorld.DisplayWorldWindow(_unit)
                    End If
                    mSimulationWorld.ShowWorldWindow()
            End Select

        Catch ex As Exception
            Dim _unitVersion As String = _unit.UnitControlRef.ProductVersion.Value
            Dim _prodVersion As String = Me.ProductVersion

            If (_prodVersion < _unitVersion) Then
                UsageError("Show Analysis", "Analysis is incompatable", "Analysis was created with later version of WinSRFR (" & _unitVersion & ")")
            Else
                UsageException("WinSRFR:ShowUnit()", ex)
            End If
        End Try

    End Sub
    '
    ' Hide a Unit in its corresponding World Window
    '
    Public Sub HideUnit(ByVal _unit As Unit)

        Debug.Assert((_unit IsNot Nothing), "Unit is Nothing")

        Try
            ' Show the specified Unit is the corresponding World Window
            Select Case (_unit.UnitType.Value)

                Case WorldTypes.EventWorld
                    mEvaluationWorld.Hide()

                Case WorldTypes.DesignWorld
                    mDesignWorld.Hide()

                Case WorldTypes.OperationsWorld
                    mOperationsWorld.Hide()

                Case WorldTypes.SimulationWorld
                    mSimulationWorld.Hide()
            End Select

        Catch ex As Exception
            CriticalException("WinSRFR:HideUnit()", ex)
        End Try

    End Sub

#End Region

#Region " Update UI Methods "
    '
    ' Show this Window
    '
    Public Sub ShowWinSRFR()
        If (Me.WindowState = FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Show()
        Me.Activate()
    End Sub
    '
    ' Update the Toolbar icons
    '
    Public Sub UpdateToolbar()
        Me.SaveProjectButton.Enabled = DataHasChanged()
        Me.UndoButton.Enabled = mDataStore.CanUndo()
        Me.RedoButton.Enabled = mDataStore.CanRedo()

        ' Tooltips
        Me.NewProjectButton.ToolTipText = mDictionary.tNewProject.Translated
        Me.OpenProjectButton.ToolTipText = mDictionary.tOpenProject.Translated
        Me.SaveProjectButton.ToolTipText = mDictionary.tSaveProject.Translated
        Me.UndoButton.ToolTipText = mDictionary.tUndo.Translated
        Me.RedoButton.ToolTipText = mDictionary.tRedo.Translated
        Me.WhatsThisHelpButton.ToolTipText = mDictionary.tWhatsThisHelp.Translated

    End Sub
    '
    ' Update User Interface
    '
    Public Sub UpdateUI()
        '
        ' Get the Selected Farm & Field names
        '
        Dim _farmName As String = "none"
        Dim _fieldName As String = "none"

        If Not (SelectedFarm Is Nothing) Then
            _farmName = SelectedFarm.Name.Value
        End If

        If Not (SelectedField Is Nothing) Then
            _fieldName = SelectedField.Name.Value
        End If
        '
        ' Update WinSRFR Window
        '
        Me.AccessibleDescription = mDictionary.tWinSrfrDescription.Translated
        '
        ' Update Title Bar
        '
        If Not (SelectedFarm Is Nothing) Then
            If (FileName = String.Empty) Then
                TitleBar = Title + " - " + ProjectFarmText + ": " + _farmName
            Else
                TitleBar = Title + " - " + FileName + " (" + ProjectFarmText + ": " + _farmName + ")"
            End If
        Else
            TitleBar = Title
        End If
        '
        ' Udpate Menu Bar
        '
        If (DebuggerIsAttached) Then
            ProgrammerMenu.Visible = True
        Else
            ProgrammerMenu.Visible = False
        End If
        '
        ' Update Toolbar
        '
        UpdateToolbar()
        '
        ' Update Status Bar
        '
        Me.UserLevelPanel.Text = mDictionary.tUserLevel.Translated & ": " & UserLevelText(UserLevel)
        '
        ' Display the FARM & FIELD in the TitleBox
        '
        TitleBox.Clear()
        TitleBox.SelectionAlignment = HorizontalAlignment.Center
        AppendFieldIdText(TitleBox, Me, _farmName, _fieldName, 120)
        '
        ' Update World Buttons
        '
        Me.ToolTip.SetToolTip(Me.EventButton, Me.EventButton.AccessibleDescription)
        Me.ToolTip.SetToolTip(Me.DesignButton, Me.DesignButton.AccessibleDescription)
        Me.ToolTip.SetToolTip(Me.OperationsButton, Me.OperationsButton.AccessibleDescription)
        Me.ToolTip.SetToolTip(Me.SimulationButton, Me.SimulationButton.AccessibleDescription)

    End Sub

    Public Property TitleBar() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal Value As String)
            Me.Text = Value
        End Set
    End Property

    Public Property StatusMessage() As String
        Get
            Return Me.StatusPanel.Text
        End Get
        Set(ByVal Value As String)
            Me.StatusPanel.Text = Value
        End Set
    End Property

#End Region

#Region " Command Interface (CI) Methods "

#Region " Delegates "
    '
    ' Delegate for Public Sub ParseCommand(ByVal args() As Object)
    '   Used by CommandInterface to invoke ParseCommand (i.e. marshall call to the main thread)
    Public Delegate Function ParseCommandDelegate(ByVal args As Object) As ParseError

    ' Method in main thread; invoked in CommandInterface event handler
    Public Function ParseCommand(ByVal args As Object) As ParseError
        Dim result As ParseError = ParseError.ParseFailed
        If Not (mCommandInterface Is Nothing) Then
            ' Now running in main thread; send execution back to CommandInterface
            Dim command As String = CStr(args)
            StatusMessage = command
            result = mCommandInterface.ParseCommand(command)
        End If
        Return result
    End Function
    '
    ' Delegates for Public Sub Parse..Query(ByVal args As Object())
    '   Used by CommandInterface to invoke Parse..Query (i.e. marshall call to the main thread)
    Public Delegate Function ParseStringQueryDelegate(ByVal args As Object()) As ParseError
    Public Delegate Function ParseIntegerQueryDelegate(ByVal args As Object()) As ParseError
    Public Delegate Function ParseSingleQueryDelegate(ByVal args As Object()) As ParseError
    Public Delegate Function ParseDoubleQueryDelegate(ByVal args As Object()) As ParseError

    ' Methods in main thread; invoked in CommandInterface event handler
    Public Function ParseStringQuery(ByVal args As Object()) As ParseError
        Dim result As ParseError = ParseError.ParseFailed
        If Not (mCommandInterface Is Nothing) Then
            ' Now running in main thread; send execution back to CommandInterface
            Dim query As String = CStr(args(0))
            Dim reply As String = String.Empty
            StatusMessage = query
            result = mCommandInterface.ParseStringQuery(query, reply)
            args(1) = reply
        End If
        Return result
    End Function

    Public Function ParseIntegerQuery(ByVal args As Object()) As ParseError
        Dim result As ParseError = ParseError.ParseFailed
        If Not (mCommandInterface Is Nothing) Then
            ' Now running in main thread; send execution back to CommandInterface
            Dim query As String = CStr(args(0))
            Dim reply As Integer
            StatusMessage = query
            result = mCommandInterface.ParseIntegerQuery(query, reply)
            args(1) = reply
        End If
        Return result
    End Function

    Public Function ParseSingleQuery(ByVal args As Object()) As ParseError
        Dim result As ParseError = ParseError.ParseFailed
        If Not (mCommandInterface Is Nothing) Then
            ' Now running in main thread; send execution back to CommandInterface
            Dim query As String = CStr(args(0))
            Dim reply As Single
            StatusMessage = query
            result = mCommandInterface.ParseSingleQuery(query, reply)
            args(1) = reply
        End If
        Return result
    End Function

    Public Function ParseDoubleQuery(ByVal args As Object()) As ParseError
        Dim result As ParseError = ParseError.ParseFailed
        If Not (mCommandInterface Is Nothing) Then
            ' Now running in main thread; send execution back to CommandInterface
            Dim query As String = CStr(args(0))
            Dim reply As Double
            StatusMessage = query
            result = mCommandInterface.ParseDoubleQuery(query, reply)
            args(1) = reply
        End If
        Return result
    End Function

#End Region

#Region " Methods "

    ' Run specified Analysis / Simulation
    Public Sub Run(ByVal analysis As Unit)
        If (mEvaluationWorld.DisplayedUnit Is analysis) Then
            mEvaluationWorld.Run()
        ElseIf (mDesignWorld.DisplayedUnit Is analysis) Then
            mDesignWorld.Run()
        ElseIf (mOperationsWorld.DisplayedUnit Is analysis) Then
            mOperationsWorld.Run()
        ElseIf (mSimulationWorld.DisplayedUnit Is analysis) Then
            mSimulationWorld.Run()
        End If
    End Sub

#End Region

#End Region

#Region " What's This Help "

    Public Sub StartWhatsThisHelp(ByVal _form As System.Windows.Forms.Form)
        ' Capture mouse events; see override of WndProc()
        _form.Capture = True
        ' Save current cursor then display help cursor (arrow & question mark)
        mOldCursor = _form.Cursor
        _form.Cursor = Cursors.Help
    End Sub

    Public Sub PauseWhatsThisHelp(ByVal _form As System.Windows.Forms.Form)
        ' Restore old cursor
        _form.Cursor = mOldCursor
    End Sub

    Public Sub StopWhatsThisHelp(ByVal _form As System.Windows.Forms.Form)
        ' Release mouse events
        _form.Capture = False
        ' Restore old cursor
        _form.Cursor = mOldCursor
    End Sub

    Public Function WhatsThisHelp(ByRef m As Message, ByVal _form As System.Windows.Forms.Form) As Boolean
        '
        ' Form must be 'Active' for What's This Help
        '
        If Not (Form.ActiveForm Is _form) Then
            Return False
        End If

        If (mHelpPopup Is Nothing) Then
            '
            ' Display What's This Help for this control
            '
            Dim _mouseScreen As Point = _form.PointToScreen(New Point(m.LParam.ToInt32))
            Dim _mouseClient As Point = _form.PointToClient(_mouseScreen)

            Dim _parent As Control = _form
            Dim _ctrl As Control = _form.GetChildAtPoint(_mouseClient)

            Dim _title As String = Me.AccessibleName
            Dim _desc As String = Me.AccessibleDescription

            If Not (_form.AccessibleName Is Nothing) Then
                If Not (_form.AccessibleName = String.Empty) Then
                    _title = _form.AccessibleName
                    _desc = _form.AccessibleDescription
                End If
            End If
            '
            ' Scan all controls under the mouse for the most specific help text
            '
            Do While Not (_ctrl Is Nothing)
                '
                ' If the control is hidden; find the visible one at this point
                '
                If Not (_ctrl.Visible) Then

                    ' Scan the parent's control list
                    For _idx As Integer = 0 To _parent.Controls.Count - 1
                        _ctrl = _parent.Controls(_idx)
                        If (_ctrl.Visible) Then
                            ' Control is visible; is it under the mouse?
                            _mouseClient = _ctrl.PointToClient(_mouseScreen)
                            If (_ctrl.ClientRectangle.Contains(_mouseClient)) Then
                                ' Control is under the mouse; this is it!
                                Exit For
                            End If
                        End If
                    Next _idx

                End If
                '
                ' If this control has an Accessible Name & Description; get them
                '
                If (_ctrl.Visible) Then
                    If Not (_ctrl.AccessibleName Is Nothing) Then
                        If Not (_ctrl.AccessibleName = String.Empty) Then
                            _title = _ctrl.AccessibleName
                            _desc = _ctrl.AccessibleDescription
                        End If
                    End If
                    '
                    ' Continue looking down the control hierarchy
                    '
                    _mouseClient = _ctrl.PointToClient(_mouseScreen)
                    _parent = _ctrl
                    _ctrl = _ctrl.GetChildAtPoint(_mouseClient)
                Else
                    Exit Do
                End If
            Loop
            '
            ' Build the popup help message
            '
            If (_title Is Nothing) Then
                _title = Me.AccessibleName
                _desc = Me.AccessibleDescription
            Else
                If (_desc Is Nothing) Then
                    _desc = String.Empty
                End If
            End If

            ' Calculate popup window width
            Dim _width As Integer = _title.Length * Me.FontHeight()
            If (_width < _form.Width / 3) Then
                _width = CInt(_form.Width / 3) ' Minimum of 1/3 application width
            End If
            If (_form.Width / 2 < _width) Then
                _width = CInt(_form.Width / 2) ' Maximum of 1/2 application width
            End If

            ' Calculate approx. number of lines to display
            Dim _lines As Integer = CInt(((1.5 * _desc.Length) / (_width / (Me.FontHeight() / 2.5))) + 2)
            If (_lines < 3) Then
                _lines = 3 ' Minimum of 3 lines
            End If

            _lines = _lines + LineCount(_desc) - 1

            ' Calculate popup window height
            Dim _height As Integer = _lines * (Me.FontHeight() + 3)

            ' Calculate popup window position
            _mouseClient = _form.PointToClient(_mouseScreen)
            _mouseClient.Y = _mouseClient.Y + 20
            _mouseClient.X = _mouseClient.X + 10

            If (_mouseClient.Y < 0) Then
                _mouseClient.Y = 0 ' Must be within the view
            End If

            If (_form.Width < (_mouseClient.X + _width)) Then
                _mouseClient.X = _mouseClient.X - _width ' Can't be off right
            End If
            If (_form.Height - 40 < (_mouseClient.Y + _height)) Then
                _mouseClient.Y = _mouseClient.Y - _height - 40 ' Can't be off low
            End If

            ' Build the popup using a RichTextBox
            mHelpPopup = New RichTextBox
            mHelpPopup.Width = _width
            mHelpPopup.Height = _height
            mHelpPopup.Location = _mouseClient
            mHelpPopup.BackColor = System.Drawing.Color.LightCyan
            mHelpPopup.ScrollBars = RichTextBoxScrollBars.None

            ' Add to controls and display it
            _form.Controls.Add(mHelpPopup)
            mHelpPopup.BringToFront()
            mHelpPopup.Show()

            ' Load with the accessibility text
            AppendBoldLine(mHelpPopup, _title)
            AdvanceLine(mHelpPopup)
            AppendText(mHelpPopup, _desc)

            Return True

        Else
            '
            ' Take down What's This Help
            '
            mHelpPopup.Clear()
            mHelpPopup.Hide()
            _form.Controls.Remove(mHelpPopup)
            mHelpPopup.Dispose()
            mHelpPopup = Nothing

            Return False

        End If

    End Function

#End Region

#Region " PDF Manual "
    '
    ' View the WinSRFR PDF Manual using Acrobat Reader
    '
    Public Shared Sub ViewPdfManual(Optional ByVal Key As String = Nothing)
        HelpAndManual.PdfFilePath = PdfFilePath
        HelpAndManual.ViewPdfManual(Key)
    End Sub

#End Region

#Region " Error Handling "
    '
    ' Error & Exception Reporting
    '
    ' Level (from low to high):
    '
    '   Usage    - requested operation beyond the program's capabilities
    '   Serious  - program can continue with limited functionality; reinstall
    '   Critical - program cannot continue and must close; reinstall
    '
    Enum ErrorLevels
        LowLimit = -1
        Usage
        Serious
        Critical
        HighLimit
    End Enum


    ' Usage Error & Exception
    Public Sub UsageError(ByVal _function As String, ByVal _operation As String, ByVal _errmsg As String)
        DisplayMessage(ErrorLevels.Usage, _function + " - " + _operation, _errmsg)
        LogError(ErrorLevels.Usage, _function + " - " + _operation, _errmsg)
    End Sub

    Public Sub UsageException(ByVal _errmsg As String, ByVal ex As Exception)
        DisplayMessage(ErrorLevels.Usage, _errmsg, ex.ToString)
        LogException(ErrorLevels.Usage, _errmsg, ex)
    End Sub


    ' Serious Error & Exception
    Public Sub SeriousError(ByVal _errmsg As String, ByVal _details As String)
        DisplayMessage(ErrorLevels.Serious, _errmsg, _details)
        LogError(ErrorLevels.Serious, _errmsg, _details)
    End Sub

    Public Sub SeriousException(ByVal _errmsg As String, ByVal ex As Exception)
        DisplayMessage(ErrorLevels.Serious, _errmsg, ex.ToString)
        LogException(ErrorLevels.Serious, _errmsg, ex)
    End Sub


    ' Critical Error & Exception
    Public Sub CriticalError(ByVal _errmsg As String, ByVal _details As String)
        DisplayMessage(ErrorLevels.Critical, _errmsg, _details)
        LogError(ErrorLevels.Critical, _errmsg, _details)
        ExitProgram(True)
    End Sub

    Public Sub CriticalException(ByVal _errmsg As String, ByVal ex As Exception)
        DisplayMessage(ErrorLevels.Critical, _errmsg, ex.ToString)
        LogException(ErrorLevels.Critical, _errmsg, ex)
        ExitProgram(True)
    End Sub
    '
    ' Error & Exception MsgBox Display
    '
    Private Const mCriticalMessage As String = "This is a CRITICAL error; WinSRFR cannot continue running."
    Private Const mSeriousMessage As String = "This is a serious error, however, WinSRFR can continue running."

    Private Const mReinstallMessage As String = "Re-install WinSRFR to attempt to correct this error."
    Private Const mReoccurMessage As String = "If this error reoccurs, contact ALARC."
    Private Const mErrorMessage As String = "Error details:"

    Private Sub MsgBoxUsage(ByVal _title As String, ByVal _errmsg As String)
        MsgBox(_errmsg, MsgBoxStyle.Information, "WinSRFR - Usage Error: " + _title)
    End Sub

    Private Sub MsgBoxSerious(ByVal _title As String, ByVal _errmsg As String)
        Dim _prompt As String = mSeriousMessage + ChrW(13) + ChrW(13) _
                            + mReoccurMessage + ChrW(13) + ChrW(13) _
                            + mErrorMessage + ChrW(13) + ChrW(13) _
                            + _errmsg
        MsgBox(_prompt, MsgBoxStyle.Exclamation, "WinSRFR - Serious Error: " + _title)
    End Sub

    Private Sub MsgBoxCritical(ByVal _title As String, ByVal _errmsg As String)
        Dim _prompt As String = mCriticalMessage + ChrW(13) + ChrW(13) _
                            + mReinstallMessage + ChrW(13) + ChrW(13) _
                            + mReoccurMessage + ChrW(13) + ChrW(13) _
                            + mErrorMessage + ChrW(13) + ChrW(13) _
                            + _errmsg
        MsgBox(_prompt, MsgBoxStyle.Critical, "WinSRFR - Critical Error: " + _title)
    End Sub

    Public Sub DisplayMessage(ByVal _level As ErrorLevels, ByVal _title As String, ByVal _errmsg As String)
        Select Case _level
            Case ErrorLevels.Usage
                MsgBoxUsage(_title, _errmsg)
            Case ErrorLevels.Serious
                MsgBoxSerious(_title, _errmsg)
            Case Else ' Assume ErrorLevels.Critical
                MsgBoxCritical(_title, _errmsg)
        End Select
    End Sub
    '
    ' Error & Exception Logging
    '
    Private Const MaxErrorLogSize As Long = 32 * 1024 ' 32k

    Public Sub LogError(ByVal _level As ErrorLevels, ByVal _errmsg As String, ByVal _details As String)

        ' Limit the size of error log
        Dim _fileInfo As FileInfo = New FileInfo(ErrorLogFilePath)

        If (_fileInfo.Exists) Then
            While (MaxErrorLogSize < _fileInfo.Length)

                ' Read the error log into a temporary array
                Dim _sr As StreamReader = File.OpenText(ErrorLogFilePath)
                Dim _temp As ArrayList = New ArrayList
                Dim _line As String = _sr.ReadLine

                While Not (_line Is Nothing)
                    _temp.Add(_line)
                    _line = _sr.ReadLine
                End While

                _sr.Close()

                ' Delete the oldest entry
                While (0 < _temp.Count)
                    _line = CStr(_temp(0))
                    _temp.RemoveAt(0)
                    If (_line.StartsWith("==========")) Then
                        Exit While
                    End If
                End While

                ' Write the remaining log back to the file
                Dim _sw As StreamWriter = File.CreateText(ErrorLogFilePath)
                For Each _line In _temp
                    _sw.WriteLine(_line)
                Next
                _sw.Flush()
                _sw.Close()

                _fileInfo = New FileInfo(ErrorLogFilePath)
            End While
        End If

        ' Open the WinSRFR log file
        Dim _log As StreamWriter = File.AppendText(ErrorLogFilePath)

        ' Append date & time
        Dim _msg As String = DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString()
        Debug.WriteLine("================================================================================")
        Debug.WriteLine(_msg)
        _log.WriteLine(_msg)

        ' Append level & error message (also write to Debug)
        _log.WriteLine()
        Select Case _level
            Case ErrorLevels.Usage
                _msg = ControlChars.CrLf & "Usage Error:  "
            Case ErrorLevels.Serious
                _msg = ControlChars.CrLf & "Serious Error:  "
            Case Else ' Assume ErrorLevels.Critical
                _msg = ControlChars.CrLf & "Critical Error:  "
        End Select

        Debug.WriteLine(_msg + _errmsg)
        _log.WriteLine(_msg + _errmsg)

        ' Append error details
        _msg = ControlChars.CrLf & "Details:"
        Debug.WriteLine(_msg)
        _log.WriteLine(_msg)

        _msg = ControlChars.CrLf & _details
        Debug.WriteLine(_msg)
        _log.WriteLine(_msg)

        ' Append entry separator (also used to when limiting size of error log file)
        Debug.WriteLine("================================================================================")
        _log.WriteLine("================================================================================")

        ' Close the writer and underlying file.
        _log.Flush()
        _log.Close()

    End Sub

    Public Sub LogException(ByVal _level As ErrorLevels, ByVal _errmsg As String, ByVal _ex As Exception)
        LogError(_level, _errmsg, _ex.ToString)
    End Sub

#End Region

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        Language
        Nomenclature
        UserLevel
        FarmList
    End Enum
    '
    ' Event generated when a property changes
    '
    Public Event WinSrfrUpdated(ByVal _reason As Reasons)
    '
    ' DataStore generates change events when .srfr File is read
    '
    Private Sub DataStore_ObjectDataChanged(ByVal _reason As ObjectNode.Reasons) _
    Handles mDataStore.ObjectDataChanged
        ' Handle & regenerate the DataStore event as a WinSRFR event
        Select Case _reason
            Case ObjectNode.Reasons.ObjectListChanged

                ' Relink Root objects
                Me.LinkToDataStore()
                mUnitsSystem.LinkToDataStore()

                ' Rebuild the WinSRFR objects (Farm, Field, ...)
                RebuildFarmList()
                UpdateUI()
                RaiseEvent WinSrfrUpdated(Reasons.FarmList)
        End Select
    End Sub
    '
    ' MyStore generates change events
    '
    Private Sub MyStore_ObjectDataChanged(ByVal _reason As ObjectNode.Reasons) _
    Handles mMyStore.ObjectDataChanged
        ' Handle & regenerate the DataStore event as a WinSRFR event
        Select Case _reason
            Case ObjectNode.Reasons.ObjectListChanged
                RebuildFarmList()
                UpdateUI()
                RaiseEvent WinSrfrUpdated(Reasons.FarmList)
        End Select
    End Sub
    '
    ' Title Box displays the names of the Selected Farm & Field; watch for changes
    '
    Private Sub Farm_Updated(ByVal _reason As Farm.Reasons) _
    Handles mSelectedFarm.FarmUpdated
        Select Case _reason
            Case Farm.Reasons.Name
                ' Update the UI to reflect the name chane
                UpdateUI()
            Case Farm.Reasons.FieldList
                If Not (SelectedField Is Nothing) Then
                    ' Check if Selected Field is still in the Farm's Field List
                    Dim _field As Field = SelectedFarm.GetFirstField
                    While Not (_field Is Nothing)
                        If (SelectedField.MyID = _field.MyID) Then
                            ' It is in the list; no change
                            Exit Sub
                        End If
                        _field = SelectedFarm.GetNextField
                    End While
                End If

                ' The Selected Field is not in the Field List; default to first Field, if any
                SelectedField = SelectedFarm.GetFirstField
                UpdateUI()
        End Select
    End Sub

    Private Sub Field_Updated(ByVal _reason As Field.Reasons) _
    Handles mSelectedField.FieldUpdated
        Select Case _reason
            Case Field.Reasons.Name
                ' Update the UI to reflect the name chane
                UpdateUI()
            Case Field.Reasons.WorldList
                If Not (SelectedWorld Is Nothing) Then
                    ' Check if Selected World is still in the Field's World List
                    Dim _world As World = SelectedField.GetFirstWorld
                    While Not (_world Is Nothing)
                        If (SelectedWorld.MyID = _world.MyID) Then
                            ' It is in the list; no change
                            Exit Sub
                        End If
                        _world = SelectedField.GetNextWorld
                    End While
                End If

                ' The Selected World is not in the World List; default to first World, if any
                SelectedWorld = SelectedField.GetFirstWorld
        End Select
    End Sub

    Private Sub World_Updated(ByVal _reason As World.Reasons) _
    Handles mSelectedWorld.WorldUpdated
        Select Case _reason
            Case World.Reasons.AnalysisList
                If Not (SelectedAnalysis Is Nothing) Then
                    ' Check if Selected Analysis is still in the World's Analysis List
                    Dim _analysis As Unit = SelectedWorld.GetFirstAnalysis
                    While Not (_analysis Is Nothing)
                        If (SelectedAnalysis.MyID = _analysis.MyID) Then
                            ' It is in the list; no change
                            Exit Sub
                        End If
                        _analysis = SelectedWorld.GetNextAnalysis
                    End While
                End If

                ' The Selected World is not in the World List; default to first World, if any
                SelectedAnalysis = SelectedWorld.GetFirstAnalysis
        End Select
    End Sub

#End Region

#Region " Status Bar Timer "

    '*********************************************************************************************************
    ' Timer & Callbacks for updating Status Bar time display in a threadsafe manner
    '*********************************************************************************************************
    Private mTickTimer As Timer

    ' Timer Callback
    Public Sub Tick(ByVal state As Object)
        Me.UpdateTime() ' Threadsafe method to update time/date display
    End Sub 'Tick

    ' Delegate that enables asynchronous calls
    Delegate Sub UpdateTimeCallback()

    ' Threadsafe method for updating time display
    Private Sub UpdateTime()
        '
        ' InvokeRequired compares thread ID of calling thread to thread ID of creating thread
        '
        Try
            If (Me.InvokeRequired) Then ' threads are different
                Dim d As New UpdateTimeCallback(AddressOf UpdateTime)       ' Create delegate for this method
                Me.Invoke(d)                                                ' Execute delegate using safe thread
            Else ' threads are the same
                Me.TimePanel.Text = DateTime.Now.ToShortTimeString          ' Update time display
                Me.TimePanel.ToolTipText = DateTime.Now.ToLongDateString    ' Update tooltip date display
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " File Menu "

    Private Sub FileMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileMenu.Popup

        If (0 < FarmCount) Then
            ' There is a Farm; enable menu items
            FileCloseProjectItem.Enabled = True

            If (DataHasChanged()) Then
                FileSaveItem.Enabled = True
            Else
                FileSaveItem.Enabled = False
            End If
            FileSaveAsItem.Enabled = True

            FileExitItem.Enabled = True
        Else
            ' No Farm; limit what the user can do
            FileCloseProjectItem.Enabled = False

            FileSaveItem.Enabled = False
            FileSaveAsItem.Enabled = False

            FileExitItem.Enabled = True
        End If

        ' Populate the MRU Project List
        FileMruItem.Enabled = False
        FileMruItem.MenuItems.Clear()

        Dim _idx As Integer = 1
        For Each _file As String In mMruProjectList
            FileMruItem.Enabled = True
            FileMruItem.MenuItems.Add("&" + _idx.ToString + " - " + _file,
                                    New EventHandler(AddressOf MruFileItem_Click))
            _idx += 1

            If (mMaxMruFiles < _idx) Then
                Exit For
            End If
        Next

        ' Populate the Example File List
        FileExamplesItem.Enabled = False
        FileExamplesItem.MenuItems.Clear()

        _idx = 1
        Dim _item As String
        For Each _file As String In mExamplesFileList
            FileExamplesItem.Enabled = True

            If (_idx < 10) Then ' use numeric (1-9) prefix
                _item = "&" + Chr(Asc("1") + _idx - 1) + " - " + _file
            Else ' use alpha (a-z) prefix
                _item = "&" + Chr(Asc("a") + _idx - 10) + " - " + _file
            End If

            FileExamplesItem.MenuItems.Add(_item, New EventHandler(AddressOf ExampleFileItem_Click))

            _idx += 1
            If (35 < _idx) Then
                Exit For
            End If
        Next _file

        ' Enable / disable File Properties item
        If (FilePath = String.Empty) Then
            FilePropertiesItem.Enabled = False
        Else
            FilePropertiesItem.Enabled = True
        End If

    End Sub

    Private Sub MruFileItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles MruFileItem.Click (menu items are dynamically created by FileMenu_Popup()

        ' Sender should be MenuItem
        If (sender.GetType Is GetType(MenuItem)) Then
            Dim _menuItem As MenuItem = DirectCast(sender, MenuItem)

            ' Get the selected File Path
            Dim _menuText As String = _menuItem.Text
            Dim _filePath As String = _menuText.Substring(5)

            If (CloseProject(True)) Then
                OpenProject(_filePath)
            End If
        End If

    End Sub

    Private Sub ExampleFileItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles ExampleFileItem.Click (menu items are dynamically created by FileMenu_Popup()

        ' Sender should be MenuItem
        If (sender.GetType Is GetType(MenuItem)) Then
            Dim examplesDirectory As String = Application.CommonAppDataPath & "\Examples\"
            If Not (Directory.Exists(examplesDirectory)) Then
                examplesDirectory = WinSrfrDirectory & "\Examples\"
            End If

            Dim _menuItem As MenuItem = DirectCast(sender, MenuItem)

            ' Get the selected File Path
            Dim _menuText As String = _menuItem.Text
            Dim _filePath As String = examplesDirectory + _menuText.Substring(5)

            If (CloseProject(True)) Then
                OpenProject(_filePath)
            End If
        End If

    End Sub

    Private Sub FileNewProjectItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileNewProjectItem.Click
        NewProject(True)
    End Sub

    Private Sub FileOpenProjectItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileOpenProjectItem.Click
        OpenProject(True)
    End Sub

    Private Sub FileCloseProjectItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileCloseProjectItem.Click
        CloseProject(True)
    End Sub

    Private Sub FileSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileSaveItem.Click
        Save()
    End Sub

    Private Sub FileSaveAsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileSaveAsItem.Click
        SaveAs()
    End Sub

    Private Sub FileExitItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileExitItem.Click
        ExitProgram(True)
    End Sub

    Private Sub WinSRFR_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        If Not (ExitProgram(True)) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FileClearAllResultsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileClearAllResultsItem.Click

        ' Display message box so user can verify Clear All Results
        Dim _title As String = "Clear All Results Confirmation"
        Dim _message As String
        Dim _result As MsgBoxResult

        _message = "This operation will clear:" + Chr(13) + Chr(13)
        _message += "   1) ALL results in ALL Analyses & Simulations" + Chr(13)
        _message += "   2) ALL Undo / Redo lists" + Chr(13) + Chr(13)
        _message += "This operation is not reversable!" + Chr(13) + Chr(13)
        _message += "Do you want to continue?"

        _result = MsgBox(_message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkCancel, _title)

        ' If user said OK, proceed
        If (_result = MsgBoxResult.Ok) Then
            ClearAllResults()
        End If

    End Sub

    Private Sub FilePropertiesItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FilePropertiesItem.Click
        Dim filename As String = FilePath()
        Dim attrbutes As FileAttribute = GetAttr(filename)
        Dim filesize As Long = FileLen(filename)

        Dim winsrfrName As String = Utilities.ProductName
        Dim winsrfrVersion As String = Utilities.ProductVersion
        Dim nameVersion As String = winsrfrName + " " + winsrfrVersion

        Dim msg As String = "File Properties:"
        msg += Chr(13)

        ' Created by
        msg += Chr(13) + "  Created by:"
        msg += Chr(13) + "     " + nameVersion
        msg += Chr(13)

        ' Accessed by
        Dim accessList As ArrayList = New ArrayList

        Dim farm As Farm = GetFirstFarm()
        While Not (farm Is Nothing)
            Dim field As Field = farm.GetFirstField()
            While Not (field Is Nothing)
                Dim world As World = field.GetFirstWorld()
                While Not (world Is Nothing)
                    Dim unit As Unit = world.GetFirstAnalysis()
                    While Not (unit Is Nothing)
                        Dim controlRef As UnitControl = unit.UnitControlRef

                        winsrfrName = controlRef.ProductName.Value
                        winsrfrVersion = controlRef.ProductVersion.Value
                        nameVersion = winsrfrName + " " + winsrfrVersion

                        If Not (accessList.Contains(nameVersion)) Then
                            accessList.Add(nameVersion)
                        End If
                        unit = world.GetNextAnalysis
                    End While
                    world = field.GetNextWorld()
                End While
                field = farm.GetNextField()
            End While
            farm = GetNextFarm()
        End While

        If (0 < accessList.Count) Then
            accessList.Sort()
            msg += Chr(13) + "  Accessed by:"
            For Each nameVersion In accessList
                msg += Chr(13) + "     " + nameVersion
            Next
            msg += Chr(13)
        End If

        ' File Attibutes
        msg += Chr(13) + "  Attributes:"
        msg += Chr(13) + "     " + attrbutes.ToString
        msg += Chr(13)

        ' File Size
        msg += Chr(13) + "  Size:"

        If (1000000000 < filesize) Then
            Dim gigabytes As Single = filesize / 1000000
            msg += Chr(13) + "     " + gigabytes.ToString + " GB"
        ElseIf (1000000 < filesize) Then
            Dim megabytes As Single = filesize / 1000000
            msg += Chr(13) + "     " + Format(megabytes, "0.0##") + " MB"
        ElseIf (1000 < filesize) Then
            Dim kilobytes As Single = filesize / 1000
            msg += Chr(13) + "     " + Format(kilobytes, "0.0##") + " KB"
        Else
            msg += Chr(13) + "     " + filesize.ToString + " bytes"
        End If

        MsgBox(msg, MsgBoxStyle.Information, filename)

    End Sub

#End Region

#Region " Edit Menu "

    Private Sub EditMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditMenu.Popup

        Dim _reason As String = String.Empty

        ' Enable / disable 'Undo' item
        If (mDataStore.CanUndo(_reason)) Then
            EditUndoItem.Enabled = True
            EditUndoItem.Text = "&" & mDictionary.tUndo.Translated & " " & _reason
        Else
            EditUndoItem.Enabled = False
            EditUndoItem.Text = "&" & mDictionary.tUndo.Translated
        End If

        ' Enable / disable 'Redo' item
        If (mDataStore.CanRedo(_reason)) Then
            EditRedoItem.Enabled = True
            EditRedoItem.Text = "&" & mDictionary.tRedo.Translated & " " & _reason
        Else
            EditRedoItem.Enabled = False
            EditRedoItem.Text = "&" & mDictionary.tRedo.Translated
        End If
    End Sub

    Private Sub EditUndoItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditUndoItem.Click
        Undo()
    End Sub

    Private Sub EditRedoItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditRedoItem.Click
        Redo()
    End Sub
    '
    ' Nomenclature
    '
    Private Sub EditNomenclatureItem_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditNomenclatureItem.Popup
        ' Load menu item with local language
        SelectFarmFieldItem.Text = "&" + mDictionary.tFarm.Translated + " / " + mDictionary.tField.Translated
        SelectProjectCaseItem.Text = "&" + mDictionary.tProject.Translated + " / " + mDictionary.tCase.Translated
        ' Clear all nomenclature menu item checks
        SelectFarmFieldItem.Checked = False
        SelectProjectCaseItem.Checked = False
        ' Check the appropriate user level menu item
        Select Case ProjectNomenclature
            Case ProjectNomenclatures.FarmField
                SelectFarmFieldItem.Checked = True
            Case ProjectNomenclatures.ProjectCase
                SelectProjectCaseItem.Checked = True
        End Select
    End Sub

    Private Sub SelectProjectCaseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SelectProjectCaseItem.Click
        ProjectNomenclature = ProjectNomenclatures.ProjectCase
    End Sub

    Private Sub SelectFarmFieldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SelectFarmFieldItem.Click
        ProjectNomenclature = ProjectNomenclatures.FarmField
    End Sub
    '
    ' User Level
    '
    Private Sub EditUserLevelItem_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditUserLevelItem.Popup
        ' Clear all user level menu item checks
        StandardUserLevelItem.Checked = False
        AdvancedUserLevelItem.Checked = False
        ResearchUserLevelItem.Checked = False
        ' Check the appropriate user level menu item
        Select Case UserLevel
            Case UserLevels.Standard
                StandardUserLevelItem.Checked = True
            Case UserLevels.Advanced
                AdvancedUserLevelItem.Checked = True
            Case UserLevels.Research
                ResearchUserLevelItem.Checked = True
        End Select
    End Sub

    Private Sub StandardUserLevelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StandardUserLevelItem.Click
        UserLevel = UserLevels.Standard
    End Sub

    Private Sub AdvancedUserLevelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AdvancedUserLevelItem.Click
        UserLevel = UserLevels.Advanced
    End Sub

    Private Sub ResearchUserLevelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ResearchUserLevelItem.Click

        If (WinSRFR.DebuggerIsAttached) Then ' Developer doesn't need to enter password
            UserLevel = UserLevels.Research

        Else ' not developer
            ' Prompt user for Password to Research Level
            Dim _message As String = "Enter Password:"
            Dim _title As String = "Password for Research Level"
            Dim _password As String = InputBox(_message, _title)

            ' Check user input ("" = Cancel)
            If Not (_password = String.Empty) Then
                If (_password = "BeCareful") Then
                    UserLevel = UserLevels.Research
                Else
                    MsgBox("Invalid password", MsgBoxStyle.Exclamation, _title)
                End If
            End If
        End If

    End Sub
    '
    ' User Preferences
    '
    Private Sub EditUserPreferencesItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditUserPreferencesItem.Click
        ' Verify explorer form has been created; then hide/show it
        Debug.Assert((mUserPreferences IsNot Nothing)) ' User Preferences form does not exist

        UpdateTranslation(mUserPreferences, Me.Language)

        If (mUserPreferences.Visible) Then
            mUserPreferences.BringToFront()
        Else
            mUserPreferences.ShowDialog()
        End If
    End Sub
    '
    ' Language
    '
    Private Sub EditLanguageItem_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditLanguageItem.Popup

        ' Clear current popup menu list
        SelectLanguageItem.MenuItems.Clear()

        ' Build new popup menu list based on available choices
        Dim item As MenuItem
        If (0 < mLanguagesList.Count) Then
            ' There are language choices
            For Each choice As String In mLanguagesList
                item = New MenuItem(choice, New EventHandler(AddressOf SelectLanguageItem_Click))
                If (choice = Language) Then
                    item.Checked = True
                End If
                SelectLanguageItem.MenuItems.Add(item)
            Next
        Else
            ' There are no language choices
            item = New MenuItem(Language, New EventHandler(AddressOf SelectLanguageItem_Click))
            item.Checked = True
            SelectLanguageItem.MenuItems.Add(item)
        End If

    End Sub

    Private Sub SelectLanguageItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles SelectLanguageItem.Click (menu items are dynamically created by SelectLanguageItem_Popup()

        ' Sender should be MenuItem
        If (sender.GetType Is GetType(MenuItem)) Then
            Dim item As MenuItem = DirectCast(sender, MenuItem)
            Dim selection As String = item.Text

            If (Me.Language = sNativeLanguage) Then ' current language is Native Language

                OpenLanguage(selection)                 ' Translate to selected Foreign Language

            Else ' current language is Foreign Language

                OpenLanguage(sNativeLanguage)           ' Reset to Native Language
                OpenLanguage(selection)                 ' Translate to selected Foreign Language

            End If

        End If

    End Sub

    Private Sub NewLanguageItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NewLanguageItem.Click
        ' 
        ' Save Native Language text file
        '
        Dim allUsersPath As String = Application.CommonAppDataPath
        Dim lastBackslash As Integer = allUsersPath.LastIndexOf("\")
        Dim allUsersWinSrfrPath As String = allUsersPath.Substring(0, lastBackslash)
        Dim languagesPath As String = allUsersWinSrfrPath + "\Languages"

        Try ' Create Languages directory if it doesn't exist
            MkDir(languagesPath)
        Catch ex As Exception
        End Try

        ' Prompt User to input Lanugage specification
        Dim db As db_NewLanguage = New db_NewLanguage
        db.LanguageFamily = Me.LanguageFamily
        Dim result As DialogResult = db.ShowDialog()

        mOldCursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor

        Me.StatusMessage = mDictionary.tCreatingNewLanguage.Translated

        Application.DoEvents()

        Try
            If (result = Windows.Forms.DialogResult.OK) Then
                Dim newLanguage As String = db.NewLanguage
                Dim errCode As Translator.ErrorCode = mDictionary.SaveForeignLanuage(languagesPath, newLanguage)
                If (errCode = Translator.ErrorCode.OK) Then ' Save worked
                    Me.StatusMessage = mDictionary.tNewLanguageCreated.Translated & ":  " & newLanguage
                Else ' Save failed
                    Me.StatusMessage = mDictionary.tNewLanguageSaveFailed.Translated & ":  " & newLanguage & " [" & errCode.ToString & "]"
                End If
            End If
        Catch ex As Exception
            Me.StatusMessage = mDictionary.tNewLanguageSaveFailed.Translated & " - " & ex.ToString
        Finally
            Me.Cursor = mOldCursor
        End Try

    End Sub
    '
    ' Units
    '
    Private Sub EditUnitsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditUnitsMenuItem.Click
        If (mUnitsDialogBox.Visible) Then
            mUnitsDialogBox.BringToFront()
        Else
            mUnitsDialogBox.InitDialogBox()
            mUnitsDialogBox.Show()
        End If
    End Sub

#End Region

#Region " View Menu "

    Private Sub ViewRefreshItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewRefreshItem.Click
        AnalysisExplorer.RefreshView()
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

        ViewSize949x768.Visible = DebuggerIsAttached
    End Sub

    Private Sub ViewSize800x600_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSize800x600.Click
        WindowSize = WindowSizes.S800x600
        Me.Size = New Size(800, 600)
    End Sub

    Private Sub ViewSize900x675_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSize900x675.Click
        WindowSize = WindowSizes.S900x675
        Me.Size = New Size(900, 675)
    End Sub

    Private Sub ViewSize949x768_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSize949x768.Click
        WindowSize = WindowSizes.S949x768
        Me.Size = New Size(949, 768)
    End Sub

    Private Sub ViewSize1024x768_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSize1024x768.Click
        WindowSize = WindowSizes.S1024x768
        Me.Size = New Size(1024, 768)
    End Sub

#End Region

#Region " Tools Menu "

    Private Sub DataComparisonItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DataComparisonItem.Click
        mDataComparer.ResetDataComparer()
        UpdateTranslation(mDataComparer, Me.Language)
        mDataComparer.ShowDialog()
    End Sub

    Private Sub ConversionChartItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ConversionChartItem.Click
        Dim db As ConversionChart = New ConversionChart
        UpdateTranslation(db, Me.Language)
        db.Show()
    End Sub

#End Region

#Region " Help Menu "
    '
    ' What's This Help
    '
    Private Sub WhatsThisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WhatsThisItem.Click
        mWhatsThisHelp = True
        StartWhatsThisHelp(Me)
    End Sub
    '
    ' Stop What's This Help when window is de-activated
    '  Note - Mouse capture is lost when window is de-activated
    '
    Protected Overrides Sub OnDeactivate(ByVal e As EventArgs)
        ' If What's This Help is active; stop it
        If (mWhatsThisHelp) Then
            StopWhatsThisHelp(Me)
        End If
        ' Call base class method to continue Windows message processing
        MyBase.OnDeactivate(e)
    End Sub
    '
    ' WndProc() - override of WndProc for intercepting Windows messages
    '
    Protected Overrides Sub WndProc(ByRef m As Message)
        ' Intercept all Windows messages prior to system handling;
        '  Look for events of interest
        Select Case (m.Msg)

            Case WM_LBUTTONUP, WM_RBUTTONUP, WM_MBUTTONUP ' Button up messages

                If (mWhatsThisHelp = True) Then
                    ' Process the What's This Help request
                    mWhatsThisHelp = WhatsThisHelp(m, Me)

                    If (mWhatsThisHelp) Then
                        PauseWhatsThisHelp(Me)
                    Else
                        StopWhatsThisHelp(Me)
                    End If

                    ' Absorb this event; don't let system process it
                    Return
                End If

        End Select
        '
        ' Call base class method to continue Windows message processing
        '
        MyBase.WndProc(m)

    End Sub
    '
    ' Access to general help features
    '
    Private Sub AboutWinSrfrItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AboutWinSrfrItem.Click
        Dim _dialogBox As HelpAbout = New HelpAbout
        _dialogBox.ShowDialog()
    End Sub
    '
    ' PDF Manual based Help
    '
    ' ShowPdfHelpManual()       - show help for modeless forms
    ' ShowDialogPdfHelpManual() - show help for modal dialogs
    '
    Friend Sub ShowPdfHelpManual(Optional ByVal Destination As String = "",
                                 Optional ByVal Offset As Single = 0)
        Try
            Dim viewerUp As Boolean = False
            Dim viewerLoc As Point = New Point(0, 0)
            Dim viewerHgt As Single = 0
            Dim viewerWid As Single = 0

            If (PdfDialogViewerDb IsNot Nothing) Then ' Dialog help viewer is up

                Debug.Assert(PdfViewerDb Is Nothing)

                ' Save dialog viewer's location & size
                viewerUp = True
                viewerLoc = PdfDialogViewerDb.DesktopLocation
                viewerHgt = PdfDialogViewerDb.Height
                viewerWid = PdfDialogViewerDb.Width

                ' Hide / delete dialog viewer
                PdfDialogViewerDb.Hide()
                PdfDialogViewerDb.Dispose()
                PdfDialogViewerDb = Nothing
            End If

            ' Instantiate form viewer, if neccessary
            If (PdfViewerDb Is Nothing) Then
                PdfViewerDb = New PdfViewerDialog With {
                .Text = "WinSRFR User Manual",
                .Height = Me.Height,
                .Width = Me.Width
                }
                'PdfViewerDb.PdfViewer.LoadFile(PdfFilePath)
                PdfViewerDb.PdfViewer.src = PdfFilePath
                PdfViewerDb.PdfViewer.gotoFirstPage()
            End If

            ' If dialog viewer was up, size & locate new form viewer to match
            If (viewerUp) Then
                PdfViewerDb.StartPosition = FormStartPosition.Manual
                PdfViewerDb.DesktopLocation = viewerLoc
                PdfViewerDb.Height = viewerHgt
                PdfViewerDb.Width = viewerWid
            End If

            If (Destination IsNot Nothing) Then
                If (Destination = "") Then
                    PdfViewerDb.PdfViewer.gotoFirstPage()
                Else
                    PdfViewerDb.PdfViewer.setNamedDest(Destination)
                End If
            Else
                PdfViewerDb.PdfViewer.gotoFirstPage()
            End If

            PdfViewerDb.PdfViewer.setPageMode("none")
            PdfViewerDb.PdfViewer.setViewScroll("FITH", Offset)
            PdfViewerDb.Show() ' as modeless form
            PdfViewerDb.BringToFront()
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Friend Sub ShowDialogPdfHelpManual(Optional ByVal Destination As String = "",
                                       Optional ByVal Offset As Single = 0)
        Try
            Dim viewerUp As Boolean = False
            Dim viewerLoc As Point = New Point(0, 0)
            Dim viewerHgt As Single = 0
            Dim viewerWid As Single = 0

            If (PdfViewerDb IsNot Nothing) Then ' PDF form viewer is up

                Debug.Assert(PdfDialogViewerDb Is Nothing)

                ' Save form viewer's location & size
                viewerUp = True
                viewerLoc = PdfViewerDb.DesktopLocation
                viewerHgt = PdfViewerDb.Height
                viewerWid = PdfViewerDb.Width

                ' Hide / delete form viewer
                PdfViewerDb.Hide()
                PdfViewerDb.Dispose()
                PdfViewerDb = Nothing

            ElseIf (PdfDialogViewerDb IsNot Nothing) Then ' PDF dialog viewer is up

                ' Save dialog viewer's location & size
                viewerUp = True
                viewerLoc = PdfDialogViewerDb.DesktopLocation
                viewerHgt = PdfDialogViewerDb.Height
                viewerWid = PdfDialogViewerDb.Width

                ' Hide / delete dialog viewer
                PdfDialogViewerDb.Hide()
                PdfDialogViewerDb.Dispose()
                PdfDialogViewerDb = Nothing
            End If

            ' Instantiate new dialog viewer
            PdfDialogViewerDb = New PdfViewerDialog With {
                .Text = "WinSRFR User Manual",
                .Height = Me.Height,
                .Width = Me.Width
                }

            'PdfDialogViewerDb.PdfViewer.LoadFile(PdfFilePath)
            PdfDialogViewerDb.PdfViewer.src = PdfFilePath
            PdfDialogViewerDb.PdfViewer.setPageMode("none")

            ' If either viewer was up, size & locate new dialog viewer to match
            If (viewerUp) Then
                PdfDialogViewerDb.StartPosition = FormStartPosition.Manual
                PdfDialogViewerDb.DesktopLocation = viewerLoc
                PdfDialogViewerDb.Height = viewerHgt
                PdfDialogViewerDb.Width = viewerWid
            End If

            If (Destination IsNot Nothing) Then
                If (Destination = "") Then
                    PdfDialogViewerDb.PdfViewer.gotoFirstPage()
                Else
                    PdfDialogViewerDb.PdfViewer.setNamedDest(Destination)
                    PdfDialogViewerDb.PdfViewer.setViewScroll("FITH", Offset)
                End If
            Else
                PdfDialogViewerDb.PdfViewer.gotoFirstPage()
            End If

            PdfDialogViewerDb.PdfViewer.Update()
            PdfDialogViewerDb.Show()
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub ViewPdfManualItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewPdfManualItem.Click
        ViewPdfManual()
    End Sub
    '
    ' Access to top-level manual sections
    '
    Private Sub HelpWelcomeToWinSrfrItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles HelpWelcomeToWinSrfrItem.Click
        ShowPdfHelpManual("ch:Welcome")
    End Sub

    Private Sub HelpOnHelptem_Click(sender As Object, e As EventArgs) _
        Handles HelpOnHelptem.Click
        'ShowPdfHelpManual("sec:Help")
        ShowPdfHelpManual("sec:HelpAndMessaging")
    End Sub

    Private Sub HelpNotationItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles HelpNotationItem.Click
        ShowPdfHelpManual("sec:Notation")
    End Sub
    '
    ' Basics
    '
    Private Sub HelpFunctionalityItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles HelpFunctionalityItem.Click
        ShowPdfHelpManual("ch:Functionality")
    End Sub

    Private Sub HelpScenariosItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles HelpProjectsScenariorItem.Click
        ShowPdfHelpManual("ch:CreatingProjects")
    End Sub

    Private Sub HelpGuiItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles HelpGuiItem.Click
        ShowPdfHelpManual("ch:UserInterface")
    End Sub
    '
    ' Working with Scenarios
    '
    Private Sub BasicIrrigationPropertiesItem_Click(sender As Object, e As EventArgs) _
        Handles BasicIrrigationPropertiesItem.Click
        ShowPdfHelpManual("ch:BasicProperties")
    End Sub

    Private Sub HelpSimulationItem_Click(sender As Object, e As EventArgs) _
        Handles HelpSimulationItem.Click
        ShowPdfHelpManual("ch:HydraulicSimulation")
    End Sub

    Private Sub HelpEvaluationItem_Click(sender As Object, e As EventArgs) _
        Handles HelpEvaluationItem.Click
        ShowPdfHelpManual("ch:Evaluation")
    End Sub

    Private Sub HelpOperationsItem_Click(sender As Object, e As EventArgs) _
        Handles HelpOperationsItem.Click
        ShowPdfHelpManual("ch:Operations")
    End Sub

    Private Sub HelpDesignItem_Click(sender As Object, e As EventArgs) _
        Handles HelpDesignItem.Click
        ShowPdfHelpManual("ch:Design")
    End Sub
    '
    ' F1 Help
    '
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            ShowPdfHelpManual("sec:ProjectManagementWindow")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#Region " Programmer Menu "

    Private mSaveTranslationAsBinItem As MenuItem = Nothing
    Private Sub ProgrammerMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ProgrammerMenu.Popup

        ' If appropriate, add "Save Translation as Bin" menu item
        If ((DebuggerIsAttached) And (mSaveTranslationAsBinItem Is Nothing)) Then
            mSaveTranslationAsBinItem = Me.ProgrammerMenu.MenuItems.Add(mDictionary.tSaveTranslationAsBin.Translated,
                                                                        AddressOf SaveTranslationAsBinItem_Click)
        End If
    End Sub

    Private Sub ShowDataStoreExplorerItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowDataStoreExplorerItem.Click
        ' Verify explorer form has been created; then hide/show it
        If (DataStoreExplorer IsNot Nothing) Then
            If (DataStoreExplorer.Visible) Then
                DataStoreExplorer.BringToFront()
            Else
                DataStoreExplorer.Show()
            End If

            DataStoreExplorer.DisplayObjectNode(MyStore)
        End If
    End Sub

    Private Sub ShowClipboardViewerItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowClipboardViewerItem.Click
        Dim cv As ClipboardViewer = New ClipboardViewer
        cv.ShowDialog()
    End Sub

    Private Sub SaveTranslationAsBinItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles SaveTranslationAsBinItem.Click

        Dim languagePath As String = Application.CommonAppDataPath + "\Languages"
        Dim nativeLanguage As String = mDictionary.NativeLanguage

        Try
            mDictionary.NativeLanguage = sNativeFamily & "." & "text".Replace("e", "")
            mDictionary.SaveForeignLanuage(languagePath, "")
        Catch ex As Exception

        Finally
            mDictionary.NativeLanguage = nativeLanguage
        End Try

        'mDictionary.OpenForeignLanguage(Path & "\" & Dictionary.ForeignLanguage & ".bin")
    End Sub

#End Region

#Region " Toolbar Buttons "

    Private Sub MainToolBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) _
    Handles MainToolBar.ButtonClick

        Select Case MainToolBar.Buttons.IndexOf(e.Button)
            Case 0 ' New Project
                NewProject(True)
            Case 1 ' Open Project
                OpenProject(True)
            Case 2 ' Save Project
                Save()

            Case 3 ' Separator
                Debug.Assert(False, "Separator being used as button")

            Case 4 ' Undo
                Undo()
            Case 5 ' Redo
                Redo()

            Case 6 ' Separator
                Debug.Assert(False, "Separator being used as button")

            Case 7 ' What's This Help
                mWhatsThisHelp = True
                StartWhatsThisHelp(Me)

            Case Else
                Debug.Assert(False, "Invalid toolbar button")

        End Select
    End Sub

#End Region

#Region " World Buttons "
    '
    ' DisplayWorld()
    '
    ' Desc: What Unit gets displayed depends on the existence of an appropriate Unit:
    '
    '   1) If the World Window is already up; display it
    '
    '   2) If only one Unit exists for the World; display it
    '
    '   3) If more than one Unit exists for the World; have user use Analysis Explorer
    '
    '   4) Create a Farm / Field / World / Analysis as needed
    '
    Private Sub DisplayWorld(ByVal _worldType As WorldTypes)

        ' 1) If the World Window is already up; display it
        Select Case (_worldType)

            Case Globals.WorldTypes.DesignWorld
                If (mDesignWorld.Visible) Then
                    ShowUnit(mDesignWorld.DisplayedUnit)
                    Return
                End If

            Case Globals.WorldTypes.EventWorld
                If (mEvaluationWorld.Visible) Then
                    ShowUnit(mEvaluationWorld.DisplayedUnit)
                    Return
                End If

            Case Globals.WorldTypes.OperationsWorld
                If (mOperationsWorld.Visible) Then
                    ShowUnit(mOperationsWorld.DisplayedUnit)
                    Return
                End If

            Case Else ' Assume Globals.WorldTypes.SimulationWorld
                If (mSimulationWorld.Visible) Then
                    ShowUnit(mSimulationWorld.DisplayedUnit)
                    Return
                End If

        End Select

        ' 2) If only one Unit exists for the World; display it
        Dim _count As Integer = UnitCount(_worldType)

        If (1 = _count) Then
            Dim _unit As Unit = GetFirstUnit(_worldType)
            ShowUnit(_unit)
            Return
        End If

        ' 3) If more than one Unit exists for the World; have user use Analysis Explorer
        If (1 < _count) Then
            Dim _msg As String = String.Format("Use the Analysis Explorer to select which" + Chr(13) _
                                            + "Analysis or Simulation to display.")
            Dim _title As String = "WinSRFR Worlds - Too many choices"
            Dim _style As MsgBoxStyle = MsgBoxStyle.OkOnly Or MsgBoxStyle.Information
            MsgBox(_msg, _style, _title)
            Return
        End If

        ' 4) Select or add a Farm / Field / World / Analysis as needed

        ' Select / add Farm
        Dim _farm As Farm = SelectedFarm
        If (_farm Is Nothing) Then
            _farm = Me.GetFirstFarm
        End If
        If (_farm Is Nothing) Then
            _farm = AddFarm()
        End If

        ' Select / add Field
        Dim _field As Field = SelectedField
        If (_field Is Nothing) Then
            _field = _farm.GetFirstField
        End If
        If (_field Is Nothing) Then
            _field = AddField(_farm)
        End If

        ' Select / add World Folder
        Dim _world As World = SelectedWorld
        If Not (_world Is Nothing) Then
            If Not (_world.WorldType.Value = _worldType) Then
                ' World is not the right type
                _world = Nothing
            End If
        End If
        If (_world Is Nothing) Then
            _world = _field.GetFirstWorld(_worldType)
        End If
        If (_world Is Nothing) Then
            _world = AddWorld(_field, _worldType)
        End If

        ' Select / add Analysis
        Dim _analysis As Unit = SelectedAnalysis
        If Not (_analysis Is Nothing) Then
            If Not (_analysis.UnitType.Value = _worldType) Then
                ' Analysis is not the right type
                _analysis = Nothing
            End If
        End If
        If (_analysis Is Nothing) Then
            _analysis = _world.GetFirstAnalysis
        End If
        If (_analysis Is Nothing) Then
            _analysis = AddAnalysis(_world)
        End If

        ' Make these the selected items
        SelectedFarm = _farm
        SelectedField = _field
        SelectedWorld = _world
        SelectedAnalysis = _analysis

        ' Display the Analysis
        ShowUnit(_analysis)
        Return

    End Sub
    '
    ' Event Button
    '
    Private Sub EventButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EventButton.Click
        DisplayWorld(WorldTypes.EventWorld)
    End Sub

    Private Sub EventButton_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EventButton.Enter
        StatusMessage = EventButton.AccessibleDescription
    End Sub
    '
    ' Design Button
    '
    Private Sub DesignButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DesignButton.Click
        DisplayWorld(WorldTypes.DesignWorld)
    End Sub

    Private Sub DesignButton_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DesignButton.Enter
        StatusMessage = DesignButton.AccessibleDescription
    End Sub
    '
    ' Operations Button
    '
    Private Sub OperationsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OperationsButton.Click
        DisplayWorld(WorldTypes.OperationsWorld)
    End Sub

    Private Sub OperationsButton_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OperationsButton.Enter
        StatusMessage = OperationsButton.AccessibleDescription
    End Sub
    '
    ' Simulation Button
    '
    Private Sub SimulationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SimulationButton.Click
        DisplayWorld(WorldTypes.SimulationWorld)
    End Sub

    Private Sub SimulationButton_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SimulationButton.Enter
        StatusMessage = SimulationButton.AccessibleDescription
    End Sub

#End Region

#Region " Other Events "

    Private Sub TitleBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TitleBox.Enter
        TitleBox.SelectAll()
        StatusMessage = TitleBox.AccessibleDescription
    End Sub

    Private Sub WinSrfrFunctionsPanel_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WinSrfrFunctionsPanel.Resize
        Dim logoLoc As Point = Me.USDA_ARS_Logo.Location
        logoLoc.Y = WinSrfrFunctionsPanel.Height - Me.USDA_ARS_Logo.Height - 8

        If (logoLoc.Y > Me.ButtonInstructions.Location.Y + Me.ButtonInstructions.Height + 8) Then
            Me.USDA_ARS_Logo.Location = logoLoc

            logoLoc = Me.ALARC_Logo.Location
            logoLoc.Y = WinSrfrFunctionsPanel.Height - Me.ALARC_Logo.Height - 8
            Me.ALARC_Logo.Location = logoLoc
        End If

    End Sub

#End Region

#End Region

End Class
