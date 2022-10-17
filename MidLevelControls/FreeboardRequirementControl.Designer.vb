<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FreeboardRequirementControl
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
        Me.PercentHeadBox = New WinFlume.ctl_GroupBox()
        Me.MinimumPercentage = New WinFlume.ctl_SingleUnits()
        Me.MinimumPercentageLabel = New WinFlume.ctl_Label()
        Me.FreeboardPercentageButton = New WinFlume.ctl_RadioButton()
        Me.AbsoluteDistanceBox = New WinFlume.ctl_GroupBox()
        Me.MinimumDistance = New WinFlume.ctl_SingleUnits()
        Me.MinimumDistanceLabel = New WinFlume.ctl_Label()
        Me.FreeboardDistanceButton = New WinFlume.ctl_RadioButton()
        Me.PercentHeadBox.SuspendLayout()
        Me.AbsoluteDistanceBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'PercentHeadBox
        '
        Me.PercentHeadBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PercentHeadBox.Controls.Add(Me.MinimumPercentage)
        Me.PercentHeadBox.Controls.Add(Me.MinimumPercentageLabel)
        Me.PercentHeadBox.Controls.Add(Me.FreeboardPercentageButton)
        Me.PercentHeadBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PercentHeadBox.Location = New System.Drawing.Point(4, 103)
        Me.PercentHeadBox.Name = "PercentHeadBox"
        Me.PercentHeadBox.Size = New System.Drawing.Size(459, 82)
        Me.PercentHeadBox.TabIndex = 1
        Me.PercentHeadBox.TabStop = False
        Me.PercentHeadBox.Text = "Percent of Upstream Head"
        '
        'MinimumPercentage
        '
        Me.MinimumPercentage.AutoSize = True
        Me.MinimumPercentage.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinimumPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumPercentage.FormatStyle = "0.0###"
        Me.MinimumPercentage.Label = "Single Value"
        Me.MinimumPercentage.Location = New System.Drawing.Point(294, 45)
        Me.MinimumPercentage.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumPercentage.Name = "MinimumPercentage"
        Me.MinimumPercentage.SiMin = -1.401298E-45!
        Me.MinimumPercentage.SiUnits = "%"
        Me.MinimumPercentage.SiValue = 0!
        Me.MinimumPercentage.Size = New System.Drawing.Size(83, 27)
        Me.MinimumPercentage.TabIndex = 2
        '
        'MinimumPercentageLabel
        '
        Me.MinimumPercentageLabel.AutoSize = True
        Me.MinimumPercentageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumPercentageLabel.Location = New System.Drawing.Point(99, 50)
        Me.MinimumPercentageLabel.Name = "MinimumPercentageLabel"
        Me.MinimumPercentageLabel.Size = New System.Drawing.Size(195, 17)
        Me.MinimumPercentageLabel.TabIndex = 1
        Me.MinimumPercentageLabel.Text = "Required Minimum Freeboard"
        Me.MinimumPercentageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FreeboardPercentageButton
        '
        Me.FreeboardPercentageButton.AutoSize = True
        Me.FreeboardPercentageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FreeboardPercentageButton.Label = ""
        Me.FreeboardPercentageButton.Location = New System.Drawing.Point(7, 23)
        Me.FreeboardPercentageButton.Name = "FreeboardPercentageButton"
        Me.FreeboardPercentageButton.RbValue = -1
        Me.FreeboardPercentageButton.Size = New System.Drawing.Size(437, 21)
        Me.FreeboardPercentageButton.TabIndex = 0
        Me.FreeboardPercentageButton.TabStop = True
        Me.FreeboardPercentageButton.Text = "Freeboard requirement is a pe&rcentage of the upstream head, h1"
        Me.FreeboardPercentageButton.UiValue = -1
        Me.FreeboardPercentageButton.UseVisualStyleBackColor = True
        '
        'AbsoluteDistanceBox
        '
        Me.AbsoluteDistanceBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.AbsoluteDistanceBox.Controls.Add(Me.MinimumDistance)
        Me.AbsoluteDistanceBox.Controls.Add(Me.MinimumDistanceLabel)
        Me.AbsoluteDistanceBox.Controls.Add(Me.FreeboardDistanceButton)
        Me.AbsoluteDistanceBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AbsoluteDistanceBox.Location = New System.Drawing.Point(4, 9)
        Me.AbsoluteDistanceBox.Name = "AbsoluteDistanceBox"
        Me.AbsoluteDistanceBox.Size = New System.Drawing.Size(459, 82)
        Me.AbsoluteDistanceBox.TabIndex = 0
        Me.AbsoluteDistanceBox.TabStop = False
        Me.AbsoluteDistanceBox.Text = "Absolute Distance"
        '
        'MinimumDistance
        '
        Me.MinimumDistance.AutoSize = True
        Me.MinimumDistance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MinimumDistance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumDistance.FormatStyle = "0.0###"
        Me.MinimumDistance.Label = "Single Value"
        Me.MinimumDistance.Location = New System.Drawing.Point(294, 45)
        Me.MinimumDistance.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumDistance.Name = "MinimumDistance"
        Me.MinimumDistance.SiMin = -1.401298E-45!
        Me.MinimumDistance.SiUnits = "m"
        Me.MinimumDistance.SiValue = 0!
        Me.MinimumDistance.Size = New System.Drawing.Size(82, 27)
        Me.MinimumDistance.TabIndex = 2
        '
        'MinimumDistanceLabel
        '
        Me.MinimumDistanceLabel.AutoSize = True
        Me.MinimumDistanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumDistanceLabel.Location = New System.Drawing.Point(99, 50)
        Me.MinimumDistanceLabel.Name = "MinimumDistanceLabel"
        Me.MinimumDistanceLabel.Size = New System.Drawing.Size(195, 17)
        Me.MinimumDistanceLabel.TabIndex = 1
        Me.MinimumDistanceLabel.Text = "Required Minimum Freeboard"
        Me.MinimumDistanceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FreeboardDistanceButton
        '
        Me.FreeboardDistanceButton.AutoSize = True
        Me.FreeboardDistanceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FreeboardDistanceButton.Label = ""
        Me.FreeboardDistanceButton.Location = New System.Drawing.Point(7, 23)
        Me.FreeboardDistanceButton.Name = "FreeboardDistanceButton"
        Me.FreeboardDistanceButton.RbValue = -1
        Me.FreeboardDistanceButton.Size = New System.Drawing.Size(409, 21)
        Me.FreeboardDistanceButton.TabIndex = 0
        Me.FreeboardDistanceButton.TabStop = True
        Me.FreeboardDistanceButton.Text = "Freeboard requirement is expressed as an a&bsolute distance"
        Me.FreeboardDistanceButton.UiValue = -1
        Me.FreeboardDistanceButton.UseVisualStyleBackColor = True
        '
        'FreeboardRequirementControl
        '
        Me.AccessibleDescription = "Set the required minimum freeboard"
        Me.AccessibleName = "Freeboard Requirement"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.PercentHeadBox)
        Me.Controls.Add(Me.AbsoluteDistanceBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FreeboardRequirementControl"
        Me.Size = New System.Drawing.Size(466, 248)
        Me.PercentHeadBox.ResumeLayout(False)
        Me.PercentHeadBox.PerformLayout()
        Me.AbsoluteDistanceBox.ResumeLayout(False)
        Me.AbsoluteDistanceBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AbsoluteDistanceBox As WinFlume.ctl_GroupBox
    Friend WithEvents MinimumDistance As WinFlume.ctl_SingleUnits
    Friend WithEvents MinimumDistanceLabel As WinFlume.ctl_Label
    Friend WithEvents FreeboardDistanceButton As WinFlume.ctl_RadioButton
    Friend WithEvents PercentHeadBox As WinFlume.ctl_GroupBox
    Friend WithEvents MinimumPercentage As WinFlume.ctl_SingleUnits
    Friend WithEvents MinimumPercentageLabel As WinFlume.ctl_Label
    Friend WithEvents FreeboardPercentageButton As WinFlume.ctl_RadioButton

End Class
