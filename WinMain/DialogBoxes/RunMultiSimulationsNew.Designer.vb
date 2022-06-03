<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RunMultiSimulationsNew
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.RunMultiSimsTitle = New DataStore.ctl_Label()
        Me.StructUnstructControl = New DataStore.ctl_TabControl()
        Me.StructuredTab = New System.Windows.Forms.TabPage()
        Me.Ctl_SensitivityAnalysisStructered = New WinMain.ctl_SensitivityAnalysisStructured()
        Me.UnstructuredTab = New System.Windows.Forms.TabPage()
        Me.Ctl_SensitivityAnalysisUnstructured = New WinMain.ctl_SensitivityAnalysisUnstructured()
        Me.StructUnstructControl.SuspendLayout()
        Me.StructuredTab.SuspendLayout()
        Me.UnstructuredTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'RunMultiSimsTitle
        '
        Me.RunMultiSimsTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.RunMultiSimsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.RunMultiSimsTitle.Location = New System.Drawing.Point(0, 0)
        Me.RunMultiSimsTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.RunMultiSimsTitle.Name = "RunMultiSimsTitle"
        Me.RunMultiSimsTitle.Size = New System.Drawing.Size(782, 36)
        Me.RunMultiSimsTitle.TabIndex = 1
        Me.RunMultiSimsTitle.Text = "Run Mulitple Simulations (File Driven)"
        Me.RunMultiSimsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StructUnstructControl
        '
        Me.StructUnstructControl.AccessibleDescription = ""
        Me.StructUnstructControl.AccessibleName = ""
        Me.StructUnstructControl.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.StructUnstructControl.Controls.Add(Me.StructuredTab)
        Me.StructUnstructControl.Controls.Add(Me.UnstructuredTab)
        Me.StructUnstructControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StructUnstructControl.Location = New System.Drawing.Point(0, 36)
        Me.StructUnstructControl.Name = "StructUnstructControl"
        Me.StructUnstructControl.SelectedIndex = 0
        Me.StructUnstructControl.Size = New System.Drawing.Size(782, 752)
        Me.StructUnstructControl.TabIndex = 3
        '
        'StructuredTab
        '
        Me.StructuredTab.Controls.Add(Me.Ctl_SensitivityAnalysisStructered)
        Me.StructuredTab.Location = New System.Drawing.Point(4, 4)
        Me.StructuredTab.Name = "StructuredTab"
        Me.StructuredTab.Padding = New System.Windows.Forms.Padding(3)
        Me.StructuredTab.Size = New System.Drawing.Size(774, 721)
        Me.StructuredTab.TabIndex = 0
        Me.StructuredTab.Text = "Structured"
        Me.StructuredTab.UseVisualStyleBackColor = True
        '
        'Ctl_SensitivityAnalysisStructered
        '
        Me.Ctl_SensitivityAnalysisStructered.AccessibleDescription = "Collection of controls for defining the irrigation parameters and ranges for Sens" &
    "itivity Analysis"
        Me.Ctl_SensitivityAnalysisStructered.AccessibleName = "Sensitivity Analysis Setup Control"
        Me.Ctl_SensitivityAnalysisStructered.Dep1UnitsTxt = Nothing
        Me.Ctl_SensitivityAnalysisStructered.Dep1UnitsVal = 0R
        Me.Ctl_SensitivityAnalysisStructered.Dep2UnitsTxt = Nothing
        Me.Ctl_SensitivityAnalysisStructered.Dep2UnitsVal = 0R
        Me.Ctl_SensitivityAnalysisStructered.Dep3UnitsTxt = Nothing
        Me.Ctl_SensitivityAnalysisStructered.Dep3UnitsVal = 0R
        Me.Ctl_SensitivityAnalysisStructered.Dep4UnitsTxt = Nothing
        Me.Ctl_SensitivityAnalysisStructered.Dep4UnitsVal = 0R
        Me.Ctl_SensitivityAnalysisStructered.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ctl_SensitivityAnalysisStructered.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ctl_SensitivityAnalysisStructered.Location = New System.Drawing.Point(3, 3)
        Me.Ctl_SensitivityAnalysisStructered.Margin = New System.Windows.Forms.Padding(4)
        Me.Ctl_SensitivityAnalysisStructered.Name = "Ctl_SensitivityAnalysisStructered"
        Me.Ctl_SensitivityAnalysisStructered.NumDepParams = 1
        Me.Ctl_SensitivityAnalysisStructered.NumIndepParams = 1
        Me.Ctl_SensitivityAnalysisStructered.Ind1Incs = 10
        Me.Ctl_SensitivityAnalysisStructered.Ind1UnitsTxt = Nothing
        Me.Ctl_SensitivityAnalysisStructered.Ind1UnitsVal = 0R
        Me.Ctl_SensitivityAnalysisStructered.Size = New System.Drawing.Size(768, 715)
        Me.Ctl_SensitivityAnalysisStructered.TabIndex = 0
        Me.Ctl_SensitivityAnalysisStructered.Ind2Incs = 10
        Me.Ctl_SensitivityAnalysisStructered.Ind2UnitsTxt = Nothing
        Me.Ctl_SensitivityAnalysisStructered.Inp2UnitsVal = 0R
        Me.Ctl_SensitivityAnalysisStructered.UnitRef = Nothing
        '
        'UnstructuredTab
        '
        Me.UnstructuredTab.Controls.Add(Me.Ctl_SensitivityAnalysisUnstructured)
        Me.UnstructuredTab.Location = New System.Drawing.Point(4, 4)
        Me.UnstructuredTab.Name = "UnstructuredTab"
        Me.UnstructuredTab.Padding = New System.Windows.Forms.Padding(3)
        Me.UnstructuredTab.Size = New System.Drawing.Size(774, 721)
        Me.UnstructuredTab.TabIndex = 1
        Me.UnstructuredTab.Text = "Unstructured"
        Me.UnstructuredTab.UseVisualStyleBackColor = True
        '
        'Ctl_SensitivityAnalysisUnstructured
        '
        Me.Ctl_SensitivityAnalysisUnstructured.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ctl_SensitivityAnalysisUnstructured.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ctl_SensitivityAnalysisUnstructured.Location = New System.Drawing.Point(3, 3)
        Me.Ctl_SensitivityAnalysisUnstructured.Margin = New System.Windows.Forms.Padding(4)
        Me.Ctl_SensitivityAnalysisUnstructured.Name = "Ctl_SensitivityAnalysisUnstructured"
        Me.Ctl_SensitivityAnalysisUnstructured.Size = New System.Drawing.Size(768, 715)
        Me.Ctl_SensitivityAnalysisUnstructured.TabIndex = 0
        '
        'RunMultiSimulationsNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 788)
        Me.Controls.Add(Me.StructUnstructControl)
        Me.Controls.Add(Me.RunMultiSimsTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RunMultiSimulationsNew"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Run Multple Simulations"
        Me.StructUnstructControl.ResumeLayout(False)
        Me.StructuredTab.ResumeLayout(False)
        Me.UnstructuredTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RunMultiSimsTitle As DataStore.ctl_Label
    Friend WithEvents StructUnstructControl As DataStore.ctl_TabControl
    Friend WithEvents StructuredTab As TabPage
    Friend WithEvents UnstructuredTab As TabPage
    Friend WithEvents Ctl_SensitivityAnalysisStructered As ctl_SensitivityAnalysisStructured
    Friend WithEvents Ctl_SensitivityAnalysisUnstructured As ctl_SensitivityAnalysisUnstructured
End Class
