
'*************************************************************************************************************
' Class RatingTableReport - subclass for generating the Rating Table Report
'*************************************************************************************************************
Imports Flume
Imports Flume.FlumeType

Imports WinFlume.BasePage

Public Class RatingTableReport
    Inherits BaseReport

#Region " Report Methods "

    Public Overrides Sub GenerateReport()
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data
            If (mFlume Is Nothing) Then
                Return
            End If

            Dim ratingTableControl As RatingTableControl = mWinFlumeForm.GetRatingTableControl
            ratingTableControl.UpdateUI(mWinFlumeForm)
            ratingTableControl.UpdateRatingTable()

            Dim ratingTable As ctl_DataGridView = ratingTableControl.RatingTableGridView

            ' Get header(s) & table(s); one entry in List per page
            Dim tblHdr As List(Of String) = ratingTable.HeaderTexts(PortraitWidthChars)
            Dim tblTxt As List(Of String) = ratingTable.TableTexts(PortraitWidthChars)

            Debug.Assert(tblHdr.Count = tblTxt.Count)

            If (tblHdr.Count <= 0) Then
                Return
            ElseIf (tblHdr(0) = "") Then
                Return
            End If

            PageHeader = MyBase.ReportHeader
            PageFooter = ratingTableControl.ErrorText
            PageNumber = ""
            '
            ' Generate Rating Table pages
            '
            Dim printPages As List(Of String) = New List(Of String)
            Dim pageTitles As List(Of String) = New List(Of String)
            Dim title As String = My.Resources.RatingTable

            If (1 = tblHdr.Count) Then ' table columns fit on one page

                For page123 As Integer = 1 To 3 ' extend table vertically

                    Dim pageID As String = page123.ToString

                    PageTitle = title & " (" & pageID & ")"

                    TableHeader = tblHdr(0)
                    Dim rptPage As String = GeneratePage(tblTxt(0), page123)
                    If (rptPage IsNot Nothing) Then
                        If Not (rptPage = "") Then
                            printPages.Add(rptPage)
                            pageTitles.Add(PageTitle)
                        Else
                            Exit For
                        End If
                    Else
                        Exit For
                    End If

                Next page123

            ElseIf (1 < tblHdr.Count) Then ' table columns span multiple pages

                Dim horzCount As Integer = Math.Min(tblHdr.Count, 3)

                For page123 As Integer = 1 To 3                 ' outer loop extends table pages vertically
                    For pageABC As Integer = 1 To horzCount     ' inner loop extands table pages horizontally

                        Dim pageID As String = page123.ToString & "abc".Substring(pageABC - 1, 1)

                        PageTitle = title & " (" & pageID & ")"

                        TableHeader = tblHdr(pageABC - 1)
                        Dim rptPage As String = GeneratePage(tblTxt(pageABC - 1), page123)
                        If (rptPage IsNot Nothing) Then
                            If Not (rptPage = "") Then
                                printPages.Add(rptPage)
                                pageTitles.Add(PageTitle)
                            Else
                                Exit For
                            End If
                        Else
                            Exit For
                        End If

                    Next pageABC
                Next page123

            End If

            Dim pageCount As Integer = printPages.Count

            If (0 < pageCount) Then
                ReDim mReportPages(pageCount - 1)
                ReDim mPageTitles(pageCount - 1)

                For pageNo As Integer = 1 To pageCount
                    mReportPages(pageNo - 1) = NewReportPage()
                    mReportPages(pageNo - 1).Rtf.WordWrap = False
                    mReportPages(pageNo - 1).Rtf.ScrollBars = RichTextBoxScrollBars.None
                    mReportPages(pageNo - 1).Rtf.Text = printPages(pageNo - 1)

                    mPageTitles(pageNo - 1) = pageTitles(pageNo - 1)

                Next pageNo
            End If

        End If
    End Sub

#End Region

End Class
