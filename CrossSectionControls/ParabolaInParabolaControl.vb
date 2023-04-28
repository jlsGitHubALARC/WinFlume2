
'*************************************************************************************************************
' Class ParabolaInParabolaControl  - UserControl for drawing & editing a Parabola-In-Parabola cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'
' Note - this cross-section is used only in the Control Section of the flume and only when matched to the
'        Approach Channel's Parabola cross-section
'*************************************************************************************************************
Imports Flume.Globals
Imports WinFlume.WinFlumeSectionType

Public Class ParabolaInParabolaControl
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
            Case cControl
                mSectionIdx = SectionIdx
            Case Else
                Debug.Assert(False)
                mSectionIdx = cControl
        End Select

        If (mFlume IsNot Nothing) Then
            mSection = mFlume.Section(mSectionIdx)  ' Flume.Section

            If (WinFlumeForm.ControlMatchedToApproach) Then
                Debug.Assert(mFlume.Section(cApproach).Shape = shParabola)
                ' Match Control Section cross-section to Approach Channel cross-section
                With mSection
                    .D1 = mFlume.SillHeight
                    .DiameterFocalD = mFlume.Section(cApproach).DiameterFocalD
                End With
            Else
                Debug.Assert(False)
            End If
        Else
            Debug.Assert(False)
        End If

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
                x = CSng(Math.Sqrt(2 * ODF * y))
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
        Try
            ' Baseclass initializes cross section data
            MyBase.InnerOutline(SectionIdx, ViewPort)

            Debug.Assert(mSection.GetType Is GetType(WinFlumeSectionType))

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim BH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim SH As Single = CD - BH                  ' Section height
            Dim IDF As Single = mDiamFocalDist          ' Inner Diameter / Focal Distance(2f)
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
                y = SH * pdx / Half
                x = CSng(Math.Sqrt(2 * IDF * y))
                parabola(Half - pdx) = New PointF(-x, y)    ' Left edge
                parabola(Half + pdx) = New PointF(x, y)     ' Right  "
            Next pdx
            '
            ' Translate to drawing coordinates
            '
            For pdx As Integer = 0 To NumPts
                x = parabola(pdx).X
                y = SH - parabola(pdx).Y ' invert Y
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

            InnerOutline = parabola
        Catch ex As Exception
            InnerOutline = Nothing
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete parabola outline
            Dim parabola As PointF() = Me.InnerOutline(SectionIdx, ViewPort)
            ' Extract invert outline from parabola outline
            Dim invert(1) As PointF

            invert(0) = parabola(Half)
            invert(1) = parabola(Half)

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
            Dim DF As Single = mDiamFocalDist           ' Diameter / Focal Distance(2f)

            Dim dy As Single = RH * mVertScale
            Dim dx As Single = CSng(Math.Sqrt(2 * DF * mHorzScale * dy))

            tRamp(0).X = invert(0).X - dx
            tRamp(0).Y = invert(0).Y - dy
            tRamp(1).X = invert(1).X + dx
            tRamp(1).Y = invert(1).Y - dy

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

        ' Inner Focal Distance
        Me.FocalDistanceSingle.Label = Me.FdKey.BaseText & ", 2f"
        Me.FocalDistanceSingle.SiDefaultValue = mDefaultSection.DiameterFocalD
        Me.FocalDistanceSingle.SiValue = mSection.DiameterFocalD
        Me.FocalDistanceSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.FocalDistanceSingle.IsReadOnly = False
        Me.FocalDistanceSingle.ReadOnlyMsgBox = Nothing
        Me.FdKey.ShowValue(Me.FocalDistanceSingle.UiValueUnitsText, "2f")

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

        Dim CD As Single = mCanalDepth          ' Canal depth
        Dim BH As Single = mBottomHeight        ' Height from canal bottom to section bottom
        Dim DF As Single = mDiamFocalDist       ' Diameter / Focal Distance(2f) of this Section
        Dim SH As Single = CD - BH              ' Section height

        Dim x, y As Single
        Dim x1, x2, y1, y2 As Single

        ' Focal Distance graphic
        x = mOuter(Half).X
        y = SH - (DF / 2)
        y *= mVertScale
        y += mViewPort.Y + mVertOffset

        eGraphics.DrawLine(mBlackDashedPen1, x - 5, y, x + 5, y)
        eGraphics.DrawLine(mBlackDashedPen1, x, y - 5, x, y + 5)

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

        ' Position 'Annotations' relative to parabola's outline
        Dim midPt As Integer = CInt(mInner.Length / 2)
        Dim midPtf As PointF = mInner(midPt)

        Dim x1, y1 As Single

        ' Diameter / Focal Distance
        Dim DF As Single = mSection.DiameterFocalD
        Dim DFtext As String = My.Resources.FocalDistance & ", 2f: " & UnitsDialog.UiValueUnitsText(DF, "m")
        Dim DFsize As RectangleF = MeasureString(eGraphics, DFtext, Me.Font)

        x1 = midPtf.X - DFsize.Right / 2
        y1 = mInner.First.Y - DFsize.Height
        eGraphics.DrawString(DFtext, Me.Font, mBlackBrush, x1, y1)

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls relative to outlines
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()

        Dim CD As Single = mCanalDepth          ' Canal depth
        Dim BH As Single = mBottomHeight        ' Height from canal bottom to section bottom
        Dim DF As Single = mDiamFocalDist       ' Diameter / Focal Distance(2f) of this Section
        Dim SH As Single = CD - BH              ' Section height

        ' Thumbnail graphic
        Dim x As Single = Me.Thumbnail.Location.X
        Dim y As Single = Me.Height - Me.Thumbnail.Height - 5
        Dim loc As Point = New Point(CInt(x), CInt(y))
        PositionControl(Me.Thumbnail, loc)

        ' Focal Distance control/label
        x = CSng(mInner(Half).X - (Me.FocalDistanceSingle.Width - Me.FdLabel.Width) / 2)
        y = SH - (DF / 3)
        y *= mVertScale
        y += mViewPort.Y + mVertOffset
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.FocalDistanceSingle, loc, Me.FdLabel)

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
    Protected Sub FocalDistanceSingle_ValueChanged() Handles FocalDistanceSingle.ValueChanged
        Dim DFD As Single = Me.FocalDistanceSingle.SiValue
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
