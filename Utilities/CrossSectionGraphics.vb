
'*************************************************************************************************************
' Class CrossSectionGraphics - support for drawing canal cross sections
'*************************************************************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Flume
Imports Flume.Globals

Public Class CrossSectionGraphics

#Region " Member Data "
    '
    ' Drawing tools
    '
    Protected mGraphics As System.Drawing.Graphics = Nothing

    Protected mBlackPen1 As Pen = BlackPen1()
    Protected mBlackPen2 As Pen = BlackPen2()
    Protected mBlackDashedPen1 As Pen = BlackDashedPen1()
    Protected mBlackDashedPen2 As Pen = BlackDashedPen2()
    Protected mBlackBrush As Brush = BlackSolidBrush()

    Protected mBluePen1 As Pen = BluePen1()
    Protected mBluePen2 As Pen = BluePen2()
    Protected mBlueBrush As Brush = BlueSolidBrush()

    Protected mWhitePen1 As Pen = WhitePen1()
    Protected mWhitePen2 As Pen = WhitePen2()
    Protected mWhiteBrush As Brush = WhiteSolidBrush()

    Protected mGrayPen1 As Pen = GrayPen1()
    Protected mGrayPen2 As Pen = GrayPen2()
    Protected mGrayBrush As Brush = GraySolidBrush()

#End Region

#Region " Properties "
    '
    ' World to Viewport scaling
    '
    Protected mHorzOffset As Single
    Public Function HorzOffset() As Single
        Return mHorzOffset
    End Function

    Protected mHorzScale As Single
    Public Function HorzScale() As Single
        Return mHorzScale
    End Function

    Protected mVertOffset As Single
    Public Function VertOffset() As Single
        Return mVertOffset
    End Function

    Protected mVertScale As Single
    Public Function VertScale() As Single
        Return mVertScale
    End Function

    Protected mViewPort As RectangleF
    Public Function ViewPort() As RectangleF
        Return mViewPort
    End Function
    '
    ' Flume / Section to graph
    '
    Protected mFlume As Flume.FlumeType = Nothing
    Public Property Flume() As Flume.FlumeType
        Get
            Return mFlume
        End Get
        Set(ByVal value As Flume.FlumeType)
            mFlume = value
        End Set
    End Property

    Protected mSection As Flume.SectionType = Nothing
    Public Property Section() As Flume.SectionType
        Get
            Return mSection
        End Get
        Protected Set(ByVal value As Flume.SectionType)
            mSection = value
        End Set
    End Property
    '
    ' Real world cross section dimensions
    '
    Protected mCanalDepth As Single
    Public Property CanalDepth() As Single
        Get
            Return mCanalDepth
        End Get
        Protected Set(ByVal value As Single)
            mCanalDepth = value
        End Set
    End Property

    Protected mCanalWidth As Single
    Public Property CanalWidth() As Single
        Get
            Return mCanalWidth
        End Get
        Protected Set(ByVal value As Single)
            mCanalWidth = value
        End Set
    End Property

    Protected mBottomHeight As Single
    Public Property BottomHeight() As Single
        Get
            Return mBottomHeight
        End Get
        Protected Set(ByVal value As Single)
            mBottomHeight = value
        End Set
    End Property

    Protected mChannelDepth As Single
    Public Property ChannelDepth() As Single
        Get
            Return mChannelDepth
        End Get
        Protected Set(ByVal value As Single)
            mChannelDepth = value
        End Set
    End Property

    Protected mChannelwidth As Single
    Public Property ChannelWidth() As Single
        Get
            Return mChannelwidth
        End Get
        Protected Set(ByVal value As Single)
            mChannelwidth = value
        End Set
    End Property

    Protected mDiamFocalDist As Single
    Public Property DiamFocalDist() As Single
        Get
            Return mDiamFocalDist
        End Get
        Set(ByVal value As Single)
            mDiamFocalDist = value
        End Set
    End Property

    ' Error flag
    Protected mFlumeErr As Boolean
    Public Property FlumeErr() As Boolean
        Get
            Return mFlumeErr
        End Get
        Protected Set(ByVal value As Boolean)
            mFlumeErr = value
        End Set
    End Property

    ' Graphing selections
    Protected mPen As Drawing.Pen = BlackPen2()         ' Pen used to draw
    Protected mPen1 As Drawing.Pen = BlackPen2()        ' Pens set by caller
    Protected mPen2 As Drawing.Pen = BluePen2()
    Protected mPen3 As Drawing.Pen = BlackPen1()

    Public Property Pen1() As Drawing.Pen
        Get
            Return mPen1
        End Get
        Set(ByVal value As Drawing.Pen)
            mPen1 = value
        End Set
    End Property

    Public Property Pen2() As Drawing.Pen
        Get
            Return mPen2
        End Get
        Set(ByVal value As Drawing.Pen)
            mPen2 = value
        End Set
    End Property

    Public Property Pen3() As Drawing.Pen
        Get
            Return mPen3
        End Get
        Set(ByVal value As Drawing.Pen)
            mPen3 = value
        End Set
    End Property

    ' PointF arrays of shapes drawn
    Protected mOuterShape() As PointF
    Protected mOuterShape1() As PointF
    Protected mOuterShape2() As PointF
    Public ReadOnly Property OuterShape() As PointF()
        Get
            Return mOuterShape
        End Get
    End Property

    Protected mInnerShape() As PointF
    Protected mInnerShape1() As PointF
    Protected mInnerShape2() As PointF
    Public ReadOnly Property InnerShape() As PointF()
        Get
            Return mInnerShape
        End Get
    End Property

#End Region

#Region " Public Methods "

    '*********************************************************************************************************
    ' Sub DrawApproachChannel()     - draw Approach Channel cross section graphics
    ' Sub DrawControlSection()      -   "  Control Section    "      "        "
    ' Sub DrawTailwaterChannel()    -   "  Tailwater Channel  "      "        "
    '
    ' Input(s):     eGraphics       - Graphics handle from OnPaint(); used to draw on a Control
    '               ViewPort        - ViewPort area within Control for drawing
    '*********************************************************************************************************
    Public Sub DrawApproachChannel(ByVal eGraphics As System.Drawing.Graphics, ByVal ViewPort As RectangleF)

        If ((Flume IsNot Nothing) And (eGraphics IsNot Nothing)) Then

            mGraphics = eGraphics
            mViewPort = ViewPort

            Section = Flume.Section(cApproach)

            BottomHeight = Flume.BedDrop
            ChannelDepth = Flume.ChannelDepth
            ChannelWidth = Section.TopWidth(ChannelDepth, FlumeErr)
            CanalDepth = Flume.ChannelDepth + Flume.BedDrop
            CanalWidth = Flume.TopWidth(ChannelDepth, FlumeErr)
            DiamFocalDist = Section.DiameterFocalD

            ScaleToViewport()

            Select Case Section.Shape
                Case shSimpleTrapezoid
                    Me.DrawSimpleTrapezoid()
                Case shRectangular
                    Me.DrawRectangular()
                Case shVShaped
                    Me.DrawVShaped()
                Case shCircle
                    Me.DrawCircle()
                Case shUShaped
                    Me.DrawUShaped()
                Case shParabola
                    Me.DrawParabola()
            End Select

        Else
            Debug.Assert(False, "Both Flume & eGraphics must be specified")
        End If

    End Sub

    Public Sub DrawControlSection(ByVal eGraphics As System.Drawing.Graphics, ByVal ViewPort As RectangleF)

        If ((Flume IsNot Nothing) And (eGraphics IsNot Nothing)) Then

            mGraphics = eGraphics
            mViewPort = ViewPort

            Section = Flume.Section(cControl)

            BottomHeight = Flume.SillHeight + Flume.BedDrop
            ChannelDepth = Flume.ChannelDepth
            ChannelWidth = Section.TopWidth(ChannelDepth - Flume.SillHeight, FlumeErr)
            CanalDepth = Flume.ChannelDepth + Flume.BedDrop
            CanalWidth = Flume.TopWidth(ChannelDepth, FlumeErr)
            DiamFocalDist = Section.DiameterFocalD

            ScaleToViewport()

            Select Case Section.Shape
                Case shSimpleTrapezoid
                    Me.DrawSimpleTrapezoid()
                Case shRectangular
                    Me.DrawRectangular()
                Case shVShaped
                    Me.DrawVShaped()
                Case shCircle
                    Me.DrawCircle()
                Case shUShaped
                    Me.DrawUShaped()
                Case shParabola
                    Me.DrawParabola()
            End Select

        Else
            Debug.Assert(False, "Both Flume & eGraphics must be specified")
        End If

    End Sub

    Public Sub DrawTailwaterChannel(ByVal eGraphics As System.Drawing.Graphics, ByVal ViewPort As RectangleF)

        If ((Flume IsNot Nothing) And (eGraphics IsNot Nothing)) Then

            mGraphics = eGraphics
            mViewPort = ViewPort

            Section = Flume.Section(cTailwater)

            BottomHeight = 0
            ChannelDepth = Flume.ChannelDepth
            ChannelWidth = Section.TopWidth(ChannelDepth + Flume.BedDrop, FlumeErr)
            CanalDepth = Flume.ChannelDepth + Flume.BedDrop
            CanalWidth = Flume.TopWidth(ChannelDepth, FlumeErr)
            DiamFocalDist = Section.DiameterFocalD

            ScaleToViewport()

            Select Case Section.Shape
                Case shSimpleTrapezoid
                    Me.DrawSimpleTrapezoid()
                Case shRectangular
                    Me.DrawRectangular()
                Case shVShaped
                    Me.DrawVShaped()
                Case shCircle
                    Me.DrawCircle()
                Case shUShaped
                    Me.DrawUShaped()
                Case shParabola
                    Me.DrawParabola()
            End Select

        Else
            Debug.Assert(False, "Both Flume & Ctrl eGraphics must be specified")
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub DrawUpstreamView()    - draw upstream view of Approach Channel & Control Section
    '
    ' Input(s):     eGraphics   - Graphics handle provided by Windows via OnPaint()
    '               ViewPort    - ViewPort area within Control for drawing
    '
    ' Note - the upstream view is looking downstream from the upstream end of the approach channel
    '*********************************************************************************************************
    Public Sub DrawUpstreamView(ByVal eGraphics As System.Drawing.Graphics, ByVal ViewPort As RectangleF)

        ' Draw Approach then Control cross sections
        mPen = mPen1
        DrawApproachChannel(eGraphics, ViewPort)
        mInnerShape1 = mInnerShape
        mOuterShape1 = mOuterShape

        mPen = mPen2
        DrawControlSection(eGraphics, ViewPort)
        mInnerShape2 = mInnerShape
        mOuterShape2 = mOuterShape

        ' Draw connection lines between the cross sections
        mPen = mPen3
        Me.DrawGradualSectionConnectors(Flume.Section(cApproach), Flume.Section(cControl))

        ' Reset drawing pen
        mPen = mPen1

    End Sub

    '*********************************************************************************************************
    ' Sub DrawDownstreamView()  - draw downstream view of Tailwater Channel & Control Section
    '
    ' Input(s):     eGraphics   - Graphics handle provided by Windows via OnPaint()
    '               ViewPort    - ViewPort area within Control for drawing
    '
    ' Note - the downstream view is looking upstream from the downstream end of the tailwater channel
    '*********************************************************************************************************
    Public Sub DrawDownstreamView(ByVal eGraphics As System.Drawing.Graphics, ByVal ViewPort As RectangleF)

        ' Draw Tailwater then Control cross sections
        mPen = mPen1
        DrawTailwaterChannel(eGraphics, ViewPort)
        mInnerShape1 = mInnerShape
        mOuterShape1 = mOuterShape

        mPen = mPen2
        DrawControlSection(eGraphics, ViewPort)
        mInnerShape2 = mInnerShape
        mOuterShape2 = mOuterShape

        ' Draw connection lines between the cross sections
        mPen = mPen3
        Select Case (Flume.ExpansionRampStyle)
            Case cNoRamp
                Me.DrawAbruptSectionConnectors(Flume.Section(cTailwater), Flume.Section(cControl))
            Case cFullRamp
                Me.DrawGradualSectionConnectors(Flume.Section(cTailwater), Flume.Section(cControl))
            Case cTruncatedRamp
                Me.DrawTruncatedSectionConnectors(Flume.Section(cTailwater), Flume.Section(cControl))
            Case Else
                Debug.Assert(False)
        End Select

        ' Reset drawing pen
        mPen = mPen1

    End Sub

#End Region

#Region " Protected Methods "

#Region " Draw Cross Section Shapes "

    '*********************************************************************************************************
    ' Sub DrawSimpleTrapezoid()     - draw Simple Trapezoid cross section
    ' Sub DrawRectangular()         -   "  Rectangular        "      "
    ' Sub DrawVShaped()             -   "  V-Shaped           "      "
    ' Sub DrawCircle()              -   "  Circle             "      "
    ' Sub DrawUShaped()             -   "  U-Shaped           "      "
    ' Sub DrawParabola()            -   "  Parabola           "      "
    '*********************************************************************************************************
    Protected Sub DrawSimpleTrapezoid()

        Dim CD As Single = CanalDepth               ' Canal depth
        Dim CW As Single = CanalWidth               ' Top Width of canal
        Dim BH As Single = BottomHeight             ' Height from canal bottom to section bottom
        Dim BW As Single = Section.BottomWidth      ' Width of trapezoid bottom
        Dim SW As Single = ChannelWidth             ' Top Width of this Section

        ' Define the simple trapezoid cross section shape
        Dim simpleTrapezoid(3) As PointF
        Dim x1, x2, y1, y2 As Single

        x1 = mViewPort.X + mHorzOffset + (CW - SW) * mHorzScale / 2  ' Left side
        y1 = mViewPort.Y + mVertOffset
        x2 = x1 + (SW - BW) * mHorzScale / 2
        y2 = y1 + (CD - BH) * mVertScale
        simpleTrapezoid(0) = New PointF(x1, y1)
        simpleTrapezoid(1) = New PointF(x2, y2)

        x1 = x2                                     ' Bottom
        y1 = y2
        x2 = x1 + BW * mHorzScale
        y2 = y1
        simpleTrapezoid(2) = New PointF(x2, y2)

        x1 = x2                                     ' Right side
        y1 = y2
        x2 = x1 + (SW - BW) * mHorzScale / 2
        y2 = y1 - (CD - BH) * mVertScale
        simpleTrapezoid(3) = New PointF(x2, y2)

        ' Draw the shape on the Control
        mGraphics.DrawLines(mPen, simpleTrapezoid)

        ' Save the shape as an externally accessible property
        mOuterShape = simpleTrapezoid

    End Sub

    Protected Sub DrawRectangular()

        Dim CD As Single = CanalDepth               ' Canal depth
        Dim CW As Single = CanalWidth               ' Top Width of canal
        Dim BH As Single = BottomHeight             ' Height from canal bottom to section bottom
        Dim BW As Single = Section.BottomWidth      ' Width of rectangle bottom
        Dim SW As Single = ChannelWidth             ' Section top width
        Dim SH As Single = CD - BH                  ' Section height

        ' Define the rectangular cross section shape
        Dim rectangular(3) As PointF
        Dim x1, x2, y1, y2 As Single

        x1 = mViewPort.X + mHorzOffset + (CW - SW) * mHorzScale / 2  ' Left side
        y1 = mViewPort.Y + mVertOffset
        x2 = x1
        y2 = y1 + SH * mVertScale
        rectangular(0) = New PointF(x1, y1)
        rectangular(1) = New PointF(x2, y2)

        x1 = x2                                     ' Bottom
        y1 = y2
        x2 = x1 + BW * mHorzScale
        y2 = y1
        rectangular(2) = New PointF(x2, y2)

        x1 = x2                                     ' Right side
        y1 = y2
        x2 = x1
        y2 = y1 - SH * mVertScale
        rectangular(3) = New PointF(x2, y2)

        ' Draw the shape on the Control
        mGraphics.DrawLines(mPen, rectangular)

        ' Save the shape as an externally accessible property
        mOuterShape = rectangular

    End Sub

    Protected Sub DrawVShaped()

        Dim CD As Single = CanalDepth               ' Canal depth
        Dim CW As Single = CanalWidth               ' Top Width of canal
        Dim BH As Single = BottomHeight             ' Height from canal bottom to section bottom
        Dim SW As Single = ChannelWidth             ' Section top width
        Dim SH As Single = CD - BH                  ' Section height

        ' Define the V-shaped cross section shape
        Dim vShaped(3) As PointF
        Dim x1, x2, y1, y2 As Single

        x1 = mViewPort.X + mHorzOffset + (CW - SW) * mHorzScale / 2  ' Left side
        y1 = mViewPort.Y + mVertOffset
        x2 = x1 + SW * mHorzScale / 2
        y2 = y1 + SH * mVertScale
        vShaped(0) = New PointF(x1, y1)
        vShaped(1) = New PointF(x2, y2)

        x1 = x2                                     ' Right side
        y1 = y2
        x2 = x1 + SW * mHorzScale / 2
        y2 = y1 - SH * mVertScale
        vShaped(2) = New PointF(x1, y1)
        vShaped(3) = New PointF(x2, y2)

        ' Draw the shape on the Control
        mGraphics.DrawLines(mPen, vShaped)

        ' Save the shape as an externally accessible property
        mOuterShape = vShaped

    End Sub

    Protected Sub DrawCircle()

        Dim CD As Single = CanalDepth               ' Canal depth
        Dim CW As Single = CanalWidth               ' Top Width of canal
        Dim BH As Single = BottomHeight             ' Height from canal bottom to section bottom
        Dim SW As Single = ChannelWidth             ' Top Width of this Section
        Dim DF As Single = DiamFocalDist            ' Diameter / Focal Distance of this Section
        Dim SH As Single = CD - BH                  ' Section height

        ' Define the circle cross section shape
        Dim circle(3) As PointF
        Dim x, y, w, h As Single
        Dim startAngle, sweepAngle As Single

        x = mViewPort.X + mHorzOffset + (CW - DF) * mHorzScale / 2
        y = mViewPort.Y + mVertOffset + (SH - DF) * mVertScale

        w = DF * mHorzScale
        h = w

        If (SW < 0.001) Then ' complete pipe fits in canal section

            startAngle = 0
            sweepAngle = 360

            circle(0) = New PointF(x + w / 2, y)
            circle(1) = New PointF(x + w / 2, y + h)
            circle(2) = New PointF(x + w / 2, y + h)
            circle(3) = New PointF(x + w / 2, y)

        Else ' partial pipe

            Dim op As Single = SH - (DF / 2)
            Dim hy As Single = DF / 2
            Dim aj As Single = CSng(Math.Sqrt(hy ^ 2 - op ^ 2))

            startAngle = -CSng(Math.Sin(op / hy))   ' Radians
            startAngle *= CSng(360 / (2 * Pi))      ' Degrees
            sweepAngle = 180 - 2 * startAngle

            aj *= mHorzScale
            op *= mVertScale

            circle(0) = New PointF(x + w / 2 - aj, y + h / 2 - op)
            circle(1) = New PointF(x + w / 2, y + h)
            circle(2) = New PointF(x + w / 2, y + h)
            circle(3) = New PointF(x + w / 2 + aj, y + h / 2 - op)

        End If

        ' Draw the shape on the Control
        mGraphics.DrawArc(mPen, x, y, w, h, startAngle, sweepAngle)

        ' Save the shape as an externally accessible property
        mOuterShape = circle

    End Sub

    Protected Sub DrawUShaped()

        Dim CD As Single = CanalDepth               ' Canal depth
        Dim CW As Single = CanalWidth               ' Top Width of canal
        Dim BH As Single = BottomHeight             ' Height from canal bottom to section bottom
        Dim SW As Single = ChannelWidth             ' Top Width of this Section
        Dim DF As Single = DiamFocalDist            ' Diameter / Focal Distance of this Section
        Dim SH As Single = CD - BH                  ' Section height

        ' Define the U-shaped cross section shape
        Dim uShaped(3) As PointF
        Dim x1, x2, y1, y2, w, h As Single
        Dim startAngle, sweepAngle As Single

        If (DF < 2 * SH) Then ' U-Shaped canal section (i.e. half-pipe & vertical sides)

            ' Left side
            x1 = mViewPort.X + mHorzOffset + (CW - SW) * mHorzScale / 2
            y1 = mViewPort.Y + mVertOffset
            x2 = x1
            y2 = y1 + (SH - DF / 2) * mVertScale
            uShaped(0) = New PointF(x1, y1)

            mGraphics.DrawLine(mPen, x1, y1, x2, y2)

            ' Bottom half-pipe
            x1 = x2
            y1 = y2 - (DF / 2) * mVertScale

            startAngle = 0
            sweepAngle = 180

            w = DF * mHorzScale
            h = w

            uShaped(1) = New PointF(x1 + w / 2, y1 + h)
            uShaped(2) = New PointF(x1 + w / 2, y1 + h)

            mGraphics.DrawArc(mPen, x1, y1, w, h, startAngle, sweepAngle)

            ' Right side
            x1 = x2 + DF * mVertScale
            y1 = y2
            x2 = x1
            y2 = mViewPort.Y + mVertOffset
            uShaped(3) = New PointF(x2, y2)

            mGraphics.DrawLine(mPen, x1, y1, x2, y2)

        Else ' half-pipe (or less)

            x1 = mViewPort.X + mHorzOffset + (CW - DF) * mHorzScale / 2
            y1 = mViewPort.Y + mVertOffset + (SH - DF) * mVertScale

            Dim op As Single = SH - (DF / 2)
            Dim hy As Single = DF / 2
            Dim aj As Single = CSng(Math.Sqrt(hy ^ 2 - op ^ 2))

            startAngle = -CSng(Math.Sin(op / hy))   ' Radians
            startAngle *= CSng(360 / (2 * Pi))      ' Degrees
            sweepAngle = 180 - 2 * startAngle

            w = DF * mHorzScale
            h = w

            aj *= mHorzScale
            op *= mVertScale

            uShaped(0) = New PointF(x1 + w / 2 - aj, y1 + h / 2 - op)
            uShaped(1) = New PointF(x1 + w / 2, y1 + h)
            uShaped(2) = New PointF(x1 + w / 2, y1 + h)
            uShaped(3) = New PointF(x1 + w / 2 + aj, y1 + h / 2 - op)

            ' Draw the shape on the Control
            mGraphics.DrawArc(mPen, x1, y1, w, h, startAngle, sweepAngle)
        End If

        ' Save the shape as an externally accessible property
        mOuterShape = uShaped

    End Sub

    Protected Sub DrawParabola()

        Dim CD As Single = CanalDepth               ' Canal depth
        Dim CW As Single = CanalWidth               ' Top Width of canal
        Dim BH As Single = BottomHeight             ' Height from canal bottom to section bottom
        Dim SW As Single = ChannelWidth             ' Top Width of this Section
        Dim DF As Single = DiamFocalDist            ' Diameter / Focal Distance(2f) of this Section
        Dim SH As Single = CD - BH                  ' Section height
        '
        ' Calculate parabola cross section shape in world coordinates
        '
        Dim numPts As Integer = 100
        Dim half As Integer = 50
        Dim curve(numPts) As PointF

        ' Start at X=0
        Dim x As Single = 0
        Dim y As Single = 0
        curve(half) = New PointF(x, y)

        ' Calculate parabola's sides
        For pdx As Integer = 1 To half
            y = SH * pdx / half
            x = CSng(Math.Sqrt(2 * DF * y))
            curve(half - pdx) = New PointF(-x, y)
            curve(half + pdx) = New PointF(x, y)
        Next pdx
        '
        ' Translate to drawing coordinates
        '
        For pdx As Integer = 0 To numPts
            x = curve(pdx).X
            y = SH - curve(pdx).Y ' invert Y
            x *= mHorzScale
            y *= mVertScale
            x += mViewPort.X + mHorzOffset
            y += mViewPort.Y + mVertOffset
            curve(pdx).X = x
            curve(pdx).Y = y
        Next pdx

        ' Center in ViewPort
        Dim xhalf As Single = curve(half).X
        Dim xOffset As Single = mViewPort.X + mViewPort.Width / 2 - xhalf
        For pdx As Integer = 0 To numPts
            x = curve(pdx).X + xOffset
            curve(pdx).X = x
        Next pdx

        ' Draw the shape on the Control
        mGraphics.DrawLines(mPen, curve)

        ' Save the shape as an externally accessible property
        Dim parabola(3) As PointF

        parabola(0) = curve(0)
        parabola(1) = curve(half)
        parabola(2) = curve(half)
        parabola(3) = curve(numPts)

        mOuterShape = parabola

    End Sub

#End Region

#Region " Draw Cross Section Connectors "

    '*********************************************************************************************************
    ' Sub DrawAbruptSectionConnectors()     - draw section connectors for an abrupt transition
    ' Sub DrawGradualSectionConnectors()    -   "     "         "      "  a gradual     "
    ' Sub DrawTruncatedSectionConnectors()  -   "     "         "      "  a truncated   "
    '
    ' Input(s):     Section1    - cross section 1
    '               Section2    -   "      "    2
    '*********************************************************************************************************
    Protected Sub DrawAbruptSectionConnectors(ByVal Section1 As SectionType, ByVal Section2 As SectionType)

        Dim pdx As Integer
        Dim x1, x2, y1, y2 As Single

        Select Case (Section1.Shape)

            Case shSimpleTrapezoid, shRectangular, shVShaped, _
                 shCircle, shUShaped, shParabola

                Select Case (Section2.Shape)
                    Case shSimpleTrapezoid, shRectangular, shVShaped, _
                         shCircle, shUShaped, shParabola

                        Debug.Assert(mOuterShape1.Length = mOuterShape2.Length)

                        pdx = 0
                        x1 = mOuterShape1(pdx).X
                        y1 = mOuterShape1(pdx).Y
                        x2 = mOuterShape2(pdx).X
                        y2 = mOuterShape2(pdx).Y
                        mGraphics.DrawLine(mPen, x1, y1, x2, y2)

                        pdx = mOuterShape1.Length - 1
                        x1 = mOuterShape1(pdx).X
                        y1 = mOuterShape1(pdx).Y
                        x2 = mOuterShape2(pdx).X
                        y2 = mOuterShape2(pdx).Y
                        mGraphics.DrawLine(mPen, x1, y1, x2, y2)

                    Case shComplexTrapezoid
                    Case shTrapezoidInCircle
                    Case shTrapezoidInU
                    Case shTrapezoidInParabola
                    Case shSillInCircle
                    Case shSillInU
                    Case shSillInParabola
                    Case shVInRectangle
                    Case Else
                        Debug.Assert(False, "Invalid cross section shape")
                End Select

            Case shComplexTrapezoid
            Case shTrapezoidInCircle
            Case shTrapezoidInU
            Case shTrapezoidInParabola
            Case shSillInCircle
            Case shSillInU
            Case shSillInParabola

            Case shVInRectangle

                Select Case (Section2.Shape)
                    Case shSimpleTrapezoid
                        For pdx = 0 To mOuterShape1.Length - 1
                        Next pdx
                    Case shRectangular
                    Case shVShaped
                    Case shCircle
                    Case shUShaped
                    Case shParabola
                    Case shComplexTrapezoid
                    Case shTrapezoidInCircle
                    Case shTrapezoidInU
                    Case shTrapezoidInParabola
                    Case shSillInCircle
                    Case shSillInU
                    Case shSillInParabola
                    Case shVInRectangle
                    Case Else
                        Debug.Assert(False, "Invalid cross section shape")
                End Select
            Case Else
                Debug.Assert(False, "Invalid cross section shape")

        End Select

    End Sub

    Protected Sub DrawGradualSectionConnectors(ByVal Section1 As SectionType, ByVal Section2 As SectionType)

        Dim pdx As Integer
        Dim x1, x2, y1, y2 As Single

        Select Case (Section1.Shape)

            Case shSimpleTrapezoid, shRectangular, shVShaped, _
                 shCircle, shUShaped, shParabola

                Select Case (Section2.Shape)
                    Case shSimpleTrapezoid, shRectangular, shVShaped, _
                         shCircle, shUShaped, shParabola

                        Debug.Assert(mOuterShape1.Length = mOuterShape2.Length)

                        For pdx = 0 To mOuterShape1.Length - 1
                            x1 = mOuterShape1(pdx).X
                            y1 = mOuterShape1(pdx).Y
                            x2 = mOuterShape2(pdx).X
                            y2 = mOuterShape2(pdx).Y
                            mGraphics.DrawLine(mPen, x1, y1, x2, y2)
                        Next pdx

                    Case shComplexTrapezoid
                    Case shTrapezoidInCircle
                    Case shTrapezoidInU
                    Case shTrapezoidInParabola
                    Case shSillInCircle
                    Case shSillInU
                    Case shSillInParabola
                    Case shVInRectangle
                    Case Else
                        Debug.Assert(False, "Invalid cross section shape")
                End Select

            Case shComplexTrapezoid
            Case shTrapezoidInCircle
            Case shTrapezoidInU
            Case shTrapezoidInParabola
            Case shSillInCircle
            Case shSillInU
            Case shSillInParabola

            Case shVInRectangle

                Select Case (Section2.Shape)
                    Case shSimpleTrapezoid
                        For pdx = 0 To mOuterShape1.Length - 1
                        Next pdx
                    Case shRectangular
                    Case shVShaped
                    Case shCircle
                    Case shUShaped
                    Case shParabola
                    Case shComplexTrapezoid
                    Case shTrapezoidInCircle
                    Case shTrapezoidInU
                    Case shTrapezoidInParabola
                    Case shSillInCircle
                    Case shSillInU
                    Case shSillInParabola
                    Case shVInRectangle
                    Case Else
                        Debug.Assert(False, "Invalid cross section shape")
                End Select
            Case Else
                Debug.Assert(False, "Invalid cross section shape")

        End Select

    End Sub

    Protected Sub DrawTruncatedSectionConnectors(ByVal Section1 As SectionType, ByVal Section2 As SectionType)

        Dim pdx As Integer
        Dim x1, x2, y1, y2, x1t, y1t, x2t, y2t, ratio As Single

        Select Case (Section1.Shape) ' Tailwater cross section

            Case shSimpleTrapezoid, shRectangular, shVShaped, _
                 shCircle, shUShaped, shParabola

                Select Case (Section2.Shape) ' Control cross section

                    Case shSimpleTrapezoid, shRectangular, shVShaped, _
                         shCircle, shUShaped, shParabola

                        Debug.Assert(mOuterShape1.Length = mOuterShape2.Length)
                        Debug.Assert(mOuterShape1.Length = 4)

                        x1 = mOuterShape1(0).X
                        y1 = mOuterShape1(0).Y
                        x2 = mOuterShape1(1).X
                        y2 = mOuterShape1(1).Y
                        ratio = (x2 - x1) / (y2 - y1)

                        pdx = 0
                        x1 = mOuterShape1(pdx).X
                        y1 = mOuterShape1(pdx).Y
                        x2 = mOuterShape2(pdx).X
                        y2 = mOuterShape2(pdx).Y
                        mGraphics.DrawLine(mPen, x1, y1, x2, y2)

                        pdx = 1
                        x1 = mOuterShape1(pdx).X
                        y1 = mOuterShape1(pdx).Y
                        x2 = mOuterShape2(pdx).X
                        y2 = mOuterShape2(pdx).Y
                        y1t = (y1 + y2) / 2
                        x1t = x1 - ratio * (y1 - y1t)
                        mGraphics.DrawLine(mPen, x1t, y1t, x2, y2)

                        pdx = 2
                        x1 = mOuterShape1(pdx).X
                        y1 = mOuterShape1(pdx).Y
                        x2 = mOuterShape2(pdx).X
                        y2 = mOuterShape2(pdx).Y
                        y2t = (y1 + y2) / 2
                        x2t = x1 + ratio * (y1 - y2t)
                        mGraphics.DrawLine(mPen, x2t, y2t, x2, y2)

                        mGraphics.DrawLine(mPen, x1t, y1t, x2t, y2t)

                        pdx = 3
                        x1 = mOuterShape1(pdx).X
                        y1 = mOuterShape1(pdx).Y
                        x2 = mOuterShape2(pdx).X
                        y2 = mOuterShape2(pdx).Y
                        mGraphics.DrawLine(mPen, x1, y1, x2, y2)

                    Case shComplexTrapezoid
                    Case shTrapezoidInCircle
                    Case shTrapezoidInU
                    Case shTrapezoidInParabola
                    Case shSillInCircle
                    Case shSillInU
                    Case shSillInParabola
                    Case shVInRectangle
                    Case Else
                        Debug.Assert(False, "Invalid cross section shape")
                End Select

            Case shComplexTrapezoid
            Case shTrapezoidInCircle
            Case shTrapezoidInU
            Case shTrapezoidInParabola
            Case shSillInCircle
            Case shSillInU
            Case shSillInParabola

            Case shVInRectangle

                Select Case (Section2.Shape)
                    Case shSimpleTrapezoid
                        For pdx = 0 To mOuterShape1.Length - 1
                        Next pdx
                    Case shRectangular
                    Case shVShaped
                    Case shCircle
                    Case shUShaped
                    Case shParabola
                    Case shComplexTrapezoid
                    Case shTrapezoidInCircle
                    Case shTrapezoidInU
                    Case shTrapezoidInParabola
                    Case shSillInCircle
                    Case shSillInU
                    Case shSillInParabola
                    Case shVInRectangle
                    Case Else
                        Debug.Assert(False, "Invalid cross section shape")
                End Select
            Case Else
                Debug.Assert(False, "Invalid cross section shape")

        End Select

    End Sub

#End Region

#Region " Scaling "

    '*********************************************************************************************************
    ' Sub ScaleToViewport()     - scale the real world coordinates to the Control's ViewPort
    '*********************************************************************************************************
    Protected Sub ScaleToViewport()
        ' Scale cross section to fit ViewPort
        mHorzScale = mViewPort.Width / CanalWidth
        mVertScale = mViewPort.Height / CanalDepth
        ' Maintain 1:1 aspect ratio
        If (mHorzScale > mVertScale) Then
            mHorzScale = mVertScale
        Else
            mVertScale = mHorzScale
        End If
        ' Center graphics within Viewport
        mHorzOffset = (mViewPort.Width - CanalWidth * mHorzScale) / 2
        mVertOffset = (mViewPort.Height - CanalDepth * mVertScale) / 2
    End Sub

#End Region

#End Region

End Class
