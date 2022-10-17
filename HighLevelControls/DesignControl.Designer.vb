<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignControl
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
        Me.HorizontalSplitter = New System.Windows.Forms.SplitContainer()
        Me.BottomProfileControl = New WinFlume.BottomProfileControl()
        Me.VerticalSplitter = New System.Windows.Forms.SplitContainer()
        Me.DesignControlTabControl = New WinFlume.ctl_TabControl()
        Me.DesignOptionsTab = New System.Windows.Forms.TabPage()
        Me.DesignOptionsControl = New WinFlume.DesignOptionsControl()
        Me.AlternativeDesignsTab = New System.Windows.Forms.TabPage()
        Me.AlternativeDesignsControl = New WinFlume.AlternativeDesignsControl()
        Me.SideBarControl = New WinFlume.SideBarControl()
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HorizontalSplitter.Panel1.SuspendLayout()
        Me.HorizontalSplitter.Panel2.SuspendLayout()
        Me.HorizontalSplitter.SuspendLayout()
        CType(Me.VerticalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VerticalSplitter.Panel1.SuspendLayout()
        Me.VerticalSplitter.Panel2.SuspendLayout()
        Me.VerticalSplitter.SuspendLayout()
        Me.DesignControlTabControl.SuspendLayout()
        Me.DesignOptionsTab.SuspendLayout()
        Me.AlternativeDesignsTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'HorizontalSplitter
        '
        Me.HorizontalSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HorizontalSplitter.Location = New System.Drawing.Point(0, 0)
        Me.HorizontalSplitter.Name = "HorizontalSplitter"
        Me.HorizontalSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'HorizontalSplitter.Panel1
        '
        Me.HorizontalSplitter.Panel1.Controls.Add(Me.BottomProfileControl)
        Me.HorizontalSplitter.Panel1MinSize = 165
        '
        'HorizontalSplitter.Panel2
        '
        Me.HorizontalSplitter.Panel2.Controls.Add(Me.VerticalSplitter)
        Me.HorizontalSplitter.Panel2MinSize = 150
        Me.HorizontalSplitter.Size = New System.Drawing.Size(768, 454)
        Me.HorizontalSplitter.SplitterDistance = 165
        Me.HorizontalSplitter.TabIndex = 2
        '
        'BottomProfileControl
        '
        Me.BottomProfileControl.AccessibleDescription = "Bottom profile view of the complete flume structure."
        Me.BottomProfileControl.AccessibleName = "Bottom Profile"
        Me.BottomProfileControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BottomProfileControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BottomProfileControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BottomProfileControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.BottomProfileControl.Location = New System.Drawing.Point(0, 0)
        Me.BottomProfileControl.Margin = New System.Windows.Forms.Padding(2)
        Me.BottomProfileControl.Name = "BottomProfileControl"
        Me.BottomProfileControl.Size = New System.Drawing.Size(768, 165)
        Me.BottomProfileControl.TabIndex = 0
        '
        'VerticalSplitter
        '
        Me.VerticalSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VerticalSplitter.Location = New System.Drawing.Point(0, 0)
        Me.VerticalSplitter.Name = "VerticalSplitter"
        '
        'VerticalSplitter.Panel1
        '
        Me.VerticalSplitter.Panel1.Controls.Add(Me.DesignControlTabControl)
        Me.VerticalSplitter.Panel1MinSize = 464
        '
        'VerticalSplitter.Panel2
        '
        Me.VerticalSplitter.Panel2.Controls.Add(Me.SideBarControl)
        Me.VerticalSplitter.Panel2MinSize = 300
        Me.VerticalSplitter.Size = New System.Drawing.Size(768, 285)
        Me.VerticalSplitter.SplitterDistance = 464
        Me.VerticalSplitter.TabIndex = 0
        '
        'DesignControlTabControl
        '
        Me.DesignControlTabControl.AccessibleDescription = "Various tab pages for displaying and editing the design properties."
        Me.DesignControlTabControl.AccessibleName = "Design Control tab pages"
        Me.DesignControlTabControl.Controls.Add(Me.DesignOptionsTab)
        Me.DesignControlTabControl.Controls.Add(Me.AlternativeDesignsTab)
        Me.DesignControlTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DesignControlTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.DesignControlTabControl.Location = New System.Drawing.Point(0, 0)
        Me.DesignControlTabControl.Margin = New System.Windows.Forms.Padding(2)
        Me.DesignControlTabControl.Name = "DesignControlTabControl"
        Me.DesignControlTabControl.SelectedIndex = 0
        Me.DesignControlTabControl.Size = New System.Drawing.Size(464, 285)
        Me.DesignControlTabControl.TabIndex = 0
        Me.DesignControlTabControl.Value = 0
        '
        'DesignOptionsTab
        '
        Me.DesignOptionsTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DesignOptionsTab.Controls.Add(Me.DesignOptionsControl)
        Me.DesignOptionsTab.Location = New System.Drawing.Point(4, 25)
        Me.DesignOptionsTab.Name = "DesignOptionsTab"
        Me.DesignOptionsTab.Size = New System.Drawing.Size(456, 256)
        Me.DesignOptionsTab.TabIndex = 2
        Me.DesignOptionsTab.Text = "Design Options"
        Me.DesignOptionsTab.UseVisualStyleBackColor = True
        '
        'DesignOptionsControl
        '
        Me.DesignOptionsControl.AccessibleDescription = "Set the parameters that define the design evaluation range"
        Me.DesignOptionsControl.AccessibleName = "Design Options"
        Me.DesignOptionsControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DesignOptionsControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DesignOptionsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignOptionsControl.Location = New System.Drawing.Point(0, 0)
        Me.DesignOptionsControl.Margin = New System.Windows.Forms.Padding(2)
        Me.DesignOptionsControl.Name = "DesignOptionsControl"
        Me.DesignOptionsControl.Size = New System.Drawing.Size(456, 256)
        Me.DesignOptionsControl.TabIndex = 0
        '
        'AlternativeDesignsTab
        '
        Me.AlternativeDesignsTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.AlternativeDesignsTab.Controls.Add(Me.AlternativeDesignsControl)
        Me.AlternativeDesignsTab.Location = New System.Drawing.Point(4, 25)
        Me.AlternativeDesignsTab.Name = "AlternativeDesignsTab"
        Me.AlternativeDesignsTab.Size = New System.Drawing.Size(456, 256)
        Me.AlternativeDesignsTab.TabIndex = 3
        Me.AlternativeDesignsTab.Text = "Alternative Designs"
        Me.AlternativeDesignsTab.UseVisualStyleBackColor = True
        '
        'AlternativeDesignsControl
        '
        Me.AlternativeDesignsControl.AccessibleDescription = "Table comparing alternative designs"
        Me.AlternativeDesignsControl.AccessibleName = "Alternative Designs"
        Me.AlternativeDesignsControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.AlternativeDesignsControl.Dialog = Nothing
        Me.AlternativeDesignsControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AlternativeDesignsControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.AlternativeDesignsControl.Location = New System.Drawing.Point(0, 0)
        Me.AlternativeDesignsControl.Margin = New System.Windows.Forms.Padding(2)
        Me.AlternativeDesignsControl.Name = "AlternativeDesignsControl"
        Me.AlternativeDesignsControl.SelectedFlume = Nothing
        Me.AlternativeDesignsControl.SelectedRowIndex = 0
        Me.AlternativeDesignsControl.ShowDesignNotFound = True
        Me.AlternativeDesignsControl.Size = New System.Drawing.Size(456, 256)
        Me.AlternativeDesignsControl.TabIndex = 0
        '
        'SideBarControl
        '
        Me.SideBarControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SideBarControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SideBarControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideBarControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.SideBarControl.Location = New System.Drawing.Point(0, 0)
        Me.SideBarControl.Margin = New System.Windows.Forms.Padding(2)
        Me.SideBarControl.Name = "SideBarControl"
        Me.SideBarControl.Size = New System.Drawing.Size(300, 285)
        Me.SideBarControl.TabIndex = 0
        '
        'DesignControl
        '
        Me.AccessibleName = "Design Control"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.HorizontalSplitter)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DesignControl"
        Me.Size = New System.Drawing.Size(768, 454)
        Me.HorizontalSplitter.Panel1.ResumeLayout(False)
        Me.HorizontalSplitter.Panel2.ResumeLayout(False)
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HorizontalSplitter.ResumeLayout(False)
        Me.VerticalSplitter.Panel1.ResumeLayout(False)
        Me.VerticalSplitter.Panel2.ResumeLayout(False)
        CType(Me.VerticalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VerticalSplitter.ResumeLayout(False)
        Me.DesignControlTabControl.ResumeLayout(False)
        Me.DesignOptionsTab.ResumeLayout(False)
        Me.AlternativeDesignsTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HorizontalSplitter As System.Windows.Forms.SplitContainer
    Friend WithEvents BottomProfileControl As WinFlume.BottomProfileControl
    Friend WithEvents VerticalSplitter As System.Windows.Forms.SplitContainer
    Friend WithEvents DesignControlTabControl As WinFlume.ctl_TabControl
    Friend WithEvents DesignOptionsTab As System.Windows.Forms.TabPage
    Friend WithEvents AlternativeDesignsTab As System.Windows.Forms.TabPage
    Friend WithEvents SideBarControl As WinFlume.SideBarControl
    Friend WithEvents DesignOptionsControl As WinFlume.DesignOptionsControl
    Friend WithEvents AlternativeDesignsControl As WinFlume.AlternativeDesignsControl

End Class
