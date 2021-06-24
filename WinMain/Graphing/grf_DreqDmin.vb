
'*************************************************************************************************************
' Class grf_DreqDmin    - displays the Dreq = Dmin graph for Operations World
'*************************************************************************************************************
Imports System.Runtime.InteropServices

Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI

Public Class grf_DreqDmin
    Inherits grf_X2YGraph

#Region " Member Data "
    '
    ' Reference to World Window presenting the contours
    '
    Protected mWorldWindow As WorldWindow

    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' Extra tooltip data
    '
    Protected mXRtable As DataTable     ' XR curve
    Protected mXR As Double             ' XR cursor value

#End Region

#Region " Contructor(s) "

    Public Sub New(ByVal worldWindow As WorldWindow)
        MyBase.New()
        mWorldWindow = worldWindow
    End Sub

    Public Sub New(ByVal worldWindow As WorldWindow, ByVal _dataSet As DataSet)
        MyBase.New(_dataSet)
        ' Extract extra tooltip data from DataSet
        If (2 < mDataSet.Tables.Count) Then
            mXRtable = mDataSet.Tables(2)
            mDataSet.Tables.RemoveAt(2)
        End If
        ' Save reference to World Window
        mWorldWindow = worldWindow
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " Mouse Events "

    Protected Overrides Sub PictureBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        ' Handles MyBase.PictureBox_MouseMove

        ' Get reference to the Dreq = Dmin graph
        Dim _x2yGraph As grf_DreqDmin = DirectCast(sender, grf_DreqDmin)

        Try
            ' Don't bother handling event if graph is not visible
            If (_x2yGraph.Visible) Then

                Dim rect As Rectangle = _x2yGraph.GraphRect
                If (rect.Contains(e.X, e.Y)) Then ' mouse position is within graph
                    '
                    ' Standard mouse move displays vertical line cursor then tooltip
                    '

                    ' Get cursor position within graph rectangle
                    Dim xCursor, yCursor As Integer

                    If (_x2yGraph.PosDirX = ctl_Graph2D2Y.PositiveDirection.PosRight) Then
                        xCursor = e.X - rect.X
                    Else
                        xCursor = rect.X - e.X
                    End If

                    If (_x2yGraph.PosDirY = ctl_Graph2D2Y.PositiveDirection.PosUp) Then
                        yCursor = rect.Y + rect.Height - e.Y
                    Else
                        yCursor = e.Y - rect.Y
                    End If
                    '
                    ' Display vertical line cursor
                    '
                    If (mVertLine) Then ' erase previously drawn vertical line
                        mVertLine = False
                        _x2yGraph.Refresh()
                    End If

                    ' Get Display resolution (from Display Settings) (i.e physical size)
                    Dim grf As Graphics = _x2yGraph.mGraphics
                    Dim hdc As IntPtr = grf.GetHdc
                    Dim siz As New Size(GetDeviceCaps(hdc, DESKTOPHORZRES), GetDeviceCaps(hdc, DESKTOPVERTRES))
                    grf.ReleaseHdc(hdc)

                    ' Get Display resolution (after scaling) (i.e. logical size)
                    Dim scr As Screen = Screen.FromControl(_x2yGraph)
                    Dim bnd As Rectangle = scr.Bounds

                    ' Compute ratio of resolution change
                    Dim scaleX As Double = siz.Width / bnd.Width
                    Dim scaleY As Double = siz.Height / bnd.Height

                    ' Draw a vertical line at the cursor's X position
                    mLine1Pt1 = _x2yGraph.PointToScreen(New Point(e.X, rect.Y))
                    mLine1Pt1.X *= scaleX
                    mLine1Pt1.Y *= scaleY

                    mLine1Pt2 = _x2yGraph.PointToScreen(New Point(e.X, e.Y - 7))
                    mLine1Pt2.X *= scaleX
                    mLine1Pt2.Y *= scaleY

                    ControlPaint.DrawReversibleLine(mLine1Pt1, mLine1Pt2, Drawing.Color.Black)

                    mLine2Pt1 = _x2yGraph.PointToScreen(New Point(e.X, Math.Min(e.Y + 7, rect.Y + rect.Height)))
                    mLine2Pt1.X *= scaleX
                    mLine2Pt1.Y *= scaleY

                    mLine2Pt2 = _x2yGraph.PointToScreen(New Point(e.X, rect.Y + rect.Height))
                    mLine2Pt2.X *= scaleX
                    mLine2Pt2.Y *= scaleY

                    ControlPaint.DrawReversibleLine(mLine2Pt1, mLine2Pt2, Drawing.Color.Black)

                    mVertLine = True

                    ' Show cursor
                    _x2yGraph.Cursor = Cursors.NoMoveHoriz

                    ' Start building tooltip with X-axis data
                    mX = mMinX + ((mMaxX - mMinX) * xCursor) / rect.Width
                    Dim xUnits As Units = mUnitsSystem.DisplayUnits(Me.UnitsX)
                    Dim xText As String = UnitTextWithUnits(mX, xUnits)
                    Dim xName As String = Me.NameX

                    Dim toolTip As String = xName & " = " & xText

                    ' Get y values from DataSet
                    If (2 <= mDataSet.Tables.Count) Then
                        Dim sdx As Integer
                        ' Add data from left Y-axis curves
                        Dim leftAxisCurves As DataTable = mDataSet.Tables(0)
                        Dim y1Units As Units = mUnitsSystem.DisplayUnits(Me.UnitsY)

                        For cdx As Integer = 1 To leftAxisCurves.Columns.Count - 1 ' column 0 is X-axis data
                            Dim yName As String = leftAxisCurves.Columns(cdx).ColumnName.Trim
                            sdx = yName.IndexOf(" ")
                            If (0 < sdx) Then
                                yName = yName.Substring(0, sdx)
                            End If

                            mY1 = GetYforX(leftAxisCurves, 0, mX, cdx)
                            Dim y1Text As String = UnitTextWithUnits(mY1, y1Units)

                            toolTip &= Chr(10) & yName & " = " & y1Text
                        Next

                        ' Add data from right Y-axis curve
                        Dim rightAxisCurve As DataTable = mDataSet.Tables(1)
                        Dim y2Units As Units = mUnitsSystem.DisplayUnits(Me.UnitsY2)

                        Dim y2Name As String = rightAxisCurve.Columns(1).ColumnName.Trim
                        sdx = y2Name.IndexOf(" ")
                        If (0 < sdx) Then
                            y2Name = y2Name.Substring(0, sdx)
                        End If

                        mY2 = GetYforX(rightAxisCurve, 0, mX, 1)
                        Dim y2Text As String = UnitTextWithUnits(mY2, y2Units)

                        toolTip &= Chr(10) & y2Name & " = " & y2Text

                        ' Finish with XR data
                        Dim rUnits As Units = Units.None
                        mXR = GetYforX(mXRtable, 0, mX, 1)
                        Dim rText As String = UnitTextWithUnits(mXR, rUnits)
                        Dim xrName As String = "XR"

                        toolTip &= Chr(10) & xrName & " = " & rText
                        '
                        ' Ctrl-mouse redraws Water Distribution Diagram if it is being displayed
                        '
                        If ((Control.ModifierKeys And Keys.Control) = Keys.Control) Then ' Ctrl key is down
                            If (mWorldWindow.WDD IsNot Nothing) Then
                                ' Turn off tooltip
                                _x2yGraph.ToolTip.Active = False
                                ' Graph Water Distribution Diagram
                                mWorldWindow.WDD.SetXY(mY2, mX)
                            End If

                            Return ' Mouse event handled here; don't pass it on
                        End If

                        ' Show tooltip
                        _x2yGraph.Cursor = Cursors.NoMoveHoriz
                        _x2yGraph.ToolTip.Active = True
                        _x2yGraph.ToolTip.ShowAlways = True
                        _x2yGraph.ToolTip.SetToolTip(_x2yGraph, toolTip)

                        Return ' Mouse event handled here; don't pass it on
                    End If
                End If ' Mouse within graph rectangle

                ' Erase previously drawn vertical line
                If (mVertLine) Then
                    mVertLine = False
                    _x2yGraph.Refresh()
                End If
            End If
        Catch ex As Exception
        End Try

        ' If not handled here, let the base class
        MyBase.PictureBox_MouseMove(sender, e)

    End Sub

    Protected Sub ChooseSolution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles ChooseSolution.Click (menu items are dynamically created by PictureBoxMenu_Popup()

        Try
            ' Get x, y values from DataSet
            If (2 <= mDataSet.Tables.Count) Then

                ' Use the Water Distribution Diagram to choose the Solution
                If (mWorldWindow.WDD IsNot Nothing) Then
                    mWorldWindow.WDD.Dispose()
                    mWorldWindow.WDD = Nothing
                End If

                mWorldWindow.WDD = New WaterDistributionDiagram(mWorldWindow, mY2, mX)
                UpdateTranslation(mWorldWindow.WDD, mWorldWindow.WinSrfr.Language)
                mWorldWindow.WDD.Show()
            End If

        Catch ex As Exception
        End Try

    End Sub

    Protected Overrides Sub PictureBoxMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Handles MyBase.PictureBoxMenu_Popup

        ' Have base case start popup
        MyBase.PictureBoxMenu_Popup(sender, e)

        ' Add popup menu items
        If Not (Me.Image Is Nothing) Then
            PictureBoxMenu.MenuItems.Add("-")   ' Separator
            PictureBoxMenu.MenuItems.Add(mDictionary.tChooseSolutionAtPoint.Translated & "...", _
                                          New EventHandler(AddressOf ChooseSolution_Click))
        End If

    End Sub

#End Region

#End Region

End Class
