
'*************************************************************************************************************
' Class WallGageControl - UserControl for generating the Flume's Wall Gages
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.BasePage
Imports System.Drawing.Printing

Imports WinFlume.UnitsDialog    ' Unit conversion support

Public Class WallGageControl

#Region " Member Data "
    '
    ' WinFlume's top-level User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mSection As Flume.SectionType = Nothing
    '
    ' Wall Gage Options data
    '
    Private Const DesiredLines As Integer = 30                  ' Rating Table entries after Smart Range
    '
    ' Gage data
    '
    Private PrevLabelOffset() As Integer = {-9999, -9999}
    Private LabelIntervals() As Integer = {1, 2, 4, 5, 10}
    '
    ' Printing support
    '
    Private mPrintingFixedHeadGage As Boolean = False
    Private mPrintingFixedDischargeGage As Boolean = False
    Private mPageSelections() As Integer = {1, 1}               ' Array of pages selected to print
    Private mNextPageSelection As Integer = 0                   ' Index of next page selection
    Private mNextPageNo As Integer = 1                          ' Next page number to print
    '
    ' Smart Range Undo/Redo data
    '
    Private Class SmartRangeUndoRedo
        Public RangeMin As Single
        Public RangeMax As Single
        Public RangeInc As Single
        Public Sub New(ByVal Min As Single, ByVal Max As Single, ByVal Inc As Single)
            Me.RangeMin = Min
            Me.RangeMax = Max
            Me.RangeInc = Inc
        End Sub
    End Class

#End Region

#Region " Properties "

    Public Property FixedHeadIntervalGage As ctl_WallGage
    Public Property FixedHeadPrintPages As RtfPage()

    Public Property FixedDischargeIntervalGage As ctl_WallGage
    Public Property FixedDischargePrintPages As RtfPage()

#End Region

#Region " Data Methods "

    Public Sub ValidateDischargeSmartRange(ByVal Flume As FlumeType)

        If (Flume IsNot Nothing) Then

            Dim Qmin As Single = Flume.WGageQMin
            Dim Qmax As Single = Flume.WGageQMax
            Dim Qinc As Single = Flume.WGageQInc

            If ((Qmin <= 0) And (Qmax <= 0) And (Qinc <= 0)) Then
                Flume.SmartRange(Qmin, Qmax, Qinc, QHTable, DesiredLines, False)
                Flume.WGageQMin = Qmin
                Flume.WGageQMax = Qmax
                Flume.WGageQInc = Qinc
            End If
        End If

    End Sub

    Public Sub ValidateHeadSmartRange(ByVal Flume As FlumeType)

        If (Flume IsNot Nothing) Then

            Dim Hmin As Single = Flume.WGageHMin
            Dim Hmax As Single = Flume.WGageHMax
            Dim Hinc As Single = Flume.WGageHInc

            If ((Hmin <= 0) And (Hmax <= 0) And (Hinc <= 0)) Then
                Flume.SmartRange(Hmin, Hmax, Hinc, HQTable, DesiredLines, False)
                Flume.WGageHMin = Hmin
                Flume.WGageHMax = Hmax
                Flume.WGageHInc = Hinc
            End If
        End If

    End Sub

#End Region

#Region " Printing Methods "

#Region " Print Gage "

    '*********************************************************************************************************
    ' PrintWallGageDocument event handlers that actually print the requested results pages
    '*********************************************************************************************************
    Private Sub PrintWallGageDocument_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs) _
        Handles PrintWallGageDocument.BeginPrint
        If (mPrintingFixedHeadGage) Then
            mNextPageSelection = NumberOfFixedHeadPages() - 1
        Else
            mNextPageSelection = NumberOfFixedDischargePages() - 1
        End If
    End Sub

    Private Sub PrintWallGageDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) _
        Handles PrintWallGageDocument.PrintPage

        Try
            ' Get next page number to print
            mNextPageNo = mPageSelections(mNextPageSelection)

            Dim ResultsPage As RtfPage = Nothing
            If (mPrintingFixedHeadGage) Then
                ResultsPage = FixedHeadPage(mNextPageNo)
            End If
            If (mPrintingFixedDischargeGage) Then
                ResultsPage = FixedDischargePage(mNextPageNo)
            End If
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
        mPrintingFixedDischargeGage = False

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

        mPrintingFixedHeadGage = False
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

#Region " UI Methods "

    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data
        If ((mFlume Is Nothing) Or (Not (Me.Visible))) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Debug.Assert(False)
            Return
        End If
        mUpdatingUI = True

        ' Update Wall Gage Type selection
        Me.FixedDischargeButton.Label = Me.GageTypeGroup.Text
        Me.FixedDischargeButton.RbValue = WallGageFixedDischarge
        Me.FixedDischargeButton.UiValue = mFlume.WGageType

        Me.FixedHeadButton.Label = Me.GageTypeGroup.Text
        Me.FixedHeadButton.RbValue = WallGageFixedHead
        Me.FixedHeadButton.UiValue = mFlume.WGageType

        ' Update corresponding Wall Gage user interface
        If (mFlume.WGageType = WallGageFixedHead) Then
            Me.DischargeControlPanel.Hide()
            Me.HeadControlPanel.Show()
            UpdateHeadControlsUI()

            Me.DischargeSplitContainer.Hide()
            Me.FixedDischargeGageBox.Hide()

            If (DataTableViewButton.Checked) Then
                Me.FixedHeadGageBox.Hide()
                Me.HeadSplitContainer.Show()
                UpdateHeadDataTable()
            Else
                Me.HeadSplitContainer.Hide()
                Me.FixedHeadGageBox.Show()
                UpdateHeadGagePlot()
            End If
        Else ' WallGageFixedDischarge
            Me.HeadControlPanel.Hide()
            Me.DischargeControlPanel.Show()
            UpdateDischargeControlsUI()

            Me.HeadSplitContainer.Hide()
            Me.FixedHeadGageBox.Hide()

            If (DataTableViewButton.Checked) Then
                Me.FixedDischargeGageBox.Hide()
                Me.DischargeSplitContainer.Show()
                UpdateDischargeDataTable()
            Else
                Me.DischargeSplitContainer.Hide()
                Me.FixedDischargeGageBox.Show()
                UpdateDischargeGagePlot()
            End If
        End If

        mUpdatingUI = False
    End Sub

#End Region

#Region " Fixed-Discharge UI "

    '*********************************************************************************************************
    ' Sub UpdateDischargeControlsUI() - update the Discharge Control panel
    '*********************************************************************************************************
    Protected Sub UpdateDischargeControlsUI()

        ValidateDischargeSmartRange(mFlume)

        Dim Qmin As Single = mFlume.WGageQMin
        Dim Qmax As Single = mFlume.WGageQMax
        Dim Qinc As Single = mFlume.WGageQInc
        Dim P1 As Single = mFlume.SillHeight

        ' Update Fixed-Discharge Interval parameters
        Me.MinimumDischargeSingle.SiUnits = DischargeUnitsAbbreviations(0)
        Me.MinimumDischargeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageQMin
        Me.MinimumDischargeSingle.SiValue = Qmin
        Me.MinimumDischargeSingle.Label = Me.MinimumDischargeLabel.Text

        Me.MaximumDischargeSingle.SiUnits = DischargeUnitsAbbreviations(0)
        Me.MaximumDischargeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageQMax
        Me.MaximumDischargeSingle.SiValue = Qmax
        Me.MaximumDischargeSingle.Label = Me.MaximumDischargeLabel.Text

        Me.DischargeIncrementSingle.SiUnits = DischargeUnitsAbbreviations(0)
        Me.DischargeIncrementSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageQInc
        Me.DischargeIncrementSingle.SiValue = Qinc
        Me.DischargeIncrementSingle.Label = Me.DischargeIncrementLabel.Text

        ' Update Wall Gage Options
        Me.DischargeSillReferencedButton.Label = Me.GageReferenceGroup.Text
        Me.DischargeSillReferencedButton.RbValue = WallGageRefTopOfSill
        Me.DischargeSillReferencedButton.UiValue = mFlume.WGageRef

        Me.DischargeUpstreamChannellBottomButton.Label = Me.GageReferenceGroup.Text
        Me.DischargeUpstreamChannellBottomButton.RbValue = WallGageRefApproachBottom
        Me.DischargeUpstreamChannellBottomButton.UiValue = mFlume.WGageRef

        Me.DischargeGageSlopeSingle.SiUnits = ""
        Me.DischargeGageSlopeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageZ
        Me.DischargeGageSlopeSingle.SiValue = mFlume.WGageZ
        Me.DischargeGageSlopeSingle.Label = "Z"

    End Sub

    Protected Sub UpdateDischargeGagePlot()

        ValidateDischargeSmartRange(mFlume)

        Dim Qmin As Single = mFlume.WGageQMin
        Dim Qmax As Single = mFlume.WGageQMax
        Dim Qinc As Single = mFlume.WGageQInc
        Dim P1 As Single = mFlume.SillHeight

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
                If ((0 < destWidth) And (0 < destHeight)) Then
                    Me.FixedDischargeGagePlot.ClearCanvas()

                    Dim dischargeBitmap As Bitmap = Me.FixedDischargeGagePlot.Bitmap1
                    Dim dischargeGraphics As Graphics = Me.FixedDischargeGagePlot.GdiGraphics
                    Dim dischargeRect As Rectangle = New Rectangle(0, 0, dischargeBitmap.Width, dischargeBitmap.Height)

                    dischargeGraphics.DrawImage(FixedDischargeIntervalGage.GageBitmap, dischargeRect, srcRect, GraphicsUnit.Pixel)

                    Me.FixedDischargeGagePlot.ShowCanvas()
                End If
            Else
                Me.FixedDischargeGagePlot.Visible = False
            End If
        Else
            Me.FixedDischargeGagePlot.Visible = False
        End If
    End Sub

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

        'Dim fixedDischargeCtrl As FixedDischargeDataControl = mWinFlumeForm.GetFixedDischargeDataControl
        'fixedDischargeCtrl.ValidateDischargeSmartRange(mFlume)

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

    Protected Sub UpdateDischargeDataTable()

        ValidateDischargeSmartRange(mFlume)

        Dim Qmin As Single = mFlume.WGageQMin
        Dim Qmax As Single = mFlume.WGageQMax
        Dim Qinc As Single = mFlume.WGageQInc
        Dim P1 As Single = mFlume.SillHeight

        ' Update Wall Gage data table
        Dim SiLunits As String = SiLengthUnitsText()
        Dim UiLunits As String = UiLengthUnitsText()

        Dim SiQunits As String = SiDischargeUnitsText()
        Dim UiQunits As String = UiDischargeUnitsText()

        Dim headColumnText As String = ""
        Dim distanceColumnText As String = ""
        Dim dischargeColumnText As String = ""
        Dim zRatio As String = mFlume.WGageZ.ToString & ":1 "
        Dim formatStyle As String = "0.000"

        If (mFlume.WGageRef = WallGageRefTopOfSill) Then ' Sill-Referenced
            headColumnText = My.Resources.SillReferenced
            distanceColumnText = My.Resources.SillReferenced
        Else ' Bottom-Referenced
            headColumnText = My.Resources.BottomReferenced
            distanceColumnText = My.Resources.BottomReferenced
        End If

        headColumnText &= vbCrLf & My.Resources.Head & " (" & UiLunits & ")"
        headColumnText &= vbCrLf & My.Resources.Vertical.ToLower

        distanceColumnText &= vbCrLf & My.Resources.Distance & " (" & UiLunits & ")"
        distanceColumnText &= vbCrLf & My.Resources.Slope.ToLower & " " & zRatio

        dischargeColumnText &= vbCrLf & My.Resources.Discharge
        dischargeColumnText &= vbCrLf & "(" & UiQunits & ")"

        Me.FixedDischargeIntervalTable.Columns(0).HeaderText = dischargeColumnText
        Me.FixedDischargeIntervalTable.Columns(1).HeaderText = headColumnText
        Me.FixedDischargeIntervalTable.Columns(2).HeaderText = distanceColumnText

        ' Update Wall Gage table data
        Dim RatingResults(1) As RatingResultsType
        Dim TableErrors(MaxHydErrors) As Boolean
        Dim uiValue As Single = 0

        mFlume.MakeRating(QHTable, False, Qmin, Qmax, Qinc, RatingResults, TableErrors)

        Me.FixedDischargeIntervalTable.Rows.Clear()

        For Each RatingResult As RatingResultsType In RatingResults
            If (RatingResult IsNot Nothing) Then

                Dim rowString(2) As String

                Dim h1 As Single = RatingResult.SMALLh1
                Dim Q As Single = RatingResult.Q

                Dim TotalH As Single = h1
                If (mFlume.WGageRef = WallGageRefApproachBottom) Then ' Bottom-Referenced; add Sill Height
                    TotalH += P1
                End If
                Dim Dist As Single = CSng(TotalH * Math.Sqrt(1 + mFlume.WGageZ ^ 2))

                uiValue = UiDischargeValue(Q, UiDischargeUnits)     ' Discharge
                rowString(0) = Format(uiValue, formatStyle)

                uiValue = UiLengthValue(TotalH, UiLengthUnits)      ' Head
                rowString(1) = Format(uiValue, formatStyle)

                uiValue = UiLengthValue(Dist, UiLengthUnits)        ' Distance
                rowString(2) = Format(uiValue, formatStyle)

                If (RatingResult.FatalError Or RatingResult.NonFatalError) Then
                    rowString(0) &= "*"
                End If

                Me.FixedDischargeIntervalTable.Rows.Add(rowString)

            End If
        Next RatingResult

        ' Update status
        Me.DischargeStatusPanel.Title.Text = My.Resources.AllWarningMessagesForThisTable
        Me.DischargeStatusPanel.StatusBox.Clear()

        Dim edx As Integer = 0
        Dim errText As String = ""
        Dim errLines As Integer = 0
        For Each errBool In TableErrors
            If (errBool) Then
                If (edx < 10) Then
                    errText &= " "
                End If
                errText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
                errLines += 1
            End If
            edx += 1
        Next errBool

        If (2 < errText.Length) Then
            errText = errText.Substring(0, errText.Length - 1)
        End If

        Me.DischargeStatusPanel.StatusBox.Text = errText

        ' Adjust splitter ratio
        Dim gageHeight As Integer = Me.DischargeSplitContainer.Height
        Dim statusHeight As Integer = Math.Max(80, Math.Min(130, errLines * 18 + 24))
        gageHeight -= statusHeight

        Me.DischargeSplitContainer.SplitterDistance = gageHeight
    End Sub

#End Region

#Region " Fixed-Head UI "

    '*********************************************************************************************************
    ' Sub UpdateHeadControlsUI() - update the Head Control panel
    '*********************************************************************************************************
    Protected Sub UpdateHeadControlsUI()

        ValidateHeadSmartRange(mFlume)

        Dim Hmin As Single = mFlume.WGageHMin
        Dim Hmax As Single = mFlume.WGageHMax
        Dim Hinc As Single = mFlume.WGageHInc
        Dim P1 As Single = mFlume.SillHeight

        ' Update Fixed-Head Interval parameters
        Me.MinimumHeadSingle.SiUnits = LengthUnitsAbbreviations(0)
        Me.MinimumHeadSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageHMin
        Me.MinimumHeadSingle.SiValue = Hmin
        Me.MinimumHeadSingle.Label = Me.MinimumHeadLabel.Text

        Me.MaximumHeadSingle.SiUnits = LengthUnitsAbbreviations(0)
        Me.MaximumHeadSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageHMax
        Me.MaximumHeadSingle.SiValue = Hmax
        Me.MaximumHeadSingle.Label = Me.MaximumHeadLabel.Text

        Me.HeadIncrementSingle.SiUnits = LengthUnitsAbbreviations(0)
        Me.HeadIncrementSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageHInc
        Me.HeadIncrementSingle.SiValue = Hinc
        Me.HeadIncrementSingle.Label = Me.HeadIncrementLabel.Text

        Me.HeadSillReferencedButton.Label = Me.GageReferenceGroup.Text
        Me.HeadSillReferencedButton.RbValue = WallGageRefTopOfSill
        Me.HeadSillReferencedButton.UiValue = mFlume.WGageRef

        Me.HeadUpstreamChannellBottomButton.Label = Me.GageReferenceGroup.Text
        Me.HeadUpstreamChannellBottomButton.RbValue = WallGageRefApproachBottom
        Me.HeadUpstreamChannellBottomButton.UiValue = mFlume.WGageRef

        Me.HeadGageSlopeSingle.SiUnits = ""
        Me.HeadGageSlopeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.WGageZ
        Me.HeadGageSlopeSingle.SiValue = mFlume.WGageZ
        Me.HeadGageSlopeSingle.Label = "Z"

    End Sub

    Protected Sub UpdateHeadGagePlot()

        ValidateHeadSmartRange(mFlume)

        Dim Hmin As Single = mFlume.WGageHMin
        Dim Hmax As Single = mFlume.WGageHMax
        Dim Hinc As Single = mFlume.WGageHInc
        Dim P1 As Single = mFlume.SillHeight

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

    End Sub

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

        'Dim fixedHeadCtrl As FixedHeadDataControl = mWinFlumeForm.GetFixedHeadDataControl
        'fixedHeadCtrl.ValidateHeadSmartRange(mFlume)

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

    Protected Sub UpdateHeadDataTable()

        ValidateHeadSmartRange(mFlume)

        Dim Hmin As Single = mFlume.WGageHMin
        Dim Hmax As Single = mFlume.WGageHMax
        Dim Hinc As Single = mFlume.WGageHInc
        Dim P1 As Single = mFlume.SillHeight

        ' Update Wall Gage data table
        Dim UiLunits As String = UiLengthUnitsText()
        Dim UiQunits As String = UiDischargeUnitsText()

        Dim headColumnText As String = ""
        Dim distanceColumnText As String = ""
        Dim dischargeColumnText As String = ""
        Dim zRatio As String = mFlume.WGageZ.ToString & ":1"

        If (mFlume.WGageRef = WallGageRefTopOfSill) Then ' Sill-Referenced
            headColumnText = My.Resources.SillReferenced
            distanceColumnText = My.Resources.SillReferenced
        Else ' Bottom-Referenced
            headColumnText = My.Resources.BottomReferenced
            distanceColumnText = My.Resources.BottomReferenced
        End If

        headColumnText &= vbCrLf & My.Resources.Head & " (" & UiLunits & ")"
        headColumnText &= vbCrLf & My.Resources.Vertical.ToLower

        distanceColumnText &= vbCrLf & My.Resources.Distance & " (" & UiLunits & ")"
        distanceColumnText &= vbCrLf & My.Resources.Slope.ToLower & " " & zRatio

        dischargeColumnText &= vbCrLf & My.Resources.Discharge
        dischargeColumnText &= vbCrLf & "(" & UiQunits & ")"

        Me.FixedHeadIntervalTable.Columns(0).HeaderText = headColumnText
        Me.FixedHeadIntervalTable.Columns(1).HeaderText = distanceColumnText
        Me.FixedHeadIntervalTable.Columns(2).HeaderText = dischargeColumnText

        ' Update Wall Gage table data
        Dim RatingResults(1) As RatingResultsType
        Dim TableErrors(MaxHydErrors) As Boolean
        Dim uiValue As Single = 0
        Dim formatStyle As String = "0.000"

        mFlume.MakeRating(HQTable, False, Hmin, Hmax, Hinc, RatingResults, TableErrors)

        Me.FixedHeadIntervalTable.Rows.Clear()

        For Each RatingResult As RatingResultsType In RatingResults
            If (RatingResult IsNot Nothing) Then

                Dim rowString(2) As String

                Dim h1 As Single = RatingResult.SMALLh1
                Dim Q As Single = RatingResult.Q

                Dim TotalH As Single = h1
                If (mFlume.WGageRef = WallGageRefApproachBottom) Then ' Bottom-Referenced; add Sill Height
                    TotalH += P1
                End If
                Dim Dist As Single = CSng(TotalH * Math.Sqrt(1 + mFlume.WGageZ ^ 2))

                uiValue = UiLengthValue(TotalH, UiLengthUnits)      ' Head
                rowString(0) = Format(uiValue, formatStyle)

                uiValue = UiLengthValue(Dist, UiLengthUnits)        ' Distance
                rowString(1) = Format(uiValue, formatStyle)

                uiValue = UiDischargeValue(Q, UiDischargeUnits)     ' Discharge
                rowString(2) = Format(uiValue, formatStyle)

                If (RatingResult.FatalError Or RatingResult.NonFatalError) Then
                    rowString(0) &= "*"
                End If

                Me.FixedHeadIntervalTable.Rows.Add(rowString)

            End If
        Next RatingResult

        ' Update status
        Me.HeadStatusPanel.Title.Text = My.Resources.AllWarningMessagesForThisTable
        Me.HeadStatusPanel.StatusBox.Clear()

        Dim edx As Integer = 0
        Dim errText As String = ""
        Dim errLines As Integer = 0
        For Each errBool In TableErrors
            If (errBool) Then
                If (edx < 10) Then
                    errText &= " "
                End If
                errText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
                errLines += 1
            End If
            edx += 1
        Next errBool

        If (2 < errText.Length) Then
            errText = errText.Substring(0, errText.Length - 1)
        End If

        Me.HeadStatusPanel.StatusBox.Text = errText

        ' Adjust splitter ratio
        Dim gageHeight As Integer = Me.HeadSplitContainer.Height
        Dim statusHeight As Integer = Math.Max(80, Math.Min(130, errLines * 18 + 24))
        gageHeight -= statusHeight

        Me.HeadSplitContainer.SplitterDistance = gageHeight

    End Sub

#End Region

#Region " Event Handlers "

#Region " Wall Gage Control "

    Private Sub WallGageControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DischargeSplitContainer.Dock = DockStyle.Fill
        Me.FixedDischargeGageBox.Dock = DockStyle.Fill
        Me.HeadSplitContainer.Dock = DockStyle.Fill
        Me.FixedHeadGageBox.Dock = DockStyle.Fill

        Me.GagePlotViewButton.Checked = True
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Resize handlers
    '*********************************************************************************************************
    Private Sub Mybase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize
        UpdateUI()
    End Sub

    Private Sub MyBase_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    Private Sub GagePlotViewButton_CheckedChanged(sender As Object, e As EventArgs) _
        Handles GagePlotViewButton.CheckedChanged
        If (Me.GagePlotViewButton.Checked) Then
            UpdateUI()
        End If
    End Sub

    Private Sub DataTableViewButton_CheckedChanged(sender As Object, e As EventArgs) _
        Handles DataTableViewButton.CheckedChanged
        If (Me.DataTableViewButton.Checked) Then
            UpdateUI()
        End If
    End Sub

    Private Sub FixedDischargeButton_ValueChanged(NewValue As Integer) _
        Handles FixedDischargeButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageType = NewValue) Then
                mFlume.WGageType = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub FixedHeadButton_ValueChanged(NewValue As Integer) _
        Handles FixedHeadButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageType = NewValue) Then
                mFlume.WGageType = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

#End Region

#Region " Fixed Discharge Gage "

#Region " Wall Gage Options "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub DischargeSillReferencedButton_ValueChanged(NewValue As Integer) _
        Handles DischargeSillReferencedButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageRef = NewValue) Then
                mFlume.WGageRef = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeUpstreamChannellBottomButton_ValueChanged(NewValue As Integer) _
        Handles DischargeUpstreamChannellBottomButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageRef = NewValue) Then
                mFlume.WGageRef = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeGageSlopeSingle_ValueChanged() _
        Handles DischargeGageSlopeSingle.ValueChanged
        Dim GageZ As Single = Me.DischargeGageSlopeSingle.SiValue
        If Not (mFlume.WGageZ = GageZ) Then
            mFlume.WGageZ = GageZ
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

#End Region

#Region " Fixed-Discharge Interval "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub MinimumDischargeRange_ValueChanged() _
        Handles MinimumDischargeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Qmin As Single = Me.MinimumDischargeSingle.SiValue
            If Not (mFlume.WGageQMin = Qmin) Then
                mFlume.WGageQMin = Qmin
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MaximumDischargeRange_ValueChanged() _
        Handles MaximumDischargeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Qmax As Single = Me.MaximumDischargeSingle.SiValue
            If Not (mFlume.WGageQMax = Qmax) Then
                mFlume.WGageQMax = Qmax
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DischargeIncrementSingle_ValueChanged() _
        Handles DischargeIncrementSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Qinc As Single = Me.DischargeIncrementSingle.SiValue
            If Not (mFlume.WGageQInc = Qinc) Then
                mFlume.WGageQInc = Qinc
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Button event handlers - Click, UndoButtonEvent, RedoButtonEvent
    '
    ' Note - Undo/Redo handling is specific to each Button since the action taken is not known to ctl_Button.
    '*********************************************************************************************************
    Private Sub DischargeSmartRangeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles DischargeSmartRangeButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Set current selections as Undo point
            Dim Qmin As Single = mFlume.WGageQMin
            Dim Qmax As Single = mFlume.WGageQMax
            Dim Qinc As Single = mFlume.WGageQInc
            Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Qmin, Qmax, Qinc)
            DischargeSmartRangeButton.AddUndoItem(SmartRangeUndo)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
            ' Set Smart Range values
            mFlume.SmartRange(Qmin, Qmax, Qinc, QHTable, DesiredLines, True)
            mFlume.WGageQMin = Qmin
            mFlume.WGageQMax = Qmax
            mFlume.WGageQInc = Qinc

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub DischargeSmartRangeButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles DischargeSmartRangeButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Redo point
                Dim Qmin As Single = mFlume.WGageQMin
                Dim Qmax As Single = mFlume.WGageQMax
                Dim Qinc As Single = mFlume.WGageQInc
                Dim SmartRangeRedo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Qmin, Qmax, Qinc)
                DischargeSmartRangeButton.AddRedoItem(SmartRangeRedo)
                ' Get Undo point's selections
                Dim SmartRangeUndo As SmartRangeUndoRedo = DirectCast(UndoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageQMin = SmartRangeUndo.RangeMin
                mFlume.WGageQMax = SmartRangeUndo.RangeMax
                mFlume.WGageQInc = SmartRangeUndo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub DischargeSmartRangeButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles DischargeSmartRangeButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Undo point
                Dim Qmin As Single = mFlume.WGageQMin
                Dim Qmax As Single = mFlume.WGageQMax
                Dim Qinc As Single = mFlume.WGageQInc
                Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Qmin, Qmax, Qinc)
                DischargeSmartRangeButton.AddUndoItem(SmartRangeUndo)
                ' Get Redo point's selections
                Dim SmartRangeRedo As SmartRangeUndoRedo = DirectCast(RedoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageQMin = SmartRangeRedo.RangeMin
                mFlume.WGageQMax = SmartRangeRedo.RangeMax
                mFlume.WGageQInc = SmartRangeRedo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#Region " Fixed-Discharge Gage "

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

    Private Sub PrintDischargeGageButton_Click(sender As Object, e As EventArgs) _
        Handles PrintDischargeGageButton.Click
        PrintFixedDischargeGage()
    End Sub

#End Region

#End Region

#Region " Fixed Head Gage "

#Region " Wall Gage Options "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub HeadSillReferencedButton_ValueChanged(NewValue As Integer) _
        Handles HeadSillReferencedButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageRef = NewValue) Then
                mFlume.WGageRef = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadUpstreamChannellBottomButton_ValueChanged(NewValue As Integer) _
        Handles HeadUpstreamChannellBottomButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.WGageRef = NewValue) Then
                mFlume.WGageRef = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadGageSlopeSingle_ValueChanged() _
        Handles HeadGageSlopeSingle.ValueChanged
        Dim GageZ As Single = Me.HeadGageSlopeSingle.SiValue
        If Not (mFlume.WGageZ = GageZ) Then
            mFlume.WGageZ = GageZ
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

#End Region

#Region " Fixed-Head Interval "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if the corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub MinimumHeadRange_ValueChanged() Handles MinimumHeadSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hmin As Single = Me.MinimumHeadSingle.SiValue
            If Not (mFlume.WGageHMin = Hmin) Then
                mFlume.WGageHMin = Hmin
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MaximumHeadRange_ValueChanged() Handles MaximumHeadSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hmax As Single = Me.MaximumHeadSingle.SiValue
            If Not (mFlume.WGageHMax = Hmax) Then
                mFlume.WGageHMax = Hmax
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub HeadIncrementSingle_ValueChanged() Handles HeadIncrementSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim Hinc As Single = Me.HeadIncrementSingle.SiValue
            If Not (mFlume.WGageHInc = Hinc) Then
                mFlume.WGageHInc = Hinc
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Button event handlers - Click, UndoButtonEvent, RedoButtonEvent
    '
    ' Note - Undo/Redo handling is specific to each Button since the action taken is not known to ctl_Button.
    '*********************************************************************************************************
    Private Sub HeadSmartRangeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles HeadSmartRangeButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Set current selections as Undo point
            Dim Hmin As Single = mFlume.WGageHMin
            Dim Hmax As Single = mFlume.WGageHMax
            Dim Hinc As Single = mFlume.WGageHInc
            Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
            HeadSmartRangeButton.AddUndoItem(SmartRangeUndo)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only
            ' Set Smart Range values
            mFlume.SmartRange(Hmin, Hmax, Hinc, HQTable, DesiredLines, True)
            mFlume.WGageHMin = Hmin
            mFlume.WGageHMax = Hmax
            mFlume.WGageHInc = Hinc

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub HeadSmartRangeButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles HeadSmartRangeButton.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Redo point
                Dim Hmin As Single = mFlume.WGageHMin
                Dim Hmax As Single = mFlume.WGageHMax
                Dim Hinc As Single = mFlume.WGageHInc
                Dim SmartRangeRedo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
                HeadSmartRangeButton.AddRedoItem(SmartRangeRedo)
                ' Get Undo point's selections
                Dim SmartRangeUndo As SmartRangeUndoRedo = DirectCast(UndoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageHMin = SmartRangeUndo.RangeMin
                mFlume.WGageHMax = SmartRangeUndo.RangeMax
                mFlume.WGageHInc = SmartRangeUndo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub HeadSmartRangeButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles HeadSmartRangeButton.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(SmartRangeUndoRedo)) Then
                ' Set current selections as Undo point
                Dim Hmin As Single = mFlume.WGageHMin
                Dim Hmax As Single = mFlume.WGageHMax
                Dim Hinc As Single = mFlume.WGageHInc
                Dim SmartRangeUndo As SmartRangeUndoRedo = New SmartRangeUndoRedo(Hmin, Hmax, Hinc)
                HeadSmartRangeButton.AddUndoItem(SmartRangeUndo)
                ' Get Redo point's selections
                Dim SmartRangeRedo As SmartRangeUndoRedo = DirectCast(RedoValue, SmartRangeUndoRedo)
                ' Restore range parameters
                mFlume.WGageHMin = SmartRangeRedo.RangeMin
                mFlume.WGageHMax = SmartRangeRedo.RangeMax
                mFlume.WGageHInc = SmartRangeRedo.RangeInc

                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

#End Region

#Region " Fixed-Head Gage "

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

    Private Sub PrintHeadGageButton_Click(sender As Object, e As EventArgs) Handles _
        PrintHeadGageButton.Click
        PrintFixedHeadGage()
    End Sub

#End Region

#End Region

#End Region

End Class
