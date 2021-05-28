
'**********************************************************************************************
' ctl_Results - Control for displaying the WinSRFR computation results
'
Imports System.Drawing.Printing
Imports DataStore
Imports GraphingUI
Imports PrintingUI
Imports Srfr

Public Class ctl_Results
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ctl_Results))
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
        'ctl_Results
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
    Private mPageNumber As Integer
    Private mTotalPages As Integer
    '
    ' Disposed event must be handled for these Components
    '

    ' Design Analysis
    Private WithEvents mBorderDesignParametersPage As RichTextBox
    Private WithEvents mFurrowDesignParametersPage As RichTextBox

    ' Operations Analysis
    Private WithEvents mBorderOperationsParametersPage As RichTextBox
    Private WithEvents mFurrowOperationsParametersPage As RichTextBox

    ' Infiltrated Profile Analysis
    Private WithEvents mIpaInputSummaryPage As RichTextBox
    Private WithEvents mIpaSoilWaterDeficitPage As RichTextBox
    Private WithEvents mIpaInfiltratedDepthsPage As RichTextBox
    Private WithEvents mIpaPerformanceAnalysisPage As RichTextBox

    ' Merriam-Keller Analysis
    Private WithEvents mMKInputSummaryPage As RichTextBox
    Private WithEvents mMkAdvRecOppPage As RichTextBox
    Private WithEvents mMkPerformanceSummaryPage As RichTextBox
    Private WithEvents mMkGoodnessPage As RichTextBox

    ' Elliott-Walker Two-Point Analysis
    Private WithEvents mEwInputSummaryPage As RichTextBox
    Private WithEvents mEwTwoPointPage As RichTextBox
    Private WithEvents mEwGoodnessPage As RichTextBox

    ' Erosion Analysis
    Private WithEvents mErosionParametersPage As RichTextBox
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

    Protected Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits

        If (mUnit IsNot Nothing) Then
            ' Redraw the text pages
            Select Case mUnit.UnitType.Value
                Case WorldTypes.DesignWorld
                    UpdateDesignPages()
                Case WorldTypes.OperationsWorld
                    UpdateOperationsPages()
                Case Else
                    Debug.Assert(False, "Support for this World must be added")
            End Select
        End If
    End Sub

#End Region

#Region " Display Results Methods "

#Region " Design Results "

#Region " Basin / Border Design "
    '
    ' Display / update current text results pages
    '
    Private Sub DisplayDesignResults()
        If (mUnit IsNot Nothing) Then
            Select Case (mUnit.CrossSection)
                Case CrossSections.Furrow
                    Me.DisplayFurrowDesignResults()
                Case Else ' Basin / Border
                    Me.DisplayBorderDesignResults()
            End Select
        End If
    End Sub

    Private Sub UpdateDesignPages()
        If (mUnit IsNot Nothing) Then
            Select Case mUnit.CrossSection
                Case CrossSections.Furrow
                    Me.UpdateFurrowDesignParametersPage()
                Case Else ' Basin / Border
                    Me.UpdateBorderDesignParametersPage()
            End Select
        End If
    End Sub
    '
    ' Display Border Design Results
    '
    Private Sub DisplayBorderDesignResults()
        If (mUnit IsNot Nothing) Then

            ' Add Design Contours
            Dim performanceResults As PerformanceResults = mUnit.PerformanceResultsRef
            Dim designContour As ContourParameter = performanceResults.DesignContour
            If (designContour IsNot Nothing) Then
                Dim contourGrid As ContourGrid = designContour.Value
                If (contourGrid IsNot Nothing) Then
                    mTotalPages = 3 + contourGrid.ContourCount + mWorldWindow.ContourOverlay.NoOfPages
                    mPageNumber = 0
                    ' Start with Design Parameters
                    AddBorderDesignParametersPage(mDictionary.tInputSummary.Translated, mDictionary.tInputSummary.Translated)
                    ' Add contour tabs
                    AddContourPages(designContour, contourGrid)
                    ' Add overlay tab, if requested
                    AddContourOverlay(designContour, contourGrid)
                End If
            End If

            ' Add Solution (i.e. Water Distribution Diagram)
            Dim title As String = mDictionary.tSolution.Translated
            AddSolutionPage(title)

            ' End with SRFR Comparison
            title = mDictionary.tDesign.Translated
            AddComparisonPage(title)

            ' Update the Design Parameters to include the Solution Warnings
            UpdateBorderDesignParametersPage()

        End If

    End Sub

    Private Sub AddBorderDesignParametersPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mBorderDesignParametersPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Design Parameters
        mPageNumber += 1
        mBorderDesignParametersPageNumber = mPageNumber
        UpdateBorderDesignParametersPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mBorderDesignParametersPageNumber As Integer
    Private Sub UpdateBorderDesignParametersPage()

        If (mBorderDesignParametersPage IsNot Nothing) Then

            ' mBorderDesignParametersPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mBorderDesignParametersPage.Clear()

                ' Add Header
                DisplayResultsHeader(mBorderDesignParametersPage)

                ' Add the Input Parameters
                mBorderDesignParametersPage.SelectionAlignment = HorizontalAlignment.Left

                AdvanceLines(mBorderDesignParametersPage, 2)
                AppendBoldUnderlineLine(mBorderDesignParametersPage, mDictionary.tInputParameters.Translated)

                DisplaySystemGeometryParameters(mBorderDesignParametersPage)
                DisplayInfiltrationParameters(mBorderDesignParametersPage)
                DisplayRoughnessParameters(mBorderDesignParametersPage)
                DisplayInflowManagementParameters(mBorderDesignParametersPage)

                ' Add the Design Criteria
                DisplayDesignCriteria(mBorderDesignParametersPage)

                ' Add the Tuning Factors
                DisplayTuningFactors(mBorderDesignParametersPage)

                ' Add Errors & Warnings
                DisplayErrorsAndWarnings(mBorderDesignParametersPage)

                If (mUnit.SrfrResultsRef.Overflow.Value) Then
                    Dim _time As String = TimeString(mUnit.SrfrResultsRef.OverflowTime.Value, 0)
                    Dim _dist As String = LengthString(mUnit.SrfrResultsRef.OverflowDist.Value, 0)
                    AdvanceLine(mBorderDesignParametersPage)
                    AppendLine(mBorderDesignParametersPage, mDictionary.tOverflowAt.Translated & " " & _time & ", " & _dist)
                End If

                ' Add Footer
                DisplayResultsFooter(mBorderDesignParametersPage, mBorderDesignParametersPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mBorderDesignParametersPage = Nothing
            End Try
        End If

    End Sub

#End Region

#Region " Furrow Design "
    '
    ' Display Furrow Design Results
    '
    Private Sub DisplayFurrowDesignResults()
        If (mUnit IsNot Nothing) Then

            ' Add Design Contours
            Dim performanceResults As PerformanceResults = mUnit.PerformanceResultsRef
            Dim designContour As ContourParameter = performanceResults.DesignContour
            If (designContour IsNot Nothing) Then
                Dim contourGrid As ContourGrid = designContour.Value
                If (contourGrid IsNot Nothing) Then
                    mTotalPages = 3 + contourGrid.ContourCount + mWorldWindow.ContourOverlay.NoOfPages
                    mPageNumber = 0
                    ' Start with Design Parameters
                    AddFurrowDesignParametersPage(mDictionary.tInputSummary.Translated, mDictionary.tInputSummary.Translated)
                    ' Add contour tabs
                    AddContourPages(designContour, contourGrid)
                    ' Add overlay tab, if requested
                    AddContourOverlay(designContour, contourGrid)
                End If
            End If

            ' Add Solution (i.e. Water Distribution Diagram)
            Dim title As String = mDictionary.tSolution.Translated
            AddSolutionPage(title)

            ' End with SRFR Comparison
            title = mDictionary.tDesign.Translated
            AddComparisonPage(title)

            ' Update the Design Parameters to include the Solution Warnings
            UpdateFurrowDesignParametersPage()
        End If

    End Sub

    Private Sub AddFurrowDesignParametersPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mFurrowDesignParametersPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Design Parameters
        mPageNumber += 1
        mFurrowDesignParametersPageNumber = mPageNumber
        UpdateFurrowDesignParametersPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mFurrowDesignParametersPageNumber As Integer
    Private Sub UpdateFurrowDesignParametersPage()

        If (mFurrowDesignParametersPage IsNot Nothing) Then

            ' mFurrowDesignParametersPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mFurrowDesignParametersPage.Clear()

                ' Add Header
                DisplayResultsHeader(mFurrowDesignParametersPage)

                ' Add the Input Parameters
                mFurrowDesignParametersPage.SelectionAlignment = HorizontalAlignment.Left

                AdvanceLines(mFurrowDesignParametersPage, 2)
                AppendBoldUnderlineLine(mFurrowDesignParametersPage, mDictionary.tInputParameters.Translated)

                DisplaySystemGeometryParameters(mFurrowDesignParametersPage)
                DisplayInfiltrationParameters(mFurrowDesignParametersPage)
                DisplayRoughnessParameters(mFurrowDesignParametersPage)
                DisplayInflowManagementParameters(mFurrowDesignParametersPage)

                ' Add the Design Criteria
                DisplayDesignCriteria(mFurrowDesignParametersPage)

                ' Add the Tuning Factors
                DisplayTuningFactors(mFurrowDesignParametersPage)

                ' Add Errors & Warnings
                DisplayErrorsAndWarnings(mFurrowDesignParametersPage)

                If (mUnit.SrfrResultsRef.Overflow.Value) Then
                    Dim _time As String = TimeString(mUnit.SrfrResultsRef.OverflowTime.Value, 0)
                    Dim _dist As String = LengthString(mUnit.SrfrResultsRef.OverflowDist.Value, 0)
                    AdvanceLine(mFurrowDesignParametersPage)
                    AppendLine(mFurrowDesignParametersPage, mDictionary.tOverflowAt.Translated & " " & _time & ", " & _dist)
                End If

                ' Add Footer
                DisplayResultsFooter(mFurrowDesignParametersPage, mFurrowDesignParametersPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mFurrowDesignParametersPage = Nothing
            End Try
        End If

    End Sub

#End Region

#End Region

#Region " Operations Results "

#Region " Basin / Border Operations "
    '
    ' Display / update current text results pages
    '
    Private Sub DisplayOperationsResults()
        If (mUnit IsNot Nothing) Then
            Select Case (mUnit.CrossSection)
                Case CrossSections.Furrow
                    Me.DisplayFurrowOperationsResults()
                Case Else ' Basin / Border
                    Me.DisplayBorderOperationsResults()
            End Select
        End If
    End Sub

    Private Sub UpdateOperationsPages()
        If (mUnit IsNot Nothing) Then
            Select Case mUnit.CrossSection
                Case CrossSections.Furrow
                    Me.UpdateFurrowOperationsParametersPage()
                Case Else ' Basin / Border
                    Me.UpdateBorderOperationsParametersPage()
            End Select
        End If
    End Sub

    Private Sub DisplayBorderOperationsResults()
        If (mUnit IsNot Nothing) Then

            ' Add Operations Contours
            Dim performanceResults As PerformanceResults = mUnit.PerformanceResultsRef
            Dim designContour As ContourParameter = performanceResults.DesignContour
            If (designContour IsNot Nothing) Then
                Dim contourGrid As ContourGrid = designContour.Value
                If (contourGrid IsNot Nothing) Then
                    mTotalPages = 4 + contourGrid.ContourCount + mWorldWindow.ContourOverlay.NoOfPages
                    mPageNumber = 0
                    ' Start with tab for Operations Parameters
                    AddBorderOperationsParametersPage(mDictionary.tInputSummary.Translated, mDictionary.tInputSummary.Translated)
                    ' Add contour tabs
                    AddContourPages(designContour, contourGrid)
                    ' Add overlay tab, if requested
                    AddContourOverlay(designContour, contourGrid)
                    ' Add Dreq = Dmin/Dlq graph
                    AddDreqDminlqQvsIndPage(contourGrid)
                End If
            End If

            ' End with Solution
            Dim title As String = mDictionary.tSolution.Translated
            AddSolutionPage(title)

            ' End with SRFR Comparison
            title = mDictionary.tOperations.Translated
            AddComparisonPage(title)

            ' Update the Operations Parameters to include the Solution Warnings
            UpdateBorderOperationsParametersPage()

        End If

    End Sub

    Private Sub AddBorderOperationsParametersPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mBorderOperationsParametersPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Operations Parameters
        mPageNumber += 1
        mBorderOperationsParametersPageNumber = mPageNumber
        UpdateBorderOperationsParametersPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mBorderOperationsParametersPageNumber As Integer
    Private Sub UpdateBorderOperationsParametersPage()

        If (mBorderOperationsParametersPage IsNot Nothing) Then

            ' mBorderOperationsParametersPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mBorderOperationsParametersPage.Clear()

                ' Add Header
                DisplayResultsHeader(mBorderOperationsParametersPage)

                ' Add the Input Parameters
                mBorderOperationsParametersPage.SelectionAlignment = HorizontalAlignment.Left

                AdvanceLines(mBorderOperationsParametersPage, 2)
                AppendBoldUnderlineLine(mBorderOperationsParametersPage, mDictionary.tInputParameters.Translated)

                DisplaySystemGeometryParameters(mBorderOperationsParametersPage)
                DisplayInfiltrationParameters(mBorderOperationsParametersPage)
                DisplayRoughnessParameters(mBorderOperationsParametersPage)
                DisplayInflowManagementParameters(mBorderOperationsParametersPage)

                ' Add the Tuning Factors
                DisplayTuningFactors(mBorderOperationsParametersPage)

                ' Add Errors & Warnings
                DisplayErrorsAndWarnings(mBorderOperationsParametersPage)

                If (mUnit.SrfrResultsRef.Overflow.Value) Then
                    Dim _time As String = TimeString(mUnit.SrfrResultsRef.OverflowTime.Value, 0)
                    Dim _dist As String = LengthString(mUnit.SrfrResultsRef.OverflowDist.Value, 0)
                    AdvanceLine(mBorderOperationsParametersPage)
                    AppendLine(mBorderOperationsParametersPage, mDictionary.tOverflowAt.Translated & " " & _time & ", " & _dist)
                End If

                ' Add Footer
                DisplayResultsFooter(mBorderOperationsParametersPage, mBorderOperationsParametersPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mBorderOperationsParametersPage = Nothing
            End Try
        End If

    End Sub

#End Region

#Region " Furrow Operations "

    Private Sub DisplayFurrowOperationsResults()
        If (mUnit IsNot Nothing) Then

            ' Add Operations Contours
            Dim borderCriteria As BorderCriteria = mUnit.BorderCriteriaRef
            Dim systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
            Dim performanceResults As PerformanceResults = mUnit.PerformanceResultsRef
            Dim designContour As ContourParameter = performanceResults.DesignContour
            If (designContour IsNot Nothing) Then
                Dim contourGrid As ContourGrid = designContour.Value
                If (contourGrid IsNot Nothing) Then

                    Dim furrowSpacing As Double = systemGeometry.FurrowSpacing.Value
                    Dim point As ContourPoint = Nothing
                    Dim oldY As SingleParameter
                    Dim newY As SingleParameter

                    If (borderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then

                        point = designContour.TuningPoint
                        If (point IsNot Nothing) Then
                            oldY = point.Y
                            If Not (oldY.Units = Units.None) Then
                                newY = New SingleParameter(CSng(oldY.Value / furrowSpacing), Units.None)
                                point.Y = newY
                            End If
                        End If

                        point = designContour.ContourPoint
                        If (point IsNot Nothing) Then
                            oldY = point.Y
                            If Not (oldY.Units = Units.None) Then
                                newY = New SingleParameter(CSng(oldY.Value / furrowSpacing), Units.None)
                                point.Y = newY
                            End If
                        End If

                    End If

                    If ((borderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) _
                    And (contourGrid.RowName = mDictionary.tWidth.Translated)) Then

                        contourGrid.RowName = mDictionary.tFurrowsPerSet.Translated

                        ' Convert PointArray Y values from Width to Furrow/Set
                        If (contourGrid.PointArray IsNot Nothing) Then
                            For rdx As Integer = contourGrid.PointArray.GetLowerBound(0) To contourGrid.PointArray.GetUpperBound(0)
                                For cdx As Integer = contourGrid.PointArray.GetLowerBound(1) To contourGrid.PointArray.GetUpperBound(1)
                                    point = contourGrid.PointArray(rdx, cdx)
                                    oldY = point.Y
                                    newY = New SingleParameter(CSng(oldY.Value / furrowSpacing), Units.None)
                                    point.Y = newY
                                Next
                            Next
                        End If

                        ' Convert MajorContours Y values from Width to Furrow/Set
                        If (contourGrid.MajorContours IsNot Nothing) Then
                            Dim contours As ArrayList = contourGrid.MajorContours
                            For Each contour As ContourPolygons In contours
                                For Each polygon As ArrayList In contour.Polygons
                                    For Each point In polygon
                                        oldY = point.Y
                                        newY = New SingleParameter(CSng(oldY.Value / furrowSpacing), Units.None)
                                        point.Y = newY
                                    Next
                                Next
                            Next
                        End If

                        ' Convert MinorContours Y values from Width to Furrow/Set
                        If (contourGrid.MinorContours IsNot Nothing) Then
                            Dim contours As ArrayList = contourGrid.MinorContours
                            For Each contour As ContourPolygons In contours
                                For Each polygon As ArrayList In contour.Polygons
                                    For Each point In polygon
                                        oldY = point.Y
                                        newY = New SingleParameter(CSng(oldY.Value / furrowSpacing), Units.None)
                                        point.Y = newY
                                    Next
                                Next
                            Next
                        End If

                        ' Convert ErrorContours Y values from Width to Furrow/Set
                        If (contourGrid.ErrorContours IsNot Nothing) Then
                            Dim contours As ArrayList = contourGrid.ErrorContours
                            For Each contour As ContourPolygons In contours
                                For Each polygon As ArrayList In contour.Polygons
                                    For Each point In polygon
                                        oldY = point.Y
                                        newY = New SingleParameter(CSng(oldY.Value / furrowSpacing), Units.None)
                                        point.Y = newY
                                    Next
                                Next
                            Next
                        End If

                        ' Convert ContourCurve Y values from Width to Furrow/Set
                        If (contourGrid.ContourCurve IsNot Nothing) Then
                            For Each polygon As ArrayList In contourGrid.ContourCurve.Polygons
                                For Each point In polygon
                                    oldY = point.Y
                                    newY = New SingleParameter(CSng(oldY.Value / furrowSpacing), Units.None)
                                    point.Y = newY
                                Next
                            Next
                        End If
                    End If

                    mTotalPages = 4 + contourGrid.ContourCount + mWorldWindow.ContourOverlay.NoOfPages
                    mPageNumber = 0
                    ' Start with tab for Operations Parameters
                    AddFurrowOperationsParametersPage(mDictionary.tInputSummary.Translated, mDictionary.tInputSummary.Translated)
                    ' Add contour tabs
                    AddContourPages(designContour, contourGrid)
                    ' Add overlay tab, if requested
                    AddContourOverlay(designContour, contourGrid)
                    ' Add Dreq = Dmin/Dlq graph
                    If (mUnit.BorderCriteriaRef.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
                        AddDreqDminlqFpSvsIndPage(contourGrid)
                    Else
                        AddDreqDminlqQvsIndPage(contourGrid)
                    End If
                End If
            End If

            ' Add Solution (i.e. Water Distribution Diagram)
            Dim title As String = mDictionary.tSolution.Translated
            AddSolutionPage(title)

            ' End with SRFR Comparison
            title = mDictionary.tOperations.Translated
            AddComparisonPage(title)

            ' Update the Operations Parameters to include the Solution Warnings
            UpdateFurrowOperationsParametersPage()

        End If
    End Sub

    Private Sub AddFurrowOperationsParametersPage(ByVal title As String, Optional ByVal tabName As String = "")

        Debug.Assert(title IsNot Nothing)

        If (tabName Is Nothing) Then
            tabName = title
        ElseIf (tabName = "") Then
            tabName = title
        End If

        ' Full Page view for Display, Print & Print Preview
        Dim page As RtfPage = GetNewResultsPage(title, ResultsView)
        mFurrowOperationsParametersPage = page.Rtf

        page.AccessibleName = title
        page.AccessibleDescription = mDictionary.tPrintablePageResults.Translated

        ' Display Operations Parameters
        mPageNumber += 1
        mFurrowOperationsParametersPageNumber = mPageNumber
        UpdateFurrowOperationsParametersPage()

        ' Make the Full Page visible
        AddTabPage(tabName, page)

    End Sub

    Private mFurrowOperationsParametersPageNumber As Integer
    Private Sub UpdateFurrowOperationsParametersPage()

        If (mFurrowOperationsParametersPage IsNot Nothing) Then

            ' mFurrowOperationsParametersPage may be defined but Disposed; this causes an exception
            Try
                ' Clear the old contents
                mFurrowOperationsParametersPage.Clear()

                ' Add Header
                DisplayResultsHeader(mFurrowOperationsParametersPage)

                ' Add the Input Parameters
                mFurrowOperationsParametersPage.SelectionAlignment = HorizontalAlignment.Left

                AdvanceLines(mFurrowOperationsParametersPage, 2)
                AppendBoldUnderlineLine(mFurrowOperationsParametersPage, mDictionary.tInputParameters.Translated)

                DisplaySystemGeometryParameters(mFurrowOperationsParametersPage)
                DisplayInfiltrationParameters(mFurrowOperationsParametersPage)
                DisplayRoughnessParameters(mFurrowOperationsParametersPage)
                DisplayInflowManagementParameters(mFurrowOperationsParametersPage)

                ' Add the Tuning Factors
                DisplayTuningFactors(mFurrowOperationsParametersPage)

                ' Add Errors & Warnings
                DisplayErrorsAndWarnings(mFurrowOperationsParametersPage)

                If (mUnit.SrfrResultsRef.Overflow.Value) Then
                    Dim _time As String = TimeString(mUnit.SrfrResultsRef.OverflowTime.Value, 0)
                    Dim _dist As String = LengthString(mUnit.SrfrResultsRef.OverflowDist.Value, 0)
                    AdvanceLine(mFurrowOperationsParametersPage)
                    AppendLine(mFurrowOperationsParametersPage, mDictionary.tOverflowAt.Translated & " " & _time & ", " & _dist)
                End If

                ' Add Footer
                DisplayResultsFooter(mFurrowOperationsParametersPage, mFurrowOperationsParametersPageNumber, mTotalPages)
            Catch ex As Exception
                ' Set Disposed page to Nothing
                mFurrowOperationsParametersPage = Nothing
            End Try
        End If

    End Sub

#End Region

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

    Private Sub DisplayDesignCriteria(ByVal tbox As RichTextBox)

        Dim _systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
        Dim _borderCriteria As BorderCriteria = mUnit.BorderCriteriaRef

        ' Title + 1 line
        AdvanceLine(tbox)
        AppendBoldUnderlineLine(tbox, mDictionary.tDesignCriteria.Translated)

        If (_borderCriteria.InfiltratedDepthCriterion.Value = InfiltratedDepthCriteria.MinimumDepth) Then
            AppendLine(tbox, "  " & mDictionary.tMinimumDepth.Translated & " (Dmin) = " & mDictionary.tRequiredDepth.Translated & " (Dreq)")
        Else
            AppendLine(tbox, "  " & mDictionary.tLowQuarterDepth.Translated & " (Dlq) = " & mDictionary.tRequiredDepth.Translated & " (Dreq)")
        End If

    End Sub

    Private Sub DisplayTuningFactors(ByVal tbox As RichTextBox)

        Dim _systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
        Dim _borderCriteria As BorderCriteria = mUnit.BorderCriteriaRef
        Dim _surfaceFlow As SurfaceFlow = mUnit.SurfaceFlowRef

        ' Title + 1 line
        AdvanceLine(tbox)
        AppendBoldUnderlineLine(tbox, mDictionary.tTuningFactors.Translated)

        AppendLine(tbox, "  " & mDictionary.tCalibrationPoint.Translated)

        Select Case (mUnit.UnitType.Value)
            Case WorldTypes.OperationsWorld

                AppendLine(tbox, mDictionary.tInflowRate.Translated(15) & ":  " & _borderCriteria.ContourInflowRatePoint.ValueString)
                AppendLine(tbox, mDictionary.tCutoffTime.Translated(15) & ":  " & _borderCriteria.ContourCutoffTimePoint.ValueString)

            Case Else ' Assume WorldTypes.DesignWorld

                AppendLine(tbox, mDictionary.tLength.Translated(15) & ":  " & _borderCriteria.ContourLengthPoint.ValueString)

                Select Case (_borderCriteria.DesignOption.Value)
                    Case DesignOptions.WidthGiven
                        AppendLine(tbox, mDictionary.tInflowRate.Translated(15) & ":  " & _borderCriteria.ContourInflowRatePoint.ValueString)
                    Case Else ' Assume DesignOptions.InflowRateGiven
                        AppendLine(tbox, mDictionary.tWidth.Translated(15) & ":  " & _borderCriteria.ContourWidthPoint.ValueString)
                End Select
        End Select

        AdvanceLine(tbox)
        AppendLine(tbox, "  " & mDictionary.tUpstreamDepthAtCalibrationPoint.Translated & ":  " & _surfaceFlow.UpstreamDepth.ValueString)
        AdvanceLine(tbox)
        AppendLine(tbox, "  Sigma Y:  " & _borderCriteria.SigmaY.ValueString)

        Select Case _systemGeometry.CrossSection.Value
            Case CrossSections.Furrow
                AppendText(tbox, "     Phi0:  " & _borderCriteria.Phi0Furrows.ValueString)
                AppendText(tbox, "     Phi1:  " & _borderCriteria.Phi1Furrows.ValueString)
                AppendText(tbox, "     Phi2:  " & _borderCriteria.Phi2Furrows.ValueString)
                AppendLine(tbox, "     Phi3:  " & _borderCriteria.Phi3Furrows.ValueString)
            Case Else ' Assume Basin / Border
                AppendText(tbox, "     Phi0:  " & _borderCriteria.Phi0Borders.ValueString)
                AppendText(tbox, "     Phi1:  " & _borderCriteria.Phi1Borders.ValueString)
                AppendText(tbox, "     Phi2:  " & _borderCriteria.Phi2Borders.ValueString)
                AppendLine(tbox, "     Phi3:  " & _borderCriteria.Phi3Borders.ValueString)
        End Select

    End Sub

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

        _desc1 += UpstreamConditionSelections(_upstream).Value & ", "
        _desc1 += DownstreamConditionSelections(_downstream).Value

        AppendLine(tbox, " - " & _desc1)

        ' Add bottom description
        Select Case (_bottom)
            Case BottomDescriptions.Slope
                _desc1 = LeftJustifyFill(_systemGeometry.Slope.FullXlateText, _col, "  ")
            Case Globals.BottomDescriptions.SlopeTable, Globals.BottomDescriptions.AvgFromSlopeTable
                _desc1 = LeftJustifyFill(mDictionary.tSlopeDefinedBySlopeTable.Translated, _col, "  ")
                _desc1 += mDictionary.tAverageSlope.Translated & " = " & SlopeString(_systemGeometry.AverageSlopeFromElevationTable, 0)
            Case Globals.BottomDescriptions.ElevationTable, Globals.BottomDescriptions.AvgFromElevTable
                _desc1 = LeftJustifyFill(mDictionary.tSlopeDefinedByElevationTable.Translated, _col, "  ")
                _desc1 += mDictionary.tAverageSlope.Translated & " = " & SlopeString(_systemGeometry.AverageSlopeFromElevationTable, 0)
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

                _desc1 += mDictionary.tArea.Translated & " = " & AreaString(_area, 0)

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

                            _desc2 += mDictionary.tTabulatedCrossSection.Translated

                        Else

                            Dim _const As String = mDictionary.tConstant.Translated & " = " & _systemGeometry.PowerLawConstantString & ", "
                            Dim _rho1, _rho2 As Double
                            _systemGeometry.PowerLawRho(_rho1, _rho2)

                            _desc1 += _systemGeometry.WidthAt100mm.FullXlateText
                            _desc2 += _const + _systemGeometry.PowerLawExponent.FullXlateText
                            _desc3 += _systemGeometry.MaximumDepth.FullXlateText
                            _desc4 += "Rho1 = " & Format(_rho1, "0.0###") & ", Rho2 = " & Format(_rho2, "0.0###")

                        End If

                    Case Else ' Trapezoid Furrow

                        If ((worldType = WorldTypes.SimulationWorld) And (_furrowShape = FurrowShapes.Trapezoid) And (_systemGeometry.EnableTabulatedFurrowShape.Value)) Then

                            _desc2 += mDictionary.tTabulatedCrossSection.Translated

                        Else

                            _desc1 += _systemGeometry.BottomWidth.FullXlateText
                            _desc2 += _systemGeometry.SideSlope.FullXlateText
                            _desc3 += _systemGeometry.MaximumDepth.FullXlateText

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


                Case InfiltrationFunctions.Hydrus1D

                    _desc1 = "  " & mDictionary.tHydrusInfiltration.Translated & _desc1


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

                    _desc2 = "  ThetaS = " & _soilCropProperties.EffectivePorosityGA.ValueString
                    _desc2 += "                c = " & _soilCropProperties.GreenAmptC.ValueString

                    _desc3 = "  Theta0 = " & _soilCropProperties.InitialWaterContentGA.ValueString
                    _desc4 = "  hf     = " & _soilCropProperties.WettingFrontPressureHeadGA.ValueString
                    _desc5 = "  Ks     = " & _soilCropProperties.HydraulicConductivityGA.ValueString

                Case InfiltrationFunctions.Hydrus1D
                    AppendLine(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)

                    _desc2 = "  HYDRUS Project:"
                    _desc3 = "    " & _soilCropProperties.HydrusProject.Value

                Case InfiltrationFunctions.WarrickGreenAmpt
                    AppendLine(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)

                    _desc2 = "  ThetaS = " & _soilCropProperties.SaturatedWaterContentWGA.ValueString
                    _desc2 += "                c = " & _soilCropProperties.WarrickGreenAmptC.ValueString

                    _desc3 = "  Theta0 = " & _soilCropProperties.InitialWaterContentWGA.ValueString
                    _desc4 = "  hf     = " & _soilCropProperties.WettingFrontPressureHeadWGA.ValueString
                    _desc5 = "  Ks     = " & _soilCropProperties.HydraulicConductivityWGA.ValueString

                Case Else ' Assume Branch Function
                    AppendText(tbox, " - " & InfiltrationFunctionSelections(_infiltrationFunction).Value)
                    AppendLine(tbox, ":  Z = k*T^a + c   then   Z = Zb + (b*T)")

                    Dim bt As Double = _soilCropProperties.BranchTime

                    _desc4 = "  c = " & _soilCropProperties.KostiakovC_BF.ValueString

                    _desc5 = "  b = " & _soilCropProperties.BranchB_BF.ValueString
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
                    _desc1 += ", " & _soilCropProperties.ManningAn.FullXlateText
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

                        _desc1 += mDictionary.tFurrowSetInflowRate.Translated & " = " & _inflowManagement.InflowRate.ValueString
                End Select

                Dim _cutoff As CutoffMethods = CType(_inflowManagement.CutoffMethod.Value, CutoffMethods)

                Select Case (_cutoff)
                    Case Globals.CutoffMethods.TimeBased
                        _desc2 = LeftJustifyFill(_inflowManagement.CutoffTime.FullXlateText, _col, "  ")
                    Case Globals.CutoffMethods.DistanceBased
                        _desc2 = LeftJustifyFill(_inflowManagement.CutoffLocationRatio.FullXlateText, _col, "  ")
                    Case Globals.CutoffMethods.DistanceInfDepth
                        _desc2 = LeftJustifyFill(_inflowManagement.CutoffLocationRatio.FullXlateText, _col, "  ")
                        _desc2 += "& " & _inflowManagement.CutoffInfiltrationDepth.FullXlateText
                    Case Globals.CutoffMethods.DistanceOppTime
                        _desc2 = LeftJustifyFill(_inflowManagement.CutoffLocationRatio.FullXlateText, _col, "  ")
                        _desc2 += "& " & _inflowManagement.CutoffOpportunityTime.FullXlateText
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

                _desc4 += _inflowManagement.RequiredDepth.FullXlateText
                _desc5 += _inflowManagement.UnitWaterCost.FullXlateText

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

                _desc5 = "  " & _inflowManagement.RequiredDepth.FullXlateText(_col)
                _desc5 += _inflowManagement.UnitWaterCost.FullXlateText

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

#End Region

#Region " Contour Results "
    '
    ' Add individual Contour results pages
    '
    Private Sub AddContourPages(ByVal designContour As ContourParameter, _
                                ByVal contourGrid As ContourGrid)

        ' Add tab for each contour plot
        Dim page As grf_ContourPlot
        Dim panel As grf_ContourPlot
        Dim paramIndex As Integer
        Dim paramName As String = " "
        Dim paramSymbol As String = " "
        For Each obj As Object In contourGrid.MajorContours
            If (obj.GetType Is GetType(ContourPolygons)) Then
                Dim contour As ContourPolygons = DirectCast(obj, ContourPolygons)
                If Not (paramName = contour.Name) Then
                    paramIndex = contour.Index
                    paramName = contour.Name
                    paramSymbol = contour.Symbol

                    ' Full Page view for Display, Print & Print Preview
                    page = GetNewContourGraphPage(designContour, paramName, paramIndex)
                    AddResultsPage(paramName, paramSymbol, page)

                    ' Graphic Only view for Display
                    panel = GetNewContourGraphPanel(designContour, paramName, paramIndex)
                    AddResultsPanel(paramName, paramSymbol, panel)
                End If
            End If
        Next

    End Sub
    '
    ' Add Contour Overlay
    '
    Private Sub AddContourOverlay(ByVal designContour As ContourParameter, _
                                  ByVal contourGrid As ContourGrid)

        Dim overlaysSelected As BorderContourOverlay = mWorldWindow.ContourOverlay
        Dim majorOverlays As ArrayList = New ArrayList
        Dim minorOverlays As ArrayList = New ArrayList

        If (overlaysSelected IsNot Nothing) Then
            If (0 < overlaysSelected.NoOfPages) Then
                ' Add tab for contour overlay
                Dim page As grf_ContourPlot
                Dim panel As grf_ContourPlot
                Dim paramIndex As Integer
                Dim paramName As String = " "
                Dim paramSymbol As String = " "

                ' Add overlays
                Dim majorCount As Integer = overlaysSelected.MajorOverlays.Count
                Dim minorCount As Integer = overlaysSelected.MinorOverlays.Count

                If (0 < majorCount) Then
                    For idx As Integer = 0 To majorCount - 1

                        ' Get Parameter Index & Name
                        paramIndex = CInt(overlaysSelected.MajorOverlays(idx))
                        paramName = Me.ParameterNameFromIndex(paramIndex, contourGrid)

                        Dim majorContours As ArrayList = New ArrayList
                        Dim minorContours As ArrayList = New ArrayList

                        ' Add selected major contours to overlay
                        For Each majorContour As ContourPolygons In contourGrid.MajorContours
                            If (paramName = majorContour.Name) Then
                                majorContours.Add(majorContour)

                                ' Are minor contours also to be added?
                                If ((majorContours.Count = 1) And (0 < minorCount)) Then
                                    For jdx As Integer = 0 To minorCount - 1
                                        If (paramIndex = CInt(overlaysSelected.MinorOverlays(jdx))) Then
                                            ' Yes, add minor contours
                                            For Each minorContour As ContourPolygons In contourGrid.MinorContours
                                                If (paramName = minorContour.Name) Then
                                                    minorContours.Add(minorContour)
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                            End If
                        Next

                        If (0 < majorContours.Count) Then
                            majorOverlays.Add(majorContours)
                            minorOverlays.Add(minorContours)
                        End If
                    Next
                End If

                If (0 < majorCount) Then
                    ' Full Page view for Display, Print & Print Preview
                    page = GetNewContourGraphPage(designContour, mDictionary.tContourOverlay.Translated, paramIndex)
                    If (0 < majorOverlays.Count) Then
                        page.MajorOverlayContours = majorOverlays
                        page.MinorOverlayContours = minorOverlays
                    End If
                    AddResultsPage(mDictionary.tContourOverlay.Translated, mDictionary.tOverlay.Translated, page)

                    ' Graphic Only view for Display
                    panel = GetNewContourGraphPanel(designContour, mDictionary.tContourOverlay.Translated, paramIndex)
                    If (0 < majorOverlays.Count) Then
                        panel.MajorOverlayContours = majorOverlays
                        panel.MinorOverlayContours = minorOverlays
                    End If
                    AddResultsPanel(mDictionary.tContourOverlay.Translated, mDictionary.tOverlay.Translated, panel)

                End If

            End If
        End If

    End Sub
    '
    ' Add Dreq = Dmin/lq page (Q vs. Indicators)
    '
    Private Sub AddDreqDminlqQvsIndPage(ByVal contourGrid As ContourGrid)

        If (mUnit IsNot Nothing) Then
            Dim _contourCurve As ContourPolygons = contourGrid.ContourCurve
            If (_contourCurve IsNot Nothing) Then

                ' Get model references
                Dim _inflowManagement As InflowManagement = mUnit.InflowManagementRef
                Dim _borderCriteria As BorderCriteria = mUnit.BorderCriteriaRef

                Dim _title As String = "Dreq = Dmin = " & _inflowManagement.RequiredDepth.ValueString
                Dim _tabName As String = "Dreq = Dmin"

                If (_borderCriteria.InfiltratedDepthCriterion.Value = InfiltratedDepthCriteria.LowQuarterDepth) Then
                    _title = "Dreq = Dlq = " & _inflowManagement.RequiredDepth.ValueString
                    _tabName = "Dreq = Dlq"
                End If

                ' Build DataTable for left-axis curves - Q vs. AE / DU / RO / DP
                Dim leftAxisTable As DataTable = New DataTable("Q vs. Indicators")
                leftAxisTable.ExtendedProperties.Add("LeftAxisTitle", mDictionary.tPerformanceIndicators.Translated & " (%)")

                Dim _aeQcol As DataColumn = New DataColumn(sQinX, GetType(Double))
                leftAxisTable.Columns.Add(_aeQcol)

                Dim _aeCol As DataColumn = New DataColumn("PAEmin = AE (%)", GetType(Double))
                If (_borderCriteria.InfiltratedDepthCriterion.Value = InfiltratedDepthCriteria.LowQuarterDepth) Then
                    _aeCol.ColumnName = "PAElq = AE (%)"
                End If
                _aeCol.ExtendedProperties.Add("Key", True)
                _aeCol.ExtendedProperties.Add("Color", Drawing.Color.Black)
                leftAxisTable.Columns.Add(_aeCol)

                If (_borderCriteria.InfiltratedDepthCriterion.Value = InfiltratedDepthCriteria.LowQuarterDepth) Then
                    Dim _duLqCol As DataColumn = New DataColumn("DUlq (%)", GetType(Double))
                    _duLqCol.ExtendedProperties.Add("Key", True)
                    _duLqCol.ExtendedProperties.Add("Color", Drawing.Color.Brown)
                    leftAxisTable.Columns.Add(_duLqCol)
                Else ' Minimum Depth
                    Dim _duMinCol As DataColumn = New DataColumn("DUmin (%)", GetType(Double))
                    _duMinCol.ExtendedProperties.Add("Key", True)
                    _duMinCol.ExtendedProperties.Add("Color", Drawing.Color.Brown)
                    leftAxisTable.Columns.Add(_duMinCol)
                End If

                Dim _roCol As DataColumn = New DataColumn("RO (%)", GetType(Double))
                _roCol.ExtendedProperties.Add("Key", True)
                _roCol.ExtendedProperties.Add("Color", Drawing.Color.Magenta)
                leftAxisTable.Columns.Add(_roCol)

                Dim _dpCol As DataColumn = New DataColumn("DP (%)", GetType(Double))
                _dpCol.ExtendedProperties.Add("Key", True)
                _dpCol.ExtendedProperties.Add("Color", Drawing.Color.Red)
                leftAxisTable.Columns.Add(_dpCol)

                ' Build DataTable for right-axis curves - Q vs. Tco
                Dim rightAxisTable As DataTable = New DataTable("Q vs. Tco")
                rightAxisTable.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                Dim _tcoQcol As DataColumn = New DataColumn(sQinX, GetType(Double))
                rightAxisTable.Columns.Add(_tcoQcol)

                Dim _tcoCol As DataColumn = New DataColumn("Tco (s)", GetType(Double))
                _tcoCol.ExtendedProperties.Add("Key", True)
                _tcoCol.ExtendedProperties.Add("Color", Drawing.Color.Blue)
                rightAxisTable.Columns.Add(_tcoCol)

                ' Build DataTable for Q vs. R (data for tooltip)
                Dim _rTable As DataTable = New DataTable("Q vs. R")
                _rTable.ExtendedProperties.Add("Color", Drawing.Color.Red)

                Dim _rQcol As DataColumn = New DataColumn(sQinX, GetType(Double))
                _rTable.Columns.Add(_rQcol)

                Dim _rCol As DataColumn = New DataColumn("XR ()", GetType(Double))
                _rTable.Columns.Add(_rCol)

                ' Transfer left-axis data from Contour Curve to XY Curve
                For Each _curve As ArrayList In _contourCurve.Polygons
                    For Each _point As ContourPoint In _curve
                        If Not (_point.HasError) Then
                            Dim _Q As Single = DirectCast(_point.Y, SingleParameter).Value
                            Dim _AE As Single = DirectCast(_point.Z(Analysis.AeIndex), SingleParameter).Value
                            Dim _DU As Single = DirectCast(_point.Z(Analysis.DuIndex), SingleParameter).Value
                            Dim _RO As Single = DirectCast(_point.Z(Analysis.RoIndex), SingleParameter).Value
                            Dim _DP As Single = DirectCast(_point.Z(Analysis.DpIndex), SingleParameter).Value

                            Dim _row As DataRow = leftAxisTable.NewRow
                            _row.Item(0) = _Q
                            _row.Item(1) = _AE
                            _row.Item(2) = _DU
                            _row.Item(3) = _RO
                            _row.Item(4) = _DP
                            leftAxisTable.Rows.Add(_row)
                        End If
                    Next
                Next

                ' Transfer right-axis data from Contour Curve to XY Curve
                For Each _curve As ArrayList In _contourCurve.Polygons
                    For Each _point As ContourPoint In _curve
                        If Not (_point.HasError) Then
                            Dim _Q As Single = DirectCast(_point.Y, SingleParameter).Value
                            Dim _Tco As Single = DirectCast(_point.X, SingleParameter).Value

                            Dim _row As DataRow = rightAxisTable.NewRow
                            _row.Item(0) = _Q
                            _row.Item(1) = _Tco
                            rightAxisTable.Rows.Add(_row)
                        End If
                    Next
                Next

                ' Transfer extra data for tooltip to XY Curve
                For Each _curve As ArrayList In _contourCurve.Polygons
                    For Each _point As ContourPoint In _curve
                        If Not (_point.HasError) Then
                            Dim _Q As Single = DirectCast(_point.Y, SingleParameter).Value
                            Dim _R As Single = DirectCast(_point.Z(Analysis.TcoIndex), SingleParameter).Value

                            Dim _row As DataRow = _rTable.NewRow
                            _row.Item(0) = _Q
                            _row.Item(1) = _R
                            _rTable.Rows.Add(_row)
                        End If
                    Next
                Next

                Dim _minX As Double = MinColumnValue(leftAxisTable, 0)

                ' Build DataSet for the Dreq=Dmin graph
                Dim _dataSet As DataSet = New DataSet(_title)
                _dataSet.Tables.Add(leftAxisTable)   ' Curve #1
                _dataSet.Tables.Add(rightAxisTable)  ' Curve #2

                Dim _x2yGraph As grf_DreqDmin
                '
                ' Full Page view for Display, Print & Print Preview
                '
                _dataSet.Tables.Add(_rTable)    ' Extra tooltip data

                _x2yGraph = Me.GetNewDreqDminPage(_dataSet, _title)
                _x2yGraph.DisplayKey = True
                _x2yGraph.SetMinMaxX(_minX, _x2yGraph.MaxX)
                _x2yGraph.UnitsX = UnitsDefinition.Units.Cms
                _x2yGraph.UnitsY = UnitsDefinition.Units.Percentage
                _x2yGraph.UnitsY2 = UnitsDefinition.Units.Seconds

                AddResultsPage(_title, _tabName, _x2yGraph)
                '
                ' Graphic Only view for Display
                '
                _dataSet.Tables.Add(_rTable)    ' Extra tooltip data

                _x2yGraph = GetNewDreqDminPanel(_dataSet, _title)
                _x2yGraph.DisplayKey = True
                _x2yGraph.SetMinMaxX(_minX, _x2yGraph.MaxX)
                _x2yGraph.UnitsX = UnitsDefinition.Units.Cms
                _x2yGraph.UnitsY = UnitsDefinition.Units.Percentage
                _x2yGraph.UnitsY2 = UnitsDefinition.Units.Seconds

                AddResultsPanel(_title, _tabName, _x2yGraph)

            End If
        End If

    End Sub
    '
    ' Add Dreq = Dmin/lq page (Furrows/Set vs. Indicators)
    '
    Private Sub AddDreqDminlqFpSvsIndPage(ByVal contourGrid As ContourGrid)

        If (mUnit IsNot Nothing) Then
            Dim _contourCurve As ContourPolygons = contourGrid.ContourCurve
            If (_contourCurve IsNot Nothing) Then

                ' Get model references
                Dim _inflowManagement As InflowManagement = mUnit.InflowManagementRef
                Dim _borderCriteria As BorderCriteria = mUnit.BorderCriteriaRef

                Dim _title As String = "Dreq = Dmin = " & _inflowManagement.RequiredDepth.ValueString
                Dim _tabName As String = "Dreq = Dmin"

                If (_borderCriteria.InfiltratedDepthCriterion.Value = InfiltratedDepthCriteria.LowQuarterDepth) Then
                    _title = "Dreq = Dlq = " & _inflowManagement.RequiredDepth.ValueString
                    _tabName = "Dreq = Dlq"
                End If

                ' Build DataTable for left-axis curves - Furrows/Set vs. AE / DU / RO / DP
                Dim leftAxisTable As DataTable = New DataTable("Furrows/Set vs. Indicators")
                leftAxisTable.ExtendedProperties.Add("LeftAxisTitle", mDictionary.tPerformanceIndicators.Translated & " (%)")

                Dim _aeFpScol As DataColumn = New DataColumn("Furrows/Set", GetType(Double))
                leftAxisTable.Columns.Add(_aeFpScol)

                Dim _aeCol As DataColumn = New DataColumn("PAEmin = AE (%)", GetType(Double))
                If (_borderCriteria.InfiltratedDepthCriterion.Value = InfiltratedDepthCriteria.LowQuarterDepth) Then
                    _aeCol.ColumnName = "PAElq = AE (%)"
                End If
                _aeCol.ExtendedProperties.Add("Key", True)
                _aeCol.ExtendedProperties.Add("Color", Drawing.Color.Black)
                leftAxisTable.Columns.Add(_aeCol)

                If (_borderCriteria.InfiltratedDepthCriterion.Value = InfiltratedDepthCriteria.LowQuarterDepth) Then
                    Dim _duLqCol As DataColumn = New DataColumn("DUlq (%)", GetType(Double))
                    _duLqCol.ExtendedProperties.Add("Key", True)
                    _duLqCol.ExtendedProperties.Add("Color", Drawing.Color.Brown)
                    leftAxisTable.Columns.Add(_duLqCol)
                Else ' Minimum Depth
                    Dim _duMinCol As DataColumn = New DataColumn("DUmin (%)", GetType(Double))
                    _duMinCol.ExtendedProperties.Add("Key", True)
                    _duMinCol.ExtendedProperties.Add("Color", Drawing.Color.Brown)
                    leftAxisTable.Columns.Add(_duMinCol)
                End If

                Dim _roCol As DataColumn = New DataColumn("RO (%)", GetType(Double))
                _roCol.ExtendedProperties.Add("Key", True)
                _roCol.ExtendedProperties.Add("Color", Drawing.Color.Magenta)
                leftAxisTable.Columns.Add(_roCol)

                Dim _dpCol As DataColumn = New DataColumn("DP (%)", GetType(Double))
                _dpCol.ExtendedProperties.Add("Key", True)
                _dpCol.ExtendedProperties.Add("Color", Drawing.Color.Red)
                leftAxisTable.Columns.Add(_dpCol)

                ' Build DataTable for right-axis curves - Furrows/Set vs. Tco
                Dim rightAxisTable As DataTable = New DataTable("Furrows/Set vs. Tco")
                rightAxisTable.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                Dim _tcoFpScol As DataColumn = New DataColumn("Furrows/Set", GetType(Double))
                rightAxisTable.Columns.Add(_tcoFpScol)

                Dim _tcoCol As DataColumn = New DataColumn("Tco (s)", GetType(Double))
                _tcoCol.ExtendedProperties.Add("Key", True)
                _tcoCol.ExtendedProperties.Add("Color", Drawing.Color.Blue)
                rightAxisTable.Columns.Add(_tcoCol)

                ' Build DataTable for Furrows/Set vs. R (data for tooltip)
                Dim _rTable As DataTable = New DataTable("Furrows/Set vs. R")
                _rTable.ExtendedProperties.Add("Color", Drawing.Color.Red)

                Dim _rFpScol As DataColumn = New DataColumn("Furrows/Set", GetType(Double))
                _rTable.Columns.Add(_rFpScol)

                Dim _rCol As DataColumn = New DataColumn("XR ()", GetType(Double))
                _rTable.Columns.Add(_rCol)

                ' Transfer left-axis data from Contour Curve to XY Curve
                For Each _curve As ArrayList In _contourCurve.Polygons
                    For Each _point As ContourPoint In _curve
                        If Not (_point.HasError) Then
                            Dim _FpS As Single = DirectCast(_point.Y, SingleParameter).Value
                            Dim _AE As Single = DirectCast(_point.Z(Analysis.AeIndex), SingleParameter).Value
                            Dim _DU As Single = DirectCast(_point.Z(Analysis.DuIndex), SingleParameter).Value
                            Dim _RO As Single = DirectCast(_point.Z(Analysis.RoIndex), SingleParameter).Value
                            Dim _DP As Single = DirectCast(_point.Z(Analysis.DpIndex), SingleParameter).Value

                            Dim _row As DataRow = leftAxisTable.NewRow
                            _row.Item(0) = _FpS
                            _row.Item(1) = _AE
                            _row.Item(2) = _DU
                            _row.Item(3) = _RO
                            _row.Item(4) = _DP
                            leftAxisTable.Rows.Add(_row)
                        End If
                    Next
                Next

                ' Transfer right-axis data from Contour Curve to XY Curve
                For Each _curve As ArrayList In _contourCurve.Polygons
                    For Each _point As ContourPoint In _curve
                        If Not (_point.HasError) Then
                            Dim _FpS As Single = DirectCast(_point.Y, SingleParameter).Value
                            Dim _Tco As Single = DirectCast(_point.X, SingleParameter).Value

                            Dim _row As DataRow = rightAxisTable.NewRow
                            _row.Item(0) = _FpS
                            _row.Item(1) = _Tco
                            rightAxisTable.Rows.Add(_row)
                        End If
                    Next
                Next

                ' Transfer extra data for tooltip to XY Curve
                For Each _curve As ArrayList In _contourCurve.Polygons
                    For Each _point As ContourPoint In _curve
                        If Not (_point.HasError) Then
                            Dim _FpS As Single = DirectCast(_point.Y, SingleParameter).Value
                            Dim _R As Single = DirectCast(_point.Z(Analysis.TcoIndex), SingleParameter).Value

                            Dim _row As DataRow = _rTable.NewRow
                            _row.Item(0) = _FpS
                            _row.Item(1) = _R
                            _rTable.Rows.Add(_row)
                        End If
                    Next
                Next

                Dim _minX As Double = MinColumnValue(leftAxisTable, 0)

                ' Build DataSet for the Dreq=Dmin graph
                Dim _dataSet As DataSet = New DataSet(_title)
                _dataSet.Tables.Add(leftAxisTable)   ' Curve #1
                _dataSet.Tables.Add(rightAxisTable)  ' Curve #2

                Dim _x2yGraph As grf_DreqDmin
                '
                ' Full Page view for Display, Print & Print Preview
                '
                _dataSet.Tables.Add(_rTable)    ' Extra tooltip data

                _x2yGraph = Me.GetNewDreqDminPage(_dataSet, _title)
                _x2yGraph.DisplayKey = True
                _x2yGraph.SetMinMaxX(_minX, _x2yGraph.MaxX)
                _x2yGraph.UnitsX = UnitsDefinition.Units.None
                _x2yGraph.UnitsY = UnitsDefinition.Units.Percentage
                _x2yGraph.UnitsY2 = UnitsDefinition.Units.Seconds

                AddResultsPage(_title, _tabName, _x2yGraph)
                '
                ' Graphic Only view for Display
                '
                _dataSet.Tables.Add(_rTable)    ' Extra tooltip data

                _x2yGraph = GetNewDreqDminPanel(_dataSet, _title)
                _x2yGraph.DisplayKey = True
                _x2yGraph.SetMinMaxX(_minX, _x2yGraph.MaxX)
                _x2yGraph.UnitsX = UnitsDefinition.Units.None
                _x2yGraph.UnitsY = UnitsDefinition.Units.Percentage
                _x2yGraph.UnitsY2 = UnitsDefinition.Units.Seconds

                AddResultsPanel(_title, _tabName, _x2yGraph)

            End If
        End If

    End Sub
    '
    ' Get Parameter Name from Parameter Index
    '
    Private Function ParameterNameFromIndex(ByVal idx As Integer, _
                                            ByVal contourGrid As ContourGrid) As String
        Dim paramName As String = " "

        If (mUnit.UnitType.Value = WorldTypes.OperationsWorld) Then
            If (idx = Globals.PerformanceParameters.R) Then
                idx = Globals.PerformanceParameters.Tco
            End If
        End If

        For Each obj As Object In contourGrid.MajorContours
            If (obj.GetType Is GetType(ContourPolygons)) Then
                Dim contour As ContourPolygons = DirectCast(obj, ContourPolygons)
                If (idx = contour.Index) Then
                    paramName = contour.Name
                    Exit For
                End If
            End If
        Next

        Return paramName
    End Function

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
                    _line += " " & _word

                    ' Strip the next word from Detail
                    Dim _space As Integer = _detail.IndexOf(" ")
                    If (0 < _space) Then
                        _word = _detail.Substring(0, _space)
                        _detail = _detail.Substring(_space).Trim
                    Else
                        _word = _detail ' The last word
                        If (_line.Length + _word.Length + 1 < 78) Then
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

#Region " Solution Methods "

    Private Sub AddComparisonPage(ByVal _analysis As String)

        If (mUnit IsNot Nothing) Then

            ' Get model references
            Dim _systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
            Dim _inflowManagement As InflowManagement = mUnit.InflowManagementRef
            Dim _surfaceFlow As SurfaceFlow = mUnit.SurfaceFlowRef
            Dim _subsurfaceFlow As SubsurfaceFlow = mUnit.SubsurfaceFlowRef
            Dim _srfrResults As SrfrResults = mUnit.SrfrResultsRef
            Dim _criteria As BorderCriteria = mUnit.BorderCriteriaRef

            Dim _2dGraph As grf_XYGraph
            '
            ' Create DataSets for graphs
            '   Advance / Recession
            '   Infiltration / Target Depth
            '   Inflow / Runoff Hydrographs
            '
            Dim tHydraulicSummary As String = mDictionary.tHydraulicSummary.Translated

            Dim _advRec As DataSet = New DataSet(tHydraulicSummary)
            Dim _infilt As DataSet = New DataSet(tHydraulicSummary)
            Dim _hydro As DataSet = New DataSet(tHydraulicSummary)

            _advRec.ExtendedProperties.Add("ExtTitle", "w/ " & mDictionary.tSimulationResults.Translated)

            ' Get SRFR Simulation Results
            Dim _simAdv As DataTable = Nothing
            If (_srfrResults.Advance IsNot Nothing) Then
                _simAdv = _srfrResults.Advance.Value
            End If
            Dim _simRec As DataTable = Nothing
            If (_srfrResults.Recession IsNot Nothing) Then
                _simRec = _srfrResults.Recession.Value
            End If
            Dim _simInf As DataTable = Nothing
            If (_srfrResults.LongitudinalInfiltration IsNot Nothing) Then
                _simInf = _srfrResults.LongitudinalInfiltration.Value
            End If
            Dim _hydroflow As DataTable = Nothing
            If (_srfrResults.FlowHydrographs IsNot Nothing) Then
                _hydroflow = _srfrResults.FlowHydrographs.Value
            End If

            If (DataTableHasData(_simAdv) _
            And DataTableHasData(_simInf) _
            And DataTableHasData(_hydroflow)) Then

                _simAdv.TableName = "Simulation Advance"
                _simRec.TableName = "Simulation Recession"
                _simInf.TableName = "Simulation Infiltration"
                _hydroflow.TableName = "Simulation Hydrographs"

                ' Get Analysis Results
                Dim _advance As DataTable = _surfaceFlow.Advance.Value
                Dim _recession As DataTable = _surfaceFlow.Recession.Value
                Dim _infiltration As DataTable = _subsurfaceFlow.LongitudinalInfiltration.Value

                _advance.TableName = "Advance"
                _recession.TableName = "Recession"
                _infiltration.TableName = mDictionary.tInfiltration.Translated

                Dim _inflowRate As Double = _inflowManagement.InflowRate.Value
                If (mUnit.CrossSection = CrossSections.Furrow) Then
                    _inflowRate /= _systemGeometry.FurrowsPerSet.Value
                End If
                Dim _cutoffTime As Double = _inflowManagement.CutoffTime.Value
                Dim _qin As DataTable = _inflowManagement.HydrographInflowTable(_inflowRate, _cutoffTime)

                ' Advance / Recession
                _advRec.Tables.Add(_advance.Copy)
                _advRec.Tables.Add(_recession.Copy)

                _simAdv.ExtendedProperties.Add("Color", WinSRFR.UserPreferences.Color2)
                _advRec.ExtendedProperties.Add("Color", WinSRFR.UserPreferences.Color2)
                _advRec.Tables.Add(_simAdv.Copy)
                If (_simRec IsNot Nothing) Then
                    _advRec.Tables.Add(_simRec.Copy)
                End If

                ' Infiltration / Target Depth
                Dim _label As String = mDictionary.tRequiredDepth.Translated
                Dim _depth As Double = _inflowManagement.RequiredDepth.Value
                Dim _fieldLength As Double = _systemGeometry.Length.Value
                Dim _dreqTable As DataTable = DepthTable(_label, _depth, _infiltration.Columns(0).ColumnName, _fieldLength)

                _dreqTable.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                _infilt.Tables.Add(_infiltration.Copy)
                _infilt.Tables.Add(_dreqTable)

                _simInf.ExtendedProperties.Add("Color", WinSRFR.UserPreferences.Color2)
                _infilt.Tables.Add(_simInf.Copy)

                ' Flow Hydrographs
                _hydroflow.ExtendedProperties.Add("Color", WinSRFR.UserPreferences.Color2)
                _hydro.Tables.Add(_hydroflow.Copy)
                _hydro.Tables.Add(_qin)

                '
                ' Full Page view for Display, Print & Print Preview
                '
                _2dGraph = GetNewHydraulicSummaryPage(_advRec, _infilt, _hydro, tHydraulicSummary)
                _2dGraph.UnitsX = UnitsDefinition.Units.Meters
                _2dGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPage(tHydraulicSummary, tHydraulicSummary, _2dGraph)
                '
                ' Graphic Only view for Display
                '
                _2dGraph = GetNewHydraulicSummaryPanel(_advRec, _infilt, _hydro, tHydraulicSummary)
                _2dGraph.UnitsX = UnitsDefinition.Units.Meters
                _2dGraph.UnitsY = UnitsDefinition.Units.Seconds

                AddResultsPanel(tHydraulicSummary, tHydraulicSummary, _2dGraph)

            End If
        End If

    End Sub

    Private Sub AddSolutionPage(ByVal title As String, Optional ByVal tabName As String = "")

        If (mUnit IsNot Nothing) Then

            If (tabName Is Nothing) Then
                tabName = title
            ElseIf (tabName = "") Then
                tabName = title
            End If

            ' Get model references
            Dim systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
            Dim inflowManagement As InflowManagement = mUnit.InflowManagementRef
            Dim borderCriteria As BorderCriteria = mUnit.BorderCriteriaRef
            Dim analysis As Analysis = mWorldWindow.CurrentAnalysis

            ' Get values for selected contour point
            Dim x, y As Double

            Select Case (mUnit.UnitType.Value)
                Case WorldTypes.DesignWorld
                    ' X is always Length
                    x = systemGeometry.Length.Value

                    ' Y is either Width or Flow Rate
                    If (borderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
                        ' Y is Width
                        y = systemGeometry.Width.Value
                    Else
                        ' Y is Flow Yate
                        y = inflowManagement.InflowRate.Value
                    End If

                Case WorldTypes.OperationsWorld
                    ' X is either Cutoff Time or Cutoff Distance Ratio
                    If (inflowManagement.CutoffMethod.Value = CutoffMethods.TimeBased) Then
                        ' X is Cutoff Time
                        x = inflowManagement.CutoffTime.Value
                    Else
                        ' X is Cutoff Distance Ratio
                        x = inflowManagement.CutoffLocationRatio.Value
                    End If

                    ' Y is either Width or Inflow Rate
                    If (borderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
                        If (mUnit.CrossSection = CrossSections.Furrow) Then
                            Dim furrowsPerSetParam As DoubleParameter = systemGeometry.FurrowsPerSet
                            y = furrowsPerSetParam.Value

                            If (y < borderCriteria.MinContourFurrowsPerSet.Value) Then
                                y = borderCriteria.MinContourFurrowsPerSet.Value
                            End If

                            If (y > borderCriteria.MaxContourFurrowsPerSet.Value) Then
                                y = borderCriteria.MaxContourFurrowsPerSet.Value
                            End If

                        Else ' Border
                            y = systemGeometry.Width.Value
                        End If

                    Else ' Width given
                        y = inflowManagement.InflowRate.Value
                    End If
            End Select

            ' Build the DataSet for the WDD graph
            Dim dataSet As DataSet = WddDataSet(mUnit, analysis, x, y)

            Dim _2dGraph As grf_XYGraph

            '
            ' Full Page view for Display, Print & Print Preview
            '
            _2dGraph = Me.GetNewXYGraphPage(dataSet, title)
            _2dGraph.DisplayKey = True
            _2dGraph.UnitsX = UnitsDefinition.Units.Meters
            _2dGraph.UnitsY = UnitsDefinition.Units.Millimeters
            _2dGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
            _2dGraph.MinY = 0.0 ' Start Infiltration graph at top of soil

            AddResultsPage(title, tabName, _2dGraph)
            '
            ' Graphic Only view for Display
            '
            _2dGraph = GetNewXYGraphPanel(dataSet, title)
            _2dGraph.DisplayKey = True
            _2dGraph.UnitsX = UnitsDefinition.Units.Meters
            _2dGraph.UnitsY = UnitsDefinition.Units.Millimeters
            _2dGraph.PosDirY = grf_XYGraph.PositiveDirection.PosDown
            _2dGraph.MinY = 0.0 ' Start Infiltration graph at top of soil

            AddResultsPanel(title, tabName, _2dGraph)

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
    ' Clear all the Results Pages
    '
    Private Sub ClearResultsPages()
        '
        ' Dispose of resources (especially Bitmaps) so Garbage Collection can reclaim the memory
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

    Private Function GetNewContourGraphPage(ByVal contourParameter As ContourParameter, _
                                            ByVal parameterName As String, _
                                            ByVal parameterIndex As Integer) As grf_ContourPlot

        Dim contourGraph As grf_ContourPlot = New grf_ContourPlot(mWorldWindow, contourParameter, parameterName, parameterIndex)
        contourGraph.Title = mDictionary.Translate(parameterName)

        LoadUserPreferences(contourGraph)

        contourGraph.Location = PortraitGraphLocation
        contourGraph.Size = PortraitGraphSize

        contourGraph.AccessibleName = parameterName
        contourGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        contourGraph.ToolTip.Active = False

        Return contourGraph

    End Function

    Private Function GetNewContourGraphPanel(ByVal contourParameter As ContourParameter, _
                                             ByVal parameterName As String, _
                                             ByVal parameterIndex As Integer) As grf_ContourPlot

        Dim contourGraph As grf_ContourPlot = New grf_ContourPlot(mWorldWindow, contourParameter, parameterName, parameterIndex)
        contourGraph.Title = mDictionary.Translate(parameterName)

        LoadUserPreferences(contourGraph)

        contourGraph.Dock = DockStyle.Fill
        contourGraph.AccessibleName = parameterName
        contourGraph.AccessibleDescription = mDictionary.tCopyableBitmapGraphResults.Translated
        contourGraph.ToolTip.Active = False

        Return contourGraph

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
                        Select Case (mUnit.UnitType.Value)
                            Case WorldTypes.DesignWorld
                                Me.DisplayDesignResults()
                            Case WorldTypes.OperationsWorld
                                Me.DisplayOperationsResults()
                            Case Else
                                Debug.Assert(False) ' Unknown Unit Type
                        End Select
                    End If
                Catch ex As Exception
                    mWinSRFR.LogException(WinSRFR.ErrorLevels.Serious, "ctl_Results[UpdateUI]", ex)
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

    ' Common pages
    Private Sub mIpaInputSummaryPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mIpaInputSummaryPage.Disposed
        mIpaInputSummaryPage = Nothing
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
    Private Sub MkInputSummaryPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mMKInputSummaryPage.Disposed
        mMKInputSummaryPage = Nothing
    End Sub

    Private Sub MkAdvRecOppPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mMkAdvRecOppPage.Disposed
        mMkAdvRecOppPage = Nothing
    End Sub

    Private Sub MkPerformanceSummaryPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mMkPerformanceSummaryPage.Disposed
        mMkPerformanceSummaryPage = Nothing
    End Sub

    Private Sub MkGoodnessPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mMkGoodnessPage.Disposed
        mMkGoodnessPage = Nothing
    End Sub

    ' Elliott-Walker Two-Point Analysis
    Private Sub EwMeasurementsPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mEwInputSummaryPage.Disposed
        mEwInputSummaryPage = Nothing
    End Sub

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

    Private Sub BorderDesignParametersPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mBorderDesignParametersPage.Disposed
        mBorderDesignParametersPage = Nothing
    End Sub

    Private Sub BorderOperationsParametersPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mBorderOperationsParametersPage.Disposed
        mBorderOperationsParametersPage = Nothing
    End Sub

    Private Sub FurrowDesignParametersPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mFurrowDesignParametersPage.Disposed
        mFurrowDesignParametersPage = Nothing
    End Sub

    Private Sub FurrowOperationsParametersPage_Disposed(ByVal sender As Object, ByVal e As EventArgs) _
    Handles mFurrowOperationsParametersPage.Disposed
        mFurrowOperationsParametersPage = Nothing
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
