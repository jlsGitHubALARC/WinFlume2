
'*************************************************************************************************************
' PowerAdvancePParameter - special parameter to handle 'Power Advance p'.
'
' PowerAdvancePParameter is similar to DoubleParameter except the Power Advance p's units are a function of
' 'Power Advance r'.  When new'd, this class requires a reference to a 'Power Advance r' DoubleParameter.
'*************************************************************************************************************
Imports DataStore
Imports System.Runtime.Serialization

<Serializable()> _
Public Class PowerAdvancePParameter
    Inherits Parameter

#Region " Properties "
    '
    ' Double Value
    '
    Private Const sValue As String = "DoubleValue"
    Protected mValue As Double
    Public Property Value(Optional ByVal R As Double = Double.NaN) As Double
        Get
            If Not (Double.IsNaN(R)) Then
                mLastR = R
            End If
            UpdatePowerAdvanceP()
            Return mValue
        End Get
        Set(ByVal Value As Double)
            If Not (Double.IsNaN(R)) Then
                mLastR = R
            End If
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
    Protected mUnits As P_Units
    Public ReadOnly Property PUnits() As P_Units
        Get
            Return mUnits
        End Get
    End Property

    Private Const sAltUnits As String = "AltUnits"
    Protected mAltUnits As P_Units
    Public Property AltUnits() As P_Units
        Get
            Return mAltUnits
        End Get
        Set(ByVal Value As P_Units)
            mAltUnits = Value
        End Set
    End Property

#End Region

#Region " Member Data "
    '
    ' Reference to corresponding Power Advance r Property
    '
    Private mPowerAdvanceR As DataStore.PropertyNode = Nothing
    Public Property PowerAdvanceR() As DataStore.PropertyNode
        Get
            Return mPowerAdvanceR
        End Get
        Set(ByVal Value As DataStore.PropertyNode)
            mPowerAdvanceR = Value

            If (mPowerAdvanceR IsNot Nothing) Then
                mLastR = mPowerAdvanceR.GetDoubleParameter.Value
            End If
        End Set
    End Property

    Private mLastR As Double
    '
    ' Reference to the Units System
    '
    Protected Shared mUnitsSystem As UnitsSystem = UnitsSystem.Instance()
    '
    ' Saved copy of last valid Source
    '
    Private mLastValidSource As ValueSources = DataStore.Globals.ValueSources.LowLimit
    '
    ' Power Advance p units
    '
    Public Enum P_Units

        NoUnits = -1

        MetersPerSecond_R ' SI
        MetersPerMinute_R
        MetersPerHour_R

        CentimetersPerSecond_R
        CentimetersPerMinute_R
        CentimetersPerHour_R

        MillimetersPerSecond_R
        MillimetersPerMinute_R
        MillimetersPerHour_R

        FeetPerSecond_R
        FeetPerMinute_R
        FeetPerHour_R

        InchesPerSecond_R
        InchesPerMinute_R
        InchesPerHour_R

    End Enum

    Public Shared P_UnitsText() As String = {"m/s^r", "m/min^r", "m/hr^r", _
                                             "cm/s^r", "cm/min^r", "cm/hr^r", _
                                             "mm/s^r", "mm/min^r", "mm/hr^r", _
                                             "ft/s^r", "ft/min^r", "ft/hr^r", _
                                             "in/s^r", "in/min^r", "in/hr^r"}

#End Region

#Region " Constructors "
    '
    ' New original
    '
    Public Sub New(ByVal _default As Double, ByVal _units As P_Units, ByRef _powerAdvanceR As DataStore.PropertyNode)

        ' Call the Parameter class' new
        MyBase.New()

        ' Set the Parameter's value(s) to default
        mMinValue = 0.0
        mMaxValue = Double.MaxValue
        mUnits = _units
        mAltUnits = P_Units.NoUnits
        SetValue(_default, _units, _powerAdvanceR)

    End Sub
    '
    ' New clone
    '
    Public Sub New(ByVal _parameter As PowerAdvancePParameter)

        ' Call the Parameter class' new
        MyBase.New(_parameter)

        ' Copy data from input Parameter
        mMinValue = _parameter.MinValue
        mMaxValue = _parameter.MaxValue
        mUnits = _parameter.PUnits
        mAltUnits = _parameter.AltUnits
        SetValue(_parameter.Value, _parameter.PUnits, _parameter.PowerAdvanceR)

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
        Me.mValue = 0.5
        Me.mMinValue = 0.0
        Me.mMaxValue = Double.MaxValue
        Me.mUnits = P_Units.NoUnits
        Me.mAltUnits = P_Units.NoUnits
        '
        ' Attempt to read property values from De-serialization stream
        '
        On Error GoTo ErrorHandler

        With _info
            Me.mValue = CDbl(.GetValue(sValue, GetType(Double)))
            Me.mMinValue = CDbl(.GetValue(sMinValue, GetType(Double)))
            Me.mMaxValue = CDbl(.GetValue(sMaxValue, GetType(Double)))
            Me.mUnits = CType(.GetValue(sUnits, GetType(Integer)), P_Units)
            Me.mAltUnits = CType(.GetValue(sAltUnits, GetType(Integer)), P_Units)
        End With

        ' Note - PowerAdvanceR still needs to be set (it can't be done here).
        '        The object that created and 'owns' this PowerAdvancePParameter should set it.

        Exit Sub

ErrorHandler:
        Resume Next

    End Sub

#End Region

#Region " Methods "
    '
    ' Update Power Advance p to reflect any changes made to its corresponding Power Advance r
    '
    Private Sub UpdatePowerAdvanceP()

        If (PowerAdvanceR IsNot Nothing) Then
            Dim _newP As Double = mValue
            Dim _newR As Double = PowerAdvanceR.GetDoubleParameter.Value

            If Not (_newR = mLastR) Then
                ' Update Power Advance p
                Dim _pUnits As P_Units = DisplayUnits
                If Not (mAltUnits = P_Units.NoUnits) Then
                    _pUnits = mAltUnits
                End If

                Select Case _pUnits
                    Case P_Units.CentimetersPerHour_R, P_Units.FeetPerHour_R, P_Units.InchesPerHour_R, P_Units.MetersPerHour_R, P_Units.MillimetersPerHour_R
                        _newP = mValue * (SecondsPerHour ^ mLastR) / (SecondsPerHour * _newR)

                    Case P_Units.CentimetersPerMinute_R, P_Units.FeetPerMinute_R, P_Units.InchesPerMinute_R, P_Units.MetersPerMinute_R, P_Units.MillimetersPerMinute_R
                        _newP = mValue * (SecondsPerMinute ^ mLastR) / (SecondsPerMinute ^ _newR)
                End Select

                ' Save new value of Power Advance p & a
                mValue = _newP
                mLastR = _newR
            End If
        End If

    End Sub
    '
    ' PowerAdvancePText() - returns the input value's text without units
    '
    Public Shared Function PowerAdvancePText(ByVal _value As Double, _
                                             ByVal _powerAdvanceR As Double, _
                                             ByVal _units As P_Units) As String
        Dim _valueText As String = "#####"

        ' Convert value to DisplayUnits before
        Select Case _units

            Case P_Units.CentimetersPerSecond_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.CentimetersPerSecond_R), "0.0###")
            Case P_Units.FeetPerSecond_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.FeetPerSecond_R), "0.0###")
            Case P_Units.InchesPerSecond_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.InchesPerSecond_R), "0.0###")
            Case P_Units.MetersPerSecond_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.MetersPerSecond_R), "0.0###")
            Case P_Units.MillimetersPerSecond_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.MillimetersPerSecond_R), "0.0###")

            Case P_Units.CentimetersPerHour_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.CentimetersPerHour_R), "0.0##")
            Case P_Units.FeetPerHour_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.FeetPerHour_R), "0.0##")
            Case P_Units.InchesPerHour_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.InchesPerHour_R), "0.0###")
            Case P_Units.MetersPerHour_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.MetersPerHour_R), "0.0##")
            Case P_Units.MillimetersPerHour_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.MillimetersPerHour_R), "0.0##")

            Case P_Units.CentimetersPerMinute_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.CentimetersPerMinute_R), "0.0#")
            Case P_Units.FeetPerMinute_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.FeetPerMinute_R), "0.0#")
            Case P_Units.InchesPerMinute_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.InchesPerMinute_R), "0.0##")
            Case P_Units.MetersPerMinute_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.MetersPerMinute_R), "0.0#")
            Case P_Units.MillimetersPerMinute_R
                _valueText = Format(UnitPowerAdvanceP(_value, _powerAdvanceR, P_Units.MillimetersPerMinute_R), "0.0#")

            Case Else
                Debug.Assert(False, "Invalid Units for PowerAdvanceString")
        End Select

        Return _valueText
    End Function
    '
    ' Text() - returns this Parameter's value's text without units
    '
    Public Function Text() As String
        Text = PowerAdvancePText(Value, mLastR, DisplayUnits)
    End Function

    Public Function Text(ByVal _units As P_Units) As String
        Text = PowerAdvancePText(Value, mLastR, _units)
    End Function
    '
    ' PowerAdvancePString() - returns the input value's text with units
    '
    Public Shared Function PowerAdvancePString(ByVal _value As Double, ByVal _powerAdvanceR As Double, _
                                            ByVal _units As P_Units, Optional ByVal _len As Integer = 0) As String
        Dim _valueText As String = PowerAdvancePText(_value, _powerAdvanceR, _units)
        Dim _unitsText As String = P_UnitsText(_units)

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
            ValueString = PowerAdvancePString(Value, mLastR, DisplayUnits)
        Else
            ValueString = PowerAdvancePText(Value, mLastR, DisplayUnits)
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
    ' Convert unit Power Advance p to SI Units (m/s^r)
    '
    Public Shared Function SiPowerAdvanceP(ByVal _unitPowerAdvanceP As Double, ByVal _siPowerAdvanceR As Double, ByVal _units As P_Units) As Double
        Select Case _units
            Case P_Units.CentimetersPerSecond_R, Units.CentimetersPerSecond_R
                Return _unitPowerAdvanceP * MetersPerCentimeter
            Case P_Units.FeetPerSecond_R, Units.FeetPerSecond_R
                Return _unitPowerAdvanceP * MetersPerFoot
            Case P_Units.InchesPerSecond_R, Units.InchesPerSecond_R
                Return _unitPowerAdvanceP * MetersPerInch
            Case P_Units.MetersPerSecond_R, Units.MetersPerSecond_R
                Return _unitPowerAdvanceP
            Case P_Units.MillimetersPerSecond_R, Units.MillimetersPerSecond_R
                Return _unitPowerAdvanceP * MetersPerMillimeter

            Case P_Units.CentimetersPerMinute_R, Units.CentimetersPerMinute_R
                Return _unitPowerAdvanceP * MetersPerCentimeter / (SecondsPerMinute ^ _siPowerAdvanceR)
            Case P_Units.MillimetersPerMinute_R, Units.MillimetersPerMinute_R
                Return _unitPowerAdvanceP * MetersPerMillimeter / (SecondsPerMinute ^ _siPowerAdvanceR)
            Case P_Units.InchesPerMinute_R, Units.InchesPerMinute_R
                Return _unitPowerAdvanceP * MetersPerInch / (SecondsPerMinute ^ _siPowerAdvanceR)
            Case P_Units.MetersPerMinute_R, Units.MetersPerMinute_R
                Return _unitPowerAdvanceP / (SecondsPerMinute ^ _siPowerAdvanceR)
            Case P_Units.MillimetersPerMinute_R, Units.MillimetersPerMinute_R
                Return _unitPowerAdvanceP * MetersPerMillimeter / (SecondsPerMinute ^ _siPowerAdvanceR)

            Case P_Units.CentimetersPerHour_R, Units.CentimetersPerHour_R
                Return _unitPowerAdvanceP * MetersPerCentimeter / (SecondsPerHour ^ _siPowerAdvanceR)
            Case P_Units.FeetPerHour_R, Units.FeetPerHour_R
                Return _unitPowerAdvanceP * MetersPerFoot / (SecondsPerHour ^ _siPowerAdvanceR)
            Case P_Units.InchesPerHour_R, Units.InchesPerHour_R
                Return _unitPowerAdvanceP * MetersPerInch / (SecondsPerHour ^ _siPowerAdvanceR)
            Case P_Units.MetersPerHour_R, Units.MetersPerHour_R
                Return _unitPowerAdvanceP / (SecondsPerHour ^ _siPowerAdvanceR)
            Case P_Units.MillimetersPerHour_R, Units.MillimetersPerHour_R
                Return _unitPowerAdvanceP * MetersPerMillimeter / (SecondsPerHour ^ _siPowerAdvanceR)

            Case Else
                Debug.Assert(False, "Invalid Power Advance p Units")
                Return _unitPowerAdvanceP
        End Select
    End Function
    '
    ' Convert SI units (m/s^r) to units Power Advance p
    '
    Public Shared Function UnitPowerAdvanceP(ByVal _siPowerAdvance As Double, ByVal _siPowerAdvanceR As Double, ByVal _units As P_Units) As Double
        Select Case _units
            Case P_Units.CentimetersPerSecond_R, Units.CentimetersPerSecond_R
                Return _siPowerAdvance * CentimetersPerMeter
            Case P_Units.FeetPerSecond_R, Units.FeetPerSecond_R
                Return _siPowerAdvance * FeetPerMeter
            Case P_Units.InchesPerSecond_R, Units.InchesPerSecond_R
                Return _siPowerAdvance * InchesPerMeter
            Case P_Units.MetersPerSecond_R, Units.MetersPerSecond_R
                Return _siPowerAdvance
            Case P_Units.MillimetersPerSecond_R, Units.MillimetersPerSecond_R
                Return _siPowerAdvance * MillimetersPerMeter

            Case P_Units.CentimetersPerMinute_R, Units.CentimetersPerMinute_R
                Return _siPowerAdvance * CentimetersPerMeter * (SecondsPerMinute ^ _siPowerAdvanceR)
            Case P_Units.FeetPerMinute_R, Units.FeetPerMinute_R
                Return _siPowerAdvance * FeetPerMeter * (SecondsPerMinute ^ _siPowerAdvanceR)
            Case P_Units.InchesPerMinute_R, Units.InchesPerMinute_R
                Return _siPowerAdvance * InchesPerMeter * (SecondsPerMinute ^ _siPowerAdvanceR)
            Case P_Units.MetersPerMinute_R, Units.MetersPerMinute_R
                Return _siPowerAdvance * (SecondsPerMinute ^ _siPowerAdvanceR)
            Case P_Units.MillimetersPerMinute_R, Units.MillimetersPerMinute_R
                Return _siPowerAdvance * MillimetersPerMeter * (SecondsPerMinute ^ _siPowerAdvanceR)

            Case P_Units.CentimetersPerHour_R, Units.CentimetersPerHour_R
                Return _siPowerAdvance * CentimetersPerMeter * (SecondsPerHour ^ _siPowerAdvanceR)
            Case P_Units.FeetPerHour_R, Units.FeetPerHour_R
                Return _siPowerAdvance * FeetPerMeter * (SecondsPerHour ^ _siPowerAdvanceR)
            Case P_Units.InchesPerHour_R, Units.InchesPerHour_R
                Return _siPowerAdvance * InchesPerMeter * (SecondsPerHour ^ _siPowerAdvanceR)
            Case P_Units.MetersPerHour_R, Units.MetersPerHour_R
                Return _siPowerAdvance * (SecondsPerHour ^ _siPowerAdvanceR)
            Case P_Units.MillimetersPerHour_R, Units.MillimetersPerHour_R
                Return _siPowerAdvance * MillimetersPerMeter * (SecondsPerHour ^ _siPowerAdvanceR)

            Case Else
                Debug.Assert(False, "Invalid Power Advance p Units")
                Return _siPowerAdvance
        End Select
    End Function
    '
    ' DisplayUnits() - returns current Display Units
    '
    Public Shared ReadOnly Property DisplayUnits() As P_Units
        Get
            If (mUnitsSystem.UnitSystem = UnitSystems.English) Then
                If (mUnitsSystem.TimeUnits = Units.Minutes) Then
                    Return P_Units.FeetPerMinute_R
                Else
                    Return P_Units.FeetPerHour_R
                End If
            Else
                If (mUnitsSystem.TimeUnits = Units.Minutes) Then
                    Return P_Units.MetersPerMinute_R
                Else
                    Return P_Units.MetersPerHour_R
                End If
            End If
        End Get
    End Property
    '
    ' SetValue(value, display units)
    '
    Public Sub SetValue(ByVal _value As Double, ByVal _displayUnits As P_Units, ByVal _powerAdvanceR As PropertyNode)

        ' Save a reference to the corresponding Power Advance r PropertyNode
        PowerAdvanceR = _powerAdvanceR

        ' Convert value to SI units before saving
        If (PowerAdvanceR IsNot Nothing) Then
            Value = SiPowerAdvanceP(_value, mLastR, _displayUnits)
        Else
            Value = _value
        End If
    End Sub

    Public Sub SetValue(ByVal _value As Double, ByVal _displayUnits As P_Units, ByVal _powerAdvanceR As Double)

        ' Save the value of the corresponding Power Advance r
        mLastR = _powerAdvanceR

        ' Convert value to SI units before saving
        Value = SiPowerAdvanceP(_value, mLastR, _displayUnits)
    End Sub

    Public Overrides Function ParseAndSetValue(ByVal _value As String) As Boolean

        Dim dvalue As Double
        Dim dunits As Units
        If (ParseValueWithUnits(_value, dvalue, dunits)) Then
            If (dunits = Units.None) Then ' no Units were specified; use Display Units
                dunits = DisplayUnits
            End If

            Value = SiPowerAdvanceP(dvalue, mLastR, dunits)
            Return True
        End If

        Return False
    End Function
    '
    ' value = GetValue(display units)
    '
    Public Function GetValue(ByVal _displayUnits As P_Units) As Double
        Dim _siValue As Double = Value
        Dim _dispValue As Double = UnitPowerAdvanceP(_siValue, mLastR, _displayUnits)

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
