
'*************************************************************************************************************
' Class ctl_Precision - UI control for selecting the precision of a value
'*************************************************************************************************************
Public Class ctl_Precision

#Region " Properties "

    Protected mPrecision As Single = 0.01!
    Public Property Precision() As Single
        Get
            Return mPrecision
        End Get
        Set(ByVal value As Single)
            mPrecision = value
            Me.UpdateUI()
        End Set
    End Property

    Public Property UnitsText As String
        Get
            UnitsText = Me.PrecisionUnits.Text
        End Get
        Set(value As String)
            Me.PrecisionUnits.Text = value
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

#Region " Public Undo/Redo Methods "

    Public Sub Undo(ByVal ParentName As String, ByVal ControlName As String, ByVal UndoValue As Object)
        Debug.Assert(WinFlumeForm.InUndo, "Not in Undo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                If (UndoValue.GetType Is GetType(Single)) Then
                    Dim precision As Single = DirectCast(UndoValue, Single)
                    ' Add Redo item
                    Dim redoText As String = My.Resources.ValueChange & " - " & Me.Label
                    WinFlumeForm.AddRedoItem(ParentName, ControlName, redoText, Me.Precision)
                    ' Load Undo value
                    Me.Precision = precision
                    Me.PrecisionUpDown.Focus()      ' Select text to track undo/redo
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
                    Dim precision As Single = DirectCast(RedoValue, Single)
                    ' Add Undo item
                    Dim undoText As String = My.Resources.ValueChange & " - " & Me.Label
                    WinFlumeForm.AddUndoItem(ParentName, ControlName, undoText, Me.Precision)
                    ' Load Redo value
                    Me.Precision = precision
                    Me.PrecisionUpDown.Focus()      ' Select text to track undo/redo
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

    Private mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        If (mUpdatingUI) Then ' prevent recursive calls
            Return
        End If
        mUpdatingUI = True

        Dim diff As Single = Single.MaxValue
        Dim idx As Integer = 0
        Dim pdx As Integer = 0
        Try
            For Each obj As Object In Me.PrecisionUpDown.Items
                If (obj.GetType Is GetType(String)) Then
                    Dim str As String = CStr(obj)
                    Dim val As Single = Single.Parse(str)
                    If (diff > Math.Abs(val - mPrecision)) Then
                        diff = Math.Abs(val - mPrecision)
                        pdx = idx
                    End If
                End If
                idx += 1
            Next obj
            Me.PrecisionUpDown.SelectedIndex = pdx
            mPrecision = Single.Parse(CStr(Me.PrecisionUpDown.Items(pdx)))
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        mUpdatingUI = False
    End Sub

    Protected Sub SaveNewValue()
        ' Wait for control to be initialized
        If ((Me.Parent Is Nothing) Or (Me.Label = "")) Then
            Return
        End If

        If (UndoEnabled) Then ' Establish Undo point
            Dim undoText As String = My.Resources.ValueChange & " - " & Me.Label
            WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, Me.Precision)
            WinFlumeForm.ClearRedoStack()
        End If

        Dim obj As Object = Me.PrecisionUpDown.SelectedItem
        If (obj.GetType Is GetType(String)) Then
            Dim str As String = CStr(obj)
            Dim val As Single = Single.Parse(str)
            mPrecision = val

            ' Let others respond to new value
            RaiseValueChangedEvent()
        End If
    End Sub

#End Region

#Region " UI Events & Handlers "
    '
    ' Selected Item in list has changed
    '
    Private Sub PrecisionUpDown_SelectedItemChanged(sender As Object, e As EventArgs) _
    Handles PrecisionUpDown.SelectedItemChanged
        If Not (mUpdatingUI) Then
            Me.SaveNewValue()
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
