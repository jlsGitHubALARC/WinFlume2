<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StationMeasurements
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
        Me.components = New System.ComponentModel.Container
        Me.AdvanceRecessionBox = New DataStore.ctl_GroupBox
        Me.IncludeRecession = New DataStore.ctl_CheckParameter
        Me.RecessionTimes = New DataStore.ctl_DataTableParameter
        Me.AdvanceTimes = New DataStore.ctl_DataTableParameter
        Me.SurfaceFlowBox = New DataStore.ctl_GroupBox
        Me.EditLocationButton = New DataStore.ctl_Button
        Me.FlowDepths = New DataStore.ctl_DataTableParameter
        Me.WaterFlowActionControl = New System.Windows.Forms.ComboBox
        Me.Ok_Button = New DataStore.ctl_Button
        Me.Cancel_Button = New DataStore.ctl_Button
        Me.AdvRecInstructions = New DataStore.ctl_Label
        Me.WaterFlowInstructions = New DataStore.ctl_Label
        Me.Apply_Button = New DataStore.ctl_Button
        Me.AdvanceRecessionBox.SuspendLayout()
        CType(Me.RecessionTimes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvanceTimes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SurfaceFlowBox.SuspendLayout()
        CType(Me.FlowDepths, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AdvanceRecessionBox
        '
        Me.AdvanceRecessionBox.Controls.Add(Me.IncludeRecession)
        Me.AdvanceRecessionBox.Controls.Add(Me.RecessionTimes)
        Me.AdvanceRecessionBox.Controls.Add(Me.AdvanceTimes)
        Me.AdvanceRecessionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvanceRecessionBox.Location = New System.Drawing.Point(10, 10)
        Me.AdvanceRecessionBox.Name = "AdvanceRecessionBox"
        Me.AdvanceRecessionBox.Size = New System.Drawing.Size(348, 432)
        Me.AdvanceRecessionBox.TabIndex = 0
        Me.AdvanceRecessionBox.TabStop = False
        Me.AdvanceRecessionBox.Text = "Advance / Recession Times"
        '
        'IncludeRecession
        '
        Me.IncludeRecession.Checked = True
        Me.IncludeRecession.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IncludeRecession.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IncludeRecession.Location = New System.Drawing.Point(174, 22)
        Me.IncludeRecession.Name = "IncludeRecession"
        Me.IncludeRecession.Size = New System.Drawing.Size(160, 23)
        Me.IncludeRecession.TabIndex = 2
        Me.IncludeRecession.Text = "Include Recession"
        Me.IncludeRecession.UseVisualStyleBackColor = True
        '
        'RecessionTimes
        '
        Me.RecessionTimes.AllRowsFixed = False
        Me.RecessionTimes.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.RecessionTimes.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.RecessionTimes.CaptionText = "Recession"
        Me.RecessionTimes.ColumnWidthRatios = Nothing
        Me.RecessionTimes.DataMember = ""
        Me.RecessionTimes.EnableSaveActions = False
        Me.RecessionTimes.FirstColumnIncreases = True
        Me.RecessionTimes.FirstColumnMaximum = 1.7976931348623157E+308
        Me.RecessionTimes.FirstColumnMinimum = 0
        Me.RecessionTimes.FirstRowFixed = True
        Me.RecessionTimes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecessionTimes.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.RecessionTimes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.RecessionTimes.Location = New System.Drawing.Point(174, 44)
        Me.RecessionTimes.MaxRows = 100
        Me.RecessionTimes.MinRows = 0
        Me.RecessionTimes.Name = "RecessionTimes"
        Me.RecessionTimes.SecondColumnIncreases = False
        Me.RecessionTimes.SecondColumnMaximum = 1.7976931348623157E+308
        Me.RecessionTimes.SecondColumnMinimum = 0
        Me.RecessionTimes.Size = New System.Drawing.Size(160, 378)
        Me.RecessionTimes.TabIndex = 1
        Me.RecessionTimes.TableReadonly = False
        '
        'AdvanceTimes
        '
        Me.AdvanceTimes.AllRowsFixed = False
        Me.AdvanceTimes.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.AdvanceTimes.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.AdvanceTimes.CaptionText = "Advance"
        Me.AdvanceTimes.ColumnWidthRatios = Nothing
        Me.AdvanceTimes.DataMember = ""
        Me.AdvanceTimes.EnableSaveActions = False
        Me.AdvanceTimes.FirstColumnIncreases = True
        Me.AdvanceTimes.FirstColumnMaximum = 1.7976931348623157E+308
        Me.AdvanceTimes.FirstColumnMinimum = 0
        Me.AdvanceTimes.FirstRowFixed = True
        Me.AdvanceTimes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvanceTimes.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.AdvanceTimes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.AdvanceTimes.Location = New System.Drawing.Point(7, 44)
        Me.AdvanceTimes.MaxRows = 100
        Me.AdvanceTimes.MinRows = 0
        Me.AdvanceTimes.Name = "AdvanceTimes"
        Me.AdvanceTimes.SecondColumnIncreases = False
        Me.AdvanceTimes.SecondColumnMaximum = 1.7976931348623157E+308
        Me.AdvanceTimes.SecondColumnMinimum = 0
        Me.AdvanceTimes.Size = New System.Drawing.Size(160, 378)
        Me.AdvanceTimes.TabIndex = 0
        Me.AdvanceTimes.TableReadonly = False
        '
        'SurfaceFlowBox
        '
        Me.SurfaceFlowBox.Controls.Add(Me.EditLocationButton)
        Me.SurfaceFlowBox.Controls.Add(Me.FlowDepths)
        Me.SurfaceFlowBox.Controls.Add(Me.WaterFlowActionControl)
        Me.SurfaceFlowBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurfaceFlowBox.Location = New System.Drawing.Point(364, 10)
        Me.SurfaceFlowBox.Name = "SurfaceFlowBox"
        Me.SurfaceFlowBox.Size = New System.Drawing.Size(290, 432)
        Me.SurfaceFlowBox.TabIndex = 1
        Me.SurfaceFlowBox.TabStop = False
        Me.SurfaceFlowBox.Text = "Water Flow Depths"
        '
        'EditLocationButton
        '
        Me.EditLocationButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditLocationButton.Location = New System.Drawing.Point(12, 56)
        Me.EditLocationButton.Name = "EditLocationButton"
        Me.EditLocationButton.Size = New System.Drawing.Size(265, 23)
        Me.EditLocationButton.TabIndex = 2
        Me.EditLocationButton.Text = "Edit Location of this Table"
        Me.EditLocationButton.UseVisualStyleBackColor = True
        '
        'FlowDepths
        '
        Me.FlowDepths.AllRowsFixed = False
        Me.FlowDepths.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.FlowDepths.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.FlowDepths.CaptionText = "Flow Depths"
        Me.FlowDepths.ColumnWidthRatios = Nothing
        Me.FlowDepths.DataMember = ""
        Me.FlowDepths.EnableSaveActions = False
        Me.FlowDepths.FirstColumnIncreases = True
        Me.FlowDepths.FirstColumnMaximum = 1.7976931348623157E+308
        Me.FlowDepths.FirstColumnMinimum = 0
        Me.FlowDepths.FirstRowFixed = False
        Me.FlowDepths.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowDepths.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.FlowDepths.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.FlowDepths.Location = New System.Drawing.Point(12, 85)
        Me.FlowDepths.MaxRows = 250
        Me.FlowDepths.MinRows = 0
        Me.FlowDepths.Name = "FlowDepths"
        Me.FlowDepths.SecondColumnIncreases = False
        Me.FlowDepths.SecondColumnMaximum = 1.7976931348623157E+308
        Me.FlowDepths.SecondColumnMinimum = 0
        Me.FlowDepths.Size = New System.Drawing.Size(265, 337)
        Me.FlowDepths.TabIndex = 3
        Me.FlowDepths.TableReadonly = False
        '
        'WaterFlowActionControl
        '
        Me.WaterFlowActionControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WaterFlowActionControl.FormattingEnabled = True
        Me.WaterFlowActionControl.Items.AddRange(New Object() {"Select Action -->"})
        Me.WaterFlowActionControl.Location = New System.Drawing.Point(12, 24)
        Me.WaterFlowActionControl.Name = "WaterFlowActionControl"
        Me.WaterFlowActionControl.Size = New System.Drawing.Size(265, 24)
        Me.WaterFlowActionControl.TabIndex = 0
        '
        'Ok_Button
        '
        Me.Ok_Button.BackColor = System.Drawing.SystemColors.Control
        Me.Ok_Button.Location = New System.Drawing.Point(364, 495)
        Me.Ok_Button.Name = "Ok_Button"
        Me.Ok_Button.Size = New System.Drawing.Size(75, 23)
        Me.Ok_Button.TabIndex = 6
        Me.Ok_Button.Text = "Ok"
        Me.Ok_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(579, 495)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.TabIndex = 8
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'AdvRecInstructions
        '
        Me.AdvRecInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.AdvRecInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdvRecInstructions.Location = New System.Drawing.Point(10, 452)
        Me.AdvRecInstructions.Name = "AdvRecInstructions"
        Me.AdvRecInstructions.Size = New System.Drawing.Size(348, 36)
        Me.AdvRecInstructions.TabIndex = 4
        Me.AdvRecInstructions.Text = "The Distance columns in the Advance, Recession and Measurement Stations tables mu" & _
            "st match."
        '
        'WaterFlowInstructions
        '
        Me.WaterFlowInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.WaterFlowInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WaterFlowInstructions.Location = New System.Drawing.Point(364, 452)
        Me.WaterFlowInstructions.Name = "WaterFlowInstructions"
        Me.WaterFlowInstructions.Size = New System.Drawing.Size(290, 36)
        Me.WaterFlowInstructions.TabIndex = 5
        Me.WaterFlowInstructions.Text = "There must be a Flow Depth table for each Measurement Station."
        '
        'Apply_Button
        '
        Me.Apply_Button.BackColor = System.Drawing.SystemColors.Control
        Me.Apply_Button.Location = New System.Drawing.Point(474, 495)
        Me.Apply_Button.Name = "Apply_Button"
        Me.Apply_Button.Size = New System.Drawing.Size(75, 23)
        Me.Apply_Button.TabIndex = 7
        Me.Apply_Button.Text = "Apply"
        Me.Apply_Button.UseVisualStyleBackColor = False
        '
        'StationMeasurements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(664, 526)
        Me.Controls.Add(Me.Apply_Button)
        Me.Controls.Add(Me.WaterFlowInstructions)
        Me.Controls.Add(Me.AdvRecInstructions)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.Ok_Button)
        Me.Controls.Add(Me.AdvanceRecessionBox)
        Me.Controls.Add(Me.SurfaceFlowBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(680, 1000)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(680, 560)
        Me.Name = "StationMeasurements"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Station Flow Depth Measurements"
        Me.TopMost = True
        Me.AdvanceRecessionBox.ResumeLayout(False)
        CType(Me.RecessionTimes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvanceTimes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SurfaceFlowBox.ResumeLayout(False)
        CType(Me.FlowDepths, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SurfaceFlowBox As DataStore.ctl_GroupBox
    Friend WithEvents AdvanceRecessionBox As DataStore.ctl_GroupBox
    Friend WithEvents IncludeRecession As DataStore.ctl_CheckParameter
    Friend WithEvents RecessionTimes As DataStore.ctl_DataTableParameter
    Friend WithEvents AdvanceTimes As DataStore.ctl_DataTableParameter
    Friend WithEvents Ok_Button As DataStore.ctl_Button
    Friend WithEvents Cancel_Button As DataStore.ctl_Button
    Friend WithEvents FlowDepths As DataStore.ctl_DataTableParameter
    Friend WithEvents WaterFlowActionControl As Windows.Forms.ComboBox
    Friend WithEvents AdvRecInstructions As DataStore.ctl_Label
    Friend WithEvents WaterFlowInstructions As DataStore.ctl_Label
    Friend WithEvents EditLocationButton As DataStore.ctl_Button
    Friend WithEvents Apply_Button As DataStore.ctl_Button
End Class
