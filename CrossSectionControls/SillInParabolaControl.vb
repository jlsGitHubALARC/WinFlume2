
'*************************************************************************************************************
' Class SillInParabolaControl  - UserControl for drawing & editing a Sill-In-Parabola cross section
'
' Inherits CrossSectionControl - see baseclass for common data/code & overridable methods
'*************************************************************************************************************
Imports WinFlume.WinFlumeSectionType

Public Class SillInParabolaControl

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
            Dim inner(outer.GetUpperBound(0)) As PointF

            Dim idx As Integer = 0
            For odx As Integer = 0 To NumPts
                If (SD > outer(odx).Y) Then ' parabolic section above sill
                    inner(idx) = outer(odx)
                    idx += 1

                ElseIf (SD = outer(odx).Y) Then ' parabolic section at sill
                    inner(idx) = outer(odx)
                    idx += 1
                    odx += 1

                    If (outer(odx).Y > SD) Then
                        While (outer(odx).Y > SD)
                            odx += 1
                        End While

                        inner(idx).X = outer(odx).X
                        inner(idx).Y = SD
                        idx += 1
                        odx += 1
                    Else
                        inner(idx) = outer(odx)
                        idx += 1
                    End If

                Else ' parabolic section below sill
                    inner(idx).X = outer(odx).X
                    inner(idx).Y = SD
                    idx += 1
                    odx += 1

                    While (outer(odx).Y > SD)
                        odx += 1
                    End While

                    inner(idx).X = outer(odx).X
                    inner(idx).Y = SD
                    idx += 1
                End If
            Next odx

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

        Dim DF As Single = mSection.DiameterFocalD
        Dim D1 As Single = mSection.D1

        ' Focal Distance
        Me.FocalDistanceSingle.Label = Me.FdKey.BaseText & ", 2f"
        Me.FocalDistanceSingle.SiDefaultValue = mDefaultSection.DiameterFocalD
        Me.FocalDistanceSingle.SiValue = DF
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
        Me.SillHeightSingle.SiValue = D1
        Me.SillHeightSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.D1Key.ShowValue(Me.SillHeightSingle.UiValueUnitsText, "D1")

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

        ' Top Width
        Dim TWtxt As String = UnitsDialog.UiValueUnitsText(mChannelWidth, "m")
        Me.TwKey.ShowValue(TWtxt)

        ' Sill Width
        Dim SWval As Single = 2 * CSng(Math.Sqrt(2 * DF * D1))
        Dim SWtxt As String = UnitsDialog.UiValueUnitsText(SWval, "m")
        Me.SwKey.ShowValue(SWtxt)

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
    ' Sub DrawExtras() - draw extra graphics relative to outline
    '
    ' Input(s):     eGraphics   - Graphics object provided by Windows via OnPaint()
    '*********************************************************************************************************
    Public Overrides Sub DrawExtras(ByVal eGraphics As System.Drawing.Graphics)
        Try ' catch, but ignore, drawing exceptions

            Dim CD As Single = mCanalDepth          ' Canal depth
            Dim D1 As Single = mSection.D1          ' Inner sill height
            Dim BH As Single = mBottomHeight - D1   ' Height from canal bottom to section bottom
            Dim DF As Single = mDiamFocalDist       ' Diameter / Focal Distance(2f) of this Section
            Dim SH As Single = CD - BH              ' Section height

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
            midPt = CInt(mInner.GetUpperBound(0) / 2)
            x1 = mInner(midPt + 1).X
            y1 = mInner(midPt + 1).Y
            x2 = mOuter.Last.X
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

            midPt = CInt(mOuter.GetUpperBound(0) / 2)
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
            Dim DFtxt As String = My.Resources.FocalDistance & ", 2f: " & UnitsDialog.UiValueUnitsText(DF, "m")
            Dim DFsiz As RectangleF = MeasureString(eGraphics, DFtxt, Me.Font)

            dx = (mOuter.Last.X - mOuter.First.X - DFsiz.Right) / 2

            x1 = mOuter.First.X + dx
            y1 = mOuter.First.Y - DFsiz.Height
            eGraphics.DrawString(DFtxt, Me.Font, mBlackBrush, x1, y1)

            ' Sill Height
            Dim D1 As Single = mSection.D1
            Dim D1Txt As String = UnitsDialog.UiValueUnitsText(D1, "m")
            Dim D1siz As RectangleF = MeasureString(eGraphics, D1Txt, Me.Font)
            x1 = sill(1).X
            y1 = sill(1).Y
            eGraphics.DrawString(D1Txt, Me.Font, mBlackBrush, x1, y1)

            ' Sill Width
            Dim SWval As Single = 2 * CSng(Math.Sqrt(2 * DF * D1))
            Dim SWtxt As String = UnitsDialog.UiValueUnitsText(SWval, "m")
            Dim SWsiz As RectangleF = MeasureString(eGraphics, SWtxt, Me.Font)
            x1 = (sill(0).X + sill(1).X - SWsiz.Width) / 2
            y1 = sill(0).Y - SWsiz.Height
            eGraphics.DrawString(SWtxt, Me.Font, mBlackBrush, x1, y1)

        Catch ex As Exception
            Debug.Assert(False)
        End Try
    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()
        Try ' catch, but ignore, drawing exceptions

            ' Position Controls relative to parabola's outline
            Dim sill As PointF() = Me.SillOutline(mSectionIdx, mViewPort)

            ' Thumbnail graphic
            Dim x As Single = Me.Thumbnail.Location.X
            Dim y As Single = Me.Height - Me.Thumbnail.Height - 5
            Dim loc As Point = New Point(CInt(x), CInt(y))
            PositionControl(Me.Thumbnail, loc)

            ' FocalDistance control/label
            Dim midPt As Integer = CInt(mOuter.GetUpperBound(0) / 2)
            x = CSng(mOuter(midPt).X - Me.FocalDistanceSingle.Width / 2)
            y = mOuter(midPt).Y + Me.Margin.Vertical
            loc = New Point(CInt(x), CInt(y))
            PositionControl(Me.FocalDistanceSingle, loc, Me.FdLabel)

            ' SillHeight control/label
            x = CSng(mOuter.Last.X - Me.SillHeightSingle.Width)
            x = Math.Max(x, Me.FocalDistanceSingle.Location.X)
            y = sill(1).Y + Me.Margin.Vertical
            y = Math.Min(y, Me.FocalDistanceSingle.Location.Y - Me.SillHeightSingle.Height)
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
