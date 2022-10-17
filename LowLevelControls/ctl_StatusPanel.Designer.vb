<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_StatusPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_StatusPanel))
        Me.Title = New System.Windows.Forms.Label()
        Me.StatusBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Title
        '
        resources.ApplyResources(Me.Title, "Title")
        Me.Title.Name = "Title"
        '
        'StatusBox
        '
        Me.StatusBox.BackColor = System.Drawing.SystemColors.Info
        resources.ApplyResources(Me.StatusBox, "StatusBox")
        Me.StatusBox.ForeColor = System.Drawing.SystemColors.InfoText
        Me.StatusBox.Name = "StatusBox"
        '
        'ctl_StatusPanel
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.Title)
        Me.Name = "ctl_StatusPanel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Title As System.Windows.Forms.Label
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox

End Class
