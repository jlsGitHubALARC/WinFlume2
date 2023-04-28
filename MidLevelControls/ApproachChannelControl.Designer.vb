<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ApproachChannelControl
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
        Me.ApproachCrossSection = New WinFlume.ctl_ComboBox()
        Me.ApproachSectionDescription = New WinFlume.ctl_Label()
        Me.CrossSectionPanel = New WinFlume.ctl_Panel()
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
        Me.ApproachCrossSection.Size = New System.Drawing.Size(150, 28)
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
        Me.ApproachSectionDescription.Size = New System.Drawing.Size(317, 20)
        Me.ApproachSectionDescription.TabIndex = 0
        Me.ApproachSectionDescription.Text = "Approach &Section (at gaging station)"
        Me.ApproachSectionDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CrossSectionPanel
        '
        Me.CrossSectionPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CrossSectionPanel.Location = New System.Drawing.Point(0, 26)
        Me.CrossSectionPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.CrossSectionPanel.Name = "CrossSectionPanel"
        Me.CrossSectionPanel.Size = New System.Drawing.Size(466, 218)
        Me.CrossSectionPanel.TabIndex = 2
        '
        'ApproachChannelControl
        '
        Me.AccessibleDescription = "Select and edit the approach cross section"
        Me.AccessibleName = "Approach Channel"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.ApproachCrossSection)
        Me.Controls.Add(Me.ApproachSectionDescription)
        Me.Controls.Add(Me.CrossSectionPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ApproachChannelControl"
        Me.Size = New System.Drawing.Size(466, 248)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ApproachCrossSection As WinFlume.ctl_ComboBox
    Friend WithEvents CrossSectionPanel As WinFlume.ctl_Panel
    Friend WithEvents ApproachSectionDescription As WinFlume.ctl_Label
End Class
