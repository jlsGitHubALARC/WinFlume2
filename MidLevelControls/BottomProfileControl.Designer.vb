<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BottomProfileControl
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
        Me.TailwaterLabel = New WinFlume.ctl_Label()
        Me.FlumeDescription = New WinFlume.ctl_TextBox()
        Me.RadiusLabel = New WinFlume.ctl_Label()
        Me.RadiusSingle = New WinFlume.ctl_SingleUnits()
        Me.OperatingDepthLabel = New WinFlume.ctl_Label()
        Me.OperatingDepthSingle = New WinFlume.ctl_SingleUnits()
        Me.AutoAdjustButton = New WinFlume.ctl_Button()
        Me.MinWspCheckBox = New WinFlume.ctl_CheckBox()
        Me.MaxWspCheckBox = New WinFlume.ctl_CheckBox()
        Me.TruncatedRampButton = New WinFlume.ctl_RadioButton()
        Me.GradualExpansionButton = New WinFlume.ctl_RadioButton()
        Me.AbruptExpansionButton = New WinFlume.ctl_RadioButton()
        Me.BottomProfileLabel = New WinFlume.ctl_Label()
        Me.GageLabel = New WinFlume.ctl_Label()
        Me.ExpansionSlopeSingle = New WinFlume.ctl_Single()
        Me.ExpansionSlopeLabel = New WinFlume.ctl_Label()
        Me.BedDropLabel = New WinFlume.ctl_Label()
        Me.BedDropSingle = New WinFlume.ctl_SingleUnits()
        Me.ExpansionLengthLabel = New WinFlume.ctl_Label()
        Me.ExpansionLengthSingle = New WinFlume.ctl_SingleUnits()
        Me.ControlLengthLabel = New WinFlume.ctl_Label()
        Me.ControlLengthSingle = New WinFlume.ctl_SingleUnits()
        Me.ConvergeLengthLabel = New WinFlume.ctl_Label()
        Me.ConvergeLengthSingle = New WinFlume.ctl_SingleUnits()
        Me.GageDistanceLabel = New WinFlume.ctl_Label()
        Me.GageDistanceSingle = New WinFlume.ctl_SingleUnits()
        Me.SillHeightLabel = New WinFlume.ctl_Label()
        Me.SillHeightSingle = New WinFlume.ctl_SingleUnits()
        Me.ChannelDepthLabel = New WinFlume.ctl_Label()
        Me.ChannelDepthSingle = New WinFlume.ctl_SingleUnits()
        Me.SuspendLayout()
        '
        'TailwaterLabel
        '
        Me.TailwaterLabel.AutoSize = True
        Me.TailwaterLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TailwaterLabel.Location = New System.Drawing.Point(555, 135)
        Me.TailwaterLabel.Name = "TailwaterLabel"
        Me.TailwaterLabel.Size = New System.Drawing.Size(65, 17)
        Me.TailwaterLabel.TabIndex = 26
        Me.TailwaterLabel.Text = "Tailwater"
        '
        'FlumeDescription
        '
        Me.FlumeDescription.AccessibleDescription = "Enter a description for the flume design"
        Me.FlumeDescription.AccessibleName = "Flume Description"
        Me.FlumeDescription.BackColor = System.Drawing.SystemColors.Info
        Me.FlumeDescription.CausesValidation = False
        Me.FlumeDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FlumeDescription.ForeColor = System.Drawing.Color.Blue
        Me.FlumeDescription.Label = ""
        Me.FlumeDescription.Location = New System.Drawing.Point(371, 2)
        Me.FlumeDescription.Name = "FlumeDescription"
        Me.FlumeDescription.Size = New System.Drawing.Size(370, 23)
        Me.FlumeDescription.TabIndex = 23
        Me.FlumeDescription.Text = "Description"
        Me.FlumeDescription.Value = "Description"
        Me.FlumeDescription.WordWrap = False
        '
        'RadiusLabel
        '
        Me.RadiusLabel.AutoSize = True
        Me.RadiusLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadiusLabel.Location = New System.Drawing.Point(323, 81)
        Me.RadiusLabel.Name = "RadiusLabel"
        Me.RadiusLabel.Size = New System.Drawing.Size(52, 17)
        Me.RadiusLabel.TabIndex = 14
        Me.RadiusLabel.Text = "Radi&us"
        '
        'RadiusSingle
        '
        Me.RadiusSingle.AccessibleDescription = "Radius of entrance transition on movable crest"
        Me.RadiusSingle.AccessibleName = "Radius"
        Me.RadiusSingle.AutoSize = True
        Me.RadiusSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RadiusSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.RadiusSingle.FormatStyle = "0.0###"
        Me.RadiusSingle.IsReadOnly = False
        Me.RadiusSingle.Label = "Single Value"
        Me.RadiusSingle.Location = New System.Drawing.Point(323, 54)
        Me.RadiusSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.RadiusSingle.Name = "RadiusSingle"
        Me.RadiusSingle.ReadOnlyMsgBox = Nothing
        Me.RadiusSingle.SiDefaultValue = 0!
        Me.RadiusSingle.SiMin = -1.401298E-45!
        Me.RadiusSingle.SiUnits = "m"
        Me.RadiusSingle.SiValue = 0!
        Me.RadiusSingle.Size = New System.Drawing.Size(81, 23)
        Me.RadiusSingle.TabIndex = 15
        Me.RadiusSingle.UndoEnabled = True
        '
        'OperatingDepthLabel
        '
        Me.OperatingDepthLabel.AutoSize = True
        Me.OperatingDepthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.OperatingDepthLabel.Location = New System.Drawing.Point(156, 81)
        Me.OperatingDepthLabel.Name = "OperatingDepthLabel"
        Me.OperatingDepthLabel.Size = New System.Drawing.Size(113, 17)
        Me.OperatingDepthLabel.TabIndex = 4
        Me.OperatingDepthLabel.Text = "&Operating Depth"
        '
        'OperatingDepthSingle
        '
        Me.OperatingDepthSingle.AccessibleDescription = "Operating depth in approach channel"
        Me.OperatingDepthSingle.AccessibleName = "Operating Depth"
        Me.OperatingDepthSingle.AutoSize = True
        Me.OperatingDepthSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.OperatingDepthSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.OperatingDepthSingle.FormatStyle = "0.0###"
        Me.OperatingDepthSingle.IsReadOnly = False
        Me.OperatingDepthSingle.Label = "Single Value"
        Me.OperatingDepthSingle.Location = New System.Drawing.Point(156, 54)
        Me.OperatingDepthSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.OperatingDepthSingle.Name = "OperatingDepthSingle"
        Me.OperatingDepthSingle.ReadOnlyMsgBox = Nothing
        Me.OperatingDepthSingle.SiDefaultValue = 0!
        Me.OperatingDepthSingle.SiMin = -1.401298E-45!
        Me.OperatingDepthSingle.SiUnits = "m"
        Me.OperatingDepthSingle.SiValue = 0!
        Me.OperatingDepthSingle.Size = New System.Drawing.Size(81, 23)
        Me.OperatingDepthSingle.TabIndex = 5
        Me.OperatingDepthSingle.UndoEnabled = True
        '
        'AutoAdjustButton
        '
        Me.AutoAdjustButton.AutoSize = True
        Me.AutoAdjustButton.BackColor = System.Drawing.SystemColors.Control
        Me.AutoAdjustButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AutoAdjustButton.Location = New System.Drawing.Point(595, 85)
        Me.AutoAdjustButton.Name = "AutoAdjustButton"
        Me.AutoAdjustButton.Size = New System.Drawing.Size(146, 27)
        Me.AutoAdjustButton.TabIndex = 24
        Me.AutoAdjustButton.Text = "Auto-Adjust &Lengths"
        Me.AutoAdjustButton.UseVisualStyleBackColor = False
        '
        'MinWspCheckBox
        '
        Me.MinWspCheckBox.AccessibleDescription = "Show / hide minimum water surface profile"
        Me.MinWspCheckBox.AccessibleName = "Min WSP"
        Me.MinWspCheckBox.AutoSize = True
        Me.MinWspCheckBox.HandleCheckedChanged = True
        Me.MinWspCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MinWspCheckBox.Location = New System.Drawing.Point(10, 85)
        Me.MinWspCheckBox.Name = "MinWspCheckBox"
        Me.MinWspCheckBox.Size = New System.Drawing.Size(84, 21)
        Me.MinWspCheckBox.TabIndex = 3
        Me.MinWspCheckBox.Text = "Mi&n WSP"
        Me.MinWspCheckBox.UndoEnabled = True
        Me.MinWspCheckBox.UseVisualStyleBackColor = True
        Me.MinWspCheckBox.Value = False
        '
        'MaxWspCheckBox
        '
        Me.MaxWspCheckBox.AccessibleDescription = "Show / hide maximum water surface profile"
        Me.MaxWspCheckBox.AccessibleName = "Max WSP"
        Me.MaxWspCheckBox.AutoSize = True
        Me.MaxWspCheckBox.HandleCheckedChanged = True
        Me.MaxWspCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MaxWspCheckBox.Location = New System.Drawing.Point(10, 56)
        Me.MaxWspCheckBox.Name = "MaxWspCheckBox"
        Me.MaxWspCheckBox.Size = New System.Drawing.Size(87, 21)
        Me.MaxWspCheckBox.TabIndex = 2
        Me.MaxWspCheckBox.Text = "Ma&x WSP"
        Me.MaxWspCheckBox.UndoEnabled = True
        Me.MaxWspCheckBox.UseVisualStyleBackColor = True
        Me.MaxWspCheckBox.Value = False
        '
        'TruncatedRampButton
        '
        Me.TruncatedRampButton.AccessibleDescription = "Select a truncated ramp expansion profile"
        Me.TruncatedRampButton.AccessibleName = "Truncated Ramp"
        Me.TruncatedRampButton.AutoSize = True
        Me.TruncatedRampButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TruncatedRampButton.Label = ""
        Me.TruncatedRampButton.Location = New System.Drawing.Point(595, 65)
        Me.TruncatedRampButton.Name = "TruncatedRampButton"
        Me.TruncatedRampButton.RbValue = -1
        Me.TruncatedRampButton.Size = New System.Drawing.Size(132, 21)
        Me.TruncatedRampButton.TabIndex = 20
        Me.TruncatedRampButton.TabStop = True
        Me.TruncatedRampButton.Text = "Truncated Ramp"
        Me.TruncatedRampButton.UiValue = -1
        Me.TruncatedRampButton.UseVisualStyleBackColor = True
        '
        'GradualExpansionButton
        '
        Me.GradualExpansionButton.AccessibleDescription = "Select a gradual expansion section profile"
        Me.GradualExpansionButton.AccessibleName = "Gradual Expansion"
        Me.GradualExpansionButton.AutoSize = True
        Me.GradualExpansionButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GradualExpansionButton.Label = ""
        Me.GradualExpansionButton.Location = New System.Drawing.Point(595, 45)
        Me.GradualExpansionButton.Name = "GradualExpansionButton"
        Me.GradualExpansionButton.RbValue = -1
        Me.GradualExpansionButton.Size = New System.Drawing.Size(146, 21)
        Me.GradualExpansionButton.TabIndex = 19
        Me.GradualExpansionButton.TabStop = True
        Me.GradualExpansionButton.Text = "Gradual Expansion"
        Me.GradualExpansionButton.UiValue = -1
        Me.GradualExpansionButton.UseVisualStyleBackColor = True
        '
        'AbruptExpansionButton
        '
        Me.AbruptExpansionButton.AccessibleDescription = "Select an abrupt expansion section profile"
        Me.AbruptExpansionButton.AccessibleName = "Abrupt Expansion"
        Me.AbruptExpansionButton.AutoSize = True
        Me.AbruptExpansionButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AbruptExpansionButton.Label = ""
        Me.AbruptExpansionButton.Location = New System.Drawing.Point(595, 25)
        Me.AbruptExpansionButton.Name = "AbruptExpansionButton"
        Me.AbruptExpansionButton.RbValue = -1
        Me.AbruptExpansionButton.Size = New System.Drawing.Size(137, 21)
        Me.AbruptExpansionButton.TabIndex = 18
        Me.AbruptExpansionButton.TabStop = True
        Me.AbruptExpansionButton.Text = "Abrupt Expansion"
        Me.AbruptExpansionButton.UiValue = -1
        Me.AbruptExpansionButton.UseVisualStyleBackColor = True
        '
        'BottomProfileLabel
        '
        Me.BottomProfileLabel.AutoSize = True
        Me.BottomProfileLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.BottomProfileLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BottomProfileLabel.Location = New System.Drawing.Point(230, 5)
        Me.BottomProfileLabel.Name = "BottomProfileLabel"
        Me.BottomProfileLabel.Size = New System.Drawing.Size(110, 17)
        Me.BottomProfileLabel.TabIndex = 22
        Me.BottomProfileLabel.Text = "Bottom Pro&file"
        '
        'GageLabel
        '
        Me.GageLabel.AutoSize = True
        Me.GageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GageLabel.Location = New System.Drawing.Point(150, 5)
        Me.GageLabel.Name = "GageLabel"
        Me.GageLabel.Size = New System.Drawing.Size(43, 17)
        Me.GageLabel.TabIndex = 21
        Me.GageLabel.Text = "Gage"
        '
        'ExpansionSlopeSingle
        '
        Me.ExpansionSlopeSingle.AccessibleDescription = "Diverging transition slope (6:1 recommended)"
        Me.ExpansionSlopeSingle.AccessibleName = "Expansion Slope"
        Me.ExpansionSlopeSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ExpansionSlopeSingle.FormatStyle = "0.0###"
        Me.ExpansionSlopeSingle.IsReadOnly = False
        Me.ExpansionSlopeSingle.Label = "Single Value"
        Me.ExpansionSlopeSingle.Location = New System.Drawing.Point(470, 54)
        Me.ExpansionSlopeSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.ExpansionSlopeSingle.Name = "ExpansionSlopeSingle"
        Me.ExpansionSlopeSingle.ReadOnlyMsgBox = Nothing
        Me.ExpansionSlopeSingle.SiDefaultValue = 0!
        Me.ExpansionSlopeSingle.SiMin = -1.401298E-45!
        Me.ExpansionSlopeSingle.SiValue = 0!
        Me.ExpansionSlopeSingle.Size = New System.Drawing.Size(55, 23)
        Me.ExpansionSlopeSingle.TabIndex = 15
        Me.ExpansionSlopeSingle.UiValue = 0!
        Me.ExpansionSlopeSingle.UndoEnabled = True
        '
        'ExpansionSlopeLabel
        '
        Me.ExpansionSlopeLabel.AutoSize = True
        Me.ExpansionSlopeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ExpansionSlopeLabel.Location = New System.Drawing.Point(470, 36)
        Me.ExpansionSlopeLabel.Name = "ExpansionSlopeLabel"
        Me.ExpansionSlopeLabel.Size = New System.Drawing.Size(44, 17)
        Me.ExpansionSlopeLabel.TabIndex = 14
        Me.ExpansionSlopeLabel.Text = "&Slope"
        '
        'BedDropLabel
        '
        Me.BedDropLabel.AutoSize = True
        Me.BedDropLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BedDropLabel.Location = New System.Drawing.Point(630, 135)
        Me.BedDropLabel.Name = "BedDropLabel"
        Me.BedDropLabel.Size = New System.Drawing.Size(68, 17)
        Me.BedDropLabel.TabIndex = 16
        Me.BedDropLabel.Text = "Bed Dro&p"
        '
        'BedDropSingle
        '
        Me.BedDropSingle.AccessibleDescription = "Bed drop relative to approach channel (+ for drop, - for rise)"
        Me.BedDropSingle.AccessibleName = "Bed Drop"
        Me.BedDropSingle.AutoSize = True
        Me.BedDropSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BedDropSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.BedDropSingle.FormatStyle = "0.0###"
        Me.BedDropSingle.IsReadOnly = False
        Me.BedDropSingle.Label = "Single Value"
        Me.BedDropSingle.Location = New System.Drawing.Point(630, 110)
        Me.BedDropSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.BedDropSingle.Name = "BedDropSingle"
        Me.BedDropSingle.ReadOnlyMsgBox = Nothing
        Me.BedDropSingle.SiDefaultValue = 0!
        Me.BedDropSingle.SiMin = -1.0!
        Me.BedDropSingle.SiUnits = "m"
        Me.BedDropSingle.SiValue = 0!
        Me.BedDropSingle.Size = New System.Drawing.Size(81, 23)
        Me.BedDropSingle.TabIndex = 17
        Me.BedDropSingle.UndoEnabled = True
        '
        'ExpansionLengthLabel
        '
        Me.ExpansionLengthLabel.AutoSize = True
        Me.ExpansionLengthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ExpansionLengthLabel.Location = New System.Drawing.Point(470, 135)
        Me.ExpansionLengthLabel.Name = "ExpansionLengthLabel"
        Me.ExpansionLengthLabel.Size = New System.Drawing.Size(73, 17)
        Me.ExpansionLengthLabel.TabIndex = 12
        Me.ExpansionLengthLabel.Text = "&Expansion"
        '
        'ExpansionLengthSingle
        '
        Me.ExpansionLengthSingle.AccessibleDescription = "Diverging transition length"
        Me.ExpansionLengthSingle.AccessibleName = "Expansion Length"
        Me.ExpansionLengthSingle.AutoSize = True
        Me.ExpansionLengthSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ExpansionLengthSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ExpansionLengthSingle.FormatStyle = "0.0###"
        Me.ExpansionLengthSingle.IsReadOnly = False
        Me.ExpansionLengthSingle.Label = "Single Value"
        Me.ExpansionLengthSingle.Location = New System.Drawing.Point(470, 110)
        Me.ExpansionLengthSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.ExpansionLengthSingle.Name = "ExpansionLengthSingle"
        Me.ExpansionLengthSingle.ReadOnlyMsgBox = Nothing
        Me.ExpansionLengthSingle.SiDefaultValue = 0!
        Me.ExpansionLengthSingle.SiMin = -1.401298E-45!
        Me.ExpansionLengthSingle.SiUnits = "m"
        Me.ExpansionLengthSingle.SiValue = 0!
        Me.ExpansionLengthSingle.Size = New System.Drawing.Size(81, 23)
        Me.ExpansionLengthSingle.TabIndex = 13
        Me.ExpansionLengthSingle.UndoEnabled = True
        '
        'ControlLengthLabel
        '
        Me.ControlLengthLabel.AutoSize = True
        Me.ControlLengthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ControlLengthLabel.Location = New System.Drawing.Point(355, 135)
        Me.ControlLengthLabel.Name = "ControlLengthLabel"
        Me.ControlLengthLabel.Size = New System.Drawing.Size(53, 17)
        Me.ControlLengthLabel.TabIndex = 10
        Me.ControlLengthLabel.Text = "Con&trol"
        '
        'ControlLengthSingle
        '
        Me.ControlLengthSingle.AccessibleDescription = "Control section length"
        Me.ControlLengthSingle.AccessibleName = "Control Length"
        Me.ControlLengthSingle.AutoSize = True
        Me.ControlLengthSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ControlLengthSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ControlLengthSingle.FormatStyle = "0.0###"
        Me.ControlLengthSingle.IsReadOnly = False
        Me.ControlLengthSingle.Label = "Single Value"
        Me.ControlLengthSingle.Location = New System.Drawing.Point(355, 110)
        Me.ControlLengthSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.ControlLengthSingle.Name = "ControlLengthSingle"
        Me.ControlLengthSingle.ReadOnlyMsgBox = Nothing
        Me.ControlLengthSingle.SiDefaultValue = 0!
        Me.ControlLengthSingle.SiMin = 0!
        Me.ControlLengthSingle.SiUnits = "m"
        Me.ControlLengthSingle.SiValue = 0!
        Me.ControlLengthSingle.Size = New System.Drawing.Size(81, 23)
        Me.ControlLengthSingle.TabIndex = 11
        Me.ControlLengthSingle.UndoEnabled = True
        '
        'ConvergeLengthLabel
        '
        Me.ConvergeLengthLabel.AutoSize = True
        Me.ConvergeLengthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ConvergeLengthLabel.Location = New System.Drawing.Point(240, 135)
        Me.ConvergeLengthLabel.Name = "ConvergeLengthLabel"
        Me.ConvergeLengthLabel.Size = New System.Drawing.Size(69, 17)
        Me.ConvergeLengthLabel.TabIndex = 8
        Me.ConvergeLengthLabel.Text = "Con&verge"
        '
        'ConvergeLengthSingle
        '
        Me.ConvergeLengthSingle.AccessibleDescription = "Transition length (2.5 to 4.5:1 transisition recommended)"
        Me.ConvergeLengthSingle.AccessibleName = "Converge Distance"
        Me.ConvergeLengthSingle.AutoSize = True
        Me.ConvergeLengthSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ConvergeLengthSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ConvergeLengthSingle.FormatStyle = "0.0###"
        Me.ConvergeLengthSingle.IsReadOnly = False
        Me.ConvergeLengthSingle.Label = "Single Value"
        Me.ConvergeLengthSingle.Location = New System.Drawing.Point(240, 110)
        Me.ConvergeLengthSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.ConvergeLengthSingle.Name = "ConvergeLengthSingle"
        Me.ConvergeLengthSingle.ReadOnlyMsgBox = Nothing
        Me.ConvergeLengthSingle.SiDefaultValue = 0!
        Me.ConvergeLengthSingle.SiMin = -1.401298E-45!
        Me.ConvergeLengthSingle.SiUnits = "m"
        Me.ConvergeLengthSingle.SiValue = 0!
        Me.ConvergeLengthSingle.Size = New System.Drawing.Size(81, 23)
        Me.ConvergeLengthSingle.TabIndex = 9
        Me.ConvergeLengthSingle.UndoEnabled = True
        '
        'GageDistanceLabel
        '
        Me.GageDistanceLabel.AutoSize = True
        Me.GageDistanceLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GageDistanceLabel.Location = New System.Drawing.Point(125, 135)
        Me.GageDistanceLabel.Name = "GageDistanceLabel"
        Me.GageDistanceLabel.Size = New System.Drawing.Size(69, 17)
        Me.GageDistanceLabel.TabIndex = 6
        Me.GageDistanceLabel.Text = "&Approach"
        '
        'GageDistanceSingle
        '
        Me.GageDistanceSingle.AccessibleDescription = "Distance from gage to start of converging transition"
        Me.GageDistanceSingle.AccessibleName = "Approach Distance"
        Me.GageDistanceSingle.AutoSize = True
        Me.GageDistanceSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GageDistanceSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GageDistanceSingle.FormatStyle = "0.0###"
        Me.GageDistanceSingle.IsReadOnly = False
        Me.GageDistanceSingle.Label = "Single Value"
        Me.GageDistanceSingle.Location = New System.Drawing.Point(125, 110)
        Me.GageDistanceSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.GageDistanceSingle.Name = "GageDistanceSingle"
        Me.GageDistanceSingle.ReadOnlyMsgBox = Nothing
        Me.GageDistanceSingle.SiDefaultValue = 0!
        Me.GageDistanceSingle.SiMin = -1.401298E-45!
        Me.GageDistanceSingle.SiUnits = "m"
        Me.GageDistanceSingle.SiValue = 0!
        Me.GageDistanceSingle.Size = New System.Drawing.Size(81, 23)
        Me.GageDistanceSingle.TabIndex = 7
        Me.GageDistanceSingle.UndoEnabled = True
        '
        'SillHeightLabel
        '
        Me.SillHeightLabel.AutoSize = True
        Me.SillHeightLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SillHeightLabel.Location = New System.Drawing.Point(5, 135)
        Me.SillHeightLabel.Name = "SillHeightLabel"
        Me.SillHeightLabel.Size = New System.Drawing.Size(71, 17)
        Me.SillHeightLabel.TabIndex = 4
        Me.SillHeightLabel.Text = "Sill &Height"
        '
        'SillHeightSingle
        '
        Me.SillHeightSingle.AccessibleDescription = "Height of sill above approach channel invert"
        Me.SillHeightSingle.AccessibleName = "Sill Height"
        Me.SillHeightSingle.AutoSize = True
        Me.SillHeightSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SillHeightSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.SillHeightSingle.FormatStyle = "0.0###"
        Me.SillHeightSingle.IsReadOnly = False
        Me.SillHeightSingle.Label = "Single Value"
        Me.SillHeightSingle.Location = New System.Drawing.Point(5, 110)
        Me.SillHeightSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.SillHeightSingle.Name = "SillHeightSingle"
        Me.SillHeightSingle.ReadOnlyMsgBox = Nothing
        Me.SillHeightSingle.SiDefaultValue = 0!
        Me.SillHeightSingle.SiMin = -1.401298E-45!
        Me.SillHeightSingle.SiUnits = "m"
        Me.SillHeightSingle.SiValue = 0!
        Me.SillHeightSingle.Size = New System.Drawing.Size(81, 23)
        Me.SillHeightSingle.TabIndex = 5
        Me.SillHeightSingle.UndoEnabled = True
        '
        'ChannelDepthLabel
        '
        Me.ChannelDepthLabel.AutoSize = True
        Me.ChannelDepthLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ChannelDepthLabel.Location = New System.Drawing.Point(5, 5)
        Me.ChannelDepthLabel.Name = "ChannelDepthLabel"
        Me.ChannelDepthLabel.Size = New System.Drawing.Size(102, 17)
        Me.ChannelDepthLabel.TabIndex = 0
        Me.ChannelDepthLabel.Text = "&Channel Depth"
        '
        'ChannelDepthSingle
        '
        Me.ChannelDepthSingle.AccessibleDescription = "Depth of approach channel, from invert to top of bank of lining"
        Me.ChannelDepthSingle.AccessibleName = "Channel Depth"
        Me.ChannelDepthSingle.AutoSize = True
        Me.ChannelDepthSingle.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ChannelDepthSingle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ChannelDepthSingle.FormatStyle = "0.0###"
        Me.ChannelDepthSingle.IsReadOnly = False
        Me.ChannelDepthSingle.Label = "Single Value"
        Me.ChannelDepthSingle.Location = New System.Drawing.Point(5, 25)
        Me.ChannelDepthSingle.Margin = New System.Windows.Forms.Padding(4)
        Me.ChannelDepthSingle.Name = "ChannelDepthSingle"
        Me.ChannelDepthSingle.ReadOnlyMsgBox = Nothing
        Me.ChannelDepthSingle.SiDefaultValue = 0!
        Me.ChannelDepthSingle.SiMin = -1.401298E-45!
        Me.ChannelDepthSingle.SiUnits = "m"
        Me.ChannelDepthSingle.SiValue = 0!
        Me.ChannelDepthSingle.Size = New System.Drawing.Size(81, 23)
        Me.ChannelDepthSingle.TabIndex = 1
        Me.ChannelDepthSingle.UndoEnabled = True
        '
        'BottomProfileControl
        '
        Me.AccessibleDescription = "View and edit the flume's bottom profile"
        Me.AccessibleName = "Bottom Profile"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.TailwaterLabel)
        Me.Controls.Add(Me.FlumeDescription)
        Me.Controls.Add(Me.RadiusLabel)
        Me.Controls.Add(Me.RadiusSingle)
        Me.Controls.Add(Me.OperatingDepthLabel)
        Me.Controls.Add(Me.OperatingDepthSingle)
        Me.Controls.Add(Me.AutoAdjustButton)
        Me.Controls.Add(Me.MinWspCheckBox)
        Me.Controls.Add(Me.MaxWspCheckBox)
        Me.Controls.Add(Me.TruncatedRampButton)
        Me.Controls.Add(Me.GradualExpansionButton)
        Me.Controls.Add(Me.AbruptExpansionButton)
        Me.Controls.Add(Me.BottomProfileLabel)
        Me.Controls.Add(Me.GageLabel)
        Me.Controls.Add(Me.ExpansionSlopeSingle)
        Me.Controls.Add(Me.ExpansionSlopeLabel)
        Me.Controls.Add(Me.BedDropLabel)
        Me.Controls.Add(Me.BedDropSingle)
        Me.Controls.Add(Me.ExpansionLengthLabel)
        Me.Controls.Add(Me.ExpansionLengthSingle)
        Me.Controls.Add(Me.ControlLengthLabel)
        Me.Controls.Add(Me.ControlLengthSingle)
        Me.Controls.Add(Me.ConvergeLengthLabel)
        Me.Controls.Add(Me.ConvergeLengthSingle)
        Me.Controls.Add(Me.GageDistanceLabel)
        Me.Controls.Add(Me.GageDistanceSingle)
        Me.Controls.Add(Me.SillHeightLabel)
        Me.Controls.Add(Me.SillHeightSingle)
        Me.Controls.Add(Me.ChannelDepthLabel)
        Me.Controls.Add(Me.ChannelDepthSingle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "BottomProfileControl"
        Me.Size = New System.Drawing.Size(713, 140)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChannelDepthSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents ChannelDepthLabel As WinFlume.ctl_Label
    Friend WithEvents SillHeightLabel As WinFlume.ctl_Label
    Friend WithEvents SillHeightSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents GageDistanceLabel As WinFlume.ctl_Label
    Friend WithEvents GageDistanceSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents ConvergeLengthLabel As WinFlume.ctl_Label
    Friend WithEvents ConvergeLengthSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents ControlLengthLabel As WinFlume.ctl_Label
    Friend WithEvents ControlLengthSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents ExpansionLengthLabel As WinFlume.ctl_Label
    Friend WithEvents ExpansionLengthSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents BedDropLabel As WinFlume.ctl_Label
    Friend WithEvents BedDropSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents ExpansionSlopeLabel As WinFlume.ctl_Label
    Friend WithEvents ExpansionSlopeSingle As WinFlume.ctl_Single
    Friend WithEvents GageLabel As WinFlume.ctl_Label
    Friend WithEvents BottomProfileLabel As WinFlume.ctl_Label
    Friend WithEvents AbruptExpansionButton As WinFlume.ctl_RadioButton
    Friend WithEvents GradualExpansionButton As WinFlume.ctl_RadioButton
    Friend WithEvents TruncatedRampButton As WinFlume.ctl_RadioButton
    Friend WithEvents MaxWspCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents MinWspCheckBox As WinFlume.ctl_CheckBox
    Friend WithEvents AutoAdjustButton As WinFlume.ctl_Button
    Friend WithEvents RadiusLabel As WinFlume.ctl_Label
    Friend WithEvents RadiusSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents OperatingDepthLabel As WinFlume.ctl_Label
    Friend WithEvents OperatingDepthSingle As WinFlume.ctl_SingleUnits
    Friend WithEvents FlumeDescription As WinFlume.ctl_TextBox
    Friend WithEvents TailwaterLabel As WinFlume.ctl_Label

End Class
