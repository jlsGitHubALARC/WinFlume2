<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TailwaterChannelControl
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
        Me.components = New System.ComponentModel.Container()
        Me.MakeIdenticalMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ApproachSectionItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlChannelItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrossSectionPanel = New WinFlume.ctl_Panel()
        Me.MatchTailwaterToApproachCheckBox = New WinFlume.ctl_CheckBox()
        Me.MakeIdenticalToButton = New WinFlume.ctl_Button()
        Me.TailwaterCrossSection = New WinFlume.ctl_ComboBox()
        Me.TailwaterSectionDescription = New WinFlume.ctl_Label()
        Me.MakeIdenticalMenu.SuspendLayout()
        Me.CrossSectionPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MakeIdenticalMenu
        '
        Me.MakeIdenticalMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApproachSectionItem, Me.ControlChannelItem})
        Me.MakeIdenticalMenu.Name = "ContextMenuStrip1"
        Me.MakeIdenticalMenu.Size = New System.Drawing.Size(169, 48)
        '
        'ApproachSectionItem
        '
        Me.ApproachSectionItem.Name = "ApproachSectionItem"
        Me.ApproachSectionItem.Size = New System.Drawing.Size(168, 22)
        Me.ApproachSectionItem.Text = "Approach Section"
        '
        'ControlChannelItem
        '
        Me.ControlChannelItem.Name = "ControlChannelItem"
        Me.ControlChannelItem.Size = New System.Drawing.Size(168, 22)
        Me.ControlChannelItem.Text = "Control Channel"
        '
        'CrossSectionPanel
        '
        Me.CrossSectionPanel.Controls.Add(Me.MatchTailwaterToApproachCheckBox)
        Me.CrossSectionPanel.Controls.Add(Me.MakeIdenticalToButton)
        Me.CrossSectionPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CrossSectionPanel.Location = New System.Drawing.Point(0, 26)
        Me.CrossSectionPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.CrossSectionPanel.Name = "CrossSectionPanel"
        Me.CrossSectionPanel.Size = New System.Drawing.Size(466, 218)
        Me.CrossSectionPanel.TabIndex = 2
        '
        'MatchTailwaterToApproachCheckBox
        '
        Me.MatchTailwaterToApproachCheckBox.AccessibleDescription = "Match the Tailwater Channel to the Approach Channel and the Sill Height"
        Me.MatchTailwaterToApproachCheckBox.AccessibleName = "Match Tailwater Channel to Approach Channel"
        Me.MatchTailwaterToApproachCheckBox.AutoCheck = False
        Me.MatchTailwaterToApproachCheckBox.AutoSize = True
        Me.MatchTailwaterToApproachCheckBox.HandleCheckedChanged = True
        Me.MatchTailwaterToApproachCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MatchTailwaterToApproachCheckBox.Location = New System.Drawing.Point(141, 37)
        Me.MatchTailwaterToApproachCheckBox.Name = "MatchTailwaterToApproachCheckBox"
        Me.MatchTailwaterToApproachCheckBox.Size = New System.Drawing.Size(319, 21)
        Me.MatchTailwaterToApproachCheckBox.TabIndex = 7
        Me.MatchTailwaterToApproachCheckBox.Text = "Match Tailwater Channel to Approach Channel"
        Me.MatchTailwaterToApproachCheckBox.UndoEnabled = True
        Me.MatchTailwaterToApproachCheckBox.UseVisualStyleBackColor = True
        Me.MatchTailwaterToApproachCheckBox.Value = False
        '
        'MakeIdenticalToButton
        '
        Me.MakeIdenticalToButton.AccessibleDescription = "Make the Tailwater Section identical to either the Approach or Control sections."
        Me.MakeIdenticalToButton.AccessibleName = "Make Tailwater Section Identical To"
        Me.MakeIdenticalToButton.AutoSize = True
        Me.MakeIdenticalToButton.BackColor = System.Drawing.SystemColors.Control
        Me.MakeIdenticalToButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MakeIdenticalToButton.Location = New System.Drawing.Point(207, 4)
        Me.MakeIdenticalToButton.Name = "MakeIdenticalToButton"
        Me.MakeIdenticalToButton.Size = New System.Drawing.Size(253, 27)
        Me.MakeIdenticalToButton.TabIndex = 0
        Me.MakeIdenticalToButton.Text = "Make Tailwater Section Identical To..."
        Me.MakeIdenticalToButton.UseVisualStyleBackColor = False
        '
        'TailwaterCrossSection
        '
        Me.TailwaterCrossSection.BackColor = System.Drawing.SystemColors.Info
        Me.TailwaterCrossSection.DefaultValue = 0
        Me.TailwaterCrossSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TailwaterCrossSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TailwaterCrossSection.FormattingEnabled = True
        Me.TailwaterCrossSection.Location = New System.Drawing.Point(312, 0)
        Me.TailwaterCrossSection.Name = "TailwaterCrossSection"
        Me.TailwaterCrossSection.Size = New System.Drawing.Size(150, 24)
        Me.TailwaterCrossSection.TabIndex = 1
        Me.TailwaterCrossSection.UndoEnabled = True
        Me.TailwaterCrossSection.Value = -1
        '
        'TailwaterSectionDescription
        '
        Me.TailwaterSectionDescription.AutoSize = True
        Me.TailwaterSectionDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TailwaterSectionDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TailwaterSectionDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TailwaterSectionDescription.Location = New System.Drawing.Point(0, 5)
        Me.TailwaterSectionDescription.Name = "TailwaterSectionDescription"
        Me.TailwaterSectionDescription.Size = New System.Drawing.Size(418, 17)
        Me.TailwaterSectionDescription.TabIndex = 0
        Me.TailwaterSectionDescription.Text = "Tailwater &Section (downstream from diverging transition)"
        Me.TailwaterSectionDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TailwaterChannelControl
        '
        Me.AccessibleDescription = "Select and edit the tailwater cross section"
        Me.AccessibleName = "Tailwater Channel"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.CrossSectionPanel)
        Me.Controls.Add(Me.TailwaterCrossSection)
        Me.Controls.Add(Me.TailwaterSectionDescription)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "TailwaterChannelControl"
        Me.Size = New System.Drawing.Size(466, 248)
        Me.MakeIdenticalMenu.ResumeLayout(False)
        Me.CrossSectionPanel.ResumeLayout(False)
        Me.CrossSectionPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TailwaterSectionDescription As WinFlume.ctl_Label
    Friend WithEvents TailwaterCrossSection As WinFlume.ctl_ComboBox
    Friend WithEvents CrossSectionPanel As WinFlume.ctl_Panel
    Friend WithEvents MakeIdenticalToButton As ctl_Button
    Friend WithEvents MakeIdenticalMenu As ContextMenuStrip
    Friend WithEvents ApproachSectionItem As ToolStripMenuItem
    Friend WithEvents ControlChannelItem As ToolStripMenuItem
    Friend WithEvents MatchTailwaterToApproachCheckBox As ctl_CheckBox
End Class
