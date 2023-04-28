
'*************************************************************************************************************
' Class ctl_DataGridView - UI control for displaying/editing a table of values
'*************************************************************************************************************
Imports System.IO

Imports WinFlume.UnitsDialog

Public Class ctl_DataGridView
    Inherits Windows.Forms.DataGridView

    Friend WithEvents GridContextMenu As ContextMenuStrip
    Private components As System.ComponentModel.IContainer
    Friend WithEvents CopyTable As ToolStripMenuItem
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents PasteTable As ToolStripMenuItem

#Region " Properties "

    Public Property TableColUnits As String()

    Public Property ClipboardText As String
    Public Property ClipboardRows As String()
    Public Property ClipboardColHeaders As String()
    Public Property ClipboardColUnits As String()

#End Region

#Region " Constructor(s) "
    '
    ' Visual Studio's Designer requires a New() with no parameters
    '
    Public Sub New()
        Me.InitializeComponent()

        With Me
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .GridColor = Color.Black
            .RowHeadersVisible = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            .Dock = DockStyle.Fill

            With .ColumnHeadersDefaultCellStyle
                .BackColor = System.Drawing.SystemColors.ControlDark
                .ForeColor = System.Drawing.SystemColors.ControlText
                '.Font = New Font(ParentFont, FontStyle.Bold)
                .WrapMode = DataGridViewTriState.True
                .Alignment = DataGridViewContentAlignment.TopCenter
            End With
        End With
    End Sub
    '
    ' Only for use when instantiating the ctl_DataGridView at runtime
    '
    Public Sub New(ByVal ParentFont As Font)
        Me.InitializeComponent()

        With Me
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .GridColor = Color.Black
            .RowHeadersVisible = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            .Dock = DockStyle.Fill

            With .ColumnHeadersDefaultCellStyle
                .BackColor = System.Drawing.SystemColors.ControlDark
                .ForeColor = System.Drawing.SystemColors.ControlText
                .Font = New Font(ParentFont, FontStyle.Bold)
                .WrapMode = DataGridViewTriState.True
                .Alignment = DataGridViewContentAlignment.TopCenter
            End With

        End With
    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GridContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyTable = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteTable = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GridContextMenu.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridContextMenu
        '
        Me.GridContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyTable, Me.PasteTable})
        Me.GridContextMenu.Name = "ContextMenu"
        Me.GridContextMenu.Size = New System.Drawing.Size(134, 48)
        '
        'CopyTable
        '
        Me.CopyTable.Name = "CopyTable"
        Me.CopyTable.Size = New System.Drawing.Size(133, 22)
        Me.CopyTable.Text = "Copy Table"
        Me.CopyTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasteTable
        '
        Me.PasteTable.Name = "PasteTable"
        Me.PasteTable.Size = New System.Drawing.Size(133, 22)
        Me.PasteTable.Text = "Paste Table"
        Me.PasteTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctl_DataGridView
        '
        Me.AllowUserToResizeColumns = False
        Me.AllowUserToResizeRows = False
        Me.CausesValidation = False
        Me.ContextMenuStrip = Me.GridContextMenu
        Me.ReadOnly = True
        Me.GridContextMenu.ResumeLayout(False)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Methods "

    Public Sub SetError(ByVal ErrMsg As String)
        ErrorProvider.SetError(Me, ErrMsg)
    End Sub

#End Region

#Region " Print Support Methods "

    '*********************************************************************************************************
    ' Function HeaderTexts()    - Generate printable text of the table's column headers
    ' Function TableTexts()     -     "        "       "   "  "     "       "   data
    '
    ' Input(s):     PageWidth       - character width of a print page
    '
    ' Returns:      List(Of String) - list of text for page columns
    '
    '                   1 entry     text for table's data that fits within 1 PageWidth
    '                   2 entries     "   "     "      "    "    "     "   2 PageWidths
    '                   3 entries     "   "     "      "    "    "     "   3     "
    '                   etc.
    '*********************************************************************************************************
    Public Function HeaderTexts(ByVal PageWidth As Integer) As List(Of String)
        Dim HdrTexts = New List(Of String)({""})
        '
        ' Find number and widths of each header text column
        '
        Dim hdrWidths As New List(Of Integer)({0})  ' Header widths per page
        Dim hdx As Integer = 0                      ' Index into header width list

        Dim colWidths As List(Of Integer) = Me.TableColumnWidths
        For Each colWidth As Integer In colWidths
            If (hdrWidths(hdx) + colWidth <= PageWidth) Then
                hdrWidths(hdx) += colWidth
            Else
                HdrTexts.Add("")
                hdrWidths.Add(colWidth)
                hdx += 1
            End If
        Next colWidth
        '
        ' Generate each header text column
        '
        Dim numHdrLines As Integer = Me.NumHeaderLines
        For lineNum As Integer = 1 To numHdrLines
            Dim hdrLine As String = HeaderLine(lineNum, colWidths)
            For hdx = 0 To HdrTexts.Count - 1
                Dim colText As String = hdrLine
                If (hdrWidths(hdx) < colText.Length) Then
                    colText = hdrLine.Substring(0, hdrWidths(hdx))
                    hdrLine = hdrLine.Substring(hdrWidths(hdx))
                End If
                HdrTexts(hdx) &= colText & vbCrLf
            Next hdx
        Next lineNum
        '
        ' Add header bar for each text column
        Dim barLine As String = HeaderBar(colWidths.Count, colWidths)
        For hdx = 0 To HdrTexts.Count - 1
            Dim barText As String = barLine
            If (hdrWidths(hdx) < barText.Length) Then
                barText = barLine.Substring(0, hdrWidths(hdx))
                barLine = barLine.Substring(hdrWidths(hdx))
            End If
            HdrTexts(hdx) &= barText & vbCrLf
        Next hdx

        Return HdrTexts
    End Function

    Public Function TableTexts(ByVal PageWidth As Integer) As List(Of String)
        Dim TblTexts = New List(Of String)({""})
        '
        ' Find number and widths of each header text column
        '
        Dim hdrWidths As New List(Of Integer)({0})  ' Header widths per page
        Dim hdx As Integer = 0                      ' Index into header width list

        Dim colWidths As List(Of Integer) = Me.TableColumnWidths
        For Each colWidth As Integer In colWidths
            If (hdrWidths(hdx) + colWidth <= PageWidth) Then
                hdrWidths(hdx) += colWidth
            Else
                TblTexts.Add("")
                hdrWidths.Add(colWidth)
                hdx += 1
            End If
        Next colWidth
        '
        ' Generate each table text column
        '
        Dim rowHdrWidth As Integer = RowHeaderDataWidth()
        Dim numTblLines As Integer = Me.Rows.Count
        For lineNum As Integer = 1 To numTblLines
            Dim tblLine As String = TableLine(lineNum, colWidths, rowHdrWidth)
            For hdx = 0 To TblTexts.Count - 1
                Dim colText As String = tblLine
                If (hdrWidths(hdx) < colText.Length) Then
                    colText = tblLine.Substring(0, hdrWidths(hdx))
                    tblLine = tblLine.Substring(hdrWidths(hdx))
                End If
                TblTexts(hdx) &= colText & vbCrLf
            Next hdx
        Next lineNum

        Return TblTexts
    End Function

    Public Function PrintPages(ByVal MaxLines1 As Integer, ByVal MaxLines2 As Integer) As List(Of String)
        PrintPages = New List(Of String)

        Dim cpi As Integer = 11         ' Characters per inch (width)
        Dim cpl As Integer = cpi * 7    ' Characters per line (page width)
        Dim cpp As Integer = 0          ' Columns per page
        Dim tblWidth As Integer = 0

        If (Me.RowHeadersVisible) Then
            cpp = 1
        End If

        Dim colWidths As List(Of Integer) = Me.TableColumnWidths
        For Each colWidth As Integer In colWidths
            If (tblWidth + colWidth < cpl) Then
                tblWidth += colWidth
                cpp += 1
            Else
                Exit For
            End If
        Next colWidth

        ' First page
        Dim PrintPage As String = ""
        Dim numHdrLines As Integer = Me.NumHeaderLines
        For lineNum As Integer = 1 To numHdrLines
            PrintPage &= HeaderLine(lineNum, cpp, colWidths) & vbCrLf
        Next lineNum

        PrintPage &= HeaderBar(cpp, colWidths) & vbCrLf

        Dim rowHdrWidth As Integer = RowHeaderDataWidth()
        For lineNum As Integer = 1 To MaxLines1 - 1
            Dim line As String = DataLine(lineNum, cpp, colWidths, rowHdrWidth)
            If (line = "") Then
                PrintPages.Add(PrintPage)
                Exit Function
            Else
                line &= vbCrLf
                PrintPage &= line
            End If
        Next lineNum

        PrintPages.Add(PrintPage)

        ' Second page
        PrintPage = ""
        For lineNum As Integer = 1 To numHdrLines
            PrintPage &= HeaderLine(lineNum, cpp, colWidths) & vbCrLf
        Next lineNum

        PrintPage &= HeaderBar(cpp, colWidths) & vbCrLf

        For lineNum As Integer = MaxLines1 To MaxLines1 + MaxLines2 - 1
            Dim line As String = DataLine(lineNum, cpp, colWidths, rowHdrWidth)
            If (line = "") Then
                PrintPages.Add(PrintPage)
                Exit Function
            Else
                line &= vbCrLf
                PrintPage &= line
            End If
        Next lineNum

        PrintPages.Add(PrintPage)

    End Function

    Private Function TableLine(ByVal LineNum As Integer,
                               ByVal ColWidths As List(Of Integer),
                               Optional ByVal RowHdrWidth As Integer = 0) As String
        TableLine = ""

        If (Me.Rows Is Nothing) Then
            Exit Function
        End If

        Try
            If (LineNum <= Me.Rows.Count) Then
                Dim row As DataGridViewRow = Me.Rows(LineNum - 1)
                Dim hdx As Integer = 0

                If (Me.RowHeadersVisible) Then
                    Dim rHdr As String = ""

                    If (row.HeaderCell.Value IsNot Nothing) Then
                        Dim obj As Object = row.HeaderCell.Value
                        If (obj.GetType Is GetType(String)) Then
                            rHdr = CStr(obj).Trim
                            If (0 < RowHdrWidth) Then
                                rHdr = RightJustifyText(rHdr, RowHdrWidth)
                            Else
                                rHdr = RightJustifyText(rHdr, ColWidths(hdx) - 2)
                            End If
                        End If
                    End If

                    TableLine &= rHdr & StrDup(ColWidths(hdx) - rHdr.Length, " ")
                    hdx += 1
                End If

                For cdx As Integer = 0 To Me.Columns.Count - 1
                    Dim colWidth As Integer = ColWidths(hdx + cdx) - 2
                    Dim rStr As String = StrDup(colWidth, " ")

                    Dim rCell As DataGridViewCell = row.Cells(cdx)
                    If (rCell.Value IsNot Nothing) Then
                        Dim obj As Object = rCell.Value
                        If (obj.GetType Is GetType(String)) Then
                            rStr = CStr(obj).Trim
                            If (rStr = "") Then
                                rStr = StrDup(colWidth, " ")
                            Else
                                If (IsNumeric(rStr.Substring(0, 1))) Then
                                    rStr = RightJustifyText(rStr, colWidth)
                                Else ' must be a sign char (+-)
                                    rStr = RightJustifyText(rStr, colWidth + 1)
                                    TableLine = TableLine.Substring(0, TableLine.Length - 1)
                                End If
                            End If
                        End If
                    End If

                    TableLine &= rStr & "  "
                Next cdx

                TableLine = TableLine.Substring(0, TableLine.Length - 2)

            Else
                Exit Try
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Function

    Private Function DataLine(ByVal LineNum As Integer, ByVal ColsPerPage As Integer,
                              ByVal ColWidths As List(Of Integer),
                              Optional ByVal RowHdrWidth As Integer = 0) As String
        DataLine = ""

        If (Me.Rows Is Nothing) Then
            Exit Function
        End If

        Try
            If (LineNum <= Me.Rows.Count) Then
                Dim row As DataGridViewRow = Me.Rows(LineNum - 1)
                Dim hdx As Integer = 0

                If (Me.RowHeadersVisible) Then
                    Dim rHdr As String = ""

                    If (row.HeaderCell.Value IsNot Nothing) Then
                        Dim obj As Object = row.HeaderCell.Value
                        If (obj.GetType Is GetType(String)) Then
                            rHdr = CStr(obj).Trim
                            If (0 < RowHdrWidth) Then
                                rHdr = RightJustifyText(rHdr, RowHdrWidth)
                            Else
                                rHdr = RightJustifyText(rHdr, ColWidths(hdx) - 2)
                            End If
                        End If
                    End If

                    DataLine &= rHdr & StrDup(ColWidths(hdx) - rHdr.Length, " ")
                    hdx += 1
                End If

                For cdx As Integer = 0 To Me.Columns.Count - 1
                    If (cdx < ColsPerPage) Then
                        Dim colWidth As Integer = ColWidths(hdx + cdx) - 2
                        Dim rStr As String = StrDup(colWidth, " ")

                        Dim rCell As DataGridViewCell = row.Cells(cdx)
                        If (rCell.Value IsNot Nothing) Then
                            Dim obj As Object = rCell.Value
                            If (obj.GetType Is GetType(String)) Then
                                rStr = CStr(obj).Trim
                                If (rStr = "") Then
                                    rStr = StrDup(colWidth, " ")
                                Else
                                    If (IsNumeric(rStr.Substring(0, 1))) Then
                                        rStr = RightJustifyText(rStr, colWidth)
                                    Else ' must be a sign char (+-)
                                        rStr = RightJustifyText(rStr, colWidth + 1)
                                        DataLine = DataLine.Substring(0, DataLine.Length - 1)
                                    End If
                                End If
                            End If
                        End If

                        DataLine &= rStr & "  "
                    Else
                        Exit Try
                    End If
                Next cdx

                DataLine = DataLine.Substring(0, DataLine.Length - 2)

            Else
                Exit Try
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Function

    Public Function HeaderLine(ByVal LineNum As Integer,
                               ByVal ColWidths As List(Of Integer)) As String
        HeaderLine = ""

        If (Me.Columns Is Nothing) Then
            Exit Function
        End If

        Try
            Dim cdx As Integer = 0

            If (Me.RowHeadersVisible) Then
                Dim obj As Object = Me.TopLeftHeaderCell.Value
                If (obj.GetType Is GetType(String)) Then
                    Dim hdr As String = CStr(obj)
                    Dim lines() As String = hdr.Split(Chr(13))

                    If (LineNum <= lines.Length) Then
                        Dim line As String = lines(LineNum - 1)

                        Dim colWidth As Integer = ColWidths(cdx)
                        line = (line & "                    ").Substring(0, colWidth)
                        HeaderLine &= line
                        cdx += 1
                    End If
                End If
            End If

            For Each col As DataGridViewColumn In Me.Columns
                Dim hdr As String = col.HeaderText
                Dim lines() As String = hdr.Split(Chr(13))

                If (LineNum <= lines.Length) Then
                    Dim line As String = lines(LineNum - 1)

                    Dim colWidth As Integer = ColWidths(cdx)
                    line = (line & "                    ").Substring(0, colWidth)
                    HeaderLine &= line
                    cdx += 1
                End If
            Next col

            HeaderLine = HeaderLine.Substring(0, HeaderLine.Length - 2)

        Catch ex As Exception
        End Try
    End Function

    Public Function HeaderLine(ByVal LineNum As Integer, ByVal ColsPerPage As Integer,
                               ByVal ColWidths As List(Of Integer)) As String
        HeaderLine = ""

        If (Me.Columns Is Nothing) Then
            Exit Function
        End If

        Try
            Dim cdx As Integer = 0

            If (Me.RowHeadersVisible) Then
                Dim obj As Object = Me.TopLeftHeaderCell.Value
                If (obj.GetType Is GetType(String)) Then
                    Dim hdr As String = CStr(obj)
                    Dim lines() As String = hdr.Split(Chr(13))

                    If (LineNum <= lines.Length) Then
                        Dim line As String = lines(LineNum - 1)

                        Dim colWidth As Integer = ColWidths(cdx)
                        line = (line & "                    ").Substring(0, colWidth)
                        HeaderLine &= line
                        cdx += 1
                    End If
                End If
            End If

            For Each col As DataGridViewColumn In Me.Columns
                Dim hdr As String = col.HeaderText
                Dim lines() As String = hdr.Split(Chr(13))

                If (LineNum <= lines.Length) Then
                    Dim line As String = lines(LineNum - 1)

                    If (cdx < ColsPerPage) Then
                        Dim colWidth As Integer = ColWidths(cdx)
                        line = (line & "                    ").Substring(0, colWidth)
                        HeaderLine &= line
                        cdx += 1
                    Else
                        Exit For
                    End If
                End If
            Next col

            HeaderLine = HeaderLine.Substring(0, HeaderLine.Length - 2)

        Catch ex As Exception
        End Try
    End Function

    Public Function HeaderBar(ByVal ColsPerPage As Integer, ByVal ColWidths As List(Of Integer)) As String
        HeaderBar = ""

        Try
            For cdx As Integer = 0 To ColWidths.Count - 1
                If (cdx < ColsPerPage) Then
                    Dim colWidth As Integer = ColWidths(cdx)
                    HeaderBar &= "--------------------".Substring(0, colWidth - 2) & "  "
                Else
                    Exit For
                End If
            Next cdx

            HeaderBar = HeaderBar.Substring(0, HeaderBar.Length - 2)

        Catch ex As Exception
        End Try
    End Function

    Public Function NumHeaderLines() As Integer
        NumHeaderLines = 0

        With Me
            If (.Columns Is Nothing) Then
                Exit Function
            End If

            If (.RowHeadersVisible) Then
                Dim obj As Object = .TopLeftHeaderCell.Value
                If (obj.GetType Is GetType(String)) Then
                    Dim hdr As String = CStr(obj)
                    Dim lines() As String = hdr.Split(Chr(13))
                    If (NumHeaderLines < lines.Length) Then
                        NumHeaderLines = lines.Length
                    End If
                End If
            End If

            For Each col As DataGridViewColumn In .Columns
                Dim hdr As String = col.HeaderText
                Dim lines() As String = hdr.Split(Chr(13))
                If (NumHeaderLines < lines.Length) Then
                    NumHeaderLines = lines.Length
                End If
            Next col
        End With
    End Function

    Public Function RowHeaderDataWidth() As Integer
        RowHeaderDataWidth = 0

        If (Me.RowHeadersVisible) Then
            Dim obj As Object = Me.TopLeftHeaderCell.Value
            If (obj.GetType Is GetType(String)) Then

                For Each row As DataGridViewRow In Me.Rows
                    obj = row.HeaderCell.Value
                    If (obj.GetType Is GetType(String)) Then
                        Dim rHdr As String = CStr(obj)
                        If (RowHeaderDataWidth < rHdr.Length) Then
                            RowHeaderDataWidth = rHdr.Length
                        End If
                    End If
                Next row
            End If
        End If
    End Function

    Public Function TableColumnWidths() As List(Of Integer)
        TableColumnWidths = New List(Of Integer)

        With Me
            If (.Columns Is Nothing) Then
                Exit Function
            End If

            If (.RowHeadersVisible) Then
                Dim obj As Object = .TopLeftHeaderCell.Value
                If (obj.GetType Is GetType(String)) Then
                    Dim hdr As String = CStr(obj)
                    Dim len As Integer = 0
                    Dim lines() As String = hdr.Split(Chr(13))
                    For Each line As String In lines
                        If (len < line.Length + 2) Then
                            len = line.Length + 2
                        End If
                    Next line

                    For Each row As DataGridViewRow In Me.Rows
                        obj = row.HeaderCell.Value
                        If (obj.GetType Is GetType(String)) Then
                            hdr = CStr(obj)
                            If (len < hdr.Length + 2) Then
                                len = hdr.Length + 2
                            End If
                        End If
                    Next row

                    TableColumnWidths.Add(len)
                End If
            End If

            Dim cdx As Integer = 0
            For Each col As DataGridViewColumn In .Columns
                Dim hdr As String = col.HeaderText
                Dim len As Integer = 0
                Dim lines() As String = hdr.Split(Chr(13))
                For Each line As String In lines
                    If (len < line.Length + 2) Then
                        len = line.Length + 2
                    End If
                Next line

                For Each row As DataGridViewRow In .Rows
                    Dim rCell As DataGridViewCell = row.Cells(cdx)
                    If (rCell.Value IsNot Nothing) Then
                        Dim rStr As String = CStr(rCell.Value)
                        If (0 < rStr.Length) Then
                            If (IsNumeric(rStr.Substring(0, 1))) Then
                                If (len < rStr.Length + 2) Then
                                    len = rStr.Length + 2
                                End If
                            Else
                                If (len < rStr.Length + 1) Then
                                    len = rStr.Length + 1
                                End If
                            End If
                        End If
                    End If
                Next row

                TableColumnWidths.Add(len)
                cdx += 1
            Next col
        End With
    End Function

#End Region

#Region " Undo/Redo Methods "

    Public Sub AddUndoItem(ByVal UndoValue As Object, Optional ByVal Reason As String = "")
        If (Reason = "") Then
            Reason = My.Resources.ValueChange
        End If
        Dim undoText As String = My.Resources.Table & " - " & Reason
        WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, UndoValue)
    End Sub

    Public Sub Undo(ByVal ParentName As String, ByVal ControlName As String, ByVal UndoValue As Object)
        Debug.Assert(WinFlumeForm.InUndo, "Not in Undo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                RaiseUndoTableEvent(UndoValue) ' Since UndoValue is unknown here, let others handle Undo
            Else
                Debug.Assert(False, "Undo - Invalid control name")
            End If
        Else
            Debug.Assert(False, "Undo - Invalid parent name")
        End If
    End Sub

    Public Sub AddRedoItem(ByVal RedoValue As Object, Optional ByVal Reason As String = "")
        If (Reason = "") Then
            Reason = My.Resources.ValueChange
        End If
        Dim redoText As String = My.Resources.Table & " - " & Reason
        WinFlumeForm.AddRedoItem(Me.Parent.Name, Me.Name, redoText, RedoValue)
    End Sub

    Public Sub Redo(ByVal ParentName As String, ByVal ControlName As String, ByVal RedoValue As Object)
        Debug.Assert(WinFlumeForm.InRedo, "Not in Redo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                RaiseRedoTableEvent(RedoValue) ' Since RedoValue is unknown here, let others handle Redo
            Else
                Debug.Assert(False, "Redo - Invalid control name")
            End If
        Else
            Debug.Assert(False, "Redo - Invalid parent name")
        End If
    End Sub

#End Region

#Region " Copy To Clipboard "

    Public Sub CopyToClipboard()
        Dim clipboardText As String = ""
        Dim clipboardLine As String = ""

        ' WinFlume name & version
        Dim version As String = WinFlumeForm.WinFlumeName() & " " & WinFlumeForm.WinFlumeVersion()
        Dim username As String = WinFlumeForm.Username.Trim
        Dim flume As Flume.FlumeType = WinFlumeForm.Flume
        '
        ' Start with header
        '
        Dim file As String = My.Resources.File          ' Get localized strings
        Dim user As String = My.Resources.User
        Dim desc As String = My.Resources.Desc
        Dim revision As String = My.Resources.Revision
        Dim name As String = My.Resources.Name

        With flume
            ' Line 1 - User Name, WinFlume Version
            Dim line1 As String = Trim(user & ": " & username)
            line1 &= vbTab & version

            ' Line 2 - File Name/Path, Revision #
            Dim filePath As String = Trim(.FlumeName)

            Dim line2 As String = Trim(file & ": " & filePath)
            line2 &= vbTab & revision & ": " & .Revision

            ' Line 3 - WinFlume project description
            Dim line3 As String = Trim(desc & ": " & .Description)

            ' Line 4 - Table name, Data/Time
            Dim tableName As String = Me.AccessibleName

            Dim line4 As String = Trim(name & ": " & tableName)
            line4 &= vbTab & Date.Now.ToString("g")

            clipboardText &= line1.Trim & vbCrLf
            clipboardText &= line2.Trim & vbCrLf
            clipboardText &= line3.Trim & vbCrLf
            clipboardText &= line4.Trim & vbCrLf

        End With

        '
        ' Add column headers
        '
        If (Me.RowHeadersVisible) Then ' include row header
            Dim obj As Object = Me.TopLeftHeaderCell.Value
            If (obj.GetType Is GetType(String)) Then
                Dim hdr As String = CStr(obj)
                Dim lines() As String = hdr.Split(Chr(13))

                For ldx As Integer = 0 To lines.Length - 1
                    Dim line As String = lines(ldx).Trim
                    If Not (line = "") Then
                        clipboardLine &= line & " "
                    End If
                Next ldx

                clipboardLine = clipboardLine.Trim & vbTab

            Else
                Debug.Assert(False)
                clipboardLine = " " & vbTab
            End If
        End If

        For cdx As Integer = 0 To Me.Columns.Count - 1
            Dim col As DataGridViewColumn = Me.Columns(cdx)
            Dim hdr As String = col.HeaderText
            Dim lines() As String = hdr.Split(Chr(13))

            For ldx As Integer = 0 To lines.Length - 1
                Dim line As String = lines(ldx).Trim
                If Not (line = "") Then
                    clipboardLine &= line & " "
                End If
            Next ldx

            If (cdx < Me.Columns.Count - 1) Then
                clipboardLine = clipboardLine.Trim & vbTab
            End If
        Next cdx

        clipboardText &= clipboardLine.Trim & vbCrLf
        '
        ' Continue with column data
        '
        For rdx As Integer = 0 To Me.Rows.Count - 1
            Dim row As DataGridViewRow = Me.Rows(rdx)
            Dim rStr As String = ""

            clipboardLine = ""

            If (Me.RowHeadersVisible) Then ' include row header
                If (row.HeaderCell.Value IsNot Nothing) Then
                    Dim obj As Object = row.HeaderCell.Value
                    If (obj.GetType Is GetType(String)) Then
                        rStr = CStr(obj).Trim
                        If (rStr = "") Then
                            rStr = " "
                        End If
                    Else
                        Debug.Assert(False)
                        rStr = " "
                    End If
                End If

                clipboardLine = rStr & vbTab
            End If

            For cdx As Integer = 0 To Me.Columns.Count - 1

                Dim rCell As DataGridViewCell = row.Cells(cdx)
                If (rCell.Value IsNot Nothing) Then
                    Dim obj As Object = rCell.Value
                    If (obj.GetType Is GetType(String)) Then
                        rStr = CStr(obj).Trim
                        If (rStr = "") Then
                            rStr = " "
                        End If
                    Else
                        Debug.Assert(False)
                        rStr = " "
                    End If

                    clipboardLine &= rStr

                    If (cdx < Me.Columns.Count - 1) Then
                        clipboardLine &= vbTab
                    End If
                End If
            Next cdx

            clipboardText &= clipboardLine & vbCrLf
        Next rdx

        Clipboard.SetDataObject(clipboardText, True)

    End Sub

#End Region

#Region " Paste From Clipboard "

    '*********************************************************************************************************
    ' Function CanPasteFromClipboard() - verify paste data from clipboard is compatible with grid view
    '*********************************************************************************************************
    Public Function CanPasteFromClipboard() As Boolean
        CanPasteFromClipboard = False

        ' Can't paste to ReadOnly tables
        If (Me.ReadOnly = True) Then
            Exit Function
        End If
        '
        ' Get table properties
        '
        Dim tableColCount As Integer = Me.Columns.Count         ' # of columns
        ReDim TableColUnits(tableColCount - 1)                  ' Table UI column units
        For cdx As Integer = 0 To tableColCount - 1
            Dim colHdr As String = Me.Columns(cdx).HeaderText
            Dim ldx As Integer = colHdr.IndexOf("(")
            Dim rdx As Integer = colHdr.IndexOf(")")
            If (ldx < rdx) Then
                TableColUnits(cdx) = colHdr.Substring(ldx + 1, rdx - ldx - 1)
            Else
                TableColUnits(cdx) = ""
            End If
        Next cdx
        '
        ' Get clipboard data
        '
        ClipboardText = Clipboard.GetText()
        ClipboardText = ClipboardText.Replace(vbCrLf, vbCr)
        ClipboardText = ClipboardText.Replace(vbCr & vbCr, vbCr)

        ClipboardRows = ClipboardText.Split(vbCr.ToCharArray)

        ' Remove empty rows
        Dim ddx As Integer = 0
        For rdx As Integer = 0 To ClipboardRows.Length - 1
            Dim clipRow As String = ClipboardRows(rdx).Trim
            If (clipRow <> "") Then
                ClipboardRows(ddx) = clipRow
                ddx += 1
            End If
        Next rdx

        ReDim Preserve ClipboardRows(ddx - 1)

        ' Remove header rows (rows starting with 'text: ...') e.g. 'User: J Smith
        ddx = 0
        For rdx As Integer = 0 To ClipboardRows.Length - 1
            Dim clipRow As String = ClipboardRows(rdx).Trim
            If (4 < clipRow.Length) Then
                If (clipRow(4) <> ":") Then
                    ClipboardRows(ddx) = clipRow
                    ddx += 1
                End If
            Else
                ClipboardRows(ddx) = clipRow
                ddx += 1
            End If
        Next rdx

        ReDim Preserve ClipboardRows(ddx - 1)

        Dim hasHeader As Boolean = True
        Dim clipboardColCount As Integer = 0
        Dim clipboardRowCount As Integer = ClipboardRows.Length
        If (clipboardRowCount > 0) Then ' there is data; verify it is compatible with table
            ' Check/verify column headers
            ClipboardColHeaders = ClipboardRows(0).Split(vbTab.ToCharArray)
            clipboardColCount = ClipboardColHeaders.Length

            If (clipboardColCount = tableColCount) Then ' # of columns match
                ReDim ClipboardColUnits(tableColCount - 1)

                ' Extract clipboard column units
                For cdx As Integer = 0 To tableColCount - 1
                    Dim clipboardHeader As String = ClipboardColHeaders(cdx)

                    Try ' to parse header as a Single; Exception generated if not a number
                        Dim value As Single = Single.Parse(clipboardHeader)
                        ClipboardColUnits(cdx) = TableColUnits(cdx)
                        hasHeader = False
                    Catch ex As Exception
                        ' Get units from column header
                        Dim ldx As Integer = clipboardHeader.IndexOf("(")
                        Dim rdx As Integer = clipboardHeader.IndexOf(")")
                        If (ldx < rdx) Then
                            ClipboardColUnits(cdx) = clipboardHeader.Substring(ldx + 1, rdx - ldx - 1)
                        Else
                            ClipboardColUnits(cdx) = TableColUnits(cdx)
                        End If
                    End Try
                Next cdx

                If (hasHeader) Then ' remove header row from clipboard rows
                    For rdx As Integer = 0 To ClipboardRows.Length - 2
                        ClipboardRows(rdx) = ClipboardRows(rdx + 1)
                    Next rdx

                    ReDim Preserve ClipboardRows(ClipboardRows.Length - 2)
                End If

                ' Verify clipboard column units match table column units
                For cdx As Integer = 0 To tableColCount - 1
                    Dim tableUiUnits As String = TableColUnits(cdx)
                    Dim clipboardUnits As String = ClipboardColUnits(cdx)

                    If (DischargeUnitsAbbreviations.Contains(tableUiUnits)) Then
                        If Not (DischargeUnitsAbbreviations.Contains(clipboardUnits)) Then
                            Exit Function
                        End If
                    ElseIf (LengthUnitsAbbreviations.Contains(tableUiUnits)) Then
                        If Not (LengthUnitsAbbreviations.Contains(clipboardUnits)) Then
                            Exit Function
                        End If
                    ElseIf (SlopeUnitsAbbreviations.Contains(tableUiUnits)) Then
                        If Not (SlopeUnitsAbbreviations.Contains(clipboardUnits)) Then
                            Exit Function
                        End If
                    ElseIf (VelocityUnitsAbbreviations.Contains(tableUiUnits)) Then
                        If Not (VelocityUnitsAbbreviations.Contains(clipboardUnits)) Then
                            Exit Function
                        End If
                    ElseIf (tableUiUnits <> "") Then
                        Exit Function
                    End If
                Next cdx
            Else
                Exit Function
            End If

            CanPasteFromClipboard = True
        End If

    End Function

#End Region

#Region " File I/O Methods "

    Public Sub ExportToFile()

        Dim saveDialog As New SaveFileDialog With {
            .Filter = "txt files (*.txt)|*.txt",
            .RestoreDirectory = True
        }

        Dim msg As String
        Dim title As String = "Export Error"

        ' Enclose Export code in Try Catch block
        Dim stream As StreamWriter = Nothing
        Try
            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim fileName As String = saveDialog.FileName
                If (0 < fileName.Length) Then
                    stream = New StreamWriter(fileName)
                    If (stream IsNot Nothing) Then
                        ExportToFile(stream)
                    End If
                End If
            End If
        Catch ex As Exception
            msg = "Error Opening / Writing File" & Chr(13) & Chr(13)
            msg += ex.Message
            MsgBox(msg, MsgBoxStyle.Exclamation, title)
        Finally
            If (stream IsNot Nothing) Then
                stream.Close()
            End If
        End Try

    End Sub

    Public Sub ExportToFile(ByVal Stream As StreamWriter)
        Dim fileLine As String = ""
        '
        ' Start with column headers
        '
        If (Me.RowHeadersVisible) Then ' include row header
            Dim obj As Object = Me.TopLeftHeaderCell.Value
            If (obj.GetType Is GetType(String)) Then
                Dim hdr As String = CStr(obj)
                Dim lines() As String = hdr.Split(Chr(13))

                For ldx As Integer = 0 To lines.Length - 1
                    Dim line As String = lines(ldx).Trim
                    If Not (line = "") Then
                        fileLine &= line & " "
                    End If
                Next ldx

                fileLine = fileLine.Trim & vbTab

            Else
                Debug.Assert(False)
                fileLine = " " & vbTab
            End If
        End If

        For cdx As Integer = 0 To Me.Columns.Count - 1
            Dim col As DataGridViewColumn = Me.Columns(cdx)
            Dim hdr As String = col.HeaderText
            Dim lines() As String = hdr.Split(Chr(13))

            For ldx As Integer = 0 To lines.Length - 1
                Dim line As String = lines(ldx).Trim
                If Not (line = "") Then
                    fileLine &= line & " "
                End If
            Next ldx

            If (cdx < Me.Columns.Count - 1) Then
                fileLine = fileLine.Trim & vbTab
            End If
        Next cdx

        Stream.WriteLine(fileLine)
        '
        ' Continue with column data
        '
        For rdx As Integer = 0 To Me.Rows.Count - 1
            Dim row As DataGridViewRow = Me.Rows(rdx)
            Dim rStr As String = ""

            fileLine = ""

            If (Me.RowHeadersVisible) Then ' include row header
                If (row.HeaderCell.Value IsNot Nothing) Then
                    Dim obj As Object = row.HeaderCell.Value
                    If (obj.GetType Is GetType(String)) Then
                        rStr = CStr(obj).Trim
                        If (rStr = "") Then
                            rStr = " "
                        End If
                    Else
                        Debug.Assert(False)
                        rStr = " "
                    End If
                End If

                fileLine = rStr & vbTab
            End If

            For cdx As Integer = 0 To Me.Columns.Count - 1

                Dim rCell As DataGridViewCell = row.Cells(cdx)
                If (rCell.Value IsNot Nothing) Then
                    Dim obj As Object = rCell.Value
                    If (obj.GetType Is GetType(String)) Then
                        rStr = CStr(obj).Trim
                        If (rStr = "") Then
                            rStr = " "
                        End If
                    Else
                        Debug.Assert(False)
                        rStr = " "
                    End If

                    fileLine &= rStr

                    If (cdx < Me.Columns.Count - 1) Then
                        fileLine &= vbTab
                    End If
                End If
            Next cdx

            Stream.WriteLine(fileLine)
        Next rdx

    End Sub

#End Region

#Region " UI Events & Handlers "
    '
    ' Undo / Redo events
    '
    Protected Sub RaiseUndoTableEvent(ByVal UndoValue As Object)
        RaiseEvent UndoTableEvent(UndoValue)
    End Sub

    Protected Sub RaiseRedoTableEvent(ByVal RedoValue As Object)
        RaiseEvent RedoTableEvent(RedoValue)
    End Sub

    Protected Friend Sub RaisePasteTableEvent()
        RaiseEvent PasteTableEvent()
    End Sub

    Public Event UndoTableEvent(ByVal UndoValue As Object)
    Public Event RedoTableEvent(ByVal RedoValue As Object)
    Public Event PasteTableEvent()

    Private Sub CopyTable_Click(sender As Object, e As EventArgs) _
        Handles CopyTable.Click
        CopyToClipboard()
    End Sub

    Private Sub PasteTable_Click(sender As Object, e As EventArgs) _
        Handles PasteTable.Click
        RaisePasteTableEvent()
    End Sub

    Private Sub GridContextMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) _
        Handles GridContextMenu.Opening
        If (Me.ReadOnly) Then
            PasteTable.Enabled = False
        Else
            PasteTable.Enabled = CanPasteFromClipboard()
        End If
    End Sub

#End Region

End Class
