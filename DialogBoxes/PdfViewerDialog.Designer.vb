<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PdfViewerDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PdfViewerDialog))
        Me.ViewerPanel = New WinFlume.ctl_Panel()
        Me.PdfViewer = New AxAcroPDFLib.AxAcroPDF()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.ButtonPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ViewerPanel.SuspendLayout()
        CType(Me.PdfViewer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlPanel.SuspendLayout()
        Me.ButtonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ViewerPanel
        '
        Me.ViewerPanel.Controls.Add(Me.PdfViewer)
        Me.ViewerPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewerPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ViewerPanel.Location = New System.Drawing.Point(0, 0)
        Me.ViewerPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.ViewerPanel.Name = "ViewerPanel"
        Me.ViewerPanel.Size = New System.Drawing.Size(784, 511)
        Me.ViewerPanel.TabIndex = 1
        '
        'PdfViewer
        '
        Me.PdfViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PdfViewer.Enabled = True
        Me.PdfViewer.Location = New System.Drawing.Point(0, 0)
        Me.PdfViewer.Margin = New System.Windows.Forms.Padding(4)
        Me.PdfViewer.Name = "PdfViewer"
        Me.PdfViewer.OcxState = CType(resources.GetObject("PdfViewer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PdfViewer.Size = New System.Drawing.Size(784, 511)
        Me.PdfViewer.TabIndex = 2
        '
        'ControlPanel
        '
        Me.ControlPanel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ControlPanel.Controls.Add(Me.ButtonPanel)
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ControlPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ControlPanel.Location = New System.Drawing.Point(0, 511)
        Me.ControlPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(784, 50)
        Me.ControlPanel.TabIndex = 0
        '
        'ButtonPanel
        '
        Me.ButtonPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPanel.ColumnCount = 2
        Me.ButtonPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ButtonPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ButtonPanel.Controls.Add(Me.OK_Button, 0, 0)
        Me.ButtonPanel.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.ButtonPanel.Location = New System.Drawing.Point(583, 7)
        Me.ButtonPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.RowCount = 1
        Me.ButtonPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ButtonPanel.Size = New System.Drawing.Size(195, 36)
        Me.ButtonPanel.TabIndex = 1
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.Visible = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(101, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Close"
        '
        'PdfViewerDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.ViewerPanel)
        Me.Controls.Add(Me.ControlPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "PdfViewerDialog"
        Me.ShowIcon = False
        Me.Text = "PdfViewerDialog"
        Me.ViewerPanel.ResumeLayout(False)
        CType(Me.PdfViewer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlPanel.ResumeLayout(False)
        Me.ButtonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ControlPanel As ctl_Panel
    Friend WithEvents ButtonPanel As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents ViewerPanel As ctl_Panel
    Friend WithEvents PdfViewer As AxAcroPDFLib.AxAcroPDF
End Class
