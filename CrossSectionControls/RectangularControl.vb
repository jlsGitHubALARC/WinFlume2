
'*************************************************************************************************************
' Class RectangularControl      - UserControl for drawing & editing a Rectangular cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'   Note - Inherits statement is found in the file: SimpleTrapezoidControl.Designer.vb
'*************************************************************************************************************
Imports Flume.Globals

Public Class RectangularControl

#Region " Constructor(s) "

    '*********************************************************************************************************
    ' Sub New() - Constructor
    '
    ' Input(s):     SectionIdx  - index selection for Flume Section (cApproach, cControl, cTailwater)
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
            Dim CW As Single = mCanalWidth              ' Top Width of canal
            Dim BH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim BW As Single = mSection.BottomWidth     ' Width of rectangle bottom
            Dim SW As Single = mChannelWidth            ' Top Width of this Section
            Dim SH As Single = CD - BH                  ' Section height

            ' Define the rectangular cross section shape
            Dim rectangular(3) As PointF
            Dim x1, x2, y1, y2 As Single

            x1 = mViewPort.X + mHorzOffset + (CW - SW) * mHorzScale / 2  ' Left edge
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

            Dim dy As Single = RH * mVertScale

            tRamp(0).X = invert(0).X
            tRamp(0).Y = invert(0).Y - dy
            tRamp(1).X = invert(1).X
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
        MyBase.UpdateControlValues()

        ' Bottom Width control
        Me.BottomWidthSingle.Label = Me.BwKey.BaseText
        Me.BottomWidthSingle.SiDefaultValue = mDefaultSection.BottomWidth
        Me.BottomWidthSingle.SiValue = mSection.BottomWidth
        Me.BottomWidthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.BottomWidthSingle.IsReadOnly = False
        Me.BottomWidthSingle.ReadOnlyMsgBox = Nothing
        Me.BwKey.ShowValue(Me.BottomWidthSingle.UiValueUnitsText)

        ' Top Width
        Dim TWtxt As String = UnitsDialog.UiValueUnitsText(mChannelWidth, "m")
        Me.TwKey.ShowValue(TWtxt)

        ' Set Read-Only state, when appropriate
        Select Case (mSectionIdx)
            Case cControl
                If (OuterIsReadOnly) Then
                    Me.BottomWidthSingle.IsReadOnly = True
                    Me.BottomWidthSingle.ReadOnlyMsgBox = ControlMatchedToApproachDialog
                End If
            Case cTailwater
                If (WinFlumeForm.TailwaterMatchedToApproach) Then
                    Me.BottomWidthSingle.IsReadOnly = True
                    Me.BottomWidthSingle.ReadOnlyMsgBox = TailwaterMatchedToApproachDialog
                End If
        End Select
    End Sub

    '*********************************************************************************************************
    ' Sub DrawCrossSection() - draw the cross section graphics
    '
    ' Input(s):     eGraphics   - Graphics handle provided by Windows via OnPaint()
    '*********************************************************************************************************
    Protected Overrides Sub DrawCrossSection(ByVal eGraphics As System.Drawing.Graphics)
        MyBase.DrawCrossSection(eGraphics)      ' Baseclass defines ViewPort
        Dim dPen As Drawing.Pen = BlackPen2()   ' Pen for cross section control graphics

        DrawCrossSection(mSectionIdx, mViewPort, eGraphics, dPen)
    End Sub

    '*********************************************************************************************************
    ' Sub AnnotateDrawing() - annotate cross section's printable drawing
    '*********************************************************************************************************
    Public Overrides Sub AnnotateDrawing(ByVal eGraphics As Graphics)

        ' Position 'Annotations' relative to rectangle's outline
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)

        Dim x1, y1, dx As Single

        ' Bottom Width
        Dim BW As Single = mSection.BottomWidth
        Dim BWtext As String = UnitsDialog.UiValueUnitsText(BW, "m")
        Dim BWsize As SizeF = eGraphics.MeasureString(BWtext, Me.Font)

        dx = (outer(2).X - outer(1).X - BWsize.Width) / 2

        x1 = outer(1).X + dx
        y1 = outer(1).Y + 1
        eGraphics.DrawString(BWtext, Me.Font, mBlackBrush, x1, y1)

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - called to position contained Controls
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()

        ' Position Controls relative to rectangular's outline
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)

        ' Thumbnail graphic
        Dim x As Single = Me.Thumbnail.Location.X
        Dim y As Single = Me.Height - Me.Thumbnail.Height - 5
        Dim loc As Point = New Point(CInt(x), CInt(y))
        PositionControl(Me.Thumbnail, loc)

        ' Bottom Width control
        x = (outer(1).X + (outer(2).X - Me.BottomWidthSingle.Width)) / 2
        x = Math.Max(x, outer(1).X)
        y = outer(1).Y + 2
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.BottomWidthSingle, loc)

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
        Dim BW = Me.BottomWidthSingle.SiValue
        SetBW(BW)
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
