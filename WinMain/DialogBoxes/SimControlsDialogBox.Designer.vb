<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimControlsDialogBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.SurfaceShapeFactorsBox = New DataStore.ctl_GroupBox
        Me.ThetaControl = New DataStore.ctl_DoubleUpDownParameter
        Me.ThetaLabel = New DataStore.ctl_Label
        Me.PhiAZLControl = New DataStore.ctl_DoubleUpDownParameter
        Me.PhiAZLLabel = New DataStore.ctl_Label
        Me.PhiAYLControl = New DataStore.ctl_DoubleUpDownParameter
        Me.PhiAYLLabel = New DataStore.ctl_Label
        Me.OkSimControls = New DataStore.ctl_Button
        Me.CancelSimControls = New DataStore.ctl_Button
        Me.SurfaceShapeFactorsBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'SurfaceShapeFactorsBox
        '
        Me.SurfaceShapeFactorsBox.Controls.Add(Me.ThetaControl)
        Me.SurfaceShapeFactorsBox.Controls.Add(Me.ThetaLabel)
        Me.SurfaceShapeFactorsBox.Controls.Add(Me.PhiAZLControl)
        Me.SurfaceShapeFactorsBox.Controls.Add(Me.PhiAZLLabel)
        Me.SurfaceShapeFactorsBox.Controls.Add(Me.PhiAYLControl)
        Me.SurfaceShapeFactorsBox.Controls.Add(Me.PhiAYLLabel)
        Me.SurfaceShapeFactorsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurfaceShapeFactorsBox.Location = New System.Drawing.Point(13, 13)
        Me.SurfaceShapeFactorsBox.Name = "SurfaceShapeFactorsBox"
        Me.SurfaceShapeFactorsBox.Size = New System.Drawing.Size(257, 120)
        Me.SurfaceShapeFactorsBox.TabIndex = 0
        Me.SurfaceShapeFactorsBox.TabStop = False
        Me.SurfaceShapeFactorsBox.Text = "Surface Shape Factors"
        '
        'ThetaControl
        '
        Me.ThetaControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ThetaControl.DialogMode = True
        Me.ThetaControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThetaControl.IsCalculated = False
        Me.ThetaControl.IsInteger = False
        Me.ThetaControl.Location = New System.Drawing.Point(84, 85)
        Me.ThetaControl.Margin = New System.Windows.Forms.Padding(4)
        Me.ThetaControl.Name = "ThetaControl"
        Me.ThetaControl.Size = New System.Drawing.Size(100, 24)
        Me.ThetaControl.TabIndex = 5
        Me.ThetaControl.ToBeCalculated = True
        Me.ThetaControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ThetaControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ThetaControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        '
        'ThetaLabel
        '
        Me.ThetaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThetaLabel.Location = New System.Drawing.Point(7, 85)
        Me.ThetaLabel.Name = "ThetaLabel"
        Me.ThetaLabel.Size = New System.Drawing.Size(70, 24)
        Me.ThetaLabel.TabIndex = 4
        Me.ThetaLabel.Text = "Theta"
        Me.ThetaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PhiAZLControl
        '
        Me.PhiAZLControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.PhiAZLControl.DialogMode = True
        Me.PhiAZLControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PhiAZLControl.IsCalculated = False
        Me.PhiAZLControl.IsInteger = False
        Me.PhiAZLControl.Location = New System.Drawing.Point(84, 55)
        Me.PhiAZLControl.Margin = New System.Windows.Forms.Padding(4)
        Me.PhiAZLControl.Name = "PhiAZLControl"
        Me.PhiAZLControl.Size = New System.Drawing.Size(100, 24)
        Me.PhiAZLControl.TabIndex = 3
        Me.PhiAZLControl.ToBeCalculated = True
        Me.PhiAZLControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.PhiAZLControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.PhiAZLControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        '
        'PhiAZLLabel
        '
        Me.PhiAZLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PhiAZLLabel.Location = New System.Drawing.Point(7, 55)
        Me.PhiAZLLabel.Name = "PhiAZLLabel"
        Me.PhiAZLLabel.Size = New System.Drawing.Size(70, 24)
        Me.PhiAZLLabel.TabIndex = 2
        Me.PhiAZLLabel.Text = "PhiAZL"
        Me.PhiAZLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PhiAYLControl
        '
        Me.PhiAYLControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.PhiAYLControl.DialogMode = True
        Me.PhiAYLControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PhiAYLControl.IsCalculated = False
        Me.PhiAYLControl.IsInteger = False
        Me.PhiAYLControl.Location = New System.Drawing.Point(84, 25)
        Me.PhiAYLControl.Margin = New System.Windows.Forms.Padding(4)
        Me.PhiAYLControl.Name = "PhiAYLControl"
        Me.PhiAYLControl.Size = New System.Drawing.Size(100, 24)
        Me.PhiAYLControl.TabIndex = 1
        Me.PhiAYLControl.ToBeCalculated = True
        Me.PhiAYLControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.PhiAYLControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.PhiAYLControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        '
        'PhiAYLLabel
        '
        Me.PhiAYLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PhiAYLLabel.Location = New System.Drawing.Point(7, 25)
        Me.PhiAYLLabel.Name = "PhiAYLLabel"
        Me.PhiAYLLabel.Size = New System.Drawing.Size(70, 24)
        Me.PhiAYLLabel.TabIndex = 0
        Me.PhiAYLLabel.Text = "PhiAYL"
        Me.PhiAYLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OkSimControls
        '
        Me.OkSimControls.AccessibleDescription = "Accepts new simulation contraols values."
        Me.OkSimControls.AccessibleName = "OK Button"
        Me.OkSimControls.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OkSimControls.Enabled = False
        Me.OkSimControls.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkSimControls.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OkSimControls.Location = New System.Drawing.Point(13, 139)
        Me.OkSimControls.Name = "OkSimControls"
        Me.OkSimControls.Size = New System.Drawing.Size(80, 24)
        Me.OkSimControls.TabIndex = 10
        Me.OkSimControls.Text = "&Ok"
        Me.OkSimControls.UseVisualStyleBackColor = False
        '
        'CancelSimControls
        '
        Me.CancelSimControls.AccessibleDescription = "Rejects the Simulation Control changes."
        Me.CancelSimControls.AccessibleName = "Cancel Button"
        Me.CancelSimControls.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelSimControls.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelSimControls.Location = New System.Drawing.Point(190, 139)
        Me.CancelSimControls.Name = "CancelSimControls"
        Me.CancelSimControls.Size = New System.Drawing.Size(80, 24)
        Me.CancelSimControls.TabIndex = 11
        Me.CancelSimControls.Text = "&Cancel"
        '
        'SimControlsDialogBox
        '
        Me.AccessibleDescription = "Allows setting of select simulation controls used during a run."
        Me.AccessibleName = "Simulation Controls"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 172)
        Me.Controls.Add(Me.OkSimControls)
        Me.Controls.Add(Me.CancelSimControls)
        Me.Controls.Add(Me.SurfaceShapeFactorsBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SimControlsDialogBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Simulation Controls"
        Me.SurfaceShapeFactorsBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SurfaceShapeFactorsBox As DataStore.ctl_GroupBox
    Friend WithEvents PhiAYLLabel As DataStore.ctl_Label
    Friend WithEvents ThetaControl As DataStore.ctl_DoubleUpDownParameter
    Friend WithEvents ThetaLabel As DataStore.ctl_Label
    Friend WithEvents PhiAZLControl As DataStore.ctl_DoubleUpDownParameter
    Friend WithEvents PhiAZLLabel As DataStore.ctl_Label
    Friend WithEvents PhiAYLControl As DataStore.ctl_DoubleUpDownParameter
    Friend WithEvents OkSimControls As DataStore.ctl_Button
    Friend WithEvents CancelSimControls As DataStore.ctl_Button
End Class
