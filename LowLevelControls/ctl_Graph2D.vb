
'*************************************************************************************************************
' ctl_Graph2D - Control for drawing 2D Cartesian Coordinate graphs.
'
' Graphics UI object hierarchy:
'
'   System.Windows.Forms.PictureBox
'       ex_PictureBox
'           ctl_Canvas2D
'               ctl_Graph2D
'               ctl_Contour2D
'
' ctl_Graph2D graphs data from a DataSet where each DataTable in the DataSet represents a set
'   of curves to be graphed.  The 1st DataColumn in a DataTable holds the abscissa (X) values
'   while the remaining DataColumns hold one or more sets of ordinate (Y) values.
'
' ctl_Graph2D is initialized with a DataSet containing zero or more DataTables.  DataTables can
'   be added or removed after initialization.
'
' ctl_Graph2D divides the drawing region as follows:
'
'        _______________________________
'       |             Title             |
'       |   _________________________   |
'       |  |                         |  |
'       |  |                         |  |
'       |  |                         |  |
'       |  |                         |  |
'       |  |          Graph          |  |
'       |  |                         |  |
'       |  |                         |  |
'       |  |                         |  |
'       |  |_________________________|  |
'       |                               |
'       |  Key(s)                Inset  |
'       |_______________________________|
'
'   Title -     defaults to DataSet name
'               overridden by DataSet.ExtendedProperties("Title")
'
'   Graph -     defined by DataTables
'
'   Key(s) -    optional - defined by DataTable.ExtendedProperties("Key")
'                               or by DataColumn.ExtendedProperties("Key")
'
'   Inset -     optional - defined by DataSet.ExtendedProperties("Inset")
'
'   Color(s) -  optional - defined by DataTable.ExtendedProperties("Color")
'                               or by DataColumn.ExtendedProperties("Color")
'
Public Class ctl_Graph2D
    Inherits ctl_Canvas2D

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
        InitializeGraph2D(_dataSet)

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
                Me.DisposeGraph2D()
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

#Region " Embedded Classes "
    '
    ' Class for adding a Symbol (e.g. 'X' | 'x' | 'O' | 'o') to a graph
    '
    Public Class GraphSymbol
        Public X As Single              ' (X, Y) location for the Symbol
        Public Y As Single
        Public Symbol As String         ' 'X' | 'x' | 'O' | 'o'
        Public Color As Drawing.Color   ' Color for the Symbol
        Public Width As Integer         ' Line width for drawing the Symbol

        Public Sub New(ByVal X As Single, ByVal Y As Single, ByVal Symbol As String,
                       ByVal Color As Drawing.Color, Optional ByVal Width As Integer = 2)
            Me.X = X
            Me.Y = Y
            Me.Symbol = Symbol
            Me.Color = Color
            Me.Width = Width
        End Sub
    End Class
    '
    ' Class for adding a Text Line (e.g. "Description..." to a graph
    '
    Public Class TextLine
        Public X As Single              ' (X, Y) location for the Text Line
        Public Y As Single
        Public LineText As String       ' Text for Line
        Public Color As Drawing.Color   ' Color for the Symbol

        Public Sub New(ByVal X As Single, ByVal Y As Single, ByVal LineText As String,
                       ByVal Color As Drawing.Color)
            Me.X = X
            Me.Y = Y
            Me.LineText = LineText
            Me.Color = Color
        End Sub
    End Class

#End Region

#Region " Member Data "
    '
    ' Data to be drawn (loaded by constructor)
    '
    Protected mDataSet As DataSet
    Protected mDataTable As DataTable
    '
    ' Drawing controls
    '
    Protected mColorNo As Integer
    Protected mKeysPerLine As Integer = 4

#End Region

#Region " Properties "
    '
    ' The direction for positive values
    '
    Public Enum PositiveDirection
        PosUp
        PosDown
        PosLeft
        PosRight
    End Enum

    Protected mPosDirX As PositiveDirection = PositiveDirection.PosRight
    Protected mPosDirY As PositiveDirection = PositiveDirection.PosUp

    Public Property PosDirX() As PositiveDirection
        Get
            Return mPosDirX
        End Get
        Set(ByVal Value As PositiveDirection)
            mPosDirX = Value
        End Set
    End Property

    Public Property PosDirY() As PositiveDirection
        Get
            Return mPosDirY
        End Get
        Set(ByVal Value As PositiveDirection)
            mPosDirY = Value
        End Set
    End Property
    '
    ' Min & Max X & Y values (SI units)
    '
    ' These values define the limits for the X & Y-axes.
    '
    Protected mMinX As Single
    Protected mMaxX As Single

    Protected mMinY As Single
    Protected mMaxY As Single

    Protected mRangeX, mRangeY As Single

    Protected mValidValues As Boolean = False

    Public Property MinX() As Single
        Get
            Return mMinX
        End Get
        Set(ByVal Value As Single)
            If (Value < mMinX) Then
                mMinX = Value
                mRangeX = mMaxX - mMinX
            End If
        End Set
    End Property

    Public Property MaxX() As Single
        Get
            Return mMaxX
        End Get
        Set(ByVal Value As Single)
            If (mMaxX < Value) Then
                mMaxX = RoundUp(Value)
                mRangeX = mMaxX - mMinX
            End If
        End Set
    End Property

    Public Property MinY() As Single
        Get
            Return mMinY
        End Get
        Set(ByVal Value As Single)
            If (Value < mMinY) Then
                mMinY = Value
                mRangeY = mMaxY - mMinY
            End If
        End Set
    End Property

    Public Property MaxY() As Single
        Get
            Return mMaxY
        End Get
        Set(ByVal Value As Single)
            If (mMaxY < Value) Then
                mMaxY = RoundUp(Value)
                mRangeY = mMaxY - mMinY
            End If
        End Set
    End Property
    '
    ' Graph Key
    '
    Protected mDisplayKey As Boolean = True     ' Display the Key?
    Public Property DisplayKey() As Boolean
        Get
            Return mDisplayKey
        End Get
        Set(ByVal Value As Boolean)
            mDisplayKey = Value
        End Set
    End Property

    Public Function CurveKey(ByVal CurveNo As Integer) As String
        Try
            For tdx As Integer = 0 To mDataSet.Tables.Count - 1
                Dim numCurves As Integer = mDataSet.Tables(tdx).Columns.Count - 1
                If (CurveNo <= numCurves) Then
                    Dim col As DataColumn = mDataSet.Tables(tdx).Columns(CurveNo)
                    If (col.ExtendedProperties.Contains("Key")) Then
                        Dim obj As Object = col.ExtendedProperties.Item("Key")
                        If (obj.GetType Is GetType(String)) Then
                            CurveKey = CStr(obj).Trim
                        Else
                            CurveKey = col.ColumnName
                        End If
                    Else
                        CurveKey = col.ColumnName
                    End If

                    Exit Function
                End If
                CurveNo -= numCurves
            Next tdx
            CurveKey = ""
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
            CurveKey = ""
        End Try
    End Function

    Public Function KeySymbol(ByVal CurveNo As Integer) As String
        KeySymbol = ""

        Try
            For tdx As Integer = 0 To mDataSet.Tables.Count - 1
                Dim numCurves As Integer = mDataSet.Tables(tdx).Columns.Count - 1
                If (CurveNo <= numCurves) Then
                    Dim table As DataTable = mDataSet.Tables(tdx)
                    If (table.ExtendedProperties.Contains("Symbol")) Then
                        Dim obj As Object = table.ExtendedProperties.Item("Symbol")
                        If (obj.GetType Is GetType(String)) Then
                            KeySymbol = CStr(obj).Trim
                        End If
                    End If

                    Exit Function
                End If
                CurveNo -= numCurves
            Next tdx

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
            KeySymbol = ""
        End Try
    End Function

    Public Function KeyLine(ByVal CurveNo As Integer) As Boolean
        KeyLine = False

        Try
            For tdx As Integer = 0 To mDataSet.Tables.Count - 1
                Dim numCurves As Integer = mDataSet.Tables(tdx).Columns.Count - 1
                If (CurveNo <= numCurves) Then
                    Dim table As DataTable = mDataSet.Tables(tdx)
                    If (table.ExtendedProperties.Contains("Line")) Then
                        Dim obj As Object = table.ExtendedProperties.Item("Line")
                        If (obj.GetType Is GetType(Boolean)) Then
                            KeyLine = CBool(obj)
                        End If
                    End If

                    Exit Function
                End If
                CurveNo -= numCurves
            Next tdx

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
            KeyLine = False
        End Try
    End Function
    '
    ' Additional horizontal & vertical lines
    '
    Private mHorzLines() As Single
    Public Property HorzLines() As Single()
        Get
            Return mHorzLines
        End Get
        Set(ByVal value As Single())
            mHorzLines = value
        End Set
    End Property

    Public Sub AddHorzLine(ByVal HorzLine As Single)
        If (mHorzLines Is Nothing) Then
            ReDim mHorzLines(0)
            mHorzLines(0) = HorzLine
        Else
            Dim count As Integer = mHorzLines.Length
            ReDim Preserve mHorzLines(count)
            mHorzLines(count) = HorzLine
        End If
    End Sub

    Public Sub ClearHorzLines()
        mHorzLines = Nothing
    End Sub

    Private mVertLines() As Single
    Public Property VertLines() As Single()
        Get
            Return mVertLines
        End Get
        Set(ByVal value As Single())
            mVertLines = value
        End Set
    End Property

    Private mVertLabels() As String
    Public Property VertLabels() As String()
        Get
            Return mVertLabels
        End Get
        Set(ByVal value As String())
            mVertLabels = value
        End Set
    End Property

    Private mVLabelPos() As Single
    Public Property VLabelPos() As Single()
        Get
            Return mVLabelPos
        End Get
        Set(ByVal value As Single())
            mVLabelPos = value
        End Set
    End Property

    Public Sub AddVertLine(ByVal VertLine As Single, Optional ByVal Label As String = "", Optional ByVal VPos As Single = 0.0)
        If (mVertLines Is Nothing) Then
            ReDim mVertLines(0)
            mVertLines(0) = VertLine
            ReDim mVertLabels(0)
            mVertLabels(0) = Label
            ReDim mVLabelPos(0)
            mVLabelPos(0) = VPos
        Else
            Dim count As Integer = mVertLines.Length
            ReDim Preserve mVertLines(count)
            mVertLines(count) = VertLine
            ReDim Preserve mVertLabels(count)
            mVertLabels(count) = Label
            ReDim Preserve mVLabelPos(count)
            mVLabelPos(count) = VPos
        End If
    End Sub

    Public Sub ClearVertLines()
        mVertLines = Nothing
        mVertLabels = Nothing
        mVLabelPos = Nothing
    End Sub
    '
    ' Additional symbols
    '
    Private mGraphSymbols() As GraphSymbol
    Public Property GraphSymbols() As GraphSymbol()
        Get
            Return mGraphSymbols
        End Get
        Set(ByVal value As GraphSymbol())
            mGraphSymbols = value
        End Set
    End Property

    Public Sub AddGraphSymbol(ByVal X As Single, ByVal Y As Single, ByVal Symbol As String,
                              ByVal Color As Drawing.Color, Optional ByVal Width As Integer = 2)
        If (mGraphSymbols Is Nothing) Then
            ReDim mGraphSymbols(0)
            mGraphSymbols(0) = New GraphSymbol(X, Y, Symbol, Color, Width)
        Else
            Dim count As Integer = mGraphSymbols.Length
            ReDim Preserve mGraphSymbols(count)
            mGraphSymbols(count) = New GraphSymbol(X, Y, Symbol, Color, Width)
        End If
    End Sub

    Public Sub ClearGraphSymbols()
        mGraphSymbols = Nothing
    End Sub
    '
    ' Additional lines of text
    '
    Private mTextLines() As TextLine
    Public Property TextLines() As TextLine()
        Get
            Return mTextLines
        End Get
        Set(ByVal value As TextLine())
            mTextLines = value
        End Set
    End Property

    Public Sub AddTextLine(ByVal X As Single, ByVal Y As Single, ByVal TextLine As String,
                           ByVal Color As Drawing.Color)
        If (mTextLines Is Nothing) Then
            ReDim mTextLines(0)
            mTextLines(0) = New TextLine(X, Y, TextLine, Color)
        Else
            Dim count As Integer = mTextLines.Length
            ReDim Preserve mTextLines(count)
            mTextLines(count) = New TextLine(X, Y, TextLine, Color)
        End If
    End Sub

    Public Sub ClearTextLines()
        mTextLines = Nothing
    End Sub

#End Region

#Region " Initialization "

    Public Sub InitializeGraph2D(ByVal _dataSet As DataSet)

        If (_dataSet IsNot Nothing) Then

            ' Save the DataSet
            mDataSet = _dataSet

            Me.AccessibleName = mDataSet.DataSetName

            ' Find the Min & Max values for the DataSet
            FindMinMax()

            ' First DataTable defines Axis titles and labels
            If (0 < mDataSet.Tables.Count) Then
                mDataTable = mDataSet.Tables(0)
            Else
                mDataTable = Nothing
            End If
        End If
    End Sub

    Protected Overridable Sub DisposeGraph2D()
        MyBase.DisposeOfCanvas()

        If (mDataSet IsNot Nothing) Then
            mDataSet.Dispose()
            mDataSet = Nothing
        End If

        If (mDataTable IsNot Nothing) Then
            mDataTable.Dispose()
            mDataTable = Nothing
        End If
    End Sub

#End Region

#Region " Protected Methods "

#Region " Utilities "
    '
    ' Convert label SI Units to one with UI Units
    '
    Protected Function UiLabelUnits(ByVal SiLabelUnits As String) As String
        Dim siLabel As String = ""
        Dim SiUnits As String = ""
        ParseLabelUnits(SiLabelUnits, siLabel, SiUnits)
        If (0 < SiUnits.Length) Then
            UiLabelUnits = siLabel & " (" & UnitsDialog.UiUnitsText(SiUnits) & ")"
        Else
            UiLabelUnits = siLabel
        End If
    End Function
    '
    ' Parse a label with units into its separate label & units
    '
    Protected Sub ParseLabelUnits(ByVal LabelUnits As String, ByRef Label As String, ByRef Units As String)
        Label = LabelUnits.Trim
        Units = ""
        Dim unitsStart As Integer = LabelUnits.IndexOf("(") + 1
        If (unitsStart > 0) Then
            Label = LabelUnits.Substring(0, unitsStart - 1).Trim
            Dim unitsEnd As Integer = LabelUnits.IndexOf(")")
            If (unitsEnd > unitsStart) Then
                Units = LabelUnits.Substring(unitsStart, unitsEnd - unitsStart).Trim
            End If
        End If
    End Sub
    '
    ' Set / Reset the Min & Max values
    '
    Protected Overridable Sub ResetMinMax()
        mMinX = 0.0
        mMaxX = Single.MinValue

        mMinY = 0.0
        mMaxY = Single.MinValue

        mValidValues = False
    End Sub
    '
    ' Find the Min & Max values for the DataSet
    '
    Protected Overridable Sub FindMinMax()

        ' Reset Min & Max values
        ResetMinMax()

        If (mDataSet IsNot Nothing) Then
            '
            ' Find max & min X & Y values (in SI Units)
            '   Max & Min can be preset by caller
            '
            For Each _dataTable As DataTable In mDataSet.Tables

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
            Next

            ' If minimum values are relatively close (<10% of max) to zero; set them to zero
            If (mMinX < (mMaxX * 0.1)) Then
                mMinX = 0.0
            End If

            If ((0.0 < mMinY) And (mMinY < (mMaxY * 0.1))) Then
                mMinY = 0.0
            End If

            ' Round up so curves do not touch at the top
            mMaxX = RoundUp(mMaxX)
            mMaxY = RoundUp(mMaxY)

            ' Compute X & Y ranges (in SI Units)
            mRangeX = mMaxX - mMinX
            mRangeY = mMaxY - mMinY
        End If

        If ((0.0 < mRangeX) And (0.0 < mRangeY)) Then
            mValidValues = True
        End If

    End Sub
    '
    ' Round a value up to a more UI friendle value
    '
    Protected Function RoundUp(ByVal Value As Single) As Single
        RoundUp = Value

        If (Value < 0.5!) Then ' round up to next 0.1
            Value *= 10.0!
            Value = CSng(Math.Ceiling(Value))
            Value /= 10.0!
            RoundUp = Value
        ElseIf (Value < 1.0!) Then ' round up to next 0.2
            Value *= 5.0!
            Value = CSng(Math.Ceiling(Value))
            Value /= 5.0!
            RoundUp = Value
        ElseIf (Value < 10.0!) Then ' round up to next 1.0
            Value = CSng(Math.Ceiling(Value))
            RoundUp = Value
        ElseIf (Value < 20.0!) Then ' round up to next 2.0
            Value /= 5.0!
            Value = CSng(Math.Ceiling(Value))
            Value *= 5.0!
            RoundUp = Value
        Else ' round up to next 10.0
            Value /= 10.0!
            Value = CSng(Math.Ceiling(Value))
            Value *= 10.0!
            RoundUp = Value
        End If

    End Function

#End Region

#Region " Scale Methods "
    '
    ' Scale the fonts
    '
    Protected Overridable Sub ScaleFonts()

        ' Scale fonts based on available Bitmap size
        Dim fontSize As Single = CInt(Math.Ceiling(Math.Min(Me.Height / 70, Me.Width / 70) + 5))
        fontSize = Math.Max(fontSize, 7) ' Minimum font size is 7

        mFont = New Font(mFont.FontFamily, fontSize)
        mBold = New Font(mFont, FontStyle.Bold)

        fontSize = CInt(Math.Ceiling(Math.Min(Me.Height / 70, Me.Width / 80) + 5))
        fontSize = Math.Max(fontSize, 7) ' Minimum font size is 7

        mCourier = New Font("Courier New", fontSize)

        ' Define max size of one text line for the key
        mKeyLineSize = mGraphics.MeasureString("01234567890123456789", mFont)

        ' Define portion of the Bitmap available for the graph
        Dim labelSize As SizeF = mGraphics.MeasureString("1.23", mCourier)

        mTop = labelSize.Height * 2
        mLeft = labelSize.Height * 2.5! + labelSize.Width
        mWidth = Me.Width - mLeft * 2 - labelSize.Height - mKeyLineSize.Width
        mHeight = Me.Height - mTop - labelSize.Height * 3
        mBottom = mTop + mHeight
        mRight = mLeft + mWidth

    End Sub
    '
    ' Scale the graph, on a 1,2,5 scale, based on min / max values (i.e ranges)
    '
    Protected Overridable Sub ScaleGraph()
        ' Scale the fonts first, then scale the X & Y axes on a 1,2,5 scale
        ScaleFonts()

        Dim scaleX As Single = Scale125(mRangeX, mMajorTickX, mMinorTickX)
        Dim scaleY As Single = Scale125(mRangeY, mMajorTickY, mMinorTickY)
    End Sub
    '
    ' Calculate the Major & Minor ticks to display the input range based on a 1, 2, 5 scale
    '
    ' Returns Major & Minor ticks for a 1, 2, 5 scaled graph.
    ' Returns the range scaled to fit between 0.0-10.0
    '
    Public Function Scale125(ByVal range As Single, ByRef majorTick As Single, ByRef minorTick As Single) As Single

        Dim intLog10 As Single

        Try ' Math can cause an exception
            intLog10 = CInt(Int(Math.Log10(range)))
        Catch ex As Exception
            intLog10 = 1
        End Try

        Scale125 = CSng(range / (10 ^ intLog10))   ' 0.0 < scaled range < 10.0

        If (Scale125 < 1.8) Then
            majorTick = CSng(2.0 * (10 ^ (intLog10 - 1)))
            minorTick = CSng(0.5 * (10 ^ (intLog10 - 1)))
        ElseIf (Scale125 < 3.6) Then
            majorTick = CSng(5.0 * (10 ^ (intLog10 - 1)))
            minorTick = CSng(1.0 * (10 ^ (intLog10 - 1)))
        ElseIf (Scale125 < 7.2) Then
            majorTick = CSng(10.0 * (10 ^ (intLog10 - 1)))
            minorTick = CSng(2.0 * (10 ^ (intLog10 - 1)))
        Else
            majorTick = CSng(2.0 * (10 ^ intLog10))
            minorTick = CSng(0.5 * (10 ^ intLog10))
        End If

    End Function

#End Region

#Region " Title Methods "

    '*********************************************************************************************************
    ' DrawGraphTitle()      - Draw graph's Title
    ' DrawLeftAxisTitles()  - Draw left axis title(s)
    ' DrawRighttAxisTitle() -   "  right  "    "
    ' DrawTopAxisTitle()    -   "  top    "    "
    ' DrawBottomAxisTitle() -   "  bottom "    "
    '*********************************************************************************************************
    Protected Overridable Sub DrawGraphTitle()

        ' Title is DataSet Name
        Dim title As String = mDataSet.DataSetName

        ' Display title at Center/Top
        Dim size As SizeF = mGraphics.MeasureString(title, mBold)
        Dim x As Integer = CInt(mLeft + (mWidth - size.Width) / 2)      ' Center
        Dim y As Integer = 2                                            ' Top

        AddText(title, mBold, mBlackPen1.Color, x, y, False, False)

    End Sub

    Protected Overridable Sub DrawLeftAxisTitles(ByVal table As DataTable)

        ' Draw graph's left-axis title
        If (1 < table.Columns.Count) Then ' at least 1 curve

            ' Title is Column Name
            Dim title As String = UiLabelUnits(table.Columns(1).ColumnName)

            ' Position text relative to graph and size of title
            Dim titleSize As SizeF = mGraphics.MeasureString(title, mFont)
            Dim x As Integer = CInt(titleSize.Height) + 2
            Dim y As Integer = CInt(mTop + ((mHeight - titleSize.Width) / 2))

            AddText(title, mFont, mBlackPen1.Color, x, y, False, True)

            If (2 < table.Columns.Count) Then ' at least 2 curves

                ' Default title is Column Name
                title = UiLabelUnits(table.Columns(2).ColumnName)

                ' Position based on size of title
                titleSize = mGraphics.MeasureString(title, mFont)
                x = 2
                y = CInt(mTop + ((mHeight - titleSize.Width) / 2))

                AddText(title, mFont, mBlackPen1.Color, x, y, False, True)

            End If
        End If

    End Sub

    Protected Overridable Sub DrawRightAxisTitle(ByVal table As DataTable)

        ' Draw graph's right-axis title
        If (1 < table.Columns.Count) Then ' at least 1 curve

            ' Title is Column Name
            Dim title As String = UiLabelUnits(table.Columns(1).ColumnName)

            ' Position based on size of title
            Dim _sizeF As SizeF = mGraphics.MeasureString(title, mFont)
            Dim x As Integer = CInt(mRight + (_sizeF.Height * 2.5!))
            Dim y As Integer = CInt(mTop + ((mHeight - _sizeF.Width) / 2))

            AddText(title, mFont, mBlackPen1.Color, x, y, False, True)

        End If

    End Sub

    Protected Overridable Sub DrawBottomAxisTitle(ByVal table As DataTable)

        ' Draw graph's bottom axis title
        If (2 <= table.Columns.Count) Then

            ' Title is Column Name
            Dim title As String = UiLabelUnits(table.Columns(0).ColumnName)

            ' Position based on size of title
            Dim _sizeF As SizeF = mGraphics.MeasureString(title, mFont)
            Dim x As Integer = CInt(mLeft + ((mWidth - _sizeF.Width) / 2))
            Dim y As Integer = CInt(Me.Height - _sizeF.Height - 3)

            AddText(title, mFont, mBlackPen1.Color, x, y, False, False)

        End If

    End Sub

#End Region

#Region " Key Methods "

    Protected Overridable Sub DrawKey()

        ' Draw the Graph Key only if it is enabled
        If (DisplayKey) Then

            Dim keys As List(Of String()) = New List(Of String())
            Dim keyLineCount As Integer = 0

            For kdx As Integer = 1 To 4
                Dim cKey As String = CurveKey(kdx)
                If (cKey = "") Then
                    Exit For
                Else
                    Dim fKey As String() = FormatKey(cKey, mFont)
                    keyLineCount += fKey.Length
                    keys.Add(fKey)
                End If
            Next

            ' Draw box for keys
            Dim keyWidth As Single = mKeyLineSize.Width + 15
            Dim keyHeight As Single = mKeyLineSize.Height * (keyLineCount + 3)
            Dim keyTop As Single = mTop + (mHeight - keyHeight) / 2
            Dim keyBottom As Single = keyTop + keyHeight
            Dim keyLeft As Single = Me.Width - keyWidth - 10
            Dim keyRight As Single = keyLeft + keyWidth

            mGraphics.DrawLine(mBlackPen1, keyLeft, keyTop, keyRight, keyTop)
            mGraphics.DrawLine(mBlackPen1, keyRight, keyTop, keyRight, keyBottom)
            mGraphics.DrawLine(mBlackPen1, keyRight, keyBottom, keyLeft, keyBottom)
            mGraphics.DrawLine(mBlackPen1, keyLeft, keyBottom, keyLeft, keyTop)

            ' Draw keys
            Dim pen2 As Pen = BlackPen2()

            keyLeft += 18   ' Indent within box

            For kdx As Integer = 1 To keys.Count
                If (kdx < mPens2.Length) Then
                    pen2 = mPens2(kdx)
                End If

                Dim key As String() = keys(kdx - 1)

                keyTop += mKeyLineSize.Height / 2

                Dim symbol As String = KeySymbol(kdx)
                Dim kLine As Boolean = KeyLine(kdx)

                If (symbol = "") Then ' no symbol to draw
                    mGraphics.DrawLine(pen2, keyLeft - 3, keyTop + 10, keyLeft - 13, keyTop + 20)
                Else
                    DrawSymbol(pen2, symbol, keyLeft - 8, keyTop + 15)
                    If (kLine) Then
                        mGraphics.DrawLine(pen2, keyLeft - 3, keyTop + 10, keyLeft - 13, keyTop + 20)
                    End If
                End If

                For Each line As String In key
                    mGraphics.DrawString(line, mFont, mBlackBrush, keyLeft, keyTop)
                    keyTop += mKeyLineSize.Height
                Next line
            Next kdx

        End If
    End Sub

    Protected Function FormatKey(ByVal Key As String, ByVal KeyFont As Font) As String()
        Dim keyLines As String() = {""}
        Dim numLines As Integer = keyLines.Length

        Dim lines() As String = Key.Split(Chr(13))
        For Each line As String In lines

            Dim tokens() As String = line.Split(" ".ToCharArray)
            For Each token As String In tokens
                If Not (token = "()") Then ' no units; don't display units
                    Dim siz1 As SizeF = mGraphics.MeasureString(keyLines(numLines - 1), KeyFont)
                    Dim siz2 As SizeF = mGraphics.MeasureString(token, KeyFont)

                    If (siz1.Width + siz2.Width < mKeyLineSize.Width) Then
                        If (keyLines(numLines - 1) = "") Then
                            keyLines(numLines - 1) = token
                        Else
                            keyLines(numLines - 1) &= " " & token
                        End If
                    Else
                        ReDim Preserve keyLines(numLines)
                        keyLines(numLines) = token
                        numLines += 1
                    End If
                End If
            Next token

            ReDim Preserve keyLines(numLines)
            keyLines(numLines) = ""
            numLines += 1
        Next line

        If (keyLines(numLines - 1) = "") Then
            ReDim Preserve keyLines(numLines - 1)
        End If

        Return keyLines
    End Function

#End Region

#Region " Axis Methods "

    Protected Overridable Sub DrawAxes()

        ' Draw the graph
        If (mDataTable IsNot Nothing) Then
            ' Draw the graph's title
            DrawGraphTitle()

            ' Draw the left and bottom axes' titles
            DrawLeftAxisTitles(mDataTable)
            DrawBottomAxisTitle(mDataTable)

            ' Draw all four axes w/labels
            DrawTopAxis(True)
            'DrawTopAxisLabels(mDataTable, True)

            DrawLeftAxis(True)
            DrawLeftAxisLabels(mDataTable, True)

            DrawRightAxis(True)
            'DrawRightAxisLabels(mDataTable, True)

            DrawBottomAxis(True)
            DrawBottomAxisLabels(mDataTable, True)
        Else
            DrawNoData()
        End If

    End Sub

    Protected Sub DrawNoData()

        ' Get the Graph's Title from the DataSet
        Dim _noData As String = "There is no data to graph"

        ' Scale the graph relative to the Bitmap size
        Dim _sizeF As SizeF = mGraphics.MeasureString(_noData, mBold)

        ' Draw the Title
        Dim x As Single = mLeft + ((mWidth - _sizeF.Width) / 2)
        Dim y As Single = mTop + (mHeight / 2)
        mGraphics.DrawString(_noData, mBold, mBlackBrush, x, y)

    End Sub

    Protected Overridable Sub DrawLeftAxis(ByVal _withMinor As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _mark As Single
        Dim _inc As Single

        ' Draw within a Try/Catch block in case mMajorTickY or mRangeY are zero
        Try
            _mark = mMajorTickY * (Int(mMinY / mMajorTickY))

            If (_mark < mMinY) Then
                _mark += mMajorTickY
            End If

            Dim _iter As Integer = 0
            While ((_mark <= mMaxY) And (_iter < 100))
                x = mLeft
                y = mTop

                _inc = ((_mark - mMinY) / mRangeY) * mHeight

                If (mPosDirY = PositiveDirection.PosUp) Then
                    y += mHeight - _inc
                Else ' Assume PosDown
                    y += _inc
                End If

                mGraphics.DrawLine(mBlackPen2, x - 5, y, x + 5, y)

                _mark += mMajorTickY
                _iter += 1
            End While

            ' Draw the minor tick marks
            If (_withMinor) Then
                _mark = mMinorTickY * (Int(mMinY / mMinorTickY))

                If (_mark < mMinY) Then
                    _mark += mMinorTickY
                End If

                _iter = 0
                While ((_mark <= mMaxY) And (_iter < 100))
                    x = mLeft
                    y = mTop

                    _inc = ((_mark - mMinY) / mRangeY) * mHeight

                    If (mPosDirY = PositiveDirection.PosUp) Then
                        y += mHeight - _inc
                    Else ' Assume PosDown
                        y += _inc
                    End If

                    mGraphics.DrawLine(mBlackPen2, x - 3, y, x, y)

                    _mark += mMinorTickY
                    _iter += 1
                End While

            End If

            ' Draw the axes
            x = mLeft
            y = mTop

            mGraphics.DrawLine(mBlackPen2, x, y, x, y + mHeight)
        Catch ex As Exception
            mGraphics.DrawLine(mBlackPen2, mLeft, mTop, mLeft, mTop + mHeight)
        End Try

    End Sub

    Protected Overridable Sub DrawRightAxis(ByVal _withMinor As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _mark As Single
        Dim _inc As Single

        ' Draw within a Try/Catch block in case mMajorTickY or mRangeY are zero
        Try
            _mark = mMajorTickY * (Int(mMinY / mMajorTickY))

            If (_mark < mMinY) Then
                _mark += mMajorTickY
            End If

            Dim _iter As Integer = 0
            While ((_mark <= mMaxY) And (_iter < 100))
                x = mLeft + mWidth
                y = mTop

                _inc = ((_mark - mMinY) / mRangeY) * mHeight

                If (mPosDirY = PositiveDirection.PosUp) Then
                    y += mHeight - _inc
                Else ' Assume PosDown
                    y += _inc
                End If

                mGraphics.DrawLine(mBlackPen2, x - 5, y, x + 5, y)

                _mark += mMajorTickY
                _iter += 1
            End While

            ' Draw the minor tick marks
            If (_withMinor) Then

                _mark = mMinorTickY * (Int(mMinY / mMinorTickY))

                If (_mark < mMinY) Then
                    _mark += mMinorTickY
                End If

                _iter = 0
                While ((_mark <= mMaxY) And (_iter < 100))
                    x = mLeft + mWidth
                    y = mTop

                    _inc = ((_mark - mMinY) / mRangeY) * mHeight

                    If (mPosDirY = PositiveDirection.PosUp) Then
                        y += mHeight - _inc
                    Else ' Assume PosDown
                        y += _inc
                    End If

                    mGraphics.DrawLine(mBlackPen2, x + 3, y, x, y)

                    _mark += mMinorTickY
                    _iter += 1
                End While
            End If

            ' Draw the axes
            x = mLeft + mWidth
            y = mTop

            mGraphics.DrawLine(mBlackPen2, x, y, x, y + mHeight)
        Catch ex As Exception
            mGraphics.DrawLine(mBlackPen2, mLeft + mWidth, mTop, mLeft + mWidth, mTop + mHeight)
        End Try

    End Sub

    Protected Overridable Sub DrawLeftAxisLabels(ByVal _dataTable As DataTable, ByVal _withZero As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _sizeF As New SizeF(0, 0)
        Dim _mark As Single
        Dim _text, _format As String

        ' Draw within a Try/Catch block in case mMajorTickY or mRangeY are zero
        Try
            _mark = mMajorTickY * (Int(mMinY / mMajorTickY))

            If (_mark < mMinY) Then
                _mark += mMajorTickY
            End If

            Dim _fontSize As Single = mFont.Size

            If (mRangeY < 0.005) Then
                '_format = "0.####"
                _format = "0.0#e+0#"
                _fontSize -= 1
            ElseIf (mRangeY < 0.05) Then
                _format = "0.0##"
            ElseIf (mRangeY < 0.5) Then
                _format = "0.0#"
            ElseIf (mRangeY < 10000.0) Then
                _format = "0.#"
            Else
                _format = "0.0e+0#"
                _fontSize -= 1
            End If

            Dim _font As Font = New Font(mFont.FontFamily, _fontSize)

            Dim _iter As Integer = 0
            While ((_mark <= mMaxY) And (_iter < 100))
                If (_withZero Or Not (_mark = 0.0)) Then
                    x = mLeft
                    y = mTop

                    If (mPosDirY = PositiveDirection.PosUp) Then
                        y += mHeight - (((_mark - mMinY) / mRangeY) * mHeight)
                    Else ' Assume PosDown
                        y += ((_mark - mMinY) / mRangeY) * mHeight
                    End If

                    _text = Format(_mark, _format)
                    _sizeF = mGraphics.MeasureString(_text, _font)

                    y -= _sizeF.Height / 2

                    mGraphics.DrawString(_text, _font, mBlackBrush, x - _sizeF.Width - 5, y)
                End If

                _mark += mMajorTickY
                _iter += 1
            End While
        Catch ex As Exception
        End Try

    End Sub

    Protected Overridable Sub DrawRightAxisLabels(ByVal _dataTable As DataTable, ByVal _withZero As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _sizeF As New SizeF(0, 0)
        Dim _mark As Single
        Dim _text, _format As String

        ' Draw within a Try/Catch block in case mMajorTickY or mRangeY are zero
        Try
            _mark = mMajorTickY * (Int(mMinY / mMajorTickY))

            If (_mark < mMinY) Then
                _mark += mMajorTickY
            End If

            Dim _fontSize As Single = mFont.Size

            If (mRangeY < 0.005) Then
                '_format = "0.####"
                _format = "0.0#e+0#"
                _fontSize -= 1
            ElseIf (mRangeY < 0.05) Then
                _format = "0.###"
            ElseIf (mRangeY < 0.5) Then
                _format = "0.##"
            ElseIf (mRangeY < 10000.0) Then
                _format = "0.#"
            Else
                _format = "0.0#e+0##"
                _fontSize -= 1
            End If

            Dim _font As Font = New Font(mFont.FontFamily, _fontSize)

            Dim _iter As Integer = 0
            While ((_mark <= mMaxY) And (_iter < 100))
                If (_withZero Or Not (_mark = 0.0)) Then
                    x = mLeft + mWidth
                    y = mTop

                    If (mPosDirY = PositiveDirection.PosUp) Then
                        y += mHeight - (((_mark - mMinY) / mRangeY) * mHeight)
                    Else ' Assume PosDown
                        y += ((_mark - mMinY) / mRangeY) * mHeight
                    End If

                    _text = Format(_mark, _format)
                    _sizeF = mGraphics.MeasureString(_text, _font)

                    y -= _sizeF.Height / 2

                    mGraphics.DrawString(_text, _font, mBlackBrush, x + 7, y)
                End If

                _mark += mMajorTickY
                _iter += 1
            End While
        Catch ex As Exception
        End Try

    End Sub

    Protected Overridable Sub DrawTopAxis(ByVal _withMinor As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _mark As Single
        Dim _inc As Single

        ' Draw within a Try/Catch block in case mMajorTickY or mRangeY are zero
        Try
            _mark = mMajorTickX * (Int(mMinX / mMajorTickX))

            If (_mark < mMinX) Then
                _mark += mMajorTickX
            End If

            Dim _iter As Integer = 0
            While ((_mark <= mMaxX) And (_iter < 100))
                x = mLeft
                y = mTop

                _inc = ((_mark - mMinX) / mRangeX) * mWidth

                If (mPosDirX = PositiveDirection.PosRight) Then
                    x += _inc
                Else ' Assume PosLeft
                    x += mWidth - _inc
                End If

                mGraphics.DrawLine(mBlackPen2, x, y - 5, x, y + 5)

                _mark += mMajorTickX
                _iter += 1
            End While

            ' Draw the minor tick marks
            If (_withMinor) Then

                If (5 < (mMinorTickX / mRangeX) * mWidth) Then

                    _mark = mMinorTickX * (Int(mMinX / mMinorTickX))

                    If (_mark < mMinX) Then
                        _mark += mMinorTickX
                    End If

                    _iter = 0
                    While ((_mark <= mMaxX) And (_iter < 100))
                        x = mLeft
                        y = mTop

                        _inc = ((_mark - mMinX) / mRangeX) * mWidth

                        If (mPosDirX = PositiveDirection.PosRight) Then
                            x += _inc
                        Else ' Assume PosLeft
                            x += mWidth - _inc
                        End If

                        mGraphics.DrawLine(mBlackPen2, x, y - 3, x, y)

                        _mark += mMinorTickX
                        _iter += 1
                    End While
                End If
            End If

            ' Draw the axes
            x = mLeft
            y = mTop

            mGraphics.DrawLine(mBlackPen2, x, y, x + mWidth, y)
        Catch ex As Exception
            mGraphics.DrawLine(mBlackPen2, mLeft, mTop, mLeft + mWidth, mTop)
        End Try

    End Sub

    Protected Overridable Sub DrawBottomAxis(ByVal _withMinor As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _mark As Single
        Dim _inc As Single

        ' Draw within a Try/Catch block in case mMajorTickY or mRangeY are zero
        Try
            _mark = mMajorTickX * (Int(mMinX / mMajorTickX))

            If (_mark < mMinX) Then
                _mark += mMajorTickX
            End If

            Dim _iter As Integer = 0
            While ((_mark <= mMaxX) And (_iter < 100))
                x = mLeft
                y = mTop + mHeight

                _inc = ((_mark - mMinX) / mRangeX) * mWidth

                If (mPosDirX = PositiveDirection.PosRight) Then
                    x += _inc
                Else ' Assume PosLeft
                    x += mWidth - _inc
                End If

                mGraphics.DrawLine(mBlackPen2, x, y - 5, x, y + 5)

                _mark += mMajorTickX
                _iter += 1
            End While

            ' Draw the minor tick marks
            If (_withMinor) Then

                If (5 < (mMinorTickX / mRangeX) * mWidth) Then

                    _mark = mMinorTickX * (Int(mMinX / mMinorTickX))

                    If (_mark < mMinX) Then
                        _mark += mMinorTickX
                    End If

                    _iter = 0
                    While ((_mark <= mMaxX) And (_iter < 100))
                        x = mLeft
                        y = mTop + mHeight

                        _inc = ((_mark - mMinX) / mRangeX) * mWidth

                        If (mPosDirX = PositiveDirection.PosRight) Then
                            x += _inc
                        Else ' Assume PosLeft
                            x += mWidth - _inc
                        End If

                        mGraphics.DrawLine(mBlackPen2, x, y + 3, x, y)

                        _mark += mMinorTickX
                        _iter += 1
                    End While
                End If
            End If

            ' Draw the axes
            x = mLeft
            y = mTop + mHeight

            mGraphics.DrawLine(mBlackPen2, x, y, x + mWidth, y)
        Catch ex As Exception
            mGraphics.DrawLine(mBlackPen2, mLeft, mTop + mHeight, mLeft + mWidth, mTop + mHeight)
        End Try

    End Sub

    Protected Overridable Sub DrawTopAxisLabels(ByVal _dataTable As DataTable, ByVal _withZero As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _sizeF As New SizeF(0, 0)
        Dim _mark As Single
        Dim _text, _format As String

        ' Draw within a Try/Catch block in case mMajorTickY or mRangeY are zero
        Try
            _mark = mMajorTickX * (Int(mMinX / mMajorTickX))

            If (_mark < mMinX) Then
                _mark += mMajorTickX
            End If

            If (mRangeX < 0.005) Then
                _format = "0.####"
            ElseIf (mRangeX < 0.05) Then
                _format = "0.###"
            ElseIf (mRangeX < 0.5) Then
                _format = "0.##"
            ElseIf (mRangeX < 10000.0) Then
                _format = "0.#"
            Else
                _format = "0.0#e+0##"
            End If

            Dim _iter As Integer = 0
            While ((_mark <= mMaxX) And (_iter < 100))
                If (_withZero Or Not (_mark = 0.0)) Then
                    x = mLeft
                    y = mTop

                    If (mPosDirX = PositiveDirection.PosRight) Then
                        x += ((_mark - mMinX) / mRangeX) * mWidth
                    Else ' Assume PosLeft
                        x += mWidth - (((_mark - mMinX) / mRangeX) * mWidth)
                    End If

                    _text = Format(_mark, _format)
                    _sizeF = mGraphics.MeasureString(_text, mFont)

                    x -= _sizeF.Width / 2

                    mGraphics.DrawString(_text, mFont, mBlackBrush, x, y - _sizeF.Height - 6)
                End If

                _mark += mMajorTickX
                _iter += 1
            End While
        Catch ex As Exception
        End Try

    End Sub

    Protected Overridable Sub DrawBottomAxisLabels(ByVal _dataTable As DataTable, ByVal _withZero As Boolean)

        ' Draw the major tick marks with their labels
        Dim x, y As Single
        Dim _sizeF As New SizeF(0, 0)
        Dim _mark As Single
        Dim _text, _format As String

        ' Draw within a Try/Catch block in case mMajorTickY or mRangeY are zero
        Try
            _mark = mMajorTickX * (Int(mMinX / mMajorTickX))

            If (_mark < mMinX) Then
                _mark += mMajorTickX
            End If

            If (mRangeX < 0.005) Then
                _format = "0.####"
            ElseIf (mRangeX < 0.05) Then
                _format = "0.###"
            ElseIf (mRangeX < 0.5) Then
                _format = "0.##"
            ElseIf (mRangeX < 10000.0) Then
                _format = "0.#"
            Else
                _format = "0.0#e+0##"
            End If

            Dim _iter As Integer = 0
            While ((_mark <= mMaxX) And (_iter < 100))
                If (_withZero Or Not (_mark = 0.0)) Then
                    x = mLeft
                    y = mTop + mHeight

                    If (mPosDirX = PositiveDirection.PosRight) Then
                        x += ((_mark - mMinX) / mRangeX) * mWidth
                    Else ' Assume PosLeft
                        x += mWidth - (((_mark - mMinX) / mRangeX) * mWidth)
                    End If

                    _text = Format(_mark, _format)
                    _sizeF = mGraphics.MeasureString(_text, mFont)

                    x -= _sizeF.Width / 2

                    mGraphics.DrawString(_text, mFont, mBlackBrush, x, y + _sizeF.Height - 8)
                End If

                _mark += mMajorTickX
                _iter += 1
            End While
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Grid Methods "

    Protected Overridable Sub DrawGrid()

        ' Define drawing tools
        Dim _color As Drawing.Color = ColorN(0)

        Dim x, y As Single
        Dim x1, x2, y1, y2 As Single
        Dim _sizeF As New SizeF(0, 0)

        If (mDataSet IsNot Nothing) Then
            ' "Grid" is an optional property of a graph's DataSet
            If (mDataSet.ExtendedProperties.Contains("Grid")) Then
                ' There is a "Grid" property; validate it
                Dim _object As Object = mDataSet.ExtendedProperties.Item("Grid")

                If (_object.GetType Is GetType(DataSet)) Then
                    Dim _grid As DataSet = DirectCast(_object, DataSet)

                    ' Allow override of "Color" property
                    If (_grid.ExtendedProperties.Contains("Color")) Then
                        _object = _grid.ExtendedProperties.Item("Color")
                        If (_object.GetType Is GetType(Drawing.Color)) Then
                            _color = DirectCast(_object, Drawing.Color)
                        End If
                    End If

                    Dim _pen As Pen = New Pen(_color, 1)

                    ' 1st DataTable is X grid
                    If (0 < _grid.Tables.Count) Then
                        Dim _vGrid As DataTable = _grid.Tables(0)
                        If (0 < _vGrid.Columns.Count) Then
                            For Each _dataRow As DataRow In _vGrid.Rows
                                x = CSng(_dataRow.Item(0))
                                ' Is vertical grid line within range?
                                If ((mMinX <= x) And (x <= mMaxX)) Then
                                    If (mPosDirX = PositiveDirection.PosRight) Then
                                        x1 = mLeft + (((x - mMinX) / mRangeX) * mWidth)
                                    Else ' Assume PosLeft
                                        x1 = mRight - (((x - mMinX) / mRangeX) * mWidth)
                                    End If

                                    y1 = mBottom
                                    y2 = mBottom - mHeight

                                    mGraphics.DrawLine(_pen, x1, y1, x1, y2)
                                End If
                            Next
                        End If
                    End If

                    ' 2nd DataTable is Y grid
                    If (1 < _grid.Tables.Count) Then
                        Dim _hGrid As DataTable = _grid.Tables(1)
                        If (0 < _hGrid.Columns.Count) Then
                            For Each _dataRow As DataRow In _hGrid.Rows
                                y = CSng(_dataRow.Item(0))
                                ' Is horizontal grid line within range?
                                If ((mMinY <= y) And (y <= mMaxY)) Then
                                    If (mPosDirY = PositiveDirection.PosUp) Then
                                        y1 = mBottom - (((y - mMinY) / mRangeY) * mHeight)
                                    Else ' Assume PosDown
                                        y1 = mTop + (((y - mMinY) / mRangeY) * mHeight)
                                    End If

                                    x1 = mLeft
                                    x2 = mLeft + mWidth

                                    mGraphics.DrawLine(_pen, x1, y1, x2, y1)
                                End If
                            Next
                        End If
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#Region " Curve Methods "

    Protected Overridable Sub DrawCurves()
        mColorNo = 1
        mPens2 = New Pen() {}

        ' Each DataTable represents one axis' set of curves
        If (mDataSet IsNot Nothing) Then
            If (mDataSet.Tables IsNot Nothing) Then
                For Each table As DataTable In mDataSet.Tables
                    Me.DrawCurve(table)
                Next
            End If
        End If
    End Sub

    Protected Overridable Sub DrawCurve(ByVal CurveTable As DataTable)

        Dim x, y As Single
        Dim x1, x2, y1, y2 As Single
        Dim siz As New SizeF(0, 0)
        Dim row As DataRow

        ' Draw each curve in the DataTable
        For YcolNo As Integer = 1 To CurveTable.Columns.Count - 1

            ' Define drawing tools
            ReDim Preserve mPens2(mColorNo)

            mPens2(mColorNo) = New Pen(ColorN(mColorNo), 2)
            Dim Pen2 As Pen = mPens2(mColorNo)
            Dim _brush As SolidBrush = New SolidBrush(ColorN(mColorNo))
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

                    y = (mMinY + mMaxY) / 2.0!

                ElseIf (y < mMinY) Then

                    If (1 < CurveTable.Rows.Count) Then
                        Dim nextRow As DataRow = CurveTable.Rows(1)
                        Dim nextX As Single = CSng(nextRow.Item(0))
                        Dim nextY As Single = CSng(nextRow.Item(YcolNo))

                        If (mMinY < nextY) Then
                            x = x + (nextX - x) * (mMinY - y) / (nextY - y)
                        End If
                    End If

                    y = mMinY

                ElseIf (y > mMaxY) Then

                    y = mMaxY

                End If

                If (mPosDirY = PositiveDirection.PosUp) Then
                    y1 = mBottom - (((y - mMinY) / mRangeY) * mHeight)
                Else ' Assume PosDown
                    y1 = mTop + (((y - mMinY) / mRangeY) * mHeight)
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

            If (1 < CurveTable.Rows.Count) Then ' there is more than one point (lines can be drawn)
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
                    Dim drawOK As Boolean = True

                    If (Single.IsNaN(y) Or Single.IsInfinity(y)) Then

                        drawOK = False

                    ElseIf (y < mMinY) Then

                        If (_row < CurveTable.Rows.Count - 1) Then
                            Dim nextRow As DataRow = CurveTable.Rows(_row + 1)
                            Dim nextX As Single = CSng(nextRow.Item(0))
                            Dim nextY As Single = CSng(nextRow.Item(YcolNo))

                            If (mMinY < nextY) Then
                                x = x + (nextX - x) * (mMinY - y) / (nextY - y)
                            End If
                        End If

                        y = mMinY

                    ElseIf (y > mMaxY) Then

                        Dim lastRow As DataRow = CurveTable.Rows(_row - 1)
                        Dim lastX As Single = CSng(lastRow.Item(0))
                        Dim lastY As Single = CSng(lastRow.Item(YcolNo))

                        If (Single.IsNaN(lastY)) Then
                            drawOK = False
                        Else
                            If (lastY < mMaxY) Then
                                x = x - (x - lastX) * (y - mMaxY) / (y - lastY)
                            End If

                            y = mMaxY
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

                        If (mPosDirY = PositiveDirection.PosUp) Then
                            y2 = mBottom - (((y - mMinY) / mRangeY) * mHeight)
                        Else ' Assume PosDown
                            y2 = mTop + (((y - mMinY) / mRangeY) * mHeight)
                        End If
                        '
                        ' Draw Symbol and/or Line graph
                        '
                        Try ' Catch & release (i.e. ignore) all drawing exception

                            If (CurveTable.ExtendedProperties.Contains("Symbol")) Then

                                Dim _symbol As String = "X"
                                Dim _object As Object = CurveTable.ExtendedProperties.Item("Symbol")
                                If (_object.GetType Is GetType(String)) Then
                                    _symbol = CStr(_object)
                                End If
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

                                    If (CurveTable.ExtendedProperties.Contains("Fill O")) Then
                                        mGraphics.FillEllipse(_brush, x1 - _offset, y1 - _offset, _size, _size)
                                        mGraphics.FillEllipse(_brush, x2 - _offset, y2 - _offset, _size, _size)
                                    Else
                                        mGraphics.DrawEllipse(Pen2, x1 - _offset, y1 - _offset, _size, _size)
                                        mGraphics.DrawEllipse(Pen2, x2 - _offset, y2 - _offset, _size, _size)
                                    End If
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
                                        If Not ((y1 = y2) And (y = mMinY)) Then
                                            mGraphics.DrawLine(Pen2, x1, y1, x2, y2)
                                        End If
                                    End If
                                End If
                            Else
                                '
                                ' Draw line if not on Min axis
                                '
                                If Not ((x1 = x2) And (x = mMinX)) Then
                                    If Not ((y1 = y2) And (y = mMinY)) Then
                                        mGraphics.DrawLine(Pen2, x1, y1, x2, y2)
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            Exit For ' Quit drawing this line
                        End Try
                    End If

                    ' Save end point of this line as start of next line
                    x1 = x2
                    y1 = y2

                Next _row

            Else ' there is only one point; just draw a symbol

                ' Draw single point
                Dim _symbol As String = "X"
                Dim _object As Object = CurveTable.ExtendedProperties.Item("Symbol")
                If (_object IsNot Nothing) Then
                    If (_object.GetType Is GetType(String)) Then
                        _symbol = CStr(_object)
                    End If
                End If
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
                Else ' Assume "X" or "x"
                    Dim _len As Integer = 4
                    If (_symbol = "x") Then
                        _len = 3
                    End If
                    mGraphics.DrawLine(Pen2, x1 - _len, y1 - _len, x1 + _len, y1 + _len)
                    mGraphics.DrawLine(Pen2, x1 - _len, y1 + _len, x1 + _len, y1 - _len)
                End If
            End If
        Next YcolNo

    End Sub

    Protected Overridable Sub DrawCurveLabels()

        If (mDataSet IsNot Nothing) Then
            ' Draw labels each set of curves
            Dim _colorNo As Integer = 0
            Dim _color As Drawing.Color = ColorN(_colorNo)

            For Each _dataTable As DataTable In mDataSet.Tables

                ' Advance to next color for each curve included in the Graph Key
                If (_dataTable.ExtendedProperties.Contains("Key")) Then
                    Dim _object As Object = _dataTable.ExtendedProperties.Item("Key")

                    Dim _key As Boolean = False

                    If (_object.GetType Is GetType(Boolean)) Then
                        _key = CBool(_object)
                    ElseIf (_object.GetType Is GetType(String)) Then
                        _key = CStr(_object) = "True"
                    End If

                    ' Is this DataTable in the Graph Key?
                    If (_key) Then
                        ' Yes, advance to the next color
                        _colorNo += 1
                        _color = ColorN(_colorNo)
                    End If
                End If

                ' Allow override of "Color" property
                If (_dataTable.ExtendedProperties.Contains("Color")) Then
                    Dim _object As Object = _dataTable.ExtendedProperties.Item("Color")
                    If (_object.GetType Is GetType(Drawing.Color)) Then
                        _color = DirectCast(_object, Drawing.Color)
                    End If
                End If

                ' Draw the curve label
                DrawCurveLabel(_dataTable, _color)
            Next
        End If

    End Sub

    Protected Overridable Sub DrawCurveLabel(ByVal _dataTable As DataTable, ByVal _color As Drawing.Color)

        ' Define drawing tools
        Dim _brush As Brush = New SolidBrush(_color)

        Dim x, y As Single
        Dim x1, x2, y1, y2 As Single

        Dim _label As String
        Dim _sizeF As New SizeF(0, 0)

        ' Draw label for each curve in the DataTable
        For _col As Integer = 1 To _dataTable.Columns.Count - 1

            Dim _dataRow As DataRow

            ' Start with first & last points
            Dim _start As Integer = 0
            Dim _end As Integer = _dataTable.Rows.Count - 1

            ' Draw in Try/Catch block in case mRangeX or mRangeY are zero
            Try
                If (_start < _end) Then
                    '
                    ' Get curve's starting point
                    '
                    _dataRow = _dataTable.Rows(_start)

                    x = CSng(_dataRow.Item(0))

                    If (mPosDirX = PositiveDirection.PosRight) Then
                        x1 = mLeft + (((x - mMinX) / mRangeX) * mWidth)
                    Else ' Assume PosLeft
                        x1 = mRight - (((x - mMinX) / mRangeX) * mWidth)
                    End If

                    y = CSng(_dataRow.Item(_col))

                    If (mPosDirY = PositiveDirection.PosUp) Then
                        y1 = mBottom - (((y - mMinY) / mRangeY) * mHeight)
                    Else ' Assume PosDown
                        y1 = mTop + (((y - mMinY) / mRangeY) * mHeight)
                    End If
                    '
                    ' Get curve's ending point
                    '
                    _dataRow = _dataTable.Rows(_end)

                    x = CSng(_dataRow.Item(0))

                    If (mPosDirX = PositiveDirection.PosRight) Then
                        x2 = mLeft + (((x - mMinX) / mRangeX) * mWidth)
                    Else ' Assume PosLeft
                        x2 = mRight - (((x - mMinX) / mRangeX) * mWidth)
                    End If

                    y = CSng(_dataRow.Item(_col))

                    If (mPosDirY = PositiveDirection.PosUp) Then
                        y2 = mBottom - (((y - mMinY) / mRangeY) * mHeight)
                    Else ' Assume PosDown
                        y2 = mTop + (((y - mMinY) / mRangeY) * mHeight)
                    End If
                    '
                    ' Draw label
                    '
                    If (_dataTable.ExtendedProperties.Contains("Label")) Then
                        '
                        ' Draw specified label at left edge
                        '
                        Dim _object As Object = _dataTable.ExtendedProperties.Item("Label")

                        If (_object.GetType Is GetType(String)) Then
                            _label = CStr(_object)
                            _sizeF = mGraphics.MeasureString(_label, mFont)

                            If (y2 < y1) Then
                                ' Sloping up
                                y1 -= 1
                            Else
                                ' Sloping down or level
                                y1 -= _sizeF.Height - 2
                            End If

                            ' Draw the label
                            x1 += 2
                            AddText(_label, mFont, _color, CInt(x1), CInt(y1), False, False)
                        End If
                    ElseIf Not (_dataTable.ExtendedProperties.Contains("No Label")) Then
                        '
                        ' Label 2-point, full-width line
                        '
                        If ((_start + 1 = _end) And (x2 = mRight)) Then

                            ' Only label relatively flat lines
                            If (Math.Abs(y2 - y1) < 10) Then
                                _label = _dataTable.TableName.Trim
                                _sizeF = mGraphics.MeasureString(_label, mFont)

                                If (y1 < y2) Then
                                    ' Sloping down
                                    y1 += (_sizeF.Width * (y2 - y1)) / (x2 - x1)
                                ElseIf (y2 < y1) Then
                                    ' Sloping up
                                    y1 -= (_sizeF.Width * (y1 - y2)) / (x2 - x1)
                                    y1 -= _sizeF.Height
                                End If

                                ' Draw the label
                                x1 += 2
                                y1 -= 1
                                AddText(_label, mFont, _color, CInt(x1), CInt(y1), False, False)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
        Next

    End Sub

    Protected Sub DrawLabel(ByVal x As Single, ByVal y As Single, ByVal _label As String)

        Dim x1, y1 As Single

        ' Draw in Try/Catch block in case mRangeX or mRangeY are zero
        Try
            ' Get label's position
            If (mPosDirX = PositiveDirection.PosRight) Then
                x1 = mLeft + (((x - mMinX) / mRangeX) * mWidth)
            Else ' Assume PosLeft
                x1 = mRight - (((x - mMinX) / mRangeX) * mWidth)
            End If

            If (mPosDirY = PositiveDirection.PosUp) Then
                y1 = mBottom - (((y - mMinY) / mRangeY) * mHeight)
            Else ' Assume PosDown
                y1 = mTop + (((y - mMinY) / mRangeY) * mHeight)
            End If

            ' Draw the label
            mGraphics.DrawString(_label, mFont, mBlackBrush, x1, y1)
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Symbol Methods "

    Protected Overridable Sub DrawSymbol(ByVal Pen2 As Pen, ByVal Symbol As String,
                                         ByVal X As Single, ByVal Y As Single)

        If ((Symbol = "O") Or (Symbol = "o")) Then
            Dim siz As Integer = 10
            Dim offset As Integer = 5
            If (Symbol = "o") Then
                siz = 6
                offset = 3
            End If
            mGraphics.DrawEllipse(Pen2, X - offset, Y - offset, siz, siz)
        Else ' Assume "X" or "x"
            Dim len As Integer = 4
            If (Symbol = "x") Then
                len = 3
            End If
            mGraphics.DrawLine(Pen2, X - len, Y - len, X + len, Y + len)
            mGraphics.DrawLine(Pen2, X - len, Y + len, X + len, Y - len)
        End If

    End Sub

#End Region

#Region " Text Line Methods "

    Protected Overridable Sub DrawTextLines()
        If (mTextLines IsNot Nothing) Then
            If (0 < mTextLines.Length) Then
                For Each line As TextLine In mTextLines
                    DrawTextLine(line)
                Next
            End If
        End If
    End Sub

    Protected Overridable Sub DrawTextLine(ByVal graphTextLine As TextLine)

        ' Define drawing tools
        Dim _color As Drawing.Color = graphTextLine.Color
        Dim _brush As SolidBrush = New SolidBrush(_color)

        Dim x1, y1 As Single
        Dim _sizeF As New SizeF(0, 0)

        ' Get X & Y values
        Dim x As Single = graphTextLine.X
        Dim y As Single = graphTextLine.Y

        ' Scale Y
        If (mPosDirY = PositiveDirection.PosUp) Then
            y1 = mBottom - (((y - mMinY) / mRangeY) * mHeight)
        Else ' Assume PosDown
            y1 = mTop + (((y - mMinY) / mRangeY) * mHeight)
        End If

        ' Scale X
        If (mPosDirX = PositiveDirection.PosRight) Then
            x1 = mLeft + (((x - mMinX) / mRangeX) * mWidth)
        Else ' Assume PosLeft
            x1 = mRight - (((x - mMinX) / mRangeX) * mWidth)
        End If

        ' Draw text line
        mGraphics.DrawString(graphTextLine.LineText, mFont, _brush, x1, y1)

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
    Protected Overridable Sub CopyDataSetAsText(ByVal _dataSet As DataSet, ByVal _copy As Boolean)

        If (_dataSet IsNot Nothing) Then

            For Each _dataTable As DataTable In _dataSet.Tables

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
            Next
        End If

        ' Copy to clipboard if requested
        If (_copy) Then
            Clipboard.SetDataObject(mClipboardText, True)
            ClearClipboardText()
        End If

    End Sub

#End Region

#End Region

#Region " Public Methods "

#Region " Data Methods "

    Public Sub AddGrid(ByVal _grid As DataTable)

        If (mDataSet IsNot Nothing) Then
            If (_grid IsNot Nothing) Then
                ' Remove current grid, if any
                Me.RemoveGrid()
                ' Add the DataTable as a 'Grid' extended property
                mDataSet.ExtendedProperties.Add("Grid", _grid)
                ' Draw the new graph set
                DrawImage()
            End If
        End If

    End Sub

    Public Sub RemoveGrid()
        If (mDataSet IsNot Nothing) Then
            mDataSet.ExtendedProperties.Remove("Grid")
        End If
    End Sub

#End Region

#Region " Graphing Methods "

    '******************************************************************************************
    ' DrawImage()
    '
    Public Overrides Sub DrawImage()

        ' Don't attempt the draw if control is being Disposed
        If (Me.Disposing) Then
            Return
        End If

        ' If data has not been defined, can't draw yet
        If ((mRangeX <= 0.0) Or (mRangeY <= 0.0)) Then
            If (Me.Image IsNot Nothing) Then
                Me.Image.Dispose()
                Me.Image = Nothing
            End If
            Return
        End If

        ' Enclose drawing code in a Try Catch block so drawing is skipped when error occur
        '  Errors occur when size of graph goes to zero
        Try
            ' Start with a clean canvas
            ClearCanvas()

            ' Scale the graph based on the DataSet
            ScaleGraph()

            ' Draw the Graph - grid/curves 1st so axes overlay them
            If (mValidValues) Then
                DrawGrid()          ' grid first
                DrawCurves()        ' curves overlay grid
                DrawAxes()          ' axes after curves
                DrawKey()
                DrawTextLines()
                DrawCurveLabels()
            Else
                DrawNoData()
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

    Public Overridable Sub CopyDataToClipboard()
        ClearClipboardText()
        CopyDataSetAsText(mDataSet, True)
    End Sub

#End Region

#End Region

#Region " UI Event Handlers "
    '
    ' Copy Data menu item handler; added in PictureBoxMenu_Popup() below
    '
    Private Sub CopyData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles CopyData.Click (menu items are dynamically created by PictureBoxMenu_Popup()
        CopyDataToClipboard()
    End Sub
    '
    ' Add 'Copy Data' menu item to menu
    '
    Protected Overrides Sub PictureBoxMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Handles MyBase.PictureBoxMenu_Popup

        ' Have base case start popup
        MyBase.PictureBoxMenu_Popup(sender, e)

        ' Add additional popup menu items
        If (Me.Image IsNot Nothing) Then
            PictureBoxMenu.MenuItems.Add("-")   ' Separator
            PictureBoxMenu.MenuItems.Add(My.Resources.CopyData, New EventHandler(AddressOf CopyData_Click))
        End If

    End Sub

#End Region

End Class
