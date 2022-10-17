<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectDescription
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
        Me.ProjectDescriptionPanel1 = New System.Windows.Forms.Panel()
        Me.ProjectDescriptionTextBox1 = New System.Windows.Forms.TextBox()
        Me.ProjectDescriptionPanel2 = New System.Windows.Forms.Panel()
        Me.ProjectDescriptionTextBox2 = New System.Windows.Forms.TextBox()
        Me.StepPanel1.SuspendLayout()
        Me.StepPanel2.SuspendLayout()
        Me.ProjectDescriptionPanel1.SuspendLayout()
        Me.ProjectDescriptionPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StepPanel1
        '
        Me.StepPanel1.Controls.Add(Me.ProjectDescriptionPanel1)
        '
        'StepPanel2
        '
        Me.StepPanel2.Controls.Add(Me.ProjectDescriptionPanel2)
        '
        'ProjectDescriptionPanel1
        '
        Me.ProjectDescriptionPanel1.Controls.Add(Me.ProjectDescriptionTextBox1)
        Me.ProjectDescriptionPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProjectDescriptionPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ProjectDescriptionPanel1.Name = "ProjectDescriptionPanel1"
        Me.ProjectDescriptionPanel1.Size = New System.Drawing.Size(420, 170)
        Me.ProjectDescriptionPanel1.TabIndex = 0
        '
        'ProjectDescriptionTextBox1
        '
        Me.ProjectDescriptionTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProjectDescriptionTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.ProjectDescriptionTextBox1.Multiline = True
        Me.ProjectDescriptionTextBox1.Name = "ProjectDescriptionTextBox1"
        Me.ProjectDescriptionTextBox1.Size = New System.Drawing.Size(420, 170)
        Me.ProjectDescriptionTextBox1.TabIndex = 0
        Me.ProjectDescriptionTextBox1.Text = "Enter a brief description for the project.  The description will be shown on the " &
    "printed output."
        '
        'ProjectDescriptionPanel2
        '
        Me.ProjectDescriptionPanel2.Controls.Add(Me.ProjectDescriptionTextBox2)
        Me.ProjectDescriptionPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProjectDescriptionPanel2.Location = New System.Drawing.Point(0, 0)
        Me.ProjectDescriptionPanel2.Name = "ProjectDescriptionPanel2"
        Me.ProjectDescriptionPanel2.Size = New System.Drawing.Size(420, 20)
        Me.ProjectDescriptionPanel2.TabIndex = 0
        '
        'ProjectDescriptionTextBox2
        '
        Me.ProjectDescriptionTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProjectDescriptionTextBox2.Location = New System.Drawing.Point(0, 0)
        Me.ProjectDescriptionTextBox2.Multiline = True
        Me.ProjectDescriptionTextBox2.Name = "ProjectDescriptionTextBox2"
        Me.ProjectDescriptionTextBox2.Size = New System.Drawing.Size(420, 20)
        Me.ProjectDescriptionTextBox2.TabIndex = 0
        Me.ProjectDescriptionTextBox2.Text = "Click the 'Next >' button to continue."
        Me.ProjectDescriptionTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ProjectDescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Name = "ProjectDescription"
        Me.StepPanel1.ResumeLayout(False)
        Me.StepPanel2.ResumeLayout(False)
        Me.ProjectDescriptionPanel1.ResumeLayout(False)
        Me.ProjectDescriptionPanel1.PerformLayout()
        Me.ProjectDescriptionPanel2.ResumeLayout(False)
        Me.ProjectDescriptionPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProjectDescriptionPanel1 As Panel
    Friend WithEvents ProjectDescriptionPanel2 As Panel
    Friend WithEvents ProjectDescriptionTextBox1 As TextBox
    Friend WithEvents ProjectDescriptionTextBox2 As TextBox
End Class
