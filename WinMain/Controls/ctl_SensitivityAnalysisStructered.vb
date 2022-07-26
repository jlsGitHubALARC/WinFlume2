
'************************************************************************************************************
' Class ctl_SensitivityAnalysisInputs - UserControl for defining the dependent and indepentent irrigation
'                                       parameters for Sensiivity Analysis
'
'************************************************************************************************************
Imports System.IO

Imports DataStore
Imports System.Collections.Generic

Public Class ctl_SensitivityAnalysisStructured

    Friend WithEvents BrowseOutputFileButton As DataStore.ctl_Button

#Region " Constants "

    Public Enum Groups
        SystemGeometry = 0
        Roughness
        Infiltration
        Inflow
    End Enum

    Public Enum BorderParams
        Length = 0
        Width
        Depth
        Slope
    End Enum

    Public Enum TrapezoidFurrowParams
        Length = 0
        Width
        Depth
        Slope
        BW
        SS
    End Enum

    Public Enum PowerLawFurrowParams
        Length = 0
        Width
        Depth
        Slope
        W100
        M
    End Enum

    Public Enum RoughnessParams
        ManningN = 0
        SayreAlbertsonChi
    End Enum

    Public Enum MK_InfiltrationParams
        KostiakovK = 0
        KostiakovA
        KostiakovB
        KostiakovC
    End Enum

    Public Enum Char_InfiltrationParams
        CharDepth = 0
        CharTime
        CharTime_KA
    End Enum

    Public Enum BF_InfiltrationParams
        BranchK = 0
        BranchA
        BranchB
        BranchC
    End Enum

    Public Enum WGA_InfiltrationParams
        ThetaS = 0
        Theta0
        hf
        Ks
        MacroporeInf
        Gamma
    End Enum

    Public Enum InflowParams
        InflowRate = 0
        CutoffTime
    End Enum

#End Region

#Region " Member Data "

    Protected WithEvents mScriptRecorder As ScriptRecorder
    Public ReadOnly Property ScriptRecorder() As ScriptRecorder
        Get
            Return mScriptRecorder
        End Get
    End Property

    Private mInputFile As String
    Private mOuputFile As String

    Protected mInitiazing As Boolean = True

    Protected UseCompressedId As Boolean = False

#End Region

#Region " Properties "
    '
    ' Access to WinSFRF & SystemWorld
    '
    Private mWinSRFR As WinSRFR = Nothing
    Public Property WinSRFR
        Get
            Return mWinSRFR
        End Get
        Set(value)
            mWinSRFR = value
        End Set
    End Property

    Private mSimulationWorld As SimulationWorld
    Public Property SimulationWorld
        Get
            Return mSimulationWorld
        End Get
        Set(value)
            mSimulationWorld = value
        End Set
    End Property
    '
    ' Independent Parameters
    '
    Public Const MinIndepParams As Integer = 1
    Public Const MaxIndepParams As Integer = 2
    Public Property NumIndepParams As Integer = MinIndepParams

    ' Independent 1 
    Public Property MinInd1Val As Double
    Public Property MaxInd1Val As Double

    Public Property Ind1UnitsTxt As String
    Public Property Ind1UnitsVal As Double

    Public Property Ind1Incs As Integer = 10             ' Number of increments for Independent 1 parameter

    ' Independent 2
    Public Property MinInd2Val As Double
    Public Property MaxInd2Val As Double

    Public Property Ind2UnitsTxt As String
    Public Property Inp2UnitsVal As Double

    Public Property Ind2Incs As Integer = 10             ' Number of increments for Indepedent 2 parameter

    Public Function NumPoints() As Integer              ' Number of points (rows) in resulting DataTable
        Return Ind1Incs * Ind2Incs + 1                    ' + 1 is for last fence post
    End Function
    '
    ' Dependent Parameters are selected by the user from System Geometry, Roughness, Infiltration and Inflow
    '
    Public Const MinDepParams As Integer = 1
    Public Const MaxDepParams As Integer = 4
    Public Property NumDepParams As Integer = MinDepParams

    Public Property Dep1UnitsTxt As String
    Public Property Dep1UnitsVal As Double
    Public Property Dep1GroupSelectedIndex As Integer = 0
    Public Property Dep1ParamSelectedIndex As Integer = 0

    Public Property Dep2UnitsTxt As String
    Public Property Dep2UnitsVal As Double
    Public Property Dep2GroupSelectedIndex As Integer = 0
    Public Property Dep2ParamSelectedIndex As Integer = 0

    Public Property Dep3UnitsTxt As String
    Public Property Dep3UnitsVal As Double
    Public Property Dep3GroupSelectedIndex As Integer = 0
    Public Property Dep3ParamSelectedIndex As Integer = 0

    Public Property Dep4UnitsTxt As String
    Public Property Dep4UnitsVal As Double
    Public Property Dep4GroupSelectedIndex As Integer = 0
    Public Property Dep4ParamSelectedIndex As Integer = 0

    Public Property InputFileLines As List(Of String)
    Public Property OutputFileLines As List(Of String)

#End Region

#Region " Initialization "

    Public Sub Initialize(ByVal pUint As Unit)
        '
        ' Initialize referenced to DataStore objects
        '
        mUnit = pUint
        mMyStore = pUint.MyStore
        mSystemGeometry = mUnit.SystemGeometryRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        Me.LinKToModel()

        ' Initialize Independent variables UI
        OneIndVarRadioButton.Checked = True

        ' Independent 1
        Indep1GroupValue.SelectedIndex = 0                  ' Group value
        Indep1ParamValue.SelectedIndex = 0                  ' Parameter value

        MinIndep1Value.Text = "10"                          ' Range

        MaxIndep1Value.Text = "100"

        ' Independent 2
        Indep2GroupValue.SelectedIndex = 0                  ' Group value
        Indep2ParamValue.SelectedIndex = 0                  ' Parameter value

        MinIndep2Value.Text = "20"                          ' Range

        MaxIndep2Value.Text = "200"

        ' Initialize Dependent variables UI
        ZeroDepVarRadioButton.Checked = True

        Dep1ParamGroupValue.SelectedIndex = 0
        Dep1SelParamValue.SelectedIndex = 0

        Dep2ParamGroupValue.SelectedIndex = 0
        Dep2SelParamValue.SelectedIndex = 0

        Dep3ParamGroupValue.SelectedIndex = 0
        Dep3SelParamValue.SelectedIndex = 0

        Dep4ParamGroupValue.SelectedIndex = 0
        Dep4SelParamValue.SelectedIndex = 0

        InputFileLines = New List(Of String)
        OutputFileLines = New List(Of String)

        ' Use Script Recorder to generate Dependent drop-down list
        If (mScriptRecorder Is Nothing) Then
            Try ' to create Script Recorder
                mScriptRecorder = New ScriptRecorder
                mScriptRecorder.ObjectNode = mMyStore
            Catch ex1 As Exception
                Try ' again
                    mScriptRecorder = Nothing
                    mScriptRecorder = New ScriptRecorder
                    mScriptRecorder.ObjectNode = mMyStore
                Catch ex2 As Exception
                    Debug.Assert(False)
                End Try
            End Try
        End If

        mInitiazing = False

        UpdateUI()

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Protected WithEvents mUnit As Unit

    Protected mDictionary As Dictionary = Dictionary.Instance
    Protected mMyStore As DataStore.ObjectNode

    Protected WithEvents mSystemGeometry As SystemGeometry
    Protected WithEvents mSoilCropProperties As SoilCropProperties
    Protected WithEvents mInflowManagement As InflowManagement
    Protected WithEvents mEventCriteria As EventCriteria

    Protected WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Public Sub LinKToModel()

        '*****************************************************************************************************
        ' Independent Variables
        '*****************************************************************************************************
        OneIndVarRadioButton.LinkToModel(mMyStore, mEventCriteria.NumIndependentVariablesProperty, 1)
        TwoIndVarRadioButton.LinkToModel(mMyStore, mEventCriteria.NumIndependentVariablesProperty, 2)

        ' Independent Variable 1
        Indep1GroupValue.AlwaysUseBackColorDefault = True
        Indep1GroupValue.LinkToModel(mMyStore, mEventCriteria.Indep1ParamGroupProperty)
        Indep1ParamValue.AlwaysUseBackColorDefault = True
        Indep1ParamValue.LinkToModel(mMyStore, mEventCriteria.Indep1ParamValueProperty)

        MinIndep1Value.LinkToModel(mMyStore, mEventCriteria.MinIndepParameter1Property)
        MaxIndep1Value.LinkToModel(mMyStore, mEventCriteria.MaxIndepParameter1Property)

        NumInd1Increments.LinkToModel(mMyStore, mEventCriteria.NumIndepParameter1Property)

        ' Independent Variable 2
        Indep2GroupValue.AlwaysUseBackColorDefault = True
        Indep2GroupValue.LinkToModel(mMyStore, mEventCriteria.Indep2ParamGroupProperty)
        Indep2ParamValue.AlwaysUseBackColorDefault = True
        Indep2ParamValue.LinkToModel(mMyStore, mEventCriteria.Indep2ParamValueProperty)

        MinIndep2Value.LinkToModel(mMyStore, mEventCriteria.MinIndepParameter2Property)
        MaxIndep2Value.LinkToModel(mMyStore, mEventCriteria.MaxIndepParameter2Property)

        NumInd2Increments.LinkToModel(mMyStore, mEventCriteria.NumIndepParameter2Property)

        '*****************************************************************************************************
        ' Dependent Variables
        '*****************************************************************************************************
        OneDepVarRadioButton.LinkToModel(mMyStore, mEventCriteria.NumDependentVariablesProperty, 1)
        TwoDepVarRadioButton.LinkToModel(mMyStore, mEventCriteria.NumDependentVariablesProperty, 2)
        ThreeDepVarRadioButton.LinkToModel(mMyStore, mEventCriteria.NumDependentVariablesProperty, 3)
        FourDepVarRadioButton.LinkToModel(mMyStore, mEventCriteria.NumDependentVariablesProperty, 4)

        ' Dependent Variable 1
        Dep1ParamGroupValue.LinkToModel(mMyStore, mEventCriteria.DepParamGroup1Property)
        Dep1SelParamValue.LinkToModel(mMyStore, mEventCriteria.DepSelectedParameter1Property)

    End Sub

#End Region

#Region " Methods "

    Private mUpdateUI As Boolean = False
    Friend Sub UpdateUI()

        Dim UnitsText As String
        '
        ' Wait for initialization to complete before updating UI
        '
        If (mInitiazing) Then
            Return
        End If
        '
        ' Wait for Save to complete before performing the UI update
        If (mSaving) Then
            Return
        End If
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateUI() generates many events that require additional calls to UpdateUI()
        '  Without this check, the call stack would overflow
        '
        If (mUpdateUI) Then
            Return
        Else
            mUpdateUI = True
        End If

        UseCompressedId = False
        '
        ' Independent Parameters
        '
        Independent1GroupBox.Show()                                    ' Inflow Rate is always visible

        UpdateIndep1Group(Indep1GroupValue, Indep1ParamValue)

        UnitsText = GetCommandUnits(Indep1ParamValue.Text)
        'JLS MinIndep1Value.UnitsToDisplay(UnitsText)
        'JLS MaxIndep1Value.UnitsToDisplay(UnitsText)
        Ind1UnitsText.Text = UnitsText

        If (1 < NumIndepParams) Then                            ' Cutoff Time may or may not be shown
            Independent2GroupBox.Show()

            UpdateIndep2Group(Indep2GroupValue, Indep2ParamValue)

            UnitsText = GetCommandUnits(Indep2ParamValue.Text)
            'JLS MinIndep2Value.UnitsToDisplay(UnitsText)
            'JLS MaxIndep2Value.UnitsToDisplay(UnitsText)
            Ind2UnitsText.Text = UnitsText

        Else
            Independent2GroupBox.Hide()
        End If
        '
        ' Dependent Parameters
        '
        If (0 < NumDepParams) Then                          ' Dependent 1/2/3/4 may or may not be shown
            Dependent1GroupBox.Show()

            UpdateDep1Group(Dep1ParamGroupValue, Dep1SelParamValue)
            'UpdateIndep1Group(Indep1GroupValue, Dep1ParamGroupValue)

            'Dep1ParamGroupValue.Items.Clear()
            'Dep1ParamGroupValue.Items.Add(Indep1GroupValue.Items(Indep1GroupValue.SelectedIndex))

            'If (1 < NumIndepParams) Then
            '    Dep1ParamGroupValue.Items.Add(Indep2GroupValue.Items(Indep2GroupValue.SelectedIndex))
            'End If

            If Dep1GroupSelectedIndex >= Dep1ParamGroupValue.Items.Count Then
                Dep1ParamGroupValue.SelectedIndex = Dep1ParamGroupValue.Items.Count - 1
            End If

            Dep1ParamGroupValue.SelectedIndex = Dep1GroupSelectedIndex

        Else
            Dependent1GroupBox.Hide()
        End If

        If (1 < NumDepParams) Then
            Dependent2GroupBox.Show()

            UpdateDep2Group(Dep2ParamGroupValue, Dep2SelParamValue)
            'UpdateIndep1Group(Indep1GroupValue, Dep2ParamGroupValue)

            'Dep2ParamGroupValue.Items.Clear()
            'Dep2ParamGroupValue.Items.Add(Indep1GroupValue.Items(Indep1GroupValue.SelectedIndex))

            'If (1 < NumIndepParams) Then
            '    Dep2ParamGroupValue.Items.Add(Indep2GroupValue.Items(Indep2GroupValue.SelectedIndex))
            'End If

            If Dep2GroupSelectedIndex >= Dep2ParamGroupValue.Items.Count Then
                Dep2ParamGroupValue.SelectedIndex = Dep2ParamGroupValue.Items.Count - 1
            End If

            Dep2ParamGroupValue.SelectedIndex = Dep2GroupSelectedIndex
        Else
            Dependent2GroupBox.Hide()
        End If

        If (2 < NumDepParams) Then
            Dependent3GroupBox.Show()

            UpdateDep3Group(Dep3ParamGroupValue, Dep3SelParamValue)
            'UpdateIndep1Group(Indep1GroupValue, Dep3ParamGroupValue)

            'Dep3ParamGroupValue.Items.Clear()
            'Dep3ParamGroupValue.Items.Add(Indep1GroupValue.Items(Indep1GroupValue.SelectedIndex))

            'If (1 < NumIndepParams) Then
            '    Dep3ParamGroupValue.Items.Add(Indep2GroupValue.Items(Indep2GroupValue.SelectedIndex))
            'End If

            If Dep3GroupSelectedIndex >= Dep3ParamGroupValue.Items.Count Then
                Dep3ParamGroupValue.SelectedIndex = Dep3ParamGroupValue.Items.Count - 1
            End If

            Dep3ParamGroupValue.SelectedIndex = Dep3GroupSelectedIndex
        Else
            Dependent3GroupBox.Hide()
        End If

        If (3 < NumDepParams) Then
            Dependent4GroupBox.Show()

            UpdateDep4Group(Dep4ParamGroupValue, Dep4SelParamValue)
            'UpdateIndep1Group(Indep1GroupValue, Dep4ParamGroupValue)

            'Dep4ParamGroupValue.Items.Clear()
            'Dep4ParamGroupValue.Items.Add(Indep1GroupValue.Items(Indep1GroupValue.SelectedIndex))

            'If (1 < NumIndepParams) Then
            '    Dep4ParamGroupValue.Items.Add(Indep2GroupValue.Items(Indep2GroupValue.SelectedIndex))
            'End If

            If Dep4GroupSelectedIndex >= Dep4ParamGroupValue.Items.Count Then
                Dep4ParamGroupValue.SelectedIndex = Dep4ParamGroupValue.Items.Count - 1
            End If

            Dep4ParamGroupValue.SelectedIndex = Dep4GroupSelectedIndex
        Else
            Dependent4GroupBox.Hide()
        End If

        ' Allow another call to UpdateUI()
        mUpdateUI = False

    End Sub

    Protected Sub UpdateIndep1Group(ByVal ParameterGroup As ctl_SelectParameter,
                                    ByVal ParameterValue As ctl_SelectParameter)

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

        ParameterGroup.AlwaysUseBackColorDefault = True
        ParameterValue.AlwaysUseBackColorDefault = True

        ' The Parameeter Group's available values depends on the Parameter Group selection
        Select Case (ParameterGroup.SelectedItem)
            Case ("System Geometry")
                LoadSystemGeometry(ParameterValue)
            Case ("Roughness")
                LoadRoughness(ParameterValue)
            Case ("Infiltration")
                LoadInfiltration(ParameterValue)
            Case ("Inflow")
                LoadInflow(ParameterValue)
            Case ("Inflow / Runoff")
                LoadInflow(ParameterValue)
            Case Else
                Debug.Assert(False)
        End Select

    End Sub

    Private mUpdatingIndep2 As Boolean = False
    Protected Sub UpdateIndep2Group(ByVal ParameterGroup As ctl_SelectParameter,
                                    ByVal ParameterValue As ctl_SelectParameter)

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

        ParameterGroup.AlwaysUseBackColorDefault = True
        ParameterValue.AlwaysUseBackColorDefault = True

        ' The Parameeter Group's available values depends on the Parameter Group selection
        Select Case (ParameterGroup.SelectedItem)
            Case ("System Geometry")
                LoadSystemGeometry(ParameterValue)
            Case ("Roughness")
                LoadRoughness(ParameterValue)
            Case ("Infiltration")
                LoadInfiltration(ParameterValue)
            Case ("Inflow")
                LoadInflow(ParameterValue)
            Case ("Inflow / Runoff")
                LoadInflow(ParameterValue)
            Case Else
                Debug.Assert(False)
        End Select

        ' Allow another call to UpdateIndep2Group()
        mUpdatingIndep2 = False

    End Sub

    Protected Sub UpdateDep1Group(ByVal ParameterGroup As ctl_SelectParameter,
                                  ByVal ParameterValue As ctl_SelectParameter)

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

        ParameterGroup.AlwaysUseBackColorDefault = True
        ParameterValue.AlwaysUseBackColorDefault = True

        ' The Parameeter Group's available values depends on the Parameter Group selection
        Select Case (ParameterGroup.SelectedIndex)
            Case 0 '("System Geometry")
                LoadSystemGeometry(ParameterValue)
            Case 1 '("Roughness")
                LoadRoughness(ParameterValue)
            Case 2 '("Infiltration")
                LoadInfiltration(ParameterValue)
            Case 3 '("Inflow")
                LoadInflow(ParameterValue)
            Case 4 '("Inflow / Runoff")
                LoadInflow(ParameterValue)
            Case Else
                Debug.Assert(False)
        End Select

        ParameterGroup.BackColor = DataStore.Globals.BackColor_Defaulted
        ParameterValue.BackColor = DataStore.Globals.BackColor_Defaulted

    End Sub

    Protected Sub UpdateDep2Group(ByVal ParameterGroup As ctl_SelectParameter,
                                  ByVal ParameterValue As ctl_SelectParameter)

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

        ParameterGroup.AlwaysUseBackColorDefault = True
        ParameterValue.AlwaysUseBackColorDefault = True

        ' The Parameeter Group's available values depends on the Parameter Group selection
        Select Case (ParameterGroup.SelectedIndex)
            Case 0 '("System Geometry")
                LoadSystemGeometry(ParameterValue)
            Case 1 '("Roughness")
                LoadRoughness(ParameterValue)
            Case 2 '("Infiltration")
                LoadInfiltration(ParameterValue)
            Case 3 '("Inflow")
                LoadInflow(ParameterValue)
            Case 4 '("Inflow / Runoff")
                LoadInflow(ParameterValue)
            Case Else
                Debug.Assert(False)
        End Select

        ParameterGroup.BackColor = DataStore.Globals.BackColor_Defaulted
        ParameterValue.BackColor = DataStore.Globals.BackColor_Defaulted

    End Sub

    Protected Sub UpdateDep3Group(ByVal ParameterGroup As ctl_SelectParameter,
                                  ByVal ParameterValue As ctl_SelectParameter)

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

        ParameterGroup.AlwaysUseBackColorDefault = True
        ParameterValue.AlwaysUseBackColorDefault = True

        ' The Parameeter Group's available values depends on the Parameter Group selection
        Select Case (ParameterGroup.SelectedIndex)
            Case 0 '("System Geometry")
                LoadSystemGeometry(ParameterValue)
            Case 1 '("Roughness")
                LoadRoughness(ParameterValue)
            Case 2 '("Infiltration")
                LoadInfiltration(ParameterValue)
            Case 3 '("Inflow")
                LoadInflow(ParameterValue)
            Case 4 '("Inflow / Runoff")
                LoadInflow(ParameterValue)
            Case Else
                Debug.Assert(False)
        End Select

        ParameterGroup.BackColor = DataStore.Globals.BackColor_Defaulted
        ParameterValue.BackColor = DataStore.Globals.BackColor_Defaulted

    End Sub

    Protected Sub UpdateDep4Group(ByVal ParameterGroup As ctl_SelectParameter,
                                  ByVal ParameterValue As ctl_SelectParameter)

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

        ParameterGroup.AlwaysUseBackColorDefault = True
        ParameterValue.AlwaysUseBackColorDefault = True

        ' The Parameeter Group's available values depends on the Parameter Group selection
        Select Case (ParameterGroup.SelectedIndex)
            Case 0 '("System Geometry")
                LoadSystemGeometry(ParameterValue)
            Case 1 '("Roughness")
                LoadRoughness(ParameterValue)
            Case 2 '("Infiltration")
                LoadInfiltration(ParameterValue)
            Case 3 '("Inflow")
                LoadInflow(ParameterValue)
            Case 4 '("Inflow / Runoff")
                LoadInflow(ParameterValue)
            Case Else
                Debug.Assert(False)
        End Select

        ParameterGroup.BackColor = DataStore.Globals.BackColor_Defaulted
        ParameterValue.BackColor = DataStore.Globals.BackColor_Defaulted

    End Sub

    Private CommandsWithUnits As New List(Of String)()

    Public Function GetCommandWithUnits(ByVal Command As String) As String
        GetCommandWithUnits = ""
        For idx As Integer = 0 To CommandsWithUnits.Count - 1
            Dim CommandWithUnits As String = CommandsWithUnits(idx)
            If (CommandWithUnits.StartsWith(Command)) Then
                GetCommandWithUnits = CommandWithUnits
            End If
        Next
    End Function

    Public Function GetCommandUnits(ByVal Command As String) As String
        GetCommandUnits = ""
        For idx As Integer = 0 To CommandsWithUnits.Count - 1
            Dim CommandWithUnits As String = CommandsWithUnits(idx)
            If (CommandWithUnits.StartsWith(Command)) Then
                Dim tokens() As String = CommandWithUnits.Split(" ".ToCharArray)
                GetCommandUnits = tokens(tokens.Length - 1)
                If (GetCommandUnits.StartsWith("*")) Then
                    GetCommandUnits = ""
                End If
            End If
        Next
    End Function

    Private Sub AddParameter(ByVal ControlSelectParameter As ctl_SelectParameter,
                             ByVal command As String, ByRef ParamIdx As Integer)

        Dim tokens() As String = command.Split(" ".ToCharArray)
        Dim cmd As String = ""
        Dim units As String = ""
        Dim idx As Integer

        For idx = 0 To tokens.Length - 2
            cmd &= tokens(idx) & " "
        Next

        Dim valUnits As String = tokens(idx)

        For ldx As Integer = 0 To valUnits.Length - 1
            If (Char.IsDigit(valUnits(ldx))) Then
            ElseIf (valUnits(ldx) = ".") Then
            Else
                units &= valUnits(ldx)
            End If
        Next

        If (units.Length = 0) Then
            units = "*"
        End If

        Dim cmdUnits = cmd & " " & units
        CommandsWithUnits.Add(cmdUnits)

        If (0 < tokens.Length) Then
            ControlSelectParameter.Add(cmd, ParamIdx)
            ParamIdx += 1
        End If

    End Sub

    Private Sub LoadSystemGeometry(ByVal ControlSelectParameter As ctl_SelectParameter)
        Dim command As String = ""
        Dim paramIdx As Integer

        Dim selIndex As Integer = ControlSelectParameter.SelectedIndex

        ControlSelectParameter.Clear()
        '
        ' Add Parameters common to all Cross Sections (Basin & Border only use these)
        '
        command = mSystemGeometry.LengthProperty.RemoteCommand(UseCompressedId)
        AddParameter(ControlSelectParameter, command, paramIdx)

        command = mSystemGeometry.WidthProperty.RemoteCommand(UseCompressedId)
        AddParameter(ControlSelectParameter, command, paramIdx)

        command = mSystemGeometry.DepthProperty.RemoteCommand(UseCompressedId)
        AddParameter(ControlSelectParameter, command, paramIdx)

        command = mSystemGeometry.SlopeProperty.RemoteCommand(UseCompressedId)
        AddParameter(ControlSelectParameter, command, paramIdx)
        '
        ' Add Parameters specific to each Cross Section (Basin | Border | Furrow)
        '
        Select Case (mSystemGeometry.CrossSection.Value)
            Case CrossSections.Basin
                ' No specific parameters for Basins
            Case CrossSections.Border
                ' No specific parameters for Borders
            Case CrossSections.Furrow

                Dim FurrowShape As FurrowShapes = CType(mSystemGeometry.FurrowShape.Value, FurrowShapes)

                Select Case FurrowShape

                    Case FurrowShapes.Trapezoid

                        command = mSystemGeometry.WidthAt100mmProperty.RemoteCommand(UseCompressedId)
                        AddParameter(ControlSelectParameter, command, paramIdx)

                        command = mSystemGeometry.PowerLawExponentProperty.RemoteCommand(UseCompressedId)
                        AddParameter(ControlSelectParameter, command, paramIdx)

                    Case FurrowShapes.PowerLaw

                        command = mSystemGeometry.BottomWidthProperty.RemoteCommand(UseCompressedId)
                        AddParameter(ControlSelectParameter, command, paramIdx)

                        command = mSystemGeometry.SideSlopeProperty.RemoteCommand(UseCompressedId)
                        AddParameter(ControlSelectParameter, command, paramIdx)

                    Case Else
                        Exit Sub

                End Select

        End Select

        If (selIndex < ControlSelectParameter.Items.Count) Then
            ControlSelectParameter.SelectedIndex = selIndex
        Else
            ControlSelectParameter.SelectedIndex = 0
        End If

    End Sub

    Private Sub LoadRoughness(ByVal ControlSelectParameter As ctl_SelectParameter)
        Dim command As String
        Dim paramIdx As Integer

        Dim selIndex As Integer = ControlSelectParameter.SelectedIndex

        ControlSelectParameter.Clear()
        '
        ' Record Roughness Method specific parameters
        '
        Select Case (mSoilCropProperties.RoughnessMethod.Value)

            Case RoughnessMethods.ManningCnAn

                command = mSoilCropProperties.ManningCnProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.ManningAnProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

            Case RoughnessMethods.SayreAlbertson

                command = mSoilCropProperties.SayreChiProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

            Case Else ' RoughnessMethods.ManningN | NrcsSuggestedManningN | UserSelected

                command = mSoilCropProperties.ManningNProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

        End Select

        If (selIndex < ControlSelectParameter.Items.Count) Then
            ControlSelectParameter.SelectedIndex = selIndex
        Else
            ControlSelectParameter.SelectedIndex = 0
        End If

    End Sub

    Private Sub LoadInfiltration(ByVal ControlSelectParameter As ctl_SelectParameter)
        Dim command As String
        Dim paramIdx As Integer

        Dim selIndex As Integer = ControlSelectParameter.SelectedIndex

        ControlSelectParameter.Clear()
        '
        ' Record common Infiltration parameters
        '
        command = mSoilCropProperties.LimitingDepthProperty.RemoteCommand(UseCompressedId)
        '
        ' Record Infiltration Method specific parameters
        '
        Dim infFunc As InfiltrationFunctions = mSoilCropProperties.InfiltrationFunction.Value
        Select Case (infFunc)

            Case InfiltrationFunctions.BranchFunction

                command = mSoilCropProperties.KostiakovK_BFProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.KostiakovA_BFProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.BranchB_BFProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.KostiakovC_BFProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

            Case InfiltrationFunctions.CharacteristicInfiltrationTime

                command = mSoilCropProperties.InfiltrationDepth_KTProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.InfiltrationTime_KTProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.KostiakovA_KTProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

            Case InfiltrationFunctions.KostiakovFormula

                command = mSoilCropProperties.KostiakovK_KFProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.KostiakovA_KFProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

            Case InfiltrationFunctions.ModifiedKostiakovFormula

                command = mSoilCropProperties.KostiakovK_MKProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.KostiakovA_MKProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.KostiakovB_MKProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.KostiakovC_MKProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

            Case InfiltrationFunctions.GreenAmpt

                command = mSoilCropProperties.SoilTextureSelectionGA_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.EffectivePorosityGA_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.InitialWaterContentGA_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.WettingFrontPressureHeadGA_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.HydraulicConductivityGA_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.GreenAmptC_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

            Case InfiltrationFunctions.WarrickGreenAmpt

                command = mSoilCropProperties.SaturatedWaterContentWGA_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.InitialWaterContentWGA_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.WettingFrontPressureHeadWGA_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.HydraulicConductivityWGA_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.WarrickGreenAmptC_Property.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mSoilCropProperties.WarrickGreenAmptGammaProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

            Case Else
                Exit Sub

        End Select

        If (selIndex < ControlSelectParameter.Items.Count) Then
            ControlSelectParameter.SelectedIndex = selIndex
        Else
            ControlSelectParameter.SelectedIndex = 0
        End If

    End Sub

    Private Sub LoadInflow(ByVal ControlSelectParameter As ctl_SelectParameter)
        Dim command As String
        Dim paramIdx As Integer

        Dim selIndex As Integer = ControlSelectParameter.SelectedIndex

        ControlSelectParameter.Clear()
        '
        ' Record Inflow Method specific parameters
        '
        Dim infMethod As InflowMethods = mInflowManagement.InflowMethod.Value

        Select Case (infMethod)

            Case InflowMethods.StandardHydrograph

                command = mInflowManagement.InflowRateProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

                command = mInflowManagement.CutoffTimeProperty.RemoteCommand(UseCompressedId)
                AddParameter(ControlSelectParameter, command, paramIdx)

            Case Else
                Exit Sub

        End Select

        If (selIndex < ControlSelectParameter.Items.Count) Then
            ControlSelectParameter.SelectedIndex = selIndex
        Else
            ControlSelectParameter.SelectedIndex = 0
        End If

    End Sub

    Public Function GetUnitsText(ByVal GroupIdx As Integer, ByVal ParamIdx As Integer) As String
        Dim UnitsText As String = ""
        Select Case (GroupIdx)
            Case Groups.SystemGeometry
                UnitsText = GetSystemGeometryUnitsText(ParamIdx)
            Case Groups.Roughness
                UnitsText = GetRoughnessUnitsText(ParamIdx)
            Case Groups.Infiltration
                UnitsText = GetInfiltrationUnitsText(ParamIdx)
            Case Groups.Inflow
                UnitsText = GetInflowUnitsText(ParamIdx)
            Case Else
                Debug.Assert(False)
        End Select

        Return UnitsText
    End Function

    Public Function GetSystemGeometryUnitsText(ByVal ParamIdx As Integer) As String
        Dim UnitsText As String = ""

        Select Case (mUnit.CrossSection)
            Case CrossSections.Basin Or CrossSections.Border

                Select Case (ParamIdx)
                    Case BorderParams.Width
                        UnitsText = mUnit.SystemGeometryRef.Width.UnitsString
                    Case BorderParams.Depth
                        UnitsText = mUnit.SystemGeometryRef.Depth.UnitsString
                    Case BorderParams.Slope
                        UnitsText = mUnit.SystemGeometryRef.Slope.UnitsString
                    Case Else
                        UnitsText = mUnit.SystemGeometryRef.Length.UnitsString
                End Select

            Case CrossSections.Furrow

                Select Case mUnit.FurrowShape
                    Case FurrowShapes.Trapezoid 'Or FurrowShapes.TrapezoidFromFieldData

                        Select Case (ParamIdx)
                            Case TrapezoidFurrowParams.Width
                                UnitsText = mUnit.SystemGeometryRef.Width.UnitsString
                            Case TrapezoidFurrowParams.Depth
                                UnitsText = mUnit.SystemGeometryRef.Depth.UnitsString
                            Case TrapezoidFurrowParams.Slope
                                UnitsText = mUnit.SystemGeometryRef.Slope.UnitsString
                            Case TrapezoidFurrowParams.BW
                                UnitsText = mUnit.SystemGeometryRef.BottomWidth.UnitsString
                            Case TrapezoidFurrowParams.SS
                                UnitsText = mUnit.SystemGeometryRef.SideSlope.UnitsString
                            Case Else
                                UnitsText = mUnit.SystemGeometryRef.Length.UnitsString
                        End Select

                    Case FurrowShapes.PowerLaw 'Or FurrowShapes.PowerLawFromFieldData

                        Select Case (ParamIdx)
                            Case PowerLawFurrowParams.Width
                                UnitsText = mUnit.SystemGeometryRef.Width.UnitsString
                            Case PowerLawFurrowParams.Depth
                                UnitsText = mUnit.SystemGeometryRef.Depth.UnitsString
                            Case PowerLawFurrowParams.Slope
                                UnitsText = mUnit.SystemGeometryRef.Slope.UnitsString
                            Case PowerLawFurrowParams.W100
                                UnitsText = mUnit.SystemGeometryRef.WidthAt100mm.UnitsString
                            Case PowerLawFurrowParams.M
                                UnitsText = mUnit.SystemGeometryRef.PowerLawExponent.UnitsString
                            Case Else
                                UnitsText = mUnit.SystemGeometryRef.Length.UnitsString
                        End Select

                End Select

            Case Else
                Debug.Assert(False)
        End Select

        Return UnitsText
    End Function

    Public Function GetRoughnessUnitsText(ByVal ParamIdx As Integer) As String
        Dim UnitsText As String = ""

        Select Case (ParamIdx)
            Case RoughnessParams.ManningN
                UnitsText = mUnit.SoilCropPropertiesRef.ManningN.UnitsString
            Case RoughnessParams.SayreAlbertsonChi
                UnitsText = mUnit.SoilCropPropertiesRef.SayreChi.UnitsString
        End Select

        Return UnitsText
    End Function

    Public Function GetInfiltrationUnitsText(ByVal ParamIdx As Integer) As String
        Dim UnitsText As String = ""

        Select Case (mUnit.SoilCropPropertiesRef.InfiltrationFunction.Value)

            Case InfiltrationFunctions.BranchFunction
                Select Case (ParamIdx)
                    Case BF_InfiltrationParams.BranchK
                        UnitsText = KostiakovKParameter.K_UnitsText(KostiakovKParameter.DisplayUnits)
                    Case BF_InfiltrationParams.BranchA
                        UnitsText = ""
                    Case BF_InfiltrationParams.BranchB
                        UnitsText = mUnit.SoilCropPropertiesRef.BranchB_BF.UnitsString
                    Case BF_InfiltrationParams.BranchC
                        UnitsText = mUnit.SoilCropPropertiesRef.KostiakovC_MK.UnitsString
                End Select

            Case InfiltrationFunctions.CharacteristicInfiltrationTime
                Select Case (ParamIdx)
                    Case Char_InfiltrationParams.CharDepth
                        UnitsText = mUnit.SoilCropPropertiesRef.InfiltrationDepth_KT.UnitsString
                    Case Char_InfiltrationParams.CharTime
                        UnitsText = mUnit.SoilCropPropertiesRef.InfiltrationTime_KT.UnitsString
                    Case Char_InfiltrationParams.CharTime_KA
                        UnitsText = mUnit.SoilCropPropertiesRef.KostiakovA_KT.UnitsString
                End Select

            Case InfiltrationFunctions.KostiakovFormula
                Select Case (ParamIdx)
                    Case MK_InfiltrationParams.KostiakovK
                        UnitsText = KostiakovKParameter.K_UnitsText(KostiakovKParameter.DisplayUnits)
                    Case MK_InfiltrationParams.KostiakovA
                        UnitsText = ""
                End Select

            Case InfiltrationFunctions.ModifiedKostiakovFormula
                Select Case (ParamIdx)
                    Case MK_InfiltrationParams.KostiakovK
                        UnitsText = KostiakovKParameter.K_UnitsText(KostiakovKParameter.DisplayUnits)
                    Case MK_InfiltrationParams.KostiakovA
                        UnitsText = ""
                    Case MK_InfiltrationParams.KostiakovB
                        UnitsText = mUnit.SoilCropPropertiesRef.KostiakovB_MK.UnitsString
                    Case MK_InfiltrationParams.KostiakovC
                        UnitsText = mUnit.SoilCropPropertiesRef.KostiakovC_MK.UnitsString
                End Select

            Case InfiltrationFunctions.WarrickGreenAmpt
                Select Case (ParamIdx)
                    Case WGA_InfiltrationParams.ThetaS
                        UnitsText = mUnit.SoilCropPropertiesRef.SaturatedWaterContentWGA.UnitsString
                    Case WGA_InfiltrationParams.Theta0
                        UnitsText = mUnit.SoilCropPropertiesRef.InitialWaterContentGA.UnitsString
                    Case WGA_InfiltrationParams.hf
                        UnitsText = mUnit.SoilCropPropertiesRef.WettingFrontPressureHeadGA.UnitsString
                    Case WGA_InfiltrationParams.Ks
                        UnitsText = mUnit.SoilCropPropertiesRef.HydraulicConductivityGA.UnitsString
                    Case WGA_InfiltrationParams.MacroporeInf
                        UnitsText = mUnit.SoilCropPropertiesRef.WarrickGreenAmptC.UnitsString
                    Case WGA_InfiltrationParams.Gamma
                        UnitsText = mUnit.SoilCropPropertiesRef.WarrickGreenAmptGamma.UnitsString
                End Select
        End Select

        Return UnitsText
    End Function

    Public Function GetInflowUnitsText(ByVal ParamIdx As Integer)
        Dim UnitsText As String = ""

        Select Case (ParamIdx)
            Case InflowParams.CutoffTime
                UnitsText = mUnit.InflowManagementRef.CutoffTime.UnitsString
            Case InflowParams.InflowRate
                UnitsText = mUnit.InflowManagementRef.InflowRate.UnitsString
        End Select

        Return UnitsText
    End Function

#End Region

#Region " Event Handlers "

    '********************************************************************************************************
    ' Independant Variable Events
    '********************************************************************************************************

    ' UI needs to be updated based on number of independent variables
    Private Sub OneIndVarRadioButton_CheckedChanged(sender As Object, e As EventArgs) _
        Handles OneIndVarRadioButton.CheckedChanged
        NumIndepParams = 1
        UpdateUI()
    End Sub

    Private Sub TwoIndVarRadioButton_CheckedChanged(sender As Object, e As EventArgs) _
        Handles TwoIndVarRadioButton.CheckedChanged
        NumIndepParams = 2
        UpdateUI()
    End Sub

    ' Independent 1
    Private Sub Indep1GroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Indep1GroupValue.SelectedIndexChanged
        If (Indep1GroupValue.SelectedIndex < 0) Then
            Indep1GroupValue.SelectedIndex = 0
        End If
        UpdateUI()
    End Sub

    Private Sub Indep1ParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Indep1ParamValue.SelectedIndexChanged
        If (Indep1ParamValue.SelectedIndex < 0) Then
            Indep1ParamValue.SelectedIndex = 0
        End If
        UpdateUI()
    End Sub

    ' Independent 2
    Private Sub Indep2GroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Indep2GroupValue.SelectedIndexChanged
        If (Indep2GroupValue.SelectedIndex < 0) Then
            Indep2GroupValue.SelectedIndex = 0
        End If
        UpdateUI()
    End Sub

    Private Sub Indep2ParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Indep2ParamValue.SelectedIndexChanged
        If (Indep2ParamValue.SelectedIndex < 0) Then
            Indep2ParamValue.SelectedIndex = 0
        End If
        UpdateUI()
    End Sub

    '********************************************************************************************************
    ' Dependant Variable Events
    '********************************************************************************************************

    ' UI needs to be updated based on the number of and selection of the dependent variables
    Private Sub ZeroDepVarRadioButton_CheckedChanged(sender As Object, e As EventArgs) _
        Handles ZeroDepVarRadioButton.CheckedChanged
        NumDepParams = 0
        UpdateUI()
    End Sub

    Private Sub OneDepVarRadioButton_CheckedChanged(sender As Object, e As EventArgs) _
        Handles OneDepVarRadioButton.CheckedChanged
        NumDepParams = 1
        UpdateUI()
    End Sub

    Private Sub TwoDepVarRadioButton_CheckedChanged(sender As Object, e As EventArgs) _
        Handles TwoDepVarRadioButton.CheckedChanged
        NumDepParams = 2
        UpdateUI()
    End Sub

    Private Sub ThreeDepVarRadioButton_CheckedChanged(sender As Object, e As EventArgs) _
        Handles ThreeDepVarRadioButton.CheckedChanged
        NumDepParams = 3
        UpdateUI()
    End Sub

    Private Sub FourDepVarRadioButton_CheckedChanged(sender As Object, e As EventArgs) _
        Handles FourDepVarRadioButton.CheckedChanged
        NumDepParams = 4
        UpdateUI()
    End Sub

    ' Dependent 1
    Private Sub Dep1ParamGroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep1ParamGroupValue.SelectedIndexChanged
        If (Dep1ParamGroupValue.SelectedIndex < 0) Then
            Dep1ParamGroupValue.SelectedIndex = 0
        End If
        Dep1GroupSelectedIndex = Dep1ParamGroupValue.SelectedIndex
        UpdateUI()
    End Sub

    Private Sub Dep1SelParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep1SelParamValue.SelectedIndexChanged
        If (Dep1SelParamValue.SelectedIndex < 0) Then
            Dep1SelParamValue.SelectedIndex = 0
        End If
        Dep1ParamSelectedIndex = Dep1SelParamValue.SelectedIndex
        UpdateUI()
    End Sub

    ' Dependent 2
    Private Sub Dep2ParamGroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep2ParamGroupValue.SelectedIndexChanged
        If (Dep2ParamGroupValue.SelectedIndex < 0) Then
            Dep2ParamGroupValue.SelectedIndex = 0
        End If
        Dep2GroupSelectedIndex = Dep2ParamGroupValue.SelectedIndex
        UpdateUI()
    End Sub

    Private Sub Dep2SelParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep2SelParamValue.SelectedIndexChanged
        If (Dep2SelParamValue.SelectedIndex < 0) Then
            Dep2SelParamValue.SelectedIndex = 0
        End If
        Dep2ParamSelectedIndex = Dep2SelParamValue.SelectedIndex
        UpdateUI()
    End Sub

    ' Dependent 3
    Private Sub Dep3ParamGroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep3ParamGroupValue.SelectedIndexChanged
        If (Dep3ParamGroupValue.SelectedIndex < 0) Then
            Dep3ParamGroupValue.SelectedIndex = 0
        End If
        Dep3GroupSelectedIndex = Dep3ParamGroupValue.SelectedIndex
        UpdateUI()
    End Sub

    Private Sub Dep3SelParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep3SelParamValue.SelectedIndexChanged

        If (Dep3SelParamValue.SelectedIndex < 0) Then
            Dep3SelParamValue.SelectedIndex = 0
        End If
        Dep3ParamSelectedIndex = Dep3SelParamValue.SelectedIndex
        UpdateUI()
    End Sub

    ' Dependent 4
    Private Sub Dep4ParamGroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep4ParamGroupValue.SelectedIndexChanged
        If (Dep4ParamGroupValue.SelectedIndex < 0) Then
            Dep4ParamGroupValue.SelectedIndex = 0
        End If
        Dep4GroupSelectedIndex = Dep4ParamGroupValue.SelectedIndex
        UpdateUI()
    End Sub

    Private Sub Dep4SelParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep4SelParamValue.SelectedIndexChanged
        If (Dep4SelParamValue.SelectedIndex < 0) Then
            Dep4SelParamValue.SelectedIndex = 0
        End If
        Dep4ParamSelectedIndex = Dep4SelParamValue.SelectedIndex
        UpdateUI()
    End Sub
    '
    ' File I/O Events
    '
    Private Sub InputFilename_TextChanged(sender As Object, e As EventArgs) _
        Handles InputFilename.TextChanged

        Me.Text = mDictionary.ControlText(Me)

        ' Save button is enabled after both input & output files are specified
        If ((Me.InputFilename.Text.Trim = String.Empty) _
         Or (Me.OutputFileName.Text.Trim = String.Empty)) Then
            Me.SaveButton.Enabled = False
        Else
            Me.SaveButton.Enabled = True
        End If

    End Sub

    Private Sub BrowseInputFileButton_Click(sender As Object, e As EventArgs) _
        Handles BrowseInputFileButton.Click

        Dim saveDiag As New SaveFileDialog

        saveDiag.FileName = ""
        saveDiag.DefaultExt = "*.csv"
        saveDiag.Filter = "Save File (*.csv;*.txt)|*.csv;*.txt"

        Dim result As DialogResult = saveDiag.ShowDialog()

        If (result = DialogResult.OK) Then
            mInputFile = saveDiag.FileName
            Me.InputFilename.Text = mInputFile
        End If

    End Sub

    Private Sub OutputFilename_TextChanged(sender As Object, e As EventArgs) _
        Handles OutputFileName.TextChanged

        Me.Text = mDictionary.ControlText(Me)

        ' Save button is enabled after both input & output files are specified
        If ((Me.InputFilename.Text.Trim = String.Empty) _
         Or (Me.OutputFileName.Text.Trim = String.Empty)) Then
            Me.SaveButton.Enabled = False
        Else
            Me.SaveButton.Enabled = True
        End If
    End Sub


    Private Sub BrowseOutputFileName_Click(sender As Object, e As EventArgs) _
        Handles BrowseOutputFileName.Click

        Dim saveDiag As New SaveFileDialog

        saveDiag.FileName = ""
        saveDiag.DefaultExt = "*.csv"
        saveDiag.Filter = "Output File (*.csv;*.txt)|*.csv;*.txt"

        Dim result As DialogResult = saveDiag.ShowDialog()

        If (result = DialogResult.OK) Then
            mOuputFile = saveDiag.FileName
            Me.OutputFileName.Text = mOuputFile
        End If

    End Sub

    Private mSaving As Boolean = False
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) _
        Handles SaveButton.Click

        Dim title, msg As String
        Dim Dep1Range As Double
        Dim Dep2Range As Double
        Dim Ind1Incs, Ind2Incs As Integer

        mSaving = True
        '
        ' Validate user entered parameters
        '

        ' Independent 1 is always used
        If Not (ParseDouble(MinIndep1Value.Text, MinInd1Val)) Then
            title = "Invalid Number"
            msg = "Min Independent 1 is not a valid number" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        ' 0 <= MinInd1 < MaxInd1
        If (MinInd1Val < 0) Then
            title = "Invalid Number"
            msg = "Min Independent 1 is less than zero" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        If Not (ParseDouble(MaxIndep1Value.Text, MaxInd1Val)) Then
            title = "Invalid Number"
            msg = "Min Independent 1 is not a valid number" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        If Not (MinInd1Val < MaxInd1Val) Then
            title = "Invalid Number"
            msg = "Min Independent 1 should be be less than Max Independent 1" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        ' Number of Independent 1 Increments should be a valid integer
        If Not (Integer.TryParse(NumInd1Increments.Value, Ind1Incs)) Then
            title = "Invalid Number"
            msg = "Number of Independent 1 Increments is not a valid integer" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        Dep1Range = MaxInd1Val - MinInd1Val

        ' Independent 2 may or may not be used
        If (TwoIndVarRadioButton.Checked) Then

            If Not (ParseDouble(MinIndep2Value.Text, MinInd2Val)) Then
                title = "Invalid Number"
                msg = "Min Independent 1 is not a valid number" & Chr(10) & Chr(10)
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
                Exit Sub
            End If

            If Not (ParseDouble(MaxIndep2Value.Text, MaxInd2Val)) Then
                title = "Invalid Number"
                msg = "Min Independent 2 is not a valid number" & Chr(10) & Chr(10)
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
                Exit Sub
            End If

            If Not (MinInd2Val < MaxInd2Val) Then
                title = "Invalid Number"
                msg = "Min Independent 2 should be be less than Max Independent 2" & Chr(10) & Chr(10)
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
                Exit Sub
            End If

            ' Number of Independet 2 Increments should be a valid integer
            If Not (Integer.TryParse(NumInd2Increments.Value, Ind2Incs)) Then
                title = "Invalid Number"
                msg = "Number of Independent 2 Increment is not a valid integer" & Chr(10) & Chr(10)
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
                Exit Sub
            End If

            Dep2Range = MaxInd2Val - MinInd2Val

        End If
        '
        ' Number of columns is determined by:
        '   1 - Whether it is the input or output DataTable
        '   2 - The input variables (use of Independent and Dependent (Aux) inputs)  1 to 6
        '   3 - The Water Balance Components (Dapp, Dinf, Ddp, Dro, Dmin, Dlq)      6
        '   4 - The Performance Indicators (AE, DUlq, DUmin, RO, DP, RE)            6 - JLS
        '   5 - Other useful outputs (Txa and XR)                                   2
        '
        '
        ' Number of rows is determined by the number of Idependent increments
        '
        Dim numRows As Integer

        If (TwoIndVarRadioButton.Checked) Then
            ' Both Independent 1 and independent 2 are used (results are displayed as contours
            numRows = Ind1Incs * Ind2Incs + 1
        Else
            ' Only Independent 1 is used (results are display as scatter plots
            numRows = Ind1Incs + 1
        End If

        '*****************************************************************************************************
        ' Build Structured input file
        '*****************************************************************************************************
        '
        ' Add the columns - colhdrline are column names, colunitsline are the column units
        '
        Dim colhdrline As String = ""
        Dim colunitsline As String = ""

        Dim colName As String
        Dim colUnits As String

        ' Independent 1 is always used
        UseCompressedId = True

        UpdateIndep1Group(Indep1GroupValue, Indep1ParamValue)
        colName = Indep1ParamValue.Text.Trim
        colhdrline &= colName & " ,"
        colUnits = GetCommandUnits(Indep1ParamValue.Text.Trim)
        colunitsline &= colUnits & " ,"

        ' Independent 2 may or may not be used
        If (TwoIndVarRadioButton.Checked) Then

            UpdateIndep1Group(Indep2GroupValue, Indep2ParamValue)
            colName = Indep2ParamValue.Text.Trim
            colhdrline &= colName & " ,"
            colUnits = GetCommandUnits(Indep2ParamValue.Text.Trim)
            colunitsline &= colUnits & " ,"

        End If

        ' 0-4 Auxillary parameter may be used
        If (0 < NumDepParams) Then

            UpdateDep1Group(Dep1ParamGroupValue, Dep1SelParamValue)
            colName = Dep1SelParamValue.Text.Trim
            colhdrline &= colName & " ,"
            colUnits = GetCommandUnits(Dep1SelParamValue.Text.Trim)
            colunitsline &= colUnits & " ,"

        End If

        If (1 < NumDepParams) Then

            UpdateDep2Group(Dep2ParamGroupValue, Dep2SelParamValue)
            colName = Dep2SelParamValue.Text.Trim
            colhdrline &= colName & " ,"
            colUnits = GetCommandUnits(Dep2SelParamValue.Text.Trim)
            colunitsline &= colUnits & " ,"

        End If

        If (2 < NumDepParams) Then

            UpdateDep3Group(Dep3ParamGroupValue, Dep3SelParamValue)
            colName = Dep3SelParamValue.Text.Trim
            colhdrline &= colName & " ,"
            colUnits = GetCommandUnits(Dep3SelParamValue.Text.Trim)
            colunitsline &= colUnits & " ,"

        End If

        If (3 < NumDepParams) Then

            UpdateDep4Group(Dep4ParamGroupValue, Dep4SelParamValue)
            colName = Dep4SelParamValue.Text.Trim
            colhdrline &= colName & " ,"
            colUnits = GetCommandUnits(Dep4SelParamValue.Text.Trim)
            colunitsline &= colUnits & " ,"

        End If

        InputFileLines.Add(colhdrline)
        InputFileLines.Add(colunitsline)
        '
        ' Add the rows
        '
        If (TwoIndVarRadioButton.Checked) Then
            BuildTwoIndepInputDataTable()
        Else
            BuildOneIndepInputDataTable()
        End If

        '*****************************************************************************************************
        ' Build Structered output file
        '*****************************************************************************************************
        '
        ' Add the columns - colhdrline are column names, colunitsline are the column units
        '
        colhdrline = ""
        colunitsline = ""

        ' Independent 1 is always used
        UseCompressedId = True

        UpdateIndep1Group(Indep1GroupValue, Indep1ParamValue)
        colName = Indep1ParamValue.Text
        colhdrline &= colName & ","
        colUnits = GetCommandUnits(Indep1ParamValue.Text)
        colunitsline &= colUnits & ","

        ' Independent 2 may or may not be used
        If (TwoIndVarRadioButton.Checked) Then

            UpdateIndep1Group(Indep2GroupValue, Indep2ParamValue)
            colName = Indep2ParamValue.Text
            colhdrline &= colName & ","
            colUnits = GetCommandUnits(Indep2ParamValue.Text)
            colunitsline &= colUnits & ","

        End If

        ' 0-4 Auxillary parameter may be used
        If (0 < NumDepParams) Then

            UpdateDep1Group(Dep1ParamGroupValue, Dep1SelParamValue)
            colName = Dep1SelParamValue.Text
            colhdrline &= colName & ","
            colUnits = GetCommandUnits(Dep1SelParamValue.Text)
            colunitsline &= colUnits & ","

        End If

        If (1 < NumDepParams) Then

            UpdateDep2Group(Dep2ParamGroupValue, Dep2SelParamValue)
            colName = Dep2SelParamValue.Text
            colhdrline &= colName & ","
            colUnits = GetCommandUnits(Dep2SelParamValue.Text)
            colunitsline &= colUnits & ","

        End If

        If (2 < NumDepParams) Then

            UpdateDep3Group(Dep3ParamGroupValue, Dep3SelParamValue)
            colName = Dep3SelParamValue.Text
            colhdrline &= colName & ","
            colUnits = GetCommandUnits(Dep3SelParamValue.Text)
            colunitsline &= colUnits & ","

        End If

        If (3 < NumDepParams) Then

            UpdateDep4Group(Dep4ParamGroupValue, Dep4SelParamValue)
            colName = Dep4SelParamValue.Text
            colhdrline &= colName & ","
            colUnits = GetCommandUnits(Dep4SelParamValue.Text)
            colunitsline &= colUnits & ","

        End If

        ' All the calculated water balance components
        colName = "Dapp"
        colhdrline &= colName & ","
        colUnits = "m"
        colunitsline &= colUnits & ","

        colName = "Dinf"
        colhdrline &= colName & ","
        colUnits = "m"
        colunitsline &= colUnits & ","

        colName = "Ddp"
        colhdrline &= colName & ","
        colUnits = "m"
        colunitsline &= colUnits & ","

        colName = "Dro"
        colhdrline &= colName & ","
        colUnits = "m"
        colunitsline &= colUnits & ","

        colName = "Dmin"
        colhdrline &= colName & ","
        colUnits = "m"
        colunitsline &= colUnits & ","

        colName = "Dlq"
        colhdrline &= colName & ","
        colUnits = "m"
        colunitsline &= colUnits & ","

        ' Performance indicators calculated from the water balacne components
        colName = "AE"
        colhdrline &= colName & ","
        colUnits = "&"
        colunitsline &= colUnits & ","

        colName = "DUlq"
        colhdrline &= colName & ","
        colUnits = ""
        colunitsline &= colUnits & ","

        colName = "DUmin"
        colhdrline &= colName & ","
        colUnits = ""
        colunitsline &= colUnits & ","

        colName = "RO"
        colhdrline &= colName & ","
        colUnits = "%"
        colunitsline &= colUnits & ","

        colName = "DP"
        colhdrline &= colName & ","
        colUnits = "%"
        colunitsline &= colUnits & ","

        'colName = "RE"                         JLS
        'colhdrline &= colName & ","
        'colUnits = "%"
        'colunitsline &= colUnits & ","

        ' Additional useful outputs
        colName = "Txa"
        colhdrline &= colName & ","
        colUnits = "s"
        colunitsline &= colUnits & ","

        colName = "XR"
        colhdrline &= colName & ","
        colUnits = ""
        colunitsline &= colUnits & ","

        OutputFileLines.Add(colhdrline)
        OutputFileLines.Add(colunitsline)
        '
        ' Add the rows
        '
        If (TwoIndVarRadioButton.Checked) Then
            BuildTwoIndepOutputDataTable()
        Else
            BuildOneIndepOutputDataTable()
        End If

        '*****************************************************************************************************
        ' Save both Structured DataTables
        '*****************************************************************************************************
        Dim stream As StreamWriter = Nothing

        Dim inputfilepath As String = Me.InputFilename.Text
        '
        ' Save input file
        '
        Try
            stream = New StreamWriter(inputfilepath)

            If (stream IsNot Nothing) Then
                For Each line As String In InputFileLines
                    stream.WriteLine(line)
                Next
            End If

        Catch ex As Exception
            title = mDictionary.tErrOpeningWritingFile.Translated
            msg = mDictionary.tFile.Translated & ": " & inputfilepath & Chr(13) & Chr(13)
            msg += ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)

        Finally
            If (stream IsNot Nothing) Then
                stream.Close()
                stream = Nothing
            End If
        End Try
        '
        ' Save output file
        '
        Dim outputfilepath As String = Me.OutputFileName.Text

        Try
            stream = New StreamWriter(outputfilepath)

            If (stream IsNot Nothing) Then
                For Each line As String In OutputFileLines
                    stream.WriteLine(line)
                Next
            End If

        Catch ex As Exception
            title = mDictionary.tErrOpeningWritingFile.Translated
            msg = mDictionary.tFile.Translated & ": " & outputfilepath & Chr(13) & Chr(13)
            msg += ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)

        Finally
            If (stream IsNot Nothing) Then
                stream.Close()
                stream = Nothing
            End If
        End Try

        mSaving = False

        UpdateUI()

    End Sub

    Private Sub BuildOneIndepInputDataTable()

        Dim Indep1Increment As Double = (MaxInd1Val - MinInd1Val) / Ind1Incs

        Dim rowline As String = ""

        For idx1 As Integer = 0 To Ind1Incs

            Dim Indep1RowValue As Double = MinInd1Val + idx1 * Indep1Increment
            rowline &= Indep1RowValue.ToString & " ,"

            ' 0-4 Auxillary parameter may be used
            If (0 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (1 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (2 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (3 < NumDepParams) Then
                rowline &= " ,"
            End If

            InputFileLines.Add(rowline)

            rowline = ""

        Next idx1

    End Sub

    Private Sub BuildTwoIndepInputDataTable()

        Dim Indep1Increment As Double = (MaxInd1Val - MinInd1Val) / Ind1Incs
        Dim Indep2Increment As Double = (MaxInd2Val - MinInd2Val) / Ind2Incs

        Dim rowline As String = ""

        Dim idx1, idx2 As Integer

        For idx3 As Integer = 0 To Ind1Incs * Ind2Incs - 1

            Dim Indep1RowValue As Double = MinInd1Val + idx1 * Indep1Increment
            rowline &= Indep1RowValue.ToString & " ,"

            idx1 += 1

            Indep1RowValue = MinInd1Val + idx1 * Indep1Increment
            rowline &= Indep1RowValue.ToString & " ,"

            Dim Indep2RowValue As Double = MinInd2Val + idx2 * Indep2Increment
            rowline &= Indep2RowValue.ToString & " ,"

            idx2 += 1

            Indep2RowValue = MinInd1Val + idx2 * Indep2Increment
            rowline &= Indep2RowValue.ToString & " ,"

            ' 0-4 Auxillary parameter may be used
            If (0 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (1 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (2 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (3 < NumDepParams) Then
                rowline &= " ,"
            End If

            InputFileLines.Add(rowline)

            rowline = ""

        Next idx3

    End Sub

    Private Sub BuildOneIndepOutputDataTable()

        Dim Indep1Increment As Double = (MaxInd1Val - MinInd1Val) / Ind1Incs

        Dim rowline As String = ""

        For idx1 As Integer = 0 To Ind1Incs

            Dim Indep1RowValue As Double = MinInd1Val + idx1 * Indep1Increment
            rowline &= Indep1RowValue.ToString & ","

            ' 0-4 Auxillary parameter may be used
            If (0 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (1 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (2 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (3 < NumDepParams) Then
                rowline &= " ,"
            End If

            ' All the calculated water balance components
            rowline &= " ,"     ' Dapp
            rowline &= " ,"     ' Dinf
            rowline &= " ,"     ' Ddp
            rowline &= " ,"     ' Dro
            rowline &= " ,"     ' Dmin
            rowline &= " ,"     ' Dlq

            ' Performance indicators calculated from the water balacne components
            rowline &= " ,"     ' AE
            rowline &= " ,"     ' DUlq
            rowline &= " ,"     ' DUmin
            rowline &= " ,"     ' RO
            rowline &= " ,"     ' DP
            rowline &= " ,"     ' RE

            ' Additional useful outputs
            rowline &= " ,"     ' Txa
            rowline &= " ,"     ' XR

            OutputFileLines.Add(rowline)

            rowline = ""

        Next idx1

    End Sub

    Private Sub BuildTwoIndepOutputDataTable()

        Dim Indep1Increment As Double = (MaxInd1Val - MinInd1Val) / Ind1Incs
        Dim Indep2Increment As Double = (MaxInd2Val - MinInd2Val) / Ind2Incs

        Dim rowline As String = ""

        Dim idx1, idx2 As Integer

        For idx3 As Integer = 0 To Ind1Incs * Ind2Incs - 1

            Dim Indep1RowValue As Double = MinInd1Val + idx1 * Indep1Increment
            rowline &= Indep1RowValue.ToString & " ,"

            idx1 += 1

            Indep1RowValue = MinInd1Val + idx1 * Indep1Increment
            rowline &= Indep1RowValue.ToString & " ,"

            Dim Indep2RowValue As Double = MinInd2Val + idx2 * Indep2Increment
            rowline &= Indep2RowValue.ToString & " ,"

            idx2 += 1

            Indep2RowValue = MinInd1Val + idx2 * Indep2Increment
            rowline &= Indep2RowValue.ToString & " ,"

            ' 0-4 Auxillary parameter may be used
            If (0 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (1 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (2 < NumDepParams) Then
                rowline &= " ,"
            End If

            If (3 < NumDepParams) Then
                rowline &= " ,"
            End If

            rowline &= " ,"     ' Dapp
            rowline &= " ,"     ' Dinf
            rowline &= " ,"     ' Ddp
            rowline &= " ,"     ' Dro
            rowline &= " ,"     ' Dmin
            rowline &= " ,"     ' Dlq

            ' Performance indicators calculated from the water balacne components
            rowline &= " ,"     ' AE
            rowline &= " ,"     ' DUlq
            rowline &= " ,"     ' DUmin
            rowline &= " ,"     ' RO
            rowline &= " ,"     ' DP
            rowline &= " ,"     ' RE

            ' Additional useful outputs
            rowline &= " ,"     ' Txa
            rowline &= " ,"     ' XR

            OutputFileLines.Add(rowline)

            rowline = ""

        Next idx3

    End Sub

#End Region

End Class
