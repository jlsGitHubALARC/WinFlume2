
'*************************************************************************************************************
' Class SillInRectangleControl  - UserControl for drawing & editing a Sill-In-Rectangle cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'
' Note - this cross-section is used only in the Control Section of the flume and only when matched to the
'        Approach Channel's Rectanglular cross-section
'*************************************************************************************************************
Imports Flume.Globals
Imports WinFlume.WinFlumeSectionType

Public Class SillInRectangleControl

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
                    .D1 = mFlume.SillHeight
                    .Z1 = 0
                    .BottomWidth = mFlume.Section(cApproach).TopWidth(.D1, False)
                    .OuterBottomWidth = mFlume.Section(cApproach).BottomWidth
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

            Dim CD As Single = mCanalDepth              ' Canal depth
            Dim BH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim D1 As Single = mSection.D1              ' Inner sill height
            Dim SH As Single = CD - BH + D1             ' Section height

            Dim CW As Single = mCanalWidth              ' Top Width of canal
            Dim BW As Single = mSection.BottomWidth     ' Bottom width of section
            Dim TW As Single = mChannelWidth            ' Top Width of section

            ' Define the rectangle cross section shape
            Dim rectangle(3) As PointF
            Dim x1, x2, y1, y2 As Single

            x1 = mViewPort.X + mHorzOffset + (CW - TW) * mHorzScale / 2  ' Left edge
            y1 = mViewPort.Y + mVertOffset
            x2 = x1
            y2 = y1 + SH * mVertScale
            rectangle(0) = New PointF(x1, y1)
            rectangle(1) = New PointF(x2, y2)

            x1 = x2                                     ' Invert / Sill
            y1 = y2
            x2 = x1 + BW * mHorzScale
            y2 = rectangle(1).Y
            rectangle(2) = New PointF(x2, y2)

            x1 = x2                                     ' Right edge
            y1 = y2
            x2 = x1 + (TW - BW) * mHorzScale / 2
            y2 = rectangle(0).Y
            rectangle(3) = New PointF(x2, y2)

            OuterOutline = rectangle
        Catch ex As Exception
            OuterOutline = Nothing
        End Try
    End Function

    Public Overrides Function InnerOutline(ByVal SectionIdx As Integer,
                                           ByVal ViewPort As RectangleF) As PointF()
        ' Start with outer outline
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

            ' Calculate deltas to Sill end points
            Dim dx As Single = (outer(1).X - outer(0).X) * SD / CD
            Dim dy As Single = (outer(1).Y - outer(0).Y) * SD / CD

            ' Build inner outline from outer outline
            Dim inner(3) As PointF
            inner(0) = outer(0)
            inner(1) = New PointF(outer(0).X + dx, outer(0).Y + dy)
            inner(2) = New PointF(outer(3).X - dx, outer(3).Y + dy)
            inner(3) = outer(3)

            InnerOutline = inner
        Catch ex As Exception
            InnerOutline = outer
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete simple rectangle outline
            Dim rectangle As PointF() = Me.OuterOutline(SectionIdx, ViewPort)
            ' Extract invert outline from simple rectangle outline
            Dim invert(1) As PointF

            invert(0) = rectangle(1)
            invert(1) = rectangle(2)

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

        ' Inner Sill Height (D1) control
        Dim D1 As Single = mSection.D1
        Dim errVal As Boolean
        Me.SillHeightSingle.Label = D1Key.BaseText & ", D1"
        Me.SillHeightSingle.SiDefaultValue = mDefaultSection.D1
        Me.SillHeightSingle.SiValue = D1
        Me.SillHeightSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.D1Key.ShowValue(Me.SillHeightSingle.UiValueUnitsText)

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
        Dim SWval As Single = mSection.TopWidth(0, errVal)
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
    ' Sub DrawExtras()      - draw extra graphics for control graphics
    ' Sub AnnotateDrawing() - add annotations to printable cross section drawing
    '
    ' Input(s):     eGraphics   - Graphics object provided by Windows via OnPaint()
    '*********************************************************************************************************
    Public Overrides Sub DrawExtras(ByVal eGraphics As Graphics)

        ' Position 'Extras' relative to rectangle's outline
        Dim sill As PointF() = Me.SillOutline(mSectionIdx, mViewPort)

        Dim x1, x2, y1, y2 As Single

        ' Sill Height graphic
        x1 = sill(1).X
        y1 = sill(1).Y
        x2 = x1 + Me.SillHeightSingle.Width
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

        ' Position 'Annotations' relative to rectangle's outline
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)
        Dim inner As PointF() = Me.InnerOutline(mSectionIdx, mViewPort)

        Dim x1, y1, dx As Single

        ' Bottom Width
        Dim BW As Single = mSection.BottomWidth
        Dim BWtext As String = UnitsDialog.UiValueUnitsText(BW, "m")
        Dim BWsize As SizeF = eGraphics.MeasureString(BWtext, Me.Font)

        dx = (outer(2).X - outer(1).X - BWsize.Width) / 2

        x1 = outer(1).X + dx
        y1 = outer(1).Y + 1
        eGraphics.DrawString(BWtext, Me.Font, mBlackBrush, x1, y1)

        ' Sill Height
        Dim D1 As Single = mSection.D1
        Dim D1text As String = UnitsDialog.UiValueUnitsText(D1, "m")
        Dim D1Size As SizeF = eGraphics.MeasureString(D1text, Me.Font)

        x1 = inner(2).X - D1Size.Width - 4
        y1 = (inner(2).Y + outer(2).Y - D1Size.Height) / 2
        eGraphics.DrawString(D1text, Me.Font, mBlackBrush, x1, y1)

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

        ' SillHeight control/label
        x = CSng(mInner(2).X + Me.SillHeightSingle.Width / 2)
        y = CSng(mInner(2).Y + mOuter(2).Y - Me.SillHeightSingle.Height) / 2
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

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
