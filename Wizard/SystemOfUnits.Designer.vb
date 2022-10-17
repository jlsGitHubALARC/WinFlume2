<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SystemOfUnits
    Inherits WinFlume.WizardStep

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SystemOfUnitsPanel1 = New System.Windows.Forms.Panel()
        Me.SystemOfUnitsTextBox1 = New System.Windows.Forms.TextBox()
        Me.SystemOfUnitsPanel2 = New System.Windows.Forms.Panel()
        Me.SystemOfUnitsTextBox2 = New System.Windows.Forms.TextBox()
        Me.StepPanel1.SuspendLayout()
        Me.StepPanel2.SuspendLayout()
        Me.SystemOfUnitsPanel1.SuspendLayout()
        Me.SystemOfUnitsPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StepPanel1
        '
        Me.StepPanel1.Controls.Add(Me.SystemOfUnitsPanel1)
        '
        'StepPanel2
        '
        Me.StepPanel2.Controls.Add(Me.SystemOfUnitsPanel2)
        '
        'SystemOfUnitsPanel1
        '
        Me.SystemOfUnitsPanel1.Controls.Add(Me.SystemOfUnitsTextBox1)
        Me.SystemOfUnitsPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemOfUnitsPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SystemOfUnitsPanel1.Name = "SystemOfUnitsPanel1"
        Me.SystemOfUnitsPanel1.Size = New System.Drawing.Size(420, 170)
        Me.SystemOfUnitsPanel1.TabIndex = 0
        '
        'SystemOfUnitsTextBox1
        '
        Me.SystemOfUnitsTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemOfUnitsTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.SystemOfUnitsTextBox1.Multiline = True
        Me.SystemOfUnitsTextBox1.Name = "SystemOfUnitsTextBox1"
        Me.SystemOfUnitsTextBox1.Size = New System.Drawing.Size(420, 170)
        Me.SystemOfUnitsTextBox1.TabIndex = 0
        Me.SystemOfUnitsTextBox1.Text = "Select the system of units to be used with this project."
        '
        'SystemOfUnitsPanel2
        '
        Me.SystemOfUnitsPanel2.Controls.Add(Me.SystemOfUnitsTextBox2)
        Me.SystemOfUnitsPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemOfUnitsPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SystemOfUnitsPanel2.Name = "SystemOfUnitsPanel2"
        Me.SystemOfUnitsPanel2.Size = New System.Drawing.Size(420, 20)
        Me.SystemOfUnitsPanel2.TabIndex = 0
        '
        'SystemOfUnitsTextBox2
        '
        Me.SystemOfUnitsTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SystemOfUnitsTextBox2.Location = New System.Drawing.Point(0, 0)
        Me.SystemOfUnitsTextBox2.Multiline = True
        Me.SystemOfUnitsTextBox2.Name = "SystemOfUnitsTextBox2"
        Me.SystemOfUnitsTextBox2.Size = New System.Drawing.Size(420, 20)
        Me.SystemOfUnitsTextBox2.TabIndex = 0
        Me.SystemOfUnitsTextBox2.Text = "Click the 'Next >' button to continue."
        Me.SystemOfUnitsTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SystemOfUnits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Name = "SystemOfUnits"
        Me.StepPanel1.ResumeLayout(False)
        Me.StepPanel2.ResumeLayout(False)
        Me.SystemOfUnitsPanel1.ResumeLayout(False)
        Me.SystemOfUnitsPanel1.PerformLayout()
        Me.SystemOfUnitsPanel2.ResumeLayout(False)
        Me.SystemOfUnitsPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SystemOfUnitsPanel1 As Panel
    Friend WithEvents SystemOfUnitsPanel2 As Panel
    Friend WithEvents SystemOfUnitsTextBox1 As TextBox
    Friend WithEvents SystemOfUnitsTextBox2 As TextBox
End Class
