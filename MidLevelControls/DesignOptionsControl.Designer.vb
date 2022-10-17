<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignOptionsControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DesignOptionsControl))
        Me.ControlAdjustmentGroup = New WinFlume.ctl_GroupBox()
        Me.AdjustSideContraction = New WinFlume.ctl_RadioButton()
        Me.AdjustInnerSection = New WinFlume.ctl_RadioButton()
        Me.AdjustEntireSection = New WinFlume.ctl_RadioButton()
        Me.AdjustSillHeight = New WinFlume.ctl_RadioButton()
        Me.DesignEvaluationBox = New WinFlume.ctl_GroupBox()
        Me.DesignIncrementUnits = New WinFlume.ctl_ComboBox()
        Me.DesignIncrement = New WinFlume.ctl_Single()
        Me.DesignIncrementLabel = New WinFlume.ctl_Label()
        Me.DesignEvaluationInstructions = New WinFlume.ctl_TextBox()
        Me.ControlAdjustmentGroup.SuspendLayout()
        Me.DesignEvaluationBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ControlAdjustmentGroup
        '
        Me.ControlAdjustmentGroup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ControlAdjustmentGroup.Controls.Add(Me.AdjustSideContraction)
        Me.ControlAdjustmentGroup.Controls.Add(Me.AdjustInnerSection)
        Me.ControlAdjustmentGroup.Controls.Add(Me.AdjustEntireSection)
        Me.ControlAdjustmentGroup.Controls.Add(Me.AdjustSillHeight)
        Me.ControlAdjustmentGroup.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ControlAdjustmentGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ControlAdjustmentGroup.Location = New System.Drawing.Point(0, 166)
        Me.ControlAdjustmentGroup.Name = "ControlAdjustmentGroup"
        Me.ControlAdjustmentGroup.Size = New System.Drawing.Size(466, 82)
        Me.ControlAdjustmentGroup.TabIndex = 1
        Me.ControlAdjustmentGroup.TabStop = False
        Me.ControlAdjustmentGroup.Text = "&Method of Control Section Adjustment"
        '
        'AdjustSideContraction
        '
        Me.AdjustSideContraction.AutoSize = True
        Me.AdjustSideContraction.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdjustSideContraction.Label = ""
        Me.AdjustSideContraction.Location = New System.Drawing.Point(250, 50)
        Me.AdjustSideContraction.Name = "AdjustSideContraction"
        Me.AdjustSideContraction.RbValue = -1
        Me.AdjustSideContraction.Size = New System.Drawing.Size(163, 21)
        Me.AdjustSideContraction.TabIndex = 3
        Me.AdjustSideContraction.Text = "Vary Side Contraction"
        Me.AdjustSideContraction.UiValue = -1
        Me.AdjustSideContraction.UseVisualStyleBackColor = True
        '
        'AdjustInnerSection
        '
        Me.AdjustInnerSection.AutoSize = True
        Me.AdjustInnerSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdjustInnerSection.Label = ""
        Me.AdjustInnerSection.Location = New System.Drawing.Point(250, 25)
        Me.AdjustInnerSection.Name = "AdjustInnerSection"
        Me.AdjustInnerSection.RbValue = -1
        Me.AdjustInnerSection.Size = New System.Drawing.Size(208, 21)
        Me.AdjustInnerSection.TabIndex = 2
        Me.AdjustInnerSection.Text = "Raise or Lower Inner Section"
        Me.AdjustInnerSection.UiValue = -1
        Me.AdjustInnerSection.UseVisualStyleBackColor = True
        '
        'AdjustEntireSection
        '
        Me.AdjustEntireSection.AutoSize = True
        Me.AdjustEntireSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdjustEntireSection.Label = ""
        Me.AdjustEntireSection.Location = New System.Drawing.Point(15, 50)
        Me.AdjustEntireSection.Name = "AdjustEntireSection"
        Me.AdjustEntireSection.RbValue = -1
        Me.AdjustEntireSection.Size = New System.Drawing.Size(213, 21)
        Me.AdjustEntireSection.TabIndex = 1
        Me.AdjustEntireSection.Text = "Raise or Lower Entire Section"
        Me.AdjustEntireSection.UiValue = -1
        Me.AdjustEntireSection.UseVisualStyleBackColor = True
        '
        'AdjustSillHeight
        '
        Me.AdjustSillHeight.AutoSize = True
        Me.AdjustSillHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdjustSillHeight.Label = ""
        Me.AdjustSillHeight.Location = New System.Drawing.Point(15, 25)
        Me.AdjustSillHeight.Name = "AdjustSillHeight"
        Me.AdjustSillHeight.RbValue = -1
        Me.AdjustSillHeight.Size = New System.Drawing.Size(204, 21)
        Me.AdjustSillHeight.TabIndex = 0
        Me.AdjustSillHeight.Text = "Raise or Lower Height of Sill"
        Me.AdjustSillHeight.UiValue = -1
        Me.AdjustSillHeight.UseVisualStyleBackColor = True
        '
        'DesignEvaluationBox
        '
        Me.DesignEvaluationBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DesignEvaluationBox.Controls.Add(Me.DesignIncrementUnits)
        Me.DesignEvaluationBox.Controls.Add(Me.DesignIncrement)
        Me.DesignEvaluationBox.Controls.Add(Me.DesignIncrementLabel)
        Me.DesignEvaluationBox.Controls.Add(Me.DesignEvaluationInstructions)
        Me.DesignEvaluationBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DesignEvaluationBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignEvaluationBox.Location = New System.Drawing.Point(0, 0)
        Me.DesignEvaluationBox.Name = "DesignEvaluationBox"
        Me.DesignEvaluationBox.Size = New System.Drawing.Size(466, 248)
        Me.DesignEvaluationBox.TabIndex = 0
        Me.DesignEvaluationBox.TabStop = False
        Me.DesignEvaluationBox.Text = "&Evalutate Alternative Designs"
        '
        'DesignIncrementUnits
        '
        Me.DesignIncrementUnits.BackColor = System.Drawing.SystemColors.Window
        Me.DesignIncrementUnits.DefaultValue = 0
        Me.DesignIncrementUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DesignIncrementUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignIncrementUnits.FormattingEnabled = True
        Me.DesignIncrementUnits.Location = New System.Drawing.Point(310, 120)
        Me.DesignIncrementUnits.Name = "DesignIncrementUnits"
        Me.DesignIncrementUnits.Size = New System.Drawing.Size(121, 24)
        Me.DesignIncrementUnits.TabIndex = 3
        Me.DesignIncrementUnits.UndoEnabled = True
        Me.DesignIncrementUnits.Value = -1
        '
        'DesignIncrement
        '
        Me.DesignIncrement.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignIncrement.FormatStyle = "0.0###"
        Me.DesignIncrement.IsReadOnly = False
        Me.DesignIncrement.Label = "Single Value"
        Me.DesignIncrement.Location = New System.Drawing.Point(250, 120)
        Me.DesignIncrement.Margin = New System.Windows.Forms.Padding(2)
        Me.DesignIncrement.Name = "DesignIncrement"
        Me.DesignIncrement.ReadOnlyMsgBox = Nothing
        Me.DesignIncrement.SiDefaultValue = 0!
        Me.DesignIncrement.SiMin = -1.401298E-45!
        Me.DesignIncrement.SiValue = 0!
        Me.DesignIncrement.Size = New System.Drawing.Size(59, 27)
        Me.DesignIncrement.TabIndex = 2
        Me.DesignIncrement.UiValue = 0!
        Me.DesignIncrement.UndoEnabled = True
        '
        'DesignIncrementLabel
        '
        Me.DesignIncrementLabel.AutoSize = True
        Me.DesignIncrementLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignIncrementLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DesignIncrementLabel.Location = New System.Drawing.Point(60, 123)
        Me.DesignIncrementLabel.Name = "DesignIncrementLabel"
        Me.DesignIncrementLabel.Size = New System.Drawing.Size(188, 17)
        Me.DesignIncrementLabel.TabIndex = 1
        Me.DesignIncrementLabel.Text = "Design Evaluation &Increment"
        '
        'DesignEvaluationInstructions
        '
        Me.DesignEvaluationInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.DesignEvaluationInstructions.Dock = System.Windows.Forms.DockStyle.Top
        Me.DesignEvaluationInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignEvaluationInstructions.Label = ""
        Me.DesignEvaluationInstructions.Location = New System.Drawing.Point(3, 19)
        Me.DesignEvaluationInstructions.Multiline = True
        Me.DesignEvaluationInstructions.Name = "DesignEvaluationInstructions"
        Me.DesignEvaluationInstructions.ReadOnly = True
        Me.DesignEvaluationInstructions.Size = New System.Drawing.Size(460, 92)
        Me.DesignEvaluationInstructions.TabIndex = 0
        Me.DesignEvaluationInstructions.Tag = ""
        Me.DesignEvaluationInstructions.Text = resources.GetString("DesignEvaluationInstructions.Text")
        Me.DesignEvaluationInstructions.Value = resources.GetString("DesignEvaluationInstructions.Value")
        '
        'DesignOptionsControl
        '
        Me.AccessibleDescription = "Set the parameters that define the design evaluation range"
        Me.AccessibleName = "Design Options"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.ControlAdjustmentGroup)
        Me.Controls.Add(Me.DesignEvaluationBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "DesignOptionsControl"
        Me.Size = New System.Drawing.Size(466, 248)
        Me.ControlAdjustmentGroup.ResumeLayout(False)
        Me.ControlAdjustmentGroup.PerformLayout()
        Me.DesignEvaluationBox.ResumeLayout(False)
        Me.DesignEvaluationBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DesignEvaluationBox As WinFlume.ctl_GroupBox
    Friend WithEvents DesignEvaluationInstructions As WinFlume.ctl_TextBox
    Friend WithEvents ControlAdjustmentGroup As WinFlume.ctl_GroupBox
    Friend WithEvents AdjustEntireSection As WinFlume.ctl_RadioButton
    Friend WithEvents AdjustSillHeight As WinFlume.ctl_RadioButton
    Friend WithEvents DesignIncrementLabel As WinFlume.ctl_Label
    Friend WithEvents AdjustSideContraction As WinFlume.ctl_RadioButton
    Friend WithEvents AdjustInnerSection As WinFlume.ctl_RadioButton
    Friend WithEvents DesignIncrementUnits As WinFlume.ctl_ComboBox
    Friend WithEvents DesignIncrement As WinFlume.ctl_Single

End Class
