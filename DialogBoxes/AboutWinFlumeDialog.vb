
'*************************************************************************************************************
' AboutWinFlumeDialog
'*************************************************************************************************************

Public Class AboutWinFlumeDialog

#Region " Member Data "
    '
    ' URLs
    '
    Public Const URL_USDA As String = "https://www.usda.gov"
    Public Const URL_ARS As String = "https://www.ars.usda.gov"
    Public Const URL_ALARC As String = "https://www.ars.usda.gov/pacific-west-area/maricopa-arizona/us-arid-land-agricultural-research-center/"

    Public Const URL_USBR As String = "https://www.usbr.gov/"
    Public Const URL_USBR_Research As String = "https://www.usbr.gov/research/"
    Public Const URL_TONY_WAHL As String = "https://www.usbr.gov/research/projects/researcher.cfm?id=120"

    Public Const URL_ILRI As String = "http://www.bos-water.nl"

#End Region

#Region " Event Handlers "

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub USBR_URL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles USBR_URL.LinkClicked
        ' Mark link as visited
        Me.USBR_URL.Links(USBR_URL.Links.IndexOf(e.Link)).Visited = True
        ' Display ARS web page
        Try ' default browser
            System.Diagnostics.Process.Start(URL_USBR)
        Catch ex1 As Exception
            Try ' Internet Explorer
                System.Diagnostics.Process.Start("IExplore", URL_USBR)
            Catch ex2 As Exception
                Try ' Chrome
                    System.Diagnostics.Process.Start("Chrome", URL_USBR)
                Catch ex3 As Exception
                End Try
            End Try
        End Try
    End Sub

    Private Sub ARS_URL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles ARS_URL.LinkClicked
        ' Mark link as visited
        Me.ARS_URL.Links(ARS_URL.Links.IndexOf(e.Link)).Visited = True
        ' Display ARS web page
        Try ' default browser
            System.Diagnostics.Process.Start(URL_ARS)
        Catch ex1 As Exception
            Try ' Internet Explorer
                System.Diagnostics.Process.Start("IExplore", URL_ARS)
            Catch ex2 As Exception
                Try ' Chrome
                    System.Diagnostics.Process.Start("Chrome", URL_ARS)
                Catch ex3 As Exception
                End Try
            End Try
        End Try
    End Sub

    Private Sub ILRI_URL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles ILRI_URL.LinkClicked
        ' Mark link as visited
        Me.ILRI_URL.Links(ILRI_URL.Links.IndexOf(e.Link)).Visited = True
        ' Display ARS web page
        Try ' default browser
            System.Diagnostics.Process.Start(URL_ILRI)
        Catch ex1 As Exception
            Try ' Internet Explorer
                System.Diagnostics.Process.Start("IExplore", URL_ILRI)
            Catch ex2 As Exception
                Try ' Chrome
                    System.Diagnostics.Process.Start("Chrome", URL_ILRI)
                Catch ex3 As Exception
                End Try
            End Try
        End Try
    End Sub

    Private Sub DetailsButton_Click(sender As Object, e As EventArgs) _
        Handles DetailsButton.Click

        Dim msg As String = "WinFlume Version " & WinFlumeForm.WinFlumeVersion & vbLf

        msg &= "------------------------------------------------------------------------" & vbLf
        msg &= My.Resources.ToReportProblems & vbLf & vbLf
        msg &= "Tony L. Wahl" & vbLf
        msg &= "U.S. Bureau of Reclamation, 86-68460" & vbLf
        msg &= "Hydraulic Investigations and Laboratory Services Group" & vbLf
        msg &= "Denver, Colorado" & vbLf & vbLf
        msg &= "twahl@usbr.gov           303-445-2155" & vbLf & vbLf
        msg &= My.Resources.WinFlumeAvailableAt & vbLf
        msg &= "https://www.ars.usda.gov/research/software" & vbLf ' "www.usbr.gov/pmts/hydraulics_lab/winflume" & vbLf
        msg &= "------------------------------------------------------------------------" & vbLf

        Dim title As String = Me.Text
        Dim style As MsgBoxStyle = MsgBoxStyle.Information Or MsgBoxStyle.OkOnly

        Dim result As MsgBoxResult = MsgBox(msg, style, title)
    End Sub

    Private Sub AboutWinFlumeDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WinFlumeDescription.Location = Me.FlumePicture.PointToClient(Me.PointToScreen(Me.WinFlumeDescription.Location))
        Me.WinFlumeDescription.Parent = Me.FlumePicture

        Me.WinFlumeAffiliations.Location = Me.FlumePicture.PointToClient(Me.PointToScreen(Me.WinFlumeAffiliations.Location))
        Me.WinFlumeAffiliations.Parent = Me.FlumePicture
        Me.WinFlumeAffiliations.ForeColor = Color.Yellow

        Me.WinFlumeVersionLabel.Text = "Version " & WinFlumeForm.WinFlumeVersion
    End Sub

#End Region

End Class
