
'*************************************************************************************************************
' Erosion properties
'
' Erosion stores user entered and SRFR generated data that describe the entrainment, transport & deposition of
' constituents (e.g. soil) out of/with/into the surface irrigation water.
'*************************************************************************************************************
Imports DataStore

Imports Srfr
Imports Srfr.ConstituentTransport

Public Class Erosion

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Erosion"
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

#Region " UI Properties "

    Public Const sEnableErosion As String = "Enable Erosion"

    Public ReadOnly Property EnableErosionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableErosion)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultEnableErosion)
                mMyStore.AddProperty(sEnableErosion, _boolean)
                _propertyNode = mMyStore.GetProperty(sEnableErosion)
            End If

            If Not (WinSRFR.UserLevel = UserLevels.Research) Then
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _bparam As BooleanParameter = DirectCast(_param, BooleanParameter)
                _bparam.Value = False
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableErosion() As BooleanParameter
        Get
            Return EnableErosionProperty.GetBooleanParameter()
        End Get
        Set(ByVal Value As BooleanParameter)
            EnableErosionProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sParticleDiameter As String = "Particle Diameter"

    Public ReadOnly Property ParticleDiameterProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sParticleDiameter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(FiftyMicrons, Units.Microns)
                mMyStore.AddProperty(sParticleDiameter, _double)
                _propertyNode = mMyStore.GetProperty(sParticleDiameter)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ParticleDiameter() As DoubleParameter
        Get
            Return ParticleDiameterProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ParticleDiameterProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sSpecificGravity As String = "Specific Gravity"

    Public ReadOnly Property SpecificGravityProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSpecificGravity)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(2.65, Units.None)
                mMyStore.AddProperty(sSpecificGravity, _double)
                _propertyNode = mMyStore.GetProperty(sSpecificGravity)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SpecificGravity() As DoubleParameter
        Get
            Return SpecificGravityProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SpecificGravityProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sEnableCriticalShear As String = "Enable Critical Shear"

    Public ReadOnly Property EnableCriticalShearProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEnableCriticalShear)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(DefaultEnableCriticalShear)
                mMyStore.AddProperty(sEnableCriticalShear, _boolean)
                _propertyNode = mMyStore.GetProperty(sEnableCriticalShear)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EnableCriticalShear() As BooleanParameter
        Get
            Dim tabulated As BooleanParameter = EnableCriticalShearProperty.GetBooleanParameter()

            ' Not for Standard Users
            If (WinSRFR.UserLevel = UserLevels.Standard) Then
                tabulated.Value = False
            End If

            Return tabulated
        End Get
        Set(ByVal Value As BooleanParameter)
            EnableCriticalShearProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sCriticalShear As String = "Critical Shear"

    Public ReadOnly Property CriticalShearProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCriticalShear)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.05, Units.NewtonsPerSquareMeter)
                mMyStore.AddProperty(sCriticalShear, _double)
                _propertyNode = mMyStore.GetProperty(sCriticalShear)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CriticalShear() As DoubleParameter
        Get
            Return CriticalShearProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CriticalShearProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sKr As String = "Kr"

    Public ReadOnly Property KrProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKr)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0056, Units.SecondsPerMeter)
                mMyStore.AddProperty(sKr, _double)
                _propertyNode = mMyStore.GetProperty(sKr)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Kr() As DoubleParameter
        Get
            Return KrProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            KrProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sKinematicViscosity As String = "Kinematic Viscosity"

    Public ReadOnly Property KinematicViscosityProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sKinematicViscosity)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultKinematicViscosity, _
                                                                     Units.SquareMetersPerSecond)
                mMyStore.AddProperty(sKinematicViscosity, _double)
                _propertyNode = mMyStore.GetProperty(sKinematicViscosity)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property KinematicViscosity() As DoubleParameter
        Get
            Return KinematicViscosityProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            KinematicViscosityProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sWaterTemp As String = "Water Temperature"

    Public ReadOnly Property WaterTempProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sWaterTemp)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultWaterTempC, Units.DegreesC)
                mMyStore.AddProperty(sWaterTemp, _double)
                _propertyNode = mMyStore.GetProperty(sWaterTemp)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property WaterTemp() As DoubleParameter
        Get
            Return WaterTempProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            WaterTempProperty.SetParameter(Value)
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
    ' Mass Transport Hydrograph Table
    '
    Private Const sMassTransportHydrographs As String = "Mass Transport Hydrographs"

    Public ReadOnly Property MassTransportHydrographsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMassTransportHydrographs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sMassTransportHydrographs, _parameter)
                _propertyNode = mMyStore.GetProperty(sMassTransportHydrographs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MassTransportHydrographs() As DataTableParameter
        Get
            Return MassTransportHydrographsProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            MassTransportHydrographsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearMassTransportHydrographs()
        mMyStore.DeleteProperty(sMassTransportHydrographs)
    End Sub
    '
    ' Mass Concentration Hydrograph Table
    '
    Private Const sMassConcentrationHydrographs As String = "Mass Concentration Hydrographs"

    Public ReadOnly Property MassConcentrationHydrographsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMassConcentrationHydrographs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sMassConcentrationHydrographs, _parameter)
                _propertyNode = mMyStore.GetProperty(sMassConcentrationHydrographs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MassConcentrationHydrographs() As DataTableParameter
        Get
            Return MassConcentrationHydrographsProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            MassConcentrationHydrographsProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearMassConcentrationHydrographs()
        mMyStore.DeleteProperty(sMassConcentrationHydrographs)
    End Sub
    '
    ' Soil movement / loss
    '
    Private Const sGL01 As String = "GL01"

    Public ReadOnly Property GL01Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGL01)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Kilograms)
                mMyStore.AddProperty(sGL01, _double)
                _propertyNode = mMyStore.GetProperty(sGL01)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property GL01() As DoubleParameter
        Get
            Return GL01Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            GL01Property.SetParameter(Value)
        End Set
    End Property

    Private Const sGL02 As String = "GL02"

    Public ReadOnly Property GL02Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGL02)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Kilograms)
                mMyStore.AddProperty(sGL02, _double)
                _propertyNode = mMyStore.GetProperty(sGL02)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property GL02() As DoubleParameter
        Get
            Return GL02Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            GL02Property.SetParameter(Value)
        End Set
    End Property

    Private Const sGL03 As String = "GL03"

    Public ReadOnly Property GL03Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGL03)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Kilograms)
                mMyStore.AddProperty(sGL03, _double)
                _propertyNode = mMyStore.GetProperty(sGL03)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property GL03() As DoubleParameter
        Get
            Return GL03Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            GL03Property.SetParameter(Value)
        End Set
    End Property

    Private Const sGL04 As String = "GL04"

    Public ReadOnly Property GL04Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGL04)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Kilograms)
                mMyStore.AddProperty(sGL04, _double)
                _propertyNode = mMyStore.GetProperty(sGL04)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property GL04() As DoubleParameter
        Get
            Return GL04Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            GL04Property.SetParameter(Value)
        End Set
    End Property

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
            mParentStore = mUnit.MyStore
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Add Erosion to Parent's Data Store
        '
        If (mParentStore IsNot Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If (mMyStore IsNot Nothing) Then ' enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "Erosion not added to Data Store")
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
        Me.ClearMassTransportHydrographs()
        Me.ClearMassConcentrationHydrographs()
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        EnableErosion

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
        ' Regenerate the DataStore event as a Erosion event
        Select Case _id
            Case sEnableErosion
                RaiseEvent PropertyDataChanged(Reasons.EnableErosion)

            Case Else
                RaiseEvent PropertyDataChanged(Reasons.Other)
        End Select
    End Sub

#End Region

End Class
