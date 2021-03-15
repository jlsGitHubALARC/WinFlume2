
'**********************************************************************************************
' grf_HydraulicSummary provides graphics support for drawing SRFR's Hydraulic Summary.
'
' The data to be graphed is stored in several DataSets (sets of DataTables).
'
' The graph is drawn as a Bitmap.
'
Imports DataStore
Imports GraphingUI

Public Class grf_HydraulicSummary
    Inherits grf_XYGraph

#Region " Member Data "

    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' Advance / Recession subgraph
    '
    Private mAdvRec As DataSet

    Private Const mAdvRecTop As Double = 10
    Private Const mAdvRecLeft As Double = 10
    Private Const mAdvRecWidth As Double = 80
    Private Const mAdvRecHeight As Double = 50

    Private mExtTitle As String = Nothing
    '
    ' Infiltration subgraph
    '
    Private mInfiltration As DataSet

    Private Const mInfiltTop As Double = 48.75
    Private Const mInfiltLeft As Double = 10
    Private Const mInfiltWidth As Double = 80
    Private Const mInfiltHeight As Double = 45

    Private mLength As Double
    '
    ' Flow Hydrograph subgraphs
    '
    Private mQin As DataSet

    Private Const mQinTop As Double = 10
    Private Const mQinLeft As Double = 6
    Private Const mQinWidth As Double = 13.35
    Private Const mQinHeight As Double = 50

    Private mRunoff As DataSet

    Private Const mRunoffTop As Double = 10
    Private Const mRunoffLeft As Double = 80.65
    Private Const mRunoffWidth As Double = 13.35
    Private Const mRunoffHeight As Double = 50

#End Region

#Region " Constructor(s) "
    '
    ' Graph from DataSet
    '
    Public Sub New(ByVal _advRec As DataSet, _
                   ByVal _infilt As DataSet, _
                   ByVal _hydro As DataSet)

        ' Call the baseclass constructor
        MyBase.New(_advRec)

        Dim tTime As String = mDictionary.tTime.Translated
        Dim tRunoff As String = mDictionary.tRunoff.Translated

        ' Save the DataSets
        If (_advRec IsNot Nothing) Then
            '
            ' The Advance/Recession DataSet contains some number of Advance & Recession
            ' curves, each defined as a DataTable.
            '
            mAdvRec = _advRec

            ' Get the Graph's ExtTitle(s) from the DataSet
            mExtTitle = Nothing

            If (mAdvRec.ExtendedProperties.Contains("ExtTitle")) Then
                Dim _object As Object = mAdvRec.ExtendedProperties.Item("ExtTitle")
                If (_object.GetType Is GetType(String)) Then
                    mExtTitle = CStr(_object)
                Else
                    Debug.Assert(False, "'ExtTitle' is not String")
                End If
            End If
        Else
            Debug.Assert(False, "Advance / Recession DataSet is Nothing")
        End If

        If (_infilt IsNot Nothing) Then
            '
            ' The Infiltration DataSet contains some number of Infiltration curves,
            ' eash defined as a DataTable.
            '
            mInfiltration = _infilt

            ' Get the field length from the Infiltration DataSet
            If (1 < mInfiltration.Tables.Count) Then
                Dim _dataTable As DataTable = mInfiltration.Tables(1)
                Dim _rows As Integer = _dataTable.Rows.Count

                If (0 < _rows) Then
                    Dim _lastRow As DataRow = _dataTable.Rows(_rows - 1)

                    If (0 < _lastRow.ItemArray.Length) Then
                        mLength = CDbl(_lastRow.Item(0))
                    Else
                        Debug.Assert(False, "Not enough data in DataRow")
                    End If
                Else
                    Debug.Assert(False, "No data in Infiltration DataTable")
                End If
            Else
                Debug.Assert(False, "Not enough data in Infiltration DataSet")
            End If
        Else
            Debug.Assert(False, "Infiltration DataSet is Nothing")
        End If

        If (_hydro IsNot Nothing) Then
            If (0 < _hydro.Tables.Count) Then
                ' Is there an additional Qin table?
                If (1 < _hydro.Tables.Count) Then
                    ' Save this Qin table first
                    Dim _qinFlow As DataTable = New DataTable("Qin")
                    Dim _qinData As DataColumn = New DataColumn("Qin", GetType(Double))
                    Dim _qinTime As DataColumn = New DataColumn(tTime, GetType(Double))

                    _qinFlow.Columns.Add(_qinData)          ' Qin is X
                    _qinFlow.Columns.Add(_qinTime)          ' Time is Y

                    For Each _hydroRow As DataRow In _hydro.Tables(1).Rows

                        ' Build Qin DataTable
                        Dim _qinRow As DataRow = _qinFlow.NewRow

                        _qinRow(0) = _hydroRow(1)           ' Reverse X & Y
                        _qinRow(1) = _hydroRow(0)

                        _qinFlow.Rows.Add(_qinRow)

                    Next

                    mQin = New DataSet("Qin")
                    mQin.Tables.Add(_qinFlow)
                End If

                ' Is there an additional Runoff table?
                If (2 < _hydro.Tables.Count) Then
                    ' Save this Runoff table first
                    Dim _runoffFlow As DataTable = New DataTable(tRunoff)
                    Dim _runoffData As DataColumn = New DataColumn(tRunoff, GetType(Double))
                    Dim _runoffTime As DataColumn = New DataColumn(tTime, GetType(Double))

                    _runoffFlow.Columns.Add(_runoffData)    ' Runoff is X
                    _runoffFlow.Columns.Add(_runoffTime)    ' Time is Y

                    For Each _hydroRow As DataRow In _hydro.Tables(2).Rows

                        ' Build Runoff DataTable
                        Dim _runoffRow As DataRow = _runoffFlow.NewRow

                        _runoffRow(0) = _hydroRow(1)           ' Reverse X & Y
                        _runoffRow(1) = _hydroRow(0)

                        _runoffFlow.Rows.Add(_runoffRow)

                    Next

                    mRunoff = New DataSet("Runoff")
                    mRunoff.Tables.Add(_runoffFlow)
                End If

                ' Extract Qin & Runoff tables from Hydrographs
                Dim _hydroflow As DataTable = _hydro.Tables(0)

                If (2 < _hydroflow.Columns.Count) Then

                    Dim _runoffIdx As Integer = _hydroflow.Columns.Count - 1

                    ' Convert the Flow Hydrograph data into Qin and Runoff data
                    Dim _qinFlow As DataTable = New DataTable("Qin")
                    Dim _qinData As DataColumn = New DataColumn("Qin", GetType(Double))
                    Dim _qinTime As DataColumn = New DataColumn(tTime, GetType(Double))

                    Dim _runoffFlow As DataTable = New DataTable(tRunoff)
                    Dim _runoffData As DataColumn = New DataColumn(tRunoff, GetType(Double))
                    Dim _runoffTime As DataColumn = New DataColumn(tTime, GetType(Double))

                    If (_hydroflow.ExtendedProperties.Contains("Color")) Then
                        Dim _object As Object = _hydroflow.ExtendedProperties.Item("Color")
                        _qinFlow.ExtendedProperties.Add("Color", _object)
                        _object = _hydroflow.ExtendedProperties.Item("Color")
                        _runoffFlow.ExtendedProperties.Add("Color", _object)
                    End If

                    _qinFlow.Columns.Add(_qinData)          ' Qin is X
                    _qinFlow.Columns.Add(_qinTime)          ' Time is Y

                    _runoffFlow.Columns.Add(_runoffData)    ' Runoff is X
                    _runoffFlow.Columns.Add(_runoffTime)    ' Time is Y

                    For Each _hydroRow As DataRow In _hydroflow.Rows

                        ' Build Qin DataTable
                        Dim _qinRow As DataRow = _qinFlow.NewRow

                        _qinRow(0) = _hydroRow(1)           ' Reverse X & Y
                        _qinRow(1) = _hydroRow(0)

                        _qinFlow.Rows.Add(_qinRow)

                        ' Build Runoff DataTable
                        Dim _runoffRow As DataRow = _runoffFlow.NewRow

                        _runoffRow(0) = _hydroRow(_runoffIdx)   ' Reverse X & Y
                        _runoffRow(1) = _hydroRow(0)

                        _runoffFlow.Rows.Add(_runoffRow)
                    Next

                    If (mQin Is Nothing) Then
                        mQin = New DataSet("Qin")
                    Else
                        _qinFlow.TableName = "Hydro Qin"
                    End If
                    mQin.Tables.Add(_qinFlow)

                    If (mRunoff Is Nothing) Then
                        mRunoff = New DataSet(tRunoff)
                    Else
                        _runoffFlow.TableName = "Hydro Runoff"
                    End If
                    mRunoff.Tables.Add(_runoffFlow)
                Else
                    Debug.Assert(False, "Not enough data is Hydroflow DataTable")
                End If
            Else
                Debug.Assert(False, "Hydroflow DataSet is empty")
            End If
        Else
            Debug.Assert(False, "Hydroflow DataSet is Nothing")
        End If

    End Sub

    Protected Overrides Sub DisposeGraph2D()
        MyBase.DisposeGraph2D()

        mAdvRec = Nothing
        mInfiltration = Nothing
        mQin = Nothing
        mRunoff = Nothing
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
        Dim tHydraulicSummary As String = mDictionary.tHydraulicSummary.Translated
        Dim _titleSizeF As SizeF = mGraphics.MeasureString(tHydraulicSummary, mBold)

        ' Draw the Title
        Dim x As Integer = CInt((Me.Width - _titleSizeF.Width) / 2)
        Dim y As Integer = CInt(_titleSizeF.Height)

        ' Draw the Graph's ExtTitle(s) from the DataSet
        If (mExtTitle Is Nothing) Then
            AddText(tHydraulicSummary, mBold, mBlackPen1.Color, x, y, False, False)
        Else
            Dim _subtitleSizeF = mGraphics.MeasureString(mExtTitle, mBold)
            x -= _subtitleSizeF.Width / 2
            AddText(tHydraulicSummary, mBold, mBlackPen1.Color, x, y, False, False)

            x += _subtitleSizeF.Width
            AddText(mExtTitle, mBold, WinSRFR.UserPreferences.Color2, x, y, False, False)
        End If

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

        If Not (mDataTable Is Nothing) Then
            ' Draw the top axis' title & labels
            DrawTopAxisTitle(mDataTable)
            DrawTopAxisLabels(mDataTable, True)

            ' Draw axes (Bottom is drawn by Infiltration subgraph)
            DrawTopAxis(True)
            DrawLeftAxis(True)
            DrawRightAxis(True)
            'DrawBottomAxis(True)
        Else
            Debug.Assert(False, "DataTable is Nothing")
        End If

    End Sub
    '
    ' Draw Infiltration subgraph axes
    '
    Protected Overridable Sub DrawInfiltrationAxes()

        If Not (mDataTable Is Nothing) Then
            ' Draw the bottom axis' title & labels
            DrawBottomAxisTitle(mDataTable)
            DrawBottomAxisLabels(mDataTable, True)

            ' Draw the side axes' titles & labels
            DrawLeftAxisTitle(mDataTable)
            DrawLeftAxisLabels(mDataTable, False)

            DrawRightAxisTitle(mDataTable)
            DrawRightAxisLabels(mDataTable, False)

            ' Draw all four axes
            DrawTopAxis(True)
            DrawLeftAxis(True)
            DrawRightAxis(True)
            DrawBottomAxis(True)
        Else
            Debug.Assert(False, "DataTable is Nothing")
        End If

    End Sub
    '
    ' Draw Qin subgraph axes
    '
    Protected Overridable Sub DrawQinAxes()

        If Not (mDataTable Is Nothing) Then
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

        If Not (mDataTable Is Nothing) Then
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

        If (_unitRangeX < 0.005) Then
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

        If (_unitRangeX < 0.005) Then
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

#Region " Public Methods "

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
            '
            ' Draw Advance / Recession subgraph
            '
            If (mAdvRec IsNot Nothing) Then
                mDataSet = mAdvRec
                Me.FindMinMax()

                ' Save 1st DataTable (used to draw axes * 1st set curves)
                If (0 < mAdvRec.Tables.Count) Then
                    mDataTable = mAdvRec.Tables(0).Copy
                    mDataTable.Columns(0).ColumnName = mDictionary.tAdvance.Translated & " / " & mDictionary.tRecession.Translated & " (m)"

                    mTop = CSng((Me.Height * mAdvRecTop) / 100.0)
                    mLeft = CSng((Me.Width * mAdvRecLeft) / 100.0)
                    mWidth = CSng((Me.Width * mAdvRecWidth) / 100.0)
                    mHeight = CSng((Me.Height * mAdvRecHeight) / 100.0)

                    UnitsX = UnitsDefinition.Units.Meters
                    UnitsY = UnitsDefinition.Units.Seconds
                    PosDirX = grf_XYGraph.PositiveDirection.PosRight
                    PosDirY = grf_XYGraph.PositiveDirection.PosUp

                    Me.MaxX = mLength

                    ScaleGraph()
                    DrawCurves()
                    DrawAdvRecAxes()
                Else
                    Debug.Assert(False, "Advance / Recession is empty")
                End If
            Else
                Debug.Assert(False, "Advance / Recession is Nothing")
            End If

            Dim _advRecMinX As Double = Me.MinX
            Dim _advRecMaxX As Double = Me.MaxX
            Dim _advRecMinY As Double = Me.MinY
            Dim _advRecMaxY As Double = Me.MaxY
            '
            ' Draw Infiltration subgraph
            '
            If Not (mInfiltration Is Nothing) Then
                mDataSet = mInfiltration
                Me.FindMinMax()

                ' Save 1st DataTable (used to draw axes * 1st set curves)
                If (0 < mInfiltration.Tables.Count) Then
                    mDataTable = mInfiltration.Tables(0)
                    mDataTable.Columns(0).ColumnName = mDictionary.tDistance.Translated
                    mDataTable.Columns(1).ColumnName = mDictionary.tInfiltration.Translated

                    mTop = CSng((Me.Height * mInfiltTop) / 100.0)
                    mLeft = CSng((Me.Width * mInfiltLeft) / 100.0)
                    mWidth = CSng((Me.Width * mInfiltWidth) / 100.0)
                    mHeight = CSng((Me.Height * mInfiltHeight) / 100.0)

                    UnitsX = UnitsDefinition.Units.Meters
                    UnitsY = UnitsDefinition.Units.Millimeters
                    PosDirX = grf_XYGraph.PositiveDirection.PosRight
                    PosDirY = grf_XYGraph.PositiveDirection.PosDown

                    Me.MinY = 0.0
                    Me.MaxX = mLength

                    ScaleGraph()
                    DrawCurves()
                    DrawCurveLabels()
                    DrawInfiltrationAxes()
                Else
                    Debug.Assert(False, "Infiltration is empty")
                End If
            Else
                Debug.Assert(False, "Infiltration is Nothing")
            End If
            '
            ' Draw Qin subgraph
            '
            Dim _qinMax As Double

            If Not (mQin Is Nothing) Then
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
                    mMaxY = _advRecMaxY
                    mRangeY = mMaxY - mMinY

                    ScaleGraph()
                    DrawCurves()
                    DrawQinAxes()
                Else
                    Debug.Assert(False, "Qin is empty")
                End If
            Else
                Debug.Assert(False, "Qin is Nothing")
            End If
            '
            ' Draw Runoff subgraph
            '
            If Not (mRunoff Is Nothing) Then
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
                    mMaxY = _advRecMaxY
                    mRangeY = mMaxY - mMinY

                    ScaleGraph()
                    DrawCurves()
                    DrawRunoffAxes()
                Else
                    Debug.Assert(False, "Runoff is empty")
                End If
            Else
                Debug.Assert(False, "Runoff is Nothing")
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

        ' Then Runoff
        UnitsX = UnitsDefinition.Units.Cms
        UnitsY = UnitsDefinition.Units.Seconds
        CopyDataSetAsText(mRunoff, False)

        ' End with Infiltration
        UnitsX = UnitsDefinition.Units.Meters
        UnitsY = UnitsDefinition.Units.Millimeters
        CopyDataSetAsText(mInfiltration, True)
    End Sub

#End Region

#End Region

End Class
