
'*************************************************************************************************************
' ctl_Evalue - UI for viewing & editing the EVALUE Predicted Infiltration Estimations
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_Evalue

#Region " Member Data "
    '
    ' Access to EVALUE Analysis
    '
    Private mEVALUE As EVALUE = Nothing

    Private infFuncEditor As InfiltrationFunctionEditor = Nothing
    Private infFuncResult As DialogResult = DialogResult.None

#End Region

#Region " Control / Model Linkage "
    '
    ' Field data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm
    Private WithEvents mWinSRFR As WinSRFR

    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Private WithEvents mEventCriteria As EventCriteria

    Private mSrfrResults As SrfrResults

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    Private mMyStore As DataStore.ObjectNode
    '
    ' Access to UI
    '
    Private mEvaluationWorld As EvaluationWorld
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal MyUnit As Unit, ByVal MyWindow As WorldWindow, _
                           ByVal evalue As EVALUE)

        Debug.Assert(MyUnit IsNot Nothing)

        ' Link this control to its data model and store
        mUnit = MyUnit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mEventCriteria = mUnit.EventCriteriaRef

        mSrfrResults = mUnit.SrfrResultsRef

        mEvaluationWorld = MyWindow
        mEVALUE = evalue

        mMyStore = mUnit.MyStore

        ' Link Wetted Perimeter & Infiltration Equation controls
        StdWettedPerimeterControl.LinkToModel(mMyStore, mSoilCropProperties.WettedPerimeterMethodProperty)
        StdInfiltrationEquationControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationFunctionProperty)

        AdvWettedPerimeterControl.LinkToModel(mMyStore, mSoilCropProperties.WettedPerimeterMethodProperty)
        AdvInfiltrationEquationControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationFunctionProperty)

        Me.RefInflowRateControl.LinkToModel(mMyStore, mEventCriteria.ReferenceFlowRateProperty)

        ' Link Kostiakov Formula UI controls
        Me.KF_aControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_KFProperty)
        Me.KF_kControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovK_KFProperty)

        ' Link Modified Kostiakov UI controls
        Me.MK_aControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_MKProperty)
        Me.MK_bControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovB_MKProperty)
        Me.MK_cControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovC_MKProperty)
        Me.MK_kControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovK_MKProperty)

        ' Link Branch Function UI controls
        Me.BF_aControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_BFProperty)
        Me.BF_bControl.LinkToModel(mMyStore, mSoilCropProperties.BranchB_BFProperty)
        Me.BF_cControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovC_BFProperty)
        Me.BF_kControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovK_BFProperty)
        Me.BF_BranchTimeSet.LinkToModel(mMyStore, mSoilCropProperties.BranchTimeSetProperty)
        Me.BF_BranchTimeControl.LinkToModel(mMyStore, mSoilCropProperties.BranchTime_BFProperty)

        ' Link Time Rated Family UI controls
        Me.TR_InfiltrationTimeControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationTime_TRProperty)

        ' Link Known Characteristic Time UI controls
        Me.KT_InfiltrationDepthControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationDepth_KTProperty)
        Me.KT_InfiltrationTimeControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationTime_KTProperty)
        Me.KT_KostiakovAControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_KTProperty)

        ' Link NRCS Intake Family UI controls
        Me.Sel_005.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family005)
        Me.Sel_010.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family010)
        Me.Sel_015.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family015)
        Me.Sel_020.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family020)
        Me.Sel_025.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family025)
        Me.Sel_030.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family030)
        Me.Sel_035.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family035)
        Me.Sel_040.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family040)
        Me.Sel_045.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family045)
        Me.Sel_050.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family050)
        Me.Sel_060.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family060)
        Me.Sel_070.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family070)
        Me.Sel_080.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family080)
        Me.Sel_090.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family090)
        Me.Sel_100.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family100)
        Me.Sel_150.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family150)
        Me.Sel_200.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family200)
        Me.Sel_300.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family300)
        Me.Sel_400.LinkToModel(mMyStore, mSoilCropProperties.NrcsIntakeFamilyProperty, NrcsIntakeFamilies.Family400)

        ' Link Green-Ampt Function UI controls
        Me.GA_PorosityControl.LinkToModel(mMyStore, mSoilCropProperties.EffectivePorosityGA_Property)
        Me.GA_InitVolWaterContentControl.LinkToModel(mMyStore, mSoilCropProperties.InitialWaterContentGA_Property)
        Me.GA_WettingFrontControl.LinkToModel(mMyStore, mSoilCropProperties.WettingFrontPressureHeadGA_Property)
        Me.GA_HydraulicConductivityControl.LinkToModel(mMyStore, mSoilCropProperties.HydraulicConductivityGA_Property)
        Me.GA_cControl.LinkToModel(mMyStore, mSoilCropProperties.GreenAmptC_Property)

        ' Link Warrick Green-Ampt Function UI controls
        Me.WGA_SatWaterContentControl.LinkToModel(mMyStore, mSoilCropProperties.SaturatedWaterContentWGA_Property)
        Me.WGA_InitWaterContentControl.LinkToModel(mMyStore, mSoilCropProperties.InitialWaterContentWGA_Property)
        Me.WGA_WettingFrontControl.LinkToModel(mMyStore, mSoilCropProperties.WettingFrontPressureHeadWGA_Property)
        Me.WGA_HydraulicConductivityControl.LinkToModel(mMyStore, mSoilCropProperties.HydraulicConductivityWGA_Property)
        Me.WGA_cControl.LinkToModel(mMyStore, mSoilCropProperties.WarrickGreenAmptC_Property)

    End Sub
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated
        Select Case reason
            Case WinSRFR.Reasons.Language
                UpdateLanguage()
            Case WinSRFR.Reasons.UserLevel
                UpdateUI()
        End Select
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mSoilCropProperties Is Nothing) Then
            Return
        End If

        Try
            ' Get current Kostiakov parameter values
            Dim k As Double = mSoilCropProperties.KostiakovK
            Dim a As Double = mSoilCropProperties.KostiakovA
            Dim b As Double = mSoilCropProperties.KostiakovB
            Dim c As Double = mSoilCropProperties.KostiakovC

            Dim kUnits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
            Dim bUnits As Units = mUnitsSystem.FlowRateUnits
            Dim cUnits As Units = mUnitsSystem.DepthUnits

            Dim infFunc As InfiltrationFunctions = _
                CType(mSoilCropProperties.InfiltrationFunction.Value, InfiltrationFunctions)
            '
            ' Show/update selected Standard or Advanced infiltration group
            '
            If (mEventCriteria.AdvFunctionsSelected.Value) Then
                Me.StandardInfiltrationGroup.Hide()
                Me.AdvancedInfiltrationGroup.Show()

                UpdateAdvancedWettedPerimeterMethod()
                UpdateAdvancedInfiltrationEquation()
            Else ' Std functions
                Me.AdvancedInfiltrationGroup.Hide()
                Me.StandardInfiltrationGroup.Show()

                UpdateStandardWettedPerimeterMethod()
                UpdateStandardInfiltrationEquation()
            End If

            Me.CharacteristicTimeBox.Hide()
            Me.NrcsIntakeFamilyGroup.Hide()
            Me.TimeRatedFamilyBox.Hide()
            Me.KostiakovFormulaBox.Hide()
            Me.ModifiedKostiakovBox.Hide()
            Me.BranchFunctionBox.Hide()
            Me.GreenAmptBox.Hide()
            Me.WarrickGreenAmptBox.Hide()

            If (Me.AdvancedInfiltrationGroup.Visible) Then ' Show Advanced infiltration options

                If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

                    ' Show selection infiltration box
                    Select Case infFunc
                        Case InfiltrationFunctions.TimeRatedIntakeFamily
                            Me.TimeRatedFamilyBox.Show()
                        Case InfiltrationFunctions.KostiakovFormula
                            Me.KostiakovFormulaBox.Show()
                        Case InfiltrationFunctions.ModifiedKostiakovFormula
                            Me.ModifiedKostiakovBox.Show()
                        Case InfiltrationFunctions.BranchFunction
                            Me.BranchFunctionBox.Show()

                            If (mSoilCropProperties.BranchTimeSet.Value) Then ' Branch Time is set by user
                                Me.BF_BranchTimeValue.Hide()
                                Me.BF_BranchTimeControl.Show()
                            Else ' Branch Time is calculated
                                Me.BF_BranchTimeControl.Hide()
                                Dim bt As Double = mSoilCropProperties.BranchTime
                                Me.BF_BranchTimeValue.Text = TimeString(bt)
                                Me.BF_BranchTimeValue.Show()
                            End If

                            Me.BF_bControl.CheckError()
                            Me.BF_bControl.UpdateUI()

                        Case InfiltrationFunctions.GreenAmpt, InfiltrationFunctions.WarrickGreenAmpt
                            Me.WarrickGreenAmptBox.Show()
                        Case Else
                            'Debug.Assert(False)
                    End Select

                Else ' Basin/Border
                    ' Green-Ampt is only choice for Basin/Border
                    Me.GreenAmptBox.Show()
                End If

            Else ' Standard Infiltration Group visible

                ' Show selection infiltration box
                Select Case infFunc
                    Case InfiltrationFunctions.CharacteristicInfiltrationTime
                        Me.CharacteristicTimeBox.Show()
                        ' Update Kostiakov k
                        Me.KT_KostiakovK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, kUnits)
                    Case InfiltrationFunctions.NRCSIntakeFamily
                        Me.NrcsIntakeFamilyGroup.Show()
                    Case InfiltrationFunctions.TimeRatedIntakeFamily
                        Me.TimeRatedFamilyBox.Show()
                        ' Update Kostiakov a & k
                        TR_KostiakovA.Text = "a = " + Format(a, "0.00#")
                        TR_KostiakovK.Text = "k = " + KostiakovKParameter.KostiakovKString(k, a, kUnits)
                    Case InfiltrationFunctions.KostiakovFormula
                        Me.KostiakovFormulaBox.Show()
                    Case InfiltrationFunctions.ModifiedKostiakovFormula
                        Me.ModifiedKostiakovBox.Show()
                    Case InfiltrationFunctions.BranchFunction
                        Me.BranchFunctionBox.Show()

                        If (mSoilCropProperties.BranchTimeSet.Value) Then ' Branch Time is set by user
                            Me.BF_BranchTimeValue.Hide()
                            Me.BF_BranchTimeControl.Show()
                        Else ' Branch Time is calculated
                            Me.BF_BranchTimeControl.Hide()
                            Dim bt As Double = mSoilCropProperties.BranchTime
                            Me.BF_BranchTimeValue.Text = TimeString(bt)
                            Me.BF_BranchTimeValue.Show()
                        End If

                        Me.BF_bControl.CheckError()
                        Me.BF_bControl.UpdateUI()
                    Case Else
                        'Debug.Assert(False)
                End Select

                If (WinSRFR.UserLevel = UserLevels.Standard) Then
                    Me.NrcsOptionsButton.Hide()
                Else
                    Me.NrcsOptionsButton.Show()
                End If

                If (mSrfrResults.StdFlowDepthHydrographs Is Nothing) Then
                    Me.ShowAdvancedFunctions.Enabled = False
                Else
                    Me.ShowAdvancedFunctions.Enabled = True
                End If
            End If

            ' Reference Inflow is a Research level option
            If (WinSRFR.UserLevel = UserLevels.Research) Then
                RefInflowPanel.Show()
            Else
                RefInflowPanel.Hide()
            End If

        Catch ex As Exception
        End Try

    End Sub
    '
    ' Update display of Wetted Perimeter Method
    '
    Private Sub UpdateStandardWettedPerimeterMethod()

        If (mEVALUE IsNot Nothing) Then
            ' Wetted Perimeter only applies to Furrows
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

                ' EVALUE Analysis determines what items are in the Wetted Perimeter list
                mEVALUE.LoadWettedPerimeterControl(StdWettedPerimeterControl)

                StdWettedPerimeterLabel.Show()
                StdWettedPerimeterControl.UpdateUI()
                StdWettedPerimeterControl.Show()

            Else ' Basin / Border

                ' No Wetted Perimeter for Basin/Border
                Me.StdWettedPerimeterLabel.Hide()
                Me.StdWettedPerimeterControl.Hide()

            End If
        End If

    End Sub

    Private Sub UpdateAdvancedWettedPerimeterMethod()

        If (mEVALUE IsNot Nothing) Then
            ' Wetted Perimeter only applies to Furrows
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

                ' EVALUE Analysis determines what items are in the Wetted Perimeter list
                mEVALUE.LoadWettedPerimeterControl(AdvWettedPerimeterControl)

                AdvWettedPerimeterLabel.Show()
                AdvWettedPerimeterControl.UpdateUI()
                AdvWettedPerimeterControl.Show()

            Else ' Basin / Border

                ' No Wetted Perimeter for Basin/Border
                Me.AdvWettedPerimeterLabel.Hide()
                Me.AdvWettedPerimeterControl.Hide()

            End If
        End If

    End Sub
    '
    ' Update the Infiltration Equation selection list & selection
    '
    Private Sub UpdateStandardInfiltrationEquation()
        ' EVALUE Analysis determines what items are in the Infiltration Equation list
        If (mEVALUE IsNot Nothing) Then
            mEVALUE.LoadInfiltrationEquationControl(StdInfiltrationEquationControl)
            StdInfiltrationEquationControl.UpdateUI()
        End If
    End Sub

    Private Sub UpdateAdvancedInfiltrationEquation()
        ' EVALUE Analysis determines what items are in the Infiltration Equation list
        If (mEVALUE IsNot Nothing) Then
            mEVALUE.LoadInfiltrationEquationControl(AdvInfiltrationEquationControl)
            AdvInfiltrationEquationControl.UpdateUI()
        End If
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " Standard / Advanced Option "
    '
    ' Handle the switch between Standard vs. Advanced Infiltration Functions
    '
    Private Sub ShowStandardFunctions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowStandardFunctions.Click

        Dim undoText As String = ShowStandardFunctions.Text.Replace("&", "")
        mMyStore.MarkForUndo(undoText)
        '
        ' Set both Infiltration Function & Wetted Perimeter Method to their Standard values
        '
        Dim stdInfFunc As InfiltrationFunctions = mEventCriteria.StdInfiltrationFunction.Value
        Dim stdWpMethod As WettedPerimeterMethods = mEventCriteria.StdWettedPerimeterMethod.Value

        mSoilCropProperties.MyStore.EventsEnabled = False ' disable events to minimize UI updates

        Dim intParam As IntegerParameter = mSoilCropProperties.InfiltrationFunction
        intParam.Value = stdInfFunc
        intParam.Source = ValueSources.UserEntered
        mSoilCropProperties.InfiltrationFunction = intParam

        intParam = mSoilCropProperties.WettedPerimeterMethod
        intParam.Value = stdWpMethod
        intParam.Source = ValueSources.UserEntered
        mSoilCropProperties.WettedPerimeterMethod = intParam

        mSoilCropProperties.MyStore.EventsEnabled = True ' re-enable events

        Dim boolParam As BooleanParameter = mEventCriteria.AdvFunctionsSelected
        boolParam.Value = False
        boolParam.Source = ValueSources.UserEntered
        mEventCriteria.AdvFunctionsSelected = boolParam

    End Sub

    Private Sub ShowAdvancedFunctions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowAdvancedFunctions.Click

        Dim undoText As String = ShowAdvancedFunctions.Text.Replace("&", "")
        mMyStore.MarkForUndo(undoText)

        mSoilCropProperties.MyStore.EventsEnabled = False ' disable events to minimize UI updates
        mEventCriteria.MyStore.EventsEnabled = False
        '
        ' Save the Standard Wetted Perimeter
        '
        Dim stdWpMethod As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value

        Dim intParam As IntegerParameter = mEventCriteria.StdWettedPerimeterMethod
        intParam.Value = stdWpMethod
        intParam.Source = ValueSources.UserEntered
        mEventCriteria.StdWettedPerimeterMethod = intParam
        '
        ' Set both Infiltration Function & Wetted Perimeter Method to their Advanced values
        '
        Dim advInfFunc As InfiltrationFunctions = mEventCriteria.AdvInfiltrationFunction.Value
        Dim advWpMethod As WettedPerimeterMethods = WettedPerimeterMethods.LocalWettedPerimeter

        intParam = mSoilCropProperties.InfiltrationFunction
        intParam.Value = advInfFunc
        intParam.Source = ValueSources.UserEntered
        mSoilCropProperties.InfiltrationFunction = intParam

        intParam = mSoilCropProperties.WettedPerimeterMethod
        intParam.Value = advWpMethod
        intParam.Source = ValueSources.UserEntered
        mSoilCropProperties.WettedPerimeterMethod = intParam

        mSoilCropProperties.MyStore.EventsEnabled = True ' re-enable events
        mEventCriteria.MyStore.EventsEnabled = True

        Dim boolParam As BooleanParameter = mEventCriteria.AdvFunctionsSelected
        boolParam.Value = True
        boolParam.Source = ValueSources.UserEntered
        mEventCriteria.AdvFunctionsSelected = boolParam

        mMyStore.ClearUndoRedo()

    End Sub

#End Region

#Region " Wetted Perimeter Control Event Handlers "

    Private Sub StdWettedPerimeterControl_ControlValueChanged() _
    Handles StdWettedPerimeterControl.ControlValueChanged
        Dim WPparam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
        Dim WPmethod As WettedPerimeterMethods = WPparam.Value

        Dim IEparam As IntegerParameter = mSoilCropProperties.InfiltrationFunction

        Select Case (WPmethod)

            Case WettedPerimeterMethods.LocalWettedPerimeter
                ' Must be Kostiakov, Branch, Time-Rated or Warrick/Green-Ampt
                If ((IEparam.Value = InfiltrationFunctions.KostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.BranchFunction) _
                 Or (IEparam.Value = InfiltrationFunctions.TimeRatedIntakeFamily) _
                 Or (IEparam.Value = InfiltrationFunctions.WarrickGreenAmpt)) Then
                    IEparam.Value = mSoilCropProperties.InfiltrationFunction.Value
                Else
                    IEparam.Value = InfiltrationFunctions.WarrickGreenAmpt
                End If

            Case WettedPerimeterMethods.NrcsEmpiricalFunction
                ' Only choice is NRCS
                IEparam.Value = InfiltrationFunctions.NRCSIntakeFamily

            Case WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter
                ' Must be Kostiakov, Branch or Time-Rated
                If ((IEparam.Value = InfiltrationFunctions.KostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.BranchFunction) _
                 Or (IEparam.Value = InfiltrationFunctions.TimeRatedIntakeFamily)) Then
                    IEparam.Value = mSoilCropProperties.InfiltrationFunction.Value
                Else
                    IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula
                End If

            Case Else ' Assume WettedPerimeterMethods.FurrowSpacing
                ' Must be Kostiakov, Branch or Characteristic
                If ((IEparam.Value = InfiltrationFunctions.KostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.BranchFunction) _
                 Or (IEparam.Value = InfiltrationFunctions.CharacteristicInfiltrationTime)) Then
                    IEparam.Value = mSoilCropProperties.InfiltrationFunction.Value
                Else
                    IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula
                End If


        End Select

        If Not (IEparam.Value = mSoilCropProperties.InfiltrationFunction.Value) Then
            IEparam.Source = ValueSources.Calculated
            mSoilCropProperties.InfiltrationFunction = IEparam
            mSoilCropProperties.InfiltrationFunctionProperty.RecordCommand()
        End If

    End Sub

#End Region

#Region " NRCS Option "

    Private Sub NrcsOptionsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NrcsOptionsButton.Click

        Dim db As NrcsIntakeFamilyOptions = New NrcsIntakeFamilyOptions(mSoilCropProperties)

        UpdateTranslation(db, mWinSRFR.Language)

        Dim _result As DialogResult = DialogResult.OK
        _result = db.ShowDialog

        If (_result = DialogResult.OK) Then

            Dim method As IntegerParameter = mSoilCropProperties.NrcsToKostiakovMethod

            If Not (method.Value = db.NrcsToKostiakovMethod) Then

                ' Mark current state as an Undo point
                mMyStore.MarkForUndo(mDictionary.tNrcsOptionChange.Translated)

                ' Set the new value
                method.Value = db.NrcsToKostiakovMethod
                method.Source = DataStore.Globals.ValueSources.UserEntered
                mSoilCropProperties.NrcsToKostiakovMethod = method

            End If
        End If
    End Sub

#End Region

#Region " Match Function Editor "

    Private Sub UseInfiltrationEditorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles UseInfiltrationEditorButton.Click

        ' Instantiate Infiltration Function Editor, link it to WinSRFR objects; then display it
        infFuncEditor = New InfiltrationFunctionEditor(InfiltrationFunctionEditor.MatchTypes.MatchVolumes)
        infFuncEditor.WinSrfrAnalysis = mEVALUE
        infFuncEditor.WinSrfrUnit = mUnit

        Dim meLoc As Point = Me.PointToScreen(New Point(0, 0))

        meLoc.X -= infFuncEditor.Width + 16
        meLoc.X = Math.Max(8, meLoc.X)

        meLoc.Y -= (infFuncEditor.Height - Me.Height) / 2

        infFuncEditor.Location = meLoc

        infFuncResult = infFuncEditor.ShowDialog()

    End Sub

#End Region

#Region " Misc. "
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    Private Sub GreenAmptHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StdInfiltrationHelp.Click
        '
        ' Green-Ampt vs. Warrick Green-Ampt is cross section dependent
        '
        Dim Instructions As TextViewer = New TextViewer()
        Dim msg As ErrorRichTextBox = Instructions.ErrorRichTextBox
        Dim type As String = "Green-Ampt "
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            type = "Warrick Green-Ampt "
        End If

        Instructions.Text = type & mDictionary.tEstimationInstructions.Translated
        AppendBoldLine(msg, Instructions.Text)

        AdvanceLine(msg)
        AppendLine(msg, "Estimation of these parameters is a two step process:")
        AdvanceLine(msg)
        AppendBoldText(msg, "Step 1:  ")
        AppendText(msg, "Approximate the flow depth hydrographs required for " & type)

        AppendLine(msg, "parameter estimation using one of the standard infiltration functions.")
        AdvanceLine(msg)
        AppendText(msg, "After verifying the results, return to the Infiltration tab to estimate the ")
        AppendLine(msg, type & "parameter(s).")

        AdvanceLine(msg)
        AppendBoldText(msg, "Step 2:  ")
        AppendLine(msg, "Adjust the selected " & type & "parameter to match the Infiltration curves.")
        AdvanceLine(msg)
        AppendLine(msg, "Verify the " & type & "results.")

        Instructions.Show()
    End Sub

#End Region

#End Region

End Class
