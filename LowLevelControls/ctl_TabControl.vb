
'*************************************************************************************************************
' Class ctl_TabControl - UI control for selecting tab pages within a tab control
'*************************************************************************************************************
Imports System
Imports System.Windows

Public Class ctl_TabControl

#Region " Properties "

    Protected mValue As Integer = 0
    Public Property Value() As Integer
        Get
            Return mValue
        End Get
        Set(ByVal value As Integer)
            mValue = value
            Me.SelectedIndex = mValue
        End Set
    End Property

#End Region

#Region " Constructor(s) "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DrawMode = TabDrawMode.OwnerDrawFixed   ' Draw tabs via DrawItem event

    End Sub

#End Region

#Region " UI Methods "
    '
    ' User Draw the TabControl tabs to add highlights for ease-of-use
    '
    Private Sub MyBase_DrawItem(ByVal sender As Object, ByVal e As Forms.DrawItemEventArgs) _
    Handles MyBase.DrawItem
        '
        ' Define background/foreground brush colors for selected/unselected tabs
        '
        Dim background, foreground As Brush
        Dim tabRectF As RectangleF
        Dim format As New StringFormat

        If Me.SelectedIndex = e.Index Then ' selected tab

            background = New SolidBrush(System.Drawing.SystemColors.ActiveCaption)
            foreground = New SolidBrush(System.Drawing.SystemColors.ActiveCaptionText)

            If (Me.Alignment = TabAlignment.Top) Then
                tabRectF = New RectangleF(e.Bounds.X - 4, e.Bounds.Y + 3, e.Bounds.Width + 7, e.Bounds.Height - 3)
                format.Alignment = StringAlignment.Center
            Else
                tabRectF = New RectangleF(e.Bounds.X - 4, e.Bounds.Y + 3, e.Bounds.Width + 7, e.Bounds.Height)
                format.Alignment = StringAlignment.Center
            End If

        Else ' unselected tab

            background = New SolidBrush(System.Drawing.SystemColors.Control)
            foreground = New SolidBrush(DefaultForeColor)

            If (Me.Alignment = TabAlignment.Top) Then
                tabRectF = New RectangleF(e.Bounds.X - 4, e.Bounds.Y + 3, e.Bounds.Width + 7, e.Bounds.Height - 3)
                format.Alignment = StringAlignment.Center
            Else
                tabRectF = New RectangleF(e.Bounds.X - 4, e.Bounds.Y, e.Bounds.Width + 7, e.Bounds.Height)
                format.Alignment = StringAlignment.Center
            End If
        End If
        '
        ' Draw tab's rectangle/text
        '
        Dim tab As TabPage = Me.TabPages(e.Index)
        Dim tabText As String = tab.Text

        e.Graphics.FillRectangle(background, e.Bounds)
        e.Graphics.DrawString(tabText, Me.Font, foreground, tabRectF, format)

    End Sub

#End Region

#Region " Public Undo/Redo Methods "

    Public Sub Undo(ByVal ParentName As String, ByVal ControlName As String, ByVal UndoValue As Object)
        Debug.Assert(WinFlumeForm.InUndo, "Not in Undo")
        If (ParentName = Me.Parent.Name) Then
            If (ControlName = Me.Name) Then
                If (UndoValue.GetType Is GetType(Integer)) Then
                    Dim value As Integer = DirectCast(UndoValue, Integer)
                    ' Add Redo item
                    Dim redoText As String = My.Resources.TabChange & " - " & Me.SelectedTab.Text
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
                    Dim undoText As String = My.Resources.TabChange & " - " & Me.TabPages(value).Text
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
        If Not (mValue = Me.SelectedIndex) Then
            ' Establish Undo point
            Dim undoText As String = My.Resources.TabChange & " - " & Me.SelectedTab.Text
            WinFlumeForm.AddUndoItem(Me.Parent.Name, Me.Name, undoText, mValue)
            WinFlumeForm.ClearRedoStack()
            ' Save new value
            mValue = Me.SelectedIndex
            ' Let others respond to new value
            RaiseValueChangedEvent()
        End If
    End Sub

#End Region

#Region " UI Events & Handlers "

    Private Sub ctl_TabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.SelectedIndexChanged
        If (MyBase.ContainsFocus) Then
            SaveNewValue()
        End If
    End Sub
    '
    ' Event to indicate value changed
    '
    Protected Sub RaiseValueChangedEvent()
        RaiseEvent ValueChanged()
    End Sub

    Public Event ValueChanged()

#End Region

End Class
