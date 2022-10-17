<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_SingleUnits
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
        Me.components = New System.ComponentModel.Container()
        Me.SingleText = New System.Windows.Forms.TextBox()
        Me.SingleUnits = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TextboxContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TextboxContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'SingleText
        '
        Me.SingleText.ContextMenuStrip = Me.TextboxContextMenu
        Me.SingleText.Location = New System.Drawing.Point(0, 0)
        Me.SingleText.Margin = New System.Windows.Forms.Padding(0)
        Me.SingleText.Name = "SingleText"
        Me.SingleText.Size = New System.Drawing.Size(55, 23)
        Me.SingleText.TabIndex = 0
        Me.SingleText.Text = "0.12345"
        '
        'SingleUnits
        '
        Me.SingleUnits.AutoSize = True
        Me.SingleUnits.Location = New System.Drawing.Point(58, 2)
        Me.SingleUnits.Name = "SingleUnits"
        Me.SingleUnits.Size = New System.Drawing.Size(16, 17)
        Me.SingleUnits.TabIndex = 1
        Me.SingleUnits.Text = "ft"
        Me.SingleUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'TextboxContextMenu
        '
        Me.TextboxContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.TextboxContextMenu.Name = "TextboxContextMenu"
        Me.TextboxContextMenu.Size = New System.Drawing.Size(145, 48)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ctl_SingleUnits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.SingleUnits)
        Me.Controls.Add(Me.SingleText)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ctl_SingleUnits"
        Me.Size = New System.Drawing.Size(150, 24)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TextboxContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SingleText As System.Windows.Forms.TextBox
    Friend WithEvents SingleUnits As System.Windows.Forms.Label
    Protected Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents TextboxContextMenu As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
End Class
