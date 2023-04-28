
'*************************************************************************************************************
' Class RatingEquationControl - UserControl for displaying the Rating Equation
'
' Note - this control operates in two modes dependant on the value of DialogMode:
'       1) DialogMode - user changes are limited to the Dialog until the user closes the Dialog via the
'                       'Ok' button. At that point, the calling method will apply the changes.
'       2) Application Mode - user changes are applied immediately.
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog            ' Unit conversion support
Imports WinFlume.TableChoicesControl    ' Rating Table column selections

Public Class RatingEquationControl

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
    Public Function RatingEquationGridView() As ctl_DataGridView
        Return mTable
    End Function

    Private mGraph As RatingEquationGraph = Nothing

#End Region

#Region " Dialog Mode "

    Private Property DialogMode As Boolean              ' Dialog / Application mode switch
    '
    ' Class to hold the local Dialog data while in DialogMode
    '
    Public Class DialogData
        Public EqK2Zero As Boolean

        Private mFlume As FlumeType = Nothing

        Public Sub New(ByVal Flume As FlumeType)
            mFlume = Flume
            If (mFlume IsNot Nothing) Then
                Me.EqK2Zero = mFlume.EqK2Zero
            End If
        End Sub

        Public Function Changed() As Boolean
            If (mFlume IsNot Nothing) Then
                Changed = True
                Do
                    If (Me.EqK2Zero <> mFlume.EqK2Zero) Then Exit Do
                    Changed = False
                Loop Until True
            Else
                Changed = False
            End If
        End Function

        Public Sub Save()
            If (mFlume IsNot Nothing) Then
                mFlume.EqK2Zero = Me.EqK2Zero
            End If
        End Sub

    End Class

    Public mDialogData As DialogData = Nothing
    Public Function GetDialogData() As DialogData
        Return mDialogData
    End Function

#End Region

#Region " Properties "

    Public Property K1() As Single
    Public Property K2() As Single
    Public Property U() As Single
    Public Property RSquared() As Double

    Public Function QParamString() As String

        Dim logInt As Integer = CInt(Math.Ceiling(Math.Log10(Math.Abs(K1))))
        Dim K1sigfigs As Integer = maxint(4 - logInt, 0)
        Dim K2sigfigs As Integer = 3
        If (K2 <> 0) Then
            logInt = CInt(Math.Ceiling(Math.Log10(Math.Abs(K2))))
            K2sigfigs = maxint(4 - logInt, 0)
        End If
        logInt = CInt(Math.Ceiling(Math.Log10(Math.Abs(U))))
        Dim Usigfigs As Integer = maxint(4 - logInt, 0)

        Dim K1fmt As String = "########0." & New String("0"c, K1sigfigs)
        Dim K2fmt As String = "########0." & New String("0"c, K2sigfigs)
        Dim Ufmt As String = "########0." & New String("0"c, Usigfigs)

        QParamString = "K1 = " & Format(K1, K1fmt)
        QParamString &= ", K2 = " & Format(K2, K2fmt)
        QParamString &= ", u = " & Format(U, Ufmt)

    End Function

    Public Function RSquaredString() As String
        RSquaredString = Format(RSquared, "0.00")
        For sigFigs As Integer = 3 To 5
            Dim fmt As String = "0." & New String("0"c, sigFigs)
            RSquaredString = Format(RSquared, fmt)
            If (RSquaredString.StartsWith("0")) Then
                Exit For
            End If
        Next sigFigs
    End Function

    Private Property EqK2Zero As Boolean
        Get
            If (Me.DialogMode) Then ' get local selection
                EqK2Zero = mDialogData.EqK2Zero
            Else ' Application mode; get Flume selection
                EqK2Zero = mFlume.EqK2Zero
            End If
        End Get
        Set(value As Boolean)
            If (Me.DialogMode) Then ' set local selection
                mDialogData.EqK2Zero = value
            Else ' Application mode; set Flume selection
                mFlume.EqK2Zero = value
            End If
        End Set
    End Property

#End Region

#Region " Constructor(s) "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DialogMode = False
        Me.HoldK2eq0CheckBox.UndoEnabled = False

        mTable = New ctl_DataGridView(Me.Font) With {
            .ReadOnly = True,
            .AllowUserToDeleteRows = False,
            .AllowUserToAddRows = False,
            .AllowUserToOrderColumns = False,
            .AllowUserToResizeColumns = False,
            .AllowUserToResizeRows = False,
            .AccessibleName = My.Resources.RatingEquation,
            .AccessibleDescription = My.Resources.CopyableTableOfData
        }

        mGraph = New RatingEquationGraph With {
            .Dock = DockStyle.Fill,
            .AccessibleName = My.Resources.RatingTableGraph,
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
        Me.HoldK2eq0CheckBox.UndoEnabled = False

        If ((mWinFlumeForm Is Nothing) Or (mFlume Is Nothing)) Then
            Return
        End If

        If (Me.DialogMode) Then
            mDialogData = New DialogData(mFlume)
        End If

        mTable = New ctl_DataGridView(Me.Font) With {
            .ReadOnly = True,
            .AllowUserToDeleteRows = False,
            .AllowUserToAddRows = False,
            .AllowUserToOrderColumns = False,
            .AllowUserToResizeColumns = False,
            .AllowUserToResizeRows = False,
            .Dock = DockStyle.Fill,
            .AccessibleName = My.Resources.RatingEquation,
            .AccessibleDescription = My.Resources.CopyableTableOfData
        }

        mGraph = New RatingEquationGraph With {
            .Dock = DockStyle.Fill,
            .AccessibleName = My.Resources.RatingEquationGraph,
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

        mFlume = WinFlumeForm.Flume                                         ' Flume data

        ' Don't update UI until initialization is complete and control is visible
        If ((mFlume Is Nothing) Or (mTable Is Nothing) Or (mGraph Is Nothing)) Then
            Return
        End If

        If Not (Me.Visible) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Debug.Assert(False)
            Return
        End If
        mUpdatingUI = True
        '
        ' Update data to display
        '
        Dim RatingResults(1) As RatingResultsType
        Dim TableErrors(MaxHydErrors) As Boolean

        Me.UpdateRatingEquationData(RatingResults, TableErrors)
        '
        ' Update display
        '
        Try
            Me.HoldK2eq0CheckBox.Value = Me.EqK2Zero

            If (Me.ShowTableButton.Checked) Then

                If Not (Me.DataPanel.Controls.Contains(mTable)) Then
                    Me.DataPanel.Controls.Clear()
                    Me.DataPanel.Controls.Add(mTable)
                End If

                UpdateRatingEquationTable(RatingResults)

            Else ' Assume Me.ShowGraphButton.Checked

                If Not (Me.DataPanel.Controls.Contains(mGraph)) Then
                    Me.DataPanel.Controls.Clear()
                    Me.DataPanel.Controls.Add(mGraph)
                End If

                Me.UpdateRatingEquationGraph(RatingResults)
            End If

            Dim loc As Point = Me.ViewAsDialogButton.Location
            loc.X = ControlPanel.Width - Me.ViewAsDialogButton.Width - 2
            Me.ViewAsDialogButton.Location = loc

            Me.StatusPanel.Title.Text = My.Resources.EquationReport & " && " & My.Resources.AllWarningMessagesForThisTable
            Me.StatusPanel.StatusBox.Clear()

            Me.StatusPanel.StatusBox.Text = StatusReport(TableErrors)

        Catch ex As Exception

        End Try

        mUpdatingUI = False
    End Sub

    Public Function StatusReport(ByVal TableErrors() As Boolean) As String
        StatusReport = ""

        If (K1 = 0 Or U = 0) Then
            StatusReport &= My.Resources.RatingEquMsg1 & " "
            StatusReport &= UnitsDialog.UiValueUnitsText(K2, "m")
        Else
            StatusReport &= My.Resources.Equation & ":  Q_fit = K1 * (h1 + K2) ^ u" & vbCrLf
            StatusReport &= My.Resources.Parameters & ":   " & QParamString() & vbCrLf
            StatusReport &= My.Resources.CoefficientOfDetermination & " = " & RSquaredString() & vbCrLf & vbCrLf

            Dim edx As Integer = 0
            For Each errBool In TableErrors
                If (errBool) Then
                    If (edx < 10) Then
                        StatusReport &= " "
                    End If
                    StatusReport &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
                End If
                edx += 1
            Next errBool

            StatusReport &= vbCrLf
            StatusReport &= My.Resources.RatingEquMsg2 & " "
            StatusReport &= My.Resources.RatingEquMsg3 & " "
            StatusReport &= My.Resources.RatingEquMsg4 & " "
            StatusReport &= My.Resources.RatingEquMsg5
        End If

    End Function

    Public Sub UpdateRatingEquationData(ByRef RatingResults() As RatingResultsType,
                                        ByRef TableErrors() As Boolean)
        Dim MinVal As Single
        Dim MaxVal As Single
        Dim Inc As Single

        Dim choicesControl As TableChoicesControl = mWinFlumeForm.GetTableChoicesControl
        choicesControl.ValidateSmartRange(mFlume)

        If (mFlume.RatingTableType = HQTable) Then '  Head-Discharge (HQ) rating table
            MinVal = mFlume.RatingHMin
            MaxVal = mFlume.RatingHMax
            Inc = mFlume.RatingHInc

            mFlume.MakeRating(HQTable, False, MinVal, MaxVal, Inc, RatingResults, TableErrors)
        Else ' Discharge-Head (QH) rating table
            MinVal = mFlume.RatingQMin
            MaxVal = mFlume.RatingQMax
            Inc = mFlume.RatingQInc

            mFlume.MakeRating(QHTable, False, MinVal, MaxVal, Inc, RatingResults, TableErrors)
        End If

        ' CurveFit() calculates K1, K2 & u in UI units not SI units
        Flume.CurveFit(RatingResults, False, K1, K2, U, RSquared, Me.EqK2Zero)

    End Sub

#End Region

#Region " Update Rating Equation Table "

    '*********************************************************************************************************
    ' UpdateRatingEquationTable - Update Rating Equation Table using input Rating Results
    '*********************************************************************************************************
    Public Sub UpdateRatingEquationTable(ByVal RatingResults() As RatingResultsType)

        Dim choicesControl As TableChoicesControl = mWinFlumeForm.GetTableChoicesControl
        Dim tblChoices As List(Of TableChoice) = choicesControl.TableChoices()
        Dim numChoices As Integer = choicesControl.NumberOfTableChoices()

        ' Define the columns' header text and width
        With mTable
            .Rows.Clear()
            .Columns.Clear()
            .ColumnCount = 6

            Dim tblChoice As TableChoice = tblChoices(0)
            tblChoice.Name = My.Resources.SillReferencedHeadAtGage
            tblChoice.Symbol = "h1"
            tblChoice.SiUnits = "m"
            .Columns(0).HeaderText = TableColumnName(tblChoice)

            tblChoice = tblChoices(1)
            tblChoice.Name = My.Resources.TheoreticalDischarge
            tblChoice.Symbol = "Q"
            tblChoice.SiUnits = "m³/s"
            .Columns(1).HeaderText = TableColumnName(tblChoice)

            tblChoice.Name = My.Resources.CurveFitEquationDischarge
            tblChoice.Symbol = "Q_fit"
            tblChoice.SiUnits = "m³/s"
            .Columns(2).HeaderText = TableColumnName(tblChoice)

            tblChoice.Name = My.Resources.Difference
            tblChoice.Symbol = "D"
            tblChoice.SiUnits = "m³/s"
            .Columns(3).HeaderText = TableColumnName(tblChoice, "Q_fit - Q")

            tblChoice.Name = My.Resources.Difference
            tblChoice.Symbol = ""
            tblChoice.SiUnits = "%"
            .Columns(4).HeaderText = TableColumnName(tblChoice, "D/Q * 100")

            tblChoice.Name = My.Resources.Warnings
            tblChoice.Symbol = ""
            tblChoice.SiUnits = ""
            .Columns(5).HeaderText = TableColumnName(tblChoice)

            .Columns(0).DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight

            ' Use 9-point / bold font for header text
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 67
            .ColumnHeadersDefaultCellStyle.Font = New Font(Me.Font.FontFamily, 9, FontStyle.Bold)

            ' Minimize column widths
            Dim numCols As Integer = .Columns.Count
            Dim colWidth As Integer = CInt((.Width - 2 * numCols) / .Columns.Count) - 2

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            For cdx As Integer = 0 To numCols - 1
                Dim col As DataGridViewColumn = .Columns(cdx)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                col.Width = Math.Max(colWidth, 88)
            Next cdx
        End With

        Dim lUnits As LengthUnits = UiLengthUnits
        Dim qUnits As DischargeUnits = UiDischargeUnits
        Dim formatStyle As String = "0.000"

        For Each RatingResult As RatingResultsType In RatingResults
            If (RatingResult IsNot Nothing) Then

                Dim rowString(5) As String

                With RatingResult

                    Dim sih1 As Single = .SMALLh1
                    Dim uih1 As Single = UiLengthValue(sih1, lUnits)
                    rowString(0) = Format(uih1, formatStyle)

                    Dim siQ As Single = .Q
                    Dim uiQ As Single = UiDischargeValue(siQ, qUnits)
                    rowString(1) = Format(uiQ, formatStyle)

                    ' K1, K2 & U are based on UI units not SI units
                    Dim uiQ_fit As Single = CSng(K1 * (maxsingle(uih1 + K2, 0.0!)) ^ U)
                    rowString(2) = Format(uiQ_fit, formatStyle)

                    Dim uiD As Single = uiQ_fit - uiQ
                    rowString(3) = Format(uiD, formatStyle)

                    Dim PctError As Single = (uiD / uiQ) * 100
                    rowString(4) = Format(PctError, formatStyle)

                    Dim edx As Integer = 0
                    Dim errText As String = ""
                    For Each errbool As Boolean In .Errors
                        If (errbool) Then
                            If (errText = "") Then
                                errText = edx.ToString
                            Else
                                errText &= ", " & edx.ToString
                            End If
                        End If
                        edx += 1
                    Next errbool
                    rowString(5) = errText

                End With

                mTable.Rows.Add(rowString)

            End If
        Next RatingResult

        ' Highlight the Warning cells
        For row As Integer = 0 To mTable.Rows.Count - 1
            Dim cell As DataGridViewCell = mTable.Item(5, row)
            If (cell IsNot Nothing) Then
                Dim obj As Object = cell.Value
                If (obj IsNot Nothing) Then
                    If (obj.GetType = GetType(String)) Then
                        Dim str As String = DirectCast(obj, String)
                        If Not (str = "") Then
                            cell.Style.BackColor = Color.FromArgb(255, 255, 255, 128) ' Medium Yellow
                        End If
                    End If
                End If
            End If
        Next row

    End Sub
    '
    ' Generate 4-line column name for specified TableChoice entry
    '
    Public Shared Function TableColumnName(ByVal TblChoice As TableChoice,
                                  Optional ByVal FixedLine As String = "") As String
        TableColumnName = TblChoice.Name
        '
        ' First 3 lines are name of specified Table Choice
        '
        Dim tokens As String() = TableColumnName.Split(" ".ToCharArray)
        If (tokens.Count < 2) Then ' only 1 word in name; add newlines
            TableColumnName &= Chr(13) & FixedLine & Chr(13) & Chr(13)
        ElseIf (tokens.Count = 2) Then ' 2 words in name; 1 per line' add newline
            TableColumnName = tokens(0) & Chr(13) & tokens(1) & Chr(13) & FixedLine & Chr(13)
        ElseIf (tokens.Count = 3) Then ' 3 words in name; 1 per line
            TableColumnName = tokens(0) & Chr(13) & tokens(1) & Chr(13) & tokens(2) & Chr(13)
        Else ' 4 or more words; distribute between 3 lines
            Dim nameLength As Integer = TableColumnName.Length
            TableColumnName = ""
            Dim tdx As Integer = 0
            TableColumnName &= tokens(tdx) & " "
            tdx += 1
            While (TableColumnName.Length + tokens(tdx).Length <= nameLength * 1 / 3)
                If (tdx < tokens.Count - 1) Then
                    TableColumnName &= tokens(tdx) & " "
                    tdx += 1
                Else
                    Exit While
                End If
            End While
            TableColumnName &= Chr(13)
            TableColumnName &= tokens(tdx) & " "
            tdx += 1
            While (TableColumnName.Length + tokens(tdx).Length <= nameLength * 2 / 3)
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
        ' 4th line is Symbol & Units
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

#Region " Update Rating Equation Graph "

    Private Sub UpdateRatingEquationGraph(ByVal RatingResults() As RatingResultsType)
        '
        ' Update the Rating Graph
        '
        mGraph.FlumeRef = mFlume
        mGraph.K1 = K1
        mGraph.K2 = K2
        mGraph.U = U
        mGraph.UpdateRatingEquationGraph(RatingResults)

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub RatingEquationControl_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub HoldK2eq0CheckBox_ValueChanged() Handles HoldK2eq0CheckBox.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                Me.EqK2Zero = Me.HoldK2eq0CheckBox.Value
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' CheckedChanged event handlers for contained Controls
    '*********************************************************************************************************
    Private Sub ShowTableButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowTableButton.CheckedChanged
        If (Me.ShowTableButton.Checked) Then
            UpdateUI()
        End If
    End Sub

    Private Sub ShowGraphButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowGraphButton.CheckedChanged
        If (Me.ShowGraphButton.Checked) Then
            UpdateUI()
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub RatingEquationControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub RatingEquationControl_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        Me.StatusPanel.Height = CInt(Me.Height / 4)
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Sub RatingEquationControl_Load() - runtime initialization of control
    '*********************************************************************************************************
    Private Sub RatingEquationControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.HorizontalSplitter
            If (DialogMode) Then
                .SplitterDistance = CInt(.Height * 3 / 4)
            Else
                .SplitterDistance = CInt(.Height * 2 / 3)
            End If
        End With

    End Sub

    '*********************************************************************************************************
    ' Sub ViewAsDialogButton_Click() - display table/graph as dialog box
    '*********************************************************************************************************
    Private Sub ViewAsDialogButton_Click(sender As Object, e As EventArgs) _
        Handles ViewAsDialogButton.Click
        mWinFlumeForm.ViewRatingEquationAsDialog()
    End Sub

#End Region

End Class
