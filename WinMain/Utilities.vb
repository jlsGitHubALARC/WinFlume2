
'**********************************************************************************************
' Utilities - General purpose utilities
'
Imports System.IO
Imports System.Collections.Generic

Imports DataStore
Imports GraphingUI
Imports PrintingUI

Module Utilities

#Region " Constants "

    Const OneDecimeter As Double = Srfr.Globals.OneDecimeter
    Const OneMillimeter As Double = Srfr.Globals.OneMillimeter
    Const SquareMetersPerHectare As Double = Srfr.Globals.SquareMetersPerHectare

#End Region

#Region " WinSRFR Utilities "
    '
    ' Retrieve the Product Name or Version from the DataStore
    '
    ' For opened files, this is the name or version of WinSRFR that wrote the file
    ' For created files, this is for the current version of WinSRFR
    '
    Public Function ProductName() As String

        Dim _name As String = Nothing

        ' Get reference to DataStore
        Dim _dataStore As DataStore.DataStore = DataStore.DataStore.Instance()

        If Not (_dataStore Is Nothing) Then
            Dim _versionParameter As StringParameter = Nothing

            ' Name of Product
            _versionParameter = _dataStore.GetStringParameter(WinSRFR.MyID + "." + WinSRFR.sProductName)
            If Not (_versionParameter Is Nothing) Then
                _name = _versionParameter.Value
            End If
        End If

        Return _name
    End Function

    Public Function ProductVersion() As String

        Dim _version As String = Application.ProductVersion

        ' Get reference to DataStore
        Dim _dataStore As DataStore.DataStore = DataStore.DataStore.Instance()

        If (_dataStore IsNot Nothing) Then
            Dim _versionID As String = WinSRFR.MyID + "." + WinSRFR.sProductVersion

            ' Current name of Project Version
            Dim _versionParameter As StringParameter = _dataStore.GetStringParameter(_versionID)
            If (_versionParameter IsNot Nothing) Then
                _version = _versionParameter.Value
            Else
                _versionID = WinSRFR.MyID + "." + "Version"

                ' Previous name of Project Version
                _versionParameter = _dataStore.GetStringParameter(_versionID)
                If (_versionParameter IsNot Nothing) Then
                    _version = _versionParameter.Value
                End If
            End If
        End If

        Return _version

    End Function

    Public ReadOnly Property MajorVersion() As String
        Get
            Dim _productVersion As String = ProductVersion()
            Dim _versions As String() = _productVersion.Split(".".ToCharArray, 3)
            Return _versions(0)
        End Get
    End Property

    Public ReadOnly Property MinorVersion() As String
        Get
            Dim _productVersion As String = ProductVersion()
            Dim _versions As String() = _productVersion.Split(".".ToCharArray, 3)

            If (1 < _versions.Length) Then
                Return _versions(1)
            Else
                Return "1"
            End If
        End Get
    End Property

    Public ReadOnly Property BetaVersion() As String
        Get
            Dim _productVersion As String = ProductVersion()
            Dim _versions As String() = _productVersion.Split(".".ToCharArray, 3)

            If (2 < _versions.Length) Then
                Return _versions(2)
            Else
                Return "0"
            End If
        End Get
    End Property

#End Region

#Region " RichTextBox Utilities "
    '
    ' Append the Field ID (i.e. its FARM & FIELD names) to the RichTextBox text
    '
    Public Sub AppendFieldIdText(ByRef _rtb As Windows.Forms.RichTextBox, _
                                 ByVal _winSRFR As WinSRFR, _
                                 ByVal _farmName As String, _
                                 ByVal _fieldName As String, _
                                 ByVal _len As Integer)

        Const ColonText As String = ": "
        Const SeparatorText As String = ", "
        Const MoreText As String = "..."

        Dim _farmOverhead As Integer = _winSRFR.ProjectFarmText.Length + ColonText.Length + SeparatorText.Length
        Dim _fieldOverhead As Integer = _winSRFR.CaseFieldText.Length + ColonText.Length
        '
        ' Append the Farm Name; shortened if necessary to fit into at most 1/2 the length specified
        '
        Dim _fieldLength As Double = _fieldName.Length + _fieldOverhead
        If ((_len / 2) < _fieldLength) Then
            ' Field Name requires more than 1/2 the available length
            If (((_len / 2) - _farmOverhead) < _farmName.Length) Then
                _farmName = _farmName.Substring(0, CInt((_len / 2) - _farmOverhead - MoreText.Length)) + MoreText
            End If
        Else
            ' Field Name requires less than 1/2 the available length
            If (((_len - _fieldLength) - _farmOverhead) < _farmName.Length) Then
                _farmName = _farmName.Substring(0, CInt((_len - _fieldLength) - _farmOverhead - MoreText.Length)) + MoreText
            End If
        End If

        AppendBoldText(_rtb, _winSRFR.ProjectFarmText + ColonText)
        AppendText(_rtb, _farmName + SeparatorText)

        ' Use remaining length for the Field name
        _len = _len - _winSRFR.ProjectFarmText.Length - ColonText.Length - _farmName.Length - SeparatorText.Length
        '
        ' Append the Field Name; shortened if necessary to fit in the remaining length
        '
        If ((_len - _fieldOverhead) < _fieldName.Length) Then
            _fieldName = _fieldName.Substring(0, (_len - _fieldOverhead - MoreText.Length)) + MoreText
        End If

        AppendBoldText(_rtb, _winSRFR.CaseFieldText + ColonText)
        AppendText(_rtb, _fieldName)

    End Sub

    Public Sub AppendFieldIdText(ByRef _rtb As Windows.Forms.RichTextBox, _
                                 ByVal _unit As Unit, _
                                 ByVal _len As Integer)

        ' Get the Farm & Field names via the Unit
        If Not (_unit Is Nothing) Then

            Dim _winSRFR As WinSRFR = _unit.WorldRef.FieldRef.FarmRef.WinSrfrRef

            Dim _farmName As String = _unit.WorldRef.FieldRef.FarmRef.Name.Value
            Dim _fieldName As String = _unit.WorldRef.FieldRef.Name.Value

            AppendFieldIdText(_rtb, _winSRFR, _farmName, _fieldName, _len)

        End If

    End Sub
    '
    ' Append the Unit's ID (i.e. its EVENT/OPERATIONS/DESIGN/SIMULATION & ANALYSIS names) to the RichTextBox text
    '
    Public Sub AppendUnitIdText(ByRef _rtb As Windows.Forms.RichTextBox, _
                                ByVal _unit As Unit, _
                                ByVal _len As Integer)

        Const ColonText As String = ": "
        Const SeparatorText As String = ", "
        Const MoreText As String = "..."

        Dim _worldLabel As String = "N/A"
        Dim _worldName As String = "none"
        Dim _analysisLabel As String = "N/A"
        Dim _analysisName As String = "none"

        Dim dictionary As Dictionary = dictionary.Instance

        If Not (_unit Is Nothing) Then

            '_worldLabel = WorldsText(_unit.UnitType.Value)
            _worldLabel = dictionary.tFolder.Translated
            _worldName = _unit.WorldRef.Name.Value
            _analysisName = _unit.Name.Value

            If (_unit.UnitType.Value = WorldTypes.SimulationWorld) Then
                _analysisLabel = dictionary.tSimulation.Translated
            Else
                _analysisLabel = dictionary.tAnalysis.Translated
            End If

        End If

        _worldLabel += ColonText
        _analysisLabel += ColonText

        Dim _worldOverhead As Integer = _worldLabel.Length + SeparatorText.Length
        Dim _analysisOverhead As Integer = _analysisLabel.Length
        '
        ' Append the World Name; shortened if necessary to fit into at most 1/2 the length specified
        '
        Dim _analysisLength As Double = _analysisName.Length + _analysisOverhead
        If ((_len / 2) < _analysisLength) Then
            ' Analysis Name requires more than 1/2 the available length
            If (((_len / 2) - _worldOverhead) < _worldName.Length) Then
                _worldName = _worldName.Substring(0, CInt((_len / 2) - _worldOverhead - MoreText.Length)) + MoreText
            End If
        Else
            ' Analysis Name requires less than 1/2 the available length
            If (((_len - _analysisLength) - _worldOverhead) < _worldName.Length) Then
                _worldName = _worldName.Substring(0, CInt((_len - _analysisLength) - _worldOverhead - MoreText.Length)) + MoreText
            End If
        End If

        AppendBoldText(_rtb, _worldLabel)
        AppendText(_rtb, _worldName + SeparatorText)

        ' Use remaining length for the Unit name
        _len = _len - _worldLabel.Length - _worldName.Length - SeparatorText.Length
        '
        ' Append the Analysis Name; shortened if necessary to fit in the remaining length
        '
        If ((_len - _analysisOverhead) < _analysisName.Length) Then
            _analysisName = _analysisName.Substring(0, (_len - _analysisOverhead - MoreText.Length)) + MoreText
        End If

        AppendBoldText(_rtb, _analysisLabel)
        AppendText(_rtb, _analysisName)

    End Sub

#End Region

#Region " UI Utilities "
    '
    ' Get the Selection Flags based on the World Type, Cross Section & User Level
    '
    ' These flags control what UI selections are available to the user.
    '
    Public Function GetSelFlags(ByVal _type As WorldTypes, _
                                ByVal _crossSection As CrossSections, _
                                ByVal _userLevel As UserLevels) As SelFlags

        Dim _flags As SelFlags = 0

        ' Determine World & Cross section usage
        Select Case _type

            Case WorldTypes.EventWorld

                _flags = _flags Or Globals.SelFlags.EventAnalysis

            Case WorldTypes.DesignWorld

                _flags = _flags Or Globals.SelFlags.PhysicalDesign

                Select Case (_crossSection)
                    Case CrossSections.Basin, CrossSections.Border
                        _flags = _flags Or Globals.SelFlags.Border
                    Case Else ' CrossSections.Furrow
                        _flags = _flags Or Globals.SelFlags.Furrow
                End Select

            Case WorldTypes.OperationsWorld

                _flags = _flags Or Globals.SelFlags.OperationsAnalysis

                Select Case (_crossSection)
                    Case CrossSections.Basin, CrossSections.Border
                        _flags = _flags Or Globals.SelFlags.Border
                    Case Else ' CrossSections.Furrow
                        _flags = _flags Or Globals.SelFlags.Furrow
                End Select

            Case WorldTypes.SimulationWorld

                _flags = _flags Or Globals.SelFlags.Simulation

                _flags = _flags Or Globals.SelFlags.Srfr

                Select Case (_crossSection)
                    Case CrossSections.Basin, CrossSections.Border
                        _flags = _flags Or Globals.SelFlags.Border
                    Case Else ' CrossSections.Furrow
                        _flags = _flags Or Globals.SelFlags.Furrow
                End Select

        End Select

        ' Determine Standard, Advanced user level
        Select Case (_userLevel)
            Case Globals.UserLevels.Research
                _flags = _flags Or Globals.SelFlags.Research
            Case Globals.UserLevels.Advanced
                _flags = _flags Or Globals.SelFlags.Advanced
            Case Else ' Assume Standard
                _flags = _flags Or Globals.SelFlags.Standard
        End Select

        Return _flags

    End Function
    '
    ' Load User Preference colors into Graphs
    '
    Public Sub LoadUserColors(ByVal _graph2D As ctl_Graph2D)
        Dim _userPreferences As UserPreferences = UserPreferences.Instance

        For _color As Integer = 0 To 9
            _graph2D.ColorN(_color) = _userPreferences.ColorN(_color)
        Next
    End Sub

    Public Sub LoadUserPreferences(ByVal _contour2D As ctl_Contour2D)
        Dim _userPreferences As UserPreferences = UserPreferences.Instance

        ' Colors
        For _color As Integer = 0 To 9
            _contour2D.ColorN(_color) = _userPreferences.ColorN(_color)
            _contour2D.FillColorN(_color) = _userPreferences.FillColorN(_color)
        Next

        ' Graph Options
        _contour2D.DisplayTitle = _userPreferences.DisplayTitle
        _contour2D.DisplaySubtitles = _userPreferences.DisplaySubtitles
        _contour2D.DisplayAxisLabels = _userPreferences.DisplayAxisLabels

        ' Contour Options
        _contour2D.DisplayContourKey = _userPreferences.DisplayContourKey
        _contour2D.DisplayContourLabels = _userPreferences.DisplayContourLabels
        _contour2D.DisplayContourPoints = _userPreferences.DisplayContourPoints
    End Sub

    '***********************************************************************************************
    ' Function CtrlNotVisible()         - check if UI Control is truely visible
    ' Function ParentCtrlNotVisible()   - check if UI Control's Parent is truely visible
    '
    ' Input(s):     Ctrl    - reference to Control
    '               pCtrl   - reference to Parent Control
    '
    ' Returns:      True    if any Ctrl or Parent up the heirarchy is Nothing or Not Visible
    '               False   if Control is truely visible
    '***********************************************************************************************
    Public Function CtrlNotVisible(ByVal Ctrl As Control) As Boolean

        If (Ctrl IsNot Nothing) Then
            If (Ctrl.Visible) Then
                Return ParentCtrlNotVisible(Ctrl.Parent)
            Else
                Return True
            End If
        Else
            Return True
        End If

    End Function

    Public Function ParentCtrlNotVisible(ByVal pCtrl As Control) As Boolean

        If (pCtrl IsNot Nothing) Then
            While (pCtrl IsNot Nothing)
                If (pCtrl.Visible = False) Then
                    Return True
                End If

                If ((pCtrl.GetType Is GetType(TabControl)) _
                 Or (pCtrl.GetType.IsSubclassOf(GetType(TabControl)))) Then
                    Exit While
                End If

                pCtrl = pCtrl.Parent
            End While

            If (pCtrl Is Nothing) Then
                Return True
            End If
        Else ' Parent Control is Nothing
            Return True
        End If

        Return False
    End Function

    '***********************************************************************************************
    ' Function HasFocus()   - checks a contained control of a specified type has focus
    '
    ' Input(s):     Ctrl        - reference to Control
    '               CtrlType    - Type of Control to check for focus
    '
    ' Returns:      True    if any contained control of specified type has focus
    '               False   otherwise
    '***********************************************************************************************
    Public Function HasFocus(ByVal Ctrl As Control, ByVal CtrlType As Type) As Boolean
        HasFocus = False

        If (Ctrl IsNot Nothing) Then
            If (Ctrl.GetType Is CtrlType) Then
                HasFocus = Ctrl.ContainsFocus
            Else
                For Each subCtrl As Control In Ctrl.Controls
                    If (HasFocus(subCtrl, CtrlType)) Then
                        Return True
                    End If
                Next
            End If

        End If
    End Function

#End Region

#Region " DataSet Utilities "

    Public Function FindValueAtDistanceAndTime(ByVal _dataSet As DataSet, _
                    ByVal _distance As Double, ByVal _time As Double) As Double

        ' Verify DataSet has proper tables
        If (DataSetHasData(_dataSet)) Then
            For Each table As DataTable In _dataSet.Tables
                Dim _tableName As String = table.TableName

                ' Check if name contains a value; if so parse it
                Dim _equals As Integer = _tableName.IndexOf("=")
                If (-1 < _equals) Then
                    Dim _name As String = _tableName.Substring(0, _equals + 1)
                    Dim _valString As String = _tableName.Substring(_equals + 1, _tableName.Length - _equals - 1)
                    Dim _tableDist As Double
                    Dim _units As Units
                    If (ParseValueWithUnits(_valString, _tableDist, _units)) Then
                        If (ThisClose(_tableDist, _distance, OneDecimeter)) Then
                            If (1 < table.Columns.Count) Then
                                Dim _value As Double = GetYforX(table, 0, _time, 1)
                                Return _value
                            End If
                        End If
                    End If
                End If
            Next
        End If

        Return 0.0

    End Function

    Public Function WddDataSet(ByVal unit As Unit, ByVal analysis As Analysis, _
                               ByVal x As Double, ByVal y As Double) As DataSet

        Dim mDictionary As Dictionary = Dictionary.Instance

        ' Validate input references
        If ((unit Is Nothing) Or (analysis Is Nothing)) Then
            Return Nothing
        End If

        ' Get DataStore references
        Dim systemGeometry As SystemGeometry = unit.SystemGeometryRef
        Dim inflowManagement As InflowManagement = unit.InflowManagementRef
        Dim criteria As BorderCriteria = unit.BorderCriteriaRef
        Dim unitSystem As UnitsSystem = UnitsSystem.Instance

        ' Compute data for Water Distribution Diagram
        analysis.ClearExecutionErrors()
        analysis.ClearExecutionWarnings()

        Dim contourPoint As ContourPoint = analysis.GetContourPoint(x, y, NumWddPoints)

        ' Get performance parameter for selected contour point
        Dim L As Double = analysis.Length
        Dim W As Double = analysis.Width
        Dim Q As Double = analysis.InflowRate
        Dim Qcb As Double = analysis.CutbackRate
        Dim Tco As Double = analysis.Tco
        Dim Tcb As Double = analysis.Tcb
        Dim TL As Double = analysis.TL
        Dim XR As Double = analysis.XR

        Dim AE As Double = analysis.AE
        Dim PAElq As Double = analysis.PAElq
        Dim PAEmin As Double = analysis.PAEmin
        Dim DUlq As Double = analysis.DUlq
        Dim DUmin As Double = analysis.DUmin

        Dim Dro As Double = analysis.RoDepth
        Dim ROf As Double = analysis.RoFraction
        Dim Ddp As Double = analysis.DpDepth
        Dim DPf As Double = analysis.DpFraction
        Dim Dmin As Double = analysis.DMin
        Dim Dlq As Double = analysis.DLf
        Dim Dapp As Double = analysis.DApp
        Dim Z As Double = analysis.DInf

        Dim hectares As Double = L * W / SquareMetersPerHectare
        Dim Cost As Double = analysis.Cost

        ' Build DataSet to hold graph lines
        Dim title As String = mDictionary.tDistributionOfInfiltratedDepths.Translated

        ' Add Depth Criteria
        Dim reqDepth As Double = inflowManagement.RequiredDepth.Value
        Dim reqDepthLabel As String = mDictionary.tRequiredDepth.Translated
        If Not (unit.UnitType.Value = WorldTypes.OperationsWorld) Then
            If (criteria.InfiltratedDepthCriterion.Value = InfiltratedDepthCriteria.MinimumDepth) Then
                title += " (Dreq = Dmin)"
            Else ' Assume Low-Quarter
                title += " (Dreq = Dlq)"
            End If
        End If

        Dim dataSet As DataSet = New DataSet(title)

        ' Infiltrated depths line
        Dim infDepths As DataTable = New DataTable(mDictionary.tInfiltration.Translated)
        infDepths.Columns.Add(mDictionary.tDistance.Translated, GetType(Double))
        infDepths.Columns.Add(mDictionary.tInfiltration.Translated, GetType(Double))

        Debug.Assert(analysis.Distances.Count = NumWddPoints)
        Debug.Assert(analysis.InfDepths.Count = NumWddPoints)
        For idx As Integer = 0 To NumWddPoints - 1
            Dim distance As Double = CDbl(analysis.Distances(idx))
            Dim infDepth As Double = CDbl(analysis.InfDepths(idx))
            Dim dataRow As DataRow = infDepths.NewRow
            dataRow.Item(0) = distance
            dataRow.Item(1) = infDepth
            infDepths.Rows.Add(dataRow)
        Next

        AddExtendedProperty(infDepths, "Key", True)
        AddExtendedProperty(infDepths, "Line", True)
        dataSet.Tables.Add(infDepths.Copy)

        ' Required depth line
        Dim maxDist As Double = CDbl(analysis.Distances(NumWddPoints - 1))
        Dim dreq As DataTable = DreqTable(reqDepth, mDictionary.tRequiredDepth.Translated, maxDist)
        dreq.TableName = reqDepthLabel
        AddExtendedProperty(dreq, "Key", True)
        AddExtendedProperty(dreq, "Line", True)
        AddExtendedProperty(dreq, "Color", Drawing.Color.Blue)
        dataSet.Tables.Add(dreq.Copy)

        ' Performance parameters go in Inset
        Dim insetLines As Integer = 7
        Dim asterisk As String = ""
        If (contourPoint.HasError) Then
            insetLines += 1
            asterisk = "**"
        ElseIf (contourPoint.HasWarning) Then
            insetLines += 1
            asterisk = "*"
        End If

        If Not (Double.IsNaN(TL)) Then
            insetLines += 1
        End If

        Dim parameters(insetLines) As String

        parameters(0) = mDictionary.tPerformanceIndicators.Translated & asterisk

        parameters(1) = "L   =" + LengthString(L, 10)
        parameters(2) = "W   =" + LengthString(W, 10)
        parameters(3) = "Q   =" + FlowRateString(Q, 10)
        parameters(4) = "Tco =" + TimeString(Tco, 10)

        If ((Double.IsNaN(TL)) Or (TL = 0)) Then
            parameters(5) = "                   "
        Else
            parameters(5) = "TL  =" + TimeString(TL, 10)
        End If

        If ((Double.IsNaN(XR)) Or (XR = 0)) Then
            parameters(6) = "                   "
        Else
            parameters(6) = "XR  =" + UnitText(XR, Units.None, 10)
        End If

        parameters(1) += "  RO % =" + PercentageString(ROf, 9)
        parameters(2) += "  Dro  =" + DepthString(Dro, 9)
        parameters(3) += "  DP % =" + PercentageString(DPf, 9)
        parameters(4) += "  Ddp  =" + DepthString(Ddp, 9)
        parameters(5) += "  Dapp =" + DepthString(Dapp, 9)

        If (inflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            parameters(6) += "                 "
        Else
            parameters(6) += "  Qcb  =" + FlowRateString(Qcb, 9)
        End If

        If (unit.UnitType.Value = WorldTypes.DesignWorld) Then
            parameters(1) += "  PAE  =" + PercentageString(PAEmin, 9)
        Else
            parameters(1) += "  AE   =" + PercentageString(AE, 9)
        End If

        If (criteria.InfiltratedDepthCriterion.Value = InfiltratedDepthCriteria.MinimumDepth) Then
            parameters(2) += "  DUmin=" + RatioString(DUmin, 9)
        Else ' Assume Low-Quarter
            parameters(2) += "  DUlq =" + RatioString(DUlq, 9)
        End If
        parameters(3) += "  Dinf =" + DepthString(Z, 9)
        parameters(4) += "  Dmin =" + DepthString(Dmin, 9)
        parameters(5) += "  Dlq  =" + DepthString(Dlq, 9)

        If (inflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            parameters(6) += "       " & mDictionary.tNoCutback.Translated
        Else
            parameters(6) += "  Tcb  =" + TimeString(Tcb, 9)
        End If

        parameters(7) = mDictionary.tCosts.Translated & " = " & AreaCostString(Cost) & ", " & mDictionary.tTotal.Translated & " =" + CostString(Cost * hectares, 9)

        If (contourPoint.HasError) Then
            parameters(8) = asterisk + mDictionary.tError.Translated & ": " + contourPoint.ErrMsg
        ElseIf (contourPoint.HasWarning) Then
            parameters(8) = asterisk + mDictionary.tWarning.Translated & ": " + contourPoint.WarnMsg
        End If

        dataSet.ExtendedProperties.Add("Inset", parameters)

        Return dataSet

    End Function

#End Region

#Region " DataTable Utilities "

    Public Function DoubleColumn(ByVal table As DataTable, ByVal col As Integer) As List(Of Double)
        DoubleColumn = New List(Of Double)

        If (table IsNot Nothing) Then ' there is a DataTable
            If ((0 < table.Rows.Count) And (col < table.Columns.Count)) Then ' and is has data

                For Each row As DataRow In table.Rows
                    Dim columnValue As Double = CDbl(row.Item(col))
                    DoubleColumn.Add(columnValue)
                Next
            End If
        End If

    End Function

    Public Function MinColumnValue(ByVal table As DataTable, ByVal col As Integer) As Double
        MinColumnValue = Double.MaxValue

        If (table IsNot Nothing) Then
            If ((0 < table.Rows.Count) And (col < table.Columns.Count)) Then
                For Each row As DataRow In table.Rows
                    Dim columnValue As Double = CDbl(row.Item(col))
                    If (columnValue < MinColumnValue) Then
                        MinColumnValue = columnValue
                    End If
                Next
            End If
        End If

    End Function

    Public Function MaxColumnValue(ByVal table As DataTable, ByVal col As Integer) As Double
        MaxColumnValue = Double.MinValue

        If (table IsNot Nothing) Then
            If ((0 < table.Rows.Count) And (col < table.Columns.Count)) Then
                For Each row As DataRow In table.Rows
                    Dim columnValue As Double = CDbl(row.Item(col))
                    If (columnValue > MaxColumnValue) Then
                        MaxColumnValue = columnValue
                    End If
                Next
            End If
        End If

    End Function
    '
    ' Find Y for given X in array of Single values
    '
    Public Function GetYforX(ByVal _array() As Single, ByVal _x As Single) As Single
        Dim _y As Single = Single.NaN

        If Not (_array Is Nothing) Then
            If (4 <= _array.Length) Then

                ' Get/chaeck first value in DataTable
                Dim _x1 As Single = _array(0)
                Dim _y1 As Single = _array(1)

                If (_x <= _x1) Then
                    ' Value is before first entry; return first Y value
                    Return _y1
                End If

                ' Scan array for first value larger than X
                Dim _count As Integer = CInt(_array.Length / 2)
                Dim _x2, _y2 As Single

                For idx As Integer = 1 To _count
                    _x2 = _array(idx * 2)
                    _y2 = _array((idx * 2) + 1)

                    If (_x < _x2) Then
                        ' Value is between two point; interpolate
                        _y = CSng((((_y2 - _y1) * (_x - _x1)) / (_x2 - _x1)) + _y1)
                        Return _y
                    ElseIf (_x = _x2) Then
                        ' Value is equal array entry; return its Y value
                        Return _y2
                    End If

                    ' Save values for next iteration
                    _x1 = _x2
                    _y1 = _y2
                Next

                ' Not found in array; return last Y value
                Return _y2
            End If
        End If

        Return _y
    End Function
    '
    ' Find Y for given X in DataTable
    '
    Public Function GetYforX(ByVal table As DataTable, _
                             ByVal _xCol As Integer, ByVal _x As Double, _
                             ByVal _yCol As Integer) As Double
        Dim _y As Double = Double.NaN

        If (DataTableHasData(table)) Then
            If ((_xCol < table.Columns.Count) And (_yCol < table.Columns.Count)) Then

                Dim _count As Integer = table.Rows.Count

                ' Get/check first & last values in DataTable
                Dim row As DataRow = table.Rows(0)
                Dim _x1 As Double = CDbl(row(_xCol))
                Dim _y1 As Double = CDbl(row(_yCol))

                Dim lastRow As DataRow = table.Rows(_count - 1)
                Dim _x2 As Double = CDbl(lastRow(_xCol))
                Dim _y2 As Double = CDbl(lastRow(_yCol))

                ' X values can be either increasing or decreasing
                Dim _start As Integer = 1
                Dim _end As Integer = _count - 1
                Dim _step As Integer = 1

                If (_x2 < _x1) Then
                    ' X values are decreasing
                    _start = _count - 2
                    _end = 0
                    _step = -1
                    _x1 = _x2
                    _y1 = _y2
                End If

                If (_x <= _x1) Then
                    ' Value is before first DataTable entry; return first Y value
                    Return _y1
                End If

                ' Scan DataTable for first value larger than X
                For idx As Integer = _start To _end Step _step
                    row = table.Rows(idx)
                    _x2 = CDbl(row(_xCol))

                    If (_x < _x2) Then
                        _y1 = CDbl(lastRow(_yCol))
                        _y2 = CDbl(row(_yCol))

                        If (Double.IsNaN(_y1) Or Double.IsNaN(_y2)) Then
                            Return Double.NaN
                        Else ' Value is between two points; interpolate
                            _y = (((_y2 - _y1) * (_x - _x1)) / (_x2 - _x1)) + _y1
                            Return _y
                        End If
                    ElseIf (_x = _x2) Then
                        ' Value is equal DataTable entry; return its Y value
                        _y2 = CDbl(row(_yCol))
                        Return _y2
                    End If

                    ' Save value for next iteration
                    lastRow = row
                    _x1 = _x2
                Next

                ' Not found in DataTable; return last Y value
                Return _y2
            End If
        End If

        Return _y
    End Function

    Public Function GetTimeColumn(ByVal table As DataTable, _
                                  ByVal _distances As ArrayList) As ArrayList
        Dim _times As ArrayList = New ArrayList

        If (DataTableHasData(table)) Then
            If ((DataColumnIsDouble(table, sDistanceX)) _
            And (DataColumnIsDouble(table, sTimeX))) Then
                ' Get last distance in data table
                Dim _rowItem As Object = table.Rows(table.Rows.Count - 1).Item(sDistanceX)
                Dim _lastDistance As Double = CDbl(_rowItem)
                ' Return equivalent time upto last distance
                For Each _distance As Double In _distances
                    If (_distance <= _lastDistance + 0.1) Then
                        Dim _time As Double = FindTimeAtDistance(table, _distance)
                        _times.Add(_time)
                    End If
                Next
            End If
        End If

        Return _times
    End Function

    Public Function GetInfiltrationColumn(ByVal table As DataTable, _
                                          ByVal _distances As ArrayList) As ArrayList
        Dim depths As ArrayList = New ArrayList

        If (DataTableHasData(table)) Then
            If ((DataColumnIsDouble(table, sDistanceX)) _
            And (DataColumnIsDouble(table, sInfiltrationX))) Then
                ' Get last distance in data table
                Dim _rowItem As Object = table.Rows(table.Rows.Count - 1).Item(sDistanceX)
                Dim _lastDistance As Double = CDbl(_rowItem)
                ' Return equivalent depths upto last distance
                For Each _distance As Double In _distances
                    If (_distance <= _lastDistance + 0.1) Then
                        Dim _depth As Double = FindInfiltrationAtDistance(table, _distance)
                        depths.Add(_depth)
                    End If
                Next
            End If
        End If

        Return depths
    End Function

    Public Function GetRunoffColumn(ByVal table As DataTable, _
                                    ByVal _times As ArrayList) As ArrayList
        Dim _runoffArray As ArrayList = New ArrayList

        If (DataTableHasData(table)) Then
            If ((DataColumnIsDouble(table, sTimeX)) _
            And (DataColumnIsDouble(table, sRunoffX))) Then
                ' Get last runoff time with a zero runoff
                Dim _firstRunoffTime As Double = 0.0
                For idx As Integer = 0 To table.Rows.Count - 1
                    ' Does this time have runoff?
                    Dim _rowItem As Object = table.Rows(idx).Item(sRunoffX)
                    Dim _runoff As Double = CDbl(_rowItem)
                    If (0 < _runoff) Then
                        ' Yes, use it as the start of runoff
                        If (0 < idx) Then
                            _rowItem = table.Rows(idx).Item(sTimeX)
                        Else
                            _rowItem = table.Rows(0).Item(sTimeX)
                        End If

                        _firstRunoffTime = CDbl(_rowItem)
                        Exit For
                    End If
                Next

                ' Return an array containing only runoff rates
                If (0 < _times.Count) Then
                    If (_times(0).GetType Is GetType(Double)) Then
                        ' Compute delta time between first runoff time and first requested time
                        Dim _firstReqTime As Double = CDbl(_times(0))
                        Dim _deltaTime As Double = _firstRunoffTime - _firstReqTime

                        ' Get the last runoff time
                        Dim _rowItem As Object = table.Rows(table.Rows.Count - 1).Item(sTimeX)
                        Dim _lastTime As Double = CDbl(_rowItem)

                        ' Build runoff array
                        For Each _time As Double In _times
                            If (_time <= _lastTime) Then
                                _time += _deltaTime
                                Dim _runoff As Double = FindRunoffAtTime(table, _time)
                                _runoffArray.Add(_runoff)
                            End If
                        Next
                    End If
                End If
            End If
        End If

        Return _runoffArray
    End Function

    '*********************************************************************************************************
    ' Function DoubleColumnByTimes() - return array list of column values matching input Times
    '
    ' Input(s):     Table       - DataTable containing column to get data from
    '               Tcol        - Time column number
    '               Times       - ArrayList of Times to get column data for
    '               Vcol        - Value column number
    '
    ' Returns       ArrayList   - Array List of data column values that match Times
    '*********************************************************************************************************
    Public Function DoubleColumnByTimes(ByVal Table As DataTable, _
                                        ByVal Tcol As Integer, _
                                        ByVal Times As ArrayList, _
                                        ByVal Vcol As Integer) As ArrayList
        Dim dblCol As ArrayList = New ArrayList

        If (DataTableHasData(Table)) Then
            If ((DataColumnIsDouble(Table, Tcol)) _
            And (DataColumnIsDouble(Table, Vcol))) Then

                For Each Time As Double In Times
                    Dim dbl As Double = FindDoubleAtTime(Table, Tcol, Time, Vcol)
                    dblCol.Add(dbl)
                Next Time

            End If
        End If

        Return dblCol
    End Function

    Public Function HasDistance(ByVal table As DataTable, _
                                ByVal _distance As Double) As Boolean

        ' Search DataRow for the specified distance
        If (DataTableHasData(table)) Then
            If (DataColumnIsDouble(table, sDistanceX)) Then
                For Each row As DataRow In table.Rows
                    Dim _rowDist As Double = CDbl(row.Item(sDistanceX))
                    If (ThisClose(_distance, _rowDist, 0.1)) Then
                        Return True
                    End If
                Next
            End If
        End If

        Return False

    End Function

    Public Function FindDistanceAtTime(ByVal table As DataTable, _
                                       ByVal _time As Double) As Double

        ' Verify DataTable has proper columns
        If (DataTableHasData(table)) Then
            If ((DataColumnIsDouble(table, sDistanceX)) _
            And (DataColumnIsDouble(table, sTimeX))) Then

                ' DataTable contains correct data
                Dim _numRows As Integer = table.Rows.Count

                ' If Time is before first row, return first row distance
                Dim _firstRow As Integer = 0
                Dim x1 As Double = CDbl(table.Rows(_firstRow).Item(sDistanceX))
                Dim _time1 As Double = CDbl(table.Rows(_firstRow).Item(sTimeX))
                If (_time <= _time1) Then
                    Return x1
                End If

                ' If Time is after last row, return last row distance
                Dim _lastRow As Integer = _numRows - 1
                Dim x2 As Double = CDbl(table.Rows(_lastRow).Item(sDistanceX))
                Dim _time2 As Double = CDbl(table.Rows(_lastRow).Item(sTimeX))
                If (_time2 < _time) Then
                    Return x2
                End If

                ' Time is within table
                For _row As Integer = 1 To _numRows - 1
                    x2 = CDbl(table.Rows(_row).Item(sDistanceX))
                    _time2 = CDbl(table.Rows(_row).Item(sTimeX))
                    If ((_time1 <= _time) And (_time <= _time2)) Then
                        Dim _dist As Double = x1 + (((_time - _time1) * (x2 - x1)) / (_time2 - _time1))
                        Return _dist
                    End If

                    x1 = x2
                    _time1 = _time2
                Next
            End If
        End If

        Return 0.0

    End Function

    Public Function FindTimeAtDistance(ByVal table As DataTable, _
                                       ByVal _distance As Double) As Double

        ' Verify DataTable has proper columns
        If (DataTableHasData(table)) Then
            If ((DataColumnIsDouble(table, sDistanceX)) _
            And (DataColumnIsDouble(table, sTimeX))) Then

                ' DataTable contains correct data
                Dim _numRows As Integer = table.Rows.Count

                ' If Distance is before first row, return first row time
                Dim x1 As Double = CDbl(table.Rows(0).Item(sDistanceX))
                Dim _time1 As Double = CDbl(table.Rows(0).Item(sTimeX))
                If (_distance <= x1) Then
                    Return _time1
                End If

                ' If Distance is within table, return interpolated time
                Dim x2, _time2 As Double
                For _row As Integer = 1 To _numRows - 1
                    x2 = CDbl(table.Rows(_row).Item(sDistanceX))
                    _time2 = CDbl(table.Rows(_row).Item(sTimeX))
                    If ((x1 <= _distance) And (_distance <= x2)) Then
                        Dim _time As Double = _time1 + (((_distance - x1) * (_time2 - _time1)) / (x2 - x1))
                        Return _time
                    End If

                    x1 = x2
                    _time1 = _time2
                Next

                ' Distance is after last row, return last row time
                Return _time2
            End If
        End If

        Return 0.0

    End Function

    Public Function FindInfiltrationAtDistance(ByVal table As DataTable, _
                                               ByVal _distance As Double) As Double

        ' Verify DataTable has proper columns
        If (DataTableHasData(table)) Then
            If ((DataColumnIsDouble(table, sDistanceX)) _
            And (DataColumnIsDouble(table, sInfiltrationX))) Then

                ' DataTable contains correct data
                Dim _numRows As Integer = table.Rows.Count

                ' If Distance is before first row, return first row time
                Dim x1 As Double = CDbl(table.Rows(0).Item(sDistanceX))
                Dim _infiltration1 As Double = CDbl(table.Rows(0).Item(sInfiltrationX))
                If (_distance <= x1) Then
                    Return _infiltration1
                End If

                ' If Distance is after last row, return last row infiltration
                Dim x2 As Double = CDbl(table.Rows(_numRows - 1).Item(sDistanceX))
                Dim _infiltration2 As Double = CDbl(table.Rows(_numRows - 1).Item(sInfiltrationX))
                If (x2 <= _distance) Then
                    Return _infiltration2
                End If

                ' Distance is within table
                For _row As Integer = 1 To _numRows - 1
                    x2 = CDbl(table.Rows(_row).Item(sDistanceX))
                    _infiltration2 = CDbl(table.Rows(_row).Item(sInfiltrationX))
                    If ((x1 <= _distance) And (_distance <= x2)) Then
                        Dim _infiltration As Double = _infiltration1 + (((_distance - x1) * (_infiltration2 - _infiltration1)) / (x2 - x1))
                        Return _infiltration
                    End If

                    x1 = x2
                    _infiltration1 = _infiltration2
                Next
            End If
        End If

        Return 0.0

    End Function

    Public Function FindRunoffAtTime(ByVal table As DataTable, _
                                     ByVal _time As Double) As Double

        ' Verify DataTable has proper columns
        If (DataTableHasData(table)) Then
            If ((DataColumnIsDouble(table, sTimeX)) _
            And (DataColumnIsDouble(table, sRunoffX))) Then

                ' DataTable contains correct data
                Dim _numRows As Integer = table.Rows.Count

                ' If Time is before first row, return first row time
                Dim _time1 As Double = CDbl(table.Rows(0).Item(sTimeX))
                Dim _rate1 As Double = CDbl(table.Rows(0).Item(sRunoffX))
                If (_time <= _time1) Then
                    Return _rate1
                End If

                ' If Time is after last row, return last row rate
                Dim _time2 As Double = CDbl(table.Rows(_numRows - 1).Item(sTimeX))
                Dim _rate2 As Double = CDbl(table.Rows(_numRows - 1).Item(sRunoffX))
                If (_time2 <= _time) Then
                    Return _rate2
                End If

                ' Time is within table
                For _row As Integer = 1 To _numRows - 1
                    _time2 = CDbl(table.Rows(_row).Item(sTimeX))
                    _rate2 = CDbl(table.Rows(_row).Item(sRunoffX))
                    If ((_time1 <= _time) And (_time <= _time2)) Then
                        Dim _rate As Double = _rate1 + (((_time - _time1) * (_rate2 - _rate1)) / (_time2 - _time1))
                        Return _rate
                    End If

                    _time1 = _time2
                    _rate1 = _rate2
                Next
            End If
        End If

        Return 0.0

    End Function

    '*********************************************************************************************************
    ' Function FindDoubleAtTime() - find Double value at the input Time
    '
    ' Input(s):     Table   - DataTable to search for Double value
    '               Tcol    - Time column number
    '               Time    - Time to search for
    '               Vcol    - Value column
    '
    ' Returns:      Double  - Value (possibly interpolated) at Time
    '*********************************************************************************************************
    Public Function FindDoubleAtTime(ByVal Table As DataTable, _
                                     ByVal Tcol As Integer, _
                                     ByVal Time As Double, _
                                     ByVal Vcol As Integer) As Double

        ' Verify DataTable has proper columns
        If (DataTableHasData(Table)) Then
            If ((DataColumnIsDouble(Table, Tcol)) _
            And (DataColumnIsDouble(Table, Vcol))) Then

                ' DataTable contains correct data
                Dim _numRows As Integer = Table.Rows.Count

                ' If Time is before first row, return first row data
                Dim _time1 As Double = CDbl(Table.Rows(0).Item(Tcol))
                Dim _data1 As Double = CDbl(Table.Rows(0).Item(Vcol))
                If (Time <= _time1) Then
                    Return _data1
                End If

                ' If Time is after last row, return last row data
                Dim _time2 As Double = CDbl(Table.Rows(_numRows - 1).Item(Tcol))
                Dim _data2 As Double = CDbl(Table.Rows(_numRows - 1).Item(Vcol))
                If (_time2 <= Time) Then
                    Return _data2
                End If

                ' Time is within table
                For _row As Integer = 1 To _numRows - 1
                    _time2 = CDbl(Table.Rows(_row).Item(Tcol))
                    _data2 = CDbl(Table.Rows(_row).Item(Vcol))
                    If ((_time1 <= Time) And (Time <= _time2)) Then
                        Dim _rate As Double = _data1 + (((Time - _time1) * (_data2 - _data1)) / (_time2 - _time1))
                        Return _rate
                    End If

                    _time1 = _time2
                    _data1 = _data2
                Next
            End If
        End If

        Return 0.0

    End Function

    Public Function AverageTimeOverDistance(ByVal Table As DataTable) As Double
        Dim integral As Double = DataTableIntegral(Table, sDistanceX, sTimeX)
        Dim Xspan As Double = DataColumnSpan(Table, sDistanceX)
        AverageTimeOverDistance = integral / Xspan
    End Function

    '*********************************************************************************************************
    ' DepthTable() - builds an Infiltrated Depth line for Infiltration graphs
    '
    ' DavgTable()    - Average Infiltrated Depth line for Infiltration graphs
    ' DreqTable()    - Dreq line for Infiltration graphs
    ' DeficitTable() - Soil Water Deficit line for Infiltration graphs
    '
    ' Inputs:   tableName   - name to assign to created DataTable & 2nd DataColumn
    '           depth       - infiltrated depth
    '           xLabel      - name to assign to 1st DataColumn
    '           xEnd        - X value for end-of-line (0.0 is X value for start-of-line)
    '
    Public Function DepthTable(ByVal tableName As String, ByVal depth As Double, _
                               ByVal xLabel As String, ByVal xEnd As Double) As DataTable

        ' Build and return required depth curve to DataSet
        Dim davg As DataTable = New DataTable(tableName)
        davg.Columns.Add(xLabel, GetType(Double))
        davg.Columns.Add(tableName, GetType(Double))

        ' Start of Depth line
        Dim dataRow As DataRow = davg.NewRow
        dataRow.Item(xLabel) = 0.0
        dataRow.Item(tableName) = depth
        davg.Rows.Add(dataRow)

        ' End of Depth line
        dataRow = davg.NewRow
        dataRow.Item(xLabel) = xEnd
        dataRow.Item(tableName) = depth
        davg.Rows.Add(dataRow)

        Return davg

    End Function

    Public Function DavgTable(ByVal depth As Double, ByVal xLabel As String, ByVal xEnd As Double) As DataTable
        Dim davg As DataTable = DepthTable("Davg", depth, xLabel, xEnd)
        Return davg
    End Function

    Public Function DreqTable(ByVal depth As Double, ByVal xLabel As String, ByVal xEnd As Double) As DataTable
        Dim dreq As DataTable = DepthTable("Dreq", depth, xLabel, xEnd)
        Return dreq
    End Function

    Public Function DeficitTable(ByVal depth As Double, ByVal xLabel As String, ByVal xEnd As Double) As DataTable
        Dim _deficit As DataTable = DepthTable("Deficit", depth, xLabel, xEnd)
        Return _deficit
    End Function

    '******************************************************************************************
    ' DataTableSubset()  - return a subset of a DataTable bounded by X & Y limits
    '
    ' Column  0 defines X value
    ' Columns 1+ define Y values
    '
    Public Function DataTableSubset(ByVal fullTable As DataTable, _
                                    ByVal minX As Double, ByVal maxX As Double, _
                                    ByVal minY As Double, ByVal maxY As Double) As DataTable
        ' Create DataTable subset
        Dim subset As DataTable = fullTable.Clone
        Dim colCount As Integer = fullTable.Columns.Count
        Dim rowCount As Integer = fullTable.Rows.Count
        Dim ratio As Double
        Dim lastX As Double

        ' Data table must at least of X values
        If (0 < colCount) Then
            Dim lastRow As DataRow = Nothing
            For Each row As DataRow In fullTable.Rows
                Dim subRow As DataRow = subset.NewRow

                If (lastRow Is Nothing) Then
                    lastRow = row
                End If

                ' Limit X values first
                Dim x As Double = CDbl(row.Item(0))
                If (x < minX) Then
                    ' X is before subset (x < minX); save row for future interpolation
                    lastRow = row

                ElseIf (x <= maxX) Then
                    ' X is within subset (minX <= x <= maxX)
                    lastX = CDbl(lastRow.Item(0))

                    ' Is X interpolation required?
                    If (lastX < minX) Then
                        ' Interpolated point at minX is required
                        ratio = (minX - lastX) / (x - lastX)

                        ' X is minX
                        subRow.Item(0) = minX

                        ' Interpolate Y(s)
                        If (1 < colCount) Then
                            For cdx As Integer = 1 To colCount - 1
                                Dim y As Double = CDbl(row.Item(cdx))
                                Dim lastY As Double = CDbl(lastRow.Item(cdx))
                                Dim intrY As Double = lastY + (y - lastY) * ratio
                                subRow.Item(cdx) = intrY
                            Next
                        End If

                        subset.Rows.Add(subRow)
                        subRow = subset.NewRow
                    End If

                    ' Save current point as is (its within subset)
                    For cdx As Integer = 0 To colCount - 1
                        subRow.Item(cdx) = row.Item(cdx)
                    Next

                    subset.Rows.Add(subRow)
                    lastRow = row

                Else ' Row is after subset (maxX < x)
                    lastX = CDbl(lastRow.Item(0))

                    ' Is X interpolation required?
                    If (lastX < minX) Then
                        ' Interpolated point at minX is required
                        ratio = (minX - lastX) / (x - lastX)

                        ' X is minX
                        subRow.Item(0) = minX

                        ' Interpolate Y(s)
                        If (1 < colCount) Then
                            For cdx As Integer = 1 To colCount - 1
                                Dim y As Double = CDbl(row.Item(cdx))
                                Dim lastY As Double = CDbl(lastRow.Item(cdx))
                                Dim intrY As Double = lastY + (y - lastY) * ratio
                                subRow.Item(cdx) = intrY
                            Next
                        End If

                        subset.Rows.Add(subRow)
                        subRow = subset.NewRow
                    End If

                    ' Interpolated point at maxX is required
                    ratio = (maxX - lastX) / (x - lastX)

                    ' X is maxX
                    subRow.Item(0) = maxX

                    ' Interpolate Y(s)
                    If (1 < colCount) Then
                        For cdx As Integer = 1 To colCount - 1
                            Dim y As Double = CDbl(row.Item(cdx))
                            Dim lastY As Double = CDbl(lastRow.Item(cdx))
                            Dim intrY As Double = lastY + (y - lastY) * ratio
                            subRow.Item(cdx) = intrY
                        Next
                    End If

                    subset.Rows.Add(subRow)

                    Exit For
                End If
            Next
        End If

        Return subset
    End Function
    '
    ' Load Kostiakov values from a DataRow; handle exceptions that may ocurr
    '
    Public Sub LoadKostiakovFromDataRow(ByVal row As DataRow, _
                                        ByRef k As Double, ByRef a As Double, ByRef b As Double, ByRef c As Double)
        Try
            If (row.Table.Columns.Contains(Srfr.Globals.sA)) Then
                a = CDbl(row.Item(Srfr.Globals.sA))
            ElseIf (row.Table.Columns.Contains(SoilCropProperties.sa)) Then
                a = CDbl(row.Item(SoilCropProperties.sa))
            End If
        Catch ex As Exception
        End Try

        Try
            If (row.Table.Columns.Contains(Srfr.Globals.sB)) Then
                b = CDbl(row.Item(Srfr.Globals.sB))
            ElseIf (row.Table.Columns.Contains(SoilCropProperties.sb)) Then
                b = CDbl(row.Item(SoilCropProperties.sb))
            End If
        Catch ex As Exception
        End Try

        Try
            If (row.Table.Columns.Contains(Srfr.Globals.sC)) Then
                c = CDbl(row.Item(Srfr.Globals.sC))
            ElseIf (row.Table.Columns.Contains(SoilCropProperties.sc)) Then
                c = CDbl(row.Item(SoilCropProperties.sc))
            End If
        Catch ex As Exception
        End Try

        Try
            If (row.Table.Columns.Contains(Srfr.Globals.sK)) Then
                k = CDbl(row.Item(Srfr.Globals.sK))
            ElseIf (row.Table.Columns.Contains(SoilCropProperties.sk)) Then
                k = CDbl(row.Item(SoilCropProperties.sk))
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Sub LoadBranchTimeFromDataRow(ByVal row As DataRow, ByRef Tb As Double)

        Try
            If (row.Table.Columns.Contains(Srfr.Globals.sTb)) Then
                Tb = CDbl(row.Item(Srfr.Globals.sTb))
            End If
        Catch ex As Exception
        End Try

    End Sub
    '
    ' Manage ExtendedProperties
    '
    Public Sub AddExtendedProperty(ByVal table As DataTable, ByVal key As String, ByVal value As Object)
        Try
            If (table.ExtendedProperties.Contains(key)) Then
                table.ExtendedProperties.Remove(key)
            End If
            table.ExtendedProperties.Add(key, value)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Public Sub AddExtendedProperty(ByVal col As DataColumn, ByVal key As String, ByVal value As Object)
        Try
            If (col.ExtendedProperties.Contains(key)) Then
                col.ExtendedProperties.Remove(key)
            End If
            col.ExtendedProperties.Add(key, value)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

#End Region

#Region " Math Functions "
    '
    ' Linear regression  (y = a + bx)
    '
    Public Sub LinearFit(ByVal x As ArrayList, ByVal y As ArrayList, _
                         ByRef a As Double, ByRef b As Double)

        Dim xDbl() As Double = ArrayListToDouble(x)
        Dim yDbl() As Double = ArrayListToDouble(y)

        Srfr.SrfrAPI.LinearFit(xDbl, yDbl, a, b)

    End Sub
    '
    ' Power regression  (y = ax^b)
    '
    Public Sub PowerFit(ByVal x As ArrayList, ByVal y As ArrayList, _
                        ByRef a As Double, ByRef b As Double)

        Dim xDbl() As Double = ArrayListToDouble(x)
        Dim yDbl() As Double = ArrayListToDouble(y)

        Srfr.SrfrAPI.PowerFit(xDbl, yDbl, a, b)

    End Sub
    '
    ' Calculate Advance curve's parameters (p & r)
    '
    Public Function AdvancePandR(ByVal advTable As DataTable, ByRef p As Double, ByRef r As Double) As Boolean

        If (UsePowerAdvanceLaw) Then ' use direct Power Advance Law function
            AdvancePandR = PowerAdvancePandR(advTable, p, r)
        Else ' use AMOEBA fit
            AdvancePandR = AmoebaAdvancePandR(advTable, p, r)
        End If

    End Function
    '
    ' Calculate Advance curve's Power-Law parameters (p & r) using input Advance Table
    '
    Public Function PowerAdvancePandR(ByVal advTable As DataTable, ByRef p As Double, ByRef r As Double) As Boolean
        PowerAdvancePandR = False

        Try
            If (advTable IsNot Nothing) Then
                Dim rowCount As Integer = advTable.Rows.Count
                If (2 < rowCount) Then ' 2 or more points

                    Dim dists As ArrayList = New ArrayList
                    Dim times As ArrayList = New ArrayList

                    Dim advRow As DataRow = Nothing
                    Dim dist, time As Double

                    For rdx As Integer = 0 To rowCount - 1
                        advRow = advTable.Rows(rdx)

                        dist = advRow.Item(nDistanceX)
                        time = advRow.Item(nTimeX1)

                        If (0.0 < dist) Then
                            dists.Add(dist)
                            times.Add(time)
                        End If
                    Next rdx

                    PowerFit(times, dists, p, r)

                    If Not (Double.IsNaN(p) Or Double.IsNaN(r)) Then
                        PowerAdvancePandR = True
                    End If
                ElseIf (1 < rowCount) Then ' 1 point
                    Dim advRow As DataRow = advTable.Rows(1)
                    Dim dist As Double = advRow.Item(nDistanceX)
                    Dim time As Double = advRow.Item(nTimeX1)
                    r = 0.75
                    p = dist / time ^ r
                    PowerAdvancePandR = True
                End If
            End If

        Catch ex As Exception
            p = Double.NaN
            r = Double.NaN
        End Try

    End Function
    '
    ' Calculate input Advance curve's Power-Law parameters (p & r) using AMOEBA fit
    '
    Public Function AmoebaAdvancePandR(ByVal advTable As DataTable, ByRef p As Double, ByRef r As Double) As Boolean
        AmoebaAdvancePandR = False

        If (advTable IsNot Nothing) Then
            Dim advCurve As Double(,) = GetDoubleArray(advTable, 0, 1)
            Dim lastCdx As Integer = advCurve.GetUpperBound(1)
            If (0 <= lastCdx) Then ' at least one row
                Dim XL As Double = advCurve(0, lastCdx)
                Dim TL As Double = advCurve(1, lastCdx)

                ' Initial 'guesses' for advance p & r
                Dim pArr(,) As Double = New Double(1, 3) {{0.6, 0.7, 0.8, 0.9}, {0, 0, 0, 0}}
                For cdx As Integer = 0 To pArr.GetUpperBound(1)
                    pArr(1, cdx) = XL / TL ^ pArr(0, cdx) ' p = x / t^r
                Next cdx

                Dim amoeba As Srfr.AmoebePowerAdvanceLawFit = New Srfr.AmoebePowerAdvanceLawFit

                amoeba.p = pArr
                amoeba.AdvanceCurve = advCurve

                If (amoeba.AmoebaFit(0.001, 1000)) Then
                    p = pArr(1, 3)
                    r = pArr(0, 3)
                    AmoebaAdvancePandR = True
                End If
            End If
        End If

    End Function

    Public Function SumOfSquares(ByVal Table1 As DataTable, ByVal Table2 As DataTable,
                                 ByVal xCol As Integer, ByVal yCol As Integer) As Double
        SumOfSquares = 0.0

        Try
            For Each T1row As DataRow In Table1.Rows
                Dim X1 As Double = CDbl(T1row.Item(xCol))
                Dim Y1 As Double = CDbl(T1row.Item(yCol))
                Dim Y2 As Double = DataColumnValue(Table2, xCol, X1, yCol)

                SumOfSquares += (Y1 - Y2) ^ 2
            Next T1row

        Catch ex As Exception
            Debug.Assert(False)
            SumOfSquares = Double.NaN
        End Try
    End Function

    '*********************************************************************************************************
    ' Function TriangularInterpolation()    - calculate interpolation weights within enclosing triangle
    '
    ' Input(s):     V1      - location of point 1 values                    V1
    '               V2      -     "     "   "   2    "                     /  \
    '               V3      -     "     "   "   3    "                    /  P \
    '               P       -     "     " new point                     V2 ---- V3
    '
    ' Output(s)     W1      - weight for V1 values
    '               W2      -    "    "  V2    "
    '               W3      -    "    "  V3    "
    '
    ' Returns:      Boolean - true if P within triangle; false otherwise
    '
    ' Note  - based on Barymetric Coordinates
    '
    ' See   - codeplea.com/triangular interpolation
    '*********************************************************************************************************
    Public Function TriangularInterpolation(ByVal V1 As PointF, ByVal V2 As PointF, ByVal V3 As PointF, ByVal P As PointF,
                                            ByRef W1 As Single, ByRef W2 As Single, ByRef W3 As Single) As Boolean
        Dim InTriangle As Boolean = True

        ' Equation numerators
        Dim W1num As Single = (V2.Y - V3.Y) * (P.X - V3.X) + (V3.X - V2.X) * (P.Y - V3.Y)
        Dim W2num As Single = (V3.Y - V1.Y) * (P.X - V3.X) + (V1.X - V3.X) * (P.Y - V3.Y)

        ' Equation denominators
        Dim den As Single = (V2.Y - V3.Y) * (V1.X - V3.X) + (V3.X - V2.X) * (V1.Y - V3.Y)

        ' Weights
        W1 = W1num / den
        W2 = W2num / den
        W3 = 1 - W1 - W2

        ' Check if P is within enclosing triangle (any negative W means outside)
        If (W1 < 0 Or W2 < 0 Or W3 < 0) Then
            InTriangle = False
        End If

        Return InTriangle
    End Function

#End Region

#Region " Excel Functions "
    '
    ' For an explanation of these functions, refer to Excel's Help
    '
    Public Function PEARSON(ByVal Array_x As ArrayList, ByVal Array_y As ArrayList) As Double
        Dim _PEARSON As Double = Double.NaN

        If Not (Array_x Is Nothing) Then
            If Not (Array_y Is Nothing) Then

                Dim _numArray_x As Integer = Array_x.Count
                Dim _numArray_y As Integer = Array_y.Count

                ' Verify contents of Array_x
                If (0 < _numArray_x) Then
                    Dim _obj As Object = Array_x(0)
                    If (Not (_obj.GetType Is GetType(Double)) _
                    And Not (_obj.GetType Is GetType(String))) Then
                        Return _PEARSON
                    End If
                Else
                    Return _PEARSON
                End If

                ' Verify contents of Array_y
                If (0 < _numArray_y) Then
                    Dim _obj As Object = Array_y(0)
                    If (Not (_obj.GetType Is GetType(Double)) _
                    And Not (_obj.GetType Is GetType(String))) Then
                        Return _PEARSON
                    End If
                Else
                    Return _PEARSON
                End If

                ' Calculate Pearson r
                Dim _n As Integer = Math.Min(_numArray_x, _numArray_y)

                Dim _sumX As Double = 0.0   ' Sum of X
                Dim _sumY As Double = 0.0   ' Sum of Y
                Dim _sumX2 As Double = 0.0  ' Sum of (X^2)
                Dim _sumY2 As Double = 0.0  ' Sum of (Y^2)
                Dim _sumXY As Double = 0.0  ' Sum of X*Y

                For _idx As Integer = 0 To _n - 1
                    If ((Array_x(_idx).GetType Is GetType(Double)) _
                    And (Array_y(_idx).GetType Is GetType(Double))) Then
                        Dim _x As Double = CDbl(Array_x(_idx))
                        Dim _y As Double = CDbl(Array_y(_idx))

                        _sumX += _x
                        _sumY += _y
                        _sumX2 += _x ^ 2
                        _sumY2 += _y ^ 2
                        _sumXY += _x * _y
                    End If
                Next

                Dim _term1 As Double = _n * _sumXY
                Dim _term2 As Double = _sumX * _sumY
                Dim _term3 As Double = (_n * _sumX2) - (_sumX ^ 2)
                Dim _term4 As Double = (_n * _sumY2) - (_sumY ^ 2)

                _PEARSON = (_term1 - _term2) / Math.Sqrt(_term3 * _term4)
            Else
                Debug.Assert(False, "Array_y is Nothing")
            End If
        Else
            Debug.Assert(False, "Array_x is Nothing")
        End If

        Return _PEARSON
    End Function

    Public Function RSQ(ByVal Array_x As ArrayList, ByVal Array_y As ArrayList) As Double
        Dim _PEARSON As Double = PEARSON(Array_x, Array_y)
        Dim _RSQ As Double = _PEARSON ^ 2
        Return _RSQ
    End Function

    Public Function AVERAGE(ByVal Array_x As ArrayList) As Double
        Dim _AVERAGE As Double = Double.NaN

        If Not (Array_x Is Nothing) Then

            Dim _numArray_x As Integer = Array_x.Count

            ' Verify contents of Array_x
            If (0 < _numArray_x) Then
                Dim _obj As Object = Array_x(0)
                If (Not (_obj.GetType Is GetType(Double)) _
                And Not (_obj.GetType Is GetType(String))) Then
                    Return _AVERAGE
                End If
            Else
                Return _AVERAGE
            End If

            ' Calculate Average
            Dim _n As Integer = _numArray_x
            Dim _sumX As Double = 0.0   ' Sum of X

            For _idx As Integer = 0 To _n - 1
                If (Array_x(_idx).GetType Is GetType(Double)) Then
                    Dim _x As Double = CDbl(Array_x(_idx))
                    _sumX += _x
                End If
            Next

            _AVERAGE = _sumX / _n
        Else
            Debug.Assert(False, "Array_x is Nothing")
        End If

        Return _AVERAGE
    End Function

    Public Function DEVSQ(ByVal Array_x As ArrayList) As Double
        Dim _DEVSQ As Double = Double.NaN

        If Not (Array_x Is Nothing) Then

            Dim _numArray_x As Integer = Array_x.Count

            ' Verify contents of Array_x
            If (0 < _numArray_x) Then
                Dim _obj As Object = Array_x(0)
                If (Not (_obj.GetType Is GetType(Double)) _
                And Not (_obj.GetType Is GetType(String))) Then
                    Return _DEVSQ
                End If
            Else
                Return _DEVSQ
            End If

            ' Calculate Deviation^2
            Dim _average As Double = AVERAGE(Array_x)
            Dim _n As Integer = _numArray_x
            _DEVSQ = 0.0

            For _idx As Integer = 0 To _n - 1
                If (Array_x(_idx).GetType Is GetType(Double)) Then
                    Dim _x As Double = CDbl(Array_x(_idx))
                    Dim _diff As Double = _x - _average
                    Dim _sqr As Double = _diff ^ 2.0
                    _DEVSQ += _sqr
                End If
            Next

        Else
            Debug.Assert(False, "Array_x is Nothing")
        End If

        Return _DEVSQ
    End Function

    Public Function MSE(ByVal Array_x As ArrayList, ByVal Array_y As ArrayList) As Double
        MSE = Double.NaN

        Dim sum_xmy2 As Double = SUMXMY2(Array_x, Array_y)
        If (Not Double.IsNaN(sum_xmy2)) Then
            Dim N As Integer = Array_x.Count
            MSE = sum_xmy2 / N
        End If
    End Function

    Public Function PE(ByVal Array_x As ArrayList, ByVal Array_y As ArrayList) As Double
        PE = Double.NaN

        If (Array_x IsNot Nothing) Then
            If (Array_y IsNot Nothing) Then

                Dim _numArray_x As Integer = Array_x.Count
                Dim _numArray_y As Integer = Array_y.Count

                ' Verify contents of Array_x
                If (0 < _numArray_x) Then
                    Dim _obj As Object = Array_x(0)
                    If ((_obj.GetType IsNot GetType(Double)) _
                    And (_obj.GetType IsNot GetType(String))) Then
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                ' Verify contents of Array_y
                If (0 < _numArray_y) Then
                    Dim _obj As Object = Array_y(0)
                    If ((_obj.GetType IsNot GetType(Double)) _
                    And (_obj.GetType IsNot GetType(String))) Then
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                ' Average of X array
                Dim _average As Double = AVERAGE(Array_x)
                Dim _n As Integer = Math.Min(_numArray_x, _numArray_y)

                ' Calculate Sum((|X-Avg|+|Y-Avg|)^2)
                PE = 0.0

                For _idx As Integer = 0 To _n - 1
                    If ((Array_x(_idx).GetType Is GetType(Double)) _
                    And (Array_y(_idx).GetType Is GetType(Double))) Then
                        Dim _x As Double = CDbl(Array_x(_idx))
                        Dim _y As Double = CDbl(Array_y(_idx))

                        Dim _Xdiff As Double = Math.Abs(_x - _average)
                        Dim _Ydiff As Double = Math.Abs(_y - _average)

                        Dim _sqr As Double = (_Xdiff + _Ydiff) ^ 2.0
                        PE += _sqr
                    End If
                Next
            Else
                Debug.Assert(False, "Array_y is Nothing")
            End If
        Else
            Debug.Assert(False, "Array_x is Nothing")
        End If

    End Function

    Public Function SUMXMY2(ByVal Array_x As ArrayList, ByVal Array_y As ArrayList) As Double
        SUMXMY2 = Double.NaN

        If (Array_x IsNot Nothing) Then
            If (Array_y IsNot Nothing) Then

                Dim _numArray_x As Integer = Array_x.Count
                Dim _numArray_y As Integer = Array_y.Count

                ' Verify contents of Array_x
                If (0 < _numArray_x) Then
                    Dim _obj As Object = Array_x(0)
                    If ((_obj.GetType IsNot GetType(Double)) _
                    And (_obj.GetType IsNot GetType(String))) Then
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                ' Verify contents of Array_y
                If (0 < _numArray_y) Then
                    Dim _obj As Object = Array_y(0)
                    If ((_obj.GetType IsNot GetType(Double)) _
                    And (_obj.GetType IsNot GetType(String))) Then
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                ' Calculate Sum((X-Y)^2)
                Dim _n As Integer = Math.Min(_numArray_x, _numArray_y)
                SUMXMY2 = 0.0

                For _idx As Integer = 0 To _n - 1
                    If ((Array_x(_idx).GetType Is GetType(Double)) _
                    And (Array_y(_idx).GetType Is GetType(Double))) Then
                        Dim _x As Double = CDbl(Array_x(_idx))
                        Dim _y As Double = CDbl(Array_y(_idx))

                        Dim _diff As Double = (_x - _y)
                        Dim _sqr As Double = _diff ^ 2.0
                        SUMXMY2 += _sqr
                    End If
                Next
            Else
                Debug.Assert(False, "Array_y is Nothing")
            End If
        Else
            Debug.Assert(False, "Array_x is Nothing")
        End If

    End Function

    Public Function PBIAS(ByVal Array_x As ArrayList, ByVal Array_y As ArrayList) As Double
        PBIAS = Double.NaN

        If (Array_x IsNot Nothing) Then
            If (Array_y IsNot Nothing) Then

                Dim _numArray_x As Integer = Array_x.Count
                Dim _numArray_y As Integer = Array_y.Count

                ' Verify contents of Array_x
                If (0 < _numArray_x) Then
                    Dim _obj As Object = Array_x(0)
                    If ((_obj.GetType IsNot GetType(Double)) _
                    And (_obj.GetType IsNot GetType(String))) Then
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                ' Verify contents of Array_y
                If (0 < _numArray_y) Then
                    Dim _obj As Object = Array_y(0)
                    If ((_obj.GetType IsNot GetType(Double)) _
                    And (_obj.GetType IsNot GetType(String))) Then
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                ' Calculate Sum((X-Y)*100) & Sum(X)
                Dim _n As Integer = Math.Min(_numArray_x, _numArray_y)
                PBIAS = 0.0
                Dim _num As Double = 0.0    ' numerator
                Dim _den As Double = 0.0    ' denominator

                For _idx As Integer = 0 To _n - 1
                    If ((Array_x(_idx).GetType Is GetType(Double)) _
                    And (Array_y(_idx).GetType Is GetType(Double))) Then
                        Dim _x As Double = CDbl(Array_x(_idx))
                        Dim _y As Double = CDbl(Array_y(_idx))

                        _num += (_x - _y) * 100.0   ' numerator
                        _den += _x                  ' denominator
                    End If
                Next _idx

                PBIAS = _num / _den
            Else
                Debug.Assert(False, "Array_y is Nothing")
            End If
        Else
            Debug.Assert(False, "Array_x is Nothing")
        End If

    End Function

    Public Function RMSE(ByVal Array_x As ArrayList, ByVal Array_y As ArrayList) As Double
        RMSE = Double.NaN

        If (Array_x IsNot Nothing) Then
            If (Array_y IsNot Nothing) Then

                Dim _numArray_x As Integer = Array_x.Count
                Dim _numArray_y As Integer = Array_y.Count

                ' Verify contents of Array_x
                If (0 < _numArray_x) Then
                    Dim _obj As Object = Array_x(0)
                    If ((_obj.GetType IsNot GetType(Double)) _
                    And (_obj.GetType IsNot GetType(String))) Then
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                ' Verify contents of Array_y
                If (0 < _numArray_y) Then
                    Dim _obj As Object = Array_y(0)
                    If ((_obj.GetType IsNot GetType(Double)) _
                    And (_obj.GetType IsNot GetType(String))) Then
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                ' Calculate Sum((X-Y)^2)
                Dim _n As Integer = Math.Min(_numArray_x, _numArray_y)
                RMSE = 0.0

                For _idx As Integer = 0 To _n - 1
                    If ((Array_x(_idx).GetType Is GetType(Double)) _
                    And (Array_y(_idx).GetType Is GetType(Double))) Then
                        Dim _x As Double = CDbl(Array_x(_idx))
                        Dim _y As Double = CDbl(Array_y(_idx))

                        Dim _diff As Double = (_x - _y)
                        Dim _sqr As Double = _diff ^ 2.0
                        RMSE += _sqr
                    End If
                Next _idx

                RMSE = Math.Sqrt(RMSE)
            Else
                Debug.Assert(False, "Array_y is Nothing")
            End If
        Else
            Debug.Assert(False, "Array_x is Nothing")
        End If

    End Function

    Public Function STDEV(ByVal Array_x As ArrayList) As Double
        STDEV = Double.NaN

        If (Array_x IsNot Nothing) Then

            Dim _numArray_x As Integer = Array_x.Count

            ' Verify contents of Array_x
            If (0 < _numArray_x) Then
                Dim _obj As Object = Array_x(0)
                If ((_obj.GetType IsNot GetType(Double)) _
                And (_obj.GetType IsNot GetType(String))) Then
                    Exit Function
                End If
            Else
                Exit Function
            End If

            ' Average of X array
            Dim _average As Double = AVERAGE(Array_x)

            ' Calculate Sum((X-Avg)^2)
            Dim _n As Integer = _numArray_x
            STDEV = 0.0

            For _idx As Integer = 0 To _n - 1
                If (Array_x(_idx).GetType Is GetType(Double)) Then
                    Dim _x As Double = CDbl(Array_x(_idx))

                    Dim _diff As Double = (_x - _average)
                    Dim _sqr As Double = _diff ^ 2.0
                    STDEV += _sqr
                End If
            Next _idx

            STDEV = Math.Sqrt(STDEV)
        Else
            Debug.Assert(False, "Array_x is Nothing")
        End If

    End Function

#End Region

#Region " Miscellaneous "
    '
    ' Swap values such that (_value1 <=> _value2)
    '
    Public Sub Swap(ByRef _value1 As Integer, ByRef _value2 As Integer)
        Dim _temp As Integer = _value1
        _value1 = _value2
        _value2 = _temp
    End Sub

    Public Sub Swap(ByRef _value1 As Single, ByRef _value2 As Single)
        Dim _temp As Single = _value1
        _value1 = _value2
        _value2 = _temp
    End Sub

    Public Sub Swap(ByRef _value1 As Double, ByRef _value2 As Double)
        Dim _temp As Double = _value1
        _value1 = _value2
        _value2 = _temp
    End Sub
    '
    ' Order values such that (_value1 <= _value2)
    '
    Public Sub Order(ByRef _value1 As Integer, ByRef _value2 As Integer)
        If (_value2 < _value1) Then
            Swap(_value1, _value2)
        End If
    End Sub

    Public Sub Order(ByRef _value1 As Single, ByRef _value2 As Single)
        If (_value2 < _value1) Then
            Swap(_value1, _value2)
        End If
    End Sub

    Public Sub Order(ByRef _value1 As Double, ByRef _value2 As Double)
        If (_value2 < _value1) Then
            Swap(_value1, _value2)
        End If
    End Sub
    '
    ' Count the number of lines in a String
    '
    Public Function LineCount(ByVal _str As String) As Integer
        Dim _lines As Integer = 0

        For _idx As Integer = 0 To _str.Length - 1
            Dim _chr As Char = _str.Chars(_idx)
            If (_chr = ChrW(13)) Then
                _lines = _lines + 1
            End If
        Next _idx

        If (_lines = 0) Then
            _lines = 1
        End If

        Return _lines

    End Function
    '
    ' Compare two numbers for being 'This Close'
    '
    Public Function ThisClose(ByVal _int1 As Integer, _
                              ByVal _int2 As Integer, _
                              ByVal _tolerance As Integer) As Boolean

        If (_int1 < _int2 - _tolerance) Then
            Return False
        ElseIf (_int2 + _tolerance < _int1) Then
            Return False
        End If

        Return True
    End Function

    Public Function ThisClose(ByVal _dbl1 As Single, _
                              ByVal _dbl2 As Single, _
                              ByVal _tolerance As Single) As Boolean

        If (_dbl1 < _dbl2 - _tolerance) Then
            Return False
        ElseIf (_dbl2 + _tolerance < _dbl1) Then
            Return False
        End If

        Return True
    End Function

    Public Function ThisClose(ByVal _dbl1 As Double, _
                              ByVal _dbl2 As Double, _
                              ByVal _tolerance As Double) As Boolean

        If (_dbl1 < _dbl2 - _tolerance) Then
            Return False
        ElseIf (_dbl2 + _tolerance < _dbl1) Then
            Return False
        End If

        Return True
    End Function

    Public Function IsElementOf(ByVal _text As String, ByVal _array() As String) As Integer
        If Not (_array Is Nothing) Then
            If (0 < _array.Length) Then
                For _idx As Integer = 0 To _array.Length - 1
                    If (0 = String.Compare(_array(_idx), _text)) Then
                        Return _idx
                    End If
                Next
            End If
        End If

        Return -1
    End Function

    Public Function LeftJustifyFill(ByVal _text As String, ByVal _len As Integer, _
                                    Optional ByVal _pre As String = "", Optional ByVal _post As String = "") As String
        _text = _pre & _text & _post
        If (_text.Length < _len) Then
            _text = _text.PadRight(_len, " "c)
        End If
        _text = _text.Substring(0, _len)
        Return _text
    End Function

    Public Function RightJustifyFill(ByVal _text As String, ByVal _len As Integer, _
                                     Optional ByVal _pre As String = "", Optional ByVal _post As String = "") As String
        _text = _pre & _text & _post
        If (_text.Length < _len) Then
            _text = _text.PadLeft(_len, " "c)
        End If
        _text = _text.Substring(0, _len)
        Return _text
    End Function

    '*********************************************************************************************************
    ' General Double array functions
    '
    ' Function ArrayListToDouble()          - convert ArrayList to Double()
    ' Function LimitArrayValues()           - remove all array value larger than limit value
    ' Function RemoveDuplicateArrayValues() - remove duplicate array values
    ' Function RemoveNegativeArrayValues()  - remove negative (<0.0) array values
    ' Function RemoveSpecificArrayValues()  - remove specific array value
    ' Function ArrayContainsValue()         - check if array contain a specific value
    '
    ' Input(s):     ArrList                 - ArrayList of doubles
    '               DblArray                - array of Double values
    '               DblLimit                - limiting value for array members
    '               DblValue                - specific value
    '*********************************************************************************************************
    Public Function ArrayListToDouble(ByVal ArrList As ArrayList) As Double()
        Dim dblArray As Double() = {}

        Try
            ReDim dblArray(ArrList.Count - 1)
            For idx As Integer = 0 To ArrList.Count - 1
                dblArray(idx) = CDbl(ArrList(idx))
            Next idx

        Catch ex As Exception
        End Try

        Return dblArray
    End Function

    Public Function LimitArrayValues(ByVal DblArray As Double(), ByVal DblLimit As Double) As Double()
        Dim limited As Double() = {}

        ' Remove all values greater than the limit
        For Each dbl As Double In DblArray
            If (dbl <= DblLimit) Then
                ReDim Preserve limited(limited.Length)
                limited(limited.Length - 1) = dbl
            End If
        Next dbl

        Return limited
    End Function

    Public Function RemoveDuplicateArrayValues(ByVal DblArray As Double()) As Double()
        Dim removed As Double() = {}

        ' Remove all duplicate values
        If (0 < DblArray.Length) Then
            Dim dbl1 As Double = DblArray(0)
            ReDim Preserve removed(removed.Length)
            removed(removed.Length - 1) = dbl1
            If (1 < DblArray.Length) Then
                For idx As Integer = 1 To DblArray.Length - 1
                    Dim dbl2 As Double = DblArray(idx)
                    If Not (dbl1 = dbl2) Then
                        ReDim Preserve removed(removed.Length)
                        removed(removed.Length - 1) = dbl2
                    End If
                    dbl1 = dbl2
                Next idx
            End If
        End If

        Return removed
    End Function

    Public Function RemoveNegativeArrayValues(ByVal DblArray As Double()) As Double()
        Dim removed As Double() = {}

        ' Remove all negative values (i.e. keep zero & positive value)
        For Each dbl As Double In DblArray
            If (0.0 <= dbl) Then
                ReDim Preserve removed(removed.Length)
                removed(removed.Length - 1) = dbl
            End If
        Next dbl

        Return removed
    End Function

    Public Function RemoveSpecificArrayValues(ByVal DblArray As Double(), ByVal DblValue As Double) As Double()
        Dim removed As Double() = {}

        ' Remove all values equal to input value
        For Each dbl As Double In DblArray
            If Not (dbl = DblValue) Then
                ReDim Preserve removed(removed.Length)
                removed(removed.Length - 1) = dbl
            End If
        Next dbl

        Return removed
    End Function

    Public Function ArrayContainsValue(ByVal DblArray As Double(), ByVal DblValue As Double) As Boolean
        ArrayContainsValue = False

        ' Compare array values against input value
        For Each dbl As Double In DblArray
            If (dbl = DblValue) Then
                ArrayContainsValue = True
                Exit For
            End If
        Next dbl

    End Function

    Public Function FloorValue(ByVal DblArray As Double(), ByVal DblValue As Double) As Double
        For idx As Integer = DblArray.Length - 1 To 0 Step -1
            FloorValue = DblArray(idx)
            If (FloorValue <= DblValue) Then
                Exit For
            End If
        Next idx
    End Function

    Public Function CeilingValue(ByVal DblArray As Double(), ByVal DblValue As Double) As Double
        For idx As Integer = 0 To DblArray.Length - 1
            CeilingValue = DblArray(idx)
            If (DblValue <= CeilingValue) Then
                Exit For
            End If
        Next idx
    End Function

    '*********************************************************************************************************
    ' Function RandomString() - return a randomly generated string
    '*********************************************************************************************************
    Public Function RandomString() As String
        RandomString = Path.GetRandomFileName()
        RandomString = RandomString.Replace(".", "")
    End Function

    '*********************************************************************************************************
    ' Sub DisposeImages() - recursively traverses Controls looking for ExPictureBoxes so their Images can
    '                       be properly Disposed
    '*********************************************************************************************************
    Public Sub DisposeImages(ByVal Ctrl As Control)
        If (Ctrl IsNot Nothing) Then
            ' Look for ex_pictureBox or derived class
            If ((Ctrl.GetType Is GetType(ex_PictureBox)) _
             Or (Ctrl.GetType.IsSubclassOf(GetType(ex_PictureBox)))) Then

                ' Properly Dispose of Image
                Dim exPictureBox As ex_PictureBox = DirectCast(Ctrl, ex_PictureBox)
                If (exPictureBox.Image IsNot Nothing) Then
                    exPictureBox.Image.Dispose()
                    exPictureBox.Image = Nothing
                End If
            Else
                ' Traverse backwards through all contained controls
                For cdx As Integer = Ctrl.Controls.Count - 1 To 0 Step -1
                    Try
                        ' Get Control at the end of the list
                        Dim eCtrl As Control = Ctrl.Controls(cdx)
                        If (eCtrl IsNot Nothing) Then
                            ' First, clear its resources
                            DisposeImages(eCtrl)
                        End If
                    Catch ex As Exception
                    End Try
                Next cdx
            End If
        End If
    End Sub

#End Region

#Region " Infiltrated Volume "

    Public Function IncompleteBeta(ByVal N As Integer, ByVal A As Double, ByVal B As Double, ByVal Xu As Double) As Double
        Dim J As Integer, I As Integer
        Dim SumIB As Double, PiIB As Double, IR As Double, JR As Double
        'Approximation to the Incomplete Beta Function
        'See Strelkoff et al 2005, eq. (68)

        SumIB = 1
        For I = 1 To N
            IR = CDbl(I)
            PiIB = 1
            For J = 0 To I - 1
                JR = CDbl(J)
                PiIB = PiIB * (A - JR) / (IR - JR)
            Next J
            SumIB = SumIB + (-Xu) ^ IR * (B / (B + IR)) * PiIB
        Next I
        IncompleteBeta = SumIB
    End Function

    Public Function ExtKostPwrAdvIntegral(ByVal T As Double, ByVal Xadv As Double, ByVal TL As Double, _
                                          ByVal rpa As Double, ByVal K As Double, ByVal a As Double, _
                                          ByVal B As Double, ByVal C As Double) As Double
        Dim SigZ1 As Double, SigZ2 As Double
        'This function uses power-law advance relationships to solve for the total infiltrated volume
        'at time T for a field section of length X and with infiltration given by the Extended
        'Kostiakov equation.

        'Inputs:
        'T    : Time
        'Xadv : Advance distance at time T (= L if water has reached the end of the field)
        'TL   : Advance time to the end of the field (L)
        'rpa  : exponent of the power advance relationship x= ppa*t^rpa
        'K, a, B, C : Extended Kostiakov infiltration parameters

        'All inputs have SI units except rpa and ainf, which are dimensionless

        'References:
        'Christiansen, J.E., Bishop, A.A., Kiefer, F.W., Jr., and Fok, Y.S. 1966.
        'Evaluation of Intake Rate Constants as Related to Advance of Water in Surface Irrigation.
        'Transactions of the ASAE, 9(5):671-674
        'Scaloppi, E.J., Merkeley, G.P., and Willardson, L.S.   1995.
        'Intake parameters from advance and wetting phases of surface irrigation,
        'Journal of Irrigation and Drainage Engineering, ASCE, 121(1):57-70

        'See also Eqs. (35)-(37) and Appendix I from Strelkoff et al. 2005

        'Function parameters
        'SigZ1, SigZ2 :     infiltration shape factors


        If T <= TL Then
            'Advance integral: shape factors given by Kiefer binomial series approximation to beta function
            SigZ1 = (1 + a + rpa * (1 - a)) / (1 + a + rpa * (1 + a))
            SigZ2 = 1 / (1 + rpa)

        Else
            'Integral during storage phase, prior to cutoff
            'Integral for power term is given by incomplete beta function
            'The IncompleteBeta function is a binomial expansion approximation; the first parameter
            'is the number of terms used in the approximation - can be modified by user
            SigZ1 = IncompleteBeta(10, a, rpa, TL / T)
            SigZ2 = 1 - rpa * (TL / T) / (1 + rpa)
        End If

        ExtKostPwrAdvIntegral = (SigZ1 * K * T ^ a + SigZ2 * B * T + C) * Xadv
    End Function

#End Region

End Module
