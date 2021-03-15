
'*************************************************************************************************************
' ctl_SurfaceVolumeMeasured - UI for viewing & editing Measured Surface Volumes
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_SurfaceVolumeMeasured

#Region " Member Data "

    ' Data to display
    Private mDepthHydrographs As DataSet = Nothing
    Private mDepthProfiles As DataSet = Nothing
    Private mElevationProfiles As DataSet = Nothing

    Private Enum DispTypes
        DepthHydrographs
        DepthProfiles
        ElevationProfiles
    End Enum

    Private mDispType As DispTypes = DispTypes.DepthHydrographs

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
    Private mWorldWindow As WorldWindow
    Private mEvaluationWorld As EvaluationWorld
    '
    ' Establish link to model object and update UI with its data
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow)

        Debug.Assert((_unit IsNot Nothing), "Unit is Nothing")

        ' Link control to its data model, UI and DataStore
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        mWorldWindow = worldWindow
        If (mWorldWindow.GetType Is GetType(EvaluationWorld)) Then
            mEvaluationWorld = DirectCast(mWorldWindow, EvaluationWorld)
        End If

        mMyStore = mUnit.MyStore

        ' Link contained controls to their data models
        Me.MeasStationsControl.LinkToModel(mMyStore, mInflowManagement.MeasurementStationsProperty)
        Me.MeasStationsControl.AllRowsFixed = True
        Me.MeasStationsControl.PasteDisabled = True
        Me.MeasStationsControl.ReadonlyColumn(sDistanceX) = True
        Me.MeasStationsControl.UpdateUI()

        Me.SurfaceVolumesControl.LinkToModel(mMyStore, mEventCriteria.VolumeBalancesProperty)
        Me.SurfaceVolumesControl.ReadonlyColumn(sTimeX) = True
        Me.SurfaceVolumesControl.HiddenColumn(sVin) = True
        Me.SurfaceVolumesControl.HiddenColumn(sVro) = True
        Me.SurfaceVolumesControl.ReadonlyColumn(sVy) = True
        Me.SurfaceVolumesControl.HiddenColumn(sVz) = True
        Me.SurfaceVolumesControl.UpdateUI()

        ' Initial graph selection based on downstream condition
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
            Me.ElevationProfileButton.Checked = True
            mDispType = DispTypes.ElevationProfiles
        Else
            Me.DepthProfileButton.Checked = True
            mDispType = DispTypes.DepthProfiles
        End If

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
    Private Sub SystemGeometry_PropertyChanged(ByVal reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub EventCriteriaPropertyChanged(ByVal reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update the FlowDepths control UI
    '
    Public Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mEvaluationWorld IsNot Nothing) Then

            If (mEvaluationWorld.ResetingTabs) Then ' Evaluation World is reseting tab pages; wait
                Return
            End If

            Try
                ' Update Measurement Station table
                Dim numStations As Integer = 0

                Dim measStations As DataTable = mInflowManagement.MeasurementStations.Value
                If (measStations IsNot Nothing) Then
                    If (measStations.Rows IsNot Nothing) Then
                        numStations = measStations.Rows.Count
                    End If
                End If

                Me.MeasStationsControl.MinRows = numStations ' Can't add/delete Stations here
                Me.MeasStationsControl.MaxRows = numStations

                ' Update Flow Depths table to match selected Measurement Station
                Dim stationDist As Double = mInflowManagement.SelectedStationDistance

                Me.SurfaceVolumesControl.UpdateUI()

                ' Update remainder of UI
                Me.UpdateInstructions()
                Me.UpdateGraphics()

            Catch ex As Exception
            End Try
        End If

    End Sub
    '
    ' Update the Flow Depths entry/use instructions
    '
    Private Sub UpdateInstructions()
        SurfaceVolumeInstructions.Clear()
        SurfaceVolumeInstructions.SelectionAlignment = HorizontalAlignment.Left
        AppendBoldText(SurfaceVolumeInstructions, "Measurement Stations")
        AppendText(SurfaceVolumeInstructions, " - " & mDictionary.tEditStationsInstructions1.Translated)
        AppendLine(SurfaceVolumeInstructions, "  " & mDictionary.tEditStationsInstructions2.Translated)

        Dim analysis As Analysis = mWorldWindow.CurrentAnalysis

        Dim hasSetupErrors As Boolean = analysis.CheckSetupErrors
        If (hasSetupErrors) Then
            Dim ifOnlyFuncParamError As Boolean = analysis.HasOnlySetupError(analysis.ErrorFlags.InfiltrationParameters)
            If Not (ifOnlyFuncParamError) Then
                AdvanceLine(SurfaceVolumeInstructions)
                AppendBoldLine(SurfaceVolumeInstructions, mDictionary.tErrors.Translated & ":")
                AppendLine(SurfaceVolumeInstructions, "  " & mDictionary.tSeeVerifyTabForDetails.Translated)
            End If
        End If

        Dim hasSetupWarnings As Boolean = analysis.CheckSetupWarnings
        If (hasSetupWarnings) Then
            AdvanceLine(SurfaceVolumeInstructions)
            AppendBoldLine(SurfaceVolumeInstructions, mDictionary.tWarnings.Translated & ":")
            AppendLine(SurfaceVolumeInstructions, "  " & mDictionary.tSeeVerifyTabForDetails.Translated)
        End If
    End Sub
    '
    ' Resize control's UI to match the new window size
    '
    Private Sub ResizeUI()
        '
        ' Adjust controls on left to match new height
        '
        Me.VolumeBalanceBox.Height = Me.Height - Me.VolumeBalanceBox.Location.Y - 4

        ' Limit Station Table height to lesser of 1/2 parent height or just enough to display all rows
        Dim measStationHeight As Integer = (Me.VolumeBalanceBox.Height / 2) - 4    ' 1/2 parent height
        Dim dispAllHeight As Integer = Me.MeasStationsControl.DisplayAllHeight  ' All rows height

        measStationHeight = MathMin(measStationHeight, dispAllHeight)

        Me.MeasStationsControl.Height = measStationHeight

        Me.SurfaceVolumesControl.Location = New Point(Me.MeasStationsControl.Location.X, Me.MeasStationsControl.Location.Y + Me.MeasStationsControl.Height + 2)
        Me.SurfaceVolumesControl.Height = Me.VolumeBalanceBox.Height - Me.SurfaceVolumesControl.Location.Y - 4
        '
        ' Adjust controls on right to match new size
        '
        Me.ShowFlowDepthsBox.Height = (Me.Height * 2 / 3) - 4
        Me.ShowFlowDepthsBox.Width = Me.Width - Me.ShowFlowDepthsBox.Location.X - 4

        Me.StationsFlowGraph.Height = Me.ShowFlowDepthsBox.Height - Me.StationsFlowGraph.Location.Y - 8
        Me.StationsFlowGraph.Width = Me.ShowFlowDepthsBox.Width - Me.StationsFlowGraph.Location.X - 8

        Me.SurfaceVolumeInstructions.Location = New Point(Me.ShowFlowDepthsBox.Location.X, Me.ShowFlowDepthsBox.Location.Y + Me.ShowFlowDepthsBox.Height + 2)
        Me.SurfaceVolumeInstructions.Height = Me.Height - Me.SurfaceVolumeInstructions.Location.Y - 4
        Me.SurfaceVolumeInstructions.Width = Me.ShowFlowDepthsBox.Width

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
    ' Redraw the selected Flow Depths graph
    '
    Private Sub UpdateGraphics()

        Try ' catch, but ignore exceptions drawing graphs

            Dim volTable As DataTable = mEventCriteria.VolumeBalances.Value
            Dim times As Double() = GetDoubleColumn(volTable, nTimeX)

            mDepthHydrographs = mInflowManagement.StationsFlowDepths.Value                      ' Depth Hydrographs are inputs to
            mDepthProfiles = mInflowManagement.FlowDepthProfiles(mDepthHydrographs, times)      '  Depth & Elevation Profile calculations
            mElevationProfiles = mInflowManagement.FlowElevationProfiles(mDepthHydrographs, times)

            Dim measStations As DataTable = mInflowManagement.MeasurementStations.Value
            Dim selStationNo As Integer = Me.MeasStationsControl.RowSelected
            Dim stationRow As DataRow = measStations.Rows(selStationNo)
            Dim selDist As Double = stationRow.Item(sDistanceX)

            ' Add Key info to graph data
            For Each table As DataTable In mDepthHydrographs.Tables                             ' Add keys to Depth Hydrographs
                table.ExtendedProperties.Add("Key", True)
                If (table.ExtendedProperties.Contains(sDistanceX)) Then
                    Dim dist As Double = table.ExtendedProperties(sDistanceX)
                    Dim distText As String = "X=" & LengthString(dist)
                    table.ExtendedProperties.Add("Key Text", distText)

                    If (dist = selDist) Then
                        table.ExtendedProperties.Add("Symbol", "o")
                        table.ExtendedProperties.Add("Line", True)
                    End If
                End If
            Next table

            For Each table As DataTable In mDepthProfiles.Tables                                ' Add keys to Depth Profiles
                If (table.ExtendedProperties.Contains(sTimeX)) Then
                    Dim time As Double = table.ExtendedProperties(sTimeX)
                    If (0.0 < time) Then
                        table.ExtendedProperties.Add("Key", True)
                        Dim timeText As String = "T=" & TimeString(time)
                        table.ExtendedProperties.Add("Key Text", timeText)
                    End If
                End If
            Next table

            For Each table As DataTable In mElevationProfiles.Tables                            ' Add keys to Elevation Profiles
                table.ExtendedProperties.Add("Key", True)
                If (table.ExtendedProperties.Contains(sTimeX)) Then
                    Dim time As Double = table.ExtendedProperties(sTimeX)
                    Dim timeText As String = "T=" & TimeString(time)
                    table.ExtendedProperties.Add("Key Text", timeText)
                Else
                    table.ExtendedProperties.Add("Symbol", "o")
                    table.ExtendedProperties.Add("Line", True)
                End If
            Next table

            If (Me.DepthHydrographButton.Checked) Then                                          ' Draw Depth Hydrographs

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

                If Not (mDispType = DispTypes.DepthHydrographs) Then
                    mDispType = DispTypes.DepthHydrographs
                    Me.StationsFlowGraph.ShowAllCurves()
                End If

            ElseIf (Me.DepthProfileButton.Checked) Then                                         ' Draw Depth Profiles

                mDepthProfiles.DataSetName = mDictionary.tFlowDepthProfiles.Translated

                Me.StationsFlowGraph.InitializeGraph2D(mDepthProfiles)
                Me.StationsFlowGraph.UnitsX = Units.Meters
                Me.StationsFlowGraph.UnitsY = Units.Millimeters
                Me.StationsFlowGraph.Name = mDictionary.tFlowDepthProfiles.Translated
                Me.StationsFlowGraph.DisplayKey = True
                Me.StationsFlowGraph.HorizontalKeys = True
                Me.StationsFlowGraph.ClearVertLines()
                Me.StationsFlowGraph.AddVertLine(selDist)
                Me.StationsFlowGraph.CurveControlIsOn = True
                Me.StationsFlowGraph.DrawImage()

                If Not (mDispType = DispTypes.DepthProfiles) Then
                    mDispType = DispTypes.DepthProfiles
                    Me.StationsFlowGraph.ShowAllCurves()
                End If

            Else                                                                                ' Draw Elevation Profile

                mElevationProfiles.DataSetName = mDictionary.tWaterSurfaceProfiles.Translated

                Me.StationsFlowGraph.InitializeGraph2D(mElevationProfiles)
                Me.StationsFlowGraph.UnitsX = Units.Meters
                Me.StationsFlowGraph.UnitsY = Units.Meters

                Dim minY As Double = DataColumnMin(mElevationProfiles, sElevationX)
                minY = (CInt(minY * CentimetersPerMeter - 0.5)) / CentimetersPerMeter

                Dim maxY As Double = DataColumnMax(mElevationProfiles, sElevationX)
                maxY = (CInt(maxY * CentimetersPerMeter + 0.5)) / CentimetersPerMeter

                Me.StationsFlowGraph.SetMinMaxY(minY, maxY)
                Me.StationsFlowGraph.Name = mDictionary.tWaterSurfaceProfiles.Translated
                Me.StationsFlowGraph.DisplayKey = True
                Me.StationsFlowGraph.HorizontalKeys = True
                Me.StationsFlowGraph.ClearVertLines()
                Me.StationsFlowGraph.AddVertLine(selDist)
                Me.StationsFlowGraph.LastCurve = 0
                Me.StationsFlowGraph.CurveControlIsOn = True
                Me.StationsFlowGraph.DrawImage()

                If Not (mDispType = DispTypes.ElevationProfiles) Then
                    mDispType = DispTypes.ElevationProfiles
                    Me.StationsFlowGraph.ShowAllCurves()
                End If

            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " UI Event Handler(s) "
    '
    ' Measurement Station table controls selected station
    '
    Private Sub MeasStationControl_RowChanged() _
    Handles MeasStationsControl.RowChanged
        Me.UpdateUI()
    End Sub
    '
    ' Keep UI up to date with contained control changes
    '
    Private Sub MeasStationControl_ControlValueChanged() _
    Handles MeasStationsControl.ControlValueChanged
        mUnit.SyncMeasStationsWithElevationTable()
        Me.UpdateUI()
        mWorldWindow.UpdateResultsControls()
    End Sub

    Private Sub FlowDepthsControl_ControlValueChanged() _
    Handles SurfaceVolumesControl.ControlValueChanged
        Me.UpdateGraphics()
        mWorldWindow.UpdateResultsControls()
    End Sub

    Private Sub DepthHydrographButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DepthHydrographButton.CheckedChanged
        If (DepthHydrographButton.Checked) Then
            Me.UpdateUI()
        End If
    End Sub

    Private Sub DepthProfileButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DepthProfileButton.CheckedChanged
        If (DepthProfileButton.Checked) Then
            Me.UpdateUI()
        End If
    End Sub

    Private Sub ElevationProfileButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ElevationProfileButton.CheckedChanged
        If (ElevationProfileButton.Checked) Then
            Me.UpdateUI()
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
        Me.UpdateUI()
    End Sub

#End Region

End Class
