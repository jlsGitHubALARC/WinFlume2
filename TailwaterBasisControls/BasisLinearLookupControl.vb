
'*************************************************************************************************************
' Class BasisLinearLookupControl - UserControl for displaying & editing a tailwater calculation method:
'                                   Linear lookup from table of Q-y2 values
'*************************************************************************************************************
Imports Flume                   ' Flume data
Imports WinFlume.UnitsDialog    ' Unit conversion support

Public Class BasisLinearLookupControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mSection As Flume.SectionType = Nothing
    '
    ' Linear Lookup table data
    '
    Private mSelectedRow As Integer = 0
    Private mSelectedCol As Integer = 0

#End Region

#Region " Properties "

    '*********************************************************************************************************
    ' Property HQLookUpTable - Get/Set HQLooup table from Flume
    '
    ' This property filters out the 'erased' entries to provide a contiguous set of valid values
    '*********************************************************************************************************
    Private Property HQLookUpTable As HQLookupDataType()
        Get
            Dim HQTable(LOOKUP_TABLE_SIZE) As HQLookupDataType
            Dim tdx As Integer = 0

            ' Get valid (i.e. not erased) HQ value pairs
            For Each HQ As HQLookupDataType In mFlume.HQLookup
                With HQ
                    If (Not .QErased) And (Not .HErased) Then ' HQ pair has valid data
                        HQTable(tdx) = HQ
                        tdx += 1
                    End If
                End With
            Next HQ

            ' Return table with only valid HQ value pairs; may be empty
            ReDim Preserve HQTable(tdx - 1)
            HQLookUpTable = HQTable
        End Get
        Set(value As HQLookupDataType())
            Dim tdx As Integer = 0

            ' Start with contiguous set of HQ pairs passed in
            For Each HQ As HQLookupDataType In value
                With HQ
                    If (Not .QErased) And (Not .HErased) Then ' HQ pair has valid data
                        If tdx <= LOOKUP_TABLE_SIZE Then
                            mFlume.HQLookup(tdx) = HQ
                            tdx += 1
                        End If
                    End If
                End With
            Next HQ

            ' Add 'erased' HQ value pairs to fill out fixed size Flume HQLookup table
            While tdx <= LOOKUP_TABLE_SIZE
                mFlume.HQLookup(tdx).HErased = True
                mFlume.HQLookup(tdx).QErased = True
                tdx += 1
            End While
        End Set
    End Property

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Approach cross section
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Private mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        ' Validate update can occur
        mFlume = WinFlumeForm.Flume                                             ' Flume data
        If (mFlume Is Nothing) Then
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

        Try
            Dim SiLunits As String = SiLengthUnitsText()
            Dim UiLunits As String = UiLengthUnitsText()

            Dim SiQunits As String = SiDischargeUnitsText()
            Dim UiQunits As String = UiDischargeUnitsText()

            Me.LinearLookupTable.ReadOnly = False
            Me.LinearLookupTable.Columns(0).HeaderText = My.Resources.Discharge _
            & vbCrLf & "Q (" & UiQunits & ")"
            Me.LinearLookupTable.Columns(1).HeaderText = My.Resources.TailwaterLevel _
            & vbCrLf & "y2 (" & UiLunits & ")"

            Me.LinearLookupTable.Rows.Clear()

            Dim rowString(1) As String

            Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
            Dim tblLength As Integer = HQLookUpTable.Length

            For Each HQ As HQLookupDataType In HQLookUpTable
                With HQ
                    If (0 <= .Q) Then
                        rowString(0) = UiValueText(.Q, SiQunits)
                    Else
                        rowString(0) = "0"
                    End If

                    If (0 <= .H) Then
                        rowString(1) = UiValueText(.H, SiLunits)
                    Else
                        rowString(1) = "0"
                    End If
                End With

                Me.LinearLookupTable.Rows.Add(rowString)
            Next HQ

            If (mSelectedRow < 0) Then
                mSelectedRow = 0
            End If

            If (mSelectedRow > Me.LinearLookupTable.Rows.Count - 1) Then
                mSelectedRow = Me.LinearLookupTable.Rows.Count - 1
            End If

            If ((0 <= mSelectedRow) And (mSelectedRow < Me.LinearLookupTable.Rows.Count)) Then
                Dim selected As DataGridViewCell = Me.LinearLookupTable.Rows(mSelectedRow).Cells(mSelectedCol)
                Me.LinearLookupTable.CurrentCell = selected
                Me.LinearLookupTable.Select()
            End If

            ' Check for user input errors
            Dim ErrMsg As String = ""

            If (1 < tblLength) Then ' 2 or more entries
                Dim HQ0 As HQLookupDataType = HQLookUpTable(0)
                For tdx As Integer = 1 To tblLength - 1
                    Dim HQ1 As HQLookupDataType = HQLookUpTable(tdx)
                    If (HQ1.Q <= HQ0.Q) Then
                        ErrMsg = My.Resources.MsgQandHmustIncrease
                        Exit For
                    End If
                    If (HQ1.H <= HQ0.H) Then
                        ErrMsg = My.Resources.MsgQandHmustIncrease
                        Exit For
                    End If
                    HQ0 = HQ1
                Next tdx
            Else
                ErrMsg = My.Resources.MsgTableMustHaveTwoRows
            End If

            Me.LinearLookupTable.SetError(ErrMsg)

            ResizeUI()

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        mUpdatingUI = False
    End Sub

#End Region

#Region " Event Handlers "

#Region " Edit Table Events "

    '*********************************************************************************************************
    ' Linear Lookup table change events
    '*********************************************************************************************************
    Private Sub LinearLookupTable_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles LinearLookupTable.CellValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore event while updating UI
            If (mUpdatingUI) Then
                Return
            End If

            ' Get HQ Lookup Table from Flume
            Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
            Dim len As Integer = HQLookUpTable.Length
            If (len <= 0) Then ' nothing to change
                Return
            End If

            ' Set current table as Undo point
            LinearLookupTable.AddUndoItem(HQLookUpTable)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in change handler only

            ' Get updated table from the UI
            Dim rowCount As Integer = LinearLookupTable.Rows.Count
            Dim UItable(rowCount - 1) As HQLookupDataType

            Debug.Assert(len = rowCount)

            Dim Qunits As DischargeUnits = UiDischargeUnits
            Dim Hunits As LengthUnits = UiLengthUnits

            For rdx As Integer = 0 To rowCount - 1
                Dim HQflume As HQLookupDataType = HQLookUpTable(rdx)
                Dim HQui As DataGridViewRow = Me.LinearLookupTable.Rows(rdx)

                Dim Qsi As Single = HQflume.Q
                Try ' Single.Parse may fail if non-numeric text in Cell
                    Dim Qcell As DataGridViewCell = HQui.Cells(0)
                    Dim Qui As Single = Single.Parse(CStr(Qcell.Value))
                    Qsi = SiDischargeValue(Qui, Qunits)
                Catch ex As Exception
                    mSelectedRow = rdx
                    mSelectedCol = 0
                End Try

                Dim Hsi As Single = HQflume.H
                Try ' Single.Parse may fail if non-numeric text in Cell
                    Dim Hcell As DataGridViewCell = HQui.Cells(1)
                    Dim Hui As Single = Single.Parse(CStr(Hcell.Value))
                    Hsi = SiLengthValue(Hui, Hunits)
                Catch ex As Exception
                    mSelectedRow = rdx
                    mSelectedCol = 1
                End Try

                UItable(rdx).Q = Qsi
                UItable(rdx).QErased = False
                UItable(rdx).H = Hsi
                UItable(rdx).HErased = False
            Next

            Me.HQLookUpTable = UItable

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub LinearLookupTable_UndoTableEvent(ByVal UndoValue As Object) _
        Handles LinearLookupTable.UndoTableEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Redo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                LinearLookupTable.AddRedoItem(HQLookUpTable)
                ' Get Undo point's table
                HQLookUpTable = DirectCast(UndoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub LinearLookupTable_RedoTableEvent(ByVal RedoValue As Object) _
        Handles LinearLookupTable.RedoTableEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Undo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                LinearLookupTable.AddUndoItem(HQLookUpTable)
                ' Get Redo point's table
                HQLookUpTable = DirectCast(RedoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub LinearLookupTable_PasteTableEvent() _
        Handles LinearLookupTable.PasteTableEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Try
                ' Get/validate paste table from clipboard
                Dim pasteRows As String() = LinearLookupTable.ClipboardRows
                Dim pasteColHdrs As String() = LinearLookupTable.ClipboardColHeaders
                Dim pasteColUnits As String() = LinearLookupTable.ClipboardColUnits

                Debug.Assert((pasteRows IsNot Nothing) And
                             (pasteColHdrs IsNot Nothing) And
                             (pasteColUnits IsNot Nothing))
                Debug.Assert(0 < pasteRows.Length)
                Debug.Assert(2 = pasteColHdrs.Length)
                Debug.Assert(2 = pasteColUnits.Length)

                Dim col1PasteUnits As String = pasteColUnits(0)
                Dim col1SiUnits As String = SiUnitsText(col1PasteUnits)
                Dim col2PasteUnits As String = pasteColUnits(1)
                Dim col2SiUnits As String = SiUnitsText(col2PasteUnits)

                Debug.Assert(col1SiUnits = DischargeUnitsAbbreviations(0))
                Debug.Assert(col2SiUnits = LengthUnitsAbbreviations(0))

                ' Get HQ Lookup Table from Flume
                Dim HQtable As HQLookupDataType() = Me.HQLookUpTable

                ' Set current table as Undo point
                LinearLookupTable.AddUndoItem(HQtable, My.Resources.Paste)
                WinFlumeForm.ClearRedoStack() ' Clear Redo stack in change handler only

                ' Build new Measure Data Table from paste data
                ReDim HQtable(pasteRows.Length - 1)

                For tdx As Integer = 0 To pasteRows.Length - 1
                    Dim pasteRow As String = pasteRows(tdx)
                    Dim colVals As String() = pasteRow.Split(vbTab.ToCharArray)

                    Dim pasteDischarge As Single = Single.Parse(colVals(0))
                    Dim pasteLength As Single = Single.Parse(colVals(1))

                    Dim siDischarge As Single = SiValue(pasteDischarge, pasteColUnits(0))
                    Dim siLength As Single = SiValue(pasteLength, pasteColUnits(1))

                    Dim HQrow As HQLookupDataType = New HQLookupDataType With {
                        .Q = siDischarge,
                        .H = siLength
                    }

                    HQtable(tdx) = HQrow
                Next tdx

                Me.HQLookUpTable = HQtable

                mWinFlumeForm.RaiseFlumeDataChanged()

            Catch ex As Exception
                Debug.Assert(False, ex.Message)
            End Try
        End If
    End Sub

#End Region

#Region " Insert Row Events "

    '*********************************************************************************************************
    ' Insert Row button event handlers
    '*********************************************************************************************************
    Private Sub InsertRowButton_Click(sender As Object, e As EventArgs) _
        Handles InsertRowButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Get HQ Lookup Table from Flume
            Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
            Dim len As Integer = HQLookUpTable.Length

            ' Set current table as Undo point
            InsertRowButton.AddUndoItem(HQLookUpTable)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Insert a row before the selected table row
            Dim newRow As New HQLookupDataType With {
                .H = 0, .Q = 0,
                .HErased = False, .QErased = False}

            ReDim Preserve HQLookUpTable(len)

            If (LinearLookupTable.SelectedCells.Count > 0) Then
                Dim idx As Integer = LinearLookupTable.SelectedCells(0).RowIndex

                ' Make room for inserted row
                For tdx As Integer = len To idx + 1 Step -1
                    HQLookUpTable(tdx) = HQLookUpTable(tdx - 1)
                Next

                HQLookUpTable(idx) = newRow
                mSelectedRow = idx
                mSelectedCol = 0
            Else ' Table is empty; set new value
                HQLookUpTable(len) = newRow
                mSelectedRow = len
                mSelectedCol = 0
            End If

            Me.HQLookUpTable = HQLookUpTable

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub InsertRowButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles InsertRowButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Redo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                InsertRowButton.AddRedoItem(HQLookUpTable)
                ' Get Undo point's table
                HQLookUpTable = DirectCast(UndoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub InsertRowButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles InsertRowButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Undo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                InsertRowButton.AddUndoItem(HQLookUpTable)
                ' Get Redo point's table
                HQLookUpTable = DirectCast(RedoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#Region " Add Row Events "
    '*********************************************************************************************************
    ' Add Row button event handlers
    '*********************************************************************************************************
    Private Sub AddRowButton_Click(sender As Object, e As EventArgs) _
        Handles AddRowButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Get HQ Lookup Table from Flume
            Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
            Dim len As Integer = HQLookUpTable.Length

            ' Set current table as Undo point
            AddRowButton.AddUndoItem(HQLookUpTable)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Add a row to the end of the table
            Dim newRow As New HQLookupDataType With {
                .H = 0, .Q = 0,
                .HErased = False, .QErased = False}

            ReDim Preserve HQLookUpTable(len)
            HQLookUpTable(len) = newRow
            Me.HQLookUpTable = HQLookUpTable

            mSelectedRow = len
            mSelectedCol = 0

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub AddRowButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles AddRowButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Redo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                AddRowButton.AddRedoItem(HQLookUpTable)
                ' Get Undo point's table
                HQLookUpTable = DirectCast(UndoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub AddRowButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles AddRowButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Undo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                AddRowButton.AddUndoItem(HQLookUpTable)
                ' Get Redo point's table
                HQLookUpTable = DirectCast(RedoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#Region " Delete Row Events "

    '*********************************************************************************************************
    ' Delete Row button event handlers
    '*********************************************************************************************************
    Private Sub DeleteRowButton_Click(sender As Object, e As EventArgs) _
        Handles DeleteRowButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Get HQ Lookup Table from Flume
            Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
            Dim len As Integer = HQLookUpTable.Length

            If (len <= 0) Then ' there is nothing to delete
                Return
            End If

            ' Set current table as Undo point
            DeleteRowButton.AddUndoItem(HQLookUpTable)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Delete the selected table row
            If (LinearLookupTable.SelectedCells.Count > 0) Then
                HQLookUpTable = Me.HQLookUpTable ' re-get Flume table so UndoItem isn't modified
                Dim idx As Integer = LinearLookupTable.SelectedCells(0).RowIndex
                ' Set selection to 'erased'; HQLookUpTable set() will remove it
                HQLookUpTable(idx).HErased = True
                HQLookUpTable(idx).QErased = True
            End If

            Me.HQLookUpTable = HQLookUpTable

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub DeleteRowButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles DeleteRowButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Redo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                DeleteRowButton.AddRedoItem(HQLookUpTable)
                ' Get Undo point's table
                HQLookUpTable = DirectCast(UndoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub DeleteRowButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles DeleteRowButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Undo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                DeleteRowButton.AddUndoItem(HQLookUpTable)
                ' Get Redo point's table
                HQLookUpTable = DirectCast(RedoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#Region " Sort Table Events "

    '*********************************************************************************************************
    ' Sort Table button event handler
    '*********************************************************************************************************
    Private Sub SortTableButton_Click(sender As Object, e As EventArgs) _
        Handles SortTableButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Get HQ Lookup Table from Flume
            Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable

            ' Set current table as Undo point
            SortTableButton.AddUndoItem(HQLookUpTable)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Sort the table
            mFlume.SortLookupTable()

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub SortTableButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles SortTableButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Redo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                SortTableButton.AddRedoItem(HQLookUpTable)
                ' Get Undo point's table
                HQLookUpTable = DirectCast(UndoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub SortTableButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles SortTableButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(HQLookupDataType())) Then
                ' Set table Undo point
                Dim HQLookUpTable As HQLookupDataType() = Me.HQLookUpTable
                SortTableButton.AddUndoItem(HQLookUpTable)
                ' Get Redo point's table
                HQLookUpTable = DirectCast(RedoValue, HQLookupDataType())
                ' Restore HQ Lookup table
                Me.HQLookUpTable = HQLookUpTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#Region " Resize Events "

    '*********************************************************************************************************
    ' Resize contained controls to match new size
    '*********************************************************************************************************
    Private Sub BasisLinearLookControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize
        ResizeUI()
    End Sub

    Private Sub ResizeUI()
        Dim roomY As Integer = Me.Height - (Me.LinearLookupTable.ColumnHeadersHeight + Me.Margin.Vertical)
        roomY -= Me.LinearLookupTable.Rows.Count * 20

        If (Me.HelpLabel.Height < roomY) Then
            Me.HelpLabel.Show()
        Else
            Me.HelpLabel.Hide()
        End If
    End Sub

#End Region

#End Region

End Class
