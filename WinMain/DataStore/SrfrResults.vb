
'*************************************************************************************************************
' SRFR Simulation Results
'
' SrfrResults stores results produced by a SRFR Simulation run.  Only results used for comparison purposes
' should be stored here; normally SRFR Results are distributed to other objects.
'*************************************************************************************************************
Imports DataStore

Public Class SrfrResults

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "SRFR Results"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Parent Unit
    '
    Private mUnit As Unit
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

#Region " Constructor(s) "

    Public Sub New(ByVal _myID As String, ByVal _unit As Unit)
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
        ' Add SrfrResults to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "SrfrResults not added to Data Store")
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

#Region " Non-Serialized Properties "
    '
    ' Surface Flow results from a Standard Infiltration Function simulation
    '
    Private mStdAdvanceProfile As DataTable = Nothing
    Public Property StdAdvanceProfile() As DataTable
        Get
            Return mStdAdvanceProfile
        End Get
        Set(ByVal value As DataTable)
            mStdAdvanceProfile = value
        End Set
    End Property

    Private mStdRecessionProfile As DataTable = Nothing
    Public Property StdRecessionProfile() As DataTable
        Get
            Return mStdRecessionProfile
        End Get
        Set(ByVal value As DataTable)
            mStdRecessionProfile = value
        End Set
    End Property

    Private mStdFlowDepthHydrographs As DataSet = Nothing
    Public Property StdFlowDepthHydrographs() As DataSet
        Get
            Return mStdFlowDepthHydrographs
        End Get
        Set(ByVal value As DataSet)
            mStdFlowDepthHydrographs = value
        End Set
    End Property

    Public Function StdFlowDepthHydrograph(ByVal Dist As Double) As DataTable
        StdFlowDepthHydrograph = Nothing

        Try
            '
            ' The StdAdvanceProfile and the StdFlowDepthHydrographs are results from a standard infiltration
            ' method simulation. They are uploaded from SRFR and must contain the same number of entries.
            ' There should be one entry for each Node column in SRFR's final Irrigation solution network.
            '
            If ((mStdAdvanceProfile IsNot Nothing) And (mStdFlowDepthHydrographs IsNot Nothing)) Then

                ' Must have one Flow Depth Hydrograph for each Advance curve point (X vs T)
                Debug.Assert(mStdAdvanceProfile.Rows.Count = mStdFlowDepthHydrographs.Tables.Count)

                ' Search Advance curve for entry closest to requested Dist
                Dim closest As Double = Double.MaxValue

                Dim fdx As Integer = -1
                For adx As Integer = 0 To mStdAdvanceProfile.Rows.Count - 1

                    Dim advRow As DataRow = mStdAdvanceProfile.Rows(adx)
                    Dim advDist As Double = advRow(nDistanceX)

                    Dim dx As Double = Math.Abs(advDist - Dist)
                    If (dx = 0.0) Then ' at requested distance; done with search
                        fdx = adx
                        Exit For
                    ElseIf (closest > dx) Then ' closer to requested distance; save & keep looking
                        closest = dx
                        fdx = adx
                    ElseIf (closest < dx) Then ' further away; stop looking; use previous closest distance
                        Exit For
                    End If

                Next adx

                ' If closest Advance curve point found; return corresponding Flow Depth Hydrograph
                If (-1 < fdx) Then
                    StdFlowDepthHydrograph = mStdFlowDepthHydrographs.Tables(fdx)
                End If

            End If

        Catch ex As Exception
            StdFlowDepthHydrograph = Nothing
        End Try
    End Function

#End Region

#Region " Serialized Properties "

#Region " Advance "
    '
    ' Advance Table
    '
    Public ReadOnly Property AdvanceProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvance)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _advance As DataTable = New DataTable(sAdvance)

                ResetAdvance(_advance)

                Dim _parameter As DataTableParameter = New DataTableParameter(_advance)
                mMyStore.AddProperty(sAdvance, _parameter)
                _propertyNode = mMyStore.GetProperty(sAdvance)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Advance() As DataTableParameter
        Get
            Dim _table As DataTableParameter = AdvanceProperty.GetDataTableParameter()

            If Not (_table.Value Is Nothing) Then
                ' Bring Advance Table up to date
                _table.Value.Columns(nDistanceX).ColumnName = sDistanceX
                _table.Value.Columns(nTimeX1).ColumnName = sTimeX
            End If

            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            AdvanceProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearAdvance()
        mMyStore.DeleteProperty(sAdvance)
    End Sub

    Public Sub ResetAdvance(ByVal _advance As DataTable)

        ' Remove the previous data
        _advance.Columns.Clear()
        _advance.Rows.Clear()

        ' Add the columns
        _advance.Columns.Add(sDistanceX, GetType(Double))
        _advance.Columns.Add(sTimeX, GetType(Double))

        ' Add the rows of reset data
        Dim _advanceRow As DataRow

        _advanceRow = _advance.NewRow
        _advanceRow.Item(nDistanceX) = 0.0
        _advanceRow.Item(nTimeX1) = 0.0
        _advance.Rows.Add(_advanceRow)

    End Sub

    Public Function AdvanceAtDistance(ByVal _distance As Double) As Double
        Dim _time As Double = Double.NaN

        ' Get Advance Table
        Dim _advanceTable As DataTable = Advance.Value
        If Not (_advanceTable Is Nothing) Then
            If (0 < _advanceTable.Rows.Count) Then

                ' Get Distance & Time for first Advance row
                Dim _dist1 As Double = 0.0
                Dim _time1 As Double = 0.0
                Dim _dist2 As Double = 0.0
                Dim _time2 As Double = 0.0

                For _idx As Integer = 0 To _advanceTable.Rows.Count - 1
                    Dim _advanceRow As DataRow = _advanceTable.Rows(_idx)
                    _dist2 = CDbl(_advanceRow.Item(sDistanceX))
                    _time2 = CDbl(_advanceRow.Item(sTimeX))

                    If (ThisClose(_dist2, _distance, OneDecimeter)) Then
                        ' At the requested Distance
                        _time = _time2
                        Exit For
                    ElseIf (_dist2 < _distance) Then
                        ' Before the requested distance
                        _time = 0.0
                    Else ' _distance < _dist2
                        ' Past the requested distance
                        _time = _time1 + ((_distance - _dist1) * (_time2 - _time1) / (_dist2 - _dist1))
                        Exit For
                    End If

                    _dist1 = _dist2
                    _time1 = _time2
                Next

                If (_time = 0.0) Then
                    If (_distance < _dist1 + OneMeter) Then
                        _time = _time1
                    End If
                End If
            End If
        End If

        Return _time
    End Function

#End Region

#Region " Recession "

    Public ReadOnly Property RecessionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRecession)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _recession As DataTable = New DataTable(sRecession)

                ResetRecession(_recession)

                Dim _parameter As DataTableParameter = New DataTableParameter(_recession)
                mMyStore.AddProperty(sRecession, _parameter)
                _propertyNode = mMyStore.GetProperty(sRecession)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Recession() As DataTableParameter
        Get
            Dim _table As DataTableParameter = RecessionProperty.GetDataTableParameter()

            If Not (_table.Value Is Nothing) Then
                ' Bring Recession Table up to date
                _table.Value.Columns(nDistanceX).ColumnName = sDistanceX
                _table.Value.Columns(nTimeX1).ColumnName = sTimeX
            End If

            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            RecessionProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearRecession()
        mMyStore.DeleteProperty(sRecession)
    End Sub

    Public Sub ResetRecession(ByVal _recession As DataTable)

        ' Remove the previous data
        _recession.Columns.Clear()
        _recession.Rows.Clear()

        ' Add the columns
        _recession.Columns.Add(sDistanceX, GetType(Double))
        _recession.Columns.Add(sTimeX, GetType(Double))

        ' Add the rows of reset data
        '   Recession Table start empty of rows

    End Sub

    Public Function LastRecessionDistance() As Double
        Dim _dist As Double = Double.NaN

        ' Get Recession Table
        Dim _recessionTable As DataTable = Recession.Value
        If Not (_recessionTable Is Nothing) Then
            If (0 < _recessionTable.Rows.Count) Then
                ' Get Distance for last Recession row
                _dist = CDbl(_recessionTable.Rows(_recessionTable.Rows.Count - 1).Item(sDistanceX))
            End If
        End If

        Return _dist
    End Function

    Public Function RecessionAtDistance(ByVal _distance As Double) As Double
        Dim _time As Double = Double.NaN

        ' Get Recession Table
        Dim _recessionTable As DataTable = Recession.Value
        If Not (_recessionTable Is Nothing) Then
            If (0 < _recessionTable.Rows.Count) Then

                ' Get Distance & Time for first Recession row
                Dim _dist1 As Double = 0.0
                Dim _time1 As Double = 0.0
                Dim _dist2 As Double = 0.0
                Dim _time2 As Double = 0.0

                For _idx As Integer = 0 To _recessionTable.Rows.Count - 1
                    Dim _recessionRow As DataRow = _recessionTable.Rows(_idx)
                    _dist2 = CDbl(_recessionRow.Item(sDistanceX))
                    _time2 = CDbl(_recessionRow.Item(sTimeX))

                    If (ThisClose(_dist2, _distance, OneDecimeter)) Then
                        ' At the requested distance
                        _time = _time2
                        Exit For
                    ElseIf (_dist2 < _distance) Then
                        ' Before the requested distance
                        _time = 0.0
                    Else ' _distance < _dist2
                        ' Past the requested distance
                        _time = _time1 + ((_distance - _dist1) * (_time2 - _time1) / (_dist2 - _dist1))
                        Exit For
                    End If

                    _dist1 = _dist2
                    _time1 = _time2
                Next

                If (_time = 0.0) Then
                    If (_distance < _dist1 + OneMeter) Then
                        _time = _time1
                    End If
                End If
            End If
        End If

        Return _time
    End Function

#End Region

#Region " Infiltration "
    '
    ' Longitudinal Infiltration Table
    '
    Private Const sLongitudinalInfiltration As String = "Longitudinal Infiltration"

    Public ReadOnly Property LongitudinalInfiltrationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sLongitudinalInfiltration)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sLongitudinalInfiltration, _parameter)
                _propertyNode = mMyStore.GetProperty(sLongitudinalInfiltration)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property LongitudinalInfiltration() As DataTableParameter
        Get
            Dim _table As DataTableParameter = LongitudinalInfiltrationProperty.GetDataTableParameter()

            If (_table.Value Is Nothing) Then
                _table.Value = New DataTable
                _table.Value.Columns.Add(sDistanceX, GetType(Double))
                _table.Value.Columns.Add(sInfiltrationX, GetType(Double))
            Else
                ' Bring Longitudinal Infiltration up to date
                _table.Value.Columns(nDistanceX).ColumnName = sDistanceX
                _table.Value.Columns(nInfiltrationX).ColumnName = sInfiltrationX
            End If

            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            LongitudinalInfiltrationProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearLongitudinalInfiltration()
        mMyStore.DeleteProperty(sLongitudinalInfiltration)
    End Sub

#End Region

#Region " Hydrographs "
    '
    ' Flow Hydrograph Table
    '
    Private Const sFlowHydrographs As String = "Flow Hydrographs"

    Public ReadOnly Property FlowHydrographsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFlowHydrographs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sFlowHydrographs, _parameter)
                _propertyNode = mMyStore.GetProperty(sFlowHydrographs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property FlowHydrographs() As DataTableParameter
        Get
            Return FlowHydrographsProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            FlowHydrographsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearFlowHydrographs()
        mMyStore.DeleteProperty(sFlowHydrographs)
    End Sub

#End Region

#Region " Surface Flow "
    '
    ' Average Depth (Yavg)
    '
    Public Const sAverageDepthPt1 As String = "Avg Depth Pt1"
    Public Const sYavgPt1 As String = "Yavg Pt1"

    Public ReadOnly Property YavgPt1Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAverageDepthPt1)

            ' If it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sAverageDepthPt1, sYavgPt1, _parameter)
                _propertyNode = mMyStore.GetProperty(sAverageDepthPt1)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property YavgPt1() As DoubleParameter
        Get
            Return YavgPt1Property.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            YavgPt1Property.SetParameter(Value)
        End Set
    End Property

    Public Const sAverageDepthPt2 As String = "Avg Depth Pt2"
    Public Const sYavgPt2 As String = "Yavg Pt2"

    Public ReadOnly Property YavgPt2Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAverageDepthPt2)

            ' If it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sAverageDepthPt2, sYavgPt2, _parameter)
                _propertyNode = mMyStore.GetProperty(sAverageDepthPt2)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property YavgPt2() As DoubleParameter
        Get
            Return YavgPt2Property.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            YavgPt2Property.SetParameter(Value)
        End Set
    End Property
    '
    ' Average Flow Area (AYavg)
    '
    Public Const sAverageFlowAreaPt1 As String = "Avg Flow Area Pt1"
    Public Const sAYavgPt1 As String = "AYavg Pt1"

    Public ReadOnly Property AYavgPt1Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAverageFlowAreaPt1)

            ' If it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.SquareMeters)
                mMyStore.AddProperty(sAverageFlowAreaPt1, sAYavgPt1, _parameter)
                _propertyNode = mMyStore.GetProperty(sAverageFlowAreaPt1)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AYavgPt1() As DoubleParameter
        Get
            Return AYavgPt1Property.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            AYavgPt1Property.SetParameter(Value)
        End Set
    End Property

    Public Const sAverageFlowAreaPt2 As String = "Avg Flow Area Pt2"
    Public Const sAYavgPt2 As String = "AYavg Pt2"

    Public ReadOnly Property AYavgPt2Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAverageFlowAreaPt2)

            ' If it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.SquareMeters)
                mMyStore.AddProperty(sAverageFlowAreaPt2, sAYavgPt2, _parameter)
                _propertyNode = mMyStore.GetProperty(sAverageFlowAreaPt2)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AYavgPt2() As DoubleParameter
        Get
            Return AYavgPt2Property.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            AYavgPt2Property.SetParameter(Value)
        End Set
    End Property
    '
    ' Average Wetted Perimeter (WPavg)
    '
    Public Const sAverageWettedPerimeterPt1 As String = "Avg Wetted Perimeter Pt1"
    Public Const sWPavgPt1 As String = "WPavg Pt1"

    Public ReadOnly Property WPavgPt1Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAverageWettedPerimeterPt1)

            ' If it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.SquareMeters)
                mMyStore.AddProperty(sAverageWettedPerimeterPt1, sWPavgPt1, _parameter)
                _propertyNode = mMyStore.GetProperty(sAverageWettedPerimeterPt1)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property WPavgPt1() As DoubleParameter
        Get
            Return WPavgPt1Property.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            WPavgPt1Property.SetParameter(Value)
        End Set
    End Property

    Public Const sAverageWettedPerimeterPt2 As String = "Avg Wetted Perimeter Pt2"
    Public Const sWPavgPt2 As String = "WPavg Pt2"

    Public ReadOnly Property WPavgPt2Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAverageWettedPerimeterPt2)

            ' If it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.SquareMeters)
                mMyStore.AddProperty(sAverageWettedPerimeterPt2, sWPavgPt2, _parameter)
                _propertyNode = mMyStore.GetProperty(sAverageWettedPerimeterPt2)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property WPavgPt2() As DoubleParameter
        Get
            Return WPavgPt2Property.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            WPavgPt2Property.SetParameter(Value)
        End Set
    End Property
    '
    ' Overflow
    '
    Public Const sOverflow As String = "Overflow"

    Public ReadOnly Property OverflowProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sOverflow)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(False)
                mMyStore.AddProperty(sOverflow, _boolean, True)
                _propertyNode = mMyStore.GetProperty(sOverflow)
            End If

            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property Overflow() As BooleanParameter
        Get
            Return OverflowProperty.GetBooleanParameter()
        End Get
        Set(ByVal Value As BooleanParameter)
            OverflowProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sOverflowTime As String = "Overflow Time"
    Public Const sTov As String = "Tov"

    Public ReadOnly Property OverflowTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sOverflowTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _time As DoubleParameter = New DoubleParameter(0.0, Units.Seconds)
                mMyStore.AddProperty(sOverflowTime, sTov, _time, True)
                _propertyNode = mMyStore.GetProperty(sOverflowTime)
            End If

            _propertyNode.Symbol = sTov
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property OverflowTime() As DoubleParameter
        Get
            Return OverflowTimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            OverflowTimeProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sOverflowDist As String = "Overflow Dist"
    Public Const sXov As String = "Xov"

    Public ReadOnly Property OverflowDistProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sOverflowDist)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _dist As DoubleParameter = New DoubleParameter(0.0, Units.Meters)
                mMyStore.AddProperty(sOverflowDist, sXov, _dist, True)
                _propertyNode = mMyStore.GetProperty(sOverflowDist)
            End If

            _propertyNode.Symbol = sXov
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property OverflowDist() As DoubleParameter
        Get
            Return OverflowDistProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            OverflowDistProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#End Region

#Region " Calculated Properties "

#Region " Advance / Recession "

    '*********************************************************************************************************
    ' Function Tadv() - returns the Advance Time for a specified Distance down the field
    '          Trec() -    "     "  Recession "   "  "     "         "      "   "    "
    '
    ' Inputs:   AdvTable    - Advance Profile
    '           RecTable    - Recession Profile
    '           Dist        - Distance down the field
    '
    ' Returns:  Double  - Advance/Recession/Opportunity Time for Dist, if any
    '*********************************************************************************************************
    Public Function Tadv(ByVal AdvTable As DataTable, ByVal Dist As Double) As Double
        Tadv = Double.NaN

        If (AdvTable IsNot Nothing) Then
            If (1 < AdvTable.Rows.Count) Then

                Dim advRow0 As DataRow = AdvTable.Rows(0)
                Dim xAdv0 As Double = CDbl(advRow0(0))
                Dim time0 As Double = CDbl(advRow0(1))

                For rdx As Integer = 1 To AdvTable.Rows.Count - 1

                    Dim advRow1 As DataRow = AdvTable.Rows(rdx)
                    Dim xAdv1 As Double = CDbl(advRow1(0))
                    Dim time1 As Double = CDbl(advRow1(1))

                    If ((xAdv0 <= Dist) And (Dist < xAdv1)) Then
                        Dim ratio As Double = (Dist - xAdv0) / (xAdv1 - xAdv0)
                        Tadv = time0 + (time1 - time0) * ratio
                        Exit Function
                    ElseIf (Dist = xAdv1) Then
                        Tadv = time1
                        Exit Function
                    End If

                    advRow0 = advRow1
                    xAdv0 = xAdv1
                    time0 = time1

                Next
            End If
        End If

    End Function

    Public Function Trec(ByVal RecTable As DataTable, ByVal Dist As Double) As Double
        Trec = Double.NaN

        If (RecTable IsNot Nothing) Then
            If (1 < RecTable.Rows.Count) Then

                Dim recRow0 As DataRow = RecTable.Rows(0)
                Dim xRec0 As Double = CDbl(recRow0(0))
                Dim time0 As Double = CDbl(recRow0(1))

                For rdx As Integer = 1 To RecTable.Rows.Count - 1

                    Dim recRow1 As DataRow = RecTable.Rows(rdx)
                    Dim xRec1 As Double = CDbl(recRow1(0))
                    Dim time1 As Double = CDbl(recRow1(1))

                    If ((xRec0 <= Dist) And (Dist < xRec1)) Then
                        Dim ratio As Double = (Dist - xRec0) / (xRec1 - xRec0)
                        Trec = time0 + (time1 - time0) * ratio
                        Exit Function
                    ElseIf (Dist = xRec1) Then
                        Trec = time1
                        Exit Function
                    End If

                    recRow0 = recRow1
                    xRec0 = xRec1
                    time0 = time1

                Next
            End If
        End If

    End Function

#End Region

#Region " Opportunity Time "

    Public Function OpportunityTimeCurve(ByVal AdvTable As DataTable, ByVal RecTable As DataTable, _
                                         ByVal TrecLimit As Double) As DataTable
        OpportunityTimeCurve = Nothing

        If ((AdvTable IsNot Nothing) And (RecTable IsNot Nothing)) Then

            OpportunityTimeCurve = New DataTable("Opportunity Time")
            OpportunityTimeCurve.Columns.Add("X (m)", GetType(Double))
            OpportunityTimeCurve.Columns.Add("T (s)", GetType(Double))

            For Each advRow As DataRow In AdvTable.Rows
                Dim dist As Double = CDbl(advRow.Item(0))
                Dim tAdv As Double = CDbl(advRow.Item(1))
                Dim tRec As Double = Me.Trec(RecTable, dist)

                If (0.0 < TrecLimit) Then ' Recession time is limited
                    If (tRec > TrecLimit) Then
                        tRec = TrecLimit
                    End If
                End If

                Dim tOpp As Double = Math.Max(tRec - tAdv, 0.0)

                Dim oppRow As DataRow = OpportunityTimeCurve.NewRow
                oppRow.Item(0) = dist
                oppRow.Item(1) = tOpp
                OpportunityTimeCurve.Rows.Add(oppRow)
            Next advRow

        End If ' (AdvTable IsNot Nothing)
    End Function

#End Region

#End Region

#Region " Methods "
    '
    ' Clear all large ArrayList and DataTable results data from the DataStore
    '
    Public Sub ClearResults()
        Me.ClearAdvance()
        Me.ClearRecession()
        Me.ClearLongitudinalInfiltration()
        Me.ClearFlowHydrographs()
    End Sub

#End Region

End Class
