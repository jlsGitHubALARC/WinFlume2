
'*************************************************************************************************************
' Class FlumeEquationReport - subclass for generating the Flume Equation Report
'*************************************************************************************************************
Imports Flume

Imports WinFlume.BasePage

Public Class RatingEquationReport
    Inherits BaseReport

#Region " Report Methods "

    Public Overrides Sub GenerateReport()
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data
            If (mFlume Is Nothing) Then
                Return
            End If

            Dim choicesControl As TableChoicesControl = mWinFlumeForm.GetTableChoicesControl
            Dim ratingEquationControl As RatingEquationControl = mWinFlumeForm.GetRatingEquationControl
            '
            ' Get Rating Equation results
            '
            choicesControl.ValidateSmartRange(mFlume)

            Dim RatingResults(1) As RatingResultsType
            Dim TableErrors(MaxHydErrors) As Boolean

            ratingEquationControl.UpdateUI(mWinFlumeForm)
            ratingEquationControl.UpdateRatingEquationData(RatingResults, TableErrors)
            '
            ' Generate Rating Equation Graph
            '
            Dim ratingGraph As RatingEquationGraph = New RatingEquationGraph With {
            .Location = New Point(75, 150),   ' (0.75", 1.50")
            .Size = New Size(700, 300),       ' (7.00", 3.00")
            .FlumeRef = mFlume
            }

            ratingGraph.FlumeRef = mFlume
            ratingGraph.K1 = ratingEquationControl.K1
            ratingGraph.K2 = ratingEquationControl.K2
            ratingGraph.U = ratingEquationControl.U
            ratingGraph.UpdateRatingEquationGraph(RatingResults)

            ReDim mReportImages(0)
            mReportImages(0) = ratingGraph

            ' Make room for graph on page 1
            Dim grfBuf As String = ""
            Dim grfLC As Integer = 20

            For ldx As Integer = 1 To grfLC     ' Skip text past Rating Equation Graph
                grfBuf &= vbCrLf
            Next ldx
            '
            ' Generate Rating Equation Status Report
            '
            Dim statusReport As String = ratingEquationControl.StatusReport(TableErrors)
            statusReport = WordWrap(statusReport, PortraitWidthChars) & vbCrLf
            Dim repLC As Integer = LineCount(statusReport, CChar(vbCrLf))
            '
            ' Generate Rating Equation Table
            '
            ratingEquationControl.UpdateRatingEquationTable(RatingResults, mFlume.RatingTableType)
            Dim ratingTable As ctl_DataGridView = ratingEquationControl.RatingEquationGridView

            ' Start of report page header
            Dim hdr As String = ""
            hdr = MyBase.ReportHeader()     ' Start with report header
            hdr &= vbCrLf & vbCrLf

            Dim hdrLC As Integer = LineCount(hdr, CChar(vbCrLf)) + 1
            Dim rptLC As Integer = PortraitHeightLines - hdrLC - grfLC - repLC

            Dim printPages As List(Of String) = ratingTable.PrintPages(rptLC, rptLC + grfLC + repLC)

            If (0 < printPages.Count) Then

                If (1 = printPages.Count) Then
                    hdr &= TextOutput.CenterText(My.Resources.FlumeRatingEquation, PortraitWidthChars)
                    hdr &= vbCrLf
                Else ' at least 2 pages
                    hdr &= TextOutput.CenterText(My.Resources.FlumeRatingEquation & " (1)", PortraitWidthChars)
                    hdr &= vbCrLf
                End If

                Dim rptPage As String = hdr & grfBuf & statusReport & printPages(0)

                ReDim mReportPages(0)
                mReportPages(0) = NewReportPage()
                mReportPages(0).Rtf.WordWrap = False
                mReportPages(0).Rtf.ScrollBars = RichTextBoxScrollBars.None
                mReportPages(0).Rtf.Text = rptPage

                If (1 < printPages.Count) Then ' at least 2 pages

                    ' Start with report page header
                    hdr = ""
                    hdr = MyBase.ReportHeader()     ' Start with report header
                    hdr &= vbCrLf & vbCrLf
                    hdr &= TextOutput.CenterText(My.Resources.FlumeRatingEquation & " (2)", PortraitWidthChars)
                    hdr &= vbCrLf & vbCrLf

                    rptPage = hdr & printPages(1)

                    ReDim Preserve mReportPages(1)
                    mReportPages(1) = NewReportPage()
                    mReportPages(1).Rtf.WordWrap = False
                    mReportPages(1).Rtf.ScrollBars = RichTextBoxScrollBars.None
                    mReportPages(1).Rtf.Text = rptPage

                End If
            End If

        End If
    End Sub

#End Region

End Class
