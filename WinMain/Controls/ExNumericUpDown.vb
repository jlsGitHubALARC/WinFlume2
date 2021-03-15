
'**********************************************************************************************
' ExNumericUpDown - Extended NumericUpDown
'
Public Class ExNumericUpDown
    Inherits System.Windows.Forms.NumericUpDown

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

#Region " Event Overrides "
    '
    ' Suppress beep when Enter is pressed
    '
    Protected Overrides Sub OnTextBoxKeyPress(ByVal sender As Object, _
                                              ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(Windows.Forms.Keys.Return)) Then
            e.Handled = True
            ' Select all the text so the user can easily re-enter value
            MyBase.Select(0, MyBase.Text.Length)
        Else
            MyBase.OnTextBoxKeyPress(sender, e)
        End If
    End Sub
    '
    ' Select all text when control is entered
    '
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        MyBase.Select(0, MyBase.Text.Length)
        MyBase.OnEnter(e)
    End Sub

#End Region

End Class
