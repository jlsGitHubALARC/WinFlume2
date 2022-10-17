
'*************************************************************************************************************
' Class FixedDischargePlotControl - UserControl for generating the Wall Gage plots
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.BasePage
Imports System.Drawing.Printing

Public Class FixedDischargePlotControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mSection As Flume.SectionType = Nothing
    '
    ' Gage data
    '
    Private PrevLabelOffset() As Integer = {-9999, -9999}
    Private LabelIntervals() As Integer = {1, 2, 4, 5, 10}
    '
    ' Printing support
    '
    Private mPrintingFixedDischargeGage As Boolean = False
    Private mPageSelections() As Integer = {1, 1}   ' Array of pages selected to print
    Private mNextPageSelection As Integer = 0       ' Index of next page selection
    Private mNextPageNo As Integer = 1              ' Next page number to print

#End Region

#Region " Properties "

    Public Property FixedHeadIntervalGage As ctl_WallGage
    Public Property FixedHeadPrintPages As RtfPage()

    Public Property FixedDischargeIntervalGage As ctl_WallGage
    Public Property FixedDischargePrintPages As RtfPage()

#End Region

#Region " UI Methods "

#Region " Wall Gage Plots "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display the Fixed-Head Interval Wall Gage options & data
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Private mUpdatingUI As Boolean = False
    Private Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data
        If ((mFlume Is Nothing) Or (Not (Me.Visible))) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Debug.Assert(False)
            Return
        End If
        mUpdatingUI = True
        '
        ' Initialization
        '
        If (PrevLabelOffset(0) = -9999) Then
            PrevLabelOffset(0) = mFlume.WGageFirstLabelOffset(0)
            PrevLabelOffset(1) = mFlume.WGageFirstLabelOffset(1)
        End If
        '
        ' Fixed-Discharge Interval Gage
        '
        UpdateFixedDischargeIntervalControls()
        UpdateFixedDischargeIntervalGage()

        If (FixedDischargeIntervalGage IsNot Nothing) Then
            If (FixedDischargeIntervalGage.GageBitmap IsNot Nothing) Then
                Me.FixedDischargeGagePlot.Visible = True

                Dim srcWidth As Integer = CInt(FixedDischargeIntervalGage.GageBitmap.Width)
                Dim srcHeight As Integer = CInt(FixedDischargeIntervalGage.GageBitmap.Height)
                Dim srcRect As Rectangle = New Rectangle(0, 0, srcWidth, srcHeight)
                Dim srcRatio As Double = srcWidth / srcHeight

                ' Size & locate thumbnail plot
                Dim destloc As Point = Me.FixedDischargeGagePlot.Location
                Dim destHeight As Integer = Me.FixedDischargeGagePanel.Height - destloc.Y * 2
                Dim destWidth As Integer = CInt(destHeight * srcRatio)
                If (destWidth > Me.FixedDischargeGagePanel.Width - Me.Margin.Horizontal * 2) Then
                    destWidth = Me.FixedDischargeGagePanel.Width - Me.Margin.Horizontal * 2
                    destHeight = CInt(destWidth / srcRatio)
                End If
                destloc.X = CInt((Me.FixedDischargeGagePanel.Width - destWidth) / 2)

                Me.FixedDischargeGagePlot.Location = destloc
                Me.FixedDischargeGagePlot.Width = destWidth
                Me.FixedDischargeGagePlot.Height = destHeight

                ' Clone fixed-discharge gage to thumbnail
                Me.FixedDischargeGagePlot.ClearCanvas()

                Dim dischargeBitmap As Bitmap = Me.FixedDischargeGagePlot.Bitmap1
                Dim dischargeGraphics As Graphics = Me.FixedDischargeGagePlot.GdiGraphics
                Dim dischargeRect As Rectangle = New Rectangle(0, 0, dischargeBitmap.Width, dischargeBitmap.Height)

                dischargeGraphics.DrawImage(FixedDischargeIntervalGage.GageBitmap, dischargeRect, srcRect, GraphicsUnit.Pixel)

                Me.FixedDischargeGagePlot.ShowCanvas()
            Else
                Me.FixedDischargeGagePlot.Visible = False
            End If
        Else
            Me.FixedDischargeGagePlot.Visible = False
        End If

        mUpdatingUI = False
    End Sub

#End Region

#Region " Fixed-Discharge Interval "

    Private Sub UpdateFixedDischargeIntervalControls()

        Me.SlopedDischargeGageButton.Label = My.Resources.GageSlopeChoice
        Me.SlopedDischargeGageButton.RbValue = WallGageOnSlope
        Me.SlopedDischargeGageButton.UiValue = mFlume.WGageSlopeChoice(1)

        Me.VerticalDischargeGageButton.Label = My.Resources.GageSlopeChoice
        Me.VerticalDischargeGageButton.RbValue = WallGageVertical
        Me.VerticalDischargeGageButton.UiValue = mFlume.WGageSlopeChoice(1)

        Me.DischargeLabelSizeFactorUpDown.Label = My.Resources.GageTextSize
        Me.DischargeLabelSizeFactorUpDown.SiValue = mFlume.WGageTextSize(1)

        Dim tickInterval As Integer = mFlume.WGageTickIntervalChoice(1)
        If (tickInterval < 0) Then
            tickInterval = 0
        End If
        If (tickInterval > 4) Then
            tickInterval = 4
        End If
        Me.DischargeLabeledTickIntervalControl.Value = tickInterval

        If (0 < tickInterval) Then
            Me.DischargeFirstLabelOffsetLabel.Enabled = True
            Me.DischargeFirstLabelOffsetControl.Enabled = True
        Else
            Me.DischargeFirstLabelOffsetLabel.Enabled = False
            Me.DischargeFirstLabelOffsetControl.Enabled = False
        End If

        Me.DischargeDecimalsToShowControl.Label = Me.DischargeDecimalsToShowLabel.Text
        Me.DischargeDecimalsToShowControl.SiValue = mFlume.WGageDecimalsChoice(1)

        Me.DischargeFirstLabelOffsetControl.Label = Me.DischargeFirstLabelOffsetLabel.Text

    End Sub

    Private Sub UpdateFixedDischargeIntervalGage()

        Dim fixedDischargeCtrl As FixedDischargeDataControl = mWinFlumeForm.GetFixedDischargeDataControl
        fixedDischargeCtrl.ValidateDischargeSmartRange(mFlume)

        Dim Qmin As Single = mFlume.WGageQMin
        Dim Qmax As Single = mFlume.WGageQMax
        Dim Qinc As Single = mFlume.WGageQInc
        Dim P1 As Single = mFlume.SillHeight

        Dim RatingResults(1) As RatingResultsType
        Dim TableErrors(MaxHydErrors) As Boolean

        mFlume.MakeRating(QHTable, False, Qmin, Qmax, Qinc, RatingResults, TableErrors)

        Dim numRows As Integer = RatingResults.Length
        Dim headCol As Single(), distCol As Single(), flowCol As Single()
        ReDim headCol(numRows - 2)
        ReDim distCol(numRows - 2)
        ReDim flowCol(numRows - 2)

        Dim idx As Integer = 0
        For Each result As RatingResultsType In RatingResults
            If (result IsNot Nothing) Then
                headCol(idx) = result.SMALLh1
                distCol(idx) = CSng(result.SMALLh1 * Math.Sqrt(1 + mFlume.WGageZ ^ 2))
                flowCol(idx) = result.Q
                idx += 1
            End If
        Next result

        If (FixedDischargeIntervalGage Is Nothing) Then
            FixedDischargeIntervalGage = New ctl_WallGage
        End If

        If (mFlume.WGageSlopeChoice(1) = WallGageOnSlope) Then
            FixedDischargeIntervalGage.TickMarks = distCol
            FixedDischargeIntervalGage.GageSlope = mFlume.WGageZ
        Else
            FixedDischargeIntervalGage.TickMarks = headCol
            FixedDischargeIntervalGage.GageSlope = -1
        End If

        FixedDischargeIntervalGage.TickLabels = flowCol
        FixedDischargeIntervalGage.LabelUiUnits = UnitsDialog.UiDischargeUnitsText

        FixedDischargeIntervalGage.LabelFontSize = 150 * mFlume.WGageTextSize(1)
        FixedDischargeIntervalGage.LabelDecimals = mFlume.WGageDecimalsChoice(1)

        Dim labelIntervalIdx As Integer = mFlume.WGageTickIntervalChoice(1)
        If (labelIntervalIdx < 0) Then
            labelIntervalIdx = 0
        End If
        If (labelIntervalIdx > LabelIntervals.GetUpperBound(0)) Then
            labelIntervalIdx = LabelIntervals.GetUpperBound(0)
        End If
        Dim labelInterval As Integer = LabelIntervals(labelIntervalIdx)
        FixedDischargeIntervalGage.LabelInternal = labelInterval

        Dim firstLabel As Integer = mFlume.WGageFirstLabelOffset(1) Mod labelInterval
        FixedDischargeIntervalGage.LabelFirst = firstLabel + 1

        FixedDischargeIntervalGage.GenerateWallGage(mFlume)

    End Sub

    Private Sub UpdateFixedDischargePrintPages()

        If (FixedDischargeIntervalGage Is Nothing) Then
            Return
        End If

        Dim numPages As Integer = FixedDischargeIntervalGage.NumPages

        ReDim FixedDischargePrintPages(numPages - 1)

        For pageNo As Integer = 1 To numPages

            ' Get the wall gage section for this page
            Dim wallGage As ctl_Canvas2D = FixedDischargeIntervalGage.WallGageToPrint(pageNo)
            wallGage.Location = New Point(50, 50)

            ' Instantiate a new RTF Page
            Dim wallGagePage = New RtfPage With {
            .PageWidth = PortraitPageWidth,
            .PageHeight = PortraitPageLength,
            .TopMargin = PortraitTopMargin,
            .LeftMargin = PortraitLeftMargin,
            .RightMargin = PortraitRightMargin,
            .BottomMargin = PortraitBottomMargin,
            .Location = New Point(LeftOffset, TopOffset)
            }

            wallGagePage.Rtf.WordWrap = False
            wallGagePage.Rtf.ScrollBars = RichTextBoxScrollBars.None
            wallGagePage.AddImage(wallGage)

            FixedDischargePrintPages(pageNo - 1) = wallGagePage

        Next pageNo

    End Sub

#End Region

#End Region

#Region " Printing Methods "

#Region " Print Gage "

    '*********************************************************************************************************
    ' PrintWallGageDocument event handlers that actually print the requested results pages
    '*********************************************************************************************************
    Private Sub PrintWallGageDocument_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs) _
        Handles PrintWallGageDocument.BeginPrint
        mNextPageSelection = NumberOfFixedDischargePages() - 1
    End Sub

    Private Sub PrintWallGageDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) _
        Handles PrintWallGageDocument.PrintPage

        Try
            ' Get next page number to print
            mNextPageNo = mPageSelections(mNextPageSelection)

            Dim ResultsPage As RtfPage = FixedDischargePage(mNextPageNo)
            If (ResultsPage IsNot Nothing) Then

                ' Tell the next page to print itself
                ResultsPage.Print(e)

                ' If there are more pages to print; let caller know
                If (0 < mNextPageSelection) Then
                    mNextPageSelection -= 1
                    e.HasMorePages = True
                    Return
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        e.HasMorePages = False

    End Sub

#End Region

#Region " Fixed-Discharge Interval "

    '*********************************************************************************************************
    ' Function NumberOfFixedDischargePages() - return number of pages available to print
    ' Function FixedDischargePage()          - return specific RtfPage
    '*********************************************************************************************************
    Private Function NumberOfFixedDischargePages() As Integer
        Return Me.FixedDischargePrintPages.Count
    End Function

    Private Function FixedDischargePage(ByVal PageNumber As Integer) As RtfPage
        FixedDischargePage = Nothing
        If ((1 <= PageNumber) And (PageNumber <= NumberOfFixedDischargePages())) Then
            FixedDischargePage = Me.FixedDischargePrintPages(PageNumber - 1)
        End If
    End Function

    '*********************************************************************************************************
    ' Sub PrintFixedDischargeGage()  - called to print the wall gage pages
    '*********************************************************************************************************
    Public Sub PrintFixedDischargeGage()

        If (mWinFlumeForm Is Nothing) Then ' there is nothing to print
            Return
        End If

        mPrintingFixedDischargeGage = True

        UpdateFixedDischargeIntervalGage()
        UpdateFixedDischargePrintPages()

        If (NumberOfFixedDischargePages() < 0) Then ' there is nothing to print
            Return
        End If

        ' Start with full range of pages
        ReDim mPageSelections(1)
        mPageSelections(0) = 1
        mPageSelections(1) = NumberOfFixedDischargePages()

        If (mWinFlumeForm.PrintResults(Me.PrintWallGageDialog, 1, mPageSelections)) Then

            mNextPageNo = mPageSelections.Last

            ' Make sure the first page actually exists
            Dim page As RtfPage = FixedDischargePage(mNextPageNo)
            If (page IsNot Nothing) Then

                ' Set page to match the portrait results display
                Dim PortraitMargins As Margins = New Margins(PortraitLeftMargin - 10, PortraitRightMargin,
                                                             PortraitTopMargin, PortraitBottomMargin)

                Me.PrintWallGageDocument.DefaultPageSettings.Margins = PortraitMargins
                Me.PrintWallGageDocument.DefaultPageSettings.Landscape = False

                ' Print (which may cause exceptions)
                Try
                    Me.PrintWallGageDocument.Print()
                Catch ex As Exception
                    Debug.Assert(False, ex.Message)
                End Try
            End If
        End If

    End Sub

#End Region

#End Region

#Region " Event Handlers "

#Region " Wall Gage Plots "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub MyBase_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub MyBase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize

        Dim boxWidth As Integer = CInt(Me.Width / 2) - Me.Margin.Horizontal
        Dim boxHeight As Integer = Me.Height - Me.Margin.Vertical

        ' Fixed-Discharge Interval Gage
        Dim loc As Point = Me.FixedDischargeIntervalBox.Location
        loc.X = boxWidth + Me.Margin.Horizontal * 2

        Me.FixedDischargeIntervalBox.Location = loc
        Me.FixedDischargeIntervalBox.Width = boxWidth - Me.Margin.Horizontal
        Me.FixedDischargeIntervalBox.Height = boxHeight

        Me.FixedDischargeThumbnailLabel.Width = Me.FixedDischargeGagePanel.Width - Me.Margin.Horizontal * 2

        UpdateUI()
    End Sub

#End Region

#Region " Fixed-Discharge Interval "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub SlopedDischargeGageButton_ValueChanged(ByVal NewValue As Integer) _
        Handles SlopedDischargeGageButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageSlopeChoice(1) = NewValue) Then
                mFlume.WGageSlopeChoice(1) = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub VerticalDischargeGageButton_ValueChanged(ByVal NewValue As Integer) _
        Handles VerticalDischargeGageButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageSlopeChoice(1) = NewValue) Then
                mFlume.WGageSlopeChoice(1) = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeLabelSizeFactorUpDown_UpDownChanged() _
        Handles DischargeLabelSizeFactorUpDown.UpDownChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim labelSize As Single = Me.DischargeLabelSizeFactorUpDown.SiValue
            If Not (mFlume.WGageTextSize(1) = labelSize) Then
                mFlume.WGageTextSize(1) = labelSize
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeLabeledTickIntervalControl_ValueChange() _
        Handles DischargeLabeledTickIntervalControl.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim tickInterval As Integer = Me.DischargeLabeledTickIntervalControl.Value
            If Not (mFlume.WGageTickIntervalChoice(1) = tickInterval) Then
                mFlume.WGageTickIntervalChoice(1) = tickInterval
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeDecimalsToShowControl_UpDownChanged() _
        Handles DischargeDecimalsToShowControl.UpDownChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim decimals As Integer = CInt(Me.DischargeDecimalsToShowControl.SiValue)
            If Not (mFlume.WGageDecimalsChoice(1) = decimals) Then
                mFlume.WGageDecimalsChoice(1) = decimals
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeFirstLabelOffsetControl_UpDownChanged() _
        Handles DischargeFirstLabelOffsetControl.UpDownChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim labelIntervalIdx As Integer = mFlume.WGageTickIntervalChoice(1)
            If (labelIntervalIdx < 0) Then
                labelIntervalIdx = 0
            End If
            If (labelIntervalIdx > LabelIntervals.GetUpperBound(0)) Then
                labelIntervalIdx = LabelIntervals.GetUpperBound(0)
            End If
            Dim labelInterval As Integer = LabelIntervals(labelIntervalIdx)

            Dim firstLabelOffset As Integer = CInt(Me.DischargeFirstLabelOffsetControl.SiValue)
            If (firstLabelOffset < PrevLabelOffset(1)) Then ' Down-arrow
                mFlume.WGageFirstLabelOffset(1) -= 1
                If (mFlume.WGageFirstLabelOffset(1) < 0) Then
                    mFlume.WGageFirstLabelOffset(1) = labelInterval - 1
                End If
                PrevLabelOffset(1) = firstLabelOffset
                mWinFlumeForm.RaiseFlumeDataChanged()
            ElseIf (firstLabelOffset > PrevLabelOffset(1)) Then ' Up-arrow
                mFlume.WGageFirstLabelOffset(1) += 1
                If (mFlume.WGageFirstLabelOffset(1) > labelInterval - 1) Then
                    mFlume.WGageFirstLabelOffset(1) = 0
                End If
                PrevLabelOffset(1) = firstLabelOffset
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Button event handlers - Click, UndoButtonEvent, RedoButtonEvent
    '
    ' Note - Undo/Redo handling is specific to each Button since the action taken is not known to ctl_Button.
    '*********************************************************************************************************
    Private Sub ViewDischargeGageButton_Click(sender As Object, e As EventArgs) _
        Handles ViewDischargeGageButton.Click

        UpdateFixedDischargePrintPages()

        Dim viewer = New WallGageViewer With {
            .WallGage = FixedDischargeIntervalGage,
            .WallGagePages = FixedDischargePrintPages,
            .ViewAsMode = WallGageViewer.ViewAs.FullGage
        }
        viewer.UpdateUI()
        viewer.ShowDialog()
        viewer = Nothing
    End Sub

#End Region

#End Region

End Class
