
'*************************************************************************************************************
' ctl_WallGage - Control for drawing & printing a Flume Wall Gage.
'
' Graphics UI object hierarchy:
'
'   System.Windows.Forms.PictureBox
'       ex_PictureBox
'           ctl_Canvas2D
'               ctl_WallGage
'*************************************************************************************************************
Imports WinFlume.UnitsDialog
Imports Flume.Globals

Public Class ctl_WallGage
    Inherits ctl_Canvas2D

#Region " Member Data "

    Public Formats() As String = {"0", "0.0", "0.00", "0.000", "0.0000", "0.00000"}

#End Region

#Region " Properties "

    ' Printed page dimensions (in inches); default is Portrait page with 0.5" margins
    Public Property PageWidth As Single = 8.5!
    Public Property PageHeight As Single = 11.0!
    Public Property PageMargin As Single = 0.5!
    Public Property PPI As Integer = 100            ' Pixels / Inch for display

    ' Gage dimensions (in inches); default is Portrait page less margins
    Public Property GageWidth As Single = 7.5!
    Public Property GageHeight As Single = 10.0!
    Public Property GageSlope As Single = 1.0!

    ' Gage properties are all in SI units (m, m³/s)
    Public Property TickMarks As Single()                                   ' m
    Public Property MarkSiUnits As String = LengthUnitsAbbreviations(0)
    Public Property MarkUiUnits As String = MarkSiUnits

    Public Property TickLabels As Single()                                  ' m | m³/s
    Public Property LabelSiUnits As String = LengthUnitsAbbreviations(0)
    Public Property LabelUiUnits As String = LabelSiUnits
    Public Property LabelInternal As Integer = 4
    Public Property LabelFirst As Integer = 1
    Public Property LabelDecimals As Integer = 2
    Public Property LabelFontName As String = Me.Font.FontFamily.Name
    Public Property LabelFontSize As Single = 100
    Public Property LabelFont As Font = New Font(LabelFontName, LabelFontSize)

    Public Property TextFontSize As Single = 8
    Public Property TextFont As Font = New Font(mFontName, TextFontSize)

    Public Property MinTick As Single   ' Min tick for labeling
    Public Property MaxTick As Single   ' Max   "   "      "
    Public Property TopTick As Single   ' Top of gage tick for scaling
    Public Property OffTick As Single   ' Offset from bottom of Wall Gage

    Public Property NumPages As Integer

    ' Drawing tools
    Public Property GageBitmap As Bitmap
    Public Property GageGraphics As Graphics

#End Region

#Region " Wall Gage Generation "

    '*********************************************************************************************************
    ' Sub GenerateWallGage() - generate the Wall Gage based on input properties
    '
    ' Input(s):     FlumeRef    - reference to current Flume.dll FlumeType object
    '*********************************************************************************************************
    Public Sub GenerateWallGage(ByVal FlumeRef As Flume.FlumeType)

        If (TickMarks Is Nothing) Then               ' Must have valid Tick Mark data to continue
            Return
        ElseIf (TickMarks.Length < 2) Then
            Return
        End If

        Array.Sort(TickMarks) ' just to make sure

        If (TickLabels Is Nothing) Then              ' If no Tick Labels specified; use Tick Marks
            TickLabels = TickMarks
        ElseIf (TickLabels.Length = 0) Then
            TickLabels = TickMarks
        End If

        Debug.Assert(TickMarks.Length = TickLabels.Length)

        LabelFont = New Font(LabelFontName, LabelFontSize)

        MinTick = TickMarks.Min ' Tick values are in SI units
        MaxTick = TickMarks.Max

        Debug.Assert(MinTick = TickMarks.First)
        Debug.Assert(MaxTick = TickMarks.Last)

        ' Define Gage dimensions (in inches) for one printed page
        GageWidth = PageWidth - 2 * PageMargin
        GageHeight = PageHeight - 2 * PageMargin

        ' Define Gage dimensions (in inches) for all printed pages
        Dim gageMaxY As Single = UiLengthValue(MaxTick, LengthUnits.Inches)     ' Max gage tick mark
        Dim gageOffY As Single = 0                                              ' Gage bottom offset
        If (FlumeRef.WGageRef = WallGageRefApproachBottom) Then
            gageOffY = UiLengthValue(FlumeRef.SillHeight, LengthUnits.Inches)
        End If

        NumPages = CInt(Math.Ceiling((gageMaxY + gageOffY + 3 * PageMargin) / GageHeight))

        TopTick = SiLengthValue(NumPages * GageHeight, LengthUnits.Inches)
        OffTick = SiLengthValue(gageOffY, LengthUnits.Inches)

        ' Define Wall Gage Bitmap in PPI for displaying
        Me.Width = CInt(GageWidth * PPI)
        Me.Height = CInt(GageHeight * NumPages * PPI)

        Try
            Me.ClearCanvas()                    ' Start a new Gage Plot
            Me.DrawBorderLine(BlackPen2)

            GageBitmap = Me.Bitmap1
            GageGraphics = Me.GdiGraphics

            GenerateWallGagePlot(FlumeRef)      ' Generate Gage Plot

            Me.ShowCanvas()                     ' Display Gage Plot
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub

    Private Sub GenerateWallGagePlot(ByVal FlumeRef As Flume.FlumeType)
        '
        ' Calculate size (width & height) of tick marks
        '
        Dim tickMarkSize As SizeF = GdiGraphics.MeasureString("X", LabelFont)

        ' X width of tick marks
        Dim minorWidth As Integer = Math.Max(CInt(tickMarkSize.Width / 2), 5)
        Dim interWidth As Integer = CInt(minorWidth * 1.5)
        Dim majorWidth As Integer = minorWidth * 2

        ' Y height of tick marks
        Dim minorHeight As Integer = Math.Max(CInt(tickMarkSize.Height / 32), 1)
        If (IsEven(minorHeight)) Then ' ensure minor tick height is odd
            minorHeight -= 1
        End If
        minorHeight = Math.Min(minorHeight, 5)

        Dim interHeight As Integer = minorHeight + 2
        Dim majorHeight As Integer = minorHeight + 4

        Dim minorPen As New Pen(System.Drawing.Color.Black, minorHeight)
        Dim interPen As New Pen(System.Drawing.Color.Black, interHeight)
        Dim majorPen As New Pen(System.Drawing.Color.Black, majorHeight)

        ' 1/2 pen width adjustments
        Dim minorHalf As Integer = CInt(Math.Round((minorHeight / 2), MidpointRounding.AwayFromZero))
        Dim interHalf As Integer = CInt(Math.Round((interHeight / 2), MidpointRounding.AwayFromZero))
        Dim majorHalf As Integer = CInt(Math.Round((majorHeight / 2), MidpointRounding.AwayFromZero))

        ' Get text to add to wall gage
        Dim baseline As String = My.Resources.BottomBaselineIsTopOfSill & "  "
        If (FlumeRef.WGageRef = WallGageRefApproachBottom) Then
            baseline = My.Resources.BottomBaselineIsInverftUpstream & "  "
        End If
        If (GageSlope < 0) Then
            baseline &= My.Resources.InstallGageVertically
        Else
            baseline &= My.Resources.InstallOnSlopeOf & " " & GageSlope.ToString & ":1 (h/v)"
        End If

        Dim filepath As String = Trim(FlumeRef.FlumeName)
        Dim description As String = Trim(FlumeRef.Description)
        description &= " - " & My.Resources.Revision & ": " & FlumeRef.Revision

        ' Draw right-side tick axis
        Dim XL As Integer = CInt(PPI * PageMargin)                  ' X Left
        Dim XR As Integer = Me.Width - CInt(PPI * PageMargin)       ' X Right
        Dim YT As Integer = CInt(PPI * PageMargin)                  ' Y Top
        Dim YB As Integer = Me.Height - CInt(PPI * PageMargin)      ' Y Bottom

        Debug.Assert((0 <= XL) And (0 < XR) And (0 <= YT) And (0 < YB))

        Dim tickY As Integer = YB
        Dim pt1 As New Point(XR - majorHalf, tickY)

        Dim len As Integer = Math.Min(CInt((MaxTick + OffTick) * Me.Height / TopTick), YB)
        tickY = YB - len
        Dim pt2 As New Point(XR - majorHalf, tickY)

        GageGraphics.DrawLine(majorPen, pt1, pt2)

        ' Draw gage units; make sure they fit on page
        Dim unitsFont = New Font(LabelFontName, LabelFontSize * 3.0! / 4.0!)
        Dim strSize As SizeF = GageGraphics.MeasureString(LabelUiUnits, unitsFont)
        Dim strX As Integer = CInt(XR - strSize.Width + majorHalf)
        Dim strY As Integer = CInt(pt2.Y - strSize.Height + majorHalf)

        If (strX < (XR - majorWidth - majorHalf)) Then
            Dim unitsSize As Single = LabelFontSize
            While (strX < (XR - majorWidth - majorHalf))
                unitsSize *= 0.99!
                unitsFont = New Font(LabelFontName, unitsSize)
                strSize = GageGraphics.MeasureString(LabelUiUnits, unitsFont)
                strX = CInt(XR - strSize.Width + majorHalf)
                strY = CInt(pt2.Y - strSize.Height + majorHalf)
            End While
        End If

        If (strY < 0) Then
            Dim unitsSize As Single = LabelFontSize
            While (strY < 0)
                unitsSize *= 0.99!
                unitsFont = New Font(LabelFontName, unitsSize)
                strSize = GageGraphics.MeasureString(LabelUiUnits, unitsFont)
                strX = CInt(XR - strSize.Width + majorHalf)
                strY = CInt(pt2.Y - strSize.Height + majorHalf)
            End While
        End If

        GageGraphics.DrawString(LabelUiUnits, unitsFont, BlackSolidBrush, strX, strY)

        ' Draw bottom baseline
        tickY = YB - interHalf
        pt1 = New Point(XL, tickY)
        pt2 = New Point(XR, tickY)

        GageGraphics.DrawLine(interPen, pt1, pt2)

        ' Add baseline text
        strSize = GageGraphics.MeasureString(baseline, TextFont)
        strX = pt1.X
        strY = CInt(pt1.Y - interHalf - strSize.Height)
        GageGraphics.DrawString(baseline, TextFont, BlackSolidBrush, strX, strY)

        strY = CInt(pt1.Y + interHalf + 1)
        GageGraphics.DrawString(filepath, TextFont, BlackSolidBrush, strX, strY)

        strY += CInt(strSize.Height)
        GageGraphics.DrawString(description, TextFont, BlackSolidBrush, strX, strY)

        ' Draw minor tick marks
        For Each tickMark As Single In TickMarks
            tickY = YB - CInt((tickMark + OffTick) * Me.Height / TopTick)

            pt1 = New Point(XR - minorWidth, tickY)
            pt2 = New Point(XR, tickY)

            GageGraphics.DrawLine(minorPen, pt1, pt2)
        Next tickMark

        ' Draw intermediate tick marks, if needed
        If (IsEven(LabelInternal)) Then
            For tdx As Integer = LabelFirst - 1 To TickMarks.Length - 1 Step CInt(LabelInternal / 2)
                Dim tickMark As Single = TickMarks(tdx)
                tickY = YB - CInt((tickMark + OffTick) * Me.Height / TopTick)

                pt1 = New Point(XR - interWidth, tickY)
                pt2 = New Point(XR, tickY)

                GageGraphics.DrawLine(interPen, pt1, pt2)
            Next tdx
        End If

        ' Draw major tick marks & labels
        For tdx As Integer = LabelFirst - 1 To TickMarks.Length - 1 Step LabelInternal
            ' Tick marks
            Dim tickMark As Single = TickMarks(tdx)
            tickY = YB - CInt((tickMark + OffTick) * Me.Height / TopTick)

            pt1 = New Point(XR - majorWidth, tickY)
            pt2 = New Point(XR, tickY)

            GageGraphics.DrawLine(majorPen, pt1, pt2)

            pt1.X -= minorHeight
            GageGraphics.DrawLine(minorPen, pt1, pt2)

            ' Labels
            Dim siLabel As Single = TickLabels(tdx)
            Dim uiLabel As Single = UiValue(siLabel, LabelUiUnits)

            If (LabelDecimals < 0) Then
                LabelDecimals = 0
            End If
            If (LabelDecimals > Formats.GetUpperBound(0)) Then
                LabelDecimals = Formats.GetUpperBound(0)
            End If
            Dim label As String = Format(uiLabel, Formats(LabelDecimals))

            strSize = GageGraphics.MeasureString(label, LabelFont)
            strX = CInt(pt1.X - strSize.Width)
            strY = CInt(pt1.Y - strSize.Height / 2 + majorHalf)

            GageGraphics.DrawString(label, LabelFont, BlackSolidBrush, strX, strY)

        Next tdx

    End Sub

    '*********************************************************************************************************
    ' Function WallGageToPrint() - return the specified Wall Gage page bitmap for printing
    '
    ' Input(s):     PageNum     - page number of bitmap to return
    '
    ' Returns:      ctl_Canvas2D    - PictureBox containing bitmap of specified Wall Gage page
    '*********************************************************************************************************
    Public Function WallGageToPrint(ByVal PageNum As Integer) As ctl_Canvas2D
        WallGageToPrint = Nothing

        If (GageBitmap IsNot Nothing) Then
            If ((1 <= PageNum) And (PageNum <= NumPages)) Then

                ' Locate rectangle within Wall Gage bitmap for specified page
                Dim pageWidth As Integer = CInt(GageWidth * PPI)
                Dim pageHeight As Integer = CInt(GageHeight * PPI)
                Dim srcY As Integer = (NumPages - PageNum) * pageHeight

                Dim gageRect As Rectangle = New Rectangle(0, srcY, pageWidth, pageHeight)

                ' Initialize blank canvas for page bitmap
                WallGageToPrint = New ctl_Canvas2D
                WallGageToPrint.Width = pageWidth
                WallGageToPrint.Height = pageHeight

                WallGageToPrint.ClearCanvas()

                ' Fill page bitmap with single page from Wall Gage bimap
                Dim pageBitmap As Bitmap = WallGageToPrint.Bitmap1
                Dim pageGraphics As Graphics = WallGageToPrint.GdiGraphics
                Dim pageRect As Rectangle = New Rectangle(0, 0, pageWidth, pageHeight)

                pageGraphics.DrawImage(GageBitmap, pageRect, gageRect, GraphicsUnit.Pixel)

                WallGageToPrint.ShowCanvas()

            End If
        End If

    End Function

#End Region

End Class
