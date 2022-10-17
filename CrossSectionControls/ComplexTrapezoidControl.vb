
'*************************************************************************************************************
' Class ComplexTrapezoidControl - UserControl for drawing & editing a Complex Trapezoid cross section
'
' Inherits CrossSectionControl  - see baseclass for common data/code & overridable methods
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.WinFlumeSectionType

Public Class ComplexTrapezoidControl

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
    ' Functions:    OuterOutline()      - left edge, invert, right edge   - outer trapezoid
    '               InnerOutline()      - left edge, sill, right edge     - inner trapezoid
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

            ' Section specific dimensions
            Dim CD As Single = mFlume.CanalDepth            ' Canal depth; w/buried components; wo/bed drop
            Dim CW As Single = mCanalWidth                  ' Top Width of canal
            Dim BH As Single = mBottomHeight                ' Section height from canal bottom

            ' Outer trapezoid dimensions
            Dim BW As Single = mSection.OuterBottomWidth    ' Outer trapezoid bottom width
            Dim Z3 As Single = mSection.Z3                  '   "       "     side slope (H/V)
            Dim TH As Single = mChannelDepth + mSection.D1  '   "       "     height
            If (SectionIdx = cControl) Then
                TH -= mSillHeight
            End If

            Dim TW As Single = BW + 2 * TH * Z3             ' Outer trapezoid top width

            ' Define the outer trapezoid cross section shape
            Dim outerTrapezoid(3) As PointF
            Dim x1, x2, y1, y2 As Single

            x1 = mViewPort.X + mHorzOffset + (CW - TW) * mHorzScale / 2  ' Left edge
            y1 = mViewPort.Y + mVertOffset
            x2 = x1 + (TW - BW) * mHorzScale / 2
            y2 = y1 + TH * mVertScale
            outerTrapezoid(0) = New PointF(x1, y1)
            outerTrapezoid(1) = New PointF(x2, y2)

            x1 = x2                                     ' Invert
            y1 = y2
            x2 = x1 + BW * mHorzScale
            y2 = y1
            outerTrapezoid(2) = New PointF(x2, y2)

            x1 = x2                                     ' Right edge
            y1 = y2
            x2 = x1 + (TW - BW) * mHorzScale / 2
            y2 = y1 - TH * mVertScale
            outerTrapezoid(3) = New PointF(x2, y2)

            OuterOutline = outerTrapezoid
        Catch ex As Exception
            OuterOutline = Nothing
        End Try
    End Function

    Public Overrides Function InnerOutline(ByVal SectionIdx As Integer,
                                           ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Baseclass initializes cross section data
            MyBase.InnerOutline(SectionIdx, ViewPort)

            ' Section specific dimensions
            Dim CD As Single = mFlume.CanalDepth            ' Canal depth; w/buried components
            Dim CW As Single = mCanalWidth                  ' Top Width of canal
            Dim BD As Single = mBedDrop                     ' Tailwater bed drop
            Dim BH As Single = mBottomHeight                ' Section height from canal bottom

            ' Inner trapezoid dimensions
            Dim BW As Single = mSection.BottomWidth         ' Inner trapezoid bottom width
            Dim TH As Single = mChannelDepth                '   "       "     height
            If (SectionIdx = cControl) Then
                TH -= mSillHeight
            End If

            Dim Z1 As Single = mSection.Z1                  ' Lower channel side slope (H/V)
            Dim D1 As Single = mSection.D1                  '   "      "    bottom height
            Dim D2 As Single = mSection.D2                  '   "      "    channel depth
            If (D2 > CD - D1) Then
                D2 = CD - D1                                ' Limit to Canal depth
            End If
            Dim W2 As Single = D2 * Z1                      '   "      "    width (one side)
            Dim Z2 As Single = mSection.Z2                  ' Middle channel side slope (H/V)
            Dim D3 As Single = TH - D2                      '    "      "    channel depth
            If (D3 < 0) Then
                D3 = 0
            End If
            Dim W3 As Single = D3 * Z2                      '    "      "    width (one side)
            Dim TW As Single = BW + 2 * (W2 + W3)           ' Inner trapezoid top width

            Dim Z3 As Single = mSection.Z3                  ' Outer trapezoid side slope (H/V)

            ' Define the inner trapezoid cross section shape
            Dim innerTrapezoid(5) As PointF
            Dim x1, x2, y1, y2 As Single

            x1 = mViewPort.X + mHorzOffset + (CW - TW) * mHorzScale / 2  ' Left edge (middle channel)
            y1 = mViewPort.Y + mVertOffset
            x2 = x1 + W3 * mHorzScale
            y2 = y1 + D3 * mVertScale
            innerTrapezoid(0) = New PointF(x1, y1)
            innerTrapezoid(1) = New PointF(x2, y2)

            x1 = x2                                     ' Left edge (lower channel)
            y1 = y2
            x2 = x1 + W2 * mHorzScale
            y2 = y1 + D2 * mVertScale
            innerTrapezoid(2) = New PointF(x2, y2)

            x1 = x2                                     ' Invert / Sill
            y1 = y2
            x2 = x1 + BW * mHorzScale
            y2 = y1
            innerTrapezoid(3) = New PointF(x2, y2)

            x1 = x2                                     ' Right edge (lower channel)
            y1 = y2
            x2 = x1 + W2 * mHorzScale
            y2 = y1 - D2 * mVertScale
            innerTrapezoid(4) = New PointF(x2, y2)

            x1 = x2                                     ' Right edge (middle channel)
            y1 = y2
            x2 = x1 + W3 * mHorzScale
            y2 = y1 - D3 * mVertScale
            innerTrapezoid(5) = New PointF(x2, y2)

            ' If necessary, fit inner trapezoid within the outer trapezoid
            Dim outerTrapezoid As PointF() = Me.OuterOutline(SectionIdx, ViewPort)
            Dim oPt0 As PointF = outerTrapezoid(0)
            Dim oPt1 As PointF = outerTrapezoid(1)
            Dim oPt2 As PointF = outerTrapezoid(2)
            Dim oPt3 As PointF = outerTrapezoid(3)

            Dim IY As Single = innerTrapezoid(2).Y              ' Clip inner from the bottom up
            Dim OPT As PointF = PointAtY(oPt0, oPt1, IY)

            If (innerTrapezoid(2).X <= OPT.X) Then ' inner bottom width extends beyond outer trapezoid
                ReDim innerTrapezoid(3)
                innerTrapezoid(0) = oPt0
                innerTrapezoid(1) = OPT
                OPT = PointAtY(oPt3, oPt2, IY)
                innerTrapezoid(2) = OPT
                innerTrapezoid(3) = oPt3
            Else
                IY = innerTrapezoid(1).Y
                OPT = PointAtY(oPt0, oPt1, IY)

                If (innerTrapezoid(1).X <= OPT.X) Then ' inner middle width extends beyond outer
                    innerTrapezoid(0) = oPt0

                    ' Get upper-left points for both trapezoids' left edges
                    Dim ix1 As Single = innerTrapezoid(1).X
                    Dim iy1 As Single = innerTrapezoid(1).Y

                    Dim ox0 As Single = outerTrapezoid(0).X
                    Dim oy0 As Single = outerTrapezoid(0).Y

                    ' Find the intercept of the two edges
                    Dim y As Single = (Z1 * iy1 - Z3 * oy0 + ox0 - ix1) / (Z1 - Z3)
                    Dim x As Single = Z1 * (y - iy1) + ix1

                    ' Clip end points of the inner trapezoid
                    Dim dy As Single = y - iy1
                    Dim dx As Single = x - ix1

                    innerTrapezoid(1).X += dx
                    innerTrapezoid(1).Y += dy
                    innerTrapezoid(4).X -= dx
                    innerTrapezoid(4).Y += dy

                    innerTrapezoid(5) = oPt3
                Else
                    IY = innerTrapezoid(0).Y
                    OPT = PointAtY(oPt0, oPt1, IY)

                    If (innerTrapezoid(0).X < OPT.X) Then ' inner top width extends beyond outer

                        ' Get upper-left points for both trapezoids left edges
                        Dim ix0 As Single = innerTrapezoid(0).X
                        Dim iy0 As Single = innerTrapezoid(0).Y

                        Dim ox0 As Single = outerTrapezoid(0).X
                        Dim oy0 As Single = outerTrapezoid(0).Y

                        ' Find the intercept of the two edges
                        Dim y As Single = (Z2 * iy0 - Z3 * oy0 + ox0 - ix0) / (Z2 - Z3)
                        Dim x As Single = Z2 * (y - iy0) + ix0

                        ' Clip end points of the inner trapezoid
                        Dim dy As Single = y - iy0
                        Dim dx As Single = x - ix0

                        innerTrapezoid(0).X += dx
                        innerTrapezoid(0).Y += dy
                        innerTrapezoid(5).X -= dx
                        innerTrapezoid(5).Y += dy

                        ReDim Preserve innerTrapezoid(7)
                        innerTrapezoid(7) = oPt3                            ' Extend upper-right
                        For idx = 6 To 1 Step -1
                            innerTrapezoid(idx) = innerTrapezoid(idx - 1)   ' Shift inner points
                        Next
                        innerTrapezoid(0) = oPt0                            ' Extendd upper-left
                    End If
                End If
            End If

            InnerOutline = innerTrapezoid
        Catch ex As Exception
            InnerOutline = Nothing
        End Try
    End Function

    Public Overrides Function InvertOutline(ByVal SectionIdx As Integer,
                                            ByVal ViewPort As RectangleF) As PointF()
        Try
            ' Get complete inner outline
            Dim inner As PointF() = Me.InnerOutline(SectionIdx, ViewPort)
            ' Extract invert outline from inner outline
            Dim invert(1) As PointF

            If (inner.Length = 4) Then
                invert(0) = inner(1)
                invert(1) = inner(2)
            ElseIf (inner.Length = 6) Then
                invert(0) = inner(2)
                invert(1) = inner(3)
            Else ' Length = 8
                invert(0) = inner(3)
                invert(1) = inner(4)
            End If

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

    Private Function PointAtX(ByVal Pt1 As PointF, Pt2 As PointF, X As Single) As PointF
        Dim slope As Single = (Pt2.Y - Pt1.Y) / (Pt2.X - Pt1.X)
        Dim Y As Single = Pt1.Y + slope * (X - Pt1.X)
        PointAtX = New PointF(X, Y)
    End Function

    Private Function PointAtY(ByVal Pt1 As PointF, Pt2 As PointF, Y As Single) As PointF
        Dim slope As Single = (Pt2.Y - Pt1.Y) / (Pt2.X - Pt1.X)
        Dim X As Single = Pt1.X + (Y - Pt1.Y) / slope
        PointAtY = New PointF(X, Y)
    End Function

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateControlValues() - update contained Controls' values
    '*********************************************************************************************************
    Protected Overrides Sub UpdateControlValues()
        MyBase.UpdateControlValues()

        UpdateInnerTrapezoidControlValues()
        UpdateOuterTrapezoidControlValues()
    End Sub

    Private Sub UpdateInnerTrapezoidControlValues()

        If (Me.EditInnerCheckBox.Checked) Then ' Show inner trapezoid

            Me.BinSingle.Visible = True
            Me.BinLabel.Visible = True
            Me.BinKey.Visible = True
            Me.Z1Single.Visible = True
            Me.Z1Label.Visible = True
            Me.Z1Key.Visible = True
            Me.Z2Single.Visible = True
            Me.Z2Label.Visible = True
            Me.Z2Key.Visible = True
            Me.D2Single.Visible = True
            Me.D2Label.Visible = True
            Me.D2Key.Visible = True

            Me.BinSingle.Label = BinKey.BaseText
            Me.BinSingle.SiDefaultValue = mDefaultSection.BottomWidth
            Me.BinSingle.SiValue = mSection.BottomWidth
            Me.BinSingle.SiUnits = WinFlumeForm.SiLengthUnitsText
            Me.BinKey.ShowValue(Me.BinSingle.UiValueUnitsText)

            Me.Z1Single.Label = Me.Z1Key.BaseText
            Me.Z1Single.SiDefaultValue = mDefaultSection.Z1
            Me.Z1Single.SiValue = mSection.Z1
            Me.Z1Key.ShowValue(Me.Z1Single.UiValueText)

            Me.Z2Single.Label = Z2Key.BaseText
            Me.Z2Single.SiDefaultValue = mDefaultSection.Z2
            Me.Z2Single.SiValue = mSection.Z2
            Me.Z2Key.ShowValue(Me.Z2Single.UiValueText)

            Me.D2Single.Label = D2Key.BaseText
            Me.D2Single.SiDefaultValue = mDefaultSection.D2
            Me.D2Single.SiValue = mSection.D2
            Me.D2Single.SiUnits = WinFlumeForm.SiLengthUnitsText
            Me.D2Key.ShowValue(Me.D2Single.UiValueUnitsText)

            ' Top Width
            Dim TWtxt As String = UnitsDialog.UiValueUnitsText(mChannelWidth, "m")
            Me.TwKey.ShowValue(TWtxt)

            ' Set Read-Only state, when appropriate
            Me.BinSingle.IsReadOnly = False
            Me.BinSingle.ReadOnlyMsgBox = Nothing
            Me.Z1Single.IsReadOnly = False
            Me.Z1Single.ReadOnlyMsgBox = Nothing
            Me.Z2Single.IsReadOnly = False
            Me.Z2Single.ReadOnlyMsgBox = Nothing
            Me.D2Single.IsReadOnly = False
            Me.D2Single.ReadOnlyMsgBox = Nothing

            Select Case (mSectionIdx)
                Case cApproach

                Case cControl

                Case cTailwater

                    If (WinFlumeForm.TailwaterMatchedToApproach) Then
                        Me.BinSingle.IsReadOnly = True
                        Me.BinSingle.ReadOnlyMsgBox = TailwaterMatchedToApproachDialog
                        Me.Z1Single.IsReadOnly = True
                        Me.Z1Single.ReadOnlyMsgBox = TailwaterMatchedToApproachDialog
                        Me.Z2Single.IsReadOnly = True
                        Me.Z2Single.ReadOnlyMsgBox = TailwaterMatchedToApproachDialog
                        Me.D2Single.IsReadOnly = True
                        Me.D2Single.ReadOnlyMsgBox = TailwaterMatchedToApproachDialog
                    End If
            End Select

        Else ' Hide inner trapezoid

            Me.BinSingle.Visible = False
            Me.BinLabel.Visible = False
            Me.BinKey.Visible = False
            Me.Z1Single.Visible = False
            Me.Z1Label.Visible = False
            Me.Z1Key.Visible = False
            Me.Z2Single.Visible = False
            Me.Z2Label.Visible = False
            Me.Z2Key.Visible = False
            Me.D2Single.Visible = False
            Me.D2Label.Visible = False
            Me.D2Key.Visible = False
        End If

    End Sub

    Private Sub UpdateOuterTrapezoidControlValues()

        If (Me.EditOuterCheckBox.Checked) Then ' Show outer trapezoid

            Me.BoutSingle.Visible = True
            Me.BoutLabel.Visible = True
            Me.BoutKey.Visible = True
            Me.Z3Single.Visible = True
            Me.Z3Label.Visible = True
            Me.Z3Key.Visible = True

            Me.BoutSingle.Label = BoutKey.BaseText
            Me.BoutSingle.SiDefaultValue = mDefaultSection.OuterBottomWidth
            Me.BoutSingle.SiValue = mSection.OuterBottomWidth
            Me.BoutSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

            Me.BoutKey.ShowValue(Me.BoutSingle.UiValueUnitsText)

            Me.Z3Single.Label = Z3Key.BaseText
            Me.Z3Single.SiDefaultValue = mDefaultSection.Z3
            Me.Z3Single.SiValue = mSection.Z3

            Me.Z3Key.ShowValue(Me.Z3Single.UiValueText)

            Me.D1Single.Label = D1Key.BaseText
            Me.D1Single.SiDefaultValue = mDefaultSection.D1
            Me.D1Single.SiValue = mSection.D1
            Me.D1Single.SiUnits = WinFlumeForm.SiLengthUnitsText

            Me.D1Key.ShowValue(Me.D1Single.UiValueUnitsText)

            ' Set Visible / Read-Only state, when appropriate
            Me.BoutSingle.IsReadOnly = False
            Me.BoutSingle.ReadOnlyMsgBox = Nothing
            Me.Z3Single.IsReadOnly = False
            Me.Z3Single.ReadOnlyMsgBox = Nothing
            Me.D1Single.IsReadOnly = False
            Me.D1Single.ReadOnlyMsgBox = Nothing

            Select Case (mSectionIdx)
                Case cApproach
                    Me.D1Single.Visible = D1visible
                    Me.D1Label.Visible = D1visible
                    Me.D1Key.Visible = True

                Case cControl
                    Me.D1Single.Visible = True
                    Me.D1Label.Visible = True
                    Me.D1Key.Visible = True

                    If (mSection.GetType Is GetType(WinFlumeSectionType)) Then
                        Dim WinFlumeSection As WinFlumeSectionType = DirectCast(mSection, WinFlumeSectionType)
                        Dim MatchConstraints As Integer = WinFlumeSection.MatchConstraints

                        If (BitSet(MatchConstraints, MatchConstraint.InnerSillHeightMatchesProfileSillHeight)) Then
                            Me.D1Single.IsReadOnly = True
                            Me.D1Single.ReadOnlyMsgBox = SillHeightMatchesProfile
                        End If

                        Me.BoutSingle.IsReadOnly = True
                        Me.BoutSingle.ReadOnlyMsgBox = ControlMatchedToApproachDialog

                        Me.Z3Single.IsReadOnly = True
                        Me.Z3Single.ReadOnlyMsgBox = ControlMatchedToApproachDialog
                    End If

                Case cTailwater
                    Me.D1Single.Visible = D1visible
                    Me.D1Label.Visible = D1visible
                    Me.D1Key.Visible = True

                    If (WinFlumeForm.TailwaterMatchedToApproach) Then
                        Me.BoutSingle.IsReadOnly = True
                        Me.BoutSingle.ReadOnlyMsgBox = TailwaterMatchedToApproachDialog
                        Me.Z3Single.IsReadOnly = True
                        Me.Z3Single.ReadOnlyMsgBox = TailwaterMatchedToApproachDialog
                    End If
            End Select

        Else ' Hide outer trapezoid

            Me.BoutSingle.Visible = False
            Me.BoutLabel.Visible = False
            Me.BoutKey.Visible = False
            Me.Z3Single.Visible = False
            Me.Z3Label.Visible = False
            Me.Z3Key.Visible = False
            Me.D1Single.Visible = False
            Me.D1Label.Visible = False
            Me.D1Key.Visible = False
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

    Public Overrides Sub DrawCrossSection(ByVal SectionIdx As Integer, ByVal ViewPort As RectangleF,
                                          ByVal eGraphics As Drawing.Graphics, ByVal dPen As Drawing.Pen)
        DrawInnerCrossSection(SectionIdx, ViewPort, eGraphics, BlackPen2)
        DrawOuterCrossSection(SectionIdx, ViewPort, eGraphics, BlackPen1)
    End Sub

    Public Overrides Sub DrawOuterCrossSection(ByVal SectionIdx As Integer, ByVal ViewPort As RectangleF,
                                         ByVal eGraphics As Drawing.Graphics, ByVal dPen As Drawing.Pen)
        Try
            mOuter = OuterOutline(SectionIdx, ViewPort)
            If (mOuter IsNot Nothing) Then
                eGraphics.DrawLines(dPen, mOuter)
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Public Overrides Sub DrawInnerCrossSection(ByVal SectionIdx As Integer, ByVal ViewPort As RectangleF,
                                         ByVal eGraphics As Drawing.Graphics, ByVal dPen As Drawing.Pen)
        Try
            mInner = InnerOutline(SectionIdx, ViewPort)
            If (mInner IsNot Nothing) Then
                eGraphics.DrawLines(dPen, mInner)
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    '*********************************************************************************************************
    ' Sub DrawExtras() - draw extra graphics
    '
    ' Input(s):     eGraphics   - Graphics object provided by Windows via OnPaint()
    '*********************************************************************************************************
    Public Overrides Sub DrawExtras(ByVal eGraphics As System.Drawing.Graphics)

        ' Draw 'Extras' relative to outlines & controls
        Dim inner As PointF() = Me.InnerOutline(mSectionIdx, mViewPort)
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)

        Dim x1, x2, y1, y2 As Single

        Dim i As Integer = 0
        If (inner.Length = 6) Then
            i += 1
        ElseIf (inner.Length = 8) Then
            i += 2
        End If

        ' Slope graphic
        x1 = outer(3).X - Me.Z1Single.Width
        x1 = Math.Max(x1, outer(2).X)
        y1 = outer(3).Y
        x2 = outer(3).X
        y2 = y1
        'eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)    ' Horizontal line

        If (0 < Me.Z1Single.SiValue) Then
            y2 = y1 + ((x2 - x1) / Me.Z1Single.SiValue)
        End If
        x2 = x1
        'eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)    ' Vertical line

        ' Slope label along vertical line
        x1 = x1 - 16
        y1 = (y1 + y2) / 2 - 8
        'eGraphics.DrawString("1", mBold, mBlackBrush, x1, y1)

        ' D1 & D2 height indicators
        If (Me.D1Single.Visible) Then ' Draw lines for D1
            x1 = inner(1 + i).X
            y1 = inner(1 + i).Y
            x2 = Me.D1Label.Location.X
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)

            y1 = outer(1).Y
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)
        End If

        If ((Me.D2Single.Visible) And (4 < inner.Length)) Then ' Draw lines for D2
            x1 = inner(i).X
            y1 = inner(i).Y
            x2 = Me.D2Label.Location.X
            y2 = y1

            Dim CD As Single = mFlume.ChannelDepth - mFlume.BedDrop
            Dim D2 As Single = mSection.D2
            If (D2 <= CD) Then
                eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)
            End If

            x1 = inner(1 + i).X
            y1 = inner(1 + i).Y
            y2 = y1
            eGraphics.DrawLine(mBlackDashedPen1, x1, y1, x2, y2)
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub AnnotateDrawing() - annotate cross section's printable drawing
    '*********************************************************************************************************
    Public Overrides Sub AnnotateDrawing(ByVal eGraphics As Graphics)

        Dim x1, y1 As Single

        ' Inner Trapezoid properties
        Dim TRtext As String = My.Resources.InnerTrapezoid
        Dim TRsize As RectangleF = MeasureString(eGraphics, TRtext, Me.Font)
        x1 = mViewPort.Location.X - 8
        y1 = mViewPort.Location.Y + mViewPort.Height - 5 * TRsize.Height + 8
        eGraphics.DrawString(TRtext, Me.Font, mBlackBrush, x1, y1)

        Dim BW As Single = mSection.BottomWidth
        Dim BWtext As String = "Bin: " & UnitsDialog.UiValueUnitsText(BW, "m")
        x1 += 8
        y1 += TRsize.Height
        eGraphics.DrawString(BWtext, Me.Font, mBlackBrush, x1, y1)

        Dim Z1 As Single = mSection.Z1
        Dim Z1text As String = "Z1: " & Format(Z1, "0.0###") & ":1"
        y1 += TRsize.Height
        eGraphics.DrawString(Z1text, Me.Font, mBlackBrush, x1, y1)

        Dim Z2 As Single = mSection.Z2
        Dim Z2text = "Z2: " & Format(Z2, "0.0###") & ":1"
        y1 += TRsize.Height
        eGraphics.DrawString(Z2text, Me.Font, mBlackBrush, x1, y1)

        Dim D2 As Single = mSection.D2
        Dim D2text As String = "D2: " & UnitsDialog.UiValueUnitsText(D2, "m")
        y1 += TRsize.Height
        eGraphics.DrawString(D2text, Me.Font, mBlackBrush, x1, y1)

        ' Outer Trapezoid properties
        TRtext = My.Resources.OuterTrapezoid
        TRsize = MeasureString(eGraphics, TRtext, Me.Font)
        x1 = mViewPort.Location.X + mViewPort.Width - TRsize.Width + 4
        y1 = mViewPort.Location.Y + mViewPort.Height - 5 * TRsize.Height + 8
        eGraphics.DrawString(TRtext, Me.Font, mBlackBrush, x1, y1)

        BW = mSection.OuterBottomWidth
        BWtext = "Bout: " & UnitsDialog.UiValueUnitsText(BW, "m")
        x1 += 8
        y1 += TRsize.Height
        eGraphics.DrawString(BWtext, Me.Font, mBlackBrush, x1, y1)

        Dim Z3 As Single = mSection.Z3
        Dim Z3text As String = "Z3: " & Format(Z3, "0.0###") & ":1"
        y1 += TRsize.Height
        eGraphics.DrawString(Z3text, Me.Font, mBlackBrush, x1, y1)

        If (Me.D1Single.Visible) Then
            Dim D1 As Single = mSection.D1
            Dim D1text As String = "D1: " & UnitsDialog.UiValueUnitsText(D1, "m")
            y1 += TRsize.Height
            eGraphics.DrawString(D1text, Me.Font, mBlackBrush, x1, y1)
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls
    '*********************************************************************************************************
    Protected Overrides Sub PositionControls()

        ' Thumbnail graphic
        Dim x As Single = Me.Thumbnail.Location.X
        Dim y As Single = Me.Height - Me.Thumbnail.Height - 2 * Me.Margin.Vertical

        Dim loc As Point = New Point(CInt(x), CInt(y))
        Me.Thumbnail.Location = loc

        ' View controls
        Dim iw As Integer = Me.EditInnerCheckBox.Width
        Dim ow As Integer = Me.EditOuterCheckBox.Width

        Dim mw As Integer = Math.Max(iw, ow)

        x = Me.Width - mw
        y = Me.Height - Me.EditOuterCheckBox.Height
        loc = New Point(CInt(x), CInt(y))
        Me.EditOuterCheckBox.Location = loc

        y -= Me.EditInnerCheckBox.Height
        loc = New Point(CInt(x), CInt(y))
        Me.EditInnerCheckBox.Location = loc

        Dim it As Integer = Me.EditInnerCheckBox.Location.Y
        Dim ob As Integer = Me.EditOuterCheckBox.Location.Y + Me.EditOuterCheckBox.Height

        ' Position trapezoid parameter controls
        PositionInnerControls()
        PositionOuterControls()

    End Sub

    Private Sub PositionInnerControls()
        '
        ' Position inner keys
        '
        Dim x As Single = Me.Margin.Horizontal
        Dim y As Single = Me.Margin.Vertical
        Dim loc As Point = New Point(CInt(x), CInt(y))

        Me.BinKey.Location = loc

        y += Me.BinKey.Height
        loc = New Point(CInt(x), CInt(y))
        Me.Z1Key.Location = loc

        y += Me.Z1Key.Height
        loc = New Point(CInt(x), CInt(y))
        Me.Z2Key.Location = loc

        y += Me.Z2Key.Height
        loc = New Point(CInt(x), CInt(y))
        Me.D2Key.Location = loc

        y += Me.D2Key.Height
        loc = New Point(CInt(x), CInt(y))
        Me.TwKey.Location = loc
        '
        ' Position Controls relative to inner trapezoid's outline
        '
        Dim inner As PointF() = Me.InnerOutline(mSectionIdx, mViewPort)
        Dim i As Integer = 0
        If (inner.Length = 6) Then
            i += 1
        ElseIf (inner.Length = 8) Then
            i += 2
        End If

        ' Bottom Width control
        x = (inner(1 + i).X + inner(2 + i).X - Me.BinSingle.Width) / 2
        x = Math.Max(x, inner(1 + i).X)
        y = inner(1 + i).Y + 2
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.BinSingle, loc, Me.BinLabel)

        ' Lower slope (Z1) control
        x = inner(3 + i).X - Me.Z1Single.Width
        y = inner(3 + i).Y - Me.Z1Single.Height
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.Z1Single, loc, Me.Z1Label)

        ' Middle slope (Z2) control
        x += Me.Z1Single.Width
        y -= Me.Z1Single.Height
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.Z2Single, loc, Me.Z2Label)

        ' Middle trapezoid depth (D2) control
        x = inner(0).X
        y = inner(1 + i).Y - Me.D2Single.Height - Me.Margin.Vertical
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.D2Single, loc, Me.D2Label)

    End Sub

    Private Sub PositionOuterControls()
        '
        ' Position outer keys
        '
        Dim x As Single = Me.Margin.Horizontal
        Dim y As Single = Me.Thumbnail.Location.Y - 3 * Me.BoutKey.Height - Me.Margin.Vertical
        Dim loc As Point = New Point(CInt(x), CInt(y))

        Me.BoutKey.Location = loc

        y += Me.BoutKey.Height
        loc = New Point(CInt(x), CInt(y))
        Me.Z3Key.Location = loc

        y += Me.Z3Key.Height
        loc = New Point(CInt(x), CInt(y))
        Me.D1Key.Location = loc
        '
        ' Position Controls relative to outer trapezoid's outline
        '
        Dim outer As PointF() = Me.OuterOutline(mSectionIdx, mViewPort)

        ' Bottom Width control
        x = (outer(1).X + outer(2).X - Me.BoutSingle.Width) / 2
        x = Math.Max(x, outer(1).X)
        y = outer(1).Y + Me.Margin.Vertical
        If (y < Me.BinSingle.Location.Y + Me.BinSingle.Height) Then
            y = Me.BinSingle.Location.Y + Me.BinSingle.Height
        End If
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.BoutSingle, loc, Me.BoutLabel)

        ' Slope (Z3) control
        x = outer(0).X
        y = outer(0).Y - Me.Z3Single.Height - Me.Margin.Vertical
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.Z3Single, loc, Me.Z3Label)

        ' Outer to Inner trapezoid delta (D1) control
        x = outer(0).X
        y = outer(2).Y - Me.D1Single.Height
        If (y < Me.D2Single.Location.Y + Me.D2Single.Height) Then
            y = Me.D2Single.Location.Y + Me.D2Single.Height
        End If
        loc = New Point(CInt(x), CInt(y))
        PositionControl(Me.D1Single, loc, Me.D1Label)

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Protected Sub BinSingle_ValueChanged() Handles BinSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then
            Dim Bin As Single = Me.BinSingle.SiValue
            If (mSection.BottomWidth <> Bin) Then
                mSection.BottomWidth = Bin

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach

                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .BottomWidth = Bin
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .BottomWidth = Bin
                            End With
                        End If

                    Case cControl

                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            ' Keep Control Section's cross-section within Approach Channel
                            With ctrlSection
                                Bin = MatchControlBWToApproach(Bin, .D1)
                                If (mSection.BottomWidth > Bin) Then
                                    mSection.BottomWidth = Bin
                                End If
                            End With
                        End If

                    Case cTailwater
                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case Else
                        Debug.Assert(False)

                End Select
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub BoutSingle_ValueChanged() Handles BoutSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then
            Dim Bout As Single = Me.BoutSingle.SiValue
            If (mSection.OuterBottomWidth <> Bout) Then
                mSection.OuterBottomWidth = Bout

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach

                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .OuterBottomWidth = Bout
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .OuterBottomWidth = Bout
                            End With
                        End If

                    Case cControl

                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case cTailwater
                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case Else
                        Debug.Assert(False)

                End Select
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub Z1Single_ValueChanged() Handles Z1Single.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then
            Dim Z1 As Single = Me.Z1Single.SiValue
            If (mSection.Z1 <> Z1) Then
                mSection.Z1 = Z1

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .Z1 = Z1
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .Z1 = Z1
                            End With
                        End If

                    Case cControl
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            ' Keep Control Section's cross-section within Approach Channel
                            With ctrlSection
                                Z1 = MatchZ1ToApproach(Z1)
                                mSection.Z1 = Z1
                            End With
                        End If

                    Case cTailwater
                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case Else
                        Debug.Assert(False)
                End Select
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub Z2Single_ValueChanged() Handles Z2Single.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then
            Dim Z2 As Single = Me.Z2Single.SiValue
            If (mSection.Z2 <> Z2) Then
                mSection.Z2 = Z2

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .Z2 = Z2
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .Z2 = Z2
                            End With
                        End If

                    Case cControl
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            ' Keep Control Section's cross-section within Approach Channel
                            With ctrlSection
                                Z2 = MatchZ2ToApproach(Z2)
                                mSection.Z2 = Z2
                            End With
                        End If

                    Case cTailwater
                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case Else
                        Debug.Assert(False)
                End Select
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub Z3Single_ValueChanged() Handles Z3Single.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then
            Dim Z3 As Single = Me.Z3Single.SiValue
            If (mSection.Z3 <> Z3) Then
                mSection.Z3 = Z3

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .Z3 = Z3
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .Z3 = Z3
                            End With
                        End If

                    Case cControl
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            ' Keep Control Section's cross-section within Approach Channel
                            With ctrlSection
                                Z3 = MatchZ3ToApproach(Z3)
                                mSection.Z3 = Z3
                            End With
                        End If

                    Case cTailwater
                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case Else
                        Debug.Assert(False)
                End Select
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub D1Single_ValueChanged() Handles D1Single.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then
            Dim D1 As Single = Me.D1Single.SiValue
            If (mSection.D1 <> D1) Then
                mSection.D1 = D1

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .D1 = D1
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .D1 = D1
                            End With
                        End If

                    Case cControl

                    Case cTailwater
                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case Else
                        Debug.Assert(False)
                End Select
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub D2Single_ValueChanged() Handles D2Single.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then
            Dim D2 As Single = Me.D2Single.SiValue
            If Not (mSection.D2 = D2) Then
                mSection.D2 = D2

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .D2 = D2
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .D2 = D2
                            End With
                        End If

                    Case cControl

                    Case cTailwater
                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case Else
                        Debug.Assert(False)
                End Select
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub EditInnerCheckBox_ValueChanged() Handles EditInnerCheckBox.ValueChanged
        Me.UpdateUI()
    End Sub

    Protected Sub EditOuterCheckBox_ValueChanged() Handles EditOuterCheckBox.ValueChanged
        Me.UpdateUI()
    End Sub

    Protected Sub VertZoomSingle_ValueChanged()
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
