
'**********************************************************************************************
' Class CommandInterface - Command / Query parser for WinSRFR
'
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Imports DataStore

Public Class CommandInterface

#Region " Member Data "

    Private WithEvents mWinSRFR As WinSRFR

    Private mUnits As UnitsSystem = UnitsSystem.Instance()

    Private mSeparators As String = " ."

#End Region

#Region " Properties "

    ' Reference to WinSRFR's Remote Command Interface
    Private WithEvents mRemoteInterface As WinSrfrCommandInterface.WinSrfrCommandInterface
    'Public ReadOnly Property RemoteInterface() As WinSrfrCommandInterface.WinSrfrCommandInterface
    '    Get
    '        Return mRemoteInterface
    '    End Get
    'End Property

    'Private mPort As Integer = 8047
    'Public ReadOnly Property Port() As Integer
    '    Get
    '        Return mPort
    '    End Get
    'End Property

    'Private mChannel As HttpChannel
    'Public ReadOnly Property Channel() As HttpChannel
    '    Get
    '        Return mChannel
    '    End Get
    'End Property

#End Region

#Region " Constructors "

    ' Disable default constructor
    Private Sub New()
    End Sub

    ' Provide usable constructor
    Public Sub New(ByVal _winSRFR As WinSRFR)
        ' Save reference to WinSRFR application
        mWinSRFR = _winSRFR
    End Sub

#End Region

#Region " Initialization "

    'Public Function SetupRemoteChannel() As Boolean

    '    Try
    '        ' Create & register Http Channel
    '        'mChannel = New HttpChannel(mPort)
    '        'ChannelServices.RegisterChannel(mChannel, False)

    '        ' Instantiate WinSRFR's remote Command Interface
    '        mRemoteInterface = New WinSrfrCommandInterface.WinSrfrCommandInterface

    '        ' Marshal instantiated Command Interface for use by client applications
    '        RemotingServices.SetObjectUriForMarshal(mRemoteInterface, "WinSrfrCommandInterface")
    '        RemotingServices.Marshal(mRemoteInterface)

    '    Catch ex As Exception
    '        'MsgBox(ex.Message, MsgBoxStyle.Information, "CommandInterface.New()")
    '        Return False
    '    End Try

    '    Return True
    'End Function

#End Region

#Region " Command Parsers "

#Region " Parse Command "
    '
    ' Receive Remote Interface Command
    '
    ' NOTE - execution is running in client's thread; call must be marshalled to the
    '        main thread for WinSRFR to execute the command properly.
    '
    Private Sub RemoteInterface_RemoteCommand(ByVal command As String, ByRef result As Integer) _
    Handles mRemoteInterface.RemoteCommand
        ' Get delegate to WinSRFR method
        Dim parseCommand As WinSRFR.ParseCommandDelegate = AddressOf mWinSRFR.ParseCommand
        ' Invoke requires array of Objects for method arguments
        Dim args As Object() = {command}
        ' Marshall call to main thread
        result = mWinSRFR.Invoke(parseCommand, args)
    End Sub
    '
    ' WinSRFR's ParseCommand method returns execution control here; now using main thread
    '
    ' Parse 1st token from command; call appropriate 2nd level parser
    '
    Public Function ParseCommand(ByVal command As String) As ParseError
        command = command.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = command.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim menu As String = tokens(0).ToLower()
            Select Case menu
                Case "file"
                    result = Me.ParseFileCommand(tokens(1))
                Case "edit"
                    result = Me.ParseEditCommand(tokens(1))
                Case "view"
                    result = Me.ParseViewCommand(tokens(1))
                Case "farm", "project"
                    result = Me.ParseFarmCommand(tokens(1))
                Case "field", "case"
                    result = Me.ParseFieldCommand(tokens(1))
                Case "world", "folder"
                    result = Me.ParseWorldCommand(tokens(1))
                Case "analysis", "simulation"
                    result = Me.ParseAnalysisCommand(tokens(1))
                Case WinSRFR.MyID.ToLower
                    ' DataStore command aimed at the root ObjectNode
                    Dim _dataStore As DataStore.ObjectNode = mWinSRFR.MyStore
                    If Not (_dataStore Is Nothing) Then
                        result = _dataStore.ParseCommand(tokens(1))
                    End If
                Case Else
                    ' DataStore command aimed at an Analysis ObjectNode
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        Dim _dataStore As DataStore.ObjectNode = _analysis.MyStore
                        If Not (_dataStore Is Nothing) Then
                            result = _dataStore.ParseCommand(command)
                            If Not (result = ParseError.ParseOK) Then ' command not found thru normal hierarchy
                                result = _dataStore.ParseCommand(command, True) ' try drilling down
                            End If
                        End If
                    End If
            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function
    '
    ' Prepare token for easier, consistent use
    '
    Private Function ParseParameter(ByRef token As String) As ParseError
        token = token.Trim.ToLower  ' Trim extraneous whitespace & Convert to lower case

        Dim result As ParseError = ParseError.ParseOK

        ' Strip off leading ", if present
        If (0 < token.Length) Then
            If (token.Chars(0) = """") Then
                token = token.Substring(1)
            End If
        End If

        ' Strip off trailing ", if present
        If (0 < token.Length) Then
            If (token.Chars(token.Length - 1) = """") Then
                token = token.Substring(0, token.Length - 1)
            End If
        End If

        ' Is there anything left?
        If (0 = token.Length) Then
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

#End Region

#Region " File Commands "
    '
    ' Parse / execute File menu commands
    '
    Private Function ParseFileCommand(ByVal command As String) As ParseError
        command = command.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = command.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "new"
                    mWinSRFR.NewProject(False)
                    result = ParseError.ParseOK

                Case "open"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            mWinSRFR.CloseProject(False)
                            mWinSRFR.OpenProject(tokens(1))
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "close"
                    mWinSRFR.CloseProject(False)
                    result = ParseError.ParseOK

                Case "clearallresults"
                    mWinSRFR.ClearAllResults()
                    result = ParseError.ParseOK

                Case "save"
                    mWinSRFR.Save()
                    result = ParseError.ParseOK

                Case "saveas"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            mWinSRFR.SaveProject(tokens(1))
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "examples"
                    If (1 < tokens.Length) Then
                        Try
                            Dim n As Integer = Integer.Parse(tokens(1))
                            If ((0 < n) And (n < 10)) Then
                                Dim examplesDirectory As String = Application.CommonAppDataPath + "\Examples\"
                                Dim exampleFile As String = examplesDirectory + mWinSRFR.ExamplesFileList(n)
                                mWinSRFR.CloseProject(False)
                                mWinSRFR.OpenProject(exampleFile)
                                result = ParseError.ParseOK
                            Else
                                result = ParseError.BadValueType
                            End If
                        Catch ex As Exception
                            result = ParseError.BadValueType
                        End Try
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "recent"
                    If (1 < tokens.Length) Then
                        Try
                            Dim n As Integer = Integer.Parse(tokens(1))
                            If ((0 < n) And (n < 10)) Then
                                Dim mruFile As String = mWinSRFR.MruProjectList(n)
                                mWinSRFR.CloseProject(False)
                                mWinSRFR.OpenProject(mruFile)
                                result = ParseError.ParseOK
                            Else
                                result = ParseError.BadValueType
                            End If
                        Catch ex As Exception
                            result = ParseError.BadValueType
                        End Try
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "exit"
                    mWinSRFR.ExitProgram(False)
                    result = ParseError.ParseOK

                Case Else
            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

#End Region

#Region " Edit Commands "
    '
    ' Parse / execute Edit menu commands
    '
    Private Function ParseEditCommand(ByVal command As String) As ParseError
        command = command.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = command.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()

            Select Case item
                Case "nomenclature"
                    If (1 < tokens.Length) Then
                        Dim param As String = tokens(1).ToLower()
                        Select Case param
                            Case "project"
                                mWinSRFR.ProjectNomenclature = ProjectNomenclatures.ProjectCase
                            Case Else
                                mWinSRFR.ProjectNomenclature = ProjectNomenclatures.FarmField
                        End Select
                        result = ParseError.ParseOK
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "windowsize"
                    If (1 < tokens.Length) Then
                        Dim param As String = tokens(1).ToLower()
                        Select Case param
                            Case "800x600"
                                mWinSRFR.WindowSize = WindowSizes.S800x600
                            Case "900x675"
                                mWinSRFR.WindowSize = WindowSizes.S900x675
                            Case Else
                                mWinSRFR.WindowSize = WindowSizes.S1024x768
                        End Select
                        result = ParseError.ParseOK
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "userlevel"
                    If (1 < tokens.Length) Then
                        Dim param As String = tokens(1).ToLower()
                        Select Case param
                            Case "advanced"
                                mWinSRFR.UserLevel = UserLevels.Advanced
                            Case Else
                                mWinSRFR.UserLevel = UserLevels.Standard
                        End Select
                        result = ParseError.ParseOK
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "units"
                    If (1 < tokens.Length) Then
                        Dim param As String = tokens(1).ToLower()
                        Select Case param
                            Case "english"
                                mUnits.UnitSystem = UnitsDefinition.UnitSystems.English
                            Case Else
                                mUnits.UnitSystem = UnitsDefinition.UnitSystems.Metric
                        End Select
                        result = ParseError.ParseOK
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case Else
            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

#End Region

#Region " View Commands "
    '
    ' Parse / execute View menu commands
    '
    Private Function ParseViewCommand(ByVal command As String) As ParseError
        command = command.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = command.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "refresh"
                    mWinSRFR.Refresh()
                    result = ParseError.ParseOK

                Case Else

            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

#End Region

#Region " Farm Commands "
    '
    ' Parse / execute Analysis Explorer Farm commands
    '
    Private Function ParseFarmCommand(ByVal command As String) As ParseError
        command = command.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = command.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "name"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _name As StringParameter = mWinSRFR.SelectedFarm.Name
                            _name.Value = tokens(1)
                            mWinSRFR.SelectedFarm.Name = _name
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "addfield", "addcase"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _field As Field = mWinSRFR.SelectedFarm.AddField()
                            Dim _name As StringParameter = _field.Name
                            _name.Value = tokens(1)
                            _field.Name = _name
                            mWinSRFR.AnalysisExplorer.AddField(_field)
                            mWinSRFR.SelectedField = _field
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "selectfield", "selectcase"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _farm As Farm = mWinSRFR.SelectedFarm
                            If Not (_farm Is Nothing) Then
                                Dim _field As Field = _farm.GetFieldByName(tokens(1))
                                If Not (_field Is Nothing) Then
                                    mWinSRFR.SelectedField = _field
                                    result = ParseError.ParseOK
                                End If
                            End If
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "pastefield", "pastecase"
                    Dim _farm As Farm = mWinSRFR.SelectedFarm
                    If Not (_farm Is Nothing) Then
                        mWinSRFR.PasteField(_farm)
                        result = ParseError.ParseOK
                    End If

                Case Else
            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

#End Region

#Region " Field Commands "
    '
    ' Parse / execute Analysis Explorer Field commands
    '
    Private Function ParseFieldCommand(ByVal command As String) As ParseError
        command = command.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = command.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "name"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _name As StringParameter = mWinSRFR.SelectedField.Name
                            _name.Value = tokens(1)
                            mWinSRFR.SelectedField.Name = _name
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "addeventworld"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _world As World = mWinSRFR.SelectedField.AddWorld(WorldTypes.EventWorld)
                            Dim _name As StringParameter = _world.Name
                            _name.Value = tokens(1)
                            _world.Name = _name
                            mWinSRFR.AnalysisExplorer.AddWorld(_world)
                            mWinSRFR.SelectedWorld = _world
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "adddesignworld"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _world As World = mWinSRFR.SelectedField.AddWorld(WorldTypes.DesignWorld)
                            Dim _name As StringParameter = _world.Name
                            _name.Value = tokens(1)
                            _world.Name = _name
                            mWinSRFR.AnalysisExplorer.AddWorld(_world)
                            mWinSRFR.SelectedWorld = _world
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "addoperationsworld"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _world As World = mWinSRFR.SelectedField.AddWorld(WorldTypes.OperationsWorld)
                            Dim _name As StringParameter = _world.Name
                            _name.Value = tokens(1)
                            _world.Name = _name
                            mWinSRFR.AnalysisExplorer.AddWorld(_world)
                            mWinSRFR.SelectedWorld = _world
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "addsimulationworld"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _world As World = mWinSRFR.SelectedField.AddWorld(WorldTypes.SimulationWorld)
                            Dim _name As StringParameter = _world.Name
                            _name.Value = tokens(1)
                            _world.Name = _name
                            mWinSRFR.AnalysisExplorer.AddWorld(_world)
                            mWinSRFR.SelectedWorld = _world
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "selectworld", "selectfolder"
                    tokens = tokens(1).Split(" .,".ToCharArray, 2)

                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(0))
                        If (result = ParseError.ParseOK) Then

                            Dim type As WorldTypes = WorldTypes.LowLimit
                            Select Case tokens(0)
                                Case "event"
                                    type = WorldTypes.EventWorld
                                Case "design"
                                    type = WorldTypes.DesignWorld
                                Case "operations"
                                    type = WorldTypes.OperationsWorld
                                Case "simulation"
                                    type = WorldTypes.SimulationWorld
                            End Select

                            If Not (type = WorldTypes.LowLimit) Then
                                result = Me.ParseParameter(tokens(1))
                                If (result = ParseError.ParseOK) Then
                                    Dim _field As Field = mWinSRFR.SelectedField
                                    If Not (_field Is Nothing) Then
                                        Dim _world As World = _field.GetWorldByName(type, tokens(1))
                                        If Not (_world Is Nothing) Then
                                            mWinSRFR.SelectedWorld = _world
                                            result = ParseError.ParseOK
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "pasteworld", "pastefolder"
                    Dim _field As Field = mWinSRFR.SelectedField
                    If Not (_field Is Nothing) Then
                        mWinSRFR.PasteWorld(_field)
                        result = ParseError.ParseOK
                    End If

                Case "remove" ' Field
                    Dim _farm As Farm = mWinSRFR.SelectedFarm
                    Dim _field As Field = mWinSRFR.SelectedField
                    _farm.RemoveField(_field)
                    result = ParseError.ParseOK

                Case "cut" ' Field
                    Dim _field As Field = mWinSRFR.SelectedField
                    If Not (_field Is Nothing) Then
                        mWinSRFR.CutField(_field)
                        result = ParseError.ParseOK
                    End If

                Case "copy" ' Field
                    Dim _field As Field = mWinSRFR.SelectedField
                    If Not (_field Is Nothing) Then
                        mWinSRFR.CopyField(_field)
                        result = ParseError.ParseOK
                    End If

                Case Else
            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

#End Region

#Region " World Commands "
    '
    ' Parse / execute Analysis Explorer World commands
    '
    Private Function ParseWorldCommand(ByVal command As String) As ParseError
        command = command.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = command.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "name"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _name As StringParameter = mWinSRFR.SelectedWorld.Name
                            _name.Value = tokens(1)
                            mWinSRFR.SelectedWorld.Name = _name
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "addanalysis", "addsimulation"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _analysis As Unit = mWinSRFR.SelectedWorld.AddAnalysis()
                            Dim _name As StringParameter = _analysis.Name
                            _name.Value = tokens(1)
                            _analysis.Name = _name
                            mWinSRFR.AnalysisExplorer.AddAnalysis(_analysis)
                            mWinSRFR.SelectedAnalysis = _analysis
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "selectanalysis", "selectsimulation"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _world As World = mWinSRFR.SelectedWorld
                            If Not (_world Is Nothing) Then
                                Dim _analysis As Unit = _world.GetAnalysisByName(tokens(1))
                                If Not (_analysis Is Nothing) Then
                                    mWinSRFR.SelectedAnalysis = _analysis
                                    result = ParseError.ParseOK
                                End If
                            End If
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "pasteanalysis", "pastesimulation"
                    Dim _world As World = mWinSRFR.SelectedWorld
                    If Not (_world Is Nothing) Then
                        mWinSRFR.PasteAnalysis(_world)
                        result = ParseError.ParseOK
                    End If

                Case "remove" ' World
                    Dim _field As Field = mWinSRFR.SelectedField
                    Dim _world As World = mWinSRFR.SelectedWorld
                    _field.RemoveWorld(_world)
                    result = ParseError.ParseOK

                Case "cut" ' World
                    Dim _world As World = mWinSRFR.SelectedWorld
                    If Not (_world Is Nothing) Then
                        mWinSRFR.CutWorld(_world)
                        result = ParseError.ParseOK
                    End If

                Case "copy" ' World
                    Dim _world As World = mWinSRFR.SelectedWorld
                    If Not (_world Is Nothing) Then
                        mWinSRFR.CopyWorld(_world)
                        result = ParseError.ParseOK
                    End If

                Case Else
            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

#End Region

#Region " Analysis Commands "
    '
    ' Parse / execute Analysis Explorer Analysis commands
    '
    Private Function ParseAnalysisCommand(ByVal command As String) As ParseError
        command = command.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = command.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "name"
                    If (1 < tokens.Length) Then
                        result = Me.ParseParameter(tokens(1))
                        If (result = ParseError.ParseOK) Then
                            Dim _name As StringParameter = mWinSRFR.SelectedAnalysis.Name
                            _name.Value = tokens(1)
                            mWinSRFR.SelectedAnalysis.Name = _name
                            result = ParseError.ParseOK
                        End If
                    Else
                        result = ParseError.NotEnoughTokens
                    End If

                Case "open" ' Analysis
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        mWinSRFR.ShowUnit(_analysis)
                        result = ParseError.ParseOK
                    End If

                Case "close" ' Analysis
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        mWinSRFR.HideUnit(_analysis)
                        result = ParseError.ParseOK
                    End If

                Case "remove" ' Analysis
                    Dim _world As World = mWinSRFR.SelectedWorld
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    _world.RemoveAnalysis(_analysis)
                    result = ParseError.ParseOK

                Case "cut" ' Analysis
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        mWinSRFR.CutAnalysis(_analysis)
                        result = ParseError.ParseOK
                    End If

                Case "copy" ' Analysis
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        mWinSRFR.CopyAnalysis(_analysis)
                        result = ParseError.ParseOK
                    End If

                Case "run" ' Analysis
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        mWinSRFR.Run(_analysis)
                        result = ParseError.ParseOK
                    End If

                Case Else
            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

#End Region

#End Region

#Region " Query Parsers "

#Region " String Query Parsers "
    '
    ' Receive Remote Interface Query
    '
    ' NOTE - execution is running in client's thread; call must be marshalled to the
    '        main thread for WinSRFR to execute properly.
    '
    Private Sub RemoteInterface_RemoteStringQuery(ByVal query As String, ByRef reply As String, ByRef result As Integer) _
    Handles mRemoteInterface.RemoteStringQuery
        ' Get delegate to WinSRFR method
        Dim parseQuery As WinSRFR.ParseStringQueryDelegate = AddressOf mWinSRFR.ParseStringQuery
        ' Invoke requires array of Objects for method arguments
        Dim args As Object() = {query, reply}
        ' Marshall call to main thread
        result = mWinSRFR.Invoke(parseQuery, New Object() {args})
        ' Retrieve query reply from argument list
        reply = CStr(args(1))
    End Sub

    Public Function ParseStringQuery(ByVal query As String, ByRef reply As String) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(mSeparators.ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim menu As String = tokens(0).ToLower()
            Select Case menu
                Case "file"
                    result = Me.ParseFileStringQuery(tokens(1), reply)
                Case "edit"
                    result = Me.ParseEditStringQuery(tokens(1), reply)
                Case "farm", "project"
                    result = Me.ParseFarmStringQuery(tokens(1), reply)
                Case "field", "case"
                    result = Me.ParseFieldStringQuery(tokens(1), reply)
                Case "world", "folder"
                    result = Me.ParseWorldStringQuery(tokens(1), reply)
                Case "analysis", "simulation"
                    result = Me.ParseAnalysisStringQuery(tokens(1), reply)
                Case WinSRFR.MyID.ToLower
                    ' DataStore query aimed at the root ObjectNode
                    Dim _dataStore As DataStore.ObjectNode = mWinSRFR.MyStore
                    If Not (_dataStore Is Nothing) Then
                        result = _dataStore.ParseStringQuery(tokens(1), reply)
                    End If
                Case Else
                    ' DataStore query aimed at an Analysis ObjectNode
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        Dim _dataStore As DataStore.ObjectNode = _analysis.MyStore
                        If Not (_dataStore Is Nothing) Then
                            result = _dataStore.ParseStringQuery(query, reply)
                        End If
                    End If
            End Select
        End If

        Return result
    End Function

    Private Function ParseFileStringQuery(ByVal query As String, ByRef reply As String) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(mSeparators.ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "name"
                    reply = """" + mWinSRFR.FileName + """"
                    result = ParseError.ParseOK

                Case "path"
                    reply = """" + mWinSRFR.FilePath + """"
                    result = ParseError.ParseOK

            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

    Private Function ParseEditStringQuery(ByVal query As String, ByRef reply As String) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(mSeparators.ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "nomenclature"
                    Select Case mWinSRFR.ProjectNomenclature
                        Case Globals.ProjectNomenclatures.ProjectCase
                            reply = "Project"
                        Case Else ' Assume Globals.ProjectNomenclatures.FarmField
                            reply = "Farm"
                    End Select
                    result = ParseError.ParseOK

                Case "windowsize"
                    Select Case mWinSRFR.WindowSize
                        Case Globals.WindowSizes.S800x600
                            reply = "800x600"
                        Case Globals.WindowSizes.S900x675
                            reply = "900x675"
                        Case Else ' Globals.WindowSizes.S1024x768
                            reply = "1024x768"
                    End Select
                    result = ParseError.ParseOK

                Case "userlevel"
                    Select Case mWinSRFR.UserLevel
                        Case Globals.UserLevels.Advanced
                            reply = "Advanced"
                        Case Else ' Assume Globals.UserLevels.Standard
                            reply = "Standard"
                    End Select
                    result = ParseError.ParseOK

                Case "units"
                    Select Case mUnits.UnitSystem
                        Case UnitsDefinition.UnitSystems.English
                            reply = "English"
                        Case Else ' Assume UnitsDefinition.UnitSystems.Metric
                            reply = "Metric"
                    End Select
                    result = ParseError.ParseOK

            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

    Private Function ParseFarmStringQuery(ByVal query As String, ByRef reply As String) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(mSeparators.ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "selectedfield"
                    Dim _field As Field = mWinSRFR.SelectedField
                    If Not (_field Is Nothing) Then
                        reply = """" + _field.Name.Value + """"
                    Else
                        reply = String.Empty
                    End If
                    result = ParseError.ParseOK

                Case "firstfield"
                    Dim _farm As Farm = mWinSRFR.SelectedFarm
                    If Not (_farm Is Nothing) Then
                        Dim _field As Field = _farm.GetFirstField
                        If Not (_field Is Nothing) Then
                            reply = """" + _field.Name.Value + """"
                        Else
                            reply = String.Empty
                        End If
                        result = ParseError.ParseOK
                    End If

                Case "nextfield"
                    Dim _farm As Farm = mWinSRFR.SelectedFarm
                    If Not (_farm Is Nothing) Then
                        Dim _field As Field = _farm.GetNextField
                        If Not (_field Is Nothing) Then
                            reply = """" + _field.Name.Value + """"
                        Else
                            reply = String.Empty
                        End If
                        result = ParseError.ParseOK
                    End If

            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

    Private Function ParseFieldStringQuery(ByVal query As String, ByRef reply As String) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(mSeparators.ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "selectedworld"
                    Dim _world As World = mWinSRFR.SelectedWorld
                    If Not (_world Is Nothing) Then
                        reply = """" + _world.Name.Value + """"
                    Else
                        reply = String.Empty
                    End If
                    result = ParseError.ParseOK

                Case "firstworld"
                    Dim _field As Field = mWinSRFR.SelectedField
                    If Not (_field Is Nothing) Then
                        Dim _world As World = _field.GetFirstWorld
                        If Not (_world Is Nothing) Then
                            reply = """" + _world.Name.Value + """"
                        Else
                            reply = String.Empty
                        End If
                        result = ParseError.ParseOK
                    End If

                Case "nextworld"
                    Dim _field As Field = mWinSRFR.SelectedField
                    If Not (_field Is Nothing) Then
                        Dim _world As World = _field.GetNextWorld
                        If Not (_world Is Nothing) Then
                            reply = """" + _world.Name.Value + """"
                        Else
                            reply = String.Empty
                        End If
                        result = ParseError.ParseOK
                    End If

            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

    Private Function ParseWorldStringQuery(ByVal query As String, ByRef reply As String) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(mSeparators.ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "selectedanalysis"
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        reply = """" + _analysis.Name.Value + """"
                    Else
                        reply = String.Empty
                    End If
                    result = ParseError.ParseOK

                Case "firstanalysis"
                    Dim _world As World = mWinSRFR.SelectedWorld
                    If Not (_world Is Nothing) Then
                        Dim _analysis As Unit = _world.GetFirstAnalysis
                        If Not (_analysis Is Nothing) Then
                            reply = """" + _analysis.Name.Value + """"
                        Else
                            reply = String.Empty
                        End If
                        result = ParseError.ParseOK
                    End If

                Case "nextanalysis"
                    Dim _world As World = mWinSRFR.SelectedWorld
                    If Not (_world Is Nothing) Then
                        Dim _analysis As Unit = _world.GetNextAnalysis
                        If Not (_analysis Is Nothing) Then
                            reply = """" + _analysis.Name.Value + """"
                        Else
                            reply = String.Empty
                        End If
                        result = ParseError.ParseOK
                    End If

            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

    Private Function ParseAnalysisStringQuery(ByVal query As String, ByRef reply As String) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(mSeparators.ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim item As String = tokens(0).ToLower()
            Select Case item
                Case "xyz"
                    reply = String.Empty
                    result = ParseError.ParseOK

                Case Else
            End Select
        Else
            result = ParseError.NotEnoughTokens
        End If

        Return result
    End Function

#End Region

#Region " Integer Query Parsers "
        '
        ' Receive Remote Interface Query
        '
        ' NOTE - execution is running in client's thread; call must be marshalled to the
        '        main thread for WinSRFR to execute properly.
        '
    Private Sub RemoteInterface_RemoteIntegerQuery(ByVal query As String, ByRef reply As Integer, ByRef result As Integer) _
    Handles mRemoteInterface.RemoteIntegerQuery
        ' Get delegate to WinSRFR method
        Dim parseQuery As WinSRFR.ParseIntegerQueryDelegate = AddressOf mWinSRFR.ParseIntegerQuery
        ' Invoke requires array of Objects for method arguments
        Dim args As Object() = {query, reply}
        ' Marshall call to main thread
        result = mWinSRFR.Invoke(parseQuery, New Object() {args})
        ' Retrieve query reply from argument list
        reply = CInt(args(1))
    End Sub

    Public Function ParseIntegerQuery(ByVal query As String, ByRef reply As Integer) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim menu As String = tokens(0).ToLower()
            Select Case menu
                Case "file"
                Case "edit"
                Case "farm", "project"
                Case "field", "case"
                Case "world", "folder"
                Case "analysis", "simulation"
                Case WinSRFR.MyID
                    ' DataStore query aimed at the root ObjectNode
                    Dim _dataStore As DataStore.ObjectNode = mWinSRFR.MyStore
                    If Not (_dataStore Is Nothing) Then
                        result = _dataStore.ParseIntegerQuery(query, reply)
                    End If
                Case Else
                    ' DataStore query aimed at an Analysis ObjectNode
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        Dim _dataStore As DataStore.ObjectNode = _analysis.MyStore
                        If Not (_dataStore Is Nothing) Then
                            result = _dataStore.ParseIntegerQuery(query, reply)
                        End If
                    End If
            End Select
        End If

        Return result
    End Function

#End Region

#Region " Single Query Parsers "
    '
    ' Receive Remote Interface Query
    '
    ' NOTE - execution is running in client's thread; call must be marshalled to the
    '        main thread for WinSRFR to execute properly.
    '
    Private Sub RemoteInterface_RemoteSingleQuery(ByVal query As String, ByRef reply As Single, ByRef result As Integer) _
    Handles mRemoteInterface.RemoteSingleQuery
        ' Get delegate to WinSRFR method
        Dim parseQuery As WinSRFR.ParseSingleQueryDelegate = AddressOf mWinSRFR.ParseSingleQuery
        ' Invoke requires array of Objects for method arguments
        Dim args As Object() = {query, reply}
        ' Marshall call to main thread
        result = mWinSRFR.Invoke(parseQuery, New Object() {args})
        ' Retrieve query reply from argument list
        reply = CSng(args(1))
    End Sub

    Public Function ParseSingleQuery(ByVal query As String, ByRef reply As Single) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim menu As String = tokens(0).ToLower()
            Select Case menu
                Case "file"
                Case "edit"
                Case "farm", "project"
                Case "field", "case"
                Case "world", "folder"
                Case "analysis", "simulation"
                Case WinSRFR.MyID
                    ' DataStore query aimed at the root ObjectNode
                    Dim _dataStore As DataStore.ObjectNode = mWinSRFR.MyStore
                    If Not (_dataStore Is Nothing) Then
                        result = _dataStore.ParseSingleQuery(query, reply)
                    End If
                Case Else
                    ' DataStore query aimed at an Analysis ObjectNode
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        Dim _dataStore As DataStore.ObjectNode = _analysis.MyStore
                        If Not (_dataStore Is Nothing) Then
                            result = _dataStore.ParseSingleQuery(query, reply)
                        End If
                    End If
            End Select
        End If

        Return result
    End Function

#End Region

#Region " Double Query Parsers "
    '
    ' Receive Remote Interface Query
    '
    ' NOTE - execution is running in client's thread; call must be marshalled to the
    '        main thread for WinSRFR to execute properly.
    '
    Private Sub RemoteInterface_RemoteDoubleQuery(ByVal query As String, ByRef reply As Double, ByRef result As Integer) _
    Handles mRemoteInterface.RemoteDoubleQuery
        ' Get delegate to WinSRFR method
        Dim parseQuery As WinSRFR.ParseDoubleQueryDelegate = AddressOf mWinSRFR.ParseDoubleQuery
        ' Invoke requires array of Objects for method arguments
        Dim args As Object() = {query, reply}
        ' Marshall call to main thread
        result = mWinSRFR.Invoke(parseQuery, New Object() {args})
        ' Retrieve query reply from argument list
        reply = CDbl(args(1))
    End Sub

    Public Function ParseDoubleQuery(ByVal query As String, ByRef reply As Double) As ParseError
        query = query.Trim()

        Dim result As ParseError = ParseError.ParseFailed
        Dim tokens() As String = query.Split(" .".ToCharArray, 2)

        If (0 < tokens.Length) Then
            Dim menu As String = tokens(0).ToLower()
            Select Case menu
                Case "file"
                Case "edit"
                Case "farm", "project"
                Case "field", "case"
                Case "world", "folder"
                Case "analysis", "simulation"
                Case WinSRFR.MyID
                    ' DataStore query aimed at the root ObjectNode
                    Dim _dataStore As DataStore.ObjectNode = mWinSRFR.MyStore
                    If Not (_dataStore Is Nothing) Then
                        result = _dataStore.ParseDoubleQuery(query, reply)
                    End If
                Case Else
                    ' DataStore query aimed at an Analysis ObjectNode
                    Dim _analysis As Unit = mWinSRFR.SelectedAnalysis
                    If Not (_analysis Is Nothing) Then
                        Dim _dataStore As DataStore.ObjectNode = _analysis.MyStore
                        If Not (_dataStore Is Nothing) Then
                            result = _dataStore.ParseDoubleQuery(query, reply)
                        End If
                    End If
            End Select
        End If

        Return result
    End Function

#End Region

#End Region

End Class
