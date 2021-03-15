
'**********************************************************************************************
' ctl_EvaluationResults - Control for displaying the WinSRFR computation results
'
Imports System.Drawing.Printing

Imports DataStore
Imports GraphingUI
Imports PrintingUI
Imports Srfr

Public Class ctl_EvaluationResults
    Inherits System.Windows.Forms.TabControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeResults()

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
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
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ctl_EvaluationResults))
        Me.PrintDialog = New System.Windows.Forms.PrintDialog
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog = New System.Windows.Forms.PrintPreviewDialog
        '
        'PrintDialog
        '
        Me.PrintDialog.AllowSomePages = True
        Me.PrintDialog.Document = Me.PrintDocument
        '
        'PrintDocument
        '
        '
        'PrintPreviewDialog
        '
        Me.PrintPreviewDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog.Document = Me.PrintDocument
        Me.PrintPreviewDialog.Enabled = True
        Me.PrintPreviewDialog.Icon = CType(resources.GetObject("PrintPreviewDialog.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog.Location = New System.Drawing.Point(17, 54)
        Me.PrintPreviewDialog.MinimumSize = New System.Drawing.Size(375, 250)
        Me.PrintPreviewDialog.Name = "PrintPreviewDialog"
        Me.PrintPreviewDialog.TransparencyKey = System.Drawing.Color.Empty
        Me.PrintPreviewDialog.Visible = False
        '
        'ctl_EvaluationResults
        '
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Multiline = True

    End Sub

#End Region

#Region " Constants "
    '
    ' Resolve reference conflicts between DataStore & Srfr
    '
    Protected Const OneMillimeter As Double = Srfr.Globals.OneMillimeter
    Protected Const OneCentimeter As Double = Srfr.Globals.OneCentimeter
    Protected Const OneMeter As Double = Srfr.Globals.OneMeter

    Protected Const MillimetersPerMeter As Double = Srfr.Globals.MillimetersPerMeter
    Protected Const CentimetersPerMeter As Double = Srfr.Globals.CentimetersPerMeter

    Protected Const OneSecond As Double = Srfr.Globals.OneSecond
    Protected Const TenSeconds As Double = Srfr.Globals.TenSeconds
    Protected Const OneMinute As Double = Srfr.Globals.OneMinute
    Protected Const OneHour As Double = Srfr.Globals.OneHour
    Protected Const SecondsPerMinute As Double = Srfr.Globals.SecondsPerMinute
    Protected Const SecondsPerHour As Double = Srfr.Globals.SecondsPerHour

    Protected Const LiterPerSecond As Double = Srfr.Globals.LiterPerSecond

#End Region

#Region " Member Data "

#Region " TabControl Data "

    Private mSelectedIndex As Integer = 0

#End Region

#Region " Results Page Data "
    '
    ' Define the size & margins of the results page (in pixels)
    '
    ' Note - 100 pixels = 1 inch
    '
    Private Const PortraitPageWidth As Integer = 850
    Private Const PortraitPageLength As Integer = 1100

    Private Const PortraitTopMargin As Integer = 50
    Private Const PortraitLeftMargin As Integer = 75
    Private Const PortraitRightMargin As Integer = 75
    Private Const PortraitBottomMargin As Integer = 50

    Private Const LandscapePageWidth As Integer = 1100
    Private Const LandscapePageLength As Integer = 850

    Private Const LandscapeTopMargin As Integer = 70
    Private Const LandscapeLeftMargin As Integer = 75
    Private Const LandscapeRightMargin As Integer = 75
    Private Const LandscapeBottomMargin As Integer = 60

    Private Const TopOffset As Integer = 25
    Private Const LeftOffset As Integer = 25

    Private Const PortraitHeightLines As Integer = 58
    Private Const PortraitWidthChars As Integer = 74

    Private Const LandscapeHeightLines As Integer = 42
    Private Const LandscapeWidthChars As Integer = 104
    '
    ' Define the size & location of the graphic region (in pixels)
    '
    Private Const PortraitGraphTop As Integer = 175
    Private Const PortraitGraphLeft As Integer = 75
    Private Const PortraitGraphWidth As Integer = 700
    Private Const PortraitGraphHeight As Integer = 800

    Private ReadOnly PortraitGraphSize As Size = New Size(PortraitGraphWidth, PortraitGraphHeight)
    Private ReadOnly PortraitGraphLocation As Point = New Point(PortraitGraphLeft, PortraitGraphTop)

    Private Const LandscapeGraphTop As Integer = 170
    Private Const LandscapeGraphLeft As Integer = 75
    Private Const LandscapeGraphWidth As Integer = 950
    Private Const LandscapeGraphHeight As Integer = 570

    Private ReadOnly LandscapeGraphSize As Size = New Size(LandscapeGraphWidth, LandscapeGraphHeight)
    Private ReadOnly LandscapeGraphLocation As Point = New Point(LandscapeGraphLeft, LandscapeGraphTop)
    '
    ' Array of Results Pages & Panels
    '
    Private mResultsPages As ArrayList
    Private mResultsPanels As ArrayList
    Private mPageNumber As Integer
    Private mTotalPages As Integer
    '
    ' Disposed event must be handled for these Components
    '

    ' Common pages
    Private WithEvents mInputSummaryPage As RichTextBox
    Private WithEvents mAdvRecOppPage As RichTextBox
    Private WithEvents mVolumeBalancePage As RichTextBox
    Private WithEvents mPerformanceSummaryPage As RichTextBox

    Private mVolumeBalanceRtfPage As RtfPage
    Private mPerformanceSummaryRtfPage As RtfPage

    ' Infiltrated Profile Analysis
    Private WithEvents mIpaSoilWaterDeficitPage As RichTextBox
    Private WithEvents mIpaInfiltratedDepthsPage As RichTextBox
    Private WithEvents mIpaPerformanceAnalysisPage As RichTextBox

    ' Merriam-Keller Analysis
    Private WithEvents mMkGoodnessPage As RichTextBox

    ' Elliott-Walker Two-Point Analysis
    Private WithEvents mEwTwoPointPage As RichTextBox
    Private WithEvents mEwGoodnessPage As RichTextBox

    ' Erosion Analysis
    Private WithEvents mErosionParametersPage As RichTextBox

    ' EVALUE Analysis
    Private WithEvents mSurfaceFlowMeasuredRtfPage As RtfPage
    Private WithEvents mSurfaceFlowMeasuredPage As RichTextBox
    Private WithEvents mEvalueGoodnessPage As RichTextBox
    '
    ' Errors & Warnings
    '
    Private mDrzUnderestimation As Boolean

    Private mWarning1 As String
    Private mWarning2 As String
    '
    ' Printing support
    '
    Private mPageSelections() As Integer = {1, 1}   ' Array of pages selected to print
    Private mNextPageSelection As Integer = 0       ' Index of next page selection
    Private mNextPageNo As Integer = 1              ' Next page number to print
    '
    ' Misc.
    '
    Private Const Blanks As String = "                                          "

#End Region

#End Region

#Region " Properties "

    Private mResultsView As ResultsViews = Globals.ResultsViews.PortraitPage
    Public Property ResultsView() As ResultsViews
        Get
            Return mResultsView
        End Get
        Set(ByVal Value As ResultsViews)
            If Not (mResultsView = Value) Then
                mResultsView = Value
                UpdateUI()
            End If
        End Set
    End Property

    Public ReadOnly Property NumberOfPages() As Integer
        Get
            Return mResultsPages.Count
        End Get
    End Property

    Public Function ResultsAreDisplayed() As Boolean
        ResultsAreDisplayed = False
        If (3 < Me.TabCount) Then
            ResultsAreDisplayed = True
        End If
    End Function

#End Region

#Region " Initialization "

    Private Sub InitializeResults()

        mResultsPages = New ArrayList
        mResultsPanels = New ArrayList

        PrintPreviewDialog.Size = New Size(700, 500)

        Me.DrawMode = TabDrawMode.OwnerDrawFixed        ' User Draw tabs via DrawItem event

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mUnit As Unit
    Private mSystemGeometry As SystemGeometry
    Private mSoilCropProperties As SoilCropProperties
    Private mInflowManagement As InflowManagement
    Private mBorderCriteria As BorderCriteria
    Private mEventCriteria As EventCriteria
    Private mErosion As Erosion
    Private mSrfrResults As SrfrResults
    Private mSurfaceFlow As SurfaceFlow
    Private mSubsurfaceFlow As SubsurfaceFlow
    Private mPerformanceResults As PerformanceResults
    Private mUnitControl As UnitControl

    Private mWorldWindow As WorldWindow
    Private mWinSRFR As WinSRFR
    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    Public Sub LinkToModel(ByVal _unit As Unit, ByVal _worldForm As WorldWindow)

        If (_unit IsNot Nothing) Then

            ' Link this control to its model
            mUnit = _unit
            mSystemGeometry = mUnit.SystemGeometryRef
            mSoilCropProperties = mUnit.SoilCropPropertiesRef
            mInflowManagement = mUnit.InflowManagementRef
            mBorderCriteria = mUnit.BorderCriteriaRef
            mEventCriteria = mUnit.EventCriteriaRef
            mErosion = mUnit.ErosionRef
            mSrfrResults = mUnit.SrfrResultsRef
            mSurfaceFlow = mUnit.SurfaceFlowRef
            mSubsurfaceFlow = mUnit.SubsurfaceFlowRef
            mPerformanceResults = mUnit.PerformanceResultsRef
            mUnitControl = mUnit.UnitControlRef

            mWorldWindow = _worldForm
            mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef

            mResultsView = WinSRFR.UserPreferences.ResultsView

            ' Update this control's User Interface
            UpdateUI()
        End If
    End Sub

    Protected Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits

        If (mUnit IsNot Nothing) Then
            ' Redraw the text pages
            Select Case mUnit.UnitType.Value
                Case WorldTypes.EventWorld
                    UpdateEventAnalysisPages()
                Case Else
                    Debug.Assert(False, "Support for this World must be added")
            End Select
        End If
    End Sub

#End Region

#Region " Display Results Methods "

#Region " Evaluation Results "
    '
    ' DisplayEvaluationResults() - displays the Evaluation results in the Results Control.
    '
    Private Sub DisplayEvaluationResults()
        If (mUnit IsNot Nothing) Then

            Select Case mEventCriteria.EventAnalysisType.Value

                Case EventAnalysisTypes.InfiltratedProfileAnalysis
                    DisplayInfiltratedProfileAnalysisResults()

                Case EventAnalysisTypes.MerriamKellerAnalysis
                    DisplayMerriamKellerAnalysisResults()

                Case EventAnalysisTypes.TwoPointAnalysis
                    DisplayElliotWalkerTwoPointAnalysisResults()

                Case EventAnalysisTypes.ErosionAnalysis
                    DisplayErosionParametersResults()

                Case EventAnalysisTypes.EvalueAnalysis
                    DisplayEvalueAnalysisResults()

                Case Else
                    Debug.Assert(False) ' Support for this Event Analysis Type must be added
            End Select
        End If

    End Sub

    Private Sub UpdateEventAnalysisPages()
        If (mUnit IsNot Nothing) Then

            Select Case mEventCriteria.EventAnalysisType.Value

                Case EventAnalysisTypes.InfiltratedProfileAnalysis
                    Me.UpdateInputSummaryPage()
                    Me.UpdateIpaSoilWaterDeficitPage()
                    Me.UpdateIpaInfiltratedDepthsPage()
                    Me.UpdateIpaPerformanceAnalysisPage()

                Case EventAnalysisTypes.MerriamKellerAnalysis
                    Me.UpdateInputSummaryPage()
                    Me.UpdateAdvanceRecessionTablePage()
                    Me.UpdateVolumeBalancePage()
                    Me.UpdatePerformanceSummaryPage()
                    Me.UpdateMkGoodnessOfFitPage()

                Case EventAnalysisTypes.TwoPointAnalysis
                    Me.UpdateInputSummaryPage()
                    Me.UpdateVolumeBalancePage()
                    Me.UpdatePerformanceSummaryPage()
                    Me.UpdateEwGoodnessOfFitPage()

                Case EventAnalysisTypes.ErosionAnalysis
                    Me.UpdateErosionParametersPage()

                Case EventAnalysisTypes.EvalueAnalysis
                    Me.UpdateInputSummaryPage()
                    Me.UpdateAdvanceRecessionTablePage()
                    If (mInflowManagement.FlowDepthsMeasuredAndUsed) Then
                        Me.UpdateSurfaceFlowMeasuredPage()
                    End If
                    Me.UpdateVolumeBalancePage()
                    Me.UpdatePerformanceSummaryPage()
                    Me.UpdateEvalueGoodnessOfFitPage()

                Case Else
                    Debug.Assert(False) ' Support for this Event Analysis Type must be added
            End Select
        End If

    End Sub

#End Region

#Region " Infiltrated Profile Analysis "
    '
    ' Infiltrated Profile Analysis
    '
    Private Sub DisplayInfiltratedProfileAnalysisResults()

        If (mUnit IsNot Nothing) Then

            mPageNumber = 0
            mTotalPages = 6

            ' Input Summary Page
            Dim title As String = mDictionary.tInputSummary.Translated
            AddInputSummaryPage(title)

            ' Soil Water Deficit Page
            title = mDictionary.tSoilWaterDeficit.Translated
            AddIpaSoilWaterDeficitPage(title)

            ' Infiltrated Depths Page
            title = mDictionary.tInfiltratedDepths.Translated
            AddIpaInfiltratedDepthsPage(title)

            ' Inflow / Runoff Page
            title = mDictionary.tInflow.Translated & " / " & mDictionary.tRunoff.Translated
            AddInflowRunoffGraphPage(title)

            ' Infiltrated Depths Page
            title = mDictionary.tInfiltratedDepths.Translated
            AddIpaInfiltratedDepthsGraphPage(title)

            ' Performance Analysis Page
            title = mDictionary.tPerformanceAnalysis.Translated
            AddIpaPerformanceAnalysisPage(title)

        End If
    End Sub
    '
    ' Pre-Irrigation
    '
    Private Sub AddIpaSoilWaterDeficitPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mIpaSoilWaterDeficitPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Irrigation Requirements
        mPageNumber += 1
        mIpaPreIrrigationPageNumber = mPageNumber
        UpdateIpaSoilWaterDeficitPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mIpaPreIrrigationPageNumber As Integer
    Private Sub UpdateIpaSoilWaterDeficitPage()

        If (mIpaSoilWaterDeficitPage IsNot Nothing) Then
            ' mIpaSoilWaterDeficitPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mIpaSoilWaterDeficitPage.Clear()

                ' Header
                DisplayResultsHeader(mIpaSoilWaterDeficitPage)

                ' Section Title
                mIpaSoilWaterDeficitPage.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(mIpaSoilWaterDeficitPage, mDictionary.tPreIrrigationMeasurements.Translated)

                ' Soil Water Depletion Table
                DisplaySwdTable(mIpaSoilWaterDeficitPage)

                ' Irrigation Requirements
                DisplayIrrigationRequirements(mIpaSoilWaterDeficitPage)

                ' Display Warnings, if any
                Dim _warnings As Boolean = False

                AdvanceLine(mIpaSoilWaterDeficitPage)
                AppendBoldLine(mIpaSoilWaterDeficitPage, mDictionary.tWarnings.Translated)

                If Not (mWarning1 Is String.Empty) Then
                    _warnings = True
                    AppendID(mIpaSoilWaterDeficitPage, _
                        mWarning1, mDictionary.tCumulativeProfileDepthLtRootZoneDepthID.Translated)
                End If

                If Not (mWarning2 Is String.Empty) Then
                    _warnings = True
                    AppendID(mIpaSoilWaterDeficitPage, _
                        mWarning2, mDictionary.tProbeLengthLtRootZoneDepthID.Translated)
                End If

                If Not (_warnings) Then
                    AppendLine(mIpaSoilWaterDeficitPage, "  -- " & mDictionary.tNone.Translated & " --")
                End If

                ' Footer
                DisplayResultsFooter(mIpaSoilWaterDeficitPage, mIpaPreIrrigationPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mIpaSoilWaterDeficitPage = Nothing
            End Try
        End If

    End Sub
    '
    ' Probe Measurements & Infiltrated Depths
    '
    Private Sub AddIpaInfiltratedDepthsPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mIpaInfiltratedDepthsPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Event Analysis Parameters
        mPageNumber += 1
        mIpaInfiltratedDepthsPageNumber = mPageNumber
        UpdateIpaInfiltratedDepthsPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mIpaInfiltratedDepthsPageNumber As Integer
    Private Sub UpdateIpaInfiltratedDepthsPage()

        If (mIpaInfiltratedDepthsPage IsNot Nothing) Then
            ' mIpaInfiltratedDepthsPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mIpaInfiltratedDepthsPage.Clear()

                ' Header
                DisplayResultsHeader(mIpaInfiltratedDepthsPage)

                ' Section Title
                mIpaInfiltratedDepthsPage.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(mIpaInfiltratedDepthsPage, mDictionary.tPostIrrigationMeasurements.Translated)

                ' Infiltrated Depths Table
                DisplayIdTable(mIpaInfiltratedDepthsPage)

                ' Display Warnings, if any
                Dim _warnings As Boolean = False

                AdvanceLine(mIpaInfiltratedDepthsPage)
                AppendBoldLine(mIpaInfiltratedDepthsPage, mDictionary.tWarnings.Translated)

                If Not (mWarning1 Is String.Empty) Then
                    _warnings = True
                    AppendID(mIpaInfiltratedDepthsPage, mWarning1, mDictionary.tRootZoneInfiltrationUnderestimatedID.Translated)
                    AppendDetail(mIpaInfiltratedDepthsPage, mDictionary.tRootZoneInfiltrationUnderestimatedDetail.Translated)
                End If

                If Not (mWarning2 Is String.Empty) Then
                    _warnings = True
                    AppendID(mIpaInfiltratedDepthsPage, mWarning2, mDictionary.tLeachingRequirementUnderestimatedID.Translated)
                    AppendDetail(mIpaInfiltratedDepthsPage, mDictionary.tLeachingRequirementUnderestimatedDetail.Translated)
                End If

                If Not (_warnings) Then
                    AppendLine(mIpaInfiltratedDepthsPage, "  -- " & mDictionary.tNone.Translated & " --")
                End If

                ' Footer
                DisplayResultsFooter(mIpaInfiltratedDepthsPage, mIpaInfiltratedDepthsPageNumber, mTotalPages)

            Catch ex As Exception
                ' Set Disposed page to Nothing
                mIpaInfiltratedDepthsPage = Nothing
            End Try
        End If

    End Sub
    '
    ' Performance Analysis
    '
    Private Sub AddIpaPerformanceAnalysisPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mIpaPerformanceAnalysisPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Event Analysis Parameters
        mPageNumber += 1
        mIpaPerformanceAnalysisPageNumber = mPageNumber
        UpdateIpaPerformanceAnalysisPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mIpaPerformanceAnalysisPageNumber As Integer
    Private Sub UpdateIpaPerformanceAnalysisPage()

        If (mIpaPerformanceAnalysisPage IsNot Nothing) Then
            ' mIpaPerformanceAnalysisPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mIpaPerformanceAnalysisPage.Clear()

                ' Header
                DisplayResultsHeader(mIpaPerformanceAnalysisPage)

                ' Performance Analysis
                mIpaPerformanceAnalysisPage.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(mIpaPerformanceAnalysisPage, mDictionary.tPerformanceAnalysis.Translated)

                ' Irrigation mass balance
                'DisplayFieldVolumeBalance(mIpaPerformanceAnalysisPage)

                ' Inflow - Runoff Depth Mass Balance
                DisplayFieldDepthMassBalance(mIpaPerformanceAnalysisPage)

                ' Summary of Probed Infiltrated Depths
                DisplayAverageProbedInfiltratedDepths(mIpaPerformanceAnalysisPage)

                ' Add Warnings, if any
                Dim _warnings As Boolean = False

                Dim _usefulDepth As Double = mSoilCropProperties.UsefulInfiltratedDepth
                Dim _targetDepth As Double = mSoilCropProperties.IrrigationTargetDepth

                If (mDrzUnderestimation) Then
                    _warnings = True
                    AdvanceLine(mIpaPerformanceAnalysisPage)
                    AppendBoldLine(mIpaPerformanceAnalysisPage, mDictionary.tWarnings.Translated)

                    AppendID(mIpaPerformanceAnalysisPage, mDictionary.tRootZoneInfiltrationUnderestimatedID.Translated)
                    AppendLine(mIpaPerformanceAnalysisPage, "     " & mDictionary.tErrPerformanceIndicatorsNotCalculated.Translated)
                Else
                    ' Add Indicators
                    DisplayIpaIndicators(mIpaPerformanceAnalysisPage)

                    AdvanceLine(mIpaPerformanceAnalysisPage)
                    AppendBoldLine(mIpaPerformanceAnalysisPage, mDictionary.tWarnings.Translated)

                    If (_usefulDepth < _targetDepth) Then
                        _warnings = True
                        AppendBoldLine(mIpaPerformanceAnalysisPage, "  " & mDictionary.tUsefulDepth.Translated & " < " & mDictionary.tIrrigationTargetDepth.Translated)
                        AdvanceLine(mIpaPerformanceAnalysisPage)
                    End If
                End If

                Dim _infiltratedDepth As Double = mInflowManagement.InfiltratedDepthForField
                Dim _deepPercolation As Double = _infiltratedDepth - _usefulDepth

                If (_deepPercolation < 0.0) Then
                    If (_warnings = False) Then
                        AppendBoldLine(mIpaPerformanceAnalysisPage, mDictionary.tWarnings.Translated)
                        _warnings = True
                    End If

                    AppendID(mIpaPerformanceAnalysisPage, mDictionary.tInfiltratedDepthLtUsefulDepthID.Translated)
                    AppendDetail(mIpaPerformanceAnalysisPage, mDictionary.tInfiltratedDepthLtUsefulDepthDetail.Translated)
                End If

                If Not (_warnings) Then
                    AppendLine(mIpaPerformanceAnalysisPage, "  -- " & mDictionary.tNone.Translated & " --")
                End If

                ' Footer
                DisplayResultsFooter(mIpaPerformanceAnalysisPage, mIpaPerformanceAnalysisPageNumber, mTotalPages)

            Catch ex As Exception
                ' Set Disposed page to Nothing
                mIpaPerformanceAnalysisPage = Nothing
            End Try
        End If

    End Sub

#End Region

#Region " Merriam-Keller Analysis "
    '
    ' Merriam-Keller Analysis
    '
    Private Sub DisplayMerriamKellerAnalysisResults()

        If (mUnit IsNot Nothing) Then

            mPageNumber = 0
            mTotalPages = 7

            ' Input Summary Page
            Dim title As String = mDictionary.tInputSummary.Translated & " (1/2)"
            AddInputSummaryPage(title)

            ' Surface Flow Measurements table page
            title = mDictionary.tInputSummary.Translated & " (2/2)" ' mDictionary.tSurfaceFlow.Translated
            AddAdvanceRecessionTablePage(title)

            ' Hydraulic Summary graph page
            title = mDictionary.tHydraulicSummary.Translated
            AddHydraulicSummaryGraph(title)

            ' Surface Volume / Volume Balance page
            title = mDictionary.tVolumeBalance.Translated
            AddVolumeBalancePage(title)

            ' Infiltration Function graph page
            title = mDictionary.tInfiltrationFunction.Translated
            AddInfiltrationFunctionGraphPage(title)

            ' Performance Summary page
            title = mDictionary.tPerformanceSummary.Translated
            AddPerformanceSummaryPage(title)

            ' Goodness of Fit page
            title = mDictionary.tParametersGoodnessOfFit.Translated
            AddMkGoodnessOfFitPage(title)

        End If

    End Sub
    '
    ' Merriam-Keller Goodness of Fit
    '
    Private Sub AddMkGoodnessOfFitPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mMkGoodnessPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Advance / Recession
        mPageNumber += 1
        mMkGoodnessOfFitPageNumber = mPageNumber
        UpdateMkGoodnessOfFitPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mMkGoodnessOfFitPageNumber As Integer
    Private Sub UpdateMkGoodnessOfFitPage()

        If (mMkGoodnessPage IsNot Nothing) Then
            ' mMkGoodnessPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mMkGoodnessPage.Clear()

                ' Header
                DisplayResultsHeader(mMkGoodnessPage)

                '******************************************************************************
                ' Infiltration Parameters
                '
                mMkGoodnessPage.SelectionAlignment = HorizontalAlignment.Left

                Dim k As Double = mSoilCropProperties.KostiakovK
                Dim a As Double = mSoilCropProperties.KostiakovA
                Dim b As Double = mSoilCropProperties.KostiakovB
                Dim c As Double = mSoilCropProperties.KostiakovC

                Dim kText As String = "  k:  " & KostiakovKParameter.KostiakovKString(k, a, KostiakovKParameter.DisplayUnits, 0)
                Dim aText As String = "  a:  " & Format(a, "0.00#")
                Dim bText As String = "  b:  " & InfiltrationRateString(b, 0)
                Dim cText As String = "  c:  " & DepthString(c, 0)

                Dim wpText As String = "  "
                If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                    wpText &= WettedPerimeterMethodSelections(mSoilCropProperties.WettedPerimeterMethod.Value).Value
                End If

                AppendBoldUnderlineText(mMkGoodnessPage, "Merriam-Keller " & mDictionary.tSolution.Translated & " - ")

                Select Case (mSoilCropProperties.InfiltrationFunction.Value)

                    Case InfiltrationFunctions.NRCSIntakeFamily
                        AppendBoldUnderlineText(mMkGoodnessPage, mDictionary.tNrcsIntakeFamily.Translated)
                        AppendLine(mMkGoodnessPage, " Z = k*T^a + c")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mMkGoodnessPage, wpText)
                        End If

                        Dim family As NrcsIntakeValues = NrcsIntakeValuesTable(mSoilCropProperties.NrcsIntakeFamily.Value)
                        Dim name As String = family.Name

                        AdvanceLine(mMkGoodnessPage)
                        AppendLine(mMkGoodnessPage, mDictionary.tSelected.Translated & " " & mDictionary.tNrcsIntakeFamily.Translated & " - " & name)

                        AdvanceLine(mMkGoodnessPage)
                        AppendLine(mMkGoodnessPage, kText)
                        AppendLine(mMkGoodnessPage, aText)
                        AppendLine(mMkGoodnessPage, cText)

                        AdvanceLine(mMkGoodnessPage)
                        Dim _double As DoubleParameter = mSurfaceFlow.NrcsWettedPerimeter
                        Dim _text As String = _double.FullXlateText
                        AppendLine(mMkGoodnessPage, _text)

                    Case InfiltrationFunctions.TimeRatedIntakeFamily
                        AppendBoldUnderlineText(mMkGoodnessPage, mDictionary.tTimeRatedIntakeFamily.Translated)
                        AppendLine(mMkGoodnessPage, " Z = k*T^a")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mMkGoodnessPage, wpText)
                        End If

                        AdvanceLine(mMkGoodnessPage)
                        AppendBoldLine(mMkGoodnessPage, mDictionary.tCharacteristicInfiltrationDepth.Translated & ":  " & DepthString(Depth100mm, 0))
                        AppendLine(mMkGoodnessPage, "  " & mDictionary.tCharacteristicInfiltrationTime.Translated & ":  " & mSoilCropProperties.InfiltrationTime_TR.ValueString)

                        AdvanceLine(mMkGoodnessPage)
                        AppendLine(mMkGoodnessPage, kText)
                        AppendLine(mMkGoodnessPage, aText)

                    Case InfiltrationFunctions.CharacteristicInfiltrationTime
                        AppendBoldUnderlineText(mMkGoodnessPage, mDictionary.tCharacteristicInfiltrationTime.Translated)
                        AppendLine(mMkGoodnessPage, " (req = k*T^a")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mMkGoodnessPage, wpText)
                        End If

                        AdvanceLine(mMkGoodnessPage)
                        AppendBoldLine(mMkGoodnessPage, mDictionary.tUserEnteredParameters.Translated)
                        AppendLine(mMkGoodnessPage, aText)

                        AdvanceLine(mMkGoodnessPage)
                        AppendBoldLine(mMkGoodnessPage, mDictionary.tCalculatedParameters.Translated)
                        AppendLine(mMkGoodnessPage, kText)
                        AdvanceLine(mMkGoodnessPage)

                        Dim _depthText As String = "  " & mDictionary.tCharacteristicInfiltrationDepth.Translated & ":  " & mSoilCropProperties.InfiltrationDepth_KT.ValueString
                        AppendLine(mMkGoodnessPage, _depthText)

                        Dim _timeText As String = "  " & mDictionary.tCharacteristicInfiltrationTime.Translated & ":   " & mSoilCropProperties.InfiltrationTime_KT.ValueString
                        AppendLine(mMkGoodnessPage, _timeText)

                    Case InfiltrationFunctions.KostiakovFormula
                        AppendBoldUnderlineText(mMkGoodnessPage, mDictionary.tKostiakovFormula.Translated)
                        AppendLine(mMkGoodnessPage, " Z = k*T^a")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mMkGoodnessPage, wpText)
                        End If

                        AdvanceLine(mMkGoodnessPage)
                        AppendBoldLine(mMkGoodnessPage, mDictionary.tUserEnteredParameters.Translated)
                        AppendLine(mMkGoodnessPage, aText)

                        AdvanceLine(mMkGoodnessPage)
                        AppendBoldLine(mMkGoodnessPage, mDictionary.tCalculatedParameters.Translated)
                        AppendLine(mMkGoodnessPage, kText)

                    Case InfiltrationFunctions.ModifiedKostiakovFormula
                        AppendBoldUnderlineText(mMkGoodnessPage, mDictionary.tModifiedKostiakovFormula.Translated)
                        AppendLine(mMkGoodnessPage, " Z = k*T^a + b*T + c")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mMkGoodnessPage, wpText)
                        End If

                        AdvanceLine(mMkGoodnessPage)
                        AppendBoldLine(mMkGoodnessPage, mDictionary.tUserEnteredParameters.Translated)
                        AppendLine(mMkGoodnessPage, aText)
                        AppendLine(mMkGoodnessPage, bText)
                        AppendLine(mMkGoodnessPage, cText)

                        AdvanceLine(mMkGoodnessPage)
                        AppendBoldLine(mMkGoodnessPage, mDictionary.tCalculatedParameters.Translated)
                        AppendLine(mMkGoodnessPage, kText)

                    Case InfiltrationFunctions.BranchFunction
                        AppendBoldUnderlineText(mMkGoodnessPage, mDictionary.tBranchFunction.Translated)
                        AppendLine(mMkGoodnessPage, " Z = k*T^a + c  =>  Zb + b*T")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mMkGoodnessPage, wpText)
                        End If

                        AdvanceLine(mMkGoodnessPage)
                        AppendBoldLine(mMkGoodnessPage, mDictionary.tUserEnteredParameters.Translated)
                        AppendLine(mMkGoodnessPage, aText)
                        AppendLine(mMkGoodnessPage, bText)

                        If (mSoilCropProperties.BranchTimeSet.Value) Then
                            cText = LeftJustifyFill(cText, 38, "", " ")
                            cText &= mSoilCropProperties.BranchTime_BF.FullXlateText
                        End If
                        AppendLine(mMkGoodnessPage, cText)

                        AdvanceLine(mMkGoodnessPage)
                        AppendBoldLine(mMkGoodnessPage, mDictionary.tCalculatedParameters.Translated)

                        If Not (mSoilCropProperties.BranchTimeSet.Value) Then
                            kText = LeftJustifyFill(kText, 38, "", " ")
                            kText &= mDictionary.tBranchTime.Translated & " = " & TimeString(mSoilCropProperties.BranchTime)
                        End If
                        AppendLine(mMkGoodnessPage, kText)

                    Case InfiltrationFunctions.GreenAmpt
                        AppendBoldUnderlineText(mMkGoodnessPage, sGreenAmpt)

                        AdvanceLine(mMkGoodnessPage)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.EffectivePorosityGA.FullText)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.InitialWaterContentGA.FullText)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.WettingFrontPressureHeadGA.FullText)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.HydraulicConductivityGA.FullText)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.GreenAmptC.FullText)

                    Case InfiltrationFunctions.WarrickGreenAmpt
                        AppendBoldUnderlineText(mMkGoodnessPage, sWarrickGreenAmpt)

                        AdvanceLine(mMkGoodnessPage)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.SaturatedWaterContentWGA.FullText)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.InitialWaterContentWGA.FullText)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.WettingFrontPressureHeadWGA.FullText)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.HydraulicConductivityWGA.FullText)
                        AppendLine(mMkGoodnessPage, mSoilCropProperties.WarrickGreenAmptC.FullText)

                    Case Else
                        Debug.Assert(False) ' Invalid Infiltration Method for Merriam-Keller Analysis
                End Select

                AdvanceLine(mMkGoodnessPage)
                AppendLine(mMkGoodnessPage, mEventCriteria.ReferenceFlowRate.FullText)
                AdvanceLine(mMkGoodnessPage)

                '******************************************************************************
                ' Performance Measures
                mMkGoodnessPage.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(mMkGoodnessPage, mDictionary.tGoodnessOfFitMeasuresEstimatedParameters.Translated)
                '
                ' Inflow
                '
                Dim _appliedVolume As Double = mInflowManagement.AppliedVolumeForField
                Dim _appliedDepth As Double = mInflowManagement.AppliedDepthForField
                '
                ' Advance data
                '
                Dim _usrAdvanceTable As DataTable = mInflowManagement.TabulatedAdvance.Value
                Dim _usrAdvanceDists As ArrayList = GetDataColumn(_usrAdvanceTable, sDistanceX)
                Dim _usrAdvanceTimes As ArrayList = GetDataColumn(_usrAdvanceTable, sTimeX)
                Dim _numUsrAdvTimes As Integer = _usrAdvanceTimes.Count
                Dim _avgUsrAdvTime As Double = AverageTimeOverDistance(_usrAdvanceTable)
                Dim _endUsrAdvTime As Double = CDbl(_usrAdvanceTimes(_numUsrAdvTimes - 1))

                Dim _simAdvanceTable As DataTable = mSurfaceFlow.Advance.Value
                Dim _numSimAdvDists As Integer = _simAdvanceTable.Rows.Count
                Dim _endSimAdvDist As Double = CDbl(_simAdvanceTable.Rows(_numSimAdvDists - 1).Item(sDistanceX))

                If (_endSimAdvDist < mSystemGeometry.Length.Value - 0.1) Then
                    ' Simulated Advance DID NOT reach the end of the field
                    AdvanceLine(mMkGoodnessPage)
                    AppendBoldLine(mMkGoodnessPage, mDictionary.tAdvanceTimes.Translated)
                    AppendLine(mMkGoodnessPage, mDictionary.tAdvanceTimeEndOfField.Translated(35) & mDictionary.tMeasured.Translated(15) & ":  " & TimeString(_endUsrAdvTime, 0))
                    AdvanceLine(mMkGoodnessPage)
                    AppendLine(mMkGoodnessPage, mDictionary.tSimulatedAdvanceDidNotReachEndOfField.Translated)
                Else
                    ' Simulated Advance reached the end of the field
                    Dim _simAdvanceTimes As ArrayList = GetTimeColumn(_simAdvanceTable, _usrAdvanceDists)
                    Dim _numSimAdvTimes As Integer = _simAdvanceTimes.Count
                    Dim _avgSimAdvTime As Double = AverageTimeOverDistance(_simAdvanceTable)
                    Dim _endSimAdvTime As Double = CDbl(_simAdvanceTimes(_numSimAdvTimes - 1))

                    ' Compute RMS Error for Advance
                    Dim _sumxmy2 As Double = SUMXMY2(_usrAdvanceTimes, _simAdvanceTimes)
                    Dim _minNum As Integer = Math.Min(_numUsrAdvTimes, _numSimAdvTimes)
                    Dim _rmse As Double = Math.Sqrt(_sumxmy2 / (_minNum - 1)) ' Don't include 1st Advance Pt (0.0)

                    AdvanceLine(mMkGoodnessPage)
                    AppendBoldLine(mMkGoodnessPage, mDictionary.tAdvanceTimes.Translated)
                    AppendLine(mMkGoodnessPage, mDictionary.tRootMeanSquareError.Translated(35) & "           RMSE:  " & TimeString(_rmse, 0))
                    AdvanceLine(mMkGoodnessPage)
                    AppendLine(mMkGoodnessPage, mDictionary.tAdvanceTimeEndOfField.Translated(35) & mDictionary.tMeasured.Translated(15) & ":  " & TimeString(_endUsrAdvTime, 0))
                    AppendLine(mMkGoodnessPage, mDictionary.tPredicted.Translated(50) & ":  " & TimeString(_endSimAdvTime, 0))
                    '
                    ' Recession data
                    '
                    Dim _usrRecessionTable As DataTable = mInflowManagement.TabulatedRecession.Value
                    Dim _usrRecessionDists As ArrayList = GetDataColumn(_usrRecessionTable, sDistanceX)
                    Dim _usrRecessionTimes As ArrayList = GetDataColumn(_usrRecessionTable, sTimeX)
                    Dim _numUsrRecTimes As Integer = _usrRecessionTimes.Count
                    Dim _avgUsrRecTime As Double = AverageTimeOverDistance(_usrRecessionTable)
                    Dim _endUsrRecTime As Double = DataStore.Utilities.DataColumnMax(_usrRecessionTable, sTimeX)

                    Dim _simRecessionTable As DataTable = mSurfaceFlow.Recession.Value
                    Dim _simRecessionTimes As ArrayList = GetTimeColumn(_simRecessionTable, _usrRecessionDists)
                    Dim _numSimRecTimes As Integer = _simRecessionTimes.Count
                    Dim _avgSimRecTime As Double = AverageTimeOverDistance(_simRecessionTable)
                    Dim _endSimRecTime As Double = DataStore.Utilities.DataColumnMax(_simRecessionTable, sTimeX)

                    ' Compute RMS Error for Recession
                    _sumxmy2 = SUMXMY2(_usrRecessionTimes, _simRecessionTimes)
                    _minNum = Math.Min(_numUsrRecTimes, _numSimRecTimes)
                    _rmse = Math.Sqrt(_sumxmy2 / _minNum)

                    AdvanceLine(mMkGoodnessPage)
                    AppendBoldLine(mMkGoodnessPage, mDictionary.tRecessionTimes.Translated)
                    AppendLine(mMkGoodnessPage, mDictionary.tRootMeanSquareError.Translated(35) & "           RMSE:  " & TimeString(_rmse, 0))
                    AdvanceLine(mMkGoodnessPage)
                    AppendLine(mMkGoodnessPage, mDictionary.tMaximumRecessionTime.Translated(35) & mDictionary.tMeasured.Translated(15) & ":  " & TimeString(_endUsrRecTime, 0))
                    AppendLine(mMkGoodnessPage, mDictionary.tPredicted.Translated(50) & ":  " & TimeString(_endSimRecTime, 0))
                    '
                    ' Opportunity Times
                    '
                    Dim _usrAvgOppTime As Double = _avgUsrRecTime - _avgUsrAdvTime
                    Dim _simAvgOppTime As Double = _avgSimRecTime - _avgSimAdvTime

                    ' Compute Relative Error for Opportunity Times
                    Dim _error As Double = (_simAvgOppTime - _usrAvgOppTime) / _usrAvgOppTime

                    AdvanceLine(mMkGoodnessPage)
                    AppendBoldLine(mMkGoodnessPage, mDictionary.tAverageOpportunityTimes.Translated)
                    AppendLine(mMkGoodnessPage, mDictionary.tMeasured.Translated(15) & ":  " & TimeString(_usrAvgOppTime, 0))
                    AppendLine(mMkGoodnessPage, mDictionary.tPredicted.Translated(15) & ":  " & TimeString(_simAvgOppTime, 0))
                    '
                    ' Infiltration
                    '
                    Dim _usrAvgDepth As Double = mInflowManagement.AverageInfiltratedDepthForField
                    Dim _simAvgDepth As Double = mSubsurfaceFlow.AverageLongitudinalInfiltrationDepth

                    ' Compute Relative Error for Infiltration Depths
                    _error = (_simAvgDepth - _usrAvgDepth) / _appliedDepth

                    AdvanceLine(mMkGoodnessPage)
                    AppendBoldLine(mMkGoodnessPage, mDictionary.tAverageInfiltratedDepths.Translated)
                    AppendLine(mMkGoodnessPage, mDictionary.tMeasured.Translated(15) & ":  " & DepthString(_usrAvgDepth, 0))
                    AppendLine(mMkGoodnessPage, mDictionary.tPredicted.Translated(15) & ":  " & DepthString(_simAvgDepth, 0))
                    '
                    ' Runoff
                    '
                    Dim _usrRunoffDepth As Double = mInflowManagement.RunoffDepthForCrossSection
                    Dim _usrRunoffTable As DataTable = mInflowManagement.RunoffTableForCrossSection
                    Dim _usrRunoffTimes As ArrayList = GetDataColumn(_usrRunoffTable, sTimeX)
                    Dim _usrRunoffRates As ArrayList = GetDataColumn(_usrRunoffTable, sRunoffX)

                    Dim _simRunoffDepth As Double = mSurfaceFlow.ROd.Value
                    Dim _simRunoffTable As DataTable = mSurfaceFlow.RunoffTable
                    Dim _simRunoffRates As ArrayList = GetRunoffColumn(_simRunoffTable, _usrRunoffTimes)

                    ' Compute Relative Error for Runoff
                    _error = (_simRunoffDepth - _usrRunoffDepth) / _appliedDepth

                    ' Compute Coefficient of Determination (R²)
                    Dim _rsq As Double = RSQ(_usrRunoffRates, _simRunoffRates)

                    ' Compute Nash-Sutcliffe Efficiency E
                    _sumxmy2 = SUMXMY2(_usrRunoffRates, _simRunoffRates)
                    Dim _devsq As Double = DEVSQ(_usrRunoffRates)
                    Dim _e As Double = 1 - (_sumxmy2 / _devsq)

                    ' Display Runoff as Depth
                    AdvanceLine(mMkGoodnessPage)
                    AppendBoldLine(mMkGoodnessPage, mDictionary.tRunoffDepths.Translated)
                    AppendLine(mMkGoodnessPage, mDictionary.tMeasured.Translated(15) & ":  " & DepthString(_usrRunoffDepth, 0))
                    AppendLine(mMkGoodnessPage, mDictionary.tPredicted.Translated(15) & ":  " & DepthString(_simRunoffDepth, 0))

                    AdvanceLine(mMkGoodnessPage)
                    AppendLine(mMkGoodnessPage, mDictionary.tCoefficientOfDetermination.Translated(35) & " (R²):  " & UnitText(_rsq, Units.None) & " **")
                    AppendLine(mMkGoodnessPage, mDictionary.tNashSutcliffeEfficiency.Translated(35) & " (E):   " & UnitText(_e, Units.None) & " **")
                    '
                    ' Qualifications
                    '
                    AdvanceLine(mMkGoodnessPage)
                    AppendLine(mMkGoodnessPage, "   ** " & mDictionary.tCalculatedBasedOnTimeAdjustedRunoffValues.Translated)
                End If

                ' Footer
                DisplayResultsFooter(mMkGoodnessPage, mMkGoodnessOfFitPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mMkGoodnessPage = Nothing
            End Try
        End If

    End Sub

#End Region

#Region " Elliott-Walker Two-Point Analysis "

    Private Sub DisplayElliotWalkerTwoPointAnalysisResults()

        If (mUnit IsNot Nothing) Then

            mPageNumber = 0
            mTotalPages = 6
            If (mWinSRFR.IsResearchLevel) Then ' add Research Results tabs
                mTotalPages += 2
            End If

            ' Input Summary Page
            Dim title As String = mDictionary.tInputSummary.Translated
            AddInputSummaryPage(title)

            ' Hydraulic Summary graph page
            title = mDictionary.tHydraulicSummary.Translated
            AddHydraulicSummaryGraph(title)

            ' Surface Volume / Volume Balance page
            title = mDictionary.tVolumeBalance.Translated
            AddVolumeBalancePage(title)

            ' Infiltration Function graph page
            title = mDictionary.tInfiltrationFunction.Translated
            AddInfiltrationFunctionGraphPage(title)

            ' Performance Summary page
            title = mDictionary.tPerformanceSummary.Translated
            AddPerformanceSummaryPage(title)

            ' Goodness of Fit page
            title = mDictionary.tParametersGoodnessOfFit.Translated
            AddEwGoodnessOfFitPage(title)

            If (mWinSRFR.IsResearchLevel) Then ' add Research Results tabs
                ' AY average / Sy Graph
                title = "AY average / Sy"
                AddAySyGraphPage(title)

                ' AZ average / Sz Graph
                title = "AZ average / Sz"
                AddAzSzGraphPage(title)
            End If

        End If

    End Sub
    '
    ' Elliott-Walker Goodness of Fit
    '
    Private Sub AddEwGoodnessOfFitPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mEwGoodnessPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Advance / Recession
        mPageNumber += 1
        mEwGoodnessOfFitPageNumber = mPageNumber
        UpdateEwGoodnessOfFitPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mEwGoodnessOfFitPageNumber As Integer
    Private Sub UpdateEwGoodnessOfFitPage()

        If (mEwGoodnessPage IsNot Nothing) Then
            ' mEwGoodnessPage may be defined but Disposed; this causes an exception
            Try
                Dim _area As Double = mSystemGeometry.FieldArea

                ' Clear the old contents
                mEwGoodnessPage.Clear()

                ' Header
                DisplayResultsHeader(mEwGoodnessPage)

                Dim wpText As String = "  "
                If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                    wpText &= WettedPerimeterMethodSelections(mSoilCropProperties.WettedPerimeterMethod.Value).Value
                End If

                ' Estimates for Kostiakov k, a & b Section
                mEwGoodnessPage.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(mEwGoodnessPage, mDictionary.tEstimatesForKostiakovKAB.Translated)
                If (mUnit.CrossSection = CrossSections.Furrow) Then
                    AppendLine(mEwGoodnessPage, wpText)
                End If

                AdvanceLine(mEwGoodnessPage)
                AppendLine(mEwGoodnessPage, "    k:  " & mSoilCropProperties.KostiakovK_MK.ValueString)
                AppendLine(mEwGoodnessPage, "    a:  " & mSoilCropProperties.KostiakovA_MK.ValueString)
                AppendLine(mEwGoodnessPage, "    b:  " & mSoilCropProperties.KostiakovB_MK.ValueString)

                AdvanceLine(mEwGoodnessPage)
                AppendLine(mEwGoodnessPage, mEventCriteria.ReferenceFlowRate.FullText)
                AdvanceLine(mEwGoodnessPage)

                ' Performance Measures
                AppendBoldUnderlineLine(mEwGoodnessPage, mDictionary.tGoodnessOfFitMeasuresEstimatedParameters.Translated)

                ' Inflow
                Dim _appliedVolume As Double = mInflowManagement.AppliedVolumeForField
                Dim _appliedDepth As Double = mInflowManagement.AppliedDepthForField

                ' Advance data
                Dim _tpAdvanceTable As DataTable = mInflowManagement.TwoPointTabulatedAdvance.Value
                Dim _tpAdvanceDists As ArrayList = GetDataColumn(_tpAdvanceTable, sDistanceX)
                Dim _tpAdvanceTimes As ArrayList = GetDataColumn(_tpAdvanceTable, sTimeX)
                Dim _numTpAdvTimes As Integer = _tpAdvanceTimes.Count
                Dim _avgTpAdvTime As Double = AverageTimeOverDistance(_tpAdvanceTable)
                Dim _endTpAdvTime As Double = CDbl(_tpAdvanceTimes(_numTpAdvTimes - 1))

                Dim _simAdvanceTable As DataTable = mSurfaceFlow.Advance.Value
                Dim _simAdvanceTimes As ArrayList = GetTimeColumn(_simAdvanceTable, _tpAdvanceDists)
                Dim _numSimAdvTimes As Integer = _simAdvanceTimes.Count
                Dim _avgSimAdvTime As Double = AverageTimeOverDistance(_simAdvanceTable)
                Dim _endSimAdvTime As Double = CDbl(_simAdvanceTimes(_numSimAdvTimes - 1))

                ' Compute RMS Error for Advance
                Dim _sumxmy2 As Double = SUMXMY2(_tpAdvanceTimes, _simAdvanceTimes)
                Dim _minNum As Integer = Math.Min(_numTpAdvTimes, _numSimAdvTimes)
                Dim _rmse As Double = Math.Sqrt(_sumxmy2 / (_minNum - 1)) ' Don't include 1st Advance Pt (0.0)

                AdvanceLine(mEwGoodnessPage)
                AppendBoldLine(mEwGoodnessPage, mDictionary.tAdvanceTimes.Translated)
                AppendLine(mEwGoodnessPage, "  " & mDictionary.tRootMeanSquareError.Translated & ":  " & TimeString(_rmse, 0))

                AdvanceLine(mEwGoodnessPage)
                AppendLine(mEwGoodnessPage, "  " & mDictionary.tAdvanceTimeEndOfField.Translated)
                AppendLine(mEwGoodnessPage, mDictionary.tMeasured.Translated(20) & ":  " & TimeString(_endTpAdvTime, 0))
                AppendLine(mEwGoodnessPage, mDictionary.tPredicted.Translated(20) & ":  " & TimeString(_endSimAdvTime, 0))

                ' Footer
                DisplayResultsFooter(mEwGoodnessPage, mEwGoodnessOfFitPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mEwGoodnessPage = Nothing
            End Try
        End If

    End Sub

#End Region

#Region " Erosion Parameter Estimations Results "
    '
    ' DisplayErosionResults() - displays the SRFR simulation results in the Results Control.
    '
    Private Sub DisplayErosionParametersResults()

        If (mUnit IsNot Nothing) Then

            ' Check for SRFR error
            Dim _errorCount As Integer = mPerformanceResults.ErrorCount.Value
            Dim _errorStack As ArrayList = mPerformanceResults.ErrorStack.Array

            If (0 < _errorCount) Then
                ' There is at least one SRFR error
                Dim tErrors As String = mDictionary.tErrors.Translated

                Dim _page As RtfPage = GetNewResultsPage(tErrors, ResultsView)
                _page.AccessibleName = tErrors
                _page.AccessibleDescription = mDictionary.tErrExecution.Translated

                Dim tbox As RichTextBox = _page.Rtf

                AppendBoldLine(tbox, mDictionary.tErrExecutionStoppedDueTo.Translated & " " & tErrors & ":")

                For _idx As Integer = 0 To _errorCount - 1
                    Dim _srfrError As Integer = CInt(_errorStack(_idx))
                    _idx += 1
                    Dim _srfrMsg As String = CStr(_errorStack(_idx))
                    AdvanceLine(tbox)
                    AppendLine(tbox, _srfrError.ToString & " - " & _srfrMsg)
                Next

                AddTabPage(tErrors, _page)

                Return

            End If

            ' Field Length & Target Depth in SI units
            Dim _fieldLength As Double = mSystemGeometry.Length.Value
            Dim _requiredDepth As Double = mInflowManagement.RequiredDepth.Value

            ' Time units
            Dim _timeUnits As Units = mInflowManagement.CutoffTime.DisplayUnits

            ' Display tab page for each Display Selection
            Dim _2dGraph As grf_XYGraph

            mPageNumber = 0
            mTotalPages = 5

            mErosionParametersPage = Nothing

            '*************************************************************************************************
            ' Erosion Parameters
            '
            Dim _title As String = mDictionary.tSummary.Translated
            Dim _tabName As String = mDictionary.tSummary.Translated
            '
            ' Full Page view for Display, Print & Print Preview
            '
            AddErosionParametersPage(_title, _tabName)

            '*************************************************************************************************
            ' Hydraulic Summary
            '
            Dim _advRec As DataSet = New DataSet(sHydraulicSummary)
            Dim _infilt As DataSet = New DataSet(sHydraulicSummary)
            Dim _hydro As DataSet = New DataSet(sHydraulicSummary)

            Dim _advance As DataTable = mSurfaceFlow.Advance.Value
            Dim _recession As DataTable = mSurfaceFlow.Recession.Value

            Dim _infiltration As DataTable = mSubsurfaceFlow.LongitudinalInfiltration.Value

            Dim _hydroflow As DataTable = mSurfaceFlow.FlowHydrographs.Value

            If (DataTableHasData(_advance) _
            And DataTableHasData(_infiltration) _
            And DataTableHasData(_hydroflow)) Then

                ' Advance / Recession
                _advRec.Tables.Add(_advance.Copy)

                If (_recession IsNot Nothing) Then
                    _advRec.Tables.Add(_recession.Copy)
                End If

                ' Infiltration / Target Depth
                Dim _dreq As Double = mInflowManagement.RequiredDepth.Value
                Dim _dreqTable As DataTable = DreqTable(_dreq, _infiltration.Columns(0).ColumnName, _fieldLength)
                _dreqTable.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                _infilt.Tables.Add(_infiltration.Copy)
                _infilt.Tables.Add(_dreqTable)

                ' Flow Hydrographs
                _hydro.Tables.Add(_hydroflow.Copy)

                '
                ' Full Page view for Display, Print & Print Preview
                '
                _2dGraph = GetNewHydraulicSummaryPage(_advRec, _infilt, _hydro, sHydraulicSummary)
                _2dGraph.UnitsX = UnitsDefinition.Units.Meters
                _2dGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPage(sHydraulicSummary, sHydraulicSummary, _2dGraph)
                '
                ' Graphic Only view for Display
                '
                _2dGraph = GetNewHydraulicSummaryPanel(_advRec, _infilt, _hydro, sHydraulicSummary)
                _2dGraph.UnitsX = UnitsDefinition.Units.Meters
                _2dGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPanel(sHydraulicSummary, sHydraulicSummary, _2dGraph)

            End If

            ' Hydrographs (Erosion G)
            _title = "Hydrographs (Erosion G)"
            _tabName = "Hydrographs (Erosion G)"
            '
            ' Create DataSet for graph
            '   Hydrograph curves
            '
            Dim _hydrograph As DataSet = mSurfaceFlow.ErosionGHydrographs.Value

            If DataSetHasData(_hydrograph) Then
                '
                ' Full Page view for Display, Print & Print Preview
                '
                _2dGraph = GetNewXYGraphPage(_hydrograph, _title)
                _2dGraph.DisplayKey = True
                _2dGraph.UnitsX = UnitsDefinition.Units.Seconds
                _2dGraph.UnitsY = UnitsDefinition.Units.KilogramsPerSecond

                AddResultsPage(_title, _tabName, _2dGraph)
                '
                ' Graphic Only view for Display
                '
                _2dGraph = GetNewXYGraphPanel(_hydrograph, _title)
                _2dGraph.DisplayKey = True
                _2dGraph.UnitsX = UnitsDefinition.Units.Seconds
                _2dGraph.UnitsY = UnitsDefinition.Units.KilogramsPerSecond

                AddResultsPanel(_title, _tabName, _2dGraph)
            End If

            _title = "Hydrographs (Erosion CGm)"
            _tabName = "Hydrographs (Erosion CGm)"
            '
            ' Create DataSet for graph
            '   Hydrograph curves
            '
            Dim _hydrographCGm As DataSet = mSurfaceFlow.ErosionCGmHydrographs.Value

            If DataSetHasData(_hydrographCGm) Then
                '
                ' Full Page view for Display, Print & Print Preview
                '
                _2dGraph = GetNewXYGraphPage(_hydrographCGm, _title)
                _2dGraph.DisplayKey = True
                _2dGraph.UnitsX = UnitsDefinition.Units.Seconds
                _2dGraph.UnitsY = UnitsDefinition.Units.GramsPerLiter

                AddResultsPage(_title, _tabName, _2dGraph)
                '
                ' Graphic Only view for Display
                '
                _2dGraph = GetNewXYGraphPanel(_hydrographCGm, _title)
                _2dGraph.DisplayKey = True
                _2dGraph.UnitsX = UnitsDefinition.Units.Seconds
                _2dGraph.UnitsY = UnitsDefinition.Units.GramsPerLiter

                AddResultsPanel(_title, _tabName, _2dGraph)

            End If

            _title = "Hydrographs (Erosion CGv)"
            _tabName = "Hydrographs (Erosion CGv)"
            '
            ' Create DataSet for graph
            '   Hydrograph curves
            '
            Dim _hydrographCGv As DataSet = mSurfaceFlow.ErosionCGvHydrographs.Value

            If DataSetHasData(_hydrograph) Then
                '
                ' Full Page view for Display, Print & Print Preview
                '
                _2dGraph = GetNewXYGraphPage(_hydrographCGv, _title)
                _2dGraph.DisplayKey = True
                _2dGraph.UnitsX = UnitsDefinition.Units.Seconds
                _2dGraph.UnitsY = UnitsDefinition.Units.LitersPerLiter

                AddResultsPage(_title, _tabName, _2dGraph)
                '
                ' Graphic Only view for Display
                '
                _2dGraph = GetNewXYGraphPanel(_hydrographCGv, _title)
                _2dGraph.DisplayKey = True
                _2dGraph.UnitsX = UnitsDefinition.Units.Seconds
                _2dGraph.UnitsY = UnitsDefinition.Units.LitersPerLiter

                AddResultsPanel(_title, _tabName, _2dGraph)

            End If

        End If

    End Sub
    '
    ' Add & Update Erosion Parameters page
    '
    Private Sub AddErosionParametersPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mErosionParametersPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Srfr Parameters
        mPageNumber += 1
        mErosionParametersPageNumber = mPageNumber
        UpdateErosionParametersPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mErosionParametersPageNumber As Integer
    Private Sub UpdateErosionParametersPage()

        If (mErosionParametersPage IsNot Nothing) Then

            Dim _name As String
            Dim _value As String
            Dim _text As String

            ' mErosionParametersPage may be defined but Disposed; this caused an exception
            Try
                ' Clear the old contents
                mErosionParametersPage.Clear()

                ' Add Header
                DisplayResultsHeader(mErosionParametersPage)
                '
                ' Add the Input Parameters
                '
                mErosionParametersPage.SelectionAlignment = HorizontalAlignment.Left

                AppendBoldUnderlineLine(mErosionParametersPage, mDictionary.tInputParameters.Translated)

                DisplaySystemGeometryParameters(mErosionParametersPage)
                DisplayInfiltrationParameters(mErosionParametersPage)
                DisplayRoughnessParameters(mErosionParametersPage)
                DisplayInflowManagementParameters(mErosionParametersPage)

                ' Irrigation Water
                AdvanceLine(mErosionParametersPage)
                AppendBoldLine(mErosionParametersPage, "Irrigation Water")
                AppendLine(mErosionParametersPage, "  " & mErosion.WaterTemp.FullXlateText)
                AppendLine(mErosionParametersPage, "  " & mErosion.KinematicViscosity.FullXlateText)

                ' Erosion Field Measurements
                AdvanceLine(mErosionParametersPage)
                AppendBoldLine(mErosionParametersPage, "Erosion Field Measurements")
                AppendLine(mErosionParametersPage, "  " & mSoilCropProperties.SedimentConcentration.FullXlateText)
                AppendLine(mErosionParametersPage, "    at Distance " & mSoilCropProperties.SedimentDistance.ValueString _
                                                          & ", Time " & mSoilCropProperties.SedimentTime.ValueString)
                '
                ' Add the calculated Erosion Parameters
                '
                AdvanceLines(mErosionParametersPage, 2)
                AppendBoldUnderlineLine(mErosionParametersPage, "Calculated Erosion Parameters")

                ' Soil Erodibility
                AdvanceLine(mErosionParametersPage)
                AppendBoldLine(mErosionParametersPage, "Soil Erodibility")
                AppendLine(mErosionParametersPage, "  TauC = " & mSoilCropProperties.ErodibilityTauc.ValueString)
                AppendLine(mErosionParametersPage, "  Beta = " & mSoilCropProperties.ErodibilityBeta.ValueString)
                AppendLine(mErosionParametersPage, "  KR =   " & mSoilCropProperties.ErodibilityA.ValueString)

                ' Erosion
                AdvanceLine(mErosionParametersPage)
                AppendBoldLine(mErosionParametersPage, "Erosion")
                Dim _GL_xx As ArrayListParameter = mSurfaceFlow.GL_xx
                Dim _col As Integer = 1
                For _pdx As Integer = 0 To _GL_xx.Array.Count - 2 Step 2
                    Dim _gs As Double = CDbl(_GL_xx.Array(_pdx + 1))
                    Dim _units As Units = mUnitsSystem.TonsAreaUnits()
                    _name = (CStr(_GL_xx.Array(_pdx)) & "      ").Substring(0, 5)
                    _value = (UnitTextWithUnits(_gs, _units) & "                   ").Substring(0, 17)

                    If (_col = 1) Then
                        _text = "  " & _name & " = " & _value
                        AppendText(mErosionParametersPage, _text)
                        _col = 2
                    ElseIf (_col = 2) Then
                        _text = _name & " = " & _value
                        AppendText(mErosionParametersPage, _text)
                        _col = 3
                    Else
                        _text = _name & " = " & _value
                        AppendLine(mErosionParametersPage, _text)
                        _col = 1
                    End If
                Next ' _pdx

                If (1 < _col) Then
                    AdvanceLine(mErosionParametersPage)
                End If

                ' Add Footer
                DisplayResultsFooter(mErosionParametersPage, mErosionParametersPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mErosionParametersPage = Nothing
            End Try
        End If

    End Sub

#End Region

#Region " EVALUE Analysis "
    '
    ' EVALUE Analysis
    '
    Private Sub DisplayEvalueAnalysisResults()

        If (mUnit IsNot Nothing) Then

            mPageNumber = 0
            mTotalPages = 7
            If (mInflowManagement.FlowDepthsMeasuredAndUsed) Then
                mTotalPages += 1
            End If
            If (mWinSRFR.IsResearchLevel) Then ' add Research Results tabs
                mTotalPages += 2
            End If

            ' Input Summary Page
            Dim title As String = mDictionary.tInputSummary.Translated & " (1/2)"
            AddInputSummaryPage(title)

            ' Surface Flow Measurements table page
            title = mDictionary.tInputSummary.Translated & " (2/2)" ' mDictionary.tSurfaceFlow.Translated
            AddAdvanceRecessionTablePage(title)

            ' Hydraulic Summary graph page
            title = mDictionary.tHydraulicSummary.Translated
            AddHydraulicSummaryGraph(title)

            ' Surface Flow Summary
            If (mInflowManagement.FlowDepthsMeasuredAndUsed) Then
                title = mDictionary.tSurfaceVolumes.Translated
                AddSurfaceFlowMeasuredPage(title)
            End If

            ' Surface Volume / Volume Balance page
            title = mDictionary.tVolumeBalance.Translated
            AddVolumeBalancePage(title)

            ' Infiltration Function graph page
            title = mDictionary.tInfiltrationFunction.Translated
            AddInfiltrationFunctionGraphPage(title)

            ' Performance Summary page
            title = mDictionary.tPerformanceSummary.Translated
            AddPerformanceSummaryPage(title)

            ' Goodness of Fit page
            title = mDictionary.tParametersGoodnessOfFit.Translated
            AddEvalueGoodnessOfFitPage(title)

            If (mWinSRFR.IsResearchLevel) Then ' add Research Results tabs
                ' AY average / Sy Graph
                title = "AY average / Sy"
                AddAySyGraphPage(title)

                ' AZ average / Sz Graph
                title = "AZ average / Sz"
                AddAzSzGraphPage(title)
            End If
        End If

    End Sub
    '
    ' Input Summary
    '
    Private Sub AddInputSummaryPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mInputSummaryPage = page.Rtf
        mInputSummaryPage.WordWrap = False
        mInputSummaryPage.ScrollBars = RichTextBoxScrollBars.None

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Irrigation Requirements
        mPageNumber += 1
        mInputSummaryPageNumber = mPageNumber
        UpdateInputSummaryPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mInputSummaryPageNumber As Integer
    Private Sub UpdateInputSummaryPage()

        If (mInputSummaryPage IsNot Nothing) Then
            ' mEvalueInputSummaryPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mInputSummaryPage.Clear()

                ' Header
                DisplayResultsHeader(mInputSummaryPage)

                ' Section Title
                mInputSummaryPage.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(mInputSummaryPage, mDictionary.tInputSummary.Translated)

                ' Input Parameters
                DisplaySystemGeometryParameters(mInputSummaryPage)

                Select Case (mEventCriteria.EventAnalysisType.Value)
                    Case EventAnalysisTypes.EvalueAnalysis
                        If Not (mInflowManagement.FlowDepthsMeasuredAndUsed) Then
                            DisplayRoughnessParameters(mInputSummaryPage)
                        End If
                        ' Infiltration is estimated for EVALUE
                    Case EventAnalysisTypes.MerriamKellerAnalysis
                        DisplayRoughnessParameters(mInputSummaryPage)
                        ' Infiltration is estimated for Merriam-Keller
                    Case EventAnalysisTypes.TwoPointAnalysis
                        DisplayRoughnessParameters(mInputSummaryPage)
                        ' Infiltration is estimated for Elliott-Walker 2-point
                    Case EventAnalysisTypes.InfiltratedProfileAnalysis
                        AppendBoldLine(mInputSummaryPage, mDictionary.tRoughness.Translated)
                        AppendLine(mInputSummaryPage, "  " & mDictionary.tWrnIpaRoughnessParametersNotUsed.Translated)
                        AdvanceLine(mInputSummaryPage)

                        AppendBoldLine(mInputSummaryPage, mDictionary.tInfiltration.Translated)
                        AppendLine(mInputSummaryPage, "  " & mDictionary.tWrnIpaInfiltrationParametersNotEstimated.Translated)
                        AdvanceLine(mInputSummaryPage)
                    Case Else
                        Debug.Assert(False, "Support for this type must be added")
                End Select

                DisplayInflowRunoffTables(mInputSummaryPage)

                If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                    AdvanceLines(mInputSummaryPage, 2)
                    AppendBoldUnderlineText(mInputSummaryPage, mDictionary.tTwoPointAdvance.Translated)

                    If (mUnit.CrossSection = Globals.CrossSections.Furrow) Then
                        AppendLine(mInputSummaryPage, " " & mDictionary.tPerFurrow.Translated)
                    Else
                        AdvanceLine(mInputSummaryPage)
                    End If

                    AdvanceLine(mInputSummaryPage)
                    AppendText(mInputSummaryPage, mDictionary.tParameter.Translated(-31))
                    AppendText(mInputSummaryPage, mDictionary.tPoint.Translated(15) & " 1")
                    AppendLine(mInputSummaryPage, mDictionary.tPoint.Translated(15) & " 2")
                    'AppendLine(mInputSummaryPage, "Parameter                                Point 1          Point 2")
                    AppendLine(mInputSummaryPage, "-----------------------------------------------------------------")

                    Dim _pt1Dist As Double = mInflowManagement.TwoPointDistance1
                    Dim _pt1Time As Double = mInflowManagement.TwoPointTime1
                    Dim _pt2Dist As Double = mInflowManagement.TwoPointDistance2
                    Dim _pt2Time As Double = mInflowManagement.TwoPointTime2

                    AppendText(mInputSummaryPage, LeftJustifyFill(mDictionary.tDistance.Translated & " (X)", 34))
                    AppendLine(mInputSummaryPage, LengthString(_pt1Dist, 14) + LengthString(_pt2Dist, 17))

                    AppendText(mInputSummaryPage, LeftJustifyFill(mDictionary.tTime.Translated & " (T)", 34))
                    AppendLine(mInputSummaryPage, TimeString(_pt1Time, 14) + TimeString(_pt2Time, 17))
                    AdvanceLine(mInputSummaryPage)
                End If

                ' Footer
                DisplayResultsFooter(mInputSummaryPage, mInputSummaryPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mInputSummaryPage = Nothing
            End Try
        End If

    End Sub
    '
    ' Advance / Recession Measurements
    '
    Private Sub AddAdvanceRecessionTablePage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mAdvRecOppPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Advance / Recession
        mPageNumber += 1
        mAdvanceRecessionTablePageNumber = mPageNumber
        UpdateAdvanceRecessionTablePage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mAdvanceRecessionTablePageNumber As Integer
    Private Sub UpdateAdvanceRecessionTablePage()

        If (mAdvRecOppPage IsNot Nothing) Then
            ' mAdvRecOppPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mAdvRecOppPage.Clear()

                ' Header
                DisplayResultsHeader(mAdvRecOppPage)

                ' Section Title
                mAdvRecOppPage.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineText(mAdvRecOppPage, mDictionary.tAdvance.Translated)
                AppendBoldUnderlineText(mAdvRecOppPage, " / ")
                AppendBoldUnderlineText(mAdvRecOppPage, mDictionary.tRecession.Translated)
                AppendBoldUnderlineText(mAdvRecOppPage, " / ")
                AppendBoldUnderlineText(mAdvRecOppPage, mDictionary.tOpportunityTime.Translated)
                AppendBoldUnderlineText(mAdvRecOppPage, " ")
                AppendBoldUnderlineLine(mAdvRecOppPage, mDictionary.tTable.Translated)

                DisplayAdvanceRecessionTables(mAdvRecOppPage)

                ' Footer
                DisplayResultsFooter(mAdvRecOppPage, mAdvanceRecessionTablePageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mAdvRecOppPage = Nothing
            End Try
        End If

    End Sub
    '
    ' Surface Volumes / Volume Balances
    '
    Private Sub AddVolumeBalancePage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        mVolumeBalanceRtfPage = GetNewResultsPage(title, ResultsView)
        mVolumeBalancePage = mVolumeBalanceRtfPage.Rtf
        mVolumeBalancePage.WordWrap = False
        mVolumeBalancePage.ScrollBars = RichTextBoxScrollBars.None

        mVolumeBalanceRtfPage.AccessibleName = title
        mVolumeBalanceRtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Volume Balance data
        mPageNumber += 1
        mVolumeBalancePageNumber = mPageNumber
        UpdateVolumeBalancePage()

        ' Make the Full Page visible
        AddTabPage(tabName, mVolumeBalanceRtfPage)

    End Sub

    Private mVolumeBalancePageNumber As Integer
    Private Sub UpdateVolumeBalancePage()

        If (mVolumeBalancePage IsNot Nothing) Then
            ' mVolumeBalancePage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mVolumeBalancePage.Clear()

                ' Header
                DisplayResultsHeader(mVolumeBalancePage)

                ' Section Title
                mVolumeBalancePage.SelectionAlignment = HorizontalAlignment.Left

                ' Surface Volumes / Volume Balances table
                Dim evlVolBalances As DataTable = Nothing
                Dim simVolBalances As DataTable = Nothing

                ' Sigma Z tables
                Dim simSigmaZs As DataTable = Nothing
                Dim preSigmaZs As DataTable = Nothing

                Select Case mEventCriteria.EventAnalysisType.Value
                    Case EventAnalysisTypes.EvalueAnalysis

                        Dim curAnalysis As Analysis = mWorldWindow.CurrentAnalysis
                        Dim evalueAnalysis As EVALUE = DirectCast(curAnalysis, EVALUE)

                        evlVolBalances = mEventCriteria.VolumeBalances.Value
                        simVolBalances = mEventCriteria.SimulationVolumeBalances.Value

                        ' Update availability of "Refine Predicted Vz" button
                        Dim usePowerLaw, useStandard, useAdvanced As Boolean
                        evalueAnalysis.PredictedIntegrationMethod(usePowerLaw, useStandard, useAdvanced)

                        ' Power Law integration can be improved using simulation's Sigma Zs
                        If (usePowerLaw) Then ' Power Law integration; show button
                            simSigmaZs = evalueAnalysis.SimulationSigmaZtable
                            preSigmaZs = evalueAnalysis.PredictedSigmaZTablePwrAdv
                        End If

                    Case EventAnalysisTypes.MerriamKellerAnalysis
                        DisplayVolumeBalanceCalculations(mVolumeBalancePage)
                    Case EventAnalysisTypes.TwoPointAnalysis
                        DisplayVolumeBalanceCalculations(mVolumeBalancePage)
                End Select
                '
                ' Volume Balance error graph
                '
                If ((evlVolBalances IsNot Nothing) And (simVolBalances IsNot Nothing)) Then

                    Dim openEnd As Boolean = (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd)

                    ' Build Volume Balance Error curve to graph
                    Dim VBEtable As DataTable = New DataTable("Volume Balance Error")
                    VBEtable.Columns.Add("Time", GetType(Double))
                    VBEtable.Columns.Add("VBE (Vy)", GetType(Double))
                    If (openEnd) Then
                        VBEtable.Columns.Add("VBE (Vro)", GetType(Double))
                    End If
                    VBEtable.Columns.Add("VBE (Vz)", GetType(Double))
                    VBEtable.ExtendedProperties.Add("Symbol", "O")
                    VBEtable.ExtendedProperties.Add("Fill O", True)

                    VBEtable.Columns(1).ExtendedProperties.Add("Key", True)
                    VBEtable.Columns(1).ExtendedProperties.Add("Key Text", "VBE (Vy)")
                    If (openEnd) Then
                        VBEtable.Columns(2).ExtendedProperties.Add("Key", True)
                        VBEtable.Columns(2).ExtendedProperties.Add("Key Text", "VBE (Vro)")
                        VBEtable.Columns(3).ExtendedProperties.Add("Key", True)
                        VBEtable.Columns(3).ExtendedProperties.Add("Key Text", "VBE (Vz)")
                    Else
                        VBEtable.Columns(2).ExtendedProperties.Add("Key", True)
                        VBEtable.Columns(2).ExtendedProperties.Add("Key Text", "VBE (Vz)")
                    End If

                    ' Build Volume Balance table for copy command
                    Dim VBtable As DataTable = New DataTable("Volume Balance Table")
                    VBtable.Columns.Add("Time", GetType(Double))

                    VBtable.Columns.Add("VB Vin (m³)", GetType(Double))
                    VBtable.Columns.Add("VB Vy (m³)", GetType(Double))
                    VBtable.Columns.Add("VB Vro (m³)", GetType(Double))
                    VBtable.Columns.Add("VB Vz (m³)", GetType(Double))

                    VBtable.Columns.Add("Sim Vin (m³)", GetType(Double))
                    VBtable.Columns.Add("Sim Vy (m³)", GetType(Double))
                    VBtable.Columns.Add("Sim Vro (m³)", GetType(Double))
                    VBtable.Columns.Add("Sim Vz (m³)", GetType(Double))

                    VBtable.Columns.Add("VBE Vy (%)", GetType(Double))
                    VBtable.Columns.Add("VBE Vro (%)", GetType(Double))
                    VBtable.Columns.Add("VBE Vz (%)", GetType(Double))

                    Dim ptCount As Integer = Math.Min(evlVolBalances.Rows.Count, simVolBalances.Rows.Count)

                    For vdx As Integer = 0 To ptCount - 1
                        Dim evlRow As DataRow = evlVolBalances.Rows(vdx)
                        Dim simRow As DataRow = simVolBalances.Rows(vdx)

                        Dim evlT As Double = evlRow.Item(nTimeX)
                        Dim simT As Double = simRow.Item(nTimeX)

                        Debug.Assert(evlT = simT)

                        Dim evlVin As Double = evlRow.Item(sVin)
                        Dim evlVy As Double = evlRow.Item(sVy)
                        Dim evlVro As Double = evlRow.Item(sVro)
                        Dim evlVz As Double = evlRow.Item(sVz)

                        Dim simVin As Double = simRow.Item(sVin)
                        Dim simVy As Double = simRow.Item(sVy)
                        Dim simVro As Double = simRow.Item(sVro)
                        Dim simVz As Double = simRow.Item(sVz)

                        Dim vbeVin As Double = (evlVin - simVin) / simVin
                        Dim vbeVy As Double = (evlVy - simVy) / simVin
                        Dim vbeVro As Double = (evlVro - simVro) / simVin
                        Dim vbeVz As Double = (evlVz - simVz) / simVin

                        ' Add Volume Balance Error point to curve
                        Dim VBErow As DataRow = VBEtable.NewRow
                        VBErow.Item(0) = evlT
                        VBErow.Item(1) = vbeVy
                        If (openEnd) Then
                            VBErow.Item(2) = vbeVro
                            VBErow.Item(3) = vbeVz
                        Else
                            VBErow.Item(2) = vbeVz
                        End If
                        VBEtable.Rows.Add(VBErow)

                        ' Add Volume Balance table row for copy command
                        Dim VBrow As DataRow = VBtable.NewRow
                        VBrow.Item(0) = evlT

                        VBrow.Item(1) = evlVin
                        VBrow.Item(2) = evlVy
                        VBrow.Item(3) = evlVro
                        VBrow.Item(4) = evlVz

                        VBrow.Item(5) = simVin
                        VBrow.Item(6) = simVy
                        VBrow.Item(7) = simVro
                        VBrow.Item(8) = simVz

                        VBrow.Item(9) = vbeVy
                        VBrow.Item(10) = vbeVro
                        VBrow.Item(11) = vbeVz

                        VBtable.Rows.Add(VBrow)
                    Next vdx

                    ' Combine data to graph into a DataSet
                    Dim VBEset As DataSet = New DataSet("Volume Balance Error")
                    VBEset.Tables.Add(VBEtable)

                    Dim VBEgraph As ctl_Graph2D = New ctl_Graph2D(VBEset)
                    LoadUserColors(VBEgraph)

                    VBEgraph.UnitsX = Units.Seconds
                    VBEgraph.UnitsY = Units.Percentage
                    VBEgraph.DisplayKey = True
                    VBEgraph.HorizontalKeys = True

                    VBEgraph.MaxY = 0.1     ' Minimun Y scale is +-10%
                    VBEgraph.MinY = -0.1

                    Dim graph1Width As Integer = PortraitGraphWidth
                    Dim graph1Height As Integer = graph1Width
                    Dim graph1LocY As Integer = PortraitGraphTop + 16
                    If (preSigmaZs IsNot Nothing) Then
                        graph1Height = graph1Width / 2
                    End If

                    VBEgraph.Location = New Point(PortraitGraphLeft, graph1LocY)
                    VBEgraph.Size = New Size(graph1Width, graph1Height)

                    mVolumeBalanceRtfPage.AddImage(VBEgraph)

                    VBEgraph.DrawImage()

                    ' Combine data for copy command into a DataSet
                    Dim VBset As DataSet = New DataSet("Volume Balances")
                    VBset.Tables.Add(VBtable)
                    VBEgraph.CopyDataSet = VBset
                    '
                    ' Sigma Z graph
                    '
                    If (preSigmaZs IsNot Nothing) Then

                        simSigmaZs.ExtendedProperties.Add("Symbol", "O")
                        simSigmaZs.ExtendedProperties.Add("Fill O", True)

                        simSigmaZs.Columns(1).ExtendedProperties.Add("Key", True)
                        simSigmaZs.Columns(1).ExtendedProperties.Add("Key Text", "Simulation")

                        preSigmaZs.ExtendedProperties.Add("Symbol", "O")
                        preSigmaZs.ExtendedProperties.Add("Fill O", True)

                        preSigmaZs.Columns(1).ExtendedProperties.Add("Key", True)
                        preSigmaZs.Columns(1).ExtendedProperties.Add("Key Text", "Predicted")

                        Dim SigZs As DataSet = New DataSet("Shape Factors")
                        SigZs.Tables.Add(simSigmaZs)
                        SigZs.Tables.Add(preSigmaZs)

                        Dim SigZgraph As ctl_Graph2D = New ctl_Graph2D(SigZs)

                        SigZgraph.UnitsX = Units.Seconds
                        SigZgraph.UnitsY = Units.None
                        SigZgraph.DisplayKey = True
                        SigZgraph.HorizontalKeys = True

                        SigZgraph.MaxY = 1.0

                        Dim graph2LocY As Integer = graph1LocY + graph1Height + 32

                        SigZgraph.Location = New Point(PortraitGraphLeft, graph2LocY)
                        SigZgraph.Size = New Size(graph1Width, graph1Height)

                        mVolumeBalanceRtfPage.AddImage(SigZgraph)

                        SigZgraph.DrawImage()

                    End If
                End If

                ' Footer
                DisplayResultsFooter(mVolumeBalancePage, mVolumeBalancePageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mVolumeBalancePage = Nothing
            End Try
        End If

    End Sub
    '
    ' Surface Flow Measured Page (includes embedded graphs)
    '
    Private Sub AddSurfaceFlowMeasuredPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        mSurfaceFlowMeasuredRtfPage = GetNewResultsPage(title, ResultsView)
        mSurfaceFlowMeasuredPage = mSurfaceFlowMeasuredRtfPage.Rtf
        mSurfaceFlowMeasuredPage.WordWrap = False
        mSurfaceFlowMeasuredPage.ScrollBars = RichTextBoxScrollBars.None

        mSurfaceFlowMeasuredRtfPage.AccessibleName = title
        mSurfaceFlowMeasuredRtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Surface Flow data
        mPageNumber += 1
        mSurfaceFlowMeasuredNumber = mPageNumber
        UpdateSurfaceFlowMeasuredPage()

        ' Make the Full Page visible
        AddTabPage(tabName, mSurfaceFlowMeasuredRtfPage)

    End Sub

    Private mSurfaceFlowMeasuredNumber As Integer
    Private Sub UpdateSurfaceFlowMeasuredPage()

        If (mSurfaceFlowMeasuredPage IsNot Nothing) Then
            ' mSurfaceFlowSummaryPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mSurfaceFlowMeasuredPage.Clear()

                ' Header
                DisplayResultsHeader(mSurfaceFlowMeasuredPage, "Measured Surface Volumes")
                ' Left justify table
                mSurfaceFlowMeasuredPage.SelectionAlignment = HorizontalAlignment.Left
                '
                ' Tabulated surface volumes (Vy) from volume balances (Vz = Vin - Vy - Vro)
                '
                Dim volumeBalances As DataTable = mEventCriteria.VolumeBalances.Value
                If (volumeBalances IsNot Nothing) Then
                    Dim rowCount As Integer = volumeBalances.Rows.Count     ' Entries in volume balance table
                    If (0 < rowCount) Then
                        AdvanceLines(mSurfaceFlowMeasuredPage, 36) ' Advance past the bottom graph

                        AppendBoldUnderlineLine(mSurfaceFlowMeasuredPage, "Surface Volumes")
                        AdvanceLine(mSurfaceFlowMeasuredPage)

                        ' Sizes available for surface volume table
                        Dim svPerCol As Integer = 7                         ' Column depth
                        Dim colPerLine As Integer = 4                       ' Columns per line
                        Dim TcolWidth As Integer = 7                        ' Width for time column
                        Dim VcolWidth As Integer = 8                        ' Width for surface volume column
                        Dim vbMax As Integer = svPerCol * colPerLine        ' Max entries on page
                        Dim vbCount As Integer = Math.Min(vbMax, rowCount)  ' Number of entries to print

                        ' Get column headings
                        Dim timeText As String = UnitHeading(volumeBalances.Columns(nTimeX).ColumnName)
                        Dim volumeText As String = UnitHeading(volumeBalances.Columns(sVy).ColumnName)

                        Dim timeUnits As Units = mUnitsSystem.TimeUnits
                        Dim volumeUnits As Units = mUnitsSystem.VolumeUnits

                        If (timeText.StartsWith("Time")) Then
                            timeText = "T" & timeText.Substring(4)
                        End If

                        ' Output column headers
                        While (0 < vbCount)
                            AppendBoldText(mSurfaceFlowMeasuredPage, RightJustifyFill(timeText, TcolWidth))
                            AppendBoldText(mSurfaceFlowMeasuredPage, RightJustifyFill(volumeText, VcolWidth))
                            AppendText(mSurfaceFlowMeasuredPage, "     ")
                            vbCount -= svPerCol
                        End While
                        AdvanceLine(mSurfaceFlowMeasuredPage)

                        ' Output column data
                        vbCount = Math.Min(rowCount, vbMax) ' number of entries that can fit
                        If (vbMax < rowCount) Then ' there are more entries
                            vbCount -= 2 ' last two entries treated differently
                        End If

                        Dim svIdx As Integer = 0
                        For vdx As Integer = 1 To svPerCol ' output data line by line
                            For cdx As Integer = 1 To colPerLine ' fill line with columns
                                svIdx = (vdx - 1) + (cdx - 1) * svPerCol
                                If (svIdx < vbCount) Then
                                    Dim vbRow As DataRow = volumeBalances.Rows(svIdx)
                                    Dim T As Double = UnitTime(vbRow.Item(nTimeX))
                                    Dim Vy As Double = vbRow.Item(sVy)
                                    If (timeUnits = Units.Minutes) Then
                                        timeText = RightJustifyFill(Format(T, "0.0"), TcolWidth)
                                    Else
                                        timeText = RightJustifyFill(Format(T, "0.00"), TcolWidth)
                                    End If
                                    volumeText = UnitText(Vy, volumeUnits, VcolWidth)
                                    AppendText(mSurfaceFlowMeasuredPage, timeText & volumeText & "     ")
                                End If
                            Next cdx

                            ' last two entries may indicate 'not all data could be printed'
                            If (vbCount = vbMax - 2) Then ' not all entries could fit
                                If (svIdx = vbMax - 2) Then ' indicate not all entries could fit
                                    timeText = RightJustifyFill(". . .", TcolWidth)
                                    volumeText = RightJustifyFill(". . .", VcolWidth)
                                    AppendText(mSurfaceFlowMeasuredPage, timeText & volumeText)
                                ElseIf (svIdx = vbMax - 1) Then ' output data from last Volume Balance
                                    Dim vbRow As DataRow = volumeBalances.Rows(rowCount - 1)
                                    Dim T As Double = UnitTime(vbRow.Item(nTimeX))
                                    Dim Vy As Double = vbRow.Item(sVy)
                                    If (timeUnits = Units.Minutes) Then
                                        timeText = RightJustifyFill(Format(T, "0.0"), TcolWidth)
                                    Else
                                        timeText = RightJustifyFill(Format(T, "0.00"), TcolWidth)
                                    End If
                                    volumeText = UnitText(Vy, volumeUnits, VcolWidth)
                                    AppendText(mSurfaceFlowMeasuredPage, timeText & volumeText & "     ")
                                End If
                            End If
                            AdvanceLine(mSurfaceFlowMeasuredPage)
                        Next vdx

                    Else
                        AdvanceLine(mSurfaceFlowMeasuredPage)
                        AppendLine(mSurfaceFlowMeasuredPage, "Tabulated Volume Balances not available")
                    End If
                End If
                '
                ' Surface Flow Elevation Profiles (which are based on Station Flow Depth Hydrographs)
                '
                Dim volTable As DataTable = mEventCriteria.VolumeBalances.Value
                Dim times As Double() = GetDoubleColumn(volTable, nTimeX)

                Dim flowDepthHydrographs As DataSet = mInflowManagement.StationsFlowDepths.Value
                flowDepthHydrographs.ExtendedProperties.Add("Title", "Flow Depth Hydrographs")

                Dim flowElevationProfiles As DataSet = mInflowManagement.FlowElevationProfiles(flowDepthHydrographs, times)
                flowElevationProfiles.ExtendedProperties.Add("Title", "Surface Elevation Profiles")

                Dim flowElevationGraph As ctl_Graph2D = New ctl_Graph2D(flowElevationProfiles)
                LoadUserColors(flowElevationGraph)

                ' Also locate flow elevation profile that is 'best' for highlighting calculations
                Dim Tco As Double = mSurfaceFlow.Tco.Value
                Dim TL As Double = mSurfaceFlow.TL.Value
                Dim srfrTime As Double = MathMin(Tco, TL)
                Dim hiTime As Double = Double.MaxValue

                ' Add keys & find 'highlight' profile for Surface Flow Elevation Profiles
                For tdx As Integer = 0 To flowElevationProfiles.Tables.Count - 1
                    Dim elevProfile As DataTable = flowElevationProfiles.Tables(tdx)
                    ' Add keys
                    elevProfile.ExtendedProperties.Add("Key", True)
                    If (elevProfile.ExtendedProperties.Contains(sTimeX)) Then
                        Dim time As Double = elevProfile.ExtendedProperties(sTimeX)
                        Dim timeText As String = "T=" & TimeString(time)
                        elevProfile.ExtendedProperties.Add("Key Text", timeText)

                        If (Math.Abs(time - srfrTime) < Math.Abs(hiTime - srfrTime)) Then
                            hiTime = time
                        End If
                    End If
                Next tdx

                ' Add symbols to Surface Flow Elevation Profile
                Dim zaProfile As DataTable = flowElevationProfiles.Tables(0)
                Dim depth As Double = Double.MaxValue
                For tdx As Integer = 1 To flowElevationProfiles.Tables.Count - 1
                    Dim elevProfile As DataTable = flowElevationProfiles.Tables(tdx)
                    ' Add symbols
                    If (elevProfile.ExtendedProperties.Contains(sTimeX)) Then
                        Dim time As Double = elevProfile.ExtendedProperties(sTimeX)
                        If (time = hiTime) Then
                            For rdx As Integer = 0 To elevProfile.Rows.Count - 1
                                Dim zaRow As DataRow = zaProfile.Rows(rdx)
                                Dim zaDist As Double = zaRow.Item(sDistanceX)
                                Dim zaElev As Double = zaRow.Item(sElevationX)

                                Dim elevRow As DataRow = elevProfile.Rows(rdx)
                                Dim dist As Double = elevRow.Item(sDistanceX)
                                Dim elev As Double = elevRow.Item(sElevationX)

                                If (0.0 < depth) Then
                                    depth = elev - zaElev
                                    flowElevationGraph.AddGraphSymbol(dist, elev, "o", flowElevationGraph.ColorN(rdx + 1), 3)
                                End If
                            Next rdx
                        End If
                    End If
                Next tdx

                flowElevationGraph.UnitsX = UnitsDefinition.Units.Meters
                flowElevationGraph.UnitsY = UnitsDefinition.Units.Meters

                Dim minY As Double = DataStore.Utilities.DataColumnMin(flowElevationProfiles, sElevationX)
                minY = (CInt(minY * CentimetersPerMeter - 0.5)) / CentimetersPerMeter

                Dim maxY As Double = DataStore.Utilities.DataColumnMax(flowElevationProfiles, sElevationX)
                maxY = (CInt(maxY * CentimetersPerMeter + 0.5)) / CentimetersPerMeter

                flowElevationGraph.SetMinMaxY(minY, maxY)
                flowElevationGraph.DisplayKey = True
                flowElevationGraph.HorizontalKeys = True
                flowElevationGraph.FontAdjustment = 1
                flowElevationGraph.LastCurve = 0

                flowElevationGraph.Location = New Point(PortraitGraphLeft, PortraitGraphTop + 320)
                flowElevationGraph.Size = New Size(PortraitGraphWidth, 280)

                mSurfaceFlowMeasuredRtfPage.AddImage(flowElevationGraph)

                flowElevationGraph.DrawImage()
                '
                ' Measured Station Flow Depth Hydrographs
                '
                Dim flowDepthGraph As ctl_Graph2D = New ctl_Graph2D(flowDepthHydrographs)
                LoadUserColors(flowDepthGraph)

                ' Add keys & symbols to Station Flow Depth Hydrographs
                depth = Double.MaxValue
                For tdx As Integer = 0 To flowDepthHydrographs.Tables.Count - 1
                    Dim depthHydrograph As DataTable = flowDepthHydrographs.Tables(tdx)
                    ' Add keys
                    depthHydrograph.ExtendedProperties.Add("Key", True)
                    If (depthHydrograph.ExtendedProperties.Contains(sDistanceX)) Then
                        Dim dist As Double = depthHydrograph.ExtendedProperties(sDistanceX)
                        Dim distText As String = "X=" & LengthString(dist)
                        depthHydrograph.ExtendedProperties.Add("Key Text", distText)
                    End If
                    ' Add symbol at selected Elevation Profile time
                    If (0.0 < depth) Then
                        depth = GetYforX(depthHydrograph, nTimeX, hiTime, nDepthX1)
                        flowDepthGraph.AddGraphSymbol(hiTime, depth, "o", flowDepthGraph.ColorN(tdx + 1), 3)
                    End If
                Next tdx

                flowDepthGraph.UnitsX = UnitsDefinition.Units.Seconds
                flowDepthGraph.UnitsY = UnitsDefinition.Units.Meters
                flowDepthGraph.DisplayKey = True
                flowDepthGraph.HorizontalKeys = True
                flowDepthGraph.FontAdjustment = 1
                flowDepthGraph.ClearVertLines()
                flowDepthGraph.AddVertLine(hiTime)

                flowDepthGraph.Location = New Point(PortraitGraphLeft, PortraitGraphTop + 16)
                flowDepthGraph.Size = New Size(PortraitGraphWidth, 280)

                mSurfaceFlowMeasuredRtfPage.AddImage(flowDepthGraph)

                flowDepthGraph.DrawImage()

                ' Footer
                DisplayResultsFooter(mSurfaceFlowMeasuredPage, mSurfaceFlowMeasuredNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mSurfaceFlowMeasuredPage = Nothing
            End Try
        End If

    End Sub
    '
    ' Add Hydraulic Summary output tab
    '
    Private Sub AddHydraulicSummaryGraph(ByVal title As String, Optional ByVal tabName As String = "")

        If (mUnit IsNot Nothing) Then

            If (tabName Is Nothing) Then
                tabName = title
            ElseIf (tabName = "") Then
                tabName = title
            End If
            '
            ' Create DataSets for graphs
            '   Advance / Recession
            '   Infiltration / Target Depth
            '   Inflow / Runoff Hydrographs
            '
            Dim _advRec As DataSet = New DataSet(title)
            Dim _infilt As DataSet = New DataSet(title)
            Dim _hydro As DataSet = New DataSet(title)

            _advRec.ExtendedProperties.Add("ExtTitle", "w/ " & mDictionary.tSimulationResults.Translated)
            _advRec.ExtendedProperties.Add("Color", WinSRFR.UserPreferences.Color2)

            ' Get SRFR Simulation Results
            Dim _simAdv As DataTable = mSurfaceFlow.Advance.Value
            Dim _simRec As DataTable = mSurfaceFlow.Recession.Value
            Dim _simInf As DataTable = mSubsurfaceFlow.LongitudinalInfiltration.Value
            Dim _hydroflow As DataTable = mSurfaceFlow.FlowHydrographs.Value

            ' Assemble the data to graph
            If (DataTableHasData(_simAdv) _
            And DataTableHasData(_simRec) _
            And DataTableHasData(_simInf) _
            And DataTableHasData(_hydroflow)) Then

                _simAdv.TableName = "Simulation Advance"
                _simRec.TableName = "Simulation Recession"
                _simInf.TableName = "Simulation Infiltration"
                _hydroflow.TableName = "Simulation Hydrographs"

                _simAdv.ExtendedProperties.Add("Color", WinSRFR.UserPreferences.Color2)
                _simRec.ExtendedProperties.Add("Color", WinSRFR.UserPreferences.Color2)
                _simInf.ExtendedProperties.Add("Color", WinSRFR.UserPreferences.Color2)

                ' Advance / Recession
                Dim _advance As DataTable = Nothing
                If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                    _advance = mInflowManagement.TwoPointTabulatedAdvance.Value
                    _advance.TableName = "Advance"
                    _advance.ExtendedProperties.Add("Symbol", "O")
                    _advance.ExtendedProperties.Add("Line", True)
                    _advRec.Tables.Add(_advance.Copy)
                Else
                    If (mInflowManagement.AdvanceMeasured.Value) Then
                        If (mInflowManagement.TabulatedAdvanceHasData) Then
                            ' Add user input Advance
                            _advance = mInflowManagement.TabulatedAdvance.Value
                            _advance.TableName = "Advance"
                            _advance.ExtendedProperties.Add("Symbol", "O")
                            _advance.ExtendedProperties.Add("Line", True)
                            _advRec.Tables.Add(_advance.Copy)
                        End If
                    End If
                End If

                Dim _recession As DataTable = Nothing
                If Not (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                    If (mInflowManagement.RecessionDataAvailable) Then
                        ' Add user input Recession
                        _recession = mInflowManagement.TabulatedRecession.Value
                        _recession.TableName = "Recession"
                        _recession.ExtendedProperties.Add("Symbol", "O")
                        _recession.ExtendedProperties.Add("Line", True)
                        _advRec.Tables.Add(_recession.Copy)
                    End If
                End If

                _advRec.Tables.Add(_simAdv.Copy)
                _advRec.Tables.Add(_simRec.Copy)

                ' Infiltration / Target Depth
                Dim _infiltration As DataTable = mSoilCropProperties.Infiltration.Value
                _infiltration.TableName = mDictionary.tInfiltration.Translated
                _infiltration.ExtendedProperties.Add("Symbol", "O")
                _infiltration.ExtendedProperties.Add("Line", True)

                Dim _label As String = mDictionary.tRequiredDepth.Translated
                Dim _depth As Double = mInflowManagement.RequiredDepth.Value
                Dim _fieldLength As Double = mSystemGeometry.Length.Value
                Dim _dreqTable As DataTable = DepthTable(_label, _depth, _infiltration.Columns(0).ColumnName, _fieldLength)

                _dreqTable.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                _infilt.Tables.Add(_infiltration.Copy)
                _infilt.Tables.Add(_dreqTable)
                _infilt.Tables.Add(_simInf.Copy)

                ' Flow Hydrographs
                _hydroflow.ExtendedProperties.Add("Color", WinSRFR.UserPreferences.Color2)
                _hydro.Tables.Add(_hydroflow.Copy)

                Dim _qin As DataTable = mInflowManagement.InflowTableForCrossSection()
                _hydro.Tables.Add(_qin)

                If (mInflowManagement.RunoffMeasured.Value) Then
                    If (mInflowManagement.RunoffDataAvailable) Then
                        ' Add user input Runoff
                        Dim _qro As DataTable = mInflowManagement.RunoffTableForCrossSection
                        _hydro.Tables.Add(_qro)
                    End If
                End If
                '
                ' Full Page view for Display, Print & Print Preview
                '
                Dim _2dGraph As grf_XYGraph

                _2dGraph = GetNewHydraulicSummaryPage(_advRec, _infilt, _hydro, title)
                _2dGraph.UnitsX = UnitsDefinition.Units.Meters
                _2dGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPage(title, tabName, _2dGraph)
                '
                ' Graphic Only view for Display
                '
                _2dGraph = GetNewHydraulicSummaryPanel(_advRec, _infilt, _hydro, title)
                _2dGraph.UnitsX = UnitsDefinition.Units.Meters
                _2dGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPanel(title, tabName, _2dGraph)

            End If
        End If

    End Sub
    '
    ' Inflow / Runoff Graph
    '
    Private Sub AddInflowRunoffGraphPage(ByVal title As String, Optional ByVal tabName As String = "")
        If (mUnit IsNot Nothing) Then

            Dim _2dGraph As grf_XYGraph

            If (tabName Is Nothing) Then
                tabName = title
            ElseIf (tabName = "") Then
                tabName = title
            End If

            ' Create DataSet for graph
            '   Inflow curve
            '   Runoff curve
            Dim _dataSet As DataSet = New DataSet(title)

            ' Add Mass Balance inset
            Dim Vapp As Double = mInflowManagement.AppliedVolumeForField
            Dim Vro As Double = mInflowManagement.RunoffVolumeForField
            Dim Vinf As Double = mInflowManagement.InfiltratedVolumeForField

            Dim _massBalance(4) As String

            _massBalance(0) = " " & mDictionary.tVolumeBalance.Translated
            _massBalance(1) = mDictionary.tAppliedVolume.Translated(20) & ":  " & FieldVolumeString(Vapp, 11)

            Dim _runoffInput As Boolean = mInflowManagement.RunoffDataAvailable
            If ((mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) And Not (_runoffInput)) Then
                ' Open End wo/ Runoff
                _massBalance(2) = "- " & mDictionary.tRunoffVolume.Translated(18) & ":  " & "      N/A"
                _massBalance(3) = "= " & mDictionary.tInfiltratedVolume.Translated(18) & ":  " & "      N/A"
            Else
                ' Blocked End or Open End w/ Runoff
                _massBalance(2) = "- " & mDictionary.tRunoffVolume.Translated(18) & ":  " & FieldVolumeString(Vro, 11)
                _massBalance(3) = "= " & mDictionary.tInfiltratedVolume.Translated(18) & ":  " & FieldVolumeString(Vinf, 11)
            End If

            _dataSet.ExtendedProperties.Add("Inset", _massBalance)

            ' Add user input Inflow data
            Dim _dataTable As DataTable = Nothing

            Select Case mInflowManagement.InflowMethod.Value
                Case InflowMethods.StandardHydrograph
                    _dataTable = mInflowManagement.HydrographInflowTable
                    _dataTable.TableName = mDictionary.tStandardHydrograph.Translated

                Case InflowMethods.Cablegation
                    _dataTable = mInflowManagement.CablegationInflowTable
                    _dataTable.TableName = mDictionary.tTabulatedInflow.Translated

                Case InflowMethods.TabulatedInflow
                    _dataTable = mInflowManagement.TabulatedInflow.Value
                    _dataTable.TableName = mDictionary.tTabulatedInflow.Translated

                    If (_dataTable IsNot Nothing) Then
                        _dataTable.ExtendedProperties.Add("Symbol", "O")
                        _dataTable.ExtendedProperties.Add("Line", True)
                    End If
                Case Else
                    Debug.Assert(False) ' Support for this Inflow Method must be added
            End Select

            If DataTableHasData(_dataTable) Then

                _dataTable.Columns(0).ColumnName = mDictionary.tTime.Translated
                _dataTable.Columns(1).ColumnName = mDictionary.tInflow.Translated
                _dataTable.ExtendedProperties.Add("Key", True)
                _dataSet.Tables.Add(_dataTable.Copy)

                ' Add user input Runoff data; if available
                If (_runoffInput) Then
                    _dataTable = mInflowManagement.RunoffTableForCrossSection

                    _dataTable.TableName = mDictionary.tTabulatedRunoff.Translated
                    _dataTable.ExtendedProperties.Add("Key", True)
                    _dataTable.ExtendedProperties.Add("Symbol", "O")
                    _dataTable.ExtendedProperties.Add("Line", True)
                    _dataSet.Tables.Add(_dataTable.Copy)
                End If

                ' Add simulated Runoff data
                _dataTable = mSurfaceFlow.RunoffTable

                If DataTableHasData(_dataTable) Then
                    _dataTable.TableName = mDictionary.tSimulatedRunoff.Translated
                    _dataTable.ExtendedProperties.Add("Key", True)
                    _dataTable.ExtendedProperties.Add("Line", True)
                    _dataSet.Tables.Add(_dataTable.Copy)
                End If
                '
                ' Full Page view for Display, Print & Print Preview
                '
                _2dGraph = Me.GetNewXYGraphPage(_dataSet, title)
                _2dGraph.DisplayKey = True
                _2dGraph.UnitsX = UnitsDefinition.Units.Seconds
                _2dGraph.UnitsY = UnitsDefinition.Units.Cms

                AddResultsPage(title, tabName, _2dGraph)
                '
                ' Graphic Only view for Display
                '
                _2dGraph = GetNewXYGraphPanel(_dataSet, title)
                _2dGraph.DisplayKey = True
                _2dGraph.UnitsX = UnitsDefinition.Units.Seconds
                _2dGraph.UnitsY = UnitsDefinition.Units.Cms

                AddResultsPanel(title, tabName, _2dGraph)

            End If
        End If

    End Sub
    '
    ' Infiltration Function Graph
    '
    Private Sub AddInfiltrationFunctionGraphPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        If (mUnit IsNot Nothing) Then

            Dim x2yGraph As grf_X2YGraph                                        ' X2Y graph class

            ' Create DataSet for X2Y graph
            '  Left axis (AZ vs T)
            '   Infiltration Function
            '  Right axis (AZ/FS | AZ/W vs T)
            '   Infiltration Depth Function
            '   Required Infiltrated Depth
            Dim _dataSet As DataSet = New DataSet(" " & title & " ")
            Dim tTime As String = mDictionary.tTime.Translated

            Dim _depthFunc As DataTable = mSoilCropProperties.InfiltrationFunctionDataTable(0.0, 250)

            If DataTableHasData(_depthFunc) Then
                If (DataColumnIsDouble(_depthFunc, sTimeX)) Then

                    ' Infiltration Function
                    Dim _width As Double = mSystemGeometry.WidthForCrossSection
                    Dim _infFunc As DataTable = _depthFunc.Copy
                    For Each _infRow As DataRow In _infFunc.Rows
                        Dim z As Double = _infRow(1)
                        Dim az As Double = z * _width
                        _infRow(1) = az
                    Next

                    _infFunc.Columns(0).ColumnName = tTime
                    _infFunc.Columns(1).ColumnName = "AZ"
                    _infFunc.TableName = "AZ"
                    _dataSet.Tables.Add(_infFunc.Copy)

                    ' Infiltration Depth Function
                    _depthFunc.Columns(0).ColumnName = tTime
                    If (mUnit.CrossSection = CrossSections.Furrow) Then
                        _depthFunc.Columns(1).ColumnName = "AZ/FS"
                        _depthFunc.TableName = "AZ/FS"
                    Else
                        _depthFunc.Columns(1).ColumnName = "AZ/W"
                        _depthFunc.TableName = "AZ/W"
                    End If
                    _depthFunc.ExtendedProperties.Add("Color", Drawing.Color.Blue)
                    _dataSet.Tables.Add(_depthFunc.Copy)

                    ' Required Depth (Dreq)
                    Dim _dreq As Double = mInflowManagement.RequiredDepth.Value
                    Dim _lastRow As DataRow = _depthFunc.Rows.Item(_depthFunc.Rows.Count - 1)
                    Dim tMax As Double = CDbl(_lastRow.Item(0))

                    Dim _dreqTable As DataTable = DreqTable(_dreq, _depthFunc.Columns(0).ColumnName, tMax)
                    _dreqTable.TableName = mDictionary.tRequiredDepth.Translated

                    ' Add Dreq line as Time vs. Dreq
                    Dim dreqTime As DataTable = _dreqTable.Copy
                    dreqTime.Columns(0).ColumnName = sTimeX     ' was sDistanceX
                    dreqTime.Rows(0)(0) = 0.0
                    dreqTime.Rows(1)(0) = tMax                  ' was field length
                    _dataSet.Tables.Add(dreqTime)
                    '
                    ' Full Page view for Display, Print & Print Preview
                    '
                    x2yGraph = Me.GetNewX2YGraphPage(_dataSet, title)
                    x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                    x2yGraph.UnitsY = UnitsDefinition.Units.SquareMeters
                    x2yGraph.UnitsY2 = UnitsDefinition.Units.Millimeters

                    AddResultsPage(title, tabName, x2yGraph)
                    '
                    ' Graphic Only view for Display
                    '
                    x2yGraph = GetNewX2YGraphPanel(_dataSet, title)
                    x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                    x2yGraph.UnitsY = UnitsDefinition.Units.SquareMeters
                    x2yGraph.UnitsY2 = UnitsDefinition.Units.Millimeters

                    AddResultsPanel(title, tabName, x2yGraph)

                End If
            End If
        End If

    End Sub
    '
    ' EVALUE Goodness of Fit
    '
    Private Sub AddEvalueGoodnessOfFitPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mEvalueGoodnessPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Advance / Recession
        mPageNumber += 1
        mEvalueGoodnessOfFitPageNumber = mPageNumber
        UpdateEvalueGoodnessOfFitPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mEvalueGoodnessOfFitPageNumber As Integer
    Private Sub UpdateEvalueGoodnessOfFitPage()

        If (mEvalueGoodnessPage IsNot Nothing) Then
            ' mEvalueGoodnessPage may be defined but Disposed; this causes an exception
            Try
                Dim _area As Double = mSystemGeometry.FieldArea

                ' Clear the old contents
                mEvalueGoodnessPage.Clear()

                ' Header
                DisplayResultsHeader(mEvalueGoodnessPage)

                mEvalueGoodnessPage.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(mEvalueGoodnessPage, mDictionary.tEstimatedParameters.Translated)
                AdvanceLine(mEvalueGoodnessPage)

                ' Roughness Parameters
                DisplayRoughnessParameters(mEvalueGoodnessPage)

                ' Infiltration Parameters
                Dim k As Double = mSoilCropProperties.KostiakovK
                Dim a As Double = mSoilCropProperties.KostiakovA
                Dim b As Double = mSoilCropProperties.KostiakovB
                Dim c As Double = mSoilCropProperties.KostiakovC

                Dim kText As String = "  k:  " & KostiakovKParameter.KostiakovKString(k, a, KostiakovKParameter.DisplayUnits, 0)
                Dim aText As String = "  a:  " & Format(a, "0.00#")
                Dim bText As String = "  b:  " & InfiltrationRateString(b, 0)
                Dim cText As String = "  c:  " & DepthString(c, 0)

                Dim wpText As String = "  "
                If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                    wpText &= WettedPerimeterMethodSelections(mSoilCropProperties.WettedPerimeterMethod.Value).Value
                End If

                Select Case (mSoilCropProperties.InfiltrationFunction.Value)

                    Case InfiltrationFunctions.NRCSIntakeFamily
                        AppendBoldText(mEvalueGoodnessPage, mDictionary.tNrcsIntakeFamily.Translated)
                        AppendLine(mEvalueGoodnessPage, " Z = k*T^a + c")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mEvalueGoodnessPage, wpText)
                        End If

                        Dim family As NrcsIntakeValues = NrcsIntakeValuesTable(mSoilCropProperties.NrcsIntakeFamily.Value)
                        Dim name As String = family.Name

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, mDictionary.tSelected.Translated & " " & mDictionary.tNrcsIntakeFamily.Translated & " - " & name)

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, kText)
                        AppendLine(mEvalueGoodnessPage, aText)
                        AppendLine(mEvalueGoodnessPage, cText)

                        AdvanceLine(mEvalueGoodnessPage)
                        Dim _double As DoubleParameter = mSurfaceFlow.NrcsWettedPerimeter
                        Dim _text As String = _double.FullXlateText
                        AppendLine(mEvalueGoodnessPage, _text)

                    Case InfiltrationFunctions.TimeRatedIntakeFamily
                        AppendBoldText(mEvalueGoodnessPage, mDictionary.tTimeRatedIntakeFamily.Translated)
                        AppendLine(mEvalueGoodnessPage, " Z = k*T^a")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mEvalueGoodnessPage, wpText)
                        End If

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendBoldLine(mEvalueGoodnessPage, mDictionary.tCharacteristicInfiltrationDepth.Translated & ":  " & DepthString(Depth100mm, 0))
                        AppendLine(mEvalueGoodnessPage, "  " & mDictionary.tCharacteristicInfiltrationTime.Translated & ":  " & mSoilCropProperties.InfiltrationTime_TR.ValueString)

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, kText)
                        AppendLine(mEvalueGoodnessPage, aText)

                    Case InfiltrationFunctions.CharacteristicInfiltrationTime
                        AppendBoldText(mEvalueGoodnessPage, mDictionary.tCharacteristicInfiltrationTime.Translated)
                        AppendLine(mEvalueGoodnessPage, " (req = k*T^a")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mEvalueGoodnessPage, wpText)
                        End If

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, aText)
                        AppendLine(mEvalueGoodnessPage, kText)
                        AdvanceLine(mEvalueGoodnessPage)

                        Dim _depthText As String = "  " & mDictionary.tCharacteristicInfiltrationDepth.Translated & ":  " & mSoilCropProperties.InfiltrationDepth_KT.ValueString
                        AppendLine(mEvalueGoodnessPage, _depthText)

                        Dim _timeText As String = "  " & mDictionary.tCharacteristicInfiltrationTime.Translated & ":   " & mSoilCropProperties.InfiltrationTime_KT.ValueString
                        AppendLine(mEvalueGoodnessPage, _timeText)

                    Case InfiltrationFunctions.KostiakovFormula
                        AppendBoldText(mEvalueGoodnessPage, mDictionary.tKostiakovFormula.Translated)
                        AppendLine(mEvalueGoodnessPage, " Z = k*T^a")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mEvalueGoodnessPage, wpText)
                        End If

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, aText)
                        AppendLine(mEvalueGoodnessPage, kText)

                    Case InfiltrationFunctions.ModifiedKostiakovFormula
                        AppendBoldText(mEvalueGoodnessPage, mDictionary.tModifiedKostiakovFormula.Translated)
                        AppendLine(mEvalueGoodnessPage, " Z = k*T^a + b*T + c")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mEvalueGoodnessPage, wpText)
                        End If

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, aText)
                        AppendLine(mEvalueGoodnessPage, bText)
                        AppendLine(mEvalueGoodnessPage, cText)
                        AppendLine(mEvalueGoodnessPage, kText)

                    Case InfiltrationFunctions.BranchFunction
                        AppendBoldText(mEvalueGoodnessPage, mDictionary.tBranchFunction.Translated)
                        AppendLine(mEvalueGoodnessPage, " Z = k*T^a + c  =>  Zb + b*T")
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            AppendLine(mEvalueGoodnessPage, wpText)
                        End If

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, aText)
                        AppendLine(mEvalueGoodnessPage, bText)
                        AppendLine(mEvalueGoodnessPage, cText)

                        kText = LeftJustifyFill(kText, 38, "", " ")
                        If (mSoilCropProperties.BranchTimeSet.Value) Then
                            kText &= mSoilCropProperties.BranchTime_BF.FullXlateText
                        Else
                            kText &= mDictionary.tBranchTime.Translated & " = " & TimeString(mSoilCropProperties.BranchTime)
                        End If
                        AppendLine(mEvalueGoodnessPage, kText)

                    Case InfiltrationFunctions.GreenAmpt
                        AppendBoldText(mEvalueGoodnessPage, sGreenAmpt)

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.EffectivePorosityGA.FullText)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.InitialWaterContentGA.FullText)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.WettingFrontPressureHeadGA.FullText)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.HydraulicConductivityGA.FullText)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.GreenAmptC.FullText)

                    Case InfiltrationFunctions.WarrickGreenAmpt
                        AppendBoldText(mEvalueGoodnessPage, sWarrickGreenAmpt)

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.SaturatedWaterContentWGA.FullText)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.InitialWaterContentWGA.FullText)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.WettingFrontPressureHeadWGA.FullText)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.HydraulicConductivityWGA.FullText)
                        AppendLine(mEvalueGoodnessPage, mSoilCropProperties.WarrickGreenAmptC.FullText)

                    Case Else
                        Debug.Assert(False) ' Invalid Infiltration Method for Merriam-Keller Analysis
                End Select

                AdvanceLine(mEvalueGoodnessPage)
                AppendLine(mEvalueGoodnessPage, mEventCriteria.ReferenceFlowRate.FullText)
                AdvanceLine(mEvalueGoodnessPage)

                ' Performance Measures
                AppendBoldUnderlineLine(mEvalueGoodnessPage, mDictionary.tGoodnessOfFitMeasuresEstimatedParameters.Translated)

                ' Inflow
                Dim _appliedVolume As Double = mInflowManagement.AppliedVolumeForField
                Dim _appliedDepth As Double = mInflowManagement.AppliedDepthForField

                ' Advance data
                Dim _usrAdvanceTable As DataTable = mInflowManagement.TabulatedAdvance.Value
                Dim _usrAdvanceDists As ArrayList = GetDataColumn(_usrAdvanceTable, sDistanceX)
                Dim _usrAdvanceTimes As ArrayList = GetDataColumn(_usrAdvanceTable, sTimeX)
                Dim _numUsrAdvTimes As Integer = _usrAdvanceTimes.Count
                Dim _avgUsrAdvTime As Double = AverageTimeOverDistance(_usrAdvanceTable)
                Dim _endUsrAdvTime As Double = CDbl(_usrAdvanceTimes(_numUsrAdvTimes - 1))

                Dim _simAdvanceTable As DataTable = mSurfaceFlow.Advance.Value
                Dim _numSimAdvDists As Integer = _simAdvanceTable.Rows.Count
                Dim _endSimAdvDist As Double = CDbl(_simAdvanceTable.Rows(_numSimAdvDists - 1).Item(sDistanceX))

                If (_endSimAdvDist < mSystemGeometry.Length.Value - 0.1) Then
                    ' Simulated Advance DID NOT reach the end of the field
                    AdvanceLine(mEvalueGoodnessPage)
                    AppendBoldLine(mEvalueGoodnessPage, mDictionary.tAdvanceTimes.Translated)
                    AppendLine(mEvalueGoodnessPage, mDictionary.tAdvanceTimeEndOfField.Translated(35) & mDictionary.tMeasured.Translated(15) & ":  " & TimeString(_endUsrAdvTime, 0))
                    AdvanceLine(mEvalueGoodnessPage)
                    AppendLine(mEvalueGoodnessPage, mDictionary.tSimulatedAdvanceDidNotReachEndOfField.Translated)
                Else
                    ' Simulated Advance reached the end of the field
                    Dim _simAdvanceTimes As ArrayList = GetTimeColumn(_simAdvanceTable, _usrAdvanceDists)
                    Dim _numSimAdvTimes As Integer = _simAdvanceTimes.Count
                    Dim _avgSimAdvTime As Double = AverageTimeOverDistance(_simAdvanceTable)
                    Dim _endSimAdvTime As Double = CDbl(_simAdvanceTimes(_numSimAdvTimes - 1))

                    ' Compute RMS Error for Advance
                    Dim _sumxmy2 As Double = SUMXMY2(_usrAdvanceTimes, _simAdvanceTimes)
                    Dim _minNum As Integer = Math.Min(_numUsrAdvTimes, _numSimAdvTimes)
                    Dim _rmse As Double = Math.Sqrt(_sumxmy2 / (_minNum - 1)) ' Don't include 1st Advance Pt (0.0)

                    AdvanceLine(mEvalueGoodnessPage)
                    AppendBoldLine(mEvalueGoodnessPage, mDictionary.tAdvanceTimes.Translated)
                    AppendLine(mEvalueGoodnessPage, mDictionary.tRootMeanSquareError.Translated(35) & "           RMSE:  " & TimeString(_rmse, 0))
                    AdvanceLine(mEvalueGoodnessPage)
                    AppendLine(mEvalueGoodnessPage, mDictionary.tAdvanceTimeEndOfField.Translated(35) & mDictionary.tMeasured.Translated(15) & ":  " & TimeString(_endUsrAdvTime, 0))
                    AppendLine(mEvalueGoodnessPage, mDictionary.tPredicted.Translated(50) & ":  " & TimeString(_endSimAdvTime, 0))
                    '
                    ' Recession data
                    '
                    Dim _usrRecessionTable As DataTable = mInflowManagement.TabulatedRecession.Value
                    Dim _usrRecessionDists As ArrayList = GetDataColumn(_usrRecessionTable, sDistanceX)
                    Dim _usrRecessionTimes As ArrayList = GetDataColumn(_usrRecessionTable, sTimeX)
                    Dim _numUsrRecTimes As Integer = _usrRecessionTimes.Count
                    Dim _avgUsrRecTime As Double = AverageTimeOverDistance(_usrRecessionTable)
                    Dim _endUsrRecTime As Double = DataStore.Utilities.DataColumnMax(_usrRecessionTable, sTimeX)

                    Dim _simRecessionTable As DataTable = mSurfaceFlow.Recession.Value
                    Dim _simRecessionTimes As ArrayList = GetTimeColumn(_simRecessionTable, _usrRecessionDists)
                    Dim _numSimRecTimes As Integer = _simRecessionTimes.Count
                    Dim _avgSimRecTime As Double = AverageTimeOverDistance(_simRecessionTable)
                    Dim _endSimRecTime As Double = DataStore.Utilities.DataColumnMax(_simRecessionTable, sTimeX)

                    ' Compute RMS Error for Recession
                    _sumxmy2 = SUMXMY2(_usrRecessionTimes, _simRecessionTimes)
                    _minNum = Math.Min(_numUsrRecTimes, _numSimRecTimes)
                    _rmse = Math.Sqrt(_sumxmy2 / _minNum)

                    AdvanceLine(mEvalueGoodnessPage)
                    AppendBoldLine(mEvalueGoodnessPage, mDictionary.tRecessionTimes.Translated)
                    AppendLine(mEvalueGoodnessPage, mDictionary.tRootMeanSquareError.Translated(35) & "           RMSE:  " & TimeString(_rmse, 0))
                    AdvanceLine(mEvalueGoodnessPage)
                    AppendLine(mEvalueGoodnessPage, mDictionary.tMaximumRecessionTime.Translated(35) & mDictionary.tMeasured.Translated(15) & ":  " & TimeString(_endUsrRecTime, 0))
                    AppendLine(mEvalueGoodnessPage, mDictionary.tPredicted.Translated(50) & ":  " & TimeString(_endSimRecTime, 0))
                    '
                    ' Opportunity Times
                    '
                    Dim _usrAvgOppTime As Double = _avgUsrRecTime - _avgUsrAdvTime
                    Dim _simAvgOppTime As Double = _avgSimRecTime - _avgSimAdvTime

                    ' Compute Relative Error for Opportunity Times
                    Dim _error As Double = (_simAvgOppTime - _usrAvgOppTime) / _usrAvgOppTime

                    AdvanceLine(mEvalueGoodnessPage)
                    AppendBoldLine(mEvalueGoodnessPage, mDictionary.tAverageOpportunityTimes.Translated)
                    AppendLine(mEvalueGoodnessPage, mDictionary.tMeasured.Translated(15) & ":  " & TimeString(_usrAvgOppTime, 0))
                    AppendLine(mEvalueGoodnessPage, mDictionary.tPredicted.Translated(15) & ":  " & TimeString(_simAvgOppTime, 0))
                    '
                    ' Infiltration
                    '
                    Dim _usrAvgDepth As Double = mInflowManagement.AverageInfiltratedDepthForField
                    Dim _simAvgDepth As Double = mSubsurfaceFlow.AverageLongitudinalInfiltrationDepth

                    ' Compute Relative Error for Infiltration Depths
                    _error = (_simAvgDepth - _usrAvgDepth) / _appliedDepth

                    AdvanceLine(mEvalueGoodnessPage)
                    AppendBoldLine(mEvalueGoodnessPage, mDictionary.tAverageInfiltratedDepths.Translated)
                    AppendLine(mEvalueGoodnessPage, mDictionary.tMeasured.Translated(15) & ":  " & DepthString(_usrAvgDepth, 0))
                    AppendLine(mEvalueGoodnessPage, mDictionary.tPredicted.Translated(15) & ":  " & DepthString(_simAvgDepth, 0))
                    '
                    ' Runoff
                    '
                    If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then

                        Dim _usrRunoffDepth As Double = mInflowManagement.RunoffDepthForCrossSection
                        Dim _usrRunoffTable As DataTable = mInflowManagement.RunoffTableForCrossSection
                        Dim _usrRunoffTimes As ArrayList = GetDataColumn(_usrRunoffTable, sTimeX)
                        Dim _usrRunoffRates As ArrayList = GetDataColumn(_usrRunoffTable, sRunoffX)

                        Dim _simRunoffDepth As Double = mSurfaceFlow.TabulatedRunoffVolume / _area
                        Dim _simRunoffTable As DataTable = mSurfaceFlow.RunoffTable
                        Dim _simRunoffRates As ArrayList = GetRunoffColumn(_simRunoffTable, _usrRunoffTimes)

                        ' Compute Relative Error for Runoff
                        _error = (_simRunoffDepth - _usrRunoffDepth) / _appliedDepth

                        ' Compute Coefficient of Determination (R²)
                        Dim _rsq As Double = RSQ(_usrRunoffRates, _simRunoffRates)

                        ' Compute Nash-Sutcliffe Efficiency E
                        _sumxmy2 = SUMXMY2(_usrRunoffRates, _simRunoffRates)
                        Dim _devsq As Double = DEVSQ(_usrRunoffRates)
                        Dim _e As Double = 1 - (_sumxmy2 / _devsq)

                        ' Display Runoff as Depth
                        AdvanceLine(mEvalueGoodnessPage)
                        AppendBoldLine(mEvalueGoodnessPage, mDictionary.tRunoffDepths.Translated)
                        AppendLine(mEvalueGoodnessPage, mDictionary.tMeasured.Translated(15) & ":  " & DepthString(_usrRunoffDepth, 0))
                        AppendLine(mEvalueGoodnessPage, mDictionary.tPredicted.Translated(15) & ":  " & DepthString(_simRunoffDepth, 0))

                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, mDictionary.tCoefficientOfDetermination.Translated(35) & " (R²):  " & UnitText(_rsq, Units.None) & " **")
                        AppendLine(mEvalueGoodnessPage, mDictionary.tNashSutcliffeEfficiency.Translated(35) & " (E):   " & UnitText(_e, Units.None) & " **")
                        '
                        ' Qualifications
                        '
                        AdvanceLine(mEvalueGoodnessPage)
                        AppendLine(mEvalueGoodnessPage, "   ** " & mDictionary.tCalculatedBasedOnTimeAdjustedRunoffValues.Translated)

                    End If ' if Open-End (i.e. Runoff)
                End If

                ' Footer
                DisplayResultsFooter(mEvalueGoodnessPage, mEvalueGoodnessOfFitPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mEvalueGoodnessPage = Nothing
            End Try
        End If

    End Sub
    '
    ' AY average / Sy Graph
    '
    Private Sub AddAySyGraphPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        Dim tAdvance As String = mDictionary.tAdvance.Translated
        Dim tTime As String = mDictionary.tTime.Translated

        If (mUnit IsNot Nothing) Then

            Dim AYavg As DataTable = mSurfaceFlow.AYavgProfile.Value
            Dim AYset As DataSet = ConvertDataTableToDataSet(AYavg)

            Dim AyTable As DataTable = AYset.Tables(0)
            Dim SyTable As DataTable = AYset.Tables(1)

            AyTable.TableName = "AY Avg"
            SyTable.ExtendedProperties.Add("Color", Drawing.Color.Blue)

            ' Remove NaN Sy's from end of DataTable
            For cdx As Integer = SyTable.Rows.Count - 1 To 0 Step -1
                Dim row As DataRow = SyTable.Rows(cdx)
                Dim Sy As Double = row.Item(1)
                If (Double.IsNaN(Sy) Or Double.IsInfinity(Sy)) Then
                    SyTable.Rows.RemoveAt(cdx)
                Else
                    Exit For
                End If
            Next

            If (DataTableHasData(AYavg)) Then

                If (AyTable.Columns(0).ColumnName = sTimeX) Then
                    AyTable.Columns(0).ColumnName = tTime
                Else
                    AyTable.Columns(0).ColumnName = tAdvance
                End If

                Dim x2yGraph As grf_X2YGraph
                '
                ' Full Page view for Display, Print & Print Preview
                '
                x2yGraph = Me.GetNewX2YGraphPage(AYset, title)
                x2yGraph.DisplayKey = True

                If (AyTable.Columns(0).ColumnName = tTime) Then
                    x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                Else
                    x2yGraph.UnitsX = UnitsDefinition.Units.Meters
                End If

                x2yGraph.UnitsY = mUnitsSystem.FlowAreaUnits ' UnitsDefinition.Units.SquareMeters
                x2yGraph.UnitsY2 = UnitsDefinition.Units.None
                x2yGraph.MaxY2 = 1.0

                AddResultsPage(title, tabName, x2yGraph)
                '
                ' Graphic Only view for Display
                '
                x2yGraph = GetNewX2YGraphPanel(AYset, title)
                x2yGraph.DisplayKey = True

                If (AyTable.Columns(0).ColumnName = tTime) Then
                    x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                Else
                    x2yGraph.UnitsX = UnitsDefinition.Units.Meters
                End If

                x2yGraph.UnitsY = mUnitsSystem.FlowAreaUnits ' UnitsDefinition.Units.SquareMeters
                x2yGraph.UnitsY2 = UnitsDefinition.Units.None
                x2yGraph.MaxY2 = 1.0

                AddResultsPanel(title, tabName, x2yGraph)
            End If
        End If

    End Sub
    '
    ' AZ average / Sz Graph
    '
    Private Sub AddAzSzGraphPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        Dim tAdvance As String = mDictionary.tAdvance.Translated
        Dim tTime As String = mDictionary.tTime.Translated

        If (mUnit IsNot Nothing) Then

            Dim AZavg As DataTable = mSubsurfaceFlow.AZavgProfile.Value
            Dim AZset As DataSet = ConvertDataTableToDataSet(AZavg)

            Dim AzTable As DataTable = AZset.Tables(0)
            Dim SzTable As DataTable = AZset.Tables(1)

            AzTable.TableName = "AZ Avg"
            SzTable.ExtendedProperties.Add("Color", Drawing.Color.Blue)

            If (DataTableHasData(AZavg)) Then

                If (AzTable.Columns(0).ColumnName = sTimeX) Then
                    AzTable.Columns(0).ColumnName = tTime
                Else
                    AzTable.Columns(0).ColumnName = tAdvance
                End If

                Dim x2yGraph As grf_X2YGraph
                '
                ' Full Page view for Display, Print & Print Preview
                '
                x2yGraph = Me.GetNewX2YGraphPage(AZset, title)
                x2yGraph.DisplayKey = True

                If (AzTable.Columns(0).ColumnName = tTime) Then
                    x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                Else
                    x2yGraph.UnitsX = UnitsDefinition.Units.Meters
                End If

                x2yGraph.UnitsY = mUnitsSystem.FlowAreaUnits ' UnitsDefinition.Units.SquareMeters
                x2yGraph.UnitsY2 = UnitsDefinition.Units.None
                x2yGraph.MaxY2 = 1.0

                AddResultsPage(title, tabName, x2yGraph)
                '
                ' Graphic Only view for Display
                '
                x2yGraph = GetNewX2YGraphPanel(AZset, title)
                x2yGraph.DisplayKey = True

                If (AzTable.Columns(0).ColumnName = tTime) Then
                    x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                Else
                    x2yGraph.UnitsX = UnitsDefinition.Units.Meters
                End If

                x2yGraph.UnitsY = mUnitsSystem.FlowAreaUnits ' UnitsDefinition.Units.SquareMeters
                x2yGraph.UnitsY2 = UnitsDefinition.Units.None
                x2yGraph.MaxY2 = 1.0

                AddResultsPanel(title, tabName, x2yGraph)
            End If
        End If

    End Sub

#End Region

#Region " Evaluations Results Pages & Sections "
    '
    ' Display Soil Water Depletion (SWD) table
    '
    Private Sub DisplaySwdTable(ByVal tbox As RichTextBox)

        Dim _swdTable As DataTable = mSoilCropProperties.SoilWaterDepletion.Value

        Dim _lengthUnits As Units = mUnitsSystem.LengthUnits
        Dim _depthUnits As Units = mUnitsSystem.DepthUnits
        Dim _capacityUnits As Units = mUnitsSystem.CapacityUnits

        Dim _lengthUnitsText As String = ("(" & UnitsText(_lengthUnits) & ")" & Blanks).Substring(0, 9)
        Dim _depthUnitsText As String = ("(" & UnitsText(_depthUnits) & ")" & Blanks).Substring(0, 9)
        Dim _capacityUnitsText As String = ("(" & UnitsText(_capacityUnits) & ")" & Blanks).Substring(0, 10)

        Dim _rootZoneDepth As Double = mSoilCropProperties.RootZoneDepth.Value

        ' Title
        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tSoilWaterDepletionTable.Translated & " (SWD)")
        AdvanceLine(tbox)

        ' Column Headings
        AppendText(tbox, "  " & mDictionary.tProfile.Translated(-9))
        AppendText(tbox, "Cum. Pr.                                 ")
        AppendText(tbox, mDictionary.tProfile.Translated(-9))
        AppendLine(tbox, "Cum. Pr.")
        'AppendLine(tbox, "  Profile  Cum. Pr.                                 Profile  Cum. Pr.")

        AppendText(tbox, "  " & mDictionary.tDepth.Translated(-9) & mDictionary.tDepth.Translated(-11) & mDictionary.tTexture.Translated(-10))
        AppendLine(tbox, "AWC       SWD       SWD      SWD     ")
        'AppendLine(tbox, "  Depth    Depth      Texture   AWC       SWD       SWD      SWD     ")

        AppendText(tbox, "  " & _lengthUnitsText)   ' Profile Depth
        AppendText(tbox, _lengthUnitsText & "  ")   ' Cumulative Depth
        AppendText(tbox, "          ")              ' Texture
        AppendText(tbox, _capacityUnitsText)        ' AWC
        AppendText(tbox, "(%)       ")              ' SWD
        AppendText(tbox, _depthUnitsText)           ' Profile SWD
        AppendLine(tbox, _depthUnitsText)           ' Cumulative SWD
        AppendLine(tbox, "  -------- ---------- --------- --------- --------- -------- --------")

        ' Row Data
        If (DataTableHasData(_swdTable)) Then
            If ((DataColumnIsDouble(_swdTable, sProfileDepthX)) _
            And (DataColumnIsDouble(_swdTable, sCumulativeDepthX)) _
            And (DataColumnIsString(_swdTable, sTextureX)) _
            And (DataColumnIsDouble(_swdTable, sAwcX)) _
            And (DataColumnIsDouble(_swdTable, sSwdX)) _
            And (DataColumnIsDouble(_swdTable, sProfileSwdX)) _
            And (DataColumnIsDouble(_swdTable, sCumulativeSwdX))) Then
                For _idx As Integer = 0 To _swdTable.Rows.Count - 1
                    Dim _swdRow As DataRow = _swdTable.Rows(_idx)

                    Dim _profileDepth As Double = CDbl(_swdRow(sProfileDepthX))
                    Dim _cumDepth As Double = CDbl(_swdRow(sCumulativeDepthX))
                    Dim _texture As String = CStr(_swdRow(sTextureX))
                    Dim _awc As Double = CDbl(_swdRow(sAwcX))
                    Dim _swd As Double = CDbl(_swdRow(sSwdX))
                    Dim _profileSwd As Double = CDbl(_swdRow(sProfileSwdX))
                    Dim _cumSwd As Double = CDbl(_swdRow(sCumulativeSwdX))

                    ' Check Cummulative Depth < Root Zone Depth warning for last row
                    mWarning1 = String.Empty
                    If (_idx = _swdTable.Rows.Count - 1) Then
                        If (_cumDepth < _rootZoneDepth) Then
                            mWarning1 = "*"
                        End If
                    End If

                    AppendText(tbox, "  " & (UnitText(_profileDepth, _lengthUnits) + Blanks).Substring(0, 9))
                    AppendText(tbox, (UnitText(_cumDepth, _lengthUnits) + mWarning1 + Blanks).Substring(0, 11))
                    AppendText(tbox, (_texture + Blanks).Substring(0, 10))
                    AppendText(tbox, (UnitText(_awc, _capacityUnits) + Blanks).Substring(0, 10))
                    AppendText(tbox, (UnitText(_swd, Units.Percentage) + Blanks).Substring(0, 10))
                    AppendText(tbox, (UnitText(_profileSwd, _depthUnits) + Blanks).Substring(0, 9))
                    AppendLine(tbox, (UnitText(_cumSwd, _depthUnits) + Blanks).Substring(0, 8))
                Next
            End If
        End If

    End Sub
    '
    ' Display Irrigation Requirements
    '
    Private Sub DisplayIrrigationRequirements(ByVal tbox As RichTextBox)

        ' Irrigation Requirements
        Dim _probeLength As Double = mSoilCropProperties.ProbeLength.Value
        Dim _rootZoneDepth As Double = mSoilCropProperties.RootZoneDepth.Value
        Dim _soilWaterDeficit As Double = mSoilCropProperties.ProfileSoilWaterDeficit
        Dim _leachingFraction As Double = mSoilCropProperties.LeachingFraction.Value
        Dim _leachingRequirement As Double = mSoilCropProperties.LeachingRequirement
        Dim _targetDepth As Double = mSoilCropProperties.IrrigationTargetDepth

        ' Check for warnings
        mWarning2 = String.Empty
        If (_probeLength < _rootZoneDepth) Then
            mWarning2 = "#"
        End If

        AdvanceLine(tbox)
        AppendLine(tbox, mDictionary.tRootZoneDepth.Translated(20) & ":  " & LengthString(_rootZoneDepth, 6) + mWarning1 + mWarning2)
        AppendLine(tbox, mDictionary.tProbeLength.Translated(20) & ":  " & LengthString(_probeLength, 6) + mWarning2)

        ' Title
        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tIrrigationRequirements.Translated)

        AppendLine(tbox, mDictionary.tSoilWaterDeficit.Translated(30) & ":  " & DepthString(_soilWaterDeficit, 7))
        AppendLine(tbox, RightJustifyFill(mDictionary.tLeachingRequirement.Translated, 30, "+ ") & ":  " & DepthString(_leachingRequirement, 7) _
                                                                                                 & "  (" & PercentageString(_leachingFraction, 0) & ")")
        AppendLine(tbox, RightJustifyFill(mDictionary.tIrrigationTargetDepth.Translated, 30, "= ") & ":  " & DepthString(_targetDepth, 7))

    End Sub
    '
    ' Infiltrated Depths Table
    '
    Private Sub DisplayIdTable(ByVal tbox As RichTextBox)

        Dim _idTable As DataTable = mSoilCropProperties.InfiltratedDepth.Value

        Dim _lengthUnits As Units = mUnitsSystem.LengthUnits
        Dim _depthUnits As Units = mUnitsSystem.DepthUnits

        Dim _lengthUnitsText As String = ("(" & UnitsText(_lengthUnits) & ")" & Blanks).Substring(0, 10)
        Dim _depthUnitsText As String = ("(" & UnitsText(_depthUnits) & ")" & Blanks).Substring(0, 8)

        Dim _probeLength As Double = mSoilCropProperties.ProbeLength.Value
        Dim _rootZoneDepth As Double = mSoilCropProperties.RootZoneDepth.Value
        Dim _cumProfileDepth As Double = mSoilCropProperties.CumulativeProfileDepth
        Dim _cumulativeSWD As Double = mSoilCropProperties.CumulativeSWD
        Dim _targetDepth As Double = mInflowManagement.RequiredDepth.Value

        ' Title
        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tProbedInfiltratedDepthsTable.Translated)
        AdvanceLine(tbox)

        ' Column Headings
        Dim _text As String = mDictionary.tInfiltratedDepths.Translated
        Dim _pre As String = ""
        Dim _post As String = ""
        While (_pre.Length + _text.Length + _post.Length < 35)
            _pre &= "-"
            _post &= "-"
        End While
        If (_text.Length = 35) Then
            _pre = "|" & _pre
            _post &= "-|"
        Else ' 36
            _pre = "|" & _pre
            _post &= "|"
        End If

        AppendText(tbox, "                         " & _pre)
        AppendBoldText(tbox, _text)
        AppendLine(tbox, _post)

        AppendText(tbox, "  ")
        AppendText(tbox, mDictionary.tDistance.Translated(-10))
        AppendText(tbox, mDictionary.tProbedDepth.Translated(-14))
        AppendText(tbox, mDictionary.tProfile.Translated(-9))
        AppendText(tbox, mDictionary.tRootZone.Translated(-11))
        AppendText(tbox, mDictionary.tLeaching.Translated(-10))
        AppendText(tbox, mDictionary.tUseful.Translated(-8))
        AppendLine(tbox, mDictionary.tDeepPerc.Translated(-10))
        'AppendLine(tbox, "  Distance  Probed Depth  Profile  Root Zone  Leaching  Useful  Deep Perc.")

        AppendText(tbox, "  " & _lengthUnitsText)   ' Distance
        AppendText(tbox, _lengthUnitsText & "    ") ' Probed Depth
        AppendText(tbox, _depthUnitsText & " ")     ' Profile
        AppendText(tbox, _depthUnitsText & "   ")   ' Root Zone
        AppendText(tbox, _depthUnitsText & "  ")    ' Leaching
        AppendText(tbox, _depthUnitsText)           ' Useful
        AppendLine(tbox, _depthUnitsText)           ' Deep Perc.
        AppendLine(tbox, "  --------  ------------  -------  ---------  --------  ------  ----------")

        ' Row Data
        If (DataTableHasData(_idTable)) Then
            If ((DataColumnIsDouble(_idTable, sDistanceX)) _
            And (DataColumnIsDouble(_idTable, sProbedDepthX)) _
            And (DataColumnIsDouble(_idTable, sProfileIdX)) _
            And (DataColumnIsDouble(_idTable, sRootZoneIdX)) _
            And (DataColumnIsDouble(_idTable, sUsefulIdX)) _
            And (DataColumnIsDouble(_idTable, sDeepPercIdX))) Then

                ' Flag any warnings
                Dim _warning1 As Boolean = False
                Dim _warning2 As Boolean = False

                mDrzUnderestimation = False

                For _idx As Integer = 0 To _idTable.Rows.Count - 1
                    Dim _idRow As DataRow = _idTable.Rows(_idx)

                    Dim _distance As Double = CDbl(_idRow(sDistanceX))
                    Dim _probedDepth As Double = CDbl(_idRow(sProbedDepthX))
                    Dim _profileID As Double = CDbl(_idRow(sProfileIdX))
                    Dim _rootZoneID As Double = CDbl(_idRow(sRootZoneIdX))
                    Dim _usefulID As Double = CDbl(_idRow(sUsefulIdX))
                    Dim _leachingID As Double = _usefulID - _rootZoneID
                    Dim _deepPerc As Double = CDbl(_idRow(sDeepPercIdX))

                    ' Check for Root Zone (Drz) underestimation
                    mWarning1 = String.Empty
                    If ((_probeLength < _rootZoneDepth) _
                     Or (_cumProfileDepth < _rootZoneDepth)) Then
                        If (_cumulativeSWD <= _rootZoneID) Then
                            mDrzUnderestimation = True
                            mWarning1 = "*"
                            _warning1 = True
                        End If
                    End If

                    ' Check for underestimation of Leaching Requirement
                    mWarning2 = String.Empty
                    If Not (_probeLength < _probedDepth) Then
                        If (_usefulID < _targetDepth) Then
                            If ((_cumProfileDepth < _probedDepth) _
                             Or (_probeLength = _probedDepth)) Then
                                mWarning2 = "#"
                                _warning2 = True
                            End If
                        End If
                    End If

                    AppendText(tbox, "  " & (UnitText(_distance, _lengthUnits) + Blanks).Substring(0, 10))
                    AppendText(tbox, (UnitText(_probedDepth, _lengthUnits) + Blanks).Substring(0, 14))
                    AppendText(tbox, (UnitText(_profileID, _depthUnits) + Blanks).Substring(0, 9))
                    AppendText(tbox, (UnitText(_rootZoneID, _depthUnits) + mWarning1 + Blanks).Substring(0, 11))
                    AppendText(tbox, (UnitText(_leachingID, _depthUnits) + mWarning2 + Blanks).Substring(0, 10))
                    AppendText(tbox, (UnitText(_usefulID, _depthUnits) + mWarning2 + Blanks).Substring(0, 8))
                    AppendLine(tbox, (UnitText(_deepPerc, _depthUnits) + Blanks).Substring(0, 11))
                Next

                ' If a warning occured, restore indicator(s) for error display
                If (_warning1) Then
                    mWarning1 = "*"
                End If

                If (_warning2) Then
                    mWarning2 = "#"
                End If
            End If

        End If

    End Sub
    '
    ' Display Average Probed Infiltrated Depths based on User Enter data
    '
    Private Sub DisplayAverageProbedInfiltratedDepths(ByVal tbox As RichTextBox)

        ' Title + 3 lines
        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tAverageProbedInfiltratedDepths.Translated)

        ' Infiltration Depths
        Dim _rootZoneDepth As Double = mSoilCropProperties.RootZoneInfiltratedDepth
        Dim _usefulDepth As Double = mSoilCropProperties.UsefulInfiltratedDepth
        Dim _leachingDepth As Double = _usefulDepth - _rootZoneDepth

        DisplayDepthTableRow(tbox, mDictionary.tRootZoneDepth.Translated, _rootZoneDepth)
        DisplayDepthTableRow(tbox, "+ " & mDictionary.tLeachingDepth.Translated, _leachingDepth)
        DisplayDepthTableRow(tbox, "= " & mDictionary.tUsefulDepth.Translated, _usefulDepth)

        Dim _infiltratedDepth As Double = mInflowManagement.InfiltratedDepthForField
        Dim _deepPercolation As Double = Math.Max(_infiltratedDepth - _usefulDepth, 0)

        Dim _flag As String = "**"
        Dim _msg As String = mDictionary.tDeepPercolationEqualsInfiltratedDepthMinusUsefulDepth.Translated

        ' Open End fields should have Runoff
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            Dim _runoffInput As Boolean = mInflowManagement.RunoffDataAvailable
            If Not (_runoffInput) Then
                ' Runoff data has not been entered
                _deepPercolation = mSoilCropProperties.DeepPercolationDepth

                ' Is Deep Percolation available from Probe data?
                If (0 < _deepPercolation) Then
                    ' Yes, use it
                    _infiltratedDepth = _usefulDepth + _deepPercolation
                    _msg = mDictionary.tDeepPercolationCalculatedFromProbeReadings.Translated
                Else
                    _deepPercolation = Double.NaN
                    _infiltratedDepth = Double.NaN
                    _flag = ""
                End If
            End If
        End If

        DisplayDepthTableRow(tbox, "+ " & mDictionary.tDeepPercolation.Translated, _deepPercolation, _flag)
        DisplayDepthTableRow(tbox, "= " & mDictionary.tInfiltratedDepth.Translated, _infiltratedDepth)

        If (_flag = "**") Then
            AdvanceLine(tbox)
            AppendLine(tbox, _flag & " " & _msg)
        End If

        If (Double.IsNaN(_infiltratedDepth)) Then
            AdvanceLine(tbox)
            AppendLine(tbox, "* " & mDictionary.tRunoffDataNotBeenEntered.Translated & "; " & mDictionary.tValueCannotBeCalculated.Translated)
        End If

    End Sub
    '
    ' Display Depth/Volume Table Row
    '
    Private Sub DisplayDepthTableRow(ByVal tbox As RichTextBox, ByVal _label As String, _
                                     ByVal _depth As Double, Optional ByVal _flag As String = "")

        Dim _area As Double = mSystemGeometry.FieldArea                         ' Square meters
        Dim _appliedVolume As Double = mInflowManagement.AppliedVolumeForField          ' Cubic meters
        Dim _unitVolumeCost As Double = mInflowManagement.UnitWaterCost.Value   ' $/ML

        Dim _appliedDepth As Double = _appliedVolume / _area
        Dim _cost As Double = (_appliedVolume * _unitVolumeCost) / Srfr.Globals.CubicMetersPerMegaLiter

        Dim _rowText As String = Blanks + _label & ":"
        _rowText = _rowText.Substring(_rowText.Length - 25)

        If (Double.IsNaN(_depth)) Then
            ' Depth is invalid
            _rowText += "   N/A*"
        Else
            ' Depth is valid
            _rowText += DepthString(_depth, 9)

            ' Add percentage & cost if 0 < Depth
            If (0.0 < _depth) Then
                Dim _ratio As Double = _depth / _appliedDepth
                _rowText += PercentageString(_ratio, 9)
                _rowText += CostString(_ratio * _cost, 9)
                _rowText += " " & _flag
            End If
        End If

        AppendLine(tbox, _rowText)

    End Sub

    Private Sub DisplayVolumeTableRow(ByVal tbox As RichTextBox, ByVal _label As String, _
                                      ByVal _volume As Double, Optional ByVal _flag As String = "")

        Dim _appliedVolume As Double = mInflowManagement.AppliedVolumeForField          ' Cubic meters
        Dim _unitVolumeCost As Double = mInflowManagement.UnitWaterCost.Value   ' $/ML

        Dim _cost As Double = (_appliedVolume * _unitVolumeCost) / Srfr.Globals.CubicMetersPerMegaLiter

        Dim _rowText As String = Blanks + _label & ":"
        _rowText = _rowText.Substring(_rowText.Length - 25)

        If (Double.IsNaN(_volume)) Then
            ' Volume is invalid
            _rowText += "   N/A*"
        Else
            ' Volume is valid
            _rowText += FieldVolumeString(_volume, 9)

            ' Add percentage & cost if 0 < Depth
            If (0.0 < _volume) Then
                Dim _ratio As Double = _volume / _appliedVolume
                _rowText += PercentageString(_ratio, 9)
                _rowText += CostString(_ratio * _cost, 9)
                _rowText += " " & _flag
            End If
        End If

        AppendLine(tbox, _rowText)

    End Sub
    '
    ' Performance Indicators
    '
    Private Sub DisplayIpaIndicators(ByVal tbox As RichTextBox)

        ' Title + 4 lines
        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tIndicators.Translated)

        Dim _desc1 As String = Blanks
        Dim _desc2 As String = Blanks
        Dim _desc3 As String = Blanks

        ' Infiltration Depths
        Dim _appliedDepth As Double = mInflowManagement.AppliedDepthForField
        Dim _runoffDepth As Double = mInflowManagement.RunoffDepthForField
        Dim _infiltratedDepth As Double = mInflowManagement.InfiltratedDepthForField

        ' Limit Root Zone Depth to Infiltrated Depth
        Dim _rootZoneDepth As Double = mSoilCropProperties.RootZoneInfiltratedDepth
        If (_rootZoneDepth > _infiltratedDepth) Then
            _rootZoneDepth = _infiltratedDepth
        End If

        ' Limit Useful Depth to Infiltrated Depth
        Dim _usefulDepth As Double = mSoilCropProperties.UsefulInfiltratedDepth
        If (_usefulDepth > _infiltratedDepth) Then
            _usefulDepth = _infiltratedDepth
        End If

        Dim _leachingDepth As Double = _usefulDepth - _rootZoneDepth
        Dim _deepPercolation As Double = _infiltratedDepth - _usefulDepth

        ' Application Efficiency, Runoff & Deep Percolation Percentages
        Dim _applicationEfficiency As Double = _usefulDepth / _appliedDepth
        Dim _runoffPercentage As Double = _runoffDepth / _appliedDepth
        Dim _deepPercPercentage As Double = _deepPercolation / _appliedDepth

        _desc1 = mDictionary.tApplicationEfficiency.Translated(30) & ":  " & PercentageString(_applicationEfficiency, 6)

        Dim _runoffInput As Boolean = mInflowManagement.RunoffDataAvailable
        If (_runoffInput) Then ' Runoff data has been entered
            _desc2 = mDictionary.tRunoff.Translated(30) & ":  " & PercentageString(_runoffPercentage, 6)
            _desc3 = mDictionary.tDeepPercolation.Translated(30) & ":  " & PercentageString(_deepPercPercentage, 6)
        Else ' No runoff data
            _desc2 = mDictionary.tRunoff.Translated(30) & ":    N/A*"
            _desc3 = mDictionary.tDeepPercolation.Translated(30) & ":    N/A*"
        End If

        AppendLine(tbox, _desc1)
        AppendLine(tbox, _desc2)
        AppendLine(tbox, _desc3)
        AdvanceLine(tbox)

        ' Low-Quarter Average Depth
        Dim _avgDepthLQ As Double = mSoilCropProperties.AverageInfiltratedDepthLQ
        _desc1 = mDictionary.tLowQuarterAverageDepth.Translated(30) & ":  " & DepthString(_avgDepthLQ, 7)
        AppendLine(tbox, _desc1)

        ' Required Depth
        Dim _requiredDepth As Double = mInflowManagement.RequiredDepth.Value
        _desc1 = mDictionary.tIrrigationTargetDepth.Translated(30) & ":  " & DepthString(_requiredDepth, 7)
        AppendLine(tbox, _desc1)

        ' Low-Quarter Adequacy
        Dim _lowQuarterAdequacy As Double = _avgDepthLQ / _requiredDepth
        _desc1 = mDictionary.tLowQuarterAdequacy.Translated(30) & ":  " & Format(_lowQuarterAdequacy, "0.00")
        AppendLine(tbox, _desc1)

        ' Area Under Irrigated (%)
        Dim _lengthUnderIrrigated As Double = mSoilCropProperties.LengthUnderIrrigated
        Dim _length As Double = mSystemGeometry.Length.Value
        Dim _percentage As Double = _lengthUnderIrrigated / _length
        _desc1 = mDictionary.tAreaUnderIrrigated.Translated(30) & ":  " & PercentageString(_percentage, 6)

        AdvanceLine(tbox)
        AppendLine(tbox, _desc1)

    End Sub

    Private Sub AddIpaInfiltratedDepthsGraphPage(ByVal title As String, Optional ByVal tabName As String = "")
        If (mUnit IsNot Nothing) Then

            Dim _2dGraph As grf_XYGraph

            If (tabName Is Nothing) Then
                tabName = title
            ElseIf (tabName = "") Then
                tabName = title
            End If

            Dim _rootZone As DataTable = mSoilCropProperties.RootZoneInfiltrationTable
            Dim _useful As DataTable = mSoilCropProperties.UsefulInfiltrationTable

            ' Create DataSet for graph
            '   Required Depth
            '   Root Zone Infiltrated Depth
            '   Useful Infiltrated Depth
            Dim _dataSet As DataSet = New DataSet(title)

            ' Add Infiltrated Depths inset
            Dim _rootZoneDepth As Double = mSoilCropProperties.RootZoneInfiltratedDepth
            Dim _usefulDepth As Double = mSoilCropProperties.UsefulInfiltratedDepth
            Dim _leachingDepth As Double = _usefulDepth - _rootZoneDepth

            Dim _infiltratedDepths(4) As String

            _infiltratedDepths(0) = mDictionary.tAverageInfiltratedDepths.Translated
            _infiltratedDepths(1) = mDictionary.tRootZone.Translated(15) & ":  " & DepthString(_rootZoneDepth, 7)
            _infiltratedDepths(2) = " +" & mDictionary.tLeaching.Translated(13) & ":  " & DepthString(_leachingDepth, 7)
            _infiltratedDepths(3) = " =" & mDictionary.tUseful.Translated(13) & ":  " & DepthString(_usefulDepth, 7)

            _dataSet.ExtendedProperties.Add("Inset", _infiltratedDepths)

            ' Add Infiltration / Target Depth
            Dim _fieldLength As Double = mSystemGeometry.Length.Value

            Dim _deficit As Double = mSoilCropProperties.ProfileSoilWaterDeficit
            Dim _deficitTable As DataTable = DeficitTable(_deficit, _useful.Columns(0).ColumnName, _fieldLength)
            If (_deficitTable IsNot Nothing) Then
                _deficitTable.TableName = mDictionary.tSoilWaterDeficit.Translated
                _deficitTable.ExtendedProperties.Add("Key", True)
                _dataSet.Tables.Add(_deficitTable)
            End If

            If (_rootZone IsNot Nothing) Then
                _rootZone.TableName = mDictionary.tRootZoneInfiltratedDepth.Translated
                _rootZone.ExtendedProperties.Add("Key", True)
                _rootZone.ExtendedProperties.Add("Symbol", "O")
                _dataSet.Tables.Add(_rootZone)
            End If

            If (_useful IsNot Nothing) Then
                _useful.TableName = mDictionary.tUsefulInfiltratedDepth.Translated
                _useful.ExtendedProperties.Add("Key", True)
                _useful.ExtendedProperties.Add("Symbol", "X")
                _dataSet.Tables.Add(_useful)
            End If

            Dim _intTable As DataTable = mSubsurfaceFlow.LongitudinalInfiltration.Value
            If (DataTableHasData(_intTable)) Then
                _intTable.TableName = mDictionary.tSimulatedDepth.Translated
                _intTable.ExtendedProperties.Add("Key", True)
                _dataSet.Tables.Add(_intTable)
            End If

            Dim _dreq As Double = mInflowManagement.RequiredDepth.Value
            Dim _dreqTable As DataTable = DreqTable(_dreq, _useful.Columns(0).ColumnName, _fieldLength)
            If (_dreqTable IsNot Nothing) Then
                _dreqTable.TableName = mDictionary.tRequiredDepth.Translated
                _dreqTable.Columns(0).ColumnName = mDictionary.tDistance.Translated
                _dreqTable.Columns(1).ColumnName = mDictionary.tInfiltration.Translated
                _dreqTable.ExtendedProperties.Add("Key", True)
                _dreqTable.ExtendedProperties.Add("Color", Drawing.Color.Blue)
                _dataSet.Tables.Add(_dreqTable)
            End If

            ' Full Page view for Display, Print & Print Preview
            _2dGraph = GetNewXYGraphPage(_dataSet, title)
            _2dGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
            _2dGraph.DisplayKey = True
            _2dGraph.UnitsX = UnitsDefinition.Units.Meters
            _2dGraph.UnitsY = UnitsDefinition.Units.Millimeters

            AddResultsPage(title, tabName, _2dGraph)
            '
            ' Graphic Only view for Display
            '
            _2dGraph = GetNewXYGraphPanel(_dataSet, title)
            _2dGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
            _2dGraph.DisplayKey = True
            _2dGraph.UnitsX = UnitsDefinition.Units.Meters
            _2dGraph.UnitsY = UnitsDefinition.Units.Millimeters

            AddResultsPanel(title, tabName, _2dGraph)
        End If

    End Sub

#End Region

#Region " Display Performance Summary "
    '
    ' Performance Summary
    '
    Private Sub AddPerformanceSummaryPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        mPerformanceSummaryRtfPage = GetNewResultsPage(title, ResultsView)
        mPerformanceSummaryPage = mPerformanceSummaryRtfPage.Rtf
        mPerformanceSummaryPage.WordWrap = False
        mPerformanceSummaryPage.ScrollBars = RichTextBoxScrollBars.None

        mPerformanceSummaryRtfPage.AccessibleName = title
        mPerformanceSummaryRtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Advance / Recession
        mPageNumber += 1
        mPerformanceSummaryPageNumber = mPageNumber
        UpdatePerformanceSummaryPage()

        ' Make the Full Page visible
        AddTabPage(tabName, mPerformanceSummaryRtfPage)

    End Sub

    Private mPerformanceSummaryPageNumber As Integer
    Private Sub UpdatePerformanceSummaryPage()

        Dim inflowComplete As Boolean = False
        Dim runoffComplete As Boolean = False
        Dim eventType As EventAnalysisTypes = mEventCriteria.EventAnalysisType.Value
        If (eventType = EventAnalysisTypes.MerriamKellerAnalysis) Then ' Full hydrograph assumed
            inflowComplete = True
            runoffComplete = True
        Else
            inflowComplete = mInflowManagement.InflowComplete
            runoffComplete = mInflowManagement.RunoffComplete
        End If

        If (mPerformanceSummaryPage IsNot Nothing) Then
            ' mMkPerformanceSummaryPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mPerformanceSummaryPage.Clear()

                ' Header
                DisplayResultsHeader(mPerformanceSummaryPage)

                mPerformanceSummaryPage.SelectionAlignment = HorizontalAlignment.Left

                If (inflowComplete And runoffComplete) Then
                    ' Volume balance based on field measured data can be included
                    DisplayFieldVolumeBalance(mPerformanceSummaryPage)
                    AdvanceLine(mPerformanceSummaryPage)
                End If

                If (inflowComplete) Then
                    ' Performance Indicators
                    AdvanceLine(mPerformanceSummaryPage)
                    DisplaySimulationPerformanceIndicators(mPerformanceSummaryPage)

                    ' Water Distribution Pie Chart
                    Dim Dinf As Double = mSubsurfaceFlow.Davg.Value
                    Dim Ddp As Double = mSubsurfaceFlow.DP.Value
                    Dim Dro As Double = mSurfaceFlow.ROd.Value

                    Dim _pieChart As ctl_PieChart2D = New ctl_PieChart2D

                    If (inflowComplete And runoffComplete) Then
                        _pieChart.Location = New Point(510, 470)
                        _pieChart.Size = New Size(250, 250)
                    Else
                        _pieChart.Location = New Point(510, 380)
                        _pieChart.Size = New Size(250, 250)
                    End If

                    _pieChart.Title = mDictionary.tWaterDistribution.Translated
                    _pieChart.AddSlice("Root Zone", "RZ", Dinf - Ddp, Color.White)
                    _pieChart.AddSlice("Deep Percolation", "DP", Ddp, Color.WhiteSmoke)
                    _pieChart.AddSlice("Runoff", "RO", Dro, Color.LightGray)

                    mPerformanceSummaryRtfPage.AddImage(_pieChart)

                    _pieChart.DrawImage()
                Else
                    AdvanceLine(mPerformanceSummaryPage)
                    AppendLine(mPerformanceSummaryPage, mDictionary.tVolumeBalanceCannotBeCalculated.Translated)
                    AdvanceLine(mPerformanceSummaryPage)
                    AppendLine(mPerformanceSummaryPage, "  " & mDictionary.tInflowNotCompletelySpecified.Translated)
                End If
                '
                ' Display Warnings, if any
                '
                Dim _warnings As Boolean = False

                AdvanceLine(mPerformanceSummaryPage)
                AppendBoldLine(mPerformanceSummaryPage, mDictionary.tWarnings.Translated)

                If Not (_warnings) Then
                    AppendLine(mPerformanceSummaryPage, "  -- " & mDictionary.tNone.Translated & " --")
                End If

                ' Footer
                DisplayResultsFooter(mPerformanceSummaryPage, mPerformanceSummaryPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mPerformanceSummaryPage = Nothing
            End Try
        End If

    End Sub
    '
    ' Field Volume Balance based on user entered data
    '
    Private Sub DisplayFieldVolumeBalance(ByVal tbox As RichTextBox)

        ' Title
        AdvanceLine(tbox)
        AppendBoldUnderlineLine(tbox, mDictionary.tFieldMeasuredVolumeBalance.Translated)
        AdvanceLine(tbox)

        ' Line 1
        Dim Dapp As Double = mInflowManagement.AppliedDepthForField
        AppendText(tbox, ("  Dapp   = " & DepthString(Dapp) & "                    ").Substring(0, 30))

        Dim Dinf As Double = mInflowManagement.InfiltratedDepthForField
        AppendText(tbox, ("Dinf   = " & DepthString(Dinf) & "                    ").Substring(0, 28))

        Dim Dro As Double = mInflowManagement.RunoffDepthForField
        AppendLine(tbox, "Dro    = " & DepthString(Dro))

    End Sub
    '
    ' Irrigation Volume Balance based on simulation data
    '
    Private Sub DisplaySimulationVolumeBalance(ByVal tbox As RichTextBox)

        ' Title
        AdvanceLine(tbox)
        AppendBoldUnderlineLine(tbox, mDictionary.tFinalSimulatedVolumeBalance.Translated)

        ' Column headings
        Dim volumeUnits As Units = mUnitsSystem.VolumeUnits
        Dim volumeUnitsText As String = "(" & UnitsText(volumeUnits) & ")"

        Dim depthUnits As Units = mUnitsSystem.DepthUnits
        Dim depthUnitsText As String = "(" & UnitsText(depthUnits) & ")"

        Dim costUnits As Units = mUnitsSystem.WaterCostVolumeUnits

        ' Display tabulated data
        AdvanceLine(tbox)
        AppendTextRight(tbox, " ", 17)
        AppendTextRight(tbox, mDictionary.tVolume.Translated, 13)
        AppendTextRight(tbox, mDictionary.tDepth.Translated, 13)
        AppendTextRight(tbox, mDictionary.tCost.Translated, 13)
        AdvanceLine(tbox)

        AppendTextRight(tbox, " ", 17)
        AppendTextRight(tbox, volumeUnitsText, 13)
        AppendTextRight(tbox, depthUnitsText, 13)
        AppendTextRight(tbox, "($)", 13)
        AdvanceLine(tbox)

        AppendTextRight(tbox, " ", 17)
        AppendLine(tbox, "   ----------   ----------   ----------")

        ' Water Volumes / Depths / Costs
        Dim area As Double = mUnit.SystemGeometryRef.FieldArea

        Dim Vapp As Double = mInflowManagement.AppliedVolumeForField
        Dim Vro As Double = mSurfaceFlow.RunoffVolume
        Dim Vdp As Double = mSubsurfaceFlow.DP.Value * area
        Dim Vinf As Double = mSubsurfaceFlow.InfiltratedVolume
        Dim Vrz As Double = Vinf - Vdp

        Dim Dapp As Double = mInflowManagement.AppliedDepthForField
        Dim Dro As Double = mSurfaceFlow.ROd.Value
        Dim Ddp As Double = mSubsurfaceFlow.DP.Value
        Dim Dinf As Double = mSubsurfaceFlow.Davg.Value
        Dim Drz As Double = Dinf - Ddp

        Dim unitCost As Double = mInflowManagement.UnitWaterCost.Value / Srfr.Globals.CubicMetersPerMegaLiter

        Dim Capp As Double = Vapp * unitCost
        Dim Cro As Double = Vro * unitCost
        Dim Cdp As Double = Vdp * unitCost
        Dim Cinf As Double = Vinf * unitCost
        Dim Crz As Double = Cinf - Cdp

        ' Applied Water
        Dim volumeStr As String = UnitText(Vapp, volumeUnits)
        Dim depthStr As String = UnitText(Dapp, depthUnits)
        Dim costStr As String = UnitText(Capp, costUnits)

        AppendText(tbox, "  " & mDictionary.tAppliedWater.Translated, 17)
        AppendTextRight(tbox, volumeStr, 13)
        AppendTextRight(tbox, depthStr, 13)
        AppendTextRight(tbox, costStr, 13)
        AdvanceLine(tbox)

        ' Infiltration
        volumeStr = UnitText(Vinf, volumeUnits)
        depthStr = UnitText(Dinf, depthUnits)
        costStr = UnitText(Cinf, costUnits)

        AppendText(tbox, "  " & mDictionary.tInfiltration.Translated, 17)
        AppendTextRight(tbox, volumeStr, 13)
        AppendTextRight(tbox, depthStr, 13)
        AppendTextRight(tbox, costStr, 13)
        AdvanceLine(tbox)

        volumeStr = UnitText(Vrz, volumeUnits)
        depthStr = UnitText(Drz, depthUnits)
        costStr = UnitText(Crz, costUnits)

        AppendText(tbox, "      " & mDictionary.tRootZone.Translated, 17)
        AppendTextRight(tbox, volumeStr, 13)
        AppendTextRight(tbox, depthStr, 13)
        AppendTextRight(tbox, costStr, 13)
        AdvanceLine(tbox)

        volumeStr = UnitText(Vdp, volumeUnits)
        depthStr = UnitText(Ddp, depthUnits)
        costStr = UnitText(Cdp, costUnits)

        AppendText(tbox, "      " & mDictionary.tDeepPerc.Translated, 17)
        AppendTextRight(tbox, volumeStr, 13)
        AppendTextRight(tbox, depthStr, 13)
        AppendTextRight(tbox, costStr, 13)
        AdvanceLine(tbox)

        ' Runoff
        volumeStr = UnitText(Vro, volumeUnits)
        depthStr = UnitText(Dro, depthUnits)
        costStr = UnitText(Cro, costUnits)

        AppendText(tbox, "  " & mDictionary.tRunoff.Translated, 17)
        AppendTextRight(tbox, volumeStr, 13)
        AppendTextRight(tbox, depthStr, 13)
        AppendTextRight(tbox, costStr, 13)
        AdvanceLine(tbox)

    End Sub

    Private Sub DisplaySimulationPerformanceIndicators(ByVal tbox As RichTextBox)

        Dim _systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
        Dim _soilCropProperties As SoilCropProperties = mUnit.SoilCropPropertiesRef
        Dim _inflowManagement As InflowManagement = mUnit.InflowManagementRef
        Dim _surfaceFlow As SurfaceFlow = mUnit.SurfaceFlowRef
        Dim _subsurfaceFlow As SubsurfaceFlow = mUnit.SubsurfaceFlowRef
        Dim _performanceResults As PerformanceResults = mUnit.PerformanceResultsRef
        Dim _srfrCriteria As SrfrCriteria = mUnit.SrfrCriteriaRef
        Dim _solmod As Integer = _srfrCriteria.SolutionModel.Value

        Dim _double As DoubleParameter
        Dim _name As String
        Dim _value As String
        Dim _text As String

        ' Start with Performance Indicators heading
        AdvanceLine(tbox)
        AppendBoldUnderlineText(tbox, mDictionary.tSimulationPerformanceIndicators.Translated)

        If (mUnit.SurfaceFlowRef.Overflow.Value) Then
            Dim _time As String = TimeString(mUnit.SurfaceFlowRef.OverflowTime.Value, 0)
            Dim _dist As String = LengthString(mUnit.SurfaceFlowRef.OverflowDist.Value, 0)
            AppendLine(tbox, " - " & mDictionary.tOverflowAt.Translated & " " & _time & ", " & _dist)
        Else
            AdvanceLine(tbox)
        End If

        ' Hydraulic Summary
        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tHydraulicSummary.Translated)

        ' Line 1
        Dim _Dapp As DoubleParameter
        If (_systemGeometry.UpstreamCondition.Value = UpstreamConditions.DrainbackAfterCutoff) Then
            _Dapp = _surfaceFlow.DappG
        Else
            _Dapp = _subsurfaceFlow.Dapp
        End If
        _name = (_Dapp.Symbol & "      ").Substring(0, 6)
        _value = (_Dapp.ValueString & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendText(tbox, _text)

        Dim _Dinf As DoubleParameter = _subsurfaceFlow.Davg
        If ((_Dapp.Value - HalfMillimeter < _Dinf.Value) And (_Dinf.Value < _Dapp.Value + HalfMillimeter)) Then
            _Dinf.Value = _Dapp.Value
        End If
        _name = (_Dinf.Symbol & "      ").Substring(0, 6)
        _value = (_Dinf.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendText(tbox, _text)

        Dim _Dro As DoubleParameter
        _Dro = _surfaceFlow.ROd
        _name = ("Dro" & "      ").Substring(0, 6)
        _value = (_Dro.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendLine(tbox, _text)

        ' Line 2
        Dim _Ddp As DoubleParameter
        _Ddp = _subsurfaceFlow.DP
        _name = ("Ddp" & "      ").Substring(0, 6)
        _value = (_Ddp.ValueString & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendText(tbox, _text)

        _double = _subsurfaceFlow.Dmin
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendText(tbox, _text)

        _double = _subsurfaceFlow.Dlq
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendLine(tbox, _text)

        ' Line 3
        _double = _surfaceFlow.Tco
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendText(tbox, _text)

        _double = _surfaceFlow.TL
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendText(tbox, _text)

        _double = _surfaceFlow.XaR
        _name = ("XR     ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendLine(tbox, _text)

        ' Line 4
        _double = _surfaceFlow.Xmax
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendText(tbox, _text)

        _double = _surfaceFlow.Ymax
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendText(tbox, _text)

        If (_systemGeometry.UpstreamCondition.Value = UpstreamConditions.DrainbackAfterCutoff) Then
            _double = _surfaceFlow.Ddb
            _name = (_double.Symbol & "      ").Substring(0, 6)
            _value = (_double.ValueString & "                   ").Substring(0, 19)
            _text = _name & " = " & _value
        Else
            _double = _surfaceFlow.VerrPct
            _name = (_double.Symbol & "      ").Substring(0, 6)
            _value = (Format(_double.Value * 100, "#0.00") & " %                   ").Substring(0, 19)
            _text = _name & " = " & _value
        End If
        AppendLine(tbox, _text)

        ' Line 5
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            If (_soilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter) Then
                AdvanceLine(tbox)
                _double = _surfaceFlow.RepresentativeWettedPerimeter
                _text = _double.FullXlateText
                AppendLine(tbox, _text)
            ElseIf (_soilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
                AdvanceLine(tbox)
                _double = _surfaceFlow.NrcsWettedPerimeter
                _text = _double.FullXlateText
                AppendLine(tbox, _text)
            End If
        End If

        ' Efficiency & Uniformity Indicators
        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tEfficiencyUniformityIndicators.Translated)

        ' Line 1
        _double = _subsurfaceFlow.AE
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendText(tbox, _text)

        _double = _subsurfaceFlow.RE
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendLine(tbox, _text)

        ' Line 2
        _double = _subsurfaceFlow.DUmin
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendText(tbox, _text)

        _double = _subsurfaceFlow.ADmin
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendLine(tbox, _text)

        ' Line 3
        _double = _subsurfaceFlow.DUlq
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendText(tbox, _text)

        _double = _subsurfaceFlow.ADlq
        _name = (_double.Symbol & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendLine(tbox, _text)

        ' Costs
        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tCosts.Translated)

        _double = _inflowManagement.Cost
        _name = ("Total" & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendLine(tbox, _text)
        Dim _cost As Double = _double.Value

        ' Costs & Percentages
        _double = _subsurfaceFlow.DPpct
        _name = (" DP " & "      ").Substring(0, 6)
        _value = (AreaCostString(_double.Value * _cost, 0) & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendText(tbox, _text)

        _double = _subsurfaceFlow.DPpct
        _name = ("DP%" & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendLine(tbox, _text)

        _double = _surfaceFlow.ROpct
        _name = (" RO " & "      ").Substring(0, 6)
        _value = (AreaCostString(_double.Value * _cost, 0) & "                   ").Substring(0, 19)
        _text = "  " & _name & " = " & _value
        AppendText(tbox, _text)

        _double = _surfaceFlow.ROpct
        _name = ("RO%" & "      ").Substring(0, 6)
        _value = (_double.ValueString & "                   ").Substring(0, 19)
        _text = _name & " = " & _value
        AppendLine(tbox, _text)

    End Sub

    Private Sub DisplayFieldDepthMassBalance(ByVal tbox As RichTextBox)

        ' Title + 3 lines
        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tAverageDepthsFinalMassBalance.Translated)

        Dim _desc1 As String = Blanks
        Dim _desc2 As String = Blanks
        Dim _desc3 As String = Blanks

        ' Applied, Runoff & Infiltrated Depths
        Dim Dapp As Double = mInflowManagement.AppliedDepthForField
        Dim Dro As Double = mInflowManagement.RunoffDepthForField
        Dim Dinf As Double = Dapp - Dro

        ' Open End fields should have Runoff
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            If Not (mInflowManagement.RunoffDataAvailable) Then ' Runoff data is not available
                Dro = Double.NaN
                Dinf = Double.NaN
            End If
        End If

        DisplayDepthTableRow(tbox, mDictionary.tAppliedDepth.Translated, Dapp)
        DisplayDepthTableRow(tbox, "- " & mDictionary.tRunoffDepth.Translated, Dro)
        DisplayDepthTableRow(tbox, "= " & mDictionary.tInfiltratedDepth.Translated, Dinf)

        If (Double.IsNaN(Dinf)) Then
            AdvanceLine(tbox)
            AppendLine(tbox, "* " & mDictionary.tRunoffDataNotBeenEntered.Translated & "; " & mDictionary.tValueCannotBeCalculated.Translated)
        End If

    End Sub

#End Region

#Region " Display No Results "

    '******************************************************************************************
    ' DisplayNoResults() - displays a tab page explaining why there are no results.
    '
    Public Sub DisplayNoResults()
        Me.DisplayNoResults(Me.ResultsView)
    End Sub

    Public Sub DisplayNoResults(ByVal _view As ResultsViews)

        If (mUnit IsNot Nothing) Then
            '
            ' Display the "No Results" reason
            '
            Dim tNoResults As String = mDictionary.tNoResults.Translated

            Dim _page As RtfPage = GetNewResultsPage(tNoResults, _view)
            _page.AccessibleName = tNoResults
            _page.AccessibleDescription = mDictionary.tNoResultsAreAvailable.Translated

            Dim tbox As RichTextBox = _page.Rtf

            AppendBoldLine(tbox, mDictionary.tNoResultsAreAvailable.Translated)
            AdvanceLine(tbox)

            If (0 = mUnitControl.RunCount.Value) Then

                AppendLine(tbox, mDictionary.tAnalysisHasNotBeenRun.Translated)
                AdvanceLine(tbox)
                AppendLine(tbox, "   " & mDictionary.tSelectYourCriteria.Translated)
                AppendLine(tbox, "   " & mDictionary.tEnterValuesForAnalysis.Translated)
                AdvanceLine(tbox)
                AppendLine(tbox, "   " & mDictionary.tPressRunButton.Translated)
                AppendLine(tbox, "     " & mDictionary.tOr.Translated)
                AppendLine(tbox, "   " & mDictionary.tSelectRunMenuItem.Translated)

            Else

                AppendLine(tbox, mDictionary.tAnalysisHasBeenRunBut.Translated)
                AdvanceLine(tbox)
                AppendLine(tbox, "   " & mDictionary.tPressRunButton.Translated)
                AppendLine(tbox, "     " & mDictionary.tOr.Translated)
                AppendLine(tbox, "   " & mDictionary.tSelectRunMenuItem.Translated)
                AdvanceLine(tbox)
                AppendLine(tbox, "     " & mDictionary.tOr.Translated)
                AdvanceLine(tbox)
                AppendLine(tbox, "   " & mDictionary.tUseUndoToGoBack.Translated)

            End If

            AddTabPage(tNoResults, _page)
        End If

    End Sub

#End Region

#Region " Display Input Measurements "

    Private Sub DisplaySystemGeometryParameters(ByVal tbox As RichTextBox)

        Dim _desc1 As String = Blanks
        Dim _desc2 As String = Blanks
        Dim _desc3 As String = Blanks
        Dim _desc4 As String = Blanks

        Dim _col As Integer = 38
        '
        ' System Geometry
        '
        Dim _crossSection As CrossSections = CType(mSystemGeometry.CrossSection.Value, CrossSections)
        Dim _furrowShape As FurrowShapes = CType(mSystemGeometry.FurrowShape.Value, FurrowShapes)
        Dim _upstream As UpstreamConditions = CType(mSystemGeometry.UpstreamCondition.Value, UpstreamConditions)
        Dim _downstream As DownstreamConditions = CType(mSystemGeometry.DownstreamCondition.Value, DownstreamConditions)
        Dim _bottom As BottomDescriptions = CType(mSystemGeometry.BottomDescription.Value, BottomDescriptions)
        Dim _area As Double = mSystemGeometry.FieldArea

        ' Title + 4 lines
        AdvanceLine(tbox)
        AppendBoldText(tbox, mDictionary.tSystemGeometry.Translated)

        _desc1 = CrossSectionSelections(_crossSection).Value & ", "

        If (_crossSection = Globals.CrossSections.Furrow) Then
            Select Case (_furrowShape)
                Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData
                    _desc1 = mDictionary.tPowerLawFurrow.Translated & ", "
                Case Else ' Trapezoid
                    _desc1 = mDictionary.tTrapezoidFurrow.Translated & ", "
            End Select
        End If

        _desc1 += UpstreamConditionSelections(_upstream).Value & ", "
        _desc1 += DownstreamConditionSelections(_downstream).Value

        AppendLine(tbox, " - " & _desc1)

        ' Add bottom description
        Select Case (_bottom)
            Case BottomDescriptions.Slope
                _desc1 = LeftJustifyFill(mSystemGeometry.Slope.FullXlateText, _col, "  ")
            Case Globals.BottomDescriptions.SlopeTable, Globals.BottomDescriptions.AvgFromSlopeTable
                _desc1 = LeftJustifyFill(mDictionary.tSlopeDefinedBySlopeTable.Translated, _col, "  ")
                _desc1 += mDictionary.tAverageSlope.Translated & " = " & SlopeString(mSystemGeometry.AverageSlopeFromElevationTable, 0)
            Case Globals.BottomDescriptions.ElevationTable, Globals.BottomDescriptions.AvgFromElevTable
                _desc1 = LeftJustifyFill(mDictionary.tSlopeDefinedByElevationTable.Translated, _col, "  ")
                _desc1 += mDictionary.tAverageSlope.Translated & " = " & SlopeString(mSystemGeometry.AverageSlopeFromElevationTable, 0)
        End Select

        AppendLine(tbox, _desc1)

        ' Add field dimensions
        Dim worldType As WorldTypes = mSystemGeometry.Unit.UnitType.Value

        Select Case (_crossSection)
            Case CrossSections.Basin, CrossSections.Border
                _desc1 = LeftJustifyFill(mSystemGeometry.Length.FullXlateText, _col, "  ")
                _desc2 = LeftJustifyFill(mSystemGeometry.Width.FullXlateText, _col, "  ")

                If ((worldType = WorldTypes.SimulationWorld) And (mSystemGeometry.EnableTabulatedBorderDepth.Value)) Then
                    _desc3 = LeftJustifyFill(mDictionary.tTabulatedBorderDepth.Translated, _col, "  ")
                Else
                    _desc3 = LeftJustifyFill(mSystemGeometry.Depth.FullXlateText, _col, "  ")
                End If

                _desc1 += mDictionary.tArea.Translated & " = " & AreaString(_area, 0)

                AppendLine(tbox, _desc1)
                AppendLine(tbox, _desc2)
                AppendLine(tbox, _desc3)
            Case Else ' Assume Globals.CrossSections.Furrow
                _desc1 = LeftJustifyFill(mDictionary.tFurrowLength.Translated & " = " & mSystemGeometry.Length.ValueString, _col, "  ")
                _desc2 = LeftJustifyFill(mDictionary.tFurrowSetWidth.Translated & " = " & mSystemGeometry.Width.ValueString, _col, "  ")
                _desc3 = LeftJustifyFill(mSystemGeometry.FurrowSpacing.FullXlateText, _col, "  ")
                _desc4 = LeftJustifyFill(mDictionary.tFurrowsPerSet.Translated & " = " & Format(mSystemGeometry.FurrowsPerSet.Value, "0.#"), _col, "  ")

                Select Case (_furrowShape)

                    Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData

                        If ((worldType = WorldTypes.SimulationWorld) And (_furrowShape = FurrowShapes.PowerLaw) And (mSystemGeometry.EnableTabulatedFurrowShape.Value)) Then

                            _desc2 += mDictionary.tTabulatedCrossSection.Translated

                        Else

                            Dim _const As String = mDictionary.tConstant.Translated & " = " & mSystemGeometry.PowerLawConstantString & ", "
                            Dim _rho1, _rho2 As Double
                            mSystemGeometry.PowerLawRho(_rho1, _rho2)

                            _desc1 += mSystemGeometry.WidthAt100mm.FullXlateText
                            _desc2 += _const + mSystemGeometry.PowerLawExponent.FullXlateText
                            _desc3 += mSystemGeometry.MaximumDepth.FullXlateText
                            _desc4 += "Rho1 = " & Format(_rho1, "0.0###") & ", Rho2 = " & Format(_rho2, "0.0###")

                        End If

                    Case Else ' Trapezoid Furrow

                        If ((worldType = WorldTypes.SimulationWorld) And (_furrowShape = FurrowShapes.Trapezoid) And (mSystemGeometry.EnableTabulatedFurrowShape.Value)) Then

                            _desc2 += mDictionary.tTabulatedCrossSection.Translated

                        Else

                            _desc1 += mSystemGeometry.BottomWidth.FullXlateText
                            _desc2 += mSystemGeometry.SideSlope.FullXlateText
                            _desc3 += mSystemGeometry.MaximumDepth.FullXlateText

                        End If

                End Select

                AppendLine(tbox, _desc1)
                AppendLine(tbox, _desc2)
                AppendLine(tbox, _desc3)
                AppendLine(tbox, _desc4)
        End Select

        AdvanceLine(tbox)

    End Sub

    Private Sub DisplayInfiltrationParameters(ByVal tbox As RichTextBox)

        Dim _desc1 As String = Blanks
        Dim _desc2 As String = Blanks
        Dim _desc3 As String = Blanks
        Dim _desc4 As String = Blanks
        Dim _desc5 As String = Blanks
        Dim _desc6 As String = Blanks
        Dim _desc7 As String = Blanks
        Dim _desc8 As String = Blanks

        Dim _table As DataTable = Nothing
        '
        ' Infiltration
        '
        Dim _infiltrationFunction As InfiltrationFunctions = CType(mSoilCropProperties.InfiltrationFunction.Value, InfiltrationFunctions)
        Dim _tabulated As Boolean = mSoilCropProperties.EnableTabulatedInfiltration.Value

        ' Title + 5 lines
        AdvanceLine(tbox)
        AppendBoldText(tbox, mDictionary.tInfiltration.Translated)

        ' Get current display units
        Dim _distUnits As Units = mUnitsSystem.LengthUnits
        Dim _timeUnits As Units = mUnitsSystem.TimeUnits
        Dim _rateUnits As Units = mUnitsSystem.InfiltrationRateUnits
        Dim _depthUnits As Units = mUnitsSystem.DepthUnits
        Dim _concentrationUnits As Units = mUnitsSystem.ConcentrationLengthUnits

        Dim _rateUnitsString As String = "(" & UnitsText(_rateUnits) & ")"

        ' Display Wetted Perimeter options if Furrow
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            _desc1 = " - " & WettedPerimeterMethodSelections(mSoilCropProperties.WettedPerimeterMethod.Value).Value
        Else ' Basin / Border
            _desc1 = ""
        End If

        ' Infiltration may be tabulated
        If (_tabulated) Then

            Select Case _infiltrationFunction

                Case InfiltrationFunctions.CharacteristicInfiltrationTime

                    _desc1 = "  " & mDictionary.tCharacteristicInfiltrationTime.Translated & _desc1

                    _table = mSoilCropProperties.CharacteristicTimeTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sCharDepth)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sCharTime)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sA)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sLimit))) Then

                            ' Start with the row names
                            _desc2 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sCharDepth).ColumnName).PadRight(16, " "c)
                            _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sCharTime).ColumnName).PadRight(16, " "c)
                            _desc5 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sA).ColumnName).PadRight(16, " "c)

                            If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                _desc6 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(16, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."
                                    _desc4 &= "  ..."
                                    _desc5 &= "  ..."

                                    If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                        _desc6 &= "  ..."
                                    End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _depth As Double = CDbl(_dataRow.Item(Srfr.Globals.sCharDepth))
                                Dim _time As Double = CDbl(_dataRow.Item(Srfr.Globals.sCharTime))
                                Dim _a As Double = CDbl(_dataRow.Item(Srfr.Globals.sA))
                                Dim _limit As Double = CDbl(_dataRow.Item(Srfr.Globals.sLimit))

                                _desc2 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc3 &= " " & UnitText(_depth, _depthUnits).PadLeft(7, " "c)
                                _desc4 &= " " & UnitText(_time, _timeUnits).PadLeft(7, " "c)
                                _desc5 &= " " & Format(_a, "0.0###").PadLeft(7, " "c)

                                If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc6 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next
                        End If
                    End If

                Case InfiltrationFunctions.KostiakovFormula

                    _desc1 = "  " & mDictionary.tKostiakovFormula.Translated & _desc1

                    _table = mSoilCropProperties.KostiakovTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sK)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sA)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sLimit))) Then

                            Dim _kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

                            ' Start with the row names
                            _desc2 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sK).ColumnName).PadRight(16, " "c)
                            _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sA).ColumnName).PadRight(16, " "c)

                            If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                _desc5 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(16, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length) Or (62 < _desc5.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."
                                    _desc4 &= "  ..."

                                    If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                        _desc5 &= "  ..."
                                    End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _k As Double = CDbl(_dataRow.Item(Srfr.Globals.sK))
                                Dim _a As Double = CDbl(_dataRow.Item(Srfr.Globals.sA))
                                Dim _limit As Double = CDbl(_dataRow.Item(Srfr.Globals.sLimit))

                                _desc2 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc3 &= " " & KostiakovKParameter.KostiakovKText(_k, _a, _kUnits).PadLeft(7, " "c)
                                _desc4 &= " " & Format(_a, "0.0###").PadLeft(7, " "c)

                                If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc5 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next
                        End If
                    End If

                Case InfiltrationFunctions.ModifiedKostiakovFormula, InfiltrationFunctions.BranchFunction

                    If (_infiltrationFunction = InfiltrationFunctions.ModifiedKostiakovFormula) Then
                        _desc1 = "  " & mDictionary.tModifiedKostiakovFormula.Translated & _desc1
                    Else
                        _desc1 = "  " & mDictionary.tBranchFunction.Translated & _desc1
                    End If

                    If (_infiltrationFunction = InfiltrationFunctions.ModifiedKostiakovFormula) Then
                        _table = mSoilCropProperties.ModifiedKostiakovTable.Value
                    Else
                        _table = mSoilCropProperties.BranchFunctionTable.Value
                    End If

                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sK)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sA)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sB)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sC)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sLimit))) Then

                            Dim _kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

                            ' Start with the row names
                            _desc2 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sK).ColumnName).PadRight(16, " "c)
                            _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sA).ColumnName).PadRight(16, " "c)
                            _desc5 = "  " & ("b " & _rateUnitsString).PadRight(16, " "c)
                            _desc6 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sC).ColumnName).PadRight(16, " "c)

                            If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                _desc7 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(16, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length) Or (62 < _desc5.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."
                                    _desc4 &= "  ..."
                                    _desc5 &= "  ..."
                                    _desc6 &= "  ..."

                                    If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                        _desc7 &= "  ..."
                                    End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _k As Double = CDbl(_dataRow.Item(Srfr.Globals.sK))
                                Dim _a As Double = CDbl(_dataRow.Item(Srfr.Globals.sA))
                                Dim _b As Double = CDbl(_dataRow.Item(Srfr.Globals.sB))
                                Dim _c As Double = CDbl(_dataRow.Item(Srfr.Globals.sC))
                                Dim _limit As Double = CDbl(_dataRow.Item(Srfr.Globals.sLimit))

                                _desc2 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc3 &= " " & KostiakovKParameter.KostiakovKText(_k, _a, _kUnits).PadLeft(7, " "c)
                                _desc4 &= " " & Format(_a, "0.0###").PadLeft(7, " "c)
                                _desc5 &= " " & UnitText(_b, _rateUnits).PadLeft(7, " "c)
                                _desc6 &= " " & UnitText(_c, _depthUnits).PadLeft(7, " "c)

                                If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc7 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next
                        End If
                    End If

                Case InfiltrationFunctions.NRCSIntakeFamily

                    _desc1 = "  " & mDictionary.tNrcsIntakeFamily.Translated & _desc1

                    _table = mSoilCropProperties.NrcsIntakeTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsString(_table, Srfr.Globals.sNrcsFamily)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sLimit))) Then

                            ' Start with the row names
                            _desc2 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(13, " "c)
                            _desc3 = "  " & "NRCS Family".PadRight(13, " "c)

                            If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(13, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."

                                    If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                        _desc4 &= "  ..."
                                    End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _nrcs As String = _dataRow.Item(Srfr.Globals.sNrcsFamily)
                                Dim _limit As Double = CDbl(_dataRow.Item(Srfr.Globals.sLimit))

                                _desc2 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc3 &= " " & _nrcs.PadLeft(7, " "c)

                                If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc4 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next
                        End If
                    End If

                Case InfiltrationFunctions.TimeRatedIntakeFamily

                    _desc1 = "  " & mDictionary.tTimeRatedIntakeFamily.Translated & _desc1

                    _table = mSoilCropProperties.TimeRatedTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sCorrTime)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sLimit))) Then

                            ' Start with the row names
                            _desc2 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sCorrTime).ColumnName).PadRight(16, " "c)

                            If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(16, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."

                                    If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                        _desc4 &= "  ..."
                                    End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _time As Double = CDbl(_dataRow.Item(Srfr.Globals.sCorrTime))
                                Dim _limit As Double = CDbl(_dataRow.Item(Srfr.Globals.sLimit))

                                _desc2 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc3 &= " " & UnitText(_time, _timeUnits).PadLeft(7, " "c)

                                If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc4 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next
                        End If
                    End If

                Case InfiltrationFunctions.GreenAmpt

                    _desc1 = "  " & sGreenAmpt & _desc1

                    _table = mSoilCropProperties.GreenAmptTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sPhi)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sTheta0)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sHf)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sKs)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sC)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sLimit))) Then

                            ' Start with the row names
                            _desc2 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sPhi).ColumnName).PadRight(16, " "c)
                            _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sTheta0).ColumnName).PadRight(16, " "c)
                            _desc5 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sHf).ColumnName).PadRight(16, " "c)
                            _desc6 = "  " & ("Ks " & _rateUnitsString).PadRight(16, " "c)
                            _desc7 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sC).ColumnName).PadRight(16, " "c)

                            If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                _desc8 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(16, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length) Or (62 < _desc5.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."
                                    _desc4 &= "  ..."
                                    _desc5 &= "  ..."
                                    _desc6 &= "  ..."
                                    _desc7 &= "  ..."

                                    If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                        _desc8 &= "  ..."
                                    End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _phi As Double = CDbl(_dataRow.Item(Srfr.Globals.sPhi))
                                Dim _theta0 As Double = CDbl(_dataRow.Item(Srfr.Globals.sTheta0))
                                Dim _hf As Double = CDbl(_dataRow.Item(Srfr.Globals.sHf))
                                Dim _ks As Double = CDbl(_dataRow.Item(Srfr.Globals.sKs))
                                Dim _c As Double = CDbl(_dataRow.Item(Srfr.Globals.sC))
                                Dim _limit As Double = CDbl(_dataRow.Item(Srfr.Globals.sLimit))

                                _desc2 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc3 &= " " & UnitText(_phi, _concentrationUnits).PadLeft(7, " "c)
                                _desc4 &= " " & UnitText(_theta0, _concentrationUnits).PadLeft(7, " "c)
                                _desc5 &= " " & UnitText(_hf, _depthUnits).PadLeft(7, " "c)
                                _desc6 &= " " & UnitText(_ks, _rateUnits).PadLeft(7, " "c)
                                _desc7 &= " " & UnitText(_c, _depthUnits).PadLeft(7, " "c)

                                If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc8 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next

                        End If
                    End If


                Case InfiltrationFunctions.Hydrus1D

                    _desc1 = "  " & mDictionary.tHydrusInfiltration.Translated & _desc1


                Case InfiltrationFunctions.WarrickGreenAmpt

                    _desc1 = "  " & sWarrickGreenAmpt & _desc1

                    _table = mSoilCropProperties.WarrickGreenAmptTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sThetaS)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sTheta0)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sHf)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sKs)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sC)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sLimit))) Then

                            ' Start with the row names
                            _desc2 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sThetaS).ColumnName).PadRight(16, " "c)
                            _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sTheta0).ColumnName).PadRight(16, " "c)
                            _desc5 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sHf).ColumnName).PadRight(16, " "c)
                            _desc6 = "  " & ("Ks " & _rateUnitsString).PadRight(16, " "c)
                            _desc7 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sC).ColumnName).PadRight(16, " "c)

                            If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                _desc8 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(16, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length) Or (62 < _desc5.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."
                                    _desc4 &= "  ..."
                                    _desc5 &= "  ..."
                                    _desc6 &= "  ..."
                                    _desc7 &= "  ..."

                                    If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                        _desc8 &= "  ..."
                                    End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _thetaS As Double = CDbl(_dataRow.Item(Srfr.Globals.sThetaS))
                                Dim _theta0 As Double = CDbl(_dataRow.Item(Srfr.Globals.sTheta0))
                                Dim _hf As Double = CDbl(_dataRow.Item(Srfr.Globals.sHf))
                                Dim _ks As Double = CDbl(_dataRow.Item(Srfr.Globals.sKs))
                                Dim _c As Double = CDbl(_dataRow.Item(Srfr.Globals.sC))
                                Dim _limit As Double = CDbl(_dataRow.Item(Srfr.Globals.sLimit))

                                _desc2 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc3 &= " " & UnitText(_thetaS, _concentrationUnits).PadLeft(7, " "c)
                                _desc4 &= " " & UnitText(_theta0, _concentrationUnits).PadLeft(7, " "c)
                                _desc5 &= " " & UnitText(_hf, _depthUnits).PadLeft(7, " "c)
                                _desc6 &= " " & UnitText(_ks, _rateUnits).PadLeft(7, " "c)
                                _desc7 &= " " & UnitText(_c, _depthUnits).PadLeft(7, " "c)

                                If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc8 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next

                        End If
                    End If

            End Select

        Else ' not tabulated

            ' Get current Kostiakov parameters
            Dim k As Double = mSoilCropProperties.KostiakovK
            Dim a As Double = mSoilCropProperties.KostiakovA
            Dim b As Double = mSoilCropProperties.KostiakovB
            Dim c As Double = mSoilCropProperties.KostiakovC

            ' Display k & a
            Dim _kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            _desc2 = "  k = " & KostiakovKParameter.KostiakovKString(k, a, _kunits, 0)
            _desc3 = "  a = " & Format(a, "0.000#")

            ' Remaining data is Infiltration Method dependent
            Select Case _infiltrationFunction

                Case InfiltrationFunctions.CharacteristicInfiltrationTime
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a")

                    _desc4 = "  " & mSoilCropProperties.InfiltrationDepth_KT.FullXlateText
                    _desc5 = "  " & mSoilCropProperties.InfiltrationTime_KT.FullXlateText

                Case InfiltrationFunctions.KostiakovFormula
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a")

                    _desc4 = Blanks
                    _desc5 = Blanks

                Case InfiltrationFunctions.ModifiedKostiakovFormula
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a + (b*T) + c")

                    _desc4 = "  b = " & mSoilCropProperties.KostiakovB_MK.ValueString
                    _desc5 = "  c = " & mSoilCropProperties.KostiakovC_MK.ValueString

                Case InfiltrationFunctions.NRCSIntakeFamily
                    Dim _family As NrcsIntakeFamilies = CType(mSoilCropProperties.NrcsIntakeFamily.Value, NrcsIntakeFamilies)
                    Dim _option As NrcsToKostiakovMethods = CType(mSoilCropProperties.NrcsToKostiakovMethod.Value, NrcsToKostiakovMethods)
                    Dim _nrcsIntakeValue As NrcsIntakeValues

                    Select Case (_option)
                        Case NrcsToKostiakovMethods.ApproximateByBestFit
                            AppendLine(tbox, " - " & mDictionary.TNrcsFamilyApproximatedByBestFit.Translated & ":  Z = k*T^a")
                            _desc4 = Blanks
                            _nrcsIntakeValue = NrcsApproxValuesTable(_family)
                        Case Else ' Assume NrcsToKostiakovMethods.DescribeByNrcsFormula
                            AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                            AppendLine(tbox, ":  Z = k*T^a + c")
                            _desc4 = "  c = " & DepthString(c, 0)
                            _nrcsIntakeValue = NrcsIntakeValuesTable(_family)
                    End Select

                    _desc5 = "  " & mDictionary.tFamily.Translated & " - " & _nrcsIntakeValue.Name

                Case InfiltrationFunctions.TimeRatedIntakeFamily
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a")

                    _desc4 = "  " & mSoilCropProperties.InfiltrationDepth_KT.Name & " = " & DepthString(0.1, 0)
                    _desc5 = "  " & mSoilCropProperties.InfiltrationTime_KT.Name & " = " & mSoilCropProperties.InfiltrationTime_TR.ValueString

                Case InfiltrationFunctions.GreenAmpt
                    AppendLine(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)

                    _desc2 = "  ThetaS = " & mSoilCropProperties.EffectivePorosityGA.ValueString
                    _desc2 += "                c = " & mSoilCropProperties.GreenAmptC.ValueString

                    _desc3 = "  Theta0 = " & mSoilCropProperties.InitialWaterContentGA.ValueString
                    _desc4 = "  hf     = " & mSoilCropProperties.WettingFrontPressureHeadGA.ValueString
                    _desc5 = "  Ks     = " & mSoilCropProperties.HydraulicConductivityGA.ValueString

                Case InfiltrationFunctions.Hydrus1D
                    AppendLine(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)

                    _desc2 = "  HYDRUS Project:"
                    _desc3 = "    " & mSoilCropProperties.HydrusProject.Value

                Case InfiltrationFunctions.WarrickGreenAmpt
                    AppendLine(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)

                    _desc2 = "  ThetaS = " & mSoilCropProperties.SaturatedWaterContentWGA.ValueString
                    _desc2 += "                c = " & mSoilCropProperties.WarrickGreenAmptC.ValueString

                    _desc3 = "  Theta0 = " & mSoilCropProperties.InitialWaterContentWGA.ValueString
                    _desc4 = "  hf     = " & mSoilCropProperties.WettingFrontPressureHeadWGA.ValueString
                    _desc5 = "  Ks     = " & mSoilCropProperties.HydraulicConductivityWGA.ValueString

                Case Else ' Assume Branch Function
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a + c   then   Z = Zb + (b*T)")

                    Dim bt As Double = mSoilCropProperties.BranchTime

                    _desc4 = "  c = " & mSoilCropProperties.KostiakovC_BF.ValueString

                    _desc5 = "  b = " & mSoilCropProperties.BranchB_BF.ValueString
                    _desc5 += "  " & mDictionary.tBranchTime.Translated & " = " & TimeString(bt, 0)

            End Select
        End If

        AppendLine(tbox, _desc1)
        AppendLine(tbox, _desc2)
        AppendLine(tbox, _desc3)
        AppendLine(tbox, _desc4)
        AppendLine(tbox, _desc5)

        If Not (_desc6.Trim = String.Empty) Then
            AppendLine(tbox, _desc6)
        End If

        If Not (_desc7.Trim = String.Empty) Then
            AppendLine(tbox, _desc7)
        End If

        If Not (_desc8.Trim = String.Empty) Then
            AppendLine(tbox, _desc8)
        End If

    End Sub

    Private Sub DisplayRoughnessParameters(ByVal tbox As RichTextBox)

        Dim _desc1 As String = Blanks
        Dim _desc2 As String = Blanks
        Dim _desc3 As String = Blanks

        ' Get current display units
        Dim _distUnits As Units = mUnitsSystem.LengthUnits
        Dim _timeUnits As Units = mUnitsSystem.TimeUnits
        Dim _rateUnits As Units = mUnitsSystem.InfiltrationRateUnits
        Dim _depthUnits As Units = mUnitsSystem.DepthUnits
        '
        ' Roughness
        '
        Dim _roughnessMethod As RoughnessMethods = CType(mSoilCropProperties.RoughnessMethod.Value, RoughnessMethods)
        Dim _tabulated As Boolean = mSoilCropProperties.EnableTabulatedRoughness.Value

        Dim _table As DataTable = Nothing

        ' Title
        AppendBoldText(tbox, mDictionary.tRoughness.Translated)
        AppendLine(tbox, " - " & RoughnessMethodSelections(_roughnessMethod).Value)

        ' Roughness may be tabulated
        If (_tabulated) Then

            Select Case (_roughnessMethod)
                Case RoughnessMethods.ManningN, RoughnessMethods.NrcsSuggestedManningN

                    _table = mSoilCropProperties.ManningNTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.ManningN.sN)) _
                        And (DataColumnIsDouble(_table, Srfr.Roughness.sVegDensityM))) Then

                            ' Start with the row names
                            _desc1 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc2 = "  " & UnitHeading(_table.Columns(Srfr.ManningN.sN).ColumnName).PadRight(16, " "c)

                            'If (mSoilCropProperties.EnableVegetativeDensity.Value) Then
                            '    _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Roughness.sVegDensityM).ColumnName).PadRight(16, " "c)
                            'End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc1.Length) Or (62 < _desc2.Length)) Then
                                    _desc1 &= "  ..."
                                    _desc2 &= "  ..."

                                    'If (mSoilCropProperties.EnableVegetativeDensity.Value) Then
                                    '    _desc3 &= "  ..."
                                    'End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _n As Double = CDbl(_dataRow.Item(Srfr.ManningN.sN))
                                Dim _veg As Double = CDbl(_dataRow.Item(Srfr.Roughness.sVegDensityM))

                                _desc1 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc2 &= " " & Format(_n, "0.0###").PadLeft(7, " "c)

                                'If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                '    _desc3 &= " " & Format(_veg, "0.0###").PadLeft(7, " "c)
                                'End If
                            Next
                        End If
                    End If

                Case RoughnessMethods.ManningCnAn

                    _table = mSoilCropProperties.ManningCnAnTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.ManningN.sCn)) _
                        And (DataColumnIsDouble(_table, Srfr.ManningN.sAn)) _
                        And (DataColumnIsDouble(_table, Srfr.Roughness.sVegDensityM))) Then

                            ' Start with the row names
                            _desc1 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc2 = "  " & UnitHeading(_table.Columns(Srfr.ManningN.sCn).ColumnName).PadRight(16, " "c)
                            _desc3 = "  " & UnitHeading(_table.Columns(Srfr.ManningN.sAn).ColumnName).PadRight(16, " "c)

                            'If (mSoilCropProperties.EnableVegetativeDensity.Value) Then
                            '    _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Roughness.sVegDensityM).ColumnName).PadRight(16, " "c)
                            'End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc1.Length) Or (62 < _desc2.Length) Or (62 < _desc3.Length)) Then
                                    _desc1 &= "  ..."
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."

                                    'If (mSoilCropProperties.EnableVegetativeDensity.Value) Then
                                    '    _desc4 &= "  ..."
                                    'End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _Cn As Double = CDbl(_dataRow.Item(Srfr.ManningN.sCn))
                                Dim _An As Double = CDbl(_dataRow.Item(Srfr.ManningN.sAn))
                                Dim _veg As Double = CDbl(_dataRow.Item(Srfr.Roughness.sVegDensityM))

                                _desc1 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc2 &= " " & Format(_Cn, "0.0###").PadLeft(7, " "c)
                                _desc3 &= " " & Format(_An, "0.0###").PadLeft(7, " "c)

                                'If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                '    _desc4 &= " " & Format(_veg, "0.0###").PadLeft(7, " "c)
                                'End If
                            Next
                        End If
                    End If

                Case Else ' Assume RoughnessMethods.SayreAlbertson

                    _table = mSoilCropProperties.SayreChiTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.SayreAlbertsonChi.sChiMM)) _
                        And (DataColumnIsDouble(_table, Srfr.Roughness.sVegDensityM))) Then

                            ' Start with the row names
                            _desc1 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc2 = "  " & UnitHeading(_table.Columns(Srfr.SayreAlbertsonChi.sChiMM).ColumnName).PadRight(16, " "c)

                            'If (mSoilCropProperties.EnableVegetativeDensity.Value) Then
                            '    _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Roughness.sVegDensityM).ColumnName).PadRight(16, " "c)
                            'End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc1.Length) Or (62 < _desc2.Length)) Then
                                    _desc1 &= "  ..."
                                    _desc2 &= "  ..."

                                    'If (mSoilCropProperties.EnableVegetativeDensity.Value) Then
                                    '    _desc3 &= "  ..."
                                    'End If
                                    Exit For
                                End If

                                ' Add row data to end of lines
                                Dim _dist As Double = CDbl(_dataRow.Item(sDistanceX))
                                Dim _chi As Double = CDbl(_dataRow.Item(Srfr.SayreAlbertsonChi.sChiMM))
                                Dim _veg As Double = CDbl(_dataRow.Item(Srfr.Roughness.sVegDensityM))

                                _desc1 &= " " & UnitText(_dist, _distUnits).PadLeft(7, " "c)
                                _desc2 &= " " & UnitText(_chi, _depthUnits).PadLeft(7, " "c)

                                'If (mSoilCropProperties.EnableLimitingDepth.Value) Then
                                '    _desc3 &= " " & Format(_veg, "0.0###").PadLeft(7, " "c)
                                'End If
                            Next
                        End If
                    End If
            End Select

        Else ' not tabulated

            Select Case (_roughnessMethod)
                Case RoughnessMethods.ManningN, RoughnessMethods.NrcsSuggestedManningN
                    If (mSoilCropProperties.NrcsSuggestedManningN.Value = NrcsSuggestedManningN.UserEntered) Then
                        _desc1 = "  " & mSoilCropProperties.ManningN.FullXlateText
                    Else
                        Dim _manningN As Integer = mSoilCropProperties.NrcsSuggestedManningN.Value
                        _desc1 = "  " & mDictionary.tManningN.Translated & " = " & NrcsSuggestedManningNValues(_manningN).ToString
                    End If
                Case RoughnessMethods.ManningCnAn
                    _desc1 = "  " & mSoilCropProperties.ManningCn.FullXlateText
                    _desc1 += ", " & mSoilCropProperties.ManningAn.FullXlateText
                Case Else ' Assume RoughnessMethods.SayreAlbertson
                    _desc1 = "  " & mSoilCropProperties.SayreChi.FullXlateText
            End Select
        End If

        AppendLine(tbox, _desc1)

        If Not (_desc2 = Blanks) Then
            AppendLine(tbox, _desc2)
        End If

        If Not (_desc3 = Blanks) Then
            AppendLine(tbox, _desc3)
        End If

        AdvanceLine(tbox)

    End Sub

    Private Sub DisplayInflowRunoffTables(ByVal tbox As RichTextBox)

        Dim col2 As Integer = 38
        '
        ' Inflow Management
        '
        Dim inflowMethod As InflowMethods = CType(mInflowManagement.InflowMethod.Value, InflowMethods)

        Dim inflowLines() As String
        Dim idx As Integer = 0

        TabsEnabled = True

        ' Title + 5 lines
        AppendBoldText(tbox, mDictionary.tInflow.Translated)
        If (inflowMethod = InflowMethods.TabulatedInflow) Then
            AppendText(tbox, " - " & mDictionary.tTabulated.Translated)
            If (mInflowManagement.TabulatedInflowIncomplete.Value) Then
                AppendText(tbox, " (" & mDictionary.tPartial.Translated & ")")
            End If
        Else ' Assume Standard Hydrograph
            AppendText(tbox, " - " & InflowMethodSelections(inflowMethod).Value)
        End If
        TabTo(tbox, col2)
        AppendBoldText(tbox, mDictionary.tRunoff.Translated)
        AppendText(tbox, " - " & mDictionary.tTabulated.Translated)
        If (mInflowManagement.TabulatedRunoffIncomplete.Value) Then
            AppendText(tbox, " (" & mDictionary.tPartial.Translated & ")")
        End If
        AdvanceLine(tbox)

        Select Case (inflowMethod)
            Case InflowMethods.StandardHydrograph

                Select Case (mUnit.CrossSection)
                    Case CrossSections.Basin, CrossSections.Border
                        ReDim Preserve inflowLines(idx + 1) ' additional 2 lines
                        inflowLines(idx) = "  " & mDictionary.tBorderInflowRate.Translated & " =  " & mInflowManagement.InflowRate.ValueString
                        inflowLines(idx + 1) = ""
                        idx += 2
                    Case Else ' Assume CrossSections.Furrow
                        Dim units As Units = mUnitsSystem.FlowRateUnits
                        Dim furrowInflowRate As Double = mInflowManagement.FurrowInflowRate

                        ReDim Preserve inflowLines(idx + 2) ' additional 3 lines
                        inflowLines(idx) = "  " & mDictionary.tFurrowInflowRate.Translated & " = " & UnitTextWithUnits(furrowInflowRate, units)

                        inflowLines(idx + 1) = "  " & mDictionary.tFurrowSetInflowRate.Translated & " = " & mInflowManagement.InflowRate.ValueString
                        inflowLines(idx + 2) = ""
                        idx += 3
                End Select

                Dim cutoff As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)

                Select Case (cutoff)
                    Case Globals.CutoffMethods.TimeBased
                        ReDim Preserve inflowLines(idx + 1) ' additional 2 lines
                        inflowLines(idx) = "  " & mInflowManagement.CutoffTime.FullXlateText
                        inflowLines(idx + 1) = ""
                        idx += 2
                    Case Globals.CutoffMethods.DistanceBased
                        ReDim Preserve inflowLines(idx + 1) ' additional 2 lines
                        inflowLines(idx) = "  " & mInflowManagement.CutoffLocationRatio.FullXlateText
                        inflowLines(idx + 1) = ""
                        idx += 2
                    Case Globals.CutoffMethods.DistanceInfDepth
                        ReDim Preserve inflowLines(idx + 2) ' additional 3 lines
                        inflowLines(idx) = "  " & mInflowManagement.CutoffLocationRatio.FullXlateText
                        inflowLines(idx + 1) = "  " & mInflowManagement.CutoffInfiltrationDepth.FullXlateText
                        inflowLines(idx + 2) = ""
                        idx += 3
                    Case Globals.CutoffMethods.DistanceOppTime
                        ReDim Preserve inflowLines(idx + 2) ' additional 3 lines
                        inflowLines(idx) = "  " & mInflowManagement.CutoffLocationRatio.FullXlateText
                        inflowLines(idx + 1) = "  " & mInflowManagement.CutoffOpportunityTime.FullXlateText
                        inflowLines(idx + 2) = ""
                        idx += 3
                    Case Else ' Assume Globals.CutoffMethods.UpstreamInfDepth
                        ReDim Preserve inflowLines(idx + 1) ' additional 2 lines
                        inflowLines(idx) = "  " & mInflowManagement.CutoffUpstreamDepth.FullXlateText
                        inflowLines(idx + 1) = ""
                        idx += 2
                End Select

                Dim cutback As CutbackMethods = CType(mInflowManagement.CutbackMethod.Value, CutbackMethods)

                Select Case (cutback)
                    Case Globals.CutbackMethods.NoCutback
                        ReDim Preserve inflowLines(idx + 1) ' additional 2 lines
                        inflowLines(idx) = "  " & mDictionary.tNoCutback.Translated
                        inflowLines(idx + 1) = ""
                        idx += 2
                    Case Globals.CutbackMethods.TimeBased
                        ReDim Preserve inflowLines(idx + 2) ' additional 3 lines
                        inflowLines(idx) = "  " & mInflowManagement.CutbackTimeRatio.FullXlateText
                        inflowLines(idx + 1) = "  " & mInflowManagement.CutbackRateRatio.FullXlateText
                        inflowLines(idx + 2) = ""
                        idx += 3
                    Case Else ' Assume Globals.CutbackMethods.DistanceBased
                        ReDim Preserve inflowLines(idx + 2) ' additional 3 lines
                        inflowLines(idx) = "  " & mInflowManagement.CutbackLocationRatio.FullXlateText
                        inflowLines(idx + 1) = "  " & mInflowManagement.CutbackRateRatio.FullXlateText
                        inflowLines(idx + 2) = ""
                        idx += 3
                End Select

            Case InflowMethods.TabulatedInflow

                ' Get the Tabulated Inflow table and current display units
                Dim inflowTable As DataTable = mInflowManagement.TabulatedInflow.Value
                If (DataTableHasData(inflowTable)) Then
                    If ((DataColumnIsDouble(inflowTable, sTimeX)) _
                    And (DataColumnIsDouble(inflowTable, sInflowX))) Then
                        Dim timeUnits As Units = mUnitsSystem.TimeUnits
                        Dim inflowUnits As Units = mUnitsSystem.FlowRateUnits

                        ' Start with the column names
                        ReDim Preserve inflowLines(idx + 1) ' additional 2 lines
                        inflowLines(idx) = UnitHeading(inflowTable.Columns(nTimeX).ColumnName).PadLeft(col2 / 2 - 3, " "c)
                        inflowLines(idx) &= UnitHeading(inflowTable.Columns(nInflowX).ColumnName).PadLeft(col2 / 2 - 3, " "c)
                        inflowLines(idx + 1) = "  --------------  --------------"
                        idx += 2

                        For Each inRow As DataRow In inflowTable.Rows

                            ReDim Preserve inflowLines(idx) ' additional line

                            ' Add row data to the end of the lines
                            Dim time As Double = CDbl(inRow.Item(sTimeX))
                            Dim inflow As Double = CDbl(inRow.Item(sInflowX))

                            inflowLines(idx) = UnitText(time, timeUnits).PadLeft(col2 / 2 - 3, " "c)
                            inflowLines(idx) &= UnitText(inflow, inflowUnits).PadLeft(col2 / 2 - 3, " "c)
                            idx += 1
                        Next inRow

                        ReDim Preserve inflowLines(idx) ' additional line
                        inflowLines(idx) = ""
                        idx += 1

                    End If
                End If

            Case Else
                Debug.Assert(False, "Support for inflow method must be added")
        End Select

        ReDim Preserve inflowLines(idx + 1) ' additional 2 lines
        inflowLines(idx) = "  " & mInflowManagement.RequiredDepth.FullXlateText
        inflowLines(idx + 1) = "  " & mInflowManagement.UnitWaterCost.FullXlateText
        idx += 2

        Dim runoffLines() As String
        Dim rdx As Integer = 0

        Dim runoffTable As DataTable = mInflowManagement.TabulatedRunoff.Value
        Dim runoffInput As Boolean = mInflowManagement.RunoffDataAvailable
        If (runoffInput) Then
            ' Runoff table exists and has data
            Dim timeUnits As Units = mUnitsSystem.TimeUnits
            Dim runoffUnits As Units = mUnitsSystem.FlowRateUnits

            ' Start with the column names
            ReDim Preserve runoffLines(rdx + 1) ' additional 2 lines
            runoffLines(rdx) = UnitHeading(runoffTable.Columns(nTimeX).ColumnName).PadLeft(col2 / 2 - 3, " "c)
            runoffLines(rdx) &= UnitHeading(runoffTable.Columns(nInflowX).ColumnName).PadLeft(col2 / 2 - 3, " "c)
            runoffLines(rdx + 1) = "  --------------  --------------"
            rdx += 2

            For Each outRow As DataRow In runoffTable.Rows

                ReDim Preserve runoffLines(rdx) ' additional line

                ' Add row data to the end of the lines
                Dim time As Double = CDbl(outRow.Item(nTimeX))
                Dim runoff As Double = CDbl(outRow.Item(nInflowX))

                runoffLines(rdx) = UnitText(time, timeUnits).PadLeft(col2 / 2 - 3, " "c)
                runoffLines(rdx) &= UnitText(runoff, runoffUnits).PadLeft(col2 / 2 - 3, " "c)
                rdx += 1
            Next

            ReDim Preserve runoffLines(rdx) ' additional line
            runoffLines(rdx) = ""
            rdx += 1

        Else ' No runoff has been entered
            ReDim Preserve runoffLines(rdx) ' additional line
            runoffLines(rdx) = mDictionary.tRunoffDataNotBeenEntered.Translated
            rdx += 1
        End If

        Dim lineCount As Integer = Math.Max(idx, rdx)

        For ldx As Integer = 0 To lineCount - 1
            If (ldx < idx) Then
                AppendText(tbox, inflowLines(ldx))
            Else
                AppendText(tbox, "")
            End If
            If (ldx < rdx) Then
                TabTo(tbox, col2)
                AppendLine(tbox, runoffLines(ldx))
            Else
                AdvanceLine(tbox)
            End If
        Next ldx

    End Sub

    Private Sub DisplayInflowManagementParameters(ByVal tbox As RichTextBox)

        Dim _crossSection As String = mSystemGeometry.CrossSectionName

        Dim _desc1 As String = Blanks
        Dim _desc2 As String = Blanks
        Dim _desc3 As String = Blanks
        Dim _desc4 As String = Blanks
        Dim _desc5 As String = Blanks

        Dim _col As Integer = 38
        '
        ' Inflow Management
        '
        Dim _inflowMethod As InflowMethods = CType(mInflowManagement.InflowMethod.Value, InflowMethods)
        Dim _surgeStrategy As SurgeStrategies = CType(mInflowManagement.SurgeStrategy.Value, SurgeStrategies)
        Dim _numSurges As Integer = mInflowManagement.NumberOfSurges.Value

        ' Title + 5 lines
        AdvanceLine(tbox)
        AppendBoldText(tbox, _crossSection & " " & mDictionary.tInflow.Translated)

        Select Case (_inflowMethod)
            Case InflowMethods.Surge
                ' Surge strategy
                AppendLine(tbox, " - " & SurgeStrategySelections(_surgeStrategy).Value & " " & mDictionary.tSurge.Translated)

            Case Else ' StandardHydrograph, TabulatedInflow, Cablegation
                AppendLine(tbox, " - " & InflowMethodSelections(_inflowMethod).Value)
        End Select

        Select Case (_inflowMethod)
            Case Globals.InflowMethods.StandardHydrograph

                Select Case (mUnit.CrossSection)
                    Case CrossSections.Basin, CrossSections.Border
                        _desc1 = LeftJustifyFill(mDictionary.tBorderInflowRate.Translated & " =  " & mInflowManagement.InflowRate.ValueString, _col, "  ")
                    Case Else ' Assume CrossSections.Furrow
                        Dim units As Units = mUnitsSystem.FlowRateUnits
                        Dim furrowInflowRate As Double = mInflowManagement.FurrowInflowRate
                        _desc1 = LeftJustifyFill(mDictionary.tFurrowInflowRate.Translated & " = " & UnitTextWithUnits(furrowInflowRate, units), _col, "  ")

                        _desc1 += mDictionary.tFurrowSetInflowRate.Translated & " = " & mInflowManagement.InflowRate.ValueString
                End Select

                Dim _cutoff As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)

                Select Case (_cutoff)
                    Case Globals.CutoffMethods.TimeBased
                        _desc2 = LeftJustifyFill(mInflowManagement.CutoffTime.FullXlateText, _col, "  ")
                    Case Globals.CutoffMethods.DistanceBased
                        _desc2 = LeftJustifyFill(mInflowManagement.CutoffLocationRatio.FullXlateText, _col, "  ")
                    Case Globals.CutoffMethods.DistanceInfDepth
                        _desc2 = LeftJustifyFill(mInflowManagement.CutoffLocationRatio.FullXlateText, _col, "  ")
                        _desc2 += "& " & mInflowManagement.CutoffInfiltrationDepth.FullXlateText
                    Case Globals.CutoffMethods.DistanceOppTime
                        _desc2 = LeftJustifyFill(mInflowManagement.CutoffLocationRatio.FullXlateText, _col, "  ")
                        _desc2 += "& " & mInflowManagement.CutoffOpportunityTime.FullXlateText
                    Case Else ' Assume Globals.CutoffMethods.UpstreamInfDepth
                        _desc2 = LeftJustifyFill(mInflowManagement.CutoffUpstreamDepth.FullXlateText, _col, "  ")
                End Select

                Dim _cutback As CutbackMethods = CType(mInflowManagement.CutbackMethod.Value, CutbackMethods)

                Select Case (_cutback)
                    Case Globals.CutbackMethods.NoCutback
                        _desc3 = LeftJustifyFill("", _col)
                        _desc4 = LeftJustifyFill(mDictionary.tNoCutback.Translated, _col, "  ")
                        _desc5 = LeftJustifyFill("", _col)
                    Case Globals.CutbackMethods.TimeBased
                        _desc3 = LeftJustifyFill("", _col)
                        _desc4 = LeftJustifyFill(mInflowManagement.CutbackTimeRatio.FullXlateText, _col, "  ")
                        _desc5 = LeftJustifyFill(mInflowManagement.CutbackRateRatio.FullXlateText, _col, "  ")
                    Case Else ' Assume Globals.CutbackMethods.DistanceBased
                        _desc3 = LeftJustifyFill("", _col)
                        _desc4 = LeftJustifyFill(mInflowManagement.CutbackLocationRatio.FullXlateText, _col, "  ")
                        _desc5 = LeftJustifyFill(mInflowManagement.CutbackRateRatio.FullXlateText, _col, "  ")
                End Select

                _desc4 += mInflowManagement.RequiredDepth.FullXlateText
                _desc5 += mInflowManagement.UnitWaterCost.FullXlateText

            Case Globals.InflowMethods.TabulatedInflow

                ' Get the Tabulated Inflow table and current display units
                Dim _inflowTable As DataTable = mInflowManagement.TabulatedInflow.Value
                If (DataTableHasData(_inflowTable)) Then
                    If ((DataColumnIsDouble(_inflowTable, sTimeX)) _
                    And (DataColumnIsDouble(_inflowTable, sInflowX))) Then
                        Dim _timeUnits As Units = mUnitsSystem.TimeUnits
                        Dim _inflowUnits As Units = mUnitsSystem.FlowRateUnits

                        ' Start with the column names
                        _desc1 = "  " & "              #"
                        _desc2 = "  " & UnitHeading(_inflowTable.Columns(nTimeX).ColumnName).PadLeft(15, " "c)
                        _desc3 = "  " & UnitHeading(_inflowTable.Columns(nInflowX).ColumnName).PadLeft(15, " "c)

                        Dim _row As Integer = 0
                        For Each _dataRow As DataRow In _inflowTable.Rows

                            ' Don't let lines get too long
                            If ((62 < _desc1.Length) Or (62 < _desc2.Length) Or (62 < _desc3.Length)) Then
                                _desc1 += "  ..."
                                _desc2 += "  ..."
                                _desc3 += "  ..."
                                Exit For
                            End If

                            ' Add row data to the end of the lines
                            _row += 1
                            Dim _time As Double = CDbl(_dataRow.Item(sTimeX))
                            Dim _inflow As Double = CDbl(_dataRow.Item(sInflowX))

                            _desc1 += " " & _row.ToString.PadLeft(7, " "c)
                            _desc2 += " " & UnitText(_time, _timeUnits).PadLeft(7, " "c)
                            _desc3 += " " & UnitText(_inflow, _inflowUnits).PadLeft(7, " "c)
                        Next
                    End If
                End If

                _desc5 = "  " & mInflowManagement.RequiredDepth.FullXlateText(_col)
                _desc5 += mInflowManagement.UnitWaterCost.FullXlateText

            Case Globals.InflowMethods.Cablegation

                _desc1 = LeftJustifyFill(mInflowManagement.TotalInflow.FullXlateText, _col, "  ")
                _desc1 &= mInflowManagement.PipeDiameter.FullXlateText

                _desc2 = LeftJustifyFill(mInflowManagement.CutoffFlow.FullXlateText, _col, "  ")
                _desc2 &= mInflowManagement.PipeSlope.FullXlateText

                _desc3 = LeftJustifyFill(mInflowManagement.OrificeSpacing.FullXlateText, _col, "  ")
                _desc3 &= mInflowManagement.HazenWilliamsPipeCoefficient.FullXlateText

                If (mInflowManagement.OrificeOption.Value = OrificeOptions.EquivalentDiameter) Then
                    _desc4 = LeftJustifyFill(mInflowManagement.OrificeDiameter.FullXlateText, _col, "  ")
                Else
                    _desc4 = LeftJustifyFill(mInflowManagement.PeakOrificeFlow.FullXlateText, _col, "  ")
                End If
                _desc4 &= mInflowManagement.PlugSpeed.FullXlateText

            Case Globals.InflowMethods.Surge

                _desc3 = "  " & mInflowManagement.SurgeOnTime.FullXlateText
                _desc4 = "  " & mInflowManagement.SurgeCutoffTime.FullXlateText
                _desc5 = "  " & mInflowManagement.SurgeInflowRate.FullXlateText

                Select Case (_surgeStrategy)

                    Case SurgeStrategies.UniformTime

                        _desc1 = "  " & mDictionary.tNumberOfSurges.Translated & " = " & mWorldWindow.SrfrAPI.Inflow.NumberOfSurges.ToString

                    Case SurgeStrategies.UniformLocation
                        _desc1 = "  " & mDictionary.tNumberOfAdvanceSurges.Translated & " = " & mInflowManagement.NumberOfSurges.Text
                        _desc2 = "  " & mDictionary.tSurgeLocationRatio.Translated & " = " & Format(1.0 / _numSurges, "0.00#")

                    Case SurgeStrategies.TabulatedTime

                        ' Get the Tabulated Surge table and current display units
                        Dim onTime, offTime As Double
                        Dim _surgeTable As DataTable = mInflowManagement.SurgeTimesTable.Value
                        If (DataTableHasData(_surgeTable)) Then
                            If ((DataColumnIsDouble(_surgeTable, sStartTimeX)) _
                            And (DataColumnIsDouble(_surgeTable, sEndTimeX))) Then
                                Dim _timeUnits As Units = mUnitsSystem.TimeUnits

                                ' Start with the column names
                                _desc1 = "  " & "                  #"
                                _desc2 = "  " & UnitHeading(_surgeTable.Columns(0).ColumnName).PadLeft(19, " "c)
                                _desc3 = "  " & UnitHeading(_surgeTable.Columns(1).ColumnName).PadLeft(19, " "c)

                                Dim _row As Integer = 0
                                For Each _dataRow As DataRow In _surgeTable.Rows

                                    ' Don't let lines get too long
                                    If ((62 < _desc1.Length) Or (62 < _desc2.Length) Or (62 < _desc3.Length)) Then
                                        _desc1 += "  ..."
                                        _desc2 += "  ..."
                                        _desc3 += "  ..."
                                        Exit For
                                    End If

                                    ' Add row data to the end of the lines
                                    _row += 1
                                    onTime = CDbl(_dataRow.Item(sStartTimeX))
                                    offTime = CDbl(_dataRow.Item(sEndTimeX))

                                    _desc1 += " " & _row.ToString.PadLeft(7, " "c)
                                    _desc2 += " " & UnitText(onTime, _timeUnits).PadLeft(7, " "c)
                                    _desc3 += " " & UnitText(offTime, _timeUnits).PadLeft(7, " "c)
                                Next
                            End If
                        End If

                        _desc4 = "  " & mDictionary.tCutoffTime.Translated & " = " & TimeString(offTime)

                    Case SurgeStrategies.TabulatedLocation

                        ' Get the Tabulated Surage table and current display units
                        Dim _surgeTable As DataTable = mInflowManagement.SurgeLocationsTable.Value
                        If (DataTableHasData(_surgeTable)) Then
                            If ((DataColumnIsDouble(_surgeTable, sLocationX))) Then

                                ' Start with the column names  
                                _desc1 = "  " & "                #"
                                _desc2 = "  " & UnitHeading(_surgeTable.Columns(0).ColumnName).PadLeft(17, " "c)

                                Dim _row As Integer = 0
                                For Each _dataRow As DataRow In _surgeTable.Rows

                                    ' Don't let lines get too long
                                    If ((62 < _desc1.Length) Or (62 < _desc2.Length) Or (62 < _desc3.Length)) Then
                                        _desc1 += "  ..."
                                        _desc2 += "  ..."
                                        Exit For
                                    End If

                                    ' Add row data to the end of the lines
                                    _row += 1
                                    Dim _loc As Double = CDbl(_dataRow.Item(sLocationX))

                                    _desc1 += " " & _row.ToString.PadLeft(7, " "c)
                                    _desc2 += " " & UnitText(_loc, Units.None).PadLeft(7, " "c)
                                Next
                            End If
                        End If

                End Select

            Case Else
                _desc2 = "Unknown Inflow Method parameter output needs to be implemented"
                Debug.Assert(False, _desc2)
        End Select

        AppendLine(tbox, _desc1)
        AppendLine(tbox, _desc2)
        AppendLine(tbox, _desc3)
        AppendLine(tbox, _desc4)
        AppendLine(tbox, _desc5)

    End Sub

    Private Sub DisplayAdvanceRecessionTables(ByVal tbox As RichTextBox)

        ' Get Advance / Recession / Opportunity Time data
        Dim _advanceTable As DataTable = mInflowManagement.TabulatedAdvance.Value

        Dim _recessionTable As DataTable = Nothing
        If ((mInflowManagement.RecessionUsed.Value) And (mInflowManagement.RecessionDataAvailable)) Then
            _recessionTable = mInflowManagement.TabulatedRecession.Value
        End If

        Dim _distUnits As Units = mUnitsSystem.LengthUnits
        Dim _distUnitsText As String = "(" & UnitsText(_distUnits) & ")"

        Dim _timeUnits As Units = mUnitsSystem.TimeUnits
        Dim _timeUnitsText As String = "(" & UnitsText(_timeUnits) & ")"

        Dim _maxRow As Integer = 34

        ' Display tabulated data
        AdvanceLine(tbox)
        AppendText(tbox, "  ")
        AppendText(tbox, mDictionary.tDistance.Translated, 13)
        AppendText(tbox, mDictionary.tAdvance.Translated, 12)
        AppendText(tbox, mDictionary.tRecession.Translated, 13)
        AppendLine(tbox, mDictionary.tOpportunityTime.Translated)
        'AppendLine(tbox, "  Distance     Advance     Recession    Opportunity Time")
        AppendText(tbox, "  ")
        AppendText(tbox, _distUnitsText, 13)
        AppendText(tbox, _timeUnitsText, 12)
        AppendText(tbox, _timeUnitsText, 13)
        AppendLine(tbox, _timeUnitsText)
        AppendLine(tbox, "  --------     -------     ---------    ----------------")

        Dim _interp As Boolean = False

        Dim _numRows As Integer = _advanceTable.Rows.Count
        For _row As Integer = 0 To _numRows - 1

            If (_maxRow <= _row) Then
                If (_row < _numRows - 1) Then
                    _row = _numRows - 1
                    AppendLine(tbox, "       ...         ...           ...             ...")
                End If
            End If

            Dim _advTimeRow As DataRow = _advanceTable.Rows(_row)

            Dim _advDist As Double = CDbl(_advTimeRow.Item(sDistanceX))
            Dim _dstStr As String = UnitText(_advDist, _distUnits, 9)

            Dim _advTime As Double = CDbl(_advTimeRow.Item(sTimeX))
            Dim _recTime As Double = 0.0
            Dim _oppTime As Double = 0.0

            Dim _advStr As String = UnitText(_advTime, _timeUnits, 12) & "  "
            Dim _recStr As String = "       N/A"
            Dim _oppStr As String = "             N/A"

            Dim _recInterp As Boolean = False

            If (_recessionTable IsNot Nothing) Then

                If (GetDataRow(_recessionTable, nDistanceX, _advDist, DataStore.OneDecimeter) Is Nothing) Then
                    _interp = True
                    _recInterp = True
                End If

                _recTime = DataColumnValue(_recessionTable, nDistanceX, _advDist, nTimeX1)
                _recStr = UnitText(_recTime, _timeUnits, 12) & "  "

                _oppTime = _recTime - _advTime
                _oppStr = UnitText(_oppTime, _timeUnits, 14)

            End If

            If (_recInterp) Then
                AppendLine(tbox, _dstStr & _advStr & _recStr & _oppStr & " *")
            Else
                AppendLine(tbox, _dstStr & _advStr & _recStr & _oppStr)
            End If

        Next _row

        ' Add Average Opportunity Time
        Dim _oppTimes As DataTable = mInflowManagement.CalcOpportunityTimes
        Dim _avgOppTime As Double = AverageTimeOverDistance(_oppTimes)

        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tAverageOpportunityTime.Translated(43) & ":" & TimeString(_avgOppTime, 11))

        If (_interp) Then
            AdvanceLine(tbox)
            AppendLine(tbox, " * " & mDictionary.tRecessionInterpolated.Translated)
        End If

        ' Display Warnings, if any
        Dim _warnings As Boolean = False

        AdvanceLine(tbox)
        AppendBoldLine(tbox, mDictionary.tWarnings.Translated)

        If Not (_warnings) Then
            AppendLine(tbox, "  -- " & mDictionary.tNone.Translated & " --")
        End If

    End Sub

#End Region

#Region " Display Output Results "

    Private Sub DisplaySurfaceVolumeCalculations(ByVal tbox As RichTextBox)

        Dim col2 As Integer = 38

        Dim svLines() As String = New String() {}
        Dim svdx As Integer = 0

        TabsEnabled = True

        Dim timeUnits As Units = mUnitsSystem.TimeUnits
        Dim lengthUnits As Units = mUnitsSystem.LengthUnits
        Dim depthUnits As Units = mUnitsSystem.DepthUnits
        Dim flowUnits As Units = mUnitsSystem.FlowRateUnits
        Dim flowAreaUnits As Units = mUnitsSystem.FlowAreaUnits
        Dim volumeUnits As Units = mUnitsSystem.VolumeUnits

        Dim L As Double = mSystemGeometry.Length.Value
        Dim MaxTadv As Double = mInflowManagement.MaxAdvanceTime

        Dim powerLawUsed As Boolean = False

        AppendBoldUnderlineLine(tbox, mDictionary.tSurfaceVolume.Translated)

        If (mInflowManagement.FlowDepthsMeasuredAndUsed) Then

            Dim measSurfaceVolumes As DataTable = mInflowManagement.MeasuredSurfaceVolumeTable ' mEventCriteria.VolumeBalances.Value
            If (measSurfaceVolumes IsNot Nothing) Then

                Dim colW As Integer = 13

                Dim XadvHeading As String = UnitHeading(measSurfaceVolumes.Columns(sAdvanceX).ColumnName)
                Dim VyHeading As String = UnitHeading(measSurfaceVolumes.Columns(sVy).ColumnName)

                ReDim Preserve svLines(svdx + 1) ' additional 2 lines

                Dim tokens() As String = Split(XadvHeading, " ")
                svLines(svdx) = tokens(0).PadLeft(colW, " "c)
                svLines(svdx + 1) = tokens(1).PadLeft(colW, " "c)

                tokens = Split(VyHeading, " ")
                svLines(svdx) &= (tokens(0) & " ").PadLeft(colW, " "c)
                svLines(svdx + 1) &= tokens(1).PadLeft(colW, " "c)

                svdx += 2

                For Each svRow As DataRow In measSurfaceVolumes.Rows

                    ReDim Preserve svLines(svdx) ' additional line

                    ' Add row data to the end of the lines
                    Dim Xadv As Double = CDbl(svRow.Item(sAdvanceX))
                    Dim Vy As Double = CDbl(svRow.Item(sVy))

                    svLines(svdx) = UnitText(Xadv, lengthUnits).PadLeft(colW, " "c)
                    svLines(svdx) &= UnitText(Vy, volumeUnits).PadLeft(colW, " "c)

                    svdx += 1
                Next svRow

            End If

        Else ' Surface Volumes estimated

            Dim estSurfaceVolumes As DataTable = Nothing
            Select Case (mEventCriteria.EventAnalysisType.Value)
                Case EventAnalysisTypes.EvalueAnalysis
                    estSurfaceVolumes = mEventCriteria.EstimatedSurfaceVolumes.Value
                Case EventAnalysisTypes.TwoPointAnalysis
                    estSurfaceVolumes = mEventCriteria.EW2ptEstimatedSurfaceVolumes.Value
            End Select

            If (estSurfaceVolumes Is Nothing) Then ' Surface volumes not estimated

                ReDim Preserve svLines(svdx) ' additional line
                svLines(svdx) = "  " & mDictionary.tSurfaceVolumesNotEstimated.Translated
                svdx += 1

            Else ' Surface Volumes have been estimated for this analysis

                Dim colW As Integer = 9

                Dim timeHeading As String = UnitHeading(estSurfaceVolumes.Columns(nTimeX).ColumnName)
                Dim distHeading As String = UnitHeading(estSurfaceVolumes.Columns(sDistX).ColumnName)
                Dim QinHeading As String = UnitHeading(estSurfaceVolumes.Columns(2).ColumnName)
                Dim Y0Heading As String = UnitHeading(estSurfaceVolumes.Columns(sY0).ColumnName)
                Dim AY0Heading As String = UnitHeading(estSurfaceVolumes.Columns(sAY0).ColumnName)
                Dim VyHeading As String = UnitHeading(estSurfaceVolumes.Columns(sVy).ColumnName)

                ReDim Preserve svLines(svdx + 1) ' additional 2 lines

                Dim tokens() As String = Split(timeHeading, " ")
                svLines(svdx) = tokens(0).PadLeft(colW - 2, " "c)
                svLines(svdx + 1) = tokens(1).PadLeft(colW - 2, " "c)

                tokens = Split(distHeading, " ")
                svLines(svdx) &= "Dist".PadLeft(colW, " "c) ' tokens(0).PadLeft(colW, " "c)
                svLines(svdx + 1) &= tokens(1).PadLeft(colW, " "c)

                tokens = Split(QinHeading, " ")
                svLines(svdx) &= (tokens(0) & " ").PadLeft(colW, " "c)
                svLines(svdx + 1) &= tokens(1).PadLeft(colW, " "c)

                tokens = Split(Y0Heading, " ")
                svLines(svdx) &= (tokens(0) & " ").PadLeft(colW, " "c)
                svLines(svdx + 1) &= tokens(1).PadLeft(colW, " "c)

                tokens = Split(AY0Heading, " ")
                svLines(svdx) &= (tokens(0) & " ").PadLeft(colW, " "c)
                svLines(svdx + 1) &= tokens(1).PadLeft(colW, " "c)

                svLines(svdx) &= "Sigma Y".PadLeft(colW, " "c)
                svLines(svdx + 1) &= "".PadLeft(colW, " "c)

                tokens = Split(VyHeading, " ")
                svLines(svdx) &= (tokens(0) & " ").PadLeft(colW, " "c)
                svLines(svdx + 1) &= tokens(1).PadLeft(colW, " "c)

                svdx += 2

                For Each svRow As DataRow In estSurfaceVolumes.Rows

                    ReDim Preserve svLines(svdx) ' additional line

                    ' Add row data to the end of the lines
                    Dim time As Double = CDbl(svRow.Item(nTimeX))
                    Dim dist As Double = CDbl(svRow.Item(sDistX))
                    Dim Qin As Double = CDbl(svRow.Item(2))
                    Dim Y0 As Double = CDbl(svRow.Item(sY0))
                    Dim AY0 As Double = CDbl(svRow.Item(sAY0))
                    Dim Sy As Double = CDbl(svRow.Item(sSigmaY))
                    Dim Vy As Double = CDbl(svRow.Item(sVy))

                    Dim asterisk As String = ""
                    If ((MaxTadv < time) And (0.0 < Vy)) Then
                        asterisk = "*"
                        powerLawUsed = True
                    End If

                    svLines(svdx) = UnitText(time, timeUnits).PadLeft(colW - 2, " "c)
                    svLines(svdx) &= UnitText(dist, lengthUnits).PadLeft(colW, " "c)
                    svLines(svdx) &= UnitText(Qin, flowUnits).PadLeft(colW, " "c)
                    svLines(svdx) &= UnitText(Y0, depthUnits).PadLeft(colW, " "c)
                    svLines(svdx) &= UnitText(AY0, flowAreaUnits).PadLeft(colW, " "c)
                    svLines(svdx) &= UnitText(Sy, Units.None).PadLeft(colW, " "c)
                    svLines(svdx) &= UnitText(Vy, volumeUnits).PadLeft(colW, " "c) & asterisk

                    svdx += 1
                Next svRow

            End If
        End If

        For ldx As Integer = 0 To svdx - 1
            AppendLine(tbox, svLines(ldx))
        Next
        AdvanceLine(tbox)

        If (powerLawUsed) Then
            AppendText(tbox, "* ")
            AppendText(tbox, mDictionary.tPowerAdvanceLaw.Translated & ":  ")

            Dim p As Double = mInflowManagement.AdvanceP.Value
            Dim r As Double = mInflowManagement.AdvanceR.Value

            AppendBoldText(tbox, "p = ")
            AppendText(tbox, PowerAdvancePParameter.PowerAdvancePString(p, r, PowerAdvancePParameter.DisplayUnits, 0) & "  ")
            AppendBoldText(tbox, "r = ")
            AppendLine(tbox, UnitText(r, Units.None) & "  ")
        End If
        AdvanceLine(tbox)

    End Sub

    Private Sub DisplayVolumeBalanceCalculations(ByVal tbox As RichTextBox)

        Dim col1 As Integer = 6
        Dim col2 As Integer = 42
        Dim colW As Integer = 8

        Dim timeLines() As String = New String() {}

        Dim vbLines() As String = New String() {}
        Dim vbdx As Integer = 0

        Dim simLines() As String = New String() {}
        Dim sdx As Integer = 0

        TabsEnabled = True

        Dim timeUnits As Units = mUnitsSystem.TimeUnits
        Dim volumeUnits As Units = mUnitsSystem.VolumeUnits
        Dim volumeFormat As String = UnitFormats(volumeUnits)
        If ((volumeUnits = Units.Liters) Or (volumeUnits = Units.Gallons)) Then
            volumeFormat = "0.0"
        End If

        ' Add table headers
        TabTo(tbox, col1 + 3)
        AppendBoldUnderlineText(tbox, " " & mDictionary.tVolumeBalancesMeasured.Translated & "   ")
        TabTo(tbox, col2 + 3)
        AppendBoldUnderlineLine(tbox, " " & mDictionary.tVolumeBalancesSimulated.Translated & "  ")

        ' Add table data
        Dim analysis As Analysis = mWorldWindow.CurrentAnalysis

        Dim evalVolBalances As DataTable = Nothing
        Select Case mEventCriteria.EventAnalysisType.Value
            Case EventAnalysisTypes.EvalueAnalysis
                evalVolBalances = mEventCriteria.VolumeBalances.Value
            Case EventAnalysisTypes.MerriamKellerAnalysis
                Dim mk As MerriamKeller = DirectCast(analysis, MerriamKeller)
                evalVolBalances = mk.VolumeBalanceTableForCrossSection
            Case EventAnalysisTypes.TwoPointAnalysis
                Dim ew As ElliotWalkerTwoPoint = DirectCast(analysis, ElliotWalkerTwoPoint)
                evalVolBalances = ew.VolumeBalanceTable
        End Select

        If (evalVolBalances IsNot Nothing) Then

            Dim timeHeading As String = UnitHeading(evalVolBalances.Columns(nTimeX).ColumnName)
            Dim VinHeading As String = UnitHeading(evalVolBalances.Columns(sVin).ColumnName)
            Dim VyHeading As String = UnitHeading(evalVolBalances.Columns(sVy).ColumnName)
            Dim VroHeading As String = UnitHeading(evalVolBalances.Columns(sVro).ColumnName)
            Dim VzHeading As String = UnitHeading(evalVolBalances.Columns(sVz).ColumnName)

            ReDim Preserve timeLines(vbdx + 1) ' additional 2 lines
            ReDim Preserve vbLines(vbdx + 1)
            ReDim Preserve simLines(sdx + 1)

            Dim tokens() As String = Split(timeHeading, " ")
            timeLines(vbdx) = tokens(0).PadLeft(colW - 3, " "c)     ' 1st column applies to both
            timeLines(vbdx + 1) = tokens(1).PadLeft(colW - 3, " "c)

            tokens = Split(VinHeading, " ")
            vbLines(vbdx) = (tokens(0) & " ").PadLeft(colW, " "c)   ' Evaluation
            vbLines(vbdx + 1) &= tokens(1).PadLeft(colW, " "c)
            simLines(sdx) = (tokens(0) & " ").PadLeft(colW, " "c)   ' Simulation
            simLines(sdx + 1) = tokens(1).PadLeft(colW, " "c)

            tokens = Split(VyHeading, " ")
            vbLines(vbdx) &= (tokens(0) & " ").PadLeft(colW, " "c)  ' Evaluation
            vbLines(vbdx + 1) &= tokens(1).PadLeft(colW, " "c)
            simLines(sdx) &= (tokens(0) & " ").PadLeft(colW, " "c)  ' Simulation
            simLines(sdx + 1) &= tokens(1).PadLeft(colW, " "c)

            tokens = Split(VroHeading, " ")
            vbLines(vbdx) &= (tokens(0) & " ").PadLeft(colW, " "c)  ' Evaluation
            vbLines(vbdx + 1) &= tokens(1).PadLeft(colW, " "c)
            simLines(sdx) &= (tokens(0) & " ").PadLeft(colW, " "c)  ' Simulation
            simLines(sdx + 1) &= tokens(1).PadLeft(colW, " "c)

            tokens = Split(VzHeading, " ")
            vbLines(vbdx) &= (tokens(0) & " ").PadLeft(colW, " "c)  ' Evaluation
            vbLines(vbdx + 1) &= tokens(1).PadLeft(colW, " "c)
            simLines(sdx) &= (tokens(0) & " ").PadLeft(colW, " "c)  ' Simulation
            simLines(sdx + 1) &= tokens(1).PadLeft(colW, " "c)

            vbdx += 2
            sdx += 2

            Dim simVolBalances As DataTable = mEventCriteria.SimulationVolumeBalances.Value

            For vbx As Integer = 0 To evalVolBalances.Rows.Count - 1

                ReDim Preserve timeLines(vbdx) ' additional line
                ReDim Preserve vbLines(vbdx)

                Dim evalRow As DataRow = evalVolBalances.Rows(vbx)

                ' Add row data to the end of the lines
                Dim time As Double = CDbl(evalRow.Item(nTimeX))
                Dim Vin As Double = CDbl(evalRow.Item(sVin))
                Dim Vy As Double = CDbl(evalRow.Item(sVy))
                Dim Vro As Double = CDbl(evalRow.Item(sVro))
                Dim Vz As Double = CDbl(evalRow.Item(sVz))

                timeLines(vbdx) = UnitText(time, timeUnits).PadLeft(colW - 3, " "c)

                vbLines(vbdx) &= UnitText(Vin, volumeUnits, volumeFormat).PadLeft(colW, " "c)
                vbLines(vbdx) &= UnitText(Vy, volumeUnits, volumeFormat).PadLeft(colW, " "c)
                vbLines(vbdx) &= UnitText(Vro, volumeUnits, volumeFormat).PadLeft(colW, " "c)
                vbLines(vbdx) &= UnitText(Vz, volumeUnits, volumeFormat).PadLeft(colW, " "c)

                If (simVolBalances IsNot Nothing) Then
                    If (vbx < simVolBalances.Rows.Count) Then

                        ReDim Preserve simLines(sdx) ' additional line

                        Dim simRow As DataRow = simVolBalances.Rows(vbx)

                        Vin = CDbl(simRow.Item(sVin))
                        Vy = CDbl(simRow.Item(sVy))
                        Vro = CDbl(simRow.Item(sVro))
                        Vz = CDbl(simRow.Item(sVz))

                        simLines(vbdx) = UnitText(Vin, volumeUnits, volumeFormat).PadLeft(colW, " "c)
                        simLines(vbdx) &= UnitText(Vy, volumeUnits, volumeFormat).PadLeft(colW, " "c)
                        simLines(vbdx) &= UnitText(Vro, volumeUnits, volumeFormat).PadLeft(colW, " "c)
                        simLines(vbdx) &= UnitText(Vz, volumeUnits, volumeFormat).PadLeft(colW, " "c)

                    End If
                End If

                vbdx += 1
                sdx += 1
            Next

        End If

        Dim lineCount As Integer = Math.Max(vbdx, sdx)
        Dim maxLines As Integer = 18 ' Limit of displayed lines to make room for graph

        For ldx As Integer = 0 To lineCount - 1
            ' Stop when running into graph
            If ((ldx = maxLines - 2) And (maxLines < lineCount)) Then
                AppendBoldLine(tbox, " . . .")
                ldx = lineCount - 1
            End If

            If (ldx < vbLines.Length) Then
                AppendBoldText(tbox, timeLines(ldx) & " ")
                AppendText(tbox, vbLines(ldx))
            Else
                AppendText(tbox, "")
            End If
            If (ldx < simLines.Length) Then
                TabTo(tbox, col2)
                AppendLine(tbox, simLines(ldx))
            Else
                AdvanceLine(tbox)
            End If
        Next ldx

    End Sub

#End Region

#Region " Display Errors & Warnings "

    Private Sub DisplayErrorsAndWarnings(ByVal rtf As RichTextBox)

        Dim analysis As Analysis = mWorldWindow.CurrentAnalysis
        Dim errorWarningItem As Analysis.ErrorWarningItem

        If (analysis IsNot Nothing) Then
            If (analysis.HasExecutionErrors) Then
                AdvanceLine(rtf)
                AppendBoldUnderlineLine(rtf, mDictionary.tErrors.Translated)

                For Each errorWarningItem In analysis.ExecutionErrorItems
                    AdvanceLine(rtf)
                    AppendBoldText(rtf, errorWarningItem.ID)
                    AppendText(rtf, " - ")
                    AppendLine(rtf, errorWarningItem.Detail)
                Next
            End If

            If (analysis.HasSetupWarnings Or analysis.HasExecutionWarnings) Then
                AdvanceLine(rtf)
                AppendBoldUnderlineLine(rtf, mDictionary.tWarnings.Translated)

                For Each errorWarningItem In analysis.SetupWarningItems
                    AdvanceLine(rtf)
                    AppendBoldText(rtf, errorWarningItem.ID)
                    AppendText(rtf, " - ")
                    AppendLine(rtf, errorWarningItem.Detail)
                Next

                For Each errorWarningItem In analysis.ExecutionWarningItems
                    AdvanceLine(rtf)
                    AppendBoldText(rtf, errorWarningItem.ID)
                    AppendText(rtf, " - ")
                    AppendLine(rtf, errorWarningItem.Detail)
                Next
            End If
        End If

    End Sub
    '
    ' Add Error / Warning text
    '
    Private Sub AppendID(ByVal _page As RichTextBox, ByVal _indicator As String, ByVal _id As String)
        If (_indicator IsNot Nothing) Then
            If (_id IsNot Nothing) Then
                AppendBoldLine(_page, "  " & _indicator & " " & _id)
            End If
        Else
            AppendID(_page, _id)
        End If
    End Sub

    Private Sub AppendID(ByVal _page As RichTextBox, ByVal _id As String)
        If (_id IsNot Nothing) Then
            AppendBoldLine(_page, "  " & _id)
        End If
    End Sub

    Private Sub AppendDetail(ByVal _page As RichTextBox, ByVal _detail As String)
        If (_detail IsNot Nothing) Then
            Dim _line As String = String.Empty
            Dim _word As String = String.Empty

            _detail = _detail.Trim
            While (0 < _detail.Length)
                ' Extract & print the next line from Detail
                While (_line.Length + _word.Length < 75) ' word fits on line
                    _line += " " & _word

                    ' Strip the next word from Detail
                    Dim _space As Integer = _detail.IndexOf(" ")
                    If (0 < _space) Then
                        _word = _detail.Substring(0, _space)
                        _detail = _detail.Substring(_space).Trim
                    Else
                        _word = _detail ' The last word
                        If (_line.Length + _word.Length < 75) Then ' word fits on line
                            _line += " " & _word
                            AppendLine(_page, _line)
                        Else
                            AppendLine(_page, _line)
                            AppendLine(_page, "  " & _word)
                        End If
                        Exit Sub
                    End If
                End While

                AppendLine(_page, _line)
                _line = " "
            End While
        End If
    End Sub

#End Region

#Region " Results Page Methods "
    '
    ' Recursively traverses Controls looking for ExPictureBoxes so their Images can be properly Disposed
    '
    Private Sub ReleaseResources(ByVal _ctrl As Control)
        If (_ctrl IsNot Nothing) Then
            ' Look for ex_pictureBox or derived class
            If ((_ctrl.GetType Is GetType(ex_PictureBox)) _
             Or (_ctrl.GetType.IsSubclassOf(GetType(ex_PictureBox)))) Then

                ' Properly Dispose of Image
                Dim _pictureBox As ex_PictureBox = DirectCast(_ctrl, ex_PictureBox)
                If (_pictureBox.Image IsNot Nothing) Then
                    _pictureBox.Image.Dispose()
                    _pictureBox.Image = Nothing
                End If
            Else
                ' Keep traversing through all contained controls
                For _idx As Integer = _ctrl.Controls.Count - 1 To 0 Step -1
                    Try
                        ' Get Control at the end of the list
                        Dim _control As Control = _ctrl.Controls(_idx)
                        If (_control IsNot Nothing) Then
                            ' First, clear its resources
                            ReleaseResources(_control)
                            ' Then, remove & display of the Control
                            _ctrl.Controls.RemoveAt(_idx)
                            _control.Dispose()
                            _control = Nothing
                        End If

                    Catch ex As Exception
                    End Try
                Next
            End If
        End If
    End Sub
    '
    ' Clear all the Results Pages & Panels
    '
    Private Sub ClearResultsPages()
        '
        ' Dispose of all resources (especially Bitmaps) so Garbage Collection can reclaim
        ' the memory.
        '
        Me.SuspendLayout()
        '
        ' Clear the Tab Pages
        '
        For _idx As Integer = Me.TabPages.Count - 1 To 0 Step -1
            Try
                ' Get Tab Page at the end of the list
                Dim _tabPage As TabPage = Me.TabPages(_idx)
                If (_tabPage IsNot Nothing) Then
                    ' First, clear its Controls
                    For _jdx As Integer = _tabPage.Controls.Count - 1 To 0 Step -1
                        Dim _control As Control = _tabPage.Controls(_jdx)
                        If (_control IsNot Nothing) Then
                            ReleaseResources(_control)
                            _tabPage.Controls.RemoveAt(_jdx)
                            _control.Dispose()
                            _control = Nothing
                        End If
                    Next

                    ' Then, remove & dispose of the Tab Page
                    Me.TabPages.RemoveAt(_idx)
                    _tabPage.Dispose()
                    _tabPage = Nothing
                End If

            Catch ex As Exception
            End Try
        Next

        Me.TabPages.Clear()
        '
        ' Clear the Results Pages
        '
        For _idx As Integer = mResultsPages.Count - 1 To 0 Step -1
            Try
                ' Get Results Page at the end of the list
                Dim _page As RtfPage = CType(mResultsPages(_idx), RtfPage)
                If (_page IsNot Nothing) Then
                    ' First, clear its resources
                    ReleaseResources(_page)
                    ' Then, remove & dispose of the Results Page
                    mResultsPages.RemoveAt(_idx)
                    RemoveHandler _page.RtfCtrl.MouseWheel, AddressOf RtfCtrl_MouseWheel
                    _page.Dispose()
                    _page = Nothing
                End If

            Catch ex As Exception
            End Try
        Next

        mResultsPages.Clear()
        '
        ' Clear the Results Panels
        '
        For _idx As Integer = mResultsPanels.Count - 1 To 0 Step -1
            Try
                ' Get Results Panel at the end of the list
                Dim _panel As Panel = CType(mResultsPanels(_idx), Panel)
                If (_panel IsNot Nothing) Then
                    ' First, clear its resources
                    ReleaseResources(_panel)
                    ' Then, remove & dispose of the Results Panel
                    mResultsPanels.RemoveAt(_idx)
                    RemoveHandler _panel.Paint, AddressOf Panel_PaintGraph
                    _panel.Dispose()
                    _panel = Nothing
                End If

            Catch ex As Exception
            End Try
        Next

        mResultsPanels.Clear()

        Me.ResumeLayout()

    End Sub

    Private Function GetResultsPage(ByVal _pageNumber As Integer) As RtfPage

        ' If page number is within range of pages; return that page
        If ((0 < _pageNumber) And (_pageNumber <= NumberOfPages)) Then
            Dim _page As RtfPage = CType(mResultsPages.Item(_pageNumber - 1), RtfPage)
            Return _page
        End If

        Return Nothing

    End Function

    Private Function GetNewResultsPanel(ByVal _title As String) As Panel

        ' Instantiate a new Results Panel
        Dim _panel As Panel = New Panel

        _panel.BackColor = Color.White
        _panel.Location = New Point(0, 0)
        _panel.Dock = DockStyle.Fill

        ' Add event handler for Paint events
        AddHandler _panel.Paint, AddressOf Panel_PaintGraph

        Return _panel

    End Function

    Private Function GetNewResultsPage(ByVal _title As String, _
                                       ByVal _view As ResultsViews) As RtfPage

        ' Instantiate a new Results Page
        Dim page As RtfPage = New RtfPage

        page.PageTitle = _title
        page.PageNumber = NumberOfPages + 1

        page.PageWidth = PortraitPageWidth
        page.PageHeight = PortraitPageLength

        page.TopMargin = PortraitTopMargin
        page.LeftMargin = PortraitLeftMargin
        page.RightMargin = PortraitRightMargin
        page.BottomMargin = PortraitBottomMargin

        page.Location = New Point(LeftOffset, TopOffset)

        If (mWorldWindow IsNot Nothing) Then
            page.Font = mWorldWindow.FixedFont
            page.Rtf.Font = mWorldWindow.FixedFont
        End If

        ' Add event handler for Mouse Wheel events
        AddHandler page.RtfCtrl.MouseWheel, AddressOf RtfCtrl_MouseWheel

        mResultsPages.Add(page)

        Return page

    End Function

    Private Function GetNewXYGraphPage(ByVal _dataSet As DataSet, _
                                       ByVal _title As String) As grf_XYGraph

        Dim _2dGraph As grf_XYGraph = New grf_XYGraph(_dataSet)

        LoadUserColors(_2dGraph)

        _2dGraph.Location = PortraitGraphLocation
        _2dGraph.Size = PortraitGraphSize

        _2dGraph.AccessibleName = _title
        _2dGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        _2dGraph.ToolTip.Active = False

        Return _2dGraph

    End Function

    Private Function GetNewXYGraphPanel(ByVal _dataSet As DataSet, _
                                        ByVal _title As String) As grf_XYGraph

        Dim _2dGraph As grf_XYGraph = New grf_XYGraph(_dataSet)

        LoadUserColors(_2dGraph)

        _2dGraph.Dock = DockStyle.Fill
        _2dGraph.AccessibleName = _title
        _2dGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        _2dGraph.ToolTip.Active = False

        Return _2dGraph

    End Function

    Private Function GetNewX2YGraphPage(ByVal _dataSet As DataSet, _
                                        ByVal _title As String) As grf_X2YGraph

        Dim _2dGraph As grf_X2YGraph = New grf_X2YGraph(_dataSet)

        LoadUserColors(_2dGraph)

        _2dGraph.Location = PortraitGraphLocation
        _2dGraph.Size = PortraitGraphSize

        _2dGraph.AccessibleName = _title
        _2dGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        _2dGraph.ToolTip.Active = False

        Return _2dGraph

    End Function

    Private Function GetNewX2YGraphPanel(ByVal _dataSet As DataSet, _
                                         ByVal _title As String) As grf_X2YGraph

        Dim _2dGraph As grf_X2YGraph = New grf_X2YGraph(_dataSet)

        LoadUserColors(_2dGraph)

        _2dGraph.Dock = DockStyle.Fill
        _2dGraph.AccessibleName = _title
        _2dGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        _2dGraph.ToolTip.Active = False

        Return _2dGraph

    End Function

    Private Function GetNewDreqDminPage(ByVal _dataSet As DataSet, _
                                        ByVal _title As String) As grf_DreqDmin

        Dim _x2yGraph As grf_DreqDmin = New grf_DreqDmin(mWorldWindow, _dataSet)

        LoadUserColors(_x2yGraph)

        _x2yGraph.Location = PortraitGraphLocation
        _x2yGraph.Size = PortraitGraphSize

        _x2yGraph.AccessibleName = _title
        _x2yGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        _x2yGraph.ToolTip.Active = False

        Return _x2yGraph

    End Function

    Private Function GetNewDreqDminPanel(ByVal _dataSet As DataSet, _
                                         ByVal _title As String) As grf_DreqDmin

        Dim _x2yGraph As grf_DreqDmin = New grf_DreqDmin(mWorldWindow, _dataSet)

        LoadUserColors(_x2yGraph)

        _x2yGraph.Dock = DockStyle.Fill
        _x2yGraph.AccessibleName = _title
        _x2yGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        _x2yGraph.ToolTip.Active = False

        Return _x2yGraph

    End Function
    '
    ' DisplayResultsHeader() - displays the results header
    '
    Private Sub DisplayResultsHeader(ByVal tbox As RichTextBox, _
                                     Optional ByVal title As String = "")

        Debug.Assert(tbox IsNot Nothing)

        ' Center the heading text
        tbox.SelectionAlignment = HorizontalAlignment.Center

        ' Program & ALARC names
        AppendBoldText(tbox, mUnitControl.ProductName.Value)
        AppendLine(tbox, " " & mUnitControl.ProductVersion.Value & " - " & _
                                CenterName & ", " & CenterCity & ", " & CenterState)

        ' WinSRFR Function
        If (mWorldWindow IsNot Nothing) Then
            If (mWorldWindow.GetType Is GetType(EvaluationWorld)) Then
                AppendText(tbox, mDictionary.tEventAnalysis.Translated)
            ElseIf (mWorldWindow.GetType Is GetType(SimulationWorld)) Then
                AppendText(tbox, mDictionary.tSimulation.Translated)
            ElseIf (mWorldWindow.GetType Is GetType(OperationsWorld)) Then
                AppendText(tbox, mDictionary.tOperationsAnalysis.Translated)
            ElseIf (mWorldWindow.GetType Is GetType(DesignWorld)) Then
                AppendText(tbox, mDictionary.tDesignAnalysis.Translated)
            Else
            End If
        End If
        AppendText(tbox, " " & mDictionary.tResults.Translated & " - ")

        ' Current Date / Time
        AppendText(tbox, mUnitControl.RunDateTime.Value.ToLongDateString & " ")
        AppendLine(tbox, mUnitControl.RunDateTime.Value.ToShortTimeString)
        AdvanceLine(tbox)

        ' Farm / Field / Unit names
        Dim _widthChars As Integer = PortraitWidthChars

        AppendFieldIdText(tbox, mUnit, _widthChars)
        AdvanceLine(tbox)
        AppendUnitIdText(tbox, mUnit, _widthChars)
        AdvanceLines(tbox, 2)

        ' Current analysis or specified title
        If (title = "") Then
            Select Case (mEventCriteria.EventAnalysisType.Value)
                Case EventAnalysisTypes.EvalueAnalysis
                    AppendBoldLine(tbox, "EVALUE " & mDictionary.tAnalysis.Translated)
                Case EventAnalysisTypes.MerriamKellerAnalysis
                    AppendBoldLine(tbox, "Merriam-Keller " & mDictionary.tAnalysis.Translated)
                Case EventAnalysisTypes.TwoPointAnalysis
                    AppendBoldLine(tbox, "Elliott-Walker Two-Point " & mDictionary.tAnalysis.Translated)
                Case EventAnalysisTypes.InfiltratedProfileAnalysis
                    AppendBoldLine(tbox, mDictionary.tInfiltratedProfileAnalysis.Translated)
                Case Else
                    Debug.Assert(False, "Support for this type must be added")
            End Select
        Else
            AppendBoldLine(tbox, title)
        End If
        AdvanceLines(tbox, 2)

    End Sub
    '
    ' DisplayResultsFooter() - displays the SRFR results footer
    '
    Private Sub DisplayResultsFooter(ByVal tbox As RichTextBox, _
                                     ByVal _pageNumber As Integer, _
                                     ByVal _totalPages As Integer)

        ' Print blank lines until end-of-page
        While (CountLines(tbox) < PortraitHeightLines)
            AdvanceLine(tbox)
        End While

        ' Center the footer text
        tbox.SelectionAlignment = HorizontalAlignment.Center

        ' Print page numbers
        AppendText(tbox, mDictionary.tPage.Translated & " " & _pageNumber.ToString & " " & mDictionary.tOf.Translated & " " & _totalPages.ToString)

    End Sub

    Private Function GetNewHydraulicSummaryPanel(ByVal _advRec As DataSet, _
                                                 ByVal _infilt As DataSet, _
                                                 ByVal _hydro As DataSet, _
                                                 ByVal _title As String) As grf_HydraulicSummary

        Dim _2dGraph As grf_HydraulicSummary = New grf_HydraulicSummary(_advRec, _infilt, _hydro)

        LoadUserColors(_2dGraph)

        _2dGraph.Dock = DockStyle.Fill
        _2dGraph.AccessibleName = _title
        _2dGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        _2dGraph.ToolTip.Active = False

        Return _2dGraph

    End Function

    Private Function GetNewHydraulicSummaryPage(ByVal _advRec As DataSet, _
                                                ByVal _infilt As DataSet, _
                                                ByVal _hydro As DataSet, _
                                                ByVal _title As String) As grf_HydraulicSummary

        Dim _2dGraph As grf_HydraulicSummary = New grf_HydraulicSummary(_advRec, _infilt, _hydro)

        LoadUserColors(_2dGraph)

        _2dGraph.Location = PortraitGraphLocation
        _2dGraph.Size = PortraitGraphSize

        _2dGraph.AccessibleName = _title
        _2dGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        _2dGraph.ToolTip.Active = False

        Return _2dGraph

    End Function

    Private Sub AddResultsPanel(ByVal title As String, ByVal tabName As String, ByVal graph As ex_PictureBox)

        Debug.Assert(title IsNot Nothing, "Title is Nothing")
        Debug.Assert(tabName IsNot Nothing, "Tab Name is Nothing")
        Debug.Assert(graph IsNot Nothing, "2D Graph is Nothing")

        ' Add the Graphics Only Panel only if it will be displayed
        If (ResultsView = Globals.ResultsViews.GraphsOnly) Then
            ' Graphics Only view for Display only
            Dim _panel As Panel = GetNewResultsPanel(title)

            _panel.AccessibleName = title
            _panel.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated

            ' Add graph to panel
            _panel.Controls.Add(graph)

            ' Add panel to tabpage
            AddTabPage(tabName, _panel)

        End If

    End Sub

    Private Function AddTabPage(ByVal _title As String, ByVal _ctrl As Control) As TabPage

        ' Add control inside a new TabPage
        Dim _tabPage As TabPage = New TabPage(_title)

        _tabPage.BackColor = System.Drawing.SystemColors.ControlDarkDark

        ' Scrolling does not apply to panel view
        If (_ctrl.GetType Is GetType(Panel)) Then
            _tabPage.AutoScroll = False
            _tabPage.AutoScrollMargin = New Size(0, 0)
        Else ' Assume page view
            _tabPage.AutoScroll = True
            _tabPage.AutoScrollMargin = New Size(LeftOffset, TopOffset)
        End If

        _tabPage.SuspendLayout()
        _tabPage.Controls.Add(_ctrl)
        _tabPage.ResumeLayout()

        ' Add the TabPage to the TabControl (Me)
        Me.SuspendLayout()
        Me.TabPages.Add(_tabPage)
        Me.SelectedTab = _tabPage
        Me.ResumeLayout()

        Return _tabPage

    End Function

    Private Sub AddResultsPage(ByVal title As String, ByVal tabName As String, ByVal graph As ctl_Canvas2D)

        Debug.Assert(title IsNot Nothing, "Title is Nothing")
        Debug.Assert(tabName IsNot Nothing, "Tab Name is Nothing")
        Debug.Assert(graph IsNot Nothing, "Graph is Nothing")

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        Dim tbox As RichTextBox = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Add Header
        DisplayResultsHeader(tbox)

        ' Add graph
        page.AddImage(graph)

        ' Add Footer
        mPageNumber += 1

        DisplayResultsFooter(tbox, mPageNumber, mTotalPages)

        ' Make the Full Page visible, if requested
        If (ResultsView = Globals.ResultsViews.PortraitPage) Then
            AddTabPage(tabName, page)
        End If

        ' Draw the graph
        graph.DrawImage()

    End Sub

    Public Sub DisplayResultsPageNumber()
        ' Display the Results page number in the Status Bar
        If (mWorldWindow IsNot Nothing) Then
            Dim _pageNo As Integer = Me.SelectedIndex + 1
            mWorldWindow.ProgressMessage = "Pg " & _pageNo.ToString & "/" & mTotalPages.ToString
        End If
    End Sub

#End Region

#End Region

#Region " UI Update Methods "
    '
    ' Update the Results' User Interface
    '
    Private mResultsAreValid As Boolean = False
    Private Sub UpdateUI()
        UpdateUI(mResultsAreValid)
    End Sub

    Public Sub UpdateUI(ByVal _resultsAreValid As Boolean)

        ' Save the Results Are Valid state
        mResultsAreValid = _resultsAreValid

        ' Update the UI only if it is linked to a model object
        If ((mWorldWindow Is Nothing) Or (mUnit Is Nothing)) Then
            Return
        End If

        ' Save the currently selected tab page for later restoration
        Dim _selectedIndex As Integer = Me.SelectedIndex

        Dim _analysis As Analysis = mWorldWindow.CurrentAnalysis

        ' Clear all previously displayed results
        ClearResultsPages()

        ' If there are valid results, display them
        If (mResultsAreValid) Then

            If (mUnit IsNot Nothing) Then

                Try
                    If (0 < mUnitControl.RunCount.Value) Then

                        ' Check for Execution error
                        Dim _errorCount As Integer = _analysis.ExecutionErrorCount

                        If (0 < _errorCount) Then
                            ' There is at least one SRFR error
                            Dim tErrors As String = mDictionary.tErrors.Translated

                            Dim _page As RtfPage = GetNewResultsPage(tErrors, ResultsView)
                            _page.AccessibleName = tErrors
                            _page.AccessibleDescription = mDictionary.tErrExecution.Translated

                            Dim tbox As RichTextBox = _page.Rtf
                            AppendBoldLine(tbox, mDictionary.tErrExecutionStoppedDueTo.Translated & " " & tErrors & ":")
                            DisplayErrorsAndWarnings(tbox)
                            AddTabPage(tErrors, _page)

                            Return
                        End If

                        ' Display the appropriate results
                        Select Case (mUnit.UnitType.Value)
                            Case WorldTypes.EventWorld
                                Me.DisplayEvaluationResults()
                            Case Else
                                Debug.Assert(False) ' Unknown Unit Type
                        End Select
                    End If
                Catch ex As Exception
                    mWinSRFR.LogException(WinSRFR.ErrorLevels.Serious, "ctl_EvaluationResults[UpdateUI]", ex)
                End Try

            End If
        End If

        ' Re-select the saved tab page
        If ((-1 < _selectedIndex) And (_selectedIndex < Me.TabCount)) Then
            Me.SelectedIndex = _selectedIndex
        Else
            Me.SelectedIndex = Me.TabCount - 1
        End If

        ' If there is nothing displayed; put up "No Results" tab page
        If (Me.SelectedIndex < 0) Then
            DisplayNoResults(ResultsView)
        End If

        'FocusSelectedTab()

    End Sub

#End Region

#Region " Print Support Methods "

    '*********************************************************************************************************
    ' Sub Print()           - called to print the results pages
    ' Sub PrintPreview()    -    "    " preview "    "      "
    '*********************************************************************************************************
    Public Sub Print()

        If (NumberOfPages < 0) Then ' there is nothing to print
            Return
        End If

        ' Start with full range of pages
        ReDim mPageSelections(1)
        mPageSelections(0) = 1
        mPageSelections(1) = NumberOfPages

        If (mWorldWindow.PrintResults(Me.PrintDialog, Me.SelectedIndex + 1, mPageSelections)) Then

            mNextPageNo = mPageSelections(0)

            ' Make sure the first page actually exists
            Dim page As RtfPage = GetResultsPage(mNextPageNo)
            If (page IsNot Nothing) Then

                ' Set page to match the portrait results display
                Dim PortraitMargins As Margins = New Margins(PortraitLeftMargin - 10, PortraitRightMargin, _
                                                             PortraitTopMargin, PortraitBottomMargin)

                Me.PrintDocument.DefaultPageSettings.Margins = PortraitMargins
                Me.PrintDocument.DefaultPageSettings.Landscape = False

                ' Print (which may cause exceptions)
                Try
                    Me.PrintDocument.Print()
                Catch ex As Exception
                    mWinSRFR.SeriousException("PrintDocument.Print()", ex)
                End Try
            End If
        End If

    End Sub

    Public Sub PrintPreview()

        ' Set page to match the portrait results display
        Dim PortraitMargins As Margins = New Margins(PortraitLeftMargin - 10, PortraitRightMargin, _
                                                     PortraitTopMargin, PortraitBottomMargin)

        PrintDocument.DefaultPageSettings.Margins = PortraitMargins
        PrintDocument.DefaultPageSettings.Landscape = False

        ' Print preview all pages
        Dim FromPage As Integer = 1
        Dim ToPage As Integer = NumberOfPages

        If (FromPage <= ToPage) Then ' there are page(s) to preview
            ReDim mPageSelections(ToPage - FromPage)
            For pdx As Integer = 0 To mPageSelections.Length - 1
                mPageSelections(pdx) = FromPage + pdx
            Next pdx

            PrintPreviewDialog.Document.PrinterSettings.PrintRange = PrintRange.AllPages
            PrintPreviewDialog.ShowDialog()
        End If

    End Sub

    '*********************************************************************************************************
    ' PrintDocument event handlers that actually print the requested results pages
    '*********************************************************************************************************
    Private Sub PrintDocument_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs) _
    Handles PrintDocument.BeginPrint
        mNextPageSelection = 0
    End Sub

    Private Sub PrintDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) _
    Handles PrintDocument.PrintPage

        Try
            ' Get next page number to print
            mNextPageNo = mPageSelections(mNextPageSelection)

            Dim ResultsPage As RtfPage = GetResultsPage(mNextPageNo)
            If (ResultsPage IsNot Nothing) Then

                ' Tell the next page to print itself
                ResultsPage.Print(e)

                ' If there are more pages to print; let caller know
                If (mNextPageSelection < mPageSelections.Length - 1) Then
                    mNextPageSelection += 1
                    e.HasMorePages = True
                    Return
                End If
            End If

        Catch ex As Exception
        End Try

        e.HasMorePages = False

    End Sub

#End Region

#Region " Object Event Handlers "
    '
    ' Any disposed member data must be set to Nothing to prevent invalid accesses
    '

    ' EVALUE Analysis
    Private Sub InputSummaryPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mInputSummaryPage.Disposed
        mInputSummaryPage = Nothing
    End Sub

    Private Sub AdvRecOppPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mAdvRecOppPage.Disposed
        mAdvRecOppPage = Nothing
    End Sub

    Private Sub VolumeBalancePage_Disposed() _
    Handles mVolumeBalancePage.Disposed
        mVolumeBalancePage = Nothing
    End Sub

    Private Sub SurfaceFlowSummaryPage_Disposed() _
    Handles mSurfaceFlowMeasuredPage.Disposed
        mSurfaceFlowMeasuredPage = Nothing
    End Sub

    Private Sub PerformanceSummaryPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mPerformanceSummaryPage.Disposed
        mPerformanceSummaryPage = Nothing
    End Sub

    ' Infiltrated Profile Analysis
    Private Sub IpaSoilWaterDeficitPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mIpaSoilWaterDeficitPage.Disposed
        mIpaSoilWaterDeficitPage = Nothing
    End Sub

    Private Sub IpaInfiltratedDepthsPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mIpaInfiltratedDepthsPage.Disposed
        mIpaInfiltratedDepthsPage = Nothing
    End Sub

    Private Sub IpaPerformanceAnalysisPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mIpaPerformanceAnalysisPage.Disposed
        mIpaPerformanceAnalysisPage = Nothing
    End Sub

    ' Merriam-Keller Analysis
    Private Sub MkGoodnessPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mMkGoodnessPage.Disposed
        mMkGoodnessPage = Nothing
    End Sub

    ' Elliott-Walker Two-Point Analysis
    Private Sub EwTwoPointPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mEwTwoPointPage.Disposed
        mEwTwoPointPage = Nothing
    End Sub

    Private Sub EwGoodnessPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mEwGoodnessPage.Disposed
        mEwGoodnessPage = Nothing
    End Sub

    ' Erosion Analysis
    Private Sub ErosionParametersPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mErosionParametersPage.Disposed
        mErosionParametersPage = Nothing
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " TabControl Event Handlers "

    Private Sub TabControl_TabIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.SelectedIndexChanged

        If (-1 < Me.SelectedIndex) Then

            Dim _tabPage As TabPage = Nothing
            '
            ' Keep the same scroll position from tab to tab
            '
            If Not (mSelectedIndex = Me.SelectedIndex) Then
                If (mSelectedIndex < Me.TabCount) Then

                    'FocusSelectedTab()

                    ' Get scroll position from last Tab Page (RtfPage only)
                    _tabPage = Me.TabPages(mSelectedIndex)

                    If (0 < _tabPage.Controls.Count) Then
                        If (_tabPage.Controls(0).GetType Is GetType(RtfPage)) Then

                            Dim _position As Point = _tabPage.AutoScrollPosition

                            ' Scroll current tab page (RtfPage only)
                            _tabPage = Me.TabPages(Me.SelectedIndex)

                            If (0 < _tabPage.Controls.Count) Then
                                If (_tabPage.Controls(0).GetType Is GetType(RtfPage)) Then

                                    ' Adjust scroll position following Microsoft's inane logic:
                                    '  What goes in has the OPPOSITE SIGN of what comes out!!!  &^*%$%#
                                    _position.X = -_position.X
                                    _position.Y = -_position.Y

                                    _tabPage.AutoScrollPosition = _position

                                End If
                            End If
                        End If
                    End If
                End If

                mSelectedIndex = Me.SelectedIndex

            End If
            '
            ' Make sure the display is current
            '   The Paint event doesn't do this for tab index changes
            '
            If (_tabPage IsNot Nothing) Then

                _tabPage = Me.SelectedTab

                For Each _panel As Control In _tabPage.Controls

                    If (_panel.GetType Is GetType(Panel)) Then

                        For Each _control As Control In _panel.Controls

                            If ((_control.GetType Is GetType(ctl_Canvas2D)) _
                             Or (_control.GetType.IsSubclassOf(GetType(ctl_Canvas2D)))) Then

                                Dim _canvas As ctl_Canvas2D = DirectCast(_control, ctl_Canvas2D)

                                ' Redraw the image
                                _canvas.DrawImage()
                            End If
                        Next

                    End If
                Next

                ' Display the Results page number in the Status Bar
                DisplayResultsPageNumber()

            End If
        End If

    End Sub

    Private Sub Panel_PaintGraph(ByVal sender As Object, ByVal e As PaintEventArgs)
        ' Handles Panel.Paint

        ' Get references to Panel & Control that need painting
        Dim _panel As Panel = DirectCast(sender, Panel)

        If (0 < _panel.Controls.Count) Then

            If ((_panel.Controls(0).GetType Is GetType(ctl_Canvas2D)) _
             Or (_panel.Controls(0).GetType.IsSubclassOf(GetType(ctl_Canvas2D)))) Then

                Dim _canvas As ctl_Canvas2D = DirectCast(_panel.Controls(0), ctl_Canvas2D)

                ' Redraw the graph
                If (_canvas.Visible) Then
                    _canvas.DrawImage()
                End If
            End If
        End If

    End Sub
    '
    ' User Draw the TabControl tabs to add highlights for ease-of-use
    '
    Private Sub TabControl_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) _
    Handles MyBase.DrawItem
        '
        ' Define back/fore brush colors for selected/unselected tabs
        '
        Dim background, foreground As Brush
        If Me.SelectedIndex = e.Index Then ' selected tab
            background = New SolidBrush(System.Drawing.SystemColors.ActiveCaption)
            foreground = New SolidBrush(System.Drawing.SystemColors.ActiveCaptionText)
        Else ' unselected tab
            background = New SolidBrush(System.Drawing.SystemColors.Control)
            foreground = New SolidBrush(DefaultForeColor)
        End If
        '
        ' Draw tab's rectangle/text
        '
        Dim tab As TabPage = Me.TabPages(e.Index)
        Dim tabText As String = tab.Text
        Dim tabRectF As New RectangleF(e.Bounds.X - 4, e.Bounds.Y + 3, e.Bounds.Width + 7, e.Bounds.Height - 3)

        Dim format As New StringFormat
        format.Alignment = StringAlignment.Center

        e.Graphics.FillRectangle(background, e.Bounds)
        e.Graphics.DrawString(tabText, Me.Font, foreground, tabRectF, format)

    End Sub

#End Region

#Region " Page Event Handlers "

    Private Sub ScrollPage(ByVal _delta As Integer)

        If Not (_delta = 0) Then
            ' Scroll the currently selected TabPage
            Dim _tabPage As TabPage = Me.SelectedTab

            If (_tabPage IsNot Nothing) Then
                ' Get current scroll position
                Dim _position As Point = _tabPage.AutoScrollPosition

                ' Adjust the position to follow mouse wheel movement
                '  NOTE - What goes in has the OPPOSITE SIGN of what comes out!!!  &^*%$%#
                _position.X = CInt(-_position.X)
                _position.Y = CInt(-_position.Y - (PortraitPageLength / (_delta / 6)))

                ' Scroll the tab page
                _tabPage.AutoScrollPosition = _position
            End If
        End If

    End Sub

    Private Sub TabControl_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) _
    Handles MyBase.MouseWheel
        ScrollPage(e.Delta)
    End Sub

    Private Sub RtfCtrl_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
        ' Handles RtfCtrl.MouseWheel
        ScrollPage(e.Delta)
    End Sub

#End Region

#End Region

End Class
