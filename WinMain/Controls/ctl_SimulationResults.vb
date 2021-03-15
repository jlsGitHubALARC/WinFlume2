
'**********************************************************************************************
' ctl_SimulationResults - Control for displaying the Simulation World's results
'
Imports System.Drawing.Printing
Imports DataStore
Imports GraphingUI
Imports PrintingUI
Imports Srfr

Public Class ctl_SimulationResults
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
        'ctl_SimulationResults
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

    Protected Const OneSecond As Double = Srfr.Globals.OneSecond
    Protected Const TenSeconds As Double = Srfr.Globals.TenSeconds
    Protected Const OneMinute As Double = Srfr.Globals.OneMinute
    Protected Const OneHour As Double = Srfr.Globals.OneHour
    Protected Const SecondsPerMinute As Double = Srfr.Globals.SecondsPerMinute
    Protected Const SecondsPerHour As Double = Srfr.Globals.SecondsPerHour

    Protected Const LiterPerSecond As Double = Srfr.Globals.LiterPerSecond

    Protected Const SquareMetersPerHectare As Double = Srfr.Globals.SquareMetersPerHectare

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
    Private mPageNumber As Integer = 1
    Private mTotalPages As Integer = 1
    '
    ' Disposed event must be handled for these Components
    '

    ' Erosion Analysis
    Private WithEvents mErosionParametersPage As RichTextBox

    ' Simulation Analysis
    Private WithEvents mSimulationSummaryPage As RichTextBox
    Private WithEvents mErosionSummaryPage As RichTextBox
    Private WithEvents mFertigationSummaryPage As RichTextBox
    Private mSimulationSummaryRtfPage As RtfPage
    Private mErosionSummaryRtfPage As RtfPage
    Private mFertigationSummaryRtfPage As RtfPage
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
        If (5 < Me.TabCount) Then
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
    Private WithEvents mUnit As Unit
    Private mWorldWindow As WorldWindow
    Private mWinSRFR As WinSRFR
    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    Public Sub LinkToModel(ByVal _unit As Unit, ByVal _worldForm As WorldWindow)

        If (_unit IsNot Nothing) Then

            ' Link this control to its model
            mUnit = _unit
            mWorldWindow = _worldForm
            mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef

            mResultsView = WinSRFR.UserPreferences.ResultsView

            ' Update this control's User Interface
            UpdateUI()
        End If
    End Sub

#End Region

#Region " Display Results Methods "

#Region " Simulation Results "

    '*********************************************************************************************************
    ' DisplaySimulationResults() - displays the SRFR simulation results in the Results Control.
    '
    Private Sub DisplaySimulationResults()

        If (mUnit IsNot Nothing) Then
            '
            ' Get data references
            '
            Dim _srfrCriteria As SrfrCriteria = mUnit.SrfrCriteriaRef
            Dim _systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
            Dim _soilCropProperties As SoilCropProperties = mUnit.SoilCropPropertiesRef
            Dim _inflowManagement As InflowManagement = mUnit.InflowManagementRef
            Dim _surfaceFlow As SurfaceFlow = mUnit.SurfaceFlowRef
            Dim _subsurfaceFlow As SubsurfaceFlow = mUnit.SubsurfaceFlowRef
            Dim _erosion As Erosion = mUnit.ErosionRef
            Dim _fertigation As Fertigation = mUnit.FertigationRef
            Dim _performanceResults As PerformanceResults = mUnit.PerformanceResultsRef
            '
            ' Check for SRFR error
            '
            Dim errorCount As Integer = _performanceResults.ErrorCount.Value
            Dim errorStack As ArrayList = _performanceResults.ErrorStack.Array

            If (0 < errorCount) Then
                ' There is at least one SRFR error
                Dim tErrors As String = mDictionary.tErrors.Translated

                Dim page As RtfPage = GetNewResultsPage(tErrors, ResultsView)
                page.AccessibleName = tErrors
                page.AccessibleDescription = "SRFR " & mDictionary.tErrExecution.Translated

                Dim rtf As RichTextBox = page.Rtf

                AppendBoldLine(rtf, mDictionary.tErrExecutionStoppedDueTo.Translated & " " & tErrors & ":")

                For edx As Integer = 0 To errorCount - 1
                    Dim _srfrError As Integer = CInt(errorStack(edx))
                    edx += 1
                    Dim srfrMsg As String = CStr(errorStack(edx))
                    AdvanceLine(rtf)
                    AppendLine(rtf, _srfrError.ToString & " - " & srfrMsg)
                Next

                AddTabPage(tErrors, page)

                Return
            End If
            '
            ' There are no SRFR errors; display the Simulation Results
            '
            Dim L As Double = _systemGeometry.Length.Value                      ' Field length
            Dim Tco As Double = _surfaceFlow.Tco.Value                          ' Final Tco
            Dim Dreq As Double = _inflowManagement.RequiredDepth.Value          ' Target infiltration depth
            Dim xyGraph As grf_XYGraph                                          ' XY graph class
            Dim x2yGraph As grf_X2YGraph                                        ' X2Y graph class

            ' Which result pages to display depends on User Level & Options
            Select Case (mWinSRFR.UserLevel)
                Case UserLevels.Standard
                    mPageNumber = 0
                    mTotalPages = 10
                Case UserLevels.Advanced
                    mPageNumber = 0
                    mTotalPages = 10
                Case UserLevels.Research
                    mPageNumber = 0
                    mTotalPages = 13
            End Select

            ' Is Erosion checked?
            If (_erosion.EnableErosion.Value) Then
                mTotalPages += 4
            End If

            ' Is Fertigation checked?
            If (_fertigation.EnableFertigation.Value) Then
                If (_fertigation.CharacteristicType.Value = Srfr.ConstituentTransport.CharacteristicTypes.Continuous) Then
                    mTotalPages += 4
                Else
                    mTotalPages += 3
                End If
            End If

            ' Is HYDRUS used?
            If (_soilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then
                mTotalPages += 1
            End If

            '*************************************************************************************************
            ' Simulation Summary page + Performance Indicators
            '
            mSimulationSummaryPage = Nothing

            Dim title As String = mDictionary.tSummary.Translated
            Dim pageTitle As String = title
            Dim tabName As String = title
            '
            ' Full Page view for Display, Print & Print Preview
            '
            AddSimulationSummaryPage(pageTitle, tabName)

            '*************************************************************************************************
            ' Hydraulic Summary
            '
            Dim tHydraulicSummary As String = mDictionary.tHydraulicSummary.Translated

            Dim advRecHS As DataSet = New DataSet(tHydraulicSummary)        ' Advance / Recession
            Dim infiltrationHS As DataSet = New DataSet(tHydraulicSummary)  ' Infiltration / Target Depth
            Dim hydrographsHS As DataSet = New DataSet(tHydraulicSummary)   ' Inflow / Runoff

            Dim advance As DataTable = _surfaceFlow.Advance.Value
            Dim advanceSet As DataSet = _surfaceFlow.AdvanceSet.Value

            Dim recession As DataTable = _surfaceFlow.Recession.Value
            Dim recessionSet As DataSet = _surfaceFlow.RecessionSet.Value

            Dim infiltration As DataTable = _subsurfaceFlow.LongitudinalInfiltration.Value
            infiltration.ExtendedProperties.Add("Color", Drawing.Color.Black)

            Dim flowHydrographs As DataTable = _surfaceFlow.FlowHydrographs.Value

            ' Infiltration / Target Depth
            Dim dreqTab As DataTable = DreqTable(Dreq, infiltration.Columns(0).ColumnName, L)
            dreqTab.ExtendedProperties.Add("Color", Drawing.Color.Blue)

            If (DataTableHasData(advance) _
            And DataTableHasData(infiltration) _
            And DataTableHasData(flowHydrographs)) Then

                ' Advance / Recession curves
                If (DataSetHasData(advanceSet)) Then
                    For Each advTable As DataTable In advanceSet.Tables
                        advTable.ExtendedProperties.Add("Color", Drawing.Color.Blue)
                        advRecHS.Tables.Add(advTable.Copy)
                    Next
                Else
                    advance.ExtendedProperties.Add("Color", Drawing.Color.Blue)
                    advRecHS.Tables.Add(advance.Copy)
                End If

                If (DataSetHasData(recessionSet)) Then
                    For Each recTable As DataTable In recessionSet.Tables
                        recTable.ExtendedProperties.Add("Color", Drawing.Color.Brown)
                        advRecHS.Tables.Add(recTable.Copy)
                    Next
                Else
                    recession.ExtendedProperties.Add("Color", Drawing.Color.Brown)
                    advRecHS.Tables.Add(recession.Copy)
                End If

                ' Infiltration curve
                infiltrationHS.Tables.Add(infiltration.Copy)
                infiltrationHS.Tables.Add(dreqTab.Copy)

                ' Flow Hydrographs curves (includes Inflow & Runoff)
                hydrographsHS.Tables.Add(flowHydrographs.Copy)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewHydraulicSummaryPage(advRecHS, infiltrationHS, hydrographsHS, tHydraulicSummary)
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPage(tHydraulicSummary, tHydraulicSummary, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewHydraulicSummaryPanel(advRecHS, infiltrationHS, hydrographsHS, tHydraulicSummary)
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPanel(tHydraulicSummary, tHydraulicSummary, xyGraph)

            End If

            '*************************************************************************************************
            ' Advance
            '
            Dim tAdvance As String = mDictionary.tAdvance.Translated
            Dim tDistance As String = mDictionary.tDistance.Translated
            Dim tTime As String = mDictionary.tTime.Translated

            Dim advDataSet As DataSet = New DataSet(" " & tAdvance & " ")

            If DataTableHasData(advance) Then

                If (DataSetHasData(advanceSet)) Then
                    For Each advTable As DataTable In advanceSet.Tables
                        advTable.Columns(0).ColumnName = tDistance
                        advTable.Columns(1).ColumnName = tTime
                        advDataSet.Tables.Add(advTable.Copy)
                    Next
                Else
                    advance.Columns(0).ColumnName = tDistance
                    advance.Columns(1).ColumnName = tTime
                    advDataSet.Tables.Add(advance.Copy)
                End If
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(advDataSet, tAdvance)
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Seconds
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0

                AddResultsPage(tAdvance, tAdvance, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(advDataSet, tAdvance)
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Seconds
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0

                AddResultsPanel(tAdvance, tAdvance, xyGraph)

            End If

            '*************************************************************************************************
            ' Advance & Recession
            '
            Dim tAdvanceRecession As String = mDictionary.tAdvance.Translated & " / " & mDictionary.tRecession.Translated

            Dim advRecDataSet As DataSet = New DataSet(tAdvanceRecession)

            If DataTableHasData(advance) Then

                If (DataSetHasData(advanceSet)) Then
                    For Each advTable As DataTable In advanceSet.Tables
                        advance.Columns(0).ColumnName = tDistance
                        advance.Columns(1).ColumnName = tTime
                        advRecDataSet.Tables.Add(advTable.Copy)
                    Next
                Else
                    advRecDataSet.Tables.Add(advance.Copy)
                End If

                If (DataSetHasData(recessionSet)) Then
                    For Each recTable As DataTable In recessionSet.Tables
                        recTable.Columns(0).ColumnName = tDistance
                        recTable.Columns(1).ColumnName = tTime
                        advRecDataSet.Tables.Add(recTable.Copy)
                    Next
                Else
                    recession.Columns(0).ColumnName = tDistance
                    recession.Columns(1).ColumnName = tTime
                    advRecDataSet.Tables.Add(recession.Copy)
                End If
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(advRecDataSet, tAdvanceRecession)
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Seconds
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0

                AddResultsPage(tAdvanceRecession, tAdvanceRecession, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(advRecDataSet, tAdvanceRecession)
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Seconds
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0

                AddResultsPanel(tAdvanceRecession, tAdvanceRecession, xyGraph)

            End If

            '*************************************************************************************************
            ' Infiltration
            '
            Dim tInfiltration As String = mDictionary.tInfiltration.Translated

            Dim infiltrationDataSet As DataSet = New DataSet(" " & tInfiltration & " ")

            If DataTableHasData(infiltration) Then

                infiltration.Columns(0).ColumnName = tDistance
                infiltration.Columns(1).ColumnName = tInfiltration

                Dim srfrInfiltration As DataTable = infiltration.Copy

                infiltrationDataSet.Tables.Add(srfrInfiltration)

                If (_soilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then
                    Dim hydrusInfiltration As DataTable = _soilCropProperties.HydrusInfiltrationTable

                    If (DataTableHasData(hydrusInfiltration)) Then
                        srfrInfiltration.ExtendedProperties.Add("Key", True)

                        hydrusInfiltration.Columns(0).ColumnName = tDistance
                        hydrusInfiltration.Columns(1).ColumnName = tInfiltration

                        hydrusInfiltration.ExtendedProperties.Add("Symbol", "X")
                        hydrusInfiltration.ExtendedProperties.Add("Key", True)
                        hydrusInfiltration.ExtendedProperties.Add("Color", Drawing.Color.Black)

                        infiltrationDataSet.Tables.Add(hydrusInfiltration)
                    End If
                End If

                infiltrationDataSet.Tables.Add(dreqTab.Copy)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(infiltrationDataSet, Nothing)
                xyGraph.DisplayKey = True
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                xyGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
                xyGraph.MinY = 0.0 ' Start Infiltration graph at top of soil

                AddResultsPage(tInfiltration, tInfiltration, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(infiltrationDataSet, tInfiltration)
                xyGraph.DisplayKey = True
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                xyGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
                xyGraph.MinY = 0.0 ' Start Infiltration graph at top of soil

                AddResultsPanel(tInfiltration, tInfiltration, xyGraph)

            End If

            '*************************************************************************************************
            ' Upstream Infiltration Function
            '*************************************************************************************************
            'Dim tUpstreamInfiltration As String = mDictionary.tUpstreamInfiltration.Translated
            Dim tInfiltrationFunction As String = mDictionary.tInfiltrationFunction.Translated

            Dim upstsreamDataSet As DataSet = New DataSet(tInfiltrationFunction)
            Dim upstreamInfiltration As DataTable = _subsurfaceFlow.UpstreamInfiltrationFunction.Value
            Dim upstreamInfiltrationDepth As DataTable = _subsurfaceFlow.UpstreamInfiltrationDepthFunction.Value

            If (DataTableHasData(upstreamInfiltration) And DataTableHasData(upstreamInfiltrationDepth)) Then

                upstreamInfiltration.Columns(0).ColumnName = tTime
                upstreamInfiltration.Columns(1).ColumnName = "AZ"
                upstreamInfiltration.TableName = "AZ"

                upstreamInfiltrationDepth.Columns(0).ColumnName = tTime
                If (mUnit.CrossSection = CrossSections.Furrow) Then
                    upstreamInfiltrationDepth.Columns(1).ColumnName = "AZ/FS"
                    upstreamInfiltrationDepth.TableName = "AZ/FS"
                Else
                    upstreamInfiltrationDepth.Columns(1).ColumnName = "AZ/W"
                    upstreamInfiltrationDepth.TableName = "AZ/W"
                End If
                upstreamInfiltrationDepth.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                upstsreamDataSet.Tables.Add(upstreamInfiltration.Copy)
                upstsreamDataSet.Tables.Add(upstreamInfiltrationDepth.Copy)

                ' Add Dreq line as Time vs. Dreq
                Dim tMax As Double = upstreamInfiltration.Rows(upstreamInfiltration.Rows.Count - 1)(0)
                Dim dreqTime As DataTable = dreqTab.Copy
                dreqTime.Columns(0).ColumnName = sTimeX     ' was sDistanceX
                dreqTime.Rows(0)(0) = 0.0
                dreqTime.Rows(1)(0) = tMax                  ' was field length
                upstsreamDataSet.Tables.Add(dreqTime)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                x2yGraph = GetNewX2YGraphPage(upstsreamDataSet, tInfiltrationFunction)
                x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                x2yGraph.UnitsY = UnitsDefinition.Units.SquareMeters
                x2yGraph.UnitsY2 = UnitsDefinition.Units.Millimeters

                AddResultsPage(tInfiltrationFunction, tInfiltrationFunction, x2yGraph)
                '
                ' Graphic Only view for Display
                '
                x2yGraph = GetNewX2YGraphPanel(upstsreamDataSet, tInfiltrationFunction)
                x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                x2yGraph.UnitsY = UnitsDefinition.Units.SquareMeters
                x2yGraph.UnitsY2 = UnitsDefinition.Units.Millimeters

                AddResultsPanel(tInfiltrationFunction, tInfiltrationFunction, x2yGraph)
            End If

            '*********************************************************************************************
            ' Hydrographs (Flow)
            '*********************************************************************************************
            title = mDictionary.tHydrographs.Translated & " (" & mDictionary.tFlow.Translated & ")"
            pageTitle = title
            tabName = title

            Dim flowDataSet As DataSet = New DataSet(pageTitle)
            Dim maxHydroTime As Double = 0.0

            If DataTableHasData(flowHydrographs) Then

                Dim flowHydroCopy As DataTable = flowHydrographs.Copy

                flowHydroCopy.Columns(0).ColumnName = tTime

                ' Define left axis title
                Dim yUnits As Units = mUnitsSystem.DisplayUnits(Units.Cms)
                Dim axisTitle As String = "Flow Rate (" & UnitsText(yUnits) & ")"
                flowHydroCopy.ExtendedProperties.Add("LeftAxisTitle", axisTitle)

                ' Define Horizontal key strings
                For cdx As Integer = 1 To flowHydroCopy.Columns.Count - 1
                    Dim col As DataColumn = flowHydroCopy.Columns(cdx)
                    Dim colKey As String = col.ColumnName
                    If (colKey.StartsWith("Qin")) Then
                        colKey = "Qin"
                    ElseIf (colKey.StartsWith("Runoff")) Then
                        colKey = "Runoff"
                    Else
                        Dim idx1 As Integer = colKey.IndexOf("=") + 1
                        Dim idx2 As Integer = colKey.IndexOf("]")
                        colKey = colKey.Substring(idx1, idx2 - idx1)
                        Dim X As Double = 0.0
                        If (ParseLength(colKey, X)) Then
                            colKey = "X=" & LengthString(X)
                        Else
                            colKey = "n/a"
                        End If
                    End If
                    col.ExtendedProperties.Add("Key", True)
                    col.ExtendedProperties.Add("Key Text", colKey)
                Next cdx

                flowDataSet.Tables.Add(flowHydroCopy)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(flowDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.Cms
                xyGraph.CurveControlIsOn = True

                AddResultsPage(pageTitle, tabName, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(flowDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.Cms
                xyGraph.CurveControlIsOn = True

                AddResultsPanel(pageTitle, tabName, xyGraph)

                maxHydroTime = xyGraph.MaxX
            End If

            '*********************************************************************************************
            ' Hydrographs (Depth)
            '
            title = mDictionary.tHydrographs.Translated & " (" & mDictionary.tDepth.Translated & ")"
            pageTitle = title
            tabName = title

            Dim depthDataSet As DataSet = New DataSet(pageTitle)
            Dim depthHydrographs As DataTable = _surfaceFlow.DepthHydrographs.Value

            If DataTableHasData(depthHydrographs) Then

                Dim depthHydroCopy As DataTable = depthHydrographs.Copy

                depthHydroCopy.Columns(0).ColumnName = tTime

                ' Define left axis title
                Dim yUnits As Units = mUnitsSystem.DisplayUnits(Units.Millimeters)
                Dim axisTitle As String = "Depth (" & UnitsText(yUnits) & ")"
                depthHydroCopy.ExtendedProperties.Add("LeftAxisTitle", axisTitle)

                ' Define Horizontal key strings
                For cdx As Integer = 1 To depthHydroCopy.Columns.Count - 1
                    Dim col As DataColumn = depthHydroCopy.Columns(cdx)
                    Dim colKey As String = col.ColumnName

                    Dim idx1 As Integer = colKey.IndexOf("=") + 1
                    Dim idx2 As Integer = colKey.IndexOf("]")
                    colKey = colKey.Substring(idx1, idx2 - idx1)

                    Dim X As Double = 0.0
                    If (ParseLength(colKey, X)) Then
                        colKey = "X=" & LengthString(X)
                    Else
                        colKey = "n/a"
                    End If

                    col.ExtendedProperties.Add("Key", True)
                    col.ExtendedProperties.Add("Key Text", colKey)
                Next cdx

                depthDataSet.Tables.Add(depthHydroCopy)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(depthDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                xyGraph.CurveControlIsOn = True

                AddResultsPage(pageTitle, tabName, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(depthDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                xyGraph.CurveControlIsOn = True

                AddResultsPanel(pageTitle, tabName, xyGraph)
            End If

            '*********************************************************************************************
            ' Profile (Depth)
            '
            title = mDictionary.tProfiles.Translated & " (" & mDictionary.tDepth.Translated & ")"
            pageTitle = title
            tabName = title

            Dim depthProfileDataSet As DataSet = New DataSet(pageTitle)
            Dim depthProfile As DataTable = _surfaceFlow.DepthProfiles.Value

            If DataTableHasData(depthProfile) Then

                Dim depthProfileCopy As DataTable = depthProfile.Copy

                depthProfileCopy.Columns(0).ColumnName = tDistance

                ' Define left axis title
                Dim yUnits As Units = mUnitsSystem.DisplayUnits(Units.Millimeters)
                Dim axisTitle As String = "Depth (" & UnitsText(yUnits) & ")"
                depthProfileCopy.ExtendedProperties.Add("LeftAxisTitle", axisTitle)

                ' Define Horizontal key strings
                For cdx As Integer = 1 To depthProfileCopy.Columns.Count - 1
                    Dim col As DataColumn = depthProfileCopy.Columns(cdx)
                    Dim colKey As String = col.ColumnName

                    Dim idx1 As Integer = colKey.IndexOf("[") + 1
                    If (0 < idx1) Then
                        Dim idx2 As Integer = colKey.IndexOf("]")
                        colKey = colKey.Substring(idx1, idx2 - idx1)
                    Else
                        colKey = "Ymax"
                    End If

                    col.ExtendedProperties.Add("Key", True)
                    col.ExtendedProperties.Add("Key Text", colKey)
                Next cdx

                depthProfileDataSet.Tables.Add(depthProfileCopy)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(depthProfileDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0
                xyGraph.CurveControlIsOn = True

                AddResultsPage(pageTitle, tabName, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(depthProfileDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0
                xyGraph.CurveControlIsOn = True

                AddResultsPanel(pageTitle, tabName, xyGraph)
            End If

            '*********************************************************************************************
            ' Profile (Elevation)
            '
            title = mDictionary.tProfiles.Translated & " (" & mDictionary.tElevation.Translated & ")"
            pageTitle = title
            tabName = title

            Dim elevDataSet As DataSet = New DataSet(pageTitle)
            Dim elevProfile As DataTable = _surfaceFlow.ElevationProfiles.Value

            If DataTableHasData(elevProfile) Then

                Dim elevProfileCopy As DataTable = elevProfile.Copy

                elevProfileCopy.Columns(0).ColumnName = tDistance

                ' Define left axis title
                Dim yUnits As Units = mUnitsSystem.DisplayUnits(Units.Millimeters)
                Dim axisTitle As String = "H (" & UnitsText(yUnits) & ")"
                elevProfileCopy.ExtendedProperties.Add("LeftAxisTitle", axisTitle)

                ' Define Horizontal key strings
                For cdx As Integer = 1 To elevProfileCopy.Columns.Count - 1
                    Dim col As DataColumn = elevProfileCopy.Columns(cdx)
                    Dim colKey As String = col.ColumnName

                    Dim idx1 As Integer = colKey.IndexOf("[") + 1
                    If (0 < idx1) Then
                        Dim idx2 As Integer = colKey.IndexOf("]")
                        colKey = colKey.Substring(idx1, idx2 - idx1)
                    Else
                        If (cdx = 1) Then
                            colKey = "Hmax"
                        Else
                            colKey = "Hmin"
                        End If
                    End If

                    col.ExtendedProperties.Add("Key", True)
                    col.ExtendedProperties.Add("Key Text", colKey)
                Next cdx

                elevDataSet.Tables.Add(elevProfileCopy)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(elevDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0
                xyGraph.CurveControlIsOn = True

                AddResultsPage(pageTitle, tabName, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(elevDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0
                xyGraph.CurveControlIsOn = True

                AddResultsPanel(pageTitle, tabName, xyGraph)
            End If

            '*************************************************************************************************
            ' Erosion / Fertigation summary page(s)
            '
            If (_erosion.EnableErosion.Value) Then
                title = mDictionary.tErosion.Translated
                pageTitle = title
                tabName = title
                AddErosionSummaryPage(pageTitle, tabName)
            End If

            If (_fertigation.EnableFertigation.Value) Then
                title = mDictionary.tFertigation.Translated
                pageTitle = title
                tabName = title
                AddFertigationSummaryPage(pageTitle, tabName)
            End If

            '*************************************************************************************************
            ' Characteristics Net
            '
            pageTitle = mDictionary.tCharacteristicsNet.Translated
            Dim extTitle As String = "(" & mDictionary.tFertigation.Translated & ")"
            tabName = "XTICS Net"

            Dim xticsDataSet As DataSet = New DataSet(pageTitle)
            xticsDataSet.ExtendedProperties.Add("ExtTitle", extTitle)

            Dim grid As DataSet = Nothing
            Dim xtics As DataSet = Nothing

            If (_erosion.EnableErosion.Value) Then
                grid = _erosion.XticsGrid.Value
                xtics = _erosion.Xtics.Value
            ElseIf (_fertigation.EnableFertigation.Value) Then
                ' disabled 08/29/2018
                'grid = _fertigation.XticsGrid.Value
                'xtics = _fertigation.Xtics.Value
            End If

            If (DataSetHasData(grid) And DataSetHasData(xtics)) Then

                ' Add the grid
                grid.ExtendedProperties.Add("Color", Drawing.Color.LightGray) ' WhiteSmoke
                xticsDataSet.ExtendedProperties.Add("Grid", grid)

                ' Add the Characteristics
                Dim tcoMarked As Boolean = False

                For Each xtic As DataTable In xtics.Tables
                    Dim copy As DataTable = xtic.Copy
                    Dim row0 As DataRow = copy.Rows(0)
                    Dim TX As Double = row0.Item(sTXs)

                    If ((Not tcoMarked) And (TX = Tco)) Then
                        tcoMarked = True
                        copy.ExtendedProperties.Add("Color", Drawing.Color.Black)
                        'copy.ExtendedProperties.Add("Label", "Tco")
                    Else
                        Dim name As String = copy.TableName
                        Dim tokens As String() = name.Split(" ".ToCharArray)

                        If (1 < tokens.Length) Then
                            Dim num As Integer = Integer.Parse(tokens(1))

                            If (xtic.ExtendedProperties.Contains("Type")) Then
                                Dim _obj As Object = xtic.ExtendedProperties.Item("Type")
                                If (_obj.GetType Is GetType(String)) Then
                                    Dim type As String = DirectCast(_obj, String)
                                    If (type = "Fertigation") Then
                                        copy.ExtendedProperties.Add("Color", Drawing.Color.SeaGreen)
                                    Else
                                        copy.ExtendedProperties.Add("Color", Drawing.Color.DarkSeaGreen)
                                    End If
                                End If
                            Else
                                copy.ExtendedProperties.Add("Color", Drawing.Color.DarkSeaGreen)
                            End If
                        End If
                    End If

                    xticsDataSet.Tables.Add(copy)
                Next

                ' Add Advance & Recession last so they draws last (i.e. on top)
                If (DataSetHasData(advanceSet)) Then
                    For Each advTable As DataTable In advanceSet.Tables
                        xticsDataSet.Tables.Add(advTable.Copy)
                    Next
                Else
                    xticsDataSet.Tables.Add(advance.Copy)
                End If

                If (DataSetHasData(recessionSet)) Then
                    For Each recTable As DataTable In recessionSet.Tables
                        xticsDataSet.Tables.Add(recTable.Copy)
                    Next
                Else
                    xticsDataSet.Tables.Add(recession.Copy)
                End If
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(xticsDataSet, pageTitle)
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPage(pageTitle, tabName, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(xticsDataSet, pageTitle)
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPanel(pageTitle, tabName, xyGraph)

            End If ' DataSetHasData - XTICS & Grid

            '*************************************************************************************************
            ' Hydrographs (Mass Transport)
            '
            title = mDictionary.tHydrographs.Translated & " (" & mDictionary.tMassTransport.Translated & ")"
            pageTitle = title
            tabName = title

            Dim massTransportDataSet As DataSet = New DataSet(pageTitle)
            Dim massTransportHydrograph As DataTable = _erosion.MassTransportHydrographs.Value

            If DataTableHasData(massTransportHydrograph) Then

                If (mUnitsSystem.UnitSystem = UnitSystems.English) Then
                    massTransportHydrograph.ExtendedProperties.Add("LeftAxisTitle", mDictionary.tMassTransport.Translated & " (lb/s)")
                Else
                    massTransportHydrograph.ExtendedProperties.Add("LeftAxisTitle", mDictionary.tMassTransport.Translated & " (g/s)")
                End If
                massTransportDataSet.Tables.Add(massTransportHydrograph.Copy)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(massTransportDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.KilogramsPerSecond
                xyGraph.MaxX = maxHydroTime

                AddResultsPage(pageTitle, tabName, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(massTransportDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.KilogramsPerSecond
                xyGraph.MaxX = maxHydroTime

                AddResultsPanel(pageTitle, tabName, xyGraph)
            End If

            '*************************************************************************************************
            ' Hydrographs (Mass Concentration)
            '
            title = mDictionary.tHydrographs.Translated & " (" & mDictionary.tMassConcentration.Translated & ")"
            pageTitle = title
            tabName = title

            Dim massConcentrationDataSet As DataSet = New DataSet(pageTitle)
            Dim massConcentrationHydrograph As DataTable = _erosion.MassConcentrationHydrographs.Value

            If DataTableHasData(massConcentrationHydrograph) Then

                If (mUnitsSystem.UnitSystem = UnitSystems.English) Then
                    massConcentrationHydrograph.ExtendedProperties.Add("LeftAxisTitle", mDictionary.tMassConcentration.Translated & " (lb/ft³)")
                Else
                    massConcentrationHydrograph.ExtendedProperties.Add("LeftAxisTitle", mDictionary.tMassConcentration.Translated & " (g/l)")
                End If
                massConcentrationDataSet.Tables.Add(massConcentrationHydrograph.Copy)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(massConcentrationDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.GramsPerLiter
                xyGraph.MaxX = maxHydroTime

                AddResultsPage(pageTitle, tabName, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(massConcentrationDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.GramsPerLiter
                xyGraph.MaxX = maxHydroTime

                AddResultsPanel(pageTitle, tabName, xyGraph)
            End If

            '*************************************************************************************************
            ' Profiles (Fertigation) - Application Density
            '
            title = mDictionary.tProfiles.Translated & " (" & mDictionary.tFertigation.Translated & ")"
            pageTitle = title
            tabName = title

            Dim densityDataSet As DataSet = New DataSet(pageTitle)
            Dim densityProfiles As DataTable = _fertigation.DensityProfiles.Value

            If DataTableHasData(densityProfiles) Then

                densityProfiles.ExtendedProperties.Add("LeftAxisTitle", mDictionary.tApplicationDensity.Translated & " (g/m)")

                Dim densityTable As DataTable = densityProfiles.Copy
                For cdx As Integer = 1 To densityTable.Columns.Count - 1
                    Dim col As DataColumn = densityTable.Columns(cdx)
                    col.ExtendedProperties.Add("Key", True)
                Next cdx

                densityDataSet.Tables.Add(densityTable)

                If (_soilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then
                    Dim hydrusDensity As DataTable = _soilCropProperties.HydrusDensityTable

                    If (DataTableHasData(hydrusDensity)) Then
                        hydrusDensity.ExtendedProperties.Add("Symbol", "X")
                        hydrusDensity.ExtendedProperties.Add("Key", True)
                        hydrusDensity.ExtendedProperties.Add("Color", Drawing.Color.Black)

                        densityDataSet.Tables.Add(hydrusDensity)
                    End If
                End If
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(densityDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.GramsPerMeter
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0
                xyGraph.CurveControlIsOn = True

                AddResultsPage(pageTitle, tabName, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(densityDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Meters
                xyGraph.UnitsY = UnitsDefinition.Units.GramsPerMeter
                xyGraph.MinX = 0.0
                xyGraph.MaxX = L
                xyGraph.MinY = 0.0
                xyGraph.CurveControlIsOn = True

                AddResultsPanel(pageTitle, tabName, xyGraph)
            End If

            '*********************************************************************************************
            ' Hydrographs (Fertigation) - Concentration
            '
            title = mDictionary.tHydrographs.Translated & " (" & mDictionary.tFertigation.Translated & ")"
            pageTitle = title
            tabName = title

            Dim concentrationDataSet As DataSet = New DataSet(pageTitle)
            Dim concentrationHydrographs As DataTable = _fertigation.ConcentrationHydrographs.Value

            If DataTableHasData(concentrationHydrographs) Then

                concentrationHydrographs.ExtendedProperties.Add("LeftAxisTitle", mDictionary.tConcentration.Translated & " (g/l)")

                Dim concentrationTable As DataTable = concentrationHydrographs.Copy
                For cdx As Integer = 1 To concentrationTable.Columns.Count - 1
                    Dim col As DataColumn = concentrationTable.Columns(cdx)
                    col.ExtendedProperties.Add("Key", True)
                Next cdx

                concentrationDataSet.Tables.Add(concentrationTable)
                '
                ' Full Page view for Display, Print & Print Preview
                '
                xyGraph = GetNewXYGraphPage(concentrationDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.GramsPerLiter
                xyGraph.MaxX = maxHydroTime
                xyGraph.CurveControlIsOn = True

                AddResultsPage(pageTitle, tabName, xyGraph)
                '
                ' Graphic Only view for Display
                '
                xyGraph = GetNewXYGraphPanel(concentrationDataSet, pageTitle)
                xyGraph.DisplayKey = True
                xyGraph.HorizontalKeys = True
                xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                xyGraph.UnitsY = UnitsDefinition.Units.GramsPerLiter
                xyGraph.MaxX = maxHydroTime
                xyGraph.CurveControlIsOn = True

                AddResultsPanel(pageTitle, tabName, xyGraph)
            End If

            '*************************************************************************************************
            ' HYDRUS Infiltration Rate
            '
            If (_soilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then
                Dim tHydrusInfiltrationRate As String = mDictionary.tHydrusInfiltrationRate.Translated
                Dim hydrusInfiltration As DataSet = _soilCropProperties.HydrusInfiltrationRate.Value

                If DataSetHasData(hydrusInfiltration) Then

                    hydrusInfiltration.DataSetName = tHydrusInfiltrationRate

                    For Each table As DataTable In hydrusInfiltration.Tables
                        table.ExtendedProperties.Add("Key", True)
                    Next
                    '
                    ' Full Page view for Display, Print & Print Preview
                    '
                    xyGraph = GetNewXYGraphPage(hydrusInfiltration, Nothing)
                    xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                    xyGraph.UnitsY = UnitsDefinition.Units.MillimetersPerHour
                    xyGraph.PosDirY = grf_XYGraph.PositiveDirection.PosUp
                    xyGraph.DisplayKey = True
                    xyGraph.HorizontalKeys = True
                    xyGraph.MinY = 0.0
                    xyGraph.CurveControlIsOn = True

                    AddResultsPage(tHydrusInfiltrationRate, tHydrusInfiltrationRate, xyGraph)
                    '
                    ' Graphic Only view for Display
                    '
                    xyGraph = GetNewXYGraphPanel(hydrusInfiltration, tHydrusInfiltrationRate)
                    xyGraph.UnitsX = UnitsDefinition.Units.Seconds
                    xyGraph.UnitsY = UnitsDefinition.Units.MillimetersPerHour
                    xyGraph.PosDirY = grf_XYGraph.PositiveDirection.PosUp
                    xyGraph.DisplayKey = True
                    xyGraph.HorizontalKeys = True
                    xyGraph.MinY = 0.0
                    xyGraph.CurveControlIsOn = True

                    AddResultsPanel(tHydrusInfiltrationRate, tHydrusInfiltrationRate, xyGraph)

                End If ' DataSetHasData
            End If ' InfiltrationFunctions.Hydrus1D

            If (mWinSRFR.IsResearchLevel) Then ' add Research Results tabs

                '*********************************************************************************************
                ' Profiles (AY average / Sy)
                '
                pageTitle = "AY Avg / Sy"
                tabName = "AY Avg / Sy"

                Dim AYavg As DataTable = _surfaceFlow.AYavgProfile.Value
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
                    '
                    ' Full Page view for Display, Print & Print Preview
                    '
                    x2yGraph = Me.GetNewX2YGraphPage(AYset, pageTitle)
                    x2yGraph.DisplayKey = True

                    If (AyTable.Columns(0).ColumnName = tTime) Then
                        x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                    Else
                        x2yGraph.UnitsX = UnitsDefinition.Units.Meters
                    End If

                    x2yGraph.UnitsY = mUnitsSystem.FlowAreaUnits ' UnitsDefinition.Units.SquareMeters
                    x2yGraph.UnitsY2 = UnitsDefinition.Units.None
                    x2yGraph.MaxY2 = 1.0

                    AddResultsPage(pageTitle, tabName, x2yGraph)
                    '
                    ' Graphic Only view for Display
                    '
                    x2yGraph = GetNewX2YGraphPanel(AYset, pageTitle)
                    x2yGraph.DisplayKey = True

                    If (AyTable.Columns(0).ColumnName = tTime) Then
                        x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                    Else
                        x2yGraph.UnitsX = UnitsDefinition.Units.Meters
                    End If

                    x2yGraph.UnitsY = mUnitsSystem.FlowAreaUnits ' UnitsDefinition.Units.SquareMeters
                    x2yGraph.UnitsY2 = UnitsDefinition.Units.None
                    x2yGraph.MaxY2 = 1.0

                    AddResultsPanel(pageTitle, tabName, x2yGraph)
                End If

                '*********************************************************************************************
                ' Profiles (AZ average / Sz)
                '
                pageTitle = "AZ Avg / Sz"
                tabName = "AZ Avg / Sz"

                Dim AZavg As DataTable = _subsurfaceFlow.AZavgProfile.Value
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
                    '
                    ' Full Page view for Display, Print & Print Preview
                    '
                    x2yGraph = Me.GetNewX2YGraphPage(AZset, pageTitle)
                    x2yGraph.DisplayKey = True

                    If (AzTable.Columns(0).ColumnName = tTime) Then
                        x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                    Else
                        x2yGraph.UnitsX = UnitsDefinition.Units.Meters
                    End If

                    x2yGraph.UnitsY = mUnitsSystem.FlowAreaUnits ' UnitsDefinition.Units.SquareMeters
                    x2yGraph.UnitsY2 = UnitsDefinition.Units.None
                    x2yGraph.MaxY2 = 1.0

                    AddResultsPage(pageTitle, tabName, x2yGraph)
                    '
                    ' Graphic Only view for Display
                    '
                    x2yGraph = GetNewX2YGraphPanel(AZset, pageTitle)
                    x2yGraph.DisplayKey = True

                    If (AzTable.Columns(0).ColumnName = tTime) Then
                        x2yGraph.UnitsX = UnitsDefinition.Units.Seconds
                    Else
                        x2yGraph.UnitsX = UnitsDefinition.Units.Meters
                    End If

                    x2yGraph.UnitsY = mUnitsSystem.FlowAreaUnits ' UnitsDefinition.Units.SquareMeters
                    x2yGraph.UnitsY2 = UnitsDefinition.Units.None
                    x2yGraph.MaxY2 = 1.0

                    AddResultsPanel(pageTitle, tabName, x2yGraph)
                End If

                '*********************************************************************************************
                ' Infiltration (Ordered)
                '
                Dim tInfiltrationOrdered As String = mDictionary.tInfiltrationOrdered.Translated

                Dim orderedDataSet As DataSet = New DataSet(" " & tInfiltrationOrdered & " ")
                Dim orderedInfiltration As DataTable = _subsurfaceFlow.OrderedInfiltration.Value

                If DataTableHasData(orderedInfiltration) Then

                    orderedInfiltration.Columns(0).ColumnName = mDictionary.tArea.Translated
                    orderedInfiltration.Columns(1).ColumnName = tInfiltration

                    Dim _dreq As DataTable = DreqTable(Dreq, infiltration.Columns(0).ColumnName, 1.0)
                    _dreq.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                    orderedDataSet.Tables.Add(orderedInfiltration.Copy)
                    orderedDataSet.Tables.Add(_dreq)
                    '
                    ' Full Page view for Display, Print & Print Preview
                    '
                    xyGraph = GetNewXYGraphPage(orderedDataSet, tInfiltrationOrdered)
                    xyGraph.UnitsX = UnitsDefinition.Units.Percentage
                    xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                    xyGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
                    xyGraph.MinY = 0.0 ' Start Infiltration graph at top of soil

                    AddResultsPage(tInfiltrationOrdered, tInfiltrationOrdered, xyGraph)
                    '
                    ' Graphic Only view for Display
                    '
                    xyGraph = GetNewXYGraphPanel(orderedDataSet, tInfiltrationOrdered)
                    xyGraph.UnitsX = UnitsDefinition.Units.Percentage
                    xyGraph.UnitsY = UnitsDefinition.Units.Millimeters
                    xyGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
                    xyGraph.MinY = 0.0 ' Start Infiltration graph at top of soil

                    AddResultsPanel(tInfiltrationOrdered, tInfiltrationOrdered, xyGraph)
                End If

            End If ' (mWinSRFR.UserLevel = UserLevels.Research)

        End If ' (mUnit IsNot Nothing)

    End Sub

    '*********************************************************************************************************
    ' Add & Update Simulation Summary page
    '
    Private Sub AddSimulationSummaryPage(ByVal title As String, ByVal tabName As String)

        Debug.Assert((title IsNot Nothing) And (tabName IsNot Nothing))

        ' Full Page view for Display, Print & Print Preview
        mSimulationSummaryRtfPage = GetNewResultsPage(title, ResultsView)
        mSimulationSummaryPage = mSimulationSummaryRtfPage.Rtf
        mSimulationSummaryPage.WordWrap = False
        mSimulationSummaryPage.ScrollBars = RichTextBoxScrollBars.None

        mSimulationSummaryRtfPage.AccessibleName = title
        mSimulationSummaryRtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Srfr Parameters
        mPageNumber += 1
        mSimulationSummaryPageNumber = mPageNumber
        UpdateSimulationSummaryPage()

        ' Make the Full Page visible
        AddTabPage(tabName, mSimulationSummaryRtfPage)

    End Sub

    Private Sub UpdateSimulationPages()
        If (mUnit IsNot Nothing) Then
            UpdateSimulationSummaryPage()
        End If
    End Sub

    Private mSimulationSummaryPageNumber As Integer
    Private Sub UpdateSimulationSummaryPage()

        If (mSimulationSummaryPage IsNot Nothing) Then

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

            ' mSimulationParametersPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mSimulationSummaryPage.Clear()

                ' Add Header
                DisplayResultsHeader(mSimulationSummaryPage)
                '
                ' Add the Input Parameters
                '
                mSimulationSummaryPage.SelectionAlignment = HorizontalAlignment.Left

                AdvanceLines(mSimulationSummaryPage, 2)
                AppendBoldUnderlineText(mSimulationSummaryPage, mDictionary.tInputParameters.Translated)
                AppendText(mSimulationSummaryPage, " - ")
                AppendBoldText(mSimulationSummaryPage, mDictionary.tSolutionModel.Translated)
                AppendText(mSimulationSummaryPage, ": ")
                AppendLine(mSimulationSummaryPage, SolutionModelSelections(_solmod).Value)

                DisplaySystemGeometryParameters(mSimulationSummaryPage)
                DisplayInfiltrationParameters(mSimulationSummaryPage)
                DisplayRoughnessParameters(mSimulationSummaryPage)
                DisplayInflowManagementParameters(mSimulationSummaryPage)
                '
                ' Add the Calculated Performance Indicators
                '
                AdvanceLine(mSimulationSummaryPage)
                AppendBoldUnderlineText(mSimulationSummaryPage, mDictionary.tSimulationPerformanceIndicators.Translated)

                If (mUnit.SurfaceFlowRef.Overflow.Value) Then
                    Dim _time As String = TimeString(mUnit.SurfaceFlowRef.OverflowTime.Value, 0)
                    Dim _dist As String = LengthString(mUnit.SurfaceFlowRef.OverflowDist.Value, 0)
                    AppendLine(mSimulationSummaryPage, " - " & mDictionary.tOverflowAt.Translated & " " & _time & ", " & _dist)
                Else
                    AdvanceLine(mSimulationSummaryPage)
                End If

                ' Hydraulic Summary
                AdvanceLine(mSimulationSummaryPage)
                AppendBoldLine(mSimulationSummaryPage, mDictionary.tHydraulicSummary.Translated)

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
                AppendText(mSimulationSummaryPage, _text)

                Dim _Dinf As DoubleParameter = _subsurfaceFlow.Davg
                If ((_Dapp.Value - HalfMillimeter < _Dinf.Value) And (_Dinf.Value < _Dapp.Value + HalfMillimeter)) Then
                    _Dinf.Value = _Dapp.Value
                End If
                _name = (_Dinf.Symbol & "      ").Substring(0, 6)
                _value = (_Dinf.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                Dim _Dro As DoubleParameter
                _Dro = _surfaceFlow.ROd
                _name = ("Dro" & "      ").Substring(0, 6)
                _value = (_Dro.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendLine(mSimulationSummaryPage, _text)

                ' Line 2
                Dim _Ddp As DoubleParameter
                _Ddp = _subsurfaceFlow.DP
                _name = ("Ddp" & "      ").Substring(0, 6)
                _value = (_Ddp.ValueString & "                   ").Substring(0, 19)
                _text = "  " & _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _subsurfaceFlow.Dmin
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _subsurfaceFlow.Dlq
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendLine(mSimulationSummaryPage, _text)

                ' Line 3
                _double = _surfaceFlow.Tco
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = "  " & _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _surfaceFlow.TL
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _surfaceFlow.XaR
                _name = ("XR     ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendLine(mSimulationSummaryPage, _text)

                ' Line 4
                _double = _surfaceFlow.Xmax
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = "  " & _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _surfaceFlow.Ymax
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                If (_systemGeometry.UpstreamCondition.Value = UpstreamConditions.DrainbackAfterCutoff) Then
                    _double = _surfaceFlow.Ddb
                    _name = (_double.Symbol & "      ").Substring(0, 6)
                    _value = (_double.ValueString & "                   ").Substring(0, 19)
                    _text = _name & " = " & _value
                Else ' If (WinSRFR.DebuggerIsAttached) Then
                    _double = _surfaceFlow.VerrPct
                    _name = (_double.Symbol & "      ").Substring(0, 6)
                    _value = (Format(_double.Value * 100, "#0.00") & " %                   ").Substring(0, 19)
                    _text = _name & " = " & _value
                End If
                AppendLine(mSimulationSummaryPage, _text)

                ' Line 5
                If (mUnit.CrossSection = CrossSections.Furrow) Then
                    If (_soilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter) Then
                        AdvanceLine(mSimulationSummaryPage)
                        _double = _surfaceFlow.RepresentativeWettedPerimeter
                        _text = _double.FullXlateText
                        AppendLine(mSimulationSummaryPage, _text)
                    ElseIf (_soilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
                        AdvanceLine(mSimulationSummaryPage)
                        _double = _surfaceFlow.NrcsWettedPerimeter
                        _text = _double.FullXlateText
                        AppendLine(mSimulationSummaryPage, _text)
                    End If
                End If

                ' Efficiency & Uniformity Indicators
                AdvanceLine(mSimulationSummaryPage)
                AppendBoldLine(mSimulationSummaryPage, mDictionary.tEfficiencyUniformityIndicators.Translated)

                ' Line 1
                _double = _subsurfaceFlow.AE
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = "  " & _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _subsurfaceFlow.RE
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendLine(mSimulationSummaryPage, _text)

                ' Line 2
                _double = _subsurfaceFlow.DUmin
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = "  " & _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _subsurfaceFlow.ADmin
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendLine(mSimulationSummaryPage, _text)

                ' Line 3
                _double = _subsurfaceFlow.DUlq
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = "  " & _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _subsurfaceFlow.ADlq
                _name = (_double.Symbol & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendLine(mSimulationSummaryPage, _text)

                ' Costs
                AdvanceLine(mSimulationSummaryPage)
                AppendBoldLine(mSimulationSummaryPage, mDictionary.tCosts.Translated)

                _double = _inflowManagement.Cost
                _name = ("Total" & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = "  " & _name & " = " & _value
                AppendLine(mSimulationSummaryPage, _text)
                Dim _cost As Double = _double.Value

                ' Costs & Percentages
                _double = _subsurfaceFlow.DPpct
                _name = (" DP " & "      ").Substring(0, 6)
                _value = (AreaCostString(_double.Value * _cost, 0) & "                   ").Substring(0, 19)
                _text = "  " & _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _subsurfaceFlow.DPpct
                _name = ("DP%" & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendLine(mSimulationSummaryPage, _text)

                _double = _surfaceFlow.ROpct
                _name = (" RO " & "      ").Substring(0, 6)
                _value = (AreaCostString(_double.Value * _cost, 0) & "                   ").Substring(0, 19)
                _text = "  " & _name & " = " & _value
                AppendText(mSimulationSummaryPage, _text)

                _double = _surfaceFlow.ROpct
                _name = ("RO%" & "      ").Substring(0, 6)
                _value = (_double.ValueString & "                   ").Substring(0, 19)
                _text = _name & " = " & _value
                AppendLine(mSimulationSummaryPage, _text)

                ' Water Distribution Pie Chart
                Dim _pieChart As ctl_PieChart2D = New ctl_PieChart2D

                _pieChart.Location = New Point(510, 760)
                _pieChart.Size = New Size(250, 250)

                _pieChart.Title = mDictionary.tWaterDistribution.Translated
                _pieChart.AddSlice("Root Zone", "RZ", _Dinf.Value - _Ddp.Value, Color.White)
                _pieChart.AddSlice("Deep Percolation", "DP", _Ddp.Value, Color.WhiteSmoke)
                _pieChart.AddSlice("Runoff", "RO", _Dro.Value, Color.LightGray)

                mSimulationSummaryRtfPage.AddImage(_pieChart)

                _pieChart.DrawImage()

                ' Add Footer
                DisplayResultsFooter(mSimulationSummaryPage, mSimulationSummaryPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mSimulationSummaryPage = Nothing
            End Try
        End If

    End Sub

    Private Sub AddErosionSummaryPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert((title IsNot Nothing) And (tabName IsNot Nothing))

        ' Full Page view for Display, Print & Print Preview
        mErosionSummaryRtfPage = GetNewResultsPage(title, ResultsView)
        mErosionSummaryPage = mErosionSummaryRtfPage.Rtf
        mErosionSummaryPage.WordWrap = False
        mErosionSummaryPage.ScrollBars = RichTextBoxScrollBars.None

        mErosionSummaryRtfPage.AccessibleName = title
        mErosionSummaryRtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Srfr Parameters
        mPageNumber += 1
        mErosionSummaryPageNumber = mPageNumber
        UpdateErosionSummaryPage()

        ' Make the Full Page visible
        AddTabPage(tabName, mErosionSummaryRtfPage)

    End Sub

    Private Sub UpdateErosionPages()
        If (mUnit IsNot Nothing) Then
            UpdateErosionSummaryPage()
        End If
    End Sub

    Private mErosionSummaryPageNumber As Integer
    Private Sub UpdateErosionSummaryPage()

        If (mErosionSummaryPage IsNot Nothing) Then

            Dim _erosion As Erosion = mUnit.ErosionRef
            Dim _geometry As SystemGeometry = mUnit.SystemGeometryRef

            Dim _double As DoubleParameter
            Dim _text As String

            ' mErosionSummaryPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mErosionSummaryPage.Clear()

                ' Add Header
                DisplayResultsHeader(mErosionSummaryPage)
                '
                ' Add Erosion Input Parameters
                '
                mErosionSummaryPage.SelectionAlignment = HorizontalAlignment.Left

                AdvanceLines(mErosionSummaryPage, 2)
                AppendBoldUnderlineLine(mErosionSummaryPage, mDictionary.tFertigationInputParameters.Translated)

                AdvanceLine(mErosionSummaryPage)
                AppendBoldLine(mErosionSummaryPage, mDictionary.tIrrigationWater.Translated)

                AdvanceLine(mErosionSummaryPage)
                _double = _erosion.WaterTemp
                _text = "  " & _double.FullXlateText
                AppendLine(mErosionSummaryPage, _text)

                AdvanceLine(mErosionSummaryPage)
                _double = _erosion.KinematicViscosity
                _text = "  " & _double.FullXlateText
                AppendLine(mErosionSummaryPage, _text)

                AdvanceLine(mErosionSummaryPage)
                AppendBoldLine(mErosionSummaryPage, mDictionary.tSedimentParticle.Translated)

                AdvanceLine(mErosionSummaryPage)
                _double = _erosion.ParticleDiameter
                _text = "  " & _double.FullXlateText
                AppendLine(mErosionSummaryPage, _text)

                _double = _erosion.SpecificGravity
                _text = "  " & _double.FullXlateText
                AppendLine(mErosionSummaryPage, _text)

                AdvanceLine(mErosionSummaryPage)
                _double = _erosion.Kr
                _text = "  " & _double.FullXlateText
                AppendLine(mErosionSummaryPage, _text)
                '
                ' Add Erosion Results
                '
                AdvanceLines(mErosionSummaryPage, 2)
                AppendBoldUnderlineLine(mErosionSummaryPage, mDictionary.tErosionSoilMovement.Translated)

                Dim quarter As Double = _geometry.FieldArea / 4.0

                Dim GL01in As Double = 0.0
                Dim GL01out As Double = _erosion.GL01.Value / KilogramsPerTon ' tons
                Dim GL02in As Double = GL01out
                Dim GL02out As Double = _erosion.GL02.Value / KilogramsPerTon ' tons
                Dim GL03in As Double = GL02out
                Dim GL03out As Double = _erosion.GL03.Value / KilogramsPerTon ' tons
                Dim GL04in As Double = GL03out
                Dim GL04out As Double = _erosion.GL04.Value / KilogramsPerTon ' tons

                Dim GL01lossPerHa As Double = (GL01out - GL01in) / quarter * SquareMetersPerHectare
                Dim GL02lossPerHa As Double = (GL02out - GL02in) / quarter * SquareMetersPerHectare
                Dim GL03lossPerHa As Double = (GL03out - GL03in) / quarter * SquareMetersPerHectare
                Dim GL04lossPerHa As Double = (GL04out - GL04in) / quarter * SquareMetersPerHectare

                Dim FieldLossPerHa As Double = (GL04out - GL01in) / quarter * SquareMetersPerHectare

                AdvanceLine(mErosionSummaryPage)
                AppendLine(mErosionSummaryPage, "  " & " Quarter  |  Soil Transport (tons) * | Soil Loss/Gain (tons/ha) |")
                AppendLine(mErosionSummaryPage, "  " & "          |      In         Out      |      (Out - In)/ha **    |")
                AppendLine(mErosionSummaryPage, "  " & "----------|--------------------------|--------------------------|")
                AppendText(mErosionSummaryPage, "  " & "    1     |")
                AppendText(mErosionSummaryPage, UnitText(GL01in, Units.None, Format3dp, 9))
                AppendText(mErosionSummaryPage, UnitText(GL01out, Units.None, Format3dp, 12))
                AppendText(mErosionSummaryPage, "     |")
                AppendText(mErosionSummaryPage, UnitText(GL01lossPerHa, Units.None, Format2dp, 16))
                AppendLine(mErosionSummaryPage, "          |")

                AppendText(mErosionSummaryPage, "  " & "    2     |")
                AppendText(mErosionSummaryPage, UnitText(GL02in, Units.None, Format3dp, 9))
                AppendText(mErosionSummaryPage, UnitText(GL02out, Units.None, Format3dp, 12))
                AppendText(mErosionSummaryPage, "     |")
                AppendText(mErosionSummaryPage, UnitText(GL02lossPerHa, Units.None, Format2dp, 16))
                AppendLine(mErosionSummaryPage, "          |")

                AppendText(mErosionSummaryPage, "  " & "    3     |")
                AppendText(mErosionSummaryPage, UnitText(GL03in, Units.None, Format3dp, 9))
                AppendText(mErosionSummaryPage, UnitText(GL03out, Units.None, Format3dp, 12))
                AppendText(mErosionSummaryPage, "     |")
                AppendText(mErosionSummaryPage, UnitText(GL03lossPerHa, Units.None, Format2dp, 16))
                AppendLine(mErosionSummaryPage, "          |")

                AppendText(mErosionSummaryPage, "  " & "    4     |")
                AppendText(mErosionSummaryPage, UnitText(GL04in, Units.None, Format3dp, 9))
                AppendText(mErosionSummaryPage, UnitText(GL04out, Units.None, Format3dp, 12))
                AppendText(mErosionSummaryPage, "     |")
                AppendText(mErosionSummaryPage, UnitText(GL04lossPerHa, Units.None, Format2dp, 16))
                AppendLine(mErosionSummaryPage, "          |")

                AppendBoldLine(mErosionSummaryPage, "  " & "----------------------------------------------------------------")

                AppendLine(mErosionSummaryPage, "                           Field Loss:  " & UnitText(FieldLossPerHa, Units.None, Format2dp, 16))

                AdvanceLine(mErosionSummaryPage)
                AppendText(mErosionSummaryPage, "*  Transported soil per quarter length of ")
                If (_geometry.CrossSection.Value = CrossSections.Furrow) Then
                    AppendLine(mErosionSummaryPage, "furrow")
                Else
                    AppendLine(mErosionSummaryPage, "basin/border")
                End If
                AppendLine(mErosionSummaryPage, "** Negative values represent Deposition (i.e. soil gain)")

                ' Add Footer
                DisplayResultsFooter(mErosionSummaryPage, mErosionSummaryPageNumber, mTotalPages)

            Catch ex As Exception
                ' Set Disposed page to Nothing
                mErosionSummaryPage = Nothing
            End Try

        End If

    End Sub

    '*********************************************************************************************************

    Private Sub AddFertigationSummaryPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert((title IsNot Nothing) And (tabName IsNot Nothing))

        ' Full Page view for Display, Print & Print Preview
        mFertigationSummaryRtfPage = GetNewResultsPage(title, ResultsView)
        mFertigationSummaryPage = mFertigationSummaryRtfPage.Rtf
        mFertigationSummaryPage.WordWrap = False
        mFertigationSummaryPage.ScrollBars = RichTextBoxScrollBars.None

        mFertigationSummaryRtfPage.AccessibleName = title
        mFertigationSummaryRtfPage.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Srfr Parameters
        mPageNumber += 1
        mFertigationSummaryPageNumber = mPageNumber
        UpdateFertigationSummaryPage()

        ' Make the Full Page visible
        AddTabPage(tabName, mFertigationSummaryRtfPage)

    End Sub

    Private Sub UpdateFertigationPages()
        If (mUnit IsNot Nothing) Then
            UpdateFertigationSummaryPage()
        End If
    End Sub

    Private mFertigationSummaryPageNumber As Integer
    Private Sub UpdateFertigationSummaryPage()

        If (mFertigationSummaryPage IsNot Nothing) Then

            Dim _fertigation As Fertigation = mUnit.FertigationRef
            Dim _geometry As SystemGeometry = mUnit.SystemGeometryRef
            Dim _inflow As InflowManagement = mUnit.InflowManagementRef
            Dim _surfaceFlow As SurfaceFlow = mUnit.SurfaceFlowRef

            Dim _double As DoubleParameter
            Dim _text As String

            Dim _desc1 As String = Blanks
            Dim _desc2 As String = Blanks

            Dim _timeUnits As Units = mUnitsSystem.TimeUnits
            Dim _injRateSet As UnitsSystem.InjectionRateUnitSet = New UnitsSystem.InjectionRateUnitSet
            Dim _rateUnits As Units = _injRateSet.DisplayUnits

            Dim _time, _rate As Double
            Dim Tco As Double = _inflow.Tco

            ' mFertigationSummaryPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mFertigationSummaryPage.Clear()

                ' Add Header
                DisplayResultsHeader(mFertigationSummaryPage)
                '
                ' Add Fertigation Input Parameters
                '
                mFertigationSummaryPage.SelectionAlignment = HorizontalAlignment.Left

                AdvanceLines(mFertigationSummaryPage, 2)
                AppendBoldUnderlineLine(mFertigationSummaryPage, mDictionary.tFertigationInputParameters.Translated)

                AdvanceLine(mFertigationSummaryPage)
                AppendBoldLine(mFertigationSummaryPage, mDictionary.tFertigationInjectionPoint.Translated)

                AdvanceLine(mFertigationSummaryPage)
                _double = _fertigation.TankConcentration
                _text = "  " & _double.FullXlateText
                AppendLine(mFertigationSummaryPage, _text)

                AdvanceLine(mFertigationSummaryPage)
                AppendBoldLine(mFertigationSummaryPage, mDictionary.tFertigationInjectionTable.Translated)

                Dim _table As DataTable = _fertigation.TabulatedInjectionRate.Value
                If (DataTableHasData(_table)) Then

                    AdvanceLine(mFertigationSummaryPage)
                    _desc1 = "  " & UnitHeading(_table.Columns(0).ColumnName).PadRight(17, " "c)
                    _desc2 = "  " & UnitHeading(_table.Columns(1).ColumnName, _rateUnits).PadRight(17, " "c)

                    For Each _row As DataRow In _table.Rows

                        ' Don't let lines get too long
                        If ((62 < _desc1.Length) Or (62 < _desc2.Length)) Then
                            _desc1 &= "  ..."
                            _desc2 &= "  ..."
                            Exit For
                        End If

                        ' Add row data to end of lines
                        _time = CDbl(_row.Item(0))
                        _rate = CDbl(_row.Item(1))

                        _desc1 &= " " & UnitText(_time, _timeUnits).PadLeft(7, " "c)
                        _desc2 &= " " & UnitText(_rate, _rateUnits).PadLeft(7, " "c)
                    Next _row
                End If

                AppendLine(mFertigationSummaryPage, _desc1)
                AppendLine(mFertigationSummaryPage, _desc2)

                If (Tco < _time) Then ' injection time(s) extend past Tco
                    AdvanceLines(mFertigationSummaryPage, 2)
                    AppendBoldText(mFertigationSummaryPage, mDictionary.tWarning.Translated)
                    AppendLine(mFertigationSummaryPage, " - " & mDictionary.tInjectionTimesLimitedByTco.Translated)
                End If
                '
                ' Add Fertigation Options
                '
                AdvanceLines(mFertigationSummaryPage, 2)
                AppendBoldUnderlineLine(mFertigationSummaryPage, mDictionary.tFertigationOptions.Translated)

                AdvanceLine(mFertigationSummaryPage)
                AppendText(mFertigationSummaryPage, mDictionary.tDispersionCalculationsFormula.Translated & ": ")

                If (_fertigation.IncludeDispersion.Value = True) Then
                    Select Case (_fertigation.DispersivityCoefficientMethod.Value)
                        Case Srfr.ConstituentTransport.DispersivityCoefficientMethods.Deng
                            AppendLine(mFertigationSummaryPage, "Deng")
                        Case Srfr.ConstituentTransport.DispersivityCoefficientMethods.Fischer
                            AppendLine(mFertigationSummaryPage, "Fischer")
                        Case Srfr.ConstituentTransport.DispersivityCoefficientMethods.Rutherford
                            AppendLine(mFertigationSummaryPage, "Rutherford")
                        Case Srfr.ConstituentTransport.DispersivityCoefficientMethods.SpecifiedKx
                            AppendLine(mFertigationSummaryPage, _fertigation.SpecifiedKx.FullText)
                        Case Else ' Assume Elder
                            AppendLine(mFertigationSummaryPage, _fertigation.ElderCe.FullText)
                    End Select

                    AdvanceLine(mFertigationSummaryPage)
                    AppendLine(mFertigationSummaryPage, _fertigation.AverageKx.FullText)

                Else
                    AppendLine(mFertigationSummaryPage, "None")
                End If
                '
                ' Add Fertigation Results
                '
                AdvanceLines(mFertigationSummaryPage, 2)
                AppendBoldUnderlineLine(mFertigationSummaryPage, mDictionary.tFertigationResults.Translated)

                Dim Sapp As Double = _fertigation.AppliedSolute
                Dim Co As Double = _fertigation.TankConcentration.Value
                Dim Mapp As Double = Sapp * Co

                Dim appVolText As String = InjectionVolumeString(Sapp)
                Dim appMassText As String = MassString(Mapp, 12)

                AdvanceLine(mFertigationSummaryPage)
                AppendLine(mFertigationSummaryPage, "     " & mDictionary.tAppliedMass.Translated & " = " & appMassText)
                AdvanceLine(mFertigationSummaryPage)

                Dim Minf As DoubleParameter = _fertigation.Minf
                _text = RightJustifyFill(Minf.Name, 17) & " = " & MassString(Minf.Value, 12)
                AppendLine(mFertigationSummaryPage, _text)

                Dim Mttl As Double = Minf.Value

                If (_geometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
                    Dim Mro As DoubleParameter = _fertigation.Mro
                    _text = RightJustifyFill(Mro.Name, 17) & " = " & MassString(Mro.Value, 12)
                    AppendLine(mFertigationSummaryPage, _text)

                    Mttl += Mro.Value
                    AppendLine(mFertigationSummaryPage, "  ------------------------------")
                    AppendLine(mFertigationSummaryPage, "            " & mDictionary.tTotal.Translated & " = " & MassString(Mttl, 12))
                End If

                Dim errMass As Double = (Mttl - Mapp) / Mapp

                Dim errMassText As String = PercentageString(errMass, 12)

                AdvanceLine(mFertigationSummaryPage)
                AppendLine(mFertigationSummaryPage, "            " & mDictionary.tError.Translated & " = " & errMassText)

                Dim MDUlq As DoubleParameter = _fertigation.MDUlq
                _text = mDictionary.tFertigationDulq.Translated & " DUlq(N) = " & MDUlq.ValueString
                AdvanceLines(mFertigationSummaryPage, 2)
                AppendLine(mFertigationSummaryPage, _text)

                ' Add Footer
                DisplayResultsFooter(mFertigationSummaryPage, mFertigationSummaryPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mFertigationSummaryPage = Nothing
            End Try

        End If

    End Sub

#End Region

#Region " Display No Results "

    '******************************************************************************************
    ' DisplayNoResults() - displays a tab page explaining why there are no results.
    '
    Public Sub DisplayNoResults()
        ClearResultsPages()
        Me.DisplayNoResults(Me.ResultsView)
    End Sub

    Private Sub DisplayNoResults(ByVal _view As ResultsViews)

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

            If (0 = mUnit.UnitControlRef.RunCount.Value) Then

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

#Region " Display Input Parameters "

    Private Sub DisplaySystemGeometryParameters(ByVal tbox As RichTextBox)

        Dim _systemGeometry As SystemGeometry = mUnit.SystemGeometryRef

        Dim _desc1 As String = Blanks
        Dim _desc2 As String = Blanks
        Dim _desc3 As String = Blanks
        Dim _desc4 As String = Blanks

        Dim _col As Integer = 38
        '
        ' System Geometry
        '
        Dim _crossSection As CrossSections = CType(_systemGeometry.CrossSection.Value, CrossSections)
        Dim _furrowShape As FurrowShapes = CType(_systemGeometry.FurrowShape.Value, FurrowShapes)
        Dim _upstream As UpstreamConditions = CType(_systemGeometry.UpstreamCondition.Value, UpstreamConditions)
        Dim _downstream As DownstreamConditions = CType(_systemGeometry.DownstreamCondition.Value, DownstreamConditions)
        Dim _bottom As BottomDescriptions = CType(_systemGeometry.BottomDescription.Value, BottomDescriptions)
        Dim _area As Double = _systemGeometry.FieldArea

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

        _desc1 &= UpstreamConditionSelections(_upstream).Value & ", "
        _desc1 &= DownstreamConditionSelections(_downstream).Value

        AppendLine(tbox, " - " & _desc1)

        ' Add bottom description
        Select Case (_bottom)
            Case BottomDescriptions.Slope
                _desc1 = LeftJustifyFill(_systemGeometry.Slope.FullXlateText, _col, "  ")
            Case Globals.BottomDescriptions.SlopeTable, Globals.BottomDescriptions.AvgFromSlopeTable
                _desc1 = LeftJustifyFill(mDictionary.tSlopeDefinedBySlopeTable.Translated, _col, "  ")
                _desc1 &= mDictionary.tAverageSlope.Translated & " = " & SlopeString(_systemGeometry.AverageSlopeFromElevationTable, 0)
            Case Globals.BottomDescriptions.ElevationTable, Globals.BottomDescriptions.AvgFromElevTable
                _desc1 = LeftJustifyFill(mDictionary.tSlopeDefinedByElevationTable.Translated, _col, "  ")
                _desc1 &= mDictionary.tAverageSlope.Translated & " = " & SlopeString(_systemGeometry.AverageSlopeFromElevationTable, 0)
        End Select

        AppendLine(tbox, _desc1)

        ' Add field dimensions
        Dim worldType As WorldTypes = _systemGeometry.Unit.UnitType.Value

        Select Case (_crossSection)
            Case CrossSections.Basin, CrossSections.Border
                _desc1 = LeftJustifyFill(_systemGeometry.Length.FullXlateText, _col, "  ")
                _desc2 = LeftJustifyFill(_systemGeometry.Width.FullXlateText, _col, "  ")

                If ((worldType = WorldTypes.SimulationWorld) And (_systemGeometry.EnableTabulatedBorderDepth.Value)) Then
                    _desc3 = LeftJustifyFill(mDictionary.tTabulatedBorderDepth.Translated, _col, "  ")
                Else
                    _desc3 = LeftJustifyFill(_systemGeometry.Depth.FullXlateText, _col, "  ")
                End If

                _desc1 &= mDictionary.tArea.Translated & " = " & AreaString(_area, 0)

                AppendLine(tbox, _desc1)
                AppendLine(tbox, _desc2)
                AppendLine(tbox, _desc3)
            Case Else ' Assume Globals.CrossSections.Furrow
                _desc1 = LeftJustifyFill(mDictionary.tFurrowLength.Translated & " = " & _systemGeometry.Length.ValueString, _col, "  ")
                _desc2 = LeftJustifyFill(mDictionary.tFurrowSetWidth.Translated & " = " & _systemGeometry.Width.ValueString, _col, "  ")
                _desc3 = LeftJustifyFill(_systemGeometry.FurrowSpacing.FullXlateText, _col, "  ")
                _desc4 = LeftJustifyFill(mDictionary.tFurrowsPerSet.Translated & " = " & Format(_systemGeometry.FurrowsPerSet.Value, "0.#"), _col, "  ")

                Select Case (_furrowShape)

                    Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData

                        If ((worldType = WorldTypes.SimulationWorld) And (_furrowShape = FurrowShapes.PowerLaw) And (_systemGeometry.EnableTabulatedFurrowShape.Value)) Then

                            _desc2 &= mDictionary.tTabulatedCrossSection.Translated

                        Else

                            Dim _const As String = mDictionary.tConstant.Translated & " = " & _systemGeometry.PowerLawConstantString & ", "
                            Dim _rho1, _rho2 As Double
                            _systemGeometry.PowerLawRho(_rho1, _rho2)

                            _desc1 &= _systemGeometry.WidthAt100mm.FullXlateText
                            _desc2 &= _const + _systemGeometry.PowerLawExponent.FullXlateText
                            _desc3 &= _systemGeometry.MaximumDepth.FullXlateText
                            _desc4 &= "Rho1 = " & Format(_rho1, "0.0###") & ", Rho2 = " & Format(_rho2, "0.0###")

                        End If

                    Case Else ' Trapezoid Furrow

                        If ((worldType = WorldTypes.SimulationWorld) And (_furrowShape = FurrowShapes.Trapezoid) And (_systemGeometry.EnableTabulatedFurrowShape.Value)) Then

                            _desc2 &= mDictionary.tTabulatedCrossSection.Translated

                        Else

                            _desc1 &= _systemGeometry.BottomWidth.FullXlateText
                            _desc2 &= _systemGeometry.SideSlope.FullXlateText
                            _desc3 &= _systemGeometry.MaximumDepth.FullXlateText

                        End If

                End Select

                AppendLine(tbox, _desc1)
                AppendLine(tbox, _desc2)
                AppendLine(tbox, _desc3)
                AppendLine(tbox, _desc4)
        End Select

    End Sub

    Private Sub DisplayInfiltrationParameters(ByVal tbox As RichTextBox)

        Dim _soilCropProperties As SoilCropProperties = mUnit.SoilCropPropertiesRef

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
        Dim _infiltrationFunction As InfiltrationFunctions = CType(_soilCropProperties.InfiltrationFunction.Value, InfiltrationFunctions)
        Dim _tabulated As Boolean = _soilCropProperties.EnableTabulatedInfiltration.Value

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
            _desc1 = " - " & WettedPerimeterMethodSelections(_soilCropProperties.WettedPerimeterMethod.Value).Value
        Else ' Basin / Border
            _desc1 = ""
        End If

        ' Infiltration may be tabulated
        If (_tabulated) Then

            Select Case _infiltrationFunction

                Case InfiltrationFunctions.CharacteristicInfiltrationTime

                    _desc1 = "  " & mDictionary.tCharacteristicInfiltrationTime.Translated & _desc1

                    _table = _soilCropProperties.CharacteristicTimeTable.Value
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

                            If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                _desc6 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(16, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."
                                    _desc4 &= "  ..."
                                    _desc5 &= "  ..."

                                    If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc6 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next
                        End If
                    End If

                Case InfiltrationFunctions.KostiakovFormula

                    _desc1 = "  " & mDictionary.tKostiakovFormula.Translated & _desc1

                    _table = _soilCropProperties.KostiakovTable.Value
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

                            If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                _desc5 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(16, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length) Or (62 < _desc5.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."
                                    _desc4 &= "  ..."

                                    If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                If (_soilCropProperties.EnableLimitingDepth.Value) Then
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
                        _table = _soilCropProperties.ModifiedKostiakovTable.Value
                    Else
                        _table = _soilCropProperties.BranchFunctionTable.Value
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

                            If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                    If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc7 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next
                        End If
                    End If

                Case InfiltrationFunctions.NRCSIntakeFamily

                    _desc1 = "  " & mDictionary.tNrcsIntakeFamily.Translated & _desc1

                    _table = _soilCropProperties.NrcsIntakeTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsString(_table, Srfr.Globals.sNrcsFamily)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sLimit))) Then

                            ' Start with the row names
                            _desc2 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(13, " "c)
                            _desc3 = "  " & "NRCS Family".PadRight(13, " "c)

                            If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(13, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."

                                    If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc4 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next
                        End If
                    End If

                Case InfiltrationFunctions.TimeRatedIntakeFamily

                    _desc1 = "  " & mDictionary.tTimeRatedIntakeFamily.Translated & _desc1

                    _table = _soilCropProperties.TimeRatedTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sCorrTime)) _
                        And (DataColumnIsDouble(_table, Srfr.Globals.sLimit))) Then

                            ' Start with the row names
                            _desc2 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sCorrTime).ColumnName).PadRight(16, " "c)

                            If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Globals.sLimit).ColumnName).PadRight(16, " "c)
                            End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc2.Length) Or (62 < _desc3.Length) Or (62 < _desc4.Length)) Then
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."

                                    If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc4 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next
                        End If
                    End If

                Case InfiltrationFunctions.GreenAmpt

                    _desc1 = "  " & sGreenAmpt & _desc1

                    _table = _soilCropProperties.GreenAmptTable.Value
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

                            If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                    If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc8 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next

                        End If
                    End If


                Case InfiltrationFunctions.WarrickGreenAmpt

                    _desc1 = "  " & sWarrickGreenAmpt & _desc1

                    _table = _soilCropProperties.WarrickGreenAmptTable.Value
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

                            If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                    If (_soilCropProperties.EnableLimitingDepth.Value) Then
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

                                If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                    _desc8 &= " " & UnitText(_limit, _depthUnits).PadLeft(7, " "c)
                                End If
                            Next

                        End If
                    End If


                Case InfiltrationFunctions.Hydrus1D

                    _desc1 = "  " & mDictionary.tHydrusInfiltration.Translated & _desc1

            End Select

        Else ' not tabulated

            ' Get current Kostiakov parameters
            Dim k As Double = _soilCropProperties.KostiakovK
            Dim a As Double = _soilCropProperties.KostiakovA
            Dim b As Double = _soilCropProperties.KostiakovB
            Dim c As Double = _soilCropProperties.KostiakovC

            ' Display k & a
            Dim _kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            _desc2 = "  k = " & KostiakovKParameter.KostiakovKString(k, a, _kunits, 0)
            _desc3 = "  a = " & Format(a, "0.000#")

            ' Remaining data is Infiltration Method dependent
            Select Case _infiltrationFunction

                Case InfiltrationFunctions.CharacteristicInfiltrationTime
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a")

                    _desc4 = "  " & _soilCropProperties.InfiltrationDepth_KT.FullXlateText
                    _desc5 = "  " & _soilCropProperties.InfiltrationTime_KT.FullXlateText

                Case InfiltrationFunctions.KostiakovFormula
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a")

                    _desc4 = Blanks
                    _desc5 = Blanks

                Case InfiltrationFunctions.ModifiedKostiakovFormula
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a + (b*T) + c")

                    _desc4 = "  b = " & _soilCropProperties.KostiakovB_MK.ValueString
                    _desc5 = "  c = " & _soilCropProperties.KostiakovC_MK.ValueString

                Case InfiltrationFunctions.NRCSIntakeFamily
                    Dim _family As NrcsIntakeFamilies = CType(_soilCropProperties.NrcsIntakeFamily.Value, NrcsIntakeFamilies)
                    Dim _option As NrcsToKostiakovMethods = CType(_soilCropProperties.NrcsToKostiakovMethod.Value, NrcsToKostiakovMethods)
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

                    _desc4 = "  " & _soilCropProperties.InfiltrationDepth_KT.Name & " = " & DepthString(0.1, 0)
                    _desc5 = "  " & _soilCropProperties.InfiltrationTime_KT.Name & " = " & _soilCropProperties.InfiltrationTime_TR.ValueString

                Case InfiltrationFunctions.GreenAmpt
                    AppendLine(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)

                    _desc2 = ("  ThetaS = " & _soilCropProperties.EffectivePorosityGA.ValueString).PadRight(38, " "c)
                    _desc2 &= "c = " & _soilCropProperties.GreenAmptC.ValueString

                    _desc3 = "  Theta0 = " & _soilCropProperties.InitialWaterContentGA.ValueString
                    _desc4 = "  hf     = " & _soilCropProperties.WettingFrontPressureHeadGA.ValueString
                    _desc5 = "  Ks     = " & _soilCropProperties.HydraulicConductivityGA.ValueString

                Case InfiltrationFunctions.Hydrus1D
                    AppendLine(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)

                    _desc2 = "  HYDRUS Project:"
                    _desc3 = "    " & _soilCropProperties.HydrusProject.Value

                Case InfiltrationFunctions.WarrickGreenAmpt
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)

                    Dim gamma As Double = _soilCropProperties.WarrickGreenAmptGamma.Value
                    Dim method As WarrickGreenAmpt.Methods = WarrickGreenAmpt.Methods.Method2

                    If (method = WarrickGreenAmpt.Methods.Method1) Then
                        AppendLine(tbox, " - Method 1")
                    Else
                        AppendLine(tbox, " - Method 2")
                    End If

                    _desc1 = ""

                    _desc2 = ("  ThetaS = " & _soilCropProperties.SaturatedWaterContentWGA.ValueString).PadRight(38, " "c)
                    _desc2 &= "c = " & _soilCropProperties.WarrickGreenAmptC.ValueString

                    _desc3 = ("  Theta0 = " & _soilCropProperties.InitialWaterContentWGA.ValueString).PadRight(38, " "c)
                    _desc3 &= "Gamma = " & Format(gamma, "0.0##")

                    _desc4 = "  hf     = " & _soilCropProperties.WettingFrontPressureHeadWGA.ValueString
                    _desc5 = "  Ks     = " & _soilCropProperties.HydraulicConductivityWGA.ValueString

                Case Else ' Assume Branch Function
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a + c   then   Z = Zb + (b*T)")

                    Dim bt As Double = _soilCropProperties.BranchTime

                    _desc4 = "  c = " & _soilCropProperties.KostiakovC_BF.ValueString

                    _desc5 = "  b = " & _soilCropProperties.BranchB_BF.ValueString
                    _desc5 &= "  " & mDictionary.tBranchTime.Translated & " = " & TimeString(bt, 0)

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

        Dim _soilCropProperties As SoilCropProperties = mUnit.SoilCropPropertiesRef

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
        Dim _roughnessMethod As RoughnessMethods = CType(_soilCropProperties.RoughnessMethod.Value, RoughnessMethods)
        Dim _tabulated As Boolean = _soilCropProperties.EnableTabulatedRoughness.Value

        Dim _table As DataTable = Nothing

        ' Title + 1 line
        AdvanceLine(tbox)
        AppendBoldText(tbox, mDictionary.tRoughness.Translated)
        AppendLine(tbox, " - " & RoughnessMethodSelections(_roughnessMethod).Value)

        ' Roughness may be tabulated
        If (_tabulated) Then

            Select Case (_roughnessMethod)
                Case RoughnessMethods.ManningN, RoughnessMethods.NrcsSuggestedManningN

                    _table = _soilCropProperties.ManningNTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.ManningN.sN)) _
                        And (DataColumnIsDouble(_table, Srfr.Roughness.sVegDensityM))) Then

                            ' Start with the row names
                            _desc1 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc2 = "  " & UnitHeading(_table.Columns(Srfr.ManningN.sN).ColumnName).PadRight(16, " "c)

                            'If (_soilCropProperties.EnableVegetativeDensity.Value) Then
                            '    _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Roughness.sVegDensityM).ColumnName).PadRight(16, " "c)
                            'End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc1.Length) Or (62 < _desc2.Length)) Then
                                    _desc1 &= "  ..."
                                    _desc2 &= "  ..."

                                    'If (_soilCropProperties.EnableVegetativeDensity.Value) Then
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

                                'If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                '    _desc3 &= " " & Format(_veg, "0.0###").PadLeft(7, " "c)
                                'End If
                            Next
                        End If
                    End If

                Case RoughnessMethods.ManningCnAn

                    _table = _soilCropProperties.ManningCnAnTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.ManningN.sCn)) _
                        And (DataColumnIsDouble(_table, Srfr.ManningN.sAn)) _
                        And (DataColumnIsDouble(_table, Srfr.Roughness.sVegDensityM))) Then

                            ' Start with the row names
                            _desc1 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc2 = "  " & UnitHeading(_table.Columns(Srfr.ManningN.sCn).ColumnName).PadRight(16, " "c)
                            _desc3 = "  " & UnitHeading(_table.Columns(Srfr.ManningN.sAn).ColumnName).PadRight(16, " "c)

                            'If (_soilCropProperties.EnableVegetativeDensity.Value) Then
                            '    _desc4 = "  " & UnitHeading(_table.Columns(Srfr.Roughness.sVegDensityM).ColumnName).PadRight(16, " "c)
                            'End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc1.Length) Or (62 < _desc2.Length) Or (62 < _desc3.Length)) Then
                                    _desc1 &= "  ..."
                                    _desc2 &= "  ..."
                                    _desc3 &= "  ..."

                                    'If (_soilCropProperties.EnableVegetativeDensity.Value) Then
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

                                'If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                '    _desc4 &= " " & Format(_veg, "0.0###").PadLeft(7, " "c)
                                'End If
                            Next
                        End If
                    End If

                Case Else ' Assume RoughnessMethods.SayreAlbertson

                    _table = _soilCropProperties.SayreChiTable.Value
                    If (DataTableHasData(_table)) Then
                        If ((DataColumnIsDouble(_table, sDistanceX)) _
                        And (DataColumnIsDouble(_table, Srfr.SayreAlbertsonChi.sChiMM)) _
                        And (DataColumnIsDouble(_table, Srfr.Roughness.sVegDensityM))) Then

                            ' Start with the row names
                            _desc1 = "  " & UnitHeading(_table.Columns(sDistanceX).ColumnName).PadRight(16, " "c)
                            _desc2 = "  " & UnitHeading(_table.Columns(Srfr.SayreAlbertsonChi.sChiMM).ColumnName).PadRight(16, " "c)

                            'If (_soilCropProperties.EnableVegetativeDensity.Value) Then
                            '    _desc3 = "  " & UnitHeading(_table.Columns(Srfr.Roughness.sVegDensityM).ColumnName).PadRight(16, " "c)
                            'End If

                            For Each _dataRow As DataRow In _table.Rows

                                ' Don't let lines get too long
                                If ((62 < _desc1.Length) Or (62 < _desc2.Length)) Then
                                    _desc1 &= "  ..."
                                    _desc2 &= "  ..."

                                    'If (_soilCropProperties.EnableVegetativeDensity.Value) Then
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

                                'If (_soilCropProperties.EnableLimitingDepth.Value) Then
                                '    _desc3 &= " " & Format(_veg, "0.0###").PadLeft(7, " "c)
                                'End If
                            Next
                        End If
                    End If
            End Select

        Else ' not tabulated

            Select Case (_roughnessMethod)
                Case RoughnessMethods.ManningN, RoughnessMethods.NrcsSuggestedManningN
                    If (_soilCropProperties.NrcsSuggestedManningN.Value = NrcsSuggestedManningN.UserEntered) Then
                        _desc1 = "  " & _soilCropProperties.ManningN.FullXlateText
                    Else
                        Dim _manningN As Integer = _soilCropProperties.NrcsSuggestedManningN.Value
                        _desc1 = "  " & mDictionary.tManningN.Translated & " = " & NrcsSuggestedManningNValues(_manningN).ToString
                    End If
                Case RoughnessMethods.ManningCnAn
                    _desc1 = "  " & _soilCropProperties.ManningCn.FullXlateText
                    _desc1 &= ", " & _soilCropProperties.ManningAn.FullXlateText
                Case Else ' Assume RoughnessMethods.SayreAlbertson
                    _desc1 = "  " & _soilCropProperties.SayreChi.FullXlateText
            End Select
        End If

        AppendLine(tbox, _desc1)

        If Not (_desc2 = Blanks) Then
            AppendLine(tbox, _desc2)
        End If

        If Not (_desc3 = Blanks) Then
            AppendLine(tbox, _desc3)
        End If

    End Sub

    Private Sub DisplayInflowManagementParameters(ByVal tbox As RichTextBox)

        Dim _inflowManagement As InflowManagement = mUnit.InflowManagementRef
        Dim _systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
        Dim _crossSection As String = _systemGeometry.CrossSectionName

        Dim _desc1 As String = Blanks
        Dim _desc2 As String = Blanks
        Dim _desc3 As String = Blanks
        Dim _desc4 As String = Blanks
        Dim _desc5 As String = Blanks

        Dim _col As Integer = 38
        '
        ' Inflow Management
        '
        Dim _inflowMethod As InflowMethods = CType(_inflowManagement.InflowMethod.Value, InflowMethods)
        Dim _surgeStrategy As SurgeStrategies = CType(_inflowManagement.SurgeStrategy.Value, SurgeStrategies)
        Dim _numSurges As Integer = _inflowManagement.NumberOfSurges.Value

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
                        _desc1 = LeftJustifyFill(mDictionary.tBorderInflowRate.Translated & " =  " & _inflowManagement.InflowRate.ValueString, _col, "  ")
                    Case Else ' Assume CrossSections.Furrow
                        Dim units As Units = mUnitsSystem.FlowRateUnits
                        Dim furrowInflowRate As Double = _inflowManagement.FurrowInflowRate
                        _desc1 = LeftJustifyFill(mDictionary.tFurrowInflowRate.Translated & " = " & UnitTextWithUnits(furrowInflowRate, units), _col, "  ")

                        _desc1 &= mDictionary.tFurrowSetInflowRate.Translated & " = " & _inflowManagement.InflowRate.ValueString
                End Select

                Dim _cutoff As CutoffMethods = CType(_inflowManagement.CutoffMethod.Value, CutoffMethods)

                Select Case (_cutoff)
                    Case Globals.CutoffMethods.TimeBased
                        _desc2 = LeftJustifyFill(_inflowManagement.CutoffTime.FullXlateText, _col, "  ")
                    Case Globals.CutoffMethods.DistanceBased
                        _desc2 = LeftJustifyFill(_inflowManagement.CutoffLocationRatio.FullXlateText, _col, "  ")
                    Case Globals.CutoffMethods.DistanceInfDepth
                        _desc2 = LeftJustifyFill(_inflowManagement.CutoffLocationRatio.FullXlateText, _col, "  ")
                        _desc2 &= "& " & _inflowManagement.CutoffInfiltrationDepth.FullXlateText
                    Case Globals.CutoffMethods.DistanceOppTime
                        _desc2 = LeftJustifyFill(_inflowManagement.CutoffLocationRatio.FullXlateText, _col, "  ")
                        _desc2 &= "& " & _inflowManagement.CutoffOpportunityTime.FullXlateText
                    Case Else ' Assume Globals.CutoffMethods.UpstreamInfDepth
                        _desc2 = LeftJustifyFill(_inflowManagement.CutoffUpstreamDepth.FullXlateText, _col, "  ")
                End Select

                Dim _cutback As CutbackMethods = CType(_inflowManagement.CutbackMethod.Value, CutbackMethods)

                Select Case (_cutback)
                    Case Globals.CutbackMethods.NoCutback
                        _desc3 = LeftJustifyFill("", _col)
                        _desc4 = LeftJustifyFill(mDictionary.tNoCutback.Translated, _col, "  ")
                        _desc5 = LeftJustifyFill("", _col)
                    Case Globals.CutbackMethods.TimeBased
                        _desc3 = LeftJustifyFill("", _col)
                        _desc4 = LeftJustifyFill(_inflowManagement.CutbackTimeRatio.FullXlateText, _col, "  ")
                        _desc5 = LeftJustifyFill(_inflowManagement.CutbackRateRatio.FullXlateText, _col, "  ")
                    Case Else ' Assume Globals.CutbackMethods.DistanceBased
                        _desc3 = LeftJustifyFill("", _col)
                        _desc4 = LeftJustifyFill(_inflowManagement.CutbackLocationRatio.FullXlateText, _col, "  ")
                        _desc5 = LeftJustifyFill(_inflowManagement.CutbackRateRatio.FullXlateText, _col, "  ")
                End Select

                _desc4 &= _inflowManagement.RequiredDepth.FullXlateText
                _desc5 &= _inflowManagement.UnitWaterCost.FullXlateText

            Case Globals.InflowMethods.TabulatedInflow

                ' Get the Tabulated Inflow table and current display units
                Dim _inflowTable As DataTable = _inflowManagement.TabulatedInflow.Value
                If (DataTableHasData(_inflowTable)) Then
                    If ((DataColumnIsDouble(_inflowTable, sTimeX)) _
                    And (DataColumnIsDouble(_inflowTable, sInflowX))) Then
                        Dim _timeUnits As Units = mUnitsSystem.TimeUnits
                        Dim _inflowUnits As Units = mUnitsSystem.FlowRateUnits

                        ' Start with the column names
                        _desc1 = "  " & "            #"
                        _desc2 = "  " & UnitHeading(_inflowTable.Columns(nTimeX).ColumnName).PadLeft(13, " "c)
                        _desc3 = "  " & UnitHeading(_inflowTable.Columns(nInflowX).ColumnName).PadLeft(13, " "c)

                        Dim _row As Integer = 0
                        For Each _dataRow As DataRow In _inflowTable.Rows

                            ' Don't let lines get too long
                            If ((62 < _desc1.Length) Or (62 < _desc2.Length) Or (62 < _desc3.Length)) Then
                                _desc1 &= "  ..."
                                _desc2 &= "  ..."
                                _desc3 &= "  ..."
                                Exit For
                            End If

                            ' Add row data to the end of the lines
                            _row += 1
                            Dim _time As Double = CDbl(_dataRow.Item(sTimeX))
                            Dim _inflow As Double = CDbl(_dataRow.Item(sInflowX))

                            _desc1 &= " " & _row.ToString.PadLeft(7, " "c)
                            _desc2 &= " " & UnitText(_time, _timeUnits).PadLeft(7, " "c)
                            _desc3 &= " " & UnitText(_inflow, _inflowUnits).PadLeft(7, " "c)
                        Next
                    End If
                End If

                _desc5 = "  " & _inflowManagement.RequiredDepth.FullXlateText(_col)
                _desc5 &= _inflowManagement.UnitWaterCost.FullXlateText

            Case Globals.InflowMethods.Cablegation

                _desc1 = LeftJustifyFill(_inflowManagement.TotalInflow.FullXlateText, _col, "  ")
                _desc1 &= _inflowManagement.PipeDiameter.FullXlateText

                _desc2 = LeftJustifyFill(_inflowManagement.CutoffFlow.FullXlateText, _col, "  ")
                _desc2 &= _inflowManagement.PipeSlope.FullXlateText

                _desc3 = LeftJustifyFill(_inflowManagement.OrificeSpacing.FullXlateText, _col, "  ")
                _desc3 &= _inflowManagement.HazenWilliamsPipeCoefficient.FullXlateText

                If (_inflowManagement.OrificeOption.Value = OrificeOptions.EquivalentDiameter) Then
                    _desc4 = LeftJustifyFill(_inflowManagement.OrificeDiameter.FullXlateText, _col, "  ")
                Else
                    _desc4 = LeftJustifyFill(_inflowManagement.PeakOrificeFlow.FullXlateText, _col, "  ")
                End If
                _desc4 &= _inflowManagement.PlugSpeed.FullXlateText

            Case Globals.InflowMethods.Surge

                _desc3 = "  " & _inflowManagement.SurgeOnTime.FullXlateText
                _desc4 = "  " & _inflowManagement.SurgeCutoffTime.FullXlateText
                _desc5 = "  " & _inflowManagement.SurgeInflowRate.FullXlateText

                Select Case (_surgeStrategy)

                    Case SurgeStrategies.UniformTime

                        _desc1 = "  " & mDictionary.tNumberOfSurges.Translated & " = " & mWorldWindow.SrfrAPI.Inflow.NumberOfSurges.ToString

                    Case SurgeStrategies.UniformLocation
                        _desc1 = "  " & mDictionary.tNumberOfAdvanceSurges.Translated & " = " & _inflowManagement.NumberOfSurges.Text
                        _desc2 = "  " & mDictionary.tSurgeLocationRatio.Translated & " = " & Format(1.0 / _numSurges, "0.00#")

                    Case SurgeStrategies.TabulatedTime

                        ' Get the Tabulated Surge table and current display units
                        Dim onTime, offTime As Double
                        Dim _surgeTable As DataTable = _inflowManagement.SurgeTimesTable.Value
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
                                        _desc1 &= "  ..."
                                        _desc2 &= "  ..."
                                        _desc3 &= "  ..."
                                        Exit For
                                    End If

                                    ' Add row data to the end of the lines
                                    _row += 1
                                    onTime = CDbl(_dataRow.Item(sStartTimeX))
                                    offTime = CDbl(_dataRow.Item(sEndTimeX))

                                    _desc1 &= " " & _row.ToString.PadLeft(7, " "c)
                                    _desc2 &= " " & UnitText(onTime, _timeUnits).PadLeft(7, " "c)
                                    _desc3 &= " " & UnitText(offTime, _timeUnits).PadLeft(7, " "c)
                                Next
                            End If
                        End If

                        _desc4 = "  " & mDictionary.tCutoffTime.Translated & " = " & TimeString(offTime)

                    Case SurgeStrategies.TabulatedLocation

                        ' Get the Tabulated Surage table and current display units
                        Dim _surgeTable As DataTable = _inflowManagement.SurgeLocationsTable.Value
                        If (DataTableHasData(_surgeTable)) Then
                            If ((DataColumnIsDouble(_surgeTable, sLocationX))) Then

                                ' Start with the column names  
                                _desc1 = "  " & "                #"
                                _desc2 = "  " & UnitHeading(_surgeTable.Columns(0).ColumnName).PadLeft(17, " "c)

                                Dim _row As Integer = 0
                                For Each _dataRow As DataRow In _surgeTable.Rows

                                    ' Don't let lines get too long
                                    If ((62 < _desc1.Length) Or (62 < _desc2.Length) Or (62 < _desc3.Length)) Then
                                        _desc1 &= "  ..."
                                        _desc2 &= "  ..."
                                        Exit For
                                    End If

                                    ' Add row data to the end of the lines
                                    _row += 1
                                    Dim _loc As Double = CDbl(_dataRow.Item(sLocationX))

                                    _desc1 &= " " & _row.ToString.PadLeft(7, " "c)
                                    _desc2 &= " " & UnitText(_loc, Units.None).PadLeft(7, " "c)
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
                While (_line.Length + _word.Length + 1 < 78)
                    _line &= " " & _word

                    ' Strip the next word from Detail
                    Dim _space As Integer = _detail.IndexOf(" ")
                    If (0 < _space) Then
                        _word = _detail.Substring(0, _space)
                        _detail = _detail.Substring(_space).Trim
                    Else
                        _word = _detail ' The last word
                        If (_line.Length + _word.Length + 1 < 78) Then
                            _line &= " " & _word
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

    Private Function GetNewXYGraphPage(ByVal _dataSet As DataSet,
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
    '
    ' DisplayResultsHeader() - displays the results header
    '
    Private Sub DisplayResultsHeader(ByVal tbox As RichTextBox)

        Debug.Assert(tbox IsNot Nothing)

        ' Center the heading text
        tbox.SelectionAlignment = HorizontalAlignment.Center

        ' Program & ALARC names
        AppendBoldText(tbox, mUnit.UnitControlRef.ProductName.Value)
        AppendLine(tbox, " " & mUnit.UnitControlRef.ProductVersion.Value & " - " & _
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
        AppendText(tbox, mUnit.UnitControlRef.RunDateTime.Value.ToLongDateString & " ")
        AppendLine(tbox, mUnit.UnitControlRef.RunDateTime.Value.ToShortTimeString)
        AdvanceLine(tbox)

        ' Farm / Field / Unit names
        Dim _widthChars As Integer = PortraitWidthChars

        AppendFieldIdText(tbox, mUnit, _widthChars)
        AdvanceLine(tbox)
        AppendUnitIdText(tbox, mUnit, _widthChars)
        AdvanceLine(tbox)

    End Sub
    '
    ' DisplayResultsFooter() - displays the SRFR results footer
    '
    Private Sub DisplayResultsFooter(ByVal tbox As RichTextBox, _
                                     ByVal _pageNumber As Integer, _
                                     ByVal _totalPages As Integer)

        Debug.Assert(_pageNumber <= _totalPages)

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
            If (_pageNo < 1) Then
                _pageNo = 1
            End If

            Debug.Assert(_pageNo <= mTotalPages)

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

        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

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
                    If (0 < mUnit.UnitControlRef.RunCount.Value) Then

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
                        DisplaySimulationResults()
                    End If
                Catch ex As Exception
                    mWinSRFR.LogException(WinSRFR.ErrorLevels.Serious, "ctl_SimulationResults[UpdateUI]", ex)
                End Try

            End If
        End If

        ' Re-select the saved tab page
        If ((-1 < _selectedIndex) And (_selectedIndex < Me.TabCount)) Then
            Me.SelectedIndex = _selectedIndex
        Else
            Me.SelectedIndex = 0 ' Me.TabCount - 1
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
    Private Sub SimulationParametersPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mSimulationSummaryPage.Disposed
        mSimulationSummaryPage = Nothing
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
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        If (Me.Visible) Then
            UpdateUI()
        End If
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
