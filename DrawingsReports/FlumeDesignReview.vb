
'*************************************************************************************************************
' Class FlumeDesignReview - subclass for generating the Flume Design Review
'*************************************************************************************************************
Public Class FlumeDesignReview
    Inherits BaseReport

#Region " Report Methods "

    Public Overrides Sub GenerateReport()
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data
            If (mFlume Is Nothing) Then
                Return
            End If

            Dim WinFlumeDesign As WinFlumeDesign = New WinFlumeDesign
            Dim version As String = WinFlumeForm.WinFlumeName() & " " & WinFlumeForm.WinFlumeVersion()

            PageHeader = MyBase.ReportHeader & vbCrLf & vbCrLf

            ReDim mReportPages(2)

            Dim rptPage1 As String = PageHeader & WinFlumeDesign.DesignReview1of3(mFlume, version)
            mReportPages(0) = NewReportPage()
            mReportPages(0).Rtf.WordWrap = False
            mReportPages(0).Rtf.ScrollBars = RichTextBoxScrollBars.None
            mReportPages(0).Rtf.Text = rptPage1

            Dim rptPage2 As String = PageHeader & WinFlumeDesign.DesignReview2of3(mFlume, version)
            mReportPages(1) = NewReportPage()
            mReportPages(1).Rtf.WordWrap = False
            mReportPages(1).Rtf.ScrollBars = RichTextBoxScrollBars.None
            mReportPages(1).Rtf.Text = rptPage2

            Dim rptPage3 As String = PageHeader & WinFlumeDesign.DesignReview3of3(mFlume, version)
            mReportPages(2) = NewReportPage()
            mReportPages(2).Rtf.WordWrap = False
            mReportPages(2).Rtf.ScrollBars = RichTextBoxScrollBars.None
            mReportPages(2).Rtf.Text = rptPage3

        End If
    End Sub

#End Region

End Class
