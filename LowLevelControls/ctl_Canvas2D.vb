
'*************************************************************************************************************
' ctl_Canvas2D - Base functionality for drawing 2D diagrams & graphs.
'
' Graphics UI object hierarchy:
'
'   System.Windows.Forms.PictureBox
'       ex_PictureBox
'           ctl_Canvas2D
'               ctl_Graph2D
'               ctl_Contour2D
'*************************************************************************************************************
Public Class ctl_Canvas2D
    Inherits ex_PictureBox

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeCanvas()

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
                Me.DisposeOfCanvas()
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

#Region " Canvas Objects "
    '
    ' Base Canvas Object - contains attibutes common to all objects
    '
    Protected MustInherit Class CanvasObject
        Public Loc As Point             ' Upper-left corner of rectangle
        Public Rect As Rectangle        ' Enclosing rectangle
        Public Framed As Boolean        ' Is frame drawn?
        Public Selected As Boolean      ' Is object selected?
        Public Dragging As Boolean      ' Is object being dragged?
    End Class
    '
    ' Text Object - adds text attributes to base Canvas Object
    '
    Protected Class TextObject
        Inherits CanvasObject

        Public Text As String           ' Text to display
        Public Font As Font             ' Font for text
        Public Color As Color           ' Font color
        Public Vertical As Boolean      ' Display vertical
    End Class
    '
    ' Hotspot Object - adds a hotspot on the canvas
    '
    Protected Class HotspotObject
        Inherits CanvasObject

        Public Type As String           ' Type of hotspot
        Public ID As Object             ' ID within Type
    End Class

#End Region

#Region " Member Data "
    '
    ' Drawing surface (i.e. the Canvas)
    '
    Private mBitmap1 As Bitmap              ' Bitmap drawing surface
    Private mBitmap2 As Bitmap              ' Bitmap drawing surface
    Protected mGraphics As Graphics         ' GDI+ drawing surface

    Public Function Bitmap1() As Bitmap
        Return mBitmap1
    End Function

    Public Function GdiGraphics() As Graphics
        Return mGraphics
    End Function
    '
    ' Rectangular area within bitmap for graph
    '
    Protected mTop As Single
    Protected mLeft As Single
    Protected mWidth As Single
    Protected mHeight As Single
    Protected mBottom As Single
    Protected mRight As Single
    '
    ' Size of Key text line
    '
    Protected mKeyLineSize As SizeF
    '
    ' Drawing tools
    '
    Protected mBlackPen1 As Pen = BlackPen1()
    Protected mBlackPen2 As Pen = BlackPen2()
    Protected mBlackDashedPen2 As Pen = BlackDashedPen2()

    Protected mWhitePen1 As Pen = WhitePen1()
    Protected mWhitePen2 As Pen = WhitePen2()
    Protected mGrayPen1 As Pen = GrayPen1()
    Protected mGrayPen2 As Pen = GrayPen2()

    Protected mBlackBrush As Brush = BlackSolidBrush()
    Protected mWhiteBrush As Brush = WhiteSolidBrush()
    Protected mGrayBrush As Brush = GraySolidBrush()

    Protected mPens2() As Pen
    '
    ' Fonts for text
    '
    Protected mFontName As String = Me.Font.FontFamily.Name
    Protected mFontSize As Single = 24
    Protected mFont As Font = New Font(mFontName, mFontSize)
    Protected mBold As Font = New Font(mFont, FontStyle.Bold)
    Protected mCourier As Font = New Font("Courier New", mFontSize)
    '
    ' Curve data
    '
    Protected mMajorTickX, mMinorTickX As Single
    Protected mMajorTickY, mMinorTickY As Single
    '
    ' Clipboard support
    '
    Protected mClipboardText As String

#End Region

#Region " Properties "
    '
    ' Colors for drawing
    '
    Protected mColors() As Drawing.Color = {Drawing.Color.Black,
                                            Drawing.Color.Black,
                                            Drawing.Color.Blue,
                                            Drawing.Color.Magenta,
                                            Drawing.Color.DarkOrchid,
                                            Drawing.Color.YellowGreen,
                                            Drawing.Color.DarkGoldenrod,
                                            Drawing.Color.Orange,
                                            Drawing.Color.Red,
                                            Drawing.Color.Crimson}

    Public Property ColorN(ByVal _number As Integer) As Drawing.Color
        Get
            If ((0 <= _number) And (_number < mColors.Length)) Then ' index within table's range
                ColorN = mColors(_number)
            ElseIf (mColors.Length <= _number) Then ' index beyond table
                Dim alpha As Byte = CByte(254 - (_number - mColors.Length)) ' calc unique alpha
                ColorN = Color.FromArgb(alpha, 0, 0, 0)                     ' Black w/ unique alpha
            Else ' negative; return default
                ColorN = mColors(0)
            End If
        End Get
        Set(ByVal Value As Drawing.Color)
            If ((0 <= _number) And (_number < mColors.Length)) Then
                mColors(_number) = Value
            End If
        End Set
    End Property
    '
    ' Lists of Canvas Objects, etc.
    '
    Private mCanvasObjects As ArrayList
    Public Function CanvasObjects() As ArrayList
        Return mCanvasObjects
    End Function

    Private mHotspots As ArrayList
    Public Function HotSpots() As ArrayList
        Return mHotspots
    End Function

#End Region

#Region " Public Methods "

#Region " Initialization "

    Public Sub InitializeCanvas()
    End Sub
    '
    ' Make sure all graphics objects are properly disposed of so garbage collection works.
    '
    Protected Sub DisposeOfCanvas()

        ' Dispose of contained Components
        If Not (mBitmap1 Is Nothing) Then
            mBitmap1.Dispose()
            mBitmap1 = Nothing
        End If

        If Not (mBitmap2 Is Nothing) Then
            mBitmap2.Dispose()
            mBitmap2 = Nothing
        End If

        If Not (mGraphics Is Nothing) Then
            mGraphics.Dispose()
            mGraphics = Nothing
        End If

        If Not (mBlackPen2 Is Nothing) Then
            mBlackPen2.Dispose()
            mBlackPen2 = Nothing
        End If

        If Not (mGrayBrush Is Nothing) Then
            mGrayBrush.Dispose()
            mGrayBrush = Nothing
        End If

        If Not (mBlackBrush Is Nothing) Then
            mBlackBrush.Dispose()
            mBlackBrush = Nothing
        End If

        If Not (mWhiteBrush Is Nothing) Then
            mWhiteBrush.Dispose()
            mWhiteBrush = Nothing
        End If

    End Sub

#End Region

#Region " Drawing Methods "
    '
    ' Subclass should override DrawImage() to define the Image contents
    '
    Public Overridable Sub DrawImage()
    End Sub
    '
    ' Clear canvas for a new graphic
    '
    Public Sub ClearCanvas()
        ' Clear old bitmaps, if any
        If Not (mBitmap1 Is Nothing) Then
            mBitmap1.Dispose()
            mBitmap1 = Nothing
        End If
        If Not (mBitmap2 Is Nothing) Then
            mBitmap2.Dispose()
            mBitmap2 = Nothing
        End If

        ' Clear old graphics, if any
        If Not (mGraphics Is Nothing) Then
            mGraphics.Dispose()
            mGraphics = Nothing
        End If

        ' Create a bitmap for the graphics
        mBitmap1 = New Bitmap(Math.Max(Me.Width, 10), Math.Max(Me.Height, 10))
        mGraphics = Graphics.FromImage(mBitmap1)

        ' Fill bitmap with white (makes printing much faster than transparent)
        If (mWhiteBrush IsNot Nothing) Then
            mGraphics.FillRectangle(mWhiteBrush, 0, 0, mBitmap1.Width, mBitmap1.Height)
        End If

        ' Clear all special effects
        If (mCanvasObjects IsNot Nothing) Then
            mCanvasObjects.Clear()
            mCanvasObjects = Nothing
        End If

        ' Create special effects, if necessary
        If (mCanvasObjects Is Nothing) Then
            mCanvasObjects = New ArrayList
        End If
    End Sub
    '
    ' Dispose of Canvas' Bitmap
    '
    Public Sub DisposeCanvas()
    End Sub
    '
    ' Dispose of Canvas' Graphics
    '
    Public Sub DisposeGraphics()
    End Sub
    '
    ' Finish graph & display it
    '
    Public Sub ShowCanvas()

        ' Clone copy of current bitmap prior to Canvas Objects being added
        If (mBitmap2 IsNot Nothing) Then
            mBitmap2.Dispose()
            mBitmap2 = Nothing
        End If
        mBitmap2 = DirectCast(mBitmap1.Clone, Bitmap)
        Dim gdiGraphics As Graphics = Graphics.FromImage(mBitmap2)

        ' Add canvas objects
        For Each canvasObj As CanvasObject In mCanvasObjects
            If (canvasObj.GetType Is GetType(TextObject)) Then
                Dim textObj As TextObject = CType(canvasObj, TextObject)
                Dim brush As SolidBrush = New SolidBrush(textObj.Color)

                If (textObj.Vertical) Then
                    Dim vertical As New StringFormat(StringFormatFlags.DirectionVertical)
                    gdiGraphics.DrawString(textObj.Text, textObj.Font, brush, textObj.Rect.X, textObj.Rect.Y, vertical)
                Else
                    gdiGraphics.DrawString(textObj.Text, textObj.Font, brush, textObj.Rect.X, textObj.Rect.Y)
                End If
            End If
            canvasObj.Framed = False
        Next

        ' Dispose of old drawing so garbage collection will reclaim its memory
        If (Me.Image IsNot Nothing) Then
            Me.Image.Dispose()
            Me.Image = Nothing
        End If

        ' Load bitmap after drawing to avoid flicker
        Me.Image = mBitmap2
        Me.Refresh()
    End Sub
    '
    ' Add Text Object to image
    '
    Public Sub AddText(ByVal text As String, ByVal font As Font, ByVal color As Color,
                       ByVal x As Integer, ByVal y As Integer,
                       ByVal overlay As Boolean, ByVal vertical As Boolean)

        Dim size As SizeF = mGraphics.MeasureString(text, font)

        ' Create canvas/text object from input parameters
        Dim newText As TextObject = New TextObject
        newText.Loc.X = x
        newText.Loc.Y = y
        newText.Rect.X = x
        newText.Rect.Y = y

        newText.Vertical = vertical
        If (newText.Vertical) Then
            newText.Rect.Width = CInt(size.Height)
            newText.Rect.Height = CInt(size.Width)
        Else
            newText.Rect.Width = CInt(size.Width)
            newText.Rect.Height = CInt(size.Height)
        End If

        newText.Framed = False
        newText.Selected = False
        newText.Dragging = False

        newText.Text = text
        newText.Font = font
        newText.Color = color

        ' If overlay, replace previous text with overlay text at same location
        If Not (overlay) Then ' If not overlay, remove previous text
            For Each canvasObj As CanvasObject In mCanvasObjects
                If (canvasObj.GetType Is GetType(TextObject)) Then
                    Dim prvText As TextObject = CType(canvasObj, TextObject)
                    If ((prvText.Rect.X = newText.Rect.X) And (prvText.Rect.Y = newText.Rect.Y)) Then
                        mCanvasObjects.Remove(canvasObj)
                        Exit For
                    End If
                End If
            Next
        End If

        mCanvasObjects.Add(newText)

    End Sub
    '
    ' Draw border line around canvas
    '
    Public Sub DrawBorderLine(ByVal pen As Pen)
        ' Draw a rectangle around the entire bitmap
        mGraphics.DrawRectangle(pen, 0, 0, mBitmap1.Width - 1, mBitmap1.Height - 1)
    End Sub
    '
    ' Draw title & subtitle at top, center
    '
    Public Sub DrawTitle(ByVal Title As String, ByVal TitleFont As Font, ByVal TitleColor As Color)
        ' Display title at Center/Top
        Dim size As RectangleF = MeasureString(mGraphics, Title, TitleFont)
        Dim x As Integer = CInt((mBitmap1.Width - size.Right) / 2)      ' Center
        Dim y As Integer = 2                                            ' Top (1st line)

        AddText(Title, TitleFont, TitleColor, x, y, False, False)
    End Sub

    Public Sub DrawSubTitle(ByVal SubTitle As String, ByVal TitleFont As Font, ByVal TitleColor As Color)
        ' Display subtitle under title at Center/Top
        Dim size As RectangleF = MeasureString(mGraphics, SubTitle, TitleFont)
        Dim x As Integer = CInt((mBitmap1.Width - size.Right) / 2)      ' Center
        Dim y As Integer = CInt(size.Height + 2)                        ' Top (2nd line)

        AddText(SubTitle, TitleFont, TitleColor, x, y, False, False)
    End Sub
    '
    ' Draw selection frame around canvas object
    '
    Protected Sub DrawObjectFrame(ByVal canvas As ctl_Canvas2D, ByVal canvasObject As CanvasObject)
        If Not (canvasObject.Framed) Then
            canvasObject.Framed = True
            ControlPaint.DrawReversibleFrame(canvas.RectangleToScreen(canvasObject.Rect), Color.Transparent, FrameStyle.Dashed)
        End If
    End Sub

    Protected Sub ClearObjectFrame(ByVal canvas As ctl_Canvas2D, ByVal canvasObject As CanvasObject)
        If (canvasObject.Framed) Then
            canvasObject.Framed = False
            ControlPaint.DrawReversibleFrame(canvas.RectangleToScreen(canvasObject.Rect), Color.Transparent, FrameStyle.Dashed)
        End If
    End Sub

#End Region

#Region " Clipboard Methods "
    '
    ' ClearClipboardText()      - clears pending clipboard data
    ' AppendClipboardText()     - appends text to pending clipboard data
    '
    Protected Sub ClearClipboardText()
        mClipboardText = String.Empty
    End Sub

    Protected Sub AppendClipboardText(ByVal Text As String)
        mClipboardText &= Text & Chr(10)
    End Sub

#End Region

#End Region

#Region " UI Event Handlers "

    Protected Overrides Sub PictureBox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)

        Dim canvas As ctl_Canvas2D = DirectCast(sender, ctl_Canvas2D)

        Try
            If (canvas.Visible) Then
                If ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then

                    For Each canvasObj As CanvasObject In mCanvasObjects

                        If (canvasObj.GetType Is GetType(HotspotObject)) Then
                            '
                            ' Toggle on/off state of Hotspot
                            '
                            If (canvasObj.Rect.Contains(e.X, e.Y)) Then
                                ' Save the on/off state of the Hotspot
                                Dim hotspot As HotspotObject = DirectCast(canvasObj, HotspotObject)
                                HotspotClicked(hotspot)
                            End If

                        Else ' not Hotspot
                            '
                            ' Shift-mouse down starts drag
                            '
                            If ((canvasObj.Rect.Contains(e.X, e.Y)) And (canvasObj.Selected)) Then
                                ' Set dragging flag to start drag
                                canvasObj.Dragging = True
                                ' Save current mouse position
                                canvasObj.Loc.X = e.X
                                canvasObj.Loc.Y = e.Y
                            Else
                                ' Clear dragging flag
                                canvasObj.Dragging = False
                            End If
                        End If
                    Next

                    ' Mouse event handled here; don't pass it on
                    Return
                End If

            End If
        Catch ex As Exception
        End Try

        ' If not handled here, let the base class
        MyBase.PictureBox_MouseDown(sender, e)

    End Sub

    Protected Overridable Sub HotspotClicked(ByVal Hotspot As HotspotObject)
        If (mHotspots.Contains(Hotspot.ID)) Then ' in the list is ON
            mHotspots.Remove(Hotspot.ID) ' turn it OFF
        Else ' not in the list is OFF
            mHotspots.Add(Hotspot.ID) ' turn it ON
        End If
    End Sub

    Protected Overrides Sub PictureBox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)

        Dim canvas As ctl_Canvas2D = DirectCast(sender, ctl_Canvas2D)

        Try
            If (canvas.Visible) Then
                ' What to do depends on which button was released
                Select Case (e.Button)
                    Case MouseButtons.Left
                        ' Stop a Drag/Drop
                        For Each canvasObj As CanvasObject In mCanvasObjects
                            canvasObj.Selected = False
                            canvasObj.Dragging = False
                        Next
                        ' Redraw canvas to clear any added special graphics (i.e. clear frame)
                        ShowCanvas()
                    Case MouseButtons.Right
                        ' Nothing to do, for now
                End Select
            End If
        Catch ex As Exception
        End Try

        ' If not handled here, let the base class
        MyBase.PictureBox_MouseUp(sender, e)

    End Sub

    Protected Overrides Sub PictureBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)

        Dim canvas As ctl_Canvas2D = DirectCast(sender, ctl_Canvas2D)

        Try
            If (canvas.Visible) Then
                If ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then
                    '
                    ' Shift-mouse moves drags and/or highlights canvas objects
                    '
                    canvas.Cursor = Cursors.Hand
                    canvas.ToolTip.Active = False
                    '
                    ' Check Canvas objects
                    '
                    For Each canvasObj As CanvasObject In mCanvasObjects

                        If (canvasObj.Dragging) Then
                            ' Object is being dragged; adjust its position by mouse change
                            canvasObj.Rect.X += e.X - canvasObj.Loc.X
                            canvasObj.Rect.Y += e.Y - canvasObj.Loc.Y
                            canvasObj.Loc.X = e.X
                            canvasObj.Loc.Y = e.Y

                            ' Redraw canvas to reflect new position; add selection frame
                            ShowCanvas()
                            DrawObjectFrame(canvas, canvasObj)

                        ElseIf (canvasObj.Rect.Contains(e.X, e.Y)) Then
                            ' Mouse is inside Object's rectangle; draw selection frame, if needed
                            If Not (canvasObj.Selected) Then
                                canvasObj.Selected = True
                                DrawObjectFrame(canvas, canvasObj)
                            End If

                        Else
                            ' Mouse is outside Object's rectangle; clear select frame, if needed
                            If (canvasObj.Selected) Then
                                canvasObj.Selected = False
                                ClearObjectFrame(canvas, canvasObj)
                            End If
                        End If
                    Next

                    ' Mouse event handled here; don't pass it on
                    Return
                End If

            End If
        Catch ex As Exception
        End Try

        ' If not handled here, let the base class
        MyBase.PictureBox_MouseMove(sender, e)

    End Sub

#End Region

End Class
