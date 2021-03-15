
'*************************************************************************************************************
' ctl_EvaluationInfiltration - UI for estimating the Evaluation World's Infiltration parameters
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_EvaluationInfiltration

#Region " Member Data "

    Private mMeasuredVsPredicted As DataSet = Nothing
    Private mMeasuredVzInfiltration As DataTable = Nothing
    Private mPredictedVzInfiltration As DataTable = Nothing

    Private mResizing As Boolean = False

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

    Private mMyStore As DataStore.ObjectNode
    Private mDictionary As Dictionary = Dictionary.Instance

    Private mAnalysis As Analysis = Nothing
    Private mElliotWalker As ElliotWalkerTwoPoint = Nothing
    Private mMerriamKeller As MerriamKeller = Nothing
    Private mEVALUE As EVALUE = Nothing
    '
    ' Access to UI
    '
    Private mEvaluationWorld As EvaluationWorld

    ' Link contained controls to the data store & world window
    Public Sub LinkToModel(ByVal MyUnit As Unit, ByVal MyWindow As EvaluationWorld)

        Debug.Assert(MyUnit IsNot Nothing)
        Debug.Assert(MyWindow IsNot Nothing)

        ' Link this control to its data model and store
        mUnit = MyUnit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mMyStore = mUnit.MyStore

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mEventCriteria = mUnit.EventCriteriaRef

        mSrfrResults = mUnit.SrfrResultsRef

        ' Link this control to its UI & Analysis
        mEvaluationWorld = MyWindow
        If (mEvaluationWorld IsNot Nothing) Then
            mAnalysis = mEvaluationWorld.CurrentAnalysis
        End If

        Me.ResizeUI()
        Me.UpdateUI()

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

    Public Sub SystemGeometry_PropertyChanged(ByVal reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        Me.UpdateUI()
    End Sub

    Public Sub SoilCropProperties_PropertyChanged(ByVal reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        Me.UpdateUI()
    End Sub

    Public Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        Me.UpdateUI()
    End Sub

    Public Sub EventCriteria_PropertyChanged(ByVal reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        Me.UpdateUI()
    End Sub
    '
    ' Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        Me.UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "

    Public Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mEvaluationWorld IsNot Nothing) Then

            If (mEvaluationWorld.ResetingTabs) Then ' Evaluation World is reseting tab pages; wait
                Return
            End If

            ' UI update is dependent on which analysis is selected
            mAnalysis = mEvaluationWorld.CurrentAnalysis
            If (mAnalysis IsNot Nothing) Then

                If (mAnalysis.Running) Then ' don't update UI while analysis is running
                    Return ' misleading UI updates occur
                End If

                mElliotWalker = Nothing
                mMerriamKeller = Nothing
                mEVALUE = Nothing

                If (mAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                    mElliotWalker = DirectCast(mAnalysis, ElliotWalkerTwoPoint)
                ElseIf (mAnalysis.GetType Is GetType(MerriamKeller)) Then
                    mMerriamKeller = DirectCast(mAnalysis, MerriamKeller)
                ElseIf (mAnalysis.GetType Is GetType(EVALUE)) Then
                    mEVALUE = DirectCast(mAnalysis, EVALUE)
                End If

                If (mElliotWalker IsNot Nothing) Then

                    Me.ElliotWalkerControl.LinkToModel(mUnit, mEvaluationWorld, mElliotWalker)

                    Me.EvalueControl.Hide()
                    Me.MerriamKellerControl.Hide()
                    Me.ElliotWalkerControl.Show()
                    Me.ElliotWalkerControl.UpdateUI()

                    Me.UpdateShapeFactors.Visible = True

                ElseIf (mMerriamKeller IsNot Nothing) Then

                    Me.MerriamKellerControl.LinkToModel(mUnit, mEvaluationWorld, mMerriamKeller)

                    Me.EvalueControl.Hide()
                    Me.ElliotWalkerControl.Hide()
                    Me.MerriamKellerControl.Show()
                    Me.MerriamKellerControl.UpdateUI()

                    Me.UpdateShapeFactors.Visible = False

                ElseIf (mEVALUE IsNot Nothing) Then

                    If (mEVALUE.EvalueRunning) Then
                        Return
                    End If

                    Me.EvalueControl.LinkToModel(mUnit, mEvaluationWorld, mEVALUE)

                    Me.ElliotWalkerControl.Hide()
                    Me.MerriamKellerControl.Hide()
                    Me.EvalueControl.Show()
                    Me.EvalueControl.UpdateUI()

                    Dim flowDepthsMeasuredUsed As Boolean = mInflowManagement.FlowDepthsMeasuredAndUsed
                    If (flowDepthsMeasuredUsed) Then
                        Me.UpdateShapeFactors.Visible = False
                    Else
                        Me.UpdateShapeFactors.Visible = True
                    End If

                End If

                Me.UpdateGraphics()
                Me.UpdateInstructions()
            End If
        End If

    End Sub
    '
    ' Update the graphs
    '
    Private Sub UpdateGraphics()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        Try
            If Not (mResizing) Then

                mMeasuredVsPredicted = New DataSet() ' data for graph

                ' Have the specified event analysis compute the infiltration tables
                If (mElliotWalker IsNot Nothing) Then

                    mMeasuredVsPredicted.DataSetName = "Infiltration"

                    mEventCriteria.MeasuredVzInfiltration = mElliotWalker.MeasuredInfiltrationVolumeTable()

                    If (mElliotWalker.ResultsAreValid) Then
                        mEventCriteria.PredictedVzInfiltration = mElliotWalker.PredictedInfiltrationVolumeTable()
                    Else
                        mEventCriteria.PredictedVzInfiltration = Nothing
                    End If

                ElseIf (mMerriamKeller IsNot Nothing) Then

                    mMeasuredVsPredicted.DataSetName = "Infiltration"

                    mEventCriteria.MeasuredVzInfiltration = mMerriamKeller.MeasuredInfiltrationVolumeTable()

                    If (Me.MerriamKellerControl.ResultsAreValid) Then
                        mEventCriteria.PredictedVzInfiltration = mMerriamKeller.PredictedInfiltrationVolumeTable()
                    Else
                        mEventCriteria.PredictedVzInfiltration = Nothing
                    End If

                ElseIf (mEVALUE IsNot Nothing) Then

                    mMeasuredVsPredicted.DataSetName = "Infiltration"

                    Dim VolBalTable As DataTable = mEventCriteria.VolumeBalances.Value
                    mEventCriteria.MeasuredVzInfiltration = mEVALUE.MeasuredInfiltrationVolumeTable(VolBalTable)

                    mEventCriteria.PredictedVzInfiltration = mEVALUE.PredictedInfiltrationVolumeTable()

                End If

                mMeasuredVzInfiltration = mEventCriteria.MeasuredVzInfiltration
                mPredictedVzInfiltration = mEventCriteria.PredictedVzInfiltration

                ' Set name/key information for tables
                If (mMeasuredVzInfiltration IsNot Nothing) Then
                    mMeasuredVzInfiltration.TableName = "Estimated"
                    mMeasuredVzInfiltration.ExtendedProperties.Add("Key", True)
                    mMeasuredVzInfiltration.ExtendedProperties.Add("Key Text", "Volume Balance")
                    mMeasuredVzInfiltration.ExtendedProperties.Add("Symbol", "O")
                    mMeasuredVzInfiltration.ExtendedProperties.Add("Line", True)
                    mMeasuredVzInfiltration.ExtendedProperties.Add("Color", Drawing.Color.Blue)

                    mMeasuredVsPredicted.Tables.Add(mMeasuredVzInfiltration)
                End If

                If (mPredictedVzInfiltration IsNot Nothing) Then
                    mPredictedVzInfiltration.ExtendedProperties.Add("Key", True)
                    mPredictedVzInfiltration.ExtendedProperties.Add("Key Text", "Predicted")
                    mPredictedVzInfiltration.ExtendedProperties.Add("Symbol", "X")
                    mPredictedVzInfiltration.ExtendedProperties.Add("Line", True)
                    mPredictedVzInfiltration.ExtendedProperties.Add("Color", Drawing.Color.DarkOrange)

                    mMeasuredVsPredicted.Tables.Add(mPredictedVzInfiltration)
                End If

            End If ' not resizing

            Dim maxMeasTime As Double = 0.0 ' Maximum times for X-axis
            Dim maxPredTime As Double = 0.0
            Dim maxMeasVol As Double = 0.0  ' Maximum volumes for Y-axis
            Dim maxPredVol As Double = 0.0

            ' Display Measured vs. Predicted Infiltration Graph
            If (mMeasuredVzInfiltration IsNot Nothing) Then
                maxMeasTime = DataStore.Utilities.DataColumnMax(mMeasuredVzInfiltration, nTimeX)
                maxMeasVol = DataStore.Utilities.DataColumnMax(mMeasuredVzInfiltration, nInfiltrationX)
            End If

            If (mPredictedVzInfiltration IsNot Nothing) Then
                maxPredTime = DataStore.Utilities.DataColumnMax(mPredictedVzInfiltration, nTimeX)
                maxPredVol = DataStore.Utilities.DataColumnMax(mPredictedVzInfiltration, nInfiltrationX)
            End If

            Dim maxGraphTime As Double = Math.Max(maxMeasTime, maxPredTime) ' Maximum time for graph (X-axis)
            Dim maxGraphVol As Double = Math.Max(maxMeasVol, maxPredVol)    '    "    volume "   "   (Y-axis)

            ' Determine if, and where, TL and/or Tco vertical lines should be drawn on graph
            Dim TL As Double = mInflowManagement.TL
            Dim Tco As Double = mInflowManagement.Cutoff

            Dim TlPos As Double = Double.NaN
            Dim TcoPos As Double = Double.NaN

            If (Not Double.IsNaN(TL)) Then
                If (TL < maxGraphTime) Then
                    If (TL < maxGraphTime / 2.0) Then ' left half of graph
                        TlPos = 0.15 ' text toward bottom of graph
                    Else ' right half of graph
                        TlPos = 0.85 ' text toward top of graph
                    End If
                ElseIf (TL = maxGraphTime) Then
                    TlPos = 0.9
                End If
            End If

            If (Not Double.IsNaN(Tco)) Then
                If (Tco < maxGraphTime) Then
                    If (Tco < maxGraphTime / 2.0) Then
                        TcoPos = 0.15
                    Else
                        TcoPos = 0.85
                    End If
                ElseIf (Tco = maxGraphTime) Then
                    TcoPos = 0.9
                End If
            End If

            If ((Not Double.IsNaN(TL)) And (Not Double.IsNaN(Tco))) Then
                If (ThisClose(TL, Tco, Srfr.Globals.OneMinute)) Then ' TL & Tco near same time
                    TlPos = 0.15 ' move 'TL' to bottom
                    TcoPos = 0.85 ' move 'Tco' to top
                End If
            End If

            Me.MeasuredVsPredictedGraph.NewHotspotKeys = True
            Me.MeasuredVsPredictedGraph.InitializeGraph2D(mMeasuredVsPredicted)
            Me.MeasuredVsPredictedGraph.UnitsX = Units.Seconds
            Me.MeasuredVsPredictedGraph.UnitsY = Units.CubicMeters
            Me.MeasuredVsPredictedGraph.DisplayKey = True
            Me.MeasuredVsPredictedGraph.HorizontalKeys = True
            Me.MeasuredVsPredictedGraph.FontAdjustment = 1
            Me.MeasuredVsPredictedGraph.TitleAdjY = -5
            Me.MeasuredVsPredictedGraph.LeftTitleAdjX = -5
            Me.MeasuredVsPredictedGraph.BottomTitleAdjY = -5
            Me.MeasuredVsPredictedGraph.ClearVertLines()

            ' Add TL & Tco vertical lines, if on graph
            If (Not Double.IsNaN(TlPos)) Then
                Me.MeasuredVsPredictedGraph.AddVertLine(TL, "TL", TlPos)
            End If

            If (Not Double.IsNaN(TcoPos)) Then
                Me.MeasuredVsPredictedGraph.AddVertLine(Tco, "Tco", TcoPos)
            End If

            If (mEVALUE IsNot Nothing) Then ' Analysis is EVALUE

                Dim SS As Double = Double.NaN
                If ((mMeasuredVzInfiltration IsNot Nothing) And (mPredictedVzInfiltration IsNot Nothing)) Then
                    SS = SumOfSquares(mMeasuredVzInfiltration, mPredictedVzInfiltration, nTimeX, nInfiltrationX)
                End If

                Me.MeasuredVsPredictedGraph.ClearTextLines()
                If (mPredictedVzInfiltration Is Nothing) Then
                    ' Add warning if Predicted Infiltration is not available
                    Me.MeasuredVsPredictedGraph.AddTextLine(maxGraphTime * 0.05, maxGraphVol * 0.95, mDictionary.tNoPredictedInfiltration.ToString, Color.Black)
                    Me.MeasuredVsPredictedGraph.AddTextLine(maxGraphTime * 0.05, maxGraphVol * 0.85, mDictionary.tSeeWarningBelow.ToString, Color.Black)
                ElseIf (Not Double.IsNaN(SS)) Then
                    ' Compute & display sum-of-squares for measured vs. predicted
                    Dim ssText As String = mDictionary.tSumOfSquares.Translated & " = " & Format(SS, "0.00#e+00") ' l²
                    Me.MeasuredVsPredictedGraph.AddTextLine(maxGraphTime * 0.05, maxGraphVol * 0.95, ssText, Color.Black)
                End If

            Else ' Not EVALUE

                ' Add warning if Predicted Infiltration is not available
                Me.MeasuredVsPredictedGraph.ClearTextLines()
                If (mPredictedVzInfiltration Is Nothing) Then
                    Me.MeasuredVsPredictedGraph.AddTextLine(maxGraphTime * 0.05, maxGraphVol * 0.95, mDictionary.tNoPredictedInfiltration.ToString, Color.Black)
                End If

            End If

            Me.MeasuredVsPredictedGraph.DrawImage()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub UpdateInstructions()
        Try

            ' Notes under graph
            EvalueInfiltrationInstructions.Clear()
            EvalueInfiltrationInstructions.SelectionAlignment = HorizontalAlignment.Left

            If (mElliotWalker IsNot Nothing) Then

                AppendLine(EvalueInfiltrationInstructions, mDictionary.tTwoPointInfiltInstruc1.Translated)
                AdvanceLine(EvalueInfiltrationInstructions)
                AppendLine(EvalueInfiltrationInstructions, mDictionary.tTwoPointInfiltInstruc2.Translated)
                '
                ' Verify Time values
                '
                Dim pt2Dist As Double = mInflowManagement.TwoPointDistance2
                Dim pt2Time As Double = mInflowManagement.TwoPointTime2
                Dim cutoff As Double = mInflowManagement.Cutoff

                If (cutoff < pt2Time) Then
                    AdvanceLine(EvalueInfiltrationInstructions)
                    AppendBoldText(EvalueInfiltrationInstructions, mDictionary.tError.Translated & ": ")
                    AppendLine(EvalueInfiltrationInstructions, mDictionary.tPT2TimeGtCutoffDetail.Translated & " (X = " & LengthString(pt2Dist) & ")")
                End If

                AdvanceLine(EvalueInfiltrationInstructions)
                AppendLine(EvalueInfiltrationInstructions, mDictionary.tSelectUpdateShapeFactors.Translated)

            ElseIf (mMerriamKeller IsNot Nothing) Then

                AppendLine(EvalueInfiltrationInstructions, mDictionary.tMkInfiltInstruct1.Translated)
                AdvanceLine(EvalueInfiltrationInstructions)
                AppendLine(EvalueInfiltrationInstructions, mDictionary.tMkInfiltInstruct2.Translated)

            ElseIf (mEVALUE IsNot Nothing) Then

                AppendLine(EvalueInfiltrationInstructions, mDictionary.tEvalueInfiltrationInstructions.Translated)

                If (mInflowManagement.AppliedVolumeForField <= 0.0) Then ' No inflow specified
                    AdvanceLine(EvalueInfiltrationInstructions)
                    AppendBoldText(EvalueInfiltrationInstructions, mDictionary.tError.Translated & " - ")
                    AppendLine(EvalueInfiltrationInstructions, mDictionary.tNoInflowSpecified.Translated)
                End If

                If (Me.UpdateShapeFactors.Visible) Then
                    AdvanceLine(EvalueInfiltrationInstructions)
                    AppendLine(EvalueInfiltrationInstructions, mDictionary.tSelectUpdateShapeFactors.Translated)
                End If

                ' Must have simulation flow depths for depth-dependent infiltration functions
                Dim wpMethod As WettedPerimeterMethods = mSoilCropProperties.WettedPerimeterMethod.Value
                If (wpMethod = WettedPerimeterMethods.LocalWettedPerimeter) Then
                    If (mSrfrResults.StdFlowDepthHydrographs Is Nothing) Then
                        AdvanceLine(EvalueInfiltrationInstructions)
                        AppendBoldText(EvalueInfiltrationInstructions, mDictionary.tWarning.Translated & " - ")
                        AppendText(EvalueInfiltrationInstructions, mDictionary.tFlowDepthsNotAvailable.Translated & "  ")
                        AppendLine(EvalueInfiltrationInstructions, mDictionary.tUseStdToRecalculate.Translated)
                    End If
                End If

            End If

            ' Add "per Furrow" line, if needed
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                If (1 < mSystemGeometry.FurrowsPerSet.Value) Then
                    AdvanceLine(EvalueInfiltrationInstructions)
                    AppendLine(EvalueInfiltrationInstructions, mDictionary.tVolumesPerFurrow.Translated)
                End If
            End If

            ' Check & display for setup errors/warnings
            Dim hasSetupErrors As Boolean = mAnalysis.CheckSetupErrors
            Dim hasSetupWarnings As Boolean = mAnalysis.CheckSetupWarnings

            If (hasSetupErrors) Then
                Dim ifOnlyFuncParamError As Boolean = mAnalysis.HasOnlySetupError(Analysis.ErrorFlags.InfiltrationParameters)
                If Not (ifOnlyFuncParamError) Then
                    AdvanceLine(EvalueInfiltrationInstructions)
                    AppendBoldLine(EvalueInfiltrationInstructions, mDictionary.tErrors.Translated & ":")
                    AppendLine(EvalueInfiltrationInstructions, "  " & mDictionary.tSeeVerifyTabForDetails.Translated)
                End If
            End If

            If (hasSetupWarnings) Then
                AdvanceLine(EvalueInfiltrationInstructions)
                AppendBoldLine(EvalueInfiltrationInstructions, mDictionary.tWarnings.Translated & ":")
                Dim hasVBwarning As Boolean = mAnalysis.HasSetupWarning(Analysis.WarningFlags.VolumeBalanceWarning)
                If (hasVBwarning) Then
                    AppendText(EvalueInfiltrationInstructions, "  " & mDictionary.tCannotCalculatePIVB.Translated)
                End If
                AppendLine(EvalueInfiltrationInstructions, "  " & mDictionary.tSeeVerifyTabForDetails.Translated)
            End If

        Catch ex As Exception
        End Try

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
    End Sub
    '
    ' Resize/relocate UI controls to match available space
    '
    Private Sub ResizeUI()

        ' Resize graph
        Dim ctrlWidth As Integer = Me.Width - Me.ElliotWalkerControl.Width - 8
        Dim ctrlHeight As Integer = Me.Height - 12

        Me.MeasuredVsPredictedGraph.Location = New Point(Me.ElliotWalkerControl.Location.X + Me.ElliotWalkerControl.Width + 2, _
                                                         Me.ElliotWalkerControl.Location.Y + 4)
        Me.MeasuredVsPredictedGraph.Width = ctrlWidth
        Me.MeasuredVsPredictedGraph.Height = ctrlHeight * 3 / 5 - 3

        ' Resize/relocate instructions
        Me.EvalueInfiltrationInstructions.Location = New Point(Me.MeasuredVsPredictedGraph.Location.X, _
                      Me.MeasuredVsPredictedGraph.Location.Y + Me.MeasuredVsPredictedGraph.Height + 3)

        Me.EvalueInfiltrationInstructions.Width = ctrlWidth
        Me.EvalueInfiltrationInstructions.Height = ctrlHeight * 2 / 5

    End Sub

#End Region

#Region " UI Event Handlers "
    '
    ' Handle user request to update Sigma Y & Sigma Z shape factors
    '
    Private Sub UpdateShapeFactors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles UpdateShapeFactors.Click

        If (mEvaluationWorld IsNot Nothing) Then

            Dim eventAnalysis As EventAnalysis = mEvaluationWorld.CurrentAnalysis
            If (eventAnalysis IsNot Nothing) Then

                ' Surface Volume table to update is Analysis dependent
                Dim SurfaceVolumeParam As DataTableParameter = Nothing
                If (eventAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                    SurfaceVolumeParam = mEventCriteria.EW2ptEstimatedSurfaceVolumes
                ElseIf (eventAnalysis.GetType Is GetType(EVALUE)) Then
                    SurfaceVolumeParam = mEventCriteria.EstimatedSurfaceVolumes
                Else
                    Debug.Assert(False, "Support for Analysis must be added")
                    Return
                End If

                eventAnalysis.RunSimulationWithSlope(True)
                Dim srfrIrrigation As Srfr.Irrigation = mEvaluationWorld.SrfrAPI.Irrigation
                If (srfrIrrigation IsNot Nothing) Then

                    Dim SurfaceVolumes As DataTable = SurfaceVolumeParam.Value
                    If (SurfaceVolumes IsNot Nothing) Then

                        Dim undoText As String = UpdateShapeFactors.Text.Replace("&", "")
                        mMyStore.MarkForUndo(undoText)
                        '
                        ' Update Sigma Y values in Surface Bolumes table using values from Simulation
                        '
                        ' AYavgProfile: Col 0 (Time), Col 1(AZavg), Col 2 (Sigma Y)
                        '
                        Dim SyProfile As DataTable = srfrIrrigation.AYavgProfile("Time")

                        ' Update Surface Volumes table with Sigma Y values from Simulation
                        Dim TadvMax As Double = srfrIrrigation.TadvMax ' Simulation's maximum advance time
                        For Each row As DataRow In SurfaceVolumes.Rows
                            Dim T As Double = row.Item(nTimeX)
                            Dim Sy As Double = DataColumnValue(SyProfile, 0, T, 2)

                            ' T for blocked systems must be limited to max Tadv from simulation
                            If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
                                If (TadvMax < T) Then
                                    Sy = DataColumnValue(SyProfile, 0, TadvMax, 2)
                                End If
                            End If

                            row.Item(sSigmaY) = Sy
                        Next row

                        ' Re-calculate dependent values
                        If (eventAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                            mEventCriteria.CalculateEW2ptEstimatedSurfaceVolumes(SurfaceVolumes)
                        ElseIf (eventAnalysis.GetType Is GetType(EVALUE)) Then
                        End If

                        ' Save results
                        SurfaceVolumeParam.Source = ValueSources.Calculated
                        SurfaceVolumeParam.Value = SurfaceVolumes

                        If (eventAnalysis.GetType Is GetType(ElliotWalkerTwoPoint)) Then
                            mEventCriteria.EW2ptEstimatedSurfaceVolumes = SurfaceVolumeParam
                        ElseIf (eventAnalysis.GetType Is GetType(EVALUE)) Then
                            mEventCriteria.EstimatedSurfaceVolumes = SurfaceVolumeParam
                        End If
                        '
                        ' Update Sigma Z values using values from Simulation
                        '
                        ' AZavgProfile: Col 0 (Time), Col 1(AZavg), Col 2 (Sigma Z)
                        '
                        Dim SzProfile As DataTable = srfrIrrigation.AZavgProfile("Time")

                        Dim sigmaZparam As DataTableParameter = mEventCriteria.SimSigmaZtable
                        Dim sigmaZtable As DataTable = sigmaZparam.Value

                        mEventCriteria.ResetSimSigmaZtable(sigmaZtable)

                        ' Generate Sigma Z table based on times from Surface Volumes table
                        For Each row As DataRow In SurfaceVolumes.Rows
                            Dim T As Double = row.Item(nTimeX)
                            Dim Sz As Double = DataColumnValue(SzProfile, 0, T, 2) ' get Sz for time

                            Dim sigmaZrow As DataRow = sigmaZtable.NewRow
                            sigmaZrow.Item(nTimeX) = T
                            sigmaZrow.Item(sSigmaZ) = Sz
                            sigmaZtable.Rows.Add(sigmaZrow)
                        Next row

                        sigmaZparam.Source = ValueSources.Calculated
                        sigmaZparam.Value = sigmaZtable

                        mEventCriteria.SimSigmaZtable = sigmaZparam

                        Dim msg As String = mDictionary.tNewShapeFactorsCalculated.Translated & vbCrLf & vbCrLf
                        msg &= mDictionary.tSeeSurfaceVolumesTab.Translated
                        Dim title As String = mDictionary.tShapeFactors.Translated
                        MsgBox(msg, MsgBoxStyle.Information, title)

                    End If ' (SurfaceVolumes IsNot Nothing)
                End If ' (srfrIrrigation IsNot Nothing)
            End If ' (eventAnalysis IsNot Nothing)
        End If ' (mEvaluationWorld IsNot Nothing)

    End Sub

    ' Resize display when required
    Private Sub ctl_EvalueInfiltration_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        mResizing = True
        Me.ResizeUI()
        Me.UpdateGraphics()
        mResizing = False
    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        Me.ResizeUI()
        Me.UpdateUI()
    End Sub

#End Region

End Class
