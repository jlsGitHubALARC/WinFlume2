
'*************************************************************************************************************
' Class DrawingsReportsControl - UserControl for displaying the Flume's Design reports & drawings
'*************************************************************************************************************
Imports System.Drawing.Printing

Imports WinFlume.BasePage

Public Class DrawingsReportsControl

#Region " Member Data "
    '
    ' WinFlume's top-level User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Protected mFlume As Flume.FlumeType = Nothing
    Protected mSection As Flume.SectionType = Nothing
    '
    ' Printing support
    '
    Private mPageSelections() As Integer = {1, 1}   ' Array of pages selected to print
    Private mNextPageSelection As Integer = 0       ' Index of next page selection
    Private mNextPageNo As Integer = 1              ' Next page number to print

#End Region

#Region " Results Page Data "

    ' Drawings & Reports
    Private mFlumeDataReport As FlumeDataReport
    Private mFlumeDesignReview As FlumeDesignReview
    Private mRatingTableReport As RatingTableReport
    Private mRatingEquationReport As RatingEquationReport
    Private mDitchridersTableReport As DitchridersTableReport
    Private mFlumeDrawings As FlumeDrawings

#End Region

#Region " UI Methods "

    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm,
               Optional ByVal ForceUpdate As Boolean = False)
        mWinFlumeForm = WinFlume
        Me.UpdateUI(ForceUpdate)
    End Sub

    Protected Sub UpdateUI(Optional ByVal ForceUpdate As Boolean = False)
        If Not (Me.Visible) Then
            Return
        End If

        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data
            If (mFlume Is Nothing) Then
                Return
            End If

            If (ForceUpdate) Then
                If (mFlumeDataReport Is Nothing) Then
                    mFlumeDataReport = New FlumeDataReport
                    mFlumeDesignReview = New FlumeDesignReview
                    mRatingTableReport = New RatingTableReport
                    mRatingEquationReport = New RatingEquationReport
                    mDitchridersTableReport = New DitchridersTableReport
                    mFlumeDrawings = New FlumeDrawings
                End If
            Else
                If Not (Me.Visible) Then ' only update when control is visible
                    Return
                End If
            End If

            Me.DrawingsReportsControlTabControl.TabPages.Clear()

            AddReportPages(mFlumeDataReport, My.Resources.FlumeDataReport)
            AddReportPages(mFlumeDesignReview, My.Resources.FlumeDesignReview)
            AddReportPages(mRatingTableReport, My.Resources.RatingTable)
            AddReportPages(mRatingEquationReport, My.Resources.RatingEquation)
            AddReportPages(mDitchridersTableReport, My.Resources.DitchridersTable)
            AddReportPages(mFlumeDrawings, My.Resources.FlumeDrawings)

            ' Rename Design Review tabs
            Me.DrawingsReportsControlTabControl.TabPages(1).Text = My.Resources.FlumeDesignReview
            Me.DrawingsReportsControlTabControl.TabPages(2).Text = My.Resources.MeasurmentUncertainty
            Me.DrawingsReportsControlTabControl.TabPages(3).Text = My.Resources.ConstructionNotes

        End If
    End Sub

#End Region

#Region " Report Page / Tab Methods "

    Private Sub AddReportPages(ByVal Report As BaseReport, ByVal Title As String)
        Try
            If (Report IsNot Nothing) Then
                Report.WinFlumeForm = mWinFlumeForm
                Report.GenerateReport()

                Dim numPages As Integer = Report.NumReportPages
                Dim tabTitle As String = Title

                For pageNo As Integer = 1 To numPages
                    Dim ReportPage As RtfPage = Report.ReportPages(pageNo - 1)

                    If (Report.ReportImages IsNot Nothing) Then
                        If (pageNo = 1) Then
                            For Each repImage As PictureBox In Report.ReportImages
                                ReportPage.AddImage(repImage)
                            Next
                        End If
                    End If

                    If (1 < numPages) Then
                        tabTitle = Title & " (" & pageNo.ToString & ")"
                    End If

                    If (Report.PageTitles IsNot Nothing) Then
                        If (pageNo <= Report.PageTitles.Count) Then
                            tabTitle = Report.PageTitles(pageNo - 1)
                        End If
                    End If

                    Dim ReportTab As TabPage = NewReportTab(tabTitle)

                    With ReportTab
                        .SuspendLayout()
                        .Controls.Add(ReportPage)
                        .ResumeLayout()
                    End With
                Next pageNo

            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Function NewReportTab(ByVal TabName As String) As TabPage
        NewReportTab = New TabPage(TabName) With {
            .AutoScroll = True,
            .AutoScrollMargin = New Size(LeftOffset, TopOffset),
            .BackColor = System.Drawing.SystemColors.ControlDarkDark
        }
        Me.DrawingsReportsControlTabControl.TabPages.Add(NewReportTab)
    End Function

    Private Function NewResultsPage() As RtfPage
        NewResultsPage = New RtfPage With {
            .PageWidth = PortraitPageWidth,
            .PageHeight = PortraitPageLength,
            .TopMargin = PortraitTopMargin,
            .LeftMargin = PortraitLeftMargin,
            .RightMargin = PortraitRightMargin,
            .BottomMargin = PortraitBottomMargin,
            .Location = New Point(LeftOffset, TopOffset)
        }

        If (mWinFlumeForm IsNot Nothing) Then
            With NewResultsPage
                .Font = mWinFlumeForm.FixedFont
                .Rtf.Font = mWinFlumeForm.FixedFont
            End With
        End If

        ' Add event handler for Mouse Wheel events
        'jls AddHandler page.RtfCtrl.MouseWheel, AddressOf RtfCtrl_MouseWheel
    End Function

#End Region

#Region " Printing Methods "

    '*********************************************************************************************************
    ' Function NumberOfPages()  - return number of pages available to print (one RtfPage per tab)
    ' Function GetReportPage()  - return specific RtfPage
    '*********************************************************************************************************
    Private Function NumberOfPages() As Integer
        Return Me.DrawingsReportsControlTabControl.TabCount
    End Function

    Private Function GetReportPage(ByVal PageNumber As Integer) As RtfPage
        If ((1 <= PageNumber) And (PageNumber <= NumberOfPages())) Then
            Dim tabPage As TabPage = Me.DrawingsReportsControlTabControl.TabPages(PageNumber - 1)
            If (0 < tabPage.Controls.Count) Then
                Dim obj As Object = tabPage.Controls(0)
                If (obj.GetType Is GetType(RtfPage)) Then
                    Dim tabRtfPage As RtfPage = DirectCast(obj, RtfPage)
                    Return tabRtfPage
                Else
                    Debug.Assert(False)
                End If
            Else
                Debug.Assert(False)
            End If
        End If
        Return Nothing
    End Function

    '*********************************************************************************************************
    ' Sub Print()           - called to print the results pages
    ' Sub PrintPreview()    -    "    " preview "    "      "
    '*********************************************************************************************************
    Public Sub Print()

        If ((mWinFlumeForm Is Nothing) Or (NumberOfPages() < 0)) Then ' there is nothing to print
            Return
        End If

        ' Start with full range of pages
        ReDim mPageSelections(1)
        mPageSelections(0) = 1
        mPageSelections(1) = NumberOfPages()

        If (mWinFlumeForm.PrintResults(Me.PrintReportsDialog,
                                       Me.DrawingsReportsControlTabControl.SelectedIndex + 1,
                                       mPageSelections)) Then

            mNextPageNo = mPageSelections(0)

            ' Make sure the first page actually exists
            Dim page As RtfPage = GetReportPage(mNextPageNo)
            If (page IsNot Nothing) Then

                ' Set page to match the portrait results display
                Dim PortraitMargins As Margins = New Margins(PortraitLeftMargin - 10, PortraitRightMargin,
                                                             PortraitTopMargin, PortraitBottomMargin)

                Me.PrintReportDocument.DefaultPageSettings.Margins = PortraitMargins
                Me.PrintReportDocument.DefaultPageSettings.Landscape = False

                ' Print (which may cause exceptions)
                Try
                    Me.PrintReportDocument.Print()
                Catch ex As Exception
                    Debug.Assert(False, ex.Message)
                End Try
            End If
        End If

    End Sub

    '*********************************************************************************************************
    ' PrintReportDocument event handlers that actually print the requested results pages
    '*********************************************************************************************************
    Private Sub PrintReportDocument_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs) _
        Handles PrintReportDocument.BeginPrint
        mNextPageSelection = 0
    End Sub

    Private Sub PrintReportDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) _
        Handles PrintReportDocument.PrintPage

        Try
            ' Get next page number to print
            mNextPageNo = mPageSelections(mNextPageSelection)

            Dim ResultsPage As RtfPage = GetReportPage(mNextPageNo)
            If (ResultsPage IsNot Nothing) Then

                ' Tell the next page to print itself
                ResultsPage.Print(e)

                ' If there are more pages to print; let caller know
                If (mNextPageSelection < mPageSelections.Length - 1) Then
                    mNextPageSelection += 1
                    e.HasMorePages = True
                    Return
                End If
            End If

        Catch ex As Exception
        End Try

        e.HasMorePages = False

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Sub DrawingsReportsControl_Load - Initialization at load time
    '*********************************************************************************************************
    Private Sub DrawingsReportsControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load

        mFlumeDataReport = New FlumeDataReport
        mFlumeDesignReview = New FlumeDesignReview
        mRatingTableReport = New RatingTableReport
        mRatingEquationReport = New RatingEquationReport
        mDitchridersTableReport = New DitchridersTableReport
        mFlumeDrawings = New FlumeDrawings

        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Sub FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    Private Sub MyBase_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.VisibleChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
