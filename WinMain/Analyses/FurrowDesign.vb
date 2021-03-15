
'*************************************************************************************************************
' Class:    FurrowDesign
'
' Desc:     Design functions for a Furrow Set
'*************************************************************************************************************
Imports Srfr.SrfrAPI
Imports DataStore

Public Class FurrowDesign
    Inherits DesignAnalysis

#Region " Member Data "

#Region " Irrigation Data "

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

    '*********************************************************************************************************
    ' Adjust SRFR Field Data to match the specific point being analyzed
    '
    ' After the SRFR Field Data has been loaded from the Unit but prior to the SRFR Simulation
    ' being executed, the SRFR Field Data can be modified to meet any special requirements of
    ' the analysis by overriding AdjustSrfrInputs().
    '
    ' NOTE - Srfr Criteria is adjusted in DesignAnalysis' AdjustSrfrCriteria().
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

    '******************************************************************************************
    ' Estimate Furrow Design Tuning Factors
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
        ' Furrow design only works for Time-Based Cutoff
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
        Dim length As DoubleParameter = mSystemGeometry.Length
        length.Value = mBorderCriteria.ContourLengthPoint.Value
        length.Source = mBorderCriteria.ContourLengthPoint.Source
        mSystemGeometry.Length = length
        mLength = length.Value

        ' Contour's Y-axis based on the user selected Design Option
        Dim furrowSpacing As Double = mSystemGeometry.FurrowSpacing.Value

        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            ' Inflow Rate given; contour is Length (X) vs. Width (Y)
            Dim widthPoint As Double = mBorderCriteria.ContourWidthPoint.Value

            Dim furrowsPerSetParam As DoubleParameter = mSystemGeometry.FurrowsPerSet
            furrowsPerSetParam.Value = Math.Max(CInt(widthPoint / furrowSpacing), 1.0)
            furrowsPerSetParam.Source = mBorderCriteria.ContourWidthPoint.Source
            mSystemGeometry.FurrowsPerSet = furrowsPerSetParam

            Dim widthParam As DoubleParameter = mSystemGeometry.Width
            widthParam.Value = furrowSpacing * furrowsPerSetParam.Value
            widthParam.Source = mBorderCriteria.ContourWidthPoint.Source
            mSystemGeometry.Width = widthParam
            mWidth = widthParam.Value

        Else
            ' Ensure width is correct for furrow set
            Dim widthParam As DoubleParameter = mSystemGeometry.Width
            mSystemGeometry.Width = widthParam
            mWidth = widthParam.Value

            ' Width given; contour is Length (X) vs. Inflow Rate (Y)
            Dim inflowRateParam As DoubleParameter = mInflowManagement.InflowRate
            inflowRateParam.Value = mBorderCriteria.ContourInflowRatePoint.Value
            inflowRateParam.Source = mBorderCriteria.ContourInflowRatePoint.Source
            mInflowManagement.InflowRate = inflowRateParam
            mInflowRate = inflowRateParam.Value
        End If
        '
        ' Furrow Design is per furrow; convert field rates to furrow rates
        '
        Dim furrowsPerSet As Double = mWidth / mSystemGeometry.FurrowSpacing.Value
        mFurrowFlowRate = mInflowRate / furrowsPerSet
        mFurrowCutbackRate = mFurrowFlowRate * mInflowManagement.CutbackRateRatio.Value
        '
        ' Get Wetted Perimeter parameters
        '
        Dim Qin As Double = mFurrowFlowRate

        Dim L As Double = mLength
        Dim Y0, A0, R0, WP0, Sf As Double
        Me.UpstreamParameters(Qin, L, mWidth, S0, Y0, A0, R0, WP0, Sf)

        Dim WP As Double = Me.WettedPerimeter(Qin)

        '*****************************************************************************************************
        ' 1. Compute furrow design with simplified procedure
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

        ' Compute furrow design with default Tuning Factors & Open End
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

        ' Compute furrow design with default Tuning Factors
        Dim point As ContourPoint = DesignPoint()

        If (point.HasError) Then
            If Not (point.ErrMsg = mDictionary.tDesignNotRecommendedID.Translated) Then
                Dim title As String = mDictionary.tTuningError.Translated
                Dim msg As String

                msg = mDictionary.tTuningFactorsCalculationFailed.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tError.Translated & ": " + point.ErrMsg
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tToCorrectErrorDo.Translated
                msg += Chr(13)
                msg += Chr(13) + "1) " & mDictionary.tIncreaseInflowRate.Translated
                msg += Chr(13) + "2) " & mDictionary.tDecreaseLength.Translated
                msg += Chr(13) + "3) " & mDictionary.tDecreaseWidth.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tAdditionalErrorMessagesMayFollow.Translated

                MsgBox(msg, MsgBoxStyle.Exclamation, title)

                ' Restore Downstream Condition
                parameter = mSystemGeometry.DownstreamCondition
                parameter.Value = mDownstreamValue
                parameter.Source = mDownstreamSource
                mSystemGeometry.DownstreamCondition = parameter

                Me.Running = False
                Return False
            End If
        End If
        '
        ' 2. Run SRFR simulation and determine:
        '   a. Advance time to end of field
        '   b. Recession time at end of field
        '   c. Infiltrated volume
        '
        RunSRFR(False, True, True)

        Dim tcoSrfr As Double = mTco
        Dim tlSrfr As Double = mSurfaceFlow.AdvanceTimeToEndOfField
        Dim trlSrfr As Double = mSurfaceFlow.RecessionAtDistance(mLength)
        Dim trlDsgn As Double = Me.TRatDistance(mLength, furrowSpacing, WP)
        If (tcoSrfr < trlDsgn) Then
            trlSrfr = trlDsgn
        End If
        Dim inVolSrfr As Double = mSubsurfaceFlow.InfiltratedVolume()
        Dim dMinSrfr As Double = mSubsurfaceFlow.Dmin.Value
        Dim tLagSrfr As Double = mSurfaceFlow.RecessionAtDistance(0.0) - tcoSrfr
        tLagSrfr = Me.TRatDistance(0.0, furrowSpacing, WP) - tcoSrfr
        Dim tlFurrow As Double
        '
        ' 3. Adjust Phi 0 to make Furrow Design advance match SRFR simulation advance
        '   a. This step is performed with an Open End
        '
        Me.StatusMessage = mDictionary.tEstimatingPhi0.Translated

        ' Use binary search to match Phi 0 values
        Dim minPhi0 As Double = 0.0
        Dim maxPhi0 As Double = 2.0 / sigmaY.Value

        For iter As Integer = 0 To 20

            ' Get advance from last furrow design
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

            ' Compute furrow design with mid-range Phi 0
            point = DesignPoint()
        Next iter

        ' If solution is at limit of binary search; this is an error
        If (maxPhi0 = 2.0 / sigmaY.Value) Then
            Dim title As String = mDictionary.tTuningError.Translated
            Dim msg As String

            msg = mDictionary.tTuningFactorsCalculationFailed.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tCannotBeMatchedToSimulation.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tToCorrectErrorDo.Translated
            msg += Chr(13)
            msg += Chr(13) + "1) " & mDictionary.tIncreaseInflowRate.Translated
            msg += Chr(13) + "2) " & mDictionary.tDecreaseLength.Translated
            msg += Chr(13)

            MsgBox(msg, MsgBoxStyle.Exclamation, title)

            ' Restore Downstream Condition
            parameter = mSystemGeometry.DownstreamCondition
            parameter.Value = mDownstreamValue
            parameter.Source = mDownstreamSource
            mSystemGeometry.DownstreamCondition = parameter

            Me.Running = False
            Return False
        Else
            '
            ' 4. Estimate Phi 1 to match recession at end of furrow
            '   a. This step is performed with an Open End
            '
            ' Note - There is a circular dependency problem estimating Phi 1:
            '
            '       Phi 1 is based on the recession at the end of the furrow
            '       Phi 1 is used to adjust Tco
            '       Adjusting Tco changes the recession at the end of the furrow
            '
            '   Repeated estimations, using the previous Phi 1 / Tco values, do not converge
            '   but oscillate around the desired value.
            '
            '   A good final estimation for Phi 1 is the average of the 2nd & 3rd estimations.
            '
            Dim adjRate As Double = mFurrowFlowRate

            For iter As Integer = 1 To 3
                Me.StatusMessage = mDictionary.tEstimatingPhi1.Translated

                Dim deltaTime As Double = trlSrfr - tcoSrfr

                If (deltaTime < 0.0) Then
                    Dim title As String = mDictionary.tTuningError.Translated
                    Dim msg As String

                    msg = mDictionary.tTuningFactorsCalculationFailed.Translated
                    msg += Chr(13)
                    msg += Chr(13) + mDictionary.tAdvanceDidNotReachEndOfField.Translated
                    msg += Chr(13)
                    msg += Chr(13) + mDictionary.tToCorrectErrorDo.Translated
                    msg += Chr(13)
                    msg += Chr(13) + "1) " & mDictionary.tIncreaseInflowRate.Translated
                    msg += Chr(13) + "2) " & mDictionary.tDecreaseLength.Translated
                    msg += Chr(13)

                    MsgBox(msg, MsgBoxStyle.Exclamation, title)

                    ' Restore Downstream Condition
                    parameter = mSystemGeometry.DownstreamCondition
                    parameter.Value = mDownstreamValue
                    parameter.Source = mDownstreamSource
                    mSystemGeometry.DownstreamCondition = parameter

                    Me.Running = False
                    Return False
                End If

                If (mInflowManagement.CutbackMethod.Value = CutbackMethods.TimeBased) Then
                    adjRate = ((mFurrowFlowRate * mTcb) + (mFurrowCutbackRate * (mTco - mTcb))) / mTco
                End If

                ' The final Phi 1 gets the average of the last two iterations
                phi1 = mBorderCriteria.Phi1Furrows
                If (iter < 3) Then ' Iterations 1 & 2
                    phi1.Value = (deltaTime * adjRate) / mSurfaceVolume2
                Else ' Iteration 3
                    phi1.Value += (deltaTime * adjRate) / mSurfaceVolume2
                    phi1.Value /= 2.0
                End If
                phi1.Source = ValueSources.Calculated
                mBorderCriteria.Phi1Furrows = phi1

                ProgressMessage = phi1.Value

                ' Compute furrow design with new Phi 1; results in new Tco
                point = DesignPoint()

                ' Rerun SRFR simulation with adjusted Furrow Design Tco (based on new Phi 1)
                RunSRFR(False, True, True)

                ' This SRFR run is the standard to which Phi 2 is tuned
                tlSrfr = mSurfaceFlow.AdvanceTimeToEndOfField
                trlSrfr = mSurfaceFlow.RecessionAtDistance(mLength)
                trlDsgn = Me.TRatDistance(mLength, furrowSpacing, WP)
                If (tcoSrfr < trlDsgn) Then
                    trlSrfr = trlDsgn
                End If
                inVolSrfr = mSubsurfaceFlow.InfiltratedVolume()
                dMinSrfr = mSubsurfaceFlow.Dmin.Value
                tcoSrfr = mTco
                tLagSrfr = mSurfaceFlow.RecessionAtDistance(0.0) - tcoSrfr
                tLagSrfr = Me.TRatDistance(0.0, furrowSpacing, WP) - tcoSrfr

                If (phi1.Value < 1.0) Then
                    Exit For
                End If
            Next iter
            '
            ' 5. Estimate Phi 2 to match infiltrated volumes
            '   a. This step is performed with an Open End
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi2.Translated

            ' Save Upstream Representative Depth
            Dim upstreamDepth As DoubleParameter = mSurfaceFlow.UpstreamDepth
            upstreamDepth.Value = Y0
            upstreamDepth.Source = ValueSources.Calculated
            mSurfaceFlow.UpstreamDepth = upstreamDepth

            Dim minTr0 As Double = mTco
            Dim maxTr0 As Double = Math.Max(trlSrfr, mTco + (2 * tLagSrfr))

            Dim tr0 As Double = (minTr0 + maxTr0) / 2.0
            Dim trl As Double = trlSrfr

            ' Find straight-line recession to match infiltrated volumes
            For iter As Integer = 0 To 20

                ' Compute new recession/opportunity time curves & resulting infiltration curve
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
                Dim inVolFurrow As Double = InfiltratedVolume(furrowSpacing)

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
            phi2.Value = Math.Max(0, tlag * (2.0 * adjRate) / (A0 * mLength))
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

                    ' Compute furrow design with new Phi 2
                    point = DesignPoint()

                    RunSRFR(False, True, False)

                    If (0.0 < mRunoffVolume) Then
                        phi3.Value = mSurfaceFlow.TabulatedRunoffVolume / mRunoffVolume
                    Else
                        phi3.Value = 1.0
                    End If
                Else
                    phi3.Value = 1.0
                End If
            Else
                phi3.Value = 1.0
            End If

            phi3.Source = ValueSources.Calculated
            mBorderCriteria.Phi3Furrows = phi3

            ProgressMessage = phi3.Value
        End If

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
            Dim title As String = mDictionary.tTuningError.Translated
            Dim msg As String

            msg = mDictionary.tSimulationFailedAtTuningPoint.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tAdditionalErrorMessagesMayFollow.Translated

            MsgBox(msg, MsgBoxStyle.Exclamation, title)

            DisplayErrors()
        Else
            CheckOverflow()
        End If

        ' Save Tuning Point
        _contour = mPerformanceResults.DesignContour
        _contour.TuningPoint = point
        mPerformanceResults.DesignContour = _contour

        ProgressMessage = ""

        Me.Running = False
        Return ok
    End Function

#End Region

#Region " Furrow Design "

    Public Overrides Sub RunDesign()
        Me.StartRun("Furrow Design", True)

        ' Ensure Width is correct
        Dim width As DoubleParameter = mSystemGeometry.Width
        mSystemGeometry.Width = width
        mWidth = width.Value
        '
        ' Build design contour grid
        '
        Me.BuildDesignGrid("Furrow", "Furrow Set")
        '
        ' Furrow design only works for Time-Based Cutoff & Minimum Depth
        '
        Dim cutoff As IntegerParameter = mInflowManagement.CutoffMethod
        If Not (cutoff.Value = CutoffMethods.TimeBased) Then
            cutoff.Value = CutoffMethods.TimeBased
            cutoff.Source = ValueSources.Calculated
            mInflowManagement.CutoffMethod = cutoff
        End If

        Dim designDepth As IntegerParameter = mBorderCriteria.InfiltratedDepthCriterion
        If Not (designDepth.Value = InfiltratedDepthCriteria.MinimumDepth) Then
            designDepth.Value = InfiltratedDepthCriteria.MinimumDepth
            designDepth.Source = ValueSources.Calculated
            mBorderCriteria.InfiltratedDepthCriterion = designDepth
        End If
        '
        ' Build contour polygons using contour grid as guide
        '
        mContourGrid.ClearContours()

        XTolerance = mLengthTolerance
        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            YTolerance = mWidthTolerance
        Else
            YTolerance = mInflowRateTolerance
        End If

        Dim minorContours As Boolean = WinSRFR.UserPreferences.DisplayMinorContours

        ' Potential Application Efficiency (AEmin) contour polygons
        Me.BuildMajorContours(sPotentialApplicationEfficiency, sPAEmin, PaeIndex, _
                Me.mMajor10PercentValues, PaeTolerance, Units.Percentage, True)

        If (minorContours) Then
            Me.BuildMinorContours(sPotentialApplicationEfficiency, sPAEmin, PaeIndex, _
                Me.mMinor10PercentValues, PaeTolerance, Units.Percentage, True)
        End If

        ' Distribution Uniformity (DUmin) contour polygons
        Me.BuildMajorContours(sMinimumDistributionUniformity, sDUmin, DuIndex, _
                Me.mMajor10PercentValues, DuTolerance, Units.Fraction, True)

        If (minorContours) Then
            Me.BuildMinorContours(sMinimumDistributionUniformity, sDUmin, DuIndex, _
                    Me.mMinor10PercentValues, DuTolerance, Units.Fraction, True)
        End If

        ' Adequacy (ADmin) contour polygons
        Me.BuildMajorContours(sMinimumAdequacy, sADmin, AdIndex, _
                Me.mMajor10PercentValues, ADTolerance, Units.Fraction, True)

        If (minorContours) Then
            Me.BuildMinorContours(sMinimumAdequacy, sADmin, AdIndex, _
                    Me.mMinor10PercentValues, ADTolerance, Units.Fraction, True)
        End If

        ' Runoff (RO) contour polygons
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            Me.BuildMajorContours(sRunoff, sRO, RoIndex, Me.mMajor10PercentValues, _
                    RoTolerance, Units.Percentage, False)

            If (minorContours) Then
                Me.BuildMinorContours(sRunoff, sRO, RoIndex, Me.mMinor10PercentValues, _
                        RoTolerance, Units.Percentage, False)
            End If
        End If

        ' Deep Percolation (DP) contour polygons
        Me.BuildMajorContours(sDeepPercolation, sDP, DpIndex, Me.mMajor10PercentValues, _
                DpTolerance, Units.Percentage, False)

        If (minorContours) Then
            Me.BuildMinorContours(sDeepPercolation, sDP, DpIndex, Me.mMinor10PercentValues, _
                    DpTolerance, Units.Percentage, False)
        End If

        ' Applied Depth (Dapp) contour polygons
        Me.BuildMajorContours(sAppliedDepth, sDapp, DappIndex, Me.mMajor10LevelDapps, _
                DappTolerance, Units.Millimeters, False)

        If (minorContours) Then
            Me.BuildMinorContours(sAppliedDepth, sDapp, DappIndex, Me.mMinor10LevelDapps, _
                    DappTolerance, Units.Millimeters, False)
        End If

        ' Low-Quarter Depth (Dlq) contour polygons
        Me.BuildMajorContours(sLowQuarterDepth, sDlq, DLfIndex, Me.mMajor10LevelDlfs, _
                DLfTolerance, Units.Millimeters, False)

        If (minorContours) Then
            Me.BuildMinorContours(sLowQuarterDepth, sDlq, DLfIndex, Me.mMinor10LevelDlfs, _
                    DLfTolerance, Units.Millimeters, False)
        End If

        ' Max Advance Time (Txa) contour polygons
        Me.BuildMajorContours(sMaxAdvanceTime, sTxa, TxaIndex, Me.mMajor10TxaValues, _
                TxaTolerance, Units.Seconds, False)

        If (minorContours) Then
            Me.BuildMinorContours(sMaxAdvanceTime, sTxa, TxaIndex, Me.mMinor10TxaValues, _
                    TxaTolerance, Units.Seconds, False)
        End If

        ' Cutoff Time (Tco) contour polygons
        Me.BuildMajorContours(sCutoffTime, sTco, TcoIndex, Me.mMajor10TcoValues, _
                TcoTolerance, Units.Seconds, False)

        If (minorContours) Then
            Me.BuildMinorContours(sCutoffTime, sTco, TcoIndex, Me.mMinor10TcoValues, _
                    TcoTolerance, Units.Seconds, False)
        End If

        ' Relative Cutoff (R) contour polygons
        Me.BuildMajorContours(sCutoffRatio, sXR, RcoIndex, Me.mMajor10LevelsRco, _
                RcoTolerance, Units.None, False)

        If (minorContours) Then
            Me.BuildMinorContours(sCutoffRatio, sXR, RcoIndex, Me.mMinor10LevelsRco, _
                    RcoTolerance, Units.None, False)
        End If

        ' Cutback Ratio
        If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            Me.BuildMajorContours(sCutbackRatio, sCutback, CutbackIndex, Me.mMajor10LevelsCutback, _
                    CutbackTolerance, Units.None, False)

            If (minorContours) Then
                Me.BuildMinorContours(sCutbackRatio, sCutback, CutbackIndex, Me.mMinor10LevelsCutback, _
                        CutbackTolerance, Units.None, False)
            End If
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

        Me.EndRun()
    End Sub

#End Region

#Region " Furrow Design Point "

    '*********************************************************************************************************
    ' Compute Furrow Design Point based on use of Cutback
    '
    Protected Overloads Overrides Function DesignPoint() As ContourPoint
        Dim point As ContourPoint

        If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            point = DesignPoint(mLength, mWidth, mInflowRate, NumWddPoints)
        Else
            mFurrowCutbackRate = mInflowRate * mCutbackRateRatio
            point = DesignPoint(mLength, mWidth, mInflowRate, mFurrowCutbackRate, NumWddPoints)
        End If

        Return point
    End Function

    '*********************************************************************************************************
    ' Compute Furrow Design Point wo/ Cutback
    '
    ' This function follows Bert Clemmen's Furrow Design algorithm found in FurrowDesign2005.xls
    '
    Protected Overloads Overrides Function DesignPoint(ByVal furrowLength As Double, _
                                                       ByVal furrowSetWidth As Double, _
                                                       ByVal inflowRate As Double, _
                                                       ByVal numDistances As Integer) As ContourPoint
        Debug.Assert(0 < furrowLength)
        Debug.Assert(0 < furrowSetWidth)
        Debug.Assert(0 < inflowRate)
        Debug.Assert(0 < numDistances)

        Dim furrowSpacing As Double = mSystemGeometry.FurrowSpacing.Value   ' Furrow geometry
        Dim furrowsPerSet As Double = furrowSetWidth / furrowSpacing

        ' Instantiate/initialize SRFR Infiltration object; its used for infiltration calculations
        mSoilCropProperties.SetSrfrInfiltration()
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.Length = furrowLength
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.BorderWidth = furrowSetWidth
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.FurrowsPerSet = furrowsPerSet
        mSoilCropProperties.SrfrInfiltration.RefInflow.Q0 = inflowRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.L = furrowLength

        '*****************************************************************************************************
        ' Step 1: Get input conditions
        '
        Dim zTolerance As Double = 0.001     ' 0.1%

        mSigmaY = mBorderCriteria.SigmaY.Value                              ' Tuning factors
        mPhi0 = mBorderCriteria.Phi0Furrows.Value
        mPhi1 = mBorderCriteria.Phi1Furrows.Value
        mPhi2 = mBorderCriteria.Phi2Furrows.Value
        mPhi3 = mBorderCriteria.Phi3Furrows.Value

        mArea = furrowLength * furrowSpacing

        mFurrowFlowRate = inflowRate / furrowsPerSet                        ' Furrow Inflow

        Dim Dmax As Double = mSystemGeometry.MaximumDepth.Value

        '*****************************************************************************************************
        ' Step 2: Compute upstream representative depth, flow area & wetted perimeter
        '
        Dim Qin As Double = mFurrowFlowRate

        Dim L1 As Double = furrowLength / 2.0
        Dim Y01, A01, R01, WP01, Sf1 As Double
        Me.UpstreamParameters(Qin, L1, furrowSetWidth, S0, Y01, A01, R01, WP01, Sf1)
        Dim V01 As Double = mFurrowFlowRate / Y01

        Dim L2 As Double = furrowLength
        Dim Y02, A02, R02, WP02, Sf2 As Double
        Me.UpstreamParameters(Qin, L2, furrowSetWidth, S0, Y02, A02, R02, WP02, Sf2)
        Dim V02 As Double = mFurrowFlowRate / Y02

        Dim WP As Double = Me.WettedPerimeter(Qin)

        '*****************************************************************************************************
        ' Step 3: Compute 2-point advance
        '
        ComputeTwoPointAdvance(L1, A01, V01, L2, A02, V02, furrowSpacing, WP, Qin, numDistances)

        '*****************************************************************************************************
        ' Step 4: Compute Performance (w/ Horizontal Recession)
        '   (not supported by WinSRFR)
        '

        '*****************************************************************************************************
        ' Step 5: Compute Performance (w/ Adjusted Recession)
        '

        ' Infiltration & Recession time at end of furrow (i.e. the design requirements)
        mDReq = mInflowManagement.RequiredDepth.Value
        mTReq = mSoilCropProperties.InfiltrationTime(mDReq, WP, furrowSpacing)
        mTrL = mTReq + mAdvanceTime2

        ' Adjusted cutoff time
        mTco = mTrL - (mPhi1 * (mSurfaceVolume2 / mFurrowFlowRate))

        ' Recession lag & recession time at head of furrow
        mTlag = (mPhi2 * A02 * furrowLength) / (2 * mFurrowFlowRate)
        mTr0 = mTco + mTlag

        ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
        ComputeIrrigationCurves(furrowSpacing, inflowRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

        ' Inflow volume
        mInflowVolume = mFurrowFlowRate * mTco

        ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
        If ((mInflowVolume < mInfiltratedVolume) And (mInfiltratedVolume < mInflowVolume * 1.01)) Then
            mInfiltratedVolume = mInflowVolume
        End If

        If (mInflowVolume < mInfiltratedVolume) Then

            ' Compute irrigation curves using Tco as Tr0
            ComputeIrrigationCurves(furrowSpacing, inflowRate, mTco, mTrL, mDMin, mInfiltratedVolume)

            If (mInflowVolume + 0.0001 < mInfiltratedVolume) Then
                ' Tr0 can't be less than Tco
                mTr0 = mTco
            Else
                ' Tr0 should be less than it is now but greater than Tco
                Dim minTr0 As Double = mTco
                Dim maxTr0 As Double = mTr0

                For iter As Integer = 1 To 25
                    mTr0 = (minTr0 + maxTr0) / 2.0

                    ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
                    ComputeIrrigationCurves(furrowSpacing, inflowRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                    If (mInflowVolume + 0.0001 < mInfiltratedVolume) Then
                        maxTr0 = mTr0                                           ' Too large
                    ElseIf (mInfiltratedVolume < mInflowVolume - 0.0001) Then
                        minTr0 = mTr0                                           ' Too small
                    Else
                        mInfiltratedVolume = mInflowVolume
                        Exit For                                                ' Just right
                    End If
                Next iter
            End If
        End If ' mInflowVolume < mInfiltratedVolume

        ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
        If ((mInflowVolume < mInfiltratedVolume) And (mInfiltratedVolume < mInflowVolume * 1.01)) Then
            mInfiltratedVolume = mInflowVolume
        End If

        ' Runoff volume
        mRunoffVolume = mPhi3 * Math.Max(mInflowVolume - mInfiltratedVolume, 0)

        '*****************************************************************************************************
        ' Step 6 - Adjust for Blocked End, if necessary
        '
        If ((mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) _
        And (0 < mRunoffVolume)) Then
            If (0.0 < S0) Then

                ' Compensate for ponded infiltration
                Dim loTco As Double = 0
                Dim hiTco As Double = mTco

                Dim blockedTco As Double = mTco
                Dim blockedTr0, blockedTr1 As Double

                ' Binary search for Tco where DMin = DReq
                For idx As Integer = 0 To 50

                    ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
                    blockedTr0 = mTr0 - (mTco - blockedTco)
                    blockedTr1 = mTrL - (mTco - blockedTco)
                    ComputeIrrigationCurves(furrowSpacing, inflowRate, blockedTr0, blockedTr1, mDMin, mInfiltratedVolume)

                    ' Inflow & Runoff volumes
                    mInflowVolume = mFurrowFlowRate * blockedTco
                    mRunoffVolume = mPhi3 * Math.Max(mInflowVolume - mInfiltratedVolume, 0)

                    ' Add infiltration due to ponding at end of field
                    AddSlopingFieldPond(furrowSpacing, WP, mRunoffVolume, mDMin, mInfiltratedVolume)

                    ' Check if Dmin is close enough to Dreq
                    If (mDMin < mDReq - 0.0001) Then
                        loTco = blockedTco                  ' Too small
                        If (0 < mDMin) Then
                            blockedTco = Math.Min(blockedTco * mDReq / mDMin, (loTco + hiTco) / 2.0)
                        Else ' mDMin = 0
                            blockedTco = (loTco + hiTco) / 2.0
                        End If
                    ElseIf (mDReq + 0.0001 < mDMin) Then
                        hiTco = blockedTco                  ' Too large
                        If (0 < mDMin) Then
                            blockedTco = Math.Max(blockedTco * mDReq / mDMin, (loTco + hiTco) / 2.0)
                        Else ' mDMin = 0
                            blockedTco = (loTco + hiTco) / 2.0
                        End If
                    Else
                        Exit For                            ' Just right
                    End If
                Next idx

                ' New Tco estimate
                mTco = blockedTco
            Else ' Slope is level
                ' Subtract time to input Runoff Volume from Tco
                mTco -= (mRunoffVolume / mFurrowFlowRate)
            End If

            ' Inflow volume
            mInflowVolume = mFurrowFlowRate * mTco

            ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
            If ((mInflowVolume < mInfiltratedVolume) And (mInfiltratedVolume < mInflowVolume * 1.01)) Then
                mInfiltratedVolume = mInflowVolume
            End If

            ' Blocked End; there is no Runoff
            mRunoffVolume = 0
        End If

        '*****************************************************************************************************
        ' Compute & load performance parameters into Contour Point
        '*****************************************************************************************************
        Dim parameter As SingleParameter
        Dim contourPoint As ContourPoint = New ContourPoint

        ComputePerformanceParameters(furrowLength, furrowSpacing)

        ' Move errors & warnings, if any, to Contour Point
        If (S0 < MaximumLevelSlope) Then
            ' Limit Line applies only to Level Furrows
            If (mXR < DesignLimitLine) Then
                AddExecutionWarning(WarningFlags.LimitLineExceeded, mDictionary.tLimitLineExceededID.Translated, mDictionary.tLimitLineExceededDetail.Translated)
                contourPoint.HasError = True
                contourPoint.ErrMsg = mDictionary.tLimitLineExceededID.Translated
            End If
        End If

        If ((Double.IsNaN(mTL)) Or (mTL = 0.0)) Then
            AddExecutionWarning(WarningFlags.AdvanceRecessionInadequate, mDictionary.tAdvanceRecessionInadequateID.Translated, mDictionary.tAdvanceRecessionInadequateDetail.Translated)
            contourPoint.HasError = True
            contourPoint.ErrMsg = mDictionary.tAdvanceRecessionInadequateID.Translated
        End If

        If ((OneWeek <= mOppTimes(0)) Or (OneWeek <= mOppTimes(mOppTimes.Count - 1))) Then
            AddExecutionWarning(WarningFlags.TimeTooLong, mDictionary.tTimeTooLongErrorID.Translated, mDictionary.tTimeTooLongErrorDetail.Translated)
            contourPoint.HasError = True
            contourPoint.ErrMsg = mDictionary.tTimeTooLongErrorID.Translated
        End If

        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            Dim RoDpRatio As Double = mRoDepth / mDpDepth
            If (RoDpRatio < RoDpRatioLimit) Then
                AddExecutionWarning(WarningFlags.DesignNotRecommended, mDictionary.tDesignNotRecommendedID.Translated, mDictionary.tDesignNotRecommendedDetail.Translated)
                contourPoint.HasError = True
                contourPoint.ErrMsg = mDictionary.tDesignNotRecommendedID.Translated
            End If
        End If

        Dim Ymax As Double = Math.Max(Y01, Y02)
        If (Dmax < Ymax) Then
            AddExecutionWarning(WarningFlags.DesignIsInvalid, mDictionary.tDesignNotValidID.Translated, mDictionary.tDesignNotValidDetail.Translated)
            contourPoint.HasError = True
            contourPoint.ErrMsg = mDictionary.tDesignNotValidID.Translated & " - Overflow; Ymax = " & DepthString(Ymax)
        End If

        If (Dmax * 0.9 < Ymax) Then
            AddExecutionWarning(WarningFlags.DesignNotRecommended, mDictionary.tDesignNotRecommendedID.Translated, mDictionary.tDesignNotRecommendedDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tDesignNotRecommendedID.Translated & "; Ymax = " & DepthString(Ymax)
        End If

        ' NOTE - order of Z parameters must match calling function's order
        contourPoint.X = New SingleParameter(CSng(mLength), Units.Meters)

        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            contourPoint.Y = New SingleParameter(CSng(furrowSetWidth), Units.Meters)
            parameter = New SingleParameter(CSng(inflowRate), Units.Cms)
        Else
            contourPoint.Y = New SingleParameter(CSng(inflowRate), Units.Cms)
            parameter = New SingleParameter(CSng(furrowSetWidth), Units.Meters)
        End If
        contourPoint.Z.Add(parameter)   ' Flow Rate or Furrow Set Width

        parameter = New SingleParameter(CSng(mPAEmin), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Potential Application Efficiency

        parameter = New SingleParameter(CSng(mDUmin), Units.Fraction)
        contourPoint.Z.Add(parameter)   ' Distribution Uniformity

        parameter = New SingleParameter(CSng(mADmin), Units.Fraction)
        contourPoint.Z.Add(parameter)   ' Adequacy

        parameter = New SingleParameter(CSng(mRoFraction), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Runoff

        parameter = New SingleParameter(CSng(mDpFraction), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Deep percolation

        parameter = New SingleParameter(CSng(mDApp), Units.Millimeters)
        contourPoint.Z.Add(parameter)   ' Applied Depth

        parameter = New SingleParameter(CSng(mDLf), Units.Millimeters)
        contourPoint.Z.Add(parameter)   ' Low-Quarter Depth

        parameter = New SingleParameter(CSng(mTxa), Units.Seconds)
        contourPoint.Z.Add(parameter)   ' Maximum Advance time

        parameter = New SingleParameter(CSng(mTco), Units.Seconds)
        contourPoint.Z.Add(parameter)   ' Cutoff time

        parameter = New SingleParameter(CSng(mXR), Units.None)
        contourPoint.Z.Add(parameter)   ' Relative cutoff

        mTcb = mTco ' No Cutback
        parameter = New SingleParameter(CSng(mTcb), Units.Seconds)
        contourPoint.Z.Add(parameter)   ' Cutback time

        parameter = New SingleParameter(CSng(mCost), Units.DollarsPerHectare)
        contourPoint.Z.Add(parameter)   ' Cost

        mSoilCropProperties.ClrSrfrInfiltration()

        Return contourPoint

    End Function

    '*********************************************************************************************************
    ' Compute Furrow Design Point w/ Cutback
    '
    ' This function follows Bert Clemmen's Furrow Design algorithm found FurrowDesign2005.xls
    '
    Protected Overloads Overrides Function DesignPoint(ByVal furrowLength As Double, _
                                                       ByVal furrowSetWidth As Double, _
                                                       ByVal inflowRate As Double, _
                                                       ByVal cutbackRate As Double, _
                                                       ByVal numDistances As Integer) As ContourPoint

        Debug.Assert(0 < furrowLength, "Furrow Length = " & furrowLength.ToString)
        Debug.Assert(0 < furrowSetWidth, "Furrow Set Width = " & furrowSetWidth.ToString)
        Debug.Assert(0 < inflowRate, "Inflow Rate = " & inflowRate.ToString)
        Debug.Assert(0 < numDistances, "Number of Distances = " & numDistances.ToString)

        ' If Cutback Rate is 0.0, use method without cutback
        If (cutbackRate <= 0.0) Then
            Return DesignPoint(furrowLength, furrowSetWidth, inflowRate, numDistances)
        End If

        Dim furrowSpacing As Double = mSystemGeometry.FurrowSpacing.Value   ' Furrow geometry
        Dim furrowsPerSet As Double = furrowSetWidth / furrowSpacing

        ' Instantiate/initialize SRFR Infiltration object; its used for infiltration calculations
        mSoilCropProperties.SetSrfrInfiltration()
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.Length = furrowLength
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.BorderWidth = furrowSetWidth
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.FurrowsPerSet = furrowsPerSet
        mSoilCropProperties.SrfrInfiltration.RefInflow.Q0 = inflowRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.Qcb = cutbackRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.L = furrowLength

        '*****************************************************************************************************
        ' Step 1: Get input conditions
        '
        mSigmaY = mBorderCriteria.SigmaY.Value                              ' Tuning factors
        mPhi0 = mBorderCriteria.Phi0Furrows.Value
        mPhi1 = mBorderCriteria.Phi1Furrows.Value
        mPhi2 = mBorderCriteria.Phi2Furrows.Value
        mPhi3 = mBorderCriteria.Phi3Furrows.Value

        mArea = furrowLength * furrowSpacing

        mFurrowFlowRate = inflowRate / furrowsPerSet                        ' Furrow Inflow
        mFurrowCutbackRate = cutbackRate / furrowsPerSet

        Dim zTolerance As Double = 0.001     ' 0.1%

        Dim Dmax As Double = mSystemGeometry.MaximumDepth.Value

        '*****************************************************************************************************
        ' Step 2: Compute upstream representative depths & flow areas (before & after cutback)
        '
        Dim Qin As Double = mFurrowFlowRate

        Dim L1 As Double = furrowLength / 2.0
        Dim Y01, A01, R01, WP01, Sf1 As Double
        Me.UpstreamParameters(Qin, L1, furrowSetWidth, S0, Y01, A01, R01, WP01, Sf1)
        Dim V01 As Double = mFurrowFlowRate / Y01

        Dim L2 As Double = furrowLength
        Dim Y02, A02, R02, WP02, Sf2 As Double
        Me.UpstreamParameters(Qin, L2, furrowSetWidth, S0, Y02, A02, R02, WP02, Sf2)
        Dim V02 As Double = mFurrowFlowRate / Y02

        Dim Y0cb, A0cb, R0cb, WP0cb, Sfcb As Double
        Me.UpstreamParameters(mFurrowCutbackRate, L2, furrowSetWidth, S0, Y0cb, A0cb, R0cb, WP0cb, Sfcb)
        Dim V0cb As Double = mFurrowCutbackRate / Y0cb

        Dim WP As Double = WP02 ' WP0cb
        If (mSoilCropProperties.WettedPerimeterMethod.Value = WettedPerimeterMethods.FurrowSpacing) Then
            WP = furrowSpacing
        End If

        '*****************************************************************************************************
        ' Step 3: Compute 2-point advance
        '
        ComputeTwoPointAdvance(L1, A01, V01, L2, A02, V02, furrowSpacing, WP, Qin, numDistances)

        '*****************************************************************************************************
        ' Step 4: Determine cutback time
        '
        mDReq = mInflowManagement.RequiredDepth.Value               ' Inflow requirements
        mTReq = mSoilCropProperties.InfiltrationTime(mDReq, WP, furrowSpacing)

        mTrL = mTReq + mAdvanceTime2                                ' Cutoff & Recession times

        zTolerance = 0.0000000001
        Dim minCutbackTime As Double = mAdvanceTime2
        Dim maxCutbackTime As Double = mTrL
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

                For idx As Integer = 0 To numDistances - 1
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
                For idx As Integer = 1 To numDistances - 1
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

                ' Is Cutback Time search range small enough?
                If (ThisClose(minCutbackTime, maxCutbackTime, TenSeconds)) Then
                    Exit For
                End If

            Next iter
        Catch ex As Exception
            Return Nothing
        End Try

        '*****************************************************************************************************
        ' Step 5: Compute Performance (w/ Horizontal Recession)
        '   (not supported by WinSRFR)
        '

        '*****************************************************************************************************
        ' Step 6: Compute Performance (w/ Adjusted cutback time & Recession)
        '
        Dim adjRate As Double = mFurrowFlowRate
        Dim adjSurfaceVolume As Double = (mSigmaY * mPhi0) * A0cb * furrowLength
        mTco = mTrL - (mPhi1 * (adjSurfaceVolume / mFurrowCutbackRate))
        mTcb = estCutbackTime - (mSurfaceVolume2 - adjSurfaceVolume) / (mFurrowFlowRate - mFurrowCutbackRate)

        ' Cutback time is limited by Cutoff time
        If (mTcb > mTco) Then
            ' Cutback Time after Cutoff Time; this can't happen!  Switch to no Cutback solution
            mTco = mTrL - (mPhi1 * (mSurfaceVolume2 / mFurrowFlowRate))
            mTcb = mTco
        Else
            ' Compute equivalent inflow rate
            adjRate = ((mFurrowFlowRate * mTcb) + (mFurrowCutbackRate * (mTco - mTcb))) / mTco
        End If

        ' Recession lag & recession time at head of furrow
        mTlag = (mPhi2 * A02 * furrowLength) / (2 * adjRate)
        mTr0 = mTco + mTlag

        ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
        ComputeIrrigationCurves(furrowSpacing, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

        ' Inflow  volume
        mInflowVolume = adjRate * mTco

        ' Cutback Time Ratio
        mCutbackTimeRatio = mTcb / mTco

        ' Runoff
        mRunoffVolume = mPhi3 * Math.Max(mInflowVolume - mInfiltratedVolume, 0)

        '*****************************************************************************************************
        ' Step 7 - Adjust for Blocked End, if necessary
        '
        If ((mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) _
        And (0 < mRunoffVolume)) Then

            If (0.0 < S0) Then
                ' Compensate for ponded infiltration
                Dim loTco As Double = 0
                Dim hiTco As Double = mTco

                ' Binary search for Tco where DMin = DReq
                For idx As Integer = 0 To 50

                    ' Compute equivalent single inflow rate
                    adjRate = ((mFurrowFlowRate * mTcb) + (mFurrowCutbackRate * (mTco - mTcb))) / mTco

                    ' Recession lag & recession time at head of furrow
                    mTlag = (mPhi2 * A02 * furrowLength) / (2 * adjRate)
                    mTr0 = mTco + mTlag

                    ' Recession time at end of furrow
                    mTrL = mTco + (mPhi1 * (mSurfaceVolume2 / adjRate))

                    ' Compute irrigation curves
                    ComputeIrrigationCurves(furrowSpacing, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                    ' Inflow, Infiltrated & Runoff volumes
                    mInflowVolume = adjRate * mTco
                    mRunoffVolume = Math.Max(mInflowVolume - mInfiltratedVolume, 0)

                    ' Add infiltration due to ponding at end of field
                    AddSlopingFieldPond(furrowSpacing, WP, mRunoffVolume, mDMin, mInfiltratedVolume)

                    If (mDMin < mDReq - 0.0004) Then
                        loTco = mTco                  ' Too small
                        If (0 < mDMin) Then
                            mTco = Math.Min(mTco * mDReq / mDMin, (loTco + hiTco) / 2.0)
                        Else
                            mTco = (loTco + hiTco) / 2.0
                        End If
                    ElseIf (mDReq + 0.0004 < mDMin) Then
                        hiTco = mTco                  ' Too large
                        If (0 < mDMin) Then
                            mTco = Math.Max(mTco * mDReq / mDMin, (loTco + hiTco) / 2.0)
                        Else
                            mTco = (loTco + hiTco) / 2.0
                        End If
                    Else
                        Exit For                            ' Just right
                    End If

                    mTcb = mTco * mCutbackTimeRatio
                    mTcb = Math.Max(mTcb, mAdvanceTime2)
                Next idx

            Else ' Slope is level
                ' Subtract time to input Runoff Volume from Tco
                If (mTcb < mTco) Then
                    Dim cutbackVolume As Double = (mTco - mTcb) * mFurrowCutbackRate

                    If (mRunoffVolume < cutbackVolume) Then
                        ' Runoff is within cutback volume
                        mTco -= (mRunoffVolume / mFurrowCutbackRate)
                    Else
                        ' Runoff is more than cutback volume
                        mTco -= (cutbackVolume / mFurrowCutbackRate)
                        mTco -= (mRunoffVolume - cutbackVolume) / mFurrowFlowRate
                        mTcb = mTco
                    End If
                Else ' Tco <= Tcb
                    mTco -= (mRunoffVolume / mFurrowFlowRate)
                    mTcb = mTco
                End If
            End If

            ' Cutback Time Ratio
            mCutbackTimeRatio = mTcb / mTco

            ' Inflow & Infiltrated volumes
            If (mTcb < mTco) Then
                mInflowVolume = mFurrowFlowRate * mTcb + mFurrowCutbackRate * (mTco - mTcb)
            Else
                mInflowVolume = mFurrowFlowRate * mTco
            End If

            ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
            If ((mInflowVolume < mInfiltratedVolume) And (mInfiltratedVolume < mInflowVolume * 1.01)) Then
                mInfiltratedVolume = mInflowVolume
            End If

            ' There is no Runoff
            mRunoffVolume = 0
        End If

        '*****************************************************************************************************
        ' Compute & load performance parameters into Contour Point
        '*****************************************************************************************************
        Dim parameter As SingleParameter
        Dim contourPoint As ContourPoint = New ContourPoint

        ComputePerformanceParameters(furrowLength, furrowSpacing)

        ' Move errors & warnings, if any, to Contour Point
        If (S0 < MaximumLevelSlope) Then
            ' Limit Line applies only to Level Furrows
            If (mXR < DesignLimitLine) Then
                AddExecutionWarning(WarningFlags.LimitLineExceeded, mDictionary.tLimitLineExceededID.Translated, mDictionary.tLimitLineExceededDetail.Translated)
                contourPoint.HasError = True
                contourPoint.ErrMsg = mDictionary.tLimitLineExceededID.Translated
            End If
        End If

        If ((Double.IsNaN(mTL)) Or (mTL = 0.0)) Then
            AddExecutionWarning(WarningFlags.AdvanceRecessionInadequate, mDictionary.tAdvanceRecessionInadequateID.Translated, mDictionary.tAdvanceRecessionInadequateDetail.Translated)
            contourPoint.HasError = True
            contourPoint.ErrMsg = mDictionary.tAdvanceRecessionInadequateID.Translated
        End If

        If (mTcb > mTco - 0.1) Then
            mTcb = mTco
            AddExecutionWarning(WarningFlags.TcbLimitedToTco, mDictionary.tTcbLimitedToTcoID.Translated, mDictionary.tTcbLimitedToTcoDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tTcbLimitedToTcoID.Translated
        End If

        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            Dim RoDpRatio As Double = mRoDepth / mDpDepth
            If (RoDpRatio < RoDpRatioLimit) Then
                AddExecutionWarning(WarningFlags.DesignNotRecommended, mDictionary.tDesignNotRecommendedID.Translated, mDictionary.tDesignNotRecommendedDetail.Translated)
                contourPoint.HasError = True
                contourPoint.ErrMsg = mDictionary.tDesignNotRecommendedID.Translated
            End If
        End If

        Dim Ymax As Double = Math.Max(Y01, Y02)
        If (Dmax < Ymax) Then
            AddExecutionWarning(WarningFlags.DesignIsInvalid, mDictionary.tDesignNotValidID.Translated, mDictionary.tDesignNotValidDetail.Translated)
            contourPoint.HasError = True
            contourPoint.ErrMsg = mDictionary.tDesignNotValidID.Translated & " - Overflow; Ymax = " & DepthString(Ymax)
        End If

        If (Dmax * 0.9 < Ymax) Then
            AddExecutionWarning(WarningFlags.DesignNotRecommended, mDictionary.tDesignNotRecommendedID.Translated, mDictionary.tDesignNotRecommendedDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tDesignNotRecommendedID.Translated & "; Ymax = " & DepthString(Ymax)
        End If

        ' NOTE - order of Z parameters must match calling function's order
        contourPoint.X = New SingleParameter(CSng(mLength), Units.Meters)

        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            contourPoint.Y = New SingleParameter(CSng(mWidth), Units.Meters)
            parameter = New SingleParameter(CSng(inflowRate), Units.Cms)
        Else
            contourPoint.Y = New SingleParameter(CSng(inflowRate), Units.Cms)
            parameter = New SingleParameter(CSng(furrowSetWidth), Units.Meters)
        End If
        contourPoint.Z.Add(parameter)   ' Flow Rate or Furrow Set Width

        parameter = New SingleParameter(CSng(mPAEmin), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Potential Application Efficiency

        parameter = New SingleParameter(CSng(mDUmin), Units.Fraction)
        contourPoint.Z.Add(parameter)   ' Distribution Uniformity

        parameter = New SingleParameter(CSng(mADmin), Units.Fraction)
        contourPoint.Z.Add(parameter)   ' Adequacy

        parameter = New SingleParameter(CSng(mRoFraction), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Runoff

        parameter = New SingleParameter(CSng(mDpFraction), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Deep percolation

        parameter = New SingleParameter(CSng(mDApp), Units.Millimeters)
        contourPoint.Z.Add(parameter)   ' Applied Depth

        parameter = New SingleParameter(CSng(mDLf), Units.Millimeters)
        contourPoint.Z.Add(parameter)   ' Low-Quarter Depth

        parameter = New SingleParameter(CSng(mTxa), Units.Seconds)
        contourPoint.Z.Add(parameter)   ' Maximum Advance time

        parameter = New SingleParameter(CSng(mTco), Units.Seconds)
        contourPoint.Z.Add(parameter)   ' Cutoff time

        parameter = New SingleParameter(CSng(mXR), Units.None)
        contourPoint.Z.Add(parameter)   ' Relative cutoff

        parameter = New SingleParameter(CSng(mTcb / mTco), Units.None)
        contourPoint.Z.Add(parameter)   ' Relative cutback

        parameter = New SingleParameter(CSng(mCost), Units.DollarsPerHectare)
        contourPoint.Z.Add(parameter)   ' Cost

        mSoilCropProperties.ClrSrfrInfiltration()

        Return contourPoint

    End Function

#End Region

#Region " Solution "

    '*********************************************************************************************************
    ' CalculateSolution() - calculate the solution for the current user values
    '
    Public Overrides Sub CalculateSolution()

        ' Furrow Design is per furrow; convert field rates to furrow rates
        mFurrowFlowRate = mInflowManagement.InflowRate.Value / mSystemGeometry.FurrowsPerSet.Value
        mFurrowCutbackRate = mFurrowFlowRate * mInflowManagement.CutbackRateRatio.Value

        ' Calculate the Solution's Design Point
        MyBase.CalculateSolution()

        ' Run a SRFR comparison
        VerifySrfrParameters(CellDensities.Medium)
        RunSRFR(True, False, False)

        ' Display then Clear any SRFR Execution Errors
        DisplayErrors()
        ClearExecutionErrors()

        ' Save Design Point results (overwrites SRFR results)
        SaveSolution()
    End Sub

    Protected Overrides Sub SaveSolution()
        ' Save parameters common to all design analyses
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
    ' Extended check of setup errors and warnings for Design Analysis
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
            AddSetupWarning(WarningFlags.DefaultTuningFactors, mDictionary.tDefaultTuningFactorsID.Translated, mDictionary.tDefaultTuningFactorsDetails.Translated)
        End If

    End Sub

#End Region

End Class
