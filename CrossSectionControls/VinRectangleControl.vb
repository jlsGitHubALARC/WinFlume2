
'*************************************************************************************************************
' Class VinRectangleControl     - UserControl for drawing & editing a V in Rectangule cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'
' Note - this cross-section is used only in the Control Section of the flume
'*************************************************************************************************************
Imports Flume.Globals
Imports WinFlume.WinFlumeSectionType

Public Class VinRectangleControl

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
                Debug.Assert(mFlume.Section(cApproach).Shape = shRectangular)
                ' Match Control Section cross-section to Approach Channel cross-section
                With mSection
                    .Z1 = mFlume.Section(cApproach).Z1
                    .BottomWidth = mFlume.Section(cApproach).BottomWidth
                End With
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

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim CW As Single = mCanalWidth              ' Top Width of canal
            Dim BH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim BW As Single = mSection.BottomWidth     ' Width of rectangle bottom
            Dim D1 As Single = mSection.D1              ' V section bottom within rectangle
            Dim SH As Single = CD - BH + D1             ' Section height

            If (CW < BW) Then
                CW = BW
            End If

            ' Define the rectangular cross section shape
            Dim rectangular(3) As PointF
            Dim x1, x2, y1, y2 As Single

            x1 = mViewPort.X + mHorzOffset + (CW - BW) * mHorzScale / 2  ' Left edge
            y1 = mViewPort.Y + mVertOffset
            x2 = x1
            y2 = y1 + SH * mVertScale
            rectangular(0) = New PointF(x1, y1)
            rectangular(1) = New PointF(x2, y2)

            x1 = x2                                     ' Invert / Sill
            y1 = y2
            x2 = x1 + BW * mHorzScale
            y2 = y1
            rectangular(2) = New PointF(x2, y2)

            x1 = x2                                     ' Right edge
            y1 = y2
            x2 = x1
            y2 = y1 - SH * mVertScale
            rectangular(3) = New PointF(x2, y2)

            OuterOutline = rectangular
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
            Dim BW As Single = mSection.BottomWidth     ' Width of rectangle
            Dim SW As Single = mChannelWidth            ' Top Width of this Section

            If (CW < BW) Then
                CW = BW
            End If

            If (SW < BW) Then ' V within rectangle

                Dim SH As Single = CD - BH              ' Section height

                ' Define V-shaped cross section
                Dim vShape(3) As PointF
                Dim x1, x2, y1, y2 As Single

                x1 = mViewPort.X + mHorzOffset + (CW - SW) * mHorzScale / 2  ' Left side
                y1 = mViewPort.Y + mVertOffset
                x2 = x1 + SW * mHorzScale / 2
                y2 = y1 + SH * mVertScale
                vShape(0) = New PointF(x1, y1)
                vShape(1) = New PointF(x2, y2)

                x1 = x2                                 ' Right side
                y1 = y2
                x2 = x1 + SW * mHorzScale / 2
                y2 = y1 - SH * mVertScale
                vShape(2) = New PointF(x1, y1)
                vShape(3) = New PointF(x2, y2)

                InnerOutline = vShape

            Else ' V limited by rectangle

                Dim D1 As Single = mSection.D1          ' V section bottom within rectangle
                Dim SH As Single = CD - BH + D1         ' Section height
                Dim VZ As Single = mSection.Z1          ' V section slope
                Dim VH As Single = SW / 2 / VZ          ' V section height
                Dim VT As Single = D1 + VH              ' V section top within rectangle

                ' Define V-shaped cross section
                Dim vShape(5) As PointF
                Dim x1, x2, x3, y1, y2, y3 As Single

                x1 = mViewPort.X + mHorzOffset + (CW - BW) * mHorzScale / 2  ' Left side
                y1 = mViewPort.Y + mVertOffset
                x2 = x1
                y2 = y1 + (SH - VT) * mVertScale

                vShape(0) = New PointF(x1, y1)
                vShape(1) = New PointF(x2, y2)

                x3 = x1 + SW * mHorzScale / 2           ' Sill
                y3 = y1 + (SH - D1) * mVertScale
                vShape(2) = New PointF(x3, y3)
                vShape(3) = New PointF(x3, y3)

                x2 = x1 + BW * mHorzScale               ' Right side
                y2 = y2
                x3 = x2
                y3 = y1
                vShape(4) = New PointF(x2, y2)
                vShape(5) = New PointF(x3, y3)

                InnerOutline = vShape

            End If
        Catch ex As Exception
            InnerOutline = Nothing
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete rectangular outline
            Dim rectangular As PointF() = Me.OuterOutline(SectionIdx, ViewPort)
            ' Extract invert outline from rectangular outline
            Dim invert(1) As PointF

            invert(0) = rectangular(1)
            invert(1) = rectangular(2)

            InvertOutline = invert
        Catch ex As Exception
            InvertOutline = Nothing
        End Try
    End Function

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateControlValues() - called to update contained Controls' values
    '*********************************************************************************************************
    Protected Overrides Sub UpdateControlValues()
        MyBase.UpdateControlValues()

        ' Bottom Width control
        Me.BottomWidthSingle.Label = Me.BwKey.BaseText
        Me.BottomWidthSingle.SiDefaultValue = mDefaultSection.BottomWidth
        Me.BottomWidthSingle.SiValue = mSection.BottomWidth
        Me.BottomWidthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        If (OuterIsReadOnly) Then
            Me.BottomWidthSingle.IsReadOnly = True
            Me.BottomWidthSingle.ReadOnlyMsgBox = ControlMatchedToApproachDialog
        Else
            Me.BottomWidthSingle.IsReadOnly = False
            Me.BottomWidthSingle.ReadOnlyMsgBox = Nothing
        End If
        Me.BwKey.ShowValue(Me.BottomWidthSingle.UiValueUnitsText)

        ' Inner Sill Height (D1) control
        Me.SillHeightSingle.Label = Me.BwKey.BaseText
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

        ' Slope (Z1) control
        Me.Z1Single.Label = Me.Z1Key.BaseText
        Me.Z1Single.SiDefaultValue = mDefaultSection.Z1
        Me.Z1Single.SiValue = mSection.Z1
        Me.Z1Key.ShowValue(Me.Z1Single.UiValueText)

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

        ' Position 'Extras' relative to V-shaped's outlines
        Dim inner As PointF() = Me.InnerOutline(mSectionIdx, mViewPort)
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)

        Dim x1, x2, y1, y2 As Single
        Dim xMin As Single = inner(2).X
        Dim yMax As Single = inner(2).Y
        Dim Ls As Single = (outer(3).X - outer(0).X) * Z1Single.UiValue / Me.BottomWidthSingle.UiValue

        ' Slope graphic
        If (inner.Length = 6) Then
            x1 = inner(4).X - Ls
            x1 = Math.Max(x1, xMin)
            y1 = inner(4).Y
            x2 = inner(4).X
            y2 = y1
        Else
            x1 = inner(3).X - Ls
            x1 = Math.Max(x1, xMin)
            y1 = inner(3).Y
            x2 = inner(3).X
            y2 = y1
        End If
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

        If (0 < Me.Z1Single.UiValue) Then
            y2 = y1 + ((x2 - x1) / Me.Z1Single.UiValue)
            y2 = Math.Min(y2, yMax)
        End If
        x2 = x1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

        x1 = x1 - 12
        y1 = (y1 + y2) / 2 - 8
        eGraphics.DrawString("1", mBold, mBlackBrush, x1, y1)

        ' D1 graphic
        x1 = inner(2).X
        y1 = inner(2).Y
        x2 = outer(2).X + Me.SillHeightSingle.Width / 2.0!
        y2 = y1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

        y1 = outer(2).Y
        y2 = y1
        eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

    End Sub

    '*********************************************************************************************************
    ' Sub AnnotateDrawing() - annotate cross section's printable drawing
    '*********************************************************************************************************
    Public Overrides Sub AnnotateDrawing(ByVal eGraphics As Graphics)
        DrawExtras(eGraphics)

        ' Position 'Annotations' relative to rectangle's outline
        Dim inner As PointF() = Me.InnerOutline(mSectionIdx, mViewPort)
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)
        Dim sill As PointF() = Me.SillOutline(mSectionIdx, mViewPort)

        Dim x1, y1, dx As Single

        ' Bottom Width
        Dim BW As Single = mSection.BottomWidth
        Dim BWtext As String = UnitsDialog.UiValueUnitsText(BW, "m")
        Dim BWsize As SizeF = eGraphics.MeasureString(BWtext, Me.Font)

        dx = (outer(2).X - outer(1).X - BWsize.Width) / 2

        x1 = outer(1).X + dx
        y1 = outer(1).Y + 2
        eGraphics.DrawString(BWtext, Me.Font, mBlackBrush, x1, y1)

        ' Sill Height
        Dim D1 As Single = mSection.D1
        Dim D1Text As String = "D1: " & UnitsDialog.UiValueUnitsText(D1, "m")
        Dim D1size As RectangleF = MeasureString(eGraphics, D1Text, Me.Font)
        x1 = mOuter.Last.X - D1size.Width - 4
        y1 = sill(1).Y + 4
        eGraphics.DrawString(D1Text, Me.Font, mBlackBrush, x1, y1)

        ' V-Shape Slope
        Dim Z1 As Single = mSection.Z1
        Dim Z1Text As String = Format(Z1, "0.0##")
        Dim Z1size As RectangleF = MeasureString(eGraphics, Z1Text, Me.Font)
        dx = (outer(2).X - outer(1).X) / 2
        x1 = outer(1).X + dx - 4
        If (inner.Length = 6) Then
            y1 = inner(4).Y
        Else
            y1 = inner(3).Y
        End If
        y1 -= Z1size.Height
        eGraphics.DrawString(Z1Text, Me.Font, mBlackBrush, x1, y1)

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - called to position contained Controls
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()

        ' Position Controls relative to rectangular's outline
        Dim inner As PointF() = Me.InnerOutline(mSectionIdx, mViewPort)
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)

        Dim x1Min As Single = inner(2).X
        Dim Ls As Single = (outer(3).X - outer(0).X) * Z1Single.UiValue / Me.BottomWidthSingle.UiValue

        ' Thumbnail graphic
        Dim x As Single = Me.Thumbnail.Location.X
        Dim y As Single = Me.Height - Me.Thumbnail.Height - 5
        Dim loc As Point = New Point(CInt(x), CInt(y))
        PositionControl(Me.Thumbnail, loc)

        ' Bottom Width control
        x = (outer(1).X + (outer(2).X - Me.BottomWidthSingle.Width)) / 2
        x = Math.Max(x, outer(1).X)
        y = outer(1).Y + Me.Margin.Vertical
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.BottomWidthSingle, loc)

        ' Slope (Z1) control
        If (inner.Length = 6) Then
            x = inner(4).X - Ls
            x = Math.Max(x, x1Min)
            y = inner(4).Y - Me.Z1Single.Height
        Else
            x = inner(3).X - Ls
            x = Math.Max(x, x1Min)
            y = inner(3).Y - Me.Z1Single.Height
        End If
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.Z1Single, loc)

        ' D1 control
        x += Me.SillHeightSingle.Width / 2.0!
        y = inner(2).Y + Me.Margin.Vertical
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.SillHeightSingle, loc)

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '*********************************************************************************************************
    Protected Sub BottomWidthSingle_ValueChanged() Handles BottomWidthSingle.ValueChanged
        Dim BW As Single = Me.BottomWidthSingle.SiValue
        SetControlBW(BW)
    End Sub

    Protected Sub Z1Single_ValueChanged() Handles Z1Single.ValueChanged
        Dim Z1 = Me.Z1Single.SiValue
        SetZ1(Z1)
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
