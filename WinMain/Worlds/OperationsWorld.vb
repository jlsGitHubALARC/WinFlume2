
'*************************************************************************************************************
' OperationsWorld - Top-level form (Window) for WinSRFR's Operations World.
'*************************************************************************************************************
Imports DataStore.DataStore

Public Class OperationsWorld
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
                item.Text = "&Operations"
            End If
        Next

    End Sub

    Public Sub New(ByVal _winSRFR As WinSRFR)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            InitializeOperationsWorld(_winSRFR)
        Catch ex As Exception
            _winSRFR.CriticalException("InitializeOperationsWorld()", ex)
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
    Friend WithEvents OperationsMainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents ExWorldMenu As System.Windows.Forms.MenuItem
    Friend WithEvents ExHelpMenu As System.Windows.Forms.MenuItem
    Friend WithEvents HelpOperationsItem As System.Windows.Forms.MenuItem
    Friend WithEvents RunOperationsItem As System.Windows.Forms.MenuItem
    Friend WithEvents ChooseNewSolutionItem As System.Windows.Forms.MenuItem
    Friend WithEvents SelectContourOverlayItem As System.Windows.Forms.MenuItem
    Friend WithEvents OperationsTabControl As DataStore.ctl_TabControl
    Friend WithEvents OperationsWorldTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SystemGeometryTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SystemGeometryControl As WinMain.ctl_SystemGeometry
    Friend WithEvents SoilCropPropertiesTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SoilCropPropertiesControl As WinMain.ctl_SoilCropProperties
    Friend WithEvents InflowManagementTabPage As System.Windows.Forms.TabPage
    Friend WithEvents InflowManagementControl As WinMain.ctl_InflowManagement
    Friend WithEvents ExecutionTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ResultsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents OperationsResultsControl As WinMain.ctl_Results
    Friend WithEvents OperationsSeparator1 As System.Windows.Forms.MenuItem
    Friend WithEvents OperationsWorldControl As WinMain.ctl_OperationsWorld
    Friend WithEvents OperationsExecutionControl As WinMain.ctl_OperationsExecution
    Friend WithEvents HelpSepartor2 As MenuItem
    Friend WithEvents HelpStartItem As MenuItem
    Friend WithEvents HelpSystemGeometryItem As MenuItem
    Friend WithEvents HelpSoilCropItem As MenuItem
    Friend WithEvents HelpInflowRunoffItem As MenuItem
    Friend WithEvents HelpExecutionItem As MenuItem
    Friend WithEvents HelpResultsItem As MenuItem
    Friend WithEvents EstimateTuningFactorsItem As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OperationsWorld))
        Me.OperationsMainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.ExWorldMenu = New System.Windows.Forms.MenuItem()
        Me.EstimateTuningFactorsItem = New System.Windows.Forms.MenuItem()
        Me.RunOperationsItem = New System.Windows.Forms.MenuItem()
        Me.ChooseNewSolutionItem = New System.Windows.Forms.MenuItem()
        Me.OperationsSeparator1 = New System.Windows.Forms.MenuItem()
        Me.SelectContourOverlayItem = New System.Windows.Forms.MenuItem()
        Me.ExHelpMenu = New System.Windows.Forms.MenuItem()
        Me.HelpOperationsItem = New System.Windows.Forms.MenuItem()
        Me.HelpSepartor2 = New System.Windows.Forms.MenuItem()
        Me.HelpStartItem = New System.Windows.Forms.MenuItem()
        Me.HelpSystemGeometryItem = New System.Windows.Forms.MenuItem()
        Me.HelpSoilCropItem = New System.Windows.Forms.MenuItem()
        Me.HelpInflowRunoffItem = New System.Windows.Forms.MenuItem()
        Me.HelpExecutionItem = New System.Windows.Forms.MenuItem()
        Me.HelpResultsItem = New System.Windows.Forms.MenuItem()
        Me.OperationsTabControl = New DataStore.ctl_TabControl()
        Me.OperationsWorldTabPage = New System.Windows.Forms.TabPage()
        Me.OperationsWorldControl = New WinMain.ctl_OperationsWorld()
        Me.SystemGeometryTabPage = New System.Windows.Forms.TabPage()
        Me.SystemGeometryControl = New WinMain.ctl_SystemGeometry()
        Me.SoilCropPropertiesTabPage = New System.Windows.Forms.TabPage()
        Me.SoilCropPropertiesControl = New WinMain.ctl_SoilCropProperties()
        Me.InflowManagementTabPage = New System.Windows.Forms.TabPage()
        Me.InflowManagementControl = New WinMain.ctl_InflowManagement()
        Me.ExecutionTabPage = New System.Windows.Forms.TabPage()
        Me.OperationsExecutionControl = New WinMain.ctl_OperationsExecution()
        Me.ResultsTabPage = New System.Windows.Forms.TabPage()
        Me.OperationsResultsControl = New WinMain.ctl_Results()
        Me.WorldPanel.SuspendLayout()
        Me.OperationsTabControl.SuspendLayout()
        Me.OperationsWorldTabPage.SuspendLayout()
        Me.SystemGeometryTabPage.SuspendLayout()
        Me.SoilCropPropertiesTabPage.SuspendLayout()
        Me.InflowManagementTabPage.SuspendLayout()
        Me.ExecutionTabPage.SuspendLayout()
        Me.ResultsTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorldStatusBar
        '
        Me.WorldStatusBar.Location = New System.Drawing.Point(0, 489)
        '
        'TitleBox
        '
        Me.TitleBox.Location = New System.Drawing.Point(0, 28)
        '
        'WorldPanel
        '
        Me.WorldPanel.Controls.Add(Me.OperationsTabControl)
        Me.WorldPanel.Location = New System.Drawing.Point(0, 68)
        Me.WorldPanel.Size = New System.Drawing.Size(792, 421)
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
        'OperationsMainMenu
        '
        Me.OperationsMainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ExWorldMenu, Me.ExHelpMenu})
        '
        'ExWorldMenu
        '
        Me.ExWorldMenu.Index = 0
        Me.ExWorldMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.EstimateTuningFactorsItem, Me.RunOperationsItem, Me.ChooseNewSolutionItem, Me.OperationsSeparator1, Me.SelectContourOverlayItem})
        Me.ExWorldMenu.Text = "&World"
        '
        'EstimateTuningFactorsItem
        '
        Me.EstimateTuningFactorsItem.Index = 0
        Me.EstimateTuningFactorsItem.Text = "&Estimate Tuning Factors"
        '
        'RunOperationsItem
        '
        Me.RunOperationsItem.Index = 1
        Me.RunOperationsItem.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.RunOperationsItem.Text = "&Run Operations Analysis"
        '
        'ChooseNewSolutionItem
        '
        Me.ChooseNewSolutionItem.Index = 2
        Me.ChooseNewSolutionItem.Text = "View / &Choose New Solution ..."
        '
        'OperationsSeparator1
        '
        Me.OperationsSeparator1.Index = 3
        Me.OperationsSeparator1.Text = "-"
        '
        'SelectContourOverlayItem
        '
        Me.SelectContourOverlayItem.Index = 4
        Me.SelectContourOverlayItem.Text = "&Add Contour Overlay ..."
        '
        'ExHelpMenu
        '
        Me.ExHelpMenu.Index = 1
        Me.ExHelpMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.HelpOperationsItem, Me.HelpSepartor2, Me.HelpStartItem, Me.HelpSystemGeometryItem, Me.HelpSoilCropItem, Me.HelpInflowRunoffItem, Me.HelpExecutionItem, Me.HelpResultsItem})
        Me.ExHelpMenu.Text = "&Help"
        '
        'HelpOperationsItem
        '
        Me.HelpOperationsItem.Index = 0
        Me.HelpOperationsItem.Text = "Operations Analysis &Overview"
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
        'HelpSoilCropItem
        '
        Me.HelpSoilCropItem.Index = 4
        Me.HelpSoilCropItem.Text = "Soil / &Crop Properties"
        '
        'HelpInflowRunoffItem
        '
        Me.HelpInflowRunoffItem.Index = 5
        Me.HelpInflowRunoffItem.Text = "I&nflow / Runoff"
        '
        'HelpExecutionItem
        '
        Me.HelpExecutionItem.Index = 6
        Me.HelpExecutionItem.Text = "&Execution"
        '
        'HelpResultsItem
        '
        Me.HelpResultsItem.Index = 7
        Me.HelpResultsItem.Text = "Resu&lts"
        '
        'OperationsTabControl
        '
        Me.OperationsTabControl.AccessibleDescription = "Provides access to WinSRFR's operations functions."
        Me.OperationsTabControl.AccessibleName = "Operations World Window"
        Me.OperationsTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.OperationsTabControl.Controls.Add(Me.OperationsWorldTabPage)
        Me.OperationsTabControl.Controls.Add(Me.SystemGeometryTabPage)
        Me.OperationsTabControl.Controls.Add(Me.SoilCropPropertiesTabPage)
        Me.OperationsTabControl.Controls.Add(Me.InflowManagementTabPage)
        Me.OperationsTabControl.Controls.Add(Me.ExecutionTabPage)
        Me.OperationsTabControl.Controls.Add(Me.ResultsTabPage)
        Me.OperationsTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OperationsTabControl.Location = New System.Drawing.Point(0, 0)
        Me.OperationsTabControl.Name = "OperationsTabControl"
        Me.OperationsTabControl.SelectedIndex = 0
        Me.OperationsTabControl.Size = New System.Drawing.Size(792, 421)
        Me.OperationsTabControl.TabIndex = 0
        '
        'OperationsWorldTabPage
        '
        Me.OperationsWorldTabPage.AccessibleDescription = "Operations criteria for the field"
        Me.OperationsWorldTabPage.AccessibleName = "Operations World Tab"
        Me.OperationsWorldTabPage.Controls.Add(Me.OperationsWorldControl)
        Me.OperationsWorldTabPage.Location = New System.Drawing.Point(4, 4)
        Me.OperationsWorldTabPage.Name = "OperationsWorldTabPage"
        Me.OperationsWorldTabPage.Size = New System.Drawing.Size(784, 392)
        Me.OperationsWorldTabPage.TabIndex = 0
        Me.OperationsWorldTabPage.Text = "Start Operations"
        '
        'OperationsWorldControl
        '
        Me.OperationsWorldControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperationsWorldControl.Location = New System.Drawing.Point(0, 0)
        Me.OperationsWorldControl.Name = "OperationsWorldControl"
        Me.OperationsWorldControl.Size = New System.Drawing.Size(776, 422)
        Me.OperationsWorldControl.TabIndex = 0
        '
        'SystemGeometryTabPage
        '
        Me.SystemGeometryTabPage.AccessibleDescription = "Geometric parameters for the field under operations"
        Me.SystemGeometryTabPage.AccessibleName = "System Geometry Tab"
        Me.SystemGeometryTabPage.Controls.Add(Me.SystemGeometryControl)
        Me.SystemGeometryTabPage.Location = New System.Drawing.Point(4, 4)
        Me.SystemGeometryTabPage.Name = "SystemGeometryTabPage"
        Me.SystemGeometryTabPage.Size = New System.Drawing.Size(784, 433)
        Me.SystemGeometryTabPage.TabIndex = 1
        Me.SystemGeometryTabPage.Text = "System Geometry"
        Me.SystemGeometryTabPage.Visible = False
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
        Me.SoilCropPropertiesTabPage.AccessibleDescription = "Roughness and infiltration parameters for the field under operations"
        Me.SoilCropPropertiesTabPage.AccessibleName = "Soil / Crop Properties Tab"
        Me.SoilCropPropertiesTabPage.Controls.Add(Me.SoilCropPropertiesControl)
        Me.SoilCropPropertiesTabPage.Location = New System.Drawing.Point(4, 4)
        Me.SoilCropPropertiesTabPage.Name = "SoilCropPropertiesTabPage"
        Me.SoilCropPropertiesTabPage.Size = New System.Drawing.Size(784, 433)
        Me.SoilCropPropertiesTabPage.TabIndex = 2
        Me.SoilCropPropertiesTabPage.Text = "Soil / Crop Properties"
        Me.SoilCropPropertiesTabPage.Visible = False
        '
        'SoilCropPropertiesControl
        '
        Me.SoilCropPropertiesControl.AccessibleDescription = "Roughness and Infiltration parameter input."
        Me.SoilCropPropertiesControl.AccessibleName = "Soil Crop Properties"
        Me.SoilCropPropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SoilCropPropertiesControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoilCropPropertiesControl.Location = New System.Drawing.Point(0, 0)
        Me.SoilCropPropertiesControl.Name = "SoilCropPropertiesControl"
        Me.SoilCropPropertiesControl.Size = New System.Drawing.Size(784, 433)
        Me.SoilCropPropertiesControl.TabIndex = 0
        '
        'InflowManagementTabPage
        '
        Me.InflowManagementTabPage.AccessibleDescription = "Inflow parameters for the field under operations"
        Me.InflowManagementTabPage.AccessibleName = "Inflow / Runoff Tab"
        Me.InflowManagementTabPage.Controls.Add(Me.InflowManagementControl)
        Me.InflowManagementTabPage.Location = New System.Drawing.Point(4, 4)
        Me.InflowManagementTabPage.Name = "InflowManagementTabPage"
        Me.InflowManagementTabPage.Size = New System.Drawing.Size(784, 433)
        Me.InflowManagementTabPage.TabIndex = 3
        Me.InflowManagementTabPage.Text = "Inflow / Runoff"
        Me.InflowManagementTabPage.Visible = False
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
        'ExecutionTabPage
        '
        Me.ExecutionTabPage.AccessibleDescription = "Execution parameters for the field under operations"
        Me.ExecutionTabPage.AccessibleName = "Operations Execution Tab"
        Me.ExecutionTabPage.Controls.Add(Me.OperationsExecutionControl)
        Me.ExecutionTabPage.Location = New System.Drawing.Point(4, 4)
        Me.ExecutionTabPage.Name = "ExecutionTabPage"
        Me.ExecutionTabPage.Size = New System.Drawing.Size(784, 433)
        Me.ExecutionTabPage.TabIndex = 4
        Me.ExecutionTabPage.Text = "Execution"
        Me.ExecutionTabPage.Visible = False
        '
        'OperationsExecutionControl
        '
        Me.OperationsExecutionControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperationsExecutionControl.Location = New System.Drawing.Point(0, 0)
        Me.OperationsExecutionControl.Name = "OperationsExecutionControl"
        Me.OperationsExecutionControl.Size = New System.Drawing.Size(776, 422)
        Me.OperationsExecutionControl.TabIndex = 0
        '
        'ResultsTabPage
        '
        Me.ResultsTabPage.AccessibleDescription = "Displays the operations results for the field"
        Me.ResultsTabPage.AccessibleName = "Operations Results Tab"
        Me.ResultsTabPage.Controls.Add(Me.OperationsResultsControl)
        Me.ResultsTabPage.Location = New System.Drawing.Point(4, 4)
        Me.ResultsTabPage.Name = "ResultsTabPage"
        Me.ResultsTabPage.Size = New System.Drawing.Size(784, 433)
        Me.ResultsTabPage.TabIndex = 5
        Me.ResultsTabPage.Text = "Results"
        Me.ResultsTabPage.Visible = False
        '
        'OperationsResultsControl
        '
        Me.OperationsResultsControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OperationsResultsControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.OperationsResultsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OperationsResultsControl.Location = New System.Drawing.Point(0, 0)
        Me.OperationsResultsControl.Multiline = True
        Me.OperationsResultsControl.Name = "OperationsResultsControl"
        Me.OperationsResultsControl.ResultsView = WinMain.Globals.ResultsViews.PortraitPage
        Me.OperationsResultsControl.SelectedIndex = 0
        Me.OperationsResultsControl.Size = New System.Drawing.Size(784, 433)
        Me.OperationsResultsControl.TabIndex = 0
        '
        'OperationsWorld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(792, 511)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.OperationsMainMenu
        Me.Name = "OperationsWorld"
        Me.WorldPanel.ResumeLayout(False)
        Me.OperationsTabControl.ResumeLayout(False)
        Me.OperationsWorldTabPage.ResumeLayout(False)
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
    Private mBorderOperations As BasinBorderOperations
    Private mFurrowOperations As FurrowOperations
    '
    ' Execution control
    '
    Private mFirstRun As Boolean = True
    Private mWddRun As Boolean = False
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
    ' Known parameters for Operations functions
    '
    '                                     L     W     Q     DU     Tco     R
    Private Mngt_Inputs() As Boolean = {True, True, False, False, False, False}
    Private Eval_Inputs() As Boolean = {True, True, True, False, True, True}

    ' Resize data
    Private mMinOperationsWorldHeight As Integer
    Private mOperationsWorldHeight As Integer

    Private mMinErrorsAndWarnings As Integer

    Private mControlHeightsSaved As Boolean

#End Region

#Region " Properties "
    '
    ' Override of property to implement Results View
    '
    Protected Overrides Property ResultsView() As ResultsViews
        Get
            Return OperationsResultsControl.ResultsView
        End Get
        Set(ByVal Value As ResultsViews)
            OperationsResultsControl.ResultsView = Value
        End Set
    End Property
    '
    ' Currently Selected Operations Analysis
    '
    Public Shadows ReadOnly Property CurrentAnalysis() As OperationsAnalysis
        Get
            mAnalysis = Nothing
            Select Case (mUnit.CrossSection)
                Case CrossSections.Basin, CrossSections.Border
                    mAnalysis = mBorderOperations
                Case CrossSections.Furrow
                    mAnalysis = mFurrowOperations
            End Select
            Return mAnalysis
        End Get
    End Property

#End Region

#Region " Initialization "
    '
    ' Called by New() to initialize the Operations Analysis World
    '
    Private Sub InitializeOperationsWorld(ByVal _winSRFR As WinSRFR)
        MyBase.InitializeWorldWindow(_winSRFR)

        If Not (mWinSRFR Is Nothing) Then
            ' Change the name of the World Menu
            WorldMenu.Text = "&" & mDictionary.tOperations.Translated

            ' Save current sizes & locations
            mOperationsWorldHeight = MyBase.Height
            mMinOperationsWorldHeight = MyBase.Height
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
        mBorderOperations = New BasinBorderOperations(mUnit, Me)
        mFurrowOperations = New FurrowOperations(mUnit, Me)
        mAnalysis = Me.CurrentAnalysis

        ' Link the UI's of all contained controls to their model object(s)
        Me.OperationsWorldControl.LinkToModel(mUnit)
        Me.SystemGeometryControl.LinkToModel(mUnit, Me)
        Me.SoilCropPropertiesControl.LinkToModel(mUnit, Me)
        Me.InflowManagementControl.LinkToModel(mUnit, Me)
        Me.OperationsExecutionControl.LinkToModel(mUnit, Me)
        Me.OperationsResultsControl.LinkToModel(mUnit, Me)

        ' Update the UI
        UpdateUI()

        ' Display the previously selected tab
        OperationsTabControl.SelectedIndex = mUnit.UnitControlRef.SelectedTab.Value

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

#Region " Operations Methods "
    '
    ' Estimate tuning factors
    '
    Public Sub EstimateOperationsTuningFactors()
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
    ' Run Operations Analysis for Basin, Border or Furrow
    '
    Public Sub RunOperationsAnalysis()
        Me.StartRun() ' Common World code to Start a Run

        Try
            ' Run operations function
            CurrentAnalysis.RunOperations()
            CurrentAnalysis.CheckOverflow()
        Catch ex As Exception
            Dim title As String = ex.Message
            Dim details As String = ex.ToString
            CurrentAnalysis.AddExecutionError(Analysis.ErrorFlags.ExecutionError, title, details)
        Finally
            ' Display any Errors and/or Warnings
            CurrentAnalysis.DisplayErrorsAndWarnings()
            '
            ' NOTE - order is important in the following steps
            '
            ' Display the Results (which adds an unwanted Undo point)
            OperationsTabControl.SelectedTab = ResultsTabPage
            ' Clear the Undo/Redo points (required for UpdateResultsControls to work)
            mUnit.MyStore.ClearUndoRedo()
            ' Update the results controls & tab page
            mResultsAreValid = False
            UpdateResultsControls()
            ' Clear the Undo/Redo points; there is no Undo after a Run
            mUnit.MyStore.ClearUndoRedo()
            ' Set Focus so Ctrl-R works
            OperationsResultsControl.Focus()
        End Try

        Me.EndRun() ' Common World code to End a Run
    End Sub
    '
    ' Choose a new solution point
    '
    Private Sub ChooseNewSolution()

        Dim inflowManagement As InflowManagement = mUnit.InflowManagementRef

        ' Default solution point depends on criteria (x & Y must be in SI units)
        Dim x As Double = inflowManagement.CutoffTime.Value
        Dim y As Double = inflowManagement.InflowRate.Value

        If Not (inflowManagement.CutoffMethod.Value = CutoffMethods.TimeBased) Then
            x = inflowManagement.CutoffLocationRatio.Value
        End If

        ' Dispose of old WDD
        If (Me.WDD IsNot Nothing) Then
            Me.WDD.Dispose()
            Me.WDD = Nothing
        End If

        ' Create new one
        Me.WDD = New WaterDistributionDiagram(Me, x, y)
        UpdateTranslation(Me.WDD)
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
        UpdateTranslation(mContourOverlay)

        ' Display the contour Overlay dialog box
        Dim _results As DialogResult = mContourOverlay.ShowDialog
    End Sub

#End Region

#Region " Update UI Methods "

#Region " Operations World "
    '
    ' Update the Operations World's UI
    '
    Public Overrides Sub UpdateUI()
        MyBase.UpdateUI()

        If (mUnit IsNot Nothing) Then

            ' Update Title Bar
            Dim _title As String = WinSrfrName & " " & WinSRFR.Version & " - Operations"
            Me.Text = _title
            '
            ' Set controls to their correct color
            '
            TitleBox.BackColor = mWinSRFR.OperationsBackColor
            TitleBox.ForeColor = mWinSRFR.OperationsForeColor
            '
            ' Update Operations controls
            '
            Me.OperationsWorldControl.UpdateUI()
            Me.OperationsExecutionControl.UpdateUI()

        End If

    End Sub
    '
    ' Update the Results Control (Icons, Buttons, etc.)
    '
    Public Overrides Sub UpdateResultsControls()
        MyBase.UpdateResultsControls()

        If (mUnit IsNot Nothing) Then

            Me.OperationsExecutionControl.UpdateOperationsSetupErrorsWarnings(CurrentAnalysis)

            ' Set Results defaults
            Dim _resultsAreValid As Boolean = False

            SetKnownUnknown()

            If Not (CurrentAnalysis Is Nothing) Then
                If (CurrentAnalysis.HasSetupErrors) Then
                    ' There are errors; disable Run & Verify buttons
                    Me.OperationsExecutionControl.EstimateTuningFactorsButton.Enabled = True
                Else
                    ' There are no errors; enable appropriate buttons
                    Me.OperationsExecutionControl.RunOperationsButton.Enabled = True

                    If (0 < mUnit.UnitControlRef.RunCount.Value) Then
                        ' Operations has been run at least once; are the results valid?
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

            ' If changed, set the new Results Are Valid state
            If Not (mResultsAreValid = _resultsAreValid) Then
                mResultsAreValid = _resultsAreValid
                OperationsResultsControl.UpdateUI(_resultsAreValid)
            End If

            ' Ensure results are displayed if they are valid
            If (mResultsAreValid And Not OperationsResultsControl.ResultsAreDisplayed) Then
                OperationsResultsControl.UpdateUI(mResultsAreValid)
            End If

            ' Ensure results are not displayed if they are invalid
            If (Not mResultsAreValid And OperationsResultsControl.ResultsAreDisplayed) Then
                OperationsResultsControl.DisplayNoResults()
            End If

            ' Inform Unit of Results change
            mUnit.RaiseResultsEvent()
        End If

    End Sub

#End Region

#Region " Basin / Border / Furrow Operations "
    '
    ' Operations Criteria enable / disable
    '
    Private Sub SetKnownUnknown()

        Dim operationsInputs() As Boolean = Mngt_Inputs

        If (operationsInputs.Length = InputParameters.HighLimit) Then

            ' Enable known parameters; disable unknown
            mSystemGeometry.LengthProperty.ToBeCalculated = Not operationsInputs(InputParameters.L)
            mSystemGeometry.WidthProperty.ToBeCalculated = Not operationsInputs(InputParameters.W)
            mSystemGeometry.FurrowsPerSetProperty.ToBeCalculated = Not operationsInputs(InputParameters.W)

            mInflowManagement.CutoffLocationRatioProperty.ToBeCalculated = Not operationsInputs(InputParameters.R)
            mInflowManagement.CutoffTimeProperty.ToBeCalculated = Not operationsInputs(InputParameters.Tco)
            mInflowManagement.CutbackTimeRatioProperty.ToBeCalculated = Not operationsInputs(InputParameters.Tco)
            mInflowManagement.InflowRateProperty.ToBeCalculated = Not operationsInputs(InputParameters.Q)

            mSubsurfaceFlow.DUProperty.ToBeCalculated = Not operationsInputs(InputParameters.DU)
            mSubsurfaceFlow.DUlqProperty.ToBeCalculated = Not operationsInputs(InputParameters.DU)
            mSubsurfaceFlow.DUminProperty.ToBeCalculated = Not operationsInputs(InputParameters.DU)

            ' Some Inputs are now Cross Section dependent
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                Select Case (mBorderCriteria.OperationsOption.Value)
                    Case OperationsOptions.WidthGiven
                        mSystemGeometry.FurrowsPerSetProperty.ToBeCalculated = Not operationsInputs(InputParameters.W)
                        mInflowManagement.InflowRateProperty.ToBeCalculated = Not operationsInputs(InputParameters.Q)
                    Case Else ' Assume OperationsOptions.InflowRateGiven
                        mSystemGeometry.FurrowsPerSetProperty.ToBeCalculated = operationsInputs(InputParameters.W)
                        mInflowManagement.InflowRateProperty.ToBeCalculated = operationsInputs(InputParameters.Q)
                End Select
            End If

        End If
    End Sub

#End Region

#End Region

#Region " Printing "
    '
    ' Override these methods to implement Print & Print Preview
    '
    Protected Overrides Sub Print(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OperationsResultsControl.Print()
    End Sub

    Protected Overrides Sub PrintPreview(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OperationsResultsControl.PrintPreview()
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
                Me.OperationsWorldControl.UpdateUI()
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
        Select Case (_reason)
            Case UnitControl.Reasons.SelectedTab
                OperationsTabControl.SelectedIndex = mUnit.UnitControlRef.SelectedTab.Value
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

#Region " Operations Menu "

    Private Sub OperationsMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WorldMenu.Popup
        Me.Focus()

        ' Errors prevent Run
        Me.OperationsExecutionControl.UpdateOperationsSetupErrorsWarnings(CurrentAnalysis)
        If (CurrentAnalysis.HasSetupErrors) Then
            RunOperationsItem.Enabled = False
        Else
            RunOperationsItem.Enabled = True
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

    Private Sub EstimateTuningFactorsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EstimateTuningFactorsItem.Click
        EstimateOperationsTuningFactors()
    End Sub

    Private Sub RunOperationsAnalysisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunOperationsItem.Click
        RunOperationsAnalysis()
    End Sub

    Private Sub ChooseSolutionItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ChooseNewSolutionItem.Click
        ChooseNewSolution()
    End Sub

    Private Sub SelectContourOverlayItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SelectContourOverlayItem.Click
        AddContourOverlays()
    End Sub

#End Region

#Region " Help Menu "
    '
    ' Help Menu
    '
    Private Sub HelpOperationsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles HelpOperationsItem.Click
        WinSrfr.ShowPdfHelpManual("ch:Operations")
    End Sub

    Private Sub HelpStartItem_Click(sender As Object, e As EventArgs) _
        Handles HelpStartItem.Click
        WinSrfr.ShowPdfHelpManual("ch:OperationsStart")
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

    Private Sub HelpSoilCropItem_Click(sender As Object, e As EventArgs) _
        Handles HelpSoilCropItem.Click
        WinSrfr.ShowPdfHelpManual("ch:OperationsSoilCrop")
    End Sub

    Private Sub HelpInflowRunoffItem_Click(sender As Object, e As EventArgs) _
        Handles HelpInflowRunoffItem.Click
        WinSrfr.ShowPdfHelpManual("ch:OperationsInflowRunoff")
    End Sub

    Private Sub HelpExecutionItem_Click(sender As Object, e As EventArgs) _
        Handles HelpExecutionItem.Click
        WinSrfr.ShowPdfHelpManual("ch:OperationsExecution")
    End Sub

    Private Sub HelpResultsItem_Click(sender As Object, e As EventArgs) _
        Handles HelpResultsItem.Click
        WinSrfr.ShowPdfHelpManual("ch:OperationsOutputs")
    End Sub
    '
    ' F1 key handler
    '
    Protected Overrides Sub HelpF1()

        Dim destination As String = "ch:Operations"

        Dim curTab As TabPage = Me.OperationsTabControl.SelectedTab
        If (curTab IsNot Nothing) Then
            If (curTab Is Me.OperationsWorldTabPage) Then
                destination = "ch:OperationsStart"
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
                destination = "ch:OperationsInflowRunoff"
            ElseIf (curTab Is Me.ExecutionTabPage) Then
                destination = "ch:OperationsExecution"
            ElseIf (curTab Is Me.ResultsTabPage) Then
                destination = "ch:OperationsOutputs"
            End If
        End If

        WinSrfr.ShowPdfHelpManual(destination)

    End Sub

#End Region

#Region " Tab Control "

    Private Sub AnalysisTabControl_SelectedIndexChanged(ByVal sender As System.Object, _
                                                        ByVal e As System.EventArgs) _
    Handles OperationsTabControl.SelectedIndexChanged

        ' Wait for a valid tab page to be selected then save the selection
        If (-1 < OperationsTabControl.SelectedIndex) Then
            If (mUnit IsNot Nothing) Then

                ' Get the current Selected Tab value
                Dim _integer As DataStore.IntegerParameter = mUnit.UnitControlRef.SelectedTab

                ' Only update if the value has changed
                If Not (_integer.Value = OperationsTabControl.SelectedIndex) Then

                    ' Mark this as an Undo point
                    mUnit.MyStore.MarkForUndo(mDictionary.tTabPageSelection.Translated)

                    ' Save the new tab selected
                    _integer.Value = OperationsTabControl.SelectedIndex
                    _integer.Source = DataStore.Globals.ValueSources.UserEntered
                    mUnit.UnitControlRef.SelectedTab = _integer

                    ' Update the Toolbar buttons
                    UpdateToolbar()

                    ' Update the Run Errors & Warnings
                    Me.OperationsExecutionControl.UpdateOperationsSetupErrorsWarnings(CurrentAnalysis)

                    ' Display Results page number when visible
                    Dim _tabPage As TabPage = OperationsTabControl.SelectedTab
                    If Not (_tabPage Is Nothing) Then
                        If (_tabPage Is ResultsTabPage) Then
                            Me.OperationsResultsControl.DisplayResultsPageNumber()
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
