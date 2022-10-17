
'*************************************************************************************************************
' Class ctl_RadioButton - UI control for displaying/editing a Radio Box
'*************************************************************************************************************
Public Class ctl_RadioButton

#Region " Properties "

    Protected mRbValue As Integer = -1
    Public Property RbValue() As Integer
        Get
            Return mRbValue
        End Get
        Set(ByVal value As Integer)
            mRbValue = value
        End Set
    End Property

    Protected mUiValue As Integer = -1
    Public Property UiValue() As Integer
        Get
            Return mUiValue
        End Get
        Set(ByVal value As Integer)
            mUiValue = value
            If (mUiValue = mRbValue) Then
                If (0 <= mUiValue) Then
                    If Not (Me.Checked) Then
                        Me.Checked = True
                    End If
                End If
            End If
        End Set
    End Property

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

    Public Sub Undo(ByVal ParentName As String, ByVal ControlName As String, ByVal UndoValue As Object)
        Debug.Assert(WinFlumeForm.InUndo, "Not in Undo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                If (UndoValue.GetType Is GetType(Integer)) Then
                    Dim value As Integer = DirectCast(UndoValue, Integer)
                    ' Add Redo item
                    Dim redoText As String = My.Resources.SelectChange & " - " & Me.Label
                    WinFlumeForm.AddRedoItem(ParentName, ControlName, redoText, mUiValue)
                    ' Load Undo value
                    Me.UiValue = value
                    Me.Focus() ' Track undo/redo
                    ' Let others respond to new value
                    RaiseValueChangedEvent(value)
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
                If (RedoValue.GetType Is GetType(Integer)) Then
                    Dim value As Integer = DirectCast(RedoValue, Integer)
                    ' Add Undo item
                    Dim undoText As String = My.Resources.SelectChange & " - " & Me.Label
                    WinFlumeForm.AddUndoItem(ParentName, ControlName, undoText, mUiValue)
                    ' Load Redo value
                    Me.UiValue = value
                    Me.Focus() ' Track undo/redo
                    ' Let others respond to new value
                    RaiseValueChangedEvent(value)
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
        If Not (mUiValue = mRbValue) Then
            ' Establish Undo point
            Dim undoText As String = My.Resources.SelectChange & " - " & Me.Label
            WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, mUiValue)
            WinFlumeForm.ClearRedoStack()
            ' Save new value
            mUiValue = mRbValue
            ' Let others respond to new value
            RaiseValueChangedEvent(mUiValue)
        End If
    End Sub

#End Region

#Region " UI Events & Handlers "

    Private Sub ctl_RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.CheckedChanged
        If (MyBase.Checked) Then ' Was unchecked; now checked
            'If (MyBase.ContainsFocus) Then
            SaveNewValue()
            'End If
        End If
    End Sub
    '
    ' Event to indicate value changed
    '
    Protected Sub RaiseValueChangedEvent(ByVal NewValue As Integer)
        RaiseEvent ValueChanged(NewValue)
    End Sub

    Public Event ValueChanged(ByVal NewValue As Integer)

#End Region

End Class
