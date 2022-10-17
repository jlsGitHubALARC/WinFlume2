<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_ComboBox
    Inherits System.Windows.Forms.ComboBox

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
        Me.SuspendLayout()
        '
        'ctl_ComboBox
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Size = New System.Drawing.Size(121, 21)
        Me.ResumeLayout(False)

    End Sub

End Class
