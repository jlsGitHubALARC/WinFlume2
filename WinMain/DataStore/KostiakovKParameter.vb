
'*************************************************************************************************************
' KostiakovKParameter - special parameter to handle 'Kostiakov k'.
'
' KostiakovKParameter is similar to DoubleParameter except that the Kostiakov k's units are a function of
' 'Kostiakov a'.  When this class in new'd, it requires a reference to a 'Kostiakov a' DoubleParameter.
'*************************************************************************************************************
Imports DataStore
Imports System.Runtime.Serialization

<Serializable()> _
Public Class KostiakovKParameter
    Inherits Parameter

#Region " Properties "
    '
    ' Double Value
    '
    Private Const sValue As String = "DoubleValue"
    Protected mValue As Double
    Public Property Value() As Double
        Get
            UpdateKostiakovK()
            Return mValue
        End Get
        Set(ByVal Value As Double)
            mValue = Value
            ValidateValue()
        End Set
    End Property

    Private Const sMinValue As String = "MinValue"
    Protected mMinValue As Double
    Public Property MinValue() As Double
        Get
            Return mMinValue
        End Get
        Set(ByVal Value As Double)
            mMinValue = Value
            ValidateValue()
        End Set
    End Property

    Private Const sMaxValue As String = "MaxValue"
    Protected mMaxValue As Double
    Public Property MaxValue() As Double
        Get
            Return mMaxValue
        End Get
        Set(ByVal Value As Double)
            mMaxValue = Value
            ValidateValue()
        End Set
    End Property
    '
    ' SI Units
    '
    Private Const sUnits As String = "Units"
    Protected mUnits As K_Units
    Public ReadOnly Property KUnits() As K_Units
        Get
            Return mUnits
        End Get
    End Property

    Private Const sAltUnits As String = "AltUnits"
    Protected mAltUnits As K_Units
    Public Property AltUnits() As K_Units
        Get
            Return mAltUnits
        End Get
        Set(ByVal Value As K_Units)
            mAltUnits = Value
        End Set
    End Property

#End Region

#Region " Member Data "
    '
    ' Reference to corresponding Kostiakov A Property
    '
    Private mKostiakovA As DataStore.PropertyNode = Nothing
    Public Property KostiakovA() As DataStore.PropertyNode
        Get
            Return mKostiakovA
        End Get
        Set(ByVal Value As DataStore.PropertyNode)
            mKostiakovA = Value

            If (mKostiakovA IsNot Nothing) Then
                mLastA = mKostiakovA.GetDoubleParameter.Value
            End If
        End Set
    End Property

    Private mLastA As Double
    '
    ' Reference to the Units System
    '
    Protected Shared mUnitsSystem As UnitsSystem = UnitsSystem.Instance()
    '
    ' Saved copy of last valid Source
    '
    Private mLastValidSource As ValueSources = DataStore.Globals.ValueSources.LowLimit
    '
    ' Kostiakov k units
    '
    Public Enum K_Units

        NoUnits = -1

        MetersPerSecond_A

        MillimetersPerMinute_A
        MillimetersPerHour_A

        InchesPerMinute_A
        InchesPerHour_A

    End Enum

    Public Shared K_UnitsText() As String = {"m/sec^a", "mm/min^a", "mm/hr^a", "in/min^a", "in/hr^a"}

#End Region

#Region " Constructors "
    '
    ' New original
    '
    Public Sub New(ByVal _default As Double, ByVal _units As K_Units, ByRef _kostiakovA As DataStore.PropertyNode)

        ' Call the Parameter class' new
        MyBase.New()

        ' Set the Parameter's value(s) to default
        mMinValue = 0.0
        mMaxValue = Double.MaxValue
        mUnits = _units
        mAltUnits = K_Units.NoUnits
        SetValue(_default, _units, _kostiakovA)

    End Sub
    '
    ' New clone
    '
    Public Sub New(ByVal _parameter As KostiakovKParameter)

        ' Call the Parameter class' new
        MyBase.New(_parameter)

        ' Copy data from input Parameter
        mMinValue = _parameter.MinValue
        mMaxValue = _parameter.MaxValue
        mUnits = _parameter.KUnits
        mAltUnits = _parameter.AltUnits
        SetValue(_parameter.Value, _parameter.KUnits, _parameter.KostiakovA)

    End Sub

#End Region

#Region " Serialization "
    '
    ' Serialization
    '
    Public Overrides Sub GetObjectData(ByVal _info As SerializationInfo, _
                                       ByVal _context As StreamingContext)
        '
        ' Have base class serialize first
        '
        MyBase.GetObjectData(_info, _context)
        '
        ' Attempt to save the properties within this parameter
        '
        On Error GoTo ErrorHandler

        With _info
            .AddValue(sValue, Me.mValue, GetType(Double))
            .AddValue(sMinValue, Me.mMinValue, GetType(Double))
            .AddValue(sMaxValue, Me.mMaxValue, GetType(Double))
            .AddValue(sUnits, Me.mUnits, GetType(Integer))
            .AddValue(sAltUnits, Me.mAltUnits, GetType(Integer))
        End With

        Exit Sub

ErrorHandler:
        Debug.Assert(False, "DoubleParameter Serialization Error: " + Err.Description)
        Resume Next

    End Sub
    '
    ' De-serialization
    '
    Public Sub New(ByVal _info As SerializationInfo, _
                   ByVal _context As StreamingContext)
        '
        ' Have base class de-serialize first
        '
        MyBase.New(_info, _context)
        '
        ' Set property value(s) to default
        '
        Me.mValue = DefaultKostiakovK
        Me.mMinValue = 0.0
        Me.mMaxValue = Double.MaxValue
        Me.mUnits = K_Units.NoUnits
        Me.mAltUnits = K_Units.NoUnits
        '
        ' Attempt to read property values from De-serialization stream
        '
        On Error GoTo ErrorHandler

        With _info
            Me.mValue = CDbl(.GetValue(sValue, GetType(Double)))
            Me.mMinValue = CDbl(.GetValue(sMinValue, GetType(Double)))
            Me.mMaxValue = CDbl(.GetValue(sMaxValue, GetType(Double)))
            Me.mUnits = CType(.GetValue(sUnits, GetType(Integer)), K_Units)
            Me.mAltUnits = CType(.GetValue(sAltUnits, GetType(Integer)), K_Units)
        End With

        ' Note - KostiakovA still needs to be set (it can't be done here).
        '        The object that created and 'owns' this KostiakovKParameter should set it.

        Exit Sub

ErrorHandler:
        Resume Next

    End Sub

#End Region

#Region " Methods "
    '
    ' Update Kostiakov k to reflect any changes made to its corresponding Kostiakov a
    '
    Private Sub UpdateKostiakovK()

        If (KostiakovA IsNot Nothing) Then
            Dim _newK As Double = mValue
            Dim _newA As Double = KostiakovA.GetDoubleParameter.Value

            If Not (_newA = mLastA) Then
                ' Update Kostiakov k
                Dim _kUnits As K_Units = DisplayUnits
                If Not (mAltUnits = K_Units.NoUnits) Then
                    _kUnits = mAltUnits
                End If

                Select Case _kUnits
                    Case K_Units.MillimetersPerMinute_A, K_Units.InchesPerMinute_A
                        _newK = mValue * (SecondsPerMinute ^ mLastA) / (SecondsPerMinute ^ _newA)
                    Case K_Units.MillimetersPerHour_A, K_Units.InchesPerHour_A
                        _newK = mValue * (SecondsPerHour ^ mLastA) / (SecondsPerHour ^ _newA)
                End Select

                ' Save new value of Kostiakov k & a
                mValue = _newK
                mLastA = _newA
            End If
        End If

    End Sub
    '
    ' KostiakovKText() - returns the input value's text without units
    '
    Public Shared Function KostiakovKText(ByVal _value As Double, _
                                          ByVal _kostiakovA As Double, _
                                          ByVal _units As K_Units) As String
        Dim _valueText As String = "#####"

        ' Convert value to DisplayUnits before
        Select Case _units

            Case K_Units.MetersPerSecond_A
                _valueText = Format(UnitKostiakovK(_value, _kostiakovA, K_Units.MetersPerSecond_A), "0.0###")

            Case K_Units.MillimetersPerHour_A
                _valueText = Format(UnitKostiakovK(_value, _kostiakovA, K_Units.MillimetersPerHour_A), "0.0##")

            Case K_Units.MillimetersPerMinute_A
                _valueText = Format(UnitKostiakovK(_value, _kostiakovA, K_Units.MillimetersPerMinute_A), "0.0#")

            Case K_Units.InchesPerHour_A
                _valueText = Format(UnitKostiakovK(_value, _kostiakovA, K_Units.InchesPerHour_A), "0.0###")

            Case K_Units.InchesPerMinute_A
                _valueText = Format(UnitKostiakovK(_value, _kostiakovA, K_Units.InchesPerMinute_A), "0.0##")

            Case Else
                Debug.Assert(False, "Invalid Units for KostiakovString")
        End Select

        Return _valueText
    End Function
    '
    ' Text() - returns this Parameter's value's text without units
    '
    Public Function Text() As String
        Text = KostiakovKText(Value, mLastA, DisplayUnits)
    End Function

    Public Function Text(ByVal _units As K_Units) As String
        Text = KostiakovKText(Value, mLastA, _units)
    End Function
    '
    ' KostiakovKString() - returns the input value's text with units
    '
    Public Shared Function KostiakovKString(ByVal _value As Double, ByVal _kostiakovA As Double, _
                                            ByVal _units As K_Units, Optional ByVal _len As Integer = 0) As String
        Dim _valueText As String = KostiakovKText(_value, _kostiakovA, _units)
        Dim _unitsText As String = K_UnitsText(_units)

        ' Append the units text, if any
        If Not (_unitsText = "") Then
            _valueText = _valueText + " " + _unitsText
        End If

        ' Prepend spaces to generate right-justified string of requested length
        While (_valueText.Length < _len)
            _valueText = " " + _valueText
        End While

        Return _valueText
    End Function
    '
    ' ValueString() - returns this Parameter's value's text with units
    '
    Public Overrides Function ValueString(Optional ByVal WithUnits As Boolean = True) As String
        If (WithUnits) Then
            ValueString = KostiakovKString(Value, mLastA, DisplayUnits)
        Else
            ValueString = KostiakovKText(Value, mLastA, DisplayUnits)
        End If
    End Function

    Public Overrides Function TypeString() As String
        Return "double"
    End Function
    '
    ' Copy to Clipboard
    '
    Public Overrides Sub Copy()
        CopyToClipboard(Value)
    End Sub
    '
    ' Convert unit Kostiakov k to SI Units (m/s^a)
    '
    Public Shared Function SiKostiakovK(ByVal _unitKostiakovK As Double, ByVal _siKostiakovA As Double, ByVal _units As K_Units) As Double
        Select Case _units
            Case K_Units.MetersPerSecond_A, Units.MetersPerSecond_A
                Return _unitKostiakovK
            Case K_Units.MillimetersPerMinute_A
                Return _unitKostiakovK * MetersPerMillimeter / (SecondsPerMinute ^ _siKostiakovA)
            Case K_Units.MillimetersPerHour_A, Units.MillimetersPerHour_A
                Return _unitKostiakovK * MetersPerMillimeter / (SecondsPerHour ^ _siKostiakovA)
            Case K_Units.InchesPerMinute_A
                Return _unitKostiakovK * MetersPerInch / (SecondsPerMinute ^ _siKostiakovA)
            Case K_Units.InchesPerHour_A, Units.InchesPerHour_A
                Return _unitKostiakovK * MetersPerInch / (SecondsPerHour ^ _siKostiakovA)
            Case Else
                Debug.Assert(False, "Invalid Kostiakov k Units")
                Return _unitKostiakovK
        End Select
    End Function
    '
    ' Convert SI units (m/s^a) to units Kostiakov k
    '
    Public Shared Function UnitKostiakovK(ByVal _siKostiakov As Double, ByVal _siKostiakovA As Double, ByVal _units As K_Units) As Double
        Select Case _units
            Case K_Units.MetersPerSecond_A, Units.MetersPerSecond_A
                Return _siKostiakov
            Case K_Units.MillimetersPerMinute_A
                Return _siKostiakov * MillimetersPerMeter * (SecondsPerMinute ^ _siKostiakovA)
            Case K_Units.MillimetersPerHour_A, Units.MillimetersPerHour_A
                Return _siKostiakov * MillimetersPerMeter * (SecondsPerHour ^ _siKostiakovA)
            Case K_Units.InchesPerMinute_A
                Return _siKostiakov * InchesPerMeter * (SecondsPerMinute ^ _siKostiakovA)
            Case K_Units.InchesPerHour_A, Units.InchesPerHour_A
                Return _siKostiakov * InchesPerMeter * (SecondsPerHour ^ _siKostiakovA)
            Case Else
                Debug.Assert(False, "Invalid Kostiakov k Units")
                Return _siKostiakov
        End Select
    End Function
    '
    ' DisplayUnits() - returns current Display Units
    '
    Public Shared Function DisplayUnits() As K_Units
        If (mUnitsSystem.UnitSystem = UnitSystems.English) Then
            Return K_Units.InchesPerHour_A
        Else
            Return K_Units.MillimetersPerHour_A
        End If
    End Function
    '
    ' UnitsForString() - return K_Units associated with string
    '
    Public Shared Function UnitsForString(ByVal UnitsText As String) As K_Units
        UnitsForString = K_Units.NoUnits
        For kdx As Integer = 0 To K_UnitsText.Length - 1
            Dim kUnitText As String = K_UnitsText(kdx)
            If (kUnitText = UnitsText) Then
                UnitsForString = kdx
            End If
        Next kdx
    End Function
    '
    ' SetValue(value, display units)
    '
    Public Sub SetValue(ByVal _value As Double, ByVal _displayUnits As K_Units, ByVal _kostiakovA As PropertyNode)

        ' Save a reference to the corresponding Kostiakov A PropertyNode
        KostiakovA = _kostiakovA

        ' Convert value to SI units before saving
        If (KostiakovA IsNot Nothing) Then
            Value = SiKostiakovK(_value, mLastA, _displayUnits)
        Else
            Value = _value
        End If
    End Sub

    Public Sub SetValue(ByVal _value As Double, ByVal _displayUnits As K_Units, ByVal _kostiakovA As Double)

        ' Save the value of the corresponding Kostiakov A
        mLastA = _kostiakovA

        ' Convert value to SI units before saving
        Value = SiKostiakovK(_value, mLastA, _displayUnits)
    End Sub

    Public Overrides Function ParseAndSetValue(ByVal _value As String) As Boolean

        Dim dvalue As Double
        Dim dunits As Units
        If (ParseValueWithUnits(_value, dvalue, dunits)) Then
            If (dunits = Units.None) Then ' no Units were specified; use Display Units
                dunits = DisplayUnits()
            End If

            Value = SiKostiakovK(dvalue, mLastA, dunits)
            Return True
        End If

        Return False
    End Function
    '
    ' value = GetValue(display units)
    '
    Public Function GetValue(ByVal _displayUnits As K_Units) As Double
        Dim _siValue As Double = Value
        Dim _dispValue As Double = UnitKostiakovK(_siValue, mLastA, _displayUnits)

        Return _dispValue
    End Function
    '
    ' ValidateValue()
    '
    Public Function ValidateValue() As Boolean
        '
        ' Validate this value if it is not a Constant
        '
        If Not (Source = DataStore.Globals.ValueSources.Constant) Then
            ' Verify Value falls between Min & Max
            If ((Double.IsNaN(Value)) Or (Value < MinValue) Or (MaxValue < Value)) Then
                ' Value is outside valid range
                If Not (Source = DataStore.Globals.ValueSources.Errored) Then
                    ' Source moving to Errored; save current non-errored Source
                    mLastValidSource = Source
                    Source = DataStore.Globals.ValueSources.Errored
                End If

                Return False

            End If
        End If
        '
        ' Value is within valid range
        '
        If (Source = DataStore.Globals.ValueSources.Errored) Then
            ' Source was Errored; go back to last non-errored Source
            If Not (mLastValidSource = DataStore.Globals.ValueSources.LowLimit) Then
                Source = mLastValidSource
            End If
        End If

        Return True

    End Function

#End Region

End Class
