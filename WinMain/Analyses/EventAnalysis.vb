
'*************************************************************************************************************
' Class:    EventAnalysis - abstract baseclass for all Event Analyses
'
' Desc: Baseclass for all WinSRFR Event Analyses; derived from Analysis
'*************************************************************************************************************
Imports System.Collections.Generic

Imports DataStore

Public MustInherit Class EventAnalysis
    Inherits Analysis

#Region " Member Data "

    Protected mRunSimWithSlope As Boolean = False

#End Region

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
    End Sub

#End Region

#Region " Methods "

#Region " Evaluation Execution "

    '******************************************************************************************
    ' Run the Evaluation Analysis
    '
    Public MustOverride Sub RunEvaluation()

#End Region

#Region " Simulation Execution "

    Public Overrides Sub AdjustSrfrInputs(ByVal unit As Unit)
        ' Set the Bottom Description to match particular requirements
        Dim srfrCrossSection As Srfr.CrossSection = Me.SrfrAPI.CrossSection
        If (srfrCrossSection IsNot Nothing) Then
            If (mRunSimWithSlope) Then ' Run Simulation with Slope / Average Slope
                srfrCrossSection.ClearElevations() ' Clear the Elevation Table, if it set
            End If
        End If
    End Sub

    Public Overrides Sub RunSimulation(Optional ByVal MinCellDensity As Integer = CellDensities.Medium)
        mRunSimWithSlope = False
        MyBase.RunSimulation(MinCellDensity)

        ' Check for Simulation error
        If (mUnit IsNot Nothing) Then
            Dim _performanceResults As PerformanceResults = mUnit.PerformanceResultsRef
            Dim errorCount As Integer = _performanceResults.ErrorCount.Value

            If (0 < errorCount) Then
                Dim errorList As ArrayList = _performanceResults.ErrorStack.Array

                Dim title As String = mDictionary.tErrAnalysisVerification.Translated
                Dim msg As String = mDictionary.tErrSimulationFailedDueToData.Translated
                msg &= Chr(10)
                If (1 < errorList.Count) Then
                    If (errorList(1).GetType Is GetType(String)) Then
                        msg &= errorList(1)
                    End If
                End If
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
            End If
        End If
    End Sub

    Public Sub RunSimulationWithSlope(ByVal WithSlope As Boolean, _
                             Optional ByVal MinCellDensity As Integer = CellDensities.Medium)
        mRunSimWithSlope = WithSlope
        MyBase.RunSimulation(MinCellDensity)

        ' Check for Simulation error
        If (mUnit IsNot Nothing) Then
            Dim _performanceResults As PerformanceResults = mUnit.PerformanceResultsRef
            Dim errorCount As Integer = _performanceResults.ErrorCount.Value

            If (0 < errorCount) Then
                Dim errorList As ArrayList = _performanceResults.ErrorStack.Array

                Dim title As String = mDictionary.tErrAnalysisVerification.Translated
                Dim msg As String = mDictionary.tErrSimulationFailedDueToData.Translated
                msg &= Chr(10)
                If (1 < errorList.Count) Then
                    If (errorList(1).GetType Is GetType(String)) Then
                        msg &= errorList(1)
                    End If
                End If
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
            End If
        End If
    End Sub

    Protected Overrides Function UnloadSrfrResults(ByVal srfrAPI As Srfr.SrfrAPI, ByVal unit As Unit,
    ByVal compareRun As Boolean, ByVal skipProfiles As Boolean, ByVal skipHydroGraphs As Boolean) As Srfr.Irrigation
        ' Unload the SRFR results common to all/most Analyses
        Dim srfrIrrigation As Srfr.Irrigation = Nothing
        srfrIrrigation = MyBase.UnloadSrfrResults(srfrAPI, unit, compareRun, skipProfiles, skipHydroGraphs)

        Return srfrIrrigation
    End Function

#End Region

#Region " Contour Point "

    '******************************************************************************************
    ' Method to get a specified Design Contour Point
    '
    Public Overrides Function GetContourPoint(ByVal x As Double, ByVal y As Double, _
                                              ByVal numDistances As Integer) As ContourPoint
        Dim point As ContourPoint = Nothing
        Return point
    End Function

#End Region

#Region " Automation "

    '*********************************************************************************************************
    ' Sub AutoRun()                 - runs Event Analysis via automation interface as opposed to the UI
    '*********************************************************************************************************
    Public Overrides Sub AutoRun()
        RunEvaluation()
    End Sub

#End Region

#Region " Errors & Warnings "

    '*********************************************************************************************************
    ' Sub CheckVolumeBalancesErrors() - check Volume Balance table for errors
    '*********************************************************************************************************
    Public Overridable Sub CheckVolumeBalancesErrors(Optional ByVal VolBalTable As DataTable = Nothing)

        Dim errorID As String = mDictionary.tInvalidVolumeBalanceTableID.Translated
        Dim errorDetail As String = mDictionary.tInvalidVolumeBalanceDetail.Translated
        Dim err As Boolean = False

        ' Verify Volume Balance Table has data
        If (VolBalTable Is Nothing) Then
            VolBalTable = mEventCriteria.VolumeBalances.Value
        End If

        If ((DataTableHasData(VolBalTable, 1)) _
        And (DataColumnIsDouble(VolBalTable, nTimeX)) _
        And (DataColumnIsDouble(VolBalTable, sVz))) Then ' table has data
            '
            ' Verify:
            '   1) Times in VB table are valid for making VB calculations
            '
            Dim L As Double = mSystemGeometry.Length.Value

            For Each vbRow As DataRow In VolBalTable.Rows
                Dim T As Double = vbRow.Item(nTimeX)

                Dim inflowError As InflowManagement.InflowErrors = mInflowManagement.ValidateInflowTimeForVin(T)
                If (inflowError = InflowManagement.InflowErrors.TimeNotValidForVin) Then
                    errorID = mDictionary.tInvalidVbTimeDetail.Translated & " (T = " & TimeString(T) & ")"
                    AddSetupError(ErrorFlags.VolumeBalances, errorID, "")
                    Return
                End If

                Dim advanceError As InflowManagement.AdvanceErrors = mInflowManagement.ValidateAdvanceTimeForVy(T, L)
                If (advanceError = InflowManagement.AdvanceErrors.TimeNotValidForVy) Then
                    errorID = mDictionary.tInvalidVbTimeDetail.Translated & " (T = " & TimeString(T) & ")"
                    AddSetupError(ErrorFlags.VolumeBalances, errorID, "")
                    Return
                End If

                Dim runoffError As InflowManagement.RunoffErrors = mInflowManagement.ValidateRunoffTimeForVro(T)
                If (runoffError = InflowManagement.RunoffErrors.TimeNotValidForVro) Then
                    errorID = mDictionary.tInvalidVbTimeDetail.Translated & " (T = " & TimeString(T) & ")"
                    AddSetupError(ErrorFlags.VolumeBalances, errorID, "")
                    Return
                End If

                Dim recessionError As InflowManagement.RecessionErrors = mInflowManagement.ValidateRecessionTimeForVB(T)
                If (recessionError = InflowManagement.RecessionErrors.TimeNotValidForVB) Then
                    errorID = mDictionary.tInvalidVbTimeDetail.Translated & " (T = " & TimeString(T) & ")"
                    AddSetupError(ErrorFlags.VolumeBalances, errorID, "")
                    Return
                End If

            Next vbRow

        Else ' No data in table is an error
            AddSetupError(ErrorFlags.VolumeBalances, errorID, errorDetail)
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub CheckVolumeBalancesWarnings() - check Volume Balance table for warnings
    '*********************************************************************************************************
    Public Overridable Sub CheckVolumeBalancesWarnings(Optional ByVal VolBalTable As DataTable = Nothing)

        Dim warningID As String = mDictionary.tVolumeBalanceTableID.Translated
        Dim warningDetail As String = mDictionary.tInvalidVolumeBalanceDetail.Translated
        Dim warn As Boolean = False

        ' Verify Volume Balance Table has data
        If (VolBalTable Is Nothing) Then
            VolBalTable = mEventCriteria.VolumeBalances.Value
        End If

        If ((DataTableHasData(VolBalTable, 1)) _
        And (DataColumnIsDouble(VolBalTable, nTimeX)) _
        And (DataColumnIsDouble(VolBalTable, sVz))) Then ' table has data

            Dim Vz1 As Double = -Double.Epsilon
            '
            ' Verify:
            '   1) Infiltrated volume values (Vz) increase with time
            '
            For Each vbRow As DataRow In VolBalTable.Rows
                Dim T As Double = vbRow.Item(nTimeX)
                Dim Vz2 As Double = vbRow.Item(sVz)

                If (Vz2 <= Vz1) Then
                    warningDetail = mDictionary.tInvalidVbVzValuesDetail.Translated
                    AddSetupWarning(ErrorFlags.VolumeBalances, warningID, warningDetail)
                    Return
                End If

                Vz1 = Vz2
            Next vbRow

        End If
    End Sub

    '*********************************************************************************************************
    ' Sub CheckEstimatedSurfaceVolumesErrors()      - check Surface Volumes table for errors
    ' Sub CheckEstimatedSurfaceVolumesWarnings()    -   "      "       "      "    "  warnings
    '
    ' Input(s):     SurfaceVolumes      - DataTable of Surface Volumes vs. Time
    '*********************************************************************************************************
    Public Overridable Sub CheckEstimatedSurfaceVolumesErrors(ByVal SurfaceVolumes As DataTable)

        Dim errorID As String = mDictionary.tInvalidEstimatedSurfaceVolumeTableID.Translated
        Dim errorDetail As String = mDictionary.tInvalidEstimatedSurfaceVolumeDetail.Translated
        Dim err As Boolean = False

        ' Verify Surface Volumes Table has data
        If ((DataTableHasData(SurfaceVolumes, 1)) _
        And (DataColumnIsDouble(SurfaceVolumes, nTimeX)) _
        And (DataColumnIsDouble(SurfaceVolumes, sDistX))) Then ' table has data

            Dim L As Double = mSystemGeometry.Length.Value  ' Length of field
            Dim TL As Double = mInflowManagement.TL         ' Time advance reached end-of-field

            If Not (Double.IsNaN(TL)) Then ' Advance reached end-of-field
                Dim vbRow As DataRow = Nothing

                ' Verify each post-advance distance in table is at the end-of-field
                For Each vbRow In SurfaceVolumes.Rows
                    Dim time As Double = vbRow.Item(nTimeX)
                    Dim dist As Double = vbRow.Item(sDistX)

                    If (TL < time) Then ' Post-advance
                        If (dist < L) Then ' Error (distance should be at the end-of-field)
                            If (err = False) Then ' 1st distance found in error
                                err = True
                                errorID &= " - " & mDictionary.tVerifyAdvancePowerLawParameters.Translated
                                errorDetail = mDictionary.tInvalidEstimatedSurfaceVolumeXpaDistance.Translated
                                errorDetail &= ": " & LengthString(dist)
                            Else
                                errorDetail &= ", " & LengthString(dist)
                            End If
                        End If
                    End If

                Next vbRow

                If (err) Then
                    AddSetupError(ErrorFlags.EstimatedSurfaceVolumes, errorID, errorDetail)
                    Return
                End If
            End If
        Else ' No data in table is an error
            AddSetupError(ErrorFlags.EstimatedSurfaceVolumes, errorID, errorDetail)
        End If
    End Sub

    Public Overridable Sub CheckEstimatedSurfaceVolumesWarnings(ByVal SurfaceVolumes As DataTable)

        Dim warnID As String = mDictionary.tSigmaYEstimatedSurfaceVolumeID.Translated
        Dim warnDetail As String = mDictionary.tSigmaYEstimatedSurfaceVolumeDetail.Translated
        Dim warn As Boolean = False

        ' Verify Surface Volumes Table has data
        If ((DataTableHasData(SurfaceVolumes, 1)) _
        And (DataColumnIsDouble(SurfaceVolumes, nTimeX)) _
        And (DataColumnIsDouble(SurfaceVolumes, sDistX))) Then ' table has data

            Dim L As Double = mSystemGeometry.Length.Value  ' Length of field
            Dim TL As Double = mInflowManagement.TL         ' Time advance reached end-of-field

            If Not (Double.IsNaN(TL)) Then ' Advance reached end-of-field
                Dim vbRow As DataRow = Nothing

                ' Verify each Sigma Y in table is valid and within expected range
                For Each vbRow In SurfaceVolumes.Rows
                    Dim Sy As Double = vbRow.Item(sSigmaY)

                    If ((Double.IsNaN(Sy)) Or (1.0 < Sy)) Then
                        warn = True
                    End If
                Next vbRow

                If (warn) Then
                    AddSetupWarning(ErrorFlags.EstimatedSurfaceVolumes, warnID, warnDetail)
                    Return
                End If
            End If
        End If

    End Sub

#End Region

#End Region

End Class

