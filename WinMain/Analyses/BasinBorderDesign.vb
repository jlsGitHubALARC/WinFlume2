
'*************************************************************************************************************
' Class:    BasinBorderDesign
'
' This class provides data and methods specific to Basin / Border Design:
'
'   * Setup/execution warnings & errors
'   * Contour Tuning Point & Factors
'   * Design Execution
'   * Design Point Computation
'   * Contour Point Access
'*************************************************************************************************************
Imports DataStore

Public Class BasinBorderDesign
    Inherits DesignAnalysis

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

    Public Property MinXR As Double = 1.0
    Public Property MinPAE As Double = 0.6

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
    ' Estimate Basin/Border Design Tuning Factors
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

        mSoilCropProperties.ClrSrfrInfiltration()

        Return ok
    End Function

#Region " Level Basin "

    Protected Function EstimateTuningFactorsLevelBasin() As Boolean
        Dim ok As Boolean = MyBase.EstimateTuningFactors()
        Me.Running = True
        Me.Tuning = True

        Dim point As ContourPoint = Nothing

        '
        ' Basin / Border Design only works for Time-Based Cutoff
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
        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            ' Inflow Rate given; contour is Length (X) vs. Width (Y)
            Dim width As DoubleParameter = mSystemGeometry.Width
            width.Value = mBorderCriteria.ContourWidthPoint.Value
            width.Source = mBorderCriteria.ContourWidthPoint.Source
            mSystemGeometry.Width = width
            mWidth = width.Value
            ' Inflow Rate
            mInflowRate = mInflowManagement.InflowRate.Value
        Else
            ' Width given; contour is Length (X) vs. Inflow Rate (Y)
            Dim inflowRate As DoubleParameter = mInflowManagement.InflowRate
            inflowRate.Value = mBorderCriteria.ContourInflowRatePoint.Value
            inflowRate.Source = mBorderCriteria.ContourInflowRatePoint.Source
            mInflowManagement.InflowRate = inflowRate
            mInflowRate = inflowRate.Value
            ' Width
            mWidth = mSystemGeometry.Width.Value
        End If
        '
        ' Level Basin requires Blocked End
        '
        Dim downstream As IntegerParameter = mSystemGeometry.DownstreamCondition
        downstream.Value = DownstreamConditions.BlockedEnd
        downstream.Source = ValueSources.Calculated
        mSystemGeometry.DownstreamCondition = downstream
        '
        ' Two passes may be required if 1st pass results in Tuning Point that lies
        ' outside the acceptable range
        '
        For pass As Integer = 1 To 2
            '
            ' 1. Compute Basin / Border design with simplified procedure
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

            ' Compute Basin / Border design with default Tuning Factors & Open End
            Dim phi0 As DoubleParameter = mBorderCriteria.Phi0Borders
            phi0.Value = upperPhi0Limit
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

            ' Compute Border design with default Tuning Factors
            point = DesignPoint()

            ' Get data from last design
            Dim tlBorder As Double = Me.AdvanceTimeToEndOfField
            Dim tr0Border As Double = Me.RecessionTimeAtHeadOfField
            Dim trlBorder As Double = Me.RecessionTimeAtEndOfField
            Dim dminBorder As Double = Me.DMin

            If (point.HasError) Then
                If Not (point.ErrMsg = mDictionary.tLimitLineExceededID.Translated) Then
                    If Not (point.ErrMsg = mDictionary.tDesignNotRecommendedID.Translated) Then
                        Dim title As String = mDictionary.tTuningError.Translated
                        Dim msg As String

                        msg = mDictionary.tTuningFactorsCalculationFailed.Translated
                        msg += Chr(13)
                        msg += Chr(13) + mDictionary.tError.Translated & ": " + point.ErrMsg
                        msg += Chr(13)
                        msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated

                        MsgBox(msg, MsgBoxStyle.Exclamation, title)

                        Me.Running = False
                        Me.Tuning = False
                        Return False
                    End If
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
                Dim title As String = mDictionary.tTuningError.Translated
                Dim msg As String

                msg = mDictionary.tSimulationFailedAtTuningPoint.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tAdditionalErrorMessagesMayFollow.Translated

                MsgBox(msg, MsgBoxStyle.Exclamation, title)

                DisplayErrors()

                Me.Running = False
                Me.Tuning = False
                Return False
            End If

            If ((tlSrfr <= 0.0) Or (trlSrfr <= 0.0)) Then
                Dim title As String = mDictionary.tTuningError.Translated
                Dim msg As String

                msg = mDictionary.tSimulationFailedAtTuningPoint.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tAdvanceDidNotReachEndOfField.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tToCorrectErrorDo.Translated
                msg += Chr(13)
                msg += Chr(13) + "1) " & mDictionary.tIncreaseInflowRate.Translated
                msg += Chr(13) + "2) " & mDictionary.tSelectMoreAppropriateTuningPoint.Translated

                MsgBox(msg, MsgBoxStyle.Exclamation, title)

                Me.Running = False
                Me.Tuning = False
                Return False
            End If
            '
            ' 3. Adjust Phi 0 so Border Design advance matches SRFR simulation advance
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

                ProgressMessage = phi0.Value

                ' Compute design with mid-range Phi 0
                point = DesignPoint()

                tlBorder = Me.AdvanceTimeToEndOfField
                tr0Border = Me.RecessionTimeAtHeadOfField
                trlBorder = Me.RecessionTimeAtEndOfField
                dminBorder = Me.DMin
            Next

            ' If solution is at limit of binary search; this is an error
            If ((Not ok) And (maxPhi0 = upperPhi0Limit)) Then
                Dim title As String = mDictionary.tTuningError.Translated
                Dim msg As String

                msg = mDictionary.tTuningFactorsCalculationPhi0Failed.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated

                MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Else
                '
                ' 4. Estimate Phi 1 to match Dmin with Dreq at the end of the field
                '

                ' Get & display current value of Phi 1
                phi1 = mBorderCriteria.Phi1Borders

                mDReq = mInflowManagement.RequiredDepth.Value          ' Inflow requirements
                mTReq = mSoilCropProperties.InfiltrationTime(mDReq)

                Dim minPhi1 As Double = lowerPhi1Limit
                Dim maxPhi1 As Double = upperPhi1Limit

                ok = False
                For iter As Integer = 1 To 15
                    Me.StatusMessage = mDictionary.tEstimatingPhi1.Translated

                    ' Get current value of Phi 1
                    phi1 = mBorderCriteria.Phi1Borders

                    ' Run SRFR simulation with adjusted Tco (based on new Phi 1)
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

                        Me.Running = False
                        Me.Tuning = False
                        Return False
                    End If

                    ' Advance must reach the end of the field
                    If ((tlSrfr <= 0.0) Or Double.IsNaN(tlSrfr)) _
                    Or ((trlSrfr <= 0.0) Or Double.IsNaN(trlSrfr)) Then
                        minPhi1 = phi1.Value                            ' Too small
                    ElseIf (tlSrfr < tlBorder * 0.999) Then
                        minPhi1 = phi1.Value                            ' Too small
                    Else
                        Dim oppTime As Double = trlSrfr - tlSrfr

                        If (oppTime < mTReq * 0.99) Then
                            minPhi1 = phi1.Value                        ' Too small
                        ElseIf (mTReq * 1.01 < oppTime) Then
                            maxPhi1 = phi1.Value                        ' Too large
                        Else
                            ok = True
                            Exit For                                    ' Just right
                        End If
                    End If

                    ' Calculate new estimate for Phi 1
                    phi1.Value = (minPhi1 + maxPhi1) / 2.0
                    phi1.Source = ValueSources.Calculated
                    mBorderCriteria.Phi1Borders = phi1

                    ProgressMessage = phi1.Value

                    ' Compute design with new Phi 1; results in new Tco
                    point = DesignPoint()

                    tlBorder = Me.AdvanceTimeToEndOfField
                    tr0Border = Me.RecessionTimeAtHeadOfField
                    trlBorder = Me.RecessionTimeAtEndOfField
                    dminBorder = Me.DMin
                Next

                Me.Tuning = False
            End If ' Phi 0 estimate OK
            '
            ' Make sure Tuning Point is within acceptable range
            '
            If ((mXR < MinXR) Or (mPAEmin < MinPAE)) Then
                Dim title As String = mDictionary.tTuningError.Translated
                Dim xStr, yStr, msg As String

                msg = mDictionary.tSelectedTuningPointOutsideLimitLine.Translated
                msg += Chr(13)
                msg += Chr(13) + "XR:     " + RatioString(mXR, 0)
                msg += Chr(13) + "PAEmin: " + PercentageString(mPAEmin, 0)
                msg += Chr(13)

                If (pass = 1) Then
                    ' Tuning Point is outside acceptable range; try to bring it in

                    ' Decrease Length
                    Dim curLength As DoubleParameter = mBorderCriteria.ContourLengthPoint
                    Dim minLength As DoubleParameter = mBorderCriteria.MinContourLength

                    mLength = (curLength.Value + minLength.Value) / 2

                    xStr = mDictionary.tLength.Translated(11) & " = " & LengthString(mLength, 0)

                    ' Decrease Inflow Rate (perhaps by increasing Width)
                    If (mBorderCriteria.DesignOption.Value = DesignOptions.WidthGiven) Then

                        Dim curInflowRate As DoubleParameter = mBorderCriteria.ContourInflowRatePoint
                        Dim minInflowRate As DoubleParameter = mBorderCriteria.MinContourInflowRate

                        mInflowRate = (minInflowRate.Value + curInflowRate.Value) / 2.0

                        yStr = mDictionary.tInflowRate.Translated(11) & " = " & FlowRateString(mInflowRate, 0)

                    Else ' Inflow Rate Given

                        ' Is maximum Width within acceptable range?
                        Dim curWidth As DoubleParameter = mBorderCriteria.ContourWidthPoint
                        Dim maxWidth As DoubleParameter = mBorderCriteria.MaxContourWidth

                        mWidth = (maxWidth.Value + curWidth.Value) / 2.0

                        yStr = mDictionary.tWidth.Translated(11) & " = " & LengthString(mWidth, 0)

                    End If

                    msg += Chr(13) + mDictionary.tTuningPointSuggested.Translated
                    msg += Chr(13)
                    msg += Chr(13) + xStr
                    msg += Chr(13) + yStr
                    msg += Chr(13)
                    msg += Chr(13) + mDictionary.tPressYesToRetryAtSuggestedPoint.Translated
                    msg += Chr(13)
                    msg += Chr(13) + mDictionary.tPressNoKeepCurrentPoint.Translated
                    msg += Chr(13)

                    Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)

                    If (result = MsgBoxResult.Yes) Then
                        ' Save new Tuning & Solution Point
                        Dim contourPoint As DoubleParameter = mBorderCriteria.ContourLengthPoint
                        contourPoint.Value = mLength
                        contourPoint.Source = ValueSources.Calculated
                        mBorderCriteria.ContourLengthPoint = contourPoint

                        Dim parameter As DoubleParameter = mSystemGeometry.Length
                        parameter.Value = mLength
                        parameter.Source = ValueSources.Calculated
                        mSystemGeometry.Length = parameter

                        If (mBorderCriteria.DesignOption.Value = DesignOptions.WidthGiven) Then
                            contourPoint = mBorderCriteria.ContourInflowRatePoint
                            contourPoint.Value = mInflowRate
                            contourPoint.Source = ValueSources.Calculated
                            mBorderCriteria.ContourInflowRatePoint = contourPoint

                            parameter = mInflowManagement.InflowRate
                            parameter.Value = mInflowRate
                            parameter.Source = ValueSources.Calculated
                            mInflowManagement.InflowRate = parameter
                        Else
                            contourPoint = mBorderCriteria.ContourWidthPoint
                            contourPoint.Value = mWidth
                            contourPoint.Source = ValueSources.Calculated
                            mBorderCriteria.ContourWidthPoint = contourPoint

                            parameter = mSystemGeometry.Width
                            parameter.Value = mWidth
                            parameter.Source = ValueSources.Calculated
                            mSystemGeometry.Width = parameter
                        End If

                        If Not (mWorldWindow Is Nothing) Then
                            mWorldWindow.Refresh()
                        End If
                    Else
                        mWidth = mBorderCriteria.ContourWidthPoint.Value
                        mLength = mBorderCriteria.ContourLengthPoint.Value
                        mInflowRate = mBorderCriteria.ContourInflowRatePoint.Value
                        point = DesignPoint()

                        ok = True
                        Exit For
                    End If
                Else ' pass 2
                    '
                    ' Is Tuning Point is still outside Limit Line?
                    '   Yes, let user pick better one
                    '
                    If (mXR < DesignLimitLine) Then
                        msg += Chr(13) + mDictionary.tToCorrectErrorDo.Translated
                        msg += Chr(13)
                        msg += Chr(13) + "1) Run the Design using the current Tuning Parameters."
                        msg += Chr(13) + "2) Manually select a Tuning Point within the Limit Line."
                        msg += Chr(13) + "   This may require adjusting the contour ranges."

                        MsgBox(msg, MsgBoxStyle.OkOnly, title)
                    End If
                End If
            Else ' Tuning Point is ok
                Exit For
            End If
        Next ' pass

        ' Check completion status of Phi 1 estimation
        If (Not ok) Then
            Dim title As String = mDictionary.tTuningError.Translated
            Dim msg As String

            msg = mDictionary.tTuningFactorsCalculationPhi1Failed.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated

            MsgBox(msg, MsgBoxStyle.Exclamation, title)
        End If ' Phi 1 estimate OK

        ProgressMessage = ""

        mTuningPoint = point

        Me.Running = False
        Me.Tuning = False
        Return ok
    End Function

#End Region

#Region " Sloping Border wo/ Cutback "

    Protected Function EstimateTuningFactorsBorderNoCutback() As Boolean
        Dim ok As Boolean = MyBase.EstimateTuningFactors()
        Me.Running = True
        Me.Tuning = True

        ' Inflow Parameters
        mInflowRate = mInflowManagement.InflowRate.Value
        mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value
        '
        ' Basin / Border Design only works for Time-Based Cutoff
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
        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            ' Inflow Rate given; contour is Length (X) vs. Width (Y)
            Dim width As DoubleParameter = mSystemGeometry.Width
            width.Value = mBorderCriteria.ContourWidthPoint.Value
            width.Source = mBorderCriteria.ContourWidthPoint.Source
            mSystemGeometry.Width = width
            mWidth = width.Value
        Else
            ' Width given; contour is Length (X) vs. Inflow Rate (Y)
            Dim inflowRate As DoubleParameter = mInflowManagement.InflowRate
            inflowRate.Value = mBorderCriteria.ContourInflowRatePoint.Value
            inflowRate.Source = mBorderCriteria.ContourInflowRatePoint.Source
            mInflowManagement.InflowRate = inflowRate
            mInflowRate = inflowRate.Value
        End If
        '
        ' Save current Downstream Condition
        '
        Dim downstream As IntegerParameter = mSystemGeometry.DownstreamCondition

        mDownstreamValue = downstream.Value
        mDownstreamSource = downstream.Source

        ' Set Downstream Condition to Open End
        downstream = mSystemGeometry.DownstreamCondition
        downstream.Value = DownstreamConditions.OpenEnd
        downstream.Source = ValueSources.Calculated
        mSystemGeometry.DownstreamCondition = downstream
        '
        ' 1. Compute Basin / Border design with simplified procedure
        '   a. This estimates Tco for Dreq (i.e. Dmin)
        '

        ' Get Sigma Y (surface-shape factor)
        Dim sigmaY As DoubleParameter = mBorderCriteria.SigmaY
        sigmaY.Value = Me.SigmaY(mInflowRate, mLength, mWidth, S0)
        sigmaY.Source = ValueSources.Calculated
        mBorderCriteria.SigmaY = sigmaY

        Dim upperPhi0Limit As Double = 2.0 / sigmaY.Value
        Dim upperPhi1Limit As Double = 2.0

        ' Compute Basin / Border design with default Tuning Factors & Open End
        Dim phi0 As DoubleParameter = mBorderCriteria.Phi0Borders
        phi0.Value = upperPhi0Limit
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

        ' Compute Border design with default Tuning Factors
        Dim point As ContourPoint = DesignPoint()

        ' Get data from last design
        Dim tlBorder As Double = Me.AdvanceTimeToEndOfField
        Dim tr0Border As Double = Me.RecessionTimeAtHeadOfField
        Dim trlBorder As Double = Me.RecessionTimeAtEndOfField
        Dim dminBorder As Double = Me.DMin

        If (point.HasError) Then
            If Not (point.ErrMsg = mDictionary.tDesignNotRecommendedID.Translated) Then
                Dim title As String = mDictionary.tTuningError.Translated
                Dim msg As String

                msg = mDictionary.tTuningFactorsCalculationFailed.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tError.Translated & ": " + point.ErrMsg
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated

                MsgBox(msg, MsgBoxStyle.Exclamation, title)

                ' Restore Downstream Condition
                downstream = mSystemGeometry.DownstreamCondition
                downstream.Value = mDownstreamValue
                downstream.Source = mDownstreamSource
                mSystemGeometry.DownstreamCondition = downstream

                Me.Running = False
                Me.Tuning = False
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
            Me.Tuning = False
            Return False
        End If

        If ((tlSrfr <= 0.0) Or (trlSrfr <= 0.0)) Then
            Dim title As String = mDictionary.tTuningError.Translated
            Dim msg As String

            msg = mDictionary.tSimulationFailedAtTuningPoint.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tAdvanceDidNotReachEndOfField.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tToCorrectErrorDo.Translated
            msg += Chr(13)
            msg += Chr(13) + "1) " & mDictionary.tIncreaseInflowRate.Translated
            msg += Chr(13) + "2) " & mDictionary.tSelectMoreAppropriateTuningPoint.Translated

            MsgBox(msg, MsgBoxStyle.Exclamation, title)

            ' Restore Downstream Condition
            downstream = mSystemGeometry.DownstreamCondition
            downstream.Value = mDownstreamValue
            downstream.Source = mDownstreamSource
            mSystemGeometry.DownstreamCondition = downstream

            Me.Running = False
            Me.Tuning = False
            Return False
        End If
        '
        ' 3. Adjust Phi 0 so Border Design advance matches SRFR simulation advance
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

            ProgressMessage = phi0.Value

            ' Compute design with mid-range Phi 0
            point = DesignPoint()

            tlBorder = Me.AdvanceTimeToEndOfField
            tr0Border = Me.RecessionTimeAtHeadOfField
            trlBorder = Me.RecessionTimeAtEndOfField
            dminBorder = Me.DMin
        Next

        ' If solution is at limit of binary search; this is an error
        If ((Not ok) And (maxPhi0 = upperPhi0Limit)) Then
            Dim title As String = mDictionary.tTuningError.Translated
            Dim msg As String

            msg = mDictionary.tTuningFactorsCalculationPhi0Failed.Translated
            msg += Chr(13)
            msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated

            MsgBox(msg, MsgBoxStyle.Exclamation, title)
        Else
            '
            ' 4. Estimate Phi 1 to match Dmin with Dreq at the end of the field
            '

            ' Get & display current value of Phi 1
            phi1 = mBorderCriteria.Phi1Borders

            mDReq = mInflowManagement.RequiredDepth.Value          ' Inflow requirements
            mTReq = mSoilCropProperties.InfiltrationTime(mDReq)

            Dim minPhi1 As Double = 0.0
            Dim maxPhi1 As Double = upperPhi1Limit

            ok = False
            For iter As Integer = 1 To 15
                Me.StatusMessage = mDictionary.tEstimatingPhi1.Translated

                ' Get current value of Phi 1
                phi1 = mBorderCriteria.Phi1Borders

                ' Run SRFR simulation with adjusted Tco (based on new Phi 1)
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
                    Me.Tuning = False
                    Return False
                End If

                ' Advance must reach the end of the field
                If ((tlSrfr <= 0.0) Or Double.IsNaN(tlSrfr)) _
                Or ((trlSrfr <= 0.0) Or Double.IsNaN(trlSrfr)) Then
                    maxPhi1 = phi1.Value                            ' Too large
                ElseIf (tlSrfr < tlBorder * 0.999) Then
                    minPhi1 = phi1.Value                            ' Too small
                Else
                    Dim oppTime As Double = trlSrfr - tlSrfr

                    If (oppTime < mTReq * 0.99) Then
                        maxPhi1 = phi1.Value                        ' Too large
                    ElseIf (mTReq * 1.01 < oppTime) Then
                        minPhi1 = phi1.Value                        ' Too small
                    Else
                        ok = True
                        Exit For                                    ' Just right
                    End If
                End If

                ' Calculate new estimate for Phi 1
                phi1.Value = (minPhi1 + maxPhi1) / 2.0
                phi1.Source = ValueSources.Calculated
                mBorderCriteria.Phi1Borders = phi1

                ProgressMessage = phi1.Value

                ' Compute design with new Phi 1; results in new Tco
                point = DesignPoint()

                tlBorder = Me.AdvanceTimeToEndOfField
                tr0Border = Me.RecessionTimeAtHeadOfField
                trlBorder = Me.RecessionTimeAtEndOfField
                dminBorder = Me.DMin
            Next

            Me.Tuning = False

            ' Check completion status of Phi 1 estimation
            If ((Not ok) And (maxPhi1 = upperPhi1Limit)) Then
                Dim title As String = mDictionary.tTuningError.Translated
                Dim msg As String

                msg = mDictionary.tTuningFactorsCalculationPhi1Failed.Translated
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated

                MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Else ' Phi 1 OK
                '
                ' 5. Calculate Phi 2 to match recession at upstream end
                '
                Me.StatusMessage = mDictionary.tEstimatingPhi2.Translated

                Dim Y0, A0, R0, WP0, Sf As Double
                Me.UpstreamParameters(mInflowRate, mLength, mWidth, S0, Y0, A0, R0, WP0, Sf)

                ' Save Upstream Representative Depth
                Dim upstreamDepth As DoubleParameter = mSurfaceFlow.UpstreamDepth
                upstreamDepth.Value = Y0
                upstreamDepth.Source = ValueSources.Calculated
                mSurfaceFlow.UpstreamDepth = upstreamDepth

                ' Get & display current value of Phi 2
                phi2 = mBorderCriteria.Phi1Borders

                Dim qin As Double = mInflowRate / mWidth            ' Unit inflow rate

                Dim num As Double = 0.345 * n * qin ^ 0.175         ' Recession lag (from eq. 14.34)
                Dim den As Double = mTReq ^ 0.88 * S0 ^ 0.5

                mTlag = (qin ^ 0.2 * n ^ 1.2) / ((S0 + (num / den)) ^ 1.6)

                ' Calculate new estimate for Phi 2
                phi2.Value = tlagSrfr / mTlag
                phi2.Source = ValueSources.Calculated
                mBorderCriteria.Phi2Borders = phi2

                ProgressMessage = phi2.Value

                ' Compute design with new Phi 2
                point = DesignPoint()

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
                Dim dInf0 As Double = mSoilCropProperties.InfiltrationDepth(mOppTimes(0))

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

                    ' Compute design with new Phi 1 & 2
                    point = DesignPoint()

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
                ' Calculate Phi 3 to:
                '   1) Match runoff volumes if Blocked
                '   2) Set recession slope if Open
                '
                Me.StatusMessage = mDictionary.tEstimatingPhi3.Translated

                ' Get & display current value of Phi 3
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

                        If (ThisClose(minDistX, maxDistX, OneLiter)) Then
                            Exit For
                        End If
                    Next

                    phi3.Value = ((mTrL - mTr0) * qin) / (distX * sigmaY.Value * Y0)
                Else
                    phi3.Value = 0.0
                End If

                phi3.Source = ValueSources.Calculated
                mBorderCriteria.Phi3Borders = phi3

                ProgressMessage = phi3.Value
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
        Me.Tuning = False
        Return ok
    End Function

#End Region

#Region " Sloping Border w/ Cutback "

    '******************************************************************************************
    ' Estimate the Design Tuning Factors for Irrigations with Cutback
    '
    Protected Function EstimateTuningFactorsBorderWithCutback() As Boolean
        Dim ok As Boolean = MyBase.EstimateTuningFactors()
        Me.Running = True

        ' Inflow Rates
        mInflowRate = mInflowManagement.InflowRate.Value
        mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value
        '
        ' Basin / Border Design only works for Time-Based Cutoff
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
        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            ' Inflow Rate given; contour is Length (X) vs. Width (Y)
            Dim width As DoubleParameter = mSystemGeometry.Width
            width.Value = mBorderCriteria.ContourWidthPoint.Value
            width.Source = mBorderCriteria.ContourWidthPoint.Source
            mSystemGeometry.Width = width
            mWidth = width.Value

        Else
            ' Width given; contour is Length (X) vs. Inflow Rate (Y)
            Dim inflowRate As DoubleParameter = mInflowManagement.InflowRate
            inflowRate.Value = mBorderCriteria.ContourInflowRatePoint.Value
            inflowRate.Source = mBorderCriteria.ContourInflowRatePoint.Source
            mInflowManagement.InflowRate = inflowRate
            mInflowRate = inflowRate.Value
        End If
        '
        ' 1. Compute Basin / Border design with simplified procedure
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

        ' Compute Basin / Border design with default Tuning Factors & Open End
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

        Dim parameter As IntegerParameter = mSystemGeometry.DownstreamCondition
        parameter.Value = DownstreamConditions.OpenEnd
        parameter.Source = ValueSources.Calculated
        mSystemGeometry.DownstreamCondition = parameter

        ' Compute Basin / Border design with default Tuning Factors
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

        If (0 < mPerformanceResults.ErrorCount.Value) Then
            Dim _title As String = mDictionary.tTuningError.Translated
            Dim _message As String

            _message = mDictionary.tSimulationFailedAtTuningPoint.Translated
            _message += Chr(13)
            _message += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated
            _message += Chr(13)
            _message += Chr(13) + mDictionary.tAdditionalErrorMessagesMayFollow.Translated

            MsgBox(_message, MsgBoxStyle.Exclamation, _title)

            DisplayErrors()

            ' Restore Downstream Condition
            parameter = mSystemGeometry.DownstreamCondition
            parameter.Value = mDownstreamValue
            parameter.Source = mDownstreamSource
            mSystemGeometry.DownstreamCondition = parameter

            Me.Running = False
            Return False
        End If

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
        Dim tlBorder As Double
        '
        ' 3. Adjust Phi 0 to make Basin / Border Design advance match SRFR simulation advance
        '   a. This step is performed with an Open End
        '
        Me.StatusMessage = mDictionary.tEstimatingPhi0.Translated

        ' Use binary search to match Phi 0 values
        Dim minPhi0 As Double = 0.0
        Dim maxPhi0 As Double = 2.0 / sigmaY.Value

        For iter As Integer = 0 To 20

            ' Get advance from last design
            tlBorder = Me.AdvanceTimeToEndOfField

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
                    Exit For                                ' Just Right
                End If
            End If

            phi0.Value = (minPhi0 + maxPhi0) / 2.0
            phi0.Source = ValueSources.Calculated
            mBorderCriteria.Phi0Borders = phi0

            ' Compute design with mid-range Phi 0
            point = DesignPoint()
        Next

        ' If solution is at limit of binary search; this is an error
        If (maxPhi0 = 2.0 / sigmaY.Value) Then
            ok = False
        Else
            '
            ' 4. Estimate Phi 1 to match recession at end of basin/border
            '   a. This step is performed with an Open End
            '
            mDReq = mInflowManagement.RequiredDepth.Value          ' Inflow requirements
            mTReq = mSoilCropProperties.InfiltrationTime(mDReq)

            Dim minPhi1 As Double = 0.0
            Dim maxPhi1 As Double = 10.0

            For iter As Integer = 1 To 20
                Me.StatusMessage = mDictionary.tEstimatingPhi1.Translated

                ' Calculate Phi 1
                phi1 = mBorderCriteria.Phi1Borders

                ' Advance must reach the end of the field
                If ((tlSrfr <= 0.0) Or Double.IsNaN(tlSrfr)) _
                Or ((trlSrfr <= 0.0) Or Double.IsNaN(trlSrfr)) Then
                    maxPhi1 = phi1.Value                            ' Too large
                Else
                    Dim oppTime As Double = trlSrfr - tlSrfr

                    If (oppTime < mTReq - OneMinute) Then
                        maxPhi1 = phi1.Value                        ' Too small
                    ElseIf (mTReq + OneMinute < oppTime) Then
                        minPhi1 = phi1.Value                        ' Too large
                    Else
                        Exit For                                    ' Just right
                    End If
                End If

                phi1.Value = (minPhi1 + maxPhi1) / 2.0
                phi1.Source = ValueSources.Calculated
                mBorderCriteria.Phi1Borders = phi1

                ' Compute design with new Phi 1; results in new Tco
                point = DesignPoint()

                ' Rerun SRFR simulation with adjusted Basin / Border Design Tco (based on new Phi 1)
                RunSRFR(False, True, True)

                If (0 < mPerformanceResults.ErrorCount.Value) Then
                    Dim _title As String = mDictionary.tTuningError.Translated
                    Dim _message As String

                    _message = mDictionary.tSimulationFailedAtTuningPoint.Translated
                    _message += Chr(13)
                    _message += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated
                    _message += Chr(13)
                    _message += Chr(13) + mDictionary.tAdditionalErrorMessagesMayFollow.Translated

                    MsgBox(_message, MsgBoxStyle.Exclamation, _title)

                    DisplayErrors()

                    ' Restore Downstream Condition
                    parameter = mSystemGeometry.DownstreamCondition
                    parameter.Value = mDownstreamValue
                    parameter.Source = mDownstreamSource
                    mSystemGeometry.DownstreamCondition = parameter

                    Me.Running = False
                    Return False
                End If

                ' This SRFR run is the standard to which Phi 2 is tuned
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
            Next
            '
            ' 5. Estimate Phi 2 to match infiltrated volumes
            '   a. This step is performed with an Open End
            '
            Me.StatusMessage = mDictionary.tEstimatingPhi2.Translated

            Dim Y0, A0, R0, WP0, Sf As Double
            Me.UpstreamParameters(mInflowRate, mLength, mWidth, S0, Y0, A0, R0, WP0, Sf)

            ' Save Upstream Representative Depth
            Dim upstreamDepth As DoubleParameter = mSurfaceFlow.UpstreamDepth
            upstreamDepth.Value = Y0
            upstreamDepth.Source = ValueSources.Calculated
            mSurfaceFlow.UpstreamDepth = upstreamDepth

            Dim minTr0 As Double = mTco
            Dim maxTr0 As Double = Math.Max(trlSrfr, mTco + (2 * tlagSrfr))

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
                Dim inVolBorder As Double = InfiltratedVolume(mWidth)

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

            Dim adjRate As Double = mInflowRate
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
                If (0.0 < S0) Then
                    parameter = mSystemGeometry.DownstreamCondition
                    parameter.Value = DownstreamConditions.OpenEnd
                    parameter.Source = mDownstreamSource
                    mSystemGeometry.DownstreamCondition = parameter

                    ' Compute design with new Phi 2
                    point = DesignPoint()

                    RunSRFR(False, True, False)

                    If (0.0 < mRunoffVolume) Then
                        phi3.Value = mSurfaceFlow.RunoffVolume / mRunoffVolume
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
            Dim _title As String = mDictionary.tTuningError.Translated
            Dim _message As String

            _message = mDictionary.tSimulationFailedAtTuningPoint.Translated
            _message += Chr(13)
            _message += Chr(13) + mDictionary.tSelectMoreAppropriateTuningPoint.Translated
            _message += Chr(13)
            _message += Chr(13) + mDictionary.tAdditionalErrorMessagesMayFollow.Translated

            MsgBox(_message, MsgBoxStyle.Exclamation, _title)

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

#Region " Basin / Border Design Contours "

    Public Overrides Sub RunDesign()
        Me.StartRun("Basin / Border Design", True)
        Me.BuildDesignGrid("Basin / Border", "Basin / Border")
        '
        ' Basin / Border design only work for Time-Based Cutoff & Minimum Depth
        '
        Dim cutoff As IntegerParameter = mInflowManagement.CutoffMethod
        If Not (cutoff.Value = CutoffMethods.TimeBased) Then
            cutoff.Value = CutoffMethods.TimeBased
            cutoff.Source = ValueSources.Calculated
            mInflowManagement.CutoffMethod = cutoff
        End If

        mCutbackMethod = mInflowManagement.CutbackMethod.Value

        Dim designDepth As IntegerParameter = mBorderCriteria.InfiltratedDepthCriterion
        If Not (designDepth.Value = InfiltratedDepthCriteria.MinimumDepth) Then
            designDepth.Value = InfiltratedDepthCriteria.MinimumDepth
            designDepth.Source = ValueSources.Calculated
            mBorderCriteria.InfiltratedDepthCriterion = designDepth
        End If
        '
        ' Level basins wo/ Cutback requires Blocked End
        '
        If ((mCutbackMethod = CutbackMethods.NoCutback) And (S0 <= MaximumLevelSlope)) Then
            Dim downstream As IntegerParameter = mSystemGeometry.DownstreamCondition
            downstream.Value = DownstreamConditions.BlockedEnd
            downstream.Source = ValueSources.Calculated
            mSystemGeometry.DownstreamCondition = downstream
        End If
        '
        ' Build contour polygons using contour grid as guide
        '
        '   X is always Length
        '   Y can be either Width or Inflow Rate
        '
        mContourGrid.ClearContours()

        XTolerance = mLengthTolerance
        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            YTolerance = mWidthTolerance
        Else
            YTolerance = mInflowRateTolerance
        End If

        Dim minorContours As Boolean = WinSRFR.UserPreferences.DisplayMinorContours

        ' Potential Application Efficiency (PAEmin) contour polygons
        Me.BuildMajorContours(sPotentialApplicationEfficiency, sPAEmin, PaeIndex,
                Me.mMajor10PercentValues, PaeTolerance, Units.Percentage, True)

        If (minorContours) Then
            Me.BuildMinorContours(sPotentialApplicationEfficiency, sPAEmin, PaeIndex,
                Me.mMinor10PercentValues, PaeTolerance, Units.Percentage, True)
        End If

        ' Distribution Uniformity (DUmin) contour polygons
        Me.BuildMajorContours(sMinimumDistributionUniformity, sDUmin, DuIndex,
                Me.mMajor10PercentValues, DuTolerance, Units.Fraction, True)

        If (minorContours) Then
            Me.BuildMinorContours(sMinimumDistributionUniformity, sDUmin, DuIndex,
                    Me.mMinor10PercentValues, DuTolerance, Units.Fraction, True)
        End If

        ' Adequacy (ADmin) contour polygons
        Me.BuildMajorContours(sMinimumAdequacy, sADmin, AdIndex,
                Me.mMajor10PercentValues, ADTolerance, Units.Fraction, True)

        If (minorContours) Then
            Me.BuildMinorContours(sMinimumAdequacy, sADmin, AdIndex,
                    Me.mMinor10PercentValues, ADTolerance, Units.Fraction, True)
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

        ' Applied Depth (Dapp) contour polygons
        Me.BuildMajorContours(sAppliedDepth, sDapp, DappIndex, Me.mMajor10LevelDapps,
                DappTolerance, Units.Millimeters, False)

        If (minorContours) Then
            Me.BuildMinorContours(sAppliedDepth, sDapp, DappIndex, Me.mMinor10LevelDapps,
                    DappTolerance, Units.Millimeters, False)
        End If

        ' Low-Quarter Depth (Dlq) contour polygons
        Me.BuildMajorContours(sLowQuarterDepth, sDlq, DLfIndex, Me.mMajor10LevelDlfs,
                DLfTolerance, Units.Millimeters, False)

        If (minorContours) Then
            Me.BuildMinorContours(sLowQuarterDepth, sDlq, DLfIndex, Me.mMinor10LevelDlfs,
                    DLfTolerance, Units.Millimeters, False)
        End If

        ' Max Advance Time (Txa) contour polygons
        Me.BuildMajorContours(sMaxAdvanceTime, sTxa, TxaIndex, Me.mMajor10TxaValues,
                TxaTolerance, Units.Seconds, False)

        If (minorContours) Then
            Me.BuildMinorContours(sMaxAdvanceTime, sTxa, TxaIndex, Me.mMinor10TxaValues,
                    TxaTolerance, Units.Seconds, False)
        End If

        ' Cutoff Time (Tco) contour polygons
        Me.BuildMajorContours(sCutoffTime, sTco, TcoIndex, Me.mMajor10TcoValues,
                TcoTolerance, Units.Seconds, False)

        If (minorContours) Then
            Me.BuildMinorContours(sCutoffTime, sTco, TcoIndex, Me.mMinor10TcoValues,
                    TcoTolerance, Units.Seconds, False)
        End If

        ' Relative Cutoff (R) contour polygons
        Me.BuildMajorContours(sCutoffRatio, sXR, RcoIndex, Me.mMajor10LevelsRco,
                RcoTolerance, Units.None, False)

        If (minorContours) Then
            Me.BuildMinorContours(sCutoffRatio, sXR, RcoIndex, Me.mMinor10LevelsRco,
                    RcoTolerance, Units.None, False)
        End If

        ' Cutback Ratio
        If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            Me.BuildMajorContours(sCutbackRatio, sCutback, CutbackIndex, Me.mMajor10LevelsCutback,
                    CutbackTolerance, Units.None, False)

            If (minorContours) Then
                Me.BuildMinorContours(sCutbackRatio, sCutback, CutbackIndex, Me.mMinor10LevelsCutback,
                        CutbackTolerance, Units.None, False)
            End If
        End If
        '
        ' Save contour in the DataStore
        '
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

        Me.EndRun()
    End Sub

#End Region

#Region " Basin / Border Design Point "

    '******************************************************************************************
    ' Compute Basin / Border Design Point based on use of Cutback
    '
    Protected Overloads Overrides Function DesignPoint() As ContourPoint
        Dim point As ContourPoint

        If (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            ' Run design with no cutback
            point = DesignPoint(mLength, mWidth, mInflowRate, NumWddPoints)
        Else
            ' Run design with cutback
            mCutbackRate = mInflowRate * mCutbackRateRatio
            point = DesignPoint(mLength, mWidth, mInflowRate, mCutbackRate, NumWddPoints)
        End If

        Return point
    End Function

    '*********************************************************************************************************
    ' Compute Basin / Border Design Point wo/ Cutback
    '
    ' This design is adapted from Bert Clemmen's Furrow Design algorithm in FurrowDesign2005.xls
    '
    Protected Overloads Overrides Function DesignPoint(ByVal borderLength As Double,
                                                       ByVal borderWidth As Double,
                                                       ByVal inflowRate As Double,
                                                       ByVal numDistances As Integer) As ContourPoint
        Debug.Assert(0 < borderLength)
        Debug.Assert(0 < borderWidth)
        Debug.Assert(0 < inflowRate)
        Debug.Assert(0 < numDistances)

        ' Instantiate/initialize SRFR Infiltration object; its used for infiltration calculations
        mSoilCropProperties.SetSrfrInfiltration()
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.Length = borderLength
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.BorderWidth = borderWidth
        mSoilCropProperties.SrfrInfiltration.RefInflow.Q0 = inflowRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.L = borderLength

        '*****************************************************************************************************
        ' Step 1: Get input conditions
        '
        mSigmaY = mBorderCriteria.SigmaY.Value                      ' Tuning factors
        mPhi0 = mBorderCriteria.Phi0Borders.Value
        mPhi1 = mBorderCriteria.Phi1Borders.Value
        mPhi2 = mBorderCriteria.Phi2Borders.Value
        mPhi3 = mBorderCriteria.Phi3Borders.Value

        mArea = borderLength * borderWidth                          ' System geometry

        Dim Dmax As Double = mSystemGeometry.Depth.Value

        '*****************************************************************************************************
        ' Step 2: Compute upstream representative depth, flow area & velocity, etc.
        '
        Dim L1 As Double = borderLength / 2.0
        Dim Y01, A01, R01, WP01, Sf1 As Double
        Me.UpstreamParameters(inflowRate, L1, borderWidth, S0, Y01, A01, R01, WP01, Sf1)
        Dim V01 As Double = inflowRate / Y01

        Dim L2 As Double = borderLength
        Dim Y02, A02, R02, WP02, Sf2 As Double
        Me.UpstreamParameters(inflowRate, L2, borderWidth, S0, Y02, A02, R02, WP02, Sf2)
        Dim V02 As Double = inflowRate / Y02

        '*****************************************************************************************************
        ' Step 3: Compute 2-point advance
        '
        ComputeTwoPointAdvance(L1, A01, V01, L2, A02, V02, borderWidth, borderWidth, inflowRate, numDistances)

        '*****************************************************************************************************
        ' Step 4: Compute Performance (w/ Horizontal Recession)
        '   (not supported by WinSRFR)
        '

        '*****************************************************************************************************
        ' Step 5: Compute Performance (w/ Adjusted Recession)
        '

        ' Infiltration & Recession Time at end of border (i.e. the design requirements)
        mDReq = mInflowManagement.RequiredDepth.Value
        mTReq = mSoilCropProperties.InfiltrationTime(mDReq)
        mTrL = mTReq + mAdvanceTime2

        If (S0 <= MaximumLevelSlope) Then
            '
            ' Downstream is fixed at TrL; find its required Tco
            '

            ' Start with level recession at TrL
            ComputeIrrigationCurves(borderWidth, inflowRate, mTrL, mTrL, mDMin, mInfiltratedVolume)

            ' Average infiltrated depth
            Dim Davg As Double = mInfiltratedVolume / mArea

            ' Tco for level recession
            Dim tcox As Double = mInfiltratedVolume / inflowRate

            ' Tco adjustment (from Davg/Dreq vs. tco/tcox graph)
            Dim graphSlope As Double = (1.05 - 1.0) / (1.2 - 1.0)   ' 0.25

            mDepthRatio = Davg / mDReq
            Dim depthDelta As Double = mDepthRatio - 1.0

            Dim tcoDelta As Double = depthDelta * graphSlope * mPhi1
            mTcoRatio = tcoDelta + 1.0

            ' Adjusted Tco & Inflow Volume
            mTco = tcox * mTcoRatio
            mInflowVolume = mTco * inflowRate
            '
            ' Find Tr0 that matches Infiltrated Volume with Inflow Volume
            '
            Dim minTr0 As Double = mTco
            Dim maxTr0 As Double = mTrL * 2.0

            For iter As Integer = 1 To 25
                mTr0 = (minTr0 + maxTr0) / 2.0

                ' Compute recession & infiltrated volume with new Tr0
                ComputeIrrigationCurves(borderWidth, inflowRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                If (mInfiltratedVolume < mInflowVolume - OneLiter) Then
                    minTr0 = mTr0                                           ' Too small
                ElseIf (mInflowVolume + OneLiter < mInfiltratedVolume) Then
                    maxTr0 = mTr0                                           ' Too large
                Else
                    Exit For                                                ' Just right
                End If
            Next

            ' Blocked End; there is no Runoff
            mInfiltratedVolume = mInflowVolume
            mRunoffVolume = 0

            mDeltaTr = 3.27

        Else ' MaximumLevelSlope < S0
            '
            ' Field is sloping
            '
            Dim qin As Double = inflowRate / borderWidth        ' Unit inflow rate

            Dim num As Double = 0.345 * n * qin ^ 0.175         ' Recession lag (from eq. 14.34)
            Dim den As Double = mTReq ^ 0.88 * S0 ^ 0.5

            mTlag = (mPhi2 * qin ^ 0.2 * n ^ 1.2) / ((S0 + (num / den)) ^ 1.6)

            Dim tr0s1 As Double = mTrL                          ' Estimated / Actual tR(0)s
            Dim tr0s2 As Double = 0

            Dim minTr0s1 As Double = 0.0                        ' Search limits
            Dim maxTr0s1 As Double = tr0s1

            Dim lastDeltaTr As Double = 0                       ' Last valid mDeltaTr

            Dim avgInfRate, Sy As Double

            For iter As Integer = 1 To 25

                ' Compute irrigation curves w/ level recession
                mRecTimes.Clear()
                mOppTimes.Clear()
                mInfRates.Clear()

                avgInfRate = 0.0

                For idx As Integer = 0 To numDistances - 1
                    Dim Tadv As Double = mAdvTimes(idx)
                    Dim Trec As Double = tr0s1
                    Dim Tau As Double = Math.Max(Trec - Tadv, 0)
                    Dim dZdT As Double = mSoilCropProperties.InfiltrationRate(Tau)

                    mRecTimes.Add(Trec)
                    mOppTimes.Add(Tau)
                    mInfRates.Add(dZdT)

                    avgInfRate += dZdT
                Next

                avgInfRate /= numDistances

                If (OneMinute < mOppTimes(numDistances - 1)) Then
                    ' Calculate Sy (eq. 14.32)
                    num = Math.Max((qin - (avgInfRate * borderLength)) * n, 0.0)
                    den = S0 ^ 0.5
                    Sy = ((num / den) ^ 0.6) / borderLength

                    ' Calculate delta Tr (eq. 14.31)
                    num = (0.666 * n ^ 0.4757) * (Sy ^ 0.2074) * (borderLength ^ 0.6829)
                    den = (avgInfRate ^ 0.5244) * (S0 ^ 0.2378)
                    mDeltaTr = num / den

                    If (0.0 < mDeltaTr) Then
                        lastDeltaTr = mDeltaTr

                        ' Check tr0s
                        tr0s2 = mTrL - mDeltaTr

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
            Next iter

            If (mDeltaTr = 0.0) Then
                mDeltaTr = lastDeltaTr
            End If

            ' Adjusted cutoff time
            sTlag = (Y02 * borderLength) / (2.0 * qin)     ' Strelkoff's Tlag
            mTco = mTrL - sTlag - mPhi1 * mDeltaTr

            ' Recession time at head of border
            mTr0 = mTco + mTlag

            Dim distX As Double

            num = (mTrL - mTr0) * qin
            den = mPhi3 * mSigmaY * Y02
            If (0.0 < den) Then
                distX = num / den
            Else
                distX = borderLength
            End If

            If (distX < 0.0) Then
                distX = 0.0
            ElseIf (distX > borderLength) Then
                distX = borderLength
            End If

            ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
            ComputeIrrigationCurves(borderWidth, borderWidth, distX, mTr0, mTrL, mDMin, mInfiltratedVolume)

            ' Adjust for Dmin < Dreq at upstream of border
            If Not (Me.Tuning) Then
                Dim tInf0 As Double = mOppTimes(0)
                Dim dInf0 As Double = mSoilCropProperties.InfiltrationDepth(tInf0)
                Dim tInfL As Double = mOppTimes(mOppTimes.Count - 1)
                Dim dInfL As Double = mSoilCropProperties.InfiltrationDepth(tInfL)

                ' Is Dmin is at upstream end of border?
                If (dInf0 < mDReq) Then
                    ' Yes, set Tr0 to Treq
                    mTr0 = mTReq
                    mTco = mTr0 - mTlag
                    mTrL = mTco + sTlag + mPhi1 * mDeltaTr

                    ' Did adjustment move Dmin to downstream end of border?
                    If ((mTrL - mAdvanceTime2) < mTReq) Then
                        ' Yes, set TrL to Treq
                        mTrL = mTReq + mAdvanceTime2
                        mTco = mTrL - sTlag - mPhi1 * mDeltaTr
                        mTr0 = mTco + mTlag
                    End If

                    num = (mTrL - mTr0) * qin
                    den = mPhi3 * mSigmaY * Y02
                    If (0.0 < den) Then
                        distX = num / den
                    Else
                        distX = borderLength
                    End If

                    If (distX < 0.0) Then
                        distX = 0.0
                    ElseIf (distX > borderLength) Then
                        distX = borderLength
                    End If

                    ComputeIrrigationCurves(borderWidth, borderWidth, distX, mTr0, mTrL, mDMin, mInfiltratedVolume)
                End If
            End If

            ' Inflow & Infiltrated volume
            mInflowVolume = inflowRate * mTco

            ' Infiltrated Volume cannot be greater than Inflow Volume (can't create water!)
            If ((mInflowVolume < mInfiltratedVolume) And (mInfiltratedVolume < mInflowVolume * 1.01)) Then
                mInfiltratedVolume = mInflowVolume
            End If

            ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
            If (mInflowVolume + OneLiter < mInfiltratedVolume) Then

                ' distX should be greater than it is now but less than the field length
                Dim minDistX As Double = distX
                Dim maxDistX As Double = borderLength

                For iter As Integer = 1 To 25
                    distX = (minDistX + maxDistX) / 2.0

                    ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
                    ComputeIrrigationCurves(borderWidth, borderWidth, distX, mTr0, mTrL, mDMin, mInfiltratedVolume)

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

            '*****************************************************************************************************
            ' Step 6: Adjust for Blocked End, if necessary
            '
            If ((mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) _
            And (0 < mRunoffVolume)) Then
                If (0.0 < S0) Then

                    ' Compensate for ponded infiltration
                    Dim loTco As Double = 0
                    Dim hiTco As Double = mTco

                    Dim blockedTco As Double = mTco / 2.0
                    Dim blockedTr0, blockedTrL As Double

                    ' Binary search for Tco where DMin = DReq
                    For iter As Integer = 0 To 25

                        ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
                        blockedTr0 = blockedTco + mTlag
                        blockedTrL = blockedTco + sTlag + (mPhi1 * mDeltaTr)

                        num = (blockedTrL - blockedTr0) * qin
                        den = mPhi3 * mSigmaY * Y02
                        If (0.0 < den) Then
                            distX = num / den
                        Else
                            distX = borderLength
                        End If

                        If (distX < 0.0) Then
                            distX = 0.0
                        ElseIf (distX > borderLength) Then
                            distX = borderLength
                        End If

                        ComputeIrrigationCurves(borderWidth, borderWidth, distX, blockedTr0, blockedTrL, mDMin, mInfiltratedVolume)

                        ' Inflow & Runoff volumes
                        mInflowVolume = inflowRate * blockedTco
                        mRunoffVolume = Math.Max(mInflowVolume - mInfiltratedVolume, 0)

                        ' Add infiltration due to ponding at end of field
                        AddSlopingFieldPond(borderWidth, borderWidth, mRunoffVolume, mDMin, mInfiltratedVolume)

                        ' Check if Dmin is close enough to Dreq
                        If (mDMin < mDReq - 0.0003) Then
                            loTco = blockedTco                  ' Too small
                        ElseIf (mDReq + 0.0003 < mDMin) Then
                            hiTco = blockedTco                  ' Too large
                        Else
                            Exit For                            ' Just right
                        End If

                        blockedTco = (loTco + hiTco) / 2.0
                    Next iter

                    ' New Tco estimate
                    mTco = blockedTco
                Else ' Slope is level
                    ' Subtract time to input Runoff Volume from Tco
                    mTco -= (mRunoffVolume / inflowRate)
                End If

                ' Adjust recession times to match new Tco
                mTr0 = mTco + mTlag
                mTrL = mTco + sTlag + (mPhi1 * mDeltaTr)

                ' Inflow & Infiltrated volumes
                mInflowVolume = inflowRate * mTco
                mInfiltratedVolume = mInflowVolume

                ' Blocked End; there is no Runoff
                mRunoffVolume = 0

            End If ' If Blocked & Runoff
        End If ' Level vs. sloping border

        '*****************************************************************************************************
        ' Compute & load performance parameters into Contour Point
        '*****************************************************************************************************
        Dim parameter As SingleParameter
        Dim contourPoint As ContourPoint = New ContourPoint

        ComputePerformanceParameters(borderLength, borderWidth)

        ' Move errors & warnings, if any, to Contour Point
        If (S0 < MaximumLevelSlope) Then
            ' Limit Line applies only to Level Basins
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
            contourPoint.ErrMsg = mDictionary.tDesignNotValidID.Translated & " - " & mDictionary.tOverflowYaxGtDmax.Translated
        End If

        If (Dmax * 0.9 < Ymax) Then
            AddExecutionWarning(WarningFlags.DesignNotRecommended, mDictionary.tDesignNotRecommendedID.Translated, mDictionary.tDesignNotRecommendedDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tDesignNotRecommendedID.Translated & " - " & mDictionary.tOverflowYaxNearDmax.Translated
        End If

        ' NOTE - order of Z parameters must match calling function's order
        contourPoint.X = New SingleParameter(CSng(borderLength), Units.Meters)

        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            contourPoint.Y = New SingleParameter(CSng(borderWidth), Units.Meters)
            parameter = New SingleParameter(CSng(inflowRate), Units.Cms)
        Else
            contourPoint.Y = New SingleParameter(CSng(inflowRate), Units.Cms)
            parameter = New SingleParameter(CSng(borderWidth), Units.Meters)
        End If
        contourPoint.Z.Add(parameter)   ' Flow Rate or Basin / Border Width

        parameter = New SingleParameter(CSng(mPAEmin), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Potential Application efficiency

        parameter = New SingleParameter(CSng(mDUmin), Units.Fraction)
        contourPoint.Z.Add(parameter)   ' Distribution uniformity

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

    '******************************************************************************************
    ' Compute Basin / Border Design Point w/ Cutback
    '
    ' This function is adpated from Bert Clemmen's Furrow Design algorithm in FurrowDesign2005.xls
    '
    Protected Overloads Overrides Function DesignPoint(ByVal borderLength As Double,
                                                       ByVal borderWidth As Double,
                                                       ByVal inflowRate As Double,
                                                       ByVal cutbackRate As Double,
                                                       ByVal numDistances As Integer) As ContourPoint
        Debug.Assert(0 < borderLength)
        Debug.Assert(0 < borderWidth)
        Debug.Assert(0 < inflowRate)
        Debug.Assert(0 < numDistances)

        ' If Cutback Rate is 0.0, use method without cutback
        If (cutbackRate <= 0.0) Then
            Return DesignPoint(borderLength, borderWidth, inflowRate, numDistances)
        End If

        ' Instantiate/initialize SRFR Infiltration object; its used for infiltration calculations
        mSoilCropProperties.SetSrfrInfiltration()
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.Length = borderLength
        mSoilCropProperties.SrfrInfiltration.RefCrossSection.BorderWidth = borderWidth
        mSoilCropProperties.SrfrInfiltration.RefInflow.Q0 = inflowRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.Qcb = cutbackRate
        mSoilCropProperties.SrfrInfiltration.RefInflow.L = borderLength

        '**************************************************************************************
        ' Step 1: Get input conditions
        '
        mSigmaY = mBorderCriteria.SigmaY.Value                      ' Tuning factors
        mPhi0 = mBorderCriteria.Phi0Borders.Value
        mPhi1 = mBorderCriteria.Phi1Borders.Value
        mPhi2 = mBorderCriteria.Phi2Borders.Value
        mPhi3 = mBorderCriteria.Phi3Borders.Value

        mArea = borderLength * borderWidth                          ' Basin / Border geometry

        Dim Dmax As Double = mSystemGeometry.Depth.Value

        '**************************************************************************************
        ' Step 2: Compute upstream representative depths & flow areas (before & after cutback)
        '
        Dim W As Double = borderWidth
        Dim Qin As Double = inflowRate

        Dim L1 As Double = borderLength / 2.0
        Dim Y01, A01, R01, WP01, Sf1 As Double
        UpstreamParameters(Qin, L1, borderWidth, S0, Y01, A01, R01, WP01, Sf1)
        Dim V01 As Double = inflowRate / Y01

        Dim L2 As Double = borderLength
        Dim Y02, A02, R02, WP02, Sf2 As Double
        UpstreamParameters(Qin, L2, borderWidth, S0, Y02, A02, R02, WP02, Sf2)
        Dim V02 As Double = inflowRate / Y02

        Dim Y0cb, A0cb, R0cb, WP0cb, Sfcb As Double
        UpstreamParameters(mCutbackRate, L2, borderWidth, S0, Y0cb, A0cb, R0cb, WP0cb, Sfcb)
        Dim V0cb As Double = mCutbackRate / Y0cb

        '**************************************************************************************
        ' Step 3: Compute 2-point advance
        '
        ComputeTwoPointAdvance(L1, A01, V01, L2, A02, V02, borderWidth, borderWidth, Qin, numDistances)

        '**************************************************************************************
        ' Step 4: Determine cutback time
        '
        mDReq = mInflowManagement.RequiredDepth.Value               ' Inflow requirements
        mTReq = mSoilCropProperties.InfiltrationTime(mDReq)

        mTrL = mTReq + mAdvanceTime2                                ' Cutoff & Recession times
        Dim cutoffTime As Double = mTrL

        Dim zTolerance As Double = 0.0000000001
        Dim minCutbackTime As Double = mAdvanceTime2
        Dim maxCutbackTime As Double = Math.Max(cutoffTime, mTrL)
        Dim estCutbackTime As Double = (minCutbackTime + maxCutbackTime) / 2
        Dim reqAvgInfRate As Double = mCutbackRate / mArea

        Try
            ' Binary search for cutback time
            For iter As Integer = 1 To 25

                ' Compute irrigation curves
                mDistances.Clear()
                mAdvTimes.Clear()
                mRecTimes.Clear()
                mOppTimes.Clear()
                mInfRates.Clear()

                For idx As Integer = 0 To numDistances - 1
                    Dim X As Double = (borderLength * idx) / (numDistances - 1)
                    Dim Tadv As Double = mAdvanceTime2 * (X / borderLength) ^ h
                    Dim Trec As Double = Math.Max(estCutbackTime, Tadv)
                    Dim Tau As Double = Math.Max(Trec - Tadv, 0)
                    Dim dZdT As Double = mSoilCropProperties.InfiltrationRate(Tau)

                    mDistances.Add(X)
                    mAdvTimes.Add(Tadv)
                    mRecTimes.Add(Trec)
                    mOppTimes.Add(Tau)
                    mInfRates.Add(DInf)
                Next

                ' Compute average flow rate using integration
                Dim intFlowRate As Double = 0.0

                Dim dist1 As Double = CDbl(mDistances(0))
                Dim dist2 As Double = CDbl(mDistances(1))
                Dim deltaDist As Double = dist2 - dist1

                Dim infRate1 As Double = CDbl(mInfRates(0))
                For idx As Integer = 1 To numDistances - 1
                    Dim infRate2 As Double = CDbl(mInfRates(idx))
                    Dim avgRate As Double = (infRate1 + infRate2) / 2.0

                    intFlowRate += avgRate

                    infRate1 = infRate2
                Next

                intFlowRate *= deltaDist * borderWidth

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

        '**************************************************************************************
        ' Step 5: Compute Performance (w/ Horizontal Recession)
        '   (not supported by WinSRFR)
        '

        '**************************************************************************************
        ' Step 6: Compute Performance (w/ Adjusted cutback time & Recession)
        '
        Dim adjSurfaceVolume As Double = (mSigmaY * mPhi0) * A0cb * borderLength
        mTco = mTReq + mAdvanceTime2 - (mPhi1 * (adjSurfaceVolume / mCutbackRate))
        mTcb = estCutbackTime - (mSurfaceVolume2 - adjSurfaceVolume) / (inflowRate - mCutbackRate)

        sTlag = (Y02 * borderLength) / (2.0 * Qin)     ' Strelkoff's Tlag

        ' Cutback time is limited by Cutoff time
        If (mTcb > mTco) Then
            ' Cutback Time is after than Cutoff Time; this can't happen!
            '  Switch to solution with no Cutback

            ' Recession time at end of border
            mTrL = mTReq + mAdvanceTime2

            ' Adjusted cutoff time; no cutback
            mTco = mTrL - (mPhi1 * (mSurfaceVolume2 / inflowRate))
            mTcb = mTco

            ' Recession lag & recession time at head of border
            mTlag = (mPhi2 * A02 * borderLength) / (2 * inflowRate)
            mTr0 = mTco + mTlag

            ' Compute irrigation curves assuming there is Runoff (i.e. Open End)
            ComputeIrrigationCurves(borderWidth, inflowRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

            ' Inflow  volume
            mInflowVolume = inflowRate * mTco
        Else
            ' Compute equivalent single inflow rate
            Dim adjRate As Double = ((inflowRate * mTcb) + (mCutbackRate * (mTco - mTcb))) / mTco

            ' Recession lag & recession time at head of border
            mTlag = (mPhi2 * A02 * borderLength) / (2 * adjRate)
            mTr0 = mTco
            If (S0 <= 0.0) Then
                mTr0 = mTco + mTlag
            End If

            ' Recession time at end of border
            mTrL = mTco + sTlag + (mPhi1 * (mSurfaceVolume2 / adjRate))

            ' Compute irrigation curves
            ComputeIrrigationCurves(borderWidth, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

            ' Inflow Volume
            mInflowVolume = inflowRate * mTcb + mCutbackRate * (mTco - mTcb)
        End If

        ' Cutback Time Ratio
        mCutbackTimeRatio = mTcb / mTco

        ' Runoff
        mRunoffVolume = Math.Max(mInflowVolume - mInfiltratedVolume, 0)

        '**************************************************************************************
        ' Step 7 - Adjust for Blocked End, if necessary
        '
        If ((mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) _
        And (0 < mRunoffVolume)) Then

            If (0.0 < S0) Then
                ' Compensate for ponded infiltration
                Dim loTco As Double = 0
                Dim hiTco As Double = mTco

                ' Binary search for Tco where DMin = DReq
                For iter As Integer = 0 To 25

                    ' Compute equivalent single inflow rate
                    Dim adjRate As Double = ((inflowRate * mTcb) + (mCutbackRate * (mTco - mTcb))) / mTco

                    ' Recession lag & recession time at head of border
                    mTlag = (mPhi2 * A02 * borderLength) / (2 * adjRate)
                    mTr0 = mTco + mTlag

                    ' Recession time at end of border
                    mTrL = mTco + sTlag + (mPhi1 * (mSurfaceVolume2 / adjRate))

                    ' Compute irrigation curves
                    ComputeIrrigationCurves(borderWidth, adjRate, mTr0, mTrL, mDMin, mInfiltratedVolume)

                    ' Inflow & Runoff volumes
                    mInflowVolume = adjRate * mTco
                    mRunoffVolume = Math.Max(mInflowVolume - mInfiltratedVolume, 0)

                    ' Add infiltration due to ponding at end of field
                    AddSlopingFieldPond(borderWidth, adjRate, mRunoffVolume, mDMin, mInfiltratedVolume)

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
                Next

            Else ' Slope is level
                ' Subtract time to input Runoff Volume from Tco
                If (mTcb < mTco) Then
                    Dim cutbackVolume As Double = (mTco - mTcb) * mCutbackRate

                    If (mRunoffVolume < cutbackVolume) Then
                        ' Runoff is within cutback volume
                        mTco -= (mRunoffVolume / mCutbackRate)
                    Else
                        ' Runoff is more than cutback volume
                        mTco -= (cutbackVolume / mCutbackRate)
                        mTco -= (mRunoffVolume - cutbackVolume) / inflowRate
                        mTcb = mTco
                    End If
                Else ' Tco <= Tcb
                    mTco -= (mRunoffVolume / inflowRate)
                    mTcb = mTco
                End If

            End If

            ' Inflow volume
            If (mTcb < mTco) Then
                mInflowVolume = inflowRate * mTcb + mCutbackRate * (mTco - mTcb)
            Else
                mInflowVolume = inflowRate * mTco
            End If

            ' Infiltrated Volume should not be greater than Inflow Volume (can't create water!)
            If ((mInflowVolume < mInfiltratedVolume) And (mInfiltratedVolume < mInflowVolume * 1.01)) Then
                mInfiltratedVolume = mInflowVolume
            End If

            ' There is no Runoff
            mRunoffVolume = 0
        End If

        '**************************************************************************************
        ' Compute & load performance parameters into Contour Point
        '**************************************************************************************
        Dim parameter As SingleParameter
        Dim contourPoint As ContourPoint = New ContourPoint

        ComputePerformanceParameters(borderLength, borderWidth)

        ' Move errors & warnings, if any, to Contour Point
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
            contourPoint.ErrMsg = mDictionary.tDesignNotValidID.Translated & " - " & mDictionary.tOverflowYaxGtDmax.Translated
        End If

        If (Dmax * 0.9 < Ymax) Then
            AddExecutionWarning(WarningFlags.DesignNotRecommended, mDictionary.tDesignNotRecommendedID.Translated, mDictionary.tDesignNotRecommendedDetail.Translated)
            contourPoint.HasWarning = True
            contourPoint.WarnMsg = mDictionary.tDesignNotRecommendedID.Translated & " - " & mDictionary.tOverflowYaxNearDmax.Translated
        End If

        ' NOTE - order of Z parameters must match calling function's order
        contourPoint.X = New SingleParameter(CSng(borderLength), Units.Meters)

        If (mBorderCriteria.DesignOption.Value = DesignOptions.InflowRateGiven) Then
            contourPoint.Y = New SingleParameter(CSng(borderWidth), Units.Meters)
            parameter = New SingleParameter(CSng(inflowRate), Units.Cms)
        Else
            contourPoint.Y = New SingleParameter(CSng(inflowRate), Units.Cms)
            parameter = New SingleParameter(CSng(borderWidth), Units.Meters)
        End If
        contourPoint.Z.Add(parameter)   ' Flow Rate or Basin / Border Width

        parameter = New SingleParameter(CSng(mPAEmin), Units.Percentage)
        contourPoint.Z.Add(parameter)   ' Potential Application efficiency

        parameter = New SingleParameter(CSng(mDUmin), Units.Fraction)
        contourPoint.Z.Add(parameter)   ' Distribution uniformity

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

    '******************************************************************************************
    ' CalculateSolution() - calculate the solution for the current user values
    '
    Public Overrides Sub CalculateSolution()
        MyBase.CalculateSolution() ' Initialize calculation

        ' Basin / Border Design is for entire field
        mInflowRate = mInflowManagement.InflowRate.Value
        mCutbackRate = mInflowRate * mInflowManagement.CutbackRateRatio.Value

        ' Run a SRFR comparison
        RunSRFR(True, False, False)

        ' Display then Clear any SRFR Execution Errors
        DisplayErrors()
        ClearExecutionErrors()

        ' Save Design Point results (overwites SRFR results)
        SaveSolution()
    End Sub

    Protected Overrides Sub SaveSolution()
        ' Save parameters common to all design analyses
        MyBase.SaveSolution()

        ' Inflow / Runoff curves
        Dim hydrographs As DataTableParameter = mSurfaceFlow.FlowHydrographs
        Dim inflowTable As DataTable = mInflowManagement.HydrographInflowTable(mInflowRate, mTco, _
                                                                               mCutbackRate, mTcb)
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

        ' Tuning Factors must not be default values
        If ((mBorderCriteria.Phi0Borders.Source = ValueSources.Defaulted) _
         Or (mBorderCriteria.Phi1Borders.Source = ValueSources.Defaulted) _
         Or (mBorderCriteria.Phi2Borders.Source = ValueSources.Defaulted) _
         Or (mBorderCriteria.Phi3Borders.Source = ValueSources.Defaulted)) Then
            AddSetupWarning(WarningFlags.DefaultTuningFactors, mDictionary.tDefaultTuningFactorsID.Translated, mDictionary.tDefaultTuningFactorsDetails.Translated)
        End If

    End Sub

#End Region

End Class
