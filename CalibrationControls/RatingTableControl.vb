
'*************************************************************************************************************
' Class RatingTableControl - UserControl for displaying the Rating Table
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

Public Class RatingTableControl

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
    Private WithEvents mTable As ctl_DataGridView = Nothing
    Public Function RatingTableGridView() As ctl_DataGridView
        Return mTable
    End Function

    Dim mRatingResults(1) As RatingResultsType
    Dim mTableErrors(MaxHydErrors) As Boolean
    Dim mRowErrors(MaxHydErrors) As Boolean

    Private mGraph As RatingTableGraph = Nothing

    Private mShowAllErrors As Boolean = True

#End Region

#Region " Dialog Mode "

    Private Property DialogMode As Boolean              ' Dialog / Application mode switch
    '
    ' Class to hold the local Dialog data while in DialogMode
    '
    Public Class DialogData
        Public RatingGraphItem1 As Integer
        Public RatingGraphItem2 As Integer
        Public RatingGraphItem3 As Integer
        Public RatingGraphSyncAxes As Boolean

        Public Sub New()
            Me.RatingGraphItem1 = WinFlumeForm.RatingGraphItem1
            Me.RatingGraphItem2 = WinFlumeForm.RatingGraphItem2
            Me.RatingGraphItem3 = WinFlumeForm.RatingGraphItem3
            Me.RatingGraphSyncAxes = WinFlumeForm.RatingGraphSyncAxes
        End Sub

        Public Function Changed() As Boolean
            Changed = True
            Do
                If (Me.RatingGraphItem1 <> WinFlumeForm.RatingGraphItem1) Then Exit Do
                If (Me.RatingGraphItem2 <> WinFlumeForm.RatingGraphItem2) Then Exit Do
                If (Me.RatingGraphItem3 <> WinFlumeForm.RatingGraphItem3) Then Exit Do
                If (Me.RatingGraphSyncAxes <> WinFlumeForm.RatingGraphSyncAxes) Then Exit Do
                Changed = False
            Loop Until True
        End Function

        Public Sub Save()
            WinFlumeForm.RatingGraphItem1 = Me.RatingGraphItem1
            WinFlumeForm.RatingGraphItem2 = Me.RatingGraphItem2
            WinFlumeForm.RatingGraphItem3 = Me.RatingGraphItem3
            WinFlumeForm.RatingGraphSyncAxes = Me.RatingGraphSyncAxes
        End Sub

    End Class

    Public mDialogData As DialogData = Nothing
    Public Function GetDialogData() As DialogData
        Return mDialogData
    End Function

#End Region

#Region " Graph Properties "

    Public Class GraphChoice
        Public Rating As Flume.RatingResultsEnum
        Public Name As String
        Public Symbol As String
        Public SiUnits As String
        Public RegTag As Integer
        Public GraphIdx As Integer

        Public Sub New(ByVal Rating As Flume.RatingResultsEnum, ByVal Name As String, ByVal Symbol As String, _
                       ByVal SiUnits As String, ByVal RegTag As Integer)
            Me.Rating = Rating
            Me.Name = Name
            Me.Symbol = Symbol
            Me.SiUnits = SiUnits
            Me.RegTag = RegTag
            Me.GraphIdx = 0
        End Sub

        Public Sub New(ByVal TblChoice As TableChoice, ByVal RegTag As Integer)
            With TblChoice
                Me.Rating = .Rating
                Me.Name = .Name
                Me.Symbol = .Symbol
                Me.SiUnits = .SiUnits
            End With
            Me.RegTag = RegTag
        End Sub

        Public Function NameSymbol() As String
            NameSymbol = Me.Name
            If Not (Me.Symbol = "") Then
                NameSymbol &= ", " & Me.Symbol
            End If
        End Function

    End Class

    '*********************************************************************************************************
    ' Function GraphList() - returns the complete list of choices for the Y Axes of the Rating Graph
    '
    ' Note - this is the complete list, not the adjusted list shown in the drop-downs.  This list only
    '        needs to be generated once as it does not change.
    '*********************************************************************************************************
    Private mGraphList As List(Of GraphChoice) = Nothing
    Public Function GraphList() As List(Of GraphChoice)
        If (mGraphList Is Nothing) Then
            ' Graph's Y Axes choices are based on the Rating Table columns
            Dim choicesControl As TableChoicesControl = mWinFlumeForm.GetTableChoicesControl
            Dim tblChoices As List(Of TableChoice) = choicesControl.TableChoices()

            mGraphList = New List(Of GraphChoice) From {
                New GraphChoice(RatingResultsEnum.None, My.Resources.None, "", "", 0),
                New GraphChoice(tblChoices(0), 1)
            }
            ' Skip TableChoice(1) - discharge is X Axis
            For tdx = 2 To 14
                mGraphList.Add(New GraphChoice(tblChoices(tdx), tdx))
            Next tdx

        End If
        GraphList = mGraphList
    End Function

    '*********************************************************************************************************
    ' Property RatingGraphItem1/2/3() - Get/Set Registry selections for Rating Graph's Y axes
    '*********************************************************************************************************
    Private Property RatingGraphItem1() As Integer
        Get
            If (Me.DialogMode) Then ' get local selection
                RatingGraphItem1 = mDialogData.RatingGraphItem1
            Else ' Application mode; get registry selection
                RatingGraphItem1 = WinFlumeForm.RatingGraphItem1
            End If

            Dim graphList As List(Of GraphChoice) = Me.GraphList
            Dim regChoice As GraphChoice = graphList(RatingGraphItem1)
            Dim regSelect As String = regChoice.NameSymbol

            ' Find selection in UI's drop-down list
            For idx As Integer = 0 To Me.LeftAxisSelect1.Items.Count - 1
                Dim uiSelect As String = CStr(Me.LeftAxisSelect1.Items(idx))
                If (uiSelect = regSelect) Then
                    RatingGraphItem1 = idx
                    Exit For
                End If
            Next idx
        End Get
        Set(ByVal value As Integer)
            ' Get selection from UI's drop-down list
            Dim uiSelect As String = CStr(Me.LeftAxisSelect1.SelectedItem)

            ' Set Registry selection based on complete list of choices
            Dim graphList As List(Of GraphChoice) = Me.GraphList

            For idx As Integer = 0 To graphList.Count - 1
                Dim regChoice As GraphChoice = graphList(idx)
                Dim regSelect As String = regChoice.NameSymbol
                If (regSelect = uiSelect) Then
                    value = idx
                    Exit For
                End If
            Next idx

            If (Me.DialogMode) Then ' set local selection
                mDialogData.RatingGraphItem1 = value
            Else ' Application mode; set registry selection
                WinFlumeForm.RatingGraphItem1 = value
            End If
        End Set
    End Property

    Private Property RatingGraphItem2() As Integer
        Get
            If (Me.DialogMode) Then ' get local selection
                RatingGraphItem2 = mDialogData.RatingGraphItem2
            Else ' Application mode; get registry selection
                RatingGraphItem2 = WinFlumeForm.RatingGraphItem2
            End If

            Dim graphList As List(Of GraphChoice) = Me.GraphList
            Dim regChoice As GraphChoice = graphList(RatingGraphItem2)
            Dim regSelect As String = regChoice.NameSymbol

            ' Find Registry selection in UI's drop-down list
            For idx As Integer = 0 To Me.LeftAxisSelect2.Items.Count - 1
                Dim uiSelect As String = CStr(Me.LeftAxisSelect2.Items(idx))
                If (uiSelect = regSelect) Then
                    RatingGraphItem2 = idx
                    Exit For
                End If
            Next idx
        End Get
        Set(ByVal value As Integer)
            ' Get selection from UI's drop-down list
            Dim uiSelect As String = CStr(Me.LeftAxisSelect2.SelectedItem)

            ' Set Registry selection based on complete list of choices
            Dim graphList As List(Of GraphChoice) = Me.GraphList

            For idx As Integer = 0 To graphList.Count - 1
                Dim regChoice As GraphChoice = graphList(idx)
                Dim regSelect As String = regChoice.NameSymbol
                If (regSelect = uiSelect) Then
                    value = idx
                    Exit For
                End If
            Next idx

            If (Me.DialogMode) Then ' set local selection
                mDialogData.RatingGraphItem2 = value
            Else ' Application mode; set registry selection
                WinFlumeForm.RatingGraphItem2 = value
            End If
        End Set
    End Property

    Private Property RatingGraphItem3() As Integer
        Get
            If (Me.DialogMode) Then ' get local selection
                RatingGraphItem3 = mDialogData.RatingGraphItem3
            Else ' Application mode; get registry selection
                RatingGraphItem3 = WinFlumeForm.RatingGraphItem3
            End If

            Dim graphList As List(Of GraphChoice) = Me.GraphList
            Dim regChoice As GraphChoice = graphList(RatingGraphItem3)
            Dim regSelect As String = regChoice.NameSymbol

            ' Find Registry selection in UI's drop-down list
            For idx As Integer = 0 To Me.RightAxisSelect1.Items.Count - 1
                Dim uiSelect As String = CStr(Me.RightAxisSelect1.Items(idx))
                If (uiSelect = regSelect) Then
                    RatingGraphItem3 = idx
                    Exit For
                End If
            Next idx
        End Get
        Set(ByVal value As Integer)
            ' Get selection from UI's drop-down list
            Dim uiSelect As String = CStr(Me.RightAxisSelect1.SelectedItem)

            ' Set Registry selection based on complete list of choices
            Dim graphList As List(Of GraphChoice) = Me.GraphList

            For idx As Integer = 0 To graphList.Count - 1
                Dim regChoice As GraphChoice = graphList(idx)
                Dim regSelect As String = regChoice.NameSymbol
                If (regSelect = uiSelect) Then
                    value = idx
                    Exit For
                End If
            Next idx

            If (Me.DialogMode) Then ' set local selection
                mDialogData.RatingGraphItem3 = value
            Else ' Application mode; set registry selection
                WinFlumeForm.RatingGraphItem3 = value
            End If
        End Set
    End Property

    Private Property RatingGraphSyncAxes As Boolean
        Get
            If (Me.DialogMode) Then ' get local selection
                RatingGraphSyncAxes = mDialogData.RatingGraphSyncAxes
            Else ' Application mode; get registry selection
                RatingGraphSyncAxes = WinFlumeForm.RatingGraphSyncAxes
            End If
        End Get
        Set(value As Boolean)
            If (Me.DialogMode) Then ' set local selection
                mDialogData.RatingGraphSyncAxes = value
            Else ' Application mode; set registry selection
                WinFlumeForm.RatingGraphSyncAxes = value
            End If
        End Set
    End Property

#End Region

#Region " Constructor(s) "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DialogMode = False
        Me.LeftAxisSelect1.UndoEnabled = False
        Me.LeftAxisSelect2.UndoEnabled = False
        Me.RightAxisSelect1.UndoEnabled = False
        Me.SyncYAxesSelect.UndoEnabled = False

        mTable = New ctl_DataGridView(Me.Font) With {
            .ReadOnly = True,
            .AllowUserToDeleteRows = False,
            .AllowUserToAddRows = False,
            .AllowUserToOrderColumns = False,
            .AllowUserToResizeColumns = False,
            .AllowUserToResizeRows = False,
            .Dock = DockStyle.Fill,
            .ColumnHeadersHeight = 60,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader,
            .AccessibleName = My.Resources.RatingTable,
            .AccessibleDescription = My.Resources.CopyableTableOfData
        }

        With mTable
            ' Use 9-point / bold font for header text
            .ColumnHeadersDefaultCellStyle.Font = New Font(Me.Font.FontFamily, 9, FontStyle.Bold)
        End With

        mGraph = New RatingTableGraph With {
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
        Me.DialogMode = DialogMode
        Me.LeftAxisSelect1.UndoEnabled = False
        Me.LeftAxisSelect2.UndoEnabled = False
        Me.RightAxisSelect1.UndoEnabled = False
        Me.SyncYAxesSelect.UndoEnabled = False

        If (Me.DialogMode) Then
            mDialogData = New DialogData
        End If

        mTable = New ctl_DataGridView(Me.Font) With {
            .ReadOnly = True,
            .AllowUserToDeleteRows = False,
            .AllowUserToAddRows = False,
            .AllowUserToOrderColumns = False,
            .AllowUserToResizeColumns = False,
            .AllowUserToResizeRows = False,
            .ColumnHeadersHeight = 60,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader,
            .AccessibleName = My.Resources.RatingTable,
            .AccessibleDescription = My.Resources.CopyableTableOfData
        }

        mGraph = New RatingTableGraph With {
            .Dock = DockStyle.Fill,
            .AccessibleName = My.Resources.RatingTableGraph,
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
        Dim choicesControl As TableChoicesControl = mWinFlumeForm.GetTableChoicesControl
        choicesControl.ValidateSmartRange(mFlume)

        Dim MinVal As Single
        Dim MaxVal As Single
        Dim Inc As Single

        If (mFlume.RatingTableType = HQTable) Then '  Head-Discharge (HQ) rating table
            MinVal = mFlume.RatingHMin
            MaxVal = mFlume.RatingHMax
            Inc = mFlume.RatingHInc

            mFlume.MakeRating(HQTable, False, MinVal, MaxVal, Inc, mRatingResults, mTableErrors)
        Else ' Discharge-Head (QH) rating table
            MinVal = mFlume.RatingQMin
            MaxVal = mFlume.RatingQMax
            Inc = mFlume.RatingQInc

            mFlume.MakeRating(QHTable, False, MinVal, MaxVal, Inc, mRatingResults, mTableErrors)
        End If
        '
        ' Update display
        '
        Try
            If (Me.ShowTableButton.Checked) Then

                If Not (Me.DataPanel.Controls.Contains(mTable)) Then
                    Me.DataPanel.Controls.Clear()
                    Me.DataPanel.Controls.Add(mTable)
                End If

                Me.GraphControlPanel.Hide()
                Me.TableControlPanel.Show()

                Dim loc As Point = Me.ViewAsDialogButton.Location
                loc.X = TableControlPanel.Width - Me.ViewAsDialogButton.Width - 2
                Me.ViewAsDialogButton.Location = loc

                UpdateRatingTable(mRatingResults, mFlume.RatingTableType)

            Else ' Assume Me.ShowGraphButton.Checked

                If Not (Me.DataPanel.Controls.Contains(mGraph)) Then
                    Me.DataPanel.Controls.Clear()
                    Me.DataPanel.Controls.Add(mGraph)
                End If

                Me.SyncYAxesSelect.Value = Me.RatingGraphSyncAxes

                Me.TableControlPanel.Hide()
                Me.GraphControlPanel.Show()
                Me.UpdateRatingGraph(mRatingResults)
            End If

            UpdateErrorMessages() ' Update status

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        mUpdatingUI = False
    End Sub

    Private Sub UpdateErrorMessages()

        Dim edx As Integer

        Try
            mShowAllErrors = True

            If (Me.ShowTableButton.Checked) Then

                Dim selectedRowCount As Integer = mTable.Rows.GetRowCount(DataGridViewElementStates.Selected)
                If (selectedRowCount = 1) Then
                    For rdx As Integer = 0 To mTable.Rows.Count - 1
                        Dim tRow As DataGridViewRow = mTable.Rows(rdx)
                        If (tRow.Selected) Then
                            Dim rowRating As RatingResultsType = mRatingResults(rdx + 1)
                            If (rowRating IsNot Nothing) Then

                                For Each rowErr As Boolean In rowRating.Errors
                                    If (rowErr) Then
                                        mRowErrors = rowRating.Errors
                                        mShowAllErrors = False
                                        Exit For
                                    End If
                                Next rowErr

                                Exit For

                            End If
                        End If
                    Next
                End If
            End If

            If (mShowAllErrors) Then
                Me.StatusPanel.Title.Text = My.Resources.AllWarningMessagesForThisTable
                Me.StatusPanel.StatusBox.Clear()

                edx = 0
                Dim errText As String = ""
                For Each errBool As Boolean In mTableErrors
                    If (errBool) Then
                        If (edx < 10) Then
                            errText &= " "
                        End If
                        errText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
                    End If
                    edx += 1
                Next errBool

                Me.StatusPanel.StatusBox.Text = errText
            Else ' show error(s) for selected row
                Me.StatusPanel.Title.Text = My.Resources.WarningMessagesForThisRow
                Me.StatusPanel.StatusBox.Clear()

                edx = 0
                Dim errText As String = ""
                For Each errBool As Boolean In mRowErrors
                    If (errBool) Then
                        If (edx < 10) Then
                            errText &= " "
                        End If
                        errText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
                    End If
                    edx += 1
                Next errBool

                Me.StatusPanel.StatusBox.Text = errText
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Public Function ErrorText() As String
        ErrorText = ""

        Dim RatingResults(1) As RatingResultsType
        Dim TableErrors(MaxHydErrors) As Boolean

        Dim MinVal As Single
        Dim MaxVal As Single
        Dim Inc As Single

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

        Dim edx As Integer = 0
        For Each errBool As Boolean In TableErrors
            If (errBool) Then
                If (edx < 10) Then
                    ErrorText &= " "
                End If
                ErrorText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
            End If
            edx += 1
        Next errBool

    End Function

#End Region

#Region " Update Rating Table "

    Public Sub UpdateRatingTable()

        Dim RatingResults(1) As RatingResultsType
        Dim TableErrors(MaxHydErrors) As Boolean

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

        UpdateRatingTable(RatingResults, mFlume.RatingTableType)

    End Sub

    Public Sub UpdateRatingTable(ByVal RatingResults() As RatingResultsType,
                                 ByVal TableType As Integer)

        Dim cdx, edx, tdx As Integer

        Dim choicesControl As TableChoicesControl = mWinFlumeForm.GetTableChoicesControl
        Dim tblChoice As TableChoice
        Dim tblChoices As List(Of TableChoice) = choicesControl.TableChoices()
        Dim numChoices As Integer = choicesControl.NumberOfTableChoices()
        '
        ' Update Rating Table column headers
        '
        With mTable
            .Rows.Clear()
            .Columns.Clear()
            .ColumnCount = numChoices

            ' 1st two columns are HQ | QH
            If (TableType = HQTable) Then ' Head-Discharge (HQ) rating table

                tblChoice = tblChoices(0)
                .Columns(0).HeaderText = TableColumnName(tblChoice)
                tblChoice = tblChoices(1)
                .Columns(1).HeaderText = TableColumnName(tblChoice)

            Else ' Discharge-Head (QH) rating table

                tblChoice = tblChoices(1)
                .Columns(0).HeaderText = TableColumnName(tblChoice)
                tblChoice = tblChoices(0)
                .Columns(1).HeaderText = TableColumnName(tblChoice)

            End If

            ' 3rd column is Warnings
            tblChoice = tblChoices(tblChoices.Count - 1)
            .Columns(2).HeaderText = TableColumnName(tblChoice)

            ' Columns 4+ are user selected
            cdx = 3
            For tdx = 2 To tblChoices.Count - 2
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
        For Each RatingResult As RatingResultsType In RatingResults
            If (RatingResult IsNot Nothing) Then

                Dim rowString(numChoices) As String

                cdx = 0
                For tdx = 0 To tblChoices.Count - 1
                    tblChoice = tblChoices(tdx)
                    If (TableType = QHTable) Then
                        If (tdx = 0) Then
                            tblChoice = tblChoices(1)
                        ElseIf (tdx = 1) Then
                            tblChoice = tblChoices(0)
                        End If
                    End If
                    If (tblChoice.Selected) Then
                        Dim siValue As Single = Single.NaN
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
                                    rowString(2) = siString

                                Case RatingResultsEnum.FatalError
                                    Debug.Assert(False) ' not used
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
                                    Debug.Assert(False) ' not used
                                    siString = .NonFatalError.ToString
                                Case RatingResultsEnum.Q
                                    siValue = .Q
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

                        If (Single.IsNaN(siValue)) Then ' must be String
                            ' Currently, only Warnings/Errors are Strings
                        Else
                            Dim uiValue As Single = 0
                            Dim siUnits As String = tblChoice.SiUnits
                            Dim formatStyle As String = "0.000"

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

                            If (cdx < 2) Then ' 3rd column is now Warnings
                                rowString(cdx) = Format(uiValue, formatStyle)
                            Else
                                rowString(cdx + 1) = Format(uiValue, formatStyle)
                            End If

                        End If

                        cdx += 1
                    End If ' (tblChoice.Selected)
                Next tdx

                mTable.Rows.Add(rowString)
            End If

        Next RatingResult

        ' Highlight the Warning cells
        For row As Integer = 0 To mTable.Rows.Count - 1
            Dim cell As DataGridViewCell = mTable.Item(2, row)
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

#Region " Update Rating Graph "

    Private Sub UpdateRatingGraph(ByVal RatingResults() As RatingResultsType)
        '
        ' Update the user choices for Rating Graph
        '
        Dim graphList As List(Of GraphChoice) = Me.GraphList

        Dim regGraphItem1 As Integer = WinFlumeForm.RatingGraphItem1
        Dim regGraphItem2 As Integer = WinFlumeForm.RatingGraphItem2
        Dim regGraphItem3 As Integer = WinFlumeForm.RatingGraphItem3
        If (DialogMode) Then
            regGraphItem1 = mDialogData.RatingGraphItem1
            regGraphItem2 = mDialogData.RatingGraphItem2
            regGraphItem3 = mDialogData.RatingGraphItem3
        End If

        ' 1st left axis selection
        Me.LeftAxisSelect1.Items.Clear()
        For Each grfChoice As GraphChoice In graphList
            Dim grfSelect As String = grfChoice.NameSymbol
            If (grfSelect = My.Resources.None) Then ' "None" is always a choice
                Me.LeftAxisSelect1.Items.Add(grfSelect)
            ElseIf Not ((grfChoice.RegTag = regGraphItem2) Or (grfChoice.RegTag = regGraphItem3)) Then
                Me.LeftAxisSelect1.Items.Add(grfSelect)
            End If
        Next
        Me.LeftAxisSelect1.Value = Me.RatingGraphItem1

        ' 2nd left axis selection
        Me.LeftAxisSelect2.Items.Clear()
        For Each grfChoice As GraphChoice In graphList
            Dim grfSelect As String = grfChoice.NameSymbol
            If (grfSelect = My.Resources.None) Then ' "None" is always a choice
                Me.LeftAxisSelect2.Items.Add(grfSelect)
            ElseIf Not ((grfChoice.RegTag = regGraphItem1) Or (grfChoice.RegTag = regGraphItem3)) Then
                Me.LeftAxisSelect2.Items.Add(grfSelect)
            End If
        Next
        Me.LeftAxisSelect2.Value = Me.RatingGraphItem2

        ' 1st right axis selection
        Me.RightAxisSelect1.Items.Clear()
        For Each grfChoice As GraphChoice In graphList
            Dim grfSelect As String = grfChoice.NameSymbol
            If (grfSelect = My.Resources.None) Then ' "None" is always a choice
                Me.RightAxisSelect1.Items.Add(grfSelect)
            ElseIf Not ((grfChoice.RegTag = regGraphItem1) Or (grfChoice.RegTag = regGraphItem2)) Then
                Me.RightAxisSelect1.Items.Add(grfSelect)
            End If
        Next
        Me.RightAxisSelect1.Value = Me.RatingGraphItem3
        '
        ' Update the Rating Graph
        '
        mGraph.FlumeRef = mFlume
        mGraph.GraphList = Me.GraphList
        mGraph.SyncYAxesSelect = Me.SyncYAxesSelect.Checked
        mGraph.UpdateRatingTableGraph(regGraphItem1, regGraphItem2, regGraphItem3, RatingResults)

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
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub LeftAxisSelect1_ValueChanged() Handles LeftAxisSelect1.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                Me.RatingGraphItem1 = Me.LeftAxisSelect1.Value
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Private Sub LeftAxisSelect2_ValueChanged() Handles LeftAxisSelect2.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                Me.RatingGraphItem2 = Me.LeftAxisSelect2.Value
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Private Sub RightAxisSelect1_ValueChanged() Handles RightAxisSelect1.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                Me.RatingGraphItem3 = Me.RightAxisSelect1.Value
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Private Sub SyncYAxesSelect_ValueChanged() Handles SyncYAxesSelect.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                Me.RatingGraphSyncAxes = Me.SyncYAxesSelect.Value
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' CheckedChanged events handlers
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
    ' Sub MyBase_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Resize

        ' Resize ControlPanels
        Me.TableControlPanel.Width = Me.ControlPanel.Width - Me.TableControlPanel.Location.X - 1
        Me.GraphControlPanel.Width = Me.ControlPanel.Width - Me.GraphControlPanel.Location.X - 1

        Dim width As Integer = CInt((Me.GraphControlPanel.Width - Me.LeftAxisBox.Location.X) / 2 - 3)

        ' Left Axis controls
        Me.LeftAxisBox.Width = width
        Me.LeftAxisSelect1.Width = Me.LeftAxisBox.Width - Me.LeftAxisSelect1.Location.X * 2
        Me.LeftAxisSelect2.Width = Me.LeftAxisSelect1.Width

        ' Right Axis controls
        Dim loc As Point = New Point(Me.LeftAxisBox.Location.X + width + 5, Me.RightAxisBox.Location.Y)
        Me.RightAxisBox.Location = loc
        Me.RightAxisBox.Width = width
        Me.RightAxisSelect1.Width = Me.LeftAxisSelect1.Width

        ' Update control to match the new size
        UpdateUI()

    End Sub

    '*********************************************************************************************************
    ' Sub RatingTableControl_Load() - runtime initialization of control
    '*********************************************************************************************************
    Private Sub RatingTableControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.HorizontalSplitter
            If (DialogMode) Then
                .SplitterDistance = CInt(.Height * 3 / 4)
            Else
                .SplitterDistance = CInt(.Height * 2 / 3)
            End If
        End With

    End Sub

    Private Sub DataGridView_SelectionChanged(sender As Object, e As EventArgs) _
        Handles mTable.SelectionChanged
        UpdateErrorMessages()
    End Sub

    Private Sub HorizontalSplitter_SplitterMoved(sender As Object, e As SplitterEventArgs) _
        Handles HorizontalSplitter.SplitterMoved
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Sub ViewAsDialogButton_Click() - display table/graph as dialog box
    '*********************************************************************************************************
    Private Sub ViewAsDialogButton_Click(sender As Object, e As EventArgs) _
        Handles ViewAsDialogButton.Click
        mWinFlumeForm.ViewRatingTableAsDialog()
    End Sub

#End Region

End Class
