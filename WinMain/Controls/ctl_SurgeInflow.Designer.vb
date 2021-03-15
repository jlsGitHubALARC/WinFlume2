<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_SurgeInflow
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctl_SurgeInflow))
        Me.SurgeStrategyLabel = New DataStore.ctl_Label
        Me.SurgeStrategyControl = New DataStore.ctl_SelectParameter
        Me.UniformLocationPanel = New DataStore.ctl_Panel
        Me.UniformLocationHelp = New DataStore.ctl_Label
        Me.NumberOfSurgesControl = New DataStore.ctl_IntegerParameter
        Me.NumberOfSurgesLabel = New DataStore.ctl_Label
        Me.SurgeOnTimeLabel = New DataStore.ctl_Label
        Me.SurgeOnTimeControl = New DataStore.ctl_DoubleParameter
        Me.SurgeInflowRateLabel = New DataStore.ctl_Label
        Me.SurgeInflowRateControl = New DataStore.ctl_DoubleParameter
        Me.TabulatedTimePanel = New DataStore.ctl_Panel
        Me.TabulatedTimeHelp = New DataStore.ctl_Label
        Me.TabulatedTimeControl = New DataStore.ctl_DataTableParameter
        Me.SurgeCutoffTimeLabel = New DataStore.ctl_Label
        Me.SurgeCutoffTimeControl = New DataStore.ctl_DoubleParameter
        Me.TabulatedLocationPanel = New DataStore.ctl_Panel
        Me.TabulatedLocationHelp = New DataStore.ctl_Label
        Me.TabulatedLocationControl = New DataStore.ctl_DataTableParameter
        Me.UniformTimeSurgeBox = New DataStore.ctl_GroupBox
        Me.UniformTimePanel = New DataStore.ctl_Panel
        Me.UniformTimeHelp = New DataStore.ctl_Label
        Me.UniformLocationPanel.SuspendLayout()
        Me.TabulatedTimePanel.SuspendLayout()
        CType(Me.TabulatedTimeControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabulatedLocationPanel.SuspendLayout()
        CType(Me.TabulatedLocationControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UniformTimeSurgeBox.SuspendLayout()
        Me.UniformTimePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'SurgeStrategyLabel
        '
        Me.SurgeStrategyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurgeStrategyLabel.Location = New System.Drawing.Point(8, 4)
        Me.SurgeStrategyLabel.Name = "SurgeStrategyLabel"
        Me.SurgeStrategyLabel.Size = New System.Drawing.Size(134, 22)
        Me.SurgeStrategyLabel.TabIndex = 0
        Me.SurgeStrategyLabel.Text = "&Surge Strategy"
        Me.SurgeStrategyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SurgeStrategyControl
        '
        Me.SurgeStrategyControl.AccessibleDescription = "Selects which type of Surge Inflow to simulate"
        Me.SurgeStrategyControl.AccessibleName = "Surge Strategy"
        Me.SurgeStrategyControl.ApplicationValue = -1
        Me.SurgeStrategyControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SurgeStrategyControl.EnableSaveActions = False
        Me.SurgeStrategyControl.FormattingEnabled = True
        Me.SurgeStrategyControl.IsCalculated = False
        Me.SurgeStrategyControl.Location = New System.Drawing.Point(147, 4)
        Me.SurgeStrategyControl.Name = "SurgeStrategyControl"
        Me.SurgeStrategyControl.SelectedIndexSet = False
        Me.SurgeStrategyControl.Size = New System.Drawing.Size(185, 24)
        Me.SurgeStrategyControl.TabIndex = 1
        '
        'UniformLocationPanel
        '
        Me.UniformLocationPanel.AccessibleDescription = "Parameters for the uniform location surges"
        Me.UniformLocationPanel.AccessibleName = "Uniform Location"
        Me.UniformLocationPanel.Controls.Add(Me.UniformLocationHelp)
        Me.UniformLocationPanel.Controls.Add(Me.NumberOfSurgesControl)
        Me.UniformLocationPanel.Controls.Add(Me.NumberOfSurgesLabel)
        Me.UniformLocationPanel.Location = New System.Drawing.Point(9, 34)
        Me.UniformLocationPanel.Name = "UniformLocationPanel"
        Me.UniformLocationPanel.Size = New System.Drawing.Size(322, 179)
        Me.UniformLocationPanel.TabIndex = 2
        '
        'UniformLocationHelp
        '
        Me.UniformLocationHelp.Location = New System.Drawing.Point(6, 15)
        Me.UniformLocationHelp.Name = "UniformLocationHelp"
        Me.UniformLocationHelp.Size = New System.Drawing.Size(308, 117)
        Me.UniformLocationHelp.TabIndex = 0
        Me.UniformLocationHelp.Text = resources.GetString("UniformLocationHelp.Text")
        '
        'NumberOfSurgesControl
        '
        Me.NumberOfSurgesControl.AccessibleDescription = "Specifies the number of time uniform surges prior to the final surge"
        Me.NumberOfSurgesControl.AccessibleName = "Number of Surges"
        Me.NumberOfSurgesControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfSurgesControl.IsCalculated = False
        Me.NumberOfSurgesControl.Location = New System.Drawing.Point(241, 145)
        Me.NumberOfSurgesControl.Name = "NumberOfSurgesControl"
        Me.NumberOfSurgesControl.Size = New System.Drawing.Size(77, 24)
        Me.NumberOfSurgesControl.TabIndex = 2
        Me.NumberOfSurgesControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.NumberOfSurgesControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.NumberOfSurgesControl.ValueText = ""
        '
        'NumberOfSurgesLabel
        '
        Me.NumberOfSurgesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfSurgesLabel.Location = New System.Drawing.Point(3, 146)
        Me.NumberOfSurgesLabel.Name = "NumberOfSurgesLabel"
        Me.NumberOfSurgesLabel.Size = New System.Drawing.Size(232, 23)
        Me.NumberOfSurgesLabel.TabIndex = 1
        Me.NumberOfSurgesLabel.Text = "&Number of Advance Surges"
        Me.NumberOfSurgesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SurgeOnTimeLabel
        '
        Me.SurgeOnTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurgeOnTimeLabel.Location = New System.Drawing.Point(6, 19)
        Me.SurgeOnTimeLabel.Name = "SurgeOnTimeLabel"
        Me.SurgeOnTimeLabel.Size = New System.Drawing.Size(93, 23)
        Me.SurgeOnTimeLabel.TabIndex = 0
        Me.SurgeOnTimeLabel.Text = "On &Time"
        Me.SurgeOnTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SurgeOnTimeControl
        '
        Me.SurgeOnTimeControl.AccessibleDescription = "Defines the on time for the first surge"
        Me.SurgeOnTimeControl.AccessibleName = "On time for first surge"
        Me.SurgeOnTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SurgeOnTimeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurgeOnTimeControl.IsCalculated = False
        Me.SurgeOnTimeControl.IsInteger = False
        Me.SurgeOnTimeControl.Location = New System.Drawing.Point(98, 18)
        Me.SurgeOnTimeControl.MaxErrMsg = ""
        Me.SurgeOnTimeControl.MinErrMsg = ""
        Me.SurgeOnTimeControl.Name = "SurgeOnTimeControl"
        Me.SurgeOnTimeControl.Size = New System.Drawing.Size(99, 24)
        Me.SurgeOnTimeControl.TabIndex = 1
        Me.SurgeOnTimeControl.ToBeCalculated = True
        Me.SurgeOnTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SurgeOnTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SurgeOnTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SurgeOnTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SurgeOnTimeControl.ValueText = ""
        '
        'SurgeInflowRateLabel
        '
        Me.SurgeInflowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurgeInflowRateLabel.Location = New System.Drawing.Point(6, 232)
        Me.SurgeInflowRateLabel.Name = "SurgeInflowRateLabel"
        Me.SurgeInflowRateLabel.Size = New System.Drawing.Size(102, 23)
        Me.SurgeInflowRateLabel.TabIndex = 3
        Me.SurgeInflowRateLabel.Text = "Inflow &Rate"
        Me.SurgeInflowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SurgeInflowRateControl
        '
        Me.SurgeInflowRateControl.AccessibleDescription = "Specifies the inflow rate for the surges"
        Me.SurgeInflowRateControl.AccessibleName = "Inflow Rate"
        Me.SurgeInflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SurgeInflowRateControl.IsCalculated = False
        Me.SurgeInflowRateControl.IsInteger = False
        Me.SurgeInflowRateControl.Location = New System.Drawing.Point(9, 258)
        Me.SurgeInflowRateControl.MaxErrMsg = ""
        Me.SurgeInflowRateControl.MinErrMsg = ""
        Me.SurgeInflowRateControl.Name = "SurgeInflowRateControl"
        Me.SurgeInflowRateControl.Size = New System.Drawing.Size(99, 24)
        Me.SurgeInflowRateControl.TabIndex = 4
        Me.SurgeInflowRateControl.ToBeCalculated = True
        Me.SurgeInflowRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SurgeInflowRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SurgeInflowRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SurgeInflowRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SurgeInflowRateControl.ValueText = ""
        '
        'TabulatedTimePanel
        '
        Me.TabulatedTimePanel.AccessibleDescription = "Parameters describing surge inflow using a time table."
        Me.TabulatedTimePanel.AccessibleName = "Tabulated Time"
        Me.TabulatedTimePanel.Controls.Add(Me.TabulatedTimeHelp)
        Me.TabulatedTimePanel.Controls.Add(Me.TabulatedTimeControl)
        Me.TabulatedTimePanel.Location = New System.Drawing.Point(9, 34)
        Me.TabulatedTimePanel.Name = "TabulatedTimePanel"
        Me.TabulatedTimePanel.Size = New System.Drawing.Size(322, 179)
        Me.TabulatedTimePanel.TabIndex = 2
        '
        'TabulatedTimeHelp
        '
        Me.TabulatedTimeHelp.Location = New System.Drawing.Point(4, 4)
        Me.TabulatedTimeHelp.Name = "TabulatedTimeHelp"
        Me.TabulatedTimeHelp.Size = New System.Drawing.Size(130, 170)
        Me.TabulatedTimeHelp.TabIndex = 0
        Me.TabulatedTimeHelp.Text = "Surges progress at tabulated time intervals. All surges use the same inflow rate." & _
            ""
        '
        'TabulatedTimeControl
        '
        Me.TabulatedTimeControl.AllRowsFixed = False
        Me.TabulatedTimeControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedTimeControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedTimeControl.CaptionText = "Surge Times"
        Me.TabulatedTimeControl.CausesValidation = False
        Me.TabulatedTimeControl.ColumnWidthRatios = Nothing
        Me.TabulatedTimeControl.DataMember = ""
        Me.TabulatedTimeControl.EnableSaveActions = False
        Me.TabulatedTimeControl.FirstColumnIncreases = True
        Me.TabulatedTimeControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedTimeControl.FirstColumnMinimum = 0
        Me.TabulatedTimeControl.FirstRowFixed = True
        Me.TabulatedTimeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedTimeControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedTimeControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedTimeControl.Location = New System.Drawing.Point(138, 5)
        Me.TabulatedTimeControl.MaxRows = 50
        Me.TabulatedTimeControl.MinRows = 0
        Me.TabulatedTimeControl.Name = "TabulatedTimeControl"
        Me.TabulatedTimeControl.PasteDisabled = False
        Me.TabulatedTimeControl.SecondColumnIncreases = False
        Me.TabulatedTimeControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedTimeControl.SecondColumnMinimum = 0
        Me.TabulatedTimeControl.Size = New System.Drawing.Size(182, 170)
        Me.TabulatedTimeControl.TabIndex = 1
        Me.TabulatedTimeControl.TableReadonly = False
        '
        'SurgeCutoffTimeLabel
        '
        Me.SurgeCutoffTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurgeCutoffTimeLabel.Location = New System.Drawing.Point(6, 44)
        Me.SurgeCutoffTimeLabel.Name = "SurgeCutoffTimeLabel"
        Me.SurgeCutoffTimeLabel.Size = New System.Drawing.Size(93, 23)
        Me.SurgeCutoffTimeLabel.TabIndex = 2
        Me.SurgeCutoffTimeLabel.Text = "Cutoff Ti&me"
        Me.SurgeCutoffTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SurgeCutoffTimeControl
        '
        Me.SurgeCutoffTimeControl.AccessibleDescription = "Defines the final surge's cutoff time"
        Me.SurgeCutoffTimeControl.AccessibleName = "Cutoff Time"
        Me.SurgeCutoffTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SurgeCutoffTimeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurgeCutoffTimeControl.IsCalculated = False
        Me.SurgeCutoffTimeControl.IsInteger = False
        Me.SurgeCutoffTimeControl.Location = New System.Drawing.Point(98, 43)
        Me.SurgeCutoffTimeControl.MaxErrMsg = ""
        Me.SurgeCutoffTimeControl.MinErrMsg = ""
        Me.SurgeCutoffTimeControl.Name = "SurgeCutoffTimeControl"
        Me.SurgeCutoffTimeControl.Size = New System.Drawing.Size(99, 24)
        Me.SurgeCutoffTimeControl.TabIndex = 3
        Me.SurgeCutoffTimeControl.ToBeCalculated = True
        Me.SurgeCutoffTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SurgeCutoffTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SurgeCutoffTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SurgeCutoffTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SurgeCutoffTimeControl.ValueText = ""
        '
        'TabulatedLocationPanel
        '
        Me.TabulatedLocationPanel.AccessibleDescription = "Parameters describing surge inflow using a location table."
        Me.TabulatedLocationPanel.AccessibleName = "Tabulated Located"
        Me.TabulatedLocationPanel.Controls.Add(Me.TabulatedLocationHelp)
        Me.TabulatedLocationPanel.Controls.Add(Me.TabulatedLocationControl)
        Me.TabulatedLocationPanel.Location = New System.Drawing.Point(9, 34)
        Me.TabulatedLocationPanel.Name = "TabulatedLocationPanel"
        Me.TabulatedLocationPanel.Size = New System.Drawing.Size(322, 179)
        Me.TabulatedLocationPanel.TabIndex = 2
        '
        'TabulatedLocationHelp
        '
        Me.TabulatedLocationHelp.Location = New System.Drawing.Point(4, 4)
        Me.TabulatedLocationHelp.Name = "TabulatedLocationHelp"
        Me.TabulatedLocationHelp.Size = New System.Drawing.Size(130, 170)
        Me.TabulatedLocationHelp.TabIndex = 0
        Me.TabulatedLocationHelp.Text = "Surges progress at tabulated advance intervals followed by uniform time surges as" & _
            " specified below. All surges use the same inflow rate."
        '
        'TabulatedLocationControl
        '
        Me.TabulatedLocationControl.AllRowsFixed = False
        Me.TabulatedLocationControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedLocationControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedLocationControl.CaptionText = "Surge Locations"
        Me.TabulatedLocationControl.CausesValidation = False
        Me.TabulatedLocationControl.ColumnWidthRatios = Nothing
        Me.TabulatedLocationControl.DataMember = ""
        Me.TabulatedLocationControl.EnableSaveActions = False
        Me.TabulatedLocationControl.FirstColumnIncreases = True
        Me.TabulatedLocationControl.FirstColumnMaximum = 1
        Me.TabulatedLocationControl.FirstColumnMinimum = 0.1
        Me.TabulatedLocationControl.FirstRowFixed = False
        Me.TabulatedLocationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedLocationControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedLocationControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedLocationControl.Location = New System.Drawing.Point(138, 5)
        Me.TabulatedLocationControl.MaxRows = 50
        Me.TabulatedLocationControl.MinRows = 0
        Me.TabulatedLocationControl.Name = "TabulatedLocationControl"
        Me.TabulatedLocationControl.PasteDisabled = False
        Me.TabulatedLocationControl.SecondColumnIncreases = False
        Me.TabulatedLocationControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedLocationControl.SecondColumnMinimum = 0
        Me.TabulatedLocationControl.Size = New System.Drawing.Size(182, 170)
        Me.TabulatedLocationControl.TabIndex = 1
        Me.TabulatedLocationControl.TableReadonly = False
        '
        'UniformTimeSurgeBox
        '
        Me.UniformTimeSurgeBox.AccessibleDescription = "Time values for uniform time surges."
        Me.UniformTimeSurgeBox.AccessibleName = "Uniform Time Surges"
        Me.UniformTimeSurgeBox.Controls.Add(Me.SurgeOnTimeLabel)
        Me.UniformTimeSurgeBox.Controls.Add(Me.SurgeCutoffTimeControl)
        Me.UniformTimeSurgeBox.Controls.Add(Me.SurgeCutoffTimeLabel)
        Me.UniformTimeSurgeBox.Controls.Add(Me.SurgeOnTimeControl)
        Me.UniformTimeSurgeBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UniformTimeSurgeBox.Location = New System.Drawing.Point(126, 219)
        Me.UniformTimeSurgeBox.Name = "UniformTimeSurgeBox"
        Me.UniformTimeSurgeBox.Size = New System.Drawing.Size(206, 76)
        Me.UniformTimeSurgeBox.TabIndex = 5
        Me.UniformTimeSurgeBox.TabStop = False
        Me.UniformTimeSurgeBox.Text = "Uniform Time Surges"
        '
        'UniformTimePanel
        '
        Me.UniformTimePanel.AccessibleDescription = "Parameters for the uniform time surges"
        Me.UniformTimePanel.AccessibleName = "Uniform Time"
        Me.UniformTimePanel.Controls.Add(Me.UniformTimeHelp)
        Me.UniformTimePanel.Location = New System.Drawing.Point(9, 34)
        Me.UniformTimePanel.Name = "UniformTimePanel"
        Me.UniformTimePanel.Size = New System.Drawing.Size(322, 179)
        Me.UniformTimePanel.TabIndex = 2
        '
        'UniformTimeHelp
        '
        Me.UniformTimeHelp.Location = New System.Drawing.Point(6, 15)
        Me.UniformTimeHelp.Name = "UniformTimeHelp"
        Me.UniformTimeHelp.Size = New System.Drawing.Size(308, 117)
        Me.UniformTimeHelp.TabIndex = 0
        Me.UniformTimeHelp.Text = resources.GetString("UniformTimeHelp.Text")
        '
        'ctl_SurgeInflow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabulatedTimePanel)
        Me.Controls.Add(Me.UniformTimePanel)
        Me.Controls.Add(Me.UniformTimeSurgeBox)
        Me.Controls.Add(Me.SurgeInflowRateLabel)
        Me.Controls.Add(Me.SurgeInflowRateControl)
        Me.Controls.Add(Me.SurgeStrategyControl)
        Me.Controls.Add(Me.SurgeStrategyLabel)
        Me.Controls.Add(Me.UniformLocationPanel)
        Me.Controls.Add(Me.TabulatedLocationPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_SurgeInflow"
        Me.Size = New System.Drawing.Size(335, 295)
        Me.UniformLocationPanel.ResumeLayout(False)
        Me.TabulatedTimePanel.ResumeLayout(False)
        CType(Me.TabulatedTimeControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabulatedLocationPanel.ResumeLayout(False)
        CType(Me.TabulatedLocationControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UniformTimeSurgeBox.ResumeLayout(False)
        Me.UniformTimePanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SurgeStrategyLabel As DataStore.ctl_Label
    Friend WithEvents SurgeStrategyControl As DataStore.ctl_SelectParameter
    Friend WithEvents UniformLocationPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedTimePanel As DataStore.ctl_Panel
    Friend WithEvents SurgeCutoffTimeLabel As DataStore.ctl_Label
    Friend WithEvents SurgeCutoffTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents NumberOfSurgesControl As DataStore.ctl_IntegerParameter
    Friend WithEvents NumberOfSurgesLabel As DataStore.ctl_Label
    Friend WithEvents SurgeInflowRateLabel As DataStore.ctl_Label
    Friend WithEvents SurgeInflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SurgeOnTimeLabel As DataStore.ctl_Label
    Friend WithEvents SurgeOnTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents TabulatedLocationPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedTimeControl As DataStore.ctl_DataTableParameter
    Friend WithEvents TabulatedLocationControl As DataStore.ctl_DataTableParameter
    Friend WithEvents UniformTimeSurgeBox As DataStore.ctl_GroupBox
    Friend WithEvents UniformLocationHelp As DataStore.ctl_Label
    Friend WithEvents TabulatedLocationHelp As DataStore.ctl_Label
    Friend WithEvents TabulatedTimeHelp As DataStore.ctl_Label
    Friend WithEvents UniformTimePanel As DataStore.ctl_Panel
    Friend WithEvents UniformTimeHelp As DataStore.ctl_Label

End Class
