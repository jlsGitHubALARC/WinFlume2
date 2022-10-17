<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DrawingsReportsControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DrawingsReportsControl))
        Me.DrawingsReportsControlTabControl = New System.Windows.Forms.TabControl()
        Me.PrintReportsDialog = New System.Windows.Forms.PrintDialog()
        Me.PrintReportDocument = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'DrawingsReportsControlTabControl
        '
        resources.ApplyResources(Me.DrawingsReportsControlTabControl, "DrawingsReportsControlTabControl")
        Me.DrawingsReportsControlTabControl.Multiline = True
        Me.DrawingsReportsControlTabControl.Name = "DrawingsReportsControlTabControl"
        Me.DrawingsReportsControlTabControl.SelectedIndex = 0
        '
        'PrintReportsDialog
        '
        Me.PrintReportsDialog.UseEXDialog = True
        '
        'DrawingsReportsControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.DrawingsReportsControlTabControl)
        Me.Name = "DrawingsReportsControl"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DrawingsReportsControlTabControl As TabControl
    Friend WithEvents PrintReportsDialog As PrintDialog
    Friend WithEvents PrintReportDocument As Printing.PrintDocument
End Class
