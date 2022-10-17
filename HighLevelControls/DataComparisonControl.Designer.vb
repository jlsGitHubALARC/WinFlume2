<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataComparisonControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataComparisonControl))
        Me.DataComparisonControlTabControl = New WinFlume.ctl_TabControl()
        Me.DataEntryTab = New System.Windows.Forms.TabPage()
        Me.MeasuredDataEntryControl = New WinFlume.MeasuredDataEntryControl()
        Me.RatingComparisonTab = New System.Windows.Forms.TabPage()
        Me.RatingComparisonControl = New WinFlume.RatingComparisonControl()
        Me.DataComparisonControlTabControl.SuspendLayout()
        Me.DataEntryTab.SuspendLayout()
        Me.RatingComparisonTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataComparisonControlTabControl
        '
        resources.ApplyResources(Me.DataComparisonControlTabControl, "DataComparisonControlTabControl")
        Me.DataComparisonControlTabControl.Controls.Add(Me.DataEntryTab)
        Me.DataComparisonControlTabControl.Controls.Add(Me.RatingComparisonTab)
        Me.DataComparisonControlTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.DataComparisonControlTabControl.Name = "DataComparisonControlTabControl"
        Me.DataComparisonControlTabControl.SelectedIndex = 0
        Me.DataComparisonControlTabControl.Value = 0
        '
        'DataEntryTab
        '
        Me.DataEntryTab.Controls.Add(Me.MeasuredDataEntryControl)
        resources.ApplyResources(Me.DataEntryTab, "DataEntryTab")
        Me.DataEntryTab.Name = "DataEntryTab"
        Me.DataEntryTab.UseVisualStyleBackColor = True
        '
        'MeasuredDataEntryControl
        '
        Me.MeasuredDataEntryControl.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.MeasuredDataEntryControl, "MeasuredDataEntryControl")
        Me.MeasuredDataEntryControl.Name = "MeasuredDataEntryControl"
        '
        'RatingComparisonTab
        '
        Me.RatingComparisonTab.Controls.Add(Me.RatingComparisonControl)
        resources.ApplyResources(Me.RatingComparisonTab, "RatingComparisonTab")
        Me.RatingComparisonTab.Name = "RatingComparisonTab"
        Me.RatingComparisonTab.UseVisualStyleBackColor = True
        '
        'RatingComparisonControl
        '
        resources.ApplyResources(Me.RatingComparisonControl, "RatingComparisonControl")
        Me.RatingComparisonControl.Name = "RatingComparisonControl"
        '
        'DataComparisonControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.DataComparisonControlTabControl)
        Me.Name = "DataComparisonControl"
        Me.DataComparisonControlTabControl.ResumeLayout(False)
        Me.DataEntryTab.ResumeLayout(False)
        Me.RatingComparisonTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataComparisonControlTabControl As WinFlume.ctl_TabControl
    Friend WithEvents DataEntryTab As System.Windows.Forms.TabPage
    Friend WithEvents RatingComparisonTab As System.Windows.Forms.TabPage
    Friend WithEvents MeasuredDataEntryControl As MeasuredDataEntryControl
    Friend WithEvents RatingComparisonControl As RatingComparisonControl
End Class
