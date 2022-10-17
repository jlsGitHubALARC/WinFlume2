<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DefineControlControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DefineControlControl))
        Me.HorizontalSplitter = New System.Windows.Forms.SplitContainer()
        Me.BottomProfileControl = New WinFlume.BottomProfileControl()
        Me.VerticalSplitter = New System.Windows.Forms.SplitContainer()
        Me.DefineControlTabControl = New WinFlume.ctl_TabControl()
        Me.FlumeCrestTab = New System.Windows.Forms.TabPage()
        Me.FlumeCrestControl = New WinFlume.FlumeCrestControl()
        Me.HeadMeasurementTab = New System.Windows.Forms.TabPage()
        Me.HeadMeasurementControl = New WinFlume.HeadMeasurementControl()
        Me.ControlSectionTab = New System.Windows.Forms.TabPage()
        Me.ControlSectionControl = New WinFlume.ControlSectionControl()
        Me.DesignReviewTab = New System.Windows.Forms.TabPage()
        Me.FlumeDesignReview = New WinFlume.RtfPage()
        Me.SideBarControl = New WinFlume.SideBarControl()
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HorizontalSplitter.Panel1.SuspendLayout()
        Me.HorizontalSplitter.Panel2.SuspendLayout()
        Me.HorizontalSplitter.SuspendLayout()
        CType(Me.VerticalSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VerticalSplitter.Panel1.SuspendLayout()
        Me.VerticalSplitter.Panel2.SuspendLayout()
        Me.VerticalSplitter.SuspendLayout()
        Me.DefineControlTabControl.SuspendLayout()
        Me.FlumeCrestTab.SuspendLayout()
        Me.HeadMeasurementTab.SuspendLayout()
        Me.ControlSectionTab.SuspendLayout()
        Me.DesignReviewTab.SuspendLayout()
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
        Me.VerticalSplitter.Panel1.Controls.Add(Me.DefineControlTabControl)
        '
        'VerticalSplitter.Panel2
        '
        Me.VerticalSplitter.Panel2.Controls.Add(Me.SideBarControl)
        '
        'DefineControlTabControl
        '
        resources.ApplyResources(Me.DefineControlTabControl, "DefineControlTabControl")
        Me.DefineControlTabControl.Controls.Add(Me.FlumeCrestTab)
        Me.DefineControlTabControl.Controls.Add(Me.HeadMeasurementTab)
        Me.DefineControlTabControl.Controls.Add(Me.ControlSectionTab)
        Me.DefineControlTabControl.Controls.Add(Me.DesignReviewTab)
        Me.DefineControlTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.DefineControlTabControl.Name = "DefineControlTabControl"
        Me.DefineControlTabControl.SelectedIndex = 0
        Me.DefineControlTabControl.Value = 0
        '
        'FlumeCrestTab
        '
        Me.FlumeCrestTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FlumeCrestTab.Controls.Add(Me.FlumeCrestControl)
        resources.ApplyResources(Me.FlumeCrestTab, "FlumeCrestTab")
        Me.FlumeCrestTab.Name = "FlumeCrestTab"
        Me.FlumeCrestTab.UseVisualStyleBackColor = True
        '
        'FlumeCrestControl
        '
        resources.ApplyResources(Me.FlumeCrestControl, "FlumeCrestControl")
        Me.FlumeCrestControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.FlumeCrestControl.Name = "FlumeCrestControl"
        '
        'HeadMeasurementTab
        '
        Me.HeadMeasurementTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HeadMeasurementTab.Controls.Add(Me.HeadMeasurementControl)
        resources.ApplyResources(Me.HeadMeasurementTab, "HeadMeasurementTab")
        Me.HeadMeasurementTab.Name = "HeadMeasurementTab"
        Me.HeadMeasurementTab.UseVisualStyleBackColor = True
        '
        'HeadMeasurementControl
        '
        resources.ApplyResources(Me.HeadMeasurementControl, "HeadMeasurementControl")
        Me.HeadMeasurementControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HeadMeasurementControl.Name = "HeadMeasurementControl"
        '
        'ControlSectionTab
        '
        Me.ControlSectionTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ControlSectionTab.Controls.Add(Me.ControlSectionControl)
        resources.ApplyResources(Me.ControlSectionTab, "ControlSectionTab")
        Me.ControlSectionTab.Name = "ControlSectionTab"
        Me.ControlSectionTab.UseVisualStyleBackColor = True
        '
        'ControlSectionControl
        '
        resources.ApplyResources(Me.ControlSectionControl, "ControlSectionControl")
        Me.ControlSectionControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ControlSectionControl.Name = "ControlSectionControl"
        '
        'DesignReviewTab
        '
        resources.ApplyResources(Me.DesignReviewTab, "DesignReviewTab")
        Me.DesignReviewTab.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DesignReviewTab.Controls.Add(Me.FlumeDesignReview)
        Me.DesignReviewTab.Name = "DesignReviewTab"
        Me.DesignReviewTab.UseVisualStyleBackColor = True
        '
        'FlumeDesignReview
        '
        Me.FlumeDesignReview.BackColor = System.Drawing.SystemColors.Window
        Me.FlumeDesignReview.BottomMargin = 0
        resources.ApplyResources(Me.FlumeDesignReview, "FlumeDesignReview")
        Me.FlumeDesignReview.LeftMargin = 0
        Me.FlumeDesignReview.Name = "FlumeDesignReview"
        Me.FlumeDesignReview.PageHeight = 1100
        Me.FlumeDesignReview.PageNumber = 0
        Me.FlumeDesignReview.PageTitle = ""
        Me.FlumeDesignReview.PageWidth = 630
        Me.FlumeDesignReview.RightMargin = 0
        Me.FlumeDesignReview.TopMargin = 0
        '
        'SideBarControl
        '
        Me.SideBarControl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SideBarControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.SideBarControl, "SideBarControl")
        Me.SideBarControl.Name = "SideBarControl"
        '
        'DefineControlControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.HorizontalSplitter)
        Me.Name = "DefineControlControl"
        Me.HorizontalSplitter.Panel1.ResumeLayout(False)
        Me.HorizontalSplitter.Panel2.ResumeLayout(False)
        CType(Me.HorizontalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HorizontalSplitter.ResumeLayout(False)
        Me.VerticalSplitter.Panel1.ResumeLayout(False)
        Me.VerticalSplitter.Panel2.ResumeLayout(False)
        CType(Me.VerticalSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VerticalSplitter.ResumeLayout(False)
        Me.DefineControlTabControl.ResumeLayout(False)
        Me.FlumeCrestTab.ResumeLayout(False)
        Me.HeadMeasurementTab.ResumeLayout(False)
        Me.ControlSectionTab.ResumeLayout(False)
        Me.DesignReviewTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HorizontalSplitter As System.Windows.Forms.SplitContainer
    Friend WithEvents BottomProfileControl As WinFlume.BottomProfileControl
    Friend WithEvents VerticalSplitter As System.Windows.Forms.SplitContainer
    Friend WithEvents DefineControlTabControl As WinFlume.ctl_TabControl
    Friend WithEvents ControlSectionTab As System.Windows.Forms.TabPage
    Friend WithEvents ControlSectionControl As WinFlume.ControlSectionControl
    Friend WithEvents SideBarControl As WinFlume.SideBarControl
    Friend WithEvents FlumeCrestTab As System.Windows.Forms.TabPage
    Friend WithEvents HeadMeasurementTab As System.Windows.Forms.TabPage
    Friend WithEvents FlumeCrestControl As WinFlume.FlumeCrestControl
    Friend WithEvents HeadMeasurementControl As WinFlume.HeadMeasurementControl
    Friend WithEvents DesignReviewTab As TabPage
    Friend WithEvents FlumeDesignReview As RtfPage
End Class
