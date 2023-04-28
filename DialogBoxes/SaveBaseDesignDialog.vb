
'*************************************************************************************************************
'   Class SaveBaseDesignDialog - Dialog used to prompt the user whether to save the current Base Design to
'   a file before examininig Alternative Designs.
'*************************************************************************************************************
Imports System.Windows.Forms

Public Class SaveBaseDesignDialog

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) _
        Handles SaveButton.Click
        WinFlumeForm.SaveFlumeFile(WinFlumeForm.FilePath)
        Me.Close()
    End Sub

    Private Sub SaveAsButton_Click(sender As Object, e As EventArgs) _
        Handles SaveAsButton.Click
        WinFlumeForm.SaveAsFlumeFile()
        Me.Close()
    End Sub

    Private Sub NoButton_Click(sender As Object, e As EventArgs) _
        Handles NoButton.Click
        Me.Close()
    End Sub

    Private Sub DontShowDialog_CheckedChanged(sender As Object, e As EventArgs) _
        Handles DontShowDialog.CheckedChanged
        WinFlumeForm.ShowSaveDesignDialog = Not DontShowDialog.Checked
    End Sub
End Class
