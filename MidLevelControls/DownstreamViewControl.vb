
'*************************************************************************************************************
' Class DownstreamViewControl - UserControl for displaying the downstream view of the flume
'*************************************************************************************************************
Imports System.Windows
Imports Flume.Globals

Public Class DownstreamViewControl

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
    '
    ' Support for drawing cross section graphics
    '
    Protected mControl As CrossSectionControl = Nothing
    Protected mTailwater As CrossSectionControl = Nothing

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - update Bottom Profile UI
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume                ' Access to top level methods / events
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data
        End If
        Me.UpdateUI()
    End Sub

    Protected Sub UpdateUI()
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data
            Me.Refresh()                        ' Causes OnPaint() to be called
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub UpdateDownstreamView() - draw downstream view graphics
    '
    ' Input(s):     eGraphics   - Graphics handle provided by Windows via OnPaint()
    '*********************************************************************************************************
    Protected Sub UpdateDownstreamView(ByVal eGraphics As System.Drawing.Graphics)

        If (mFlume Is Nothing) Then ' Can't update until Flume data is available
            Return
        End If

        Try
            ' Define Viewport for graphics
            Dim ViewPort As RectangleF = New RectangleF With {
                .X = Me.Margin.Horizontal * 2,
                .Y = Me.Margin.Vertical * 5
            }
            ViewPort.Width = Me.Size.Width - 3 * ViewPort.X
            ViewPort.Height = Me.Size.Height - ViewPort.Y - Me.Margin.Vertical

            ' Draw downstream view
            DrawDownstreamView(ViewPort, eGraphics)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub

    Public Sub DrawDownstreamView(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics)
        Try
            ' Get cross section controls for downstream view
            mControl = mWinFlumeForm.GetControlCrossSectionControl
            mTailwater = mWinFlumeForm.GetTailwaterCrossSectionControl

            ' Check for alternate FlumeType from AlternativeDesigns
            'Dim ReviewDesignCtrl As AlternativeDesignsControl = mWinFlumeForm.GetAlternativeDesignsControl
            'If (ReviewDesignCtrl.Visible) Then
            '    Dim designFlume As FlumeType = ReviewDesignCtrl.CurrentFlume
            '    mControl.InitializeCrossSection(cControl, designFlume)
            '    mTailwater.InitializeCrossSection(cTailwater, designFlume)
            'End If
            '
            ' Drawing order for downstream view (upstream to downstream, mostly)
            '
            ' Start with Control's outer outline (this may be partially obscured by expansion section)
            '
            mControl.DrawOuterCrossSection(cControl, ViewPort, eGraphics, HalfBluePen2)
            '
            ' Continue with Expansion section
            '
            Dim rampStyle As Integer = mFlume.ExpansionRampStyle
            If (mFlume.ExpansionSlopeZ <= 0) Then
                rampStyle = cNoRamp
            End If

            If (mFlume.CrestType = MovableCrest) Then
                rampStyle = cNoRamp
            End If

            Select Case (rampStyle)

                Case cNoRamp
                    '
                    '   1) Control/Tailwater face
                    '
                    Me.DrawDownstreamFace(ViewPort, eGraphics, BlackPen2)

                Case cFullRamp
                    '
                    '   1) Left, right sides of expansion
                    '   2) Tailwater ramp
                    '
                    Me.DrawDownstreamLeftSide(ViewPort, eGraphics, BlackPen1)
                    Me.DrawDownstreamRightSide(ViewPort, eGraphics, BlackPen1)
                    Me.DrawDownstreamRamp(ViewPort, eGraphics, BlackPen1)

                Case cTruncatedRamp
                    '
                    '   1) Control/Tailwater face
                    '   2) Truncated tailwater ramp
                    '
                    Me.DrawDownstreamFace(ViewPort, eGraphics, BlackPen1)
                    Me.DrawTruncatedRamp(ViewPort, eGraphics, BlackPen1)

                Case Else
                    Debug.Assert(False, "Invalid Expansion Ramp")
            End Select
            '
            ' Finish with inner outlines
            '   1) Control's inner outline
            '   2) Tailwater's inner outline
            '
            mControl.DrawInnerCrossSection(cControl, ViewPort, eGraphics, BluePen2)
            mTailwater.DrawInnerCrossSection(cTailwater, ViewPort, eGraphics, BlackPen2)

            ' Add outer trapezoid for Complex Trapezoid
            If (mTailwater.GetType Is GetType(ComplexTrapezoidControl)) Then
                mTailwater.DrawOuterCrossSection(cTailwater, ViewPort, eGraphics, BlackPen1)
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        Finally
            ' Return to current WinFlume FlumeType
            'mControl.InitializeCrossSection(cControl, Nothing)
            'mTailwater.InitializeCrossSection(cTailwater, Nothing)
        End Try
    End Sub

    Protected Sub DrawDownstreamFace(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics,
                                     ByVal dPen As Drawing.Pen)
        Try
            '
            ' Build polygon representing the control/tailwater face using:
            '   1) Tailwater cross section's left/right edges
            '   2) Control cross section's left/right edges
            '
            Dim tlEdge As PointF() = mTailwater.LeftEdgeOutline(cTailwater, ViewPort)
            Dim trEdge As PointF() = mTailwater.RightEdgeOutline(cTailwater, ViewPort)
            Dim clEdge As PointF() = mControl.LeftEdgeOutline(cControl, ViewPort)
            Dim crEdge As PointF() = mControl.RightEdgeOutline(cControl, ViewPort)

            clEdge = clEdge.Reverse().ToArray
            crEdge = crEdge.Reverse().ToArray

            Dim face As PointF() = tlEdge.Concat(trEdge).ToArray

            face = face.Concat(crEdge).ToArray
            face = face.Concat(clEdge).ToArray

            ' Fill & draw polygon to depict face of control/tailwater channel
            eGraphics.FillPolygon(LightGraySemiTransparentBrush, face)
            eGraphics.DrawPolygon(dPen, face)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Protected Sub DrawDownstreamLeftSide(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics,
                                         ByVal dPen As Drawing.Pen)
        Try
            '
            ' Build polygon representing the tailwater channel's left side using:
            '   1) Tailwater cross section's left edge
            '   2) Control cross section's left edge
            '
            Dim tEdge As PointF() = mTailwater.LeftEdgeOutline(cTailwater, ViewPort)
            Dim cEdge As PointF() = mControl.LeftEdgeOutline(cControl, ViewPort)

            cEdge = cEdge.Reverse().ToArray
            Dim leftSide As PointF() = tEdge.Concat(cEdge).ToArray

            ' Fill & draw polygon to depict left side of tailwater channel
            eGraphics.FillPolygon(LightGraySemiTransparentBrush, leftSide)
            eGraphics.DrawPolygon(dPen, leftSide)

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Protected Sub DrawDownstreamRightSide(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics,
                                          ByVal dPen As Drawing.Pen)
        Try
            '
            ' Build polygon representing the tailwater channel's right side
            '   1) Tailwater cross section's right edge
            '   2) Control cross section's right edge
            '
            Dim tEdge As PointF() = mTailwater.RightEdgeOutline(cTailwater, ViewPort)
            Dim cEdge As PointF() = mControl.RightEdgeOutline(cControl, ViewPort)

            cEdge = cEdge.Reverse().ToArray
            Dim rightSide As PointF() = tEdge.Concat(cEdge).ToArray

            ' Fill & draw polygon to depict left side of tailwater channel
            eGraphics.FillPolygon(LightGraySemiTransparentBrush, rightSide)
            eGraphics.DrawPolygon(dPen, rightSide)

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Protected Sub DrawDownstreamRamp(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics,
                                     ByVal dPen As Drawing.Pen)
        Try
            '
            ' Build polygon representing the tailwater channel's ramp (invert to sill)
            '   1) Tailwater cross section's invert
            '   2) Control cross section's sill
            '
            Dim tEdge As PointF() = mTailwater.InvertOutline(cTailwater, ViewPort)
            Dim cEdge As PointF() = mControl.SillOutline(cControl, ViewPort)

            cEdge = cEdge.Reverse().ToArray
            Dim ramp As PointF() = tEdge.Concat(cEdge).ToArray

            ' Fill & draw polygon to depict ramp of tailwater channel
            eGraphics.FillPolygon(MediumGraySemiTransparentBrush, ramp)
            eGraphics.DrawPolygon(dPen, ramp)

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Protected Sub DrawTruncatedRamp(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics,
                                    ByVal dPen As Drawing.Pen)
        Try
            '
            ' Build polygon representing the tailwater channel's ramp (invert to sill)
            '   1) Tailwater cross section's truncated ramp edge
            '   2) Control cross section's sill
            '
            Dim rEdge As PointF() = mTailwater.TruncatedRampOutline(cTailwater, ViewPort)
            Dim cEdge As PointF() = mControl.SillOutline(cControl, ViewPort)
            cEdge = cEdge.Reverse().ToArray
            Dim ramp As PointF() = rEdge.Concat(cEdge).ToArray
            ' Fill & draw polygon to depict ramp of tailwater channel
            eGraphics.FillPolygon(MediumGraySemiTransparentBrush, ramp)
            eGraphics.DrawPolygon(dPen, ramp)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Sub OnPaint() - re-draw graphics when Control needs painting
    '*********************************************************************************************************
    Protected Overrides Sub OnPaint(ByVal e As Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.UpdateDownstreamView(e.Graphics)
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged() - event handler; update UI whenever Flume data changes
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
