
'*************************************************************************************************************
' Class ParabolaControl         - UserControl for drawing & editing a Parabola cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'   Note - Inherits statement is found in the file: SimpleTrapezoidControl.Designer.vb
'*************************************************************************************************************
Imports Flume.Globals

Public Class ParabolaControl

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
            Dim BH As Single = mBottomHeight            ' Height from canal bottom to section bottom
            Dim DF As Single = mDiamFocalDist           ' Diameter / Focal Distance(2f)
            Dim SH As Single = CD - BH                  ' Section height
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
                x = CSng(Math.Sqrt(2 * DF * y))
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

            OuterOutline = parabola
        Catch ex As Exception
            OuterOutline = Nothing
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete parabola outline
            Dim parabola As PointF() = Me.OuterOutline(SectionIdx, ViewPort)
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
        MyBase.UpdateControlValues()

        ' Focal Distance
        Me.FocalDistanceSingle.Label = Me.FdKey.BaseText & ", 2f"
        Me.FocalDistanceSingle.SiDefaultValue = mDefaultSection.DiameterFocalD
        Me.FocalDistanceSingle.SiValue = mSection.DiameterFocalD
        Me.FocalDistanceSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
        Me.FocalDistanceSingle.IsReadOnly = False
        Me.FocalDistanceSingle.ReadOnlyMsgBox = Nothing
        Me.FdKey.ShowValue(Me.FocalDistanceSingle.UiValueUnitsText, "2f")

        ' Top Width
        Dim TWtxt As String = UnitsDialog.UiValueUnitsText(mChannelWidth, "m")
        Me.TwKey.ShowValue(TWtxt)

        ' Set Read-Only state, when appropriate
        Select Case (mSectionIdx)
            Case cControl
                If (OuterIsReadOnly) Then
                    Me.FocalDistanceSingle.IsReadOnly = True
                    Me.FocalDistanceSingle.ReadOnlyMsgBox = ControlMatchedToApproachDialog
                End If
            Case cTailwater
                If (WinFlumeForm.TailwaterMatchedToApproach) Then
                    Me.FocalDistanceSingle.IsReadOnly = True
                    Me.FocalDistanceSingle.ReadOnlyMsgBox = TailwaterMatchedToApproachDialog
                End If
        End Select

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

        ' Focal Distance graphic
        x = mOuter(Half).X
        y = SH - (DF / 2)
        y *= mVertScale
        y += mViewPort.Y + mVertOffset

        eGraphics.DrawLine(mBlackDashedPen1, x - 5, y, x + 5, y)
        eGraphics.DrawLine(mBlackDashedPen1, x, y - 5, x, y + 5)

    End Sub

    '*********************************************************************************************************
    ' Sub AnnotateDrawing() - annotate cross section's printable drawing
    '*********************************************************************************************************
    Public Overrides Sub AnnotateDrawing(ByVal eGraphics As Graphics)
        ' Include 'Extras'
        DrawExtras(eGraphics)

        ' Position 'Annotations' relative to parabola's outline
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)
        Dim midPt As Integer = CInt(outer.Length / 2)
        Dim midPtf As PointF = outer(midPt)

        Dim x1, y1 As Single

        ' Diameter / Focal Distance
        Dim DF As Single = mSection.DiameterFocalD
        Dim DFtext As String = My.Resources.FocalDistance & ", 2f: " & UnitsDialog.UiValueUnitsText(DF, "m")
        Dim DFsize As RectangleF = MeasureString(eGraphics, DFtext, Me.Font)

        x1 = midPtf.X - DFsize.Right / 2
        y1 = outer.First.Y - DFsize.Height
        eGraphics.DrawString(DFtext, Me.Font, mBlackBrush, x1, y1)

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls relative to outlines
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()

        ' Thumbnail graphic
        Dim x As Single = Me.Thumbnail.Location.X
        Dim y As Single = Me.Height - Me.Thumbnail.Height - 5
        Dim loc As Point = New Point(CInt(x), CInt(y))
        PositionControl(Me.Thumbnail, loc)

        ' FocalDistance control/label
        x = CSng(mOuter(Half).X - Me.FocalDistanceSingle.Width / 2)
        y = mOuter(Half).Y + Me.Margin.Vertical
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.FocalDistanceSingle, loc, Me.FdLabel)

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
