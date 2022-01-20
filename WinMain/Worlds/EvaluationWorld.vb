
'**********************************************************************************************
' Evaluation World - Top-level form (Window) for WinSRFR's Evaluation World.
'
Imports DataStore
Imports DataStore.DataStore

Public Class EvaluationWorld
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
                item.Text = "&Evaluation"
            End If
        Next
    End Sub

    Public Sub New(ByVal _winSRFR As WinSRFR)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            InitializeEvaluationWorld(_winSRFR)
        Catch ex As Exception
            _winSRFR.CriticalException("InitializeEvaluationWorld()", ex)
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
    Friend WithEvents EvaluationTabControl As DataStore.ctl_TabControl
    Friend WithEvents EventWorldTabPage As System.Windows.Forms.TabPage
    Friend WithEvents EvaluationMainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents ExWorldMenu As System.Windows.Forms.MenuItem
    Friend WithEvents RunAnalysisItem As System.Windows.Forms.MenuItem
    Friend WithEvents ExHelpMenu As System.Windows.Forms.MenuItem
    Friend WithEvents HelpEventWorldItem As System.Windows.Forms.MenuItem
    Friend WithEvents SelectGoodnessOfFitMethod As System.Windows.Forms.MenuItem
    Friend WithEvents NashSutcliffeItem As System.Windows.Forms.MenuItem
    Friend WithEvents IndexOfAgreementItem As System.Windows.Forms.MenuItem
    Friend WithEvents PercentBiasItem As System.Windows.Forms.MenuItem
    Friend WithEvents RmseStandardRatioItem As System.Windows.Forms.MenuItem
    Friend WithEvents HelpStartItem As MenuItem
    Friend WithEvents HelpSystemGeometryItem As MenuItem
    Friend WithEvents HelpSoilCropItem As MenuItem
    Friend WithEvents HelpInflowRunoffItem As MenuItem
    Friend WithEvents HelpVerifyItem As MenuItem
    Friend WithEvents HelpResultsItem As MenuItem
    Friend WithEvents HelpInputsItem As MenuItem
    Friend WithEvents HelpAnalysisItem As MenuItem
    Friend WithEvents EvaluationWorldControl As WinMain.ctl_EvaluationWorld
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EvaluationWorld))
        Me.EvaluationTabControl = New DataStore.ctl_TabControl()
        Me.EventWorldTabPage = New System.Windows.Forms.TabPage()
        Me.EvaluationWorldControl = New WinMain.ctl_EvaluationWorld()
        Me.EvaluationMainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.ExWorldMenu = New System.Windows.Forms.MenuItem()
        Me.RunAnalysisItem = New System.Windows.Forms.MenuItem()
        Me.SelectGoodnessOfFitMethod = New System.Windows.Forms.MenuItem()
        Me.NashSutcliffeItem = New System.Windows.Forms.MenuItem()
        Me.IndexOfAgreementItem = New System.Windows.Forms.MenuItem()
        Me.PercentBiasItem = New System.Windows.Forms.MenuItem()
        Me.RmseStandardRatioItem = New System.Windows.Forms.MenuItem()
        Me.ExHelpMenu = New System.Windows.Forms.MenuItem()
        Me.HelpEventWorldItem = New System.Windows.Forms.MenuItem()
        Me.HelpStartItem = New System.Windows.Forms.MenuItem()
        Me.HelpSystemGeometryItem = New System.Windows.Forms.MenuItem()
        Me.HelpSoilCropItem = New System.Windows.Forms.MenuItem()
        Me.HelpInflowRunoffItem = New System.Windows.Forms.MenuItem()
        Me.HelpInputsItem = New System.Windows.Forms.MenuItem()
        Me.HelpAnalysisItem = New System.Windows.Forms.MenuItem()
        Me.HelpVerifyItem = New System.Windows.Forms.MenuItem()
        Me.HelpResultsItem = New System.Windows.Forms.MenuItem()
        Me.WorldPanel.SuspendLayout()
        Me.EvaluationTabControl.SuspendLayout()
        Me.EventWorldTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'WorldStatusBar
        '
        Me.WorldStatusBar.Size = New System.Drawing.Size(784, 22)
        '
        'TitleBox
        '
        Me.TitleBox.Location = New System.Drawing.Point(0, 28)
        Me.TitleBox.Size = New System.Drawing.Size(784, 40)
        '
        'WorldPanel
        '
        Me.WorldPanel.Controls.Add(Me.EvaluationTabControl)
        Me.WorldPanel.Location = New System.Drawing.Point(0, 68)
        Me.WorldPanel.Size = New System.Drawing.Size(784, 463)
        '
        'WorldToolbar
        '
        Me.WorldToolbar.Size = New System.Drawing.Size(784, 28)
        '
        'HelpMenu
        '
        '
        'WorldMenu
        '
        '
        'mProgressBar
        '
        Me.mProgressBar.Location = New System.Drawing.Point(542, 3)
        Me.mProgressBar.Size = New System.Drawing.Size(69, 18)
        '
        'EvaluationTabControl
        '
        Me.EvaluationTabControl.AccessibleDescription = "Provides access to WinSRFR's evaluation functions"
        Me.EvaluationTabControl.AccessibleName = "Evaluation World Window"
        Me.EvaluationTabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.EvaluationTabControl.Controls.Add(Me.EventWorldTabPage)
        Me.EvaluationTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EvaluationTabControl.Location = New System.Drawing.Point(0, 0)
        Me.EvaluationTabControl.Name = "EvaluationTabControl"
        Me.EvaluationTabControl.SelectedIndex = 0
        Me.EvaluationTabControl.Size = New System.Drawing.Size(784, 463)
        Me.EvaluationTabControl.TabIndex = 0
        '
        'EventWorldTabPage
        '
        Me.EventWorldTabPage.Controls.Add(Me.EvaluationWorldControl)
        Me.EventWorldTabPage.Location = New System.Drawing.Point(4, 4)
        Me.EventWorldTabPage.Name = "EventWorldTabPage"
        Me.EventWorldTabPage.Size = New System.Drawing.Size(776, 434)
        Me.EventWorldTabPage.TabIndex = 0
        Me.EventWorldTabPage.Text = "Start Event"
        Me.EventWorldTabPage.UseVisualStyleBackColor = True
        '
        'EvaluationWorldControl
        '
        Me.EvaluationWorldControl.AccessibleDescription = "Provides various methods for analyzing the performance of an irrigation and estim" &
    "ating a field's infiltration and hydraulic resistance parameters."
        Me.EvaluationWorldControl.AccessibleName = "Evaluation World"
        Me.EvaluationWorldControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EvaluationWorldControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EvaluationWorldControl.Location = New System.Drawing.Point(0, 0)
        Me.EvaluationWorldControl.Name = "EvaluationWorldControl"
        Me.EvaluationWorldControl.Size = New System.Drawing.Size(776, 434)
        Me.EvaluationWorldControl.TabIndex = 0
        '
        'EvaluationMainMenu
        '
        Me.EvaluationMainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ExWorldMenu, Me.ExHelpMenu})
        '
        'ExWorldMenu
        '
        Me.ExWorldMenu.Index = 0
        Me.ExWorldMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.RunAnalysisItem, Me.SelectGoodnessOfFitMethod})
        Me.ExWorldMenu.Text = "&World"
        '
        'RunAnalysisItem
        '
        Me.RunAnalysisItem.Index = 0
        Me.RunAnalysisItem.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.RunAnalysisItem.Text = "&Run Event Analysis"
        '
        'SelectGoodnessOfFitMethod
        '
        Me.SelectGoodnessOfFitMethod.Index = 1
        Me.SelectGoodnessOfFitMethod.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.NashSutcliffeItem, Me.IndexOfAgreementItem, Me.PercentBiasItem, Me.RmseStandardRatioItem})
        Me.SelectGoodnessOfFitMethod.Text = "&Goodness of Fit Method"
        '
        'NashSutcliffeItem
        '
        Me.NashSutcliffeItem.Index = 0
        Me.NashSutcliffeItem.Text = "Nash-Sutcliffe E (&NSE)"
        '
        'IndexOfAgreementItem
        '
        Me.IndexOfAgreementItem.Index = 1
        Me.IndexOfAgreementItem.Text = "Index of Agreement &d"
        '
        'PercentBiasItem
        '
        Me.PercentBiasItem.Index = 2
        Me.PercentBiasItem.Text = "Percent Bias (&PBIAS)"
        '
        'RmseStandardRatioItem
        '
        Me.RmseStandardRatioItem.Index = 3
        Me.RmseStandardRatioItem.Text = "RMSE Standard Ratio (&RSR)"
        '
        'ExHelpMenu
        '
        Me.ExHelpMenu.Index = 1
        Me.ExHelpMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.HelpEventWorldItem, Me.HelpStartItem, Me.HelpSystemGeometryItem, Me.HelpSoilCropItem, Me.HelpInflowRunoffItem, Me.HelpInputsItem, Me.HelpAnalysisItem, Me.HelpVerifyItem, Me.HelpResultsItem})
        Me.ExHelpMenu.Text = "&Help"
        '
        'HelpEventWorldItem
        '
        Me.HelpEventWorldItem.Index = 0
        Me.HelpEventWorldItem.Text = "Event Analysis &Overview"
        '
        'HelpStartItem
        '
        Me.HelpStartItem.Index = 1
        Me.HelpStartItem.Text = "&Start"
        '
        'HelpSystemGeometryItem
        '
        Me.HelpSystemGeometryItem.Index = 2
        Me.HelpSystemGeometryItem.Text = "System &Geometry"
        '
        'HelpSoilCropItem
        '
        Me.HelpSoilCropItem.Index = 3
        Me.HelpSoilCropItem.Text = "Soil / &Crop Properties"
        '
        'HelpInflowRunoffItem
        '
        Me.HelpInflowRunoffItem.Index = 4
        Me.HelpInflowRunoffItem.Text = "I&nflow / Runoff"
        '
        'HelpInputsItem
        '
        Me.HelpInputsItem.Index = 5
        Me.HelpInputsItem.Text = "In&puts"
        '
        'HelpAnalysisItem
        '
        Me.HelpAnalysisItem.Index = 6
        Me.HelpAnalysisItem.Text = "&Analysis"
        '
        'HelpVerifyItem
        '
        Me.HelpVerifyItem.Index = 7
        Me.HelpVerifyItem.Text = "&Verify"
        '
        'HelpResultsItem
        '
        Me.HelpResultsItem.Index = 8
        Me.HelpResultsItem.Text = "Resu&lts"
        '
        'EvaluationWorld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.ClientSize = New System.Drawing.Size(784, 553)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.EvaluationMainMenu
        Me.Name = "EvaluationWorld"
        Me.WorldPanel.ResumeLayout(False)
        Me.EvaluationTabControl.ResumeLayout(False)
        Me.EventWorldTabPage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Member Data "
    '
    ' References to contained controls
    '
    Friend WithEvents SystemGeometryControl As WinMain.ctl_SystemGeometry           ' Data input tabs
    Friend WithEvents SoilCropPropertiesControl As WinMain.ctl_SoilCropProperties
    Friend WithEvents InflowRunoffControl As WinMain.ctl_InflowRunoff
    Friend WithEvents AdvanceRecessionControl As WinMain.ctl_AdvanceRecession
    Friend WithEvents FlowDepthsControl As WinMain.ctl_FlowDepths

    Friend WithEvents VolumeBalancesControl As WinMain.ctl_VolumeBalances           ' Data analysis tabs
    Friend WithEvents RoughnessControl As WinMain.ctl_Roughness
    Friend WithEvents SurfaceVolumeMeasuredControl As WinMain.ctl_SurfaceVolumeMeasured
    Friend WithEvents SurfaceVolumeEstimatedControl As WinMain.ctl_SurfaceVolumeEstimated

    Friend WithEvents EvaluationInfiltrationControl As WinMain.ctl_EvaluationInfiltration
    Friend WithEvents EvalueRoughnessControl As WinMain.ctl_EvalueRoughness

    Friend WithEvents InfiltratedProfileControl As WinMain.ctl_InfiltratedProfile   ' Probe Penetration

    Friend WithEvents EvaluationExecutionControl As WinMain.ctl_EvaluationExecution
    Friend WithEvents EventAnalysisResultsControl As WinMain.ctl_EvaluationResults

    ' CWnd::LockWindowUpdate - Disables drawing in the given window
    Friend Declare Function LockWindowUpdate Lib "user32.dll" (ByVal hWndLock As IntPtr) As Boolean

    Private mSelectedGroup As TabGroups = TabGroups.LowLimit
    Private mSelectedTab As Integer = -1

#End Region

#Region " Properties "
    '
    ' Override of property to implement Results View
    '
    Protected Overrides Property ResultsView() As ResultsViews
        Get
            Return EventAnalysisResultsControl.ResultsView
        End Get
        Set(ByVal Value As ResultsViews)
            EventAnalysisResultsControl.ResultsView = Value
        End Set
    End Property
    '
    ' Currently Selected Analysis
    '
    Public Shadows ReadOnly Property CurrentAnalysis() As EventAnalysis
        Get
            ' mAnalysis is stored in the WorldWindow baseclass
            mAnalysis = Me.EvaluationExecutionControl.CurrentAnalysis
            Return mAnalysis
        End Get
    End Property

    Private mResetingTabs As Boolean = False
    Public Function ResetingTabs() As Boolean
        Return mResetingTabs
    End Function

#End Region

#Region " Initialization "
    '
    ' Called by New() to initialize the Evaluation World Window
    '
    Private Sub InitializeEvaluationWorld(ByVal _winSRFR As WinSRFR)
        MyBase.InitializeWorldWindow(_winSRFR)

        If (mWinSRFR IsNot Nothing) Then

            ' Instantiate the various Evaluation World input controls
            Me.SystemGeometryControl = New WinMain.ctl_SystemGeometry
            Me.SoilCropPropertiesControl = New WinMain.ctl_SoilCropProperties
            Me.InflowRunoffControl = New WinMain.ctl_InflowRunoff
            Me.AdvanceRecessionControl = New WinMain.ctl_AdvanceRecession
            Me.FlowDepthsControl = New WinMain.ctl_FlowDepths

            Me.VolumeBalancesControl = New WinMain.ctl_VolumeBalances
            Me.RoughnessControl = New WinMain.ctl_Roughness
            Me.SurfaceVolumeMeasuredControl = New WinMain.ctl_SurfaceVolumeMeasured
            Me.SurfaceVolumeEstimatedControl = New WinMain.ctl_SurfaceVolumeEstimated
            Me.EvaluationInfiltrationControl = New WinMain.ctl_EvaluationInfiltration
            Me.EvalueRoughnessControl = New WinMain.ctl_EvalueRoughness

            Me.InfiltratedProfileControl = New WinMain.ctl_InfiltratedProfile           ' Probe Penetration

            Me.EvaluationExecutionControl = New WinMain.ctl_EvaluationExecution
            Me.EventAnalysisResultsControl = New WinMain.ctl_EvaluationResults

            ' Change the name of the World Menu
            WorldMenu.Text = "&" & mDictionary.tEvaluation.Translated
        Else
            Debug.Assert(False, "WinSRFR is Nothing")
        End If

    End Sub
    '
    ' Display the World Window for the specified Unit
    '
    Public Overrides Sub DisplayWorldWindow(ByVal _unit As Unit)
        MyBase.DisplayWorldWindow(_unit)

        ' Link UI's of contained controls to their model object(s)
        Me.EvaluationWorldControl.LinkToModel(mUnit)
        Me.SystemGeometryControl.LinkToModel(mUnit, Me)
        Me.SoilCropPropertiesControl.LinkToModel(mUnit, Me)
        Me.InflowRunoffControl.LinkToModel(mUnit, Me)

        Me.EvaluationExecutionControl.LinkToModel(mUnit, Me)    ' Sets CurrentAnalysis
        mAnalysis = Me.CurrentAnalysis

        Me.AdvanceRecessionControl.LinkToModel(mUnit, Me)       ' Uses CurrentAnalysis
        Me.FlowDepthsControl.LinkToModel(mUnit, Me)
        Me.VolumeBalancesControl.LinkToModel(mUnit, Me)
        Me.RoughnessControl.LinkToModel(mUnit)
        Me.SurfaceVolumeMeasuredControl.LinkToModel(mUnit, Me)
        Me.SurfaceVolumeEstimatedControl.LinkToModel(mUnit, Me)
        Me.EvaluationInfiltrationControl.LinkToModel(mUnit, Me)
        Me.EvalueRoughnessControl.LinkToModel(mUnit, Me)
        Me.InfiltratedProfileControl.LinkToModel(mUnit, Me)

        Me.EventAnalysisResultsControl.LinkToModel(mUnit, Me)

        ' Get references to Event Criteria & Analysis
        mEventCriteria = _unit.EventCriteriaRef

        ' Update Title Bar
        Dim _title As String = WinSrfrName & " " & WinSRFR.Version & " - Evaluation"
        Me.Text = _title

        ' Set controls to their correct color
        TitleBox.BackColor = mWinSRFR.EventBackColor
        TitleBox.ForeColor = mWinSRFR.EventForeColor

        ' Reset input controls & tab pages
        ResetTabPages()

        ' Initialize UI
        UpdateUI()

        ' Update results controls & tab pages
        UpdateResultsControls()

        ' Set initial window size
        If Not (mWindowSizeSet) Then
            mWindowSizeSet = True
            Select Case mWinSRFR.WindowSize
                Case WindowSizes.S800x600
                    Me.Size = New Size(800, 600)
                Case WindowSizes.S900x675
                    Me.Size = New Size(900, 675)
                Case WindowSizes.S949x768
                    Me.Size = New Size(949, 768)
                Case Else
                    Me.Size = New Size(1024, 768)
            End Select
            Me.MinimumSize = New Size(800, 600)
        End If

    End Sub

    Private Sub ResetTabPages()

        If (mEventCriteria IsNot Nothing) Then

            If (mResetingTabs) Then
                Return
            End If

            mResetingTabs = True

            ' Disable drawing in this window
            LockWindowUpdate(Me.Handle.ToInt32)
            '
            ' Set the UI to match the selected criteria
            '
            Me.EvaluationTabControl.SuspendLayout()
            Me.EventWorldTabPage.SuspendLayout()
            Me.SuspendLayout()

            ' Remove all tab pages except the 1st one (Evaluation World tab)
            For tdx As Integer = Me.EvaluationTabControl.TabPages.Count - 1 To 1 Step -1
                Dim tdxPage As TabPage = Me.EvaluationTabControl.TabPages(tdx)
                Me.EvaluationTabControl.TabPages.Remove(tdxPage)
                tdxPage.Controls.Clear()
                tdxPage.Dispose()
            Next tdx

            ' Add tab pages for current analysis
            Dim tSystemGeometry As String = mDictionary.tSystemGeometry.Translated
            Dim tSoilCropProperties As String = mDictionary.tSoilCropProperties.Translated
            Dim tRoughness As String = mDictionary.tRoughness.Translated
            Dim tInfiltration As String = mDictionary.tInfiltration.Translated
            Dim tInflowRunoff As String = mDictionary.tInflow.Translated & " / " & mDictionary.tRunoff.Translated
            Dim tAdvance As String = mDictionary.tAdvance.Translated
            Dim tAdvanceRecession As String = tAdvance & " / " & mDictionary.tRecession.Translated
            Dim tVolumeBalance As String = mDictionary.tVolumeBalance.Translated
            Dim tSurfaceVolumesEstimated As String = mDictionary.tSurfaceVolumesEstimated.Translated
            Dim tProbeMeas As String = mDictionary.tProbeMeasurement.Translated
            Dim tVerify As String = mDictionary.tVerify.Translated
            Dim tResults As String = mDictionary.tResults.Translated

            Select Case (mEventCriteria.EventAnalysisType.Value)

                Case EventAnalysisTypes.InfiltratedProfileAnalysis
                    Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.SystemGeometryControl, tSystemGeometry))
                    Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.InflowRunoffControl, tInflowRunoff))
                    Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.InfiltratedProfileControl, tProbeMeas))
                    Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EvaluationExecutionControl, tVerify))
                    Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EventAnalysisResultsControl, tResults))

                Case EventAnalysisTypes.MerriamKellerAnalysis
                    If (mUnitControl.TabGroup.Value = TabGroups.DataTabs) Then
                        ' Data input tabs
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.SystemGeometryControl, tSystemGeometry))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.SoilCropPropertiesControl, tSoilCropProperties))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.InflowRunoffControl, tInflowRunoff))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.AdvanceRecessionControl, tAdvanceRecession))
                        Me.EvaluationTabControl.Controls.Add(New TabPage(mDictionary.tAnalysisTabs.Translated))

                        Me.SoilCropPropertiesControl.InfiltrationControl.Hide()
                    Else
                        ' Analysis tabs
                        Me.EvaluationTabControl.Controls.Add(New TabPage(mDictionary.tDataTabs.Translated))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.VolumeBalancesControl, tVolumeBalance))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.RoughnessControl, tRoughness))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EvaluationInfiltrationControl, tInfiltration))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EvaluationExecutionControl, tVerify))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EventAnalysisResultsControl, tResults))
                    End If

                Case EventAnalysisTypes.TwoPointAnalysis
                    If (mUnitControl.TabGroup.Value = TabGroups.DataTabs) Then
                        ' Data input tabs
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.SystemGeometryControl, tSystemGeometry))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.InflowRunoffControl, tInflowRunoff))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.AdvanceRecessionControl, tAdvance))
                        Me.EvaluationTabControl.Controls.Add(New TabPage(mDictionary.tAnalysisTabs.Translated))
                    Else
                        ' Analysis tabs
                        Me.EvaluationTabControl.Controls.Add(New TabPage(mDictionary.tDataTabs.Translated))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.VolumeBalancesControl, tVolumeBalance))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.SurfaceVolumeEstimatedControl, tSurfaceVolumesEstimated))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EvaluationInfiltrationControl, tInfiltration))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EvaluationExecutionControl, tVerify))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EventAnalysisResultsControl, tResults))
                    End If

                Case EventAnalysisTypes.EvalueAnalysis
                    If (mUnitControl.TabGroup.Value = TabGroups.DataTabs) Then
                        ' Data input tabs
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.SystemGeometryControl, tSystemGeometry))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.SoilCropPropertiesControl, tSoilCropProperties))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.InflowRunoffControl, tInflowRunoff))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.AdvanceRecessionControl, tAdvanceRecession))

                        If (mInflowManagement.FlowDepthsMeasured.Value) Then
                            Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.FlowDepthsControl, mDictionary.tFlowDepths.Translated))
                        End If

                        Me.EvaluationTabControl.Controls.Add(New TabPage(mDictionary.tAnalysisTabs.Translated))

                        Me.SoilCropPropertiesControl.InfiltrationControl.Hide()
                    Else
                        ' Analysis tabs
                        Me.EvaluationTabControl.Controls.Add(New TabPage(mDictionary.tDataTabs.Translated))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.VolumeBalancesControl, tVolumeBalance))

                        If (mInflowManagement.FlowDepthsMeasuredAndUsed) Then
                            Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.SurfaceVolumeMeasuredControl, mDictionary.tSurfaceVolumesMeasured.Translated))
                        Else
                            Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.SurfaceVolumeEstimatedControl, mDictionary.tSurfaceVolumesEstimated.Translated))
                        End If

                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EvaluationInfiltrationControl, tInfiltration))

                        If (mInflowManagement.FlowDepthsDataAvailable) Then
                            Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EvalueRoughnessControl, mDictionary.tRoughness.Translated))
                        End If

                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EvaluationExecutionControl, tVerify))
                        Me.EvaluationTabControl.Controls.Add(NewTabPage(Me.EventAnalysisResultsControl, tResults))
                    End If

                    Me.FlowDepthsControl.AutoScroll = False
                    Me.VolumeBalancesControl.AutoScroll = False
                    Me.RoughnessControl.AutoScroll = False
                    Me.SurfaceVolumeMeasuredControl.AutoScroll = False
                    Me.SurfaceVolumeEstimatedControl.AutoScroll = False
                    Me.EvaluationInfiltrationControl.AutoScroll = False
                    Me.EvalueRoughnessControl.AutoScroll = False

                Case Else
                    Debug.Assert(False, "Support for the Event Analysis Type must be added")
            End Select

            mSelectedGroup = mUnitControl.TabGroup.Value

            Dim tabParam As IntegerParameter = mUnitControl.SelectedTabProperty.GetParameter
            mSelectedTab = tabParam.Value

            If (mSelectedTab = -99) Then
                mSelectedTab = 2
                tabParam.Value = mSelectedTab
            ElseIf (mSelectedTab = 99) Then
                mSelectedTab = Me.EvaluationTabControl.TabPages.Count - 2
                tabParam.Value = mSelectedTab
            End If

            Me.EvaluationTabControl.ResumeLayout(False)
            Me.EventWorldTabPage.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

            Me.EvaluationTabControl.SelectedIndex = mSelectedTab
            Me.EvaluationTabControl.TabIndex = 0
            Me.EvaluationTabControl.Focus()

            ' Enable drawing
            LockWindowUpdate(0)

            mResetingTabs = False

            Me.RefreshUI()

        End If

    End Sub

    Private Function NewTabPage(ByVal TabCtrl As Control, ByVal TabName As String) As TabPage
        ' Set the Tab's control properties so it fills the tab
        TabCtrl.SuspendLayout()
        TabCtrl.Dock = System.Windows.Forms.DockStyle.Fill
        TabCtrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!,
                                                  System.Drawing.FontStyle.Regular,
                                                  System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TabCtrl.TabIndex = 0
        TabCtrl.ResumeLayout()

        ' Create the TabPage for the Control
        NewTabPage = New TabPage
        NewTabPage.SuspendLayout()
        NewTabPage.Controls.Add(TabCtrl)
        NewTabPage.Location = New System.Drawing.Point(4, 4)
        NewTabPage.Name = TabCtrl.Name & "TabPage"
        NewTabPage.Size = New System.Drawing.Size(784, 434)
        NewTabPage.TabIndex = 0
        NewTabPage.Text = TabName
        NewTabPage.UseVisualStyleBackColor = True
        NewTabPage.ResumeLayout()
    End Function

#End Region

#Region " Methods "

#Region " Event Analysis UI "
    '
    ' Update the Event Analysis World's UI
    '
    Public Overrides Sub UpdateUI()
        MyBase.UpdateUI()
    End Sub
    '
    ' Update the Results Control (Icons, Buttons, etc.)
    '
    Public Overrides Sub UpdateResultsControls()
        MyBase.UpdateResultsControls()

        If (mUnit IsNot Nothing) Then

            ' Set Results defaults
            Dim _resultsAreValid As Boolean = False

            If Not (CurrentAnalysis Is Nothing) Then
                If Not (CurrentAnalysis.HasSetupErrors) Then
                    If (0 < mUnit.UnitControlRef.RunCount.Value) Then
                        ' Analysis has been run at least once; are results valid?
                        If (mUnit.ResultsAreValid) Then
                            ' Yes; Parameters are known
                            SetKnown()
                            _resultsAreValid = True
                        End If
                    End If
                End If
            End If

            ' Save the new Results Are Valid state and display the results
            If Not (mResultsAreValid = _resultsAreValid) Then
                mResultsAreValid = _resultsAreValid
                EventAnalysisResultsControl.UpdateUI(_resultsAreValid)
            End If

            ' Ensure results are displayed if they are valid
            If (mResultsAreValid And Not EventAnalysisResultsControl.ResultsAreDisplayed) Then
                EventAnalysisResultsControl.UpdateUI(mResultsAreValid)
            End If

            ' Ensure results are not displayed if they are invalid
            If (Not mResultsAreValid And EventAnalysisResultsControl.ResultsAreDisplayed) Then
                EventAnalysisResultsControl.DisplayNoResults()
            End If

            ' Inform Unit of Results change
            mUnit.RaiseResultsEvent()
        End If

    End Sub

#End Region

#Region " Printing "
    '
    ' Override these methods to implement Print & Print Preview
    '
    Protected Overrides Sub Print(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EventAnalysisResultsControl.Print()
    End Sub

    Protected Overrides Sub PrintPreview(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EventAnalysisResultsControl.PrintPreview()
    End Sub

#End Region

#End Region

#Region " Event Analysis Execution "
    '
    ' Run Event Analysis
    '
    Public Sub RunEventAnalysis()
        Me.StartRun() ' Common World code to Start a Run

        Try
            CurrentAnalysis.Running = True ' set running flag first; UI updaters check this

            ' Save reference inflow rate used by event analysis
            SetReferenceInflowRate()

            ' Run Analysis
            CurrentAnalysis.RunEvaluation()
            CurrentAnalysis.CheckOverflow()

            ' Make sure the Analysis tabs are showing after a run
            Dim _tabParam As IntegerParameter = mUnitControl.TabGroup
            If (_tabParam.Value = TabGroups.DataTabs) Then
                mSelectedGroup = TabGroups.AnalysisTabs
                _tabParam.Value = mSelectedGroup
                _tabParam.Source = ValueSources.Calculated
                mUnitControl.TabGroup = _tabParam
                ResetTabPages()
            End If

        Catch ex As Exception
            ResetReferenceInflowRate()
            Dim title As String = ex.Message
            Dim details As String = ex.ToString
            CurrentAnalysis.AddExecutionError(Analysis.ErrorFlags.ExecutionError, title, details)
        Finally
            ' Display any Errors or Warnings
            CurrentAnalysis.DisplayErrorsAndWarnings()
            '
            ' NOTE - order is important in the following steps
            '
            ' Display the Results (which adds an unwanted Undo point)
            EvaluationTabControl.SelectedIndex = EvaluationTabControl.TabPages.Count - 1
            ' Clear the Undo/Redo points (required for UpdateResultsControls to work)
            mMyStore.ClearUndoRedo()
            ' Update the results controls & tab page
            mResultsAreValid = False
            UpdateResultsControls()
            ' Clear the Undo/Redo points; there is no Undo after a Run
            mMyStore.ClearUndoRedo()
            ' Set Focus so Ctrl-R works
            EventAnalysisResultsControl.Focus()
        End Try

        Me.EndRun() ' Common World code to End a Run
    End Sub

    Private Sub SetReferenceInflowRate()
        Dim refInflow As Double = mInflowManagement.AverageInflowRateForCrossSection

        Dim setParam As BooleanParameter = mEventCriteria.ReferenceFlowRateSet
        If Not ((setParam.Value = True) And (setParam.Source = ValueSources.Calculated)) Then
            setParam.Value = True
            setParam.Source = ValueSources.Calculated
            mEventCriteria.ReferenceFlowRateSet = setParam
        End If

        Dim refParam As DoubleParameter = mEventCriteria.ReferenceFlowRate
        If Not ((refParam.Value = refInflow) And (refParam.Source = ValueSources.Calculated)) Then
            refParam.Value = refInflow
            refParam.Source = ValueSources.Calculated
            mEventCriteria.ReferenceFlowRate = refParam
        End If
    End Sub

    Private Sub ResetReferenceInflowRate()
        Dim refInflow As Double = mInflowManagement.AverageInflowRateForCrossSection

        Dim setParam As BooleanParameter = mEventCriteria.ReferenceFlowRateSet
        setParam.Source = ValueSources.Defaulted
        setParam.Value = False
        mEventCriteria.ReferenceFlowRateSet = setParam

        Dim refParam As DoubleParameter = mEventCriteria.ReferenceFlowRate
        refParam.Source = ValueSources.Defaulted
        refParam.Value = refInflow
        mEventCriteria.ReferenceFlowRate = refParam
    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal Reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated
        Select Case (Reason)
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
                SystemGeometryControl.UpdateUI()
                SoilCropPropertiesControl.UpdateUI()
                InflowRunoffControl.UpdateUI()

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
    Private Sub UnitControl_Updated(ByVal Reason As UnitControl.Reasons) _
    Handles mUnitControl.PropertyDataUpdated
        If Not (Running) Then
            Select Case (Reason)
                Case UnitControl.Reasons.SelectedTab
                    If (mUnitControl.TabGroup.Value = mSelectedGroup) Then
                        Dim selectedTab As Integer = mUnitControl.SelectedTab.Value
                        If ((0 <= selectedTab) And (selectedTab < EvaluationTabControl.TabCount)) Then
                            mSelectedTab = selectedTab
                            EvaluationTabControl.SelectedIndex = mSelectedTab
                        End If
                    Else ' tab group changed
                        ResetTabPages()
                    End If
                Case UnitControl.Reasons.TabGroup
                    ResetTabPages()
                Case Else
                    UpdateUI()
            End Select
        End If
    End Sub
    '
    ' Event Criteria changes
    '
    Private Sub EventCriteria_PropertyChanged(ByVal Reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        If Not (Running) Then
            If (Reason = EventCriteria.Reasons.EventAnalysisType) Then
                ResetTabPages()
            End If

            UpdateUI()
            CurrentAnalysis.ClearExecutionErrors()
            CurrentAnalysis.ClearExecutionWarnings()
            UpdateResultsControls()
        End If
    End Sub
    '
    ' SRFR Criteria changes
    '
    Private Sub SrfrCriteria_PropertyChanged(ByVal Reason As SrfrCriteria.Reasons) _
    Handles mSrfrCriteria.PropertyDataChanged
        If Not (Running) Then
            UpdateUI()
            CurrentAnalysis.ClearExecutionErrors()
            CurrentAnalysis.ClearExecutionWarnings()
            UpdateResultsControls()
        End If
    End Sub
    '
    ' Update UI when any System Geometry value changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal Reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        SetParametersUnknown()
    End Sub
    '
    ' Update UI when any Inflow value changes
    '
    Private Sub InflowManagement_PropertyChanged(ByVal Reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        If Not (Running) Then
            If (Reason = InflowManagement.Reasons.FieldMeasurements) Then
                ResetTabPages()
            End If
        End If
    End Sub
    '
    ' Update UI when any Soil/Crop Property value changes
    '
    Private Sub SoilCropProperties_PropertyChanged(ByVal Reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        SetParametersUnknown()
    End Sub

    Private Sub SetParametersUnknown()
        If (mUnit.UnitType.Value = WorldTypes.EventWorld) Then
            If Not (Running) Then
                mSoilCropProperties.ErodibilityAProperty.ToBeCalculated = True
                mSoilCropProperties.ErodibilityBProperty.ToBeCalculated = True
                mSoilCropProperties.ErodibilityTaucProperty.ToBeCalculated = True
                mSoilCropProperties.ErodibilityBetaProperty.ToBeCalculated = True

                CurrentAnalysis.ClearExecutionErrors()
                CurrentAnalysis.ClearExecutionWarnings()
            End If
        End If
    End Sub

    Protected Overrides Sub SetKnown()
        mSoilCropProperties.ErodibilityAProperty.ToBeCalculated = False
        mSoilCropProperties.ErodibilityBProperty.ToBeCalculated = False
        mSoilCropProperties.ErodibilityTaucProperty.ToBeCalculated = False
        mSoilCropProperties.ErodibilityBetaProperty.ToBeCalculated = False
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " Event Menu "

    Private Sub EventMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WorldMenu.Popup
        Me.Focus()
        ' Setup Errors prevent Run
        If (CurrentAnalysis.HasSetupErrors) Then
            RunAnalysisItem.Enabled = False
        Else
            RunAnalysisItem.Enabled = True
        End If

        If (Me.EvaluationTabControl.SelectedTab.Text = mDictionary.tRoughness.Translated) Then
            Me.SelectGoodnessOfFitMethod.Visible = True

            Me.IndexOfAgreementItem.Checked = False
            Me.PercentBiasItem.Checked = False
            Me.RmseStandardRatioItem.Checked = False
            Me.NashSutcliffeItem.Checked = False

            Me.IndexOfAgreementItem.Visible = False
            Me.RmseStandardRatioItem.Visible = False

            Dim GoodnessOfFitMethod As GoodnessOfFitMethods = mEventCriteria.GoodnessOfFitMethod.Value
            Select Case (GoodnessOfFitMethod)
                'Case GoodnessOfFitMethods.IndexOfAgreementD
                '    Me.IndexOfAgreementItem.Checked = True
                'Case GoodnessOfFitMethods.RMSEstandardRatio
                '    Me.RmseStandardRatioItem.Checked = True
                Case GoodnessOfFitMethods.PercentBias
                    Me.PercentBiasItem.Checked = True
                Case Else ' Assume GoodnessOfFitMethods.NashSutcliffeE
                    Me.NashSutcliffeItem.Checked = True
            End Select
        Else
            Me.SelectGoodnessOfFitMethod.Visible = False
        End If

    End Sub

    Private Sub NashSutcliffeItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NashSutcliffeItem.Click
        Dim gofParam As IntegerParameter = mEventCriteria.GoodnessOfFitMethod
        Dim gofMethod As Integer = gofParam.Value

        If (Not gofMethod = GoodnessOfFitMethods.NashSutcliffeE) Then
            mMyStore.MarkForUndo(GoodnessOfFitMethodSelections(GoodnessOfFitMethods.NashSutcliffeE).Value)
            gofParam.Value = GoodnessOfFitMethods.NashSutcliffeE
            gofParam.Source = ValueSources.UserEntered
            mEventCriteria.GoodnessOfFitMethod = gofParam
        End If
    End Sub

    Private Sub IndexOfAgreementItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles IndexOfAgreementItem.Click
        Dim gofParam As IntegerParameter = mEventCriteria.GoodnessOfFitMethod
        Dim gofMethod As Integer = gofParam.Value

        If (Not gofMethod = GoodnessOfFitMethods.IndexOfAgreementD) Then
            mMyStore.MarkForUndo(GoodnessOfFitMethodSelections(GoodnessOfFitMethods.IndexOfAgreementD).Value)
            gofParam.Value = GoodnessOfFitMethods.IndexOfAgreementD
            gofParam.Source = ValueSources.UserEntered
            mEventCriteria.GoodnessOfFitMethod = gofParam
        End If
    End Sub

    Private Sub PercentBiasItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PercentBiasItem.Click
        Dim gofParam As IntegerParameter = mEventCriteria.GoodnessOfFitMethod
        Dim gofMethod As Integer = gofParam.Value

        If (Not gofMethod = GoodnessOfFitMethods.PercentBias) Then
            mMyStore.MarkForUndo(GoodnessOfFitMethodSelections(GoodnessOfFitMethods.PercentBias).Value)
            gofParam.Value = GoodnessOfFitMethods.PercentBias
            gofParam.Source = ValueSources.UserEntered
            mEventCriteria.GoodnessOfFitMethod = gofParam
        End If
    End Sub

    Private Sub RmseStandardRatioItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RmseStandardRatioItem.Click
        Dim gofParam As IntegerParameter = mEventCriteria.GoodnessOfFitMethod
        Dim gofMethod As Integer = gofParam.Value

        If (Not gofMethod = GoodnessOfFitMethods.RMSEstandardRatio) Then
            mMyStore.MarkForUndo(GoodnessOfFitMethodSelections(GoodnessOfFitMethods.RMSEstandardRatio).Value)
            gofParam.Value = GoodnessOfFitMethods.RMSEstandardRatio
            gofParam.Source = ValueSources.UserEntered
            mEventCriteria.GoodnessOfFitMethod = gofParam
        End If
    End Sub

    Private Sub RunEventAnalysisItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunAnalysisItem.Click
        RunEventAnalysis()
    End Sub

#End Region

#Region " Help Menu "

    Private Sub HelpMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles HelpMenu.Popup
        If (mAnalysis IsNot Nothing) Then
            If (mAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                Me.HelpSoilCropItem.Visible = False
                Me.HelpAnalysisItem.Visible = True
            ElseIf (mAnalysis.GetType Is GetType(InfiltratedProfile)) Then
                Me.HelpSoilCropItem.Visible = False
                Me.HelpAnalysisItem.Visible = False
            ElseIf (mAnalysis.GetType Is GetType(MerriamKeller)) Then
                Me.HelpSoilCropItem.Visible = True
                Me.HelpAnalysisItem.Visible = True
            ElseIf (mAnalysis.GetType Is GetType(EVALUE)) Then
                Me.HelpSoilCropItem.Visible = True
                Me.HelpAnalysisItem.Visible = True
            End If
        End If
    End Sub

    Private Sub HelpEventWorldItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles HelpEventWorldItem.Click
        WinSrfr.ShowPdfHelpManual("ch:Evaluation")
    End Sub

    Private Sub HelpStartItem_Click(sender As Object, e As EventArgs) Handles HelpStartItem.Click
        If (mAnalysis IsNot Nothing) Then
            If (mAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                WinSrfr.ShowPdfHelpManual("sec:TwoPoint")
            ElseIf (mAnalysis.GetType Is GetType(InfiltratedProfile)) Then
                WinSrfr.ShowPdfHelpManual("sec:Probe")
            ElseIf (mAnalysis.GetType Is GetType(MerriamKeller)) Then
                WinSrfr.ShowPdfHelpManual("sec:PIVB")
            ElseIf (mAnalysis.GetType Is GetType(EVALUE)) Then
                WinSrfr.ShowPdfHelpManual("sec:EvalueInputs")
            End If
        End If
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
        WinSrfr.ShowPdfHelpManual("sec:HydraulicResistance")
    End Sub

    Private Sub HelpInflowRunoffItem_Click(sender As Object, e As EventArgs) _
        Handles HelpInflowRunoffItem.Click
        WinSrfr.ShowPdfHelpManual("sec:InflowRunoff")
    End Sub

    Private Sub HelpInputsItem_Click(sender As Object, e As EventArgs) _
        Handles HelpInputsItem.Click
        If (mAnalysis IsNot Nothing) Then
            If (mAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                WinSrfr.ShowPdfHelpManual("sec:TwoPointInputs")
            ElseIf (mAnalysis.GetType Is GetType(InfiltratedProfile)) Then
                WinSrfr.ShowPdfHelpManual("sec:ProbeInputs")
            ElseIf (mAnalysis.GetType Is GetType(MerriamKeller)) Then
                WinSrfr.ShowPdfHelpManual("sec:PIVBInputs")
            ElseIf (mAnalysis.GetType Is GetType(EVALUE)) Then
                WinSrfr.ShowPdfHelpManual("sec:EvalueInputs")
            End If
        End If
    End Sub

    Private Sub HelpAnalysisItem_Click(sender As Object, e As EventArgs) _
        Handles HelpAnalysisItem.Click
        If (mAnalysis IsNot Nothing) Then
            If (mAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                WinSrfr.ShowPdfHelpManual("sec:TwoPointAnalysis")
            ElseIf (mAnalysis.GetType Is GetType(InfiltratedProfile)) Then
                WinSrfr.ShowPdfHelpManual("sec:ProbeOutputs")
            ElseIf (mAnalysis.GetType Is GetType(MerriamKeller)) Then
                WinSrfr.ShowPdfHelpManual("sec:PIVBAnalysis")
            ElseIf (mAnalysis.GetType Is GetType(EVALUE)) Then
                WinSrfr.ShowPdfHelpManual("sec:EvalueAnalysis")
            End If
        End If
    End Sub

    Private Sub HelpVerifyItem_Click(sender As Object, e As EventArgs) _
        Handles HelpVerifyItem.Click
        If (mAnalysis IsNot Nothing) Then
            If (mAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                WinSrfr.ShowPdfHelpManual("sec:TwoPointAnalysis")
            ElseIf (mAnalysis.GetType Is GetType(InfiltratedProfile)) Then
                WinSrfr.ShowPdfHelpManual("sec:ProbeExecution")
            ElseIf (mAnalysis.GetType Is GetType(MerriamKeller)) Then
                WinSrfr.ShowPdfHelpManual("sec:PIVBExecution")
            ElseIf (mAnalysis.GetType Is GetType(EVALUE)) Then
                WinSrfr.ShowPdfHelpManual("sec:EvalueAnalysis")
            End If
        End If
    End Sub

    Private Sub HelpResultsItem_Click(sender As Object, e As EventArgs) _
        Handles HelpResultsItem.Click
        If (mAnalysis IsNot Nothing) Then
            If (mAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                WinSrfr.ShowPdfHelpManual("sec:TwoPointOutputs")
            ElseIf (mAnalysis.GetType Is GetType(InfiltratedProfile)) Then
                WinSrfr.ShowPdfHelpManual("sec:ProbeOutputs")
            ElseIf (mAnalysis.GetType Is GetType(MerriamKeller)) Then
                WinSrfr.ShowPdfHelpManual("sec:PIVBOutputs")
            ElseIf (mAnalysis.GetType Is GetType(EVALUE)) Then
                WinSrfr.ShowPdfHelpManual("sec:EvalueOutputs")
            End If
        End If
    End Sub

    Protected Overrides Sub HelpF1()

        Dim destination As String = "ch:Evaluation"
        Dim offset As Single = 0

        Dim curTab As TabPage = Me.EvaluationTabControl.SelectedTab
        If (curTab IsNot Nothing) Then

            If (curTab Is Me.EventWorldTabPage) Then

                If (mAnalysis IsNot Nothing) Then
                    If (mAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                        destination = "sec:TwoPoint"
                    ElseIf (mAnalysis.GetType Is GetType(InfiltratedProfile)) Then
                        destination = "sec:Probe"
                    ElseIf (mAnalysis.GetType Is GetType(MerriamKeller)) Then
                        destination = "sec:PIVB"
                    ElseIf (mAnalysis.GetType Is GetType(EVALUE)) Then
                        destination = "sec:EvalueInputs"
                    End If
                End If

            ElseIf (0 < curTab.Controls.Count) Then

                If (mAnalysis IsNot Nothing) Then
                    If (mAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then

                        Dim curCtrl As Control = curTab.Controls(0)
                        If (curCtrl.GetType Is GetType(ctl_SystemGeometry)) Then
                            destination = "sec:TwoPointInputs"
                            offset = 200
                        ElseIf (curCtrl.GetType Is GetType(ctl_InflowRunoff)) Then
                            destination = "sec:TwoPointInputs"
                            offset = 200
                        ElseIf (curCtrl.GetType Is GetType(ctl_AdvanceRecession)) Then
                            destination = "sec:TwoPointInputs"
                            offset = 300

                        ElseIf (curCtrl.GetType Is GetType(ctl_VolumeBalances)) Then
                            destination = "sec:TwoPointAnalysis"
                            offset = 200
                        ElseIf (curCtrl.GetType Is GetType(ctl_SurfaceVolumeEstimated)) Then
                            destination = "sec:TwoPointAnalysis"
                            offset = 300
                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationInfiltration)) Then
                            destination = "sec:TwoPointAnalysis"
                            offset = 800

                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationExecution)) Then
                            destination = "sec:TwoPointAnalysis"
                            offset = 1600
                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationResults)) Then
                            destination = "sec:TwoPointOutputs"
                            offset = 200
                        Else
                            destination = "sec:TwoPoint"
                        End If

                    ElseIf (mAnalysis.GetType Is GetType(InfiltratedProfile)) Then

                        Dim curCtrl As Control = curTab.Controls(0)
                        If (curCtrl.GetType Is GetType(ctl_SystemGeometry)) Then
                            destination = "sec:ProbeInputs"
                        ElseIf (curCtrl.GetType Is GetType(ctl_InflowRunoff)) Then
                            destination = "sec:ProbeInputs"
                        ElseIf (curCtrl.GetType Is GetType(ctl_InfiltratedProfile)) Then
                            destination = "sec:ProbeInputs"
                            offset = 250
                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationExecution)) Then
                            destination = "sec:ProbeExecution"
                            offset = 200
                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationResults)) Then
                            destination = "sec:ProbeExecution"
                            offset = 300
                        Else
                            destination = "sec:Probe"
                        End If

                    ElseIf (mAnalysis.GetType Is GetType(MerriamKeller)) Then

                        Dim curCtrl As Control = curTab.Controls(0)
                        If (curCtrl.GetType Is GetType(ctl_SystemGeometry)) Then
                            destination = "sec:PIVBInputs"
                            offset = 100
                        ElseIf (curCtrl.GetType Is GetType(ctl_InflowRunoff)) Then
                            destination = "sec:PIVBInputs"
                            offset = 100
                        ElseIf (curCtrl.GetType Is GetType(ctl_SoilCropProperties)) Then
                            destination = "sec:HydraulicResistance"
                            offset = 100
                        ElseIf (curCtrl.GetType Is GetType(ctl_AdvanceRecession)) Then
                            destination = "sec:PIVBInputs"
                            offset = 300

                        ElseIf (curCtrl.GetType Is GetType(ctl_VolumeBalances)) Then
                            destination = "sec:PIVBAnalysis"
                            offset = 100
                        ElseIf (curCtrl.GetType Is GetType(ctl_Roughness)) Then
                            destination = "sec:HydraulicResistance"
                            offset = 100
                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationInfiltration)) Then
                            destination = "sec:PIVBAnalysis"
                            offset = 200

                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationExecution)) Then
                            destination = "sec:PIVBAnalysis"
                            offset = 400
                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationResults)) Then
                            destination = "sec:PIVBOutputs"
                            offset = 100
                        Else
                            destination = "sec:PIVB"
                        End If

                    ElseIf (mAnalysis.GetType Is GetType(EVALUE)) Then

                        Dim curCtrl As Control = curTab.Controls(0)
                        If (curCtrl.GetType Is GetType(ctl_SystemGeometry)) Then
                            If (mUnit IsNot Nothing) Then
                                If (mUnit.CrossSection = CrossSections.Furrow) Then
                                    destination = "sec:FurrowGeometry"
                                Else
                                    destination = "sec:BorderGeometry"
                                End If
                            Else
                                destination = "sec:GeometryTab"
                            End If
                        ElseIf (curCtrl.GetType Is GetType(ctl_InflowRunoff)) Then
                            destination = "sec:InflowRunoff"
                        ElseIf (curCtrl.GetType Is GetType(ctl_SoilCropProperties)) Then
                            destination = "sec:HydraulicResistance"
                        ElseIf (curCtrl.GetType Is GetType(ctl_AdvanceRecession)) Then
                            destination = "sec:EvalueInputs"
                            offset = 300
                        ElseIf (curCtrl.GetType Is GetType(ctl_FlowDepths)) Then
                            destination = "sec:EvalueInputs"
                            offset = 325

                        ElseIf (curCtrl.GetType Is GetType(ctl_VolumeBalances)) Then
                            destination = "sec:EvalueAnalysis"
                            offset = -500
                        ElseIf (curCtrl.GetType Is GetType(ctl_SurfaceVolumeEstimated)) Then
                            destination = "sec:EvalueAnalysis"
                            offset = 1200
                        ElseIf (curCtrl.GetType Is GetType(ctl_SurfaceVolumeMeasured)) Then
                            destination = "sec:EvalueAnalysis"
                            offset = 1100
                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationInfiltration)) Then
                            destination = "sec:EvalueAnalysis"
                            offset = 1850
                        ElseIf (curCtrl.GetType Is GetType(ctl_EvalueRoughness)) Then
                            destination = "sec:EvalueAnalysis"
                            offset = 3200

                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationExecution)) Then
                            destination = "sec:EvalueAnalysis"
                            offset = 3400
                        ElseIf (curCtrl.GetType Is GetType(ctl_EvaluationResults)) Then
                            destination = "sec:EvalueOutputs"
                            offset = 275
                        Else
                            destination = "sec:Evalue"
                        End If
                    End If

                End If ' (mAnalysis IsNot Nothing)
            End If ' (0 < curTab.Controls.Count)
        End If ' (curTab IsNot Nothing)

        WinSrfr.ShowPdfHelpManual(destination, offset)

    End Sub

#End Region

#Region " Tab Control "

    Private mHandlingSelectedIndexChanged As Boolean = False
    Private Sub EvaluationTabControl_SelectedIndexChanged(ByVal sender As System.Object,
                                                          ByVal e As System.EventArgs) _
    Handles EvaluationTabControl.SelectedIndexChanged

        If Not (mHandlingSelectedIndexChanged) Then ' ignore recursive calls
            mHandlingSelectedIndexChanged = True

            Dim _tabIndex As Integer = EvaluationTabControl.SelectedIndex
            Dim _tabText As String = EvaluationTabControl.TabPages(_tabIndex).Text

            If ((mMyStore.InUndo) Or (mMyStore.InRedo)) Then
                If (_tabText = mDictionary.tDataTabs.Translated) Then
                    ResetTabPages()
                ElseIf (_tabText = mDictionary.tAnalysisTabs.Translated) Then
                    ResetTabPages()
                End If

                mHandlingSelectedIndexChanged = False
                Return
            End If

            If Not (mResetingTabs) Then ' ignore selected tab changes during reset

                ' Wait for a valid tab page to be selected then save the selection
                If (-1 < EvaluationTabControl.SelectedIndex) Then
                    If (mUnit IsNot Nothing) Then

                        ' Get the current Selected Tab value
                        Dim _tabParam As DataStore.IntegerParameter = mUnitControl.SelectedTab

                        ' Only update if the value has changed
                        If Not (_tabParam.Value = EvaluationTabControl.SelectedIndex) Then

                            ' Mark this as an Undo point
                            mMyStore.MarkForUndo(mDictionary.tTabPageSelection.Translated)

                            ' Display Results page number when visible
                            If (_tabText = mDictionary.tResults.Translated) Then
                                Me.EventAnalysisResultsControl.DisplayResultsPageNumber()
                            Else
                                Me.ProgressMessage = ""
                            End If

                            Dim _groupParam As DataStore.IntegerParameter = mUnitControl.TabGroup

                            If (_tabText = mDictionary.tDataTabs.Translated) Then

                                If (EvaluationTabControl.SelectedIndex = 0) Then
                                    _tabParam.Value = 1
                                Else
                                    _tabParam.Value = 99
                                End If
                                _tabParam.Source = DataStore.Globals.ValueSources.UserEntered
                                mUnitControl.SelectedTab = _tabParam

                                mSelectedGroup = TabGroups.DataTabs
                                _groupParam.Value = mSelectedGroup
                                _groupParam.Source = ValueSources.UserEntered
                                mUnitControl.TabGroup = _groupParam

                            ElseIf (_tabText = mDictionary.tAnalysisTabs.Translated) Then

                                _tabParam.Value = -99
                                _tabParam.Source = DataStore.Globals.ValueSources.UserEntered
                                mUnitControl.SelectedTab = _tabParam

                                mSelectedGroup = TabGroups.AnalysisTabs
                                _groupParam.Value = mSelectedGroup
                                _groupParam.Source = ValueSources.UserEntered
                                mUnitControl.TabGroup = _groupParam

                            Else
                                ' Save the new tab selected
                                mSelectedTab = EvaluationTabControl.SelectedIndex
                                _tabParam.Value = mSelectedTab
                                _tabParam.Source = DataStore.Globals.ValueSources.UserEntered
                                mUnitControl.SelectedTab = _tabParam
                            End If

                            ' Update the UI
                            UpdateToolbar()
                            'UpdateResultsControls()

                        End If
                    End If
                End If
            End If

            mHandlingSelectedIndexChanged = False
        End If

    End Sub

#End Region

#End Region

End Class
