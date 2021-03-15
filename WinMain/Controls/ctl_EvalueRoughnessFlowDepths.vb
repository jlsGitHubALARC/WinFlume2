
'*************************************************************************************************************
' ctl_EvalueRoughnessFlowDepths - Estimate EVALUE Roughness Estimations using Surface Flow Depths
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_EvalueRoughnessFlowDepths

#Region " Member Data "

    ' Misc
    Private mMsgDisplayed As Boolean = False
    Private mRunning As Boolean = False

#End Region

#Region " Control / Model Linkage "
    '
    ' Link to model objects and update UI with its data
    '
    Private mUnit As Unit = Nothing
    Private mWorld As World = Nothing
    Private mField As Field = Nothing
    Private mFarm As Farm = Nothing
    Private WithEvents mWinSRFR As WinSRFR = Nothing

    Private WithEvents mSoilCropProperties As SoilCropProperties = Nothing
    Private WithEvents mInflowManagement As InflowManagement = Nothing
    Private WithEvents mEventCriteria As EventCriteria = Nothing

    Private mSurfaceFlow As SurfaceFlow = Nothing

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mUserPreferences As UserPreferences = UserPreferences.Instance

    Private mDictionary As Dictionary = Dictionary.Instance

    Private mMyStore As DataStore.ObjectNode = Nothing

    Private mAnalysis As Analysis
    Private mEVALUE As EVALUE
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow)

        Debug.Assert((_unit IsNot Nothing), "Unit is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        mSurfaceFlow = mUnit.SurfaceFlowRef

        mWorldWindow = worldWindow

        mAnalysis = mWorldWindow.CurrentAnalysis
        If (mAnalysis IsNot Nothing) Then
            If (mAnalysis.GetType Is GetType(EVALUE)) Then
                mEVALUE = DirectCast(mAnalysis, EVALUE)
            End If
        End If

        mMyStore = mUnit.MyStore

        ' Link contained controls to their models & store
        Me.RoughnessMethodControl.LinkToModel(mMyStore, mSoilCropProperties.RoughnessMethodProperty)

        Me.Sel_004.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.BareSoil)
        Me.Sel_010.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.SmallGrain)
        Me.Sel_015.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.AlfalfaMintBroadcast)
        Me.Sel_020.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.AlfalfaDenseOrLong)
        Me.Sel_025.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.DenseSodCrops)
        Me.Sel_UserEntered.LinkToModel(mMyStore, mSoilCropProperties.NrcsSuggestedManningNProperty, NrcsSuggestedManningN.UserEntered)

        Me.UsersManningNControl.LinkToModel(mMyStore, mSoilCropProperties.UsersManningNProperty)
        Me.ManningCnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningCnProperty)
        Me.ManningAnControl.LinkToModel(mMyStore, mSoilCropProperties.ManningAnProperty)
        Me.SayreChiControl.LinkToModel(mMyStore, mSoilCropProperties.SayreChiProperty)

        mMsgDisplayed = False

        ' Update language translation
        UpdateLanguage()

        UpdateUI()

    End Sub
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated
        Select Case reason
            Case WinSRFR.Reasons.Language
                UpdateLanguage()
        End Select
    End Sub
    '
    ' Update UI when referenced DataStore values change
    '
    Public Sub SoilCropProperties_PropertyChanged(ByVal _reason As SoilCropProperties.Reasons) _
     Handles mSoilCropProperties.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub EventCriteria_PropertyChanged(ByVal reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        If Not (mRunning) Then
            UpdateRoughnessMethod()
            UpdateNrcsSuggestedManningN()

            UpdateGraphics()
            UpdateInstructions()
        End If

    End Sub
    '
    ' Resize the UI to allow easier viewing
    '
    Private Sub ResizeUI()

        ' Adjust left-side controls to match new size
        Me.RoughnessBox.Width = Me.Width / 2 - 8

        Dim x As Integer = Me.RoughnessBox.Location.X + Me.RoughnessBox.Width / 2 - Me.CalibrateHydrographs.Width / 2
        Dim y As Integer = Me.CalibrateHydrographs.Location.Y
        Dim loc As Point = New Point(x, y)

        Me.CalibrateHydrographs.Location = loc

        x = Me.RoughnessBox.Location.X
        y = Me.CalibrateHydrographs.Location.Y + Me.CalibrateHydrographs.Height + 4
        loc = New Point(x, y)

        Me.GoodnessOfFitGraph.Width = Me.RoughnessBox.Width
        Me.GoodnessOfFitGraph.Height = Me.Height - y - 4
        Me.GoodnessOfFitGraph.Location = loc

        ' Adjust right-side controls to match new size
        Me.EvalueRoughnessInstructions.Width = Me.Width / 2 - 8

        x = Me.Width - Me.EvalueRoughnessInstructions.Width - 8
        y = Me.Height - Me.EvalueRoughnessInstructions.Height - 4
        loc = New Point(x, y)

        Me.EvalueRoughnessInstructions.Location = loc

        x = Me.EvalueRoughnessInstructions.Location.X
        y = Me.RoughnessBox.Location.Y
        loc = New Point(x, y)

        Me.FlowDepthHydrographs.Width = Me.EvalueRoughnessInstructions.Width
        Me.FlowDepthHydrographs.Height = Me.Height - Me.EvalueRoughnessInstructions.Height - 16
        Me.FlowDepthHydrographs.Location = loc

        Me.UpdateUI()

    End Sub
    '
    ' Update the Roughness Method selection list & selection
    '
    Private Sub UpdateRoughnessMethod()

        ' Update selection list
        Dim roughnessMethod As RoughnessMethods = mSoilCropProperties.RoughnessMethod.Value
        Dim _sel As String = String.Empty
        Dim _idx As Integer = 0

        RoughnessMethodControl.Clear()

        Dim _selOk As Boolean = mSoilCropProperties.GetFirstRoughnessMethodSelection(_sel)
        While Not (_sel Is Nothing)
            If (_selOk) Then
                RoughnessMethodControl.Add(_sel, _idx, True)
            ElseIf (roughnessMethod = _idx) Then
                RoughnessMethodControl.Add(_sel, _idx, False)
            End If
            _selOk = mSoilCropProperties.GetNextRoughnessMethodSelection(_sel)
            _idx += 1
        End While

        ' Update selection
        RoughnessMethodControl.UpdateUI()

        ' Hide / Show correspnding UI panels & photos
        Select Case (roughnessMethod)
            Case RoughnessMethods.SayreAlbertson
                NrcsManningNPanel.Hide()
                ManningCnAnPanel.Hide()
                SayreChiPanel.Show()

            Case RoughnessMethods.ManningCnAn
                NrcsManningNPanel.Hide()
                SayreChiPanel.Hide()
                ManningCnAnPanel.Show()

            Case Else ' Assume RoughnessMethods.NrcsSuggestedManningN
                ManningCnAnPanel.Hide()
                SayreChiPanel.Hide()
                NrcsManningNPanel.Show()
        End Select

    End Sub
    '
    ' Update which NRCS Manning N is checked
    '
    Private Sub UpdateNrcsSuggestedManningN()
        Select Case mSoilCropProperties.NrcsSuggestedManningN.Value
            Case NrcsSuggestedManningN.BareSoil
                Sel_004.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.SmallGrain
                Sel_010.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.AlfalfaMintBroadcast
                Sel_015.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.AlfalfaDenseOrLong
                Sel_020.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.DenseSodCrops
                Sel_025.Checked = True
                Me.UsersManningNControl.Enabled = False
            Case NrcsSuggestedManningN.UserEntered
                Sel_UserEntered.Checked = True
                Me.UsersManningNControl.Enabled = True
        End Select
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " Graphics Update Methods "
    '
    ' Update the graphs
    '
    Public Sub UpdateGraphics()
        If (mWorldWindow IsNot Nothing) Then ' Evaluation World window is up
            If Not (mRunning) Then
                UpdateGoodnessOfFitGraph()
                UpdateFlowDepthHydrographs()
            End If
        End If
    End Sub

    Private Sub UpdateGoodnessOfFitGraph()

        Try ' catch but ignore exceptions drawing graphs

            Dim gofTable As DataTable = Nothing

            Dim gofMethod As GoodnessOfFitMethods = mEventCriteria.GoodnessOfFitMethod.Value
            If (gofMethod = GoodnessOfFitMethods.PercentBias) Then

                Dim pbiasParam As DataTableParameter = mEventCriteria.PBiasCurves
                If (pbiasParam IsNot Nothing) Then
                    Dim pbiasTable3 As DataTable = pbiasParam.Value
                    If (DataTableHasData(pbiasTable3)) Then ' PBIAS curve available; graph it
                        gofTable = pbiasTable3.Copy
                        gofTable.ExtendedProperties.Add("LeftAxisTitle", "PBIAS (%)")
                    End If
                End If

            Else ' Assume NSE

                Dim nseParam As DataTableParameter = mEventCriteria.NseCurves
                If (nseParam IsNot Nothing) Then
                    Dim nseTable3 As DataTable = nseParam.Value
                    If (DataTableHasData(nseTable3)) Then ' NSE curve available; graph it
                        gofTable = nseTable3.Copy
                        gofTable.ExtendedProperties.Add("LeftAxisTitle", "NSE")
                    End If
                End If

            End If

            If (gofTable IsNot Nothing) Then ' PBIAS | NSE curve available for graphing

                ' Set curve graphing properties
                gofTable.ExtendedProperties.Add("Symbol", "O")
                gofTable.ExtendedProperties.Add("Fill O", True)
                gofTable.ExtendedProperties.Add("Line", True)

                ' Remove undefined curved
                Dim gofRow As DataRow = gofTable.Rows(0)
                For rdx As Integer = gofTable.Columns.Count - 1 To 1 Step -1
                    If (gofRow.Item(rdx).GetType Is GetType(DBNull)) Then
                        gofTable.Columns.RemoveAt(rdx)
                    End If
                Next rdx

                ' Set graph key properties
                For cdx As Integer = 1 To gofTable.Columns.Count - 1
                    Dim gofCol As DataColumn = gofTable.Columns(cdx)
                    Dim colName As String = gofCol.ColumnName
                    gofCol.ExtendedProperties.Add("Key", True)
                    gofCol.ExtendedProperties.Add("Key Text", colName)
                    gofCol.ExtendedProperties.Add("Symbol", "O")
                    gofCol.ExtendedProperties.Add("Line", True)
                Next cdx

                ' grf_XYGraph uses a DataSet; load curve's DataTable into one
                Dim setName As String = gofTable.TableName
                Dim spcIdx As Integer = setName.LastIndexOf(" ")
                If (-1 < spcIdx) Then ' change last " " to "  " so names are unique
                    setName = setName.Substring(0, spcIdx) & " " & setName.Substring(spcIdx)
                End If

                Dim gofDataSet As DataSet = New DataSet(setName)
                gofDataSet.Tables.Add(gofTable)

                Me.GoodnessOfFitGraph.NewHotspotKeys = True
                Me.GoodnessOfFitGraph.InitializeGraph2D(gofDataSet)
                Me.GoodnessOfFitGraph.UnitsX = Units.Meters
                Me.GoodnessOfFitGraph.UnitsY = Units.None
                Me.GoodnessOfFitGraph.Name = mDictionary.tGoodnessOfFit.Translated
                Me.GoodnessOfFitGraph.DisplayKey = True
                Me.GoodnessOfFitGraph.HorizontalKeys = True
                Me.GoodnessOfFitGraph.ClearVertLines()
                Me.GoodnessOfFitGraph.DrawImage()
                Me.GoodnessOfFitGraph.Show()

            Else
                Me.GoodnessOfFitGraph.Hide()
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub UpdateFlowDepthHydrographs()

        Try ' catch but ignore exceptions drawing graphs

            Dim depthHydrographs As DataSet = Nothing

            Dim StationDepthHydrographs As DataSet = mInflowManagement.StationsFlowDepths.Value
            Dim SimDepthHydrographs As DataSet = mEventCriteria.SimFlowDepthsRoughness.Value

            If ((StationDepthHydrographs IsNot Nothing) And (SimDepthHydrographs IsNot Nothing)) Then

                depthHydrographs = New DataSet()
                depthHydrographs.DataSetName = mDictionary.tFlowDepthHydrographs.Translated

                Dim sdx As Integer = 0
                For Each stationHydro As DataTable In StationDepthHydrographs.Tables

                    Dim staHydroCopy As DataTable = stationHydro.Copy
                    staHydroCopy.ExtendedProperties.Add("Color", mUserPreferences.ColorN(sdx + 1))
                    staHydroCopy.ExtendedProperties.Add("Symbol", "o")
                    staHydroCopy.ExtendedProperties.Add("Line", True)

                    Dim staDist As Double = CDbl(staHydroCopy.ExtendedProperties.Item(sDistanceX))

                    staHydroCopy.ExtendedProperties.Add("Key", True)
                    Dim distText As String = "X=" & LengthString(staDist)
                    staHydroCopy.ExtendedProperties.Add("Key Text", distText)

                    depthHydrographs.Tables.Add(staHydroCopy)

                    Dim pbiasCurves As DataTable = mEventCriteria.PBiasCurves.Value

                    If (DataTableHasData(pbiasCurves)) Then
                        If (sdx < SimDepthHydrographs.Tables.Count) Then
                            Dim simHydro As DataTable = SimDepthHydrographs.Tables(sdx).Copy
                            simHydro.TableName = "Simulation at " & LengthString(staDist)
                            simHydro.ExtendedProperties.Add("Color", mUserPreferences.ColorN(sdx + 1))
                            simHydro.ExtendedProperties.Add("Key2", True) ' pair with "KEY" curve

                            depthHydrographs.Tables.Add(simHydro)
                        End If
                    End If

                    sdx += 1
                Next stationHydro
            End If

            If (depthHydrographs IsNot Nothing) Then
                Me.FlowDepthHydrographs.InitializeGraph2D(depthHydrographs)
                Me.FlowDepthHydrographs.UnitsX = Units.Seconds
                Me.FlowDepthHydrographs.UnitsY = Units.Millimeters
                Me.FlowDepthHydrographs.Name = depthHydrographs.DataSetName
                Me.FlowDepthHydrographs.DisplayKey = True
                Me.FlowDepthHydrographs.HorizontalKeys = True
                Me.FlowDepthHydrographs.CurveControlIsOn = True
                Me.FlowDepthHydrographs.DrawImage()
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub UpdateInstructions()
        Try
            If Not (mRunning) Then
                EvalueRoughnessInstructions.Clear()
                EvalueRoughnessInstructions.SelectionAlignment = HorizontalAlignment.Left

                Dim srfrIrrigation As Srfr.Irrigation = mWorldWindow.SrfrAPI.Irrigation
                If (srfrIrrigation IsNot Nothing) Then ' Simulation results available
                    AppendText(EvalueRoughnessInstructions, mDictionary.tEvalueRoughnessFlowDepthsInstructionsWithSim.Translated)
                    AppendText(EvalueRoughnessInstructions, " ")

                    If (mEventCriteria.GoodnessOfFitMethod.Value = GoodnessOfFitMethods.PercentBias) Then
                        AppendLine(EvalueRoughnessInstructions, mDictionary.tEvalueRoughnessPercentBias.Translated)
                    Else ' Assume Nash-Sutcliffe
                        AppendLine(EvalueRoughnessInstructions, mDictionary.tEvalueRoughnessNashSutcliffe.Translated)
                    End If

                Else ' No simulation results
                    AppendLine(EvalueRoughnessInstructions, mDictionary.tEvalueRoughnessFlowDepthsInstructionsNoSim.Translated)
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' Manning N should track NRCS Suggested Manning N
    '
    Private Sub RoughnessMethodControl_ControlValueChanged() _
    Handles RoughnessMethodControl.ControlValueChanged
        If (mSoilCropProperties IsNot Nothing) Then
            If (mSoilCropProperties.RoughnessMethod.Value = RoughnessMethods.NrcsSuggestedManningN) Then
                Dim _suggested As NrcsSuggestedManningN = mSoilCropProperties.NrcsSuggestedManningN.Value
                SetNrcsManningN(_suggested)
            End If
        End If
    End Sub

#End Region

#Region " UI Event Handlers "
    '
    ' Update NRCS Manning N selection
    '
    Private Sub SetNrcsManningN(ByVal _suggested As NrcsSuggestedManningN)
        If (mSoilCropProperties IsNot Nothing) Then
            mMyStore.MarkForUndo(mDictionary.tSelectNrcsFamily.Translated)
            Dim _double As DoubleParameter = mSoilCropProperties.ManningN
            If (_suggested = NrcsSuggestedManningN.UserEntered) Then
                _double.Value = mSoilCropProperties.UsersManningN.Value
            Else
                _double.Value = NrcsSuggestedManningNValues(_suggested)
            End If
            _double.Source = DataStore.Globals.ValueSources.UserEntered
            mSoilCropProperties.ManningN = _double
        End If
    End Sub

    Private Sub Sel_004_ControlValueChanged() Handles Sel_004.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.BareSoil)
    End Sub

    Private Sub Sel_010_ControlValueChanged() Handles Sel_010.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.SmallGrain)
    End Sub

    Private Sub Sel_015_ControlValueChanged() Handles Sel_015.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.AlfalfaMintBroadcast)
    End Sub

    Private Sub Sel_020_ControlValueChanged() Handles Sel_020.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.AlfalfaDenseOrLong)
    End Sub

    Private Sub Sel_025_ControlValueChanged() Handles Sel_025.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.DenseSodCrops)
    End Sub

    Private Sub Sel_UserEntered_ControlValueChanged() Handles Sel_UserEntered.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.UserEntered)
    End Sub

    Private Sub UserManningNControl_ControlValueChanged() Handles UsersManningNControl.ControlValueChanged
        SetNrcsManningN(NrcsSuggestedManningN.UserEntered)
    End Sub
    '
    ' Resize contained controls when this control's size changes
    '
    Private Sub ctl_EvalueRoughness_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        ResizeUI()
        UpdateGraphics()
    End Sub
    '
    ' Run a Simulation to compare the resulting Flow Depth Hydrographs
    '
    Private Sub CompareDepthHydrographs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CalibrateHydrographs.Click
        If (mEVALUE IsNot Nothing) Then

            ' Verify user has completed estimation of Infitration parameter
            If Not (mMsgDisplayed) Then
                mMsgDisplayed = True
                Dim title As String = CalibrateHydrographs.Text
                title = title.Replace("&", "")
                Dim msg As String = mDictionary.tRefineSyNote1.Translated & Chr(10) & Chr(10)
                msg &= mDictionary.tRefineSyNote2.Translated
                Dim msgResult As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                If (msgResult = MsgBoxResult.No) Then
                    Return
                End If
            End If

            mRunning = True

            Dim sayreChiParam As DoubleParameter = mSoilCropProperties.SayreChi
            Dim chiRangeParam As DoubleParameter = mSoilCropProperties.ChiRange
            Dim manningParam As DoubleParameter = mSoilCropProperties.ManningN
            Dim nRangeParam As DoubleParameter = mSoilCropProperties.ManningRange

            Dim db As RoughnessGoodnessOfFit = New RoughnessGoodnessOfFit(mWorldWindow)
            db.RoughnessMethod = mSoilCropProperties.RoughnessMethod.Value
            db.GoodnessOfFitMethod = mEventCriteria.GoodnessOfFitMethod.Value
            db.Chi = sayreChiParam.Value
            db.ChiRange = chiRangeParam.Value
            db.ManningN = manningParam.Value
            db.ManningNRange = nRangeParam.Value

            Dim dbResult As DialogResult = db.ShowDialog
            If (dbResult = DialogResult.OK) Then
                '
                ' Check for update of roughness parameter
                '
                Select Case db.RoughnessMethod

                    Case RoughnessMethods.SayreAlbertson
                        If Not (sayreChiParam.Value = db.Chi) Then
                            mMyStore.MarkForUndo("Update Chi && Depth Hydrographs")

                            sayreChiParam.Source = ValueSources.UserEntered
                            sayreChiParam.Value = db.Chi
                            mSoilCropProperties.SayreChi = sayreChiParam
                        Else
                            mMyStore.MarkForUndo("Update Depth Hydrographs")
                        End If

                        If Not (chiRangeParam.Value = db.ChiRange) Then
                            chiRangeParam.Source = ValueSources.UserEntered
                            chiRangeParam.Value = db.ChiRange
                            mSoilCropProperties.ChiRange = chiRangeParam
                        End If

                    Case Else ' Manning n
                        If Not (manningParam.Value = db.ManningN) Then ' Manning n changed
                            mMyStore.MarkForUndo("Update Manning n && Depth Hydrographs")

                            Dim userManningParam As DoubleParameter = mSoilCropProperties.UsersManningN
                            userManningParam.Source = ValueSources.UserEntered
                            userManningParam.Value = db.ManningN
                            mSoilCropProperties.UsersManningN = userManningParam

                            manningParam.Source = ValueSources.UserEntered
                            manningParam.Value = db.ManningN
                            mSoilCropProperties.ManningN = manningParam
                        Else
                            mMyStore.MarkForUndo("Update Depth Hydrographs")
                        End If

                        If Not (nRangeParam.Value = db.ManningNRange) Then
                            nRangeParam.Source = ValueSources.UserEntered
                            nRangeParam.Value = db.ManningNRange
                            mSoilCropProperties.ManningRange = nRangeParam
                        End If
                End Select
                '
                ' Get Goodness of Fit selection & curves
                '
                Dim gofParam As IntegerParameter = mEventCriteria.GoodnessOfFitMethod
                gofParam.Source = ValueSources.UserEntered
                gofParam.Value = db.GoodnessOfFitMethod
                mEventCriteria.GoodnessOfFitMethod = gofParam

                Dim pbiasParam As DataTableParameter = mEventCriteria.PBiasCurves
                pbiasParam.Source = ValueSources.UserEntered
                pbiasParam.Value = db.PbiasCurves.Copy
                mEventCriteria.PBiasCurves = pbiasParam

                Dim nseParam As DataTableParameter = mEventCriteria.NseCurves
                nseParam.Source = ValueSources.UserEntered
                nseParam.Value = db.NseCurves.Copy
                mEventCriteria.NseCurves = nseParam
                '
                ' Get set of simulation Flow Depth Hydrographs used to estimate roughness
                '
                Dim srfrIrrigation As Srfr.Irrigation = mWorldWindow.SrfrAPI.Irrigation
                If (srfrIrrigation IsNot Nothing) Then

                    Dim StationsTable As DataTable = mInflowManagement.MeasurementStations.Value
                    If (StationsTable IsNot Nothing) Then

                        Dim stationCount As Integer = StationsTable.Rows.Count
                        Dim simFlowDepthParam As DataSetParameter = mEventCriteria.SimFlowDepthsRoughness
                        Dim simFlowDepthSet As DataSet = simFlowDepthParam.Value
                        mEventCriteria.ResetSimFlowDepthsRoughness(simFlowDepthSet)

                        ' Get one simulation Flow Depth Hydrograph for every Station
                        For sdx As Integer = 0 To stationCount - 1

                            ' Get Station's location
                            Dim advRow As DataRow = StationsTable.Rows(sdx)
                            Dim staDist As Double = advRow.Item(sDistanceX)
                            Dim tableName As String = "Y @ " & LengthString(staDist)

                            ' Get/save matching Flow Depth Hydrograph for Simulation
                            Dim simHydro As DataTable = srfrIrrigation.Hydrographs("Y", staDist)
                            simHydro.TableName = tableName

                            simFlowDepthSet.Tables.Add(simHydro)

                        Next sdx

                        simFlowDepthParam.Value = simFlowDepthSet
                        simFlowDepthParam.Source = ValueSources.Calculated
                        mEventCriteria.SimFlowDepthsRoughness = simFlowDepthParam

                    End If ' (StationsTable IsNot Nothing)
                End If ' (srfrIrrigation IsNot Nothing)
            End If ' (dbResult = DialogResult.OK)
        End If

        mRunning = False
        UpdateUI()
    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

End Class
