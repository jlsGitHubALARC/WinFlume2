
'*************************************************************************************************************
' Class:    ElliotWalkerTwoPoint
'
' Desc:     Elliott-Walker Two-Point Analysis 
'*************************************************************************************************************
Imports DataStore

Public Class ElliotWalkerTwoPoint
    Inherits EventAnalysis

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
        If (mUnit IsNot Nothing) Then
            mKostiakovB = mSoilCropProperties.KostiakovB_MK.Value
        End If
    End Sub

#End Region

#Region " Properties "
    '
    ' Flow Rates
    '
    Protected mQavgT1 As Double
    Public ReadOnly Property QavgT1() As Double
        Get
            Return mQavgT1
        End Get
    End Property

    Protected mQavgT2 As Double
    Public ReadOnly Property QavgT2() As Double
        Get
            Return mQavgT2
        End Get
    End Property

    Protected mQavgFinal As Double
    Public ReadOnly Property QavgFinal() As Double
        Get
            Return mQavgFinal
        End Get
    End Property
    '
    ' Upstream Depths
    '
    Protected mUpstreamDepthT1 As Double
    Public ReadOnly Property UpstreamDepthT1() As Double
        Get
            Return mUpstreamDepthT1
        End Get
    End Property

    Protected mUpstreamDepthT2 As Double
    Public ReadOnly Property UpstreamDepthT2() As Double
        Get
            Return mUpstreamDepthT2
        End Get
    End Property
    '
    ' Hydraulic Gradients
    '
    Protected mHydraulicGradientT1 As Double
    Public ReadOnly Property HydraulicGradientT1() As Double
        Get
            Return mHydraulicGradientT1
        End Get
    End Property

    Protected mHydraulicGradientT2 As Double
    Public ReadOnly Property HydraulicGradientT2() As Double
        Get
            Return mHydraulicGradientT2
        End Get
    End Property
    '
    ' Flow Areas
    '
    Protected mFlowAreaT1 As Double
    Public ReadOnly Property FlowAreaT1() As Double
        Get
            Return mFlowAreaT1
        End Get
    End Property

    Protected mFlowAreaT2 As Double
    Public ReadOnly Property FlowAreaT2() As Double
        Get
            Return mFlowAreaT2
        End Get
    End Property

    Protected mShapedFlowAreaT1 As Double
    Public ReadOnly Property ShapedFlowAreaT1() As Double
        Get
            Return mShapedFlowAreaT1
        End Get
    End Property

    Protected mShapedFlowAreaT2 As Double
    Public ReadOnly Property ShapedFlowAreaT2() As Double
        Get
            Return mShapedFlowAreaT2
        End Get
    End Property
    '
    ' Hydraulic Radius
    '
    Protected mHydraulicRadiusT1 As Double
    Public ReadOnly Property HydraulicRadiusT1() As Double
        Get
            Return mHydraulicRadiusT1
        End Get
    End Property

    Protected mHydraulicRadiusT2 As Double
    Public ReadOnly Property HydraulicRadiusT2() As Double
        Get
            Return mHydraulicRadiusT2
        End Get
    End Property
    '
    ' Wetted Perimeter
    '
    Protected mWettedPerimeterT1 As Double
    Public ReadOnly Property WettedPerimeterT1() As Double
        Get
            Return mWettedPerimeterT1
        End Get
    End Property

    Protected mWettedPerimeterT2 As Double
    Public ReadOnly Property WettedPerimeterT2() As Double
        Get
            Return mWettedPerimeterT2
        End Get
    End Property
    '
    ' Inflow - Outflow
    '
    Protected mSteadyRO As Double
    Public ReadOnly Property SteadyRO() As Double
        Get
            Return mSteadyRO
        End Get
    End Property

    Protected mInOut As Double
    Public ReadOnly Property InOut() As Double
        Get
            Return mInOut
        End Get
    End Property
    '
    ' Estimated Kostiakov k, a & b
    '
    Protected mKostiakovK As Double
    Public ReadOnly Property KostiakovK() As Double
        Get
            Return mKostiakovK
        End Get
    End Property

    Protected mKostiakovA As Double
    Public ReadOnly Property KostiakovA() As Double
        Get
            Return mKostiakovA
        End Get
    End Property

    Protected mKostiakovB As Double
    Public Property KostiakovB() As Double
        Get
            Return mKostiakovB
        End Get
        Set(ByVal Value As Double)
            mKostiakovB = Value
        End Set
    End Property
    '
    ' Water Volumes
    '
    Protected mInflowVolumeT1 As Double
    Public ReadOnly Property InflowVolumeT1() As Double
        Get
            Return mInflowVolumeT1
        End Get
    End Property

    Protected mSurfaceVolumeT1 As Double
    Public ReadOnly Property SurfaceVolumeT1() As Double
        Get
            Return mSurfaceVolumeT1
        End Get
    End Property

    Protected mInfiltratedVolumeT1 As Double
    Public ReadOnly Property InfiltratedVolumeT1() As Double
        Get
            Return mInfiltratedVolumeT1
        End Get
    End Property

    Protected mInflowVolumeT2 As Double
    Public ReadOnly Property InflowVolumeT2() As Double
        Get
            Return mInflowVolumeT2
        End Get
    End Property

    Protected mSurfaceVolumeT2 As Double
    Public ReadOnly Property SurfaceVolumeT2() As Double
        Get
            Return mSurfaceVolumeT2
        End Get
    End Property

    Protected mInfiltratedVolumeT2 As Double
    Public ReadOnly Property InfiltratedVolumeT2() As Double
        Get
            Return mInfiltratedVolumeT2
        End Get
    End Property
    '
    ' Power Advance
    '
    Protected mPowerAdvanceExponent As Double
    Public ReadOnly Property PowerAdvanceExponent() As Double
        Get
            Return mPowerAdvanceExponent
        End Get
    End Property

    Protected mPowerAdvanceConstant As Double
    Public ReadOnly Property PowerAdvanceConstant() As Double
        Get
            Return mPowerAdvanceConstant
        End Get
    End Property
    '
    ' Simulation Results
    '
    Protected mAverageDepthT1 As Double
    Public ReadOnly Property AverageDepthT1() As Double
        Get
            Return mAverageDepthT1
        End Get
    End Property

    Protected mAverageDepthT2 As Double
    Public ReadOnly Property AverageDepthT2() As Double
        Get
            Return mAverageDepthT2
        End Get
    End Property

    Protected mAverageWettedPerimeterT1 As Double
    Public ReadOnly Property AverageWettedPerimeterT1() As Double
        Get
            Return mAverageWettedPerimeterT1
        End Get
    End Property

    Protected mAverageWettedPerimeterT2 As Double
    Public ReadOnly Property AverageWettedPerimeterT2() As Double
        Get
            Return mAverageWettedPerimeterT2
        End Get
    End Property

    Protected mAverageFlowAreaT1 As Double
    Public ReadOnly Property AverageFlowAreaT1() As Double
        Get
            Return mAverageFlowAreaT1
        End Get
    End Property

    Protected mAverageFlowAreaT2 As Double
    Public ReadOnly Property AverageFlowAreaT2() As Double
        Get
            Return mAverageFlowAreaT2
        End Get
    End Property

    Public Function ResultsAreValid() As Boolean
        ' Check Analysis errors & warnings
        UpdateSetupErrorsAndWarnings()
        Return Not HasSetupErrors()
    End Function

#End Region

#Region " Run Simulation "

    Protected Overrides Function UnloadSrfrResults(ByVal srfrAPI As Srfr.SrfrAPI, ByVal unit As Unit,
        ByVal compareRun As Boolean, ByVal skipProfiles As Boolean, ByVal skipHydroGraphs As Boolean) As Srfr.Irrigation
        ' Unload the SRFR results common to all/most Event Analyses
        Dim srfrResults As Srfr.Irrigation = Nothing
        srfrResults = MyBase.UnloadSrfrResults(srfrAPI, unit, compareRun, skipProfiles, skipHydroGraphs)
        '
        ' Unload the Elliott-Walker 2-Point specific, additional SRFR results
        '
        ' A simulation derived Volume Balance table that corresponds to the evaluation Volume Balance
        ' table is required for the results display.
        '
        If (srfrResults IsNot Nothing) Then
            Dim ewVolBalTable As DataTable = Me.VolumeBalanceTable
            If (ewVolBalTable IsNot Nothing) Then
                Dim simVolBalParam As DataTableParameter = mEventCriteria.SimulationVolumeBalances
                Dim simVolBalTable As DataTable = simVolBalParam.Value
                mEventCriteria.ResetVolumeBalancesTable(simVolBalTable)

                For Each ewRow As DataRow In ewVolBalTable.Rows
                    Dim time As Double = CDbl(ewRow.Item(sTimeX))

                    Dim Vin As Double = srfrResults.VinUptoTime(time)
                    Dim Vy As Double = srfrResults.VyAtTime(time)
                    Dim Vro As Double = srfrResults.VroUptoTime(time)
                    Dim Vz As Double = srfrResults.VzAtTime(time)

                    Dim simRow As DataRow = simVolBalTable.NewRow
                    simRow.Item(sTimeX) = time
                    simRow.Item(sVin) = Vin
                    simRow.Item(sVy) = Vy
                    simRow.Item(sVro) = Vro
                    simRow.Item(sVz) = Vz

                    simVolBalTable.Rows.Add(simRow)
                Next ewRow

                simVolBalParam.Source = ValueSources.Calculated
                mEventCriteria.SimulationVolumeBalances = simVolBalParam
            End If
        End If

        Return srfrResults
    End Function

#End Region

#Region " Methods "

#Region " Evaluation Execution "

    Public Overrides Sub RunEvaluation()
        ' Execute standard start analysis code
        Me.StartRun("Elliott-Walker Two-Point Analysis", False)

        ' Clear calculated Infiltration data
        mSoilCropProperties.ClearInfiltration()

        ' Calculate & save the Solution
        CalculateSolution()

        Me.EndRun()
    End Sub

#End Region

#Region " Solution "

    Public Overrides Sub CalculateSolution()
        MyBase.CalculateSolution()
        Me.RunSimulation(CellDensities.Medium)
    End Sub

    '********************************************************************************************************************************
    ' GetSimulationResults() - get parameters from SRFR Simulation required for Elliott-Walker two-point evaluation
    ' GetAverages()          - extract parameters from SRFR Profiles
    '********************************************************************************************************************************
    Protected Sub GetSimulationResults()

        ' Two-point distances
        Dim pt1Dist As Double = mInflowManagement.TwoPointDistance1
        Dim pt2Dist As Double = mInflowManagement.TwoPointDistance2

        ' Properties to build profiles for
        Dim propNames() As String = {"Y", "AY", "WP"}

        ' Reference to SRFR Irrigation object
        Dim srfrIrrigation As Srfr.Irrigation = SrfrAPI.Irrigation

        ' Build profiles for requested properties at two-point distances
        Dim pt1Profiles As DataTable = srfrIrrigation.AdvanceProfiles(propNames, pt1Dist)
        Dim pt2Profiles As DataTable = srfrIrrigation.AdvanceProfiles(propNames, pt2Dist)

        ' Extract averages for parameters
        GetAverages(pt1Profiles, mAverageDepthT1, mAverageFlowAreaT1, mAverageWettedPerimeterT1)
        GetAverages(pt2Profiles, mAverageDepthT2, mAverageFlowAreaT2, mAverageWettedPerimeterT2)

        ' Directly accessible simulation results
        mDMin = mSubsurfaceFlow.Dmin.Value
        mDLf = mSubsurfaceFlow.Dlq.Value
        mDInf = mSubsurfaceFlow.Davg.Value

    End Sub

    Protected Sub GetAverages(ByVal profiles As DataTable, _
                              ByRef averageDepth As Double, _
                              ByRef averageFlowArea As Double, _
                              ByRef averageWettedPerimeter As Double)

        ' Set default return values
        averageDepth = 0.0
        averageFlowArea = 0.0
        averageWettedPerimeter = 0.0

        Try
            ' Compute average depth (Y), flow area (AY) & wetted perimeter (WP) for profile
            Dim row As DataRow = profiles.Rows(0)
            Dim X1 As Double = row.Item(0)
            Dim Y1 As Double = row.Item(1)
            Dim AY1 As Double = row.Item(2)
            Dim WP1 As Double = row.Item(3)

            Dim X2, Y2, AY2, WP2 As Double

            For rdx As Integer = 1 To profiles.Rows.Count - 1

                row = profiles.Rows(rdx)

                X2 = row.Item(0)
                Y2 = row.Item(1)
                AY2 = row.Item(2)
                WP2 = row.Item(3)

                Dim DX As Double = X2 - X1
                Dim Yavg As Double = (Y1 + Y2) / 2.0
                Dim AYavg As Double = (AY1 + AY2) / 2.0
                Dim WPavg As Double = (WP1 + WP2) / 2.0

                ' Sum weighted values
                averageDepth += Yavg * DX
                averageFlowArea += AYavg * DX
                averageWettedPerimeter += WPavg * DX

                ' Right-side values become left-side values
                X1 = X2
                Y1 = Y2
                AY1 = AY2
                WP1 = WP2
            Next

            averageDepth /= X2
            averageFlowArea /= X2
            averageWettedPerimeter /= X2

        Catch ex As Exception
            ' Set default return values
            averageDepth = 0.0
            averageFlowArea = 0.0
            averageWettedPerimeter = 0.0
        End Try

    End Sub

    Protected Overrides Sub SaveSolution()
        ' Save parameters common to all design analyses
        MyBase.SaveSolution()

        ' Save SRFR animation results
        Dim _average As DoubleParameter = mSrfrResults.YavgPt1
        _average.Value = AverageDepthT1
        _average.Source = ValueSources.Calculated
        mSrfrResults.YavgPt1 = _average

        _average = mSrfrResults.YavgPt2
        _average.Value = AverageDepthT2
        _average.Source = ValueSources.Calculated
        mSrfrResults.YavgPt2 = _average

        _average = mSrfrResults.AYavgPt1
        _average.Value = AverageFlowAreaT1
        _average.Source = ValueSources.Calculated
        mSrfrResults.AYavgPt1 = _average

        _average = mSrfrResults.AYavgPt2
        _average.Value = AverageFlowAreaT2
        _average.Source = ValueSources.Calculated
        mSrfrResults.AYavgPt2 = _average

        _average = mSrfrResults.WPavgPt1
        _average.Value = AverageWettedPerimeterT1
        _average.Source = ValueSources.Calculated
        mSrfrResults.WPavgPt1 = _average

        _average = mSrfrResults.WPavgPt2
        _average.Value = AverageWettedPerimeterT2
        _average.Source = ValueSources.Calculated
        mSrfrResults.WPavgPt2 = _average

    End Sub

#End Region

#Region " Automation "

    '*********************************************************************************************************
    ' Function PreAutoRun()     - performs pre-AutoRun functions such as setup error checking
    '
    ' Note - for Elliott-Walker two-point method, also estimate Kostiakov k & a prior to AutoRun()
    '*********************************************************************************************************
    Public Overrides Function PreAutoRun() As Boolean
        EstimateKostiakovKA()                           ' Estimate k & a before check for setup errors
        UpdateSetupErrorsAndWarnings()                  ' Check for setup errors/warnings
        PreAutoRun = Not HasSetupErrors()               ' Setup errors should prevent AutoRun()
    End Function

#End Region

#Region " Two-Point Analyses "
    '
    ' Perfom the Elliott-Walker Two-Point analysis
    '
    Public Sub PerformTwoPointAnalysis()
        '
        ' Get user-entered data
        '
        Dim pt1Dist As Double = mInflowManagement.TwoPointDistance1
        Dim pt1Time As Double = mInflowManagement.TwoPointTime1

        Dim pt2Dist As Double = mInflowManagement.TwoPointDistance2
        Dim pt2Time As Double = mInflowManagement.TwoPointTime2
        '
        ' Perform Two-Point analysis
        '

        ' Average Inflow Flow Rate
        mQavgT1 = mInflowManagement.AverageInflowRateForCrossSection(pt1Time)
        mQavgT2 = mInflowManagement.AverageInflowRateForCrossSection(pt2Time)

        ' Calculate all Upstream Hydraulic Parameters
        Dim W As Double = mSystemGeometry.Width.Value
        S0 = mSystemGeometry.AverageSlope

        Dim Sy1 As Double = mEventCriteria.SurfaceShapeFactor1
        Dim beta1 As Double = mUnit.Beta(Sy1, mQavgT1, pt1Dist, W, S0)

        Me.UpstreamParameters(mQavgT1, pt1Dist, W, S0, mUpstreamDepthT1, mFlowAreaT1, _
                              mHydraulicRadiusT1, mWettedPerimeterT1, mHydraulicGradientT1, beta1)

        Dim Sy2 As Double = mEventCriteria.SurfaceShapeFactor2
        Dim beta2 As Double = mUnit.Beta(Sy2, mQavgT2, pt2Dist, W, S0)

        Me.UpstreamParameters(mQavgT2, pt2Dist, W, S0, mUpstreamDepthT2, mFlowAreaT2, _
                              mHydraulicRadiusT2, mWettedPerimeterT2, mHydraulicGradientT2, beta2)

        ' Shaped Flow Area
        mShapedFlowAreaT1 = mFlowAreaT1 * Sy1
        mShapedFlowAreaT2 = mFlowAreaT2 * Sy2

        ' Inflow - Outflow
        mQavgFinal = mInflowManagement.AverageInflowRateForCrossSection
        mSteadyRO = mInflowManagement.SteadyRunoffRateForCrossSection
        mInOut = mQavgFinal - mSteadyRO

        ' Kostiakov b Estimate
        Me.EstimateKostiakovB()

        ' Water Volumes
        mInflowVolumeT1 = mQavgT1 * pt1Time
        mSurfaceVolumeT1 = mShapedFlowAreaT1 * pt1Dist
        mInfiltratedVolumeT1 = mInflowVolumeT1 - mSurfaceVolumeT1

        mInflowVolumeT2 = mQavgT2 * pt2Time
        mSurfaceVolumeT2 = mShapedFlowAreaT2 * pt2Dist
        mInfiltratedVolumeT2 = mInflowVolumeT2 - mSurfaceVolumeT2

    End Sub

#End Region

#Region " Kostiakov Estimation "
    '
    ' Estimate Kostiaiov b
    '
    Public Function EstimateKostiakovB() As Double
        If (mUnit IsNot Nothing) Then
            '
            ' Get user-entered data
            '
            Dim L As Double = mSystemGeometry.Length.Value
            Dim WP As Double = Me.WettedPerimeter

            ' Kostiakov b Estimate
            mKostiakovB = InOut / L / WP / 2.0
            'mKostiakovB = (InOut * 0.7) / L / WP

            Return mKostiakovB
        End If

        Return 0.0
    End Function
    '
    ' Calculate estimates for Kostiakov k & a using the input Kostiakov b
    '
    Public Sub EstimateKostiakovKA()

        ' Run the Elliott-Walker analysis
        Me.PerformTwoPointAnalysis()
        ' Then estimate Kostiakov k & a using b
        mKostiakovB = mSoilCropProperties.KostiakovB_MK.Value
        Me.EstimateKostiakov()

        ' Save Modified Kostiakov parameters
        Dim infiltrationFunction As IntegerParameter = mSoilCropProperties.InfiltrationFunction
        If Not (infiltrationFunction.Value = InfiltrationFunctions.ModifiedKostiakovFormula) Then
            infiltrationFunction.Value = InfiltrationFunctions.ModifiedKostiakovFormula
            infiltrationFunction.Source = ValueSources.Calculated
            mSoilCropProperties.InfiltrationFunction = infiltrationFunction
        End If

        If (mUnit.CrossSection = CrossSections.Furrow) Then ' save WP for furrows
            Dim wettedPerimeterMethod As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
            If Not (wettedPerimeterMethod.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter) Then
                wettedPerimeterMethod.Value = WettedPerimeterMethods.FurrowSpacing
                wettedPerimeterMethod.Source = ValueSources.Calculated
            End If

            If Not (mSoilCropProperties.WettedPerimeterMethod.Value = wettedPerimeterMethod.Value) Then
                mSoilCropProperties.WettedPerimeterMethod = wettedPerimeterMethod
            End If
        End If

        ' Save the Reference Flow Rate when Modified Kostiakov estimated
        Dim Qavg As Double = mInflowManagement.AverageInflowRateForCrossSection
        Me.SaveReferenceFlowRate(Qavg)

        ' Clear Kostiakov c (do this BEFORE updating a & k)
        Dim c As DoubleParameter = mSoilCropProperties.KostiakovC_MK
        c.Value = 0.0
        c.Source = ValueSources.Calculated
        mSoilCropProperties.KostiakovC_MK = c

        ' Update Kostiakov a & k
        Dim a As DoubleParameter = mSoilCropProperties.KostiakovA_MK
        a.Value = mKostiakovA
        a.Source = ValueSources.Calculated
        mSoilCropProperties.KostiakovA_MK = a

        Dim k As KostiakovKParameter = mSoilCropProperties.KostiakovK_MK
        k.Value = mKostiakovK
        k.Source = ValueSources.Calculated
        mSoilCropProperties.KostiakovK_MK = k

    End Sub

    Public Sub EstimateKostiakov()

        If (mUnit IsNot Nothing) Then
            ' Elliott-Walker requires Kostiakov b in m^2/s units
            Dim WP As Double = Me.WettedPerimeter
            Dim B As Double = mKostiakovB * WP

            ' User-entered data
            Dim L As Double = mSystemGeometry.Length.Value

            Dim pt1Dist As Double = mInflowManagement.TwoPointDistance1
            Dim pt1Time As Double = mInflowManagement.TwoPointTime1

            Dim pt2Dist As Double = mInflowManagement.TwoPointDistance2
            Dim pt2Time As Double = mInflowManagement.TwoPointTime2

            ' Shaped flow area
            Dim shapedFlowAreaT1 As Double = mFlowAreaT1 * mEventCriteria.SurfaceShapeFactor1
            Dim shapedFlowAreaT2 As Double = mFlowAreaT2 * mEventCriteria.SurfaceShapeFactor2

            ' Inflow volume
            Dim inflowVolumeT1 As Double = mQavgT1 * pt1Time
            Dim inflowVolumeT2 As Double = mQavgT2 * pt2Time

            ' Power Advance
            Dim r As Double = Math.Log(pt1Dist / pt2Dist) / Math.Log(pt1Time / pt2Time)
            mPowerAdvanceExponent = r

            Dim p As Double = pt2Dist / (pt2Time ^ r)
            mPowerAdvanceConstant = p

            Dim r1 As Double = (inflowVolumeT1 / pt1Dist) - shapedFlowAreaT1 - ((B * pt1Time) / (r + 1))
            Dim r2 As Double = (inflowVolumeT2 / pt2Dist) - shapedFlowAreaT2 - ((B * pt2Time) / (r + 1))

            ' Kostiakov a
            Dim a As Double = Math.Log(r2 / r1) / Math.Log(pt2Time / pt1Time)
            mKostiakovA = a

            ' SigmaZ1
            Dim sigmaZ1 As Double = (a + r - (r * a) + 1) / ((a + 1) * (r + 1))

            ' Kostiakov k
            Dim k As Double = r2 / (sigmaZ1 * (pt2Time ^ a)) / WP
            mKostiakovK = k
        End If

    End Sub

#End Region

#Region " Reference Flow Rate "

    Protected Sub SaveReferenceFlowRate(ByVal Qref As Double)

        ' Set flag indicating Reference Flow Rate has been set
        Dim setParam As BooleanParameter = mEventCriteria.ReferenceFlowRateSet
        If Not ((setParam.Value = True) _
            And (setParam.Source = ValueSources.Calculated)) Then
            setParam.Value = True
            setParam.Source = ValueSources.Calculated
            mEventCriteria.ReferenceFlowRateSet = setParam
        End If

        ' Save Reference Flow Rate
        Dim refParam As DoubleParameter = mEventCriteria.ReferenceFlowRate
        If Not ((refParam.Value = Qref) _
            And (refParam.Source = ValueSources.Calculated)) Then
            refParam.Value = Qref
            refParam.Source = ValueSources.Calculated
            mEventCriteria.ReferenceFlowRate = refParam
        End If

    End Sub

#End Region

#Region " Volume Balance Table "

    Public Function VolumeBalanceTable() As DataTable

        ' Perform two-point analysis to generate values for the volume balance table
        Me.PerformTwoPointAnalysis()

        ' Initialize volume balance table
        VolumeBalanceTable = New DataTable(mDictionary.tVolumeBalances.Translated)
        mEventCriteria.ResetVolumeBalancesTable(VolumeBalanceTable)
        Dim VBrow As DataRow = Nothing

        ' Move two-point values to the volume balance table
        VBrow = VolumeBalanceTable.NewRow                       ' Point 1
        VBrow.Item(sTimeX) = mInflowManagement.TwoPointTime1
        VBrow.Item(sVin) = mInflowVolumeT1
        VBrow.Item(sVy) = mSurfaceVolumeT1
        VBrow.Item(sVro) = 0.0
        VBrow.Item(sVz) = mInfiltratedVolumeT1
        VolumeBalanceTable.Rows.Add(VBrow)

        VBrow = VolumeBalanceTable.NewRow                       ' Point 2
        VBrow.Item(sTimeX) = mInflowManagement.TwoPointTime2
        VBrow.Item(sVin) = mInflowVolumeT2
        VBrow.Item(sVy) = mSurfaceVolumeT2
        VBrow.Item(sVro) = 0.0
        VBrow.Item(sVz) = mInfiltratedVolumeT2
        VolumeBalanceTable.Rows.Add(VBrow)

    End Function

    Public Overrides Function MeasuredInfiltrationVolumeTable() As DataTable

        ' Define infiltration table
        MeasuredInfiltrationVolumeTable = New DataTable(mDictionary.tMeasuredInfiltration.Translated)
        MeasuredInfiltrationVolumeTable.Columns.Add(sTimeX, GetType(Double))
        MeasuredInfiltrationVolumeTable.Columns.Add(sVz, GetType(Double))

        ' Load its data from the volume balance table (only need T vs. Vz)
        Dim volBalTable As DataTable = Me.VolumeBalanceTable
        If (volBalTable IsNot Nothing) Then
            Dim row As DataRow = MeasuredInfiltrationVolumeTable.NewRow
            row.Item(sTimeX) = volBalTable.Rows(0).Item(sTimeX)
            row.Item(sVz) = volBalTable.Rows(0).Item(sVz)
            MeasuredInfiltrationVolumeTable.Rows.Add(row)

            row = MeasuredInfiltrationVolumeTable.NewRow
            row.Item(sTimeX) = volBalTable.Rows(1).Item(sTimeX)
            row.Item(sVz) = volBalTable.Rows(1).Item(sVz)
            MeasuredInfiltrationVolumeTable.Rows.Add(row)
        End If

    End Function

    Public Overrides Function PredictedInfiltrationVolumeTable( _
               Optional ByVal SrfrInfiltration As Srfr.Infiltration = Nothing) As DataTable
        PredictedInfiltrationVolumeTable = Nothing

        ' Define infiltration table
        PredictedInfiltrationVolumeTable = New DataTable(mDictionary.tPredictedInfiltration.Translated)
        PredictedInfiltrationVolumeTable.Columns.Add(sTimeX, GetType(Double))
        PredictedInfiltrationVolumeTable.Columns.Add(sVz, GetType(Double))

        Dim T1 As Double = mInflowManagement.TwoPointTime1
        Dim T2 As Double = mInflowManagement.TwoPointTime2

        Dim row1 As DataRow = PredictedInfiltrationVolumeTable.NewRow
        row1.Item(sTimeX) = T1
        row1.Item(sVz) = mInfiltratedVolumeT1
        PredictedInfiltrationVolumeTable.Rows.Add(row1)

        Dim row2 As DataRow = PredictedInfiltrationVolumeTable.NewRow
        row2.Item(sTimeX) = T2
        row2.Item(sVz) = mInfiltratedVolumeT2
        PredictedInfiltrationVolumeTable.Rows.Add(row2)

    End Function

#End Region

#Region " Errors & Warnings "

    '*********************************************************************************************************
    ' Function CheckSetupErrors()   - check setup errors for Elliott-Walker Analysis
    ' Function CheckSetupWarnings() -   "     "  warnings "     "      "       "
    '*********************************************************************************************************
    Public Overrides Function CheckSetupErrors() As Boolean
        ' Call to overridden baseclass clears previous errors
        Dim hasErrors As Boolean = MyBase.CheckSetupErrors()

        Dim L As Double = mSystemGeometry.Length.Value
        Dim Tco As Double = mInflowManagement.Cutoff

        CheckGeometryErrors()           ' System Geometry

        CheckRoughnessErrors()          ' Soil / Crop Properties

        CheckInflowErrors()             ' Inflow Management
        CheckRunoffErrors()

        CheckSolutionModelErrors()      ' Solution Model

        ' Verify two-point advance distance values (0 < PT1 < PT2 <= L)
        Dim pt1Dist As Double = mInflowManagement.TwoPointDistance1
        Dim pt2Dist As Double = mInflowManagement.TwoPointDistance2

        If (pt1Dist <= 0.0) Then
            AddSetupError(ErrorFlags.Advance, _
                     mDictionary.tPT1DistLeZeroID.Translated, _
                     mDictionary.tPT1DistLeZeroDetail.Translated)
        End If

        If (L < pt2Dist) Then
            AddSetupError(ErrorFlags.Advance, _
                     mDictionary.tPT2DistGtLengthID.Translated, _
                     mDictionary.tPT2DistGtLengthDetail.Translated)
        End If

        If (pt2Dist <= pt1Dist) Then
            AddSetupError(ErrorFlags.Advance, _
                     mDictionary.tPT1DistGePT2DistID.Translated, _
                     mDictionary.tPT1DistGePT2DistDetail.Translated)
        End If

        ' Verify two-point advance time values (0 < PT1 < PT2 <= Tco)
        Dim pt1Time As Double = mInflowManagement.TwoPointTime1
        Dim pt2Time As Double = mInflowManagement.TwoPointTime2

        If (pt1Time <= 0.0) Then
            AddSetupError(ErrorFlags.Advance, _
                     mDictionary.tPT1TimeLeZeroID.Translated, _
                     mDictionary.tPT1TimeLeZeroDetail.Translated)
        End If

        If (Tco <= pt2Time) Then
            AddSetupError(ErrorFlags.Advance, _
                     mDictionary.tPT2TimeGtCutoffID.Translated, _
                     mDictionary.tPT2TimeGtCutoffDetail.Translated)
        End If

        If (pt2Time <= pt1Time) Then
            AddSetupError(ErrorFlags.Advance, _
                     mDictionary.tPT1TimeGePT2TimeID.Translated, _
                     mDictionary.tPT1TimeGePT2TimeDetail.Translated)
        End If

        ' Runoff & Advance times should align
        If (mInflowManagement.RunoffComplete) Then ' user has entered a 'complete' runoff hydrograph
            If (ThisClose(pt2Dist, L, OneDecimeter)) Then ' Point 2 is at end-of-field (L)

                Dim TL As Double = pt2Time ' Point 2 time is TL

                Dim firstT, lastT, firstQro, lastQro As Double
                Dim runoffOK As Boolean = mInflowManagement.RunoffRange(firstT, firstQro, lastT, lastQro)
                If (runoffOK) Then
                    If Not (ThisClose(firstT, TL, OneMinute)) Then ' Runoff does not start at TL
                        AddSetupError(ErrorFlags.Runoff, _
                                mDictionary.tInvalidRunoffTableID.Translated, _
                                mDictionary.tInvalidRunoffStartTime.Translated)
                    End If
                End If
            End If ' TL specified
        End If ' Complete runoff hydrograph

        ' Verify other user inputs
        If (InOut < 0.0) Then ' Vin < Vout
            AddSetupError(ErrorFlags.Runoff, _
                     mDictionary.tOutflowGtInflowID.Translated, _
                     mDictionary.tOutflowGtInflowDetail.Translated)
        End If

        If (mKostiakovA < 0.0) Then
            AddSetupError(EventAnalysis.ErrorFlags.InvalidKostiakovA, _
                     mDictionary.tInvalidKostiakovAID.Translated, _
                     mDictionary.tInvalidKostiakovADetail.Translated)
        End If

        ' Verify Infiltration Estimations are valid
        Dim kChangedTime As DateTime = mSoilCropProperties.KostiakovK_MK.Timestamp

        If ((mUnit.DataHasChangedSince(kChangedTime)) _
        And (Not mUnit.ResultsAreValid)) Then
            AddSetupError(ErrorFlags.InfiltrationParameters, _
                     mDictionary.tInvalidInfiltrationParametersID.Translated, _
                     mDictionary.tInvalidInfiltrationParametersDetail.Translated)
        Else
            RemoveSetupError(ErrorFlags.InfiltrationParameters, _
                        mDictionary.tInvalidInfiltrationParametersID.Translated, _
                        mDictionary.tInvalidInfiltrationParametersDetail.Translated)
        End If

        hasErrors = Me.HasSetupErrors
        Return hasErrors
    End Function

    Public Overrides Function CheckSetupWarnings() As Boolean
        Dim _hasWarnings As Boolean = MyBase.CheckSetupWarnings()

        If (mUnit IsNot Nothing) Then
            '
            ' Verify Power Advance
            '
            Dim _r As Double = PowerAdvanceExponent

            If (1.0 < _r) Then
                AddSetupWarning(WarningFlags.ExecutionWarning, _
                               mDictionary.tPowerAdvanceExponentGt1ID.Translated, _
                               mDictionary.tPowerAdvanceExponentGt1Detail.Translated)
            End If
            '
            ' Verify Surface volumes
            '
            Dim _inflowVol1 As Double = InflowVolumeT1
            Dim _inflowVol2 As Double = InflowVolumeT2

            Dim _surfaceVol1 As Double = SurfaceVolumeT1
            Dim _surfaceVol2 As Double = SurfaceVolumeT2

            Dim _percent1 As Double = _surfaceVol1 * 100.0 / _inflowVol1
            Dim _percent2 As Double = _surfaceVol2 * 100.0 / _inflowVol2

            If (_percent1 <= _percent2) Then
                AddSetupWarning(WarningFlags.ExecutionWarning, _
                           mDictionary.tVolumeRatioPt2GtPt1ID.Translated, _
                           mDictionary.tVolumeRatioPt2GtPt1Detail.Translated)
            End If
            '
            ' Verify Subsurface Shape Factors
            '
            Dim Sy1 As Double = mEventCriteria.SurfaceShapeFactor1
            Dim Sy2 As Double = mEventCriteria.SurfaceShapeFactor2

            If (1.0 < Sy1) Then
                AddSetupWarning(WarningFlags.ExecutionWarning, _
                                mDictionary.tSubsurfaceShapeFactorGt1ID.Translated, _
                                mDictionary.tSubsurfaceShapeFactorGt1Detail.Translated)
            End If

            If (1.0 < Sy2) Then
                AddSetupWarning(WarningFlags.ExecutionWarning, _
                                mDictionary.tSubsurfaceShapeFactorGt1ID.Translated, _
                                mDictionary.tSubsurfaceShapeFactorGt1Detail.Translated)
            End If

            ' Check infiltration calculations
            Dim inflowComplete As Boolean = mInflowManagement.InflowComplete
            Dim runoffComplete As Boolean = mInflowManagement.RunoffComplete

            If Not (inflowComplete) Then
                AddSetupWarning(WarningFlags.ExecutionWarning, _
                                "", mDictionary.tCannotPredictParameters.Translated)
            End If

            If Not (inflowComplete And runoffComplete) Then
                AddSetupWarning(WarningFlags.VolumeBalanceWarning, _
                                "", mDictionary.tCannotComputeVolumeBalance.Translated)
            End If

        End If

        _hasWarnings = Me.HasSetupWarnings
        Return _hasWarnings
    End Function

#End Region

#End Region

End Class
