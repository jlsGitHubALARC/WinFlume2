<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MatchControlDialog
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
        Me.OkCancelPanel = New System.Windows.Forms.Panel()
        Me.ButtonTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.MessagePanel = New System.Windows.Forms.Panel()
        Me.MessageBox = New System.Windows.Forms.RichTextBox()
        Me.GraphicsPanel = New System.Windows.Forms.Panel()
        Me.ControlPanel = New System.Windows.Forms.Panel()
        Me.ControlShapeGroup = New WinFlume.ctl_GroupBox()
        Me.ShapeButton4 = New System.Windows.Forms.RadioButton()
        Me.ShapeButton3 = New System.Windows.Forms.RadioButton()
        Me.ShapeButton2 = New System.Windows.Forms.RadioButton()
        Me.ShapeButton1 = New System.Windows.Forms.RadioButton()
        Me.OkCancelPanel.SuspendLayout()
        Me.ButtonTableLayoutPanel.SuspendLayout()
        Me.MessagePanel.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        Me.ControlShapeGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'OkCancelPanel
        '
        Me.OkCancelPanel.Controls.Add(Me.ButtonTableLayoutPanel)
        Me.OkCancelPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.OkCancelPanel.Location = New System.Drawing.Point(0, 385)
        Me.OkCancelPanel.Name = "OkCancelPanel"
        Me.OkCancelPanel.Size = New System.Drawing.Size(434, 56)
        Me.OkCancelPanel.TabIndex = 1
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
        'MessagePanel
        '
        Me.MessagePanel.Controls.Add(Me.MessageBox)
        Me.MessagePanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MessagePanel.Location = New System.Drawing.Point(0, 139)
        Me.MessagePanel.Name = "MessagePanel"
        Me.MessagePanel.Size = New System.Drawing.Size(434, 246)
        Me.MessagePanel.TabIndex = 2
        '
        'MessageBox
        '
        Me.MessageBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MessageBox.Location = New System.Drawing.Point(0, 0)
        Me.MessageBox.Name = "MessageBox"
        Me.MessageBox.Size = New System.Drawing.Size(434, 246)
        Me.MessageBox.TabIndex = 0
        Me.MessageBox.Text = ""
        '
        'GraphicsPanel
        '
        Me.GraphicsPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.GraphicsPanel.Location = New System.Drawing.Point(0, 0)
        Me.GraphicsPanel.Name = "GraphicsPanel"
        Me.GraphicsPanel.Size = New System.Drawing.Size(434, 8)
        Me.GraphicsPanel.TabIndex = 3
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.ControlShapeGroup)
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlPanel.Location = New System.Drawing.Point(0, 8)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(434, 131)
        Me.ControlPanel.TabIndex = 0
        '
        'ControlShapeGroup
        '
        Me.ControlShapeGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ControlShapeGroup.Controls.Add(Me.ShapeButton4)
        Me.ControlShapeGroup.Controls.Add(Me.ShapeButton3)
        Me.ControlShapeGroup.Controls.Add(Me.ShapeButton2)
        Me.ControlShapeGroup.Controls.Add(Me.ShapeButton1)
        Me.ControlShapeGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlShapeGroup.Location = New System.Drawing.Point(12, 7)
        Me.ControlShapeGroup.Name = "ControlShapeGroup"
        Me.ControlShapeGroup.Size = New System.Drawing.Size(410, 118)
        Me.ControlShapeGroup.TabIndex = 0
        Me.ControlShapeGroup.TabStop = False
        Me.ControlShapeGroup.Text = "Select Control Section Shape"
        '
        'ShapeButton4
        '
        Me.ShapeButton4.AutoSize = True
        Me.ShapeButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShapeButton4.Location = New System.Drawing.Point(15, 86)
        Me.ShapeButton4.Name = "ShapeButton4"
        Me.ShapeButton4.Size = New System.Drawing.Size(79, 21)
        Me.ShapeButton4.TabIndex = 7
        Me.ShapeButton4.TabStop = True
        Me.ShapeButton4.Text = "Shape 4"
        Me.ShapeButton4.UseVisualStyleBackColor = True
        '
        'ShapeButton3
        '
        Me.ShapeButton3.AutoSize = True
        Me.ShapeButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShapeButton3.Location = New System.Drawing.Point(15, 64)
        Me.ShapeButton3.Name = "ShapeButton3"
        Me.ShapeButton3.Size = New System.Drawing.Size(79, 21)
        Me.ShapeButton3.TabIndex = 6
        Me.ShapeButton3.TabStop = True
        Me.ShapeButton3.Text = "Shape 3"
        Me.ShapeButton3.UseVisualStyleBackColor = True
        '
        'ShapeButton2
        '
        Me.ShapeButton2.AutoSize = True
        Me.ShapeButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShapeButton2.Location = New System.Drawing.Point(15, 42)
        Me.ShapeButton2.Name = "ShapeButton2"
        Me.ShapeButton2.Size = New System.Drawing.Size(79, 21)
        Me.ShapeButton2.TabIndex = 5
        Me.ShapeButton2.TabStop = True
        Me.ShapeButton2.Text = "Shape 2"
        Me.ShapeButton2.UseVisualStyleBackColor = True
        '
        'ShapeButton1
        '
        Me.ShapeButton1.AutoSize = True
        Me.ShapeButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShapeButton1.Location = New System.Drawing.Point(15, 20)
        Me.ShapeButton1.Name = "ShapeButton1"
        Me.ShapeButton1.Size = New System.Drawing.Size(79, 21)
        Me.ShapeButton1.TabIndex = 4
        Me.ShapeButton1.TabStop = True
        Me.ShapeButton1.Text = "Shape 1"
        Me.ShapeButton1.UseVisualStyleBackColor = True
        '
        'MatchControlDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(434, 441)
        Me.Controls.Add(Me.ControlPanel)
        Me.Controls.Add(Me.GraphicsPanel)
        Me.Controls.Add(Me.MessagePanel)
        Me.Controls.Add(Me.OkCancelPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(370, 420)
        Me.Name = "MatchControlDialog"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Match Control Section to Approach Channel"
        Me.OkCancelPanel.ResumeLayout(False)
        Me.ButtonTableLayoutPanel.ResumeLayout(False)
        Me.MessagePanel.ResumeLayout(False)
        Me.ControlPanel.ResumeLayout(False)
        Me.ControlShapeGroup.ResumeLayout(False)
        Me.ControlShapeGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OkCancelPanel As Panel
    Friend WithEvents ButtonTableLayoutPanel As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents MessagePanel As Panel
    Friend WithEvents GraphicsPanel As Panel
    Friend WithEvents ControlPanel As Panel
    Friend WithEvents ControlShapeGroup As ctl_GroupBox
    Friend WithEvents ShapeButton4 As RadioButton
    Friend WithEvents ShapeButton3 As RadioButton
    Friend WithEvents ShapeButton2 As RadioButton
    Friend WithEvents ShapeButton1 As RadioButton
    Friend WithEvents MessageBox As RichTextBox
End Class
