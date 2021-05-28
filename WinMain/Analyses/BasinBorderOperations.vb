
'*************************************************************************************************************
' Class:    BasinBorderOperations
'
' Desc:     Performs Operations functions for a Basin / Border field.
'*************************************************************************************************************
Imports DataStore

Public Class BasinBorderOperations
    Inherits OperationsAnalysis

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

    '******************************************************************************************
    ' Estimate Basin/Border Operations Tuning Factors
    '
    Public Overrides Function EstimateTuningFactors() As Boolean
        Dim ok As Boolean = False

        mSoilCropProperties.SetSrfrInfiltration()

        mTuningPoint = Nothing

        S0 = mSystemGeometry.AverageSlope

        If (S0 <= MaximumLevelSlope) Then
            ' Level Basin
            ok = EstimateTuningFactorsLevelBasin()
        Else ' Sloping Border
            mCutbackMethod = mInflowManagement.CutbackMethod.Value

            If (mCutbackMethod = Globals.CutbackMethods.NoCutback) Then
                ok = EstimateTuningFactorsBorderNoCutback()
            Else
                ok = EstimateTuningFactorsBorderWithCutback()
            End If
        End If

        ' Calculate/Save Advance Curve's 'r' value
        Dim p, r As Double
        Dim advTable As DataTable = Me.AdvanceTable
        Dim PandRok As Boolean = AdvancePandR(advTable, p, r)

        Dim _rParam As DoubleParameter = mBorderCriteria.PwrAdvRBorders
        _rParam.Source = ValueSources.Calculated
        _rParam.Value = r
        mBorderCriteria.PwrAdvRBorders = _rParam

        ' Validate Advance Curve's 'r' value
        PandRok = ValidateTuningAdvancePandR(PandRok, p, r)

        ' Save Tuning Point
        Dim _contour As ContourParameter = mPerformanceResults.DesignContour
        _contour.TuningPoint = mTuningPoint
        mPerformanceResults.DesignContour = _contour

        ' Check for adequate water application
        Dim Dapp As Double = mSurfaceFlow.DappG.Value
        Dim Dreq As Double = mInflowManagement.RequiredDepth.Value

        If (Dapp < Dreq) Then
            Me.DisplayTuningPointBadAppliedDepthMessage()
            ok = False
        End If

        mSoilCropProperties.ClrSrfrInfiltration()

        Return ok
    End Function

#Region " Level Basin "

    Protected Function EstimateTuningFactorsLevelBasin() As Boolean
        Dim ok As Boolean = MyBase.EstimateTuningFactors()
        Me.Running = True
        '
        ' Basin / Border Operations only works for Time-Based Cutoff
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
        Dim inflowRate As DoubleParameter = mInflowManagement.InflowRate
        inflowRate.Value = mBorderCriteria.ContourInflowRatePoint.Value
        inflowRate.Source = mBorderCriteria.ContourInflowRatePoint.Source
        mInflowManagement.InflowRate = inflowRate
        mInflowRate = inflowRate.Value

        Dim cutoffTime As DoubleParameter = mInflowManagement.CutoffTime
        cutoffTime.Value = mBorderCriteria.ContourCutoffTimePoint.Value
        cutoffTime.Source = mBorderCriteria.ContourCutoffTimePoint.Source
        mInflowManagement.CutoffTime = cutoffTime
        mTco = cutoffTime.Value
        '
        ' Level Basin requires Blocked End
        '
        Dim downstream As IntegerParameter = mSystemGeometry.DownstreamCondition
        downstream.Value = DownstreamConditions.BlockedEnd
        downstream.Source = ValueSources.Calculated
        mSystemGeometry.DownstreamCondition = downstream
        '
        ' Save current Downstream Condition
        '
        mDownstreamValue = downstream.Value
        mDownstreamSource = downstream.Source
        '
        ' 1. Compute Basin / Border operations with simplified procedure
        '   a. This estimates Tco for Dreq (i.e. Dmin)
        '

        ' Get Sigma Y (surface-shape factor)
        Dim sigmaY As DoubleParameter = mBorderCriteria.SigmaY
        sigmaY.Value = Me.SigmaY(mInflowRate, mLength, mWidth, S0)
        sigmaY.Source = ValueSources.Calculated
        mBorderCriteria.SigmaY = sigmaY

        Dim lowerPhi0Limit As Double = 0.0
        Dim upperPhi0Limit As Double = 2.0 / sigmaY.Value
        Dim lowerPhi1Limit As Double = 0.0
        Dim upperPhi1Limit As Double = 2.0

        ' Compute Basin / Border operations with default Tuning Factors & Open End
        Dim phi0 As DoubleParameter = mBorderCriteria.Phi0Borders
        phi0.Value = DefaultPhi0Borders
        phi0.Source = ValueSources.Calculated
        mBorderCriteria.Phi0Borders = phi0

        Dim phi1 As DoubleParameter = mBorderCriteria.Phi1Borders
        phi1.Value = DefaultPhi1Borders
        phi1.Source = ValueSources.Calculated
        mBorderCriteria.Phi1Borders = phi1

        Dim phi2 As DoubleParameter = mBorderCriteria.Phi2Borders
        phi2.Value = DefaultPhi2Borders
        phi2.Source = ValueSources.Calculated
        mBorderCriteria.Phi2Borders = phi2

        Dim phi3 As DoubleParameter = mBorderCriteria.Phi3Borders
        phi3.Value = DefaultPhi3Borders
        phi3.Source = ValueSources.Calculated
        mBorderCriteria.Phi3Borders = phi3

        ' Compute Border operations with default Tuning Factors
        Dim point As ContourPoint = OperationsPointVolBal()

        ' Get data from last operations
        Dim tlBorder As Double = Me.AdvanceTimeToEndOfField
        Dim tr0Border As Double = Me.RecessionTimeAtHeadOfField
        Dim trlBorder As Double = Me.RecessionTimeAtEndOfField
        Dim dminBorder As Double = Me.DMin

        Dim title As String = mDictionary.tTuningError.Translated
        Dim msg As String

        If (point.HasError) Then
            ' Search for better Tuning Point
            Dim minInflowRate As Double = mInflowRate
            Dim maxInflowRate As Double = mBorderCriteria.MaxContourInflowRate.Value
            Dim minTco As Double = mTco
            Dim maxTco As Double = mBorderCriteria.MaxContourCutoffTime.Value

            For iter As Integer = 1 To 20
                mInflowRate = (minInflowRate + maxInflowRate) / 2.0
                mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value
                mTco = (minTco + maxTco) / 2.0

                point = OperationsPointVolBal()

                If (point.HasError) Then
                    minInflowRate = mInflowRate
                    minTco = mTco
                Else
                    maxInflowRate = mInflowRate
                    maxTco = mTco
                End If
            Next

            If (point.HasError) Then
                mInflowRate = maxInflowRate
                mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value
                mTco = maxTco

                point = OperationsPointVolBal()

                If (point.HasError) Then
                    If (point.ErrMsg = mDictionary.tAdvanceRecessionInadequateID.Translated) Then
                        Me.DisplayTuningPointBadAdvanceMessage()
                    Else
                        Me.DisplayTuningPointBadMessage(point.ErrMsg)
                    End If

                    ' Restore Downstream Condition
                    downstream = mSystemGeometry.DownstreamCondition
                    downstream.Value = mDownstreamValue
                    downstream.Source = mDownstreamSource
                    mSystemGeometry.DownstreamCondition = downstream

                    Me.Running = False
                    Return False
                End If
            End If

            msg = mDictionary.tTuningFactorsCalculationFailed.Translated
            msg += Chr(13)
            msg += Chr(13) + "A more suitable Tuning Point was found and will be used."

            MsgBox(msg, MsgBoxStyle.Information, title)

            ' Move Tuning Point 5% of the distance toward the upper-right corner
            mInflowRate += (mBorderCriteria.MaxContourInflowRate.Value - mInflowRate) * 0.05
            mInflowRate = Math.Round(mInflowRate, 3)
            mTco += (mBorderCriteria.MaxContourCutoffTime.Value - mTco) * 0.05
            mTco = Math.Round(mTco)

            ' Save new Tuning & Solution Point
            inflowRate = mInflowManagement.InflowRate
            inflowRate.Value = mInflowRate
            inflowRate.Source = ValueSources.Calculated
            mInflowManagement.InflowRate = inflowRate

            inflowRate = mBorderCriteria.ContourInflowRatePoint
            inflowRate.Value = mInflowRate
            inflowRate.Source = ValueSources.Calculated
            mBorderCriteria.ContourInflowRatePoint = inflowRate

            cutoffTime = mInflowManagement.CutoffTime
            cutoffTime.Value = mTco
            cutoffTime.Source = ValueSources.Calculated
            mInflowManagement.CutoffTime = cutoffTime

            cutoffTime = mBorderCriteria.ContourCutoffTimePoint
            cutoffTime.Value = mTco
            cutoffTime.Source = ValueSources.Calculated
            mBorderCriteria.ContourCutoffTimePoint = cutoffTime

            If Not (mWorldWindow Is Nothing) Then
                mWorldWindow.Refresh()
            End If
        Else ' User selected Solution Point doesn't produce an error
            Dim AE1 As Double = mAE

            ' Search for better Tuning Point
            Dim minInflowRate As Double = mBorderCriteria.MinContourInflowRate.Value
            Dim maxInflowRate As Double = mInflowRate
            Dim minTco As Double = mBorderCriteria.MinContourCutoffTime.Value
            Dim maxTco As Double = mTco

            For iter As Integer = 1 To 20
                mInflowRate = (minInflowRate + maxInflowRate) / 2.0
                mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value
                mTco = (minTco + maxTco) / 2.0

                point = OperationsPointVolBal()

                If (point.HasError) Then
                    minInflowRate = mInflowRate
                    minTco = mTco
                Else
                    maxInflowRate = mInflowRate
                    maxTco = mTco
                End If
            Next

            If (point.HasError) Then
                mInflowRate = maxInflowRate
                mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value
                mTco = maxTco

                point = OperationsPointVolBal()
            End If

            Dim AE2 As Double = mAE

            ' If new point has more than a 10% AE improvement; ask if it should be used
            If ((0.1 < AE2 - AE1) And (1.0 <= mXR)) Then

                msg = Chr(13) + mDictionary.tTuningPointSuggested.Translated
                msg += Chr(13)
                msg += Chr(13) & mDictionary.tOriginalPoint.Translated & ":  AE = " & PercentageString(AE1, 0)
                msg += Chr(13) & mDictionary.tAlternatePoint.Translated & ":  AE = " & PercentageString(AE2, 0)
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tPressYesToRetryAtSuggestedPoint.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tPressNoKeepCurrentPoint.Translated
                msg += Chr(13)

                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)

                If (result = MsgBoxResult.Yes) Then
                    ' Move Tuning Point 5% of the distance toward the upper-right corner
                    mInflowRate += (mBorderCriteria.MaxContourInflowRate.Value - mInflowRate) * 0.05
                    mInflowRate = Math.Round(mInflowRate, 3)
                    mTco += (mBorderCriteria.MaxContourCutoffTime.Value - mTco) * 0.05
                    mTco = Math.Round(mTco)

                    ' Save new Tuning & Solution Point
                    inflowRate = mInflowManagement.InflowRate
                    inflowRate.Value = mInflowRate
                    inflowRate.Source = ValueSources.Calculated
                    mInflowManagement.InflowRate = inflowRate

                    inflowRate = mBorderCriteria.ContourInflowRatePoint
                    inflowRate.Value = mInflowRate
                    inflowRate.Source = ValueSources.Calculated
                    mBorderCriteria.ContourInflowRatePoint = inflowRate

                    cutoffTime = mInflowManagement.CutoffTime
                    cutoffTime.Value = mTco
                    cutoffTime.Source = ValueSources.Calculated
                    mInflowManagement.CutoffTime = cutoffTime

                    cutoffTime = mBorderCriteria.ContourCutoffTimePoint
                    cutoffTime.Value = mTco
                    cutoffTime.Source = ValueSources.Calculated
                    mBorderCriteria.ContourCutoffTimePoint = cutoffTime

                    If Not (mWorldWindow Is Nothing) Then
                        mWorldWindow.Refresh()
                    End If
                Else
                    ' Restore Tuning Point to it original position
                    mInflowRate = mBorderCriteria.ContourInflowRatePoint.Value
                    mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value
                    mTco = mBorderCriteria.ContourCutoffTimePoint.Value

                    point = OperationsPointVolBal()
                End If
            Else
                ' Restore Tuning Point to it original position
                mInflowRate = mBorderCriteria.ContourInflowRatePoint.Value
                mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value
                mTco = mBorderCriteria.ContourCutoffTimePoint.Value

                point = OperationsPointVolBal()
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
        Dim tr0Srfr As Double = mSurfaceFlow.RecessionAtHead
        If (Double.IsNaN(tr0Srfr)) Then
            tr0Srfr = Me.TRatDistance(0.0, mWidth, mWidth)
        End If
        Dim trlSrfr As Double = mSurfaceFlow.RecessionAtDistance(mLength)
        trlSrfr = Me.TRatDistance(mLength, mWidth, mWidth)
        Dim tlagSrfr As Double = Math.Max(tr0Srfr - tcoSrfr, MinTlag)
        Dim inVolSrfr As Double = mSubsurfaceFlow.InfiltratedVolume()
        Dim dminSrfr As Double = mSubsurfaceFlow.Dmin.Value

        If (0 < mPerformanceResults.ErrorCount.Value) Then
            Me.DisplayTuningPointBadMessage()
            DisplayErrors()

            Me.Running = False
            Return False
        End If

        If ((tlSrfr <= 0.0) Or (trlSrfr <= 0.0)) Then
            Me.DisplayTuningPointBadAdvanceMessage()

            Me.Running = False
            Return False
        End If
        '
        ' 3. Adjust Phi 0 so Border Operations advance matches SRFR simulation advance
        '
        Me.StatusMessage = mDictionary.tEstimatingPhi0.Translated

        ' Use binary search to match Phi 0 values
        Dim minPhi0 As Double = lowerPhi0Limit
        Dim maxPhi0 As Double = upperPhi0Limit

        ok = False
        For iter As Integer = 0 To 25

            ' Get current value of Phi 0
            phi0 = mBorderCriteria.Phi0Borders

            ' Halve the range for Phi 0 binary search
            If (Double.IsNaN(tlSrfr)) Then
                maxPhi0 = phi0.Value                        ' Too large
            Else
                If (tlSrfr + 0.001 < tlBorder) Then
                    maxPhi0 = phi0.Value                    ' Too large
                ElseIf (tlBorder < tlSrfr - 0.001) Then
                    minPhi0 = phi0.Value                    ' Too small
                Else
                    ok = True
                    Exit For                                ' Just Right
                End If
            End If

            phi0.Value = (minPhi0 + maxPhi0) / 2.0
            phi0.Source = ValueSources.Calculated
            mBorderCriteria.Phi0Borders = phi0

            ProgressMessage = phi0.Value.ToString

            If ((maxPhi0 - minPhi0) < 0.000001) Then
                ok = True
                Exit For
            End If

            ' Compute Border operations with mid-range Phi 0
            point = OperationsPointVolBal()

            tlBorder = Me.AdvanceTimeToEndOfField
            tr0Border = Me.RecessionTimeAtHeadOfField
            trlBorder = Me.RecessionTimeAtEndOfField
            dminBorder = Me.DMin
        Next

        ' If solution is at limit of binary search; this is an error
        If ((Not ok) And (maxPhi0 = upperPhi0Limit)) Then
            msg = mDictionary.tTuningFactorsCalculationPhi0Failed.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated

            MsgBox(msg, MsgBoxStyle.Exclamation, title)
        Else
            '
            ' 4. Estimate Phi 1 to match recession at downstream end
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi1.Translated

            Dim minPhi1 As Double = lowerPhi1Limit
            Dim maxPhi1 As Double = upperPhi1Limit

            ok = False
            For iter As Integer = 1 To 25

                ' Get current value of Phi 1
                phi1 = mBorderCriteria.Phi1Borders

                ' Halve the range for Phi 1 binary search
                If (trlSrfr + 0.001 < mTrL) Then
                    minPhi1 = phi1.Value                    ' Too small
                ElseIf (mTrL < trlSrfr - 0.001) Then
                    maxPhi1 = phi1.Value                    ' Too large
                Else
                    ok = True
                    Exit For                                ' Just Right
                End If

                phi1.Value = (minPhi1 + maxPhi1) / 2.0
                phi1.Source = ValueSources.Calculated
                mBorderCriteria.Phi1Borders = phi1

                ProgressMessage = phi1.Value.ToString

                If ((maxPhi1 - minPhi1) < 0.000001) Then
                    ok = True
                    Exit For
                End If

                ' Compute Border operations with mid-range Phi 1
                point = OperationsPointVolBal()

                ' Get data from last design
                tlBorder = Me.AdvanceTimeToEndOfField
                trlBorder = Me.RecessionTimeAtEndOfField
            Next
        End If ' Phi 0 estimate OK

        ProgressMessage = ""

        mTuningPoint = point

        Me.Running = False
        Return ok
    End Function

#End Region

#Region " Sloping Border wo/ Cutback "

    Protected Function EstimateTuningFactorsBorderNoCutback() As Boolean
        Dim ok As Boolean = MyBase.EstimateTuningFactors()
        Me.Running = True
        '
        ' Basin / Border Operations only works for Time-Based Cutoff
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
        Dim inflowRate As DoubleParameter = mInflowManagement.InflowRate
        inflowRate.Value = mBorderCriteria.ContourInflowRatePoint.Value
        inflowRate.Source = mBorderCriteria.ContourInflowRatePoint.Source
        mInflowManagement.InflowRate = inflowRate
        mInflowRate = inflowRate.Value
        mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value

        Dim cutoffTime As DoubleParameter = mInflowManagement.CutoffTime
        cutoffTime.Value = mBorderCriteria.ContourCutoffTimePoint.Value
        cutoffTime.Source = mBorderCriteria.ContourCutoffTimePoint.Source
        mInflowManagement.CutoffTime = cutoffTime
        mTco = cutoffTime.Value

        mInflowVolume = mInflowRate * mTco
        '
        ' Save current Downstream Condition
        '
        Dim downstream As IntegerParameter = mSystemGeometry.DownstreamCondition
        mDownstreamValue = downstream.Value
        mDownstreamSource = downstream.Source
        '
        ' 1. Compute Basin / Border operations with simplified procedure
        '   a. This estimates Tco for Dreq (i.e. Dmin)
        '

        ' Get Sigma Y (surface-shape factor)
        Dim sigmaY As DoubleParameter = mBorderCriteria.SigmaY
        sigmaY.Value = Me.SigmaY(mInflowRate, mLength, mWidth, S0)
        sigmaY.Source = ValueSources.Calculated
        mBorderCriteria.SigmaY = sigmaY

        Dim upperPhi0Limit As Double = 2.0 / sigmaY.Value
        Dim upperPhi1Limit As Double = 2.0

        ' Compute Basin / Border operations with default Tuning Factors & Open End
        Dim phi0 As DoubleParameter = mBorderCriteria.Phi0Borders
        phi0.Value = DefaultPhi0Borders
        phi0.Source = ValueSources.Calculated
        mBorderCriteria.Phi0Borders = phi0

        Dim phi1 As DoubleParameter = mBorderCriteria.Phi1Borders
        phi1.Value = DefaultPhi1Borders
        phi1.Source = ValueSources.Calculated
        mBorderCriteria.Phi1Borders = phi1

        Dim phi2 As DoubleParameter = mBorderCriteria.Phi2Borders
        phi2.Value = DefaultPhi2Borders
        phi2.Source = ValueSources.Calculated
        mBorderCriteria.Phi2Borders = phi2

        Dim phi3 As DoubleParameter = mBorderCriteria.Phi3Borders
        phi3.Value = DefaultPhi3Borders
        phi3.Source = ValueSources.Calculated
        mBorderCriteria.Phi3Borders = phi3

        ' Compute Border operations with default Tuning Factors
        Dim point As ContourPoint = OperationsPointVolBal()
        If (point.HasError) Then
            If (point.ErrMsg = mDictionary.tAdvanceRecessionInadequateID.Translated) Then
                Me.DisplayTuningPointBadAdvanceMessage()
            Else
                Me.DisplayTuningPointBadMessage(point.ErrMsg)
            End If

            ' Restore Downstream Condition
            downstream = mSystemGeometry.DownstreamCondition
            downstream.Value = mDownstreamValue
            downstream.Source = mDownstreamSource
            mSystemGeometry.DownstreamCondition = downstream

            Me.Running = False
            Return False
        End If

        ' Get data from last operations
        Dim tlBorder As Double = Me.AdvanceTimeToEndOfField
        Dim tr0Border As Double = Me.RecessionTimeAtHeadOfField
        Dim trlBorder As Double = Me.RecessionTimeAtEndOfField
        Dim dminBorder As Double = Me.DMin
        '
        ' 2. Run SRFR simulation and determine:
        '   a. Advance time to end of field
        '   b. Recession time at end of field
        '   c. Infiltrated volume
        '

        ' Set Downstream Condition to Open End
        downstream = mSystemGeometry.DownstreamCondition
        downstream.Value = DownstreamConditions.OpenEnd
        downstream.Source = ValueSources.Calculated
        mSystemGeometry.DownstreamCondition = downstream

        mTco *= 2.0 ' Ensure adequate time for unencumbered advance
        RunSRFR(False, True, True)
        mTco /= 2.0 ' Restore cutoff time

        Dim tcoSrfr As Double = mTco
        Dim tlSrfr As Double = mSurfaceFlow.AdvanceTimeToEndOfField
        Dim tr0Srfr As Double = mSurfaceFlow.RecessionAtHead
        If (Double.IsNaN(tr0Srfr)) Then
            tr0Srfr = Me.TRatDistance(0.0, mWidth, mWidth)
        End If
        Dim trlSrfr As Double = mSurfaceFlow.RecessionAtDistance(mLength)
        trlSrfr = Me.TRatDistance(mLength, mWidth, mWidth)
        Dim tlagSrfr As Double = Math.Max(tr0Srfr - tcoSrfr, MinTlag)
        Dim inVolSrfr As Double = mSubsurfaceFlow.InfiltratedVolume()
        Dim dminSrfr As Double = mSubsurfaceFlow.Dmin.Value

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

            ' Restore Downstream Condition
            downstream = mSystemGeometry.DownstreamCondition
            downstream.Value = mDownstreamValue
            downstream.Source = mDownstreamSource
            mSystemGeometry.DownstreamCondition = downstream

            Me.Running = False
            Return False
        End If

        If ((tlSrfr <= 0.0) Or (trlSrfr <= 0.0)) Then
            Me.DisplayTuningPointBadAdvanceMessage()

            ' Restore Downstream Condition
            downstream = mSystemGeometry.DownstreamCondition
            downstream.Value = mDownstreamValue
            downstream.Source = mDownstreamSource
            mSystemGeometry.DownstreamCondition = downstream

            Me.Running = False
            Return False
        End If
        '
        ' 3. Adjust Phi 0 so Border Operations advance matches SRFR simulation advance
        '
        Me.StatusMessage = mDictionary.tEstimatingPhi0.Translated

        ' Use binary search to match Phi 0 values
        Dim minPhi0 As Double = 0.0
        Dim maxPhi0 As Double = upperPhi0Limit

        ok = False
        For iter As Integer = 0 To 25

            ' Get current value of Phi 0
            phi0 = mBorderCriteria.Phi0Borders

            ' Halve the range for Phi 0 binary search
            If (Double.IsNaN(tlSrfr)) Then
                maxPhi0 = phi0.Value                        ' Too large
            Else
                If (tlSrfr + 0.001 < tlBorder) Then
                    maxPhi0 = phi0.Value                    ' Too large
                ElseIf (tlBorder < tlSrfr - 0.001) Then
                    minPhi0 = phi0.Value                    ' Too small
                Else
                    ok = True
                    Exit For                                ' Just Right
                End If
            End If

            phi0.Value = (minPhi0 + maxPhi0) / 2.0
            phi0.Source = ValueSources.Calculated
            mBorderCriteria.Phi0Borders = phi0

            ProgressMessage = phi0.Value.ToString

            If ((maxPhi0 - minPhi0) < 0.000001) Then
                ok = True
                Exit For
            End If

            ' Compute Border operations with mid-range Phi 0
            point = OperationsPointVolBal()

            tlBorder = Me.AdvanceTimeToEndOfField
            tr0Border = Me.RecessionTimeAtHeadOfField
            trlBorder = Me.RecessionTimeAtEndOfField
            dminBorder = Me.DMin
        Next

        ' If solution is at limit of binary search; this is an error
        If ((Not ok) And (maxPhi0 = upperPhi0Limit)) Then
            Me.DisplayTuningPointBadAdvanceMessage()
            Me.Running = False
            Return False

        Else
            ' Run SRFR with correct Tco
            RunSRFR(False, True, True)

            tcoSrfr = mTco
            tlSrfr = mSurfaceFlow.AdvanceTimeToEndOfField
            tr0Srfr = mSurfaceFlow.RecessionAtHead
            If (Double.IsNaN(tr0Srfr)) Then
                tr0Srfr = Me.TRatDistance(0.0, mWidth, mWidth)
            End If
            trlSrfr = mSurfaceFlow.RecessionAtDistance(mLength)
            trlSrfr = Me.TRatDistance(mLength, mWidth, mWidth)
            tlagSrfr = Math.Max(tr0Srfr - tcoSrfr, MinTlag)
            inVolSrfr = mSubsurfaceFlow.InfiltratedVolume()
            dminSrfr = mSubsurfaceFlow.Dmin.Value
            '
            ' 4. Estimate Phi 1 to match recession at downstream end
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi1.Translated

            Dim minPhi1 As Double = 0.0
            Dim maxPhi1 As Double = upperPhi1Limit

            Dim deltaTime As Double = trlSrfr - tcoSrfr - sTlag
            If (deltaTime < 0.0) Then
                Me.DisplayTuningPointBadAdvanceMessage()
                Me.Running = False
                Return False
            End If

            phi1 = mBorderCriteria.Phi1Borders
            phi1.Value = deltaTime / mDeltaTr
            phi1.Source = ValueSources.Calculated
            mBorderCriteria.Phi1Borders = phi1

            ProgressMessage = phi1.Value.ToString

            ' Compute Border operations with new Phi 1
            point = OperationsPointVolBal()

            tlBorder = Me.AdvanceTimeToEndOfField
            tr0Border = Me.RecessionTimeAtHeadOfField
            trlBorder = Me.RecessionTimeAtEndOfField
            dminBorder = Me.DMin

            ' Check completion status of Phi 1 estimation
            If ((Not ok) And (maxPhi1 = upperPhi1Limit)) Then
                Me.DisplayTuningPointBadAdvanceMessage()
                Me.Running = False
                Return False

            Else ' Phi 1 OK
                '
                ' 5. Calculate Phi 2 to match recession at upstream end
                '
                Me.StatusMessage = mDictionary.tEstimatingPhi2.Translated

                Dim Y0, A0, R0, WP0, Sf As Double
                UpstreamParameters(mInflowRate, mLength, mWidth, S0, Y0, A0, R0, WP0, Sf)

                ' Save Upstream Representative Depth
                Dim upstreamDepth As DoubleParameter = mSurfaceFlow.UpstreamDepth
                upstreamDepth.Value = Y0
                upstreamDepth.Source = ValueSources.Calculated
                mSurfaceFlow.UpstreamDepth = upstreamDepth

                ' Get current value of Phi 2
                phi2 = mBorderCriteria.Phi1Borders

                Dim Qin As Double = mInflowRate / mWidth            ' Unit inflow rate

                Dim num As Double = 0.345 * n * Qin ^ 0.175         ' Recession lag (from eq. 14.34)
                Dim den As Double = mTReq ^ 0.88 * S0 ^ 0.5

                mTlag = (Qin ^ 0.2 * n ^ 1.2) / ((S0 + (num / den)) ^ 1.6)

                ' Calculate new estimate for Phi 2
                phi2.Value = tlagSrfr / mTlag
                phi2.Source = ValueSources.Calculated
                mBorderCriteria.Phi2Borders = phi2

                ProgressMessage = phi2.Value.ToString

                ' Compute operations with new Phi 2
                point = OperationsPointVolBal()

                tlBorder = Me.AdvanceTimeToEndOfField
                tr0Border = Me.RecessionTimeAtHeadOfField
                trlBorder = Me.RecessionTimeAtEndOfField
                dminBorder = Me.DMin

                ' Rerun SRFR simulation with new Phi 2
                RunSRFR(False, True, True)

                tcoSrfr = mTco
                tlSrfr = mSurfaceFlow.AdvanceTimeToEndOfField
                tr0Srfr = mSurfaceFlow.RecessionAtHead
                If (Double.IsNaN(tr0Srfr)) Then
                    tr0Srfr = Me.TRatDistance(0.0, mWidth, mWidth)
                End If
                trlSrfr = mSurfaceFlow.RecessionAtDistance(mLength)
                trlSrfr = Me.TRatDistance(mLength, mWidth, mWidth)
                tlagSrfr = Math.Max(tr0Srfr - tcoSrfr, MinTlag)
                inVolSrfr = mSubsurfaceFlow.InfiltratedVolume()
                dminSrfr = mSubsurfaceFlow.Dmin.Value

                ' Adjust for Dmin < Dreq at head of border
                Dim tau As Double = CDbl(mOppTimes(0))
                Dim dInf0 As Double = mSoilCropProperties.InfiltrationDepth(tau)

                If (dInf0 < mDReq) Then

                    mPhi2 *= (tr0Srfr - mTco) / (tr0Border - mTco)
                    mPhi1 *= trlSrfr / trlBorder

                    phi1 = mBorderCriteria.Phi1Borders
                    phi1.Value = mPhi1
                    phi1.Source = ValueSources.Calculated
                    mBorderCriteria.Phi1Borders = phi1

                    phi2 = mBorderCriteria.Phi1Borders
                    phi2.Value = mPhi2
                    phi2.Source = ValueSources.Calculated
                    mBorderCriteria.Phi2Borders = phi2

                    ' Compute operations with new Phi 1 & 2
                    point = OperationsPointVolBal()

                    tlBorder = Me.AdvanceTimeToEndOfField
                    tr0Border = Me.RecessionTimeAtHeadOfField
                    trlBorder = Me.RecessionTimeAtEndOfField
                    dminBorder = Me.DMin

                    ' Rerun SRFR simulation with new Phi 1 & 2
                    RunSRFR(False, True, True)

                    tcoSrfr = mTco
                    tlSrfr = mSurfaceFlow.AdvanceTimeToEndOfField
                    tr0Srfr = mSurfaceFlow.RecessionAtHead
                    If (Double.IsNaN(tr0Srfr)) Then
                        tr0Srfr = Me.TRatDistance(0.0, mWidth, mWidth)
                    End If
                    trlSrfr = mSurfaceFlow.RecessionAtDistance(mLength)
                    trlSrfr = Me.TRatDistance(mLength, mWidth, mWidth)
                    tlagSrfr = Math.Max(tr0Srfr - tcoSrfr, MinTlag)
                    inVolSrfr = mSubsurfaceFlow.InfiltratedVolume()
                    dminSrfr = mSubsurfaceFlow.Dmin.Value

                End If
                '
                ' Calculate Phi 3 to set recession slope
                '
                Me.StatusMessage = mDictionary.tEstimatingPhi3.Translated

                ' Get current value of Phi 3
                phi3 = mBorderCriteria.Phi3Borders

                If (mTr0 < mTrL) Then
                    Dim minDistX As Double = 0.0
                    Dim maxDistX As Double = mLength
                    Dim distX As Double = (minDistX + maxDistX) / 2.0

                    For iter As Integer = 1 To 25

                        ComputeIrrigationCurves(mWidth, mWidth, distX, mTr0, mTrL, mDMin, mInfiltratedVolume)

                        If (mInfiltratedVolume < inVolSrfr - OneLiter) Then
                            maxDistX = distX                            ' Too small
                        ElseIf (inVolSrfr + OneLiter < mInfiltratedVolume) Then
                            minDistX = distX                            ' Too large
                        Else
                            Exit For                                    ' Just Right
                        End If

                        distX = (minDistX + maxDistX) / 2.0

                        If (ThisClose(minDistX, maxDistX, 0.001)) Then
                            Exit For
                        End If
                    Next

                    phi3.Value = ((mTrL - mTr0) * Qin) / (distX * sigmaY.Value * Y0)
                Else
                    phi3.Value = 0.0
                End If

                phi3.Source = ValueSources.Calculated
                mBorderCriteria.Phi3Borders = phi3

                ProgressMessage = phi3.Value.ToString

            End If ' Phi 1 estimate OK
        End If ' Phi 0 estimate OK
        '
        ' Restore Downstream Condition
        '
        downstream = mSystemGeometry.DownstreamCondition
        downstream.Value = mDownstreamValue
        downstream.Source = mDownstreamSource
        mSystemGeometry.DownstreamCondition = downstream

        ProgressMessage = ""

        mTuningPoint = point

        Me.Running = False
        Return ok
    End Function

#End Region

#Region " Sloping Border w/ Cutback "

    Protected Function EstimateTuningFactorsBorderWithCutback() As Boolean
        Dim ok As Boolean = MyBase.EstimateTuningFactors()
        Me.Running = True

        ' Inflow Rates
        mInflowRate = mInflowManagement.InflowRate.Value
        mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value
        '
        ' Basin / Border Operations only works for Time-Based Cutoff
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

        Dim inflowRate As DoubleParameter = mInflowManagement.InflowRate
        inflowRate.Value = mBorderCriteria.ContourInflowRatePoint.Value
        inflowRate.Source = mBorderCriteria.ContourInflowRatePoint.Source
        mInflowManagement.InflowRate = inflowRate
        mInflowRate = inflowRate.Value
        '
        ' 1. Compute border operations with simplified procedure
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

        ' Compute Basin / Border operations with default Tuning Factors & Open End
        Dim phi0 As DoubleParameter = mBorderCriteria.Phi0Borders
        phi0.Value = DefaultPhi0Borders
        phi0.Source = ValueSources.Calculated
        mBorderCriteria.Phi0Borders = phi0

        Dim phi1 As DoubleParameter = mBorderCriteria.Phi1Borders
        phi1.Value = DefaultPhi1Borders
        phi1.Source = ValueSources.Calculated
        mBorderCriteria.Phi1Borders = phi1

        Dim phi2 As DoubleParameter = mBorderCriteria.Phi2Borders
        phi2.Value = DefaultPhi2Borders
        phi2.Source = ValueSources.Calculated
        mBorderCriteria.Phi2Borders = phi2

        Dim phi3 As DoubleParameter = mBorderCriteria.Phi3Borders
        phi3.Value = DefaultPhi3Borders
        phi3.Source = ValueSources.Calculated
        mBorderCriteria.Phi3Borders = phi3

        Dim slope As Double = mSystemGeometry.AverageSlope

        Dim parameter As IntegerParameter = mSystemGeometry.DownstreamCondition
        If (0.0 < slope) Then
            parameter.Value = DownstreamConditions.OpenEnd
            parameter.Source = ValueSources.Calculated
            mSystemGeometry.DownstreamCondition = parameter
        End If

        ' Compute Border operations with default Tuning Factors
        Dim point As ContourPoint = OperationsPointVolBal()
        If (point.HasError) Then
            Dim title As String = mDictionary.tTuningError.Translated
            Dim msg As String

            msg = mDictionary.tTuningFactorsCalculationFailed.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tError.Translated & ": " + point.ErrMsg
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tToCorrectErrorDo.Translated
            msg += Chr(13)

            If (0 <> (mSetupWarnings And WarningFlags.TimeTooLong)) Then
                msg += Chr(13) + "1) " & mDictionary.tDecreaseInflowRate.Translated
                msg += Chr(13) + "2) " & mDictionary.tDecreaseCutoffTime.Translated
            ElseIf (0 <> (mSetupWarnings And WarningFlags.AdvanceRecessionInadequate)) Then
                msg += Chr(13) + "1) " & mDictionary.tIncreaseInflowRate.Translated
                msg += Chr(13) + "2) " & mDictionary.tIncreaseCutoffTime.Translated
            Else
                msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated
            End If

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
        '
        ' 2. Run SRFR simulation and determine:
        '   a. Advance time to end of field
        '   b. Recession time at end of field
        '   c. Infiltrated volume
        '
        RunSRFR(False, True, True)

        Dim tlSrfr As Double = mSurfaceFlow.AdvanceTimeToEndOfField
        Dim trlSrfr As Double = mSurfaceFlow.RecessionAtDistance(mLength)
        trlSrfr = Me.TRatDistance(mLength, mWidth, mWidth)
        Dim inVolSrfr As Double = mSubsurfaceFlow.InfiltratedVolume()
        Dim dMinSrfr As Double = mSubsurfaceFlow.Dmin.Value
        Dim tcoSrfr As Double = mTco
        Dim tLagSrfr As Double = mSurfaceFlow.RecessionAtDistance(0.0) - tcoSrfr
        tLagSrfr = Me.TRatDistance(0.0, mWidth, mWidth) - tcoSrfr
        Dim tlBorder As Double
        '
        ' 3. Adjust Phi 0 to make Basin / Border Operations advance match SRFR simulation advance
        '   a. This step is performed with an Open End
        '
        Me.StatusMessage = mDictionary.tEstimatingPhi0.Translated

        ' Use binary search to match Phi 0 values
        Dim minPhi0 As Double = 0.0
        Dim maxPhi0 As Double = 2.0 / sigmaY.Value

        For iter As Integer = 0 To 20

            ' Get advance from last Border operations
            tlBorder = Me.AdvanceTimeToEndOfField

            ' Get current value of Phi 0
            phi0 = mBorderCriteria.Phi0Borders

            ' Halve the range for Phi 0 binary search
            If (tlSrfr + 0.001 < tlBorder) Then
                maxPhi0 = phi0.Value                    ' Too large
            ElseIf (tlBorder < tlSrfr - 0.001) Then
                minPhi0 = phi0.Value                    ' Too small
            Else
                Exit For                                ' Just Right
            End If

            phi0.Value = (minPhi0 + maxPhi0) / 2.0
            phi0.Source = ValueSources.Calculated
            mBorderCriteria.Phi0Borders = phi0

            If ((maxPhi0 - minPhi0) < 0.000001) Then
                Exit For
            End If

            ' Compute Border operations with mid-range Phi 0
            point = OperationsPointVolBal()
        Next

        ' If solution is at limit of binary search; this is an error
        If (maxPhi0 = 2.0 / sigmaY.Value) Then
            ok = False
        Else
            '
            ' 4. Estimate Phi 1 to match recession at end of Border
            '   a. This step is performed with an Open End
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi1.Translated

            Dim adjRate As Double = mInflowRate

            Dim deltaTime As Double = trlSrfr - tcoSrfr - sTlag

            If (deltaTime < 0.0) Then
                deltaTime = 0.0
                ok = False
            End If

            If (mInflowManagement.CutbackMethod.Value = CutbackMethods.TimeBased) Then
                adjRate = ((mInflowRate * mTcb) + (mCutbackRate * (mTco - mTcb))) / mTco
            End If

            phi1 = mBorderCriteria.Phi1Borders
            phi1.Value = (deltaTime * adjRate) / mSurfaceVolume2
            phi1.Source = ValueSources.Calculated
            mBorderCriteria.Phi1Borders = phi1

            ' Compute Border operations with new Phi 1
            point = OperationsPointVolBal()

            ' Rerun SRFR simulation with adjusted Basin / Border Operations Tco (based on new Phi 1)
            RunSRFR(False, True, True)

            ' This SRFR run is the standard to which Phi 2 is tuned
            tlSrfr = mSurfaceFlow.AdvanceTimeToEndOfField
            trlSrfr = mSurfaceFlow.RecessionAtDistance(mLength)
            trlSrfr = Me.TRatDistance(mLength, mWidth, mWidth)
            inVolSrfr = mSubsurfaceFlow.InfiltratedVolume()
            dMinSrfr = mSubsurfaceFlow.Dmin.Value
            tcoSrfr = mTco
            tLagSrfr = mSurfaceFlow.RecessionAtDistance(0.0) - tcoSrfr
            tLagSrfr = Me.TRatDistance(0.0, mWidth, mWidth) - tcoSrfr
            '
            ' 5. Estimate Phi 2 to match infiltrated volumes
            '   a. This step is performed with an Open End
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi2.Translated

            Dim Y0, A0, R0, WP0, Sf As Double
            UpstreamParameters(mInflowRate, mLength, mWidth, S0, Y0, A0, R0, WP0, Sf)

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
                Next

                ' Compute infiltrated volume
                Dim inVolBorder As Double = 0.0

                For idx As Integer = 1 To mDistances.Count - 1
                    Dim dist1 As Double = CDbl(mDistances(idx - 1))
                    Dim dist2 As Double = CDbl(mDistances(idx))
                    Dim deltaDist As Double = dist2 - dist1

                    Dim infDepth1 As Double = CDbl(mInfDepths(idx - 1))
                    Dim infDepth2 As Double = CDbl(mInfDepths(idx))
                    Dim avgDepth As Double = (infDepth1 + infDepth2) / 2.0

                    Dim infVolume As Double = deltaDist * mWidth * avgDepth

                    inVolBorder += infVolume
                Next

                ' Compare infiltrated volumes
                If (inVolBorder + 0.00001 < inVolSrfr) Then
                    minTr0 = tr0                            ' Too small
                ElseIf (inVolSrfr < inVolBorder - 0.00001) Then
                    maxTr0 = tr0                            ' Too large
                Else
                    Exit For                                ' Just right
                End If

                tr0 = (minTr0 + maxTr0) / 2.0
            Next

            ' Calculate & save Phi 2
            Dim tlag As Double = tr0 - mTco

            adjRate = mInflowRate
            If (mInflowManagement.CutbackMethod.Value = CutbackMethods.TimeBased) Then
                adjRate = ((mInflowRate * mTcb) + (mCutbackRate * (mTco - mTcb))) / mTco
            End If

            phi2 = mBorderCriteria.Phi2Borders
            phi2.Value = Math.Max(0, tlag * (2.0 * adjRate) / (A0 * mLength))
            phi2.Source = ValueSources.Calculated
            mBorderCriteria.Phi2Borders = phi2
            '
            ' If Basin / Border is Blocked, estimate Phi 3 to compensate for runoff
            '   a. Use Phi 3 to match SRFR's & Basin / Border Design's Runoff Volumes
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi3.Translated

            phi3 = mBorderCriteria.Phi3Borders

            If (mDownstreamValue = DownstreamConditions.BlockedEnd) Then
                If (0.0 < slope) Then
                    parameter = mSystemGeometry.DownstreamCondition
                    parameter.Value = DownstreamConditions.OpenEnd
                    parameter.Source = mDownstreamSource
                    mSystemGeometry.DownstreamCondition = parameter

                    ' Compute Border opertions with new Phi 2
                    point = OperationsPointVolBal()

                    RunSRFR(False, True, False)

                    phi3.Value = mSurfaceFlow.RunoffVolume / mRunoffVolume
                Else
                    phi3.Value = 1.0
                End If
            Else
                phi3.Value = 1.0
            End If

            phi3.Source = ValueSources.Calculated
            mBorderCriteria.Phi3Borders = phi3
        End If

        ' Restore Downstream Condition
        parameter = mSystemGeometry.DownstreamCondition
        parameter.Value = mDownstreamValue
        parameter.Source = mDownstreamSource
        mSystemGeometry.DownstreamCondition = parameter

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

        mTuningPoint = point

        Me.Running = False
        Return ok
    End Function

#End Region

#End Region

#Region " Basin / Border Operations "

    Public Overrides Sub RunOperations(ByVal Method As OperationsMethod)
        Me.StartRun("Basin / Border Operations", True)

        mOperationsMethod = Method

        XTolerance = mCutoffTimeTolerance
        YTolerance = mInflowRateTolerance
        '
        ' Build operations contour grid
        '
        mDepthCriterion = mBorderCriteria.InfiltratedDepthCriterion.Value
        If (Method = OperationsMethod.VolumeBalance) Then
            Me.BuildOperationsGridVolBal()
        Else
            If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.GreenAmpt) Then
                ' Green-Ampt must build contours not refine them
                mWorldWindow.RemoveSrfrStatusHandler()
                Me.BuildOperationsGridSrfrSim()
                mWorldWindow.AddSrfrStatusHandler()
            Else ' Kostiakov derived infiltration
                If (mContourGrid IsNot Nothing) Then ' Volume Balance grid has been built; refine it
                    mWorldWindow.RemoveSrfrStatusHandler()
                    Me.RefineOperationsGridSrfrSim()
                    mWorldWindow.AddSrfrStatusHandler()
                Else ' There is no Contour Grid; build it
                    mWorldWindow.RemoveSrfrStatusHandler()
                    Me.BuildOperationsGridSrfrSim()
                    mWorldWindow.AddSrfrStatusHandler()
                End If
            End If
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
        Me.BuildValueCurve(label, "Dreq", DLfIndex, CSng(dreq), DLfTolerance, Units.Millimeters)
        Me.Precision = Globals.ContourPrecision.Standard
        '
        ' Basin / Border operations only works for Time-Based Cutoff
        '
        Dim cutoff As IntegerParameter = mInflowManagement.CutoffMethod
        If Not (cutoff.Value = CutoffMethods.TimeBased) Then
            cutoff.Value = CutoffMethods.TimeBased
            cutoff.Source = ValueSources.Calculated
            mInflowManagement.CutoffMethod = cutoff
        End If
        '
        ' Level wo/ Cutback requires Blocked End
        '
        Dim slope As Double = mSystemGeometry.AverageSlope
        If ((mCutbackMethod = CutbackMethods.NoCutback) And (slope <= MaximumLevelSlope)) Then
            Dim downstream As IntegerParameter = mSystemGeometry.DownstreamCondition
            downstream.Value = DownstreamConditions.BlockedEnd
            downstream.Source = ValueSources.Calculated
            mSystemGeometry.DownstreamCondition = downstream
        End If
        '
        ' Build contour polygons using contour cells as guides
        '
        mContourGrid.ClearContours()

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
        Next

        MyBase.EndRun()
    End Sub

#End Region

#Region " Basin / Border Operations Point - Volume Balance "

    '******************************************************************************************
    ' Compute Basin / Border Operations Point using Volume Balance calculations
    '
    Protected Overloads Overrides Function OperationsPointVolBal() As ContourPoint
        Dim point As ContourPoint = Nothing

        Dim cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)

        Select Case (cutoffMethod)
            Case CutoffMethods.DistanceBased
                Debug.Assert(False, "Basin / Border Operations does not support Distance-Based Cutoff")

            Case Else ' Assume CutoffMethods.TimeBased
                If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                    point = OperationsPointVolBal(mInflowRate, mWidth, mTco, NumWddPoints)
                Else ' Assume Cutback
                    mCutbackRate = mInflowRate * mCutbackRateRatio
                    point = OperationsPointVolBal(mInflowRate, mWidth, mTco, mCutbackRate, NumWddPoints)
                End If
        End Select

        Return point
    End Function

    '*********************************************************************************************************
    ' Function OperationsPointVolBal() - Compute a Basin/Border Operations Point with NO Cutback
    '                                    using Volume Balance calculations
    '
    ' Called By:    Build Operations Grid   - to calculate the Operations Point at a Contour Grid Point
    '
    ' Input(s):     InflowRate              - Qin
    '               BorderWidth             - Border Width
    '               CutoffTime              - Tco
    '               NumDistances            - Number of points for Advance Curve
    '
    ' Returns:      ContourPoint            - the Operations Point
    '
    ' Function is adapted from Bert Clemmen's Border Operations algorithm found BorderDesign2005.xls
    '*********************************************************************************************************
    Protected Overloads Overrides Function OperationsPointVolBal(ByVal InflowRate As Double,
                                                           ByVal BorderWidth As Double,
                                                           ByVal CutoffTime As Double,
                                                           ByVal NumDistances As Integer) As ContourPoint
        Debug.Assert(0 < InflowRate)
        Debug.Assert(0 < BorderWidth)
        Debug.Assert(0 < CutoffTime)
        Debug.Assert(0 < NumDistances)

        ' Instantiate/initialize SRFR Infiltration object; its used for infiltration calculations
        mSoilCropProperties.SetSrfrInfiltration()
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.BorderWidth = BorderWidth
        mSoilCropProperties.SrfrInfiltration.RefInflow.Q0 = InflowRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.Tco = CutoffTime
        mSoilCropProperties.SrfrInfiltration.RefInflow.L = mLength

        '**************************************************************************************
        ' Step 1: Get input conditions
        '
        mSigmaY = mBorderCriteria.SigmaY.Value                      ' Tuning factors
        mPhi0 = mBorderCriteria.Phi0Borders.Value
        mPhi1 = mBorderCriteria.Phi1Borders.Value
        mPhi2 = mBorderCriteria.Phi2Borders.Value
        mPhi3 = mBorderCriteria.Phi3Borders.Value

        mArea = mLength * BorderWidth                               ' System Geometry

        mDReq = mInflowManagement.RequiredDepth.Value               ' Infiltration requirements
        mTReq = mSoilCropProperties.InfiltrationTime(mDReq)

        mDepthCriterion = mBorderCriteria.InfiltratedDepthCriterion.Value

        Dim iter As Integer ' Loop iteration

        '**************************************************************************************
        ' Step 2: Compute upstream representative depth, flow area & velocity, etc.
        '
        Dim Qin As Double = InflowRate

        Dim L1 As Double = mLength / 2.0
        Dim Y01, A01, R01, WP01, Sf1 As Double
        UpstreamParameters(Qin, L1, BorderWidth, S0, Y01, A01, R01, WP01, Sf1)
        Dim V01 As Double = InflowRate / Y01

        Dim L2 As Double = mLength
        Dim Y02, A02, R02, WP02, Sf2 As Double
        UpstreamParameters(Qin, L2, BorderWidth, S0, Y02, A02, R02, WP02, Sf2)
        Dim V02 As Double = InflowRate / Y02

        Dim Dmax As Double = mSystemGeometry.Depth.Value

        '**************************************************************************************
        ' Step 3: Compute 2-point advance
        '
        ComputeTwoPointAdvance(L1, A01, V01, L2, A02, V02, BorderWidth, BorderWidth, Qin, NumDistances)

        '**************************************************************************************
        ' Step 4: Compute Performance (w/ Horizontal Recession)
        '   (not supported by WinSRFR)
        '
        Qin = InflowRate / BorderWidth                      ' Unit inflow rate
        mInflowVolume = CutoffTime * InflowRate             ' Inflow volume

        Dim num As Double = 0.345 * n * Qin ^ 0.175         ' Recession lag (from eq. 14.34)
        Dim den As Double = mTReq ^ 0.88 * S0 ^ 0.5

        mTlag = (mPhi2 * Qin ^ 0.2 * n ^ 1.2) / ((S0 + (num / den)) ^ 1.6)

        '**************************************************************************************
        ' Step 5: Compute Performance (w/ Adjusted Recession)
        '
        If (S0 <= MaximumLevelSlope) Then
            '
            ' Field is considered level; use graph based algorithm
            '
            Dim graphSlope As Double = (1.05 - 1.0) / (1.2 - 1.0)   ' 0.25

            Dim Davg As Double = mInflowVolume / mArea
            Dim Tavg As Double = mSoilCropProperties.InfiltrationTime(Davg)

            Dim minTrL As Double = mAdvanceTime2
            Dim maxTrL As Double = mAdvanceTime2 + Tavg

            ' Binary search for TrL that matches Tco
            For iter = 1 To 25

                mTrL = (minTrL + maxTrL) / 2.0

                ' Level recession at TrL
                ComputeIrrigationCurves(BorderWidth, InflowRate, mTrL, mTrL, mDMin, mInfiltratedVolume)

                If (0.0 < mDMin) Then
                    ' Average infiltrated depth
                    Davg = mInfiltratedVolume / mArea

                    ' Tco for level recession
                    Dim tcox As Double = mInfiltratedVolume / InflowRate

                    ' Tco adjustment (from Davg/Dreq vs. tco/tcox graph)

                    mDepthRatio = Davg / mDMin
                    Dim depthDelta As Double = mDepthRatio - 1.0

                    Dim tcoDelta As Double = depthDelta * graphSlope * mPhi1
                    mTcoRatio = tcoDelta + 1.0

                    ' Adjusted Tco & Inflow Volume
                    Dim tco As Double = tcox * mTcoRatio

                    If (tco < CutoffTime - TenSeconds) Then
                        minTrL = mTrL                                           ' Too small
                    ElseIf (CutoffTime + TenSeconds < tco) Then
                        maxTrL = mTrL                                           ' Too large
                    Else
                        Exit For                                                ' Just right
                    End If

                    If (ThisClose(minTrL, maxTrL, TenSeconds)) Then
                        Exit For
                    End If
                Else
                    minTrL = mTrL                                               ' Too small
                End If
            Next
            '
            ' Find Tr0 that matches Infiltrated Volume with Inflow Volume
            '
            If (mInfiltratedVolume < mInflowVolume) Then

                Dim minTr0 As Double = CutoffTime
                Dim maxTr0 As Double = mTrL * 2.0

                For iter = 1 To 25
                    mTr0 = (minTr0 + maxTr0) / 2.0

                    ' Compute recession & infiltrated volume with new Tr0
                    ComputeIrrigationCurves(BorderWidth, InflowRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                    If (mInfiltratedVolume < mInflowVolume - OneLiter) Then
                        minTr0 = mTr0                                           ' Too small
                    ElseIf (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                        maxTr0 = mTr0                                           ' Too large
                    Else
                        Exit For                                                ' Just right
                    End If
                Next ' iter

            Else ' mInflowVolume < mInfiltratedVolume

                minTrL = 0.0
                maxTrL = mTrL

                For iter = 1 To 25
                    mTrL = (minTrL + maxTrL) / 2.0

                    ' Compute recession & infiltrated volume with new mTrL
                    ComputeIrrigationCurves(BorderWidth, InflowRate, mTrL, mTrL, mDMin, mInfiltratedVolume)

                    If (mInfiltratedVolume < mInflowVolume - OneLiter) Then
                        minTrL = mTrL                                           ' Too small
                    ElseIf (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                        maxTrL = mTrL                                           ' Too large
                    Else
                        Exit For                                                ' Just right
                    End If
                Next ' iter
            End If ' mInfiltratedVolume < mInflowVolume

            ' Blocked End; there is no Runoff
            mInfiltratedVolume = mInflowVolume
            mRunoffVolume = 0

            mDeltaTr = 3.27

        Else ' MaximumLevelSlope < S0

            Dim tr0s1 As Double = mAdvanceTime2 + CutoffTime + mTlag    ' Estimated / Actual tR(0)s
            Dim tr0s2 As Double = 0

            Dim minTr0s1 As Double = 0.0                        ' Search limits
            Dim maxTr0s1 As Double = tr0s1

            Dim lastDeltaTr As Double = 0                       ' Last valid mDeltaTr

            Dim avgInfRate, Sy As Double

            For iter = 1 To 25

                ' Compute irrigation curves w/ level recession
                mDistances.Clear()
                mAdvTimes.Clear()
                mRecTimes.Clear()
                mOppTimes.Clear()
                mInfRates.Clear()

                avgInfRate = 0.0

                For idx As Integer = 0 To NumDistances - 1
                    Dim X As Double = (mLength * idx) / (NumDistances - 1)
                    Dim Tadv As Double = mAdvanceTime2 * (X / mLength) ^ h
                    Dim Trec As Double = tr0s1
                    Dim Tau As Double = Math.Max(Trec - Tadv, 0)
                    Dim dZdT As Double = mSoilCropProperties.InfiltrationRate(Tau)

                    mDistances.Add(X)
                    mAdvTimes.Add(Tadv)
                    mRecTimes.Add(Trec)
                    mOppTimes.Add(Tau)
                    mInfRates.Add(dZdT)

                    avgInfRate += dZdT
                Next

                avgInfRate /= NumDistances

                If (OneMinute < CDbl(mOppTimes(NumDistances - 1))) Then
                    ' Calculate Sy (eq. 14.32)
                    num = Math.Max((Qin - (avgInfRate * mLength)) * n, 0.0)
                    den = S0 ^ 0.5
                    Sy = ((num / den) ^ 0.6) / mLength

                    ' Calculate delta Tr (eq. 14.31)
                    num = (0.666 * n ^ 0.4757) * (Sy ^ 0.2074) * (mLength ^ 0.6829)
                    den = (avgInfRate ^ 0.5244) * (S0 ^ 0.2378)
                    mDeltaTr = num / den

                    If (0.0 < mDeltaTr) Then
                        lastDeltaTr = mDeltaTr

                        ' Check tr0s
                        tr0s2 = mAdvanceTime2 + mTReq - mDeltaTr

                        If (tr0s1 > tr0s2 + OneSecond) Then
                            maxTr0s1 = tr0s1
                        ElseIf (tr0s1 < tr0s2 - OneSecond) Then
                            minTr0s1 = tr0s1
                        Else
                            Exit For
                        End If
                    Else
                        minTr0s1 = tr0s1
                    End If
                Else
                    minTr0s1 = tr0s1
                End If

                If (ThisClose(minTr0s1, maxTr0s1, OneSecond)) Then
                    Exit For
                End If

                tr0s1 = (minTr0s1 + maxTr0s1) / 2.0
            Next

            If (mDeltaTr = 0.0) Then
                mDeltaTr = lastDeltaTr
            End If

            ' Adjusted Recession time at end of Border
            sTlag = (Y02 * mLength) / (2.0 * Qin)     ' Strelkoff's Tlag
            mTrL = CutoffTime + sTlag + mPhi1 * mDeltaTr

            ' Recession time at head of border
            mTr0 = CutoffTime + mTlag

            Dim distX As Double

            num = (mTrL - mTr0) * Qin
            den = mPhi3 * mSigmaY * Y02
            If (0.0 < den) Then
                distX = num / den
            Else
                distX = mLength
            End If

            If (distX < 0.0) Then
                distX = 0.0
            ElseIf (distX > mLength) Then
                distX = mLength
            End If

            ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
            ComputeIrrigationCurves(BorderWidth, BorderWidth, distX, mTr0, mTrL, mDMin, mInfiltratedVolume)

            ' Inflow & Runoff volumes
            mInflowVolume = InflowRate * CutoffTime
            mRunoffVolume = Math.Max(mInflowVolume - mInfiltratedVolume, 0)

            '**************************************************************************************
            ' Step 6: Adjust for Blocked End, if necessary
            '
            If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
                If (0 < mRunoffVolume) Then
                    If (0.0 < S0) Then
                        ' Add infiltration due to ponding at end of field
                        AddSlopingFieldPond(BorderWidth, BorderWidth, mRunoffVolume, mDMin, mInfiltratedVolume)
                    Else ' Slope is level
                        ' Compute irrigation curves with added Runoff
                        Dim Dro As Double = mRunoffVolume / BorderWidth / mLength
                        Dim Z As Double = CDbl(mInfDepths(mInfDepths.Count - 1)) + Dro

                        For pass As Integer = 1 To 25

                            Dim Tau As Double = mSoilCropProperties.InfiltrationTime(Z)
                            Dim deltaTime As Double = Tau - CDbl(mOppTimes(mOppTimes.Count - 1))

                            mTr0 += deltaTime
                            mTrL += deltaTime

                            num = (mTrL - mTr0) * Qin
                            den = mPhi3 * mSigmaY * Y02
                            If (0.0 < den) Then
                                distX = num / den
                            Else
                                distX = mLength
                            End If

                            If (distX < 0.0) Then
                                distX = 0.0
                            ElseIf (distX > mLength) Then
                                distX = mLength
                            End If

                            ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
                            ComputeIrrigationCurves(BorderWidth, BorderWidth, distX, mTr0, mTrL, mDMin, mInfiltratedVolume)

                            If (mInfiltratedVolume < mInflowVolume - OneLiter) Then
                                Dim deltaVolume As Double = mInflowVolume - mInfiltratedVolume
                                Dim deltaDepth As Double = deltaVolume / BorderWidth / mLength
                                Z += deltaDepth
                            ElseIf (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                                Dim deltaVolume As Double = mInfiltratedVolume - mInflowVolume
                                Dim deltaDepth As Double = deltaVolume / BorderWidth / mLength
                                Z -= deltaDepth
                            Else
                                Exit For
                            End If
                        Next
                    End If
                Else ' No runoff
                    ' Check for too much infiltration
                    If (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                        ' Remove excess infiltration
                        Dim excessDepth As Double = (mInfiltratedVolume - mInflowVolume) / BorderWidth / mLength

                        ' Remove excess depth from top of Border
                        Dim Z As Double = Math.Max(mInfDepths(0) - excessDepth, 0.0)

                        If (0.0 < Z) Then
                            ' Binary search for depth where Inflow Volume = Infiltrated Volume
                            For pass As Integer = 1 To 25

                                Dim Tau As Double = mSoilCropProperties.InfiltrationTime(Z)
                                Dim deltaTime As Double = mOppTimes(0) - Tau

                                mTr0 -= deltaTime
                                mTrL -= deltaTime

                                num = (mTrL - mTr0) * Qin
                                den = mPhi3 * mSigmaY * Y02
                                If (0.0 < den) Then
                                    distX = num / den
                                Else
                                    distX = mLength
                                End If

                                If (distX < 0.0) Then
                                    distX = 0.0
                                ElseIf (distX > mLength) Then
                                    distX = mLength
                                End If

                                ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
                                ComputeIrrigationCurves(BorderWidth, BorderWidth, distX, mTr0, mTrL, mDMin, mInfiltratedVolume)

                                If (mInfiltratedVolume < mInflowVolume - OneLiter) Then
                                    Dim deltaVolume As Double = mInflowVolume - mInfiltratedVolume
                                    Dim deltaDepth As Double = deltaVolume / BorderWidth / mLength
                                    Z += deltaDepth
                                ElseIf (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                                    Dim deltaVolume As Double = mInfiltratedVolume - mInflowVolume
                                    Dim deltaDepth As Double = deltaVolume / BorderWidth / mLength
                                    Z -= deltaDepth
                                Else
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If

                ' Inflow & Infiltrated volume
                mInflowVolume = InflowRate * CutoffTime
                mInfiltratedVolume = mInflowVolume

                ' Blocked End; there is no Runoff
                mRunoffVolume = 0
            Else ' Open End

                ' Infiltrated Volume cannot be greater than Inflow Volume (can't create water!)
                If ((mInflowVolume < mInfiltratedVolume) And (mInfiltratedVolume < mInflowVolume + OneLiter)) Then
                    mInfiltratedVolume = mInflowVolume
                End If

                ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
                If (mInflowVolume + OneLiter < mInfiltratedVolume) Then

                    ' distX should be greater than it is now but less than the field length
                    Dim minDistX As Double = distX
                    Dim maxDistX As Double = mLength

                    For iter = 1 To 25
                        distX = (minDistX + maxDistX) / 2.0

                        ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
                        ComputeIrrigationCurves(BorderWidth, BorderWidth, distX, mTr0, mTrL, mDMin, mInfiltratedVolume)

                        If (mInfiltratedVolume < mInflowVolume - OneLiter) Then
                            maxDistX = distX                                        ' Too small
                        ElseIf (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                            minDistX = distX                                        ' Too large
                        Else
                            mInfiltratedVolume = mInflowVolume
                            Exit For                                                ' Just right
                        End If

                        If (ThisClose(minDistX, maxDistX, OneMillimeter)) Then
                            mInfiltratedVolume = mInflowVolume
                            Exit For                                                ' Just right
                        End If
                    Next
                End If ' mInflowVolume < mInfiltratedVolume

                ' Runoff volume
                mRunoffVolume = Math.Max(mInflowVolume - mInfiltratedVolume, 0)
            End If ' If Blocked & Runoff
        End If ' S0 <= MaximumLevelSlope

        '**************************************************************************************
        ' Compute & load performance parameters into Contour Point
        '**************************************************************************************
        ComputePerformanceParameters(mLength, BorderWidth)

        Dim parameter As SingleParameter
        Dim contourPoint As ContourPoint = New ContourPoint

        ' Move errors & warnings, if any, to Contour Point
        If (S0 < MaximumLevelSlope) Then
            ' Limit Line applies only to Level Basins
            If (mXR < DesignLimitLine) Then
                AddExecutionWarning(WarningFlags.LimitLineExceeded,
                                    mDictionary.tLimitLineExceededID.Translated,
                                    mDictionary.tLimitLineExceededDetail.Translated)
                contourPoint.HasError = True
                contourPoint.ErrMsg = mDictionary.tLimitLineExceededID.Translated
            End If
        End If

        If ((mDeltaTr = 0.0) Or (Double.IsNaN(mTL)) Or (mTL = 0.0)) Then
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
        contourPoint.Y = New SingleParameter(CSng(InflowRate), Units.Cms)

        parameter = New SingleParameter(CSng(BorderWidth), Units.Meters)
        contourPoint.Z.Add(parameter)   ' Border Width

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
            contourPoint.Z.Add(parameter)   ' Low-Quarter Depth
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
    ' Function is adapted from Bert Clemmen's Border Operations algorithm found BorderDesign2005.xls
    '*********************************************************************************************************
    Protected Overloads Overrides Function OperationsPointVolBal(ByVal InflowRate As Double,
                                                                 ByVal BorderWidth As Double,
                                                                 ByVal CutoffTime As Double,
                                                                 ByVal CutbackRate As Double,
                                                                 ByVal NumDistances As Integer) As ContourPoint
        Debug.Assert(0 < InflowRate)
        Debug.Assert(0 < BorderWidth)
        Debug.Assert(0 < CutoffTime)
        Debug.Assert(0 < NumDistances)

        ' Instantiate/initialize SRFR Infiltration object; its used for infiltration calculations
        mSoilCropProperties.SetSrfrInfiltration()
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.BorderWidth = BorderWidth
        mSoilCropProperties.SrfrInfiltration.RefInflow.Q0 = InflowRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.Qcb = CutbackRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.Tco = CutoffTime
        mSoilCropProperties.SrfrInfiltration.RefInflow.L = mLength

        ' If cutback rate is 0.0, use method without cutback
        If (CutbackRate <= 0.0) Then
            Return OperationsPointVolBal(InflowRate, BorderWidth, CutoffTime, NumDistances)
        End If

        Dim cutbackTime As Double = CutoffTime * mCutbackTimeRatio

        '**************************************************************************************
        ' Step 1: Get input conditions
        '
        mSigmaY = mBorderCriteria.SigmaY.Value                      ' Tuning factors
        mPhi0 = mBorderCriteria.Phi0Borders.Value
        mPhi1 = mBorderCriteria.Phi1Borders.Value
        mPhi2 = mBorderCriteria.Phi2Borders.Value
        mPhi3 = mBorderCriteria.Phi3Borders.Value

        mArea = mLength * BorderWidth                               ' System Geometry

        Dim Dmax As Double = mSystemGeometry.Depth.Value

        '**************************************************************************************
        ' Step 2: Compute upstream depths & flow areas (before & after cutback)
        '
        Dim Qin As Double = InflowRate

        Dim L1 As Double = mLength / 2.0
        Dim Y01, A01, R01, WP01, Sf1 As Double
        UpstreamParameters(Qin, L1, BorderWidth, S0, Y01, A01, R01, WP01, Sf1)
        Dim V01 As Double = InflowRate / Y01

        Dim L2 As Double = mLength
        Dim Y02, A02, R02, WP02, Sf2 As Double
        UpstreamParameters(Qin, L2, BorderWidth, S0, Y02, A02, R02, WP02, Sf2)
        Dim V02 As Double = InflowRate / Y02

        Dim Y0cb, A0cb, R0cb, WP0cb, Sfcb As Double
        UpstreamParameters(mCutbackRate, L2, BorderWidth, S0, Y0cb, A0cb, R0cb, WP0cb, Sfcb)
        Dim V0cb As Double = mCutbackRate / Y0cb

        '**************************************************************************************
        ' Step 3: Compute 2-point advance
        '
        ComputeTwoPointAdvance(L1, A01, V01, L2, A02, V02, BorderWidth, BorderWidth, Qin, NumDistances)

        '**************************************************************************************
        ' Step 4: Determine needed cutback time
        '
        mDReq = mInflowManagement.RequiredDepth.Value       ' Infiltration requirements
        mTReq = mSoilCropProperties.InfiltrationTime(mDReq)

        mTrL = mTReq + mAdvanceTime2

        Dim zTolerance As Double = 0.000000001
        Dim minCutbackTime As Double = mAdvanceTime2
        Dim maxCutbackTime As Double = Math.Max(CutoffTime, mTrL)
        Dim estCutbackTime As Double = (minCutbackTime + maxCutbackTime) / 2
        Dim reqAvgInfRate As Double = CutbackRate / mArea

        Dim infRates As ArrayList = New ArrayList

        Try
            For iter As Integer = 1 To 25

                ' Compute irrigation curves
                mDistances.Clear()
                mAdvTimes.Clear()
                mRecTimes.Clear()
                mOppTimes.Clear()
                infRates.Clear()

                For idx As Integer = 0 To NumDistances - 1
                    Dim X As Double = (mLength * idx) / (NumDistances - 1)
                    Dim Tadv As Double = mAdvanceTime2 * (X / mLength) ^ h
                    Dim Trec As Double = estCutbackTime
                    Dim Tau As Double = Math.Max(Trec - Tadv, 0)
                    Dim dZdT As Double = mSoilCropProperties.InfiltrationRate(Tau)

                    mDistances.Add(X)
                    mAdvTimes.Add(Tadv)
                    mRecTimes.Add(Trec)
                    mOppTimes.Add(Tau)
                    infRates.Add(DInf)
                Next

                ' Compute average flow rate using integration
                Dim intFlowRate As Double = 0.0

                For idx As Integer = 1 To NumDistances - 1
                    Dim dist1 As Double = CDbl(mDistances(idx - 1))
                    Dim dist2 As Double = CDbl(mDistances(idx))
                    Dim deltaDist As Double = dist2 - dist1

                    Dim infRate1 As Double = CDbl(infRates(idx - 1))
                    Dim infRate2 As Double = CDbl(infRates(idx))
                    Dim avgRate As Double = (infRate1 + infRate2) / 2.0

                    intFlowRate += deltaDist * BorderWidth * avgRate
                Next

                Dim avgInfRate As Double = intFlowRate / mArea
                Dim infRateErr As Double = avgInfRate - reqAvgInfRate

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

            Next
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
        Dim adjSurfaceVolume As Double = (mSigmaY * mPhi0) * A0cb * mLength
        cutbackTime = estCutbackTime - (mSurfaceVolume2 - adjSurfaceVolume) / (InflowRate - CutbackRate)

        ' Cutback time is limited by Cutoff time
        If (cutbackTime > CutoffTime) Then
            cutbackTime = CutoffTime
        End If

        Dim adjRate As Double = ((InflowRate * cutbackTime) + (CutbackRate * (CutoffTime - cutbackTime))) / CutoffTime

        ' Recession lag & recession time at head of Border
        mTlag = (mPhi2 * A02 * mLength) / (2 * adjRate)
        mTr0 = CutoffTime + mTlag
        If (S0 <= 0.0) Then
            mTr0 = CutoffTime + mTlag
        End If

        ' Recession time at end of Border
        sTlag = (Y02 * mLength) / (2.0 * Qin)     ' Strelkoff's Tlag
        mTrL = CutoffTime + sTlag + (mPhi1 * (mSurfaceVolume2 / adjRate))

        ' Compute irrigation curves
        ComputeIrrigationCurves(BorderWidth, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

        ' Inflow & Runoff volumes
        mInflowVolume = InflowRate * cutbackTime + CutbackRate * (CutoffTime - cutbackTime)
        mRunoffVolume = Math.Max(mInflowVolume - mInfiltratedVolume, 0)

        '**************************************************************************************
        ' Step 7 - Adjust for Blocked End, if necessary
        '
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
            If (0 < mRunoffVolume) Then
                If (0.0 < S0) Then
                    ' Add infiltration due to ponding at end of field
                    AddSlopingFieldPond(BorderWidth, BorderWidth, mRunoffVolume, mDMin, mInfiltratedVolume)
                Else ' Slope is level
                    ' Compute irrigation curves with added Runoff
                    Dim Dro As Double = mRunoffVolume / BorderWidth / mLength
                    Dim Z As Double = mInfDepths(mInfDepths.Count - 1) + Dro

                    For pass As Integer = 1 To 25

                        Dim Tau As Double = mSoilCropProperties.InfiltrationTime(Z)
                        Dim deltaTime As Double = Tau - mOppTimes(mOppTimes.Count - 1)

                        mTr0 += deltaTime
                        mTrL += deltaTime

                        ComputeIrrigationCurves(BorderWidth, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                        If (mInfiltratedVolume < mInflowVolume - OneLiter) Then
                            Dim deltaVolume As Double = mInflowVolume - mInfiltratedVolume
                            Dim deltaDepth As Double = deltaVolume / BorderWidth / mLength
                            Z += deltaDepth
                        ElseIf (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                            Dim deltaVolume As Double = mInfiltratedVolume - mInflowVolume
                            Dim deltaDepth As Double = deltaVolume / BorderWidth / mLength
                            Z -= deltaDepth
                        Else
                            Exit For
                        End If
                    Next
                End If
            Else ' No runoff
                ' Check for too much infiltration
                If (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                    ' Remove excess infiltration
                    Dim excessDepth As Double = (mInfiltratedVolume - mInflowVolume) / BorderWidth / mLength

                    ' Remove excess depth from top of Border
                    Dim Z As Double = Math.Max(mInfDepths(0) - excessDepth, 0.0)

                    If (0.0 < Z) Then
                        ' Binary search for depth where Inflow Volume = Infiltrated Volume
                        For pass As Integer = 1 To 25

                            Dim Tau As Double = mSoilCropProperties.InfiltrationTime(Z)
                            Dim deltaTime As Double = mOppTimes(0) - Tau

                            mTr0 -= deltaTime
                            mTrL -= deltaTime

                            ComputeIrrigationCurves(BorderWidth, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                            If (mInfiltratedVolume < mInflowVolume - OneLiter) Then
                                Dim deltaVolume As Double = mInflowVolume - mInfiltratedVolume
                                Dim deltaDepth As Double = deltaVolume / BorderWidth / mLength
                                Z += deltaDepth
                            ElseIf (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                                Dim deltaVolume As Double = mInfiltratedVolume - mInflowVolume
                                Dim deltaDepth As Double = deltaVolume / BorderWidth / mLength
                                Z -= deltaDepth
                            Else
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If

            ' Inflow & Infiltrated volumes
            If (cutbackTime < CutoffTime) Then
                mInflowVolume = InflowRate * cutbackTime + CutbackRate * (CutoffTime - cutbackTime)
            Else
                mInflowVolume = InflowRate * CutoffTime
            End If

            ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
            If ((mInflowVolume < mInfiltratedVolume) And (mInfiltratedVolume < mInflowVolume * 1.01)) Then
                mInfiltratedVolume = mInflowVolume
            End If

            ' Blocked End; there is no Runoff
            mRunoffVolume = 0
        End If

        '**************************************************************************************
        ' Compute & load performance parameters into Contour Point
        '**************************************************************************************
        ComputePerformanceParameters(mLength, BorderWidth)

        Dim parameter As SingleParameter
        Dim contourPoint As ContourPoint = New ContourPoint

        ' Move errors & warnings, if any, to Contour Point
        If ((Double.IsNaN(mTL)) Or (mTL = 0.0)) Then
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

        If (cutbackTime > CutoffTime - 0.1) Then
            cutbackTime = CutoffTime
            AddExecutionWarning(WarningFlags.TcbLimitedToTco,
                                mDictionary.tTcbLimitedToTcoID.Translated,
                                mDictionary.tTcbLimitedToTcoDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tTcbLimitedToTcoID.Translated
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
        contourPoint.Y = New SingleParameter(CSng(InflowRate), Units.Cms)

        parameter = New SingleParameter(CSng(BorderWidth), Units.Meters)
        contourPoint.Z.Add(parameter)   ' Border Width

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

        parameter = New SingleParameter(CSng(cutbackTime / CutoffTime), Units.None)
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
        Dim inflowTable As DataTable = mInflowManagement.HydrographInflowTable(mInflowRate, mTco,
                                                                               mCutbackRate, mTcb)
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

    Public Overrides Sub CheckGeometryErrors()
        MyBase.CheckGeometryErrors()

        ' Level Basins must have Blocked Ends
        If (mSystemGeometry.AverageSlope <= MaximumLevelSlope) Then
            If Not (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
                AddSetupError(ErrorFlags.LevelBasinNotBlocked, _
                         mDictionary.tLevelBasinNotBlockedID.Translated, _
                         mDictionary.tLevelBasinNotBlockedDetails.Translated)
            End If
        End If

    End Sub

    Public Overrides Sub CheckInflowErrors()
        MyBase.CheckInflowErrors()

        ' Only Time-Based Cutoff is supported
        If Not (mInflowManagement.CutoffMethod.Value = CutoffMethods.TimeBased) Then
            AddSetupError(ErrorFlags.CutoffOptionNotSupported, _
                     mDictionary.tCutoffOptionNotSupportID.Translated, _
                     mDictionary.tCutoffOptionNotSupportDetails.Translated)
        End If

        ' Cutback is not supported
        If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            AddSetupError(ErrorFlags.CutbackNotSupported, _
                     mDictionary.tCutbackNotSupportedID.Translated, _
                     mDictionary.tCutbackBasinBorderNotSupportedDetails.Translated)
        End If
    End Sub

    Public Overrides Sub CheckContourCriteriaErrors()
        MyBase.CheckContourCriteriaErrors()

        If (mBorderCriteria.OperationsMethod.Value = OperationsMethod.VolumeBalance) Then
            ' Tuning Factors must not be default values
            If ((mBorderCriteria.Phi0Borders.Source = ValueSources.Defaulted) _
             Or (mBorderCriteria.Phi1Borders.Source = ValueSources.Defaulted) _
             Or (mBorderCriteria.Phi2Borders.Source = ValueSources.Defaulted) _
             Or (mBorderCriteria.Phi3Borders.Source = ValueSources.Defaulted)) Then
                AddSetupWarning(WarningFlags.DefaultTuningFactors,
                       mDictionary.tDefaultTuningFactorsID.Translated,
                       mDictionary.tDefaultTuningFactorsDetails.Translated)
            End If
        End If

    End Sub

#End Region

End Class
