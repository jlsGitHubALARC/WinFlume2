
'*************************************************************************************************************
' Station Measurements Dialog
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore

Public Class StationMeasurements

#Region " Member Data "

    Private mFormLoaded As Boolean = False
    Private mDataChanged As Boolean = False

    Private mUnits As UnitsSystem = UnitsSystem.Instance()
    Private mDictionary As Dictionary = Dictionary.Instance()

    Public Enum WaterFlowActions
        SelectAction
        AddNewTable
        DeleteTable
        ShowTable
    End Enum
    '
    ' Control positions / heights for re-sizing
    '
    Private mMinStationMeasurementsHeight As Integer
    Private mStationMeasurementsHeight As Integer

    Private mMinAdvanceRecessionBoxHeight As Integer
    Private mMinAdvanceTimesHeight As Integer
    Private mMinRecessionTimesHeight As Integer

    Private mMinSurfaceFlowBoxHeight As Integer
    Private mMinFlowDepthsHeight As Integer

    Private mMinCancelButtonY As Integer
    Private mMinOkButtonY As Integer
    Private mMinAdvRecInstructionsY As Integer
    Private mMinWaterFlowInstructionsY As Integer

#End Region

#Region " Properties "
    '
    ' EVALUE Analysis
    '
    Private mEVALUE As EVALUE
    Public Property EVALUE() As EVALUE
        Get
            Return mEVALUE
        End Get
        Set(ByVal value As EVALUE)
            mEVALUE = value
        End Set
    End Property
    '
    ' Include Recession
    '
    Private mIncludeStationRecession As Boolean = True
    Public Property IncludeStationRecession() As Boolean
        Get
            Return mIncludeStationRecession
        End Get
        Set(ByVal value As Boolean)
            mIncludeStationRecession = value
            UpdateUI()
        End Set
    End Property
    '
    ' Advance / Recession Tables
    '
    Private mAdvanceTimesPropertyNode As PropertyNode = New PropertyNode
    Private mAdvanceTimesUpdating As Boolean = False

    Public Property AdvanceTimesTable() As DataTable
        Get
            AdvanceTimesTable = mAdvanceTimesPropertyNode.GetDataTableParameter.Value
            AdvanceTimesTable.Columns(0).ColumnName = sDistanceX
            AdvanceTimesTable.Columns(1).ColumnName = sTimeX
        End Get
        Set(ByVal value As DataTable)

            Dim _advanceTimesParameter As DataTableParameter = New DataTableParameter(value)

            mAdvanceTimesPropertyNode.SetParameter(_advanceTimesParameter)
            mAdvanceTimesPropertyNode.EventsEnabled = True

            Me.AdvanceTimes.LinkToModel(Nothing, mAdvanceTimesPropertyNode)
            Me.AdvanceTimes.FirstColumnIncreases = True
            Me.AdvanceTimes.SecondColumnIncreases = True
            Me.AdvanceTimes.UpdateUI()
            UpdateUI()
        End Set
    End Property

    Private mRecessionTimesPropertyNode As PropertyNode = New PropertyNode
    Private mRecessionTimesUpdating As Boolean = False

    Public Property RecessionTimesTable() As DataTable
        Get
            RecessionTimesTable = mRecessionTimesPropertyNode.GetDataTableParameter.Value
            RecessionTimesTable.Columns(0).ColumnName = sDistanceX
            RecessionTimesTable.Columns(1).ColumnName = sTimeX
        End Get
        Set(ByVal value As DataTable)

            Dim _recessionTimesParameter As DataTableParameter = New DataTableParameter(value)

            mRecessionTimesPropertyNode.SetParameter(_recessionTimesParameter)
            mRecessionTimesPropertyNode.EventsEnabled = True

            Me.RecessionTimes.LinkToModel(Nothing, mRecessionTimesPropertyNode)
            Me.RecessionTimes.FirstColumnIncreases = True
            Me.RecessionTimes.SecondColumnIncreases = True
            Me.RecessionTimes.UpdateUI()
            UpdateUI()
        End Set
    End Property
    '
    ' Station Flow Depths Set
    '
    Private mFlowDepthsSet As DataSet = Nothing
    Private mFlowDepthsPropertyNode As PropertyNode = New PropertyNode
    Private mFlowDepthsUpdating As Boolean = False

    Public Property FlowDepthsSet() As DataSet
        Get
            FlowDepthsSet = mFlowDepthsSet.Copy
            If (FlowDepthsSet.Tables IsNot Nothing) Then
                For Each flowDepthTable As DataTable In FlowDepthsSet.Tables
                    flowDepthTable.Columns(0).ColumnName = sTimeX
                    flowDepthTable.Columns(1).ColumnName = sDepthX
                Next
            End If
        End Get
        Set(ByVal value As DataSet)
            mFlowDepthsSet = value
            UpdateUI()
        End Set
    End Property

    ' Selected Flow Depths table
    Private mSelectedFlowDepthTable As Integer = -1
    Public Property SelectedFlowDepthTable() As Integer
        Get
            Return mSelectedFlowDepthTable
        End Get
        Set(ByVal value As Integer)
            Me.SaveSelectedFlowDepthTable()    ' Save the currently displayed Station data
            mSelectedFlowDepthTable = value    ' Switch to the newly selected Station
            Me.ShowSelectedFlowDepthTable()    ' Show the newly select Station data
            UpdateUI()
        End Set
    End Property

#End Region

#Region " Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update the User Interface, primarily data setup errors
    '*********************************************************************************************************
    Public Sub UpdateUI()
        If (mFormLoaded) Then ' Form has been loaded; controls exist

            ' Update Recession table availability
            If (mIncludeStationRecession) Then
                Me.RecessionTimes.Show()
            Else
                Me.RecessionTimes.Hide()
            End If

            ' Setup checks are made by the EVALUE analysis
            If (mEVALUE IsNot Nothing) Then

                ' Check Advance Table for errors
                mEVALUE.ClearSetupErrors()
                mEVALUE.CheckAdvanceTableErrors(Me.AdvanceTimesTable)

                If (mEVALUE.HasSetupErrors) Then
                    Dim errorItem As Analysis.ErrorWarningItem = mEVALUE.SetupErrorItems(0)
                    Dim errDetail As String = errorItem.Detail
                    Me.AdvanceTimes.ErrorProvider.SetError(Me.AdvanceTimes, errDetail)
                Else
                    Me.AdvanceTimes.ErrorProvider.Clear()
                End If

                ' Check Recession Table for errors
                If (mIncludeStationRecession) Then

                    mEVALUE.ClearSetupErrors()
                    mEVALUE.CheckRecessionTableErrors(Me.RecessionTimesTable)

                    If (mEVALUE.HasSetupErrors) Then
                        Dim errorItem As Analysis.ErrorWarningItem = mEVALUE.SetupErrorItems(0)
                        Dim errDetail As String = errorItem.Detail
                        Me.RecessionTimes.ErrorProvider.SetError(Me.RecessionTimes, errDetail)
                    Else
                        Me.RecessionTimes.ErrorProvider.Clear()
                    End If
                End If

                ' Check Flow Depth Tables for errors
                mEVALUE.ClearSetupErrors()
                mEVALUE.CheckFlowDepthHydrographsErrors(Me.FlowDepthsSet, Me.AdvanceTimesTable)

                If (mEVALUE.HasSetupErrors) Then
                    Dim errorItem As Analysis.ErrorWarningItem = mEVALUE.SetupErrorItems(0)
                    Dim errDetail As String = errorItem.Detail
                    Me.FlowDepths.ErrorProvider.SetError(Me.FlowDepths, errDetail)
                Else
                    Me.FlowDepths.ErrorProvider.Clear()
                End If

                ' Update available user actions
                Me.WaterFlowActionControl.SelectedIndex = 0
                Me.WaterFlowActionControl.Update()

                ' Update OK & Apply buttons depending on whether or not data has changed
                If (mDataChanged) Then
                    Me.Ok_Button.Enabled = True
                    Me.Apply_Button.Enabled = True
                Else
                    Me.Ok_Button.Enabled = False
                    Me.Apply_Button.Enabled = False
                End If

            End If
        End If ' mFormLoaded
    End Sub

    '*********************************************************************************************************
    ' Sub SaveSelectedFlowDepthTable() - Save selected Flow Depth DatTable back into the Flow Depths DataSet
    '*********************************************************************************************************
    Private Sub SaveSelectedFlowDepthTable()

        If (mFlowDepthsSet IsNot Nothing) Then
            If (mFlowDepthsSet.Tables IsNot Nothing) Then

                Dim numFlowDepthTables As Integer = mFlowDepthsSet.Tables.Count

                If ((0 <= mSelectedFlowDepthTable) And (mSelectedFlowDepthTable < numFlowDepthTables)) Then

                    ' Get new Flow Depths table from UI control
                    Dim tableParam As DataTableParameter = mFlowDepthsPropertyNode.GetDataTableParameter
                    If (tableParam IsNot Nothing) Then

                        Dim newFlowDepths As DataTable = tableParam.Value
                        If (newFlowDepths IsNot Nothing) Then

                            ' Build a new Flow Depths DataSet using the new Flow Depths table from the UI
                            Dim newFlowDepthsSet As DataSet = New DataSet(InflowManagement.sStationsFlowDepths)

                            For sdx As Integer = 0 To mFlowDepthsSet.Tables.Count - 1
                                If (sdx = mSelectedFlowDepthTable) Then ' this is where UI table goes
                                    newFlowDepthsSet.Tables.Add(newFlowDepths)
                                Else ' copy all the rest as is
                                    newFlowDepthsSet.Tables.Add(mFlowDepthsSet.Tables(sdx).Copy)
                                End If
                            Next sdx

                            ' Replace old Flow Depths DataSet with new Flow Depths DataSet
                            mFlowDepthsSet.Clear()
                            mFlowDepthsSet = Nothing
                            mFlowDepthsSet = newFlowDepthsSet

                        End If ' (newFlowDepths IsNot Nothing)
                    End If ' (tableParam IsNot Nothing)

                End If ' mSelectedStation in range
            End If ' (mFlowDepthsSet.Tables IsNot Nothing)
        End If ' (mFlowDepthsSet IsNot Nothing)

    End Sub

    '*********************************************************************************************************
    ' Sub ShowSelectedFlowDepthTable() - Get/show selected Flow Depth DatTable from the Flow Depths DataSet
    '*********************************************************************************************************
    Private Sub ShowSelectedFlowDepthTable()

        If (mFlowDepthsSet IsNot Nothing) Then
            If (mFlowDepthsSet.Tables IsNot Nothing) Then

                Dim numFlowDepthTables As Integer = mFlowDepthsSet.Tables.Count

                If ((0 <= mSelectedFlowDepthTable) And (mSelectedFlowDepthTable < numFlowDepthTables)) Then

                    Dim flowDepthTable As DataTable = mFlowDepthsSet.Tables(mSelectedFlowDepthTable)
                    Dim distance As Double = flowDepthTable.ExtendedProperties(sDistanceX)

                    Dim flowDepthsParameter As DataTableParameter = New DataTableParameter(flowDepthTable)

                    mFlowDepthsPropertyNode.SetParameter(flowDepthsParameter)
                    mFlowDepthsPropertyNode.EventsEnabled = True

                    Me.FlowDepths.LinkToModel(Nothing, mFlowDepthsPropertyNode)
                    Me.FlowDepths.FirstColumnIncreases = True
                    Me.FlowDepths.CaptionText = "Flow Depths at " & LengthString(distance)
                    Me.FlowDepths.UpdateUI()

                End If ' mSelectedStation in range
            End If ' (mFlowDepthsSet.Tables IsNot Nothing)
        End If ' (mFlowDepthsSet IsNot Nothing)

    End Sub

#End Region

#Region " UI Event Handlers "
    '
    ' Load/Shown event handlers
    '
    Private Sub StationMeasurements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        Me.AdvanceTimes.ColumnWidthRatios = New Integer() {6, 4}
        Me.AdvanceTimes.UpdateUI()
        Me.RecessionTimes.ColumnWidthRatios = New Integer() {6, 4}
        Me.RecessionTimes.UpdateUI()
        Me.FlowDepths.ColumnWidthRatios = New Integer() {3, 3, 5}
        Me.FlowDepths.UpdateUI()

        Me.WaterFlowActionControl.SelectedIndex = 0
        '
        ' Save initial control sizing for later re-sizing
        '
        mMinStationMeasurementsHeight = MyBase.Height
        mStationMeasurementsHeight = MyBase.Height

        mMinAdvanceRecessionBoxHeight = Me.AdvanceRecessionBox.Height
        mMinAdvanceTimesHeight = Me.AdvanceTimes.Height
        mMinRecessionTimesHeight = Me.RecessionTimes.Height

        mMinSurfaceFlowBoxHeight = Me.SurfaceFlowBox.Height
        mMinFlowDepthsHeight = Me.FlowDepths.Height

        mMinCancelButtonY = Me.Cancel_Button.Location.Y
        mMinOkButtonY = Me.Ok_Button.Location.Y
        mMinAdvRecInstructionsY = Me.AdvRecInstructions.Location.Y
        mMinWaterFlowInstructionsY = Me.WaterFlowInstructions.Location.Y

        mFormLoaded = True
    End Sub

    Private Sub StationMeasurements_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Shown
        UpdateUI()
    End Sub
    '
    ' Include Recession checkbox handler
    '
    Private Sub IncludeRecession_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles IncludeRecession.CheckedChanged
        Me.IncludeStationRecession = Me.IncludeRecession.Checked
    End Sub
    '
    ' Advance / Recession / Flow Depths table data updated handlers
    '
    Private Sub AdvanceTimes_ControlValueChanged() Handles AdvanceTimes.ControlValueChanged
        mDataChanged = True
        UpdateUI()
    End Sub

    Private Sub RecessionTimes_ControlValueChanged() Handles RecessionTimes.ControlValueChanged
        mDataChanged = True
        UpdateUI()
    End Sub

    Private Sub FlowDepths_ControlValueChanged() Handles FlowDepths.ControlValueChanged
        Me.SaveSelectedFlowDepthTable()
        mDataChanged = True
        UpdateUI()
        Me.ShowSelectedFlowDepthTable()    ' Show the new selected Station data
    End Sub
    '
    ' Water Flow Action drop down handlers
    '
    Private Sub WaterFlowActionControl_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WaterFlowActionControl.DropDown

        ' Clear action menu then build a new one from based on currently available user input data
        Me.WaterFlowActionControl.Items.Clear()
        Me.WaterFlowActionControl.Items.Add(mDictionary.tSelectAction.Translated & " -->")

        ' Add menu item to add a new Flow Depth Table
        Me.WaterFlowActionControl.Items.Add(mDictionary.tAddNewTable.Translated & " ...")

        ' If a Flow Depth Set exists, add meun items specific to each Flow Depth Table
        If (mFlowDepthsSet IsNot Nothing) Then
            If (mFlowDepthsSet.Tables IsNot Nothing) Then

                mSelectedFlowDepthTable = Math.Max(mSelectedFlowDepthTable, 0)
                mSelectedFlowDepthTable = Math.Min(mSelectedFlowDepthTable, FlowDepthsSet.Tables.Count - 1)

                Dim flowDepthTable As DataTable = FlowDepthsSet.Tables(mSelectedFlowDepthTable)
                Dim distance As Double = flowDepthTable.ExtendedProperties(sDistanceX)

                ' Add menu item to delete the currently selected Flow Depth Table
                Me.WaterFlowActionControl.Items.Add(mDictionary.tDeleteTableAt.Translated & " " & LengthString(distance) & " ...")

                ' Add menu items to select one of the Flow Depth Tables
                For fdx As Integer = 0 To FlowDepthsSet.Tables.Count - 1
                    flowDepthTable = FlowDepthsSet.Tables(fdx)
                    distance = flowDepthTable.ExtendedProperties(sDistanceX)
                    Me.WaterFlowActionControl.Items.Add(mDictionary.tShowTableAt.Translated & " " & LengthString(distance))
                Next fdx

            End If
        End If
    End Sub

    Private mChangingSelection As Boolean = False
    Private Sub WaterFlowActionControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles WaterFlowActionControl.SelectedIndexChanged
        If Not (mChangingSelection) Then
            mChangingSelection = True

            If (WaterFlowActions.SelectAction = Me.WaterFlowActionControl.SelectedIndex) Then

            ElseIf (WaterFlowActions.AddNewTable = Me.WaterFlowActionControl.SelectedIndex) Then

                ' Setup dialog to allow user to enter new table's location
                Dim db As db_GetDoubleValue = Nothing
                If (mUnits.UnitSystem = UnitSystems.English) Then
                    db = New db_GetDoubleValue(0.0, Units.Feet)
                    db.MinValue = 0.0
                    db.MaxValue = UnitValue(mEVALUE.Unit.SystemGeometryRef.Length.Value, Units.Feet)
                Else ' Metric
                    db = New db_GetDoubleValue(0.0, Units.Meters)
                    db.MinValue = 0.0
                    db.MaxValue = UnitValue(mEVALUE.Unit.SystemGeometryRef.Length.Value, Units.Meters)
                End If

                db.Title = mDictionary.tEnterLocation.Translated
                db.Instructions = mDictionary.tEnterLocationForFlowDepthTable.Translated

                ' Display dialog so user can edit location
                Dim result As DialogResult = db.ShowDialog
                If (result = Windows.Forms.DialogResult.OK) Then

                    ' Get new table's location
                    Dim distance As Double = db.Value

                    Dim flowDepthTable As DataTable = GetDataTableByExtendedProperty(mFlowDepthsSet, sDistanceX, distance)
                    If (flowDepthTable Is Nothing) Then
                        flowDepthTable = InflowManagement.NewStationFlowDepthTable(distance)
                        mFlowDepthsSet.Tables.Add(flowDepthTable)
                        SortDataSetByExtendedProperty(mFlowDepthsSet, sDistanceX)

                        ' Find new position for selected table
                        For mSelectedFlowDepthTable = 0 To mFlowDepthsSet.Tables.Count - 1
                            flowDepthTable = mFlowDepthsSet.Tables(mSelectedFlowDepthTable)
                            If (distance = flowDepthTable.ExtendedProperties(sDistanceX)) Then
                                Exit For
                            End If
                        Next
                    Else
                        Dim msg As String = mDictionary.tFlowDepthTableExists.Translated & " " & LengthString(distance) & "!"
                        MsgBox(msg, MsgBoxStyle.Exclamation, mDictionary.tLocationError.Translated)
                    End If

                    ' Show selected table in its new position
                    ShowSelectedFlowDepthTable()
                    UpdateUI()
                End If

            ElseIf (WaterFlowActions.DeleteTable = Me.WaterFlowActionControl.SelectedIndex) Then
                Dim flowDepthTable As DataTable = mFlowDepthsSet.Tables(mSelectedFlowDepthTable)
                Dim distance As Double = flowDepthTable.ExtendedProperties(sDistanceX)

                Dim title As String = mDictionary.tDeleteTable.Translated

                If (1 < mFlowDepthsSet.Tables.Count) Then
                    Dim msg As String = mDictionary.tDeleteFlowDepthTable.Translated & " " & LengthString(distance) & "?"
                    Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                    If (result = MsgBoxResult.Yes) Then
                        mFlowDepthsSet.Tables.RemoveAt(mSelectedFlowDepthTable)
                        mSelectedFlowDepthTable = Math.Min(mSelectedFlowDepthTable, mFlowDepthsSet.Tables.Count - 1)
                        ShowSelectedFlowDepthTable()
                        UpdateUI()
                    End If
                Else
                    Dim msg As String = mDictionary.tCannotDeleteLastFlowDepthTable.Translated & " " & LengthString(distance) & "!"
                    MsgBox(msg, MsgBoxStyle.Exclamation, title)
                End If

            ElseIf (WaterFlowActions.ShowTable <= Me.WaterFlowActionControl.SelectedIndex) Then
                Dim sdx As Integer = Me.WaterFlowActionControl.SelectedIndex - WaterFlowActions.ShowTable
                Me.SelectedFlowDepthTable = sdx
            End If

            Me.WaterFlowActionControl.SelectedIndex = 0
            UpdateUI()

            mChangingSelection = False
        End If
    End Sub

    Private Sub EditLocationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EditLocationButton.Click

        If (mFlowDepthsSet IsNot Nothing) Then
            If (mFlowDepthsSet.Tables IsNot Nothing) Then

                Dim numFlowDepthTables As Integer = mFlowDepthsSet.Tables.Count

                If ((0 <= mSelectedFlowDepthTable) And (mSelectedFlowDepthTable < numFlowDepthTables)) Then

                    ' Get currently selected Flow Depth table
                    Dim flowDepthTable As DataTable = mFlowDepthsSet.Tables(mSelectedFlowDepthTable)
                    Dim distance As Double = flowDepthTable.ExtendedProperties(sDistanceX)

                    ' Setup dialog to allow user to change its location
                    Dim db As db_GetDoubleValue = Nothing
                    If (mUnits.UnitSystem = UnitSystems.English) Then
                        db = New db_GetDoubleValue(distance, Units.Feet)
                        db.MinValue = 0.0
                        db.MaxValue = UnitValue(mEVALUE.Unit.SystemGeometryRef.Length.Value, Units.Feet)
                    Else ' Metric
                        db = New db_GetDoubleValue(distance, Units.Meters)
                        db.MinValue = 0.0
                        db.MaxValue = UnitValue(mEVALUE.Unit.SystemGeometryRef.Length.Value, Units.Meters)
                    End If

                    db.Title = mDictionary.tEnterLocation.Translated
                    db.Instructions = mDictionary.tEnterLocationForFlowDepthTable.Translated

                    ' Display dialog so user can edit location
                    Dim result As DialogResult = db.ShowDialog
                    If (result = Windows.Forms.DialogResult.OK) Then

                        ' Get new location and save in DataTable as Extended Property
                        distance = db.Value
                        flowDepthTable.ExtendedProperties(sDistanceX) = distance
                        SortDataSetByExtendedProperty(mFlowDepthsSet, sDistanceX)

                        ' Find new position for selected table
                        For mSelectedFlowDepthTable = 0 To numFlowDepthTables - 1
                            flowDepthTable = mFlowDepthsSet.Tables(mSelectedFlowDepthTable)
                            If (distance = flowDepthTable.ExtendedProperties(sDistanceX)) Then
                                Exit For
                            End If
                        Next

                        ' Show selected table in its new position
                        ShowSelectedFlowDepthTable()
                        UpdateUI()
                    End If

                End If ' mSelectedStation in range
            End If ' (mFlowDepthsSet.Tables IsNot Nothing)
        End If ' (mFlowDepthsSet IsNot Nothing)

    End Sub
    '
    ' Resize handler - expand dialog vertically to allow more of the table data to be shown
    '
    Private Sub StationMeasurements_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        If (mFormLoaded) Then

            ' Get change in Height for Station Measurements dialog box
            Dim _deltaHeight As Integer = mStationMeasurementsHeight - MyBase.Height

            ' Move controls below tables
            Dim pt As Point = New Point(Ok_Button.Location.X, _
                                        Math.Max(mMinOkButtonY, Ok_Button.Location.Y - _deltaHeight))
            Ok_Button.Location = pt

            pt = New Point(Cancel_Button.Location.X, _
                           Math.Max(mMinCancelButtonY, Cancel_Button.Location.Y - _deltaHeight))
            Cancel_Button.Location = pt

            pt = New Point(AdvRecInstructions.Location.X, _
                           Math.Max(mMinAdvRecInstructionsY, AdvRecInstructions.Location.Y - _deltaHeight))
            AdvRecInstructions.Location = pt

            pt = New Point(WaterFlowInstructions.Location.X, _
                           Math.Max(mMinWaterFlowInstructionsY, WaterFlowInstructions.Location.Y - _deltaHeight))
            WaterFlowInstructions.Location = pt

            ' Adjust tables to match new height (with limits on minimum heights)
            AdvanceRecessionBox.Height = Math.Max(mMinAdvanceRecessionBoxHeight, _
                                                  AdvanceRecessionBox.Height - _deltaHeight)

            AdvanceTimes.Height = Math.Max(mMinAdvanceTimesHeight, _
                                           AdvanceTimes.Height - _deltaHeight)

            RecessionTimes.Height = Math.Max(mMinRecessionTimesHeight, _
                                             RecessionTimes.Height - _deltaHeight)

            SurfaceFlowBox.Height = Math.Max(mMinSurfaceFlowBoxHeight, _
                                             SurfaceFlowBox.Height - _deltaHeight)

            FlowDepths.Height = Math.Max(mMinFlowDepthsHeight, _
                                         FlowDepths.Height - _deltaHeight)

            If (mMinStationMeasurementsHeight < MyBase.Height) Then
                mStationMeasurementsHeight = MyBase.Height
            End If

        End If

    End Sub
    '
    ' Apply button handler
    '
    Private Sub Apply_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Apply_Button.Click
        Me.SaveSelectedFlowDepthTable()
        mDataChanged = False
        UpdateUI()
        Me.ShowSelectedFlowDepthTable()    ' Show the new selected Station data
        RaiseEvent ApplyChanges()
    End Sub
    '
    ' OK button handler
    '
    Private Sub Ok_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Ok_Button.Click
        Me.SaveSelectedFlowDepthTable()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Event ApplyChanges()

#End Region

End Class