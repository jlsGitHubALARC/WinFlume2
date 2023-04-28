
'*************************************************************************************************************
' Class SillInUShapedControl    - UserControl for drawing & editing a Sill-In-UShaped cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'*************************************************************************************************************
Imports Flume.Globals
Imports WinFlume.WinFlumeSectionType

Public Class SillInUShapedControl
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
            Dim UH As Single = SH - D1                  ' U-Shaped height from canal bottom
            Dim UD As Single = CD - UH                  ' U-Shaped depth from canal top
            '
            ' Calculate U-Shaped cross section shape in world coordinates
            '
            Dim Ushaped(NumPts + 2) As PointF
            Dim uub As Integer = Ushaped.GetUpperBound(0)

            ' Counter-clockwise (left edge top-to-bottom) then (right edge bottom-to-top)
            Dim r As Double = DF / 2                        ' radius
            Dim cx As Double = 0                            ' circle origin (i.e. center)
            Dim cy As Double = r                            ' 
            Dim a As Double = Math.PI                       ' angle in radians of semi-circle top

            Dim x As Single = CSng(cx + r * Math.Cos(a))    ' left edge top
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
            Dim xhalf As Single = CInt((Ushaped(0).X + Ushaped(NumPts).X) / 2)
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

        ' Start with outer circle outline
        Dim outer As PointF() = Me.OuterOutline(SectionIdx, ViewPort)
        Dim oub As Integer = outer.GetUpperBound(0)

        Try
            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim SH As Single = mBottomHeight            ' Sill height from canal bottom
            Dim SD As Single = CD - SH                  ' Sill depth from canal top

            ' Check for Sill at top of Canal
            If (SD <= 0.001) Then ' degenerate case: just a sill
                Dim sill(1) As PointF
                sill(0) = outer.First
                sill(1) = outer.Last
                InnerOutline = sill
                Exit Try
            End If

            ' Translate Sill Depth to outline coordinates
            SD *= mVertScale
            SD += mViewPort.Y + mVertOffset

            ' Build inner outline from outer outline
            Dim inner(oub) As PointF

            Dim idx As Integer = 0
            For odx As Integer = 0 To oub
                If (SD > outer(odx).Y) Then ' circle section above sill
                    inner(idx) = outer(odx)
                    idx += 1

                ElseIf (SD = outer(odx).Y) Then ' circle section at sill

                    inner(idx) = outer(odx)         ' left-end of sill
                    idx += 1
                    odx += 1

                    While (outer(odx).Y > SD)       ' skip circle below sill
                        odx += 1
                    End While

                    inner(idx).X = outer(odx).X     ' right-end of sill
                    inner(idx).Y = SD
                    idx += 1
                    odx += 1

                Else ' circle section below sill

                    inner(idx).X = outer(odx).X     ' left-end of sill
                    inner(idx).Y = SD
                    idx += 1

                    While (odx <= oub)              ' skip circle below sill
                        If (outer(odx).Y > SD) Then
                            odx += 1
                        Else
                            Exit While
                        End If
                    End While

                    inner(idx).X = outer(odx).X     ' right-end of sill
                    inner(idx).Y = SD
                    idx += 1

                End If
            Next odx

            If Not (inner(idx - 1) = outer(oub)) Then
                inner(idx) = outer(oub)
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
            ' Get complete outer Sill-In-Parabola outline
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

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateControlValues() - update contained Controls' values
    '*********************************************************************************************************
    Protected Overrides Sub UpdateControlValues()
        MyBase.UpdateControlValues()

        Dim DF As Single = mSection.DiameterFocalD
        Dim D1 As Single = mSection.D1

        ' Circle diameter
        Me.DiameterSingle.Label = DiameterKey.BaseText
        Me.DiameterSingle.SiDefaultValue = mDefaultSection.DiameterFocalD
        Me.DiameterSingle.SiValue = DF
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
        Me.SillHeightSingle.SiValue = D1
        Me.SillHeightSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.D1Key.ShowValue(Me.SillHeightSingle.UiValueUnitsText, "D1")

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

        ' Top Width
        Dim TWtxt As String = UnitsDialog.UiValueUnitsText(mChannelWidth, "m")
        Me.TwKey.ShowValue(TWtxt)

        ' Control Width
        Dim CWval As Single
        If (D1 < DF / 2) Then
            CWval = 2 * CSng(Math.Sqrt(D1 - D1 ^ 2))
        Else
            CWval = DF
        End If
        Dim CWtxt As String = UnitsDialog.UiValueUnitsText(CWval, "m")
        Me.CwKey.ShowValue(CWtxt)

    End Sub

    '*********************************************************************************************************
    ' Sub DrawCrossSection() - draw cross section graphics
    '
    ' Input(s):     eGraphics   - Graphics handle provided by Windows via OnPaint()
    '*********************************************************************************************************
    Protected Overrides Sub DrawCrossSection(ByVal eGraphics As System.Drawing.Graphics)
        MyBase.DrawCrossSection(eGraphics)      ' Baseclass defines ViewPort
        Dim dPen As Drawing.Pen = BlackPen2()   ' Pen for cross section control graphics

        DrawCrossSection(mSectionIdx, mViewPort, eGraphics, dPen)
    End Sub

    '*********************************************************************************************************
    ' Sub DrawExtras() - draw extra graphics relative to outlines
    '
    ' Input(s):     eGraphics   - Graphics handle provided by Windows via OnPaint()
    '*********************************************************************************************************
    Public Overrides Sub DrawExtras(ByVal eGraphics As System.Drawing.Graphics)
        Try ' catch, but ignore, drawing exceptions

            Dim sill As PointF() = Me.SillOutline(mSectionIdx, mViewPort)

            Dim CD As Single = mCanalDepth          ' Canal depth
            Dim CW As Single = mCanalWidth          ' Top Width of canal
            Dim D1 As Single = mSection.D1          ' Inner sill height
            Dim BH As Single = mBottomHeight - D1   ' Height from canal bottom to section bottom
            Dim DF As Single = mDiamFocalDist       ' Diameter / Focal Distance of this Section
            Dim SH As Single = CD - BH              ' Section height

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
            x2 = x1 + Me.SillHeightSingle.Width
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

            Dim midPt As Integer = CInt(mOuter.GetUpperBound(0) / 2)
            x1 = mOuter(midPt + 1).X
            y1 = mOuter(midPt + 1).Y
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
        Try ' catch, but ignore, drawing exceptions

            Dim sill As PointF() = Me.SillOutline(mSectionIdx, mViewPort)

            Dim x1, y1, dx As Single

            ' Diameter / Focal Distance
            Dim DF As Single = mSection.DiameterFocalD
            Dim DFtext As String = My.Resources.Diameter & ": " & UnitsDialog.UiValueUnitsText(DF, "m")
            Dim DFsize As RectangleF = MeasureString(eGraphics, DFtext, Me.Font)

            ' Include 'Extras', if they fit
            Dim CD As Single = mFlume.ChannelDepth
            If (DF <= CD * 2) Then
                DrawExtras(eGraphics)
            End If

            dx = (mOuter.Last.X - mOuter.First.X - DFsize.Right) / 2

            x1 = mOuter.First.X + dx
            y1 = mOuter.First.Y - DFsize.Height
            eGraphics.DrawString(DFtext, Me.Font, mBlackBrush, x1, y1)

            ' Sill Height
            Dim D1 As Single = mSection.D1
            Dim D1Text As String = "D1: " & UnitsDialog.UiValueUnitsText(D1, "m")
            Dim D1size As RectangleF = MeasureString(eGraphics, D1Text, Me.Font)
            x1 = mOuter.Last.X + 4
            y1 = sill(1).Y - D1size.Height
            eGraphics.DrawString(D1Text, Me.Font, mBlackBrush, x1, y1)

        Catch ex As Exception
            Debug.Assert(False)
        End Try
    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()
        Try ' catch, but ignore, drawing exceptions

            ' Position Controls relative to circle's outline
            Dim sill As PointF() = Me.SillOutline(mSectionIdx, mViewPort)

            ' Thumbnail graphic
            Dim x As Single = Me.Thumbnail.Location.X
            Dim y As Single = Me.Height - Me.Thumbnail.Height - 2 * Me.Margin.Vertical
            Dim loc As Point = New Point(CInt(x), CInt(y))
            PositionControl(Me.Thumbnail, loc)

            ' Diameter control/label
            Dim Half As Integer = CInt(mOuter.GetUpperBound(0) / 2)
            x = CSng(mOuter(Half).X - (Me.DiameterSingle.Width - Me.DiaLabel.Width) / 2)
            y = mOuter(Half).Y + 2 * Me.Margin.Vertical
            loc = New Point(CInt(x), CInt(y))
            PositionControl(Me.DiameterSingle, loc, Me.DiaLabel)

            ' SillHeight control/label
            x = CSng(sill(1).X + Me.SillHeightSingle.Width / 2)
            y = sill(1).Y + Me.Margin.Vertical
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
    Protected Sub DiameterSingle_ValueChanged() Handles DiameterSingle.ValueChanged
        Dim DFD As Single = Me.DiameterSingle.SiValue
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
