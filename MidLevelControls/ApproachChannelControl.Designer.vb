<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApproachChannelControl
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
        Me.ApproachCrossSection = New WinFlume.ctl_ComboBox()
        Me.ApproachSectionDescription = New WinFlume.ctl_Label()
        Me.CrossSectionPanel = New WinFlume.ctl_Panel()
        Me.ControlMatchedToApproachCheckBox = New WinFlume.ctl_CheckBox()
        Me.CrossSectionPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ApproachCrossSection
        '
        Me.ApproachCrossSection.BackColor = System.Drawing.SystemColors.Info
        Me.ApproachCrossSection.DefaultValue = 0
        Me.ApproachCrossSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ApproachCrossSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ApproachCrossSection.FormattingEnabled = True
        Me.ApproachCrossSection.Location = New System.Drawing.Point(312, 0)
        Me.ApproachCrossSection.Name = "ApproachCrossSection"
        Me.ApproachCrossSection.Size = New System.Drawing.Size(150, 24)
        Me.ApproachCrossSection.TabIndex = 1
        Me.ApproachCrossSection.UndoEnabled = True
        Me.ApproachCrossSection.Value = -1
        '
        'ApproachSectionDescription
        '
        Me.ApproachSectionDescription.AutoSize = True
        Me.ApproachSectionDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ApproachSectionDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ApproachSectionDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ApproachSectionDescription.Location = New System.Drawing.Point(0, 5)
        Me.ApproachSectionDescription.Name = "ApproachSectionDescription"
        Me.ApproachSectionDescription.Size = New System.Drawing.Size(275, 17)
        Me.ApproachSectionDescription.TabIndex = 0
        Me.ApproachSectionDescription.Text = "Approach &Section (at gaging station)"
        Me.ApproachSectionDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CrossSectionPanel
        '
        Me.CrossSectionPanel.Controls.Add(Me.ControlMatchedToApproachCheckBox)
        Me.CrossSectionPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CrossSectionPanel.Location = New System.Drawing.Point(0, 26)
        Me.CrossSectionPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.CrossSectionPanel.Name = "CrossSectionPanel"
        Me.CrossSectionPanel.Size = New System.Drawing.Size(466, 218)
        Me.CrossSectionPanel.TabIndex = 2
        '
        'ControlMatchedToApproachCheckBox
        '
        Me.ControlMatchedToApproachCheckBox.AccessibleDescription = "Match the Control Section to the Approach Channel and the Sill Height"
        Me.ControlMatchedToApproachCheckBox.AccessibleName = "Match Control Section to Approach Channel"
        Me.ControlMatchedToApproachCheckBox.HandleCheckedChanged = True
        Me.ControlMatchedToApproachCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ControlMatchedToApproachCheckBox.Location = New System.Drawing.Point(159, 4)
        Me.ControlMatchedToApproachCheckBox.Name = "ControlMatchedToApproachCheckBox"
        Me.ControlMatchedToApproachCheckBox.Size = New System.Drawing.Size(303, 45)
        Me.ControlMatchedToApproachCheckBox.TabIndex = 4
        Me.ControlMatchedToApproachCheckBox.Text = "Match Control Section to Approach Channel Uncheck to select other shapes."
        Me.ControlMatchedToApproachCheckBox.UndoEnabled = True
        Me.ControlMatchedToApproachCheckBox.UseVisualStyleBackColor = True
        Me.ControlMatchedToApproachCheckBox.Value = False
        '
        'ApproachChannelControl
        '
        Me.AccessibleDescription = "Select and edit the approach cross section"
        Me.AccessibleName = "Approach Channel"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.ApproachCrossSection)
        Me.Controls.Add(Me.ApproachSectionDescription)
        Me.Controls.Add(Me.CrossSectionPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ApproachChannelControl"
        Me.Size = New System.Drawing.Size(466, 248)
        Me.CrossSectionPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ApproachCrossSection As WinFlume.ctl_ComboBox
    Friend WithEvents CrossSectionPanel As WinFlume.ctl_Panel
    Friend WithEvents ApproachSectionDescription As WinFlume.ctl_Label
    Friend WithEvents ControlMatchedToApproachCheckBox As ctl_CheckBox
End Class
