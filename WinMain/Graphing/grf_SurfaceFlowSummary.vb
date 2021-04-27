
'*************************************************************************************************************
' grf_SurfaceFlowSummary - generates composite summary graph of Surface Flow including:
'                          Advance & Recession
'                          Inflow & Runoff
'*************************************************************************************************************
Imports DataStore

Public Class grf_SurfaceFlowSummary
    Inherits grf_XYGraph

#Region " Member Data "

    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' Advance / Recession subgraph
    '
    Private Const mAdvRecTop As Double = 1
    Private Const mAdvRecLeft As Double = 10
    Private Const mAdvRecWidth As Double = 80
    Private Const mAdvRecHeight As Double = 95
    '
    ' Inflow / Runoff subgraphs
    '
    Private Const mQinTop As Double = 1
    Private Const mQinLeft As Double = 6
    Private Const mQinWidth As Double = 13.35
    Private Const mQinHeight As Double = 95

    Private Const mRunoffTop As Double = 1
    Private Const mRunoffLeft As Double = 80.65
    Private Const mRunoffWidth As Double = 13.35
    Private Const mRunoffHeight As Double = 95

#End Region

#Region " Properties "

    Private mAdvRec As DataSet
    Public Property AdvanceRecession() As DataSet
        Get
            Return mAdvRec
        End Get
        Set(ByVal value As DataSet)
            mAdvRec = value
        End Set
    End Property

    Private mLength As Double
    Public Property Length() As Double
        Get
            Return mLength
        End Get
        Set(ByVal value As Double)
            mLength = value
        End Set
    End Property

    Private mQin As DataSet
    Public Property Inflow() As DataSet
        Get
            Return mQin
        End Get
        Set(ByVal value As DataSet)
            mQin = value
        End Set
    End Property

    Private mRunoff As DataSet
    Public Property Runoff() As DataSet
        Get
            Return mRunoff
        End Get
        Set(ByVal value As DataSet)
            mRunoff = value
        End Set
    End Property

    Private mTimeLines() As Double
    Public Property TimeLines() As Double()
        Get
            Return mTimeLines
        End Get
        Set(ByVal value As Double())
            mTimeLines = value
        End Set
    End Property

    Private mHighlightLine As Integer = -1
    Public Property HighlightLine() As Integer
        Get
            Return mHighlightLine
        End Get
        Set(ByVal value As Integer)
            mHighlightLine = value
        End Set
    End Property

#End Region

#Region " Constructor(s) "

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides Sub DisposeGraph2D()
        MyBase.DisposeGraph2D()

        mAdvRec = Nothing
        mQin = Nothing
        mRunoff = Nothing
    End Sub

#End Region

#Region " Public Methods "

    Public Function MaxTime() As Double
        MaxTime = 0.0

        If (mAdvRec IsNot Nothing) Then ' Check Advance/Recession for max time
            mDataSet = mAdvRec
            Me.FindMinMax()
            MaxTime = Math.Max(MaxTime, Me.MaxY)
        End If

        If (mQin IsNot Nothing) Then ' Check Inflow for max time
            mDataSet = mQin
            Me.FindMinMax()
            MaxTime = Math.Max(MaxTime, Me.MaxY)
        End If

        If (mRunoff IsNot Nothing) Then ' Check Runoff for max time
            mDataSet = mRunoff
            Me.FindMinMax()
            MaxTime = Math.Max(MaxTime, Me.MaxY)
        End If

        If (mTimeLines IsNot Nothing) Then ' Check Time Lines for max time
            For Each time As Double In mTimeLines
                If (MaxTime < time * 1.05) Then
                    MaxTime = time * 1.05
                End If
            Next
        End If

    End Function

    Public Sub AddTimeLine(ByVal TimeLine As Double)
        If (mTimeLines Is Nothing) Then
            ReDim mTimeLines(0)
            mTimeLines(0) = TimeLine
        Else
            Dim count As Integer = mTimeLines.Length
            ReDim Preserve mTimeLines(count)
            mTimeLines(count) = TimeLine
        End If
    End Sub

    Public Sub ClearTimeLines()
        mTimeLines = Nothing
    End Sub

#End Region

#Region " Protected Methods "
    '
    ' Draw the Graph Title
    '
    Protected Overrides Sub DrawGraphTitles()

        ' Scale the fonts to match the graph size
        ScaleFonts(FontAdjustment)

        ' Scale the graph relative to the Bitmap size
        Dim tSurfaceFlowSummary As String = mDictionary.tSurfaceFlowSummary.Translated
        Dim _titleSizeF As SizeF = mGraphics.MeasureString(tSurfaceFlowSummary, mBold)

        ' Draw the Title
        Dim x As Integer = CInt((Me.Width - _titleSizeF.Width) / 2)
        Dim y As Integer = CInt(_titleSizeF.Height)

        Return ' Don't actually show Title; too much for display

        ' Draw the Graph's Subtitle(s) from the DataSet
        AddText(tSurfaceFlowSummary, mBold, mBlackPen1.Color, x, y, False, False)

    End Sub
    '
    ' Scale the fonts
    '
    Protected Overrides Sub ScaleFonts(ByVal adjustment As Single)

        Dim _size As Single = CSng(Math.Ceiling(Math.Min(Me.Height / 70, Me.Width / 70) + 2)) + adjustment

        mFont = New Font(mFont.FontFamily, _size)
        mBold = New Font(mFont, FontStyle.Bold)

        _size = CSng(Math.Ceiling(Math.Min(Me.Height / 70, Me.Width / 80) + 1)) + adjustment
        mCourier = New Font("Courier New", _size)

    End Sub
    '
    ' Draw Advance / Recession subgraph axes
    '
    Protected Overridable Sub DrawAdvRecAxes()

        If (mDataTable IsNot Nothing) Then
            ' Draw the top axis' title & labels
            DrawTopAxisTitle(mDataTable)
            DrawTopAxisLabels(mDataTable, True)

            ' Draw the bottom axis' title & labels
            Dim title As String = mDataTable.Columns(0).ColumnName
            mDataTable.Columns(0).ColumnName = mDictionary.tDistance.Translated & " (m)"
            DrawBottomAxisTitle(mDataTable)
            DrawBottomAxisLabels(mDataTable, True)
            mDataTable.Columns(0).ColumnName = title

            ' Draw axes
            DrawTopAxis(True)
            DrawLeftAxis(True)
            DrawRightAxis(True)
            DrawBottomAxis(True)
        End If

    End Sub
    '
    ' Draw Qin subgraph axes
    '
    Protected Overridable Sub DrawQinAxes()

        If (mDataTable IsNot Nothing) Then
            ' Draw the top axis' title
            DrawTopAxisTitle(mDataTable)
            DrawTopQLabel(mDataTable)
            DrawBottomQLabel(mDataTable)

            ' Draw the left side axis' titles & labels
            DrawLeftAxisTitle(mDataTable)
            DrawLeftAxisLabels(mDataTable, True)

            ' Draw axes (Right is drawn be Advance / Recession subgraph)
            DrawTopAxis(False)
            DrawLeftAxis(True)
            'DrawRightAxis(True)
            DrawBottomAxis(False)
        Else
            Debug.Assert(False, "DataTable is Nothing")
        End If

    End Sub
    '
    ' Draw Runoff subgraph axes
    '
    Protected Overridable Sub DrawRunoffAxes()

        If (mDataTable IsNot Nothing) Then
            ' Draw the top axis' title
            DrawTopAxisTitle(mDataTable)
            DrawTopQLabel(mDataTable)
            DrawBottomQLabel(mDataTable)

            ' Draw the right side axis' titles & labels
            DrawRightAxisTitle(mDataTable)
            DrawRightAxisLabels(mDataTable, True)

            ' Draw axes (Left is drawn be Advance / Recession subgraph)
            DrawTopAxis(False)
            'DrawLeftAxis(True)
            DrawRightAxis(True)
            DrawBottomAxis(False)
        Else
            Debug.Assert(False, "DataTable is Nothing")
        End If

    End Sub

    Protected Sub DrawTopQLabel(ByVal _dataTable As DataTable)

        ' Scale the graph relative to the available Bitmap size
        Dim _left As Integer = CInt(mLeft + ((mWidth * GraphMargin) / 100))
        Dim _width As Integer = CInt((mWidth * GraphWidth) / 100)
        Dim _right As Integer = _left + _width

        Dim _top As Integer = CInt(mTop + ((mHeight * GraphTop) / 100))
        Dim _height As Integer = CInt((mHeight * GraphHeight) / 100)
        Dim _bottom As Integer = _top + _height

        ' Draw the major tick marks with their labels
        Dim x, y As Integer
        Dim _sizeF As New SizeF(0, 0)
        Dim _mark As Double
        Dim _text As String = String.Empty
        Dim _format As String = String.Empty

        ' Draw in Display Units
        Dim _unitMinX As Double = UnitX(Me.MinX)
        Dim _unitMaxX As Double = UnitX(Me.MaxX)
        Dim _unitRangeX As Double = UnitX(mRangeX)

        _mark = mMajorTickX * (Int(_unitMinX / mMajorTickX))

        If (_mark < _unitMinX) Then
            _mark += mMajorTickX
        End If

        If (_unitRangeX <= 0.0) Then
            Return
        ElseIf (_unitRangeX < 0.005) Then
            _format = "0.####"
        ElseIf (_unitRangeX < 0.05) Then
            _format = "0.###"
        ElseIf (_unitRangeX < 0.5) Then
            _format = "0.##"
        Else
            _format = "0.#"
        End If

        While (_mark <= _unitMaxX)
            x = _left
            y = _top

            If (PosDirX = PositiveDirection.PosRight) Then
                x += CInt(((_mark - _unitMinX) / _unitRangeX) * _width)
            Else ' Assume PosLeft
                x += CInt(_width - (((_mark - _unitMinX) / _unitRangeX) * _width))
            End If

            _text = Format(_mark, _format)
            _sizeF = mGraphics.MeasureString(_text, mFont)

            x -= CInt(_sizeF.Width / 2)

            _mark += mMajorTickX
        End While

        mGraphics.DrawString(_text, mFont, mBlackBrush, x, y - _sizeF.Height - 6)

    End Sub

    Protected Sub DrawBottomQLabel(ByVal _dataTable As DataTable)

        ' Scale the graph relative to the available Bitmap size
        Dim _left As Integer = CInt(mLeft + ((mWidth * GraphMargin) / 100))
        Dim _width As Integer = CInt((mWidth * GraphWidth) / 100)
        Dim _right As Integer = _left + _width

        Dim _top As Integer = CInt(mTop + ((mHeight * GraphTop) / 100))
        Dim _height As Integer = CInt((mHeight * GraphHeight) / 100)
        Dim _bottom As Integer = _top + _height

        ' Draw the major tick marks with their labels
        Dim x, y As Integer
        Dim _sizeF As New SizeF(0, 0)
        Dim _mark As Double
        Dim _text As String = String.Empty
        Dim _format As String = String.Empty

        ' Draw in Display Units
        Dim _unitMinX As Double = UnitX(Me.MinX)
        Dim _unitMaxX As Double = UnitX(Me.MaxX)
        Dim _unitRangeX As Double = UnitX(mRangeX)

        _mark = mMajorTickX * (Int(_unitMinX / mMajorTickX))

        If (_mark < _unitMinX) Then
            _mark += mMajorTickX
        End If

        If (_unitRangeX <= 0.0) Then
            Return
        ElseIf (_unitRangeX < 0.005) Then
            _format = "0.####"
        ElseIf (_unitRangeX < 0.05) Then
            _format = "0.###"
        ElseIf (_unitRangeX < 0.5) Then
            _format = "0.##"
        Else
            _format = "0.#"
        End If

        While (_mark <= _unitMaxX)
            x = _left
            y = _top + _height

            If (PosDirX = PositiveDirection.PosRight) Then
                x += CInt(((_mark - _unitMinX) / _unitRangeX) * _width)
            Else ' Assume PosLeft
                x += CInt(_width - (((_mark - _unitMinX) / _unitRangeX) * _width))
            End If

            _text = Format(_mark, _format)
            _sizeF = mGraphics.MeasureString(_text, mFont)

            x -= CInt(_sizeF.Width / 2)

            _mark += mMajorTickX
        End While

        mGraphics.DrawString(_text, mFont, mBlackBrush, x, y + _sizeF.Height - 8)

    End Sub

#End Region

#Region " Graphing Methods "

    Public Overrides Sub DrawImage()

        ' Don't attempt the draw if control is being Disposed
        If (Me.Disposing) Then
            Return
        End If

        ' Enclose drawing code in a Try Catch block so drawing is skipped when error occur
        '  Errors occur when size of graph goes to zero
        Try
            ' Start with a clean canvas
            ClearCanvas()

            ' Draw the graph's title
            DrawGraphTitles()

            ' Get maximum time for entire graph
            Dim _maxTime As Double = MaxTime()
            '
            ' Draw Advance / Recession subgraph
            '
            If (mAdvRec IsNot Nothing) Then
                mDataSet = mAdvRec
                Me.FindMinMax()

                ' Save 1st DataTable (used to draw axes & 1st set curves)
                If (0 < mAdvRec.Tables.Count) Then
                    mDataTable = mAdvRec.Tables(0).Copy
                    mDataTable.Columns(0).ColumnName = mAdvRec.DataSetName & " (m)"

                    mTop = CSng((Me.Height * mAdvRecTop) / 100.0)
                    mLeft = CSng((Me.Width * mAdvRecLeft) / 100.0)
                    mWidth = CSng((Me.Width * mAdvRecWidth) / 100.0)
                    mHeight = CSng((Me.Height * mAdvRecHeight) / 100.0)

                    UnitsX = UnitsDefinition.Units.Meters
                    UnitsY = UnitsDefinition.Units.Seconds
                    PosDirX = grf_XYGraph.PositiveDirection.PosRight
                    PosDirY = grf_XYGraph.PositiveDirection.PosUp

                    Me.MaxX = mLength
                    mMaxY = _maxTime
                    mRangeY = mMaxY - mMinY

                    ScaleGraph()
                    DrawCurves()
                    DrawAdvRecAxes()
                End If
            End If

            ' Draw Time Lines in Advance/Recession graph
            If (mTimeLines IsNot Nothing) Then
                For tdx As Integer = 0 To mTimeLines.Length - 1
                    Dim timeline As Double = mTimeLines(tdx)
                    If (tdx = mHighlightLine) Then
                        Me.DrawHorzLine(timeline, Color.Blue, 2)
                    Else
                        Me.DrawHorzLine(timeline, Color.Blue)
                    End If
                Next tdx
            End If
            '
            ' Draw Qin subgraph
            '
            Dim _qinMax As Double

            If (mQin IsNot Nothing) Then
                mDataSet = mQin
                Me.FindMinMax()

                ' Save 1st DataTable (used to draw axes * 1st set curves)
                If (0 < mQin.Tables.Count) Then
                    mDataTable = mQin.Tables(0)

                    _qinMax = 0.0
                    For Each _row As DataRow In mDataTable.Rows
                        Dim _qin As Double = CDbl(_row.Item(0))
                        If (_qinMax < _qin) Then
                            _qinMax = _qin
                        End If
                    Next
                    _qinMax *= 1.1

                    mTop = CSng((Me.Height * mQinTop) / 100.0)
                    mLeft = CSng((Me.Width * mQinLeft) / 100.0)
                    mWidth = CSng((Me.Width * mQinWidth) / 100.0)
                    mHeight = CSng((Me.Height * mQinHeight) / 100.0)

                    UnitsX = UnitsDefinition.Units.Cms
                    UnitsY = UnitsDefinition.Units.Seconds
                    PosDirX = grf_XYGraph.PositiveDirection.PosLeft
                    PosDirY = grf_XYGraph.PositiveDirection.PosUp

                    Me.MaxX = _qinMax
                    mMaxY = _maxTime
                    mRangeY = mMaxY - mMinY

                    ScaleGraph()
                    DrawCurves()
                    DrawQinAxes()
                End If
            End If

            ' Draw Time Lines in Inflow graph
            If (mTimeLines IsNot Nothing) Then
                For tdx As Integer = 0 To mTimeLines.Length - 1
                    Dim timeline As Double = mTimeLines(tdx)
                    If (tdx = mHighlightLine) Then
                        Me.DrawHorzLine(timeline, Color.Blue, 2)
                    Else
                        Me.DrawHorzLine(timeline, Color.Blue)
                    End If
                Next tdx
            End If
            '
            ' Draw Runoff subgraph
            '
            If (mRunoff IsNot Nothing) Then
                mDataSet = mRunoff
                Me.FindMinMax()

                ' Save 1st DataTable (used to draw axes * 1st set curves)
                If (0 < mRunoff.Tables.Count) Then
                    mDataTable = mRunoff.Tables(0)

                    mTop = CSng((Me.Height * mRunoffTop) / 100.0)
                    mLeft = CSng((Me.Width * mRunoffLeft) / 100.0)
                    mWidth = CSng((Me.Width * mRunoffWidth) / 100.0)
                    mHeight = CSng((Me.Height * mRunoffHeight) / 100.0)

                    UnitsX = UnitsDefinition.Units.Cms
                    UnitsY = UnitsDefinition.Units.Seconds
                    PosDirX = grf_XYGraph.PositiveDirection.PosRight
                    PosDirY = grf_XYGraph.PositiveDirection.PosUp

                    Me.MaxX = _qinMax
                    mMaxY = _maxTime
                    mRangeY = mMaxY - mMinY

                    ScaleGraph()
                    DrawCurves()
                    DrawRunoffAxes()
                End If
            End If

            ' Draw Time Lines in Runoff graph
            If (mTimeLines IsNot Nothing) Then
                For tdx As Integer = 0 To mTimeLines.Length - 1
                    Dim timeline As Double = mTimeLines(tdx)
                    If (tdx = mHighlightLine) Then
                        Me.DrawHorzLine(timeline, Color.Blue, 2)
                    Else
                        Me.DrawHorzLine(timeline, Color.Blue)
                    End If
                Next tdx
            End If

            ' Draw a border around the entire bitmap
            DrawBorderLine(mBlackPen2)

            ' Show canvas after drawing to avoid flicker
            ShowCanvas()

        Catch ex As Exception
            DisposeCanvas()
        Finally
            DisposeGraphics()
        End Try

    End Sub

#End Region

#Region " Clipboard Methods "

    Public Overrides Sub CopyDataToClipboard()
        ClearClipboardText()

        ' Start with Inflow
        UnitsX = UnitsDefinition.Units.Cms
        UnitsY = UnitsDefinition.Units.Seconds
        CopyDataSetAsText(mQin, False)

        ' Add Advance / Recession
        UnitsX = UnitsDefinition.Units.Meters
        UnitsY = UnitsDefinition.Units.Seconds
        CopyDataSetAsText(mAdvRec, False)

        ' End with Runoff
        UnitsX = UnitsDefinition.Units.Cms
        UnitsY = UnitsDefinition.Units.Seconds
        CopyDataSetAsText(mRunoff, True)
    End Sub

#End Region

End Class
