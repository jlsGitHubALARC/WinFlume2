
'*************************************************************************************************************
' Class:    DesignAnalysis
'
' This must inherit baseclass provides data and methods common across all Design World analyses.
' It provides layered support for:
'
'   * Setup/execution warnings & errors
'   * Contour Tuning Point & Factors
'   * Design Execution
'   * Design Point Computation
'   * Contour Point Access
'*************************************************************************************************************
Imports DataStore

Public MustInherit Class DesignAnalysis
    Inherits Analysis

#Region " Member Data "

#Region " Errors "
    '
    ' Error flags (values 1-99 reserved for Analysis baseclass)
    '
    Public Shadows Enum ErrorFlags
        LevelBasinNotBlocked = 101
        CutoffOptionNotSupported
        CutbackNotSupported
    End Enum

#End Region

#Region " Warnings "
    '
    ' Warning bit flags (bits 0-9 reserved for Analysis baseclass)
    '
    Public Shadows Enum WarningFlags
        DefaultTuningFactors = 1 << 10
        AdvanceRecessionInadequate = 1 << 11
        TimeTooLong = 1 << 12
        TcbLimitedToTco = 1 << 13
        LimitLineExceeded = 1 << 14
        DesignNotRecommended = 1 << 15
        DesignIsInvalid = 1 << 16
    End Enum

#End Region

#Region " Tuning "

    Protected mDownstreamValue As DownstreamConditions
    Protected mDownstreamSource As ValueSources

#End Region

#End Region

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
    End Sub

#End Region

#Region " Methods "

#Region " SRFR Adjustments "

    '*********************************************************************************************************
    ' Adjust SRFR Criteria to match the specific point being analyzed
    '
    ' After SRFR Criteria has been loaded from but prior to the SRFR Simulation being executed, the Criteria
    ' can be modified to meet any special requirements of the analysis by overriding AdjustSrfrCriteria().
    '*********************************************************************************************************
    Public Overrides Sub AdjustSrfrCriteria(ByVal unit As Unit, ByVal solmod As Srfr.SolutionModel)
        If (unit IsNot Nothing) Then
            If (solmod IsNot Nothing) Then

                'solmod.EnableDiagnostics = False

                If (solmod.GetType Is GetType(Srfr.KinematicWave)) Then
                    Dim KW As Srfr.KinematicWave = DirectCast(solmod, Srfr.KinematicWave)
                    KW.ZeroInertiaRecession = False
                End If

                ' System Geometry
                Dim systemGeometry As SystemGeometry = unit.SystemGeometryRef
                Dim blocked As DownstreamConditions = systemGeometry.DownstreamCondition.Value

                Dim cellDensity As Double = 40

                ' Set Cell Density to attempt to avoid simulation problems.
                If (blocked = DownstreamConditions.BlockedEnd) Then
                    cellDensity = 80
                End If ' Blocked / Open End

                If (solmod.CellDensity < cellDensity) Then
                    solmod.CellDensity = cellDensity
                End If

                ' Save SRFR Criteria so copy/paste to Simulation World has matching criteria
                Dim density As IntegerParameter = mSrfrCriteria.CellDensity
                density.Value = cellDensity
                density.Source = ValueSources.Calculated
                mSrfrCriteria.CellDensity = density

            End If ' (solmod IsNot Nothing)
        End If ' (unit IsNot Nothing)
    End Sub

    '*********************************************************************************************************
    ' Verify SRFR parameters match current conditions.
    '*********************************************************************************************************
    Protected Overrides Sub VerifySrfrParameters(ByVal minCellDensity As Integer)

        ' Set Cell Density to attempt to avoid simulation problems
        Dim cellDensity As Double = minCellDensity

        mDownstreamValue = mSystemGeometry.DownstreamCondition.Value
        If (mDownstreamValue = DownstreamConditions.BlockedEnd) Then
            cellDensity = Math.Max(cellDensity, 80)
        End If ' Blocked / Open End

        ' Save SRFR Criteria so copy/paste to Simulation World has matching criteria
        Dim density As IntegerParameter = mSrfrCriteria.CellDensity
        density.Value = cellDensity
        density.Source = ValueSources.Calculated
        mSrfrCriteria.CellDensity = density

    End Sub

#End Region

#Region " Tuning Factors "

    '******************************************************************************************
    ' Estimate Design Tuning Factors
    '
    ' Analysis should override this method when tuning calculations using SRFR.  Call this
    ' baseclass function to perform common initialization.
    '
    Public Overridable Function EstimateTuningFactors() As Boolean
        Dim ok As Boolean = True
        Me.ClearExecutionErrors()
        Me.ClearExecutionWarnings()
        Me.GetContourParameters()

        ' Get Unit parameters
        GetUnitParameters()

        ' Verify SRFR parameters match current conditions
        VerifySrfrParameters(CellDensities.Medium)

        Return ok
    End Function

#End Region

#Region " Design Grid "

    '******************************************************************************************
    ' Run Design Analysis
    '******************************************************************************************
    Public MustOverride Sub RunDesign()

    '******************************************************************************************
    ' Set/Clear SRFR.Infiltration reference to optimize calls to SrfrAPI.Infiltration...
    '******************************************************************************************
    Public Overrides Sub StartRun(ByVal SimName As String, ByVal contourRun As Boolean)
        MyBase.StartRun(SimName, contourRun)
        mSoilCropProperties.SetSrfrInfiltration()
    End Sub

    Public Overrides Sub EndRun()
        MyBase.EndRun()
        mSoilCropProperties.ClrSrfrInfiltration()
    End Sub

    '******************************************************************************************
    ' Build Design Contour Grid
    '
    ' The Contour Grid is used as the guide for calculation the contour graphs; it must be
    ' computed before computing the contours.
    '******************************************************************************************
    Protected Function BuildDesignGrid(ByVal xLabel As String, _
                                       ByVal yLabel As String) As Boolean

        Dim point As ContourPoint
        Dim rdx, cdx As Integer

        Me.StatusMessage &= " - " & mDictionary.tBuildingContourGrid.Translated

        ' Clear previous Design Results
        If Not (mContourGrid Is Nothing) Then
            mContourGrid.ClearContours()
            mContourGrid = Nothing
        End If

        If Not (mLineList Is Nothing) Then
            mLineList.Clear()
            mLineList = Nothing
        End If

        ' Define contour's Y-axis based on the user selected Design Option
        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            '
            ' Inflow Rate given; contour is Length (X) vs. Width (Y)
            '
            mContourGrid = New ContourGrid(mNumWidths, mNumLengths)
            mContourGrid.ColName = mDictionary.Translate(xLabel) & " " & mDictionary.tLength.Translated     ' X-axis (cols) is length
            mContourGrid.RowName = mDictionary.Translate(yLabel) & " " & mDictionary.tWidth.Translated      ' Y-axis (rows) is width
            '
            ' Calculate & load the contour points
            '
            For rdx = 0 To mNumWidths - 1
                mWidth = Widths(rdx)

                For cdx = 0 To mNumLengths - 1
                    mLength = Lengths(cdx)

                    If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                        point = DesignPoint(mLength, mWidth, mInflowRate, NumWddPoints)
                    Else
                        mCutbackRate = mInflowRate * mCutbackRateRatio
                        point = DesignPoint(mLength, mWidth, mInflowRate, mCutbackRate, NumWddPoints)
                    End If

                    mContourGrid.Point(rdx, cdx) = point
                Next

                Me.RunProgress = CInt((100 * (rdx + 1)) / mNumWidths)
            Next

            mContourGrid.ValueName(ZIndex) = sInflowRate ' Z(0) parameter
        Else
            '
            ' Width given; contour is Length (X) vs. Inflow Rate (Y)
            '
            mContourGrid = New ContourGrid(mNumInflowRates, mNumLengths)
            mContourGrid.ColName = mDictionary.Translate(xLabel) & " " & mDictionary.tLength.Translated     ' X-axis (cols) is length
            mContourGrid.RowName = mDictionary.Translate(yLabel) & " " & mDictionary.tInflowRate.Translated ' Y-axis (rows) is inflow rate
            '
            ' Calculate & load the contour points
            '
            For rdx = 0 To mNumInflowRates - 1
                mInflowRate = InflowRates(rdx)

                For cdx = 0 To mNumLengths - 1
                    mLength = Lengths(cdx)

                    If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                        point = DesignPoint(mLength, mWidth, mInflowRate, NumWddPoints)
                    Else
                        mCutbackRate = mInflowRate * mCutbackRateRatio
                        point = DesignPoint(mLength, mWidth, mInflowRate, mCutbackRate, NumWddPoints)
                    End If

                    mContourGrid.Point(rdx, cdx) = point

                    Me.RunProgress = CInt((100 * (rdx + 1)) / mNumWidths)
                Next
            Next

            mContourGrid.ValueName(ZIndex) = sWidth ' Z(0) parameter
        End If

        ' Define the Z-parameters to be calculated for each contour point
        mContourGrid.ValueName(PaeIndex) = sPotentialApplicationEfficiency
        mContourGrid.ValueName(DuIndex) = sMinimumDistributionUniformity
        mContourGrid.ValueName(AdIndex) = sMinimumAdequacy
        mContourGrid.ValueName(RoIndex) = sRunoff
        mContourGrid.ValueName(DpIndex) = sDeepPercolation
        mContourGrid.ValueName(DappIndex) = sAppliedDepth
        mContourGrid.ValueName(DLfIndex) = sMinimumDepth
        mContourGrid.ValueName(TxaIndex) = sMaxAdvanceTime
        mContourGrid.ValueName(TcoIndex) = sCutoffTime
        mContourGrid.ValueName(RcoIndex) = sCutoffRatio

        If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            mContourGrid.ValueName(CutbackIndex) = sCutbackRatio
        End If

        mContourGrid.ValueName(CostIndex) = sCost
        '
        ' Build contour cells from contour points; cell has corner points & one center point
        '
        Dim rowBound As Integer = mContourGrid.PointArray.GetUpperBound(0)
        Dim colBound As Integer = mContourGrid.PointArray.GetUpperBound(1)

        For rdx = 0 To rowBound - 1
            For cdx = 0 To colBound - 1
                ' Get corner points
                Dim bl As ContourPoint = mContourGrid.Point(rdx, cdx)            ' Bottom-left
                Dim br As ContourPoint = mContourGrid.Point(rdx, cdx + 1)        ' Bottom-right
                Dim tl As ContourPoint = mContourGrid.Point(rdx + 1, cdx)        ' Top-left
                Dim tr As ContourPoint = mContourGrid.Point(rdx + 1, cdx + 1)    ' Top-right

                Dim x As Single = (bl.X.Value + br.X.Value) / 2     ' Length
                Dim y As Single = (bl.Y.Value + tl.Y.Value) / 2     ' Width or Flow Rate

                Dim blz As SingleParameter = DirectCast(bl.Z(ZIndex), SingleParameter)

                If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
                    mLength = x             ' x is Length
                    mWidth = y              ' y is Width

                    mInflowRate = blz.Value ' z(0) is Inflow Rate
                Else
                    mLength = x             ' x is Length
                    mInflowRate = y         ' y is Inflow Rate

                    mWidth = blz.Value      ' z(0) is Width
                End If

                ' Compute center point
                If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                    point = DesignPoint(mLength, mWidth, mInflowRate, NumWddPoints)
                Else
                    mCutbackRate = mInflowRate * mCutbackRateRatio
                    point = DesignPoint(mLength, mWidth, mInflowRate, mCutbackRate, NumWddPoints)
                End If

                ' Create the cell
                Dim cell As PrecisionContourCell = New PrecisionContourCell(Me, rdx, cdx, tl, tr, bl, br, point)

                ' Set edge flags for cell
                Dim edgeFlags As Integer = ContourCell.Edge.NoEdge

                If (rdx = 0) Then
                    edgeFlags = edgeFlags + ContourCell.Edge.Bottom
                ElseIf (rdx = rowBound - 1) Then
                    edgeFlags = edgeFlags + ContourCell.Edge.Top
                End If

                If (cdx = 0) Then
                    edgeFlags = edgeFlags + ContourCell.Edge.Left
                ElseIf (cdx = colBound - 1) Then
                    edgeFlags = edgeFlags + ContourCell.Edge.Right
                End If

                cell.CellEdge = edgeFlags

                ' Build the cell's Error Contour as a precise contour
                cell.Precision = Globals.ContourPrecision.Precise
                cell.BuildLimitContour()
                If (WinSRFR.UserPreferences.CalculatePrecisionContours = True) Then
                    cell.Precision = Globals.ContourPrecision.Precise
                Else
                    cell.Precision = Globals.ContourPrecision.Standard
                End If

                mContourGrid.Cell(rdx, cdx) = cell
            Next

            Me.RunProgress = CInt((100 * (rdx + 1)) / rowBound)
        Next
        '
        ' Scale contour axes based on grid points
        '
        Me.ScaleDapp()
        Me.ScaleDlf()
        Me.ScaleTco()
        Me.ScaleTxa()
        Me.ScaleCost()

    End Function

#End Region

#Region " Design Point "

    '******************************************************************************************
    ' Compute Design Point
    '
    Protected MustOverride Function DesignPoint() As ContourPoint

    '******************************************************************************************
    ' Compute Design Point wo/ Cutback
    '
    Public Function DesignPoint(ByVal length As Double, _
                                ByVal width As Double, _
                                ByVal flowRate As Double) As ContourPoint
        ' Use number of distances from Analysis class
        Return DesignPoint(length, width, flowRate, NumDistances)
    End Function

    Protected MustOverride Function DesignPoint(ByVal length As Double, _
                                                ByVal width As Double, _
                                                ByVal flowRate As Double, _
                                                ByVal numDistances As Integer) As ContourPoint

    '******************************************************************************************
    ' Compute Design Point w/ Cutback
    '
    Public Function DesignPoint(ByVal length As Double, _
                                ByVal width As Double, _
                                ByVal flowRate As Double, _
                                ByVal cutbackRate As Double) As ContourPoint
        ' Use number of distances from Furrow Analysis class
        Return DesignPoint(length, width, flowRate, cutbackRate, NumDistances)
    End Function

    Protected MustOverride Function DesignPoint(ByVal length As Double, _
                                                ByVal width As Double, _
                                                ByVal flowRate As Double, _
                                                ByVal cutbackRate As Double, _
                                                ByVal numDistances As Integer) As ContourPoint

#End Region

#Region " Contour Point "

    '******************************************************************************************
    ' Method to get a specified Design Contour Point
    '
    Public Overrides Function GetContourPoint(ByVal x As Double, ByVal y As Double, _
                                              ByVal numDistances As Integer) As ContourPoint
        Dim point As ContourPoint = Nothing

        ' X is always Length
        mLength = x

        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            ' Y is Width
            mWidth = y
            mInflowRate = mInflowManagement.InflowRate.Value
        Else
            ' Y is Flow Rate
            mWidth = mSystemGeometry.Width.Value
            mInflowRate = y
        End If

        If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            point = DesignPoint(mLength, mWidth, mInflowRate, numDistances)
        Else
            mCutbackRateRatio = mInflowManagement.CutbackRateRatio.Value
            mCutbackRate = mInflowRate * mCutbackRateRatio
            point = DesignPoint(mLength, mWidth, mInflowRate, mCutbackRate, numDistances)
        End If

        Return point
    End Function

#End Region

#Region " Solution "

    Public Overrides Sub CalculateSolution()
        ' Initialize calculation
        MyBase.CalculateSolution()

        ' Calculate Design Point
        Try
            mSolutionPoint = DesignPoint()
        Catch ex As Exception
            mWinSRFR.UsageException("CalculateSolution[DesignPoint] ", ex)
        End Try
    End Sub

    Protected Overrides Sub SaveSolution()
        ' Save parameters common to all analyses
        MyBase.SaveSolution()

        ' Save Solution Point
        Dim _contour As ContourParameter = mPerformanceResults.DesignContour
        _contour.ContourPoint = mSolutionPoint
        mPerformanceResults.DesignContour = _contour

    End Sub

#End Region

#Region " Upstream Parameters "

    Public Overrides Sub UpstreamParameters(ByVal Q0 As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double, _
                    ByRef Y0 As Double, ByRef AY0 As Double, ByRef R0 As Double, ByRef WP0 As Double, ByRef Sf0 As Double, _
                    Optional ByVal Beta As Double = 0.0)

        If (Beta <= 0.0) Then
            Beta = mUnit.Beta(S0) ' 0.45 '
        End If

        MyBase.UpstreamParameters(Q0, L, W, S0, Y0, AY0, R0, WP0, Sf0, Beta)
    End Sub

#End Region

#Region " Automation "

    '*********************************************************************************************************
    ' Sub AutoRun()                 - runs Design Analysis via automation interface as opposed to the UI
    '*********************************************************************************************************
    Public Overrides Sub AutoRun()
        RunDesign()
    End Sub

#End Region

#Region " Errors & Warnings "

    '*********************************************************************************************************
    ' Sub CheckInfiltrationErrors() - Check Infiltration parameter errors
    '*********************************************************************************************************
    Public Overrides Sub CheckInfiltrationErrors()
        MyBase.CheckInfiltrationErrors()

        Dim infiltrationFunction As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value

        Select Case (infiltrationFunction)

            Case InfiltrationFunctions.GreenAmpt

                ' Green-Ampt not available for Design Analysis
                AddSetupError(Analysis.ErrorFlags.GreenAmptNotAvailable, _
                         mDictionary.tGreenAmptNotAvailable.Translated, _
                         mDictionary.tGreenAmptNotAvailableForDesignAnalysis.Translated)

            Case InfiltrationFunctions.WarrickGreenAmpt

                ' Warrick Green-Ampt not available for Design Analysis
                AddSetupError(Analysis.ErrorFlags.WarrickGreenAmptNotAvailable, _
                         mDictionary.tWarrickGreenAmptNotAvailable.Translated, _
                         mDictionary.tWarrickGreenAmptNotAvailableForDesignAnalysis.Translated)

            Case InfiltrationFunctions.Hydrus1D

                ' HYDRUS-1D not available for Design Analysis
                AddSetupError(Analysis.ErrorFlags.Hydrus1DNotAvailable, _
                         mDictionary.tHydrus1DNotAvailable.Translated, _
                         mDictionary.tHydrus1DNotAvailableForDesignAnalysis.Translated)
        End Select

    End Sub

#End Region

#End Region

End Class
