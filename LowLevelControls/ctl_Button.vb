
'*************************************************************************************************************
' Class ctl_Button - UI control for a Button
'*************************************************************************************************************
Public Class ctl_Button

#Region " Public Undo/Redo Methods "

    Public Sub AddUndoItem(ByVal UndoValue As Object)
        ' Establish Undo point
        Dim undoText As String = My.Resources.Button & " - " & Me.Text
        WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, UndoValue)
    End Sub

    Public Sub Undo(ByVal ParentName As String, ByVal ControlName As String, ByVal UndoValue As Object)
        Debug.Assert(WinFlumeForm.InUndo, "Not in Undo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                RaiseUndoButtonEvent(UndoValue) ' Since UndoValue is unknown here, let others handle Undo
            Else
                Debug.Assert(False, "Undo - Invalid control name")
            End If
        Else
            Debug.Assert(False, "Undo - Invalid parent name")
        End If
    End Sub

    Public Sub AddRedoItem(ByVal RedoValue As Object)
        ' Establish Redo point
        Dim redoText As String = My.Resources.Button & " - " & Me.Text
        WinFlumeForm.AddRedoItem(Me.Parent.Name, Me.Name, redoText, RedoValue)
    End Sub

    Public Sub Redo(ByVal ParentName As String, ByVal ControlName As String, ByVal RedoValue As Object)
        Debug.Assert(WinFlumeForm.InRedo, "Not in Redo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                RaiseRedoButtonEvent(RedoValue) ' Since RedoValue is unknown here, let others handle Redo
            Else
                Debug.Assert(False, "Redo - Invalid control name")
            End If
        Else
            Debug.Assert(False, "Redo - Invalid parent name")
        End If
    End Sub

#End Region

#Region " UI Events & Handlers "
    '
    ' Event to indicate value may have changed
    '
    Protected Sub RaiseUndoButtonEvent(ByVal UndoValue As Object)
        RaiseEvent UndoButtonEvent(UndoValue)
    End Sub

    Protected Sub RaiseRedoButtonEvent(ByVal RedoValue As Object)
        RaiseEvent RedoButtonEvent(RedoValue)
    End Sub

    Public Event UndoButtonEvent(ByVal UndoValue As Object)
    Public Event RedoButtonEvent(ByVal RedoValue As Object)

#End Region

End Class
