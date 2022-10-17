
'*************************************************************************************************************
' Class DefinitionSketchDialog - dialog box for displaying the stationary & movable flume sketches
'*************************************************************************************************************
Imports System.Windows.Forms

Public Class DefinitionSketchDialog

    Private Sub ViewStationaryButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewStationaryButton.CheckedChanged
        Me.MovableSketch.Hide()
        Me.StationarySketch.Show()
    End Sub

    Private Sub ViewMovableButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ViewMovableButton.CheckedChanged
        Me.StationarySketch.Hide()
        Me.MovableSketch.Show()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
