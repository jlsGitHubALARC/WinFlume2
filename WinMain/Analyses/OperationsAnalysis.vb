
'*************************************************************************************************************
' Class:    OperationsAnalysis
'
' Desc: Base class for all WinSRFR Operations Analyses; derived from Analysis
'*************************************************************************************************************
Imports DataStore
Imports Srfr

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

#Region " Operations "

    Protected mOperationsMethod As OperationsMethod

    Protected mRunContourSimulations As RunContourSimulations

#End Region

#Region " SRFR Results List "

    Friend Property SrfrResults As ArrayList = Nothing
    Private SrfrSim As Srfr.SrfrSimulation              ' Package for running background simulations

    '*********************************************************************************************************
    ' Sub ClearResultsList()    - clear all results from list
    ' Sub AddToResultsList()    - add SRFR Results to end of list
    ' Sub SortResultsList()     - sort results by Simulation Number
    '*********************************************************************************************************
    Friend Sub ClearResultsList()
        Try
            If (Me.SrfrResults Is Nothing) Then
                Me.SrfrResults = New ArrayList
            End If

            SrfrResults.Clear()
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Friend Sub AddToResultsList(ByVal SrfrResults As Srfr.Results)
        Try
            If (Me.SrfrResults Is Nothing) Then
                Me.SrfrResults = New ArrayList
            End If

            Me.SrfrResults.Add(SrfrResults)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Friend Sub SortResultsList()
        Try
            If (Me.SrfrResults IsNot Nothing) Then
                If (1 < Me.SrfrResults.Count) Then
                    Dim sorted As Boolean = False
                    While Not sorted ' keep sorting until all are in order
                        sorted = True
                        Dim results0 As Srfr.Results = Me.SrfrResults(0)
                        Dim results1 As Srfr.Results = Me.SrfrResults(1)

                        For rdx As Integer = 1 To Me.SrfrResults.Count - 1
                            results1 = Me.SrfrResults(rdx)
                            If (results1.SimNum < results0.SimNum) Then ' out-of-order
                                sorted = False
                                ' correctly sort these two results
                                Me.SrfrResults(rdx) = results0
                                Me.SrfrResults(rdx - 1) = results1
                            Else ' in-order
                                results0 = results1
                            End If
                        Next rdx
                    End While
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

#End Region

#End Region

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
        mRunContourSimulations = New RunContourSimulations
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
                    edgeFlags += ContourCell.Edge.Bottom
                ElseIf (rdx = rowBound - 1) Then
                    edgeFlags += ContourCell.Edge.Top
                End If

                If (cdx = 0) Then
                    edgeFlags += ContourCell.Edge.Left
                ElseIf (cdx = colBound - 1) Then
                    edgeFlags += ContourCell.Edge.Right
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

#Region " Compute Operations Point - Interpolation "

    '*********************************************************************************************************
    ' Function OperationsPointInterpolate() - Compute an Operations Point using Grid Interpolation
    '
    ' Input(s):     x                       - Cutoff Time (Tco) or Cutoff Distance (XR)
    '               y                       - Inflow Rate (Q0) or Border Width (BW)
    '
    ' Called By:    Calculate Solution      - to estimate the Operations Point at a selected Point
    '
    ' Returns:      ContourPoint            - the Operations Point
    '*********************************************************************************************************
    Protected Function OperationsPointInterpolate(ByVal x As Double, ByVal y As Double) As ContourPoint
        Dim point As ContourPoint = Nothing

        If (mContourGrid IsNot Nothing) Then

            Dim cells As ContourCell(,) = mContourGrid.CellArray

            Dim minx As Single = mContourGrid.MinX
            Dim maxx As Single = mContourGrid.MaxX
            Dim rngx As Single = maxx - minx
            Debug.Assert(minx <= x And x <= maxx And 0 < rngx)

            Dim miny As Single = mContourGrid.MinY
            Dim maxy As Single = mContourGrid.MaxY
            Dim rngy As Single = maxy - miny
            Debug.Assert(miny <= y And y <= maxy And 0 < rngy)

            For row As Integer = 0 To cells.GetUpperBound(0)
                For col As Integer = 0 To cells.GetUpperBound(1)
                    Dim cell As ContourCell = mContourGrid.Cell(row, col)

                    If (cell.BL.X.Value <= x And x <= cell.BR.X.Value) Then
                        If (cell.BL.Y.Value <= y And y <= cell.TL.Y.Value) Then
                            ' Found Cell containing selected Operations Point;
                            '  find interior triangle containing point

                            Dim P As PointF = New PointF(x, y)

                            Dim V1, V2, V3 As PointF
                            Dim W1, W2, W3 As Single

                            ' Check left triangle
                            V1 = New PointF(cell.C.X.Value, cell.C.Y.Value)
                            V2 = New PointF(cell.TL.X.Value, cell.TL.Y.Value)
                            V3 = New PointF(cell.BL.X.Value, cell.BL.Y.Value)

                            Dim inLeft As Boolean = TriangularInterpolation(V1, V2, V3, P, W1, W2, W3)
                            If (inLeft) Then
                                point = InterpolateContourPoint(cell.C, cell.TL, cell.BL, x, y, W1, W2, W3)
                            End If

                            ' Check top triangle
                            V1 = New PointF(cell.C.X.Value, cell.C.Y.Value)
                            V2 = New PointF(cell.TR.X.Value, cell.TR.Y.Value)
                            V3 = New PointF(cell.TL.X.Value, cell.TL.Y.Value)

                            Dim inTop As Boolean = TriangularInterpolation(V1, V2, V3, P, W1, W2, W3)
                            If (inTop) Then
                                point = InterpolateContourPoint(cell.C, cell.TR, cell.TL, x, y, W1, W2, W3)
                            End If

                            ' Check right triangle
                            V1 = New PointF(cell.C.X.Value, cell.C.Y.Value)
                            V2 = New PointF(cell.BR.X.Value, cell.BR.Y.Value)
                            V3 = New PointF(cell.TR.X.Value, cell.TR.Y.Value)

                            Dim inRight As Boolean = TriangularInterpolation(V1, V2, V3, P, W1, W2, W3)
                            If (inRight) Then
                                point = InterpolateContourPoint(cell.C, cell.BR, cell.TR, x, y, W1, W2, W3)
                            End If

                            ' Check bottom triangle
                            V1 = New PointF(cell.C.X.Value, cell.C.Y.Value)
                            V2 = New PointF(cell.BL.X.Value, cell.BL.Y.Value)
                            V3 = New PointF(cell.BR.X.Value, cell.BR.Y.Value)

                            Dim inBottom As Boolean = TriangularInterpolation(V1, V2, V3, P, W1, W2, W3)
                            If (inBottom) Then
                                point = InterpolateContourPoint(cell.C, cell.BL, cell.BR, x, y, W1, W2, W3)
                            End If

                        End If
                    End If
                Next col
            Next row

        End If

        Return point
    End Function

    '*********************************************************************************************************
    ' Function InterpolateContourPoint() - interpolate values of new contour point given enclosing triangle
    '
    ' Input(s):     P1              - contour point 1                    P1
    '               P2              -    "     "    2                   /  \
    '               P3              -    "     "    3                  /  P \
    '                                                                P2 ---- P3
    '               x               - X location of P
    '               y               - Y     "     " "
    '
    '               W1              - interpolation weight for values from P1
    '               W2              -       "          "    "     "     "  P2
    '               W3              -       "          "    "     "     "  P3
    '
    ' Returns:      ContourPoint    - new interpolated ContourPoint
    '*********************************************************************************************************
    Private Function InterpolateContourPoint(ByVal P1 As ContourPoint, ByVal P2 As ContourPoint, ByVal P3 As ContourPoint,
                                             ByVal x As Double, ByVal y As Double, ByVal W1 As Single, ByVal W2 As Single, ByVal W3 As Single) As ContourPoint
        ' Start with clone of point 1
        Dim point As ContourPoint = New ContourPoint(P1, True)

        ' Load specified contour location
        point.X.Value = x
        point.Y.Value = y

        ' Interpolate Z value from input enclosing triangular ContourPoints
        For zdx As Integer = 0 To point.Z.Count - 1
            Dim V1 As Single = DirectCast(P1.Z(zdx), SingleParameter).Value
            Dim V2 As Single = DirectCast(P2.Z(zdx), SingleParameter).Value
            Dim V3 As Single = DirectCast(P3.Z(zdx), SingleParameter).Value

            DirectCast(point.Z(zdx), SingleParameter).Value = V1 * W1 + V2 * W2 + V3 * W3
        Next zdx

        Return point
    End Function

#End Region

#Region " Refine Operations Grid - SRFR Simulation "

    '*********************************************************************************************************
    ' Function RefineOperationsGridSrfrSim() - Refine Operations Contour Grid using SRFR simultaions
    '*********************************************************************************************************
    Protected Function RefineOperationsGridSrfrSim(ByVal Method As OperationsMethod) As Boolean

        ' Define variables
        Dim point As ContourPoint = Nothing
        Dim rdx, cdx As Integer

        Me.StatusMessage &= " - " & mDictionary.tRefiningContourGrid.Translated

        Dim rowBound As Integer = mContourGrid.PointArray.GetUpperBound(0)
        Dim colBound As Integer = mContourGrid.PointArray.GetUpperBound(1)
        Dim numRows As Integer = rowBound + 1
        Dim numCols As Integer = colBound + 1

        Dim numSimRun As Integer = 0
        Dim numPoints As Integer = numRows * numCols + rowBound * colBound
        Dim status As String

        ' Display BG thread window, if necessary
        Select Case (Method)
            Case OperationsMethod.SrfrUiThread
            Case OperationsMethod.SrfrBgThreads
                ClearResultsList()
                mRunContourSimulations.Show()
                mRunContourSimulations.BringToFront()
            Case Else ' OperationsMethod.VolumeBalance
                Debug.Assert(False)
        End Select

        ' Refine previously calculated contour grid points
        For rdx = 0 To rowBound
            For cdx = 0 To colBound
                numSimRun += 1
                status = numSimRun & " / " & numPoints.ToString
                mWorldWindow.ProgressMessage = status

                If (mRunContourSimulations.Visible) Then
                    mRunContourSimulations.ProgressMessage = status
                End If

                point = mContourGrid.Point(rdx, cdx)
                Me.RefineOperationsPointSrfrSim(point, Method, numSimRun)
            Next cdx
        Next rdx

        ' Retrieve SRFR results for grid points, if necessary
        Select Case (Method)
            Case OperationsMethod.SrfrUiThread
            Case OperationsMethod.SrfrBgThreads
                ' Wait for background threads to finish
                mRunContourSimulations.WaitforSrfrSimsToComplete()

                ' Get SRFR Results from just completed background SRFR runs
                For Each SrfrSim In mRunContourSimulations.SrfrRunMgr.SrfrSims
                    If Not (SrfrSim.ResultsUploaded) Then
                        If (SrfrSim.uiSrfrAPI IsNot Nothing) Then
                            Dim results As Srfr.Results = SrfrSim.uiSrfrAPI.Irrigation.Results
                            AddToResultsList(results)
                            SrfrSim.ResultsUploaded = True
                        End If
                    End If
                Next

                ' Sort SRFR Results since BG threads may completed out-of-order started
                SortResultsList()

                ' Move SRFR Results into grid points
                For Each results As Srfr.Results In Me.SrfrResults
                    Dim runNo As Integer = results.SimNum - 1
                    cdx = runNo Mod numCols
                    rdx = Math.Floor(runNo / numCols)
                    point = mContourGrid.Point(rdx, cdx)

                    SrfrResultsToContourPoint(results, point)
                Next

                ClearResultsList()
            Case Else ' OperationsMethod.VolumeBalance
                Debug.Assert(False)
        End Select

        ' Update contour cells from refined contour grid points
        For rdx = 0 To rowBound - 1
            For cdx = 0 To colBound - 1

                ' Update Contour Cell with refined corner points
                mContourGrid.Cell(rdx, cdx).BL = mContourGrid.Point(rdx, cdx)            ' Bottom-left
                mContourGrid.Cell(rdx, cdx).BR = mContourGrid.Point(rdx, cdx + 1)        ' Bottom-right
                mContourGrid.Cell(rdx, cdx).TL = mContourGrid.Point(rdx + 1, cdx)        ' Top-left
                mContourGrid.Cell(rdx, cdx).TR = mContourGrid.Point(rdx + 1, cdx + 1)    ' Top-right

                ' Refine center point
                numSimRun += 1
                status = numSimRun & " / " & numPoints.ToString
                mWorldWindow.ProgressMessage = status

                If (mRunContourSimulations.Visible) Then
                    mRunContourSimulations.ProgressMessage = status
                End If

                point = mContourGrid.Cell(rdx, cdx).C
                Me.RefineOperationsPointSrfrSim(point, Method, numSimRun)
            Next cdx
        Next rdx

        ' Retrieve SRFR results for cell center points, if necessary
        Select Case (Method)
            Case OperationsMethod.SrfrUiThread
            Case OperationsMethod.SrfrBgThreads
                ' Wait for background threads to finish
                mRunContourSimulations.WaitforSrfrSimsToComplete()

                ' Get SRFR Results from just completed background SRFR runs
                For Each SrfrSim In mRunContourSimulations.SrfrRunMgr.SrfrSims
                    If Not (SrfrSim.ResultsUploaded) Then
                        If (SrfrSim.uiSrfrAPI IsNot Nothing) Then
                            Dim results As Srfr.Results = SrfrSim.uiSrfrAPI.Irrigation.Results
                            AddToResultsList(results)
                            SrfrSim.ResultsUploaded = True
                        End If
                    End If
                Next

                ' Sort SRFR Results since BG threads may completed out-of-order started
                SortResultsList()

                ' Move SRFR Results into cell center points
                For Each results As Srfr.Results In Me.SrfrResults
                    Dim runNo As Integer = results.SimNum - (numRows * numCols) - 1
                    cdx = runNo Mod (numCols - 1)
                    rdx = Math.Floor(runNo / (numCols - 1))
                    point = mContourGrid.Cell(rdx, cdx).C

                    SrfrResultsToContourPoint(results, point)
                Next

            Case Else ' OperationsMethod.VolumeBalance
                Debug.Assert(False)
        End Select

        ' Build the cells Error Contours as a standard contour
        For rdx = 0 To rowBound - 1
            For cdx = 0 To colBound - 1
                Dim cell As PrecisionContourCell = mContourGrid.Cell(rdx, cdx)

                cell.Precision = Globals.ContourPrecision.Standard
                cell.BuildLimitContour()

                ' Restore cell precision to user selected value
                If (WinSRFR.UserPreferences.CalculatePrecisionContours = True) Then
                    cell.Precision = Globals.ContourPrecision.Precise
                Else
                    cell.Precision = Globals.ContourPrecision.Standard
                End If
            Next cdx
        Next rdx

        ' Hide BG thread window, if necessary
        Select Case (Method)
            Case OperationsMethod.SrfrUiThread
            Case OperationsMethod.SrfrBgThreads
                mRunContourSimulations.Hide()
            Case Else ' OperationsMethod.VolumeBalance
                Debug.Assert(False)
        End Select

    End Function

#End Region

#Region " Refine Operations Point - SRFR Simulation "

    '*********************************************************************************************************
    ' Function RefineOperationsPointSrfrSim() - Refine an Operations Point using a SRFR Simulation
    '
    ' Input(s):     Point                   - Operations Point to refine
    '               Method                  - OperationsMethod to use for refinement
    '*********************************************************************************************************
    Public Sub RefineOperationsPointSrfrSim(ByVal Point As ContourPoint,
                                            ByVal Method As OperationsMethod,
                                            ByVal RunNo As Integer)

        Select Case (Method)
            Case OperationsMethod.SrfrUiThread
                RefineOperationsPointUiThread(Point, RunNo)
            Case OperationsMethod.SrfrBgThreads
                RefineOperationsPointBgThreads(Point, RunNo)
            Case Else ' OperationsMethod.VolumeBalance
                Debug.Assert(False)
        End Select

    End Sub

    '*********************************************************************************************************
    ' Sub RefineOperationsPointUiThread()   - run SRFR Simulation in User Interface (UI) thread
    ' Sub RefineOperationsPointBgThreads()  -  "    "       "      " Background     (BG)    "
    '
    ' Input(s):     Point                   - Operations Point to refine
    '*********************************************************************************************************
    Public Sub RefineOperationsPointUiThread(ByVal Point As ContourPoint,
                                             ByVal RunNo As Integer)

        ' Contour's X-axis is always Cutoff Time (Tco)
        SrfrAPI.Inflow.Tco = Point.X.Value

        ' Contour's Y axis for Borders is always Inflow Rate (Q0)
        '    "      "   "   "  Furrows is either Inflow Rate (Q0) or Width
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
                SrfrAPI.CrossSection.FurrowsPerSet = Point.Y.Value
                SrfrAPI.CrossSection.BorderWidth = Point.Y.Value * mSystemGeometry.FurrowSpacing.Value
            Else ' WidthGiven
                SrfrAPI.Inflow.Q0 = Point.Y.Value
            End If
        Else ' Border
            SrfrAPI.Inflow.Q0 = Point.Y.Value
        End If

        ' Run the SRFR Simulation
        SrfrAPI.Simulate(mSolutionModel)

        ' Get the Results and move them into the Contour Point
        Dim SrfrResults As Srfr.Results = SrfrAPI.Irrigation.Results.Clone

        SrfrResultsToContourPoint(SrfrResults, Point)

    End Sub

    Public Sub RefineOperationsPointBgThreads(ByVal Point As ContourPoint,
                                              ByVal RunNo As Integer)
        Dim pointID As String = ""

        ' Contour's X-axis is always Cutoff Time (Tco)
        SrfrAPI.Inflow.Tco = Point.X.Value
        pointID &= "Tco = " & Point.X.Value.ToString

        ' Contour's Y axis for Borders is always Inflow Rate (Q0)
        '    "      "   "   "  Furrows is either Inflow Rate (Q0) or Width
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
                SrfrAPI.CrossSection.FurrowsPerSet = Point.Y.Value
                SrfrAPI.CrossSection.BorderWidth = Point.Y.Value * mSystemGeometry.FurrowSpacing.Value
                pointID &= "; BW = " & Point.Y.Value.ToString
            Else ' WidthGiven
                SrfrAPI.Inflow.Q0 = Point.Y.Value
                pointID &= "; Q0 = " & Point.Y.Value.ToString
            End If
        Else ' Border
            SrfrAPI.Inflow.Q0 = Point.Y.Value
            pointID &= "; Q0 = " & Point.Y.Value.ToString
        End If

        ' Get next available SRFR Simulation
        Dim SrfrSim As Srfr.SrfrSimulation = mRunContourSimulations.GetAvailableSrfrSimulation

        With SrfrSim
            If (.uiSrfrAPI Is Nothing) Then ' SrfrAPI needs to be instantiated
                .uiSrfrAPI = New Srfr.SrfrAPI

            Else ' SrfrAPI may contain results from previous simulation, save them
                If Not (.ResultsUploaded) Then
                    Dim results As Srfr.Results = .uiSrfrAPI.Irrigation.Results
                    AddToResultsList(results)
                    .ResultsUploaded = True
                End If
            End If

            With .uiSrfrAPI
                ' Copy the UI's SrfrAPI inputs to the BG SrfrAPI
                .CrossSection = SrfrAPI.CrossSection.Clone
                .Roughness = SrfrAPI.Roughness.Clone
                .Infiltration = SrfrAPI.Infiltration.Clone
                .Inflow = SrfrAPI.Inflow.Clone
                .SimName = pointID
                .SimNum = RunNo.ToString
            End With

            ' Define Solution Model to use for Simulation
            Dim uiSolMod As SolutionModel
            If (SrfrAPI.SolMod.GetType Is GetType(KinematicWave)) Then
                Dim KW = New KinematicWave With {
                        .ZeroInertiaRecession = True
                    }
                uiSolMod = KW
            Else
                Dim ZI = New ZeroInertia()
                uiSolMod = ZI
            End If

            uiSolMod.CellDensity = SrfrAPI.SolMod.CellDensity
            uiSolMod.StatusEventCriteria = Srfr.SolutionModel.StatusEvents.BFLGS

            .uiSolMod = uiSolMod

            .ResultsUploaded = False

            ' Run SRFR simulation using a background thread
            .Run() ' returns immediately; does not wait for simulation to finish

        End With

    End Sub

    '*********************************************************************************************************
    ' Sub SrfrResultsToContourPoint() - move results from SRFR Simulation into Contour Point
    '
    ' Input(s):     SrfrResults     - Results from SRFR Simulation run
    '               Point           - Operations Point to refine
    '*********************************************************************************************************
    Public Sub SrfrResultsToContourPoint(ByVal SrfrResults As Srfr.Results,
                                         ByVal Point As ContourPoint)

        ' Z(0) is value not defined by X & Y contour axes
        Dim sParam As SingleParameter = Point.Z(0)

        If (mUnit.CrossSection = CrossSections.Furrow) Then
            If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
                sParam.Value = SrfrResults.Tco          ' Inflow Rate
            Else ' WidthGiven
                sParam.Value = SrfrResults.Width        ' Border Width
            End If
        Else ' Border
            sParam.Value = SrfrResults.Width            ' Border Width
        End If

        sParam = Point.Z(1)
        sParam.Value = SrfrResults.AE                   ' Application Efficiency

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            sParam = Point.Z(2)
            sParam.Value = SrfrResults.DUmin            ' Minimum Distribution Uniformity

            sParam = Point.Z(3)
            sParam.Value = SrfrResults.ADmin            ' Minimum Adequacy
        Else ' Low-Quarter
            sParam = Point.Z(2)
            sParam.Value = SrfrResults.DUlq             ' Low-Quarter Distribution Uniformity

            sParam = Point.Z(3)
            sParam.Value = SrfrResults.ADlq             ' Low-Quarter Adequacy
        End If

        sParam = Point.Z(4)
        sParam.Value = SrfrResults.ROpct                ' Runoff

        sParam = Point.Z(5)
        sParam.Value = SrfrResults.DPpct                ' Deep percolation

        sParam = Point.Z(6)
        sParam.Value = SrfrResults.Dapp                 ' Applied Depth

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            sParam = Point.Z(7)
            sParam.Value = SrfrResults.Dmin             ' Minimum Depth
        Else
            sParam = Point.Z(7)
            sParam.Value = SrfrResults.Dlq              ' Low-Quarter Depth
        End If

        sParam = Point.Z(8)
        sParam.Value = SrfrResults.Txa                  ' Maximum Advance time

        sParam = Point.Z(9)
        sParam.Value = SrfrResults.XR                   ' Relative cutoff

        ' 10 & 11 are fillers

        sParam = Point.Z(12)
        sParam.Value = SrfrResults.WaterCostPerHectare  ' Cost

    End Sub

#End Region

#Region " Contour Point "

    '*********************************************************************************************************
    ' Function GetContourPoint() - get a specified Operations Contour Point
    '
    ' Input(s):     x               - Cutoff Time (Tco) or Cutoff Distance (XR)
    '               y               - Inflow Rate (Q0) or Border Width (BW)
    '
    ' Returns:      ContourPoint    - the Operations Point
    '*********************************************************************************************************
    Public Overrides Function GetContourPoint(ByVal x As Double, ByVal y As Double,
                                              ByVal numDistances As Integer) As ContourPoint
        Dim point As ContourPoint = Nothing

        If (mOperationsMethod = OperationsMethod.VolumeBalance) Then ' Volume Balance calculated

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

        Else ' SRFR Simulation

            point = OperationsPointInterpolate(x, y)

        End If

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
