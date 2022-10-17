<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalibrationControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalibrationControl))
        Me.HorizontalSplitter = New System.Windows.Forms.SplitContainer()
        Me.BottomProfileControl = New WinFlume.BottomProfileControl()
        Me.VerticalSplitter = New System.Windows.Forms.SplitContainer()
        Me.CalibrationControlTabControl = New WinFlume.ctl_TabControl()
        Me.TableChoicesTab = New System.Windows.Forms.TabPage()
        Me.TableChoicesControl = New WinFlume.TableChoicesControl()
        Me.RatingTableTab = New System.Windows.Forms.TabPage()
        Me.RatingTableControl = New WinFlume.RatingTableControl()
        Me.RatingEquationTableTab = New System.Windows.Forms.TabPage()
        Me.RatingEquationControl = New WinFlume.RatingEquationControl()
        Me.DitchridersTableTab = New System.Windows.Forms.TabPage()
        Me.DitchridersTableControl = New WinFlume.DitchridersTableControl()
        Me.SideBarControl = New WinFlume.SideBarControl()
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HorizontalSplitter.Panel1.SuspendLayout()
        Me.HorizontalSplitter.Panel2.SuspendLayout()
        Me.HorizontalSplitter.SuspendLayout()
        CType(Me.VerticalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VerticalSplitter.Panel1.SuspendLayout()
        Me.VerticalSplitter.Panel2.SuspendLayout()
        Me.VerticalSplitter.SuspendLayout()
        Me.CalibrationControlTabControl.SuspendLayout()
        Me.TableChoicesTab.SuspendLayout()
        Me.RatingTableTab.SuspendLayout()
        Me.RatingEquationTableTab.SuspendLayout()
        Me.DitchridersTableTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'HorizontalSplitter
        '
        resources.ApplyResources(Me.HorizontalSplitter, "HorizontalSplitter")
        Me.HorizontalSplitter.Name = "HorizontalSplitter"
        '
        'HorizontalSplitter.Panel1
        '
        Me.HorizontalSplitter.Panel1.Controls.Add(Me.BottomProfileControl)
        '
        'HorizontalSplitter.Panel2
        '
        Me.HorizontalSplitter.Panel2.Controls.Add(Me.VerticalSplitter)
        '
        'BottomProfileControl
        '
        resources.ApplyResources(Me.BottomProfileControl, "BottomProfileControl")
        Me.BottomProfileControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BottomProfileControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BottomProfileControl.Name = "BottomProfileControl"
        '
        'VerticalSplitter
        '
        resources.ApplyResources(Me.VerticalSplitter, "VerticalSplitter")
        Me.VerticalSplitter.Name = "VerticalSplitter"
        '
        'VerticalSplitter.Panel1
        '
        Me.VerticalSplitter.Panel1.Controls.Add(Me.CalibrationControlTabControl)
        '
        'VerticalSplitter.Panel2
        '
        Me.VerticalSplitter.Panel2.Controls.Add(Me.SideBarControl)
        '
        'CalibrationControlTabControl
        '
        resources.ApplyResources(Me.CalibrationControlTabControl, "CalibrationControlTabControl")
        Me.CalibrationControlTabControl.Controls.Add(Me.TableChoicesTab)
        Me.CalibrationControlTabControl.Controls.Add(Me.RatingTableTab)
        Me.CalibrationControlTabControl.Controls.Add(Me.RatingEquationTableTab)
        Me.CalibrationControlTabControl.Controls.Add(Me.DitchridersTableTab)
        Me.CalibrationControlTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.CalibrationControlTabControl.Name = "CalibrationControlTabControl"
        Me.CalibrationControlTabControl.SelectedIndex = 0
        Me.CalibrationControlTabControl.Value = 0
        '
        'TableChoicesTab
        '
        Me.TableChoicesTab.Controls.Add(Me.TableChoicesControl)
        resources.ApplyResources(Me.TableChoicesTab, "TableChoicesTab")
        Me.TableChoicesTab.Name = "TableChoicesTab"
        Me.TableChoicesTab.UseVisualStyleBackColor = True
        '
        'TableChoicesControl
        '
        resources.ApplyResources(Me.TableChoicesControl, "TableChoicesControl")
        Me.TableChoicesControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TableChoicesControl.Name = "TableChoicesControl"
        '
        'RatingTableTab
        '
        Me.RatingTableTab.Controls.Add(Me.RatingTableControl)
        resources.ApplyResources(Me.RatingTableTab, "RatingTableTab")
        Me.RatingTableTab.Name = "RatingTableTab"
        Me.RatingTableTab.UseVisualStyleBackColor = True
        '
        'RatingTableControl
        '
        resources.ApplyResources(Me.RatingTableControl, "RatingTableControl")
        Me.RatingTableControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RatingTableControl.Name = "RatingTableControl"
        '
        'RatingEquationTableTab
        '
        Me.RatingEquationTableTab.Controls.Add(Me.RatingEquationControl)
        resources.ApplyResources(Me.RatingEquationTableTab, "RatingEquationTableTab")
        Me.RatingEquationTableTab.Name = "RatingEquationTableTab"
        Me.RatingEquationTableTab.UseVisualStyleBackColor = True
        '
        'RatingEquationControl
        '
        resources.ApplyResources(Me.RatingEquationControl, "RatingEquationControl")
        Me.RatingEquationControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RatingEquationControl.K1 = 0!
        Me.RatingEquationControl.K2 = 0!
        Me.RatingEquationControl.Name = "RatingEquationControl"
        Me.RatingEquationControl.RSquared = 0R
        Me.RatingEquationControl.U = 0!
        '
        'DitchridersTableTab
        '
        Me.DitchridersTableTab.Controls.Add(Me.DitchridersTableControl)
        resources.ApplyResources(Me.DitchridersTableTab, "DitchridersTableTab")
        Me.DitchridersTableTab.Name = "DitchridersTableTab"
        Me.DitchridersTableTab.UseVisualStyleBackColor = True
        '
        'DitchridersTableControl
        '
        resources.ApplyResources(Me.DitchridersTableControl, "DitchridersTableControl")
        Me.DitchridersTableControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DitchridersTableControl.Name = "DitchridersTableControl"
        '
        'SideBarControl
        '
        Me.SideBarControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SideBarControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.SideBarControl, "SideBarControl")
        Me.SideBarControl.Name = "SideBarControl"
        '
        'CalibrationControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.HorizontalSplitter)
        Me.Name = "CalibrationControl"
        Me.HorizontalSplitter.Panel1.ResumeLayout(False)
        Me.HorizontalSplitter.Panel2.ResumeLayout(False)
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HorizontalSplitter.ResumeLayout(False)
        Me.VerticalSplitter.Panel1.ResumeLayout(False)
        Me.VerticalSplitter.Panel2.ResumeLayout(False)
        CType(Me.VerticalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VerticalSplitter.ResumeLayout(False)
        Me.CalibrationControlTabControl.ResumeLayout(False)
        Me.TableChoicesTab.ResumeLayout(False)
        Me.RatingTableTab.ResumeLayout(False)
        Me.RatingEquationTableTab.ResumeLayout(False)
        Me.DitchridersTableTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HorizontalSplitter As System.Windows.Forms.SplitContainer
    Friend WithEvents BottomProfileControl As WinFlume.BottomProfileControl
    Friend WithEvents VerticalSplitter As System.Windows.Forms.SplitContainer
    Friend WithEvents CalibrationControlTabControl As WinFlume.ctl_TabControl
    Friend WithEvents SideBarControl As WinFlume.SideBarControl
    Friend WithEvents TableChoicesTab As System.Windows.Forms.TabPage
    Friend WithEvents RatingTableTab As System.Windows.Forms.TabPage
    Friend WithEvents RatingEquationTableTab As System.Windows.Forms.TabPage
    Friend WithEvents DitchridersTableTab As System.Windows.Forms.TabPage
    Friend WithEvents TableChoicesControl As WinFlume.TableChoicesControl
    Friend WithEvents RatingTableControl As WinFlume.RatingTableControl
    Friend WithEvents RatingEquationControl As WinFlume.RatingEquationControl
    Friend WithEvents DitchridersTableControl As WinFlume.DitchridersTableControl

End Class
