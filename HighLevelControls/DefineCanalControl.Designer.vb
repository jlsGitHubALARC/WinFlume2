<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DefineCanalControl
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
        Me.HorizontalSplitter = New System.Windows.Forms.SplitContainer()
        Me.BottomProfileControl = New WinFlume.BottomProfileControl()
        Me.VerticalSplitter = New System.Windows.Forms.SplitContainer()
        Me.DefineCanalTabControl = New WinFlume.ctl_TabControl()
        Me.ApproachChannelTab = New System.Windows.Forms.TabPage()
        Me.ApproachChannelControl = New WinFlume.ApproachChannelControl()
        Me.TailwaterChannelTab = New System.Windows.Forms.TabPage()
        Me.TailwaterChannelControl = New WinFlume.TailwaterChannelControl()
        Me.DischargeTailwaterTab = New System.Windows.Forms.TabPage()
        Me.DischargeTailwaterControl = New WinFlume.DischargeTailwaterControl()
        Me.FreeboardRequirementTab = New System.Windows.Forms.TabPage()
        Me.FreeboardRequirementControl = New WinFlume.FreeboardRequirementControl()
        Me.SideBarControl = New WinFlume.SideBarControl()
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HorizontalSplitter.Panel1.SuspendLayout()
        Me.HorizontalSplitter.Panel2.SuspendLayout()
        Me.HorizontalSplitter.SuspendLayout()
        CType(Me.VerticalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VerticalSplitter.Panel1.SuspendLayout()
        Me.VerticalSplitter.Panel2.SuspendLayout()
        Me.VerticalSplitter.SuspendLayout()
        Me.DefineCanalTabControl.SuspendLayout()
        Me.ApproachChannelTab.SuspendLayout()
        Me.TailwaterChannelTab.SuspendLayout()
        Me.DischargeTailwaterTab.SuspendLayout()
        Me.FreeboardRequirementTab.SuspendLayout()
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
        Me.HorizontalSplitter.TabIndex = 0
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
        Me.VerticalSplitter.Panel1.Controls.Add(Me.DefineCanalTabControl)
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
        'DefineCanalTabControl
        '
        Me.DefineCanalTabControl.AccessibleDescription = "Various tab pages for displaying and editing the canal properties."
        Me.DefineCanalTabControl.AccessibleName = "Define Canal tab pages"
        Me.DefineCanalTabControl.Controls.Add(Me.ApproachChannelTab)
        Me.DefineCanalTabControl.Controls.Add(Me.TailwaterChannelTab)
        Me.DefineCanalTabControl.Controls.Add(Me.DischargeTailwaterTab)
        Me.DefineCanalTabControl.Controls.Add(Me.FreeboardRequirementTab)
        Me.DefineCanalTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DefineCanalTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.DefineCanalTabControl.Location = New System.Drawing.Point(0, 0)
        Me.DefineCanalTabControl.Margin = New System.Windows.Forms.Padding(2)
        Me.DefineCanalTabControl.Name = "DefineCanalTabControl"
        Me.DefineCanalTabControl.SelectedIndex = 0
        Me.DefineCanalTabControl.Size = New System.Drawing.Size(464, 285)
        Me.DefineCanalTabControl.TabIndex = 0
        Me.DefineCanalTabControl.Value = 0
        '
        'ApproachChannelTab
        '
        Me.ApproachChannelTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ApproachChannelTab.Controls.Add(Me.ApproachChannelControl)
        Me.ApproachChannelTab.Location = New System.Drawing.Point(4, 25)
        Me.ApproachChannelTab.Margin = New System.Windows.Forms.Padding(2)
        Me.ApproachChannelTab.Name = "ApproachChannelTab"
        Me.ApproachChannelTab.Padding = New System.Windows.Forms.Padding(2)
        Me.ApproachChannelTab.Size = New System.Drawing.Size(456, 256)
        Me.ApproachChannelTab.TabIndex = 0
        Me.ApproachChannelTab.Text = "Approach Channel"
        Me.ApproachChannelTab.UseVisualStyleBackColor = True
        '
        'ApproachChannelControl
        '
        Me.ApproachChannelControl.AccessibleDescription = "Select and edit the approach cross section"
        Me.ApproachChannelControl.AccessibleName = "Approach Channel"
        Me.ApproachChannelControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ApproachChannelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ApproachChannelControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ApproachChannelControl.Location = New System.Drawing.Point(2, 2)
        Me.ApproachChannelControl.Margin = New System.Windows.Forms.Padding(2)
        Me.ApproachChannelControl.Name = "ApproachChannelControl"
        Me.ApproachChannelControl.Size = New System.Drawing.Size(452, 252)
        Me.ApproachChannelControl.TabIndex = 0
        '
        'TailwaterChannelTab
        '
        Me.TailwaterChannelTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TailwaterChannelTab.Controls.Add(Me.TailwaterChannelControl)
        Me.TailwaterChannelTab.Location = New System.Drawing.Point(4, 25)
        Me.TailwaterChannelTab.Margin = New System.Windows.Forms.Padding(2)
        Me.TailwaterChannelTab.Name = "TailwaterChannelTab"
        Me.TailwaterChannelTab.Padding = New System.Windows.Forms.Padding(2)
        Me.TailwaterChannelTab.Size = New System.Drawing.Size(456, 256)
        Me.TailwaterChannelTab.TabIndex = 2
        Me.TailwaterChannelTab.Text = "Tailwater Channel"
        Me.TailwaterChannelTab.UseVisualStyleBackColor = True
        '
        'TailwaterChannelControl
        '
        Me.TailwaterChannelControl.AccessibleDescription = "Select and edit the tailwater cross section"
        Me.TailwaterChannelControl.AccessibleName = "Tailwater Channel"
        Me.TailwaterChannelControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TailwaterChannelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TailwaterChannelControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TailwaterChannelControl.Location = New System.Drawing.Point(2, 2)
        Me.TailwaterChannelControl.Margin = New System.Windows.Forms.Padding(2)
        Me.TailwaterChannelControl.Name = "TailwaterChannelControl"
        Me.TailwaterChannelControl.Size = New System.Drawing.Size(452, 252)
        Me.TailwaterChannelControl.TabIndex = 0
        '
        'DischargeTailwaterTab
        '
        Me.DischargeTailwaterTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DischargeTailwaterTab.Controls.Add(Me.DischargeTailwaterControl)
        Me.DischargeTailwaterTab.Location = New System.Drawing.Point(4, 25)
        Me.DischargeTailwaterTab.Name = "DischargeTailwaterTab"
        Me.DischargeTailwaterTab.Size = New System.Drawing.Size(456, 256)
        Me.DischargeTailwaterTab.TabIndex = 3
        Me.DischargeTailwaterTab.Text = "Discharge & Tailwater"
        Me.DischargeTailwaterTab.UseVisualStyleBackColor = True
        '
        'DischargeTailwaterControl
        '
        Me.DischargeTailwaterControl.AccessibleDescription = "Define the range of flume operation and the method for the tailwater calculations" &
    ""
        Me.DischargeTailwaterControl.AccessibleName = "Discharge and Tailwater"
        Me.DischargeTailwaterControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DischargeTailwaterControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DischargeTailwaterControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DischargeTailwaterControl.Location = New System.Drawing.Point(0, 0)
        Me.DischargeTailwaterControl.Margin = New System.Windows.Forms.Padding(2)
        Me.DischargeTailwaterControl.Name = "DischargeTailwaterControl"
        Me.DischargeTailwaterControl.Size = New System.Drawing.Size(456, 256)
        Me.DischargeTailwaterControl.TabIndex = 0
        '
        'FreeboardRequirementTab
        '
        Me.FreeboardRequirementTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FreeboardRequirementTab.Controls.Add(Me.FreeboardRequirementControl)
        Me.FreeboardRequirementTab.Location = New System.Drawing.Point(4, 25)
        Me.FreeboardRequirementTab.Name = "FreeboardRequirementTab"
        Me.FreeboardRequirementTab.Size = New System.Drawing.Size(456, 256)
        Me.FreeboardRequirementTab.TabIndex = 4
        Me.FreeboardRequirementTab.Text = "Freeboard Requirement"
        Me.FreeboardRequirementTab.UseVisualStyleBackColor = True
        '
        'FreeboardRequirementControl
        '
        Me.FreeboardRequirementControl.AccessibleDescription = "Set the required minimum freeboard"
        Me.FreeboardRequirementControl.AccessibleName = "Freeboard Requirement"
        Me.FreeboardRequirementControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FreeboardRequirementControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FreeboardRequirementControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.FreeboardRequirementControl.Location = New System.Drawing.Point(0, 0)
        Me.FreeboardRequirementControl.Margin = New System.Windows.Forms.Padding(2)
        Me.FreeboardRequirementControl.Name = "FreeboardRequirementControl"
        Me.FreeboardRequirementControl.Size = New System.Drawing.Size(456, 256)
        Me.FreeboardRequirementControl.TabIndex = 0
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
        'DefineCanalControl
        '
        Me.AccessibleDescription = "Properties of the canal containing the control flume."
        Me.AccessibleName = "Define Canal"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.HorizontalSplitter)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DefineCanalControl"
        Me.Size = New System.Drawing.Size(768, 454)
        Me.HorizontalSplitter.Panel1.ResumeLayout(False)
        Me.HorizontalSplitter.Panel2.ResumeLayout(False)
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HorizontalSplitter.ResumeLayout(False)
        Me.VerticalSplitter.Panel1.ResumeLayout(False)
        Me.VerticalSplitter.Panel2.ResumeLayout(False)
        CType(Me.VerticalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VerticalSplitter.ResumeLayout(False)
        Me.DefineCanalTabControl.ResumeLayout(False)
        Me.ApproachChannelTab.ResumeLayout(False)
        Me.TailwaterChannelTab.ResumeLayout(False)
        Me.DischargeTailwaterTab.ResumeLayout(False)
        Me.FreeboardRequirementTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HorizontalSplitter As System.Windows.Forms.SplitContainer
    Friend WithEvents VerticalSplitter As System.Windows.Forms.SplitContainer
    Friend WithEvents DefineCanalTabControl As WinFlume.ctl_TabControl
    Friend WithEvents ApproachChannelTab As System.Windows.Forms.TabPage
    Friend WithEvents TailwaterChannelTab As System.Windows.Forms.TabPage
    Friend WithEvents DischargeTailwaterTab As System.Windows.Forms.TabPage
    Friend WithEvents FreeboardRequirementTab As System.Windows.Forms.TabPage
    Friend WithEvents ApproachChannelControl As WinFlume.ApproachChannelControl
    Friend WithEvents TailwaterChannelControl As WinFlume.TailwaterChannelControl
    Friend WithEvents BottomProfileControl As WinFlume.BottomProfileControl
    Friend WithEvents SideBarControl As WinFlume.SideBarControl
    Friend WithEvents FreeboardRequirementControl As WinFlume.FreeboardRequirementControl
    Friend WithEvents DischargeTailwaterControl As WinFlume.DischargeTailwaterControl
End Class
