
'*************************************************************************************************************
' ctl_VolumeBalances - UI for viewing & editing Volume Balance times
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI
Imports PrintingUI

Public Class ctl_VolumeBalances

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

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    Private mMyStore As DataStore.ObjectNode

    Private mAnalysis As Analysis = Nothing
    '
    ' Access to UI & Analysis
    '
    Private mEvaluationWorld As EvaluationWorld
    '
    ' Data for calculated Volume Balance tables
    '
    Private mEWvolumeBalanceTable As DataTable = New DataTable(sVolumeBalance)
    Private mEWvolumeBalanceParameter As DataTableParameter = New DataTableParameter(mEWvolumeBalanceTable)
    Private mEWvolumeBalanceProperty As PropertyNode = New PropertyNode

    Private mMKvolumeBalanceTable As DataTable = New DataTable(sVolumeBalance)
    Private mMKvolumeBalanceParameter As DataTableParameter = New DataTableParameter(mMKvolumeBalanceTable)
    Private mMKvolumeBalanceProperty As PropertyNode = New PropertyNode
    '
    ' Establish links to model objects and update UI with the model data
    '
    Public Sub LinkToModel(ByVal MyUnit As Unit, ByVal MyWindow As EvaluationWorld)

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

        mEvaluationWorld = MyWindow

        If (mEvaluationWorld IsNot Nothing) Then
            mAnalysis = mEvaluationWorld.CurrentAnalysis
        End If

        mMyStore = mUnit.MyStore

        ' Link contained controls to their data models
        mEWvolumeBalanceProperty.EventsEnabled = False
        mEWvolumeBalanceProperty.SetParameter(mEWvolumeBalanceParameter)
        Me.ElliotWalkerVolumeBalanceTable.LinkToModel(Nothing, mEWvolumeBalanceProperty)
        Me.ElliotWalkerVolumeBalanceTable.MinRows = 2 ' Two and only two rows for Elliott-Walker 2-Pt
        Me.ElliotWalkerVolumeBalanceTable.MaxRows = 2
        Me.ElliotWalkerVolumeBalanceTable.ReadonlyColumn(sTimeX) = True
        Me.ElliotWalkerVolumeBalanceTable.ReadonlyColumn(sVin) = True
        Me.ElliotWalkerVolumeBalanceTable.ReadonlyColumn(sVy) = True
        Me.ElliotWalkerVolumeBalanceTable.ReadonlyColumn(sVro) = True
        Me.ElliotWalkerVolumeBalanceTable.ReadonlyColumn(sVz) = True

        mMKvolumeBalanceProperty.EventsEnabled = False
        mMKvolumeBalanceProperty.SetParameter(mMKvolumeBalanceParameter)
        Me.MerriamKellerVolumeBalanceTable.LinkToModel(Nothing, mMKvolumeBalanceProperty)
        Me.MerriamKellerVolumeBalanceTable.MinRows = 1 ' One and only One rows for Merriam-Keller
        Me.MerriamKellerVolumeBalanceTable.MaxRows = 1
        Me.MerriamKellerVolumeBalanceTable.ReadonlyColumn(sTimeX) = True
        Me.MerriamKellerVolumeBalanceTable.ReadonlyColumn(sVin) = True
        Me.MerriamKellerVolumeBalanceTable.ReadonlyColumn(sVy) = True
        Me.MerriamKellerVolumeBalanceTable.ReadonlyColumn(sVro) = True
        Me.MerriamKellerVolumeBalanceTable.ReadonlyColumn(sVz) = True

        Me.EvalueVolumeBalanceTable.LinkToModel(mMyStore, mEventCriteria.VolumeBalancesProperty)
        ' Rows can be added/deleted for EVALUE (user chooses Times)
        Me.EvalueVolumeBalanceTable.ReadonlyColumn(sVin) = True
        Me.EvalueVolumeBalanceTable.ReadonlyColumn(sVy) = True
        Me.EvalueVolumeBalanceTable.ReadonlyColumn(sVro) = True
        Me.EvalueVolumeBalanceTable.ReadonlyColumn(sVz) = True

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
    ' Update UI when Data Store changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub SoilCropPropertiesPropertyChanged(ByVal reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub EventCriteriaPropertyChanged(ByVal reason As EventCriteria.Reasons) _
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
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        Try
            ' Update world & analysis to current
            If (mEvaluationWorld IsNot Nothing) Then

                If (mEvaluationWorld.ResetingTabs) Then ' Evaluation World is reseting tab pages; wait
                    Return
                End If

                mAnalysis = mEvaluationWorld.CurrentAnalysis
            End If

            ' Volume Table caption
            Dim caption As String = mDictionary.tVolumeBalance.Translated
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                If (1 < mSystemGeometry.FurrowsPerSet.Value) Then
                    caption &= " - " & mDictionary.tPerFurrow.Translated
                End If
            End If

            ' Display appropriate analysis control
            Select Case (mEventCriteria.EventAnalysisType.Value)
                Case EventAnalysisTypes.TwoPointAnalysis
                    Me.MerriamKellerBox.Hide()
                    Me.EvalueBox.Hide()
                    Me.ElliotWalkerBox.Show()
                    '
                    ' The Elliott-Walker 2-Point Volume Balance table is for informational
                    ' purposes only (i.e. read-only); recalculate its content every time.
                    '
                    Dim ew As ElliotWalkerTwoPoint = DirectCast(mAnalysis, ElliotWalkerTwoPoint)

                    mEWvolumeBalanceTable = ew.VolumeBalanceTable

                    mEventCriteria.CalculateVolumeBalances(mEWvolumeBalanceTable)

                    If (mEWvolumeBalanceParameter Is Nothing) Then
                        mEWvolumeBalanceParameter = New DataTableParameter(mEWvolumeBalanceTable)
                    Else
                        mEWvolumeBalanceParameter.Value = mEWvolumeBalanceTable
                    End If

                    Me.ElliotWalkerVolumeBalanceTable.CaptionText = caption
                    Me.ElliotWalkerVolumeBalanceTable.UpdateUI()

                Case EventAnalysisTypes.MerriamKellerAnalysis
                    Me.ElliotWalkerBox.Hide()
                    Me.EvalueBox.Hide()
                    Me.MerriamKellerBox.Show()
                    '
                    ' The Merriam-Keller Volume Balance table is for informational
                    ' purposes only (i.e. read-only); recalculate its content every time.
                    '
                    Dim mk As MerriamKeller = DirectCast(mAnalysis, MerriamKeller)

                    mMKvolumeBalanceTable = mk.VolumeBalanceTableForCrossSection

                    If (mMKvolumeBalanceParameter Is Nothing) Then
                        mMKvolumeBalanceParameter = New DataTableParameter(mMKvolumeBalanceTable)
                    Else
                        mMKvolumeBalanceParameter.Value = mMKvolumeBalanceTable
                    End If

                    Me.MerriamKellerVolumeBalanceTable.CaptionText = caption
                    Me.MerriamKellerVolumeBalanceTable.UpdateUI()

                Case EventAnalysisTypes.EvalueAnalysis
                    Me.ElliotWalkerBox.Hide()
                    Me.MerriamKellerBox.Hide()
                    Me.EvalueBox.Show()
                    '
                    ' The EVALUE Volume Balance table is interactive, WinSRFR can suggest times
                    ' and the user can add/delete times.
                    '
                    Dim evalue As EVALUE = DirectCast(mAnalysis, EVALUE)

                    Me.EvalueVolumeBalanceTable.CaptionText = caption
                    Me.EvalueVolumeBalanceTable.UpdateUI()

            End Select

            UpdateGraphics()
            UpdateInstructions()

        Catch ex As Exception
        End Try

    End Sub
    '
    ' Resize the UI to allow easier viewing
    '
    Private Sub ResizeUI()

        ' Elliott-Walker two-point control
        Me.ElliotWalkerBox.Height = Me.Height - 8
        Me.ElliotWalkerNotes.Height = Me.ElliotWalkerBox.Height - Me.ElliotWalkerNotes.Location.Y - 8

        ' Merriam-Keller control
        Me.MerriamKellerBox.Height = Me.Height - 8
        Me.MerriamKellerNotes.Height = Me.MerriamKellerBox.Height - Me.MerriamKellerNotes.Location.Y - 8

        ' EVALUE control
        Me.EvalueBox.Height = Me.Height - 8
        Me.EvalueVolumeBalanceTable.Height = Me.EvalueBox.Height - Me.EvalueVolumeBalanceTable.Location.Y - 4

        ' Adjust contained controls to match new size
        Dim ctrlWidth As Integer = Me.Width - Me.EvalueBox.Width - 12

        Me.HydraulicSummaryTitle.Width = ctrlWidth

        Me.MassBalanceTimesGraph.Height = Me.Height * 5 / 8
        Me.MassBalanceTimesGraph.Width = ctrlWidth
        Me.MassBalanceTimesGraph.DrawImage()

        Me.VolumeBalanceNotes.Location = New Point(Me.VolumeBalanceNotes.Location.X, _
                                                   Me.MassBalanceTimesGraph.Height + 8)
        Me.VolumeBalanceNotes.Height = Me.EvalueBox.Height - Me.MassBalanceTimesGraph.Height
        Me.VolumeBalanceNotes.Height -= Me.HydraulicSummaryTitle.Height - 4
        Me.VolumeBalanceNotes.Width = ctrlWidth

    End Sub
    '
    ' Update the graphs
    '
    Private Sub UpdateGraphics()

        Try
            '
            ' Advance / Recession sub-graph
            '
            Dim advRec As DataSet = New DataSet(" Advance ")

            If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                Dim advTable As DataTable = mInflowManagement.TwoPointTabulatedAdvance.Value
                advRec.Tables.Add(advTable)
            Else
                Dim advTable As DataTable = mInflowManagement.TabulatedAdvance.Value
                advRec.Tables.Add(advTable)
                If (mInflowManagement.RecessionDataAvailable) Then ' User enter recession data
                    advRec.DataSetName = mDictionary.tAdvance.Translated & " / " & mDictionary.tRecession.Translated
                    Dim recTable As DataTable = mInflowManagement.TabulatedRecession.Value
                    advRec.Tables.Add(recTable)
                End If
            End If

            Me.MassBalanceTimesGraph.AdvanceRecession = advRec
            Me.MassBalanceTimesGraph.Length = mSystemGeometry.Length.Value
            '
            ' Inflow sub-graph
            '
            Dim Qin As DataTable = mInflowManagement.InflowTableForCrossSection
            If (Qin IsNot Nothing) Then
                '
                ' Reverse the columns in the Qin table
                '
                ' The Inflow Management columns are T then Q
                ' The Surface Flow graph requires Q then T
                ' 
                Dim Qrev As DataTable = New DataTable("Qin")

                Qrev.Columns.Add(sQinX, GetType(Double))
                Qrev.Columns.Add(sTimeX, GetType(Double))

                For Each inRow As DataRow In Qin.Rows
                    Dim revRow As DataRow = Qrev.NewRow
                    revRow.Item(sQinX) = inRow.Item(sInflowX)
                    revRow.Item(sTimeX) = inRow.Item(sTimeX)
                    Qrev.Rows.Add(revRow)
                Next inRow

                Dim inflow As DataSet = New DataSet("Inflow")
                inflow.Tables.Add(Qrev)

                Me.MassBalanceTimesGraph.Inflow = inflow
            End If
            '
            ' Runoff sub-graph
            '
            Dim Qout As DataTable = mInflowManagement.RunoffTableForCrossSection
            If (Qout IsNot Nothing) Then
                '
                ' Reverse the columns in the Qout table
                '
                ' The Inflow Management columns are T then Q
                ' The Surface Flow graph requires Q then T
                ' 
                Dim Qrev As DataTable = New DataTable("Qout")

                Qrev.Columns.Add(sRunoffX, GetType(Double))
                Qrev.Columns.Add(sTimeX, GetType(Double))

                For Each inRow As DataRow In Qout.Rows
                    Dim revRow As DataRow = Qrev.NewRow
                    revRow.Item(sRunoffX) = inRow.Item(sRunoffX)
                    revRow.Item(sTimeX) = inRow.Item(sTimeX)
                    Qrev.Rows.Add(revRow)
                Next inRow

                Dim runoff As DataSet = New DataSet("Runoff")
                runoff.Tables.Add(Qrev)

                Me.MassBalanceTimesGraph.Runoff = runoff
            End If
            '
            ' Add Volume Balance time lines
            '
            Me.MassBalanceTimesGraph.ClearTimeLines()
            Dim timeLine As Double
            Select Case (mEventCriteria.EventAnalysisType.Value)

                Case EventAnalysisTypes.TwoPointAnalysis

                    For Each row As DataRow In mEWvolumeBalanceTable.Rows
                        timeLine = row.Item(sTimeX)
                        Me.MassBalanceTimesGraph.AddTimeLine(timeLine)
                    Next row

                    Me.MassBalanceTimesGraph.HighlightLine = Me.ElliotWalkerVolumeBalanceTable.RowSelected

                Case EventAnalysisTypes.MerriamKellerAnalysis

                    For Each row As DataRow In mMKvolumeBalanceTable.Rows
                        timeLine = row.Item(sTimeX)
                        Me.MassBalanceTimesGraph.AddTimeLine(timeLine)
                    Next row

                    Me.MassBalanceTimesGraph.HighlightLine = Me.MerriamKellerVolumeBalanceTable.RowSelected

                Case EventAnalysisTypes.EvalueAnalysis

                    For Each row As DataRow In mEventCriteria.VolumeBalances.Value.Rows
                        timeLine = row.Item(sTimeX)
                        Me.MassBalanceTimesGraph.AddTimeLine(timeLine)
                    Next row

                    Me.MassBalanceTimesGraph.HighlightLine = Me.EvalueVolumeBalanceTable.RowSelected
            End Select

            ' Draw the graph
            Me.MassBalanceTimesGraph.DrawImage()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub UpdateInstructions()
        Try
            ' Start Notes under graph
            VolumeBalanceNotes.Clear()
            VolumeBalanceNotes.SelectionAlignment = HorizontalAlignment.Left

            AppendLine(VolumeBalanceNotes, mDictionary.tVbGraphNotes.Translated)
            AdvanceLine(VolumeBalanceNotes)

            Select Case (mEventCriteria.EventAnalysisType.Value)

                Case EventAnalysisTypes.TwoPointAnalysis

                    ' Update Notes under Elliott-Walker table
                    ElliotWalkerNotes.Clear()
                    ElliotWalkerNotes.SelectionAlignment = HorizontalAlignment.Left

                    AdvanceLine(ElliotWalkerNotes)
                    ElliotWalkerNotes.SelectionAlignment = HorizontalAlignment.Center
                    AppendBoldLine(ElliotWalkerNotes, "Vz = Vin - Vy")
                    ElliotWalkerNotes.SelectionAlignment = HorizontalAlignment.Left

                Case EventAnalysisTypes.MerriamKellerAnalysis

                    ' Update Notes under Merriam-Keller table
                    MerriamKellerNotes.Clear()
                    MerriamKellerNotes.SelectionAlignment = HorizontalAlignment.Left

                    AdvanceLine(MerriamKellerNotes)
                    MerriamKellerNotes.SelectionAlignment = HorizontalAlignment.Center
                    AppendBoldLine(MerriamKellerNotes, "Vz = Vin - Vro")
                    MerriamKellerNotes.SelectionAlignment = HorizontalAlignment.Left

                Case EventAnalysisTypes.EvalueAnalysis

                    ' Additional Notes under graph for EVALUE
                    If (mInflowManagement.AppliedVolumeForField <= 0.0) Then ' No inflow specified
                        AppendBoldText(VolumeBalanceNotes, mDictionary.tError.Translated & " - ")
                        AppendLine(VolumeBalanceNotes, mDictionary.tNoInflowSpecified.Translated)
                        AdvanceLine(VolumeBalanceNotes)
                    Else
                        AppendLine(VolumeBalanceNotes, mDictionary.tVolumeBalanceData.Translated & ":")
                        AppendText(VolumeBalanceNotes, "   ")
                        AppendBoldText(VolumeBalanceNotes, mDictionary.tInflow.Translated)

                        If (mInflowManagement.AdvanceDataAvailable) Then ' Advance has been measured & entered
                            AppendText(VolumeBalanceNotes, ", ")
                            AppendBoldText(VolumeBalanceNotes, mDictionary.tAdvance.Translated)
                        End If

                        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then

                            If (mInflowManagement.RunoffDataAvailable) Then ' Runoff has been measured & entered
                                If (mInflowManagement.RunoffUsed.Value) Then ' User said to use it for VB calculations
                                    AppendText(VolumeBalanceNotes, ", ")
                                    AppendBoldText(VolumeBalanceNotes, mDictionary.tRunoff.Translated)

                                    If (mInflowManagement.RecessionDataAvailable) Then ' Recession has been measured & entered
                                        If (mInflowManagement.RecessionUsed.Value) Then ' User said to use it for VB calculations
                                            AppendText(VolumeBalanceNotes, ", ")
                                            AppendBoldText(VolumeBalanceNotes, mDictionary.tRecession.Translated)
                                        End If
                                    End If
                                End If
                            End If

                        Else ' Blocked End

                            If (mInflowManagement.RecessionDataAvailable) Then ' Recession has been measured & entered
                                If (mInflowManagement.RecessionUsed.Value) Then ' User said to use it for VB calculations
                                    AppendText(VolumeBalanceNotes, ", ")
                                    AppendBoldText(VolumeBalanceNotes, mDictionary.tRecession.Translated)
                                End If
                            End If

                        End If

                        If (mInflowManagement.FlowDepthsMeasuredAndUsed) Then
                            AppendText(VolumeBalanceNotes, ", ")
                            AppendBoldText(VolumeBalanceNotes, mDictionary.tFlowDepths.Translated)
                        End If

                        AdvanceLine(VolumeBalanceNotes)
                    End If

            End Select

            ' Ad "per Furrow" line, if needed
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then
                If (1 < mSystemGeometry.FurrowsPerSet.Value) Then
                    AdvanceLine(VolumeBalanceNotes)
                    AppendLine(VolumeBalanceNotes, mDictionary.tQinRunoffPerFurrow.Translated)
                End If
            End If

            ' Check & display setup errors/warnings
            Dim hasSetupErrors As Boolean = mAnalysis.CheckSetupErrors
            Dim hasSetupWarnings As Boolean = mAnalysis.CheckSetupWarnings

            If (hasSetupErrors) Then
                Dim ifOnlyFuncParamError As Boolean = mAnalysis.HasOnlySetupError(Analysis.ErrorFlags.InfiltrationParameters)
                If Not (ifOnlyFuncParamError) Then
                    AdvanceLine(VolumeBalanceNotes)
                    AppendBoldLine(VolumeBalanceNotes, mDictionary.tErrors.Translated & ":")
                    AppendLine(VolumeBalanceNotes, "  " & mDictionary.tSeeVerifyTabForDetails.Translated)
                End If
            End If

            If (hasSetupWarnings) Then
                AdvanceLine(VolumeBalanceNotes)
                AppendBoldLine(VolumeBalanceNotes, mDictionary.tWarnings.Translated & ":")
                Dim hasVBwarning As Boolean = mAnalysis.HasSetupWarning(Analysis.WarningFlags.VolumeBalanceWarning)
                If (hasVBwarning) Then
                    AppendText(VolumeBalanceNotes, "  " & mDictionary.tCannotCalculatePIVB.Translated)
                End If
                AppendLine(VolumeBalanceNotes, "  " & mDictionary.tSeeVerifyTabForDetails.Translated)
            End If

        Catch ex As Exception
        End Try

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " Data Store Event Handlers "
    '
    ' EVALUE Volume Balance DataTable
    '
    ' Pre-Save Action - After a change to a user value within the Volume Balance table, but
    '                   before the table is saved, the calculated values must be updated.
    '
    Private Sub EvalueVolumeBalanceTable_PreSaveAction(ByVal VolumeBalances As DataTable, ByRef SaveOK As Boolean) _
    Handles EvalueVolumeBalanceTable.PreSaveAction
        SaveOK = False

        Try
            If (VolumeBalances IsNot Nothing) Then
                SaveOK = mEventCriteria.CalculateVolumeBalances(VolumeBalances)
            End If
        Catch ex As Exception
            SaveOK = False
        End Try

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub ElliotWalkerVolumeBalanceTable_RowChanged() Handles ElliotWalkerVolumeBalanceTable.RowChanged
        Me.UpdateGraphics() ' Update graphics first; this updates the Vy calculations
    End Sub

    Private Sub MerriamKellerVolumeBalanceTable_RowChanged() Handles MerriamKellerVolumeBalanceTable.RowChanged
        Me.UpdateGraphics() ' Update graphics first; this updates the Vy calculations
    End Sub

    Private Sub EvalueVolumeBalanceTable_RowChanged() Handles EvalueVolumeBalanceTable.RowChanged
        Me.UpdateGraphics() ' Update graphics first; this updates the Vy calculations
        Me.EvalueVolumeBalanceTable.UpdateUI() ' Update table UI last; displays Vy calculations
    End Sub

    Private Sub EvalueVolumeBalanceTable_ColumnChanged() Handles EvalueVolumeBalanceTable.ColumnChanged
        Me.EvalueVolumeBalanceTable.UpdateUI() ' Update table UI last; displays Vy calculations
    End Sub

    Private Sub EvalueVolumeBalanceTable_ControlValueChanged() Handles EvalueVolumeBalanceTable.ControlValueChanged

        Dim vbTableParam As DataTableParameter = mEventCriteria.VolumeBalances
        Dim vbTable As DataTable = vbTableParam.Value

        If (vbTable.Rows.Count <= 0) Then
            ' Clear the Sigma Z table
            Dim sigmaZparam As DataTableParameter = mEventCriteria.SimSigmaZtable
            Dim sigmaZtable As DataTable = sigmaZparam.Value
            sigmaZtable.Rows.Clear()
            sigmaZparam.Source = ValueSources.Calculated
            mEventCriteria.SimSigmaZtable = sigmaZparam
        End If

        mEvaluationWorld.UpdateResultsControls()
        Me.UpdateGraphics() ' Update graphics; this updates the Vy calculations
    End Sub

    ' Resize display when required
    Private Sub ctl_VolumeBalances_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        Me.ResizeUI()
    End Sub

    Private Sub SuggestTimesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SuggestTimesButton.Click

        Select Case (mEventCriteria.EventAnalysisType.Value)

            Case EventAnalysisTypes.EvalueAnalysis
                Try
                    Dim eval As EVALUE = DirectCast(mAnalysis, EVALUE)

                    Dim times As Double() = eval.SuggestVolumeBalanceTimes()
                    If (times IsNot Nothing) Then
                        If (0 < times.Length) Then

                            mMyStore.MarkForUndo(mDictionary.tEvalueSuggestTimes.Translated)

                            ' Clear the Sigma Z table
                            Dim sigmaZparam As DataTableParameter = mEventCriteria.SimSigmaZtable
                            Dim sigmaZtable As DataTable = sigmaZparam.Value
                            sigmaZtable.Rows.Clear()
                            sigmaZparam.Source = ValueSources.Calculated
                            mEventCriteria.SimSigmaZtable = sigmaZparam

                            ' Get current EVALUE Volume Balances table
                            Dim vbParam As DataTableParameter = mEventCriteria.VolumeBalances
                            Dim vbTable As DataTable = vbParam.Value

                            ' Reload / recalculate using suggested times
                            mEventCriteria.ReloadVolumeBalanceTimes(vbTable, times)
                            mEventCriteria.CalculateVolumeBalances(vbTable)

                            ' Save new table
                            vbParam.Source = ValueSources.UserEntered
                            mEventCriteria.VolumeBalances = vbParam

                        End If
                    End If

                Catch ex As Exception
                End Try

                Me.UpdateGraphics() ' Update graphics first; this updates the Vy calculations
                Me.EvalueVolumeBalanceTable.UpdateUI() ' Update table UI last; displays Vy calculations

            Case Else ' Elliott-Walker 2pt or Merriam-Keller
                Debug.Assert(False, "Support for Analysis Type must be added")
        End Select

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
