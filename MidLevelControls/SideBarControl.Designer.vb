<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SideBarControl
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
        Me.DownstreamView = New WinFlume.DownstreamViewControl()
        Me.UpstreamView = New WinFlume.UpstreamViewControl()
        Me.SelectSideBars = New WinFlume.ctl_GroupBox()
        Me.ShowAll = New WinFlume.ctl_RadioButton()
        Me.ShowDesignReview = New WinFlume.ctl_RadioButton()
        Me.ShowEndViews = New WinFlume.ctl_RadioButton()
        Me.DesignReviewPanel = New WinFlume.ctl_Panel()
        Me.DesignReviewText = New System.Windows.Forms.RichTextBox()
        Me.SelectSideBars.SuspendLayout()
        Me.DesignReviewPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DownstreamView
        '
        Me.DownstreamView.AccessibleDescription = "View of the flume from its downstream end"
        Me.DownstreamView.AccessibleName = "Downstream View"
        Me.DownstreamView.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DownstreamView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DownstreamView.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DownstreamView.Location = New System.Drawing.Point(0, 75)
        Me.DownstreamView.Margin = New System.Windows.Forms.Padding(2)
        Me.DownstreamView.Name = "DownstreamView"
        Me.DownstreamView.Size = New System.Drawing.Size(275, 75)
        Me.DownstreamView.TabIndex = 5
        '
        'UpstreamView
        '
        Me.UpstreamView.AccessibleDescription = "View of the flume from its upstream end"
        Me.UpstreamView.AccessibleName = "Upstream View"
        Me.UpstreamView.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UpstreamView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UpstreamView.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.UpstreamView.Location = New System.Drawing.Point(0, 0)
        Me.UpstreamView.Margin = New System.Windows.Forms.Padding(2)
        Me.UpstreamView.Name = "UpstreamView"
        Me.UpstreamView.Size = New System.Drawing.Size(275, 75)
        Me.UpstreamView.TabIndex = 4
        '
        'SelectSideBars
        '
        Me.SelectSideBars.AccessibleDescription = "Selects which views to show in the side bar"
        Me.SelectSideBars.AccessibleName = "Show Views Selection"
        Me.SelectSideBars.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SelectSideBars.Controls.Add(Me.ShowAll)
        Me.SelectSideBars.Controls.Add(Me.ShowDesignReview)
        Me.SelectSideBars.Controls.Add(Me.ShowEndViews)
        Me.SelectSideBars.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.SelectSideBars.Location = New System.Drawing.Point(2, 228)
        Me.SelectSideBars.Name = "SelectSideBars"
        Me.SelectSideBars.Size = New System.Drawing.Size(270, 44)
        Me.SelectSideBars.TabIndex = 3
        Me.SelectSideBars.TabStop = False
        Me.SelectSideBars.Text = "Sho&w"
        '
        'ShowAll
        '
        Me.ShowAll.AutoSize = True
        Me.ShowAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ShowAll.Label = ""
        Me.ShowAll.Location = New System.Drawing.Point(230, 18)
        Me.ShowAll.Name = "ShowAll"
        Me.ShowAll.RbValue = -1
        Me.ShowAll.Size = New System.Drawing.Size(41, 21)
        Me.ShowAll.TabIndex = 2
        Me.ShowAll.Text = "All"
        Me.ShowAll.UiValue = -1
        Me.ShowAll.UseVisualStyleBackColor = True
        '
        'ShowDesignReview
        '
        Me.ShowDesignReview.AutoSize = True
        Me.ShowDesignReview.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ShowDesignReview.Label = ""
        Me.ShowDesignReview.Location = New System.Drawing.Point(100, 18)
        Me.ShowDesignReview.Name = "ShowDesignReview"
        Me.ShowDesignReview.RbValue = -1
        Me.ShowDesignReview.Size = New System.Drawing.Size(119, 21)
        Me.ShowDesignReview.TabIndex = 1
        Me.ShowDesignReview.Text = "Design Review"
        Me.ShowDesignReview.UiValue = -1
        Me.ShowDesignReview.UseVisualStyleBackColor = True
        '
        'ShowEndViews
        '
        Me.ShowEndViews.AutoSize = True
        Me.ShowEndViews.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ShowEndViews.Label = ""
        Me.ShowEndViews.Location = New System.Drawing.Point(4, 18)
        Me.ShowEndViews.Name = "ShowEndViews"
        Me.ShowEndViews.RbValue = -1
        Me.ShowEndViews.Size = New System.Drawing.Size(91, 21)
        Me.ShowEndViews.TabIndex = 0
        Me.ShowEndViews.Text = "End Views"
        Me.ShowEndViews.UiValue = -1
        Me.ShowEndViews.UseVisualStyleBackColor = True
        '
        'DesignReviewPanel
        '
        Me.DesignReviewPanel.Controls.Add(Me.DesignReviewText)
        Me.DesignReviewPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DesignReviewPanel.Location = New System.Drawing.Point(0, 152)
        Me.DesignReviewPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.DesignReviewPanel.Name = "DesignReviewPanel"
        Me.DesignReviewPanel.Size = New System.Drawing.Size(275, 75)
        Me.DesignReviewPanel.TabIndex = 2
        '
        'DesignReviewText
        '
        Me.DesignReviewText.AccessibleDescription = "Short summary of the flume design"
        Me.DesignReviewText.AccessibleName = "Design Reivew"
        Me.DesignReviewText.BackColor = System.Drawing.SystemColors.Info
        Me.DesignReviewText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DesignReviewText.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.DesignReviewText.Location = New System.Drawing.Point(0, 0)
        Me.DesignReviewText.Margin = New System.Windows.Forms.Padding(2)
        Me.DesignReviewText.Name = "DesignReviewText"
        Me.DesignReviewText.ReadOnly = True
        Me.DesignReviewText.Size = New System.Drawing.Size(275, 75)
        Me.DesignReviewText.TabIndex = 0
        Me.DesignReviewText.Text = "Design Review"
        '
        'SideBarControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.DownstreamView)
        Me.Controls.Add(Me.UpstreamView)
        Me.Controls.Add(Me.SelectSideBars)
        Me.Controls.Add(Me.DesignReviewPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SideBarControl"
        Me.Size = New System.Drawing.Size(261, 261)
        Me.SelectSideBars.ResumeLayout(False)
        Me.SelectSideBars.PerformLayout()
        Me.DesignReviewPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DesignReviewPanel As WinFlume.ctl_Panel
    Friend WithEvents SelectSideBars As WinFlume.ctl_GroupBox
    Friend WithEvents ShowAll As WinFlume.ctl_RadioButton
    Friend WithEvents ShowDesignReview As WinFlume.ctl_RadioButton
    Friend WithEvents ShowEndViews As WinFlume.ctl_RadioButton
    Friend WithEvents DesignReviewText As System.Windows.Forms.RichTextBox
    Friend WithEvents UpstreamView As WinFlume.UpstreamViewControl
    Friend WithEvents DownstreamView As WinFlume.DownstreamViewControl

End Class
