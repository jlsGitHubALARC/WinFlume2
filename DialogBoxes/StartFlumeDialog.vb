
'*************************************************************************************************************
' Class StartFlumeDialog - Windows form (dialog) for selecting starting Flume file
'*************************************************************************************************************
Public Class StartFlumeDialog

    Private Sub StartFlumeDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.OpenOtherFlumeButton.Checked = True              ' Start with Open Other Flume file
        If (WinFlumeForm.MruProjectList IsNot Nothing) Then ' MRU list exists
            If (0 < WinFlumeForm.MruProjectList.Count) Then '  and has entries
                Me.OpenLastFlumeButton.Enabled = True
                Me.OpenLastFlumeButton.Checked = True       ' Switch to Open Last Flume file
            Else
                Me.OpenLastFlumeButton.Enabled = False
            End If
        Else
            Me.OpenLastFlumeButton.Enabled = False
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class