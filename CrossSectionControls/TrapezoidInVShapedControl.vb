
'*************************************************************************************************************
' Class TrapezoidInVShapedControl  - UserControl for drawing & editing a Trapezoid-In-VShaped cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'*************************************************************************************************************
Imports Flume.Globals
Imports WinFlume.WinFlumeSectionType

Public Class TrapezoidInVShapedControl
    Inherits CrossSectionControl

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

        Select Case SectionIdx                  ' Flume.Section index
            Case cControl
                mSectionIdx = SectionIdx
            Case Else
                Debug.Assert(False)
                mSectionIdx = cControl
        End Select

        mSection = mFlume.Section(mSectionIdx)
        With mSection
            .Z3 = mFlume.Section(cApproach).Z1
        End With

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

            Dim CD As Single = mCanalDepth                  ' Depth of canal
            Dim CW As Single = mCanalWidth                  ' Top Width of canal
            Dim SH As Single = mBottomHeight                ' Sill height from canal bottom

            Dim D1 As Single = mSection.D1                  ' Inner sill height
            Dim TH As Single = SH - D1                      ' Outer trapezoid height from canal bottom

            Dim BW As Single = 0 ' mSection.OuterBottomWidth    ' Bottom width of outer trapezoid
            Dim Z3 As Single = mSection.Z3                  ' Side slope of outer trapezoid
            Dim TW As Single = BW + 2 * Z3 * mChannelDepth  ' Top Width of outer trapezoid

            ' Define the outer trapezoid cross section shape
            Dim trapezoid(3) As PointF
            Dim x1, x2, y1, y2 As Single

            x1 = mViewPort.X + mHorzOffset + (CW - TW) * mHorzScale / 2  ' Left edge
            y1 = mViewPort.Y + mVertOffset
            x2 = x1 + (TW - BW) * mHorzScale / 2
            y2 = y1 + (CD - TH) * mVertScale
            trapezoid(0) = New PointF(x1, y1)
            trapezoid(1) = New PointF(x2, y2)

            x1 = x2                                     ' Invert / Sill
            y1 = y2
            x2 = x1 + BW * mHorzScale
            y2 = trapezoid(1).Y
            trapezoid(2) = New PointF(x2, y2)

            x1 = x2                                     ' Right edge
            y1 = y2
            x2 = x1 + (TW - BW) * mHorzScale / 2
            y2 = trapezoid(0).Y
            trapezoid(3) = New PointF(x2, y2)

            OuterOutline = trapezoid
        Catch ex As Exception
            OuterOutline = Nothing
        End Try
    End Function

    Public Overrides Function InnerOutline(ByVal SectionIdx As Integer,
                                           ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Baseclass initializes cross section data
            MyBase.InnerOutline(SectionIdx, ViewPort)

            Dim CD As Single = mCanalDepth                  ' Depth of canal
            Dim CW As Single = mCanalWidth                  ' Top Width of canal
            Dim SH As Single = mBottomHeight                ' Sill height from canal bottom

            Dim D1 As Single = mSection.D1                  ' Inner sill height
            Dim TH As Single = mChannelDepth - D1           ' Inner trapezoid height from canal bottom

            Dim BW As Single = mSection.BottomWidth         ' Bottom width of inner trapezoid
            Dim Z1 As Single = mSection.Z1                  ' Side slope of inner trapezoid
            Dim TW As Single = BW + 2 * Z1 * TH             ' Top Width of inner trapezoid

            ' Define the inner trapezoid cross section shape
            Dim trapezoid(3) As PointF
            Dim x1, x2, y1, y2 As Single

            x1 = mViewPort.X + mHorzOffset + (CW - TW) * mHorzScale / 2  ' Left edge
            y1 = mViewPort.Y + mVertOffset
            x2 = x1 + (TW - BW) * mHorzScale / 2
            y2 = y1 + (CD - SH) * mVertScale
            trapezoid(0) = New PointF(x1, y1)
            trapezoid(1) = New PointF(x2, y2)

            x1 = x2                                     ' Invert / Sill
            y1 = y2
            x2 = x1 + BW * mHorzScale
            y2 = trapezoid(1).Y
            trapezoid(2) = New PointF(x2, y2)

            x1 = x2                                     ' Right edge
            y1 = y2
            x2 = x1 + (TW - BW) * mHorzScale / 2
            y2 = trapezoid(0).Y
            trapezoid(3) = New PointF(x2, y2)

            InnerOutline = trapezoid
        Catch ex As Exception
            InnerOutline = Nothing
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete outer trapezoid outline
            Dim trapezoid As PointF() = Me.OuterOutline(SectionIdx, ViewPort)
            ' Extract invert outline from trapezoid outline
            Dim invert(1) As PointF

            invert(0) = trapezoid(1)
            invert(1) = trapezoid(2)

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

        Dim curShape As Integer = WinFlumeForm.MatchedControlShape
        If Not (curShape = shTrapezoidInVShaped) Then
            Return
        End If

        Debug.Assert(mSection.Z3 = mFlume.Section(cApproach).Z1)

        ' Bottom Width control (inner shape)
        Me.BottomWidthSingle.Label = Me.BottomWidthKey.BaseText
        Me.BottomWidthSingle.SiDefaultValue = mDefaultSection.BottomWidth
        Me.BottomWidthSingle.SiValue = mSection.BottomWidth

        If (WinFlumeForm.ControlMatchedToApproach) Then
            If (Me.BottomWidthSingle.SiValue > Me.SillHeightSingle.SiValue) Then
                Me.BottomWidthSingle.SiValue = Me.SillHeightSingle.SiValue
                SetControlBW(Me.BottomWidthSingle.SiValue)
            End If
        End If

        Me.BottomWidthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.BottomWidthKey.ShowValue(Me.BottomWidthSingle.UiValueUnitsText)

        ' Slope (Z1) control (inner shape)
        Me.Z1Single.Label = Me.Z1Key.BaseText
        Me.Z1Single.SiDefaultValue = mDefaultSection.Z1
        Me.Z1Single.SiValue = mSection.Z1
        Me.Z1Key.ShowValue(Me.Z1Single.UiValueText)

        ' Inner Sill Height (D1) control
        Me.SillHeightSingle.Label = D1Key.BaseText & ", D1"
        Me.SillHeightSingle.SiDefaultValue = mDefaultSection.D1
        Me.SillHeightSingle.SiValue = mSection.D1
        Me.SillHeightSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.D1Key.ShowValue(Me.SillHeightSingle.UiValueUnitsText)

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
    ' Sub DrawExtras()      - draw extra graphics for control graphics
    ' Sub AnnotateDrawing() - add annotations to printable cross section drawing
    '
    ' Input(s):     eGraphics   - Graphics object provided by Windows via OnPaint()
    '*********************************************************************************************************
    Public Overrides Sub DrawExtras(ByVal eGraphics As Graphics)

        ' Position 'Extras' relative to inner trapezoid's outline
        Dim x1, x2, y1, y2 As Single

        ' Slope graphic
        x1 = mInner(3).X - Me.Z1Single.Width
        x1 = Math.Max(x1, mInner(2).X)
        y1 = mInner(3).Y
        x2 = mInner(3).X
        y2 = y1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)    ' Horizontal line

        If (0 < Me.Z1Single.SiValue) Then
            y2 = y1 + ((x2 - x1) / Me.Z1Single.SiValue)
        End If
        x2 = x1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)    ' Vertical line

        ' Slope label along vertical line
        x1 = x1 - 16
        y1 = (y1 + y2) / 2 - 8
        eGraphics.DrawString("1", mBold, mBlackBrush, x1, y1)

        ' Sill Height graphic
        x1 = mInner(2).X
        y1 = mInner(2).Y
        x2 = mOuter(3).X
        y2 = y1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

        x1 = mOuter(2).X
        y1 = mOuter(2).Y
        y2 = y1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

    End Sub

    '*********************************************************************************************************
    ' Sub AnnotateDrawing() - annotate cross section's printable drawing
    '*********************************************************************************************************
    Public Overrides Sub AnnotateDrawing(ByVal eGraphics As Graphics)

        ' Position 'Annotations' relative to simple trapezoid's outline
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)

        Dim x1, x2, y1, y2, dx, dy As Single

        ' Slope
        Dim Z1 As Single = mSection.Z1
        Dim Z1text As String = Format(Z1, "0.0###") & ":1"
        Dim Z1size As SizeF = eGraphics.MeasureString(Z1text, Me.Font)

        dx = (outer(3).X - outer(2).X) / 4
        dy = dx / Z1

        x1 = outer(3).X - 2 * dx
        y1 = outer(3).Y
        x2 = x1 + dx
        y2 = y1 + dy
        eGraphics.DrawLine(mBlackPen1, x1, y1, x2, y2)

        x1 -= Z1size.Width
        y1 -= Z1size.Height
        eGraphics.DrawString(Z1text, Me.Font, mBlackBrush, x1, y1)

        ' Bottom Width
        Dim BW As Single = mSection.BottomWidth
        Dim BWtext As String = UnitsDialog.UiValueUnitsText(BW, "m")
        Dim BWsize As SizeF = eGraphics.MeasureString(BWtext, Me.Font)

        dx = (outer(2).X - outer(1).X - BWsize.Width) / 2

        x1 = outer(1).X + dx
        y1 = outer(1).Y + 2
        eGraphics.DrawString(BWtext, Me.Font, mBlackBrush, x1, y1)

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()

        ' Thumbnail graphic
        Dim x As Single = Me.Thumbnail.Location.X
        Dim y As Single = Me.Height - Me.Thumbnail.Height - 2 * Me.Margin.Vertical
        Dim loc As Point = New Point(CInt(x), CInt(y))
        PositionControl(Me.Thumbnail, loc)

        ' Bottom Width control
        x = (mInner(1).X + (mInner(2).X - Me.BottomWidthSingle.Width)) / 2
        x = Math.Max(x, mInner(1).X)
        y = mInner(1).Y + Me.Margin.Vertical
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.BottomWidthSingle, loc)

        ' Slope (Z1) control
        x = mInner(3).X - Me.Z1Single.Width
        x = Math.Max(x, mInner(2).X)
        x = Math.Min(x, Me.Width - Me.Z1Single.Width)
        y = mInner(3).Y - Me.Z1Single.Height
        y = Math.Max(y, 32)
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.Z1Single, loc)

        ' SillHeight control/label
        x = mOuter(3).X - Me.SillHeightSingle.Width
        y = mInner(2).Y + Me.Margin.Vertical
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
    Protected Sub BottomWidthSingle_ValueChanged() Handles BottomWidthSingle.ValueChanged
        Dim BW As Single = Me.BottomWidthSingle.SiValue

        If (WinFlumeForm.ControlMatchedToApproach) Then
            If (BW > Me.SillHeightSingle.SiValue) Then
                BW = Me.SillHeightSingle.SiValue
            End If
        End If

        SetControlBW(BW)
    End Sub

    Protected Sub Z1Single_ValueChanged() Handles Z1Single.ValueChanged
        Dim Z1 = Me.Z1Single.SiValue
        SetZ1(Z1)
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
