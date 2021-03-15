
'*************************************************************************************************************
' Class:    OperationsAnalysis
'
' Desc: Base class for all WinSRFR Operations Analyses; derived from Analysis
'*************************************************************************************************************
Imports DataStore

Public MustInherit Class OperationsAnalysis
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
        OperationIsInvalid = 1 << 15
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
    ' Estimate Operations Tuning Factors
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

#Region " Operations Execution "

    '******************************************************************************************
    ' Run Operations Analysis
    '******************************************************************************************
    Public MustOverride Sub RunOperations(ByVal Method As OperationsMethod)

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

#End Region

#Region " Build Operations Grid - Volume Balance "

    '*********************************************************************************************************
    ' Function BuildOperationsGridVolBal() - Build Operations Grid using Volume Balance calculations
    '
    ' The Contour Grid is used as the guide for calculation the contour graphs; it must be
    ' computed before computing the contours.
    '*********************************************************************************************************
    Protected Function BuildOperationsGridVolBal() As Boolean

        Dim point As ContourPoint = Nothing
        Dim rdx, cdx As Integer

        Me.StatusMessage &= " - " & mDictionary.tBuildingContourGrid.Translated

        ' Clear previous Operations Results
        If Not (mContourGrid Is Nothing) Then
            mContourGrid.ClearContours()
            mContourGrid = Nothing
        End If

        If Not (mLineList Is Nothing) Then
            mLineList.Clear()
            mLineList = Nothing
        End If

        ' Which operations function to call is cutoff dependent
        Dim cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)

        If ((mUnit.CrossSection = CrossSections.Furrow) _
        And (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven)) Then
            '
            ' Contour is Cutoff (X) vs. Width (Y)
            '
            mContourGrid = New ContourGrid(mNumWidths, mNumCutoffTimes)

            Select Case (cutoffMethod)
                Case CutoffMethods.DistanceBased
                    mContourGrid.ColName = mDictionary.tRelativeCutoffDistTime.Translated   ' X-axis (cols) is cutoff distance
                Case Else ' Assume CutoffMethods.TimeBased
                    mContourGrid.ColName = mDictionary.tCutoffTime.Translated               ' X-axis (cols) is cutoff time
            End Select

            mContourGrid.RowName = mDictionary.tWidth.Translated                            ' Y-axis (rows) is width
            '
            ' Calculate & load the contour points
            '
            For rdx = 0 To mNumWidths - 1
                mWidth = Widths(rdx)
                mCutbackRate = mInflowRate * mCutbackRateRatio

                Select Case (cutoffMethod)
                    Case CutoffMethods.DistanceBased
                        For cdx = 0 To mNumCutoffRatios - 1
                            mXR = CutoffRatios(cdx)

                            point = Me.OperationsPointVolBal(mInflowRate, mWidth, mXR)

                            mContourGrid.Point(rdx, cdx) = point
                        Next

                    Case Else ' Assume CutoffMethods.TimeBased
                        For cdx = 0 To mNumCutoffTimes - 1
                            mTco = CutoffTimes(cdx)

                            If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                                point = Me.OperationsPointVolBal(mInflowRate, mWidth, mTco)
                            Else
                                point = Me.OperationsPointVolBal(mInflowRate, mWidth, mTco, mCutbackRate)
                            End If

                            mContourGrid.Point(rdx, cdx) = point
                        Next
                End Select

                Me.RunProgress = CInt((100 * (rdx + 1)) / mNumInflowRates)
            Next

        Else ' Width Given
            '
            ' Contour is Cutoff (X) vs. Inflow Rate (Y)
            '
            mContourGrid = New ContourGrid(mNumInflowRates, mNumCutoffTimes)

            Select Case (cutoffMethod)
                Case CutoffMethods.DistanceBased
                    mContourGrid.ColName = mDictionary.tRelativeCutoffDistTime.Translated   ' X-axis (cols) is cutoff distance
                Case Else ' Assume CutoffMethods.TimeBased
                    mContourGrid.ColName = mDictionary.tCutoffTime.Translated               ' X-axis (cols) is cutoff time
            End Select

            mContourGrid.RowName = mDictionary.tInflowRate.Translated                       ' Y-axis (rows) is inflow rate
            '
            ' Calculate & load the contour points
            '
            For rdx = 0 To mNumInflowRates - 1
                mInflowRate = InflowRates(rdx)
                mCutbackRate = mInflowRate * mCutbackRateRatio

                Select Case (cutoffMethod)
                    Case CutoffMethods.DistanceBased
                        For cdx = 0 To mNumCutoffRatios - 1
                            mXR = CutoffRatios(cdx)

                            point = Me.OperationsPointVolBal(mInflowRate, mWidth, mXR)

                            mContourGrid.Point(rdx, cdx) = point
                        Next

                    Case Else ' Assume CutoffMethods.TimeBased
                        For cdx = 0 To mNumCutoffTimes - 1
                            mTco = CutoffTimes(cdx)

                            If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                                point = Me.OperationsPointVolBal(mInflowRate, mWidth, mTco)
                            Else
                                point = Me.OperationsPointVolBal(mInflowRate, mWidth, mTco, mCutbackRate)
                            End If

                            mContourGrid.Point(rdx, cdx) = point
                        Next
                End Select

                Me.RunProgress = CInt((100 * (rdx + 1)) / mNumInflowRates)
            Next

            mContourGrid.ValueName(ZIndex) = sWidth ' Z(0) is Width
        End If

        ' Define the Z-parameters to be calculated for each contour point
        mContourGrid.ValueName(AeIndex) = sApplicationEfficiency
        mContourGrid.ValueName(DuIndex) = sMinimumDistributionUniformity
        mContourGrid.ValueName(AdIndex) = sMinimumAdequacy
        mContourGrid.ValueName(RoIndex) = sRunoff
        mContourGrid.ValueName(DpIndex) = sDeepPercolation
        mContourGrid.ValueName(DappIndex) = sAppliedDepth

        Select Case (mDepthCriterion)
            Case InfiltratedDepthCriteria.LowQuarterDepth
                mContourGrid.ValueName(DLfIndex) = sLowQuarterDepth
            Case Else ' Assume InfiltratedDepthCriteria.MinimumDepth
                mContourGrid.ValueName(DLfIndex) = sMinimumDepth
        End Select

        mContourGrid.ValueName(TxaIndex) = sMaxAdvanceTime

        Select Case (cutoffMethod)
            Case CutoffMethods.DistanceBased
                mContourGrid.ValueName(TcoIndex) = sCutoffTime
            Case Else ' Assume CutoffMethods.TimeBased
                mContourGrid.ValueName(TcoIndex) = sCutoffRatio
        End Select

        If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            mContourGrid.ValueName(RcoIndex) = sCutbackRatio
        End If

        mContourGrid.ValueName(CostIndex) = sCost
        '
        ' Build contour cells from contour points
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

                mTco = (bl.X.Value + br.X.Value) / 2                ' Cutoff/cutback Times

                If ((mUnit.CrossSection = CrossSections.Furrow) _
                And (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven)) Then
                    mWidth = (bl.Y.Value + tl.Y.Value) / 2          ' Furrow Set Width
                Else
                    mInflowRate = (bl.Y.Value + tl.Y.Value) / 2     ' Inflow Rate
                    mCutbackRate = mInflowRate * mCutbackRateRatio
                End If

                Dim blz As SingleParameter = DirectCast(bl.Z(ZIndex), SingleParameter)

                ' Compute center point
                If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                    point = Me.OperationsPointVolBal(mInflowRate, mWidth, mTco)
                Else
                    mCutbackRate = mInflowRate * mCutbackRateRatio
                    point = Me.OperationsPointVolBal(mInflowRate, mWidth, mTco, mCutbackRate)
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

#Region " Compute Operations Point - Volume Balance "

    '*********************************************************************************************************
    ' Function OperationsPointVolBal() - Compute an Operations Point using Volume Balance calculations
    '
    ' Called By:    Calculate Solution      - to calculate the Operations Point at the Solution Point
    '               Estimate Tuning Factors - to calculate the Operations Point at the Tuning Point
    '
    ' Returns:      ContourPoint            - the Operations Point
    '*********************************************************************************************************
    Protected MustOverride Function OperationsPointVolBal() As ContourPoint

    '*********************************************************************************************************
    ' Function OperationsPointVolBal() - Compute an Operations Point with NO Cutback
    '                                    using Volume Balance calculations
    '
    ' Called By:    Build Operations Grid   - to calculate the Operations Point at a Contour Grid Point
    '
    ' Input(s):     InflowRate              - Qin
    '               Width                   - BorderWidth | FurrowSetWidth
    '               CutoffTime              - Tco
    '               NumDistances            - Number of points for Advance Curve
    '
    ' Returns:      ContourPoint            - the Operations Point
    '*********************************************************************************************************
    Public Function OperationsPointVolBal(ByVal InflowRate As Double,
                                          ByVal Width As Double,
                                          ByVal CutoffTime As Double) As ContourPoint
        ' Use number of distances from Furrow Analysis class
        Return OperationsPointVolBal(InflowRate, Width, CutoffTime, NumDistances)
    End Function

    Protected MustOverride Function OperationsPointVolBal(ByVal InflowRate As Double,
                                                          ByVal Width As Double,
                                                          ByVal CutoffTime As Double,
                                                          ByVal NumDistances As Integer) As ContourPoint

    '*********************************************************************************************************
    ' Function OperationsPointVolBal() - Compute an Operations Point WITH Cutback
    '                                    using Volume Balance calculations
    '
    ' Called By:    Build Operations Grid   - to calculate the Operations Point at a Contour Grid Point
    '
    ' Input(s):     InflowRate              - Qin
    '               Width                   - BorderWidth | FurrowSetWidth
    '               CutoffTime              - Tco
    '               CutbackRate             - Rcb
    '               NumDistances            - Number of points for Advance Curve
    '
    ' Returns:      ContourPoint            - the Operations Point
    '*********************************************************************************************************
    Public Function OperationsPointVolBal(ByVal InflowRate As Double,
                                          ByVal Width As Double,
                                          ByVal CutoffTime As Double,
                                          ByVal CutbackRate As Double) As ContourPoint
        ' Use number of distances from Furrow Analysis class
        Return OperationsPointVolBal(InflowRate, Width, CutoffTime, CutbackRate, NumDistances)
    End Function

    Protected MustOverride Function OperationsPointVolBal(ByVal InflowRate As Double,
                                                          ByVal Width As Double,
                                                          ByVal CutoffTime As Double,
                                                          ByVal CutbackRate As Double,
                                                          ByVal NumDistances As Integer) As ContourPoint
#End Region

#Region " Compute Operations Point - Grid Interpolation "

    '*********************************************************************************************************
    ' Function OperationsPointGridInterpolate() - Compute an Operations Point using Grid Interpolation
    '
    ' Called By:    Calculate Solution      - to simulate the Operations Point at the Solution Point
    '               Estimate Tuning Factors - to simulate the Operations Point at the Tuning Point
    '
    ' Returns:      ContourPoint            - the Operation Point
    '*********************************************************************************************************
    Protected MustOverride Function OperationsPointGridInterpolate() As ContourPoint

#End Region

#Region " Refine Operations Grid - SRFR Simulation "

    '*********************************************************************************************************
    ' Function RefineOperationsGridSrfrSim() - Refine Operations Contour Grid using SRFR simultaions
    '*********************************************************************************************************
    Protected Function RefineOperationsGridSrfrSim(ByVal Method As OperationsMethod) As Boolean

        Dim point As ContourPoint = Nothing
        Dim rdx, cdx As Integer

        Me.StatusMessage &= " - " & mDictionary.tRefiningContourGrid.Translated

        ' Refine previously calculated contour grid points
        Dim rowBound As Integer = mContourGrid.PointArray.GetUpperBound(0)
        Dim colBound As Integer = mContourGrid.PointArray.GetUpperBound(1)

        Dim numSimRun As Integer = 0
        Dim numPoints As Integer = (rowBound + 1) * (colBound + 1) + rowBound * colBound
        Dim status As String

        For rdx = 0 To rowBound
            For cdx = 0 To colBound
                numSimRun += 1
                status = numSimRun & " / " & numPoints.ToString
                mWorldWindow.ProgressMessage = status

                point = mContourGrid.Point(rdx, cdx)
                Me.RefineOperationsPointSrfrSim(point, Method)
            Next cdx

            'Me.RunProgress = CInt((100 * rdx) / rowBound)
        Next rdx

        ' Update contour cells from refined contour grid points
        For rdx = 0 To rowBound - 1
            For cdx = 0 To colBound - 1

                ' Get refined corner points
                mContourGrid.Cell(rdx, cdx).BL = mContourGrid.Point(rdx, cdx)            ' Bottom-left
                mContourGrid.Cell(rdx, cdx).BR = mContourGrid.Point(rdx, cdx + 1)        ' Bottom-right
                mContourGrid.Cell(rdx, cdx).TL = mContourGrid.Point(rdx + 1, cdx)        ' Top-left
                mContourGrid.Cell(rdx, cdx).TR = mContourGrid.Point(rdx + 1, cdx + 1)    ' Top-right

                ' Refine center point
                numSimRun += 1
                status = numSimRun & " / " & numPoints.ToString
                mWorldWindow.ProgressMessage = status

                point = mContourGrid.Cell(rdx, cdx).C
                Me.RefineOperationsPointSrfrSim(point, Method)

                ' Build the cell's Error Contour as a standard contour
                Dim cell As PrecisionContourCell = mContourGrid.Cell(rdx, cdx)

                cell.Precision = Globals.ContourPrecision.Standard
                cell.BuildLimitContour()
                If (WinSRFR.UserPreferences.CalculatePrecisionContours = True) Then
                    cell.Precision = Globals.ContourPrecision.Precise
                Else
                    cell.Precision = Globals.ContourPrecision.Standard
                End If
            Next cdx

            'Me.RunProgress = CInt((100 * rdx) / rowBound)
        Next rdx

    End Function

#End Region

#Region " Refine Operations Point - SRFR Simulation "

    '*********************************************************************************************************
    ' Function RefineOperationsPointSrfrSim() - Refine an Operations Point using SRFR Simulation
    '
    ' Called By:    Refine Operations Grid  - to refine the Operations Point at a Contour Grid Point
    '
    ' Input(s):     Point                   - Operations Point to refine
    '               Method                  - OperationsMethod to use for refinement
    '*********************************************************************************************************
    Public Sub RefineOperationsPointSrfrSim(ByVal Point As ContourPoint, ByVal Method As OperationsMethod)

        Select Case (Method)
            Case OperationsMethod.SrfrUiThread
                RefineOperationsPointUiThread(Point)
            Case OperationsMethod.SrfrBgThread
                RefineOperationsPointBgThread(Point)
            Case OperationsMethod.SrfrBgThreads
                RefineOperationsPointBgThreads(Point)
            Case Else ' OperationsMethod.VolumeBalance
                Debug.Assert(False)
        End Select

    End Sub

    Public Sub RefineOperationsPointUiThread(ByVal Point As ContourPoint)

        SrfrAPI.Irrigation.Results.Clear()

        SrfrAPI.Inflow.Tco = Point.X.Value
        SrfrAPI.Inflow.Q0 = Point.Y.Value

        SrfrAPI.Simulate(mSolutionModel)

        Dim results As Srfr.Results = SrfrAPI.Irrigation.Results.Clone

        SrfrAPI.Irrigation.ClearResults()

        Dim sParam As SingleParameter

        sParam = Point.Z(0)
        sParam.Value = results.Width                ' Border Width

        sParam = Point.Z(1)
        sParam.Value = results.AE                   ' Application Efficiency

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            sParam = Point.Z(2)
            sParam.Value = results.DUmin            ' Minimum Distribution Uniformity

            sParam = Point.Z(3)
            sParam.Value = results.ADmin            ' Minimum Adequacy
        Else ' Low-Quarter
            sParam = Point.Z(2)
            sParam.Value = results.DUlq             ' Low-Quarter Distribution Uniformity

            sParam = Point.Z(3)
            sParam.Value = results.ADlq             ' Low-Quarter Adequacy
        End If

        sParam = Point.Z(4)
        sParam.Value = results.ROpct                ' Runoff

        sParam = Point.Z(5)
        sParam.Value = results.DPpct                ' Deep percolation

        sParam = Point.Z(6)
        sParam.Value = results.Dapp                 ' Applied Depth

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            sParam = Point.Z(7)
            sParam.Value = results.Dmin             ' Minimum Depth
        Else
            sParam = Point.Z(7)
            sParam.Value = results.Dlq              ' Low-Quarter Depth
        End If

        sParam = Point.Z(8)
        sParam.Value = results.Txa                  ' Maximum Advance time

        sParam = Point.Z(9)
        sParam.Value = results.XR                   ' Relative cutoff

        ' 10 & 11 are fillers

        sParam = Point.Z(12)
        sParam.Value = results.WaterCostPerHectare  ' Cost

        results.Clear()
        results = Nothing

    End Sub

    Public Sub RefineOperationsPointBgThread(ByVal Point As ContourPoint)

    End Sub

    Public Sub RefineOperationsPointBgThreads(ByVal Point As ContourPoint)

    End Sub

#End Region

#Region " Contour Point "

    '******************************************************************************************
    ' Method to get a specified Operations Contour Point
    '
    Public Overrides Function GetContourPoint(ByVal x As Double, ByVal y As Double,
                                              ByVal numDistances As Integer) As ContourPoint
        Dim point As ContourPoint = Nothing

        ' Y is Inflow Rate or Width
        Select Case (mBorderCriteria.OperationsOption.Value)
            Case OperationsOptions.InflowRateGiven
                mWidth = y
            Case Else ' Assume OperationsOptions.WidthGiven
                mInflowRate = y
        End Select

        ' X is Cutoff Time or Distance
        Dim cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)
        Select Case (cutoffMethod)
            Case CutoffMethods.DistanceBased
                mXR = x

                point = OperationsPointVolBal(mInflowRate, mWidth, mXR, numDistances)
            Case Else ' Assume CutoffMethods.TimeBased
                mTco = x

                If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                    point = OperationsPointVolBal(mInflowRate, mWidth, mTco, numDistances)
                Else
                    mCutbackRateRatio = mInflowManagement.CutbackRateRatio.Value
                    mCutbackRate = mInflowRate * mCutbackRateRatio
                    point = OperationsPointVolBal(mInflowRate, mWidth, mTco, mCutbackRate, numDistances)
                End If
        End Select

        Return point
    End Function

#End Region

#Region " Solution "

    Public Overrides Sub CalculateSolution()
        MyBase.CalculateSolution() ' Initialize calculation

        ' Calculate Operations Point
        Try
            mSolutionPoint = Me.OperationsPointVolBal()
        Catch ex As Exception
            mWinSRFR.UsageException("CalculateSolution[OperationsPoint] ", ex)
        End Try
    End Sub

    Protected Overrides Sub SaveSolution()
        MyBase.SaveSolution() ' Save parameters common to all analyses

        ' Save Solution Point
        Dim _contour As ContourParameter = mPerformanceResults.DesignContour
        _contour.ContourPoint = mSolutionPoint
        mPerformanceResults.DesignContour = _contour

    End Sub

#End Region

#Region " Upstream Parameters "

    Public Overrides Sub UpstreamParameters(ByVal Q0 As Double, ByVal L As Double, ByVal W As Double, ByVal S0 As Double,
                    ByRef Y0 As Double, ByRef AY0 As Double, ByRef R0 As Double, ByRef WP0 As Double, ByRef Sf0 As Double,
                    Optional ByVal Beta As Double = 0.0)

        If (Beta <= 0.0) Then
            Beta = mUnit.Beta(S0) ' 0.45 '
        End If

        MyBase.UpstreamParameters(Q0, L, W, S0, Y0, AY0, R0, WP0, Sf0, Beta)
    End Sub

#End Region

#Region " Automation "

    '*********************************************************************************************************
    ' Sub AutoRun()                 - runs Operation Analysis via automation interface as opposed to the UI
    '*********************************************************************************************************
    Public Overrides Sub AutoRun()
        RunOperations(OperationsMethod.VolumeBalance)
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

                ' Green-Ampt not available for Operations Analysis
                AddSetupError(Analysis.ErrorFlags.GreenAmptNotAvailable, _
                         mDictionary.tGreenAmptNotAvailable.Translated, _
                         mDictionary.tGreenAmptNotAvailableForOperationsAnalysis.Translated)

            Case InfiltrationFunctions.WarrickGreenAmpt

                ' Warrick Green-Ampt not available for Operations Analysis
                AddSetupError(Analysis.ErrorFlags.WarrickGreenAmptNotAvailable, _
                         mDictionary.tWarrickGreenAmptNotAvailable.Translated, _
                         mDictionary.tWarrickGreenAmptNotAvailableForOperationsAnalysis.Translated)

            Case InfiltrationFunctions.Hydrus1D

                ' HYDRUS-1D not available for Operations Analysis
                AddSetupError(Analysis.ErrorFlags.Hydrus1DNotAvailable, _
                         mDictionary.tHydrus1DNotAvailable.Translated, _
                         mDictionary.tHydrus1DNotAvailableForOperationsAnalysis.Translated)
        End Select

    End Sub

#End Region

#End Region

End Class
