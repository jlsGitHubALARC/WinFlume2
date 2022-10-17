
Public Class PdfViewerDialog

    'Private Sub PdfViewerDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Try
    '        Dim pdfAvail As Boolean = Me.PdfViewer.LoadFile("WinFlume User Manual.pdf")
    '    Catch ex As Exception
    '        Debug.Assert(False, ex.Message)
    '    End Try
    'End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub MyBase_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles MyBase.Closing
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
        e.Cancel = True
    End Sub

End Class
