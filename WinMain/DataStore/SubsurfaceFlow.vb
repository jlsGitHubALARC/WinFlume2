
'*************************************************************************************************************
' Subsurface Flow properties
'
' SubsurfaceFlow stores data that describes how irrigation water infiltrates into the field.
'
' NOTE: This class should be used for calculated Results only.  No user input data should be stored here.
'*************************************************************************************************************
Imports DataStore

Public Class SubsurfaceFlow

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Subsurface Flow"
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

#Region " Infiltration "

    '*********************************************************************************************************
    ' Upstream Infiltration Function (AZ - Infiltration volume per unit length)
    '*********************************************************************************************************
    Private Const sUpstreamInfiltrationFunction As String = "Upstream Infiltration Function"

    Public ReadOnly Property UpstreamInfiltrationFunctionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sUpstreamInfiltrationFunction)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sUpstreamInfiltrationFunction, _parameter)
                _propertyNode = mMyStore.GetProperty(sUpstreamInfiltrationFunction)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property UpstreamInfiltrationFunction() As DataTableParameter
        Get
            Dim _table As DataTableParameter = UpstreamInfiltrationFunctionProperty.GetDataTableParameter()

            If (_table.Value Is Nothing) Then
                _table.Value = New DataTable
                _table.Value.Columns.Add(sDistanceX, GetType(Double))
                _table.Value.Columns.Add(sInfiltrationAZ, GetType(Double))
            End If

            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            UpstreamInfiltrationFunctionProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearUpstreamInfiltrationFunction()
        mMyStore.DeleteProperty(sUpstreamInfiltrationFunction)
    End Sub

    '*********************************************************************************************************
    ' Upstream Infiltration Depth Function (AZ/FS | AZ/W - Infiltration volume per unit area)
    '*********************************************************************************************************
    Private Const sUpstreamInfiltration As String = "Upstream Infiltration"
    Private Const sUpstreamInfiltrationDepthFunction As String = "Upstream Infiltration Depth Function"

    Public ReadOnly Property UpstreamInfiltrationDepthFunctionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sUpstreamInfiltration)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sUpstreamInfiltration, _parameter)
                _propertyNode = mMyStore.GetProperty(sUpstreamInfiltration)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property UpstreamInfiltrationDepthFunction() As DataTableParameter
        Get
            Dim _table As DataTableParameter = UpstreamInfiltrationDepthFunctionProperty.GetDataTableParameter()

            If (_table.Value Is Nothing) Then
                _table.Value = New DataTable
                _table.Value.Columns.Add(sDistanceX, GetType(Double))
                _table.Value.Columns.Add(sInfiltrationX, GetType(Double))
            End If

            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            UpstreamInfiltrationDepthFunctionProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearUpstreamInfiltration()
        mMyStore.DeleteProperty(sUpstreamInfiltration)
    End Sub
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
                _table.Value = New DataTable(sInfiltration)
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
    '
    ' Ordered Infiltration Table
    '
    Private Const sOrderedInfiltration As String = "Ordered Infiltration"

    Public ReadOnly Property OrderedInfiltrationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sOrderedInfiltration)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sOrderedInfiltration, _parameter)
                _propertyNode = mMyStore.GetProperty(sOrderedInfiltration)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property OrderedInfiltration() As DataTableParameter
        Get
            Return OrderedInfiltrationProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            OrderedInfiltrationProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearOrderedInfiltration()
        mMyStore.DeleteProperty(sOrderedInfiltration)
    End Sub
    '
    ' Low-Quarter Depth (Dlq)
    '
    Public Const sLowQuarterDepth As String = "Low-Quarter Depth"
    Public Const sDlq As String = "Dlq"

    Public ReadOnly Property DlqProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sLowQuarterDepth)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sLowQuarterDepth, sDlq, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sLowQuarterDepth)
            End If

            _propertyNode.Symbol = sDlq
            _propertyNode.QueryOnly = True
            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property Dlq() As DoubleParameter
        Get
            Return DlqProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            DlqProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Average Depth (Davg)
    '
    Public Const sAverageDepth As String = "Average Depth"
    Private Const sDavg As String = "Davg"
    Public Const sDinf As String = "Dinf"

    Public ReadOnly Property DavgProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAverageDepth)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sAverageDepth, sDinf, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sAverageDepth)
            End If

            _propertyNode.Symbol = sDinf
            _propertyNode.QueryOnly = True
            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property Davg() As DoubleParameter
        Get
            Return DavgProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            DavgProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Minimum Depth (Dmin)
    '
    Public Const sMinimumDepth As String = "Minimum Depth"
    Public Const sDmin As String = "Dmin"

    Public ReadOnly Property DminProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinimumDepth)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sMinimumDepth, sDmin, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sMinimumDepth)
            End If

            _propertyNode.Symbol = sDmin
            _propertyNode.QueryOnly = True
            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property Dmin() As DoubleParameter
        Get
            Return DminProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            DminProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Applied Depth (Dapp)
    '
    Public Const sAppliedDepth As String = "Applied Depth"
    Public Const sDapp As String = "Dapp"

    Public ReadOnly Property DappProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAppliedDepth)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sAppliedDepth, sDapp, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sAppliedDepth)
            End If

            _propertyNode.Symbol = sDapp
            _propertyNode.QueryOnly = True
            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property Dapp() As DoubleParameter
        Get
            Return DappProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            DappProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Percentage Deep Percolation (DPpct)
    '
    Public Const sPercentageDeepPercolation As String = "Percentage Deep Percolation"
    Public Const sDPpct As String = "DP%"

    Public ReadOnly Property DPpctProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPercentageDeepPercolation)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Percentage)
                mMyStore.AddProperty(sPercentageDeepPercolation, sDPpct, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sPercentageDeepPercolation)
            End If

            _propertyNode.Symbol = sDPpct
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property DPpct() As DoubleParameter
        Get
            Return DPpctProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            DPpctProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Deep Percolation Depth (DP d)
    '
    Public Const sDeepPercolationDepth As String = "Deep Percolation Depth"
    Public Const sDdp As String = "Ddp"

    Public ReadOnly Property DPProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDeepPercolationDepth)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Millimeters)
                mMyStore.AddProperty(sDeepPercolationDepth, sDdp, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sDeepPercolationDepth)
            End If

            _propertyNode.Symbol = sDdp
            _propertyNode.QueryOnly = True
            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property DP() As DoubleParameter
        Get
            Return DPProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            DPProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Length Under Irrigated (Lui)
    '
    Public Const sLengthUnderIrrigated As String = "Length Under Irrigated"
    Public Const sLui As String = "Lui"

    Public ReadOnly Property LuiProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sLengthUnderIrrigated)

            ' If it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Meters)
                mMyStore.AddProperty(sLengthUnderIrrigated, sLui, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sLengthUnderIrrigated)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Lui() As DoubleParameter
        Get
            Return LuiProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            LuiProperty.SetParameter(Value)
        End Set
    End Property

    '*********************************************************************************************************
    Public Const sHydrusInfiltration As String = "HYDRUS Infiltration"

    Public ReadOnly Property HydrusInfiltrationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHydrusInfiltration)

            ' If Property was not found; create it
            ' If Property was found; validate its data
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter()
                mMyStore.AddProperty(sHydrusInfiltration, _parameter)
                _propertyNode = mMyStore.GetProperty(sHydrusInfiltration)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property HydrusInfiltration() As DataTableParameter
        Get
            Return HydrusInfiltrationProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            HydrusInfiltrationProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearHydrusInfiltration()
        mMyStore.DeleteProperty(sHydrusInfiltration)
    End Sub

#End Region

#Region " Distribution Uniformity "

    Public Const sDistributionUniformity As String = "Distribution Uniformity"
    Public Const sDU As String = "DU"

    Public ReadOnly Property DUProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDistributionUniformity)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultDU, Units.Fraction)
                mMyStore.AddProperty(sDistributionUniformity, sDU, _double, True)
                _propertyNode = mMyStore.GetProperty(sDistributionUniformity)
            Else
                Dim _double As DoubleParameter = _propertyNode.GetParameter()
                _double.Units = Units.Fraction
            End If

            _propertyNode.Symbol = sDU
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property DU() As DoubleParameter
        Get
            Dim _double As DoubleParameter = DUProperty.GetDoubleParameter()
            _double.Units = Units.Fraction
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            DUProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sDuLowQuarter As String = "Low-Quarter Distribution Uniformity"
    Public Const sDUlq As String = "DUlq"

    Public ReadOnly Property DUlqProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDuLowQuarter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultDU, Units.Fraction)
                mMyStore.AddProperty(sDuLowQuarter, sDUlq, _double, True)
                _propertyNode = mMyStore.GetProperty(sDuLowQuarter)
            Else
                Dim _double As DoubleParameter = _propertyNode.GetParameter()
                _double.Units = Units.Fraction
            End If

            _propertyNode.Symbol = sDUlq
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property DUlq() As DoubleParameter
        Get
            Dim _double As DoubleParameter = DUlqProperty.GetDoubleParameter()
            _double.Units = Units.Fraction
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            DUlqProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sDuMinimum As String = "Minimum Distribution Uniformity"
    Public Const sDUmin As String = "DUmin"

    Public ReadOnly Property DUminProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDuMinimum)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultDU, Units.Fraction)
                mMyStore.AddProperty(sDuMinimum, sDUmin, _double, True)
                _propertyNode = mMyStore.GetProperty(sDuMinimum)
            Else
                Dim _double As DoubleParameter = _propertyNode.GetParameter()
                _double.Units = Units.Fraction
            End If

            _propertyNode.Symbol = sDUmin
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property DUmin() As DoubleParameter
        Get
            Dim _double As DoubleParameter = DUminProperty.GetDoubleParameter()
            _double.Units = Units.Fraction
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            DUminProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Requirement Efficiency "
    '
    ' Requirement Efficiency (RE)
    '
    Public Const sRequirementEfficiency As String = "Requirement Efficiency"
    Public Const sRE As String = "RE"

    Public ReadOnly Property REProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRequirementEfficiency)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Percentage)
                mMyStore.AddProperty(sRequirementEfficiency, sRE, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sRequirementEfficiency)
            End If

            _propertyNode.Symbol = sRE
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property RE() As DoubleParameter
        Get
            Return REProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            REProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Application Efficiency "
    '
    ' Application Efficiency (AE)
    '
    Public Const sApplicationEfficiency As String = "Application Efficiency"
    Public Const sAE As String = "AE"

    Public ReadOnly Property AEProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sApplicationEfficiency)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Percentage)
                mMyStore.AddProperty(sApplicationEfficiency, sAE, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sApplicationEfficiency)
            End If

            _propertyNode.Symbol = sAE
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property AE() As DoubleParameter
        Get
            Return AEProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            AEProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Potential Application Efficiency (PAE)
    '
    Public Const sPotentialApplicationEfficiency As String = "Potential Application Efficiency"
    Public Const sPAE As String = "PAE"

    Public ReadOnly Property PAEProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPotentialApplicationEfficiency)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Percentage)
                mMyStore.AddProperty(sPotentialApplicationEfficiency, sPAE, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sPotentialApplicationEfficiency)
            End If

            _propertyNode.Symbol = sPAE
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property PAE() As DoubleParameter
        Get
            Return PAEProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            PAEProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Low-Quarter Potential Application Efficiency (PAElq)
    '
    Public Const sLowQuarterPAE As String = "Low-Quarter PAE"
    Public Const sPAElq As String = "PAElq"

    Public ReadOnly Property PAElqProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sLowQuarterPAE)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Percentage)
                mMyStore.AddProperty(sLowQuarterPAE, sPAElq, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sLowQuarterPAE)
            End If

            _propertyNode.Symbol = sPAElq
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property PAElq() As DoubleParameter
        Get
            Return PAElqProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            PAElqProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Minimum Potential Application Efficiency (PAEmin)
    '
    Public Const sMinimumPAE As String = "Minimum PAE"
    Public Const sPAEmin As String = "PAEmin"

    Public ReadOnly Property PAEminProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinimumPAE)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.Percentage)
                mMyStore.AddProperty(sMinimumPAE, sPAEmin, _parameter, True)
                _propertyNode = mMyStore.GetProperty(sMinimumPAE)
            End If

            _propertyNode.Symbol = sPAEmin
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property PAEmin() As DoubleParameter
        Get
            Return PAEminProperty.GetDoubleParameter
        End Get
        Set(ByVal Value As DoubleParameter)
            PAEminProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Adequacy "
    '
    ' Minimum Adequacy (ADmin)
    '
    Public Const sMinimumAdequacy As String = "Minimum Adequacy"
    Public Const sADmin As String = "ADmin"

    Public ReadOnly Property ADminProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinimumAdequacy)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Fraction)
                mMyStore.AddProperty(sMinimumAdequacy, sADmin, _double, True)
                _propertyNode = mMyStore.GetProperty(sMinimumAdequacy)
            Else
                Dim _double As DoubleParameter = _propertyNode.GetParameter()
                _double.Units = Units.Fraction
            End If

            _propertyNode.Symbol = sADmin
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property ADmin() As DoubleParameter
        Get
            Dim _double As DoubleParameter = ADminProperty.GetDoubleParameter()
            _double.Units = Units.Fraction
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            ADminProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Low-Quarter Adequacy (ADlq)
    '
    Public Const sLowQuarterAdequacy As String = "Low-Quarter Adequacy"
    Public Const sADlq As String = "ADlq"

    Public ReadOnly Property ADlqProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sLowQuarterAdequacy)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(0.0, Units.Fraction)
                mMyStore.AddProperty(sLowQuarterAdequacy, sADlq, _double, True)
                _propertyNode = mMyStore.GetProperty(sLowQuarterAdequacy)
            Else
                Dim _double As DoubleParameter = _propertyNode.GetParameter()
                _double.Units = Units.Fraction
            End If

            _propertyNode.Symbol = sADlq
            _propertyNode.QueryOnly = True
            Return _propertyNode
        End Get
    End Property

    Public Property ADlq() As DoubleParameter
        Get
            Dim _double As DoubleParameter = ADlqProperty.GetDoubleParameter()
            _double.Units = Units.Fraction
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            ADlqProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Profiles "
    '
    ' Average Infiltrated Area (AZ) Profile Table
    '
    Private Const sAZavgProfile As String = "AZavg Profile"

    Public ReadOnly Property AZavgProfilesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAZavgProfile)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter
                mMyStore.AddProperty(sAZavgProfile, _parameter)
                _propertyNode = mMyStore.GetProperty(sAZavgProfile)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AZavgProfile() As DataTableParameter
        Get
            Return AZavgProfilesProperty.GetDataTableParameter()
        End Get
        Set(ByVal Value As DataTableParameter)
            AZavgProfilesProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearAZavgProfiles()
        mMyStore.DeleteProperty(sAZavgProfile)
    End Sub

#End Region

#End Region

#Region " Calculated Properties "
    '
    ' Calculate Average Infiltrated Depth from Longitudinal Infiltration table
    '
    Public Function AverageLongitudinalInfiltrationDepth() As Double
        ' Get the Longitudinal Infiltration table
        Dim zTable As DataTable = LongitudinalInfiltration.Value
        ' Average Infiltrated Depth
        Dim Davg As Double = SoilCropProperties.AverageInfiltrationDepth(zTable)
        Return Davg
    End Function
    '
    ' Calculate Low-Quarter Average Infiltrated Depth from Longitudinal Infiltration table
    '
    Public Function AverageLongitudinalInfiltrationDepthLQ() As Double
        ' Get the Longitudinal Infiltration table
        Dim zTable As DataTable = LongitudinalInfiltration.Value
        ' Low-Quarter Average Infiltrated Depth
        Dim DavgLQ As Double = SoilCropProperties.AverageInfiltrationDepthLQ(zTable)
        Return DavgLQ
    End Function
    '
    ' Calculate Length Under-Irrigated
    '
    Public Function LengthUnderIrrigated() As Double
        ' Get the Longitudinal Infiltration table
        Dim _idTable As DataTable = LongitudinalInfiltration.Value
        Dim _reqDepth As Double = mUnit.InflowManagementRef.RequiredDepth.Value

        Dim _lengthUnderIrrigated As Double = SoilCropProperties.LengthUnderIrrigated(_idTable, _reqDepth)

        Return _lengthUnderIrrigated
    End Function
    '
    ' Infiltrated Volume (per basin, border or furrow)
    '
    Public Function InfiltratedVolume() As Double
        Dim davg As Double = Me.Davg.Value
        Dim length As Double = mUnit.SystemGeometryRef.Length.Value
        Dim width As Double = mUnit.SystemGeometryRef.WidthForCrossSection

        Dim infVolume As Double = length * width * davg

        Dim tableParam As DataTableParameter = LongitudinalInfiltrationProperty.GetDataTableParameter()

        If Not (tableParam Is Nothing) Then
            Dim table As DataTable = tableParam.Value
            If Not (table Is Nothing) Then
                If (2 <= table.Rows.Count) Then
                    Dim infArea As Double = 0.0

                    Dim row As DataRow = table.Rows(0)
                    Dim dist1 As Double = CDbl(row.Item(nDistanceX))
                    Dim infDepth1 As Double = CDbl(row.Item(nInfiltrationX))

                    For idx As Integer = 1 To table.Rows.Count - 1
                        row = table.Rows(idx)
                        Dim dist2 As Double = CDbl(row.Item(nDistanceX))
                        Dim infDepth2 As Double = CDbl(row.Item(nInfiltrationX))

                        infArea += (dist2 - dist1) * (infDepth2 + infDepth1) / 2.0

                        dist1 = dist2
                        infDepth1 = infDepth2
                    Next

                    infVolume = infArea * width
                End If
            End If
        End If

        Return infVolume
    End Function

    Public Function InfiltratedDepth() As Double
        Dim Vinf As Double = InfiltratedVolume()
        Dim area As Double = mUnit.SystemGeometryRef.AreaForCrossSection
        Dim Dinf As Double = Vinf / area
        Return Dinf
    End Function

    Public Function CalculatedUpstreamInfiltration(ByVal NumPoints As Integer) As DataTable

        CalculatedUpstreamInfiltration = Nothing
        '
        ' Calculate the Infiltration Function DataTable based on the Infiltration Method
        '
        Dim _soilCropProperties As SoilCropProperties = mUnit.SoilCropPropertiesRef

        ' For most infiltration methods, Zn = Upstream Infiltrated Depth
        Dim _depthTable As DataTable = Me.LongitudinalInfiltration.Value
        If DataTableHasData(_depthTable) Then
            If (_depthTable.Columns.Contains(sInfiltrationX)) Then
                Dim _row As DataRow = _depthTable.Rows(0)

                Dim Zn As Double = CDbl(_row.Item(sInfiltrationX))
                Dim Tn As Double = _soilCropProperties.InfiltrationTime(Zn)

                CalculatedUpstreamInfiltration = _soilCropProperties.InfiltrationFunctionDataTable(Tn, NumPoints)
            End If
        End If

    End Function

    Public Function InfiltrationAtDistance(ByVal distance As Double) As Double
        Dim infiltration As Double = Double.NaN

        ' Get Infiltration Table
        Dim infiltrationTable As DataTable = Me.LongitudinalInfiltration.Value
        If Not (infiltrationTable Is Nothing) Then
            If (0 < infiltrationTable.Rows.Count) Then

                ' Get Distance & Time for first Advance row
                Dim dist1 As Double = 0.0
                Dim infilt1 As Double = 0.0
                Dim dist2 As Double = 0.0
                Dim infilt2 As Double = 0.0

                For idx As Integer = 0 To infiltrationTable.Rows.Count - 1
                    Dim advanceRow As DataRow = infiltrationTable.Rows(idx)
                    dist2 = CDbl(advanceRow.Item(sDistanceX))
                    infilt2 = CDbl(advanceRow.Item(sInfiltrationX))

                    If (ThisClose(dist2, distance, OneDecimeter)) Then
                        ' At the requested Distance
                        infiltration = infilt2
                        Exit For
                    ElseIf (dist2 < distance) Then
                        ' Before the requested distance
                        infiltration = 0.0
                    Else ' _distance < _rowDist
                        ' Past the requested distance
                        infiltration = infilt1 + ((distance - dist1) * (infilt2 - infilt1) / (dist2 - dist1))
                        Exit For
                    End If

                    dist1 = dist2
                    infilt1 = infilt2
                Next

                If (infiltration = 0.0) Then
                    If (distance < dist1 + OneMeter) Then
                        infiltration = infilt1
                    End If
                End If
            End If
        End If

        Return infiltration
    End Function

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
        ' Add SubsurfaceFlow to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "SubsurfaceFlow not added to Data Store")
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
        Me.ClearLongitudinalInfiltration()
        Me.ClearOrderedInfiltration()
        Me.ClearUpstreamInfiltration()
        Me.ClearUpstreamInfiltrationFunction()
        Me.ClearHydrusInfiltration()

        Me.ClearAZavgProfiles()

        ' Clear properties that were used in the past but no more.
        Dim fertigationInfiltration As PropertyNode = mMyStore.GetProperty("Fertigation Infiltration")
        If (fertigationInfiltration IsNot Nothing) Then
            mMyStore.DeleteProperty("Fertigation Infiltration")
        End If
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        Infiltration
        DistributionUniformity
        ApplicationEfficiency
        Adequacy
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
        ' Regenerate the DataStore event as a Subsurface Flow event
        Select Case _id
            Case sLongitudinalInfiltration
                RaiseEvent PropertyDataChanged(Reasons.Infiltration)
            Case sDistributionUniformity
                RaiseEvent PropertyDataChanged(Reasons.DistributionUniformity)
            Case sApplicationEfficiency
                RaiseEvent PropertyDataChanged(Reasons.ApplicationEfficiency)
            Case sMinimumAdequacy, sLowQuarterAdequacy
                RaiseEvent PropertyDataChanged(Reasons.Adequacy)
        End Select
    End Sub

#End Region

End Class
