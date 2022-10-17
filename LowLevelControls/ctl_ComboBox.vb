
'*************************************************************************************************************
' Class ctl_ComboBox - UI control for displaying/editing a Combo Box
'*************************************************************************************************************
Public Class ctl_ComboBox

#Region " Properties "

    Public Property DefaultValue() As Integer = 0

    Protected mValue As Integer = -1
    Public Property Value() As Integer
        Get
            Return mValue
        End Get
        Set(ByVal value As Integer)
            If ((-1 < value) And (value < Me.Items.Count)) Then
                mValue = value
                Me.SelectedIndex = mValue

                If (1 = Me.Items.Count) Then
                    Me.BackColor = Color.LightBlue
                Else
                    If (mValue = DefaultValue) Then
                        Me.BackColor = SystemColors.Window
                    Else
                        Me.BackColor = Color.LightGreen
                    End If
                End If
            End If
        End Set
    End Property

    Public Property UndoEnabled As Boolean = True

#End Region

#Region " Public Undo/Redo Methods "

    Public Sub Undo(ByVal ParentName As String, ByVal ControlName As String, ByVal UndoValue As Object)
        Debug.Assert(WinFlumeForm.InUndo, "Not in Undo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                If (UndoValue.GetType Is GetType(Integer)) Then
                    Dim value As Integer = DirectCast(UndoValue, Integer)
                    ' Add Redo item
                    Dim redoText As String = My.Resources.SelectChange & " - " & Me.Text
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
                If (RedoValue.GetType Is GetType(Integer)) Then
                    Dim value As Integer = DirectCast(RedoValue, Integer)
                    ' Add Undo item
                    Dim undoText As String = My.Resources.SelectChange & " - " & CStr(Me.Items(value))
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

#Region " Methods "

    Protected Sub SaveNewValue()
        If Not (mValue = Me.SelectedIndex) Then
            SaveNewValue(Me.SelectedIndex)
        End If
    End Sub

    Friend Sub SaveNewValue(ByVal NewIndex As Integer)
        If (UndoEnabled) Then ' Establish Undo point
            Dim undoText As String = My.Resources.SelectChange & " - " & Me.Text
            WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, mValue)
            WinFlumeForm.ClearRedoStack()
        End If
        ' Save new value
        mValue = NewIndex
        ' Let others respond to new value
        RaiseValueChangedEvent()
    End Sub

#End Region

#Region " UI Events & Handlers "

    Private Sub ctl_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.SelectedIndexChanged
        If (MyBase.ContainsFocus) Then
            SaveNewValue()
        End If
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
