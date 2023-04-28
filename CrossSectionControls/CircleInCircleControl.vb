
'*************************************************************************************************************
' Class CircleInCircleControl           - UserControl for drawing & editing a Circle cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'   Note - Inherits statement is found in the file: CircleInCircleControl.Designer.vb
'*************************************************************************************************************
Imports WinFlume.WinFlumeSectionType

Public Class CircleInCircleControl
    Inherits CrossSectionControl

#Region " Constants "

    Protected Const Half As Integer = 50
    Protected Const NumPts As Integer = Half * 2

#End Region

#Region " Constructor(s) "

    '*********************************************************************************************************
    ' Sub New() - Constructor
    '
    ' Input(s):     SectionIdx  - index selection for Flume Section
    '*********************************************************************************************************
    Public Sub New(ByVal SectionIdx As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Type all your code here! This code will be executed before the "FormLoad" if you call your new form

        mFlume = WinFlumeForm.Flume                 ' Reference to Flume data; may be Nothing
        mSectionIdx = SectionIdx                ' Flume.Section index

    End Sub

#End Region

#Region " Outline Methods "

    '*********************************************************************************************************
    ' Functions:    OuterOutline()      - left edge, invert, right edge
    '               InnerOutline()      - left edge, sill, right edge     - baseclass default is OuterOutline
    '               InvertOutline()     - invert (left to right)          - extracted from OuterOutline
    '
    ' Input(s):     SectionIdx  - index indicating section type (cApproach, cControl, cTailwater)
    '               ViewPort    - rectangle defining area to draw graphic within
    '
    ' Over-riden methods should call baseclass method to initialize cross section data
    '
    ' Note - all outlines are generated counter-clock wise
    '*********************************************************************************************************
    Public Overrides Function OuterOutline(ByVal SectionIdx As Integer,
                                           ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Baseclass initializes cross section data
            MyBase.OuterOutline(SectionIdx, ViewPort)

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim SH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim ODF As Single = mOuterDiamFocalDist     ' Outer Diameter / Focal Distance(2f)

            Dim D1 As Single = mSection.D1              ' Inner sill height
            Dim CH As Single = SH - D1                  ' Circle height from canal bottom
            Dim OD As Single = CD - CH                  ' Circle depth from canal top
            '
            ' Calculate circle cross section shape in world coordinates
            '
            Dim circle(NumPts) As PointF

            ' Counter-clockwise (left edge top-to-bottom) then (right edge bottom-to-top)
            Dim r As Double = ODF / 2                       ' radius
            Dim cx As Double = 0                            ' circle origin (i.e. center)
            Dim cy As Double = r                            ' 
            Dim a As Double = Math.PI / 2                   ' angle in radians of circle top
            Dim inc As Double = Math.PI / Half

            Dim x As Single = CSng(cx + r * Math.Cos(a))    ' top of circle
            Dim y As Single = CSng(cy + r * Math.Sin(a))

            If (y > OD) Then ' circle extends above canal
                a = Math.Asin((OD - cy) / r)
                inc = (2 * a + Math.PI) / NumPts
                a = Math.PI - a
            End If

            For pdx = 0 To NumPts
                x = CSng(cx + r * Math.Cos(a))
                y = CSng(cy + r * Math.Sin(a))
                circle(pdx) = New PointF(x, y)
                a += inc
            Next
            '
            ' Translate to drawing coordinates
            '
            For pdx As Integer = 0 To NumPts
                x = circle(pdx).X
                y = OD - circle(pdx).Y ' invert Y
                x *= mHorzScale
                y *= mVertScale
                x += mViewPort.X + mHorzOffset
                y += mViewPort.Y + mVertOffset
                circle(pdx).X = x
                circle(pdx).Y = y
            Next pdx

            ' Center in ViewPort
            Dim xhalf As Single = CInt((circle(0).X + circle(NumPts).X) / 2)
            Dim xOffset As Single = mViewPort.X + mViewPort.Width / 2 - xhalf
            For pdx As Integer = 0 To NumPts
                x = circle(pdx).X + xOffset
                circle(pdx).X = x
            Next pdx

            OuterOutline = circle
        Catch ex As Exception
            OuterOutline = Nothing
        End Try
    End Function

    Public Overrides Function InnerOutline(ByVal SectionIdx As Integer,
                                           ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Baseclass initializes cross section data
            MyBase.InnerOutline(SectionIdx, ViewPort)

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim BH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim DF As Single = mDiamFocalDist           ' Diameter / Focal Distance(2f)
            Dim SH As Single = CD - BH                  ' Section height
            '
            ' Calculate circle cross section shape in world coordinates
            '
            Dim circle(NumPts) As PointF

            ' Counter-clockwise (left edge top-to-bottom) then (right edge bottom-to-top)
            Dim r As Double = DF / 2                        ' radius
            Dim cx As Double = 0                            ' circle origin (i.e. center)
            Dim cy As Double = r                            ' 
            Dim a As Double = Math.PI / 2                   ' angle in radians of circle top
            Dim inc As Double = Math.PI / Half

            Dim x As Single = CSng(cx + r * Math.Cos(a))    ' top of circle
            Dim y As Single = CSng(cy + r * Math.Sin(a))

            If (y > SH) Then ' circle extends above canal
                a = Math.Asin((SH - cy) / r)
                inc = (2 * a + Math.PI) / NumPts
                a = Math.PI - a
            End If

            For pdx = 0 To NumPts
                x = CSng(cx + r * Math.Cos(a))
                y = CSng(cy + r * Math.Sin(a))
                circle(pdx) = New PointF(x, y)
                a += inc
            Next
            '
            ' Translate to drawing coordinates
            '
            For pdx As Integer = 0 To NumPts
                x = circle(pdx).X
                y = SH - circle(pdx).Y ' invert Y
                x *= mHorzScale
                y *= mVertScale
                x += mViewPort.X + mHorzOffset
                y += mViewPort.Y + mVertOffset
                circle(pdx).X = x
                circle(pdx).Y = y
            Next pdx

            ' Center in ViewPort
            Dim xhalf As Single = CInt((circle(0).X + circle(NumPts).X) / 2)
            Dim xOffset As Single = mViewPort.X + mViewPort.Width / 2 - xhalf
            For pdx As Integer = 0 To NumPts
                x = circle(pdx).X + xOffset
                circle(pdx).X = x
            Next pdx

            InnerOutline = circle
        Catch ex As Exception
            InnerOutline = Nothing
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete circle outline
            Dim circle As PointF() = Me.InnerOutline(SectionIdx, ViewPort)
            ' Extract invert outline from circle outline
            Dim Half As Integer = CInt(circle.GetUpperBound(0) / 2)
            Dim invert(1) As PointF

            invert(0) = circle(Half)
            invert(1) = circle(Half)

            InvertOutline = invert
        Catch ex As Exception
            InvertOutline = Nothing
        End Try
    End Function

    Public Overrides Function TruncatedRampOutline(ByVal SectionIdx As Integer,
                                                   ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Start with the invert outline
            Dim invert As PointF() = Me.InvertOutline(SectionIdx, ViewPort)
            ' Move the invert up to the truncated ramp end
            Dim tRamp(1) As PointF

            Dim SH As Single = mSillHeight              ' Sill height
            Dim BD As Single = mBedDrop                 ' Bed drop
            Dim RH As Single = (SH + BD) / 2            ' Truncated ramp height
            Dim DF As Single = mDiamFocalDist           ' Circle diameter

            If (RH < DF) Then

                Dim r As Double = DF / 2
                Dim d As Double = r - RH
                Dim c As Double = 2 * r * Math.Sqrt(1 - (d / r) ^ 2)

                Dim dx As Single = CSng(c * mHorzScale / 2)
                Dim dy As Single = RH * mVertScale

                tRamp(0).X = invert(0).X - dx
                tRamp(0).Y = invert(0).Y - dy
                tRamp(1).X = invert(1).X + dx
                tRamp(1).Y = invert(1).Y - dy
            Else
                Dim dx As Single = 0
                Dim dy As Single = DF * mVertScale

                tRamp(0).X = invert(0).X - dx
                tRamp(0).Y = invert(0).Y - dy
                tRamp(1).X = invert(1).X + dx
                tRamp(1).Y = invert(1).Y - dy
            End If

            TruncatedRampOutline = tRamp
        Catch ex As Exception
            TruncatedRampOutline = Nothing
        End Try
    End Function

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateControlValues() - update contained Controls' values
    '*********************************************************************************************************
    Protected Overrides Sub UpdateControlValues()
        MyBase.UpdateControlValues()

        ' Inner Circle diameter
        Me.DiameterSingle.Label = DiameterKey.BaseText
        Me.DiameterSingle.SiDefaultValue = mDefaultSection.DiameterFocalD
        Me.DiameterSingle.SiValue = mSection.DiameterFocalD
        Me.DiameterSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.DiameterSingle.IsReadOnly = False
        Me.DiameterSingle.ReadOnlyMsgBox = Nothing
        Me.DiameterKey.ShowValue(Me.DiameterSingle.UiValueUnitsText)

        ' Inner Sill Height (D1) control
        Me.SillHeightSingle.Label = D1Key.BaseText & ", D1"
        Me.SillHeightSingle.SiDefaultValue = mDefaultSection.D1
        Me.SillHeightSingle.SiValue = mSection.D1
        Me.SillHeightSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.D1Key.ShowValue(Me.SillHeightSingle.UiValueUnitsText, "D1")

        ' Top Width
        Dim TWtxt As String = UnitsDialog.UiValueUnitsText(mChannelWidth, "m")
        Me.TwKey.ShowValue(TWtxt)

        ' Set Read-Only state, when appropriate
        If (mSection.GetType Is GetType(WinFlumeSectionType)) Then
            Dim WinFlumeSection As WinFlumeSectionType = DirectCast(mSection, WinFlumeSectionType)
            Dim MatchConstraints As Integer = WinFlumeSection.MatchConstraints

            If (BitSet(MatchConstraints, MatchConstraint.InnerSillHeightMatchesProfileSillHeight)) Then
                Me.SillHeightSingle.IsReadOnly = True
                Me.SillHeightSingle.ReadOnlyMsgBox = SillHeightMatchesProfile
            Else
                Me.SillHeightSingle.IsReadOnly = False
                Me.SillHeightSingle.ReadOnlyMsgBox = Nothing
            End If
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub DrawCrossSection() - draw cross section graphics
    '
    ' Input(s):     eGraphics   - Graphics object provided by Windows via OnPaint()
    '*********************************************************************************************************
    Protected Overrides Sub DrawCrossSection(ByVal eGraphics As System.Drawing.Graphics)
        MyBase.DrawCrossSection(eGraphics)      ' Baseclass defines ViewPort
        Dim dPen As Drawing.Pen = BlackPen2()   ' Pen for cross section control graphics

        DrawCrossSection(mSectionIdx, mViewPort, eGraphics, dPen)
    End Sub

    '*********************************************************************************************************
    ' Sub DrawExtras() - draw extra graphics
    '
    ' Input(s):     eGraphics   - Graphics object provided by Windows via OnPaint()
    '*********************************************************************************************************
    Public Overrides Sub DrawExtras(ByVal eGraphics As System.Drawing.Graphics)
        DrawDiameter(eGraphics)
        DrawSillHeight(eGraphics)
    End Sub

    Private dx1, dx2, dy1, dy2 As Single
    Private Sub DrawDiameter(ByVal eGraphics As System.Drawing.Graphics)
        Try ' catch, but ignore, drawing exceptions

            Dim CD As Single = mCanalDepth                  ' Canal depth
            Dim CW As Single = mCanalWidth                  ' Top Width of canal
            Dim BH As Single = mBottomHeight                ' Height from canal bottom to section bottom
            Dim DF As Single = mDiamFocalDist               ' Diameter / Focal Distance of this Section
            Dim SH As Single = CD - BH                      ' Section height

            Dim x, y, w, h As Single

            ' Diameter graphic
            x = mViewPort.X + mHorzOffset + (CW - DF) * mHorzScale / 2
            y = mViewPort.Y + mVertOffset + (SH - DF) * mVertScale
            w = DF * mHorzScale
            h = w

            dx1 = x
            dy1 = y + h / 2
            dx2 = x + w
            dy2 = dy1
            eGraphics.DrawLine(mBlackDashedPen1, dx1, dy1, dx2, dy2)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DrawSillHeight(ByVal eGraphics As System.Drawing.Graphics)
        Try ' catch, but ignore, drawing exceptions

            Dim x1, x2, y1, y2 As Single

            ' Sill Height graphic
            Dim midPt As Integer = CInt(mInner.GetUpperBound(0) / 2)
            x1 = mInner(midPt).X
            y1 = mInner(midPt).Y
            x2 = Math.Max(CInt(x1 + D1Label.Width + Me.SillHeightSingle.Width), CInt(mOuter.Last.X))
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

            midPt = CInt(mOuter.GetUpperBound(0) / 2)
            x1 = mOuter(midPt).X
            y1 = mOuter(midPt).Y
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

        Catch ex As Exception
        End Try
    End Sub

    '*********************************************************************************************************
    ' Sub AnnotateDrawing() - annotate cross section's printable drawing
    '*********************************************************************************************************
    Public Overrides Sub AnnotateDrawing(ByVal eGraphics As Graphics)

        ' Position 'Annotations' relative to circle's outline
        Dim x1, y1, dx As Single

        ' Diameter / Focal Distance
        Dim DF As Single = mSection.DiameterFocalD
        Dim DFtext As String = My.Resources.Diameter & ": " & UnitsDialog.UiValueUnitsText(DF, "m")
        Dim DFsize As RectangleF = MeasureString(eGraphics, DFtext, Me.Font)

        ' Include 'Extras'
        DrawDiameter(eGraphics)

        dx = (mInner.Last.X - mInner.First.X - DFsize.Right) / 2

        x1 = mInner.First.X + dx
        y1 = mInner.First.Y - DFsize.Height
        eGraphics.DrawString(DFtext, Me.Font, mBlackBrush, x1, y1)

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls relative to circle's outline
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()

        ' Thumbnail graphic
        Dim x As Single = Me.Thumbnail.Location.X
        Dim y As Single = Me.Height - Me.Thumbnail.Height - 5
        Dim loc As Point = New Point(CInt(x), CInt(y))
        PositionControl(Me.Thumbnail, loc)

        ' Diameter control
        x = (dx1 + dx2 - Me.DiameterSingle.Width) / 2
        y = dy1 - Me.DiameterSingle.Height
        If (y < Me.DiameterSingle.Height) Then
            y = Me.DiameterSingle.Height
        End If
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.DiameterSingle, loc)

        ' SillHeight control/label
        x = CSng(mInner(Half + 1).X + Me.D1Label.Width + Me.Margin.Horizontal)
        y = CSng(mInner(Half + 1).Y + Me.Margin.Vertical)
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.SillHeightSingle, loc, Me.D1Label)

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Protected Sub DiameterSingle_ValueChanged() Handles DiameterSingle.ValueChanged
        Dim Diameter As Single = Me.DiameterSingle.SiValue
        SetDiameter(Diameter)
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

#End Region

End Class
