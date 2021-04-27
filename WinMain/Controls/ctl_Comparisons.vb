
'**********************************************************************************************
' ctl_Comparisons - Control for comparing the WinSRFR computation results
'
Imports System.Drawing.Printing
Imports DataStore
Imports PrintingUI

Public Class ctl_Comparisons
    Inherits System.Windows.Forms.TabControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeComparisons()

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ctl_Comparisons))
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
        Me.PrintPreviewDialog.Location = New System.Drawing.Point(124, 17)
        Me.PrintPreviewDialog.MinimumSize = New System.Drawing.Size(375, 250)
        Me.PrintPreviewDialog.Name = "PrintPreviewDialog"
        Me.PrintPreviewDialog.TransparencyKey = System.Drawing.Color.Empty
        Me.PrintPreviewDialog.Visible = False
        '
        'ctl_Comparisons
        '
        Me.AccessibleDescription = "Tab pages contain the comparisons of the last WinSRFR Runs"
        Me.AccessibleName = "WinSRFR Comparisons"
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Multiline = True

    End Sub

#End Region

#Region " Member Data "

#Region " Object References "

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

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

    Private Const FontSize As Integer = 11

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
    ' Results Pages & Panels
    '
    Private mResultsPages As ArrayList
    Private mResultsPanels As ArrayList
    Private mPageNumber As Integer
    Private mTotalPages As Integer

    Private Const UnitsPerPage As Integer = 4
    Private Const ColWidth As Integer = 15
    Private Const Blanks As String = "                                          "
    '
    ' Printing support
    '
    Private mFromPage As Integer = 1
    Private mPageToPrint As Integer = 1
    Private mToPage As Integer = 1

#End Region

#Region " Comparison Data "
    '
    ' Units to compare
    '
    Private mUnits As ArrayList
    '
    ' Graphs
    '
    Private mInflowPageGraph As grf_XYGraph
    Private mInflowRunoffPageGraph As grf_XYGraph
    Private mAdvancePageGraph As grf_XYGraph
    Private mAdvanceRecessionPageGraph As grf_XYGraph
    Private mVolumeBalanceVsTimePageGraph As grf_XYGraph
    Private mVolumeBalanceVsAdvPageGraph As grf_XYGraph
    Private mInfiltrationPageGraph As grf_XYGraph
    Private mUpstreamInfiltrationPageGraph As grf_XYGraph
    Private mInfiltrationFunctionPageGraph As grf_XYGraph
    Private mInfiltrationDepthFunctionPageGraph As grf_XYGraph
    Private mErosionGPageGraph As grf_XYGraph
    Private mErosionCGmPageGraph As grf_XYGraph
    Private mErosionCGvPageGraph As grf_XYGraph

    Private mInflowPanelGraph As grf_XYGraph
    Private mInflowRunoffPanelGraph As grf_XYGraph
    Private mAdvancePanelGraph As grf_XYGraph
    Private mAdvanceRecessionPanelGraph As grf_XYGraph
    Private mVolumeBalanceVsTimePanelGraph As grf_XYGraph
    Private mVolumeBalanceVsAdvPanelGraph As grf_XYGraph
    Private mInfiltrationPanelGraph As grf_XYGraph
    Private mUpstreamInfiltrationPanelGraph As grf_XYGraph
    Private mInfiltrationFunctionPanelGraph As grf_XYGraph
    Private mInfiltrationDepthFunctionPanelGraph As grf_XYGraph
    Private mErosionGPanelGraph As grf_XYGraph
    Private mErosionCGmPanelGraph As grf_XYGraph
    Private mErosionCGvPanelGraph As grf_XYGraph

#End Region

#End Region

#Region " Properties "
    '
    ' Data Comparison selections
    '
    Private mDataComparisonType As DataComparisonTypes = DataComparisonTypes.AllDataComparisonTypes
    Public Property DataComparisonType() As DataComparisonTypes
        Get
            Return mDataComparisonType
        End Get
        Set(ByVal Value As DataComparisonTypes)
            mDataComparisonType = Value
        End Set
    End Property
    '
    ' Erosion curve number to display
    '
    Private mErosionCurveNo As Integer = 1
    Public Property ErosionCurveNo() As Integer
        Get
            Return mErosionCurveNo
        End Get
        Set(ByVal Value As Integer)
            mErosionCurveNo = Value
        End Set
    End Property

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

#End Region

#Region " Initialization "

    Private Sub InitializeComparisons()
        mResultsPages = New ArrayList
        mResultsPanels = New ArrayList
        PrintPreviewDialog.Size = New Size(700, 500)
    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mWinSRFR As WinSRFR
    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Public Sub LinkToModel(ByVal _winSRFR As WinSRFR,
                           ByVal _dataComparisonType As DataComparisonTypes,
                           ByVal _resultsView As ResultsViews)

        Dim _dataSet As DataSet

        If (_winSRFR IsNot Nothing) Then

            Dim tInflow As String = mDictionary.tInflow.Translated
            Dim tInflowRunoff As String = tInflow & " / " & mDictionary.tRunoff.Translated
            Dim tAdvance As String = mDictionary.tAdvance.Translated
            Dim tAdvanceRecession As String = tAdvance & " / " & mDictionary.tRecession.Translated
            Dim tInfiltration As String = mDictionary.tInfiltration.Translated
            Dim tInfiltrationFunction As String = mDictionary.tInfiltrationFunction.Translated
            Dim tInfiltrationDepthFunction As String = mDictionary.tInfiltrationDepthFunction.Translated
            Dim tUpstreamInfiltration As String = mDictionary.tUpstreamInfiltration.Translated
            Dim tUpstreamInfiltrationDepth As String = mDictionary.tUpstreamInfiltrationDepth.Translated
            '
            ' Start with a new set of Units to compare
            '
            mUnits = New ArrayList
            '
            ' Save input data
            '
            mWinSRFR = _winSRFR
            mDataComparisonType = _dataComparisonType
            mResultsView = _resultsView
            '
            ' Add TabPages based on Graph Type
            '
            mUpdatingTabPages = True
            Me.TabPages.Clear()
            '
            ' Inflow curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tInflow)

            If (mInflowPageGraph IsNot Nothing) Then
                mInflowPageGraph.Dispose()
                mInflowPageGraph = Nothing
            End If
            mInflowPageGraph = GetNew2dGraphPage(_dataSet, tInflow)
            mInflowPageGraph.UnitsX = UnitsDefinition.Units.Seconds
            mInflowPageGraph.UnitsY = UnitsDefinition.Units.Cms
            mInflowPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tInflow)

            If (mInflowPanelGraph IsNot Nothing) Then
                mInflowPanelGraph.Dispose()
                mInflowPanelGraph = Nothing
            End If
            mInflowPanelGraph = GetNew2dGraphPanel(_dataSet, tInflow)
            mInflowPanelGraph.UnitsX = UnitsDefinition.Units.Seconds
            mInflowPanelGraph.UnitsY = UnitsDefinition.Units.Cms
            mInflowPanelGraph.DisplayKey = True
            '
            ' Inflow / Runoff curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tInflowRunoff)

            If (mInflowRunoffPageGraph IsNot Nothing) Then
                mInflowRunoffPageGraph.Dispose()
                mInflowRunoffPageGraph = Nothing
            End If
            mInflowRunoffPageGraph = GetNew2dGraphPage(_dataSet, tInflowRunoff)
            mInflowRunoffPageGraph.UnitsX = UnitsDefinition.Units.Seconds
            mInflowRunoffPageGraph.UnitsY = UnitsDefinition.Units.Cms
            mInflowRunoffPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tInflowRunoff)

            If (mInflowRunoffPanelGraph IsNot Nothing) Then
                mInflowRunoffPanelGraph.Dispose()
                mInflowRunoffPanelGraph = Nothing
            End If
            mInflowRunoffPanelGraph = GetNew2dGraphPanel(_dataSet, tInflowRunoff)
            mInflowRunoffPanelGraph.UnitsX = UnitsDefinition.Units.Seconds
            mInflowRunoffPanelGraph.UnitsY = UnitsDefinition.Units.Cms
            mInflowRunoffPanelGraph.DisplayKey = True
            '
            ' Advance curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tAdvance)

            If (mAdvancePageGraph IsNot Nothing) Then
                mAdvancePageGraph.Dispose()
                mAdvancePageGraph = Nothing
            End If
            mAdvancePageGraph = GetNew2dGraphPage(_dataSet, tAdvance)
            mAdvancePageGraph.UnitsX = UnitsDefinition.Units.Meters
            mAdvancePageGraph.UnitsY = UnitsDefinition.Units.Seconds
            mAdvancePageGraph.MinX = 0.0
            mAdvancePageGraph.MinY = 0.0
            mAdvancePageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tAdvance)

            If (mAdvancePanelGraph IsNot Nothing) Then
                mAdvancePanelGraph.Dispose()
                mAdvancePanelGraph = Nothing
            End If
            mAdvancePanelGraph = GetNew2dGraphPanel(_dataSet, tAdvance)
            mAdvancePanelGraph.UnitsX = UnitsDefinition.Units.Meters
            mAdvancePanelGraph.UnitsY = UnitsDefinition.Units.Seconds
            mAdvancePanelGraph.MinX = 0.0
            mAdvancePanelGraph.MinY = 0.0
            mAdvancePanelGraph.DisplayKey = True
            '
            ' Advance / Recession curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tAdvanceRecession)

            If (mAdvanceRecessionPageGraph IsNot Nothing) Then
                mAdvanceRecessionPageGraph.Dispose()
                mAdvanceRecessionPageGraph = Nothing
            End If
            mAdvanceRecessionPageGraph = GetNew2dGraphPage(_dataSet, tAdvanceRecession)
            mAdvanceRecessionPageGraph.UnitsX = UnitsDefinition.Units.Meters
            mAdvanceRecessionPageGraph.UnitsY = UnitsDefinition.Units.Seconds
            mAdvanceRecessionPageGraph.MinX = 0.0
            mAdvanceRecessionPageGraph.MinY = 0.0
            mAdvanceRecessionPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tAdvanceRecession)

            If (mAdvanceRecessionPanelGraph IsNot Nothing) Then
                mAdvanceRecessionPanelGraph.Dispose()
                mAdvanceRecessionPanelGraph = Nothing
            End If
            mAdvanceRecessionPanelGraph = GetNew2dGraphPanel(_dataSet, tAdvanceRecession)
            mAdvanceRecessionPanelGraph.UnitsX = UnitsDefinition.Units.Meters
            mAdvanceRecessionPanelGraph.UnitsY = UnitsDefinition.Units.Seconds
            mAdvanceRecessionPanelGraph.MinX = 0.0
            mAdvanceRecessionPanelGraph.MinY = 0.0
            mAdvanceRecessionPanelGraph.DisplayKey = True
            '
            ' Volume Balance vs. Time curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tInfiltration)

            If (mVolumeBalanceVsTimePageGraph IsNot Nothing) Then
                mVolumeBalanceVsTimePageGraph.Dispose()
                mVolumeBalanceVsTimePageGraph = Nothing
            End If
            mVolumeBalanceVsTimePageGraph = GetNew2dGraphPage(_dataSet, tInfiltration)
            mVolumeBalanceVsTimePageGraph.UnitsX = UnitsDefinition.Units.Seconds
            mVolumeBalanceVsTimePageGraph.UnitsY = UnitsDefinition.Units.CubicMeters
            mVolumeBalanceVsTimePageGraph.MinX = 0.0
            mVolumeBalanceVsTimePageGraph.MinY = 0.0
            mVolumeBalanceVsTimePageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tInfiltration)

            If (mVolumeBalanceVsTimePanelGraph IsNot Nothing) Then
                mVolumeBalanceVsTimePanelGraph.Dispose()
                mVolumeBalanceVsTimePanelGraph = Nothing
            End If
            mVolumeBalanceVsTimePanelGraph = GetNew2dGraphPanel(_dataSet, tInfiltration)
            mVolumeBalanceVsTimePanelGraph.UnitsX = UnitsDefinition.Units.Seconds
            mVolumeBalanceVsTimePanelGraph.UnitsY = UnitsDefinition.Units.CubicMeters
            mVolumeBalanceVsTimePanelGraph.MinX = 0.0
            mVolumeBalanceVsTimePanelGraph.MinY = 0.0
            mVolumeBalanceVsTimePanelGraph.DisplayKey = True
            '
            ' Volume Balance vs. Advance curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tInfiltration)

            If (mVolumeBalanceVsAdvPageGraph IsNot Nothing) Then
                mVolumeBalanceVsAdvPageGraph.Dispose()
                mVolumeBalanceVsAdvPageGraph = Nothing
            End If
            mVolumeBalanceVsAdvPageGraph = GetNew2dGraphPage(_dataSet, tInfiltration)
            mVolumeBalanceVsAdvPageGraph.UnitsX = UnitsDefinition.Units.Meters
            mVolumeBalanceVsAdvPageGraph.UnitsY = UnitsDefinition.Units.CubicMeters
            mVolumeBalanceVsAdvPageGraph.MinX = 0.0
            mVolumeBalanceVsAdvPageGraph.MinY = 0.0
            mVolumeBalanceVsAdvPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tInfiltration)

            If (mVolumeBalanceVsAdvPanelGraph IsNot Nothing) Then
                mVolumeBalanceVsAdvPanelGraph.Dispose()
                mVolumeBalanceVsAdvPanelGraph = Nothing
            End If
            mVolumeBalanceVsAdvPanelGraph = GetNew2dGraphPanel(_dataSet, tInfiltration)
            mVolumeBalanceVsAdvPanelGraph.UnitsX = UnitsDefinition.Units.Meters
            mVolumeBalanceVsAdvPanelGraph.UnitsY = UnitsDefinition.Units.CubicMeters
            mVolumeBalanceVsAdvPanelGraph.MinX = 0.0
            mVolumeBalanceVsAdvPanelGraph.MinY = 0.0
            mVolumeBalanceVsAdvPanelGraph.DisplayKey = True
            '
            ' Infiltration curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tInfiltration)

            If (mInfiltrationPageGraph IsNot Nothing) Then
                mInfiltrationPageGraph.Dispose()
                mInfiltrationPageGraph = Nothing
            End If
            mInfiltrationPageGraph = GetNew2dGraphPage(_dataSet, tInfiltration)
            mInfiltrationPageGraph.UnitsX = UnitsDefinition.Units.Meters
            mInfiltrationPageGraph.UnitsY = UnitsDefinition.Units.Millimeters
            mInfiltrationPageGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
            mInfiltrationPageGraph.MinY = 0.0 ' Start Infiltration graph at top of soil
            mInfiltrationPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tInfiltration)

            If (mInfiltrationPanelGraph IsNot Nothing) Then
                mInfiltrationPanelGraph.Dispose()
                mInfiltrationPanelGraph = Nothing
            End If
            mInfiltrationPanelGraph = GetNew2dGraphPanel(_dataSet, tInfiltration)
            mInfiltrationPanelGraph.UnitsX = UnitsDefinition.Units.Meters
            mInfiltrationPanelGraph.UnitsY = UnitsDefinition.Units.Millimeters
            mInfiltrationPanelGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
            mInfiltrationPanelGraph.MinY = 0.0 ' Start Infiltration graph at top of soil
            mInfiltrationPanelGraph.DisplayKey = True
            '
            ' Upstsream Infiltration curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tUpstreamInfiltrationDepth)

            If (mUpstreamInfiltrationPageGraph IsNot Nothing) Then
                mUpstreamInfiltrationPageGraph.Dispose()
                mUpstreamInfiltrationPageGraph = Nothing
            End If
            mUpstreamInfiltrationPageGraph = GetNew2dGraphPage(_dataSet, tUpstreamInfiltrationDepth)
            mUpstreamInfiltrationPageGraph.UnitsX = UnitsDefinition.Units.Seconds
            mUpstreamInfiltrationPageGraph.UnitsY = UnitsDefinition.Units.Millimeters
            mUpstreamInfiltrationPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tUpstreamInfiltrationDepth)

            If (mUpstreamInfiltrationPanelGraph IsNot Nothing) Then
                mUpstreamInfiltrationPanelGraph.Dispose()
                mUpstreamInfiltrationPanelGraph = Nothing
            End If
            mUpstreamInfiltrationPanelGraph = GetNew2dGraphPanel(_dataSet, tUpstreamInfiltrationDepth)
            mUpstreamInfiltrationPanelGraph.UnitsX = UnitsDefinition.Units.Seconds
            mUpstreamInfiltrationPanelGraph.UnitsY = UnitsDefinition.Units.Millimeters
            mUpstreamInfiltrationPanelGraph.DisplayKey = True
            '
            ' Infiltration Function curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tInfiltrationFunction)

            If (mInfiltrationFunctionPageGraph IsNot Nothing) Then
                mInfiltrationFunctionPageGraph.Dispose()
                mInfiltrationFunctionPageGraph = Nothing
            End If
            mInfiltrationFunctionPageGraph = GetNew2dGraphPage(_dataSet, tInfiltrationFunction)
            mInfiltrationFunctionPageGraph.UnitsX = UnitsDefinition.Units.Seconds
            mInfiltrationFunctionPageGraph.UnitsY = UnitsDefinition.Units.SquareMeters
            mInfiltrationFunctionPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tInfiltrationFunction)

            If (mInfiltrationFunctionPanelGraph IsNot Nothing) Then
                mInfiltrationFunctionPanelGraph.Dispose()
                mInfiltrationFunctionPanelGraph = Nothing
            End If
            mInfiltrationFunctionPanelGraph = GetNew2dGraphPanel(_dataSet, tInfiltrationFunction)
            mInfiltrationFunctionPanelGraph.UnitsX = UnitsDefinition.Units.Seconds
            mInfiltrationFunctionPanelGraph.UnitsY = UnitsDefinition.Units.SquareMeters
            mInfiltrationFunctionPanelGraph.DisplayKey = True
            '
            ' Infiltration Depth Function curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(tInfiltrationDepthFunction)

            If (mInfiltrationDepthFunctionPageGraph IsNot Nothing) Then
                mInfiltrationDepthFunctionPageGraph.Dispose()
                mInfiltrationDepthFunctionPageGraph = Nothing
            End If
            mInfiltrationDepthFunctionPageGraph = GetNew2dGraphPage(_dataSet, tInfiltrationDepthFunction)
            mInfiltrationDepthFunctionPageGraph.UnitsX = UnitsDefinition.Units.Seconds
            mInfiltrationDepthFunctionPageGraph.UnitsY = UnitsDefinition.Units.Millimeters
            mInfiltrationDepthFunctionPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(tInfiltrationDepthFunction)

            If (mInfiltrationDepthFunctionPanelGraph IsNot Nothing) Then
                mInfiltrationDepthFunctionPanelGraph.Dispose()
                mInfiltrationDepthFunctionPanelGraph = Nothing
            End If
            mInfiltrationDepthFunctionPanelGraph = GetNew2dGraphPanel(_dataSet, tInfiltrationDepthFunction)
            mInfiltrationDepthFunctionPanelGraph.UnitsX = UnitsDefinition.Units.Seconds
            mInfiltrationDepthFunctionPanelGraph.UnitsY = UnitsDefinition.Units.Millimeters
            mInfiltrationDepthFunctionPanelGraph.DisplayKey = True
            '
            ' Erosion G curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(sErosionG)

            If (mErosionGPageGraph IsNot Nothing) Then
                mErosionGPageGraph.Dispose()
                mErosionGPageGraph = Nothing
            End If
            mErosionGPageGraph = GetNew2dGraphPage(_dataSet, sErosionG)
            mErosionGPageGraph.UnitsX = UnitsDefinition.Units.Seconds
            mErosionGPageGraph.UnitsY = UnitsDefinition.Units.KilogramsPerSecond
            mErosionGPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(sErosionG)

            If (mErosionGPanelGraph IsNot Nothing) Then
                mErosionGPanelGraph.Dispose()
                mErosionGPanelGraph = Nothing
            End If
            mErosionGPanelGraph = GetNew2dGraphPanel(_dataSet, sErosionG)
            mErosionGPanelGraph.UnitsX = UnitsDefinition.Units.Seconds
            mErosionGPanelGraph.UnitsY = UnitsDefinition.Units.KilogramsPerSecond
            mErosionGPanelGraph.DisplayKey = True
            '
            ' Erosion CGm curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(sErosionCGm)

            If (mErosionCGmPageGraph IsNot Nothing) Then
                mErosionCGmPageGraph.Dispose()
                mErosionCGmPageGraph = Nothing
            End If
            mErosionCGmPageGraph = GetNew2dGraphPage(_dataSet, sErosionCGm)
            mErosionCGmPageGraph.UnitsX = UnitsDefinition.Units.Seconds
            mErosionCGmPageGraph.UnitsY = UnitsDefinition.Units.GramsPerLiter
            mErosionCGmPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(sErosionCGm)

            If (mErosionCGmPanelGraph IsNot Nothing) Then
                mErosionCGmPanelGraph.Dispose()
                mErosionCGmPanelGraph = Nothing
            End If
            mErosionCGmPanelGraph = GetNew2dGraphPanel(_dataSet, sErosionCGm)
            mErosionCGmPanelGraph.UnitsX = UnitsDefinition.Units.Seconds
            mErosionCGmPanelGraph.UnitsY = UnitsDefinition.Units.GramsPerLiter
            mErosionCGmPanelGraph.DisplayKey = True
            '
            ' Erosion CGv curve
            '

            ' Full Page view for Display, Print & Print Preview
            _dataSet = New DataSet(sErosionCGv)

            If (mErosionCGvPageGraph IsNot Nothing) Then
                mErosionCGvPageGraph.Dispose()
                mErosionCGvPageGraph = Nothing
            End If
            mErosionCGvPageGraph = GetNew2dGraphPage(_dataSet, sErosionCGv)
            mErosionCGvPageGraph.UnitsX = UnitsDefinition.Units.Seconds
            mErosionCGvPageGraph.UnitsY = UnitsDefinition.Units.LitersPerLiter
            mErosionCGvPageGraph.DisplayKey = True

            ' Graphic Only view for Display
            _dataSet = New DataSet(sErosionCGv)

            If (mErosionCGvPanelGraph IsNot Nothing) Then
                mErosionCGvPanelGraph.Dispose()
                mErosionCGvPanelGraph = Nothing
            End If
            mErosionCGvPanelGraph = GetNew2dGraphPanel(_dataSet, sErosionCGv)
            mErosionCGvPanelGraph.UnitsX = UnitsDefinition.Units.Seconds
            mErosionCGvPanelGraph.UnitsY = UnitsDefinition.Units.LitersPerLiter
            mErosionCGvPanelGraph.DisplayKey = True

            UpdateUI()

            mUpdatingTabPages = False
        End If

    End Sub

    Protected Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        If (mWinSRFR IsNot Nothing) Then
            UpdatePerformanceIndicatorsPages()
            UpdateGoodnessOfFitPages()
        End If
    End Sub

#End Region

#Region " Methods "

#Region " Selection Methods "

    Public Sub ResetTabPages(ByVal selections As Integer, ByVal erosionCurveNo As Integer)

        Dim tInflow As String = mDictionary.tInflow.Translated
        Dim tInflowRunoff As String = tInflow & "/ " & mDictionary.tRunoff.Translated
        Dim tAdvance As String = mDictionary.tAdvance.Translated
        Dim tAdvanceRecession As String = tAdvance & " / " & mDictionary.tRecession.Translated
        Dim tVolumeBalanceInfiltration As String = mDictionary.tVolumeBalanceInfiltration.Translated
        Dim tInfiltration As String = mDictionary.tInfiltration.Translated
        Dim tInfiltrationFunction As String = mDictionary.tInfiltrationFunction.Translated
        Dim tInfiltrationDepthFunction As String = mDictionary.tInfiltrationDepthFunction.Translated
        Dim tUpstreamInfiltration As String = mDictionary.tUpstreamInfiltration.Translated
        Dim tUpstreamInfiltrationDepth As String = mDictionary.tUpstreamInfiltrationDepth.Translated
        '
        ' Update erosion curve being displayed, if necessary
        '
        If Not (mErosionCurveNo = erosionCurveNo) Then
            mErosionCurveNo = erosionCurveNo

            ' Remove currently displayed erosion curves
            mErosionGPageGraph.RemoveAllData()
            mErosionCGmPageGraph.RemoveAllData()
            mErosionCGvPageGraph.RemoveAllData()
            mErosionGPanelGraph.RemoveAllData()
            mErosionCGmPanelGraph.RemoveAllData()
            mErosionCGvPanelGraph.RemoveAllData()

            ' Add newly selected erosion curves
            For Each _unit As Unit In mUnits
                Dim _name As String = ComparisonName(_unit)
                AddErosionTabs(_unit, _name)
            Next
        End If
        '
        ' Update displayed comparison tabs
        '
        mDataComparisonType = selections

        ' Clear the current tab pages
        mUpdatingTabPages = True

        Me.TabPages.Clear()
        '
        ' Recover memory used by Results Pages & Panels
        '
        For pdx As Integer = mResultsPages.Count - 1 To 0 Step -1
            Try
                ' Get Results Page at the end of the list
                Dim rpage As RtfPage = CType(mResultsPages(pdx), RtfPage)
                If (rpage IsNot Nothing) Then
                    ' First, clear its images
                    DisposeImages(rpage)
                    ' Then, remove & dispose of the Results Page
                    mResultsPages.RemoveAt(pdx)
                    RemoveHandler rpage.RtfCtrl.MouseWheel, AddressOf RtfCtrl_MouseWheel
                    For cdx As Integer = rpage.Controls.Count - 1 To 0 Step -1
                        Dim ctrl As Control = rpage.Controls(cdx)
                        If (ctrl.GetType Is GetType(grf_XYGraph)) Then
                            rpage.Controls.Remove(ctrl)
                            ctrl = Nothing
                        End If
                    Next cdx
                    rpage.Dispose()
                    rpage = Nothing
                End If
            Catch ex As Exception
            End Try
        Next

        mResultsPages.Clear()

        For pdx As Integer = mResultsPanels.Count - 1 To 0 Step -1
            Try
                ' Get Results Panel at the end of the list
                Dim rpanel As Panel = CType(mResultsPanels(pdx), Panel)
                If (rpanel IsNot Nothing) Then
                    ' First, clear its images
                    DisposeImages(rpanel)
                    ' Then, remove & dispose of the Results Panel
                    mResultsPanels.RemoveAt(pdx)
                    RemoveHandler rpanel.Paint, AddressOf Panel_Paint2DGraph
                    For cdx As Integer = rpanel.Controls.Count - 1 To 0 Step -1
                        Dim ctrl As Control = rpanel.Controls(cdx)
                        If (ctrl.GetType Is GetType(grf_XYGraph)) Then
                            rpanel.Controls.Remove(ctrl)
                            ctrl = Nothing
                        End If
                    Next cdx
                    rpanel.Dispose()
                    rpanel = Nothing
                End If
            Catch ex As Exception
            End Try
        Next

        mResultsPanels.Clear()

        ' Reset the page numbering
        mPageNumber = 0
        mTotalPages = 0

        ' One page for each curve parameter
        Dim _bitMask As Integer = 1
        While (_bitMask < DataComparisonTypes.LastDataComparisonType)
            If ((selections And _bitMask) = _bitMask) Then
                mTotalPages += 1
            End If
            _bitMask *= 2
        End While

        ' One page for each 4 Units for Performance Indicators table
        If (UnitsPerPage < mUnits.Count) Then
            If ((selections And DataComparisonTypes.PerformanceIndicators) = DataComparisonTypes.PerformanceIndicators) Then
                mTotalPages += Math.Floor(mUnits.Count / UnitsPerPage)
            End If
        End If

        ' One page for each Goodness of Fit set
        If ((selections And DataComparisonTypes.GoodnessOfFit) = DataComparisonTypes.GoodnessOfFit) Then
            If (mUnits.Count < 2) Then
                mTotalPages -= 1
            Else
                mTotalPages += mUnits.Count - 2
            End If
        End If
        '
        ' Add selected pages
        '

        ' Inflow curve
        If ((selections And DataComparisonTypes.InflowGraph) = DataComparisonTypes.InflowGraph) Then
            AddResultsPage(tInflow, mInflowPageGraph)
            AddResultsPanel(tInflow, mInflowPanelGraph)
        End If

        ' Inflow / Runoff curve
        If ((selections And DataComparisonTypes.InflowRunoffGraph) = DataComparisonTypes.InflowRunoffGraph) Then
            AddResultsPage(tInflowRunoff, mInflowRunoffPageGraph)
            AddResultsPanel(tInflowRunoff, mInflowRunoffPanelGraph)
        End If

        ' Advance curve
        If ((selections And DataComparisonTypes.AdvanceGraph) = DataComparisonTypes.AdvanceGraph) Then
            AddResultsPage(tAdvance, mAdvancePageGraph)
            AddResultsPanel(tAdvance, mAdvancePanelGraph)
        End If

        ' Advance / Recession curve
        If ((selections And DataComparisonTypes.AdvanceRecessionGraph) = DataComparisonTypes.AdvanceRecessionGraph) Then
            AddResultsPage(tAdvanceRecession, mAdvanceRecessionPageGraph)
            AddResultsPanel(tAdvanceRecession, mAdvanceRecessionPanelGraph)
        End If

        ' Volume Balance curve
        If ((selections And DataComparisonTypes.VolumeBalance) = DataComparisonTypes.VolumeBalance) Then
            If ((selections And DataComparisonTypes.VsAdvance) = DataComparisonTypes.VsAdvance) Then
                AddResultsPage(tVolumeBalanceInfiltration, mVolumeBalanceVsAdvPageGraph)
                AddResultsPanel(tVolumeBalanceInfiltration, mVolumeBalanceVsAdvPanelGraph)
            Else
                AddResultsPage(tVolumeBalanceInfiltration, mVolumeBalanceVsTimePageGraph)
                AddResultsPanel(tVolumeBalanceInfiltration, mVolumeBalanceVsTimePanelGraph)
            End If
        End If

        ' Infiltration curve
        If ((selections And DataComparisonTypes.InfiltrationGraph) = DataComparisonTypes.InfiltrationGraph) Then
            AddResultsPage(tInfiltration, mInfiltrationPageGraph)
            AddResultsPanel(tInfiltration, mInfiltrationPanelGraph)
        End If

        ' Infiltration Function curve
        If ((selections And DataComparisonTypes.InfiltrationFunctionGraph) = DataComparisonTypes.InfiltrationFunctionGraph) Then
            AddResultsPage(tInfiltrationFunction, mInfiltrationFunctionPageGraph)
            AddResultsPanel(tInfiltrationFunction, mInfiltrationFunctionPanelGraph)
        End If

        ' Infiltration Depth Function curve
        If ((selections And DataComparisonTypes.InfiltrationFunctionGraph) = DataComparisonTypes.InfiltrationFunctionGraph) Then
            AddResultsPage(tInfiltrationDepthFunction, mInfiltrationDepthFunctionPageGraph)
            AddResultsPanel(tInfiltrationDepthFunction, mInfiltrationDepthFunctionPanelGraph)
        End If

        ' Upstream Infiltration curve
        If ((selections And DataComparisonTypes.UpstreamInfiltrationGraph) = DataComparisonTypes.UpstreamInfiltrationGraph) Then
            AddResultsPage(tUpstreamInfiltration, mUpstreamInfiltrationPageGraph)
            AddResultsPanel(tUpstreamInfiltration, mUpstreamInfiltrationPanelGraph)
        End If

        ' Erosion G curve
        If ((selections And DataComparisonTypes.ErosionGGraph) = DataComparisonTypes.ErosionGGraph) Then
            AddResultsPage(sErosionG, mErosionGPageGraph)
            AddResultsPanel(sErosionG, mErosionGPanelGraph)
        End If

        ' Erosion CGm curve
        If ((selections And DataComparisonTypes.ErosionCGmGraph) = DataComparisonTypes.ErosionCGmGraph) Then
            AddResultsPage(sErosionCGm, mErosionCGmPageGraph)
            AddResultsPanel(sErosionCGm, mErosionCGmPanelGraph)
        End If

        ' Erosion CGv curve
        If ((selections And DataComparisonTypes.ErosionCGvGraph) = DataComparisonTypes.ErosionCGvGraph) Then
            AddResultsPage(sErosionCGv, mErosionCGvPageGraph)
            AddResultsPanel(sErosionCGv, mErosionCGvPanelGraph)
        End If

        If (Me.TabPages.Count - 1 < mSelectedIndex) Then
            mSelectedIndex = 0
        End If

        ' Performance Indicators
        If ((selections And DataComparisonTypes.PerformanceIndicators) = DataComparisonTypes.PerformanceIndicators) Then
            AddPerformanceIndicatorsPages(mDictionary.tPerformanceIndicators.Translated, mDictionary.tIndicators.Translated)
        End If

        ' Goodness of Fit
        If ((selections And DataComparisonTypes.GoodnessOfFit) = DataComparisonTypes.GoodnessOfFit) Then
            AddGoodnessOfFitPages(mDictionary.tGoodnessOfFit.Translated, mDictionary.tGoodness.Translated)
        End If

        Me.SelectedIndex = mSelectedIndex
        mUpdatingTabPages = False

        ' Refresh UI so all keys are visible
        Me.Refresh()

    End Sub

    Private Function ComparisonName(ByVal _unit As Unit) As String
        Dim _name As String = String.Empty

        If Not (_unit Is Nothing) Then
            Dim _world As World = _unit.WorldRef
            Dim _field As Field = _world.FieldRef

            _name = _field.Name.Value + " - " _
                  + WorldsText(_world.WorldType.Value) + ":" + _world.Name.Value + " - " _
                  + _unit.Name.Value
        End If

        Return _name
    End Function

    Public Function AddUnit(ByVal _unit As Unit) As Boolean

        If (_unit Is Nothing) Then
            Return False
        End If
        '
        ' Performance Indicators are displayed from results stored in the Unit
        '
        ' WinSRFR versions prior to 3x did not store the Analysis results into the
        ' Unit.  To correct this, the 3x version of the Analysis must be run.
        '
        Dim _runOK As Boolean = False

        Dim _productName As String = _unit.MyStore.FindPropertyPath(UnitControl.sProductName)
        If Not (_productName Is Nothing) Then
            ' Verify WinSRFR ran this Analysis (might have been wSRFR)
            _productName = _unit.UnitControlRef.ProductName.Value
            If (_productName = Application.ProductName) Then
                ' WinSRFR run analysis; check version
                Dim _productVersion As String = _unit.MyStore.FindPropertyPath(UnitControl.sProductVersion)
                If Not (_productVersion Is Nothing) Then
                    ' Verify correct version of WinSRFR ran this Analysis
                    _productVersion = _unit.UnitControlRef.ProductVersion.Value
                    If ("3.0.0" <= _productVersion) Then
                        ' Current enough version run for this Analysis
                        _runOK = True
                    End If
                End If
            End If
        End If

        If Not (_runOK) Then
            Dim _title As String = mDictionary.tDataComparisonError.Translated
            Dim _message As String = mDictionary.tErrAnalysisFromOlderWinSrfrVersion.Translated _
                     & Chr(13) _
                     & Chr(13) & mDictionary.tErrToCorrectlyDisplayComparisonResultsItMustBeRerun.Translated

            MsgBox(_message, MsgBoxStyle.Exclamation, _title)

            Return False
        End If
        '
        ' Add the Unit to the list of Units to compare
        '
        If (mUnits.IndexOf(_unit) < 0) Then
            mUnits.Add(_unit)

            Dim _name As String = ComparisonName(_unit)

            Dim tAdvance As String = mDictionary.tAdvance.Translated
            Dim tDistance As String = mDictionary.tDistance.Translated
            Dim tTime As String = mDictionary.tTime.Translated
            Dim tInflowRate As String = mDictionary.tInflowRate.Translated
            Dim tInfiltration As String = mDictionary.tInfiltration.Translated
            Dim tUpstreamInfiltration As String = mDictionary.tUpstreamInfiltration.Translated

            Dim _dataTable As DataTable
            Dim _dataSet As DataSet
            '
            '**************
            ' Inflow curve
            '**************
            '
            ' Is Inflow available as a result?
            _dataTable = _unit.SurfaceFlowRef.InflowTable

            If ((DataTableHasData(_dataTable)) _
            And (Not (_unit.UnitType.Value = WorldTypes.EventWorld))) Then
                ' Yes, use it
                _dataTable.TableName = _name
                _dataTable.Columns(0).ColumnName = tTime
                _dataTable.Columns(1).ColumnName = tInflowRate
                AddExtendedProperty(_dataTable, "Key", True)
                mInflowPageGraph.AddData(_dataTable)
                mInflowPanelGraph.AddData(_dataTable.Copy)
            Else
                ' No, is Inflow available as an input?
                Select Case _unit.InflowManagementRef.InflowMethod.Value
                    Case InflowMethods.StandardHydrograph

                        ' Get Standard Hydrograph in tabulated form
                        _dataTable = _unit.InflowManagementRef.HydrographInflowTable

                        If (DataTableHasData(_dataTable)) Then
                            _dataTable.TableName = _name
                            _dataTable.Columns(0).ColumnName = tTime
                            _dataTable.Columns(1).ColumnName = tInflowRate
                            AddExtendedProperty(_dataTable, "Key", True)
                            mInflowPageGraph.AddData(_dataTable)
                            mInflowPanelGraph.AddData(_dataTable.Copy)
                        Else
                            mInflowPageGraph.AddNullData(_name, True)
                            mInflowPanelGraph.AddNullData(_name, True)
                        End If

                    Case InflowMethods.Cablegation

                        ' Check if Cablegation Inflow is available
                        _dataTable = _unit.InflowManagementRef.CablegationInflowTable

                        If (DataTableHasData(_dataTable)) Then
                            _dataTable.TableName = _name
                            _dataTable.Columns(0).ColumnName = tTime
                            _dataTable.Columns(1).ColumnName = tInflowRate
                            AddExtendedProperty(_dataTable, "Key", True)
                            mInflowPageGraph.AddData(_dataTable)
                            mInflowPanelGraph.AddData(_dataTable.Copy)
                        Else
                            mInflowPageGraph.AddNullData(_name, True)
                            mInflowPanelGraph.AddNullData(_name, True)
                        End If

                    Case InflowMethods.TabulatedInflow

                        ' Check if Tabulated Inflow is available
                        _dataTable = _unit.InflowManagementRef.TabulatedInflow.Value

                        If (DataTableHasData(_dataTable)) Then
                            _dataTable.TableName = _name
                            _dataTable.Columns(0).ColumnName = tTime
                            _dataTable.Columns(1).ColumnName = tInflowRate
                            AddExtendedProperty(_dataTable, "Key", True)
                            AddExtendedProperty(_dataTable, "Symbol", "X")
                            AddExtendedProperty(_dataTable, "Line", True)
                            mInflowPageGraph.AddData(_dataTable)
                            mInflowPanelGraph.AddData(_dataTable.Copy)
                        Else
                            mInflowPageGraph.AddNullData(_name, True)
                            mInflowPanelGraph.AddNullData(_name, True)
                        End If

                    Case Else
                        Debug.Assert(False) ' Support for this Inflow Method must be added
                End Select
            End If
            '
            '***********************
            ' Inflow / Runoff curve
            '***********************
            '
            ' Inflow
            '
            ' Is Inflow available as a result?
            _dataTable = _unit.SurfaceFlowRef.InflowTable

            If ((DataTableHasData(_dataTable)) _
            And (Not (_unit.UnitType.Value = WorldTypes.EventWorld))) Then
                ' Yes, use it
                _dataTable.TableName = _name
                _dataTable.Columns(0).ColumnName = tTime
                _dataTable.Columns(1).ColumnName = tInflowRate
                AddExtendedProperty(_dataTable, "Key", True)
                mInflowRunoffPageGraph.AddData(_dataTable)
                mInflowRunoffPanelGraph.AddData(_dataTable.Copy)
            Else
                ' No, is Inflow available as an input?
                Select Case _unit.InflowManagementRef.InflowMethod.Value
                    Case InflowMethods.StandardHydrograph

                        ' Get Standard Hydrograph in tabulated form
                        _dataTable = _unit.InflowManagementRef.HydrographInflowTable

                        If (DataTableHasData(_dataTable)) Then
                            _dataTable.TableName = _name
                            _dataTable.Columns(0).ColumnName = tTime
                            _dataTable.Columns(1).ColumnName = tInflowRate
                            AddExtendedProperty(_dataTable, "Key", True)
                            mInflowRunoffPageGraph.AddData(_dataTable)
                            mInflowRunoffPanelGraph.AddData(_dataTable.Copy)
                        Else
                            mInflowRunoffPageGraph.AddNullData(_name, True)
                            mInflowRunoffPanelGraph.AddNullData(_name, True)
                        End If

                    Case InflowMethods.Cablegation

                        ' Check if Cablegation Inflow is available
                        _dataTable = _unit.InflowManagementRef.CablegationInflowTable

                        If (DataTableHasData(_dataTable)) Then
                            _dataTable.TableName = _name
                            _dataTable.Columns(0).ColumnName = tTime
                            _dataTable.Columns(1).ColumnName = tInflowRate
                            AddExtendedProperty(_dataTable, "Key", True)
                            mInflowRunoffPageGraph.AddData(_dataTable)
                            mInflowRunoffPanelGraph.AddData(_dataTable.Copy)
                        Else
                            mInflowRunoffPageGraph.AddNullData(_name, True)
                            mInflowRunoffPanelGraph.AddNullData(_name, True)
                        End If

                    Case InflowMethods.TabulatedInflow

                        ' Check if Tabulated Inflow is available
                        _dataTable = _unit.InflowManagementRef.TabulatedInflow.Value

                        If (DataTableHasData(_dataTable)) Then
                            _dataTable.TableName = _name
                            _dataTable.Columns(0).ColumnName = tTime
                            _dataTable.Columns(1).ColumnName = tInflowRate
                            AddExtendedProperty(_dataTable, "Key", True)
                            AddExtendedProperty(_dataTable, "Symbol", "X")
                            AddExtendedProperty(_dataTable, "Line", True)
                            mInflowRunoffPageGraph.AddData(_dataTable)
                            mInflowRunoffPanelGraph.AddData(_dataTable.Copy)
                        Else
                            mInflowRunoffPageGraph.AddNullData(_name, True)
                            mInflowRunoffPanelGraph.AddNullData(_name, True)
                        End If

                    Case Else
                        Debug.Assert(False) ' Support for this Inflow Method must be added
                End Select
            End If
            '
            ' Runoff
            '
            ' Is Runoff available as a result?
            _dataTable = _unit.SurfaceFlowRef.RunoffTable

            If ((DataTableHasData(_dataTable)) _
            And (Not (_unit.UnitType.Value = WorldTypes.EventWorld))) Then
                ' Yes, use it
                _dataTable.TableName = _name + " "
                _dataTable.Columns(0).ColumnName = tTime
                _dataTable.Columns(1).ColumnName = tInflowRate
                mInflowRunoffPageGraph.AddData(_dataTable)
                mInflowRunoffPanelGraph.AddData(_dataTable.Copy)
            Else
                ' No, is Runoff available as an input?
                _dataTable = _unit.InflowManagementRef.RunoffTableForCrossSection

                If (DataTableHasData(_dataTable)) Then
                    _dataTable.TableName = _name + " "
                    _dataTable.Columns(0).ColumnName = tTime
                    _dataTable.Columns(1).ColumnName = tInflowRate
                    AddExtendedProperty(_dataTable, "Symbol", "X")
                    AddExtendedProperty(_dataTable, "Line", True)
                    mInflowRunoffPageGraph.AddData(_dataTable)
                    mInflowRunoffPanelGraph.AddData(_dataTable.Copy)
                End If
            End If
            '
            '***************
            ' Advance curve
            '***************
            '
            ' Is Advance available as a result?
            _dataTable = _unit.SurfaceFlowRef.Advance.Value
            _dataSet = _unit.SurfaceFlowRef.AdvanceSet.Value

            If ((DataTableHasData(_dataTable)) _
            And (Not (_unit.UnitType.Value = WorldTypes.EventWorld))) Then
                ' Yes, use it
                If (DataSetHasData(_dataSet)) Then
                    Dim suffix As String = String.Empty

                    For Each advTable As DataTable In _dataSet.Tables
                        _dataTable = advTable.Copy

                        If (suffix = String.Empty) Then
                            _dataTable.TableName = _name
                            AddExtendedProperty(_dataTable, "Key", True)
                        Else
                            _dataTable.TableName = _name & suffix
                        End If

                        _dataTable.Columns(0).ColumnName = tDistance
                        _dataTable.Columns(1).ColumnName = tTime

                        mAdvancePageGraph.AddData(_dataTable)
                        mAdvancePanelGraph.AddData(_dataTable.Copy)

                        suffix &= " "
                    Next

                Else
                    _dataTable.TableName = _name
                    _dataTable.Columns(0).ColumnName = tDistance
                    _dataTable.Columns(1).ColumnName = tTime
                    AddExtendedProperty(_dataTable, "Key", True)
                    mAdvancePageGraph.AddData(_dataTable)
                    mAdvancePanelGraph.AddData(_dataTable.Copy)
                End If
            Else
                ' No, is Advance available as an input?
                _dataTable = Nothing
                If (_unit.UnitType.Value = WorldTypes.EventWorld) Then ' check if 2-point advance
                    If (_unit.EventCriteriaRef.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                        _dataTable = _unit.InflowManagementRef.TwoPointTabulatedAdvance.Value
                    End If
                End If

                If (_dataTable Is Nothing) Then ' not 2-point advance; check Tabulated Advance
                    _dataTable = _unit.InflowManagementRef.TabulatedAdvance.Value
                End If

                If (DataTableHasData(_dataTable)) Then
                    _dataTable.TableName = _name
                    _dataTable.Columns(0).ColumnName = tDistance
                    _dataTable.Columns(1).ColumnName = tTime
                    AddExtendedProperty(_dataTable, "Key", True)
                    AddExtendedProperty(_dataTable, "Symbol", "X")
                    AddExtendedProperty(_dataTable, "Line", True)
                    mAdvancePageGraph.AddData(_dataTable)
                    mAdvancePanelGraph.AddData(_dataTable.Copy)
                Else
                    mAdvancePageGraph.AddNullData(_name, True)
                    mAdvancePanelGraph.AddNullData(_name, True)
                End If
            End If

            mAdvancePageGraph.MaxX = _unit.SystemGeometryRef.Length.Value
            mAdvancePanelGraph.MaxX = _unit.SystemGeometryRef.Length.Value
            '
            '***************************
            ' Advance / Recession curve
            '***************************
            '
            ' Advance
            '
            ' Is Advance available as a result?
            _dataTable = _unit.SurfaceFlowRef.Advance.Value
            _dataSet = _unit.SurfaceFlowRef.AdvanceSet.Value

            If ((DataTableHasData(_dataTable)) _
            And (Not (_unit.UnitType.Value = WorldTypes.EventWorld))) Then
                If (DataSetHasData(_dataSet)) Then
                    Dim suffix As String = String.Empty

                    For Each advTable As DataTable In _dataSet.Tables
                        _dataTable = advTable.Copy

                        If (suffix = String.Empty) Then
                            _dataTable.TableName = _name
                            AddExtendedProperty(_dataTable, "Key", True)
                        Else
                            _dataTable.TableName = _name & suffix
                        End If

                        _dataTable.Columns(0).ColumnName = tDistance
                        _dataTable.Columns(1).ColumnName = tTime

                        mAdvanceRecessionPageGraph.AddData(_dataTable)
                        mAdvanceRecessionPanelGraph.AddData(_dataTable.Copy)

                        suffix &= " "
                    Next

                Else
                    _dataTable.TableName = _name
                    _dataTable.Columns(0).ColumnName = tDistance
                    _dataTable.Columns(1).ColumnName = tTime
                    AddExtendedProperty(_dataTable, "Key", True)
                    mAdvanceRecessionPageGraph.AddData(_dataTable)
                    mAdvanceRecessionPanelGraph.AddData(_dataTable.Copy)
                End If
            Else
                ' No, is Advance available as an input?
                _dataTable = Nothing
                If (_unit.UnitType.Value = WorldTypes.EventWorld) Then ' check if 2-point advance
                    If (_unit.EventCriteriaRef.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                        _dataTable = _unit.InflowManagementRef.TwoPointTabulatedAdvance.Value
                    End If
                End If

                If (_dataTable Is Nothing) Then ' not 2-point advance; check Tabulated Advance
                    _dataTable = _unit.InflowManagementRef.TabulatedAdvance.Value
                End If

                If (DataTableHasData(_dataTable)) Then
                    _dataTable.TableName = _name
                    _dataTable.Columns(0).ColumnName = tDistance
                    _dataTable.Columns(1).ColumnName = tTime
                    AddExtendedProperty(_dataTable, "Key", True)
                    AddExtendedProperty(_dataTable, "Symbol", "X")
                    AddExtendedProperty(_dataTable, "Line", True)
                    mAdvanceRecessionPageGraph.AddData(_dataTable)
                    mAdvanceRecessionPanelGraph.AddData(_dataTable.Copy)
                Else
                    mAdvanceRecessionPageGraph.AddNullData(_name, True)
                    mAdvanceRecessionPanelGraph.AddNullData(_name, True)
                End If
            End If
            '
            ' Recession
            '
            ' Is Recession available as a result?
            _dataTable = _unit.SurfaceFlowRef.Recession.Value
            _dataSet = _unit.SurfaceFlowRef.RecessionSet.Value

            If ((DataTableHasData(_dataTable)) _
            And (Not (_unit.UnitType.Value = WorldTypes.EventWorld))) Then
                ' Yes, use it
                If (DataSetHasData(_dataSet)) Then
                    Dim suffix As String = String.Empty

                    For Each recTable As DataTable In _dataSet.Tables
                        _dataTable = recTable.Copy

                        _dataTable.TableName = _name & suffix
                        _dataTable.Columns(0).ColumnName = tDistance
                        _dataTable.Columns(1).ColumnName = tTime

                        mAdvanceRecessionPageGraph.AddData(_dataTable)
                        mAdvanceRecessionPanelGraph.AddData(_dataTable.Copy)

                        suffix &= " "
                    Next

                Else
                    _dataTable.TableName = _name
                    _dataTable.Columns(0).ColumnName = tDistance
                    _dataTable.Columns(1).ColumnName = tTime
                    mAdvanceRecessionPageGraph.AddData(_dataTable)
                    mAdvanceRecessionPanelGraph.AddData(_dataTable.Copy)
                End If
            Else
                ' No, is Recession available as an input?
                If Not (_unit.EventCriteriaRef.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                    If (_unit.InflowManagementRef.RecessionDataAvailable) Then
                        _dataTable = _unit.InflowManagementRef.TabulatedRecession.Value
                        _dataTable.TableName = _name + " "
                        _dataTable.Columns(0).ColumnName = tDistance
                        _dataTable.Columns(1).ColumnName = tTime
                        AddExtendedProperty(_dataTable, "Symbol", "X")
                        AddExtendedProperty(_dataTable, "Line", True)
                        mAdvanceRecessionPageGraph.AddData(_dataTable)
                        mAdvanceRecessionPanelGraph.AddData(_dataTable.Copy)
                    End If
                End If
            End If

            mAdvanceRecessionPageGraph.MaxX = _unit.SystemGeometryRef.Length.Value
            mAdvanceRecessionPanelGraph.MaxX = _unit.SystemGeometryRef.Length.Value
            '
            '*******************************
            ' Volume Balance vs. Time curve
            '*******************************
            '
            ' Is Measured Volume Balance available?
            _dataTable = _unit.EventCriteriaRef.MeasVzInfiltration.Value

            If (DataTableHasData(_dataTable)) Then
                ' Yes, use it
                _dataTable.TableName = _name
                _dataTable.Columns(0).ColumnName = tTime
                _dataTable.Columns(1).ColumnName = "Vz"
                AddExtendedProperty(_dataTable, "Key", True)
                AddExtendedProperty(_dataTable, "Symbol", "o")
                AddExtendedProperty(_dataTable, "Line", True)
                mVolumeBalanceVsTimePageGraph.AddData(_dataTable)
                mVolumeBalanceVsTimePanelGraph.AddData(_dataTable.Copy)
            End If
            '
            '**********************************
            ' Volume Balance vs. Advance curve
            '**********************************
            '
            ' Is Measured Volume Balance available?
            _dataTable = _unit.EventCriteriaRef.MeasVzInfiltration.Value

            If (DataTableHasData(_dataTable)) Then
                ' Yes, use it
                Dim _advance As DataTable = _unit.InflowManagementRef.TabulatedAdvance.Value
                If (DataTableHasData(_advance)) Then
                    Dim advCount As Integer = _advance.Rows.Count
                    Dim advRow As DataRow = _advance.Rows(advCount - 1)
                    Dim XadvMax As Double = advRow.Item(0)
                    Dim TadvMax As Double = advRow.Item(1)

                    Dim vdx As Integer = _dataTable.Rows.Count - 1
                    While (0 <= vdx)
                        Dim vzRow As DataRow = _dataTable.Rows(vdx)
                        Dim Tvz As Double = vzRow.Item(0)
                        If (Tvz <= TadvMax) Then
                            Dim Xvz As Double = DataColumnValue(_advance, 1, Tvz, 0)
                            vzRow.Item(0) = Xvz
                        Else
                            _dataTable.Rows.RemoveAt(vdx)
                        End If
                        vdx -= 1
                    End While

                    _dataTable.TableName = _name
                    _dataTable.Columns(0).ColumnName = tAdvance
                    _dataTable.Columns(1).ColumnName = "Vz"
                    AddExtendedProperty(_dataTable, "Key", True)
                    AddExtendedProperty(_dataTable, "Symbol", "o")
                    AddExtendedProperty(_dataTable, "Line", True)
                    mVolumeBalanceVsAdvPageGraph.AddData(_dataTable)
                    mVolumeBalanceVsAdvPanelGraph.AddData(_dataTable.Copy)
                End If
            End If
            '
            '********************
            ' Infiltration curve
            '********************
            '
            ' Is Infiltration available as a result?
            _dataTable = _unit.SubsurfaceFlowRef.LongitudinalInfiltration.Value

            If ((DataTableHasData(_dataTable)) _
            And (Not (_unit.UnitType.Value = WorldTypes.EventWorld))) Then
                ' Yes, use it
                _dataTable.TableName = _name
                _dataTable.Columns(0).ColumnName = tDistance
                _dataTable.Columns(1).ColumnName = tInfiltration
                AddExtendedProperty(_dataTable, "Key", True)
                mInfiltrationPageGraph.AddData(_dataTable)
                mInfiltrationPanelGraph.AddData(_dataTable.Copy)
            Else
                ' No, is Infiltration available as an input?
                _dataTable = _unit.SoilCropPropertiesRef.Infiltration.Value

                If (DataTableHasData(_dataTable)) Then
                    _dataTable.TableName = _name
                    _dataTable.Columns(0).ColumnName = tDistance
                    _dataTable.Columns(1).ColumnName = tInfiltration
                    AddExtendedProperty(_dataTable, "Key", True)
                    AddExtendedProperty(_dataTable, "Symbol", "X")
                    AddExtendedProperty(_dataTable, "Line", True)
                    mInfiltrationPageGraph.AddData(_dataTable)
                    mInfiltrationPanelGraph.AddData(_dataTable.Copy)
                Else
                    _dataTable = _unit.SoilCropPropertiesRef.UsefulInfiltrationTable

                    If (DataTableHasData(_dataTable)) Then
                        _dataTable.TableName = _name
                        _dataTable.Columns(0).ColumnName = tDistance
                        _dataTable.Columns(1).ColumnName = tInfiltration
                        AddExtendedProperty(_dataTable, "Key", True)
                        AddExtendedProperty(_dataTable, "Symbol", "X")
                        AddExtendedProperty(_dataTable, "Line", True)
                        mInfiltrationPageGraph.AddData(_dataTable)
                        mInfiltrationPanelGraph.AddData(_dataTable.Copy)
                    Else
                        mInfiltrationPageGraph.AddNullData(_name, True)
                        mInfiltrationPanelGraph.AddNullData(_name, True)
                    End If
                End If
            End If
            '
            '*******************************************
            ' Upstream Field Depth of Infiltration curve
            '*******************************************
            '
            ' Is Upstream Infiltration available as a result?
            _dataTable = _unit.SubsurfaceFlowRef.UpstreamInfiltrationDepthFunction.Value

            If (DataTableHasData(_dataTable)) Then
                ' Yes, use it
                _dataTable.TableName = _name
                _dataTable.Columns(0).ColumnName = tTime
                _dataTable.Columns(1).ColumnName = tUpstreamInfiltration
                AddExtendedProperty(_dataTable, "Key", True)
                mUpstreamInfiltrationPageGraph.AddData(_dataTable)
                mUpstreamInfiltrationPanelGraph.AddData(_dataTable.Copy)
            Else
                ' No, Upstream Infiltration can be calculated from Infiltration Parameters
                _dataTable = _unit.SubsurfaceFlowRef.CalculatedUpstreamInfiltration(250)

                If (DataTableHasData(_dataTable)) Then
                    _dataTable.TableName = _name
                    _dataTable.Columns(0).ColumnName = tTime
                    _dataTable.Columns(1).ColumnName = tUpstreamInfiltration
                    AddExtendedProperty(_dataTable, "Key", True)
                    mUpstreamInfiltrationPageGraph.AddData(_dataTable)
                    mUpstreamInfiltrationPanelGraph.AddData(_dataTable.Copy)
                Else
                    mUpstreamInfiltrationPageGraph.AddNullData(_name, True)
                    mUpstreamInfiltrationPanelGraph.AddNullData(_name, True)
                End If
            End If
            '
            '*****************************
            ' Infiltration Function curves
            '*****************************
            '
            ' Infiltration Depth Function is calculated from Infiltration Parameters
            If (_unit.SoilCropPropertiesRef.EnableTabulatedInfiltration.Value) Then
                _dataTable = _unit.SoilCropPropertiesRef.InfiltrationFunctionDataTable(0.0, 250, 0)
            Else
                _dataTable = _unit.SoilCropPropertiesRef.InfiltrationFunctionDataTable(0.0, 250)
            End If

            If (DataTableHasData(_dataTable)) Then
                _dataTable.TableName = _name
                _dataTable.Columns(0).ColumnName = tTime
                _dataTable.Columns(1).ColumnName = tInfiltration
                If (_unit.CrossSection = CrossSections.Furrow) Then
                    _dataTable.Columns(1).ColumnName = "AZ/FS"
                Else
                    _dataTable.Columns(1).ColumnName = "AZ/W"
                End If
                AddExtendedProperty(_dataTable, "Key", True)
                mInfiltrationDepthFunctionPageGraph.AddData(_dataTable)
                mInfiltrationDepthFunctionPanelGraph.AddData(_dataTable.Copy)

                ' Infiltration Function is calculated from Infiltration Depth Function
                _dataTable = _dataTable.Copy
                _dataTable.Columns(1).ColumnName = "AZ"

                Dim _width As Double = _unit.SystemGeometryRef.WidthForCrossSection
                For Each dRow As DataRow In _dataTable.Rows
                    Dim z As Double = dRow(1)
                    Dim az As Double = z * _width
                    dRow(1) = az
                Next

                mInfiltrationFunctionPageGraph.AddData(_dataTable)
                mInfiltrationFunctionPanelGraph.AddData(_dataTable.Copy)
            Else
                mInfiltrationDepthFunctionPageGraph.AddNullData(_name, True)
                mInfiltrationDepthFunctionPanelGraph.AddNullData(_name, True)

                mInfiltrationFunctionPageGraph.AddNullData(_name, True)
                mInfiltrationFunctionPanelGraph.AddNullData(_name, True)
            End If
            '
            '*****************************
            ' Performance Indicators
            '*****************************
            '
            If ((mDataComparisonType And DataComparisonTypes.PerformanceIndicators) = DataComparisonTypes.PerformanceIndicators) Then
                Dim _numPages As Integer = Math.Ceiling(mUnits.Count / UnitsPerPage)
                If (0 < _numPages) Then
                    If (mUnits.Count - ((_numPages - 1) * UnitsPerPage) = 1) Then
                        ' Added Unit adds page
                        ResetTabPages(mDataComparisonType, mErosionCurveNo)
                    Else
                        ' Added Unit adds column
                        UpdatePerformanceIndicatorsPages()
                    End If
                Else ' No Units to display
                    UpdatePerformanceIndicatorsPages()
                End If
            End If
            '
            '*****************************
            ' Goodness Of Fit
            '*****************************
            '
            If ((mDataComparisonType And DataComparisonTypes.GoodnessOfFit) = DataComparisonTypes.GoodnessOfFit) Then
                ' Added Unit adds page
                ResetTabPages(mDataComparisonType, mErosionCurveNo)
            End If
            '
            '*****************************
            ' Erosion curves
            '*****************************
            '
            AddErosionTabs(_unit, _name)
        End If

        ' Refresh UI so all keys are visible
        Me.Refresh()

        Return True

    End Function

    Private Sub AddErosionTabs(ByVal _unit As Unit, ByVal _name As String)
        '
        '*****************************
        ' Erosion curves
        '*****************************
        '
        Dim _dataSet As DataSet
        Dim _dataTable As DataTable

        ' Is Erosion G available as an output?
        _dataSet = _unit.SurfaceFlowRef.ErosionGHydrographs.Value

        If (DataSetHasData(_dataSet)) Then
            Try
                _dataTable = _dataSet.Tables(mErosionCurveNo).Copy
                _dataTable.TableName = _dataTable.TableName + " - " + _name
                mErosionGPageGraph.AddData(_dataTable)

                _dataTable = _dataSet.Tables(mErosionCurveNo).Copy
                _dataTable.TableName = _dataTable.TableName + " - " + _name
                mErosionGPanelGraph.AddData(_dataTable)
            Catch ex As Exception
                mErosionGPageGraph.AddNullData(_name, True)
                mErosionGPanelGraph.AddNullData(_name, True)
            End Try
        Else
            mErosionGPageGraph.AddNullData(_name, True)
            mErosionGPanelGraph.AddNullData(_name, True)
        End If

        ' Is Erosion CGm available as an output?
        _dataSet = _unit.SurfaceFlowRef.ErosionCGmHydrographs.Value

        If (DataSetHasData(_dataSet)) Then
            Try
                _dataTable = _dataSet.Tables(mErosionCurveNo).Copy
                _dataTable.TableName = _dataTable.TableName + " - " + _name
                mErosionCGmPageGraph.AddData(_dataTable)

                _dataTable = _dataSet.Tables(mErosionCurveNo).Copy
                _dataTable.TableName = _dataTable.TableName + " - " + _name
                mErosionCGmPanelGraph.AddData(_dataTable)
            Catch ex As Exception
                mErosionCGmPageGraph.AddNullData(_name, True)
                mErosionCGmPanelGraph.AddNullData(_name, True)
            End Try
        Else
            mErosionCGmPageGraph.AddNullData(_name, True)
            mErosionCGmPanelGraph.AddNullData(_name, True)
        End If

        ' Is Erosion CGv available as an output?
        _dataSet = _unit.SurfaceFlowRef.ErosionCGvHydrographs.Value

        If (DataSetHasData(_dataSet)) Then
            Try
                _dataTable = _dataSet.Tables(mErosionCurveNo).Copy
                _dataTable.TableName = _dataTable.TableName + " - " + _name
                mErosionCGvPageGraph.AddData(_dataTable)

                _dataTable = _dataSet.Tables(mErosionCurveNo).Copy
                _dataTable.TableName = _dataTable.TableName + " - " + _name
                mErosionCGvPanelGraph.AddData(_dataTable)
            Catch ex As Exception
                mErosionCGvPageGraph.AddNullData(_name, True)
                mErosionCGvPanelGraph.AddNullData(_name, True)
            End Try
        Else
            mErosionCGvPageGraph.AddNullData(_name, True)
            mErosionCGvPanelGraph.AddNullData(_name, True)
        End If

    End Sub

    Public Sub RemoveUnit(ByVal _unit As Unit)

        If (_unit Is Nothing) Then
            Return
        End If

        If (0 <= mUnits.IndexOf(_unit)) Then
            mUnits.Remove(_unit)

            Dim _name As String = ComparisonName(_unit)
            Dim _suffix As String = String.Empty

            ' Inflow curve
            mInflowPageGraph.RemoveData(_name)
            mInflowPanelGraph.RemoveData(_name)

            ' Inflow / Runoff curve
            _suffix = String.Empty
            While (mInflowRunoffPageGraph.ContainsData(_name + _suffix))
                mInflowRunoffPageGraph.RemoveData(_name + _suffix)
                mInflowRunoffPanelGraph.RemoveData(_name + _suffix)
                _suffix += " "
            End While

            ' Advance curve
            _suffix = String.Empty
            While (mAdvancePageGraph.ContainsData(_name + _suffix))
                mAdvancePageGraph.RemoveData(_name + _suffix)
                mAdvancePanelGraph.RemoveData(_name + _suffix)
                _suffix += " "
            End While

            mAdvancePageGraph.MaxX = _unit.SystemGeometryRef.Length.Value
            mAdvancePanelGraph.MaxX = _unit.SystemGeometryRef.Length.Value

            mAdvancePageGraph.DrawImage()
            mAdvancePanelGraph.DrawImage()

            ' Advance / Recession curve
            _suffix = String.Empty
            While (mAdvanceRecessionPageGraph.ContainsData(_name + _suffix))
                mAdvanceRecessionPageGraph.RemoveData(_name + _suffix)
                mAdvanceRecessionPanelGraph.RemoveData(_name + _suffix)
                _suffix += " "
            End While

            mAdvanceRecessionPageGraph.MaxX = _unit.SystemGeometryRef.Length.Value
            mAdvanceRecessionPanelGraph.MaxX = _unit.SystemGeometryRef.Length.Value

            mAdvanceRecessionPageGraph.DrawImage()
            mAdvanceRecessionPanelGraph.DrawImage()

            ' Volume Balance curve
            mVolumeBalanceVsTimePageGraph.RemoveData(_name)
            mVolumeBalanceVsTimePanelGraph.RemoveData(_name)
            mVolumeBalanceVsAdvPanelGraph.RemoveData(_name)
            mVolumeBalanceVsAdvPanelGraph.RemoveData(_name)

            ' Infiltration curve
            mInfiltrationPageGraph.RemoveData(_name)
            mInfiltrationPanelGraph.RemoveData(_name)

            ' Upstream Infiltration curve
            mUpstreamInfiltrationPageGraph.RemoveData(_name)
            mUpstreamInfiltrationPanelGraph.RemoveData(_name)

            ' Infiltration Function curve
            mInfiltrationFunctionPageGraph.RemoveData(_name)
            mInfiltrationFunctionPanelGraph.RemoveData(_name)

            ' Infiltration Depth Function curve
            mInfiltrationDepthFunctionPageGraph.RemoveData(_name)
            mInfiltrationDepthFunctionPanelGraph.RemoveData(_name)

            ' Erosion curves
            Dim _dataSet As DataSet
            Dim _dataTable As DataTable

            ' Is Erosion G available as an output?
            _dataSet = _unit.SurfaceFlowRef.ErosionGHydrographs.Value

            If (DataSetHasData(_dataSet)) Then
                Try
                    _dataTable = _dataSet.Tables(mErosionCurveNo)
                    mErosionGPageGraph.RemoveData(_dataTable.TableName + " - " + _name)
                    mErosionGPanelGraph.RemoveData(_dataTable.TableName + " - " + _name)
                Catch ex As Exception
                End Try
            End If

            ' Is Erosion CGm available as an output?
            _dataSet = _unit.SurfaceFlowRef.ErosionCGmHydrographs.Value

            If (DataSetHasData(_dataSet)) Then
                Try
                    _dataTable = _dataSet.Tables(mErosionCurveNo)
                    mErosionCGmPageGraph.RemoveData(_dataTable.TableName + " - " + _name)
                    mErosionCGmPanelGraph.RemoveData(_dataTable.TableName + " - " + _name)
                Catch ex As Exception
                End Try
            End If

            ' Is Erosion CGv available as an output?
            _dataSet = _unit.SurfaceFlowRef.ErosionCGvHydrographs.Value

            If (DataSetHasData(_dataSet)) Then
                Try
                    _dataTable = _dataSet.Tables(mErosionCurveNo)
                    mErosionCGvPageGraph.RemoveData(_dataTable.TableName + " - " + _name)
                    mErosionCGvPanelGraph.RemoveData(_dataTable.TableName + " - " + _name)
                Catch ex As Exception
                End Try
            End If

            ' Performance Indicators
            If ((mDataComparisonType And DataComparisonTypes.PerformanceIndicators) = DataComparisonTypes.PerformanceIndicators) Then
                Dim _numPages As Integer = Math.Ceiling(mUnits.Count / UnitsPerPage)
                If (0 < _numPages) Then
                    If (mUnits.Count - ((_numPages - 1) * UnitsPerPage) = 4) Then
                        ' Removed Unit removes page
                        ResetTabPages(mDataComparisonType, mErosionCurveNo)
                    Else
                        ' Removed Unit removes column
                        UpdatePerformanceIndicatorsPages()
                    End If
                Else ' No Unit to display
                    UpdatePerformanceIndicatorsPages()
                End If
            End If

            ' Goodness Of Fit
            If ((mDataComparisonType And DataComparisonTypes.GoodnessOfFit) = DataComparisonTypes.GoodnessOfFit) Then
                ' Removed Unit removes page
                ResetTabPages(mDataComparisonType, mErosionCurveNo)
            End If
        End If

    End Sub

    Public Sub RemoveAllUnits()

        ' Clear the Units list
        mUnits.Clear()

        ' Clear the graphs

        ' Inflow curve
        mInflowPageGraph.RemoveAllData()
        mInflowPanelGraph.RemoveAllData()

        ' Inflow / Runoff curve
        mInflowRunoffPageGraph.RemoveAllData()
        mInflowRunoffPanelGraph.RemoveAllData()

        ' Advance curve
        mAdvancePageGraph.RemoveAllData()
        mAdvancePanelGraph.RemoveAllData()

        ' Advance / Recession curve
        mAdvanceRecessionPageGraph.RemoveAllData()
        mAdvanceRecessionPanelGraph.RemoveAllData()

        ' Volume Balance curve
        mVolumeBalanceVsTimePageGraph.RemoveAllData()
        mVolumeBalanceVsTimePanelGraph.RemoveAllData()
        mVolumeBalanceVsAdvPageGraph.RemoveAllData()
        mVolumeBalanceVsAdvPanelGraph.RemoveAllData()

        ' Infiltration curve
        mInfiltrationPageGraph.RemoveAllData()
        mInfiltrationPanelGraph.RemoveAllData()

        ' Upstream Infiltration curve
        mUpstreamInfiltrationPageGraph.RemoveAllData()
        mUpstreamInfiltrationPanelGraph.RemoveAllData()

        ' Infiltration Function curve
        mInfiltrationFunctionPageGraph.RemoveAllData()
        mInfiltrationFunctionPanelGraph.RemoveAllData()

        ' Infiltration Depth Function curve
        mInfiltrationDepthFunctionPageGraph.RemoveAllData()
        mInfiltrationDepthFunctionPanelGraph.RemoveAllData()

        ' Erosion curves
        mErosionGPageGraph.RemoveAllData()
        mErosionGPanelGraph.RemoveAllData()
        mErosionCGmPageGraph.RemoveAllData()
        mErosionCGmPanelGraph.RemoveAllData()
        mErosionCGvPageGraph.RemoveAllData()
        mErosionCGvPanelGraph.RemoveAllData()

        ResetTabPages(mDataComparisonType, mErosionCurveNo)

    End Sub

#End Region

#Region " Results Page Methods "

    Private Function GetResultsPage(ByVal _pageNumber As Integer) As RtfPage

        ' If page number is within range of pages; return that page
        If ((0 < _pageNumber) And (_pageNumber <= NumberOfPages)) Then
            Dim _page As RtfPage = mResultsPages.Item(_pageNumber - 1)
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
        AddHandler _panel.Paint, AddressOf Panel_Paint2DGraph

        mResultsPanels.Add(_panel)

        Return _panel

    End Function

    Private Function GetNewResultsPage(ByVal _title As String,
                                       ByVal _view As ResultsViews) As RtfPage

        ' Instantiate a new Results Page
        Dim _rtfPage As RtfPage = New RtfPage

        _rtfPage.PageTitle = _title
        _rtfPage.PageNumber = NumberOfPages + 1

        _rtfPage.PageWidth = PortraitPageWidth
        _rtfPage.PageHeight = PortraitPageLength

        _rtfPage.TopMargin = PortraitTopMargin
        _rtfPage.LeftMargin = PortraitLeftMargin
        _rtfPage.RightMargin = PortraitRightMargin
        _rtfPage.BottomMargin = PortraitBottomMargin

        _rtfPage.Location = New Point(LeftOffset, TopOffset)

        ' Add event handler for Mouse Wheel events
        AddHandler _rtfPage.RtfCtrl.MouseWheel, AddressOf RtfCtrl_MouseWheel

        mResultsPages.Add(_rtfPage)

        Return _rtfPage

    End Function

    Private Function GetNew2dGraphPanel(ByVal _dataSet As DataSet,
                                        ByVal _title As String) As grf_XYGraph

        Dim _2dGraph As grf_XYGraph = New grf_XYGraph(_dataSet)

        LoadUserColors(_2dGraph)

        _2dGraph.Dock = DockStyle.Fill
        _2dGraph.AccessibleName = _title
        _2dGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        _2dGraph.ToolTip.Active = False

        Return _2dGraph

    End Function

    Private Function GetNew2dGraphPage(ByVal _dataSet As DataSet,
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

    '******************************************************************************************
    ' DisplayResultsHeader() - displays the results header
    '
    Private Sub DisplayResultsHeader(ByVal _rtf As RichTextBox)

        If (_rtf IsNot Nothing) Then
            ' Center the heading text
            _rtf.SelectionAlignment = HorizontalAlignment.Center

            ' Program & ALARC names
            AppendBoldText(_rtf, Application.ProductName)
            AppendLine(_rtf, " " + Application.ProductVersion + " - " +
                                CenterName + ", " + CenterCity + ", " + CenterState)

            AdvanceLine(_rtf)
        End If

    End Sub

    '******************************************************************************************
    ' DisplayResultsFooter() - displays the results footer
    '
    Private Sub DisplayResultsFooter(ByVal _rtf As RichTextBox,
                                     ByVal _pageNumber As Integer,
                                     ByVal _totalPages As Integer)

        ' Print blank lines until end-of-page
        While (CountLines(_rtf) < PortraitHeightLines)
            AdvanceLine(_rtf)
        End While

        ' Center the footer text
        _rtf.SelectionAlignment = HorizontalAlignment.Center

        ' Print page numbers
        AppendText(_rtf, mDictionary.tPage.Translated & " " & _pageNumber.ToString & " " & mDictionary.tOf.Translated & " " & _totalPages.ToString)

    End Sub

    Private Function AddResultsPage(ByVal _title As String,
                                    ByVal _2dGraph As grf_XYGraph) As TabPage

        Debug.Assert(_title IsNot Nothing And _2dGraph IsNot Nothing)

        Dim _tabPage As TabPage = Nothing

        ' Full Page view for Display, Print & Print Preview
        Dim _rtfPage As RtfPage = GetNewResultsPage(_title, ResultsView)
        Dim _rtf As RichTextBox = _rtfPage.Rtf

        _rtfPage.AccessibleName = _title
        _rtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Add Header
        DisplayResultsHeader(_rtf)

        ' Add graph
        _2dGraph.Location = PortraitGraphLocation
        _2dGraph.Size = PortraitGraphSize

        _rtfPage.AddImage(_2dGraph)

        ' Add Footer
        mPageNumber += 1

        DisplayResultsFooter(_rtf, mPageNumber, mTotalPages)

        ' Make the Full Page visible, if requested
        If (ResultsView = Globals.ResultsViews.PortraitPage) Then
            _tabPage = AddTabPage(_title, _rtfPage)
        End If

        _2dGraph.DrawImage()

        Return _tabPage

    End Function

    Private Function AddResultsPanel(ByVal _title As String,
                                     ByVal _2dGraph As grf_XYGraph) As TabPage

        Debug.Assert(_title IsNot Nothing And _2dGraph IsNot Nothing)

        Dim _tabPage As TabPage = Nothing

        ' Add the Graphics Only Panel only if it will be displayed
        If (ResultsView = Globals.ResultsViews.GraphsOnly) Then

            ' Graphics Only view for Display only
            Dim _panel As Panel = GetNewResultsPanel(_title)

            _panel.AccessibleName = _title
            _panel.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated

            ' Add graph to panel
            _panel.Controls.Add(_2dGraph)

            ' Add panel to tabpage
            _tabPage = AddTabPage(_title, _panel)

            _2dGraph.DrawImage()

        End If

        Return _tabPage

    End Function

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
        Me.ResumeLayout()

        Return _tabPage

    End Function
    '
    ' Performance Indicators
    '
    Private mFirstPerformanceIndicatorsPageNumber As Integer
    Private Sub AddPerformanceIndicatorsPages(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = String.Empty) Then
            tabName = title
        End If

        ' Save page number for 1st Indicators page (there may be more than 1)
        mFirstPerformanceIndicatorsPageNumber = mPageNumber + 1

        Dim _numPages As Integer = Math.Ceiling((mUnits.Count / UnitsPerPage))
        If (0 < _numPages) Then
            ' Add Indicators tab for each set of columns
            Dim _tabNum As Integer = 0
            For _pageNum As Integer = mFirstPerformanceIndicatorsPageNumber To mFirstPerformanceIndicatorsPageNumber + _numPages - 1

                ' Full Page view for Display, Print & Print Preview
                Dim _rtfPage As RtfPage = GetNewResultsPage(title, ResultsView)
                Dim _rtb As RichTextBox = _rtfPage.Rtf

                _rtfPage.AccessibleName = title
                _rtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

                ' Display Performance Indicators
                mPageNumber += 1
                Dim _firstUnitNum As Integer = (_pageNum - Me.mFirstPerformanceIndicatorsPageNumber) * UnitsPerPage
                Dim _lastUnitNum As Integer = Math.Min(_firstUnitNum + UnitsPerPage, mUnits.Count) - 1
                Dim _numCols As Integer = _lastUnitNum - _firstUnitNum + 1
                Dim _colWidth As Integer = ColWidth
                If (_numCols < 3) Then
                    _colWidth = ColWidth * UnitsPerPage / (_numCols + 1)
                End If

                UpdatePerformanceIndicatorsPage(_rtb, _pageNum, _firstUnitNum, _lastUnitNum, _colWidth)

                ' Make the Full Page visible
                _tabNum += 1
                Dim _tabTitle As String = tabName + " " + _tabNum.ToString + "/" + _numPages.ToString
                AddTabPage(_tabTitle, _rtfPage)
            Next
        Else ' No Units to display
            ' Full Page view for Display, Print & Print Preview
            Dim _rtfPage As RtfPage = GetNewResultsPage(title, ResultsView)
            Dim _rtb As RichTextBox = _rtfPage.Rtf

            _rtfPage.AccessibleName = title
            _rtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

            ' Display Performance Indicators
            mPageNumber += 1
            UpdatePerformanceIndicatorsPage(_rtb, mPageNumber, 0, -1, ColWidth * 2)

            ' Make the Full Page visible
            Dim _tabTitle As String = tabName + " 1/1"
            AddTabPage(_tabTitle, _rtfPage)
        End If

    End Sub

    Private Sub UpdatePerformanceIndicatorsPages()

        If (0 < mFirstPerformanceIndicatorsPageNumber) Then
            Dim _numPages As Integer = Math.Ceiling((mUnits.Count / UnitsPerPage))
            If (0 < _numPages) Then
                For _pageNum As Integer = mFirstPerformanceIndicatorsPageNumber To mFirstPerformanceIndicatorsPageNumber + _numPages - 1

                    ' Update Performance Indicators
                    Dim _rtfPage As RtfPage = mResultsPages.Item(_pageNum - 1)
                    Dim _rtb As RichTextBox = _rtfPage.Rtf
                    Dim _firstUnitNum As Integer = (_pageNum - mFirstPerformanceIndicatorsPageNumber) * UnitsPerPage
                    Dim _lastUnitNum As Integer = Math.Min(_firstUnitNum + UnitsPerPage, mUnits.Count) - 1
                    Dim _numCols As Integer = _lastUnitNum - _firstUnitNum + 1
                    Dim _colWidth As Integer = ColWidth
                    If (_numCols < 3) Then
                        _colWidth = ColWidth * UnitsPerPage / (_numCols + 1)
                    End If

                    UpdatePerformanceIndicatorsPage(_rtb, _pageNum, _firstUnitNum, _lastUnitNum, _colWidth)
                Next
            Else ' No Units to display
                Dim _pageNum As Integer = mFirstPerformanceIndicatorsPageNumber

                ' Full Page view for Display, Print & Print Preview
                Dim _rtfPage As RtfPage = mResultsPages.Item(_pageNum - 1)
                Dim _rtb As RichTextBox = _rtfPage.Rtf

                ' Update Performance Indicators
                UpdatePerformanceIndicatorsPage(_rtb, _pageNum, 0, -1, ColWidth * 2)
            End If
        End If
    End Sub

    Private Sub UpdatePerformanceIndicatorsPage(ByVal rtb As RichTextBox, ByVal pageNo As Integer,
                                                ByVal firstUnit As Integer, ByVal lastUnit As Integer, ByVal ColWidth As Integer)
        Dim _name As String

        If (rtb IsNot Nothing) Then
            ' rtb may be defined but Disposed; this causes an exception
            Try
                Dim _unit As Unit
                Dim _world, _folder, _field, _analysis As String

                Dim tInfiltration As String = mDictionary.tWaterBalanceInfiltration.Translated

                ' Clear the old contents
                rtb.Clear()

                ' Page Header
                DisplayResultsHeader(rtb)
                AdvanceLine(rtb)
                AppendBoldUnderlineLine(rtb, mDictionary.tInputAndPerformanceSummary.Translated)
                AdvanceLine(rtb)
                '
                ' Column Header(s)
                '
                rtb.SelectionAlignment = HorizontalAlignment.Left

                ' Field ID
                AppendTextLeft(rtb, mDictionary.tField.Translated & ": ", ColWidth)
                For _idx As Integer = firstUnit To lastUnit
                    _unit = mUnits(_idx)
                    _field = _unit.WorldRef.FieldRef.Name.Value

                    If (ColWidth - 2 < _field.Length) Then
                        _field = _field.Substring(0, ColWidth - 3) + ">"
                    End If

                    AppendTextRight(rtb, _field, ColWidth)
                Next
                AdvanceLine(rtb)

                ' World ID
                AppendTextLeft(rtb, mDictionary.tWorld.Translated & ": ", ColWidth)
                For _idx As Integer = firstUnit To lastUnit
                    _unit = mUnits(_idx)
                    _world = WorldsText(_unit.UnitType.Value)

                    AppendTextRight(rtb, _world, ColWidth)
                Next
                AdvanceLine(rtb)

                AppendTextLeft(rtb, mDictionary.tFolder.Translated & ": ", ColWidth)
                For _idx As Integer = firstUnit To lastUnit
                    _unit = mUnits(_idx)
                    _folder = _unit.WorldRef.Name.Value

                    If (ColWidth - 2 < _folder.Length) Then
                        _folder = _folder.Substring(0, ColWidth - 3) + ">"
                    End If

                    AppendTextRight(rtb, _folder, ColWidth)
                Next
                AdvanceLine(rtb)

                ' Analysis ID
                AppendTextLeft(rtb, mDictionary.tAnalysis.Translated & ": ", ColWidth)
                For _idx As Integer = firstUnit To lastUnit
                    _unit = mUnits(_idx)
                    _analysis = _unit.Name.Value

                    If (ColWidth - 2 < _analysis.Length) Then
                        _analysis = _analysis.Substring(0, ColWidth - 3) + ">"
                    End If

                    AppendTextRight(rtb, _analysis, ColWidth)
                Next
                AdvanceLine(rtb)
                '
                ' System Geometry
                '
                _unit = DirectCast(mUnits(0), Unit)
                Dim drainback As Boolean = (_unit.SystemGeometryRef.UpstreamCondition.Value = UpstreamConditions.DrainbackAfterCutoff)

                AdvanceLine(rtb)
                rtb.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(rtb, mDictionary.tSystemGeometry.Translated)

                ' Cross Section
                _name = sCrossSection
                UpdateStringLine(rtb, firstUnit, lastUnit, ColWidth, _name, mDictionary.tCrossSection.Translated, CrossSectionSelections)

                ' Length
                _name = SystemGeometry.sLength
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, mDictionary.tLength.Translated)

                ' Width
                _name = SystemGeometry.sWidth
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, mDictionary.tWidth.Translated)
                '
                ' Surface Flow
                '
                AdvanceLine(rtb)
                rtb.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(rtb, mDictionary.tSurfaceFlow.Translated)

                ' Tco
                _name = SurfaceFlow.sSimCutoffTime
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Tco")

                ' TL
                _name = SurfaceFlow.sAdvanceTimeToFieldEnd
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "TL")

                ' R
                _name = SurfaceFlow.sXaR
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "XR")

                ' Q0avg
                _name = SurfaceFlow.sSimAverageInflowRate
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Q0avg")
                '
                ' Infiltration
                '
                AdvanceLine(rtb)
                rtb.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(rtb, tInfiltration)

                ' Dreq
                _name = mDictionary.tRequiredDepth.Translated
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Dreq")

                ' Dapp / Dapp G
                If (drainback) Then
                    _name = SurfaceFlow.sGrossAppliedDepth
                    UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Dapp G")
                Else
                    _name = SubsurfaceFlow.sAppliedDepth
                    UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Dapp")
                End If

                ' Dinf
                _name = SubsurfaceFlow.sAverageDepth
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Dinf")

                ' DP
                _name = SubsurfaceFlow.sDeepPercolationDepth
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Ddp")

                ' RO
                _name = SurfaceFlow.sRunoffDepth
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Dro")

                ' Dmin
                _name = SubsurfaceFlow.sMinimumDepth
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Dmin")

                ' Dlq
                _name = SubsurfaceFlow.sLowQuarterDepth
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "Dlq")
                '
                ' Performance Summary
                '
                AdvanceLine(rtb)
                rtb.SelectionAlignment = HorizontalAlignment.Left
                AppendBoldUnderlineLine(rtb, mDictionary.tPerformanceSummary.Translated)

                _name = SubsurfaceFlow.sMinimumPAE
                'UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "PAEmin")

                _name = SubsurfaceFlow.sDuMinimum
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "DUmin")

                _name = SubsurfaceFlow.sMinimumAdequacy
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "ADmin")

                AdvanceLine(rtb)

                _name = SubsurfaceFlow.sLowQuarterPAE
                'UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "PAElq")

                _name = SubsurfaceFlow.sDuLowQuarter
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "DUlq")

                _name = SubsurfaceFlow.sLowQuarterAdequacy
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "ADlq")

                AdvanceLine(rtb)

                _name = SubsurfaceFlow.sApplicationEfficiency
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "AE")

                _name = SubsurfaceFlow.sRequirementEfficiency
                UpdateDoubleLine(rtb, firstUnit, lastUnit, ColWidth, _name, "RE")

                ' Footer
                DisplayResultsFooter(rtb, pageNo, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                rtb = Nothing
            End Try
        End If

    End Sub
    '
    ' Goodness of Fit
    '
    Private mFirstGoodnessOfFitPageNumber As Integer
    Private Sub AddGoodnessOfFitPages(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Save page number for 1st Indicators page (there may be more than 1)
        mFirstGoodnessOfFitPageNumber = mPageNumber + 1

        Dim _numPages As Integer = mUnits.Count - 1
        If (0 < _numPages) Then
            ' Add Indicators tab for each set of columns
            Dim _tabNum As Integer = 0
            For _pageNum As Integer = mFirstGoodnessOfFitPageNumber To mFirstGoodnessOfFitPageNumber + _numPages - 1

                ' Full Page view for Display, Print & Print Preview
                Dim _rtfPage As RtfPage = GetNewResultsPage(title, ResultsView)
                Dim _rtb As RichTextBox = _rtfPage.Rtf

                _rtfPage.AccessibleName = title
                _rtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

                ' Display Goodness of Fit Parameters
                mPageNumber += 1
                Dim _firstUnit As Integer = 0
                Dim _secondUnit As Integer = _tabNum + 1

                UpdateGoodnessOfFitPage(_rtb, _pageNum, _firstUnit, _secondUnit)

                ' Make the Full Page visible
                _tabNum += 1
                Dim _tabTitle As String = tabName + " " + _tabNum.ToString + "/" + _numPages.ToString
                AddTabPage(_tabTitle, _rtfPage)
            Next

        Else ' No Units to display
            ' Full Page view for Display, Print & Print Preview
            Dim _rtfPage As RtfPage = GetNewResultsPage(title, ResultsView)
            Dim _rtb As RichTextBox = _rtfPage.Rtf

            _rtfPage.AccessibleName = title
            _rtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

            ' Display Goodness of Fit Parameters
            mPageNumber += 1
            UpdateGoodnessOfFitPage(_rtb, mPageNumber, 0, -1)

            ' Make the Full Page visible
            Dim _tabTitle As String = tabName + " 1/1"
            AddTabPage(_tabTitle, _rtfPage)
        End If

    End Sub

    Private Sub UpdateGoodnessOfFitPages()

        If (0 < mFirstGoodnessOfFitPageNumber) Then
            Dim _numPages As Integer = mUnits.Count - 1
            If (0 < _numPages) Then
                Dim _tabNum As Integer = 0
                For _pageNum As Integer = mFirstGoodnessOfFitPageNumber To mFirstGoodnessOfFitPageNumber + _numPages - 1

                    ' Update Performance Indicators
                    Dim _rtfPage As RtfPage = mResultsPages.Item(_pageNum - 1)
                    Dim _rtb As RichTextBox = _rtfPage.Rtf
                    Dim _firstUnit As Integer = 0
                    Dim _secondUnit As Integer = _tabNum + 1

                    UpdateGoodnessOfFitPage(_rtb, _pageNum, _firstUnit, _secondUnit)

                    _tabNum += 1
                Next
            End If
        End If
    End Sub

    Private Sub UpdateGoodnessOfFitPage(ByVal rtb As RichTextBox, ByVal pageNo As Integer,
                                        ByVal firstUnit As Integer, ByVal secondUnit As Integer)

        If Not (rtb Is Nothing) Then
            ' rtb may be defined but Disposed; this causes an exception
            Try
                Dim tInflow As String = mDictionary.tInflow.Translated

                ' Clear the old contents
                rtb.Clear()

                ' Get references to Unit data
                Dim unit1Title As String = mDictionary.tParameterSet.Translated & " #1"
                Dim unit1Label As String = "  Set #1: "

                Dim unit2Title As String = mDictionary.tParameterSet.Translated & " #2"
                Dim unit2Label As String = "  Set #2: "

                Dim blankLabel As String = "          "
                '
                ' Page Header
                '
                DisplayResultsHeader(rtb)
                AdvanceLine(rtb)
                AppendBoldUnderlineLine(rtb, mDictionary.tGoodnessOfFitMeasures.Translated)
                AdvanceLine(rtb)
                '
                ' Farm / Field / Unit names
                '
                Dim _widthChars As Integer = PortraitWidthChars

                Dim unit1 As Unit = Nothing
                If ((0 <= firstUnit) And (firstUnit < mUnits.Count)) Then
                    unit1 = mUnits(firstUnit)
                    AppendBoldLine(rtb, unit1Title)
                    AppendFieldIdText(rtb, unit1, _widthChars)
                    AdvanceLine(rtb)
                    AppendUnitIdText(rtb, unit1, _widthChars)
                    AdvanceLines(rtb, 2)
                Else
                    Return
                End If

                Dim unit2 As Unit = Nothing
                If ((0 <= secondUnit) And (secondUnit < mUnits.Count)) Then
                    unit2 = mUnits(secondUnit)
                    AppendBoldLine(rtb, unit2Title)
                    AppendFieldIdText(rtb, unit2, _widthChars)
                    AdvanceLine(rtb)
                    AppendUnitIdText(rtb, unit2, _widthChars)
                    AdvanceLines(rtb, 2)
                Else
                    Return
                End If

                ' Left justity text
                rtb.SelectionAlignment = HorizontalAlignment.Left
                '
                ' System Geometry
                '
                Dim type1 As String = CrossSectionSelections(unit1.CrossSection).Value
                Dim length1 As Double = unit1.SystemGeometryRef.Length.Value
                Dim width1 As Double = unit1.SystemGeometryRef.Width.Value
                Dim area1 As Double = unit1.SystemGeometryRef.FieldArea

                Dim type2 As String = CrossSectionSelections(unit2.CrossSection).Value
                Dim length2 As Double = unit2.SystemGeometryRef.Length.Value
                Dim width2 As Double = unit2.SystemGeometryRef.Width.Value
                Dim area2 As Double = unit2.SystemGeometryRef.FieldArea

                AdvanceLine(rtb)
                AppendBoldUnderlineLine(rtb, mDictionary.tSystemGeometry.Translated)

                AppendText(rtb, unit1Label + "(" + type1 + ") " & mDictionary.tLength.Translated & ": " + LengthString(length1, -12))
                AppendText(rtb, mDictionary.tWidth.Translated & ": " + LengthString(width1, -12))
                AppendLine(rtb, mDictionary.tArea.Translated & ": " + AreaString(area1, 0))

                AppendText(rtb, unit2Label + "(" + type2 + ")         " + LengthString(length2, -12))
                AppendText(rtb, "       " + LengthString(width2, -12))
                AppendLine(rtb, "      " + AreaString(area2, 0))
                '
                ' Inflow
                '
                Dim appliedVolume1 As Double = unit1.InflowManagementRef.AppliedVolumeForCrossSection
                Dim appliedDepth1 As Double = unit1.InflowManagementRef.AppliedDepthForField
                If (0.0 = appliedVolume1) Then ' get values from Simulation results
                    appliedVolume1 = unit1.SurfaceFlowRef.InflowVolume
                    appliedDepth1 = unit1.SurfaceFlowRef.InflowDepth
                End If

                Dim appliedVolume2 As Double = unit2.InflowManagementRef.AppliedVolumeForCrossSection
                Dim appliedDepth2 As Double = unit2.InflowManagementRef.AppliedDepthForField
                If (0.0 = appliedVolume2) Then ' get values from Simulation results
                    appliedVolume2 = unit2.SurfaceFlowRef.InflowVolume
                    appliedDepth2 = unit2.SurfaceFlowRef.InflowDepth
                End If

                Dim errDepth As Double = (appliedDepth2 - appliedDepth1) / appliedDepth1

                AdvanceLine(rtb)
                AppendBoldUnderlineLine(rtb, tInflow)

                AppendText(rtb, unit1Label + mDictionary.tAppliedDepth.Translated & ":  " + DepthString(appliedDepth1, 0), 0)
                AdvanceLine(rtb)

                AppendText(rtb, unit2Label + "                " + DepthString(appliedDepth2, 0), 0)
                AdvanceLine(rtb)

                AppendText(rtb, blankLabel + mDictionary.tRelativeError.Translated & ": " + PercentageString(errDepth, 0), 0)
                AdvanceLine(rtb)
                '
                ' Advance
                '
                Dim TL1 As Double = unit1.SurfaceFlowRef.TL.Value
                Dim TL2 As Double = unit2.SurfaceFlowRef.TL.Value
                Dim errTL As Double = (TL2 - TL1) / TL1

                Dim advTable1 As DataTable = Nothing
                If (unit1.UnitType.Value = WorldTypes.EventWorld) Then ' check if 2-point advance

                    If (unit1.EventCriteriaRef.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                        advTable1 = unit1.InflowManagementRef.TwoPointTabulatedAdvance.Value
                    End If

                    If (advTable1 Is Nothing) Then ' not 2-point advance; check Tabulated Advance
                        advTable1 = unit1.InflowManagementRef.TabulatedAdvance.Value
                    End If
                Else
                    advTable1 = unit1.SurfaceFlowRef.Advance.Value
                End If
                Dim advDists1 As ArrayList = GetDataColumn(advTable1, sDistanceX)
                Dim advTimes1 As ArrayList = GetDataColumn(advTable1, sTimeX)

                Dim endIdx As Integer = advDists1.Count - 1
                While (0 < endIdx)
                    If (advDists1(endIdx) = advDists1(endIdx - 1)) Then
                        advDists1.RemoveAt(endIdx)
                        advTimes1.RemoveAt(endIdx)
                        endIdx -= 1
                    Else
                        Exit While
                    End If
                End While

                Dim numAdvTimes1 As Integer = advTimes1.Count
                Dim avgAdvTime1 As Double
                Dim endAdvTime1 As Double
                If (0 < numAdvTimes1) Then
                    avgAdvTime1 = AverageTimeOverDistance(advTable1)
                    endAdvTime1 = CDbl(advTimes1(numAdvTimes1 - 1))
                Else
                    avgAdvTime1 = Double.NaN
                    endAdvTime1 = Double.NaN
                End If

                Dim advTable2 As DataTable = Nothing
                If (unit2.UnitType.Value = WorldTypes.EventWorld) Then ' check if 2-point advance

                    If (unit2.EventCriteriaRef.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                        advTable2 = unit2.InflowManagementRef.TwoPointTabulatedAdvance.Value
                    End If

                    If (advTable2 Is Nothing) Then ' not 2-point advance; check Tabulated Advance
                        advTable2 = unit2.InflowManagementRef.TabulatedAdvance.Value
                    End If
                Else
                    advTable2 = unit2.SurfaceFlowRef.Advance.Value
                End If
                Dim advTimes2 As ArrayList = GetTimeColumn(advTable2, advDists1)

                Dim numAdvTimes2 As Integer = advTimes2.Count
                Dim avgAdvTime2 As Double
                Dim endAdvTime2 As Double
                If (0 < numAdvTimes2) Then
                    avgAdvTime2 = AverageTimeOverDistance(advTable2)
                    endAdvTime2 = CDbl(advTimes2(numAdvTimes2 - 1))
                Else
                    avgAdvTime2 = Double.NaN
                    endAdvTime2 = Double.NaN
                End If

                ' RMS Error for Advance
                Dim advSum As Double = SUMXMY2(advTimes1, advTimes2)
                Dim advMinNum As Double = Math.Min(numAdvTimes1, numAdvTimes2)
                Dim advRmse As Double = Math.Sqrt(advSum / advMinNum)

                AdvanceLine(rtb)
                AppendBoldUnderlineLine(rtb, mDictionary.tAdvanceTimes.Translated)
                AppendLine(rtb, "  " & mDictionary.tRootMeanSquareError.Translated & ":  " + TimeString(advRmse, 0))
                AdvanceLine(rtb)

                AppendLine(rtb, mDictionary.tAdvanceTimeEndOfField.Translated(30) & ": " + unit1Label + TimeString(TL1, 0))
                AppendLine(rtb, "                                " + unit2Label + TimeString(TL2, 0))
                AppendLine(rtb, mDictionary.tRelativeError.Translated(30) & ":           " + PercentageString(errTL, 0))
                '
                ' Recession
                '
                Dim recTable1 As DataTable
                If (unit1.UnitType.Value = WorldTypes.EventWorld) Then
                    recTable1 = unit1.InflowManagementRef.TabulatedRecession.Value
                Else
                    recTable1 = unit1.SurfaceFlowRef.Recession.Value
                End If
                Dim recDists1 As ArrayList = GetDataColumn(recTable1, sDistanceX)
                Dim recTimes1 As ArrayList = GetDataColumn(recTable1, sTimeX)

                Dim numRecTimes1 As Integer = recTimes1.Count
                Dim avgRecTime1 As Double = AverageTimeOverDistance(recTable1)
                Dim endRecTime1 As Double = DataColumnMax(recTable1, sTimeX)

                Dim recTable2 As DataTable
                If (unit2.UnitType.Value = WorldTypes.EventWorld) Then
                    recTable2 = unit2.InflowManagementRef.TabulatedRecession.Value
                Else
                    recTable2 = unit2.SurfaceFlowRef.Recession.Value
                End If
                Dim recTimes2 As ArrayList = GetTimeColumn(recTable2, recDists1)

                Dim numRecTimes2 As Integer = recTimes2.Count
                Dim avgRecTime2 As Double = AverageTimeOverDistance(recTable2)
                Dim endRecTime2 As Double = DataColumnMax(recTable2, sTimeX)

                Dim errRec As Double = (endRecTime2 - endRecTime1) / endRecTime1

                ' Compute RMS Error for Recession
                Dim recSum As Double = SUMXMY2(recTimes1, recTimes2)
                Dim recMinNum As Double = Math.Min(numRecTimes1, numRecTimes2)
                Dim recRmse As Double = Math.Sqrt(recSum / recMinNum)

                AdvanceLine(rtb)
                AppendBoldUnderlineLine(rtb, mDictionary.tRecessionTimes.Translated)
                AppendLine(rtb, mDictionary.tRootMeanSquareError.Translated(24) & ":  " + TimeString(recRmse, 0))
                AdvanceLine(rtb)
                AppendLine(rtb, mDictionary.tMaximumRecessionTime.Translated(24) & ":" + unit1Label + TimeString(endRecTime1, 0))
                AppendLine(rtb, "                         " + unit2Label + TimeString(endRecTime2, 0))
                AppendLine(rtb, mDictionary.tRelativeError.Translated(24) & ":          " + PercentageString(errRec, 0))
                '
                ' Opportunity Time
                '
                Dim avgOppTime1 As Double = avgRecTime1 - avgAdvTime1
                Dim avgOppTime2 As Double = avgRecTime2 - avgAdvTime2
                Dim errOpp As Double = (avgOppTime2 - avgOppTime1) / avgOppTime1

                AdvanceLine(rtb)
                AppendBoldUnderlineLine(rtb, mDictionary.tAverageOpportunityTimes.Translated)
                AppendLine(rtb, unit1Label + "        " + TimeString(avgOppTime1, 0))
                AppendLine(rtb, unit2Label + "        " + TimeString(avgOppTime2, 0))
                AppendLine(rtb, mDictionary.tRelativeError.Translated(16) & ": " + PercentageString(errOpp, 0))
                '
                ' Infiltration
                '
                Dim infilDepth1 As Double = unit1.SubsurfaceFlowRef.Davg.Value
                Dim infilDepth2 As Double = unit2.SubsurfaceFlowRef.Davg.Value

                errDepth = (infilDepth2 - infilDepth1) / infilDepth1

                AdvanceLine(rtb)
                AppendBoldUnderlineLine(rtb, mDictionary.tAverageInfiltration.Translated)

                AppendText(rtb, unit1Label + mDictionary.tInfiltratedDepth.Translated(17) & ": " + DepthString(infilDepth1, 0), 0)
                AdvanceLine(rtb)

                AppendText(rtb, unit2Label + "                   " + DepthString(infilDepth2, 0), 0)
                AdvanceLine(rtb)

                AppendText(rtb, blankLabel + mDictionary.tRelativeError.Translated(17) & ": " + PercentageString(errDepth, 0), 0)
                AdvanceLine(rtb)
                '
                ' Runoff
                '
                Dim roTable1 As DataTable
                If (unit1.UnitType.Value = WorldTypes.EventWorld) Then
                    roTable1 = unit1.InflowManagementRef.RunoffTableForCrossSection
                Else
                    roTable1 = unit1.SurfaceFlowRef.RunoffTable
                End If
                Dim roTimes1 As ArrayList = GetDataColumn(roTable1, sTimeX)
                Dim roRates1 As ArrayList = GetDataColumn(roTable1, sRunoffX)
                Dim runoffVolume1 As Double = DataTableIntegral(roTable1, sTimeX, sRunoffX)
                Dim runoffDepth1 As Double = unit1.SurfaceFlowRef.RunoffDepth

                Dim roTable2 As DataTable
                If (unit2.UnitType.Value = WorldTypes.EventWorld) Then
                    roTable2 = unit2.InflowManagementRef.RunoffTableForCrossSection
                Else
                    roTable2 = unit2.SurfaceFlowRef.RunoffTable
                End If
                Dim roRates2 As ArrayList = GetRunoffColumn(roTable2, roTimes1)
                Dim runoffVolume2 As Double = DataTableIntegral(roTable2, sTimeX, sRunoffX)
                Dim runoffDepth2 As Double = unit2.SurfaceFlowRef.RunoffDepth

                ' Compute Coefficient of Determination (R²)
                Dim _rsq As Double = RSQ(roRates1, roRates2)

                ' Compute Nash-Sutcliffe Efficiency E
                Dim _sumxmy2 As Double = SUMXMY2(roRates1, roRates2)
                Dim _devsq As Double = DEVSQ(roRates1)
                Dim _e As Double = 1 - (_sumxmy2 / _devsq)

                errDepth = (runoffDepth2 - runoffDepth1) / runoffDepth1

                AdvanceLine(rtb)
                AppendBoldUnderlineLine(rtb, mDictionary.tRunoff.Translated)

                AppendText(rtb, unit1Label + mDictionary.tRunoffDepth.Translated(12) & ":   " + DepthString(runoffDepth1, 0), 0)
                AdvanceLine(rtb)

                AppendText(rtb, unit2Label + "                " + DepthString(runoffDepth2, 0), 0)
                AdvanceLine(rtb)

                AppendText(rtb, blankLabel + mDictionary.tRelativeError.Translated(14) & ": " + PercentageString(errDepth, 0), 0)
                AdvanceLine(rtb)

                If ((0 < runoffVolume1) And (0 < runoffVolume2)) Then
                    AdvanceLine(rtb)
                    AppendLine(rtb, mDictionary.tCoefficientOfDetermination.Translated(35) & " (R²):  " & UnitText(_rsq, Units.None) + " *")
                    AppendLine(rtb, mDictionary.tNashSutcliffeEfficiency.Translated(35) & " (E):   " & UnitText(_e, Units.None) + " *")
                    AdvanceLine(rtb)
                    AppendLine(rtb, "   * " & mDictionary.tCalculatedBasedOnTimeAdjustedRunoffValues.Translated)
                    AdvanceLine(rtb)
                End If

                ' Footer
                DisplayResultsFooter(rtb, pageNo, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                rtb = Nothing
            End Try
        End If

    End Sub

    Private Sub UpdateStringLine(ByVal rtb As RichTextBox, ByVal first As Integer, ByVal last As Integer, ByVal ColWidth As Integer,
                                 ByVal name As String, ByVal label As String, ByVal selections() As Selection)

        Dim _label As String = "  " + label
        Dim _over As Integer = Math.Max(0, _label.Length - ColWidth)

        AppendText(rtb, _label, ColWidth)

        For _idx As Integer = first To last
            Dim _unit As Unit = mUnits(_idx)
            Dim _path As String = _unit.MyStore.FindPropertyPath(name)

            If Not (_path Is Nothing) Then
                Dim _integer As IntegerParameter = _unit.MyStore.GetIntegerParameter(_path)

                If Not (_integer Is Nothing) Then
                    If ((0 <= _integer.Value) And (_integer.Value < selections.Length)) Then
                        Dim _text As String = selections(_integer.Value).Value
                        AppendTextRight(rtb, _text, ColWidth - _over)
                    Else
                        AppendTextRight(rtb, "*****", ColWidth)
                    End If
                Else
                    AppendTextRight(rtb, "*****", ColWidth)
                End If
            Else
                AppendTextRight(rtb, "*****", ColWidth)
            End If

            _over = 0
        Next
        AdvanceLine(rtb)

    End Sub

    Private Sub UpdateDoubleLine(ByVal rtb As RichTextBox,
                                 ByVal first As Integer, ByVal last As Integer, ByVal ColWidth As Integer,
                                 ByVal name As String, ByVal label As String)

        Dim _label As String = String.Empty
        Dim _row As String = String.Empty

        For _idx As Integer = first To last
            Dim _unit As Unit = mUnits(_idx)
            Dim _col As String = String.Empty

            Dim _path As String = _unit.MyStore.FindPropertyPath(name)
            If (_path IsNot Nothing) Then

                Dim _double As DoubleParameter = _unit.MyStore.GetDoubleParameter(_path)
                If (_double IsNot Nothing) Then
                    ' Has the Row label been defined?
                    If (_label = String.Empty) Then
                        ' No, define it
                        Dim _units As Units = _double.DisplayUnits

                        _label = "  " + label
                        If Not ((_units = Units.None) Or (_units = Units.Text)) Then
                            _label += " (" + UnitsText(_units) + ")"
                        End If
                    End If

                    ' Add this data value to the Row
                    If (Double.IsNaN(_double.Value)) Then
                        _col = " " ' Value is undefined
                    Else
                        _col = _double.Text()
                    End If
                Else
                    _col = "*****"
                End If
            Else
                _col = "*****"
            End If

            ' Right-justify column data
            While (_col.Length < ColWidth)
                _col = " " + _col
            End While

            _row += _col
        Next

        If Not (_label = String.Empty) Then

            ' Left-justify label
            While (_label.Length < ColWidth)
                _label += " "
            End While

            Dim _over As Integer = Math.Max(0, _label.Length - ColWidth)
            For _idx As Integer = 0 To _over - 1
                _row = _row.Substring(1)
            Next

            AppendLine(rtb, _label + _row)
        End If

    End Sub

    Private Sub UpdateIntegerLine(ByVal rtb As RichTextBox, ByVal first As Integer, ByVal last As Integer, ByVal ColWidth As Integer,
                                  ByVal name As String, ByVal label As String)

        Dim _label As String = "  " + label
        Dim _over As Integer = Math.Max(0, _label.Length - ColWidth)

        AppendText(rtb, _label, ColWidth)

        For _idx As Integer = first To last
            Dim _unit As Unit = mUnits(_idx)
            Dim _path As String = _unit.MyStore.FindPropertyPath(name)

            If Not (_path Is Nothing) Then
                Dim _integer As IntegerParameter = _unit.MyStore.GetIntegerParameter(_path)

                If Not (_integer Is Nothing) Then
                    AppendTextRight(rtb, _integer.Text, ColWidth - _over)
                Else
                    AppendTextRight(rtb, "*****", ColWidth)
                End If
            Else
                AppendTextRight(rtb, "*****", ColWidth)
            End If

            _over = 0
        Next
        AdvanceLine(rtb)

    End Sub

#End Region

#Region " Print Support Methods "

    Public Sub Print(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal _view As ResultsViews)

        ' Display the PrintDialog
        PrintDialog.UseEXDialog = True
        If (PrintDialog.ShowDialog() = DialogResult.OK) Then

            ' Get the print range
            mFromPage = 1
            mToPage = NumberOfPages

            If (PrintDialog.PrinterSettings.PrintRange = PrintRange.SomePages) Then
                ' Start
                If (0 < PrintDialog.PrinterSettings.FromPage) Then
                    mFromPage = PrintDialog.PrinterSettings.FromPage
                End If
                ' End
                If (0 < PrintDialog.PrinterSettings.ToPage) Then
                    mToPage = PrintDialog.PrinterSettings.ToPage
                End If
                ' Start <= End
                If (mToPage < mFromPage) Then
                    mToPage = mFromPage
                End If
            End If

            ' Make sure the first page actually exists
            Dim _rtfPage As RtfPage = GetResultsPage(mFromPage)

            If Not (_rtfPage Is Nothing) Then

                ' Set page to match the display
                Dim _margins As Margins = New Margins(PortraitLeftMargin - 10, PortraitRightMargin,
                                                      PortraitTopMargin, PortraitBottomMargin)

                PrintDocument.DefaultPageSettings.Margins = _margins
                PrintDocument.DefaultPageSettings.Landscape = False

                ' Print (which may cause exceptions)
                Try
                    PrintDocument.Print()
                Catch ex As Exception
                    mWinSRFR.SeriousException("PrintDocument.Print()", ex)
                End Try
            Else
                Dim _details As String = String.Format("Invalid print range!  Page {0} does not exist.", mFromPage)
                mWinSRFR.SeriousError("Print", _details)
            End If
        End If

    End Sub

    Public Sub PrintPreview(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal _view As ResultsViews)

        ' Set page to match the display
        Dim _margins As Margins = New Margins(PortraitLeftMargin - 10, PortraitRightMargin,
                                              PortraitTopMargin, PortraitBottomMargin)

        PrintDocument.DefaultPageSettings.Margins = _margins
        PrintDocument.DefaultPageSettings.Landscape = False

        ' Print preview all pages
        PrintPreviewDialog.Document.PrinterSettings.PrintRange = PrintRange.AllPages
        mFromPage = 1
        mToPage = NumberOfPages
        PrintPreviewDialog.ShowDialog()

    End Sub

    Private Function PrintPage(ByVal _pageNumber As Integer, ByVal e As PrintPageEventArgs) As Boolean

        Dim _rtfPage As RtfPage = GetResultsPage(_pageNumber)

        If Not (_rtfPage Is Nothing) Then

            ' Tell the next page to print itself
            _rtfPage.Print(e)

            ' If there are more pages to print; let the caller know
            If (_pageNumber < NumberOfPages) Then
                Return True
            End If
        End If

        ' No more pages to print
        Return False

    End Function

    Private Sub PrintDocument_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs) _
    Handles PrintDocument.BeginPrint
        mPageToPrint = mFromPage
    End Sub

    Private Sub PrintDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) _
    Handles PrintDocument.PrintPage

        ' Print the next page; returns True if more pages are available to print
        Dim _more As Boolean = PrintPage(mPageToPrint, e)

        ' Also check print range
        If (_more) Then
            mPageToPrint += 1

            If (mPageToPrint <= mToPage) Then
                e.HasMorePages = True
                Return
            End If
        End If

        e.HasMorePages = False

    End Sub

#End Region

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Private Sub UpdateUI()

        ' Set flag indicating program (not user) is changing tab pages
        mUpdatingTabPages = True

        ResetTabPages(mDataComparisonType, mErosionCurveNo)

        ' Re-select the saved tab page
        If ((mSelectedIndex < 0) Or (Me.TabCount <= mSelectedIndex)) Then
            mSelectedIndex = Me.TabCount - 1
        End If

        Me.SelectedIndex = mSelectedIndex

        mUpdatingTabPages = False

    End Sub

#End Region

#Region " UI Event Handlers "

#Region " TabControl Event Handlers "

    Private mUpdatingTabPages As Boolean = False
    Private Sub TabControl_TabIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.SelectedIndexChanged

        If (mUpdatingTabPages) Then
            Return
        End If

        If (-1 < Me.SelectedIndex) Then

            Dim _tabPage As TabPage = Nothing
            '
            ' Keep the same scroll position from tab to tab
            '
            If Not (mSelectedIndex = Me.SelectedIndex) Then
                If ((mSelectedIndex < 0) Or (Me.TabCount <= mSelectedIndex)) Then
                    mSelectedIndex = 0
                End If

                _tabPage = Me.TabPages(mSelectedIndex)
                Dim _position As Point = _tabPage.AutoScrollPosition

                ' Adjust the position to follow Microsoft's inane logic!
                '  What goes in has the OPPOSITE SIGN of what comes out!!!  &^*%$%#
                _position.X = -_position.X
                _position.Y = -_position.Y

                ' Scroll all tab pages
                For Each _tabPage In Me.TabPages
                    _tabPage.AutoScrollPosition = _position
                Next

                mSelectedIndex = Me.SelectedIndex

            End If
            '
            ' Make sure the display is current
            '   The Paint event doesn't do this for tab index changes
            '
            If Not (_tabPage Is Nothing) Then

                _tabPage = Me.SelectedTab

                For Each _panel As Control In _tabPage.Controls

                    If (_panel.GetType Is GetType(Panel)) Then

                        For Each _control As Control In _panel.Controls

                            If ((_control.GetType Is GetType(grf_XYGraph)) _
                             Or (_control.GetType.IsSubclassOf(GetType(grf_XYGraph)))) Then

                                Dim _2DGraph As grf_XYGraph = DirectCast(_control, grf_XYGraph)

                                ' Redraw the graph
                                _2DGraph.DrawImage()
                            End If
                        Next

                    End If
                Next

            End If
        End If

    End Sub

    Private Sub Panel_Paint2DGraph(ByVal sender As Object, ByVal e As PaintEventArgs)
        ' Handles Panel.Paint

        ' Get references to Panel & Control that need painting
        Dim _panel As Panel = DirectCast(sender, Panel)

        If (0 < _panel.Controls.Count) Then

            If (_panel.Controls(0).GetType Is GetType(grf_XYGraph)) Then

                Dim _2DGraph As grf_XYGraph = DirectCast(_panel.Controls(0), grf_XYGraph)

                ' Redraw the 2D graph
                If (_2DGraph.Visible) Then
                    _2DGraph.DrawImage()
                End If
            End If
        End If

    End Sub

#End Region

#Region " Page Event Handlers "

    Private Sub ScrollPage(ByVal _delta As Integer)

        ' Scroll the currently selected TabPage
        Dim _tabPage As TabPage = Me.SelectedTab

        If Not (_tabPage Is Nothing) Then
            ' Get current scroll position
            Dim _position As Point = _tabPage.AutoScrollPosition

            ' Adjust the position to follow mouse wheel movement
            '  NOTE - What goes in has the OPPOSITE SIGN of what comes out!!!  &^*%$%#
            _position.X = CInt(-_position.X)
            _position.Y = CInt(-_position.Y - (PortraitPageLength / (_delta / 6)))

            ' Scroll the tab page
            _tabPage.AutoScrollPosition = _position
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
