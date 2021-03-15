
'**********************************************************************************************
' Image Viewer - Provides a Windows Form for viewing images
'
Public Class ImageViewer
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _title As String, ByVal _helpLine1 As String, ByVal _helpLine2 As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeImageViewer(_title, _helpLine1, _helpLine2)

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
    Friend WithEvents ImageTitle As System.Windows.Forms.Label
    Friend WithEvents HelpLine2 As System.Windows.Forms.Label
    Friend WithEvents HelpLine1 As System.Windows.Forms.Label
    Public WithEvents ImagePanel As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ImageViewer))
        Me.ImageTitle = New System.Windows.Forms.Label
        Me.HelpLine2 = New System.Windows.Forms.Label
        Me.HelpLine1 = New System.Windows.Forms.Label
        Me.ImagePanel = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'ImageTitle
        '
        Me.ImageTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.ImageTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImageTitle.Location = New System.Drawing.Point(0, 0)
        Me.ImageTitle.Name = "ImageTitle"
        Me.ImageTitle.Size = New System.Drawing.Size(592, 23)
        Me.ImageTitle.TabIndex = 0
        Me.ImageTitle.Text = "Image"
        Me.ImageTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'HelpLine2
        '
        Me.HelpLine2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HelpLine2.Location = New System.Drawing.Point(0, 353)
        Me.HelpLine2.Name = "HelpLine2"
        Me.HelpLine2.Size = New System.Drawing.Size(592, 23)
        Me.HelpLine2.TabIndex = 1
        Me.HelpLine2.Text = "Text"
        Me.HelpLine2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'HelpLine1
        '
        Me.HelpLine1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HelpLine1.Location = New System.Drawing.Point(0, 330)
        Me.HelpLine1.Name = "HelpLine1"
        Me.HelpLine1.Size = New System.Drawing.Size(592, 23)
        Me.HelpLine1.TabIndex = 2
        Me.HelpLine1.Text = "Help"
        Me.HelpLine1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ImagePanel
        '
        Me.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagePanel.Location = New System.Drawing.Point(0, 23)
        Me.ImagePanel.Name = "ImagePanel"
        Me.ImagePanel.Size = New System.Drawing.Size(592, 307)
        Me.ImagePanel.TabIndex = 3
        '
        'ImageViewer
        '
        Me.AccessibleDescription = "Displays a sizeable image."
        Me.AccessibleName = "Image Viewer"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(592, 376)
        Me.Controls.Add(Me.ImagePanel)
        Me.Controls.Add(Me.HelpLine1)
        Me.Controls.Add(Me.HelpLine2)
        Me.Controls.Add(Me.ImageTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImageViewer"
        Me.ShowInTaskbar = False
        Me.Text = "Image Viewer"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    Private mSize As Size

#End Region

#Region " Initialization "

    Private Sub InitializeImageViewer(ByVal _title As String, _
                                      ByVal _helpLine1 As String, _
                                      ByVal _helpLine2 As String)

        Me.ImageTitle.Text = _title
        Me.HelpLine1.Text = _helpLine1
        Me.HelpLine2.Text = _helpLine2

        mSize = Me.Size

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub ImageViewer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        ' Do not allow a form to close.
        e.Cancel = True
        ' Simply hide the form instead.
        Hide()
    End Sub

    Private Sub ImageView_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.SizeChanged
        If ((Me.Size.Width < mSize.Width) Or (Me.Size.Height < mSize.Height)) Then
            ImagePanel.Invalidate()
        End If
        mSize = Me.Size
    End Sub

#End Region

End Class
