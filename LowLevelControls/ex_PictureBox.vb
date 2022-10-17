
'**********************************************************************************************
' ex_PictureBox - Extended PictureBox - adds Copy & Drag functionality
'
' Graphics UI object hierarchy:
'
'   System.Windows.Forms.PictureBox
'       ex_PictureBox
'           ctl_Canvas2D
'               ctl_Graph2D
'               ctl_Contour2D
'
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class ex_PictureBox
    Inherits System.Windows.Forms.PictureBox

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeExPictureBox()

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents ToolTip As System.Windows.Forms.ToolTip
    Public WithEvents PictureBoxMenu As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.PictureBoxMenu = New System.Windows.Forms.ContextMenu
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        '
        'PictureBoxMenu
        '
        '
        'ToolTip
        '
        Me.ToolTip.AutoPopDelay = 500
        Me.ToolTip.InitialDelay = 500
        Me.ToolTip.ReshowDelay = 100
        '
        'ex_PictureBox
        '
        Me.AccessibleDescription = "A copyable bitmap image"
        Me.AccessibleName = "Bitmap Diagram"

    End Sub

#End Region

#Region " Member Data "

    Private mDragging As Boolean = False

    Protected mOldCursor As Cursor = Nothing
    Protected mMousePoint As Point = Nothing
#End Region

#Region " Public Methods "
    '
    ' Initialization 
    '
    Private Sub InitializeExPictureBox()
        Me.Text = Me.AccessibleName
    End Sub
    '
    ' Default Copy operation copies Image as is to the Clipboard
    '
    Public Overridable Sub CopyImageToClipboard()
        If Not (Me.Image Is Nothing) Then
            Clipboard.SetDataObject(Me.Image, True)
        End If
    End Sub
    '
    ' Save Image as data file (*.bmp, *.gif, *.jpeg, ...)
    '
    Public Overridable Sub SaveImageAsFile(ByVal format As Imaging.ImageFormat)
        If Not (Me.Image Is Nothing) Then

            Dim _ext As String
            Dim _filter As String

            If (format Is Imaging.ImageFormat.Gif) Then
                _ext = "gif"
                _filter = "GIF Files"
            ElseIf (format Is Imaging.ImageFormat.Jpeg) Then
                _ext = "jpeg"
                _filter = "JPEG Files"
            ElseIf (format Is Imaging.ImageFormat.Tiff) Then
                _ext = "tiff"
                _filter = "Tiff Files"
            Else ' assume BMP
                _ext = "bmp"
                _filter = "Bitmap Files"
            End If

            ' Create a SaveFileDialog to request a path and file name to save to
            Dim _fileName As String = "image." + _ext
            Dim _saveFile As New SaveFileDialog

            _saveFile.FileName = _fileName
            _saveFile.DefaultExt = "*." + _ext
            _saveFile.Filter = _filter + "|*." + _ext

            ' Determine if the user selected a file name from the SaveFileDialog
            If (_saveFile.ShowDialog() = System.Windows.Forms.DialogResult.OK) _
                And (_saveFile.FileName.Length) > 0 Then
                Me.Image.Save(_saveFile.FileName, format)
            End If
        End If
    End Sub

#End Region

#Region " UI Event Handlers "
    '
    ' Mouse event handlers for Copy/Paste, Drag/Drop & Context Menu
    '
    Protected Overridable Sub PictureBox_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.MouseEnter
        ' Save current cursor style so it can be restored when leaving PictureBox
        Dim _pictureBox As ex_PictureBox = DirectCast(sender, ex_PictureBox)
        mOldCursor = _pictureBox.Cursor
    End Sub

    Protected Overridable Sub PictureBox_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.MouseLeave
        ' Restore cursor saved when entering PictureBox
        Dim _pictureBox As ex_PictureBox = DirectCast(sender, ex_PictureBox)
        _pictureBox.Cursor = mOldCursor
    End Sub

    Protected Overridable Sub PictureBox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
    Handles MyBase.MouseDown
        ' Get MousePoint where it was pressed
        mMousePoint = New Point(e.X, e.Y)
        ' What to do depends on which button was pressed
        Select Case (e.Button)
            Case MouseButtons.Left
                ' Start a Drag/Drop
                If Not (Me.Image Is Nothing) Then
                    mDragging = True
                End If
        End Select
    End Sub

    Protected Overridable Sub PictureBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) _
    Handles MyBase.MouseMove

        Dim _pictureBox As ex_PictureBox = CType(sender, ex_PictureBox)

        ' If performing a Drag operation; show visual feedback
        If (mDragging) Then
            ' Put the image on the Clipboard
            Clipboard.SetDataObject(Me.Image, True)
            ' Start drag/drop of Image from Clipboard
            DoDragDrop(Clipboard.GetDataObject, DragDropEffects.Copy)
        End If
        mDragging = False

        _pictureBox.Cursor = Cursors.Arrow
        _pictureBox.ToolTip.Active = False
    End Sub

    Protected Overridable Sub PictureBox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) _
    Handles MyBase.MouseUp
        ' Get MousePoint where it was released
        mMousePoint = New Point(e.X, e.Y)
        ' What to do depends on which button was released
        Select Case (e.Button)
            Case MouseButtons.Left
                ' Stop a Drag/Drop
                mDragging = False
            Case MouseButtons.Right
                ' Display the Picture Box's context menu
                PictureBoxMenu.Show(Me, mMousePoint)
        End Select
    End Sub

    Protected Overridable Sub PictureBox_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Click
    End Sub

    Protected Overridable Sub PictureBox_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.DoubleClick
    End Sub
    '
    ' Build initial Context Menu with Menu Item for copying image to clipboard
    '
    Protected Overridable Sub PictureBoxMenu_Popup(ByVal sender As Object, ByVal e As EventArgs) _
    Handles PictureBoxMenu.Popup
        ' Clear Context Menu
        PictureBoxMenu.MenuItems.Clear()
        ' Add Menu Item if Image is available
        If Not (Me.Image Is Nothing) Then
            ' Text for Menu Item
            Dim _itemText As String = My.Resources.ExportImageAs

            ' Add menu items to save image as a data file
            Dim _saveItem As MenuItem = New MenuItem(_itemText)

            _saveItem.MenuItems.Add("Bitmap (*.bmp)...", New EventHandler(AddressOf SaveImageAsBmp))
            _saveItem.MenuItems.Add("GIF (*.gif)...", New EventHandler(AddressOf SaveImageAsGif))
            _saveItem.MenuItems.Add("JPEG (*.jpeg)...", New EventHandler(AddressOf SaveImageAsJpeg))
            _saveItem.MenuItems.Add("Tiff (*.tiff)...", New EventHandler(AddressOf SaveImageAsTiff))

            PictureBoxMenu.MenuItems.Add(_saveItem)

            ' Add menu item to copy image to clipboard
            If (Me.Image.GetType Is GetType(Bitmap)) Then
                _itemText = My.Resources.CopyBitmap
            Else
                _itemText = My.Resources.CopyImage
            End If

            ' Add Menu Item to Context Menu
            PictureBoxMenu.MenuItems.Add(_itemText, New EventHandler(AddressOf Copy_Click))
        End If
    End Sub

    Protected Sub Copy_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Handles Copy.Click (menu items are dynamically created by PictureBoxMenu_Popup()
        CopyImageToClipboard()
    End Sub

    Protected Sub SaveImageAsBmp(ByVal sender As Object, ByVal e As EventArgs)
        'Handles SaveImageasBmp.Click (menu items are dynamically created by PictureBoxMenu_Popup()
        SaveImageAsFile(Imaging.ImageFormat.Bmp)
    End Sub

    Protected Sub SaveImageAsGif(ByVal sender As Object, ByVal e As EventArgs)
        'Handles SaveImageasGif.Click (menu items are dynamically created by PictureBoxMenu_Popup()
        SaveImageAsFile(Imaging.ImageFormat.Gif)
    End Sub

    Protected Sub SaveImageAsJpeg(ByVal sender As Object, ByVal e As EventArgs)
        'Handles SaveImageasJpeg.Click (menu items are dynamically created by PictureBoxMenu_Popup()
        SaveImageAsFile(Imaging.ImageFormat.Jpeg)
    End Sub

    Protected Sub SaveImageAsTiff(ByVal sender As Object, ByVal e As EventArgs)
        'Handles SaveImageasTiff.Click (menu items are dynamically created by PictureBoxMenu_Popup()
        SaveImageAsFile(Imaging.ImageFormat.Tiff)
    End Sub

#End Region

End Class