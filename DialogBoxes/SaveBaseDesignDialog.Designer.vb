<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveBaseDesignDialog
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
        Me.InstructionsLabel = New System.Windows.Forms.Label()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.SaveAsButton = New System.Windows.Forms.Button()
        Me.NoButton = New System.Windows.Forms.Button()
        Me.DontShowDialog = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'InstructionsLabel
        '
        Me.InstructionsLabel.AccessibleDescription = "Do  you want to save current design as Base Design in a file?"
        Me.InstructionsLabel.AccessibleName = "Save Question"
        Me.InstructionsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstructionsLabel.Location = New System.Drawing.Point(13, 9)
        Me.InstructionsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.InstructionsLabel.Name = "InstructionsLabel"
        Me.InstructionsLabel.Size = New System.Drawing.Size(392, 45)
        Me.InstructionsLabel.TabIndex = 0
        Me.InstructionsLabel.Text = "Do you want to save the Base Design to file before examining the Alternative Desi" &
    "gns?"
        Me.InstructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SaveButton
        '
        Me.SaveButton.AccessibleDescription = "Save Base Design to currently opened file."
        Me.SaveButton.AccessibleName = "Save"
        Me.SaveButton.Location = New System.Drawing.Point(10, 70)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(107, 27)
        Me.SaveButton.TabIndex = 1
        Me.SaveButton.Text = "&Save"
        '
        'SaveAsButton
        '
        Me.SaveAsButton.AccessibleDescription = "Save Base Design to new file."
        Me.SaveAsButton.AccessibleName = "Save &As Button"
        Me.SaveAsButton.Location = New System.Drawing.Point(150, 70)
        Me.SaveAsButton.Name = "SaveAsButton"
        Me.SaveAsButton.Size = New System.Drawing.Size(107, 27)
        Me.SaveAsButton.TabIndex = 2
        Me.SaveAsButton.Text = "Save &As"
        '
        'NoButton
        '
        Me.NoButton.AccessibleDescription = "User does not want to save Base Design before proceeding."
        Me.NoButton.AccessibleName = "No Button"
        Me.NoButton.Location = New System.Drawing.Point(282, 70)
        Me.NoButton.Name = "NoButton"
        Me.NoButton.Size = New System.Drawing.Size(107, 27)
        Me.NoButton.TabIndex = 3
        Me.NoButton.Text = "&No"
        '
        'CheckBox2
        '
        Me.DontShowDialog.AccessibleDescription = "Check this box if you do not want to see this dialog each time you navigate to th" &
    "e Design tab."
        Me.DontShowDialog.AccessibleName = "Don't Show Dialog"
        Me.DontShowDialog.AutoSize = True
        Me.DontShowDialog.Location = New System.Drawing.Point(12, 115)
        Me.DontShowDialog.Name = "CheckBox2"
        Me.DontShowDialog.Size = New System.Drawing.Size(340, 24)
        Me.DontShowDialog.TabIndex = 6
        Me.DontShowDialog.Text = "Don't show this dialog again this session."
        Me.DontShowDialog.UseVisualStyleBackColor = True
        '
        'SaveBaseDesignDialog
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 145)
        Me.Controls.Add(Me.DontShowDialog)
        Me.Controls.Add(Me.NoButton)
        Me.Controls.Add(Me.SaveAsButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.InstructionsLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SaveBaseDesignDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Save Base Design Dialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents InstructionsLabel As Label
    Friend WithEvents SaveButton As Button
    Friend WithEvents SaveAsButton As Button
    Friend WithEvents NoButton As Button
    Friend WithEvents DontShowDialog As CheckBox
End Class
