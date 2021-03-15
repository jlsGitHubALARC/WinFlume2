
Public Class TextViewer
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Public WithEvents ErrorRichTextBox As WinMain.ErrorRichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ErrorRichTextBox = New WinMain.ErrorRichTextBox
        Me.SuspendLayout()
        '
        'ErrorRichTextBox
        '
        Me.ErrorRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ErrorRichTextBox.Location = New System.Drawing.Point(0, 0)
        Me.ErrorRichTextBox.Name = "ErrorRichTextBox"
        Me.ErrorRichTextBox.ReadOnly = True
        Me.ErrorRichTextBox.Size = New System.Drawing.Size(600, 280)
        Me.ErrorRichTextBox.TabIndex = 0
        Me.ErrorRichTextBox.Text = ""
        '
        'TextViewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(600, 280)
        Me.Controls.Add(Me.ErrorRichTextBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "TextViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text Viewer"
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
