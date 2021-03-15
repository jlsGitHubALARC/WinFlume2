
'*************************************************************************************************************
' Fertigation properties
'
' Fertigation stores user entered and SRFR generated data that describe the injection of and distribution of
' fertilizing solutes into the surface irrigation water.
'*************************************************************************************************************
Imports DataStore

Imports Srfr
Imports Srfr.SoluteTransport

Public Class Fertigation

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Fertigation"
    Public ReadOnly Property MyID() As String
        Get
            Return mMyID
        End Get
    End Property
    '
    ' Parent Unit
    '
    Private mWinSRFR As WinSRFR
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

#Region " UI Properties "

    Public Const sEnableFertigation As String = "Enable Fertigation"

    Public ReadOnly Property EnableFertigationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableFertigation)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultEnableFertigation)
                mMyStore.AddProperty(sEnableFertigation, _boolean)
                _propertyNode = mMyStore.GetProperty(sEnableFertigation)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableFertigation() As BooleanParameter
        Get
            Return EnableFertigationProperty.GetBooleanParameter()
        End Get
        Set(ByVal Value As BooleanParameter)
            EnableFertigationProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sTankConcentration As String = "Tank Concentration"

    Public ReadOnly Property TankConcentrationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTankConcentration)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultTankConcentration, Units.GramsPerLiter)
                mMyStore.AddProperty(sTankConcentration, _parameter)
                _propertyNode = mMyStore.GetProperty(sTankConcentration)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property TankConcentration() As DoubleParameter
        Get
            Return TankConcentrationProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            TankConcentrationProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sTabulatedInjectionRate As String = "Tabulated Injection Rate"

    Public ReadOnly Property TabulatedInjectionRateProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTabulatedInjectionRate)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim injectionTimeTable As DataTable = New DataTable(sTabulatedInjectionRate)

                ResetTabulatedInjectionRate(injectionTimeTable)

                Dim _parameter As DataTableParameter = New DataTableParameter(injectionTimeTable)
                mMyStore.AddProperty(sTabulatedInjectionRate, _parameter)
                _propertyNode = mMyStore.GetProperty(sTabulatedInjectionRate)

            Else
                Dim param As Parameter = _propertyNode.GetParameter
                If (param.GetType Is GetType(DataTableParameter)) Then
                    Dim tableParam As DataTableParameter = DirectCast(param, DataTableParameter)

                    Dim injectionTimeTable As DataTable = tableParam.Value
                    injectionTimeTable.Columns(1).ExtendedProperties.Clear()
                    injectionTimeTable.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.InjectionRateUnitSet)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property TabulatedInjectionRate() As DataTableParameter
        Get
            Dim _table As DataTableParameter = TabulatedInjectionRateProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            TabulatedInjectionRateProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetTabulatedInjectionRate(ByVal _tabulatedInjectionRate As DataTable)

        ' Remove the previous data
        _tabulatedInjectionRate.Columns.Clear()
        _tabulatedInjectionRate.Rows.Clear()

        ' Add the columns
        _tabulatedInjectionRate.Columns.Add(sTimeX, GetType(Double))
        _tabulatedInjectionRate.Columns.Add(sInjectionRateX, GetType(Double))
        _tabulatedInjectionRate.Columns(1).ExtendedProperties.Add(UnitsSystem.sAltUnitSet, New UnitsSystem.InjectionRateUnitSet)

        ' The reset Time Injection Table contain one entry
        Dim _injectionRow As DataRow

        _injectionRow = _tabulatedInjectionRate.NewRow
        _injectionRow.Item(sTimeX) = 0.0
        _injectionRow.Item(sInjectionRateX) = GallonPerHour
        _tabulatedInjectionRate.Rows.Add(_injectionRow)

        _injectionRow = _tabulatedInjectionRate.NewRow
        _injectionRow.Item(sTimeX) = Srfr.Globals.TenMinutes
        _injectionRow.Item(sInjectionRateX) = GallonPerHour
        _tabulatedInjectionRate.Rows.Add(_injectionRow)

        _injectionRow = _tabulatedInjectionRate.NewRow
        _injectionRow.Item(sTimeX) = Srfr.Globals.TenMinutes + Srfr.Globals.TenSeconds
        _injectionRow.Item(sInjectionRateX) = 0.0
        _tabulatedInjectionRate.Rows.Add(_injectionRow)

    End Sub


    Public Const sCharacteristicType As String = "Characteristic Type"

    Public ReadOnly Property CharacteristicTypeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCharacteristicType)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultCharacteristicType)
                mMyStore.AddProperty(sCharacteristicType, _parameter)
                _propertyNode = mMyStore.GetProperty(sCharacteristicType)
            End If

            If (IncludeDispersion.Value) Then ' Dispersion requires PieceWise Characteristics
                If (_propertyNode IsNot Nothing) Then
                    Dim _param As Parameter = _propertyNode.GetParameter
                    Dim _intParam As IntegerParameter = DirectCast(_param, IntegerParameter)
                    _intParam.Value = CharacteristicTypes.PieceWise
                    _intParam.Source = ValueSources.Calculated
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CharacteristicType() As IntegerParameter
        Get
            Dim intParam As IntegerParameter = CharacteristicTypeProperty.GetIntegerParameter()
            intParam.Value = CharacteristicTypes.PieceWise ' Piece-Wise only for now (09/18/2019)
            Return intParam
        End Get
        Set(ByVal Value As IntegerParameter)
            CharacteristicTypeProperty.SetParameter(Value)
        End Set
    End Property

    Private mCharacteristicTypeIndex As Integer = -1
    Public Function GetFirstCharacteristicTypeSelection() As String
        mCharacteristicTypeIndex = -1
        Return GetNextCharacteristicTypeSelection()
    End Function

    Public Function GetNextCharacteristicTypeSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = CType(mUnit.CrossSection, CrossSections)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        mCharacteristicTypeIndex += 1
        If (mCharacteristicTypeIndex <= CharacteristicTypes.PieceWise) Then
            If ((CharacteristicTypeSelections(mCharacteristicTypeIndex).Flags And _flags) = 0) Then
                Return CharacteristicTypeSelections(mCharacteristicTypeIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function


    Public Const sAdvectionInterpolationMethod As String = "Advection Interpolation Method"

    Public ReadOnly Property AdvectionInterpolationMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvectionInterpolationMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultAdvectionInterpolationMethod)
                mMyStore.AddProperty(sAdvectionInterpolationMethod, _parameter)
                _propertyNode = mMyStore.GetProperty(sAdvectionInterpolationMethod)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AdvectionInterpolationMethod() As IntegerParameter
        Get
            Dim intParam As IntegerParameter = AdvectionInterpolationMethodProperty.GetIntegerParameter()
            Return intParam
        End Get
        Set(ByVal Value As IntegerParameter)
            AdvectionInterpolationMethodProperty.SetParameter(Value)
        End Set
    End Property

    Private mAdvectionInterpolationMethodIndex As Integer = -1
    Public Function GetFirstAdvectionInterpolationMethodSelection() As String
        mAdvectionInterpolationMethodIndex = -1
        Return GetNextAdvectionInterpolationMethodSelection()
    End Function

    Public Function GetNextAdvectionInterpolationMethodSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = CType(mUnit.CrossSection, CrossSections)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        mAdvectionInterpolationMethodIndex += 1
        If (mAdvectionInterpolationMethodIndex <= Srfr.SoluteTransport.AdvectionInterpolationMethods.CubicSpline) Then
            If ((AdvectionInterpolationMethodSelections(mAdvectionInterpolationMethodIndex).Flags And _flags) = 0) Then
                Return AdvectionInterpolationMethodSelections(mAdvectionInterpolationMethodIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function


    Public Const sIncludeDispersion As String = "Include Dispersion"

    Public ReadOnly Property IncludeDispersionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sIncludeDispersion)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultIncludeDispersion)
                mMyStore.AddProperty(sIncludeDispersion, _boolean)
                _propertyNode = mMyStore.GetProperty(sIncludeDispersion)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property IncludeDispersion() As BooleanParameter
        Get
            Dim boolParam As BooleanParameter = IncludeDispersionProperty.GetBooleanParameter()
            Return boolParam
        End Get
        Set(ByVal Value As BooleanParameter)
            IncludeDispersionProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sDispersivityCoefficientMethod As String = "Dispersivity Coefficient Method"

    Public ReadOnly Property DispersivityCoefficientMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDispersivityCoefficientMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultDispersivityCoefficientMethod)
                mMyStore.AddProperty(sDispersivityCoefficientMethod, _parameter)
                _propertyNode = mMyStore.GetProperty(sDispersivityCoefficientMethod)
            End If

            ' Deng, Fischer & Rutheford only available to Research Level
            If Not (mWinSRFR.UserLevel = UserLevels.Research) Then ' Standard | Advanced user
                If (_propertyNode IsNot Nothing) Then
                    Dim param As Parameter = _propertyNode.GetParameter
                    Dim intParam As IntegerParameter = DirectCast(param, IntegerParameter)
                    Select Case intParam.Value
                        Case DispersivityCoefficientMethods.Deng,
                             DispersivityCoefficientMethods.Fischer,
                             DispersivityCoefficientMethods.Rutherford

                            intParam.Value = DispersivityCoefficientMethods.Elder
                            intParam.Source = ValueSources.Calculated
                    End Select
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DispersivityCoefficientMethod() As IntegerParameter
        Get
            Dim intParam As IntegerParameter = DispersivityCoefficientMethodProperty.GetIntegerParameter()
            Return intParam
        End Get
        Set(ByVal Value As IntegerParameter)
            DispersivityCoefficientMethodProperty.SetParameter(Value)
        End Set
    End Property

    Private mDispersivityCoefficientMethodIndex As Integer = -1
    Public Function GetFirstDispersivityCoefficientMethodSelection() As String
        mDispersivityCoefficientMethodIndex = -1
        Return GetNextDispersivityCoefficientMethodSelection()
    End Function

    Public Function GetNextDispersivityCoefficientMethodSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = CType(mUnit.CrossSection, CrossSections)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, _crossSection, _userLevel)

        mDispersivityCoefficientMethodIndex += 1
        If (mDispersivityCoefficientMethodIndex <= Srfr.SoluteTransport.DispersivityCoefficientMethods.Rutherford) Then
            If ((DispersivityCoefficientMethodSelections(mDispersivityCoefficientMethodIndex).Flags And _flags) = 0) Then
                Return DispersivityCoefficientMethodSelections(mDispersivityCoefficientMethodIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function


    Public Const sElderCe As String = "Elder Ce"

    Public ReadOnly Property ElderCeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sElderCe)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultElderCe, Units.None)
                mMyStore.AddProperty(sElderCe, _parameter)
                _propertyNode = mMyStore.GetProperty(sElderCe)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ElderCe() As DoubleParameter
        Get
            Return ElderCeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ElderCeProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sSpecifiedKx As String = "Specified Kx"

    Public ReadOnly Property SpecifiedKxProperty As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSpecifiedKx)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(DefaultSpecifiedKx, Units.None)
                mMyStore.AddProperty(sSpecifiedKx, _parameter)
                _propertyNode = mMyStore.GetProperty(sSpecifiedKx)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SpecifiedKx() As DoubleParameter
        Get
            Return SpecifiedKxProperty.GetDoubleParameter
        End Get
        Set(value As DoubleParameter)
            SpecifiedKxProperty.SetParameter(value)
        End Set
    End Property


    Public Const sAverageKx As String = "Average Kx"

    Public ReadOnly Property AverageKxProperty As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAverageKx)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.None)
                mMyStore.AddProperty(sAverageKx, _parameter)
                _propertyNode = mMyStore.GetProperty(sAverageKx)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AverageKx() As DoubleParameter
        Get
            Return AverageKxProperty.GetDoubleParameter
        End Get
        Set(value As DoubleParameter)
            AverageKxProperty.SetParameter(value)
        End Set
    End Property

#End Region

#Region " XTICS "
    '
    ' Xtics
    '
    Private Const sXtics As String = "XTICS"

    Public ReadOnly Property XticsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sXtics)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataSetParameter = New DataSetParameter
                mMyStore.AddProperty(sXtics, _parameter)
                _propertyNode = mMyStore.GetProperty(sXtics)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Xtics() As DataSetParameter
        Get
            Return XticsProperty.GetDataSetParameter()
        End Get
        Set(ByVal Value As DataSetParameter)
            XticsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearXtics()
        mMyStore.DeleteProperty(sXtics)
    End Sub
    '
    ' Xtics Grid
    '
    Private Const sXticsGrid As String = "XTICS Grid"

    Public ReadOnly Property XticsGridProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sXticsGrid)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataSetParameter = New DataSetParameter
                mMyStore.AddProperty(sXticsGrid, _parameter)
                _propertyNode = mMyStore.GetProperty(sXticsGrid)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property XticsGrid() As DataSetParameter
        Get
            Return XticsGridProperty.GetDataSetParameter()
        End Get
        Set(ByVal Value As DataSetParameter)
            XticsGridProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearXticsGrid()
        mMyStore.DeleteProperty(sXticsGrid)
    End Sub

#End Region

#Region " Results "
    '
    ' Density Profile Table
    '
    Private Const sDensityProfiles As String = "Density Profiles"

    Public ReadOnly Property DensityProfilesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDensityProfiles)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sDensityProfiles, _parameter)
                _propertyNode = mMyStore.GetProperty(sDensityProfiles)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DensityProfiles() As DataTableParameter
        Get
            Return DensityProfilesProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            DensityProfilesProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearDensityProfiles()
        mMyStore.DeleteProperty(sDensityProfiles)
    End Sub
    '
    ' Concentration Hydrograph Table
    '
    Private Const sConcentrationHydrographs As String = "Concentration Hydrographs"

    Public ReadOnly Property ConcentrationHydrographsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sConcentrationHydrographs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sConcentrationHydrographs, _parameter)
                _propertyNode = mMyStore.GetProperty(sConcentrationHydrographs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ConcentrationHydrographs() As DataTableParameter
        Get
            Return ConcentrationHydrographsProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            ConcentrationHydrographsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearConcentrationHydrographs()
        mMyStore.DeleteProperty(sConcentrationHydrographs)
    End Sub
    '
    ' Infiltrated solute
    '
    Private Const sMinf As String = "Infiltrated Mass"

    Public ReadOnly Property MinfProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinf)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Kilograms)
                mMyStore.AddProperty(sMinf, _double)
                _propertyNode = mMyStore.GetProperty(sMinf)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Minf() As DoubleParameter
        Get
            Return MinfProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MinfProperty.SetParameter(Value)
        End Set
    End Property


    Private Const sMDUlq As String = "Infiltrated Mass (DUlq)"

    Public ReadOnly Property MDUlqProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMDUlq)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Fraction)
                mMyStore.AddProperty(sMDUlq, _double)
                _propertyNode = mMyStore.GetProperty(sMDUlq)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MDUlq() As DoubleParameter
        Get
            Return MDUlqProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MDUlqProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Runoff solute
    '
    Private Const sMro As String = "Runoff Mass"

    Public ReadOnly Property MroProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMro)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Kilograms)
                mMyStore.AddProperty(sMro, _double)
                _propertyNode = mMyStore.GetProperty(sMro)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Mro() As DoubleParameter
        Get
            Return MroProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MroProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#End Region

#Region " Calculated Properties "

#Region " Applied Solute "
    '
    ' Return total solute applied
    '
    Public Function AppliedSolute() As Double
        AppliedSolute = 0.0

        ' Limit injection time to Tco
        Dim Tco As Double = mUnit.InflowManagementRef.Cutoff

        ' Get the Tabulated Injection Rate table
        Dim injectionTable As DataTable = TabulatedInjectionRate.Value
        If (injectionTable IsNot Nothing) Then
            ' Calculate the Tabulated Injection volume
            If (0 < injectionTable.Rows.Count) Then

                Dim time1 As Double = CDbl(injectionTable.Rows(0).Item(nTimeX))
                Dim rate1 As Double = CDbl(injectionTable.Rows(0).Item(nInflowX))

                For rdx As Integer = 1 To injectionTable.Rows.Count - 1

                    Dim time2 As Double = CDbl(injectionTable.Rows(rdx).Item(nTimeX))
                    Dim rate2 As Double = CDbl(injectionTable.Rows(rdx).Item(nInflowX))

                    If (time2 < Tco) Then
                        AppliedSolute += ((rate2 + rate1) / 2.0) * (time2 - time1)
                    Else
                        AppliedSolute += ((rate2 + rate1) / 2.0) * (Tco - time1)
                        Exit For
                    End If

                    time1 = time2
                    rate1 = rate2
                Next rdx

            End If
        End If

    End Function

#End Region

#End Region

#Region " Constructor(s) "

    Public Sub New(ByVal _myID As String, ByVal _unit As Unit)
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
            mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef
            mParentStore = mUnit.MyStore
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Add Fertigation to Parent's Data Store
        '
        If (mParentStore IsNot Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If (mMyStore IsNot Nothing) Then ' enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "Fertigation not added to Data Store")
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
            mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef
            mParentStore = mUnit.MyStore
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
        Me.ClearXtics()
        Me.ClearXticsGrid()
        Me.ClearDensityProfiles()
        Me.ClearConcentrationHydrographs()
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        EnableFertigation

        Other
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
        ' Regenerate the DataStore event as a Fertigation event
        Select Case _id
            Case sEnableFertigation
                RaiseEvent PropertyDataChanged(Reasons.EnableFertigation)

            Case Else
                RaiseEvent PropertyDataChanged(Reasons.Other)
        End Select
    End Sub

#End Region

End Class
