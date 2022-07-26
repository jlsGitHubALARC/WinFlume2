
'*************************************************************************************************************
' Event Criteria properties
'
' EventCriteria contains the Irrigation Event evaluation criteria. These criteria are DataStore properties
' that are unique to the Event Analysis World.
'*************************************************************************************************************
Imports DataStore

Public Class EventCriteria

#Region " Identification "
    '
    ' mMyID - unique object ID for DataStore
    '
    Private mMyID As String = "Event Criteria"
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

#Region " Member Data "
    '
    ' Enumeration flags to indicate how input data is used for Event Analyses.
    '
    ' Elliott-Walker, Merriam-Keller & EVALUE have varying requirements for how input data is used.  These
    ' enumerations are used to keep track of these variations.
    '
    Public Enum Prerequisites
        NotUsed                 ' Not used for Verification nor Volume Balance calculations
        Useful                  ' Useful    "        "
        UsefulVB                ' Useful    "        "      and    "      "         "
        Required                ' Required  "        "
        RequiredVB              ' Required  "        "      and    "      "         "
    End Enum

    Public GroupValueMethodSelections() As Selection =
        {New Selection("System Geometry", 0),
         New Selection("Roughness", 0),
         New Selection("Infiltration", 0),
         New Selection("Inflow / Runoff", 0)}

#End Region

#Region " Properties "
    '
    ' The status of how input data is used per Event Analysis type
    '
    Private mInflowPrereq As Prerequisites = Prerequisites.RequiredVB
    Public Property InflowPrereq() As Prerequisites
        Get
            Return mInflowPrereq
        End Get
        Set(ByVal value As Prerequisites)
            mInflowPrereq = value
        End Set
    End Property

    Private mRunoffPrereq As Prerequisites = Prerequisites.UsefulVB
    Public Property RunoffPrereq() As Prerequisites
        Get
            Return mRunoffPrereq
        End Get
        Set(ByVal value As Prerequisites)
            mRunoffPrereq = value
        End Set
    End Property

    Private mAdvancePrereq As Prerequisites = Prerequisites.UsefulVB
    Public Property AdvancePrereq() As Prerequisites
        Get
            Return mAdvancePrereq
        End Get
        Set(ByVal value As Prerequisites)
            mAdvancePrereq = value
        End Set
    End Property

    Private mRecessionPrereq As Prerequisites = Prerequisites.UsefulVB
    Public Property RecessionPrereq() As Prerequisites
        Get
            Return mRecessionPrereq
        End Get
        Set(ByVal value As Prerequisites)
            mRecessionPrereq = value
        End Set
    End Property

    Private mFlowDepthsPrereq As Prerequisites = Prerequisites.UsefulVB
    Public Property FlowDepthsPrereq() As Prerequisites
        Get
            Return mFlowDepthsPrereq
        End Get
        Set(ByVal value As Prerequisites)
            mFlowDepthsPrereq = value
        End Set
    End Property

#End Region

#Region " Serialized Properties "

#Region " Sensitivity Analysis "

    '*********************************************************************************************************
    ' Independent Variables
    '*********************************************************************************************************

    ' Independent Parameter 1 is always used, Independent Parameter 2 may or may not  be used
    Public Const sNumIndependentVariables As String = "Num Independent Variables"

    Public ReadOnly Property NumIndependentVariablesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNumIndependentVariables)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(1)
                mMyStore.AddProperty(sNumIndependentVariables, _integer)
                _propertyNode = mMyStore.GetProperty(sNumIndependentVariables)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property NumIndependentVariables() As IntegerParameter
        Get
            Return NumIndependentVariablesProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            NumIndependentVariablesProperty.SetParameter(Value)
        End Set
    End Property
    ' 
    ' Independent Variable 1
    '
    Public Const sIndep1ParamGroup As String = "Indep 1 Param Group"

    Public ReadOnly Property Indep1ParamGroupProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sIndep1ParamGroup)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(0)
                mMyStore.AddProperty(sIndep1ParamGroup, _integer)
                _propertyNode = mMyStore.GetProperty(sIndep1ParamGroup)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Indep1ParamGroup() As IntegerParameter
        Get
            Return Indep1ParamGroupProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            Indep1ParamGroupProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sIndep1SelectedParameter As String = "Indep 1 Selected Parameter"

    Public ReadOnly Property Indep1ParamValueProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sIndep1SelectedParameter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(0)
                mMyStore.AddProperty(sIndep1SelectedParameter, _integer)
                _propertyNode = mMyStore.GetProperty(sIndep1SelectedParameter)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Indep1SelectedParameter() As IntegerParameter
        Get
            Return Indep1ParamValueProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            Indep1ParamValueProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sMinIdepen1Parameter As String = "Min Indep 1 Parameter"

    Public ReadOnly Property MinIndepParameter1Property As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinIdepen1Parameter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As DoubleParameter = New DoubleParameter(10)
                mMyStore.AddProperty(sMinIdepen1Parameter, _integer)
                _propertyNode = mMyStore.GetProperty(sMinIdepen1Parameter)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MinIndep1SelectedParameter() As DoubleParameter
        Get
            Return MinIndepParameter1Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MinIndepParameter1Property.SetParameter(Value)
        End Set
    End Property

    Public Const sMaxIdepen1Parameter As String = "Max Indep 1 Parameter"

    Public ReadOnly Property MaxIndepParameter1Property As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaxIdepen1Parameter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As DoubleParameter = New DoubleParameter(100)
                mMyStore.AddProperty(sMaxIdepen1Parameter, _integer)
                _propertyNode = mMyStore.GetProperty(sMaxIdepen1Parameter)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MaxIndep1SelectedParameter() As DoubleParameter
        Get
            Return MaxIndepParameter1Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaxIndepParameter1Property.SetParameter(Value)
        End Set
    End Property

    Public Const sNumIndep1Parameter1Incs As String = "Num Indep 1 Parameter Increments"

    Public ReadOnly Property NumIndepParameter1Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNumIndep1Parameter1Incs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(10)
                mMyStore.AddProperty(sNumIndep1Parameter1Incs, _integer)
                _propertyNode = mMyStore.GetProperty(sNumIndep1Parameter1Incs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property NumIndepParameter1() As IntegerParameter
        Get
            Return NumIndepParameter1Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            NumIndepParameter1Property.SetParameter(Value)
        End Set
    End Property
    ' 
    ' Independent Variable 2
    '
    Public Const sIndep2ParamGroup As String = "Indep 2 Param Group"

    Public ReadOnly Property Indep2ParamGroupProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sIndep2ParamGroup)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(0)
                mMyStore.AddProperty(sIndep2ParamGroup, _integer)
                _propertyNode = mMyStore.GetProperty(sIndep2ParamGroup)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Indep2ParamGroup() As IntegerParameter
        Get
            Return Indep2ParamGroupProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            Indep2ParamGroupProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sIndep2SelectedParameter As String = "Indep 2 Selected Parameter"

    Public ReadOnly Property Indep2ParamValueProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sIndep2SelectedParameter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(0)
                mMyStore.AddProperty(sIndep2SelectedParameter, _integer)
                _propertyNode = mMyStore.GetProperty(sIndep2SelectedParameter)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property Indep2SelectedParameter() As IntegerParameter
        Get
            Return Indep2ParamValueProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            Indep2ParamValueProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sMinIdepen2Parameter As String = "Min Indep 2 Parameter"

    Public ReadOnly Property MinIndepParameter2Property As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMinIdepen2Parameter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As DoubleParameter = New DoubleParameter(20)
                mMyStore.AddProperty(sMinIdepen2Parameter, _integer)
                _propertyNode = mMyStore.GetProperty(sMinIdepen2Parameter)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MinIndep2SelectedParameter() As DoubleParameter
        Get
            Return MinIndepParameter2Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MinIndepParameter2Property.SetParameter(Value)
        End Set
    End Property

    Public Const sMaxIdepen2Parameter As String = "Max Indep 2 Parameter"

    Public ReadOnly Property MaxIndepParameter2Property As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMaxIdepen2Parameter)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As DoubleParameter = New DoubleParameter(200)
                mMyStore.AddProperty(sMaxIdepen2Parameter, _integer)
                _propertyNode = mMyStore.GetProperty(sMaxIdepen2Parameter)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property MaxIndep2SelectedParameter() As DoubleParameter
        Get
            Return MaxIndepParameter2Property.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            MaxIndepParameter2Property.SetParameter(Value)
        End Set
    End Property

    Public Const sNumIndep2ParameterIncs As String = "Num Indep 2 Parameter Increments"

    Public ReadOnly Property NumIndepParameter2Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNumIndep2ParameterIncs)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(10)
                mMyStore.AddProperty(sNumIndep2ParameterIncs, _integer)
                _propertyNode = mMyStore.GetProperty(sNumIndep2ParameterIncs)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property NumIndep2Parameter() As IntegerParameter
        Get
            Return NumIndepParameter2Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            NumIndepParameter2Property.SetParameter(Value)
        End Set
    End Property

    '*********************************************************************************************************
    ' Dependent Variables
    '*********************************************************************************************************

    Public Const sNumDependentVariables As String = "Num Dependent Variables"

    Public ReadOnly Property NumDependentVariablesProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNumDependentVariables)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(1)
                mMyStore.AddProperty(sNumDependentVariables, _integer)
                _propertyNode = mMyStore.GetProperty(sNumDependentVariables)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property NumDependentVariables() As IntegerParameter
        Get
            Return NumDependentVariablesProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            NumDependentVariablesProperty.SetParameter(Value)
        End Set
    End Property
    ' 
    ' Dependent Variable 1
    '
    Public Const sDepParamGroup1 As String = "Dep Param Group 1"

    Public ReadOnly Property DepParamGroup1Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepParamGroup1)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(1)
                mMyStore.AddProperty(sDepParamGroup1, _integer)
                _propertyNode = mMyStore.GetProperty(sDepParamGroup1)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepParamGroup1() As IntegerParameter
        Get
            Return DepParamGroup1Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DepParamGroup1Property.SetParameter(Value)
        End Set
    End Property

    Public Const sDepSelectedParameter1 As String = "Dep Selected Parameter 1"

    Public ReadOnly Property DepSelectedParameter1Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepSelectedParameter1)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(1)
                mMyStore.AddProperty(sDepSelectedParameter1, _integer)
                _propertyNode = mMyStore.GetProperty(sDepSelectedParameter1)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepSelectedParameter1() As IntegerParameter
        Get
            Return DepSelectedParameter1Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DepSelectedParameter1Property.SetParameter(Value)
        End Set
    End Property
    ' 
    ' Dependent Variable 2
    '
    Public Const sDepParamGroup2 As String = "Dep Param Group 2"

    Public ReadOnly Property DepParamGroup2Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepParamGroup2)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(1)
                mMyStore.AddProperty(sDepParamGroup2, _integer)
                _propertyNode = mMyStore.GetProperty(sDepParamGroup2)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepParamGroup2() As IntegerParameter
        Get
            Return DepParamGroup2Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DepParamGroup2Property.SetParameter(Value)
        End Set
    End Property

    Public Const sDepSelectedParameter2 As String = "Dep Selected Parameter 2"

    Public ReadOnly Property DepSelectedParameter2Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepSelectedParameter2)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(1)
                mMyStore.AddProperty(sDepSelectedParameter2, _integer)
                _propertyNode = mMyStore.GetProperty(sDepSelectedParameter2)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepSelectedParameter2() As IntegerParameter
        Get
            Return DepSelectedParameter2Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DepSelectedParameter2Property.SetParameter(Value)
        End Set
    End Property
    ' 
    ' Dependent Variable 3
    '
    Public Const sDepParamGroup3 As String = "Dep Param Group 3"

    Public ReadOnly Property DepParamGroup3Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepParamGroup3)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(1)
                mMyStore.AddProperty(sDepParamGroup3, _integer)
                _propertyNode = mMyStore.GetProperty(sDepParamGroup3)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepParamGroup3() As IntegerParameter
        Get
            Return DepParamGroup3Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DepParamGroup3Property.SetParameter(Value)
        End Set
    End Property

    Public Const sDepSelectedParameter3 As String = "Dep Selected Parameter 3"

    Public ReadOnly Property DepSelectedParameter3Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepSelectedParameter3)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(3)
                mMyStore.AddProperty(sDepSelectedParameter3, _integer)
                _propertyNode = mMyStore.GetProperty(sDepSelectedParameter3)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepSelectedParameter3() As IntegerParameter
        Get
            Return DepSelectedParameter3Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DepSelectedParameter3Property.SetParameter(Value)
        End Set
    End Property
    ' 
    ' Dependent Variable 4
    '
    Public Const sDepParamGroup4 As String = "Dep Param Group 4"

    Public ReadOnly Property DepParamGroup4Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepParamGroup4)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(4)
                mMyStore.AddProperty(sDepParamGroup4, _integer)
                _propertyNode = mMyStore.GetProperty(sDepParamGroup4)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepParamGroup4() As IntegerParameter
        Get
            Return DepParamGroup4Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DepParamGroup4Property.SetParameter(Value)
        End Set
    End Property

    Public Const sDepSelectedParameter4 As String = "Dep Selected Parameter 4"

    Public ReadOnly Property DepSelectedParameter4Property() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sDepSelectedParameter4)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _integer As IntegerParameter = New IntegerParameter(1)
                mMyStore.AddProperty(sDepSelectedParameter4, _integer)
                _propertyNode = mMyStore.GetProperty(sDepSelectedParameter4)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property DepSelectedParameter4() As IntegerParameter
        Get
            Return DepSelectedParameter4Property.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            DepSelectedParameter4Property.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Event Analysis Type "

    Private Const sEventAnalysisType As String = "Event Analysis Type"

    Public ReadOnly Property EventAnalysisTypeProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEventAnalysisType)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultEventAnalysisType)
                mMyStore.AddProperty(sEventAnalysisType, _parameter)
                _propertyNode = mMyStore.GetProperty(sEventAnalysisType)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property EventAnalysisType() As IntegerParameter
        Get
            Return EventAnalysisTypeProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            EventAnalysisTypeProperty.SetParameter(Value)
        End Set
    End Property

    ' Return the text selections for Event Analysis Type
    Private mEventAnalysisTypeIndex As Integer = -1
    Public Function GetFirstEventAnalysisTypeSelection() As String
        mEventAnalysisTypeIndex = -1
        Return GetNextEventAnalysisTypeSelection()
    End Function

    Public Function GetNextEventAnalysisTypeSelection() As String
        Dim _worldType As WorldTypes = CType(mUnit.UnitType.Value, WorldTypes)
        Dim _userLevel As UserLevels = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef.UserLevel
        Dim _flags As SelFlags = GetSelFlags(_worldType, mUnit.CrossSection, _userLevel)

        mEventAnalysisTypeIndex += 1
        If (mEventAnalysisTypeIndex < EventAnalysisTypes.HighLimit) Then
            If ((EventAnalysisTypeSelections(mEventAnalysisTypeIndex).Flags And _flags) = 0) Then
                Return EventAnalysisTypeSelections(mEventAnalysisTypeIndex).Value
            Else
                Return String.Empty
            End If
        End If
        Return Nothing
    End Function

#End Region

#Region " Infiltration "
    '
    ' Standard vs. Advanced Infiltration Function Group
    '
    Public Const sAdvFunctionsSelected As String = "Adv Functions Selected"

    Public ReadOnly Property AdvFunctionsSelectedProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvFunctionsSelected)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim advFuncs As Boolean = False
                Dim defInfFunc As InfiltrationFunctions = mUnit.SoilCropPropertiesRef.InfiltrationFunction.Value
                If ((defInfFunc = InfiltrationFunctions.GreenAmpt) _
                 Or (defInfFunc = InfiltrationFunctions.WarrickGreenAmpt)) Then
                    advFuncs = True
                End If
                Dim _boolean As BooleanParameter = New BooleanParameter(advFuncs)
                mMyStore.AddProperty(sAdvFunctionsSelected, _boolean)
                _propertyNode = mMyStore.GetProperty(sAdvFunctionsSelected)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property AdvFunctionsSelected() As BooleanParameter
        Get
            Return AdvFunctionsSelectedProperty.GetBooleanParameter()
        End Get
        Set(ByVal Value As BooleanParameter)
            AdvFunctionsSelectedProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Standard Infiltration Function (currently used by EVALUE only - 01/26/2016)
    '
    ' Note - For EVALUE, the Infiltration Functions are grouped into Standard & Advanced categories.
    '        When a switch between Standard & Advance occurs or when a selection in a group changes,
    '        the 'real' Infiltration Function found in SoilCropProperties must reflect the change.
    '
    Public Const sStdInfiltrationFunction As String = "Std Infiltration Function"

    Public ReadOnly Property StdInfiltrationFunctionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sStdInfiltrationFunction)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim defInfFunc As InfiltrationFunctions = mUnit.SoilCropPropertiesRef.InfiltrationFunction.Value
                If ((defInfFunc = InfiltrationFunctions.GreenAmpt) _
                 Or (defInfFunc = InfiltrationFunctions.Hydrus1D) _
                 Or (defInfFunc = InfiltrationFunctions.WarrickGreenAmpt)) Then
                    defInfFunc = InfiltrationFunctions.ModifiedKostiakovFormula
                End If
                Dim _integer As IntegerParameter = New IntegerParameter(defInfFunc)
                mMyStore.AddProperty(sStdInfiltrationFunction, _integer)
                _propertyNode = mMyStore.GetProperty(sStdInfiltrationFunction)
            End If

            _propertyNode.EventsEnabled = False

            Return _propertyNode
        End Get
    End Property

    Public Property StdInfiltrationFunction() As IntegerParameter
        Get
            Return StdInfiltrationFunctionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            StdInfiltrationFunctionProperty.SetParameter(Value)
        End Set
    End Property

    ' Standard Wetted Perimeter (currently used by EVALUE only - 01/26/2016)
    Public Const sStdWettedPerimeterMethod As String = "Std Wetted Perimeter Method"

    Public ReadOnly Property StdWettedPerimeterMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sStdWettedPerimeterMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim defWP As WettedPerimeterMethods = mUnit.SoilCropPropertiesRef.WettedPerimeterMethod.Value
                If ((defWP = WettedPerimeterMethods.AtNormalInflowDepth) _
                 Or (defWP = WettedPerimeterMethods.LocalWettedPerimeter)) Then
                    defWP = WettedPerimeterMethods.FurrowSpacing
                End If
                Dim _integer As IntegerParameter = New IntegerParameter(defWP)
                mMyStore.AddProperty(sStdWettedPerimeterMethod, _integer)
                _propertyNode = mMyStore.GetProperty(sStdWettedPerimeterMethod)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property StdWettedPerimeterMethod() As IntegerParameter
        Get
            Return StdWettedPerimeterMethodProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            StdWettedPerimeterMethodProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Advanced Infiltration Function (currently used by EVALUE only - 01/26/2016)
    '
    ' See Standard Infiltration Function note above
    '
    Public Const sAdvInfiltrationFunction As String = "Adv Infiltration Function"

    Public ReadOnly Property AdvInfiltrationFunctionProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sAdvInfiltrationFunction)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim defInfFunc As InfiltrationFunctions = InfiltrationFunctions.GreenAmpt
                If (mUnit.CrossSection = CrossSections.Furrow) Then
                    defInfFunc = InfiltrationFunctions.WarrickGreenAmpt
                End If
                Dim _integer As IntegerParameter = New IntegerParameter(defInfFunc)
                mMyStore.AddProperty(sAdvInfiltrationFunction, _integer)
                _propertyNode = mMyStore.GetProperty(sAdvInfiltrationFunction)
            End If

            _propertyNode.EventsEnabled = False

            Return _propertyNode
        End Get
    End Property

    Public Property AdvInfiltrationFunction() As IntegerParameter
        Get
            Return AdvInfiltrationFunctionProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            AdvInfiltrationFunctionProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Reference Flow Rate "

    Public Const sReferenceFlowRate As String = "Reference Flow Rate"

    Public ReadOnly Property ReferenceFlowRateProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sReferenceFlowRate)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _defaultFlowRate As Double = mUnit.InflowManagementRef.AverageInflowRateForCrossSection
                Dim _parameter As DoubleParameter = New DoubleParameter(_defaultFlowRate, Units.Lps)
                mMyStore.AddProperty(sReferenceFlowRate, _parameter)
                _propertyNode = mMyStore.GetProperty(sReferenceFlowRate)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ReferenceFlowRate() As DoubleParameter
        Get
            Return ReferenceFlowRateProperty.GetDoubleParameter()
        End Get
        Set(ByVal Value As DoubleParameter)
            ReferenceFlowRateProperty.SetParameter(Value)
        End Set
    End Property

    Public Const sReferenceFlowRateSet As String = "Reference Flow Rate Set"

    Public ReadOnly Property ReferenceFlowRateSetProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sReferenceFlowRateSet)
            If (_propertyNode Is Nothing) Then ' Property does not exist; add it
                Dim _referenceInflowSet As BooleanParameter = New BooleanParameter(False)
                mMyStore.AddProperty(sReferenceFlowRateSet, _referenceInflowSet)
                _propertyNode = mMyStore.GetProperty(sReferenceFlowRateSet)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property ReferenceFlowRateSet() As BooleanParameter
        Get
            Return ReferenceFlowRateSetProperty.GetBooleanParameter()
        End Get
        Set(ByVal value As BooleanParameter)
            ReferenceFlowRateSetProperty.SetParameter(value)
        End Set
    End Property

#End Region

#Region " Surface Volume Summary "
    '
    ' This property is used to compare "Measured" surface volumes to predicted surface volumes.
    ' It is not to be used to compare "Estimated" surface volumes to predicted surface volumes.
    '
    Public Const sSurfaceVolumeSummary As String = "Surface Volume Summary"

    Public ReadOnly Property SurfaceVolumeSummaryProperty() As PropertyNode
        Get
            ' Define reset Volume Summary table
            Dim _VySummary As DataTable = New DataTable(sSurfaceVolumeSummary)
            ResetSurfaceVolumeSummary(_VySummary)

            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSurfaceVolumeSummary)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _tableParameter As DataTableParameter = New DataTableParameter(_VySummary)
                mMyStore.AddProperty(sSurfaceVolumeSummary, _tableParameter)
                _propertyNode = mMyStore.GetProperty(sSurfaceVolumeSummary)
            Else ' it was found; validate its contents (i.e. bring up-to-date)
                Dim _parameter As Parameter = _propertyNode.GetParameter
                Dim _tableParameter As DataTableParameter = DirectCast(_parameter, DataTableParameter)
                If (_tableParameter.Value.Columns.Contains(sTimeX)) Then ' table is up-to-date
                    CalculateSurfaceVolumeSummary(_tableParameter.Value)
                Else
                    _tableParameter.Value = _VySummary
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SurfaceVolumeSummary() As DataTableParameter
        Get
            Return SurfaceVolumeSummaryProperty.GetDataTableParameter()
        End Get
        Set(ByVal value As DataTableParameter)
            SurfaceVolumeSummaryProperty.SetParameter(value)
        End Set
    End Property
    '
    ' Reset volume balances table
    '
    Public Sub ResetSurfaceVolumeSummary(ByVal SurfaceVolumeSummary As DataTable)

        SurfaceVolumeSummary.Columns.Clear()                            ' Remove previous data
        SurfaceVolumeSummary.Rows.Clear()

        SurfaceVolumeSummary.Columns.Add(sTimeX, GetType(Double))       ' Add columns
        SurfaceVolumeSummary.Columns.Add(sDistanceX, GetType(Double))
        SurfaceVolumeSummary.Columns.Add(sVyMeas, GetType(Double))
        SurfaceVolumeSummary.Columns.Add(sVyPred, GetType(Double))
        SurfaceVolumeSummary.Columns.Add(sBeta, GetType(Double))
        '
        ' The Measurement Station table contains the distances for the Surface Volume summary
        '
        Dim inflowManagement As InflowManagement = mUnit.InflowManagementRef
        Dim depthHydrographs As DataSet = inflowManagement.StationsFlowDepths.Value

        Dim systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
        Dim W As Double = systemGeometry.WidthForCrossSection
        Dim S0 As Double = systemGeometry.AverageSlope

        Dim measStations As DataTable = inflowManagement.MeasurementStations.Value
        If (measStations.Rows IsNot Nothing) Then
            For Each stationRow As DataRow In measStations.Rows
                Dim Xadv As Double = stationRow.Item(sDistanceX)
                Dim Tadv As Double = inflowManagement.Tadv(Xadv)
                Dim Beta As Double = mUnit.Beta(S0)

                If (Tadv <= inflowManagement.Cutoff) Then
                    Dim svRow As DataRow = SurfaceVolumeSummary.NewRow
                    svRow.Item(sTimeX) = Tadv
                    svRow.Item(sDistanceX) = Xadv
                    svRow.Item(sVyMeas) = 0.0
                    svRow.Item(sVyPred) = 0.0
                    svRow.Item(sBeta) = Beta
                    SurfaceVolumeSummary.Rows.Add(svRow)
                End If

            Next stationRow
        End If

    End Sub

    Public Function CalculateSurfaceVolumeSummary(ByVal SurfaceVolumeSummary As DataTable) As Boolean
        CalculateSurfaceVolumeSummary = True

        Try
            ' Get the data required for the calculations
            Dim inflowManagement As InflowManagement = mUnit.InflowManagementRef
            Dim depthHydrographs As DataSet = inflowManagement.StationsFlowDepths.Value

            Dim systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
            Dim W As Double = systemGeometry.WidthForCrossSection
            Dim S0 As Double = systemGeometry.AverageSlope
            '
            ' Re-calculate the Surface Volumes
            '
            For Each svRow As DataRow In SurfaceVolumeSummary.Rows
                Dim Xadv As Double = svRow.Item(sDistanceX)
                Dim Tadv As Double = inflowManagement.Tadv(Xadv)
                Dim Beta As Double = svRow.Item(sBeta)

                Dim Qin As Double = inflowManagement.InflowRateAtTimeForCrossSection(Tadv)
                Dim Sy As Double = mUnit.SigmaY(Qin, Xadv, W, S0, Beta)

                Dim VyMeas As Double = inflowManagement.MeasuredSurfaceVolume(Tadv, depthHydrographs)
                Dim VyPred As Double = inflowManagement.PredictedSurfaceVolume(Tadv, Sy, Beta)

                svRow.Item(sVyMeas) = VyMeas
                svRow.Item(sVyPred) = VyPred

            Next svRow

        Catch ex As Exception
            CalculateSurfaceVolumeSummary = False
        End Try

    End Function

#End Region

#Region " Shape Factors "

#Region " Sigma Z "

    Private sSimSigmaZtable As String = "Sim Sigma Z Table"

    Public ReadOnly Property SimSigmaZtableProperty() As PropertyNode
        Get
            ' Define reset Surface Volume table
            Dim sigmaZs As DataTable = New DataTable(sSimSigmaZtable)
            ResetSimSigmaZtable(sigmaZs)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSimSigmaZtable, sigmaZs)

            Return _propertyNode
        End Get
    End Property

    Public Property SimSigmaZtable() As DataTableParameter
        Get
            Dim _tableParameter As DataTableParameter = SimSigmaZtableProperty.GetDataTableParameter()
            Return _tableParameter
        End Get
        Set(ByVal Value As DataTableParameter)
            SimSigmaZtableProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Reset/calculate volume balances table
    '
    Public Sub ResetSimSigmaZtable(ByVal SigmaZtable As DataTable)
        SigmaZtable.Columns.Clear()                        ' Remove previous data
        SigmaZtable.Rows.Clear()

        SigmaZtable.Columns.Add(sTimeX, GetType(Double))   ' Add columns but no rows
        SigmaZtable.Columns.Add(sSigmaZ, GetType(Double))
    End Sub

#End Region

#End Region

#Region " Estimated Surface Volumes "

    Private Const sEstimatedSurfaceVolumes As String = "Estimated Surface Volumes"

    Public ReadOnly Property EstimatedSurfaceVolumesProperty() As PropertyNode
        Get
            ' Define reset Surface Volume table
            Dim _surfaceVolumes As DataTable = New DataTable(sEstimatedSurfaceVolumes)
            ResetEstimatedSurfaceVolumes(_surfaceVolumes)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEstimatedSurfaceVolumes, _surfaceVolumes)

            If (_surfaceVolumes.Columns.Contains(sAdvanceX)) Then
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _tableParam As DataTableParameter = DirectCast(_param, DataTableParameter)
                _surfaceVolumes = _tableParam.Value
                ResetEstimatedSurfaceVolumes(_surfaceVolumes)
            End If

            If (_surfaceVolumes.Columns.Contains(sBeta)) Then
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _tableParam As DataTableParameter = DirectCast(_param, DataTableParameter)
                _surfaceVolumes = _tableParam.Value
                _surfaceVolumes.Columns.Remove(sBeta)
            End If

            CalculateEstimatedSurfaceVolumes(_surfaceVolumes)
            Return _propertyNode
        End Get
    End Property

    Public Property EstimatedSurfaceVolumes() As DataTableParameter
        Get
            Dim _tableParameter As DataTableParameter = EstimatedSurfaceVolumesProperty.GetDataTableParameter()
            Return _tableParameter
        End Get
        Set(ByVal Value As DataTableParameter)
            EstimatedSurfaceVolumesProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Reset/calculate volume balances table
    '
    Public Sub ResetEstimatedSurfaceVolumes(ByVal SurfaceVolumes As DataTable)

        SurfaceVolumes.Columns.Clear()                        ' Remove previous data
        SurfaceVolumes.Rows.Clear()

        SurfaceVolumes.Columns.Add(sTimeX, GetType(Double))   ' Add columns but no rows
        SurfaceVolumes.Columns.Add(sDistX, GetType(Double))
        SurfaceVolumes.Columns.Add(sQinX, GetType(Double))
        SurfaceVolumes.Columns.Add(sY0, GetType(Double))
        SurfaceVolumes.Columns.Add(sAY0, GetType(Double))
        SurfaceVolumes.Columns.Add(sSigmaY, GetType(Double))
        SurfaceVolumes.Columns.Add(sVy, GetType(Double))

    End Sub

    Public Function CalculateEstimatedSurfaceVolumes(ByVal SurfaceVolumes As DataTable) As Boolean
        CalculateEstimatedSurfaceVolumes = True
        '
        ' The Volume Balances table contains the Times required by the Estimated Surface Volumes table.
        '
        Dim inflowManagement As InflowManagement = mUnit.InflowManagementRef
        Dim TL As Double = inflowManagement.TL
        Dim Tco As Double = inflowManagement.Cutoff
        Dim MaxTadv As Double = inflowManagement.MaxAdvanceTime

        Dim systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
        Dim S0 As Double = systemGeometry.AverageSlope
        Dim beta As Double = mUnit.Beta(S0)
        Dim L As Double = systemGeometry.Length.Value
        Dim W As Double = systemGeometry.WidthForCrossSection
        '
        ' For times in the Volume Balances table that are already in the Estimated Surface Volumes table,
        ' the Sigma Y values must be maintained.
        '
        ' For times in the Volume Balances table that are NOT in the Estimated Surface Volumes table, a
        ' new entry must be added with its Sigma Y value set to default.
        '
        ' Times in the Estimated Surface Volumes table that are NOT in the Volume Balances table should
        ' be discarded.
        '
        ' Once the new list of Time & Sigma Y values is set, the remainder of the items are calculated. The
        ' new list of Estimated Surface Volumes times must match the Volume Balances times.
        '
        Dim svCopy As DataTable = SurfaceVolumes.Copy   ' Get a copy of the current SurfaceVolumes table
        '
        ' Clear then rebuild the SurfaceVolumes table.
        '
        SurfaceVolumes.Rows.Clear()
        '
        ' Scan the Volume Balances table adding a row to the Surface Volumes table for each time.
        '
        Dim vbTable As DataTable = Nothing
        Dim prop As PropertyNode = mMyStore.GetProperty(sVolumeBalances)
        If (prop IsNot Nothing) Then
            Dim param As Parameter = prop.GetParameter
            If (param IsNot Nothing) Then
                If (param.GetType Is GetType(DataTableParameter)) Then
                    Dim vbParam As DataTableParameter = DirectCast(param, DataTableParameter)
                    vbTable = vbParam.Value
                End If
            End If
        End If

        If (vbTable IsNot Nothing) Then
            For Each vbRow As DataRow In vbTable.Rows
                Dim vbTime As Double = vbRow.Item(nTimeX) ' Use integer index not string index (i.e. sTimeX)
                Dim Qin As Double = inflowManagement.AverageInflowRateForCrossSection(vbTime)
                If (Tco < vbTime) Then ' appears to be past Cutoff
                    If (vbTime < Tco + OneSecond) Then ' considered at Cutoff
                        vbTime = Tco ' set to Cutoff
                    Else ' past Cutoff; no Inflow
                        Qin = 0.0
                    End If
                End If
                Dim Xa As Double = 0.0 ' Advance distance
                Dim Sy As Double = 0.0 ' Sigma Y

                Dim svRow As DataRow = GetDataRow(svCopy, nTimeX, vbTime, OneSecond)

                ' First, assume time is prior to recession
                If (Double.IsNaN(TL)) Then ' Advance did not reach the end of the field

                    If (vbTime <= MaxTadv) Then ' Advance phase time

                        Xa = inflowManagement.Xadv(vbTime)
                        If (svRow Is Nothing) Then ' Surface Volume time is not in Volume Balances table
                            beta = mUnit.Beta(S0) ' use default Beta to calculate Sy
                            Sy = mUnit.SigmaY(Qin, Xa, W, S0, beta)
                        Else
                            Sy = svRow.Item(sSigmaY) ' use Sy from table to calculate Beta
                            beta = mUnit.Beta(Sy, Qin, Xa, W, S0)
                        End If

                    End If

                Else ' Advance reached the end of the field

                    If (vbTime <= TL) Then ' Advance phase time

                        Xa = inflowManagement.Xadv(vbTime)
                        If (svRow Is Nothing) Then ' Surface Volume time is not in Volume Balances table
                            beta = mUnit.Beta(S0) ' use default Beta to calculate Sy
                            Sy = mUnit.SigmaY(Qin, Xa, W, S0, beta)
                        Else
                            Sy = svRow.Item(sSigmaY) ' use Sy from table to calculate Beta
                            beta = mUnit.Beta(Sy, Qin, Xa, W, S0)
                        End If

                    Else ' Post-advance phase time

                        Xa = inflowManagement.Xpa(vbTime)
                        If (Xa <= L) Then ' Xpa() failed to calculate advance past L
                            Xa = L ' Xa minimum is L
                            If (svRow Is Nothing) Then ' Surface Volume time is not in Volume Balances table
                                beta = mUnit.Beta(S0) ' use default Beta to calculate Sy
                                Sy = mUnit.SigmaY(Qin, Xa, W, S0, beta)
                            Else
                                Sy = svRow.Item(sSigmaY) ' use Sy from table to calculate Beta
                                beta = mUnit.Beta(Sy, Qin, Xa, W, S0)
                            End If
                        Else ' Valid value (L < Xa) from Xpa()
                            If (svRow Is Nothing) Then ' Surface Volume time is not in Volume Balances table
                                beta = mUnit.Beta(S0) ' use default Beta to calculate Sy
                                Sy = mUnit.SigmaYpa(Qin, Xa, L, W, S0, beta) ' calculate Sy using 'SigmaYpa' method
                                beta = mUnit.Beta(Sy, Qin, Xa, W, S0) ' get Beta that matches 'SigmaY' method
                            Else
                                Sy = svRow.Item(sSigmaY) ' use Sy from table to calculate Beta
                                beta = mUnit.Beta(Sy, Qin, Xa, W, S0)
                            End If
                        End If

                    End If
                End If

                ' Time might actually be after recession has completed
                If (inflowManagement.RecessionDataAvailable) Then
                    Dim TrecMax As Double = inflowManagement.MaxRecessionTime
                    If (TrecMax <= vbTime) Then ' time is after recession, only PIVB applies
                        Xa = L
                        Sy = 0.0
                        beta = 0.0
                    End If
                End If

                ' Get the upstream parameters for this time
                Dim Y0, AY0, R0, WP0, Sf0 As Double
                mUnit.UpstreamParameters(Qin, Xa, W, S0, Y0, AY0, R0, WP0, Sf0, beta)

                ' Calculate surface volume
                If (Xa > L) Then
                    Xa = L
                End If
                Dim Vy As Double = Sy * AY0 * Xa                                    ' Equation 3

                ' Save inputs & results of calculation in DataTable
                svRow = SurfaceVolumes.NewRow
                svRow.Item(0) = vbTime  ' Indeces must match order defined in ResetEstimatedSurfaceVolumes()
                svRow.Item(1) = Xa
                svRow.Item(2) = Qin
                svRow.Item(3) = Y0
                svRow.Item(4) = AY0
                svRow.Item(5) = Sy
                svRow.Item(6) = Vy
                SurfaceVolumes.Rows.Add(svRow)
            Next vbRow
        Else
            ResetEstimatedSurfaceVolumes(SurfaceVolumes)
        End If

    End Function
    '
    ' Validate estimated volume balances table
    '
    Public Function ValidateEstimatedSurfaceVolumes(ByVal SurfaceVolumes As DataTable) As Boolean

        SurfaceVolumes.Columns.Clear()                        ' Remove previous data
        SurfaceVolumes.Rows.Clear()

        SurfaceVolumes.Columns.Add(sTimeX, GetType(Double))   ' Add columns but no rows
        SurfaceVolumes.Columns.Add(sDistX, GetType(Double))
        SurfaceVolumes.Columns.Add(sQinX, GetType(Double))
        SurfaceVolumes.Columns.Add(sY0, GetType(Double))
        SurfaceVolumes.Columns.Add(sAY0, GetType(Double))
        SurfaceVolumes.Columns.Add(sSigmaY, GetType(Double))
        SurfaceVolumes.Columns.Add(sVy, GetType(Double))

    End Function

#End Region

#Region " EW 2-Pt Estimated Surface Volumes "

    Private Const sEW2ptEstimatedSurfaceVolumes As String = "EW 2-Pt Estimated Surface Volumes"

    Public ReadOnly Property EW2ptEstimatedSurfaceVolumesProperty() As PropertyNode
        Get
            Dim _surfaceVolumes As DataTable = Nothing
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sEW2ptEstimatedSurfaceVolumes)
            If (_propertyNode Is Nothing) Then
                ' Define reset Surface Volume table
                _surfaceVolumes = New DataTable(sEW2ptEstimatedSurfaceVolumes)
                Dim _source As ValueSources = ResetEW2ptEstimatedSurfaceVolumes(_surfaceVolumes)
                Dim _tableParam As DataTableParameter = New DataTableParameter(_surfaceVolumes)
                _tableParam.Source = _source
                mMyStore.AddProperty(sEW2ptEstimatedSurfaceVolumes, _tableParam)
                _propertyNode = mMyStore.GetProperty(sEW2ptEstimatedSurfaceVolumes)
            Else
                Dim _param As Parameter = _propertyNode.GetParameter
                Dim _tableParam As DataTableParameter = DirectCast(_param, DataTableParameter)
                _surfaceVolumes = _tableParam.Value

                If (_surfaceVolumes.Columns.Contains(sAdvanceX)) Then
                    Dim _source As ValueSources = ResetEW2ptEstimatedSurfaceVolumes(_surfaceVolumes)
                    _tableParam.Source = _source
                End If

                If (_surfaceVolumes.Columns.Contains(sBeta)) Then
                    _surfaceVolumes.Columns.Remove(sBeta)
                End If

            End If

            CalculateEW2ptEstimatedSurfaceVolumes(_surfaceVolumes)
            Return _propertyNode
        End Get
    End Property

    Public Property EW2ptEstimatedSurfaceVolumes() As DataTableParameter
        Get
            Dim _tableParameter As DataTableParameter = EW2ptEstimatedSurfaceVolumesProperty.GetDataTableParameter()
            Return _tableParameter
        End Get
        Set(ByVal Value As DataTableParameter)
            EW2ptEstimatedSurfaceVolumesProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Reset volume balances table
    '
    Private Function ResetEW2ptEstimatedSurfaceVolumes(ByVal SurfaceVolumes As DataTable) As ValueSources
        ResetEW2ptEstimatedSurfaceVolumes = ValueSources.Defaulted

        SurfaceVolumes.Columns.Clear()                        ' Remove previous data
        SurfaceVolumes.Rows.Clear()

        SurfaceVolumes.Columns.Add(sTimeX, GetType(Double))   ' Add columns
        SurfaceVolumes.Columns.Add(sDistX, GetType(Double))
        SurfaceVolumes.Columns.Add(sQinX, GetType(Double))
        SurfaceVolumes.Columns.Add(sY0, GetType(Double))
        SurfaceVolumes.Columns.Add(sAY0, GetType(Double))
        SurfaceVolumes.Columns.Add(sSigmaY, GetType(Double))
        SurfaceVolumes.Columns.Add(sVy, GetType(Double))

        ' Add two rows, one for each point in the 2-Pt data
        Try
            Dim systemGeometry As SystemGeometry = mUnit.SystemGeometryRef
            Dim S0 As Double = systemGeometry.AverageSlope
            Dim W As Double = systemGeometry.WidthForCrossSection

            Dim inflowManagement As InflowManagement = mUnit.InflowManagementRef
            Dim twoPtTable As DataTable = inflowManagement.TwoPointTabulatedAdvance.Value

            ' Point 1
            Dim twoPtRow As DataRow = twoPtTable.Rows(1)
            Dim svRow As DataRow = SurfaceVolumes.NewRow

            Dim T As Double = twoPtRow.Item(nTimeX1)
            Dim Xa As Double = twoPtRow.Item(sDistanceX)
            Dim Qin As Double = inflowManagement.InflowRateAtTimeForCrossSection(T)

            Dim SigmaY As Double = mUnit.SigmaY(Qin, Xa, W, S0)

            If (systemGeometry.SurfaceShapeFactor1.Source = ValueSources.UserEntered) Then
                SigmaY = systemGeometry.SurfaceShapeFactor1.Value
                ResetEW2ptEstimatedSurfaceVolumes = ValueSources.UserEntered
            End If

            svRow.Item(sTimeX) = T
            svRow.Item(sDistX) = Xa
            svRow.Item(sQinX) = Qin
            svRow.Item(sY0) = 0.0
            svRow.Item(sAY0) = 0.0
            svRow.Item(sSigmaY) = SigmaY
            svRow.Item(sVy) = 0.0

            SurfaceVolumes.Rows.Add(svRow)

            ' Point 2
            twoPtRow = twoPtTable.Rows(2)
            svRow = SurfaceVolumes.NewRow

            T = twoPtRow.Item(nTimeX1)
            Xa = twoPtRow.Item(sDistanceX)
            Qin = inflowManagement.InflowRateAtTimeForCrossSection(T)

            SigmaY = mUnit.SigmaY(Qin, Xa, W, S0)

            If (systemGeometry.SurfaceShapeFactor2.Source = ValueSources.UserEntered) Then
                SigmaY = systemGeometry.SurfaceShapeFactor2.Value
                ResetEW2ptEstimatedSurfaceVolumes = ValueSources.UserEntered
            End If

            svRow.Item(sTimeX) = T
            svRow.Item(sDistX) = Xa
            svRow.Item(sQinX) = Qin
            svRow.Item(sY0) = 0.0
            svRow.Item(sAY0) = 0.0
            svRow.Item(sSigmaY) = SigmaY
            svRow.Item(sVy) = 0.0

            SurfaceVolumes.Rows.Add(svRow)

        Catch ex As Exception
        End Try

    End Function

    Public Function CalculateEW2ptEstimatedSurfaceVolumes(ByVal SurfaceVolumes As DataTable) As Boolean
        CalculateEW2ptEstimatedSurfaceVolumes = True
        '
        ' The Elliott-Walker Two-Point table contains two entries, one for each point
        '
        Dim inflowManagement As InflowManagement = mUnit.InflowManagementRef
        Dim systemGeometry As SystemGeometry = mUnit.SystemGeometryRef

        Dim S0 As Double = systemGeometry.AverageSlope
        Dim W As Double = systemGeometry.WidthForCrossSection
        '
        ' Recalculate the values in the SurfaceVolumes table.
        '
        Dim twoPtTable As DataTable = inflowManagement.TwoPointTabulatedAdvance.Value
        Dim twoPtIdx As Integer = 1

        For Each svRow As DataRow In SurfaceVolumes.Rows
            ' 2-Pt Table provides T & XA
            Dim twoPtRow As DataRow = twoPtTable.Rows(twoPtIdx)
            Dim T As Double = twoPtRow.Item(nTimeX1)
            Dim Xa As Double = twoPtRow.Item(sDistanceX)

            Dim Sy As Double = svRow.Item(sSigmaY)

            Dim Qavg As Double = inflowManagement.AverageInflowRateForCrossSection(T)
            Dim beta As Double = mUnit.Beta(Sy, Qavg, Xa, W, S0)

            ' Get the upstream parameters for this time
            Dim Y0 As Double = mUnit.UpstreamDepth(Qavg, Xa, W, S0, beta)
            Dim AY0 As Double = mUnit.UpstreamArea(Qavg, Xa, W, S0, beta)

            ' Calculate surface volume
            Dim Vy As Double = Sy * AY0 * Xa                                    ' Equation 3

            ' Save results of calculation in DataTable
            svRow.Item(0) = T
            svRow.Item(1) = Xa
            svRow.Item(2) = Qavg
            svRow.Item(sY0) = Y0
            svRow.Item(sAY0) = AY0
            svRow.Item(sSigmaY) = Sy
            svRow.Item(sVy) = Vy

            twoPtIdx += 1
        Next svRow

    End Function

#End Region

#Region " Volume Balances "
    '
    ' Volume Balances Table
    '
    Private Const sVolumeBalances As String = "Volume Balances"

    Public ReadOnly Property VolumeBalancesProperty() As PropertyNode
        Get
            ' Define reset Volume Balance table
            Dim _volumeBalances As DataTable = New DataTable(sVolumeBalances)
            ResetVolumeBalancesTable(_volumeBalances)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sVolumeBalances, _volumeBalances)
            CalculateVolumeBalances(_volumeBalances)
            Return _propertyNode
        End Get
    End Property

    Public Property VolumeBalances() As DataTableParameter
        Get
            Dim _tableParameter As DataTableParameter = VolumeBalancesProperty.GetDataTableParameter()
            Return _tableParameter
        End Get
        Set(ByVal Value As DataTableParameter)
            VolumeBalancesProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Reset volume balances table
    '
    Public Sub ResetVolumeBalancesTable(ByVal VolumeBalances As DataTable)

        VolumeBalances.Columns.Clear()                        ' Remove previous data
        VolumeBalances.Rows.Clear()

        VolumeBalances.Columns.Add(sTimeX, GetType(Double))   ' Add columns but no rows
        VolumeBalances.Columns.Add(sVin, GetType(Double))
        VolumeBalances.Columns.Add(sVy, GetType(Double))
        VolumeBalances.Columns.Add(sVro, GetType(Double))
        VolumeBalances.Columns.Add(sVz, GetType(Double))

    End Sub

    '*********************************************************************************************************
    ' Sub ReloadVolumeBalanceTimes() - reload Volume Balances table with specified Times
    '
    ' Input(s):     VolumeBalances  - table to clear and load with Times
    '               Times           - array of times to load into table (one Time initializes one row)
    '
    ' Output(s):    VolumeBalances  - table with only Time column defined
    '*********************************************************************************************************
    Public Sub ReloadVolumeBalanceTimes(ByVal VolumeBalances As DataTable, ByVal Times() As Double)
        If (Times IsNot Nothing) Then
            If (0 < Times.Length) Then

                ' Clear all rows from table
                VolumeBalances.Rows.Clear()

                ' Add row to table for each time in Times array
                For Each time As Double In Times
                    Dim vbRow As DataRow = VolumeBalances.NewRow
                    vbRow.Item(sTimeX) = time
                    VolumeBalances.Rows.Add(vbRow)
                Next time
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Function CalculateVolumeBalances() - load/calculate volume columns within input Volume Balances table
    '
    ' Input(s):     VolumeBalances  - Time column is specified; the remaining columns are loaded/calculated
    '
    ' Output(s):    VolumeBalances  - Volume columns loaded or calculated
    '
    ' Returns:      Boolean         - whether or not the calculations were successful
    '*********************************************************************************************************
    Public Function CalculateVolumeBalances(ByVal VolumeBalances As DataTable) As Boolean
        CalculateVolumeBalances = False

        ' Get Estimated Surface Volumes table, if needed
        Dim estimatedSurfaceVolumes As DataTable = Nothing
        Dim propNode As PropertyNode = Nothing

        If (Me.EventAnalysisType.Value = EventAnalysisTypes.TwoPointAnalysis) Then
            propNode = mMyStore.GetProperty(sEW2ptEstimatedSurfaceVolumes)
            If (propNode IsNot Nothing) Then
                Dim tableParam As DataTableParameter = propNode.GetDataTableParameter
                If (tableParam IsNot Nothing) Then
                    estimatedSurfaceVolumes = tableParam.Value
                    CalculateEW2ptEstimatedSurfaceVolumes(estimatedSurfaceVolumes)
                End If
            End If
        Else
            propNode = mMyStore.GetProperty(sEstimatedSurfaceVolumes)
            If (propNode IsNot Nothing) Then
                Dim tableParam As DataTableParameter = propNode.GetDataTableParameter
                If (tableParam IsNot Nothing) Then
                    estimatedSurfaceVolumes = tableParam.Value
                    If (estimatedSurfaceVolumes.Columns.Contains(sAdvanceX)) Then
                        ResetEstimatedSurfaceVolumes(estimatedSurfaceVolumes)
                    End If
                    CalculateEstimatedSurfaceVolumes(estimatedSurfaceVolumes)
                End If
            End If
        End If

        Try
            If (VolumeBalances IsNot Nothing) Then

                Dim inflowManagement As InflowManagement = mUnit.InflowManagementRef
                Dim systemGeometry As SystemGeometry = mUnit.SystemGeometryRef

                For Each balRow As DataRow In VolumeBalances.Rows

                    ' Get time from input VolumeBalance table
                    Dim T As Double = balRow.Item(nTimeX)

                    ' Vin is defined in Inflow Management (set by user)
                    Dim Vin As Double = inflowManagement.AppliedVolumeForCrossSection(T)

                    ' Vy may be measured, via flow depth hydrographs, or estimated
                    Dim Vy As Double = 0.0
                    If (inflowManagement.FlowDepthsMeasuredAndUsed()) Then ' use Measured surface volumes
                        If (T < inflowManagement.MaxRecessionTime()) Then
                            Dim depthHydrographs As DataSet = inflowManagement.StationsFlowDepths.Value
                            Vy = inflowManagement.MeasuredSurfaceVolume(T, depthHydrographs)
                        End If
                    Else ' use Estimated surface volumes
                        Dim estRow As DataRow = GetDataRow(estimatedSurfaceVolumes, nTimeX, T, OneSecond)
                        If (estRow IsNot Nothing) Then
                            Vy = CDbl(estRow.Item(sVy))
                        End If
                    End If

                    ' Vro is define in Inflow Management (set by user)
                    Dim Vro As Double = 0.0
                    Dim runoffInput As Boolean = inflowManagement.RunoffDataAvailable()
                    If (runoffInput) Then
                        Dim runoffUsed As Boolean = True
                        If (Me.EventAnalysisType.Value = EventAnalysisTypes.EvalueAnalysis) Then
                            runoffUsed = inflowManagement.RunoffUsed.Value
                        End If
                        If (runoffUsed) Then
                            Vro = inflowManagement.RunoffVolumeForCrossSection(T)
                        End If
                    End If

                    ' Calculate Vz to complete the Volume Balance
                    Dim Vz As Double = Vin - Vy - Vro

                    ' Save the loaded / calculated items into the table's DataRow
                    balRow.Item(sVin) = Vin
                    balRow.Item(sVy) = Vy
                    balRow.Item(sVro) = Vro
                    balRow.Item(sVz) = Vz

                Next balRow

                CalculateVolumeBalances = True
            End If

        Catch ex As Exception
            CalculateVolumeBalances = False
        End Try

    End Function

#End Region

#Region " Goodness-of-Fit "
    '
    ' Goodness-Of-Fit tables
    '
    Public Const sPBiasCurves As String = "PBIAS Curves"

    Public ReadOnly Property PBiasCurvesProperty() As PropertyNode
        Get
            ' Get property with at least an empty table
            Dim _tableParam As DataTableParameter = New DataTableParameter
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sPBiasCurves)
            If (_propertyNode Is Nothing) Then
                mMyStore.AddProperty(sPBiasCurves, _tableParam)
                _propertyNode = mMyStore.GetProperty(sPBiasCurves)
            End If
            Return _propertyNode
        End Get
    End Property

    Public Property PBiasCurves() As DataTableParameter
        Get
            Dim _tableParameter As DataTableParameter = PBiasCurvesProperty.GetDataTableParameter()
            Return _tableParameter
        End Get
        Set(ByVal Value As DataTableParameter)
            PBiasCurvesProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearPBiasCurves()
        Dim pbiasParam As DataTableParameter = Me.PBiasCurves
        Dim pbiasTable As DataTable = pbiasParam.Value
        If (pbiasTable IsNot Nothing) Then
            pbiasTable.Rows.Clear()
            pbiasParam.Value = pbiasTable
            Me.PBiasCurves = pbiasParam
        End If
    End Sub

    Public Const sNseCurves As String = "NSE Curves"

    Public ReadOnly Property NseCurvesProperty() As PropertyNode
        Get
            ' Get property with at least an empty table
            Dim _tableParam As DataTableParameter = New DataTableParameter
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sNseCurves)
            If (_propertyNode Is Nothing) Then
                mMyStore.AddProperty(sNseCurves, _tableParam)
                _propertyNode = mMyStore.GetProperty(sNseCurves)
            End If
            Return _propertyNode
        End Get
    End Property

    Public Property NseCurves() As DataTableParameter
        Get
            Dim _tableParameter As DataTableParameter = NseCurvesProperty.GetDataTableParameter()
            Return _tableParameter
        End Get
        Set(ByVal Value As DataTableParameter)
            NseCurvesProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ClearNseCurves()
        Dim nseParam As DataTableParameter = Me.NseCurves
        Dim nseTable As DataTable = nseParam.Value
        If (nseTable IsNot Nothing) Then
            nseTable.Rows.Clear()
            nseParam.Value = nseTable
            Me.NseCurves = nseParam
        End If
    End Sub
    '
    ' Goodness-Of-Fit calculation method
    '
    Public Const sGoodnessOfFitMethod As String = "Goodness-of-Fit Method"

    Public ReadOnly Property GoodnessOfFitMethodProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sGoodnessOfFitMethod)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As IntegerParameter = New IntegerParameter(DefaultGoodnessOfFitMethod)
                mMyStore.AddProperty(sGoodnessOfFitMethod, _parameter)
                _propertyNode = mMyStore.GetProperty(sGoodnessOfFitMethod)
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property GoodnessOfFitMethod() As IntegerParameter
        Get
            Return GoodnessOfFitMethodProperty.GetIntegerParameter()
        End Get
        Set(ByVal Value As IntegerParameter)
            GoodnessOfFitMethodProperty.SetParameter(Value)
        End Set
    End Property

#End Region

#Region " Evaluation Results "

    '*********************************************************************************************************
    ' Event Analyses often produce 'intermediate' results that are used as inputs to other parts of an
    ' analysis.  Also, some of these 'intermediate' results need to be preserved for display by the Data
    ' Comparison tool.
    '*********************************************************************************************************

    Private mMeasuredVzInfiltration As DataTable = Nothing
    Public Property MeasuredVzInfiltration() As DataTable
        Get
            Return mMeasuredVzInfiltration
        End Get
        Set(ByVal value As DataTable)
            mMeasuredVzInfiltration = value
        End Set
    End Property

    Public Const sMeasVzInfiltration As String = "Meas Vz Infiltration"

    Public ReadOnly Property MeasVzInfiltrationProperty() As PropertyNode
        Get
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sMeasVzInfiltration)
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataTableParameter = New DataTableParameter(mMeasuredVzInfiltration)

                mMyStore.AddProperty(sMeasVzInfiltration, _parameter)
                _propertyNode = mMyStore.GetProperty(sMeasVzInfiltration)
            End If
            Return _propertyNode
        End Get
    End Property

    Public Property MeasVzInfiltration() As DataTableParameter
        Get
            Dim _tableParameter As DataTableParameter = MeasVzInfiltrationProperty.GetDataTableParameter()
            Return _tableParameter
        End Get
        Set(ByVal Value As DataTableParameter)
            MeasVzInfiltrationProperty.SetParameter(Value)
        End Set
    End Property

    Private mPredictedVzInfiltration As DataTable = Nothing
    Public Property PredictedVzInfiltration() As DataTable
        Get
            Return mPredictedVzInfiltration
        End Get
        Set(ByVal value As DataTable)
            mPredictedVzInfiltration = value
        End Set
    End Property

#End Region

#Region " Simulation Results "

    '*********************************************************************************************************
    ' Most Event Analyses use simulation results as 'inputs' to the analyses.  These results must be stored
    ' in the DataStore as 'inputs' as they must be preserved.
    '*********************************************************************************************************

    Private Const sSimulationVolumeBalances As String = "Simulation Volume Balances"

    Public ReadOnly Property SimulationVolumeBalancesProperty() As PropertyNode
        Get
            ' Define reset Volume Balance table
            Dim _volumeBalances As DataTable = New DataTable(sSimulationVolumeBalances)
            ResetVolumeBalancesTable(_volumeBalances)
            ' Get property with at least a reset table
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSimulationVolumeBalances, _volumeBalances)
            Return _propertyNode
        End Get
    End Property

    Public Property SimulationVolumeBalances() As DataTableParameter
        Get
            Dim _tableParameter As DataTableParameter = SimulationVolumeBalancesProperty.GetDataTableParameter()
            Return _tableParameter
        End Get
        Set(ByVal Value As DataTableParameter)
            SimulationVolumeBalancesProperty.SetParameter(Value)
        End Set
    End Property
    '
    ' Flow Depth Hydrograph Tables (1 for Roughness estimation)
    '
    Private Const sSimFlowDepthsForRoughnessEstimation As String = "Sim Flow Depths Roughness"

    Public ReadOnly Property SimFlowDepthsRoughnessProperty() As PropertyNode
        Get
            Dim _propertyNode As PropertyNode = mMyStore.GetProperty(sSimFlowDepthsForRoughnessEstimation)
            Dim _flowDepthSet As DataSet = New DataSet(sSimFlowDepthsForRoughnessEstimation)

            ' If it was not found; create it
            If (_propertyNode Is Nothing) Then
                Dim _parameter As DataSetParameter = New DataSetParameter(_flowDepthSet)
                mMyStore.AddProperty(sSimFlowDepthsForRoughnessEstimation, _parameter)
                _propertyNode = mMyStore.GetProperty(sSimFlowDepthsForRoughnessEstimation)
            Else
                Dim _parameter As DataSetParameter = _propertyNode.GetDataSetParameter
                If (_parameter Is Nothing) Then
                    _parameter = New DataSetParameter(_flowDepthSet)
                    _propertyNode.SetParameter(_parameter)
                ElseIf (_parameter.Value Is Nothing) Then
                    _parameter = New DataSetParameter(_flowDepthSet)
                    _propertyNode.SetParameter(_parameter)
                End If
            End If

            Return _propertyNode
        End Get
    End Property

    Public Property SimFlowDepthsRoughness() As DataSetParameter
        Get
            Return SimFlowDepthsRoughnessProperty.GetDataSetParameter()
        End Get
        Set(ByVal Value As DataSetParameter)
            SimFlowDepthsRoughnessProperty.SetParameter(Value)
        End Set
    End Property

    Public Sub ResetSimFlowDepthsRoughness(ByVal SimFlowDepthsRoughness As DataSet)
        SimFlowDepthsRoughness.Tables.Clear()               ' Remove previous data
    End Sub

    Public Sub ClearSimFlowDepthsRoughness()
        mMyStore.DeleteProperty(sSimFlowDepthsForRoughnessEstimation)
    End Sub

#End Region

#End Region

#Region " Calculated Properties "

#Region " EW 2-Pt Estimated Surface Volumes "

    Public Function SurfaceShapeFactor1() As Double
        SurfaceShapeFactor1 = DefaultSurfaceShapeFactor1

        Try
            Dim twoPointTable As DataTable = EW2ptEstimatedSurfaceVolumes.Value
            Dim twoPointRow As DataRow = twoPointTable.Rows(0)
            SurfaceShapeFactor1 = twoPointRow.Item(sSigmaY)

        Catch ex As Exception
            SurfaceShapeFactor1 = DefaultSurfaceShapeFactor1
        End Try

    End Function

    Public Function SurfaceShapeFactor2() As Double
        SurfaceShapeFactor2 = DefaultSurfaceShapeFactor2

        Try
            Dim twoPointTable As DataTable = EW2ptEstimatedSurfaceVolumes.Value
            Dim twoPointRow As DataRow = twoPointTable.Rows(1)
            SurfaceShapeFactor2 = twoPointRow.Item(sSigmaY)

        Catch ex As Exception
            SurfaceShapeFactor2 = DefaultSurfaceShapeFactor2
        End Try

    End Function

#End Region

#Region " Volume Balances "

    '*********************************************************************************************************
    ' Function MaxVolumeBalanceTime() - return the maximum time in the Volume Balances table
    '
    ' Note - This method assumes the Volume Balance Table is up-to-date so it bypasses the normal access
    '        procedure to save time.
    '*********************************************************************************************************
    Public Function MaxVolumeBalanceTime() As Double
        MaxVolumeBalanceTime = 0.0

        Dim VolBalNode As PropertyNode = mMyStore.GetProperty(sVolumeBalances)
        Dim VolBalParam As DataTableParameter = VolBalNode.GetDataTableParameter
        Dim VolBalTable As DataTable = VolBalParam.Value

        If (DataTableHasData(VolBalTable, 1)) Then
            MaxVolumeBalanceTime = MaxColumnValue(VolBalTable, nTimeX)
        End If
    End Function

#End Region

#End Region

#Region " Constructor(s) "
    '
    ' New() - Instantiate a new EventCriteria object
    '
    ' _myID - Object ID string
    '   Nothing or String.Empty - default ID is used
    '
    ' _unit - Parent Unit reference
    '
    Public Sub New(ByVal _myID As String, ByVal _unit As Unit)
        '
        ' Save ID
        '
        If (_myID IsNot Nothing) Then
            If Not (_myID.Trim = String.Empty) Then
                mMyID = _myID.Trim
            End If
        End If
        '
        ' Save Parent Unit reference and get Parent's Data Store
        '
        If (_unit IsNot Nothing) Then
            mUnit = _unit
            mParentStore = mUnit.MyStore
        Else
            Debug.Assert(False, "Unit is Nothing")
        End If
        '
        ' Add EventCriteria to Parent's Data Store
        '
        If (mParentStore IsNot Nothing) Then

            mMyStore = mParentStore.AddObject(MyID)

            If (mMyStore IsNot Nothing) Then
                ' Enable event generation
                mMyStore.EventsEnabled = True
            Else
                Debug.Assert(False, "EventCriteria not added to Data Store")
            End If
        Else
            Debug.Assert(False, "Parent's Data Store is Nothing")
        End If

    End Sub
    '
    ' New() - Instantiate a EventCriteria object; then connect to DataStore
    '
    ' _myStore - DataStore ObjectNode reference
    '
    ' _unit - Parent Unit reference
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
        Me.ClearSimFlowDepthsRoughness()
        mMyStore.DeleteProperty("HYDRUS Infiltration")
    End Sub

#End Region

#Region " Events & Handlers "
    '
    ' Reasons for generating an event
    '
    Public Enum Reasons
        EventCriteria
        EventAnalysisType
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
        Select Case (_id)
            Case sEventAnalysisType
                RaiseEvent PropertyDataChanged(Reasons.EventAnalysisType)
            Case Else
                RaiseEvent PropertyDataChanged(Reasons.EventCriteria)
        End Select
    End Sub

#End Region

End Class
