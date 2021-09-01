
'**********************************************************************************************
' Class:    InfiltratedProfile
'
' Desc: Perform Infiltrated Profile Analysis 
'
Imports DataStore

Public Class InfiltratedProfile
    Inherits EventAnalysis

#Region " Member Data "

#Region " Errors "
    '
    ' Error flags (values 1-99 reserved for Analysis baseclass)
    '
    Public Shadows Enum ErrorFlags
        ProbeLengthLtProbedDepth = 101
        LastInfiltratedDepthDistanceNotLength
    End Enum

#End Region

#Region " Warnings "
    '
    ' Warning bit flags (bits 0-9 reserved for Analysis baseclass)
    '
    Public Shadows Enum WarningFlags
        ProbeLengthLtRootZoneDepth = 1 << 10
        CumulativeProfileDepthLtRootZoneDepth = 1 << 11
        RootZoneInfiltrationUnderestimated = 1 << 12
        LeachingRequirementUnderestimated = 1 << 13
        InfiltratedDepthLtUsefulDepth = 1 << 14
    End Enum

#End Region

#End Region

#Region " Properties "

#End Region

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
    End Sub

#End Region

#Region " Methods "

#Region " Evaluation Execution "

    Public Overrides Sub RunEvaluation()
        ' Execute standard start analysis code
        Dim runName As String = mDictionary.tInfiltratedProfileAnalysis.Translated
        Me.StartRun(runName, False)

        ' Set Target Infiltration Depth to Irrigation Target Depth
        Dim targetDepth As Double = mSoilCropProperties.IrrigationTargetDepth

        Dim requiredDepth As DoubleParameter = mInflowManagement.RequiredDepth
        requiredDepth.Value = targetDepth
        requiredDepth.Source = ValueSources.Calculated
        mInflowManagement.RequiredDepth = requiredDepth

        ' Clear calculated Infiltration data
        mSoilCropProperties.ClearInfiltration()

        ' Save Modified Kostiakov parameters
        Dim infiltrationFunction As IntegerParameter = mSoilCropProperties.InfiltrationFunction
        infiltrationFunction.Value = InfiltrationFunctions.ModifiedKostiakovFormula
        infiltrationFunction.Source = ValueSources.Calculated
        mSoilCropProperties.InfiltrationFunction = infiltrationFunction

        Dim wettedPerimeterMethod As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
        wettedPerimeterMethod.Value = WettedPerimeterMethods.FurrowSpacing
        wettedPerimeterMethod.Source = ValueSources.Calculated
        mSoilCropProperties.WettedPerimeterMethod = wettedPerimeterMethod

        Dim k As KostiakovKParameter = mSoilCropProperties.KostiakovK_MK
        k.Value = Double.NaN
        k.Source = ValueSources.Calculated
        mSoilCropProperties.KostiakovK_MK = k

        Dim a As DoubleParameter = mSoilCropProperties.KostiakovA_MK
        a.Value = 0.0
        a.Source = ValueSources.Calculated
        mSoilCropProperties.KostiakovA_MK = a

        Dim b As KostiakovBParameter = mSoilCropProperties.KostiakovB_MK
        b.Value = 0.0
        b.Source = ValueSources.Calculated
        mSoilCropProperties.KostiakovB_MK = b

        Dim c As DoubleParameter = mSoilCropProperties.KostiakovC_MK
        c.Value = 0.0
        c.Source = ValueSources.Calculated
        mSoilCropProperties.KostiakovC_MK = c

        ' Calculate & save the Solution
        CalculateSolution()

        Me.EndRun()
    End Sub

#End Region

#Region " Solution "

    Public Overrides Sub CalculateSolution()
        MyBase.CalculateSolution()

        ' Water Volumes
        Dim Vapp As Double = mInflowManagement.AppliedVolumeForField
        Dim Vinf As Double = mInflowManagement.InfiltratedVolumeForField
        Dim Vro As Double = mInflowManagement.RunoffVolumeForField

        ' System Geometry
        Dim fieldArea As Double = mSystemGeometry.FieldArea

        ' Surface Flow
        mTL = Double.NaN
        mXR = Double.NaN

        ' Infiltration Depths
        mDReq = mInflowManagement.RequiredDepth.Value
        mDapp = Vapp / fieldArea
        mDinf = Vinf / fieldArea

        Dim _runoff As Double = Vro / fieldArea
        mRoFraction = _runoff / mDapp

        Dim _usefulDepth As Double = mSoilCropProperties.UsefulInfiltratedDepth
        Dim _deepPerc As Double = Math.Max(0, mDinf - _usefulDepth)
        mDpFraction = _deepPerc / mDapp

        ' Application Efficiency
        mAE = _usefulDepth / mDapp

        ' Low-Quarter parameters
        mDlf = mSoilCropProperties.AverageInfiltratedDepthLQ
        mADlq = mDlf / mDreq
        mDUlq = mDlf / mDinf

        ' Minimum parameters
        mDmin = mSoilCropProperties.MinimumInfiltratedDepth
        mADmin = mDmin / mDreq
        mDUmin = mDmin / mDInf

        ' Save results
        MyBase.SaveSolution()
    End Sub

#End Region

#Region " Error & Warnings "
    '
    ' Extended check of setup errors and warnings for Infiltrated Profile Analysis
    '
    ' Infiltrated Profile Analysis does not use Infiltration, Roughness or Simulation; don't
    ' include them in the error/warning checking.
    '
    Public Overrides Sub UpdateSetupErrorsAndWarnings()
        CheckSetupErrorsAndWarnings()
        CheckGeometryErrors()
        CheckInflowErrors()
    End Sub
    '
    ' Check for errors in user-entered Infiltrated Profile data
    '
    Public Overrides Function CheckSetupErrors() As Boolean
        Dim _hasErrors As Boolean = MyBase.CheckSetupErrors()

        ' Get SWD values
        Dim _probeLength As Double = mSoilCropProperties.ProbeLength.Value

        ' Get ID values
        Dim _idTable As DataTable = mSoilCropProperties.InfiltratedDepth.Value
        Dim _lastRow As DataRow = _idTable.Rows(_idTable.Rows.Count - 1)
        Dim _lastDistance As Double = CDbl(_lastRow.Item(sDistanceX))

        ' Check IPA Errors
        If Not (_lastDistance = mSystemGeometry.Length.Value) Then
            AddSetupError(ErrorFlags.LastInfiltratedDepthDistanceNotLength, _
                     mDictionary.tLastInfiltratedDepthDistanceNotLengthID.Translated, _
                     mDictionary.tLastInfiltratedDepthDistanceNotLengthDetail.Translated)
        End If

        ' For each row in the DataTable, update its calculated values
        For Each _dataRow As DataRow In _idTable.Rows
            ' Get user entered data
            Dim _probedDepth As Double = CDbl(_dataRow.Item(sProbedDepthX))

            If (_probeLength < _probedDepth) Then
                AddSetupError(ErrorFlags.ProbeLengthLtProbedDepth, _
                         mDictionary.tProbeLengthLtProbedDepthID.Translated, _
                         mDictionary.tProbeLengthLtProbedDepthDetail.Translated)
                Exit For
            End If
        Next

        _hasErrors = Me.HasSetupErrors
        Return _hasErrors
    End Function
    '
    ' Check for warnings in user-entered Infiltrated Profile data
    '
    Public Overrides Function CheckSetupWarnings() As Boolean
        Dim _hasWarnings As Boolean = MyBase.CheckSetupWarnings()

        ' Get SWD values
        Dim _targetDepth As Double = mSoilCropProperties.IrrigationTargetDepth
        Dim _probeLength As Double = mSoilCropProperties.ProbeLength.Value
        Dim _rootZoneDepth As Double = mSoilCropProperties.RootZoneDepth.Value

        Dim _profileRootZoneDepth As Double = mSoilCropProperties.ProfileRootZoneDepth
        Dim _profileRootZoneSWD As Double = mSoilCropProperties.ProfileSoilWaterDeficit

        Dim _cumulativeSWD As Double = mSoilCropProperties.CumulativeSWD
        Dim _cumulativeProfileDepth As Double = mSoilCropProperties.CumulativeProfileDepth

        ' Get ID values
        Dim _idTable As DataTable = mSoilCropProperties.InfiltratedDepth.Value
        Dim _lastRow As DataRow = _idTable.Rows(_idTable.Rows.Count - 1)
        Dim _lastDistance As Double = CDbl(_lastRow.Item(sDistanceX))

        ' Check IPA Warnings
        If (_probeLength < _rootZoneDepth) Then
            AddSetupWarning(WarningFlags.ProbeLengthLtRootZoneDepth, _
                       mDictionary.tProbeLengthLtRootZoneDepthID.Translated, _
                       mDictionary.tProbeLengthLtRootZoneDepthDetail.Translated)
        End If

        If (_cumulativeProfileDepth < _rootZoneDepth) Then
            AddSetupWarning(WarningFlags.CumulativeProfileDepthLtRootZoneDepth, _
                       mDictionary.tCumulativeProfileDepthLtRootZoneDepthID.Translated, _
                       mDictionary.tCumulativeProfileDepthLtRootZoneDepthDetail.Translated)
        End If

        ' For each row in the DataTable, check its calculated values
        For Each _dataRow As DataRow In _idTable.Rows
            ' Enclose in Try/Catch block to trap exceptions
            Try
                ' Get user entered data
                Dim _probedDepth As Double = CDbl(_dataRow.Item(sProbedDepthX))
                Dim _probedSWD As Double = mSoilCropProperties.InterpolateSwd(_probedDepth)
                '
                ' Profile Infiltrated Depth
                '
                Dim _profileID As Double = Double.NaN

                If Not (_probeLength < _probedDepth) Then
                    If (_probedDepth < _cumulativeProfileDepth) Then
                        _profileID = _probedSWD
                    Else
                        _profileID = _cumulativeSWD
                    End If
                End If
                '
                ' Root Zone Infiltrated Depth
                '
                Dim _rootZoneID As Double = Double.NaN

                If Not (_probeLength < _probedDepth) Then
                    If (_probedDepth < _profileRootZoneDepth) Then
                        _rootZoneID = _probedSWD
                    Else
                        _rootZoneID = _profileRootZoneSWD
                    End If

                    ' Check for underestimation of Root Zone Infiltration
                    If (((mSetupWarnings And WarningFlags.ProbeLengthLtRootZoneDepth) = WarningFlags.ProbeLengthLtRootZoneDepth) _
                     Or ((mSetupWarnings And WarningFlags.CumulativeProfileDepthLtRootZoneDepth) = WarningFlags.CumulativeProfileDepthLtRootZoneDepth)) Then

                        If (_cumulativeSWD <= _rootZoneID) Then
                            If Not ((mSetupWarnings And WarningFlags.RootZoneInfiltrationUnderestimated) = WarningFlags.RootZoneInfiltrationUnderestimated) Then
                                AddSetupWarning(WarningFlags.RootZoneInfiltrationUnderestimated, _
                                           mDictionary.tRootZoneInfiltrationUnderestimatedID.Translated, _
                                           mDictionary.tRootZoneInfiltrationUnderestimatedDetail.Translated)
                            End If
                        End If
                    End If
                End If
                '
                ' Useful Infiltrated Depth
                '
                Dim _usefulID As Double = Double.NaN

                If Not (_probeLength < _probedDepth) Then
                    If (_probedSWD < _targetDepth) Then
                        _usefulID = _probedSWD
                    Else
                        _usefulID = _targetDepth
                    End If
                End If
                '
                ' Leaching Requirement
                '
                If Not (_probeLength < _probedDepth) Then
                    ' Check for underestimation of Leaching Requirement
                    If (_usefulID < _targetDepth) Then

                        If ((_cumulativeProfileDepth < _probedDepth) _
                         Or (_probeLength = _probedDepth)) Then

                            If Not ((mSetupWarnings And WarningFlags.LeachingRequirementUnderestimated) = WarningFlags.LeachingRequirementUnderestimated) Then
                                AddSetupWarning(WarningFlags.LeachingRequirementUnderestimated, _
                                           mDictionary.tLeachingRequirementUnderestimatedID.Translated, _
                                           mDictionary.tLeachingRequirementUnderestimatedDetail.Translated)
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
            End Try
        Next

        _hasWarnings = Me.HasSetupWarnings
        Return _hasWarnings
    End Function

#End Region

#End Region

End Class
