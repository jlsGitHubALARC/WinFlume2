
'**********************************************************************************************
' Class BasePage - Base class for all printing pages in this class library.
'
' Desc: The BasePage provides a single "page" to render text & graphics.  No text is supported
'       by BasePage but Images contained within PictureBoxes are.
'
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing

Public Class BasePage
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializePage()

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'BasePage
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "BasePage"
        Me.Size = New System.Drawing.Size(850, 1100)

    End Sub

#End Region

#Region " Results Page Constants "
    '
    ' Define the size & margins of a printable page (in pixels)
    '
    ' Note - 100 pixels = 1 inch
    '
    Public Const PortraitPageWidth As Integer = 850
    Public Const PortraitPageLength As Integer = 1100

    Public Const PortraitTopMargin As Integer = 50
    Public Const PortraitLeftMargin As Integer = 75
    Public Const PortraitRightMargin As Integer = 50
    Public Const PortraitBottomMargin As Integer = 50

    Public Const TopOffset As Integer = 25
    Public Const LeftOffset As Integer = 25

    Public Const PortraitHeightLines As Integer = 55
    Public Const PortraitWidthChars As Integer = 76

#End Region

#Region " Results Page Properties "
    '
    ' Page Identification
    '
    Private mPageTitle As String = String.Empty
    Private mPageNumber As Integer = 0

    Public Property PageTitle() As String
        Get
            Return mPageTitle
        End Get
        Set(ByVal Value As String)
            mPageTitle = Value
        End Set
    End Property

    Public Property PageNumber() As Integer
        Get
            Return mPageNumber
        End Get
        Set(ByVal Value As Integer)
            mPageNumber = Value
        End Set
    End Property
    '
    ' Page Size
    '
    Private mPageWidth As Integer = PortraitPageWidth
    Private mPageHeight As Integer = PortraitPageLength

    Public Property PageWidth() As Integer
        Get
            Return mPageWidth
        End Get
        Set(ByVal Value As Integer)
            If Not (mPageWidth = Value) Then
                mPageWidth = Value
                AdjustPage()
            End If
        End Set
    End Property

    Public Property PageHeight() As Integer
        Get
            Return mPageHeight
        End Get
        Set(ByVal Value As Integer)
            If Not (mPageHeight = Value) Then
                mPageHeight = Value
                AdjustPage()
            End If
        End Set
    End Property
    '
    ' Page Margins
    '
    Private mTopMargin As Integer = PortraitTopMargin
    Private mLeftMargin As Integer = PortraitLeftMargin
    Private mRightMargin As Integer = PortraitRightMargin
    Private mBottomMargin As Integer = PortraitBottomMargin

    Public Property TopMargin() As Integer
        Get
            Return mTopMargin
        End Get
        Set(ByVal Value As Integer)
            If Not (mTopMargin = Value) Then
                mTopMargin = Value
                AdjustPage()
            End If
        End Set
    End Property

    Public Property LeftMargin() As Integer
        Get
            Return mLeftMargin
        End Get
        Set(ByVal Value As Integer)
            If Not (mLeftMargin = Value) Then
                mLeftMargin = Value
                AdjustPage()
            End If
        End Set
    End Property

    Public Property RightMargin() As Integer
        Get
            Return mRightMargin
        End Get
        Set(ByVal Value As Integer)
            If Not (mRightMargin = Value) Then
                mRightMargin = Value
                AdjustPage()
            End If
        End Set
    End Property

    Public Property BottomMargin() As Integer
        Get
            Return mBottomMargin
        End Get
        Set(ByVal Value As Integer)
            If Not (mBottomMargin = Value) Then
                mBottomMargin = Value
                AdjustPage()
            End If
        End Set
    End Property

#End Region

#Region " Contained Images "

    Private mImages As ArrayList = New ArrayList

    Public Sub AddImage(ByVal _pictureBox As Windows.Forms.PictureBox)

        ' Add the PictureBox (and its contained Image) to the list
        mImages.Add(_pictureBox)

        ' Also add it as a Control so it is displayed
        Me.SuspendLayout()
        Me.Controls.Add(_pictureBox)
        _pictureBox.BringToFront()
        Me.ResumeLayout()

    End Sub

#End Region

#Region " Initialization "

    Private Sub InitializePage()
        AdjustPage()
    End Sub

#End Region

#Region " Methods "

    Protected Overridable Sub AdjustPage()

        ' Adjust the size of the page
        Me.Size = New Drawing.Size(mPageWidth, mPageHeight)

    End Sub
    '
    ' Print all the contained images
    '
    Public Overridable Sub Print(ByVal e As PrintPageEventArgs)

        For Each _pictureBox As PictureBox In mImages
            ' Get the image's location
            Dim _location As Point = _pictureBox.Location
            Dim _size As Size = _pictureBox.Size
            ' Print (i.e. draw in e) the image at the correct location
            e.Graphics.DrawImage(_pictureBox.Image, _location.X, _location.Y, _size.Width, _size.Height)
        Next

    End Sub

#End Region

End Class
