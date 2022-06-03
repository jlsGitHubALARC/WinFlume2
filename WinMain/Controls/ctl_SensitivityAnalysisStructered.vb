
'************************************************************************************************************
' Class ctl_SensitivityAnalysisInputs - UserControl for defining the dependent and indepentent irrigation
'                                       parameters for Sensiivity Analysis
'
'************************************************************************************************************
Imports System.IO

Imports Srfr
Imports Srfr.SrfrAPI

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
    '
    ' References passed or derived via initialization
    '
    Protected WithEvents mUnit As Unit

    Protected mDictionary As Dictionary = Dictionary.Instance
    Protected mMyStore As DataStore.ObjectNode

    Protected WithEvents mUnitControl As UnitControl
    Protected WithEvents mSystemGeometry As SystemGeometry
    Protected WithEvents mSoilCropProperties As SoilCropProperties
    Protected WithEvents mInflowManagement As InflowManagement

    Protected WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

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
    ' Unit Reference
    '
    Public Property UnitRef As Unit = Nothing
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

    Public Property Dep2UnitsTxt As String
    Public Property Dep2UnitsVal As Double

    Public Property Dep3UnitsTxt As String
    Public Property Dep3UnitsVal As Double

    Public Property Dep4UnitsTxt As String
    Public Property Dep4UnitsVal As Double

    Public Property StructDataTable As DataTable

#End Region

#Region " Initialization "

    Public Sub Initialize(ByVal pUint As Unit)
        '
        ' Initialize referenced to DataStore objects
        '
        mUnit = pUint

        mMyStore = mUnit.MyStore

        mUnitControl = mUnit.UnitControlRef
        mSystemGeometry = mUnit.SystemGeometryRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mInflowManagement = mUnit.InflowManagementRef
        '
        ' Initialize UI selections
        '

        ' Initialize Independent variables UI
        ZeroDepVarRadioButton.Checked = True

        ' Independent 1
        Indep1GroupValue.SelectedIndex = 0                  ' Group value
        Indep1ParamValue.SelectedIndex = 0                  ' Parameter value

        MinInd1Value.Text = "10"                            ' Range
        MaxInd1Value.Text = "100"

        ' Independent 2
        Indep2GroupValue.SelectedIndex = 0                  ' Group value
        Indep2ParamValue.SelectedIndex = 0                  ' Parameter value

        MinInd2Value.Text = "0"                              ' Range
        MaxInd2Value.Text = "0"

        ' Initialize Dependent variables UI
        OneIndVarRadioButton.Checked = True

        Dep1ParamGroupValue.SelectedIndex = 0
        Dep1SelParamValue.SelectedIndex = 0

        Dep2ParamGroupValue.SelectedIndex = 0
        Dep2SelParamValue.SelectedIndex = 0

        Dep3ParamGroupValue.SelectedIndex = 0
        Dep3SelParamValue.SelectedIndex = 0

        Dep4ParamGroupValue.SelectedIndex = 0
        Dep4SelParamValue.SelectedIndex = 0

        mInitiazing = False

        ' Update UI after initialzation
        UpdateUI()

    End Sub

#End Region

#Region " Methods "

    Private mUpdating As Boolean = False
    Friend Sub UpdateUI()

        Dim UnitsText As String
        '
        ' Wait for initialization to complete before updating UI
        '
        If (mInitiazing) Then
            Return
        End If
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateUI() generates many events that require additional calls to UpdateUI()
        '  Without this check, the call stack would overflow
        '
        If (mUpdating) Then
            Return
        Else
            mUpdating = True
        End If
        '
        ' Independent Parameters
        '
        Independent1GroupBox.Show()                                    ' Inflow Rate is always visible

        UnitsText = GetCommandUnits(Indep1ParamValue.Text)
        'UnitsText = GetUnitsText(Indep1GroupValue.SelectedIndex, Indep1ParamValue.SelectedIndex)
        Ind1UnitsText.Text = UnitsText

        If (1 < NumIndepParams) Then                            ' Cutoff Time may or may not be shown
            Independent2GroupBox.Show()

            UnitsText = GetCommandUnits(Indep2ParamValue.Text)
            'UnitsText = GetUnitsText(Indep2GroupValue.SelectedIndex, Indep2ParamValue.SelectedIndex)
            Ind2UnitsText.Text = UnitsText

        Else
            Independent2GroupBox.Hide()
        End If
        '
        ' Dependent Parameters
        '
        If (0 < NumDepParams) Then
            Dependent1GroupBox.Show()

            Dep1ParamGroupValue.Items.Clear()
            Dep1ParamGroupValue.Items.Add(Indep1GroupValue.Items(Indep1GroupValue.SelectedIndex))

            If (1 < NumIndepParams) Then
                Dep1ParamGroupValue.Items.Add(Indep2GroupValue.Items(Indep2GroupValue.SelectedIndex))
            End If

            Dep1ParamGroupValue.SelectedIndex = 0

        Else
            Dependent1GroupBox.Hide()
        End If

        If (1 < NumDepParams) Then                          ' Dependent 1/2/3/4 may or may not be shown
            Dependent2GroupBox.Show()

            Dep2ParamGroupValue.Items.Clear()
            Dep2ParamGroupValue.Items.Add(Indep1GroupValue.Items(Indep1GroupValue.SelectedIndex))

            If (1 < NumIndepParams) Then
                Dep2ParamGroupValue.Items.Add(Indep2GroupValue.Items(Indep2GroupValue.SelectedIndex))
            End If

            Dep2ParamGroupValue.SelectedIndex = 0
        Else
            Dependent2GroupBox.Hide()
        End If

        If (2 < NumDepParams) Then
            Dependent3GroupBox.Show()

            Dep3ParamGroupValue.Items.Clear()
            Dep3ParamGroupValue.Items.Add(Indep1GroupValue.Items(Indep1GroupValue.SelectedIndex))

            If (1 < NumIndepParams) Then
                Dep3ParamGroupValue.Items.Add(Indep2GroupValue.Items(Indep2GroupValue.SelectedIndex))
            End If

            Dep3ParamGroupValue.SelectedIndex = 0
        Else
            Dependent3GroupBox.Hide()
        End If

        If (3 < NumDepParams) Then
            Dependent4GroupBox.Show()

            Dep4ParamGroupValue.Items.Clear()
            Dep4ParamGroupValue.Items.Add(Indep1GroupValue.Items(Indep1GroupValue.SelectedIndex))

            If (1 < NumIndepParams) Then
                Dep4ParamGroupValue.Items.Add(Indep2GroupValue.Items(Indep2GroupValue.SelectedIndex))
            End If

            Dep4ParamGroupValue.SelectedIndex = 0
        Else
            Dependent4GroupBox.Hide()
        End If

        ' Allow another call to UpdateUI()
        mUpdating = False

    End Sub

    Private mUpdatingIndep1 As Boolean = False
    Protected Sub UpdateIndep1Group(ByVal ParameterGroup As ctl_SelectParameter,
                                    ByVal ParameterValue As ctl_SelectParameter)
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateIndep1Group() generates many events that require additional calls to
        '  UpdateIndep1Group().  Without this check, the call stack would overflow
        '
        If (mUpdatingIndep1) Then
            Return
        Else
            mUpdatingIndep1 = True
        End If

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

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

        ' Allow another call to UpdateIndep1Group()
        mUpdatingIndep1 = False

    End Sub

    Private mUpdatingIndep2 As Boolean = False
    Protected Sub UpdateIndep2Group(ByVal ParameterGroup As ctl_SelectParameter,
                                    ByVal ParameterValue As ctl_SelectParameter)
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateIndep2Group() generates many events that require additional calls to 
        '  UpdateIndep2Group().  Without this check, the call stack would overflow
        '
        If (mUpdatingIndep2) Then
            Return
        Else
            mUpdatingIndep2 = True
        End If

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

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

    Private mUpdatingDep1 As Boolean = False
    Protected Sub UpdateDep1Group(ByVal ParameterGroup As ctl_SelectParameter,
                                  ByVal ParameterValue As ctl_SelectParameter)
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateDep1Group() generates many events that require additional calls to UpdateDep1Group()
        '  Without this check, the call stack would overflow
        '
        If (mUpdatingDep1) Then
            Return
        Else
            mUpdatingDep1 = True
        End If

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

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

        ' Allow another call to Updatedep1Group()
        mUpdatingDep1 = False

    End Sub

    Private mUpdatingDep2 As Boolean = False
    Protected Sub UpdateDep2Group(ByVal ParameterGroup As ctl_SelectParameter,
                                  ByVal ParameterValue As ctl_SelectParameter)
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateDep2Group() generates many events that require additional calls to UpdateDep2Group()
        '  Without this check, the call stack would overflow
        '
        If (mUpdatingDep2) Then
            Return
        Else
            mUpdatingDep2 = True
        End If

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

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

        ' Allow another call to Updatedep2Group()
        mUpdatingDep2 = False

    End Sub

    Private mUpdatingDep3 As Boolean = False
    Protected Sub UpdateDep3Group(ByVal ParameterGroup As ctl_SelectParameter,
                                  ByVal ParameterValue As ctl_SelectParameter)
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateDep3Group() generates many events that require additional calls to UpdateDep3Group()
        '  Without this check, the call stack would overflow
        '
        If (mUpdatingDep3) Then
            Return
        Else
            mUpdatingDep3 = True
        End If

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

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

        ' Allow another call to Updatedep3Group()
        mUpdatingDep3 = False

    End Sub

    Private mUpdatingDep4 As Boolean = False
    Protected Sub UpdateDep4Group(ByVal ParameterGroup As ctl_SelectParameter,
                                  ByVal ParameterValue As ctl_SelectParameter)
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateDep4Group() generates many events that require additional calls to UpdateDep4Group()
        '  Without this check, the call stack would overflow
        '
        If (mUpdatingDep4) Then
            Return
        Else
            mUpdatingDep4 = True
        End If

        ' Default selected index is -1; change to 0 when found
        If (ParameterGroup.SelectedIndex < 0) Then
            ParameterGroup.SelectedIndex = 0
        End If

        If (ParameterValue.SelectedIndex < 0) Then
            ParameterValue.SelectedIndex = 0
        End If

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

        ' Allow another call to Updatedep4Group()
        mUpdatingDep4 = False

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
    '
    ' Independant Variable Events
    '

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

        UpdateIndep1Group(Indep1GroupValue, Indep1ParamValue)

        UpdateUI()
    End Sub

    Private mHandlingIndep1SelIndChange As Boolean = False
    Private Sub Indep1ParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Indep1ParamValue.SelectedIndexChanged
        If (mHandlingIndep1SelIndChange) Then
            Return
        Else
            mHandlingIndep1SelIndChange = True
        End If

        If (Indep1ParamValue.SelectedIndex < 0) Then
            Indep1ParamValue.SelectedIndex = 0
        End If

        UpdateIndep1Group(Indep1GroupValue, Indep1ParamValue)

        UpdateUI()
        mHandlingIndep1SelIndChange = False
    End Sub

    ' Independent 1
    Private Sub Indep2GroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Indep2GroupValue.SelectedIndexChanged
        If (Indep2GroupValue.SelectedIndex < 0) Then
            Indep2GroupValue.SelectedIndex = 0
        End If

        UpdateIndep2Group(Indep2GroupValue, Indep2ParamValue)

        UpdateUI()
    End Sub

    Private mHandlingInd2SelIndChange As Boolean = False
    Private Sub Indep2ParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Indep2ParamValue.SelectedIndexChanged
        If (mHandlingInd2SelIndChange) Then
            Return
        Else
            mHandlingInd2SelIndChange = True
        End If

        If (Indep2ParamValue.SelectedIndex < 0) Then
            Indep2ParamValue.SelectedIndex = 0
        End If

        UpdateIndep2Group(Indep2GroupValue, Indep2ParamValue)

        UpdateUI()
        mHandlingInd2SelIndChange = False
    End Sub

    ' Values simply need to be saved
    Private Sub MinInd1Value_ControlValueChanged() _
        Handles MinInd1Value.TextChanged

        Try
            Dim MinInd1 As Double = Double.Parse(MinInd1Value.Text)

            If (MinInd1 < 0) Then
                MinInd1 = 0
            End If

            MinInd1Value.Text = MinInd1.ToString
        Catch ex As Exception
            MinInd1Value.Text = "0"
        End Try

    End Sub

    Private Sub MaxInd1Value_ControlValueChanged() _
        Handles MaxInd1Value.TextChanged

        Try
            Dim MaxInd1 As Double = Double.Parse(MaxInd1Value.Text)

            If (MaxInd1 < 0) Then
                MaxInd1 = 0
            End If

            MaxInd1Value.Text = MaxInd1.ToString
        Catch ex As Exception
            MaxInd1Value.Text = "0"
        End Try

    End Sub

    Private Sub MinInd2Value_ControlValueChanged() _
        Handles MinInd2Value.TextChanged

        Try
            Dim MinInd2 As Double = Double.Parse(MinInd2Value.Text)

            If (MinInd2 < 0) Then
                MinInd2 = 0
            End If

            MinInd2Value.Text = MinInd2.ToString
        Catch ex As Exception
            MinInd2Value.Text = "0"
        End Try

    End Sub

    Private Sub MaxInd2Value_ControlValueChanged() _
        Handles MaxInd2Value.TextChanged

        Try
            Dim MaxInd2 As Double = Double.Parse(MaxInd2Value.Text)

            If (MaxInd2 < 0) Then
                MaxInd2 = 0
            End If

            MaxInd2Value.Text = MaxInd2.ToString
        Catch ex As Exception
            MaxInd2Value.Text = "0"
        End Try

    End Sub
    '
    ' Dependant Variable Events
    '

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

        UpdateDep1Group(Dep1ParamGroupValue, Dep1SelParamValue)
    End Sub

    Private mHandlingDep1SelIndChange As Boolean = False
    Private Sub Dep1SelParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep1SelParamValue.SelectedIndexChanged
        If (mHandlingDep1SelIndChange = True) Then
            Return
        Else
            mHandlingDep1SelIndChange = True
        End If

        If (Dep1SelParamValue.SelectedIndex < 0) Then
            Dep1SelParamValue.SelectedIndex = 0
        End If

        UpdateDep1Group(Dep1ParamGroupValue, Dep1SelParamValue)

        mHandlingDep1SelIndChange = False
    End Sub

    ' Dependent 2
    Private Sub Dep2ParamGroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep2ParamGroupValue.SelectedIndexChanged
        If (Dep2ParamGroupValue.SelectedIndex < 0) Then
            Dep2ParamGroupValue.SelectedIndex = 0
        End If

        UpdateDep2Group(Dep2ParamGroupValue, Dep2SelParamValue)
    End Sub

    Private mHandlingDep2SelIndChange As Boolean = False
    Private Sub Dep2SelParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep2SelParamValue.SelectedIndexChanged
        If (mHandlingDep2SelIndChange = True) Then
            Return
        Else
            mHandlingDep2SelIndChange = True
        End If

        If (Dep2SelParamValue.SelectedIndex < 0) Then
            Dep2SelParamValue.SelectedIndex = 0
        End If

        UpdateDep2Group(Dep2ParamGroupValue, Dep2SelParamValue)

        mHandlingDep2SelIndChange = False
    End Sub

    ' Dependent 3
    Private Sub Dep3ParamGroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep3ParamGroupValue.SelectedIndexChanged
        If (Dep3ParamGroupValue.SelectedIndex < 0) Then
            Dep3ParamGroupValue.SelectedIndex = 0
        End If

        UpdateDep3Group(Dep3ParamGroupValue, Dep3SelParamValue)
    End Sub

    Private mHandlingDep3SelIndChange As Boolean = False
    Private Sub Dep3SelParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep3SelParamValue.SelectedIndexChanged
        If (mHandlingDep3SelIndChange = True) Then
            Return
        Else
            mHandlingDep3SelIndChange = True
        End If

        If (Dep3SelParamValue.SelectedIndex < 0) Then
            Dep3SelParamValue.SelectedIndex = 0
        End If

        UpdateDep3Group(Dep3ParamGroupValue, Dep3SelParamValue)

        mHandlingDep3SelIndChange = False
    End Sub

    ' Dependent 4
    Private Sub Dep4ParamGroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep4ParamGroupValue.SelectedIndexChanged
        If (Dep4ParamGroupValue.SelectedIndex < 0) Then
            Dep4ParamGroupValue.SelectedIndex = 0
        End If

        UpdateDep4Group(Dep4ParamGroupValue, Dep4SelParamValue)
    End Sub

    Private mHandlingDep4SelIndChange As Boolean = False
    Private Sub Dep4SelParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles Dep4SelParamValue.SelectedIndexChanged
        If (mHandlingDep4SelIndChange = True) Then
            Return
        Else
            mHandlingDep4SelIndChange = True
        End If

        If (Dep4SelParamValue.SelectedIndex < 0) Then
            Dep4SelParamValue.SelectedIndex = 0
        End If

        UpdateDep4Group(Dep4ParamGroupValue, Dep4SelParamValue)

        mHandlingDep4SelIndChange = False
    End Sub
    '
    ' File I/O Events
    '
    Private Sub InputFilename_TextChanged(sender As Object, e As EventArgs) _
        Handles InputFilename.TextChanged

        Me.Text = mDictionary.ControlText(Me)

        ' Save button is enabled after both input & output files are specified
        If ((Me.InputFilename.Text.Trim = String.Empty) _
         Or (Me.OutputFilename.Text.Trim = String.Empty)) Then
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
        Handles OutputFilename.TextChanged

        Me.Text = mDictionary.ControlText(Me)

        ' Save button is enabled after both input & output files are specified
        If ((Me.InputFilename.Text.Trim = String.Empty) _
         Or (Me.OutputFilename.Text.Trim = String.Empty)) Then
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

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) _
        Handles SaveButton.Click

        Dim title, msg As String
        Dim Dep1Range As Double
        Dim Dep2Range As Double
        Dim Ind1Incs, Ind2Incs As Integer
        '
        ' Validate user entered parameters
        '

        ' Independent 1 is always used
        If Not (ParseDouble(MinInd1Value.Text, MinInd1Val)) Then
            title = "Invalid Number"
            msg = "Min Independent 1 is not a valid number" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        If Not (ParseDouble(MaxInd1Value.Text, MaxInd1Val)) Then
            title = "Invalid Number"
            msg = "Max Independent 1 is not a valid number" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        ' 0 <= MinInd1 < MaxInd1
        If (MaxInd1Val < 0) Then
            title = "Invalid Number"
            msg = "Min Independent 1 is less than zero" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        If Not (MinInd1Val < MaxInd1Val) Then
            title = "Invalid Number"
            msg = "Min Independent 1 should be be less than Max Independent 2" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        ' Number of Independent 1 Increments should be a valid integer
        If Not (Integer.TryParse(NumInd1Increments.ValueText, Ind1Incs)) Then
            title = "Invalid Number"
            msg = "Number of Independent 1 Increments is not a valid integer" & Chr(10) & Chr(10)
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
            Exit Sub
        End If

        Dep1Range = MaxInd1Val - MinInd1Val

        ' Independent 2 may or may not be used
        If (TwoIndVarRadioButton.Checked) Then

            If Not (ParseDouble(MinInd2Value.Text, MinInd2Val)) Then
                title = "Invalid Number"
                msg = "Min Independent 2 is not a valid number" & Chr(10) & Chr(10)
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
                Exit Sub
            End If

            If Not (ParseDouble(MaxInd2Value.Text, MaxInd2val)) Then
                title = "Invalid Number"
                msg = "Max Independent 2 is not a valid number" & Chr(10) & Chr(10)
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
                Exit Sub
            End If

            ' 0 <= MinInd2 < MaxInd2
            If (MinInd2Val < 0) Then
                title = "Invalid Number"
                msg = "Min Independent 2 is less than zero" & Chr(10) & Chr(10)
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
            If Not (Integer.TryParse(NumInd2Increments.ValueText, Ind2Incs)) Then
                title = "Invalid Number"
                msg = "Number of Independent 2 Increment is not a valid integer" & Chr(10) & Chr(10)
                MsgBox(msg, MsgBoxStyle.Exclamation, title)
                Exit Sub
            End If

            Dep2Range = MaxInd2Val - MinInd2Val

        End If
        '
        ' Number of columns is determined by:
        '   1 - The input variabls (use of Independent and Dependent (Aux) inputs)  1 to 6
        '   2 - The Water Balance Components (Dapp, Dinf, Ddp, Dro, Dmin, Dlq)      6
        '   3 - The Performance Indicators (AE, DUlq, DUmin, RO, DP, RE)            6
        '   4 - Other useful outputs (Txa and XR)                                   2
        '
        Dim numCols As Integer = 1                  ' Independent 1 is always used

        If (TwoIndVarRadioButton.Checked) Then      ' Independent 2 may or may not be used
            numCols += 1
        End If

        If (OneDepVarRadioButton.Checked) Then      ' 0-4 Auxillary parameter may be used
            numCols += 1
        ElseIf (TwoDepVarRadioButton.Checked) Then
            numCols += 2
        ElseIf (ThreeDepVarRadioButton.Checked) Then
            numCols += 3
        ElseIf (FourDepVarRadioButton.Checked) Then
            numCols += 4
        End If

        ' Water Balance, Performance Indicators & other outputs are always in the DataTable;
        ' which ones are used will be selected when the results are displayed
        numCols += 13
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
        '
        ' Build Structured DataTable
        '
        StructDataTable = New DataTable("Structered Data")

        '
        ' Add the columns
        '
        Dim colName As String
        Dim groupIdx, selectIdx As Integer
        Dim colUnits As String

        ' Independent 1 is always used
        groupIdx = Indep1GroupValue.SelectedIndex
        selectIdx = Indep1ParamValue.SelectedIndex
        colUnits = GetCommandUnits(Indep1ParamValue.Text)
        'colUnits = GetUnitsText(groupIdx, selectIdx)

        colName = Indep1ParamValue.Text & "(" & colUnits & ") I1"
        StructDataTable.Columns.Add(colName, GetType(Double))

        ' Independent 2 may or may not be used
        If (TwoIndVarRadioButton.Checked) Then

            groupIdx = Indep2GroupValue.SelectedIndex
            selectIdx = Indep2ParamValue.SelectedIndex
            colUnits = GetCommandUnits(Indep2ParamValue.Text)
            'colUnits = GetUnitsText(groupIdx, selectIdx)

            colName = Indep2ParamValue.Text & "(" & colUnits & ") I2"
            StructDataTable.Columns.Add(colName, GetType(Double))

        End If

        ' 0-4 Auxillary parameter may be used
        If (0 < NumDepParams) Then

            groupIdx = Dep1ParamGroupValue.SelectedIndex
            selectIdx = Dep1SelParamValue.SelectedIndex
            colUnits = GetCommandUnits(Dep1SelParamValue.Text)
            'colUnits = GetUnitsText(groupIdx, selectIdx)

            colName = Dep1SelParamValue.Text & "(" & colUnits & ") D1"
            StructDataTable.Columns.Add(colName, GetType(Double))

        End If

        If (1 < NumDepParams) Then

            groupIdx = Dep2ParamGroupValue.SelectedIndex
            selectIdx = Dep2SelParamValue.SelectedIndex
            colUnits = GetCommandUnits(Dep2SelParamValue.Text)
            'colUnits = GetUnitsText(groupIdx, selectIdx)

            colName = Dep2SelParamValue.Text & "(" & colUnits & ") D2"
            StructDataTable.Columns.Add(colName, GetType(Double))

        End If

        If (2 < NumDepParams) Then

            groupIdx = Dep3ParamGroupValue.SelectedIndex
            selectIdx = Dep3SelParamValue.SelectedIndex
            colUnits = GetCommandUnits(Dep3SelParamValue.Text)
            'colUnits = GetUnitsText(groupIdx, selectIdx)

            colName = Dep3SelParamValue.Text & "(" & colUnits & ") D3"
            StructDataTable.Columns.Add(colName, GetType(Double))

        End If

        If (3 < NumDepParams) Then

            groupIdx = Dep4ParamGroupValue.SelectedIndex
            selectIdx = Dep4SelParamValue.SelectedIndex
            colUnits = GetCommandUnits(Dep4SelParamValue.Text)
            'colUnits = GetUnitsText(groupIdx, selectIdx)

            colName = Dep4SelParamValue.Text & "(" & colUnits & ") D4"
            StructDataTable.Columns.Add(colName, GetType(Double))

        End If

        ' All the calculated water balance components
        colName = "Dapp (m)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "Dinf (m)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "Ddp (m)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "Dro (m)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "Dmin (m)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "Dlq (m)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        ' Performance indicators calculated from the water balacne components
        colName = "AE (%)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "DUlq ()"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "DUmin()"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "RO (%)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "DP (%)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = "RE (%)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        ' Additional useful outputs
        colName = "Txa (s)"
        StructDataTable.Columns.Add(colName, GetType(Double))

        colName = " XR()"
        StructDataTable.Columns.Add(colName, GetType(Double))
        '
        ' Add the rows
        '
        If (TwoIndVarRadioButton.Checked) Then
            BuildTwoIndepVarsTable()
        Else
            BuildOneIndepVarTable()
        End If
        '
        ' Save Structured DataTable in BOTH Input and Output files

        Dim output As StreamWriter = Nothing

        Dim filepath As String = Me.InputFilename.Text

        Try
            ConvertDataTableToDisplayUnits(StructDataTable)

            output = New StreamWriter(filepath)

            If (output IsNot Nothing) Then
                ExportToFile(StructDataTable, output)
            End If

        Catch ex As Exception
            title = mDictionary.tErrOpeningWritingFile.Translated
            msg = mDictionary.tFile.Translated & ": " & filepath & Chr(13) & Chr(13)
            msg += ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)

        Finally
            If (output IsNot Nothing) Then
                output.Close()
                output = Nothing
            End If
        End Try

        filepath = Me.OutputFileName.Text

        Try
            ConvertDataTableToDisplayUnits(StructDataTable)

            output = New StreamWriter(filepath)

            If (output IsNot Nothing) Then
                ExportToFile(StructDataTable, output)
            End If

        Catch ex As Exception
            title = mDictionary.tErrOpeningWritingFile.Translated
            msg = mDictionary.tFile.Translated & ": " & filepath & Chr(13) & Chr(13)
            msg += ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)

        Finally
            If (output IsNot Nothing) Then
                output.Close()
                output = Nothing
            End If
        End Try

    End Sub

    Private Sub BuildOneIndepVarTable()

        Dim Indep1Increment As Double = (MaxInd1Val - MinInd1Val) / Ind1Incs
        Dim Indep2Increment As Double = (MaxInd2Val - MinInd2Val) / Ind2Incs

        Dim cdx As Integer

        For idx1 As Integer = 0 To Ind1Incs - 1

            Dim row As DataRow = StructDataTable.NewRow
            cdx = 0

            Dim Indep1RowValue As Double = MinInd1Val + idx1 * Indep1Increment
            row.Item(cdx) = Indep1RowValue
            cdx += 1

            ' 0-4 Auxillary parameter may be used
            If (0 < NumDepParams) Then
                row.Item(cdx) = 0
                cdx += 1
            End If

            If (1 < NumDepParams) Then
                row.Item(cdx) = 0
                cdx += 1
            End If

            If (2 < NumDepParams) Then
                row.Item(cdx) = 0
                cdx += 1
            End If

            If (3 < NumDepParams) Then
                row.Item(cdx) = 0
                cdx += 1
            End If

            ' All the calculated water balance components
            row.Item(cdx) = 0    ' Dapp
            cdx += 1
            row.Item(cdx) = 0    ' Dinf
            cdx += 1
            row.Item(cdx) = 0    ' Ddp
            cdx += 1
            row.Item(cdx) = 0    ' Dro
            cdx += 1
            row.Item(cdx) = 0    ' Dmin
            cdx += 1
            row.Item(cdx) = 0    ' Dlq
            cdx += 1

            ' Performance indicators calculated from the water balacne components
            row.Item(cdx) = 0    ' AE
            cdx += 1
            row.Item(cdx) = 0    ' DUlq
            cdx += 1
            row.Item(cdx) = 0    ' DUmin
            cdx += 1
            row.Item(cdx) = 0    ' RO
            cdx += 1
            row.Item(cdx) = 0    ' DP
            cdx += 1
            row.Item(cdx) = 0    ' RE
            cdx += 1

            ' Additional useful outputs
            row.Item(cdx) = 0    ' Txa
            cdx += 1
            row.Item(cdx) = 0    ' XR

            StructDataTable.Rows.Add(row)

        Next idx1

        Dim a As Integer = 0

    End Sub

    Private Sub BuildTwoIndepVarsTable()

        Dim Indep1Increment As Double = (MaxInd1Val - MinInd1Val) / Ind1Incs
        Dim Indep2Increment As Double = (MaxInd2Val - MinInd2Val) / Ind2Incs

        Dim cdx As Integer

        For idx1 As Integer = 0 To Ind1Incs - 1

            Dim row As DataRow = StructDataTable.NewRow
            cdx = 0

            Dim Indep1RowValue As Double = MinInd1Val + idx1 * Indep1Increment
            row.Item(cdx) = Indep1RowValue
            cdx += 1

            For idx2 As Integer = 0 To Ind2Incs - 1

                Dim Indep2RowValue As Double = MinInd2Val + idx2 * Indep2Increment
                row.Item(cdx) = Indep2RowValue
                cdx += 1

                ' 0-4 Auxillary parameter may be used
                If (0 < NumDepParams) Then
                    row.Item(cdx) = 0
                    cdx += 1
                End If

                If (1 < NumDepParams) Then
                    row.Item(cdx) = 0
                    cdx += 1
                End If

                If (2 < NumDepParams) Then
                    row.Item(cdx) = 0
                    cdx += 1
                End If

                If (3 < NumDepParams) Then
                    row.Item(cdx) = 0
                    cdx += 1
                End If

                ' All the calculated water balance components
                row.Item(cdx) = 0    ' Dapp
                cdx += 1
                row.Item(cdx) = 0    ' Dinf
                cdx += 1
                row.Item(cdx) = 0    ' Ddp
                cdx += 1
                row.Item(cdx) = 0    ' Dro
                cdx += 1
                row.Item(cdx) = 0    ' Dmin
                cdx += 1
                row.Item(cdx) = 0    ' Dlq
                cdx += 1

                ' Performance indicators calculated from the water balacne components
                row.Item(cdx) = 0    ' AE
                cdx += 1
                row.Item(cdx) = 0    ' DUlq
                cdx += 1
                row.Item(cdx) = 0    ' DUmin
                cdx += 1
                row.Item(cdx) = 0    ' RO
                cdx += 1
                row.Item(cdx) = 0    ' DP
                cdx += 1
                row.Item(cdx) = 0    ' RE
                cdx += 1

                ' Additional useful outputs
                row.Item(cdx) = 0    ' Txa
                cdx += 1

                row.Item(cdx) = 0    ' XR

                StructDataTable.Rows.Add(row)

                row = StructDataTable.NewRow
                cdx = 0

                Indep1RowValue = MinInd1Val + idx1 * Indep1Increment
                row.Item(cdx) = Indep1RowValue
                cdx += 1

            Next idx2

        Next idx1

        Dim a As Integer = 0

    End Sub

#End Region

End Class
