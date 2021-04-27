
'**********************************************************************************************
' grf_X2YGraph provides enhanced graphics support for drawing XY Graphs w/ 2 Y axes.
'
' The graph is drawn as a Bitmap.
'
Imports DataStore
Imports GraphingUI

Public Class grf_X2YGraph
    Inherits ctl_Graph2D2Y

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

    Public Overrides Sub DisposeGraph2D()
        MyBase.DisposeGraph2D2Y()
    End Sub

#End Region

#Region " Member Data "

    ' Vertical line control
    Protected mVertLine As Boolean = False
    Protected mLine1Pt1, mLine1Pt2 As Point
    Protected mLine2Pt1, mLine2Pt2 As Point
    Protected mLastX, mLastY As Integer

    ' Cursor values
    Protected mX, mY1, mY2 As Double

#End Region

#Region " UI Event Handlers "

#Region " Mouse Events "

    Protected Overrides Sub PictureBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        ' Handles MyBase.PictureBox_MouseMove

        ' Get reference to the X2Y graph
        Dim _x2yGraph As grf_X2YGraph = DirectCast(sender, grf_X2YGraph)

        ' Don't bother handling event if mouse hasn't moved; unless tooltip is down
        If ((mLastX = e.X) And (mLastY = e.Y)) Then
            If (_x2yGraph.ToolTip.GetToolTip(_x2yGraph) = String.Empty) Then
                Return
            End If
        Else
            mLastX = e.X ' Save new mouse position
            mLastY = e.Y
        End If

        Try
            ' Don't bother handling event if graph is not visible
            If (_x2yGraph.Visible) Then
                Dim rect As Rectangle = _x2yGraph.GraphRect

                ' Is mouse within the contour plot?
                If (rect.Contains(e.X, e.Y)) Then
                    '
                    ' Standard mouse move displays position tooltip
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

                    ' Erase previously drawn vertical line
                    If (mVertLine) Then
                        mVertLine = False
                        _x2yGraph.Refresh()
                    End If

                    ' Draw a vertical line at the cursor's X position
                    mLine1Pt1 = _x2yGraph.PointToScreen(New Point(e.X, rect.Y))
                    mLine1Pt2 = _x2yGraph.PointToScreen(New Point(e.X, e.Y - 7))
                    ControlPaint.DrawReversibleLine(mLine1Pt1, mLine1Pt2, Drawing.Color.Black)

                    mLine2Pt1 = _x2yGraph.PointToScreen(New Point(e.X, Math.Min(e.Y + 57, rect.Y + rect.Height)))
                    mLine2Pt2 = _x2yGraph.PointToScreen(New Point(e.X, rect.Y + rect.Height))
                    ControlPaint.DrawReversibleLine(mLine2Pt1, mLine2Pt2, Drawing.Color.Black)

                    mVertLine = True

                    ' Get x, y values from DataSet
                    If (2 <= mDataSet.Tables.Count) Then
                        Dim curve1 As DataTable = mDataSet.Tables(0)
                        Dim curve2 As DataTable = mDataSet.Tables(1)

                        ' Convert position to SI data values
                        mX = mMinX + ((mMaxX - mMinX) * xCursor) / rect.Width
                        mY1 = GetYforX(curve1, 0, mX, 1)

                        ' Convert position SI values to display values
                        Dim xUnits As Units = mUnitsSystem.DisplayUnits(Me.UnitsX)
                        Dim y1Units As Units = mUnitsSystem.DisplayUnits(Me.UnitsY)

                        Dim xText As String = UnitTextWithUnits(mX, xUnits)
                        Dim y1Text As String = UnitTextWithUnits(mY1, y1Units)

                        Dim xName As String = Me.NameX
                        Dim yName As String = Me.NameY

                        ' Build basic tooltip; i.e. no value just position
                        Dim toolTip As String = xName + " = " + xText + Chr(10) _
                                              + yName + " = " + y1Text

                        ' Add curve 2 value, if one exists
                        Dim row2 As DataRow = curve2.Rows(curve2.Rows.Count - 1)
                        If (mX <= row2.Item(0)) Then
                            mY2 = GetYforX(curve2, 0, mX, 1)
                            Dim y2Units As Units = mUnitsSystem.DisplayUnits(Me.UnitsY2)
                            Dim y2Text As String = UnitTextWithUnits(mY2, y2Units)
                            Dim y2Name As String = Me.NameY2

                            toolTip += Chr(10) + y2Name + " = " + y2Text
                        End If

                        ' Show tooltip
                        _x2yGraph.Cursor = Cursors.NoMoveHoriz
                        _x2yGraph.ToolTip.Active = True
                        _x2yGraph.ToolTip.ShowAlways = True
                        _x2yGraph.ToolTip.SetToolTip(_x2yGraph, toolTip)
                    Else
                        ' Not enough data, turn tooltip off
                        _x2yGraph.ToolTip.Active = False
                    End If

                    Return ' Mouse event handled here; don't pass it on
                End If ' Mouse within graph rectangle

                ' Outside contour plot, turn tooltip off
                _x2yGraph.ToolTip.Active = False
                _x2yGraph.ToolTip.SetToolTip(_x2yGraph, String.Empty)

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

    Protected Overrides Sub PictureBox_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        'Handles MyBase.PictureBox_MouseLeave

        ' Get reference to the X2Y graph
        Dim _x2yGraph As grf_X2YGraph = DirectCast(sender, grf_X2YGraph)

        ' Erase previously drawn vertical line
        If (mVertLine) Then
            mVertLine = False
            _x2yGraph.Refresh()
        End If
    End Sub

#End Region

#Region " Clipboard Methods "
    '
    ' CopyDataSetAsText() - copies DataSet to the clipboard
    '
    ' Copy uses Tabs to separate text as Tabs work with both Word & Excel
    '
    ' When _copy is true, data is transferred to the clipboard.  This allows for chaining
    ' several sets of data together as one clipboard object.  Only the last call has _copy
    ' set to true.
    '
    Protected Overrides Sub CopyDataSetAsText(ByVal _dataSet As DataSet, ByVal _copy As Boolean)

        If (_dataSet IsNot Nothing) Then

            If (0 < _dataSet.Tables.Count) Then

                ' 1st DataTable uses Y1 units
                Dim _dataTable1 As DataTable = _dataSet.Tables(0)

                ' 2nd DataTable uses Y2 units
                Dim _dataTable2 As DataTable = Nothing
                If (1 < _dataSet.Tables.Count) Then
                    _dataTable2 = _dataSet.Tables(1)
                End If
                '
                ' Add title
                '
                mClipboardText += _dataTable1.TableName
                If (_dataTable2 IsNot Nothing) Then
                    mClipboardText += " / " + _dataTable2.TableName
                End If

                mClipboardText += Chr(10) ' Newline terminator
                '
                ' Add DataTable column headers
                '
                For _col As Integer = 0 To _dataTable1.Columns.Count - 1        ' DataTable 1
                    Dim _dataColumn As DataColumn = _dataTable1.Columns(_col)
                    Dim _heading As String = _dataColumn.ColumnName

                    If (_col = 0) Then
                        ' First column is X; Tab separator
                        mClipboardText += LabelX(_heading) + Chr(9)
                    ElseIf (_col < _dataTable1.Columns.Count - 1) Then
                        ' Remaining columns are Y; Tab separator
                        mClipboardText += LabelY(_heading) + Chr(9)
                    Else
                        mClipboardText += LabelY(_heading)
                    End If
                Next

                If (_dataTable2 IsNot Nothing) Then                             ' DataTable 2
                    mClipboardText += Chr(9) ' Tab separator

                    ' Add DataTable 2 column headers
                    For _col As Integer = 1 To _dataTable2.Columns.Count - 1
                        Dim _dataColumn As DataColumn = _dataTable2.Columns(_col)
                        Dim _heading As String = _dataColumn.ColumnName

                        If (_col < _dataTable2.Columns.Count - 1) Then
                            mClipboardText += LabelY2(_heading) + Chr(9)
                        Else
                            mClipboardText += LabelY2(_heading)
                        End If
                    Next
                End If

                mClipboardText += Chr(10) ' Newline terminator
                '
                ' Add data rows
                '
                For _rdx As Integer = 0 To _dataTable1.Rows.Count - 1
                    Dim _dataRow1 As DataRow = _dataTable1.Rows(_rdx)

                    Dim _dataRow2 As DataRow = Nothing
                    If (_dataTable2 IsNot Nothing) Then
                        If (_rdx < _dataTable2.Rows.Count) Then
                            _dataRow2 = _dataTable2.Rows(_rdx)
                        End If
                    End If

                    For _col As Integer = 0 To _dataRow1.ItemArray.Length - 1    ' DataTable 1
                        Dim _item As Object = _dataRow1.ItemArray(_col)
                        Dim _value As Double = CDbl(_item)
                        Dim _text As String

                        If (_col = 0) Then
                            ' First column is X; Tab separator
                            _value = UnitX(_value)

                            If (_value < 0.1) Then
                                _text = Format(_value, "0.00##e+00")
                            Else
                                _text = Format(_value, "0.00##")
                            End If

                            _text += Chr(9)
                        ElseIf (_col < _dataTable1.Columns.Count - 1) Then
                            ' Remaining columns are Y; Tab separator
                            _value = UnitY(_value)

                            If (_value < 0.1) Then
                                _text = Format(_value, "0.000#e+00")
                            Else
                                _text = Format(_value, "0.000##")
                            End If

                            _text += Chr(9)
                        Else
                            ' Last column
                            _value = UnitY(_value)

                            If (_value < 0.1) Then
                                _text = Format(_value, "0.000#e+00")
                            Else
                                _text = Format(_value, "0.000##")
                            End If
                        End If

                        mClipboardText += _text
                    Next

                    If (_dataRow2 IsNot Nothing) Then                             ' DataTable 2
                        mClipboardText += Chr(9) ' Tab separator

                        For _col As Integer = 1 To _dataRow2.ItemArray.Length - 1
                            Dim _item As Object = _dataRow2.ItemArray(_col)
                            Dim _value As Double = CDbl(_item)
                            Dim _text As String

                            If (_col < _dataTable2.Columns.Count - 1) Then
                                ' Remaining columns are Y; Tab separator
                                _value = UnitY2(_value)

                                If (_value < 0.1) Then
                                    _text = Format(_value, "0.000#e+00")
                                Else
                                    _text = Format(_value, "0.000##")
                                End If

                                _text += Chr(9)
                            Else
                                ' Last column
                                _value = UnitY2(_value)

                                If (_value < 0.1) Then
                                    _text = Format(_value, "0.000#e+00")
                                Else
                                    _text = Format(_value, "0.000##")
                                End If
                            End If

                            mClipboardText += _text
                        Next
                    End If

                    mClipboardText += Chr(10) ' Newline terminator

                Next ' _rdx

            End If ' (0 < _dataSet.Tables.Count)
        End If ' (_dataSet IsNot Nothing)

        ' Copy to clipboard if requested
        If (_copy) Then
            Clipboard.SetDataObject(mClipboardText, True)
            ClearClipboardText()
        End If

    End Sub

#End Region

#End Region

End Class
