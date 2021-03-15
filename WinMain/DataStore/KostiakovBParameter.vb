
'*************************************************************************************************************
' KostiakovBParameter - special parameter to handle Kostiakov b.
'
' KostiakovBParameter is very similar to DoubleParameter except that it limits its Time Units to Hours.
'*************************************************************************************************************
Imports DataStore
Imports System.Runtime.Serialization

<Serializable()> _
Public Class KostiakovBParameter
    Inherits DoubleParameter

#Region " Constructor(s) "
    '
    ' Required for De-serialzation
    '
    Sub New()
        MyBase.New()
    End Sub
    '
    ' Normal application code constructors
    '
    Public Sub New(ByVal _default As Double, ByVal _unitsText As String)
        MyBase.New(_default, _unitsText)
    End Sub

    Public Sub New(ByVal _default As Double, ByVal _units As UnitsDefinition.Units)
        MyBase.New(_default, _units)
    End Sub
    '
    ' New clone
    '
    Protected Friend Sub New(ByVal _parameter As KostiakovBParameter)
        MyBase.New(_parameter)
    End Sub

    Protected Friend Sub New(ByVal _parameter As DoubleParameter)
        MyBase.New(_parameter)
    End Sub
    '
    ' New for sub-classes
    '
    Public Sub New(ByVal _default As Double)
        MyBase.New(_default)
    End Sub

#End Region

#Region " Serialization "
    '
    ' Serialization
    '
    Public Overrides Sub GetObjectData(ByVal _info As SerializationInfo, _
                                       ByVal _context As StreamingContext)
        MyBase.GetObjectData(_info, _context)
    End Sub
    '
    ' De-serialization
    '
    Public Sub New(ByVal _info As SerializationInfo, _
                   ByVal _context As StreamingContext)
        MyBase.New(_info, _context)
    End Sub

#End Region

#Region " Methods "
    '
    ' DisplayUnits() - returns current Display Units limiting Time to Hours
    '
    Public Overrides Function DisplayUnits() As Units
        If (UnitsSystem.Instance.UnitSystem = UnitSystems.English) Then
            Return Units.InchesPerHour
        Else
            Return Units.MillimetersPerHour
        End If
    End Function
    '
    ' SetValue
    '
    Public Overrides Function ParseAndSetValue(ByVal _value As String) As Boolean

        Dim dvalue As Double
        Dim dunits As Units
        If (ParseValueWithUnits(_value, dvalue, dunits)) Then
            If (dunits = Units.None) Then ' no Units were specified; use Display Units
                dunits = Me.DisplayUnits
                dvalue = SiValue(dvalue, dunits)
            End If

            Me.Value = dvalue
            Return True
        End If

        Return False
    End Function
    '
    ' Clipboard
    '
    Public Overrides Sub Copy()
        MyBase.Copy()
    End Sub

#End Region

End Class
