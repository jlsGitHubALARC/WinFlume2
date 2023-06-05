
'*************************************************************************************************************
' Class UpstreamViewControl  - UserControl for displaying the upstream view of the flume
'*************************************************************************************************************
Imports System.Windows
Imports Flume
Imports Flume.Globals

Public Class UpstreamViewControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Protected mFlume As Flume.FlumeType = Nothing
    '
    ' Support for drawing cross section graphics
    '
    Protected mControl As CrossSectionControl = Nothing
    Protected mApproach As CrossSectionControl = Nothing

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
    ' Sub UpdateUpstreamView() - draw upstream view graphics
    '
    ' Input(s):     eGraphics   - Graphics handle provided by Windows via OnPaint()
    '*********************************************************************************************************
    Protected Sub UpdateUpstreamView(ByVal eGraphics As System.Drawing.Graphics)

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

            ' Draw upstream view
            DrawUpstreamView(ViewPort, eGraphics)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub

    Public Sub DrawUpstreamView(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics)
        Try
            ' Get cross section controls for upstream view
            mControl = mWinFlumeForm.GetControlCrossSectionControl
            mApproach = mWinFlumeForm.GetApproachCrossSectionControl

            ' Check for alternate FlumeType from AlternativeDesigns
            'Dim ReviewDesignCtrl As AlternativeDesignsControl = mWinFlumeForm.GetAlternativeDesignsControl
            'If (ReviewDesignCtrl.Visible) Then
            '    Dim designFlume As FlumeType = ReviewDesignCtrl.CurrentFlume
            '    mControl.InitializeCrossSection(cControl, designFlume)
            '    mApproach.InitializeCrossSection(cApproach, designFlume)
            'End If

            ' Upstream View depends on Crest Type selection
            Dim crestType As Integer = mFlume.CrestType

            Select Case (crestType)
                Case StationaryCrest
                    '
                    ' Drawing order for upstream view (downstream to upstream, mostly):
                    '   1) Control's outer outline
                    '   2) Left, right sides of approach
                    '   3) Approach ramp (this may obscure part of control's outer outline
                    '   4) Control's inner outline
                    '   5) Approach's inner outline
                    '
                    mControl.DrawOuterCrossSection(cControl, ViewPort, eGraphics, HalfBluePen2)
                    Me.DrawUpstreamLeftSide(ViewPort, eGraphics, BlackPen1)
                    Me.DrawUpstreamRightSide(ViewPort, eGraphics, BlackPen1)
                    Me.DrawUpstreamRamp(ViewPort, eGraphics, BlackPen1)
                    mControl.DrawInnerCrossSection(cControl, ViewPort, eGraphics, BluePen2)
                    mApproach.DrawInnerCrossSection(cApproach, ViewPort, eGraphics, BlackPen2)
                Case MovableCrest
                    '
                    ' Build polygon representing the control/approach face using:
                    '   1) Approach cross section's left/right edges
                    '   2) Control cross section's left/right edges
                    '
                    Dim alEdge As PointF() = mApproach.LeftEdgeOutline(cApproach, ViewPort)
                    Dim arEdge As PointF() = mApproach.RightEdgeOutline(cApproach, ViewPort)
                    Dim clEdge As PointF() = mControl.LeftEdgeOutline(cControl, ViewPort)
                    Dim crEdge As PointF() = mControl.RightEdgeOutline(cControl, ViewPort)
                    clEdge = clEdge.Reverse().ToArray
                    crEdge = crEdge.Reverse().ToArray
                    Dim face As PointF() = alEdge.Concat(arEdge).ToArray
                    face = face.Concat(crEdge).ToArray
                    face = face.Concat(clEdge).ToArray
                    ' Fill & draw polygon to depict face of control/approach channel
                    eGraphics.FillPolygon(LightGraySemiTransparentBrush, face)
                    eGraphics.DrawPolygon(BlackPen2, face)
                    ' Highlight Control section
                    mControl.DrawOuterCrossSection(cControl, ViewPort, eGraphics, HalfBluePen2)
                    mControl.DrawInnerCrossSection(cControl, ViewPort, eGraphics, BluePen2)
                Case Else
                    Debug.Assert(False, "Invalid Crest Type")
            End Select

            ' Add outer trapezoid for Complex Trapezoid
            If (mApproach.GetType Is GetType(ComplexTrapezoidControl)) Then
                mApproach.DrawOuterCrossSection(cApproach, ViewPort, eGraphics, BlackPen1)
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        Finally
            ' Return to current WinFlume FlumeType
            'mControl.InitializeCrossSection(cControl, Nothing)
            'mApproach.InitializeCrossSection(cApproach, Nothing)
        End Try
    End Sub

    Protected Sub DrawUpstreamLeftSide(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics,
                                       ByVal dPen As Drawing.Pen)
        Try
            '
            ' Build polygon representing the approach channel's left side using:
            '   1) Approach cross section's left edge
            '   2) Control cross section's left edge
            '
            Dim aEdge As PointF() = mApproach.LeftEdgeOutline(cApproach, ViewPort)
            Dim cEdge As PointF() = mControl.LeftEdgeOutline(cControl, ViewPort)
            cEdge = cEdge.Reverse().ToArray
            Dim leftSide As PointF() = aEdge.Concat(cEdge).ToArray
            ' Fill & draw polygon to depict left side of approach channel
            eGraphics.FillPolygon(LightGraySemiTransparentBrush, leftSide)
            eGraphics.DrawPolygon(dPen, leftSide)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Protected Sub DrawUpstreamRightSide(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics,
                                        ByVal dPen As Drawing.Pen)
        Try
            '
            ' Build polygon representing the approach channel's right side
            '   1) Approach cross section's right edge
            '   2) Control cross section's right edge
            '
            Dim aEdge As PointF() = mApproach.RightEdgeOutline(cApproach, ViewPort)
            Dim cEdge As PointF() = mControl.RightEdgeOutline(cControl, ViewPort)
            cEdge = cEdge.Reverse().ToArray
            Dim rightSide As PointF() = aEdge.Concat(cEdge).ToArray
            ' Fill & draw polygon to depict right side of approach channel
            eGraphics.FillPolygon(LightGraySemiTransparentBrush, rightSide)
            eGraphics.DrawPolygon(dPen, rightSide)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Protected Sub DrawUpstreamRamp(ByVal ViewPort As RectangleF, ByVal eGraphics As Drawing.Graphics,
                                   ByVal dPen As Drawing.Pen)
        Try
            '
            ' Build polygon representing the approach channel's ramp (invert to sill)
            '   1) Approach cross section's invert
            '   2) Control cross section's sill
            '
            Dim aEdge As PointF() = mApproach.InvertOutline(cApproach, ViewPort)
            Dim cEdge As PointF() = mControl.SillOutline(cControl, ViewPort)
            cEdge = cEdge.Reverse().ToArray
            Dim ramp As PointF() = aEdge.Concat(cEdge).ToArray
            ' Fill & draw polygon to depict ramp of approach channel
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
        Try ' Catch, but ignore, exceptions
            Me.UpdateUpstreamView(e.Graphics)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged() - event handler; update UI whenever Flume data changes
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

#End Region

End Class
