
'*************************************************************************************************************
' Class RatingTableDrawing - subclass for generating the Rating Table Drawing
'*************************************************************************************************************
Imports Flume
Imports Flume.FlumeType

Imports WinFlume.BasePage

Public Class RatingTableDrawing
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
            Dim ratingTableControl As RatingTableControl = mWinFlumeForm.GetRatingTableControl
            Dim ratingTable As ctl_DataGridView = ratingTableControl.RatingTableGridView

            ' Generate report page header
            Dim hdr As String = ""
            hdr = ReportHeader() & vbCrLf
            hdr &= vbCrLf
            hdr &= TextOutput.CenterText(My.Resources.FlumeRatingTable.ToUpper, PortraitWidthChars) & vbCrLf
            hdr &= vbCrLf

            Dim hdrLC As Integer = LineCount(hdr, CChar(vbCrLf))
            '
            ' Get user choices for Rating Graph
            '
            Dim regGraphItem1 As Integer = WinFlumeForm.RatingGraphItem1
            Dim regGraphItem2 As Integer = WinFlumeForm.RatingGraphItem2
            Dim regGraphItem3 As Integer = WinFlumeForm.RatingGraphItem3
            '
            ' Get Rating Table results
            '
            choicesControl.ValidateSmartRange(mFlume)

            Dim RatingResults(1) As RatingResultsType
            Dim TableErrors(MaxHydErrors) As Boolean
            Dim Vmin, Vmax, Vinc As Single

            If (mFlume.RatingTableType = HQTable) Then '  Head-Discharge (HQ) rating table
                Vmin = mFlume.RatingHMin
                Vmax = mFlume.RatingHMax
                Vinc = mFlume.RatingHInc

                mFlume.MakeRating(HQTable, False, Vmin, Vmax, Vinc, RatingResults, TableErrors)
            Else ' Discharge-Head (QH) rating table
                Vmin = mFlume.RatingQMin
                Vmax = mFlume.RatingQMax
                Vinc = mFlume.RatingQInc

                mFlume.MakeRating(QHTable, False, Vmin, Vmax, Vinc, RatingResults, TableErrors)
            End If
            '
            ' Generate Rating Table Graph
            '
            Dim ratingGraph As RatingTableGraph = New RatingTableGraph With {
                .Location = New Point(75, 175),   ' (0.75", 1.75")
                .Size = New Size(700, 300),       ' (7.00", 3.00")
                .FlumeRef = mFlume,
                .GraphList = ratingTableControl.GraphList,
                .SyncYAxesSelect = False ' jls Me.SyncYAxesSelect.Checked
            }

            ratingGraph.UpdateRatingTableGraph(regGraphItem1, regGraphItem2, regGraphItem3, RatingResults)

            ReDim mReportImages(0)
            mReportImages(0) = ratingGraph

            ' Make room for graph on page 1
            Dim grfBuf As String = ""
            Dim grfLC As Integer = 20

            For ldx As Integer = 1 To grfLC     ' Skip text past Rating Table Graph
                grfBuf &= vbCrLf
            Next ldx
            '
            ' Generate Rating Table
            '
            ratingTableControl.UpdateRatingTable(RatingResults, mFlume.RatingTableType)

            Dim rptLC As Integer = PortraitHeightLines - hdrLC - grfLC
            Dim printPages As List(Of String) = ratingTable.PrintPages(rptLC, rptLC + grfLC)

            If (0 < printPages.Count) Then

                Dim rptPage As String = hdr & grfBuf & printPages(0)

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
