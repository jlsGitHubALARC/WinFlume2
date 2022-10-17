
'*************************************************************************************************************
' Class FixedHeadPlotControl - UserControl for generating the Wall Gage plots
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.BasePage
Imports System.Drawing.Printing

Public Class FixedHeadPlotControl

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
    Private mPrintingFixedHeadGage As Boolean = False
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
        ' Fixed-Head Interval Gage
        '
        UpdateFixedHeadIntervalControls()
        UpdateFixedHeadIntervalGage()

        If (FixedHeadIntervalGage IsNot Nothing) Then
            If (FixedHeadIntervalGage.GageBitmap IsNot Nothing) Then
                Me.FixedHeadGagePlot.Visible = True

                Dim srcWidth As Integer = CInt(FixedHeadIntervalGage.GageBitmap.Width)
                Dim srcHeight As Integer = CInt(FixedHeadIntervalGage.GageBitmap.Height)
                Dim srcRect As Rectangle = New Rectangle(0, 0, srcWidth, srcHeight)
                Dim srcRatio As Double = srcWidth / srcHeight

                ' Size & locate thumbnail plot
                Dim destloc As Point = Me.FixedHeadGagePlot.Location
                Dim destHeight As Integer = Me.FixedHeadGagePanel.Height - destloc.Y * 2
                Dim destWidth As Integer = CInt(destHeight * srcRatio)
                If (destWidth > Me.FixedHeadGagePanel.Width - Me.Margin.Horizontal * 2) Then
                    destWidth = Me.FixedHeadGagePanel.Width - Me.Margin.Horizontal * 2
                    destHeight = CInt(destWidth / srcRatio)
                End If
                destloc.X = CInt((Me.FixedHeadGagePanel.Width - destWidth) / 2)

                Me.FixedHeadGagePlot.Location = destloc
                Me.FixedHeadGagePlot.Width = destWidth
                Me.FixedHeadGagePlot.Height = destHeight

                ' Clone fixed-head gage to thumbnail
                Me.FixedHeadGagePlot.ClearCanvas()

                Dim headBitmap As Bitmap = Me.FixedHeadGagePlot.Bitmap1
                Dim headGraphics As Graphics = Me.FixedHeadGagePlot.GdiGraphics
                Dim headRect As Rectangle = New Rectangle(0, 0, headBitmap.Width, headBitmap.Height)

                headGraphics.DrawImage(FixedHeadIntervalGage.GageBitmap, headRect, srcRect, GraphicsUnit.Pixel)

                Me.FixedHeadGagePlot.ShowCanvas()
            Else
                Me.FixedHeadGagePlot.Visible = False
            End If
        Else
            Me.FixedHeadGagePlot.Visible = False
        End If

        mUpdatingUI = False
    End Sub

#End Region

#Region " Fixed-Head Interval "

    Private Sub UpdateFixedHeadIntervalControls()

        Me.SlopedHeadGageButton.Label = My.Resources.GageSlopeChoice
        Me.SlopedHeadGageButton.RbValue = WallGageOnSlope
        Me.SlopedHeadGageButton.UiValue = mFlume.WGageSlopeChoice(0)

        Me.VerticalHeadGageButton.Label = My.Resources.GageSlopeChoice
        Me.VerticalHeadGageButton.RbValue = WallGageVertical
        Me.VerticalHeadGageButton.UiValue = mFlume.WGageSlopeChoice(0)

        Me.HeadLabelSizeFactorUpDown.Label = My.Resources.GageTextSize
        Me.HeadLabelSizeFactorUpDown.SiValue = mFlume.WGageTextSize(0)

        Dim tickInterval As Integer = mFlume.WGageTickIntervalChoice(0)
        If (tickInterval < 0) Then
            tickInterval = 0
        End If
        If (tickInterval > 4) Then
            tickInterval = 4
        End If
        Me.HeadLabeledTickIntervalControl.Value = tickInterval

        If (0 < tickInterval) Then
            Me.HeadFirstLabelOffsetLabel.Enabled = True
            Me.HeadFirstLabelOffsetControl.Enabled = True
        Else
            Me.HeadFirstLabelOffsetLabel.Enabled = False
            Me.HeadFirstLabelOffsetControl.Enabled = False
        End If

        Me.HeadDecimalsToShowControl.Label = Me.HeadDecimalsToShowLabel.Text
        Me.HeadDecimalsToShowControl.SiValue = mFlume.WGageDecimalsChoice(0)

        Me.HeadFirstLabelOffsetControl.Label = Me.HeadFirstLabelOffsetLabel.Text

        Me.HeadLabelsButton.Label = My.Resources.GageLabelType
        Me.HeadLabelsButton.RbValue = WallGageHeadLabels
        Me.HeadLabelsButton.UiValue = mFlume.WGageHGageLabelType

        Me.FlowLabelsButton.Label = My.Resources.GageLabelType
        Me.FlowLabelsButton.RbValue = WallGageFlowLabels
        Me.FlowLabelsButton.UiValue = mFlume.WGageHGageLabelType

    End Sub

    Private Sub UpdateFixedHeadIntervalGage()

        Dim fixedHeadCtrl As FixedHeadDataControl = mWinFlumeForm.GetFixedHeadDataControl
        fixedHeadCtrl.ValidateHeadSmartRange(mFlume)

        Dim Hmin As Single = mFlume.WGageHMin
        Dim Hmax As Single = mFlume.WGageHMax
        Dim Hinc As Single = mFlume.WGageHInc
        Dim P1 As Single = mFlume.SillHeight

        Dim RatingResults(1) As RatingResultsType
        Dim TableErrors(MaxHydErrors) As Boolean

        mFlume.MakeRating(HQTable, False, Hmin, Hmax, Hinc, RatingResults, TableErrors)

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

        If (FixedHeadIntervalGage Is Nothing) Then
            FixedHeadIntervalGage = New ctl_WallGage
        End If

        If (mFlume.WGageSlopeChoice(0) = WallGageOnSlope) Then
            FixedHeadIntervalGage.TickMarks = distCol
            FixedHeadIntervalGage.GageSlope = mFlume.WGageZ
        Else
            FixedHeadIntervalGage.TickMarks = headCol
            FixedHeadIntervalGage.GageSlope = -1
        End If

        If (mFlume.WGageHGageLabelType = WallGageHeadLabels) Then
            FixedHeadIntervalGage.TickLabels = headCol
            FixedHeadIntervalGage.LabelUiUnits = UnitsDialog.UiLengthUnitsText
        Else
            FixedHeadIntervalGage.TickLabels = flowCol
            FixedHeadIntervalGage.LabelUiUnits = UnitsDialog.UiDischargeUnitsText
        End If

        FixedHeadIntervalGage.LabelFontSize = 150 * mFlume.WGageTextSize(0)
        FixedHeadIntervalGage.LabelDecimals = mFlume.WGageDecimalsChoice(0)

        Dim labelIntervalIdx As Integer = mFlume.WGageTickIntervalChoice(0)
        If (labelIntervalIdx < 0) Then
            labelIntervalIdx = 0
        End If
        If (labelIntervalIdx > LabelIntervals.GetUpperBound(0)) Then
            labelIntervalIdx = LabelIntervals.GetUpperBound(0)
        End If
        Dim labelInterval As Integer = LabelIntervals(labelIntervalIdx)
        FixedHeadIntervalGage.LabelInternal = labelInterval

        Dim firstLabel As Integer = mFlume.WGageFirstLabelOffset(0) Mod labelInterval
        FixedHeadIntervalGage.LabelFirst = firstLabel + 1

        FixedHeadIntervalGage.GenerateWallGage(mFlume)

    End Sub

    Private Sub UpdateFixedHeadPrintPages()

        If (FixedHeadIntervalGage Is Nothing) Then
            Return
        End If

        Dim numPages As Integer = FixedHeadIntervalGage.NumPages

        ReDim FixedHeadPrintPages(numPages - 1)

        For pageNo As Integer = 1 To numPages

            ' Get the wall gage section for this page
            Dim wallGage As ctl_Canvas2D = FixedHeadIntervalGage.WallGageToPrint(pageNo)
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

            FixedHeadPrintPages(pageNo - 1) = wallGagePage

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
        mNextPageSelection = NumberOfFixedHeadPages() - 1
    End Sub

    Private Sub PrintWallGageDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) _
        Handles PrintWallGageDocument.PrintPage

        Try
            ' Get next page number to print
            mNextPageNo = mPageSelections(mNextPageSelection)

            Dim ResultsPage As RtfPage = FixedHeadPage(mNextPageNo)
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

#Region " Fixed-Head Interval "

    '*********************************************************************************************************
    ' Function NumberOfFixedHeadPages() - return number of pages available to print
    ' Function FixedHeadPage()          - return specific RtfPage
    '*********************************************************************************************************
    Private Function NumberOfFixedHeadPages() As Integer
        Return Me.FixedHeadPrintPages.Count
    End Function

    Private Function FixedHeadPage(ByVal PageNumber As Integer) As RtfPage
        FixedHeadPage = Nothing
        If ((1 <= PageNumber) And (PageNumber <= NumberOfFixedHeadPages())) Then
            FixedHeadPage = Me.FixedHeadPrintPages(PageNumber - 1)
        End If
    End Function

    '*********************************************************************************************************
    ' Sub PrintFixedHeadGage()  - called to print the wall gage pages
    '*********************************************************************************************************
    Public Sub PrintFixedHeadGage()

        If (mWinFlumeForm Is Nothing) Then ' there is nothing to print
            Return
        End If

        mPrintingFixedHeadGage = True

        UpdateFixedHeadIntervalGage()
        UpdateFixedHeadPrintPages()

        If (NumberOfFixedHeadPages() < 0) Then ' there is nothing to print
            Return
        End If

        ' Start with full range of pages
        ReDim mPageSelections(1)
        mPageSelections(0) = 1
        mPageSelections(1) = NumberOfFixedHeadPages()

        If (mWinFlumeForm.PrintResults(Me.PrintWallGageDialog, 1, mPageSelections)) Then

            mNextPageNo = mPageSelections.Last ' print pages top-down

            ' Make sure the first page actually exists
            Dim page As RtfPage = FixedHeadPage(mNextPageNo)
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

        ' Fixed-Head Interval Gage
        Me.FixedHeadIntervalBox.Width = boxWidth
        Me.FixedHeadIntervalBox.Height = boxHeight

        Me.FixedHeadThumbnailLabel.Width = Me.FixedHeadGagePanel.Width - Me.Margin.Horizontal * 2

        UpdateUI()
    End Sub

#End Region

#Region " Fixed-Head Interval "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub SlopedHeadGageButton_ValueChanged(ByVal NewValue As Integer) _
        Handles SlopedHeadGageButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageSlopeChoice(0) = NewValue) Then
                mFlume.WGageSlopeChoice(0) = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub VerticalHeadGageButton_ValueChanged(ByVal NewValue As Integer) _
        Handles VerticalHeadGageButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageSlopeChoice(0) = NewValue) Then
                mFlume.WGageSlopeChoice(0) = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadLabelSizeFactorUpDown_UpDownChanged() _
        Handles HeadLabelSizeFactorUpDown.UpDownChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim labelSize As Single = Me.HeadLabelSizeFactorUpDown.SiValue
            If Not (mFlume.WGageTextSize(0) = labelSize) Then
                mFlume.WGageTextSize(0) = labelSize
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadLabeledTickIntervalControl_ValueChange() _
        Handles HeadLabeledTickIntervalControl.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim tickInterval As Integer = Me.HeadLabeledTickIntervalControl.Value
            If Not (mFlume.WGageTickIntervalChoice(0) = tickInterval) Then
                mFlume.WGageTickIntervalChoice(0) = tickInterval
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadDecimalsToShowControl_UpDownChanged() _
        Handles HeadDecimalsToShowControl.UpDownChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim decimals As Integer = CInt(Me.HeadDecimalsToShowControl.SiValue)
            If Not (mFlume.WGageDecimalsChoice(0) = decimals) Then
                mFlume.WGageDecimalsChoice(0) = decimals
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadFirstLabelOffsetControl_UpDownChanged() _
        Handles HeadFirstLabelOffsetControl.UpDownChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            Dim labelIntervalIdx As Integer = mFlume.WGageTickIntervalChoice(0)
            If (labelIntervalIdx < 0) Then
                labelIntervalIdx = 0
            End If
            If (labelIntervalIdx > LabelIntervals.GetUpperBound(0)) Then
                labelIntervalIdx = LabelIntervals.GetUpperBound(0)
            End If
            Dim labelInterval As Integer = LabelIntervals(labelIntervalIdx)

            Dim firstLabelOffset As Integer = CInt(Me.HeadFirstLabelOffsetControl.SiValue)
            If (firstLabelOffset < PrevLabelOffset(0)) Then ' Down-arrow
                mFlume.WGageFirstLabelOffset(0) -= 1
                If (mFlume.WGageFirstLabelOffset(0) < 0) Then
                    mFlume.WGageFirstLabelOffset(0) = labelInterval - 1
                End If
                PrevLabelOffset(0) = firstLabelOffset
                mWinFlumeForm.RaiseFlumeDataChanged()
            ElseIf (firstLabelOffset > PrevLabelOffset(0)) Then ' Up-arrow
                mFlume.WGageFirstLabelOffset(0) += 1
                If (mFlume.WGageFirstLabelOffset(0) > labelInterval - 1) Then
                    mFlume.WGageFirstLabelOffset(0) = 0
                End If
                PrevLabelOffset(0) = firstLabelOffset
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadLabelsButton_ValueChanged(ByVal NewValue As Integer) _
        Handles HeadLabelsButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageHGageLabelType = NewValue) Then
                mFlume.WGageHGageLabelType = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub FlowLabelsButton_ValueChanged(ByVal NewValue As Integer) _
        Handles FlowLabelsButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageHGageLabelType = NewValue) Then
                mFlume.WGageHGageLabelType = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Button event handlers - Click, UndoButtonEvent, RedoButtonEvent
    '
    ' Note - Undo/Redo handling is specific to each Button since the action taken is not known to ctl_Button.
    '*********************************************************************************************************
    Private Sub ViewHeadGageButton_Click(sender As Object, e As EventArgs) _
        Handles ViewHeadGageButton.Click

        UpdateFixedHeadPrintPages()

        Dim viewer = New WallGageViewer With {
            .WallGage = FixedHeadIntervalGage,
            .WallGagePages = FixedHeadPrintPages,
            .ViewAsMode = WallGageViewer.ViewAs.FullGage
        }
        viewer.UpdateUI()
        viewer.ShowDialog()
        viewer = Nothing
    End Sub

#End Region

#End Region

End Class
