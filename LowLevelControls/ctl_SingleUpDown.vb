
'*************************************************************************************************************
' Class ctl_SingleUpDown - UI control with up/down arrows for displaying/editing a Single value with NO Units
'*************************************************************************************************************
Public Class ctl_SingleUpDown
    Inherits NumericUpDown

#Region " Properties "

    Protected mSiValue As Single = 0.0
    Public Property SiValue() As Single
        Get
            SiValue = mSiValue
        End Get
        Set(ByVal value As Single)
            mSiValue = value
            MyBase.Value = CDec(mSiValue)
        End Set
    End Property

    Public Property UiValue() As Single
        Get
            UiValue = SiValue
        End Get
        Set(ByVal value As Single)
            SiValue = value
        End Set
    End Property

    Protected mFormatStyle As String = "0.0###"
    Public Property FormatStyle() As String
        Get
            Return mFormatStyle
        End Get
        Set(ByVal value As String)
            mFormatStyle = value
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

    Public Property UndoEnabled As Boolean = True

#End Region

#Region " Public SI Value Methods "

    Public Function SiValueText() As String
        SiValueText = Format(SiValue, mFormatStyle)
    End Function

    Public Function SiLabelValueText() As String
        Return mLabel & " = " & SiValueText()
    End Function

#End Region

#Region " Public UI Value Methods "

    Public Function UiValueText() As String
        UiValueText = Format(UiValue, mFormatStyle)
    End Function

    Public Function UiLabelValueText() As String
        Return mLabel & " = " & UiValueText()
    End Function

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
        Try
            If (Me.SiValue <> MyBase.Value) Then
                If (UndoEnabled) Then ' Establish Undo point
                    Dim undoText As String = My.Resources.ValueChange & " - " & Me.Label
                    WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, mSiValue)
                    WinFlumeForm.ClearRedoStack()
                End If
                ' Save new value
                Me.SiValue = MyBase.Value
                ' Let others respond to new value
                RaiseValueChangedEvent()
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
    Private Sub MyBase_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
        Handles MyBase.KeyPress
        ' Absorb KeyPress for Return key to suppress beep
        '   Note - setting e.Handled to True in KeyDown handler doesn't suppress beep
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(Windows.Forms.Keys.Return)) Then
            e.Handled = True
            e.KeyChar = Chr(Keys.D2)
        End If
    End Sub
    '
    ' Return key enters new data value
    '
    'Private Sub MyBase_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
    '    Handles MyBase.KeyDown
    '    If (e.KeyCode = Windows.Forms.Keys.Return) Then
    '        SaveNewValue()
    '        MyBase.Focus()
    '    End If
    'End Sub
    '
    ' Data value has changed
    '
    Private Sub MyBase_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.ValueChanged
        SaveNewValue()
        MyBase.Focus()
    End Sub
    '
    ' Leave & Lost Focus may enter new data value
    '
    'Private Sub MyBase_Leave(ByVal sender As Object, ByVal e As EventArgs) _
    '    Handles MyBase.Leave
    '    If Not (WinFlumeForm.InUndo Or WinFlumeForm.InRedo) Then
    '        SaveNewValue()
    '    End If
    'End Sub

    'Protected Overridable Sub Control_LostFocus(ByVal sender As Object, ByVal e As EventArgs) _
    'Handles MyBase.LostFocus
    '    If Not (WinFlumeForm.InUndo Or WinFlumeForm.InRedo) Then
    '        SaveNewValue()
    '    End If
    'End Sub
    '
    ' Event to indicate value may have changed
    '
    Protected Sub RaiseValueChangedEvent()
        RaiseEvent UpDownChanged()
    End Sub

    Public Event UpDownChanged()

    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ctl_SingleUpDown
        '
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
