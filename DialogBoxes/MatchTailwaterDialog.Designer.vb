<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MatchTailwaterDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MatchTailwaterDialog))
        Me.OkCancelPanel = New System.Windows.Forms.Panel()
        Me.ButtonTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.MessageBox = New System.Windows.Forms.RichTextBox()
        Me.OkCancelPanel.SuspendLayout()
        Me.ButtonTableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'OkCancelPanel
        '
        Me.OkCancelPanel.Controls.Add(Me.ButtonTableLayoutPanel)
        Me.OkCancelPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.OkCancelPanel.Location = New System.Drawing.Point(0, 205)
        Me.OkCancelPanel.Name = "OkCancelPanel"
        Me.OkCancelPanel.Size = New System.Drawing.Size(434, 56)
        Me.OkCancelPanel.TabIndex = 2
        '
        'ButtonTableLayoutPanel
        '
        Me.ButtonTableLayoutPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonTableLayoutPanel.ColumnCount = 2
        Me.ButtonTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ButtonTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ButtonTableLayoutPanel.Controls.Add(Me.OK_Button, 0, 0)
        Me.ButtonTableLayoutPanel.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.ButtonTableLayoutPanel.Location = New System.Drawing.Point(231, 11)
        Me.ButtonTableLayoutPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonTableLayoutPanel.Name = "ButtonTableLayoutPanel"
        Me.ButtonTableLayoutPanel.RowCount = 1
        Me.ButtonTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ButtonTableLayoutPanel.Size = New System.Drawing.Size(195, 36)
        Me.ButtonTableLayoutPanel.TabIndex = 2
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "&OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cancel_Button.Location = New System.Drawing.Point(101, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "&Cancel"
        '
        'MessageBox
        '
        Me.MessageBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessageBox.Location = New System.Drawing.Point(0, 0)
        Me.MessageBox.Name = "MessageBox"
        Me.MessageBox.ReadOnly = True
        Me.MessageBox.Size = New System.Drawing.Size(434, 205)
        Me.MessageBox.TabIndex = 3
        Me.MessageBox.Text = resources.GetString("MessageBox.Text")
        '
        'MatchTailwaterDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 261)
        Me.Controls.Add(Me.MessageBox)
        Me.Controls.Add(Me.OkCancelPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MatchTailwaterDialog"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Match Tailwater Channel to Approach Channel"
        Me.OkCancelPanel.ResumeLayout(False)
        Me.ButtonTableLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OkCancelPanel As Panel
    Friend WithEvents ButtonTableLayoutPanel As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents MessageBox As RichTextBox
End Class
