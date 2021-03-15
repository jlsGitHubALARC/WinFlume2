
'*************************************************************************************************************
' Class:    SystemGeometry
'
' Desc: SystemGeometry provides the Model (data store & logic) for the physical geometric description of a
'       border or furrow.
'
' Note - once DataStore Properties are assigned to a DataStore Object, they should remain there.  It may be
'        possible to move them but that would require special programming to detect their presence under one
'        Object in an earlier file version and move them to their new Object.
'
'        This is pertinent to some Properties under the SystemGeometry Object where they originally resided
'        but were 'moved' to Inflow as far as the UI & User are concerned.  They remain logically under the
'        SystemGeometry Object to maintain backward compatibility with earlier version .srfr files:
'
'        UpstreamCondition now appears within the Inflow UI as Drainback.  It is still here in the DataStore!
'        DownstreamCondition also appears within the Inflow UI but remains here for storage.
'*************************************************************************************************************
Imports System
Imports System.Collections.Generic

Imports DataStore

Public Class SystemGeometry

#Region " Member Data "

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "System Geometry"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Parent Unit
    '
    Private mUnit As Unit = Nothing
    Public ReadOnly Property Unit() As Unit
        Get
            Return mUnit
        End Get
    End Property
    '
    ' Data Store
    '
    Private mParentStore As DataStore.ObjectNode = Nothing
    Private WithEvents mMyStore As DataStore.ObjectNode = Nothing
    Public ReadOnly Property MyStore() As DataStore.ObjectNode
        Get
            Return mMyStore
        End Get
    End Property

#End Region

#Region " Serialized Properties "

#Region " Cross Section "

    Public ReadOnly Property CrossSectionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCrossSection)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultCrossSection)
                mMyStore.AddProperty(sCrossSection, _parameter)
                _propertyNode = mMyStore.GetProperty(sCrossSection)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CrossSection() As IntegerParameter
        Get
            Return CrossSectionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            CrossSectionProperty.SetParameter(Value)
        End Set
    End Property

    Private mCrossSectionIndex As Integer = -1
    Public Function GetFirstCrossSectionSelection() As String
        mCrossSectionIndex = -1
        Return GetNextCrossSectionSelection()
    End Function

    Public Function GetNextCrossSectionSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = CType(CrossSection.Value, CrossSections)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        mCrossSectionIndex += 1
        If (mCrossSectionIndex < CrossSections.HighLimit) Then
            If ((CrossSectionSelections(mCrossSectionIndex).Flags And _flags) = 0) Then
                Return CrossSectionSelections(mCrossSectionIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function

#End Region

#Region " Upstream Boundary Condition "

    Public ReadOnly Property UpstreamConditionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDrainback)

            If (_propertyNode Is Nothing) Then ' try deprecated name
                _propertyNode = mMyStore.GetProperty(sUpstreamCondition)

                ' If deprecated name was found; update it
                If (_propertyNode IsNot Nothing) Then
                    _propertyNode.MyID = sDrainback
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultUpstreamCondition)
                mMyStore.AddProperty(sDrainback, _parameter)
                _propertyNode = mMyStore.GetProperty(sDrainback)
            End If

            Dim noDrainback As Boolean = False

            ' No Drainback for Cablegation or Surge Inflow
            Dim inflow As InflowMethods = mUnit.InflowManagementRef.InflowMethod.Value
            If ((inflow = InflowMethods.Cablegation) Or (inflow = InflowMethods.Surge)) Then
                noDrainback = True
            End If

            ' No Drainback for Standard Hydrograph w/ Cutback
            Dim cutback As CutbackMethods = mUnit.InflowManagementRef.CutbackMethod.Value
            If ((inflow = InflowMethods.StandardHydrograph) And Not (cutback = CutbackMethods.NoCutback)) Then
                noDrainback = True
            End If

            ' Drainback only for Research user
            If Not (WinSRFR.UserLevel = UserLevels.Research) Then
                noDrainback = True
            End If

            If (noDrainback) Then
                Dim _parameter As Parameter = _propertyNode.GetParameter
                Dim _integer As IntegerParameter = DirectCast(_parameter, IntegerParameter)

                If (_integer.Value = UpstreamConditions.DrainbackAfterCutoff) Then
                    _integer.Value = UpstreamConditions.NoDrainback
                    '_propertyNode.RaisePropertyDataChangedEvent(PropertyNode.Reasons.ValueChanged)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property UpstreamCondition() As IntegerParameter
        Get
            Return UpstreamConditionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            UpstreamConditionProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Downstream Boundary Condition "

    Public ReadOnly Property DownstreamConditionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDownstreamCondition)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultDownstreamCondition)
                mMyStore.AddProperty(sDownstreamCondition, _parameter)
                _propertyNode = mMyStore.GetProperty(sDownstreamCondition)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DownstreamCondition() As IntegerParameter
        Get
            Return DownstreamConditionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DownstreamConditionProperty.SetParameter(Value)
        End Set
    End Property

    Private mDownstreamConditionIndex As Integer = -1
    Public Function GetFirstDownstreamConditionSelection() As String
        mDownstreamConditionIndex = -1
        Return GetNextDownstreamConditionSelection()
    End Function

    Public Function GetNextDownstreamConditionSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = CType(CrossSection.Value, CrossSections)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        mDownstreamConditionIndex += 1
        If (mDownstreamConditionIndex < DownstreamConditions.HighLimit) Then
            If ((DownstreamConditionSelections(mDownstreamConditionIndex).Flags And _flags) = 0) Then
                Return DownstreamConditionSelections(mDownstreamConditionIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function

#End Region

#Region " Bottom Description "
    '
    ' Bottom Description selection
    '
    Public Const sBottomDescription As String = "Bottom Description"

    Public ReadOnly Property BottomDescriptionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sBottomDescription)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _intParam As IntegerParameter = New IntegerParameter(DefaultBottomDescription)
                mMyStore.AddProperty(sBottomDescription, _intParam)
                _propertyNode = mMyStore.GetProperty(sBottomDescription)
            End If
            '
            ' Bottom Description options are limited for EVALUE
            '
            Dim worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
            If (worldType = WorldTypes.EventWorld) Then
                Dim eventCriteria As EventCriteria = mUnit.EventCriteriaRef
                Dim analysisType As EventAnalysisTypes = eventCriteria.EventAnalysisType.Value
                If (analysisType = EventAnalysisTypes.EvalueAnalysis) Then
                    Dim inflowManagment As InflowManagement = mUnit.InflowManagementRef
                    If (inflowManagment.FlowDepthsMeasured.Value) Then
                        Dim _param As Parameter = _propertyNode.GetParameter
                        Dim _intParam As IntegerParameter = DirectCast(_param, IntegerParameter)
                        _intParam.Value = BottomDescriptions.ElevationTable
                    End If
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property BottomDescription() As IntegerParameter
        Get
            Return BottomDescriptionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            BottomDescriptionProperty.SetParameter(Value)
        End Set
    End Property

    Private mBottomDescriptionIndex As Integer = -1
    Public Function GetFirstBottomDescriptionSelection() As String
        mBottomDescriptionIndex = -1
        Return GetNextBottomDescriptionSelection()
    End Function
    Public Function GetNextBottomDescriptionSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = CType(CrossSection.Value, CrossSections)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        Dim inflowManagment As InflowManagement = mUnit.InflowManagementRef
        Dim eventCriteria As EventCriteria = mUnit.EventCriteriaRef

        mBottomDescriptionIndex += 1
        If (mBottomDescriptionIndex < BottomDescriptions.HighLimit) Then
            If ((BottomDescriptionSelections(mBottomDescriptionIndex).Flags And _flags) = 0) Then
                '
                ' Bottom Description options are limited for EVALUE
                '
                If (_worldType = WorldTypes.EventWorld) Then
                    Dim _analysisType As EventAnalysisTypes = eventCriteria.EventAnalysisType.Value
                    If (_analysisType = EventAnalysisTypes.EvalueAnalysis) Then
                        If (inflowManagment.FlowDepthsMeasured.Value) Then
                            If (mBottomDescriptionIndex = BottomDescriptions.ElevationTable) Then
                                Return BottomDescriptionSelections(mBottomDescriptionIndex).Value
                            Else
                                Return String.Empty
                            End If
                        Else
                            Return BottomDescriptionSelections(mBottomDescriptionIndex).Value
                        End If
                    Else
                        Return BottomDescriptionSelections(mBottomDescriptionIndex).Value
                    End If
                Else
                    Return BottomDescriptionSelections(mBottomDescriptionIndex).Value
                End If
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function
    '
    ' Slope (S)
    '
    Public Const sSlope As String = "Slope"
    Public Const sS0 As String = "S0"

    Public ReadOnly Property SlopeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSlope)

            ' If it was not found; create it
            Dim defaultSlope As Double

            Select Case (DefaultCrossSection)
                Case CrossSections.Basin, CrossSections.Border
                    defaultSlope = DefaultBasinBorderSlope
                Case Else ' Assume CrossSections.Furrow
                    defaultSlope = DefaultFurrowSlope
            End Select

            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(defaultSlope, Units.MetersPerMeter)
                _double.MinValue = MinimunAdverseSlope
                mMyStore.AddProperty(sSlope, sS0, _double)
                _propertyNode = mMyStore.GetProperty(sSlope)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = MinimunAdverseSlope
            End If

            _propertyNode.Symbol = sS0
            Return _propertyNode
        End Get
    End Property

    Public Property Slope() As DoubleParameter
        Get
            Dim _double As DoubleParameter = SlopeProperty.GetDoubleParameter()
            _double.MinValue = MinimunAdverseSlope
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            SlopeProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Slope Table
    '
    Public Const sSlopeTable As String = "Slope Table"

    Public ReadOnly Property SlopeTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSlopeTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _slopeTable As DataSet = New DataSet(sSlopeTable)

                ResetSlopeTable(_slopeTable, Slope.Value)

                Dim _parameter As DataSetParameter = New DataSetParameter(_slopeTable)
                mMyStore.AddProperty(sSlopeTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sSlopeTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SlopeTable() As DataSetParameter
        Get
            Dim _set As DataSetParameter = SlopeTableProperty.GetDataSetParameter()

            If Not (_set.Value Is Nothing) Then

                For Each _table As DataTable In _set.Value.Tables
                    If (_table.Columns(0).ColumnName = "#") Then
                        _table.Columns.RemoveAt(0)
                    End If
                Next

            End If

            Return _set
        End Get
        Set(ByVal Value As DataSetParameter)
            SlopeTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sSlopeVariation As String = "Slope Variation"

    Public ReadOnly Property SlopeVariationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSlopeVariation)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultSlopeVariation)
                mMyStore.AddProperty(sSlopeVariation, _parameter)
                _propertyNode = mMyStore.GetProperty(sSlopeVariation)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SlopeVariation() As IntegerParameter
        Get
            Return SlopeVariationProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            SlopeVariationProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetSlopeTable(ByVal _slopeTable As DataSet, ByVal _slope As Double)

        ' Remove the previous data
        _slopeTable.Tables.Clear()
        '
        ' Slope Table must have an entry for Time = 0
        '
        Dim _timeLabel As String = "Time " + UnitTextWithUnits(0.0, Units.Seconds)
        Dim _timeTable As DataTable = New DataTable(_timeLabel)

        ' Add the columns
        _timeTable.Columns.Add(sDistanceX, GetType(Double))
        _timeTable.Columns.Add(sSlopeX, GetType(Double))

        ' Add the row(s) of reset data
        Dim _slopeRow As DataRow = _timeTable.NewRow
        _slopeRow.Item(nDistanceX) = 0.0
        _slopeRow.Item(nSlopeX) = _slope
        _timeTable.Rows.Add(_slopeRow)

        ' Add time table to slope table
        _slopeTable.Tables.Add(_timeTable)

    End Sub
    '
    ' Elevation Table
    '
    Public Const sElevation As String = "Elevation"
    Public Const sElevationTable As String = "Elevation Table"

    Public ReadOnly Property ElevationTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sElevationTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _elevationTable As DataSet = New DataSet(sElevationTable)

                ResetElevationTable(_elevationTable, Length.Value, Slope.Value)

                Dim _parameter As DataSetParameter = New DataSetParameter(_elevationTable)
                mMyStore.AddProperty(sElevationTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sElevationTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ElevationTable() As DataSetParameter
        Get
            Dim _set As DataSetParameter = ElevationTableProperty.GetDataSetParameter()

            If Not (_set.Value Is Nothing) Then

                For Each _table As DataTable In _set.Value.Tables
                    If (_table.Columns(0).ColumnName = "#") Then
                        _table.Columns.RemoveAt(0)
                    End If
                Next

            End If

            Return _set
        End Get
        Set(ByVal Value As DataSetParameter)
            ElevationTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sElevationVariation As String = "Elevation Variation"

    Public ReadOnly Property ElevationVariationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sElevationVariation)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultElevationVariation)
                mMyStore.AddProperty(sElevationVariation, _parameter)
                _propertyNode = mMyStore.GetProperty(sElevationVariation)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ElevationVariation() As IntegerParameter
        Get
            Return ElevationVariationProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            ElevationVariationProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetElevationTable(ByVal _elevationTable As DataSet, _
                                   ByVal _length As Double, ByVal _slope As Double)

        ' Remove the previous data
        _elevationTable.Tables.Clear()
        '
        ' Elevation Table must have an entry for Time = 0
        '
        Dim _timeLabel As String = "Time " + UnitTextWithUnits(0.0, Units.Seconds)
        Dim _timeTable As DataTable = New DataTable(_timeLabel)

        ' Add the columns
        _timeTable.Columns.Add(sDistanceX, GetType(Double))
        _timeTable.Columns.Add(sElevationX, GetType(Double))

        ' Add the rows of reset data
        Dim _elevationRow As DataRow = _timeTable.NewRow
        _elevationRow.Item(nDistanceX) = 0.0
        _elevationRow.Item(nElevationX) = _length * _slope
        _timeTable.Rows.Add(_elevationRow)

        _elevationRow = _timeTable.NewRow
        _elevationRow.Item(nDistanceX) = _length
        _elevationRow.Item(nElevationX) = 0.0
        _timeTable.Rows.Add(_elevationRow)

        ' Add time table to elevation table
        _elevationTable.Tables.Add(_timeTable)

    End Sub

    Public Function TabulatedElevationDistances() As List(Of Double)

        TabulatedElevationDistances = New List(Of Double)

        Select Case (Me.BottomDescription.Value)

            Case BottomDescriptions.SlopeTable

                Dim table As DataTable = Me.SlopeTable.Value.Tables(0)
                If (table IsNot Nothing) Then
                    For Each row As DataRow In table.Rows
                        TabulatedElevationDistances.Add(CDbl(row(sDistanceX)))
                    Next
                End If

            Case BottomDescriptions.ElevationTable

                Dim table As DataTable = Me.ElevationTable.Value.Tables(0)
                If (table IsNot Nothing) Then
                    For Each row As DataRow In table.Rows
                        TabulatedElevationDistances.Add(CDbl(row(sDistanceX)))
                    Next
                End If

        End Select

        If (0 = TabulatedElevationDistances.Count) Then
            TabulatedElevationDistances = Nothing
        End If

    End Function

    Public Function NumElevationDistances() As Integer
        NumElevationDistances = 0
        Dim table As DataTable = Me.ElevationTable.Value.Tables(0)
        If (table IsNot Nothing) Then
            NumElevationDistances = table.Rows.Count
        End If
    End Function
    '
    ' Translate an Elevation Table into a Slope Table
    '
    ' NOTE - an Elevation Table has one more DataRow than a Slope Table
    '
    Public Function SlopeTableFromElevationTable(ByVal _elevationDataSet As DataSet) As DataSet

        ' Create a new Slope Table
        Dim _slopeTable As DataSet = New DataSet(sSlopeTable)

        ' Copy all Times from the Elevation Table to the Slope Table
        For Each _elevationTimeTable As DataTable In _elevationDataSet.Tables

            ' Create a new Time Table for the Slope Table
            Dim _slopeTimeTable As DataTable = New DataTable(_elevationTimeTable.TableName)

            ' Add the columns
            _slopeTimeTable.Columns.Add(sDistanceX, GetType(Double))
            _slopeTimeTable.Columns.Add(sSlopeX, GetType(Double))

            ' Get the first Distance & Elevation
            Dim _elevationRow As DataRow = _elevationTimeTable.Rows(0)
            Dim _dist1 As Double = CDbl(_elevationRow.Item(nDistanceX))
            Dim _elev1 As Double = CDbl(_elevationRow.Item(nElevationX))

            ' Translate the row data from the Elevation Table to the Slope Table
            For _row As Integer = 1 To _elevationTimeTable.Rows.Count - 1

                ' Get the next Distance & Elevation
                _elevationRow = _elevationTimeTable.Rows(_row)
                Dim _dist2 As Double = CDbl(_elevationRow.Item(nDistanceX))
                Dim _elev2 As Double = CDbl(_elevationRow.Item(nElevationX))

                ' Calculate the slope between the next two distances
                Dim _slope As Double = (_elev1 - _elev2) / (_dist2 - _dist1)

                ' Create a new Data Row for the Slope Table
                Dim _slopeRow As DataRow = _slopeTimeTable.NewRow

                ' Translate row data
                _slopeRow.Item(nDistanceX) = _dist1
                _slopeRow.Item(nSlopeX) = _slope
                _slopeTimeTable.Rows.Add(_slopeRow)

                ' Seed for next loop iteration
                _dist1 = _dist2
                _elev1 = _elev2
            Next

            _slopeTable.Tables.Add(_slopeTimeTable)
        Next

        Return _slopeTable

    End Function
    '
    ' Translate a Slope Table into an Elevation Table
    '
    ' NOTE - an Elevation Table has one more DataRow than a Slope Table
    '
    Public Function ElevationTableFromSlopeTable(ByVal _slopeDataSet As DataSet) As DataSet

        Dim _elevationTable As DataSet = New DataSet(sElevationTable)

        ' Copy all Times from the Slope Table to the Elevation Table
        For Each _slopeTimeTable As DataTable In _slopeDataSet.Tables

            ' Create a new Time Table for the Elevation Table
            Dim _elevationTimeTable As DataTable = New DataTable(_slopeTimeTable.TableName)

            ' Add the columns
            _elevationTimeTable.Columns.Add(sDistanceX, GetType(Double))
            _elevationTimeTable.Columns.Add(sElevationX, GetType(Double))

            ' Get the last Distance & Elevation
            Dim _dist2 As Double = Length.Value
            Dim _elev2 As Double = 0.0

            ' Create a new Data Row for the Elevation Table
            Dim _elevationRow As DataRow = _elevationTimeTable.NewRow

            ' Translate row data for end of field
            _elevationRow.Item(nDistanceX) = _dist2
            _elevationRow.Item(nElevationX) = _elev2
            _elevationTimeTable.Rows.InsertAt(_elevationRow, 0)

            ' Translate the row data from the Slope Table to the Elevation Table
            For _row As Integer = _slopeTimeTable.Rows.Count - 1 To 0 Step -1

                ' Get the previous Distance & Slope
                Dim _slopeRow As DataRow = _slopeTimeTable.Rows(_row)
                Dim _dist1 As Double = CDbl(_slopeRow.Item(nDistanceX))
                Dim _slope As Double = CDbl(_slopeRow.Item(nSlopeX))

                ' Calculate the elevation between the last two distances
                Dim _elev1 As Double = (_slope * (_dist2 - _dist1)) + _elev2

                ' Create a new Data Row for the Elevation Table
                _elevationRow = _elevationTimeTable.NewRow

                ' Translate row data
                _elevationRow.Item(nDistanceX) = _dist1
                _elevationRow.Item(nElevationX) = _elev1
                _elevationTimeTable.Rows.InsertAt(_elevationRow, 0)

                ' Seed for next loop iteration
                _dist2 = _dist1
                _elev2 = _elev1
            Next

            _elevationTable.Tables.Add(_elevationTimeTable)
        Next

        Return _elevationTable

    End Function
    '
    ' Compute the average slope from an Elevation Table
    '
    Public Function AverageSlopeFromElevationTable() As Double
        ' Return the average slope from the current System Geometry Elevation Table
        Dim _elevationParameter As DataSetParameter = Me.ElevationTable
        Dim _elevationDataSet As DataSet = _elevationParameter.Value
        Dim _averageSlope As Double = AverageSlopeFromElevationTable(_elevationDataSet)
        Return _averageSlope
    End Function

    Public Function AverageSlopeFromElevationTable(ByVal _elevationDataSet As DataSet) As Double
        ' Validate input parameters
        If (_elevationDataSet Is Nothing) Then
            Debug.Assert(False, "Elevation DataSet is Nothing")
            Return 0.0
        Else
            If (_elevationDataSet.Tables.Count <= 0) Then
                Debug.Assert(False, "Elevation DataSet is empty")
                Return 0.0
            End If
        End If

        ' Return the average slope from the input Elevation DataSet
        Dim _slopeTable As DataTable = _elevationDataSet.Tables(0)
        Dim _averageSlope As Double = AverageSlopeFromElevationTable(_slopeTable)

        Return _averageSlope
    End Function

    Public Function AverageSlopeFromElevationTable(ByVal _elevationTable As DataTable) As Double
        ' Validate input parameters
        If (_elevationTable Is Nothing) Then
            Debug.Assert(False, "Elevation DataTable is Nothing")
            Return 0.0
        Else
            If (_elevationTable.Rows.Count <= 1) Then
                Debug.Assert(False, "Elevation DataTable is empty")
                Return 0.0
            End If
        End If

        ' Return the average slope from the input Elevation DataTable
        Dim _dataRow As DataRow = _elevationTable.Rows(0)                   ' Elevation at first point
        Dim _dist1 As Double = CDbl(_dataRow.Item(nDistanceX))
        Dim _elev1 As Double = CDbl(_dataRow.Item(nElevationX))

        _dataRow = _elevationTable.Rows(_elevationTable.Rows.Count - 1)     ' Elevation at last point
        Dim _dist2 As Double = CDbl(_dataRow.Item(nDistanceX))
        Dim _elev2 As Double = CDbl(_dataRow.Item(nElevationX))

        Dim _averageSlope As Double = (_elev1 - _elev2) / (_dist2 - _dist1)

        Return _averageSlope

    End Function
    '
    ' Compute the least slope (i.e. most negative) from an Elevation Table
    '
    Public Function LeastSlopeFromElevationTable() As Double
        ' Return the least slope from the current System Geometry Elevation Table
        Dim _elevationParameter As DataSetParameter = Me.ElevationTable
        Dim _elevationDataSet As DataSet = _elevationParameter.Value
        Dim _leastSlope As Double = LeastSlopeFromElevationTable(_elevationDataSet)
        Return _leastSlope
    End Function

    Public Function LeastSlopeFromElevationTable(ByVal _elevationDataSet As DataSet) As Double
        ' Validate input parameters
        If (_elevationDataSet Is Nothing) Then
            Debug.Assert(False, "Elevation DataSet is Nothing")
            Return 0.0
        Else
            If (_elevationDataSet.Tables.Count <= 0) Then
                Debug.Assert(False, "Elevation DataSet is empty")
                Return 0.0
            End If
        End If

        ' Return the least slope from the input Elevation DataSet
        Dim _slopeTable As DataTable = _elevationDataSet.Tables(0)
        Dim _leastSlope As Double = LeastSlopeFromElevationTable(_slopeTable)

        Return _leastSlope
    End Function

    Public Function LeastSlopeFromElevationTable(ByVal _elevationTable As DataTable) As Double
        ' Validate input parameters
        If (_elevationTable Is Nothing) Then
            Return 0.0
        Else
            If (_elevationTable.Rows.Count <= 2) Then
                Return 0.0
            End If
        End If

        ' Return the least slope from the input Elevation DataTable
        Dim _leastSlope As Double = 0.0

        Dim _dataRow As DataRow = _elevationTable.Rows(0)                   ' Elevation at first point
        Dim _dist1 As Double = CDbl(_dataRow.Item(nDistanceX))
        Dim _elev1 As Double = CDbl(_dataRow.Item(nElevationX))

        For idx As Integer = 1 To _elevationTable.Rows.Count - 1
            _dataRow = _elevationTable.Rows(idx)                            ' Elevation at next point
            Dim _dist2 As Double = CDbl(_dataRow.Item(nDistanceX))
            Dim _elev2 As Double = CDbl(_dataRow.Item(nElevationX))

            If (_leastSlope > (_elev1 - _elev2) / (_dist2 - _dist1)) Then
                _leastSlope = (_elev1 - _elev2) / (_dist2 - _dist1)
            End If

            _dist1 = _dist2
            _elev1 = _elev2
        Next idx

        Return _leastSlope

    End Function

#End Region

#Region " Border Depth "

    Public Const sEnableTabulatedBorderDepth As String = "Enable Tabulated Border Depth"

    Public ReadOnly Property EnableTabulatedBorderDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableTabulatedBorderDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultEnableTabulatedBorderDepth)
                mMyStore.AddProperty(sEnableTabulatedBorderDepth, _boolean)
                _propertyNode = mMyStore.GetProperty(sEnableTabulatedBorderDepth)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableTabulatedBorderDepth() As BooleanParameter
        Get
            Dim enable As BooleanParameter = EnableTabulatedBorderDepthProperty.GetBooleanParameter()
            '
            ' Tabulated Border Depth is only available in the Simulation World to Advanced Users
            '
            If Not (mUnit.WorldRef.WorldType.Value = WorldTypes.SimulationWorld) Then
                enable.Value = False
            End If

            If (WinSRFR.UserLevel = UserLevels.Standard) Then
                enable.Value = False
            End If

            Return enable
        End Get
        Set(ByVal Value As BooleanParameter)
            EnableTabulatedBorderDepthProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Border Depth Table
    '
    Public Const sBorderDepthTable As String = "Border Depth Table"

    Public ReadOnly Property BorderDepthTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sBorderDepthTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim borderDepthTable As DataTable = New DataTable(sBorderDepthTable)

                ResetBorderDepthTable(borderDepthTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(borderDepthTable)
                mMyStore.AddProperty(sBorderDepthTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sBorderDepthTable)
            Else
                ' Update older tables
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _tableParam As DataTableParameter = DirectCast(_param, DataTableParameter)
                Dim borderDepthTable As DataTable = _tableParam.Value

                borderDepthTable.Columns(1).ExtendedProperties.Clear()
                borderDepthTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property BorderDepthTable() As DataTableParameter
        Get
            Return BorderDepthTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            BorderDepthTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetBorderDepthTable(ByVal BorderDepthTable As DataTable)

        ' Remove the previous data
        BorderDepthTable.Clear()          ' Clear rows
        BorderDepthTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        BorderDepthTable.Columns.Add(sDistanceX, GetType(Double))
        BorderDepthTable.Columns.Add(Srfr.Globals.sDepthMM, GetType(Double))
        BorderDepthTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

        ' Add the row(s) of reset data
        Dim borderDepthRow As DataRow = BorderDepthTable.NewRow
        borderDepthRow.Item(sDistanceX) = 0.0
        borderDepthRow.Item(Srfr.Globals.sDepthMM) = DefaultDepth

        BorderDepthTable.Rows.Add(borderDepthRow)

    End Sub

    Public Function TabulatedGeometryDistances() As List(Of Double)

        TabulatedGeometryDistances = New List(Of Double)

        Select Case (Me.CrossSection.Value)

            Case CrossSections.Basin, CrossSections.Border

                If (Me.EnableTabulatedBorderDepth.Value) Then

                    Dim table As DataTable = Me.BorderDepthTable.Value
                    If (table IsNot Nothing) Then
                        For Each row As DataRow In table.Rows
                            TabulatedGeometryDistances.Add(CDbl(row(sDistanceX)))
                        Next
                    End If
                End If

            Case Else ' Furrow

                If (Me.EnableTabulatedFurrowShape.Value) Then

                    Select Case (Me.FurrowShape.Value)

                        Case FurrowShapes.PowerLaw

                            Dim table As DataTable = Me.PowerLawTable.Value
                            If (table IsNot Nothing) Then
                                For Each row As DataRow In table.Rows
                                    TabulatedGeometryDistances.Add(CDbl(row(sDistanceX)))
                                Next
                            End If

                        Case FurrowShapes.Trapezoid

                            Dim table As DataTable = Me.TrapezoidTable.Value
                            If (table IsNot Nothing) Then
                                For Each row As DataRow In table.Rows
                                    TabulatedGeometryDistances.Add(CDbl(row(sDistanceX)))
                                Next
                            End If
                    End Select
                End If
        End Select

        If (0 = TabulatedGeometryDistances.Count) Then
            TabulatedGeometryDistances = Nothing
        End If

    End Function

#End Region

#Region " Furrow Shape "

    Public Const sFurrowShape As String = "Furrow Shape"

    Public ReadOnly Property FurrowShapeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFurrowShape)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultFurrowShape)
                mMyStore.AddProperty(sFurrowShape, _parameter)
                _propertyNode = mMyStore.GetProperty(sFurrowShape)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property FurrowShape() As IntegerParameter
        Get
            Return FurrowShapeProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            FurrowShapeProperty.SetParameter(Value)
        End Set
    End Property

    Private mFurrowShapeIndex As Integer = -1
    Public Function GetFirstFurrowShapeSelection() As String
        mFurrowShapeIndex = -1
        Return GetNextFurrowShapeSelection()
    End Function
    Public Function GetNextFurrowShapeSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = CType(CrossSection.Value, CrossSections)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        mFurrowShapeIndex += 1
        If (mFurrowShapeIndex < FurrowShapes.HighLimit) Then
            If ((FurrowShapeSelections(mFurrowShapeIndex).Flags And _flags) = 0) Then
                Return FurrowShapeSelections(mFurrowShapeIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function

    Public Const sFurrowFieldDataType As String = "Furrow FieldDataType"

    Public ReadOnly Property FurrowFieldDataTypeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFurrowFieldDataType)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultFurrowFieldDataType)
                mMyStore.AddProperty(sFurrowFieldDataType, _parameter)
                _propertyNode = mMyStore.GetProperty(sFurrowFieldDataType)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property FurrowFieldDataType() As IntegerParameter
        Get
            Return FurrowFieldDataTypeProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            FurrowFieldDataTypeProperty.SetParameter(Value)
        End Set
    End Property

    Private mFurrowFieldDataTypeIndex As Integer = -1
    Public Function GetFirstFurrowFieldDataTypeSelection() As String
        mFurrowFieldDataTypeIndex = -1
        Return GetNextFurrowFieldDataTypeSelection()
    End Function
    Public Function GetNextFurrowFieldDataTypeSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = CType(CrossSection.Value, CrossSections)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        mFurrowFieldDataTypeIndex += 1
        If (mFurrowFieldDataTypeIndex < FurrowFieldDataTypes.HighLimit) Then
            If ((FurrowFieldDataTypeSelections(mFurrowFieldDataTypeIndex).Flags And _flags) = 0) Then
                Return FurrowFieldDataTypeSelections(mFurrowFieldDataTypeIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function

    Public Const sEnableTabulatedFurrowShape As String = "Enable Tabulated Furrow Shape"

    Public ReadOnly Property EnableTabulatedFurrowShapeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableTabulatedFurrowShape)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultEnableTabulatedFurrowShape)
                mMyStore.AddProperty(sEnableTabulatedFurrowShape, _boolean)
                _propertyNode = mMyStore.GetProperty(sEnableTabulatedFurrowShape)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableTabulatedFurrowShape() As BooleanParameter
        Get
            Dim enable As BooleanParameter = EnableTabulatedFurrowShapeProperty.GetBooleanParameter()
            '
            ' Tabulated Furrow Shape is only available in the Simulation World to Advanced Users
            '
            If Not (mUnit.WorldRef.WorldType.Value = WorldTypes.SimulationWorld) Then
                enable.Value = False
            End If

            If (WinSRFR.UserLevel = UserLevels.Standard) Then
                enable.Value = False
            End If

            Return enable
        End Get
        Set(ByVal Value As BooleanParameter)
            EnableTabulatedFurrowShapeProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Bay Geometry "
    '
    ' Length (L)
    '
    Public Const sLength As String = "Length"
    Public Const sL As String = "L"

    Public ReadOnly Property LengthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sLength)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(Globals.DefaultLength, Units.Meters)
                _parameter.MinValue = Globals.MinimumLength
                _parameter.MaxValue = Globals.MaximumLength
                mMyStore.AddProperty(sLength, sL, _parameter)
                _propertyNode = mMyStore.GetProperty(sLength)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Length() As DoubleParameter
        Get
            Return LengthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            LengthProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Width (W)
    '
    Public Const sWidth As String = "Width"
    Public Const sW As String = "W"

    Public ReadOnly Property WidthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWidth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(Globals.DefaultWidth, Units.Meters)
                _parameter.MinValue = Globals.MinimumWidth
                _parameter.MaxValue = Globals.MaximumWidth
                mMyStore.AddProperty(sWidth, sW, _parameter)
                _propertyNode = mMyStore.GetProperty(sWidth)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Width() As DoubleParameter
        Get
            Dim _double As DoubleParameter = WidthProperty.GetDoubleParameter()

            If (Me.CrossSection.Value = CrossSections.Furrow) Then
                Dim furrowSpacing As Double = Me.FurrowSpacing.Value
                Dim furrowsPerSet As Double = Me.FurrowsPerSet.Value
                Dim furrowSetWidth As Double = furrowSpacing * furrowsPerSet

                _double.Value = furrowSetWidth
            End If

            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            WidthProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Depth
    '
    Public Const sOverflowDepth As String = "Overflow Depth"
    Public Const sDepth As String = "Depth"
    Public Const sY As String = "Y"

    Public ReadOnly Property DepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepth)

            ' If not found, try deprecated name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sOverflowDepth)

                ' If deprecated name was found; update it
                If (_propertyNode IsNot Nothing) Then
                    _propertyNode.MyID = sDepth
                End If
            End If

            ' If still not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(Globals.DefaultDepth, Units.Millimeters)
                _parameter.MinValue = Globals.MinimumDepth
                _parameter.MaxValue = Globals.MaximumDepth
                mMyStore.AddProperty(sDepth, sY, _parameter)
                _propertyNode = mMyStore.GetProperty(sDepth)
            End If

            _propertyNode.Symbol = sY
            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property Depth() As DoubleParameter
        Get
            Return DepthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            DepthProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Furrow Spacing
    '
    Public Const sFurrowSpacing As String = "Furrow Spacing"

    Public ReadOnly Property FurrowSpacingProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFurrowSpacing)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultFurrowSpacing, Units.Meters)
                mMyStore.AddProperty(sFurrowSpacing, _parameter)
                _propertyNode = mMyStore.GetProperty(sFurrowSpacing)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property FurrowSpacing() As DoubleParameter
        Get
            Return FurrowSpacingProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            FurrowSpacingProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Furrows Per Set
    '
    Public Const sFurrowsPerSet As String = "Furrows Per Set"

    Public ReadOnly Property FurrowsPerSetProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFurrowsPerSet)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _param As Parameter = Me.WidthProperty.GetParameter
                Dim _width As DoubleParameter = DirectCast(_param, DoubleParameter)
                Dim fps As Double = CInt(_width.Value / FurrowSpacing.Value)
                Dim _parameter As DoubleParameter = New DoubleParameter(fps, Units.None)
                mMyStore.AddProperty(sFurrowsPerSet, _parameter)
                _propertyNode = mMyStore.GetProperty(sFurrowsPerSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property FurrowsPerSet() As DoubleParameter
        Get
            FurrowsPerSet = FurrowsPerSetProperty.GetDoubleParameter()
            If (FurrowsPerSet.Value < 1.0) Then
                FurrowsPerSet.Value = 1.0
            End If
        End Get
        Set(ByVal Value As DoubleParameter)
            If (Value.Value < 1.0) Then
                Value.Value = 1.0
            End If
            FurrowsPerSetProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Surface Shape Factors
    '
    Public Const sSurfaceShapeFactor1 As String = "Surface Shape Factor"

    Public ReadOnly Property SurfaceShapeFactor1Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurfaceShapeFactor1)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultSurfaceShapeFactor1, Units.None)
                mMyStore.AddProperty(sSurfaceShapeFactor1, _parameter)
                _propertyNode = mMyStore.GetProperty(sSurfaceShapeFactor1)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SurfaceShapeFactor1() As DoubleParameter
        Get
            Return SurfaceShapeFactor1Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SurfaceShapeFactor1Property.SetParameter(Value)
        End Set
    End Property


    Public Const sSurfaceShapeFactor2 As String = "Surface Shape Factor 2"

    Public ReadOnly Property SurfaceShapeFactor2Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurfaceShapeFactor2)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultSurfaceShapeFactor2, Units.None)
                mMyStore.AddProperty(sSurfaceShapeFactor2, _parameter)
                _propertyNode = mMyStore.GetProperty(sSurfaceShapeFactor2)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SurfaceShapeFactor2() As DoubleParameter
        Get
            Return SurfaceShapeFactor2Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SurfaceShapeFactor2Property.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Furrow Geometry "

#Region " Trapezoid Furrow "
    '
    ' Trapezoid Furrow
    '
    Public Const sBottomWidth As String = "Bottom Width"

    Public ReadOnly Property BottomWidthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sBottomWidth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultBottomWidth, Units.Millimeters)
                mMyStore.AddProperty(sBottomWidth, _parameter)
                _propertyNode = mMyStore.GetProperty(sBottomWidth)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property BottomWidth() As DoubleParameter
        Get
            Return BottomWidthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            BottomWidthProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sSideSlope As String = "Side Slope"

    Public ReadOnly Property SideSlopeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSideSlope)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultSideSlope, Units.HorzPerVert)
                mMyStore.AddProperty(sSideSlope, _parameter)
                _propertyNode = mMyStore.GetProperty(sSideSlope)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SideSlope() As DoubleParameter
        Get
            Return SideSlopeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SideSlopeProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sMaximumDepth As String = "Maximum Depth"

    Public ReadOnly Property MaximumDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaximumDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMaximumDepth, Units.Millimeters)
                mMyStore.AddProperty(sMaximumDepth, _parameter)
                _propertyNode = mMyStore.GetProperty(sMaximumDepth)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property MaximumDepth() As DoubleParameter
        Get
            Return MaximumDepthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaximumDepthProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Tabulated Trapezoid Furrow "
    '
    ' Trapezoid Furrow Table
    '
    Public Const sTrapezoidTable As String = "Trapezoid Table"

    Public ReadOnly Property TrapezoidTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTrapezoidTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim trapezoidTable As DataTable = New DataTable(sTrapezoidTable)

                ResetTrapezoidTable(trapezoidTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(trapezoidTable)
                mMyStore.AddProperty(sTrapezoidTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sTrapezoidTable)
            Else
                ' Update older tables
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _tableParam As DataTableParameter = DirectCast(_param, DataTableParameter)
                Dim trapezoidTable As DataTable = _tableParam.Value

                trapezoidTable.Columns(1).ExtendedProperties.Clear()
                trapezoidTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

                trapezoidTable.Columns(3).ExtendedProperties.Clear()
                trapezoidTable.Columns(3).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property TrapezoidTable() As DataTableParameter
        Get
            Return TrapezoidTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            TrapezoidTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetTrapezoidTable(ByVal TrapezoidTable As DataTable)

        ' Remove the previous data
        TrapezoidTable.Clear()          ' Clear rows
        TrapezoidTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        TrapezoidTable.Columns.Add(sDistanceX, GetType(Double))

        TrapezoidTable.Columns.Add(Srfr.Globals.sBWmm, GetType(Double))
        TrapezoidTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

        TrapezoidTable.Columns.Add(Srfr.Globals.sSS, GetType(Double))

        TrapezoidTable.Columns.Add(Srfr.Globals.sDepthMM, GetType(Double))
        TrapezoidTable.Columns(3).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

        ' Add the row(s) of reset data
        Dim trapezoidRow As DataRow = TrapezoidTable.NewRow
        trapezoidRow.Item(sDistanceX) = 0.0
        trapezoidRow.Item(Srfr.Globals.sBWmm) = DefaultBottomWidth
        trapezoidRow.Item(Srfr.Globals.sSS) = DefaultSideSlope
        trapezoidRow.Item(Srfr.Globals.sDepthMM) = DefaultDepth

        TrapezoidTable.Rows.Add(trapezoidRow)

    End Sub

#End Region

#Region " Power Law Furrow "
    '
    ' Power Law Furrow
    '
    Public Const sWidthAt100mm As String = "Width At 100mm"

    Public ReadOnly Property WidthAt100mmProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWidthAt100mm)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultWidthAt100mm, Units.Millimeters)
                mMyStore.AddProperty(sWidthAt100mm, _parameter)
                _propertyNode = mMyStore.GetProperty(sWidthAt100mm)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property WidthAt100mm() As DoubleParameter
        Get
            Return WidthAt100mmProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            WidthAt100mmProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sExponent As String = "Exponent"

    Public ReadOnly Property PowerLawExponentProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sExponent)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultPowerLawExponent, Units.None)
                mMyStore.AddProperty(sExponent, _parameter)
                _propertyNode = mMyStore.GetProperty(sExponent)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property PowerLawExponent() As DoubleParameter
        Get
            Return PowerLawExponentProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            PowerLawExponentProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Tabulated Power Law Furrow "
    '
    ' Power Law Furrow Table
    '
    Public Const sPowerLawTable As String = "Power Law Table"

    Public ReadOnly Property PowerLawTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPowerLawTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim powerLawTable As DataTable = New DataTable(sPowerLawTable)

                ResetPowerLawTable(powerLawTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(powerLawTable)
                mMyStore.AddProperty(sPowerLawTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sPowerLawTable)
            Else
                ' Update older tables
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _tableParam As DataTableParameter = DirectCast(_param, DataTableParameter)
                Dim powerLawTable As DataTable = _tableParam.Value

                powerLawTable.Columns(1).ExtendedProperties.Clear()
                powerLawTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

                powerLawTable.Columns(3).ExtendedProperties.Clear()
                powerLawTable.Columns(3).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property PowerLawTable() As DataTableParameter
        Get
            Return PowerLawTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            PowerLawTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetPowerLawTable(ByVal PowerLawTable As DataTable)

        ' Remove the previous data
        PowerLawTable.Clear()          ' Clear rows
        PowerLawTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        PowerLawTable.Columns.Add(sDistanceX, GetType(Double))

        PowerLawTable.Columns.Add(Srfr.Globals.sW100mm, GetType(Double))
        PowerLawTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

        PowerLawTable.Columns.Add(Srfr.Globals.sM, GetType(Double))

        PowerLawTable.Columns.Add(Srfr.Globals.sDepthMM, GetType(Double))
        PowerLawTable.Columns(3).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

        ' Add the row(s) of reset data
        Dim powerLawRow As DataRow = PowerLawTable.NewRow
        powerLawRow.Item(sDistanceX) = 0.0
        powerLawRow.Item(Srfr.Globals.sW100mm) = DefaultWidthAt100mm
        powerLawRow.Item(Srfr.Globals.sM) = DefaultPowerLawExponent
        powerLawRow.Item(Srfr.Globals.sDepthMM) = DefaultDepth

        PowerLawTable.Rows.Add(powerLawRow)

    End Sub

#End Region

#Region " Flow Cross Section Furrow "
    '
    ' Flow Cross Section Furrow
    '
    Public Const sTopSectionWidth As String = "Top Section Width"

    Public ReadOnly Property TopSectionWidthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTopSectionWidth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultTopSectionWidth, Units.Millimeters)
                mMyStore.AddProperty(sTopSectionWidth, _parameter)
                _propertyNode = mMyStore.GetProperty(sTopSectionWidth)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property TopSectionWidth() As DoubleParameter
        Get
            Return TopSectionWidthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            TopSectionWidthProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sMiddleSectionWidth As String = "Middle Section Width"

    Public ReadOnly Property MiddleSectionWidthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMiddleSectionWidth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultMiddleSectionWidth, Units.Millimeters)
                mMyStore.AddProperty(sMiddleSectionWidth, _parameter)
                _propertyNode = mMyStore.GetProperty(sMiddleSectionWidth)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property MiddleSectionWidth() As DoubleParameter
        Get
            Return MiddleSectionWidthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MiddleSectionWidthProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sBottomSectionWidth As String = "Bottom Section Width"

    Public ReadOnly Property BottomSectionWidthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sBottomSectionWidth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultBottomSectionWidth, Units.Millimeters)
                mMyStore.AddProperty(sBottomSectionWidth, _parameter)
                _propertyNode = mMyStore.GetProperty(sBottomSectionWidth)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property BottomSectionWidth() As DoubleParameter
        Get
            Return BottomSectionWidthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            BottomSectionWidthProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sSectionDepth As String = "Section Depth"

    Public ReadOnly Property SectionDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSectionDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultSectionDepth, Units.Millimeters)
                mMyStore.AddProperty(sSectionDepth, _parameter)
                _propertyNode = mMyStore.GetProperty(sSectionDepth)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property SectionDepth() As DoubleParameter
        Get
            Return SectionDepthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SectionDepthProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Profilometer Furrow "
    '
    ' Profilometer Rods
    '
    Public Const sNoOfRods As String = "Number of Rods"

    Public ReadOnly Property NoOfRodsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNoOfRods)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultNoOfRods)
                mMyStore.AddProperty(sNoOfRods, _parameter)
                _propertyNode = mMyStore.GetProperty(sNoOfRods)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property NoOfRods() As IntegerParameter
        Get
            Return NoOfRodsProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            NoOfRodsProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sRodSpacing As String = "Rod Spacing"

    Public ReadOnly Property RodSpacingProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRodSpacing)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultRodSpacing, Units.Millimeters)
                mMyStore.AddProperty(sRodSpacing, _parameter)
                _propertyNode = mMyStore.GetProperty(sRodSpacing)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property RodSpacing() As DoubleParameter
        Get
            Return RodSpacingProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            RodSpacingProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Profilometer Data Table
    '
    Public Const sProfilometerTable As String = "Profilometer Table"

    Public ReadOnly Property ProfilometerTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sProfilometerTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                ' Build default Profilometer Table
                Dim _profilometerTable As DataTable = New DataTable(sProfilometerTable)

                ResetProfilometerTable(_profilometerTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(_profilometerTable)
                mMyStore.AddProperty(sProfilometerTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sProfilometerTable)
            Else
                ' Update older tables
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _tableParam As DataTableParameter = DirectCast(_param, DataTableParameter)
                Dim _profilometerTable As DataTable = _tableParam.Value

                _profilometerTable.Columns(0).ExtendedProperties.Clear()
                _profilometerTable.Columns(0).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

                _profilometerTable.Columns(1).ExtendedProperties.Clear()
                _profilometerTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ProfilometerTable() As DataTableParameter
        Get
            Dim _table As DataTableParameter = ProfilometerTableProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            ProfilometerTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetProfilometerTable(ByVal _profilometerTable As DataTable)

        ' Remove the previous data
        _profilometerTable.Clear()
        _profilometerTable.Columns.Clear()

        ' Add the columns
        _profilometerTable.Columns.Add(sRodLocationX, GetType(Double))
        _profilometerTable.Columns(0).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

        _profilometerTable.Columns.Add(sRodDepthX, GetType(Double))
        _profilometerTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

        ' Add the rows of reset data
        Dim _profilometerRod As DataRow = _profilometerTable.NewRow
        Dim _halfNoOfRods As Integer = (DefaultNoOfRods - 1) / 2
        Debug.Assert(DefaultNoOfRods = (_halfNoOfRods * 2) + 1, "DefaultNoOfRods must be odd")

        ' Left half of Profilometer table
        For pdx As Integer = 0 To _halfNoOfRods - 1
            _profilometerRod = _profilometerTable.NewRow
            _profilometerRod.Item(sRodLocationX) = (pdx - _halfNoOfRods) * DefaultRodSpacing
            _profilometerRod.Item(sRodDepthX) = pdx * DefaultMaximumDepth / (_halfNoOfRods - 1)
            _profilometerTable.Rows.Add(_profilometerRod)
        Next pdx

        ' Center of table
        _profilometerRod = _profilometerTable.NewRow
        _profilometerRod.Item(sRodLocationX) = 0.0
        _profilometerRod.Item(sRodDepthX) = DefaultMaximumDepth
        _profilometerTable.Rows.Add(_profilometerRod)

        ' Right half is reflection of left half
        For pdx As Integer = _halfNoOfRods + 1 To DefaultNoOfRods - 1
            _profilometerRod = _profilometerTable.NewRow
            _profilometerRod.Item(sRodLocationX) = -(_profilometerTable.Rows(DefaultNoOfRods - pdx - 1).Item(0))
            _profilometerRod.Item(sRodDepthX) = _profilometerTable.Rows(DefaultNoOfRods - pdx - 1).Item(1)
            _profilometerTable.Rows.Add(_profilometerRod)
        Next pdx

    End Sub

#End Region

#Region " Depth/Width Table Furrow "
    '
    ' Depth/Width Data Table
    '
    Public Const sHeightWidthTable As String = "Height / Width Table"
    Public Const sDepthWidthTable As String = "Depth / Width Table"

    Public ReadOnly Property DepthWidthTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepthWidthTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                ' Build default DepthWidth Table
                Dim _depthWidthTable As DataTable = New DataTable(sDepthWidthTable)

                ResetDepthWidthTable(_depthWidthTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(_depthWidthTable)
                mMyStore.AddProperty(sDepthWidthTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sDepthWidthTable)
            Else
                ' Update older tables
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _tableParam As DataTableParameter = DirectCast(_param, DataTableParameter)
                Dim _depthWidthTable As DataTable = _tableParam.Value

                _depthWidthTable.Columns(0).ExtendedProperties.Clear()
                _depthWidthTable.Columns(0).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

                _depthWidthTable.Columns(1).ExtendedProperties.Clear()
                _depthWidthTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepthWidthTable() As DataTableParameter
        Get
            Dim _table As DataTableParameter = DepthWidthTableProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            DepthWidthTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetDepthWidthTable(ByVal _depthWidthTable As DataTable)

        ' Remove the previous data
        _depthWidthTable.Clear()
        _depthWidthTable.Columns.Clear()

        ' Add the columns
        _depthWidthTable.Columns.Add(sDepthX, GetType(Double))
        _depthWidthTable.Columns(0).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

        _depthWidthTable.Columns.Add(sWidthX, GetType(Double))
        _depthWidthTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.ShapeUnitSet)

        ' Add the rows of reset data
        Dim _depthWidthRow As DataRow = _depthWidthTable.NewRow
        _depthWidthRow.Item(sDepthX) = DefaultSectionDepth
        _depthWidthRow.Item(sWidthX) = DefaultTopSectionWidth
        _depthWidthTable.Rows.Add(_depthWidthRow)

        _depthWidthRow = _depthWidthTable.NewRow
        _depthWidthRow.Item(sDepthX) = DefaultSectionDepth / 2.0
        _depthWidthRow.Item(sWidthX) = DefaultMiddleSectionWidth
        _depthWidthTable.Rows.Add(_depthWidthRow)

        _depthWidthRow = _depthWidthTable.NewRow
        _depthWidthRow.Item(sDepthX) = 0.0
        _depthWidthRow.Item(sWidthX) = DefaultBottomSectionWidth
        _depthWidthTable.Rows.Add(_depthWidthRow)

    End Sub

#End Region

#End Region

#End Region

#Region " Calculated Properties "

#Region " Cross Section "

    Public Function CrossSectionName() As String
        Dim name As String

        Select Case (CrossSection.Value)
            Case CrossSections.Basin, CrossSections.Border
                name = mDictionary.tBorder.Translated
            Case Else ' Assume CrossSections.Furrow
                If (1 < FurrowsPerSet.Value) Then
                    name = mDictionary.tFurrowSet.Translated
                Else
                    name = mDictionary.tFurrow.Translated
                End If
        End Select

        Return name
    End Function

#End Region

#Region " Wetted Perimeter "

    Public Function WettedPerimeter(ByVal Y As Double) As Double
        If (CrossSection.Value = CrossSections.Furrow) Then
            WettedPerimeter = FurrowWettedPerimeter(Y)
        Else
            WettedPerimeter = BorderWettedPerimeter(Y)
        End If
    End Function

    Public Function BorderWettedPerimeter(ByVal Y As Double) As Double
        BorderWettedPerimeter = Width.Value + (2.0 * Y)
    End Function

    Public Function FlowDepth(ByVal WP As Double) As Double
        If (CrossSection.Value = CrossSections.Furrow) Then
            FlowDepth = FurrowFlowDepth(WP)
        Else
            FlowDepth = BorderFlowDepth(WP)
        End If
    End Function

    Public Function FurrowFlowDepth(ByVal WP As Double) As Double
        Dim Ymin As Double = 0.0
        Dim Ymax As Double = WP
        Dim Ymid As Double = (Ymin + Ymax) / 2.0
        Dim WPmid As Double

        ' Binary search for flow depth (Y) for given WP
        For iter As Integer = 1 To 20
            Select Case (Me.FurrowShape.Value)

                Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData, _
                     FurrowShapes.AveragePowerLawFromTable, FurrowShapes.PowerLawTable

                    Dim C As Double = PowerLawConstant()
                    Dim M As Double = PowerLawExponent.Value
                    Dim FS As Double = FurrowSpacing.Value

                    WPmid = Srfr.SrfrAPI.PowerLawWettedPerimeter(Ymid, WP, FS, C, M)

                Case Else ' Assume FurrowShapes.Trapezoid

                    Dim BW As Double = BottomWidth.Value
                    Dim SS As Double = SideSlope.Value
                    Dim FS As Double = FurrowSpacing.Value

                    WPmid = Srfr.SrfrAPI.TrapezoidWettedPerimeter(Ymid, WP, FS, BW, SS)

            End Select

            If (WPmid < WP - OneMillimeter) Then
                Ymin = Ymid
            ElseIf (WP + OneMillimeter < WPmid) Then
                Ymax = Ymid
            Else
                Exit For
            End If

            Ymid = (Ymin + Ymax) / 2.0
        Next iter

        Return Ymid
    End Function

    Public Function BorderFlowDepth(ByVal WP As Double) As Double
        BorderFlowDepth = (WP - Width.Value) / 2.0
    End Function

#End Region

#Region " Flow Area "

    Public Function FlowArea(ByVal Y As Double) As Double
        If (CrossSection.Value = CrossSections.Furrow) Then
            FlowArea = FurrowFlowArea(Y)
        Else
            FlowArea = BorderFlowArea(Y)
        End If
    End Function

    Public Function BorderFlowArea(ByVal Y As Double) As Double
        BorderFlowArea = Width.Value * Y
    End Function

#End Region

#Region " Field Dimensions "
    '
    ' Field Area = Field Length * Field Width
    '
    Public Function FieldArea() As Double
        Dim area As Double = 1.0

        If Not (Me.LengthProperty.ToBeCalculated) Then
            If Not (Me.WidthProperty.ToBeCalculated) Then
                area = Me.Length.Value * Me.Width.Value
            End If
        End If

        Return area
    End Function
    '
    ' Field Area / Width per Cross Section (Basin/Border or Furrow)
    '
    Public Function AreaForCrossSection() As Double
        If (Me.CrossSection.Value = CrossSections.Furrow) Then ' Area for single furrow
            AreaForCrossSection = Me.Length.Value * Me.FurrowSpacing.Value
        Else ' Area for basin/border
            AreaForCrossSection = Me.Length.Value * Me.Width.Value
        End If
    End Function

    Public Function WidthForCrossSection() As Double
        If (Me.CrossSection.Value = CrossSections.Furrow) Then ' Width for single furrow
            WidthForCrossSection = Me.FurrowSpacing.Value
        Else ' Width for basin/border
            WidthForCrossSection = Me.Width.Value
        End If
    End Function

#End Region

#Region " Field Depth "
    '
    ' Get border depth
    '
    Public ReadOnly Property BorderDepth() As Double
        Get
            Select Case (CrossSection.Value)
                Case CrossSections.Furrow
                    BorderDepth = MaximumDepth.Value
                Case Else ' Assume Basin or Border
                    BorderDepth = Depth.Value
            End Select
        End Get
    End Property

#End Region

#Region " Field Slope "
    '
    ' Average slope for field.
    '
    Public ReadOnly Property AverageSlope() As Double
        Get
            Dim _avgSlope As Double = Double.MaxValue

            Select Case (BottomDescription.Value)

                Case BottomDescriptions.Slope
                    ' No table, use field slope
                    _avgSlope = Slope.Value

                Case BottomDescriptions.SlopeTable, BottomDescriptions.AvgFromSlopeTable, _
                     BottomDescriptions.ElevationTable, BottomDescriptions.AvgFromElevTable

                    _avgSlope = AverageSlopeFromElevationTable()

                Case Else
                    Debug.Assert(False, "Support for the Bottom type must be added")
            End Select

            Return _avgSlope
        End Get
    End Property
    '
    ' Minimum slope for field or any segment of the field.
    '
    Public ReadOnly Property MinimumSlope() As Double
        Get
            Dim _minSlope As Double = Double.MaxValue

            Select Case (BottomDescription.Value)

                Case BottomDescriptions.Slope
                    ' No table, use field slope
                    _minSlope = Slope.Value

                Case BottomDescriptions.AvgFromSlopeTable, BottomDescriptions.AvgFromElevTable

                    _minSlope = AverageSlopeFromElevationTable()

                Case BottomDescriptions.SlopeTable
                    Dim _slopeSet As DataSet = SlopeTable.Value

                    Select Case (SlopeVariation.Value)

                        Case Srfr.VaryByLocTime.Variations.VaryWithDistance
                            ' Vary w/Distance is 1st table in set
                            If (0 < _slopeSet.Tables.Count) Then
                                Dim _slopeTable As DataTable = _slopeSet.Tables(0)
                                ' Check each segment's slope
                                For Each _slopeRow As DataRow In _slopeTable.Rows
                                    Dim _slope As Double = CDbl(_slopeRow.Item(sSlopeX))
                                    If (_minSlope > _slope) Then
                                        _minSlope = _slope
                                    End If
                                Next
                            End If

                        Case Srfr.VaryByLocTime.Variations.VaryDistanceAndTime
                            ' Vary w/Distance & Time, use all tables in set
                            For Each _slopeTable As DataTable In _slopeSet.Tables
                                ' Check each segment's slope
                                For Each _slopeRow As DataRow In _slopeTable.Rows
                                    Dim _slope As Double = CDbl(_slopeRow.Item(sSlopeX))
                                    If (_minSlope > _slope) Then
                                        _minSlope = _slope
                                    End If
                                Next
                            Next

                        Case Else
                            Debug.Assert(False, "Invalid variation")
                    End Select

                Case BottomDescriptions.ElevationTable
                    Dim _elevationSet As DataSet = ElevationTable.Value

                    Select Case (SlopeVariation.Value)

                        Case Srfr.VaryByLocTime.Variations.VaryWithDistance
                            ' Vary w/Distance is 1st table in set
                            If (0 < _elevationSet.Tables.Count) Then
                                Dim _elevationTable As DataTable = _elevationSet.Tables(0)
                                ' Check each segment's slope
                                If (2 <= _elevationTable.Rows.Count) Then
                                    Dim _elev1 As Double = CDbl(_elevationTable.Rows(0).Item(sElevationX))
                                    Dim _dist1 As Double = CDbl(_elevationTable.Rows(0).Item(sDistanceX))
                                    For _idx As Integer = 1 To _elevationTable.Rows.Count - 1
                                        Dim _elevationRow As DataRow = _elevationTable.Rows(_idx)
                                        Dim _elev2 As Double = CDbl(_elevationRow.Item(sElevationX))
                                        Dim _dist2 As Double = CDbl(_elevationRow.Item(sDistanceX))
                                        If (_minSlope > (_elev1 - _elev2) / (_dist2 - _dist1)) Then
                                            _minSlope = (_elev1 - _elev2) / (_dist2 - _dist1)
                                        End If
                                        _elev1 = _elev2
                                        _dist1 = _dist2
                                    Next
                                End If
                            End If

                        Case Srfr.VaryByLocTime.Variations.VaryDistanceAndTime
                            ' Vary w/Distance & Time, use all tables in set
                            For Each _elevationTable As DataTable In _elevationSet.Tables
                                ' Check each segment's slope
                                If (2 <= _elevationTable.Rows.Count) Then
                                    Dim _elev1 As Double = CDbl(_elevationTable.Rows(0).Item(sElevationX))
                                    Dim _dist1 As Double = CDbl(_elevationTable.Rows(0).Item(sDistanceX))
                                    For _idx As Integer = 1 To _elevationTable.Rows.Count - 1
                                        Dim _elevationRow As DataRow = _elevationTable.Rows(_idx)
                                        Dim _elev2 As Double = CDbl(_elevationRow.Item(sElevationX))
                                        Dim _dist2 As Double = CDbl(_elevationRow.Item(sDistanceX))
                                        If (_minSlope > (_elev1 - _elev2) / (_dist2 - _dist1)) Then
                                            _minSlope = (_elev1 - _elev2) / (_dist2 - _dist1)
                                        End If
                                        _elev1 = _elev2
                                        _dist1 = _dist2
                                    Next
                                End If
                            Next

                        Case Else
                            Debug.Assert(False, "Invalid variation")
                    End Select

                Case Else
                    Debug.Assert(False, "Support for the Bottom type must be added")
            End Select

            Return _minSlope
        End Get
    End Property
    '
    ' Maximum slope for field or any segment of the field.
    '
    Public ReadOnly Property MaximumSlope() As Double
        Get
            Dim _maxSlope As Double = 0.0

            Select Case (BottomDescription.Value)

                Case BottomDescriptions.Slope
                    ' No table, use field slope
                    _maxSlope = Slope.Value

                Case BottomDescriptions.AvgFromSlopeTable, BottomDescriptions.AvgFromElevTable

                    _maxSlope = AverageSlopeFromElevationTable()

                Case BottomDescriptions.SlopeTable
                    Dim _slopeSet As DataSet = SlopeTable.Value

                    Select Case (SlopeVariation.Value)

                        Case Srfr.VaryByLocTime.Variations.VaryWithDistance
                            ' Vary w/Distance is 1st table in set
                            If (0 < _slopeSet.Tables.Count) Then
                                Dim _slopeTable As DataTable = _slopeSet.Tables(0)
                                ' Check each segment's slope
                                For Each _slopeRow As DataRow In _slopeTable.Rows
                                    Dim _slope As Double = CDbl(_slopeRow.Item(sSlopeX))
                                    If (_maxSlope < _slope) Then
                                        _maxSlope = _slope
                                    End If
                                Next
                            End If

                        Case Srfr.VaryByLocTime.Variations.VaryDistanceAndTime
                            ' Vary w/Distance & Time, use all tables in set
                            For Each _slopeTable As DataTable In _slopeSet.Tables
                                ' Check each segment's slope
                                For Each _slopeRow As DataRow In _slopeTable.Rows
                                    Dim _slope As Double = CDbl(_slopeRow.Item(sSlopeX))
                                    If (_maxSlope < _slope) Then
                                        _maxSlope = _slope
                                    End If
                                Next
                            Next

                        Case Else
                            Debug.Assert(False, "Invalid variation")
                    End Select

                Case BottomDescriptions.ElevationTable
                    Dim _elevationSet As DataSet = ElevationTable.Value

                    Select Case (SlopeVariation.Value)

                        Case Srfr.VaryByLocTime.Variations.VaryWithDistance
                            ' Vary w/Distance is 1st table in set
                            If (0 < _elevationSet.Tables.Count) Then
                                Dim _elevationTable As DataTable = _elevationSet.Tables(0)
                                ' Check each segment's slope
                                If (2 <= _elevationTable.Rows.Count) Then
                                    Dim _elev1 As Double = CDbl(_elevationTable.Rows(0).Item(sElevationX))
                                    Dim _dist1 As Double = CDbl(_elevationTable.Rows(0).Item(sDistanceX))
                                    For _idx As Integer = 1 To _elevationTable.Rows.Count - 1
                                        Dim _elevationRow As DataRow = _elevationTable.Rows(_idx)
                                        Dim _elev2 As Double = CDbl(_elevationRow.Item(sElevationX))
                                        Dim _dist2 As Double = CDbl(_elevationRow.Item(sDistanceX))
                                        If (_maxSlope < (_elev1 - _elev2) / (_dist2 - _dist1)) Then
                                            _maxSlope = (_elev1 - _elev2) / (_dist2 - _dist1)
                                        End If
                                        _elev1 = _elev2
                                        _dist1 = _dist2
                                    Next
                                End If
                            End If

                        Case Srfr.VaryByLocTime.Variations.VaryDistanceAndTime
                            ' Vary w/Distance & Time, use all tables in set
                            For Each _elevationTable As DataTable In _elevationSet.Tables
                                ' Check each segment's slope
                                If (2 <= _elevationTable.Rows.Count) Then
                                    Dim _elev1 As Double = CDbl(_elevationTable.Rows(0).Item(sElevationX))
                                    Dim _dist1 As Double = CDbl(_elevationTable.Rows(0).Item(sDistanceX))
                                    For _idx As Integer = 1 To _elevationTable.Rows.Count - 1
                                        Dim _elevationRow As DataRow = _elevationTable.Rows(_idx)
                                        Dim _elev2 As Double = CDbl(_elevationRow.Item(sElevationX))
                                        Dim _dist2 As Double = CDbl(_elevationRow.Item(sDistanceX))
                                        If (_maxSlope < (_elev1 - _elev2) / (_dist2 - _dist1)) Then
                                            _maxSlope = (_elev1 - _elev2) / (_dist2 - _dist1)
                                        End If
                                        _elev1 = _elev2
                                        _dist1 = _dist2
                                    Next
                                End If
                            Next

                        Case Else
                            Debug.Assert(False, "Invalid variation")
                    End Select

                Case Else
                    Debug.Assert(False, "Support for the Bottom type must be added")
            End Select

            Return _maxSlope
        End Get
    End Property

#End Region

#Region " Field Elevation "
    '
    ' Minimum elevation for field
    '
    Public ReadOnly Property MinimumElevation() As Double
        Get
            Dim _minElevation As Double = Double.MaxValue

            Select Case (BottomDescription.Value)

                Case BottomDescriptions.SlopeTable, BottomDescriptions.ElevationTable
                    Dim _elevationSet As DataSet = ElevationTable.Value

                    For Each _elevationTable As DataTable In _elevationSet.Tables
                        For Each _elevationRow As DataRow In _elevationTable.Rows
                            Dim _elev As Double = CDbl(_elevationRow.Item(sElevationX))

                            If (_minElevation > _elev) Then
                                _minElevation = _elev
                            End If
                        Next
                    Next
            End Select

            If (_minElevation = Double.MaxValue) Then
                _minElevation = 0.0
            End If

            Return _minElevation
        End Get
    End Property
    '
    ' Maximum elevation for field
    '
    Public ReadOnly Property MaximumElevation() As Double
        Get
            Dim _maxElevation As Double = 0.0

            Select Case (BottomDescription.Value)

                Case BottomDescriptions.SlopeTable, BottomDescriptions.ElevationTable
                    Dim _elevationSet As DataSet = ElevationTable.Value

                    For Each _elevationTable As DataTable In _elevationSet.Tables
                        For Each _elevationRow As DataRow In _elevationTable.Rows
                            Dim _elev As Double = CDbl(_elevationRow.Item(sElevationX))

                            If (_maxElevation < _elev) Then
                                _maxElevation = _elev
                            End If
                        Next
                    Next

            End Select

            If (_maxElevation = 0.0) Then
                Dim _avgSlope As Double = AverageSlope
                _maxElevation = _avgSlope * Length.Value
            End If

            Return _maxElevation
        End Get
    End Property

#End Region

#Region " Field Segments "
    '
    ' Minimum Segment Length
    '
    Public ReadOnly Property MinimumSegmentLength() As Double
        Get
            Dim _minLength As Double = Length.Value

            Select Case (BottomDescription.Value)

                Case BottomDescriptions.Slope, _
                     BottomDescriptions.AvgFromSlopeTable, _
                     BottomDescriptions.AvgFromElevTable

                    _minLength = Length.Value

                Case BottomDescriptions.SlopeTable
                    Dim _slopeSet As DataSet = SlopeTable.Value

                    Select Case (SlopeVariation.Value)

                        Case Srfr.VaryByLocTime.Variations.VaryWithDistance
                            ' Vary w/Distance is 1st table in set
                            If (0 < _slopeSet.Tables.Count) Then
                                Dim _slopeTable As DataTable = _slopeSet.Tables(0)
                                ' Check each segment's length
                                If (1 <= _slopeTable.Rows.Count) Then
                                    Dim _dist2 As Double = Length.Value
                                    For _idx As Integer = _slopeTable.Rows.Count - 1 To 0 Step -1
                                        Dim _slopeRow As DataRow = _slopeTable.Rows(_idx)
                                        Dim _dist1 As Double = CDbl(_slopeRow.Item(sDistanceX))
                                        If (_minLength > _dist2 - _dist1) Then
                                            _minLength = _dist2 - _dist1
                                        End If
                                        _dist2 = _dist1
                                    Next
                                End If
                            End If

                        Case Srfr.VaryByLocTime.Variations.VaryDistanceAndTime
                            ' Vary w/Distance & Time, use all tables in set
                            For Each _slopeTable As DataTable In _slopeSet.Tables
                                ' Check each segment's slope
                                If (1 <= _slopeTable.Rows.Count) Then
                                    Dim _dist2 As Double = Length.Value
                                    For _idx As Integer = _slopeTable.Rows.Count - 1 To 0 Step -1
                                        Dim _slopeRow As DataRow = _slopeTable.Rows(_idx)
                                        Dim _dist1 As Double = CDbl(_slopeRow.Item(sDistanceX))
                                        If (_minLength > _dist2 - _dist1) Then
                                            _minLength = _dist2 - _dist1
                                        End If
                                        _dist2 = _dist1
                                    Next
                                End If
                            Next

                        Case Else
                            Debug.Assert(False, "Invalid variation")
                    End Select

                Case BottomDescriptions.ElevationTable
                    Dim _elevationSet As DataSet = ElevationTable.Value

                    Select Case (SlopeVariation.Value)

                        Case Srfr.VaryByLocTime.Variations.VaryWithDistance
                            ' Vary w/Distance is 1st table in set
                            If (0 < _elevationSet.Tables.Count) Then
                                Dim _elevationTable As DataTable = _elevationSet.Tables(0)
                                ' Check each segment's length
                                If (2 <= _elevationTable.Rows.Count) Then
                                    Dim _dist1 As Double = CDbl(_elevationTable.Rows(0).Item(sDistanceX))
                                    For _idx As Integer = 1 To _elevationTable.Rows.Count - 1
                                        Dim _elevationRow As DataRow = _elevationTable.Rows(_idx)
                                        Dim _dist2 As Double = CDbl(_elevationRow.Item(sDistanceX))
                                        If (_minLength > _dist2 - _dist1) Then
                                            _minLength = _dist2 - _dist1
                                        End If
                                        _dist1 = _dist2
                                    Next
                                End If
                            End If

                        Case Srfr.VaryByLocTime.Variations.VaryDistanceAndTime
                            ' Vary w/Distance & Time, use all tables in set
                            For Each _elevationTable As DataTable In _elevationSet.Tables
                                ' Check each segment's slope
                                If (2 <= _elevationTable.Rows.Count) Then
                                    Dim _dist1 As Double = CDbl(_elevationTable.Rows(0).Item(sDistanceX))
                                    For _idx As Integer = 1 To _elevationTable.Rows.Count - 1
                                        Dim _elevationRow As DataRow = _elevationTable.Rows(_idx)
                                        Dim _dist2 As Double = CDbl(_elevationRow.Item(sDistanceX))
                                        If (_minLength > _dist2 - _dist1) Then
                                            _minLength = _dist2 - _dist1
                                        End If
                                        _dist1 = _dist2
                                    Next
                                End If
                            Next

                        Case Else
                            Debug.Assert(False, "Invalid variation")
                    End Select

                Case Else
                    Debug.Assert(False, "Support for the Bottom type must be added")
            End Select

            Return _minLength
        End Get
    End Property

#End Region

#Region " Pond Depth "

    '******************************************************************************************
    ' PondDepth() - Given a pond volume calculate the pond depth
    '
    Public ReadOnly Property PondDepth(ByVal pondVolume As Double) As Double
        Get
            Dim crossSection As CrossSections = Me.CrossSection.Value
            Select Case crossSection
                Case CrossSections.Furrow
                    Return FurrowPondDepth(pondVolume)
                Case Else ' Assume Basin or Border
                    Return BasinBorderPondDepth(pondVolume)
            End Select
        End Get
    End Property
    '
    ' Basin / Border
    '
    Public ReadOnly Property BasinBorderPondDepth(ByVal pondVolume As Double) As Double
        Get
            Dim fieldLength As Double = Me.Length.Value
            Dim fieldWidth As Double = Me.Width.Value
            Dim pondDepth As Double = BasinBorderPondDepth(pondVolume, fieldLength, fieldWidth)
            Return pondDepth
        End Get
    End Property

    Public ReadOnly Property BasinBorderPondDepth(ByVal pondVolume As Double, _
                                                  ByVal fieldLength As Double, _
                                                  ByVal fieldWidth As Double) As Double
        Get
            Dim pondDepth As Double = 0.0
            Dim pondLength As Double = 0.0
            BasinBorderPondDimensions(pondVolume, fieldLength, fieldWidth, pondDepth, pondLength)
            Return pondDepth
        End Get
    End Property
    '
    ' Furrow
    '
    Public ReadOnly Property FurrowPondDepth(ByVal pondVolume As Double) As Double
        Get
            Dim fieldLength As Double = Me.Length.Value
            Dim pondDepth As Double = FurrowPondDepth(pondVolume, fieldLength)
            Return pondDepth
        End Get
    End Property

    Public ReadOnly Property FurrowPondDepth(ByVal pondVolume As Double, _
                                             ByVal fieldLength As Double) As Double
        Get
            Dim pondDepth As Double = 0.0
            Dim pondLength As Double = 0.0
            FurrowPondDimensions(pondVolume, fieldLength, pondDepth, pondLength)
            Return pondDepth
        End Get
    End Property

#End Region

#Region " Pond Length "

    '******************************************************************************************
    ' PondLength() - Given a pond volume calculate the pond length
    '
    Public ReadOnly Property PondLength(ByVal pondVolume As Double) As Double
        Get
            Dim crossSection As CrossSections = Me.CrossSection.Value
            Select Case crossSection
                Case CrossSections.Furrow
                    Return FurrowPondLength(pondVolume)
                Case Else ' Assume Basin or Border
                    Return BasinBorderPondLength(pondVolume)
            End Select
        End Get
    End Property
    '
    ' Basin / Border
    '
    Public ReadOnly Property BasinBorderPondLength(ByVal pondVolume As Double) As Double
        Get
            Dim fieldLength As Double = Me.Length.Value
            Dim fieldWidth As Double = Me.Width.Value
            Dim pondLength As Double = BasinBorderPondLength(pondVolume, fieldLength, fieldWidth)
            Return pondLength
        End Get
    End Property

    Public ReadOnly Property BasinBorderPondLength(ByVal pondVolume As Double, _
                                                   ByVal fieldLength As Double, _
                                                   ByVal fieldWidth As Double) As Double
        Get
            Dim pondDepth As Double = 0.0
            Dim pondLength As Double = 0.0
            BasinBorderPondDimensions(pondVolume, fieldLength, fieldWidth, pondDepth, pondLength)
            Return pondLength
        End Get
    End Property
    '
    ' Furrow
    '
    Public ReadOnly Property FurrowPondLength(ByVal pondVolume As Double) As Double
        Get
            Dim fieldLength As Double = Me.Length.Value
            Dim pondLength As Double = FurrowPondLength(pondVolume, fieldLength)
            Return pondLength
        End Get
    End Property

    Public ReadOnly Property FurrowPondLength(ByVal pondVolume As Double, _
                                              ByVal fieldLength As Double) As Double
        Get
            Dim pondDepth As Double = 0.0
            Dim pondLength As Double = 0.0
            FurrowPondDimensions(pondVolume, fieldLength, pondDepth, pondLength)
            Return pondLength
        End Get
    End Property

#End Region

#Region " Pond Dimensions "

    '******************************************************************************************
    ' PondDimensions() - Given a pond volume and field length, calculate the pond's
    '                    dimensions (i.e. depth at end & length)
    '
    Public Sub PondDimensions(ByVal pondVolume As Double, ByVal fieldLength As Double, ByVal fieldWidth As Double, _
                              ByRef pondDepth As Double, ByRef pondLength As Double)
        Dim crossSection As CrossSections = Me.CrossSection.Value
        Select Case crossSection
            Case CrossSections.Furrow
                FurrowPondDimensions(pondVolume, fieldLength, pondDepth, pondLength)
            Case Else ' Assume Basin or Border
                BasinBorderPondDimensions(pondVolume, fieldLength, fieldWidth, pondDepth, pondLength)
        End Select
    End Sub
    '
    ' Basin / Border
    '
    Public Sub BasinBorderPondDimensions(ByVal pondVolume As Double, ByVal fieldLength As Double, ByVal fieldWidth As Double, _
                                         ByRef pondDepth As Double, ByRef pondLength As Double)
        pondDepth = 0.0
        pondLength = 0.0

        ' No volume; no pond
        If (pondVolume <= 0.0) Then
            Return
        End If

        ' Field dimensions
        Dim S0 As Double = Me.AverageSlope

        If (S0 <= 0) Then
            '
            ' Flat field
            '
            ' Border flow area   = width * depth
            ' Border pond volume = width * depth * length
            '
            ' Depth = volume / (width * length)
            '
            pondDepth = pondVolume / (fieldWidth * fieldLength)
            pondLength = fieldLength
        Else
            '
            ' Sloping field
            '
            ' Border flow area   = width * depth
            '   Substituting:  depth = x*S0
            ' Border flow area = width * (x*S0)
            '
            ' Integrating x from 0 to pond length:
            '
            ' Border pond volume = (S0 * width * length^2) / 2.0
            '
            ' Length = SQRT[(2.0 * volume) / (S0 * width)]
            ' Depth  = S0 * length
            '
            pondLength = Math.Sqrt((2.0 * pondVolume) / (S0 * fieldWidth))
            pondDepth = S0 * pondLength

            ' Computed pond may be longer than field
            If (fieldLength < pondLength) Then
                ' Pond extends beyond actual field length
                Dim extraLength As Double = pondLength - fieldLength
                Dim extraVolume As Double = BasinBorderPondVolume(S0, extraLength, fieldWidth)

                Dim addedDepth As Double = extraVolume / (fieldWidth * fieldLength)

                pondDepth += addedDepth
                pondLength = fieldLength
            End If
        End If

    End Sub

    '******************************************************************************************
    ' FurrowPondDimensions() - Given a pond volume and field length, calculate the pond's
    '                          dimensions (i.e. depth at end & length)
    '
    Public Sub FurrowPondDimensions(ByVal pondVolume As Double, ByVal fieldLength As Double, _
                                    ByRef pondDepth As Double, ByRef pondLength As Double)
        pondDepth = 0.0
        pondLength = 0.0

        Select Case (Me.FurrowShape.Value)
            Case FurrowShapes.Trapezoid, FurrowShapes.TrapezoidFromFieldData

                TrapezoidPondDimensions(pondVolume, fieldLength, pondDepth, pondLength)

            Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData

                PowerLawPondDimensions(pondVolume, fieldLength, pondDepth, pondLength)

            Case Else
                Debug.Assert(False, "Furrow Shape not supported")
        End Select

    End Sub

    Public Sub TrapezoidPondDimensions(ByVal pondVolume As Double, ByVal fieldLength As Double, _
                                       ByRef pondDepth As Double, ByRef pondLength As Double)
        pondDepth = 0.0
        pondLength = 0.0

        ' No volume; no pond
        If (pondVolume <= 0.0) Then
            Return
        End If

        ' Get Trapezoid Furrow's shape parameters
        Dim SS As Double = Me.SideSlope.Value
        Dim BW As Double = Me.BottomWidth.Value
        Dim S0 As Double = Me.AverageSlope

        If (S0 <= 0) Then
            '
            ' Flat field
            '
            ' Trapezoid flow area   =  SS*depth^2 + BW*depth
            ' Trapezoid pond volume = (SS*depth^2 + BW*depth) * length
            '
            ' Using quadratic equation:
            '   a*depth^2 + b*depth + c = 0
            '     a = SS*length
            '     b = BW*length
            '     c = -volume
            '   depth = (-b + (b^2-4ac)^.5) / 2a
            '
            Dim a As Double = SS * fieldLength
            Dim b As Double = BW * fieldLength
            Dim c As Double = -pondVolume

            pondDepth = (-b + Math.Sqrt(b ^ 2 - 4 * a * c)) / (2 * a)
            pondLength = fieldLength
        Else
            '
            ' Sloping field
            '
            ' Trapezoid flow area = SS*depth^2 + BW*depth
            '   Substituting:  depth = x*S0
            ' Trapezoid flow area = SS*(x*S0)^2 + BW*(x*S0)
            '
            ' Integrating x from 0 to pond length:
            '
            ' Trapezoid pond volume = a*length^3 + b*length^2
            '   a = (SS*S0^2)/3
            '   b = (BW*S0  )/2
            '
            ' Substituting:  length = depth / S0
            '
            ' Trapezoid pond volume = a*depth^3 + b*depth^2
            '   a = SS/(3*S0)
            '   b = BW/(2*S0)
            '
            ' Use root-finding formula for cubic functions:
            '  f(x) = a*x^3 + b*x^2 + c*x + d = a(x-x1)(x-x2)(x-x3)
            '   a = SS/(3*S0)
            '   b = BW/(2*S0)
            '   c = 0
            '   d = - pondVolume
            '
            ' Only need to solve for x1 since x2 & x3 are imaginary roots
            '   x1 = pondDepth
            '
            Dim a As Double = SS / (3 * S0)
            Dim b As Double = BW / (2 * S0)
            Dim c As Double = 0
            Dim d As Double = -pondVolume

            Dim q As Double = (3 * a * c - b ^ 2) / (9 * a ^ 2)
            Dim r As Double = (9 * a * b * c - 27 * a ^ 2 * d - 2 * b ^ 3) / (54 * a ^ 3)

            ' Can only take square root of positive number
            Dim discriminate As Double = q ^ 3 + r ^ 2
            If (0 <= discriminate) Then

                Dim s As Double = Math.Pow((r + Math.Sqrt(discriminate)), 1 / 3)
                Dim t As Double = Math.Pow((r - Math.Sqrt(discriminate)), 1 / 3)

                pondDepth = s + t - (b / (3 * a))
                pondLength = pondDepth / S0

            Else ' discriminate < 0
                ' Search for pond dimensions
                Dim loDepth As Double = 0.0
                Dim hiDepth As Double = Me.MaximumDepth.Value
                Dim midDepth As Double
                Dim midVolume As Double

                For idx As Integer = 1 To 25
                    midDepth = (loDepth + hiDepth) / 2.0
                    midVolume = a * midDepth ^ 3.0 + b * midDepth ^ 2.0

                    If (midVolume < pondVolume - 0.0001) Then
                        loDepth = midDepth                          ' Too small
                    ElseIf (pondVolume + 0.0001 < midVolume) Then
                        hiDepth = midDepth                          ' Too large
                    Else
                        Exit For                                    ' Just right
                    End If
                Next

                pondDepth = midDepth
                pondLength = pondDepth / S0

            End If

            ' Computed pond may be longer than field
            If (fieldLength < pondLength) Then
                ' Pond extends beyond actual field length
                Dim extraLength As Double = pondLength - fieldLength
                Dim extraVolume As Double = TrapezoidPondVolume(S0, extraLength)
                Dim w2 As Double = TrapezoidFlowWidth(pondDepth)
                Dim w1 As Double = TrapezoidFlowWidth(pondDepth - fieldLength * S0)

                ' depth = (-b + (b^2-4ac)^.5) / 2a
                a = SS * pondLength
                b = (w2 + w1) * pondLength / 2
                c = -extraVolume

                Dim addedDepth As Double = (-b + (b ^ 2 - (4 * a * c)) ^ 0.5) / (2 * a)

                pondDepth += addedDepth
                pondLength = fieldLength
            End If
        End If

    End Sub

    Public Sub PowerLawPondDimensions(ByVal pondVolume As Double, ByVal fieldLength As Double, _
                                      ByRef pondDepth As Double, ByRef pondLength As Double)
        pondDepth = 0.0
        pondLength = 0.0

        ' No volume; no pond
        If (pondVolume <= 0.0) Then
            Return
        End If

        ' Get Power Law Furrow's shape parameters
        Dim M As Double = Me.PowerLawExponent.Value
        Dim C As Double = Me.PowerLawConstant
        Dim S0 As Double = Me.AverageSlope

        If (S0 <= 0) Then
            '
            ' Flat field
            '
            ' Power Law flow area = (C / (M+1)) * (depth^(M+1))
            '   Substituting:  depth = x*S0
            ' Power Law flow area = (C / (M+1)) * ((x*S0)^(M+1))
            '
            ' Integrating x from 0 to L (pond length):
            '
            ' Power Law pond volume = a*length^(M+2)
            '   a = C*S0^(M+1) / ((M+2)*(M+1))
            '
            ' Substituting:  length = depth / S0
            '
            ' Power Law pond volume = a*(depth)^(M+2)
            '   a = C / (S0*(M+2)*(M+1))
            '
            Dim a As Double = C / (S0 * (M + 2) * (M + 1))

            pondDepth = Math.Pow((pondVolume / a), 1 / (M + 2))
            pondLength = pondDepth / S0
        Else
            '
            ' Sloping field
            '
            ' Power Law flow area = (C / (M+1)) * (depth^(M+1))
            '   Substituting:  depth = x*S0
            ' Power Law flow area = (C / (M+1)) * ((x*S0)^(M+1))
            '
            ' Integrating x from 0 to L (pond length):
            '
            ' Power Law pond volume = a*length^(M+2)
            '   a = C*S0^(M+1) / ((M+2)*(M+1))
            '
            ' Substituting:  length = depth / S0
            '
            ' Power Law pond volume = a*(depth)^(M+2)
            '   a = C / (S0*(M+2)*(M+1))
            '
            Dim a As Double = C / (S0 * (M + 2) * (M + 1))

            pondDepth = Math.Pow((pondVolume / a), 1 / (M + 2))
            pondLength = pondDepth / S0

            ' Computed pond may be longer than field
            If (fieldLength < pondLength) Then
                ' Pond extends beyond actual field length
                Dim extraLength As Double = pondLength - fieldLength
                Dim extraVolume As Double = PowerLawPondVolume(S0, extraLength)
                Dim w2 As Double = PowerLawFlowWidth(pondDepth)
                Dim w1 As Double = PowerLawFlowWidth(pondDepth - fieldLength * S0)

                ' depth = (-b + (b^2-4ac)^.5) / 2a
                Dim a2 As Double = S0 * pondLength
                Dim b2 As Double = (w2 + w1) * pondLength / 2
                Dim c2 As Double = -extraVolume

                Dim addedDepth As Double = (-b2 + (b2 ^ 2 - (4 * a2 * c2)) ^ 0.5) / (2 * a2)

                pondDepth += addedDepth
                pondLength = fieldLength
            End If
        End If

    End Sub

#End Region

#Region " Pond Volume "

    '******************************************************************************************
    ' PondVolume() - return pond volume of specified length pond
    '
    Public Function PondVolume(ByVal S0 As Double, ByVal pondLength As Double, _
                               ByVal width As Double) As Double
        Dim crossSection As CrossSections = Me.CrossSection.Value
        Select Case crossSection
            Case CrossSections.Furrow
                Return FurrowPondVolume(S0, pondLength)
            Case Else ' Assume Basin / Border
                Return BasinBorderPondVolume(S0, pondLength, width)
        End Select
    End Function
    '
    ' Basin / Border
    '
    Public Function BasinBorderPondVolume(ByVal S0 As Double, ByVal pondLength As Double, _
                                          ByVal fieldWidth As Double) As Double
        Dim pondVolume As Double = 0.0

        Dim pondDepth As Double = S0 * pondLength

        pondVolume = (pondDepth * pondLength * fieldWidth) / 2.0

        Return pondVolume
    End Function
    '
    ' Furrow
    '
    Public Function FurrowPondVolume(ByVal S0 As Double, ByVal pondLength As Double) As Double
        Dim pondVolume As Double = 0.0

        Select Case (Me.FurrowShape.Value)
            Case FurrowShapes.Trapezoid, FurrowShapes.TrapezoidFromFieldData

                pondVolume = TrapezoidPondVolume(S0, pondLength)

            Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData

                pondVolume = PowerLawPondVolume(S0, pondLength)

            Case Else
                Debug.Assert(False, "Furrow Shape not supported")
        End Select

        Return pondVolume
    End Function

    Public Function TrapezoidPondVolume(ByVal S0 As Double, ByVal pondLength As Double) As Double
        Dim pondVolume As Double = 0.0

        ' Get Trapezoid Furrow's shape parameters
        Dim SS As Double = Me.SideSlope.Value
        Dim BW As Double = Me.BottomWidth.Value

        If (S0 <= 0) Then
            '
            ' Flat field
            '
            Debug.Assert(False, "Cannot determine Pond Volume for flat fields")
        Else
            '
            ' Sloping field
            '
            ' Trapezoid flow area = SS*depth^2 + BW*depth
            '   Substituting:  depth = x*S0
            ' Trapezoid flow area = SS*(x*S0)^2 + BW*(x*S0)
            '
            ' Integrating x from 0 to L (pond length):
            '
            ' Trapezoid pond volume = a*length^3 + b*length^2
            '   a = (SS*S0^2)/3
            '   b = (BW*S0  )/2
            '
            Dim a As Double = (SS * S0 ^ 2) / 3
            Dim b As Double = (BW * S0) / 2

            pondVolume = (a * pondLength ^ 3) + (b * pondLength ^ 2)
        End If

        Return pondVolume
    End Function

    Public Function PowerLawPondVolume(ByVal S0 As Double, ByVal pondLength As Double) As Double
        Dim pondVolume As Double = 0.0

        ' Get Power Law Furrow's shape parameters
        Dim M As Double = Me.PowerLawExponent.Value
        Dim C As Double = Me.PowerLawConstant

        If (S0 <= 0) Then
            '
            ' Flat field
            '
            Debug.Assert(False, "Cannot determine Pond Volume for flat fields")
        Else
            '
            ' Sloping field
            '
            ' Power Law flow area = (C / (M+1)) * (depth^(M+1))
            '   Substituting:  depth = x*S0
            ' Power Law flow area = (C / (M+1)) * ((x*S0)^(M+1))
            '
            ' Integrating x from 0 to L (pond length):
            '
            ' Power Law pond volume = a*length^(M+2)
            '   a = C*S0^(M+1) / ((M+2)*(M+1))
            '
            Dim a As Double = (C * S0 ^ (M + 1)) / ((M + 2) * (M + 1))

            pondVolume = a * pondLength ^ (M + 2)
        End If

        Return pondVolume
    End Function

#End Region

#Region " Furrow "

    Public Function FurrowTopWidth() As Double
        Dim Y As Double = Me.MaximumDepth.Value
        Dim TW As Double = Me.FurrowFlowWidth(Y)
        Return TW
    End Function

    Public Function FurrowFlowWidth(ByVal Y As Double) As Double
        Dim W As Double = 0.0
        Select Case (Me.FurrowShape.Value)
            Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData
                W = Me.PowerLawFlowWidth(Y)
            Case Else ' Assume FurrowShapes.Trapezoid
                W = Me.TrapezoidFlowWidth(Y)
        End Select
        Return W
    End Function

    Public Function FurrowFlowArea(ByVal Y As Double) As Double
        Dim A As Double = 0.0
        Select Case (Me.FurrowShape.Value)
            Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData
                A = Me.PowerLawFlowArea(Y)
            Case Else ' Assume FurrowShapes.Trapezoid
                A = Me.TrapezoidFlowArea(Y)
        End Select
        Return A
    End Function

    Public Function FurrowWettedPerimeter(ByVal Y As Double) As Double
        Dim WP As Double = 0.0
        Select Case (Me.FurrowShape.Value)
            Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData
                WP = Me.PowerLawWettedPerimeter(Y)
            Case Else ' Assume FurrowShapes.Trapezoid
                WP = Me.TrapezoidWettedPerimeter(Y)
        End Select
        Return WP
    End Function

    Public Function FurrowHydraulicRadius(ByVal Y As Double) As Double
        Dim R As Double = 0.0

        Select Case (Me.FurrowShape.Value)
            Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData
                R = Me.PowerLawHydraulicRadius(Y)
            Case Else ' Assume FurrowShapes.Trapezoid
                R = Me.TrapezoidHydraulicRadius(Y)
        End Select

        Return R
    End Function

    Public Function FurrowHydraulicGradient(ByVal n As Double, ByVal Q As Double, _
                                            Optional ByVal Beta As Double = 0.0) As Double

        Dim L As Double = Length.Value
        Dim S0 As Double = AverageSlope()

        ' If input Beta is undefined, use default
        If (Beta <= 0.0) Then
            Beta = mUnit.Beta(S0) ' Globals.Beta
        End If

        Dim _gradient As Double = 0.0

        Dim _sf As Double = Math.Max(S0, 0.00001)

        Dim _y1 As Double = 0.0001
        Dim _y2 As Double = FurrowNormalDepth(_sf, n, Q)

        Dim _f As Double = FurrowHydraulicGradient(n, Q, _sf, _y1, Beta)
        Dim _fmid As Double = FurrowHydraulicGradient(n, Q, _sf, _y2, Beta)
        Dim _ymid As Double

        If (_f * _fmid <= 0) Then
            Dim _rtbis As Double = _y2
            Dim _dy As Double = _y1 - _y2

            If (_f < 0.0) Then
                _rtbis = _y1
                _dy = _y2 - _y1
            End If

            For iter As Integer = 1 To 100
                _dy *= 0.5
                _ymid = _rtbis + _dy
                _fmid = FurrowHydraulicGradient(n, Q, _sf, _ymid, Beta)

                If (_fmid <= 0) Then
                    _rtbis = _ymid
                End If

                If ((Math.Abs(_dy) < 0.000001) Or (_fmid = 0.0)) Then
                    _gradient = S0 + Beta * _ymid / L
                    Return _gradient
                End If
            Next
        Else
            _gradient = Double.NaN
        End If

        Return _gradient
    End Function

    Public Function FurrowHydraulicGradient(ByVal n As Double, ByVal Q As Double, ByVal S0 As Double, ByVal Y As Double, _
                                            Optional ByVal Beta As Double = 0.0) As Double

        ' If input Beta is undefined, use default
        If (Beta <= 0.0) Then
            Beta = mUnit.Beta(S0) ' Globals.Beta
        End If

        Dim AY As Double = FurrowFlowArea(Y) ^ 2.0
        Dim R As Double = FurrowHydraulicRadius(Y) ^ (4.0 / 3.0)
        Dim L As Double = Length.Value

        FurrowHydraulicGradient = ((Q ^ 2.0) * (n ^ 2.0) / (AY * R)) - S0 - (Beta * Y / L)

    End Function

    Public Function FurrowNormalDepth(ByVal S0 As Double, ByVal n As Double, ByVal Q As Double) As Double
        Dim Yn As Double = 0.0
        Select Case (Me.FurrowShape.Value)
            Case FurrowShapes.PowerLaw, FurrowShapes.PowerLawFromFieldData

                Dim crossSection As Srfr.PowerLawFurrow = New Srfr.PowerLawFurrow
                crossSection.M = Me.PowerLawExponent.Value
                crossSection.W100 = Me.WidthAt100mm.Value

                Dim roughness As Srfr.ManningN = New Srfr.ManningN
                roughness.n = n

                Yn = Srfr.SrfrAPI.NormalDepth(Q, S0, crossSection, roughness)
            Case Else ' Assume FurrowShapes.Trapezoid

                Dim crossSection As Srfr.TrapezoidFurrow = New Srfr.TrapezoidFurrow
                crossSection.BW = Me.BottomWidth.Value
                crossSection.SS = Me.SideSlope.Value

                Dim roughness As Srfr.ManningN = New Srfr.ManningN
                roughness.n = n

                Yn = Srfr.SrfrAPI.NormalDepth(Q, S0, crossSection, roughness)
        End Select
        Return Yn
    End Function

#End Region

#Region " Trapezoid Furrow "
    '
    ' Trapezoid Furrow parameters
    '
    Public Function TrapezoidFlowWidth(ByVal Y As Double) As Double
        Dim BW As Double = BottomWidth.Value
        Dim SS As Double = SideSlope.Value
        Dim Ymax As Double = MaximumDepth.Value
        Dim FS As Double = FurrowSpacing.Value

        Dim W As Double = Srfr.SrfrAPI.TrapezoidFlowWidth(Y, Ymax, FS, BW, SS)
        Return W
    End Function

    Public Function TrapezoidFlowArea(ByVal Y As Double) As Double
        Dim BW As Double = BottomWidth.Value
        Dim SS As Double = SideSlope.Value
        Dim Ymax As Double = MaximumDepth.Value
        Dim FS As Double = FurrowSpacing.Value

        Dim A As Double = Srfr.SrfrAPI.TrapezoidFlowArea(Y, Ymax, FS, BW, SS)
        Return A
    End Function

    Public Function TrapezoidWettedPerimeter(ByVal Y As Double) As Double
        Dim BW As Double = BottomWidth.Value
        Dim SS As Double = SideSlope.Value
        Dim Ymax As Double = MaximumDepth.Value
        Dim FS As Double = FurrowSpacing.Value

        Dim WP As Double = Srfr.SrfrAPI.TrapezoidWettedPerimeter(Y, Ymax, FS, BW, SS)
        Return WP
    End Function

    Public Function TrapezoidHydraulicRadius(ByVal Y As Double) As Double
        Dim BW As Double = BottomWidth.Value
        Dim SS As Double = SideSlope.Value
        Dim Ymax As Double = MaximumDepth.Value
        Dim FS As Double = FurrowSpacing.Value

        Dim R As Double = Srfr.SrfrAPI.TrapezoidHydraulicRadius(Y, Ymax, FS, BW, SS)
        Return R
    End Function

    Public Function TrapezoidCotSS() As Double
        Dim SS As Double = Me.SideSlope.Value

        Dim cotSS As Double = Math.Sqrt(1.0 + (SS ^ 2.0))
        Return cotSS
    End Function

#End Region

#Region " Power Law Furrow "
    '
    ' Power Law Furrow parameters
    '
    Public Function PowerLawConstant() As Double
        Dim W100 As Double = WidthAt100mm.Value
        Dim M As Double = PowerLawExponent.Value

        Dim C As Double = Srfr.SrfrAPI.PowerLawC(W100, M)
        Return C
    End Function

    Public Function PowerLawConstantString() As String
        Dim C As Double = PowerLawConstant()
        Dim M As Double = PowerLawExponent.Value
        Dim _string As String

        Dim constantUnits As Units = UnitsSystem.Instance.ShapeUnits

        Select Case (constantUnits)
            Case Units.Feet
                C *= (FeetPerMeter / (FeetPerMeter ^ M))
                _string = Format(C, "0.000") + " ft/ft^M"
            Case Units.Inches
                C *= (InchesPerMeter / (InchesPerMeter ^ M))
                _string = Format(C, "0.000") + " in/in^M"
            Case Units.Meters
                _string = Format(C, "0.00") + " m/m^M"
            Case Units.Centimeters
                C *= (CentimetersPerMeter / (CentimetersPerMeter ^ M))
                _string = Format(C, "0.00") + " cm/cm^M"
            Case Else ' Assume Units.Millimeters
                C *= (MillimetersPerMeter / (MillimetersPerMeter ^ M))
                _string = Format(C, "0.0") + " mm/mm^M"
        End Select

        Return _string
    End Function

    Public Function PowerLawFlowWidth(ByVal Y As Double) As Double
        Dim C As Double = PowerLawConstant()
        Dim M As Double = PowerLawExponent.Value
        Dim Ymax As Double = MaximumDepth.Value
        Dim FS As Double = FurrowSpacing.Value

        Dim W As Double = Srfr.SrfrAPI.PowerLawFlowWidth(Y, Ymax, FS, C, M)
        Return W
    End Function

    Public Function PowerLawFlowArea(ByVal Y As Double) As Double
        Dim C As Double = PowerLawConstant()
        Dim M As Double = PowerLawExponent.Value
        Dim Ymax As Double = MaximumDepth.Value
        Dim FS As Double = FurrowSpacing.Value

        Dim A As Double = Srfr.SrfrAPI.PowerLawFlowArea(Y, Ymax, FS, C, M)
        Return A
    End Function

    Public Function PowerLawWettedPerimeter(ByVal Y As Double) As Double
        Dim C As Double = PowerLawConstant()
        Dim M As Double = PowerLawExponent.Value
        Dim Ymax As Double = MaximumDepth.Value
        Dim FS As Double = FurrowSpacing.Value

        Dim WP As Double = Srfr.SrfrAPI.PowerLawWettedPerimeter(Y, Ymax, FS, C, M)
        Return WP
    End Function

    Public Function PowerLawHydraulicRadius(ByVal Y As Double) As Double
        Dim C As Double = PowerLawConstant()
        Dim M As Double = PowerLawExponent.Value
        Dim Ymax As Double = MaximumDepth.Value
        Dim FS As Double = FurrowSpacing.Value

        Dim R As Double = Srfr.SrfrAPI.PowerLawHydraulicRadius(Y, Ymax, FS, C, M)
        Return R
    End Function
    '
    ' Compute Rho1 & Rho2 for Power Law furrow using Power Fit (y=rho1*x^rho2)
    '
    Public Sub PowerLawRho(ByRef Rho1 As Double, ByRef Rho2 As Double)

        ' Compute array values at 5 equally spaced furrow depths
        Dim n As Integer = 5
        Dim Y As Double = Me.MaximumDepth.Value

        Dim areas As ArrayList = New ArrayList     ' x values
        Dim ars As ArrayList = New ArrayList       ' y values

        For i As Integer = 1 To n
            ' Get next furrow depth
            Dim Yi As Double = (Y * i) / n

            ' Compute parameters for this depth
            Dim A As Double = Me.PowerLawFlowArea(Yi)
            Dim WP As Double = Me.PowerLawWettedPerimeter(Yi)
            Dim R As Double = A / WP

            Dim AR As Double = (A ^ 2.0) * (R ^ (4.0 / 3.0))

            ' Build arrays of computed parameters
            areas.Add(A)
            ars.Add(AR)
        Next

        ' Compute Rho1 & Rho1 using power fit for computed x & y arrays
        PowerFit(areas, ars, Rho1, Rho2)

    End Sub

#End Region

#End Region

#Region " Constructor(s) "

    Public Sub New(ByVal _myID As String, ByVal _unit As Unit)
        '
        ' Verify data structures' sizes
        '
        Debug.Assert(CrossSections.HighLimit = CrossSectionSelections.Length)
        Debug.Assert(UpstreamConditions.HighLimit = UpstreamConditionSelections.Length)
        Debug.Assert(DownstreamConditions.HighLimit = DownstreamConditionSelections.Length)
        Debug.Assert(BottomDescriptions.HighLimit = BottomDescriptionSelections.Length)
        Debug.Assert(FurrowShapes.HighLimit = FurrowShapeSelections.Length)
        '
        ' Save ID
        '
        If Not (_myID Is Nothing) Then
            If Not (_myID.Trim = String.Empty) Then
                mMyID = _myID.Trim
            Else
                Debug.Assert(False, "MyID is Empty")
            End If
        Else
            Debug.Assert(False, "MyID is Nothing")
        End If
        '
        ' Get Parent's Data Store
        '
        If Not (_unit Is Nothing) Then
            mUnit = _unit
            mParentStore = mUnit.MyStore
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Add SystemGeometry to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "SystemGeometry not added to Data Store")
            End If
        Else
            Debug.Assert(False, "Parent's Data Store is Nothing")
        End If

    End Sub
    '
    ' Constructor that restores from the Data Store
    '
    Public Sub New(ByVal _myStore As DataStore.ObjectNode, ByVal _unit As Unit)
        '
        ' Restore Parent & Parent's DataStore
        '
        If Not (_unit Is Nothing) Then
            mUnit = _unit
            mParentStore = mUnit.MyStore
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Restore MyStore
        '
        If Not (_myStore Is Nothing) Then
            ' Restore identification
            mMyStore = _myStore
            mMyID = mMyStore.MyID

            ' Enable event generation
            mMyStore.EventsEnabled = True
        Else
            Debug.Assert(False, "MyStore is Nothing")
        End If
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        Length
        CrossSection
        Variation
        Drainback
        DownstreamCondition
        BottomDescription
        FurrowShape
        Dimensions
    End Enum
    '
    ' Event generated when a property changes
    '
    Public Event PropertyDataChanged(ByVal _reason As Reasons)
    '
    ' Method to raise the PropertyChanged event
    '
    Protected Sub RaisePropertyDataChangedEvent(ByVal _reason As Reasons)
        RaiseEvent PropertyDataChanged(_reason)
    End Sub
    '
    ' Handler for MyStore changes
    '
    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged
        ' Regenerate the DataStore event as a SystemGeometry event
        Select Case _id
            Case sLength
                RaiseEvent PropertyDataChanged(Reasons.Length)
            Case sCrossSection
                RaiseEvent PropertyDataChanged(Reasons.CrossSection)
            Case sSlopeVariation, sElevationVariation
                RaiseEvent PropertyDataChanged(Reasons.Variation)
            Case sUpstreamCondition, sDrainback
                RaiseEvent PropertyDataChanged(Reasons.Drainback)
            Case sDownstreamCondition
                RaiseEvent PropertyDataChanged(Reasons.DownstreamCondition)
            Case sBottomDescription
                RaiseEvent PropertyDataChanged(Reasons.BottomDescription)
            Case sFurrowShape
                RaiseEvent PropertyDataChanged(Reasons.FurrowShape)
            Case Else
                RaiseEvent PropertyDataChanged(Reasons.Dimensions)
        End Select
    End Sub

#End Region

End Class
