
'*************************************************************************************************************
' Class:    FurrowOperations
'
' Desc:     Performs Operations functions for a Furrow Set.
'*************************************************************************************************************
Imports DataStore

Public Class FurrowOperations
    Inherits OperationsAnalysis

#Region " Member Data "

#Region " Furrow Irrigation Data "

    Private mFurrowFlowRate As Double
    Private mFurrowCutbackRate As Double

#End Region

#End Region

#Region " Properties "
    '
    ' The number of distances (points) to calculate for the Advance, Recession, etc. curves
    '
    Protected Overrides ReadOnly Property NumDistances() As Integer
        Get
            If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
                Return 65
            Else
                Return 17
            End If
        End Get
    End Property

#End Region

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
    End Sub

#End Region

#Region " SRFR Adjustments "

    '******************************************************************************************
    ' Adjust SRFR Field Data to match the specific point being analyzed
    '
    ' After the SRFR Field Data has been loaded from the Unit but prior to the SRFR Simulation
    ' being executed, the SRFR Field Data can be modified to meet any special requirements of
    ' the analysis by overriding AdjustSrfrInputs().
    '
    ' NOTE - Srfr Criteria is adjusted in OperationsAnalysis' AdjustSrfrCriteria().
    '
    Public Overrides Sub AdjustSrfrInputs(ByVal unit As Unit)
        If (unit IsNot Nothing) Then
            '
            ' System Geometry adjustments
            '
            SrfrAPI.CrossSection.Length = mLength
            SrfrAPI.CrossSection.BorderWidth = mWidth
            '
            ' Inflow Management adjustments
            '
            If (SrfrAPI.Inflow.GetType Is GetType(Srfr.StandardHydrograph)) Then
                Dim stdHydro As Srfr.StandardHydrograph = DirectCast(SrfrAPI.Inflow, Srfr.StandardHydrograph)
                stdHydro.Q0 = mInflowRate
                stdHydro.Tco = mTco
                stdHydro.RTcb = mTcb / mTco
            End If

        End If
    End Sub

#End Region

#Region " Tuning Factors "

    '*************************************************************************************************************
    ' Estimate the Operations Tuning Factors
    '
    Public Overrides Function EstimateTuningFactors() As Boolean
        Dim ok As Boolean = False

        mSoilCropProperties.SetSrfrInfiltration()

        ok = EstimateTuningFactorsFurrow()

        mSoilCropProperties.ClrSrfrInfiltration()

        Return ok
    End Function

    Protected Function EstimateTuningFactorsFurrow() As Boolean
        Dim ok As Boolean = MyBase.EstimateTuningFactors()

        Me.Running = True

        ' Clear Tuning Point
        Dim _contour As ContourParameter = mPerformanceResults.DesignContour
        _contour.TuningPoint = Nothing
        mPerformanceResults.DesignContour = _contour
        '
        ' Furrow Operations only works for Time-Based Cutoff
        '
        Dim cutoff As IntegerParameter = mInflowManagement.CutoffMethod
        If Not (cutoff.Value = CutoffMethods.TimeBased) Then
            cutoff.Value = CutoffMethods.TimeBased
            cutoff.Source = ValueSources.Calculated
            mInflowManagement.CutoffMethod = cutoff
        End If
        '
        ' Use the selected contour point for estimating tuning factors
        '
        Dim cutoffTime As DoubleParameter = mInflowManagement.CutoffTime
        cutoffTime.Value = mBorderCriteria.ContourCutoffTimePoint.Value
        cutoffTime.Source = mBorderCriteria.ContourCutoffTimePoint.Source
        mInflowManagement.CutoffTime = cutoffTime
        mTco = cutoffTime.Value

        Select Case (mBorderCriteria.OperationsOption.Value)

            Case OperationsOptions.WidthGiven

                mWidth = mSystemGeometry.Width.Value

                ' Inflow Rate set by Tuning Point
                Dim inflowRateParam As DoubleParameter = mInflowManagement.InflowRate
                inflowRateParam.Value = mBorderCriteria.ContourInflowRatePoint.Value
                inflowRateParam.Source = mBorderCriteria.ContourInflowRatePoint.Source
                mInflowManagement.InflowRate = inflowRateParam
                mInflowRate = inflowRateParam.Value

            Case OperationsOptions.InflowRateGiven

                mInflowRate = mInflowManagement.InflowRate.Value

                ' Width set indirectly via Furrows Per Set Tuning Point
                Dim furrowsPerSetParam As DoubleParameter = mSystemGeometry.FurrowsPerSet
                furrowsPerSetParam.Value = mBorderCriteria.ContourFurrowsPerSetPoint.Value
                furrowsPerSetParam.Source = mBorderCriteria.ContourFurrowsPerSetPoint.Source
                mSystemGeometry.FurrowsPerSet = furrowsPerSetParam

                ' Width = Furrows Per Set * Furrow Spacing
                mWidth = furrowsPerSetParam.Value * mSystemGeometry.FurrowSpacing.Value

                ' Save calculated Width also
                Dim widthParam As DoubleParameter = mSystemGeometry.Width
                widthParam.Value = mWidth
                widthParam.Source = mBorderCriteria.ContourFurrowsPerSetPoint.Source
                mSystemGeometry.Width = widthParam

        End Select
        '
        ' Furrow Operations is per furrow; convert field rates to furrow rates
        '
        Dim furrowsPerSet As Double = mWidth / mSystemGeometry.FurrowSpacing.Value
        mFurrowFlowRate = mInflowRate / furrowsPerSet
        mFurrowCutbackRate = mFurrowFlowRate * mInflowManagement.CutbackRateRatio.Value
        '
        ' Get Wetted Perimeter parameters
        '
        Dim Qin As Double = mFurrowFlowRate

        Dim furrowSpacing As Double = mSystemGeometry.FurrowSpacing.Value

        Dim L1 As Double = mLength / 2.0
        Dim Y01, A01, R01, WP01, Sf1 As Double
        Me.UpstreamParameters(Qin, L1, mWidth, S0, Y01, A01, R01, WP01, Sf1)
        Dim V01 As Double = Qin / Y01

        Dim L2 As Double = mLength
        Dim Y02, A02, R02, WP02, Sf2 As Double
        Me.UpstreamParameters(Qin, L2, mWidth, S0, Y02, A02, R02, WP02, Sf2)
        Dim V02 As Double = Qin / Y02

        Dim WP As Double = Me.WettedPerimeter(Qin)

        '*****************************************************************************************************
        ' 1. Compute furrow operations with simplified procedure
        '   a. This estimates Tco for Dreq (i.e. Dmin)
        '   b. This step is performed with an Open End
        '

        ' Get Sigma Y (surface-shape factor)
        Dim sigmaY As DoubleParameter = mBorderCriteria.SigmaY
        sigmaY.Value = Me.SigmaY(mInflowRate, mLength, mWidth, S0)
        sigmaY.Source = ValueSources.Calculated
        mBorderCriteria.SigmaY = sigmaY

        ' Save current Downstream Condition
        mDownstreamValue = mSystemGeometry.DownstreamCondition.Value
        mDownstreamSource = mSystemGeometry.DownstreamCondition.Source

        ' Compute furrow operations with default Tuning Factors & Open End
        Dim phi0 As DoubleParameter = mBorderCriteria.Phi0Furrows
        phi0.Value = DefaultPhi0Furrows
        phi0.Source = ValueSources.Calculated
        mBorderCriteria.Phi0Furrows = phi0

        Dim phi1 As DoubleParameter = mBorderCriteria.Phi1Furrows
        phi1.Value = DefaultPhi1Furrows
        phi1.Source = ValueSources.Calculated
        mBorderCriteria.Phi1Furrows = phi1

        Dim phi2 As DoubleParameter = mBorderCriteria.Phi2Furrows
        phi2.Value = DefaultPhi2Furrows
        phi2.Source = ValueSources.Calculated
        mBorderCriteria.Phi2Furrows = phi2

        Dim phi3 As DoubleParameter = mBorderCriteria.Phi3Furrows
        phi3.Value = DefaultPhi3Furrows
        phi3.Source = ValueSources.Calculated
        mBorderCriteria.Phi3Furrows = phi3

        Dim parameter As IntegerParameter = mSystemGeometry.DownstreamCondition

        If (0.0 < S0) Then
            parameter.Value = DownstreamConditions.OpenEnd
            parameter.Source = ValueSources.Calculated
            mSystemGeometry.DownstreamCondition = parameter
        End If

        ' Compute furrow operations with default Tuning Factors
        Dim point As ContourPoint = OperationsPointVolBal()
        If (point.HasError) Then
            If (point.ErrMsg = mDictionary.tAdvanceRecessionInadequateID.Translated) Then
                Me.DisplayTuningPointBadAdvanceMessage()
            Else
                Me.DisplayTuningPointBadMessage(point.ErrMsg)
            End If

            ' Restore Downstream Condition
            parameter = mSystemGeometry.DownstreamCondition
            parameter.Value = mDownstreamValue
            parameter.Source = mDownstreamSource
            mSystemGeometry.DownstreamCondition = parameter

            Me.Running = False
            Return False
        End If
        '
        ' 2. Run SRFR simulation and determine:
        '   a. Advance time to end of field
        '   b. Recession time at end of field
        '   c. Infiltrated volume
        '
        Dim tlFurrow As Double = Me.AdvanceTimeToEndOfField
        Dim saveTco As Double = mTco

        mTco = tlFurrow * 1.5
        point = OperationsPointVolBal()

        RunSRFR(False, True, True)

        Dim tlSrfr As Double = mSurfaceFlow.AdvanceTimeToEndOfField
        '
        ' 3. Adjust Phi 0 to make Furrow Operations advance match SRFR simulation advance
        '   a. This step is performed with an Open End
        '
        Me.StatusMessage = mDictionary.tEstimatingPhi0.Translated

        ' Use binary search to adjust Phi 0 to match Advance times
        Dim minPhi0 As Double = 0.0
        Dim maxPhi0 As Double = 2.0 / sigmaY.Value

        For iter As Integer = 0 To 25

            ' Get advance from last furrow operations
            tlFurrow = Me.AdvanceTimeToEndOfField

            ' Get current value of Phi 0
            phi0 = mBorderCriteria.Phi0Furrows

            ' Halve the range for Phi 0 binary search
            If (tlSrfr + 0.001 < tlFurrow) Then
                maxPhi0 = phi0.Value                    ' Too large
            ElseIf (tlFurrow < tlSrfr - 0.001) Then
                minPhi0 = phi0.Value                    ' Too small
            Else
                Exit For                                ' Just Right
            End If

            phi0.Value = (minPhi0 + maxPhi0) / 2.0
            phi0.Source = ValueSources.Calculated
            mBorderCriteria.Phi0Furrows = phi0

            ProgressMessage = phi0.Value

            ' Compute furrow operations with mid-range Phi 0
            point = OperationsPointVolBal()
        Next iter

        ' If solution is at limit of binary search; this is an error
        If (maxPhi0 = 2.0 / sigmaY.Value) Then
            Me.DisplayTuningPointBadAdvanceMessage()
            Me.Running = False
            Return False

        Else

            mTco = saveTco
            point = OperationsPointVolBal()

            RunSRFR(False, True, True)

            Dim tcoSrfr As Double = mTco
            tlSrfr = mSurfaceFlow.AdvanceTimeToEndOfField
            Dim trlSrfr As Double = mSurfaceFlow.RecessionAtDistance(mLength)
            Dim trlOper As Double = Me.TRatDistance(mLength, furrowSpacing, WP)
            If (tcoSrfr < trlOper) Then
                trlSrfr = trlOper
            End If
            Dim inVolSrfr As Double = mSubsurfaceFlow.InfiltratedVolume()
            Dim dMinSrfr As Double = mSubsurfaceFlow.Dmin.Value
            Dim tLagSrfr As Double = mSurfaceFlow.RecessionAtDistance(0.0) - tcoSrfr
            tLagSrfr = Me.TRatDistance(0.0, furrowSpacing, WP) - tcoSrfr
            Dim inVolFurrow As Double
            '
            ' 4. Estimate Phi 1 to match recession at end of furrow
            '   a. This step is performed with an Open End
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi1.Translated

            Dim deltaTime As Double = trlSrfr - tcoSrfr
            If (deltaTime < 0.0) Then
                Me.DisplayTuningPointBadAdvanceMessage()
                Me.Running = False
                Return False
            End If

            Dim adjRate As Double = mFurrowFlowRate
            If (mInflowManagement.CutbackMethod.Value = CutbackMethods.TimeBased) Then
                adjRate = ((mFurrowFlowRate * mTcb) + (mFurrowCutbackRate * (mTco - mTcb))) / mTco
            End If

            phi1 = mBorderCriteria.Phi1Furrows
            phi1.Value = (deltaTime * adjRate) / mSurfaceVolume2
            phi1.Source = ValueSources.Calculated
            mBorderCriteria.Phi1Furrows = phi1

            ProgressMessage = phi1.Value

            ' Compute furrow operations with new Phi 1
            point = OperationsPointVolBal()

            ' Rerun SRFR simulation with adjusted Furrow Operations Tco (based on new Phi 1)
            RunSRFR(False, True, True)

            ' This SRFR run is the standard to which Phi 2 is tuned
            tcoSrfr = mTco
            tlSrfr = mSurfaceFlow.AdvanceTimeToEndOfField
            trlSrfr = mSurfaceFlow.RecessionAtDistance(mLength)
            trlOper = Me.TRatDistance(mLength, furrowSpacing, WP)
            If (tcoSrfr < trlOper) Then
                trlSrfr = trlOper
            End If
            inVolSrfr = mSubsurfaceFlow.InfiltratedVolume()
            dMinSrfr = mSubsurfaceFlow.Dmin.Value
            tLagSrfr = mSurfaceFlow.RecessionAtDistance(0.0) - tcoSrfr
            tLagSrfr = Me.TRatDistance(0.0, furrowSpacing, WP) - tcoSrfr
            '
            ' 5. Estimate Phi 2 to match infiltrated volumes
            '   a. This step is performed with an Open End
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi2.Translated

            Dim y0, A0, R0, WP0, Sf As Double
            Me.UpstreamParameters(mFurrowFlowRate, mLength, mWidth, S0, y0, A0, R0, WP0, Sf)

            ' Save Upstream Representative Depth
            Dim upstreamDepth As DoubleParameter = mSurfaceFlow.UpstreamDepth
            upstreamDepth.Value = Y02
            upstreamDepth.Source = ValueSources.Calculated
            mSurfaceFlow.UpstreamDepth = upstreamDepth

            Dim minTr0 As Double = mTco
            Dim maxTr0 As Double = Math.Max(trlSrfr, mTco + (2 * tLagSrfr))

            Dim tr0 As Double = (minTr0 + maxTr0) / 2.0
            Dim trl As Double = trlSrfr

            ' Find straight-line recession to match infiltrated volumes
            For iter As Integer = 0 To 25

                ' Compute new recession curve & resulting infiltration
                '   Use existing Distance & Advance curves
                mRecTimes.Clear()
                mOppTimes.Clear()
                mInfDepths.Clear()

                For idx As Integer = 0 To mDistances.Count - 1
                    Dim X As Double = CDbl(mDistances(idx))
                    Dim Tadv As Double = CDbl(mAdvTimes(idx))

                    Dim Trec As Double = Math.Max(tr0 + ((trl - tr0) * X / mLength), Tadv)
                    Dim Tau As Double = Math.Max(Trec - Tadv, 0)
                    Dim Z As Double = mSoilCropProperties.InfiltrationDepth(Tau)

                    mRecTimes.Add(Trec)
                    mOppTimes.Add(Tau)
                    mInfDepths.Add(Z)
                Next idx

                ' Compute infiltrated volume
                inVolFurrow = 0.0

                For idx As Integer = 1 To mDistances.Count - 1
                    Dim dist1 As Double = CDbl(mDistances(idx - 1))
                    Dim dist2 As Double = CDbl(mDistances(idx))
                    Dim deltaDist As Double = dist2 - dist1

                    Dim infDepth1 As Double = CDbl(mInfDepths(idx - 1))
                    Dim infDepth2 As Double = CDbl(mInfDepths(idx))
                    Dim avgDepth As Double = (infDepth1 + infDepth2) / 2.0

                    Dim infVolume As Double = deltaDist * furrowSpacing * avgDepth

                    inVolFurrow += infVolume
                Next idx

                ' Compare infiltrated volumes
                If (inVolFurrow + 0.00001 < inVolSrfr) Then
                    minTr0 = tr0                            ' Too small
                ElseIf (inVolSrfr < inVolFurrow - 0.00001) Then
                    maxTr0 = tr0                            ' Too large
                Else
                    Exit For                                ' Just right
                End If

                tr0 = (minTr0 + maxTr0) / 2.0
            Next iter

            ' Calculate & save Phi 2
            Dim tlag As Double = tr0 - mTco

            adjRate = mFurrowFlowRate
            If (mInflowManagement.CutbackMethod.Value = CutbackMethods.TimeBased) Then
                adjRate = ((mFurrowFlowRate * mTcb) + (mFurrowCutbackRate * (mTco - mTcb))) / mTco
            End If

            phi2 = mBorderCriteria.Phi2Furrows
            phi2.Value = Math.Max(0, tlag * (2.0 * adjRate) / (A02 * mLength))
            phi2.Source = ValueSources.Calculated
            mBorderCriteria.Phi2Furrows = phi2

            ProgressMessage = phi2.Value
            '
            ' If Furrow is Blocked, estimate Phi 3 to compensate for runoff
            '   a. Use Phi 3 to match SRFR's & Furrow Design's Runoff Volumes
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi3.Translated

            phi3 = mBorderCriteria.Phi3Furrows

            If (mDownstreamValue = DownstreamConditions.BlockedEnd) Then
                If (0.0 < S0) Then
                    parameter = mSystemGeometry.DownstreamCondition
                    parameter.Value = DownstreamConditions.OpenEnd
                    parameter.Source = mDownstreamSource
                    mSystemGeometry.DownstreamCondition = parameter

                    ' Compute furrow opertions with new Phi 2
                    point = OperationsPointVolBal()

                    RunSRFR(False, True, False)

                    phi3.Value = mSurfaceFlow.TabulatedRunoffVolume / mRunoffVolume
                Else
                    phi3.Value = 1.0
                End If
            Else
                phi3.Value = 1.0
            End If

            phi3.Source = ValueSources.Calculated
            mBorderCriteria.Phi3Furrows = phi3

            ProgressMessage = phi3.Value

        End If ' (maxPhi0 = 2.0 / sigmaY.Value)

        ' Restore Downstream Condition
        parameter = mSystemGeometry.DownstreamCondition
        parameter.Value = mDownstreamValue
        parameter.Source = mDownstreamSource
        mSystemGeometry.DownstreamCondition = parameter

        ' Calculate/Save Advance Curve's 'r' value
        Dim p, r As Double
        Dim advTable As DataTable = Me.AdvanceTable
        Dim PandRok As Boolean = AdvancePandR(advTable, p, r)

        Dim _rParam As DoubleParameter = mBorderCriteria.PwrAdvRFurrows
        _rParam.Source = ValueSources.Calculated
        _rParam.Value = r
        mBorderCriteria.PwrAdvRFurrows = _rParam

        ' Validate Advance Curve's 'r' value
        PandRok = ValidateTuningAdvancePandR(PandRok, p, r)

        ' Performance one last SRFR Simulation to verify tuning point is valid
        RunSRFR(False, True, True)

        If (0 < mPerformanceResults.ErrorCount.Value) Then
            Me.DisplayTuningPointBadMessage()
            DisplayErrors()
        Else
            CheckOverflow()
        End If

        ' Save Tuning Point
        _contour = mPerformanceResults.DesignContour
        _contour.TuningPoint = point
        mPerformanceResults.DesignContour = _contour

        ' Check for adequate water application
        Dim Dapp As Double = mSurfaceFlow.DappG.Value
        Dim Dreq As Double = mInflowManagement.RequiredDepth.Value

        If (Dapp < Dreq) Then
            Me.DisplayTuningPointBadAppliedDepthMessage()
            ok = False
        End If

        ProgressMessage = ""

        Me.Running = False
        Return ok
    End Function

#End Region

#Region " Furrow Operations "

    Public Overrides Sub RunOperations(ByVal Method As OperationsMethod)
        Me.StartRun("Furrow Operations", True)

        If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
            '
            ' Width is calculated from the Furrows/Set range
            '
            Dim furrowSpacing As Double = mSystemGeometry.FurrowSpacing.Value

            mMinWidth = Math.Max(Math.Floor(mBorderCriteria.MinContourFurrowsPerSet.Value), 1) * furrowSpacing
            mMaxWidth = Math.Max(Math.Ceiling(mBorderCriteria.MaxContourFurrowsPerSet.Value), mMinWidth + 1) * furrowSpacing
            mWidthRange = mMaxWidth - mMinWidth

            For idx As Integer = 0 To mNumWidths - 1
                mWidths(idx) = mMinWidth + (mWidthRange * (idx / (mNumWidths - 1)))
            Next idx

        End If

        ' Ensure Width is correct
        Dim width As DoubleParameter = mSystemGeometry.Width
        mSystemGeometry.Width = width
        mWidth = width.Value
        '
        ' Build operations contour grid
        '
        mDepthCriterion = mBorderCriteria.InfiltratedDepthCriterion.Value
        If (Method = OperationsMethod.VolumeBalance) Then
            Me.BuildOperationsGridVolBal()
        Else
            mWorldWindow.RemoveSrfrStatusHandler()
            Me.RefineOperationsGridSrfrSim(Method)
            mWorldWindow.AddSrfrStatusHandler()
        End If
        '
        ' Build Dreq = Dmin or Dreq = Dlq curve
        '
        Dim dreq As Double = mInflowManagement.RequiredDepth.Value

        Dim label As String = "Dreq = Dmin = " + mInflowManagement.RequiredDepth.ValueString
        If (mDepthCriterion = InfiltratedDepthCriteria.LowQuarterDepth) Then
            label = "Dreq = Dlq = " + mInflowManagement.RequiredDepth.ValueString
        End If

        If (Method = OperationsMethod.VolumeBalance) Then
            Me.Precision = Globals.ContourPrecision.Precise
        Else
            Me.Precision = Globals.ContourPrecision.Standard
        End If
        Me.BuildValueCurve(label, "Dreq", DLfIndex, dreq, DLfTolerance, Units.Millimeters)
        Me.Precision = Globals.ContourPrecision.Standard
        '
        ' Furrow operations only works for Time-Based Cutoff
        '
        Dim cutoff As IntegerParameter = mInflowManagement.CutoffMethod
        If Not (cutoff.Value = CutoffMethods.TimeBased) Then
            cutoff.Value = CutoffMethods.TimeBased
            cutoff.Source = ValueSources.Calculated
            mInflowManagement.CutoffMethod = cutoff
        End If
        '
        ' Build contour polygons using contour cells as guides
        '
        mContourGrid.ClearContours()

        XTolerance = mCutoffTimeTolerance
        If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
            YTolerance = mWidthTolerance
        Else ' WidthGiven
            YTolerance = mInflowRateTolerance
        End If

        Dim minorContours As Boolean = WinSRFR.UserPreferences.DisplayMinorContours

        ' Application Efficiency (AE) contour polygons
        Me.BuildMajorContours(sApplicationEfficiency, sAE, AeIndex,
                Me.mMajor10PercentValues, AeTolerance, Units.Percentage, True)

        If (minorContours) Then
            Me.BuildMinorContours(sApplicationEfficiency, sAE, AeIndex,
                    Me.mMinor10PercentValues, AeTolerance, Units.Percentage, True)
        End If

        ' Distribution Uniformity contour polygons
        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            ' Minimum Distribution Uniformity (DUmin) contour polygons
            mContourGrid.ValueName(DuIndex) = sMinimumDistributionUniformity
            Me.BuildMajorContours(sMinimumDistributionUniformity, sDUmin, DuIndex,
                    Me.mMajor10PercentValues, DuTolerance, Units.Fraction, True)

            If (minorContours) Then
                Me.BuildMinorContours(sMinimumDistributionUniformity, sDUmin, DuIndex,
                    Me.mMinor10PercentValues, DuTolerance, Units.Fraction, True)
            End If

            ' Adequacy (ADmin) contour polygons
            mContourGrid.ValueName(AdIndex) = sMinimumAdequacy
            Me.BuildMajorContours(sMinimumAdequacy, sADmin, AdIndex,
                    Me.mMajor10PercentValues, ADTolerance, Units.Fraction, True)

            If (minorContours) Then
                Me.BuildMinorContours(sMinimumAdequacy, sADmin, AdIndex,
                        Me.mMinor10PercentValues, ADTolerance, Units.Fraction, True)
            End If
        Else
            ' Low Quarter Distribution Uniformity (DUlq) contour polygons
            mContourGrid.ValueName(DuIndex) = sLowQuarterDistributionUniformity
            Me.BuildMajorContours(sLowQuarterDistributionUniformity, sDUlq, DuIndex,
                    Me.mMajor10PercentValues, DuTolerance, Units.Fraction, True)

            If (minorContours) Then
                Me.BuildMinorContours(sLowQuarterDistributionUniformity, sDUlq, DuIndex,
                    Me.mMinor10PercentValues, DuTolerance, Units.Fraction, True)
            End If

            ' Adequacy (ADlq) contour polygons
            mContourGrid.ValueName(AdIndex) = sLowQuarterAdequacy
            Me.BuildMajorContours(sLowQuarterAdequacy, sADlq, AdIndex,
                    Me.mMajor10PercentValues, ADTolerance, Units.Fraction, True)

            If (minorContours) Then
                Me.BuildMinorContours(sLowQuarterAdequacy, sADlq, AdIndex,
                        Me.mMinor10PercentValues, ADTolerance, Units.Fraction, True)
            End If
        End If

        ' Runoff (RO) contour polygons
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            Me.BuildMajorContours(sRunoff, sRO, RoIndex, Me.mMajor10PercentValues,
                    RoTolerance, Units.Percentage, False)

            If (minorContours) Then
                Me.BuildMinorContours(sRunoff, sRO, RoIndex, Me.mMinor10PercentValues,
                        RoTolerance, Units.Percentage, False)
            End If
        End If

        ' Deep Percolation (DP) contour polygons
        Me.BuildMajorContours(sDeepPercolation, sDP, DpIndex, Me.mMajor10PercentValues,
                DpTolerance, Units.Percentage, False)

        If (minorContours) Then
            Me.BuildMinorContours(sDeepPercolation, sDP, DpIndex, Me.mMinor10PercentValues,
                    DpTolerance, Units.Percentage, False)
        End If

        ' Applied Depth contour polygons
        Me.BuildMajorContours(sAppliedDepth, sDapp, DappIndex, Me.mMajor10LevelDapps,
                DappTolerance, Units.Millimeters, False)

        If (minorContours) Then
            Me.BuildMinorContours(sAppliedDepth, sDapp, DappIndex, Me.mMinor10LevelDapps,
                    DappTolerance, Units.Millimeters, False)
        End If

        ' Infiltrated Depth contour polygons
        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            ' Minimum Depth (Dmin) contour polygons
            mContourGrid.ValueName(DLfIndex) = sMinimumDepth
            Me.BuildMajorContours(sMinimumDepth, sDmin, DLfIndex, Me.mMajor10LevelDlfs,
                    DLfTolerance, Units.Millimeters, False)

            If (minorContours) Then
                Me.BuildMinorContours(sMinimumDepth, sDmin, DLfIndex, Me.mMinor10LevelDlfs,
                        DLfTolerance, Units.Millimeters, False)
            End If
        Else
            ' Low-Quarter Depth (Dlq) contour polygons
            mContourGrid.ValueName(DLfIndex) = sLowQuarterDepth
            Me.BuildMajorContours(sLowQuarterDepth, sDlq, DLfIndex, Me.mMajor10LevelDlfs,
                    DLfTolerance, Units.Millimeters, False)

            If (minorContours) Then
                Me.BuildMinorContours(sLowQuarterDepth, sDlq, DLfIndex, Me.mMinor10LevelDlfs,
                        DLfTolerance, Units.Millimeters, False)
            End If
        End If

        ' Max Advance Time (Txa) contour polygons
        Me.BuildMajorContours(sMaxAdvanceTime, sTxa, TxaIndex, Me.mMajor10TxaValues,
                TxaTolerance, Units.Seconds, False)

        If (minorContours) Then
            Me.BuildMinorContours(sMaxAdvanceTime, sTxa, TxaIndex, Me.mMinor10TxaValues,
                    TxaTolerance, Units.Seconds, False)
        End If

        ' Relative Cutoff (R) contour polygons
        Me.BuildMajorContours(sCutoffRatio, sXR, TcoIndex, Me.mMajor10LevelsRco,
                RcoTolerance, Units.None, False)

        If (minorContours) Then
            Me.BuildMinorContours(sCutoffRatio, sXR, TcoIndex, Me.mMinor10LevelsRco,
                    RcoTolerance, Units.None, False)
        End If

        ' Cutback Ratio
        If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            Me.BuildMajorContours(sCutbackRatio, sCutback, RcoIndex, Me.mMajor10LevelsCutback,
                    CutbackTolerance, Units.None, False)

            If (minorContours) Then
                Me.BuildMinorContours(sCutbackRatio, sCutback, RcoIndex, Me.mMinor10LevelsCutback,
                        CutbackTolerance, Units.None, False)
            End If
        End If

        ' Cost
        Me.BuildMajorContours(sCost, sCost, CostIndex, Me.mMajor10LevelsCost,
                CostTolerance, Units.DollarsPerHectare, False)

        If (minorContours) Then
            Me.BuildMinorContours(sCost, sCost, CostIndex, Me.mMinor10LevelsCost,
                    CostTolerance, Units.DollarsPerHectare, False)
        End If

        ' Save the contour in the DataStore
        Dim eventContour As ContourParameter = mPerformanceResults.DesignContour
        eventContour.Value = mContourGrid
        eventContour.Source = ValueSources.Calculated
        mPerformanceResults.DesignContour = eventContour
        '
        ' Calculate the Solution
        '
        CalculateSolution()

        ' Set all Warning counts to 1
        For Each warning As ErrorWarningItem In Me.ExecutionWarningItems
            warning.Count = 1
        Next warning

        MyBase.EndRun()
    End Sub

#End Region

#Region " Furrow Operations Point - SRFR Simulation "

    '*********************************************************************************************************
    ' Function OperationsPointGridInterpolate() - Compute an Operations Point using Grid Interpolation
    '
    ' Called By:    Calculate Solution      - to simulate the Operations Point at the Solution Point
    '               Estimate Tuning Factors - to simulate the Operations Point at the Tuning Point
    '
    ' Returns:      ContourPoint            - the Operations Point
    '*********************************************************************************************************
    Protected Overloads Overrides Function OperationsPointGridInterpolate() As ContourPoint
        Dim point As ContourPoint = Nothing

        Return point
    End Function

#End Region

#Region " Furrow Operations Point - Volume Balance "

    '*********************************************************************************************************
    ' Compute Furrow Operations Point based on use of Cutback
    '
    Protected Overloads Overrides Function OperationsPointVolBal() As ContourPoint
        Dim point As ContourPoint = Nothing

        Dim cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)

        Select Case (cutoffMethod)
            Case CutoffMethods.DistanceBased
                Debug.Assert(False, "Furrow Operations does not support Distance-Based Cutoff")

            Case Else ' Assume CutoffMethods.TimeBased
                If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                    point = OperationsPointVolBal(mInflowRate, mWidth, mTco, NumWddPoints)
                Else
                    mFurrowCutbackRate = mInflowRate * mCutbackRateRatio
                    point = OperationsPointVolBal(mInflowRate, mWidth, mTco, mFurrowCutbackRate, NumWddPoints)
                End If
        End Select

        Return point
    End Function

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
    '
    ' Function is adapted from Bert Clemmen's Furrow Operations algorithm found FurrowDesign2005.xls
    '*********************************************************************************************************
    Protected Overloads Overrides Function OperationsPointVolBal(ByVal InflowRate As Double,
                                                                 ByVal FurrowSetWidth As Double,
                                                                 ByVal CutoffTime As Double,
                                                                 ByVal NumDistances As Integer) As ContourPoint
        Debug.Assert(0 < InflowRate)
        Debug.Assert(0 < FurrowSetWidth)
        Debug.Assert(0 < CutoffTime)
        Debug.Assert(0 < NumDistances)

        Dim furrowLength As Double = mSystemGeometry.Length.Value           ' Furrow geometry
        Dim furrowSpacing As Double = mSystemGeometry.FurrowSpacing.Value
        Dim furrowsPerSet As Double = FurrowSetWidth / furrowSpacing

        ' Instantiate/initialize SRFR Infiltration object; its used for infiltration calculations
        mSoilCropProperties.SetSrfrInfiltration()
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.Length = furrowLength
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.BorderWidth = FurrowSetWidth
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.FurrowsPerSet = furrowsPerSet
        mSoilCropProperties.SrfrInfiltration.RefInflow.Q0 = InflowRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.Tco = CutoffTime
        mSoilCropProperties.SrfrInfiltration.RefInflow.L = furrowLength

        ' Save Tco & Tcb for Solution calculation
        mTco = CutoffTime
        mTcb = mTco * mCutbackTimeRatio

        '*****************************************************************************************************
        ' Step 1: Get input conditions
        '
        mSigmaY = mBorderCriteria.SigmaY.Value                              ' Tuning factors
        mPhi0 = mBorderCriteria.Phi0Furrows.Value
        mPhi1 = mBorderCriteria.Phi1Furrows.Value
        mPhi2 = mBorderCriteria.Phi2Furrows.Value
        mPhi3 = mBorderCriteria.Phi3Furrows.Value

        mArea = furrowLength * furrowSpacing

        mFurrowFlowRate = InflowRate / furrowsPerSet                        ' Furrow Inflow

        mDepthCriterion = mBorderCriteria.InfiltratedDepthCriterion.Value

        Dim zTolerance As Double = 0.001     ' 0.1%

        Dim Dmax As Double = mSystemGeometry.MaximumDepth.Value

        '*****************************************************************************************************
        ' Step 2: Compute upstream representative depth, flow area & wetted perimeter
        '
        Dim Qin As Double = mFurrowFlowRate

        Dim L1 As Double = furrowLength / 2.0
        Dim Y01, A01, R01, WP01, Sf1 As Double
        Me.UpstreamParameters(Qin, L1, FurrowSetWidth, S0, Y01, A01, R01, WP01, Sf1)
        Dim V01 As Double = mFurrowFlowRate / Y01

        Dim L2 As Double = furrowLength
        Dim Y02, A02, R02, WP02, Sf2 As Double
        Me.UpstreamParameters(Qin, L2, FurrowSetWidth, S0, Y02, A02, R02, WP02, Sf2)
        Dim V02 As Double = mFurrowFlowRate / Y02

        Dim WP As Double = Me.WettedPerimeter(Qin)

        '*****************************************************************************************************
        ' Step 3: Compute 2-point advance
        '
        ComputeTwoPointAdvance(L1, A01, V01, L2, A02, V02, furrowSpacing, WP, Qin, NumDistances)

        '*****************************************************************************************************
        ' Step 4: Compute Performance (w/ Horizontal Recession)
        '   (not supported by WinSRFR)
        '
        mDReq = mInflowManagement.RequiredDepth.Value          ' Inflow requirements
        mTReq = mSoilCropProperties.InfiltrationTime(mDReq, WP, furrowSpacing)

        '*****************************************************************************************************
        ' Step 5: Compute Performance (w/ Adjusted Recession)
        '

        ' Recession time at end of furrow
        mTrL = mTco + (mPhi1 * (mSurfaceVolume2 / mFurrowFlowRate))

        ' Recession lag & recession time at head of furrow
        mTlag = (mPhi2 * A02 * furrowLength) / (2 * mFurrowFlowRate)
        mTr0 = mTco + mTlag

        ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
        ComputeIrrigationCurves(furrowSpacing, InflowRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

        ' Inflow & Infiltrated volume
        mInflowVolume = mFurrowFlowRate * mTco

        ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
        If (mInflowVolume < mInfiltratedVolume) Then
            ' Remove excess infiltration
            Dim excessDepth As Double = (mInfiltratedVolume - mInflowVolume) / mArea

            ' Remove excess depth from top of furrow
            Dim Z As Double = Math.Max(mInfDepths(0) - excessDepth, 0.0)

            If (0.0 < Z) Then
                ' Binary search for depth where Inflow Volume = Infiltrated Volume
                For iter As Integer = 1 To 25

                    Dim oppTime As Double = mSoilCropProperties.InfiltrationTime(Z, WP, furrowSpacing)
                    Dim deltaTime As Double = mOppTimes(0) - oppTime

                    mTr0 -= deltaTime
                    mTrL -= deltaTime

                    ComputeIrrigationCurves(furrowSpacing, InflowRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                    If (mInfiltratedVolume < mInflowVolume - 0.0001) Then
                        Dim deltaVolume As Double = mInflowVolume - mInfiltratedVolume
                        Dim deltaDepth As Double = deltaVolume / mArea
                        Z += deltaDepth
                    ElseIf (mInflowVolume + 0.0001 < mInfiltratedVolume) Then
                        Dim deltaVolume As Double = mInfiltratedVolume - mInflowVolume
                        Dim deltaDepth As Double = deltaVolume / mArea
                        Z -= deltaDepth
                    Else
                        Exit For
                    End If
                Next iter
            End If

            mInfiltratedVolume = mInflowVolume
        End If

        ' Runoff volume
        mRunoffVolume = mPhi3 * Math.Max(mInflowVolume - mInfiltratedVolume, 0)

        '*****************************************************************************************************
        ' Step 6: Adjust for Blocked End, if necessary
        '
        If ((mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) _
        And (0 < mRunoffVolume)) Then
            If (0.0 < S0) Then
                ' Add infiltration due to ponding at end of field
                AddSlopingFieldPond(furrowSpacing, WP, mRunoffVolume, mDMin, mInfiltratedVolume)
            Else ' Slope is level
                ' Compute irrigation curves with added Runoff
                Dim Zro As Double = mRunoffVolume / mArea
                Dim Z As Double = mInfDepths(mInfDepths.Count - 1) + Zro

                For iter As Integer = 1 To 25

                    Dim oppTime As Double = mSoilCropProperties.InfiltrationTime(Z, WP, furrowSpacing)
                    Dim deltaTime As Double = oppTime - mOppTimes(mOppTimes.Count - 1)

                    mTr0 += deltaTime
                    mTrL += deltaTime

                    ComputeIrrigationCurves(furrowSpacing, InflowRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                    If (mInfiltratedVolume < mInflowVolume - 0.0001) Then
                        Dim deltaVolume As Double = mInflowVolume - mInfiltratedVolume
                        Dim deltaDepth As Double = deltaVolume / mArea
                        Z += deltaDepth
                    ElseIf (mInflowVolume + 0.0001 < mInfiltratedVolume) Then
                        Dim deltaVolume As Double = mInfiltratedVolume - mInflowVolume
                        Dim deltaDepth As Double = deltaVolume / mArea
                        Z -= deltaDepth
                    Else
                        Exit For
                    End If
                Next iter
            End If

            ' Blocked End; there is no Runoff
            mInfiltratedVolume = mInflowVolume
            mRunoffVolume = 0
        End If

        '*****************************************************************************************************
        ' Compute & load performance parameters into Contour Point
        '*****************************************************************************************************
        ComputePerformanceParameters(furrowLength, furrowSpacing)

        Dim parameter As SingleParameter
        Dim contourPoint As ContourPoint = New ContourPoint

        ' Move errors & warnings, if any, to Contour Point
        If (S0 < MaximumLevelSlope) Then
            ' Limit Line applies only to Level Furrows
            If (mXR < DesignLimitLine) Then
                AddExecutionWarning(WarningFlags.LimitLineExceeded,
                                    mDictionary.tLimitLineExceededID.Translated,
                                    mDictionary.tLimitLineExceededDetail.Translated)
                contourPoint.HasError = True
                contourPoint.ErrMsg = mDictionary.tLimitLineExceededID.Translated
            End If
        End If

        If ((Double.IsNaN(mTL)) Or (mTL <= 0.0)) Then
            AddExecutionWarning(WarningFlags.AdvanceRecessionInadequate,
                                mDictionary.tAdvanceRecessionInadequateID.Translated,
                                mDictionary.tAdvanceRecessionInadequateDetail.Translated)
            contourPoint.HasError = True
            contourPoint.ErrMsg = mDictionary.tAdvanceRecessionInadequateID.Translated
        End If

        If ((OneWeek <= mOppTimes(0)) Or (OneWeek <= mOppTimes(mOppTimes.Count - 1))) Then
            AddExecutionWarning(WarningFlags.TimeTooLong,
                                mDictionary.tTimeTooLongErrorID.Translated,
                                mDictionary.tTimeTooLongErrorDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tTimeTooLongErrorID.Translated
        End If

        Dim Ymax As Double = Math.Max(Y01, Y02)
        If (Dmax < Ymax) Then
            AddExecutionWarning(WarningFlags.OperationIsInvalid, mDictionary.tOperationNotValidID.Translated, mDictionary.tOperationNotValidDetail.Translated)
            contourPoint.HasError = True
            contourPoint.ErrMsg = mDictionary.tOperationNotValidID.Translated & " - Overflow; Ymax = " & DepthString(Ymax)
        End If

        If (Dmax * 0.9 < Ymax) Then
            AddExecutionWarning(WarningFlags.OperationIsInvalid, mDictionary.tOperationNotRecommendedID.Translated, mDictionary.tOperationNotRecommendedDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tOperationNotRecommendedID.Translated & "; Ymax = " & DepthString(Ymax)
        End If

        ' NOTE - order of Z parameters must match calling function's order
        contourPoint.X = New SingleParameter(CSng(CutoffTime), Units.Seconds)

        If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
            contourPoint.Y = New SingleParameter(CSng(FurrowSetWidth), Units.Meters)
            parameter = New SingleParameter(CSng(InflowRate), Units.Cms)
        Else
            contourPoint.Y = New SingleParameter(CSng(InflowRate), Units.Cms)
            parameter = New SingleParameter(CSng(FurrowSetWidth), Units.Meters)
        End If
        contourPoint.Z.Add(parameter)   ' Inflow Rate or Width

        parameter = New SingleParameter(CSng(mAE), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Application Efficiency

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            parameter = New SingleParameter(CSng(mDUmin), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Distribution Uniformity

            parameter = New SingleParameter(CSng(mADmin), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Adequacy
        Else ' Low-Quarter
            parameter = New SingleParameter(CSng(mDUlq), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Distribution Uniformity

            parameter = New SingleParameter(CSng(mADlq), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Adequacy
        End If

        parameter = New SingleParameter(CSng(mRoFraction), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Runoff

        parameter = New SingleParameter(CSng(mDpFraction), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Deep percolation

        parameter = New SingleParameter(CSng(mDApp), Units.Millimeters)
        contourPoint.Z.Add(parameter)   ' Applied Depth

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            parameter = New SingleParameter(CSng(mDMin), Units.Millimeters)
            contourPoint.Z.Add(parameter)   ' Minimum Depth
        Else
            parameter = New SingleParameter(CSng(mDLf), Units.Millimeters)
            contourPoint.Z.Add(parameter)   ' Low-Fraction Depth
        End If

        parameter = New SingleParameter(CSng(mTxa), Units.Seconds)
        contourPoint.Z.Add(parameter)   ' Maximum Advance time

        parameter = New SingleParameter(CSng(mXR), Units.None)
        contourPoint.Z.Add(parameter)   ' Relative cutoff

        parameter = New SingleParameter(CSng(0), Units.None)
        contourPoint.Z.Add(parameter)   ' Filler (10)

        parameter = New SingleParameter(CSng(0), Units.None)
        contourPoint.Z.Add(parameter)   ' Filler (11)

        parameter = New SingleParameter(CSng(mCost), Units.DollarsPerHectare)
        contourPoint.Z.Add(parameter)   ' Cost

        mSoilCropProperties.ClrSrfrInfiltration()

        Return contourPoint

    End Function

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
    '
    ' Function is adapted from Bert Clemmen's Furrow Operations algorithm found FurrowDesign2005.xls
    '*********************************************************************************************************
    Protected Overloads Overrides Function OperationsPointVolBal(ByVal InflowRate As Double,
                                                                 ByVal FurrowSetWidth As Double,
                                                                 ByVal CutoffTime As Double,
                                                                 ByVal CutbackRate As Double,
                                                                 ByVal NumDistances As Integer) As ContourPoint
        Debug.Assert(0 < InflowRate)
        Debug.Assert(0 < FurrowSetWidth)
        Debug.Assert(0 < CutoffTime)
        Debug.Assert(0 < NumDistances)

        ' If cutback rate is 0.0, use method without cutback
        If (CutbackRate <= 0.0) Then
            Return OperationsPointVolBal(InflowRate, FurrowSetWidth, CutoffTime, NumDistances)
        End If

        Dim furrowLength As Double = mSystemGeometry.Length.Value           ' Furrow geometry
        Dim furrowSpacing As Double = mSystemGeometry.FurrowSpacing.Value
        Dim furrowsPerSet As Double = FurrowSetWidth / furrowSpacing

        ' Instantiate/initialize SRFR Infiltration object; its used for infiltration calculations
        mSoilCropProperties.SetSrfrInfiltration()
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.BorderWidth = FurrowSetWidth
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.FurrowsPerSet = furrowsPerSet
        mSoilCropProperties.SrfrInfiltration.RefInflow.Q0 = InflowRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.Qcb = CutbackRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.Tco = CutoffTime
        mSoilCropProperties.SrfrInfiltration.RefInflow.L = furrowLength

        ' Save Tco for Solution calculation
        mTco = CutoffTime

        '**************************************************************************************
        ' Step 1: Get input conditions
        '
        mSigmaY = mBorderCriteria.SigmaY.Value                              ' Tuning factors
        mPhi0 = mBorderCriteria.Phi0Furrows.Value
        mPhi1 = mBorderCriteria.Phi1Furrows.Value
        mPhi2 = mBorderCriteria.Phi2Furrows.Value
        mPhi3 = mBorderCriteria.Phi3Furrows.Value

        mArea = furrowLength * furrowSpacing

        mFurrowFlowRate = InflowRate / furrowsPerSet                        ' Furrow Inflow
        mFurrowCutbackRate = CutbackRate / furrowsPerSet

        Dim zTolerance As Double = 0.001     ' 0.1%

        '**************************************************************************************
        ' Step 2: Compute upstream depths & flow areas (before & after cutback)
        '
        Dim W As Double = furrowSpacing
        Dim Qin As Double = mFurrowFlowRate
        Dim Qcb As Double = mFurrowCutbackRate

        Dim L1 As Double = furrowLength / 2.0
        Dim Y01, A01, R01, WP01, Sf1 As Double
        Me.UpstreamParameters(Qin, L1, FurrowSetWidth, S0, Y01, A01, R01, WP01, Sf1)
        Dim V01 As Double = Qin / Y01

        Dim L2 As Double = furrowLength
        Dim Y02, A02, R02, WP02, Sf2 As Double
        Me.UpstreamParameters(Qin, L2, FurrowSetWidth, S0, Y02, A02, R02, WP02, Sf2)
        Dim V02 As Double = Qin / Y02

        Dim Y0cb, A0cb, R0cb, WP0cb, Sfcb As Double
        Me.UpstreamParameters(Qcb, L2, FurrowSetWidth, S0, Y0cb, A0cb, R0cb, WP0cb, Sfcb)
        Dim V0cb As Double = Qcb / Y0cb

        Dim WP As Double = Me.WettedPerimeter(Qin)

        '**************************************************************************************
        ' Step 3: Compute 2-point advance
        '
        ComputeTwoPointAdvance(L1, A01, V01, L2, A02, V02, furrowSpacing, WP, Qin, NumDistances)

        '**************************************************************************************
        ' Step 4: Determine cutback time
        '
        mDReq = mInflowManagement.RequiredDepth.Value       ' Infiltration requirements
        mTReq = mSoilCropProperties.InfiltrationTime(mDReq, WP, furrowSpacing)

        mTrL = mTReq + mAdvanceTime2           ' Cutoff time

        zTolerance = 0.0000000001
        Dim minCutbackTime As Double = mAdvanceTime2
        Dim maxCutbackTime As Double = Math.Max(mTco, mTrL)
        Dim estCutbackTime As Double = (minCutbackTime + maxCutbackTime) / 2
        Dim reqAvgInfRate As Double = mFurrowCutbackRate / mArea

        Dim infRates As ArrayList = New ArrayList

        Try
            ' Binary search for cutback time
            For iter As Integer = 1 To 25

                ' Compute irrigation curves
                mRecTimes.Clear()
                mOppTimes.Clear()
                infRates.Clear()

                For idx As Integer = 0 To NumDistances - 1
                    Dim Tadv As Double = mAdvTimes(idx)
                    Dim Trec As Double = Math.Max(estCutbackTime, Tadv)
                    Dim Tau As Double = Trec - Tadv
                    Dim dZdT As Double = mSoilCropProperties.InfiltrationRate(Tau)

                    mRecTimes.Add(Trec)
                    mOppTimes.Add(Tau)
                    infRates.Add(dZdT)
                Next idx

                ' Compute average flow rate using integration
                Dim intFlowRate As Double = 0.0

                Dim dist1 As Double = CDbl(mDistances(0))
                Dim dist2 As Double = CDbl(mDistances(1))
                Dim deltaDist As Double = dist2 - dist1

                Dim infRate1 As Double = CDbl(infRates(0))
                For idx As Integer = 1 To NumDistances - 1
                    Dim infRate2 As Double = CDbl(infRates(idx))
                    Dim avgRate As Double = (infRate1 + infRate2) / 2.0

                    intFlowRate += avgRate

                    infRate1 = infRate2
                Next idx

                intFlowRate *= deltaDist * furrowSpacing

                Dim avgInfRate As Double = intFlowRate / mArea
                Dim infRateErr As Double = avgInfRate - reqAvgInfRate

                ' Is Infiltration Rate close enough?
                If (zTolerance < infRateErr) Then
                    minCutbackTime = estCutbackTime     ' Too small
                ElseIf (infRateErr < -zTolerance) Then
                    maxCutbackTime = estCutbackTime     ' Too large
                Else
                    Exit For                            ' Just right
                End If

                estCutbackTime = (minCutbackTime + maxCutbackTime) / 2

                ' Is this close enough?
                If (ThisClose(minCutbackTime, maxCutbackTime, TenSeconds)) Then
                    Exit For
                End If

            Next iter
        Catch ex As Exception
            Return Nothing
        End Try

        '**************************************************************************************
        ' Step 5: Compute Performance (w/ Horizontal Recession)
        '   (not supported by WinSRFR)
        '

        '**************************************************************************************
        ' Step 6: Compute Performance (w/ Adjusted Recession)
        '
        Dim adjSurfaceVolume As Double = (mSigmaY * mPhi0) * A0cb * furrowLength
        mTcb = estCutbackTime - ((mSurfaceVolume2 - adjSurfaceVolume) / (mFurrowFlowRate - mFurrowCutbackRate))

        ' Cutback time is limited by Cutoff time
        If (mTcb > mTco) Then
            mTcb = mTco
        End If

        ' Compute Inflow Volume
        mInflowVolume = mFurrowFlowRate * mTcb + mFurrowCutbackRate * (mTco - mTcb)

        Dim adjRate As Double = ((mFurrowFlowRate * mTcb) + (mFurrowCutbackRate * (mTco - mTcb))) / mTco

        ' Recession lag & recession time at head of furrow
        mTlag = (mPhi2 * A02 * furrowLength) / (2 * adjRate)
        mTr0 = mTco + mTlag
        If (S0 <= 0.0) Then
            mTr0 = mTco + mTlag
        End If

        ' Recession time at end of furrow
        mTrL = mTco + (mPhi1 * (mSurfaceVolume2 / adjRate))

        ' Compute irrigation curves
        ComputeIrrigationCurves(furrowSpacing, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

        ' Inflow & Runoff volumes
        mInflowVolume = mFurrowFlowRate * mTcb + mFurrowCutbackRate * (mTco - mTcb)

        ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
        If (mInflowVolume < mInfiltratedVolume) Then
            ' Remove excess infiltration
            Dim excessDepth As Double = (mInfiltratedVolume - mInflowVolume) / mArea

            ' Remove excess depth from top of furrow
            Dim Z As Double = Math.Max(mInfDepths(0) - excessDepth, 0.0)

            If (0.0 < Z) Then
                ' Binary search for depth where Inflow Volume = Infiltrated Volume
                For iter As Integer = 1 To 25

                    Dim oppTime As Double = mSoilCropProperties.InfiltrationTime(Z, WP, furrowSpacing)
                    Dim deltaTime As Double = mOppTimes(0) - oppTime

                    mTr0 -= deltaTime
                    mTrL -= deltaTime

                    ComputeIrrigationCurves(furrowSpacing, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                    If (mInfiltratedVolume < mInflowVolume - 0.0001) Then
                        Dim deltaVolume As Double = mInflowVolume - mInfiltratedVolume
                        Dim deltaDepth As Double = deltaVolume / mArea
                        Z += deltaDepth
                    ElseIf (mInflowVolume + 0.0001 < mInfiltratedVolume) Then
                        Dim deltaVolume As Double = mInfiltratedVolume - mInflowVolume
                        Dim deltaDepth As Double = deltaVolume / mArea
                        Z -= deltaDepth
                    Else
                        Exit For
                    End If
                Next iter
            End If

            mInfiltratedVolume = mInflowVolume
        End If

        mRunoffVolume = Math.Max(mInflowVolume - mInfiltratedVolume, 0)

        '**************************************************************************************
        ' Step 7 - Adjust for Blocked End, if necessary
        '
        If ((mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) _
        And (0 < mRunoffVolume)) Then
            If (0.0 < S0) Then

                ' Add infiltration due to ponding at end of field
                AddSlopingFieldPond(furrowSpacing, WP, mRunoffVolume, mDMin, mInfiltratedVolume)

            Else ' Slope is level
                ' Compute irrigation curves with added Runoff
                Dim runoffDepth As Double = mRunoffVolume / mArea
                Dim Z As Double = mInfDepths(mInfDepths.Count - 1) + runoffDepth

                For iter As Integer = 1 To 25

                    Dim Tau As Double = mSoilCropProperties.InfiltrationTime(Z, WP, furrowSpacing)
                    Dim DT As Double = Tau - mOppTimes(mOppTimes.Count - 1)

                    mTr0 += DT
                    mTrL += DT

                    ComputeIrrigationCurves(furrowSpacing, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                    If (mInfiltratedVolume < mInflowVolume - 0.0001) Then
                        Dim deltaVolume As Double = mInflowVolume - mInfiltratedVolume
                        Dim deltaDepth As Double = deltaVolume / mArea
                        Z += deltaDepth
                    ElseIf (mInflowVolume + 0.0001 < mInfiltratedVolume) Then
                        Dim deltaVolume As Double = mInfiltratedVolume - mInflowVolume
                        Dim deltaDepth As Double = deltaVolume / mArea
                        Z -= deltaDepth
                    Else
                        Exit For
                    End If
                Next iter
            End If

            ' Blocked End; there is no Runoff
            mInfiltratedVolume = mInflowVolume
            mRunoffVolume = 0
        End If

        '**************************************************************************************
        ' Compute & load performance parameters into Contour Point
        '**************************************************************************************
        ComputePerformanceParameters(furrowLength, furrowSpacing)

        Dim parameter As SingleParameter
        Dim contourPoint As ContourPoint = New ContourPoint

        ' Move errors & warnings, if any, to Contour Point
        If (S0 < MaximumLevelSlope) Then
            ' Limit Line applies only to Level Furrows
            If (mXR < DesignLimitLine) Then
                AddExecutionWarning(WarningFlags.LimitLineExceeded,
                                    mDictionary.tLimitLineExceededID.Translated,
                                    mDictionary.tLimitLineExceededDetail.Translated)
                contourPoint.HasError = True
                contourPoint.ErrMsg = mDictionary.tLimitLineExceededID.Translated
            End If
        End If

        If ((Double.IsNaN(mTL)) Or (mTL <= 0.0)) Then
            AddExecutionWarning(WarningFlags.AdvanceRecessionInadequate,
                                mDictionary.tAdvanceRecessionInadequateID.Translated,
                                mDictionary.tAdvanceRecessionInadequateDetail.Translated)
            contourPoint.HasError = True
            contourPoint.ErrMsg = mDictionary.tAdvanceRecessionInadequateID.Translated
        End If

        If ((OneWeek <= mOppTimes(0)) Or (OneWeek <= mOppTimes(mOppTimes.Count - 1))) Then
            AddExecutionWarning(WarningFlags.TimeTooLong,
                                mDictionary.tTimeTooLongErrorID.Translated,
                                mDictionary.tTimeTooLongErrorDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tTimeTooLongErrorID.Translated
        End If

        If (mTcb > mTco - 0.1) Then
            mTcb = mTco
            AddExecutionWarning(WarningFlags.TcbLimitedToTco,
                                mDictionary.tTcbLimitedToTcoID.Translated,
                                mDictionary.tTcbLimitedToTcoDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tTcbLimitedToTcoID.Translated
        End If

        ' NOTE - order of Z parameters must match calling function's order
        contourPoint.X = New SingleParameter(CSng(mTco), Units.Seconds)

        If (mBorderCriteria.OperationsOption.Value = OperationsOptions.InflowRateGiven) Then
            contourPoint.Y = New SingleParameter(CSng(FurrowSetWidth), Units.Meters)
            parameter = New SingleParameter(CSng(InflowRate), Units.Cms)
        Else
            contourPoint.Y = New SingleParameter(CSng(InflowRate), Units.Cms)
            parameter = New SingleParameter(CSng(FurrowSetWidth), Units.Meters)
        End If
        contourPoint.Z.Add(parameter)   ' Inflow Rate or Width

        parameter = New SingleParameter(CSng(mAE), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Application Efficiency

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            parameter = New SingleParameter(CSng(mDUmin), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Distribution Uniformity

            parameter = New SingleParameter(CSng(mADmin), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Adequacy
        Else ' Low-Quarter
            parameter = New SingleParameter(CSng(mDUlq), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Distribution uniformity

            parameter = New SingleParameter(CSng(mADlq), Units.Fraction)
            contourPoint.Z.Add(parameter)   ' Adequacy
        End If

        parameter = New SingleParameter(CSng(mRoFraction), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Runoff

        parameter = New SingleParameter(CSng(mDpFraction), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Deep percolation

        parameter = New SingleParameter(CSng(mDApp), Units.Millimeters)
        contourPoint.Z.Add(parameter)   ' Applied Depth

        If (mDepthCriterion = InfiltratedDepthCriteria.MinimumDepth) Then
            parameter = New SingleParameter(CSng(mDMin), Units.Millimeters)
            contourPoint.Z.Add(parameter)   ' Minimum Depth
        Else
            parameter = New SingleParameter(CSng(mDLf), Units.Millimeters)
            contourPoint.Z.Add(parameter)   ' Low-Fraction Depth
        End If

        parameter = New SingleParameter(CSng(mTxa), Units.Seconds)
        contourPoint.Z.Add(parameter)   ' Maximum Advance time

        parameter = New SingleParameter(CSng(mXR), Units.None)
        contourPoint.Z.Add(parameter)   ' Relative cutoff

        parameter = New SingleParameter(CSng(mTcb / mTco), Units.None)
        contourPoint.Z.Add(parameter)   ' Relative cutback

        parameter = New SingleParameter(CSng(0), Units.None)
        contourPoint.Z.Add(parameter)   ' Filler (11)

        parameter = New SingleParameter(CSng(mCost), Units.DollarsPerHectare)
        contourPoint.Z.Add(parameter)   ' Cost

        mSoilCropProperties.ClrSrfrInfiltration()

        Return contourPoint

    End Function

#End Region

#Region " Solution "

    '******************************************************************************************
    ' CalculateSolution() - calculate the solution for the current user values
    '
    Public Overrides Sub CalculateSolution()

        ' Furrow Operations is per furrow; convert field rates to furrow rates
        mFurrowFlowRate = mInflowManagement.InflowRate.Value / mSystemGeometry.FurrowsPerSet.Value
        mFurrowCutbackRate = mFurrowFlowRate * mInflowManagement.CutbackRateRatio.Value

        ' Calculate the Solution's Operations Point
        MyBase.CalculateSolution()

        ' Run a SRFR comparison
        VerifySrfrParameters(CellDensities.Medium)
        RunSRFR(True, False, False)

        ' Display then Clear any SRFR Execution Errors
        DisplayErrors()
        ClearExecutionErrors()

        ' Save Operations Point results (overwites SRFR results)
        SaveSolution()
    End Sub

    Protected Overrides Sub SaveSolution()
        ' Save parameters common to all operations analyses
        MyBase.SaveSolution()

        ' Inflow / Runoff curves
        Dim hydrographs As DataTableParameter = mSurfaceFlow.FlowHydrographs
        Dim inflowTable As DataTable = mInflowManagement.HydrographInflowTable(mFurrowFlowRate, mTco, _
                                                                               mFurrowCutbackRate, mTcb)
        hydrographs.Value = inflowTable
        hydrographs.Source = ValueSources.Calculated
        mSurfaceFlow.FlowHydrographs = hydrographs
    End Sub

#End Region

#Region " Errors & Warnings "
    '
    ' Extended check of setup errors and warnings for Operations Analysis
    '
    Public Overrides Sub UpdateSetupErrorsAndWarnings()
        MyBase.UpdateSetupErrorsAndWarnings()
        CheckContourCriteriaErrors()
    End Sub

    Public Overrides Sub CheckInflowErrors()
        MyBase.CheckInflowErrors()

        ' Only Time-Based Cutoff is supported
        If Not (mInflowManagement.CutoffMethod.Value = CutoffMethods.TimeBased) Then
            AddSetupError(ErrorFlags.CutoffOptionNotSupported, _
                     mDictionary.tCutoffOptionNotSupportID.Translated, _
                     mDictionary.tCutoffOptionNotSupportDetails.Translated)
        End If

        If Not (mSoilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.FurrowSpacing) Then
            If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                AddSetupError(ErrorFlags.CutbackNotSupported, _
                         mDictionary.tCutbackNotSupportedID.Translated, _
                         mDictionary.tCutbackFurrowNotSupportedDetails.Translated)
            End If
        End If
    End Sub

    Public Overrides Sub CheckContourCriteriaErrors()
        MyBase.CheckContourCriteriaErrors()

        ' Tuning Factors must not be default values
        If ((mBorderCriteria.Phi0Furrows.Source = ValueSources.Defaulted) _
         Or (mBorderCriteria.Phi1Furrows.Source = ValueSources.Defaulted) _
         Or (mBorderCriteria.Phi2Furrows.Source = ValueSources.Defaulted) _
         Or (mBorderCriteria.Phi3Furrows.Source = ValueSources.Defaulted)) Then
            AddSetupWarning(WarningFlags.DefaultTuningFactors, _
                       mDictionary.tDefaultTuningFactorsID.Translated, _
                       mDictionary.tDefaultTuningFactorsDetails.Translated)
        End If

    End Sub

#End Region

End Class
