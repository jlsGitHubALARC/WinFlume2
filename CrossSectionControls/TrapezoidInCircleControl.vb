﻿
'*************************************************************************************************************
' Class TrapezoidInCircleControl - UserControl for drawing & editing a Trapezoid-In-Circle cross section
'
' Inherits CrossSectionControl   - see baseclass for common data/code & overridable methods
'*************************************************************************************************************
Imports Flume.Globals
Imports WinFlume.WinFlumeSectionType

Public Class TrapezoidInCircleControl
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

        Select Case SectionIdx                      ' Flume.Section index
            Case cApproach, cControl, cTailwater
                mSectionIdx = SectionIdx
            Case Else
                Debug.Assert(False)
                mSectionIdx = cApproach
        End Select

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
            Dim PH As Single = SH - D1                  ' Circle height from canal bottom
            Dim PD As Single = CD - PH                  ' Circle depth from canal top
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

            If (y > PD) Then ' circle extends above canal
                a = Math.Asin((PD - cy) / r)
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
                y = PD - circle(pdx).Y ' invert Y
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

    Protected Function CircleWidth(ByVal DF As Single, ByVal Y As Single) As Single
        Dim t1 As Double = DF ^ 2 / 4
        Dim t2 As Double = (DF / 2 - Y) ^ 2
        Dim t3 = t1 - t2
        If (t3 < 0) Then
            CircleWidth = 0
        Else
            CircleWidth = CSng(2 * Math.Sqrt(t3))
        End If
    End Function

    Public Overrides Function InnerOutline(ByVal SectionIdx As Integer,
                                           ByVal ViewPort As RectangleF) As PointF()

        ' Start with outer circle outline
        Dim outer As PointF() = Me.OuterOutline(SectionIdx, ViewPort)

        Try
            Dim oub As Integer = outer.GetUpperBound(0)

            Dim CD As Single = mCanalDepth                      ' Canal depth
            Dim SH As Single = mBottomHeight                    ' Sill height from canal bottom
            Dim SD As Single = CD - SH                          ' Sill depth from canal top

            Dim D1 As Single = mSection.D1                      ' Inner sill height
            Dim DF As Single = mDiamFocalDist                   ' Diameter / Focal Distance(2f)
            Dim PH As Single = SH - D1                          ' Circle height from canal bottom
            Dim PD As Single = CD - PH                          ' Circle depth from canal top
            Dim PW As Single = CircleWidth(DF, PD)              ' Circle top width (at CD)

            Dim Z1 As Single = mSection.Z1                      ' Trapezoid side slope
            Dim CW As Single = mSection.BottomWidth             ' Trapezoid bottom width (i.e. Control width)
            Dim TW As Single = CW + 2 * Z1 * SD                 ' Trapezoid top width (at CD)

            Dim x1, x2, y1, y2 As Single

            ' Translate Sill Depth to outline coordinates
            SD *= mVertScale
            SD += mViewPort.Y + mVertOffset
            '
            ' Build inner outline from outer outline; dependent on fit of trapezoid within circle
            '
            Dim inner(oub) As PointF
            Dim idx As Integer = 0

            ' Case by trapezoid fit within circle
            Dim maxCW As Single = CircleWidth(DF, D1) ' Maximum control width for D1
            If (maxCW <= CW) Then ' Degenerate case: Sill-In-Circle

                For odx As Integer = 0 To NumPts
                    If (SD > outer(odx).Y) Then ' circle section above sill
                        inner(idx) = outer(odx)
                        idx += 1
                    Else ' circle section at or below sill
                        inner(idx).X = outer(odx).X
                        inner(idx).Y = SD
                        idx += 1

                        While (odx <= oub)
                            If (outer(odx).Y > SD) Then
                                odx += 1
                            Else
                                Exit While
                            End If
                        End While

                        If (odx <= oub) Then
                            inner(idx).X = outer(odx).X
                            inner(idx).Y = SD
                            idx += 1

                            inner(idx) = outer(odx)
                            idx += 1
                            odx += 1
                        End If
                    End If
                Next odx

            Else ' Trapezoid-In-Circle

                If (TW <= PW) Then ' Trapezoid does not intersect with circle

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

                Else ' Trapezoid and circle intersect

                    ' Find trapezoid/circle intersection point; ported from Winflume.bas
                    Dim xa As Single = CW / 2
                    Dim ya As Single = -DF / 2 + D1

                    Dim X, Y As Double

                    If (Z1 <= 0) Then
                        X = CW / 2
                        Y = Math.Sqrt(DF ^ 2 / 4 - xa ^ 2)
                        TW = CW
                    Else
                        Dim A As Double = 1 + 1 / Z1 ^ 2
                        Dim B As Double = 2 * (ya / Z1 - xa / Z1 ^ 2)
                        Dim C As Double = (ya - xa / Z1) ^ 2 - DF ^ 2 / 4

                        X = (-B + Math.Sqrt(B ^ 2 - 4 * A * C)) / (2 * A)
                        Y = ya + (X - xa) / Z1
                        TW = CSng(X * 2)
                    End If

                    Y = Y + DF / 2

                    ' Translate trapezoid top to outline coordinates
                    Y = PD - Y ' invert
                    Y *= mVertScale
                    Y += mViewPort.Y + mVertOffset

                    For odx As Integer = 0 To NumPts
                        If (CSng(Y) > outer(odx).Y) Then ' circle section above trapezoid
                            inner(idx) = outer(odx)
                            idx += 1
                        Else ' circle section at or below trapezoid
                            x1 = outer(odx).X                           ' Left edge
                            y1 = outer(odx).Y ' CSng(Y)
                            inner(idx).X = x1
                            inner(idx).Y = y1
                            idx += 1

                            x1 += (TW - CW) * mHorzScale / 2
                            y1 = SD
                            inner(idx).X = x1
                            inner(idx).Y = y1
                            idx += 1

                            If (inner(idx - 2).Y > inner(idx - 1).Y) Then
                                inner(idx - 2).Y = inner(idx - 1).Y
                            End If

                            x1 += CW * mHorzScale                       ' Invert / Sill
                            y1 = SD
                            inner(idx).X = x1
                            inner(idx).Y = y1
                            idx += 1

                            While (odx <= oub) ' skip outer below trapezoid
                                If (outer(odx).Y >= CSng(Y)) Then
                                    odx += 1
                                Else
                                    Exit While
                                End If
                            End While

                            odx -= 1
                            x1 = outer(odx).X                           ' Right edge
                            y1 = outer(odx).Y ' CSng(Y)

                            If (Z1 <= 0) Then
                                inner(idx - 1).X = x1
                            End If

                            inner(idx).X = x1
                            inner(idx).Y = y1
                            idx += 1

                            If (odx <= oub) Then
                                inner(idx) = outer(odx)
                                idx += 1
                            End If
                        End If
                    Next odx

                End If
            End If

            ' Inner outline must have at least two points
            If (idx = 1) Then ' only one point; duplicate it
                inner(1) = inner(0)
                idx += 1
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
            ' Get complete outer Trapezoid-In-Circle outline
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
            ' Get complete inner Trapezoid-In-Circle outline
            Dim inner As PointF() = Me.InnerOutline(SectionIdx, ViewPort)
            ' Extract trapezoid outline from inner outline
            Dim trapezoid(3) As PointF

            ' Check for degenerate cases (e.g. sill)
            If (inner.Length < 3) Then
                If (inner.Length = 0) Then
                    Debug.Assert(False)
                ElseIf (inner.Length = 1) Then
                    trapezoid(0) = inner(0)
                    trapezoid(1) = inner(0)
                    trapezoid(2) = inner(0)
                    trapezoid(3) = inner(0)
                Else ' Length = 2
                    trapezoid(0) = inner(0)
                    trapezoid(1) = inner(0)
                    trapezoid(2) = inner(1)
                    trapezoid(3) = inner(1)
                End If

                TrapezoidOutline = trapezoid
                Exit Function
            End If

            Dim midPt As Integer = CInt(Math.Floor(inner.GetUpperBound(0) / 2))

            Dim D1 As Single = mSection.D1              ' Inner sill height
            If (D1 <= 0) Then ' no trapezoid
                trapezoid(0) = inner(midPt - 1)
                trapezoid(1) = inner(midPt)
                trapezoid(2) = inner(midPt)
                trapezoid(3) = inner(midPt + 1)
            Else ' trapezoid
                If (inner.Length = 3) Then
                    trapezoid(0) = inner(0)
                    trapezoid(1) = inner(1)
                    trapezoid(2) = inner(1)
                    trapezoid(3) = inner(2)
                ElseIf (inner.Length = 4) Then
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

        ' Bottom Width control
        Me.BottomWidthSingle.Label = Me.BwKey.BaseText
        Me.BottomWidthSingle.SiDefaultValue = mDefaultSection.BottomWidth
        Me.BottomWidthSingle.SiValue = mSection.BottomWidth
        Me.BottomWidthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.BwKey.ShowValue(Me.BottomWidthSingle.UiValueUnitsText)

        ' Slope (Z1) control
        Me.Z1Single.Label = Z1Key.BaseText
        Me.Z1Single.SiDefaultValue = mDefaultSection.Z1
        Me.Z1Single.SiValue = mSection.Z1
        Me.Z1Key.ShowValue(Me.Z1Single.UiValueText)

        ' Circle diameter
        Me.DiameterSingle.Label = DiameterKey.BaseText
        Me.DiameterSingle.SiDefaultValue = mDefaultSection.DiameterFocalD
        Me.DiameterSingle.SiValue = mSection.DiameterFocalD
        Me.DiameterSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        If (OuterIsReadOnly) Then
            Me.DiameterSingle.IsReadOnly = True
            Me.DiameterSingle.ReadOnlyMsgBox = ControlMatchedToApproachDialog
        Else
            Me.DiameterSingle.IsReadOnly = False
            Me.DiameterSingle.ReadOnlyMsgBox = Nothing
        End If
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
            Dim CW As Single = mCanalWidth          ' Top Width of canal
            Dim D1 As Single = mSection.D1          ' Inner sill height
            Dim PB As Single = mBottomHeight - D1   ' Height from canal bottom to circle bottom
            Dim DF As Single = mDiamFocalDist       ' Focal Distance(2f) of circle
            Dim SH As Single = CD - PB              ' Section height

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
            x1 = sill(1).X
            y1 = sill(1).Y
            x2 += D1Label.Width + Me.SillHeightSingle.Width
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

            Dim midPt As Integer = CInt(mOuter.GetUpperBound(0) / 2)
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
            Dim DFtext As String = My.Resources.Diameter & ": " & UnitsDialog.UiValueUnitsText(DF, "m")
            Dim DFsize As RectangleF = MeasureString(eGraphics, DFtext, Me.Font)

            dx = (mOuter.Last.X - mOuter.First.X - DFsize.Right) / 2

            x1 = mOuter.First.X + dx
            y1 = mOuter.First.Y - DFsize.Height
            eGraphics.DrawString(DFtext, Me.Font, mBlackBrush, x1, y1)

            ' Sill Height
            Dim D1 As Single = mSection.D1
            Dim D1Txt As String = UnitsDialog.UiValueUnitsText(D1, "m")
            Dim D1siz As RectangleF = MeasureString(eGraphics, D1Txt, Me.Font)
            x1 = sill(1).X
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

            Dim DF As Single = mDiamFocalDist       ' Focal Distance(2f) of circle

            ' Thumbnail graphic
            Dim x As Single = Me.Thumbnail.Location.X
            Dim y As Single = Me.Height - Me.Thumbnail.Height - 2 * Me.Margin.Vertical
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
            y = trapezoid(3).Y - Me.Z1Single.Height
            loc = New Point(CInt(x), CInt(y))
            PositionControl(Me.Z1Single, loc, Me.Z1Label)

            ' Diameter control/label
            Dim Half As Integer = CInt(mOuter.GetUpperBound(0) / 2)
            x = CSng(mOuter(Half).X - (Me.DiameterSingle.Width - Me.DiaLabel.Width) / 2)
            y = mOuter(Half).Y + 2 * Me.Margin.Vertical
            loc = New Point(CInt(x), CInt(y))
            PositionControl(Me.DiameterSingle, loc, Me.DiaLabel)

            ' SillHeight control/label
            x = (trapezoid(1).X + trapezoid(2).X + DF * mHorzScale) / 2 + Me.D1Label.Width
            y = trapezoid(2).Y + Me.Margin.Vertical + 2
            loc = New Point(CInt(x), CInt(y))
            PositionControl(Me.SillHeightSingle, loc, Me.D1Label)

        Catch ex As Exception
            Debug.Assert(False)
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

    Protected Sub DiameterSingle_ValueChanged() Handles DiameterSingle.ValueChanged
        Dim Diameter As Single = Me.DiameterSingle.SiValue
        SetDiameter(Diameter)
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
