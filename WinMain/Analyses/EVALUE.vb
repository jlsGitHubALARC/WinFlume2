
'*************************************************************************************************************
' Class:    EVALUE
'
' Desc: Perform EVALUE Analysis 
'*************************************************************************************************************
Imports DataStore

Public Class EVALUE
    Inherits EventAnalysis

#Region " Member Data "

    Public Enum VolBalCalcLimits
        LowLimit = -1
        NotLimited
        QinLimited
        QroLimited
        AdvLimited
        RecLimited
        FlowDepthLimited
        HighLimit
    End Enum

#End Region

#Region " Properties "
    '
    ' Infiltrated Depths DataTable
    '
    Protected mInfiltrationTable As DataTable
    Public Function InfiltrationTable() As DataTable
        Return mInfiltrationTable
    End Function

    Protected mEvalueRunning As Boolean = False
    Public Function EvalueRunning() As Boolean
        Return mEvalueRunning
    End Function
    '
    ' SRFR Input Adjustments
    '
    Protected mAdjustManningN As Boolean = False
    Public Property AdjustManningN() As Boolean
        Get
            Return mAdjustManningN
        End Get
        Set(ByVal value As Boolean)
            mAdjustManningN = value
        End Set
    End Property

    Protected mManningN As Double
    Public Property ManningN() As Double
        Get
            Return mManningN
        End Get
        Set(ByVal value As Double) ' Keep Manning n with valid range
            If (value < mWinSRFR.Nmin * 1.001) Then
                mManningN = mWinSRFR.Nmin
            ElseIf (mWinSRFR.Nmax * 0.999 < value) Then
                mManningN = mWinSRFR.Nmax
            Else
                mManningN = value
            End If
        End Set
    End Property

    Protected mAdjustSayreAlbertsonChi As Boolean = False
    Public Property AdjustSayreAlbertsonChi() As Boolean
        Get
            Return mAdjustSayreAlbertsonChi
        End Get
        Set(ByVal value As Boolean)
            mAdjustSayreAlbertsonChi = value
        End Set
    End Property

    Protected mSayreAlbertsonChi As Double
    Public Property SayreAlbertsonChi() As Double
        Get
            Return mSayreAlbertsonChi
        End Get
        Set(ByVal value As Double) ' Keep Chi within valid range
            If (value < mWinSRFR.ChiMin * 1.001) Then
                mSayreAlbertsonChi = mWinSRFR.ChiMin
            ElseIf (mWinSRFR.ChiMax * 0.999 < value) Then
                mSayreAlbertsonChi = mWinSRFR.ChiMax
            Else
                mSayreAlbertsonChi = value
            End If
        End Set
    End Property

#End Region

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
    End Sub

#End Region

#Region " Run Simulation "

    '*********************************************************************************************************
    ' Mechanism for Analyses to adjust SRFR criteria & field data prior to running a simulation
    '*********************************************************************************************************
    Public Overrides Sub AdjustSrfrInputs(ByVal unit As Unit)

        ' EventAnalysis baseclass adjusts for 'run w/slope'
        MyBase.AdjustSrfrInputs(unit)

        ' Get references to Unit objects
        Dim srfrCriteria As SrfrCriteria = unit.SrfrCriteriaRef
        Dim inflowManagement As InflowManagement = unit.InflowManagementRef

        Dim stations As DataTable = inflowManagement.StationZaElevationProfile()
        '
        ' Set the Hydrograph distances equal to the Station distances so the
        ' simulated flow depth hydrographs are at the Station locations.
        '
        ' NOTE - these distances are within WinSRFR only; nothing is passed to SRFR
        '
        Dim htParam As DataTableParameter = srfrCriteria.HydrographTable
        Dim htDists As DataTable = htParam.Value
        htDists.Rows.Clear()

        For Each station As DataRow In stations.Rows
            Dim stationLoc As Double = CDbl(station.Item(sDistanceX))
            Dim hydroLoc As DataRow = htDists.NewRow
            hydroLoc.Item(sDistanceX) = stationLoc
            htDists.Rows.Add(hydroLoc)
        Next station

        srfrCriteria.HydrographTable = htParam
        '
        ' Adjust SRFR Inputs, as required
        '
        If (mAdjustManningN) Then
            ' Set Manning n to match particular requirements
            Dim srfrRoughness As Srfr.Roughness = Me.SrfrAPI.Roughness
            If (srfrRoughness IsNot Nothing) Then
                If (srfrRoughness.GetType Is GetType(Srfr.ManningN)) Then
                    Dim srfrManningN As Srfr.ManningN = DirectCast(srfrRoughness, Srfr.ManningN)
                    srfrManningN.n = mManningN
                End If
            End If
        End If

        If (mAdjustSayreAlbertsonChi) Then
            ' Set Sayre-Albertson Chi to match particular requirements
            Dim srfrRoughness As Srfr.Roughness = Me.SrfrAPI.Roughness
            If (srfrRoughness IsNot Nothing) Then
                If (srfrRoughness.GetType Is GetType(Srfr.SayreAlbertsonChi)) Then
                    Dim srfrChi As Srfr.SayreAlbertsonChi = DirectCast(srfrRoughness, Srfr.SayreAlbertsonChi)
                    srfrChi.Chi = mSayreAlbertsonChi
                End If
            End If
        End If

    End Sub

    '*********************************************************************************************************
    ' Mechanism for Analyses to unload additional SRFR results after running a simulation
    '*********************************************************************************************************
    Public Overrides Function UnloadSrfrResults(ByVal srfrAPI As Srfr.SrfrAPI, ByVal unit As Unit, _
          ByVal compareRun As Boolean, ByVal skipProfiles As Boolean, ByVal skipHydroGraphs As Boolean) As Srfr.Irrigation
        ' Unload the SRFR results common to all/most Event Analyses
        Dim srfrIrrigation As Srfr.Irrigation = Nothing
        srfrIrrigation = MyBase.UnloadSrfrResults(srfrAPI, unit, compareRun, skipProfiles, skipHydroGraphs)
        '
        ' Unload the EVALUE specific, additional SRFR results
        '
        ' A simulation derived Volume Balance table that corresponds to the evaluation Volume Balance
        ' table is required for the results display.  This data is used by the Volume Balance results tab.
        '
        Dim evalueVolBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        If (evalueVolBalTable IsNot Nothing) Then
            Dim simVolBalParam As DataTableParameter = mEventCriteria.SimulationVolumeBalances
            Dim simVolBalTable As DataTable = simVolBalParam.Value
            mEventCriteria.ResetVolumeBalancesTable(simVolBalTable)

            For Each evalueRow As DataRow In evalueVolBalTable.Rows
                Dim time As Double = CDbl(evalueRow.Item(sTimeX))

                Dim Vin As Double = srfrIrrigation.VinUptoTime(time)
                Dim Vy As Double = srfrIrrigation.VyAtTime(time)
                Dim Vro As Double = srfrIrrigation.VroUptoTime(time)
                Dim Vz As Double = srfrIrrigation.VzAtTime(time)

                Dim simRow As DataRow = simVolBalTable.NewRow
                simRow.Item(sTimeX) = time
                simRow.Item(sVin) = Vin
                simRow.Item(sVy) = Vy
                simRow.Item(sVro) = Vro
                simRow.Item(sVz) = Vz

                simVolBalTable.Rows.Add(simRow)
            Next evalueRow

            simVolBalParam.Source = ValueSources.Calculated
            mEventCriteria.SimulationVolumeBalances = simVolBalParam
        End If
        '
        ' Save reference data from Standard Infiltration function simulation
        '
        Dim wpMethod As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value
        If Not (wpMethod = WettedPerimeterMethods.LocalWettedPerimeter) Then

            mSrfrResults.StdAdvanceProfile = srfrIrrigation.AdvanceCurve
            mSrfrResults.StdRecessionProfile = srfrIrrigation.RecessionCurve

            mSrfrResults.StdFlowDepthHydrographs = New DataSet("Flow Depth Hydrographs")
            Dim Xs As DataTable = mSrfrResults.StdAdvanceProfile
            Dim X1 As Double = -1
            Dim Xstr1 As String = ""
            For Each Xrow As DataRow In Xs.Rows
                Dim X2 As Double = Xrow.Item(nDistanceX)
                If (X1 < X2) Then ' Advancing; not FER
                    Dim Xstr2 As String = X2.ToString
                    If Not (Xstr1 = Xstr2) Then ' not a duplicate table name
                        Dim flowDepthHydrograph As DataTable = srfrIrrigation.Hydrographs("Y", X2)
                        flowDepthHydrograph.TableName = "Y Hydrograph @ " & Xstr2
                        mSrfrResults.StdFlowDepthHydrographs.Tables.Add(flowDepthHydrograph)
                    Else
                        Debug.Assert(False)
                    End If
                    X1 = X2
                    Xstr1 = Xstr2
                End If
            Next Xrow

        End If

        Return srfrIrrigation
    End Function

#End Region

#Region " Run Evaluation "

    Public Overrides Sub RunEvaluation()
        mEvalueRunning = True
        ' Get the selected Merriam-Keller Option
        Dim _infiltrationFunction As InfiltrationFunctions = _
            CType(mSoilCropProperties.InfiltrationFunction.Value, InfiltrationFunctions)

        ' Execute standard start analysis code
        Select Case (_infiltrationFunction)
            Case InfiltrationFunctions.GreenAmpt
                Me.StartRun(sGreenAmpt, False)
            Case InfiltrationFunctions.WarrickGreenAmpt
                Me.StartRun(sWarrickGreenAmpt, False)
            Case Else
                Me.StartRun("EVALUE", False)
        End Select

        ' Calculate & save the EVALUE results
        Dim VolBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        mEventCriteria.MeasuredVzInfiltration = Me.MeasuredInfiltrationVolumeTable(VolBalTable)

        Dim measVzParam As DataTableParameter = mEventCriteria.MeasVzInfiltration
        Dim measVzTable As DataTable = mEventCriteria.MeasuredVzInfiltration.Copy
        measVzTable.TableName = EventCriteria.sMeasVzInfiltration
        measVzParam.Value = measVzTable
        measVzParam.Source = ValueSources.Calculated
        mEventCriteria.MeasVzInfiltration = measVzParam

        ' Calculate & save the Solution
        Me.CalculateSolution()

        ' Re-calculate & save the Infiltration table AFTER CalculateSolution()
        If (mEventCriteria.AdvFunctionsSelected.Value) Then
            Me.CalcAdvInfiltrationTable()
        Else
            Me.CalcStdInfiltrationTable()
        End If

        ' Timestamp of SoilCropProperties.Infiltration is used by UI to synchronize to data changes
        Dim infiltration As DataTableParameter = mSoilCropProperties.Infiltration
        If (mInfiltrationTable IsNot Nothing) Then ' nothing to replace table with; just update timestamp
            infiltration.Value = mInfiltrationTable
        End If
        infiltration.Source = ValueSources.Calculated
        mSoilCropProperties.Infiltration = infiltration

        Me.EndRun()
        mEvalueRunning = False
    End Sub

#End Region

#Region " Solution "

    Public Overrides Sub CalculateSolution()
        MyBase.CalculateSolution()
        Me.AdjustManningN = False
        Me.AdjustSayreAlbertsonChi = False
        Me.RunSimulation(CellDensities.Medium)
    End Sub

#End Region

#Region " Methods "

    '*********************************************************************************************************
    ' Function MeasuredInfiltrationVolumeTable() - build measured Infiltration table
    '
    ' Input(s):     VolBalTable     - measured Volume Balances table
    '
    ' Measured Infiltration is one column within the measured Volume Balances table
    '*********************************************************************************************************
    Public Overrides Function MeasuredInfiltrationVolumeTable() As DataTable
        Dim volBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        MeasuredInfiltrationVolumeTable = Me.MeasuredInfiltrationVolumeTable(volBalTable)
    End Function

    Public Overloads Function MeasuredInfiltrationVolumeTable(ByVal volBalTable As DataTable) As DataTable

        ' Define infiltration table
        MeasuredInfiltrationVolumeTable = New DataTable(mDictionary.tMeasuredInfiltration.Translated)
        MeasuredInfiltrationVolumeTable.Columns.Add(sTimeX, GetType(Double))
        MeasuredInfiltrationVolumeTable.Columns.Add(sVz, GetType(Double))

        ' Load its data from the volume balance table (only need T vs. Vz)
        If (volBalTable IsNot Nothing) Then

            ' Extract measured infiltration (Vz) from Volume Balance table
            For Each vbRow As DataRow In volBalTable.Rows
                Dim infRow As DataRow = MeasuredInfiltrationVolumeTable.NewRow
                infRow.Item(sTimeX) = vbRow.Item(nTimeX)
                infRow.Item(sVz) = vbRow.Item(sVz)
                MeasuredInfiltrationVolumeTable.Rows.Add(infRow)
            Next vbRow
        End If

    End Function

#End Region

#Region " UI Utilities "

    Public Overrides Sub LoadWettedPerimeterControl(ByVal WettedPerimeterControl As DataStore.ctl_SelectParameter)

        ' Get Wetted Perimeter selection
        Dim WPparam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
        Dim WPsource As ValueSources = WPparam.Source
        Dim WPmethod As WettedPerimeterMethods = WPparam.Value

        ' Update selection list
        WettedPerimeterControl.Clear()

        Dim _sel As String = String.Empty
        Dim _val As Integer = 0
        Dim _selOk As Boolean = mSoilCropProperties.GetFirstWettedPerimeterMethodSelection(_sel)

        If (mEventCriteria.AdvFunctionsSelected.Value) Then

            While (_sel IsNot Nothing)
                If (_sel = sLocalWettedPerimeter) Then
                    If (_selOk) Then
                        WettedPerimeterControl.Add(_sel, _val, True)
                    Else ' Is selection the current WP selection? Yes, flag it
                        If (WPmethod = _val) Then
                            WettedPerimeterControl.Add(_sel, _val, False)
                        End If
                    End If
                End If

                _selOk = mSoilCropProperties.GetNextWettedPerimeterMethodSelection(_sel)
                _val += 1
            End While

        Else ' Std functions

            While (_sel IsNot Nothing)
                If (_sel = sLocalWettedPerimeter) Then
                    _selOk = False
                End If
                If (_selOk) Then
                    WettedPerimeterControl.Add(_sel, _val, True)
                Else ' Is selection the current WP selection? Yes, flag it
                    If (WPmethod = _val) Then
                        WettedPerimeterControl.Add(_sel, _val, False)
                    End If
                End If

                _selOk = mSoilCropProperties.GetNextWettedPerimeterMethodSelection(_sel)
                _val += 1
            End While

        End If

    End Sub

    '*********************************************************************************************************************************
    ' Sub LoadInfiltrationEquationControl() - load a ctl_SelectParameter control with its appropriate selection list
    '
    ' Input(s):     InfiltrationEquationControl - ctl_SelectParameter control to load
    '               WPmethod                    - current Wetted Perimeter method
    '               IEmethod                    - current Infiltration Equation method
    '               AddInvalid                  - should invalid selection be loaded or not
    '*********************************************************************************************************************************
    Public Overrides Sub LoadInfiltrationEquationControl(ByVal InfiltrationEquationControl As DataStore.ctl_SelectParameter, _
                                                   Optional ByVal WPmethod As WettedPerimeterMethods = WettedPerimeterMethods.LowLimit, _
                                                   Optional ByVal IEmethod As InfiltrationFunctions = InfiltrationFunctions.LowLimit, _
                                                   Optional ByVal AddInvalid As Boolean = True)

        ' Get Infiltration Function selections
        If (WPmethod = WettedPerimeterMethods.LowLimit) Then
            WPmethod = mSoilCropProperties.WettedPerimeterMethod.Value
        End If

        If (IEmethod = InfiltrationFunctions.LowLimit) Then
            IEmethod = mSoilCropProperties.InfiltrationFunction.Value
        End If

        ' Get selection flags for current World, Cross Section & User Level
        Dim _worldType As WorldTypes = CType(mUnit.WorldRef.WorldType.Value, WorldTypes)
        Dim _crossSection As CrossSections = mUnit.CrossSection
        Dim _userLevel As UserLevels = mWinSRFR.UserLevel

        Dim _selFlags As Globals.SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        ' Update selection list
        Dim _sel As String = String.Empty
        Dim _val As Integer = 0

        InfiltrationEquationControl.Clear()

        Dim _selOk As Boolean = mSoilCropProperties.GetFirstInfiltrationFunctionSelection(_sel)

        If (mEventCriteria.AdvFunctionsSelected.Value) Then ' Advanced infiltration functions

            While (_sel IsNot Nothing)
                Dim _added As Boolean = False

                If (_selOk) Then
                    Select Case (mUnit.CrossSection)
                        Case CrossSections.Furrow
                            If (_val < InfiltrationWettedPerimeterConstraints.Length) Then
                                ' Check criteria for adding furrow Infiltration Equations
                                Dim infRowFlags As SelFlags() = InfiltrationWettedPerimeterConstraints(_val)
                                Dim wpColFlags As Integer = infRowFlags(WPmethod)
                                If Not (0 = (wpColFlags And _selFlags)) Then
                                    InfiltrationEquationControl.Add(_sel, _val, True)
                                    _added = True
                                End If
                            End If

                        Case Else ' Basin or Border
                            If (_val < InfiltrationFunctionConstraints.Length) Then
                                ' Check criteria for adding basin/border Infiltration Equations
                                If (_sel = sGreenAmpt) Then ' Green-Ampt is only valid advanced selection
                                    Dim _infiltration As Boolean() = InfiltrationFunctionConstraints(_val)
                                    If (_infiltration(_worldType)) Then
                                        InfiltrationEquationControl.Add(_sel, _val, True)
                                        _added = True
                                    End If
                                End If
                            End If
                    End Select
                End If

                ' Current selection may not be valid
                If (AddInvalid And (Not (_added))) Then ' Check if current invalid selection should be added
                    If (IEmethod = _val) Then ' Yes, it should
                        InfiltrationEquationControl.Add(_sel, _val, False) ' Add, but mark as invalid
                    End If
                End If

                _selOk = mSoilCropProperties.GetNextInfiltrationFunctionSelection(_sel)
                _val += 1
            End While

        Else ' Standard infiltration functions

            While (_sel IsNot Nothing)
                Dim _added As Boolean = False

                If (_selOk) Then
                    Select Case (mUnit.CrossSection)
                        Case CrossSections.Furrow
                            If (_val < InfiltrationWettedPerimeterConstraints.Length) Then
                                ' Check criteria for adding furrow Infiltration Equations
                                Dim infRowFlags As SelFlags() = InfiltrationWettedPerimeterConstraints(_val)
                                Dim wpColFlags As Integer = infRowFlags(WPmethod)
                                If Not (0 = (wpColFlags And _selFlags)) Then
                                    InfiltrationEquationControl.Add(_sel, _val, True)
                                    _added = True
                                End If
                            End If

                        Case Else ' Basin or Border
                            If (_val < InfiltrationFunctionConstraints.Length) Then
                                ' Check criteria for adding basin/border Infiltration Equations
                                If Not (_sel = sGreenAmpt) Then ' Green-Ampt is not a valid standard selection
                                    Dim _infiltration As Boolean() = InfiltrationFunctionConstraints(_val)
                                    If (_infiltration(_worldType)) Then
                                        InfiltrationEquationControl.Add(_sel, _val, True)
                                        _added = True
                                    End If
                                End If
                            End If
                    End Select
                End If

                ' Current selection may not be valid
                If (AddInvalid And (Not (_added))) Then ' Check if current invalid selection should be added
                    If (IEmethod = _val) Then ' Yes, it should
                        InfiltrationEquationControl.Add(_sel, _val, False) ' Add, but mark as invalid
                    End If
                End If

                _selOk = mSoilCropProperties.GetNextInfiltrationFunctionSelection(_sel)
                _val += 1
            End While

        End If

    End Sub

#End Region

#Region " Predicted Infiltration "

    '*********************************************************************************************************
    ' Sub PredictedIntegrationMethod()  - Determine if power law integral or trapezoid integration is used
    '*********************************************************************************************************
    Public Sub PredictedIntegrationMethod(ByRef UsePowerLaw As Boolean, ByRef UseStandard As Boolean, ByRef UseAdvanced As Boolean, _
                                          Optional ByVal SrfrInfiltration As Srfr.Infiltration = Nothing)
        UsePowerLaw = False
        UseStandard = False
        UseAdvanced = False

        ' If SRFR Infiltration object is specified; check its values
        If (SrfrInfiltration IsNot Nothing) Then

            ' Local Wetted Perimeter functions use trapezoid integration w/ flow depth hydrographs
            If (SrfrInfiltration.WettedPerimeterMethod = Srfr.Infiltration.WettedPerimeterMethods.Local) Then
                UseAdvanced = True
                Return
            End If

            ' Green-Ampt, Warrick Green-Ampt use trapezoid integration w/ flow depth hydrographs
            If ((SrfrInfiltration.GetType Is GetType(Srfr.GreenAmpt)) _
             Or (SrfrInfiltration.GetType Is GetType(Srfr.WarrickGreenAmpt))) Then
                UseAdvanced = True
                Return
            End If

            ' Branch Function (non-Local WP) use trapezoid integration wo/ flow depth hydrographs
            If ((SrfrInfiltration.GetType Is GetType(Srfr.BranchFunction)) _
             Or (SrfrInfiltration.GetType Is GetType(Srfr.BranchFunction2))) Then
                UseStandard = True
                Return
            End If

        Else ' Check values in Soil Crop Properties

            ' Local Wetted Perimeter functions use trapezoid integration w/ flow depth hydrographs
            Dim wpMethod As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value
            If (wpMethod = WettedPerimeterMethods.LocalWettedPerimeter) Then
                UseAdvanced = True
                Return
            End If

            ' Green-Ampt, Warrick Green-Ampt use trapezoid integration w/ flow depth hydrographs
            Dim infFunc As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value
            If ((infFunc = InfiltrationFunctions.GreenAmpt) _
             Or (infFunc = InfiltrationFunctions.WarrickGreenAmpt)) Then
                UseAdvanced = True
                Return
            End If

            ' Branch Function (non-Local WP) use trapezoid integration wo/ flow depth hydrographs
            If (infFunc = InfiltrationFunctions.BranchFunction) Then
                UseStandard = True
                Return
            End If

        End If
        '
        ' Text from Eduardo Bautista email 7-13-2018:
        '
        ' The power law integral assumes a constant inflow.  It cannot be applied after cutoff time. 
        ' In principle, it should not be used either when the inflow is varying but it works with an
        ' average inflow, as long as the flow is relatively uniform.  
        '
        ' The numerical integral is reasonably accurate, but can be expected to lose accuracy if the
        ' stations are relatively unequal and large.
        '
        ' I think we can work with the following rules:
        '
        ' If cutoff time >= final advance time then
        '   If the number of stations is 9 or less (including station 0) then
        '       use power law integration
        '   else
        '       use numerical
        '
        ' If cutoff time < final advance time
        '   If the number of stations is 5 or more, then
        '       use numerical integration
        '   If the number of stations is fewer than 5, then
        '       limit the volume balance calculation times to no more than the cutoff time
        '

        ' Verify a constant inflow.
        Dim inflowMethod As Integer = mInflowManagement.InflowMethod.Value
        Select Case inflowMethod
            Case InflowMethods.Cablegation, InflowMethods.Surge, InflowMethods.TabulatedInflow
                UseStandard = True
                Return
        End Select

        ' Verify calculation times do not extend past cutoff
        Dim Tco As Double = mInflowManagement.Tco

        Dim volBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        If (DataTableHasData(volBalTable, 1)) Then
            Dim numVolBalances As Integer = volBalTable.Rows.Count
            Dim vbRow As DataRow = volBalTable.Rows(numVolBalances - 1)

            Dim T As Double = vbRow.Item(nTimeX)
            If (Tco < T) Then
                UseStandard = True
                Return
            End If
        End If

        ' Check Tco vx. max adv time options
        Dim numStations As Integer = 0
        Dim stationTable As DataTable = mInflowManagement.MeasurementStations.Value
        If (DataTableHasData(stationTable, 1)) Then
            numStations = stationTable.Rows.Count
        End If

        Dim maxAdvTime As Double = mInflowManagement.MaxAdvanceTime
        If (Tco >= maxAdvTime) Then ' cutoff time >= final advance time
            If (9 < numStations) Then
                UseStandard = True
                Return
            End If
        Else ' cutoff time < final advance time
            If (5 <= numStations) Then
                UseStandard = True
                Return
            End If
        End If

        ' Use the power law integration
        UsePowerLaw = True

    End Sub

    '*********************************************************************************************************
    ' Function PredictedInfiltrationVolumeTable() - calculate predicted Infiltration volume table
    '
    ' Input(s): SrfrInfiltration    - optional reference to Srfr.Infiltration object
    '
    ' Note - if SrfrInfiltration is not specified (i.e. = Nothing), the current infiltration parameters in
    '        the SoilCropProperties object are used.
    '
    '        When this method is called from the Evaluation World's infiltration tab to calculate the data
    '        to graph, SrfrInfiltration = Nothing. So, the infiltration parameters in SoilCropProperties,
    '        which represent the user's current infiltration parameters, are used.
    '
    '        When this method is called from the Infiltration Function Editor, SrfrInfiltration will hold a
    '        reference to a SRFR Infiltration object for the new infiltration method/parameters selected in
    '        that dialog box.
    '
    ' Refer to:  "Data Requirements and Rules for Volume Balance Calculations"
    '             III. EVALUE f.
    '*********************************************************************************************************
    Public Overrides Function PredictedInfiltrationVolumeTable( _
               Optional ByVal SrfrInfiltration As Srfr.Infiltration = Nothing) As DataTable
        '
        ' Determine if power law integral or trapezoid integration should be used
        '
        Dim usePowerLaw, useStandard, useAdvanced As Boolean

        Me.PredictedIntegrationMethod(usePowerLaw, useStandard, useAdvanced, SrfrInfiltration)
        '
        ' Compute volume table using power law integral or trapezoid integration as determined above
        '
        If (usePowerLaw) Then
            PredictedInfiltrationVolumeTable = PredictedKostiakovTablePwrAdv(SrfrInfiltration)
        ElseIf (useStandard) Then
            PredictedInfiltrationVolumeTable = PredictedInfiltrationVolumeTableStd(SrfrInfiltration)
        ElseIf (useAdvanced) Then
            PredictedInfiltrationVolumeTable = PredictedInfiltrationVolumeTableAdv(SrfrInfiltration)
        Else
            PredictedInfiltrationVolumeTable = Nothing
        End If

    End Function

    Public Function PredictedInfiltrationVolumeTableAdv( _
           Optional ByVal SrfrInfiltration As Srfr.Infiltration = Nothing) As DataTable

        ' Get results from last Standard Infiltration Function simulation
        Dim stdAdvance As DataTable = mSrfrResults.StdAdvanceProfile
        Dim stdRecession As DataTable = mSrfrResults.StdRecessionProfile
        Dim stdFlowDepths As DataSet = mSrfrResults.StdFlowDepthHydrographs
        If ((stdAdvance Is Nothing) Or (stdRecession Is Nothing) Or (stdFlowDepths Is Nothing)) Then
            Return Nothing
        End If

        ' Get Border Width or Furrow Spacing
        Dim W As Double = mSystemGeometry.WidthForCrossSection
        ' Calc SigmaZ for computing infiltrated volumes
        Dim a As Double = mSoilCropProperties.KostiakovA
        Dim SigmaZ As Double = 1.0 / (1.0 + a)

        ' Define predicted infiltration table
        PredictedInfiltrationVolumeTableAdv = New DataTable(mDictionary.tPredictedInfiltration.Translated)
        PredictedInfiltrationVolumeTableAdv.Columns.Add(sTimeX, GetType(Double))
        PredictedInfiltrationVolumeTableAdv.Columns.Add(sVz, GetType(Double))

        ' Calculate predicted infiltration volumes using times from the volume balance table
        Dim volBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        If (DataTableHasData(volBalTable)) Then
            Dim rowCount As Integer = volBalTable.Rows.Count
            If (1 < rowCount) Then

                ' Set alternate source, if any, for infiltration parameters
                mSoilCropProperties.SrfrInfiltration = SrfrInfiltration

                For Each vbRow As DataRow In volBalTable.Rows

                    ' Get next time to calculate Vz
                    Dim T As Double = vbRow.Item(nTimeX)

                    ' Opportunity times (Tau) limited by time T
                    Dim tauTable As DataTable = mSrfrResults.OpportunityTimeCurve(stdAdvance, stdRecession, T)
                    ' Infiltrated Depths for opportunity times; Reference SrfrAPI, if any, supplies flow depths
                    Dim infTable As DataTable = mSoilCropProperties.InfiltratedDepthProfile(tauTable, stdFlowDepths)
                    ' Infiltrated Volume calculated from infiltrated depths table
                    Dim Vz As Double = mSoilCropProperties.InfiltratedVolume(infTable, SigmaZ)
                    Vz *= W

                    Dim infRow As DataRow = PredictedInfiltrationVolumeTableAdv.NewRow
                    infRow.Item(sTimeX) = T
                    infRow.Item(sVz) = Vz
                    PredictedInfiltrationVolumeTableAdv.Rows.Add(infRow)
                Next vbRow

                ' Clear alternate source of infiltration parameters
                mSoilCropProperties.SrfrInfiltration = Nothing

            End If
        End If

    End Function

    Public Function PredictedInfiltrationVolumeTableStd( _
           Optional ByVal SrfrInfiltration As Srfr.Infiltration = Nothing) As DataTable

        ' Define predicted infiltration table
        PredictedInfiltrationVolumeTableStd = New DataTable(mDictionary.tPredictedInfiltration.Translated)
        PredictedInfiltrationVolumeTableStd.Columns.Add(sTimeX, GetType(Double))
        PredictedInfiltrationVolumeTableStd.Columns.Add(sVz, GetType(Double))

        ' Get Border Width or Furrow Spacing
        Dim W As Double = mSystemGeometry.WidthForCrossSection
        ' Calc SigmaZ for computing infiltrated volumes
        Dim a As Double = mSoilCropProperties.KostiakovA
        Dim SigmaZ As Double = 1.0 / (1.0 + a)

        ' Calculate predicted infiltration volumes using times from the volume balance table
        Dim volBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        If (DataTableHasData(volBalTable)) Then
            Dim rowCount As Integer = volBalTable.Rows.Count
            If (1 < rowCount) Then

                ' Set alternate source, if any, for infiltration parameters
                mSoilCropProperties.SrfrInfiltration = SrfrInfiltration

                For Each vbRow As DataRow In volBalTable.Rows

                    ' Get next time to calculate Vz
                    Dim T As Double = vbRow.Item(nTimeX)

                    ' Opportunity times (Tau) limited by time T
                    Dim tauTable As DataTable = mInflowManagement.CalcOpportunityTimes(T)
                    ' Infiltrated Depths for opportunity times; Reference SrfrAPI, if any, supplies flow depths
                    Dim infTable As DataTable = mSoilCropProperties.InfiltratedDepthProfile(tauTable)
                    ' Infiltrated Volume calculated from infiltrated depths table
                    Dim Vz As Double = mSoilCropProperties.InfiltratedVolume(infTable, SigmaZ)
                    Vz *= W

                    Dim infRow As DataRow = PredictedInfiltrationVolumeTableStd.NewRow
                    infRow.Item(sTimeX) = T
                    infRow.Item(sVz) = Vz
                    PredictedInfiltrationVolumeTableStd.Rows.Add(infRow)
                Next vbRow

                ' Clear alternate source of infiltration parameters
                mSoilCropProperties.SrfrInfiltration = Nothing

            End If
        End If

    End Function

    Protected Function PredictedKostiakovTablePwrAdv( _
              Optional ByVal SrfrInfiltration As Srfr.Infiltration = Nothing) As DataTable

        ' Define predicted infiltration table
        PredictedKostiakovTablePwrAdv = New DataTable(mDictionary.tPredictedInfiltration.Translated)
        PredictedKostiakovTablePwrAdv.Columns.Add(sTimeX, GetType(Double))
        PredictedKostiakovTablePwrAdv.Columns.Add(sVz, GetType(Double))

        Dim WP As Double = Me.WettedPerimeter()                     ' Border Width | Furrow Wetted Perimeter
        Dim W As Double = mSystemGeometry.WidthForCrossSection()    ' Border Width | Furrow Spacing

        Dim K As Double = mSoilCropProperties.KostiakovK * WP       ' Note - K, B, C are capitalized versions
        Dim a As Double = mSoilCropProperties.KostiakovA
        Dim B As Double = mSoilCropProperties.KostiakovB * WP
        Dim C As Double = mSoilCropProperties.KostiakovC * W

        If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.NRCSIntakeFamily) Then
            C = mSoilCropProperties.KostiakovC * WP
        End If

        Dim Q0 As Double = mInflowManagement.AverageInflowRateForCrossSection
        Dim n As Double = mSoilCropProperties.ManningN.Value

        Dim S0 As Double = mSystemGeometry.AverageSlope
        Dim L As Double = mSystemGeometry.Length.Value
        If (S0 <= 0.0) Then ' Eq. 5-25 in SCS (1984) Section 15, Ch5 Furrow Irrigation
            S0 = Srfr.SrfrAPI.NrcsHydraulicGradient(Q0, L)
        End If

        If (SrfrInfiltration IsNot Nothing) Then

            Dim wpMethod As Srfr.Infiltration.WettedPerimeterMethods = SrfrInfiltration.WettedPerimeterMethod
            Select Case (wpMethod)
                Case Srfr.Infiltration.WettedPerimeterMethods.BorderWidth
                    ' WP already set
                Case Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing
                    ' WP already set
                Case Srfr.Infiltration.WettedPerimeterMethods.NRCS
                    WP = Srfr.SrfrAPI.NrcsUpstreamWettedPerimeter(Q0, S0, n)
                Case Srfr.Infiltration.WettedPerimeterMethods.RepresentativeUpstream
                    WP = Me.UpstreamWettedPerimeter(Q0, L, W, S0)
                Case Else
                    Debug.Assert(False)
            End Select

            If (SrfrInfiltration.GetType Is GetType(Srfr.NrcsIntakeFamily)) Then
                Dim nrcs As Srfr.NrcsIntakeFamily = DirectCast(SrfrInfiltration, Srfr.NrcsIntakeFamily)
                K = nrcs.k * WP
                a = nrcs.a
                B = nrcs.b * WP
                C = nrcs.c * WP
            ElseIf ((SrfrInfiltration.GetType Is GetType(Srfr.ModifiedKostiakov)) _
                 Or (SrfrInfiltration.GetType.IsSubclassOf(GetType(Srfr.ModifiedKostiakov)))) Then
                Dim mk As Srfr.ModifiedKostiakov = DirectCast(SrfrInfiltration, Srfr.ModifiedKostiakov)
                K = mk.k * WP
                a = mk.a
                B = mk.b * WP
                C = mk.c * W
            Else
                Debug.Assert(False)
            End If
        End If

        Dim TL As Double = mInflowManagement.TL

        Dim maxAdvTime As Double = mInflowManagement.MaxAdvanceTime
        Dim maxRecTime As Double = mInflowManagement.MaxRecessionTime

        Dim rpa As Double = mInflowManagement.AdvanceR.Value
        Dim Vz As Double = 0.0

        Dim sigmaZsAvailable As Boolean = False
        Dim sigmaZsTable As DataTable = mEventCriteria.SimSigmaZtable.Value
        If (sigmaZsTable IsNot Nothing) Then
            If (0 < sigmaZsTable.Rows.Count) Then
                sigmaZsAvailable = True
            End If
        End If

        Dim Sz As Double = -1.0

        ' Load predicted infiltration table using times from the volume balance table
        Dim volBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        If (DataTableHasData(volBalTable, 1)) Then

            For Each vbRow As DataRow In volBalTable.Rows

                Dim T As Double = vbRow.Item(nTimeX)
                Dim X As Double = mInflowManagement.Xadv(T)

                If (Double.IsNaN(TL)) Then ' Advance did not reach the end of the field
                    If (T <= maxAdvTime) Then ' Advance is ongoing
                        If (sigmaZsAvailable) Then ' Sigma Z values from simulation are available
                            Sz = DataColumnValue(sigmaZsTable, nTimeX, T, 1)
                            Vz = (K * T ^ a + B * T + C) * Sz * X
                        Else ' No simulation Sigma Z values available
                            Vz = ExtKostPwrAdvIntegral(T, X, maxAdvTime, rpa, K, a, B, C)
                        End If
                    Else
                        If (sigmaZsAvailable) Then ' Sigma Z values from simulation are available
                            Sz = DataColumnValue(sigmaZsTable, nTimeX, T, 1)
                            Vz = (K * T ^ a + B * T + C) * Sz * L
                        Else ' No simulation Sigma Z values available
                            Vz = ExtKostPwrAdvIntegral(T, L, maxAdvTime, rpa, K, a, B, C)
                        End If
                    End If

                Else ' Advance reached the end of the field
                    Debug.Assert(T <= maxRecTime)

                    If (TL < T) Then ' T is Post-Advance
                        If (sigmaZsAvailable) Then ' Sigma Z values from simulation are available
                            Sz = DataColumnValue(sigmaZsTable, nTimeX, T, 1)
                            Vz = (K * T ^ a + B * T + C) * Sz * L
                        Else ' No simulation Sigma Z values available
                            Vz = ExtKostPwrAdvIntegral(T, L, TL, rpa, K, a, B, C)
                        End If
                    Else ' Advance is ongoing
                        If (sigmaZsAvailable) Then ' Sigma Z values from simulation are available
                            Sz = DataColumnValue(sigmaZsTable, nTimeX, T, 1)
                            Vz = (K * T ^ a + B * T + C) * Sz * X
                        Else ' No simulation Sigma Z values available
                            Vz = ExtKostPwrAdvIntegral(T, X, TL, rpa, K, a, B, C)
                        End If
                    End If
                End If

                Dim infRow As DataRow = PredictedKostiakovTablePwrAdv.NewRow
                infRow.Item(sTimeX) = T
                infRow.Item(sVz) = Vz
                PredictedKostiakovTablePwrAdv.Rows.Add(infRow)
            Next vbRow

        End If

    End Function

    Public Function PredictedSigmaZTablePwrAdv( _
           Optional ByVal SrfrInfiltration As Srfr.Infiltration = Nothing) As DataTable

        ' Define predicted infiltration table
        PredictedSigmaZTablePwrAdv = New DataTable(mDictionary.tPredictedInfiltration.Translated)
        PredictedSigmaZTablePwrAdv.Columns.Add(sTimeX, GetType(Double))
        PredictedSigmaZTablePwrAdv.Columns.Add(sSigmaZ, GetType(Double))

        Dim WP As Double = Me.WettedPerimeter()                     ' Border Width | Furrow Wetted Perimeter
        Dim W As Double = mSystemGeometry.WidthForCrossSection()    ' Border Width | Furrow Spacing

        Dim K As Double = mSoilCropProperties.KostiakovK * WP       ' Note - K, B, C are capitalized versions
        Dim a As Double = mSoilCropProperties.KostiakovA
        Dim B As Double = mSoilCropProperties.KostiakovB * WP
        Dim C As Double = mSoilCropProperties.KostiakovC * W

        If (mSoilCropProperties.InfiltrationFunction.Value = InfiltrationFunctions.NRCSIntakeFamily) Then
            C = mSoilCropProperties.KostiakovC * WP
        End If

        Dim Q0 As Double = mInflowManagement.AverageInflowRateForCrossSection
        Dim n As Double = mSoilCropProperties.ManningN.Value

        Dim S0 As Double = mSystemGeometry.AverageSlope
        Dim L As Double = mSystemGeometry.Length.Value
        If (S0 <= 0.0) Then ' Eq. 5-25 in SCS (1984) Section 15, Ch5 Furrow Irrigation
            S0 = Srfr.SrfrAPI.NrcsHydraulicGradient(Q0, L)
        End If

        If (SrfrInfiltration IsNot Nothing) Then

            Dim wpMethod As Srfr.Infiltration.WettedPerimeterMethods = SrfrInfiltration.WettedPerimeterMethod
            Select Case (wpMethod)
                Case Srfr.Infiltration.WettedPerimeterMethods.BorderWidth
                    ' WP already set
                Case Srfr.Infiltration.WettedPerimeterMethods.FurrowSpacing
                    ' WP already set
                Case Srfr.Infiltration.WettedPerimeterMethods.NRCS
                    WP = Srfr.SrfrAPI.NrcsUpstreamWettedPerimeter(Q0, S0, n)
                Case Srfr.Infiltration.WettedPerimeterMethods.RepresentativeUpstream
                    WP = Me.UpstreamWettedPerimeter(Q0, L, W, S0)
                Case Else
                    Debug.Assert(False)
            End Select

            If (SrfrInfiltration.GetType Is GetType(Srfr.NrcsIntakeFamily)) Then
                Dim nrcs As Srfr.NrcsIntakeFamily = DirectCast(SrfrInfiltration, Srfr.NrcsIntakeFamily)
                K = nrcs.k * WP
                a = nrcs.a
                B = nrcs.b * WP
                C = nrcs.c * WP
            ElseIf ((SrfrInfiltration.GetType Is GetType(Srfr.ModifiedKostiakov)) _
                 Or (SrfrInfiltration.GetType.IsSubclassOf(GetType(Srfr.ModifiedKostiakov)))) Then
                Dim mk As Srfr.ModifiedKostiakov = DirectCast(SrfrInfiltration, Srfr.ModifiedKostiakov)
                K = mk.k * WP
                a = mk.a
                B = mk.b * WP
                C = mk.c * W
            Else
                Debug.Assert(False)
            End If
        End If

        Dim TL As Double = mInflowManagement.TL

        Dim maxAdvTime As Double = mInflowManagement.MaxAdvanceTime
        Dim maxRecTime As Double = mInflowManagement.MaxRecessionTime

        Dim rpa As Double = mInflowManagement.AdvanceR.Value
        Dim Vz As Double = 0.0

        Dim SzSim As Double = -1.0
        Dim SzPai As Double = -1.0

        ' Load predicted infiltration table using times from the volume balance table
        Dim volBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        If (DataTableHasData(volBalTable, 1)) Then

            For Each vbRow As DataRow In volBalTable.Rows

                Dim T As Double = vbRow.Item(nTimeX)
                Dim X As Double = mInflowManagement.Xadv(T)

                If (Double.IsNaN(TL)) Then ' Advance did not reach the end of the field
                    If (T <= maxAdvTime) Then ' Advance is ongoing
                        Vz = ExtKostPwrAdvIntegral(T, X, maxAdvTime, rpa, K, a, B, C)
                        SzPai = Vz / ((K * T ^ a + B * T + C) * X)
                    End If

                Else ' Advance reached the end of the field
                    Debug.Assert(T <= maxRecTime)

                    If (TL < T) Then ' T is Post-Advance
                        Vz = ExtKostPwrAdvIntegral(T, L, TL, rpa, K, a, B, C)
                        SzPai = Vz / ((K * T ^ a + B * T + C) * L)
                    Else ' Advance is ongoing
                        Vz = ExtKostPwrAdvIntegral(T, X, TL, rpa, K, a, B, C)
                        SzPai = Vz / ((K * T ^ a + B * T + C) * X)
                    End If
                End If

                Dim infRow As DataRow = PredictedSigmaZTablePwrAdv.NewRow
                infRow.Item(sTimeX) = T
                infRow.Item(sSigmaZ) = SzPai
                PredictedSigmaZTablePwrAdv.Rows.Add(infRow)
            Next vbRow

        End If

    End Function

    Public Function SimulationSigmaZtable() As DataTable

        SimulationSigmaZtable = New DataTable("Sim Sigma Z")
        SimulationSigmaZtable.Columns.Add(sTimeX, GetType(Double))
        SimulationSigmaZtable.Columns.Add(sSigmaZ, GetType(Double))

        ' Update Sigma Z values using values from Simulation
        Dim srfrIrrigation As Srfr.Irrigation = mWorldWindow.SrfrAPI.Irrigation
        If (srfrIrrigation IsNot Nothing) Then

            Dim SzVsTime As DataTable = srfrIrrigation.AZavgProfile("Time")

            Dim SurfaceVolumes As DataTable = mEventCriteria.EstimatedSurfaceVolumes.Value
            If (SurfaceVolumes IsNot Nothing) Then

                ' Update Surface Volumes table with Sigma Z values from Simulation
                For Each row As DataRow In SurfaceVolumes.Rows
                    Dim T As Double = row.Item(nTimeX)
                    Dim Sz As Double = DataColumnValue(SzVsTime, 0, T, 2) ' get Sz by time

                    Dim sigmaZrow As DataRow = SimulationSigmaZtable.NewRow
                    sigmaZrow.Item(nTimeX) = T
                    sigmaZrow.Item(sSigmaZ) = Sz
                    SimulationSigmaZtable.Rows.Add(sigmaZrow)
                Next row

            End If
        End If

    End Function

#End Region

#Region " Volume Balance Times "

    '*********************************************************************************************************
    ' Function SuggestVolumeBalanceTimes() - Suggest times for volume balance calculations

    ' Function SuggestOpenEndVolumeBalanceTimes()    - Suggest times for Open-End systems
    ' Function SuggestBlockedEndVolumeBalanceTimes() - Suggest times for Blocked-End systems
    '
    ' Returns:      Double()        - array of times
    '*********************************************************************************************************
    Public Function SuggestVolumeBalanceTimes() As Double()
        Dim times As Double() = {}

        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            times = SuggestOpenEndVolumeBalanceTimes()
        Else ' DownstreamConditions.BlockedEnd
            times = SuggestBlockedEndVolumeBalanceTimes()
        End If

        Return times
    End Function

    Public Function SuggestOpenEndVolumeBalanceTimes() As Double()
        Dim times As Double() = {}

        '*****************************************************************************************************
        ' Get user input field measurements
        '*****************************************************************************************************
        Dim L As Double = mSystemGeometry.Length.Value                          ' Field length

        Dim qinTimes As Double() = mInflowManagement.InflowHydrographTimes()    ' Times from Inflow Hydrograph
        Dim qroTimes As Double() = mInflowManagement.RunoffHydrographTimes()    '   "     "  Runoff      "
        Dim advTimes As Double() = mInflowManagement.AdvanceProfileTimes()      '   "     "  Advance Profile
        Dim recTimes As Double() = mInflowManagement.RecessionProfileTimes()    '   "     "  Recession  "

        Dim maxAdvDist As Double = mInflowManagement.MaxAdvanceDistance         ' Max advance distance
        Dim maxAdvTime As Double = mInflowManagement.MaxAdvanceTime             ' Max    "    time
        Dim maxRecDist As Double = mInflowManagement.MaxRecessionDistance       ' Max recession distance
        Dim maxRecTime As Double = mInflowManagement.MaxRecessionTime           ' Max     "     time

        '*****************************************************************************************************
        ' Combine times that are valid for Volume Balance calculations
        '*****************************************************************************************************
        '
        ' Start with Advance Phase times; only Advance times where 0 < Qin are valid for suggested times
        '
        While (0 < advTimes.Length)
            Dim advTime As Double = advTimes(advTimes.Length - 1) ' Last advance time
            Dim Qin As Double = mInflowManagement.InflowRateAtTimeForField(advTime) ' Qin at that time
            If (Qin <= 0) Then ' no inflow; remove Advance Time from list
                ReDim Preserve advTimes(advTimes.Length - 2)
            Else ' inflow; rest should be valid
                Exit While
            End If
        End While

        If (0 < advTimes.Length) Then
            If (8 < advTimes.Length) Then ' limit to at most 8 times
                Dim lastTime As Double = advTimes(advTimes.Length - 1) ' Last advance time

                ' Select advance times as evenly spaced as available
                For tdx As Integer = 1 To 7
                    Dim nextTime As Double = lastTime * tdx / 8             ' Desired advance time
                    Dim advTime As Double = FloorValue(advTimes, nextTime)  ' Floor time before desired

                    If Not (ArrayContainsValue(times, advTime)) Then ' not already added; add it
                        ReDim Preserve times(times.Length)
                        times(times.Length - 1) = advTime
                    End If
                Next tdx

                ' Always end with last advance time
                ReDim Preserve times(times.Length)
                times(times.Length - 1) = lastTime

            Else ' <=8; keep them all
                ReDim times(advTimes.Length - 1)
                Array.Copy(advTimes, 0, times, 0, advTimes.Length)
            End If
        Else ' there are no valid Advance times; can't continue
            Return times
        End If
        '
        ' If Advance reached end-of-field; more times can be added
        '
        If (L - OneDecimeter <= maxAdvDist) Then ' Advance reached end-of-field
            If (mInflowManagement.RunoffDataAvailable And mInflowManagement.RunoffUsed.Value) Then
                '
                ' Add Storage / Drainage Phase times
                '
                Dim ratios As Double() = {0.1, 0.25, 0.5, 1.0}

                Dim TL As Double = times(times.Length - 1)      ' Final time suggested for Advance Phase
                Dim Tco As Double = mInflowManagement.Tco
                Dim Tfvb As Double = Tco                        ' Final time for Storage / Drainage Phase

                If (0 < qroTimes.Length) Then ' Runoff measurements have been entered

                    If Not (mInflowManagement.RunoffComplete) Then ' Runoff Partial Hydrograph

                        Dim firstQroTime As Double = qroTimes(0)
                        If Not (ThisClose(maxAdvTime, firstQroTime, OneMinute)) Then ' start of Runoff missing
                            qroTimes = New Double() {} ' Runoff can't be used for VB calculations
                        End If
                    End If

                    If (0 < qroTimes.Length) Then ' Runoff still available

                        Dim Tro As Double = qroTimes(qroTimes.Length - 1) ' Final runoff (Qro) time
                        If (Tro < Tco) Then ' Final runoff measurement is prior to Tco
                            Tfvb = Tro ' Runoff limits Storage / Drainage Phase
                        ElseIf (recTimes.Length <= 0) Then ' No recession available
                            Tfvb = Tco ' Cutoff limits Storage / Drainage Phase
                        End If

                        Dim DT As Double = Tfvb - TL                ' Storage / Drainage time

                        If (DT < TL / 4.0) Then
                            ratios = New Double() {1.0}
                        ElseIf (DT < TL / 2.0) Then
                            ratios = New Double() {0.5, 1.0}
                        End If

                        Dim tdx As Integer = times.Length - 1
                        ReDim Preserve times(tdx + ratios.Length)

                        For rdx As Integer = 0 To ratios.Length - 1
                            times(tdx + rdx + 1) = TL + ratios(rdx) * DT
                        Next rdx
                    End If
                End If
                '
                ' Add Post-Irrigation VB (PIVB) time, if applicable
                '
                If (mInflowManagement.RecessionDataIsValid And mInflowManagement.RecessionUsed.Value) Then
                    ' Recession times are available/to be used for PIVB calculations
                    If (mInflowManagement.RunoffComplete) Then ' Runoff times are available
                        If (L - OneDecimeter <= maxAdvDist) Then ' Advance reached end-of-field
                            If (L - OneDecimeter <= maxRecDist) Then ' Recession reached end-of-field
                                ReDim Preserve times(times.Length)
                                times(times.Length - 1) = maxRecTime
                            End If
                        End If
                    End If
                End If

            End If ' Runoff Available & Used for VB
        End If ' Advance reached end-of-field

        ' Sort times in increasing order
        Array.Sort(times)
        ' Remove duplicate times
        times = RemoveDuplicateArrayValues(times)
        ' Remove all times <= 0.0
        times = RemoveNegativeArrayValues(times)
        times = RemoveSpecificArrayValues(times, 0.0)

        Return times
    End Function

    Public Function SuggestBlockedEndVolumeBalanceTimes() As Double()
        Dim times As Double() = {}

        '*****************************************************************************************************
        ' Get user input field measurements (No Runoff Hydrograph for Blocked-End systems)
        '*****************************************************************************************************
        Dim L As Double = mSystemGeometry.Length.Value                          ' Field length

        Dim qinTimes As Double() = mInflowManagement.InflowHydrographTimes()    ' Times from Inflow Hydrograph
        Dim advTimes As Double() = mInflowManagement.AdvanceProfileTimes()      '   "     "  Advance Profile
        Dim recTimes As Double() = mInflowManagement.RecessionProfileTimes()    '   "     "  Recession  "

        Dim maxAdvDist As Double = mInflowManagement.MaxAdvanceDistance         ' Max advance distance
        Dim minRecTime As Double = mInflowManagement.MinRecessionTime           ' Min recession time
        Dim maxRecTime As Double = mInflowManagement.MaxRecessionTime           ' Max     "       "
        '
        ' Get Flow Depth Hydrograph times
        '
        ' If flow depths were measured, determine latest time Vy can be calculated using the
        ' flow depth hydrographs.
        '
        Dim tVyf As Double = 0.0
        Dim tRi As Double = 0.0
        If (mInflowManagement.FlowDepthsMeasuredAndUsed) Then

            tVyf = mInflowManagement.EarliestFlowDepthHydrographFinalTime                       ' 4) a
            tRi = mInflowManagement.EarliestFlowDepthHydrographRecessionTime(True)              ' 4) b

            If (0.0 < minRecTime) Then
                tRi = Math.Min(tRi, minRecTime)
            End If

            tVyf = Math.Min(tVyf, tRi)                                                          ' 4) c
        End If

        '*****************************************************************************************************
        ' Combine times that are valid for Volume Balance calculations
        '*****************************************************************************************************
        '
        ' Start with Advance Phase times; only Advance times where 0 < Qin are valid for suggested times
        '
        While (0 < advTimes.Length)
            Dim advTime As Double = advTimes(advTimes.Length - 1) ' Last advance time
            Dim Qin As Double = mInflowManagement.InflowRateAtTimeForField(advTime) ' Qin at that time
            If (Qin <= 0) Then ' no inflow; remove Advance Time from list
                ReDim Preserve advTimes(advTimes.Length - 2)
            Else ' inflow; rest should be valid
                Exit While
            End If
        End While

        If (0 < advTimes.Length) Then
            If (8 < advTimes.Length) Then ' limit to at most 8 times
                Dim lastTime As Double = advTimes(advTimes.Length - 1) ' Last advance time

                ' Select advance times as evenly spaced as available
                For tdx As Integer = 1 To 7
                    Dim nextTime As Double = lastTime * tdx / 8             ' Desired advance time
                    Dim advTime As Double = FloorValue(advTimes, nextTime)  ' Floor time before desired

                    If Not (ArrayContainsValue(times, advTime)) Then ' not already added; add it
                        ReDim Preserve times(times.Length)
                        times(times.Length - 1) = advTime
                    End If
                Next tdx

                ' Always end with last advance time
                ReDim Preserve times(times.Length)
                times(times.Length - 1) = lastTime

            Else ' <=8; keep them all
                ReDim times(advTimes.Length - 1)
                Array.Copy(advTimes, 0, times, 0, advTimes.Length)
            End If
        Else ' there are no valid Advance times; can't continue
            Return times
        End If
        '
        ' If Advance reached end-of-field; more times can be added
        '
        If (L - OneDecimeter <= maxAdvDist) Then ' Advance reached end-of-field
            '
            ' Add Storage / Drainage Phase times
            '
            Dim ratios As Double() = {0.1, 0.25, 0.5, 1.0}

            Dim TL As Double = times(times.Length - 1)      ' Final time suggested for Advance Phase
            Dim Tco As Double = mInflowManagement.Tco

            tVyf = MathMax(tVyf, Tco)                       ' Final time for Storage / Drainage Phase
            tVyf = MathMin(tVyf, tRi)

            Dim DT As Double = tVyf - TL                    ' Delta time for Storage / Drainage Phase

            ' Blocked-End system (i.e. ponding)
            If (0.0 < DT) Then

                If (DT < TL / 4.0) Then
                    ratios = New Double() {1.0}
                ElseIf (DT < TL / 2.0) Then
                    ratios = New Double() {0.5, 1.0}
                End If

                Dim tdx As Integer = times.Length - 1
                ReDim Preserve times(tdx + ratios.Length)

                For rdx As Integer = 0 To ratios.Length - 1
                    times(tdx + rdx + 1) = TL + ratios(rdx) * DT
                Next rdx
            End If
            '
            ' Add Post-Irrigation VB (PIVB) time, if applicable
            '
            If (mInflowManagement.RecessionDataAvailable) Then ' User enter recession data
                If (mInflowManagement.RecessionUsed.Value) Then ' and indicated it can be used
                    ' Recession times are available for Volume Balance Calculations
                    If (L - OneDecimeter <= maxAdvDist) Then ' advance reached end-of-field
                        ReDim Preserve times(times.Length)
                        times(times.Length - 1) = maxRecTime
                    End If
                End If
            End If

        End If ' Advance reached end-of-field

        ' Sort times in increasing order
        Array.Sort(times)
        ' Remove duplicate times
        times = RemoveDuplicateArrayValues(times)
        ' Remove all times <= 0.0
        times = RemoveNegativeArrayValues(times)
        times = RemoveSpecificArrayValues(times, 0.0)

        Return times
    End Function

    '*********************************************************************************************************
    ' Function FindVolBalCalcRange() - find the valid range of times for Volume Balance calculations
    '*********************************************************************************************************
    Protected Function FindVolBalCalcRange(ByRef MinVolBalTime As Double, _
                                           ByRef MaxVolBalTime As Double) As VolBalCalcLimits
        FindVolBalCalcRange = VolBalCalcLimits.NotLimited
        MinVolBalTime = 0.0
        MaxVolBalTime = Double.MaxValue

        '*****************************************************************************************************
        ' Get user input field measurements
        '*****************************************************************************************************
        Dim L As Double = mSystemGeometry.Length.Value                          ' Field length

        Dim qinTimes As Double() = mInflowManagement.InflowHydrographTimes()    ' Times from Inflow Hydrograph
        Dim qroTimes As Double() = mInflowManagement.RunoffHydrographTimes()    '   "     "  Runoff      "
        Dim advTimes As Double() = mInflowManagement.AdvanceProfileTimes()      '   "     "  Advance Profile
        Dim recTimes As Double() = mInflowManagement.RecessionProfileTimes()    '   "     "  Recession  "

        ' Get advance times from Flow Depth Hydrographs, if available for use
        Dim fdAdvTimes As Double() = {}
        If (mInflowManagement.FlowDepthsMeasuredAndUsed) Then ' Flow Depths are available for VB calculations
            fdAdvTimes = mInflowManagement.FlowDepthHydrographsAdvanceTimes()
        End If
        '
        ' Limit max VB time based on the Inflow Hydrograph, there should always be one
        '
        If (0 < qinTimes.Length) Then ' there is an Inflow Hydrograph
            If Not (mInflowManagement.InflowComplete) Then ' Inflow is a Partial Hydrograph
                Dim lastQinTime As Double = qinTimes(qinTimes.Length - 1)
                If (lastQinTime < MaxVolBalTime) Then
                    FindVolBalCalcRange = VolBalCalcLimits.QinLimited
                    MaxVolBalTime = lastQinTime
                End If
            End If
        Else
            Debug.Assert(False)
        End If
        '
        ' Limit max VB time based on the Runoff Hydrograph, if any
        '
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            If (0 < qroTimes.Length) Then ' there is a Runoff Hydrograph
                If Not (mInflowManagement.RunoffComplete) Then ' Runoff is a Partial Hydrograph
                    Dim lastQroTime As Double = qinTimes(qroTimes.Length - 1)
                    If (lastQroTime < MaxVolBalTime) Then
                        MaxVolBalTime = lastQroTime
                    End If
                End If
            End If
        End If
        '
        ' Limit max VB time based on the Advance Curve, there should always be one
        '
        Dim maxAdvDist As Double = mInflowManagement.MaxAdvanceDistance
        If (maxAdvDist <= L - OneDecimeter) Then ' Advance did not reach end-of-field
            If (0 < advTimes.Length) Then ' there is an Advance Profile
                Dim lastAdvTime As Double = advTimes(advTimes.Length - 1)
                If (lastAdvTime < MaxVolBalTime) Then
                    MaxVolBalTime = lastAdvTime
                End If
            End If
        Else
            Debug.Assert(False)
        End If

    End Function

#End Region

#Region " Infiltration Table "
    '
    ' Calculate Infiltrated Depths from Opportunity Times for 'Standard' infiltration methods
    '
    Public Sub CalcStdInfiltrationTable()

        ' Recalculate the Infiltration Table
        mInfiltrationTable = New DataTable("Infiltrated Depth")
        mInfiltrationTable.Columns.Add(sDistanceX, GetType(Double))
        mInfiltrationTable.Columns.Add(sInfiltrationX, GetType(Double))

        If Not (mInflowManagement.RecessionDataAvailable) Then
            Exit Sub
        End If

        Dim oppTable As DataTable = mInflowManagement.CalcOpportunityTimes
        If (oppTable IsNot Nothing) Then
            For Each oppRow As DataRow In oppTable.Rows

                Dim dist As Double = CDbl(oppRow.Item(nDistanceX))
                Dim tau As Double = CDbl(oppRow.Item(nTauX))

                Dim depth As Double = mSoilCropProperties.InfiltrationDepth(tau)

                Dim infRow As DataRow = mInfiltrationTable.NewRow
                infRow.Item(sDistanceX) = dist
                infRow.Item(sInfiltrationX) = depth

                mInfiltrationTable.Rows.Add(infRow)

            Next oppRow
        End If

    End Sub
    '
    ' Calculate Infiltrated Depths from Opportunity Times for 'Advanced' infiltration methods
    '
    Public Sub CalcAdvInfiltrationTable()

        ' Advanced Infiltration calculation required Reference SRFR simulation
        'Dim RefSrfrAPI As Srfr.SrfrAPI = Me.GetRefSrfrAPI()
        'If (RefSrfrAPI Is Nothing) Then
        '    Return
        'End If

        ' Recalculate the Infiltration Table
        mInfiltrationTable = New DataTable("Infiltrated Depth")
        mInfiltrationTable.Columns.Add(sDistanceX, GetType(Double))
        mInfiltrationTable.Columns.Add(sInfiltrationX, GetType(Double))

        If Not (mInflowManagement.RecessionDataAvailable) Then
            Exit Sub
        End If

        Dim flowDepthHydrographs As DataSet = mSrfrResults.StdFlowDepthHydrographs
        If (flowDepthHydrographs Is Nothing) Then
            Return
        End If

        Dim oppTable As DataTable = mInflowManagement.CalcOpportunityTimes
        If (oppTable IsNot Nothing) Then
            For Each oppRow As DataRow In oppTable.Rows

                Dim dist As Double = CDbl(oppRow.Item(nDistanceX))
                Dim tau As Double = CDbl(oppRow.Item(nTauX))

                Dim flowDepthHydrograph As DataTable = mSrfrResults.StdFlowDepthHydrograph(dist)
                Dim depth0 As Double = mSoilCropProperties.InfiltrationDepth(tau, flowDepthHydrograph)

                'Dim depth1 As Double = mSoilCropProperties.InfiltrationDepth(tau, dist, RefSrfrAPI)
                'Debug.Assert(Math.Abs(depth0 - depth1) < OneCentimeter)

                Dim infRow As DataRow = mInfiltrationTable.NewRow
                infRow.Item(sDistanceX) = dist
                infRow.Item(sInfiltrationX) = depth0

                mInfiltrationTable.Rows.Add(infRow)

            Next oppRow
        End If

    End Sub

#End Region

#Region " Errors & Warnings "

    Public Overrides Sub UpdateSetupErrorsAndWarnings()
        MyBase.CheckSetupErrorsAndWarnings()
    End Sub

    '*********************************************************************************************************
    ' Function CheckSetupErrors() - check setup errors for EVALUE Analysis
    ' Function CheckSetupWarnings() - "     "  warnings "     "       "
    '*********************************************************************************************************
    Public Overrides Function CheckSetupErrors() As Boolean
        ' Call to overridden baseclass clears previous errors
        Dim hasErrors As Boolean = MyBase.CheckSetupErrors()

        Dim L As Double = mSystemGeometry.Length.Value
        Dim Tco As Double = mInflowManagement.Tco

        CheckGeometryErrors()           ' System Geometry

        CheckRoughnessErrors()          ' Soil / Crop Properties
        CheckInfiltrationErrors()

        CheckInflowErrors()             ' Inflow Management
        CheckRunoffErrors()

        CheckSolutionModelErrors()      ' Solution Model

        ' Runoff & Advance/Recession table times should align
        Dim runoffMeasured As Boolean = mInflowManagement.RunoffMeasured.Value
        Dim runoffUsed As Boolean = mInflowManagement.RunoffUsed.Value
        Dim runoffPartial As Boolean = mInflowManagement.TabulatedRunoffIncomplete.Value

        Dim advanceMeasured As Boolean = mInflowManagement.AdvanceMeasured.Value
        Dim advanceUsed As Boolean = True

        Dim recessionMeasured As Boolean = mInflowManagement.RecessionMeasured.Value
        Dim recessionUsed As Boolean = mInflowManagement.RecessionUsed.Value

        If (runoffMeasured And runoffUsed) Then ' runoff should be available for VB calculations; is it?

            Dim firstT, lastT, firstQro, lastQro As Double
            Dim runoffOK As Boolean = mInflowManagement.RunoffRange(firstT, firstQro, lastT, lastQro)
            If (runoffOK) Then
                If Not (firstQro = 0.0) Then
                    AddSetupError(ErrorFlags.Runoff, mDictionary.tInvalidRunoffTableID.Translated, _
                                  mDictionary.tInvalidRunoffForVB.Translated & " " & _
                                  mDictionary.tInvalidRunoffUseForVB.Translated)
                End If

                If Not (lastQro = 0.0) Then
                    If Not (runoffPartial) Then
                        AddSetupError(ErrorFlags.Runoff, mDictionary.tInvalidRunoffTableID.Translated, _
                                      mDictionary.tInvalidRunoffEnd.Translated)
                    End If
                End If
            End If
        End If

        If (advanceMeasured) Then
            CheckAdvanceErrors()
        End If

        If (runoffMeasured And runoffUsed And advanceMeasured) Then
            CheckRunoffAdvanceErrors(L)
        End If

        If (recessionMeasured) Then
            If (recessionUsed) Then
                CheckRecessionErrors(0.0, L)    ' Must start at X=0 and end at X=L
            Else
                CheckRecessionErrors(-1.0, 0.0) ' No up/downstream restrictions
            End If
        End If

        ' Station measurements should agree with System Geometry elevation table
        ' Station measurements & flow depths/times should align with Advance/Recession
        Dim flowDepthsMeasured As Boolean = mInflowManagement.FlowDepthsMeasured.Value
        Dim flowDepthsUsed As Boolean = mInflowManagement.FlowDepthsUsed.Value

        If (flowDepthsMeasured) Then ' check flow depth measurements
            CheckFlowDepthErrors()
            CheckStationElevationErrors()
        End If

        If (flowDepthsMeasured And Not flowDepthsUsed) Then
            CheckStationAdvanceErrors(False)

            If (recessionMeasured) Then
                CheckStationRecessionErrors(False)
            End If
        End If

        If (flowDepthsMeasured And flowDepthsUsed) Then ' flow volumes measured
            CheckStationsTableErrors(L)
            CheckStationAdvanceErrors(True)

            If (recessionMeasured And recessionUsed) Then
                CheckStationRecessionErrors(True)
            End If
        Else ' flow volumes estimated
            Dim surfaceVolumes As DataTable = mEventCriteria.EstimatedSurfaceVolumes.Value
            CheckEstimatedSurfaceVolumesErrors(surfaceVolumes)
        End If

        ' Check volume balance errors
        Dim VolBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        CheckVolumeBalancesErrors(VolBalTable)

        hasErrors = Me.HasSetupErrors
        Return hasErrors
    End Function

    Public Overrides Function CheckSetupWarnings() As Boolean
        Dim hasWarnings As Boolean = MyBase.CheckSetupWarnings()
        '
        ' Checks specific to EVALUE
        '
        Dim L As Double = mSystemGeometry.Length.Value     ' End-of-field

        If (mInflowManagement.AdvanceDataAvailable) Then
            Dim advTable As DataTable = mInflowManagement.TabulatedAdvance.Value
            If (2 = advTable.Rows.Count) Then
                Dim warning As String = mDictionary.tSingleAdvanceMeasurement.Translated
                warning &= " r = " & mInflowManagement.AdvanceR.ValueString & ".  "
                warning &= mDictionary.tTestAlternativeValuesOfR.Translated
                AddSetupWarning(WarningFlags.ExecutionWarning, "", warning)
            End If
        End If

        ' Check infiltration calculations
        Dim inflowComplete As Boolean = mInflowManagement.InflowComplete

        Dim runoffComplete As Boolean = mInflowManagement.RunoffComplete
        Dim runoffMeasured As Boolean = mInflowManagement.RunoffMeasured.Value
        Dim runoffUsed As Boolean = mInflowManagement.RunoffUsed.Value

        Dim advanceMeasured As Boolean = mInflowManagement.AdvanceMeasured.Value
        Dim advanceUsed As Boolean = True

        Dim recessionMeasured As Boolean = mInflowManagement.RecessionMeasured.Value
        Dim recessionUsed As Boolean = mInflowManagement.RecessionUsed.Value

        If Not (inflowComplete) Then
            AddSetupWarning(WarningFlags.ExecutionWarning, _
                            "", mDictionary.tCannotPredictParameters.Translated)
        End If

        If Not (inflowComplete And runoffComplete) Then
            AddSetupWarning(WarningFlags.VolumeBalanceWarning, _
                            "", mDictionary.tCannotComputeVolumeBalance.Translated)
        End If

        If (runoffMeasured And runoffUsed And recessionMeasured And recessionUsed) Then
            If Not (runoffComplete) Then
                AddSetupWarning(WarningFlags.VolumeBalanceWarning, _
                                mDictionary.tInvalidRecessionDataUseID.Translated, _
                                mDictionary.tInvalidRecessionDataUseDetail.Translated)
            End If
        End If

        ' Check runoff/recession warnings
        If (runoffMeasured And runoffUsed And recessionMeasured) Then
            CheckRunoffRecessionWarnings(L)
        End If

        ' Check volume balance warnings
        Dim VolBalTable As DataTable = mEventCriteria.VolumeBalances.Value
        CheckVolumeBalancesWarnings(VolBalTable)

        ' Check surface flow volume warnings
        Dim flowDepthsMeasured As Boolean = mInflowManagement.FlowDepthsMeasured.Value
        Dim flowDepthsUsed As Boolean = mInflowManagement.FlowDepthsUsed.Value
        If (flowDepthsMeasured And flowDepthsUsed) Then ' flow volumes measured
        Else ' flow volumes estimated
            Dim surfaceVolumes As DataTable = mEventCriteria.EstimatedSurfaceVolumes.Value
            CheckEstimatedSurfaceVolumesWarnings(surfaceVolumes)
        End If

        hasWarnings = Me.HasSetupWarnings
        Return hasWarnings
    End Function

    '*********************************************************************************************************
    ' Sub CheckStationsTableErrors()    - check Stations' Table setup errors
    ' Sub CheckStationLocationErrors()  -   "       "       "   location errors
    ' Sub CheckStationElevationErrors() -   "       "       "   elevation errors
    '*********************************************************************************************************
    Public Sub CheckStationsTableErrors(ByVal L As Double)

        ' Start with the most general Stations Error
        Dim errorFlag As ErrorFlags = ErrorFlags.MeasurementStations
        Dim errorID As String = mDictionary.tInvalidStationsTableID.Translated
        Dim errorDetail As String = mDictionary.tInvalidStationsTableDetail.Translated

        Dim stationsError As InflowManagement.StationErrors = mInflowManagement.ValidateStationsTable(L)

        If Not (stationsError = InflowManagement.StationErrors.NoError) Then ' there is a station error

            Select Case (stationsError) ' get specific error's detail
                Case InflowManagement.StationErrors.NotEnoughStations
                    errorDetail = mDictionary.tNotEnoughStationsDetail.Translated
                Case InflowManagement.StationErrors.FirstStationNotAt0
                    errorDetail = mDictionary.tFirstStationNotAtHeadDetail.Translated
                Case InflowManagement.StationErrors.LastStationNotAtL
                    errorDetail = mDictionary.tLastStationNotAtEndDetail.Translated
                Case InflowManagement.StationErrors.DistancesNotMonotonic
                    errorDetail = mDictionary.tInvalidStationDistancesNotMonotonic.Translated
            End Select

            AddSetupError(errorFlag, errorID, errorDetail)
        End If

    End Sub

    Public Sub CheckStationLocationErrors()

        ' Start with the most general Stations Error
        Dim errorFlag As ErrorFlags = ErrorFlags.MeasurementStations
        Dim errorID As String = mDictionary.tInvalidStationsTableID.Translated
        Dim errorDetail As String = mDictionary.tInvalidStationsTableDetail.Translated

        Dim stationIdx As Integer
        Dim stationError As InflowManagement.StationErrors

        stationError = mInflowManagement.ValidateStationLocations(stationIdx)

        If Not (stationError = InflowManagement.StationErrors.NoError) Then ' there is a station error

            Select Case (stationError) ' get specific error's detail
                Case InflowManagement.StationErrors.InvalidTable
                    ' general error works here
                Case InflowManagement.StationErrors.LocationNotSynced
                    errorID = mDictionary.tInvalidStationLocationID.Translated
                    errorDetail = mDictionary.tInvalidStationLocationDetail.Translated
            End Select

            Dim stationsTable As DataTable = mInflowManagement.MeasurementStations.Value
            If ((0 <= stationIdx) And (stationIdx < stationsTable.Rows.Count)) Then
                Dim staRow As DataRow = stationsTable.Rows(stationIdx)
                Dim staDist As Double = staRow.Item(nDistanceX) ' Location of Measurement Station
                errorDetail &= " for Station at " & LengthString(staDist)
            End If

            AddSetupError(errorFlag, errorID, errorDetail)
        End If

    End Sub

    Public Sub CheckStationElevationErrors()

        ' Start with the most general Stations Error
        Dim errorFlag As ErrorFlags = ErrorFlags.MeasurementStations
        Dim errorID As String = mDictionary.tInvalidStationsTableID.Translated
        Dim errorDetail As String = mDictionary.tInvalidStationsTableDetail.Translated

        Dim stationIdx As Integer
        Dim stationError As InflowManagement.StationErrors

        stationError = mInflowManagement.ValidateStationElevations(stationIdx)

        If Not (stationError = InflowManagement.StationErrors.NoError) Then ' there is a station error

            Select Case (stationError) ' get specific error's detail
                Case InflowManagement.StationErrors.InvalidTable
                    ' general error works here
                Case InflowManagement.StationErrors.LocationNotSynced
                    errorID = mDictionary.tInvalidStationLocationID.Translated
                    errorDetail = mDictionary.tInvalidStationLocationDetail.Translated
                Case InflowManagement.StationErrors.ElevationNotSynced
                    errorID = mDictionary.tInvalidStationElevationID.Translated
                    errorDetail = mDictionary.tInvalidStationElevationDetail.Translated
            End Select

            Dim stationsTable As DataTable = mInflowManagement.MeasurementStations.Value
            If ((0 <= stationIdx) And (stationIdx < stationsTable.Rows.Count)) Then
                Dim staRow As DataRow = stationsTable.Rows(stationIdx)
                Dim staDist As Double = staRow.Item(nDistanceX) ' Location of Measurement Station
                errorDetail &= " for Station at " & LengthString(staDist)
            End If

            AddSetupError(errorFlag, errorID, errorDetail)
        End If

    End Sub

    Public Sub CheckStationAdvanceErrors(ByVal FirstPointIsAdvance As Boolean)

        ' Start with the most general Stations Error
        Dim errorFlag As ErrorFlags = ErrorFlags.MeasurementStations
        Dim errorID As String = mDictionary.tInvalidStationsTableID.Translated
        Dim errorDetail As String = mDictionary.tInvalidStationsTableDetail.Translated

        Dim stationIdx As Integer
        Dim stationError As InflowManagement.StationErrors

        stationError = mInflowManagement.ValidateStationAdvanceTimes(FirstPointIsAdvance, stationIdx)

        If Not (stationError = InflowManagement.StationErrors.NoError) Then ' there is a station error

            Select Case (stationError) ' get specific error's detail
                Case InflowManagement.StationErrors.InvalidTable
                    ' general error works here
                Case InflowManagement.StationErrors.AdvanceTimes
                    errorID = mDictionary.tInvalidStationAdvanceID.Translated
                    errorDetail = mDictionary.tInvalidStationAdvanceDetail.Translated
                Case InflowManagement.StationErrors.NoFlowDepthTableForStation
                    errorID = mDictionary.tInvalidFlowDepthTablesID.Translated
                    errorDetail = mDictionary.tInvalidFlowDepthTablesDetail.Translated
                Case InflowManagement.StationErrors.FirstFlowDepthNotZero
                    errorID = mDictionary.tInvalidFlowDepthTablesID.Translated
                    errorDetail = mDictionary.tInvalidInitialFlowDepth.Translated
                Case InflowManagement.StationErrors.FirstFlowDepthTimeNotAdv
                    errorID = mDictionary.tInvalidFlowDepthTablesID.Translated
                    errorDetail = mDictionary.tInvalidInitialFlowDepthTime.Translated
            End Select

            Dim stationsTable As DataTable = mInflowManagement.MeasurementStations.Value
            If ((0 <= stationIdx) And (stationIdx < stationsTable.Rows.Count)) Then
                Dim staRow As DataRow = stationsTable.Rows(stationIdx)
                Dim staDist As Double = staRow.Item(nDistanceX) ' Location of Measurement Station
                errorDetail &= " for Station at " & LengthString(staDist)
            End If

            AddSetupError(errorFlag, errorID, errorDetail)
        End If

    End Sub

    Public Sub CheckStationRecessionErrors(ByVal LastPointIsRecession As Boolean)

        ' Start with the most general Stations Error
        Dim errorFlag As ErrorFlags = ErrorFlags.MeasurementStations
        Dim errorID As String = mDictionary.tInvalidStationsTableID.Translated
        Dim errorDetail As String = mDictionary.tInvalidStationsTableDetail.Translated

        Dim stationIdx As Integer
        Dim stationsError As InflowManagement.StationErrors
        stationsError = mInflowManagement.ValidateStationRecessionTimes(LastPointIsRecession, stationIdx)

        If Not (stationsError = InflowManagement.StationErrors.NoError) Then ' there is a station error

            Select Case (stationsError) ' get specific error's detail
                Case InflowManagement.StationErrors.InvalidTable
                    ' general error works here
                Case InflowManagement.StationErrors.RecessionTimes
                    errorID = mDictionary.tInvalidStationRecessionID.Translated
                    errorDetail = mDictionary.tInvalidStationRecessionDetail.Translated
                Case InflowManagement.StationErrors.NoFlowDepthTableForStation
                    errorID = mDictionary.tInvalidFlowDepthTablesID.Translated
                    errorDetail = mDictionary.tInvalidFlowDepthTablesDetail.Translated
                Case InflowManagement.StationErrors.LastFlowDepthNotZero
                    errorID = mDictionary.tInvalidFlowDepthTablesID.Translated
                    errorDetail = mDictionary.tInvalidFinalFlowDepth.Translated
                Case InflowManagement.StationErrors.LastFlowDepthTimeNotRec
                    errorID = mDictionary.tInvalidFlowDepthTablesID.Translated
                    errorDetail = mDictionary.tInvalidFinalFlowDepthTime.Translated
            End Select

            Dim stationsTable As DataTable = mInflowManagement.MeasurementStations.Value
            If ((0 <= stationIdx) And (stationIdx < stationsTable.Rows.Count)) Then
                Dim staRow As DataRow = stationsTable.Rows(stationIdx)
                Dim staDist As Double = staRow.Item(nDistanceX) ' Location of Measurement Station
                errorDetail &= " for Station at " & LengthString(staDist)
            End If

            AddSetupError(errorFlag, errorID, errorDetail) ' specific error
        End If

    End Sub

#End Region

End Class
