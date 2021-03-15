
'**********************************************************************************************
' grf_XYGraph provides enhanced graphics support for drawing XY Graphs.
'
' The graph is drawn as a Bitmap.
'
Imports DataStore
Imports GraphingUI

Public Class grf_XYGraph
    Inherits ctl_Graph2D

#Region " Contructor(s) "

    Public Sub New()
        MyBase.New()
        Me.FontName = WinSRFR.UserPreferences.SelectedFont
        Me.FontAdjustment = WinSRFR.UserPreferences.FontAdjustment
    End Sub

    Public Sub New(ByVal _dataSet As DataSet)
        MyBase.New(_dataSet)
        Me.FontName = WinSRFR.UserPreferences.SelectedFont
        Me.FontAdjustment = WinSRFR.UserPreferences.FontAdjustment
    End Sub

    Protected Overrides Sub DisposeGraph2D()
        MyBase.DisposeGraph2D()
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " Mouse Events "

    Protected Overrides Sub PictureBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        ' Handles MyBase.PictureBox_MouseMove

        ' Get reference to the XY graph
        Dim _xyGraph As grf_XYGraph = DirectCast(sender, grf_XYGraph)

        Try
            ' Don't bother handling mouse event if graph is not visible
            If (_xyGraph.Visible) Then
                Dim rect As Rectangle = _xyGraph.GraphRect

                ' Is mouse within the contour plot?
                If (rect.Contains(e.X, e.Y)) Then
                    '
                    ' Shift-mouse selects convas objects in baseclass
                    '
                    If ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then
                        Exit Try
                    End If
                    '
                    ' Standard mouse move displays position tooltip
                    '

                    ' Get cursor position within contour rectangle
                    Dim xCursor, yCursor As Integer

                    If (_xyGraph.PosDirX = ctl_Graph2D.PositiveDirection.PosRight) Then
                        xCursor = e.X - rect.X
                    Else
                        xCursor = rect.X - e.X
                    End If

                    If (_xyGraph.PosDirY = ctl_Graph2D.PositiveDirection.PosUp) Then
                        yCursor = rect.Y + rect.Height - e.Y
                    Else
                        yCursor = e.Y - rect.Y
                    End If

                    ' Convert position to SI data values
                    Dim x As Double = mMinX + ((mMaxX - mMinX) * xCursor) / rect.Width
                    Dim y As Double = mMinY + ((mMaxY - mMinY) * yCursor) / rect.Height

                    ' Convert position SI values to display values
                    Dim xUnits As Units = mUnitsSystem.DisplayUnits(Me.UnitsX)
                    Dim yUnits As Units = mUnitsSystem.DisplayUnits(Me.UnitsY)

                    Dim xText As String = UnitTextWithUnits(x, xUnits)
                    Dim yText As String = UnitTextWithUnits(y, yUnits)

                    Dim xName As String = Me.NameX
                    Dim yName As String = Me.NameY

                    ' Build basic tooltip; i.e. no value just position
                    Dim toolTip As String = xName + " = " + xText + Chr(10) _
                                          + yName + " = " + yText

                    ' Show tooltip
                    _xyGraph.Cursor = Cursors.Cross
                    _xyGraph.ToolTip.Active = True
                    _xyGraph.ToolTip.ShowAlways = True
                    _xyGraph.ToolTip.SetToolTip(_xyGraph, toolTip)

                    ' Mouse event handled here; don't pass it on
                    Return
                End If ' Mouse is within graph rectangle

                ' Outside contour plot, turn tooltip off
                _xyGraph.ToolTip.Active = False

            End If
        Catch ex As Exception
        End Try

        ' If not handled here, let the base class
        MyBase.PictureBox_MouseMove(sender, e)

    End Sub

#End Region

#End Region

End Class
