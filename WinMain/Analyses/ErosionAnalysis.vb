
'*************************************************************************************************************
' Class:    ErosionAnalysis
'
' Desc: Perform Erosion Analysis 
'
Imports Srfr.SrfrAPI
Imports DataStore

Public Class ErosionAnalysis
    Inherits EventAnalysis

#Region " Member Data "

#Region " Errors "
    '
    ' Error flags (values 1-99 reserved for Analysis baseclass)
    '
    Public Shadows Enum ErrorFlags
        BlockedEnd = 101
        FieldLevel
        PercentRetainedTooSmall
        PercentRetainedTooLarge
        SieveSizeTooSmall
        SpecGravityOutOfRange
        BadMeas
        BadMeasTime
        BadMeasDist
        NoErosion
    End Enum
    '
    ' Error IDs
    '
    Public Shared BlockedEndID As String = _
        "Erosion Analysis does not support Blocked Ends"

    Public Shared FieldLevelID As String = _
        "Erosion Analysis does not support level fields"

    Public Shared PercentRetainedTooSmallID As String = _
        "Retained (%) < 0"

    Public Shared PercentRetainedTooLargeID As String = _
        "Retained (%) total must be less than 100%"

    Public Shared SieveSizeTooSmallID As String = _
        "Sieve Size < 0"

    Public Shared SpecGravityOutOfRangeID As String = _
        "Specific Gravity must be between 1.0 and 3.0"

    Public Shared BadMeasID As String = _
        "Invalid Erosion Measurement CGm"

    Public Shared BadMeasTimeID As String = _
        "Invalid Erosion Measurement Time"

    Public Shared BadMeasDistID As String = _
        "Invalid Erosion Measurement Distance"

    Public Shared NoErosionID As String = _
        "No Erosion during simulation"
    '
    ' Error Details
    '
    Public Shared BlockedEndDetails As String = _
        "Erosion Analysis only supports fields with Open Ends."

    Public Shared FieldLevelDetails As String = _
        "Erosion Analysis only supports sloping fields."

    Public Shared PercentRetainedTooSmallDetails As String = _
        "Individual Retained (%) values cannot be negative."

    Public Shared PercentRetainedTooLargeDetails As String = _
        "Sum of Retained (%) values must be less than 100%."

    Public Shared SieveSizeTooSmallDetails As String = _
        "Individual Sieve Size values cannot be negative."

    Public Shared SpecGravityOutOfRangeDetails As String = _
        "Specific Gravity is less than 1.0 or greater than 3.0"

    Public Shared BadMeasDetails As String = _
        "Erosion Measurement must be greater than zero."

    Public Shared BadMeasTimeDetails As String = _
        "Erosion Measurement Time must be greater than zero and less than Cutoff Time."

    Public Shared BadMeasDistDetails As String = _
        "Erosion Measurement Time must be 1/4 Length."

    Public Shared NoErosionDetails As String = _
        "No Erosion during simulation at measurement point."

#End Region

#End Region

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
    End Sub

#End Region

#Region " SRFR Adjustments "

    '******************************************************************************************
    ' Adjust SRFR Criteria to match the specific point being analyzed
    '
    ' After the SRFR Criteria has been loaded from the Unit but prior to the SRFR Simulation
    ' being executed, the SRFR Criteria can be modified to meet any special requirements of
    ' the analysis by overriding AdjustSrfrCriteria().
    '
    Public Overrides Sub AdjustSrfrInputs(ByVal unit As Unit)
        If Not (unit Is Nothing) Then

        End If ' Not (unit Is Nothing)
    End Sub

#End Region

#Region " Erosion Parameter Estimation "

    Public Overrides Sub RunEvaluation()
        ' Execute standard start analysis code
        Me.StartRun("Erosion Parameter Estimation", False)

        ' Get user measured Erosion data
        Dim userTime As Double = mSoilCropProperties.SedimentTime.Value
        Dim userDist As Double = mSoilCropProperties.SedimentDistance.Value
        Dim userCGm As Double = mSoilCropProperties.SedimentConcentration.Value

        ' Compute & save TauC
        Dim parameter As DoubleParameter = mSoilCropProperties.ErodibilityTauc
        parameter.Value = mSoilCropProperties.ComputedErodibilityTauC
        parameter.Source = ValueSources.Calculated
        mSoilCropProperties.ErodibilityTauc = parameter

        mSoilCropProperties.ErodibilityTaucProperty.ToBeCalculated = False

        ' Restore default Beta
        parameter = mSoilCropProperties.ErodibilityBeta
        parameter.Value = DefaultErodibilityBeta
        parameter.Source = ValueSources.Calculated
        mSoilCropProperties.ErodibilityBeta = parameter

        mSoilCropProperties.ErodibilityBetaProperty.ToBeCalculated = False

        ' Estimate KR (i.e. A when B=0)
        Dim KR As DoubleParameter
        Dim minKR As Double = 0.000001
        Dim maxKR As Double = 1.0

        parameter = mSoilCropProperties.ErodibilityB
        parameter.Value = DefaultErodibilityB
        parameter.Source = ValueSources.Calculated
        mSoilCropProperties.ErodibilityB = parameter

        mSoilCropProperties.ErodibilityBProperty.ToBeCalculated = False

        ' Find Max KR
        For iter As Integer = 1 To 25
            Me.StatusMessage = "Estimating KR"

            ' Adjust value of KR
            KR = mSoilCropProperties.ErodibilityA
            KR.Value = maxKR
            KR.Source = ValueSources.Calculated
            mSoilCropProperties.ErodibilityA = KR

            mSoilCropProperties.ErodibilityAProperty.ToBeCalculated = False

            ProgressMessage = KR.Value

            ' Run SRFR simulation with adjusted KR
            RunSRFR(False, True, True)

            Dim CGm As DataSet = mSurfaceFlow.ErosionCGmHydrographs.Value
            Dim srfrCGm As Double = FindValueAtDistanceAndTime(CGm, userDist, userTime)

            If (0 < mPerformanceResults.ErrorCount.Value) Then
                Dim title As String = "Execution Error"
                Dim msg As String

                msg = "The Erosion Simulation failed."
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tAdditionalErrorMessagesMayFollow.Translated

                MsgBox(msg, MsgBoxStyle.Exclamation, title)

                DisplayErrors()
                Exit For
            End If

            If ((iter = 1) And (srfrCGm = 0.0)) Then        ' No erosion at measurement point
                minKR = 0.0
                maxKR = 2.0
                Exit For
            End If

            If (userCGm < srfrCGm) Then
                Exit For                                    ' KR < maxKR
            End If

            minKR = maxKR                                   ' maxKR < KR; set min to max
            maxKR *= 2.0                                    ' Double maxKR and keep looking
        Next

        ' Find KR using bisection
        For iter As Integer = 1 To 25
            Me.StatusMessage = "Estimating KR"

            ' Adjust value of KR
            KR = mSoilCropProperties.ErodibilityA
            KR.Value = (minKR + maxKR) / 2.0
            KR.Source = ValueSources.Calculated
            mSoilCropProperties.ErodibilityA = KR

            mSoilCropProperties.ErodibilityAProperty.ToBeCalculated = False

            ProgressMessage = KR.Value

            ' Run SRFR simulation with adjusted KR
            RunSRFR(False, True, True)

            Dim CGm As DataSet = mSurfaceFlow.ErosionCGmHydrographs.Value
            Dim srfrCGm As Double = FindValueAtDistanceAndTime(CGm, userDist, userTime)

            If (0 < mPerformanceResults.ErrorCount.Value) Then
                Dim title As String = "Execution Error"
                Dim msg As String

                msg = "The Erosion Simulation failed."
                msg += Chr(13)
                msg += Chr(13) + mDictionary.tAdditionalErrorMessagesMayFollow.Translated

                MsgBox(msg, MsgBoxStyle.Exclamation, title)

                DisplayErrors()

                mSoilCropProperties.ErodibilityAProperty.ToBeCalculated = True
                Exit For
            End If

            If ((iter = 1) And (srfrCGm = 0.0)) Then
                Dim title As String = "Erosion Error"
                Dim msg As String

                msg = "No Erosion occurs during Simulation at " + TimeString(userTime, 0) + "."
                msg += Chr(13)
                msg += Chr(13) + "Verify the following inputs are correct:"
                msg += Chr(13)
                msg += Chr(13) + " 1) Slope"
                msg += Chr(13) + " 2) Inflow Rate"
                msg += Chr(13) + " 3) Sediment Components Table"

                MsgBox(msg, MsgBoxStyle.Exclamation, title)

                ' Error value of KR
                KR = mSoilCropProperties.ErodibilityA
                KR.Source = ValueSources.Errored
                mSoilCropProperties.ErodibilityA = KR

                AddExecutionError(ErrorFlags.NoErosion, NoErosionID, NoErosionDetails)
                Exit For
            End If

            If (srfrCGm < userCGm - 0.0001) Then
                minKR = KR.Value                            ' Too small
            ElseIf (userCGm + 0.0001 < srfrCGm) Then
                maxKR = KR.Value                            ' Too large
            Else
                Exit For                                    ' Just right
            End If

            If (ThisClose(minKR, maxKR, 0.00001)) Then
                Exit For                                    ' Close enough
            End If
        Next

        Me.EndRun()
    End Sub

#End Region

#Region " Errors & Warnings "
    '
    ' Check for setup Errors and/or Warnings
    '
    Public Overrides Function CheckSetupErrors() As Boolean
        MyBase.CheckSetupErrors()
        CheckGeometryErrors()

        ' Verify Sediment Components table
        Dim sediment As DataTable = mSoilCropProperties.SedimentComponents.Value
        Dim retainedNegative As Boolean = False
        Dim sieveSizeNegative As Boolean = False
        Dim retainedTotal As Double = 0.0

        For Each row As DataRow In sediment.Rows
            Dim retained As Double = row.Item(nPercentRetainedX)
            Dim sieveSize As Double = row.Item(nSieveSizeX)
            Dim specGravity As Double = row.Item(nSpecificGravityX)

            If (retained < 0.0) Then
                retainedNegative = True
            End If

            If (sieveSize < 0.0) Then
                sieveSizeNegative = True
            End If

            If ((specGravity < 1.0) Or (3.0 < specGravity)) Then
                AddSetupError(ErrorFlags.SpecGravityOutOfRange, SpecGravityOutOfRangeID, SpecGravityOutOfRangeDetails)
            End If

            retainedTotal += retained
        Next

        If (retainedNegative) Then
            AddSetupError(ErrorFlags.PercentRetainedTooSmall, PercentRetainedTooSmallID, PercentRetainedTooSmallDetails)
        End If

        If (sieveSizeNegative) Then
            AddSetupError(ErrorFlags.SieveSizeTooSmall, SieveSizeTooSmallID, SieveSizeTooSmallDetails)
        End If

        If (1.0 <= retainedTotal) Then
            AddSetupError(ErrorFlags.PercentRetainedTooLarge, PercentRetainedTooLargeID, PercentRetainedTooLargeDetails)
        End If

        ' Erosion measurement must be greater than zero
        Dim CGm As Double = mSoilCropProperties.SedimentConcentration.Value
        If (CGm <= 0.0) Then
            AddSetupError(ErrorFlags.BadMeas, BadMeasID, BadMeasDetails)
        End If

        ' Erosion measurement time must be greater than zero and less than Cutoff Time
        Dim time As Double = mSoilCropProperties.SedimentTime.Value
        Dim tco As Double = mInflowManagement.CutoffTime.Value

        If (mInflowManagement.InflowMethod.Value = InflowMethods.TabulatedInflow) Then
            Dim inflow As DataTable = mInflowManagement.TabulatedInflow.Value
            If Not (inflow Is Nothing) Then
                Dim idx As Integer = inflow.Rows.Count - 1
                If (0 <= idx) Then
                    tco = CDbl(inflow.Rows(idx).Item(sTimeX))
                End If
            End If
        End If

        If ((time <= 0.0) Or (tco < time)) Then
            AddSetupError(ErrorFlags.BadMeasTime, BadMeasTimeID, BadMeasTimeDetails)
        End If

        ' Erosion measurement distance must be 1/4 length
        Dim dist As Double = mSoilCropProperties.SedimentDistance.Value
        Dim length As Double = mSystemGeometry.Length.Value / 4.0

        If Not (ThisClose(dist, length, OneDecimeter)) Then
            AddSetupError(ErrorFlags.BadMeasDist, BadMeasDistID, BadMeasDistDetails)
        End If

        Dim _errors As Boolean = Me.HasSetupErrors
        Return _errors
    End Function

    Public Overrides Sub CheckGeometryErrors()
        MyBase.CheckGeometryErrors()

        ' Field can't be level
        If (mSystemGeometry.AverageSlope <= MaximumLevelSlope) Then
            AddSetupError(ErrorFlags.FieldLevel, FieldLevelID, FieldLevelDetails)
        End If

        ' Downstream end can't be blocked
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
            AddSetupError(ErrorFlags.BlockedEnd, BlockedEndID, BlockedEndDetails)
        End If
    End Sub

#End Region

End Class
