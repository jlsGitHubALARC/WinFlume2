
'*************************************************************************************************************
' Class ControlSectionControl - UserControl for displaying & editing the Control Section
'*************************************************************************************************************
Imports System.Windows
Imports WinFlume.WinFlumeSectionType
Imports Flume.Globals
Imports Flume

Public Class ControlSectionControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mApproachChannel As Flume.SectionType = Nothing
    Private mControlSection As Flume.SectionType = Nothing
    '
    ' Cross section controls
    '
    Private stCtrl As SimpleTrapezoidControl = Nothing
    Private reCtrl As RectangularControl = Nothing
    Private vsCtrl As VShapedControl = Nothing
    Private ciCtrl As CircleControl = Nothing
    Private usCtrl As UShapedControl = Nothing
    Private paCtrl As ParabolaControl = Nothing
    Private ctCtrl As ComplexTrapezoidControl = Nothing

    Private sincCtrl As SillInCircleControl = Nothing
    Private tincCtrl As TrapezoidInCircleControl = Nothing
    Private sinpCtrl As SillInParabolaControl = Nothing
    Private tinpCtrl As TrapezoidInParabolaControl = Nothing
    Private sinuCtrl As SillInUShapedControl = Nothing
    Private tinuCtrl As TrapezoidInUShapedControl = Nothing
    Private vinrCtrl As VinRectangleControl = Nothing

    Private sintCtrl As SillInTrapezoidControl = Nothing
    Private tintCtrl As TrapezoidInTrapezoidControl = Nothing
    Private sinrCtrl As SillInRectangleControl = Nothing
    Private rinrCtrl As RectangleInRectangleControl = Nothing
    Private sinvCtrl As SillInVShapedControl = Nothing
    Private tinvCtrl As TrapezoidInVShapedControl = Nothing
    Private cincCtrl As CircleInCircleControl = Nothing
    Private uinuCtrl As UShapedInUShapedControl = Nothing
    Private pinpCtrl As ParabolaInParabolaControl = Nothing
    Private vinvCtrl As VShapedInVShapedControl = Nothing
    Private tinrCtrl As TrapezoidInRectangleControl = Nothing

    Public Function GetCrossSectionControl(ByVal SectionIdx As Integer) As CrossSectionControl
        Dim crossSectionCtrl As CrossSectionControl = Nothing
        Select Case SectionIdx
            Case shSimpleTrapezoid                          ' 1
                crossSectionCtrl = stCtrl
            Case shRectangular                              ' 2
                crossSectionCtrl = reCtrl
            Case shVShaped                                  ' 3
                crossSectionCtrl = vsCtrl
            Case shCircle                                   ' 4
                crossSectionCtrl = ciCtrl
            Case shUShaped                                  ' 5
                crossSectionCtrl = usCtrl
            Case shParabola                                 ' 6
                crossSectionCtrl = paCtrl
            Case shComplexTrapezoid                         ' 7
                crossSectionCtrl = ctCtrl
            Case shTrapezoidInCircle                        ' 8
                crossSectionCtrl = tincCtrl
            Case shTrapezoidInUShaped                       ' 9
                crossSectionCtrl = tinuCtrl
            Case shTrapezoidInParabola                      ' 10
                crossSectionCtrl = tinpCtrl
            Case shSillInCircle                             ' 11
                crossSectionCtrl = sincCtrl
            Case shSillInUShaped                            ' 12
                crossSectionCtrl = sinuCtrl
            Case shSillInParabola                           ' 13
                crossSectionCtrl = sinpCtrl
            Case shVInRectangle                             ' 14
                crossSectionCtrl = vinrCtrl
            Case shSillInTrapezoid                          ' 15
                crossSectionCtrl = sintCtrl
            Case shTrapezoidInTrapezoid                     ' 16
                crossSectionCtrl = tintCtrl
            Case shSillInRectangle                          ' 17
                crossSectionCtrl = sinrCtrl
            Case shRectangleInRectangle                     ' 18
                crossSectionCtrl = rinrCtrl
            Case shSillInVShaped                            ' 19
                crossSectionCtrl = sinvCtrl
            Case shTrapezoidInVShaped                       ' 20
                crossSectionCtrl = tinvCtrl
            Case shVShapedInVShaped                         ' 21
                crossSectionCtrl = vinvCtrl
            Case shCircleInCircle                           ' 22
                crossSectionCtrl = cincCtrl
            Case shUShapedInUShaped                         ' 23
                crossSectionCtrl = uinuCtrl
            Case shParabolaInParabola                       ' 24
                crossSectionCtrl = pinpCtrl
            Case shTrapezoidInRectangle                     ' 25
                crossSectionCtrl = tinrCtrl
            Case Else
                Debug.Assert(False)
        End Select
        Return crossSectionCtrl
    End Function

    Private sSimpleTrapezoid As String = SectionString(shSimpleTrapezoid)
    Private sRectangular As String = SectionString(shRectangular)
    Private sVShaped As String = SectionString(shVShaped)
    Private sCircle As String = SectionString(shCircle)
    Private sUShaped As String = SectionString(shUShaped)
    Private sParabola As String = SectionString(shParabola)
    Private sComplexTrapezoid As String = SectionString(shComplexTrapezoid)
    Private sTrapezoidInCircle As String = SectionString(shTrapezoidInCircle)
    Private sTrapezoidInUShaped As String = SectionString(shTrapezoidInUShaped)
    Private sTrapezoidInParabola As String = SectionString(shTrapezoidInParabola)
    Private sSillInCircle As String = SectionString(shSillInCircle)
    Private sSillInUShaped As String = SectionString(shSillInUShaped)
    Private sSillInParabola As String = SectionString(shSillInParabola)
    Private sVShapeInRectangle As String = SectionString(shVInRectangle)
    ' Added cross-section shapes for UI; minimal support in Flume.dll
    Private sSillInTrapezoid As String = SectionString(shSillInTrapezoid)
    Private sTrapezoidInTrapezoid As String = SectionString(shTrapezoidInTrapezoid)
    Private sSillInRectangle As String = SectionString(shSillInRectangle)
    Private sRectangleInRectangle As String = SectionString(shRectangleInRectangle)
    Private sSillInVShape As String = SectionString(shSillInVShaped)
    Private sTrapezoidInVShaped As String = SectionString(shTrapezoidInVShaped)
    Private sCircleInCircle As String = SectionString(shCircleInCircle)
    Private sParabolaInParabola As String = SectionString(shParabolaInParabola)
    Private sUShapedInUShaped As String = SectionString(shUShapedInUShaped)
    Private sVShapedInVShaped As String = SectionString(shVShapedInVShaped)
    Private sTrapezoidInRectangle As String = SectionString(shTrapezoidInRectangle)

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Control cross section
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                 ' Flume accessor9

        If (mFlume Is Nothing) Then
            Return
        End If

        If Not Me.Visible Then
            mControlSection = mFlume.Section(cControl)              ' Control Section data
            Return
        End If

        If ((mFlume IsNot Nothing) And (0 < Me.ControlCrossSection.Items.Count)) Then

            mControlSection = mFlume.Section(cControl)              ' Control Section data

            ' Update cross section selection to match Section data
            Dim crestType As Integer = mFlume.CrestType
            ControlCrossSection_Load(crestType)

            Select Case (crestType)
                Case StationaryCrest
                    ' Match Control to Approach available for Stationary Crest
                    Me.MatchControlToApproachCheckBox.Show()
                    Me.MatchControlToApproachCheckBox.Enabled = True
                    Me.MatchControlToApproachCheckBox.Value = WinFlumeForm.ControlMatchedToApproach

                    For idx As Integer = 0 To Me.ControlCrossSection.Items.Count - 1
                        Dim itemText As String = DirectCast(Me.ControlCrossSection.Items(idx), String)
                        If (itemText = SectionString(mControlSection.Shape)) Then
                            Me.ControlCrossSection.Value = idx
                            Exit Select
                        End If
                    Next
                    Me.ControlCrossSection.Value = 0
                Case MovableCrest
                    ' No Match Control to Approach for Movable Crest
                    Me.MatchControlToApproachCheckBox.Hide()
                    Me.MatchControlToApproachCheckBox.Enabled = False

                    If (mControlSection.Shape = shVInRectangle) Then
                        Me.ControlCrossSection.Value = 1
                    Else
                        Me.ControlCrossSection.Value = 0
                        mControlSection.Shape = shRectangular
                    End If
                Case Else
                    Debug.Assert(False, "Invalid Crest Type")
            End Select

            ' Update cross section control to match Section data
            Select Case (mControlSection.Shape)

                Case shSimpleTrapezoid                                  ' 1

                    If (stCtrl Is Nothing) Then
                        stCtrl = New SimpleTrapezoidControl(cControl)
                    End If

                    UpdateCrossSection(stCtrl)
                    stCtrl.UpdateUI(mWinFlumeForm)

                Case shRectangular                                      ' 2

                    If (reCtrl Is Nothing) Then
                        reCtrl = New RectangularControl(cControl)
                    End If

                    UpdateCrossSection(reCtrl)
                    reCtrl.UpdateUI(mWinFlumeForm)

                Case shVShaped                                          ' 3

                    If (vsCtrl Is Nothing) Then
                        vsCtrl = New VShapedControl(cControl)
                    End If

                    UpdateCrossSection(vsCtrl)
                    vsCtrl.UpdateUI(mWinFlumeForm)

                Case shCircle                                           ' 4

                    If (ciCtrl Is Nothing) Then
                        ciCtrl = New CircleControl(cControl)
                    End If

                    UpdateCrossSection(ciCtrl)
                    ciCtrl.UpdateUI(mWinFlumeForm)

                Case shUShaped                                          ' 5

                    If (usCtrl Is Nothing) Then
                        usCtrl = New UShapedControl(cControl)
                    End If

                    UpdateCrossSection(usCtrl)
                    usCtrl.UpdateUI(mWinFlumeForm)

                Case shParabola                                         ' 6

                    If (paCtrl Is Nothing) Then
                        paCtrl = New ParabolaControl(cControl)
                    End If

                    UpdateCrossSection(paCtrl)
                    paCtrl.UpdateUI(mWinFlumeForm)

                Case shComplexTrapezoid                                 ' 7

                    If (ctCtrl Is Nothing) Then
                        ctCtrl = New ComplexTrapezoidControl(cControl)
                    End If

                    UpdateCrossSection(ctCtrl)
                    ctCtrl.UpdateUI(mWinFlumeForm)

                Case shTrapezoidInCircle                                ' 8

                    If (tincCtrl Is Nothing) Then
                        tincCtrl = New TrapezoidInCircleControl(cControl)
                    End If

                    UpdateCrossSection(tincCtrl)
                    tincCtrl.UpdateUI(mWinFlumeForm)

                Case shTrapezoidInUShaped                               ' 9

                    If (tinuCtrl Is Nothing) Then
                        tinuCtrl = New TrapezoidInUShapedControl(cControl)
                    End If

                    UpdateCrossSection(tinuCtrl)
                    tinuCtrl.UpdateUI(mWinFlumeForm)

                Case shTrapezoidInParabola                              ' 10

                    If (tinpCtrl Is Nothing) Then
                        tinpCtrl = New TrapezoidInParabolaControl(cControl)
                    End If

                    UpdateCrossSection(tinpCtrl)
                    tinpCtrl.UpdateUI(mWinFlumeForm)

                Case shSillInCircle                                     ' 11

                    If (sincCtrl Is Nothing) Then
                        sincCtrl = New SillInCircleControl(cControl)
                    End If

                    UpdateCrossSection(sincCtrl)
                    sincCtrl.UpdateUI(mWinFlumeForm)

                Case shSillInUShaped                                    ' 12

                    If (sinuCtrl Is Nothing) Then
                        sinuCtrl = New SillInUShapedControl(cControl)
                    End If

                    UpdateCrossSection(sinuCtrl)
                    sinuCtrl.UpdateUI(mWinFlumeForm)

                Case shSillInParabola                                   ' 13

                    If (sinpCtrl Is Nothing) Then
                        sinpCtrl = New SillInParabolaControl(cControl)
                    End If

                    UpdateCrossSection(sinpCtrl)
                    sinpCtrl.UpdateUI(mWinFlumeForm)

                Case shVInRectangle                                     ' 14

                    If (vinrCtrl Is Nothing) Then
                        vinrCtrl = New VinRectangleControl(cControl)
                    End If

                    UpdateCrossSection(vinrCtrl)
                    vinrCtrl.UpdateUI(mWinFlumeForm)

                Case shSillInTrapezoid                                  ' 15

                    If (sintCtrl Is Nothing) Then
                        sintCtrl = New SillInTrapezoidControl(cControl)
                    End If

                    UpdateCrossSection(sintCtrl)
                    sintCtrl.UpdateUI(mWinFlumeForm)

                Case shTrapezoidInTrapezoid                             ' 16

                    If (tintCtrl Is Nothing) Then
                        tintCtrl = New TrapezoidInTrapezoidControl(cControl)
                    End If

                    UpdateCrossSection(tintCtrl)
                    tintCtrl.UpdateUI(mWinFlumeForm)

                Case shSillInRectangle                                  ' 17

                    If (sinrCtrl Is Nothing) Then
                        sinrCtrl = New SillInRectangleControl(cControl)
                    End If

                    UpdateCrossSection(sinrCtrl)
                    sinrCtrl.UpdateUI(mWinFlumeForm)

                Case shRectangleInRectangle                             ' 18

                    If (rinrCtrl Is Nothing) Then
                        rinrCtrl = New RectangleInRectangleControl(cControl)
                    End If

                    UpdateCrossSection(rinrCtrl)
                    rinrCtrl.UpdateUI(mWinFlumeForm)

                Case shSillInVShaped                                    ' 19

                    If (sinvCtrl Is Nothing) Then
                        sinvCtrl = New SillInVShapedControl(cControl)
                    End If

                    UpdateCrossSection(sinvCtrl)
                    sinvCtrl.UpdateUI(mWinFlumeForm)

                Case shTrapezoidInVShaped                               ' 20

                    If (tinvCtrl Is Nothing) Then
                        tinvCtrl = New TrapezoidInVShapedControl(cControl)
                    End If

                    UpdateCrossSection(tinvCtrl)
                    tinvCtrl.UpdateUI(mWinFlumeForm)

                Case shVShapedInVShaped                                 ' 21

                    If (vinvCtrl Is Nothing) Then
                        vinvCtrl = New VShapedInVShapedControl(cControl)
                    End If

                    UpdateCrossSection(vinvCtrl)
                    vinvCtrl.UpdateUI(mWinFlumeForm)

                Case shCircleInCircle                                   ' 22

                    If (cincCtrl Is Nothing) Then
                        cincCtrl = New CircleInCircleControl(cControl)
                    End If

                    UpdateCrossSection(cincCtrl)
                    cincCtrl.UpdateUI(mWinFlumeForm)

                Case shUShapedInUShaped                                 ' 23

                    If (uinuCtrl Is Nothing) Then
                        uinuCtrl = New UShapedInUShapedControl(cControl)
                    End If

                    UpdateCrossSection(uinuCtrl)
                    uinuCtrl.UpdateUI(mWinFlumeForm)

                Case shParabolaInParabola                               ' 24

                    If (pinpCtrl Is Nothing) Then
                        pinpCtrl = New ParabolaInParabolaControl(cControl)
                    End If

                    UpdateCrossSection(pinpCtrl)
                    pinpCtrl.UpdateUI(mWinFlumeForm)

                Case shTrapezoidInRectangle                             ' 25

                    If (tinrCtrl Is Nothing) Then
                        tinrCtrl = New TrapezoidInRectangleControl(cControl)
                    End If

                    UpdateCrossSection(tinrCtrl)
                    tinrCtrl.UpdateUI(mWinFlumeForm)

                Case Else
                    Debug.Assert(False, "Invalid cross section shape")
            End Select

        End If

    End Sub

    '*********************************************************************************************************
    ' Sub UpdateCrossSection()  - ensure cross section controls are being displayed
    '
    ' Input(s):         Ctrl    - control that should be displayed
    '*********************************************************************************************************
    Protected Sub UpdateCrossSection(ByVal Ctrl As CrossSectionControl)

        If (mFlume IsNot Nothing) Then
            If (0 = Me.CrossSectionPanel.Controls.Count) Then ' No controls are displayed
                Me.CrossSectionPanel.Controls.Add(Ctrl) ' Add requested one
            ElseIf (Me.CrossSectionPanel.Controls(0) IsNot Ctrl) Then ' Requested control is not displayed
                Me.CrossSectionPanel.Controls.Clear()   ' Clear current control(s)
                Me.CrossSectionPanel.Controls.Add(Ctrl) ' Add requested one
            End If

            ' Add back the 'Match Control to Approach' controls; Stationary Crest only
            If (mFlume.CrestType = StationaryCrest) Then
                Me.CrossSectionPanel.Controls.Add(Me.MatchControlToApproachCheckBox)
                Me.MatchControlToApproachCheckBox.BringToFront()
                Me.MatchControlToApproachCheckBox.Show()
            End If

            ' Set the behavior of the Cross-Section Control for the Control Section
            mControlSection = mFlume.Section(cControl)
            If (mControlSection.GetType Is GetType(WinFlumeSectionType)) Then
                Dim WinFlumeSection As WinFlumeSectionType = DirectCast(mControlSection, WinFlumeSectionType)
                Dim matchConstraints As Integer = WinFlumeSection.MatchConstraints

                If (BitSet(matchConstraints, MatchConstraint.OuterShapeMatchesApproachChannel) _
                 Or BitSet(matchConstraints, MatchConstraint.ShapeMatchesApproachChannel)) Then
                    Ctrl.OuterIsReadOnly = True
                Else
                    Ctrl.OuterIsReadOnly = False
                End If
            Else
                Ctrl.OuterIsReadOnly = False
            End If

            Ctrl.Dock = DockStyle.Fill
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub PositionControls() - position contained Controls
    '*********************************************************************************************************
    Protected Overridable Sub PositionControls()

        ' Cross Section selection
        Dim loc As Point = Me.ControlCrossSection.Location
        loc.X = Me.Width - Me.ControlCrossSection.Width
        Me.ControlCrossSection.Location = loc

        loc = Me.MatchControlToApproachCheckBox.Location
        loc.X = Me.Width - Me.MatchControlToApproachCheckBox.Width - Me.Margin.Horizontal
        loc.Y = Me.Margin.Vertical
        Me.MatchControlToApproachCheckBox.Location = loc

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Sub OnPaint() - ensure contained Controls are correctly positioned when Control is re-painted
    '*********************************************************************************************************
    Protected Overrides Sub OnPaint(ByVal e As Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.PositionControls()
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Sub ControlChannelControl_Load() - handle Load event to initialize contained Controls
    '*********************************************************************************************************
    Private Sub ControlChannelControl_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Load

        ' Default to NO Control to Approach matching
        Me.MatchControlToApproachCheckBox.Value = False
        Me.MatchControlToApproachCheckBox.HandleCheckedChanged = False

        ' Load cross section selections
        ControlCrossSection_Load(StationaryCrest)

        ' Default to Simple Trapezoid cross section
        stCtrl = New SimpleTrapezoidControl(cControl)
        UpdateCrossSection(stCtrl)
        stCtrl.UpdateUI(mWinFlumeForm)

    End Sub

    Private Sub ControlCrossSection_Load(ByVal CrestType As Integer)
        ' Load cross section selections
        Me.ControlCrossSection.Items.Clear()

        If (mFlume Is Nothing) Then
            mFlume = WinFlumeForm.Flume
            If (mFlume Is Nothing) Then
                Return
            End If
        End If

        Select Case (CrestType)
            Case StationaryCrest
                If (WinFlumeForm.ControlMatchedToApproach) Then
                    mApproachChannel = mFlume.Section(cApproach)

                    For Each MatchType As WinFlumeSectionType In WinFlumeForm.ApproachControlMatchTypes
                        With MatchType
                            If (.ApproachShape = mApproachChannel.Shape) Then
                                Me.ControlCrossSection.Items.Add(SectionString(.ControlShape))
                            End If
                        End With
                    Next

                    'mControlSection = mFlume.Section(cControl)
                    'Dim WinFlumeSection As WinFlumeSectionType = DirectCast(mControlSection, WinFlumeSectionType)
                    'Me.ControlCrossSection.Items.Add(SectionString(WinFlumeSection.Shape))
                Else
                    Me.ControlCrossSection.Items.Add(SectionString(shSimpleTrapezoid))
                    Me.ControlCrossSection.Items.Add(SectionString(shRectangular))
                    Me.ControlCrossSection.Items.Add(SectionString(shVShaped))
                    Me.ControlCrossSection.Items.Add(SectionString(shCircle))
                    Me.ControlCrossSection.Items.Add(SectionString(shUShaped))
                    Me.ControlCrossSection.Items.Add(SectionString(shParabola))
                    Me.ControlCrossSection.Items.Add(SectionString(shComplexTrapezoid))
                    Me.ControlCrossSection.Items.Add(SectionString(shTrapezoidInCircle))
                    Me.ControlCrossSection.Items.Add(SectionString(shTrapezoidInUShaped))
                    Me.ControlCrossSection.Items.Add(SectionString(shTrapezoidInParabola))
                    Me.ControlCrossSection.Items.Add(SectionString(shSillInCircle))
                    Me.ControlCrossSection.Items.Add(SectionString(shSillInUShaped))
                    Me.ControlCrossSection.Items.Add(SectionString(shSillInParabola))
                    Me.ControlCrossSection.Items.Add(SectionString(shVInRectangle))
                End If
            Case MovableCrest
                Me.ControlCrossSection.Items.Add(SectionString(shRectangular))
                Me.ControlCrossSection.Items.Add(SectionString(shVInRectangle))
            Case Else
                Debug.Assert(False, "Invalid Crest Type")
        End Select
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub ControlCrossSection_ValueChanged() _
        Handles ControlCrossSection.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim itemIdx As Integer = Me.ControlCrossSection.Value
            Dim itemText As String = DirectCast(Me.ControlCrossSection.Items(itemIdx), String)
            Dim ChannelDepth = mFlume.Section(cApproach).TopWidth(mFlume.ChannelDepth, False)

            mControlSection = mFlume.Section(cControl)                     ' Section data
            mApproachChannel = mFlume.Section(cApproach)

            Dim CW As Single = mApproachChannel.TopWidth(mControlSection.D1, False)
            'Dim TW As Single = mApproachChannel.TopWidth(mFlume.SillHeight, False)
            Dim TW As Single = mApproachChannel.TopWidth(ChannelDepth, False)

            Dim crestType As Integer = mFlume.CrestType
            Select Case (crestType)
                Case StationaryCrest
                    For sdx As Integer = 1 To SectionString.Length - 1
                        Dim sectionText As String = SectionString(sdx)
                        If (sectionText = itemText) Then
                            mControlSection.Shape = sdx

                            Dim diam As Single = mControlSection.DiameterFocalD

                            Dim flumeSectionType As Flume.SectionType = DirectCast(mControlSection, Flume.SectionType)
                            flumeSectionType.Shape = sdx

                            ' Set bottom width so trapezoid-in-xyz is clearly visible
                            Select Case mControlSection.Shape
                                Case shTrapezoidInVShaped, shTrapezoidInParabola, shTrapezoidInRectangle
                                    mControlSection.BottomWidth = CW / 2
                                Case shTrapezoidInUShaped, shTrapezoidInCircle
                                    mControlSection.BottomWidth = diam / 2
                                Case shCircle, shParabola, shSillInCircle, shSillInParabola, shSillInUShaped, shUShaped
                                    mControlSection.BottomWidth = diam
                            End Select

                            If (mControlSection.GetType Is GetType(WinFlumeSectionType)) Then
                                Dim winFlumeSection As WinFlumeSectionType = DirectCast(mControlSection, WinFlumeSectionType)

                                mFlume.MatchedControlShape = mControlSection.Shape

                                For Each MatchType As WinFlumeSectionType In WinFlumeForm.ApproachControlMatchTypes
                                    With MatchType
                                        If (.ApproachShape = mApproachChannel.Shape) Then
                                            If (.ControlShape = mControlSection.Shape) Then
                                                winFlumeSection.MatchConstraints = .MatchConstraints

                                                ' Set cross-section parameters to defaults (i.e. overwrite any user edits)
                                                Select Case mControlSection.Shape
                                                    Case shTrapezoidInCircle, shTrapezoidInUShaped, shRectangleInRectangle
                                                        winFlumeSection.BottomWidth = mApproachChannel.BottomWidth / 2
                                                    Case shTrapezoidInVShaped, shTrapezoidInRectangle
                                                        winFlumeSection.BottomWidth = TW / 2
                                                    Case shSillInTrapezoid
                                                        winFlumeSection.BottomWidth = CW
                                                    Case shTrapezoidInParabola
                                                        winFlumeSection.BottomWidth = CW / 2
                                                    Case Else
                                                        winFlumeSection.BottomWidth = mApproachChannel.BottomWidth
                                                End Select

                                                winFlumeSection.Z1 = mApproachChannel.Z1
                                                winFlumeSection.DiameterFocalD = mApproachChannel.DiameterFocalD

                                                ' Set D1 to Sill Height, if required
                                                If (BitSet(.MatchConstraints, MatchConstraint.InnerSillHeightMatchesProfileSillHeight)) Then
                                                    winFlumeSection.D1 = mFlume.SillHeight
                                                End If

                                                ' Set methods of contraction for selecteed cross-section
                                                winFlumeSection.MethodsOfContraction = .MethodsOfContraction

                                                If (BitSet(.MethodsOfContraction, MethodOfContraction.RaiseLowerSillHeight)) Then
                                                    mFlume.ContractionAdjustment = RaiseSillHeight
                                                ElseIf (BitSet(.MethodsOfContraction, MethodOfContraction.RaiseLowerEntireSection)) Then
                                                    mFlume.ContractionAdjustment = RaiseLowerEntireSection
                                                ElseIf (BitSet(.MethodsOfContraction, MethodOfContraction.RaiseLowerInnerSection)) Then
                                                    mFlume.ContractionAdjustment = RaiseLowerInnerSection
                                                ElseIf (BitSet(.MethodsOfContraction, MethodOfContraction.VarySideContraction)) Then
                                                    mFlume.ContractionAdjustment = VarySideContraction
                                                End If

                                                Exit For
                                            End If
                                        End If
                                    End With
                                Next MatchType

                            End If ' (mControlSection.GetType Is GetType(WinFlumeSectionType))

                            Exit Select
                        End If ' (sectionText = itemText)
                    Next sdx
                    Debug.Assert(False)
                Case MovableCrest
                    If (itemIdx = 0) Then
                        mControlSection.Shape = shRectangular
                    Else
                        mControlSection.Shape = shVInRectangle
                    End If
                Case Else
                    Debug.Assert(False, "Invalid Crest Type")
            End Select

            mFlume.Section(cControl) = mControlSection

            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub ControlChannelControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub ControlChannelControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize
        Dim ctrlSize As Size = New Size(Me.Width, Me.Height - Me.CrossSectionPanel.Location.Y)
        Me.CrossSectionPanel.Size = ctrlSize
    End Sub

    '*********************************************************************************************************
    ' Handler for 'Match Control to Approach' button
    '
    ' Note - MatchControlToApproachCheckBox is toggling so if it is not checked, it is being checked
    '*********************************************************************************************************
    Private Sub MatchControlToApproachCheckBox_MouseDown(sender As Object, e As EventArgs) _
        Handles MatchControlToApproachCheckBox.MouseDown

        If (Me.MatchControlToApproachCheckBox.Value = True) Then ' CheckBox is being unchecked

            ' Debug.Assert(mFlume.Section(cControl).GetType Is GetType(WinFlumeSectionType))

            ' Set current Flume object as Undo point; new Flume object must be created for new data
            MatchControlToApproachCheckBox.AddUndoItem(mFlume)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Instantiate new Flume object
            mFlume = WinFlumeForm.NewFlumeType(mFlume)
            mFlume.ControlMatchedToApproach = False
            mFlume.MatchedControlShape = 0

            ' Demote WinFlumeSectionType to Flume.SectionType
            mFlume.Section(cControl) = New Flume.SectionType(mFlume.Section(cControl))

            ' Generate 'non-matched' equivalent Control cross-section
            With mFlume.Section(cControl)
                Select Case (.Shape)
                    Case shSillInTrapezoid, shSillInVShaped
                        .BottomWidth = .TopWidth(0, False)
                        .Shape = shSimpleTrapezoid
                    Case shTrapezoidInTrapezoid, shTrapezoidInVShaped
                        .Shape = shSimpleTrapezoid
                    Case shSillInRectangle, shRectangleInRectangle
                        .Shape = shRectangular
                    Case shCircleInCircle
                        .Shape = shCircle
                    Case shParabolaInParabola
                        .Shape = shParabola
                    Case shUShapedInUShaped
                        .Shape = shUShaped
                    Case shVShapedInVShaped
                        .Shape = shVShaped
                    Case shTrapezoidInRectangle
                        .Shape = shComplexTrapezoid
                End Select
            End With

            WinFlumeForm.SetFlume(mFlume)
            mWinFlumeForm.RaiseFlumeDataChanged()

        Else ' Match is not checked; show Match Control to Approach dialog

            Dim db As MatchControlDialog = New MatchControlDialog(mFlume, WinFlumeForm.ApproachControlMatchTypes)
            Dim result As DialogResult = db.ShowDialog
            If (result = DialogResult.OK) Then
                Dim approachShape As Integer = db.ApproachChannelShape
                Dim controlShape As Integer = db.ControlSectionShape
                Dim controlSection As WinFlumeSectionType = db.ControlSectionType
                Dim constraints As Integer = controlSection.MatchConstraints
                Dim methods As Integer = controlSection.MethodsOfContraction

                Debug.Assert(mFlume.Section(cControl).GetType Is GetType(Flume.SectionType))

                ' Set current Flume object as Undo point; new Flume object must be created for new data
                MatchControlToApproachCheckBox.AddUndoItem(mFlume)
                WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

                ' Create new Flume object
                mFlume = WinFlumeForm.NewFlumeType(mFlume)
                mFlume.ControlMatchedToApproach = True
                mFlume.MatchedControlShape = controlShape

                ' First, load Flume.SectionType with WinFlumeSectionType
                mFlume.Section(cControl) = controlSection

                ' Then set constraints & contraction methods
                If (BitSet(constraints, MatchConstraint.InnerSillHeightMatchesProfileSillHeight)) Then
                    If (mFlume.SillHeight <= 0) Then
                        mFlume.SillHeight = mFlume.ChannelDepth / 4
                    End If
                End If

                If (BitSet(methods, MethodOfContraction.RaiseLowerSillHeight)) Then
                    mFlume.ContractionAdjustment = RaiseSillHeight
                ElseIf (BitSet(methods, MethodOfContraction.RaiseLowerEntireSection)) Then
                    mFlume.ContractionAdjustment = RaiseLowerEntireSection
                ElseIf (BitSet(methods, MethodOfContraction.RaiseLowerInnerSection)) Then
                    mFlume.ContractionAdjustment = RaiseLowerInnerSection
                ElseIf (BitSet(methods, MethodOfContraction.VarySideContraction)) Then
                    mFlume.ContractionAdjustment = VarySideContraction
                End If

                ' Make new Flume object known to rest of WinFlume
                WinFlumeForm.SetFlume(mFlume)
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If

    End Sub

    Private Sub MatchControlToApproachCheckBox_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles MatchControlToApproachCheckBox.UndoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (UndoValue.GetType Is GetType(FlumeType)) Then
                ' Set Flume for Redo point
                MatchControlToApproachCheckBox.AddRedoItem(mFlume)
                ' Restore Flume object
                mFlume = DirectCast(UndoValue, FlumeType)
                WinFlumeForm.SetFlume(mFlume)
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Undo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub MatchControlToApproachCheckBox_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles MatchControlToApproachCheckBox.RedoButtonEvent
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If (RedoValue.GetType Is GetType(FlumeType)) Then
                ' Set Flume for Undo point
                MatchControlToApproachCheckBox.AddUndoItem(mFlume)
                ' Restore Flume table
                mFlume = DirectCast(RedoValue, FlumeType)
                WinFlumeForm.SetFlume(mFlume)
                mWinFlumeForm.RaiseFlumeDataChanged()
            Else
                Debug.Assert(False, "Redo - Invalid value type")
            End If
        End If
    End Sub

    Private Sub ControlSectionControl_VisibleChanged(sender As Object, e As EventArgs) _
        Handles MyBase.VisibleChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
