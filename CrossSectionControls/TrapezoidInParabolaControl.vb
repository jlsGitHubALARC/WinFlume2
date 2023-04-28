
'*************************************************************************************************************
' Class TrapezoidInParabolaControl - UserControl for drawing & editing a Trapezoid-In-Parabola cross section
'
' Inherits CrossSectionControl - see baseclass for common data/code & overridable methods
'*************************************************************************************************************
Imports WinFlume.WinFlumeSectionType

Public Class TrapezoidInParabolaControl
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

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim SH As Single = mBottomHeight            ' Sill height from canal bottom
            Dim SD As Single = CD - SH                  ' Sill depth from canal top

            Dim D1 As Single = mSection.D1              ' Inner sill height
            Dim DF As Single = mDiamFocalDist           ' Diameter / Focal Distance(2f)
            Dim PH As Single = SH - D1                  ' Parabola height from canal bottom
            Dim PD As Single = CD - PH                  ' Parabola depth from canal top
            '
            ' Calculate parabola cross section shape in world coordinates
            '
            Dim parabola(NumPts) As PointF

            ' Start at X=0
            Dim x As Single = 0
            Dim y As Single = 0
            parabola(Half) = New PointF(x, y)

            ' Calculate parabola's edges
            For pdx As Integer = 1 To Half
                y = PD * pdx / Half
                x = CSng(Math.Sqrt(2 * DF * y))
                parabola(Half - pdx) = New PointF(-x, y)    ' Left edge
                parabola(Half + pdx) = New PointF(x, y)     ' Right  "
            Next pdx
            '
            ' Translate to drawing coordinates
            '
            For pdx As Integer = 0 To NumPts
                x = parabola(pdx).X
                y = PD - parabola(pdx).Y ' invert Y
                x *= mHorzScale
                y *= mVertScale
                x += mViewPort.X + mHorzOffset
                y += mViewPort.Y + mVertOffset
                parabola(pdx).X = x
                parabola(pdx).Y = y
            Next pdx

            ' Center in ViewPort
            Dim xhalf As Single = CInt((parabola(0).X + parabola(NumPts).X) / 2)
            Dim xOffset As Single = mViewPort.X + mViewPort.Width / 2 - xhalf
            For pdx As Integer = 0 To NumPts
                x = parabola(pdx).X + xOffset
                parabola(pdx).X = x
            Next pdx

            OuterOutline = parabola
        Catch ex As Exception
            OuterOutline = Nothing
        End Try
    End Function

    Public Overrides Function InnerOutline(ByVal SectionIdx As Integer,
                                           ByVal ViewPort As RectangleF) As PointF()

        ' Start with outer parabola outline
        Dim outer As PointF() = Me.OuterOutline(SectionIdx, ViewPort)

        Try
            Dim oub As Integer = outer.GetUpperBound(0)

            Dim CD As Single = mCanalDepth                      ' Canal depth
            Dim SH As Single = mBottomHeight                    ' Sill height from canal bottom
            Dim SD As Single = CD - SH                          ' Sill depth from canal top

            Dim D1 As Single = mSection.D1                      ' Inner sill height
            Dim DF As Single = mDiamFocalDist                   ' Diameter / Focal Distance(2f)
            Dim PH As Single = SH - D1                          ' Parabola height from canal bottom
            Dim PD As Single = CD - PH                          ' Parabola depth from canal top
            Dim PW As Single = CSng(2 * Math.Sqrt(2 * DF * PD)) ' Parabola top width (at CD)

            Dim Z1 As Single = mSection.Z1                      ' Trapezoid side slope
            Dim CW As Single = mSection.BottomWidth             ' Trapezoid bottom width (i.e. control width)
            Dim TW As Single = CW + 2 * Z1 * SD                 ' Trapezoid top width (at CD)

            Dim x1, x2, dx, y1, y2 As Single

            ' Translate Sill Depth to outline coordinates
            SD *= mVertScale
            SD += mViewPort.Y + mVertOffset
            '
            ' Build inner outline from outer outline; dependent on fit of trapezoid within parabola
            '
            Dim inner(oub) As PointF
            Dim idx As Integer = 0

            ' Case by trapezoid fit within parabola
            Dim maxCW As Single = CSng(2 * Math.Sqrt(2 * DF * D1)) ' Maximum control width for D1
            If (maxCW <= CW) Then ' Degenerate case: Sill-In-Parabola

                For odx As Integer = 0 To NumPts
                    If (SD > outer(odx).Y) Then ' parabolic section above sill
                        inner(idx) = outer(odx)
                        idx += 1
                    Else ' parabolic section at or below sill
                        inner(idx).X = outer(odx).X             ' left end of sill
                        inner(idx).Y = SD
                        idx += 1

                        While (odx <= oub)
                            If (outer(odx).Y >= SD) Then
                                odx += 1
                            Else
                                Exit While
                            End If
                        End While

                        If (odx <= oub) Then
                            inner(idx).X = outer(odx - 1).X     ' right end of sill
                            inner(idx).Y = SD
                            idx += 1

                            inner(idx) = outer(odx)
                            idx += 1
                            odx += 1
                        End If
                    End If
                Next odx

            Else ' Trapezoid-In-Parabola

                If (TW <= PW) Then ' Trapezoid does not intersect with parabola

                    x1 = outer(0).X + (PW - TW) * mHorzScale / 2  ' Left edge
                    y1 = outer(0).Y
                    x2 = x1 + (TW - CW) * mHorzScale / 2
                    y2 = SD
                    inner(0) = New PointF(x1, y1)
                    inner(1) = New PointF(x2, y2)

                    x1 = x2                                     ' Invert / Sill
                    y1 = y2
                    x2 = x1 + CW * mHorzScale
                    y2 = y1
                    inner(2) = New PointF(x2, y2)

                    x1 = x2                                     ' Right edge
                    y1 = y2
                    x2 = x1 + (TW - CW) * mHorzScale / 2
                    y2 = outer(0).Y
                    inner(3) = New PointF(x2, y2)

                    idx = 4

                Else ' Trapezoid and parabola intersect

                    ' Find trapezoid/parabola intersection point; ported from Winflume.bas
                    Dim xa As Single = mSection.BottomWidth / 2
                    Dim ya As Single = D1

                    Dim A As Double = Z1 ^ 2
                    Dim B As Double = 2 * Z1 * (xa - ya * Z1) - 2 * DF
                    Dim C As Double = (xa - Z1 * ya) ^ 2

                    Dim Y As Double = (-B + Math.Sqrt(B ^ 2 - 4 * A * C)) / (2 * A)
                    Dim X As Double = Math.Sqrt(2 * DF * Y)
                    TW = CSng(X * 2)

                    ' Translate trapezoid top to outline coordinates
                    Y = PD - Y ' invert
                    Y *= mVertScale
                    Y += mViewPort.Y + mVertOffset

                    For odx As Integer = 0 To NumPts
                        If (Y > outer(odx).Y) Then ' parabolic section above trapezoid
                            inner(idx) = outer(odx)
                            idx += 1
                        Else ' parabolic section at or below trapezoid
                            dx = (TW - CW) * mHorzScale / 2

                            x1 = outer(odx).X + dx                      ' Left edge
                            y1 = SD
                            inner(idx).X = x1
                            inner(idx).Y = y1
                            idx += 1

                            x1 += CW * mHorzScale                       ' Right end of sill
                            y1 = SD
                            inner(idx).X = x1
                            inner(idx).Y = y1
                            idx += 1

                            While (odx <= oub)
                                If (outer(odx).Y > Y) Then
                                    odx += 1
                                Else
                                    Exit While
                                End If
                            End While

                            x1 = outer(odx - 1).X                       ' Right edge
                            y1 = outer(odx - 1).Y ' CSng(Y)
                            inner(idx).X = x1
                            inner(idx).Y = y1
                            idx += 1

                            inner(idx - 2).X = x1 - dx                  ' Correct right end of sill

                            If (odx <= oub) Then
                                inner(idx) = outer(odx)
                                idx += 1
                            End If
                        End If
                    Next odx

                End If
            End If

            ReDim Preserve inner(idx - 1)

            InnerOutline = inner
        Catch ex As Exception
            InnerOutline = outer
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete outer Trapezoid-In-Parabola outline
            Dim outer As PointF() = Me.OuterOutline(SectionIdx, ViewPort)
            ' Extract invert outline from outer outline
            Dim invert(1) As PointF

            invert(0) = outer(Half)
            invert(1) = outer(Half)

            InvertOutline = invert
        Catch ex As Exception
            InvertOutline = Nothing
        End Try
    End Function

    Public Function TrapezoidOutline(ByVal SectionIdx As Integer,
                                     ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete inner Trapezoid-In-Parabola outline
            Dim inner As PointF() = Me.InnerOutline(SectionIdx, ViewPort)
            ' Extract trapezoid outline from inner outline
            Dim trapezoid(3) As PointF
            Dim midPt As Integer = CInt(Math.Floor(inner.GetUpperBound(0) / 2))

            If (inner.Length = 4) Then ' trapezoid does not intersect parabola
                trapezoid = inner
            Else ' trapezoid and parabola intersect

                Dim D1 As Single = mSection.D1              ' Inner sill height
                If (D1 <= 0) Then ' no trapezoid
                    trapezoid(0) = inner(midPt - 1)
                    trapezoid(1) = inner(midPt)
                    trapezoid(2) = inner(midPt)
                    trapezoid(3) = inner(midPt + 1)
                Else ' trapezoid
                    If (inner.Length <= 4) Then
                        trapezoid(0) = inner(0)
                        trapezoid(1) = inner(1)
                        trapezoid(2) = inner(2)
                        trapezoid(3) = inner(3)
                    Else
                        trapezoid(0) = inner(midPt - 1)
                        trapezoid(1) = inner(midPt)
                        trapezoid(2) = inner(midPt + 1)
                        trapezoid(3) = inner(midPt + 2)

                        If (trapezoid(1).Y > trapezoid(2).Y) Then
                            trapezoid(0) = inner(midPt - 2)
                            trapezoid(1) = inner(midPt - 1)
                            trapezoid(2) = inner(midPt)
                            trapezoid(3) = inner(midPt + 1)
                        ElseIf (trapezoid(1).Y < trapezoid(2).Y) Then
                            trapezoid(0) = inner(midPt)
                            trapezoid(1) = inner(midPt + 1)
                            trapezoid(2) = inner(midPt + 2)
                            trapezoid(3) = inner(midPt + 3)
                        End If
                    End If
                End If
            End If

            Debug.Assert(trapezoid(1).Y = trapezoid(2).Y) ' verify sill values

            TrapezoidOutline = trapezoid
        Catch ex As Exception
            Debug.Assert(False)
            TrapezoidOutline = Nothing
        End Try
    End Function

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateControlValues() - update contained Controls' values
    '*********************************************************************************************************
    Protected Overrides Sub UpdateControlValues()
        MyBase.UpdateControlValues()

        ' Bottom Width control (inner shape)
        Me.BottomWidthSingle.Label = Me.BwKey.BaseText
        Me.BottomWidthSingle.SiDefaultValue = mDefaultSection.BottomWidth
        Me.BottomWidthSingle.SiValue = mSection.BottomWidth
        Me.BottomWidthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.BwKey.ShowValue(Me.BottomWidthSingle.UiValueUnitsText)

        ' Slope (Z1) control (inner shape)
        Me.Z1Single.Label = Me.Z1Key.BaseText
        Me.Z1Single.SiDefaultValue = mDefaultSection.Z1
        Me.Z1Single.SiValue = mSection.Z1
        Me.Z1Key.ShowValue(Me.Z1Single.UiValueText)

        ' Focal Distance
        Me.FocalDistanceSingle.Label = Me.FdKey.BaseText & ", 2f"
        Me.FocalDistanceSingle.SiDefaultValue = mDefaultSection.DiameterFocalD
        Me.FocalDistanceSingle.SiValue = mSection.DiameterFocalD
        Me.FocalDistanceSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        If (OuterIsReadOnly) Then
            Me.FocalDistanceSingle.IsReadOnly = True
            Me.FocalDistanceSingle.ReadOnlyMsgBox = ControlMatchedToApproachDialog
        Else
            Me.FocalDistanceSingle.IsReadOnly = False
            Me.FocalDistanceSingle.ReadOnlyMsgBox = Nothing
        End If
        Me.FdKey.ShowValue(Me.FocalDistanceSingle.UiValueUnitsText, "2f")

        ' Inner Sill Height (D1) control
        Me.SillHeightSingle.Label = Me.D1Key.BaseText & ", D1"
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
        Else
            Me.SillHeightSingle.IsReadOnly = False
            Me.SillHeightSingle.ReadOnlyMsgBox = Nothing
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub DrawCrossSection() - draw the cross section graphics
    '
    ' Input(s):     eGraphics   - Graphics object provided by Windows via OnPaint()
    '*********************************************************************************************************
    Protected Overrides Sub DrawCrossSection(ByVal eGraphics As System.Drawing.Graphics)
        MyBase.DrawCrossSection(eGraphics)      ' Baseclass defines ViewPort
        Dim dPen As Drawing.Pen = BlackPen2()   ' Pen for cross section control graphics

        DrawCrossSection(mSectionIdx, mViewPort, eGraphics, dPen)
    End Sub

    '*********************************************************************************************************
    ' Sub DrawExtras() - draw extra graphics relative to outlines
    '
    ' Input(s):     eGraphics   - Graphics object provided by Windows via OnPaint()
    '*********************************************************************************************************
    Public Overrides Sub DrawExtras(ByVal eGraphics As System.Drawing.Graphics)
        Try ' catch, but ignore, exceptions

            Dim sill As PointF() = Me.SillOutline(mSectionIdx, mViewPort)

            Dim CD As Single = mCanalDepth          ' Canal depth
            Dim D1 As Single = mSection.D1          ' Inner sill height
            Dim PB As Single = mBottomHeight - D1   ' Height from canal bottom to parabola bottom
            Dim DF As Single = mDiamFocalDist       ' Focal Distance(2f) of parabola
            Dim SH As Single = CD - PB              ' Section height

            Dim x1, x2, y1, y2 As Single

            ' Focal Distance graphic
            Dim midPt As Integer = CInt(mOuter.GetUpperBound(0) / 2)
            x1 = mOuter(midPt).X
            y1 = SH - (DF / 2)
            y1 *= mVertScale
            y1 += mViewPort.Y + mVertOffset

            eGraphics.DrawLine(mBlackDashedPen1, x1 - 5, y1, x1 + 5, y1)
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1 - 5, x1, y1 + 5)

            ' Sill Height graphic
            x1 = sill(1).X
            y1 = sill(1).Y
            x2 = mOuter.Last.X
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

            midPt = CInt(mOuter.GetUpperBound(0) / 2)
            x1 = mOuter(midPt).X
            y1 = mOuter(midPt).Y
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

        Catch ex As Exception
            Debug.Assert(False)
        End Try
    End Sub

    '*********************************************************************************************************
    ' Sub AnnotateDrawing() - annotate cross section's printable drawing
    '*********************************************************************************************************
    Public Overrides Sub AnnotateDrawing(ByVal eGraphics As Graphics)
        Try ' catch, but ignore, exceptions

            Dim sill As PointF() = Me.SillOutline(mSectionIdx, mViewPort)
            Dim rEdge As PointF() = Me.RightEdgeOutline(mSectionIdx, mViewPort)

            Dim x1, y1, dx As Single

            ' Diameter / Focal Distance
            Dim DF As Single = mSection.DiameterFocalD
            Dim DFtext As String = "2f: " & UnitsDialog.UiValueUnitsText(DF, "m")
            Dim DFsize As RectangleF = MeasureString(eGraphics, DFtext, Me.Font)

            dx = (mOuter.Last.X - mOuter.First.X - DFsize.Right) / 2

            x1 = mOuter.First.X + dx
            y1 = mOuter.First.Y - DFsize.Height
            eGraphics.DrawString(DFtext, Me.Font, mBlackBrush, x1, y1)

            ' Sill Height
            Dim D1 As Single = mSection.D1
            Dim D1Txt As String = UnitsDialog.UiValueUnitsText(D1, "m")
            Dim D1siz As RectangleF = MeasureString(eGraphics, D1Txt, Me.Font)
            x1 = sill(1).X + 8
            y1 = sill(1).Y
            eGraphics.DrawString(D1Txt, Me.Font, mBlackBrush, x1, y1)

            ' Bottom Width
            Dim BW As Single = mSection.BottomWidth
            Dim BWtxt = UnitsDialog.UiValueUnitsText(BW, "m")
            Dim BWsiz As RectangleF = MeasureString(eGraphics, BWtxt, Me.Font)
            x1 = (sill(0).X + sill(1).X - BWsiz.Width) / 2
            y1 = sill(0).Y - BWsiz.Height
            eGraphics.DrawString(BWtxt, Me.Font, mBlackBrush, x1, y1)

            ' Side Slope
            Dim Z1 As Single = mSection.Z1
            Dim Z1txt = Format(Z1, "0.0###") & ":1"
            Dim Z1siz As RectangleF = MeasureString(eGraphics, Z1txt, Me.Font)
            x1 = rEdge(1).X - Z1siz.Width - 8
            y1 = rEdge(1).Y - Z1siz.Height
            eGraphics.DrawString(Z1txt, Me.Font, mBlackBrush, x1, y1)

        Catch ex As Exception
            Debug.Assert(False)
        End Try
    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls relative to outlines
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()
        Try ' catch, but ignore, exceptions

            Dim trapezoid As PointF() = Me.TrapezoidOutline(mSectionIdx, mViewPort)

            ' Thumbnail graphic
            Dim x As Single = Me.Thumbnail.Location.X
            Dim y As Single = Me.Height - Me.Thumbnail.Height - 5

            Dim loc As Point = New Point(CInt(x), CInt(y))
            PositionControl(Me.Thumbnail, loc)

            ' Bottom Width control
            Dim midPt As Integer = CInt(mOuter.GetUpperBound(0) / 2)
            x = CSng(mOuter(midPt).X - Me.BottomWidthSingle.Width / 2)
            y = trapezoid(2).Y + Me.Margin.Vertical

            loc = New Point(CInt(x), CInt(y))
            PositionControl(Me.BottomWidthSingle, loc)

            ' Slope (Z1) control/label
            x = trapezoid(3).X - Me.Z1Single.Width
            x = Math.Max(x, trapezoid(2).X)
            y = trapezoid(3).Y - Me.Z1Single.Height - Me.Margin.Vertical

            loc = New Point(CInt(x), CInt(y))
            PositionControl(Me.Z1Single, loc)

            x = loc.X - Me.Z1Label.Width
            y = loc.Y + 2
            loc = New Point(CInt(x), CInt(y))
            Me.Z1Label.Location = loc

            ' FocalDistance control/label
            x = CSng(mOuter(midPt).X - Me.FocalDistanceSingle.Width / 2)
            y = mOuter(midPt).Y + Me.Margin.Vertical

            loc = New Point(CInt(x), CInt(y))
            PositionControl(Me.FocalDistanceSingle, loc)

            x = loc.X - Me.FdLabel.Width
            y = loc.Y + 2
            loc = New Point(CInt(x), CInt(y))
            Me.FdLabel.Location = loc

            ' SillHeight control/label
            x = CSng(mOuter.Last.X - Me.SillHeightSingle.Width)
            x = Math.Max(x, Me.BottomWidthSingle.Location.X + Me.BottomWidthSingle.Width + Me.D1Label.Width)
            y = trapezoid(2).Y + Me.Margin.Vertical

            loc = New Point(CInt(x), CInt(y))
            PositionControl(Me.SillHeightSingle, loc)

            x = loc.X - Me.D1Label.Width
            y = loc.Y + 2
            loc = New Point(CInt(x), CInt(y))
            Me.D1Label.Location = loc

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Protected Sub BottomWidthSingle_ValueChanged() Handles BottomWidthSingle.ValueChanged
        Dim BW As Single = Me.BottomWidthSingle.SiValue
        SetControlBW(BW)
    End Sub

    Protected Sub Z1Single_ValueChanged() Handles Z1Single.ValueChanged
        Dim Z1 = Me.Z1Single.SiValue
        SetZ1(Z1)
    End Sub

    Protected Sub FocalDistanceSingle_ValueChanged() Handles FocalDistanceSingle.ValueChanged
        Dim DFD As Single = Me.FocalDistanceSingle.SiValue
        SetDFD(DFD)
    End Sub

    Protected Sub SillHeightSingle_ValueChanged() Handles SillHeightSingle.ValueChanged
        Dim D1 As Single = Me.SillHeightSingle.SiValue
        SetD1(D1)
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
