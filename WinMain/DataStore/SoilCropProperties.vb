
'*************************************************************************************************************
' Class:    SoilCropProperties
'
' Desc: SoilCropProperties provides the Model (data store & logic) for the soil and crop:
'           1) infiltration properties
'           2) surface roughness properties
'
' Infiltration calculations are performed by the appropriate Infiltration object with the SRFR DLL.
'
' SoilCropProperties is the main conduit for infiltration calculations for WinSRFR; WinSRFR objects make
' calls to SoilCropProperties functions which in turn call appropriate SRFR DLL Infiltration functions.
'*************************************************************************************************************
Imports System.Collections.Generic

Imports DataStore

Public Class SoilCropProperties

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Soil Crop Properties"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Parent Unit & associated sub-units
    '
    Private mUnit As Unit
    Public ReadOnly Property Unit() As Unit
        Get
            Return mUnit
        End Get
    End Property

    Private mWinSRFR As WinSRFR
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

#Region " Constants "

    Private Const Depth7mm As Double = OneMillimeter * 7.0
    Private Const Depth100mm As Double = OneMillimeter * 100.0

#End Region

#Region " Properties "

    '*********************************************************************************************************
    ' Property SrfrInfiltration() - alternate source of parameters for infiltration calculations
    '
    ' Unless otherwise specified, Infiltration calculations use the infiltration parameters found in
    ' SoilCropProperties.  There are times, however, when an alternate set of infiltration parameters
    ' needs to be used.  A SRFR Infiltration object can be instantiated and loaded with the desired
    ' alternate parameters then that object can be used as the alternate parameter source.
    '
    ' If SrfrInfiltration is set, be sure to clear it when finished.  SoilCropProperties will continue to
    ' use it until otherwise instructed!
    '*********************************************************************************************************
    Public Property SrfrInfiltration() As Srfr.Infiltration = Nothing

    ' Instantiate a SRFR Infiltration object based on the infiltration parameters in SoilCropProperties
    Public Sub SetSrfrInfiltration()
        SrfrInfiltration = SrfrAPI.SrfrInfiltration(Me)
    End Sub

    ' Clear the previously set SRFR Infiltration object
    Public Sub ClrSrfrInfiltration()
        SrfrInfiltration = Nothing
    End Sub

#End Region

#Region " Serialized Properties "

#Region " Soil Properties "

#Region " Soil Water Depletion "

    Public Const sSoilWaterDepletion As String = "Soil Water Depletion"

    Public ReadOnly Property SoilWaterDepletionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSoilWaterDepletion)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _soilWaterDepletion As DataTable = New DataTable(sSoilWaterDepletion)

                ResetSoilWaterDepletion(_soilWaterDepletion)

                Dim _parameter As DataTableParameter = New DataTableParameter(_soilWaterDepletion)
                mMyStore.AddProperty(sSoilWaterDepletion, _parameter)
                _propertyNode = mMyStore.GetProperty(sSoilWaterDepletion)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SoilWaterDepletion() As DataTableParameter
        Get
            Return SoilWaterDepletionProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            SoilWaterDepletionProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetSoilWaterDepletion(ByVal _soilWaterDepletion As DataTable)

        ' Remove the previous data
        _soilWaterDepletion.Columns.Clear()
        _soilWaterDepletion.Rows.Clear()

        ' Add the columns
        _soilWaterDepletion.Columns.Add(sProfileDepthX, GetType(Double))
        _soilWaterDepletion.Columns.Add(sCumulativeDepthX, GetType(Double))
        _soilWaterDepletion.Columns.Add(sTextureX, GetType(String))
        _soilWaterDepletion.Columns.Add(sAwcX, GetType(Double))
        _soilWaterDepletion.Columns.Add(sSwdX, GetType(Double))
        _soilWaterDepletion.Columns.Add(sProfileSwdX, GetType(Double))
        _soilWaterDepletion.Columns.Add(sCumulativeSwdX, GetType(Double))

        ' Add the rows of reset data
        Dim _soilRow As DataRow

        _soilRow = _soilWaterDepletion.NewRow
        _soilRow.Item(sProfileDepthX) = 1.0
        _soilRow.Item(sCumulativeDepthX) = 1.0
        _soilRow.Item(sTextureX) = "SiL"
        _soilRow.Item(sAwcX) = 0.1
        _soilRow.Item(sSwdX) = 0.5
        _soilRow.Item(sProfileSwdX) = 0.05
        _soilRow.Item(sCumulativeSwdX) = 0.05
        _soilWaterDepletion.Rows.Add(_soilRow)

    End Sub
    '
    ' Probe Length
    '
    Public Const sProbeLength As String = "Probe Length"

    Public ReadOnly Property ProbeLengthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sProbeLength)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultProbeLength, Units.Meters)
                mMyStore.AddProperty(sProbeLength, _double)
                _propertyNode = mMyStore.GetProperty(sProbeLength)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ProbeLength() As DoubleParameter
        Get
            Return ProbeLengthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ProbeLengthProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Root Zone Depth
    '
    Public Const sRootZoneDepth As String = "Root Zone Depth"

    Public ReadOnly Property RootZoneDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRootZoneDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultRootZoneDepth, Units.Meters)
                mMyStore.AddProperty(sRootZoneDepth, _double)
                _propertyNode = mMyStore.GetProperty(sRootZoneDepth)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property RootZoneDepth() As DoubleParameter
        Get
            Return RootZoneDepthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            RootZoneDepthProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Leaching Fraction
    '
    Public Const sLeachingFraction As String = "Leaching Fraction"

    Public ReadOnly Property LeachingFractionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sLeachingFraction)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultLeachingFraction, Units.Percentage)
                mMyStore.AddProperty(sLeachingFraction, _double)
                _propertyNode = mMyStore.GetProperty(sLeachingFraction)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property LeachingFraction() As DoubleParameter
        Get
            Return LeachingFractionProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            LeachingFractionProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Infiltration "
    '
    ' Infiltration Table
    '
    Private Const sInfiltration As String = "Infiltration"

    Public ReadOnly Property InfiltrationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInfiltration)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sInfiltration, _parameter)
                _propertyNode = mMyStore.GetProperty(sInfiltration)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Infiltration() As DataTableParameter
        Get
            Dim _table As DataTableParameter = InfiltrationProperty.GetDataTableParameter()

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
            InfiltrationProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearInfiltration()
        mMyStore.DeleteProperty(sInfiltration)
    End Sub

#End Region

#Region " Infiltrated Depth "

    Public Const sInfiltratedDepth As String = "Infiltrated Depth"

    Public ReadOnly Property InfiltratedDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInfiltratedDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _infiltratedDepth As DataTable = New DataTable(sInfiltratedDepth)

                ResetInfiltratedDepth(_infiltratedDepth)

                Dim _parameter As DataTableParameter = New DataTableParameter(_infiltratedDepth)
                mMyStore.AddProperty(sInfiltratedDepth, _parameter)
                _propertyNode = mMyStore.GetProperty(sInfiltratedDepth)
            Else
                ' Make sure Infiltrated Depth table is up to date; columns added Feb. 6, 2006
                Dim _parameter As DataTableParameter = _propertyNode.GetDataTableParameter()
                If Not (_parameter.Value.Columns.Contains(sProfileIdX)) Then
                    UpdateInfiltratedDepth(_parameter)
                    _propertyNode.SetParameter(_parameter)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InfiltratedDepth() As DataTableParameter
        Get
            Return InfiltratedDepthProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            InfiltratedDepthProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetInfiltratedDepth(ByVal _infiltratedDepth As DataTable)

        ' Remove the previous data
        _infiltratedDepth.Columns.Clear()
        _infiltratedDepth.Rows.Clear()

        ' Add the columns
        _infiltratedDepth.Columns.Add(sDistanceX, GetType(Double))
        _infiltratedDepth.Columns.Add(sProbedDepthX, GetType(Double))
        _infiltratedDepth.Columns.Add(sProfileIdX, GetType(Double))
        _infiltratedDepth.Columns.Add(sRootZoneIdX, GetType(Double))
        _infiltratedDepth.Columns.Add(sUsefulIdX, GetType(Double))
        _infiltratedDepth.Columns.Add(sDeepPercIdX, GetType(Double))

        ' Add the rows of reset data
        Dim _distanceRow As DataRow
        Dim _start As Double = 0.0
        Dim _end As Double = mUnit.SystemGeometryRef.Length.Value

        ' Start of field
        _distanceRow = _infiltratedDepth.NewRow
        _distanceRow.Item(sDistanceX) = _start
        _distanceRow.Item(sProbedDepthX) = 1.0
        _distanceRow.Item(sProfileIdX) = 0.05
        _distanceRow.Item(sRootZoneIdX) = 0.05
        _distanceRow.Item(sUsefulIdX) = 0.05
        _distanceRow.Item(sDeepPercIdX) = 0.0
        _infiltratedDepth.Rows.Add(_distanceRow)

        ' End of field
        _distanceRow = _infiltratedDepth.NewRow
        _distanceRow.Item(sDistanceX) = _end
        _distanceRow.Item(sProbedDepthX) = 1.0
        _distanceRow.Item(sProfileIdX) = 0.05
        _distanceRow.Item(sRootZoneIdX) = 0.05
        _distanceRow.Item(sUsefulIdX) = 0.05
        _distanceRow.Item(sDeepPercIdX) = 0.0
        _infiltratedDepth.Rows.Add(_distanceRow)

    End Sub

    Public Sub UpdateInfiltratedDepth(ByVal _dataTableParameter As DataTableParameter)

        ' Get the current Infiltrated Depth table from the parameter
        Dim _oldTable As DataTable = _dataTableParameter.Value

        ' Feb. 6, 2006 update
        '   Files saved before this date need two columns added
        If Not (_oldTable.Columns.Contains(sProfileIdX)) Then

            Dim _updatedTable As DataTable = New DataTable(sInfiltratedDepth)

            ' Add the columns
            _updatedTable.Columns.Add(sDistanceX, GetType(Double))
            _updatedTable.Columns.Add(sProbedDepthX, GetType(Double))
            _updatedTable.Columns.Add(sProfileIdX, GetType(Double))
            _updatedTable.Columns.Add(sRootZoneIdX, GetType(Double))
            _updatedTable.Columns.Add(sUsefulIdX, GetType(Double))
            _updatedTable.Columns.Add(sDeepPercIdX, GetType(Double))

            ' Move the data from the old table to the udpated table; default new values
            Dim _updatedRow As DataRow
            For Each _oldRow As DataRow In _oldTable.Rows

                _updatedRow = _updatedTable.NewRow
                _updatedRow.Item(sDistanceX) = _oldRow.Item(sDistanceX)
                _updatedRow.Item(sProbedDepthX) = _oldRow.Item(sProbedDepthX)
                _updatedRow.Item(sRootZoneIdX) = _oldRow.Item(sRootZoneIdX)
                _updatedRow.Item(sUsefulIdX) = _oldRow.Item(sUsefulIdX)

                _updatedRow.Item(sProfileIdX) = 0.0
                _updatedRow.Item(sDeepPercIdX) = 0.0

                _updatedTable.Rows.Add(_updatedRow)
            Next

            ' Save the updated Infiltrated Depth table into the parameter
            _dataTableParameter.Value = _updatedTable

        End If

    End Sub

#End Region

#End Region

#Region " Infiltration Properties "

#Region " Infiltration Function "

    Public Const sInfiltrationMethod As String = "Infiltration Method"
    Public Const sInfiltrationFunction As String = "Infiltration Function"

    Public ReadOnly Property InfiltrationFunctionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInfiltrationFunction)

            ' If not found; try deprecated name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sInfiltrationMethod)

                ' If deprecated name was found; update it
                If (_propertyNode IsNot Nothing) Then
                    _propertyNode.MyID = sInfiltrationFunction
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultInfiltrationFunction)
                mMyStore.AddProperty(sInfiltrationFunction, _integer)
                _propertyNode = mMyStore.GetProperty(sInfiltrationFunction)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InfiltrationFunction() As IntegerParameter
        Get
            Dim _integerParam As IntegerParameter = InfiltrationFunctionProperty.GetIntegerParameter()
            Return _integerParam
        End Get
        Set(ByVal Value As IntegerParameter)
            InfiltrationFunctionProperty.SetParameter(Value)
        End Set
    End Property

    Private mInfiltrationFunctionIndex As Integer = -1
    Public Function GetFirstInfiltrationFunctionSelection(ByRef _sel As String) As Boolean
        mInfiltrationFunctionIndex = -1
        Return GetNextInfiltrationFunctionSelection(_sel)
    End Function

    Public Function GetNextInfiltrationFunctionSelection(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mInfiltrationFunctionIndex += 1
        If (mInfiltrationFunctionIndex < InfiltrationFunctions.HighLimit) Then
            _sel = InfiltrationFunctionSelections(mInfiltrationFunctionIndex).Value
            If ((InfiltrationFunctionSelections(mInfiltrationFunctionIndex).Flags And _flags) = 0) Then
                ' Selection is valid for World, User Level & Cross Section
                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function

#End Region

#Region " Surge 2+ Infiltration Method "

    Public Const sSurge2InfiltrationMethod As String = "Surge 2+ Infiltration Method"

    Public ReadOnly Property Surge2InfiltrationMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurge2InfiltrationMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultSurge2InfiltrationMethod)
                mMyStore.AddProperty(sSurge2InfiltrationMethod, _integer)
                _propertyNode = mMyStore.GetProperty(sSurge2InfiltrationMethod)
            Else
                ' Get the actual Parameter, not a copy of it; GetIntegerParameter() gets a copy
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _integerParam As IntegerParameter = DirectCast(_param, IntegerParameter)

                ' Izuno-Podmore Surge 2+ Infiltration Method is limited in scope
                If (_integerParam.Value = Surge2InfiltrationMethods.IzunoPodmore) Then

                    If (WinSRFR.UserLevel = UserLevels.Standard) Then
                        _integerParam.Value = Surge2InfiltrationMethods.BlairSmerdon
                    End If

                    If Not (mUnit.InflowManagementRef.InflowMethod.Value = InflowMethods.Surge) Then
                        _integerParam.Value = Surge2InfiltrationMethods.BlairSmerdon
                    End If

                    If (KostiakovB() <= 0.0) Then
                        _integerParam.Value = Surge2InfiltrationMethods.BlairSmerdon
                    End If
                End If
            End If

            _propertyNode.ClearEnums()

            For _idx As Integer = 0 To Surge2InfiltrationMethodSelections.Length - 1
                Dim _value As String = Surge2InfiltrationMethodSelections(_idx).Value
                _propertyNode.AddEnumItem(_value, _idx, True)
            Next

            Return _propertyNode
        End Get
    End Property

    Public Property Surge2InfiltrationMethod() As IntegerParameter
        Get
            Dim _integerParam As IntegerParameter = Surge2InfiltrationMethodProperty.GetIntegerParameter()
            Return _integerParam
        End Get
        Set(ByVal Value As IntegerParameter)
            Surge2InfiltrationMethodProperty.SetParameter(Value)
        End Set
    End Property

    Private mSurge2InfiltrationMethodIndex As Integer = -1
    Public Function GetFirstSurge2InfiltrationMethodSelection(ByRef _sel As String) As Boolean
        mSurge2InfiltrationMethodIndex = -1
        Return GetNextSurge2InfiltrationMethodSelection(_sel)
    End Function

    Public Function GetNextSurge2InfiltrationMethodSelection(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mSurge2InfiltrationMethodIndex += 1
        If (mSurge2InfiltrationMethodIndex < Surge2InfiltrationMethods.HighLimit) Then
            _sel = Surge2InfiltrationMethodSelections(mSurge2InfiltrationMethodIndex).Value
            If ((Surge2InfiltrationMethodSelections(mSurge2InfiltrationMethodIndex).Flags And _flags) = 0) Then
                ' Selection is valid for World, User Level & Cross Section
                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function

#End Region

#Region " Wetted Perimeter Method "

    Public Const sWettedPerimeterMethod As String = "Wetted Perimeter Method"

    Public ReadOnly Property WettedPerimeterMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWettedPerimeterMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultWettedPerimeterMethod)
                mMyStore.AddProperty(sWettedPerimeterMethod, _integer)
                _propertyNode = mMyStore.GetProperty(sWettedPerimeterMethod)
            End If

            Dim _param As Parameter = _propertyNode.GetParameter
            Dim _integerParam As IntegerParameter = DirectCast(_param, IntegerParameter)

            ' Replace old upstream methods with new one (as of 07/11/28)
            If ((_integerParam.Value = WettedPerimeterMethods.AtNormalInflowDepth) _
             Or (_integerParam.Value = WettedPerimeterMethods.UpstreamWettedPerimeter)) Then
                _integerParam.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter
            End If

            ' Keep Wetted Perimeter value within valid range
            If (_integerParam.Value >= WettedPerimeterMethods.HighLimit) Then
                _integerParam.Value = WettedPerimeterMethods.HighLimit - 1
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property WettedPerimeterMethod() As IntegerParameter
        Get
            Dim _integerParam As IntegerParameter = WettedPerimeterMethodProperty.GetIntegerParameter()
            Return _integerParam
        End Get
        Set(ByVal Value As IntegerParameter)
            WettedPerimeterMethodProperty.SetParameter(Value)
        End Set
    End Property

    Private mWettedPerimeterMethodIndex As Integer = -1
    Public Function GetFirstWettedPerimeterMethodSelection(ByRef _sel As String) As Boolean
        mWettedPerimeterMethodIndex = -1
        Return GetNextWettedPerimeterMethodSelection(_sel)
    End Function

    Public Function GetNextWettedPerimeterMethodSelection(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mWettedPerimeterMethodIndex += 1
        If (mWettedPerimeterMethodIndex < WettedPerimeterMethods.HighLimit) Then
            _sel = WettedPerimeterMethodSelections(mWettedPerimeterMethodIndex).Value
            If ((WettedPerimeterMethodSelections(mWettedPerimeterMethodIndex).Flags And _flags) = 0) Then
                ' Selection is valid for World, User Level & Cross Section
                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function

#End Region

#Region " Infiltration "

#Region " Characteristic Infiltration Time "
    '
    ' Characteristic Infiltration Time
    '
    ' User Inputs:
    '   Characteristic Infiltration Depth
    '   Characteristic Infiltration Time
    '   Kostiakov a
    '
    Public Const sInfiltrationDepth_KT As String = "Characteristic Infiltration Depth"

    Public ReadOnly Property InfiltrationDepth_KTProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInfiltrationDepth_KT)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultInfiltrationDepth, Units.Millimeters)
                mMyStore.AddProperty(sInfiltrationDepth_KT, _double)
                _propertyNode = mMyStore.GetProperty(sInfiltrationDepth_KT)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InfiltrationDepth_KT() As DoubleParameter
        Get
            Return InfiltrationDepth_KTProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            InfiltrationDepth_KTProperty.SetParameter(Value)
        End Set
    End Property


    Private Const sCorrespondingInfiltrationTime As String = "Corresponding Infiltration Time" ' Changed from "Corresponding" to "Characteristic"!
    Public Const sCharacteristicInfiltrationTime As String = "Characteristic Infiltration Time"

    Public ReadOnly Property InfiltrationTime_KTProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCharacteristicInfiltrationTime)

            ' If it was not found; check deprecated name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sCorrespondingInfiltrationTime)

                ' If deprecated name was found; update it
                If (_propertyNode IsNot Nothing) Then
                    _propertyNode.MyID = sCharacteristicInfiltrationTime
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultInfiltrationTime, Units.Hours)
                mMyStore.AddProperty(sCharacteristicInfiltrationTime, _double)
                _propertyNode = mMyStore.GetProperty(sCharacteristicInfiltrationTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InfiltrationTime_KT() As DoubleParameter
        Get
            Return InfiltrationTime_KTProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            InfiltrationTime_KTProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sKostiakovA_KT As String = "Kostiakov a - Known Time"
    Public Const sKostiakovACharTime As String = "Kostiakov a - Char Time"

    Public ReadOnly Property KostiakovA_KTProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovACharTime)

            ' If it was not found; check deprecated name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sKostiakovA_KT)

                ' If deprecated name was found; update it
                If (_propertyNode IsNot Nothing) Then
                    _propertyNode.MyID = sKostiakovACharTime
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultKostiakovA, Units.None)
                _double.MinValue = mWinSRFR.MinimumKostiakovA
                _double.MaxValue = MaximumKostiakovA
                mMyStore.AddProperty(sKostiakovACharTime, sa, _double)
                _propertyNode = mMyStore.GetProperty(sKostiakovACharTime)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = mWinSRFR.MinimumKostiakovA
                _double.MaxValue = MaximumKostiakovA
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovA_KT() As DoubleParameter
        Get
            Return KostiakovA_KTProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            KostiakovA_KTProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Kostiakov Formula "
    '
    ' Kostiakov Formula:  Zn = k * T^a
    '
    ' User Inputs:
    '   Kostiakov a, k
    '
    Public Const sKostiakovA_KF As String = "Kostiakov a"

    Public ReadOnly Property KostiakovA_KFProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovA_KF)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultKostiakovA, Units.None)
                _double.MinValue = mWinSRFR.MinimumKostiakovA
                _double.MaxValue = MaximumKostiakovA
                mMyStore.AddProperty(sKostiakovA_KF, sa, _double)
                _propertyNode = mMyStore.GetProperty(sKostiakovA_KF)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = mWinSRFR.MinimumKostiakovA
                _double.MaxValue = MaximumKostiakovA
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovA_KF() As DoubleParameter
        Get
            Return KostiakovA_KFProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            KostiakovA_KFProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sKostiakovK_KF As String = "Kostiakov k"

    Public ReadOnly Property KostiakovK_KFProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovK_KF)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _kostiakovK As KostiakovKParameter = New KostiakovKParameter(DefaultKostiakovK,
                                    KostiakovKParameter.K_Units.MetersPerSecond_A, KostiakovA_KFProperty)
                mMyStore.AddProperty(sKostiakovK_KF, sk, _kostiakovK)
                _propertyNode = mMyStore.GetProperty(sKostiakovK_KF)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovK_KF() As KostiakovKParameter
        Get
            ' Get the current Parameter
            Dim _parameter As Parameter = KostiakovK_KFProperty.GetParameter()

            ' Validate & return a copy of the KostiakovKParameter
            If (_parameter.GetType Is GetType(KostiakovKParameter)) Then
                Dim _kostiakovK As KostiakovKParameter = DirectCast(_parameter, KostiakovKParameter)

                Dim _copy As KostiakovKParameter = New KostiakovKParameter(_kostiakovK)
                Return _copy
            End If

            Debug.Assert(False, "Parameter is not KostiakovKParameter")
            Return Nothing
        End Get
        Set(ByVal Value As KostiakovKParameter)
            KostiakovK_KFProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Modified Kostiakov Formula "
    '
    ' Modified Kostiakov Formula:  Zn = k * T^a + (b * T) + c
    '
    ' User Inputs:
    '   Kostiakov a, b, c, k
    '
    Public Const sKostiakovA_MK As String = "Modified Kostiakov A"
    Public Const sa As String = "a"

    Public ReadOnly Property KostiakovA_MKProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovA_MK)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultKostiakovA, Units.None)
                _double.MinValue = mWinSRFR.MinimumKostiakovA
                _double.MaxValue = MaximumKostiakovA
                mMyStore.AddProperty(sKostiakovA_MK, sa, _double)
                _propertyNode = mMyStore.GetProperty(sKostiakovA_MK)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = mWinSRFR.MinimumKostiakovA
                _double.MaxValue = MaximumKostiakovA
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovA_MK() As DoubleParameter
        Get
            Return KostiakovA_MKProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            KostiakovA_MKProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sKostiakovB_MK As String = "Modified Kostiakov B"
    Public Const sb As String = "b"

    Public ReadOnly Property KostiakovB_MKProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovB_MK)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _dParam As KostiakovBParameter = New KostiakovBParameter(DefaultKostiakovB, Units.MetersPerSecond)
                _dParam.MinValue = MinimumKostiakovB
                _dParam.MaxValue = MaximumKostiakovB
                mMyStore.AddProperty(sKostiakovB_MK, sb, _dParam)
                _propertyNode = mMyStore.GetProperty(sKostiakovB_MK)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovB_MK() As KostiakovBParameter
        Get
            ' Get the current Parameter
            Dim _parameter As Parameter = KostiakovB_MKProperty.GetParameter()

            ' Validate & return a copy of the KostiakovBParameter
            If (_parameter.GetType Is GetType(KostiakovBParameter)) Then
                Dim _b As KostiakovBParameter = DirectCast(_parameter, KostiakovBParameter)
                Dim _copy As KostiakovBParameter = New KostiakovBParameter(_b)
                Return _copy
            ElseIf (_parameter.GetType Is GetType(DoubleParameter)) Then
                Dim _double As DoubleParameter = DirectCast(_parameter, DoubleParameter)
                Dim _copy As KostiakovBParameter = New KostiakovBParameter(_double)
                Return _copy
            End If

            Debug.Assert(False, "Parameter is not KostiakovBParameter")
            Return Nothing
        End Get
        Set(ByVal Value As KostiakovBParameter)
            KostiakovB_MKProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sKostiakovC_MK As String = "Modified Kostiakov C"
    Public Const sc As String = "c"

    Public ReadOnly Property KostiakovC_MKProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovC_MK)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultKostiakovC, Units.Millimeters)
                mMyStore.AddProperty(sKostiakovC_MK, sc, _double)
                _propertyNode = mMyStore.GetProperty(sKostiakovC_MK)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.MillimetersInchesUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovC_MK() As DoubleParameter
        Get
            Return KostiakovC_MKProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            KostiakovC_MKProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sKostiakovK_MK As String = "Modified Kostiakov K"
    Public Const sk As String = "k"

    Public ReadOnly Property KostiakovK_MKProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovK_MK)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _kostiakovK As KostiakovKParameter = New KostiakovKParameter(DefaultKostiakovK,
                                    KostiakovKParameter.K_Units.MetersPerSecond_A, KostiakovA_MKProperty)
                mMyStore.AddProperty(sKostiakovK_MK, sk, _kostiakovK)
                _propertyNode = mMyStore.GetProperty(sKostiakovK_MK)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovK_MK() As KostiakovKParameter
        Get
            ' Get the current Parameter
            Dim _parameter As Parameter = KostiakovK_MKProperty.GetParameter()

            ' Validate & return a copy of the KostiakovKParameter
            If (_parameter.GetType Is GetType(KostiakovKParameter)) Then
                Dim _kostiakovK As KostiakovKParameter = DirectCast(_parameter, KostiakovKParameter)

                Dim _copy As KostiakovKParameter = New KostiakovKParameter(_kostiakovK)
                Return _copy
            End If

            Debug.Assert(False, "Parameter is not KostiakovKParameter")
            Return Nothing

        End Get
        Set(ByVal Value As KostiakovKParameter)
            KostiakovK_MKProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sTimeOffsetC As String = "Time Offset C"

    Public ReadOnly Property TimeOffsetCProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTimeOffsetC)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(False)
                mMyStore.AddProperty(sTimeOffsetC, _boolean)
                _propertyNode = mMyStore.GetProperty(sTimeOffsetC)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property TimeOffsetC() As BooleanParameter
        Get
            Dim _boolean As BooleanParameter = TimeOffsetCProperty.GetBooleanParameter()

            If Not (WinSRFR.IsResearchLevel) Then
                _boolean.Value = False
            End If

            Return _boolean
        End Get
        Set(ByVal Value As BooleanParameter)
            TimeOffsetCProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " NRCS Intake Family "
    '
    ' NRCS Intake Family
    '
    ' User Inputs:
    '   NRCS Intake Family Selection
    '
    Public Const sNrcsIntakeFamily As String = "NRCS Intake Family"

    Public ReadOnly Property NrcsIntakeFamilyProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNrcsIntakeFamily)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultNrcsIntakeFamily)
                mMyStore.AddProperty(sNrcsIntakeFamily, _integer)
                _propertyNode = mMyStore.GetProperty(sNrcsIntakeFamily)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property NrcsIntakeFamily() As IntegerParameter
        Get
            Return NrcsIntakeFamilyProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            NrcsIntakeFamilyProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Time Rated Intake Family "
    '
    ' Time Rated Intake Family
    '
    ' User Inputs:
    '   Characteristic Infiltration Depth (fixed at 100mm)
    '   Characteristic Infiltration Time
    '
    Public Const sInfiltrationTime_TR As String = "Time Rated Intake Family"

    Public ReadOnly Property InfiltrationTime_TRProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInfiltrationTime_TR)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultInfiltrationTime, Units.Hours)
                mMyStore.AddProperty(sInfiltrationTime_TR, _double)
                _propertyNode = mMyStore.GetProperty(sInfiltrationTime_TR)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InfiltrationTime_TR() As DoubleParameter
        Get
            Return InfiltrationTime_TRProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            InfiltrationTime_TRProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Branch Formula "
    '
    ' Branch Formula:  Zn = k * T^a + c    branches to    Zn = Zb + (b * T)
    '
    ' User Inputs:
    '   Kostiakov a, c, k
    '   Branch b, Time
    '
    Public Const sKostiakovA_BF As String = "Branch a"

    Public ReadOnly Property KostiakovA_BFProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovA_BF)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultKostiakovA, Units.None)
                _double.MinValue = mWinSRFR.MinimumKostiakovA
                _double.MaxValue = MaximumKostiakovA
                mMyStore.AddProperty(sKostiakovA_BF, sa, _double)
                _propertyNode = mMyStore.GetProperty(sKostiakovA_BF)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = mWinSRFR.MinimumKostiakovA
                _double.MaxValue = MaximumKostiakovA
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovA_BF() As DoubleParameter
        Get
            Return KostiakovA_BFProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            KostiakovA_BFProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sKostiakovC_BF As String = "Branch c"

    Public ReadOnly Property KostiakovC_BFProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovC_BF)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultKostiakovC, Units.Millimeters)
                mMyStore.AddProperty(sKostiakovC_BF, sc, _double)
                _propertyNode = mMyStore.GetProperty(sKostiakovC_BF)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.MillimetersInchesUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovC_BF() As DoubleParameter
        Get
            Return KostiakovC_BFProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            KostiakovC_BFProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sKostiakovK_BF As String = "Branch k"

    Public ReadOnly Property KostiakovK_BFProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovK_BF)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _kostiakovK As KostiakovKParameter = New KostiakovKParameter(DefaultKostiakovK,
                                KostiakovKParameter.K_Units.MetersPerSecond_A, KostiakovA_BFProperty)
                mMyStore.AddProperty(sKostiakovK_BF, sk, _kostiakovK)
                _propertyNode = mMyStore.GetProperty(sKostiakovK_BF)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovK_BF() As KostiakovKParameter
        Get
            ' Get the current Parameter
            Dim _parameter As Parameter = KostiakovK_BFProperty.GetParameter()

            ' Validate & return a copy of the KostiakovKParameter
            If (_parameter.GetType Is GetType(KostiakovKParameter)) Then
                Dim _kostiakovK As KostiakovKParameter = DirectCast(_parameter, KostiakovKParameter)

                Dim _copy As KostiakovKParameter = New KostiakovKParameter(_kostiakovK)
                Return _copy
            End If

            Debug.Assert(False, "Parameter is not KostiakovKParameter")
            Return Nothing

        End Get
        Set(ByVal Value As KostiakovKParameter)
            KostiakovK_BFProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sBranchB_BF As String = "Branch b"

    Public ReadOnly Property BranchB_BFProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sBranchB_BF)

            Dim dZdT As Double = MaximumBranchB
            If (Me.BranchTimeSet.Value) Then
                Dim _bNode As PropertyNode = mMyStore.GetProperty(sBranchTime_BF)
                If (_bNode IsNot Nothing) Then
                    Dim _bParam As Parameter = _bNode.GetParameter
                    Dim _double As DoubleParameter = DirectCast(_bParam, DoubleParameter)
                    Dim Tb As Double = _double.Value
                    Dim a As Double = Me.KostiakovA_BF.Value
                    Dim k As Double = Me.KostiakovK_BF.Value
                    dZdT = a * k * (Tb ^ (a - 1))              ' Derivative of Branch Function
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As KostiakovBParameter = New KostiakovBParameter(DefaultBranchB, Units.MetersPerSecond)
                _double.MinValue = MinimumBranchB
                _double.MaxValue = dZdT
                mMyStore.AddProperty(sBranchB_BF, sb, _double)
                _propertyNode = mMyStore.GetProperty(sBranchB_BF)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = MinimumBranchB
                _double.MaxValue = dZdT
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property BranchB_BF() As KostiakovBParameter
        Get
            ' Get the current Parameter
            Dim _parameter As Parameter = BranchB_BFProperty.GetParameter()

            ' Validate & return a copy of the KostiakovBParameter
            If (_parameter.GetType Is GetType(KostiakovBParameter)) Then
                Dim _b As KostiakovBParameter = DirectCast(_parameter, KostiakovBParameter)
                Dim _copy As KostiakovBParameter = New KostiakovBParameter(_b)
                Return _copy
            ElseIf (_parameter.GetType Is GetType(DoubleParameter)) Then
                Dim _double As DoubleParameter = DirectCast(_parameter, DoubleParameter)
                Dim _copy As KostiakovBParameter = New KostiakovBParameter(_double)
                Return _copy
            End If

            Debug.Assert(False, "Parameter is not KostiakovBParameter")
            Return Nothing
        End Get
        Set(ByVal Value As KostiakovBParameter)
            BranchB_BFProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sBranchTime_BF As String = "Branch Time"

    Public ReadOnly Property BranchTime_BFProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sBranchTime_BF)

            ' Use calculated Branch Time for default user-entered value
            Dim k As Double = Me.KostiakovK_BF.Value
            Dim a As Double = Me.KostiakovA_BF.Value
            Dim b As Double = Me.BranchB_BF.Value
            Dim Tb As Double = Srfr.SrfrAPI.BranchTime(k, a, b)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(Tb, Units.Seconds)
                mMyStore.AddProperty(sBranchTime_BF, _double)
                _propertyNode = mMyStore.GetProperty(sBranchTime_BF)
            Else ' If it was found; update its default value
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.Source = ValueSources.Defaulted) Then
                    Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                    _double.Value = Tb
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property BranchTime_BF() As DoubleParameter
        Get
            Return BranchTime_BFProperty.GetDoubleParameter()
        End Get
        Set(ByVal value As DoubleParameter)
            BranchTime_BFProperty.SetParameter(value)
        End Set
    End Property


    Public Const sBranchTimeSet_BF As String = "Branch Time Set"

    Public ReadOnly Property BranchTimeSetProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sBranchTimeSet_BF)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(False)
                mMyStore.AddProperty(sBranchTimeSet_BF, _boolean)
                _propertyNode = mMyStore.GetProperty(sBranchTimeSet_BF)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property BranchTimeSet() As BooleanParameter
        Get
            Return BranchTimeSetProperty.GetBooleanParameter()
        End Get
        Set(ByVal Value As BooleanParameter)
            BranchTimeSetProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Green-Ampt "

    Public Const sSoilTextureSelectionGA As String = "Soil Texture Selection"

    Public ReadOnly Property SoilTextureSelectionGA_Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSoilTextureSelectionGA)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultSoilTextureSelection)
                mMyStore.AddProperty(sSoilTextureSelectionGA, _integer)
                _propertyNode = mMyStore.GetProperty(sSoilTextureSelectionGA)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SoilTextureSelectionGA() As IntegerParameter
        Get
            Return SoilTextureSelectionGA_Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            SoilTextureSelectionGA_Property.SetParameter(Value)
        End Set
    End Property

    Private mSoilTextureSelectionIndexGA As Integer = -1
    Public Function GetFirstSoilTextureSelectionGA(ByRef _sel As String) As Boolean
        mSoilTextureSelectionIndexGA = -1
        Return GetNextSoilTextureSelectionGA(_sel)
    End Function

    Public Function GetNextSoilTextureSelectionGA(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mSoilTextureSelectionIndexGA += 1
        If (mSoilTextureSelectionIndexGA <= Srfr.Infiltration.SoilTextures.Clay) Then
            _sel = SoilTextureSelections(mSoilTextureSelectionIndexGA).Value
            If ((SoilTextureSelections(mSoilTextureSelectionIndexGA).Flags And _flags) = 0) Then
                ' Selection is valid for World, User Level & Cross Section
                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function


    Public Const sPorosity As String = "Porosity"
    Public Const sEffectivePorosity As String = "Effective Porosity"
    Public Const sSaturatedWaterContentGA As String = "Saturated Water Content"
    Public ReadOnly Property EffectivePorosityGA_Property() As PropertyNode
        Get
            Dim _soilTexture As Integer = DefaultSoilTextureSelection
            Dim _effectivePorosity As Double = Srfr.Infiltration.SoilPropertiesTable(_soilTexture).EffectivePorosity

            Dim _source As ValueSources = ValueSources.Defaulted

            ' Handle name change from "Porosity" to "Effective Porosity" to "Saturated Water Content"
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSaturatedWaterContentGA)
            If (_propertyNode Is Nothing) Then ' doesn't exist as "Saturated Water Content"
                _propertyNode = mMyStore.GetProperty(sEffectivePorosity) ' try "Effective Porosity"
                If (_propertyNode Is Nothing) Then ' doesn't exist as "Effective Porosity"
                    _propertyNode = mMyStore.GetProperty(sPorosity) ' try "Porosity"
                    If (_propertyNode IsNot Nothing) Then ' exists as "Porosity"; get its value then delete it
                        Dim _double As DoubleParameter = _propertyNode.GetDoubleParameter
                        If (_double IsNot Nothing) Then
                            _effectivePorosity = _double.Value
                            _source = _double.Source
                        End If
                        mMyStore.DeleteProperty(sPorosity)
                        _propertyNode = Nothing
                    End If
                Else ' exists as "Effective Porosity"; get its value then delete it
                    Dim _double As DoubleParameter = _propertyNode.GetDoubleParameter
                    If (_double IsNot Nothing) Then
                        _effectivePorosity = _double.Value
                        _source = _double.Source
                    End If
                    mMyStore.DeleteProperty(sEffectivePorosity)
                    _propertyNode = Nothing
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(_effectivePorosity, Units.CentimetersPerCentimeter)
                _double.Source = _source
                mMyStore.AddProperty(sSaturatedWaterContentGA, "ThetaS", _double)
                _propertyNode = mMyStore.GetProperty(sSaturatedWaterContentGA)
            End If

            Dim _doubleParameter As DoubleParameter = _propertyNode.GetParameter
            _doubleParameter.Units = Units.CentimetersPerCentimeter

            _propertyNode.Symbol = "ThetaS"
            Return _propertyNode
        End Get
    End Property

    Public Property EffectivePorosityGA() As DoubleParameter
        Get
            Dim _doubleParameter As DoubleParameter = EffectivePorosityGA_Property.GetDoubleParameter()
            _doubleParameter.Units = Units.CentimetersPerCentimeter
            Return _doubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            EffectivePorosityGA_Property.SetParameter(Value)
        End Set
    End Property


    Public Const sInitVolWaterContent As String = "Init Vol Water Content"
    Public Const sInitialWaterContent As String = "Initial Water Content"
    Public ReadOnly Property InitialWaterContentGA_Property() As PropertyNode
        Get
            Dim _soilTexture As Integer = DefaultSoilTextureSelection
            Dim _initialWaterContent As Double = Srfr.Infiltration.SoilPropertiesTable(_soilTexture).InitialWaterContent

            Dim _source As ValueSources = ValueSources.Defaulted

            ' Handle name change from "Init Vol Water Content" to "Initial Water Content"
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInitialWaterContent)
            If (_propertyNode Is Nothing) Then ' doesn't exist as "Initial Water Content"
                _propertyNode = mMyStore.GetProperty(sInitVolWaterContent) ' try "Init Vol Water Content"
                If (_propertyNode IsNot Nothing) Then ' exists as "Init Vol Water Content"; get its value then delete it
                    Dim _double As DoubleParameter = _propertyNode.GetDoubleParameter
                    If (_double IsNot Nothing) Then
                        _initialWaterContent = _double.Value
                        _source = _double.Source
                    End If
                    _initialWaterContent = _propertyNode.GetDoubleParameter.Value
                    mMyStore.DeleteProperty(sInitVolWaterContent)
                    _propertyNode = Nothing
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(_initialWaterContent, Units.CentimetersPerCentimeter)
                _double.Source = _source
                mMyStore.AddProperty(sInitialWaterContent, "Theta0", _double)
                _propertyNode = mMyStore.GetProperty(sInitialWaterContent)
            End If

            Dim _doubleParameter As DoubleParameter = _propertyNode.GetParameter
            _doubleParameter.Units = Units.CentimetersPerCentimeter

            _propertyNode.Symbol = "Theta0"
            Return _propertyNode
        End Get
    End Property

    Public Property InitialWaterContentGA() As DoubleParameter
        Get
            Dim _doubleParameter As DoubleParameter = InitialWaterContentGA_Property.GetDoubleParameter()
            _doubleParameter.Units = Units.CentimetersPerCentimeter
            Return _doubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            InitialWaterContentGA_Property.SetParameter(Value)
        End Set
    End Property


    Public Const sAirEntryPressure As String = "Air-Entry Pressure"
    Public Const sWettingFrontPressureHead As String = "Wetting Front Pressure Head"
    Public ReadOnly Property WettingFrontPressureHeadGA_Property() As PropertyNode
        Get
            Dim _soilTexture As Integer = DefaultSoilTextureSelection
            Dim _wettingFrontPressureHead As Double = Srfr.Infiltration.SoilPropertiesTable(_soilTexture).WettingFrontPressureHead

            Dim _source As ValueSources = ValueSources.Defaulted

            ' Handle name change from "Air-Entry Pressure" to "Wetting Front Pressure Head"
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWettingFrontPressureHead)
            If (_propertyNode Is Nothing) Then ' doesn't exist as "Wetting Front Pressure Head"
                _propertyNode = mMyStore.GetProperty(sAirEntryPressure) ' try "Air-Entry Pressure"
                If (_propertyNode IsNot Nothing) Then ' exists as "Air-Entry Pressure"; get its value then delete it
                    Dim _double As DoubleParameter = _propertyNode.GetDoubleParameter
                    If (_double IsNot Nothing) Then
                        _wettingFrontPressureHead = _double.Value
                        _source = _double.Source
                    End If
                    mMyStore.DeleteProperty(sAirEntryPressure)
                    _propertyNode = Nothing
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(_wettingFrontPressureHead, Units.Millimeters)
                _double.Source = _source
                mMyStore.AddProperty(sWettingFrontPressureHead, "hf", _double)
                _propertyNode = mMyStore.GetProperty(sWettingFrontPressureHead)
            End If

            Dim _param As Parameter = _propertyNode.GetParameter
            If (_param IsNot Nothing) Then
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = Double.MinValue
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.CentimetersInchesUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property WettingFrontPressureHeadGA() As DoubleParameter
        Get
            Return WettingFrontPressureHeadGA_Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            WettingFrontPressureHeadGA_Property.SetParameter(Value)
        End Set
    End Property


    Public Const sSaturatedHydraulicConductivity As String = "Saturated Hydraulic Conductivity"
    Public Const sHydraulicConductivity As String = "Hydraulic Conductivity"
    Public ReadOnly Property HydraulicConductivityGA_Property() As PropertyNode
        Get
            Dim _soilTexture As Integer = DefaultSoilTextureSelection
            Dim _hydraulicConductivity As Double = Srfr.Infiltration.SoilPropertiesTable(_soilTexture).HydraulicConductivity

            Dim _source As ValueSources = ValueSources.Defaulted

            ' Handle name change from "Saturated Hydraulic Conductivity" to "Hydraulic Conductivity"
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHydraulicConductivity)
            If (_propertyNode Is Nothing) Then ' doesn't exist as "Hydraulic Conductivity"
                _propertyNode = mMyStore.GetProperty(sSaturatedHydraulicConductivity) ' try "Saturated Hydraulic Conductivity"
                If (_propertyNode IsNot Nothing) Then ' exists as "Saturated Hydraulic Conductivity"; get its value then delete it
                    Dim _double As DoubleParameter = _propertyNode.GetDoubleParameter
                    If (_double IsNot Nothing) Then
                        _hydraulicConductivity = _double.Value
                        _source = _double.Source
                    End If
                    mMyStore.DeleteProperty(sSaturatedHydraulicConductivity)
                    _propertyNode = Nothing
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(_hydraulicConductivity, Units.MetersPerSecond)
                _double.Source = _source
                mMyStore.AddProperty(sHydraulicConductivity, "Ks", _double)
                _propertyNode = mMyStore.GetProperty(sHydraulicConductivity)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.CentimetersInchesPerHourUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property HydraulicConductivityGA() As DoubleParameter
        Get
            Dim _double As DoubleParameter = HydraulicConductivityGA_Property.GetDoubleParameter
            If (_double Is Nothing) Then ' Verify default exists if previous parameter was the deleted HydraulicConductivityParameter
                Dim _soilTexture As Integer = DefaultSoilTextureSelection
                Dim _hydraulicConductivity As Double = Srfr.Infiltration.SoilPropertiesTable(_soilTexture).HydraulicConductivity
                _double = New DoubleParameter(_hydraulicConductivity, Units.MetersPerSecond)
            End If
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            HydraulicConductivityGA_Property.SetParameter(Value)
        End Set
    End Property


    Public Const sGreenAmptC As String = "Green-Ampt C"

    Public ReadOnly Property GreenAmptC_Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGreenAmptC)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultKostiakovC, Units.Millimeters)
                mMyStore.AddProperty(sGreenAmptC, sc, _double)
                _propertyNode = mMyStore.GetProperty(sGreenAmptC)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.CentimetersInchesUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property GreenAmptC() As DoubleParameter
        Get
            Return GreenAmptC_Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            GreenAmptC_Property.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " HYDRUS "

    '*********************************************************************************************************
    Public ReadOnly Property HydrusProjectProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(Srfr.Hydrus.sHydrusProject)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As StringParameter = New StringParameter(DefaultHydrusInfiltrationFilename)
                mMyStore.AddProperty(Srfr.Hydrus.sHydrusProject, _parameter)
                _propertyNode = mMyStore.GetProperty(Srfr.Hydrus.sHydrusProject)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property HydrusProject() As StringParameter
        Get
            Return HydrusProjectProperty.GetStringParameter()
        End Get
        Set(ByVal Value As StringParameter)
            HydrusProjectProperty.SetParameter(Value)
        End Set
    End Property

    '*********************************************************************************************************
    Public Const sSyncHydrusOption As String = "Sync HYDRUS Options"

    Public ReadOnly Property SyncHydrusOptionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSyncHydrusOption)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultSyncHydrusOption)
                mMyStore.AddProperty(sSyncHydrusOption, _integer)
                _propertyNode = mMyStore.GetProperty(sSyncHydrusOption)
            End If

            _propertyNode.ClearEnums()

            For _idx As Integer = 0 To SyncHydrusSelections.Length - 1
                Dim _value As String = SyncHydrusSelections(_idx).Value
                _propertyNode.AddEnumItem(_value, _idx, True)
            Next

            Return _propertyNode
        End Get
    End Property

    Public Property SyncHydrusOption() As IntegerParameter
        Get
            Return SyncHydrusOptionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            SyncHydrusOptionProperty.SetParameter(Value)
        End Set
    End Property

    Private mSyncHydrusOptionIndex As Integer = -1
    Public Function GetFirstSyncHydrusOption(ByRef _sel As String) As Boolean
        mSyncHydrusOptionIndex = -1
        Return GetNextSyncHydrusOption(_sel)
    End Function

    Public Function GetNextSyncHydrusOption(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mSyncHydrusOptionIndex += 1
        If (mSyncHydrusOptionIndex <= Srfr.Infiltration.SoilTextures.Clay) Then
            _sel = SyncHydrusSelections(mSyncHydrusOptionIndex).Value
            If ((SyncHydrusSelections(mSyncHydrusOptionIndex).Flags And _flags) = 0) Then
                ' Selection is valid for World, User Level & Cross Section
                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function

    '*********************************************************************************************************
    Public Const sHydrusSyncDistances As String = "HYDRUS Sync Distances"

    Public ReadOnly Property HydrusSyncDistancesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHydrusSyncDistances)

            ' Define default Tabulated  Table Infiltration table & parameter
            Dim _hydrusSyncDists As DataTable = New DataTable(sHydrusSyncDistances)
            ResetHydrusSyncDistances(_hydrusSyncDists)
            Dim _parameter As DataTableParameter = New DataTableParameter(_hydrusSyncDists)

            ' If Property was not found; create it
            ' If Property was found; validate its data
            If (_propertyNode Is Nothing) Then
                ' Property not found; create it
                mMyStore.AddProperty(sHydrusSyncDistances, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusSyncDistances)
            ElseIf (_propertyNode.GetDataTableParameter Is Nothing) Then
                ' Property found but it does not contain a parameter
                mMyStore.DeleteProperty(sHydrusSyncDistances)
                mMyStore.AddProperty(sHydrusSyncDistances, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusSyncDistances)
            ElseIf (_propertyNode.GetDataTableParameter.Value Is Nothing) Then
                ' Parameter found but it does not contain a DataTable
                mMyStore.DeleteProperty(sHydrusSyncDistances)
                mMyStore.AddProperty(sHydrusSyncDistances, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusSyncDistances)
            End If

            ' If sync distances are chosen be WinSRFR, make sure they are current
            If (Me.SyncHydrusOption.Value = SyncHydrusOptions.SyncWithWinSrfrDistances) Then
                ChooseHydrusSyncDists()
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property HydrusSyncDistances() As DataTableParameter
        Get
            Dim _table As DataTableParameter = HydrusSyncDistancesProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            HydrusSyncDistancesProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetHydrusSyncDistances(ByVal HydrusSyncDistances As DataTable)

        ' Remove the previous data
        HydrusSyncDistances.Columns.Clear()
        HydrusSyncDistances.Rows.Clear()

        ' Add the columns
        HydrusSyncDistances.Columns.Add(sDistanceX, GetType(Double))

        ' Add the row(s) of reset data
        Dim _syncDist As DataRow = HydrusSyncDistances.NewRow
        _syncDist.Item(sDistanceX) = 0.0
        HydrusSyncDistances.Rows.Add(_syncDist)

    End Sub

    '*********************************************************************************************************
    ' Sub ChooseHydrusSyncDists() - choose the WinSRFR distances at which to sync HYDRUS & SRFR
    '*********************************************************************************************************
    Private Sub ChooseHydrusSyncDists()

        Dim fieldLength As Double = mUnit.SystemGeometryRef.Length.Value
        Dim cellWidth As Double = fieldLength / mUnit.SrfrCriteriaRef.CellDensity.Value

        Dim syncAllDists As List(Of Double) = New List(Of Double) From {
            0.0,
            fieldLength
        }

        ' First, get all tabulated parameter distances
        Dim syncList As List(Of Double) = mUnit.SystemGeometryRef.TabulatedElevationDistances
        If (syncList IsNot Nothing) Then
            syncAllDists.AddRange(syncList)
        End If

        syncList = mUnit.SystemGeometryRef.TabulatedGeometryDistances
        If (syncList IsNot Nothing) Then
            syncAllDists.AddRange(syncList)
        End If

        syncList = Me.TabulatedRoughnessDistances
        If (syncList IsNot Nothing) Then
            syncAllDists.AddRange(syncList)
        End If

        syncList = Me.TabulatedHydrusDistances
        If (syncList IsNot Nothing) Then
            syncAllDists.AddRange(syncList)
        End If

        syncAllDists.Sort()

        ' Second, add distance 1 cell width back from tabulated distances
        Dim syncCount As Integer = syncAllDists.Count
        For sdx As Integer = 0 To syncCount - 1
            Dim dist As Double = syncAllDists(sdx)

            If ((cellWidth * 2 < dist) And (dist < fieldLength)) Then
                syncAllDists.Add(dist - cellWidth)
            End If
        Next

        syncAllDists.Sort()

        ' Third, fill in large gaps
        Dim gapDivisor As Integer = 4
        Dim gapMax As Double = Math.Round(fieldLength / gapDivisor, 0)
        If (gapMax > 25) Then ' limit gap to at most 25m
            gapMax = 25
        End If

        Dim filling As Boolean = True
        While (filling)
            filling = False
            Dim dist0 As Double = syncAllDists(0)
            For gdx As Integer = 1 To syncAllDists.Count - 1
                Dim dist1 As Double = syncAllDists(gdx)
                Dim gap As Double = dist1 - dist0
                If (gap = 0.0) Then
                    syncAllDists.Remove(dist1)
                    filling = True
                    Exit For
                ElseIf (gapMax < gap) Then ' large gap; fill it in
                    Dim numFill As Integer = Math.Max(gap / gapMax, 1)
                    Dim gapFill As Double = gap / (numFill + 1)

                    For fdx As Integer = 1 To numFill
                        Dim dstFill As Double = Math.Round(dist0 + (gapFill * fdx), 0)

                        If (dstFill < dist1) Then
                            syncAllDists.Add(dstFill)
                        End If
                    Next

                    filling = True
                    syncAllDists.Sort()
                    Exit For
                End If

                dist0 = dist1
            Next
        End While

        While (syncAllDists.Remove(fieldLength))
        End While

        If (syncAllDists(syncAllDists.Count - 1) < fieldLength - (2 * cellWidth)) Then
            syncAllDists.Add(fieldLength - cellWidth)
        End If

        ' Save HYDRUS sync distances
        Dim hydrusSyncNode As PropertyNode = mMyStore.GetProperty(sHydrusSyncDistances)

        Dim param As Parameter = hydrusSyncNode.GetParameter
        If (param IsNot Nothing) Then

            Dim distsParam As DataTableParameter = DirectCast(param, DataTableParameter)

            Dim hydrusSyncDists As DataTable = distsParam.Value
            Dim row As DataRow = Nothing
            hydrusSyncDists.Rows.Clear()
            For Each dist As Double In syncAllDists
                row = hydrusSyncDists.NewRow
                row.Item(sDistanceX) = dist
                hydrusSyncDists.Rows.Add(row)
            Next

            distsParam.Source = ValueSources.Calculated
            distsParam.Value = hydrusSyncDists

        End If

    End Sub

    Public Function FirstHydrusSyncDistance() As Double
        FirstHydrusSyncDistance = 0

        Dim syncDists As DataTable = HydrusSyncDistances.Value
        If (syncDists IsNot Nothing) Then
            If (0 < syncDists.Rows.Count) Then
                Dim row As DataRow = syncDists.Rows(0)
                FirstHydrusSyncDistance = row.Item(sDistanceX)
            End If
        End If
    End Function

    Public Function LastHydrusSyncDistance() As Double
        LastHydrusSyncDistance = 0

        Dim syncDists As DataTable = HydrusSyncDistances.Value
        If (syncDists IsNot Nothing) Then
            If (0 < syncDists.Rows.Count) Then
                Dim row As DataRow = syncDists.Rows(syncDists.Rows.Count - 1)
                LastHydrusSyncDistance = row.Item(sDistanceX)
            End If
        End If
    End Function

    '*********************************************************************************************************
    '*********************************************************************************************************
    Public Const sHydrusInfiltrationRate As String = "HYDRUS Infiltration Rate"

    Public ReadOnly Property HydrusInfiltrationRateProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHydrusInfiltrationRate)

            ' Define default Tabulated DataSet table & parameter
            Dim _hydrusInfiltrationRate As DataSet = New DataSet(sHydrusInfiltrationRate)
            ResetHydrusInfiltrationRate(_hydrusInfiltrationRate)
            Dim _parameter As DataSetParameter = New DataSetParameter(_hydrusInfiltrationRate)

            ' If Property was not found; create it
            ' If Property was found; validate its data
            If (_propertyNode Is Nothing) Then
                ' Property not found; create it
                mMyStore.AddProperty(sHydrusInfiltrationRate, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusInfiltrationRate)
            ElseIf (_propertyNode.GetDataSetParameter Is Nothing) Then
                ' Property found but it does not contain a parameter
                mMyStore.DeleteProperty(sHydrusInfiltrationRate)
                mMyStore.AddProperty(sHydrusInfiltrationRate, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusInfiltrationRate)
            ElseIf (_propertyNode.GetDataSetParameter.Value Is Nothing) Then
                ' Parameter found but it does not contain a DataSet
                mMyStore.DeleteProperty(sHydrusInfiltrationRate)
                mMyStore.AddProperty(sHydrusInfiltrationRate, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusInfiltrationRate)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property HydrusInfiltrationRate() As DataSetParameter
        Get
            Return HydrusInfiltrationRateProperty.GetDataSetParameter()
        End Get
        Set(ByVal Value As DataSetParameter)
            HydrusInfiltrationRateProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearHydrusInfiltrationRate()
        mMyStore.DeleteProperty(sHydrusInfiltrationRate)
    End Sub

    Public Sub ResetHydrusInfiltrationRate(ByVal HydrusInfiltrationRate As DataSet)

        ' Remove the previous data
        HydrusInfiltrationRate.Tables.Clear()

    End Sub

    '*********************************************************************************************************
    '*********************************************************************************************************
    Public Const sHydrusInfiltrationDepth As String = "HYDRUS Infiltration Depth"

    Public ReadOnly Property HydrusInfiltrationDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHydrusInfiltrationDepth)

            ' Define default Tabulated DataSet table & parameter
            Dim _hydrusInfiltrationDepth As DataSet = New DataSet(sHydrusInfiltrationDepth)
            ResetHydrusInfiltrationDepth(_hydrusInfiltrationDepth)
            Dim _parameter As DataSetParameter = New DataSetParameter(_hydrusInfiltrationDepth)

            ' If Property was not found; create it
            ' If Property was found; validate its data
            If (_propertyNode Is Nothing) Then
                ' Property not found; create it
                mMyStore.AddProperty(sHydrusInfiltrationDepth, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusInfiltrationDepth)
            ElseIf (_propertyNode.GetDataSetParameter Is Nothing) Then
                ' Property found but it does not contain a parameter
                mMyStore.DeleteProperty(sHydrusInfiltrationDepth)
                mMyStore.AddProperty(sHydrusInfiltrationDepth, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusInfiltrationDepth)
            ElseIf (_propertyNode.GetDataSetParameter.Value Is Nothing) Then
                ' Parameter found but it does not contain a DataSet
                mMyStore.DeleteProperty(sHydrusInfiltrationDepth)
                mMyStore.AddProperty(sHydrusInfiltrationDepth, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusInfiltrationDepth)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property HydrusInfiltrationDepth() As DataSetParameter
        Get
            Return HydrusInfiltrationDepthProperty.GetDataSetParameter()
        End Get
        Set(ByVal Value As DataSetParameter)
            HydrusInfiltrationDepthProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearHydrusInfiltrationDepth()
        mMyStore.DeleteProperty(sHydrusInfiltrationDepth)
    End Sub

    Public Sub ResetHydrusInfiltrationDepth(ByVal HydrusInfiltrationDepth As DataSet)

        ' Remove the previous data
        HydrusInfiltrationDepth.Tables.Clear()

    End Sub

    '*********************************************************************************************************
    ' Property HydrusProfiles
    '*********************************************************************************************************
    Public Const sHydrusProfiles As String = "HYDRUS Profiles"

    Public ReadOnly Property HydrusProfilesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHydrusProfiles)

            ' Define default Tabulated DataSet table & parameter
            Dim _hydrusProfiles As DataSet = New DataSet(sHydrusProfiles)
            ResetHydrusProfiles(_hydrusProfiles)
            Dim _parameter As DataSetParameter = New DataSetParameter(_hydrusProfiles)

            ' If Property was not found; create it
            ' If Property was found; validate its data
            If (_propertyNode Is Nothing) Then
                ' Property not found; create it
                mMyStore.AddProperty(sHydrusProfiles, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusProfiles)
            ElseIf (_propertyNode.GetDataSetParameter Is Nothing) Then
                ' Property found but it does not contain a parameter
                mMyStore.DeleteProperty(sHydrusProfiles)
                mMyStore.AddProperty(sHydrusProfiles, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusProfiles)
            ElseIf (_propertyNode.GetDataSetParameter.Value Is Nothing) Then
                ' Parameter found but it does not contain a DataSet
                mMyStore.DeleteProperty(sHydrusProfiles)
                mMyStore.AddProperty(sHydrusProfiles, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusProfiles)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property HydrusProfiles() As DataSetParameter
        Get
            Return HydrusProfilesProperty.GetDataSetParameter()
        End Get
        Set(ByVal Value As DataSetParameter)
            HydrusProfilesProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearHydrusConcentration()
        mMyStore.DeleteProperty(sHydrusProfiles)
    End Sub

    Public Sub ResetHydrusProfiles(ByVal HydrusProfiles As DataSet)
        HydrusProfiles.Tables.Clear() ' Remove the previous data
    End Sub

    Public Function HydrusInfiltration(ByVal Dist As Double) As Double
        HydrusInfiltration = 0.0

        Dim hydrusProfiles As DataSet = Me.HydrusProfiles.Value
        If (hydrusProfiles IsNot Nothing) Then

            For Each table As DataTable In hydrusProfiles.Tables

                If (table.ExtendedProperties.Contains("Dist")) Then

                    Dim tabDist As Double = CDbl(table.ExtendedProperties("Dist"))

                    If (ThisClose(Dist, tabDist, OneCentimeter)) Then

                        If (1 < table.Rows.Count) Then

                            Dim row0 As DataRow = table.Rows(0)
                            Dim depth0 As Double = row0.Item(sDepthX)
                            Dim moist0 As Double = row0.Item(sNewMoistureX)

                            For rdx As Integer = 1 To table.Rows.Count - 1

                                Dim row1 As DataRow = table.Rows(rdx)
                                Dim depth1 As Double = row1.Item(sDepthX)
                                Dim moist1 As Double = row1.Item(sNewMoistureX)

                                HydrusInfiltration += (depth1 - depth0) * (0.6 * moist0 + 0.4 * moist1)

                                depth0 = depth1
                                moist0 = moist1
                            Next
                        End If
                    End If
                End If
            Next
        End If
    End Function

    Public Function HydrusInfiltrationTable() As DataTable
        HydrusInfiltrationTable = Nothing

        Dim syncDists As DataTable = HydrusSyncDistances.Value
        If (syncDists IsNot Nothing) Then

            HydrusInfiltrationTable = New DataTable("HYDRUS Infiltration")
            HydrusInfiltrationTable.Columns.Add(sDistanceX, GetType(Double))
            HydrusInfiltrationTable.Columns.Add(sInfiltrationX, GetType(Double))

            For Each row As DataRow In syncDists.Rows
                Dim distance As Double = row.Item(sDistanceX)
                Dim infiltration As Double = Me.HydrusInfiltration(distance)

                Dim hydrusRow As DataRow = HydrusInfiltrationTable.NewRow
                hydrusRow.Item(sDistanceX) = distance
                hydrusRow.Item(sInfiltrationX) = infiltration
                HydrusInfiltrationTable.Rows.Add(hydrusRow)
            Next
        End If
    End Function

    Public Function HydrusDensity(ByVal Dist As Double) As Double
        HydrusDensity = 0.0

        Dim hydrusProfiles As DataSet = Me.HydrusProfiles.Value
        If (hydrusProfiles IsNot Nothing) Then

            For Each table As DataTable In hydrusProfiles.Tables

                If (table.ExtendedProperties.Contains("Dist")) Then

                    Dim tabDist As Double = CDbl(table.ExtendedProperties("Dist"))

                    If (ThisClose(Dist, tabDist, OneCentimeter)) Then

                        If (1 < table.Rows.Count) Then

                            Dim row0 As DataRow = table.Rows(0)
                            Dim depth0 As Double = row0.Item(sDepthX)
                            Dim moist0 As Double = row0.Item(sMoistureX)
                            Dim conc0 As Double = row0.Item(sConcentrationXgpl)

                            For rdx As Integer = 1 To table.Rows.Count - 1

                                Dim row1 As DataRow = table.Rows(rdx)
                                Dim depth1 As Double = row1.Item(sDepthX)
                                Dim moist1 As Double = row1.Item(sMoistureX)
                                Dim conc1 As Double = row1.Item(sConcentrationXgpl)

                                HydrusDensity += (depth1 - depth0) * (0.6 * moist0 + 0.4 * moist1) * (conc0 + conc1) / 2.0

                                depth0 = depth1
                                moist0 = moist1
                                conc0 = conc1
                            Next
                        End If
                    End If
                End If
            Next
        End If
    End Function

    Public Function HydrusDensityTable() As DataTable
        HydrusDensityTable = Nothing

        Dim syncDists As DataTable = HydrusSyncDistances.Value
        If (syncDists IsNot Nothing) Then

            Dim width As Double = mUnit.SystemGeometryRef.Width.Value

            HydrusDensityTable = New DataTable("HYDRUS Application Density")
            HydrusDensityTable.Columns.Add(sDistanceX, GetType(Double))
            HydrusDensityTable.Columns.Add("Solute Density (g/m)", GetType(Double))

            For Each row As DataRow In syncDists.Rows
                Dim distance As Double = row.Item(sDistanceX)
                Dim soluteDensity As Double = Me.HydrusDensity(distance) * width

                Dim hydrusRow As DataRow = HydrusDensityTable.NewRow
                hydrusRow.Item(sDistanceX) = distance
                hydrusRow.Item("Solute Density (g/m)") = soluteDensity
                HydrusDensityTable.Rows.Add(hydrusRow)
            Next
        End If
    End Function

#End Region

#Region " Warrick / Green-Ampt "

    Public Const sSoilTextureSelectionWGA As String = "Soil Texture Selection WGA"

    Public ReadOnly Property SoilTextureSelectionWGA_Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSoilTextureSelectionWGA)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultSoilTextureSelection)
                mMyStore.AddProperty(sSoilTextureSelectionWGA, _integer)
                _propertyNode = mMyStore.GetProperty(sSoilTextureSelectionWGA)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SoilTextureSelectionWGA() As IntegerParameter
        Get
            Return SoilTextureSelectionWGA_Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            SoilTextureSelectionWGA_Property.SetParameter(Value)
        End Set
    End Property

    Private mSoilTextureSelectionWGAIndex As Integer = -1
    Public Function GetFirstSoilTextureSelectionWGA(ByRef _sel As String) As Boolean
        mSoilTextureSelectionWGAIndex = -1
        Return GetNextSoilTextureSelectionWGA(_sel)
    End Function

    Public Function GetNextSoilTextureSelectionWGA(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mSoilTextureSelectionWGAIndex += 1
        If (mSoilTextureSelectionWGAIndex <= Srfr.Infiltration.SoilTextures.Clay) Then
            _sel = SoilTextureSelections(mSoilTextureSelectionWGAIndex).Value
            If ((SoilTextureSelections(mSoilTextureSelectionWGAIndex).Flags And _flags) = 0) Then
                ' Selection is valid for World, User Level & Cross Section
                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function


    Public Const sSaturatedWaterContentWGA As String = "Saturated Water Content WGA"
    Public ReadOnly Property SaturatedWaterContentWGA_Property() As PropertyNode
        Get
            ' If not found; create it
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSaturatedWaterContentWGA)
            If (_propertyNode Is Nothing) Then
                Dim _soilTexture As Integer = DefaultSoilTextureSelection
                Dim _satWaterContent As Double = Srfr.Infiltration.SoilPropertiesTable(_soilTexture).EffectivePorosity
                Dim _double As DoubleParameter = New DoubleParameter(_satWaterContent, Units.CentimetersPerCentimeter)
                _double.Source = ValueSources.Defaulted
                mMyStore.AddProperty(sSaturatedWaterContentWGA, "ThetaS", _double)
                _propertyNode = mMyStore.GetProperty(sSaturatedWaterContentWGA)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SaturatedWaterContentWGA() As DoubleParameter
        Get
            Dim _doubleParameter As DoubleParameter = SaturatedWaterContentWGA_Property.GetDoubleParameter()
            Return _doubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            SaturatedWaterContentWGA_Property.SetParameter(Value)
        End Set
    End Property


    Public Const sInitialWaterContentWGA As String = "Initial Water Content WGA"
    Public ReadOnly Property InitialWaterContentWGA_Property() As PropertyNode
        Get
            ' If not found; create it
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInitialWaterContentWGA)
            If (_propertyNode Is Nothing) Then
                Dim _soilTexture As Integer = DefaultSoilTextureSelection
                Dim _initialWaterContent As Double = Srfr.Infiltration.SoilPropertiesTable(_soilTexture).InitialWaterContent
                Dim _double As DoubleParameter = New DoubleParameter(_initialWaterContent, Units.CentimetersPerCentimeter)
                _double.Source = ValueSources.Defaulted
                mMyStore.AddProperty(sInitialWaterContentWGA, "Theta0", _double)
                _propertyNode = mMyStore.GetProperty(sInitialWaterContentWGA)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InitialWaterContentWGA() As DoubleParameter
        Get
            Dim _doubleParameter As DoubleParameter = InitialWaterContentWGA_Property.GetDoubleParameter()
            Return _doubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            InitialWaterContentWGA_Property.SetParameter(Value)
        End Set
    End Property


    Public Const sWettingFrontPressureHeadWGA As String = "Wetting Front Pressure Head WGA"
    Public ReadOnly Property WettingFrontPressureHeadWGA_Property() As PropertyNode
        Get
            ' If not found; create it
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWettingFrontPressureHeadWGA)
            If (_propertyNode Is Nothing) Then
                Dim _soilTexture As Integer = DefaultSoilTextureSelection
                Dim _wettingFrontPressureHead As Double = Srfr.Infiltration.SoilPropertiesTable(_soilTexture).WettingFrontPressureHead
                Dim _double As DoubleParameter = New DoubleParameter(_wettingFrontPressureHead, Units.Millimeters)
                _double.Source = ValueSources.Defaulted
                mMyStore.AddProperty(sWettingFrontPressureHeadWGA, "hf", _double)
                _propertyNode = mMyStore.GetProperty(sWettingFrontPressureHeadWGA)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.CentimetersInchesUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property WettingFrontPressureHeadWGA() As DoubleParameter
        Get
            Dim _doubleParameter As DoubleParameter = WettingFrontPressureHeadWGA_Property.GetDoubleParameter()
            Return _doubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            WettingFrontPressureHeadWGA_Property.SetParameter(Value)
        End Set
    End Property


    Public Const sHydraulicConductivityWGA As String = "Hydraulic Conductivity WGA"
    Public ReadOnly Property HydraulicConductivityWGA_Property() As PropertyNode
        Get
            ' If not found; create it
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHydraulicConductivityWGA)
            If (_propertyNode Is Nothing) Then
                Dim _soilTexture As Integer = DefaultSoilTextureSelection
                Dim _hydraulicConductivity As Double = Srfr.Infiltration.SoilPropertiesTable(_soilTexture).HydraulicConductivity
                Dim _double As DoubleParameter = New DoubleParameter(_hydraulicConductivity, Units.MetersPerSecond)
                _double.Source = ValueSources.Defaulted
                mMyStore.AddProperty(sHydraulicConductivityWGA, "Ks", _double)
                _propertyNode = mMyStore.GetProperty(sHydraulicConductivityWGA)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.CentimetersInchesPerHourUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property HydraulicConductivityWGA() As DoubleParameter
        Get
            Dim _doubleParameter As DoubleParameter = HydraulicConductivityWGA_Property.GetDoubleParameter()
            Return _doubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            HydraulicConductivityWGA_Property.SetParameter(Value)
        End Set
    End Property


    Public Const sWarrickGreenAmptC As String = "Warrick Green-Ampt C"
    Public ReadOnly Property WarrickGreenAmptC_Property() As PropertyNode
        Get
            ' If not found; create it
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWarrickGreenAmptC)
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultKostiakovC, Units.Millimeters)
                mMyStore.AddProperty(sWarrickGreenAmptC, sc, _double)
                _propertyNode = mMyStore.GetProperty(sWarrickGreenAmptC)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.CentimetersInchesUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property WarrickGreenAmptC() As DoubleParameter
        Get
            Dim _doubleParameter As DoubleParameter = WarrickGreenAmptC_Property.GetDoubleParameter()
            Return _doubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            WarrickGreenAmptC_Property.SetParameter(Value)
        End Set
    End Property

    '*********************************************************************************************************
    Public Const sWarrickGreenAmptGamma As String = "Warrick Green-Ampt Gamma"

    Public ReadOnly Property WarrickGreenAmptGammaProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWarrickGreenAmptGamma)

            ' If Property was not found; create it
            If (_propertyNode Is Nothing) Then
                ' Property not found; create it
                Dim _parameter As DoubleParameter = New DoubleParameter(1.0, Units.None)
                mMyStore.AddProperty(sWarrickGreenAmptGamma, _parameter)
                _propertyNode = mMyStore.GetProperty(sWarrickGreenAmptGamma)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property WarrickGreenAmptGamma() As DoubleParameter
        Get
            Return WarrickGreenAmptGammaProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            WarrickGreenAmptGammaProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#End Region

#Region " Limiting Depth "

    Public Const sEnableLimitingDepth As String = "Enable Limiting Depth"

    Public ReadOnly Property EnableLimitingDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableLimitingDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultEnableLimitingDepth)
                mMyStore.AddProperty(sEnableLimitingDepth, _boolean)
                _propertyNode = mMyStore.GetProperty(sEnableLimitingDepth)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableLimitingDepth() As BooleanParameter
        Get
            Dim enable As BooleanParameter = EnableLimitingDepthProperty.GetBooleanParameter()

            ' Simulation World only
            If Not (mUnit.WorldRef.WorldType.Value = WorldTypes.SimulationWorld) Then
                enable.Value = False
            End If

            ' Not available to Standard Users
            If (WinSRFR.UserLevel = UserLevels.Standard) Then
                enable.Value = False
            End If

            Return enable
        End Get
        Set(ByVal Value As BooleanParameter)
            EnableLimitingDepthProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sLimitingDepth As String = "Limiting Depth"

    Public ReadOnly Property LimitingDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sLimitingDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultLimitingDepth, Units.Millimeters)
                mMyStore.AddProperty(sLimitingDepth, _double)
                _propertyNode = mMyStore.GetProperty(sLimitingDepth)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property LimitingDepth() As DoubleParameter
        Get
            Dim limit As DoubleParameter = LimitingDepthProperty.GetDoubleParameter()

            ' Simulation World only
            If Not (mUnit.WorldRef.WorldType.Value = WorldTypes.SimulationWorld) Then
                limit.Value = 0.0
            End If

            ' Not available to Standard Users
            If (WinSRFR.UserLevel = UserLevels.Standard) Then
                limit.Value = 0.0
            End If

            Return limit
        End Get
        Set(ByVal Value As DoubleParameter)
            LimitingDepthProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Tabulated Infiltration "

#Region " Enable "

    Public Const sEnableTabulatedInfiltration As String = "Enable Tabulated Infiltration"

    Public ReadOnly Property EnableTabulatedInfiltrationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableTabulatedInfiltration)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultEnableTabulatedInfiltration)
                mMyStore.AddProperty(sEnableTabulatedInfiltration, _boolean)
                _propertyNode = mMyStore.GetProperty(sEnableTabulatedInfiltration)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableTabulatedInfiltration() As BooleanParameter
        Get
            Return EnableTabulatedInfiltrationProperty.GetBooleanParameter()
        End Get
        Set(ByVal Value As BooleanParameter)
            EnableTabulatedInfiltrationProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Characteristic Infiltration Time "

    Public Const sKnownTimeTable As String = "Known Time Table"
    Public Const sCharacteristicTimeTime As String = "Characteristic Time Table"

    Public ReadOnly Property CharacteristicTimeTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCharacteristicTimeTime)

            ' If it was not found; check deprecated name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sKnownTimeTable)

                ' If deprecated name was found; update it
                If (_propertyNode IsNot Nothing) Then
                    _propertyNode.MyID = sCharacteristicTimeTime
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim charTimeDataTable As DataTable = New DataTable(sCharacteristicTimeTime)

                ResetCharacteristicTimeTable(charTimeDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(charTimeDataTable)
                mMyStore.AddProperty(sCharacteristicTimeTime, _parameter)
                _propertyNode = mMyStore.GetProperty(sCharacteristicTimeTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CharacteristicTimeTable() As DataTableParameter
        Get
            Return CharacteristicTimeTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            CharacteristicTimeTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetCharacteristicTimeTable(ByVal charTimeDataTable As DataTable)

        ' Remove the previous data
        charTimeDataTable.Clear()          ' Clear rows
        charTimeDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        charTimeDataTable.Columns.Add(sDistanceX, GetType(Double))
        charTimeDataTable.Columns.Add(Srfr.Globals.sCharDepth, GetType(Double))
        charTimeDataTable.Columns.Add(Srfr.Globals.sCharTime, GetType(Double))
        charTimeDataTable.Columns.Add(Srfr.Globals.sA, GetType(Double))
        charTimeDataTable.Columns.Add(Srfr.Globals.sLimit, GetType(Double))

        ' Add the row(s) of reset data
        Dim charTimeRow As DataRow = charTimeDataTable.NewRow
        charTimeRow.Item(sDistanceX) = 0.0
        charTimeRow.Item(Srfr.Globals.sCharDepth) = DefaultInfiltrationDepth
        charTimeRow.Item(Srfr.Globals.sCharTime) = DefaultInfiltrationTime
        charTimeRow.Item(Srfr.Globals.sA) = DefaultKostiakovA
        charTimeRow.Item(Srfr.Globals.sLimit) = DefaultLimitingDepth

        charTimeDataTable.Rows.Add(charTimeRow)

    End Sub

#End Region

#Region " Time Rated Intake Family "

    '*********************************************************************************************************
    Public Const sTimeRatedTable As String = "Time Rated Table"

    Public ReadOnly Property TimeRatedTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTimeRatedTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim timeRatedDataTable As DataTable = New DataTable(sTimeRatedTable)

                ResetTimeRatedTable(timeRatedDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(timeRatedDataTable)
                mMyStore.AddProperty(sTimeRatedTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sTimeRatedTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property TimeRatedTable() As DataTableParameter
        Get
            Return TimeRatedTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            TimeRatedTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetTimeRatedTable(ByVal timeRatedDataTable As DataTable)

        ' Remove the previous data
        timeRatedDataTable.Clear()          ' Clear rows
        timeRatedDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        timeRatedDataTable.Columns.Add(sDistanceX, GetType(Double))
        timeRatedDataTable.Columns.Add(Srfr.Globals.sCorrTime, GetType(Double))
        timeRatedDataTable.Columns.Add(Srfr.Globals.sLimit, GetType(Double))

        ' Add the row(s) of reset data
        Dim timeRatedRow As DataRow = timeRatedDataTable.NewRow
        timeRatedRow.Item(sDistanceX) = 0.0
        timeRatedRow.Item(Srfr.Globals.sCorrTime) = DefaultInfiltrationTime
        timeRatedRow.Item(Srfr.Globals.sLimit) = DefaultLimitingDepth

        timeRatedDataTable.Rows.Add(timeRatedRow)

    End Sub

#End Region

#Region " NRCS Intake Family "

    '*********************************************************************************************************
    Public Const sNrcsIntakeTable As String = "NRCS Intake Table"

    Public ReadOnly Property NrcsIntakeTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNrcsIntakeTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim timeRatedDataTable As DataTable = New DataTable(sNrcsIntakeTable)

                ResetNrcsIntakeTable(timeRatedDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(timeRatedDataTable)
                mMyStore.AddProperty(sNrcsIntakeTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sNrcsIntakeTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property NrcsIntakeTable() As DataTableParameter
        Get
            Return NrcsIntakeTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            NrcsIntakeTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetNrcsIntakeTable(ByVal timeRatedDataTable As DataTable)

        ' Remove the previous data
        timeRatedDataTable.Clear()          ' Clear rows
        timeRatedDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        timeRatedDataTable.Columns.Add(sDistanceX, GetType(Double))
        timeRatedDataTable.Columns.Add(Srfr.Globals.sNrcsFamily, GetType(String))
        timeRatedDataTable.Columns.Add(Srfr.Globals.sLimit, GetType(Double))

        ' Add the row(s) of reset data
        Dim timeRatedRow As DataRow = timeRatedDataTable.NewRow
        timeRatedRow.Item(sDistanceX) = 0.0
        timeRatedRow.Item(Srfr.Globals.sNrcsFamily) = DefaultNrcsSelection
        timeRatedRow.Item(Srfr.Globals.sLimit) = DefaultLimitingDepth

        timeRatedDataTable.Rows.Add(timeRatedRow)

    End Sub

#End Region

#Region " Kostiakov Formula "

    '*********************************************************************************************************
    Public Const sKostiakovTable As String = "Kostiakov Table"

    Public ReadOnly Property KostiakovTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKostiakovTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim kostiakovDataTable As DataTable = New DataTable(sKostiakovTable)

                ResetKostiakovTable(kostiakovDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(kostiakovDataTable)
                mMyStore.AddProperty(sKostiakovTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sKostiakovTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KostiakovTable() As DataTableParameter
        Get
            Return KostiakovTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            KostiakovTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetKostiakovTable(ByVal kostiakovDataTable As DataTable)

        ' Remove the previous data
        kostiakovDataTable.Clear()          ' Clear rows
        kostiakovDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        kostiakovDataTable.Columns.Add(sDistanceX, GetType(Double))
        kostiakovDataTable.Columns.Add(Srfr.Globals.sK, GetType(Double))
        kostiakovDataTable.Columns.Add(Srfr.Globals.sA, GetType(Double))
        kostiakovDataTable.Columns.Add(Srfr.Globals.sLimit, GetType(Double))

        ' Add the row(s) of reset data
        Dim kostiakovRow As DataRow = kostiakovDataTable.NewRow
        kostiakovRow.Item(sDistanceX) = 0.0
        kostiakovRow.Item(Srfr.Globals.sK) = DefaultKostiakovK
        kostiakovRow.Item(Srfr.Globals.sA) = DefaultKostiakovA
        kostiakovRow.Item(Srfr.Globals.sLimit) = DefaultLimitingDepth

        kostiakovDataTable.Rows.Add(kostiakovRow)

    End Sub

#End Region

#Region " Modified Kostiakov Formula "

    '*********************************************************************************************************
    Public Const sModifiedKostiakovTable As String = "Modified Kostiakov Table"

    Public ReadOnly Property ModifiedKostiakovTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sModifiedKostiakovTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim kostiakovDataTable As DataTable = New DataTable(sModifiedKostiakovTable)

                ResetModifiedKostiakovTable(kostiakovDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(kostiakovDataTable)
                mMyStore.AddProperty(sModifiedKostiakovTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sModifiedKostiakovTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ModifiedKostiakovTable() As DataTableParameter
        Get
            Return ModifiedKostiakovTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            ModifiedKostiakovTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetModifiedKostiakovTable(ByVal kostiakovDataTable As DataTable)

        ' Remove the previous data
        kostiakovDataTable.Clear()          ' Clear rows
        kostiakovDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        kostiakovDataTable.Columns.Add(sDistanceX, GetType(Double))
        kostiakovDataTable.Columns.Add(Srfr.Globals.sK, GetType(Double))
        kostiakovDataTable.Columns.Add(Srfr.Globals.sA, GetType(Double))
        kostiakovDataTable.Columns.Add(Srfr.Globals.sB, GetType(Double))
        kostiakovDataTable.Columns.Add(Srfr.Globals.sC, GetType(Double))
        kostiakovDataTable.Columns.Add(Srfr.Globals.sLimit, GetType(Double))

        ' Add the row(s) of reset data
        Dim kostiakovRow As DataRow = kostiakovDataTable.NewRow
        kostiakovRow.Item(sDistanceX) = 0.0
        kostiakovRow.Item(Srfr.Globals.sK) = DefaultKostiakovK
        kostiakovRow.Item(Srfr.Globals.sA) = DefaultKostiakovA
        kostiakovRow.Item(Srfr.Globals.sB) = DefaultKostiakovB
        kostiakovRow.Item(Srfr.Globals.sC) = DefaultKostiakovC
        kostiakovRow.Item(Srfr.Globals.sLimit) = DefaultLimitingDepth

        kostiakovDataTable.Rows.Add(kostiakovRow)

    End Sub

#End Region

#Region " Branch Formula "

    '*********************************************************************************************************
    Public Const sBranchFunctionTable As String = "Branch Function Table"

    Public ReadOnly Property BranchFunctionTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sBranchFunctionTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim branchDataTable As DataTable = New DataTable(sBranchFunctionTable)

                ResetBranchFunctionTable(branchDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(branchDataTable)
                mMyStore.AddProperty(sBranchFunctionTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sBranchFunctionTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property BranchFunctionTable() As DataTableParameter
        Get
            Return BranchFunctionTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            BranchFunctionTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetBranchFunctionTable(ByVal branchDataTable As DataTable)

        ' Remove the previous data
        branchDataTable.Clear()          ' Clear rows
        branchDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        branchDataTable.Columns.Add(sDistanceX, GetType(Double))
        branchDataTable.Columns.Add(Srfr.Globals.sK, GetType(Double))
        branchDataTable.Columns.Add(Srfr.Globals.sA, GetType(Double))
        branchDataTable.Columns.Add(Srfr.Globals.sB, GetType(Double))
        branchDataTable.Columns.Add(Srfr.Globals.sC, GetType(Double))
        branchDataTable.Columns.Add(Srfr.Globals.sLimit, GetType(Double))

        ' Add the row(s) of reset data
        Dim branchRow As DataRow = branchDataTable.NewRow
        branchRow.Item(sDistanceX) = 0.0
        branchRow.Item(Srfr.Globals.sK) = DefaultKostiakovK
        branchRow.Item(Srfr.Globals.sA) = DefaultKostiakovA
        branchRow.Item(Srfr.Globals.sB) = DefaultBranchB
        branchRow.Item(Srfr.Globals.sC) = DefaultKostiakovC
        branchRow.Item(Srfr.Globals.sLimit) = DefaultLimitingDepth

        branchDataTable.Rows.Add(branchRow)

    End Sub

#End Region

#Region " Green-Ampt "

    '*********************************************************************************************************
    Public Const sGreenAmptTable As String = "Green Ampt Table"

    Public ReadOnly Property GreenAmptTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGreenAmptTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim greenAmptDataTable As DataTable = New DataTable(sGreenAmptTable)

                ResetGreenAmptTable(greenAmptDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(greenAmptDataTable)
                mMyStore.AddProperty(sGreenAmptTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sGreenAmptTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property GreenAmptTable() As DataTableParameter
        Get
            Return GreenAmptTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            GreenAmptTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetGreenAmptTable(ByVal greenAmptDataTable As DataTable)

        ' Remove the previous data
        greenAmptDataTable.Clear()          ' Clear rows
        greenAmptDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        greenAmptDataTable.Columns.Add(sDistanceX, GetType(Double))
        greenAmptDataTable.Columns.Add(Srfr.Globals.sPhi, GetType(Double))
        greenAmptDataTable.Columns.Add(Srfr.Globals.sTheta0, GetType(Double))
        greenAmptDataTable.Columns.Add(Srfr.Globals.sHf, GetType(Double))
        greenAmptDataTable.Columns.Add(Srfr.Globals.sKs, GetType(Double))
        greenAmptDataTable.Columns.Add(Srfr.Globals.sC, GetType(Double))
        greenAmptDataTable.Columns.Add(Srfr.Globals.sLimit, GetType(Double))

        ' Add the row(s) of reset data
        Dim texture As Integer = DefaultSoilTextureSelection
        Dim soilProperties As Srfr.Infiltration.SoilProperties = Srfr.Infiltration.SoilPropertiesTable(texture)

        Dim greenAmptRow As DataRow = greenAmptDataTable.NewRow
        greenAmptRow.Item(sDistanceX) = 0.0
        greenAmptRow.Item(Srfr.Globals.sPhi) = soilProperties.EffectivePorosity
        greenAmptRow.Item(Srfr.Globals.sTheta0) = soilProperties.InitialWaterContent
        greenAmptRow.Item(Srfr.Globals.sHf) = soilProperties.WettingFrontPressureHead
        greenAmptRow.Item(Srfr.Globals.sKs) = soilProperties.HydraulicConductivity
        greenAmptRow.Item(Srfr.Globals.sC) = 0.0
        greenAmptRow.Item(Srfr.Globals.sLimit) = DefaultLimitingDepth

        greenAmptDataTable.Rows.Add(greenAmptRow)

    End Sub

#End Region

#Region " HYDRUS "

    '*********************************************************************************************************
    Public Const sHydrusProjectTable As String = "HYDRUS Project Table"

    Public ReadOnly Property HydrusProjectTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHydrusProjectTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim hydrusProjectDataTable As DataTable = New DataTable(sHydrusProjectTable)

                ResetHydrusProjectTable(hydrusProjectDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(hydrusProjectDataTable)
                mMyStore.AddProperty(sHydrusProjectTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusProjectTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property HydrusProjectTable() As DataTableParameter
        Get
            Return HydrusProjectTableProperty.GetDataTableParameter
        End Get
        Set(ByVal value As DataTableParameter)
            HydrusProjectTableProperty.SetParameter(value)
        End Set
    End Property

    Public Sub ResetHydrusProjectTable(ByVal hydrusProjectTable As DataTable)

        ' Remove the previous data
        hydrusProjectTable.Clear()          ' Clear rows
        hydrusProjectTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        hydrusProjectTable.Columns.Add(sDistanceX, GetType(Double))
        hydrusProjectTable.Columns.Add(Srfr.Hydrus.sHydrusProject, GetType(String))

        ' Add the row(s) of reset data
        Dim hydrusRow As DataRow = hydrusProjectTable.NewRow
        hydrusRow.Item(sDistanceX) = 0.0
        hydrusRow.Item(Srfr.Hydrus.sHydrusProject) = "<-- " & DefaultHydrusRowFilename

        hydrusProjectTable.Rows.Add(hydrusRow)

    End Sub

    Public Function TabulatedHydrusDistances() As List(Of Double)

        TabulatedHydrusDistances = New List(Of Double)

        If (Me.EnableTabulatedInfiltration.Value) Then

            Select Case (Me.InfiltrationFunction.Value)

                Case InfiltrationFunctions.Hydrus1D

                    Dim table As DataTable = Me.HydrusProjectTable.Value
                    If (table IsNot Nothing) Then
                        For Each row As DataRow In table.Rows
                            TabulatedHydrusDistances.Add(CDbl(row(sDistanceX)))
                        Next
                    End If
            End Select
        End If

        If (0 = TabulatedHydrusDistances.Count) Then
            TabulatedHydrusDistances = Nothing
        End If

    End Function

#End Region

#Region " Warrick Green-Ampt "

    '*********************************************************************************************************
    Public Const sWarrickGreenAmptTable As String = "Warrick Green Ampt Table"

    Public ReadOnly Property WarrickGreenAmptTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWarrickGreenAmptTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _table As DataTable = New DataTable(sWarrickGreenAmptTable)

                ResetWarrickGreenAmptTable(_table)

                Dim _parameter As DataTableParameter = New DataTableParameter(_table)
                mMyStore.AddProperty(sWarrickGreenAmptTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sWarrickGreenAmptTable)
            Else
                Dim _parameter As Parameter = _propertyNode.GetParameter
                Dim _tableParam As DataTableParameter = DirectCast(_parameter, DataTableParameter)
                Dim _table As DataTable = _tableParam.Value

                If Not (_table.Columns.Contains(Srfr.Globals.sGamma)) Then
                    ResetWarrickGreenAmptTable(_table)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property WarrickGreenAmptTable() As DataTableParameter
        Get
            Return WarrickGreenAmptTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            WarrickGreenAmptTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetWarrickGreenAmptTable(ByVal warrickGreenAmptDataTable As DataTable)

        ' Remove the previous data
        warrickGreenAmptDataTable.Clear()          ' Clear rows
        warrickGreenAmptDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        warrickGreenAmptDataTable.Columns.Add(sDistanceX, GetType(Double))
        warrickGreenAmptDataTable.Columns.Add(Srfr.Globals.sThetaS, GetType(Double))
        warrickGreenAmptDataTable.Columns.Add(Srfr.Globals.sTheta0, GetType(Double))
        warrickGreenAmptDataTable.Columns.Add(Srfr.Globals.sHf, GetType(Double))
        warrickGreenAmptDataTable.Columns.Add(Srfr.Globals.sKs, GetType(Double))
        warrickGreenAmptDataTable.Columns.Add(Srfr.Globals.sC, GetType(Double))
        warrickGreenAmptDataTable.Columns.Add(Srfr.Globals.sGamma, GetType(Double))

        warrickGreenAmptDataTable.Columns.Add(Srfr.Globals.sLimit, GetType(Double))

        ' Add the row(s) of reset data
        Dim texture As Integer = DefaultSoilTextureSelection
        Dim soilProperties As Srfr.Infiltration.SoilProperties = Srfr.Infiltration.SoilPropertiesTable(texture)

        Dim warrickGreenAmptRow As DataRow = warrickGreenAmptDataTable.NewRow
        warrickGreenAmptRow.Item(sDistanceX) = 0.0
        warrickGreenAmptRow.Item(Srfr.Globals.sThetaS) = soilProperties.EffectivePorosity
        warrickGreenAmptRow.Item(Srfr.Globals.sTheta0) = soilProperties.InitialWaterContent
        warrickGreenAmptRow.Item(Srfr.Globals.sHf) = soilProperties.WettingFrontPressureHead
        warrickGreenAmptRow.Item(Srfr.Globals.sKs) = soilProperties.HydraulicConductivity
        warrickGreenAmptRow.Item(Srfr.Globals.sC) = 0.0
        warrickGreenAmptRow.Item(Srfr.Globals.sGamma) = 1.0
        warrickGreenAmptRow.Item(Srfr.Globals.sLimit) = DefaultLimitingDepth

        warrickGreenAmptDataTable.Rows.Add(warrickGreenAmptRow)

    End Sub

#End Region

#End Region

#Region " NRCS to Kostiakov Method "

    Public Const sNrcsToKostiakovMethod As String = "NrcsToKostiakov Method"

    Public ReadOnly Property NrcsToKostiakovMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNrcsToKostiakovMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultNrcsToKostiakovMethod)
                mMyStore.AddProperty(sNrcsToKostiakovMethod, _integer)
                _propertyNode = mMyStore.GetProperty(sNrcsToKostiakovMethod)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property NrcsToKostiakovMethod() As IntegerParameter
        Get
            Dim nrcsMethod As IntegerParameter = NrcsToKostiakovMethodProperty.GetIntegerParameter()

            If (WinSRFR.UserLevel = UserLevels.Standard) Then
                nrcsMethod.Value = NrcsToKostiakovMethods.DescribeByNrcsFormula
            End If

            Return nrcsMethod
        End Get
        Set(ByVal Value As IntegerParameter)
            NrcsToKostiakovMethodProperty.SetParameter(Value)
        End Set
    End Property

    Private mNrcsToKostiakovMethodIndex As Integer = -1
    Public Function GetFirstNrcsToKostiakovMethodSelection() As String
        mNrcsToKostiakovMethodIndex = -1
        Return GetNextNrcsToKostiakovMethodSelection()
    End Function

    Public Function GetNextNrcsToKostiakovMethodSelection() As String
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)
        mNrcsToKostiakovMethodIndex += 1
        If (mNrcsToKostiakovMethodIndex < NrcsToKostiakovMethods.HighLimit) Then
            If ((NrcsToKostiakovMethodSelections(mNrcsToKostiakovMethodIndex).Flags And _flags) = 0) Then
                Return NrcsToKostiakovMethodSelections(mNrcsToKostiakovMethodIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function

#End Region

#End Region

#Region " Roughness Properties "

#Region " Roughness Method "

    Public Const sRoughnessMethod As String = "Roughness Method"

    Public ReadOnly Property RoughnessMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRoughnessMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultRoughnessMethod)
                mMyStore.AddProperty(sRoughnessMethod, _integer)
                _propertyNode = mMyStore.GetProperty(sRoughnessMethod)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _integer As IntegerParameter = DirectCast(_param, IntegerParameter)

                ' Manning n & NRCS Suggested Manning n have been combined in version 4.1
                If (_integer.Value = RoughnessMethods.ManningN) Then
                    _integer.Value = RoughnessMethods.NrcsSuggestedManningN

                    ' Set NRCS Suggested enum to 'User Entered'
                    _param = NrcsSuggestedManningNProperty.GetParameter
                    _integer = DirectCast(_param, IntegerParameter)
                    _integer.Value = Globals.NrcsSuggestedManningN.UserEntered
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property RoughnessMethod() As IntegerParameter
        Get
            Dim roughness As IntegerParameter = RoughnessMethodProperty.GetIntegerParameter()

            If (WinSRFR.UserLevel = UserLevels.Standard) Then ' Standard uses only Manning n
                Select Case (roughness.Value)
                    Case RoughnessMethods.ManningCnAn, RoughnessMethods.SayreAlbertson
                        roughness.Value = RoughnessMethods.NrcsSuggestedManningN
                End Select
            End If

            Return roughness
        End Get
        Set(ByVal Value As IntegerParameter)
            RoughnessMethodProperty.SetParameter(Value)
        End Set
    End Property

    Private mRoughnessMethodIndex As Integer = -1
    Public Function GetFirstRoughnessMethodSelection(ByRef _sel As String) As Boolean
        mRoughnessMethodIndex = -1
        Return GetNextRoughnessMethodSelection(_sel)
    End Function

    Public Function GetNextRoughnessMethodSelection(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        If (_worldType = WorldTypes.EventWorld) Then
            ' The Event Analysis World's erosion analysis supports all roughness methods
            If (mUnit.EventCriteriaRef.EventAnalysisType.Value = EventAnalysisTypes.ErosionAnalysis) Then
                _worldType = WorldTypes.SimulationWorld
            End If
        End If

        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mRoughnessMethodIndex += 1
        If (mRoughnessMethodIndex < RoughnessMethods.HighLimit) Then
            _sel = RoughnessMethodSelections(mRoughnessMethodIndex).Value
            If ((RoughnessMethodSelections(mRoughnessMethodIndex).Flags And _flags) = 0) Then
                ' Selection is valid for World, User Level & Cross Section
                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function

#End Region

#Region " Roughness Values "
    '
    ' In earlier versions, Manning n was directly entered or was selected from a set of radio buttons
    ' where the value selected by the radio buttons over-wrote the entered value.  Both were stored in
    ' the ManningNProperty which was/is used throughout WinSRFR as the value of Manning n.
    '
    ' Now, both the radio button value and the entered value are retained.  To accomplish this, three
    ' properties now exist:
    '
    '   1) NrcsSuggestedManningNProperty    - value selected via radio buttons
    '   2) UsersManningNProperty            - value entered directly be user
    '   3) ManningNProperty                 - the original version
    '
    ' The 1st two properties are changed via the UI while the last version is updated by the 1st two.
    ' The WinSRFR code still uses the last version as the value of Manning n.
    '
    Public Const sNrcsSuggestedManningN As String = "NRCS Suggested Manning N"

    Public ReadOnly Property NrcsSuggestedManningNProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNrcsSuggestedManningN)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultNrcsSuggestedManningN)
                mMyStore.AddProperty(sNrcsSuggestedManningN, _integer)
                _propertyNode = mMyStore.GetProperty(sNrcsSuggestedManningN)
            End If

            _propertyNode.ClearEnums()

            For _idx As Integer = 0 To NrcsSuggestedManningNValues.Length - 1
                Dim _value As Double = NrcsSuggestedManningNValues(_idx)
                _propertyNode.AddEnumItem(_value.ToString, _idx, True)
            Next

            Return _propertyNode
        End Get
    End Property

    Public Property NrcsSuggestedManningN() As IntegerParameter
        Get
            Return NrcsSuggestedManningNProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            NrcsSuggestedManningNProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sManningN As String = "Manning N"

    Public ReadOnly Property ManningNProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sManningN)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(Srfr.Ndef, Units.None)
                _double.MinValue = mWinSRFR.Nmin
                _double.MaxValue = mWinSRFR.Nmax
                mMyStore.AddProperty(sManningN, Srfr.ManningN.sN, _double)
                _propertyNode = mMyStore.GetProperty(sManningN)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = mWinSRFR.Nmin
                _double.MaxValue = mWinSRFR.Nmax

                Dim nrcsSuggestion As NrcsSuggestedManningN = Me.NrcsSuggestedManningN.Value
                If (nrcsSuggestion = Globals.NrcsSuggestedManningN.UserEntered) Then ' load user-entered Manning n
                    _double.Value = Me.UsersManningN.Value
                Else ' load NRCS suggested Manning n
                    _double.Value = NrcsSuggestedManningNValues(nrcsSuggestion)
                End If

            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ManningN() As DoubleParameter
        Get
            Return ManningNProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ManningNProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sUsersManningN As String = "User's Manning N"
    Public Const sUserEnteredManningN As String = "User Entered Manning N"

    Public ReadOnly Property UsersManningNProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sUserEnteredManningN)

            ' If not found; try deprecated name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sUsersManningN)

                ' If deprecated name was found; update it
                If (_propertyNode IsNot Nothing) Then
                    _propertyNode.MyID = sUserEnteredManningN
                End If
            End If

            ' If still not found; create it
            If (_propertyNode Is Nothing) Then
                '
                ' Default User Entered Manning N comes from Manning N
                '
                ' Manning N was user entered value in WinSRFR 3.1 
                '
                Dim _default As Double = ManningN.Value
                Dim _double As DoubleParameter = New DoubleParameter(_default, Units.None)
                _double.MinValue = mWinSRFR.Nmin
                _double.MaxValue = mWinSRFR.Nmax
                mMyStore.AddProperty(sUserEnteredManningN, Srfr.ManningN.sN, _double)
                _propertyNode = mMyStore.GetProperty(sUserEnteredManningN)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = mWinSRFR.Nmin
                _double.MaxValue = mWinSRFR.Nmax
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property UsersManningN() As DoubleParameter
        Get
            Return UsersManningNProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            UsersManningNProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sManningCn As String = "Manning Cn"

    Public ReadOnly Property ManningCnProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sManningCn)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(Srfr.CnDef, Units.None)
                _double.MinValue = mWinSRFR.CnMin
                _double.MaxValue = mWinSRFR.CnMax
                mMyStore.AddProperty(sManningCn, Srfr.ManningCnAn.sCn, _double)
                _propertyNode = mMyStore.GetProperty(sManningCn)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = mWinSRFR.CnMin
                _double.MaxValue = mWinSRFR.CnMax
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ManningCn() As DoubleParameter
        Get
            Return ManningCnProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ManningCnProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sManningAn As String = "Manning An"

    Public ReadOnly Property ManningAnProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sManningAn)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(Srfr.AnDef, Units.None)
                _double.MinValue = mWinSRFR.AnMin
                _double.MaxValue = mWinSRFR.AnMax
                mMyStore.AddProperty(sManningAn, Srfr.ManningCnAn.sAn, _double)
                _propertyNode = mMyStore.GetProperty(sManningAn)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.MinValue = mWinSRFR.AnMin
                _double.MaxValue = mWinSRFR.AnMax
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ManningAn() As DoubleParameter
        Get
            Return ManningAnProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ManningAnProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sManningRange As String = "Manning Range"

    Public ReadOnly Property ManningRangeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sManningRange)
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(Srfr.Ninc, Units.Millimeters)
                mMyStore.AddProperty(sManningRange, _double)
                _propertyNode = mMyStore.GetProperty(sManningRange)
            End If
            Return _propertyNode
        End Get
    End Property

    Public Property ManningRange() As DoubleParameter
        Get
            Return ManningRangeProperty.GetDoubleParameter()
        End Get
        Set(ByVal value As DoubleParameter)
            ManningRangeProperty.SetParameter(value)
        End Set
    End Property


    Public Const sSayreChi As String = "Sayre Albertson Chi"
    Public Const sChi As String = "Chi"

    Public ReadOnly Property SayreChiProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSayreChi)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(Srfr.ChiDef, Units.Millimeters)
                _double.MinValue = mWinSRFR.ChiMin
                _double.MaxValue = mWinSRFR.ChiMax
                mMyStore.AddProperty(sSayreChi, sChi, _double)
                _propertyNode = mMyStore.GetProperty(sSayreChi)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.Units = Units.Millimeters
                _double.MinValue = mWinSRFR.ChiMin
                _double.MaxValue = mWinSRFR.ChiMax
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SayreChi() As DoubleParameter
        Get
            Return SayreChiProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SayreChiProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sChiRange As String = "Chi Range"

    Public ReadOnly Property ChiRangeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sChiRange)
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(Srfr.ChiInc, Units.Millimeters)
                mMyStore.AddProperty(sChiRange, _double)
                _propertyNode = mMyStore.GetProperty(sChiRange)
            End If
            Return _propertyNode
        End Get
    End Property

    Public Property ChiRange() As DoubleParameter
        Get
            Return ChiRangeProperty.GetDoubleParameter()
        End Get
        Set(ByVal value As DoubleParameter)
            ChiRangeProperty.SetParameter(value)
        End Set
    End Property

#End Region

#Region " Vegetative Density "

    Public Const sEnableVegetativeDensity As String = "Enable Vegetative Density"

    Public ReadOnly Property EnableVegetativeDensityProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableVegetativeDensity)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultEnableVegetativeDensity)
                mMyStore.AddProperty(sEnableVegetativeDensity, _boolean)
                _propertyNode = mMyStore.GetProperty(sEnableVegetativeDensity)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableVegetativeDensity() As BooleanParameter
        Get
            Dim density As BooleanParameter = EnableVegetativeDensityProperty.GetBooleanParameter()

            ' Only for Researchers
            If Not (WinSRFR.IsResearchLevel) Then
                density.Value = False
            End If

            ' Only for Simulation World
            If Not (mUnit.WorldRef.WorldType.Value = WorldTypes.SimulationWorld) Then
                density.Value = False
            End If

            Return density
        End Get
        Set(ByVal Value As BooleanParameter)
            EnableVegetativeDensityProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sVegetativeDensity As String = "Vegetative Density"

    Public ReadOnly Property VegetativeDensityProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sVegetativeDensity)
            '
            ' If it was not found; create it
            '
            ' Units were changed from None to PerMeter in version 4.1; update old values accordingly
            '
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(Srfr.VegDensityDef, Units.PerMeter)
                mMyStore.AddProperty(sVegetativeDensity, _double)
                _propertyNode = mMyStore.GetProperty(sVegetativeDensity)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                _double.Units = Units.PerMeter
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property VegetativeDensity() As DoubleParameter
        Get
            Dim density As DoubleParameter = VegetativeDensityProperty.GetDoubleParameter()

            If Not (WinSRFR.IsResearchLevel) Then
                density.Value = 0.0
            End If

            Return density
        End Get
        Set(ByVal Value As DoubleParameter)
            VegetativeDensityProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Tabulated Roughness "

    Public Const sEnableTabulatedRoughness As String = "Enable Tabulated Roughness"

    Public ReadOnly Property EnableTabulatedRoughnessProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableTabulatedRoughness)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultEnableTabulatedRoughness)
                mMyStore.AddProperty(sEnableTabulatedRoughness, _boolean)
                _propertyNode = mMyStore.GetProperty(sEnableTabulatedRoughness)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableTabulatedRoughness() As BooleanParameter
        Get
            Dim tabulated As BooleanParameter = EnableTabulatedRoughnessProperty.GetBooleanParameter()

            ' Not for Standard Users
            If (WinSRFR.UserLevel = UserLevels.Standard) Then
                tabulated.Value = False
            End If

            Return tabulated
        End Get
        Set(ByVal Value As BooleanParameter)
            EnableTabulatedRoughnessProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Roughness Tables
    '
    Public Const sManningNTable As String = "Manning n Table"

    Public ReadOnly Property ManningNTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sManningNTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim manningNDataTable As DataTable = New DataTable(sManningNTable)

                ResetManningNTable(manningNDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(manningNDataTable)
                mMyStore.AddProperty(sManningNTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sManningNTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ManningNTable() As DataTableParameter
        Get
            Return ManningNTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            ManningNTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetManningNTable(ByVal manningNDataTable As DataTable)

        ' Remove the previous data
        manningNDataTable.Clear()          ' Clear rows
        manningNDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        manningNDataTable.Columns.Add(sDistanceX, GetType(Double))
        manningNDataTable.Columns.Add(Srfr.ManningN.sN, GetType(Double))
        manningNDataTable.Columns.Add(Srfr.Roughness.sVegDensityM, GetType(Double))

        ' Add the row(s) of reset data
        Dim manningNRow As DataRow = manningNDataTable.NewRow
        manningNRow.Item(sDistanceX) = 0.0
        manningNRow.Item(Srfr.ManningN.sN) = Srfr.Ndef
        manningNRow.Item(Srfr.Roughness.sVegDensityM) = Srfr.VegDensityDef

        manningNDataTable.Rows.Add(manningNRow)

    End Sub

    '*********************************************************************************************************
    Public Const sManningCnAnTable As String = "Manning Cn/An Table"

    Public ReadOnly Property ManningCnAnTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sManningCnAnTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim manningCnAnDataTable As DataTable = New DataTable(sManningCnAnTable)

                ResetManningCnAnTable(manningCnAnDataTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(manningCnAnDataTable)
                mMyStore.AddProperty(sManningCnAnTable, _parameter)
                _propertyNode = mMyStore.GetProperty(sManningCnAnTable)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ManningCnAnTable() As DataTableParameter
        Get
            Return ManningCnAnTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            ManningCnAnTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetManningCnAnTable(ByVal manningCnAnDataTable As DataTable)

        ' Remove the previous data
        manningCnAnDataTable.Clear()          ' Clear rows
        manningCnAnDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        manningCnAnDataTable.Columns.Add(sDistanceX, GetType(Double))
        manningCnAnDataTable.Columns.Add(Srfr.ManningCnAn.sCn, GetType(Double))
        manningCnAnDataTable.Columns.Add(Srfr.ManningCnAn.sAn, GetType(Double))
        manningCnAnDataTable.Columns.Add(Srfr.Roughness.sVegDensityM, GetType(Double))

        ' Add the row(s) of reset data
        Dim manningCnAnRow As DataRow = manningCnAnDataTable.NewRow
        manningCnAnRow.Item(sDistanceX) = 0.0
        manningCnAnRow.Item(Srfr.ManningCnAn.sCn) = Srfr.CnDef
        manningCnAnRow.Item(Srfr.ManningCnAn.sAn) = Srfr.AnDef
        manningCnAnRow.Item(Srfr.Roughness.sVegDensityM) = Srfr.VegDensityDef

        manningCnAnDataTable.Rows.Add(manningCnAnRow)

    End Sub

    '*********************************************************************************************************
    Public Const sSayreChiTable As String = "Sayre Chi Table"

    Public ReadOnly Property SayreChiTableProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSayreChiTable)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim sayreChiDataTable As DataTable = New DataTable(sSayreChiTable)

                ResetSayreChiTable(sayreChiDataTable)

                Dim _table As DataTableParameter = New DataTableParameter(sayreChiDataTable)
                mMyStore.AddProperty(sSayreChiTable, _table)
                _propertyNode = mMyStore.GetProperty(sSayreChiTable)

            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _table As DataTableParameter = DirectCast(_param, DataTableParameter)

                If (_table.Value.Columns.Contains(sChi)) Then
                    _table.Value.Columns(sChi).ColumnName = Srfr.SayreAlbertsonChi.sChiMM
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SayreChiTable() As DataTableParameter
        Get
            Return SayreChiTableProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            SayreChiTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetSayreChiTable(ByVal sayreChiDataTable As DataTable)

        ' Remove the previous data
        sayreChiDataTable.Clear()          ' Clear rows
        sayreChiDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        sayreChiDataTable.Columns.Add(sDistanceX, GetType(Double))
        sayreChiDataTable.Columns.Add(Srfr.SayreAlbertsonChi.sChiMM, GetType(Double))
        sayreChiDataTable.Columns.Add(Srfr.Roughness.sVegDensityM, GetType(Double))

        ' Add the row(s) of reset data
        Dim sayreChiRow As DataRow = sayreChiDataTable.NewRow
        sayreChiRow.Item(sDistanceX) = 0.0
        sayreChiRow.Item(Srfr.SayreAlbertsonChi.sChiMM) = Srfr.ChiDef
        sayreChiRow.Item(Srfr.Roughness.sVegDensityM) = Srfr.VegDensityDef

        sayreChiDataTable.Rows.Add(sayreChiRow)

    End Sub

    Public Function TabulatedRoughnessDistances() As List(Of Double)

        TabulatedRoughnessDistances = New List(Of Double)

        If (Me.EnableTabulatedRoughness.Value) Then

            Select Case (Me.RoughnessMethod.Value)

                Case RoughnessMethods.SayreAlbertson

                    Dim table As DataTable = Me.SayreChiTable.Value
                    If (table IsNot Nothing) Then
                        For Each row As DataRow In table.Rows
                            TabulatedRoughnessDistances.Add(CDbl(row(sDistanceX)))
                        Next
                    End If

                Case RoughnessMethods.ManningCnAn

                    Dim table As DataTable = Me.ManningCnAnTable.Value
                    If (table IsNot Nothing) Then
                        For Each row As DataRow In table.Rows
                            TabulatedRoughnessDistances.Add(CDbl(row(sDistanceX)))
                        Next
                    End If

                Case Else ' assume Manning N

                    Dim table As DataTable = Me.ManningNTable.Value
                    If (table IsNot Nothing) Then
                        For Each row As DataRow In table.Rows
                            TabulatedRoughnessDistances.Add(CDbl(row(sDistanceX)))
                        Next
                    End If
            End Select
        End If

        If (0 = TabulatedRoughnessDistances.Count) Then
            TabulatedRoughnessDistances = Nothing
        End If

    End Function

#End Region

#End Region

#Region " Erosion Properties "

    Public Const sSedimentComponents As String = "Sediment Components"

    Public ReadOnly Property SedimentComponentsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSedimentComponents)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _sedimentComponents As DataTable = New DataTable(sSedimentComponents)

                ResetSedimentComponents(_sedimentComponents)

                Dim _parameter As DataTableParameter = New DataTableParameter(_sedimentComponents)
                mMyStore.AddProperty(sSedimentComponents, _parameter)
                _propertyNode = mMyStore.GetProperty(sSedimentComponents)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SedimentComponents() As DataTableParameter
        Get
            Return SedimentComponentsProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            SedimentComponentsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetSedimentComponents(ByVal _sedimentComponents As DataTable)

        ' Remove previous data
        _sedimentComponents.Columns.Clear()
        _sedimentComponents.Rows.Clear()

        ' Add columns
        _sedimentComponents.Columns.Add(sPercentRetainedX, GetType(Double))
        _sedimentComponents.Columns.Add(sSieveSizeX, GetType(Double))
        _sedimentComponents.Columns.Add(sSpecificGravityX, GetType(String))

        ' Add rows of reset data
        Dim _sedimentRow As DataRow

        _sedimentRow = _sedimentComponents.NewRow
        _sedimentRow.Item(sPercentRetainedX) = 0.25
        _sedimentRow.Item(sSieveSizeX) = FiftyMicrons
        _sedimentRow.Item(sSpecificGravityX) = SpecificGravityOfSand
        _sedimentComponents.Rows.Add(_sedimentRow)

        _sedimentRow = _sedimentComponents.NewRow
        _sedimentRow.Item(sPercentRetainedX) = 0.6
        _sedimentRow.Item(sSieveSizeX) = EightMicrons
        _sedimentRow.Item(sSpecificGravityX) = SpecificGravityOfSand
        _sedimentComponents.Rows.Add(_sedimentRow)

    End Sub


    Public Const sSedimentConcentration As String = "Sediment Concentration"

    Public ReadOnly Property SedimentConcentrationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSedimentConcentration)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultSedimentConcentration, Units.GramsPerLiter)
                mMyStore.AddProperty(sSedimentConcentration, _double)
                _propertyNode = mMyStore.GetProperty(sSedimentConcentration)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SedimentConcentration() As DoubleParameter
        Get
            Return SedimentConcentrationProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SedimentConcentrationProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sSedimentTime As String = "Sediment Time"

    Public ReadOnly Property SedimentTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSedimentTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultSedimentTime, Units.Seconds)
                mMyStore.AddProperty(sSedimentTime, _double)
                _propertyNode = mMyStore.GetProperty(sSedimentTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SedimentTime() As DoubleParameter
        Get
            Return SedimentTimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SedimentTimeProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sSedimentDistance As String = "Sediment Distance"

    Public ReadOnly Property SedimentDistanceProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSedimentDistance)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _length As Double = mUnit.SystemGeometryRef.Length.Value
                Dim _double As DoubleParameter = New DoubleParameter(_length / 4.0, Units.Meters)
                _double.Source = ValueSources.Constant
                mMyStore.AddProperty(sSedimentDistance, _double)
                _propertyNode = mMyStore.GetProperty(sSedimentDistance)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SedimentDistance() As DoubleParameter
        Get
            Return SedimentDistanceProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SedimentDistanceProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sMassDensity As String = "Mass Density"

    Public ReadOnly Property MassDensityProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMassDensity)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultMassDensity,
                                                                     Units.GramsPerLiter)
                mMyStore.AddProperty(sMassDensity, _double)
                _propertyNode = mMyStore.GetProperty(sMassDensity)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MassDensity() As DoubleParameter
        Get
            Return MassDensityProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MassDensityProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sErodibilityA As String = "Erodibility A"

    Public ReadOnly Property ErodibilityAProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErodibilityA)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultErodibilityA,
                                                                     Units.SecondsPerMeter)
                mMyStore.AddProperty(sErodibilityA, _double)
                _propertyNode = mMyStore.GetProperty(sErodibilityA)
            Else
                Dim _double As DoubleParameter = _propertyNode.GetParameter
                _double.Units = Units.SecondsPerMeter
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErodibilityA() As DoubleParameter
        Get
            Return ErodibilityAProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ErodibilityAProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sErodibilityB As String = "Erodibility B"

    Public ReadOnly Property ErodibilityBProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErodibilityB)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultErodibilityB,
                                                                     Units.None)
                _double.MinValue = Double.MinValue
                mMyStore.AddProperty(sErodibilityB, _double)
                _propertyNode = mMyStore.GetProperty(sErodibilityB)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErodibilityB() As DoubleParameter
        Get
            Return ErodibilityBProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ErodibilityBProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sErodibilityTauc As String = "Erodibility Tauc"

    Public ReadOnly Property ErodibilityTaucProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErodibilityTauc)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultErodibilityTauc,
                                                                     Units.NewtonsPerSquareMeter)
                mMyStore.AddProperty(sErodibilityTauc, _double)
                _propertyNode = mMyStore.GetProperty(sErodibilityTauc)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErodibilityTauc() As DoubleParameter
        Get
            Return ErodibilityTaucProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ErodibilityTaucProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sErodibilityBeta As String = "Erodibility Beta"

    Public ReadOnly Property ErodibilityBetaProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErodibilityBeta)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultErodibilityBeta,
                                                                     Units.None)
                mMyStore.AddProperty(sErodibilityBeta, _double)
                _propertyNode = mMyStore.GetProperty(sErodibilityBeta)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErodibilityBeta() As DoubleParameter
        Get
            Return ErodibilityBetaProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ErodibilityBetaProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sFullScaleG As String = "Full Scale G"

    Public ReadOnly Property FullScaleGProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFullScaleG)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultFullScaleG,
                                                                     Units.KilogramsPerSecond)
                mMyStore.AddProperty(sFullScaleG, _double)
                _propertyNode = mMyStore.GetProperty(sFullScaleG)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property FullScaleG() As DoubleParameter
        Get
            Return FullScaleGProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            FullScaleGProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sErosionResolution As String = "Erosion Resolution"

    Public ReadOnly Property ErosionResolutionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErosionResolution)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultErosionResolution)
                mMyStore.AddProperty(sErosionResolution, _integer)
                _propertyNode = mMyStore.GetProperty(sErosionResolution)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErosionResolution() As IntegerParameter
        Get
            Return ErosionResolutionProperty.GetIntegerParameter
        End Get
        Set(ByVal Value As IntegerParameter)
            ErosionResolutionProperty.SetParameter(Value)
        End Set
    End Property

    Private mErosionResolutionIndex As Integer = -1
    Public Function GetFirstErosionResolutionSelection() As String
        mErosionResolutionIndex = -1
        Return GetNextErosionResolutionSelection()
    End Function

    Public Function GetNextErosionResolutionSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mErosionResolutionIndex += 1
        If (mErosionResolutionIndex < ErosionResolutions.HighLimit) Then
            If ((ErosionResolutionSelections(mErosionResolutionIndex).Flags And _flags) = 0) Then
                Return ErosionResolutionSelections(mErosionResolutionIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function


    Public Const sErosionFit As String = "Erosion Fit"

    Public ReadOnly Property ErosionFitProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErosionFit)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultErosionFit)
                mMyStore.AddProperty(sErosionFit, _integer)
                _propertyNode = mMyStore.GetProperty(sErosionFit)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErosionFit() As IntegerParameter
        Get
            Return ErosionFitProperty.GetIntegerParameter
        End Get
        Set(ByVal Value As IntegerParameter)
            ErosionFitProperty.SetParameter(Value)
        End Set
    End Property

    Private mErosionFitIndex As Integer = -1
    Public Function GetFirstErosionFitSelection() As String
        mErosionFitIndex = -1
        Return GetNextErosionFitSelection()
    End Function

    Public Function GetNextErosionFitSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mErosionFitIndex += 1
        If (mErosionFitIndex < ErosionFits.HighLimit) Then
            If ((ErosionFitSelections(mErosionFitIndex).Flags And _flags) = 0) Then
                Return ErosionFitSelections(mErosionFitIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function


    Public Const sErosionCoefficient As String = "Erosion Coefficient"

    Public ReadOnly Property ErosionCoefficientProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sErosionCoefficient)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultErosionCoefficient, Units.None)
                _double.MinValue = MinErosionCoefficient
                _double.MaxValue = MaxErosionCoefficient
                mMyStore.AddProperty(sErosionCoefficient, _double)
                _propertyNode = mMyStore.GetProperty(sErosionCoefficient)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ErosionCoefficient() As DoubleParameter
        Get
            Return ErosionCoefficientProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ErosionCoefficientProperty.SetParameter(Value)
        End Set
    End Property


#End Region

#End Region

#Region " Calculated Properties "

#Region " Infiltration "

    '*********************************************************************************************************
    ' KostiakovK()  - return k based on the current Infiltration Function
    ' KostiakovA()  -    "   a   "    "  "      "         "          "
    ' KostiakovB()  -    "   b   "    "  "      "         "          "
    ' KostiakovC()  -    "   c   "    "  "      "         "          "
    '
    ' Note - non-Kostiakov based Infiltration Functions will return default values
    '*********************************************************************************************************
    Public Function KostiakovK() As Double
        KostiakovK = 0.0
        Select Case Me.InfiltrationFunction.Value
            Case InfiltrationFunctions.NRCSIntakeFamily
                Dim nrcsFamily As Srfr.NrcsIntakeFamily.NrcsIntakeFamilies = Me.NrcsIntakeFamily.Value
                Dim nrcsOptions As Srfr.NrcsIntakeFamily.NrcsIntakeOptions = Me.NrcsToKostiakovMethod.Value
                Dim nrcsValues As Srfr.NrcsIntakeFamily.NrcsIntakeValues = Srfr.NrcsIntakeFamily.NrcsIntakeFamilyValues(nrcsFamily, nrcsOptions)
                KostiakovK = nrcsValues.k
            Case InfiltrationFunctions.TimeRatedIntakeFamily
                Dim Tn As Double = Me.InfiltrationTime_TR.Value
                Dim a As Double = Srfr.SrfrAPI.NrcsA(Tn)
                KostiakovK = Srfr.SrfrAPI.KostiakovK(Depth100mm, Tn, a)
            Case InfiltrationFunctions.CharacteristicInfiltrationTime
                Dim Zn As Double = Me.InfiltrationDepth_KT.Value
                Dim Tn As Double = Me.InfiltrationTime_KT.Value
                Dim a As Double = Me.KostiakovA_KT.Value
                KostiakovK = Srfr.SrfrAPI.KostiakovK(Zn, Tn, a)
            Case InfiltrationFunctions.BranchFunction
                KostiakovK = Me.KostiakovK_BF.Value
            Case InfiltrationFunctions.KostiakovFormula
                KostiakovK = Me.KostiakovK_KF.Value
            Case InfiltrationFunctions.ModifiedKostiakovFormula
                KostiakovK = Me.KostiakovK_MK.Value
        End Select
    End Function

    Public Function KostiakovA() As Double
        KostiakovA = 0.5
        Select Case Me.InfiltrationFunction.Value
            Case InfiltrationFunctions.NRCSIntakeFamily
                Dim nrcsFamily As Srfr.NrcsIntakeFamily.NrcsIntakeFamilies = Me.NrcsIntakeFamily.Value
                Dim nrcsOptions As Srfr.NrcsIntakeFamily.NrcsIntakeOptions = Me.NrcsToKostiakovMethod.Value
                Dim nrcsValues As Srfr.NrcsIntakeFamily.NrcsIntakeValues = Srfr.NrcsIntakeFamily.NrcsIntakeFamilyValues(nrcsFamily, nrcsOptions)
                KostiakovA = nrcsValues.a
            Case InfiltrationFunctions.TimeRatedIntakeFamily
                Dim Tn As Double = Me.InfiltrationTime_TR.Value
                KostiakovA = Srfr.SrfrAPI.NrcsA(Tn)
            Case InfiltrationFunctions.CharacteristicInfiltrationTime
                KostiakovA = Me.KostiakovA_KT.Value
            Case InfiltrationFunctions.BranchFunction
                KostiakovA = Me.KostiakovA_BF.Value
            Case InfiltrationFunctions.KostiakovFormula
                KostiakovA = Me.KostiakovA_KF.Value
            Case InfiltrationFunctions.ModifiedKostiakovFormula
                KostiakovA = Me.KostiakovA_MK.Value
        End Select
    End Function

    Public Function KostiakovB() As Double
        KostiakovB = 0.0
        Select Case Me.InfiltrationFunction.Value
            Case InfiltrationFunctions.BranchFunction
                KostiakovB = Me.BranchB_BF.Value
            Case InfiltrationFunctions.ModifiedKostiakovFormula
                KostiakovB = Me.KostiakovB_MK.Value
        End Select
    End Function

    Public Function KostiakovC() As Double
        KostiakovC = 0.0
        Select Case Me.InfiltrationFunction.Value
            Case InfiltrationFunctions.NRCSIntakeFamily
                Dim nrcsOptions As Srfr.NrcsIntakeFamily.NrcsIntakeOptions = Me.NrcsToKostiakovMethod.Value
                Select Case (nrcsOptions)
                    Case Srfr.NrcsIntakeFamily.NrcsIntakeOptions.ApproximateByBestFit
                        KostiakovC = 0.0
                    Case Else ' Assume NrcsToKostiakovMethods.DescribeByNrcsFormula
                        KostiakovC = Depth7mm
                End Select
            Case InfiltrationFunctions.BranchFunction
                KostiakovC = Me.KostiakovC_BF.Value
            Case InfiltrationFunctions.ModifiedKostiakovFormula
                KostiakovC = Me.KostiakovC_MK.Value
            Case InfiltrationFunctions.GreenAmpt
                KostiakovC = Me.GreenAmptC.Value
            Case InfiltrationFunctions.WarrickGreenAmpt
                KostiakovC = Me.WarrickGreenAmptC.Value
        End Select
    End Function

    '*********************************************************************************************************
    ' BranchTime()  - returns time at which the Branch Function switches to the 'b' infiltration term
    '*********************************************************************************************************
    Public Function BranchTime() As Double
        Dim k As Double = Me.KostiakovK_BF.Value
        Dim a As Double = Me.KostiakovA_BF.Value
        Dim b As Double = Me.BranchB_BF.Value

        Dim Tb As Double = Srfr.SrfrAPI.BranchTime(k, a, b)
        If (Me.BranchTimeSet.Value) Then
            Tb = Me.BranchTime_BF.Value
        End If

        Return Tb
    End Function

    '*********************************************************************************************************
    ' InfiltrationTime() - return time to infiltrate to depth based on current Infiltration Function
    '
    ' Input(s):     Zn      - infiltration depth
    '
    ' Returns:      Double  - Tau; time to infiltrate to Zn
    '*********************************************************************************************************
    Public Function InfiltrationTime(ByVal Zn As Double, Optional ByVal Y As Double = 0.0) As Double
        Dim Tau As Double = 0.0

        Select Case Me.InfiltrationFunction.Value

            Case InfiltrationFunctions.GreenAmpt, InfiltrationFunctions.WarrickGreenAmpt

                Dim h0 As Double = mUnit.UpstreamDepth()    ' Use Upstream Depth for h0

                If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
                    Tau = SrfrAPI.InfiltrationTime(Zn, h0, SrfrInfiltration)
                Else
                    Tau = SrfrAPI.InfiltrationTime(Zn, h0, Me)
                End If

            Case InfiltrationFunctions.Hydrus1D

                Dim rateTable As DataTable = mUnit.SubsurfaceFlowRef.HydrusInfiltration.Value
                If (rateTable IsNot Nothing) Then
                    Tau = Srfr.SrfrAPI.InfiltrationTimeTabRate(Zn, rateTable)
                Else
                    Tau = SrfrAPI.InfiltrationTime(Zn, Y, Me)
                End If

            Case Else ' Kostiakov Formula based

                If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
                    Tau = SrfrAPI.InfiltrationTime(Zn, Y, SrfrInfiltration)
                Else
                    Tau = SrfrAPI.InfiltrationTime(Zn, Y, Me)
                End If

        End Select

        Return Tau
    End Function

    Public Function InfiltrationTime(ByVal Zn As Double, ByVal WP As Double, ByVal FS As Double) As Double
        Dim Tau As Double = 0.0

        If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
            Tau = SrfrAPI.InfiltrationTime(Zn, WP, FS, SrfrInfiltration)
        Else
            Tau = SrfrAPI.InfiltrationTime(Zn, WP, FS, Me)
        End If

        Return Tau
    End Function

    Public Function InfiltrationTime(ByVal Zn As Double, ByVal RowIdx As Integer, Optional ByVal Y As Double = 0.0) As Double
        Dim Tau As Double = 0.0

        Select Case Me.InfiltrationFunction.Value

            Case InfiltrationFunctions.GreenAmpt, InfiltrationFunctions.WarrickGreenAmpt

                Dim h0 As Double = mUnit.UpstreamDepth()    ' Use Upstream Depth for h0

                If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
                    Tau = SrfrAPI.InfiltrationTime(Zn, RowIdx, h0, SrfrInfiltration)
                Else
                    Tau = SrfrAPI.InfiltrationTime(Zn, RowIdx, h0, Me)
                End If

            Case InfiltrationFunctions.Hydrus1D

                Dim rateTable As DataTable = mUnit.SubsurfaceFlowRef.HydrusInfiltration.Value
                If (rateTable IsNot Nothing) Then
                    Tau = Srfr.SrfrAPI.InfiltrationTimeTabRate(Zn, rateTable)
                Else
                    Debug.Assert(False)
                End If

            Case Else ' Kostiakov Formula based

                If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
                    Tau = SrfrAPI.InfiltrationTime(Zn, RowIdx, Y, SrfrInfiltration)
                Else
                    Tau = SrfrAPI.InfiltrationTime(Zn, RowIdx, Y, Me)
                End If

        End Select

        Return Tau
    End Function

    '*********************************************************************************************************
    ' InfiltrationDepth() - calculate depth infiltrated at opportunity time based on current Infiltration
    '                       Function and optionally a flow depth or flow depth hydrograph
    '
    ' Input(s):     Tau                 - opportunity time
    '               Y                   - flow depth
    '               FlowDepthHydrograph - flow depth hydrograph
    '
    ' Returns:      Double      - Zn; infiltrated depth
    '
    ' Note - for best results, the finer the DTs between DataRows in the flow depth hydrograph the better.
    '*********************************************************************************************************
    Public Function InfiltrationDepth(ByVal Tau As Double, Optional ByVal Y As Double = 0.0) As Double
        Dim Zn As Double = 0.0

        Select Case Me.InfiltrationFunction.Value

            Case InfiltrationFunctions.GreenAmpt, InfiltrationFunctions.WarrickGreenAmpt

                Dim h0 As Double = mUnit.UpstreamDepth()    ' Use Upstream Depth for h0

                If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
                    Zn = SrfrAPI.InfiltrationDepth(Tau, h0, SrfrInfiltration)
                Else
                    Zn = SrfrAPI.InfiltrationDepth(Tau, h0, Me)
                End If

            Case InfiltrationFunctions.Hydrus1D

                Debug.Assert(False)

            Case Else ' Empirical infiltration methods (e.g. Kostiakov Formula based)

                If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
                    Zn = SrfrAPI.InfiltrationDepth(Tau, Y, SrfrInfiltration)
                Else
                    Zn = SrfrAPI.InfiltrationDepth(Tau, Y, Me)
                End If

        End Select

        Return Zn
    End Function

    Public Function InfiltrationDepth(ByVal Tau As Double,
                                      ByVal FlowDepthHydrograph As DataTable) As Double
        Dim Zn As Double = 0.0

        If (FlowDepthHydrograph Is Nothing) Then
            Zn = InfiltrationDepth(Tau)
        Else
            Select Case Me.InfiltrationFunction.Value

                Case InfiltrationFunctions.Hydrus1D

                    Debug.Assert(False)

                Case Else

                    If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
                        Zn = SrfrAPI.InfiltrationDepth(Tau, FlowDepthHydrograph, SrfrInfiltration)
                    Else
                        Zn = SrfrAPI.InfiltrationDepth(Tau, FlowDepthHydrograph, Me)
                    End If

            End Select
        End If

        Return Zn
    End Function

    Public Function InfiltrationDepth(ByVal Tau As Double, ByVal Dist As Double,
                                      ByVal RefSrfrAPI As Srfr.SrfrAPI) As Double
        Dim Zn As Double = 0.0

        If (RefSrfrAPI Is Nothing) Then
            Zn = InfiltrationDepth(Tau)
        ElseIf (RefSrfrAPI.Irrigation Is Nothing) Then
            Zn = InfiltrationDepth(Tau)
        Else
            Dim FlowDepthHydrograph As DataTable = RefSrfrAPI.Irrigation.Hydrographs("Y", Dist)
            Zn = InfiltrationDepth(Tau, FlowDepthHydrograph)
        End If

        Return Zn
    End Function

    '*********************************************************************************************************
    ' InfiltrationRate() - return infiltration rate at opportunity time based on current Infiltration Function
    '
    ' Input(s):     Tau     - opportunity time
    '
    ' Returns:      Double  - dZdT; infiltration rate
    '
    ' Note - currently, this function is only used by Design & Operations
    '*********************************************************************************************************
    Public Function InfiltrationRate(ByVal Tau As Double, Optional ByVal Y As Double = 0.0) As Double
        Dim dZdT As Double = 0.0

        Select Case Me.InfiltrationFunction.Value

            Case InfiltrationFunctions.GreenAmpt

                Dim h0 As Double = mUnit.UpstreamDepth()    ' Use Upstream Depth for h0

                If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
                    dZdT = SrfrAPI.InfiltrationRate(Tau, h0, SrfrInfiltration)
                Else
                    dZdT = SrfrAPI.InfiltrationRate(Tau, h0, Me)
                End If

            Case InfiltrationFunctions.WarrickGreenAmpt, InfiltrationFunctions.Hydrus1D

                Debug.Assert(False)

            Case Else ' Kostiakov Formula based

                If (SrfrInfiltration IsNot Nothing) Then ' use alternate source for infiltration parameters
                    dZdT = SrfrAPI.InfiltrationRate(Tau, Y, SrfrInfiltration)
                Else
                    dZdT = SrfrAPI.InfiltrationRate(Tau, Y, Me)
                End If
        End Select

        Return dZdT
    End Function

#End Region

#Region " Infiltration Function "

    '*********************************************************************************************************
    ' InfiltrationFunctionDataTable() - Calculate Infiltration Function DataTable
    ' InfiltrationFunctionArrayList() -     "        "        "         ArrayList
    '
    ' Input(s):     Tend        - End Infiltration time (0.0 => use time to infiltrate to Dreq
    '               NumPoints   - number of points (i.e. DataRows) for created DataTable
    '               RowIdx      - optional row index if infiltration is specified using a table
    '
    ' Returns:      DataTable   - Time vs. Infiltration
    '           or  ArrayList   - Infiltration only
    '*********************************************************************************************************
    Public Function InfiltrationFunctionDataTable(ByVal Tend As Double, ByVal NumPoints As Integer,
                                                  Optional ByVal RowIdx As Integer = -1) As DataTable
        InfiltrationFunctionDataTable = Nothing

        If (0 < NumPoints) Then

            ' If no end time specified, use time required to infiltrate to Dreq
            If (Tend <= 0.0) Then
                Dim Zn As Double = mUnit.InflowManagementRef.RequiredDepth.Value
                Dim Tn As Double = Me.InfiltrationTime(Zn)
                Tend = Tn * 2.0 ' End of curve is double Infiltration Time
            End If

            ' Calculate the Infiltration Function DataTable based on current Infiltration Method
            If (RowIdx < 0) Then ' standard infiltration (i.e. not tabulated)
                Select Case Me.InfiltrationFunction.Value

                    Case InfiltrationFunctions.Hydrus1D
                        InfiltrationFunctionDataTable = mUnit.SubsurfaceFlowRef.HydrusInfiltration.Value

                    Case InfiltrationFunctions.GreenAmpt, InfiltrationFunctions.WarrickGreenAmpt
                        Dim h0 As Double = mUnit.UpstreamDepth() ' Use Upstream Depth for h0
                        InfiltrationFunctionDataTable = SrfrAPI.InfiltrationFunction(Tend, h0, NumPoints, Me)

                    Case Else ' Assume Branch / Kostiakov variation
                        InfiltrationFunctionDataTable = SrfrAPI.InfiltrationFunction(Tend, NumPoints, Me)
                End Select
            Else ' tabulated infiltration
                Select Case Me.InfiltrationFunction.Value

                    Case InfiltrationFunctions.Hydrus1D
                        InfiltrationFunctionDataTable = mUnit.SubsurfaceFlowRef.HydrusInfiltration.Value

                    Case InfiltrationFunctions.GreenAmpt, InfiltrationFunctions.WarrickGreenAmpt
                        Dim h0 As Double = mUnit.UpstreamDepth() ' Use Upstream Depth for h0
                        InfiltrationFunctionDataTable = SrfrAPI.InfiltrationFunction(Tend, h0, RowIdx, NumPoints, Me)

                    Case Else ' Assume Branch / Kostiakov variation
                        InfiltrationFunctionDataTable = SrfrAPI.InfiltrationFunction(Tend, RowIdx, NumPoints, Me)
                End Select
            End If
        End If ' (0 < NumPoints)

    End Function

    Public Function InfiltrationFunctionArrayList(ByVal Tend As Double, ByVal NumPoints As Integer) As ArrayList
        InfiltrationFunctionArrayList = Nothing

        If (0 < NumPoints) Then

            ' If no end time specified, use time required to infiltrate to Dreq
            If ((Tend <= 0.0) Or (Double.IsNaN(Tend))) Then
                Dim Zn As Double = mUnit.InflowManagementRef.RequiredDepth.Value
                Dim Tn As Double = Me.InfiltrationTime(Zn)
                Tend = Tn * 2.0 ' End of curve is double Infiltration Time
            End If

            ' Calculate the Infiltration Function ArrayList based on current Infiltration Method
            Select Case Me.InfiltrationFunction.Value

                Case InfiltrationFunctions.Hydrus1D
                    'InfiltrationFunctionArrayList = mUnit.SubsurfaceFlowRef.HydrusInfiltration.Value
                    Debug.Assert(False)

                Case InfiltrationFunctions.GreenAmpt, InfiltrationFunctions.WarrickGreenAmpt
                    Dim h0 As Double = mUnit.UpstreamDepth() ' Use Upstream Depth for h0
                    InfiltrationFunctionArrayList = SrfrAPI.InfiltrationFunctionDepths(Tend, h0, NumPoints, Me)

                Case Else ' Assume Branch / Kostiakov variation
                    InfiltrationFunctionArrayList = SrfrAPI.InfiltrationFunctionDepths(Tend, NumPoints, Me)
            End Select
        End If ' (0 < NumPoints)

    End Function

    Public Function InfiltrationFunctionArrayList(ByVal Q0 As Double, ByVal Tend As Double, ByVal NumPoints As Integer) As ArrayList
        InfiltrationFunctionArrayList = Nothing

        If (0 < NumPoints) Then

            Dim S0 As Double = mUnit.SystemGeometryRef.AverageSlope
            Dim L As Double = mUnit.SystemGeometryRef.Length.Value
            Dim W As Double = mUnit.SystemGeometryRef.WidthForCrossSection
            Dim h0 As Double = mUnit.UpstreamDepth(Q0, L, W, S0) ' Use Upstream Depth for h0

            ' If no end time specified, use time required to infiltrate to Dreq
            If ((Tend <= 0.0) Or (Double.IsNaN(Tend))) Then
                Dim Zn As Double = mUnit.InflowManagementRef.RequiredDepth.Value
                Dim Tn As Double = Me.InfiltrationTime(Zn)
                Tend = Tn * 2.0 ' End of curve is double Infiltration Time
            End If

            ' Calculate the Infiltration Function ArrayList based on current Infiltration Method
            Select Case Me.InfiltrationFunction.Value

                Case InfiltrationFunctions.Hydrus1D
                    'InfiltrationFunctionArrayList = mUnit.SubsurfaceFlowRef.HydrusInfiltration.Value
                    Debug.Assert(False)

                Case Else
                    InfiltrationFunctionArrayList = SrfrAPI.InfiltrationFunctionDepths(Tend, h0, NumPoints, Me)
            End Select
        End If ' (0 < NumPoints)

    End Function

    Public Function InfiltrationFunctionArrayList(ByVal Tend As Double, ByVal RowIdx As Integer,
                                                  ByVal NumPoints As Integer) As ArrayList
        InfiltrationFunctionArrayList = Nothing

        If (0 < NumPoints) Then

            ' If no end time specified, use time required to infiltrate to Dreq
            If ((Tend <= 0.0) Or (Double.IsNaN(Tend))) Then
                Dim Zn As Double = mUnit.InflowManagementRef.RequiredDepth.Value
                Dim Tn As Double = Me.InfiltrationTime(Zn)
                Tend = Tn * 2.0 ' End of curve is double Infiltration Time
            End If

            ' Calculate the Infiltration Function ArrayList based on current Infiltration Method
            Select Case Me.InfiltrationFunction.Value

                Case InfiltrationFunctions.Hydrus1D
                    'InfiltrationFunctionArrayList = mUnit.SubsurfaceFlowRef.HydrusInfiltration.Value
                    Debug.Assert(False)

                Case InfiltrationFunctions.GreenAmpt, InfiltrationFunctions.WarrickGreenAmpt
                    Dim h0 As Double = mUnit.UpstreamDepth() ' Use Upstream Depth for h0
                    InfiltrationFunctionArrayList = SrfrAPI.InfiltrationFunctionDepths(Tend, h0, NumPoints, Me)

                Case Else ' Assume Branch / Kostiakov variation
                    InfiltrationFunctionArrayList = SrfrAPI.InfiltrationFunctionDepths(Tend, RowIdx, NumPoints, Me)
            End Select
        End If ' (0 < NumPoints)

    End Function

    Public Function InfiltrationFunctionArrayList(ByVal Q0 As Double, ByVal Tend As Double, ByVal RowIdx As Integer,
                                                  ByVal NumPoints As Integer) As ArrayList
        InfiltrationFunctionArrayList = Nothing

        If (0 < NumPoints) Then

            Dim S0 As Double = mUnit.SystemGeometryRef.AverageSlope
            Dim L As Double = mUnit.SystemGeometryRef.Length.Value
            Dim W As Double = mUnit.SystemGeometryRef.WidthForCrossSection
            Dim h0 As Double = mUnit.UpstreamDepth(Q0, L, W, S0) ' Use Upstream Depth for h0

            ' If no end time specified, use time required to infiltrate to Dreq
            If ((Tend <= 0.0) Or (Double.IsNaN(Tend))) Then
                Dim Zn As Double = mUnit.InflowManagementRef.RequiredDepth.Value
                Dim Tn As Double = Me.InfiltrationTime(Zn)
                Tend = Tn * 2.0 ' End of curve is double Infiltration Time
            End If

            ' Calculate the Infiltration Function ArrayList based on current Infiltration Method
            Select Case Me.InfiltrationFunction.Value

                Case InfiltrationFunctions.Hydrus1D
                    'InfiltrationFunctionArrayList = mUnit.SubsurfaceFlowRef.HydrusInfiltration.Value
                    Debug.Assert(False)

                Case Else
                    InfiltrationFunctionArrayList = SrfrAPI.InfiltrationFunctionDepths(Tend, h0, NumPoints, Me)
            End Select
        End If ' (0 < NumPoints)

    End Function

#Region " Branch Infiltration Function "

    '*********************************************************************************************************
    ' BranchDataTable() - Calculate Branch infiltration function DataTable                       Class Methods
    ' BranchArrayList() -     "        "        "           "    ArrayList
    '
    ' Input(s):     k, a, b, c  - Kostiakov parameters
    '               Tend        - End Infiltration time
    '               Tb          - Branch time
    '               NumPoints   - number of points (i.e. DataRows) for created DataTable
    '               TimeOffsetC - whether or not a Time Offset should be used with the C term
    '
    ' Returns:      DataTable   - Time vs. Infiltration
    '           or  ArrayList   - Infiltration only
    '*********************************************************************************************************
    Public Shared Function BranchDataTable(ByVal k As Double, ByVal a As Double, ByVal b As Double, ByVal c As Double,
            ByVal Tend As Double, ByVal Tb As Double, ByVal NumPoints As Integer, ByVal TimeOffsetC As Boolean) As DataTable

        BranchDataTable = Nothing

        If (0 < NumPoints) Then

            ' Branch curve to return
            BranchDataTable = New DataTable("Infiltration Function")
            Dim row As DataRow

            BranchDataTable.Columns.Add(sTimeX, GetType(Double))
            BranchDataTable.Columns.Add(sInfiltrationX, GetType(Double))
            '
            ' Calculate the infiltration depth curve using the Kostiakov branch power functions:
            '
            '   T <= Tb:  Zn = k * (T ^ a) + c
            '   Tb  < T:  Zb = Zn + (b * T)
            '
            Dim Z As Double   ' Infiltration depth for (T <= Tb)
            Dim Zb As Double   ' Infiltration depth for (Tb < T)
            Dim Tau As Double    ' Infiltration time
            '
            ' The classic fence post problem: N fence posts = N-1 fence segments
            '
            ' Here: N points = N-1 time segments
            '
            Dim NumSegments As Integer = NumPoints - 1

            For point As Integer = 0 To NumPoints - 1

                ' Get time represented by this point
                Tau = (Tend * point) / NumSegments

                row = BranchDataTable.NewRow
                row.Item(sTimeX) = Tau

                ' Check if time has past the Branch point
                If (Tau <= Tb) Then

                    ' T <= Tb:  Zn = k * (T ^ a) + c
                    If (TimeOffsetC) Then
                        Z = Srfr.SrfrAPI.InfiltrationDepthMKTO(Tau, k, a, 0.0, c)
                    Else
                        Z = Srfr.SrfrAPI.InfiltrationDepthMK(Tau, k, a, 0.0, c)
                    End If

                    row.Item(sInfiltrationX) = Z

                Else ' After Branch point

                    ' T <= Tb:  Zn = k * (T ^ a) + c
                    If (TimeOffsetC) Then
                        Z = Srfr.SrfrAPI.InfiltrationDepthMKTO(Tb, k, a, 0.0, c)
                    Else
                        Z = Srfr.SrfrAPI.InfiltrationDepthMK(Tb, k, a, 0.0, c)
                    End If

                    ' Tb < T:  Zb = Zn + (b * T)
                    Zb = Z + (b * (Tau - Tb))

                    row.Item(sInfiltrationX) = Zb
                End If

                BranchDataTable.Rows.Add(row)

            Next point
        End If ' (0 < NumPoints)

    End Function

    Public Shared Function BranchArrayList(ByVal k As Double, ByVal a As Double, ByVal b As Double, ByVal c As Double,
            ByVal Tend As Double, ByVal Tb As Double, ByVal NumPoints As Integer, ByVal TimeOffsetC As Boolean) As ArrayList

        BranchArrayList = Nothing

        Dim BranchTable As DataTable = BranchDataTable(k, a, b, c, Tend, Tb, NumPoints, TimeOffsetC)
        If (BranchTable IsNot Nothing) Then

            BranchArrayList = New ArrayList

            For Each row As DataRow In BranchTable.Rows
                Dim z As Double = CDbl(row.Item(sInfiltrationX))
                BranchArrayList.Add(z)
            Next row

        End If
    End Function

#End Region

#Region " Kostiakov Infiltration Function "

    '*********************************************************************************************************
    ' KostiakovDataTable() - Calculate Kostiakov infiltration function DataTable                 Class Methods
    ' KostiakovArrayList() -     "         "          "           "    ArrayList
    '
    ' Input(s):     k, a, b, c  - Kostiakov parameters
    '               Tend        - End Infiltration time
    '               NumPoints   - number of points (i.e. DataRows) for created DataTable
    '               TimeOffsetC - whether or not a Time Offset should be used with the C term
    '
    ' Returns:      DataTable   - Time vs. Infiltration
    '           or  ArrayList   - Infiltration only
    '*********************************************************************************************************
    Public Shared Function KostiakovDataTable(ByVal k As Double, ByVal a As Double, ByVal b As Double, ByVal c As Double,
                        ByVal Tend As Double, ByVal NumPoints As Integer, ByVal TimeOffsetC As Boolean) As DataTable

        KostiakovDataTable = Nothing

        If (0 < NumPoints) Then

            ' Branch curve to return
            KostiakovDataTable = New DataTable(sInfiltrationFunction)
            Dim row As DataRow

            KostiakovDataTable.Columns.Add(sTimeX, GetType(Double))
            KostiakovDataTable.Columns.Add(sInfiltrationX, GetType(Double))
            '
            ' Calculate the infiltration depth curve using the Kostiakov power function:
            '
            '   Zn = k * (Tn ^ a) + (b * Tn) + c
            '
            Dim Z As Double     ' Infiltration depth
            Dim Tau As Double   ' Infiltration time
            '
            ' The classic fence post problem: N fence posts = N-1 fence segments
            '
            ' Here: N points = N-1 time segments
            '
            Dim NumSegments As Integer = NumPoints - 1

            For point As Integer = 0 To NumPoints - 1

                ' Get time represented by this point
                Tau = (Tend * point) / NumSegments

                If (TimeOffsetC) Then
                    Z = Srfr.SrfrAPI.InfiltrationDepthMKTO(Tau, k, a, b, c)
                Else
                    Z = Srfr.SrfrAPI.InfiltrationDepthMK(Tau, k, a, b, c)
                End If

                row = KostiakovDataTable.NewRow
                row.Item(sTimeX) = Tau
                row.Item(sInfiltrationX) = Z

                KostiakovDataTable.Rows.Add(row)

            Next point
        End If ' (0 < NumPoints)

    End Function

    Public Shared Function KostiakovArrayList(ByVal k As Double, ByVal a As Double, ByVal b As Double, ByVal c As Double,
                        ByVal Tend As Double, ByVal NumPoints As Integer, ByVal TimeOffsetC As Boolean) As ArrayList

        KostiakovArrayList = Nothing

        Dim KostiakovTable As DataTable = KostiakovDataTable(k, a, b, c, Tend, NumPoints, TimeOffsetC)
        If (KostiakovTable IsNot Nothing) Then

            KostiakovArrayList = New ArrayList

            For Each row As DataRow In KostiakovTable.Rows
                Dim z As Double = CDbl(row.Item(sInfiltrationX))
                KostiakovArrayList.Add(z)
            Next row

        End If
    End Function

#End Region

#Region " Green-Ampt Infiltration Function "

    '*********************************************************************************************************
    ' GreenAmptDataTable() - Calculate Green-Ampt infiltration function DataTable                Class Methods
    ' GreenAmptArrayList() -     "         "           "           "    ArrayList
    '
    ' Input(s):     SWD         - Soil Water Deficit
    '               h0          - Representative surface flow depth
    '               hf          - Wetting Front Pressure Head
    '               Ks          - Hydraulic conductivity
    '               c           - Macropore infiltration
    '               Tend        - End Infiltration time
    '               NumPoints   - number of points (i.e. DataRows) for created DataTable
    '               Hydrographs - optional DataSet of FlowDepthHydrographs
    '
    ' Returns:      DataTable   - Time vs. Infiltration
    '           or  ArrayList   - Infiltration only
    '
    ' Note - If Flow Depth Hydrographs are included in the input parameter list, they are used in lieu of h0
    '        to specifiy the flow depths at each Tau.
    '*********************************************************************************************************
    Public Shared Function GreenAmptDataTable(ByVal SWD As Double, ByVal h0 As Double, ByVal hf As Double,
            ByVal Ks As Double, ByVal c As Double, ByVal Tend As Double, ByVal NumPoints As Integer,
            Optional ByVal Hydrographs As DataSet = Nothing) As DataTable

        GreenAmptDataTable = Nothing

        If (0 < NumPoints) Then

            ' Green-Ampt curve to return
            GreenAmptDataTable = New DataTable("Infiltration Function")
            Dim row As DataRow

            GreenAmptDataTable.Columns.Add(sTimeX, GetType(Double))
            GreenAmptDataTable.Columns.Add(sInfiltrationX, GetType(Double))
            '
            ' Calculate the infiltration depth curve
            '
            Dim Z As Double     ' Infiltration depth
            Dim Tau As Double   ' Infiltration time
            '
            ' The classic fence post problem: N fence posts = N-1 fence segments
            '
            ' Here: N points = N-1 time segments
            '
            Dim NumSegments As Integer = NumPoints - 1

            For point As Integer = 0 To NumPoints - 1

                Tau = (Tend * point) / NumSegments  ' Time represented by this point
                Z = Srfr.SrfrAPI.InfiltrationDepthGA(Tau, SWD, h0, hf, Ks, 0.0, c)

                row = GreenAmptDataTable.NewRow
                row.Item(sTimeX) = Tau
                row.Item(sInfiltrationX) = Z

                GreenAmptDataTable.Rows.Add(row)
            Next point
        End If ' (0 < NumPoints)

    End Function

    Public Shared Function GreenAmptArrayList(ByVal SWD As Double, ByVal h0 As Double, ByVal hf As Double,
            ByVal Ks As Double, ByVal c As Double, ByVal Tend As Double, ByVal NumPoints As Integer,
            Optional ByVal Hydrographs As DataSet = Nothing) As ArrayList

        GreenAmptArrayList = Nothing

        Dim GreenAmptTable As DataTable = GreenAmptDataTable(SWD, h0, hf, Ks, c, Tend, NumPoints, Hydrographs)
        If (GreenAmptTable IsNot Nothing) Then

            GreenAmptArrayList = New ArrayList

            For Each row As DataRow In GreenAmptTable.Rows
                Dim z As Double = CDbl(row.Item(sInfiltrationX))
                GreenAmptArrayList.Add(z)
            Next row

        End If
    End Function

    '*********************************************************************************************************
    ' GreenAmptInfiltrationTable() - Calculate infiltration function DataTable                  Object Methods
    ' GreenAmptInfiltrationList()  -     "          "           "    ArrayList
    '
    ' Input(s):     FlowDepthHydrograph   - Flow Depth Hydrograph (Time vs. Flow Depth)
    '
    ' Returns:      DataTable   - Time vs. Infiltration
    '           or  ArrayList   - Infiltration only
    '*********************************************************************************************************
    Public Function GreenAmptInfiltrationTable(ByVal FlowDepthHydrograph As DataTable) As DataTable

        Dim srfrGreenAmpt As Srfr.GreenAmpt = SrfrAPI.SrfrGreenAmpt(Me)
        Dim srfrCrossSection As Srfr.CrossSection = SrfrAPI.SrfrCrossSection(mUnit.SystemGeometryRef)

        srfrGreenAmpt.RefCrossSection = srfrCrossSection

        GreenAmptInfiltrationTable = srfrGreenAmpt.InfiltrationFunction(FlowDepthHydrograph)
    End Function

    Public Function GreenAmptInfiltrationList(ByVal FlowDepthHydrograph As DataTable) As ArrayList

        GreenAmptInfiltrationList = Nothing

        Dim GreenAmptTable As DataTable = GreenAmptInfiltrationTable(FlowDepthHydrograph)
        If (GreenAmptTable IsNot Nothing) Then

            GreenAmptInfiltrationList = New ArrayList

            For Each row As DataRow In GreenAmptTable.Rows
                Dim z As Double = CDbl(row.Item(sInfiltrationX))
                GreenAmptInfiltrationList.Add(z)
            Next row

        End If

    End Function

#End Region

#Region " Warrick Green-Ampt Infiltration Function "

    '*********************************************************************************************************
    ' WarrickGreenAmptDataTable() - Calculate infiltration function DataTable                    Class Methods
    ' WarrickGreenAmptArrayList() -     "          "           "    ArrayList
    '
    ' Input(s):     SWD         - Soil Water Deficit
    '               hf          - Wetting Front Pressure Head
    '               Ks          - Hydraulic conductivity
    '               h0          - Representative surface flow depth
    '               c           - Macropore infiltration
    '               FS          - Furrow spacing
    '               Tend        - End Infiltration time
    '               NumPoints   - number of points (i.e. DataRows) for created DataTable
    '
    ' Returns:      DataTable   - Time vs. Infiltration
    '           or  ArrayList   - Infiltration only
    '*********************************************************************************************************
    Public Shared Function WarrickGreenAmptDataTable(ByVal SWD As Double, ByVal hf As Double, ByVal Ks As Double,
            ByVal h0 As Double, ByVal Wa As Double, ByVal Wr As Double, ByVal c As Double, ByVal FS As Double,
            ByVal Tend As Double, ByVal NumPoints As Integer) As DataTable

        WarrickGreenAmptDataTable = Nothing

        If (0 < NumPoints) Then

            ' Warrick Green-Ampt curve to return
            WarrickGreenAmptDataTable = New DataTable("Infiltration Function")
            Dim row As DataRow

            WarrickGreenAmptDataTable.Columns.Add(sTimeX, GetType(Double))
            WarrickGreenAmptDataTable.Columns.Add(sInfiltrationX, GetType(Double))
            '
            ' Calculate the infiltration depth curve
            '
            Dim Zwp As Double = 0.0         ' Infiltration depth
            Dim Z1Dprev As Double = c
            Dim AZprev As Double = c * FS

            Dim Tau As Double = 0.0         ' Infiltration time
            Dim TauPrev As Double = 0.0

            Dim Z, Z1D, AZ As Double
            '
            ' The classic fence post problem: N fence posts = N-1 fence segments
            '
            ' Here: N points = N-1 time segments
            '
            Dim NumSegments As Integer = NumPoints - 1

            For point As Integer = 0 To NumSegments

                Tau = (Tend * point) / NumSegments  ' Time represented by this point
                Z = Srfr.SrfrAPI.InfiltrationDepthWGA2(Tau, c, 1.0, Wa, Wr, 0.0, SWD, h0, hf, Ks, TauPrev, Z1Dprev, AZprev, Z1D, AZ)
                Zwp = AZ / FS

                row = WarrickGreenAmptDataTable.NewRow
                row.Item(sTimeX) = Tau
                row.Item(sInfiltrationX) = Zwp

                WarrickGreenAmptDataTable.Rows.Add(row)

                TauPrev = Tau
                Z1Dprev = Z1D
                AZprev = AZ
            Next point
        End If ' (0 < NumPoints)

    End Function

    Public Shared Function WarrickGreenAmptArrayList(ByVal SWD As Double, ByVal hf As Double, ByVal Ks As Double,
            ByVal h0 As Double, ByVal Wa As Double, ByVal Wr As Double, ByVal c As Double, ByVal FS As Double,
            ByVal Tend As Double, ByVal NumPoints As Integer) As ArrayList

        WarrickGreenAmptArrayList = Nothing

        Dim WarrickGreenAmptTable As DataTable = WarrickGreenAmptDataTable(SWD, hf, Ks, h0, Wa, Wr, c, FS, Tend, NumPoints)
        If (WarrickGreenAmptTable IsNot Nothing) Then

            WarrickGreenAmptArrayList = New ArrayList

            For Each row As DataRow In WarrickGreenAmptTable.Rows
                Dim z As Double = CDbl(row.Item(sInfiltrationX))
                WarrickGreenAmptArrayList.Add(z)
            Next row

        End If
    End Function

    '*********************************************************************************************************
    ' WarrickGreenAmptInfiltrationTable() - Calculate infiltration function DataTable           Object Methods
    ' WarrickGreenAmptInfiltrationList()  -     "          "           "    ArrayList
    '
    ' Input(s):     FlowDepthHydrograph   - Flow Depth Hydrograph (Time vs. Flow Depth)
    '
    ' Returns:      DataTable   - Time vs. Infiltration
    '           or  ArrayList   - Infiltration only
    '*********************************************************************************************************
    Public Function WarrickGreenAmptInfiltrationTable(ByVal FlowDepthHydrograph As DataTable) As DataTable

        Dim srfrWarrickGreenAmpt As Srfr.WarrickGreenAmpt = SrfrAPI.SrfrWarrickGreenAmpt(Me)
        Dim srfrCrossSection As Srfr.CrossSection = SrfrAPI.SrfrCrossSection(mUnit.SystemGeometryRef)

        srfrWarrickGreenAmpt.RefCrossSection = srfrCrossSection

        WarrickGreenAmptInfiltrationTable = srfrWarrickGreenAmpt.InfiltrationFunction(FlowDepthHydrograph)
    End Function

    Public Function WarrickGreenAmptInfiltrationList(ByVal FlowDepthHydrograph As DataTable) As ArrayList

        WarrickGreenAmptInfiltrationList = Nothing

        Dim WarrickGreenAmptTable As DataTable = WarrickGreenAmptInfiltrationTable(FlowDepthHydrograph)
        If (WarrickGreenAmptTable IsNot Nothing) Then

            WarrickGreenAmptInfiltrationList = New ArrayList

            For Each row As DataRow In WarrickGreenAmptTable.Rows
                Dim z As Double = CDbl(row.Item(sInfiltrationX))
                WarrickGreenAmptInfiltrationList.Add(z)
            Next row

        End If

    End Function

#End Region

#End Region

#Region " Soil Water Depletion "
    '
    ' Lookup SWD column values
    '
    Public Function CumulativeProfileDepth() As Double
        CumulativeProfileDepth = 0.0

        Dim swdTable As DataTable = SoilWaterDepletion.Value
        If Not (swdTable Is Nothing) Then
            If (0 < swdTable.Rows.Count) Then
                Dim row As DataRow = swdTable.Rows(swdTable.Rows.Count - 1)
                CumulativeProfileDepth = CDbl(row.Item(sCumulativeDepthX))
            End If
        End If
    End Function

    Public Function CumulativeSWD() As Double
        CumulativeSWD = 0.0

        Dim swdTable As DataTable = SoilWaterDepletion.Value
        If Not (swdTable Is Nothing) Then
            If (0 < swdTable.Rows.Count) Then
                Dim row As DataRow = swdTable.Rows(swdTable.Rows.Count - 1)
                CumulativeSWD = CDbl(row.Item(sCumulativeSwdX))
            End If
        End If
    End Function

    Public Function SoilWaterDepletionDepth() As Double
        SoilWaterDepletionDepth = 0.0

        Dim swdTable As DataTable = SoilWaterDepletion.Value
        If Not (swdTable Is Nothing) Then
            If (0 < swdTable.Rows.Count) Then
                Dim row As DataRow = swdTable.Rows(swdTable.Rows.Count - 1)
                SoilWaterDepletionDepth = CDbl(row.Item(sCumulativeDepthX))
            End If
        End If
    End Function
    '
    ' Linear Interpolation of Cumulative SWD
    '
    Public Function InterpolateSwd(ByVal Depth As Double) As Double

        Dim swdTable As DataTable = SoilWaterDepletion.Value

        ' Soil Water Deficit
        Dim Depth1 As Double = 0.0     ' Cumulative Depth
        Dim Depth2 As Double
        Dim SWD1 As Double = 0.0       ' Cumulative SWD
        Dim SWD2 As Double

        If Not (swdTable Is Nothing) Then

            ' Search for deeper soil layer
            For Each row As DataRow In swdTable.Rows
                ' Get values for next soil profile layer
                Depth2 = CDbl(row.Item(sCumulativeDepthX))
                SWD2 = CDbl(row.Item(sCumulativeSwdX))

                ' Is depth within this soil profile layer?
                If (Depth <= Depth2) Then
                    ' Yes, interpolate soil water deficit
                    SWD1 = (((Depth - Depth1) * (SWD2 - SWD1)) / (Depth2 - Depth1)) + SWD1
                    Exit For
                End If

                ' No, save values as previous soil layer and iterate
                Depth1 = Depth2
                SWD1 = SWD2
            Next
        End If

        Return SWD1

    End Function
    '
    ' Calculate the Profile Root Zone Depth
    '
    Public Function ProfileRootZoneDepth() As Double
        Dim _rootZoneDepth As Double = RootZoneDepth.Value
        Dim _cumulativeProfileDepth As Double = CumulativeProfileDepth()

        ProfileRootZoneDepth = Math.Min(_rootZoneDepth, _cumulativeProfileDepth)
    End Function
    '
    ' Calculate Soil Water Deficit from Soil Water Depletion table
    '
    Public Function SoilWaterDeficit(ByVal _depth As Double) As Double
        SoilWaterDeficit = InterpolateSwd(_depth)
    End Function

    Public Function ProfileSoilWaterDeficit() As Double
        Dim Depth As Double = ProfileRootZoneDepth()
        ProfileSoilWaterDeficit = SoilWaterDeficit(Depth)
    End Function
    '
    ' Calculate Leaching Requirement from Soil Water Depletion table
    '
    Public Function LeachingRequirement() As Double
        Dim _leachingFraction As Double = LeachingFraction.Value

        LeachingRequirement = ProfileSoilWaterDeficit() * _leachingFraction
    End Function
    '
    ' Calculate Irrigation Target Depth from Soil Water Depletion table
    '
    Public Function IrrigationTargetDepth() As Double
        IrrigationTargetDepth = ProfileSoilWaterDeficit() + LeachingRequirement()
    End Function

#End Region

#Region " Infiltration Table "

    '*********************************************************************************************************
    ' Find Minimum Infiltrated Depth from Infiltration table
    '*********************************************************************************************************
    Public Function MinimumInfiltrationDepth() As Double
        Dim zTable As DataTable = Infiltration.Value

        Dim Dmin As Double = MinimumInfiltrationDepth(zTable)
        Return Dmin
    End Function

    Public Shared Function MinimumInfiltrationDepth(ByVal infiltrationTable As DataTable) As Double
        Dim Dmin As Double = 0.0

        ' Validate the Infiltrated Depth table
        If (DataTableHasData(infiltrationTable)) Then
            If ((DataColumnIsDouble(infiltrationTable, sDistanceX)) _
            And (DataColumnIsDouble(infiltrationTable, sInfiltrationX))) Then

                ' Find minimum infiltrated depth
                Dmin = Double.MaxValue

                For Each row As DataRow In infiltrationTable.Rows
                    Dim Z As Double = CDbl(row.Item(sInfiltrationX))

                    If (Dmin > Z) Then
                        Dmin = Z
                    End If
                Next
            End If
        End If

        Return Dmin
    End Function

    '*********************************************************************************************************
    ' Calculate Average Infiltrated Depth from Infiltration table
    '*********************************************************************************************************
    Public Function AverageInfiltrationDepth() As Double
        Dim zTable As DataTable = Infiltration.Value
        AverageInfiltrationDepth = AverageInfiltrationDepth(zTable)
    End Function

    Public Shared Function AverageInfiltrationDepth(ByVal InfiltrationTable As DataTable) As Double
        ' Calculate infiltrated volume per unit width (i.e. 1m) (e.g infiltrated area)
        Dim Ainf As Double = DataTableIntegral(InfiltrationTable, sDistanceX, sInfiltrationX)
        ' Divide by length of infiltration to get average depth
        Dim Xspan As Double = DataColumnSpan(InfiltrationTable, sDistanceX)
        AverageInfiltrationDepth = Ainf / Xspan
    End Function

    '*********************************************************************************************************
    ' Calculate Low-Quarter Average Infiltration Depth from the Infiltration table
    '*********************************************************************************************************
    Public Function AverageInfiltrationDepthLQ() As Double
        Dim zTable As DataTable = Infiltration.Value

        Dim DavgLQ As Double = AverageInfiltrationDepthLQ(zTable)
        Return DavgLQ
    End Function
    '
    ' Calculate Low-Quarter Average Infiltration Depth from Infiltrated Depths table
    Public Shared Function AverageInfiltrationDepthLQ(ByVal infiltrationTable As DataTable) As Double
        ' Low-Quarter Average Infiltrated Depth
        Dim DavgLQ As Double = 0.0

        ' Validate the Infiltrated Depth table
        If (DataTableHasData(infiltrationTable)) Then
            If ((DataColumnIsDouble(infiltrationTable, sDistanceX)) _
            And (DataColumnIsDouble(infiltrationTable, sInfiltrationX))) Then
                '
                ' The Low-Quarter Average Infiltrated Depth is calculated as the:
                '
                '   Weighted sum of each segment's average infiltrated depth / Quarter Field Length
                '   for the Low-Quarter of the field
                '

                ' N+1 points create N segments; minimum of 1 segment (i.e. 2 points)
                Dim points As Integer = infiltrationTable.Rows.Count
                If (2 <= points) Then
                    '
                    ' Build list of segment infiltrated depths
                    '
                    Dim lengths As ArrayList = New ArrayList
                    Dim depths As ArrayList = New ArrayList

                    ' Get the start point of the 1st segment
                    Dim x1 As Double = CDbl(infiltrationTable.Rows(0).Item(sDistanceX))
                    Dim z1 As Double = CDbl(infiltrationTable.Rows(0).Item(sInfiltrationX))
                    Dim x2 As Double
                    Dim z2 As Double

                    For idx As Integer = 1 To points - 1
                        ' Get the end point of the segment
                        x2 = CDbl(infiltrationTable.Rows(idx).Item(sDistanceX))
                        z2 = CDbl(infiltrationTable.Rows(idx).Item(sInfiltrationX))

                        ' Save the segment data
                        lengths.Add(x2 - x1)           ' Length of segment
                        depths.Add((z1 + z2) / 2.0)  ' Average depth for segment

                        ' Start of the next segment is the end of the previous segment
                        x1 = x2
                        z1 = z2
                    Next
                    '
                    ' Sort list of infiltrated depths (bubble sort)
                    '
                    Dim temp As Object
                    For idx As Integer = 0 To depths.Count
                        Dim swap As Boolean = False
                        For jdx As Integer = 0 To depths.Count - 2
                            z1 = CDbl(depths(jdx))
                            z2 = CDbl(depths(jdx + 1))
                            If (z2 < z1) Then
                                ' Swap locations
                                swap = True
                                ' Swap depths
                                temp = depths(jdx)
                                depths(jdx) = depths(jdx + 1)
                                depths(jdx + 1) = temp
                                ' Swap lengths
                                temp = lengths(jdx)
                                lengths(jdx) = lengths(jdx + 1)
                                lengths(jdx + 1) = temp
                            End If
                        Next
                        If Not (swap) Then
                            Exit For
                        End If
                    Next
                    '
                    ' Sum the infiltrated depths for the Low-Quarter
                    '
                    x1 = CDbl(infiltrationTable.Rows(0).Item(sDistanceX))           ' Start of field
                    x2 = CDbl(infiltrationTable.Rows(points - 1).Item(sDistanceX)) ' End of field

                    Dim lengthLQ As Double = (x2 - x1) / 4.0
                    Dim length1 As Double = 0.0
                    Dim length2 As Double

                    For idx As Integer = 0 To depths.Count - 2
                        length2 = CDbl(lengths(idx))
                        z2 = CDbl(depths(idx))
                        If (length1 + length2 < lengthLQ) Then
                            ' Haven't reached Low-Quarter length, yet
                            length1 += length2
                            ' Sum the average segment depths weighted by the segment lengths
                            DavgLQ += z2 * length2
                        Else
                            ' Have reached Low-Quarter length; interpolate last value
                            Dim remainingLength As Double = lengthLQ - length1
                            length1 += remainingLength
                            ' Sum the average segment depths weighted by the segment lengths
                            DavgLQ += z2 * remainingLength

                            Exit For
                        End If
                    Next
                    '
                    ' Divide sum of weighted segment depths by Low-Quarter field length to get average depth
                    '
                    DavgLQ /= lengthLQ    ' / Low-Quarter Field length
                End If
            End If
        End If

        Return DavgLQ
    End Function

    '*********************************************************************************************************
    ' Calculate Deep Percolation Depth from the Infiltration table
    '*********************************************************************************************************
    Public Function DeepPercolationDepth(ByVal Dreq As Double) As Double
        Dim zTable As DataTable = Infiltration.Value

        Dim Ddp As Double = DeepPercolationDepth(zTable, Dreq)
        Return Ddp
    End Function

    Public Shared Function DeepPercolationDepth(ByVal infiltrationTable As DataTable, ByVal Dreq As Double) As Double
        ' Average Infiltrated Depth
        Dim Ddp As Double = 0.0

        ' Validate the Infiltrated Depth table
        If (DataTableHasData(infiltrationTable)) Then
            If ((DataColumnIsDouble(infiltrationTable, sDistanceX)) _
            And (DataColumnIsDouble(infiltrationTable, sInfiltrationX))) Then
                '
                ' The Deep Percolation Depth is calculated as the:
                '
                '   Infiltrated Depth area beyond the Required Depth
                '

                ' N+1 points create N segments; minimum of 1 segment (i.e. 2 points)
                Dim points As Integer = infiltrationTable.Rows.Count
                If (2 <= points) Then
                    ' Get the start point of the 1st segment
                    Dim x1 As Double = CDbl(infiltrationTable.Rows(0).Item(sDistanceX))
                    Dim z1 As Double = CDbl(infiltrationTable.Rows(0).Item(sInfiltrationX))
                    Dim x2 As Double
                    Dim z2 As Double
                    Dim delta1 As Double
                    Dim delta2 As Double

                    ' Compute Average Infiltrated Depth
                    For idx As Integer = 1 To points - 1
                        ' Get the segment's end point
                        x2 = CDbl(infiltrationTable.Rows(idx).Item(sDistanceX))
                        z2 = CDbl(infiltrationTable.Rows(idx).Item(sInfiltrationX))

                        ' Sum the average segment depths weighted by the segment lengths
                        If ((z1 < Dreq) And (Dreq < z2)) Then
                            delta2 = z2 - Dreq
                            Ddp += ((delta2 ^ 2) * (x2 - x1)) / ((z2 - z1) * 2.0)
                        ElseIf ((z2 < Dreq) And (Dreq < z1)) Then
                            delta1 = z1 - Dreq
                            Ddp += ((delta1 ^ 2) * (x2 - x1)) / ((z1 - z2) * 2.0)
                        ElseIf ((Dreq <= z1) And (Dreq <= z2)) Then
                            delta1 = z1 - Dreq
                            delta2 = z2 - Dreq
                            Ddp += ((delta1 + delta2) / 2.0) * (x2 - x1)
                        End If

                        ' Start of the next segment is the end of the previous segment
                        x1 = x2
                        z1 = z2
                    Next

                    ' Divide sum of weighted segment depths by field length to get average depth
                    x1 = CDbl(infiltrationTable.Rows(0).Item(sDistanceX))
                    x2 = CDbl(infiltrationTable.Rows(points - 1).Item(sDistanceX))
                    Ddp /= (x2 - x1)
                End If
            End If
        End If

        Return Ddp
    End Function

    '*********************************************************************************************************
    ' Calculate Length Under-Irrigated from Infiltration Depth table
    '*********************************************************************************************************
    Public Function LengthUnderIrrigrated() As Double
        Dim zTable As DataTable = Infiltration.Value
        Dim Dreq As Double = mUnit.InflowManagementRef.RequiredDepth.Value

        Dim length As Double = LengthUnderIrrigated(zTable, Dreq)
        Return length
    End Function

    Public Shared Function LengthUnderIrrigated(ByVal infiltrationTable As DataTable,
                                                ByVal Dreq As Double) As Double
        ' Length Under-irrigated
        Dim length As Double = 0.0

        ' Validate the Infiltrated Depth table
        If (DataTableHasData(infiltrationTable)) Then
            If ((DataColumnIsDouble(infiltrationTable, sDistanceX)) _
            And (DataColumnIsDouble(infiltrationTable, sInfiltrationX))) Then

                ' N+1 points create N segments; minimum of 1 segment (i.e. 2 points)
                Dim points As Integer = infiltrationTable.Rows.Count
                If (2 <= points) Then
                    Dim dataRow As DataRow = infiltrationTable.Rows(0)

                    Dim x1 As Double = CDbl(dataRow.Item(sDistanceX))
                    Dim z1 As Double = CDbl(dataRow.Item(sInfiltrationX))

                    For idx As Integer = 1 To infiltrationTable.Rows.Count - 1
                        dataRow = infiltrationTable.Rows(idx)

                        Dim x2 As Double = CDbl(dataRow.Item(sDistanceX))
                        Dim z2 As Double = CDbl(dataRow.Item(sInfiltrationX))

                        ' Sum the segment lengths
                        If ((z1 < Dreq) And (Dreq < z2)) Then
                            length += ((z2 - Dreq) * (x2 - x1)) / (z2 - z1)
                        ElseIf ((z2 < Dreq) And (Dreq < z1)) Then
                            length += ((z1 - Dreq) * (x2 - x1)) / (z1 - z2)
                        ElseIf ((z1 < Dreq) And (z2 < Dreq)) Then
                            length += x2 - x1
                        End If

                        x1 = x2
                        z1 = z2
                    Next
                End If
            End If
        End If

        Return length
    End Function

    '*********************************************************************************************************
    ' Function InfiltratedVolume() - Calculate Infiltrated Volume from Infiltrated Depth table
    '
    ' Input(s):         InfiltrationTable   - table of Distance vs. Depth values
    '                   SigmaZ              - optional weighting parameter for 'tip' delta X
    '
    ' Returns:          Double              - Infiltrated volume per unit width
    '*********************************************************************************************************
    Public Function InfiltratedVolume(ByVal InfiltrationTable As DataTable,
                                      Optional ByVal SigmaZ As Double = 0.5) As Double
        InfiltratedVolume = 0.0

        If (InfiltrationTable IsNot Nothing) Then
            If (0 < InfiltrationTable.Rows.Count) Then
                Dim row As DataRow = InfiltrationTable.Rows(0)

                ' Get 1st distance/depth values
                Dim dist1 As Double = CDbl(InfiltrationTable.Rows(0).Item(0))
                Dim depth1 As Double = CDbl(InfiltrationTable.Rows(0).Item(1))

                Dim upperBound As Integer = InfiltrationTable.Rows.Count - 1

                ' Integrate area curve to determine infiltrated volume
                Dim c As Double = Me.KostiakovC
                If (SrfrInfiltration IsNot Nothing) Then
                    c = SrfrInfiltration.c
                End If

                For rdx As Integer = 1 To upperBound
                    row = InfiltrationTable.Rows(rdx)

                    ' Get segment's end distance/depth values
                    Dim dist2 As Double = CDbl(row.Item(0))
                    Dim depth2 As Double = CDbl(row.Item(1))

                    ' Calc area for segment and add to volume
                    If ((rdx = upperBound) And (depth2 <= c)) Then ' this is 'tip' delta x
                        InfiltratedVolume += (depth1 * (dist2 - dist1)) * SigmaZ ' use SigmaZ to get volume
                    Else
                        InfiltratedVolume += ((depth2 + depth1) * (dist2 - dist1)) / 2.0 ' trapezoid rule
                    End If

                    ' Save end values of current segment as start of next segment
                    dist1 = dist2
                    depth1 = depth2
                Next
            End If
        End If

    End Function

#End Region

#Region " Infiltrated Depth Table "
    '
    ' Find Minimum Infiltrated Depth from Infiltrated Depth table
    '
    Public Function MinimumInfiltratedDepth() As Double
        MinimumInfiltratedDepth = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            Dim count As Integer = idTable.Rows.Count
            If (0 < count) Then

                ' Find Minimum Infiltrated Depth
                Dim row As DataRow = idTable.Rows(0)
                MinimumInfiltratedDepth = CDbl(row.Item(sProfileIdX))

                For rdx As Integer = 1 To count - 1
                    row = idTable.Rows(rdx)
                    Dim Depth As Double = CDbl(row.Item(sProfileIdX))
                    If (MinimumInfiltratedDepth > Depth) Then
                        MinimumInfiltratedDepth = Depth
                    End If
                Next
            End If
        End If
    End Function
    '
    ' Calculate Low-Quarter Average Infiltrated Depth from Infiltrated Depth table
    '
    Public Function AverageInfiltratedDepthLQ() As Double
        AverageInfiltratedDepthLQ = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            Dim count As Integer = idTable.Rows.Count
            If (0 < count) Then
                Dim countLQ As Integer = CInt(Math.Max(count / 4, 1))
                Dim depthLQ As Double = 0.0

                ' Compute Average Infiltrated Depth for 1st Low-Quarter
                For rdx As Integer = 0 To countLQ - 1
                    Dim _idRow As DataRow = idTable.Rows(rdx)
                    depthLQ += CDbl(_idRow.Item(sUsefulIdX))
                Next
                AverageInfiltratedDepthLQ = depthLQ / countLQ

                ' Slide the Low-Quarter down the field looking for the lowest one
                If (countLQ < count) Then
                    For rdx As Integer = countLQ To count - 1
                        Dim row1 As DataRow = idTable.Rows(rdx - countLQ)
                        Dim row2 As DataRow = idTable.Rows(rdx)
                        Dim usefulDepth1 As Double = CDbl(row1.Item(sUsefulIdX))
                        Dim usefulDepth2 As Double = CDbl(row2.Item(sUsefulIdX))
                        depthLQ += (usefulDepth2 - usefulDepth1)

                        ' Is this a new Low-Quarter average depth?
                        If (AverageInfiltratedDepthLQ > depthLQ / countLQ) Then
                            AverageInfiltratedDepthLQ = depthLQ / countLQ
                        End If
                    Next
                End If
            End If
        End If
    End Function
    '
    ' Calculate Profile Infiltrated Volume / Depth from Infiltrated Depth table
    '
    Public Function ProfileInfiltratedVolume() As Double
        ProfileInfiltratedVolume = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            If (0 < idTable.Rows.Count) Then
                Dim row As DataRow = idTable.Rows(0)

                Dim dist1 As Double = CDbl(idTable.Rows(0).Item(sDistanceX))
                Dim profileDepth1 As Double = CDbl(idTable.Rows(0).Item(sProfileIdX))

                For rdx As Integer = 1 To idTable.Rows.Count - 1
                    row = idTable.Rows(rdx)

                    Dim dist2 As Double = CDbl(row.Item(sDistanceX))
                    Dim profileDepth2 As Double = CDbl(row.Item(sProfileIdX))

                    ProfileInfiltratedVolume += ((profileDepth2 + profileDepth1) * (dist2 - dist1)) / 2.0

                    dist1 = dist2
                    profileDepth1 = profileDepth2
                Next
            End If
        End If
    End Function

    Public Function ProfileInfiltratedDepth() As Double
        ProfileInfiltratedDepth = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            If (0 < idTable.Rows.Count) Then
                Dim lastRow As DataRow = idTable.Rows(idTable.Rows.Count - 1)
                Dim fieldLength As Double = CDbl(lastRow.Item(sDistanceX))

                ProfileInfiltratedDepth = ProfileInfiltratedVolume() / fieldLength
            End If
        End If
    End Function
    '
    ' Calculate Root Zone Infiltrated Volume / Depth from Infiltrated Depth table
    '
    Public Function RootZoneInfiltratedVolume() As Double
        RootZoneInfiltratedVolume = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If Not (idTable Is Nothing) Then
            If (0 < idTable.Rows.Count) Then
                Dim row As DataRow = idTable.Rows(0)

                Dim dist1 As Double = CDbl(row.Item(sDistanceX))
                Dim rootZoneDepth1 As Double = CDbl(row.Item(sRootZoneIdX))

                For rdx As Integer = 1 To idTable.Rows.Count - 1
                    row = idTable.Rows(rdx)

                    Dim dist2 As Double = CDbl(row.Item(sDistanceX))
                    Dim rootZoneDepth2 As Double = CDbl(row.Item(sRootZoneIdX))

                    RootZoneInfiltratedVolume += ((rootZoneDepth2 + rootZoneDepth1) * (dist2 - dist1)) / 2.0

                    dist1 = dist2
                    rootZoneDepth1 = rootZoneDepth2
                Next
            End If
        End If
    End Function

    Public Function RootZoneInfiltratedDepth() As Double
        RootZoneInfiltratedDepth = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            If (0 < idTable.Rows.Count) Then
                Dim lastRow As DataRow = idTable.Rows(idTable.Rows.Count - 1)
                Dim fieldLength As Double = CDbl(lastRow.Item(sDistanceX))

                RootZoneInfiltratedDepth = RootZoneInfiltratedVolume() / fieldLength
            End If
        End If
    End Function
    '
    ' Calculate Useful Infiltrated Volume / Depth from Infiltrated Depth table
    '
    Public Function UsefulInfiltratedVolume() As Double
        UsefulInfiltratedVolume = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            If (0 < idTable.Rows.Count) Then
                Dim row As DataRow = idTable.Rows(0)

                Dim dist1 As Double = CDbl(row.Item(sDistanceX))
                Dim usefulDepth1 As Double = CDbl(row.Item(sUsefulIdX))

                For rdx As Integer = 1 To idTable.Rows.Count - 1
                    row = idTable.Rows(rdx)

                    Dim dist2 As Double = CDbl(row.Item(sDistanceX))
                    Dim usefulDepth2 As Double = CDbl(row.Item(sUsefulIdX))

                    UsefulInfiltratedVolume += ((usefulDepth2 + usefulDepth1) * (dist2 - dist1)) / 2.0

                    dist1 = dist2
                    usefulDepth1 = usefulDepth2
                Next
            End If
        End If
    End Function

    Public Function UsefulInfiltratedDepth() As Double
        UsefulInfiltratedDepth = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            If (0 < idTable.Rows.Count) Then
                Dim lastRow As DataRow = idTable.Rows(idTable.Rows.Count - 1)
                Dim fieldLength As Double = CDbl(lastRow.Item(sDistanceX))

                UsefulInfiltratedDepth = UsefulInfiltratedVolume() / fieldLength
            End If
        End If
    End Function
    '
    ' Calculate Deep Percolation Volume / Depth from Infiltrated Depth table
    '
    Public Function DeepPercolationVolume() As Double
        DeepPercolationVolume = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            If (0 < idTable.Rows.Count) Then
                Dim row As DataRow = idTable.Rows(0)

                Dim dist1 As Double = CDbl(row.Item(sDistanceX))
                Dim dpDepth1 As Double = CDbl(row.Item(sDeepPercIdX))

                For rdx As Integer = 1 To idTable.Rows.Count - 1
                    row = idTable.Rows(rdx)

                    Dim dist2 As Double = CDbl(row.Item(sDistanceX))
                    Dim dpDepth2 As Double = CDbl(row.Item(sDeepPercIdX))

                    DeepPercolationVolume += ((dpDepth2 + dpDepth1) * (dist2 - dist1)) / 2.0

                    dist1 = dist2
                    dpDepth1 = dpDepth2
                Next
            End If
        End If
    End Function

    Public Function DeepPercolationDepth() As Double
        DeepPercolationDepth = 0.0

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            If (0 < idTable.Rows.Count) Then
                Dim lastRow As DataRow = idTable.Rows(idTable.Rows.Count - 1)
                Dim fieldLength As Double = CDbl(lastRow.Item(sDistanceX))

                DeepPercolationDepth = DeepPercolationVolume() / fieldLength
            End If
        End If
    End Function
    '
    ' Calculate the Leaching Infiltrated Depth (Useful Depth - Root Zone Depth)
    '
    Public Function LeachingInfiltratedDepth() As Double
        Dim usefulDepth As Double = UsefulInfiltratedDepth()
        Dim rootZoneDepth As Double = rootZoneDepth
        LeachingInfiltratedDepth = usefulDepth - rootZoneDepth
    End Function
    '
    ' Derive Probe Infiltration table from Infiltrated Depth table
    '
    Public Function ProbeInfiltrationTable() As DataTable
        Dim infiltratedDepthTable As DataTable = InfiltratedDepth.Value

        If (infiltratedDepthTable IsNot Nothing) Then

            ' Extract the Probe Infiltration Table from the Infiltrated Depth Table
            Dim probeTable As DataTable = New DataTable("Probe Penetration Depth")

            probeTable.Columns.Add(sDistanceX, GetType(Double))
            probeTable.Columns.Add(sInfiltrationX, GetType(Double))

            For Each infRow As DataRow In infiltratedDepthTable.Rows
                Dim probeRow As DataRow = probeTable.NewRow
                probeRow.Item(sDistanceX) = infRow.Item(sDistanceX)
                probeRow.Item(sInfiltrationX) = infRow.Item(sProbedDepthX)

                probeTable.Rows.Add(probeRow)
            Next

            Return probeTable
        End If

        Return Nothing
    End Function
    '
    ' Derive Root Zone Infiltration table from Infiltrated Depth table
    '
    Public Function RootZoneInfiltrationTable() As DataTable
        Dim infiltratedDepthTable As DataTable = InfiltratedDepth.Value

        If Not (infiltratedDepthTable Is Nothing) Then

            ' Extract the Root Zone Infiltration Table from the Infiltrated Depth Table
            Dim rootZoneTable As DataTable = New DataTable("Root Zone Infiltrated Depth")

            rootZoneTable.Columns.Add(sDistanceX, GetType(Double))
            rootZoneTable.Columns.Add(sInfiltrationX, GetType(Double))

            For Each infRow As DataRow In infiltratedDepthTable.Rows
                Dim rootZoneRow As DataRow = rootZoneTable.NewRow
                rootZoneRow.Item(sDistanceX) = infRow.Item(sDistanceX)
                rootZoneRow.Item(sInfiltrationX) = infRow.Item(sRootZoneIdX)

                rootZoneTable.Rows.Add(rootZoneRow)
            Next

            Return rootZoneTable
        End If

        Return Nothing
    End Function
    '
    ' Derive Useful Infiltration table from Infiltrated Depth table
    '
    Public Function UsefulInfiltrationTable() As DataTable
        Dim infiltratedDepthTable As DataTable = InfiltratedDepth.Value

        If Not (infiltratedDepthTable Is Nothing) Then
            If (2 < infiltratedDepthTable.Rows.Count) Then

                ' Extract the Useful Infiltration Table from the Infiltrated Depth Table
                Dim usefulTable As DataTable = New DataTable("Useful Infiltrated Depth")

                usefulTable.Columns.Add(sDistanceX, GetType(Double))
                usefulTable.Columns.Add(sInfiltrationX, GetType(Double))

                For Each infRow As DataRow In infiltratedDepthTable.Rows
                    Dim usefulRow As DataRow = usefulTable.NewRow
                    usefulRow.Item(sDistanceX) = infRow.Item(sDistanceX)
                    usefulRow.Item(sInfiltrationX) = infRow.Item(sUsefulIdX)

                    usefulTable.Rows.Add(usefulRow)
                Next

                Return usefulTable
            End If
        End If

        Return Nothing
    End Function
    '
    ' Calculate Length Under-irrigated
    '
    Public Function LengthUnderIrrigated() As Double
        LengthUnderIrrigated = 0.0

        Dim Dreq As Double = IrrigationTargetDepth()

        Dim idTable As DataTable = InfiltratedDepth.Value
        If (idTable IsNot Nothing) Then
            If (0 < idTable.Rows.Count) Then
                Dim row As DataRow = idTable.Rows(0)

                Dim dist1 As Double = CDbl(row.Item(sDistanceX))
                Dim usefulDepth1 As Double = CDbl(row.Item(sUsefulIdX))

                For rdx As Integer = 1 To idTable.Rows.Count - 1
                    row = idTable.Rows(rdx)

                    Dim dist2 As Double = CDbl(row.Item(sDistanceX))
                    Dim usefulDepth2 As Double = CDbl(row.Item(sUsefulIdX))

                    If ((usefulDepth1 < Dreq) _
                     Or (usefulDepth2 < Dreq)) Then
                        LengthUnderIrrigated += (dist2 - dist1)
                    End If

                    dist1 = dist2
                    usefulDepth1 = usefulDepth2
                Next
            End If
        End If
    End Function

    '*********************************************************************************************************
    ' Function InfiltratedDepthProfile() - Calculate an Infiltrated Depth Profile (Z vs. Distance) based on
    ' an Opportunity Time Profile
    '
    ' Input(s):     OpportunityTimeProfile  - table of Distance vs. Opportunity time values
    '
    ' Returns:      DataTable               - Infiltrated Depth Profile
    '*********************************************************************************************************
    Public Function InfiltratedDepthProfile(ByVal OpportunityTimeProfile As DataTable) As DataTable

        InfiltratedDepthProfile = Nothing

        If (OpportunityTimeProfile IsNot Nothing) Then

            InfiltratedDepthProfile = New DataTable(OpportunityTimeProfile.TableName)
            InfiltratedDepthProfile.Columns.Add(sDistanceX, GetType(Double))
            InfiltratedDepthProfile.Columns.Add(sDepthX, GetType(Double))

            If (OpportunityTimeProfile.ExtendedProperties.Contains(sTimeX)) Then
                Dim time As Double = OpportunityTimeProfile.ExtendedProperties(sTimeX)
                InfiltratedDepthProfile.ExtendedProperties.Add(sTimeX, time)
            End If

            For Each oppRow As DataRow In OpportunityTimeProfile.Rows
                Dim oppDist As Double = oppRow.Item(0)
                Dim oppTime As Double = oppRow.Item(1)

                Dim infDepth As Double = Me.InfiltrationDepth(oppTime)

                Dim infRow As DataRow = InfiltratedDepthProfile.NewRow
                infRow.Item(sDistanceX) = oppDist
                infRow.Item(sDepthX) = infDepth
                InfiltratedDepthProfile.Rows.Add(infRow)

                If (0.0 = oppTime) Then ' at the 'tip' distance
                    Exit For
                End If
            Next oppRow

        End If

    End Function

    '*********************************************************************************************************
    ' Function InfiltratedDepthProfile() - Calculate an Infiltrated Depth Profile (Distance vs. Z) based on
    ' an Opportunity Time Profile and a Flow Depth Hydrograph
    '
    ' Input(s):     OpportunityTimeProfile  - table of Distance vs. Opportunity time values
    '               FlowDepthHydrographs    - DataSet of Flow Depth Hydrograph (Time vs. Y)
    '            or RerSrfrAPI              - Reference SRFR simulation (source of Flow Depth Hydrographs)
    '
    ' Returns:      DataTable               - Infiltrated Depth Profile
    '*********************************************************************************************************
    Public Function InfiltratedDepthProfile(ByVal OpportunityTimeProfile As DataTable, _
                                            ByVal FlowDepthHydrographs As DataSet) As DataTable
        InfiltratedDepthProfile = Nothing

        Try
            If ((OpportunityTimeProfile IsNot Nothing) And (FlowDepthHydrographs IsNot Nothing)) Then

                Debug.Assert(OpportunityTimeProfile.Rows.Count = FlowDepthHydrographs.Tables.Count)

                InfiltratedDepthProfile = New DataTable(OpportunityTimeProfile.TableName)
                InfiltratedDepthProfile.Columns.Add(sDistanceX, GetType(Double))
                InfiltratedDepthProfile.Columns.Add(sDepthX, GetType(Double))

                If (OpportunityTimeProfile.ExtendedProperties.Contains(sTimeX)) Then
                    Dim time As Double = OpportunityTimeProfile.ExtendedProperties(sTimeX)
                    InfiltratedDepthProfile.ExtendedProperties.Add(sTimeX, time)
                End If

                Dim hdx As Integer = 0
                For Each oppRow As DataRow In OpportunityTimeProfile.Rows
                    Dim oppDist As Double = oppRow.Item(0)
                    Dim oppTime As Double = oppRow.Item(1)

                    Dim flowDepthHydrograph As DataTable = FlowDepthHydrographs.Tables(hdx)
                    Dim infDepth As Double = Me.InfiltrationDepth(oppTime, flowDepthHydrograph)

                    Dim infRow As DataRow = InfiltratedDepthProfile.NewRow
                    infRow.Item(sDistanceX) = oppDist
                    infRow.Item(sDepthX) = infDepth
                    InfiltratedDepthProfile.Rows.Add(infRow)

                    If (0.0 = oppTime) Then ' at the 'tip' distance
                        Exit For
                    End If

                    hdx += 1
                Next oppRow
            End If

        Catch ex As Exception
            InfiltratedDepthProfile = Nothing
        End Try
    End Function

    Public Function InfiltratedDepthProfile(ByVal OpportunityTimeProfile As DataTable, _
                                            ByVal RefSrfrAPI As Srfr.SrfrAPI) As DataTable
        InfiltratedDepthProfile = Nothing

        Try
            If ((OpportunityTimeProfile IsNot Nothing) And (RefSrfrAPI IsNot Nothing)) Then

                InfiltratedDepthProfile = New DataTable(OpportunityTimeProfile.TableName)
                InfiltratedDepthProfile.Columns.Add(sDistanceX, GetType(Double))
                InfiltratedDepthProfile.Columns.Add(sDepthX, GetType(Double))

                If (OpportunityTimeProfile.ExtendedProperties.Contains(sTimeX)) Then
                    Dim time As Double = OpportunityTimeProfile.ExtendedProperties(sTimeX)
                    InfiltratedDepthProfile.ExtendedProperties.Add(sTimeX, time)
                End If

                For Each oppRow As DataRow In OpportunityTimeProfile.Rows
                    Dim oppDist As Double = oppRow.Item(0)
                    Dim oppTime As Double = oppRow.Item(1)

                    Dim flowDepthHydrograph As DataTable = RefSrfrAPI.Irrigation.Hydrographs("Y", oppDist)

                    Dim infDepth As Double = Me.InfiltrationDepth(oppTime, flowDepthHydrograph)

                    Dim infRow As DataRow = InfiltratedDepthProfile.NewRow
                    infRow.Item(sDistanceX) = oppDist
                    infRow.Item(sDepthX) = infDepth
                    InfiltratedDepthProfile.Rows.Add(infRow)

                    If (0.0 = oppTime) Then ' at the 'tip' distance
                        Exit For
                    End If
                Next oppRow
            End If

        Catch ex As Exception
            InfiltratedDepthProfile = Nothing
        End Try
    End Function
    '
    ' Calculate an Infiltrated Volume Profile (Vz vs. Distance) based on an Infiltrated Depth Profile
    '
    Public Function InfiltratedVolumeProfile(ByVal InfiltratedDepthProfile As DataTable) As DataTable
        InfiltratedVolumeProfile = Nothing

        If (InfiltratedDepthProfile IsNot Nothing) Then
            If (InfiltratedDepthProfile.ExtendedProperties.Contains(sTimeX)) Then

                Dim time As Double = InfiltratedDepthProfile.ExtendedProperties(sTimeX)

                If (1 < InfiltratedDepthProfile.Rows.Count) Then

                    InfiltratedVolumeProfile = New DataTable(InfiltratedDepthProfile.TableName)
                    InfiltratedVolumeProfile.Columns.Add(sDistanceX, GetType(Double))
                    InfiltratedVolumeProfile.Columns.Add(sVz, GetType(Double))
                    InfiltratedVolumeProfile.ExtendedProperties.Add(sTimeX, time)

                    Dim depthRow As DataRow = InfiltratedDepthProfile.Rows(0)
                    Dim infDist1 As Double = depthRow.Item(sDistanceX)
                    Dim infDepth1 As Double = depthRow.Item(sDepthX)

                    Dim sigmaZ As Double = 1.0 / (1.0 + KostiakovA())
                    Dim W As Double = mUnit.SystemGeometryRef.WidthForCrossSection ' Border Width | Furrow Spacing

                    For ddx As Integer = 1 To InfiltratedDepthProfile.Rows.Count - 1
                        depthRow = InfiltratedDepthProfile.Rows(ddx)

                        Dim infDist2 As Double = depthRow.Item(sDistanceX)
                        Dim infDepth2 As Double = depthRow.Item(sDepthX)

                        Dim infArea As Double = 0
                        If (0.0 = infDepth2) Then
                            infArea = infDepth1 * sigmaZ * W
                        Else
                            infArea = (infDepth1 + infDepth2) * W / 2.0
                        End If

                        Dim infVolume As Double = (infDist2 - infDist1) * infArea

                        Dim infRow As DataRow = InfiltratedVolumeProfile.NewRow
                        infRow.Item(sDistanceX) = infDist1
                        infRow.Item(sVz) = infVolume
                        InfiltratedVolumeProfile.Rows.Add(infRow)

                        infDist1 = infDist2
                        infDepth1 = infDepth2
                    Next ddx
                End If
            End If
        End If

    End Function

    Public Function InfiltratedVolumeProfiles(ByVal InfiltratedDepthProfiles As DataSet) As DataSet
        InfiltratedVolumeProfiles = Nothing

        If (InfiltratedDepthProfiles IsNot Nothing) Then
            If (0 < InfiltratedDepthProfiles.Tables.Count) Then

                InfiltratedVolumeProfiles = New DataSet("Infiltrated Volume Profiles")

                For Each infDepthProfile As DataTable In InfiltratedDepthProfiles.Tables
                    Dim infProfile As DataTable = Me.InfiltratedVolumeProfile(infDepthProfile)
                    If (infProfile IsNot Nothing) Then

                        InfiltratedVolumeProfiles.Tables.Add(infProfile)
                    End If
                Next infDepthProfile
            End If
        End If

    End Function
    '
    ' Calculate Infiltration Hydrograph (Vz vs. Time) based on Infiltrated Profiles
    '
    Public Function InfiltrationHydrograph(ByVal InfiltratedVolumeProfiles As DataSet) As DataTable
        InfiltrationHydrograph = Nothing

        If (InfiltratedVolumeProfiles IsNot Nothing) Then
            If (0 < InfiltratedVolumeProfiles.Tables.Count) Then

                InfiltrationHydrograph = New DataTable("Infiltration Profile")
                InfiltrationHydrograph.Columns.Add(sTimeX, GetType(Double))
                InfiltrationHydrograph.Columns.Add(sVz, GetType(Double))

                For Each infVolProfile As DataTable In InfiltratedVolumeProfiles.Tables
                    If (infVolProfile.ExtendedProperties.Contains(sTimeX)) Then

                        Dim time As Double = infVolProfile.ExtendedProperties(sTimeX)
                        Dim VzSum As Double = DataColumnSum(infVolProfile, sVz)

                        Dim infRow As DataRow = InfiltrationHydrograph.NewRow
                        infRow.Item(sTimeX) = time
                        infRow.Item(sVz) = VzSum
                        InfiltrationHydrograph.Rows.Add(infRow)

                    End If
                Next infVolProfile

            End If
        End If
    End Function

#End Region

#Region " Erosion "
    '
    ' Compute TauC based on Unit's data
    '
    Public Function ComputedErodibilityTauC() As Double
        Dim _erosion As Erosion = mUnit.ErosionRef

        ' Constants
        Const g As Double = AccelerationDueToGravity
        Const rho As Double = MassDensityOfWater

        ' Unit parameters
        Dim v As Double = _erosion.KinematicViscosity.Value
        Dim n As Double = Me.ManningN.Value
        Dim S0 As Double = mUnit.SystemGeometryRef.AverageSlope
        Dim W As Double = mUnit.SystemGeometryRef.Width.Value
        Dim Ymax As Double = mUnit.SystemGeometryRef.MaximumDepth.Value
        Dim Qin As Double = mUnit.InflowManagementRef.AverageInflowRateForCrossSection

        Dim geometry As Srfr.BorderStrip = New Srfr.BorderStrip
        geometry.BorderWidth = W

        Dim roughness As Srfr.ManningN = New Srfr.ManningN
        roughness.Cn = n

        ' Normal Depth & Hydraulic Radius
        Dim yn, R As Double
        Select Case (mUnit.CrossSection)
            Case CrossSections.Furrow
                yn = mUnit.SystemGeometryRef.FurrowNormalDepth(S0, n, Qin)
                R = mUnit.SystemGeometryRef.FurrowHydraulicRadius(yn)
            Case Else ' Basin / Border
                yn = Srfr.SrfrAPI.NormalDepth(Qin, S0, geometry, roughness)
                R = Srfr.SrfrAPI.BorderStripHydraulicRadius(yn, Ymax, W)
        End Select

        ' 50% Representative Particle Size & Specific Gravity
        Dim Ds As Double = Me.RepresentativeParticleSize(0.5)
        Dim Sg As Double = Me.RepresentativeSpecificGravity(0.5)

        ' Renolds Number
        Dim Rn As Double = (Math.Sqrt(g * R * S0) * Ds) / v

        ' TauD - Dimensionless Critical Sheer for Renolds Number
        Dim TauD As Double = Me.CriticalShear(Ds, Sg, Rn)

        ' TauC
        Dim TauC As Double = TauD * rho * g * (Sg - 1.0) * Ds

        Return TauC
    End Function

    Public Function RepresentativeParticleSize(ByVal retainedPct As Double) As Double
        Dim Ds As Double = 0.00005

        Debug.Assert(0.0 < retainedPct And retainedPct < 1.0)

        Dim sedimentComponents As DataTable = Me.SedimentComponents.Value

        If Not (sedimentComponents Is Nothing) Then
            If (0 < sedimentComponents.Rows.Count) Then
                Dim row As DataRow = sedimentComponents.Rows(0)
                Dim pct1 As Double = row.Item(sPercentRetainedX)
                Dim Ds1 As Double
                Try
                    Ds1 = row.Item(sSieveSizeX)
                Catch ex As Exception
                    Ds1 = row.Item("Sieve Size (mm)") / 1000.0
                End Try

                Dim pct2 As Double = pct1
                Dim Ds2 As Double = Ds1

                If (retainedPct <= pct1) Then
                    ' Retained Percent within first row
                    Ds = Ds1
                Else
                    ' Retained Percent after first row
                    For idx As Integer = 1 To sedimentComponents.Rows.Count - 1
                        row = sedimentComponents.Rows(idx)
                        pct2 = row.Item(sPercentRetainedX)
                        Try
                            Ds2 = row.Item(sSieveSizeX)
                        Catch ex As Exception
                            Ds2 = row.Item("Sieve Size (mm)") / 1000.0
                        End Try

                        If (retainedPct <= pct1 + pct2) Then
                            Exit For
                        End If

                        pct1 += pct2
                        Ds1 = Ds2
                    Next

                    If (retainedPct <= pct1 + pct2) Then
                        ' Retained Percent within table
                        Ds = Ds1 - (((retainedPct - pct1) / pct2) * (Ds1 - Ds2))
                    Else
                        ' Retained Percent after last row
                        Ds = Ds2 - (((retainedPct - (pct1 + pct2)) / 100) * Ds2)
                    End If
                End If
            End If
        End If

        Return Ds
    End Function

    Public Function RepresentativeSpecificGravity(ByVal retainedPct As Double) As Double
        Dim Sg As Double = SpecificGravityOfSand

        Debug.Assert(0.0 < retainedPct And retainedPct < 1.0)

        Dim sedimentComponents As DataTable = Me.SedimentComponents.Value

        If Not (sedimentComponents Is Nothing) Then
            If (0 < sedimentComponents.Rows.Count) Then
                Dim row As DataRow = sedimentComponents.Rows(0)
                Dim pct1 As Double = row.Item(sPercentRetainedX)
                Dim Sg1 As Double = row.Item(sSpecificGravityX)

                Dim pct2 As Double = pct1
                Dim Sg2 As Double = Sg1

                If (retainedPct <= pct1) Then
                    ' Retained Percent within first row
                    Sg = Sg1
                Else
                    ' Retained Percent after first row
                    For idx As Integer = 1 To sedimentComponents.Rows.Count - 1
                        row = sedimentComponents.Rows(idx)
                        pct2 = row.Item(sPercentRetainedX)
                        Sg2 = row.Item(sSpecificGravityX)

                        If (retainedPct <= pct1 + pct2) Then
                            Exit For
                        End If

                        pct1 += pct2
                        Sg1 = Sg2
                    Next

                    If (retainedPct <= pct1 + pct2) Then
                        ' Retained Percent within table
                        Sg = Sg1 - (((retainedPct - pct1) / pct2) * (Sg1 - Sg2))
                    Else
                        ' Retained Percent after last row
                        Sg = Sg2 - (((retainedPct - (pct1 + pct2)) / 100) * Sg2)
                    End If
                End If
            End If
        End If

        Return Sg
    End Function
    '
    ' Calculate Critical Shear stress per Shields entrainment function
    '
    ' Inputs:   Ds  - representative particle size
    '           Sg  -        "       specific gravity
    '           Rn  - Renolds number
    '
    Public Function CriticalShear(ByVal Ds As Double, ByVal Sg As Double, ByVal Rn As Double) As Double

        ' Verify input parameters
        Debug.Assert(0.0 < Ds And 0.0 < Sg And 0.0 < Rn)

        ' Constants
        Const g As Double = AccelerationDueToGravity
        Const rho As Double = MassDensityOfWater
        Const gamma As Double = rho * g

        ' Calculate Shields function
        Dim fs As Double
        If (Rn < 1.3) Then
            fs = 0.1118 / Rn
        ElseIf (550.0 < Rn) Then
            fs = 0.06
        Else
            Dim xi As Double = Math.Log10(Rn)
            Dim eta As Double = (-0.1277 * xi ^ 3) + (0.7372 * xi ^ 2) + (-1.163 * xi) + (-0.9424)

            fs = 10.0 ^ eta
        End If

        ' Calculate TauD
        Dim TauD As Double = fs * gamma * (Sg - 1) * Ds

        Return TauD
    End Function

#End Region

#End Region

#Region " Constructor(s) "

    Public Sub New(ByVal _myID As String, ByVal _unit As Unit)
        '
        ' Verify data structures' sizes
        '
        Debug.Assert(InfiltrationFunctions.HighLimit = InfiltrationFunctionSelections.Length)
        Debug.Assert(RoughnessMethods.HighLimit = RoughnessMethodSelections.Length)
        '
        ' Save ID
        '
        If (_myID IsNot Nothing) Then
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
        If (_unit IsNot Nothing) Then
            mUnit = _unit
            mParentStore = mUnit.MyStore
            mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Add SoilCropProperties to Parent's Data Store
        '
        If (mParentStore IsNot Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If (mMyStore IsNot Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "SoilCropProperties not added to Data Store")
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
        If (_unit IsNot Nothing) Then
            mUnit = _unit
            mParentStore = mUnit.MyStore
            mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Restore MyStore
        '
        If (_myStore IsNot Nothing) Then
            ' Restore identification
            mMyStore = _myStore
            mMyID = mMyStore.MyID

            ' Restore the Kostiakov k -> Kostiakov a linkages
            Dim _parameter As Parameter
            Dim _kostiakovK As KostiakovKParameter

            ' Branch Function (BF)
            _parameter = KostiakovK_BFProperty.GetParameter()

            If (_parameter.GetType Is GetType(KostiakovKParameter)) Then
                _kostiakovK = DirectCast(_parameter, KostiakovKParameter)
                _kostiakovK.KostiakovA = KostiakovA_BFProperty
            Else
                Debug.Assert(False, "Parameter is not Kostiakov K")
            End If

            ' Characteristic Infiltration Time (KF)
            _parameter = KostiakovK_KFProperty.GetParameter()

            If (_parameter.GetType Is GetType(KostiakovKParameter)) Then
                _kostiakovK = DirectCast(_parameter, KostiakovKParameter)
                _kostiakovK.KostiakovA = KostiakovA_KFProperty
            Else
                Debug.Assert(False, "Parameter is not Kostiakov K")
            End If

            ' Modified Kostiakov Formula (MK)
            _parameter = KostiakovK_MKProperty.GetParameter()

            If (_parameter.GetType Is GetType(KostiakovKParameter)) Then
                _kostiakovK = DirectCast(_parameter, KostiakovKParameter)
                _kostiakovK.KostiakovA = KostiakovA_MKProperty
            Else
                Debug.Assert(False, "Parameter is not Kostiakov K")
            End If

            ' Enable event generation
            mMyStore.EventsEnabled = True
        Else
            Debug.Assert(False, "MyStore is Nothing")
        End If
    End Sub

#End Region

#Region " Methods "
    '
    ' Check if Wetted Perimiter / Infiltration Equation are defaulted
    '
    Public Function InfiltrationParameterAreDefault() As Boolean
        InfiltrationParameterAreDefault = True

        If Not (Me.WettedPerimeterMethod.Source = ValueSources.Defaulted) Then
            InfiltrationParameterAreDefault = False
            Exit Function
        End If

        If Not (Me.InfiltrationFunction.Source = ValueSources.Defaulted) Then
            InfiltrationParameterAreDefault = False
            Exit Function
        End If

        If Not (Me.EnableLimitingDepth.Source = ValueSources.Defaulted) Then
            InfiltrationParameterAreDefault = False
            Exit Function
        End If

        If Not (Me.EnableTabulatedInfiltration.Source = ValueSources.Defaulted) Then
            InfiltrationParameterAreDefault = False
            Exit Function
        End If

        Dim infFunc As InfiltrationFunctions = Me.InfiltrationFunction.Value

        Select Case (infFunc)
            Case InfiltrationFunctions.BranchFunction

                If Not (Me.KostiakovA_BF.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.BranchB_BF.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.KostiakovC_BF.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.KostiakovK_BF.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

            Case InfiltrationFunctions.CharacteristicInfiltrationTime

                If Not (Me.InfiltrationDepth_KT.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.InfiltrationTime_KT.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.KostiakovA_KT.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

            Case InfiltrationFunctions.GreenAmpt

                If Not (Me.SoilTextureSelectionGA.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.EffectivePorosityGA.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.InitialWaterContentGA.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.WettingFrontPressureHeadGA.Source = False) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.HydraulicConductivityGA.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.GreenAmptC.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

            Case InfiltrationFunctions.Hydrus1D
                Debug.Assert(False)

            Case InfiltrationFunctions.KostiakovFormula

                If Not (Me.KostiakovA_KF.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.KostiakovK_KF.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

            Case InfiltrationFunctions.ModifiedKostiakovFormula

                If Not (Me.KostiakovA_MK.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.KostiakovB_MK.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.KostiakovC_MK.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.KostiakovK_MK.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

            Case InfiltrationFunctions.NRCSIntakeFamily

                If Not (Me.NrcsIntakeFamily.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

            Case InfiltrationFunctions.TimeRatedIntakeFamily

                If Not (Me.InfiltrationTime_TR.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

            Case InfiltrationFunctions.WarrickGreenAmpt

                If Not (Me.SaturatedWaterContentWGA.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.InitialWaterContentWGA.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.WettingFrontPressureHeadWGA.Source = False) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.HydraulicConductivityWGA.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

                If Not (Me.WarrickGreenAmptC.Source = ValueSources.Defaulted) Then
                    InfiltrationParameterAreDefault = False
                End If

        End Select

    End Function
    '
    ' Clear all large ArrayList and DataTable results data from the DataStore
    '
    Public Sub ClearResults()
        Me.ClearHydrusConcentration()
        Me.ClearHydrusInfiltrationDepth()
        Me.ClearHydrusInfiltrationRate()
        mMyStore.DeleteProperty("HYDRUS Infiltration")
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        SoilWaterDepletionTable
        InfiltratedDepthsTable
        NrcsSuggestionChanged
        ValueChanged
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
    ' Handle event from MyStore
    '
    Private Sub MyStore_PropertyDataChanged(ByVal _id As String, ByVal _reason As PropertyNode.Reasons) _
    Handles mMyStore.PropertyDataChanged

        If (_id = sSoilWaterDepletion) Then
            RaiseEvent PropertyDataChanged(Reasons.SoilWaterDepletionTable)
        ElseIf (_id = sInfiltratedDepth) Then
            RaiseEvent PropertyDataChanged(Reasons.InfiltratedDepthsTable)
        ElseIf (_id = sNrcsSuggestedManningN) Then
            RaiseEvent PropertyDataChanged(Reasons.NrcsSuggestionChanged)
        ElseIf (_reason = PropertyNode.Reasons.ValueChanged) Then
            RaiseEvent PropertyDataChanged(Reasons.ValueChanged)
        End If

    End Sub

#End Region

End Class
