
'*************************************************************************************************************
' Class DitchridersTableReport - subclass for generating the Ditchrider's Table Report
'*************************************************************************************************************
Imports Flume
Imports Flume.FlumeType

Imports WinFlume.BasePage

Public Class DitchridersTableReport
    Inherits BaseReport

#Region " Report Methods "

    Public Overrides Sub GenerateReport()
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data
            If (mFlume Is Nothing) Then
                Return
            End If

            Dim version As String = WinFlumeForm.WinFlumeName() & " " & WinFlumeForm.WinFlumeVersion()

            Dim choicesControl As TableChoicesControl = mWinFlumeForm.GetTableChoicesControl
            Dim ditchridersTableControl As DitchridersTableControl = mWinFlumeForm.GetDitchridersTableControl

            choicesControl.ValidateSmartRange(mFlume)

            ' Generate report page header
            Dim hdr As String = ""
            hdr = MyBase.ReportHeader()
            hdr &= vbCrLf & vbCrLf
            hdr &= TextOutput.CenterText(My.Resources.DitchridersTable, PortraitWidthChars) & vbCrLf
            hdr &= vbCrLf
            hdr &= TextOutput.CenterText(ditchridersTableControl.Caption(mFlume.DitchShowSlope), PortraitWidthChars) & vbCrLf
            hdr &= vbCrLf

            Dim hdrLC As Integer = LineCount(hdr, CChar(vbCrLf))
            '
            ' Generate Ditchrider's Table
            '
            ditchridersTableControl.UpdateUI(mWinFlumeForm)
            ditchridersTableControl.UpdateDitchridersTable()
            Dim ditchridersTable As ctl_DataGridView = ditchridersTableControl.DitchRidersTableGridView

            Dim rptLC As Integer = PortraitHeightLines - hdrLC
            Dim printPages As List(Of String) = ditchridersTable.PrintPages(rptLC, rptLC)

            If (0 < printPages.Count) Then

                Dim rptPage As String = hdr & printPages(0)

                ReDim mReportPages(0)
                mReportPages(0) = NewReportPage()
                mReportPages(0).Rtf.WordWrap = False
                mReportPages(0).Rtf.ScrollBars = RichTextBoxScrollBars.None
                mReportPages(0).Rtf.Text = rptPage
            End If

        End If
    End Sub

#End Region

End Class
