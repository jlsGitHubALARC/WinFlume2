
'*************************************************************************************************************
' ctl_FlowDepths - UI for viewing & editing Flow Depth measurements
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_FlowDepths

#Region " Member Data "

    ' Data to display
    Private mDepthHydrographs As DataSet = Nothing

    ' Misc
    Private mUpdatingUI As Boolean = False

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
    Private WithEvents mEventCriteria As EventCriteria

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
    Public Sub LinkToModel(ByVal MyUnit As Unit, ByVal MyWindow As WorldWindow)

        Debug.Assert((MyUnit IsNot Nothing), "Unit is Nothing")

        ' Link control to its data model, UI and DataStore
        mUnit = MyUnit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        mEvaluationWorld = MyWindow
        mMyStore = mUnit.MyStore

        ' Link contained controls to their data models
        mUnit.SyncMeasStationsWithElevationTable() ' Ensure table flow depth values match
        Me.MeasStationsControl.LinkToModel(mMyStore, mInflowManagement.MeasurementStationsProperty)
        Me.MeasStationsControl.AllRowsFixed = True
        Me.MeasStationsControl.PasteDisabled = True
        Me.MeasStationsControl.ReadonlyColumn(sDistanceX) = True
        Me.MeasStationsControl.ReadonlyColumn(sElevationX) = True
        Me.MeasStationsControl.UpdateUI()

        Me.FlowDepthsControl.LinkToModel(mMyStore, mInflowManagement.StationsFlowDepthsProperty)
        Me.FlowDepthsControl.UpdateUI()

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
    ' Update UI when DataStore changes
    '
    Private Sub InflowManagement_PropertyChanged(ByVal Reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        ResizeUI()
        UpdateUI()
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal Reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update the FlowDepths control UI
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mEvaluationWorld IsNot Nothing) Then

            If (mEvaluationWorld.ResetingTabs) Then ' Evaluation World is reseting tab pages; wait
                Return
            End If

            mUpdatingUI = True

            Try
                ' Update Measurement Station table
                Dim measStationTable As DataTable = mInflowManagement.MeasurementStations.Value
                Dim selectedStation As Integer = mInflowManagement.SelectedStation.Value

                Dim currentIndex As Integer = Me.MeasStationsControl.CurrentRowIndex
                If (currentIndex < 0) Then
                    currentIndex = 0
                End If

                If Not (selectedStation = currentIndex) Then
                    Me.MeasStationsControl.UnSelect(Me.MeasStationsControl.CurrentRowIndex)
                    Me.MeasStationsControl.CurrentRowIndex = selectedStation
                End If

                ' Update Flow Depths table to match selected Measurement Station
                If (DataTableHasData(measStationTable, 1)) Then
                    Me.FlowDepthsControl.Show()

                    Dim flowDepthsSet As DataSet = mInflowManagement.StationsFlowDepths.Value

                    Dim stationDist As Double = mInflowManagement.SelectedStationDistance

                    Me.FlowDepthsControl.CaptionText = mDictionary.tFlowDepthsStation.Translated & " " & LengthString(stationDist)
                    Me.FlowDepthsControl.TableSelected = selectedStation
                    Me.FlowDepthsControl.UpdateUI()

                Else ' No measurement stations
                    Me.FlowDepthsControl.Hide()
                End If

            Catch ex As Exception
                Me.FlowDepthsControl.Hide()
            Finally
                Me.UpdateGraphics()
                Me.UpdateInstructions()
            End Try

            mUpdatingUI = False

        End If

    End Sub
    '
    ' Update the Flow Depths entry/use instructions
    '
    Private Sub UpdateInstructions()
        Dim measStationTable As DataTable = mInflowManagement.MeasurementStations.Value

        FlowDepthsInstructions.Clear()
        FlowDepthsInstructions.SelectionAlignment = HorizontalAlignment.Left

        AppendBoldText(FlowDepthsInstructions, mDictionary.tMeasurementStations.Translated)
        AppendLine(FlowDepthsInstructions, " - " & mDictionary.tStationsTableInstructions.Translated)
        AdvanceLine(FlowDepthsInstructions)
        AppendBoldText(FlowDepthsInstructions, mDictionary.tSelectMeasurementStations.Translated)
        AppendLine(FlowDepthsInstructions, " - " & mDictionary.tEditMeasurmentStations.Translated)

        If (DataTableHasData(measStationTable, 1)) Then
            AdvanceLine(FlowDepthsInstructions)
            AppendBoldText(FlowDepthsInstructions, "Flow Depths")
            AppendLine(FlowDepthsInstructions, " - " & mDictionary.tEnterFlowDepthsInstructions.Translated)
        End If

        If (mInflowManagement.FlowDepthsMeasuredAndUsed) Then
            AdvanceLine(FlowDepthsInstructions)
            AppendText(FlowDepthsInstructions, mDictionary.tFlowDepthsVolumeBalance.Translated)
        End If
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me)
        UpdateUI()
    End Sub
    '
    ' Resize control's UI to match the new window size
    '
    Private Sub ResizeUI()
        '
        ' Adjust controls on left to match new height
        '
        Me.FlowDepthsBox.Height = Me.Height - Me.FlowDepthsBox.Location.Y - 4

        ' Limit Station Table height to lesser of 1/2 parent height or just enough to display all rows
        Dim measStationHeight As Integer = (Me.FlowDepthsBox.Height / 2) - 4    ' 1/2 parent height
        Dim dispAllHeight As Integer = Me.MeasStationsControl.DisplayAllHeight  ' All rows height

        measStationHeight = MathMin(measStationHeight, dispAllHeight)

        Me.MeasStationsControl.Height = measStationHeight

        Me.SelectStationsButton.Location = New Point(Me.MeasStationsControl.Location.X, Me.MeasStationsControl.Location.Y + Me.MeasStationsControl.Height + 2)

        Me.FlowDepthsControl.Location = New Point(Me.MeasStationsControl.Location.X, Me.SelectStationsButton.Location.Y + Me.SelectStationsButton.Height + 2)
        Me.FlowDepthsControl.Height = Me.FlowDepthsBox.Height - Me.FlowDepthsControl.Location.Y - 4
        '
        ' Adjust controls on right to match new size
        '
        Me.StationsFlowGraph.Height = (Me.Height * 2 / 3)
        Me.StationsFlowGraph.Width = Me.Width - Me.StationsFlowGraph.Location.X - 4

        Me.FlowDepthsInstructions.Location = New Point(Me.StationsFlowGraph.Location.X, Me.StationsFlowGraph.Location.Y + Me.StationsFlowGraph.Height + 4)
        Me.FlowDepthsInstructions.Height = Me.Height - Me.FlowDepthsInstructions.Location.Y - 4
        Me.FlowDepthsInstructions.Width = Me.StationsFlowGraph.Width

    End Sub

#End Region

#Region " Graphics Update Methods "
    '
    ' Redraw the selected Flow Depths graph
    '
    Private Sub UpdateGraphics()

        Try ' catch, but ignore exceptions drawing graphs

            mDepthHydrographs = mInflowManagement.StationsFlowDepths.Value              ' Depth Hydrographs

            ' Add Key info to graph data
            For Each table As DataTable In mDepthHydrographs.Tables                     ' Add keys to Depth Hydrographs
                table.ExtendedProperties.Add("Key", True)
                If (table.ExtendedProperties.Contains(sDistanceX)) Then
                    Dim dist As Double = table.ExtendedProperties(sDistanceX)
                    Dim distText As String = "X=" & LengthString(dist)
                    table.ExtendedProperties.Add("Key Text", distText)

                    If (mInflowManagement.IsSelectedStationDist(dist)) Then
                        table.ExtendedProperties.Add("Symbol", "o")
                        table.ExtendedProperties.Add("Line", True)
                    End If
                End If
            Next table

            ' Draw Depth Hydrographs
            mDepthHydrographs.DataSetName = mDictionary.tFlowDepthHydrographs.Translated

            Me.StationsFlowGraph.InitializeGraph2D(mDepthHydrographs)
            Me.StationsFlowGraph.UnitsX = Units.Seconds
            Me.StationsFlowGraph.UnitsY = Units.Millimeters
            Me.StationsFlowGraph.Name = mDictionary.tFlowDepthHydrographs.Translated
            Me.StationsFlowGraph.DisplayKey = True
            Me.StationsFlowGraph.HorizontalKeys = True
            Me.StationsFlowGraph.ClearVertLines()
            Me.StationsFlowGraph.CurveControlIsOn = True
            Me.StationsFlowGraph.DrawImage()

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " UI Event Handler(s) "
    '
    ' Measurement Station table controls selected station number
    '
    Private Sub MeasStationControl_RowChanged() _
    Handles MeasStationsControl.RowChanged
        ' Make sure this is an actual change via user click to Measurement Station table
        If Not (mUpdatingUI Or mMyStore.InUndo Or mMyStore.InRedo) Then
            Dim selectedStation As IntegerParameter = mInflowManagement.SelectedStation

            If (0 <= selectedStation.Value) Then ' A station has been selected
                Dim arrowRow As Integer = Me.MeasStationsControl.RowSelected
                If (arrowRow < 0) Then
                    arrowRow = Me.MeasStationsControl.CurrentRowIndex
                End If

                If Not (selectedStation.Value = arrowRow) Then
                    mMyStore.MarkForUndo(mDictionary.tSelectStation.Translated)
                    selectedStation.Value = arrowRow
                    selectedStation.Source = ValueSources.UserEntered
                    mInflowManagement.SelectedStation = selectedStation
                End If
            End If
        End If
    End Sub

    Private Sub FlowDepthsControl_ControlValueChanged() _
    Handles FlowDepthsControl.ControlValueChanged
        Me.UpdateGraphics()
        mEvaluationWorld.UpdateResultsControls()
    End Sub

    Private Sub SelectStationsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SelectStationsButton.Click
        ' Get data for Select Measurement Stations dialog box
        Dim elevationTable As DataTable = mSystemGeometry.ElevationTable.Value.Tables(0)

        Dim stationParam As DataTableParameter = mInflowManagement.MeasurementStations
        Dim stationTable As DataTable = stationParam.Value

        ' Create, initialize & display dialog
        Dim db As SelectMeasurementStations = New SelectMeasurementStations

        db.ElevationTable = elevationTable
        db.StationsTable = stationTable
        db.Initialize()

        Dim result As DialogResult = db.ShowDialog()

        ' If user accepted changes, update Measurement Stations table
        If (result = DialogResult.OK) Then

            mUpdatingUI = True

            mMyStore.MarkForUndo("Measurement Stations Selected")

            stationTable = db.StationsTable

            stationParam.Source = ValueSources.UserEntered
            stationParam.Value = db.StationsTable
            mInflowManagement.MeasurementStations = stationParam

            ' Changing the Stations table invalidates the simulation's flow depth hydrographs
            mEventCriteria.ClearNseCurves()
            mEventCriteria.ClearPBiasCurves()
            mInflowManagement.SyncFlowHydrographsToStations()

            mUpdatingUI = False
        End If

    End Sub

    Private Sub ctl_FlowDepths_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        Me.ResizeUI()
        Me.UpdateUI()
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
