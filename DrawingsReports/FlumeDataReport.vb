
'*************************************************************************************************************
' Class FlumeDataReport - subclass for generating the Flume Data Report
'*************************************************************************************************************
Public Class FlumeDataReport
    Inherits BaseReport

#Region " Report Methods "

    Public Overrides Sub GenerateReport()
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data
            If (mFlume Is Nothing) Then
                Return
            End If

            PageHeader = MyBase.ReportHeader & vbCrLf & vbCrLf

            Dim version As String = WinFlumeForm.WinFlumeName() & " " & WinFlumeForm.WinFlumeVersion()
            Dim rptPage As String = PageHeader & mFlume.DataReport(version)

            ReDim mReportPages(0)
            mReportPages(0) = NewReportPage()
            mReportPages(0).Rtf.WordWrap = False
            mReportPages(0).Rtf.ScrollBars = RichTextBoxScrollBars.None
            mReportPages(0).Rtf.Text = rptPage

        End If
    End Sub

#End Region

End Class
