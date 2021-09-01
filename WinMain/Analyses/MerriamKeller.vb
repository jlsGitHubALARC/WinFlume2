
'*************************************************************************************************************
' Class:    MerriamKeller
'
' Desc: Perform Merriam-Keller Analysis 
'*************************************************************************************************************
Imports Srfr.SrfrAPI
Imports DataStore

Public Class MerriamKeller
    Inherits EventAnalysis

#Region " Member Data "

#End Region

#Region " Properties "
    '
    ' Calculated Kostiakov k
    '
    Protected mMKostiakovK As Double
    Public ReadOnly Property MKostiakovK() As Double
        Get
            Return mMKostiakovK
        End Get
    End Property
    '
    ' Selected NRCS Intake Family
    '
    Protected mNrcsIntakeFamily As Srfr.NrcsIntakeFamily.NrcsIntakeFamilies = Srfr.NrcsIntakeFamily.DefaultNrcsIntakeFamily
    Public ReadOnly Property NrcsIntakeFamily() As Srfr.NrcsIntakeFamily.NrcsIntakeFamilies
        Get
            Return mNrcsIntakeFamily
        End Get
    End Property
    '
    ' Calculated Time-Rated Intake Family
    '
    Protected mTimeRatedIntakeFamily As Double
    Public ReadOnly Property TimeRatedIntakeFamily() As Double
        Get
            Return mTimeRatedIntakeFamily
        End Get
    End Property
    '
    ' Infiltrated Depths DataTable
    '
    Protected mInfiltrationTable As DataTable
    Public ReadOnly Property InfiltrationTable() As DataTable
        Get
            Return mInfiltrationTable
        End Get
    End Property

#End Region

#Region " Constructor "

    Public Sub New(ByVal unit As Unit, ByVal worldWindow As WorldWindow)
        MyBase.New(unit, worldWindow)
    End Sub

#End Region

#Region " Run Simulation "

    Protected Overrides Function UnloadSrfrResults(ByVal srfrAPI As Srfr.SrfrAPI, ByVal unit As Unit,
        ByVal compareRun As Boolean, ByVal skipProfiles As Boolean, ByVal skipHydroGraphs As Boolean) As Srfr.Irrigation
        ' Unload the SRFR results common to all/most Event Analyses
        Dim srfrResults As Srfr.Irrigation = Nothing
        srfrResults = MyBase.UnloadSrfrResults(srfrAPI, unit, compareRun, skipProfiles, skipHydroGraphs)
        '
        ' Unload the Merriam-Keller specific, additional SRFR results
        '
        ' A simulation derived Volume Balance table that corresponds to the evaluation Volume Balance
        ' table is required for the results display.
        '
        If (srfrResults IsNot Nothing) Then
            Dim mkVolBalTable As DataTable = Me.VolumeBalanceTableForCrossSection
            If (mkVolBalTable IsNot Nothing) Then
                Dim simVolBalParam As DataTableParameter = mEventCriteria.SimulationVolumeBalances
                Dim simVolBalTable As DataTable = simVolBalParam.Value
                mEventCriteria.ResetVolumeBalancesTable(simVolBalTable)

                For Each mkRow As DataRow In mkVolBalTable.Rows
                    Dim time As Double = CDbl(mkRow.Item(sTimeX))

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
                Next mkRow

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
        Me.StartRun("Merriam-Keller", False)

        ' Calculate & save the Solution
        CalculateSolution()

        ' Re-calculate & save the Infiltration table AFTER CalculateSolution()
        Me.CalcSaveInfiltrationTable()

        Me.EndRun()
    End Sub

#End Region

#Region " Solution "

    Public Overrides Sub CalculateSolution()
        MyBase.CalculateSolution()
        Me.RunSimulation(CellDensities.Medium)
    End Sub

#End Region

#Region " Automation "

    '*********************************************************************************************************
    ' Function PreAutoRun()     - performs pre-AutoRun functions such as setup error checking
    '
    ' Note - for Merriam-Keller method, also estimate selected infiltration parameters prior to AutoRun()
    '*********************************************************************************************************
    Public Overrides Function PreAutoRun() As Boolean

        ' Estimate appropriate infiltration parameters
        Dim parameter As IntegerParameter = mSoilCropProperties.InfiltrationFunction
        Dim infiltrationFunction As InfiltrationFunctions = parameter.Value

        Select Case (infiltrationFunction)
            Case InfiltrationFunctions.NRCSIntakeFamily
                Me.SelectNrcsIntakeFamily()

            Case InfiltrationFunctions.TimeRatedIntakeFamily
                Me.CalcTimeRatedIntakeFamily()

            Case InfiltrationFunctions.CharacteristicInfiltrationTime
                Me.EstimateCharacteristicTimeK()

            Case InfiltrationFunctions.KostiakovFormula
                Me.EstimateKostiakovFormulaK()

            Case InfiltrationFunctions.ModifiedKostiakovFormula
                Me.EstimateModifiedKostiakovK()

            Case InfiltrationFunctions.BranchFunction
                Me.EstimateBranchFunctionK()

            Case Else
                Debug.Assert(False)
        End Select

        UpdateSetupErrorsAndWarnings()                  ' Check for setup errors/warnings
        PreAutoRun = Not HasSetupErrors()               ' Setup errors should prevent AutoRun()
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
                            If Not (_sel = sGreenAmpt) Then ' Green-Ampt is not a valid selection
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

    End Sub

#End Region

#Region " NRCS Intake Family Selection "
    '
    ' Select best-fitting NRCS Intake Family (uses NRCS Upstream Wetted Perimeter)
    '
    Public Function SelectNrcsIntakeFamily() As Boolean

        ' Input parameters
        Dim oppTable As DataTable = mInflowManagement.CalcOpportunityTimes
        If (oppTable Is Nothing) Then
            AddSetupError(ErrorFlags.OpportunityTimes, _
                                mDictionary.tNoOpportunityTimesID.Translated, _
                                mDictionary.tNoOpportunityTimesDetail.Translated)
            Return False
        ElseIf (0 = oppTable.Rows.Count) Then
            AddSetupError(ErrorFlags.OpportunityTimes, _
                                mDictionary.tNoOpportunityTimesID.Translated, _
                                mDictionary.tNoOpportunityTimesDetail.Translated)
            Return False
        End If

        Dim S0 As Double = mSystemGeometry.AverageSlope
        Dim W As Double = mSystemGeometry.WidthForCrossSection
        Dim L As Double = mSystemGeometry.Length.Value
        Dim Qavg As Double = mInflowManagement.AverageInflowRateForCrossSection
        Dim n As Double = mSoilCropProperties.ManningN.Value

        ' Make necessary modifications for furrows
        Dim wpFactor As Double = 1.0

        If (mUnit.CrossSection = Globals.CrossSections.Furrow) Then
            ' Friction slope (i.e. hydraulic gradient)
            Dim Sf As Double = S0
            If (Sf <= 0.0) Then
                ' If level field, use emperical SCS formula
                Sf = NrcsHydraulicGradient(Qavg, L)
            End If

            ' Upstream Wetted Perimeter (emperical NRCS formula)
            Dim WP0 As Double = NrcsUpstreamWettedPerimeter(Qavg, Sf, n)

            ' Wetted Perimeter Factor (1.0+)
            If (WP0 < W) Then
                wpFactor = WP0 / W
            End If
        End If

        ' c is dependent on selected NRCS Option
        Dim nrcsOption As Srfr.NrcsIntakeFamily.NrcsIntakeOptions = mSoilCropProperties.NrcsToKostiakovMethod.Value
        Dim nrcsFamily As Srfr.NrcsIntakeFamily.NrcsIntakeFamilies
        Dim nrcsValues As Srfr.NrcsIntakeFamily.NrcsIntakeValues

        Dim c As Double
        Select Case (nrcsOption)
            Case Srfr.NrcsIntakeFamily.NrcsIntakeOptions.ApproximateByBestFit
                c = 0
            Case Else ' Srfr.NrcsIntakeFamily.NrcsIntakeOptions.DescribeByNrcsFormula
                c = Srfr.Globals.Depth7mm
        End Select

        ' Try to match Inflow / Runoff infiltrated volume with one calculated using
        ' NRCS Intake Family and Opportunity Times table

        ' Infiltrated volume from Inflow / Runoff mass balance
        Dim mbVolume As Double = mInflowManagement.InfiltratedVolumeForCrossSection

        Dim deltaVolume As Double = Double.MaxValue
        Dim loVolume, hiVolume As Double

        Dim tableSize As Integer = Srfr.NrcsIntakeFamily.NrcsIntakeFamilyTableSize
        For nrcsFamily = 0 To tableSize - 1
            nrcsValues = Srfr.NrcsIntakeFamily.NrcsIntakeFamilyValues(nrcsFamily, nrcsOption)

            Dim k As Double = nrcsValues.k
            Dim a As Double = nrcsValues.a
            Dim b As Double = 0.0

            Dim oppVolume As Double = InfiltratedDepth(oppTable, 0.77, k, a, b, c) * W * wpFactor

            ' Save limiting infiltrated volumes
            If (0 = nrcsFamily) Then
                ' First NRCS Family
                loVolume = oppVolume
            Else
                ' Eventually, last NRCS Family
                hiVolume = oppVolume
            End If

            ' Is this NRCS Family closer to Mass-Balance volume?
            If (Math.Abs(oppVolume - mbVolume) < deltaVolume) Then
                ' Yes, save as possible selection
                deltaVolume = Math.Abs(oppVolume - mbVolume)
                Me.mNrcsIntakeFamily = nrcsFamily
            End If
        Next

        ' Verify Mass-Balance volume within range of NRCS Intake Family values
        If ((mbVolume < loVolume) Or (hiVolume < mbVolume)) Then
            AddSetupError(ErrorFlags.ExecutionError, _
                          mDictionary.tOutsideNrcsRangeID.Translated, _
                          mDictionary.tOutsideNrcsRangeDetail.Translated)
            Return False

        Else

            ' Set the Infiltration Method match to the Merriam-Keller Option
            Dim infFunc As IntegerParameter = mSoilCropProperties.InfiltrationFunction
            If Not ((infFunc.Value = InfiltrationFunctions.NRCSIntakeFamily) _
                And (infFunc.Source = ValueSources.UserEntered)) Then
                infFunc.Value = InfiltrationFunctions.NRCSIntakeFamily
                infFunc.Source = ValueSources.UserEntered
                mSoilCropProperties.InfiltrationFunction = infFunc
            End If

            ' Save new value for NRCS Intake Family
            Dim nrcs As IntegerParameter = mSoilCropProperties.NrcsIntakeFamily
            If Not ((nrcs.Value = Me.NrcsIntakeFamily) _
                And (nrcs.Source = ValueSources.Calculated)) Then
                nrcs.Value = Me.NrcsIntakeFamily
                nrcs.Source = ValueSources.Calculated
                mSoilCropProperties.NrcsIntakeFamily = nrcs
            End If

            ' NRCS Intake Family should use NRCS Empirical Function
            Dim _wettedPerimeter As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
            If Not (_wettedPerimeter.Value = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
                _wettedPerimeter.Value = WettedPerimeterMethods.NrcsEmpiricalFunction
                _wettedPerimeter.Source = DataStore.Globals.ValueSources.Calculated
                mSoilCropProperties.WettedPerimeterMethod = _wettedPerimeter
            End If

            ' Save the Reference Flow Rate used to calculate the NRCS Family
            Me.SaveReferenceFlowRate(Qavg)

            ' Calculate & save the Infiltration table
            Me.CalcSaveInfiltrationTable()

        End If

        Return True
    End Function

#End Region

#Region " Time-Rated Intake Family Estimation "
    '
    ' Calculate Time-Rated Intake Family (uses Representative Upstream Wetted Perimeter)
    '
    Public Function CalcTimeRatedIntakeFamily() As Boolean

        ' Input parameters
        Dim oppTable As DataTable = mInflowManagement.CalcOpportunityTimes
        Dim S0 As Double = mSystemGeometry.AverageSlope
        Dim W As Double = mSystemGeometry.WidthForCrossSection
        Dim L As Double = mSystemGeometry.Length.Value
        Dim Qavg As Double = mInflowManagement.AverageInflowRateForCrossSection
        Dim n As Double = mSoilCropProperties.ManningN.Value

        ' Make necessary modifications for furrows
        Dim wpFactor As Double = 1.0

        If (mUnit.CrossSection = Globals.CrossSections.Furrow) Then
            ' Friction slope (i.e. hydraulic gradient)
            ' Zerihun et al approach
            Dim Sf As Double = mSystemGeometry.FurrowHydraulicGradient(n, Qavg)

            ' Upstream Wetted Perimeter
            Dim y0 As Double = mSystemGeometry.FurrowNormalDepth(Sf, n, Qavg)
            Dim WP0 As Double = mSystemGeometry.FurrowWettedPerimeter(y0)

            ' Wetted Perimeter Factor
            If (WP0 < W) Then
                wpFactor = WP0 / W
            End If
        End If

        ' Infiltrated volume from Inflow / Runoff mass balance
        Dim mbVolume As Double = mInflowManagement.InfiltratedVolumeForCrossSection

        ' Lower limit for binary search for Time-Rated Family is T = 32hr
        Dim tLo As Double = 32.0 * OneHour
        Dim aLo As Double = NrcsA(tLo)
        Dim kLo As Double = KostiakovK(Srfr.Globals.Depth100mm, tLo, aLo)
        Dim loVolume As Double = InfiltratedDepth(oppTable, 0.77, kLo, aLo, 0.0, 0.0) * W * wpFactor

        ' Upper limit for binary search
        Dim tHi As Double = OneHour / 2.0
        Dim aHi As Double = NrcsA(tHi)
        Dim kHi As Double = KostiakovK(Srfr.Globals.Depth100mm, tHi, aHi)
        Dim hiVolume As Double = InfiltratedDepth(oppTable, 0.77, kHi, aHi, 0.0, 0.0) * W * wpFactor

        ' Does Mass-Balance Volume fall within Time-Rated Family range?
        If ((loVolume <= mbVolume) And (mbVolume <= hiVolume)) Then
            ' Yes, binary search for Time-Rated Intake Family
            Dim tMid, aMid, kMid, midVolume As Double

            For cnt As Integer = 0 To 25
                ' Calc value for mid-point
                tMid = (tLo + tHi) / 2.0
                aMid = NrcsA(tMid)
                kMid = KostiakovK(Srfr.Globals.Depth100mm, tMid, aMid)
                midVolume = InfiltratedDepth(oppTable, 0.77, kMid, aMid, 0.0, 0.0) * W * wpFactor

                ' Move appropriate end-point to mid-point
                If (mbVolume < midVolume) Then
                    ' Mass-Balance Volume is between lo & mid
                    tHi = tMid
                    aHi = aMid
                    kHi = kMid
                    hiVolume = midVolume
                ElseIf (midVolume < mbVolume) Then
                    ' Mass-Balance Volume is between mid & hi
                    tLo = tMid
                    aLo = aMid
                    kLo = kMid
                    loVolume = midVolume
                Else ' (mbVolume = midVolume)
                    Exit For
                End If

                ' End times are close; we're finished!
                If ((tLo - tHi) <= OneSecond) Then
                    Exit For
                End If
            Next

            ' Save the Time-Rated Intake Family
            mTimeRatedIntakeFamily = tMid

            ' Set the Infiltration Method to match the Merriam-Keller Option
            Dim infFunc As IntegerParameter = mSoilCropProperties.InfiltrationFunction
            If Not ((infFunc.Value = InfiltrationFunctions.TimeRatedIntakeFamily) _
                And (infFunc.Source = ValueSources.UserEntered)) Then
                infFunc.Value = InfiltrationFunctions.TimeRatedIntakeFamily
                infFunc.Source = ValueSources.UserEntered
                mSoilCropProperties.InfiltrationFunction = infFunc
            End If

            ' Time-Rated Families only use Representative Upstream Wetted Perimeter
            Dim wp As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
            If Not ((wp.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter) _
                And (wp.Source = DataStore.Globals.ValueSources.Calculated)) Then
                wp.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter
                wp.Source = DataStore.Globals.ValueSources.Calculated
                mSoilCropProperties.WettedPerimeterMethod = wp
            End If

            Dim timeRatedFamily As DoubleParameter = mSoilCropProperties.InfiltrationTime_TR
            If Not ((timeRatedFamily.Value = mTimeRatedIntakeFamily) _
                And (timeRatedFamily.Source = ValueSources.Calculated)) Then
                timeRatedFamily.Value = mTimeRatedIntakeFamily
                timeRatedFamily.Source = ValueSources.Calculated
                mSoilCropProperties.InfiltrationTime_TR = timeRatedFamily
            End If

            ' Save the Reference Flow Rate when Infiltration Time estimated
            Me.SaveReferenceFlowRate(Qavg)

            ' Calculate & save the Infiltration table
            Me.CalcSaveInfiltrationTable()

        Else
            ' No, Mass-Balance Volume outside range; no solution is possible
            AddSetupError(ErrorFlags.ExecutionError, _
                          mDictionary.tOutsideTimeRatedRangeID.Translated, _
                          mDictionary.tOutsideTimeRatedRangeDetail.Translated)
            Return False
        End If

        Return True
    End Function

#End Region

#Region " Characteristic Time Estimation k "
    '
    ' Calculate estimation for Characteristic Time k (uses Furrow Spacing)
    '
    Public Function EstimateCharacteristicTimeK() As Boolean
        Dim _ok As Boolean = True
        '
        ' For the Characteristic Time infiltration method, Merriam-Keller estimates k using:
        '
        '   Kostiakov Formula:      Davg = k * t^a
        '
        '       Davg    - average infiltrated depth based on Border Width or Furrow Spacing
        '       t       - calculated from opportunity time table
        '       a       - entered/estimated by user
        '
        Dim Davg As Double = mInflowManagement.AverageInfiltratedDepthForField ' Border Width or Furrow Spacing

        Dim oppTable As DataTable = mInflowManagement.CalcOpportunityTimes

        Dim a As Double = mSoilCropProperties.KostiakovA_KT.Value
        Dim b As Double = 0.0
        Dim c As Double = 0.0

        mMKostiakovK = EstimateModifiedKostiakovK(oppTable, 0.65, Davg, a, b, c)

        Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_KT
        If Not (aParam.Source = ValueSources.UserEntered) Then
            aParam.Source = ValueSources.UserEntered
            mSoilCropProperties.KostiakovA_KT = aParam
        End If

        ' Set Characteristic Infiltration Depth to the Required Depth
        Dim Dreg As Double = mInflowManagement.RequiredDepth.Value
        Dim depthParam As DoubleParameter = mSoilCropProperties.InfiltrationDepth_KT
        If Not ((depthParam.Value = Dreg) _
            And (depthParam.Source = ValueSources.UserEntered)) Then
            depthParam.Value = Dreg
            depthParam.Source = ValueSources.UserEntered
            mSoilCropProperties.InfiltrationDepth_KT = depthParam
        End If

        ' Calculate Characteristic Infiltration Time
        Dim Tinf As Double = Srfr.SrfrAPI.InfiltrationTimeMK(depthParam.Value, mMKostiakovK, a)
        Dim timeParam As DoubleParameter = mSoilCropProperties.InfiltrationTime_KT
        If Not ((timeParam.Value = Tinf) _
            And (timeParam.Source = ValueSources.UserEntered)) Then
            timeParam.Value = Tinf
            timeParam.Source = ValueSources.UserEntered
            mSoilCropProperties.InfiltrationTime_KT = timeParam
        End If

        ' Set Infiltration Method to Characteristic Infiltration Time
        Dim funcParam As IntegerParameter = mSoilCropProperties.InfiltrationFunction
        If Not ((funcParam.Value = InfiltrationFunctions.CharacteristicInfiltrationTime) _
            And (funcParam.Source = ValueSources.UserEntered)) Then
            funcParam.Value = InfiltrationFunctions.CharacteristicInfiltrationTime
            funcParam.Source = ValueSources.UserEntered
            mSoilCropProperties.InfiltrationFunction = funcParam
        End If

        ' Characteristic Infiltration Time is Furrow Spacing based
        Dim wpParam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
        If Not ((wpParam.Value = WettedPerimeterMethods.FurrowSpacing) _
            And (wpParam.Source = DataStore.Globals.ValueSources.Calculated)) Then
            wpParam.Value = WettedPerimeterMethods.FurrowSpacing
            wpParam.Source = DataStore.Globals.ValueSources.Calculated
            mSoilCropProperties.WettedPerimeterMethod = wpParam
        End If

        ' Save Reference Flow Rate when Characteristic Infiltration Time estimated
        Dim Qavg As Double = mInflowManagement.AverageInflowRateForCrossSection
        Me.SaveReferenceFlowRate(Qavg)

        ' Calculate & save the Infiltration table
        Me.CalcSaveInfiltrationTable()

        Return _ok
    End Function

#End Region

#Region " Kostiakov Formula k Estimation "
    '
    ' Calculate estimation for Kostiakov Formula k
    '
    Public Function EstimateKostiakovFormulaK() As Boolean
        '
        ' For the Kostiakov Formula infiltration method, Merriam-Keller estimates k using:
        '
        '   Kostiakov Formula:      Davg = k * t^a
        '
        '       Davg    - average infiltrated depth based on Border Width or Furrow Wetted Perimeter
        '       t       - calculated from opportunity time table
        '       a       - entered/estimated by user
        '
        Dim Davg As Double = Me.AverageInfiltratedDepth
        Dim Qavg As Double = mInflowManagement.AverageInflowRateForCrossSection

        Dim oppTable As DataTable = mInflowManagement.CalcOpportunityTimes

        Dim a As Double = mSoilCropProperties.KostiakovA_KF.Value
        Dim b As Double = 0.0
        Dim c As Double = 0.0

        mMKostiakovK = EstimateModifiedKostiakovK(oppTable, 0.65, Davg, a, b, c)

        If (Double.IsNaN(mMKostiakovK)) Then

            Return False

        Else

            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_KF
            If Not (aParam.Source = ValueSources.UserEntered) Then
                aParam.Source = ValueSources.UserEntered
                mSoilCropProperties.KostiakovA_KF = aParam
            End If

            ' Set Infiltration Method to Kostiakov Formula
            Dim funcParam As IntegerParameter = mSoilCropProperties.InfiltrationFunction
            If Not ((funcParam.Value = InfiltrationFunctions.KostiakovFormula) _
                And (funcParam.Source = ValueSources.UserEntered)) Then
                funcParam.Value = InfiltrationFunctions.KostiakovFormula
                funcParam.Source = ValueSources.UserEntered
                mSoilCropProperties.InfiltrationFunction = funcParam
            End If

            ' Kostiakov & Branch should not use NRCS Wetted Perimeter
            Dim wpParam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
            If (wpParam.Value = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
                wpParam.Value = WettedPerimeterMethods.FurrowSpacing
                wpParam.Source = DataStore.Globals.ValueSources.Calculated
                mSoilCropProperties.WettedPerimeterMethod = wpParam
            End If

            ' Save new value for Kostiakov k
            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_KF
            If Not ((kParam.Value = mMKostiakovK) _
                And (kParam.Source = ValueSources.Calculated)) Then
                kParam.Value = mMKostiakovK
                kParam.Source = ValueSources.Calculated
                mSoilCropProperties.KostiakovK_KF = kParam
            End If

            ' Save the Reference Flow Rate when Kostiakov Function calculated
            Me.SaveReferenceFlowRate(Qavg)

            ' Calculate & save the Infiltration table
            Me.CalcSaveInfiltrationTable()

        End If

        Return True
    End Function

#End Region

#Region " Modified Kostiakov k Estimation "
    '
    ' Calculate estimation for Modified Kostiakov k
    '
    Public Function EstimateModifiedKostiakovK() As Boolean
        '
        ' For the Modified Kostiakov Formula infiltration method, Merriam-Keller estimates k using:
        '
        '   Modified Kostiakov:     Davg = k * t^a + b * t + c
        '
        '       Davg    - average infiltrated depth based on Border Width or Furrow Wetted Perimeter
        '       t       - calculated from opportunity time table
        '       a       - entered/estimated by user
        '
        Dim Davg As Double = Me.AverageInfiltratedDepth
        Dim Qavg As Double = mInflowManagement.AverageInflowRateForCrossSection

        Dim oppTable As DataTable = mInflowManagement.CalcOpportunityTimes

        Dim a As Double = mSoilCropProperties.KostiakovA_MK.Value
        Dim b As Double = mSoilCropProperties.KostiakovB_MK.Value
        Dim c As Double = mSoilCropProperties.KostiakovC_MK.Value

        If (mUnit.CrossSection = CrossSections.Furrow) Then
            ' c is always based on Furrow Spacing
            Dim curWP As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value
            If (curWP = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter) Then

                Dim FS As Double = mSystemGeometry.FurrowSpacing.Value
                Dim WP0 As Double = mUnit.UpstreamWettedPerimeter()
                Dim ratio As Double = FS / WP0

                c *= ratio
            End If
        End If

        Dim sigmaZ As Double = 1.0 / (1.0 + a)

        mMKostiakovK = EstimateModifiedKostiakovK(oppTable, sigmaZ, Davg, a, b, c)

        If (Double.IsNaN(mMKostiakovK)) Then

            Return False

        Else

            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_MK
            If Not (aParam.Source = ValueSources.UserEntered) Then
                aParam.Source = ValueSources.UserEntered
                mSoilCropProperties.KostiakovA_MK = aParam
            End If

            Dim bParam As KostiakovBParameter = mSoilCropProperties.KostiakovB_MK
            If Not (bParam.Source = ValueSources.UserEntered) Then
                bParam.Source = ValueSources.UserEntered
                mSoilCropProperties.KostiakovB_MK = bParam
            End If

            Dim cParam As DoubleParameter = mSoilCropProperties.KostiakovC_MK
            If Not (cParam.Source = ValueSources.UserEntered) Then
                cParam.Source = ValueSources.UserEntered
                mSoilCropProperties.KostiakovC_MK = cParam
            End If

            ' Set Infiltration Method to Modified Kostiakov Formula
            Dim funcParam As IntegerParameter = mSoilCropProperties.InfiltrationFunction
            If Not ((funcParam.Value = InfiltrationFunctions.ModifiedKostiakovFormula) _
                And (funcParam.Source = ValueSources.UserEntered)) Then
                funcParam.Value = InfiltrationFunctions.ModifiedKostiakovFormula
                funcParam.Source = ValueSources.UserEntered
                mSoilCropProperties.InfiltrationFunction = funcParam
            End If

            ' Kostiakov & Branch should not use NRCS Wetted Perimeter
            Dim wpParam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
            If (wpParam.Value = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
                wpParam.Value = WettedPerimeterMethods.FurrowSpacing
                wpParam.Source = DataStore.Globals.ValueSources.Calculated
                mSoilCropProperties.WettedPerimeterMethod = wpParam
            End If

            ' Save new value for Kostiakov k
            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_MK
            If Not ((kParam.Value = mMKostiakovK) _
                And (kParam.Source = ValueSources.Calculated)) Then
                kParam.Value = mMKostiakovK
                kParam.Source = ValueSources.Calculated
                mSoilCropProperties.KostiakovK_MK = kParam
            End If

            ' Save Reference Flow Rate when Modified Kostiakov estimated
            Me.SaveReferenceFlowRate(Qavg)

            ' Calculate & save the Infiltration table
            Me.CalcSaveInfiltrationTable()

        End If

        Return True
    End Function

    '*********************************************************************************************************
    ' Estimate 'Kostiakov k' using Merriam-Keller's algorithm & the Modified Kostiakov equation
    '
    ' Shared function that estimates k using Merriam-Keller algorithm
    '
    ' For furrows, wetted perimeter effects are accounted for by the value of the input parameter Davg.
    '*********************************************************************************************************
    Public Shared Function EstimateModifiedKostiakovK(ByVal opportunityTimes As DataTable, _
                                       ByVal sigmaZ As Double, ByVal Davg As Double, _
                                       ByVal a As Double, ByVal b As Double, ByVal c As Double) As Double

        ' opportunityTimes  - DataTable of Distance / Opportunity Time pairs from start to end of field
        ' sigmaZ            - shape factor for calculations at an advance tip cell
        ' Davg              - average depth of water infiltrated
        ' a                 - Kostiakov a
        ' b                 -     "     b
        ' c                 -     "     c

        Dim k As Double = Double.NaN

        If (DataTableHasData(opportunityTimes)) Then
            If ((DataColumnIsDouble(opportunityTimes, nDistanceX)) _
            And (DataColumnIsDouble(opportunityTimes, nTimeX1))) Then

                Dim numDistances As Integer = opportunityTimes.Rows.Count

                ' Get end point data
                Dim x1 As Double = CDbl(opportunityTimes.Rows(0).Item(nDistanceX))
                Dim time1 As Double = CDbl(opportunityTimes.Rows(0).Item(nTimeX1))
                Dim x2 As Double = CDbl(opportunityTimes.Rows(numDistances - 1).Item(nDistanceX))
                Dim time2 As Double = CDbl(opportunityTimes.Rows(numDistances - 1).Item(nTimeX1))

                Dim L As Double = x2 - x1            ' Field length
                '
                ' Calculate weighted Tn & Tn^a terms for Modified Kostiakov equation
                '
                Dim tn As Double            ' Tn                Time span
                Dim tndxL As Double         ' Tn * dx / L       Weighted time span
                Dim sumTndxL As Double      '                   Sum of weighted time spans

                Dim tnA As Double           ' Tn^a              Kostiakov equation term
                Dim tnAdxL As Double        ' Tn^a * dx / L     Weighted term
                Dim sumTnAdxL As Double     '                   Sum of weighted terms

                For idx As Integer = 1 To numDistances - 1
                    x2 = CDbl(opportunityTimes.Rows(idx).Item(nDistanceX))
                    time2 = CDbl(opportunityTimes.Rows(idx).Item(nTimeX1))

                    ' Delta distance for this cell
                    Dim dx As Double = x2 - x1

                    If (time2 <= 0.0) Then
                        ' Shaped Tn / Tn^a for this tip point
                        tn = time1 * sigmaZ
                        tnA = tn ^ a
                    Else ' (0.0 < time2)
                        ' Average Tn / Tn^a for this cell
                        tn = (time1 + time2) / 2.0
                        tnA = tn ^ a
                    End If

                    ' Weight the values by their distance proportion
                    tndxL = tn * dx / L
                    tnAdxL = tnA * dx / L

                    ' Sum the weighted values
                    sumTndxL += tndxL
                    sumTnAdxL += tnAdxL

                    ' Setup for next iteration
                    x1 = x2
                    time1 = time2
                Next
                '
                '   Modified Kostiakov:    Davg = k * (Tn^a) + (b * Tn) + c
                '
                '   Solved for k:          k = (Davg - c - (b * Tn)) / (Tn^a)
                '
                k = (Davg - c - (b * sumTndxL)) / sumTnAdxL
            End If
        End If

        Return k
    End Function

#End Region

#Region " Branch Function k Estimation "
    '
    ' Calculate estimation for Branch Function k
    '
    Public Function EstimateBranchFunctionK() As Boolean
        '
        ' For the Branch Function infiltration method, Merriam-Keller estimates k using:
        '
        '   Branch Function:        Davg = k * t^a + b * t + c
        '
        '       Davg    - average infiltrated depth based on Border Width or Furrow Wetted Perimeter
        '       t       - calculated from opportunity time table
        '       a       - entered/estimated by user
        '
        Dim Davg As Double = Me.AverageInfiltratedDepth
        Dim Qavg As Double = mInflowManagement.AverageInflowRateForCrossSection

        Dim oppTable As DataTable = mInflowManagement.CalcOpportunityTimes

        Dim a As Double = mSoilCropProperties.KostiakovA_BF.Value
        Dim b As Double = mSoilCropProperties.BranchB_BF.Value
        Dim c As Double = mSoilCropProperties.KostiakovC_BF.Value

        If (mUnit.CrossSection = CrossSections.Furrow) Then
            ' c is always based on Furrow Spacing
            Dim curWP As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value
            If (curWP = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter) Then

                Dim FS As Double = mSystemGeometry.FurrowSpacing.Value
                Dim WP0 As Double = mUnit.UpstreamWettedPerimeter()
                Dim ratio As Double = FS / WP0

                c *= ratio
            End If
        End If

        Dim sigmaZ1 As Double = 1.0 / (1.0 + a)
        Dim sigmaZ2 As Double = 0.5

        If (mSoilCropProperties.BranchTimeSet.Value) Then
            Dim Tb As Double = mSoilCropProperties.BranchTime_BF.Value
            mMKostiakovK = EstimateBranch2K(oppTable, sigmaZ1, sigmaZ2, Davg, a, b, c, Tb)
        Else
            mMKostiakovK = EstimateBranchK(oppTable, sigmaZ1, sigmaZ2, Davg, a, b, c)
        End If

        If (Double.IsNaN(mMKostiakovK)) Then

            If (b <= 0.0) Then
                MsgBox("For the Branch Function, b must be greater than 0.0", _
                        MsgBoxStyle.Exclamation, "Estimation Error")
            Else
                MsgBox("For this Branch Function Estimation, b might be too large", _
                        MsgBoxStyle.Exclamation, "Estimation Error")
            End If

            Return False
        Else

            Dim aParam As DoubleParameter = mSoilCropProperties.KostiakovA_BF
            If Not (aParam.Source = ValueSources.UserEntered) Then
                aParam.Source = ValueSources.UserEntered
                mSoilCropProperties.KostiakovA_BF = aParam
            End If

            Dim bParam As DoubleParameter = mSoilCropProperties.BranchB_BF
            If Not (bParam.Source = ValueSources.UserEntered) Then
                bParam.Source = ValueSources.UserEntered
                mSoilCropProperties.BranchB_BF = bParam
            End If

            Dim cParam As DoubleParameter = mSoilCropProperties.KostiakovC_BF
            If Not (cParam.Source = ValueSources.UserEntered) Then
                cParam.Source = ValueSources.UserEntered
                mSoilCropProperties.KostiakovC_BF = cParam
            End If

            ' Set Infiltration Method to Branch Function
            Dim funcParam As IntegerParameter = mSoilCropProperties.InfiltrationFunction
            If Not ((funcParam.Value = InfiltrationFunctions.BranchFunction) _
                And (funcParam.Source = ValueSources.UserEntered)) Then
                funcParam.Value = InfiltrationFunctions.BranchFunction
                funcParam.Source = ValueSources.UserEntered
                mSoilCropProperties.InfiltrationFunction = funcParam
            End If

            ' Kostiakov & Branch should not use NRCS Wetted Perimeter
            Dim wpParam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
            If (wpParam.Value = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
                wpParam.Value = WettedPerimeterMethods.FurrowSpacing
                wpParam.Source = DataStore.Globals.ValueSources.Calculated
                mSoilCropProperties.WettedPerimeterMethod = wpParam
            End If

            ' Save new value for Kostiakov k
            Dim kParam As KostiakovKParameter = mSoilCropProperties.KostiakovK_BF
            If Not ((kParam.Value = mMKostiakovK) _
                And (kParam.Source = ValueSources.Calculated)) Then
                kParam.Value = mMKostiakovK
                kParam.Source = ValueSources.Calculated
                mSoilCropProperties.KostiakovK_BF = kParam
            End If

            ' Save Reference Flow Rate used when Branch Function calculated
            Me.SaveReferenceFlowRate(Qavg)

            ' Calculate & save the Infiltration table
            Me.CalcSaveInfiltrationTable()

        End If

        Return True
    End Function

    '*********************************************************************************************************
    ' Estimate 'Branch k' using Merriam-Keller's algorithm & the Branch Funciton equation
    '
    ' Shared function that estimates k using Merriam-Keller algorithm.
    '
    ' For furrows, wetted perimeter effects are accounted for by the value of the input parameter Davg.
    '*********************************************************************************************************
    Public Shared Function EstimateBranchK(ByVal opportunityTimes As DataTable, _
                                    ByVal sigmaZ1 As Double, ByVal sigmaZ2 As Double, ByVal Davg As Double, _
                                    ByVal a As Double, ByVal b As Double, ByVal c As Double) As Double

        ' opportunityTimes  - DataTable of Distance / Opportunity Time pairs from start to end of field
        ' sigmaZ1           - shape factor for calculations at an advance tip cell (non-linear term)
        ' sigmaZ2           -   "      "    "        "       "  "    "     "    "  (linear term)
        ' Davg              - average depth of water infiltrated
        ' a                 - Branch a
        ' b                 -    "   b
        ' c                 -    "   c

        Dim k As Double = 0.0

        If (DataTableHasData(opportunityTimes)) Then
            If ((DataColumnIsDouble(opportunityTimes, nDistanceX)) _
            And (DataColumnIsDouble(opportunityTimes, nTimeX1))) Then

                Dim numDistances As Integer = opportunityTimes.Rows.Count

                ' Get end point data
                Dim x1 As Double = CDbl(opportunityTimes.Rows(0).Item(nDistanceX))
                Dim time1 As Double = CDbl(opportunityTimes.Rows(0).Item(nTimeX1))
                Dim x2 As Double = CDbl(opportunityTimes.Rows(numDistances - 1).Item(nDistanceX))
                Dim time2 As Double = CDbl(opportunityTimes.Rows(numDistances - 1).Item(nTimeX1))

                Dim L As Double = x2 - x1                    ' Field length

                Dim tbr1 As Double = 0.0
                Dim tbr2 As Double = DataColumnMax(opportunityTimes, nTimeX1)

                ' Iterate to find Branch Time
                For iter As Integer = 1 To 20

                    ' Next estimate for Branch Time
                    tbr1 = tbr2
                    '
                    ' Calculate the weighted Tn & Tn^a terms for Modified Kostiakov equation
                    '
                    Dim tn As Double = 0.0          ' Tn                    Time for b*t
                    Dim tndxL As Double = 0.0       ' Tn * dx / L           Weighted time
                    Dim sumTndxL As Double = 0.0    '                       Sum of weighted times

                    Dim tnA As Double = 0.0         ' Tn^a                  Time for k*t^a
                    Dim tnAdxL As Double = 0.0      ' Tn^a * dx / L         Weighted time
                    Dim sumTnAdxL As Double = 0.0   '                       Sum of weighted times

                    ' Reset to head of field
                    x1 = CDbl(opportunityTimes.Rows(0).Item(nDistanceX))
                    time1 = CDbl(opportunityTimes.Rows(0).Item(nTimeX1))

                    For idx As Integer = 1 To numDistances - 1
                        x2 = CDbl(opportunityTimes.Rows(idx).Item(nDistanceX))
                        time2 = CDbl(opportunityTimes.Rows(idx).Item(nTimeX1))

                        ' Delta distance for this cell
                        Dim dx As Double = x2 - x1

                        If (time2 <= 0.0) Then

                            ' Shaped Tn / Tn^a for tip point
                            If (time1 <= tbr1) Then
                                ' Time is <= Branch Time
                                tn = 0.0 * sigmaZ2                      ' No time for b*t
                                tnA = (time1 ^ a) * sigmaZ1             ' All time for k*t^a
                            Else ' (tbr < time1)
                                ' Time is > Branch Time
                                tn = (time1 - tbr1) * sigmaZ2           ' Time > Branch Time for b*t
                                tnA = (tbr1 ^ a) * sigmaZ1              ' Branch Time for k*t^a
                            End If

                        Else ' (0.0 < time2)

                            ' Average Tn / Tn^a for cell
                            If (time1 <= tbr1) Then
                                If (time2 <= tbr1) Then
                                    ' time1 <= tbr; time2 <= tbr
                                    tn = 0.0
                                    tnA = (time1 ^ a + time2 ^ a) / 2.0
                                Else
                                    ' time1 <= tbr; tbr < time2
                                    tn = time2 - tbr1
                                    tnA = (time1 ^ a + tbr1 ^ a) / 2.0
                                End If
                            Else
                                If (time2 <= tbr1) Then
                                    ' tbr < time1; time2 <= tbr
                                    tn = time1 - tbr1
                                    tnA = (tbr1 ^ a + time2 ^ a) / 2.0
                                Else
                                    ' tbr < time1; tbr < time2
                                    tn = ((time1 - tbr1) + (time2 - tbr1)) / 2.0
                                    tnA = (tbr1 ^ a + tbr1 ^ a) / 2.0
                                End If
                            End If
                        End If

                        ' Weight the values by their distance proportion
                        tndxL = tn * dx / L
                        tnAdxL = tnA * dx / L

                        ' Sum the weighted values
                        sumTndxL += tndxL
                        sumTnAdxL += tnAdxL

                        ' Setup for next iteration
                        x1 = x2
                        time1 = time2
                    Next
                    '
                    ' Branch Function:  Davg = k*Tn^a + c   then   k*Tb^a + c + b*Tn
                    '
                    ' Solved for k:     k = (Davg - b*t - c) / Tn^a
                    '
                    k = (Davg - (b * sumTndxL) - c) / sumTnAdxL
                    '
                    ' Branch Time:             Where slope of (k*Tb^a + c)  =  slope of (b * Tb)
                    '
                    ' Slope (1st derivative):  a*k * (Tb^(a-1)) = b
                    '
                    ' Solve for Tb:            Tb = (b / (a*k)) ^ (1 / a-1)
                    '
                    tbr2 = (b / (a * k)) ^ (1 / (a - 1))

                    If (Math.Abs(tbr2 - tbr1) <= 1.0) Then
                        ' Found the solution; return it
                        Return k
                    End If
                Next
                ' No solution found; ???
                Return Double.NaN
            End If
        End If

        Return Double.NaN
    End Function

    Public Shared Function EstimateBranch2K(ByVal opportunityTimes As DataTable, _
                                    ByVal sigmaZ1 As Double, ByVal sigmaZ2 As Double, ByVal Davg As Double, _
                                    ByVal a As Double, ByVal b As Double, ByVal c As Double, _
                                    ByVal Tb As Double) As Double

        ' opportunityTimes  - DataTable of Distance / Opportunity Time pairs from start to end of field
        ' sigmaZ1           - shape factor for calculations at an advance tip cell (non-linear term)
        ' sigmaZ2           -   "      "    "        "       "  "    "     "    "  (linear term)
        ' Davg              - average depth of water infiltrated
        ' a                 - Branch a
        ' b                 -    "   b
        ' c                 -    "   c
        ' Tb                - Branch Time

        Dim k As Double = 0.0

        If (DataTableHasData(opportunityTimes)) Then
            If ((DataColumnIsDouble(opportunityTimes, nDistanceX)) _
            And (DataColumnIsDouble(opportunityTimes, nTimeX1))) Then

                Dim numDistances As Integer = opportunityTimes.Rows.Count

                ' Get end point data
                Dim x1 As Double = CDbl(opportunityTimes.Rows(0).Item(nDistanceX))
                Dim time1 As Double = CDbl(opportunityTimes.Rows(0).Item(nTimeX1))
                Dim x2 As Double = CDbl(opportunityTimes.Rows(numDistances - 1).Item(nDistanceX))
                Dim time2 As Double = CDbl(opportunityTimes.Rows(numDistances - 1).Item(nTimeX1))

                Dim L As Double = x2 - x1                    ' Field length
                '
                ' Calculate the weighted Tn & Tn^a terms for Modified Kostiakov equation
                '
                Dim tn As Double = 0.0          ' Tn                    Time for b*t
                Dim tndxL As Double = 0.0       ' Tn * dx / L           Weighted time
                Dim sumTndxL As Double = 0.0    '                       Sum of weighted times

                Dim tnA As Double = 0.0         ' Tn^a                  Time for k*t^a
                Dim tnAdxL As Double = 0.0      ' Tn^a * dx / L         Weighted time
                Dim sumTnAdxL As Double = 0.0   '                       Sum of weighted times

                ' Reset to head of field
                x1 = CDbl(opportunityTimes.Rows(0).Item(nDistanceX))
                time1 = CDbl(opportunityTimes.Rows(0).Item(nTimeX1))

                For idx As Integer = 1 To numDistances - 1
                    x2 = CDbl(opportunityTimes.Rows(idx).Item(nDistanceX))
                    time2 = CDbl(opportunityTimes.Rows(idx).Item(nTimeX1))

                    ' Delta distance for this cell
                    Dim dx As Double = x2 - x1

                    If (time2 <= 0.0) Then

                        ' Shaped Tn / Tn^a for tip point
                        If (time1 <= Tb) Then
                            ' Time is <= Branch Time
                            tn = 0.0 * sigmaZ2                      ' No time for b*t
                            tnA = (time1 ^ a) * sigmaZ1             ' All time for k*t^a
                        Else ' (tbr < time1)
                            ' Time is > Branch Time
                            tn = (time1 - Tb) * sigmaZ2             ' Time > Branch Time for b*t
                            tnA = (Tb ^ a) * sigmaZ1                ' Branch Time for k*t^a
                        End If

                    Else ' (0.0 < time2)

                        ' Average Tn / Tn^a for cell
                        If (time1 <= Tb) Then
                            If (time2 <= Tb) Then
                                ' time1 <= tbr; time2 <= tbr
                                tn = 0.0
                                tnA = (time1 ^ a + time2 ^ a) / 2.0
                            Else
                                ' time1 <= tbr; tbr < time2
                                tn = time2 - Tb
                                tnA = (time1 ^ a + Tb ^ a) / 2.0
                            End If
                        Else
                            If (time2 <= Tb) Then
                                ' tbr < time1; time2 <= tbr
                                tn = time1 - Tb
                                tnA = (Tb ^ a + time2 ^ a) / 2.0
                            Else
                                ' tbr < time1; tbr < time2
                                tn = ((time1 - Tb) + (time2 - Tb)) / 2.0
                                tnA = (Tb ^ a + Tb ^ a) / 2.0
                            End If
                        End If
                    End If

                    ' Weight the values by their distance proportion
                    tndxL = tn * dx / L
                    tnAdxL = tnA * dx / L

                    ' Sum the weighted values
                    sumTndxL += tndxL
                    sumTnAdxL += tnAdxL

                    ' Setup for next iteration
                    x1 = x2
                    time1 = time2
                Next
                '
                ' Branch Function:  Davg = k*Tn^a + c   then   k*Tb^a + c + b*Tn
                '
                ' Solved for k:     k = (Davg - b*t - c) / Tn^a
                '
                k = (Davg - (b * sumTndxL) - c) / sumTnAdxL

                Return k
            End If
        End If

        Return Double.NaN
    End Function

#End Region

#Region " Average Infiltrated Depth "

    '*********************************************************************************************************
    ' Function AverageInfiltratedDepth()
    '*********************************************************************************************************
    Protected Function AverageInfiltratedDepth() As Double
        Dim Davg As Double = mInflowManagement.AverageInfiltratedDepthForField ' Border Width or Furrow Spacing

        If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

            Select Case (mSoilCropProperties.WettedPerimeterMethod.Value)
                Case WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter
                    Dim Qavg As Double = mInflowManagement.AverageInflowRateForCrossSection
                    Dim L As Double = mSystemGeometry.Length.Value
                    Dim FS As Double = mSystemGeometry.FurrowSpacing.Value
                    Dim S0 As Double = mSystemGeometry.AverageSlope

                    Dim WP As Double = Me.UpstreamWettedPerimeter(Qavg, L, FS, S0)

                    Davg *= FS      ' Remove Furrow Spacing effect
                    Davg /= WP      ' Apply Wetted Perimeter effect

                Case WettedPerimeterMethods.FurrowSpacing
                    ' Davg already Furrow Spacing based

                Case Else ' All others are not supported
                    Debug.Assert(False)
            End Select

        End If

        Return Davg
    End Function

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

#Region " Infiltration Table "

    '*********************************************************************************************************
    ' Sub CalcInfiltrationTable()       - Calculate Infiltration Table from Opportunity Times
    ' Sub SaveInfiltrationTable()       - Save Infiltration Table to DataStore
    ' Sub CalcSaveInfiltrationTable()   - Calculate then Saven Infiltration Table
    '*********************************************************************************************************
    Protected Sub CalcInfiltrationTable()

        ' Create new Infiltration Table
        mInfiltrationTable = New DataTable
        mInfiltrationTable.Columns.Add(sDistanceX, GetType(Double))
        mInfiltrationTable.Columns.Add(sInfiltrationX, GetType(Double))
        mInfiltrationTable.TableName = "Infiltrated Depth"

        ' Fill in with calculated distance vs. infiltrated depth rows
        Dim oppTable As DataTable = mInflowManagement.CalcOpportunityTimes
        If (oppTable IsNot Nothing) Then
            For Each oppRow As DataRow In oppTable.Rows
                ' Opportunity Times table is distance vs. opportunity time (Tau)
                Dim dist As Double = CDbl(oppRow.Item(nDistanceX))
                Dim tau As Double = CDbl(oppRow.Item(nTauX))
                ' Calculate infiltrated depth for Tau
                Dim depth As Double = mSoilCropProperties.InfiltrationDepth(tau)
                ' Save new row of distance vs. infiltrated depth 
                Dim infRow As DataRow = mInfiltrationTable.NewRow
                infRow.Item(sDistanceX) = dist
                infRow.Item(sInfiltrationX) = depth
                mInfiltrationTable.Rows.Add(infRow)
            Next oppRow
        End If

    End Sub

    Protected Sub SaveInfiltrationTable()
        Dim infParam As DataTableParameter = mSoilCropProperties.Infiltration
        infParam.Value = mInfiltrationTable
        infParam.Source = ValueSources.Calculated
        mSoilCropProperties.Infiltration = infParam
    End Sub

    Protected Sub CalcSaveInfiltrationTable()
        Me.CalcInfiltrationTable()
        Me.SaveInfiltrationTable()
    End Sub

#End Region

#Region " Opportunity Times Table "

    '*********************************************************************************************************
    ' Function InfiltratedDepth() - Calculate Infiltrated Depth based on Opportunity Times table
    '
    ' Input(s):     OpportunityTimes - table of Distance / Opportunity Times from start to end of field
    '               SigmaZ           - shape factor for calculations at an advance tip cell
    '               k, a, b, c       - Modified Kostiakov infiltration paramters
    '
    ' Returns:      Double           - integral of infiltrated depth over input distance
    '
    ' Note - Wetted Perimeter adjustments must be made by caller
    '*********************************************************************************************************
    Protected Function InfiltratedDepth(ByVal OpportunityTimes As DataTable, _
                                        ByVal SigmaZ As Double, ByVal k As Double, ByVal a As Double, _
                                        ByVal b As Double, ByVal c As Double) As Double
        Dim Z As Double = 0.0

        If (DataTableHasData(OpportunityTimes)) Then
            If ((DataColumnIsDouble(OpportunityTimes, nDistanceX)) _
            And (DataColumnIsDouble(OpportunityTimes, nTimeX1))) Then

                Dim numDistances As Integer = OpportunityTimes.Rows.Count

                ' Get start point data
                Dim x1 As Double = CDbl(OpportunityTimes.Rows(0).Item(nDistanceX))
                Dim t1 As Double = CDbl(OpportunityTimes.Rows(0).Item(nTimeX1))
                '
                ' Calculate Infiltrated Volume using Trapezoid method
                '
                For idx As Integer = 1 To numDistances - 1
                    ' Get end point data
                    Dim x2 As Double = CDbl(OpportunityTimes.Rows(idx).Item(nDistanceX))
                    Dim t2 As Double = CDbl(OpportunityTimes.Rows(idx).Item(nTimeX1))

                    Dim dx As Double = x2 - x1 ' Delta distance across cell

                    ' Average infiltrated depth
                    Dim avgZn As Double = Srfr.SrfrAPI.InfiltrationDepthMK(t1, k, a, b, c)
                    If (0.0 = t2) Then ' Shaped infiltrated depth for tip cell
                        avgZn *= SigmaZ
                    Else ' Average infiltrated depth for interior cell
                        avgZn += Srfr.SrfrAPI.InfiltrationDepthMK(t2, k, a, b, c)
                        avgZn /= 2.0
                    End If

                    Z += dx * avgZn ' Sum individual cell volumes

                    x1 = x2 ' end point becomes start point for next cell
                    t1 = t2
                Next idx

            End If
        End If

        Return Z
    End Function

#End Region

#Region " Volume Balance Table "

    Public Function VolumeBalanceTableForField() As DataTable

        ' Initialize volume balance table
        VolumeBalanceTableForField = New DataTable(mDictionary.tVolumeBalances.Translated)
        mEventCriteria.ResetVolumeBalancesTable(VolumeBalanceTableForField)
        Dim VBrow As DataRow = Nothing

        Try
            ' Get values for Merriam-Keller PIVB
            If (mInflowManagement.RecessionDataAvailable) Then
                Dim recTable As DataTable = mInflowManagement.TabulatedRecession.Value

                Dim piTime As Double = DataColumnMax(recTable, nTimeX1)
                Dim piVin As Double = mInflowManagement.AppliedVolumeForField
                Dim piVy As Double = 0.0
                Dim piVro As Double = mInflowManagement.RunoffVolumeForField

                Dim piVz As Double = piVin - piVro

                ' Move PIVB values to the volume balance table
                VBrow = VolumeBalanceTableForField.NewRow                       ' Point 1
                VBrow.Item(nTimeX) = piTime
                VBrow.Item(sVin) = piVin
                VBrow.Item(sVy) = piVy
                VBrow.Item(sVro) = piVro
                VBrow.Item(sVz) = piVz
                VolumeBalanceTableForField.Rows.Add(VBrow)
            End If

        Catch ex As Exception
        End Try

    End Function

    Public Function VolumeBalanceTableForCrossSection() As DataTable

        ' Initialize volume balance table
        VolumeBalanceTableForCrossSection = New DataTable(mDictionary.tVolumeBalances.Translated)
        mEventCriteria.ResetVolumeBalancesTable(VolumeBalanceTableForCrossSection)
        Dim VBrow As DataRow = Nothing

        Try
            ' Get values for Merriam-Keller PIVB
            If (mInflowManagement.RecessionDataAvailable) Then
                Dim recTable As DataTable = mInflowManagement.TabulatedRecession.Value

                Dim piTime As Double = DataColumnMax(recTable, nTimeX1)
                Dim piVin As Double = mInflowManagement.AppliedVolumeForCrossSection
                Dim piVy As Double = 0.0
                Dim piVro As Double = mInflowManagement.RunoffVolumeForCrossSection

                Dim piVz As Double = piVin - piVro

                ' Move PIVB values to the volume balance table
                VBrow = VolumeBalanceTableForCrossSection.NewRow    ' Point 1
                VBrow.Item(nTimeX) = piTime
                VBrow.Item(sVin) = piVin
                VBrow.Item(sVy) = piVy
                VBrow.Item(sVro) = piVro
                VBrow.Item(sVz) = piVz
                VolumeBalanceTableForCrossSection.Rows.Add(VBrow)
            End If

        Catch ex As Exception
        End Try

    End Function

    Public Overrides Function MeasuredInfiltrationVolumeTable() As DataTable

        ' Define infiltration table
        MeasuredInfiltrationVolumeTable = New DataTable(mDictionary.tMeasuredInfiltration.Translated)
        MeasuredInfiltrationVolumeTable.Columns.Add(sTimeX, GetType(Double))
        MeasuredInfiltrationVolumeTable.Columns.Add(sVz, GetType(Double))

        ' Load its data from the volume balance table (only need T vs. Vz)
        Dim volBalTable As DataTable = Me.VolumeBalanceTableForCrossSection
        If (volBalTable IsNot Nothing) Then
            Dim row As DataRow = MeasuredInfiltrationVolumeTable.NewRow
            row.Item(sTimeX) = volBalTable.Rows(0).Item(nTimeX)
            row.Item(sVz) = volBalTable.Rows(0).Item(sVz)
            MeasuredInfiltrationVolumeTable.Rows.Add(row)
        End If

    End Function

    Public Overrides Function PredictedInfiltrationVolumeTable( _
           Optional ByVal SrfrInfiltration As Srfr.Infiltration = Nothing) As DataTable
        PredictedInfiltrationVolumeTable = Nothing

        If (mInflowManagement.RecessionDataAvailable) Then
            ' Get TL (should be last time in Advance & Recession tables)
            Dim recTable As DataTable = mInflowManagement.TabulatedRecession.Value
            Dim T1 As Double = DataColumnMax(recTable, nTimeX1)

            ' Get total infiltrated volume (PI)
            Dim infiltrationTable As DataTable = mSoilCropProperties.Infiltration.Value
            Dim W As Double = mSystemGeometry.Width.Value
            Dim Vz As Double = mSoilCropProperties.InfiltratedVolume(infiltrationTable) * W

            ' Adjust Infiltrated Volume to per Furrow, if needed
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                Vz /= mSystemGeometry.FurrowsPerSet.Value
            End If

            ' Define infiltration table
            PredictedInfiltrationVolumeTable = New DataTable(mDictionary.tPredictedInfiltration.Translated)
            PredictedInfiltrationVolumeTable.Columns.Add(sTimeX, GetType(Double))
            PredictedInfiltrationVolumeTable.Columns.Add(sVz, GetType(Double))

            ' Only one row (PIVB)
            Dim row1 As DataRow = PredictedInfiltrationVolumeTable.NewRow
            row1.Item(sTimeX) = T1
            row1.Item(sVz) = Vz
            PredictedInfiltrationVolumeTable.Rows.Add(row1)
        End If

    End Function

#End Region

#Region " Error & Warnings "

    '*********************************************************************************************************
    ' Function CheckSetupErrors() - check setup errors for Merriam-Keller Analysis
    ' Function CheckSetupWarnings() - "     "  warnings "     "       "       "
    '*********************************************************************************************************
    Public Overrides Function CheckSetupErrors() As Boolean
        ' Call to overridden baseclass clears previous errors
        Dim hasErrors As Boolean = MyBase.CheckSetupErrors()

        Dim L As Double = mSystemGeometry.Length.Value
        Dim Tco As Double = mInflowManagement.Cutoff

        CheckGeometryErrors()           ' System Geometry

        CheckRoughnessErrors()          ' Soil / Crop Properties
        CheckInfiltrationErrors()

        CheckInflowErrors()             ' Inflow Management
        CheckRunoffErrors()
        CheckAdvanceErrors(L)
        CheckRecessionErrors(0.0, L)

        CheckRunoffAdvanceErrors(L)
        CheckRunoffRecessionErrors(L)

        CheckSolutionModelErrors()      ' Solution Model

        ' Check infiltration calculations
        Dim infiltrationChangedTime As DateTime = mSoilCropProperties.Infiltration.Timestamp

        If ((mUnit.DataHasChangedSince(infiltrationChangedTime)) _
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
        Dim hasWarnings As Boolean = MyBase.CheckSetupWarnings()

        ' Runoff & Advance table times should align
        Dim runoffMeasured As Boolean = mInflowManagement.RunoffMeasured.Value
        Dim advanceMeasured As Boolean = mInflowManagement.AdvanceMeasured.Value
        Dim recessionMeasured As Boolean = mInflowManagement.RecessionMeasured.Value

        If (advanceMeasured And recessionMeasured) Then
            CheckAdvanceRecessionWarnings()
        End If

        hasWarnings = Me.HasSetupWarnings
        Return hasWarnings
    End Function

#End Region

#End Region

End Class
