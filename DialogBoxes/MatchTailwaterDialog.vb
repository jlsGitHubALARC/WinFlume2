
'*************************************************************************************************************
' Class MatchTailwaterDialog
'*************************************************************************************************************

Public Class MatchTailwaterDialog

#Region " Event Handlers "

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) _
        Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

End Class
