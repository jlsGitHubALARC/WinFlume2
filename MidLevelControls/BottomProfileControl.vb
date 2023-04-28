
'*************************************************************************************************************
' Class BottomProfileControl  - UserControl for displaying & editing the flume's bottom profile
'*************************************************************************************************************
Imports System.Windows

Imports Flume
Imports Flume.Globals
Imports Flume.FlumeType

Imports WinFlume.WinFlumeSectionType

Public Class BottomProfileControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Protected mFlume As Flume.FlumeType = Nothing
    Protected mFlumeAPI As FlumeAPI = Nothing
    Protected mSection As Flume.SectionType = Nothing
    '
    ' Drawing tools
    '
    Protected mBlackPen1 As Drawing.Pen = BlackPen1()
    Protected mBlackPen2 As Drawing.Pen = BlackPen2()
    Protected mBluePen1 As Drawing.Pen = BluePen1()
    Protected mBluePen2 As Drawing.Pen = BluePen2()
    Protected mGrayPen1 As Drawing.Pen = DarkGrayPen1()
    Protected mGrayPen2 As Drawing.Pen = DarkGrayPen2()
    Protected mBlackDashedPen As Drawing.Pen = BlackDashedPen1()
    Protected mBlackBrush As Brush = BlackSolidBrush()
    '
    ' Bottom Profile data
    '
    Protected mXmax As Single = 0

    Private Class AdjustLengthsUndoRedo                         ' Adjust Lengths Undo/Redo data
        Public GageDistance As Single   ' Approach Length
        Public ConvergeLength As Single
        Public ControlLength As Single
        Public RadiusMovable As Single
        Public Sub New(ByVal GageDist As Single, ByVal ConvLen As Single,
                       ByVal CtrlLen As Single, ByVal RadMov As Single)
            Me.GageDistance = GageDist
            Me.ConvergeLength = ConvLen
            Me.ControlLength = CtrlLen
            Me.RadiusMovable = RadMov
        End Sub
    End Class

#End Region

#Region " UI Methods "

#Region " Update UI "

    '*********************************************************************************************************
    ' Sub UpdateUI() - update Bottom Profile UI
    '
    ' Input(s):     WinFlume    - reference to WinFlume's main window
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume                ' Access to top level methods / events
        Me.UpdateUI()
    End Sub

    Protected Sub UpdateUI()
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data

            mFlumeAPI = WinFlumeForm.GetFlumeAPI
            If (mFlumeAPI Is Nothing) Then
                Return
            End If

            Me.Refresh()                        ' Causes OnPaint() to be called
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub UpdateControlValues() - update contained Controls' values
    '*********************************************************************************************************
    Protected Sub UpdateControlValues()

        If ((mWinFlumeForm Is Nothing) Or (mFlume Is Nothing)) Then
            Return
        End If

        ' Update Flume description
        Me.FlumeDescription.Label = My.Resources.FlumeDescription
        Me.FlumeDescription.Value = mFlume.Description.Trim

        If (Me.FlumeDescription.Value = My.Resources.NewFlumeDescription) Then
            Me.FlumeDescription.Value = mFlume.Description.Trim & " - " & My.Resources.EnterFlumeDescription & " Here"
            Me.FlumeDescription.BackColor = Color.FromArgb(255, 255, 255, 128) ' Medium Yellow
        Else
            Me.FlumeDescription.BackColor = SystemColors.ControlLightLight
        End If

        ' Update values displayed by each contained control
        Me.ChannelDepthSingle.Label = Me.ChannelDepthLabel.Text
        Me.ChannelDepthSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.ChannelDepth
        Me.ChannelDepthSingle.SiValue = mFlume.ChannelDepth
        Me.ChannelDepthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

        Me.SillHeightSingle.Label = Me.SillHeightLabel.Text
        Me.SillHeightSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.SillHeight
        Me.SillHeightSingle.SiValue = mFlume.SillHeight
        Me.SillHeightSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

        Me.GageDistanceSingle.Label = Me.GageDistanceLabel.Text
        Me.GageDistanceSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.GageDistance
        Me.GageDistanceSingle.SiValue = mFlume.GageDistance
        Me.GageDistanceSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

        Me.ConvergeLengthSingle.Label = Me.ConvergeLengthLabel.Text
        Me.ConvergeLengthSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.ConvergeLength
        Me.ConvergeLengthSingle.SiValue = mFlume.ConvergeLength
        Me.ConvergeLengthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

        Me.ControlLengthSingle.Label = Me.ControlLengthLabel.Text
        Me.ControlLengthSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.ControlLength
        Me.ControlLengthSingle.SiValue = mFlume.ControlLength
        Me.ControlLengthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

        Me.ExpansionLengthSingle.Label = Me.ExpansionLengthLabel.Text
        Me.ExpansionLengthSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.ExpansionLength
        Me.ExpansionLengthSingle.SiValue = mFlume.ExpansionLength
        Me.ExpansionLengthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

        Me.ExpansionSlopeSingle.Label = Me.ExpansionSlopeLabel.Text
        Me.ExpansionSlopeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.ExpansionSlopeZ
        Me.ExpansionSlopeSingle.SiValue = mFlume.ExpansionSlopeZ

        Me.BedDropSingle.Label = Me.BedDropLabel.Text
        Me.BedDropSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.BedDrop
        Me.BedDropSingle.SiValue = mFlume.BedDrop
        Me.BedDropSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

        Me.MaxWspCheckBox.Value = WinFlumeForm.ShowMaxWSP
        Me.MinWspCheckBox.Value = WinFlumeForm.ShowMinWSP

        Me.AbruptExpansionButton.Label = My.Resources.ExpansionRampStyle
        Me.AbruptExpansionButton.RbValue = cNoRamp
        Me.AbruptExpansionButton.UiValue = mFlume.ExpansionRampStyle

        Me.GradualExpansionButton.Label = My.Resources.ExpansionRampStyle
        Me.GradualExpansionButton.RbValue = cFullRamp
        Me.GradualExpansionButton.UiValue = mFlume.ExpansionRampStyle

        Me.TruncatedRampButton.Label = My.Resources.ExpansionRampStyle
        Me.TruncatedRampButton.RbValue = cTruncatedRamp
        Me.TruncatedRampButton.UiValue = mFlume.ExpansionRampStyle

        Me.OperatingDepthSingle.Label = Me.OperatingDepthLabel.Text
        Me.OperatingDepthSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.OperatingDepth
        Me.OperatingDepthSingle.SiValue = mFlume.OperatingDepth
        Me.OperatingDepthSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

        Me.RadiusSingle.Label = Me.RadiusLabel.Text
        Me.RadiusSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.RadiusMovable
        Me.RadiusSingle.SiValue = mFlume.RadiusMovable
        Me.RadiusSingle.SiUnits = WinFlumeForm.SiLengthUnitsText

    End Sub

    Public Sub DrawBottomProfile(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics)
        Dim crestType As Integer = mFlume.CrestType
        Select Case (crestType)
            Case StationaryCrest
                DrawStationaryBottomProfile(ViewPort, eGraphics)
            Case MovableCrest
                DrawMovableBottomProfile(ViewPort, eGraphics)
            Case Else
                Debug.Assert(False, "Invalid Crest Type")
        End Select
    End Sub

    '*********************************************************************************************************
    ' Sub UpdateBottomProfile() - draw bottom profile graphics and re-position controls
    '
    ' Input(s):     eGraphics   - Graphics object to use for drawing
    '*********************************************************************************************************
    Protected Sub UpdateBottomProfile(ByVal eGraphics As System.Drawing.Graphics)

        If ((mWinFlumeForm Is Nothing) Or (mFlume Is Nothing)) Then
            Return
        End If

        Dim crestType As Integer = mFlume.CrestType
        Select Case (crestType)
            Case StationaryCrest

                ' Hide controls for Movable Crest; show those for Stationary Crest
                Me.OperatingDepthLabel.Visible = False
                Me.OperatingDepthSingle.Visible = False
                Me.RadiusLabel.Visible = False
                Me.RadiusSingle.Visible = False

                Me.SillHeightLabel.Visible = True
                Me.SillHeightSingle.Visible = True
                Me.ConvergeLengthLabel.Visible = True
                Me.ConvergeLengthSingle.Visible = True

                Me.AbruptExpansionButton.Visible = True
                Me.GradualExpansionButton.Visible = True
                Me.TruncatedRampButton.Visible = True

                ' Update bottom profile graphics & associated control positions
                UpdateStationaryCrestProfile(eGraphics)

                ' Update MAX WSP control & graphic
                Dim errFound, ErrArray(MaxHydErrors) As Boolean
                Dim SMALLh1, Y1, Yc, Y2 As Single
                Dim CtrlLen As Single = mFlume.ControlLength

                Dim Qmax As Single = mFlume.QMax

                If ((Me.MaxWspCheckBox.Checked) And (0 < Qmax) And (0 < CtrlLen)) Then
                    mFlumeAPI.QtoH(Qmax, errFound, ErrArray, SMALLh1, 0, 0, 0, 0, 0, 0, 0, Y2, 0, 0, 0, Yc)

                    If (IsFatal(ErrArray)) Then ' Can't draw WSP
                        Me.MaxWspCheckBox.Enabled = False
                    Else
                        Me.MaxWspCheckBox.Enabled = True
                        Y1 = SMALLh1 + mFlume.SillHeight
                        DrawStationaryWSP(eGraphics, mBluePen2, Y1, Yc, Y2, Qmax)
                    End If
                End If

                ' Update MIN WSP control & graphic
                Dim Qmin As Single = mFlume.QMin

                If ((Me.MinWspCheckBox.Checked) And (0 < Qmin) And (0 < CtrlLen)) Then
                    mFlumeAPI.QtoH(Qmin, errFound, ErrArray, SMALLh1, 0, 0, 0, 0, 0, 0, 0, Y2, 0, 0, 0, Yc)

                    If (IsFatal(ErrArray)) Then ' Can't draw WSP
                        Me.MinWspCheckBox.Enabled = False
                    Else
                        Me.MinWspCheckBox.Enabled = True
                        Y1 = SMALLh1 + mFlume.SillHeight
                        DrawStationaryWSP(eGraphics, mBluePen1, Y1, Yc, Y2, Qmin)
                    End If
                End If

            Case MovableCrest

                ' Hide controls for Stationary Crest; show those for Movable Crest
                Me.SillHeightLabel.Visible = False
                Me.SillHeightSingle.Visible = False
                Me.ConvergeLengthLabel.Visible = False
                Me.ConvergeLengthSingle.Visible = False

                Me.ExpansionLengthLabel.Visible = False
                Me.ExpansionLengthSingle.Visible = False
                Me.ExpansionSlopeLabel.Visible = False
                Me.ExpansionSlopeSingle.Visible = False

                Me.AbruptExpansionButton.Visible = False
                Me.GradualExpansionButton.Visible = False
                Me.TruncatedRampButton.Visible = False

                Me.OperatingDepthLabel.Visible = True
                Me.OperatingDepthSingle.Visible = True
                Me.RadiusLabel.Visible = True
                Me.RadiusSingle.Visible = True

                ' Update bottom profile graphics & associated control positions
                UpdateMovableCrestProfile(eGraphics)

                ' Update MAX WSP control & graphic
                Dim errFound, ErrArray(MaxHydErrors) As Boolean
                Dim SMALLh1, y1, Yc, Y2, YFlume As Single

                Dim Qmax As Single = mFlume.QMax

                If ((Me.MaxWspCheckBox.Checked) And (0 < Qmax)) Then
                    mFlumeAPI.QtoH(Qmax, errFound, ErrArray, SMALLh1, 0, 0, 0, 0, 0, 0, 0, Y2, 0, 0, 0, Yc)

                    If (IsFatal(ErrArray)) Then ' Can't draw WSP
                        Me.MaxWspCheckBox.Enabled = False
                    Else
                        Me.MaxWspCheckBox.Enabled = True
                        y1 = mFlume.OperatingDepth
                        YFlume = mFlume.OperatingDepth - SMALLh1
                        DrawMovableWSP(eGraphics, mBluePen2, mGrayPen2, YFlume, y1, Yc, Y2, Qmax)
                    End If
                End If

                ' Update MIN WSP control & graphic
                Dim Qmin As Single = mFlume.QMin

                If ((Me.MinWspCheckBox.Checked) And (0 < Qmin)) Then
                    mFlumeAPI.QtoH(Qmin, errFound, ErrArray, SMALLh1, 0, 0, 0, 0, 0, 0, 0, Y2, 0, 0, 0, Yc)

                    If (IsFatal(ErrArray)) Then ' Can't draw WSP
                        Me.MinWspCheckBox.Enabled = False
                    Else
                        Me.MinWspCheckBox.Enabled = True
                        y1 = mFlume.OperatingDepth
                        YFlume = mFlume.OperatingDepth - SMALLh1
                        DrawMovableWSP(eGraphics, mBluePen1, mGrayPen1, YFlume, y1, Yc, Y2, Qmin)
                    End If
                End If

            Case Else
                Debug.Assert(False, "Invalid Crest Type")
        End Select

    End Sub

    Protected Function MaxRightBoundary(ByVal Ctrl1 As Control, ByVal Ctrl2 As Control) As Integer
        Dim ctrl1Right As Integer = Ctrl1.Location.X + Ctrl1.Width
        Dim ctrl2Right As Integer = Ctrl2.Location.X + Ctrl2.Width
        MaxRightBoundary = Math.Max(ctrl1Right, ctrl2Right)
    End Function

#End Region

#Region " Stationary Crest "

    '*********************************************************************************************************
    ' Sub DrawStationaryBottomProfile() - draw the Stationary Bottom Profile in the specified ViewPort
    '
    ' Input(s):     ViewPort    - bounding area for drawing
    '               eGraphics   - GDI Graphics object for drawing
    '*********************************************************************************************************
    Public Sub DrawStationaryBottomProfile(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics)

        Try
            '
            ' Get the Flume dimensions
            '
            Dim ChannelDepth As Single = mFlume.ChannelDepth
            Dim BedDrop As Single = mFlume.BedDrop
            Dim FlumeHeight As Single = ChannelDepth + BedDrop
            Dim SillHeight As Single = mFlume.SillHeight

            Dim ApproachLength As Single = mFlume.GageDistance
            Dim ConvergeLength As Single = mFlume.ConvergeLength
            Dim ControlLength As Single = mFlume.ControlLength
            Dim ExpansionLength As Single = mFlume.ExpansionLength
            Dim FlumeLength As Single = ApproachLength + ConvergeLength + ControlLength + ExpansionLength

            Dim TailwaterLength As Single = FlumeLength / 4
            FlumeLength += TailwaterLength

            Dim xMarginLength As Single = FlumeLength / 10
            FlumeLength += xMarginLength
            '
            ' Define region where the bottom profile will be drawn
            '
            Dim xOffset As Single = ViewPort.X          ' Start with the input ViewPort
            Dim yOffset As Single = ViewPort.Y
            Dim vWidth As Single = ViewPort.Width
            Dim vHeight As Single = ViewPort.Height

            ' Make room on left for "Channel Depth" & "Sill Height"
            Dim CDlbl As String = Me.ChannelDepthLabel.BaseText
            Dim CDval As String = UnitsDialog.UiValueUnitsText(ChannelDepth, "m")
            Dim CDsiz As RectangleF = MeasureString(eGraphics, CDlbl, Me.Font)

            Dim SHlbl As String = Me.SillHeightLabel.BaseText
            Dim SHval As String = UnitsDialog.UiValueUnitsText(SillHeight, "m")
            Dim SHsiz As RectangleF = MeasureString(eGraphics, SHlbl, Me.Font)

            If (CDsiz.Width < SHsiz.Width) Then
                xOffset += CDsiz.Width
                vWidth -= CDsiz.Width
            Else
                xOffset += SHsiz.Width
                vWidth -= SHsiz.Width
            End If

            ' Make room on bottom for segment lengths
            vHeight -= 3 * CDsiz.Height

            Dim vertRatio As Single = vHeight / FlumeHeight
            Dim horzRatio As Single = vWidth / FlumeLength

            ' Maintain 1:1 aspect ratio
            If (vertRatio > horzRatio) Then
                vertRatio = horzRatio
            Else
                horzRatio = vertRatio
            End If

            ' Position profile at bottom of ViewPort
            yOffset += vHeight - vertRatio * FlumeHeight
            '
            ' For each flume profile section:
            '   1) Draw bottom profile segment
            '   2) Draw vertical boundary indicator
            '   3) Add label/length values
            '
            Dim p1x, p1y, p2x, p2y, p3x, p3y As Single  ' End points for DrawLine()
            Dim xLoc, yLoc As Integer                   ' Label location

            ' Left margin
            If (0 < xMarginLength) Then
                p1x = xOffset
                p1y = yOffset + vertRatio * ChannelDepth
                p2x = p1x + horzRatio * xMarginLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = ViewPort.Height - CDsiz.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)
            End If

            mXmax = p2x

            ' Gage
            Dim BPlbl As String = Me.GageLabel.BaseText
            Dim BPval As String = ""
            Dim BPsiz As RectangleF = MeasureString(eGraphics, BPlbl, Me.Font)

            If (0 < ChannelDepth) Then
                p1x = p2x - 4
                p1y = yOffset

                xLoc = CInt(p1x - BPsiz.Width / 2)
                yLoc = CInt(p1y - BPsiz.Height)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                yLoc -= CInt(BPsiz.Height)
                If (yLoc < 4) Then
                    yLoc = 4
                End If
                eGraphics.DrawString(CDlbl, Me.Font, mBlackBrush, 4, yLoc)
                yLoc += CInt(BPsiz.Height)
                eGraphics.DrawString(CDval, Me.Font, mBlackBrush, 4, yLoc)

                eGraphics.DrawLine(mBlackDashedPen, 4, p1y, p1x - BPsiz.Width / 2, p1y)

                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p1x, p2y)
                p1x = p2x + 4
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p1x, p2y)

                For gdx As Integer = 0 To 15
                    Dim y As Single = yOffset + (p2y - p1y) * gdx / 16
                    eGraphics.DrawLine(mBlackPen1, p2x - 4, y, p2x + 4, y)
                Next gdx
            End If

            ' Approach section
            If (0 < ApproachLength) Then
                BPlbl = Me.GageDistanceLabel.BaseText
                BPval = UnitsDialog.UiValueUnitsText(ApproachLength, "m")

                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ApproachLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = ViewPort.Height - CDsiz.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc = CInt(ViewPort.Height - BPsiz.Height - 3)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                BPsiz = MeasureString(eGraphics, BPval, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc -= CInt(BPsiz.Height) - 2
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)
            End If

            ' Converge section
            If (0 < ConvergeLength) Then
                Dim slope As Single = ConvergeLength / SillHeight
                BPval = Format(slope, "0.0#") & ":1"
                BPsiz = MeasureString(eGraphics, BPval, Me.Font)

                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ConvergeLength
                p2y = p1y - vertRatio * SillHeight
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = ViewPort.Height - CDsiz.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                xLoc = CInt((p1x + p2x) / 2 - BPsiz.Width)
                yLoc = CInt((p1y + p2y) / 2 - BPsiz.Height)
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)

                BPlbl = Me.ConvergeLengthLabel.BaseText
                BPval = UnitsDialog.UiValueUnitsText(ConvergeLength, "m")

                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc = CInt(ViewPort.Height - BPsiz.Height - 3)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                BPsiz = MeasureString(eGraphics, BPval, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc -= CInt(BPsiz.Height) - 2
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)
            End If

            ' Control section
            If (0 < ControlLength) Then
                BPlbl = Me.ControlLengthLabel.BaseText
                BPval = UnitsDialog.UiValueUnitsText(ControlLength, "m")

                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ControlLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = ViewPort.Height - CDsiz.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc = CInt(ViewPort.Height - BPsiz.Height - 3)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                BPsiz = MeasureString(eGraphics, BPval, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc -= CInt(BPsiz.Height) - 2
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)

                ' Sill Height; position at least 3 lines from the top
                If (p1y < CInt(3 * SHsiz.Height)) Then
                    p1y = CInt(3 * SHsiz.Height)
                End If
                eGraphics.DrawString(SHlbl, Me.Font, mBlackBrush, 4, p1y)
                eGraphics.DrawString(SHval, Me.Font, mBlackBrush, 4, p1y + CInt(SHsiz.Height))
            End If

            ' Expansion section
            BPlbl = Me.ExpansionLengthLabel.BaseText
            BPval = UnitsDialog.UiValueUnitsText(ExpansionLength, "m")

            Select Case (mFlume.ExpansionRampStyle)

                Case cNoRamp

                    p1x = p2x
                    p1y = p2y
                    p2x = p1x
                    p2y = p1y + vertRatio * (SillHeight + BedDrop)
                    eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                    p3x = p2x
                    p3y = ViewPort.Height - CDsiz.Height
                    eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                Case cFullRamp

                    p1x = p2x
                    p1y = p2y
                    p2x = p1x + horzRatio * ExpansionLength
                    p2y = p1y + vertRatio * (SillHeight + BedDrop)
                    eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                    p3x = p2x
                    p3y = ViewPort.Height - CDsiz.Height
                    eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                    If (0 < mFlume.ExpansionSlopeZ) Then
                        BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
                        xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                        yLoc = CInt(ViewPort.Height - BPsiz.Height - 3)
                        eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                        BPsiz = MeasureString(eGraphics, BPval, Me.Font)
                        xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                        yLoc -= CInt(BPsiz.Height) - 2
                        eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)

                        BPlbl = My.Resources.Slope
                        BPval = UnitsDialog.UiValueText(mFlume.ExpansionSlopeZ, "")

                        xLoc = CInt(p1x + 4)
                        yLoc = CInt(p1y - 2 * BPsiz.Height)
                        eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                        yLoc = CInt(p1y - BPsiz.Height)
                        eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)
                    End If

                Case cTruncatedRamp

                    p1x = p2x
                    p1y = p2y
                    p2x = p1x + horzRatio * ExpansionLength
                    p2y = p1y + vertRatio * (SillHeight + BedDrop) / 2
                    eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                    p3y = p2y
                    p2y = p3y + vertRatio * (SillHeight + BedDrop) / 2
                    eGraphics.DrawLine(mBlackPen2, p2x, p3y, p2x, p2y)

                    p3x = p2x
                    p3y = ViewPort.Height - CDsiz.Height
                    eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                    If (0 < mFlume.ExpansionSlopeZ) Then
                        BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
                        xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                        yLoc = CInt(ViewPort.Height - BPsiz.Height - 3)
                        eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                        BPsiz = MeasureString(eGraphics, BPval, Me.Font)
                        xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                        yLoc -= CInt(BPsiz.Height) - 2
                        eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)

                        BPlbl = My.Resources.Slope
                        BPval = UnitsDialog.UiValueText(mFlume.ExpansionSlopeZ, "")

                        xLoc = CInt(p1x + 4)
                        yLoc = CInt(p1y - 2 * BPsiz.Height)
                        eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                        yLoc = CInt(p1y - BPsiz.Height)
                        eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)
                    End If

                Case Else
                    Debug.Assert(False, "Invalid Expansion Ramp")
            End Select

            ' Tailwater section
            BPlbl = Me.TailwaterLabel.BaseText

            p1x = p2x
            p1y = p2y
            p2x = p1x + horzRatio * TailwaterLength
            p2y = p1y
            eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

            BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
            xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
            yLoc = CInt(ViewPort.Height - BPsiz.Height - 3)
            eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

            If (0 < BedDrop) Then
                BPlbl = Me.BedDropLabel.BaseText
                BPval = UnitsDialog.UiValueUnitsText(BedDrop, "m")
                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)

                xLoc = CInt(p1x + 4)
                yLoc = CInt(p1y - BPsiz.Height)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                xLoc += CInt(BPsiz.Width) + 8
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub

    '*********************************************************************************************************
    ' Sub UpdateStationaryCrestProfile() - update the flume's bottom profile graphics & associated
    '                                      control positions
    '
    ' Input(s):     eGraphics       - GDI+ graphics drawing support
    '*********************************************************************************************************
    Protected Sub UpdateStationaryCrestProfile(ByVal eGraphics As System.Drawing.Graphics)

        Try
            ' Get the Flume dimensions
            Dim ChannelDepth As Single = Me.ChannelDepthSingle.SiValue
            Dim BedDrop As Single = Me.BedDropSingle.SiValue
            Dim FlumeHeight As Single = ChannelDepth + BedDrop
            Dim SillHeight As Single = Me.SillHeightSingle.SiValue

            Dim ApproachLength As Single = Me.GageDistanceSingle.SiValue
            Dim ConvergeLength As Single = Me.ConvergeLengthSingle.SiValue
            Dim ControlLength As Single = Me.ControlLengthSingle.SiValue
            Dim ExpansionLength As Single = mFlume.ExpansionLength
            Dim TailwaterLength As Single = ApproachLength + ConvergeLength

            Dim FlumeLength As Single = ApproachLength + ConvergeLength + ControlLength _
                                      + ExpansionLength + TailwaterLength

            Dim xMarginLength As Single = FlumeLength / 10
            FlumeLength += xMarginLength

            ' Define the ViewPort the bottom profile is to be drawn within
            Dim xOffset As Single = MaxRightBoundary(Me.ChannelDepthLabel, Me.ChannelDepthSingle)
            Dim yOffset As Single = Me.ChannelDepthLabel.Location.Y + Me.ChannelDepthLabel.Height
            Dim vWidth As Single = Me.Width - xOffset * 1.5!
            Dim vHeight As Single = Me.Height - yOffset - Me.GageDistanceSingle.Height - Me.GageDistanceLabel.Height - 8

            Dim vertRatio As Single = vHeight / FlumeHeight
            Dim horzRatio As Single = vWidth / FlumeLength

            ' Maintain 1:1 aspect ratio
            If (vertRatio > horzRatio) Then
                vertRatio = horzRatio
            Else
                horzRatio = vertRatio
            End If

            Dim wHeight As Single = vHeight / vertRatio
            Dim wOffset As Single = wHeight - (ChannelDepth + BedDrop)

            yOffset += vertRatio * wOffset
            '
            ' For each flume profile section:
            '   1) Draw bottom profile segment
            '   2) Draw vertical boundary indicator
            '   3) Position Single/Label controls
            '       a) Ensure no overlap with other controls/labels
            '
            Dim p1x, p1y, p2x, p2y, p3x, p3y As Single  ' End points for DrawLine()
            Dim xLoc, yLoc, xMin, yMin As Integer       ' Location
            Dim loc As Point

            ' Left margin
            If (0 < xMarginLength) Then
                p1x = xOffset
                p1y = yOffset + vertRatio * ChannelDepth
                p2x = p1x + horzRatio * xMarginLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = Me.Height - Me.GageDistanceLabel.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)
            End If

            mXmax = p2x

            ' Gage
            If (0 < ChannelDepth) Then
                p1x = p2x - 4
                p1y = yOffset
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p1x, p2y)
                p1x = p2x + 4
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p1x, p2y)

                For gdx As Integer = 0 To 15
                    Dim y As Single = yOffset + (p2y - p1y) * gdx / 16
                    eGraphics.DrawLine(mBlackPen1, p2x - 4, y, p2x + 4, y)
                Next gdx

                xLoc = CInt(p2x - Me.GageLabel.Width / 2)
                yLoc = CInt(yOffset) - Me.GageLabel.Height
                loc = New Point(xLoc, yLoc)
                Me.GageLabel.Location = loc

                xLoc = Me.GageLabel.Location.X + Me.GageLabel.Width + 32
                yLoc = Me.BottomProfileLabel.Location.Y
                loc = New Point(xLoc, yLoc)
                Me.BottomProfileLabel.Location = loc

                xLoc = Me.BottomProfileLabel.Location.X + Me.BottomProfileLabel.Width + 32
                yLoc = Me.FlumeDescription.Location.Y
                loc = New Point(xLoc, yLoc)
                Me.FlumeDescription.Location = loc
                Me.FlumeDescription.Width = Me.Width - xLoc - Me.Margin.Horizontal

            End If

            ' Approach section
            If (0 < ApproachLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ApproachLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = Me.Height - Me.GageDistanceLabel.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                xLoc = CInt(p1x + (p2x - p1x - Me.GageDistanceSingle.Width) / 2)
                yLoc = CInt(Me.Height - Me.GageDistanceLabel.Height - 4)
                loc = New Point(xLoc, yLoc)
                Me.GageDistanceLabel.Location = loc

                yLoc -= Me.GageDistanceSingle.Height
                loc = New Point(xLoc, yLoc)
                Me.GageDistanceSingle.Location = loc

                mXmax = p2x
            End If

            ' Converge section
            If (0 < ConvergeLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ConvergeLength
                p2y = p1y - vertRatio * SillHeight
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = Me.Height - Me.GageDistanceLabel.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                xMin = MaxRightBoundary(Me.GageDistanceLabel, Me.GageDistanceSingle)
                xLoc = CInt(p1x + (p2x - p1x - Me.ConvergeLengthSingle.Width) / 2)
                xLoc = Math.Max(xLoc, xMin)
                yLoc = CInt(Me.Height - Me.ConvergeLengthLabel.Height - 4)
                loc = New Point(xLoc, yLoc)
                Me.ConvergeLengthLabel.Location = loc

                yLoc -= Me.ConvergeLengthSingle.Height
                loc = New Point(xLoc, yLoc)
                Me.ConvergeLengthSingle.Location = loc

                Dim slope As Single = ConvergeLength / SillHeight
                Dim BPval As String = Format(slope, "0.0#") & ":1"
                Dim BPsiz As RectangleF = MeasureString(eGraphics, BPval, Me.Font)
                xLoc = CInt((p1x + p2x) / 2 - BPsiz.Width)
                yLoc = CInt((p1y + p2y) / 2 - BPsiz.Height)
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)

                mXmax = p2x
            End If

            ' Control section
            If (0 < ControlLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ControlLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = Me.Height - Me.GageDistanceLabel.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                xMin = MaxRightBoundary(Me.ConvergeLengthLabel, Me.ConvergeLengthSingle)
                xLoc = CInt(p1x + (p2x - p1x - Me.ControlLengthSingle.Width) / 2)
                xLoc = Math.Max(xLoc, xMin)
                yLoc = CInt(Me.Height - Me.ControlLengthLabel.Height - 4)
                loc = New Point(xLoc, yLoc)
                Me.ControlLengthLabel.Location = loc

                yLoc -= Me.ControlLengthSingle.Height
                loc = New Point(xLoc, yLoc)
                Me.ControlLengthSingle.Location = loc

                xLoc = Me.SillHeightSingle.Location.X
                yMin = Me.MinWspCheckBox.Location.Y + Me.MinWspCheckBox.Height + 8
                yLoc = CInt(p1y - Me.SillHeightSingle.Height)
                yLoc = Math.Max(yLoc, yMin)
                loc = New Point(xLoc, yLoc)
                Me.SillHeightSingle.Location = loc

                xLoc = Me.SillHeightLabel.Location.X
                yLoc += Me.SillHeightSingle.Height
                loc = New Point(xLoc, yLoc)
                Me.SillHeightLabel.Location = loc

                mXmax = p2x
            End If

            ' Expansion section
            Select Case (mFlume.ExpansionRampStyle)

                Case cNoRamp

                    p1x = p2x
                    p1y = p2y
                    p2x = p1x
                    p2y = p1y + vertRatio * (SillHeight + BedDrop)
                    eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                    p3x = p2x
                    p3y = Me.Height - Me.GageDistanceLabel.Height
                    eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                    Me.ExpansionLengthLabel.Visible = False
                    Me.ExpansionLengthSingle.Visible = False
                    Me.ExpansionSlopeLabel.Visible = False
                    Me.ExpansionSlopeSingle.Visible = False

                Case cFullRamp

                    p1x = p2x
                    p1y = p2y
                    p2x = p1x + horzRatio * ExpansionLength
                    p2y = p1y + vertRatio * (SillHeight + BedDrop)
                    eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                    p3x = p2x
                    p3y = Me.Height - Me.GageDistanceLabel.Height
                    eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                    If (0 < mFlume.ExpansionSlopeZ) Then
                        xMin = MaxRightBoundary(Me.ControlLengthLabel, Me.ControlLengthSingle)
                        xLoc = CInt(p1x + (p2x - p1x - Me.ExpansionLengthSingle.Width) / 2)
                        xLoc = Math.Max(xLoc, xMin)
                        yLoc = CInt(Me.Height - Me.ExpansionLengthLabel.Height - 4)
                        loc = New Point(xLoc, yLoc)
                        Me.ExpansionLengthLabel.Location = loc
                        Me.ExpansionLengthLabel.Visible = True

                        yLoc -= Me.ExpansionLengthSingle.Height
                        loc = New Point(xLoc, yLoc)
                        Me.ExpansionLengthSingle.Location = loc
                        Me.ExpansionLengthSingle.Visible = True
                    Else ' Expansion Slope = 0
                        Me.ExpansionLengthLabel.Visible = False
                        Me.ExpansionLengthSingle.Visible = False
                    End If

                    If (0 < mFlume.ExpansionSlopeZ) Then
                        xLoc = CInt(Me.ExpansionLengthSingle.Location.X + Me.ExpansionLengthSingle.Width / 2)
                        yLoc = CInt(p1y - Me.ExpansionSlopeSingle.Height)
                    Else ' Expansion Slope = 0
                        xLoc = CInt(p1x + 8)
                        yLoc = CInt(p2y - Me.ExpansionSlopeSingle.Height - 8)
                    End If

                    loc = New Point(xLoc, yLoc)
                    Me.ExpansionSlopeSingle.Location = loc
                    Me.ExpansionSlopeSingle.Visible = True

                    yLoc -= Me.ExpansionLengthLabel.Height
                    loc = New Point(xLoc, yLoc)
                    Me.ExpansionSlopeLabel.Location = loc
                    Me.ExpansionSlopeLabel.Visible = True

                    xLoc += Me.ExpansionSlopeSingle.Width
                    yLoc = Me.ExpansionSlopeSingle.Location.Y + 8
                    eGraphics.DrawString(" :1", Me.Font, mBlackBrush, xLoc, yLoc)

                Case cTruncatedRamp

                    p1x = p2x
                    p1y = p2y
                    p2x = p1x + horzRatio * ExpansionLength
                    p2y = p1y + vertRatio * (SillHeight + BedDrop) / 2
                    eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                    p1y = p2y
                    p2y = p1y + vertRatio * (SillHeight + BedDrop) / 2
                    eGraphics.DrawLine(mBlackPen2, p2x, p1y, p2x, p2y)

                    p3x = p2x
                    p3y = Me.Height - Me.GageDistanceLabel.Height
                    eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                    xMin = MaxRightBoundary(Me.ControlLengthLabel, Me.ControlLengthSingle)
                    xLoc = CInt(p1x + (p2x - p1x - Me.ExpansionLengthSingle.Width) / 2)
                    xLoc = Math.Max(xLoc, xMin)
                    yLoc = CInt(Me.Height - Me.ExpansionLengthLabel.Height - 4)
                    loc = New Point(xLoc, yLoc)
                    Me.ExpansionLengthLabel.Location = loc
                    Me.ExpansionLengthLabel.Visible = True

                    yLoc -= Me.ExpansionLengthSingle.Height
                    loc = New Point(xLoc, yLoc)
                    Me.ExpansionLengthSingle.Location = loc
                    Me.ExpansionLengthSingle.Visible = True

                    xMin = MaxRightBoundary(Me.ExpansionLengthLabel, Me.ExpansionLengthSingle)
                    xLoc = CInt((p1x + p2x) / 2)
                    xLoc = Math.Max(xLoc, xMin)
                    yLoc = (CInt(p1y) - Me.ExpansionSlopeSingle.Height)
                    loc = New Point(xLoc, yLoc)
                    Me.ExpansionSlopeSingle.Location = loc
                    Me.ExpansionSlopeSingle.Visible = True

                    yLoc -= Me.ExpansionLengthLabel.Height
                    loc = New Point(xLoc, yLoc)
                    Me.ExpansionSlopeLabel.Location = loc
                    Me.ExpansionSlopeLabel.Visible = True

                Case Else
                    Debug.Assert(False, "Invalid Expansion Ramp")
            End Select

            mXmax = p2x

            ' Tailwater section
            If (0 < TailwaterLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * TailwaterLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                mXmax = p2x

                xLoc = CInt(p2x - Me.BedDropLabel.Width)
                If (Me.ExpansionSlopeSingle.Visible) Then
                    If (xLoc < Me.ExpansionSlopeSingle.Location.X + Me.ExpansionSlopeSingle.Width + 16) Then
                        xLoc = Me.ExpansionSlopeSingle.Location.X + Me.ExpansionSlopeSingle.Width + 16
                    End If
                End If
                yLoc = CInt(p2y - Me.BedDropSingle.Height - Me.BedDropLabel.Height - 4)
                loc = New Point(xLoc, yLoc)
                Me.BedDropSingle.Location = loc

                yLoc += Me.BedDropSingle.Height
                loc = New Point(xLoc, yLoc)
                Me.BedDropLabel.Location = loc

                xLoc = Math.Min(Me.AbruptExpansionButton.Width, Me.GradualExpansionButton.Width)
                xLoc = Math.Min(Me.TruncatedRampButton.Width, xLoc)
                xLoc = Me.Width - xLoc - 16

                yLoc = Me.AbruptExpansionButton.Location.Y
                loc = New Point(xLoc, yLoc)
                Me.AbruptExpansionButton.Location = loc

                yLoc = Me.GradualExpansionButton.Location.Y
                loc = New Point(xLoc, yLoc)
                Me.GradualExpansionButton.Location = loc

                yLoc = Me.TruncatedRampButton.Location.Y
                loc = New Point(xLoc, yLoc)
                Me.TruncatedRampButton.Location = loc

                xLoc = Me.Width - Me.AutoAdjustButton.Width - Me.Margin.Horizontal
                yLoc = Me.Height - Me.AutoAdjustButton.Height - Me.Margin.Vertical
                loc = New Point(xLoc, yLoc)
                Me.AutoAdjustButton.Location = loc

                xMin = CInt(Math.Min(mXmax, xLoc))
                xLoc = CInt(p1x + (xMin - p1x - Me.TailwaterLabel.Width) / 2)
                yLoc = Me.ConvergeLengthLabel.Location.Y
                loc = New Point(xLoc, yLoc)
                Me.TailwaterLabel.Location = loc

            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub

    '*********************************************************************************************************
    ' Sub DrawStationaryWSP() - draw Water Surface Profile (WSP) for Stationary Flume
    '
    ' Input(s):     eGraphics       - GDI+ graphics drawing support
    '               Pen             - Pen to draw WSP
    '               Y1              - upstream depth, relative to upstream channel invert 
    '               Yc              - critical depth in the throat, relative to invert of throat section
    '               Y2              - depth in the tailwater section, relative to tailwater channel invert
    '               Q               - flow rate
    '
    ' Note - based on Sub ShowWaterSurface() in Winflume.bas (line 3025)
    '*********************************************************************************************************
    Protected Sub DrawStationaryWSP(ByVal eGraphics As System.Drawing.Graphics, ByVal Pen As Drawing.Pen, _
                ByVal Y1 As Single, ByVal Yc As Single, ByVal Y2 As Single, ByVal Q As Single)
        Try
            ' Get the Flume dimensions
            Dim ChannelDepth As Single = Me.ChannelDepthSingle.SiValue
            Dim BedDrop As Single = Me.BedDropSingle.SiValue
            Dim FlumeHeight As Single = ChannelDepth + BedDrop
            Dim SillHeight As Single = Me.SillHeightSingle.SiValue

            Dim ApproachLength As Single = Me.GageDistanceSingle.SiValue
            Dim ConvergeLength As Single = Me.ConvergeLengthSingle.SiValue
            Dim ControlLength As Single = Me.ControlLengthSingle.SiValue
            Dim ExpansionLength As Single = mFlume.ExpansionLength
            Dim ExpansionSlopeZ As Single = mFlume.ExpansionSlopeZ
            Dim TailwaterLength As Single = ApproachLength + ConvergeLength

            Dim FlumeLength As Single = ApproachLength + ConvergeLength + ControlLength _
                                      + ExpansionLength + TailwaterLength

            Dim xMarginLength As Single = FlumeLength / 10
            FlumeLength += xMarginLength

            Dim DeltaY2 As Single = Y2 - (0.95! * Yc + mFlume.SillHeight + mFlume.BedDrop)

            ' Define the ViewPort the bottom profile is to be drawn within
            Dim xOffset As Single = MaxRightBoundary(Me.ChannelDepthLabel, Me.ChannelDepthSingle)
            Dim yOffset As Single = Me.ChannelDepthLabel.Location.Y + Me.ChannelDepthLabel.Height
            Dim vWidth As Single = Me.Width - xOffset * 1.5!
            Dim vHeight As Single = Me.Height - yOffset - Me.GageDistanceSingle.Height - Me.GageDistanceLabel.Height - 8

            Dim vertRatio As Single = vHeight / FlumeHeight
            Dim horzRatio As Single = vWidth / FlumeLength

            ' Maintain 1:1 aspect ratio
            If (vertRatio > horzRatio) Then
                vertRatio = horzRatio
            Else
                horzRatio = vertRatio
            End If

            Dim wHeight As Single = vHeight / vertRatio
            Dim wOffset As Single = wHeight - (ChannelDepth + BedDrop)

            yOffset += vertRatio * wOffset
            Dim viewPort As RectangleF = New RectangleF(xOffset, yOffset, vWidth, vHeight)
            '
            ' Draw the stationary Water Surface Profile (WSP)
            '
            Dim cdy As Single = yOffset + vertRatio * ChannelDepth
            Dim p1x, p1y, p2x, p2y As Single

            Dim VHead, Y1d, Yerr As Single

            Y1d = (Y1 - mFlume.SillHeight + Yc) / 2 'first estimate
            Do
                'Compute velocity head at assumed value of y1d
                VHead = Q / mFlume.Section(cControl).Area(Y1d, False)
                VHead = CSng(VHead ^ 2 / 2 / AccelG)
                'Compute new y1d
                Y1d = Y1 - mFlume.SillHeight - VHead

                Yerr = Math.Abs((Y1d + VHead + mFlume.SillHeight) - Y1)

            Loop Until Yerr < 0.001

            Y1d = maxsingle(Y1d, Yc) 'In case velocity head is extreme

            ' Left margin
            If (0 < xMarginLength) Then
                p1x = xOffset
                p1y = yOffset + vertRatio * (ChannelDepth - Y1)
                p2x = p1x + horzRatio * xMarginLength
                p2y = p1y
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)
            End If

            ' Approach section
            If (0 < ApproachLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ApproachLength
                p2y = p1y
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

                ' "Ripples" carat
                Dim CaratLength As Single = minsingle((p2x - p1x) * 0.3!, vertRatio * Y1 * 0.3!)
                Dim offset As Single = CaratLength / 5
                If (Q = mFlume.QMin) Then
                    p1x += offset * 3
                End If
                p1x += offset * 2
                p1y += offset
                eGraphics.DrawLine(Pen, p1x, p1y, p1x + offset * 2, p1y)
                eGraphics.DrawLine(Pen, p1x + offset * 3, p1y, p1x + CaratLength, p1y)
                p1x += offset
                p1y += offset
                eGraphics.DrawLine(Pen, p1x, p1y, p1x + CaratLength - 2 * offset, p1y)
                p1x += offset
                p1y += offset
                eGraphics.DrawLine(Pen, p1x, p1y, p1x + CaratLength - 4 * offset, p1y)
            End If

            ' Converge section
            If (0 < ConvergeLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ConvergeLength
                p2y = yOffset + vertRatio * (ChannelDepth - SillHeight - Y1d)
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)
            End If

            ' Control (i.e throat) section
            If (0 < ControlLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ControlLength
                p2y = yOffset + vertRatio * (ChannelDepth - SillHeight - (0.95! * Yc))

                If (DeltaY2 > 0) Then ' Tailwater above throat water level
                    p2x += 0.2! * (p2x - p1x)               ' + 20% Control Length
                    p2x += 1.25! * vertRatio * DeltaY2      ' + delta for jump
                End If

                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)
            End If

            ' Expansion section
            If (DeltaY2 > 0) Then ' Tailwater above throat water level

                p1x = p2x - vertRatio * DeltaY2
                p2x = p1x + vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p1y - vertRatio * 0.45! * DeltaY2
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y - 0.3! * vertRatio * DeltaY2
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y - 0.15! * vertRatio * DeltaY2
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

            ElseIf ((mFlume.ExpansionRampStyle = cNoRamp) Or _
               (Not (mFlume.ExpansionRampStyle = cNoRamp) And (ExpansionSlopeZ = 0))) Then
                ' Plunging jet into low tailwater pool

                DeltaY2 = Math.Abs(DeltaY2)

                p1x = p2x
                p2x = p2x + vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y + 0.2! * vertRatio * DeltaY2
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y + 0.35! * vertRatio * DeltaY2
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y + 0.45! * vertRatio * DeltaY2
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

            Else ' Accelerating flow down ramp into hydraulic jump at tailwater

                Dim DeltaYRamp As Single = SillHeight + BedDrop + Yc - Y2
                Dim DeltaXRamp As Single = DeltaYRamp * ExpansionSlopeZ
                Dim DeltaWL As Single = 0.95! * Yc - (Y2 - SillHeight - BedDrop)

                p1x = p2x
                p2x = p2x + vertRatio * DeltaXRamp / 3
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y + vertRatio * DeltaYRamp / 3
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + vertRatio * DeltaXRamp / 3
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y + vertRatio * DeltaYRamp / 3
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + vertRatio * (DeltaXRamp / 3 + 0.95! * DeltaWL * ExpansionSlopeZ)
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = yOffset + vertRatio * (ChannelDepth + BedDrop - Y2)
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)

            End If

            ' Tailwater section
            If (0 < TailwaterLength) Then
                p1x = p2x
                p2x = p1x + horzRatio * TailwaterLength
                p2x = mXmax
                p1y = yOffset + vertRatio * (ChannelDepth + BedDrop - Y2)
                p2y = p1y
                eGraphics.DrawLine(Pen, p1x, p1y, p2x, p2y)
            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Movable Crest "

    '*********************************************************************************************************
    ' Sub DrawMovableBottomProfile() - draw the Movable Bottom Profile in the specified ViewPort
    '
    ' Input(s):     ViewPort    - bounding area for drawing
    '               eGraphics   - GDI Graphics object for drawing
    '*********************************************************************************************************
    Public Sub DrawMovableBottomProfile(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics)

        Try
            '
            ' Get the Flume dimensions
            '
            Dim ChannelDepth As Single = mFlume.ChannelDepth
            Dim BedDrop As Single = mFlume.BedDrop
            Dim FlumeHeight As Single = ChannelDepth + BedDrop
            Dim OperatingDepth As Single = mFlume.OperatingDepth
            Dim Radius As Single = mFlume.RadiusMovable

            Dim ApproachLength As Single = mFlume.GageDistance
            Dim ControlLength As Single = mFlume.ControlLength
            Dim FlumeLength As Single = ApproachLength + ControlLength

            Dim TailwaterLength As Single = FlumeLength / 4
            FlumeLength += TailwaterLength

            Dim xMarginLength As Single = FlumeLength / 10
            FlumeLength += xMarginLength
            '
            ' Define region where the bottom profile will be drawn
            '
            Dim xOffset As Single = ViewPort.X          ' Start with the input ViewPort
            Dim yOffset As Single = ViewPort.Y
            Dim vWidth As Single = ViewPort.Width
            Dim vHeight As Single = ViewPort.Height

            ' Make room on left for "Channel Depth" & "Operating Depth"
            Dim CDlbl As String = Me.ChannelDepthLabel.BaseText
            Dim CDval As String = UnitsDialog.UiValueUnitsText(ChannelDepth, "m")
            Dim CDsiz As RectangleF = MeasureString(eGraphics, CDlbl, Me.Font)

            Dim ODlbl As String = Me.OperatingDepthLabel.BaseText
            Dim ODval As String = UnitsDialog.UiValueUnitsText(OperatingDepth, "m")
            Dim ODsiz As RectangleF = MeasureString(eGraphics, ODlbl, Me.Font)

            If (CDsiz.Width < ODsiz.Width) Then
                xOffset += CDsiz.Width
                vWidth -= CDsiz.Width
            Else
                xOffset += ODsiz.Width
                vWidth -= ODsiz.Width
            End If

            ' Make room on bottom for segment lengths
            vHeight -= 4 * CDsiz.Height

            Dim vertRatio As Single = vHeight / FlumeHeight
            Dim horzRatio As Single = vWidth / FlumeLength

            ' Maintain 1:1 aspect ratio
            If (vertRatio > horzRatio) Then
                vertRatio = horzRatio
            Else
                horzRatio = vertRatio
            End If

            ' Position profile at bottom of ViewPort
            yOffset += vHeight - vertRatio * FlumeHeight
            '
            ' For each flume profile section:
            '   1) Draw bottom profile segment
            '   2) Draw vertical boundary indicator
            '   3) Add label/length values
            '
            Dim p1x, p1y, p2x, p2y, p3x, p3y As Single  ' End points for DrawLine()
            Dim xLoc, yLoc As Integer                   ' Label location

            ' Left margin
            If (0 < xMarginLength) Then
                p1x = xOffset
                p1y = yOffset + vertRatio * ChannelDepth            ' Approach channel invert
                p2x = p1x + horzRatio * xMarginLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = ViewPort.Height - CDsiz.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)
            End If

            ' Gage
            Dim BPlbl As String = Me.GageLabel.BaseText
            Dim BPval As String = ""
            Dim BPsiz As RectangleF = MeasureString(eGraphics, BPlbl, Me.Font)

            If (0 < ChannelDepth) Then
                p1x = p2x - 4
                p1y = yOffset                                       ' Channel Depth

                xLoc = CInt(p1x - BPsiz.Width / 2)
                yLoc = CInt(p1y - BPsiz.Height)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                yLoc -= CInt(BPsiz.Height)
                If (yLoc < 4) Then
                    yLoc = 4
                End If
                eGraphics.DrawString(CDlbl, Me.Font, mBlackBrush, 4, yLoc)
                yLoc += CInt(CDsiz.Height)
                eGraphics.DrawString(CDval, Me.Font, mBlackBrush, 4, yLoc)

                eGraphics.DrawLine(mBlackDashedPen, 4, p1y, p1x - BPsiz.Width / 2, p1y)

                Dim ratio As Single = OperatingDepth / ChannelDepth
                p3y = yOffset + vertRatio * ChannelDepth            ' Approach channel invert
                p3y -= ratio * vertRatio * ChannelDepth             ' Operating Depth

                eGraphics.DrawLine(mBlackDashedPen, 4, p3y, p1x - BPsiz.Width / 2, p3y)

                yLoc = CInt(p3y)
                eGraphics.DrawString(ODlbl, Me.Font, mBlackBrush, 4, yLoc)
                yLoc += CInt(ODsiz.Height)
                eGraphics.DrawString(ODval, Me.Font, mBlackBrush, 4, yLoc)

                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p1x, p2y)
                p1x = p2x + 4
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p1x, p2y)

                For gdx As Integer = 0 To 15
                    Dim y As Single = yOffset + (p2y - p1y) * gdx / 16
                    eGraphics.DrawLine(mBlackPen1, p2x - 4, y, p2x + 4, y)
                Next gdx
            End If

            ' Approach section
            If (0 < ApproachLength) Then
                BPlbl = Me.GageDistanceLabel.BaseText
                BPval = UnitsDialog.UiValueUnitsText(ApproachLength, "m")

                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ApproachLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = ViewPort.Height - CDsiz.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc = CInt(ViewPort.Height - BPsiz.Height - 4)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                BPsiz = MeasureString(eGraphics, BPval, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc -= CInt(BPsiz.Height)
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)
            End If

            ' Bed Drop
            If (0 < BedDrop) Then
                BPlbl = Me.BedDropLabel.BaseText
                BPval = UnitsDialog.UiValueUnitsText(BedDrop, "m")
                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)

                p1x = p2x
                p1y = p2y
                p2x = p1x
                p2y = p1y + vertRatio * BedDrop
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                xLoc = CInt(p2x + 4)
                yLoc = CInt(p2y - BPsiz.Height)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                xLoc += CInt(BPsiz.Width) + 8
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)
            End If

            ' Control section
            If (0 < ControlLength) Then
                BPlbl = Me.ControlLengthLabel.BaseText
                BPval = UnitsDialog.UiValueUnitsText(ControlLength, "m")

                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ControlLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = ViewPort.Height - CDsiz.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc = CInt(ViewPort.Height - BPsiz.Height - 4)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                BPsiz = MeasureString(eGraphics, BPval, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc -= CInt(BPsiz.Height)
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)
            End If

            ' Radius section
            If (0 < Radius) Then
                BPlbl = Me.RadiusLabel.BaseText
                BPval = UnitsDialog.UiValueUnitsText(Radius, "m")
                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font
                                      )
                Dim r As Single = vertRatio * Radius        ' Crest radius
                Dim d As Single = 2 * r                     '   "   diameter

                p1x = p1x + r
                p1y = p1y - r - vertRatio * BedDrop
                eGraphics.DrawLine(BluePen2, p1x, p1y, p2x, p1y)            ' Top of crest (horz.)

                eGraphics.DrawArc(BluePen2, p1x - r, p1y, d, d, 180, 90)    ' Movable crest radius

                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
                xLoc = CInt(p1x - r - BPsiz.Width)
                yLoc = CInt(p1y - 2 * BPsiz.Height)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)

                BPsiz = MeasureString(eGraphics, BPval, Me.Font)
                yLoc = CInt(p1y - BPsiz.Height)
                eGraphics.DrawString(BPval, Me.Font, mBlackBrush, xLoc, yLoc)
            End If

            ' Tailwater section
            If (0 < TailwaterLength) Then
                BPlbl = Me.TailwaterLabel.BaseText

                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * TailwaterLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                BPsiz = MeasureString(eGraphics, BPlbl, Me.Font)
                xLoc = CInt(p1x + (p2x - p1x - BPsiz.Width) / 2)
                yLoc = CInt(ViewPort.Height - BPsiz.Height - 4)
                eGraphics.DrawString(BPlbl, Me.Font, mBlackBrush, xLoc, yLoc)
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub

    '*********************************************************************************************************
    ' Sub UpdateMovableCrestProfile() - update the flume's bottom profile graphics & associated
    '                                   control positions
    '
    ' Input(s):     eGraphics       - GDI+ graphics drawing support
    '*********************************************************************************************************
    Protected Sub UpdateMovableCrestProfile(ByVal eGraphics As System.Drawing.Graphics)

        Try
            ' Get the Flume dimensions
            Dim ChannelDepth As Single = Me.ChannelDepthSingle.SiValue
            Dim BedDrop As Single = Me.BedDropSingle.SiValue
            Dim FlumeHeight As Single = ChannelDepth + BedDrop
            Dim Radius As Single = Me.RadiusSingle.SiValue

            Dim ApproachLength As Single = Me.GageDistanceSingle.SiValue
            Dim ControlLength As Single = Me.ControlLengthSingle.SiValue
            Dim TailwaterLength As Single = ApproachLength

            Dim FlumeLength As Single = ApproachLength + ControlLength + TailwaterLength

            Dim xMarginLength As Single = FlumeLength / 10
            FlumeLength += xMarginLength

            ' Define the ViewPort the bottom profile is to be drawn within
            Dim xOffset As Single = MaxRightBoundary(Me.ChannelDepthLabel, Me.ChannelDepthSingle)
            Dim yOffset As Single = Me.ChannelDepthLabel.Location.Y + Me.ChannelDepthLabel.Height
            Dim vWidth As Single = CSng(Me.Width - xOffset * 1.5)
            Dim vHeight As Single = Me.Height - yOffset - Me.GageDistanceSingle.Height - Me.GageDistanceLabel.Height - 8

            Dim vertRatio As Single = vHeight / FlumeHeight
            Dim horzRatio As Single = vWidth / FlumeLength

            ' Maintain 1:1 aspect ratio
            If (vertRatio > horzRatio) Then
                vertRatio = horzRatio
            Else
                horzRatio = vertRatio
            End If

            Dim wHeight As Single = vHeight / vertRatio
            Dim wOffset As Single = wHeight - (ChannelDepth + BedDrop)

            yOffset += vertRatio * wOffset
            '
            ' For each flume section:
            '   1) Draw bottom profile segment
            '   2) Draw vertical boundary indicator
            '   3) Position Single/Label controls
            '       a) Ensure no overlap with other controls/labels
            '
            Dim p1x, p1y, p2x, p2y, p3x, p3y As Single      ' End points for DrawLine()
            Dim xLoc, yLoc, xMin, yMin As Integer           ' Control location
            Dim loc As Point

            ' Left margin
            If (0 < xMarginLength) Then
                p1x = xOffset
                p1y = yOffset + vertRatio * ChannelDepth
                p2x = p1x + horzRatio * xMarginLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = Me.Height - Me.GageDistanceLabel.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                mXmax = p3x
            End If

            ' Gage
            If (0 < ChannelDepth) Then
                p1x = p2x - 4
                p1y = yOffset
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p1x, p2y)
                p1x = p2x + 4
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p1x, p2y)

                For gdx As Integer = 0 To 15
                    Dim y As Single = yOffset + (p2y - p1y) * gdx / 16
                    eGraphics.DrawLine(mBlackPen1, p2x - 4, y, p2x + 4, y)
                Next gdx

                xLoc = CInt(p2x - Me.GageLabel.Width / 2)
                yLoc = CInt(yOffset) - Me.GageLabel.Height
                loc = New Point(xLoc, yLoc)
                Me.GageLabel.Location = loc

                xLoc = Me.GageLabel.Location.X + Me.GageLabel.Width + 32
                yLoc = Me.BottomProfileLabel.Location.Y
                loc = New Point(xLoc, yLoc)
                Me.BottomProfileLabel.Location = loc

                xLoc = Me.BottomProfileLabel.Location.X + Me.BottomProfileLabel.Width + 32
                yLoc = Me.FlumeDescription.Location.Y
                loc = New Point(xLoc, yLoc)
                Me.FlumeDescription.Location = loc
                Me.FlumeDescription.Width = Me.Width - xLoc - Me.Margin.Horizontal

                mXmax = p2x
            End If

            ' Approach section
            If (0 < ApproachLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ApproachLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = Me.Height - Me.GageDistanceLabel.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                xLoc = CInt(p1x + (p2x - p1x - Me.GageDistanceSingle.Width) / 2)
                yLoc = CInt(Me.Height - Me.GageDistanceLabel.Height - 4)
                loc = New Point(xLoc, yLoc)
                Me.GageDistanceLabel.Location = loc

                yLoc -= Me.GageDistanceSingle.Height
                loc = New Point(xLoc, yLoc)
                Me.GageDistanceSingle.Location = loc

                loc = New Point(Me.Margin.Horizontal, Me.GageDistanceLabel.Location.Y)
                Me.OperatingDepthLabel.Location = loc

                loc = New Point(Me.Margin.Horizontal, Me.GageDistanceSingle.Location.Y)
                Me.OperatingDepthSingle.Location = loc

                mXmax = p3x
            End If

            ' Bed Drop
            If (0 < BedDrop) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x
                p2y = p1y + vertRatio * BedDrop
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                mXmax = p2x
            End If

            ' Control section
            If (0 < ControlLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * ControlLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                p3x = p2x
                p3y = Me.Height - Me.GageDistanceLabel.Height
                eGraphics.DrawLine(mBlackPen1, p2x, p2y + 5, p3x, p3y)

                xMin = MaxRightBoundary(Me.ConvergeLengthLabel, Me.ConvergeLengthSingle)
                xLoc = CInt(p1x + (p2x - p1x - Me.ControlLengthSingle.Width) / 2)
                xLoc = Math.Max(xLoc, xMin)
                yLoc = CInt(Me.Height - Me.ControlLengthLabel.Height - 4)
                loc = New Point(xLoc, yLoc)
                Me.ControlLengthLabel.Location = loc

                yLoc -= Me.ControlLengthSingle.Height
                loc = New Point(xLoc, yLoc)
                Me.ControlLengthSingle.Location = loc

                xLoc = Me.SillHeightSingle.Location.X
                yMin = Me.MinWspCheckBox.Location.Y + Me.MinWspCheckBox.Height + 8
                yLoc = CInt(p1y - Me.SillHeightSingle.Height)
                yLoc = Math.Max(yLoc, yMin)
                loc = New Point(xLoc, yLoc)
                Me.SillHeightSingle.Location = loc

                xLoc = Me.SillHeightLabel.Location.X
                yLoc += Me.SillHeightSingle.Height
                loc = New Point(xLoc, yLoc)
                Me.SillHeightLabel.Location = loc

                mXmax = p3x
            End If

            ' Radius section
            If (0 < Radius) Then
                Dim r As Single = vertRatio * Radius        ' Crest radius
                Dim d As Single = 2 * r                     '   "   diameter

                p1x = p1x + r
                p1y = p1y - r - vertRatio * BedDrop
                eGraphics.DrawLine(BluePen2, p1x, p1y, p2x, p1y)            ' Top of crest (horz.)

                eGraphics.DrawArc(BluePen2, p1x - r, p1y, d, d, 180, 90)    ' Movable crest radius

                xMin = Math.Max(Me.RadiusLabel.Width, Me.RadiusSingle.SingleText.Width * 2)
                xLoc = CInt(p1x - xMin)
                yLoc = CInt(p1y - Me.RadiusLabel.Height / 2)
                loc = New Point(xLoc, yLoc)
                Me.RadiusLabel.Location = loc

                yLoc -= Me.RadiusSingle.Height ' + Me.Margin.Vertical
                loc = New Point(xLoc, yLoc)
                Me.RadiusSingle.Location = loc

                mXmax = p2x
            End If

            ' Tailwater section
            If (0 < TailwaterLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * TailwaterLength
                p2y = p1y
                eGraphics.DrawLine(mBlackPen2, p1x, p1y, p2x, p2y)

                xLoc = CInt(p2x - Me.BedDropLabel.Width)
                yLoc = CInt(p1y - Me.BedDropSingle.Height - Me.BedDropLabel.Height - 4)
                loc = New Point(xLoc, yLoc)
                Me.BedDropSingle.Location = loc

                yLoc += Me.BedDropSingle.Height
                loc = New Point(xLoc, yLoc)
                Me.BedDropLabel.Location = loc

                xLoc = Me.Width - Me.AutoAdjustButton.Width - Me.Margin.Horizontal
                yLoc = Me.Height - Me.AutoAdjustButton.Height - Me.Margin.Vertical
                loc = New Point(xLoc, yLoc)
                Me.AutoAdjustButton.Location = loc

                xLoc = CInt(p1x + Me.TailwaterLabel.Width / 2)
                yLoc = Me.ControlLengthLabel.Location.Y
                loc = New Point(xLoc, yLoc)
                Me.TailwaterLabel.Location = loc

                mXmax = p2x
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub

    '*********************************************************************************************************
    ' Sub DrawMovableWSP() - draw Water Surface Profile (WSP) for Movable Flume
    '
    ' Input(s):     eGraphics       - GDI+ graphics drawing support
    '               PenWSP          - Pen to draw WSP
    '               PenFlume        - Pen to draw movable flume
    '               Yflume          - height of the movable weir relative to the invert of the upstream channel
    '               Y1              - upstream depth, relative to upstream channel invert
    '               Yc              - critical depth in the throat, relative to the movable weir
    '               Y2              - depth in the tailwater section, relative to tailwater channel invert
    '               Q               - flow rate
    '*********************************************************************************************************
    Protected Sub DrawMovableWSP(ByVal eGraphics As System.Drawing.Graphics, ByVal PenWSP As Drawing.Pen,
                                 ByVal PenFlume As Drawing.Pen, ByVal Yflume As Single, ByVal Y1 As Single,
                                 ByVal Yc As Single, ByVal Y2 As Single, ByVal Q As Single)
        Try
            ' Get the Flume dimensions
            Dim ChannelDepth As Single = Me.ChannelDepthSingle.SiValue
            Dim BedDrop As Single = Me.BedDropSingle.SiValue
            Dim FlumeHeight As Single = ChannelDepth + BedDrop
            Dim Radius As Single = Me.RadiusSingle.SiValue

            Dim ApproachLength As Single = Me.GageDistanceSingle.SiValue
            Dim ControlLength As Single = Me.ControlLengthSingle.SiValue
            Dim TailwaterLength As Single = ApproachLength

            Dim FlumeLength As Single = ApproachLength + ControlLength + TailwaterLength

            Dim xMarginLength As Single = FlumeLength / 10
            FlumeLength += xMarginLength

            Dim DeltaY2 As Single = Y2 - (0.95! * Yc + Yflume + mFlume.BedDrop)

            ' Define the ViewPort the bottom profile is to be drawn within
            Dim xOffset As Single = MaxRightBoundary(Me.ChannelDepthLabel, Me.ChannelDepthSingle)
            Dim yOffset As Single = Me.ChannelDepthLabel.Location.Y + Me.ChannelDepthLabel.Height
            Dim vWidth As Single = CSng(Me.Width - xOffset * 1.5)
            Dim vHeight As Single = Me.Height - yOffset - Me.GageDistanceSingle.Height - Me.GageDistanceLabel.Height - 8

            Dim vertRatio As Single = vHeight / FlumeHeight
            Dim horzRatio As Single = vWidth / FlumeLength

            ' Maintain 1:1 aspect ratio
            If (vertRatio > horzRatio) Then
                vertRatio = horzRatio
            Else
                horzRatio = vertRatio
            End If

            Dim wHeight As Single = vHeight / vertRatio
            Dim wOffset As Single = wHeight - (ChannelDepth + BedDrop)

            yOffset += vertRatio * wOffset
            Dim viewPort As RectangleF = New RectangleF(xOffset, yOffset, vWidth, vHeight)
            '
            ' Draw the Movable Water Surface Profile (WSP)
            '
            Dim p1x, p1y, p2x, p2y As Single      ' End points for DrawLine()

            Dim VHead, Y1d As Single

            Y1d = (Y1 - Yflume + Yc) / 2 'first estimate
            Do
                'Compute velocity head at assumed value of y1d
                VHead = Q / mFlume.Section(cControl).Area(Y1d, False)
                VHead = CSng(VHead ^ 2 / 2 / AccelG)
                'Compute new y1d
                Y1d = Y1 - Yflume - VHead
            Loop Until Math.Abs((Y1d + VHead + Yflume) - Y1) < 0.001

            Y1d = maxsingle(Y1d, Yc) 'In case velocity head is extreme

            ' Left margin
            If (0 < xMarginLength) Then
                p1x = xOffset
                p1y = yOffset + vertRatio * (ChannelDepth - Y1)
                p2x = p1x + horzRatio * xMarginLength
                p2y = p1y
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)
            End If

            ' Approach section
            If (0 < ApproachLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * (ApproachLength - 2 * Radius)
                p2y = p1y
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)

                ' Converge section
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * (3 * Radius)
                p2y = yOffset + vertRatio * (ChannelDepth - Yflume - Y1d)
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)
            End If

            ' Control (i.e throat) section
            If (0 < ControlLength) Then
                p1x = p2x
                p1y = p2y
                p2x = p1x + horzRatio * (ControlLength - Radius)
                p2y = yOffset + vertRatio * (ChannelDepth - Yflume - (0.95! * Yc))

                If (DeltaY2 > 0) Then ' Tailwater above throat water level
                    p2x += 0.2! * (p2x - p1x)
                End If

                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)
            End If

            ' Movable flume
            If (0 < Radius) Then
                Dim r As Single = vertRatio * Radius        ' Crest radius
                Dim d As Single = 2 * r                     '   "   diameter

                Dim f1x As Single = p1x
                Dim f2x As Single = p1x + horzRatio * ControlLength - r
                Dim f1y As Single = yOffset + vertRatio * (ChannelDepth - Yflume)
                Dim f2y As Single = yOffset + vertRatio * ChannelDepth

                Dim dashPen As Pen = New Pen(PenFlume.Color, PenFlume.Width) With {
                    .DashStyle = Drawing2D.DashStyle.Dash}

                eGraphics.DrawLine(PenFlume, f1x, f1y, f2x, f1y)            ' Top of crest (horz.)

                f1x -= r
                eGraphics.DrawArc(PenFlume, f1x, f1y, d, d, 180, 90)        ' Movable crest radius

                f1y += r
                eGraphics.DrawLine(dashPen, f1x, f1y, f1x, f2y)             ' Front of crest (vert.)
            End If

            ' Expansion section
            If (DeltaY2 > 0) Then ' Tailwater above throat water level

                p1x = p2x
                p2x = p1x + vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p1y - 0.55! * vertRatio * DeltaY2         ' p2y deltas must sum to 1.0
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y - 0.3! * vertRatio * DeltaY2          ' 0.55 + 0.3
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y - 0.15! * vertRatio * DeltaY2         ' 0.55 + 0.3 + 0.15 = 1.0
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)

            Else ' Plunging jet into low tailwater pool

                DeltaY2 = Math.Abs(DeltaY2)

                p1x = p2x
                p2x = p2x + 0.6! * vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y + 0.2! * vertRatio * DeltaY2         ' p2y deltas must sum to 1.0
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + 0.6! * vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y + 0.35! * vertRatio * DeltaY2         ' 0.2 + 0.35
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)

                p1x = p2x
                p2x = p2x + 0.6! * vertRatio * DeltaY2
                p2x = minsingle(p2x, mXmax)
                p1y = p2y
                p2y = p2y + 0.45! * vertRatio * DeltaY2         ' 0.2 + 0.35 + 0.45 = 1.0
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)

            End If

            ' Tailwater section
            If (0 < TailwaterLength) Then
                p1x = p2x
                p2x = p1x + horzRatio * TailwaterLength
                p2x = mXmax
                p1y = yOffset + vertRatio * (ChannelDepth + BedDrop - Y2)
                p2y = p1y
                eGraphics.DrawLine(PenWSP, p1x, p1y, p2x, p2y)

                ' "Ripples" carat
                Dim CaratLength As Single = minsingle((p2x - p1x) * 0.3!, vertRatio * Y1 * 0.3!)
                Dim offset As Single = CaratLength / 5
                p1x = mXmax - CaratLength - offset
                p1y += offset
                If (Q = mFlume.QMin) Then
                    p1x -= CaratLength
                End If
                eGraphics.DrawLine(PenWSP, p1x, p1y, p1x + offset * 2, p1y)
                eGraphics.DrawLine(PenWSP, p1x + offset * 3, p1y, p1x + CaratLength, p1y)
                p1x += offset
                p1y += offset
                eGraphics.DrawLine(PenWSP, p1x, p1y, p1x + CaratLength - 2 * offset, p1y)
                p1x += offset
                p1y += offset
                eGraphics.DrawLine(PenWSP, p1x, p1y, p1x + CaratLength - 4 * offset, p1y)
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Sub OnPaint() - ensure contained Controls are correctly positioned when Control is re-painted
    '*********************************************************************************************************
    Protected Overrides Sub OnPaint(ByVal e As Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        UpdateControlValues()               ' Get current values from Flume
        UpdateBottomProfile(e.Graphics)     ' Re-Paint bottom profile
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Auto-Adjust Lengths button click and Undo/Redo
    '*********************************************************************************************************
    Private Sub AutoAdjustButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles AutoAdjustButton.Click
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then

            ' Set current selections as Undo point
            Dim gageDist As Single = mFlume.GageDistance
            Dim convLen As Single = mFlume.ConvergeLength
            Dim ctrlLen As Single = mFlume.ControlLength
            Dim radMov As Single = mFlume.RadiusMovable
            Dim undoRedo As AdjustLengthsUndoRedo = New AdjustLengthsUndoRedo(gageDist, convLen, ctrlLen, radMov)
            AutoAdjustButton.AddUndoItem(undoRedo)
            WinFlumeForm.ClearRedoStack() ' Clear Redo stack in Click handler only

            ' Auto Adjust the Flume lenghts
            mFlumeAPI.FixLengths()
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub AutoAdjustButton_UndoButtonEvent(ByVal UndoValue As Object) _
        Handles AutoAdjustButton.UndoButtonEvent

        ' Set current selections as Redo point
        Dim gageDist As Single = mFlume.GageDistance
        Dim convLen As Single = mFlume.ConvergeLength
        Dim ctrlLen As Single = mFlume.ControlLength
        Dim radMov As Single = mFlume.RadiusMovable
        Dim autoAdjustRedo As AdjustLengthsUndoRedo = New AdjustLengthsUndoRedo(gageDist, convLen, ctrlLen, radMov)
        AutoAdjustButton.AddRedoItem(autoAdjustRedo)

        ' Get Undo point's selections
        Dim autoAdjustUndo As AdjustLengthsUndoRedo = DirectCast(UndoValue, AdjustLengthsUndoRedo)
        ' Restore length parameters
        mFlume.GageDistance = autoAdjustUndo.GageDistance
        mFlume.ConvergeLength = autoAdjustUndo.ConvergeLength
        mFlume.ControlLength = autoAdjustUndo.ControlLength
        mFlume.RadiusMovable = autoAdjustUndo.RadiusMovable

        mWinFlumeForm.RaiseFlumeDataChanged()
    End Sub

    Private Sub AutoAdjustButton_RedoButtonEvent(ByVal RedoValue As Object) _
        Handles AutoAdjustButton.RedoButtonEvent

        ' Set current selections as Undo point
        Dim gageDist As Single = mFlume.GageDistance
        Dim convLen As Single = mFlume.ConvergeLength
        Dim ctrlLen As Single = mFlume.ControlLength
        Dim radMov As Single = mFlume.RadiusMovable
        Dim autoAdjustUndo As AdjustLengthsUndoRedo = New AdjustLengthsUndoRedo(gageDist, convLen, ctrlLen, radMov)
        AutoAdjustButton.AddUndoItem(autoAdjustUndo)

        ' Get Redo point's selections
        Dim autoAdjustRedo As AdjustLengthsUndoRedo = DirectCast(RedoValue, AdjustLengthsUndoRedo)
        ' Restore length parameters
        mFlume.GageDistance = autoAdjustRedo.GageDistance
        mFlume.ConvergeLength = autoAdjustRedo.ConvergeLength
        mFlume.ControlLength = autoAdjustRedo.ControlLength
        mFlume.RadiusMovable = autoAdjustRedo.RadiusMovable

        mWinFlumeForm.RaiseFlumeDataChanged()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub FlumeDescription_ValueChanged() Handles FlumeDescription.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim description As String = Me.FlumeDescription.Value
            If Not (mFlume.Description = description) Then
                mFlume.Description = description
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub ChannelDepthSingle_ValueChanged() Handles ChannelDepthSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siChannelDepth As Single = Me.ChannelDepthSingle.SiValue

            If (WinFlumeForm.ValidateChannelDepth(siChannelDepth)) Then
                If (mFlume.ChannelDepth <> siChannelDepth) Then
                    mFlume.ChannelDepth = siChannelDepth

                    ' Check if Control section's D2 should track Channel Depth changes
                    Dim ctrlSection As Flume.SectionType = mFlume.Section(cControl)
                    If (ctrlSection.GetType Is GetType(WinFlumeSectionType)) Then
                        Dim winFlumeSection As WinFlumeSectionType = DirectCast(ctrlSection, WinFlumeSectionType)

                        If (winFlumeSection.ControlShape = shTrapezoidInRectangle) Then
                            ctrlSection.D2 = siChannelDepth
                        End If
                    End If

                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub OperatingDepthSingle_ValueChanged() Handles OperatingDepthSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siOperatingDepth As Single = Me.OperatingDepthSingle.SiValue
            If (WinFlumeForm.ValidateOperatingDepth(siOperatingDepth)) Then
                If (mFlume.OperatingDepth <> siOperatingDepth) Then
                    mFlume.OperatingDepth = siOperatingDepth
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub GageDistanceSingle_ValueChanged() Handles GageDistanceSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siGageDistance As Single = Me.GageDistanceSingle.SiValue
            If Not (mFlume.GageDistance = siGageDistance) Then
                mFlume.GageDistance = siGageDistance
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub ConvergeLengthSingle_ValueChanged() Handles ConvergeLengthSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siConvergeLength As Single = Me.ConvergeLengthSingle.SiValue
            If Not (mFlume.ConvergeLength = siConvergeLength) Then
                mFlume.ConvergeLength = siConvergeLength
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub RadiusSingle_ValueChanged() Handles RadiusSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siRadius As Single = Me.RadiusSingle.SiValue
            If Not (mFlume.RadiusMovable = siRadius) Then
                mFlume.RadiusMovable = siRadius
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub ControlLengthSingle_ValueChanged() Handles ControlLengthSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siControlLength As Single = Me.ControlLengthSingle.SiValue
            If Not (mFlume.ControlLength = siControlLength) Then
                mFlume.ControlLength = siControlLength
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub ExpansionLengthSingle_ValueChanged() Handles ExpansionLengthSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siExpansionLength As Single = Me.ExpansionLengthSingle.SiValue
            If Not (mFlume.ExpansionLength = siExpansionLength) Then

                Dim siExpansionSlope As Single = 0
                Dim siSillHeight As Single = mFlume.SillHeight
                Dim siBedDrop As Single = mFlume.BedDrop
                If (0 < (siSillHeight + siBedDrop)) Then
                    siExpansionSlope = siExpansionLength / (siSillHeight + siBedDrop)
                Else
                End If

                If Not (mFlume.ExpansionSlopeZ = siExpansionSlope) Then
                    mFlume.ExpansionSlopeZ = siExpansionSlope
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Private Sub ExpansionSlopeSingle_ValueChanged() Handles ExpansionSlopeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siExpansionSlope As Single = Me.ExpansionSlopeSingle.SiValue
            If Not (mFlume.ExpansionSlopeZ = siExpansionSlope) Then
                mFlume.ExpansionSlopeZ = siExpansionSlope
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub SillHeightSingle_ValueChanged() Handles SillHeightSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siSillHeight As Single = Me.SillHeightSingle.SiValue
            If (WinFlumeForm.ValidateSillHeight(siSillHeight)) Then
                If (mFlume.SillHeight <> siSillHeight) Then
                    mFlume.SillHeight = siSillHeight

                    ' Check if Control section's D1 should track Sill Height changes
                    Dim apprSection As Flume.SectionType = mFlume.Section(cApproach)
                    Dim ctrlSection As Flume.SectionType = mFlume.Section(cControl)
                    If (ctrlSection.GetType Is GetType(WinFlumeSectionType)) Then
                        Dim winFlumeSection As WinFlumeSectionType = DirectCast(ctrlSection, WinFlumeSectionType)
                        Dim MatchConstraints As Integer = winFlumeSection.MatchConstraints

                        If (BitSet(MatchConstraints, MatchConstraint.InnerSillHeightMatchesProfileSillHeight)) Then
                            ctrlSection.D1 = siSillHeight

                            Dim apprTW As Single = apprSection.TopWidth(siSillHeight, False)
                            Select Case winFlumeSection.Shape
                                Case shTrapezoidInParabola, shTrapezoidInRectangle, shTrapezoidInTrapezoid,
                                     shTrapezoidInUShaped, shTrapezoidInVShaped
                                    If (ctrlSection.BottomWidth > apprTW) Then
                                        ctrlSection.BottomWidth = apprTW
                                    End If
                                Case shSillInRectangle, shSillInTrapezoid, shSillInVShaped
                                    ctrlSection.BottomWidth = apprTW
                            End Select
                        End If
                    End If

                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            Else
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub BedDropSingle_ValueChanged() Handles BedDropSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim siBedDrop As Single = Me.BedDropSingle.SiValue
            If Not (mFlume.BedDrop = siBedDrop) Then
                mFlume.BedDrop = siBedDrop
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub AbruptExpansion_ValueChanged(ByVal NewValue As Integer) _
        Handles AbruptExpansionButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.ExpansionRampStyle = NewValue) Then
                mFlume.ExpansionRampStyle = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub GradualExpansion_ValueChanged(ByVal NewValue As Integer) _
        Handles GradualExpansionButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.ExpansionRampStyle = NewValue) Then
                mFlume.ExpansionRampStyle = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub TruncatedExpansion_ValueChanged(ByVal NewValue As Integer) _
    Handles TruncatedRampButton.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mFlume.ExpansionRampStyle = NewValue) Then
                mFlume.ExpansionRampStyle = NewValue
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub MaxWspCheckBox_ValueChanged() Handles MaxWspCheckBox.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            WinFlumeForm.ShowMaxWSP = Me.MaxWspCheckBox.Value
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

    Private Sub MinWspCheckBox_ValueChanged() Handles MinWspCheckBox.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            WinFlumeForm.ShowMinWSP = Me.MinWspCheckBox.Value
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

#End Region

End Class
