
'*************************************************************************************************************
' Class RatingComparisonControl - UserControl for displaying & editing the measured data rating comparison
'
' Note - this control operates in two modes dependant on the value of DialogMode:
'       1) DialogMode - user changes are limited to the control and may be applied to the Flume.dll by the
'                       calling method if the user closes the Dialog via the 'Ok' button.
'       2) Application Mode - user changes are applied immediately to the Flume.dll
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog                ' Unit conversion support
Imports WinFlume.MeasuredDataEntryControl   ' Rating Table column selections

Public Class RatingComparisonControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mSection As Flume.SectionType = Nothing
    '
    ' Data Panel's table or graph
    '
    Private mTable As ctl_DataGridView = Nothing
    Public Function RatingComparisonGridView() As ctl_DataGridView
        Return mTable
    End Function

    Private mGraph As RatingComparisonGraph = Nothing

#End Region

#Region " Properties "

    Public Property DialogMode As Boolean

#End Region

#Region " Constructor(s) "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DialogMode = False

        mTable = New ctl_DataGridView(Me.Font) With {
            .ReadOnly = True,
            .AllowUserToDeleteRows = False,
            .AllowUserToAddRows = False,
            .AllowUserToOrderColumns = False,
            .AllowUserToResizeColumns = False,
            .AllowUserToResizeRows = False,
            .ColumnHeadersHeight = 60,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader,
            .AccessibleName = My.Resources.RatingComparisonTable,
            .AccessibleDescription = My.Resources.CopyableTableOfData
        }

        mGraph = New RatingComparisonGraph With {
            .Dock = DockStyle.Fill,
            .AccessibleName = My.Resources.RatingComparisonGraph,
            .AccessibleDescription = My.Resources.CopyableBitmap
        }
        mGraph.ToolTip.Active = False

    End Sub

    Public Sub New(ByVal FlumeForm As WinFlumeForm, ByVal DialogMode As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mWinFlumeForm = FlumeForm
        mFlume = WinFlumeForm.Flume
        Me.DialogMode = DialogMode

        mTable = New ctl_DataGridView(Me.Font) With {
            .ReadOnly = True,
            .AllowUserToDeleteRows = False,
            .AllowUserToAddRows = False,
            .AllowUserToOrderColumns = False,
            .AllowUserToResizeColumns = False,
            .AllowUserToResizeRows = False,
            .ColumnHeadersHeight = 60,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader,
            .AccessibleName = My.Resources.RatingComparisonTable,
            .AccessibleDescription = My.Resources.CopyableTableOfData
        }

        mGraph = New RatingComparisonGraph With {
            .Dock = DockStyle.Fill,
            .AccessibleName = My.Resources.RatingComparisonGraph,
            .AccessibleDescription = My.Resources.CopyableBitmap
        }
        mGraph.ToolTip.Active = False

    End Sub

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Rating Table Choices
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume

        ' Don't update UI until initialization is complete and control is visible
        If ((mFlume Is Nothing) Or (mWinFlumeForm Is Nothing) Or (Not (Me.Visible))) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Return
        End If
        mUpdatingUI = True
        '
        ' Update data to display
        '
        Dim MeasuredTableResults(1) As RatingResultsType
        Dim MeasuredTableErrors(MaxHydErrors) As Boolean

        Dim MeasuredDataTable As MeasuredDataType() = mFlume.MeasuredData
        If (MeasuredDataTable Is Nothing) Then ' no Flume measured data
            Return
        End If
        Dim measCount As Integer = MeasuredDataTable.Length

        Dim h1Array(measCount) As Single
        ReDim MeasuredTableResults(measCount)

        Try
            ' Flume.MakeHtoQ() indexing starts at 1
            For idx As Integer = 1 To measCount
                h1Array(idx) = MeasuredDataTable(idx - 1).Head
                MeasuredTableResults(idx) = New RatingResultsType
            Next

            mFlume.MakeHtoQ(h1Array, MeasuredTableResults, MeasuredTableErrors)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
        '
        ' Update display
        '
        Try
            If (Me.ShowTableButton.Checked) Then

                If Not (Me.DataPanel.Controls.Contains(mTable)) Then
                    Me.DataPanel.Controls.Clear()
                    Me.DataPanel.Controls.Add(mTable)
                End If

                UpdateRatingComparisonTable(MeasuredTableResults, MeasuredDataTable)

            Else ' Assume Me.ShowGraphButton.Checked

                If Not (Me.DataPanel.Controls.Contains(mGraph)) Then
                    Me.DataPanel.Controls.Clear()
                    Me.DataPanel.Controls.Add(mGraph)
                End If

                Me.UpdateRatingComparisonGraph(MeasuredTableResults, MeasuredDataTable)
            End If

            Dim loc As Point = Me.ViewAsDialogButton.Location
            loc.X = Me.Width - Me.ViewAsDialogButton.Width - 8
            Me.ViewAsDialogButton.Location = loc

            ' Update status
            Me.StatusPanel.Title.Text = My.Resources.AllWarningMessagesForThisTable
            Me.StatusPanel.StatusBox.Clear()

            Dim edx As Integer = 0
            Dim errText As String = ""
            For Each errBool In MeasuredTableErrors
                If (errBool) Then
                    If (edx < 10) Then
                        errText &= " "
                    End If
                    errText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
                End If
                edx += 1
            Next errBool

            Me.StatusPanel.StatusBox.Text = errText

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        mUpdatingUI = False
    End Sub

#End Region

#Region " Update Rating Comparison Table "

    '*********************************************************************************************************
    ' Sub UpdateRatingComparisonTable - update comparison graph
    '
    ' Input(s):     RatingResults       - array of Flume calcuated rating results
    '               MeasuredDataTable   - array of user input HQ measurements
    '*********************************************************************************************************
    Public Sub UpdateRatingComparisonTable(ByVal RatingResults() As RatingResultsType,
                                           ByVal MeasuredDataTable() As MeasuredDataType)
        ' RatingResults(0) is Nothing
        Debug.Assert(RatingResults.Length = MeasuredDataTable.Length + 1)

        Dim cdx, edx, mdx, tdx As Integer

        Dim choicesControl As MeasuredDataEntryControl = mWinFlumeForm.GetMeasuredDataEntryControl
        Dim tblChoice As TableChoice
        Dim tblChoices As List(Of TableChoice) = choicesControl.TableChoices()
        Dim numChoices As Integer = choicesControl.NumberOfTableChoices() + 3
        '
        ' Update Rating Table column headers
        '
        With mTable
            .Rows.Clear()
            .Columns.Clear()
            .ColumnCount = numChoices

            tblChoice = tblChoices(0)                       ' Head at Gage
            .Columns(0).HeaderText = TableColumnName(tblChoice)

            'tblChoice = tblChoices(1)                       ' Discharge
            '.Columns(1).Name = TableColumnName(tblChoice)

            ' Substitute four columns for Discharge
            tblChoice = New TableChoice(RatingResultsEnum.Q, My.Resources.MeasuredDischarge, "Q", "m³/s", True)
            .Columns(1).HeaderText = TableColumnName(tblChoice)
            tblChoice = New TableChoice(RatingResultsEnum.Q, My.Resources.TheoreticalDischarge, "Q", "m³/s", True)
            .Columns(2).HeaderText = TableColumnName(tblChoice)
            tblChoice = New TableChoice(RatingResultsEnum.Q, My.Resources.DischargeDifference, "dQ", "m³/s", True)
            .Columns(3).HeaderText = TableColumnName(tblChoice)
            tblChoice = New TableChoice(RatingResultsEnum.Q, My.Resources.DischargeDifference, "dQ", "%", True)
            .Columns(4).HeaderText = TableColumnName(tblChoice)

            cdx = 5
            For tdx = 2 To tblChoices.Count - 1
                tblChoice = tblChoices(tdx)
                If (tblChoice.Selected) Then
                    .Columns(cdx).HeaderText = TableColumnName(tblChoice)
                    cdx += 1
                End If
            Next tdx

            .Columns(0).DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight
            .Columns(0).Frozen = True

            For cdx = 0 To numChoices - 1
                .Columns(cdx).Width += 30
            Next cdx

        End With
        '
        ' Update Rating Table data
        '
        mdx = 0
        For Each RatingResult As RatingResultsType In RatingResults
            If (RatingResult IsNot Nothing) Then

                Dim rowString(numChoices) As String
                Dim formatStyle As String = "0.000"

                cdx = 0
                For tdx = 0 To tblChoices.Count - 1
                    tblChoice = tblChoices(tdx)
                    If (tblChoice.Selected) Then
                        Dim uiValue As Single = 0
                        Dim siValue As Single = Single.NaN
                        Dim siUnits As String = ""
                        Dim siString As String = ""

                        With RatingResult

                            Select Case (tblChoice.Rating)
                                Case RatingResultsEnum.ActualTailwaterDepth
                                    siValue = .ActualTailwaterDepth
                                Case RatingResultsEnum.Cd
                                    siValue = .Cd
                                Case RatingResultsEnum.Cv
                                    siValue = .Cv
                                Case RatingResultsEnum.Errors
                                    edx = 0
                                    For Each errbool As Boolean In .Errors
                                        If (errbool) Then
                                            If (siString = "") Then
                                                siString = edx.ToString
                                            Else
                                                siString &= ", " & edx.ToString
                                            End If
                                        End If
                                        edx += 1
                                    Next errbool
                                Case RatingResultsEnum.FatalError
                                    siString = .FatalError.ToString
                                Case RatingResultsEnum.Froude
                                    siValue = .Froude
                                Case RatingResultsEnum.H1
                                    siValue = .H1
                                Case RatingResultsEnum.HLRatio
                                    siValue = .HLRatio
                                Case RatingResultsEnum.MaxTailwater
                                    siValue = .MaxTailwater
                                Case RatingResultsEnum.ModularLimit
                                    siValue = .ModularLimit
                                Case RatingResultsEnum.NonFatalError
                                    siString = .NonFatalError.ToString
                                Case RatingResultsEnum.Q
                                    'siValue = .Q
                                    Dim measQ As Single = MeasuredDataTable(mdx).Flow
                                    uiValue = UiDischargeValue(measQ, UiDischargeUnits)
                                    rowString(cdx) = Format(uiValue, formatStyle)
                                    cdx += 1
                                    mdx += 1

                                    Dim theoQ As Single = .Q
                                    uiValue = UiDischargeValue(theoQ, UiDischargeUnits)
                                    rowString(cdx) = Format(uiValue, formatStyle)
                                    cdx += 1

                                    Dim diffQ As Single = measQ - theoQ
                                    uiValue = UiDischargeValue(diffQ, UiDischargeUnits)
                                    rowString(cdx) = Format(uiValue, formatStyle)
                                    cdx += 1

                                    Dim prctQ As Single = diffQ / theoQ
                                    siValue = prctQ * 100
                                    tblChoice.SiUnits = "%"

                                Case RatingResultsEnum.ReqEnergyLoss
                                    siValue = .ReqEnergyLoss
                                Case RatingResultsEnum.SMALLh1
                                    siValue = .SMALLh1
                                Case RatingResultsEnum.smallh2
                                    siValue = .smallh2
                                Case RatingResultsEnum.Submergence
                                    siValue = .Submergence
                                Case RatingResultsEnum.V1
                                    siValue = .V1
                                Case RatingResultsEnum.y1
                                    siValue = .y1
                                Case Else
                                    Debug.Assert(False)
                            End Select
                        End With

                        If (Single.IsNaN(siValue)) Then
                            rowString(cdx) = siString
                        Else
                            siUnits = tblChoice.SiUnits

                            If (UnitsDialog.LengthUnitsAbbreviations.Contains(siUnits)) Then
                                uiValue = UiLengthValue(siValue, UiLengthUnits)
                                'formatStyle = UnitsDialog.UiLengthFormatStyle()
                            ElseIf (UnitsDialog.SlopeUnitsAbbreviations.Contains(siUnits)) Then
                                uiValue = UiSlopeValue(siValue, UiSlopeUnits)
                                'formatStyle = UnitsDialog.UiSlopeFormatStyle()
                            ElseIf (UnitsDialog.VelocityUnitsAbbreviations.Contains(siUnits)) Then
                                uiValue = UiVelocityValue(siValue, UiVelocityUnits)
                                'formatStyle = UnitsDialog.UiVelocityFormatStyle()
                            ElseIf (UnitsDialog.DischargeUnitsAbbreviations.Contains(siUnits)) Then
                                uiValue = UiDischargeValue(siValue, UiDischargeUnits)
                                'formatStyle = UnitsDialog.UiDischargeFormatStyle()
                            Else
                                uiValue = siValue
                            End If

                            rowString(cdx) = Format(uiValue, formatStyle)

                        End If

                        cdx += 1
                    End If ' (tblChoice.Selected)
                Next tdx

                mTable.Rows.Add(rowString)
            End If

        Next RatingResult

    End Sub
    '
    ' Generate 3-line column name for specified TableChoice entry
    '
    Public Shared Function TableColumnName(ByVal TblChoice As TableChoice) As String
        TableColumnName = TblChoice.Name
        '
        ' First 2 lines are name of specified Table Choice
        '
        Dim tokens As String() = TableColumnName.Split(" ".ToCharArray)
        If (tokens.Count < 2) Then ' only 1 word in name; add newlines
            TableColumnName &= Chr(13) & Chr(13)
        ElseIf (tokens.Count = 2) Then ' 2 words in name; 1 per line
            TableColumnName = tokens(0) & Chr(13) & tokens(1) & Chr(13)
        Else ' 3 or more words; distribute between 2 lines
            Dim nameLength As Integer = TableColumnName.Length
            TableColumnName = ""
            Dim tdx As Integer = 0
            While (TableColumnName.Length + tokens(tdx).Length <= nameLength / 2)
                If (tdx < tokens.Count - 1) Then
                    TableColumnName &= tokens(tdx) & " "
                    tdx += 1
                Else
                    Exit While
                End If
            End While
            TableColumnName &= Chr(13)
            While (tdx < tokens.Count - 1)
                TableColumnName &= tokens(tdx) & " "
                tdx += 1
            End While
            TableColumnName &= tokens(tdx) & Chr(13)
        End If
        '
        ' 3rd line is Symbol & Units
        '
        If Not (TblChoice.Symbol = "") Then
            TableColumnName &= TblChoice.Symbol
        End If

        Dim siUnits As String = TblChoice.SiUnits
        If Not (siUnits = "") Then
            If (UnitsDialog.LengthUnitsAbbreviations.Contains(siUnits)) Then
                TableColumnName &= " (" & UiLengthUnitsText() & ")"
            ElseIf (UnitsDialog.SlopeUnitsAbbreviations.Contains(siUnits)) Then
                TableColumnName &= " (" & UiSlopeUnitsText() & ")"
            ElseIf (UnitsDialog.VelocityUnitsAbbreviations.Contains(siUnits)) Then
                TableColumnName &= " (" & UiVelocityUnitsText() & ")"
            ElseIf (UnitsDialog.DischargeUnitsAbbreviations.Contains(siUnits)) Then
                TableColumnName &= " (" & UiDischargeUnitsText() & ")"
            Else
                TableColumnName &= " (" & siUnits & ")"
            End If

        End If
    End Function

#End Region

#Region " Update Rating Comparison Graph "

    '*********************************************************************************************************
    ' Sub UpdateRatingComparisonGraph - update comparison table
    '
    ' Input(s):     RatingResults       - array of Flume calcuated rating results
    '               MeasuredDataTable   - array of user input HQ measurements
    '*********************************************************************************************************
    Private Sub UpdateRatingComparisonGraph(ByVal RatingResults() As RatingResultsType,
                                            ByVal MeasuredDataTable() As MeasuredDataType)
        ' RatingResults(0) is Nothing
        Debug.Assert(RatingResults.Length = MeasuredDataTable.Length + 1)
        ' Update the Rating Graph
        mGraph.FlumeRef = mFlume
        mGraph.UpdateRatingComparisonGraph(RatingResults, MeasuredDataTable)
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' CheckedChanged event handlers for contained Controls
    '*********************************************************************************************************
    Private Sub ShowTableButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ShowTableButton.CheckedChanged
        If (Me.ShowTableButton.Checked) Then
            UpdateUI()
        End If
    End Sub

    Private Sub ShowGraphButton_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ShowGraphButton.CheckedChanged
        If (Me.ShowGraphButton.Checked) Then
            UpdateUI()
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub MyBase_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub MyBase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Sub ViewAsDialogButton_Click() - display table/graph as dialog box
    '*********************************************************************************************************
    Private Sub ViewAsDialogButton_Click(sender As Object, e As EventArgs) _
        Handles ViewAsDialogButton.Click
        mWinFlumeForm.ViewRatingComparisonTableAsDialog()
    End Sub

#End Region

End Class
