
'*************************************************************************************************************
' Class ctl_TextBox - UI control for displaying/editing a Text Box
'*************************************************************************************************************
Public Class ctl_TextBox

#Region " Properties "
    '
    ' Text is TextBox
    '
    Protected mValue As String = ""
    Public Property Value() As String
        Get
            Return mValue
        End Get
        Set(ByVal value As String)
            mValue = value
            Me.Text = mValue
        End Set
    End Property
    '
    ' TextBox' property name
    '
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

#End Region

#Region " Public Undo/Redo Methods "

    Public Overloads Sub Undo(ByVal ParentName As String, ByVal ControlName As String, ByVal UndoValue As Object)
        Debug.Assert(WinFlumeForm.InUndo, "Not in Undo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                If (UndoValue.GetType Is GetType(String)) Then
                    Dim value As String = DirectCast(UndoValue, String)
                    ' Add Redo item
                    Dim redoText As String = My.Resources.TextChange & " - " & Me.Label
                    WinFlumeForm.AddRedoItem(ParentName, ControlName, redoText, mValue)
                    ' Load Undo value
                    Me.Value = value
                    Me.Focus() ' Track undo/redo
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
                If (RedoValue.GetType Is GetType(String)) Then
                    Dim value As String = DirectCast(RedoValue, String)
                    ' Add Undo item
                    Dim undoText As String = My.Resources.TextChange & " - " & Me.Label
                    WinFlumeForm.AddUndoItem(ParentName, ControlName, undoText, mValue)
                    ' Load Redo value
                    Me.Value = value
                    Me.Focus() ' Track undo/redo
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

    Protected Sub SaveNewValue()
        If Not (mValue = Me.Text.Trim) Then
            ' Establish Undo point
            Dim undoText As String = My.Resources.TextChange & " - " & Me.Label
            WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, mValue)
            WinFlumeForm.ClearRedoStack()
            ' Save new value
            mValue = Me.Text.Trim
            ' Let others respond to new value
            RaiseValueChangedEvent()
        End If
    End Sub

#End Region

#Region " UI Events & Handlers "

    Private Sub ctl_TextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) _
    Handles MyBase.KeyPress
        ' Absorb KepPress for Return key to suppress beep
        '   Note - setting e.Handled to True in KeyDown handler doesn't suppress beep
        If e.KeyChar = Chr(13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ctl_TextBox_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) _
    Handles MyBase.KeyDown
        ' Enter the new value when the Return key is pressed
        If (e.KeyCode = Windows.Forms.Keys.Return) Then
            SaveNewValue()
            Me.Focus()      ' Select text so the user can easily re-enter value
            Me.SelectAll()
        End If
    End Sub

    Private Sub ctl_TextBox_LostFocus(ByVal sender As System.Object, ByVal e As EventArgs) _
    Handles MyBase.LostFocus
        ' Enter the new value when focus is lost
        SaveNewValue()
    End Sub
    '
    ' Textbox Copy / Paste
    '
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CopyToolStripMenuItem.Click
        Me.SelectAll()
        Me.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PasteToolStripMenuItem.Click
        Me.SelectAll()
        Me.Paste()
        SaveNewValue()
        Me.Focus()      ' Select text so the user can easily re-enter value
        Me.SelectAll()
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