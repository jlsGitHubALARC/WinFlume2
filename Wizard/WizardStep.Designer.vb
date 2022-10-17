<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WizardStep
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WizardStep))
        Me.StepPanel1 = New System.Windows.Forms.Panel()
        Me.StepPanel2 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'StepPanel1
        '
        resources.ApplyResources(Me.StepPanel1, "StepPanel1")
        Me.StepPanel1.Name = "StepPanel1"
        '
        'StepPanel2
        '
        resources.ApplyResources(Me.StepPanel2, "StepPanel2")
        Me.StepPanel2.Name = "StepPanel2"
        '
        'WizardStep
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.StepPanel2)
        Me.Controls.Add(Me.StepPanel1)
        Me.Name = "WizardStep"
        Me.ResumeLayout(False)

    End Sub

    Protected Friend WithEvents StepPanel1 As Panel
    Protected Friend WithEvents StepPanel2 As Panel
End Class
