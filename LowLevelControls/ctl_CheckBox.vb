
'*************************************************************************************************************
' Class ctl_CheckBox - UI control for displaying/editing a Check Box
'*************************************************************************************************************
Public Class ctl_CheckBox

#Region " Properties "
    '
    ' The Value (Boolean) of the Check Box
    '
    Protected mValue As Boolean = False
    Public Property Value() As Boolean
        Get
            Return mValue
        End Get
        Set(ByVal value As Boolean)
            mValue = value
            Me.Checked = mValue
        End Set
    End Property
    '
    ' Whether or not the CheckedChanged event should be handled by ctl_CheckBox.
    '   True    - event handled by ctl_CheckBox
    '   False   - event handled elsewhere; used when more than a true/false state change occurs
    '
    Public Property HandleCheckedChanged As Boolean = True

    Public Property UndoEnabled As Boolean = True

#End Region

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
                If (UndoValue.GetType Is GetType(Boolean)) Then
                    Dim value As Boolean = DirectCast(UndoValue, Boolean)
                    ' Add Redo item
                    Dim redoText As String = My.Resources.CheckChange & " - " & Me.Text
                    WinFlumeForm.AddRedoItem(ParentName, ControlName, redoText, mValue)
                    ' Load Undo value
                    Me.Value = value
                    Me.Focus() ' Track undo/redo
                    ' Let others respond to new value
                    RaiseValueChangedEvent()
                Else
                    RaiseUndoButtonEvent(UndoValue) ' UndoValue type is unknown, Undo is handled elsewhere
                End If
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
                If (RedoValue.GetType Is GetType(Boolean)) Then
                    Dim value As Boolean = DirectCast(RedoValue, Boolean)
                    ' Add Undo item
                    Dim undoText As String = My.Resources.CheckChange & " - " & Me.Text
                    WinFlumeForm.AddUndoItem(ParentName, ControlName, undoText, mValue)
                    ' Load Redo value
                    Me.Value = value
                    Me.Focus() ' Track undo/redo
                    ' Let others respond to new value
                    RaiseValueChangedEvent()
                Else
                    RaiseRedoButtonEvent(RedoValue) ' RedoValue type is unknown, Redo is handled elsewhere
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
        If Not (mValue = Me.Checked) Then ' Value has changed
            If (UndoEnabled) Then ' Establish Undo point
                Dim undoText As String = My.Resources.CheckChange & " - " & Me.Text
                WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, mValue)
                WinFlumeForm.ClearRedoStack()
            End If
            ' Save new value
            mValue = Me.Checked
            ' Let others respond to new value
            RaiseValueChangedEvent()
        End If
    End Sub

#End Region

#Region " UI Events & Handlers "

    Private Sub ctl_CheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.CheckedChanged
        If (MyBase.ContainsFocus) Then
            If (HandleCheckedChanged) Then
                SaveNewValue()
            End If
        End If
    End Sub
    '
    ' Events to indicate value may have changed
    '
    Protected Sub RaiseValueChangedEvent()
        RaiseEvent ValueChanged()
    End Sub

    Public Event ValueChanged()
    '
    ' Events to indicate Undo/Redo action required
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
