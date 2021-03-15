
'*************************************************************************************************************
' Surface Flow properties
'
' SurfaceFlow stores data that describes how irrigation water flows over the surface of the field.
'
' NOTE: This class should be used for calculated Results only.  No user input data should be stored here.
'*************************************************************************************************************
Imports DataStore

Public Class SurfaceFlow

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Surface Flow"
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

#Region " Serialized Properties "

#Region " Inflow "
    '
    ' Cutoff Time (Tco)
    '
    Public Const sSimCutoffTime As String = "Sim Cutoff Time"
    Public Const sTco As String = "Tco"

    Public ReadOnly Property TcoProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSimCutoffTime)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Seconds)
                mMyStore.AddProperty(sSimCutoffTime, sTco, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sSimCutoffTime)
            End If

            _propertyNode.Symbol = sTco
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property Tco() As DoubleParameter
        Get
            Return TcoProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            TcoProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Average Inflow Rate (Q0avg)
    '
    Public Const sSimAverageInflowRate As String = "Sim Average Inflow Rate"
    Public Const sQ0avg As String = "Q0avg"

    Public ReadOnly Property Q0avgProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSimAverageInflowRate)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Cms)
                mMyStore.AddProperty(sSimAverageInflowRate, sQ0avg, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sSimAverageInflowRate)
            End If

            _propertyNode.Symbol = sQ0avg
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property Q0avg() As DoubleParameter
        Get
            Return Q0avgProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            Q0avgProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Advance "
    '
    ' Advance Set
    '
    Public Const sAdvanceSet As String = "Advance Set"
    Public ReadOnly Property AdvanceSetProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvanceSet)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _advanceSet As DataSet = New DataSet(sAdvanceSet)

                Dim _parameter As DataSetParameter = New DataSetParameter(_advanceSet)
                mMyStore.AddProperty(sAdvanceSet, _parameter)
                _propertyNode = mMyStore.GetProperty(sAdvanceSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AdvanceSet() As DataSetParameter
        Get
            Dim _set As DataSetParameter = AdvanceSetProperty.GetDataSetParameter()
            Return _set
        End Get
        Set(ByVal Value As DataSetParameter)
            AdvanceSetProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearAdvanceSet()
        mMyStore.DeleteProperty(sAdvanceSet)
    End Sub
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

            If (_table.Value IsNot Nothing) Then
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
    '
    ' Max Advance Velocity (Vmax)
    '
    Public Const sMaxAdvanceVelocity As String = "Max Advance Velocity"
    Public Const sVmax As String = "Vmax"

    Public ReadOnly Property MaxAdvanceVelocityProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaxAdvanceVelocity)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.MetersPerSecond)
                mMyStore.AddProperty(sMaxAdvanceVelocity, sVmax, _double, True)
                _propertyNode = mMyStore.GetProperty(sMaxAdvanceVelocity)
            End If

            _propertyNode.Symbol = sVmax
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property MaxAdvanceVelocity() As DoubleParameter
        Get
            Return MaxAdvanceVelocityProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaxAdvanceVelocityProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Max Advance Distance (Xmax)
    '
    Public Const sAdvanceDistance As String = "Max Advance Distance"
    Public Const sXmax As String = "Xmax"

    Public ReadOnly Property XmaxProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvanceDistance)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Meters)
                mMyStore.AddProperty(sAdvanceDistance, sXmax, _double, True)
                _propertyNode = mMyStore.GetProperty(sAdvanceDistance)
            End If

            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property Xmax() As DoubleParameter
        Get
            Return XmaxProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            XmaxProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Max Advance Time (Txa)
    '
    Public Const sAdvanceTime As String = "Max Advance Time"
    Public Const sTxa As String = "Txa"

    Public ReadOnly Property TxaProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvanceTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Seconds)
                mMyStore.AddProperty(sAdvanceTime, sTxa, _double, True)
                _propertyNode = mMyStore.GetProperty(sAdvanceTime)
            End If

            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property Txa() As DoubleParameter
        Get
            Return TxaProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            TxaProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Advance Time Ratio
    '
    Public Const sAdvanceTimeRatio As String = "Advance Time Ratio"

    Public ReadOnly Property AdvanceTimeRatioProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvanceTimeRatio)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Fraction)
                mMyStore.AddProperty(sAdvanceTimeRatio, _double, True)
                _propertyNode = mMyStore.GetProperty(sAdvanceTimeRatio)
            Else
                Dim _double As DoubleParameter = _propertyNode.GetParameter()
                _double.Units = Units.Fraction
            End If

            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property AdvanceTimeRatio() As DoubleParameter
        Get
            Dim _double As DoubleParameter = AdvanceTimeRatioProperty.GetDoubleParameter()
            _double.Units = Units.Fraction
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            AdvanceTimeRatioProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Advance Time to Field End (TL)
    '
    Public Const sAdvanceTimeToFieldEnd As String = "Advance Time to Field End"
    Public Const sTL As String = "TL"

    Public ReadOnly Property TLProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvanceTimeToFieldEnd)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Seconds)
                mMyStore.AddProperty(sAdvanceTimeToFieldEnd, sTL, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sAdvanceTimeToFieldEnd)
            End If

            _propertyNode.Symbol = sTL
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property TL() As DoubleParameter
        Get
            Return TLProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            TLProperty.SetParameter(Value)
        End Set
    End Property

    Public Function AdvanceTimeToEndOfField() As Double
        Dim _advTime As Double = TL.Value

        If (Double.IsNaN(_advTime)) Then
            Dim _length As Double = mUnit.SystemGeometryRef.Length.Value
            _advTime = Me.AdvanceAtDistance(_length)
        End If

        Return _advTime
    End Function
    '
    ' Cutoff Location Ratio (Xa R)
    '
    Public Const sXaR As String = "Xa R"
    Public Const sXR As String = "XR"

    Public ReadOnly Property XaRProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sXaR)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Fraction)
                mMyStore.AddProperty(sXaR, sXR, _double, True)
                _propertyNode = mMyStore.GetProperty(sXaR)
            Else
                Dim _double As DoubleParameter = _propertyNode.GetParameter()
                _double.Units = Units.Fraction
            End If

            _propertyNode.Symbol = sXR
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property XaR() As DoubleParameter
        Get
            Dim _double As DoubleParameter = XaRProperty.GetDoubleParameter()
            _double.Units = Units.Fraction
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            XaRProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Recession "
    '
    ' Recession Set
    '
    Public Const sRecessionSet As String = "Recession Set"
    Public ReadOnly Property RecessionSetProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRecessionSet)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _recessionSet As DataSet = New DataSet(sRecessionSet)

                Dim _parameter As DataSetParameter = New DataSetParameter(_recessionSet)
                mMyStore.AddProperty(sRecessionSet, _parameter)
                _propertyNode = mMyStore.GetProperty(sRecessionSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property RecessionSet() As DataSetParameter
        Get
            Dim _set As DataSetParameter = RecessionSetProperty.GetDataSetParameter()
            Return _set
        End Get
        Set(ByVal Value As DataSetParameter)
            RecessionSetProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearRecessionSet()
        mMyStore.DeleteProperty(sRecessionSet)
    End Sub
    '
    ' Recession Table
    '
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

    Public Function RecessionAtHead() As Double
        Dim _time0 As Double = Double.NaN

        ' Get Recession Table
        Dim _recessionTable As DataTable = Recession.Value
        If Not (_recessionTable Is Nothing) Then
            If (3 < _recessionTable.Rows.Count) Then

                ' Get Distance & Time for first Recession row
                _time0 = CDbl(_recessionTable.Rows(0).Item(sTimeX))

                Dim _time1 As Double = CDbl(_recessionTable.Rows(1).Item(sTimeX))
                Dim _time2 As Double = CDbl(_recessionTable.Rows(2).Item(sTimeX))
                Dim _time3 As Double = CDbl(_recessionTable.Rows(3).Item(sTimeX))

                Dim _timeN As Double = CDbl(_recessionTable.Rows(_recessionTable.Rows.Count - 1).Item(sTimeX))

                '_time0 = _time1
                '_time0 = (_time0 + _time1) / 2.0
                _time0 += (_time1 - _time0) * 2.0 / 3.0

            End If
        End If

        Return _time0
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

#Region " Drainback & Runoff "
    '
    ' Percentage Runoff (RO %)
    '
    Public Const sPercentageRunoff As String = "Percentage Runoff"
    Public Const sROpct As String = "RO%"

    Public ReadOnly Property ROpProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPercentageRunoff)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Percentage)
                mMyStore.AddProperty(sPercentageRunoff, sROpct, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sPercentageRunoff)
            End If

            _propertyNode.Symbol = sROpct
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property ROpct() As DoubleParameter
        Get
            Return ROpProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            ROpProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Runoff Depth (RO d)
    '
    Public Const sRunoffDepth As String = "Runoff Depth"
    Public Const SDro As String = "Dro"

    Public ReadOnly Property ROdProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRunoffDepth)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, UnitsDefinition.Units.Millimeters)
                mMyStore.AddProperty(sRunoffDepth, SDro, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sRunoffDepth)
            End If

            _propertyNode.Symbol = SDro
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property ROd() As DoubleParameter
        Get
            Return ROdProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            ROdProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Drainback Depth (D_db)
    '
    Public Const sDrainbackDepth As String = "Drainback Depth"
    Public Const sDdb As String = "Ddb"

    Public ReadOnly Property DdbProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDrainbackDepth)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, UnitsDefinition.Units.Millimeters)
                mMyStore.AddProperty(sDrainbackDepth, sDdb, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sDrainbackDepth)
            End If

            _propertyNode.Symbol = sDdb
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property Ddb() As DoubleParameter
        Get
            Return DdbProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            DdbProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Gross Applied Depth (Dapp_g)
    '
    Public Const sGrossAppliedDepth As String = "Gross Applied Depth"
    Public Const sDappG As String = "Dapp G"

    Public ReadOnly Property DappGProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGrossAppliedDepth)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, UnitsDefinition.Units.Millimeters)
                mMyStore.AddProperty(sGrossAppliedDepth, sDappG, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sGrossAppliedDepth)
            End If

            _propertyNode.Symbol = sDappG
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property DappG() As DoubleParameter
        Get
            Return DappGProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            DappGProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Volumes "
    '
    ' Volume Error Percentage (Verr%)
    '
    Public Const sVolumeErrorPct As String = "Volume Error (%)"
    Public Const sVerrPct As String = "Verr%"

    Public ReadOnly Property VerrPctProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sVolumeErrorPct)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Percentage)
                mMyStore.AddProperty(sVolumeErrorPct, sVerrPct, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sVolumeErrorPct)
            End If

            _propertyNode.Symbol = sVerrPct
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property VerrPct() As DoubleParameter
        Get
            Return VerrPctProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            VerrPctProperty.SetParameter(Value)
        End Set
    End Property

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
    '
    ' Depth Hydrograph Table
    '
    Private Const sDepthHydrographs As String = "Depth Hydrographs"

    Public ReadOnly Property DepthHydrographsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepthHydrographs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sDepthHydrographs, _parameter)
                _propertyNode = mMyStore.GetProperty(sDepthHydrographs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepthHydrographs() As DataTableParameter
        Get
            Return DepthHydrographsProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            DepthHydrographsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearDepthHydrographs()
        mMyStore.DeleteProperty(sDepthHydrographs)
    End Sub

#End Region

#Region " Erosion "
    '
    ' Erosion / Deposition Table
    '
    Private Const sErosionDeposition As String = "Erosion / Deposition"

    Public ReadOnly Property ErosionDepositionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErosionDeposition)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sErosionDeposition, _parameter)
                _propertyNode = mMyStore.GetProperty(sErosionDeposition)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErosionDeposition() As DataTableParameter
        Get
            Return ErosionDepositionProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            ErosionDepositionProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearErosionDeposition()
        mMyStore.DeleteProperty(sErosionDeposition)
    End Sub
    '
    ' Erosion G Hydrograph Table
    '
    Public Const sErosionGHydrographs As String = "G Hydrographs - G(X,T)"

    Public ReadOnly Property ErosionGHydrographsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErosionGHydrographs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataSetParameter = New DataSetParameter
                mMyStore.AddProperty(sErosionGHydrographs, _parameter)
                _propertyNode = mMyStore.GetProperty(sErosionGHydrographs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErosionGHydrographs() As DataSetParameter
        Get
            Return ErosionGHydrographsProperty.GetDataSetParameter()
        End Get
        Set(ByVal Value As DataSetParameter)
            ErosionGHydrographsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearErosionGHydrographs()
        mMyStore.DeleteProperty(sErosionGHydrographs)
    End Sub
    '
    ' Erosion CGm Hydrograph Table
    '
    Public Const sErosionCGmHydrographs As String = "CGm Hydrographs - CGm(X,T)"

    Public ReadOnly Property ErosionCGmHydrographsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErosionCGmHydrographs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataSetParameter = New DataSetParameter
                mMyStore.AddProperty(sErosionCGmHydrographs, _parameter)
                _propertyNode = mMyStore.GetProperty(sErosionCGmHydrographs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErosionCGmHydrographs() As DataSetParameter
        Get
            Dim _parameter As DataSetParameter = ErosionCGmHydrographsProperty.GetDataSetParameter()
            If (_parameter Is Nothing) Then
                _parameter = New DataSetParameter
            End If
            Return _parameter
        End Get
        Set(ByVal Value As DataSetParameter)
            ErosionCGmHydrographsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearErosionCGmHydrographs()
        mMyStore.DeleteProperty(sErosionCGmHydrographs)
    End Sub
    '
    ' Erosion CGv Hydrograph Table
    '
    Public Const sErosionCGvHydrographs As String = "CGv Hydrographs - CGv(X,T)"

    Public ReadOnly Property ErosionCGvHydrographsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErosionCGvHydrographs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataSetParameter = New DataSetParameter
                mMyStore.AddProperty(sErosionCGvHydrographs, _parameter)
                _propertyNode = mMyStore.GetProperty(sErosionCGvHydrographs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErosionCGvHydrographs() As DataSetParameter
        Get
            Dim _parameter As DataSetParameter = ErosionCGvHydrographsProperty.GetDataSetParameter()
            If (_parameter Is Nothing) Then
                _parameter = New DataSetParameter
            End If
            Return _parameter
        End Get
        Set(ByVal Value As DataSetParameter)
            ErosionCGvHydrographsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearErosionCGvHydrographs()
        mMyStore.DeleteProperty(sErosionCGvHydrographs)
    End Sub
    '
    ' GL_xx - Soil loss per unit field area by quarter
    '
    Private Const sGL_xx As String = "GL_xx"

    Public ReadOnly Property GL_xxProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGL_xx)

            ' If it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As ArrayListParameter = New ArrayListParameter
                mMyStore.AddProperty(sGL_xx, _parameter)
                _propertyNode = mMyStore.GetProperty(sGL_xx)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property GL_xx() As ArrayListParameter
        Get
            Return GL_xxProperty.GetArrayListParameter
        End Get
        Set(ByVal Value As ArrayListParameter)
            GL_xxProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Profiles "
    '
    ' Surface Flow Elevation (H) Profile Table
    '
    Private Const sElevationProfiles As String = "Elevation Profiles"

    Public ReadOnly Property ElevationProfilesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sElevationProfiles)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sElevationProfiles, _parameter)
                _propertyNode = mMyStore.GetProperty(sElevationProfiles)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ElevationProfiles() As DataTableParameter
        Get
            Return ElevationProfilesProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            ElevationProfilesProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearElevationProfiles()
        mMyStore.DeleteProperty(sElevationProfiles)
    End Sub
    '
    ' Surface Flow Depth (Y) Profile Table
    '
    Private Const sDepthProfiles As String = "Depth Profiles"

    Public ReadOnly Property DepthProfilesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepthProfiles)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sDepthProfiles, _parameter)
                _propertyNode = mMyStore.GetProperty(sDepthProfiles)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepthProfiles() As DataTableParameter
        Get
            Return DepthProfilesProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            DepthProfilesProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearDepthProfiles()
        mMyStore.DeleteProperty(sDepthProfiles)
    End Sub
    '
    ' Average Surface Flow Area (AY) Profile Table
    '
    Private Const sAYavgProfile As String = "AYavg Profile"

    Public ReadOnly Property AYavgProfilesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAYavgProfile)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sAYavgProfile, _parameter)
                _propertyNode = mMyStore.GetProperty(sAYavgProfile)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AYavgProfile() As DataTableParameter
        Get
            Return AYavgProfilesProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            AYavgProfilesProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearAYavgProfiles()
        mMyStore.DeleteProperty(sAYavgProfile)
    End Sub

#End Region

#Region " Flow Depth "
    '
    ' Flow Depth (Ymax)
    '
    Public Const sFlowDepth As String = "Flow Depth"
    Public Const sYmax As String = "Ymax"

    Public ReadOnly Property YmaxProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFlowDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sFlowDepth, sYmax, _double, True)
                _propertyNode = mMyStore.GetProperty(sFlowDepth)
            End If

            _propertyNode.Symbol = sYmax
            _propertyNode.QueryOnly = True
            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property Ymax() As DoubleParameter
        Get
            Return YmaxProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            YmaxProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Upstream Depth
    '
    Public Const sUpstreamDepth As String = "Upstream Depth"
    Public Const sY0 As String = "Y0"

    Public ReadOnly Property UpstreamDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sUpstreamDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sUpstreamDepth, sY0, _double, True)
                _propertyNode = mMyStore.GetProperty(sUpstreamDepth)
            End If

            _propertyNode.Symbol = sY0
            _propertyNode.QueryOnly = True
            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property UpstreamDepth() As DoubleParameter
        Get
            Return UpstreamDepthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            UpstreamDepthProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Representative Wetted Perimeter for Infiltration
    '
    Public Const sRepresentativeWettedPerimeter As String = "Representative Wetted Perimeter"
    Public Const sWPrep As String = "WPrep"

    Public ReadOnly Property RepresentativeWettedPerimeterProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRepresentativeWettedPerimeter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sRepresentativeWettedPerimeter, sWPrep, _double, True)
                _propertyNode = mMyStore.GetProperty(sRepresentativeWettedPerimeter)
            End If

            _propertyNode.Symbol = sWPrep
            _propertyNode.QueryOnly = True
            _propertyNode.AltUnitSet = New UnitsSystem.ShapeUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property RepresentativeWettedPerimeter() As DoubleParameter
        Get
            Return RepresentativeWettedPerimeterProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            RepresentativeWettedPerimeterProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' NRCS Wetted Perimeter for Infiltration
    '
    Public Const sNrcsWettedPerimeter As String = "NRCS Wetted Perimeter"
    Public Const sWPnrcs As String = "WPnrcs"

    Public ReadOnly Property NrcsWettedPerimeterProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNrcsWettedPerimeter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sNrcsWettedPerimeter, sWPnrcs, _double, True)
                _propertyNode = mMyStore.GetProperty(sNrcsWettedPerimeter)
            End If

            _propertyNode.Symbol = sWPnrcs
            _propertyNode.QueryOnly = True
            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property NrcsWettedPerimeter() As DoubleParameter
        Get
            Return NrcsWettedPerimeterProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            NrcsWettedPerimeterProperty.SetParameter(Value)
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

#Region " Opportunity Time "
    '
    ' Derive Opportunity Time Table from Advance & Recession tables
    '
    ' Distance is 1st column in Opportunity Time table
    ' Time is 2nd column
    '
    Public ReadOnly Property OpportunityTimeTable() As DataTable
        Get
            ' Get the Advance & Recession tables
            Dim _advanceTable As DataTable = Advance.Value
            If Not (_advanceTable Is Nothing) Then
                Dim _recessionTable As DataTable = Recession.Value
                If Not (_recessionTable Is Nothing) Then

                    ' Build the Opportunity Time Table
                    Dim _opportunityTable As DataTable = New DataTable(sOpportunityTime)

                    If Not (_opportunityTable Is Nothing) Then

                        _opportunityTable.Columns.Add(sDistanceX, GetType(Double))
                        _opportunityTable.Columns.Add(sTimeX, GetType(Double))

                        For Each _recRow As DataRow In _recessionTable.Rows
                            Dim _distance As Double = CDbl(_recRow.Item(sDistanceX))
                            Dim _oppTime As Double = OpportunityAtDistance(_distance)

                            Dim _oppRow As DataRow = _opportunityTable.NewRow
                            _oppRow.Item(sDistanceX) = _distance
                            _oppRow.Item(sTimeX) = _oppTime
                            _opportunityTable.Rows.Add(_oppRow)
                        Next

                        Return _opportunityTable
                    End If
                End If
            End If

            Return Nothing
        End Get
    End Property

    Public Function OpportunityAtDistance(ByVal _distance As Double) As Double
        Dim _oppTime As Double = 0.0
        ' Get & verify Recession at this distance
        Dim _recTime As Double = Me.RecessionAtDistance(_distance)
        If Not (Double.IsNaN(_recTime)) Then
            If (0.0 < _recTime) Then
                ' There is Recession at this distance; compute Opportunity Time
                Dim _advTime As Double = Me.AdvanceAtDistance(_distance)
                _oppTime = _recTime - _advTime
            End If
        End If
        Return _oppTime
    End Function

#End Region

#Region " Inflow "
    '
    ' Derive Inflow Table from Flow Hydrographs
    '
    ' Time is 1st column in Flow Hydrographs table
    ' Inflow is 2nd column
    '
    Public ReadOnly Property InflowTable() As DataTable
        Get
            InflowTable = Nothing

            ' Get Flow Hydrographs Table
            Dim flowHydroTable As DataTable = FlowHydrographs.Value
            If (flowHydroTable IsNot Nothing) Then
                If (flowHydroTable.Columns IsNot Nothing) Then
                    If (1 < flowHydroTable.Columns.Count) Then
                        ' Extract Inflow Table from Flow Hydrographs Table
                        InflowTable = New DataTable("Inflow")
                        InflowTable.Columns.Add(sTimeX, GetType(Double))
                        InflowTable.Columns.Add(sInflowX, GetType(Double))

                        For Each flowHydroRow As DataRow In flowHydroTable.Rows
                            Dim inflowRow As DataRow = InflowTable.NewRow
                            inflowRow.Item(sTimeX) = flowHydroRow.Item(nTimeX)
                            inflowRow.Item(sInflowX) = flowHydroRow.Item(nInflowX)
                            InflowTable.Rows.Add(inflowRow)
                        Next flowHydroRow
                    End If
                End If
            End If
        End Get
    End Property

    Public Function TabulatedInflowVolume() As Double
        Dim QinTable As DataTable = Me.InflowTable
        TabulatedInflowVolume = DataTableIntegral(QinTable, sTimeX, sInflowX)
    End Function

    Public Function InflowVolume() As Double
        InflowVolume = Me.TabulatedInflowVolume
    End Function

    Public Function AverageInflow() As Double
        Dim QinTable As DataTable = Me.InflowTable
        Dim Vin As Double = DataTableIntegral(QinTable, sTimeX, sInflowX)
        Dim Tspan As Double = DataColumnSpan(QinTable, sTimeX)
        AverageInflow = Vin / Tspan
    End Function

    Public Function InflowDepth() As Double
        Dim Vin As Double = Me.TabulatedInflowVolume
        Dim Din As Double = Vin / mUnit.SystemGeometryRef.FieldArea
        Return Din
    End Function

#End Region

#Region " Runoff "
    '
    ' Derive Runoff Table from Flow Hydrographs
    '
    ' Time is 1st column in Flow Hydrographs table
    ' Runoff is last column
    '
    Public Function RunoffTable() As DataTable
        ' Get the Flow Hydrographs Table
        Dim _hydrographTable As DataTable = FlowHydrographs.Value

        If Not (_hydrographTable Is Nothing) Then
            If (_hydrographTable.Columns.Contains(sRunoffX)) Then
                ' Extract the Runoff Table from Flow Hydrographs Table
                Dim _runoffTable As DataTable = New DataTable("Runoff")
                _runoffTable.Columns.Add(sTimeX, GetType(Double))
                _runoffTable.Columns.Add(sRunoffX, GetType(Double))

                For Each _hydroRow As DataRow In _hydrographTable.Rows
                    Dim _runoffRow As DataRow = _runoffTable.NewRow
                    _runoffRow.Item(sTimeX) = _hydroRow.Item(sTimeX)
                    _runoffRow.Item(sRunoffX) = _hydroRow.Item(sRunoffX)
                    _runoffTable.Rows.Add(_runoffRow)
                Next

                Return _runoffTable
            End If
        End If

        Return Nothing
    End Function

    Public Function TabulatedRunoffVolume() As Double
        Dim table As DataTable = Me.RunoffTable
        TabulatedRunoffVolume = DataTableIntegral(table, sTimeX, sRunoffX)
    End Function

    Public Function RunoffVolume() As Double
        Dim Vro As Double = Me.TabulatedRunoffVolume

        If (Vro = 0.0) Then
            Dim depth As Double = Me.ROd.Value
            If Not (Double.IsNaN(depth)) Then
                Vro = depth * mUnit.SystemGeometryRef.FieldArea
            End If
        End If

        Return Vro
    End Function

    Public Function RunoffDepth() As Double
        Dim Dro As Double = Me.ROd.Value

        If (Double.IsNaN(Dro)) Then
            Dim volume As Double = Me.TabulatedRunoffVolume
            Dro = volume / mUnit.SystemGeometryRef.FieldArea
        End If

        Return Dro
    End Function

#End Region

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
        ' Add SurfaceFlow to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "SurfaceFlow not added to Data Store")
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

#Region " Methods "
    '
    ' Clear all large ArrayList and DataTable results data from the DataStore
    '
    Public Sub ClearResults()
        Me.ClearAdvance()
        Me.ClearAdvanceSet()
        Me.ClearRecession()
        Me.ClearRecessionSet()
        Me.ClearFlowHydrographs()
        Me.ClearDepthHydrographs()
        Me.ClearElevationProfiles()
        Me.ClearDepthProfiles()
        Me.ClearAYavgProfiles()

        Me.ClearErosionDeposition()
        Me.ClearErosionGHydrographs()
        Me.ClearErosionCGmHydrographs()
        Me.ClearErosionCGvHydrographs()
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        Advance
        Recession
    End Enum
    '
    ' Event generated when a property changes
    '
    Public Event PropertyDataChanged(ByVal _reason As Reasons)
    '
    ' MyStore generates change events
    '
    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged
        ' Regenerate the DataStore event as a Farm event
        Select Case _id
            Case sAdvance
                RaiseEvent PropertyDataChanged(Reasons.Advance)
            Case sRecession
                RaiseEvent PropertyDataChanged(Reasons.Recession)
        End Select
    End Sub

#End Region

End Class
