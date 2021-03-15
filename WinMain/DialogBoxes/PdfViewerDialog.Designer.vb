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
        Me.ControlPanel = New DataStore.ctl_Panel()
        Me.ButtonPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ViewerPanel = New DataStore.ctl_Panel()
        Me.PdfViewer = New AxAcroPDFLib.AxAcroPDF()
        Me.ControlPanel.SuspendLayout()
        Me.ButtonPanel.SuspendLayout()
        Me.ViewerPanel.SuspendLayout()
        CType(Me.PdfViewer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ControlPanel
        '
        Me.ControlPanel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ControlPanel.Controls.Add(Me.ButtonPanel)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'ButtonPanel
        '
        resources.ApplyResources(Me.ButtonPanel, "ButtonPanel")
        Me.ButtonPanel.Controls.Add(Me.OK_Button, 0, 0)
        Me.ButtonPanel.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.ButtonPanel.Name = "ButtonPanel"
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'ViewerPanel
        '
        Me.ViewerPanel.Controls.Add(Me.PdfViewer)
        resources.ApplyResources(Me.ViewerPanel, "ViewerPanel")
        Me.ViewerPanel.Name = "ViewerPanel"
        '
        'PdfViewer
        '
        resources.ApplyResources(Me.PdfViewer, "PdfViewer")
        Me.PdfViewer.Name = "PdfViewer"
        Me.PdfViewer.OcxState = CType(resources.GetObject("PdfViewer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PdfViewer.TabStop = False
        '
        'PdfViewerDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ViewerPanel)
        Me.Controls.Add(Me.ControlPanel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PdfViewerDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ControlPanel.ResumeLayout(False)
        Me.ButtonPanel.ResumeLayout(False)
        Me.ViewerPanel.ResumeLayout(False)
        CType(Me.PdfViewer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ControlPanel As DataStore.ctl_Panel
    Friend WithEvents ButtonPanel As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents ViewerPanel As DataStore.ctl_Panel
    Friend WithEvents PdfViewer As AxAcroPDFLib.AxAcroPDF
End Class
