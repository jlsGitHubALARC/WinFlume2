
'*************************************************************************************************************
' Class FlumeEquationReport - subclass for generating the Flume Equation Report
'*************************************************************************************************************
Imports Flume.Globals

Imports WinFlume.BasePage

Public Class FlumeDrawings
    Inherits BaseReport

#Region " Constants "

    Public BottomProfileLoc As Point = New Point(75, 150)       ' (0.75", 1.50")
    Public BottomProfileSize As Size = New Size(700, 275)       ' (7.00", 2.75")

    Public ApproachChannelLoc As Point = New Point(75, 450)     ' (0.75", 4.50")
    Public ControlSectionLoc As Point = New Point(315, 450)     ' (3.15", 4.50")
    Public TailwaterChannelLoc As Point = New Point(555, 450)   ' (5.55", 4.50")
    Public CrossSectionSize As Size = New Size(220, 275)        ' (2.20", 2.75")

    Public UpstreamViewLoc As Point = New Point(75, 750)        ' (0.75", 7.50")
    Public DownstreamViewLoc As Point = New Point(435, 750)     ' (4.35", 7.50")
    Public EndViewSize As Size = New Size(340, 275)             ' (3.40", 2.75")

#End Region

#Region " Report Methods "

    Public Overrides Sub GenerateReport()
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data
            If (mFlume Is Nothing) Then
                Return
            End If

            Dim version As String = WinFlumeForm.WinFlumeName() & " " & WinFlumeForm.WinFlumeVersion()

            ' Generate report page header
            Dim hdr As String = ""
            hdr = MyBase.ReportHeader()     ' Start with report header
            hdr &= vbCrLf & vbCrLf
            hdr &= TextOutput.CenterText(My.Resources.FlumeDrawings, PortraitWidthChars)
            hdr &= vbCrLf

            Dim ViewPort As New RectangleF
            Dim dGraphics As Graphics
            Dim WinFont As Font = mWinFlumeForm.WinFont
            Dim BoldFont As Font = mWinFlumeForm.WinBoldFont
            '
            ' Bottom Profile
            '
            ViewPort = New RectangleF(8, 16, BottomProfileSize.Width - 16, BottomProfileSize.Height)

            Dim crestType As Integer = mFlume.CrestType
            Dim crestText As String = CrestString(crestType)
            Dim bottomProfile As ctl_Canvas2D = New ctl_Canvas2D With {
                .Location = BottomProfileLoc,
                .Size = BottomProfileSize}
            bottomProfile.ClearCanvas()
            bottomProfile.DrawBorderLine(BlackPen1)
            bottomProfile.DrawTitle(My.Resources.BottomProfile & " ", BoldFont, Color.Black)
            bottomProfile.DrawSubTitle(crestText, WinFont, Color.Black)

            dGraphics = bottomProfile.GdiGraphics

            Dim bottomProfileCtrl As BottomProfileControl = mWinFlumeForm.GetBottomProfileControl
            bottomProfileCtrl.DrawBottomProfile(ViewPort, dGraphics)

            bottomProfile.ShowCanvas()
            '
            ' Cross Section Views
            '
            ViewPort = New RectangleF(16, 48, CrossSectionSize.Width - 32, CrossSectionSize.Height - 64)

            ' Approach Channel
            Dim controlShape As Integer = mFlume.Section(cApproach).Shape
            Dim shapeText As String = SectionString(controlShape)
            Dim approachChannel As ctl_Canvas2D = New ctl_Canvas2D With {
                .Location = ApproachChannelLoc,
                .Size = CrossSectionSize}
            approachChannel.ClearCanvas()
            approachChannel.DrawBorderLine(BlackPen1)
            approachChannel.DrawTitle(SectionDataString(cApproach), BoldFont, Color.Black)
            approachChannel.DrawSubTitle(shapeText, WinFont, Color.Black)

            dGraphics = approachChannel.GdiGraphics

            Dim approachViewCtrl As CrossSectionControl = mWinFlumeForm.GetApproachCrossSectionControl
            approachViewCtrl.DrawCrossSection(cApproach, ViewPort, dGraphics, BlackPen2)
            approachViewCtrl.AnnotateDrawing(dGraphics)

            approachChannel.ShowCanvas()

            ' Control Section
            controlShape = mFlume.Section(cControl).Shape
            shapeText = SectionString(controlShape)
            Dim controlSection As ctl_Canvas2D = New ctl_Canvas2D With {
                .Location = ControlSectionLoc,
                .Size = CrossSectionSize}
            controlSection.ClearCanvas()
            controlSection.DrawBorderLine(BlackPen1)
            controlSection.DrawTitle(SectionDataString(cControl), BoldFont, Color.DarkBlue)
            controlSection.DrawSubTitle(shapeText, WinFont, Color.DarkBlue)

            dGraphics = controlSection.GdiGraphics

            Dim controlViewCtrl As CrossSectionControl = mWinFlumeForm.GetControlCrossSectionControl
            controlViewCtrl.DrawCrossSection(cControl, ViewPort, dGraphics, BluePen2)
            controlViewCtrl.AnnotateDrawing(dGraphics)
            controlSection.ShowCanvas()

            ' Tailwater Channel
            controlShape = mFlume.Section(cTailwater).Shape
            shapeText = SectionString(controlShape)
            Dim tailwaterChannel As ctl_Canvas2D = New ctl_Canvas2D With {
                .Location = TailwaterChannelLoc,
                .Size = CrossSectionSize}
            tailwaterChannel.ClearCanvas()
            tailwaterChannel.DrawBorderLine(BlackPen1)
            tailwaterChannel.DrawTitle(SectionDataString(cTailwater), BoldFont, Color.Black)
            tailwaterChannel.DrawSubTitle(shapeText, WinFont, Color.Black)

            dGraphics = tailwaterChannel.GdiGraphics

            Dim tailwaterViewCtrl As CrossSectionControl = mWinFlumeForm.GetTailwaterCrossSectionControl
            tailwaterViewCtrl.DrawCrossSection(cTailwater, ViewPort, dGraphics, BlackPen2)
            tailwaterViewCtrl.AnnotateDrawing(dGraphics)
            tailwaterChannel.ShowCanvas()
            '
            ' End Views
            '
            ViewPort = New RectangleF(16, 32, EndViewSize.Width - 32, EndViewSize.Height - 48)

            ' Upstream View
            Dim upstreamView As ctl_Canvas2D = New ctl_Canvas2D With {
                .Location = UpstreamViewLoc,
                .Size = EndViewSize}
            upstreamView.ClearCanvas()
            upstreamView.DrawBorderLine(BlackPen1)
            upstreamView.DrawTitle(My.Resources.ViewFromUpstream, BoldFont, Color.Black)

            dGraphics = upstreamView.GdiGraphics

            Dim upstreamViewCtrl As UpstreamViewControl = mWinFlumeForm.GetUpstreamViewControl
            upstreamViewCtrl.DrawUpstreamView(ViewPort, dGraphics)
            upstreamView.ShowCanvas()

            ' Downstream View
            Dim downstreamView As ctl_Canvas2D = New ctl_Canvas2D With {
                .Location = DownstreamViewLoc,
                .Size = EndViewSize}
            downstreamView.ClearCanvas()
            downstreamView.DrawBorderLine(BlackPen1)
            downstreamView.DrawTitle(My.Resources.ViewFromDownstream, BoldFont, Color.Black)

            dGraphics = downstreamView.GdiGraphics

            Dim downstreamViewCtrl As DownstreamViewControl = mWinFlumeForm.GetDownstreamViewControl
            downstreamViewCtrl.DrawDownstreamView(ViewPort, dGraphics)
            downstreamView.ShowCanvas()
            '
            ' Load images and reports into report pages
            '
            ReDim mReportImages(5)
            mReportImages(0) = bottomProfile
            mReportImages(1) = approachChannel
            mReportImages(2) = controlSection
            mReportImages(3) = tailwaterChannel
            mReportImages(4) = upstreamView
            mReportImages(5) = downstreamView

            Dim rptPage As String = hdr

            ReDim mReportPages(0)
            mReportPages(0) = NewReportPage()
            mReportPages(0).Rtf.WordWrap = False
            mReportPages(0).Rtf.ScrollBars = RichTextBoxScrollBars.None
            mReportPages(0).Rtf.Text = rptPage

        End If
    End Sub

#End Region

End Class
