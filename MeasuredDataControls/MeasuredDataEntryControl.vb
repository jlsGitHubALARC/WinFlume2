
'*************************************************************************************************************
' Class MeasuredDataEntryControl - UserControl for displaying & editing the flume measured data
'*************************************************************************************************************
Imports Flume                   ' Flume data
Imports WinFlume.UnitsDialog    ' Unit conversion support

Public Class MeasuredDataEntryControl

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
    ' Measured Data table
    '
    Private mSelectedRow As Integer = 0
    Private mSelectedCol As Integer = 0
    '
    ' Rating Table Choices data
    '
    Private Const ClearAllRatingParameters As Integer = 262147   ' Bits 18, 2 & 1 are always selected
    Private Const SelectAllRatingParameters As Integer = 524287

#End Region

#Region " Properties "

    Public Class TableChoice
        Public Rating As Flume.RatingResultsEnum
        Public Name As String
        Public Symbol As String
        Public SiUnits As String
        Public Selected As Boolean

        Public Sub New(ByVal Rating As Flume.RatingResultsEnum, ByVal Name As String, ByVal Symbol As String,
                       ByVal SiUnits As String, ByVal Selected As Boolean)
            Me.Rating = Rating
            Me.Name = Name
            Me.Symbol = Symbol
            Me.SiUnits = SiUnits
            Me.Selected = Selected
        End Sub

        Public Sub New(ByVal tblChoice As TableChoice)
            With tblChoice
                Me.Rating = .Rating
                Me.Name = .Name
                Me.Symbol = .Symbol
                Me.SiUnits = .SiUnits
                Me.Selected = .Selected
            End With
        End Sub

    End Class

    Private mTableChoices As List(Of TableChoice) = Nothing
    Public ReadOnly Property TableChoices() As List(Of TableChoice)
        Get
            Dim ratingParameters As Integer = WinFlumeForm.MeasuredParametersToShow
            Me.RebuildTableChoicesList(ratingParameters)
            Return mTableChoices
        End Get
    End Property

    Public ReadOnly Property NumberOfTableChoices() As Integer
        Get
            NumberOfTableChoices = 0
            If (mTableChoices IsNot Nothing) Then
                For Each choice As TableChoice In mTableChoices
                    If (choice.Selected) Then
                        NumberOfTableChoices += 1
                    End If
                Next choice
            End If
        End Get
    End Property

#End Region

#Region " Data Methods "

    Private Sub RebuildTableChoicesList(ByVal MeasuredParametersToShow As Integer)

        Dim value As Flume.RatingResultsEnum
        Dim name, symbol, siUnits As String
        Dim selected As Boolean

        mTableChoices = New List(Of TableChoice)

        value = RatingResultsEnum.SMALLh1
        name = My.Resources.HeadAtGage
        symbol = "h1"
        siUnits = "m"
        selected = True
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Q
        name = My.Resources.Discharge
        symbol = "Q"
        siUnits = "m³/s"
        selected = True
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Froude
        name = Me.FroudeNumberCheckBox.Text
        symbol = SymbolFromLabel(Me.FrLabel.Text)
        siUnits = ""
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(FroudeNumberCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.ReqEnergyLoss
        name = Me.RequiredHeadLossCheckBox.Text
        symbol = SymbolFromLabel(Me.H1H2Label.Text)
        siUnits = "m"
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(RequiredHeadLossCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.HLRatio
        name = Me.HeadToCrestLengthRatioCheckBox.Text
        symbol = SymbolFromLabel(Me.H1LLabel.Text)
        siUnits = ""
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(HeadToCrestLengthRatioCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.H1
        name = Me.UpstreamEnergyHeadCheckBox.Text
        symbol = SymbolFromLabel(Me.H1Label.Text)
        siUnits = "m"
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(UpstreamEnergyHeadCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.y1
        name = Me.UpstreamDepthCheckBox.Text
        symbol = SymbolFromLabel(Me.y1Label.Text)
        siUnits = "m"
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(UpstreamDepthCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.V1
        name = Me.UpstreamVelocityCheckBox.Text
        symbol = SymbolFromLabel(Me.VaLabel.Text)
        siUnits = "m/s"
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(UpstreamVelocityCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Cd
        name = Me.DischargeCoefficientCheckBox.Text
        symbol = SymbolFromLabel(Me.CdLabel.Text)
        siUnits = ""
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(DischargeCoefficientCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Cv
        name = Me.VelocityCoefficientCheckBox.Text
        symbol = SymbolFromLabel(Me.CvLabel.Text)
        siUnits = ""
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(VelocityCoefficientCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.MaxTailwater
        name = Me.MaxAllowableTailwaterHeadCheckBox.Text
        symbol = SymbolFromLabel(Me.h2Label1.Text)
        siUnits = "m"
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(MaxAllowableTailwaterHeadCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.smallh2
        name = Me.ActualTailwaterHeadCheckBox.Text
        symbol = SymbolFromLabel(Me.h2Label2.Text)
        siUnits = "m"
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(ActualTailwaterHeadCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.ActualTailwaterDepth
        name = Me.ActualTailwaterDepthCheckBox.Text
        symbol = SymbolFromLabel(Me.y2Label.Text)
        siUnits = "m"
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(ActualTailwaterDepthCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Submergence
        name = Me.SubmergenceRatioCheckBox.Text
        symbol = SymbolFromLabel(Me.H2H1Label.Text)
        siUnits = ""
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(SubmergenceRatioCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.ModularLimit
        name = Me.ModularLimitCheckBox.Text
        symbol = ""
        siUnits = ""
        selected = 0 < (MeasuredParametersToShow And 1 << CInt(ModularLimitCheckBox.Tag))
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

        value = RatingResultsEnum.Errors
        name = My.Resources.Warnings
        symbol = ""
        siUnits = ""
        selected = True
        mTableChoices.Add(New TableChoice(value, name, symbol, siUnits, selected))

    End Sub

    Private Function SymbolFromLabel(ByVal Label As String) As String
        SymbolFromLabel = Label
        If (Label(0) = "(") Then
            Dim closed As Integer = Label.IndexOf(")")
            If (closed > 0) Then
                SymbolFromLabel = Label.Substring(1, closed - 1)
            End If
        End If
    End Function

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

            Me.MeasuredDataTable.ReadOnly = False
            Me.MeasuredDataTable.Columns(0).HeaderText = My.Resources.Head _
            & vbCrLf & "(" & UiLunits & ")"
            Me.MeasuredDataTable.Columns(1).HeaderText = My.Resources.Discharge _
            & vbCrLf & "(" & UiQunits & ")"

            Me.MeasuredDataTable.Rows.Clear()

            Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
            If (measDataTable IsNot Nothing) Then
                Dim rowString(1) As String
                For Each HQ As MeasuredDataType In measDataTable
                    With HQ
                        If (0 <= .Head) Then
                            rowString(0) = UiValueText(.Head, SiLunits)
                        Else
                            rowString(0) = "0"
                        End If

                        If (0 <= .Flow) Then
                            rowString(1) = UiValueText(.Flow, SiQunits)
                        Else
                            rowString(1) = "0"
                        End If
                    End With

                    Me.MeasuredDataTable.Rows.Add(rowString)
                Next HQ
            End If

            If (mSelectedRow < 0) Then
                mSelectedRow = 0
            End If

            If (mSelectedRow > Me.MeasuredDataTable.Rows.Count - 1) Then
                mSelectedRow = Me.MeasuredDataTable.Rows.Count - 1
            End If

            If ((0 <= mSelectedRow) And (mSelectedRow < Me.MeasuredDataTable.Rows.Count)) Then
                Dim selected As DataGridViewCell = Me.MeasuredDataTable.Rows(mSelectedRow).Cells(mSelectedCol)
                Me.MeasuredDataTable.CurrentCell = selected
                Me.MeasuredDataTable.Select()
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        ' Update Rating Table Parameter selections
        Dim MeasuredParametersToShow As Integer = WinFlumeForm.MeasuredParametersToShow

        For Each ctrl As Control In RatingTableParametersBox.Controls
            If (ctrl.GetType Is GetType(ctl_CheckBox)) Then
                Dim checkBox As ctl_CheckBox = DirectCast(ctrl, ctl_CheckBox)
                Dim checkTag As Integer = CInt(checkBox.Tag)
                Dim checkBit As Integer = 1 << checkTag
                Dim selected As Integer = MeasuredParametersToShow And checkBit

                If (selected = 0) Then
                    checkBox.Value = False
                Else
                    checkBox.Value = True
                End If
            End If
        Next ctrl

        Me.RebuildTableChoicesList(MeasuredParametersToShow)

        mUpdatingUI = False
    End Sub

#End Region

#Region " Event Handlers "

#Region " Edit Table Events "

    '*********************************************************************************************************
    ' Measured Data table change events
    '*********************************************************************************************************
    Private Sub MeasuredDataTable_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
        Handles MeasuredDataTable.CellValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Ignore event while updating UI
            If (mUpdatingUI) Then
                Return
            End If

            ' Get Measured Data Table from Flume
            Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
            If (measDataTable Is Nothing) Then
                Debug.Assert(False)
                Return
            End If

            Dim len As Integer = measDataTable.Length
            If (len <= 0) Then ' nothing to change
                Return
            End If

            ' Set current table as Undo point
            MeasuredDataTable.AddUndoItem(measDataTable)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in change handler only

            ' Get updated table from the UI
            Dim rowCount As Integer = MeasuredDataTable.Rows.Count
            Dim UItable(rowCount - 1) As MeasuredDataType

            Debug.Assert(len = rowCount)

            Dim Qunits As DischargeUnits = UiDischargeUnits
            Dim Hunits As LengthUnits = UiLengthUnits

            For rdx As Integer = 0 To rowCount - 1
                Dim HQflume As MeasuredDataType = measDataTable(rdx)
                Dim HQrow As DataGridViewRow = Me.MeasuredDataTable.Rows(rdx)

                Dim Hsi As Single = HQflume.Head
                Try ' Single.Parse may fail if non-numeric text in Cell
                    Dim Hcell As DataGridViewCell = HQrow.Cells(0)
                    Dim Hui As Single = Single.Parse(CStr(Hcell.Value))
                    Hsi = SiLengthValue(Hui, Hunits)
                Catch ex As Exception
                    mSelectedRow = rdx
                    mSelectedCol = 0
                End Try

                Dim Qsi As Single = HQflume.Flow
                Try ' Single.Parse may fail if non-numeric text in Cell
                    Dim Qcell As DataGridViewCell = HQrow.Cells(1)
                    Dim Qui As Single = Single.Parse(CStr(Qcell.Value))
                    Qsi = SiDischargeValue(Qui, Qunits)
                Catch ex As Exception
                    mSelectedRow = rdx
                    mSelectedCol = 1
                End Try

                Dim HQui As MeasuredDataType = New MeasuredDataType With {
                    .Flow = Qsi, .Head = Hsi}

                UItable(rdx) = HQui
            Next

            mFlume.MeasuredData = UItable

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub MeasuredDataTable_UndoTableEvent(ByVal UndoValue As Object) _
        Handles MeasuredDataTable.UndoTableEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Redo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                MeasuredDataTable.AddRedoItem(measDataTable)
                ' Get Undo point's table
                measDataTable = DirectCast(UndoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub MeasuredDataTable_RedoTableEvent(ByVal RedoValue As Object) _
        Handles MeasuredDataTable.RedoTableEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Undo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                MeasuredDataTable.AddUndoItem(measDataTable)
                ' Get Redo point's table
                measDataTable = DirectCast(RedoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub MeasuredDataTable_PasteTableEvent() _
        Handles MeasuredDataTable.PasteTableEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Try
                ' Get/validate paste table from clipboard
                Dim pasteRows As String() = MeasuredDataTable.ClipboardRows
                Dim pasteColHdrs As String() = MeasuredDataTable.ClipboardColHeaders
                Dim pasteColUnits As String() = MeasuredDataTable.ClipboardColUnits

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

                Debug.Assert(col1SiUnits = LengthUnitsAbbreviations(0))
                Debug.Assert(col2SiUnits = DischargeUnitsAbbreviations(0))

                ' Get HQ Lookup Table from Flume
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData

                ' Set current table as Undo point
                MeasuredDataTable.AddUndoItem(measDataTable, My.Resources.Paste)
                WinFlumeForm.ClearRedoStack() ' Clear Redo stack in change handler only

                ' Build new Measure Data Table from paste data
                ReDim measDataTable(pasteRows.Length - 1)

                For tdx As Integer = 0 To pasteRows.Length - 1
                    Dim pasteRow As String = pasteRows(tdx)
                    Dim colVals As String() = pasteRow.Split(vbTab.ToCharArray)

                    Dim pasteLength As Single = Single.Parse(colVals(0))
                    Dim pasteDischarge As Single = Single.Parse(colVals(1))

                    Dim siLength As Single = SiValue(pasteLength, pasteColUnits(0))
                    Dim siDischarge As Single = SiValue(pasteDischarge, pasteColUnits(1))

                    Dim measData As MeasuredDataType = New MeasuredDataType With {
                        .Head = siLength,
                        .Flow = siDischarge
                    }

                    measDataTable(tdx) = measData
                Next tdx

                mFlume.MeasuredData = measDataTable

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
            Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
            If (measDataTable Is Nothing) Then
                ' Instantiate new table with one row
                ReDim measDataTable(0)

                Dim newRow As New MeasuredDataType With {.Head = 0, .Flow = 0}

                measDataTable(0) = newRow
                mSelectedRow = 0
                mSelectedCol = 0
            Else
                Dim len As Integer = measDataTable.Length

                ' Set current table as Undo point
                InsertRowButton.AddUndoItem(measDataTable)
                WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

                ' Reallocate the Measured Data table one entry larger
                ReDim Preserve measDataTable(len) ' changes apply to reallocated data

                ' Insert a row before the selected table row
                Dim newRow As New MeasuredDataType With {.Head = 0, .Flow = 0}

                If (MeasuredDataTable.SelectedCells.Count > 0) Then
                    Dim idx As Integer = MeasuredDataTable.SelectedCells(0).RowIndex

                    ' Make room for inserted row
                    For tdx As Integer = len To idx + 1 Step -1
                        measDataTable(tdx) = measDataTable(tdx - 1)
                    Next

                    measDataTable(idx) = newRow
                    mSelectedRow = idx
                    mSelectedCol = 0
                Else ' Table is empty; set new value
                    measDataTable(len) = newRow
                    mSelectedRow = len
                    mSelectedCol = 0
                End If
            End If

            mFlume.MeasuredData = measDataTable

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub InsertRowButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles InsertRowButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Redo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                InsertRowButton.AddRedoItem(measDataTable)
                ' Get Undo point's table
                measDataTable = DirectCast(UndoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub InsertRowButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles InsertRowButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Undo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                InsertRowButton.AddUndoItem(measDataTable)
                ' Get Redo point's table
                measDataTable = DirectCast(RedoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
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
            Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
            If (measDataTable Is Nothing) Then
                ' Instantiate new table with one row
                ReDim measDataTable(0)

                Dim newRow As New MeasuredDataType With {.Head = 0, .Flow = 0}

                measDataTable(0) = newRow
                mSelectedRow = 0
                mSelectedCol = 0
            Else
                Dim len As Integer = measDataTable.Length

                ' Set current table as Undo point
                AddRowButton.AddUndoItem(measDataTable)
                WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

                ' Reallocate the Measured Data table one entry larger
                ReDim Preserve measDataTable(len) ' changes apply to reallocated data

                ' Add a row to the end of the table
                Dim newRow As New MeasuredDataType With {.Head = 0, .Flow = 0}

                measDataTable(len) = newRow
                mSelectedRow = len
                mSelectedCol = 0
            End If

            mFlume.MeasuredData = measDataTable

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub AddRowButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles AddRowButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Redo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                AddRowButton.AddRedoItem(measDataTable)
                ' Get Undo point's table
                measDataTable = DirectCast(UndoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub AddRowButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles AddRowButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Undo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                AddRowButton.AddUndoItem(measDataTable)
                ' Get Redo point's table
                measDataTable = DirectCast(RedoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
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
            Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
            If (measDataTable Is Nothing) Then
                Return
            End If

            Dim len As Integer = measDataTable.Length

            If (len <= 0) Then ' there is nothing to delete
                Return
            End If

            ' Set current table as Undo point
            DeleteRowButton.AddUndoItem(measDataTable)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Delete the selected table row
            If (MeasuredDataTable.SelectedCells.Count > 0) Then
                Dim idx As Integer = MeasuredDataTable.SelectedCells(0).RowIndex
                Dim measDataList As List(Of MeasuredDataType) = measDataTable.ToList
                measDataList.RemoveAt(idx)
                measDataTable = measDataList.ToArray
            End If

            mFlume.MeasuredData = measDataTable

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub DeleteRowButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles DeleteRowButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Redo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                DeleteRowButton.AddRedoItem(measDataTable)
                ' Get Undo point's table
                measDataTable = DirectCast(UndoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub DeleteRowButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles DeleteRowButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Undo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                DeleteRowButton.AddUndoItem(measDataTable)
                ' Get Redo point's table
                measDataTable = DirectCast(RedoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
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
            Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
            If (measDataTable Is Nothing) Then
                Return
            End If

            Dim len As Integer = measDataTable.Length
            If (len <= 0) Then ' there is nothing to sort
                Return
            End If

            ' Set current table as Undo point
            SortTableButton.AddUndoItem(measDataTable)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Reallocate the Measured Data table at the same size
            ReDim Preserve measDataTable(len - 1) ' changes apply to reallocated data

            ' Sort the table
            MeasuredDataType.SortHQData(measDataTable)
            mFlume.MeasuredData = measDataTable

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub SortTableButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles SortTableButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Redo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                SortTableButton.AddRedoItem(measDataTable)
                ' Get Undo point's table
                measDataTable = DirectCast(UndoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub SortTableButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles SortTableButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(MeasuredDataType())) Then
                ' Set table Undo point
                Dim measDataTable As MeasuredDataType() = mFlume.MeasuredData
                SortTableButton.AddUndoItem(measDataTable)
                ' Get Redo point's table
                measDataTable = DirectCast(RedoValue, MeasuredDataType())
                ' Restore HQ Lookup table
                mFlume.MeasuredData = measDataTable
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#Region " Rating Table Events "

    '*********************************************************************************************************
    ' Rating Table parameter selections
    '*********************************************************************************************************
    Private Sub UpdateRatingTableParameters()
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim RatingTableParameters As Integer = ClearAllRatingParameters ' Bits 15, 2 & 1 are always selected

            For Each ctrl As Control In RatingTableParametersBox.Controls
                If (ctrl.GetType Is GetType(ctl_CheckBox)) Then
                    Dim checkBox As ctl_CheckBox = DirectCast(ctrl, ctl_CheckBox)
                    If (checkBox.Checked) Then
                        Dim checkTag As Integer = CInt(checkBox.Tag)
                        Dim checkBit As Integer = 1 << checkTag
                        RatingTableParameters += checkBit
                    End If
                End If
            Next ctrl

            WinFlumeForm.MeasuredParametersToShow = RatingTableParameters
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub FroudeNumberCheckBox_ValueChanged() Handles FroudeNumberCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub RequiredHeadLossCheckBox_ValueChanged() Handles RequiredHeadLossCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub HeadToCrestLengthRatioCheckBox_ValueChanged() Handles HeadToCrestLengthRatioCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub UpstreamEnergyHeadCheckBox_ValueChanged() Handles UpstreamEnergyHeadCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub UpstreamDepthCheckBox_ValueChanged() Handles UpstreamDepthCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub UpstreamVelocityCheckBox_ValueChanged() Handles UpstreamVelocityCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub DischargeCoefficientCheckBox_ValueChanged() Handles DischargeCoefficientCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub VelocityCoefficientCheckBox_ValueChanged() Handles VelocityCoefficientCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub MaxAllowableTailwaterHeadCheckBox_ValueChanged() Handles MaxAllowableTailwaterHeadCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub ActualTailwaterHeadCheckBox_ValueChanged() Handles ActualTailwaterHeadCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub ActualTailwaterDepthCheckBox_ValueChanged() Handles ActualTailwaterDepthCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub SubmergenceRatioCheckBox_ValueChanged() Handles SubmergenceRatioCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    Private Sub ModularLimitCheckBox_ValueChanged() Handles ModularLimitCheckBox.ValueChanged
        UpdateRatingTableParameters()
    End Sub

    '*********************************************************************************************************
    ' Button event handlers - Click, UndoButtonEvent, RedoButtonEvent
    '
    ' Note - Undo/Redo handling is specific to each Button since the action taken is not known to ctl_Button.
    '*********************************************************************************************************
    Private Sub SelectAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SelectAllButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Set current selections as Undo point
            Dim RatingTableParameters As Integer = WinFlumeForm.MeasuredParametersToShow
            SelectAllButton.AddUndoItem(RatingTableParameters)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
            ' Select all rating table parameters
            WinFlumeForm.MeasuredParametersToShow = SelectAllRatingParameters
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub SelectAllButton_UndoButtonEvent(ByVal UndoValue As Object) _
    Handles SelectAllButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(Integer)) Then
                ' Set selections for Redo point
                Dim RatingTableParameters As Integer = WinFlumeForm.MeasuredParametersToShow
                SelectAllButton.AddRedoItem(RatingTableParameters)
                ' Get Undo point's selections
                RatingTableParameters = CInt(UndoValue)
                ' Restore Undo rating table parameters
                WinFlumeForm.MeasuredParametersToShow = RatingTableParameters
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub SelectAllButton_RedoButtonEvent(ByVal RedoValue As Object) _
    Handles SelectAllButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(Integer)) Then
                ' Set selections for Undo point
                Dim RatingTableParameters As Integer = WinFlumeForm.MeasuredParametersToShow
                SelectAllButton.AddUndoItem(RatingTableParameters)
                ' Get Undo point's selections
                RatingTableParameters = CInt(RedoValue)
                ' Restore slect all rating table parameters
                WinFlumeForm.MeasuredParametersToShow = RatingTableParameters
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub ClearAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ClearAllButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Set current selections as Undo point
            Dim RatingTableParameters As Integer = WinFlumeForm.MeasuredParametersToShow
            ClearAllButton.AddUndoItem(RatingTableParameters)
            WinFlumeForm.ClearRedoStack()
            ' Clear all rating table parameters
            WinFlumeForm.MeasuredParametersToShow = ClearAllRatingParameters
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub ClearAllButton_UndoButtonEvent(ByVal UndoValue As Object) _
    Handles ClearAllButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(Integer)) Then
                ' Set selections for Redo point
                Dim RatingTableParameters As Integer = WinFlumeForm.MeasuredParametersToShow
                ClearAllButton.AddRedoItem(RatingTableParameters)
                ' Get Undo point's selections
                RatingTableParameters = CInt(UndoValue)
                ' Restore Undo rating table parameters
                WinFlumeForm.MeasuredParametersToShow = RatingTableParameters
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub ClearAllButton_RedoButtonEvent(ByVal RedoValue As Object) _
    Handles ClearAllButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(Integer)) Then
                ' Set selections for Undo point
                Dim RatingTableParameters As Integer = WinFlumeForm.MeasuredParametersToShow
                ClearAllButton.AddUndoItem(RatingTableParameters)
                ' Get Undo point's selections
                RatingTableParameters = CInt(RedoValue)
                ' Restore slect all rating table parameters
                WinFlumeForm.MeasuredParametersToShow = RatingTableParameters
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#Region " Resize Events "

    '*********************************************************************************************************
    ' Sub MyBase_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub MyBase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize

        Dim loc As Point = Me.Location
        Dim siz As Size = Me.Size

        loc = Me.RatingTableParametersBox.Location
        loc.X = Me.Width - Me.RatingTableParametersBox.Width - Me.Margin.Horizontal
        siz = Me.RatingTableParametersBox.Size
        siz.Height = Me.Height - Me.Margin.Vertical
        Me.RatingTableParametersBox.Location = loc
        Me.RatingTableParametersBox.Size = siz

        siz = Me.MeasuredDataBox.Size
        siz.Width = Me.Width - Me.RatingTableParametersBox.Width - 3 * Me.Margin.Horizontal
        siz.Height = Me.Height - Me.Margin.Vertical
        Me.MeasuredDataBox.Size = siz

    End Sub

#End Region

#Region " Measured Data Events "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub TableChoicesControl_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

#End Region

End Class
