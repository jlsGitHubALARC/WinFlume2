
Public Class PdfViewerDialog

    'Private Sub PdfViewerDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Try
    '        Dim pdfAvail As Boolean = Me.PdfViewer.LoadFile("WinFlume User Manual.pdf")
    '    Catch ex As Exception
    '        Debug.Assert(False, ex.Message)
    '    End Try
    'End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub PdfViewerDialog_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        Me.Hide()
        e.Cancel = True
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
