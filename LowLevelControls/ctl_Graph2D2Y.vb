
'*************************************************************************************************************
' ctl_Graph2D2Y - Control for drawing 2D Cartesian Coordinate graphs with 2 Y-axes.
'
' Graphics UI object hierarchy:
'
'   System.Windows.Forms.PictureBox
'       ex_PictureBox
'           ctl_Canvas2D
'               ctl_Graph2D
'                  ctl_Graph2D2Y
'
' ctl_Graph2D2Y adds a 2nd Y-scale (displayed on the right axis) so two curves with different
' units can be drawn on the same graph.  Both curves share the same x axis units.
'*************************************************************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class ctl_Graph2D2Y
    Inherits ctl_Graph2D

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal _dataSet As DataSet)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeGraph2D2Y(_dataSet)

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
                Me.DisposeGraph2D2Y()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

#Region " Member Data "
    '
    ' Data to be drawn (loaded by constructor)
    '
    Protected mDataTable2 As DataTable

    Protected mMajorTickY2, mMinorTickY2 As Single
    '
    ' Drawing tools
    '
    Protected mColor As Color = Drawing.Color.Black
    Protected mPen1 As Pen = New Pen(mColor)
    Protected mPen2 As Pen = New Pen(mColor, 2)
    Protected mBrush As SolidBrush = New SolidBrush(mColor)

#End Region

#Region " Properties "
    '
    ' Min & Max Y2 value (UI units)
    '
    ' These values define the limits for the Y2-axis
    '
    Protected mMinY2 As Single
    Protected mMaxY2 As Single

    Protected mRangeY2 As Single

    Public Property MinY2() As Single
        Get
            Return mMinY2
        End Get
        Set(ByVal Value As Single)
            If (Value < mMinY2) Then
                mMinY2 = Value
                mRangeY2 = mMaxY2 - mMinY2
            End If
        End Set
    End Property

    Public Property MaxY2() As Single
        Get
            Return mMaxY2
        End Get
        Set(ByVal Value As Single)
            mMaxY2 = RoundUp(Value)
            mRangeY2 = mMaxY2 - mMinY2
        End Set
    End Property

#End Region

#Region " Initialization "

    Public Sub InitializeGraph2D2Y(ByVal CurveSet As DataSet)
        MyBase.InitializeGraph2D(CurveSet)

        If (CurveSet IsNot Nothing) Then
            ' 2nd DataTable defines right Axis titles and labels
            If (1 < mDataSet.Tables.Count) Then
                mDataTable2 = mDataSet.Tables(1)

                mColor = ColorN(1)

                ' Allow override of "Color" property
                If (mDataTable2.ExtendedProperties.Contains("Color")) Then
                    Dim obj As Object = mDataTable2.ExtendedProperties.Item("Color")
                    If (obj.GetType Is GetType(Drawing.Color)) Then
                        mColor = DirectCast(obj, Drawing.Color)
                    End If
                End If

                mPen1 = New Pen(mColor)
                mPen2 = New Pen(mColor, 2)
                mBrush = New SolidBrush(mColor)
            Else
                mDataTable2 = Nothing
            End If
        End If
    End Sub

    Protected Overridable Sub DisposeGraph2D2Y()
        MyBase.DisposeGraph2D()

        If (mDataTable2 IsNot Nothing) Then
            mDataTable2.Dispose()
            mDataTable2 = Nothing
        End If
    End Sub

#End Region

#Region " Protected Methods "

#Region " Utilities "
    '
    ' Find the Min & Max values for the DataSet
    '
    Protected Overrides Sub FindMinMax()

        ' Reset Min & Max values
        ResetMinMax()

        If (mDataSet IsNot Nothing) Then
            '
            ' Find max & min X & Y values (in SI Units)
            '   Max & Min can be preset by caller
            '
            If (0 < mDataSet.Tables.Count) Then
                Dim _dataTable As DataTable = mDataSet.Tables(0)
                ' 1st column is X; rest are Y
                If (1 < _dataTable.Columns.Count) Then

                    For Each _row As DataRow In _dataTable.Rows

                        ' Find X-axis limits from 1st column
                        Dim x As Single = CSng(_row.Item(0))

                        If Not (Single.IsNaN(x)) Then
                            If (x < mMinX) Then
                                mMinX = x
                            End If

                            If (mMaxX < x) Then
                                mMaxX = x
                            End If
                        End If

                        ' Find Y-axis limits from remaining columns
                        For _idx As Integer = 1 To _dataTable.Columns.Count - 1

                            Dim y As Single = CSng(_row.Item(_idx))

                            If Not (Single.IsNaN(y)) Then
                                If (y < mMinY) Then
                                    mMinY = y
                                End If

                                If (mMaxY < y) Then
                                    mMaxY = y
                                End If
                            End If
                        Next
                    Next

                End If
            End If

            If (1 < mDataSet.Tables.Count) Then
                Dim _dataTable As DataTable = mDataSet.Tables(1)
                ' 1st column is X; rest are Y2
                If (1 < _dataTable.Columns.Count) Then

                    For Each _row As DataRow In _dataTable.Rows

                        ' Find Y2-axis limits from remaining columns
                        For _idx As Integer = 1 To _dataTable.Columns.Count - 1

                            Dim y As Single = CSng(_row.Item(_idx))

                            If Not (Single.IsNaN(y)) Then
                                If (y < mMinY2) Then
                                    mMinY2 = y
                                End If

                                If (mMaxY2 < y) Then
                                    mMaxY2 = y
                                End If
                            End If
                        Next
                    Next

                End If
            End If

            ' If minimum values are relatively close (<10% of max) to zero; set them to zero
            If (mMinX < (mMaxX * 0.1)) Then
                mMinX = 0.0
            End If

            If ((0.0 < mMinY) And (mMinY < (mMaxY * 0.1))) Then
                mMinY = 0.0
            End If

            If ((0.0 < mMinY2) And (mMinY2 < (mMaxY2 * 0.1))) Then
                mMinY2 = 0.0
            End If

            ' Round up so curves do not touch at the top
            mMaxX = RoundUp(mMaxX)
            mMaxY = RoundUp(mMaxY)
            mMaxY2 = RoundUp(mMaxY2)

            ' Compute X & Y ranges (in SI Units)
            mRangeX = mMaxX - mMinX
            mRangeY = mMaxY - mMinY
            mRangeY2 = mMaxY2 - mMinY2

            ' Validate ranges
            If (0 < mDataSet.Tables.Count) Then ' there are left axis curves
                If ((0.0 < mRangeX) And (0.0 < mRangeY)) Then ' left axis ranges valid
                    If (1 < mDataSet.Tables.Count) Then ' there are right axis curves
                        If (0.0 < mRangeY2) Then ' right axis range valid
                            mValidValues = True
                        End If
                    Else ' only left axis curves
                        mValidValues = True
                    End If
                End If
            End If

        End If ' (mDataSet IsNot Nothing)

    End Sub

#End Region

#Region " Scale Methods "
    '
    ' Scale the graph, on a 1,2,5 scale, based on min / max values 
    '
    Protected Overrides Sub ScaleGraph()
        MyBase.ScaleGraph()

        ' Scale Y2 on a 1,2,5 scale (in Display Units)
        Dim scaleY2 As Single = Scale125(mRangeY2, mMajorTickY2, mMinorTickY2)

    End Sub

#End Region

#Region " Title Methods "

    '*********************************************************************************************************
    ' Override methods in ctl_Graph2D baseclass to handle right-axis differences
    '*********************************************************************************************************
    Protected Overrides Sub DrawAxes()

        ' Draw the graph
        If (mDataTable IsNot Nothing) Then
            ' Draw the graph's title
            DrawGraphTitle()

            ' Draw axes' titles
            DrawLeftAxisTitles(mDataTable)
            DrawRightAxisTitle(mDataTable2)
            DrawBottomAxisTitle(mDataTable)

            ' Draw all four axes w/labels
            DrawTopAxis(True)
            'DrawTopAxisLabels(mDataTable, True)

            DrawLeftAxis(True)
            DrawLeftAxisLabels(mDataTable, True)

            DrawRightAxis(True)
            DrawRightAxisLabels(mDataTable2, True)

            DrawBottomAxis(True)
            DrawBottomAxisLabels(mDataTable, True)
        Else
            DrawNoData()
        End If

    End Sub

    Protected Overrides Sub DrawRightAxisTitle(ByVal table As DataTable)

        If (table IsNot Nothing) Then ' no right-axis data
            ' Draw graph's right-axis label
            If (1 < table.Columns.Count) Then ' at least 1 curve

                ' Title is Column Name
                Dim title As String = UiLabelUnits(table.Columns(1).ColumnName)

                ' Position based on size of title
                Dim titleSize As SizeF = mGraphics.MeasureString(title, mFont)
                Dim x As Integer = CInt(mRight + (titleSize.Height * 2.5!))
                Dim y As Integer = CInt(mTop + ((mHeight - titleSize.Width) / 2))

                AddText(title, mFont, mColor, x, y, False, True)
            End If
        End If

    End Sub

#End Region

#Region " Axis Methods "

    '*********************************************************************************************************
    ' Override methods in ctl_Graph2D baseclass to handle right-axis differences
    '*********************************************************************************************************
    Protected Overrides Sub DrawRightAxis(ByVal _withMinor As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _mark As Single
        Dim _inc As Single

        _mark = mMajorTickY2 * (Int(mMinY2 / mMajorTickY2))

        If (_mark < mMinY2) Then
            _mark += mMajorTickY2
        End If

        Dim _iter As Integer = 0
        While ((_mark <= mMaxY2) And (_iter < 100))
            x = mLeft + mWidth
            y = mTop

            _inc = ((_mark - mMinY2) / mRangeY2) * mHeight

            If (mPosDirY = PositiveDirection.PosUp) Then
                y += mHeight - _inc
            Else ' Assume PosDown
                y += _inc
            End If

            mGraphics.DrawLine(mPen2, x - 5, y, x + 5, y)

            _mark += mMajorTickY2
            _iter += 1
        End While

        ' Draw the minor tick marks
        If (_withMinor) Then

            _mark = mMinorTickY * (Int(mMinY2 / mMinorTickY))

            If (_mark < mMinY2) Then
                _mark += mMinorTickY2
            End If

            _iter = 0
            While ((_mark <= mMaxY2) And (_iter < 100))
                x = mLeft + mWidth
                y = mTop

                _inc = ((_mark - mMinY2) / mRangeY2) * mHeight

                If (mPosDirY = PositiveDirection.PosUp) Then
                    y += mHeight - _inc
                Else ' Assume PosDown
                    y += _inc
                End If

                mGraphics.DrawLine(mPen2, x + 3, y, x, y)

                _mark += mMinorTickY2
                _iter += 1
            End While
        End If

        ' Draw the axes
        x = mLeft + mWidth
        y = mTop

        mGraphics.DrawLine(mPen2, x, y, x, y + mHeight)

    End Sub

    Protected Overrides Sub DrawRightAxisLabels(ByVal _dataTable As DataTable, ByVal _withZero As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _sizeF As New SizeF(0, 0)
        Dim _mark As Single
        Dim _text, _format As String

        _mark = mMajorTickY2 * (Int(mMinY2 / mMajorTickY2))

        If (_mark < mMinY2) Then
            _mark += mMajorTickY2
        End If

        If (mRangeY2 < 0.005) Then
            _format = "0.####"
        ElseIf (mRangeY2 < 0.05) Then
            _format = "0.###"
        ElseIf (mRangeY2 < 0.5) Then
            _format = "0.##"
        ElseIf (mRangeY2 < 100.0) Then
            _format = "0.#"
        ElseIf (mRangeY2 < 10000.0) Then
            _format = "0"
        Else
            _format = "0.0#e+###"
        End If

        Dim _iter As Integer = 0
        While ((_mark <= mMaxY2) And (_iter < 100))
            If (_withZero Or Not (_mark = 0.0)) Then
                x = mLeft + mWidth
                y = mTop

                If (mPosDirY = PositiveDirection.PosUp) Then
                    y += mHeight - (((_mark - mMinY2) / mRangeY2) * mHeight)
                Else ' Assume PosDown
                    y += ((_mark - mMinY2) / mRangeY2) * mHeight
                End If

                _text = Format(_mark, _format)
                _sizeF = mGraphics.MeasureString(_text, mFont)

                y -= _sizeF.Height / 2

                mGraphics.DrawString(_text, mFont, mBrush, x + 7, y)
            End If

            _mark += mMajorTickY2
            _iter += 1
        End While

    End Sub

#End Region

#Region " Curve Methods "

    '*********************************************************************************************************
    ' Override methods in ctl_Graph2D baseclass to add right-axis
    '*********************************************************************************************************
    Protected Overrides Sub DrawCurves()
        mColorNo = 1
        mPens2 = New Pen() {}

        ' Each DataTable represents one axis' set of curves
        If (mDataSet IsNot Nothing) Then

            ' Draw left axis' curves
            If (0 < mDataSet.Tables.Count) Then
                Dim curveTable As DataTable = mDataSet.Tables(0)     ' Curves for left axis
                MyBase.DrawCurve(curveTable)
            End If

            ' Draw right axis' curves
            If (1 < mDataSet.Tables.Count) Then
                Dim curveTable As DataTable = mDataSet.Tables(1)     ' Curves for right axis
                Me.DrawCurve(curveTable)
            End If
        End If

    End Sub

    Protected Overrides Sub DrawCurve(ByVal CurveTable As DataTable)

        Dim x, y As Single
        Dim x1, x2, y1, y2 As Single
        Dim siz As New SizeF(0, 0)
        Dim row As DataRow

        ' Draw each curve in the DataTable
        For YcolNo As Integer = 1 To CurveTable.Columns.Count - 1

            Dim drawOK As Boolean = True

            ReDim Preserve mPens2(mColorNo)

            mPens2(mColorNo) = New Pen(ColorN(mColorNo), 2)
            Dim Pen2 As Pen = mPens2(mColorNo)
            mColorNo += 1

            ' Start with first point
            If (0 < CurveTable.Rows.Count) Then

                row = CurveTable.Rows(0)
                '
                ' Get next X & Y values
                '
                x = CSng(row.Item(0))
                y = CSng(row.Item(YcolNo))
                '
                ' Limit & scale Y; this may require interpolating X
                '
                If (Single.IsNaN(y) Or Single.IsInfinity(y)) Then

                    drawOK = False

                ElseIf (y < mMinY2) Then

                    If (1 < CurveTable.Rows.Count) Then
                        Dim nextRow As DataRow = CurveTable.Rows(1)
                        Dim nextX As Single = CSng(nextRow.Item(0))
                        Dim nextY As Single = CSng(nextRow.Item(YcolNo))

                        If (Single.IsNaN(nextY)) Then
                            drawOK = False
                        Else
                            x = x + (nextX - x) * (mMinY2 - y) / (nextY - y)
                        End If
                    End If

                    y = mMinY2

                ElseIf (y > mMaxY2) Then

                    y = mMaxY2

                End If

                If (drawOK) Then ' y is OK
                    If (mPosDirY = PositiveDirection.PosUp) Then
                        y1 = mBottom - (((y - mMinY2) / mRangeY2) * mHeight)
                    Else ' Assume PosDown
                        y1 = mTop + (((y - mMinY2) / mRangeY2) * mHeight)
                    End If
                End If
                '
                ' Scale X
                '
                If (mPosDirX = PositiveDirection.PosRight) Then
                    x1 = mLeft + (((x - mMinX) / mRangeX) * mWidth)
                Else ' Assume PosLeft
                    x1 = mRight - (((x - mMinX) / mRangeX) * mWidth)
                End If

            End If

            ' Draw lines to remaining points
            For _row As Integer = 1 To CurveTable.Rows.Count - 1

                row = CurveTable.Rows(_row)
                '
                ' Get next X & Y values
                '
                x = CSng(row.Item(0))
                y = CSng(row.Item(YcolNo))
                '
                ' Limit & scale Y; this may require interpolating X
                '
                If (Single.IsNaN(y) Or Single.IsInfinity(y)) Then

                    drawOK = False

                ElseIf (y < mMinY2) Then

                    If (_row < CurveTable.Rows.Count - 1) Then
                        Dim nextRow As DataRow = CurveTable.Rows(_row + 1)
                        Dim nextX As Single = CSng(nextRow.Item(0))
                        Dim nextY As Single = CSng(nextRow.Item(YcolNo))

                        If (Single.IsNaN(nextY)) Then
                            drawOK = False
                        Else
                            x = x + (nextX - x) * (mMinY2 - y) / (nextY - y)
                        End If
                    End If

                    y = mMinY2

                ElseIf (y > mMaxY2) Then

                    Dim lastRow As DataRow = CurveTable.Rows(_row - 1)
                    Dim lastX As Single = CSng(lastRow.Item(0))
                    Dim lastY As Single = CSng(lastRow.Item(YcolNo))

                    If (Single.IsNaN(lastY)) Then
                        drawOK = False
                    Else
                        x = x - (x - lastX) * (y - mMaxY2) / (y - lastY)
                        y = mMaxY2
                    End If

                End If

                If (drawOK) Then ' y is OK
                    If (mPosDirY = PositiveDirection.PosUp) Then
                        y2 = mBottom - (((y - mMinY2) / mRangeY2) * mHeight)
                    Else ' Assume PosDown
                        y2 = mTop + (((y - mMinY2) / mRangeY2) * mHeight)
                    End If
                End If
                '
                ' Scale X
                '
                If (mPosDirX = PositiveDirection.PosRight) Then
                    x2 = mLeft + (((x - mMinX) / mRangeX) * mWidth)
                Else ' Assume PosLeft
                    x2 = mRight - (((x - mMinX) / mRangeX) * mWidth)
                End If

                If (drawOK) Then
                    '
                    ' Draw Symbol and/or Line graph
                    '
                    If (CurveTable.ExtendedProperties.Contains("Symbol")) Then
                        Dim _object As Object = CurveTable.ExtendedProperties.Item("Symbol")

                        If (_object.GetType Is GetType(String)) Then
                            Dim _symbol As String = CStr(_object)
                            '
                            ' Draw endpoints
                            '
                            If ((_symbol = "O") Or (_symbol = "o")) Then
                                Dim _size As Integer = 10
                                Dim _offset As Integer = 5
                                If (_symbol = "o") Then
                                    _size = 6
                                    _offset = 3
                                End If
                                mGraphics.DrawEllipse(Pen2, x1 - _offset, y1 - _offset, _size, _size)
                                mGraphics.DrawEllipse(Pen2, x2 - _offset, y2 - _offset, _size, _size)
                            Else ' Assume "X" or "x"
                                Dim _len As Integer = 4
                                If (_symbol = "x") Then
                                    _len = 3
                                End If
                                mGraphics.DrawLine(Pen2, x1 - _len, y1 - _len, x1 + _len, y1 + _len)
                                mGraphics.DrawLine(Pen2, x1 - _len, y1 + _len, x1 + _len, y1 - _len)

                                mGraphics.DrawLine(Pen2, x2 - _len, y2 - _len, x2 + _len, y2 + _len)
                                mGraphics.DrawLine(Pen2, x2 - _len, y2 + _len, x2 + _len, y2 - _len)
                            End If

                            If (CurveTable.ExtendedProperties.Contains("Line")) Then
                                '
                                ' Draw line if not on Min axis
                                '
                                If Not ((x1 = x2) And (x = mMinX)) Then
                                    If Not ((y1 = y2) And (y = mMinY2)) Then
                                        mGraphics.DrawLine(Pen2, x1, y1, x2, y2)
                                    End If
                                End If
                            End If
                        Else
                            Debug.Assert(False, "Symbol is not a String")
                        End If
                    Else
                        '
                        ' Draw line if not on Min axis
                        '
                        If Not ((x1 = x2) And (x = mMinX)) Then
                            If Not ((y1 = y2) And (y = mMinY2)) Then
                                mGraphics.DrawLine(Pen2, x1, y1, x2, y2)
                            End If
                        End If
                    End If

                Else
                    drawOK = True
                End If

                ' Save end point of this line as start of next line
                x1 = x2
                y1 = y2

            Next ' row
        Next ' col

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

        If Not (_dataSet Is Nothing) Then

            If (0 < _dataSet.Tables.Count) Then
                '
                ' 1st DataTable uses Y1 units
                '
                Dim _dataTable As DataTable = _dataSet.Tables(0)

                ' Add the title
                mClipboardText += _dataTable.TableName + Chr(10)

                ' Add the column headers
                For _col As Integer = 0 To _dataTable.Columns.Count - 1
                    Dim _dataColumn As DataColumn = _dataTable.Columns(_col)
                    Dim _heading As String = _dataColumn.ColumnName

                    If (_col = 0) Then
                        ' First column is X; Tab separator
                        mClipboardText += UiLabelUnits(_heading) + Chr(9)
                    ElseIf (_col < _dataTable.Columns.Count - 1) Then
                        ' Remaining columns are Y; Tab separator
                        mClipboardText += UiLabelUnits(_heading) + Chr(9)
                    Else
                        ' Last column ends with Newline
                        mClipboardText += UiLabelUnits(_heading) + Chr(10)
                    End If
                Next

                ' Add the data rows
                For Each _dataRow As DataRow In _dataTable.Rows

                    For _col As Integer = 0 To _dataRow.ItemArray.Length - 1
                        Dim _value As Single = CSng(_dataRow.ItemArray(_col))
                        Dim _text As String

                        If (_col = 0) Then
                            ' First column is X; Tab separator
                            If (_value < 0.1) Then
                                _text = Format(_value, "0.00##e+00")
                            Else
                                _text = Format(_value, "0.00##")
                            End If

                            _text += Chr(9)
                        ElseIf (_col < _dataTable.Columns.Count - 1) Then
                            ' Remaining columns are Y; Tab separator
                            If (_value < 0.1) Then
                                _text = Format(_value, "0.00##e+00")
                            Else
                                _text = Format(_value, "0.00##")
                            End If

                            _text += Chr(9)
                        Else
                            ' Last column ends with Newline
                            If (_value < 0.1) Then
                                _text = Format(_value, "0.00##e+00")
                            Else
                                _text = Format(_value, "0.00##")
                            End If

                            _text += Chr(10)
                        End If

                        mClipboardText += _text
                    Next

                Next

                mClipboardText += Chr(10)

            End If

            If (1 < _dataSet.Tables.Count) Then
                '
                ' 2nd DataTable uses Y2 units
                '
                Dim _dataTable As DataTable = _dataSet.Tables(1)

                ' Add the title
                mClipboardText += _dataTable.TableName + Chr(10)

                ' Add the column headers
                For _col As Integer = 0 To _dataTable.Columns.Count - 1
                    Dim _dataColumn As DataColumn = _dataTable.Columns(_col)
                    Dim _heading As String = _dataColumn.ColumnName

                    If (_col = 0) Then
                        ' First column is X; Tab separator
                        mClipboardText += UiLabelUnits(_heading) + Chr(9)
                    ElseIf (_col < _dataTable.Columns.Count - 1) Then
                        ' Remaining columns are Y; Tab separator
                        mClipboardText += UiLabelUnits(_heading) + Chr(9)
                    Else
                        ' Last column ends with Newline
                        mClipboardText += UiLabelUnits(_heading) + Chr(10)
                    End If
                Next

                ' Add the data rows
                For Each _dataRow As DataRow In _dataTable.Rows

                    For _col As Integer = 0 To _dataRow.ItemArray.Length - 1
                        Dim _value As Single = CSng(_dataRow.ItemArray(_col))
                        Dim _text As String

                        If (_col = 0) Then
                            ' First column is X; Tab separator
                            If (_value < 0.1) Then
                                _text = Format(_value, "0.00##e+00")
                            Else
                                _text = Format(_value, "0.00##")
                            End If

                            _text += Chr(9)
                        ElseIf (_col < _dataTable.Columns.Count - 1) Then
                            ' Remaining columns are Y; Tab separator
                            If (_value < 0.1) Then
                                _text = Format(_value, "0.00##e+00")
                            Else
                                _text = Format(_value, "0.00##")
                            End If

                            _text += Chr(9)
                        Else
                            ' Last column ends with Newline
                            If (_value < 0.1) Then
                                _text = Format(_value, "0.00##e+00")
                            Else
                                _text = Format(_value, "0.00##")
                            End If

                            _text += Chr(10)
                        End If

                        mClipboardText += _text
                    Next

                Next

                mClipboardText += Chr(10)

            End If
        End If

        ' Copy to clipboard if requested
        If (_copy) Then
            Clipboard.SetDataObject(mClipboardText, True)
            ClearClipboardText()
        End If

    End Sub

#End Region

#End Region

End Class
