
'**********************************************************************************************
' Class:    SrfrSimulation
'
' Desc:     Run a simulation on a Basin, Border or Furrow.
'
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Imports DataStore

Imports Srfr.Characteristic

Public Class SrfrSimulation
    Inherits Analysis

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
        SoilErodibilityErrors
    End Enum

#End Region

#End Region

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
        If Not (mUnit Is Nothing) Then
        End If
    End Sub

#End Region

#Region " Contour Point "

    '******************************************************************************************
    ' Method to get a specified Contour Point (not used)
    '
    Public Overrides Function GetContourPoint(ByVal x As Double, ByVal y As Double, _
                                              ByVal numDistances As Integer) As ContourPoint
        Dim point As ContourPoint = Nothing
        Return point
    End Function

#End Region

#Region " Automation "

    '*********************************************************************************************************
    ' Function PreAutoRun()     - performs pre-AutoRun functions such as setup error checking
    '
    ' Returns:      True        OK - No Error/Warning present
    '               False       Not OK - Error/Warning present
    '
    ' Note - for simulations coupled w/HYDRUS, also sync SRFR & HYDRUS prior to AutoRun()
    '*********************************************************************************************************
    Public Overrides Function PreAutoRun() As Boolean
        PreAutoRun = MyBase.PreAutoRun()      ' Check baseclass errors first

        If (PreAutoRun) Then ' baseclass check OK
            ' Sync SRFR w/ HYDRUS if selected
            If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.Hydrus1D) Then
                PreAutoRun = Me.SyncWithHydrus()
            End If
        End If

    End Function

#End Region

#Region " Solution "

    '******************************************************************************************
    ' Methods to calculate and save a Solution (not used)
    '
    Public Overrides Sub CalculateSolution()
        Me.RunSimulation()
        ' Initialize calculation
        MyBase.CalculateSolution()
    End Sub

    Protected Overrides Sub SaveSolution()
        ' Save parameters common to all analyses
        MyBase.SaveSolution()
    End Sub

    Public Overrides Sub AdjustSrfrCriteria(ByVal unit As Unit, ByVal solmod As Srfr.SolutionModel)

        solmod.TimeLimitEventsEnabled = EnableTimeLimitEvents
        solmod.TimestepLimitEventsEnabled = EnableTimestepLimitEvents

        EnableTimeLimitEvents = False
        EnableTimestepLimitEvents = False

    End Sub

#End Region

#Region " Erosion "

#Region " SRFR Erosion "

    Public Sub RunSrfrErosion()

        Dim erosion As Erosion = mUnit.ErosionRef
        Dim surfaceFlow As SurfaceFlow = mUnit.SurfaceFlowRef
        Dim subsurfaceFlow As SubsurfaceFlow = mUnit.SubsurfaceFlowRef
        Dim srfrCriteria As SrfrCriteria = mUnit.SrfrCriteriaRef
        Dim soilCropProperties As SoilCropProperties = mUnit.SoilCropPropertiesRef

        If ((SrfrIrrigation Is Nothing) Or (SrfrTransport Is Nothing)) Then
            Return
        End If
        '
        ' Get the Erosion results
        '
        Dim srfrXticsNet As ReadOnlyCollection(Of Srfr.Characteristic) = SrfrTransport.CharacteristicNet

        If (srfrXticsNet IsNot Nothing) Then
            If (0 < srfrXticsNet.Count) Then ' Characteristics Net was generated during simulation run

                ' Variables for Xtics
                Dim xticsParam As DataSetParameter = erosion.Xtics
                Dim xtics As DataSet = New DataSet("XTICS")

                ' Variables for XticsGrid
                Dim xticsGridParam As DataSetParameter = erosion.XticsGrid
                Dim xticsGrid As DataSet = New DataSet("XTICS Grid")
                Dim xxGrid As DataTable = New DataTable("XX Grid")
                Dim txGrid As DataTable = New DataTable("TX Grid")

                xxGrid.Columns.Add(sXXm, GetType(Double))
                txGrid.Columns.Add(sTXs, GetType(Double))
                xticsGrid.Tables.Add(xxGrid)
                xticsGrid.Tables.Add(txGrid)

                ' Variables for Erosion
                Dim infiltration As DataTable = subsurfaceFlow.LongitudinalInfiltration.Value

                ' Move SRFR Characteristics to WinSRFR
                Dim xticNo As Integer = 1
                Dim lastXX As Double = Double.MinValue
                For Each srfrXtic As Srfr.Characteristic In srfrXticsNet

                    Dim xticCurve As List(Of Srfr.Node) = srfrXtic.XticCurve
                    If (xticCurve IsNot Nothing) Then ' there is an XTIC Curve
                        If (1 < xticCurve.Count) Then ' and it has more than 1 point

                            ' Each XTIC Curve is stored in its own DataTable
                            Dim xtic As DataTable = New DataTable("XTIC " & xticNo.ToString)
                            xtic.Columns.Add(sXXm, GetType(Double))
                            xtic.Columns.Add(sTXs, GetType(Double))
                            xtics.Tables.Add(xtic)

                            xtic.ExtendedProperties.Add("Type", "Erosion")

                            ' TX Alt 1: 1st point in XTIC Curves define TX Grid lines
                            Dim xticPt As Srfr.Node = xticCurve(0)
                            xtic.ExtendedProperties.Add("Co", xticPt.GetConstituent("Co"))
                            'Dim txRow As DataRow = txGrid.NewRow
                            'txRow(0) = xticPt.TX
                            'txGrid.Rows.Add(txRow)

                            For Each xticPt In xticCurve

                                Dim TX As Double = xticPt.T
                                Dim XX As Double = xticPt.X

                                Dim Co As Double = xticPt.GetConstituent("Co") / GramsPerKilogram
                                Dim QX As Double = xticPt.Q
                                Dim YX As Double = xticPt.Y
                                Dim AZX As Double = xticPt.AZ / MillimetersPerMeter

                                Dim ZwpX As Double = xticPt.Zwp
                                If (ZwpX <= mSoilCropProperties.KostiakovC) Then
                                    ZwpX = 0.0
                                End If

                                ' Add XTIC point to XTIC DataTable
                                Dim xticRow As DataRow = xtic.NewRow
                                xticRow(0) = XX
                                xticRow(1) = TX
                                xtic.Rows.Add(xticRow)
                            Next

                            xticNo += 1
                        End If
                    End If
                Next

                ' XX Alt 2; Timestep distances define XX Grid Lines
                Dim tStep As Srfr.Timestep = SrfrIrrigation.LastTimestep
                For Each tNode As Srfr.Node In tStep.Nodes
                    Dim xxRow As DataRow = xxGrid.NewRow
                    xxRow(0) = tNode.X
                    xxGrid.Rows.Add(xxRow)
                Next

                ' TX Alt 2: Timestep times define TX Grid Lines
                For Each tStep In SrfrIrrigation.Timesteps
                    Dim txRow As DataRow = txGrid.NewRow
                    txRow(0) = tStep.T
                    txGrid.Rows.Add(txRow)
                Next

                xticsParam.Value = xtics
                xticsParam.Source = ValueSources.Calculated
                erosion.Xtics = xticsParam

                xticsGridParam.Value = xticsGrid
                xticsGridParam.Source = ValueSources.Calculated
                erosion.XticsGrid = xticsGridParam

            Else ' (0 = srfrXticsNet.Count) (i.e. no Characteristics generated)
                erosion.ClearXtics()
                erosion.ClearXticsGrid()
            End If

        Else ' (srfrXticsNet Is Nothing) i.e. no Characteristics generated
            erosion.ClearXtics()
            erosion.ClearXticsGrid()
        End If

    End Sub

#End Region

#End Region

#Region " Fertigation "

#Region " SRFR Fertigation "

    Public Sub RunSrfrFertigation()

        Dim fertigation As Fertigation = mUnit.FertigationRef
        Dim surfaceFlow As SurfaceFlow = mUnit.SurfaceFlowRef
        Dim subsurfaceFlow As SubsurfaceFlow = mUnit.SubsurfaceFlowRef
        Dim srfrCriteria As SrfrCriteria = mUnit.SrfrCriteriaRef
        Dim soilCropProperties As SoilCropProperties = mUnit.SoilCropPropertiesRef

        If ((SrfrIrrigation Is Nothing) Or (SrfrTransport Is Nothing)) Then
            Return
        End If
        '
        ' Get the Fertigation results
        '
        Dim srfrXticsNet As ReadOnlyCollection(Of Srfr.Characteristic) = SrfrTransport.CharacteristicNet

        If (srfrXticsNet IsNot Nothing) Then
            If (0 < srfrXticsNet.Count) Then ' Characteristics Net was generated during simulation run

                ' Variables for Xtics
                Dim xticsParam As DataSetParameter = fertigation.Xtics
                Dim xtics As DataSet = New DataSet("XTICS")

                ' Variables for XticsGrid
                Dim xticsGridParam As DataSetParameter = fertigation.XticsGrid
                Dim xticsGrid As DataSet = New DataSet("XTICS Grid")
                Dim xxGrid As DataTable = New DataTable("XX Grid")
                Dim txGrid As DataTable = New DataTable("TX Grid")

                xxGrid.Columns.Add(sXXm, GetType(Double))
                txGrid.Columns.Add(sTXs, GetType(Double))
                xticsGrid.Tables.Add(xxGrid)
                xticsGrid.Tables.Add(txGrid)

                ' Variables for Fertigation
                Dim infiltration As DataTable = subsurfaceFlow.LongitudinalInfiltration.Value

                ' Move SRFR Characteristics to WinSRFR
                Dim xticNo As Integer = 1
                Dim lastXX As Double = Double.MinValue
                For Each srfrXtic As Srfr.Characteristic In srfrXticsNet

                    Dim xticCurve As List(Of Srfr.Node) = srfrXtic.XticCurve
                    If (xticCurve IsNot Nothing) Then ' there is an XTIC Curve
                        If (1 < xticCurve.Count) Then ' and it has more than 1 point

                            ' Each XTIC Curve is stored in its own DataTable
                            Dim xtic As DataTable = New DataTable("XTIC " & xticNo.ToString)
                            xtic.Columns.Add(sXXm, GetType(Double))
                            xtic.Columns.Add(sTXs, GetType(Double))
                            xtics.Tables.Add(xtic)

                            xtic.ExtendedProperties.Add("Type", "Fertigation")

                            ' TX Alt 1: 1st point in XTIC Curves define TX Grid lines
                            Dim xticPt As Srfr.Node = xticCurve(0)
                            xtic.ExtendedProperties.Add("Co", xticPt.GetConstituent("Co"))
                            'Dim txRow As DataRow = txGrid.NewRow
                            'txRow(0) = xticPt.TX
                            'txGrid.Rows.Add(txRow)

                            For Each xticPt In xticCurve

                                Dim TX As Double = xticPt.T
                                Dim XX As Double = xticPt.X

                                Dim Co As Double = xticPt.GetConstituent("Co") / GramsPerKilogram
                                Dim QX As Double = xticPt.Q
                                Dim YX As Double = xticPt.Y
                                Dim AZX As Double = xticPt.AZ / MillimetersPerMeter

                                Dim ZwpX As Double = xticPt.Zwp
                                If (ZwpX <= mSoilCropProperties.KostiakovC) Then
                                    ZwpX = 0.0
                                End If

                                ' Add XTIC point to XTIC DataTable
                                Dim xticRow As DataRow = xtic.NewRow
                                xticRow(0) = XX
                                xticRow(1) = TX
                                xtic.Rows.Add(xticRow)
                            Next

                            xticNo += 1
                        End If
                    End If
                Next

                ' XX Alt 2; Timestep distances define XX Grid Lines
                Dim tStep As Srfr.Timestep = SrfrIrrigation.LastTimestep
                For Each tNode As Srfr.Node In tStep.Nodes
                    Dim xxRow As DataRow = xxGrid.NewRow
                    xxRow(0) = tNode.X
                    xxGrid.Rows.Add(xxRow)
                Next

                ' TX Alt 2: Timestep times define TX Grid Lines
                For Each tStep In SrfrIrrigation.Timesteps
                    Dim txRow As DataRow = txGrid.NewRow
                    txRow(0) = tStep.T
                    txGrid.Rows.Add(txRow)
                Next

                xticsParam.Value = xtics
                xticsParam.Source = ValueSources.Calculated
                fertigation.Xtics = xticsParam

                xticsGridParam.Value = xticsGrid
                xticsGridParam.Source = ValueSources.Calculated
                fertigation.XticsGrid = xticsGridParam

            Else ' (0 = srfrXticsNet.Count) (i.e. no Characteristics generated)
                fertigation.ClearXtics()
                fertigation.ClearXticsGrid()
            End If

        Else ' (srfrXticsNet Is Nothing) i.e. no Characteristics generated
            fertigation.ClearXtics()
            fertigation.ClearXticsGrid()
        End If

    End Sub

#End Region

#Region " HYDRUS Fertigation "

    Public Sub RunHydrusFertigation()
        Dim runOK As Boolean = False

        Try
            ' Get reference to HYDRUS 1D's API
            Dim hydrus1D As HydrusAPI.Hydrus1D = New HydrusAPI.Hydrus1D

            ' Get HYDRUS project(s) specified by the user
            Dim hydrusProject As String = mSoilCropProperties.HydrusProject.Value
            Dim hydrusProjects As DataTable = Nothing
            If (mSoilCropProperties.EnableTabulatedInfiltration.Value) Then
                hydrusProjects = mSoilCropProperties.HydrusProjectTable.Value
                If (hydrusProjects IsNot Nothing) Then
                    If (0 < hydrusProjects.Rows.Count) Then
                        hydrusProject = hydrusProjects.Rows(0).Item(Srfr.Hydrus.sHydrusProject)
                    End If
                End If
            End If

            ' Validate user has setup HYDRUS' input files correctly
            If Not (ReadValidateHydrus(hydrusProject, True)) Then
                mWorldWindow.WorldStatusMessage = mDictionary.tHydrusProjectValidationFailed.Translated
                Exit Try
            End If

            ' Get the sync distances specified by the user
            Dim distTable As DataTable = mSoilCropProperties.HydrusSyncDistances.Value

            Dim msg As String = ""
            Dim title As String = hydrusProject

            ' Run HYDRUS to get initial infiltration rate data
            Dim dist As Double = 0.0
            Dim tMin As Double = 0.0
            Dim tMax As Double = mInflowManagement.Cutoff

            ' Clear HYDRUS' infiltration rate table prior to first addition to set
            Dim preclear As Boolean = True

            ' Run HYDRUS for each sync distance
            For Each row As DataRow In distTable.Rows

                dist = row.Item(sDistanceX) ' Next sync distance

                ' Choose appropriate HYDRUS project if tabulated entries
                If (hydrusProjects IsNot Nothing) Then
                    For Each tableProject As DataRow In hydrusProjects.Rows
                        Dim tableDist As Double = tableProject.Item(sDistanceX)
                        If (tableDist <= dist) Then
                            hydrusProject = tableProject.Item(Srfr.Hydrus.sHydrusProject)
                        End If
                    Next
                End If

                ' Update HYDRUS' surface water hydrograph from SRFR hydrographs
                runOK = GenerateHydrusWaterHydrograph(hydrusProject, dist, tMin, tMax)
                If Not (runOK) Then ' Depth Hydrograph not generated for this Dist
                    Exit Try
                End If

                ' Run HYDRUS for this distance
                runOK = RunHydrus1D(hydrusProject, dist, tMin, tMax)
                If Not (runOK) Then
                    Exit Try
                End If

                ' Check HYDRUS error messages
                runOK = CheckHydrusErrorMessages(hydrusProject)
                If Not (runOK) Then
                    Exit Try
                End If

                ' Check HYDRUS mass balances
                runOK = CheckHydrusMassBalances(hydrusProject)
                If Not (runOK) Then
                    'Exit Try
                End If

                ' Append infiltration data from HYDRUS to WinSRFR's infiltration DataSet
                runOK = AppendHydrusSurfaceFluxes(hydrusProject, dist, preclear)
                If Not (runOK) Then
                    Exit Try
                End If

                ' Append concentration data from HYDRUS to WinSRFR's concentration DataSet
                runOK = AppendHydrusSubsurfaceProfiles(hydrusProject, dist, preclear)
                If Not (runOK) Then
                    Exit Try
                End If

                preclear = False    ' Only preclear before first append

            Next

        Catch ex As Exception

        End Try

    End Sub

#End Region

#End Region

#Region " Errors & Warnings "
    '
    ' Check for setup Errors and/or Warnings
    '
    Public Overrides Function CheckSetupErrors() As Boolean
        MyBase.CheckSetupErrors()

        If (mErosion.EnableErosion.Value) Then

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
                    AddSetupError(ErrorFlags.SpecGravityOutOfRange,
                             mDictionary.tSpecificGravityInvalid.Translated,
                             mDictionary.tSpecificGravityLessThan1OrGreaterThan3.Translated)
                End If

                retainedTotal += retained
            Next

            If (retainedNegative) Then
                AddSetupError(ErrorFlags.PercentRetainedTooSmall,
                         mDictionary.tPercentLessThanZero.Translated,
                         mDictionary.tIndividualRetainedValuesCannotBeNegative.Translated)
            End If

            If (sieveSizeNegative) Then
                AddSetupError(ErrorFlags.SieveSizeTooSmall,
                         mDictionary.tSieveSizeLessThanZero.Translated,
                         mDictionary.tIndividualSieveSizeValuesCannotBeNegative.Translated)
            End If

            If (1.0 <= retainedTotal) Then
                AddSetupError(ErrorFlags.PercentRetainedTooLarge,
                         mDictionary.tRetainedTooLarge.Translated,
                         mDictionary.tSumRetainedValuesMustBeLessThan100.Translated)
            End If

            ' Verify Soil Erodibility values
            If (mSoilCropProperties.ErodibilityA.Source = ValueSources.Errored) Then
                AddSetupError(ErrorFlags.SoilErodibilityErrors,
                         mDictionary.tSoilErodibilityInvalid.Translated,
                         mDictionary.tSoilErodibilityValuesAreInvalid.Translated)
            End If
        End If

        Dim infFunc As Integer = mSoilCropProperties.InfiltrationFunction.Value
        If (infFunc = InfiltrationFunctions.Hydrus1D) Then
            ' Verify HYDRUS project setup
            Dim hydrusProject As String
            If (mSoilCropProperties.EnableTabulatedInfiltration.Value) Then
                Dim hydrusProjects As DataTable = mSoilCropProperties.HydrusProjectTable.Value
                For Each winSrfrRow As DataRow In hydrusProjects.Rows
                    Dim dist As Double = winSrfrRow.Item(sDistanceX)

                    hydrusProject = winSrfrRow.Item(Srfr.Hydrus.sHydrusProject)
                    If (hydrusProject.Contains(DefaultHydrusRowFilename)) Then
                        AddSetupError(0, mDictionary.tHydrusProjectValidationFailed.Translated,
                                  mDictionary.tHydrusProjectNotSpecified.Translated)
                    End If
                Next
            Else
                hydrusProject = mSoilCropProperties.HydrusProject.Value
                If (hydrusProject = "") Or (hydrusProject.Contains(DefaultHydrusInfiltrationFilename)) Then
                    AddSetupError(0, mDictionary.tHydrusProjectValidationFailed.Translated,
                                  mDictionary.tHydrusProjectNotSpecified.Translated)
                End If
            End If

        End If

        Dim _errors As Boolean = Me.HasSetupErrors
        Return _errors
    End Function

    Public Overrides Sub CheckGeometryErrors()
        MyBase.CheckGeometryErrors()

        'If (mErosion.EnableErosion.Value) Then
        '    ' Field can't be level
        '    If (mSystemGeometry.AverageSlope <= MaximumLevelSlope) Then
        '        AddError(ErrorFlags.FieldLevel, _
        '                 mDictionary.tLevelFieldInvalid.Translated, _
        '                 mDictionary.tErosionAnalysisDoesNotSupportLevelFields.Translated)
        '    End If

        '    ' Downstream end can't be blocked
        '    If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
        '        AddError(ErrorFlags.BlockedEnd, _
        '                 mDictionary.tBlockedEndInvalid.Translated, _
        '                 mDictionary.tErosionAnalysisDoesNotSupportBlockedEnds.Translated)
        '    End If
        'End If
    End Sub

    Public Overrides Function CheckSetupWarnings() As Boolean
        MyBase.CheckSetupWarnings()

        Dim solmod As IntegerParameter = mSrfrCriteria.SolutionModel

        If (solmod.Value = SolutionModels.KinematicWave) Then
            If (mSystemGeometry.AverageSlope < Srfr.S0minKW) Then
                AddSetupWarning(WarningFlags.ExecutionWarning, _
                           mDictionary.tSlopeWarning.Translated, _
                           mDictionary.tKinematicWaveSlopeWarning.Translated)
            End If
        End If

        If (mFertigation.EnableFertigation.Value) Then
            Dim _tabulatedInjection As DataTable = mFertigation.TabulatedInjectionRate.Value
            Dim _maxInjectionTime As Double = DataStore.Utilities.DataColumnMax(_tabulatedInjection, nTimeX)
            Dim _maxInjectionRate As Double = DataStore.Utilities.DataColumnMax(_tabulatedInjection, nInjectionRateX)

            Dim Tco As Double = mInflowManagement.Cutoff

            If (Tco < _maxInjectionTime) Then
                AddSetupWarning(WarningFlags.ExecutionWarning, _
                mDictionary.tInjectionTable.Translated, _
                mDictionary.tInjectionTimesLimitedByTco.Translated)
            End If

        End If

        Dim _warnings As Boolean = Me.HasSetupWarnings
        Return _warnings
    End Function

#End Region

End Class
