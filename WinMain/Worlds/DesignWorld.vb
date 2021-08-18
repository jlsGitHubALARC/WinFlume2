
'*************************************************************************************************************
' DesignWorld - Top-level form (Window) for WinSRFR's Design World.
'*************************************************************************************************************
Imports DataStore.DataStore

Public Class DesignWorld
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
                item.Text = "&Design"
            End If
        Next

    End Sub

    Public Sub New(ByVal _winSRFR As WinSRFR)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            InitializeDesignWorld(_winSRFR)
        Catch ex As Exception
            _winSRFR.CriticalException("InitializeDesignWorld()", ex)
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
    Friend WithEvents DesignMainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents ExWorldMenu As System.Windows.Forms.MenuItem
    Friend WithEvents ExHelpMenu As System.Windows.Forms.MenuItem
    Friend WithEvents DesignTabControl As DataStore.ctl_TabControl
    Friend WithEvents DesignWorldTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SystemGeometryTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SoilCropPropertiesTabPage As System.Windows.Forms.TabPage
    Friend WithEvents InflowManagementTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ExecutionTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ResultsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents DesignResultsControl As WinMain.ctl_Results
    Friend WithEvents RunDesignItem As System.Windows.Forms.MenuItem
    Friend WithEvents DesignSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents HelpDesignItem As System.Windows.Forms.MenuItem
    Friend WithEvents ChooseNewSolutionItem As System.Windows.Forms.MenuItem
    Friend WithEvents AddContourOverlayItem As System.Windows.Forms.MenuItem
    Friend WithEvents DesignWorldControl As WinMain.ctl_DesignWorld
    Friend WithEvents SystemGeometryControl As WinMain.ctl_SystemGeometry
    Friend WithEvents SoilCropPropertiesControl As WinMain.ctl_SoilCropProperties
    Friend WithEvents InflowManagementControl As WinMain.ctl_InflowManagement
    Friend WithEvents DesignExecutionControl As WinMain.ctl_DesignExecution
    Friend WithEvents HelpSepartor2 As MenuItem
    Friend WithEvents HelpStartItem As MenuItem
    Friend WithEvents HelpSystemGeometryItem As MenuItem
    Friend WithEvents HelpRoughnessItem As MenuItem
    Friend WithEvents HelpInfiltrationItem As MenuItem
    Friend WithEvents HelpInflowRunoffItem As MenuItem
    Friend WithEvents HelpExecutionItem As MenuItem
    Friend WithEvents HelpResultsItem As MenuItem
    Friend WithEvents EstimateTuningFactorsItem As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DesignWorld))
        Me.DesignMainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.ExWorldMenu = New System.Windows.Forms.MenuItem()
        Me.EstimateTuningFactorsItem = New System.Windows.Forms.MenuItem()
        Me.RunDesignItem = New System.Windows.Forms.MenuItem()
        Me.ChooseNewSolutionItem = New System.Windows.Forms.MenuItem()
        Me.DesignSeparator1 = New System.Windows.Forms.MenuItem()
        Me.AddContourOverlayItem = New System.Windows.Forms.MenuItem()
        Me.ExHelpMenu = New System.Windows.Forms.MenuItem()
        Me.HelpDesignItem = New System.Windows.Forms.MenuItem()
        Me.HelpSepartor2 = New System.Windows.Forms.MenuItem()
        Me.HelpStartItem = New System.Windows.Forms.MenuItem()
        Me.HelpSystemGeometryItem = New System.Windows.Forms.MenuItem()
        Me.HelpRoughnessItem = New System.Windows.Forms.MenuItem()
        Me.HelpInfiltrationItem = New System.Windows.Forms.MenuItem()
        Me.HelpInflowRunoffItem = New System.Windows.Forms.MenuItem()
        Me.HelpExecutionItem = New System.Windows.Forms.MenuItem()
        Me.HelpResultsItem = New System.Windows.Forms.MenuItem()
        Me.DesignTabControl = New DataStore.ctl_TabControl()
        Me.DesignWorldTabPage = New System.Windows.Forms.TabPage()
        Me.DesignWorldControl = New WinMain.ctl_DesignWorld()
        Me.SystemGeometryTabPage = New System.Windows.Forms.TabPage()
        Me.SystemGeometryControl = New WinMain.ctl_SystemGeometry()
        Me.SoilCropPropertiesTabPage = New System.Windows.Forms.TabPage()
        Me.SoilCropPropertiesControl = New WinMain.ctl_SoilCropProperties()
        Me.InflowManagementTabPage = New System.Windows.Forms.TabPage()
        Me.InflowManagementControl = New WinMain.ctl_InflowManagement()
        Me.ExecutionTabPage = New System.Windows.Forms.TabPage()
        Me.DesignExecutionControl = New WinMain.ctl_DesignExecution()
        Me.ResultsTabPage = New System.Windows.Forms.TabPage()
        Me.DesignResultsControl = New WinMain.ctl_Results()
        Me.WorldPanel.SuspendLayout()
        Me.DesignTabControl.SuspendLayout()
        Me.DesignWorldTabPage.SuspendLayout()
        Me.SystemGeometryTabPage.SuspendLayout()
        Me.SoilCropPropertiesTabPage.SuspendLayout()
        Me.InflowManagementTabPage.SuspendLayout()
        Me.ExecutionTabPage.SuspendLayout()
        Me.ResultsTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorldStatusBar
        '
        Me.WorldStatusBar.Location = New System.Drawing.Point(0, 510)
        '
        'TitleBox
        '
        Me.TitleBox.Location = New System.Drawing.Point(0, 28)
        '
        'WorldPanel
        '
        Me.WorldPanel.Controls.Add(Me.DesignTabControl)
        Me.WorldPanel.Location = New System.Drawing.Point(0, 68)
        Me.WorldPanel.Size = New System.Drawing.Size(792, 442)
        '
        'WorldToolbar
        '
        Me.WorldToolbar.Size = New System.Drawing.Size(792, 28)
        '
        'WorldMenu
        '
        '
        'mProgressBar
        '
        Me.mProgressBar.Location = New System.Drawing.Point(550, 3)
        Me.mProgressBar.Size = New System.Drawing.Size(69, 18)
        '
        'DesignMainMenu
        '
        Me.DesignMainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ExWorldMenu, Me.ExHelpMenu})
        '
        'ExWorldMenu
        '
        Me.ExWorldMenu.Index = 0
        Me.ExWorldMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.EstimateTuningFactorsItem, Me.RunDesignItem, Me.ChooseNewSolutionItem, Me.DesignSeparator1, Me.AddContourOverlayItem})
        Me.ExWorldMenu.Text = "&World"
        '
        'EstimateTuningFactorsItem
        '
        Me.EstimateTuningFactorsItem.Index = 0
        Me.EstimateTuningFactorsItem.Text = "&Estimate Tuning Factors"
        '
        'RunDesignItem
        '
        Me.RunDesignItem.Index = 1
        Me.RunDesignItem.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.RunDesignItem.Text = "&Run Design Analysis"
        '
        'ChooseNewSolutionItem
        '
        Me.ChooseNewSolutionItem.Index = 2
        Me.ChooseNewSolutionItem.Text = "View / &Choose New Solution ..."
        '
        'DesignSeparator1
        '
        Me.DesignSeparator1.Index = 3
        Me.DesignSeparator1.Text = "-"
        '
        'AddContourOverlayItem
        '
        Me.AddContourOverlayItem.Index = 4
        Me.AddContourOverlayItem.Text = "Add Contour &Overlay ..."
        '
        'ExHelpMenu
        '
        Me.ExHelpMenu.Index = 1
        Me.ExHelpMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.HelpDesignItem, Me.HelpSepartor2, Me.HelpStartItem, Me.HelpSystemGeometryItem, Me.HelpRoughnessItem, Me.HelpInfiltrationItem, Me.HelpInflowRunoffItem, Me.HelpExecutionItem, Me.HelpResultsItem})
        Me.ExHelpMenu.Text = "&Help"
        '
        'HelpDesignItem
        '
        Me.HelpDesignItem.Index = 0
        Me.HelpDesignItem.Text = "Design Analysis &Overview"
        '
        'HelpSepartor2
        '
        Me.HelpSepartor2.Index = 1
        Me.HelpSepartor2.Text = "-"
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
        'DesignTabControl
        '
        Me.DesignTabControl.AccessibleDescription = "Provides access to WinSRFR's design functions"
        Me.DesignTabControl.AccessibleName = "Design World Window"
        Me.DesignTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.DesignTabControl.Controls.Add(Me.DesignWorldTabPage)
        Me.DesignTabControl.Controls.Add(Me.SystemGeometryTabPage)
        Me.DesignTabControl.Controls.Add(Me.SoilCropPropertiesTabPage)
        Me.DesignTabControl.Controls.Add(Me.InflowManagementTabPage)
        Me.DesignTabControl.Controls.Add(Me.ExecutionTabPage)
        Me.DesignTabControl.Controls.Add(Me.ResultsTabPage)
        Me.DesignTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DesignTabControl.Location = New System.Drawing.Point(0, 0)
        Me.DesignTabControl.Name = "DesignTabControl"
        Me.DesignTabControl.SelectedIndex = 0
        Me.DesignTabControl.Size = New System.Drawing.Size(792, 442)
        Me.DesignTabControl.TabIndex = 0
        '
        'DesignWorldTabPage
        '
        Me.DesignWorldTabPage.AccessibleDescription = "Design criteria for the field"
        Me.DesignWorldTabPage.AccessibleName = "Design World Tab"
        Me.DesignWorldTabPage.Controls.Add(Me.DesignWorldControl)
        Me.DesignWorldTabPage.Location = New System.Drawing.Point(4, 4)
        Me.DesignWorldTabPage.Name = "DesignWorldTabPage"
        Me.DesignWorldTabPage.Size = New System.Drawing.Size(784, 413)
        Me.DesignWorldTabPage.TabIndex = 0
        Me.DesignWorldTabPage.Text = "Start Design"
        '
        'DesignWorldControl
        '
        Me.DesignWorldControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignWorldControl.Location = New System.Drawing.Point(0, 0)
        Me.DesignWorldControl.Name = "DesignWorldControl"
        Me.DesignWorldControl.Size = New System.Drawing.Size(780, 430)
        Me.DesignWorldControl.TabIndex = 0
        '
        'SystemGeometryTabPage
        '
        Me.SystemGeometryTabPage.AccessibleDescription = "Geometric parameters for the field under design"
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
        Me.SystemGeometryControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemGeometryControl.Location = New System.Drawing.Point(0, 0)
        Me.SystemGeometryControl.Name = "SystemGeometryControl"
        Me.SystemGeometryControl.Size = New System.Drawing.Size(780, 430)
        Me.SystemGeometryControl.TabIndex = 0
        '
        'SoilCropPropertiesTabPage
        '
        Me.SoilCropPropertiesTabPage.AccessibleDescription = "Roughness and infiltration parameters for the field under design"
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
        Me.SoilCropPropertiesControl.AccessibleName = "Soil Crop Properties"
        Me.SoilCropPropertiesControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoilCropPropertiesControl.Location = New System.Drawing.Point(0, 0)
        Me.SoilCropPropertiesControl.Name = "SoilCropPropertiesControl"
        Me.SoilCropPropertiesControl.Size = New System.Drawing.Size(780, 430)
        Me.SoilCropPropertiesControl.TabIndex = 0
        '
        'InflowManagementTabPage
        '
        Me.InflowManagementTabPage.AccessibleDescription = "Inflow parameters for the field under design"
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
        Me.InflowManagementControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowManagementControl.Location = New System.Drawing.Point(0, 0)
        Me.InflowManagementControl.Name = "InflowManagementControl"
        Me.InflowManagementControl.Size = New System.Drawing.Size(784, 430)
        Me.InflowManagementControl.TabIndex = 0
        Me.InflowManagementControl.Title = "Inflow / Runoff"
        '
        'ExecutionTabPage
        '
        Me.ExecutionTabPage.AccessibleDescription = "Execution parameters for the field under design"
        Me.ExecutionTabPage.AccessibleName = "Design Execution Tab"
        Me.ExecutionTabPage.Controls.Add(Me.DesignExecutionControl)
        Me.ExecutionTabPage.Location = New System.Drawing.Point(4, 4)
        Me.ExecutionTabPage.Name = "ExecutionTabPage"
        Me.ExecutionTabPage.Size = New System.Drawing.Size(784, 433)
        Me.ExecutionTabPage.TabIndex = 4
        Me.ExecutionTabPage.Text = "Execution"
        '
        'DesignExecutionControl
        '
        Me.DesignExecutionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignExecutionControl.Location = New System.Drawing.Point(0, 0)
        Me.DesignExecutionControl.Name = "DesignExecutionControl"
        Me.DesignExecutionControl.Size = New System.Drawing.Size(780, 430)
        Me.DesignExecutionControl.TabIndex = 0
        '
        'ResultsTabPage
        '
        Me.ResultsTabPage.AccessibleDescription = "Displays the design results for the field"
        Me.ResultsTabPage.AccessibleName = "Design Results Tab"
        Me.ResultsTabPage.Controls.Add(Me.DesignResultsControl)
        Me.ResultsTabPage.Location = New System.Drawing.Point(4, 4)
        Me.ResultsTabPage.Name = "ResultsTabPage"
        Me.ResultsTabPage.Size = New System.Drawing.Size(784, 433)
        Me.ResultsTabPage.TabIndex = 5
        Me.ResultsTabPage.Text = "Results"
        '
        'DesignResultsControl
        '
        Me.DesignResultsControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DesignResultsControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.DesignResultsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignResultsControl.Location = New System.Drawing.Point(0, 0)
        Me.DesignResultsControl.Multiline = True
        Me.DesignResultsControl.Name = "DesignResultsControl"
        Me.DesignResultsControl.ResultsView = WinMain.Globals.ResultsViews.PortraitPage
        Me.DesignResultsControl.SelectedIndex = 0
        Me.DesignResultsControl.Size = New System.Drawing.Size(784, 433)
        Me.DesignResultsControl.TabIndex = 0
        '
        'DesignWorld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(792, 532)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.DesignMainMenu
        Me.Name = "DesignWorld"
        Me.WorldPanel.ResumeLayout(False)
        Me.DesignTabControl.ResumeLayout(False)
        Me.DesignWorldTabPage.ResumeLayout(False)
        Me.SystemGeometryTabPage.ResumeLayout(False)
        Me.SoilCropPropertiesTabPage.ResumeLayout(False)
        Me.InflowManagementTabPage.ResumeLayout(False)
        Me.ExecutionTabPage.ResumeLayout(False)
        Me.ResultsTabPage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Member Data "
    '
    ' References passed or derived via initialization
    '
    Private WithEvents mBorderCriteria As BorderCriteria
    '
    ' Supported analyses
    '
    Private mBorderDesign As BasinBorderDesign
    Private mFurrowDesign As FurrowDesign
    '
    ' Known parameters for Design functions
    '
    Private W_Inputs() As Boolean = {False, True, False, False, False, False}
    Private Q_Inputs() As Boolean = {False, False, True, False, False, False}
    '
    ' Parameters defined as User input vs. TBD
    '
    Private Enum InputParameters
        LowLimit = -1
        L
        W
        Q
        DU
        Tco
        R
        HighLimit
    End Enum
    '
    ' Window resize data
    '
    Private mMinDesignWorldHeight As Integer
    Private mDesignWorldHeight As Integer
    Private mControlHeightsSaved As Boolean

#End Region

#Region " Properties "
    '
    ' Override of property to implement Results View
    '
    Protected Overrides Property ResultsView() As ResultsViews
        Get
            Return DesignResultsControl.ResultsView
        End Get
        Set(ByVal Value As ResultsViews)
            DesignResultsControl.ResultsView = Value
        End Set
    End Property
    '
    ' Currently Selected Design Analysis
    '
    Public Shadows ReadOnly Property CurrentAnalysis() As DesignAnalysis
        Get
            mAnalysis = Nothing
            Select Case (mUnit.CrossSection)
                Case CrossSections.Basin, CrossSections.Border
                    mAnalysis = mBorderDesign
                Case CrossSections.Furrow
                    mAnalysis = mFurrowDesign
            End Select
            Return mAnalysis
        End Get
    End Property

#End Region

#Region " Initialization "
    '
    ' Called by New() to initialize the Design World Window
    '
    Private Sub InitializeDesignWorld(ByVal _winSRFR As WinSRFR)
        MyBase.InitializeWorldWindow(_winSRFR)

        If (mWinSRFR IsNot Nothing) Then
            ' Change the name of the World Menu
            WorldMenu.Text = "&" & mDictionary.tDesign.Translated

            ' Save current sizes & locations
            mDesignWorldHeight = MyBase.Height
            mMinDesignWorldHeight = MyBase.Height
            mControlHeightsSaved = True
        Else
            Debug.Assert(False, "WinSRFR is Nothing")
        End If

    End Sub
    '
    ' Display the World Window for the specified Unit
    '
    Public Overrides Sub DisplayWorldWindow(ByVal _unit As Unit)
        MyBase.DisplayWorldWindow(_unit)

        ' Get references to this Unit's child objects
        mBorderCriteria = mUnit.BorderCriteriaRef
        mEventCriteria = mUnit.EventCriteriaRef

        ' Instantiate Analyses objects
        mBorderDesign = New BasinBorderDesign(mUnit, Me)
        mFurrowDesign = New FurrowDesign(mUnit, Me)
        mAnalysis = Me.CurrentAnalysis

        ' Link the UI's of all contained controls to their model object(s)
        Me.DesignWorldControl.LinkToModel(mUnit)
        Me.SystemGeometryControl.LinkToModel(mUnit, Me)
        Me.SoilCropPropertiesControl.LinkToModel(mUnit, Me)
        Me.InflowManagementControl.LinkToModel(mUnit, Me)
        Me.DesignExecutionControl.LinkToModel(mUnit, Me)
        Me.DesignResultsControl.LinkToModel(mUnit, Me)

        ' Update the UI
        UpdateUI()

        ' Display the previously selected tab
        DesignTabControl.SelectedIndex = mUnit.UnitControlRef.SelectedTab.Value

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

#Region " Design Methods "
    '
    ' Estimate tuning factors
    '
    Public Sub EstimateDesignTuningFactors()
        Me.StartRun() ' Common World code to Start a Run

        ' Run the design function
        Dim runok As Boolean = True
        Try
            ' Mark current state as an Undo point
            mMyStore.MarkForUndo(mDictionary.tEstimateTuningFactors.Translated)

            ' Estimate Design Tuning Factors (uses SRFR Simulation)
            runok = CurrentAnalysis.EstimateTuningFactors
        Catch ex As Exception
            Dim title As String = ex.Message
            Dim details As String = ex.ToString
            CurrentAnalysis.AddExecutionError(Analysis.ErrorFlags.ExecutionError, title, details)
            runok = False
        Finally
            If (runok) Then
                WorldStatusMessage = mDictionary.tEstimationSucceeded.Translated
            Else
                CurrentAnalysis.DisplayErrors()
                WorldStatusMessage = mDictionary.tEstimationFailed.Translated
            End If

            UpdateUI()
            UpdateResultsControls()
        End Try

        Me.EndRun() ' Command World code to End a Run
    End Sub
    '
    ' Run Design Analysis for Basin, Border or Furrow
    '
    Public Sub RunDesignAnalysis()
        Me.StartRun() ' Common World code to Start a Run

        Try
            ' Run design function
            CurrentAnalysis.RunDesign()
            CurrentAnalysis.CheckOverflow()
        Catch ex As Exception
            Dim title As String = ex.Message
            Dim details As String = ex.ToString
            CurrentAnalysis.AddExecutionError(Analysis.ErrorFlags.ExecutionError, title, details)
        Finally
            ' Display any Errors and/or Warnings
            CurrentAnalysis.DisplayErrorsAndWarnings()
            '
            ' NOTE - order is important in the following steps:
            '
            ' Display the Results (which adds an unwanted Undo point)
            DesignTabControl.SelectedTab = ResultsTabPage
            ' Clear the Undo/Redo points (required for UpdateResultsControls to work)
            mUnit.MyStore.ClearUndoRedo()
            ' Update the results controls & tab page
            mResultsAreValid = False
            UpdateResultsControls()
            ' Clear the Undo/Redo points; there is no Undo after a Run
            mUnit.MyStore.ClearUndoRedo()
            ' Set Focus so Ctrl-R works
            DesignResultsControl.Focus()
        End Try

        Me.EndRun() ' Common World code to End a Run
    End Sub
    '
    ' Choose a new solution point
    '
    Private Sub ChooseNewSolution()

        Dim systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
        Dim inflowManagement As InflowManagement = mUnit.InflowManagementRef
        Dim borderCriteria As BorderCriteria = mUnit.BorderCriteriaRef

        ' Default solution point depends on criteria (x & Y must be in SI units)
        Dim x As Double = systemGeometry.Length.Value
        Dim y As Double = systemGeometry.Width.Value

        If (borderCriteria.DesignOption.Value = DesignOptions.WidthGiven) Then
            y = inflowManagement.InflowRate.Value
        End If

        ' Dispose of old WDD
        If (Me.WDD IsNot Nothing) Then
            Me.WDD.Dispose()
            Me.WDD = Nothing
        End If

        ' Create new one
        Me.WDD = New WaterDistributionDiagram(Me, x, y)
        UpdateTranslation(Me.WDD, mWinSRFR.Language)
        Me.WDD.Show()

    End Sub
    '
    ' Contour Overlays
    '
    Public Sub AddContourOverlays()
        ' If Contour Overlay dialog box is linked to another Unit, link it to this one
        If (mUnit IsNot mContourOverlay.Unit) Then
            mContourOverlay.Dispose()
            mContourOverlay = Nothing
            mContourOverlay = New BorderContourOverlay(mUnit)
        Else
            mContourOverlay.InitializeContourOverlay(mUnit)
        End If

        ' Update dialog box's translation
        UpdateTranslation(mContourOverlay, mWinSRFR.Language)

        ' Display the contour Overlay dialog box
        Dim _results As DialogResult = mContourOverlay.ShowDialog
    End Sub

#End Region

#Region " Update UI Methods "
    '
    ' Update Design World's UI
    '
    Public Overrides Sub UpdateUI()
        MyBase.UpdateUI()

        If (mUnit IsNot Nothing) Then

            ' Update Title Bar
            Dim _title As String = WinSrfrName & " " & WinSRFR.Version & " - Design"
            Me.Text = _title
            '
            ' Set controls to their correct color
            '
            TitleBox.BackColor = mWinSRFR.DesignBackColor
            TitleBox.ForeColor = mWinSRFR.DesignForeColor
            '
            ' Update Design Controls
            '
            Me.DesignWorldControl.UpdateUI()
            Me.DesignExecutionControl.UpdateUI()
        End If

    End Sub
    '
    ' Update the Results Control (Icons, Buttons, etc.)
    '
    Public Overrides Sub UpdateResultsControls()
        MyBase.UpdateResultsControls()

        If (mUnit IsNot Nothing) Then

            ' Update Run Errors & Warnings
            Me.DesignExecutionControl.UpdateDesignSetupErrorsWarnings(CurrentAnalysis)

            ' Set Results defaults
            Dim _resultsAreValid As Boolean = False

            SetKnownUnknown()

            If Not (CurrentAnalysis Is Nothing) Then
                If (CurrentAnalysis.HasSetupErrors) Then
                    ' There are errors; disable Run buttons
                    Me.DesignExecutionControl.DisableRunButtons()
                Else
                    ' There are no errors; enable Run buttons
                    Me.DesignExecutionControl.EnableRunButtons()

                    If (0 < mUnit.UnitControlRef.RunCount.Value) Then
                        ' Design has been run at least once; are the results valid?
                        If (mUnit.ResultsAreValid) Then
                            ' Yes; Parameters are known
                            SetKnown()
                            _resultsAreValid = True
                        End If
                    End If
                End If
            End If

            ' Update tooltip to match current Status Icon
            Dim _msg As String = StatusIcon.AccessibleName + "; " + StatusIcon.AccessibleDescription

            StatusIcon.ToolTip.SetToolTip(StatusIcon, _msg)
            StatusIcon.ToolTip.AutoPopDelay = 5000

            ' If changed, set new Results Are Valid state
            If Not (mResultsAreValid = _resultsAreValid) Then
                mResultsAreValid = _resultsAreValid
                DesignResultsControl.UpdateUI(_resultsAreValid)
            End If

            ' Ensure results are displayed if they are valid
            If (mResultsAreValid And Not DesignResultsControl.ResultsAreDisplayed) Then
                DesignResultsControl.UpdateUI(mResultsAreValid)
            End If

            ' Ensure results are not displayed if they are invalid
            If (Not mResultsAreValid And DesignResultsControl.ResultsAreDisplayed) Then
                DesignResultsControl.DisplayNoResults()
            End If

            ' Inform Unit of Results change
            mUnit.RaiseResultsEvent()
        End If

    End Sub

    Private Sub UpdateDesignErrorsWarnings()
        If Not (CurrentAnalysis Is Nothing) Then
            ' Check fundamental errors & warnings
            CurrentAnalysis.CheckSetupErrorsAndWarnings()
            CurrentAnalysis.CheckGeometryErrors()
            CurrentAnalysis.CheckInfiltrationErrors()
            CurrentAnalysis.CheckRoughnessErrors()
            CurrentAnalysis.CheckInflowErrors()
            CurrentAnalysis.CheckContourCriteriaErrors()

            ' Display Design errors & warnings
            Me.DesignExecutionControl.UpdateDesignSetupErrorsWarnings(CurrentAnalysis)
        End If
    End Sub
    '
    ' Design Criteria enable / disable
    '
    Private Sub SetKnownUnknown()

        Dim designInputs() As Boolean

        Select Case (mBorderCriteria.DesignOption.Value)
            Case DesignOptions.WidthGiven
                designInputs = W_Inputs
            Case Else ' Assume DesignOptions.InflowRateGiven
                designInputs = Q_Inputs
        End Select

        If (designInputs.Length = InputParameters.HighLimit) Then

            ' Enable known parameters; disable unknown
            mSystemGeometry.LengthProperty.ToBeCalculated = Not designInputs(InputParameters.L)
            mSystemGeometry.WidthProperty.ToBeCalculated = Not designInputs(InputParameters.W)
            mSystemGeometry.FurrowsPerSetProperty.ToBeCalculated = Not designInputs(InputParameters.W)

            mInflowManagement.CutoffLocationRatioProperty.ToBeCalculated = Not designInputs(InputParameters.R)
            mInflowManagement.CutoffTimeProperty.ToBeCalculated = Not designInputs(InputParameters.Tco)
            mInflowManagement.CutbackTimeRatioProperty.ToBeCalculated = Not designInputs(InputParameters.Tco)
            mInflowManagement.InflowRateProperty.ToBeCalculated = Not designInputs(InputParameters.Q)

            mSubsurfaceFlow.DUProperty.ToBeCalculated = Not designInputs(InputParameters.DU)
            mSubsurfaceFlow.DUlqProperty.ToBeCalculated = Not designInputs(InputParameters.DU)
            mSubsurfaceFlow.DUminProperty.ToBeCalculated = Not designInputs(InputParameters.DU)
        Else
            Debug.Assert(False)
        End If
    End Sub

#End Region

#Region " Printing "
    '
    ' Override these methods to implement Print & Print Preview
    '
    Protected Overrides Sub Print(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DesignResultsControl.Print()
    End Sub

    Protected Overrides Sub PrintPreview(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DesignResultsControl.PrintPreview()
    End Sub

#End Region

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
                Me.DesignWorldControl.UpdateUI()
                Me.SystemGeometryControl.UpdateUI()
                Me.SoilCropPropertiesControl.UpdateUI()
                Me.InflowManagementControl.UpdateUI()
                Me.DesignExecutionControl.UpdateUI()

                UpdateUI()

            Case WinMain.WinSRFR.Reasons.Language
                UpdateTranslation(Me, WinSrfr.Language, "WorldWindow")
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
        Select Case (_reason)
            Case UnitControl.Reasons.SelectedTab
                DesignTabControl.SelectedIndex = mUnit.UnitControlRef.SelectedTab.Value
            Case Else
                UpdateUI()
        End Select
    End Sub
    '
    ' Border Criteria changes
    '
    Private Sub BorderCriteria_PropertyChanged(ByVal _reason As BorderCriteria.Reasons) _
    Handles mBorderCriteria.PropertyDataChanged
        If Not (Running) Then
            UpdateUI()
            UpdateResultsControls()
        End If
    End Sub
    '
    ' Event Criteria changes
    '
    Private Sub EventCriteria_PropertyChanged(ByVal _reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        If Not (Running) Then
            UpdateUI()
            UpdateResultsControls()
        End If
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " Design Menu "

    Private Sub DesignMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WorldMenu.Popup
        Me.Focus()

        ' Errors prevent Run
        UpdateDesignErrorsWarnings()
        If (CurrentAnalysis.HasSetupErrors) Then
            RunDesignItem.Enabled = False
        Else
            RunDesignItem.Enabled = True
        End If

        ' Choose Solution item
        ChooseNewSolutionItem.Visible = True
        ChooseNewSolutionItem.Enabled = False
        If (0 < mUnit.UnitControlRef.RunCount.Value) Then
            If (mUnit.ResultsAreValid) Then
                ChooseNewSolutionItem.Enabled = True
            End If
        End If

    End Sub

    Private Sub EstimateTuningFactorsItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) _
    Handles EstimateTuningFactorsItem.Click
        EstimateDesignTuningFactors()
    End Sub

    Private Sub RunDesignItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunDesignItem.Click
        RunDesignAnalysis()
    End Sub

    Private Sub ChooseNewSolutionItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ChooseNewSolutionItem.Click
        ChooseNewSolution()
    End Sub

    Private Sub AddContourOverlayItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AddContourOverlayItem.Click
        AddContourOverlays()
    End Sub

#End Region

#Region " Help Menu "
    '
    ' Help Menu
    '
    Private Sub HelpDesignItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles HelpDesignItem.Click
        WinSrfr.ShowPdfHelpManual("ch:Design")
    End Sub

    Private Sub HelpStartItem_Click(sender As Object, e As EventArgs) _
        Handles HelpStartItem.Click
        WinSrfr.ShowPdfHelpManual("sec:DesignStart")
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
        WinSrfr.ShowPdfHelpManual("sec:DesignExecution")
    End Sub

    Private Sub HelpResultsItem_Click(sender As Object, e As EventArgs) _
        Handles HelpResultsItem.Click
        WinSrfr.ShowPdfHelpManual("sec:DesignOutputs")
    End Sub
    '
    ' F1 key handler
    '
    Protected Overrides Sub HelpF1()

        Dim destination As String = "ch:Design"

        Dim curTab As TabPage = Me.DesignTabControl.SelectedTab
        If (curTab IsNot Nothing) Then
            If (curTab Is Me.DesignWorldTabPage) Then
                destination = "sec:DesignStart"
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
            ElseIf (curTab Is Me.ExecutionTabPage) Then
                destination = "sec:DesignExecution"
            ElseIf (curTab Is Me.ResultsTabPage) Then
                destination = "sec:DesignOutputs"
            End If
        End If

        WinSrfr.ShowPdfHelpManual(destination)

    End Sub

#End Region

#Region " Tab Control "

    Private Sub DesignTabControl_SelectedIndexChanged(ByVal sender As System.Object,
                                                      ByVal e As System.EventArgs) _
    Handles DesignTabControl.SelectedIndexChanged

        ' Wait for a valid tab page to be selected then save the selection
        If (-1 < DesignTabControl.SelectedIndex) Then
            If (mUnit IsNot Nothing) Then

                ' Get the current Selected Tab value
                Dim _integer As DataStore.IntegerParameter = mUnit.UnitControlRef.SelectedTab

                ' Only update if the value has changed
                If Not (_integer.Value = DesignTabControl.SelectedIndex) Then

                    ' Mark this as an Undo point
                    mUnit.MyStore.MarkForUndo(mDictionary.tTabPageSelection.Translated)

                    ' Save the new tab selected
                    _integer.Value = DesignTabControl.SelectedIndex
                    _integer.Source = DataStore.Globals.ValueSources.UserEntered
                    mUnit.UnitControlRef.SelectedTab = _integer

                    ' Update the Toolbar buttons
                    UpdateToolbar()

                    ' Update the Run Errors & Warnings
                    UpdateDesignErrorsWarnings()

                    ' Display Results page number when visible
                    Dim _tabPage As TabPage = DesignTabControl.SelectedTab
                    If Not (_tabPage Is Nothing) Then
                        If (_tabPage Is ResultsTabPage) Then
                            Me.DesignResultsControl.DisplayResultsPageNumber()
                        Else
                            Me.ProgressMessage = ""
                        End If
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#End Region

End Class
