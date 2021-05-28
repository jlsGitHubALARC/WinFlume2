
'*************************************************************************************************************
' Class InflowManagement - stores user entered data describing the flow of water onto, over and off the field.
'
' Inflow Management properties - this class has evolved into a Flow Management class; not just Inflow
'
' The primary groups of user inputs managed by the InflowManagement class/object are:
'
'   Inflow               - the flow of water onto the field
'   Runoff               -  "    "   "   "   off   "    "
'   Advance              -  "    "   "   "   down  "    "
'   Recession            -  " recession of water along the field
'   Flow Depths          -  " depth      "   "     "    "    "
'   
'   Measurement Stations - stations along the field where advance, flow depth and recession are measured
'*************************************************************************************************************
Imports DataStore

Public Class InflowManagement

#Region " Identification "
    '
    ' Internal object ID
    '
    Private mMyID As String = "Inflow Management"
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

#Region " Costs "
    '
    ' Unit Water Cost
    '
    Public Const sUnitWaterCost As String = "Unit Water Cost"
    Public Const sCost As String = "Cost"

    Public ReadOnly Property UnitWaterCostProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sUnitWaterCost)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultUnitWaterCost, Units.DollarsPerML)
                mMyStore.AddProperty(sUnitWaterCost, _double)
                _propertyNode = mMyStore.GetProperty(sUnitWaterCost)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property UnitWaterCost() As DoubleParameter
        Get
            Return UnitWaterCostProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            UnitWaterCostProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Unit Labor Cost
    '
    'Public Const sUnitLaborCost As String = "Unit Labor Cost"

    'Public ReadOnly Property UnitLaborCostProperty() As PropertyNode
    '    Get
    '        Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sUnitLaborCost)

    '        ' If it was not found; create it
    '        If (_propertyNode Is Nothing) Then
    '            Dim _double As DoubleParameter = New DoubleParameter(DefaultUnitLaborCost, Units.DollarsPerML)
    '            mMyStore.AddProperty(sUnitLaborCost, _double)
    '            _propertyNode = mMyStore.GetProperty(sUnitLaborCost)
    '        End If

    '        Return _propertyNode
    '    End Get
    'End Property

    'Public Property UnitLaborCost() As DoubleParameter
    '    Get
    '        Return UnitLaborCostProperty.GetDoubleParameter()
    '    End Get
    '    Set(ByVal Value As DoubleParameter)
    '        UnitLaborCostProperty.SetParameter(Value)
    '    End Set
    'End Property
    '
    ' Cost
    '
    Public ReadOnly Property CostProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCost)

            ' if it was not found, create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DoubleParameter = New DoubleParameter(0.0, Units.DollarsPerHectare)
                mMyStore.AddProperty(sCost, sCost, _parameter)
                _propertyNode = mMyStore.GetProperty(sCost)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Cost() As DoubleParameter
        Get
            Return CostProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CostProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Required Depth (Dreq) "
    '
    ' Required Depth
    '
    Private Const sTargetInfiltrationDepth As String = "Target Infiltration Depth"
    Public Const sDreq As String = "Dreq"

    Public ReadOnly Property RequiredDepthProperty() As PropertyNode
        Get
            ' Attempt to get property using current name
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRequiredDepth)

            ' If not found, try old name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sTargetInfiltrationDepth)

                ' If not found, create it
                If (_propertyNode Is Nothing) Then
                    Dim _double As DoubleParameter = New DoubleParameter(DefaultRequiredDepth, Units.Millimeters)
                    mMyStore.AddProperty(sRequiredDepth, sDreq, _double)
                    _propertyNode = mMyStore.GetProperty(sRequiredDepth)
                Else
                    ' Rename to current name
                    _propertyNode.MyID = sRequiredDepth
                End If
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property RequiredDepth() As DoubleParameter
        Get
            Return RequiredDepthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            RequiredDepthProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Inflow "

#Region " Inflow Method "
    '
    ' Inflow Method
    '
    Public Const sInflowMethod As String = "Inflow Method"

    Public ReadOnly Property InflowMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInflowMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultInflowMethod)
                mMyStore.AddProperty(sInflowMethod, _integer)
                _propertyNode = mMyStore.GetProperty(sInflowMethod)
            Else
                Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
                If (_userLevel = UserLevels.Standard) Then
                    Dim _param As Parameter = _propertyNode.GetParameter
                    Dim _integerParam As IntegerParameter = DirectCast(_param, IntegerParameter)
                    Select Case (_integerParam.Value)
                        Case InflowMethods.StandardHydrograph, InflowMethods.TabulatedInflow ' OK for Standard User
                        Case Else
                            _integerParam.Value = InflowMethods.StandardHydrograph
                    End Select
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InflowMethod() As IntegerParameter
        Get
            Return InflowMethodProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            InflowMethodProperty.SetParameter(Value)
        End Set
    End Property

    Private mInflowMethodIndex As Integer = -1
    Public Function GetFirstInflowMethodSelection(ByRef _sel As String) As Boolean
        mInflowMethodIndex = -1
        Return GetNextInflowMethodSelection(_sel)
    End Function

    Public Function GetNextInflowMethodSelection(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mInflowMethodIndex += 1
        If (mInflowMethodIndex < InflowMethods.HighLimit) Then
            _sel = InflowMethodSelections(mInflowMethodIndex).Value
            If ((InflowMethodSelections(mInflowMethodIndex).Flags And _flags) = 0) Then
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

#Region " Standard Hydrograph "

#Region " Inflow Rate "
    '
    ' Inflow Rate (Qin)
    '
    Public Const sInflowRate As String = "Inflow Rate"
    Public Const sQin As String = "Qin"

    Public ReadOnly Property InflowRateProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInflowRate)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultInflowRate, Units.Lps)
                mMyStore.AddProperty(sInflowRate, sQin, _double)
                _propertyNode = mMyStore.GetProperty(sInflowRate)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InflowRate() As DoubleParameter
        Get
            Return InflowRateProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            InflowRateProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Cutoff "
    '
    ' Cutoff Method
    '
    Public Const sCutoffMethod As String = "Cutoff Method"

    Public ReadOnly Property CutoffMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutoffMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultCutoffMethod)
                mMyStore.AddProperty(sCutoffMethod, _integer)
                _propertyNode = mMyStore.GetProperty(sCutoffMethod)
            End If

            ' Only Time-Based cutoff allowed for HYDRUS (i.e. Richard's) infiltration
            Dim _infiltFunc As IntegerParameter = mUnit.SoilCropPropertiesRef.InfiltrationFunction
            If (_infiltFunc IsNot Nothing) Then
                If (_infiltFunc.Value = InfiltrationFunctions.Hydrus1D) Then
                    Dim _param As Parameter = _propertyNode.GetParameter
                    Dim _intParam As IntegerParameter = DirectCast(_param, IntegerParameter)
                    _intParam.Value = CutoffMethods.TimeBased
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutoffMethod() As IntegerParameter
        Get
            Return CutoffMethodProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            CutoffMethodProperty.SetParameter(Value)
        End Set
    End Property

    Private mCutoffMethodIndex As Integer = -1
    Public Function GetFirstCutoffMethodSelection(ByRef _sel As String) As Boolean
        mCutoffMethodIndex = -1
        Return GetNextCutoffMethodSelection(_sel)
    End Function

    Public Function GetNextCutoffMethodSelection(ByRef _sel As String) As Boolean
        Dim _world As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = mUnit.CrossSection
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_world, _crossSection, _userLevel)

        mCutoffMethodIndex += 1
        If (mCutoffMethodIndex < CutoffMethods.HighLimit) Then
            _sel = CutoffMethodSelections(mCutoffMethodIndex).Value
            If ((CutoffMethodSelections(mCutoffMethodIndex).Flags And _flags) = 0) Then

                ' Only Time-Based cutoff allowed for HYDRUS (i.e. Richard's) infiltration
                Dim _infiltFunc As IntegerParameter = mUnit.SoilCropPropertiesRef.InfiltrationFunction
                If (_infiltFunc IsNot Nothing) Then
                    If (_infiltFunc.Value = InfiltrationFunctions.Hydrus1D) Then
                        If (_sel = sTimeBasedCutoff) Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                End If

                ' Selection is valid for World, User Level & Cross Section
                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function
    '
    ' Cutoff Time (Tco)
    '
    Public Const sCutoffTime As String = "Cutoff Time"
    Public Const sTco As String = "Tco"

    Public ReadOnly Property CutoffTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutoffTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultCutoffTime, Units.Hours)
                mMyStore.AddProperty(sCutoffTime, sTco, _double)
                _propertyNode = mMyStore.GetProperty(sCutoffTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutoffTime() As DoubleParameter
        Get
            Return CutoffTimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CutoffTimeProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Relative Cutoff Distance (R)
    '
    Public Const sCutoffLocation As String = "Cutoff Location"
    Public Const sCutoffLocationRatio As String = "Cutoff Location Ratio"
    Public Const sRelativeCutoffDistance As String = "Relative Cutoff Distance"
    Public Const sR As String = "R"

    Public ReadOnly Property CutoffLocationRatioProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRelativeCutoffDistance)

            ' If it was not found; try older names
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sCutoffLocation)

                If (_propertyNode Is Nothing) Then
                    _propertyNode = mMyStore.GetProperty(sCutoffLocationRatio)

                    ' If it was not found; create it
                    If (_propertyNode Is Nothing) Then
                        Dim _double As DoubleParameter = New DoubleParameter(DefaultCutoffLocationRatio, "x L")
                        mMyStore.AddProperty(sRelativeCutoffDistance, sR, _double)
                        _propertyNode = mMyStore.GetProperty(sRelativeCutoffDistance)
                    Else
                        _propertyNode.MyID = sRelativeCutoffDistance

                        Dim _param As Parameter = _propertyNode.GetParameter
                        If (_param.GetType Is GetType(DoubleParameter)) Then
                            Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                            _double.TextUnits = "x L"
                        End If
                    End If

                Else
                    _propertyNode.MyID = sRelativeCutoffDistance

                    Dim _param As Parameter = _propertyNode.GetParameter
                    If (_param.GetType Is GetType(DoubleParameter)) Then
                        Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                        _double.TextUnits = "x L"
                    End If
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutoffLocationRatio() As DoubleParameter
        Get
            Return CutoffLocationRatioProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CutoffLocationRatioProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Cutoff Infiltration Depth
    '
    Public Const sCutoffInfiltrationDepth As String = "Cutoff Infiltration Depth"
    Public Const sRDinf As String = "RDinf"

    Public ReadOnly Property CutoffInfiltrationDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutoffInfiltrationDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultCutoffInfiltrationDepth, "x Dreq")
                mMyStore.AddProperty(sCutoffInfiltrationDepth, _double)
                _propertyNode = mMyStore.GetProperty(sCutoffInfiltrationDepth)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.GetType Is GetType(DoubleParameter)) Then
                    Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                    _double.TextUnits = "x Dreq"
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutoffInfiltrationDepth() As DoubleParameter
        Get
            Return CutoffInfiltrationDepthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CutoffInfiltrationDepthProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Cutoff Opportunity Time
    '
    Public Const sCutoffOpportunityTime As String = "Cutoff Opportunity Time"
    Public Const sTnR As String = "TnR"

    Public ReadOnly Property CutoffOpportunityTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutoffOpportunityTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultCutoffOpportunityTime, Units.Hours)
                mMyStore.AddProperty(sCutoffOpportunityTime, _double)
                _propertyNode = mMyStore.GetProperty(sCutoffOpportunityTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutoffOpportunityTime() As DoubleParameter
        Get
            Return CutoffOpportunityTimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CutoffOpportunityTimeProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Cutoff Upstream Depth
    '
    Public Const sCutoffUpstreamDepth As String = "Cutoff Upstream Depth"
    Public Const sRDup As String = "RDup"

    Public ReadOnly Property CutoffUpstreamDepthProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutoffUpstreamDepth)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultCutoffUpstreamDepth, "x Dreq")
                mMyStore.AddProperty(sCutoffUpstreamDepth, _double)
                _propertyNode = mMyStore.GetProperty(sCutoffUpstreamDepth)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.GetType Is GetType(DoubleParameter)) Then
                    Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                    _double.TextUnits = "x Dreq"
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutoffUpstreamDepth() As DoubleParameter
        Get
            Return CutoffUpstreamDepthProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CutoffUpstreamDepthProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Draw Down Time
    '
    Public Const sDrawDownTime As String = "Draw Down Time"
    Public Const sRTdd As String = "RTdd"

    Public ReadOnly Property DrawDownTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDrawDownTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultDrawDownTime, Units.Minutes)
                mMyStore.AddProperty(sDrawDownTime, _double)
                _propertyNode = mMyStore.GetProperty(sDrawDownTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DrawDownTime() As DoubleParameter
        Get
            Return DrawDownTimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            DrawDownTimeProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Cutback "
    '
    ' Cutback Method
    '
    Public Const sCutbackMethod As String = "Cutback Method"

    Public ReadOnly Property CutbackMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutbackMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultCutbackMethod)
                mMyStore.AddProperty(sCutbackMethod, _integer)
                _propertyNode = mMyStore.GetProperty(sCutbackMethod)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutbackMethod() As IntegerParameter
        Get
            Return CutbackMethodProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            CutbackMethodProperty.SetParameter(Value)
        End Set
    End Property

    Private mCutbackMethodIndex As Integer = -1
    Public Function GetFirstCutbackMethodSelection(ByRef _sel As String) As Boolean
        mCutbackMethodIndex = -1
        Return GetNextCutbackMethodSelection(_sel)
    End Function

    Public Function GetNextCutbackMethodSelection(ByRef _sel As String) As Boolean
        Dim _world As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _crossSection As CrossSections = mUnit.CrossSection
        Dim _soilCrop As SoilCropProperties = mUnit.SoilCropPropertiesRef
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_world, _crossSection, _userLevel)

        mCutbackMethodIndex += 1
        If (mCutbackMethodIndex < CutbackMethods.HighLimit) Then
            _sel = CutbackMethodSelections(mCutbackMethodIndex).Value
            If ((CutbackMethodSelections(mCutbackMethodIndex).Flags And _flags) = 0) Then
                ' Basin/Border Design/Operations only support No Cutback
                If ((_world = WorldTypes.DesignWorld) Or (_world = WorldTypes.OperationsWorld)) Then
                    If ((_crossSection = CrossSections.Basin) Or (_crossSection = CrossSections.Border)) Then
                        If Not (_sel = "No Cutback") Then
                            Return False
                        End If
                    Else ' Furrow
                        If ((_soilCrop.WettedPerimeterMethod.Value = WettedPerimeterMethods.LocalWettedPerimeter) _
                         Or (_soilCrop.WettedPerimeterMethod.Value = WettedPerimeterMethods.NrcsEmpiricalFunction) _
                         Or (_soilCrop.WettedPerimeterMethod.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter)) Then
                            If Not (_sel = "No Cutback") Then
                                Return False
                            End If
                        End If
                    End If
                End If
                ' Selection is valid for World, User Level & Cross Section
                Return True
            Else
                Return False
            End If
        End If
        _sel = Nothing
        Return False
    End Function
    '
    ' Cutback Time
    '
    Public Const sCutbackTime As String = "Cutback Time"
    Public Const sRTcb As String = "RTcb"

    Public ReadOnly Property CutbackTimeRatioProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutbackTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultCutbackTimeRatio, "x Tco")
                _double.MaxValue = 1.0
                mMyStore.AddProperty(sCutbackTime, _double)
                _propertyNode = mMyStore.GetProperty(sCutbackTime)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.GetType Is GetType(DoubleParameter)) Then
                    Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                    _double.TextUnits = "x Tco"
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutbackTimeRatio() As DoubleParameter
        Get
            Return CutbackTimeRatioProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CutbackTimeRatioProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Cutback Location
    '
    Public Const sCutbackLocation As String = "Cutback Location"
    Public Const sRcb As String = "Rcb"

    Public ReadOnly Property CutbackLocationRatioProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutbackLocation)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultCutbackLocationRatio, "x L")
                _double.ValidateValue()
                mMyStore.AddProperty(sCutbackLocation, _double)
                _propertyNode = mMyStore.GetProperty(sCutbackLocation)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.GetType Is GetType(DoubleParameter)) Then
                    Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                    _double.TextUnits = "x L"
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutbackLocationRatio() As DoubleParameter
        Get
            Return CutbackLocationRatioProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CutbackLocationRatioProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Cutback Rate
    '
    Public Const sCutbackRate As String = "Cutback Rate"
    Public Const sRQcb As String = "RQcb"

    Public ReadOnly Property CutbackRateRatioProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutbackRate)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultCutbackRateRatio, "x Q")
                _double.MaxValue = 1.0
                mMyStore.AddProperty(sCutbackRate, _double)
                _propertyNode = mMyStore.GetProperty(sCutbackRate)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.GetType Is GetType(DoubleParameter)) Then
                    Dim _double As DoubleParameter = DirectCast(_param, DoubleParameter)
                    _double.TextUnits = "x Q"
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutbackRateRatio() As DoubleParameter
        Get
            Return CutbackRateRatioProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CutbackRateRatioProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#End Region

#Region " Surge "

#Region " Surge Strategy "
    '
    ' Surge Strategy
    '
    Public Const sSurgeType As String = "Surge Type"
    Public Const sSurgeStrategy As String = "Surge Strategy"

    Public ReadOnly Property SurgeStrategyProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurgeStrategy)

            ' If not found; try deprecated name
            If (_propertyNode Is Nothing) Then
                _propertyNode = mMyStore.GetProperty(sSurgeType)

                ' If deprecated name was found; update it
                If (_propertyNode IsNot Nothing) Then
                    _propertyNode.MyID = sSurgeStrategy
                End If
            End If

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultSurgeStrategy)
                mMyStore.AddProperty(sSurgeStrategy, _integer)
                _propertyNode = mMyStore.GetProperty(sSurgeStrategy)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SurgeStrategy() As IntegerParameter
        Get
            Return SurgeStrategyProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            SurgeStrategyProperty.SetParameter(Value)
        End Set
    End Property

    Private mSurgeStrategyIndex As Integer = -1
    Public Function GetFirstSurgeStrategySelection(ByRef _sel As String) As Boolean
        mSurgeStrategyIndex = -1
        Return GetNextSurgeStrategySelection(_sel)
    End Function

    Public Function GetNextSurgeStrategySelection(ByRef _sel As String) As Boolean
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mSurgeStrategyIndex += 1
        If (mSurgeStrategyIndex < SurgeStrategies.HighLimit) Then
            _sel = SurgeStrategySelections(mSurgeStrategyIndex).Value
            If ((SurgeStrategySelections(mSurgeStrategyIndex).Flags And _flags) = 0) Then
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

#Region " Common Surge Parameters "
    '
    ' Surge Cutoff Time (Tco)
    '
    Public Const sSurgeCutoffTime As String = "Surge Cutoff Time"

    Public ReadOnly Property SurgeCutoffTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurgeCutoffTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultSurgeCutoffTime, Units.Hours)
                mMyStore.AddProperty(sSurgeCutoffTime, sTco, _double)
                _propertyNode = mMyStore.GetProperty(sSurgeCutoffTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SurgeCutoffTime() As DoubleParameter
        Get
            Return SurgeCutoffTimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SurgeCutoffTimeProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Uniform Surge "
    '
    ' Surge Inflow Rate (Qin)
    '
    Public Const sSurgeInflowRate As String = "Surge Inflow Rate"

    Public ReadOnly Property SurgeInflowRateProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurgeInflowRate)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultSurgeInflowRate, Units.Lps)
                mMyStore.AddProperty(sSurgeInflowRate, sQin, _double)
                _propertyNode = mMyStore.GetProperty(sSurgeInflowRate)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SurgeInflowRate() As DoubleParameter
        Get
            Return SurgeInflowRateProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SurgeInflowRateProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Surge On Time
    '
    Public Const sSurgeOnTime As String = "Surge On Time"

    Public ReadOnly Property SurgeOnTimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurgeOnTime)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultSurgeOnTime, Units.Hours)
                mMyStore.AddProperty(sSurgeOnTime, sTco, _double)
                _propertyNode = mMyStore.GetProperty(sSurgeOnTime)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SurgeOnTime() As DoubleParameter
        Get
            Return SurgeOnTimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            SurgeOnTimeProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Number of Surges
    '
    Public Const sNumberOfSurges As String = "Number of Surges"

    Public ReadOnly Property NumberOfSurgesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNumberOfSurges)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultNumberOfSurges)
                mMyStore.AddProperty(sNumberOfSurges, _integer)
                _propertyNode = mMyStore.GetProperty(sNumberOfSurges)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property NumberOfSurges() As IntegerParameter
        Get
            Return NumberOfSurgesProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            NumberOfSurgesProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Tabulated Surge "
    '
    ' Surge Tables
    '
    Public Const sSurgeTimesTable As String = "Surge Times Table"

    Public ReadOnly Property SurgeTimesTableProperty() As PropertyNode
        Get
            ' Define default Surge Times table
            Dim _surgeTable As DataTable = New DataTable(sSurgeTimesTable)
            ResetSurgeTimesTable(_surgeTable)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurgeTimesTable, _surgeTable)
            Return _propertyNode
        End Get
    End Property

    Public Property SurgeTimesTable() As DataTableParameter
        Get
            Dim _table As DataTableParameter = SurgeTimesTableProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            SurgeTimesTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetSurgeTimesTable(ByVal surgeTimesDataTable As DataTable)

        ' Remove the previous data
        surgeTimesDataTable.Clear()          ' Clear rows
        surgeTimesDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        surgeTimesDataTable.Columns.Add(sStartTimeX, GetType(Double))
        surgeTimesDataTable.Columns.Add(sEndTimeX, GetType(Double))

        ' Add the row(s) of reset data
        Dim startTime As Double = 0.0
        Dim endTime As Double = DefaultSurgeOnTime

        For sdx As Integer = 1 To DefaultNumberOfSurges
            Dim surgeTimeRow As DataRow = surgeTimesDataTable.NewRow
            surgeTimeRow.Item(sStartTimeX) = startTime
            surgeTimeRow.Item(sEndTimeX) = endTime

            surgeTimesDataTable.Rows.Add(surgeTimeRow)

            startTime = endTime + DefaultSurgeOnTime
            endTime = startTime + DefaultSurgeOnTime
        Next

    End Sub

    Public Const sSurgeLocationsTable As String = "Surge Locations Table"

    Public ReadOnly Property SurgeLocationsTableProperty() As PropertyNode
        Get
            ' Define default Surge Locations table
            Dim _surgeTable As DataTable = New DataTable(sSurgeLocationsTable)
            ResetSurgeLocationsTable(_surgeTable)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurgeLocationsTable, _surgeTable)
            Return _propertyNode
        End Get
    End Property

    Public Property SurgeLocationsTable() As DataTableParameter
        Get
            Dim _table As DataTableParameter = SurgeLocationsTableProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            SurgeLocationsTableProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetSurgeLocationsTable(ByVal surgeLocationsDataTable As DataTable)

        ' Remove the previous data
        surgeLocationsDataTable.Clear()          ' Clear rows
        surgeLocationsDataTable.Columns.Clear()  ' Clear columns

        ' Add the columns
        surgeLocationsDataTable.Columns.Add(sLocationX, GetType(Double))

        ' Add the row(s) of reset data
        For sdx As Integer = 1 To DefaultNumberOfSurges
            Dim surgeLocationRow As DataRow = surgeLocationsDataTable.NewRow
            surgeLocationRow.Item(sLocationX) = sdx / DefaultNumberOfSurges

            surgeLocationsDataTable.Rows.Add(surgeLocationRow)
        Next

    End Sub

#End Region

#End Region

#Region " Cablegation "
    '
    ' Orifice description option
    '
    Public Const sOrificeOption As String = "Orifice Option"

    Public ReadOnly Property OrificeOptionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sOrificeOption)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(DefaultOrificeOption)
                mMyStore.AddProperty(sOrificeOption, _integer)
                _propertyNode = mMyStore.GetProperty(sOrificeOption)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property OrificeOption() As IntegerParameter
        Get
            Return OrificeOptionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            OrificeOptionProperty.SetParameter(Value)
        End Set
    End Property

    Private mOrificeOptionIndex As Integer = -1
    Public Function GetFirstOrificeOptionSelection() As String
        mOrificeOptionIndex = -1
        Return GetNextOrificeOptionSelection()
    End Function

    Public Function GetNextOrificeOptionSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mOrificeOptionIndex += 1
        If (mOrificeOptionIndex < OrificeOptions.HighLimit) Then
            If ((OrificeOptionSelections(mOrificeOptionIndex).Flags And _flags) = 0) Then
                Return OrificeOptionSelections(mOrificeOptionIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function
    '
    ' Cablegation Numeric Parameters
    '
    Public Const sTotalInflow As String = "Total Inflow"

    Public ReadOnly Property TotalInflowProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTotalInflow)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultTotalInflow, Units.Lps)
                mMyStore.AddProperty(sTotalInflow, sQin, _double)
                _propertyNode = mMyStore.GetProperty(sTotalInflow)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property TotalInflow() As DoubleParameter
        Get
            Return TotalInflowProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            TotalInflowProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPeakOrificeFlow As String = "Peak Orifice Flow"

    Public ReadOnly Property PeakOrificeFlowProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPeakOrificeFlow)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultCablegationPeakOrificeFlow, Units.Lps)
                mMyStore.AddProperty(sPeakOrificeFlow, sQin, _double)
                _propertyNode = mMyStore.GetProperty(sPeakOrificeFlow)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property PeakOrificeFlow() As DoubleParameter
        Get
            Return PeakOrificeFlowProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            PeakOrificeFlowProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sCutoffFlow As String = "Cutoff Flow"

    Public ReadOnly Property CutoffFlowProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sCutoffFlow)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultCutoffFlow, Units.Lps)
                mMyStore.AddProperty(sCutoffFlow, sQin, _double)
                _propertyNode = mMyStore.GetProperty(sCutoffFlow)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property CutoffFlow() As DoubleParameter
        Get
            Return CutoffFlowProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            CutoffFlowProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPipeSlope As String = "Pipe Slope"

    Public ReadOnly Property PipeSlopeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPipeSlope)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultPipeSlope, Units.MetersPerMeter)
                mMyStore.AddProperty(sPipeSlope, "", _double)
                _propertyNode = mMyStore.GetProperty(sPipeSlope)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property PipeSlope() As DoubleParameter
        Get
            Return PipeSlopeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            PipeSlopeProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPipeDiameter As String = "Pipe Diameter"

    Public ReadOnly Property PipeDiameterProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPipeDiameter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultPipeDiameter, Units.Millimeters)
                mMyStore.AddProperty(sPipeDiameter, "", _double)
                _propertyNode = mMyStore.GetProperty(sPipeDiameter)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property PipeDiameter() As DoubleParameter
        Get
            Return PipeDiameterProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            PipeDiameterProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sOrificeDiameter As String = "Orifice Diameter"

    Public ReadOnly Property OrificeDiameterProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sOrificeDiameter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultOrificeDiameter, Units.Millimeters)
                mMyStore.AddProperty(sOrificeDiameter, "", _double)
                _propertyNode = mMyStore.GetProperty(sOrificeDiameter)
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.DepthUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property OrificeDiameter() As DoubleParameter
        Get
            Return OrificeDiameterProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            OrificeDiameterProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sOrificeSpacing As String = "Orifice Spacing"

    Public ReadOnly Property OrificeSpacingProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sOrificeSpacing)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultOrificeSpacing, Units.Meters)
                mMyStore.AddProperty(sOrificeSpacing, "", _double)
                _propertyNode = mMyStore.GetProperty(sOrificeSpacing)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property OrificeSpacing() As DoubleParameter
        Get
            Return OrificeSpacingProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            OrificeSpacingProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPlugSpeed As String = "Plug Speed"

    Public ReadOnly Property PlugSpeedProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPlugSpeed)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultPlugSpeed, Units.MetersPerSecond)
                mMyStore.AddProperty(sPlugSpeed, "", _double)
                _propertyNode = mMyStore.GetProperty(sPlugSpeed)

            Else ' Verify default exists if previous parameter was the deleted PlugSpeedParameter
                Dim _double As DoubleParameter = _propertyNode.GetDoubleParameter
                If (_double Is Nothing) Then
                    _double = New DoubleParameter(DefaultPlugSpeed, Units.MetersPerSecond)
                    _propertyNode.EventsEnabled = False
                    _propertyNode.SetParameter(_double)
                    _propertyNode.EventsEnabled = True
                End If
            End If

            _propertyNode.AltUnitSet = New UnitsSystem.MetersFeetPerHourUnitSet
            Return _propertyNode
        End Get
    End Property

    Public Property PlugSpeed() As DoubleParameter
        Get
            Dim _double As DoubleParameter = PlugSpeedProperty.GetDoubleParameter
            If (_double Is Nothing) Then ' Verify default exists if previous parameter was the deleted PlugSpeedParameter
                _double = New DoubleParameter(DefaultPlugSpeed, Units.MetersPerSecond)
            End If
            Return _double
        End Get
        Set(ByVal Value As DoubleParameter)
            PlugSpeedProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sHazenWilliamsPipeCoefficient As String = "Hazen-Williams Pipe Coefficient"

    Public ReadOnly Property HazenWilliamsPipeCoefficientProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sHazenWilliamsPipeCoefficient)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _double As DoubleParameter = New DoubleParameter(DefaultHazenWilliamsPipeCoefficient, Units.None)
                mMyStore.AddProperty(sHazenWilliamsPipeCoefficient, "", _double)
                _propertyNode = mMyStore.GetProperty(sHazenWilliamsPipeCoefficient)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property HazenWilliamsPipeCoefficient() As DoubleParameter
        Get
            Return HazenWilliamsPipeCoefficientProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            HazenWilliamsPipeCoefficientProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Tabulated Inflow "

    '*********************************************************************************************************
    ' One method of inputting Inflow is via a hydrograph of time (T) vs. inflow (Qin) values
    '
    ' This region contains methods to store & access this table and its attributes
    '*********************************************************************************************************
    Public Const sTabulatedInflow As String = "Tabulated Inflow"

    Public ReadOnly Property TabulatedInflowProperty() As PropertyNode
        Get
            ' Define default Tabulated Inflow table & parameter
            Dim tabulatedInflow As DataTable = New DataTable(sTabulatedInflow)
            ResetTabulatedInflow(tabulatedInflow, CutoffTime.Value, InflowRate.Value)
            ' Get property with at least a reset table
            Dim propNode As PropertyNode = mMyStore.GetProperty(sTabulatedInflow, tabulatedInflow)
            Return propNode
        End Get
    End Property

    Public Property TabulatedInflow() As DataTableParameter
        Get
            Dim tableParam As DataTableParameter = TabulatedInflowProperty.GetDataTableParameter()
            Return tableParam
        End Get
        Set(ByVal Value As DataTableParameter)
            TabulatedInflowProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetTabulatedInflow(ByVal TabulatedInflow As DataTable, _
                                    ByVal Tco As Double, ByVal Qin As Double)

        TabulatedInflow.Rows.Clear()                            ' Clear previous data
        TabulatedInflow.Columns.Clear()

        TabulatedInflow.Columns.Add(sTimeX, GetType(Double))    ' Add columns
        TabulatedInflow.Columns.Add(sInflowX, GetType(Double))

        Dim QinRow As DataRow                                   ' Add rows

        QinRow = TabulatedInflow.NewRow     ' Time = 0.0
        QinRow.Item(nTimeX) = 0.0
        QinRow.Item(nInflowX) = Qin
        TabulatedInflow.Rows.Add(QinRow)

        QinRow = TabulatedInflow.NewRow     ' Time = Tco
        QinRow.Item(nTimeX) = Tco
        QinRow.Item(nInflowX) = Qin
        TabulatedInflow.Rows.Add(QinRow)

    End Sub

    '*********************************************************************************************************
    ' Inflow Table Incomplete attribute (i.e. a partial hydrograph)
    '*********************************************************************************************************
    Public Const sInflowTableIncomplete As String = "Inflow Table Incomplete"

    Public ReadOnly Property TabulatedInflowIncompleteProperty() As PropertyNode
        Get
            Dim propNode As PropertyNode = mMyStore.GetProperty(sInflowTableIncomplete)

            ' If it was not found; create it
            If (propNode Is Nothing) Then
                Dim boolParam As BooleanParameter = New BooleanParameter(False)
                mMyStore.AddProperty(sInflowTableIncomplete, boolParam)
                propNode = mMyStore.GetProperty(sInflowTableIncomplete)
            End If

            Return propNode
        End Get
    End Property

    Public Property TabulatedInflowIncomplete() As BooleanParameter
        Get
            Dim boolParam As BooleanParameter = TabulatedInflowIncompleteProperty.GetBooleanParameter()
            Return boolParam
        End Get
        Set(ByVal Value As BooleanParameter)
            TabulatedInflowIncompleteProperty.SetParameter(Value)
        End Set
    End Property

    '*********************************************************************************************************
    ' Function TabulatedInflowHasData() -  Check if Tabulated Inflow has data
    '*********************************************************************************************************
    Public Function TabulatedInflowHasData() As Boolean
        TabulatedInflowHasData = False

        Dim tableParam As DataTableParameter = TabulatedInflowProperty.GetDataTableParameter()
        If (tableParam IsNot Nothing) Then ' DataTableParameter exists
            Dim QinTable As DataTable = tableParam.Value
            If (QinTable IsNot Nothing) Then ' DataTable exists
                If (QinTable.Rows IsNot Nothing) Then ' It has Rows
                    If (0 < QinTable.Rows.Count) Then ' It has at least 1 Row
                        TabulatedInflowHasData = True
                    End If
                End If
            End If
        End If

    End Function

#End Region

#Region " Inflow Measured "

    Public Const sInflowMeasured As String = "Inflow Measured"

    Public ReadOnly Property InflowMeasuredProperty() As PropertyNode
        Get
            Dim _inflowMeasured As BooleanParameter = Nothing

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sInflowMeasured)
            If (_propertyNode Is Nothing) Then
                ' Property does not exist; add it
                _inflowMeasured = New BooleanParameter
                ResetInflowMeasured(_inflowMeasured)
                mMyStore.AddProperty(sInflowMeasured, _inflowMeasured)
                _propertyNode = mMyStore.GetProperty(sInflowMeasured)
            Else
                ' Property exists; check if value is default
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.Source = ValueSources.Defaulted) Then
                    ' Value is default; update it
                    _inflowMeasured = DirectCast(_param, BooleanParameter)
                    ResetInflowMeasured(_inflowMeasured)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property InflowMeasured() As BooleanParameter
        Get
            Dim _inflowMeasured As BooleanParameter = InflowMeasuredProperty.GetBooleanParameter()
            Return _inflowMeasured
        End Get
        Set(ByVal value As BooleanParameter)
            InflowMeasuredProperty.SetParameter(value)
        End Set
    End Property

    Public Sub ResetInflowMeasured(ByVal _inflowMeasured As BooleanParameter)
        Debug.Assert(_inflowMeasured.Source = ValueSources.Defaulted)
        _inflowMeasured.Value = InflowDataAvailable()
    End Sub
    '
    ' Check if Inflow data is available; it always is
    '
    Public Function InflowDataAvailable() As Boolean
        InflowDataAvailable = True
    End Function

#End Region

#End Region

#Region " Runoff "

#Region " Tabulated Runoff "

    Public Const sTabulatedRunoff As String = "Tabulated Runoff"

    Public ReadOnly Property TabulatedRunoffProperty() As PropertyNode
        Get
            ' Define default Tabulated Runoff table
            Dim _tabulatedRunoff As DataTable = New DataTable(sTabulatedRunoff)
            ResetTabulatedRunoff(_tabulatedRunoff)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTabulatedRunoff, _tabulatedRunoff)
            Return _propertyNode
        End Get
    End Property

    Public Property TabulatedRunoff() As DataTableParameter
        Get
            ' Define default Tabulated Runoff table
            Dim _tabulatedRunoff As DataTable = New DataTable(sTabulatedRunoff)
            ResetTabulatedRunoff(_tabulatedRunoff)
            Dim _tableParameter As DataTableParameter = New DataTableParameter(_tabulatedRunoff)

            ' Downstream end must be Open for there to be Runoff
            If (mUnit.SystemGeometryRef.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
                If (Me.RunoffMeasured.Value) Then ' Runoff has been measured; return table
                    _tableParameter = TabulatedRunoffProperty.GetDataTableParameter()
                End If
            End If

            Return _tableParameter
        End Get
        Set(ByVal Value As DataTableParameter)
            TabulatedRunoffProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Reset Runoff Table to empty
    '
    Public Sub ResetTabulatedRunoff(ByVal TabulatedRunoff As DataTable)

        TabulatedRunoff.Columns.Clear()                        ' Remove previous data
        TabulatedRunoff.Rows.Clear()

        TabulatedRunoff.Columns.Add(sTimeX, GetType(Double))   ' Add columns but no rows
        TabulatedRunoff.Columns.Add(sRunoffX, GetType(Double))

    End Sub
    '
    ' Tabulated Runoff is incomplete (i.e. Partial)
    '
    Public Const sRunoffTableIncomplete As String = "Runoff Table Incomplete"

    Public ReadOnly Property TabulatedRunoffIncompleteProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRunoffTableIncomplete)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _boolean As BooleanParameter = New BooleanParameter(False)
                mMyStore.AddProperty(sRunoffTableIncomplete, _boolean)
                _propertyNode = mMyStore.GetProperty(sRunoffTableIncomplete)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property TabulatedRunoffIncomplete() As BooleanParameter
        Get
            Return TabulatedRunoffIncompleteProperty.GetBooleanParameter()
        End Get
        Set(ByVal Value As BooleanParameter)
            TabulatedRunoffIncompleteProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Check if Tabulated Runoff has data (Open-End with data entered)
    '
    Public Function TabulatedRunoffHasData() As Boolean
        TabulatedRunoffHasData = False

        If (mUnit.SystemGeometryRef.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            ' Open-end fields may have runoff data
            Dim _runoffParam As DataTableParameter = TabulatedRunoffProperty.GetDataTableParameter()
            If (_runoffParam IsNot Nothing) Then
                Dim _runoffTable As DataTable = _runoffParam.Value
                If (_runoffTable IsNot Nothing) Then
                    If (_runoffTable.Rows IsNot Nothing) Then
                        If (0 < _runoffTable.Rows.Count) Then
                            TabulatedRunoffHasData = True
                        End If
                    End If
                End If
            End If
        End If

    End Function

#End Region

#Region " Runoff Measured / Used "
    '
    ' Runoff has been measured during an irrigation
    '
    Public Const sRunoffMeasured As String = "Runoff Measured"

    Public ReadOnly Property RunoffMeasuredProperty() As PropertyNode
        Get
            Dim _runoffMeasured As BooleanParameter = Nothing

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRunoffMeasured)
            If (_propertyNode Is Nothing) Then
                ' Property does not exist; add it
                _runoffMeasured = New BooleanParameter
                ResetRunoffMeasured(_runoffMeasured)
                mMyStore.AddProperty(sRunoffMeasured, _runoffMeasured)
                _propertyNode = mMyStore.GetProperty(sRunoffMeasured)
            Else
                ' Property exists; check if value is default
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.Source = ValueSources.Defaulted) Then
                    ' Value is default; update it
                    _runoffMeasured = DirectCast(_param, BooleanParameter)
                    ResetRunoffMeasured(_runoffMeasured)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property RunoffMeasured() As BooleanParameter
        Get
            Dim _runoffMeasured As BooleanParameter = RunoffMeasuredProperty.GetBooleanParameter()
            Return _runoffMeasured
        End Get
        Set(ByVal value As BooleanParameter)
            RunoffMeasuredProperty.SetParameter(value)
        End Set
    End Property
    '
    ' "Measured" defaults to whether or not Tabulated Runoff data has been entered
    '
    Private Sub ResetRunoffMeasured(ByVal _runoffMeasured As BooleanParameter)
        Debug.Assert(_runoffMeasured.Source = ValueSources.Defaulted)
        _runoffMeasured.Value = TabulatedRunoffHasData()
    End Sub
    '
    ' Runoff data is available if user indicated it was measured and user entered it
    '
    Public Function RunoffDataAvailable() As Boolean
        RunoffDataAvailable = False
        If (RunoffMeasured.Value) Then ' user said runoff data was entered; was it?
            RunoffDataAvailable = TabulatedRunoffHasData()
        End If
    End Function

    '*********************************************************************************************************
    ' Runoff data is to be used for Volume Balance calculations
    '*********************************************************************************************************
    Public Const sRunoffUsed As String = "Runoff Used"

    Public ReadOnly Property RunoffUsedProperty() As PropertyNode
        Get
            Dim _runoffUsed As BooleanParameter = Nothing

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRunoffUsed)
            If (_propertyNode Is Nothing) Then
                ' Property does not exist; add it
                _runoffUsed = New BooleanParameter
                ResetRunoffUsed(_runoffUsed)
                mMyStore.AddProperty(sRunoffUsed, _runoffUsed)
                _propertyNode = mMyStore.GetProperty(sRunoffUsed)
            Else
                ' Property exists; check if value is default
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.Source = ValueSources.Defaulted) Then
                    ' Value is default; update it
                    _runoffUsed = DirectCast(_param, BooleanParameter)
                    ResetRunoffUsed(_runoffUsed)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property RunoffUsed() As BooleanParameter
        Get
            Dim _runoffUsed As BooleanParameter = RunoffUsedProperty.GetBooleanParameter()
            Return _runoffUsed
        End Get
        Set(ByVal value As BooleanParameter)
            RunoffUsedProperty.SetParameter(value)
        End Set
    End Property

    Public Sub ResetRunoffUsed(ByVal _runoffUsed As BooleanParameter)
        _runoffUsed.Value = False
        Debug.Assert(_runoffUsed.Source = ValueSources.Defaulted)
    End Sub

#End Region

#End Region

#Region " Advance "

#Region " Tabulated Advance "
    '
    ' Advance Table
    '
    Public ReadOnly Property TabulatedAdvanceProperty() As PropertyNode
        Get
            ' Define default Advance table
            Dim _advance As DataTable = New DataTable(sAdvance)
            ResetAdvance(_advance)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvance, _advance)
            Return _propertyNode
        End Get
    End Property

    Public Property TabulatedAdvance() As DataTableParameter
        Get
            Dim _table As DataTableParameter = TabulatedAdvanceProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            TabulatedAdvanceProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetAdvance(ByVal AdvanceTable As DataTable)

        ' Remove the previous data
        AdvanceTable.Columns.Clear()
        AdvanceTable.Rows.Clear()

        ' Add the columns
        AdvanceTable.Columns.Add(sDistanceX, GetType(Double))
        AdvanceTable.Columns.Add(sTimeX, GetType(Double))

        ' If Two-Point data exists, use it; else advance table is empty
        If ((Point1Distance.Source = ValueSources.UserEntered) _
         Or (Point1Time.Source = ValueSources.UserEntered) _
         Or (Point2Distance.Source = ValueSources.UserEntered) _
         Or (Point2Time.Source = ValueSources.UserEntered)) Then

            Dim dist1 As Double = Point1Distance.Value          ' Get 2-Pt values
            Dim time1 As Double = Point1Time.Value
            Dim dist2 As Double = Point2Distance.Value
            Dim time2 As Double = Point2Time.Value

            ' Add the rows
            Dim twoPointRow As DataRow = AdvanceTable.NewRow
            twoPointRow.Item(sDistanceX) = 0.0
            twoPointRow.Item(sTimeX) = 0.0
            AdvanceTable.Rows.Add(twoPointRow)

            twoPointRow = AdvanceTable.NewRow
            twoPointRow.Item(sDistanceX) = dist1
            twoPointRow.Item(sTimeX) = time1
            AdvanceTable.Rows.Add(twoPointRow)

            twoPointRow = AdvanceTable.NewRow
            twoPointRow.Item(sDistanceX) = dist2
            twoPointRow.Item(sTimeX) = time2
            AdvanceTable.Rows.Add(twoPointRow)
        End If

    End Sub
    '
    ' Check if Tabulated Advance has data (data entered)
    '
    Public Function TabulatedAdvanceHasData() As Boolean
        TabulatedAdvanceHasData = False

        Dim _advanceParam As DataTableParameter = TabulatedAdvanceProperty.GetDataTableParameter()
        If (_advanceParam IsNot Nothing) Then
            Dim _advanceTable As DataTable = _advanceParam.Value
            If (_advanceTable IsNot Nothing) Then
                If (_advanceTable.Rows IsNot Nothing) Then
                    If (0 < _advanceTable.Rows.Count) Then
                        TabulatedAdvanceHasData = True
                    End If
                End If
            End If
        End If

    End Function
    '
    ' Advance Power-Law Parameters
    '
    Public Const sAdvanceP As String = "Advance p"
    Public Const sp As String = "p"

    Public ReadOnly Property AdvancePProperty() As PropertyNode
        Get
            Dim p, r As Double
            Dim Rparam As DoubleParameter = AdvanceR

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvanceP)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then

                Dim TL As Double = MaxAdvanceTime()
                Dim XL As Double = MaxAdvanceDistance()
                r = Rparam.Value
                p = XL / TL ^ r

                Dim _powerAdvP As PowerAdvancePParameter = New PowerAdvancePParameter(p, _
                                  PowerAdvancePParameter.P_Units.MetersPerSecond_R, AdvanceRProperty)

                mMyStore.AddProperty(sAdvanceP, sp, _powerAdvP)
                _propertyNode = mMyStore.GetProperty(sAdvanceP)

            Else ' Property was found; validate/update it, as needed

                If Not (Rparam.Source = ValueSources.UserEntered) Then ' r not user-entered (i.e. calculated)

                    Dim Pparam As Parameter = _propertyNode.GetParameter
                    If (Pparam IsNot Nothing) Then
                        If Not (Pparam.Source = ValueSources.UserEntered) Then ' p is also not user-entered

                            ' Both p&r are calculated; make sure they are up-to-date
                            Dim prOK As Boolean

                            If (UsePowerAdvanceLaw) Then ' use direct Power Advance Law function
                                prOK = PowerAdvancePandR(p, r)
                            Else ' use AMOEBA fit
                                prOK = AmoebaAdvancePandR(p, r)
                            End If

                            If (prOK) Then
                                Dim _powerAdvP As PowerAdvancePParameter = DirectCast(Pparam, PowerAdvancePParameter)
                                _powerAdvP.Value(r) = p
                                _powerAdvP.Source = ValueSources.Calculated
                            End If
                        End If
                    Else
                        Dim TL As Double = MaxAdvanceTime()
                        Dim XL As Double = MaxAdvanceDistance()
                        r = Rparam.Value
                        p = XL / TL ^ r

                        Dim _powerAdvP As PowerAdvancePParameter = New PowerAdvancePParameter(p,
                                  PowerAdvancePParameter.P_Units.MetersPerSecond_R, AdvanceRProperty)

                        mMyStore.AddProperty(sAdvanceP, sp, _powerAdvP)
                        _propertyNode = mMyStore.GetProperty(sAdvanceP)
                    End If

                End If

            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AdvanceP() As PowerAdvancePParameter
        Get
            ' Get the current Parameter
            Dim _parameter As Parameter = AdvancePProperty.GetParameter()

            ' Validate & return a copy of the PowerAdvancePParameter
            If (_parameter.GetType Is GetType(PowerAdvancePParameter)) Then
                Dim _powerAdvP As PowerAdvancePParameter = DirectCast(_parameter, PowerAdvancePParameter)

                Dim _copy As PowerAdvancePParameter = New PowerAdvancePParameter(_powerAdvP)
                Return _copy
            End If

            Return AdvancePProperty.GetParameter()
        End Get
        Set(ByVal Value As PowerAdvancePParameter)
            AdvancePProperty.SetParameter(Value)
        End Set
    End Property


    Public Const sAdvanceR As String = "Advance R"

    Public ReadOnly Property AdvanceRProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvanceR)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then

                Dim _powerAdvR As DoubleParameter = New DoubleParameter(0.75)
                _powerAdvR.MinValue = 0.0
                _powerAdvR.MaxValue = 1.0

                mMyStore.AddProperty(sAdvanceR, _powerAdvR)
                _propertyNode = mMyStore.GetProperty(sAdvanceR)

            Else ' Property was found; validate/update it, as needed

                Dim Rparam As Parameter = _propertyNode.GetParameter

                If Not (Rparam.Source = ValueSources.UserEntered) Then ' r not user-entered (i.e. calculated)

                    ' r is calculated; make sure they are up-to-date
                    Dim p, r As Double
                    Dim prOK As Boolean

                    If (UsePowerAdvanceLaw) Then ' use direct Power Advance Law function
                        prOK = PowerAdvancePandR(p, r)
                    Else ' use AMOEBA fit
                        prOK = AmoebaAdvancePandR(p, r)
                    End If

                    If (prOK) Then
                        Dim _powerAdvR As DoubleParameter = DirectCast(Rparam, DoubleParameter)
                        _powerAdvR.Value = r
                        _powerAdvR.MinValue = 0.0
                        _powerAdvR.MaxValue = 1.0
                        _powerAdvR.Source = ValueSources.Calculated
                    End If
                End If

            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AdvanceR() As DoubleParameter
        Get
            Return AdvanceRProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            AdvanceRProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Advance Measured / Used "
    '
    ' Advance has been measured for an irrigation
    '
    Public Const sAdvanceMeasured As String = "Advance Measured"

    Public ReadOnly Property AdvanceMeasuredProperty() As PropertyNode
        Get
            Dim _advanceMeasured As BooleanParameter = Nothing

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvanceMeasured)
            If (_propertyNode Is Nothing) Then
                ' Property does not exist; add it
                _advanceMeasured = New BooleanParameter(True)
                mMyStore.AddProperty(sAdvanceMeasured, _advanceMeasured)
                _propertyNode = mMyStore.GetProperty(sAdvanceMeasured)
            Else
                ' Property exists; check if value is default
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.Source = ValueSources.Defaulted) Then
                    ' Value is default; update it
                    _advanceMeasured = DirectCast(_param, BooleanParameter)
                    _advanceMeasured.Value = True
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AdvanceMeasured() As BooleanParameter
        Get
            Dim _advanceMeasured As BooleanParameter = AdvanceMeasuredProperty.GetBooleanParameter()
            Return _advanceMeasured
        End Get
        Set(ByVal value As BooleanParameter)
            AdvanceMeasuredProperty.SetParameter(value)
        End Set
    End Property
    '
    ' Check if Advance data is available
    '
    Public Function AdvanceDataAvailable() As Boolean
        AdvanceDataAvailable = False

        Dim tableParam As DataTableParameter = Nothing

        If (mUnit.EventCriteriaRef IsNot Nothing) Then
            Select Case (mUnit.EventCriteriaRef.EventAnalysisType.Value)
                Case EventAnalysisTypes.TwoPointAnalysis
                    tableParam = TwoPointTabulatedAdvance
                Case Else ' MerriamKellerAnalysis, EvalueAnalysis
                    If (AdvanceMeasured.Value) Then ' user said Advance data was entered
                        tableParam = TabulatedAdvance
                    End If
            End Select
        End If

        ' Check for data in the advance DataTable
        If (tableParam IsNot Nothing) Then
            Dim table As DataTable = tableParam.Value
            If (table IsNot Nothing) Then
                If (table.Rows IsNot Nothing) Then
                    If (0 < table.Rows.Count) Then
                        AdvanceDataAvailable = True
                    End If
                End If
            End If
        End If

    End Function

#End Region

#Region " Two-Point Advance "
    '
    ' Point 1 - Distance / Time
    '
    Public Const sPt1Dist As String = "Pt 1 Dist"

    Public ReadOnly Property Point1DistanceProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPt1Dist)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _length As Double = mUnit.SystemGeometryRef.Length.Value
                Dim _double As DoubleParameter = New DoubleParameter(_length / 2.0, Units.Meters)
                _double.Source = ValueSources.Defaulted
                mMyStore.AddProperty(sPt1Dist, _double)
                _propertyNode = mMyStore.GetProperty(sPt1Dist)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Point1Distance() As DoubleParameter
        Get
            Return Point1DistanceProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Point1DistanceProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPt1Time As String = "Pt 1 Time"

    Public ReadOnly Property Point1TimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPt1Time)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _cutoffTime As Double = Me.CutoffTime.Value
                Dim _double As DoubleParameter = New DoubleParameter(_cutoffTime / 4.0, Units.Seconds)
                _double.Source = ValueSources.Defaulted
                mMyStore.AddProperty(sPt1Time, _double)
                _propertyNode = mMyStore.GetProperty(sPt1Time)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Point1Time() As DoubleParameter
        Get
            Return Point1TimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Point1TimeProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Point 2 - Distance / Time
    '
    Public Const sPt2Dist As String = "Pt 2 Dist"

    Public ReadOnly Property Point2DistanceProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPt2Dist)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _length As Double = mUnit.SystemGeometryRef.Length.Value
                Dim _double As DoubleParameter = New DoubleParameter(_length, Units.Meters)
                _double.Source = ValueSources.Defaulted
                mMyStore.AddProperty(sPt2Dist, _double)
                _propertyNode = mMyStore.GetProperty(sPt2Dist)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Point2Distance() As DoubleParameter
        Get
            Return Point2DistanceProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Point2DistanceProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sPt2Time As String = "Pt 2 Time"

    Public ReadOnly Property Point2TimeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPt2Time)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _cutoffTime As Double = Me.CutoffTime.Value
                Dim _double As DoubleParameter = New DoubleParameter(_cutoffTime, Units.Seconds)
                _double.Source = ValueSources.Defaulted
                mMyStore.AddProperty(sPt2Time, _double)
                _propertyNode = mMyStore.GetProperty(sPt2Time)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Point2Time() As DoubleParameter
        Get
            Return Point2TimeProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            Point2TimeProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' 2-Pt Advance Table
    '
    Public Const sTwoPointAdvance As String = "2-pt Advance"

    Public ReadOnly Property TwoPointTabulatedAdvanceProperty() As PropertyNode
        Get
            ' Define reset Two-Point Advance table
            Dim _advance As DataTable = New DataTable("Two-Point Advance")
            ResetTwoPointAdvanceTable(_advance)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sTwoPointAdvance, _advance)
            Return _propertyNode
        End Get
    End Property

    Public Property TwoPointTabulatedAdvance() As DataTableParameter
        Get
            Dim _table As DataTableParameter = TwoPointTabulatedAdvanceProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            TwoPointTabulatedAdvanceProperty.SetParameter(Value)
        End Set
    End Property

    Private Sub ResetTwoPointAdvanceTable(ByVal TwoPointAdvanceTable As DataTable)

        TwoPointAdvanceTable.Columns.Clear()                ' Remove previous data
        TwoPointAdvanceTable.Rows.Clear()

        ' Add the columns
        TwoPointAdvanceTable.Columns.Add(sDistanceX, GetType(Double))
        TwoPointAdvanceTable.Columns.Add(sTimeX, GetType(Double))

        ' Get values for reset table
        Dim dist1 As Double = Point1Distance.Value          ' Start with scaler 2-Pt values
        Dim time1 As Double = Point1Time.Value
        Dim dist2 As Double = Point2Distance.Value
        Dim time2 As Double = Point2Time.Value

        Dim twoPointUserEntered As Boolean = False
        If ((Point1Distance.Source = ValueSources.UserEntered) _
         Or (Point1Time.Source = ValueSources.UserEntered) _
         Or (Point2Distance.Source = ValueSources.UserEntered) _
         Or (Point2Time.Source = ValueSources.UserEntered)) Then
            twoPointUserEntered = True
        End If

        ' If 2-Pt values have not been entered, check Tabulated Advance table
        If Not (twoPointUserEntered) Then
            If (TabulatedAdvance.Source = ValueSources.UserEntered) Then
                Dim _advance As DataTable = TabulatedAdvance.Value
                Dim _ptCount As Integer = _advance.Rows.Count
                If (1 < _ptCount) Then ' at least two points
                    Dim lastRow As DataRow = _advance.Rows(_ptCount - 1)
                    dist2 = lastRow.Item(nDistanceX)
                    time2 = lastRow.Item(nTimeX1)
                    dist1 = dist2 / 2.0
                    time1 = DataColumnValue(_advance, nDistanceX, dist1, nTimeX1)
                End If
            End If
        End If

        ' Add the rows
        Dim twoPointRow As DataRow = TwoPointAdvanceTable.NewRow
        twoPointRow.Item(sDistanceX) = 0.0
        twoPointRow.Item(sTimeX) = 0.0
        TwoPointAdvanceTable.Rows.Add(twoPointRow)

        twoPointRow = TwoPointAdvanceTable.NewRow
        twoPointRow.Item(sDistanceX) = dist1
        twoPointRow.Item(sTimeX) = time1
        TwoPointAdvanceTable.Rows.Add(twoPointRow)

        twoPointRow = TwoPointAdvanceTable.NewRow
        twoPointRow.Item(sDistanceX) = dist2
        twoPointRow.Item(sTimeX) = time2
        TwoPointAdvanceTable.Rows.Add(twoPointRow)
    End Sub

#End Region

#End Region

#Region " Recession "

#Region " Tabulated Recession "

    Public ReadOnly Property TabulatedRecessionProperty() As PropertyNode
        Get
            ' Define default Tabulated Recession table
            Dim _recession As DataTable = New DataTable(sRecession)
            ResetRecession(_recession)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRecession, _recession)
            Return _propertyNode
        End Get
    End Property

    Public Property TabulatedRecession() As DataTableParameter
        Get
            Dim _table As DataTableParameter = TabulatedRecessionProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal Value As DataTableParameter)
            TabulatedRecessionProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetRecession(ByVal _recession As DataTable)

        ' Remove the previous data
        _recession.Columns.Clear()
        _recession.Rows.Clear()

        ' Add the columns
        _recession.Columns.Add(sDistanceX, GetType(Double))
        _recession.Columns.Add(sTimeX, GetType(Double))

        ' Reset recession table is empty

    End Sub
    '
    ' Check if Tabulated Recession has data (data entered)
    '
    Public Function TabulatedRecessionHasData() As Boolean
        TabulatedRecessionHasData = False

        Dim _advanceParam As DataTableParameter = TabulatedRecessionProperty.GetDataTableParameter()
        If (_advanceParam IsNot Nothing) Then
            Dim _advanceTable As DataTable = _advanceParam.Value
            If (_advanceTable IsNot Nothing) Then
                If (_advanceTable.Rows IsNot Nothing) Then
                    If (0 < _advanceTable.Rows.Count) Then
                        TabulatedRecessionHasData = True
                    End If
                End If
            End If
        End If

    End Function

#End Region

#Region " Recession Measured / Used "
    '
    ' Recession has been measured for an irrigation
    '
    Public Const sRecessionMeasured As String = "Recession Measured"

    Public ReadOnly Property RecessionMeasuredProperty() As PropertyNode
        Get
            Dim _recessionMeasured As BooleanParameter = Nothing

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRecessionMeasured)
            If (_propertyNode Is Nothing) Then
                ' Property does not exist; add it
                _recessionMeasured = New BooleanParameter
                ResetRecessionMeasured(_recessionMeasured)
                mMyStore.AddProperty(sRecessionMeasured, _recessionMeasured)
                _propertyNode = mMyStore.GetProperty(sRecessionMeasured)
            Else
                ' Property exists; check if value is default
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.Source = ValueSources.Defaulted) Then
                    ' Value is default; update it
                    _recessionMeasured = DirectCast(_param, BooleanParameter)
                    ResetRecessionMeasured(_recessionMeasured)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property RecessionMeasured() As BooleanParameter
        Get
            Dim _recessionMeasured As BooleanParameter = RecessionMeasuredProperty.GetBooleanParameter()
            Return _recessionMeasured
        End Get
        Set(ByVal value As BooleanParameter)
            RecessionMeasuredProperty.SetParameter(value)
        End Set
    End Property

    Public Sub ResetRecessionMeasured(ByVal recessionMeasured As BooleanParameter)
        recessionMeasured.Value = False
        Debug.Assert(recessionMeasured.Source = ValueSources.Defaulted)

        ' First, check if Recession data exists in InflowManagement
        Dim recParam As DataTableParameter = TabulatedRecession
        If (recParam IsNot Nothing) Then
            Dim recTable As DataTable = recParam.Value
            If (recTable IsNot Nothing) Then
                If (recTable.Rows IsNot Nothing) Then
                    If (0 < recTable.Rows.Count) Then
                        recessionMeasured.Value = True
                    End If
                End If
            End If
        End If

        ' If not, check what Event Analysis needs
        If Not (recessionMeasured.Value) Then
            Select Case (mUnit.EventCriteriaRef.EventAnalysisType.Value)
                Case EventAnalysisTypes.MerriamKellerAnalysis
                    recessionMeasured.Value = True
            End Select
        End If

    End Sub
    '
    ' Check if Recession data is available / valid
    '
    Public Function RecessionDataAvailable() As Boolean
        RecessionDataAvailable = False

        If (RecessionMeasured.Value) Then ' user said Recession data was entered; was it?
            Dim recParam As DataTableParameter = TabulatedRecession
            If (recParam IsNot Nothing) Then
                Dim recTable As DataTable = recParam.Value
                If (recTable IsNot Nothing) Then
                    If (recTable.Rows IsNot Nothing) Then
                        If (0 < recTable.Rows.Count) Then
                            RecessionDataAvailable = True
                        End If
                    End If
                End If
            End If
        End If
    End Function

    Public Function RecessionDataIsValid() As Boolean
        RecessionDataIsValid = True

        If (Me.RecessionDataAvailable) Then

            Dim Tco As Double = Me.Tco
            Dim TL As Double = Me.TL
            Dim L As Double = mUnit.SystemGeometryRef.Length.Value

            Dim recessionTable As DataTable = Me.TabulatedRecession.Value
            Dim rowCount As Integer = recessionTable.Rows.Count

            Dim recRow0 As DataRow = recessionTable.Rows(0)
            Dim dist0 As Double = recRow0.Item(nDistanceX)
            Dim time0 As Double = recRow0.Item(nTimeX1)

            Dim recRowL As DataRow = recessionTable.Rows(rowCount - 1)
            Dim distL As Double = recRowL.Item(nDistanceX)
            Dim timeL As Double = recRowL.Item(nTimeX1)

            ' First distance must be zero; time at or after Tco
            If ((dist0 <> 0.0) Or (time0 < Tco)) Then
                RecessionDataIsValid = False
            End If

            ' Last distance must be end-of-field (L); time at or after advance to end-of-field (TL)
            If (Not ThisClose(distL, L, OneDecimeter) Or (timeL < TL)) Then
                RecessionDataIsValid = False
            End If

        Else
            RecessionDataIsValid = False
        End If ' Recession data available

    End Function

    '*********************************************************************************************************
    ' Recession data is to be used for Volume Balance calculation
    '*********************************************************************************************************
    Public Const sRecessionUsed As String = "Recession Used"

    Public ReadOnly Property RecessionUsedProperty() As PropertyNode
        Get
            Dim _recessionUsed As BooleanParameter = Nothing

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sRecessionUsed)
            If (_propertyNode Is Nothing) Then
                ' Property does not exist; add it
                _recessionUsed = New BooleanParameter
                ResetRecessionUsed(_recessionUsed)
                mMyStore.AddProperty(sRecessionUsed, _recessionUsed)
                _propertyNode = mMyStore.GetProperty(sRecessionUsed)
            Else
                ' Property exists; check if value is default
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.Source = ValueSources.Defaulted) Then
                    ' Value is default; update it
                    _recessionUsed = DirectCast(_param, BooleanParameter)
                    ResetRecessionUsed(_recessionUsed)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property RecessionUsed() As BooleanParameter
        Get
            Dim _recessionUsed As BooleanParameter = RecessionUsedProperty.GetBooleanParameter()
            Return _recessionUsed
        End Get
        Set(ByVal value As BooleanParameter)
            RecessionUsedProperty.SetParameter(value)
        End Set
    End Property

    Public Sub ResetRecessionUsed(ByVal _recessionUsed As BooleanParameter)
        _recessionUsed.Value = False
        Debug.Assert(_recessionUsed.Source = ValueSources.Defaulted)

        ' If not, check what Event Analysis needs
        If Not (_recessionUsed.Value) Then
            Select Case (mUnit.EventCriteriaRef.EventAnalysisType.Value)
                Case EventAnalysisTypes.MerriamKellerAnalysis
                    _recessionUsed.Value = True
            End Select
        End If

    End Sub

#End Region

#End Region

#Region " Measurement Stations "
    '
    ' Selected Station
    '
    Public Const sSelectedStation As String = "Selected Station"

    Public ReadOnly Property SelectedStationProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSelectedStation)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then ' not found
                Dim _integer As IntegerParameter = New IntegerParameter(0)
                mMyStore.AddProperty(sSelectedStation, _integer)
                _propertyNode = mMyStore.GetProperty(sSelectedStation)

            Else ' property found; validate index is within Measurement Stations table
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _integer As IntegerParameter = DirectCast(_param, IntegerParameter)

                Dim _measStations As DataTable = MeasurementStations.Value

                If (_integer.Value < 0) Then
                    _integer.Value = 0
                End If

                If (_integer.Value > _measStations.Rows.Count - 1) Then
                    _integer.Value = _measStations.Rows.Count - 1
                End If

            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SelectedStation() As IntegerParameter
        Get
            Return SelectedStationProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            SelectedStationProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Station Measurements
    '
    Public Const sMeasurementStations As String = "Measurement Stations"

    Public ReadOnly Property MeasurementStationsProperty() As PropertyNode
        Get
            ' Define default Measurement Stations table
            Dim _measStations As DataTable = New DataTable(sMeasurementStations)
            ResetStationMeasurements(_measStations)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMeasurementStations, _measStations)

            ' Update columns
            If (_measStations.Columns.Contains(sElevAdjustX)) Then
                ' Add Elevation Adjustments to Elevations
                For Each row As DataRow In _measStations.Rows
                    Dim adjust As Double = CDbl(row.Item(sElevAdjustX))

                    Dim elev As Double = CDbl(row.Item(sElevationX))
                    elev += adjust
                    row.Item(sElevationX) = elev
                Next
                ' Then remove Elevation Adjustment column
                _measStations.Columns.Remove(sElevAdjustX)
            End If

            If (_measStations.Columns.Contains(sUseForVB)) Then
                _measStations.Columns.Remove(sUseForVB)
            End If

            If Not (_measStations.Columns(1).ExtendedProperties.Contains("Format")) Then
                _measStations.Columns(1).ExtendedProperties.Add("Format", "0.000")
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MeasurementStations() As DataTableParameter
        Get
            Dim _table As DataTableParameter = MeasurementStationsProperty.GetDataTableParameter()
            Return _table
        End Get
        Set(ByVal value As DataTableParameter)
            MeasurementStationsProperty.SetParameter(value)
        End Set
    End Property

    Public Sub ResetStationMeasurements(ByVal Stations As DataTable)

        ' Remove the previous data
        Stations.Columns.Clear()
        Stations.Rows.Clear()

        ' Add the columns
        Stations.Columns.Add(sDistanceX, GetType(Double))
        Stations.Columns.Add(sElevationX, GetType(Double))

    End Sub

#End Region

#Region " Flow Depths "

#Region " Station Flow Depths "
    '
    ' DataSet of Station Flow Depths (DataTables)
    '
    Public Const sStationsFlowDepths As String = "Stations Flow Depths"

    Public ReadOnly Property StationsFlowDepthsProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sStationsFlowDepths)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _flowDepths As DataSet = New DataSet(sStationsFlowDepths)

                ResetStationsFlowDepths(_flowDepths)

                Dim _parameter As DataSetParameter = New DataSetParameter(_flowDepths)
                mMyStore.AddProperty(sStationsFlowDepths, _parameter)
                _propertyNode = mMyStore.GetProperty(sStationsFlowDepths)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter()
                Dim _dataSetParam As DataSetParameter = DirectCast(_param, DataSetParameter)
                Dim _flowSet As DataSet = _dataSetParam.Value

                If (_dataSetParam.Source = ValueSources.Defaulted) Then
                    ResetStationsFlowDepths(_flowSet)
                Else
                    Dim _measStations As DataTable = Me.MeasurementStations.Value

                    If (_flowSet.Tables.Count = _measStations.Rows.Count) Then
                        ' Update distances for Flow Depth tables; must match Station distances
                        For fdx As Integer = 0 To _flowSet.Tables.Count - 1
                            Dim _measRow As DataRow = _measStations.Rows(fdx)
                            Dim _dist As Double = CDbl(_measRow.Item(sDistanceX))

                            Dim _flowTable As DataTable = _flowSet.Tables(fdx)

                            ' Update columns
                            If (_flowTable.Columns.Contains(sDepthAdjustX)) Then
                                _flowTable.Columns.Remove(sDepthAdjustX)
                            End If

                            ' Update distances
                            If (_flowTable.ExtendedProperties.Contains(sDistanceX)) Then
                                _flowTable.ExtendedProperties.Remove(sDistanceX)
                            End If
                            _flowTable.ExtendedProperties.Add(sDistanceX, _dist)
                        Next fdx
                    End If
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property StationsFlowDepths() As DataSetParameter
        Get
            Dim _dataSetParameter As DataSetParameter = StationsFlowDepthsProperty.GetDataSetParameter()
            Return _dataSetParameter
        End Get
        Set(ByVal value As DataSetParameter)
            StationsFlowDepthsProperty.SetParameter(value)
        End Set
    End Property

    Private Sub ResetStationsFlowDepths(ByVal FlowDepthsSet As DataSet)

        ' Remove the previous data
        FlowDepthsSet.Tables.Clear()

        ' Add the Flow Depth tables (one for each Station)
        Dim stationTable As DataTable = Me.MeasurementStations.Value
        If (stationTable IsNot Nothing) Then

            ' Add Flow Depth table for each Station distance
            For Each station As DataRow In stationTable.Rows
                Dim distance As Double = station.Item(sDistanceX)
                Dim flowDepths As DataTable = NewStationFlowDepthTable(distance)
                AddDataTableToDataSet(flowDepths, FlowDepthsSet)
            Next station

        End If

    End Sub

    Public Shared Function NewStationFlowDepthTable(ByVal Distance As Double) As DataTable

        NewStationFlowDepthTable = New DataTable("Station at " & LengthString(Distance))

        ' Attach the Station Distance as an Extended Property
        NewStationFlowDepthTable.ExtendedProperties.Add(sDistanceX, Distance)

        ' Add the columns
        NewStationFlowDepthTable.Columns.Add(sTimeX, GetType(Double))
        NewStationFlowDepthTable.Columns.Add(sDepthX, GetType(Double))

        ' Initialize the flow depth data
        Dim depthRow As DataRow = NewStationFlowDepthTable.NewRow
        depthRow(sTimeX) = 0.0
        depthRow(sDepthX) = 0.0
        NewStationFlowDepthTable.Rows.Add(depthRow)

    End Function

    Public Sub SyncFlowHydrographsToStations()

        Try
            Dim measStations As DataTable = Me.MeasurementStations.Value
            If (measStations.Rows IsNot Nothing) Then

                Dim stationCount As Integer = measStations.Rows.Count

                Dim flowParam As DataSetParameter = Me.StationsFlowDepths
                Dim flowDepths As DataSet = flowParam.Value
                If (flowDepths.Tables IsNot Nothing) Then

                    Dim flowDepthsChanged As Boolean = False

                    Dim hydroCount As Integer = flowDepths.Tables.Count

                    If (stationCount < hydroCount) Then ' station(s) were deleted
                        '
                        ' Delete the corresponding Flow Depth Hydrograph(s).  Scan the Flow Depth
                        ' Hydrographs looking for ones without a matching Measurement Station.
                        '
                        Dim fdx As Integer = 0
                        While (fdx < flowDepths.Tables.Count)

                            Dim hydrograph As DataTable = flowDepths.Tables(fdx)
                            Dim hydroDist As Double = hydrograph.ExtendedProperties(sDistanceX)
                            Dim found As Boolean = False

                            For Each station As DataRow In measStations.Rows
                                Dim stationDist As Double = station.Item(sDistanceX)
                                If (stationDist = hydroDist) Then ' found matching Station
                                    found = True
                                    Exit For
                                End If
                            Next station

                            If Not (found) Then
                                flowDepths.Tables.Remove(hydrograph)
                                flowDepthsChanged = True
                                hydroCount -= 1
                            Else
                                fdx += 1
                            End If

                        End While

                    End If

                    If (hydroCount < stationCount) Then ' station(s) were added
                        '
                        ' Add a Flow Depth Hydrograph for each new station.  Scan the Stations
                        ' looking for ones without a matching Flow Depth table.
                        '
                        For Each station As DataRow In measStations.Rows
                            Dim stationDist As Double = station.Item(sDistanceX)

                            Dim distInTable As Boolean = False
                            Dim fdx As Integer = 0
                            While (fdx < flowDepths.Tables.Count)

                                Dim hydrograph As DataTable = flowDepths.Tables(fdx)
                                Dim hydroDist As Double = hydrograph.ExtendedProperties(sDistanceX)

                                If (hydroDist = stationDist) Then ' found Flow Depth table for Station
                                    distInTable = True
                                    Exit While
                                ElseIf (hydroDist > stationDist) Then ' insert new Flow Depth table within set
                                    hydrograph = NewStationFlowDepthTable(stationDist)
                                    InsertDataTableIntoDataSet(hydrograph, flowDepths, fdx)
                                    flowDepthsChanged = True
                                    distInTable = True
                                    Exit While
                                End If

                                fdx += 1
                            End While

                            If Not (distInTable) Then ' new Station must be at end of list
                                Dim hydrograph As DataTable = NewStationFlowDepthTable(stationDist)
                                AddDataTableToDataSet(hydrograph, flowDepths)
                                flowDepthsChanged = True
                            End If
                        Next station

                    End If

                    ' If changes were made; save them
                    If (flowDepthsChanged) Then
                        Me.StationsFlowDepths = flowParam
                    End If

                End If ' no Flow Depths
            End If ' no Measurement Stations
        Catch ex As Exception
            Debug.Assert(False)
        End Try

    End Sub

#End Region

#Region " Flow Depths Measured / Used "
    '
    ' Flow Depths have been measured for an irrigation
    '
    Public Const sFlowDepthsMeasured As String = "Flow Depths Measured"

    Public ReadOnly Property FlowDepthsMeasuredProperty() As PropertyNode
        Get
            Dim _flowDepthsMeasured As BooleanParameter = Nothing

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFlowDepthsMeasured)
            If (_propertyNode Is Nothing) Then
                ' Property does not exist; add it
                _flowDepthsMeasured = New BooleanParameter
                ResetFlowDepthsMeasured(_flowDepthsMeasured)
                mMyStore.AddProperty(sFlowDepthsMeasured, _flowDepthsMeasured)
                _propertyNode = mMyStore.GetProperty(sFlowDepthsMeasured)
            Else
                ' Property exists; check if value is default
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.Source = ValueSources.Defaulted) Then
                    ' Value is default; update it
                    _flowDepthsMeasured = DirectCast(_param, BooleanParameter)
                    ResetFlowDepthsMeasured(_flowDepthsMeasured)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property FlowDepthsMeasured() As BooleanParameter
        Get
            Dim _flowDepthsMeasured As BooleanParameter = FlowDepthsMeasuredProperty.GetBooleanParameter()
            Return _flowDepthsMeasured
        End Get
        Set(ByVal value As BooleanParameter)
            FlowDepthsMeasuredProperty.SetParameter(value)
        End Set
    End Property

    Public Sub ResetFlowDepthsMeasured(ByVal _flowDepthsMeasured As BooleanParameter)
        _flowDepthsMeasured.Value = False
        Debug.Assert(_flowDepthsMeasured.Source = ValueSources.Defaulted)

        ' First, check if Flow Depths data exists in InflowManagement
        Dim _flowDepthsParam As DataSetParameter = Me.StationsFlowDepths
        If (_flowDepthsParam IsNot Nothing) Then
            Dim _flowDepthsSet As DataSet = _flowDepthsParam.Value
            If (_flowDepthsSet IsNot Nothing) Then
                If (_flowDepthsSet.Tables IsNot Nothing) Then
                    If (0 < _flowDepthsSet.Tables.Count) Then
                        _flowDepthsMeasured.Value = True
                    End If
                End If
            End If
        End If

        ' If not, check what Event Analysis needs
        '  No analysis requires Flow Depths; it is useful

    End Sub
    '
    ' Check if FlowDepths data is available
    '
    Public Function FlowDepthsDataAvailable() As Boolean
        FlowDepthsDataAvailable = False

        If (FlowDepthsMeasured.Value) Then ' user said FlowDepths data was entered; was it?
            Dim fdParam As DataSetParameter = Me.StationsFlowDepths
            If (fdParam IsNot Nothing) Then
                Dim fdSet As DataSet = fdParam.Value
                If (fdSet IsNot Nothing) Then
                    If (fdSet.Tables IsNot Nothing) Then
                        If (0 < fdSet.Tables.Count) Then
                            FlowDepthsDataAvailable = True
                        End If
                    End If
                End If
            End If
        End If
    End Function

    '*********************************************************************************************************
    ' Flow Depths are to be used for Volume Balance calculations
    '*********************************************************************************************************
    Public Const sFlowDepthsUsed As String = "Flow Depths Used"

    Public ReadOnly Property FlowDepthsUsedProperty() As PropertyNode
        Get
            Dim _flowDepthsUsed As BooleanParameter = Nothing

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sFlowDepthsUsed)
            If (_propertyNode Is Nothing) Then
                ' Property does not exist; add it
                _flowDepthsUsed = New BooleanParameter
                ResetFlowDepthsUsed(_flowDepthsUsed)
                mMyStore.AddProperty(sFlowDepthsUsed, _flowDepthsUsed)
                _propertyNode = mMyStore.GetProperty(sFlowDepthsUsed)
            Else
                ' Property exists; check if value is default
                Dim _param As Parameter = _propertyNode.GetParameter
                If (_param.Source = ValueSources.Defaulted) Then
                    ' Value is default; update it
                    _flowDepthsUsed = DirectCast(_param, BooleanParameter)
                    ResetFlowDepthsUsed(_flowDepthsUsed)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property FlowDepthsUsed() As BooleanParameter
        Get
            Dim _flowDepthsUsed As BooleanParameter = FlowDepthsUsedProperty.GetBooleanParameter()
            Return _flowDepthsUsed
        End Get
        Set(ByVal value As BooleanParameter)
            FlowDepthsUsedProperty.SetParameter(value)
        End Set
    End Property

    Public Sub ResetFlowDepthsUsed(ByVal _flowDepthsUsed As BooleanParameter)
        _flowDepthsUsed.Value = False
        Debug.Assert(_flowDepthsUsed.Source = ValueSources.Defaulted)
    End Sub

#End Region

#End Region

#End Region

#Region " Calculated Properties "

#Region " Inflow "

    '*********************************************************************************************************
    ' Function InflowRateAtTimeForField()           - Inflow Rate for entire field at a specified Time (T)
    ' Function InflowRateAtTimeForCrossSection()    -    "     "   "  cross section " "     "       "   "
    ' Function FurrowInflowRate()                   -    "     "   "  furrow        " Time (T) = 0.0
    '
    ' Input(s):     T       - Time at which to return Inflow Rate (Qin)
    '
    ' Returns:      Doulbe  - Qin at T
    '
    ' Note - Qin at T can only be determined for:
    '
    '   1) Standard Hydrographs with time-based cutoff/cutback
    '   2) Tabulated Inflow hydrograph
    '
    ' Note - InflowRate property is for a field unit (i.e. Basin, Border or Furrow Set)
    '*********************************************************************************************************
    Public Function InflowRateAtTimeForField(ByVal T As Double) As Double
        Dim Qin As Double = InflowRate.Value ' initial Qin

        Try
            Select Case InflowMethod.Value

                Case InflowMethods.StandardHydrograph

                    ' Qin can be determined with time-based cutoff/cutback
                    If (CutoffMethod.Value = CutoffMethods.TimeBased) Then

                        Dim Tco As Double = CutoffTime.Value                ' cutoff time
                        Dim Tcb As Double = Tco * CutbackTimeRatio.Value    ' cutback time

                        If (T <= Tco) Then ' prior to cutoff
                            ' Cutback Qin can be determined with time-based cutback
                            If (CutbackMethod.Value = CutbackMethods.TimeBased) Then
                                If (Tcb < T) Then ' time is after cutback
                                    Qin *= CutbackRateRatio.Value ' cutback rate
                                End If
                            End If
                        Else ' Tco < T
                            Qin = 0.0
                        End If
                    End If

                Case InflowMethods.TabulatedInflow

                    ' Search Tabulated Inflow hydrograph for Time (T)
                    If (Me.TabulatedInflowHasData) Then ' Table exists with at least 1 row of data
                        Dim inflowTable As DataTable = TabulatedInflow.Value
                        Dim rowCount As Integer = inflowTable.Rows.Count

                        Dim row As DataRow = inflowTable.Rows(0)    ' Inflow data from 1st row
                        Dim T1 As Double = row.Item(nTimeX)
                        Dim Q1 As Double = row.Item(sInflowX)

                        Dim rdx As Integer
                        Dim T2, Q2 As Double

                        If (1 < rowCount) Then ' Table has more than 1 row of data; search for T

                            For rdx = 1 To rowCount - 1
                                row = inflowTable.Rows(rdx) ' next row of Inflow data
                                T2 = row.Item(nTimeX)
                                Q2 = row.Item(sInflowX)

                                If (T <= T1) Then ' T at left end of time span; Qin is at left end
                                    Qin = Q1
                                    Exit For
                                ElseIf (T < T2) Then ' T within time span; interpolate for Qin
                                    Dim ratio As Double = (T - T1) / (T2 - T1)
                                    Qin = Q1 + ratio * (Q2 - Q1)
                                    Exit For
                                ElseIf (T = T2) Then ' T at right end of time spane; Qin is at right end
                                    Qin = Q2
                                    Exit For
                                End If

                                ' T not found yet, save right end of time span as left end of next time span
                                T1 = T2
                                Q1 = Q2
                            Next rdx

                            If (rowCount <= rdx) Then ' Time T not found within table; T is after Tco
                                Qin = 0.0
                            End If

                        Else ' only one row of Inflow data; return Qin from it
                            Qin = Q1
                        End If
                    End If

                Case Else ' Surge, Cablegation, etc.
                    Debug.Assert(False, "Support for Inflow Method must be added")

            End Select

        Catch ex As Exception
            Qin = InflowRate.Value
        End Try

        Return Qin
    End Function

    Public Function InflowRateAtTimeForCrossSection(ByVal Time As Double) As Double
        Dim Qin As Double = InflowRateAtTimeForField(Time) ' Qin for field
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value
            Qin /= furrowsPerSet ' Qin for cross section
        End If
        Return Qin
    End Function

    Public Function FurrowInflowRate() As Double
        Dim Qin As Double = InflowRate.Value ' Qin for field
        Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value
        Qin /= furrowsPerSet ' Qin for single furrow
        Return Qin
    End Function

    '*********************************************************************************************************
    ' Function MaximumInflowRateField()             - Qmax for field
    '
    ' Function AverageInflowRateForField()          - Qavg for field
    ' Function AverageInflowRateForCrossSection()   -   "   "  cross section
    '*********************************************************************************************************
    Public Function MaximumInflowRateForField() As Double
        Dim Qmax As Double = 0.0

        Select Case InflowMethod.Value

            Case InflowMethods.Surge

                Qmax = SurgeInflowRate.Value

            Case InflowMethods.Cablegation

                ' Get the Tabulated Inflow values
                Dim inflowTable As DataTable = CablegationInflowTable()
                If (inflowTable IsNot Nothing) Then
                    For Each row As DataRow In inflowTable.Rows
                        Dim Qin As Double = CDbl(row.Item(sInflowX))
                        If (Qmax < Qin) Then
                            Qmax = Qin
                        End If
                    Next
                End If

            Case InflowMethods.TabulatedInflow

                ' Get the Tabulated Inflow values
                Dim inflowTable As DataTable = TabulatedInflow.Value
                If (inflowTable IsNot Nothing) Then
                    For Each row As DataRow In inflowTable.Rows
                        Dim Qin As Double = CDbl(row.Item(sInflowX))
                        If (Qmax < Qin) Then
                            Qmax = Qin
                        End If
                    Next
                End If

            Case Else ' Assume InflowMethods.StandardHydrograph

                Qmax = InflowRate.Value

        End Select

        Return Qmax
    End Function

    Public Function MaximumInflowRateForCrossSection()
        Dim Qmax As Double = MaximumInflowRateForField() ' Qmax for field
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value
            Qmax /= furrowsPerSet ' Qmax for cross section
        End If
        Return Qmax
    End Function

    Public Function AverageInflowRateForField() As Double
        Dim Qavg As Double = 0.0

        Select Case InflowMethod.Value

            Case InflowMethods.Surge

                ' Get Applied Volume through Cutoff Time
                Dim Tco As Double = SurgeCutoffTime.Value
                Qavg = AverageInflowRate(Tco)

            Case InflowMethods.Cablegation

                ' Get Applied Volume through last row of Cablegation Inflow data
                Dim inflowTable As DataTable = CablegationInflowTable()
                If (inflowTable IsNot Nothing) Then
                    Dim lastRow As Integer = inflowTable.Rows.Count - 1
                    If (0 <= lastRow) Then
                        Dim Tco As Double = CDbl(inflowTable.Rows(lastRow).Item(nTimeX))
                        Qavg = AverageInflowRate(Tco)
                    End If
                End If

            Case InflowMethods.TabulatedInflow

                ' Get Applied Volume through last row of Tabulated Inflow data
                Dim inflowTable As DataTable = TabulatedInflow.Value
                If (inflowTable IsNot Nothing) Then
                    Dim lastRow As Integer = inflowTable.Rows.Count - 1
                    If (0 <= lastRow) Then
                        Dim Tco As Double = CDbl(inflowTable.Rows(lastRow).Item(nTimeX))
                        Qavg = AverageInflowRate(Tco)
                    End If
                End If

            Case Else ' Assume InflowMethods.StandardHydrograph

                ' Get Applied Volume through Cutoff Time
                Dim Tco As Double = CutoffTime.Value
                Qavg = AverageInflowRate(Tco)
        End Select

        Return Qavg
    End Function

    Public Function AverageInflowRateForCrossSection()
        Dim Qavg As Double = AverageInflowRateForField() ' Qavg for field
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value
            Qavg /= furrowsPerSet ' Qavg for cross section
        End If
        Return Qavg
    End Function
    '
    ' Calculate Qavg through specified time
    '
    Public Function AverageInflowRate(ByVal time As Double) As Double
        Dim Qavg As Double = 0.0

        If (0.0 < time) Then
            Dim Vapp As Double = AppliedVolumeForField(time)
            Qavg = Vapp / time
        End If

        Return Qavg
    End Function

    Public Function AverageInflowRateForCrossSection(ByVal time As Double)
        AverageInflowRateForCrossSection = AverageInflowRate(time)
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            AverageInflowRateForCrossSection /= mUnit.SystemGeometryRef.FurrowsPerSet.Value
        End If
    End Function
    '
    ' Build an Inflow Table based on the Standard Hydrograph parameters
    '
    Public Function HydrographInflowTable() As DataTable
        Dim Q As Double = InflowRate.Value
        Dim Tco As Double = CutoffTime.Value
        Dim Qcb As Double = Q * CutbackRateRatio.Value
        Dim Tcb As Double = Tco * CutbackTimeRatio.Value
        Return Me.HydrographInflowTable(Q, Tco, Qcb, Tcb)
    End Function

    Public Function HydrographInflowTable(ByVal Q As Double, ByVal Tco As Double) As DataTable
        Dim Qcb As Double = Q * CutbackRateRatio.Value
        Dim Tcb As Double = Tco * CutbackTimeRatio.Value
        Return Me.HydrographInflowTable(Q, Tco, Qcb, Tcb)
    End Function

    Public Function HydrographInflowTable(ByVal Q As Double, ByVal Tco As Double, _
                                          ByVal Qcb As Double, ByVal Tcb As Double) As DataTable

        ' Get the Hydrograph values
        Dim _cutoffMethod As CutoffMethods = CType(CutoffMethod.Value, CutoffMethods)
        Dim _cutbackMethod As CutbackMethods = CType(CutbackMethod.Value, CutbackMethods)

        ' Create the Tabulated Inflow table for the Standard Hydrograph
        Dim _inflowTable As DataTable = New DataTable("Standard Hydrograph")
        Dim _inflowRow As DataRow

        ' Add the columns
        _inflowTable.Columns.Add(sTimeX, GetType(Double))
        _inflowTable.Columns.Add(sInflowX, GetType(Double))

        ' How the Inflow Table is constructed depends on the Cutoff / Cutback methods
        Select Case _cutoffMethod
            Case Globals.CutoffMethods.TimeBased
                Select Case _cutbackMethod

                    Case Globals.CutbackMethods.NoCutback

                        _inflowRow = _inflowTable.NewRow
                        _inflowRow.Item(nTimeX) = 0.0
                        _inflowRow.Item(nInflowX) = Q
                        _inflowTable.Rows.Add(_inflowRow)

                        _inflowRow = _inflowTable.NewRow
                        _inflowRow.Item(nTimeX) = Tco
                        _inflowRow.Item(nInflowX) = Q
                        _inflowTable.Rows.Add(_inflowRow)

                        _inflowRow = _inflowTable.NewRow
                        _inflowRow.Item(nTimeX) = Tco
                        _inflowRow.Item(nInflowX) = 0.0
                        _inflowTable.Rows.Add(_inflowRow)

                    Case Globals.CutbackMethods.TimeBased

                        _inflowRow = _inflowTable.NewRow
                        _inflowRow.Item(nTimeX) = 0.0
                        _inflowRow.Item(nInflowX) = Q
                        _inflowTable.Rows.Add(_inflowRow)

                        If (Tcb < Tco) Then
                            ' Cutback
                            _inflowRow = _inflowTable.NewRow
                            _inflowRow.Item(nTimeX) = Tcb
                            _inflowRow.Item(nInflowX) = Q
                            _inflowTable.Rows.Add(_inflowRow)

                            _inflowRow = _inflowTable.NewRow
                            _inflowRow.Item(nTimeX) = Tcb
                            _inflowRow.Item(nInflowX) = Qcb
                            _inflowTable.Rows.Add(_inflowRow)

                            _inflowRow = _inflowTable.NewRow
                            _inflowRow.Item(nTimeX) = Tco
                            _inflowRow.Item(nInflowX) = Qcb
                            _inflowTable.Rows.Add(_inflowRow)
                        Else
                            ' No Cutback
                            _inflowRow = _inflowTable.NewRow
                            _inflowRow.Item(nTimeX) = Tco
                            _inflowRow.Item(nInflowX) = Q
                            _inflowTable.Rows.Add(_inflowRow)
                        End If

                        _inflowRow = _inflowTable.NewRow
                        _inflowRow.Item(nTimeX) = Tco
                        _inflowRow.Item(nInflowX) = 0.0
                        _inflowTable.Rows.Add(_inflowRow)
                End Select
        End Select

        Return _inflowTable
    End Function
    '
    ' Get the Tabulated Cutoff Time
    '
    Public Function TabulatedCutoffTime(ByVal _tabulatedInflow As DataTable, Optional ByVal Heading As String = sTimeX) As Double
        Dim Tco As Double = 0.0

        ' Get the Tabulated Inflow table
        If (_tabulatedInflow IsNot Nothing) Then
            If (_tabulatedInflow.Columns.Contains(Heading)) Then
                Dim _count As Integer = _tabulatedInflow.Rows.Count
                If (0 < _count) Then
                    Tco = CDbl(_tabulatedInflow.Rows(_count - 1).Item(Heading))
                End If
            End If
        End If

        Return Tco
    End Function
    '
    ' Get the Inflow Method dependent Cutoff Time
    '
    Public Function Tco() As Double

        Select Case (InflowMethod.Value)
            Case InflowMethods.Surge
                Select Case (SurgeStrategy.Value)
                    Case SurgeStrategies.TabulatedTime
                        Dim _tabulatedInflow As DataTable = SurgeTimesTable.Value
                        Tco = TabulatedCutoffTime(_tabulatedInflow, sEndTimeX)
                    Case Else
                        Tco = SurgeCutoffTime.Value
                End Select

            Case InflowMethods.Cablegation
                Dim _tabulatedInflow As DataTable = CablegationInflowTable()
                Tco = TabulatedCutoffTime(_tabulatedInflow)

            Case InflowMethods.TabulatedInflow
                Dim _tabulatedInflow As DataTable = TabulatedInflow.Value
                Tco = TabulatedCutoffTime(_tabulatedInflow)

            Case Else ' Assume InflowMethods.StandardHydrograph
                If (CutoffMethod.Value = CutoffMethods.TimeBased) Then
                    Tco = CutoffTime.Value
                Else
                    Tco = Double.MaxValue
                End If
        End Select

    End Function

    Public Function Cutoff() As Double
        Cutoff = Me.Tco
    End Function
    '
    ' Calculate the Cablegation Inflow Table
    '
    ' This function is a port of 'Subroutine QCABLE' from SRFR 4.10 - A2.f95
    '
    ' NOTE - units used in this function ARE NOT SI!  They are maintained as they are used in QCABLE.
    '
    Public Function CablegationInflowTable() As DataTable
        CablegationInflowTable = New DataTable("Cablegation Inflow")
        CablegationInflowTable.Columns.Add(sTimeX, GetType(Double))
        CablegationInflowTable.Columns.Add(sInflowX, GetType(Double))

        Const NCABLEOMX As Integer = 1000   ' Maximum number of orifices allowed
        Dim Q_O(NCABLEOMX) As Double        ' Orifice flow, Q (lps)
        Dim H_O(NCABLEOMX) As Double        ' Orifice elevation, H (m)
        '
        ' From SRFR 4.10 - I1.f95:
        '
        ' QTOT=InflowRate(2)*1000.0     ! lps
        ' D_P= InflowRate(3)*1000.0     ! mm 
        ' S_P= InflowRate(4)            ! m/m
        ' C_HW=InflowRate(5)
        ' d_o= InflowRate(6)*1000.0     ! mm
        ' Q_o_peak=InflowRate(7)*1000.0 ! lps
        ' Q_o_co=  InflowRate(8)*1000.0 ! lps
        ' l_o= InflowRate(9)            ! m
        ' v_Plug=  InflowRate(10)*3600.0! m/hr
        '
        Dim QTOT As Double = TotalInflow.Value * LitersPerCubicMeter         ' Total flow for all gates (lps)
        Dim D_P As Double = PipeDiameter.Value * MillimetersPerMeter         ' Pipe inside diameter (mm)
        Dim S_P As Double = PipeSlope.Value                                  ' Pipe slope (m/m)
        Dim C_HW As Double = HazenWilliamsPipeCoefficient.Value              ' Hazen-Williams coefficient
        Dim D_O As Double = OrificeDiameter.Value * MillimetersPerMeter      ' Equivalent diameter of orifice (mm)
        Dim Q_O_peak As Double = PeakOrificeFlow.Value * LitersPerCubicMeter ' Peak orifice flow (lps)
        Dim Q_O_co As Double = CutoffFlow.Value * LitersPerCubicMeter        ' Orifice cutoff flow (lps)
        Dim l_o As Double = OrificeSpacing.Value                             ' Orifice spacing (m)
        Dim v_Plug As Double = PlugSpeed.Value * SecondsPerHour              ' Plug speed (m/hr)

        Dim d_o_given As Boolean = (OrificeOption.Value = OrificeOptions.EquivalentDiameter)
        If Not (d_o_given) Then
            D_O = 50.0 ' (mm)
        End If
        '
        ' Values use throughout algorithm
        '
        Dim Cd0 As Double = 0.65                                    ' Basin, core value of orifice discharge coefficient

        Dim F0 As Double = 2.0 * G
        Dim F1 As Double = Math.Sqrt(F0)
        Dim F2 As Double = Pi / 4.0
        Dim F3 As Double = 6077145 / (C_HW ^ 1.85 * D_P ^ 4.865)
        Dim F4 As Double = F3 * SecondsPerMinute ^ 1.85
        Dim F5 As Double = (1000.0 / (F2 * D_P ^ 2.0)) ^ 2.0 / F0

        Dim Qcap As Double = (S_P / F4) ^ 0.54054
        Dim Sfmax As Double = F4 * QTOT ^ 1.85

        Dim delta_Q_O_error As Double = 0.0
        Dim delta_D_O As Double = -5.0
        Dim Q_O_error1 As Double = 0.0
        Dim Hold As Double = 0.0

        Dim I_O, I_D_O, I_O_END, J As Integer

        For I_D_O = 1 To 20
            Dim Q_P1 As Double = QTOT
            Dim HV_P1 As Double = F5 * Q_P1 ^ 2.0

            Q_O(1) = Q_O_co
            H_O(1) = 0.0

            For J = 1 To 40
                Dim Rh As Double = Math.Max(H_O(1) / HV_P1, 0.004)
                Dim Cd As Double = Cd0 * (1.0 - 0.28 / (0.4 + Rh))

                If ((1 < J) And (Math.Abs(H_O(1) - Hold) < 0.00001)) Then
                    Exit For
                End If

                Hold = H_O(1)
                H_O(1) = (Q_O(1) * LitersPerCubicMeter / (Cd * F2 * D_O ^ 2.0)) ^ 2.0 / F0
            Next ' J

            Q_O(0) = 0.0

            Dim HF As Double = 0.0
            Dim Delta_Z As Double = 0.0

            For I_O = 1 To NCABLEOMX
                Dim Q_P2 As Double = Q_P1 - Q_O(I_O - 1)

                If (Q_P2 < 0.0) Then
                    Exit For
                End If

                Dim Sf As Double = F4 * Q_P2 ^ 1.85
                Dim HV_P2 As Double = F5 * Q_P2 ^ 2.0

                If (1 < I_O) Then
                    HF = l_o * Sf
                    Delta_Z = l_o * S_P
                    H_O(I_O) = Math.Max(H_O(I_O - 1) + HV_P1 - HV_P2 + Delta_Z - HF, 0.004 * HV_P2)
                End If

                Dim Rh As Double = Math.Max(H_O(I_O) / HV_P2, 0.004)
                Dim Cd As Double = Cd0 * (1.0 - 0.28 / (0.4 + Rh))
                Dim F6 As Double = F2 * D_O ^ 2.0 * F1 / 1000.0
                Q_O(I_O) = Cd * F6 * Math.Sqrt(H_O(I_O))
                Q_P1 = Q_P2
                HV_P1 = HV_P2
            Next ' I_O

            I_O_END = I_O - 1

            If (d_o_given) Then
                Exit For
            End If

            Dim Q_O_error As Double = Q_O_peak - Q_O(I_O_END)

            If (1 < I_D_O) Then
                delta_Q_O_error = Q_O_error - Q_O_error1
                delta_D_O = -delta_D_O * Q_O_error / delta_Q_O_error
            End If

            Q_O_error1 = Q_O_error

            If (Math.Abs(Q_O_error) < 0.001) Then
                Exit For
            End If

            D_O = D_O + delta_D_O

        Next ' I_D_O

        ' Use H_O to reverse order of Q_O
        For I_O = 1 To I_O_END
            H_O(I_O) = Q_O(I_O_END - I_O + 1)
        Next

        ' Build Cablegation Inflow Table
        Dim Q_last As Double = Double.MaxValue

        For I_O = 1 To I_O_END
            Q_O(I_O) = H_O(I_O) / LitersPerCubicMeter               ' Q is now in UI units (m^3/s)
            H_O(I_O) = (I_O - 1) * l_o * SecondsPerHour / v_Plug    ' H is now time in UI units (s)

            If (Q_last > Q_O(I_O)) Then
                Q_last = Q_O(I_O)

                Dim row As DataRow = CablegationInflowTable.NewRow
                row.Item(sTimeX) = H_O(I_O)
                row.Item(sInflowX) = Q_O(I_O)
                CablegationInflowTable.Rows.Add(row)
            Else
                Exit For
            End If
        Next

    End Function

    '*********************************************************************************************************
    ' Function InflowTableForField()        - return a DataTable of the current inflow for the entire field
    ' Function InflowTableForCrossSection() -    "   "     "      "  "     "       "    "   "  cross section
    '*********************************************************************************************************
    Public Function InflowTableForField() As DataTable
        InflowTableForField = Nothing

        Select Case Me.InflowMethod.Value
            Case InflowMethods.StandardHydrograph
                InflowTableForField = Me.HydrographInflowTable
            Case InflowMethods.Cablegation
                InflowTableForField = Me.CablegationInflowTable
            Case InflowMethods.TabulatedInflow
                InflowTableForField = Me.TabulatedInflow.Value
            Case Else
                Debug.Assert(False) ' Support for this Inflow Method must be added
        End Select

    End Function

    Public Function InflowTableForCrossSection() As DataTable
        InflowTableForCrossSection = InflowTableForField()

        If (InflowTableForCrossSection IsNot Nothing) Then
            If (mUnit.CrossSection = CrossSections.Furrow) Then
                Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value

                For Each inflowRow As DataRow In InflowTableForCrossSection.Rows
                    inflowRow.Item(sInflowX) /= furrowsPerSet
                Next inflowRow
            End If
        End If

    End Function

    '*********************************************************************************************************
    ' Function InflowHydrographTimes() - return Double() array of times in Inflow Hydrograph
    '*********************************************************************************************************
    Public Function InflowHydrographTimes() As Double()
        Dim qinTimes As Double() = {}
        Dim qinTable As DataTable = Me.InflowTableForField ' get table of Times vs. Qin
        If (qinTable IsNot Nothing) Then
            qinTimes = GetDoubleColumn(qinTable, nTimeX) ' copy Times column to Double()
        End If
        Return qinTimes
    End Function

    '*********************************************************************************************************
    ' Function TimeOfFirstSurgeStart()
    ' Function TimeOfFirstSurgeStop()
    '
    ' Return the Start & Stop time associated with the first surge of water onto the field
    '*********************************************************************************************************
    Public Function TimeOfFirstSurgeStart() As Double
        TimeOfFirstSurgeStart = 0.0

        Try
            ' Get table representing current inflow method
            Dim inflow As DataTable = Me.InflowTableForField
            Dim rowCount As Integer = inflow.Rows.Count
            Dim Qrow As DataRow = Nothing
            Dim time, qin As Double

            ' Find time where the 1st inflow surge starts (may not be at time = 0.0)
            Dim rdx As Integer = 0
            While rdx < rowCount
                Qrow = inflow.Rows(rdx)
                time = Qrow.Item(nTimeX)
                qin = Qrow.Item(nInflowX)
                If (qin > 0.0) Then ' Inflow has started

                    If (0 < rdx) Then ' Start is actually time from previous entry
                        rdx -= 1
                        Qrow = inflow.Rows(rdx)
                        time = Qrow.Item(nTimeX)
                        qin = Qrow.Item(nInflowX)
                    End If

                    TimeOfFirstSurgeStart = time
                    Exit Function
                End If
                rdx += 1
            End While

        Catch ex As Exception
            TimeOfFirstSurgeStart = 0.0
        End Try
    End Function

    Public Function TimeOfFirstSurgeStop() As Double
        TimeOfFirstSurgeStop = 0.0

        Dim FirstSurgeStartFound As Boolean = False

        Try
            ' Get table representing current inflow method
            Dim inflow As DataTable = Me.InflowTableForField
            Dim rowCount As Integer = inflow.Rows.Count
            Dim Qrow As DataRow = Nothing
            Dim time, qin As Double

            ' Find time where the 1st inflow surge starts (may not be at time=0.0)
            Dim rdx As Integer = 0
            While rdx < rowCount
                Qrow = inflow.Rows(rdx)
                time = Qrow.Item(nTimeX)
                qin = Qrow.Item(nInflowX)
                If (qin > 0.0) Then ' Inflow has started
                    FirstSurgeStartFound = True
                    Exit While
                End If
                rdx += 1
            End While

            ' If start of 1st surge found; find when in stops
            If (FirstSurgeStartFound) Then

                While rdx < rowCount
                    Qrow = inflow.Rows(rdx)
                    time = Qrow.Item(nTimeX)
                    qin = Qrow.Item(nInflowX)
                    If (qin <= 0.0) Then ' Inflow has stopped
                        TimeOfFirstSurgeStop = time
                        Exit Function
                    End If
                    rdx += 1
                End While

                ' The last inflow time is assumed to be Tco
                TimeOfFirstSurgeStop = time

            End If

        Catch ex As Exception
            TimeOfFirstSurgeStop = 0.0
        End Try
    End Function

    Public Function InflowComplete() As Boolean
        InflowComplete = False
        Select Case (Me.InflowMethod.Value)
            Case InflowMethods.StandardHydrograph
                InflowComplete = True
            Case InflowMethods.TabulatedInflow
                If (InflowDataAvailable() And Not Me.TabulatedInflowIncomplete.Value) Then
                    InflowComplete = True
                End If
            Case Else
                Debug.Assert(False, "Support for Inflow Method needs to be added.")
        End Select
    End Function

#End Region

#Region " Runoff "

    '*********************************************************************************************************
    ' Function RunoffTableForField()        - return a DataTable of the current runoff for the entire field
    ' Function RunoffTableForCrossSection() -    "   "     "      "  "     "       "    "   "  cross section
    '*********************************************************************************************************
    Public Function RunoffTableForField() As DataTable
        RunoffTableForField = Me.TabulatedRunoff.Value
    End Function

    Public Function RunoffTableForCrossSection() As DataTable
        RunoffTableForCrossSection = RunoffTableForField()

        If (RunoffTableForCrossSection IsNot Nothing) Then
            If (mUnit.CrossSection = CrossSections.Furrow) Then
                Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value

                For Each runoffRow As DataRow In RunoffTableForCrossSection.Rows
                    runoffRow.Item(sRunoffX) /= furrowsPerSet
                Next runoffRow
            End If
        End If

    End Function

    '*********************************************************************************************************
    ' Function RunoffVolumeForField()        - return Runoff Volume at a specified time for the field
    ' Function RunoffVolumeForCrossSection() -    "      "      "    " "     "       "   "   "  cross section
    '
    ' Input(s):     Time        - time at which to return the Runoff Volume
    '
    ' Returns:      Double      - Runoff Volume
    '*********************************************************************************************************
    Public Function RunoffVolumeForField(Optional ByVal time As Double = Double.MaxValue) As Double
        Dim runoffTable As DataTable = TabulatedRunoff.Value
        RunoffVolumeForField = DataTableIntegral(runoffTable, sTimeX, sRunoffX, time)
    End Function

    Public Function RunoffVolumeForCrossSection(Optional ByVal time As Double = Double.MaxValue) As Double
        Dim Vro As Double = RunoffVolumeForField(time)

        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value
            Vro /= furrowsPerSet
        End If

        Return Vro
    End Function

    '*********************************************************************************************************
    ' Function RunoffDepthForField()        - return Runoff Depth for the field
    ' Function RunoffDepthForCrossSection() -    "      "     "    "   "  cross section
    '
    ' Returns:      Double      - Runoff Depth
    '*********************************************************************************************************
    Public Function RunoffDepthForField() As Double
        Dim Vro As Double = RunoffVolumeForField()
        Dim fieldArea As Double = mUnit.SystemGeometryRef.FieldArea
        Dim Dro As Double = Vro / fieldArea
        Return Dro
    End Function

    Public Function RunoffDepthForCrossSection() As Double
        Dim Vro As Double = RunoffVolumeForCrossSection()
        Dim Area As Double = mUnit.SystemGeometryRef.AreaForCrossSection
        Dim Dro As Double = Vro / Area
        Return Dro
    End Function

    '*********************************************************************************************************
    ' Function SteadyRunoffRateForField()        - return Steady Runoff Rate for the field
    ' Function SteadyRunoffRateForCrossSection() -    "      "      "     "   "   "  cross section
    '
    ' Returns:      Double      - Steady Runoff Rate
    '*********************************************************************************************************
    Public Function SteadyRunoffRateForField() As Double
        Dim runoffTable As DataTable = TabulatedRunoff.Value

        If (0 = runoffTable.Rows.Count) Then ' no runoff has been entered
            SteadyRunoffRateForField = 0.0

        ElseIf (1 = runoffTable.Rows.Count) Then ' single runoff value entered
            Dim roRow As DataRow = runoffTable.Rows(0)
            Dim T As Double = roRow.Item(sTimeX)
            Dim Qro As Double = roRow.Item(sRunoffX)
            SteadyRunoffRateForField = Qro ' assume it represents steady runoff rate

        Else ' tabulated value entered; find rate at Tco
            Dim Tco As Double = Me.Tco        ' Cutoff time (Tco)
            SteadyRunoffRateForField = RunoffRateForField(Tco)  ' Runoff at Cutoff time
        End If
    End Function

    Public Function SteadyRunoffRateForCrossSection() As Double
        Dim Qro As Double = SteadyRunoffRateForField()
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value
            Qro /= furrowsPerSet
        End If
        Return Qro
    End Function

    '*********************************************************************************************************
    ' Function RunoffRateForField()        - return Runoff Rate at a specified time for the field
    ' Function RunoffRateForCrossSection() -    "      "     "   " "     "       "   "   "  cross section
    '
    ' Input(s):     Time        - time at which to return the Runoff Rate
    '
    ' Returns:      Double      - Runoff Rate
    '*********************************************************************************************************
    Public Function RunoffRateForField(ByVal time As Double) As Double
        Dim Qro As Double = 0.0

        Try
            ' Downstream end must be Open for there to be Runoff
            If (mUnit.SystemGeometryRef.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then

                ' Get the Runoff Hydrograph
                Dim _tabulatedRunoff As DataTable = TabulatedRunoff.Value

                ' Scan Runoff Hydrograph looking for point at or after specified Time
                Dim numRows As Integer = _tabulatedRunoff.Rows.Count

                If (1 < numRows) Then

                    For rdx As Integer = 0 To numRows - 1
                        Dim aRow As DataRow = _tabulatedRunoff.Rows(rdx)
                        Dim aTime As Double = CDbl(aRow.Item(nTimeX))
                        Dim aQro As Double = CDbl(aRow.Item(sRunoffX))

                        If (time <= aTime) Then
                            Qro = aQro

                            ' Is there a previous value?
                            If (0 < rdx) Then
                                ' Yes, interpolate to get Runoff at Time
                                Dim pRow As DataRow = _tabulatedRunoff.Rows(rdx - 1)
                                Dim pTime As Double = CDbl(pRow.Item(nTimeX))
                                Dim pQro As Double = CDbl(pRow.Item(sRunoffX))

                                Qro = pQro + ((aQro - pQro) * ((time - pTime) / (aTime - pTime)))
                                Exit For

                            End If
                        End If
                    Next ' rdx

                End If
            End If

        Catch ex As Exception
            Qro = 0.0
        End Try

        Return Qro
    End Function

    Public Function RunoffRateForCrossSection(ByVal time As Double) As Double
        Dim Qro As Double = RunoffRateForField(time)
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value
            Qro /= furrowsPerSet
        End If
        Return Qro
    End Function

    '*********************************************************************************************************
    ' Function RunoffHydrographTimes() - return Double() array of times in Runoff Hydrograph
    '*********************************************************************************************************
    Public Function RunoffHydrographTimes() As Double()
        Dim qroTimes As Double() = {}
        If (Me.TabulatedRunoffHasData) Then ' Runoff table exists and has data
            Dim qroTable As DataTable = Me.RunoffTableForField ' get table of Times vs. Qro
            qroTimes = GetDoubleColumn(qroTable, nTimeX) ' copy Times column to Double()
        End If
        Return qroTimes
    End Function

    '*********************************************************************************************************
    ' Function RunoffRange() - return the Runoff Hydrograph end-point values
    '
    ' Output(s)     FirstT      - first Time of Runoff
    '               FirstQro    - Runoff Rate at FirstT
    '               LastT       - last Time of Runoff
    '               LastQro     - Runoff Rate at LastT
    '
    ' Returns:      Boolean     - True is Runoff data exists; False if no Runoff data
    '*********************************************************************************************************
    Public Function RunoffRange(ByRef FirstT As Double, ByRef FirstQro As Double, _
                                ByRef LastT As Double, ByRef LastQro As Double) As Boolean
        RunoffRange = False
        FirstT = 0.0
        LastT = 0.0

        Try
            ' Downstream end must be Open for there to be Runoff
            If (mUnit.SystemGeometryRef.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then

                ' Get Runoff Hydrograph
                Dim RunoffTable As DataTable = TabulatedRunoff.Value
                Dim numRows As Integer = RunoffTable.Rows.Count
                If (0 < numRows) Then
                    Dim runoffRow As DataRow
                    Dim rdx As Integer          ' runoff table index
                    Dim T, Qro As Double        ' value from table
                    '
                    ' Scan Runoff Hydrograph for start of runoff (0.0 < Qro)
                    '
                    For rdx = 0 To numRows - 1
                        runoffRow = RunoffTable.Rows(rdx)
                        T = runoffRow.Item(nTimeX)
                        Qro = runoffRow.Item(sRunoffX)

                        If (0.0 < Qro) Then ' Positive Qro
                            If (0 = rdx) Then ' Positive Qro on first measurement
                                FirstT = T
                                FirstQro = Qro
                                LastT = T
                                LastQro = Qro
                                RunoffRange = True
                            Else ' runoff started at previous time
                                runoffRow = RunoffTable.Rows(rdx - 1)
                                T = runoffRow.Item(nTimeX)
                                Qro = runoffRow.Item(sRunoffX)
                                FirstT = T
                                FirstQro = Qro
                                LastT = T
                                LastQro = Qro
                                RunoffRange = True
                            End If

                            Exit For
                        End If
                    Next rdx
                    '
                    ' Continue scanning for end of runoff (Qro <= 0.0)
                    '
                    While rdx < numRows
                        runoffRow = RunoffTable.Rows(rdx)
                        LastT = runoffRow.Item(nTimeX)
                        LastQro = runoffRow.Item(sRunoffX)

                        If (LastQro <= 0.0) Then
                            Exit While
                        End If
                        rdx += 1
                    End While

                End If ' (0 < numRows)
            End If ' OpenEnd

        Catch ex As Exception
            RunoffRange = False
        End Try
    End Function

    Public Function RunoffComplete() As Boolean
        RunoffComplete = True
        If (mUnit.SystemGeometryRef.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            If (RunoffDataAvailable() And Not Me.TabulatedRunoffIncomplete.Value) Then
                RunoffComplete = True
            Else
                RunoffComplete = False
            End If
        End If
    End Function

#End Region

#Region " Applied Volume "

    '*********************************************************************************************************
    ' Function AppliedVolumeForField()        - return volume applied for the field
    ' Function AppliedVolumeForCrossSection() -    "      "      "     "   "  cross section
    '
    ' Input(s):     Time        - ending time for calculation (Tco if none specified)
    '
    ' Returns       Double      - Applied Volume through specified time
    '*********************************************************************************************************
    Public Function AppliedVolumeForField() As Double
        Dim Tco As Double = Cutoff()
        Dim Vapp As Double = AppliedVolumeForField(Tco) ' Vapp through Tco
        Return Vapp
    End Function

    Public Function AppliedVolumeForCrossSection() As Double
        Dim Vapp As Double = AppliedVolumeForField()
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value
            Vapp /= furrowsPerSet
        End If
        Return Vapp
    End Function
    '
    ' Return volume applied through the specified time
    '
    Public Function AppliedVolumeForField(ByVal time As Double) As Double
        Dim Vapp As Double = 0.0

        Select Case InflowMethod.Value

            Case InflowMethods.Surge

                Select Case SurgeStrategy.Value

                    Case SurgeStrategies.UniformTime

                        Dim Tco As Double = SurgeCutoffTime.Value
                        Dim onTime As Double = SurgeOnTime.Value
                        Dim Qin As Double = SurgeInflowRate.Value
                        Dim startTime As Double = 0.0
                        Dim endTime As Double = startTime + onTime

                        While (startTime < Tco)
                            If (endTime < Tco) Then
                                Vapp += (endTime - startTime) * Qin
                            Else
                                Vapp += (Tco - startTime) * Qin
                            End If

                            startTime = endTime + onTime
                            endTime = startTime + onTime
                        End While

                    Case SurgeStrategies.TabulatedTime

                        Dim Tco As Double = SurgeCutoffTime.Value
                        Dim Qin As Double = SurgeInflowRate.Value

                        Dim surgeTable As DataTable = SurgeTimesTable.Value
                        If (surgeTable IsNot Nothing) Then
                            Dim rowCount As Integer = surgeTable.Rows.Count
                            For rdx As Integer = 0 To rowCount - 1
                                Dim surge As DataRow = surgeTable.Rows(rdx) ' values for Left Surge
                                Dim startTime As Double = surge.Item(sStartTimeX)
                                Dim endTime As Double = surge.Item(sEndTimeX)

                                Dim onTime As Double = endTime - startTime

                                If (time <= startTime) Then ' time prior to this Surge; stop
                                    Exit For

                                ElseIf (time <= endTime) Then ' time within this Surge; add partial Surge & Stop
                                    onTime = time - startTime
                                    Vapp += onTime * Qin
                                    Exit For

                                Else ' time after this Surge; add entire Surge
                                    Vapp += onTime * Qin
                                End If
                            Next
                        End If

                End Select

            Case InflowMethods.Cablegation

                ' Calculate Cablegation Inflow Vapp
                Dim inflowTable As DataTable = CablegationInflowTable()
                Vapp = DataTableIntegral(inflowTable, sTimeX, sInflowX, time)

            Case InflowMethods.TabulatedInflow

                ' Calculate Tabulated Inflow Vapp
                Dim inflowTable As DataTable = TabulatedInflow.Value
                Vapp = DataTableIntegral(inflowTable, sTimeX, sInflowX, time)

            Case Else ' Assume InflowMethods.StandardHydrograph

                ' Get the Hydrograph values
                Dim Q As Double = InflowRate.Value
                Dim Qcb As Double = Q * CutbackRateRatio.Value

                Dim Tco As Double = CutoffTime.Value
                Dim Tcb As Double = Tco * CutbackTimeRatio.Value

                Dim _cutbackMethod As CutbackMethods = CType(CutbackMethod.Value, CutbackMethods)
                Dim _cutoffMethod As CutoffMethods = CType(CutoffMethod.Value, CutoffMethods)

                ' Volume Applied is dependent on the Cutback & Cutoff methods
                If (_cutoffMethod = Globals.CutoffMethods.TimeBased) Then

                    Select Case _cutbackMethod

                        Case CutbackMethods.NoCutback
                            If (time <= Tco) Then
                                Vapp = Q * time
                            Else ' Tco < time
                                Vapp = Q * Tco
                            End If

                        Case CutbackMethods.TimeBased
                            If (time <= Tco) Then
                                If (time <= Tcb) Then
                                    Vapp = Q * time
                                Else
                                    Vapp = (Q * Tcb) + (Qcb * (time - Tcb))
                                End If
                            Else ' Tco < time
                                Vapp = (Q * Tcb) + (Qcb * (Tco - Tcb))
                            End If

                    End Select

                End If
        End Select

        Return Vapp
    End Function

    Public Function AppliedVolumeForCrossSection(ByVal time As Double) As Double
        Dim Vapp As Double = AppliedVolumeForField(time)
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim furrowsPerSet As Double = mUnit.SystemGeometryRef.FurrowsPerSet.Value
            Vapp /= furrowsPerSet
        End If
        Return Vapp
    End Function

#End Region

#Region " Applied & Infiltrated Depths / Volumes "
    '
    ' Calculated depths are for basin/border or furrow set; they are not per furrow
    '
    ' Per furrow calculations need to account for the applicable Wetted Perimeter (not done here)
    '
    Public Function AverageInfiltratedDepthForField() As Double
        Dim Vinf As Double = InfiltratedVolumeForField()
        Dim area As Double = mUnit.SystemGeometryRef.FieldArea
        Dim Zavg As Double = Vinf / area
        Return Zavg
    End Function

    Public Function AppliedDepthForField() As Double
        Dim Vapp As Double = AppliedVolumeForField()
        Dim area As Double = mUnit.SystemGeometryRef.FieldArea
        Dim Dapp As Double = Vapp / area
        Return Dapp
    End Function

    Public Function AppliedDepthForField(ByVal time As Double) As Double
        Dim Vapp As Double = AppliedVolumeForField(time)
        Dim area As Double = mUnit.SystemGeometryRef.FieldArea
        Dim Dapp As Double = Vapp / area
        Return Dapp
    End Function
    '
    ' Calculate the Infiltrated Volume from the Applied Volume & the Tabulated Runoff table
    '
    Public Function InfiltratedVolumeForField() As Double
        Dim Vapp As Double = AppliedVolumeForField()
        Dim Vro As Double = RunoffVolumeForField()
        Dim Vz As Double = Vapp - Vro
        Return Vz
    End Function

    Public Function InfiltratedVolumeForCrossSection() As Double
        Dim Vapp As Double = AppliedVolumeForCrossSection()
        Dim Vro As Double = RunoffVolumeForCrossSection()
        Dim Vz As Double = Vapp - Vro
        Return Vz
    End Function

    Public Function InfiltratedDepthForField() As Double
        Dim Vinf As Double = InfiltratedVolumeForField()
        Dim area As Double = mUnit.SystemGeometryRef.FieldArea
        Dim Dinf As Double = Vinf / area
        Return Dinf
    End Function

#End Region

#Region " Advance "
    '
    ' Two-Point table value accessors
    '
    Public Function TwoPointDistance1() As Double
        Dim twoPointTable As DataTable = Me.TwoPointTabulatedAdvance.Value
        TwoPointDistance1 = twoPointTable.Rows(1).Item(nDistanceX)
    End Function

    Public Function TwoPointTime1() As Double
        Dim twoPointTable As DataTable = Me.TwoPointTabulatedAdvance.Value
        TwoPointTime1 = twoPointTable.Rows(1).Item(nTimeX1)
    End Function

    Public Function TwoPointDistance2() As Double
        Dim twoPointTable As DataTable = Me.TwoPointTabulatedAdvance.Value
        TwoPointDistance2 = twoPointTable.Rows(2).Item(nDistanceX)
    End Function

    Public Function TwoPointTime2() As Double
        Dim twoPointTable As DataTable = Me.TwoPointTabulatedAdvance.Value
        TwoPointTime2 = twoPointTable.Rows(2).Item(nTimeX1)
    End Function
    '
    ' Return Advance time (Tadv) for Advance distance (Xadv)
    '
    Public Function Tadv(ByVal Xadv As Double) As Double
        Tadv = 0.0

        If (Xadv <= 0.0) Then ' no advance distance
            Exit Function
        End If

        Try
            Dim advTable As DataTable = Me.TabulatedAdvance.Value
            If (advTable IsNot Nothing) Then
                Dim rowCount As Integer = advTable.Rows.Count
                If (0 < rowCount) Then
                    Dim advRow As DataRow = advTable.Rows(0)
                    Dim X0 As Double = advRow.Item(nDistanceX)
                    Dim T0 As Double = advRow.Item(nTimeX1)

                    If (Xadv <= X0) Then ' prior to 1st entry in table
                        Dim ratio As Double = Xadv / X0
                        Tadv = ratio * T0
                        Exit Try
                    End If

                    Dim X1, T1 As Double
                    For rdx As Integer = 1 To rowCount - 1
                        advRow = advTable.Rows(rdx)
                        X1 = advRow.Item(nDistanceX)
                        T1 = advRow.Item(nTimeX1)

                        If (Xadv <= X1) Then
                            Dim ratio As Double = (Xadv - X0) / (X1 - X0)
                            Tadv = T0 + ratio * (T1 - T0)
                            Exit Try
                        End If

                        X0 = X1
                        T0 = T1
                    Next rdx

                    Tadv = T1

                End If
            End If

        Catch ex As Exception
            Tadv = 0.0
        End Try

    End Function
    '
    ' Return Advance distance (Xadv) for Advance time (Tadv)
    '
    Public Function Xadv(ByVal Tadv As Double) As Double
        Xadv = 0.0

        Try
            Dim advTable As DataTable = Me.TabulatedAdvance.Value
            If (advTable IsNot Nothing) Then
                Dim rowCount As Integer = advTable.Rows.Count
                If (0 < rowCount) Then
                    Dim advRow As DataRow = advTable.Rows(0)
                    Dim X0 As Double = advRow.Item(sDistanceX)
                    Dim T0 As Double = advRow.Item(sTimeX)

                    If (Tadv <= T0) Then
                        Xadv = X0
                        Exit Try
                    End If

                    Dim X1, T1 As Double
                    For rdx As Integer = 1 To rowCount - 1
                        advRow = advTable.Rows(rdx)
                        X1 = advRow.Item(sDistanceX)
                        T1 = advRow.Item(sTimeX)

                        If (Tadv <= T1) Then
                            Dim ratio As Double = (Tadv - T0) / (T1 - T0)
                            Xadv = X0 + ratio * (X1 - X0)
                            Exit Try
                        End If

                        X0 = X1
                        T0 = T1
                    Next rdx

                    Xadv = X1

                End If
            End If

        Catch ex As Exception
            Xadv = 0.0
        End Try

    End Function
    '
    ' Calculate Advance curve's Power-Law parameters (p & r) using Inflow Management's Advance Table
    '
    Public Function PowerAdvancePandR(ByRef p As Double, ByRef r As Double) As Boolean

        Dim advTable As DataTable = Nothing
        If (mUnit.EventCriteriaRef IsNot Nothing) Then
            If (mUnit.EventCriteriaRef.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                advTable = Me.TwoPointTabulatedAdvance.Value
            Else
                If (Me.TabulatedAdvanceHasData) Then
                    advTable = Me.TabulatedAdvance.Value
                End If
            End If

            PowerAdvancePandR = Utilities.PowerAdvancePandR(advTable, p, r)
        End If

    End Function
    '
    ' Calculate tabulated Advance curve's Power-Law parameters (p & r) using AMOEBA fit
    '
    Public Function AmoebaAdvancePandR(ByRef p As Double, ByRef r As Double) As Boolean

        Dim advTable As DataTable = Nothing
        If (mUnit.EventCriteriaRef IsNot Nothing) Then
            If (mUnit.EventCriteriaRef.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
                advTable = Me.TwoPointTabulatedAdvance.Value
            Else
                If (Me.TabulatedAdvanceHasData) Then
                    advTable = Me.TabulatedAdvance.Value
                End If
            End If

            AmoebaAdvancePandR = Utilities.AmoebaAdvancePandR(advTable, p, r)
        End If

    End Function
    '
    ' Estimate Post-Advance distance Xpa for Post-Advance time Tpa
    '
    Public Function Xpa(ByVal Tpa As Double) As Double
        Dim p As Double = Me.AdvanceP.Value
        Dim r As Double = Me.AdvanceR.Value
        Xpa = p * Tpa ^ r
    End Function
    '
    ' Estimate Post-Advance time Tpa for Post-Advance distance Xpa
    '
    Public Function Tpa(ByVal Xpa As Double) As Double
        Dim p As Double = Me.AdvanceP.Value
        Dim r As Double = Me.AdvanceR.Value
        Tpa = (Xpa / p) ^ (1 / r)
    End Function
    '
    ' Return Time when Advance reached the end of the field
    '
    Public Function TL() As Double
        TL = Double.NaN

        Dim L As Double = mUnit.SystemGeometryRef.Length.Value

        Try
            Dim advTable As DataTable = Me.TabulatedAdvance.Value
            If (advTable IsNot Nothing) Then
                If (advTable.Rows IsNot Nothing) Then
                    Dim rowCount As Integer = advTable.Rows.Count
                    If (0 < rowCount) Then
                        Dim advRow As DataRow = advTable.Rows(rowCount - 1)
                        Dim Xadv As Double = advRow.Item(sDistanceX)
                        If (Xadv >= L) Then
                            TL = advRow.Item(sTimeX)
                            Exit Function
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            TL = Double.NaN
        End Try

    End Function

    '*********************************************************************************************************
    ' Function AdvanceProfileTimes()    - return Double() array of times in Advance Profile
    ' Function MaxAdvanceTime()         - return maximum Advance time
    ' Function MaxAdvanceDistance()     -    "      "       "    distance
    '*********************************************************************************************************
    Public Function AdvanceProfileTimes() As Double()
        Dim advTimes As Double() = {}
        If (Me.TabulatedAdvanceHasData) Then ' Advance table exists and contains data
            Dim advTable As DataTable = Me.TabulatedAdvance.Value ' get table of Distances vs. Times
            advTimes = GetDoubleColumn(advTable, nTimeX1) ' copy Times column to Double()
        End If
        Return advTimes
    End Function

    Public Function MaxAdvanceTime() As Double
        MaxAdvanceTime = Double.MaxValue
        If (Me.AdvanceDataAvailable) Then
            Dim advanceProfile As DataTable = Me.TabulatedAdvance.Value
            MaxAdvanceTime = DataColumnMax(advanceProfile, sTimeX)
        End If
    End Function

    Public Function MaxAdvanceDistance() As Double
        MaxAdvanceDistance = Double.MaxValue
        If (Me.AdvanceDataAvailable) Then
            Dim advanceProfile As DataTable = Me.TabulatedAdvance.Value
            MaxAdvanceDistance = DataColumnMax(advanceProfile, sDistanceX)
        End If
    End Function

#End Region

#Region " Recession "

    '*********************************************************************************************************
    ' Function RecessionProfileTimes()  - return Double() array of times in Recession Profile
    ' Function MinRecessionTime()       - return minimum Recession time
    ' Function MaxRecessionTime()       -    "   maximum     "       "
    ' Function MinRecessionDistance()   -    "   minimum     "    distance
    ' Function MaxRecessionDistance()   -    "   maximum     "       "
    '*********************************************************************************************************
    Public Function RecessionProfileTimes() As Double()
        Dim recTimes As Double() = {}
        If (Me.RecessionDataAvailable) Then ' Recession table exists and contains data
            Dim recTable As DataTable = Me.TabulatedRecession.Value ' get table of Distances vs. Times
            recTimes = GetDoubleColumn(recTable, nTimeX1) ' copy Times column to Double()
        End If
        Return recTimes
    End Function

    Public Function MinRecessionTime() As Double
        MinRecessionTime = 0.0
        If (Me.RecessionDataAvailable) Then
            Dim recTable As DataTable = Me.TabulatedRecession.Value
            MinRecessionTime = DataColumnMin(recTable, sTimeX)
        End If
    End Function

    Public Function MaxRecessionTime() As Double
        MaxRecessionTime = Double.MaxValue
        If (Me.RecessionDataAvailable) Then
            Dim recTable As DataTable = Me.TabulatedRecession.Value
            MaxRecessionTime = DataColumnMax(recTable, sTimeX)
        End If
    End Function

    Public Function MinRecessionDistance() As Double
        MinRecessionDistance = 0.0
        If (Me.RecessionDataAvailable) Then
            Dim recTable As DataTable = Me.TabulatedRecession.Value
            MinRecessionDistance = DataColumnMin(recTable, sDistanceX)
        End If
    End Function

    Public Function MaxRecessionDistance() As Double
        MaxRecessionDistance = Double.MaxValue
        If (Me.RecessionDataAvailable) Then
            Dim recTable As DataTable = Me.TabulatedRecession.Value
            MaxRecessionDistance = DataColumnMax(recTable, sDistanceX)
        End If
    End Function

    Public Function UpstreamRecessionTime() As Double
        UpstreamRecessionTime = Double.MaxValue
        If (Me.RecessionDataAvailable) Then
            Dim recTable As DataTable = Me.TabulatedRecession.Value
            Dim upstreamRecRow As DataRow = recTable.Rows(0)
            UpstreamRecessionTime = upstreamRecRow.Item(nTimeX1)
        End If

    End Function

#End Region

#Region " Opportunity Time "

    '*********************************************************************************************************
    ' Function CalcOpportunityTimes() - calculate Opportunity Times table from Advance & Recession tables
    '
    ' Input(s):     MaxRecTime  - (optional) maximum Recession time
    '
    ' Returns:      DataTable   - Opportunity Times (Dists vs. Times)
    '
    ' Notes - Opportunity Times table will have an entry for every unique distance in either the Advance or
    '         the Recession table
    '
    Public Function CalcOpportunityTimes(Optional ByVal MaxRecTime As Double = Double.MaxValue) As DataTable

        ' Get the Advance & Recession tables
        Dim advTable As DataTable = Me.TabulatedAdvance.Value
        Dim recTable As DataTable = Me.TabulatedRecession.Value

        ' Must have an Advance table
        If (advTable Is Nothing) Then
            Return Nothing
        ElseIf (advTable.Rows.Count < 1) Then
            Return Nothing
        End If

        ' Index and row count for Advance table
        Dim advIdx As Integer = 0
        Dim advRows As Integer = advTable.Rows.Count

        ' Index and row count for Recession table
        Dim recIdx As Integer = 0
        Dim recRows As Integer = 0
        If (recTable IsNot Nothing) Then
            recRows = recTable.Rows.Count
        End If

        ' Create the Opportunity Time table
        Dim oppTable As DataTable = New DataTable(sOpportunityTime)
        oppTable.Columns.Add(sDistanceX, GetType(Double))
        oppTable.Columns.Add(sTimeX, GetType(Double))

        If (0 < recRows) Then ' there are recession dists/times
            ' Opportunity Time table gets an entry for each unique distance in either
            ' the Advance or Recession table
            While ((advIdx < advRows) And (recIdx < recRows)) ' prevent beyond end-of-table accesses

                Dim advDist As Double = CDbl(advTable.Rows(advIdx).Item(sDistanceX))
                Dim advTime As Double = CDbl(advTable.Rows(advIdx).Item(sTimeX))

                Dim recDist As Double = CDbl(recTable.Rows(recIdx).Item(sDistanceX))
                Dim recTime As Double = CDbl(recTable.Rows(recIdx).Item(sTimeX))

                Dim oppDist As Double = advDist

                Dim more As Boolean = False

                If (advDist < recDist) Then ' Advance distance before Recession distance; use it

                    If (advIdx < advRows - 1) Then ' not at end of Advance table
                        oppDist = advDist   ' use Advance distance as Opportunity distance

                        advIdx += 1         ' advance Advance index for next pass
                        more = True

                        ' If distances are close; assume they are the same
                        If (ThisClose(advDist, recDist, 0.1)) Then
                            If (recIdx < recRows - 1) Then
                                recIdx += 1
                            End If
                        End If

                    Else ' at end of Advance table
                        oppDist = recDist   ' use Recession distance as Opportunity distance

                        If (recIdx < recRows - 1) Then
                            recIdx += 1
                            more = True
                        End If
                    End If

                    ' Find corresponding Recession time
                    recTime = FindTimeAtDistance(recTable, oppDist)

                ElseIf (recDist < advDist) Then ' Recession distance before Advance distance; use it

                    If (recIdx < recRows - 1) Then ' not at end of Recession table
                        oppDist = recDist   ' use Recession distance as Opportunity distance

                        recIdx += 1         ' advance Recession index for next pass
                        more = True

                        ' If distances are close; assume they are the same
                        If (ThisClose(advDist, recDist, 0.1)) Then
                            If (advIdx < advRows - 1) Then
                                advIdx += 1
                            End If
                        End If

                    Else ' at end of Recession table
                        oppDist = advDist   ' use Advance distance as Opportunity distance

                        If (advIdx < advRows - 1) Then
                            advIdx += 1
                            more = True
                        End If
                    End If

                    ' Find corresponding Advance time
                    advTime = FindTimeAtDistance(advTable, oppDist)

                Else
                    ' Proceed to next Advance distance
                    If (advIdx < advRows - 1) Then
                        advIdx += 1
                        more = True
                    End If

                    ' Proceed to next Recession distance
                    If (recIdx < recRows - 1) Then
                        recIdx += 1
                        more = True
                    End If
                End If

                ' Build new row for Opportunity Time
                Dim oppTime As Double = Math.Max((Math.Min(MaxRecTime, recTime) - advTime), 0.0)
                Dim oppRow As DataRow = oppTable.NewRow

                oppRow.Item(sDistanceX) = oppDist
                oppRow.Item(sTimeX) = oppTime

                oppTable.Rows.Add(oppRow)

                If Not (more) Then
                    Exit While
                End If

            End While

        Else ' no recession table
            ' Opportunity Time table gets an entry for each distance in the Advance table
            While (advIdx < advRows)

                Dim advDist As Double = CDbl(advTable.Rows(advIdx).Item(sDistanceX))
                Dim advTime As Double = CDbl(advTable.Rows(advIdx).Item(sTimeX))
                Dim oppTime As Double = Math.Max((MaxRecTime - advTime), 0.0)

                Dim oppRow As DataRow = oppTable.NewRow

                oppRow.Item(sDistanceX) = advDist
                oppRow.Item(sTimeX) = oppTime

                oppTable.Rows.Add(oppRow)

                advIdx += 1
            End While
        End If

        Return oppTable

    End Function

    '*********************************************************************************************************
    ' Function OpportunityTimeProfile()  - generate Opportunity Time Profile DataTable
    ' Function OpportunityTimeProfiles() - generate Opportunity Time Profiles DataSet
    '
    ' Input(s):     AdvanceTable    - Advance Times (time vs. distance) DataTable
    '               Time            - Time for the Profile
    '*********************************************************************************************************
    Public Function OpportunityTimeProfile(ByVal AdvanceTable As DataTable, ByVal Time As Double) As DataTable
        OpportunityTimeProfile = Nothing

        If (AdvanceTable IsNot Nothing) Then

            If (0 < Time) Then

                ' Flow Elevation Profiles are built from scratch
                Dim tableName As String = TimeString(Time)
                OpportunityTimeProfile = New DataTable(tableName)
                OpportunityTimeProfile.Columns.Add(sDistanceX, GetType(Double))
                OpportunityTimeProfile.Columns.Add(sOpportunityTime, GetType(Double))
                OpportunityTimeProfile.ExtendedProperties.Add(sTimeX, Time)

                ' Hydrograph should have DataRow for each Station's Flow Depths table
                For Each advRow As DataRow In AdvanceTable.Rows
                    Dim advDist As Double = advRow.Item(sDistanceX)
                    Dim advTime As Double = advRow.Item(sTimeX)

                    Dim oppTime As Double = 0.0
                    If (advTime < Time) Then
                        oppTime = Time - advTime
                    End If

                    Dim oppRow As DataRow = OpportunityTimeProfile.NewRow
                    oppRow.Item(sDistanceX) = advDist
                    oppRow.Item(sOpportunityTime) = oppTime
                    OpportunityTimeProfile.Rows.Add(oppRow)
                Next advRow

            End If
        End If

    End Function

    Public Function OpportunityTimeProfiles(ByVal AdvanceTable As DataTable, _
                                            ByVal Times() As Double) As DataSet
        OpportunityTimeProfiles = Nothing

        If (AdvanceTable IsNot Nothing) Then

            ' Surface Flow Elevation Profiles are built from scratch
            OpportunityTimeProfiles = New DataSet("Opportunity Time Profiles")

            ' Add profile for each specified time
            For Each time As Double In Times
                Dim profile As DataTable = Me.OpportunityTimeProfile(AdvanceTable, time)
                AddDataTableToDataSet(profile, OpportunityTimeProfiles)
            Next time
        End If

    End Function

#End Region

#Region " Station Measurements "

    '*********************************************************************************************************
    ' Selected Station properties
    '*********************************************************************************************************
    Public Function SelectedStationDataRow() As DataRow
        SelectedStationDataRow = Nothing
        Try
            Dim selStation As Integer = Me.SelectedStation.Value
            Dim stations As DataTable = Me.MeasurementStations.Value
            SelectedStationDataRow = stations.Rows(selStation)
        Catch ex As Exception
            SelectedStationDataRow = Nothing
        End Try
    End Function

    Public Function SelectedStationDistance() As Double
        SelectedStationDistance = 0.0
        Try
            SelectedStationDistance = SelectedStationDataRow.Item(sDistanceX)
        Catch ex As Exception
            SelectedStationDistance = 0.0
        End Try
    End Function

    Public Function IsSelectedStationDist(ByVal dist As Double) As Boolean
        IsSelectedStationDist = (dist = Me.SelectedStationDistance())
    End Function

    Public Function SelectedStationElevation() As Double
        SelectedStationElevation = 0.0
        Try
            SelectedStationElevation = SelectedStationDataRow.Item(sElevationX)
        Catch ex As Exception
            SelectedStationElevation = 0.0
        End Try
    End Function

    Public Function SelectedStationAdvance() As Double
        SelectedStationAdvance = Double.NaN
        Try
            Dim selStation As Integer = Me.SelectedStation.Value
            Dim stations As DataTable = Me.TabulatedAdvance.Value
            SelectedStationAdvance = stations.Rows(selStation).Item(sTimeX)
        Catch ex As Exception
            SelectedStationAdvance = Double.NaN
        End Try
    End Function

    Public Function IsSelectedStationAdvance(ByVal AdvTime As Double) As Boolean
        IsSelectedStationAdvance = (AdvTime = SelectedStationAdvance())
    End Function

    Public Function SelectedStationRecession() As Double
        SelectedStationRecession = Double.NaN
        Try
            Dim selStation As Integer = Me.SelectedStation.Value
            Dim stations As DataTable = Me.TabulatedAdvance.Value
            SelectedStationRecession = stations.Rows(selStation).Item(sTimeX)
        Catch ex As Exception
            SelectedStationRecession = Double.NaN
        End Try
    End Function

    '*********************************************************************************************************
    ' Function EarliestFlowDepthHydrographFinalTime() - find earliest flow depth hydrograph final time (tVyF)
    '
    ' Note - the latest time that flow depth hydrographs can be used to determine a surface flow volume (Vy)
    '        is the earliest final time recorded for each individual flow depth hydrograph.
    '*********************************************************************************************************
    Public Function EarliestFlowDepthHydrographFinalTime() As Double
        EarliestFlowDepthHydrographFinalTime = Double.MaxValue

        Dim flowDepthHydrographs As DataSet = Me.StationsFlowDepths.Value
        If (flowDepthHydrographs IsNot Nothing) Then
            If (flowDepthHydrographs.Tables IsNot Nothing) Then

                ' Scan each flow depth hydrograph checking its final recorded time
                For Each flowDepthHydrograph As DataTable In flowDepthHydrographs.Tables
                    If (flowDepthHydrograph.Rows IsNot Nothing) Then
                        Dim rowCount As Integer = flowDepthHydrograph.Rows.Count
                        If (0 < rowCount) Then
                            Dim finalRow As DataRow = flowDepthHydrograph.Rows(rowCount - 1)
                            Dim finalTime As Double = finalRow.Item(nTimeX)
                            If ((0.0 < finalTime) And (finalTime < EarliestFlowDepthHydrographFinalTime)) Then
                                ' This final measured time is earlier than the previous one; save it
                                EarliestFlowDepthHydrographFinalTime = finalTime
                            End If
                        End If
                    End If
                Next flowDepthHydrograph

            End If
        End If
    End Function

    '*********************************************************************************************************
    ' Function EarliestFlowDepthHydrographRecessionTime() - find earliest recorded recession time (tRi)
    '
    ' Input(s):     Adjusted        - whether or not to use the flow level adjusted values or not
    '
    ' Note - once recession occurs at a Station's surface flow depth, that station can no longer be used for
    '        volume balance calcuations.
    '*********************************************************************************************************
    Public Function EarliestFlowDepthHydrographRecessionTime(ByVal Adjusted As Boolean) As Double
        EarliestFlowDepthHydrographRecessionTime = Double.MaxValue

        Dim flowDepthHydrographs As DataSet = Me.StationsFlowDepths.Value
        If (flowDepthHydrographs IsNot Nothing) Then
            If (flowDepthHydrographs.Tables IsNot Nothing) Then

                For Each flowDepthHydrograph As DataTable In flowDepthHydrographs.Tables
                    If (flowDepthHydrograph.Rows IsNot Nothing) Then

                        Dim rowCount As Integer = flowDepthHydrograph.Rows.Count
                        Dim flowDepthRow As DataRow = Nothing
                        Dim flowTime, flowDepth As Double

                        ' Find first non-zero depth row
                        Dim idx As Integer = 0
                        While (idx < rowCount)
                            flowDepthRow = flowDepthHydrograph.Rows(idx)
                            flowDepth = flowDepthRow.Item(sDepthX)
                            If (0.0 < flowDepth) Then ' flow has started
                                Exit While
                            End If
                            idx += 1
                        End While

                        ' Find next recession point
                        While (idx < rowCount)
                            flowDepthRow = flowDepthHydrograph.Rows(idx)
                            flowDepth = flowDepthRow.Item(sDepthX)
                            If (flowDepth = 0.0) Then ' Recession
                                flowTime = flowDepthRow.Item(nTimeX)
                                If (EarliestFlowDepthHydrographRecessionTime > flowTime) Then
                                    ' This recession time is earlier than the previous on; save it
                                    EarliestFlowDepthHydrographRecessionTime = flowTime
                                End If
                                Exit While
                            End If
                            idx += 1
                        End While

                    End If
                Next flowDepthHydrograph

            End If
        End If
    End Function

    '*********************************************************************************************************
    ' Function FinalUpstreamFlowDepthTime - return the time of the final flow depth measurement at the
    '                                       upstream end-of-field
    '
    ' Input(s):     Adjusted        - whether or not to use the flow level adjusted values or not
    '*********************************************************************************************************
    Public Function FinalUpstreamFlowDepthTime(ByVal Adjusted As Boolean) As Double
        FinalUpstreamFlowDepthTime = Me.Cutoff

        Try
            Dim depthHydrographs As DataSet = Me.StationsFlowDepths.Value
            Dim depthHydrograph As DataTable = depthHydrographs.Tables(0)
            Dim rowCount As Integer = depthHydrograph.Rows.Count
            Dim finalRow As DataRow = depthHydrograph.Rows(rowCount - 1)

            FinalUpstreamFlowDepthTime = finalRow.Item(nTimeX)

        Catch ex As Exception
            FinalUpstreamFlowDepthTime = Me.Tco
        End Try
    End Function

    '*********************************************************************************************************
    ' Function StationZaDepthProfile()     - generate Measurement Stations' Za Depth Profile
    ' Function StationZaElevationProfile() - generate Measurement Stations' Za Elevation Profile
    '*********************************************************************************************************
    Public Function StationZaDepthProfile() As DataTable
        StationZaDepthProfile = Nothing

        ' Get Measurement Stations data (X, H, Hadj)
        Dim stations As DataTable = Me.MeasurementStations.Value
        If (stations IsNot Nothing) Then

            ' Create station elevation table (Za)
            StationZaDepthProfile = New DataTable("Za")
            StationZaDepthProfile.Columns.Add(sDistanceX, GetType(Double))
            StationZaDepthProfile.Columns.Add(sDepthX, GetType(Double))

            ' Za Profile folds Station's Elevation Adjustment into the Elevation
            For Each stationRow As DataRow In stations.Rows
                Dim ZaRow As DataRow = StationZaDepthProfile.NewRow
                ZaRow.Item(sDistanceX) = stationRow.Item(sDistanceX)
                ZaRow.Item(sDepthX) = 0.0
                StationZaDepthProfile.Rows.Add(ZaRow)
            Next stationRow

        End If

    End Function

    Public Function StationZaElevationProfile() As DataTable
        StationZaElevationProfile = Nothing

        ' Get Measurement Stations data (X, H, Hadj)
        Dim stations As DataTable = Me.MeasurementStations.Value
        If (stations IsNot Nothing) Then

            ' Create station elevation table (Za)
            StationZaElevationProfile = New DataTable("Za")
            StationZaElevationProfile.Columns.Add(sDistanceX, GetType(Double))
            StationZaElevationProfile.Columns.Add(sElevationX, GetType(Double))

            ' Za Profile folds Station's Elevation Adjustment into the Elevation
            For Each stationRow As DataRow In stations.Rows
                Dim ZaRow As DataRow = StationZaElevationProfile.NewRow
                ZaRow.Item(sDistanceX) = stationRow.Item(sDistanceX)
                ZaRow.Item(sElevationX) = stationRow.Item(sElevationX)

                StationZaElevationProfile.Rows.Add(ZaRow)
            Next stationRow

        End If

    End Function

    '*********************************************************************************************************
    ' FlowDepthsMeasuredAndUsed() - are Flow Depth Hydrographs available for volume balance calculations?
    '*********************************************************************************************************
    Public Function FlowDepthsMeasuredAndUsed() As Boolean
        FlowDepthsMeasuredAndUsed = False

        If (Me.FlowDepthsDataAvailable) Then ' Flow Depths have been measured & entered
            If (Me.FlowDepthsUsed.Value) Then ' User said to use Flow Depths for VB calculations
                FlowDepthsMeasuredAndUsed = True
            End If
        End If
    End Function

#End Region

#Region " Surface Flow "

    '*********************************************************************************************************
    ' Function FlowElevationProfile()  - generate Flow Elevation Profile DataTable
    ' Function FlowElevationProfiles() - generate Flow Elevation Profiles DataSet
    '
    ' Input(s):     FlowDepthHydrographs    - DataSet of Station Flow Depth Hydrograph (one per Station)
    '               Time                    - Time for the Hydrograph
    '               StationZaProfile        - DataTable of Station elevations
    '*********************************************************************************************************
    Public Function FlowElevationProfile(ByVal FlowDepthHydrographs As DataSet, ByVal Time As Double, _
                                         ByVal StationZaProfile As DataTable) As DataTable
        FlowElevationProfile = Nothing

        If (FlowDepthHydrographs IsNot Nothing) Then
            If (FlowDepthHydrographs.Tables IsNot Nothing) Then

                If (0 < Time) Then

                    ' Flow Elevation Profiles are built from scratch
                    Dim tableName As String = TimeString(Time)
                    FlowElevationProfile = New DataTable(tableName)
                    FlowElevationProfile.ExtendedProperties.Add(sTimeX, Time)
                    FlowElevationProfile.Columns.Add(sDistanceX, GetType(Double))
                    FlowElevationProfile.Columns.Add(sElevationX, GetType(Double))

                    ' Hydrograph should have DataRow for each Station's Flow Depths table
                    For Each flowTable As DataTable In FlowDepthHydrographs.Tables

                        If (2 < flowTable.Rows.Count) Then
                            ' Get Distance and Flow Depth from Flow Depths table
                            Dim flowDist As Double = flowTable.ExtendedProperties(sDistanceX)
                            Dim flowElev As Double = DataColumnValue(flowTable, nTimeX, Time, nDepthX1)

                            If (StationZaProfile IsNot Nothing) Then

                                ' Add Station Elevation from Za Table to Flow Depth to get Flow Elevation
                                For Each ZaRow As DataRow In StationZaProfile.Rows

                                    Dim ZaDist As Double = ZaRow.Item(sDistanceX)
                                    Dim ZaElev As Double = ZaRow.Item(sElevationX)

                                    If (ZaDist = flowDist) Then ' Station table corresponds to Flow Depth table
                                        flowElev += ZaElev  ' Add surface elevation to flow depth
                                        Exit For
                                    End If

                                Next ZaRow

                            End If

                            Dim profRow As DataRow = FlowElevationProfile.NewRow
                            profRow.Item(sDistanceX) = flowDist
                            profRow.Item(sElevationX) = flowElev
                            FlowElevationProfile.Rows.Add(profRow)
                        End If

                    Next flowTable

                End If ' (0 < HydroTime)
            End If
        End If

    End Function

    Public Function FlowElevationProfiles(ByVal FlowDepthHydrographs As DataSet, ByVal Times As Double()) As DataSet
        FlowElevationProfiles = Nothing

        If (FlowDepthHydrographs IsNot Nothing) Then
            If (FlowDepthHydrographs.Tables IsNot Nothing) Then

                ' Flow Elevation Profiles are built from scratch
                FlowElevationProfiles = New DataSet("Water Surface Profiles")

                ' Start with station elevation table (Za)
                Dim ZaTable As DataTable = Me.StationZaElevationProfile()
                If (ZaTable IsNot Nothing) Then
                    FlowElevationProfiles.Tables.Add(ZaTable)
                End If

                ' Add profile for each specified time
                For Each Time As Double In Times
                    Dim profile As DataTable = Me.FlowElevationProfile(FlowDepthHydrographs, Time, ZaTable)
                    AddDataTableToDataSet(profile, FlowElevationProfiles)
                Next Time
            End If
        End If

    End Function

    '*********************************************************************************************************
    ' Function FlowDepthProfile()  - generate Flow Depth Profile DataTable
    ' Function FlowDepthProfiles() - generate Flow Depth Profiles DataSet
    '
    ' Input(s):     FlowDepthHydrographs    - DataSet of Station Flow Depth Hydrograph (one per Station)
    '               Time                    - Time for the Hydrograph
    '*********************************************************************************************************
    Public Function FlowDepthProfile(ByVal FlowDepthHydrographs As DataSet, ByVal Time As Double) As DataTable
        FlowDepthProfile = Nothing

        If (FlowDepthHydrographs IsNot Nothing) Then
            If (FlowDepthHydrographs.Tables IsNot Nothing) Then

                If (0 < Time) Then

                    ' Flow Elevation Profiles are built from scratch
                    Dim tableName As String = TimeString(Time)
                    FlowDepthProfile = New DataTable(tableName)
                    FlowDepthProfile.ExtendedProperties.Add(sTimeX, Time)
                    FlowDepthProfile.Columns.Add(sDistanceX, GetType(Double))
                    FlowDepthProfile.Columns.Add(sDepthX, GetType(Double))

                    ' Hydrograph should have DataRow for each Station's Flow Depths table
                    For Each flowTable As DataTable In FlowDepthHydrographs.Tables

                        If (2 < flowTable.Rows.Count) Then ' hydrograph is sufficient
                            ' Get Distance and Flow Depth from Flow Depths table
                            Dim flowDist As Double = flowTable.ExtendedProperties(sDistanceX)
                            Dim flowDepth As Double = DataColumnValue(flowTable, nTimeX, Time, nDepthX1)

                            Dim profRow As DataRow = FlowDepthProfile.NewRow
                            profRow.Item(sDistanceX) = flowDist
                            profRow.Item(sDepthX) = flowDepth
                            FlowDepthProfile.Rows.Add(profRow)
                        End If

                    Next flowTable

                End If
            End If
        End If

    End Function

    Public Function FlowDepthProfiles(ByVal FlowDepthHydrographs As DataSet, ByVal Times As Double()) As DataSet
        FlowDepthProfiles = Nothing

        If (FlowDepthHydrographs IsNot Nothing) Then
            If (FlowDepthHydrographs.Tables IsNot Nothing) Then

                ' Flow Depth Profiles are built from scratch
                FlowDepthProfiles = New DataSet("Flow Depth Profiles")

                ' Start with bottom depth table (Za)
                Dim ZaTable As DataTable = Me.StationZaDepthProfile()
                If (ZaTable IsNot Nothing) Then
                    FlowDepthProfiles.Tables.Add(ZaTable)
                End If

                ' Add profile for each requested time
                For Each Time As Double In Times
                    Dim profile As DataTable = Me.FlowDepthProfile(FlowDepthHydrographs, Time)
                    AddDataTableToDataSet(profile, FlowDepthProfiles)
                Next Time
            End If
        End If

    End Function

    '*********************************************************************************************************
    ' Function FlowDepthHydrographsAdvanceTimes() - Double() array Advance times from Flow Depth Hydrographs
    '*********************************************************************************************************
    Public Function FlowDepthHydrographsAdvanceTimes() As Double()
        Dim fdTimes As Double() = {}
        If (Me.FlowDepthsDataAvailable) Then
            Dim fdSet As DataSet = Me.StationsFlowDepths.Value
            ReDim fdTimes(fdSet.Tables.Count)
            For tdx As Integer = 0 To fdSet.Tables.Count - 1
                Dim tdTable As DataTable = fdSet.Tables(tdx)
                Dim tdRow As DataRow = tdTable.Rows(0)
                fdTimes(tdx) = tdRow.Item(nTimeX)
            Next tdx
        End If
        Return fdTimes
    End Function

#End Region

#Region " Surface Volumes "

    '*********************************************************************************************************
    ' Function MeasuredSurfaceVolumeTable() - build measured Surface Volumes DataTable for Stations
    '*********************************************************************************************************
    Public Function MeasuredSurfaceVolumeTable() As DataTable
        MeasuredSurfaceVolumeTable = New DataTable("Measured Surface Volumes")
        MeasuredSurfaceVolumeTable.Columns.Add(sAdvanceX, GetType(Double))
        MeasuredSurfaceVolumeTable.Columns.Add(sVy, GetType(Double))

        Dim advanceTable As DataTable = Me.TabulatedAdvance.Value
        Dim stationHydrographs As DataSet = StationsFlowDepths.Value

        If ((advanceTable IsNot Nothing) And _
            (stationHydrographs IsNot Nothing)) Then

            Dim StationCount As Integer = advanceTable.Rows.Count

            If (StationCount = stationHydrographs.Tables.Count) Then

                ' Skip Station at head of field; one entry for all other Stations
                For sdx As Integer = 1 To StationCount - 1
                    Dim advRow As DataRow = advanceTable.Rows(sdx)
                    Dim Xa As Double = advRow.Item(sDistanceX)
                    Dim Tadv As Double = advRow.Item(sTimeX)

                    ' Measured Surface Volume at Station's advance time
                    Dim Vy As Double = MeasuredSurfaceVolume(Tadv, stationHydrographs)

                    ' Save values in Station's Surface Volume DataRow
                    Dim VyRow As DataRow = MeasuredSurfaceVolumeTable.NewRow
                    VyRow.Item(0) = Xa
                    VyRow.Item(1) = Vy
                    MeasuredSurfaceVolumeTable.Rows.Add(VyRow)

                Next sdx
            Else
                Debug.Assert(False)
            End If

        End If

    End Function

    '*********************************************************************************************************
    ' Function MeasuredSurfaceVolume() - calculate the Surface Volume at a specified time using the
    '                                    measured depth hydrographs
    '
    ' Input(s):     Time                - time at which to calculate the Surface Volume
    '               Depth Hydrographs   - DataSet of field measured depth hydrographs
    '
    ' Returns:      Double              - Measured Surface Volume at Time
    '*********************************************************************************************************
    Public Function MeasuredSurfaceVolume(ByVal Time As Double, ByVal DepthHydrographs As DataSet) As Double
        MeasuredSurfaceVolume = 0.0

        Dim mSystemGeometry As SystemGeometry = mUnit.SystemGeometryRef

        If (DepthHydrographs IsNot Nothing) Then
            If (DepthHydrographs.Tables IsNot Nothing) Then

                Dim depthProfile As DataTable = Me.FlowDepthProfile(DepthHydrographs, Time)
                If (depthProfile IsNot Nothing) Then

                    Dim maxAdvTime As Double = Me.MaxAdvanceTime

                    Dim rowCount As Integer = depthProfile.Rows.Count

                    If (1 < rowCount) Then

                        Dim X1 As Double = depthProfile.Rows(0).Item(sDistanceX)
                        Dim Y1 As Double = depthProfile.Rows(0).Item(sDepthX)
                        Dim AY1 As Double = mSystemGeometry.FlowArea(Y1)

                        For rdx As Integer = 1 To rowCount - 1

                            Dim X2 As Double = depthProfile.Rows(rdx).Item(sDistanceX)
                            Dim Y2 As Double = depthProfile.Rows(rdx).Item(sDepthX)
                            Dim DX As Double = (X2 - X1)
                            Dim AY2 As Double = mSystemGeometry.FlowArea(Y2)

                            If (Time <= maxAdvTime) Then ' In Advance stage; check for tip cell
                                If ((0.0 < Y1) And (0.0 = Y2)) Then ' tip cell
                                    Dim Qin As Double = Me.AverageInflowRate(Me.Tco)
                                    Dim W As Double = mSystemGeometry.WidthForCrossSection
                                    Dim S0 As Double = mSystemGeometry.AverageSlope

                                    Dim SigmaY As Double = mUnit.SigmaY(Qin, X2, W, S0)

                                    DX = X2 / rdx

                                    MeasuredSurfaceVolume += AY1 * DX * SigmaY
                                Else ' not tip cell
                                    MeasuredSurfaceVolume += (AY2 + AY1) * DX / 2.0
                                End If
                            Else ' post Advance
                                MeasuredSurfaceVolume += (AY2 + AY1) * DX / 2.0
                            End If

                            X1 = X2
                            Y1 = Y2
                            AY1 = AY2
                        Next rdx

                    End If
                End If
            End If
        End If

    End Function

    '*********************************************************************************************************
    ' Function PredictedSurfaceVolume() - predict the Surface Volume at a specified time based on a surface
    '                                     shape factor (Sy) and an emperical flow depth power (beta)
    '
    ' Input(s):     Time                - time at which to calculate the Surface Volume
    '               Sy                  - surface shape factor
    '               Beta                - flow depth equation power
    '
    ' Returns:      Double              - Predicted Surface Volume at Time
    '*********************************************************************************************************
    Public Function PredictedSurfaceVolume(ByVal Time As Double, ByVal Sy As Double, ByVal Beta As Double) As Double
        PredictedSurfaceVolume = 0.0

        Dim Tco As Double = Me.Tco

        If (Time < Tco) Then ' Inflow is still occurring

            Dim Qavg As Double = Me.AverageInflowRateForCrossSection(Time)
            Dim Xadv As Double = Me.Xadv(Time)

            ' Upstream flow area
            Dim AY0 As Double = mUnit.UpstreamArea(Qavg, Xadv, Beta)

            ' Surface Volume at Advance time
            PredictedSurfaceVolume = Sy * AY0 * Xadv

        Else

        End If

    End Function

#End Region

#End Region

#Region " Data Validation "

#Region " Inflow "

    Public Enum InflowErrors
        NoError

        NoAppliedVolume         ' General Inflow errors
        TimeNotPositive
        RateNotPositive
        TimeNotValidForVin

        CutoffInvalid           ' Standard Hydrograph errors
        CutbackInvalid

        InvalidTable            ' Tabulated Inflow errors
        FirstTimeNotZero
        FirstRateIsZero
        TimesNotMonotonic
    End Enum

    '*********************************************************************************************************
    ' Function ValidateInflowVolume() - validate inflow table actually represents a positive inflow volume
    '
    ' Returns:      InflowErrors        - Inflow Error enumeration
    '*********************************************************************************************************
    Public Function ValidateInflowVolume() As InflowErrors
        ValidateInflowVolume = InflowErrors.NoError
        Dim Vapp As Double = Me.AppliedVolumeForField
        If (Vapp <= 0.0) Then
            ValidateInflowVolume = InflowErrors.NoAppliedVolume
            Exit Function
        End If
    End Function

    '*********************************************************************************************************
    ' Function ValidateInflowTimeForVin() - validate Vin can be calculated for specified time
    '
    ' Input(s):     Time            - Time to check if Vin can be calculated
    '
    ' Returns:      InflowErrors    - Inflow Error enumeration
    '*********************************************************************************************************
    Public Function ValidateInflowTimeForVin(ByVal Time As Double) As InflowErrors
        ValidateInflowTimeForVin = InflowErrors.NoError

        If (Me.InflowMethod.Value = InflowMethods.TabulatedInflow) Then
            If (Me.TabulatedInflowHasData) Then
                If (Me.TabulatedInflowIncomplete.Value) Then ' Partial Hydrograph
                    Dim Tco As Double = Me.Tco
                    If ((Time < 0.0) Or (Tco < Time)) Then
                        ValidateInflowTimeForVin = InflowErrors.TimeNotValidForVin
                        Exit Function
                    End If
                End If
            Else
                ValidateInflowTimeForVin = InflowErrors.InvalidTable
            End If
        End If
    End Function

    Public Function ValidateStandardHydrograph() As InflowErrors
        ValidateStandardHydrograph = InflowErrors.NoError

        If (Me.InflowRate.Value <= 0.0) Then
            ValidateStandardHydrograph = InflowErrors.RateNotPositive
            Exit Function
        End If

        Dim Tco As Double = Me.Tco
        If (Tco <= 0.0) Then
            ValidateStandardHydrograph = InflowErrors.CutoffInvalid
            Exit Function
        End If

        Dim cutbackMethod As CutbackMethods = Me.CutbackMethod.Value
        Select Case (cutbackMethod)
            Case CutbackMethods.TimeBased
                Dim Rcb As Double = Me.CutbackRateRatio.Value
                If (Rcb <= 0.0) Then
                    ValidateStandardHydrograph = InflowErrors.CutbackInvalid
                    Exit Function
                End If

                If (Me.CutbackTimeRatio.Source <> ValueSources.Calculated) Then
                    Dim Tcb As Double = Me.CutbackTimeRatio.Value
                    If (Tcb <= 0.0) Then
                        ValidateStandardHydrograph = InflowErrors.CutbackInvalid
                        Exit Function
                    End If
                End If
            Case CutbackMethods.DistanceBased
                Dim Rcb As Double = Me.CutbackRateRatio.Value
                If (Rcb <= 0.0) Then
                    ValidateStandardHydrograph = InflowErrors.CutbackInvalid
                    Exit Function
                End If

                Dim Tcb As Double = Me.CutbackLocationRatio.Value
                If (Tcb <= 0.0) Then
                    ValidateStandardHydrograph = InflowErrors.CutbackInvalid
                    Exit Function
                End If
        End Select

    End Function

    Public Function ValidateTabulatedInflow() As InflowErrors
        ValidateTabulatedInflow = InflowErrors.NoError

        Dim inflowTable As DataTable = Me.TabulatedInflow.Value

        If ((DataTableHasData(inflowTable)) _
        And (DataColumnIsDouble(inflowTable, nTimeX)) _
        And (DataColumnIsDouble(inflowTable, nInflowX))) Then

            Dim prevT As Double = -Double.Epsilon

            For Each inflowRow As DataRow In inflowTable.Rows

                Dim T As Double = CDbl(inflowRow.Item(nTimeX))
                Dim Qin As Double = CDbl(inflowRow.Item(nInflowX))

                If ((prevT = -Double.Epsilon) And Not (0.0 = T)) Then
                    ValidateTabulatedInflow = InflowErrors.FirstTimeNotZero
                    Exit Function
                ElseIf ((prevT = -Double.Epsilon) And (Qin < LiterPerSecond / 200.0)) Then
                    ValidateTabulatedInflow = InflowErrors.FirstRateIsZero
                    Exit Function
                ElseIf (T <= prevT) Then
                    ValidateTabulatedInflow = InflowErrors.TimesNotMonotonic
                    Exit Function
                Else
                    prevT = T
                End If

                If (Qin < 0.0) Then
                    ValidateTabulatedInflow = InflowErrors.RateNotPositive
                    Exit Function
                End If
            Next inflowRow

        Else
            ValidateTabulatedInflow = InflowErrors.InvalidTable
        End If
    End Function

    Public Function ValidateCablegation() As InflowErrors
        ValidateCablegation = InflowErrors.NoError
    End Function

    Public Function ValidateSurge() As InflowErrors
        ValidateSurge = InflowErrors.NoError
    End Function

#End Region

#Region " Runoff "

    Public Enum RunoffErrors
        NoError

        NoRunoffVolume          ' General Runoff errors
        TimeNotPositive
        RateNotPositive
        TimeNotValidForVro

        InvalidTable            ' Tabulated Runoff errors
        FirstRunoffTimeNotAdv
        FirstRunoffNotZero
        LastRunoffTimeNotRec
        LastRunoffNotZero
        TimesNotMonotonic
        TimeLessThanTL
    End Enum

    '*********************************************************************************************************
    ' Function ValidateRunoffVolume() - validate runoff table actually represents a positive runoff volume
    '
    ' Returns:      RunoffErrors        - Runoff Error enumeration
    '*********************************************************************************************************
    Public Function ValidateRunoffVolume() As RunoffErrors
        ValidateRunoffVolume = RunoffErrors.NoError
        Dim Vro As Double = Me.RunoffVolumeForField
        If (Vro <= 0.0) Then
            ValidateRunoffVolume = RunoffErrors.NoRunoffVolume
        End If
    End Function

    '*********************************************************************************************************
    ' Function ValidateRunoffTimeForVro() - validate Vro can be calculated for specified time
    '
    ' Input(s):     Time            - Time to check if Vro can be calculated
    '
    ' Returns:      RunoffErrors    - Runoff Error enumeration
    '*********************************************************************************************************
    Public Function ValidateRunoffTimeForVro(ByVal Time As Double) As RunoffErrors
        ValidateRunoffTimeForVro = RunoffErrors.NoError

        If (Me.RunoffMeasured.Value) Then ' Runoff measured
            If (Me.TabulatedRunoffHasData) Then ' Runoff input

                Dim T1, T2, Qro1, Qro2 As Double
                Dim ok As Boolean = Me.RunoffRange(T1, Qro1, T2, Qro2)
                If (ok) Then

                    If (Me.RunoffUsed.Value) Then ' Runoff used for VB calculations
                        If (Me.TabulatedRunoffIncomplete.Value) Then ' Partial Hydrograph
                            If ((Time < 0.0) Or (T2 < Time)) Then
                                ValidateRunoffTimeForVro = RunoffErrors.TimeNotValidForVro
                                Exit Function
                            End If
                        Else ' Complete Hydrograph
                            If (Time < 0.0) Then
                                ValidateRunoffTimeForVro = RunoffErrors.TimeNotValidForVro
                                Exit Function
                            End If
                        End If
                    Else ' runoff not used
                        If (T1 < Time) Then
                            ValidateRunoffTimeForVro = RunoffErrors.TimeNotValidForVro
                            Exit Function
                        End If
                    End If ' runoff used

                Else ' ok
                    ValidateRunoffTimeForVro = RunoffErrors.InvalidTable
                    Exit Function
                End If

            Else ' not input
                ValidateRunoffTimeForVro = RunoffErrors.InvalidTable
                Exit Function
            End If ' input
        End If ' measured
    End Function

    '*********************************************************************************************************
    ' Function ValidateTabulatedRunoff() - validate basic runoff table values
    '
    ' Returns:      RunoffErrors        - Runoff Error enumeration
    '
    ' This method only checks for basic runoff table errors:
    '   1) - table exists and is setup correctly with Time & Runoff columns
    '   2) - Times are positive (0 < T)
    '   3) - Times increase monotonically
    '   4) - Rates are positive (0 <= Qro)
    '
    ' Runoff values in relation to other InflowManagement data are checked elsewhere; see:
    '   ValidateRunoffAdvanceAlignment()
    '   ValidateRunoffRecessionAlignment()
    '*********************************************************************************************************
    Public Function ValidateTabulatedRunoff() As RunoffErrors
        ValidateTabulatedRunoff = RunoffErrors.NoError

        Dim runoffTable As DataTable = Me.TabulatedRunoff.Value

        If ((DataTableHasData(runoffTable, 1)) _
        And (DataColumnIsDouble(runoffTable, nTimeX)) _
        And (DataColumnIsDouble(runoffTable, nRunoffX))) Then ' table has correct runoff data

            Dim prevT As Double = -Double.Epsilon

            For Each runoffRow As DataRow In runoffTable.Rows

                Dim T As Double = CDbl(runoffRow.Item(nTimeX))
                Dim Qro As Double = CDbl(runoffRow.Item(nRunoffX))

                If (T <= 0.0) Then
                    ValidateTabulatedRunoff = RunoffErrors.TimeNotPositive
                    Exit Function
                ElseIf (T <= prevT) Then
                    ValidateTabulatedRunoff = RunoffErrors.TimesNotMonotonic
                    Exit Function
                Else
                    prevT = T
                End If

                If (Qro < 0.0) Then
                    ValidateTabulatedRunoff = RunoffErrors.RateNotPositive
                    Exit Function
                End If
            Next runoffRow

        Else
            ValidateTabulatedRunoff = RunoffErrors.InvalidTable
        End If

    End Function

#End Region

#Region " Advance "

    Public Enum AdvanceErrors
        NoError

        TimeNotValidForVy

        InvalidTable        ' Tabulated Advance errors

        FirstDistanceNotZero
        DistancesNotMonotonic
        LastDistanceNotLength

        FirstTimeNotZero
        TimesNotMonotonic
    End Enum

    '*********************************************************************************************************
    ' Function ValidateTabulatedAdvance() - validate the values in the Advance Table 
    '
    ' Input(s):     L               - optional field length
    '
    ' Returns:      AdvanceErrors   - enumerated error, if any, found in the Advance Table data
    '
    ' Note - the Advance Curve must start at (X=0, T=0) with both X & T increasing monotonically down the
    '        field.  If the field length (L) is specified, the Advance curve must reach the end of the field.
    '
    ' Note - this method validates only the Advance Table; it does not validate the Advance Table in relation
    '        to other data such as Runoff.
    '
    ' ValidateRunoffAdvanceAlignment() validates the relationship betwen Runoff & Advance
    '*********************************************************************************************************
    Public Function ValidateTabulatedAdvance(Optional ByVal L As Double = 0.0) As AdvanceErrors
        ValidateTabulatedAdvance = AdvanceErrors.NoError

        Dim advTable As DataTable = Me.TabulatedAdvance.Value

        If ((DataTableHasData(advTable)) _
        And (DataColumnIsDouble(advTable, nDistanceX)) _
        And (DataColumnIsDouble(advTable, nTimeX1))) Then

            Dim prevX As Double = -Double.Epsilon
            Dim prevT As Double = -Double.Epsilon

            For Each advRow As DataRow In advTable.Rows

                Dim advX As Double = CDbl(advRow.Item(nDistanceX))
                Dim advT As Double = CDbl(advRow.Item(nTimeX1))

                If ((prevX = -Double.Epsilon) And Not (0.0 = advX)) Then ' First X is not 0.0
                    ValidateTabulatedAdvance = AdvanceErrors.FirstDistanceNotZero
                    Exit Function
                ElseIf (advX <= prevX) Then ' X regressing
                    ValidateTabulatedAdvance = AdvanceErrors.DistancesNotMonotonic
                    Exit Function
                Else
                    prevX = advX
                End If

                If ((prevT = -Double.Epsilon) And Not (0.0 = advT)) Then ' First T is not 0.0
                    ValidateTabulatedAdvance = AdvanceErrors.FirstTimeNotZero
                    Exit Function
                ElseIf (advT <= prevT) Then ' T regressing
                    ValidateTabulatedAdvance = AdvanceErrors.TimesNotMonotonic
                    Exit Function
                Else
                    prevT = advT
                End If

            Next advRow

            If ((0.0 < L) And Not (ThisClose(prevX, L, OneDecimeter))) Then ' Advance did not reach L
                ValidateTabulatedAdvance = AdvanceErrors.LastDistanceNotLength
                Exit Function
            End If

        Else
            ValidateTabulatedAdvance = AdvanceErrors.InvalidTable
        End If

    End Function

    '*********************************************************************************************************
    ' Function ValidateAdvanceTimeForVy() - validate Vy can be calculatedfor specified time
    '
    ' Input(s):     Time            - Time to check if Vy can be calculated
    '               L               - optional field length
    '
    ' Returns:      AdvanceErrors   - Advance Error enumeration
    '*********************************************************************************************************
    Public Function ValidateAdvanceTimeForVy(ByVal Time As Double, _
                                             Optional ByVal L As Double = 0.0) As AdvanceErrors
        ValidateAdvanceTimeForVy = AdvanceErrors.NoError

        If (Me.TabulatedAdvanceHasData) Then

            Dim maxAdvTime As Double = MaxAdvanceTime()
            Dim maxAdvDist As Double = MaxAdvanceDistance()

            If (0.0 < L) Then
                If (L - OneDecimeter <= maxAdvDist) Then ' advance reached end-of-field
                    If (Time < 0.0) Then
                        ValidateAdvanceTimeForVy = AdvanceErrors.TimeNotValidForVy
                        Exit Function
                    End If
                Else ' advance did not reach end-of-field
                    If ((Time < 0.0) Or (maxAdvTime < Time)) Then
                        ValidateAdvanceTimeForVy = AdvanceErrors.TimeNotValidForVy
                        Exit Function
                    End If
                End If
            Else ' L not specified; just check advance time range
                If ((Time < 0.0) Or (maxAdvTime < Time)) Then
                    ValidateAdvanceTimeForVy = AdvanceErrors.TimeNotValidForVy
                    Exit Function
                End If
            End If
        Else
            ValidateAdvanceTimeForVy = AdvanceErrors.InvalidTable
        End If

    End Function

#End Region

#Region " Recession "

    Public Enum RecessionErrors
        NoError

        TimeNotValidForVB

        InvalidTable        ' Tabulated Recession errors

        FirstDistanceNotZero
        DistancesNotMonotonic
        LastDistanceNotLength

        FirstTimeNotAfterCutoff
        TimeNotPositive
        TimeNotAfterAdvanceTime
    End Enum

    '*********************************************************************************************************
    ' Function ValidateTabulatedRecession() - validate the values in the Recession Table 
    '
    ' Input(s):     X0              - upstream X to check
    '               XL              - downstream X to check
    '
    ' Returns:      RecessionErrors - enumerated error, if any, found in the Recession Table data
    '
    ' Note - the Recession Curve should start at (X=0, Tco<T) with X increasing monotonically down the field.
    '        If (0 = X0), the Recession curve must start at X0
    '        If (0 < XL), the Recession curve must end at XL
    '
    ' Note - this method validates only the Recession Table; it does not validate the Recession Table in
    '        relation to other data such as Runoff.
    '
    ' ValidateRunoffRecessionAlignment() validates the relationship betwen Runoff & Recession
    '*********************************************************************************************************
    Public Function ValidateTabulatedRecession(ByVal X0 As Double, ByVal XL As Double) As RecessionErrors
        ValidateTabulatedRecession = RecessionErrors.NoError

        Dim recTable As DataTable = Me.TabulatedRecession.Value

        If ((DataTableHasData(recTable)) _
        And (DataColumnIsDouble(recTable, nDistanceX)) _
        And (DataColumnIsDouble(recTable, nTimeX1))) Then

            Dim Tco As Double = Me.Tco()
            Dim prevX As Double = -Double.Epsilon

            For Each recRow As DataRow In recTable.Rows

                Dim recX As Double = CDbl(recRow.Item(nDistanceX))
                Dim recT As Double = CDbl(recRow.Item(nTimeX1))
                Dim advT As Double = Me.Tadv(recX)

                If ((prevX = -Double.Epsilon) And (0.0 = X0) And Not (0.0 = recX)) Then
                    ValidateTabulatedRecession = RecessionErrors.FirstDistanceNotZero
                    Exit Function
                ElseIf (recX <= prevX) Then
                    ValidateTabulatedRecession = RecessionErrors.DistancesNotMonotonic
                    Exit Function
                Else
                    prevX = recX
                End If

                If ((0.0 = recX) And (recT < Tco)) Then
                    ValidateTabulatedRecession = RecessionErrors.FirstTimeNotAfterCutoff
                    Exit Function
                ElseIf (recT <= advT) Then
                    ValidateTabulatedRecession = RecessionErrors.TimeNotAfterAdvanceTime
                    Exit Function
                ElseIf (recT <= 0.0) Then
                    ValidateTabulatedRecession = RecessionErrors.TimeNotPositive
                    Exit Function
                End If

            Next recRow

            If ((0.0 < XL) And Not (ThisClose(prevX, XL, OneDecimeter))) Then
                ValidateTabulatedRecession = RecessionErrors.LastDistanceNotLength
                Exit Function
            End If

        Else
            ValidateTabulatedRecession = RecessionErrors.InvalidTable
        End If

    End Function

    '*********************************************************************************************************
    ' Function ValidateRecessionTimeForVB() - validate VB can be calculated for specified time
    '
    ' Input(s):     Time            - Time to check if VB can be calculated
    '
    ' Returns:      RecessionErrors - Recession Error enumeration
    '*********************************************************************************************************
    Public Function ValidateRecessionTimeForVB(ByVal Time As Double) As RecessionErrors
        ValidateRecessionTimeForVB = RecessionErrors.NoError

        If (Me.TabulatedRecessionHasData) Then

            Dim maxT As Double = MaxRecessionTime()
            Dim maxX As Double = MaxRecessionDistance()

            If (maxT < Time) Then ' can't calc VB past max recession time
                ValidateRecessionTimeForVB = RecessionErrors.TimeNotValidForVB
                Exit Function
            End If
        Else
            ValidateRecessionTimeForVB = RecessionErrors.InvalidTable
        End If

    End Function

#End Region

#Region " Stations "

    Public Enum StationErrors
        NoError

        InvalidTable

        NotEnoughStations
        FirstStationNotAt0
        LastStationNotAtL
        DistancesNotMonotonic

        LocationNotSynced
        ElevationNotSynced

        AdvanceTimes
        RecessionTimes

        FlowDepths
        NoFlowDepthTableForStation
        FirstFlowDepthNotZero
        FirstFlowDepthTimeNotAdv
        LastFlowDepthNotZero
        LastFlowDepthTimeNotRec
        TimesNotMonotonic
        TimeIsNegative
        DepthIsNegative
    End Enum

    Public Function ValidateStationsTable(ByVal L As Double) As StationErrors
        ValidateStationsTable = StationErrors.NoError

        Dim stationsTable As DataTable = Me.MeasurementStations.Value
        If (stationsTable IsNot Nothing) Then

            If ((DataTableHasData(stationsTable)) _
            And (DataColumnIsDouble(stationsTable, sDistanceX)) _
            And (DataColumnIsDouble(stationsTable, sElevationX))) Then
                ' Stations Table has data, validate it
                Dim count As Integer = stationsTable.Rows.Count
                If (count < 5) Then
                    ValidateStationsTable = StationErrors.NotEnoughStations
                    Exit Function
                End If

                ' First Station must be at the head of the field
                Dim stationRow As DataRow = stationsTable.Rows(0)
                Dim dist1 As Double = CDbl(stationRow.Item(sDistanceX))

                If Not (dist1 = 0.0) Then
                    ValidateStationsTable = StationErrors.FirstStationNotAt0
                    Exit Function
                End If

                ' Last Station must be at the end of the field
                stationRow = stationsTable.Rows(count - 1)
                Dim dist2 As Double = CDbl(stationRow.Item(sDistanceX))

                If Not (ThisClose(dist2, L, OneDecimeter)) Then
                    ValidateStationsTable = StationErrors.LastStationNotAtL
                    Exit Function
                End If

                ' Stations distances must increase
                For sdx As Integer = 1 To count - 1

                    stationRow = stationsTable.Rows(sdx)
                    dist2 = CDbl(stationRow.Item(sDistanceX))

                    If (dist2 <= dist1) Then ' Distance not increasing
                        ValidateStationsTable = StationErrors.DistancesNotMonotonic
                        Exit Function
                    Else
                        dist1 = dist2
                    End If

                Next sdx

            Else
                ValidateStationsTable = StationErrors.InvalidTable
            End If
        Else
            ValidateStationsTable = StationErrors.InvalidTable
        End If

    End Function

    '*********************************************************************************************************
    ' Function ValidateStationLocations() - validate Measurement Stations locations against Elevation table
    '*********************************************************************************************************
    Public Function ValidateStationLocations(ByRef StationIdx As Integer) As StationErrors
        ValidateStationLocations = StationErrors.NoError
        StationIdx = -1

        Dim stationsTable As DataTable = Me.MeasurementStations.Value
        If (stationsTable IsNot Nothing) Then

            Dim staCount As Integer = stationsTable.Rows.Count

            Dim mSystemGeometry As SystemGeometry = mUnit.SystemGeometryRef
            Dim elevSet As DataSet = mSystemGeometry.ElevationTable.Value
            Dim elevTable As DataTable = elevSet.Tables(0)
            If (elevTable IsNot Nothing) Then

                For StationIdx = 0 To staCount - 1

                    Dim staRow As DataRow = stationsTable.Rows(StationIdx)
                    Dim staDist As Double = staRow.Item(nDistanceX) ' Location of Measurement Station

                    ' Is there an entry in the Elevation table for this Station's location?
                    Dim elevRow As DataRow = GetDataRow(elevTable, nDistanceX, staDist, 0.0)
                    If (elevRow Is Nothing) Then ' Station location NOT in Elevation table
                        ValidateStationLocations = StationErrors.LocationNotSynced
                        Exit Function
                    End If

                Next StationIdx

            Else
                ValidateStationLocations = StationErrors.InvalidTable
            End If
        Else
            ValidateStationLocations = StationErrors.InvalidTable
        End If

    End Function

    Public Function ValidateStationElevations(ByRef StationIdx As Integer) As StationErrors
        ValidateStationElevations = StationErrors.NoError
        StationIdx = -1

        Dim stationsTable As DataTable = Me.MeasurementStations.Value
        If (stationsTable IsNot Nothing) Then

            Dim staCount As Integer = stationsTable.Rows.Count

            Dim mSystemGeometry As SystemGeometry = mUnit.SystemGeometryRef
            Dim elevSet As DataSet = mSystemGeometry.ElevationTable.Value
            Dim elevTable As DataTable = elevSet.Tables(0)
            If (elevTable IsNot Nothing) Then

                For StationIdx = 0 To staCount - 1

                    Dim staRow As DataRow = stationsTable.Rows(StationIdx)
                    Dim staDist As Double = staRow.Item(nDistanceX) ' Location of Measurement Station
                    Dim staElev As Double = staRow.Item(nElevationX) ' Elevation of Measurement Station

                    ' Is there an entry in the Elevation table for this Station's location?
                    Dim elevRow As DataRow = GetDataRow(elevTable, nDistanceX, staDist, 0.0)
                    If (elevRow IsNot Nothing) Then ' Station location is in Elevation table
                        Dim elevation As Double = elevRow.Item(nElevationX)
                        If (Not elevation = staElev) Then
                            ValidateStationElevations = StationErrors.ElevationNotSynced
                            Exit Function
                        End If
                    Else
                        ValidateStationElevations = StationErrors.LocationNotSynced
                        Exit Function
                    End If

                Next StationIdx

            Else
                ValidateStationElevations = StationErrors.InvalidTable
            End If
        Else
            ValidateStationElevations = StationErrors.InvalidTable
        End If

    End Function

    '*********************************************************************************************************
    ' Function ValidateStationAdvanceTimes() - validate Measurement Stations data against Advance table
    '*********************************************************************************************************
    Public Function ValidateStationAdvanceTimes(ByVal FirstPointIsAdvance As Boolean, _
                                                ByRef StationIdx As Integer) As StationErrors
        ValidateStationAdvanceTimes = StationErrors.NoError
        StationIdx = -1

        Dim stationsTable As DataTable = Me.MeasurementStations.Value
        If (stationsTable IsNot Nothing) Then

            Dim staCount As Integer = stationsTable.Rows.Count

            Dim advTable As DataTable = Me.TabulatedAdvance.Value
            If (advTable IsNot Nothing) Then

                Dim advCount As Integer = advTable.Rows.Count

                Dim flowDepthSet As DataSet = Me.StationsFlowDepths.Value
                If (flowDepthSet IsNot Nothing) Then

                    Dim fdsCount As Integer = flowDepthSet.Tables.Count

                    ' Check Advance data for each Measurement Station
                    For StationIdx = 0 To staCount - 1
                        Dim staRow As DataRow = stationsTable.Rows(StationIdx)
                        Dim staDist As Double = staRow.Item(nDistanceX) ' Location of Measurement Station

                        ' Is there an entry in the Advance table for this Station's location?
                        Dim advRow As DataRow = GetDataRow(advTable, nDistanceX, staDist, OneDecimeter)
                        If (advRow Is Nothing) Then ' Station location NOT in Advance table
                            If (FirstPointIsAdvance) Then ' this is an error
                                ValidateStationAdvanceTimes = StationErrors.AdvanceTimes
                                Exit Function
                            End If
                        End If

                        ' Validate initial time & depth in this Station's Flow Depth Hydrograph
                        If (StationIdx < fdsCount) Then ' Flow Depth Hydrograph exists; get it
                            Dim flowDepthTable As DataTable = flowDepthSet.Tables(StationIdx)

                            ' Does the Flow Depth Hydrograph have data in it?
                            Dim fdCount As Integer = flowDepthTable.Rows.Count
                            If (0 < fdCount) Then ' has data; get initial time & depth
                                Dim fdRow As DataRow = flowDepthTable.Rows(0)
                                Dim firstT As Double = fdRow.Item(nTimeX)
                                Dim firstY As Double = fdRow.Item(nDepthX1)

                                If (FirstPointIsAdvance) Then

                                    Dim advT As Double = advRow.Item(nTimeX1) ' Advance time to Measurement Station

                                    ' Initial time should be Advance time to Station
                                    If Not (firstT = advT) Then
                                        ValidateStationAdvanceTimes = StationErrors.FirstFlowDepthTimeNotAdv
                                        Exit Function
                                    End If

                                    ' Initial depth should be zero
                                    If Not (firstY = 0.0) Then
                                        ValidateStationAdvanceTimes = StationErrors.FirstFlowDepthNotZero
                                        Exit Function
                                    End If
                                Else
                                    If (advRow IsNot Nothing) Then

                                        Dim advT As Double = advRow.Item(nTimeX1) ' Advance time to Measurement Station

                                        ' If initial depth is zero; initial time must be advance
                                        If ((firstY = 0.0) And Not (firstT = advT)) Then
                                            ValidateStationAdvanceTimes = StationErrors.FirstFlowDepthTimeNotAdv
                                            Exit Function
                                        End If
                                    End If
                                End If

                            Else ' no data in Flow Depth Table
                                ValidateStationAdvanceTimes = StationErrors.NoFlowDepthTableForStation
                                Exit Function
                            End If
                        Else ' no Flow Depth table for Station
                            ValidateStationAdvanceTimes = StationErrors.NoFlowDepthTableForStation
                            Exit Function
                        End If
                    Next StationIdx

                Else ' no Flow Depth set
                    ValidateStationAdvanceTimes = StationErrors.InvalidTable
                End If
            Else ' no Advance table
                ValidateStationAdvanceTimes = StationErrors.InvalidTable
            End If
        Else ' not Stations table
            ValidateStationAdvanceTimes = StationErrors.InvalidTable
        End If

    End Function

    '*********************************************************************************************************
    ' Function ValidateStationRecessionTimes() - validate Measurement Stations data against Reccession table
    '*********************************************************************************************************
    Public Function ValidateStationRecessionTimes(ByVal LastPointIsRecession As Boolean, _
                                                  ByRef StationIdx As Integer) As StationErrors
        ValidateStationRecessionTimes = StationErrors.NoError

        Dim stationsTable As DataTable = Me.MeasurementStations.Value
        If (stationsTable IsNot Nothing) Then

            Dim staCount As Integer = stationsTable.Rows.Count

            Dim recTable As DataTable = Me.TabulatedRecession.Value
            If (recTable IsNot Nothing) Then

                Dim recCount As Integer = recTable.Rows.Count

                Dim flowDepthSet As DataSet = Me.StationsFlowDepths.Value
                If (flowDepthSet IsNot Nothing) Then

                    Dim fdsCount As Integer = flowDepthSet.Tables.Count

                    ' Check Recession data for each Measurement Station
                    For StationIdx = 0 To staCount - 1
                        Dim staRow As DataRow = stationsTable.Rows(StationIdx)
                        Dim staDist As Double = staRow.Item(nDistanceX) ' Location of Measurement Station

                        ' Is there an entry in the Recession table for this Station's location?
                        Dim recRow As DataRow = GetDataRow(recTable, nDistanceX, staDist, OneDecimeter)
                        If (recRow Is Nothing) Then ' Station location NOT in Recession table
                            If (LastPointIsRecession) Then ' this is an error
                                ValidateStationRecessionTimes = StationErrors.RecessionTimes
                                Exit Function
                            End If
                        End If

                        ' Validate final time & depth in this Station's Flow Depth Hydrograph
                        If (StationIdx < fdsCount) Then ' Flow Depth Hydrograph exists; get it
                            Dim flowDepthTable As DataTable = flowDepthSet.Tables(StationIdx)

                            ' Does the Flow Depth Hydrograph have data in it?
                            Dim fdCount As Integer = flowDepthTable.Rows.Count
                            If (0 < fdCount) Then ' has data; get final time & depth
                                Dim fdRow As DataRow = flowDepthTable.Rows(fdCount - 1)
                                Dim finalT As Double = fdRow.Item(nTimeX)
                                Dim finalY As Double = fdRow.Item(nDepthX1)

                                If (LastPointIsRecession) Then

                                    Dim recT As Double = recRow.Item(nTimeX1) ' Recession time at Measurement Station

                                    ' Final time should be Recession time at Station
                                    If Not (finalT = recT) Then
                                        ValidateStationRecessionTimes = StationErrors.LastFlowDepthTimeNotRec
                                        Exit Function
                                    End If

                                    ' Final depth should be zero
                                    If Not (finalY = 0.0) Then
                                        ValidateStationRecessionTimes = StationErrors.LastFlowDepthNotZero
                                        Exit Function
                                    End If
                                Else
                                    If (recRow IsNot Nothing) Then

                                        Dim recT As Double = recRow.Item(nTimeX1) ' Recession time at Measurement Station

                                        ' If final depth is zero; final time must be recession
                                        If ((finalY = 0.0) And Not (finalT = recT)) Then
                                            ValidateStationRecessionTimes = StationErrors.LastFlowDepthTimeNotRec
                                            Exit Function
                                        End If
                                    End If
                                End If

                            Else ' no data in Flow Depth Table
                                ValidateStationRecessionTimes = StationErrors.NoFlowDepthTableForStation
                                Exit Function
                            End If
                        Else ' no Flow Depth table for Station
                            ValidateStationRecessionTimes = StationErrors.NoFlowDepthTableForStation
                            Exit Function
                        End If
                    Next StationIdx

                Else ' no Flow Depth set
                    ValidateStationRecessionTimes = StationErrors.InvalidTable
                End If

            Else ' no Recession table
                ValidateStationRecessionTimes = StationErrors.InvalidTable
            End If
        Else
            ValidateStationRecessionTimes = StationErrors.InvalidTable
        End If

    End Function

    '*********************************************************************************************************
    ' Function ValidateTabulatedFlowDepths() - validate all the Flow Depth tables
    '*********************************************************************************************************
    Public Function ValidateTabulatedFlowDepths(ByRef StationIdx As Integer) As StationErrors
        ValidateTabulatedFlowDepths = StationErrors.NoError

        Dim flowDepthSet As DataSet = Me.StationsFlowDepths.Value

        If (DataSetHasData(flowDepthSet)) Then

            StationIdx = 0
            For Each flowDepthTable As DataTable In flowDepthSet.Tables

                If ((DataTableHasData(flowDepthTable, 1)) _
                And (DataColumnIsDouble(flowDepthTable, nTimeX)) _
                And (DataColumnIsDouble(flowDepthTable, nDepthX1))) Then ' table has correct flow depth data

                    Dim prevT As Double = -Double.Epsilon

                    For Each flowDepthRow As DataRow In flowDepthTable.Rows

                        Dim T As Double = CDbl(flowDepthRow.Item(nTimeX))
                        Dim Y As Double = CDbl(flowDepthRow.Item(nDepthX1))

                        If (T < 0.0) Then
                            ValidateTabulatedFlowDepths = StationErrors.TimeIsNegative
                            Exit Function
                        ElseIf (T <= prevT) Then
                            ValidateTabulatedFlowDepths = StationErrors.TimesNotMonotonic
                            Exit Function
                        Else
                            prevT = T
                        End If

                        If (Y < 0.0) Then
                            ValidateTabulatedFlowDepths = StationErrors.DepthIsNegative
                            Exit Function
                        End If
                    Next flowDepthRow

                Else
                    ValidateTabulatedFlowDepths = StationErrors.InvalidTable
                    Exit Function
                End If

                StationIdx += 1
            Next flowDepthTable
        Else
            ValidateTabulatedFlowDepths = StationErrors.InvalidTable
        End If

    End Function

#End Region

#Region " Data Alignment "

    '*********************************************************************************************************
    ' Function ValidateRunoffAdvanceAlignment()   - Validate Runoff starts when Advance reaches end-of-field
    ' Function ValidateRunoffRecessionAlignment() -     "       "   ends when Recession occurs at "  "   "
    '
    ' Input(s):     L               - Length of the field
    '
    ' Returns:      RunoffErrors    - enumeration of error, if any, found during validation
    '*********************************************************************************************************
    Public Function ValidateRunoffAdvanceAlignment(ByVal L As Double) As RunoffErrors
        ValidateRunoffAdvanceAlignment = RunoffErrors.NoError

        Dim runoffPartial As Boolean = Me.TabulatedRunoffIncomplete.Value

        If Not (runoffPartial) Then ' Runoff is partial hydrograph; skip validation
            Dim runoffTable As DataTable = Me.TabulatedRunoff.Value
            If (DataTableHasData(runoffTable)) Then
                Dim firstRoRow As DataRow = runoffTable.Rows(0)
                Dim firstRoTime As Double = firstRoRow.Item(nTimeX)
                Dim firstRunoff As Double = firstRoRow.Item(nRunoffX)

                Dim advanceTable As DataTable = Me.TabulatedAdvance.Value
                If (DataTableHasData(advanceTable)) Then
                    Dim lastAdvRow As DataRow = advanceTable.Rows(advanceTable.Rows.Count - 1)
                    Dim lastAdvDist As Double = lastAdvRow.Item(nDistanceX)
                    Dim lastAdvTime As Double = lastAdvRow.Item(nTimeX1)

                    If (ThisClose(lastAdvDist, L, OneDecimeter)) Then ' Advance specified to end-of-field
                        If (ThisClose(firstRoTime, lastAdvTime, OneMinute)) Then ' times match; check Qro
                            If Not (firstRunoff = 0.0) Then
                                ValidateRunoffAdvanceAlignment = RunoffErrors.FirstRunoffNotZero
                            End If
                        Else
                            ValidateRunoffAdvanceAlignment = RunoffErrors.FirstRunoffTimeNotAdv
                        End If
                    End If ' Advance specified to end-of-field
                End If ' Advance table has data
            End If ' Runoff table has data
        End If ' not Partial Hydrograph

    End Function

    Public Function ValidateRunoffRecessionAlignment(ByVal L As Double) As RunoffErrors
        ValidateRunoffRecessionAlignment = RunoffErrors.NoError

        Dim runoffPartial As Boolean = Me.TabulatedRunoffIncomplete.Value

        If Not (runoffPartial) Then ' Runoff is partial hydrograph; skip validation
            Dim runoffTable As DataTable = Me.TabulatedRunoff.Value
            If (DataTableHasData(runoffTable)) Then
                Dim lastRoRow As DataRow = runoffTable.Rows(runoffTable.Rows.Count - 1)
                Dim lastRoTime As Double = lastRoRow.Item(nTimeX)
                Dim lastRunoff As Double = lastRoRow.Item(nRunoffX)

                Dim recessionTable As DataTable = Me.TabulatedRecession.Value
                If (DataTableHasData(recessionTable)) Then
                    Dim lastRecRow As DataRow = recessionTable.Rows(recessionTable.Rows.Count - 1)
                    Dim lastRecDist As Double = lastRecRow.Item(nDistanceX)
                    Dim lastRecTime As Double = lastRecRow.Item(nTimeX1)

                    If (ThisClose(lastRecDist, L, OneDecimeter)) Then ' Recession specified to end-of-field
                        If (ThisClose(lastRoTime, lastRecTime, OneMinute)) Then ' times match; check Qro
                            If Not (lastRunoff = 0.0) Then
                                ValidateRunoffRecessionAlignment = RunoffErrors.LastRunoffNotZero
                            End If
                        Else
                            ValidateRunoffRecessionAlignment = RunoffErrors.LastRunoffTimeNotRec
                        End If
                    End If ' Recession specified to end-of-field
                End If ' Recession table has data
            End If ' Runoff table has data
        End If ' not Partial Hydrograph

    End Function

    Public Function ValidateAdvanceRecessionAlignment() As Boolean
        ValidateAdvanceRecessionAlignment = False

        Dim advanceTable As DataTable = Me.TabulatedAdvance.Value
        If (DataTableHasData(advanceTable)) Then

            Dim advRowCount As Integer = advanceTable.Rows.Count

            Dim recessionTable As DataTable = Me.TabulatedRecession.Value
            If (DataTableHasData(recessionTable)) Then

                Dim recRowCount As Integer = recessionTable.Rows.Count

                If (advRowCount = recRowCount) Then
                    ValidateAdvanceRecessionAlignment = True

                    For rdx As Integer = 0 To advRowCount - 1

                        Dim advRow As DataRow = advanceTable.Rows(rdx)
                        Dim recRow As DataRow = recessionTable.Rows(rdx)

                        Dim advDist As Double = advRow.Item(nDistanceX)
                        Dim recDist As Double = recRow.Item(nDistanceX)

                        If Not (ThisClose(advDist, recDist, OneMeter)) Then
                            ValidateAdvanceRecessionAlignment = False
                            Exit Function
                        End If
                    Next rdx

                End If
            End If
        End If

    End Function

#End Region

#End Region

#Region " Constructor(s) "

    Public Sub New(ByVal _myID As String, ByVal _unit As Unit)
        '
        ' Verify data structures' sizes
        '
        Debug.Assert(InflowMethods.HighLimit = InflowMethodSelections.Length)
        Debug.Assert(CutoffMethods.HighLimit = CutoffMethodSelections.Length)
        Debug.Assert(CutbackMethods.HighLimit = CutbackMethodSelections.Length)
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
        ' Add InflowManagement to Parent's Data Store
        '
        If Not (mParentStore Is Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If Not (mMyStore Is Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "InflowManagement not added to Data Store")
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

            ' Restore the Power Law Advance p -> Power Law Advance r linkages
            Dim _parameter As Parameter
            Dim _powerAdvanceP As PowerAdvancePParameter

            _parameter = AdvancePProperty.GetParameter()

            If (_parameter.GetType Is GetType(PowerAdvancePParameter)) Then
                _powerAdvanceP = DirectCast(_parameter, PowerAdvancePParameter)
                _powerAdvanceP.PowerAdvanceR = AdvanceRProperty
            Else
                Debug.Assert(False, "Parameter is not Power Law P")
            End If

            ' Enable event generation
            mMyStore.EventsEnabled = True
        Else
            Debug.Assert(False, "MyStore is Nothing")
        End If
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        UnitWaterCost

        TargetInfiltrationDepth

        InflowRate
        InflowMethod

        CutoffMethod
        CutoffTime
        CutoffLocationRatio

        CutbackMethod
        CutbackTimeRatio
        CutbackLocationRatio
        CutbackRateRatio

        TabulatedInflow
        TabulatedRunoff

        Advance
        Recession
        OpportunityTime

        FieldMeasurements

        TwoPointData

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
        ' Regenerate the DataStore event as an InflowManagement event
        Select Case _id
            Case sUnitWaterCost
                RaiseEvent PropertyDataChanged(Reasons.UnitWaterCost)
            Case sTargetInfiltrationDepth, sRequiredDepth
                RaiseEvent PropertyDataChanged(Reasons.TargetInfiltrationDepth)
            Case sInflowRate
                RaiseEvent PropertyDataChanged(Reasons.InflowRate)
            Case sInflowMethod
                RaiseEvent PropertyDataChanged(Reasons.InflowMethod)
            Case sCutoffMethod
                RaiseEvent PropertyDataChanged(Reasons.CutoffMethod)
            Case sCutoffTime
                RaiseEvent PropertyDataChanged(Reasons.CutoffTime)
            Case sCutoffLocationRatio, sCutoffLocation, sRelativeCutoffDistance
                RaiseEvent PropertyDataChanged(Reasons.CutoffLocationRatio)
            Case sCutbackMethod
                RaiseEvent PropertyDataChanged(Reasons.CutbackMethod)
            Case sCutbackTime
                RaiseEvent PropertyDataChanged(Reasons.CutbackTimeRatio)
            Case sCutbackLocation
                RaiseEvent PropertyDataChanged(Reasons.CutbackLocationRatio)
            Case sCutbackRate
                RaiseEvent PropertyDataChanged(Reasons.CutbackRateRatio)
            Case sTabulatedInflow
                RaiseEvent PropertyDataChanged(Reasons.TabulatedInflow)
            Case sTabulatedRunoff
                RaiseEvent PropertyDataChanged(Reasons.TabulatedRunoff)
            Case sAdvance
                RaiseEvent PropertyDataChanged(Reasons.Advance)
            Case sRecession
                RaiseEvent PropertyDataChanged(Reasons.Recession)
            Case sOpportunityTime
                RaiseEvent PropertyDataChanged(Reasons.OpportunityTime)
            Case sPt1Dist, sPt1Time, sPt2Dist, sPt2Time
                RaiseEvent PropertyDataChanged(Reasons.TwoPointData)
            Case sFlowDepthsMeasured, sFlowDepthsUsed
                RaiseEvent PropertyDataChanged(Reasons.FieldMeasurements)
            Case Else
                RaiseEvent PropertyDataChanged(Reasons.Other)
        End Select
    End Sub

#End Region

End Class
