
'**********************************************************************************************
' Clipboard Viewer - displays the various formats of data present on the clipboard
'
Public Class ClipboardViewer
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeClipboardViewer()

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents FormatsTabControl As System.Windows.Forms.TabControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.FormatsTabControl = New System.Windows.Forms.TabControl
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Location = New System.Drawing.Point(0, 254)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(392, 22)
        Me.StatusBar.TabIndex = 0
        '
        'FormatsTabControl
        '
        Me.FormatsTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormatsTabControl.Location = New System.Drawing.Point(0, 0)
        Me.FormatsTabControl.Name = "FormatsTabControl"
        Me.FormatsTabControl.SelectedIndex = 0
        Me.FormatsTabControl.Size = New System.Drawing.Size(392, 254)
        Me.FormatsTabControl.TabIndex = 1
        '
        'ClipboardViewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(392, 276)
        Me.Controls.Add(Me.FormatsTabControl)
        Me.Controls.Add(Me.StatusBar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "ClipboardViewer"
        Me.Text = "Clipboard Viewer"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Initialization "

    Private Sub InitializeClipboardViewer()

        ' Retrieve the data from the clipboard.
        Dim _iDataObject As IDataObject = Clipboard.GetDataObject()
        Dim _tabPage As TabPage

        If Not (_iDataObject Is Nothing) Then

            Dim _formats As String() = _iDataObject.GetFormats(False)
            Dim _others As ArrayList = New ArrayList

            For Each _format As String In _formats

                ' Enclose in Try/Catch block to handle (i.e. ignore) unknown errors
                Try
                    Select Case (_format)
                        Case DataFormats.Bitmap, DataFormats.Dib

                            Dim _bitmap As Bitmap = CType(_iDataObject.GetData(_format), Bitmap)

                            Dim _pictureBox As PictureBox = New PictureBox

                            _pictureBox.Image = _bitmap
                            _pictureBox.Dock = DockStyle.Fill

                            _tabPage = New TabPage(_format)
                            _tabPage.Controls.Add(_pictureBox)

                            Me.FormatsTabControl.TabPages.Add(_tabPage)

                        Case DataFormats.CommaSeparatedValue

                            Dim _csv As System.IO.StreamReader = New System.IO.StreamReader(CType(_iDataObject.GetData(_format), System.IO.MemoryStream))

                            Dim _richTextBox As RichTextBox = New RichTextBox

                            Dim _line As String = _csv.ReadLine
                            While Not _line Is Nothing
                                _richTextBox.Text += _line + ChrW(10)
                                _line = _csv.ReadLine()
                            End While
                            _richTextBox.Dock = DockStyle.Fill

                            _tabPage = New TabPage("CSV")
                            _tabPage.Controls.Add(_richTextBox)

                            Me.FormatsTabControl.TabPages.Add(_tabPage)

                        Case DataFormats.Rtf
                            ' Rich text format

                            Dim _rtf As String = CType(_iDataObject.GetData(_format), String)

                            Dim _richTextBox As RichTextBox = New RichTextBox

                            _richTextBox.Rtf = _rtf
                            _richTextBox.Dock = DockStyle.Fill

                            _tabPage = New TabPage("RTF")
                            _tabPage.Controls.Add(_richTextBox)

                            Me.FormatsTabControl.TabPages.Add(_tabPage)

                        Case DataFormats.Html, DataFormats.StringFormat, DataFormats.Text, DataFormats.UnicodeText

                            Dim _text As String = CType(_iDataObject.GetData(_format), String)

                            Dim _richTextBox As RichTextBox = New RichTextBox

                            _richTextBox.Text = _text
                            _richTextBox.Dock = DockStyle.Fill

                            _tabPage = New TabPage(_format)
                            _tabPage.Controls.Add(_richTextBox)

                            Me.FormatsTabControl.TabPages.Add(_tabPage)

                        Case Else

                            _others.Add(_format)

                    End Select

                Catch ex As Exception
                    Debug.Assert(False, ex.ToString)
                    ' Ignore errors
                End Try

            Next

            If (0 < _others.Count) Then

                Dim _text As String = "Unsupported formats also on clipboard:  " + ChrW(10) + ChrW(10)

                For _idx As Integer = 0 To _others.Count - 1
                    _text += CStr(_others(_idx)) + ChrW(10)
                Next

                Dim _richTextBox As RichTextBox = New RichTextBox

                _richTextBox.Text = _text
                _richTextBox.Dock = DockStyle.Fill

                _tabPage = New TabPage("Others")
                _tabPage.Controls.Add(_richTextBox)

                Me.FormatsTabControl.TabPages.Add(_tabPage)

            End If

        End If

    End Sub

#End Region

End Class
