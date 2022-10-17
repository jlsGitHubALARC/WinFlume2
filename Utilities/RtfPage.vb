
'**********************************************************************************************
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing

Public Class RtfPage
    Inherits BasePage

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeRtf()

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
    Public WithEvents RtfCtrl As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RtfCtrl = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'RtfCtrl
        '
        Me.RtfCtrl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RtfCtrl.BackColor = System.Drawing.SystemColors.Window
        Me.RtfCtrl.Font = New System.Drawing.Font("Courier New", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RtfCtrl.Location = New System.Drawing.Point(50, 50)
        Me.RtfCtrl.Name = "RtfCtrl"
        Me.RtfCtrl.ReadOnly = True
        Me.RtfCtrl.Size = New System.Drawing.Size(750, 1000)
        Me.RtfCtrl.TabIndex = 0
        Me.RtfCtrl.Text = ""
        '
        'RtfPage
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.RtfCtrl)
        Me.Name = "RtfPage"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    ' Convert the unit that is used by the .NET framework (1/100 inch)
    ' and the unit that is used by Win32 API calls (twips 1/1440 inch)
    Private Const AnInch As Double = 14.4

    Private Structure RECT
        Public Left As Integer          ' Margins
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Private Structure CHARRANGE
        Public cpMin As Integer         ' First character of range (0 for start of doc)
        Public cpMax As Integer         ' Last character of range (-1 for end of doc)
    End Structure

    Private Structure FORMATRANGE
        Public hdc As IntPtr            ' Actual DC to draw on
        Public hdcTarget As IntPtr      ' Target DC for determining text formatting
        Public rc As RECT               ' Region of the DC to draw to (in twips)
        Public rcPage As RECT           ' Region of the whole DC (page size) (in twips)
        Public chrg As CHARRANGE        ' Range of text to draw (see above declaration)
    End Structure

    Private Const WM_USER As Integer = &H400
    Private Const EM_FORMATRANGE As Integer = WM_USER + 57
    '
    ' Declaration of the Win32 SendMessage function (Note - this is unmanaged code)
    '
    Private Declare Function SendMessage Lib "USER32" Alias "SendMessageA" _
        (ByVal hWnd As IntPtr, ByVal msg As Integer, _
         ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

#End Region

#Region " Properties "
    '
    ' RTF text area size
    '
    Private mRtfWidth As Integer
    Private mRtfHeight As Integer

    Public ReadOnly Property RtfWidth() As Integer
        Get
            Return mRtfWidth
        End Get
    End Property

    Public ReadOnly Property RtfHeight() As Integer
        Get
            Return mRtfHeight
        End Get
    End Property
    '
    ' The RTF text area
    '
    Public ReadOnly Property Rtf() As RichTextBox
        Get
            Return RtfCtrl
        End Get
    End Property

#End Region

#Region " Initialization "

    Private Sub InitializeRtf()
        AdjustPage()
    End Sub

#End Region

#Region " Methods "

    Protected Overrides Sub AdjustPage()
        MyBase.AdjustPage()

        If Not (RtfCtrl Is Nothing) Then

            ' Adjust the size of the RTF text area
            mRtfWidth = PageWidth - LeftMargin - RightMargin
            mRtfHeight = PageHeight - TopMargin - BottomMargin

            Dim _rtfSize As Drawing.Size = New Drawing.Size(mRtfWidth, mRtfHeight)
            Dim _rtfLocation As Drawing.Point = New Drawing.Point(LeftMargin, TopMargin)

            RtfCtrl.Size = _rtfSize
            RtfCtrl.Location = _rtfLocation

        End If

    End Sub
    '
    ' Render the contents of the RichTextBox for printing
    '
    ' Note - this code is heavily based on (i.e. copied from) this Microsoft document:
    '
    ' HOW TO: Print the Content of a RichTextBox by Using Microsoft Visual Basic .NET
    '
    Public Overrides Sub Print(ByVal e As PrintPageEventArgs)

        ' Set starting and ending character
        Dim cRange As CHARRANGE
        cRange.cpMin = 0    ' Start of doc
        cRange.cpMax = -1   ' End of doc

        ' Calculate the area to render and print
        Dim rectToPrint As RECT
        rectToPrint.Top = CInt(e.MarginBounds.Top * AnInch)
        rectToPrint.Bottom = CInt(e.MarginBounds.Bottom * AnInch)
        rectToPrint.Left = CInt(e.MarginBounds.Left * AnInch)
        rectToPrint.Right = CInt(e.MarginBounds.Right * AnInch)

        ' Calculate the size of the page
        Dim rectPage As RECT
        rectPage.Top = CInt(e.PageBounds.Top * AnInch)
        rectPage.Bottom = CInt(e.PageBounds.Bottom * AnInch)
        rectPage.Left = CInt(e.PageBounds.Left * AnInch)
        rectPage.Right = CInt(e.PageBounds.Right * AnInch)

        Dim hdc As IntPtr = e.Graphics.GetHdc()

        ' Build formatting structure
        Dim fmtRange As FORMATRANGE
        fmtRange.chrg = cRange                 ' Indicate character from to character to
        fmtRange.hdc = hdc                     ' Use the same DC for measuring and rendering
        fmtRange.hdcTarget = hdc               ' Point at printer hDC
        fmtRange.rc = rectToPrint              ' Indicate the area on page to print
        fmtRange.rcPage = rectPage             ' Indicate whole size of page

        ' Move the pointer to the FORMATRANGE structure in memory
        Dim lparam As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
        Dim wparam As IntPtr = New IntPtr(1)

        Marshal.StructureToPtr(fmtRange, lparam, False)

        ' Send the rendered data for printing
        Dim res As IntPtr = SendMessage(RtfCtrl.Handle, EM_FORMATRANGE, wparam, lparam)

        ' Free the block of memory allocated
        Marshal.FreeCoTaskMem(lparam)

        ' Release the device context handle obtained by a previous call
        e.Graphics.ReleaseHdc(hdc)

        ' Print the baseclass data after this subclass' data
        MyBase.Print(e)

    End Sub

#End Region

End Class
