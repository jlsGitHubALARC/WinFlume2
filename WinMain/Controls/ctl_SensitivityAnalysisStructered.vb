
'************************************************************************************************************
' Class ctl_SensitivityAnalysisInputs - UserControl for defining the dependent and indepentent irrigation
'                                       parameters for Sensiivity Analysis
'
'************************************************************************************************************
Imports System.IO

Imports Srfr
Imports Srfr.SrfrAPI

Imports DataStore

Public Class ctl_SensitivityAnalysisStructured

    Friend WithEvents OutputFilename As TextBox
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

    Protected mInitiazing As Boolean = True

    Protected UseCompressedId As Boolean = False

#End Region

#Region " Properties "
    '
    ' Unit Reference
    '
    Public Property UnitRef As Unit = Nothing
    '
    ' Independent Parameters are Inflow Rate (Qin) and Cutoff Time (Tco)
    '
    Public Const MinIndepParams As Integer = 1
    Public Const MaxIndepParams As Integer = 2
    Public Property NumIndepParams As Integer = MinIndepParams

    ' Inflow Rate (Qin) range
    Public Property QinMin As Double = Q0min
    Public Property QinDef As Double = Q0def
    Public Property QinIncs As Integer = 10             ' Number of increments for Qin

    Public Property QinParam As String = "System Geometry"

    Public Property QinUnitsTxt As String
    Public Property QinUnitsVal As Double

    ' Cutoff Time (Tco) range
    Public Property TcoMin As Double = 3600.0 ' 1 hr
    Public Property TcoDef As Double = 7200.0 ' 2 hr
    Public Property TcoIncs As Integer = 10             ' Number of increments for Tco

    Public Property TcoParam As String = "System Geometry"

    Public Property TcoUnitsTxt As String
    Public Property TcoUnitsVal As Double

    Public Function NumPoints() As Integer              ' Number of points (rows) in resulting DataTable
        Return QinIncs * TcoIncs + 1                    ' + 1 is for last fence post
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
        OneDepVarRadioButton.Checked = True

        ' Inflow Rate
        InflowRateGroupValue.SelectedIndex = 0              ' Group value
        InflowRateParamValue.SelectedIndex = 0              ' Parameter value

        MinQinValue.Text = "0"                              ' Inflow Rate range
        MaxQinValue.Text = "0"

        QinContourGridSizeValue.SelectedIndex = 0           ' Grid size

        ' Cutoff Time
        CutoffTimeGroupValue.SelectedIndex = 0
        CutoffTimeParamValue.SelectedIndex = 0

        MinTcoValue.Text = "0"                              ' Inflow Rate range
        MaxTcoValue.Text = "0"

        TcoContourGridSizeValue.SelectedIndex = 0

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
        InflowRateBox.Show()                                    ' Inflow Rate is always visible

        UnitsText = mUnit.InflowManagementRef.InflowRate.UnitsString
        QinUnitsText.Text = UnitsText

        UnitsText = GetUnitsText(InflowRateGroupValue.SelectedIndex, InflowRateParamValue.SelectedIndex)
        QinSelParamUnits.Text = UnitsText

        If (1 < NumIndepParams) Then                            ' Cutoff Time may or may not be shown
            CutoffTimeBox.Show()

            UnitsText = mUnit.InflowManagementRef.CutoffTime.UnitsString
            TcoUnitsText.Text = UnitsText

            UnitsText = GetUnitsText(CutoffTimeGroupValue.SelectedIndex, CutoffTimeParamValue.SelectedIndex)
            TcoSelParamUnits.Text = UnitsText

        Else
            CutoffTimeBox.Hide()
        End If
        '
        ' Dependent Parameters
        '
        Dependent1GroupBox.Show()                           ' Dependent 1 is always visible

        Dep1ParamGroupValue.Items.Clear()
        Dep1ParamGroupValue.Items.Add(InflowRateGroupValue.Items(InflowRateGroupValue.SelectedIndex))

        If (1 < NumIndepParams) Then
            Dep1ParamGroupValue.Items.Add(CutoffTimeGroupValue.Items(CutoffTimeGroupValue.SelectedIndex))
        End If

        Dep1ParamGroupValue.SelectedIndex = 0

        If (1 < NumDepParams) Then                          ' Dependent 2/3/4 may or may not be shown
            Dependent2GroupBox.Show()

            Dep2ParamGroupValue.Items.Clear()
            Dep2ParamGroupValue.Items.Add(InflowRateGroupValue.Items(InflowRateGroupValue.SelectedIndex))

            If (1 < NumIndepParams) Then
                Dep2ParamGroupValue.Items.Add(CutoffTimeGroupValue.Items(CutoffTimeGroupValue.SelectedIndex))
            End If

            Dep2ParamGroupValue.SelectedIndex = 0
        Else
            Dependent2GroupBox.Hide()
        End If

        If (2 < NumDepParams) Then
            Dependent3GroupBox.Show()

            Dep3ParamGroupValue.Items.Clear()
            Dep3ParamGroupValue.Items.Add(InflowRateGroupValue.Items(InflowRateGroupValue.SelectedIndex))

            If (1 < NumIndepParams) Then
                Dep3ParamGroupValue.Items.Add(CutoffTimeGroupValue.Items(CutoffTimeGroupValue.SelectedIndex))
            End If

            Dep3ParamGroupValue.SelectedIndex = 0
        Else
            Dependent3GroupBox.Hide()
        End If

        If (3 < NumDepParams) Then
            Dependent4GroupBox.Show()

            Dep4ParamGroupValue.Items.Clear()
            Dep4ParamGroupValue.Items.Add(InflowRateGroupValue.Items(InflowRateGroupValue.SelectedIndex))

            If (1 < NumIndepParams) Then
                Dep4ParamGroupValue.Items.Add(CutoffTimeGroupValue.Items(CutoffTimeGroupValue.SelectedIndex))
            End If

            Dep4ParamGroupValue.SelectedIndex = 0
        Else
            Dependent4GroupBox.Hide()
        End If

        ' Allow another call to UpdateUI()
        mUpdating = False

    End Sub

    Private mUpdatingQin As Boolean = False
    Protected Sub UpdateQinGroup(ByVal ParameterGroup As ctl_SelectParameter,
                                 ByVal ParameterValue As ctl_SelectParameter)
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateQinGroup() generates many events that require additional calls to UpdateQinGroup()
        '  Without this check, the call stack would overflow
        '
        If (mUpdatingQin) Then
            Return
        Else
            mUpdatingQin = True
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

        ' Allow another call to UpdateQinGroup()
        mUpdatingQin = False

    End Sub

    Private mUpdatingTco As Boolean = False
    Protected Sub UpdateTcoGroup(ByVal ParameterGroup As ctl_SelectParameter,
                                 ByVal ParameterValue As ctl_SelectParameter)
        '
        ' Wait for one Update to complete before running the next one
        '  Each call to UpdateTcoGroup() generates many events that require additional calls to UpdateTcoGroup()
        '  Without this check, the call stack would overflow
        '
        If (mUpdatingTco) Then
            Return
        Else
            mUpdatingTco = True
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

        ' Allow another call to UpdateTcoGroup()
        mUpdatingTco = False

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

    ' Inflow Rate (Qin)
    Private Sub InflowRateGroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles InflowRateGroupValue.SelectedIndexChanged
        If (InflowRateGroupValue.SelectedIndex < 0) Then
            InflowRateGroupValue.SelectedIndex = 0
        End If

        UpdateQinGroup(InflowRateGroupValue, InflowRateParamValue)

        UpdateUI()
    End Sub

    Private mHandlingQinSelIndChange As Boolean = False
    Private Sub InflowRateParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles InflowRateParamValue.SelectedIndexChanged
        If (mHandlingQinSelIndChange) Then
            Return
        Else
            mHandlingQinSelIndChange = True
        End If

        If (InflowRateParamValue.SelectedIndex < 0) Then
            InflowRateParamValue.SelectedIndex = 0
        End If

        UpdateQinGroup(InflowRateGroupValue, InflowRateParamValue)

        UpdateUI()
        mHandlingQinSelIndChange = False
    End Sub

    ' Cutoff Time (Tco)
    Private Sub CutoffTimeGroupValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles CutoffTimeGroupValue.SelectedIndexChanged
        If (CutoffTimeGroupValue.SelectedIndex < 0) Then
            CutoffTimeGroupValue.SelectedIndex = 0
        End If

        UpdateTcoGroup(CutoffTimeGroupValue, CutoffTimeParamValue)

        UpdateUI()
    End Sub

    Private mHandlingTcoSelIndChange As Boolean = False
    Private Sub CutoffTimeParamValue_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles CutoffTimeParamValue.SelectedIndexChanged
        If (mHandlingTcoSelIndChange) Then
            Return
        Else
            mHandlingTcoSelIndChange = True
        End If

        If (CutoffTimeParamValue.SelectedIndex < 0) Then
            CutoffTimeParamValue.SelectedIndex = 0
        End If

        UpdateTcoGroup(CutoffTimeGroupValue, CutoffTimeParamValue)

        UpdateUI()
        mHandlingTcoSelIndChange = False
    End Sub

    ' Values simply need to be saved
    Private Sub MinQinValue_ControlValueChanged() _
        Handles MinQinValue.TextChanged

        Try
            Dim MinQin As Double = Double.Parse(MinQinValue.Text)

            If (MinQin < 0) Then
                MinQin = 0
            End If

            MinQinValue.Text = MinQin.ToString
        Catch ex As Exception
            MinQinValue.Text = "0"
        End Try

    End Sub

    Private Sub MaxQinValue_ControlValueChanged() _
        Handles MaxQinValue.TextChanged

        Try
            Dim MaxQin As Double = Double.Parse(MaxQinValue.Text)

            If (MaxQin < 0) Then
                MaxQin = 0
            End If

            MaxQinValue.Text = MaxQin.ToString
        Catch ex As Exception
            MaxQinValue.Text = "0"
        End Try

    End Sub

    Private Sub MinTcoValue_ControlValueChanged() _
        Handles MinTcoValue.TextChanged

        Try
            Dim MinTco As Double = Double.Parse(MinTcoValue.Text)

            If (MinTco < 0) Then
                MinTco = 0
            End If

            MinTcoValue.Text = MinTco.ToString
        Catch ex As Exception
            MinTcoValue.Text = "0"
        End Try

    End Sub

    Private Sub MaxTcoValue_ControlValueChanged() _
        Handles MaxTcoValue.TextChanged

        Try
            Dim MaxTco As Double = Double.Parse(MaxTcoValue.Text)

            If (MaxTco < 0) Then
                MaxTco = 0
            End If

            MaxTcoValue.Text = MaxTco.ToString
        Catch ex As Exception
            MaxTcoValue.Text = "0"
        End Try

    End Sub
    '
    ' Dependant Variable Events
    '

    ' UI needs to be updated based on the number of and selection of the dependent variables
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

    End Sub

    Private Sub BrowseInputFileButton_Click(sender As Object, e As EventArgs) _
        Handles BrowseInputFileButton.Click
        Dim QinGroupVal As Integer = InflowRateGroupValue.SelectedIndex
        Dim QinGroupTxt As String = InflowRateGroupValue.Text
        Dim QinParamVal As Integer = InflowRateParamValue.SelectedIndex
        Dim QinParamTxt As String = InflowRateParamValue.Text

        Dim QinUnits As String = GetUnitsText(QinGroupVal, QinParamVal)
    End Sub

    Private Sub OutputFilename_TextChanged(sender As Object, e As EventArgs) _
        Handles OutputFilename.TextChanged

    End Sub

    Private Sub BrowseOutputFileButton_Click(sender As Object, e As EventArgs) _
        Handles BrowseOutputFileButton.Click

    End Sub

    Private Sub ClearResultsFile_CheckedChanged(sender As Object, e As EventArgs) _
        Handles ClearResultsFile.CheckedChanged

    End Sub

    Private Sub AddParameter(ByVal ControlSelectParameter As ctl_SelectParameter,
                             ByVal command As String, ByRef ParamIdx As Integer)

        Dim tokens() As String = command.Split(" ".ToCharArray)
        Dim id As String = ""

        For idx As Integer = 0 To tokens.Length - 2
            id &= tokens(idx) & " "
        Next

        If (0 < tokens.Length) Then
            ControlSelectParameter.Add(id, ParamIdx)
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

End Class
