<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ControlSectionControl
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
        Me.components = New System.ComponentModel.Container()
        Me.MatchAsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MatchItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrossSectionPanel = New WinFlume.ctl_Panel()
        Me.MatchControlToApproachCheckBox = New WinFlume.ctl_CheckBox()
        Me.ControlCrossSection = New WinFlume.ctl_ComboBox()
        Me.ControlSectionDescription = New WinFlume.ctl_Label()
        Me.MatchAsMenu.SuspendLayout()
        Me.CrossSectionPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MatchAsMenu
        '
        Me.MatchAsMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MatchAsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MatchItem1, Me.MatchItem2, Me.MatchItem3})
        Me.MatchAsMenu.Name = "ContextMenuStrip1"
        Me.MatchAsMenu.Size = New System.Drawing.Size(166, 76)
        '
        'MatchItem1
        '
        Me.MatchItem1.Name = "MatchItem1"
        Me.MatchItem1.Size = New System.Drawing.Size(165, 24)
        Me.MatchItem1.Text = "Match Item 1"
        '
        'MatchItem2
        '
        Me.MatchItem2.Name = "MatchItem2"
        Me.MatchItem2.Size = New System.Drawing.Size(165, 24)
        Me.MatchItem2.Text = "Match Item 2"
        '
        'MatchItem3
        '
        Me.MatchItem3.Name = "MatchItem3"
        Me.MatchItem3.Size = New System.Drawing.Size(165, 24)
        Me.MatchItem3.Text = "Match Item 3"
        '
        'CrossSectionPanel
        '
        Me.CrossSectionPanel.Controls.Add(Me.MatchControlToApproachCheckBox)
        Me.CrossSectionPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CrossSectionPanel.Location = New System.Drawing.Point(0, 26)
        Me.CrossSectionPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.CrossSectionPanel.Name = "CrossSectionPanel"
        Me.CrossSectionPanel.Size = New System.Drawing.Size(466, 218)
        Me.CrossSectionPanel.TabIndex = 2
        '
        'MatchControlToApproachCheckBox
        '
        Me.MatchControlToApproachCheckBox.AccessibleDescription = "Match the Control Section to the Approach Channel and the Sill Height"
        Me.MatchControlToApproachCheckBox.AccessibleName = "Match Control Section to Approach Channel"
        Me.MatchControlToApproachCheckBox.AutoCheck = False
        Me.MatchControlToApproachCheckBox.AutoSize = True
        Me.MatchControlToApproachCheckBox.HandleCheckedChanged = True
        Me.MatchControlToApproachCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MatchControlToApproachCheckBox.Location = New System.Drawing.Point(160, 4)
        Me.MatchControlToApproachCheckBox.Name = "MatchControlToApproachCheckBox"
        Me.MatchControlToApproachCheckBox.Size = New System.Drawing.Size(358, 24)
        Me.MatchControlToApproachCheckBox.TabIndex = 6
        Me.MatchControlToApproachCheckBox.Text = "Match Control Section to Approach Channel"
        Me.MatchControlToApproachCheckBox.UndoEnabled = True
        Me.MatchControlToApproachCheckBox.UseVisualStyleBackColor = True
        Me.MatchControlToApproachCheckBox.Value = False
        '
        'ControlCrossSection
        '
        Me.ControlCrossSection.AccessibleDescription = "Drop down control used to select the Control Section's Cross Section"
        Me.ControlCrossSection.AccessibleName = "Cross Section Selection Control"
        Me.ControlCrossSection.BackColor = System.Drawing.SystemColors.Info
        Me.ControlCrossSection.DefaultValue = 0
        Me.ControlCrossSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ControlCrossSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ControlCrossSection.FormattingEnabled = True
        Me.ControlCrossSection.Location = New System.Drawing.Point(283, 0)
        Me.ControlCrossSection.Name = "ControlCrossSection"
        Me.ControlCrossSection.Size = New System.Drawing.Size(180, 28)
        Me.ControlCrossSection.TabIndex = 1
        Me.ControlCrossSection.UndoEnabled = True
        Me.ControlCrossSection.Value = -1
        '
        'ControlSectionDescription
        '
        Me.ControlSectionDescription.AutoSize = True
        Me.ControlSectionDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ControlSectionDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ControlSectionDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ControlSectionDescription.Location = New System.Drawing.Point(0, 5)
        Me.ControlSectionDescription.Name = "ControlSectionDescription"
        Me.ControlSectionDescription.Size = New System.Drawing.Size(208, 20)
        Me.ControlSectionDescription.TabIndex = 0
        Me.ControlSectionDescription.Text = "Control Section (throat&)"
        Me.ControlSectionDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ControlSectionControl
        '
        Me.AccessibleDescription = "Select and edit the control cross section"
        Me.AccessibleName = "Control Section"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.CrossSectionPanel)
        Me.Controls.Add(Me.ControlCrossSection)
        Me.Controls.Add(Me.ControlSectionDescription)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ControlSectionControl"
        Me.Size = New System.Drawing.Size(466, 248)
        Me.MatchAsMenu.ResumeLayout(False)
        Me.CrossSectionPanel.ResumeLayout(False)
        Me.CrossSectionPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ControlSectionDescription As WinFlume.ctl_Label
    Friend WithEvents ControlCrossSection As WinFlume.ctl_ComboBox
    Friend WithEvents CrossSectionPanel As WinFlume.ctl_Panel
    Friend WithEvents MatchAsMenu As ContextMenuStrip
    Friend WithEvents MatchItem1 As ToolStripMenuItem
    Friend WithEvents MatchItem2 As ToolStripMenuItem
    Friend WithEvents MatchControlToApproachCheckBox As ctl_CheckBox
    Friend WithEvents MatchItem3 As ToolStripMenuItem
End Class
