
'**********************************************************************************************
' Simulation - Top-level form (Window) for WinSRFR's Simulation World.
'
Imports DataStore
Imports DataStore.DataStore

Public Class SimulationWorld
    Inherits WorldWindow

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' Change name of World Menu
        For Each item As MenuItem In Me.Menu.MenuItems
            If (item.Text = "&World") Then
                item.Text = "&Simulation"
            End If
        Next
    End Sub

    Public Sub New(ByVal _winSRFR As WinSRFR)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            InitializeSimulationWindow(_winSRFR)
        Catch ex As Exception
            _winSRFR.CriticalException("InitializeSimulationWindow()", ex)
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
    Friend WithEvents SimulationTabControl As DataStore.ctl_TabControl
    Friend WithEvents SystemGeometryTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SoilCropPropertiesTabPage As System.Windows.Forms.TabPage
    Friend WithEvents InflowManagementTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SimulationMainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents ExViewMenu As System.Windows.Forms.MenuItem
    Friend WithEvents ExWorldMenu As System.Windows.Forms.MenuItem
    Friend WithEvents RunSimulationItem As System.Windows.Forms.MenuItem
    Friend WithEvents RunMultipleSimulationsItem As System.Windows.Forms.MenuItem
    Friend WithEvents SimSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents StandardCriteriaItem As System.Windows.Forms.MenuItem
    Friend WithEvents ExHelpMenu As System.Windows.Forms.MenuItem
    Friend WithEvents AboutSimulationItem As System.Windows.Forms.MenuItem
    Friend WithEvents ExecutionTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ResultsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ViewSimulationAnimationItem As System.Windows.Forms.MenuItem
    Friend WithEvents SimSeparator2 As System.Windows.Forms.MenuItem
    Friend WithEvents SimulationTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SystemGeometryControl As WinMain.ctl_SystemGeometry
    Friend WithEvents SoilCropPropertiesControl As WinMain.ctl_SoilCropProperties
    Friend WithEvents InflowManagementControl As WinMain.ctl_InflowManagement
    Friend WithEvents DataSummaryControl As WinMain.ctl_DataSummary
    Friend WithEvents SimulationResultsControl As WinMain.ctl_SimulationResults
    Friend WithEvents DataTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ErosionControl As WinMain.ctl_Erosion
    Friend WithEvents FertigationControl As WinMain.ctl_Fertigation
    Friend WithEvents SimulationWorldControl As WinMain.ctl_SimulationWorld
    Friend WithEvents AdvancedCriteriaItem As System.Windows.Forms.MenuItem
    Friend WithEvents SimulationHelpSeparator1 As MenuItem
    Friend WithEvents HelpSystemGeometryItem As MenuItem
    Friend WithEvents HelpStartItem As MenuItem
    Friend WithEvents HelpRoughnessItem As MenuItem
    Friend WithEvents HelpInfiltrationItem As MenuItem
    Friend WithEvents HelpInflowRunoffItem As MenuItem
    Friend WithEvents HelpExecutionItem As MenuItem
    Friend WithEvents HelpResultsItem As MenuItem
    Friend WithEvents SimulationExecutionControl As WinMain.ctl_SimulationExecution
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimulationWorld))
        Me.SimulationTabControl = New DataStore.ctl_TabControl()
        Me.SimulationTabPage = New System.Windows.Forms.TabPage()
        Me.SimulationWorldControl = New WinMain.ctl_SimulationWorld()
        Me.SystemGeometryTabPage = New System.Windows.Forms.TabPage()
        Me.SystemGeometryControl = New WinMain.ctl_SystemGeometry()
        Me.SoilCropPropertiesTabPage = New System.Windows.Forms.TabPage()
        Me.SoilCropPropertiesControl = New WinMain.ctl_SoilCropProperties()
        Me.InflowManagementTabPage = New System.Windows.Forms.TabPage()
        Me.InflowManagementControl = New WinMain.ctl_InflowManagement()
        Me.DataTabPage = New System.Windows.Forms.TabPage()
        Me.ErosionControl = New WinMain.ctl_Erosion()
        Me.FertigationControl = New WinMain.ctl_Fertigation()
        Me.DataSummaryControl = New WinMain.ctl_DataSummary()
        Me.ExecutionTabPage = New System.Windows.Forms.TabPage()
        Me.SimulationExecutionControl = New WinMain.ctl_SimulationExecution()
        Me.ResultsTabPage = New System.Windows.Forms.TabPage()
        Me.SimulationResultsControl = New WinMain.ctl_SimulationResults()
        Me.SimulationMainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.ExViewMenu = New System.Windows.Forms.MenuItem()
        Me.ExWorldMenu = New System.Windows.Forms.MenuItem()
        Me.RunSimulationItem = New System.Windows.Forms.MenuItem()
        Me.RunMultipleSimulationsItem = New System.Windows.Forms.MenuItem()
        Me.SimSeparator1 = New System.Windows.Forms.MenuItem()
        Me.ViewSimulationAnimationItem = New System.Windows.Forms.MenuItem()
        Me.SimSeparator2 = New System.Windows.Forms.MenuItem()
        Me.StandardCriteriaItem = New System.Windows.Forms.MenuItem()
        Me.AdvancedCriteriaItem = New System.Windows.Forms.MenuItem()
        Me.ExHelpMenu = New System.Windows.Forms.MenuItem()
        Me.AboutSimulationItem = New System.Windows.Forms.MenuItem()
        Me.SimulationHelpSeparator1 = New System.Windows.Forms.MenuItem()
        Me.HelpStartItem = New System.Windows.Forms.MenuItem()
        Me.HelpSystemGeometryItem = New System.Windows.Forms.MenuItem()
        Me.HelpRoughnessItem = New System.Windows.Forms.MenuItem()
        Me.HelpInfiltrationItem = New System.Windows.Forms.MenuItem()
        Me.HelpInflowRunoffItem = New System.Windows.Forms.MenuItem()
        Me.HelpExecutionItem = New System.Windows.Forms.MenuItem()
        Me.HelpResultsItem = New System.Windows.Forms.MenuItem()
        Me.WorldPanel.SuspendLayout()
        Me.SimulationTabControl.SuspendLayout()
        Me.SimulationTabPage.SuspendLayout()
        Me.SystemGeometryTabPage.SuspendLayout()
        Me.SoilCropPropertiesTabPage.SuspendLayout()
        Me.InflowManagementTabPage.SuspendLayout()
        Me.DataTabPage.SuspendLayout()
        Me.ExecutionTabPage.SuspendLayout()
        Me.ResultsTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleBox
        '
        Me.TitleBox.Location = New System.Drawing.Point(0, 28)
        '
        'WorldPanel
        '
        Me.WorldPanel.Controls.Add(Me.SimulationTabControl)
        Me.WorldPanel.Location = New System.Drawing.Point(0, 68)
        Me.WorldPanel.Size = New System.Drawing.Size(792, 463)
        '
        'WorldToolbar
        '
        Me.WorldToolbar.Size = New System.Drawing.Size(792, 28)
        '
        'FileMenu
        '
        '
        'WorldMenu
        '
        '
        'mProgressBar
        '
        Me.mProgressBar.Location = New System.Drawing.Point(550, 3)
        Me.mProgressBar.Size = New System.Drawing.Size(69, 18)
        '
        'SimulationTabControl
        '
        Me.SimulationTabControl.AccessibleDescription = "Provides access to WinSRFR's simulation functions"
        Me.SimulationTabControl.AccessibleName = "Simulation World Window"
        Me.SimulationTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.SimulationTabControl.Controls.Add(Me.SimulationTabPage)
        Me.SimulationTabControl.Controls.Add(Me.SystemGeometryTabPage)
        Me.SimulationTabControl.Controls.Add(Me.SoilCropPropertiesTabPage)
        Me.SimulationTabControl.Controls.Add(Me.InflowManagementTabPage)
        Me.SimulationTabControl.Controls.Add(Me.DataTabPage)
        Me.SimulationTabControl.Controls.Add(Me.ExecutionTabPage)
        Me.SimulationTabControl.Controls.Add(Me.ResultsTabPage)
        Me.SimulationTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimulationTabControl.Location = New System.Drawing.Point(0, 0)
        Me.SimulationTabControl.Name = "SimulationTabControl"
        Me.SimulationTabControl.SelectedIndex = 0
        Me.SimulationTabControl.Size = New System.Drawing.Size(792, 463)
        Me.SimulationTabControl.TabIndex = 0
        '
        'SimulationTabPage
        '
        Me.SimulationTabPage.AccessibleDescription = "Simulation criteria for the field"
        Me.SimulationTabPage.AccessibleName = "Simulation World Tab"
        Me.SimulationTabPage.Controls.Add(Me.SimulationWorldControl)
        Me.SimulationTabPage.Location = New System.Drawing.Point(4, 4)
        Me.SimulationTabPage.Name = "SimulationTabPage"
        Me.SimulationTabPage.Size = New System.Drawing.Size(784, 434)
        Me.SimulationTabPage.TabIndex = 7
        Me.SimulationTabPage.Text = "Start Simulation"
        '
        'SimulationWorldControl
        '
        Me.SimulationWorldControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimulationWorldControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimulationWorldControl.Location = New System.Drawing.Point(0, 0)
        Me.SimulationWorldControl.Name = "SimulationWorldControl"
        Me.SimulationWorldControl.Size = New System.Drawing.Size(784, 434)
        Me.SimulationWorldControl.TabIndex = 0
        '
        'SystemGeometryTabPage
        '
        Me.SystemGeometryTabPage.AccessibleDescription = "Geometric parameters for the field being simulated"
        Me.SystemGeometryTabPage.AccessibleName = "System Geometry Tab"
        Me.SystemGeometryTabPage.Controls.Add(Me.SystemGeometryControl)
        Me.SystemGeometryTabPage.Location = New System.Drawing.Point(4, 4)
        Me.SystemGeometryTabPage.Name = "SystemGeometryTabPage"
        Me.SystemGeometryTabPage.Size = New System.Drawing.Size(784, 433)
        Me.SystemGeometryTabPage.TabIndex = 1
        Me.SystemGeometryTabPage.Text = "System Geometry"
        '
        'SystemGeometryControl
        '
        Me.SystemGeometryControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemGeometryControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemGeometryControl.Location = New System.Drawing.Point(0, 0)
        Me.SystemGeometryControl.Name = "SystemGeometryControl"
        Me.SystemGeometryControl.Size = New System.Drawing.Size(784, 433)
        Me.SystemGeometryControl.TabIndex = 0
        '
        'SoilCropPropertiesTabPage
        '
        Me.SoilCropPropertiesTabPage.AccessibleDescription = "Roughness and infiltration parameters for the field being simulated"
        Me.SoilCropPropertiesTabPage.AccessibleName = "Soil / Crop Properties Tab"
        Me.SoilCropPropertiesTabPage.Controls.Add(Me.SoilCropPropertiesControl)
        Me.SoilCropPropertiesTabPage.Location = New System.Drawing.Point(4, 4)
        Me.SoilCropPropertiesTabPage.Name = "SoilCropPropertiesTabPage"
        Me.SoilCropPropertiesTabPage.Size = New System.Drawing.Size(784, 433)
        Me.SoilCropPropertiesTabPage.TabIndex = 2
        Me.SoilCropPropertiesTabPage.Text = "Soil / Crop Properties"
        '
        'SoilCropPropertiesControl
        '
        Me.SoilCropPropertiesControl.AccessibleDescription = "Roughness and Infiltration parameter input."
        Me.SoilCropPropertiesControl.AccessibleName = "Soil / Crop Properties"
        Me.SoilCropPropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SoilCropPropertiesControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoilCropPropertiesControl.Location = New System.Drawing.Point(0, 0)
        Me.SoilCropPropertiesControl.Name = "SoilCropPropertiesControl"
        Me.SoilCropPropertiesControl.Size = New System.Drawing.Size(784, 433)
        Me.SoilCropPropertiesControl.TabIndex = 0
        '
        'InflowManagementTabPage
        '
        Me.InflowManagementTabPage.AccessibleDescription = "Inflow parameters for the field being simulated"
        Me.InflowManagementTabPage.AccessibleName = "Inflow / Runoff Tab"
        Me.InflowManagementTabPage.Controls.Add(Me.InflowManagementControl)
        Me.InflowManagementTabPage.Location = New System.Drawing.Point(4, 4)
        Me.InflowManagementTabPage.Name = "InflowManagementTabPage"
        Me.InflowManagementTabPage.Size = New System.Drawing.Size(784, 433)
        Me.InflowManagementTabPage.TabIndex = 3
        Me.InflowManagementTabPage.Text = "Inflow / Runoff"
        '
        'InflowManagementControl
        '
        Me.InflowManagementControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InflowManagementControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowManagementControl.Location = New System.Drawing.Point(0, 0)
        Me.InflowManagementControl.Name = "InflowManagementControl"
        Me.InflowManagementControl.Size = New System.Drawing.Size(784, 433)
        Me.InflowManagementControl.TabIndex = 0
        Me.InflowManagementControl.Title = "Inflow / Runoff"
        '
        'DataTabPage
        '
        Me.DataTabPage.AccessibleDescription = "Summary of the irrigation field data; see previous tabs for more details"
        Me.DataTabPage.AccessibleName = "Data Summary Tab"
        Me.DataTabPage.Controls.Add(Me.ErosionControl)
        Me.DataTabPage.Controls.Add(Me.FertigationControl)
        Me.DataTabPage.Controls.Add(Me.DataSummaryControl)
        Me.DataTabPage.Location = New System.Drawing.Point(4, 4)
        Me.DataTabPage.Name = "DataTabPage"
        Me.DataTabPage.Size = New System.Drawing.Size(784, 433)
        Me.DataTabPage.TabIndex = 4
        Me.DataTabPage.Text = "Data"
        '
        'ErosionControl
        '
        Me.ErosionControl.AccessibleDescription = "Controls for specifying erosion parameters."
        Me.ErosionControl.AccessibleName = "Erosion"
        Me.ErosionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErosionControl.Location = New System.Drawing.Point(0, 0)
        Me.ErosionControl.Name = "ErosionControl"
        Me.ErosionControl.Size = New System.Drawing.Size(780, 430)
        Me.ErosionControl.TabIndex = 1
        '
        'FertigationControl
        '
        Me.FertigationControl.AccessibleDescription = "Specifies how the fertigation solute is injected into the irrigation water."
        Me.FertigationControl.AccessibleName = "Fertigation Injection"
        Me.FertigationControl.AutoScroll = True
        Me.FertigationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FertigationControl.Location = New System.Drawing.Point(0, 0)
        Me.FertigationControl.Margin = New System.Windows.Forms.Padding(4)
        Me.FertigationControl.Name = "FertigationControl"
        Me.FertigationControl.Size = New System.Drawing.Size(780, 430)
        Me.FertigationControl.TabIndex = 1
        '
        'DataSummaryControl
        '
        Me.DataSummaryControl.AccessibleDescription = "Summary access to the major user inputs for a Simulation."
        Me.DataSummaryControl.AccessibleName = "Data Summary"
        Me.DataSummaryControl.AutoScroll = True
        Me.DataSummaryControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataSummaryControl.Location = New System.Drawing.Point(0, 0)
        Me.DataSummaryControl.Name = "DataSummaryControl"
        Me.DataSummaryControl.Size = New System.Drawing.Size(780, 430)
        Me.DataSummaryControl.TabIndex = 0
        '
        'ExecutionTabPage
        '
        Me.ExecutionTabPage.AccessibleDescription = "Execution parameters for the irrigation being simulated"
        Me.ExecutionTabPage.AccessibleName = "Simulation Execution Tab"
        Me.ExecutionTabPage.Controls.Add(Me.SimulationExecutionControl)
        Me.ExecutionTabPage.Location = New System.Drawing.Point(4, 4)
        Me.ExecutionTabPage.Name = "ExecutionTabPage"
        Me.ExecutionTabPage.Size = New System.Drawing.Size(784, 433)
        Me.ExecutionTabPage.TabIndex = 5
        Me.ExecutionTabPage.Text = "Execution"
        '
        'SimulationExecutionControl
        '
        Me.SimulationExecutionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimulationExecutionControl.Location = New System.Drawing.Point(0, 0)
        Me.SimulationExecutionControl.Name = "SimulationExecutionControl"
        Me.SimulationExecutionControl.Size = New System.Drawing.Size(780, 430)
        Me.SimulationExecutionControl.TabIndex = 0
        '
        'ResultsTabPage
        '
        Me.ResultsTabPage.AccessibleDescription = "Displays the simulation results for the field"
        Me.ResultsTabPage.AccessibleName = "Simulation Results Tab"
        Me.ResultsTabPage.Controls.Add(Me.SimulationResultsControl)
        Me.ResultsTabPage.Location = New System.Drawing.Point(4, 4)
        Me.ResultsTabPage.Name = "ResultsTabPage"
        Me.ResultsTabPage.Size = New System.Drawing.Size(784, 433)
        Me.ResultsTabPage.TabIndex = 6
        Me.ResultsTabPage.Text = "Results"
        '
        'SimulationResultsControl
        '
        Me.SimulationResultsControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimulationResultsControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.SimulationResultsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimulationResultsControl.Location = New System.Drawing.Point(0, 0)
        Me.SimulationResultsControl.Multiline = True
        Me.SimulationResultsControl.Name = "SimulationResultsControl"
        Me.SimulationResultsControl.ResultsView = WinMain.Globals.ResultsViews.PortraitPage
        Me.SimulationResultsControl.SelectedIndex = 0
        Me.SimulationResultsControl.Size = New System.Drawing.Size(784, 433)
        Me.SimulationResultsControl.TabIndex = 0
        '
        'SimulationMainMenu
        '
        Me.SimulationMainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ExViewMenu, Me.ExWorldMenu, Me.ExHelpMenu})
        '
        'ExViewMenu
        '
        Me.ExViewMenu.Index = 0
        Me.ExViewMenu.Text = "&View"
        '
        'ExWorldMenu
        '
        Me.ExWorldMenu.Index = 1
        Me.ExWorldMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.RunSimulationItem, Me.RunMultipleSimulationsItem, Me.SimSeparator1, Me.ViewSimulationAnimationItem, Me.SimSeparator2, Me.StandardCriteriaItem, Me.AdvancedCriteriaItem})
        Me.ExWorldMenu.Text = "&World"
        '
        'RunSimulationItem
        '
        Me.RunSimulationItem.Index = 0
        Me.RunSimulationItem.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.RunSimulationItem.Text = "&Run Simulation"
        '
        'RunMultipleSimulationsItem
        '
        Me.RunMultipleSimulationsItem.Index = 1
        Me.RunMultipleSimulationsItem.Text = "Run &Multiple Simulations ..."
        '
        'SimSeparator1
        '
        Me.SimSeparator1.Index = 2
        Me.SimSeparator1.Text = "-"
        '
        'ViewSimulationAnimationItem
        '
        Me.ViewSimulationAnimationItem.Index = 3
        Me.ViewSimulationAnimationItem.Text = "View Simulation &Animation Window"
        '
        'SimSeparator2
        '
        Me.SimSeparator2.Index = 4
        Me.SimSeparator2.Text = "-"
        '
        'StandardCriteriaItem
        '
        Me.StandardCriteriaItem.Index = 5
        Me.StandardCriteriaItem.Text = "&Graphics ..."
        '
        'AdvancedCriteriaItem
        '
        Me.AdvancedCriteriaItem.Index = 6
        Me.AdvancedCriteriaItem.Text = "&Cell Density ..."
        '
        'ExHelpMenu
        '
        Me.ExHelpMenu.Index = 2
        Me.ExHelpMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.AboutSimulationItem, Me.SimulationHelpSeparator1, Me.HelpStartItem, Me.HelpSystemGeometryItem, Me.HelpRoughnessItem, Me.HelpInfiltrationItem, Me.HelpInflowRunoffItem, Me.HelpExecutionItem, Me.HelpResultsItem})
        Me.ExHelpMenu.Text = "&Help"
        '
        'AboutSimulationItem
        '
        Me.AboutSimulationItem.Index = 0
        Me.AboutSimulationItem.Text = "Simulation &Overview"
        '
        'SimulationHelpSeparator1
        '
        Me.SimulationHelpSeparator1.Index = 1
        Me.SimulationHelpSeparator1.Text = "-"
        '
        'HelpStartItem
        '
        Me.HelpStartItem.Index = 2
        Me.HelpStartItem.Text = "&Start"
        '
        'HelpSystemGeometryItem
        '
        Me.HelpSystemGeometryItem.Index = 3
        Me.HelpSystemGeometryItem.Text = "System &Geometry"
        '
        'HelpRoughnessItem
        '
        Me.HelpRoughnessItem.Index = 4
        Me.HelpRoughnessItem.Text = "&Roughness"
        '
        'HelpInfiltrationItem
        '
        Me.HelpInfiltrationItem.Index = 5
        Me.HelpInfiltrationItem.Text = "&Infiltration"
        '
        'HelpInflowRunoffItem
        '
        Me.HelpInflowRunoffItem.Index = 6
        Me.HelpInflowRunoffItem.Text = "I&nflow / Runoff"
        '
        'HelpExecutionItem
        '
        Me.HelpExecutionItem.Index = 7
        Me.HelpExecutionItem.Text = "&Execution"
        '
        'HelpResultsItem
        '
        Me.HelpResultsItem.Index = 8
        Me.HelpResultsItem.Text = "Resu&lts"
        '
        'SimulationWorld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(792, 553)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.SimulationMainMenu
        Me.Name = "SimulationWorld"
        Me.WorldPanel.ResumeLayout(False)
        Me.SimulationTabControl.ResumeLayout(False)
        Me.SimulationTabPage.ResumeLayout(False)
        Me.SystemGeometryTabPage.ResumeLayout(False)
        Me.SoilCropPropertiesTabPage.ResumeLayout(False)
        Me.InflowManagementTabPage.ResumeLayout(False)
        Me.DataTabPage.ResumeLayout(False)
        Me.ExecutionTabPage.ResumeLayout(False)
        Me.ResultsTabPage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Member Data "

    ' Resize data
    Private mMinSimulationWorldHeight As Integer
    Private mSimulationWorldHeight As Integer

    Private mMinErrorsAndWarnings As Integer

    Private mControlHeightsSaved As Boolean
    Private mLinkedToModel As Boolean

    ' UI Forms
    Private mRunMultiple As RunMultiSimulations

#End Region

#Region " Properties "
    '
    ' Override of property to implement Results View
    '
    Protected Overrides Property ResultsView() As ResultsViews
        Get
            Return SimulationResultsControl.ResultsView
        End Get
        Set(ByVal Value As ResultsViews)
            SimulationResultsControl.ResultsView = Value
        End Set
    End Property

    Private mDisplayResults As Boolean = True
    Friend Property DisplayResults() As Boolean
        Get
            Return mDisplayResults
        End Get
        Set(ByVal value As Boolean)
            mDisplayResults = value
        End Set
    End Property

#End Region

#Region " Initialization "
    '
    ' Called by New() to initialize the World Window
    '
    Private Sub InitializeSimulationWindow(ByVal _winSRFR As WinSRFR)
        MyBase.InitializeWorldWindow(_winSRFR)

        If (mWinSRFR IsNot Nothing) Then ' Change name of World Menu
            WorldMenu.Text = "&" & mDictionary.tSimulation.Translated
        Else
            Debug.Assert(False, "WinSRFR is Nothing")
        End If

    End Sub
    '
    ' Display the World Window for the specified Unit
    '
    Public Overrides Sub DisplayWorldWindow(ByVal _unit As Unit)
        MyBase.DisplayWorldWindow(_unit)

        ' Get Simulation World specific references
        mSrfrCriteria = mUnit.SrfrCriteriaRef

        ' Instantiate Analyses objects
        mAnalysis = New SrfrSimulation(mUnit, Me)

        ' Link the UI's of all contained controls to their model object(s)
        Me.SimulationWorldControl.LinkToModel(mUnit)
        Me.SystemGeometryControl.LinkToModel(mUnit, Me)
        Me.SoilCropPropertiesControl.LinkToModel(mUnit, Me)
        Me.InflowManagementControl.LinkToModel(mUnit, Me)
        Me.DataSummaryControl.LinkToModel(mUnit)
        Me.ErosionControl.LinkToModel(mUnit, Me, mAnalysis)
        Me.FertigationControl.LinkToModel(mUnit, Me)
        Me.SimulationResultsControl.LinkToModel(mUnit, Me)
        Me.SimulationExecutionControl.LinkToModel(mUnit, Me)

        ' Initialize the UI
        UpdateUI()

        ' Load Selected Tab Property with its Enumerations
        Dim selectedTab As PropertyNode = mUnitControl.SelectedTabProperty
        selectedTab.ClearEnums()
        For tdx As Integer = 0 To SimulationTabControl.TabPages.Count - 1
            Dim dispTab As TabPage = SimulationTabControl.TabPages(tdx)
            Dim tabName As String = dispTab.Text.Replace(" ", "")
            selectedTab.AddEnumItem(tabName, tdx, True)
        Next

        ' Display the previously selected tab
        SimulationTabControl.SelectedIndex = mUnit.UnitControlRef.SelectedTab.Value

        ' Update the results controls & tab page
        UpdateResultsControls()

        ' Set initial window size; Title bar adds 20 to height but is not included in Size
        If Not (mWindowSizeSet) Then
            mWindowSizeSet = True
            Select Case mWinSRFR.WindowSize
                Case WindowSizes.S800x600
                    Me.Size = New Size(800, 600 - 20)
                Case WindowSizes.S900x675
                    Me.Size = New Size(900, 675 - 20)
                Case WindowSizes.S949x768
                    Me.Size = New Size(949, 768 - 20)
                Case Else
                    Me.Size = New Size(1024, 768 - 20)
            End Select
            Me.MinimumSize = New Size(800, 600)
        End If

    End Sub

#End Region

#Region " Methods "

#Region " UI Methods "
    '
    ' Resize UI to fill available space
    '
    Private Sub ResizeUI()

        Me.SimulationWorldControl.Width = Me.SimulationTabPage.Width - Me.SimulationWorldControl.Location.X * 2
        Me.SimulationWorldControl.Height = Me.SimulationTabPage.Height - Me.SimulationWorldControl.Location.Y * 2

        'If (Me.ErosionControl IsNot Nothing) Then
        '    Me.ErosionControl.Height = Me.DataTabPage.Height - 10 ' - MyBase.Margin.Top - MyBase.Margin.Bottom
        'End If

        'If (Me.FertigationControl IsNot Nothing) Then
        '    Me.FertigationControl.Height = Me.DataTabPage.Height - 10 ' - MyBase.Margin.Top - MyBase.Margin.Bottom
        'End If

    End Sub
    '
    ' Update the Simulation World's UI
    '
    Public Overrides Sub UpdateUI()
        MyBase.UpdateUI()

        If (mUnit IsNot Nothing) Then

            ' Resize UI to fill available space
            ResizeUI()
            '
            ' Update the Window's title bar
            '
            Dim _title As String = WinSrfrName & " " & WinSRFR.Version & " - Simulation"
            Me.Text = _title
            '
            ' Set controls to their correct color
            '
            TitleBox.BackColor = mWinSRFR.SimulationBackColor
            TitleBox.ForeColor = mWinSRFR.SimulationForeColor
            '
            ' Update Design Controls
            '
            Me.SimulationWorldControl.UpdateUI()
            Me.SimulationExecutionControl.UpdateUI()
            '
            ' Display 'Data Summary' or 'Erosion' or 'Fertigation' tab page
            '
            If (mWinSRFR.UserLevel = Globals.UserLevels.Standard) Then
                ' Erosion / Fertigation not available for Standard user
                ErosionControl.Hide()
                FertigationControl.Hide()
                DataSummaryControl.Show()
                DataTabPage.Text = mDictionary.tDataSummary.Translated
                DataTabPage.AccessibleDescription = DataSummaryControl.AccessibleDescription
                DataTabPage.AccessibleName = DataSummaryControl.AccessibleName

            Else ' Advanced User

                If (mErosion.EnableErosion.Value) Then ' Erosion available for Advanced+ user
                    ' Erosion enabled; display its UI
                    DataSummaryControl.Hide()
                    FertigationControl.Hide()
                    ErosionControl.Show()
                    DataTabPage.Text = mDictionary.tErosion.Translated
                    DataTabPage.AccessibleDescription = ErosionControl.AccessibleDescription
                    DataTabPage.AccessibleName = ErosionControl.AccessibleName

                ElseIf (mFertigation.EnableFertigation.Value) Then ' Fertigation available for Advanced+ user
                    ' Fertigation enabled; display its UI
                    DataSummaryControl.Hide()
                    ErosionControl.Hide()
                    FertigationControl.Show()
                    DataTabPage.Text = mDictionary.tFertigation.Translated
                    DataTabPage.AccessibleDescription = FertigationControl.AccessibleDescription
                    DataTabPage.AccessibleName = FertigationControl.AccessibleName

                Else
                    ' Erosion & Fertigation disabled; display 'Data Summary'
                    ErosionControl.Hide()
                    FertigationControl.Hide()
                    DataSummaryControl.Show()
                    DataTabPage.Text = mDictionary.tDataSummary.Translated
                    DataTabPage.AccessibleDescription = DataSummaryControl.AccessibleDescription
                    DataTabPage.AccessibleName = DataSummaryControl.AccessibleName
                End If
            End If
        End If

    End Sub
    '
    ' Update the Results Control (Icons, Buttons, etc.)
    '
    Public Overrides Sub UpdateResultsControls()
        MyBase.UpdateResultsControls()

        If (mUnit IsNot Nothing) Then

            Me.SimulationExecutionControl.UpdateSimulationSetupErrorsWarnings(CurrentAnalysis)

            ' Set Results defaults
            Dim _resultsAreValid As Boolean = False

            If Not (CurrentAnalysis Is Nothing) Then
                If (CurrentAnalysis.HasSetupErrors) Then
                    ' There are errors; disable Run button
                    Me.SimulationExecutionControl.DisableRunButtons()
                Else
                    ' There are no errors; enable Run button
                    Me.SimulationExecutionControl.EnableRunButtons()

                    If (0 <= mUnit.UnitControlRef.RunCount.Value) Then
                        ' Simulation has been run at least once; are results valid?
                        _resultsAreValid = mUnit.ResultsAreValid
                    End If
                End If
            End If

            ' If changed, set the new Results Are Valid state
            If Not (mResultsAreValid = _resultsAreValid) Then
                mResultsAreValid = _resultsAreValid
                If (mDisplayResults) Then
                    SimulationResultsControl.UpdateUI(mResultsAreValid)
                End If
            End If

            ' Ensure results are displayed if they are valid
            If (mResultsAreValid And Not SimulationResultsControl.ResultsAreDisplayed) Then
                If (mDisplayResults) Then
                    SimulationResultsControl.UpdateUI(mResultsAreValid)
                End If
            End If

            ' Ensure results are not displayed if they are invalid
            'If (Not mResultsAreValid And SimulationResultsControl.ResultsAreDisplayed) Then
            '    SimulationResultsControl.DisplayNoResults()
            'End If

            mUnit.RaiseResultsEvent()
        End If

    End Sub

#End Region

#Region " Printing "
    '
    ' Override these methods to implement Print & Print Preview
    '
    Protected Overrides Sub Print(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SimulationResultsControl.Print()
    End Sub

    Protected Overrides Sub PrintPreview(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SimulationResultsControl.PrintPreview()
    End Sub

#End Region

#End Region

#Region " Simulation Execution "
    '
    ' Run the SRFR simulation engine
    '
    Public Sub RunSrfrSimulation()

        ' Run SRFR in-sync with HYDRUS if selected
        Try
            If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then

                ' DataHasChangedSince() uses the Run Time to track subsequent input changes
                Dim runTime As DateTimeParameter = mUnit.UnitControlRef.RunDateTime
                runTime.Value = System.DateTime.Now
                runTime.Source = DataStore.Globals.ValueSources.Calculated
                mUnit.UnitControlRef.RunDateTime = runTime

                Dim syncOK As Boolean = CurrentAnalysis.SyncWithHydrus()
                'Dim syncOK As Boolean = CurrentAnalysis.SyncParallelHydrusWithSRFR()

                If (syncOK) Then
                    Me.WorldStatusMessage = mDictionary.tSyncHYDRUScompleted.Translated
                Else
                    Me.WorldStatusMessage = mDictionary.tSyncHYDRUSterminated.Translated

                    Dim Dapp As DoubleParameter = mUnit.SubsurfaceFlowRef.Dapp
                    mUnit.SubsurfaceFlowRef.Dapp = Dapp
                    Return
                End If
            End If
        Catch ex As Exception
        End Try

        Me.StartRun() ' Common World code to Start a Run

        ' Execute the Simulation
        Try

            CurrentAnalysis.RunSimulation()
            CurrentAnalysis.CheckOverflow()

            ' Perform optional Erosion / Fertigation simulation
            If (mUnit.ErosionRef.EnableErosion.Value) Then

                If (CurrentAnalysis.GetType Is GetType(SrfrSimulation)) Then
                    Dim srfrSim As SrfrSimulation = DirectCast(CurrentAnalysis, SrfrSimulation)

                    srfrSim.RunSrfrErosion()

                    ' Update run time to include Erosion Run
                    Dim runTime As DateTimeParameter = mUnit.UnitControlRef.RunDateTime
                    runTime.Value = System.DateTime.Now
                    runTime.Source = DataStore.Globals.ValueSources.Calculated
                    mUnit.UnitControlRef.RunDateTime = runTime
                End If

            ElseIf (mUnit.FertigationRef.EnableFertigation.Value) Then

                If (CurrentAnalysis.GetType Is GetType(SrfrSimulation)) Then
                    Dim srfrSim As SrfrSimulation = DirectCast(CurrentAnalysis, SrfrSimulation)

                    srfrSim.RunSrfrFertigation()

                    If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then
                        srfrSim.RunHydrusFertigation()
                    End If

                    ' Update run time to include Fertigation Run
                    Dim runTime As DateTimeParameter = mUnit.UnitControlRef.RunDateTime
                    runTime.Value = System.DateTime.Now
                    runTime.Source = DataStore.Globals.ValueSources.Calculated
                    mUnit.UnitControlRef.RunDateTime = runTime
                End If

            End If

        Catch ex As Exception
            Dim title As String = ex.Message
            Dim details As String = ex.ToString
            CurrentAnalysis.AddExecutionError(Analysis.ErrorFlags.ExecutionError, title, details)
        Finally
            ' Display any Errors or Warnings
            CurrentAnalysis.DisplayErrorsAndWarnings()
            CurrentAnalysis.ClearExecutionErrors()
            CurrentAnalysis.ClearExecutionWarnings()

            ' Display the Results (which adds an unwanted Undo point)
            If (mDisplayResults) Then
                '
                ' NOTE - order is important in the following steps
                '
                SimulationTabControl.SelectedTab = ResultsTabPage
                ' Clear the Undo/Redo points (required for UpdateResultsControls to work)
                mUnit.MyStore.ClearUndoRedo()
                ' Update the results controls & tab page
                mResultsAreValid = False
                UpdateResultsControls()
                ' Clear the Undo/Redo points
                mUnit.MyStore.ClearUndoRedo()
                ' Set Focus so Ctrl-R works
                SimulationResultsControl.Focus()
            End If
        End Try

        Me.EndRun() ' Common World code to End a Run
    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal _reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated
        Select Case (_reason)
            Case WinSRFR.Reasons.FarmList
                ' WinSRFR's Farm List changed; is my Unit still in it?
                If (mFarm IsNot Nothing) Then
                    If (mWinSRFR.GetFarmByID(mFarm.MyID) IsNot mFarm) Then
                        ' No, this Window is no longer valid; hide it
                        Me.HideWindow()
                    End If
                End If

            Case WinSRFR.Reasons.UserLevel
                ' Update the UI to reflect the new User Level
                Me.SimulationWorldControl.UpdateUI()
                Me.SystemGeometryControl.UpdateUI()
                Me.SoilCropPropertiesControl.UpdateUI()
                Me.InflowManagementControl.UpdateUI()

                UpdateUI()

            Case WinMain.WinSRFR.Reasons.Language
                UpdateTranslation(Me)
                RefreshUI()

            Case Else
                UpdateUI()
        End Select
    End Sub
    '
    ' Unit Control changes
    '
    Private Sub UnitControl_Updated(ByVal _reason As UnitControl.Reasons) _
    Handles mUnitControl.PropertyDataUpdated
        If Not (Running) Then
            Select Case (_reason)
                Case UnitControl.Reasons.SelectedTab
                    SimulationTabControl.SelectedIndex = mUnit.UnitControlRef.SelectedTab.Value
                Case Else
                    UpdateUI()
            End Select
        End If
    End Sub
    '
    ' Srfr Criteria changes
    '
    Private Sub SrfrCriteria_PropertyChanged(ByVal _reason As SrfrCriteria.Reasons) _
    Handles mSrfrCriteria.PropertyDataChanged
        If Not (Running) Then
            UpdateUI()
            UpdateResultsControls()
        End If
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " File Menu "
    '
    ' Adjust File Menu to match current display
    '
    Private Sub FileMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FileMenu.Popup
        If (WinSrfr.UserLevel = UserLevels.Standard) Then ' Enable 'Scripting' menu item
            Me.FileScriptingItem.Enabled = False
        Else
            Me.FileScriptingItem.Enabled = True
        End If
    End Sub

#End Region

#Region " Simulation Menu "

    Private Sub SimulationMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WorldMenu.Popup
        Me.Focus()

        ' Is simulation run available for this world's analysis?
        Dim simAvail As Boolean = False
        If (mUnit IsNot Nothing) Then
            Dim simName As String = Me.SrfrAPI.SimName
            Dim srfrID As String = mUnit.SrfrID.Value
            If (Me.SrfrAPI.SimName = mUnit.SrfrID.Value) Then
                simAvail = True
            End If
        End If

        ' Errors prevent Run
        Me.SimulationExecutionControl.UpdateSimulationSetupErrorsWarnings(CurrentAnalysis)
        If (CurrentAnalysis.HasSetupErrors) Then
            RunSimulationItem.Enabled = False
            RunMultipleSimulationsItem.Enabled = False
        Else
            RunSimulationItem.Enabled = True
            RunMultipleSimulationsItem.Enabled = True
        End If

        ' Enable / Disable menu items
        If (mWinSRFR.UserLevel = UserLevels.Standard) Then
            AdvancedCriteriaItem.Enabled = False
            RunMultipleSimulationsItem.Enabled = False
        Else
            AdvancedCriteriaItem.Enabled = True
            RunMultipleSimulationsItem.Enabled = True
        End If

        ' Enable / Disable Animation Viewer
        Me.ViewSimulationAnimationItem.Enabled = simAvail

    End Sub

    Private Sub RunSimulationItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunSimulationItem.Click
        Me.RunSrfrSimulation()
    End Sub

    Private Sub RunMultipleSimulationsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunMultipleSimulationsItem.Click
        If (mRunMultiple Is Nothing) Then
            mRunMultiple = New RunMultiSimulations
            mRunMultiple.WinSRFR = mWinSRFR

            UpdateTranslation(mRunMultiple)

            mRunMultiple.SimulationWorld = Me
            mRunMultiple.Show()
        Else
            mRunMultiple.Show()
            mRunMultiple.BringToFront()
        End If
    End Sub

    Private Sub ViewSimulationAnimationItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewSimulationAnimationItem.Click
        If (mResultsAreValid) Then ' There is an animation to display
            AnimationViewer.FrameNumber = 0
            AnimationViewer.UpdateUI()
            AnimationViewer.Show()
            AnimationViewer.BringToFront()
        End If
    End Sub

    Private Sub StandardCriteriaItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StandardCriteriaItem.Click
        Dim db As SimGraphicsDialogBox = New SimGraphicsDialogBox(mUnit, Globals.UserLevels.Standard)
        UpdateTranslation(db)
        db.ShowDialog()
    End Sub

    Private Sub AdvancedCriteriaItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AdvancedCriteriaItem.Click
        Dim db As SimCellDensityDialogBox = New SimCellDensityDialogBox(mUnit)
        UpdateTranslation(db)
        db.ShowDialog()
    End Sub

#End Region

#Region " Help Menu "

    Private Sub AboutSimulationItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AboutSimulationItem.Click
        WinSrfr.ShowPdfHelpManual("ch:HydraulicSimulation")
    End Sub

    Private Sub HelpStartItem_Click(sender As Object, e As EventArgs) _
        Handles HelpStartItem.Click
        WinSrfr.ShowPdfHelpManual("ch:StartTab")
    End Sub

    Private Sub HelpSystemGeometryItem_Click(sender As Object, e As EventArgs) _
        Handles HelpSystemGeometryItem.Click
        If (mUnit IsNot Nothing) Then
            If (mUnit.CrossSection = CrossSections.Furrow) Then
                WinSrfr.ShowPdfHelpManual("sec:FurrowGeometry")
            Else
                WinSrfr.ShowPdfHelpManual("sec:BorderGeometry")
            End If
        Else
            WinSrfr.ShowPdfHelpManual("sec:GeometryTab")
        End If
    End Sub

    Private Sub HelpRoughnessItem_Click(sender As Object, e As EventArgs) _
        Handles HelpRoughnessItem.Click
        WinSrfr.ShowPdfHelpManual("sec:HydraulicResistance")
    End Sub

    Private Sub HelpInfiltrationItem_Click(sender As Object, e As EventArgs) _
        Handles HelpInfiltrationItem.Click
        WinSrfr.ShowPdfHelpManual("sec:Infiltration")
    End Sub

    Private Sub HelpInflowRunoffItem_Click(sender As Object, e As EventArgs) _
        Handles HelpInflowRunoffItem.Click
        WinSrfr.ShowPdfHelpManual("sec:InflowRunoff")
    End Sub

    Private Sub HelpExecutionItem_Click(sender As Object, e As EventArgs) _
        Handles HelpExecutionItem.Click
        WinSrfr.ShowPdfHelpManual("sec:SimulationInputs")
    End Sub

    Private Sub HelpResultsItem_Click(sender As Object, e As EventArgs) _
        Handles HelpResultsItem.Click
        WinSrfr.ShowPdfHelpManual("sec:SimulationOutputs")
    End Sub

    Protected Overrides Sub HelpF1()

        Dim destination As String = "ch:HydraulicSimulation"

        Dim curTab As TabPage = Me.SimulationTabControl.SelectedTab
        If (curTab IsNot Nothing) Then
            If (curTab Is Me.SimulationTabPage) Then
                destination = "sec:StartTab"
            ElseIf (curTab Is Me.SystemGeometryTabPage) Then
                If (mUnit IsNot Nothing) Then
                    If (mUnit.CrossSection = CrossSections.Furrow) Then
                        destination = "sec:FurrowGeometry"
                    Else
                        destination = "sec:BorderGeometry"
                    End If
                Else
                    destination = "sec:GeometryTab"
                End If
            ElseIf (curTab Is Me.SoilCropPropertiesTabPage) Then
                Dim focus As Boolean = HasFocus(curTab, GetType(ctl_Roughness))
                If (focus) Then
                    destination = "sec:HydraulicResistance"
                Else
                    destination = "sec:Infiltration"
                End If
            ElseIf (curTab Is Me.InflowManagementTabPage) Then
                destination = "sec:InflowRunoff"
            ElseIf (curTab Is Me.DataTabPage) Then
                If (0 < Me.DataTabPage.Controls.Count) Then
                    For Each curCtrl As Control In Me.DataTabPage.Controls
                        If (curCtrl.Visible) Then
                            If (curCtrl.GetType() Is GetType(ctl_Erosion)) Then
                                destination = "sec:SoluteTransportInputs"
                            ElseIf (curCtrl.GetType() Is GetType(ctl_Fertigation)) Then
                                destination = "sec:SoluteTransportInputs"
                            Else
                                destination = "sec:SimulationInputs"
                            End If
                            Exit For
                        End If
                    Next curCtrl
                End If

            ElseIf (curTab Is Me.ExecutionTabPage) Then
                destination = "sec:SimulationInputs"
            ElseIf (curTab Is Me.ResultsTabPage) Then
                destination = "sec:SimulationOutputs"
            End If
        End If

        WinSrfr.ShowPdfHelpManual(destination)

    End Sub

#End Region

#Region " Tab Control "

    Private Sub SimulationTabControl_SelectedIndexChanged(ByVal sender As System.Object,
                                                          ByVal e As System.EventArgs) _
    Handles SimulationTabControl.SelectedIndexChanged

        ' Wait for a valid tab page to be selected then save the selection
        If (-1 < SimulationTabControl.SelectedIndex) Then
            If (mUnit IsNot Nothing) Then

                ' Get the current Selected Tab value
                Dim _integer As DataStore.IntegerParameter = mUnitControl.SelectedTab

                ' Only update if the value has changed
                If Not (_integer.Value = SimulationTabControl.SelectedIndex) Then

                    ' Mark this as an Undo point
                    mUnit.MyStore.MarkForUndo(mDictionary.tTabPageSelection.Translated)

                    ' Save the new tab selected
                    _integer.Value = SimulationTabControl.SelectedIndex
                    _integer.Source = DataStore.Globals.ValueSources.UserEntered
                    mUnitControl.SelectedTab = _integer

                    ' Record change as Script command
                    DataStore.DataStore.RecordScript(_integer)

                    ' Update the Toolbar buttons
                    UpdateToolbar()

                    ' Update the Execution tab
                    Me.SimulationExecutionControl.UpdateSimulationSetupErrorsWarnings(CurrentAnalysis)

                    ' Display Results page number when visible
                    Dim _tabPage As TabPage = SimulationTabControl.SelectedTab
                    If Not (_tabPage Is Nothing) Then
                        If (_tabPage Is ResultsTabPage) Then
                            Me.SimulationResultsControl.DisplayResultsPageNumber()
                        Else
                            Me.ProgressMessage = ""
                        End If
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#Region " World "

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        ResizeUI()
    End Sub

#End Region

#End Region

End Class
