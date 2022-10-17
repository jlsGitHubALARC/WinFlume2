
'*************************************************************************************************************
' Class ctl_Single - UI control for displaying/editing a Single value with NO Units
'*************************************************************************************************************
Public Class ctl_Single

#Region " Properties "

    Public Property SiDefaultValue() As Single = 0.0

    Protected mSiValue As Single = 0.0
    Public Property SiValue() As Single
        Get
            SiValue = mSiValue
        End Get
        Set(ByVal value As Single)
            mSiValue = value
            Me.UpdateUI()
        End Set
    End Property

    Public Property SiMin As Single = -Single.Epsilon

    Public Property UiValue() As Single
        Get
            UiValue = SiValue
        End Get
        Set(ByVal value As Single)
            SiValue = value
        End Set
    End Property

    Public Property FormatStyle As String = "0.0###"

    Protected mLabel As String = ""
    Public Property Label() As String
        Get
            Return mLabel
        End Get
        Set(ByVal value As String)
            mLabel = value
            While mLabel.Contains("&")
                Dim pos As Integer = mLabel.IndexOf("&")
                mLabel = mLabel.Remove(pos, 1)
            End While
        End Set
    End Property

    Protected mIsReadOnly As Boolean = False
    Public Property IsReadOnly As Boolean
        Get
            Return mIsReadOnly
        End Get
        Set(value As Boolean)
            mIsReadOnly = value
            Me.SingleText.ReadOnly = value
            UpdateUI()
        End Set
    End Property

    Public Property ReadOnlyMsgBox As Form = Nothing

    Public Property UndoEnabled As Boolean = True
    '
    ' Error message to display for invalid values
    '
    Protected mErrMsg As String = String.Empty

#End Region

#Region " Public SI Value Methods "

    Public Function SiValueText() As String
        SiValueText = Format(SiValue, FormatStyle)
    End Function

    Public Function SiLabelValueText() As String
        Return mLabel & " = " & SiValueText()
    End Function

#End Region

#Region " Public UI Value Methods "

    Public Function UiValueText() As String
        UiValueText = Format(UiValue, FormatStyle)
    End Function

    Public Sub UiValueText(ByVal UiText As String)
        Me.SingleText.Text = UiText
        SaveNewValue()
    End Sub

    Public Function UiLabelValueText() As String
        Return mLabel & " = " & UiValueText()
    End Function

    Public Sub SetError(ByVal ErrMsg As String)
        mErrMsg = ErrMsg
        ErrorProvider.SetError(SingleText, mErrMsg)
        UpdateUI()
    End Sub

#End Region

#Region " Public Undo/Redo Methods "

    Public Sub Undo(ByVal ParentName As String, ByVal ControlName As String, ByVal UndoValue As Object)
        Debug.Assert(WinFlumeForm.InUndo, "Not in Undo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                If (UndoValue.GetType Is GetType(Single)) Then
                    Dim siValue As Single = DirectCast(UndoValue, Single)
                    ' Add Redo item
                    Dim redoText As String = My.Resources.ValueChange & " - " & Me.Label
                    WinFlumeForm.AddRedoItem(ParentName, ControlName, redoText, mSiValue)
                    ' Load Undo value
                    Me.SiValue = siValue
                    Me.SingleText.Focus()      ' Select text to track undo/redo
                    Me.SingleText.SelectAll()
                    ' Let others respond to new value
                    RaiseValueChangedEvent()
                Else
                    Debug.Assert(False, "Undo - Invalid value type")
                End If
            Else
                Debug.Assert(False, "Undo - Invalid control name")
            End If
        Else
            Debug.Assert(False, "Undo - Invalid parent name")
        End If
    End Sub

    Public Sub Redo(ByVal ParentName As String, ByVal ControlName As String, ByVal RedoValue As Object)
        Debug.Assert(WinFlumeForm.InRedo, "Not in Redo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                If (RedoValue.GetType Is GetType(Single)) Then
                    Dim siValue As Single = DirectCast(RedoValue, Single)
                    ' Add Undo item
                    Dim undoText As String = My.Resources.ValueChange & " - " & Me.Label
                    WinFlumeForm.AddUndoItem(ParentName, ControlName, undoText, mSiValue)
                    ' Load Redo value
                    Me.SiValue = siValue
                    Me.SingleText.Focus()      ' Select text to track undo/redo
                    Me.SingleText.SelectAll()
                    ' Let others respond to new value
                    RaiseValueChangedEvent()
                Else
                    Debug.Assert(False, "Redo - Invalid value type")
                End If
            Else
                Debug.Assert(False, "Redo - Invalid control name")
            End If
        Else
            Debug.Assert(False, "Redo - Invalid parent name")
        End If
    End Sub

#End Region

#Region " Protected Methods "

    Protected Sub UpdateUI()

        Me.SingleText.Text = UiValueText()

        If (Me.IsReadOnly) Then
            Me.SingleText.BackColor = Color.LightBlue
        Else
            If (Me.SingleText.ReadOnly = False) Then
                If (SiValue = SiDefaultValue) Then
                    Me.SingleText.BackColor = SystemColors.Window
                Else
                    Me.SingleText.BackColor = Color.LightGreen
                End If
            Else '  Disabled (i.e. read-only)
                Me.SingleText.BackColor = Color.LightGray
            End If
        End If
    End Sub

    Protected Sub SaveNewValue()
        Try
            Dim uiText As String = UiValueText()        ' UI text to display from SI value
            If Not (uiText = Me.SingleText.Text) Then   ' Has it changed? Yes, save new value
                Dim uiValue As Single = Single.Parse(Me.SingleText.Text)
                Dim siValue As Single = uiValue

                If (SiMin < siValue) Then ' Validate minimum
                    If (UndoEnabled) Then ' Establish Undo point
                        Dim undoText As String = My.Resources.ValueChange & " - " & Me.Label
                        WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, mSiValue)
                        WinFlumeForm.ClearRedoStack()
                    End If
                    ' Save new value
                    Me.SiValue = siValue
                    ' Let others respond to new value
                    RaiseValueChangedEvent()
                Else ' less than minimum; reset to previous
                    Me.SiValue = mSiValue
                End If
            End If
        Catch ex As Exception
            Me.SiValue = mSiValue
        End Try
    End Sub

#End Region

#Region " UI Events & Handlers "
    '
    ' Absorb KeyPress for Return key to suppress beep
    '
    Protected Overridable Sub SingleText_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
    Handles SingleText.KeyPress
        ' Absorb KeyPress for Return key to suppress beep
        '   Note - setting e.Handled to True in KeyDown handler doesn't suppress beep
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(Windows.Forms.Keys.Return)) Then
            e.Handled = True
        End If
    End Sub
    '
    ' Return key enters new data value
    '
    Protected Overridable Sub SingleText_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
    Handles SingleText.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Return) Then
            SaveNewValue()
            SingleText.Focus()      ' Select text so the user can easily re-enter value
            SingleText.SelectAll()
        ElseIf (e.KeyCode = Windows.Forms.Keys.ControlKey) Then ' ignore 'Ctrl' key; start of Undo
        Else
            If (Me.ReadOnlyMsgBox IsNot Nothing) Then
                Me.ReadOnlyMsgBox.ShowDialog()
            End If
        End If
    End Sub
    '
    '    Leave & Lost Focus may enter new data value
    '
    Protected Overridable Sub Control_Leave(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Leave
        If Not (WinFlumeForm.InUndo Or WinFlumeForm.InRedo) Then
            SaveNewValue()
        End If
    End Sub

    Protected Overridable Sub Control_LostFocus(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.LostFocus
        If Not (WinFlumeForm.InUndo Or WinFlumeForm.InRedo) Then
            SaveNewValue()
        End If
    End Sub
    '
    ' On Mouse Down, display read-only meeeage, if there is one
    '
    Private Sub SingleText_MouseDown(sender As Object, e As MouseEventArgs) _
        Handles SingleText.MouseDown
        If (Me.ReadOnlyMsgBox IsNot Nothing) Then
            Me.ReadOnlyMsgBox.ShowDialog()
        End If
    End Sub
    '
    ' Textbox Copy / Paste
    '
    Private Sub TextboxContextMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) _
        Handles TextboxContextMenu.Opening
        If (SingleText.ReadOnly) Then
            Me.PasteToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CopyToolStripMenuItem.Click
        Me.SingleText.SelectAll()
        Me.SingleText.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PasteToolStripMenuItem.Click
        Me.SingleText.SelectAll()
        Me.SingleText.Paste()
        SaveNewValue()
        SingleText.Focus()      ' Select text so the user can easily re-enter value
        SingleText.SelectAll()
    End Sub
    '
    ' Event to indicate value may have changed
    '
    Protected Sub RaiseValueChangedEvent()
        RaiseEvent ValueChanged()
    End Sub

    Public Event ValueChanged()

#End Region

End Class
