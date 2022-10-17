
'*************************************************************************************************************
' Class UShapedInUShapedControl  - UserControl for drawing & editing a UShaped-In-UShaped cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'   Note - Inherits statement is found in the file: UShapedInUShapedControl.Designer.vb
'*************************************************************************************************************
Imports WinFlume.WinFlumeSectionType

Public Class UShapedInUShapedControl

#Region " Constants "

    Protected Const Half As Integer = 25
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
        mFlume = WinFlumeForm.Flume             ' Reference to Flume data; may be Nothing
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

            Debug.Assert(mSection.GetType Is GetType(WinFlumeSectionType))

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim SH As Single = mBottomHeight            ' Sill height from canal bottom
            Dim ODF As Single = mOuterDiamFocalDist     ' Outer Diameter / Focal Distance(2f)

            Dim D1 As Single = mSection.D1              ' Inner sill height
            Dim UH As Single = SH - D1                  ' U-Shaped height from canal bottom
            Dim UD As Single = CD - UH                  ' U-Shaped depth from canal top
            '
            ' Calculate U-Shaped cross section shape in world coordinates
            '
            Dim Ushaped(NumPts + 2) As PointF
            Dim uub As Integer = Ushaped.GetUpperBound(0)

            ' Counter-clockwise (left edge top-to-bottom) then (right edge bottom-to-top)
            Dim r As Double = ODF / 2                        ' radius
            Dim cx As Double = 0                            ' semi-circle origin (i.e. center)
            Dim cy As Double = r                            ' 
            Dim a As Double = Math.PI                       ' angle in radians of semi-circle top

            Dim x As Single = CSng(cx + r * Math.Cos(a))    ' top of semi-circle
            Dim y As Single = CSng(cy + r * Math.Sin(a))

            If (y >= UD) Then ' semi-circle extends above canal top

                a = Math.Asin((UD - cy) / r)
                Dim inc As Double = (2 * a + Math.PI) / uub
                a = Math.PI - a

                ' Partial semi-circle
                For pdx = 0 To uub
                    x = CSng(cx + r * Math.Cos(a))
                    y = CSng(cy + r * Math.Sin(a))
                    Ushaped(pdx) = New PointF(x, y)
                    a += inc
                Next

            Else ' U-Shaped

                Dim inc As Double = Math.PI / NumPts

                ' Top of U-Shaped's left edge
                x = CSng(-r)
                y = CSng(UD)
                Ushaped(0) = New PointF(x, y)

                ' Semi-circle
                For pdx = 1 To uub - 1
                    x = CSng(cx + r * Math.Cos(a))
                    y = CSng(cy + r * Math.Sin(a))
                    Ushaped(pdx) = New PointF(x, y)
                    a += inc
                Next

                ' Top of U-Shaped's right edge
                x = CSng(r)
                y = CSng(UD)
                Ushaped(uub) = New PointF(x, y)

            End If
            '
            ' Translate to drawing coordinates
            '
            For pdx As Integer = 0 To uub
                x = Ushaped(pdx).X
                y = UD - Ushaped(pdx).Y ' invert Y
                x *= mHorzScale
                y *= mVertScale
                x += mViewPort.X + mHorzOffset
                y += mViewPort.Y + mVertOffset
                Ushaped(pdx).X = x
                Ushaped(pdx).Y = y
            Next pdx

            ' Center in ViewPort
            Dim xhalf As Single = CInt((Ushaped(0).X + Ushaped(NumPts + 2).X) / 2)
            Dim xOffset As Single = mViewPort.X + mViewPort.Width / 2 - xhalf
            For pdx As Integer = 0 To uub
                x = Ushaped(pdx).X + xOffset
                Ushaped(pdx).X = x
            Next pdx

            OuterOutline = Ushaped
        Catch ex As Exception
            OuterOutline = Nothing
        End Try
    End Function

    Public Overrides Function InnerOutline(ByVal SectionIdx As Integer,
                                           ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Baseclass initializes cross section data
            MyBase.InnerOutline(SectionIdx, ViewPort)

            Debug.Assert(mSection.GetType Is GetType(WinFlumeSectionType))

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim BH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim IDF As Single = mDiamFocalDist          ' Inner Diameter / Focal Distance(2f)
            Dim SH As Single = CD - BH                  ' Section height
            '
            ' Calculate U-Shaped cross section shape in world coordinates
            '
            Dim Ushaped(NumPts + 2) As PointF

            ' Counter-clockwise (left edge top-to-bottom) then (right edge bottom-to-top)
            Dim r As Double = IDF / 2                       ' radius
            Dim cx As Double = 0                            ' circle origin (i.e. center)
            Dim cy As Double = r                            ' 
            Dim a As Double = Math.PI                       ' angle in radians of semi-circle top
            Dim inc As Double = Math.PI / NumPts

            Dim x As Single = CSng(cx + r * Math.Cos(a))    ' left edge top
            Dim y As Single = CSng(cy + r * Math.Sin(a))    '

            If (y >= SH) Then ' semi-circle extends to or above canal
                a = Math.Asin((SH - cy) / r)
                inc = (2 * a + Math.PI) / (NumPts + 2)
                a = Math.PI - a

                ' Partial semi-circle
                For pdx = 0 To NumPts + 2
                    x = CSng(cx + r * Math.Cos(a))
                    y = CSng(cy + r * Math.Sin(a))
                    Ushaped(pdx) = New PointF(x, y)
                    a += inc
                Next

            Else ' U-Shaped

                ' Top of U-Shaped's left edge
                x = CSng(-r)
                y = CSng(SH)
                Ushaped(0) = New PointF(x, y)

                ' Semi-circle
                For pdx = 1 To NumPts + 1
                    x = CSng(cx + r * Math.Cos(a))
                    y = CSng(cy + r * Math.Sin(a))
                    Ushaped(pdx) = New PointF(x, y)
                    a += inc
                Next

                ' Top of U-Shaped's right edge
                x = CSng(r)
                y = CSng(SH)
                Ushaped(NumPts + 2) = New PointF(x, y)
            End If
            '
            ' Translate to drawing coordinates
            '
            For pdx As Integer = 0 To NumPts + 2
                x = Ushaped(pdx).X
                y = SH - Ushaped(pdx).Y ' invert Y
                x *= mHorzScale
                y *= mVertScale
                x += mViewPort.X + mHorzOffset
                y += mViewPort.Y + mVertOffset
                Ushaped(pdx).X = x
                Ushaped(pdx).Y = y
            Next pdx

            ' Center in ViewPort
            Dim xhalf As Single = CInt((Ushaped(0).X + Ushaped(NumPts + 2).X) / 2)
            Dim xOffset As Single = mViewPort.X + mViewPort.Width / 2 - xhalf
            For pdx As Integer = 0 To NumPts + 2
                x = Ushaped(pdx).X + xOffset
                Ushaped(pdx).X = x
            Next pdx

            InnerOutline = Ushaped
        Catch ex As Exception
            InnerOutline = Nothing
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete inner U-Shaped outline
            Dim Ushaped As PointF() = Me.InnerOutline(SectionIdx, ViewPort)
            ' Extract invert outline from U-Shaped outline
            Dim invert(1) As PointF

            invert(0) = Ushaped(Half + 1)
            invert(1) = Ushaped(Half + 1)

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

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim BH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim DF As Single = mDiamFocalDist           ' Diameter / Focal Distance(2f)
            Dim UH As Single = CD - BH                  ' U-Shape height
            Dim SH As Single = mSillHeight              ' Sill height
            Dim BD As Single = mBedDrop                 ' Bed drop
            Dim RH As Single = (SH + BD) / 2            ' Truncated ramp height

            If (RH < DF / 2) Then ' within semi-circle

                Dim r As Double = DF / 2
                Dim d As Double = r - RH
                Dim c As Double = 2 * r * Math.Sqrt(1 - (d / r) ^ 2)

                Dim dx As Single = CSng(c * mHorzScale / 2)
                Dim dy As Single = RH * mVertScale

                tRamp(0).X = invert(0).X - dx
                tRamp(0).Y = invert(0).Y - dy
                tRamp(1).X = invert(1).X + dx
                tRamp(1).Y = invert(1).Y - dy

            ElseIf (RH < UH) Then ' above semi-circle; below canal top

                Dim dx As Single = DF / 2
                Dim dy As Single = RH * mVertScale

                tRamp(0).X = invert(0).X - dx
                tRamp(0).Y = invert(0).Y - dy
                tRamp(1).X = invert(1).X + dx
                tRamp(1).Y = invert(1).Y - dy

            Else ' above canal top

                Dim dx As Single = DF / 2
                Dim dy As Single = UH * mVertScale

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
    ' Sub UpdateControlValues() - called to update contained Controls' values
    '*********************************************************************************************************
    Protected Overrides Sub UpdateControlValues()
        MyBase.UpdateControlValues()

        ' Inner U-Shape diameter
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
    ' Sub DrawCrossSection() - called to draw the cross section graphics
    '
    ' Input(s):     eGraphics   - Graphics handle provided by Windows via OnPaint()
    '*********************************************************************************************************
    Protected Overrides Sub DrawCrossSection(ByVal eGraphics As System.Drawing.Graphics)
        MyBase.DrawCrossSection(eGraphics)      ' Baseclass defines ViewPort
        Dim dPen As Drawing.Pen = BlackPen2()   ' Pen for cross section control graphics

        DrawCrossSection(mSectionIdx, mViewPort, eGraphics, dPen)
    End Sub

    '*********************************************************************************************************
    ' Sub DrawExtras() - called to draw extra graphics
    '
    ' Input(s):     eGraphics   - Graphics handle provided by Windows via OnPaint()
    '*********************************************************************************************************
    Public Overrides Sub DrawExtras(ByVal eGraphics As System.Drawing.Graphics)

        ' Draw extras relative to U-Shaped's outline
        Dim CD As Single = mCanalDepth                  ' Canal depth
        Dim CW As Single = mCanalWidth                  ' Top Width of canal
        Dim BH As Single = mBottomHeight                ' Height from canal bottom to section bottom
        Dim DF As Single = mDiamFocalDist               ' Diameter / Focal Distance of this Section
        Dim SH As Single = CD - BH                      ' Section height

        Dim x, y, w, h As Single
        Dim x1, x2, y1, y2 As Single

        ' Diameter graphic
        x = mViewPort.X + mHorzOffset + (CW - DF) * mHorzScale / 2
        y = mViewPort.Y + mVertOffset + (SH - DF) * mVertScale
        w = DF * mHorzScale
        h = w

        x1 = x
        y1 = y + h / 2
        x2 = x + w
        y2 = y1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

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

    End Sub

    '*********************************************************************************************************
    ' Sub AnnotateDrawing() - annotate cross section's printable drawing
    '*********************************************************************************************************
    Public Overrides Sub AnnotateDrawing(ByVal eGraphics As Graphics)

        ' Position 'Annotations' relative to U-shaped's outline
        Dim x1, y1, dx As Single

        ' Diameter / Focal Distance
        Dim DF As Single = mSection.DiameterFocalD
        Dim DFtext As String = My.Resources.Diameter & ": " & UnitsDialog.UiValueUnitsText(DF, "m")
        Dim DFsize As RectangleF = MeasureString(eGraphics, DFtext, Me.Font)

        dx = (mOuter.Last.X - mOuter.First.X - DFsize.Right) / 2

        x1 = mOuter.First.X + dx
        y1 = mOuter.First.Y - DFsize.Height
        eGraphics.DrawString(DFtext, Me.Font, mBlackBrush, x1, y1)

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - called to position contained Controls
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()

        ' Position Controls relative to U-Shaped's outline
        Dim CD As Single = mCanalDepth                  ' Canal depth
        Dim CW As Single = mCanalWidth                  ' Top Width of canal
        Dim BH As Single = mBottomHeight                ' Height from canal bottom to section bottom
        Dim DF As Single = mDiamFocalDist               ' Diameter / Focal Distance of this Section
        Dim SH As Single = CD - BH                      ' Section height

        ' Thumbnail graphic
        Dim x As Single = Me.Thumbnail.Location.X
        Dim y As Single = Me.Height - Me.Thumbnail.Height - 5
        Dim loc As Point = New Point(CInt(x), CInt(y))
        PositionControl(Me.Thumbnail, loc)

        ' Diameter control
        Dim h, w As Single

        x = mViewPort.X + mHorzOffset + (CW - DF) * mHorzScale / 2
        y = mViewPort.Y + mVertOffset + (SH - DF) * mVertScale
        w = DF * mHorzScale
        h = w

        x = CSng(mInner(Half + 1).X - Me.DiameterSingle.Width / 2)
        y += h / 2 - Me.DiameterSingle.Height - Me.Margin.Vertical
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
        Dim DFD As Single = Me.DiameterSingle.SiValue
        SetDFD(DFD)
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
