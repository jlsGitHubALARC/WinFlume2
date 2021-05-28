
'*************************************************************************************************************
' Class:    OperationsAnalysis
'
' Desc: Base class for all WinSRFR Operations Analyses; derived from Analysis
'*************************************************************************************************************
Imports DataStore
Imports Srfr
Imports Srfr.Globals
Imports WinMain.SrfrContourParameter

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

        Dim point As ContourPoint
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

#Region " Build Operations Grid - SRFR Simulation "

    '*********************************************************************************************************
    ' Function BuildOperationsGridSrfrSim() - Build Operations Grid using SRFR Simulations
    '
    ' The Contour Grid is used as the guide for calculation the contour graphs; it must be
    ' built before computing the contours.
    '*********************************************************************************************************
    Protected Function BuildOperationsGridSrfrSim() As Boolean

        ' Define variables
        Dim SrfrSim As Srfr.SrfrSimulation

        Dim point As ContourPoint
        Dim rdx, cdx As Integer

        If (mLineList IsNot Nothing) Then
            mLineList.Clear()
            mLineList = Nothing
        End If

        Me.StatusMessage &= " - " & mDictionary.tBuildingContourGrid.Translated

        Dim numCellsX As Integer = mNumGridCellsX
        Dim numCellsY As Integer = mNumGridCellsY
        Dim numPointsX As Integer = numCellsX + 1
        Dim numPointsY As Integer = numCellsY + 1

        ' Grid Points = numPointsY * numPointsX; Cell Center Points = numCellsY * numCellsX
        Dim numPoints As Integer = numPointsY * numPointsX + numCellsY * numCellsX
        Dim numSimRun As Integer = 0
        Dim status As String

        RunSRFR(False, True, True)

        ' Display BG thread window
        mRunContourSimulations.Show()
        mRunContourSimulations.BringToFront()
        '
        ' Build list of SRFR Simulation Results for contour grid
        '
        ClearResultsList()

        If ((mUnit.CrossSection = CrossSections.Furrow) _
        And (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven)) Then
            '
            ' Contour is Cutoff Times (X axis; cols) vs. Widths (Y axis; rows)
            '
            Debug.Assert(mNumCutoffTimes = numPointsX)
            Debug.Assert(mNumWidths = numPointsY)

            ' Get Simulation Results for each contour point
            For rdx = 0 To mNumWidths - 1
                mWidth = Widths(rdx)                ' Next Y (row) Width
                mFurrowsPerSet = mWidth / mSystemGeometry.FurrowSpacing.Value

                For cdx = 0 To mNumCutoffTimes - 1
                    mTco = CutoffTimes(cdx)         ' Next X (col) Cutoff Time

                    numSimRun += 1
                    status = numSimRun & " / " & numPoints.ToString
                    mWorldWindow.ProgressMessage = status

                    If (mRunContourSimulations.Visible) Then
                        mRunContourSimulations.ProgressMessage = status
                    End If

                    Me.SimulateOperationsPoint(mInflowRate, mWidth, mTco, numSimRun)
                Next cdx
            Next rdx

        Else ' Width Given
            '
            ' Contour is Cutoff Times (X axis; cols) vs. Inflow Rates (Y axis; rows)
            '
            Debug.Assert(mNumCutoffTimes = numPointsX)
            Debug.Assert(mNumInflowRates = numPointsY)

            ' Get Simulation Results for each contour point
            For rdx = 0 To mNumInflowRates - 1
                mInflowRate = InflowRates(rdx)      ' Next Y (row) Inflow Rate

                For cdx = 0 To mNumCutoffTimes - 1
                    mTco = CutoffTimes(cdx)         ' Next X (col) Cutoff Time

                    numSimRun += 1
                    status = numSimRun & " / " & numPoints.ToString
                    mWorldWindow.ProgressMessage = status

                    If (mRunContourSimulations.Visible) Then
                        mRunContourSimulations.ProgressMessage = status
                    End If

                    Me.SimulateOperationsPoint(mInflowRate, mWidth, mTco, numSimRun)
                Next cdx
            Next rdx
        End If
        '
        ' Retrieve SRFR results for grid points
        '
        mRunContourSimulations.WaitforSrfrSimsToComplete()  ' Wait for background threads to finish

        ' Get SRFR Results from just completed background SRFR runs
        For Each SrfrSim In mRunContourSimulations.SrfrRunMgr.SrfrSims
            If Not (SrfrSim.ResultsUploaded) Then
                If (SrfrSim.uiSrfrAPI IsNot Nothing) Then
                    Dim results As Srfr.Results = SrfrSim.uiSrfrAPI.Irrigation.Results
                    'Debug.Assert(results.BorderWidth = results.Width * results.FurrowPerSet)
                    AddToResultsList(results)
                    SrfrSim.ResultsUploaded = True
                End If
            End If
        Next

        Debug.Assert(Me.SrfrResults.Count = numPointsX * numPointsY)

        SortResultsList()   ' Sort SRFR Results as BG threads may complete out-of-order
        '
        ' Generate grid points from Simulation Results
        '
        If ((mUnit.CrossSection = CrossSections.Furrow) _
        And (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven)) Then

            ' Contour is Cutoff Times (X axis; cols) vs. Widths (Y axis; rows)
            mContourGrid = New ContourGrid(mNumWidths, mNumCutoffTimes) With {
                .ColName = mDictionary.tCutoffTime.Translated,      ' X-axis (cols) is cutoff time
                .RowName = mDictionary.tWidth.Translated            ' Y-axis (rows) is width
            }

            mContourGrid.ValueName(ZIndex) = sInflowRate ' Z(0) is Inflow RAte

        Else ' Width Given

            ' Contour is Cutoff Times (X axis; cols) vs. Inflow Rates (Y axis; rows)
            mContourGrid = New ContourGrid(mNumInflowRates, mNumCutoffTimes) With {
                .ColName = mDictionary.tCutoffTime.Translated,      ' X-axis (cols) is cutoff time
                .RowName = mDictionary.tInflowRate.Translated       ' Y-axis (rows) is inflow rate
            }

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

        mContourGrid.ValueName(TcoIndex) = sCutoffRatio

        mContourGrid.ValueName(CostIndex) = sCost

        For rdx = 0 To numPointsY - 1
            For cdx = 0 To numPointsX - 1
                Dim results As Srfr.Results = Me.SrfrResults(rdx * numPointsX + cdx)
                mContourGrid.Point(rdx, cdx) = OperationsPointSrfrSim(results)
            Next cdx
        Next rdx
        '
        ' Build list of SRFR Simulation Results for center point of contour cells
        '
        ClearResultsList()

        For rdx = 0 To numCellsY - 1
            For cdx = 0 To numCellsX - 1
                ' Get cell's corner points
                ' Get corner points
                Dim bl As ContourPoint = mContourGrid.Point(rdx, cdx)            ' Bottom-left
                Dim br As ContourPoint = mContourGrid.Point(rdx, cdx + 1)        ' Bottom-right
                Dim tl As ContourPoint = mContourGrid.Point(rdx + 1, cdx)        ' Top-left
                Dim tr As ContourPoint = mContourGrid.Point(rdx + 1, cdx + 1)    ' Top-right

                mTco = (bl.X.Value + br.X.Value) / 2                ' Cutoff Time

                If ((mUnit.CrossSection = CrossSections.Furrow) _
                And (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven)) Then
                    mWidth = (bl.Y.Value + tl.Y.Value) / 2          ' Furrow Set Width
                    mFurrowsPerSet = mWidth / mSystemGeometry.FurrowSpacing.Value
                Else
                    mInflowRate = (bl.Y.Value + tl.Y.Value) / 2     ' Inflow Rate
                End If

                numSimRun += 1
                status = numSimRun & " / " & numPoints.ToString
                mWorldWindow.ProgressMessage = status

                If (mRunContourSimulations.Visible) Then
                    mRunContourSimulations.ProgressMessage = status
                End If

                Me.SimulateOperationsPoint(mInflowRate, mWidth, mTco, numSimRun)
            Next cdx
        Next rdx
        '
        ' Retrieve SRFR results for cell center points
        '
        mRunContourSimulations.WaitforSrfrSimsToComplete()  ' Wait for background threads to finish

        ' Get SRFR Results from just completed background SRFR runs
        For Each SrfrSim In mRunContourSimulations.SrfrRunMgr.SrfrSims
            If Not (SrfrSim.ResultsUploaded) Then
                If (SrfrSim.uiSrfrAPI IsNot Nothing) Then
                    Dim results As Srfr.Results = SrfrSim.uiSrfrAPI.Irrigation.Results
                    'Debug.Assert(results.BorderWidth = results.Width * results.FurrowPerSet)
                    AddToResultsList(results)
                    SrfrSim.ResultsUploaded = True
                End If
            End If
        Next

        Debug.Assert(Me.SrfrResults.Count = numCellsX * numCellsY)

        SortResultsList()   ' Sort SRFR Results as BG threads may complete out-of-order
        '
        ' Build contour cells from contour points
        '
        Debug.Assert(numCellsY = mContourGrid.PointArray.GetUpperBound(0))
        Debug.Assert(numCellsX = mContourGrid.PointArray.GetUpperBound(1))

        For rdx = 0 To numCellsY - 1
            For cdx = 0 To numCellsX - 1
                ' Get corner points
                Dim bl As ContourPoint = mContourGrid.Point(rdx, cdx)            ' Bottom-left
                Dim br As ContourPoint = mContourGrid.Point(rdx, cdx + 1)        ' Bottom-right
                Dim tl As ContourPoint = mContourGrid.Point(rdx + 1, cdx)        ' Top-left
                Dim tr As ContourPoint = mContourGrid.Point(rdx + 1, cdx + 1)    ' Top-right

                mTco = (bl.X.Value + br.X.Value) / 2                ' Cutoff/cutback Times

                ' Create the cell with its center point
                Dim results As Srfr.Results = Me.SrfrResults(rdx * numCellsX + cdx)
                point = OperationsPointSrfrSim(results)
                Dim cell As PrecisionContourCell = New PrecisionContourCell(Me, rdx, cdx, tl, tr, bl, br, point)

                ' Set edge flags for cell
                Dim edgeFlags As Integer = ContourCell.Edge.NoEdge

                If (rdx = 0) Then
                    edgeFlags += ContourCell.Edge.Bottom
                ElseIf (rdx = numCellsY - 1) Then
                    edgeFlags += ContourCell.Edge.Top
                End If

                If (cdx = 0) Then
                    edgeFlags += ContourCell.Edge.Left
                ElseIf (cdx = numCellsX - 1) Then
                    edgeFlags += ContourCell.Edge.Right
                End If

                cell.CellEdge = edgeFlags
                mContourGrid.Cell(rdx, cdx) = cell

                ' Build the cell's Error Contour as a precise contour
                cell.Precision = Globals.ContourPrecision.Precise
                cell.BuildLimitContour()
                If (WinSRFR.UserPreferences.CalculatePrecisionContours = True) Then
                    cell.Precision = Globals.ContourPrecision.Precise
                Else
                    cell.Precision = Globals.ContourPrecision.Standard
                End If

            Next cdx
        Next rdx
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

#Region " Simulate Operations Point - SRFR Simulation "

    '*********************************************************************************************************
    ' Sub SimulateOperationsPoint() - Run a SRFR Simulations at what will become an Operations Point
    '
    ' Input(s):     InflowRate      - Qin
    '               Width           - BW    (BorderWidth | FurrowSetWidth)
    '               CutoffTime      - Tco
    '*********************************************************************************************************
    Public Sub SimulateOperationsPoint(ByVal InflowRate As Double, ByVal Width As Double,
                                       ByVal CutoffTime As Double, ByVal RunNo As Integer)
        Dim pointID As String = ""

        ' Contour's X-axis is always Cutoff Time (Tco)
        SrfrAPI.Inflow.Tco = CutoffTime
        pointID &= "Tco = " & CutoffTime.ToString

        ' Contour's Y axis for Borders is always Inflow Rate (Q0)
        '    "      "   "   "  Furrows is either Inflow Rate (Q0) or Width
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
                SrfrAPI.CrossSection.BorderWidth = Width
                SrfrAPI.CrossSection.FurrowsPerSet = Width / mSystemGeometry.FurrowSpacing.Value
                pointID &= "; BorderWidth = " & Width.ToString
            Else ' WidthGiven
                SrfrAPI.Inflow.Q0 = InflowRate
                pointID &= "; Q0 = " & InflowRate.ToString
            End If
        Else ' Border
            SrfrAPI.Inflow.Q0 = InflowRate
            pointID &= "; Q0 = " & InflowRate.ToString
        End If

        ' Get next available SRFR Simulation
        Dim SrfrSim As Srfr.SrfrSimulation = mRunContourSimulations.GetAvailableSrfrSimulation

        With SrfrSim
            If (.uiSrfrAPI Is Nothing) Then ' SrfrAPI needs to be instantiated
                .uiSrfrAPI = New Srfr.SrfrAPI

            Else ' SrfrAPI may contain results from previous simulation, save them
                If Not (.ResultsUploaded) Then
                    Dim results As Srfr.Results = .uiSrfrAPI.Irrigation.Results
                    Debug.Assert(results IsNot Nothing)
                    'Debug.Assert(results.BorderWidth = results.Width * results.FurrowPerSet)
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
                Dim KW = New KinematicWave With {.ZeroInertiaRecession = True}
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

#End Region

#Region " Compute Operations Point - SRFR Simulation "

    '*********************************************************************************************************
    ' Function OperationsPointSrfrSim() - Compute an Operations Point from SRFR Simulations Results
    '
    ' Input(s):     Results         - SRFR Simulation Results
    '
    ' Returns:      ContourPoint    - the Operations Point
    '*********************************************************************************************************
    Public Function OperationsPointSrfrSim(ByVal SrfrResults As Srfr.Results) As ContourPoint

        '**************************************************************************************
        ' Compute & load performance parameters into Contour Point
        '**************************************************************************************
        Dim contourPoint As SrfrContourPoint = New SrfrContourPoint With {
            .X = New SingleParameter(CSng(SrfrResults.Tco), Units.Seconds),
            .SrfrResults = SrfrResults
        }

        If (mUnit.CrossSection = CrossSections.Furrow) Then
            If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
                contourPoint.Y = New SingleParameter(CSng(SrfrResults.FurrowPerSet), Units.None)
            Else ' WidthGiven
                contourPoint.Y = New SingleParameter(CSng(SrfrResults.Q0avg), Units.Cms)
            End If
        Else ' Border
            contourPoint.Y = New SingleParameter(CSng(SrfrResults.Q0avg), Units.Cms)
        End If

        ' Move errors & warnings, if any, to Contour Point
        If (S0 < MaximumLevelSlope) Then
            ' Limit Line applies only to Level Furrows
            If (SrfrResults.XR < DesignLimitLine) Then
                AddExecutionWarning(WarningFlags.LimitLineExceeded,
                                    mDictionary.tLimitLineExceededID.Translated,
                                    mDictionary.tLimitLineExceededDetail.Translated)
                contourPoint.HasError = True
                contourPoint.ErrMsg = mDictionary.tLimitLineExceededID.Translated
            End If
        End If

        If ((Double.IsNaN(SrfrResults.TL)) Or (SrfrResults.TL <= 0.0)) Then
            AddExecutionWarning(WarningFlags.AdvanceRecessionInadequate,
                                mDictionary.tAdvanceRecessionInadequateID.Translated,
                                mDictionary.tAdvanceRecessionInadequateDetail.Translated)
            contourPoint.HasError = True
            contourPoint.ErrMsg = mDictionary.tAdvanceRecessionInadequateID.Translated
        End If

        If (OneWeek <= SrfrResults.Ttl) Then
            AddExecutionWarning(WarningFlags.TimeTooLong,
                                mDictionary.tTimeTooLongErrorID.Translated,
                                mDictionary.tTimeTooLongErrorDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tTimeTooLongErrorID.Translated
        End If

        ' NOTE - order of Z parameters must match calling function's order
        Dim parameter As SingleParameter

        parameter = New SingleParameter(CSng(SrfrResults.Width), Units.Meters)
        contourPoint.Z.Add(parameter)   ' Border Width

        parameter = New SingleParameter(CSng(SrfrResults.AE), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Application Efficiency

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            parameter = New SingleParameter(CSng(SrfrResults.DUmin), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Distribution Uniformity

            parameter = New SingleParameter(CSng(SrfrResults.ADmin), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Adequacy
        Else ' Low-Quarter
            parameter = New SingleParameter(CSng(SrfrResults.DUlq), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Distribution uniformity

            parameter = New SingleParameter(CSng(SrfrResults.ADlq), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Adequacy
        End If

        parameter = New SingleParameter(CSng(SrfrResults.ROpct), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Runoff

        parameter = New SingleParameter(CSng(SrfrResults.DPpct), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Deep percolation

        parameter = New SingleParameter(CSng(SrfrResults.Dapp), Units.Millimeters)
        contourPoint.Z.Add(parameter)   ' Applied Depth

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            parameter = New SingleParameter(CSng(SrfrResults.Dmin), Units.Millimeters)
            contourPoint.Z.Add(parameter)   ' Minimum Depth
        Else
            parameter = New SingleParameter(CSng(SrfrResults.Dlq), Units.Millimeters)
            contourPoint.Z.Add(parameter)   ' Low-Quarter Depth
        End If

        parameter = New SingleParameter(CSng(SrfrResults.Txa), Units.Seconds)
        contourPoint.Z.Add(parameter)   ' Maximum Advance time

        parameter = New SingleParameter(CSng(SrfrResults.XR), Units.None)
        contourPoint.Z.Add(parameter)   ' Relative cutoff

        parameter = New SingleParameter(CSng(0), Units.None)
        contourPoint.Z.Add(parameter)   ' Filler (10)

        parameter = New SingleParameter(CSng(0), Units.None)
        contourPoint.Z.Add(parameter)   ' Filler (11)

        parameter = New SingleParameter(CSng(SrfrResults.WaterCostPerHectare), Units.DollarsPerHectare)
        contourPoint.Z.Add(parameter)   ' Cost

        mSoilCropProperties.ClrSrfrInfiltration()

        Return contourPoint

    End Function

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
    Protected Function OperationsPointInterpolate() As ContourPoint
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            If (mBorderCriteria.OperationsOption.Value = DesignOptions.InflowRateGiven) Then
                Return Me.OperationsPointInterpolate(Tco, FurrowsPerSet * Width)
            Else ' Width given
                Return Me.OperationsPointInterpolate(Tco, InflowRate)
            End If
        Else ' Border
            Return Me.OperationsPointInterpolate(Tco, InflowRate)
        End If
    End Function

    Protected Function OperationsPointInterpolate(ByVal x As Double, ByVal y As Double) As ContourPoint
        Dim point As ContourPoint = Nothing

        Dim row, col As Integer
        Dim cell As ContourCell
        Dim cells As ContourCell(,)

        Try
            If (mContourGrid IsNot Nothing) Then

                cells = mContourGrid.CellArray

                Dim minx As Single = mContourGrid.MinX
                Dim maxx As Single = mContourGrid.MaxX
                Dim rngx As Single = maxx - minx
                Debug.Assert(minx <= x And x <= maxx And 0 < rngx)

                Dim miny As Single = mContourGrid.MinY
                Dim maxy As Single = mContourGrid.MaxY
                Dim rngy As Single = maxy - miny
                Debug.Assert(miny <= y And y <= maxy And 0 < rngy)

                For row = 0 To cells.GetUpperBound(0)
                    For col = 0 To cells.GetUpperBound(1)
                        cell = cells(row, col)
                        If (cell Is Nothing) Then
                            Exit Function
                        End If

                        ' Find Cell containing selected Operations Point;
                        If (cell.BL.X.Value <= x And x <= cell.BR.X.Value) Then
                            If (cell.BL.Y.Value <= y And y <= cell.TL.Y.Value) Then
                                ' Found Cell; find interior triangle containing point

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
                                    Exit Function
                                End If

                                ' Check top triangle
                                V1 = New PointF(cell.C.X.Value, cell.C.Y.Value)
                                V2 = New PointF(cell.TR.X.Value, cell.TR.Y.Value)
                                V3 = New PointF(cell.TL.X.Value, cell.TL.Y.Value)

                                Dim inTop As Boolean = TriangularInterpolation(V1, V2, V3, P, W1, W2, W3)
                                If (inTop) Then
                                    point = InterpolateContourPoint(cell.C, cell.TR, cell.TL, x, y, W1, W2, W3)
                                    Exit Function
                                End If

                                ' Check right triangle
                                V1 = New PointF(cell.C.X.Value, cell.C.Y.Value)
                                V2 = New PointF(cell.BR.X.Value, cell.BR.Y.Value)
                                V3 = New PointF(cell.TR.X.Value, cell.TR.Y.Value)

                                Dim inRight As Boolean = TriangularInterpolation(V1, V2, V3, P, W1, W2, W3)
                                If (inRight) Then
                                    point = InterpolateContourPoint(cell.C, cell.BR, cell.TR, x, y, W1, W2, W3)
                                    Exit Function
                                End If

                                ' Check bottom triangle
                                V1 = New PointF(cell.C.X.Value, cell.C.Y.Value)
                                V2 = New PointF(cell.BL.X.Value, cell.BL.Y.Value)
                                V3 = New PointF(cell.BR.X.Value, cell.BR.Y.Value)

                                Dim inBottom As Boolean = TriangularInterpolation(V1, V2, V3, P, W1, W2, W3)
                                If (inBottom) Then
                                    point = InterpolateContourPoint(cell.C, cell.BL, cell.BR, x, y, W1, W2, W3)
                                    Exit Function
                                End If

                            End If
                        End If
                    Next col
                Next row

            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        Finally
            OperationsPointInterpolate = point
        End Try

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
    ' Returns:      SrfrContourPoint    - new interpolated SrfrContourPoint
    '*********************************************************************************************************
    Private Function InterpolateContourPoint(ByVal P1 As SrfrContourPoint, ByVal P2 As SrfrContourPoint, ByVal P3 As SrfrContourPoint,
                                             ByVal x As Double, ByVal y As Double, ByVal W1 As Single, ByVal W2 As Single, ByVal W3 As Single) As SrfrContourPoint

        ' Start with clone (i.e structure but no data) of point 1
        Dim point As SrfrContourPoint = New SrfrContourPoint(P1, True)
        Dim L1, L2, L3 As Integer

        ' Load specified contour location
        point.X.Value = x
        point.Y.Value = y

        Try
            ' Max Advance distance
            Dim D1, D2, D3 As Double
            D1 = P1.SrfrResults.Xa
            D2 = P2.SrfrResults.Xa
            D3 = P3.SrfrResults.Xa
            Dim Xa As Single = D1 * W1 + D2 * W2 + D3 * W3

            ' Interpolate contour Z values from enclosing triangular ContourPoints
            For zdx As Integer = 0 To point.Z.Count - 1
                Dim V1 As Single = DirectCast(P1.Z(zdx), SingleParameter).Value
                Dim V2 As Single = DirectCast(P2.Z(zdx), SingleParameter).Value
                Dim V3 As Single = DirectCast(P3.Z(zdx), SingleParameter).Value

                DirectCast(point.Z(zdx), SingleParameter).Value = V1 * W1 + V2 * W2 + V3 * W3
            Next zdx

            ' Interpolate Advance Curve, if it exists
            If (point.SrfrResults.AdvanceCurve IsNot Nothing) Then
                L1 = P1.SrfrResults.AdvanceCurve.Rows.Count
                L2 = P2.SrfrResults.AdvanceCurve.Rows.Count
                L3 = P3.SrfrResults.AdvanceCurve.Rows.Count

                Debug.Assert(L1 = L2 And L2 = L3)

                mDistances.Clear()
                mAdvTimes.Clear()

                For idx As Integer = 0 To L1 - 1
                    Dim V1 As Double = CDbl(P1.SrfrResults.AdvanceCurve.Rows(idx).Item(1))
                    Dim V2 As Double = CDbl(P2.SrfrResults.AdvanceCurve.Rows(idx).Item(1))
                    Dim V3 As Double = CDbl(P3.SrfrResults.AdvanceCurve.Rows(idx).Item(1))

                    Dim row As DataRow = point.SrfrResults.AdvanceCurve.NewRow()
                    row.Item(0) = P1.SrfrResults.AdvanceCurve.Rows(idx).Item(0)
                    row.Item(1) = V1 * W1 + V2 * W2 + V3 * W3
                    point.SrfrResults.AdvanceCurve.Rows.Add(row)

                    mDistances.Add(row.Item(0))
                    mAdvTimes.Add(row.Item(1))
                Next idx

                'mSurfaceFlow.Advance.Value = point.SrfrResults.AdvanceCurve.Copy
            End If

            ' Interpolate Recession Curve, if it exists
            If (point.SrfrResults.RecessionCurve IsNot Nothing) Then
                L1 = P1.SrfrResults.RecessionCurve.Rows.Count
                L2 = P2.SrfrResults.RecessionCurve.Rows.Count
                L3 = P3.SrfrResults.RecessionCurve.Rows.Count

                Debug.Assert(L1 = L2 And L2 = L3)

                mRecTimes.Clear()

                For idx As Integer = 0 To L1 - 1
                    Dim V1 As Double = CDbl(P1.SrfrResults.RecessionCurve.Rows(idx).Item(1))
                    Dim V2 As Double = CDbl(P2.SrfrResults.RecessionCurve.Rows(idx).Item(1))
                    Dim V3 As Double = CDbl(P3.SrfrResults.RecessionCurve.Rows(idx).Item(1))

                    Dim row As DataRow = point.SrfrResults.RecessionCurve.NewRow()
                    row.Item(0) = P1.SrfrResults.RecessionCurve.Rows(idx).Item(0)
                    row.Item(1) = V1 * W1 + V2 * W2 + V3 * W3
                    point.SrfrResults.RecessionCurve.Rows.Add(row)

                    mRecTimes.Add(row.Item(1))
                Next idx

                'mSurfaceFlow.Recession.Value = point.SrfrResults.RecessionCurve.Copy
            End If

            ' Interpolate Infiltration Curve, if it exists
            If (point.SrfrResults.InfiltrationCurve IsNot Nothing) Then
                L1 = P1.SrfrResults.InfiltrationCurve.Rows.Count
                L2 = P2.SrfrResults.InfiltrationCurve.Rows.Count
                L3 = P3.SrfrResults.InfiltrationCurve.Rows.Count

                Debug.Assert(L1 = L2 And L2 = L3)

                mInfDepths.Clear()

                For idx As Integer = 0 To L1 - 1
                    Dim V1 As Double = CDbl(P1.SrfrResults.InfiltrationCurve.Rows(idx).Item(1))
                    Dim V2 As Double = CDbl(P2.SrfrResults.InfiltrationCurve.Rows(idx).Item(1))
                    Dim V3 As Double = CDbl(P3.SrfrResults.InfiltrationCurve.Rows(idx).Item(1))

                    Dim row As DataRow = point.SrfrResults.InfiltrationCurve.NewRow()
                    row.Item(0) = P1.SrfrResults.InfiltrationCurve.Rows(idx).Item(0)
                    If (Xa < row.Item(0)) Then ' beyond Max Advance
                        row.Item(1) = 0
                    Else
                        row.Item(1) = V1 * W1 + V2 * W2 + V3 * W3
                    End If

                    point.SrfrResults.InfiltrationCurve.Rows.Add(row)

                    mInfDepths.Add(row.Item(1))
                Next idx

                'mSubsurfaceFlow.LongitudinalInfiltration.Value = point.SrfrResults.InfiltrationCurve.Copy
            End If

            ' Interpolate Analysis performance parameters
            D1 = P1.SrfrResults.Length
            D2 = P2.SrfrResults.Length
            D3 = P3.SrfrResults.Length
            point.SrfrResults.Length = D1 * W1 + D2 * W2 + D3 * W3
            mLength = point.SrfrResults.Length

            If Not (mBorderCriteria.OperationsOption.Value = OperationsOptions.WidthGiven) Then
                If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                    D1 = P1.SrfrResults.Width * mSystemGeometry.FurrowsPerSet.Value
                    D2 = P2.SrfrResults.Width * mSystemGeometry.FurrowsPerSet.Value
                    D3 = P3.SrfrResults.Width * mSystemGeometry.FurrowsPerSet.Value
                Else ' Basin | Border
                    D1 = P1.SrfrResults.Width
                    D2 = P2.SrfrResults.Width
                    D3 = P3.SrfrResults.Width
                End If

                point.SrfrResults.Width = D1 * W1 + D2 * W2 + D3 * W3
                mWidth = point.SrfrResults.Width
                mFurrowsPerSet = mWidth / mSystemGeometry.FurrowSpacing.Value
            End If

            If Not (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
                If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                    D1 = P1.SrfrResults.Q0avg
                    D2 = P2.SrfrResults.Q0avg
                    D3 = P3.SrfrResults.Q0avg

                    point.SrfrResults.Q0avg = D1 * W1 + D2 * W2 + D3 * W3
                    mInflowRate = point.SrfrResults.Q0avg
                End If
            End If

            D1 = P1.SrfrResults.Tcb
            D2 = P2.SrfrResults.Tcb
            D3 = P3.SrfrResults.Tcb
            point.SrfrResults.Tcb = D1 * W1 + D2 * W2 + D3 * W3
            mTcb = point.SrfrResults.Tcb

            D1 = P1.SrfrResults.Qcb
            D2 = P2.SrfrResults.Qcb
            D3 = P3.SrfrResults.Qcb
            point.SrfrResults.Qcb = D1 * W1 + D2 * W2 + D3 * W3
            mCutbackRate = point.SrfrResults.Qcb

            D1 = P1.SrfrResults.TL
            D2 = P2.SrfrResults.TL
            D3 = P3.SrfrResults.TL
            point.SrfrResults.TL = D1 * W1 + D2 * W2 + D3 * W3
            mTL = point.SrfrResults.TL

            D1 = P1.SrfrResults.XR
            D2 = P2.SrfrResults.XR
            D3 = P3.SrfrResults.XR
            point.SrfrResults.XR = D1 * W1 + D2 * W2 + D3 * W3
            mXR = point.SrfrResults.XR

            ' Performance indicators

            D1 = P1.SrfrResults.AE
            D2 = P2.SrfrResults.AE
            D3 = P3.SrfrResults.AE
            point.SrfrResults.AE = D1 * W1 + D2 * W2 + D3 * W3
            mAE = point.SrfrResults.AE

            D1 = P1.SrfrResults.PAElq
            D2 = P2.SrfrResults.PAElq
            D3 = P3.SrfrResults.PAElq
            point.SrfrResults.PAElq = D1 * W1 + D2 * W2 + D3 * W3
            mPAElq = point.SrfrResults.PAElq

            D1 = P1.SrfrResults.DUlq
            D2 = P2.SrfrResults.DUlq
            D3 = P3.SrfrResults.DUlq
            point.SrfrResults.DUlq = D1 * W1 + D2 * W2 + D3 * W3
            mDUlq = point.SrfrResults.DUlq

            D1 = P1.SrfrResults.DUmin
            D2 = P2.SrfrResults.DUmin
            D3 = P3.SrfrResults.DUmin
            point.SrfrResults.DUmin = D1 * W1 + D2 * W2 + D3 * W3
            mDUmin = point.SrfrResults.DUmin

            ' Depths

            D1 = P1.SrfrResults.Dapp
            D2 = P2.SrfrResults.Dapp
            D3 = P3.SrfrResults.Dapp
            point.SrfrResults.Dapp = D1 * W1 + D2 * W2 + D3 * W3
            mDApp = point.SrfrResults.Dapp

            D1 = P1.SrfrResults.Dro
            D2 = P2.SrfrResults.Dro
            D3 = P3.SrfrResults.Dro
            point.SrfrResults.Dro = D1 * W1 + D2 * W2 + D3 * W3
            mRoDepth = point.SrfrResults.Dro
            mRoFraction = mRoDepth / mDApp

            D1 = P1.SrfrResults.Ddp
            D2 = P2.SrfrResults.Ddp
            D3 = P3.SrfrResults.Ddp
            point.SrfrResults.Ddp = D1 * W1 + D2 * W2 + D3 * W3
            mDpDepth = point.SrfrResults.Ddp
            mDpFraction = mDpDepth / mDApp

            D1 = P1.SrfrResults.Dmin
            D2 = P2.SrfrResults.Dmin
            D3 = P3.SrfrResults.Dmin
            point.SrfrResults.Dmin = D1 * W1 + D2 * W2 + D3 * W3
            mDMin = point.SrfrResults.Dmin

            D1 = P1.SrfrResults.Dlq
            D2 = P2.SrfrResults.Dlq
            D3 = P3.SrfrResults.Dlq
            point.SrfrResults.Dlq = D1 * W1 + D2 * W2 + D3 * W3
            mDLf = point.SrfrResults.Dlq

            D1 = P1.SrfrResults.Dinf
            D2 = P2.SrfrResults.Dinf
            D3 = P3.SrfrResults.Dinf
            point.SrfrResults.Dinf = D1 * W1 + D2 * W2 + D3 * W3
            mDInf = point.SrfrResults.Dinf

            D1 = P1.SrfrResults.WaterCostPerHectare
            D2 = P2.SrfrResults.WaterCostPerHectare
            D3 = P3.SrfrResults.WaterCostPerHectare
            point.SrfrResults.WaterCostPerHectare = D1 * W1 + D2 * W2 + D3 * W3
            mCost = point.SrfrResults.WaterCostPerHectare

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        Return point
    End Function

#End Region

#Region " Refine Operations Grid - SRFR Simulation "

    '*********************************************************************************************************
    ' Function RefineOperationsGridSrfrSim() - Refine Operations Contour Grid using SRFR simultaions
    '*********************************************************************************************************
    Protected Function RefineOperationsGridSrfrSim() As Boolean

        ' Define variables
        Dim SrfrSim As Srfr.SrfrSimulation

        Dim point As SrfrContourPoint
        Dim rdx, cdx As Integer

        Me.StatusMessage &= " - " & mDictionary.tRefiningContourGrid.Translated

        Dim rowBound As Integer = mContourGrid.PointArray.GetUpperBound(0)
        Dim colBound As Integer = mContourGrid.PointArray.GetUpperBound(1)
        Dim numRows As Integer = rowBound + 1
        Dim numCols As Integer = colBound + 1

        Dim numSimRun As Integer = 0
        Dim numPoints As Integer = numRows * numCols + rowBound * colBound
        Dim status As String

        ' Display BG thread window
        ClearResultsList()
        mRunContourSimulations.Show()
        mRunContourSimulations.BringToFront()
        '
        ' Refine previously calculated contour grid points
        '
        For rdx = 0 To rowBound
            For cdx = 0 To colBound
                numSimRun += 1
                status = numSimRun & " / " & numPoints.ToString
                mWorldWindow.ProgressMessage = status

                If (mRunContourSimulations.Visible) Then
                    mRunContourSimulations.ProgressMessage = status
                End If

                point = New SrfrContourPoint(mContourGrid.Point(rdx, cdx), True)
                Me.RefineOperationsPointSrfrSim(point, numSimRun)
                mContourGrid.Point(rdx, cdx) = point
            Next cdx
        Next rdx
        '
        ' Retrieve SRFR results for grid points
        '
        mRunContourSimulations.WaitforSrfrSimsToComplete()  ' Wait for background threads to finish

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

        SortResultsList()   ' Sort SRFR Results as BG threads may complete out-of-order
        '
        ' Move SRFR Results into grid points
        '
        For Each results As Srfr.Results In Me.SrfrResults
            Dim runNo As Integer = results.SimNum - 1
            cdx = runNo Mod numCols
            rdx = Math.Floor(runNo / numCols)

            point = New SrfrContourPoint(mContourGrid.Point(rdx, cdx), True)
            SrfrResultsToContourPoint(results, point)
            mContourGrid.Point(rdx, cdx) = point
        Next

        ClearResultsList()
        '
        ' Update contour cells from refined contour grid points
        '
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

                point = New SrfrContourPoint(mContourGrid.Cell(rdx, cdx).C, True)
                Me.RefineOperationsPointSrfrSim(point, numSimRun)
                mContourGrid.Cell(rdx, cdx).C = point
            Next cdx
        Next rdx
        '
        ' Retrieve SRFR results for cell center points, if necessary
        '
        mRunContourSimulations.WaitforSrfrSimsToComplete()  ' Wait for background threads to finish

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

        SortResultsList()   ' Sort SRFR Results as BG threads may complete out-of-order
        '
        ' Move SRFR Results into cell center points
        '
        For Each results As Srfr.Results In Me.SrfrResults
            Dim runNo As Integer = results.SimNum - (numRows * numCols) - 1
            cdx = runNo Mod (numCols - 1)
            rdx = Math.Floor(runNo / (numCols - 1))

            point = New SrfrContourPoint(mContourGrid.Cell(rdx, cdx).C, True)
            SrfrResultsToContourPoint(results, point)
            mContourGrid.Cell(rdx, cdx).C = point
        Next

        ClearResultsList()
        '
        ' Build the cells Error Contours as a standard contour
        '
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

        ' Hide BG thread window
        mRunContourSimulations.Hide()

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
                                            ByVal RunNo As Integer)
        RefineOperationsPointBgThreads(Point, RunNo)
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
    '               ContourPoint    - Operations Point to refine
    '*********************************************************************************************************
    Public Sub SrfrResultsToContourPoint(ByVal SrfrResults As Srfr.Results,
                                         ByVal ContourPoint As SrfrContourPoint)

        ' Move errors & warnings, if any, to Contour Point
        If (S0 < MaximumLevelSlope) Then
            ' Limit Line applies only to Level Furrows
            If (SrfrResults.XR < DesignLimitLine) Then
                AddExecutionWarning(WarningFlags.LimitLineExceeded,
                                    mDictionary.tLimitLineExceededID.Translated,
                                    mDictionary.tLimitLineExceededDetail.Translated)
                ContourPoint.HasError = True
                ContourPoint.ErrMsg = mDictionary.tLimitLineExceededID.Translated
            End If
        End If

        If ((Double.IsNaN(SrfrResults.TL)) Or (SrfrResults.TL <= 0.0)) Then
            AddExecutionWarning(WarningFlags.AdvanceRecessionInadequate,
                                mDictionary.tAdvanceRecessionInadequateID.Translated,
                                mDictionary.tAdvanceRecessionInadequateDetail.Translated)
            ContourPoint.HasError = True
            ContourPoint.ErrMsg = mDictionary.tAdvanceRecessionInadequateID.Translated
        End If

        If (OneWeek <= SrfrResults.Ttl) Then
            AddExecutionWarning(WarningFlags.TimeTooLong,
                                mDictionary.tTimeTooLongErrorID.Translated,
                                mDictionary.tTimeTooLongErrorDetail.Translated)
            ContourPoint.HasWarning = True
            ContourPoint.WarnMsg = mDictionary.tTimeTooLongErrorID.Translated
        End If

        ' NOTE - order of Z parameters must match calling function's order

        ' Z(0) is value not defined by X & Y contour axes
        Dim sParam As SingleParameter = ContourPoint.Z(0)

        If (mUnit.CrossSection = CrossSections.Furrow) Then
            If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
                sParam.Value = SrfrResults.Tco          ' Inflow Rate
            Else ' WidthGiven
                sParam.Value = SrfrResults.Width        ' Border Width
            End If
        Else ' Border
            sParam.Value = SrfrResults.Width            ' Border Width
        End If

        sParam = ContourPoint.Z(1)
        sParam.Value = SrfrResults.AE                   ' Application Efficiency

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            sParam = ContourPoint.Z(2)
            sParam.Value = SrfrResults.DUmin            ' Minimum Distribution Uniformity

            sParam = ContourPoint.Z(3)
            sParam.Value = SrfrResults.ADmin            ' Minimum Adequacy
        Else ' Low-Quarter
            sParam = ContourPoint.Z(2)
            sParam.Value = SrfrResults.DUlq             ' Low-Quarter Distribution Uniformity

            sParam = ContourPoint.Z(3)
            sParam.Value = SrfrResults.ADlq             ' Low-Quarter Adequacy
        End If

        sParam = ContourPoint.Z(4)
        sParam.Value = SrfrResults.ROpct                ' Runoff

        sParam = ContourPoint.Z(5)
        sParam.Value = SrfrResults.DPpct                ' Deep percolation

        sParam = ContourPoint.Z(6)
        sParam.Value = SrfrResults.Dapp                 ' Applied Depth

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            sParam = ContourPoint.Z(7)
            sParam.Value = SrfrResults.Dmin             ' Minimum Depth
        Else
            sParam = ContourPoint.Z(7)
            sParam.Value = SrfrResults.Dlq              ' Low-Quarter Depth
        End If

        sParam = ContourPoint.Z(8)
        sParam.Value = SrfrResults.Txa                  ' Maximum Advance time

        sParam = ContourPoint.Z(9)
        sParam.Value = SrfrResults.XR                   ' Relative cutoff

        ' 10 & 11 are fillers

        sParam = ContourPoint.Z(12)
        sParam.Value = SrfrResults.WaterCostPerHectare  ' Cost

        ContourPoint.SrfrResults = SrfrResults.Clone ' structure AND data

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
        Dim point As ContourPoint

        ' Y is Inflow Rate or Width
        Select Case (mBorderCriteria.OperationsOption.Value)
            Case OperationsOptions.InflowRateGiven
                mWidth = y
                mFurrowsPerSet = mWidth / mSystemGeometry.FurrowSpacing.Value
            Case Else ' Assume OperationsOptions.WidthGiven
                mInflowRate = y
        End Select

        ' X is Cutoff Time or Distance
        Dim cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)
        Select Case (cutoffMethod)
            Case CutoffMethods.DistanceBased
                mXR = x

                If (mOperationsMethod = OperationsMethod.VolumeBalance) Then ' Volume Balance calculated
                    point = OperationsPointVolBal(mInflowRate, mWidth, mXR, numDistances)
                Else ' SRFR Simulation
                    point = OperationsPointInterpolate()
                End If
            Case Else ' Assume CutoffMethods.TimeBased
                mTco = x

                If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                    If (mOperationsMethod = OperationsMethod.VolumeBalance) Then ' Volume Balance calculated
                        point = OperationsPointVolBal(mInflowRate, mWidth, mTco, numDistances)
                    Else ' SRFR Simulation
                        point = OperationsPointInterpolate()
                    End If
                Else
                    mCutbackRateRatio = mInflowManagement.CutbackRateRatio.Value
                    mCutbackRate = mInflowRate * mCutbackRateRatio
                    If (mOperationsMethod = OperationsMethod.VolumeBalance) Then ' Volume Balance calculated
                        point = OperationsPointVolBal(mInflowRate, mWidth, mTco, mCutbackRate, numDistances)
                    Else ' SRFR Simulation
                        point = OperationsPointInterpolate()
                    End If
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
            If (mOperationsMethod = OperationsMethod.VolumeBalance) Then ' Volume Balance calculated
                mSolutionPoint = Me.OperationsPointVolBal()
            Else ' SRFR Simulation
                mSolutionPoint = Me.OperationsPointInterpolate()
            End If
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

            'Case InfiltrationFunctions.GreenAmpt

            '    ' Green-Ampt not available for Operations Analysis
            '    AddSetupError(Analysis.ErrorFlags.GreenAmptNotAvailable,
            '             mDictionary.tGreenAmptNotAvailable.Translated,
            '             mDictionary.tGreenAmptNotAvailableForOperationsAnalysis.Translated)

            'Case InfiltrationFunctions.WarrickGreenAmpt

            '    ' Warrick Green-Ampt not available for Operations Analysis
            '    AddSetupError(Analysis.ErrorFlags.WarrickGreenAmptNotAvailable,
            '             mDictionary.tWarrickGreenAmptNotAvailable.Translated,
            '             mDictionary.tWarrickGreenAmptNotAvailableForOperationsAnalysis.Translated)

            Case InfiltrationFunctions.Hydrus1D

                ' HYDRUS-1D not available for Operations Analysis
                AddSetupError(Analysis.ErrorFlags.Hydrus1DNotAvailable,
                         mDictionary.tHydrus1DNotAvailable.Translated,
                         mDictionary.tHydrus1DNotAvailableForOperationsAnalysis.Translated)
        End Select

    End Sub

#End Region

#End Region

End Class
