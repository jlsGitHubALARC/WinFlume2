<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_StdHydro
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
        Me.InflowRateLabel = New DataStore.ctl_Label
        Me.InflowRateControl = New DataStore.ctl_DoubleParameter
        Me.CutoffGroupBox = New DataStore.ctl_GroupBox
        Me.CutoffUpstreamDepthPanel = New DataStore.ctl_Panel
        Me.UpstreamDepthControl = New DataStore.ctl_DoubleParameter
        Me.UpstreamDepthLabel = New DataStore.ctl_Label
        Me.CutoffTimePanel = New DataStore.ctl_Panel
        Me.CutoffTimeControl = New DataStore.ctl_DoubleParameter
        Me.CutoffTimeLabel = New DataStore.ctl_Label
        Me.CutoffMethodControl = New DataStore.ctl_SelectParameter
        Me.CutoffLocationPanel = New DataStore.ctl_Panel
        Me.CutoffLocationControl = New DataStore.ctl_DoubleParameter
        Me.OpportunityTimeLabel = New DataStore.ctl_Label
        Me.InfiltrationDepthControl = New DataStore.ctl_DoubleParameter
        Me.CutoffLocationLabel = New DataStore.ctl_Label
        Me.InfiltrationDepthLabel = New DataStore.ctl_Label
        Me.OpportunityTimeControl = New DataStore.ctl_DoubleParameter
        Me.CutbackGroupBox = New DataStore.ctl_GroupBox
        Me.CutbackMethodControl = New DataStore.ctl_SelectParameter
        Me.CutbackPanel = New DataStore.ctl_Panel
        Me.CutbackLocationLabel = New DataStore.ctl_Label
        Me.CutbackTimeLabel = New DataStore.ctl_Label
        Me.CutbackRateLabel = New DataStore.ctl_Label
        Me.CutbackLocationControl = New DataStore.ctl_DoubleParameter
        Me.CutbackRateControl = New DataStore.ctl_DoubleParameter
        Me.CutbackTimeControl = New DataStore.ctl_DoubleParameter
        Me.CutoffGroupBox.SuspendLayout()
        Me.CutoffUpstreamDepthPanel.SuspendLayout()
        Me.CutoffTimePanel.SuspendLayout()
        Me.CutoffLocationPanel.SuspendLayout()
        Me.CutbackGroupBox.SuspendLayout()
        Me.CutbackPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'InflowRateLabel
        '
        Me.InflowRateLabel.Location = New System.Drawing.Point(2, 11)
        Me.InflowRateLabel.Name = "InflowRateLabel"
        Me.InflowRateLabel.Size = New System.Drawing.Size(91, 23)
        Me.InflowRateLabel.TabIndex = 0
        Me.InflowRateLabel.Text = "Rate, &Q"
        Me.InflowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InflowRateControl
        '
        Me.InflowRateControl.AccessibleDescription = "Defines the rate at which the irrigation water flows onto the field."
        Me.InflowRateControl.AccessibleName = "Inflow Rate"
        Me.InflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.InflowRateControl.IsCalculated = False
        Me.InflowRateControl.IsInteger = False
        Me.InflowRateControl.Location = New System.Drawing.Point(94, 11)
        Me.InflowRateControl.Name = "InflowRateControl"
        Me.InflowRateControl.Size = New System.Drawing.Size(112, 24)
        Me.InflowRateControl.TabIndex = 1
        Me.InflowRateControl.ToBeCalculated = True
        Me.InflowRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.InflowRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.InflowRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.InflowRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.InflowRateControl.ValueText = ""
        '
        'CutoffGroupBox
        '
        Me.CutoffGroupBox.AccessibleDescription = "Allows editing of the Cutoff Options."
        Me.CutoffGroupBox.AccessibleName = "Cutoff Options"
        Me.CutoffGroupBox.Controls.Add(Me.CutoffUpstreamDepthPanel)
        Me.CutoffGroupBox.Controls.Add(Me.CutoffTimePanel)
        Me.CutoffGroupBox.Controls.Add(Me.CutoffMethodControl)
        Me.CutoffGroupBox.Controls.Add(Me.CutoffLocationPanel)
        Me.CutoffGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffGroupBox.Location = New System.Drawing.Point(2, 51)
        Me.CutoffGroupBox.Name = "CutoffGroupBox"
        Me.CutoffGroupBox.Size = New System.Drawing.Size(212, 112)
        Me.CutoffGroupBox.TabIndex = 2
        Me.CutoffGroupBox.TabStop = False
        Me.CutoffGroupBox.Text = "Cut&off Options"
        '
        'CutoffUpstreamDepthPanel
        '
        Me.CutoffUpstreamDepthPanel.Controls.Add(Me.UpstreamDepthControl)
        Me.CutoffUpstreamDepthPanel.Controls.Add(Me.UpstreamDepthLabel)
        Me.CutoffUpstreamDepthPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffUpstreamDepthPanel.Location = New System.Drawing.Point(2, 48)
        Me.CutoffUpstreamDepthPanel.Name = "CutoffUpstreamDepthPanel"
        Me.CutoffUpstreamDepthPanel.Size = New System.Drawing.Size(206, 56)
        Me.CutoffUpstreamDepthPanel.TabIndex = 3
        '
        'UpstreamDepthControl
        '
        Me.UpstreamDepthControl.AccessibleDescription = "Specifies the upstream infiltrated depth before cutoff occurs."
        Me.UpstreamDepthControl.AccessibleName = "Infiltration Depth"
        Me.UpstreamDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.UpstreamDepthControl.IsCalculated = False
        Me.UpstreamDepthControl.IsInteger = False
        Me.UpstreamDepthControl.Location = New System.Drawing.Point(90, 6)
        Me.UpstreamDepthControl.Name = "UpstreamDepthControl"
        Me.UpstreamDepthControl.Size = New System.Drawing.Size(112, 24)
        Me.UpstreamDepthControl.TabIndex = 1
        Me.UpstreamDepthControl.ToBeCalculated = True
        Me.UpstreamDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.UpstreamDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.UpstreamDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.UpstreamDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.UpstreamDepthControl.ValueText = ""
        '
        'UpstreamDepthLabel
        '
        Me.UpstreamDepthLabel.Location = New System.Drawing.Point(2, 6)
        Me.UpstreamDepthLabel.Name = "UpstreamDepthLabel"
        Me.UpstreamDepthLabel.Size = New System.Drawing.Size(88, 23)
        Me.UpstreamDepthLabel.TabIndex = 0
        Me.UpstreamDepthLabel.Text = "I&nf. Depth"
        Me.UpstreamDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutoffTimePanel
        '
        Me.CutoffTimePanel.Controls.Add(Me.CutoffTimeControl)
        Me.CutoffTimePanel.Controls.Add(Me.CutoffTimeLabel)
        Me.CutoffTimePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffTimePanel.Location = New System.Drawing.Point(2, 48)
        Me.CutoffTimePanel.Name = "CutoffTimePanel"
        Me.CutoffTimePanel.Size = New System.Drawing.Size(206, 56)
        Me.CutoffTimePanel.TabIndex = 2
        '
        'CutoffTimeControl
        '
        Me.CutoffTimeControl.AccessibleDescription = "Defines the time the water flows onto the field before cutoff."
        Me.CutoffTimeControl.AccessibleName = "Cutoff Time"
        Me.CutoffTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutoffTimeControl.IsCalculated = False
        Me.CutoffTimeControl.IsInteger = False
        Me.CutoffTimeControl.Location = New System.Drawing.Point(90, 4)
        Me.CutoffTimeControl.Name = "CutoffTimeControl"
        Me.CutoffTimeControl.Size = New System.Drawing.Size(112, 24)
        Me.CutoffTimeControl.TabIndex = 1
        Me.CutoffTimeControl.ToBeCalculated = True
        Me.CutoffTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutoffTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutoffTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutoffTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutoffTimeControl.ValueText = ""
        '
        'CutoffTimeLabel
        '
        Me.CutoffTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffTimeLabel.Location = New System.Drawing.Point(2, 6)
        Me.CutoffTimeLabel.Name = "CutoffTimeLabel"
        Me.CutoffTimeLabel.Size = New System.Drawing.Size(88, 23)
        Me.CutoffTimeLabel.TabIndex = 0
        Me.CutoffTimeLabel.Text = "Time, &Tco"
        Me.CutoffTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutoffMethodControl
        '
        Me.CutoffMethodControl.AccessibleDescription = "Selects the method for describing the irrigation water cutoff."
        Me.CutoffMethodControl.AccessibleName = "Cutoff Method"
        Me.CutoffMethodControl.ApplicationValue = -1
        Me.CutoffMethodControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CutoffMethodControl.EnableSaveActions = False
        Me.CutoffMethodControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffMethodControl.IsCalculated = False
        Me.CutoffMethodControl.Location = New System.Drawing.Point(6, 24)
        Me.CutoffMethodControl.Name = "CutoffMethodControl"
        Me.CutoffMethodControl.SelectedIndexSet = False
        Me.CutoffMethodControl.Size = New System.Drawing.Size(200, 24)
        Me.CutoffMethodControl.TabIndex = 1
        '
        'CutoffLocationPanel
        '
        Me.CutoffLocationPanel.Controls.Add(Me.CutoffLocationControl)
        Me.CutoffLocationPanel.Controls.Add(Me.OpportunityTimeLabel)
        Me.CutoffLocationPanel.Controls.Add(Me.InfiltrationDepthControl)
        Me.CutoffLocationPanel.Controls.Add(Me.CutoffLocationLabel)
        Me.CutoffLocationPanel.Controls.Add(Me.InfiltrationDepthLabel)
        Me.CutoffLocationPanel.Controls.Add(Me.OpportunityTimeControl)
        Me.CutoffLocationPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffLocationPanel.Location = New System.Drawing.Point(2, 48)
        Me.CutoffLocationPanel.Name = "CutoffLocationPanel"
        Me.CutoffLocationPanel.Size = New System.Drawing.Size(206, 56)
        Me.CutoffLocationPanel.TabIndex = 2
        '
        'CutoffLocationControl
        '
        Me.CutoffLocationControl.AccessibleDescription = "Defines the location down the field where cutoff occurs as a ratio of the field l" & _
            "ength."
        Me.CutoffLocationControl.AccessibleName = "Advance at Tco"
        Me.CutoffLocationControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutoffLocationControl.IsCalculated = False
        Me.CutoffLocationControl.IsInteger = False
        Me.CutoffLocationControl.Location = New System.Drawing.Point(90, 4)
        Me.CutoffLocationControl.Name = "CutoffLocationControl"
        Me.CutoffLocationControl.Size = New System.Drawing.Size(112, 24)
        Me.CutoffLocationControl.TabIndex = 1
        Me.CutoffLocationControl.ToBeCalculated = True
        Me.CutoffLocationControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutoffLocationControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutoffLocationControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutoffLocationControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutoffLocationControl.ValueText = ""
        '
        'OpportunityTimeLabel
        '
        Me.OpportunityTimeLabel.Location = New System.Drawing.Point(3, 32)
        Me.OpportunityTimeLabel.Name = "OpportunityTimeLabel"
        Me.OpportunityTimeLabel.Size = New System.Drawing.Size(88, 23)
        Me.OpportunityTimeLabel.TabIndex = 4
        Me.OpportunityTimeLabel.Text = "&& Opp. &Time"
        Me.OpportunityTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InfiltrationDepthControl
        '
        Me.InfiltrationDepthControl.AccessibleDescription = "Specifies the infiltration depth at the Advance at Tco location before cutoff occ" & _
            "urs."
        Me.InfiltrationDepthControl.AccessibleName = "Infiltration Depth"
        Me.InfiltrationDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.InfiltrationDepthControl.IsCalculated = False
        Me.InfiltrationDepthControl.IsInteger = False
        Me.InfiltrationDepthControl.Location = New System.Drawing.Point(90, 31)
        Me.InfiltrationDepthControl.Name = "InfiltrationDepthControl"
        Me.InfiltrationDepthControl.Size = New System.Drawing.Size(112, 24)
        Me.InfiltrationDepthControl.TabIndex = 3
        Me.InfiltrationDepthControl.ToBeCalculated = True
        Me.InfiltrationDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.InfiltrationDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.InfiltrationDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.InfiltrationDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.InfiltrationDepthControl.ValueText = ""
        '
        'CutoffLocationLabel
        '
        Me.CutoffLocationLabel.Location = New System.Drawing.Point(2, 6)
        Me.CutoffLocationLabel.Name = "CutoffLocationLabel"
        Me.CutoffLocationLabel.Size = New System.Drawing.Size(88, 23)
        Me.CutoffLocationLabel.TabIndex = 0
        Me.CutoffLocationLabel.Text = "Loc, &R"
        Me.CutoffLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InfiltrationDepthLabel
        '
        Me.InfiltrationDepthLabel.Location = New System.Drawing.Point(6, 32)
        Me.InfiltrationDepthLabel.Name = "InfiltrationDepthLabel"
        Me.InfiltrationDepthLabel.Size = New System.Drawing.Size(88, 23)
        Me.InfiltrationDepthLabel.TabIndex = 2
        Me.InfiltrationDepthLabel.Text = "&& I&nf. Depth"
        Me.InfiltrationDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OpportunityTimeControl
        '
        Me.OpportunityTimeControl.AccessibleDescription = "Defines the opportunity time after Advance at Tco before cutoff occurs."
        Me.OpportunityTimeControl.AccessibleName = "Opportunity Time"
        Me.OpportunityTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.OpportunityTimeControl.IsCalculated = False
        Me.OpportunityTimeControl.IsInteger = False
        Me.OpportunityTimeControl.Location = New System.Drawing.Point(90, 31)
        Me.OpportunityTimeControl.Name = "OpportunityTimeControl"
        Me.OpportunityTimeControl.Size = New System.Drawing.Size(112, 24)
        Me.OpportunityTimeControl.TabIndex = 5
        Me.OpportunityTimeControl.ToBeCalculated = True
        Me.OpportunityTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.OpportunityTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.OpportunityTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.OpportunityTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.OpportunityTimeControl.ValueText = ""
        '
        'CutbackGroupBox
        '
        Me.CutbackGroupBox.AccessibleDescription = "Allows editing of the Cutback Options."
        Me.CutbackGroupBox.AccessibleName = "Cutback Options"
        Me.CutbackGroupBox.Controls.Add(Me.CutbackMethodControl)
        Me.CutbackGroupBox.Controls.Add(Me.CutbackPanel)
        Me.CutbackGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutbackGroupBox.Location = New System.Drawing.Point(2, 171)
        Me.CutbackGroupBox.Name = "CutbackGroupBox"
        Me.CutbackGroupBox.Size = New System.Drawing.Size(212, 112)
        Me.CutbackGroupBox.TabIndex = 3
        Me.CutbackGroupBox.TabStop = False
        Me.CutbackGroupBox.Text = "Cut&back Options"
        '
        'CutbackMethodControl
        '
        Me.CutbackMethodControl.AccessibleDescription = "Selects the method for describing the irrigation water cutback."
        Me.CutbackMethodControl.AccessibleName = "Cutback Method"
        Me.CutbackMethodControl.ApplicationValue = -1
        Me.CutbackMethodControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CutbackMethodControl.EnableSaveActions = False
        Me.CutbackMethodControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutbackMethodControl.IsCalculated = False
        Me.CutbackMethodControl.Location = New System.Drawing.Point(6, 24)
        Me.CutbackMethodControl.Name = "CutbackMethodControl"
        Me.CutbackMethodControl.SelectedIndexSet = False
        Me.CutbackMethodControl.Size = New System.Drawing.Size(200, 24)
        Me.CutbackMethodControl.TabIndex = 1
        '
        'CutbackPanel
        '
        Me.CutbackPanel.Controls.Add(Me.CutbackTimeLabel)
        Me.CutbackPanel.Controls.Add(Me.CutbackRateLabel)
        Me.CutbackPanel.Controls.Add(Me.CutbackRateControl)
        Me.CutbackPanel.Controls.Add(Me.CutbackTimeControl)
        Me.CutbackPanel.Controls.Add(Me.CutbackLocationControl)
        Me.CutbackPanel.Controls.Add(Me.CutbackLocationLabel)
        Me.CutbackPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutbackPanel.Location = New System.Drawing.Point(2, 48)
        Me.CutbackPanel.Name = "CutbackPanel"
        Me.CutbackPanel.Size = New System.Drawing.Size(206, 56)
        Me.CutbackPanel.TabIndex = 2
        '
        'CutbackLocationLabel
        '
        Me.CutbackLocationLabel.Location = New System.Drawing.Point(2, 6)
        Me.CutbackLocationLabel.Name = "CutbackLocationLabel"
        Me.CutbackLocationLabel.Size = New System.Drawing.Size(88, 23)
        Me.CutbackLocationLabel.TabIndex = 2
        Me.CutbackLocationLabel.Text = "Loc, &Xcb"
        Me.CutbackLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutbackTimeLabel
        '
        Me.CutbackTimeLabel.Location = New System.Drawing.Point(2, 6)
        Me.CutbackTimeLabel.Name = "CutbackTimeLabel"
        Me.CutbackTimeLabel.Size = New System.Drawing.Size(88, 23)
        Me.CutbackTimeLabel.TabIndex = 0
        Me.CutbackTimeLabel.Text = "Time, T&cb"
        Me.CutbackTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutbackRateLabel
        '
        Me.CutbackRateLabel.Location = New System.Drawing.Point(2, 31)
        Me.CutbackRateLabel.Name = "CutbackRateLabel"
        Me.CutbackRateLabel.Size = New System.Drawing.Size(88, 23)
        Me.CutbackRateLabel.TabIndex = 4
        Me.CutbackRateLabel.Text = "&Rate, Qcb"
        Me.CutbackRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutbackLocationControl
        '
        Me.CutbackLocationControl.AccessibleDescription = "Defines the location down the field where cutback occurs as a ratio of the field " & _
            "length."
        Me.CutbackLocationControl.AccessibleName = "Cutback Location"
        Me.CutbackLocationControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutbackLocationControl.IsCalculated = False
        Me.CutbackLocationControl.IsInteger = False
        Me.CutbackLocationControl.Location = New System.Drawing.Point(90, 6)
        Me.CutbackLocationControl.Name = "CutbackLocationControl"
        Me.CutbackLocationControl.Size = New System.Drawing.Size(112, 24)
        Me.CutbackLocationControl.TabIndex = 3
        Me.CutbackLocationControl.ToBeCalculated = True
        Me.CutbackLocationControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutbackLocationControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutbackLocationControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutbackLocationControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutbackLocationControl.ValueText = ""
        '
        'CutbackRateControl
        '
        Me.CutbackRateControl.AccessibleDescription = "Defines the cutback rate of inflow as a ratio of the Inflow Rate."
        Me.CutbackRateControl.AccessibleName = "Cutback Rate"
        Me.CutbackRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutbackRateControl.IsCalculated = False
        Me.CutbackRateControl.IsInteger = False
        Me.CutbackRateControl.Location = New System.Drawing.Point(90, 31)
        Me.CutbackRateControl.Name = "CutbackRateControl"
        Me.CutbackRateControl.Size = New System.Drawing.Size(112, 24)
        Me.CutbackRateControl.TabIndex = 5
        Me.CutbackRateControl.ToBeCalculated = True
        Me.CutbackRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutbackRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutbackRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutbackRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutbackRateControl.ValueText = ""
        '
        'CutbackTimeControl
        '
        Me.CutbackTimeControl.AccessibleDescription = "Defines the time the water flows onto the field before cutback."
        Me.CutbackTimeControl.AccessibleName = "Cutback Time"
        Me.CutbackTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.CutbackTimeControl.IsCalculated = False
        Me.CutbackTimeControl.IsInteger = False
        Me.CutbackTimeControl.Location = New System.Drawing.Point(90, 6)
        Me.CutbackTimeControl.Name = "CutbackTimeControl"
        Me.CutbackTimeControl.Size = New System.Drawing.Size(112, 24)
        Me.CutbackTimeControl.TabIndex = 1
        Me.CutbackTimeControl.ToBeCalculated = True
        Me.CutbackTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.CutbackTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.CutbackTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CutbackTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CutbackTimeControl.ValueText = ""
        '
        'ctl_StdHydro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.InflowRateLabel)
        Me.Controls.Add(Me.InflowRateControl)
        Me.Controls.Add(Me.CutoffGroupBox)
        Me.Controls.Add(Me.CutbackGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_StdHydro"
        Me.Size = New System.Drawing.Size(216, 290)
        Me.CutoffGroupBox.ResumeLayout(False)
        Me.CutoffUpstreamDepthPanel.ResumeLayout(False)
        Me.CutoffTimePanel.ResumeLayout(False)
        Me.CutoffLocationPanel.ResumeLayout(False)
        Me.CutbackGroupBox.ResumeLayout(False)
        Me.CutbackPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InflowRateLabel As DataStore.ctl_Label
    Friend WithEvents InflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents CutoffMethodControl As DataStore.ctl_SelectParameter
    Friend WithEvents CutoffLocationPanel As DataStore.ctl_Panel
    Friend WithEvents CutoffLocationControl As DataStore.ctl_DoubleParameter
    Friend WithEvents OpportunityTimeLabel As DataStore.ctl_Label
    Friend WithEvents InfiltrationDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents OpportunityTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffLocationLabel As DataStore.ctl_Label
    Friend WithEvents InfiltrationDepthLabel As DataStore.ctl_Label
    Friend WithEvents CutoffUpstreamDepthPanel As DataStore.ctl_Panel
    Friend WithEvents UpstreamDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents UpstreamDepthLabel As DataStore.ctl_Label
    Friend WithEvents CutoffTimePanel As DataStore.ctl_Panel
    Friend WithEvents CutoffTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffTimeLabel As DataStore.ctl_Label
    Friend WithEvents CutbackGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents CutbackPanel As DataStore.ctl_Panel
    Friend WithEvents CutbackRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutbackTimeLabel As DataStore.ctl_Label
    Friend WithEvents CutbackRateLabel As DataStore.ctl_Label
    Friend WithEvents CutbackLocationControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutbackLocationLabel As DataStore.ctl_Label
    Friend WithEvents CutbackTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutbackMethodControl As DataStore.ctl_SelectParameter

End Class
