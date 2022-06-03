
'*************************************************************************************************************
' ctl_SensitivityAnalysisUnstructured UserControl (Same UI and code as RunMultiSimulations Dialog Box
'*************************************************************************************************************
Imports System.IO

Imports Srfr
Imports Srfr.SrfrAPI

Imports DataStore

Public Class ctl_SensitivityAnalysisUnstructured

#Region " Member Data "

    Private mInputFile As String
    Private mOuputFile As String

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Properties "

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Public Property WinSRFR() As WinSRFR
        Get
            Return mWinSRFR
        End Get
        Set(ByVal value As WinSRFR)
            mWinSRFR = value
        End Set
    End Property

    Private mSimulationWorld As SimulationWorld
    Public Property SimulationWorld() As SimulationWorld
        Get
            Return mSimulationWorld
        End Get
        Set(ByVal value As SimulationWorld)
            mSimulationWorld = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub UpdateUI()

        Me.Text = mDictionary.ControlText(Me)

        ' Run button is enabled after both input & output files are specified
        If ((Me.InputFilename.Text.Trim = String.Empty) _
         Or (Me.OutputFilename.Text.Trim = String.Empty)) Then
            Me.RunMultiButton.Enabled = False
        Else
            Me.RunMultiButton.Enabled = True
        End If

    End Sub

    Private Sub ExportDataTable(ByVal table As DataTable, ByVal filepath As String)

        Dim output As StreamWriter = Nothing
        Dim msg As String
        Dim title As String = mDictionary.tErrOpeningWritingFile.Translated

        Try
            ConvertDataTableToDisplayUnits(table)

            output = New StreamWriter(filepath)

            If (output IsNot Nothing) Then
                ExportToFile(table, output)
            End If

        Catch ex As Exception
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

    Private Sub ImportDataTable(ByVal table As DataTable, ByVal filepath As String)

        Dim input As StreamReader = Nothing
        Dim msg As String
        Dim title As String = mDictionary.tErrOpeningReadingFile.Translated

        Try
            input = New StreamReader(filepath)

            If (input IsNot Nothing) Then
                ImportFromFile(table, input)
            End If

            ConvertDataTableToSiUnits(table)

        Catch ex As Exception
            msg = mDictionary.tFile.Translated & ": " & filepath & Chr(13) & Chr(13)
            msg += ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)

        Finally
            If (input IsNot Nothing) Then
                input.Close()
                input = Nothing
            End If
        End Try
    End Sub

#End Region

#Region " UI Event Handlers "
    '
    ' Browse for the Input File
    '
    Private Sub BrowseInputFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BrowseInputFileButton.Click

        Dim openDiag As New OpenFileDialog

        openDiag.FileName = ""
        openDiag.DefaultExt = "*.csv"
        openDiag.Filter = "Input File (*.csv;*.txt)|*.csv;*.txt"

        Dim result As DialogResult = openDiag.ShowDialog()

        If (result = DialogResult.OK) Then
            mInputFile = openDiag.FileName
            Me.InputFilename.Text = mInputFile
        End If

    End Sub
    '
    ' Browse for the Output File
    '
    Private Sub BrowseOutputFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BrowseOutputFileButton.Click

        Dim openDiag As New OpenFileDialog

        openDiag.FileName = ""
        openDiag.DefaultExt = "*.csv"
        openDiag.Filter = "Output File (*.csv;*.txt)|*.csv;*.txt"

        Dim result As DialogResult = openDiag.ShowDialog()

        If (result = DialogResult.OK) Then
            mOuputFile = openDiag.FileName
            Me.OutputFilename.Text = mOuputFile
        End If

    End Sub
    '
    ' Run multiple simulations as specified by the Input File
    '
    Private Sub RunMultiButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunMultiButton.Click

        ' Input File table is tab or comma separated
        Dim separator As Char = vbTab                           ' Default to Tab separator
        Dim separators() As Char = {vbTab, ","}

        Dim inputFile As String = Me.InputFilename.Text.Trim
        Dim outputFile As String = Me.OutputFilename.Text.Trim

        Dim inputFolder As String = String.Empty
        Dim lastBackslash As Integer = inputFile.LastIndexOf("\")
        If (0 <= lastBackslash) Then
            inputFolder = inputFile.Substring(0, lastBackslash)
        End If

        Dim tablesFolder As String = WinSRFR.UserPreferences.DefaultDataFolder & "\"
        If Not (inputFolder = String.Empty) Then
            tablesFolder = inputFolder & "\"
        End If

        Dim outputFolder As String = String.Empty
        lastBackslash = outputFile.LastIndexOf("\")
        If (0 <= lastBackslash) Then
            outputFolder = outputFile.Substring(0, lastBackslash)
        End If

        Dim resultsFolder As String = WinSRFR.UserPreferences.DefaultDataFolder & "\"
        If Not (outputFolder = String.Empty) Then
            resultsFolder = outputFolder & "\"
        End If

        Dim inStream As StreamReader = Nothing
        Dim outStream As StreamWriter = Nothing

        Dim line As String = Nothing
        Dim results() As String = Nothing

        Dim unitsOutput As Boolean = False

        Try
            If (inputFile = outputFile) Then
                Dim msg As String = inputFile & Chr(10) & Chr(10) & mDictionary.tErrCannotUseSameFileForInputOutput.Translated
                MsgBox(msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, mDictionary.tErrReadingFiles.Translated)
                Return
            End If

            If (mSimulationWorld IsNot Nothing) Then
                mSimulationWorld.DisplayResults = False         ' Don't display results during multi-run
                '
                ' Open & verify output file
                '
                inStream = New StreamReader(outputFile)

                If (inStream.EndOfStream) Then
                    Dim msg As String = outputFile & Chr(10) & Chr(10) & mDictionary.tErrFileIsEmpty.Translated
                    MsgBox(msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, mDictionary.tErrReadingFiles.Translated)
                    inStream.Close()
                    Return
                End If

                line = inStream.ReadLine.Trim

                If (line IsNot Nothing) Then
                    If (line.Contains(",")) Then
                        separator = ","                         ' Separator is actually comma
                    End If

                    results = line.Split(separators)

                    If (results.Length = 0) Then
                        Dim msg As String = outputFile & Chr(10) & Chr(10) & mDictionary.tErrFirstLineIsBlank.Translated
                        MsgBox(msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, mDictionary.tErrReadingFiles.Translated)
                        inStream.Close()
                        Return
                    End If
                Else
                    Dim msg As String = outputFile & Chr(10) & Chr(10) & mDictionary.tErrFileIsEmpty.Translated
                    MsgBox(msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, mDictionary.tErrReadingFiles.Translated)
                    inStream.Close()
                    Return
                End If

                inStream.Close()
                '
                ' Open output file for results
                '
                If (Me.ClearResultsFile.Checked) Then
                    outStream = New StreamWriter(outputFile)
                    outStream.WriteLine(line)
                Else
                    outStream = File.AppendText(outputFile)
                    unitsOutput = True
                End If
                '
                ' Open & read input file
                '
                inStream = New StreamReader(inputFile)

                If (inStream.EndOfStream) Then
                    Dim msg As String = inputFile & Chr(10) & Chr(10) & mDictionary.tErrFileIsEmpty.Translated
                    MsgBox(msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, mDictionary.tErrReadingFiles.Translated)
                    inStream.Close()
                    Return
                End If

                ' Read until first non-empty/comment line
                While Not (inStream.EndOfStream)
                    line = inStream.ReadLine.Trim
                    If Not (line = String.Empty) Then ' not empty
                        If Not (line(0) = "'") Then ' not comment
                            Exit While
                        End If
                    End If
                    line = Nothing
                End While

                If (line IsNot Nothing) Then
                    '
                    ' Parse Parameter names and perhaps units from first line
                    '
                    Dim params() As String = line.Split(separators)                 ' List of Parameter names
                    Dim units(params.Length - 1) As String                          ' Corresponding units (if parametric data)
                    Dim files(params.Length - 1) As String                          ' Corresponding filenames (if tabulated data)

                    For pdx As Integer = 0 To params.Length - 1
                        Dim param As String = params(pdx).Trim

                        ' Check for units at end of parameter name
                        Dim open As Integer = -1
                        Dim close As Integer = -1
                        Dim unit As String = String.Empty

                        ' Units can be enclosed within (), {}, []
                        If (param.Contains("(")) Then
                            open = param.IndexOf("(")
                            close = param.IndexOf(")")
                        ElseIf (param.Contains("{")) Then
                            open = param.IndexOf("{")
                            close = param.IndexOf("}")
                        ElseIf (param.Contains("[")) Then
                            open = param.IndexOf("[")
                            close = param.IndexOf("]")
                        End If

                        ' If matching brackets were found, extract unit string
                        If ((-1 < open) And (-1 < close)) Then
                            unit = param.Substring(open + 1, close - open - 1).Trim
                            param = param.Substring(0, open).Trim
                        End If

                        params(pdx) = param
                        units(pdx) = unit
                    Next pdx
                    '
                    ' Check if units are specified on second line
                    '
                    line = inStream.ReadLine.Trim

                    If (line IsNot Nothing) Then
                        Dim temp() As String = line.Split(separators)
                        Dim unitsFound As Boolean = False

                        If (temp.Length = units.Length) Then
                            For tdx As Integer = 0 To temp.Length - 1

                                Dim dsUnits As DataStore.Units = DataStore.UnitsFromString(temp(tdx))

                                If Not ((dsUnits = DataStore.Units.None) Or (dsUnits = DataStore.Units.Text)) Then ' 2nd line has Units
                                    units(tdx) = temp(tdx)
                                    unitsFound = True
                                End If

                            Next
                        End If

                        If (unitsFound) Then
                            line = inStream.ReadLine.Trim
                        End If
                    End If
                    '
                    ' Remaining Input File lines specify a set of values for a Simulation Run
                    '
                    Dim simUnit As Unit = mSimulationWorld.DisplayedUnit
                    Dim simStore As DataStore.ObjectNode = simUnit.MyStore
                    Dim command As String
                    Dim parseErr As ParseError
                    Dim runCount As Integer = 0
                    Dim continueRuns As Boolean = True
                    Dim userPrompted As Boolean = False

                    Dim errorViewer As TextViewer = New TextViewer
                    errorViewer.Text = mDictionary.tErrors.Translated & " & " & mDictionary.tWarnings.Translated
                    errorViewer.ErrorRichTextBox.Clear()

                    While ((continueRuns) And (line IsNot Nothing)) ' line = Nothing at EOS

                        If (line = String.Empty) Then ' line is blank; skip it

                        ElseIf (line(0) = "'") Then ' line is a comment; skip it

                        ElseIf (line(0) = ">") Then ' line is a command; execute it

                            command = line.Substring(1)
                            parseErr = simStore.ParseCommand(command)
                            If Not (parseErr = ParseError.ParseOK) Then ' command not found thru normal hierarchy
                                parseErr = simStore.ParseCommand(command, True) ' try drilling down
                            End If

                        Else ' line is values for Simulation; parse them

                            Dim values() As String = line.Split(separators)

                            ' Set the input parameter values
                            For pdx As Integer = 0 To params.Length - 1
                                ' Get next input parameter & its DataStore Parameter
                                Dim param As String = params(pdx).Trim
                                Dim path As String = simStore.FindPropertyPath(param)
                                Dim dsParam As Parameter = simStore.GetParameter(path)
                                If (dsParam Is Nothing) Then ' not found; assign it something not checked for
                                    dsParam = New BooleanParameter
                                End If

                                ' Check for filename for tabulated Results
                                If ((param = sAdvance) _
                                 Or (param = sRecession) _
                                 Or (param = sInfiltration) _
                                 Or (param.StartsWith(sHydrograph)) _
                                 Or (param.StartsWith(sProfile))) Then ' Parameter is tabulated Results

                                    ' Save filename for use after Simulation has been run
                                    If (values(pdx) IsNot Nothing) Then
                                        If Not (values(pdx) = String.Empty) Then
                                            files(pdx) = values(pdx)
                                        End If
                                    End If

                                ElseIf (dsParam.GetType Is GetType(DataSetParameter)) Then ' importing DataSet

                                    ' Immediately import tabulated Inputs
                                    Dim filename As String = values(pdx)
                                    If (filename IsNot Nothing) Then
                                        If Not (filename = String.Empty) Then

                                            Dim filepath As String = filename
                                            If Not (filepath.Contains("\")) Then ' filename only; add default path
                                                filepath = tablesFolder & filename
                                            End If

                                            Dim setParam As DataSetParameter = DirectCast(dsParam, DataSetParameter)
                                            Dim table As DataTable = setParam.Value.Tables(0)
                                            Dim tableName As String = table.TableName
                                            table.TableName = param
                                            ImportDataTable(table, filepath)
                                            table.TableName = tableName

                                        End If
                                    End If

                                ElseIf (dsParam.GetType Is GetType(DataTableParameter)) Then ' importing DataTable

                                    ' Immediately import tabulated Inputs
                                    Dim filename As String = values(pdx)
                                    If (filename IsNot Nothing) Then
                                        If Not (filename = String.Empty) Then

                                            Dim filepath As String = filename ' filename only; add default path
                                            If Not (filepath.Contains("\")) Then
                                                filepath = tablesFolder & filename
                                            End If

                                            Dim tableParam As DataTableParameter = DirectCast(dsParam, DataTableParameter)
                                            Dim table As DataTable = tableParam.Value

                                            ImportDataTable(table, filepath)

                                        End If
                                    End If

                                Else ' Parameter is parametric data

                                    ' Compress spaces from parameter name
                                    param = param.Replace(" ", "")

                                    ' Get associated value, if specified
                                    Dim value As String = "0"
                                    If (pdx < values.Length) Then
                                        value = values(pdx)
                                    End If

                                    ' Get associated value units, if specified
                                    Dim unit As String = String.Empty
                                    If (pdx < units.Length) Then
                                        unit = units(pdx)
                                    End If

                                    ' Overwrite column units with value units, if specified
                                    Dim tokens() As String = value.Split(" ")
                                    If (2 = tokens.Length) Then
                                        value = tokens(0)
                                        unit = tokens(1)
                                    End If

                                    ' Build command from parameter name, value & units
                                    command = param & " " & value
                                    If Not (unit = String.Empty) Then
                                        command &= " " & unit
                                    End If

                                    ' Send command to Simulation's DataStore for processing
                                    parseErr = simStore.ParseCommand(command)
                                    If Not (parseErr = ParseError.ParseOK) Then ' command not found thru normal hierarchy
                                        parseErr = simStore.ParseCommand(command, True) ' try drilling down
                                    End If
                                End If
                            Next pdx
                            '
                            ' Run the simulation
                            '
                            Dim srfrSim As SrfrSimulation = mSimulationWorld.CurrentAnalysis
                            srfrSim.EnableTimeLimitEvents = True
                            srfrSim.EnableTimestepLimitEvents = True

                            runCount += 1
                            Dim analysisWasRun As Boolean = mWinSRFR.RunAnalysis(srfrSim, errorViewer.ErrorRichTextBox, runCount)

                            If (analysisWasRun) Then

                                Dim errCode As Srfr.SrfrAPI.SrfrErrorCodes = SrfrErrorCode
                                If (errCode = Srfr.SrfrAPI.SrfrErrorCodes.NoError) Then ' Simulation OK
                                    '
                                    ' Save the parametric results
                                    '
                                    Dim outLine As String = String.Empty
                                    Dim unitsLine As String = String.Empty

                                    For Each result As String In results
                                        Dim path As String = simStore.FindPropertyPath(result, True)
                                        Dim param As Parameter = simStore.GetParameter(path)
                                        If (param IsNot Nothing) Then
                                            If Not (unitsOutput) Then
                                                Dim paramUnits As String = param.UnitsString

                                                If (unitsLine = String.Empty) Then
                                                    unitsLine = paramUnits
                                                Else
                                                    unitsLine &= separator & paramUnits
                                                End If
                                            End If

                                            Dim paramVal As String = param.ValueString("+1")
                                            Dim enumVal As String = param.EnumString()
                                            If (enumVal IsNot Nothing) Then
                                                If Not (enumVal = String.Empty) Then
                                                    paramVal = enumVal
                                                End If
                                            End If

                                            If (outLine = String.Empty) Then
                                                outLine = paramVal
                                            Else
                                                outLine &= separator & paramVal
                                            End If
                                        Else
                                            outLine &= separator
                                        End If
                                    Next result

                                    If Not (unitsOutput) Then ' Units line needs to be added to Results
                                        outStream.WriteLine(unitsLine)
                                        unitsOutput = True
                                    End If

                                    If Not (outLine = String.Empty) Then
                                        outStream.WriteLine(outLine)
                                    End If
                                    '
                                    ' Save the tabulated results
                                    '
                                    Dim irrigation As Irrigation = mSimulationWorld.SrfrAPI.Irrigation
                                    Dim output As StreamWriter = Nothing

                                    For pdx As Integer = 0 To params.Length - 1
                                        ' Get next parameter name
                                        Dim param As String = params(pdx).Trim
                                        Dim unitsText As String = units(pdx)
                                        Dim filename As String = files(pdx)
                                        Dim filepath As String = resultsFolder & filename & " " & runCount.ToString & ".txt"

                                        If (param = sAdvance) Then

                                            Dim advTable As DataTable = irrigation.AdvanceCurve
                                            ExportDataTable(advTable, filepath)

                                        ElseIf (param = sRecession) Then

                                            Dim recTable As DataTable = irrigation.RecessionCurve
                                            ExportDataTable(recTable, filepath)

                                        ElseIf (param = sInfiltration) Then

                                            Dim infTable As DataTable = irrigation.InfiltrationCurve
                                            ExportDataTable(infTable, filepath)

                                        ElseIf (param.StartsWith(sHydrograph)) Then

                                            Dim fields() As String = param.Split(" ")
                                            Dim unitsType As DataStore.UnitsDefinition.Units

                                            If (2 < fields.Length) Then
                                                Dim propName As String = fields(1)
                                                Dim distString As String = fields(2) & unitsText
                                                Dim distDouble As Double

                                                If (ParseValueWithUnits(distString, distDouble, unitsType)) Then
                                                    Dim hydroTable As DataTable = irrigation.Hydrographs(propName, distDouble)
                                                    ExportDataTable(hydroTable, filepath)
                                                End If
                                            End If

                                        ElseIf (param.StartsWith(sProfile)) Then

                                            Dim fields() As String = param.Split(" ")
                                            Dim unitsType As DataStore.UnitsDefinition.Units

                                            If (2 < fields.Length) Then
                                                Dim propName As String = fields(1)
                                                Dim timeString As String = fields(2) & unitsText
                                                Dim timeDouble As Double

                                                If (ParseValueWithUnits(timeString, timeDouble, unitsType)) Then
                                                    Dim profileTable As DataTable = irrigation.Profiles(propName, timeDouble)
                                                    ExportDataTable(profileTable, filepath)
                                                End If
                                            End If
                                        End If
                                    Next pdx

                                Else ' Simulation error occurred

                                    Dim errMsg As String = SrfrErrorMsg
                                    Dim outLine As String = errCode.ToString & "; " & errMsg
                                    outStream.WriteLine(outLine)

                                    If ((Me.ShowMessageOnError.Checked) And Not (userPrompted)) Then
                                        userPrompted = True

                                        Dim msg As String = "An error occured during a Simulation run:" & Chr(10) & Chr(10)
                                        msg &= errMsg & Chr(10) & Chr(10)
                                        msg &= "Do you want to continue executing the remaining Simulations?"

                                        Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Simulation Error")

                                        If (result = MsgBoxResult.No) Then
                                            continueRuns = False
                                        End If
                                    End If
                                End If
                            End If ' (analysisWasRun)

                        End If ' file line is valid

                        If (inStream.EndOfStream) Then ' EOS; nothing more to read
                            line = Nothing
                        Else
                            line = inStream.ReadLine.Trim
                        End If
                    End While ' ((continueRuns) And (line IsNot Nothing))

                    If Not (errorViewer.ErrorRichTextBox.Text = "") Then
                        errorViewer.ShowDialog()
                    End If

                Else
                    Dim msg As String = inputFile & Chr(10) & Chr(10) & mDictionary.tErrFileIsEmpty.Translated
                    MsgBox(msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, mDictionary.tErrReadingFiles.Translated)
                End If

                mSimulationWorld.DisplayResults = True          ' Display results again
                mSimulationWorld.UpdateResultsControls()
            End If

        Catch ex As Exception
            Dim msg As String = ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Unhandled Exception during Run")
        Finally
            '
            ' Close input & output Streams
            '
            If (inStream IsNot Nothing) Then
                inStream.Close()
            End If

            If (outStream IsNot Nothing) Then
                outStream.Close()
            End If
        End Try
    End Sub

    Private Sub InputFilename_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles InputFilename.TextChanged
        UpdateUI()
    End Sub

    Private Sub OutputFilename_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OutputFilename.TextChanged
        UpdateUI()
    End Sub

    Private Sub RunMultiSimulations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        UpdateUI()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:ScriptsDialog", 0)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CloseButton.Click
        Me.Hide()
    End Sub

#End Region

End Class
