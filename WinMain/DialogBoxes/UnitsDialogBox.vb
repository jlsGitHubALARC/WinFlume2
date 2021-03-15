
'*************************************************************************************************************
' UnitsDialogBox - UI for changing WinSRFR Units
'*************************************************************************************************************
Imports DataStore

Public Class UnitsDialogBox
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitDialogBox()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents English As DataStore.ctl_RadioButton
    Friend WithEvents Metric As DataStore.ctl_RadioButton
    Friend WithEvents SystemGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents MetricFlowRateLabel As DataStore.ctl_Label
    Friend WithEvents MetricFlowRateUnits As System.Windows.Forms.ComboBox
    Friend WithEvents MetricFieldSlopeLabel As DataStore.ctl_Label
    Friend WithEvents MetricFieldSlopeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents EnglishFieldSlopeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents EnglishFieldSlopeLabel As DataStore.ctl_Label
    Friend WithEvents EnglishFlowRateUnits As System.Windows.Forms.ComboBox
    Friend WithEvents EnglishFlowRateLabel As DataStore.ctl_Label
    Friend WithEvents OkUnitsDialogBox As DataStore.ctl_Button
    Friend WithEvents ApplyUnits As DataStore.ctl_Button
    Friend WithEvents CloseUnitsDialogBox As DataStore.ctl_Button
    Friend WithEvents EnglishUnits As DataStore.ctl_GroupBox
    Friend WithEvents MetricUnits As DataStore.ctl_GroupBox
    Friend WithEvents MetricWaterDepthUnits As System.Windows.Forms.ComboBox
    Friend WithEvents MetricWaterDepthLabel As DataStore.ctl_Label
    Friend WithEvents MetricFurrowShapeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents MetricFurrowShapeLabel As DataStore.ctl_Label
    Friend WithEvents TimeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents TimeUnitsLabel As DataStore.ctl_Label
    Friend WithEvents EnglishWaterDepthUnits As System.Windows.Forms.ComboBox
    Friend WithEvents EnglishWaterDepthLabel As DataStore.ctl_Label
    Friend WithEvents EnglishFurrowShapeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents EnglishFurrowShapeLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.English = New DataStore.ctl_RadioButton
        Me.Metric = New DataStore.ctl_RadioButton
        Me.SystemGroupBox = New DataStore.ctl_GroupBox
        Me.TimeUnits = New System.Windows.Forms.ComboBox
        Me.TimeUnitsLabel = New DataStore.ctl_Label
        Me.EnglishUnits = New DataStore.ctl_GroupBox
        Me.EnglishWaterDepthUnits = New System.Windows.Forms.ComboBox
        Me.EnglishWaterDepthLabel = New DataStore.ctl_Label
        Me.EnglishFurrowShapeUnits = New System.Windows.Forms.ComboBox
        Me.EnglishFurrowShapeLabel = New DataStore.ctl_Label
        Me.EnglishFieldSlopeUnits = New System.Windows.Forms.ComboBox
        Me.EnglishFieldSlopeLabel = New DataStore.ctl_Label
        Me.EnglishFlowRateUnits = New System.Windows.Forms.ComboBox
        Me.EnglishFlowRateLabel = New DataStore.ctl_Label
        Me.MetricUnits = New DataStore.ctl_GroupBox
        Me.MetricWaterDepthUnits = New System.Windows.Forms.ComboBox
        Me.MetricWaterDepthLabel = New DataStore.ctl_Label
        Me.MetricFurrowShapeUnits = New System.Windows.Forms.ComboBox
        Me.MetricFurrowShapeLabel = New DataStore.ctl_Label
        Me.MetricFieldSlopeUnits = New System.Windows.Forms.ComboBox
        Me.MetricFieldSlopeLabel = New DataStore.ctl_Label
        Me.MetricFlowRateUnits = New System.Windows.Forms.ComboBox
        Me.MetricFlowRateLabel = New DataStore.ctl_Label
        Me.OkUnitsDialogBox = New DataStore.ctl_Button
        Me.CloseUnitsDialogBox = New DataStore.ctl_Button
        Me.ApplyUnits = New DataStore.ctl_Button
        Me.SystemGroupBox.SuspendLayout()
        Me.EnglishUnits.SuspendLayout()
        Me.MetricUnits.SuspendLayout()
        Me.SuspendLayout()
        '
        'English
        '
        Me.English.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.English.Location = New System.Drawing.Point(250, 22)
        Me.English.Name = "English"
        Me.English.Size = New System.Drawing.Size(224, 24)
        Me.English.TabIndex = 1
        Me.English.Text = "&English"
        '
        'Metric
        '
        Me.Metric.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metric.Location = New System.Drawing.Point(19, 22)
        Me.Metric.Name = "Metric"
        Me.Metric.Size = New System.Drawing.Size(224, 24)
        Me.Metric.TabIndex = 0
        Me.Metric.Text = "&Metric"
        '
        'SystemGroupBox
        '
        Me.SystemGroupBox.Controls.Add(Me.TimeUnits)
        Me.SystemGroupBox.Controls.Add(Me.TimeUnitsLabel)
        Me.SystemGroupBox.Controls.Add(Me.English)
        Me.SystemGroupBox.Controls.Add(Me.Metric)
        Me.SystemGroupBox.Controls.Add(Me.EnglishUnits)
        Me.SystemGroupBox.Controls.Add(Me.MetricUnits)
        Me.SystemGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SystemGroupBox.Location = New System.Drawing.Point(8, 8)
        Me.SystemGroupBox.Name = "SystemGroupBox"
        Me.SystemGroupBox.Size = New System.Drawing.Size(490, 263)
        Me.SystemGroupBox.TabIndex = 0
        Me.SystemGroupBox.TabStop = False
        Me.SystemGroupBox.Text = "Unit &System"
        '
        'TimeUnits
        '
        Me.TimeUnits.Location = New System.Drawing.Point(392, 221)
        Me.TimeUnits.Name = "TimeUnits"
        Me.TimeUnits.Size = New System.Drawing.Size(80, 24)
        Me.TimeUnits.TabIndex = 5
        '
        'TimeUnitsLabel
        '
        Me.TimeUnitsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeUnitsLabel.Location = New System.Drawing.Point(259, 221)
        Me.TimeUnitsLabel.Name = "TimeUnitsLabel"
        Me.TimeUnitsLabel.Size = New System.Drawing.Size(127, 23)
        Me.TimeUnitsLabel.TabIndex = 4
        Me.TimeUnitsLabel.Text = "&Time Units"
        Me.TimeUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EnglishUnits
        '
        Me.EnglishUnits.Controls.Add(Me.EnglishWaterDepthUnits)
        Me.EnglishUnits.Controls.Add(Me.EnglishWaterDepthLabel)
        Me.EnglishUnits.Controls.Add(Me.EnglishFurrowShapeUnits)
        Me.EnglishUnits.Controls.Add(Me.EnglishFurrowShapeLabel)
        Me.EnglishUnits.Controls.Add(Me.EnglishFieldSlopeUnits)
        Me.EnglishUnits.Controls.Add(Me.EnglishFieldSlopeLabel)
        Me.EnglishUnits.Controls.Add(Me.EnglishFlowRateUnits)
        Me.EnglishUnits.Controls.Add(Me.EnglishFlowRateLabel)
        Me.EnglishUnits.Location = New System.Drawing.Point(250, 52)
        Me.EnglishUnits.Name = "EnglishUnits"
        Me.EnglishUnits.Size = New System.Drawing.Size(230, 155)
        Me.EnglishUnits.TabIndex = 3
        Me.EnglishUnits.TabStop = False
        Me.EnglishUnits.Text = "English Units"
        '
        'EnglishWaterDepthUnits
        '
        Me.EnglishWaterDepthUnits.Location = New System.Drawing.Point(142, 114)
        Me.EnglishWaterDepthUnits.Name = "EnglishWaterDepthUnits"
        Me.EnglishWaterDepthUnits.Size = New System.Drawing.Size(80, 24)
        Me.EnglishWaterDepthUnits.TabIndex = 7
        '
        'EnglishWaterDepthLabel
        '
        Me.EnglishWaterDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishWaterDepthLabel.Location = New System.Drawing.Point(6, 114)
        Me.EnglishWaterDepthLabel.Name = "EnglishWaterDepthLabel"
        Me.EnglishWaterDepthLabel.Size = New System.Drawing.Size(130, 23)
        Me.EnglishWaterDepthLabel.TabIndex = 6
        Me.EnglishWaterDepthLabel.Text = "Water Depth"
        Me.EnglishWaterDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EnglishFurrowShapeUnits
        '
        Me.EnglishFurrowShapeUnits.Location = New System.Drawing.Point(142, 84)
        Me.EnglishFurrowShapeUnits.Name = "EnglishFurrowShapeUnits"
        Me.EnglishFurrowShapeUnits.Size = New System.Drawing.Size(80, 24)
        Me.EnglishFurrowShapeUnits.TabIndex = 5
        '
        'EnglishFurrowShapeLabel
        '
        Me.EnglishFurrowShapeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFurrowShapeLabel.Location = New System.Drawing.Point(6, 84)
        Me.EnglishFurrowShapeLabel.Name = "EnglishFurrowShapeLabel"
        Me.EnglishFurrowShapeLabel.Size = New System.Drawing.Size(130, 23)
        Me.EnglishFurrowShapeLabel.TabIndex = 4
        Me.EnglishFurrowShapeLabel.Text = "Furrow Geometry"
        Me.EnglishFurrowShapeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EnglishFieldSlopeUnits
        '
        Me.EnglishFieldSlopeUnits.Location = New System.Drawing.Point(142, 54)
        Me.EnglishFieldSlopeUnits.Name = "EnglishFieldSlopeUnits"
        Me.EnglishFieldSlopeUnits.Size = New System.Drawing.Size(80, 24)
        Me.EnglishFieldSlopeUnits.TabIndex = 3
        '
        'EnglishFieldSlopeLabel
        '
        Me.EnglishFieldSlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFieldSlopeLabel.Location = New System.Drawing.Point(6, 54)
        Me.EnglishFieldSlopeLabel.Name = "EnglishFieldSlopeLabel"
        Me.EnglishFieldSlopeLabel.Size = New System.Drawing.Size(130, 23)
        Me.EnglishFieldSlopeLabel.TabIndex = 2
        Me.EnglishFieldSlopeLabel.Text = "Field &Slope"
        Me.EnglishFieldSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EnglishFlowRateUnits
        '
        Me.EnglishFlowRateUnits.Location = New System.Drawing.Point(142, 24)
        Me.EnglishFlowRateUnits.Name = "EnglishFlowRateUnits"
        Me.EnglishFlowRateUnits.Size = New System.Drawing.Size(80, 24)
        Me.EnglishFlowRateUnits.TabIndex = 1
        '
        'EnglishFlowRateLabel
        '
        Me.EnglishFlowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFlowRateLabel.Location = New System.Drawing.Point(6, 24)
        Me.EnglishFlowRateLabel.Name = "EnglishFlowRateLabel"
        Me.EnglishFlowRateLabel.Size = New System.Drawing.Size(130, 23)
        Me.EnglishFlowRateLabel.TabIndex = 0
        Me.EnglishFlowRateLabel.Text = "Flow &Rate"
        Me.EnglishFlowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MetricUnits
        '
        Me.MetricUnits.Controls.Add(Me.MetricWaterDepthUnits)
        Me.MetricUnits.Controls.Add(Me.MetricWaterDepthLabel)
        Me.MetricUnits.Controls.Add(Me.MetricFurrowShapeUnits)
        Me.MetricUnits.Controls.Add(Me.MetricFurrowShapeLabel)
        Me.MetricUnits.Controls.Add(Me.MetricFieldSlopeUnits)
        Me.MetricUnits.Controls.Add(Me.MetricFieldSlopeLabel)
        Me.MetricUnits.Controls.Add(Me.MetricFlowRateUnits)
        Me.MetricUnits.Controls.Add(Me.MetricFlowRateLabel)
        Me.MetricUnits.Location = New System.Drawing.Point(10, 52)
        Me.MetricUnits.Name = "MetricUnits"
        Me.MetricUnits.Size = New System.Drawing.Size(230, 155)
        Me.MetricUnits.TabIndex = 2
        Me.MetricUnits.TabStop = False
        Me.MetricUnits.Text = "Metric Units"
        '
        'MetricWaterDepthUnits
        '
        Me.MetricWaterDepthUnits.Location = New System.Drawing.Point(142, 114)
        Me.MetricWaterDepthUnits.Name = "MetricWaterDepthUnits"
        Me.MetricWaterDepthUnits.Size = New System.Drawing.Size(80, 24)
        Me.MetricWaterDepthUnits.TabIndex = 7
        '
        'MetricWaterDepthLabel
        '
        Me.MetricWaterDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricWaterDepthLabel.Location = New System.Drawing.Point(6, 114)
        Me.MetricWaterDepthLabel.Name = "MetricWaterDepthLabel"
        Me.MetricWaterDepthLabel.Size = New System.Drawing.Size(130, 23)
        Me.MetricWaterDepthLabel.TabIndex = 6
        Me.MetricWaterDepthLabel.Text = "Water Depth"
        Me.MetricWaterDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MetricFurrowShapeUnits
        '
        Me.MetricFurrowShapeUnits.Location = New System.Drawing.Point(142, 84)
        Me.MetricFurrowShapeUnits.Name = "MetricFurrowShapeUnits"
        Me.MetricFurrowShapeUnits.Size = New System.Drawing.Size(80, 24)
        Me.MetricFurrowShapeUnits.TabIndex = 5
        '
        'MetricFurrowShapeLabel
        '
        Me.MetricFurrowShapeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricFurrowShapeLabel.Location = New System.Drawing.Point(6, 84)
        Me.MetricFurrowShapeLabel.Name = "MetricFurrowShapeLabel"
        Me.MetricFurrowShapeLabel.Size = New System.Drawing.Size(130, 23)
        Me.MetricFurrowShapeLabel.TabIndex = 4
        Me.MetricFurrowShapeLabel.Text = "Furrow Geometry"
        Me.MetricFurrowShapeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MetricFieldSlopeUnits
        '
        Me.MetricFieldSlopeUnits.Location = New System.Drawing.Point(142, 54)
        Me.MetricFieldSlopeUnits.Name = "MetricFieldSlopeUnits"
        Me.MetricFieldSlopeUnits.Size = New System.Drawing.Size(80, 24)
        Me.MetricFieldSlopeUnits.TabIndex = 3
        '
        'MetricFieldSlopeLabel
        '
        Me.MetricFieldSlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricFieldSlopeLabel.Location = New System.Drawing.Point(6, 54)
        Me.MetricFieldSlopeLabel.Name = "MetricFieldSlopeLabel"
        Me.MetricFieldSlopeLabel.Size = New System.Drawing.Size(130, 23)
        Me.MetricFieldSlopeLabel.TabIndex = 2
        Me.MetricFieldSlopeLabel.Text = "Field &Slope"
        Me.MetricFieldSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MetricFlowRateUnits
        '
        Me.MetricFlowRateUnits.Location = New System.Drawing.Point(142, 24)
        Me.MetricFlowRateUnits.Name = "MetricFlowRateUnits"
        Me.MetricFlowRateUnits.Size = New System.Drawing.Size(80, 24)
        Me.MetricFlowRateUnits.TabIndex = 1
        '
        'MetricFlowRateLabel
        '
        Me.MetricFlowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricFlowRateLabel.Location = New System.Drawing.Point(6, 24)
        Me.MetricFlowRateLabel.Name = "MetricFlowRateLabel"
        Me.MetricFlowRateLabel.Size = New System.Drawing.Size(130, 23)
        Me.MetricFlowRateLabel.TabIndex = 0
        Me.MetricFlowRateLabel.Text = "Flow &Rate"
        Me.MetricFlowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OkUnitsDialogBox
        '
        Me.OkUnitsDialogBox.AccessibleDescription = "OK Button"
        Me.OkUnitsDialogBox.AccessibleName = "OK Button"
        Me.OkUnitsDialogBox.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OkUnitsDialogBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkUnitsDialogBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OkUnitsDialogBox.Location = New System.Drawing.Point(12, 286)
        Me.OkUnitsDialogBox.Name = "OkUnitsDialogBox"
        Me.OkUnitsDialogBox.Size = New System.Drawing.Size(72, 24)
        Me.OkUnitsDialogBox.TabIndex = 1
        Me.OkUnitsDialogBox.Text = "&Ok"
        Me.OkUnitsDialogBox.UseVisualStyleBackColor = False
        '
        'CloseUnitsDialogBox
        '
        Me.CloseUnitsDialogBox.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseUnitsDialogBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseUnitsDialogBox.Location = New System.Drawing.Point(220, 286)
        Me.CloseUnitsDialogBox.Name = "CloseUnitsDialogBox"
        Me.CloseUnitsDialogBox.Size = New System.Drawing.Size(72, 24)
        Me.CloseUnitsDialogBox.TabIndex = 2
        Me.CloseUnitsDialogBox.Text = "&Close"
        '
        'ApplyUnits
        '
        Me.ApplyUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyUnits.Location = New System.Drawing.Point(425, 286)
        Me.ApplyUnits.Name = "ApplyUnits"
        Me.ApplyUnits.Size = New System.Drawing.Size(72, 24)
        Me.ApplyUnits.TabIndex = 3
        Me.ApplyUnits.Text = "&Apply"
        '
        'UnitsDialogBox
        '
        Me.AcceptButton = Me.OkUnitsDialogBox
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CloseUnitsDialogBox
        Me.ClientSize = New System.Drawing.Size(509, 321)
        Me.Controls.Add(Me.ApplyUnits)
        Me.Controls.Add(Me.CloseUnitsDialogBox)
        Me.Controls.Add(Me.OkUnitsDialogBox)
        Me.Controls.Add(Me.SystemGroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UnitsDialogBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Unit System & Options"
        Me.SystemGroupBox.ResumeLayout(False)
        Me.EnglishUnits.ResumeLayout(False)
        Me.MetricUnits.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    Private mUnits As UnitsSystem = UnitsSystem.Instance()
    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Methods "

    Public Sub InitDialogBox()

        Me.Text = mDictionary.ControlText(Me)

        Dim idx As Integer
        '
        ' Time Units
        '
        TimeUnits.Items.Clear()
        idx = 0
        For Each str As String In UnitsText
            If ((Units.SystemTimeLow <= idx) And (idx <= Units.SystemTimeHigh)) Then
                TimeUnits.Items.Add(str)
            End If
            idx += 1
        Next
        TimeUnits.SelectedIndex = mUnits.TimeUnits - Units.SystemTimeLow
        '
        ' Metric Options
        '
        MetricFlowRateUnits.Items.Clear()
        idx = 0
        For Each str As String In UnitsText
            If ((Units.FlowRateMetricLow <= idx) And (idx <= Units.FlowRateMetricHigh)) Then
                MetricFlowRateUnits.Items.Add(str)
            End If
            idx += 1
        Next
        MetricFlowRateUnits.SelectedIndex = mUnits.MetricFlowRateUnits - Units.FlowRateMetricLow

        MetricFieldSlopeUnits.Items.Clear()
        idx = 0
        For Each str As String In UnitsText
            If ((Units.SlopeMetricLow <= idx) And (idx <= Units.SlopeMetricHigh)) Then
                MetricFieldSlopeUnits.Items.Add(str)
            End If
            idx += 1
        Next
        MetricFieldSlopeUnits.SelectedIndex = mUnits.MetricSlopeUnits - Units.SlopeMetricLow

        MetricWaterDepthUnits.Items.Clear()
        MetricWaterDepthUnits.Items.Add("m")
        MetricWaterDepthUnits.Items.Add("cm")
        MetricWaterDepthUnits.Items.Add("mm")
        If (mUnits.MetricDepthUnits = Units.Meters) Then
            MetricWaterDepthUnits.SelectedIndex = 0
        ElseIf (mUnits.MetricDepthUnits = Units.Centimeters) Then
            MetricWaterDepthUnits.SelectedIndex = 1
        Else
            MetricWaterDepthUnits.SelectedIndex = 2
        End If

        MetricFurrowShapeUnits.Items.Clear()
        MetricFurrowShapeUnits.Items.Add("m")
        MetricFurrowShapeUnits.Items.Add("cm")
        MetricFurrowShapeUnits.Items.Add("mm")
        If (mUnits.MetricShapeUnits = Units.Meters) Then
            MetricFurrowShapeUnits.SelectedIndex = 0
        ElseIf (mUnits.MetricShapeUnits = Units.Centimeters) Then
            MetricFurrowShapeUnits.SelectedIndex = 1
        Else
            MetricFurrowShapeUnits.SelectedIndex = 2
        End If
        '
        ' English Options
        '
        EnglishFlowRateUnits.Items.Clear()
        idx = 0
        For Each str As String In UnitsText
            If ((Units.FlowRateEnglishLow <= idx) And (idx <= Units.FlowRateEnglishHigh)) Then
                EnglishFlowRateUnits.Items.Add(str)
            End If
            idx += 1
        Next
        EnglishFlowRateUnits.SelectedIndex = mUnits.EnglishFlowRateUnits - Units.FlowRateEnglishLow

        EnglishFieldSlopeUnits.Items.Clear()
        idx = 0
        For Each str As String In UnitsText
            If ((Units.SlopeEnglishLow <= idx) And (idx <= Units.SlopeEnglishHigh)) Then
                EnglishFieldSlopeUnits.Items.Add(str)
            End If
            idx += 1
        Next
        EnglishFieldSlopeUnits.SelectedIndex = mUnits.EnglishSlopeUnits - Units.SlopeEnglishLow

        EnglishWaterDepthUnits.Items.Clear()
        EnglishWaterDepthUnits.Items.Add("ft")
        EnglishWaterDepthUnits.Items.Add("in")
        If (mUnits.EnglishDepthUnits = Units.Feet) Then
            EnglishWaterDepthUnits.SelectedIndex = 0
        Else
            EnglishWaterDepthUnits.SelectedIndex = 1
        End If

        EnglishFurrowShapeUnits.Items.Clear()
        EnglishFurrowShapeUnits.Items.Add("ft")
        EnglishFurrowShapeUnits.Items.Add("in")
        If (mUnits.EnglishShapeUnits = Units.Feet) Then
            EnglishFurrowShapeUnits.SelectedIndex = 0
        Else
            EnglishFurrowShapeUnits.SelectedIndex = 1
        End If
        '
        ' Unit System
        '
        Select Case mUnits.UnitSystem
            Case UnitSystems.Metric
                Metric.Checked = True
                MetricUnits.Enabled = True
                EnglishUnits.Enabled = False
            Case UnitSystems.English
                English.Checked = True
                EnglishUnits.Enabled = True
                MetricUnits.Enabled = False
            Case Else
                Debug.Assert(False, "Invalid Unit System")
        End Select
        '
        ' Buttons
        '
        UpdateApply(False)

    End Sub

    Private Sub UpdateApply(ByVal _enable As Boolean)
        If (_enable) Then
            OkUnitsDialogBox.Enabled = True
            ApplyUnits.Enabled = True
        Else
            OkUnitsDialogBox.Enabled = False
            ApplyUnits.Enabled = False
            CloseUnitsDialogBox.Text = "&Close"
        End If
    End Sub

    Private Sub SaveUpdates()

        ' Only save updates if changes were made
        If (ApplyUnits.Enabled) Then

            Dim saveCursor As Cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor

            ' Disable Apply button
            UpdateApply(False)

            ' Unit System
            If (Metric.Checked) Then
                mUnits.UnitSystem = UnitSystems.Metric
            Else
                mUnits.UnitSystem = UnitSystems.English
            End If

            ' Metric Options
            mUnits.MetricFlowRateUnits = CType((MetricFlowRateUnits.SelectedIndex + Units.FlowRateMetricLow), Units)
            mUnits.MetricSlopeUnits = CType((MetricFieldSlopeUnits.SelectedIndex + Units.SlopeMetricLow), Units)

            If (MetricWaterDepthUnits.SelectedIndex = 0) Then
                mUnits.MetricDepthUnits = Units.Meters
            ElseIf (MetricWaterDepthUnits.SelectedIndex = 1) Then
                mUnits.MetricDepthUnits = Units.Centimeters
            Else
                mUnits.MetricDepthUnits = Units.Millimeters
            End If

            If (MetricFurrowShapeUnits.SelectedIndex = 0) Then
                mUnits.MetricShapeUnits = Units.Meters
            ElseIf (MetricFurrowShapeUnits.SelectedIndex = 1) Then
                mUnits.MetricShapeUnits = Units.Centimeters
            Else
                mUnits.MetricShapeUnits = Units.Millimeters
            End If

            ' English Options
            mUnits.EnglishFlowRateUnits = CType((EnglishFlowRateUnits.SelectedIndex + Units.FlowRateEnglishLow), Units)
            mUnits.EnglishSlopeUnits = CType((EnglishFieldSlopeUnits.SelectedIndex + Units.SlopeEnglishLow), Units)

            If (EnglishWaterDepthUnits.SelectedIndex = 0) Then
                mUnits.EnglishDepthUnits = Units.Feet
            Else
                mUnits.EnglishDepthUnits = Units.Inches
            End If

            If (EnglishFurrowShapeUnits.SelectedIndex = 0) Then
                mUnits.EnglishShapeUnits = Units.Feet
            Else
                mUnits.EnglishShapeUnits = Units.Inches
            End If

            ' Time Units
            mUnits.TimeUnits = CType((TimeUnits.SelectedIndex + Units.SystemTimeLow), Units)

            mUnits.RaiseUnitsSystemEvent()

            Me.Cursor = saveCursor

        End If

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub Metric_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Metric.CheckedChanged
        If (Metric.Checked) Then
            MetricUnits.Enabled = True
            EnglishUnits.Enabled = False
            UpdateApply(True)
        End If
    End Sub

    Private Sub English_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles English.CheckedChanged
        If (English.Checked) Then
            EnglishUnits.Enabled = True
            MetricUnits.Enabled = False
            UpdateApply(True)
        End If
    End Sub

    'Private Sub UnitsDialogBox_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    'Handles MyBase.Closed
    '    SaveUpdates()
    'End Sub

    Private Shadows Sub Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        e.Cancel = True ' Cancels closing event
        Me.Hide()
    End Sub

    Private Sub OkUnitsDialogBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkUnitsDialogBox.Click
        SaveUpdates()
        Me.Hide()
    End Sub

    Private Sub CancelUnitsDialogBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CloseUnitsDialogBox.Click
        InitDialogBox()
        Me.Hide()
    End Sub

    Private Sub ApplyUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ApplyUnits.Click
        SaveUpdates()
    End Sub

    Private Sub MetricFlowRateUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetricFlowRateUnits.SelectedIndexChanged
        UpdateApply(True)
    End Sub

    Private Sub MetricFieldSlopeUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetricFieldSlopeUnits.SelectedIndexChanged
        UpdateApply(True)
    End Sub

    Private Sub MetricFurrowShapeUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetricFurrowShapeUnits.SelectedIndexChanged
        UpdateApply(True)
    End Sub

    Private Sub MetricWaterDepthUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetricWaterDepthUnits.SelectedIndexChanged
        UpdateApply(True)
    End Sub

    Private Sub EnglishFlowRateUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EnglishFlowRateUnits.SelectedIndexChanged
        UpdateApply(True)
    End Sub

    Private Sub EnglishFieldSlopeUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EnglishFieldSlopeUnits.SelectedIndexChanged
        UpdateApply(True)
    End Sub

    Private Sub EnglishFurrowShapeUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EnglishFurrowShapeUnits.SelectedIndexChanged
        UpdateApply(True)
    End Sub

    Private Sub EnglishWaterDepthUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EnglishWaterDepthUnits.SelectedIndexChanged
        UpdateApply(True)
    End Sub

    Private Sub TimeUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TimeUnits.SelectedIndexChanged
        UpdateApply(True)
    End Sub

    Private Sub UnitsDialogBox_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:UserPreferences")
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:UserPreferences")
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class
