
'*************************************************************************************************************
' Class CrossSectionControl  - base UserControl for drawing & editing cross sections
'
' Baseclass for all cross section controls; contains common data/code and overridable methods.
'
' The CrossSectionControls not only support drawing the cross section graphics on these controls but also
' provide methods for drawing the graphics on any control.  These methods are used to draw the cross section
' graphics for the End Views and the Drawing Reports.
'
' To add a new cross-section control subclassed from CrossSectionControl:
'   1) Build/Rebuild WinFlume (an error may occur if this is not done)
'   2) Using the 'Solution Explorer' tab, Right-click the 'CrossSectionControls' folder
'       a) Select 'Add -> New Item...' to display the 'Add New Item' dialog
'   3) Under 'Common Items', select 'Windows Forms'
'       a) Select 'Inherited User Control' from the list on the right side
'       b) Enter the name of the new cross-section control (e.g. CircleInCircleControl)
'       c) Press the 'Add' button to display the 'Inheritance Picker' dialog
'   4) Using 'Inheritance Picker', select 'CrossSectionControl' from the list
'       a) Press the 'Ok' button to add the new cross-section control
'*************************************************************************************************************
Imports System.Windows

Imports Flume
Imports Flume.Globals

Public Class CrossSectionControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Protected mFlume As Flume.FlumeType = Nothing
    Protected mSection As Flume.SectionType = Nothing
    Protected mDefaultSection As Flume.SectionType = Nothing

    Protected mBedDrop As Single
    Protected mBottomHeight As Single
    Protected mCanalDepth As Single
    Protected mCanalWidth As Single
    Protected mChannelDepth As Single
    Protected mChannelWidth As Single
    Protected mDiamFocalDist As Single
    Protected mOuterDiamFocalDist As Single
    Protected mSillHeight As Single
    ' Error flag
    Protected mFlumeErr As Boolean
    '
    ' Support for drawing cross section graphics
    '
    Protected mViewPort As RectangleF = New RectangleF

    Protected mHorzOffset As Single = 0
    Protected mHorzScale As Single = 1
    Protected mVertOffset As Single = 0
    Protected mVertScale As Single = 1

    Protected mOuter As PointF() = Nothing
    Protected mInner As PointF() = Nothing
    '
    ' Drawing tools
    '
    Protected mBlackPen1 As Pen = BlackPen1()
    Protected mBlackDashedPen1 As Pen = BlackDashedPen1()
    Protected mBlackBrush As Brush = BlackSolidBrush()
    Protected mBold As Font = New Font(Me.Font, FontStyle.Bold)
    Public Function BoldFont() As Font
        Return mBold
    End Function

#End Region

#Region " Properties "

    ' Index into Flume.Section() array; selects whether Approach, Control or TailWater section is drawn
    Protected mSectionIdx As Integer = -1
    Public Property SectionIdx() As Integer
        Get
            Return mSectionIdx
        End Get
        Set(ByVal value As Integer)
            If ((cApproach <= value) And (value <= cTailwater)) Then
                mSectionIdx = value
            Else
                Debug.Assert(False)
            End If
        End Set
    End Property

    ' Outer shape properties
    Public Property OuterIsReadOnly As Boolean = False
    Public Function D1visible() As Boolean
        D1visible = WinFlumeForm.D1visible
    End Function

#End Region

#Region " Outline Methods "

    '*********************************************************************************************************
    ' Sub InitializeCrossSection() - initialize the cross section data
    '
    ' Input(s):     SectionIdx      - Approach/Control/Tailwater section ID
    '               AltFlume        - FlumeType alternate from AlternativeDesigns
    '*********************************************************************************************************
    Public Sub InitializeCrossSection(ByVal SectionIdx As Integer, ByVal AltFlume As FlumeType)
        If (AltFlume IsNot Nothing) Then
            mFlume = AltFlume
        Else
            mFlume = WinFlumeForm.Flume
        End If
        InitializeCrossSection(SectionIdx)
    End Sub

    Private Sub InitializeCrossSection(ByVal SectionIdx As Integer)
        Try
            mSectionIdx = SectionIdx
            mSection = mFlume.Section(mSectionIdx)
            mDefaultSection = WinFlumeForm.DefaultFlume.Section(mSectionIdx)

            ' Flume dependent data
            mBedDrop = mFlume.BedDrop
            mChannelDepth = mFlume.ChannelDepth
            mCanalDepth = mChannelDepth + mBedDrop
            mCanalWidth = Me.MaxSectionWidth(mChannelDepth, mFlumeErr)
            mSillHeight = Math.Min(mFlume.SillHeight, mFlume.ChannelDepth)

            ' Section dependent data
            mDiamFocalDist = mSection.DiameterFocalD
            mOuterDiamFocalDist = mFlume.Section(cApproach).DiameterFocalD

            Select Case mSectionIdx
                Case cApproach
                    mBottomHeight = mBedDrop
                    mChannelWidth = mSection.TopWidth(mChannelDepth, mFlumeErr)
                Case cControl
                    mBottomHeight = mSillHeight + mBedDrop
                    mChannelWidth = mSection.TopWidth(mChannelDepth - mSillHeight, mFlumeErr)
                Case cTailwater
                    mBottomHeight = 0
                    mChannelWidth = mSection.TopWidth(mChannelDepth + mBedDrop, mFlumeErr)
                Case Else
                    Debug.Assert(False)
            End Select

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Protected Function MaxSectionWidth(ByVal Y As Single, ByRef errVal As Boolean) As Single

        Dim aTopWidth, cTopWidth, tTopWidth As Single
        Dim aErr, cErr, tErr As Boolean

        Dim outerTopWidth, CD, SH, BD, Bout, D1, Z3 As Single

        CD = mFlume.ChannelDepth
        SH = mFlume.SillHeight
        BD = mFlume.BedDrop

        aTopWidth = mFlume.Section(cApproach).TopWidth(Y, aErr)
        If (mFlume.Section(cApproach).Shape = shComplexTrapezoid) Then
            D1 = mFlume.Section(cApproach).D1
            Bout = mFlume.Section(cApproach).OuterBottomWidth
            Z3 = mFlume.Section(cApproach).Z3
            outerTopWidth = Bout + (CD + D1) * Z3 * 2

            If (aTopWidth < outerTopWidth) Then
                aTopWidth = outerTopWidth
            End If
        End If

        cTopWidth = mFlume.Section(cControl).TopWidth(Y - mFlume.SillHeight, cErr)
        If (mFlume.Section(cControl).Shape = shComplexTrapezoid) Then
            D1 = mFlume.Section(cControl).D1
            Bout = mFlume.Section(cControl).OuterBottomWidth
            Z3 = mFlume.Section(cControl).Z3
            outerTopWidth = Bout + (CD - SH + D1) * Z3 * 2

            If (cTopWidth < outerTopWidth) Then
                cTopWidth = outerTopWidth
            End If
        ElseIf (mFlume.Section(cControl).Shape = shTrapezoidInParabola) Then
            Dim DF As Single = mFlume.Section(cControl).DiameterFocalD
            outerTopWidth = 2 * CSng(Math.Sqrt(2 * DF * Y))

            If (cTopWidth < outerTopWidth) Then
                cTopWidth = outerTopWidth
            End If
        ElseIf (mFlume.Section(cControl).Shape = shVInRectangle) Then
            Dim BW As Single = mFlume.Section(cControl).BottomWidth

            If (cTopWidth < BW) Then
                cTopWidth = BW
            End If
        End If

        tTopWidth = mFlume.Section(cTailwater).TopWidth(Y + mFlume.BedDrop, tErr)
        If (mFlume.Section(cTailwater).Shape = shComplexTrapezoid) Then
            D1 = mFlume.Section(cTailwater).D1
            Bout = mFlume.Section(cTailwater).OuterBottomWidth
            Z3 = mFlume.Section(cTailwater).Z3
            outerTopWidth = Bout + (CD + BD + D1) * Z3 * 2

            If (tTopWidth < outerTopWidth) Then
                tTopWidth = outerTopWidth
            End If
        End If

        If Not (aErr Or cErr Or tErr) Then
            MaxSectionWidth = Math.Max(aTopWidth, cTopWidth)
            MaxSectionWidth = Math.Max(MaxSectionWidth, tTopWidth)
            errVal = False
        Else
            Debug.Assert(False)
            errVal = True
        End If

    End Function

    '*********************************************************************************************************
    ' Functions:    OuterOutline()      - left edge, invert, right edge
    '               InnerOutline()      - left edge, sill, right edge     - baseclass default is OuterOutline
    '               LeftEdgeOutline()   - left edge (top to sill)         - extracted from InnerOutline
    '               RightEdgeOutline()  - right edge (sill to top)        -     "       "       "
    '               SillOutline()       - sill (left to right)            -     "       "       "
    '               InvertOutline()     - invert (left to right)          -     "       "  OuterOutline
    '
    ' Input(s):     SectionIdx  - index indicating section type (cApproach, cControl, cTailwater)
    '               ViewPort    - rectangle defining area to draw graphic within
    '
    ' Over-riden methods should call baseclass method to initialize cross section data
    '
    ' Note - all outlines are generated counter-clock wise
    '*********************************************************************************************************
    Public Overridable Function OuterOutline(ByVal SectionIdx As Integer,
                                             ByVal ViewPort As RectangleF) As PointF()
        InitializeCrossSection(SectionIdx)
        mViewPort = ViewPort
        ScaleToViewport()
        OuterOutline = Nothing
    End Function

    Public Overridable Function InnerOutline(ByVal SectionIdx As Integer,
                                             ByVal ViewPort As RectangleF) As PointF()
        InitializeCrossSection(SectionIdx)
        mViewPort = ViewPort
        ScaleToViewport()
        InnerOutline = OuterOutline(SectionIdx, ViewPort)
    End Function

    Public Function LeftEdgeOutline(ByVal SectionIdx As Integer, ByVal ViewPort As RectangleF,
                                    Optional ByVal InnerOutline As PointF() = Nothing) As PointF()
        Try
            If (InnerOutline Is Nothing) Then
                InnerOutline = Me.InnerOutline(SectionIdx, ViewPort)
            Else
                InitializeCrossSection(SectionIdx)
                mViewPort = ViewPort
                ScaleToViewport()
            End If

            Dim iub As Integer = InnerOutline.GetUpperBound(0)
            If (iub < 0) Then
                LeftEdgeOutline = Nothing
            Else
                ' Extract left edge outline from inner outline
                Dim leftEdge(iub) As PointF
                Dim ldx As Integer = 0
                leftEdge(0) = InnerOutline(0)

                For idx As Integer = 1 To iub
                    If (InnerOutline(idx).Y > leftEdge(ldx).Y) Then ' left-edge continuing
                        ldx += 1
                        leftEdge(ldx) = InnerOutline(idx)
                    ElseIf (InnerOutline(idx).Y = leftEdge(ldx).Y) Then ' duplicate  point
                        ' skip point
                    Else ' at Sill
                        Exit For
                    End If
                Next idx

                ReDim Preserve leftEdge(ldx)
                LeftEdgeOutline = leftEdge
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
            LeftEdgeOutline = Nothing
        End Try

    End Function

    Public Function RightEdgeOutline(ByVal SectionIdx As Integer, ByVal ViewPort As RectangleF,
                                     Optional ByVal InnerOutline As PointF() = Nothing) As PointF()
        Try
            If (InnerOutline Is Nothing) Then
                InnerOutline = Me.InnerOutline(SectionIdx, ViewPort)
            Else
                InitializeCrossSection(SectionIdx)
                mViewPort = ViewPort
                ScaleToViewport()
            End If

            Dim iub As Integer = InnerOutline.GetUpperBound(0)
            If (iub < 0) Then
                RightEdgeOutline = Nothing
            Else
                ' Skip past Left-Edge & Sill
                Dim idx As Integer = 0
                While idx < iub
                    If (InnerOutline(idx + 1).Y >= InnerOutline(idx).Y) Then ' left-edge/sill continuing
                        idx += 1
                    Else ' past Sill
                        Exit While
                    End If
                End While

                ' Extract right edge outline from inner outline
                Dim rightEdge(iub) As PointF
                Dim rdx As Integer = 0
                While idx <= iub
                    rightEdge(rdx) = InnerOutline(idx)
                    rdx += 1
                    idx += 1
                End While

                ReDim Preserve rightEdge(rdx - 1)
                RightEdgeOutline = rightEdge
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
            RightEdgeOutline = Nothing
        End Try
    End Function

    Public Function SillOutline(ByVal SectionIdx As Integer, ByVal ViewPort As RectangleF,
                                Optional ByVal InnerOutline As PointF() = Nothing) As PointF()
        Try
            If (InnerOutline Is Nothing) Then
                InnerOutline = Me.InnerOutline(SectionIdx, ViewPort)
            Else
                InitializeCrossSection(SectionIdx)
                mViewPort = ViewPort
                ScaleToViewport()
            End If
            Dim iub As Integer = InnerOutline.GetUpperBound(0)

            ' Extract sill outline from inner outline
            Dim sill(1) As PointF
            If (iub < 0) Then
                sill = Nothing
            ElseIf (iub = 0) Then
                sill(0) = InnerOutline(0)
                sill(1) = InnerOutline(0)
            ElseIf (iub = 1) Then
                sill(0) = InnerOutline(0)
                sill(1) = InnerOutline(1)
            ElseIf (iub = 2) Then
                sill(0) = InnerOutline(1)
                sill(1) = InnerOutline(1)
            ElseIf (iub = 3) Then
                sill(0) = InnerOutline(1)
                sill(1) = InnerOutline(2)
            Else ' (4 <= iub)
                Dim midPt As Integer = CInt(Math.Floor(iub / 2))

                sill(0) = InnerOutline(midPt)
                sill(1) = InnerOutline(midPt + 1)

                If (sill(0).Y > sill(1).Y) Then
                    sill(0) = InnerOutline(midPt - 1)
                    sill(1) = InnerOutline(midPt)
                ElseIf (sill(0).Y < sill(1).Y) Then
                    sill(0) = InnerOutline(midPt + 1)
                    sill(1) = InnerOutline(midPt + 2)
                End If

                If Not (sill(0).Y = sill(1).Y) Then
                    sill(0) = InnerOutline(midPt)
                    sill(1) = InnerOutline(midPt)
                End If
            End If

            SillOutline = sill
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
            SillOutline = Nothing
        End Try
    End Function

    Public Overridable Function InvertOutline(ByVal SectionIdx As Integer,
                                              ByVal ViewPort As RectangleF) As PointF()
        InitializeCrossSection(SectionIdx)
        mViewPort = ViewPort
        ScaleToViewport()
        InvertOutline = Nothing
    End Function

    Public Overridable Function TruncatedRampOutline(ByVal SectionIdx As Integer,
                                                     ByVal ViewPort As RectangleF) As PointF()
        InitializeCrossSection(SectionIdx)
        mViewPort = ViewPort
        ScaleToViewport()
        TruncatedRampOutline = InvertOutline(SectionIdx, ViewPort)
    End Function

    '*********************************************************************************************************
    ' Sub ScaleToViewport()     - scale the real world coordinates to the Control's ViewPort
    '*********************************************************************************************************
    Private Sub ScaleToViewport()
        ' Scale cross section to fit ViewPort
        Dim CD As Single = mFlume.CanalDepth            ' Canal depth including buried components

        mHorzScale = mViewPort.Width / mCanalWidth
        mVertScale = mViewPort.Height / mFlume.CanalDepth
        ' Start with 1:1 aspect ratio
        If (mHorzScale > mVertScale) Then
            mHorzScale = mVertScale
        Else
            mVertScale = mHorzScale
        End If
        ' Center graphics within Viewport
        mHorzOffset = (mViewPort.Width - mCanalWidth * mHorzScale) / 2
        mVertOffset = (mViewPort.Height - mFlume.CanalDepth * mVertScale) / 2
    End Sub

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI
    '*********************************************************************************************************
    Private mUpdatingUI As Boolean = False

    Public Overridable Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected Overridable Sub UpdateUI()

        If Not Me.Visible Then
            Return
        End If

        If (mUpdatingUI) Then
            Return
        End If

        mUpdatingUI = True

        mFlume = WinFlumeForm.Flume                 ' Flume data

        Try
            If (mFlume IsNot Nothing) Then
                mSection = mFlume.Section(mSectionIdx)
                mDefaultSection = WinFlumeForm.DefaultFlume.Section(mSectionIdx)

                Me.UpdateControlValues()            ' Update currently dislayed values from Flume
                Me.Invalidate()                     ' Causes OnPaint() to be called
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        mUpdatingUI = False
    End Sub

    '*********************************************************************************************************
    ' Sub UpdateControlValues() - update contained Controls' values
    '*********************************************************************************************************
    Protected Overridable Sub UpdateControlValues()
        Me.InitializeCrossSection(SectionIdx)
    End Sub

    '*********************************************************************************************************
    ' Protected Overridable Sub DrawCrossSection() - called by OnPaint() to draw CrossSectionControl graphics
    '
    ' Public Sub DrawCrossSection() - draw both outer & inner cross section graphics on a Control
    ' Public Sub DrawOuterCrossSection() - draw outer portion of cross section graphics on a Control
    ' Public Sub DrawInnerCrossSection() - draw inner portion of cross section graphics on a Control
    '
    ' The three above public methods provide cross section graphics drawing to other controls such as the
    ' End Views and Drawing Reports.
    '
    ' Input(s):     SectionIdx  - index indicating section type (cApproach, cControl, cTailwater)
    '               ViewPort    - rectangle defining area to draw graphic within
    '               eGraphics   - graphics object for drawing (should be from OnPaint handler)
    '               dPen        - pen to draw with
    '*********************************************************************************************************
    Protected Overridable Sub DrawCrossSection(ByVal eGraphics As Graphics)
        ' Define ViewPort for drawing cross section graphics; must be the same for all cross section controls
        mViewPort.X = 150                               ' Room on left for Thumbnail image
        mViewPort.Y = 50 + 2 * Me.Margin.Vertical       ' Room on top for labels

        mViewPort.Width = Me.Size.Width - mViewPort.X - 2 * Me.Margin.Horizontal
        mViewPort.Height = Me.Size.Height - mViewPort.Y - 25 - Me.Margin.Vertical ' Room on bottom for ctl_Single
    End Sub

    Public Overridable Sub DrawCrossSection(ByVal SectionIdx As Integer, ByVal ViewPort As RectangleF,
                                            ByVal eGraphics As Drawing.Graphics, ByVal dPen As Drawing.Pen)
        DrawInnerCrossSection(SectionIdx, ViewPort, eGraphics, dPen)
        DrawOuterCrossSection(SectionIdx, ViewPort, eGraphics, dPen)
    End Sub

    Public Overridable Sub DrawOuterCrossSection(ByVal SectionIdx As Integer, ByVal ViewPort As RectangleF,
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

    Public Overridable Sub DrawInnerCrossSection(ByVal SectionIdx As Integer, ByVal ViewPort As RectangleF,
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
    '*********************************************************************************************************
    Public Overridable Sub DrawExtras(ByVal eGraphics As Graphics)
    End Sub

    '*********************************************************************************************************
    ' Sub AnnotateDrawing() - annotate cross section's printable drawing
    '*********************************************************************************************************
    Public Overridable Sub AnnotateDrawing(ByVal eGraphics As Graphics)
        DrawExtras(eGraphics)
    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls; implemented by subclass
    ' Sub PositionControl()  - position Control and possible Label at a location ensuring it fits
    '*********************************************************************************************************
    Protected Overridable Sub PositionControls()
    End Sub

    Protected Sub PositionControl(ByVal Ctrl As Control, ByRef Loc As Point,
                                  Optional ByVal Label As Control = Nothing)
        ' Ensure value Control fits within Cross-Section Control
        Loc.X = Math.Max(Loc.X, 0)
        Loc.X = Math.Min(Loc.X, Me.Width - Ctrl.Width + Me.Margin.Horizontal)
        Loc.Y = Math.Max(Loc.Y, 0)
        Loc.Y = Math.Min(Loc.Y, Me.Height - Ctrl.Height + Me.Margin.Vertical)
        Ctrl.Location = Loc

        If (Label IsNot Nothing) Then ' Control has a Label; Label precedes Control
            Dim x As Integer = Loc.X - Label.Width
            Dim y As Integer = Loc.Y + 2
            Loc = New Point(CInt(x), CInt(y))
            Label.Location = Loc
        End If
    End Sub

#End Region

#Region " Section Methods "

    '*********************************************************************************************************
    ' Sub MatchControlToApproach
    '*********************************************************************************************************
    Protected Sub MatchControlToApproach(ByVal mFlume As FlumeType)

        If (mFlume IsNot Nothing) Then
            mSection = mFlume.Section(mSectionIdx)  ' Flume.Section

            If (WinFlumeForm.ControlMatchedToApproach) Then
                'Debug.Assert(mFlume.Section(cApproach).Shape = shSimpleTrapezoid)
                ' Match Control Section cross-section to Approach Channel cross-section
                With mSection
                    .D1 = mFlume.SillHeight
                    ' .Z1 = mFlume.Section(cApproach).Z1
                    ' .Z2 = mFlume.Section(cApproach).Z1
                    .Z3 = mFlume.Section(cApproach).Z1
                    ' .BottomWidth = mFlume.Section(cApproach).TopWidth(.D1, False)
                    .OuterBottomWidth = mFlume.Section(cApproach).BottomWidth
                End With
                'Else
                '    Debug.Assert(False)
            End If
        Else
            Debug.Assert(False)
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub SetControlBW() - set Control Section's Bottom Width
    '*********************************************************************************************************
    Protected Sub SetControlBW(ByVal BW As Single)
        Try
            Debug.Assert(mSectionIdx = cControl)

            If (mSection.BottomWidth = BW) Then ' value not changed; nothing to do
                Return
            Else ' save the new value
                mSection.BottomWidth = BW
            End If

            If (WinFlumeForm.ControlMatchedToApproach) Then
                ' Keep Control Section's cross-section within Approach Channel
                BW = MatchControlBWToApproach(mSection.BottomWidth, mSection.D1)
                If (mSection.BottomWidth > BW) Then
                    mSection.BottomWidth = BW
                End If

                Dim Z1 As Single = MatchZ1ToApproach(mSection.Z1)
                If (mSection.Z1 <> Z1) Then
                    mSection.Z1 = Z1
                End If

            Else ' Not Matched
                Select Case (mSection.Shape)
                    Case shTrapezoidInCircle, shTrapezoidInParabola, shTrapezoidInUShaped
                        BW = MatchControlBWToApproach(mSection.BottomWidth, mSection.D1)
                        If (mSection.BottomWidth > BW) Then
                            mSection.BottomWidth = BW
                        End If
                End Select
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        Finally
            mWinFlumeForm.RaiseFlumeDataChanged()
        End Try

    End Sub

    '*********************************************************************************************************
    ' Sub SetBW()       - set BottomWidth
    ' Sub SetZ1()       - set slope Z1
    ' Sub SetDFD()      - set Diameter / Focal Distance
    ' Sub SetD1()       - set inner height D1
    ' Sub SetDiameter() - Set Diameter for Circle-based cross-sections
    '
    ' Baseclass methods to set the commonly shared parameters of most flume cross-sections.
    '
    ' Note - the Complex Trapezoid & Trapezoid-In-Rectangle cross-sections do not use these methods; all of
    '        their parameters require unique handling (Trapezoid-In-Rectangle is just a UI wrapper around
    '        a Complex Trapezoid cross-section)
    '*********************************************************************************************************
    Protected Sub SetBW(ByVal BW As Single)
        Try
            If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then

                If (mSection.BottomWidth = BW) Then ' value not changed; nothing to do
                    Return
                End If

                ' Compute ratio for adjusting Control Section's inner shape, if present
                Dim ratio As Single = 1 - (mSection.BottomWidth - BW) / mSection.BottomWidth

                ' Save new value in Flume structure
                mSection.BottomWidth = BW

                Dim apprSection As SectionType = mFlume.Section(cApproach)
                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                Select Case .Shape
                                    Case < shComplexTrapezoid ' set of simple shapes
                                        .BottomWidth = BW
                                    Case shSillInTrapezoid, shSillInRectangle, shVInRectangle
                                        .BottomWidth = BW
                                        .OuterBottomWidth = apprSection.BottomWidth
                                    Case Else
                                        .BottomWidth *= ratio
                                        .OuterBottomWidth = apprSection.BottomWidth

                                        If Not (WinFlumeForm.InRedo Or WinFlumeForm.InUndo) Then
                                            Dim title As String = My.Resources.TitleControlSectionModified
                                            Dim msg As String = My.Resources.MsgControSectionModified
                                            MsgBox(msg, MsgBoxStyle.Information, title)
                                        End If
                                End Select
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .BottomWidth = BW
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
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        Finally
            mWinFlumeForm.RaiseFlumeDataChanged()
        End Try
    End Sub

    Protected Sub SetZ1(ByVal Z1 As Single)
        Try
            If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then

                If (mSection.Z1 = Z1) Then ' value not changed; nothing to do
                    Return
                End If

                ' Compute ratio for adjusting Control Section's inner shape, if present
                Dim ratio As Single = 1 - (mSection.Z1 - Z1) / mSection.Z1

                ' Save new value in Flume structure
                mSection.Z1 = Z1

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .BottomWidth *= ratio
                                .Z1 *= ratio
                                .Z3 = Z1

                                If Not (WinFlumeForm.InRedo Or WinFlumeForm.InUndo) Then
                                    Dim title As String = My.Resources.TitleControlSectionModified
                                    Dim msg As String = My.Resources.MsgControSectionModified
                                    MsgBox(msg, MsgBoxStyle.Information, title)
                                End If
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
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        Finally
            mWinFlumeForm.RaiseFlumeDataChanged()
        End Try
    End Sub

    Protected Sub SetDFD(ByVal DFD As Single)
        Try
            If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then

                If (mSection.DiameterFocalD = DFD) Then ' value not changed; nothing to do
                    Return
                End If

                ' Compute ratio for adjusting Control Section's inner shape, if present
                Dim ratio As Single = 1 - (mSection.DiameterFocalD - DFD) / mSection.DiameterFocalD

                ' Save new value in Flume structure
                mSection.DiameterFocalD = DFD

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .BottomWidth *= ratio
                                .DiameterFocalD *= ratio

                                If Not (WinFlumeForm.InRedo Or WinFlumeForm.InUndo) Then
                                    Dim title As String = My.Resources.TitleControlSectionModified
                                    Dim msg As String = My.Resources.MsgControSectionModified
                                    MsgBox(msg, MsgBoxStyle.Information, title)
                                End If
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .DiameterFocalD = DFD
                            End With
                        End If

                    Case cControl
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                DFD = MatchDFDToApproach(DFD)
                                .DiameterFocalD = DFD
                            End With
                        End If

                    Case cTailwater
                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case Else
                        Debug.Assert(False)
                End Select
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        Finally
            mWinFlumeForm.RaiseFlumeDataChanged()
        End Try
    End Sub

    Protected Sub SetD1(ByVal D1 As Single)
        Try
            If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then
                If (mSection.D1 = D1) Then ' value not changed; nothing to do
                    Return
                End If

                mSection.D1 = D1
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        Finally
            mWinFlumeForm.RaiseFlumeDataChanged()
        End Try
    End Sub

    Protected Sub SetDiameter(ByVal Diameter As Single)
        Try
            If ((mWinFlumeForm IsNot Nothing) And (mSection IsNot Nothing)) Then

                If (mSection.DiameterFocalD = Diameter) Then ' value not changed; nothing to do
                    Return
                End If

                ' Save new value in Flume structure
                If (Diameter < mFlume.ChannelDepth) Then
                    Dim title As String = My.Resources.TitleCDgtDiameter
                    Dim msg As String = My.Resources.MsgCDgtDiameter
                    Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                    If (result = MsgBoxResult.Yes) Then
                        mFlume.ChannelDepth = Diameter
                    End If
                End If
                mSection.DiameterFocalD = Diameter

                ' Compute ratio for adjusting Control Section's inner shape, if present
                Dim ratio As Single = 1 - (mSection.DiameterFocalD - Diameter) / mSection.DiameterFocalD

                Dim ctrlSection As SectionType = mFlume.Section(cControl)
                Dim tailSection As SectionType = mFlume.Section(cTailwater)

                Select Case SectionIdx
                    Case cApproach
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                .BottomWidth *= ratio
                                .DiameterFocalD *= ratio

                                If Not (WinFlumeForm.InRedo Or WinFlumeForm.InUndo) Then
                                    Dim title As String = My.Resources.TitleControlSectionModified
                                    Dim msg As String = My.Resources.MsgControSectionModified
                                    MsgBox(msg, MsgBoxStyle.Information, title)
                                End If
                            End With
                        End If

                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            With tailSection
                                .DiameterFocalD = Diameter
                            End With
                        End If

                    Case cControl
                        If (WinFlumeForm.ControlMatchedToApproach) Then
                            With ctrlSection
                                Diameter = MatchDFDToApproach(Diameter)
                                .DiameterFocalD = Diameter
                            End With
                        End If

                    Case cTailwater
                        If (WinFlumeForm.TailwaterMatchedToApproach) Then
                            Debug.Assert(False)
                        End If

                    Case Else
                        Debug.Assert(False)
                End Select
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        Finally
            mWinFlumeForm.RaiseFlumeDataChanged()
        End Try
    End Sub

    '*********************************************************************************************************
    ' Function MatchControlBWToApproach() - ensure Control Section's BottomWidth fits within Approach Channel
    '
    ' Input(s):     BW  - user entered bottom width
    '               D1  - flow depth of BW
    '
    ' Returns:      BW  - that fits within Approach Channel
    '*********************************************************************************************************
    Protected Function MatchControlBWToApproach(ByVal BW As Single, ByVal D1 As Single) As Single
        Dim ctrlSection As SectionType = mFlume.Section(cControl)
        Dim apprSection As SectionType = mFlume.Section(cApproach)
        Dim apprTWatD1 As Single = apprSection.TopWidth(D1, False)

        Select Case (ctrlSection.Shape)
            Case shVInRectangle

                If (BW > apprTWatD1) Then
                    BW = apprTWatD1
                    MsgBox(My.Resources.BottomWidthLimited, MsgBoxStyle.Exclamation, My.Resources.BottomWidth)
                End If

            Case shTrapezoidInCircle, shTrapezoidInParabola, shTrapezoidInUShaped,
                    shTrapezoidInTrapezoid, shTrapezoidInVShaped, shTrapezoidInRectangle,
                    shRectangleInRectangle, shComplexTrapezoid

                Dim msg As String = My.Resources.BottomWidthLimited & vbCrLf & vbCrLf
                msg &= My.Resources.SimplifyToSill

                If (BW > apprTWatD1) Then
                    BW = apprTWatD1

                    Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, My.Resources.BottomWidth)
                    If (result = MsgBoxResult.Yes) Then
                        ' A change from Trapezoid-In-Shape to Sill-In-Shape has been requested;
                        ' first, remove the last BW change from the Undo Stack
                        mWinFlumeForm.RemoveLastUndoItem()
                        ' then, have the Control Section Control's handle the cross-section change
                        Try
                            Dim parentCtrl As Control = Me.Parent
                            Debug.Assert(parentCtrl.GetType Is GetType(ctl_Panel))
                            parentCtrl = parentCtrl.Parent

                            If (parentCtrl.GetType Is GetType(ControlSectionControl)) Then
                                Dim ctrlSecCtrl As ControlSectionControl = DirectCast(parentCtrl, ControlSectionControl)

                                If (WinFlumeForm.ControlMatchedToApproach) Then
                                    ctrlSecCtrl.ControlCrossSection.SaveNewValue(0) ' Index 0 is Sill-In-shape
                                Else ' Not matched; index is (shape - 1)
                                    Select Case (ctrlSection.Shape)
                                        Case shTrapezoidInCircle
                                            ctrlSecCtrl.ControlCrossSection.SaveNewValue(shSillInCircle - 1)
                                        Case shTrapezoidInParabola
                                            ctrlSecCtrl.ControlCrossSection.SaveNewValue(shSillInParabola - 1)
                                        Case shTrapezoidInUShaped
                                            ctrlSecCtrl.ControlCrossSection.SaveNewValue(shSillInUShaped - 1)
                                        Case Else
                                            Debug.Assert(False)
                                    End Select
                                End If
                            Else
                                Debug.Assert(False)
                            End If
                        Catch ex As Exception
                            Debug.Assert(False, ex.Message)
                        End Try
                    Else ' No - remove the last BW change from the Undo Stack
                        mWinFlumeForm.Undo()
                        mWinFlumeForm.ClearRedoStack()
                    End If
                ElseIf (BW = apprTWatD1) Then

                    Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, My.Resources.BottomWidth)
                    If (result = MsgBoxResult.Yes) Then
                        ' A change from Trapezoid-In-Shape to Sill-In-Shape has been requested;
                        ' first, remove the last BW change from the Undo Stack
                        mWinFlumeForm.RemoveLastUndoItem()
                        ' then, have the Control Section Control's handle the cross-section change
                        Try
                            Dim parentCtrl As Control = Me.Parent
                            Debug.Assert(parentCtrl.GetType Is GetType(ctl_Panel))
                            parentCtrl = parentCtrl.Parent

                            If (parentCtrl.GetType Is GetType(ControlSectionControl)) Then
                                Dim ctrlSecCtrl As ControlSectionControl = DirectCast(parentCtrl, ControlSectionControl)

                                If (WinFlumeForm.ControlMatchedToApproach) Then
                                    ctrlSecCtrl.ControlCrossSection.SaveNewValue(0) ' Index 0 is Sill-In-shape
                                Else ' Not matched; index is (shape - 1)
                                    Select Case (ctrlSection.Shape)
                                        Case shTrapezoidInCircle
                                            ctrlSecCtrl.ControlCrossSection.SaveNewValue(shSillInCircle - 1)
                                        Case shTrapezoidInParabola
                                            ctrlSecCtrl.ControlCrossSection.SaveNewValue(shSillInParabola - 1)
                                        Case shTrapezoidInUShaped
                                            ctrlSecCtrl.ControlCrossSection.SaveNewValue(shSillInUShaped - 1)
                                        Case Else
                                            Debug.Assert(False)
                                    End Select
                                End If
                            Else
                                Debug.Assert(False)
                            End If
                        Catch ex As Exception
                            Debug.Assert(False, ex.Message)
                        End Try
                    End If
                End If
            Case Else
                Debug.Assert(False)
        End Select

        Return BW
    End Function

    '*********************************************************************************************************
    ' Function MatchZ1ToApproach() - ensure side-slope Z1 fits within Approach Channel dimension
    ' Function MatchZ2ToApproach() -    "     "    "   Z2   "     "       "       "        "
    ' Function MatchZ3ToApproach() -    "     "    "   Z3   "     "       "       "        "
    '
    ' Input(s):     Zn  - user entered side slope
    '
    ' Returns:      Zn  - that fits within Approach Channel
    '*********************************************************************************************************
    Protected Function MatchZ1ToApproach(ByVal Z1 As Single) As Single
        If (WinFlumeForm.ControlMatchedToApproach) Then
            Dim ctrlSection As SectionType = mFlume.Section(cControl)
            Select Case ctrlSection.Shape
                Case shVInRectangle, shTrapezoidInCircle, shTrapezoidInUShaped, shTrapezoidInParabola
                    ' no Z1 limit for these shapes
                Case Else
                    Dim apprSection As SectionType = mFlume.Section(cApproach)
                    If (Z1 > apprSection.Z1) Then
                        Z1 = apprSection.Z1
                        MsgBox(My.Resources.SideSlopeLimited, MsgBoxStyle.Exclamation, My.Resources.SideSlope)
                        'ElseIf (Z1 < apprSection.Z1) Then
                        '    Z1 = apprSection.Z1
                    End If
            End Select
        End If
        Return Z1
    End Function

    Protected Function MatchZ2ToApproach(ByVal Z2 As Single) As Single
        If (WinFlumeForm.ControlMatchedToApproach) Then
            Dim ctrlSection As SectionType = mFlume.Section(cControl)
            Select Case ctrlSection.Shape
                Case shVInRectangle, shTrapezoidInCircle, shTrapezoidInUShaped, shTrapezoidInParabola
                    ' no Z2 limit for these shapes
                Case Else
                    Dim apprSection As SectionType = mFlume.Section(cApproach)
                    If (Z2 > apprSection.Z2) Then
                        Z2 = apprSection.Z2
                        MsgBox(My.Resources.SideSlopeLimited, MsgBoxStyle.Exclamation, My.Resources.SideSlope)
                    End If
            End Select
        End If
        Return Z2
    End Function

    Protected Function MatchZ3ToApproach(ByVal Z3 As Single) As Single
        If (WinFlumeForm.ControlMatchedToApproach) Then
            Dim ctrlSection As SectionType = mFlume.Section(cControl)
            Select Case ctrlSection.Shape
                Case shVInRectangle, shTrapezoidInCircle, shTrapezoidInUShaped, shTrapezoidInParabola
                    ' no Z3 limit for these shapes
                Case Else
                    Dim apprSection As SectionType = mFlume.Section(cApproach)
                    If (Z3 > apprSection.Z3) Then
                        Z3 = apprSection.Z3
                        MsgBox(My.Resources.SideSlopeLimited, MsgBoxStyle.Exclamation, My.Resources.SideSlope)
                    End If
            End Select
        End If
        Return Z3
    End Function

    '*********************************************************************************************************
    ' Function MatchDFDToApproach() - ensure diameter / focal distance fits within Approach Channel dimension
    '
    ' Input(s):     DFD  - user entered diameter / focal distance
    '
    ' Returns:      DFD  - that fits within Approach Channel
    '*********************************************************************************************************
    Protected Function MatchDFDToApproach(ByVal DFD As Single) As Single
        If (WinFlumeForm.ControlMatchedToApproach) Then
            Dim ctrlSection As SectionType = mFlume.Section(cControl)
            Select Case ctrlSection.Shape
                Case shCircle, shCircleInCircle, shUShaped, shUShapedInUShaped
                    Dim apprSection As SectionType = mFlume.Section(cApproach)
                    If (DFD > apprSection.DiameterFocalD) Then
                        DFD = apprSection.DiameterFocalD
                        MsgBox(My.Resources.DiameterLimited, MsgBoxStyle.Exclamation, My.Resources.Diameter)
                    End If
                Case shParabola, shParabolaInParabola
                    Dim apprSection As SectionType = mFlume.Section(cApproach)
                    If (DFD > apprSection.DiameterFocalD) Then
                        DFD = apprSection.DiameterFocalD
                        MsgBox(My.Resources.FocalDistanceLimited, MsgBoxStyle.Exclamation, My.Resources.FocalDistance)
                    End If
            End Select
        End If
        Return DFD
    End Function

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Sub OnPaint() - called when Control requires re-painting
    '*********************************************************************************************************
    Protected Overrides Sub OnPaint(ByVal e As Forms.PaintEventArgs)
        MyBase.OnPaint(e)   ' Call UserControl's OnPaint() first then overlay cross section graphics

        If (mFlume IsNot Nothing) Then ' can't paint cross section until Flume data is available
            Try ' Catch, but ignore, exceptions during UI updating
                Me.DrawCrossSection(e.Graphics) ' Draw cross section graphics first
                Me.PositionControls()           ' Controls positioned relative to cross section graphics
                Me.DrawExtras(e.Graphics)       ' Extras drawn relative graphics and control positions
            Catch ex As Exception
                Debug.Assert(False, ex.Message)
            End Try
        End If
    End Sub

#End Region

End Class
