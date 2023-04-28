
'*************************************************************************************************************
' Class VShapedInVShapedControl - UserControl for drawing & editing a VShaped-In-VShaped cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'
' Note - this cross-section is used only in the Control Section of the flume and only when matched to the
'        Approach Channel's VShaped cross-section
'*************************************************************************************************************
Imports Flume.Globals
Imports WinFlume.WinFlumeSectionType

Public Class VShapedInVShapedControl
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
                Debug.Assert(mFlume.Section(cApproach).Shape = shVShaped)
                ' Match Control Section cross-section to Approach Channel cross-section
                With mSection
                    .D1 = mFlume.SillHeight
                    .Z3 = mFlume.Section(cApproach).Z1
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

            Dim apprChan As Flume.SectionType = mFlume.Section(cApproach)

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim CW As Single = mCanalWidth              ' Top Width of canal
            Dim SH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim SW As Single = apprChan.TopWidth(CD, False) ' Top Width of this Section

            Dim D1 As Single = mSection.D1              ' Inner sill height
            Dim VH As Single = SH - D1                  ' V-Shaped height from canal bottom
            Dim VD As Single = CD - VH                  ' V-Shaped depth from canal top

            ' Define the V-shaped cross section shape
            Dim vShaped(3) As PointF
            Dim x1, x2, y1, y2 As Single

            x1 = mViewPort.X + mHorzOffset + (CW - SW) * mHorzScale / 2  ' Left side
            y1 = mViewPort.Y + mVertOffset
            x2 = x1 + SW * mHorzScale / 2
            y2 = y1 + VD * mVertScale
            vShaped(0) = New PointF(x1, y1)
            vShaped(1) = New PointF(x2, y2)

            x1 = x2                                     ' Right side
            y1 = y2
            x2 = x1 + SW * mHorzScale / 2
            y2 = y1 - VD * mVertScale
            vShaped(2) = New PointF(x1, y1)
            vShaped(3) = New PointF(x2, y2)

            OuterOutline = vShaped
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
            Dim CW As Single = mCanalWidth              ' Top Width of canal
            Dim BH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim SW As Single = mChannelWidth            ' Top Width of this Section
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

            InnerOutline = vShaped
        Catch ex As Exception
            InnerOutline = Nothing
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete V-shaped outline
            Dim Vshaped As PointF() = Me.InnerOutline(SectionIdx, ViewPort)
            ' Extract invert outline from V-shaped outline
            Dim invert(1) As PointF

            invert(0) = Vshaped(1)
            invert(1) = Vshaped(2)

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
            Dim Z1 As Single = mSection.Z1              ' Trapezoid side slope

            Dim dy As Single = RH * mVertScale
            Dim dx As Single = dy / Z1

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
    ' Sub UpdateControlValues() - called to update contained Controls' values
    '*********************************************************************************************************
    Protected Overrides Sub UpdateControlValues()
        MyBase.UpdateControlValues()

        Dim curShape As Integer = WinFlumeForm.MatchedControlShape
        If Not (curShape = shVShapedInVShaped) Then
            Return
        End If

        Debug.Assert(mSection.Z3 = mFlume.Section(cApproach).Z1)

        ' Slope (Z1) control
        Me.Z1Single.Label = Me.Z1Key.BaseText
        Me.Z1Single.SiDefaultValue = mDefaultSection.Z1
        Me.Z1Single.SiValue = mSection.Z1
        Me.Z1Single.IsReadOnly = False
        Me.Z1Single.ReadOnlyMsgBox = Nothing
        Me.Z1Key.ShowValue(Me.Z1Single.UiValueText)

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

        ' Position 'Extras' relative to V-shaped's outline
        Dim x1, x2, y1, y2 As Single
        Dim x1Max As Single = mInner(2).X

        ' Slope graphic
        x1 = mInner(3).X - Me.Z1Single.Width
        x1 = Math.Max(x1, x1Max)
        y1 = mInner(3).Y
        x2 = mInner(3).X
        y2 = y1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

        If (0 < Me.Z1Single.SiValue) Then
            y2 = y1 + ((x2 - x1) / Me.Z1Single.SiValue)
        End If
        x2 = x1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

        x1 = x1 - 16
        y1 = (y1 + y2) / 2 - 16
        eGraphics.DrawString("1", mBold, mBlackBrush, x1, y1)

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

        ' Position 'Annotations' relative to V-shaped's outline
        Dim x1, x2, y1, y2, dx, dy As Single

        ' Slope
        Dim Z1 As Single = mSection.Z1
        Dim Z1text As String = Format(Z1, "0.0###") & ":1"
        Dim Z1size As SizeF = eGraphics.MeasureString(Z1text, Me.Font)

        dx = (mInner(3).X - mInner(2).X) / 4
        dy = dx / Z1

        x1 = mInner(3).X - 2 * dx
        y1 = mInner(3).Y
        x2 = x1 + dx
        y2 = y1 + dy
        eGraphics.DrawLine(mBlackPen1, x1, y1, x2, y2)

        x1 -= Z1size.Width
        y1 -= Z1size.Height
        eGraphics.DrawString(Z1text, Me.Font, mBlackBrush, x1, y1)

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - called to position contained Controls
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()

        ' Position Controls relative to V-shaped's outline
        Dim x, y As Single

        ' Thumbnail graphic
        x = Me.Thumbnail.Location.X
        y = Me.Height - Me.Thumbnail.Height - 5
        Dim loc As Point = New Point(CInt(x), CInt(y))
        PositionControl(Me.Thumbnail, loc)

        ' Slope (Z1) control
        x = mInner(3).X - Me.Z1Single.Width
        y = mInner(3).Y - Me.Z1Single.Height
        y = Math.Max(y, 32)
        If (y < Me.Z1Single.Height) Then
            y = Me.Z1Single.Height
        End If
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.Z1Single, loc)

        ' SillHeight control/label
        Dim midPt As Integer = CInt(mInner.GetUpperBound(0) / 2)
        x = CSng(mInner(midPt).X + Me.D1Label.Width + Me.Margin.Horizontal)
        y = CSng(mInner(midPt).Y + Me.Margin.Vertical)
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
