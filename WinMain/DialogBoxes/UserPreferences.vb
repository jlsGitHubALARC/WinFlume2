
'*************************************************************************************************************
' UserPreferences
'*************************************************************************************************************
Imports DataStore
Imports System.IO

Imports Microsoft.Win32 'For Registry Access

Public Class UserPreferences
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Private Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeUserPreferences()

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
    Friend WithEvents OkayButton As DataStore.ctl_Button
    Friend Shadows WithEvents CancelButton As DataStore.ctl_Button
    Friend WithEvents UserPreferenceToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ShowGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents EnglishFieldSlopeLabel As DataStore.ctl_Label
    Friend WithEvents EnglishFlowRateLabel As DataStore.ctl_Label
    Friend WithEvents MectricFieldSlopeLabel As DataStore.ctl_Label
    Friend WithEvents MetricFlowRateLabel As DataStore.ctl_Label
    Friend WithEvents UserPreferenceTabs As DataStore.ctl_TabControl
    Friend WithEvents FarmName As System.Windows.Forms.TextBox
    Friend WithEvents FarmOwner As System.Windows.Forms.TextBox
    Friend WithEvents DefaultEvaluatorLabel As DataStore.ctl_Label
    Friend WithEvents Evaluator As System.Windows.Forms.TextBox
    Friend WithEvents TimeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents StartupTab As System.Windows.Forms.TabPage
    Friend WithEvents UnitsTab As System.Windows.Forms.TabPage
    Friend WithEvents EnglishFieldSlopeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents EnglishFlowRateUnits As System.Windows.Forms.ComboBox
    Friend WithEvents MetricFieldSlopeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents MetricFlowRateUnits As System.Windows.Forms.ComboBox
    Friend WithEvents English As DataStore.ctl_RadioButton
    Friend WithEvents Metric As DataStore.ctl_RadioButton
    Friend WithEvents GraphsOnly As DataStore.ctl_RadioButton
    Friend WithEvents FilesTab As System.Windows.Forms.TabPage
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents PortraitPage As DataStore.ctl_RadioButton
    Friend WithEvents ResetLogFolderButton As DataStore.ctl_Button
    Friend WithEvents BrowseLogFolderButton As DataStore.ctl_Button
    Friend WithEvents LogFolder As System.Windows.Forms.TextBox
    Friend WithEvents LineColorBox As DataStore.ctl_GroupBox
    Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents Color1Sample As System.Windows.Forms.Panel
    Friend WithEvents Color1Button As DataStore.ctl_Button
    Friend WithEvents Color2Button As DataStore.ctl_Button
    Friend WithEvents Color2Sample As System.Windows.Forms.Panel
    Friend WithEvents Color3Button As DataStore.ctl_Button
    Friend WithEvents Color3Sample As System.Windows.Forms.Panel
    Friend WithEvents Color4Button As DataStore.ctl_Button
    Friend WithEvents Color4Sample As System.Windows.Forms.Panel
    Friend WithEvents Color5Button As DataStore.ctl_Button
    Friend WithEvents Color5Sample As System.Windows.Forms.Panel
    Friend WithEvents Color9Button As DataStore.ctl_Button
    Friend WithEvents Color8Button As DataStore.ctl_Button
    Friend WithEvents Color7Button As DataStore.ctl_Button
    Friend WithEvents Color6Button As DataStore.ctl_Button
    Friend WithEvents Color9Sample As System.Windows.Forms.Panel
    Friend WithEvents Color8Sample As System.Windows.Forms.Panel
    Friend WithEvents Color6Sample As System.Windows.Forms.Panel
    Friend WithEvents Color7Sample As System.Windows.Forms.Panel
    Friend WithEvents ViewsTab As System.Windows.Forms.TabPage
    Friend WithEvents DialogsTab As System.Windows.Forms.TabPage
    Friend WithEvents DefaultValuesGroup As DataStore.ctl_GroupBox
    Friend WithEvents UnconditionallyAccept As DataStore.ctl_RadioButton
    Friend WithEvents RequireConfirmation As DataStore.ctl_RadioButton
    Friend WithEvents HelpSuggestedDefaults As DataStore.ctl_Label
    Friend WithEvents GraphsTab As System.Windows.Forms.TabPage
    Friend WithEvents ContoursTab As System.Windows.Forms.TabPage
    Friend WithEvents ColorScaleButton As DataStore.ctl_RadioButton
    Friend WithEvents GrayScaleButton As DataStore.ctl_RadioButton
    Friend WithEvents UserDefinedButton As DataStore.ctl_RadioButton
    Friend WithEvents NoFillButton As DataStore.ctl_RadioButton
    Friend WithEvents ContourOptionsBox As DataStore.ctl_GroupBox
    Friend WithEvents DisplayTitleButton As DataStore.ctl_CheckParameter
    Friend WithEvents DisplaySubtitlesButton As DataStore.ctl_CheckParameter
    Friend WithEvents DisplayAxisLabelsButton As DataStore.ctl_CheckParameter
    Friend WithEvents ColorScalePanel As DataStore.ctl_Panel
    Friend WithEvents FillColor90up As System.Windows.Forms.Panel
    Friend WithEvents FillColor8090 As System.Windows.Forms.Panel
    Friend WithEvents FillColor7080 As System.Windows.Forms.Panel
    Friend WithEvents FillColor6070 As System.Windows.Forms.Panel
    Friend WithEvents FillColor5060 As System.Windows.Forms.Panel
    Friend WithEvents FillColor4050 As System.Windows.Forms.Panel
    Friend WithEvents FillColor3040 As System.Windows.Forms.Panel
    Friend WithEvents FillColor2030 As System.Windows.Forms.Panel
    Friend WithEvents FillColor1020 As System.Windows.Forms.Panel
    Friend WithEvents FillColor0010 As System.Windows.Forms.Panel
    Friend WithEvents GrayScalePanel As DataStore.ctl_Panel
    Friend WithEvents UserDefinedPanel As DataStore.ctl_Panel
    Friend WithEvents UserDefinedInstructions As DataStore.ctl_Label
    Friend WithEvents FillUser0010 As System.Windows.Forms.Button
    Friend WithEvents FillGray90up As System.Windows.Forms.Panel
    Friend WithEvents FillGray8090 As System.Windows.Forms.Panel
    Friend WithEvents FillGray7080 As System.Windows.Forms.Panel
    Friend WithEvents FillGray6070 As System.Windows.Forms.Panel
    Friend WithEvents FillGray5060 As System.Windows.Forms.Panel
    Friend WithEvents FillGray4050 As System.Windows.Forms.Panel
    Friend WithEvents FillGray3040 As System.Windows.Forms.Panel
    Friend WithEvents FillGray2030 As System.Windows.Forms.Panel
    Friend WithEvents FillGray1020 As System.Windows.Forms.Panel
    Friend WithEvents FillGray0010 As System.Windows.Forms.Panel
    Friend WithEvents FillUser90up As System.Windows.Forms.Button
    Friend WithEvents FillUser8090 As System.Windows.Forms.Button
    Friend WithEvents FillUser7080 As System.Windows.Forms.Button
    Friend WithEvents FillUser6070 As System.Windows.Forms.Button
    Friend WithEvents FillUser5060 As System.Windows.Forms.Button
    Friend WithEvents FillUser4050 As System.Windows.Forms.Button
    Friend WithEvents FillUser3040 As System.Windows.Forms.Button
    Friend WithEvents FillUser2030 As System.Windows.Forms.Button
    Friend WithEvents FillUser1020 As System.Windows.Forms.Button
    Friend WithEvents PresetUserToColorScale As DataStore.ctl_Button
    Friend WithEvents PresetUserToGrayScale As DataStore.ctl_Button
    Friend WithEvents DisplayContourKeyButton As DataStore.ctl_CheckParameter
    Friend WithEvents DisplayContourLabelsButton As DataStore.ctl_CheckParameter
    Friend WithEvents ShowSimulationAnimationButton As DataStore.ctl_CheckParameter
    Friend WithEvents DisplayContourPointsButton As DataStore.ctl_CheckParameter
    Friend WithEvents GraphsOptionsHelp As System.Windows.Forms.TextBox
    Friend WithEvents ContoursOptionsHelp As System.Windows.Forms.TextBox
    Friend WithEvents GraphOptionsBox As DataStore.ctl_GroupBox
    Friend WithEvents AutoOpenPreviousFile As DataStore.ctl_CheckParameter
    Friend WithEvents DisplayMinorContoursButton As DataStore.ctl_CheckParameter
    Friend WithEvents StandardContoursButton As DataStore.ctl_RadioButton
    Friend WithEvents PrecisionContoursButton As DataStore.ctl_RadioButton
    Friend WithEvents FontLabel As DataStore.ctl_Label
    Friend WithEvents InstalledFonts As System.Windows.Forms.ComboBox
    Friend WithEvents FontSample As System.Windows.Forms.TextBox
    Friend WithEvents SizeLabel As DataStore.ctl_Label
    Friend WithEvents FontSize As System.Windows.Forms.ComboBox
    Friend WithEvents LogDiagFolderBox As DataStore.ctl_GroupBox
    Friend WithEvents ProjectBox As DataStore.ctl_GroupBox
    Friend WithEvents UnitsGroup As DataStore.ctl_GroupBox
    Friend WithEvents EnglishBox As DataStore.ctl_GroupBox
    Friend WithEvents MetricBox As DataStore.ctl_GroupBox
    Friend WithEvents ResultsGroup As DataStore.ctl_GroupBox
    Friend WithEvents ContourColorsGroup As DataStore.ctl_GroupBox
    Friend WithEvents ProjectOwnerLabel As System.Windows.Forms.Label
    Friend WithEvents ProjectNameLabel As System.Windows.Forms.Label
    Friend WithEvents DataFolderBox As DataStore.ctl_GroupBox
    Friend WithEvents ResetDataFolderButton As DataStore.ctl_Button
    Friend WithEvents BrowseDataFolderButton As DataStore.ctl_Button
    Friend WithEvents DataFolder As System.Windows.Forms.TextBox
    Friend WithEvents MetricWaterDepthUnits As System.Windows.Forms.ComboBox
    Friend WithEvents MetricFurrowShapeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents MetricWaterDepthLabel As DataStore.ctl_Label
    Friend WithEvents MetricFurrowShapeLabel As DataStore.ctl_Label
    Friend WithEvents EnglishWaterDepthUnits As System.Windows.Forms.ComboBox
    Friend WithEvents EnglishFurrowShapeUnits As System.Windows.Forms.ComboBox
    Friend WithEvents EnglishWaterDepthLabel As DataStore.ctl_Label
    Friend WithEvents EnglishFurrowShapeLabel As DataStore.ctl_Label
    Friend WithEvents DefaultTimeUnitsLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.OkayButton = New DataStore.ctl_Button
        Me.CancelButton = New DataStore.ctl_Button
        Me.UserPreferenceToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimeUnits = New System.Windows.Forms.ComboBox
        Me.EnglishFieldSlopeUnits = New System.Windows.Forms.ComboBox
        Me.EnglishFlowRateUnits = New System.Windows.Forms.ComboBox
        Me.MetricFieldSlopeUnits = New System.Windows.Forms.ComboBox
        Me.MetricFlowRateUnits = New System.Windows.Forms.ComboBox
        Me.English = New DataStore.ctl_RadioButton
        Me.Metric = New DataStore.ctl_RadioButton
        Me.FarmName = New System.Windows.Forms.TextBox
        Me.FarmOwner = New System.Windows.Forms.TextBox
        Me.MetricWaterDepthUnits = New System.Windows.Forms.ComboBox
        Me.MetricFurrowShapeUnits = New System.Windows.Forms.ComboBox
        Me.EnglishWaterDepthUnits = New System.Windows.Forms.ComboBox
        Me.EnglishFurrowShapeUnits = New System.Windows.Forms.ComboBox
        Me.FilesTab = New System.Windows.Forms.TabPage
        Me.DataFolderBox = New DataStore.ctl_GroupBox
        Me.ResetDataFolderButton = New DataStore.ctl_Button
        Me.BrowseDataFolderButton = New DataStore.ctl_Button
        Me.DataFolder = New System.Windows.Forms.TextBox
        Me.LogDiagFolderBox = New DataStore.ctl_GroupBox
        Me.ResetLogFolderButton = New DataStore.ctl_Button
        Me.BrowseLogFolderButton = New DataStore.ctl_Button
        Me.LogFolder = New System.Windows.Forms.TextBox
        Me.ShowGroupBox = New DataStore.ctl_GroupBox
        Me.StartupTab = New System.Windows.Forms.TabPage
        Me.AutoOpenPreviousFile = New DataStore.ctl_CheckParameter
        Me.Evaluator = New System.Windows.Forms.TextBox
        Me.DefaultEvaluatorLabel = New DataStore.ctl_Label
        Me.ProjectBox = New DataStore.ctl_GroupBox
        Me.ProjectOwnerLabel = New System.Windows.Forms.Label
        Me.ProjectNameLabel = New System.Windows.Forms.Label
        Me.UnitsTab = New System.Windows.Forms.TabPage
        Me.DefaultTimeUnitsLabel = New DataStore.ctl_Label
        Me.UnitsGroup = New DataStore.ctl_GroupBox
        Me.EnglishBox = New DataStore.ctl_GroupBox
        Me.EnglishWaterDepthLabel = New DataStore.ctl_Label
        Me.EnglishFurrowShapeLabel = New DataStore.ctl_Label
        Me.EnglishFieldSlopeLabel = New DataStore.ctl_Label
        Me.EnglishFlowRateLabel = New DataStore.ctl_Label
        Me.MetricBox = New DataStore.ctl_GroupBox
        Me.MetricWaterDepthLabel = New DataStore.ctl_Label
        Me.MetricFurrowShapeLabel = New DataStore.ctl_Label
        Me.MectricFieldSlopeLabel = New DataStore.ctl_Label
        Me.MetricFlowRateLabel = New DataStore.ctl_Label
        Me.UserPreferenceTabs = New DataStore.ctl_TabControl
        Me.ViewsTab = New System.Windows.Forms.TabPage
        Me.ShowSimulationAnimationButton = New DataStore.ctl_CheckParameter
        Me.ResultsGroup = New DataStore.ctl_GroupBox
        Me.GraphsOnly = New DataStore.ctl_RadioButton
        Me.PortraitPage = New DataStore.ctl_RadioButton
        Me.DialogsTab = New System.Windows.Forms.TabPage
        Me.DefaultValuesGroup = New DataStore.ctl_GroupBox
        Me.HelpSuggestedDefaults = New DataStore.ctl_Label
        Me.RequireConfirmation = New DataStore.ctl_RadioButton
        Me.UnconditionallyAccept = New DataStore.ctl_RadioButton
        Me.GraphsTab = New System.Windows.Forms.TabPage
        Me.GraphOptionsBox = New DataStore.ctl_GroupBox
        Me.SizeLabel = New DataStore.ctl_Label
        Me.FontSize = New System.Windows.Forms.ComboBox
        Me.FontSample = New System.Windows.Forms.TextBox
        Me.InstalledFonts = New System.Windows.Forms.ComboBox
        Me.FontLabel = New DataStore.ctl_Label
        Me.GraphsOptionsHelp = New System.Windows.Forms.TextBox
        Me.DisplayAxisLabelsButton = New DataStore.ctl_CheckParameter
        Me.DisplaySubtitlesButton = New DataStore.ctl_CheckParameter
        Me.DisplayTitleButton = New DataStore.ctl_CheckParameter
        Me.LineColorBox = New DataStore.ctl_GroupBox
        Me.Color9Sample = New System.Windows.Forms.Panel
        Me.Color8Sample = New System.Windows.Forms.Panel
        Me.Color7Sample = New System.Windows.Forms.Panel
        Me.Color6Sample = New System.Windows.Forms.Panel
        Me.Color9Button = New DataStore.ctl_Button
        Me.Color8Button = New DataStore.ctl_Button
        Me.Color7Button = New DataStore.ctl_Button
        Me.Color6Button = New DataStore.ctl_Button
        Me.Color5Button = New DataStore.ctl_Button
        Me.Color5Sample = New System.Windows.Forms.Panel
        Me.Color4Button = New DataStore.ctl_Button
        Me.Color4Sample = New System.Windows.Forms.Panel
        Me.Color3Button = New DataStore.ctl_Button
        Me.Color3Sample = New System.Windows.Forms.Panel
        Me.Color2Button = New DataStore.ctl_Button
        Me.Color2Sample = New System.Windows.Forms.Panel
        Me.Color1Button = New DataStore.ctl_Button
        Me.Color1Sample = New System.Windows.Forms.Panel
        Me.ContoursTab = New System.Windows.Forms.TabPage
        Me.ContourOptionsBox = New DataStore.ctl_GroupBox
        Me.PrecisionContoursButton = New DataStore.ctl_RadioButton
        Me.StandardContoursButton = New DataStore.ctl_RadioButton
        Me.DisplayMinorContoursButton = New DataStore.ctl_CheckParameter
        Me.ContoursOptionsHelp = New System.Windows.Forms.TextBox
        Me.DisplayContourPointsButton = New DataStore.ctl_CheckParameter
        Me.DisplayContourLabelsButton = New DataStore.ctl_CheckParameter
        Me.DisplayContourKeyButton = New DataStore.ctl_CheckParameter
        Me.ContourColorsGroup = New DataStore.ctl_GroupBox
        Me.GrayScalePanel = New DataStore.ctl_Panel
        Me.FillGray90up = New System.Windows.Forms.Panel
        Me.FillGray8090 = New System.Windows.Forms.Panel
        Me.FillGray7080 = New System.Windows.Forms.Panel
        Me.FillGray6070 = New System.Windows.Forms.Panel
        Me.FillGray5060 = New System.Windows.Forms.Panel
        Me.FillGray4050 = New System.Windows.Forms.Panel
        Me.FillGray3040 = New System.Windows.Forms.Panel
        Me.FillGray2030 = New System.Windows.Forms.Panel
        Me.FillGray1020 = New System.Windows.Forms.Panel
        Me.FillGray0010 = New System.Windows.Forms.Panel
        Me.ColorScalePanel = New DataStore.ctl_Panel
        Me.FillColor90up = New System.Windows.Forms.Panel
        Me.FillColor8090 = New System.Windows.Forms.Panel
        Me.FillColor7080 = New System.Windows.Forms.Panel
        Me.FillColor6070 = New System.Windows.Forms.Panel
        Me.FillColor5060 = New System.Windows.Forms.Panel
        Me.FillColor4050 = New System.Windows.Forms.Panel
        Me.FillColor3040 = New System.Windows.Forms.Panel
        Me.FillColor2030 = New System.Windows.Forms.Panel
        Me.FillColor1020 = New System.Windows.Forms.Panel
        Me.FillColor0010 = New System.Windows.Forms.Panel
        Me.NoFillButton = New DataStore.ctl_RadioButton
        Me.UserDefinedButton = New DataStore.ctl_RadioButton
        Me.GrayScaleButton = New DataStore.ctl_RadioButton
        Me.ColorScaleButton = New DataStore.ctl_RadioButton
        Me.UserDefinedPanel = New DataStore.ctl_Panel
        Me.PresetUserToGrayScale = New DataStore.ctl_Button
        Me.PresetUserToColorScale = New DataStore.ctl_Button
        Me.UserDefinedInstructions = New DataStore.ctl_Label
        Me.FillUser90up = New System.Windows.Forms.Button
        Me.FillUser8090 = New System.Windows.Forms.Button
        Me.FillUser7080 = New System.Windows.Forms.Button
        Me.FillUser6070 = New System.Windows.Forms.Button
        Me.FillUser5060 = New System.Windows.Forms.Button
        Me.FillUser4050 = New System.Windows.Forms.Button
        Me.FillUser3040 = New System.Windows.Forms.Button
        Me.FillUser2030 = New System.Windows.Forms.Button
        Me.FillUser1020 = New System.Windows.Forms.Button
        Me.FillUser0010 = New System.Windows.Forms.Button
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.ColorDialog = New System.Windows.Forms.ColorDialog
        Me.FilesTab.SuspendLayout()
        Me.DataFolderBox.SuspendLayout()
        Me.LogDiagFolderBox.SuspendLayout()
        Me.StartupTab.SuspendLayout()
        Me.ProjectBox.SuspendLayout()
        Me.UnitsTab.SuspendLayout()
        Me.UnitsGroup.SuspendLayout()
        Me.EnglishBox.SuspendLayout()
        Me.MetricBox.SuspendLayout()
        Me.UserPreferenceTabs.SuspendLayout()
        Me.ViewsTab.SuspendLayout()
        Me.ResultsGroup.SuspendLayout()
        Me.DialogsTab.SuspendLayout()
        Me.DefaultValuesGroup.SuspendLayout()
        Me.GraphsTab.SuspendLayout()
        Me.GraphOptionsBox.SuspendLayout()
        Me.LineColorBox.SuspendLayout()
        Me.ContoursTab.SuspendLayout()
        Me.ContourOptionsBox.SuspendLayout()
        Me.ContourColorsGroup.SuspendLayout()
        Me.GrayScalePanel.SuspendLayout()
        Me.ColorScalePanel.SuspendLayout()
        Me.UserDefinedPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'OkayButton
        '
        Me.OkayButton.AccessibleDescription = "Saves all changes made to user preferences."
        Me.OkayButton.AccessibleName = "OK Button"
        Me.OkayButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OkayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkayButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OkayButton.Location = New System.Drawing.Point(21, 336)
        Me.OkayButton.Name = "OkayButton"
        Me.OkayButton.Size = New System.Drawing.Size(80, 24)
        Me.OkayButton.TabIndex = 10
        Me.OkayButton.Text = "&Ok"
        Me.OkayButton.UseVisualStyleBackColor = False
        '
        'CancelButton
        '
        Me.CancelButton.AccessibleDescription = "Cancel all changes made to user preferences."
        Me.CancelButton.AccessibleName = "Cancel Button"
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.Location = New System.Drawing.Point(412, 336)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(80, 24)
        Me.CancelButton.TabIndex = 11
        Me.CancelButton.Text = "&Cancel"
        '
        'TimeUnits
        '
        Me.TimeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TimeUnits.ItemHeight = 16
        Me.TimeUnits.Location = New System.Drawing.Point(390, 246)
        Me.TimeUnits.Name = "TimeUnits"
        Me.TimeUnits.Size = New System.Drawing.Size(88, 24)
        Me.TimeUnits.TabIndex = 3
        Me.UserPreferenceToolTip.SetToolTip(Me.TimeUnits, "Default Time Units")
        '
        'EnglishFieldSlopeUnits
        '
        Me.EnglishFieldSlopeUnits.AccessibleDescription = "English Field Slope"
        Me.EnglishFieldSlopeUnits.AccessibleName = "Select default English field slope units."
        Me.EnglishFieldSlopeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EnglishFieldSlopeUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFieldSlopeUnits.ItemHeight = 16
        Me.EnglishFieldSlopeUnits.Location = New System.Drawing.Point(132, 54)
        Me.EnglishFieldSlopeUnits.Name = "EnglishFieldSlopeUnits"
        Me.EnglishFieldSlopeUnits.Size = New System.Drawing.Size(88, 24)
        Me.EnglishFieldSlopeUnits.TabIndex = 3
        Me.UserPreferenceToolTip.SetToolTip(Me.EnglishFieldSlopeUnits, "Default English Field Slope")
        '
        'EnglishFlowRateUnits
        '
        Me.EnglishFlowRateUnits.AccessibleDescription = "English Flow Rate"
        Me.EnglishFlowRateUnits.AccessibleName = "Select default English flow rate units."
        Me.EnglishFlowRateUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EnglishFlowRateUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFlowRateUnits.ItemHeight = 16
        Me.EnglishFlowRateUnits.Location = New System.Drawing.Point(132, 24)
        Me.EnglishFlowRateUnits.Name = "EnglishFlowRateUnits"
        Me.EnglishFlowRateUnits.Size = New System.Drawing.Size(88, 24)
        Me.EnglishFlowRateUnits.TabIndex = 1
        Me.UserPreferenceToolTip.SetToolTip(Me.EnglishFlowRateUnits, "Default English Flow Rate")
        '
        'MetricFieldSlopeUnits
        '
        Me.MetricFieldSlopeUnits.AccessibleDescription = "Metric Field Slope"
        Me.MetricFieldSlopeUnits.AccessibleName = "Select default Metric field slope units."
        Me.MetricFieldSlopeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MetricFieldSlopeUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricFieldSlopeUnits.ItemHeight = 16
        Me.MetricFieldSlopeUnits.Location = New System.Drawing.Point(127, 54)
        Me.MetricFieldSlopeUnits.Name = "MetricFieldSlopeUnits"
        Me.MetricFieldSlopeUnits.Size = New System.Drawing.Size(88, 24)
        Me.MetricFieldSlopeUnits.TabIndex = 3
        Me.UserPreferenceToolTip.SetToolTip(Me.MetricFieldSlopeUnits, "Default Metric Field Slope")
        '
        'MetricFlowRateUnits
        '
        Me.MetricFlowRateUnits.AccessibleDescription = "Metric Flow Rate"
        Me.MetricFlowRateUnits.AccessibleName = "Select default Metric flow rate units."
        Me.MetricFlowRateUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MetricFlowRateUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricFlowRateUnits.ItemHeight = 16
        Me.MetricFlowRateUnits.Location = New System.Drawing.Point(127, 24)
        Me.MetricFlowRateUnits.Name = "MetricFlowRateUnits"
        Me.MetricFlowRateUnits.Size = New System.Drawing.Size(88, 24)
        Me.MetricFlowRateUnits.TabIndex = 1
        Me.UserPreferenceToolTip.SetToolTip(Me.MetricFlowRateUnits, "Default Metric Flow Rate")
        '
        'English
        '
        Me.English.AccessibleDescription = "English"
        Me.English.AccessibleName = "Program is opened with English unit system by default."
        Me.English.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.English.Location = New System.Drawing.Point(249, 24)
        Me.English.Name = "English"
        Me.English.Size = New System.Drawing.Size(221, 24)
        Me.English.TabIndex = 1
        Me.English.Text = "&English"
        Me.UserPreferenceToolTip.SetToolTip(Me.English, "Enables English Measurement System")
        '
        'Metric
        '
        Me.Metric.AccessibleDescription = "Metric"
        Me.Metric.AccessibleName = "Program is opened with Metric unit system by default."
        Me.Metric.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Metric.Location = New System.Drawing.Point(13, 24)
        Me.Metric.Name = "Metric"
        Me.Metric.Size = New System.Drawing.Size(219, 24)
        Me.Metric.TabIndex = 0
        Me.Metric.Text = "&Metric"
        Me.UserPreferenceToolTip.SetToolTip(Me.Metric, "Enables Metric Measurement System")
        '
        'FarmName
        '
        Me.FarmName.AccessibleDescription = ""
        Me.FarmName.AccessibleName = ""
        Me.FarmName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FarmName.Location = New System.Drawing.Point(139, 32)
        Me.FarmName.Name = "FarmName"
        Me.FarmName.Size = New System.Drawing.Size(341, 22)
        Me.FarmName.TabIndex = 1
        Me.UserPreferenceToolTip.SetToolTip(Me.FarmName, "Edit Default Farm Name")
        '
        'FarmOwner
        '
        Me.FarmOwner.AccessibleDescription = ""
        Me.FarmOwner.AccessibleName = ""
        Me.FarmOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FarmOwner.Location = New System.Drawing.Point(139, 64)
        Me.FarmOwner.Name = "FarmOwner"
        Me.FarmOwner.Size = New System.Drawing.Size(341, 22)
        Me.FarmOwner.TabIndex = 3
        Me.UserPreferenceToolTip.SetToolTip(Me.FarmOwner, "Edit Default Farm Owner Name")
        '
        'MetricWaterDepthUnits
        '
        Me.MetricWaterDepthUnits.AccessibleDescription = "Metric Water Depth"
        Me.MetricWaterDepthUnits.AccessibleName = "Select default Metric water depths (infiltration & surface flow) units."
        Me.MetricWaterDepthUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MetricWaterDepthUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricWaterDepthUnits.ItemHeight = 16
        Me.MetricWaterDepthUnits.Location = New System.Drawing.Point(127, 114)
        Me.MetricWaterDepthUnits.Name = "MetricWaterDepthUnits"
        Me.MetricWaterDepthUnits.Size = New System.Drawing.Size(88, 24)
        Me.MetricWaterDepthUnits.TabIndex = 7
        Me.UserPreferenceToolTip.SetToolTip(Me.MetricWaterDepthUnits, "Default Metric Field Slope")
        '
        'MetricFurrowShapeUnits
        '
        Me.MetricFurrowShapeUnits.AccessibleDescription = "Metric Furrow Shape"
        Me.MetricFurrowShapeUnits.AccessibleName = "Select default Metric furrow geometry units."
        Me.MetricFurrowShapeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MetricFurrowShapeUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricFurrowShapeUnits.ItemHeight = 16
        Me.MetricFurrowShapeUnits.Location = New System.Drawing.Point(127, 84)
        Me.MetricFurrowShapeUnits.Name = "MetricFurrowShapeUnits"
        Me.MetricFurrowShapeUnits.Size = New System.Drawing.Size(88, 24)
        Me.MetricFurrowShapeUnits.TabIndex = 5
        Me.UserPreferenceToolTip.SetToolTip(Me.MetricFurrowShapeUnits, "Default Metric Flow Rate")
        '
        'EnglishWaterDepthUnits
        '
        Me.EnglishWaterDepthUnits.AccessibleDescription = "Metric Water Depth"
        Me.EnglishWaterDepthUnits.AccessibleName = "Select default Metric water depths (infiltration & surface flow) units."
        Me.EnglishWaterDepthUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EnglishWaterDepthUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishWaterDepthUnits.ItemHeight = 16
        Me.EnglishWaterDepthUnits.Location = New System.Drawing.Point(133, 114)
        Me.EnglishWaterDepthUnits.Name = "EnglishWaterDepthUnits"
        Me.EnglishWaterDepthUnits.Size = New System.Drawing.Size(88, 24)
        Me.EnglishWaterDepthUnits.TabIndex = 7
        Me.UserPreferenceToolTip.SetToolTip(Me.EnglishWaterDepthUnits, "Default Metric Field Slope")
        '
        'EnglishFurrowShapeUnits
        '
        Me.EnglishFurrowShapeUnits.AccessibleDescription = "Metric Furrow Shape"
        Me.EnglishFurrowShapeUnits.AccessibleName = "Select default Metric furrow geometry units."
        Me.EnglishFurrowShapeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EnglishFurrowShapeUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFurrowShapeUnits.ItemHeight = 16
        Me.EnglishFurrowShapeUnits.Location = New System.Drawing.Point(133, 84)
        Me.EnglishFurrowShapeUnits.Name = "EnglishFurrowShapeUnits"
        Me.EnglishFurrowShapeUnits.Size = New System.Drawing.Size(88, 24)
        Me.EnglishFurrowShapeUnits.TabIndex = 5
        Me.UserPreferenceToolTip.SetToolTip(Me.EnglishFurrowShapeUnits, "Default Metric Flow Rate")
        '
        'FilesTab
        '
        Me.FilesTab.AccessibleDescription = "Specifies default folders for WinSRFR files."
        Me.FilesTab.AccessibleName = "Files Tab"
        Me.FilesTab.Controls.Add(Me.DataFolderBox)
        Me.FilesTab.Controls.Add(Me.LogDiagFolderBox)
        Me.FilesTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilesTab.Location = New System.Drawing.Point(4, 4)
        Me.FilesTab.Name = "FilesTab"
        Me.FilesTab.Size = New System.Drawing.Size(506, 294)
        Me.FilesTab.TabIndex = 6
        Me.FilesTab.Text = "Files"
        '
        'DataFolderBox
        '
        Me.DataFolderBox.AccessibleDescription = "Specifies the default directory for WinSRFR log & diagnostic files."
        Me.DataFolderBox.AccessibleName = "Default Log Folder"
        Me.DataFolderBox.Controls.Add(Me.ResetDataFolderButton)
        Me.DataFolderBox.Controls.Add(Me.BrowseDataFolderButton)
        Me.DataFolderBox.Controls.Add(Me.DataFolder)
        Me.DataFolderBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataFolderBox.Location = New System.Drawing.Point(7, 112)
        Me.DataFolderBox.Name = "DataFolderBox"
        Me.DataFolderBox.Size = New System.Drawing.Size(491, 96)
        Me.DataFolderBox.TabIndex = 2
        Me.DataFolderBox.TabStop = False
        Me.DataFolderBox.Text = "Data File Folder"
        '
        'ResetDataFolderButton
        '
        Me.ResetDataFolderButton.AccessibleDescription = "Resets WinSRFR's log & diagnostic folder to the Current User's Application Data d" & _
            "irectory."
        Me.ResetDataFolderButton.AccessibleName = "Reset Log Folder"
        Me.ResetDataFolderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetDataFolderButton.Location = New System.Drawing.Point(315, 64)
        Me.ResetDataFolderButton.Name = "ResetDataFolderButton"
        Me.ResetDataFolderButton.Size = New System.Drawing.Size(80, 23)
        Me.ResetDataFolderButton.TabIndex = 2
        Me.ResetDataFolderButton.Text = "&Reset"
        '
        'BrowseDataFolderButton
        '
        Me.BrowseDataFolderButton.AccessibleDescription = "Browses for WinSRFR's log & diagnostic folder."
        Me.BrowseDataFolderButton.AccessibleName = "Browse Log Folder"
        Me.BrowseDataFolderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseDataFolderButton.Location = New System.Drawing.Point(401, 64)
        Me.BrowseDataFolderButton.Name = "BrowseDataFolderButton"
        Me.BrowseDataFolderButton.Size = New System.Drawing.Size(80, 23)
        Me.BrowseDataFolderButton.TabIndex = 1
        Me.BrowseDataFolderButton.Text = "&Browse"
        '
        'DataFolder
        '
        Me.DataFolder.AccessibleDescription = "WinSRFR's log & diagnostic folder."
        Me.DataFolder.AccessibleName = "Log Folder"
        Me.DataFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataFolder.Location = New System.Drawing.Point(16, 32)
        Me.DataFolder.Name = "DataFolder"
        Me.DataFolder.Size = New System.Drawing.Size(465, 23)
        Me.DataFolder.TabIndex = 0
        '
        'LogDiagFolderBox
        '
        Me.LogDiagFolderBox.AccessibleDescription = "Specifies the default directory for WinSRFR log & diagnostic files."
        Me.LogDiagFolderBox.AccessibleName = "Default Log Folder"
        Me.LogDiagFolderBox.Controls.Add(Me.ResetLogFolderButton)
        Me.LogDiagFolderBox.Controls.Add(Me.BrowseLogFolderButton)
        Me.LogDiagFolderBox.Controls.Add(Me.LogFolder)
        Me.LogDiagFolderBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogDiagFolderBox.Location = New System.Drawing.Point(8, 8)
        Me.LogDiagFolderBox.Name = "LogDiagFolderBox"
        Me.LogDiagFolderBox.Size = New System.Drawing.Size(490, 96)
        Me.LogDiagFolderBox.TabIndex = 1
        Me.LogDiagFolderBox.TabStop = False
        Me.LogDiagFolderBox.Text = "Log && Diagnostic File Folder"
        '
        'ResetLogFolderButton
        '
        Me.ResetLogFolderButton.AccessibleDescription = "Resets WinSRFR's log & diagnostic folder to the Current User's Application Data d" & _
            "irectory."
        Me.ResetLogFolderButton.AccessibleName = "Reset Log Folder"
        Me.ResetLogFolderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetLogFolderButton.Location = New System.Drawing.Point(314, 64)
        Me.ResetLogFolderButton.Name = "ResetLogFolderButton"
        Me.ResetLogFolderButton.Size = New System.Drawing.Size(80, 23)
        Me.ResetLogFolderButton.TabIndex = 2
        Me.ResetLogFolderButton.Text = "&Reset"
        '
        'BrowseLogFolderButton
        '
        Me.BrowseLogFolderButton.AccessibleDescription = "Browses for WinSRFR's log & diagnostic folder."
        Me.BrowseLogFolderButton.AccessibleName = "Browse Log Folder"
        Me.BrowseLogFolderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseLogFolderButton.Location = New System.Drawing.Point(400, 64)
        Me.BrowseLogFolderButton.Name = "BrowseLogFolderButton"
        Me.BrowseLogFolderButton.Size = New System.Drawing.Size(80, 23)
        Me.BrowseLogFolderButton.TabIndex = 1
        Me.BrowseLogFolderButton.Text = "&Browse"
        '
        'LogFolder
        '
        Me.LogFolder.AccessibleDescription = "WinSRFR's log & diagnostic folder."
        Me.LogFolder.AccessibleName = "Log Folder"
        Me.LogFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogFolder.Location = New System.Drawing.Point(16, 32)
        Me.LogFolder.Name = "LogFolder"
        Me.LogFolder.Size = New System.Drawing.Size(464, 23)
        Me.LogFolder.TabIndex = 0
        '
        'ShowGroupBox
        '
        Me.ShowGroupBox.Location = New System.Drawing.Point(0, 0)
        Me.ShowGroupBox.Name = "ShowGroupBox"
        Me.ShowGroupBox.Size = New System.Drawing.Size(200, 100)
        Me.ShowGroupBox.TabIndex = 0
        Me.ShowGroupBox.TabStop = False
        Me.ShowGroupBox.Text = "GroupBox1"
        '
        'StartupTab
        '
        Me.StartupTab.AccessibleDescription = "Specifies default values to use as startup."
        Me.StartupTab.AccessibleName = "Startup Tab"
        Me.StartupTab.Controls.Add(Me.AutoOpenPreviousFile)
        Me.StartupTab.Controls.Add(Me.Evaluator)
        Me.StartupTab.Controls.Add(Me.DefaultEvaluatorLabel)
        Me.StartupTab.Controls.Add(Me.ProjectBox)
        Me.StartupTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartupTab.Location = New System.Drawing.Point(4, 4)
        Me.StartupTab.Name = "StartupTab"
        Me.StartupTab.Size = New System.Drawing.Size(506, 294)
        Me.StartupTab.TabIndex = 0
        Me.StartupTab.Text = "Startup"
        '
        'AutoOpenPreviousFile
        '
        Me.AutoOpenPreviousFile.AccessibleDescription = "Check to open the previously opened file at startup."
        Me.AutoOpenPreviousFile.AccessibleName = "Open Previous File"
        Me.AutoOpenPreviousFile.AlwaysChecked = False
        Me.AutoOpenPreviousFile.ErrorMessage = Nothing
        Me.AutoOpenPreviousFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoOpenPreviousFile.Location = New System.Drawing.Point(16, 184)
        Me.AutoOpenPreviousFile.Name = "AutoOpenPreviousFile"
        Me.AutoOpenPreviousFile.Size = New System.Drawing.Size(448, 24)
        Me.AutoOpenPreviousFile.TabIndex = 4
        Me.AutoOpenPreviousFile.Text = "Automatically Open Previous File at Startup"
        Me.AutoOpenPreviousFile.UncheckAttemptMessage = Nothing
        '
        'Evaluator
        '
        Me.Evaluator.AccessibleDescription = "Enter the default Evaluator's name for new projects."
        Me.Evaluator.Location = New System.Drawing.Point(189, 128)
        Me.Evaluator.Name = "Evaluator"
        Me.Evaluator.Size = New System.Drawing.Size(299, 23)
        Me.Evaluator.TabIndex = 2
        '
        'DefaultEvaluatorLabel
        '
        Me.DefaultEvaluatorLabel.AccessibleName = "Default Evaluator"
        Me.DefaultEvaluatorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultEvaluatorLabel.Location = New System.Drawing.Point(8, 128)
        Me.DefaultEvaluatorLabel.Name = "DefaultEvaluatorLabel"
        Me.DefaultEvaluatorLabel.Size = New System.Drawing.Size(175, 23)
        Me.DefaultEvaluatorLabel.TabIndex = 1
        Me.DefaultEvaluatorLabel.Text = "Default Evaluator"
        Me.DefaultEvaluatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProjectBox
        '
        Me.ProjectBox.AccessibleDescription = "Enter the default Name & Owner for new projects."
        Me.ProjectBox.AccessibleName = "Default Name & Owner"
        Me.ProjectBox.Controls.Add(Me.FarmOwner)
        Me.ProjectBox.Controls.Add(Me.ProjectOwnerLabel)
        Me.ProjectBox.Controls.Add(Me.FarmName)
        Me.ProjectBox.Controls.Add(Me.ProjectNameLabel)
        Me.ProjectBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectBox.Location = New System.Drawing.Point(8, 8)
        Me.ProjectBox.Name = "ProjectBox"
        Me.ProjectBox.Size = New System.Drawing.Size(490, 104)
        Me.ProjectBox.TabIndex = 0
        Me.ProjectBox.TabStop = False
        Me.ProjectBox.Text = "Default Project Name && Owner"
        '
        'ProjectOwnerLabel
        '
        Me.ProjectOwnerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectOwnerLabel.Location = New System.Drawing.Point(8, 64)
        Me.ProjectOwnerLabel.Name = "ProjectOwnerLabel"
        Me.ProjectOwnerLabel.Size = New System.Drawing.Size(125, 23)
        Me.ProjectOwnerLabel.TabIndex = 2
        Me.ProjectOwnerLabel.Text = "Project Owner"
        Me.ProjectOwnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProjectNameLabel
        '
        Me.ProjectNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProjectNameLabel.Location = New System.Drawing.Point(8, 32)
        Me.ProjectNameLabel.Name = "ProjectNameLabel"
        Me.ProjectNameLabel.Size = New System.Drawing.Size(125, 23)
        Me.ProjectNameLabel.TabIndex = 0
        Me.ProjectNameLabel.Text = "Project Name"
        Me.ProjectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UnitsTab
        '
        Me.UnitsTab.AccessibleDescription = "Specifies the default numeric units."
        Me.UnitsTab.AccessibleName = "Units Tab"
        Me.UnitsTab.Controls.Add(Me.DefaultTimeUnitsLabel)
        Me.UnitsTab.Controls.Add(Me.TimeUnits)
        Me.UnitsTab.Controls.Add(Me.UnitsGroup)
        Me.UnitsTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitsTab.Location = New System.Drawing.Point(4, 4)
        Me.UnitsTab.Name = "UnitsTab"
        Me.UnitsTab.Size = New System.Drawing.Size(506, 294)
        Me.UnitsTab.TabIndex = 4
        Me.UnitsTab.Text = "Units"
        '
        'DefaultTimeUnitsLabel
        '
        Me.DefaultTimeUnitsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultTimeUnitsLabel.Location = New System.Drawing.Point(187, 246)
        Me.DefaultTimeUnitsLabel.Name = "DefaultTimeUnitsLabel"
        Me.DefaultTimeUnitsLabel.Size = New System.Drawing.Size(197, 24)
        Me.DefaultTimeUnitsLabel.TabIndex = 2
        Me.DefaultTimeUnitsLabel.Text = "Default Time Units"
        Me.DefaultTimeUnitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UnitsGroup
        '
        Me.UnitsGroup.Controls.Add(Me.EnglishBox)
        Me.UnitsGroup.Controls.Add(Me.MetricBox)
        Me.UnitsGroup.Controls.Add(Me.English)
        Me.UnitsGroup.Controls.Add(Me.Metric)
        Me.UnitsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnitsGroup.Location = New System.Drawing.Point(8, 8)
        Me.UnitsGroup.Name = "UnitsGroup"
        Me.UnitsGroup.Size = New System.Drawing.Size(490, 218)
        Me.UnitsGroup.TabIndex = 1
        Me.UnitsGroup.TabStop = False
        Me.UnitsGroup.Text = "Default Unit System"
        '
        'EnglishBox
        '
        Me.EnglishBox.Controls.Add(Me.EnglishWaterDepthUnits)
        Me.EnglishBox.Controls.Add(Me.EnglishFurrowShapeUnits)
        Me.EnglishBox.Controls.Add(Me.EnglishWaterDepthLabel)
        Me.EnglishBox.Controls.Add(Me.EnglishFurrowShapeLabel)
        Me.EnglishBox.Controls.Add(Me.EnglishFieldSlopeUnits)
        Me.EnglishBox.Controls.Add(Me.EnglishFlowRateUnits)
        Me.EnglishBox.Controls.Add(Me.EnglishFieldSlopeLabel)
        Me.EnglishBox.Controls.Add(Me.EnglishFlowRateLabel)
        Me.EnglishBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishBox.Location = New System.Drawing.Point(250, 56)
        Me.EnglishBox.Name = "EnglishBox"
        Me.EnglishBox.Size = New System.Drawing.Size(230, 150)
        Me.EnglishBox.TabIndex = 3
        Me.EnglishBox.TabStop = False
        Me.EnglishBox.Text = "English Options"
        '
        'EnglishWaterDepthLabel
        '
        Me.EnglishWaterDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishWaterDepthLabel.Location = New System.Drawing.Point(7, 114)
        Me.EnglishWaterDepthLabel.Name = "EnglishWaterDepthLabel"
        Me.EnglishWaterDepthLabel.Size = New System.Drawing.Size(120, 23)
        Me.EnglishWaterDepthLabel.TabIndex = 6
        Me.EnglishWaterDepthLabel.Text = "Water Depth"
        Me.EnglishWaterDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EnglishFurrowShapeLabel
        '
        Me.EnglishFurrowShapeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFurrowShapeLabel.Location = New System.Drawing.Point(7, 84)
        Me.EnglishFurrowShapeLabel.Name = "EnglishFurrowShapeLabel"
        Me.EnglishFurrowShapeLabel.Size = New System.Drawing.Size(120, 23)
        Me.EnglishFurrowShapeLabel.TabIndex = 4
        Me.EnglishFurrowShapeLabel.Text = "Furrow Geometry"
        Me.EnglishFurrowShapeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EnglishFieldSlopeLabel
        '
        Me.EnglishFieldSlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFieldSlopeLabel.Location = New System.Drawing.Point(9, 54)
        Me.EnglishFieldSlopeLabel.Name = "EnglishFieldSlopeLabel"
        Me.EnglishFieldSlopeLabel.Size = New System.Drawing.Size(118, 23)
        Me.EnglishFieldSlopeLabel.TabIndex = 2
        Me.EnglishFieldSlopeLabel.Text = "Field Slope"
        Me.EnglishFieldSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EnglishFlowRateLabel
        '
        Me.EnglishFlowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnglishFlowRateLabel.Location = New System.Drawing.Point(6, 24)
        Me.EnglishFlowRateLabel.Name = "EnglishFlowRateLabel"
        Me.EnglishFlowRateLabel.Size = New System.Drawing.Size(121, 23)
        Me.EnglishFlowRateLabel.TabIndex = 0
        Me.EnglishFlowRateLabel.Text = "Flow Rate"
        Me.EnglishFlowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MetricBox
        '
        Me.MetricBox.Controls.Add(Me.MetricWaterDepthUnits)
        Me.MetricBox.Controls.Add(Me.MetricFurrowShapeUnits)
        Me.MetricBox.Controls.Add(Me.MetricWaterDepthLabel)
        Me.MetricBox.Controls.Add(Me.MetricFurrowShapeLabel)
        Me.MetricBox.Controls.Add(Me.MetricFieldSlopeUnits)
        Me.MetricBox.Controls.Add(Me.MetricFlowRateUnits)
        Me.MetricBox.Controls.Add(Me.MectricFieldSlopeLabel)
        Me.MetricBox.Controls.Add(Me.MetricFlowRateLabel)
        Me.MetricBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricBox.Location = New System.Drawing.Point(11, 56)
        Me.MetricBox.Name = "MetricBox"
        Me.MetricBox.Size = New System.Drawing.Size(230, 150)
        Me.MetricBox.TabIndex = 2
        Me.MetricBox.TabStop = False
        Me.MetricBox.Text = "Metric Options"
        '
        'MetricWaterDepthLabel
        '
        Me.MetricWaterDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricWaterDepthLabel.Location = New System.Drawing.Point(6, 114)
        Me.MetricWaterDepthLabel.Name = "MetricWaterDepthLabel"
        Me.MetricWaterDepthLabel.Size = New System.Drawing.Size(120, 23)
        Me.MetricWaterDepthLabel.TabIndex = 6
        Me.MetricWaterDepthLabel.Text = "Water Depth"
        Me.MetricWaterDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MetricFurrowShapeLabel
        '
        Me.MetricFurrowShapeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricFurrowShapeLabel.Location = New System.Drawing.Point(6, 84)
        Me.MetricFurrowShapeLabel.Name = "MetricFurrowShapeLabel"
        Me.MetricFurrowShapeLabel.Size = New System.Drawing.Size(120, 23)
        Me.MetricFurrowShapeLabel.TabIndex = 4
        Me.MetricFurrowShapeLabel.Text = "Furrow Geometry"
        Me.MetricFurrowShapeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MectricFieldSlopeLabel
        '
        Me.MectricFieldSlopeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MectricFieldSlopeLabel.Location = New System.Drawing.Point(6, 54)
        Me.MectricFieldSlopeLabel.Name = "MectricFieldSlopeLabel"
        Me.MectricFieldSlopeLabel.Size = New System.Drawing.Size(120, 23)
        Me.MectricFieldSlopeLabel.TabIndex = 2
        Me.MectricFieldSlopeLabel.Text = "Field Slope"
        Me.MectricFieldSlopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MetricFlowRateLabel
        '
        Me.MetricFlowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetricFlowRateLabel.Location = New System.Drawing.Point(6, 24)
        Me.MetricFlowRateLabel.Name = "MetricFlowRateLabel"
        Me.MetricFlowRateLabel.Size = New System.Drawing.Size(120, 23)
        Me.MetricFlowRateLabel.TabIndex = 0
        Me.MetricFlowRateLabel.Text = "Flow Rate"
        Me.MetricFlowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UserPreferenceTabs
        '
        Me.UserPreferenceTabs.AccessibleDescription = ""
        Me.UserPreferenceTabs.AccessibleName = ""
        Me.UserPreferenceTabs.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.UserPreferenceTabs.Controls.Add(Me.StartupTab)
        Me.UserPreferenceTabs.Controls.Add(Me.ViewsTab)
        Me.UserPreferenceTabs.Controls.Add(Me.FilesTab)
        Me.UserPreferenceTabs.Controls.Add(Me.DialogsTab)
        Me.UserPreferenceTabs.Controls.Add(Me.UnitsTab)
        Me.UserPreferenceTabs.Controls.Add(Me.GraphsTab)
        Me.UserPreferenceTabs.Controls.Add(Me.ContoursTab)
        Me.UserPreferenceTabs.Dock = System.Windows.Forms.DockStyle.Top
        Me.UserPreferenceTabs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserPreferenceTabs.HotTrack = True
        Me.UserPreferenceTabs.ItemSize = New System.Drawing.Size(48, 18)
        Me.UserPreferenceTabs.Location = New System.Drawing.Point(0, 0)
        Me.UserPreferenceTabs.Multiline = True
        Me.UserPreferenceTabs.Name = "UserPreferenceTabs"
        Me.UserPreferenceTabs.SelectedIndex = 0
        Me.UserPreferenceTabs.Size = New System.Drawing.Size(514, 320)
        Me.UserPreferenceTabs.TabIndex = 0
        '
        'ViewsTab
        '
        Me.ViewsTab.AccessibleDescription = "Specifies default View types and control."
        Me.ViewsTab.AccessibleName = "Views Tab"
        Me.ViewsTab.Controls.Add(Me.ShowSimulationAnimationButton)
        Me.ViewsTab.Controls.Add(Me.ResultsGroup)
        Me.ViewsTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewsTab.Location = New System.Drawing.Point(4, 4)
        Me.ViewsTab.Name = "ViewsTab"
        Me.ViewsTab.Size = New System.Drawing.Size(506, 294)
        Me.ViewsTab.TabIndex = 5
        Me.ViewsTab.Text = "Views"
        '
        'ShowSimulationAnimationButton
        '
        Me.ShowSimulationAnimationButton.AlwaysChecked = False
        Me.ShowSimulationAnimationButton.ErrorMessage = Nothing
        Me.ShowSimulationAnimationButton.Location = New System.Drawing.Point(32, 80)
        Me.ShowSimulationAnimationButton.Name = "ShowSimulationAnimationButton"
        Me.ShowSimulationAnimationButton.Size = New System.Drawing.Size(431, 24)
        Me.ShowSimulationAnimationButton.TabIndex = 1
        Me.ShowSimulationAnimationButton.Text = "Show Simulation Animation during Run"
        Me.ShowSimulationAnimationButton.UncheckAttemptMessage = Nothing
        '
        'ResultsGroup
        '
        Me.ResultsGroup.Controls.Add(Me.GraphsOnly)
        Me.ResultsGroup.Controls.Add(Me.PortraitPage)
        Me.ResultsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultsGroup.Location = New System.Drawing.Point(8, 8)
        Me.ResultsGroup.Name = "ResultsGroup"
        Me.ResultsGroup.Size = New System.Drawing.Size(480, 56)
        Me.ResultsGroup.TabIndex = 0
        Me.ResultsGroup.TabStop = False
        Me.ResultsGroup.Text = "Results Display"
        '
        'GraphsOnly
        '
        Me.GraphsOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GraphsOnly.Location = New System.Drawing.Point(265, 24)
        Me.GraphsOnly.Name = "GraphsOnly"
        Me.GraphsOnly.Size = New System.Drawing.Size(209, 24)
        Me.GraphsOnly.TabIndex = 1
        Me.GraphsOnly.Text = "Graphs Only"
        '
        'PortraitPage
        '
        Me.PortraitPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PortraitPage.Location = New System.Drawing.Point(24, 24)
        Me.PortraitPage.Name = "PortraitPage"
        Me.PortraitPage.Size = New System.Drawing.Size(235, 24)
        Me.PortraitPage.TabIndex = 0
        Me.PortraitPage.Text = "Portrait Page"
        '
        'DialogsTab
        '
        Me.DialogsTab.AccessibleDescription = "Specifies default Dialog types and control."
        Me.DialogsTab.AccessibleName = "Dialogs Tab"
        Me.DialogsTab.Controls.Add(Me.DefaultValuesGroup)
        Me.DialogsTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DialogsTab.Location = New System.Drawing.Point(4, 4)
        Me.DialogsTab.Name = "DialogsTab"
        Me.DialogsTab.Size = New System.Drawing.Size(506, 294)
        Me.DialogsTab.TabIndex = 9
        Me.DialogsTab.Text = "Dialogs"
        '
        'DefaultValuesGroup
        '
        Me.DefaultValuesGroup.Controls.Add(Me.HelpSuggestedDefaults)
        Me.DefaultValuesGroup.Controls.Add(Me.RequireConfirmation)
        Me.DefaultValuesGroup.Controls.Add(Me.UnconditionallyAccept)
        Me.DefaultValuesGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultValuesGroup.Location = New System.Drawing.Point(8, 8)
        Me.DefaultValuesGroup.Name = "DefaultValuesGroup"
        Me.DefaultValuesGroup.Size = New System.Drawing.Size(480, 96)
        Me.DefaultValuesGroup.TabIndex = 0
        Me.DefaultValuesGroup.TabStop = False
        Me.DefaultValuesGroup.Text = "Solution Model and Cell Density"
        '
        'HelpSuggestedDefaults
        '
        Me.HelpSuggestedDefaults.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpSuggestedDefaults.Location = New System.Drawing.Point(10, 21)
        Me.HelpSuggestedDefaults.Name = "HelpSuggestedDefaults"
        Me.HelpSuggestedDefaults.Size = New System.Drawing.Size(456, 41)
        Me.HelpSuggestedDefaults.TabIndex = 0
        Me.HelpSuggestedDefaults.Text = "Application selects the Solution Model and Cell Density for siimulation."
        '
        'RequireConfirmation
        '
        Me.RequireConfirmation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequireConfirmation.Location = New System.Drawing.Point(243, 65)
        Me.RequireConfirmation.Name = "RequireConfirmation"
        Me.RequireConfirmation.Size = New System.Drawing.Size(223, 24)
        Me.RequireConfirmation.TabIndex = 2
        Me.RequireConfirmation.Text = "Require Confirmation"
        '
        'UnconditionallyAccept
        '
        Me.UnconditionallyAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnconditionallyAccept.Location = New System.Drawing.Point(10, 65)
        Me.UnconditionallyAccept.Name = "UnconditionallyAccept"
        Me.UnconditionallyAccept.Size = New System.Drawing.Size(227, 24)
        Me.UnconditionallyAccept.TabIndex = 1
        Me.UnconditionallyAccept.Text = "Unconditionally Accept"
        '
        'GraphsTab
        '
        Me.GraphsTab.AccessibleDescription = "Specifies the drawing colors."
        Me.GraphsTab.AccessibleName = "Color Tab"
        Me.GraphsTab.Controls.Add(Me.GraphOptionsBox)
        Me.GraphsTab.Controls.Add(Me.LineColorBox)
        Me.GraphsTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GraphsTab.Location = New System.Drawing.Point(4, 4)
        Me.GraphsTab.Name = "GraphsTab"
        Me.GraphsTab.Size = New System.Drawing.Size(506, 294)
        Me.GraphsTab.TabIndex = 7
        Me.GraphsTab.Text = "Graphs"
        '
        'GraphOptionsBox
        '
        Me.GraphOptionsBox.Controls.Add(Me.SizeLabel)
        Me.GraphOptionsBox.Controls.Add(Me.FontSize)
        Me.GraphOptionsBox.Controls.Add(Me.FontSample)
        Me.GraphOptionsBox.Controls.Add(Me.InstalledFonts)
        Me.GraphOptionsBox.Controls.Add(Me.FontLabel)
        Me.GraphOptionsBox.Controls.Add(Me.GraphsOptionsHelp)
        Me.GraphOptionsBox.Controls.Add(Me.DisplayAxisLabelsButton)
        Me.GraphOptionsBox.Controls.Add(Me.DisplaySubtitlesButton)
        Me.GraphOptionsBox.Controls.Add(Me.DisplayTitleButton)
        Me.GraphOptionsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GraphOptionsBox.Location = New System.Drawing.Point(168, 8)
        Me.GraphOptionsBox.Name = "GraphOptionsBox"
        Me.GraphOptionsBox.Size = New System.Drawing.Size(330, 280)
        Me.GraphOptionsBox.TabIndex = 1
        Me.GraphOptionsBox.TabStop = False
        Me.GraphOptionsBox.Text = "Text Options"
        '
        'SizeLabel
        '
        Me.SizeLabel.Location = New System.Drawing.Point(6, 144)
        Me.SizeLabel.Name = "SizeLabel"
        Me.SizeLabel.Size = New System.Drawing.Size(69, 23)
        Me.SizeLabel.TabIndex = 5
        Me.SizeLabel.Text = "Size:"
        Me.SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FontSize
        '
        Me.FontSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FontSize.Location = New System.Drawing.Point(81, 144)
        Me.FontSize.Name = "FontSize"
        Me.FontSize.Size = New System.Drawing.Size(80, 24)
        Me.FontSize.TabIndex = 6
        Me.FontSize.Text = "Normal"
        '
        'FontSample
        '
        Me.FontSample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FontSample.Location = New System.Drawing.Point(172, 144)
        Me.FontSample.Name = "FontSample"
        Me.FontSample.ReadOnly = True
        Me.FontSample.Size = New System.Drawing.Size(148, 23)
        Me.FontSample.TabIndex = 7
        Me.FontSample.Text = "Sample Text"
        Me.FontSample.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InstalledFonts
        '
        Me.InstalledFonts.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstalledFonts.Location = New System.Drawing.Point(81, 112)
        Me.InstalledFonts.Name = "InstalledFonts"
        Me.InstalledFonts.Size = New System.Drawing.Size(239, 24)
        Me.InstalledFonts.TabIndex = 4
        Me.InstalledFonts.Text = "Installed Fonts"
        '
        'FontLabel
        '
        Me.FontLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FontLabel.Location = New System.Drawing.Point(6, 112)
        Me.FontLabel.Name = "FontLabel"
        Me.FontLabel.Size = New System.Drawing.Size(69, 23)
        Me.FontLabel.TabIndex = 3
        Me.FontLabel.Text = "&Font:"
        Me.FontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GraphsOptionsHelp
        '
        Me.GraphsOptionsHelp.BackColor = System.Drawing.SystemColors.Control
        Me.GraphsOptionsHelp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GraphsOptionsHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GraphsOptionsHelp.Location = New System.Drawing.Point(70, 196)
        Me.GraphsOptionsHelp.Multiline = True
        Me.GraphsOptionsHelp.Name = "GraphsOptionsHelp"
        Me.GraphsOptionsHelp.Size = New System.Drawing.Size(184, 72)
        Me.GraphsOptionsHelp.TabIndex = 10
        Me.GraphsOptionsHelp.Text = "Graph Options apply to both XY Graphs and Contour Plots."
        '
        'DisplayAxisLabelsButton
        '
        Me.DisplayAxisLabelsButton.AlwaysChecked = False
        Me.DisplayAxisLabelsButton.ErrorMessage = Nothing
        Me.DisplayAxisLabelsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplayAxisLabelsButton.Location = New System.Drawing.Point(16, 80)
        Me.DisplayAxisLabelsButton.Name = "DisplayAxisLabelsButton"
        Me.DisplayAxisLabelsButton.Size = New System.Drawing.Size(280, 24)
        Me.DisplayAxisLabelsButton.TabIndex = 2
        Me.DisplayAxisLabelsButton.Text = "Display Axis Labels"
        Me.DisplayAxisLabelsButton.UncheckAttemptMessage = Nothing
        '
        'DisplaySubtitlesButton
        '
        Me.DisplaySubtitlesButton.AlwaysChecked = False
        Me.DisplaySubtitlesButton.ErrorMessage = Nothing
        Me.DisplaySubtitlesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplaySubtitlesButton.Location = New System.Drawing.Point(16, 56)
        Me.DisplaySubtitlesButton.Name = "DisplaySubtitlesButton"
        Me.DisplaySubtitlesButton.Size = New System.Drawing.Size(280, 24)
        Me.DisplaySubtitlesButton.TabIndex = 1
        Me.DisplaySubtitlesButton.Text = "Display Subtitles"
        Me.DisplaySubtitlesButton.UncheckAttemptMessage = Nothing
        '
        'DisplayTitleButton
        '
        Me.DisplayTitleButton.AlwaysChecked = False
        Me.DisplayTitleButton.ErrorMessage = Nothing
        Me.DisplayTitleButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplayTitleButton.Location = New System.Drawing.Point(16, 32)
        Me.DisplayTitleButton.Name = "DisplayTitleButton"
        Me.DisplayTitleButton.Size = New System.Drawing.Size(280, 24)
        Me.DisplayTitleButton.TabIndex = 0
        Me.DisplayTitleButton.Text = "Display Title"
        Me.DisplayTitleButton.UncheckAttemptMessage = Nothing
        '
        'LineColorBox
        '
        Me.LineColorBox.Controls.Add(Me.Color9Sample)
        Me.LineColorBox.Controls.Add(Me.Color8Sample)
        Me.LineColorBox.Controls.Add(Me.Color7Sample)
        Me.LineColorBox.Controls.Add(Me.Color6Sample)
        Me.LineColorBox.Controls.Add(Me.Color9Button)
        Me.LineColorBox.Controls.Add(Me.Color8Button)
        Me.LineColorBox.Controls.Add(Me.Color7Button)
        Me.LineColorBox.Controls.Add(Me.Color6Button)
        Me.LineColorBox.Controls.Add(Me.Color5Button)
        Me.LineColorBox.Controls.Add(Me.Color5Sample)
        Me.LineColorBox.Controls.Add(Me.Color4Button)
        Me.LineColorBox.Controls.Add(Me.Color4Sample)
        Me.LineColorBox.Controls.Add(Me.Color3Button)
        Me.LineColorBox.Controls.Add(Me.Color3Sample)
        Me.LineColorBox.Controls.Add(Me.Color2Button)
        Me.LineColorBox.Controls.Add(Me.Color2Sample)
        Me.LineColorBox.Controls.Add(Me.Color1Button)
        Me.LineColorBox.Controls.Add(Me.Color1Sample)
        Me.LineColorBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineColorBox.Location = New System.Drawing.Point(8, 8)
        Me.LineColorBox.Name = "LineColorBox"
        Me.LineColorBox.Size = New System.Drawing.Size(152, 280)
        Me.LineColorBox.TabIndex = 0
        Me.LineColorBox.TabStop = False
        Me.LineColorBox.Text = "Line Colors"
        '
        'Color9Sample
        '
        Me.Color9Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Color9Sample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color9Sample.Location = New System.Drawing.Point(16, 252)
        Me.Color9Sample.Name = "Color9Sample"
        Me.Color9Sample.Size = New System.Drawing.Size(48, 16)
        Me.Color9Sample.TabIndex = 17
        '
        'Color8Sample
        '
        Me.Color8Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Color8Sample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color8Sample.Location = New System.Drawing.Point(16, 224)
        Me.Color8Sample.Name = "Color8Sample"
        Me.Color8Sample.Size = New System.Drawing.Size(48, 16)
        Me.Color8Sample.TabIndex = 16
        '
        'Color7Sample
        '
        Me.Color7Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Color7Sample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color7Sample.Location = New System.Drawing.Point(16, 196)
        Me.Color7Sample.Name = "Color7Sample"
        Me.Color7Sample.Size = New System.Drawing.Size(48, 16)
        Me.Color7Sample.TabIndex = 15
        '
        'Color6Sample
        '
        Me.Color6Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Color6Sample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color6Sample.Location = New System.Drawing.Point(16, 168)
        Me.Color6Sample.Name = "Color6Sample"
        Me.Color6Sample.Size = New System.Drawing.Size(48, 16)
        Me.Color6Sample.TabIndex = 14
        '
        'Color9Button
        '
        Me.Color9Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color9Button.Location = New System.Drawing.Point(72, 248)
        Me.Color9Button.Name = "Color9Button"
        Me.Color9Button.Size = New System.Drawing.Size(64, 23)
        Me.Color9Button.TabIndex = 13
        Me.Color9Button.Text = "Color &9"
        '
        'Color8Button
        '
        Me.Color8Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color8Button.Location = New System.Drawing.Point(72, 220)
        Me.Color8Button.Name = "Color8Button"
        Me.Color8Button.Size = New System.Drawing.Size(64, 23)
        Me.Color8Button.TabIndex = 12
        Me.Color8Button.Text = "Color &8"
        '
        'Color7Button
        '
        Me.Color7Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color7Button.Location = New System.Drawing.Point(72, 192)
        Me.Color7Button.Name = "Color7Button"
        Me.Color7Button.Size = New System.Drawing.Size(64, 23)
        Me.Color7Button.TabIndex = 11
        Me.Color7Button.Text = "Color &7"
        '
        'Color6Button
        '
        Me.Color6Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color6Button.Location = New System.Drawing.Point(72, 164)
        Me.Color6Button.Name = "Color6Button"
        Me.Color6Button.Size = New System.Drawing.Size(64, 23)
        Me.Color6Button.TabIndex = 10
        Me.Color6Button.Text = "Color &6"
        '
        'Color5Button
        '
        Me.Color5Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color5Button.Location = New System.Drawing.Point(72, 136)
        Me.Color5Button.Name = "Color5Button"
        Me.Color5Button.Size = New System.Drawing.Size(64, 23)
        Me.Color5Button.TabIndex = 9
        Me.Color5Button.Text = "Color &5"
        '
        'Color5Sample
        '
        Me.Color5Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Color5Sample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color5Sample.Location = New System.Drawing.Point(16, 140)
        Me.Color5Sample.Name = "Color5Sample"
        Me.Color5Sample.Size = New System.Drawing.Size(48, 16)
        Me.Color5Sample.TabIndex = 8
        '
        'Color4Button
        '
        Me.Color4Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color4Button.Location = New System.Drawing.Point(72, 108)
        Me.Color4Button.Name = "Color4Button"
        Me.Color4Button.Size = New System.Drawing.Size(64, 23)
        Me.Color4Button.TabIndex = 7
        Me.Color4Button.Text = "Color &4"
        '
        'Color4Sample
        '
        Me.Color4Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Color4Sample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color4Sample.Location = New System.Drawing.Point(16, 112)
        Me.Color4Sample.Name = "Color4Sample"
        Me.Color4Sample.Size = New System.Drawing.Size(48, 16)
        Me.Color4Sample.TabIndex = 6
        '
        'Color3Button
        '
        Me.Color3Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color3Button.Location = New System.Drawing.Point(72, 80)
        Me.Color3Button.Name = "Color3Button"
        Me.Color3Button.Size = New System.Drawing.Size(64, 23)
        Me.Color3Button.TabIndex = 5
        Me.Color3Button.Text = "Color &3"
        '
        'Color3Sample
        '
        Me.Color3Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Color3Sample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color3Sample.Location = New System.Drawing.Point(16, 84)
        Me.Color3Sample.Name = "Color3Sample"
        Me.Color3Sample.Size = New System.Drawing.Size(48, 16)
        Me.Color3Sample.TabIndex = 4
        '
        'Color2Button
        '
        Me.Color2Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color2Button.Location = New System.Drawing.Point(72, 52)
        Me.Color2Button.Name = "Color2Button"
        Me.Color2Button.Size = New System.Drawing.Size(64, 23)
        Me.Color2Button.TabIndex = 3
        Me.Color2Button.Text = "Color &2"
        '
        'Color2Sample
        '
        Me.Color2Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Color2Sample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color2Sample.Location = New System.Drawing.Point(16, 56)
        Me.Color2Sample.Name = "Color2Sample"
        Me.Color2Sample.Size = New System.Drawing.Size(48, 16)
        Me.Color2Sample.TabIndex = 2
        '
        'Color1Button
        '
        Me.Color1Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color1Button.Location = New System.Drawing.Point(72, 24)
        Me.Color1Button.Name = "Color1Button"
        Me.Color1Button.Size = New System.Drawing.Size(64, 23)
        Me.Color1Button.TabIndex = 1
        Me.Color1Button.Text = "Color &1"
        '
        'Color1Sample
        '
        Me.Color1Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Color1Sample.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color1Sample.Location = New System.Drawing.Point(16, 28)
        Me.Color1Sample.Name = "Color1Sample"
        Me.Color1Sample.Size = New System.Drawing.Size(48, 16)
        Me.Color1Sample.TabIndex = 0
        '
        'ContoursTab
        '
        Me.ContoursTab.Controls.Add(Me.ContourOptionsBox)
        Me.ContoursTab.Controls.Add(Me.ContourColorsGroup)
        Me.ContoursTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContoursTab.Location = New System.Drawing.Point(4, 4)
        Me.ContoursTab.Name = "ContoursTab"
        Me.ContoursTab.Size = New System.Drawing.Size(506, 294)
        Me.ContoursTab.TabIndex = 10
        Me.ContoursTab.Text = "Contours"
        '
        'ContourOptionsBox
        '
        Me.ContourOptionsBox.Controls.Add(Me.PrecisionContoursButton)
        Me.ContourOptionsBox.Controls.Add(Me.StandardContoursButton)
        Me.ContourOptionsBox.Controls.Add(Me.DisplayMinorContoursButton)
        Me.ContourOptionsBox.Controls.Add(Me.ContoursOptionsHelp)
        Me.ContourOptionsBox.Controls.Add(Me.DisplayContourPointsButton)
        Me.ContourOptionsBox.Controls.Add(Me.DisplayContourLabelsButton)
        Me.ContourOptionsBox.Controls.Add(Me.DisplayContourKeyButton)
        Me.ContourOptionsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContourOptionsBox.Location = New System.Drawing.Point(8, 168)
        Me.ContourOptionsBox.Name = "ContourOptionsBox"
        Me.ContourOptionsBox.Size = New System.Drawing.Size(490, 120)
        Me.ContourOptionsBox.TabIndex = 1
        Me.ContourOptionsBox.TabStop = False
        Me.ContourOptionsBox.Text = "Contour Options"
        '
        'PrecisionContoursButton
        '
        Me.PrecisionContoursButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecisionContoursButton.Location = New System.Drawing.Point(231, 40)
        Me.PrecisionContoursButton.Name = "PrecisionContoursButton"
        Me.PrecisionContoursButton.Size = New System.Drawing.Size(240, 24)
        Me.PrecisionContoursButton.TabIndex = 5
        Me.PrecisionContoursButton.Text = "Calculate Precision Contours"
        '
        'StandardContoursButton
        '
        Me.StandardContoursButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StandardContoursButton.Location = New System.Drawing.Point(231, 16)
        Me.StandardContoursButton.Name = "StandardContoursButton"
        Me.StandardContoursButton.Size = New System.Drawing.Size(240, 24)
        Me.StandardContoursButton.TabIndex = 4
        Me.StandardContoursButton.Text = "Calculate Standard Contours"
        '
        'DisplayMinorContoursButton
        '
        Me.DisplayMinorContoursButton.AlwaysChecked = False
        Me.DisplayMinorContoursButton.ErrorMessage = Nothing
        Me.DisplayMinorContoursButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplayMinorContoursButton.Location = New System.Drawing.Point(16, 16)
        Me.DisplayMinorContoursButton.Name = "DisplayMinorContoursButton"
        Me.DisplayMinorContoursButton.Size = New System.Drawing.Size(209, 24)
        Me.DisplayMinorContoursButton.TabIndex = 0
        Me.DisplayMinorContoursButton.Text = "Calculate Minor Contours"
        Me.DisplayMinorContoursButton.UncheckAttemptMessage = Nothing
        '
        'ContoursOptionsHelp
        '
        Me.ContoursOptionsHelp.BackColor = System.Drawing.SystemColors.Control
        Me.ContoursOptionsHelp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ContoursOptionsHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContoursOptionsHelp.Location = New System.Drawing.Point(231, 76)
        Me.ContoursOptionsHelp.Multiline = True
        Me.ContoursOptionsHelp.Name = "ContoursOptionsHelp"
        Me.ContoursOptionsHelp.Size = New System.Drawing.Size(240, 38)
        Me.ContoursOptionsHelp.TabIndex = 6
        Me.ContoursOptionsHelp.Text = "See Graphs Tab for more options."
        Me.ContoursOptionsHelp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DisplayContourPointsButton
        '
        Me.DisplayContourPointsButton.AlwaysChecked = False
        Me.DisplayContourPointsButton.ErrorMessage = Nothing
        Me.DisplayContourPointsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplayContourPointsButton.Location = New System.Drawing.Point(16, 88)
        Me.DisplayContourPointsButton.Name = "DisplayContourPointsButton"
        Me.DisplayContourPointsButton.Size = New System.Drawing.Size(209, 24)
        Me.DisplayContourPointsButton.TabIndex = 3
        Me.DisplayContourPointsButton.Text = "Display Grid Points"
        Me.DisplayContourPointsButton.UncheckAttemptMessage = Nothing
        '
        'DisplayContourLabelsButton
        '
        Me.DisplayContourLabelsButton.AlwaysChecked = False
        Me.DisplayContourLabelsButton.ErrorMessage = Nothing
        Me.DisplayContourLabelsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplayContourLabelsButton.Location = New System.Drawing.Point(16, 64)
        Me.DisplayContourLabelsButton.Name = "DisplayContourLabelsButton"
        Me.DisplayContourLabelsButton.Size = New System.Drawing.Size(209, 24)
        Me.DisplayContourLabelsButton.TabIndex = 2
        Me.DisplayContourLabelsButton.Text = "Display Contour Labels"
        Me.DisplayContourLabelsButton.UncheckAttemptMessage = Nothing
        '
        'DisplayContourKeyButton
        '
        Me.DisplayContourKeyButton.AlwaysChecked = False
        Me.DisplayContourKeyButton.ErrorMessage = Nothing
        Me.DisplayContourKeyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisplayContourKeyButton.Location = New System.Drawing.Point(16, 40)
        Me.DisplayContourKeyButton.Name = "DisplayContourKeyButton"
        Me.DisplayContourKeyButton.Size = New System.Drawing.Size(209, 24)
        Me.DisplayContourKeyButton.TabIndex = 1
        Me.DisplayContourKeyButton.Text = "Display Fill Color Key"
        Me.DisplayContourKeyButton.UncheckAttemptMessage = Nothing
        '
        'ContourColorsGroup
        '
        Me.ContourColorsGroup.Controls.Add(Me.GrayScalePanel)
        Me.ContourColorsGroup.Controls.Add(Me.ColorScalePanel)
        Me.ContourColorsGroup.Controls.Add(Me.NoFillButton)
        Me.ContourColorsGroup.Controls.Add(Me.UserDefinedButton)
        Me.ContourColorsGroup.Controls.Add(Me.GrayScaleButton)
        Me.ContourColorsGroup.Controls.Add(Me.ColorScaleButton)
        Me.ContourColorsGroup.Controls.Add(Me.UserDefinedPanel)
        Me.ContourColorsGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContourColorsGroup.Location = New System.Drawing.Point(8, 8)
        Me.ContourColorsGroup.Name = "ContourColorsGroup"
        Me.ContourColorsGroup.Size = New System.Drawing.Size(490, 152)
        Me.ContourColorsGroup.TabIndex = 0
        Me.ContourColorsGroup.TabStop = False
        Me.ContourColorsGroup.Text = "Contour Fill Colors"
        '
        'GrayScalePanel
        '
        Me.GrayScalePanel.Controls.Add(Me.FillGray90up)
        Me.GrayScalePanel.Controls.Add(Me.FillGray8090)
        Me.GrayScalePanel.Controls.Add(Me.FillGray7080)
        Me.GrayScalePanel.Controls.Add(Me.FillGray6070)
        Me.GrayScalePanel.Controls.Add(Me.FillGray5060)
        Me.GrayScalePanel.Controls.Add(Me.FillGray4050)
        Me.GrayScalePanel.Controls.Add(Me.FillGray3040)
        Me.GrayScalePanel.Controls.Add(Me.FillGray2030)
        Me.GrayScalePanel.Controls.Add(Me.FillGray1020)
        Me.GrayScalePanel.Controls.Add(Me.FillGray0010)
        Me.GrayScalePanel.Location = New System.Drawing.Point(143, 48)
        Me.GrayScalePanel.Name = "GrayScalePanel"
        Me.GrayScalePanel.Size = New System.Drawing.Size(328, 32)
        Me.GrayScalePanel.TabIndex = 5
        '
        'FillGray90up
        '
        Me.FillGray90up.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray90up.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray90up.Location = New System.Drawing.Point(296, 4)
        Me.FillGray90up.Name = "FillGray90up"
        Me.FillGray90up.Size = New System.Drawing.Size(24, 24)
        Me.FillGray90up.TabIndex = 9
        '
        'FillGray8090
        '
        Me.FillGray8090.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray8090.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray8090.Location = New System.Drawing.Point(264, 4)
        Me.FillGray8090.Name = "FillGray8090"
        Me.FillGray8090.Size = New System.Drawing.Size(24, 24)
        Me.FillGray8090.TabIndex = 8
        '
        'FillGray7080
        '
        Me.FillGray7080.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray7080.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray7080.Location = New System.Drawing.Point(232, 4)
        Me.FillGray7080.Name = "FillGray7080"
        Me.FillGray7080.Size = New System.Drawing.Size(24, 24)
        Me.FillGray7080.TabIndex = 7
        '
        'FillGray6070
        '
        Me.FillGray6070.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray6070.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray6070.Location = New System.Drawing.Point(200, 4)
        Me.FillGray6070.Name = "FillGray6070"
        Me.FillGray6070.Size = New System.Drawing.Size(24, 24)
        Me.FillGray6070.TabIndex = 6
        '
        'FillGray5060
        '
        Me.FillGray5060.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray5060.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray5060.Location = New System.Drawing.Point(168, 4)
        Me.FillGray5060.Name = "FillGray5060"
        Me.FillGray5060.Size = New System.Drawing.Size(24, 24)
        Me.FillGray5060.TabIndex = 5
        '
        'FillGray4050
        '
        Me.FillGray4050.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray4050.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray4050.Location = New System.Drawing.Point(136, 4)
        Me.FillGray4050.Name = "FillGray4050"
        Me.FillGray4050.Size = New System.Drawing.Size(24, 24)
        Me.FillGray4050.TabIndex = 4
        '
        'FillGray3040
        '
        Me.FillGray3040.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray3040.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray3040.Location = New System.Drawing.Point(104, 4)
        Me.FillGray3040.Name = "FillGray3040"
        Me.FillGray3040.Size = New System.Drawing.Size(24, 24)
        Me.FillGray3040.TabIndex = 3
        '
        'FillGray2030
        '
        Me.FillGray2030.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray2030.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray2030.Location = New System.Drawing.Point(72, 4)
        Me.FillGray2030.Name = "FillGray2030"
        Me.FillGray2030.Size = New System.Drawing.Size(24, 24)
        Me.FillGray2030.TabIndex = 2
        '
        'FillGray1020
        '
        Me.FillGray1020.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray1020.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray1020.Location = New System.Drawing.Point(40, 4)
        Me.FillGray1020.Name = "FillGray1020"
        Me.FillGray1020.Size = New System.Drawing.Size(24, 24)
        Me.FillGray1020.TabIndex = 1
        '
        'FillGray0010
        '
        Me.FillGray0010.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillGray0010.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillGray0010.Location = New System.Drawing.Point(8, 4)
        Me.FillGray0010.Name = "FillGray0010"
        Me.FillGray0010.Size = New System.Drawing.Size(24, 24)
        Me.FillGray0010.TabIndex = 0
        '
        'ColorScalePanel
        '
        Me.ColorScalePanel.Controls.Add(Me.FillColor90up)
        Me.ColorScalePanel.Controls.Add(Me.FillColor8090)
        Me.ColorScalePanel.Controls.Add(Me.FillColor7080)
        Me.ColorScalePanel.Controls.Add(Me.FillColor6070)
        Me.ColorScalePanel.Controls.Add(Me.FillColor5060)
        Me.ColorScalePanel.Controls.Add(Me.FillColor4050)
        Me.ColorScalePanel.Controls.Add(Me.FillColor3040)
        Me.ColorScalePanel.Controls.Add(Me.FillColor2030)
        Me.ColorScalePanel.Controls.Add(Me.FillColor1020)
        Me.ColorScalePanel.Controls.Add(Me.FillColor0010)
        Me.ColorScalePanel.Location = New System.Drawing.Point(143, 16)
        Me.ColorScalePanel.Name = "ColorScalePanel"
        Me.ColorScalePanel.Size = New System.Drawing.Size(328, 32)
        Me.ColorScalePanel.TabIndex = 4
        '
        'FillColor90up
        '
        Me.FillColor90up.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor90up.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor90up.Location = New System.Drawing.Point(296, 4)
        Me.FillColor90up.Name = "FillColor90up"
        Me.FillColor90up.Size = New System.Drawing.Size(24, 24)
        Me.FillColor90up.TabIndex = 9
        '
        'FillColor8090
        '
        Me.FillColor8090.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor8090.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor8090.Location = New System.Drawing.Point(264, 4)
        Me.FillColor8090.Name = "FillColor8090"
        Me.FillColor8090.Size = New System.Drawing.Size(24, 24)
        Me.FillColor8090.TabIndex = 8
        '
        'FillColor7080
        '
        Me.FillColor7080.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor7080.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor7080.Location = New System.Drawing.Point(232, 4)
        Me.FillColor7080.Name = "FillColor7080"
        Me.FillColor7080.Size = New System.Drawing.Size(24, 24)
        Me.FillColor7080.TabIndex = 7
        '
        'FillColor6070
        '
        Me.FillColor6070.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor6070.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor6070.Location = New System.Drawing.Point(200, 4)
        Me.FillColor6070.Name = "FillColor6070"
        Me.FillColor6070.Size = New System.Drawing.Size(24, 24)
        Me.FillColor6070.TabIndex = 6
        '
        'FillColor5060
        '
        Me.FillColor5060.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor5060.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor5060.Location = New System.Drawing.Point(168, 4)
        Me.FillColor5060.Name = "FillColor5060"
        Me.FillColor5060.Size = New System.Drawing.Size(24, 24)
        Me.FillColor5060.TabIndex = 5
        '
        'FillColor4050
        '
        Me.FillColor4050.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor4050.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor4050.Location = New System.Drawing.Point(136, 4)
        Me.FillColor4050.Name = "FillColor4050"
        Me.FillColor4050.Size = New System.Drawing.Size(24, 24)
        Me.FillColor4050.TabIndex = 4
        '
        'FillColor3040
        '
        Me.FillColor3040.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor3040.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor3040.Location = New System.Drawing.Point(104, 4)
        Me.FillColor3040.Name = "FillColor3040"
        Me.FillColor3040.Size = New System.Drawing.Size(24, 24)
        Me.FillColor3040.TabIndex = 3
        '
        'FillColor2030
        '
        Me.FillColor2030.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor2030.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor2030.Location = New System.Drawing.Point(72, 4)
        Me.FillColor2030.Name = "FillColor2030"
        Me.FillColor2030.Size = New System.Drawing.Size(24, 24)
        Me.FillColor2030.TabIndex = 2
        '
        'FillColor1020
        '
        Me.FillColor1020.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor1020.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor1020.Location = New System.Drawing.Point(40, 4)
        Me.FillColor1020.Name = "FillColor1020"
        Me.FillColor1020.Size = New System.Drawing.Size(24, 24)
        Me.FillColor1020.TabIndex = 1
        '
        'FillColor0010
        '
        Me.FillColor0010.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FillColor0010.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FillColor0010.Location = New System.Drawing.Point(8, 4)
        Me.FillColor0010.Name = "FillColor0010"
        Me.FillColor0010.Size = New System.Drawing.Size(24, 24)
        Me.FillColor0010.TabIndex = 0
        '
        'NoFillButton
        '
        Me.NoFillButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoFillButton.Location = New System.Drawing.Point(16, 120)
        Me.NoFillButton.Name = "NoFillButton"
        Me.NoFillButton.Size = New System.Drawing.Size(127, 24)
        Me.NoFillButton.TabIndex = 3
        Me.NoFillButton.Text = "No Fill"
        '
        'UserDefinedButton
        '
        Me.UserDefinedButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserDefinedButton.Location = New System.Drawing.Point(16, 88)
        Me.UserDefinedButton.Name = "UserDefinedButton"
        Me.UserDefinedButton.Size = New System.Drawing.Size(127, 24)
        Me.UserDefinedButton.TabIndex = 2
        Me.UserDefinedButton.Text = "User Defined"
        '
        'GrayScaleButton
        '
        Me.GrayScaleButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrayScaleButton.Location = New System.Drawing.Point(16, 54)
        Me.GrayScaleButton.Name = "GrayScaleButton"
        Me.GrayScaleButton.Size = New System.Drawing.Size(127, 24)
        Me.GrayScaleButton.TabIndex = 1
        Me.GrayScaleButton.Text = "Gray Scale"
        '
        'ColorScaleButton
        '
        Me.ColorScaleButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorScaleButton.Location = New System.Drawing.Point(16, 22)
        Me.ColorScaleButton.Name = "ColorScaleButton"
        Me.ColorScaleButton.Size = New System.Drawing.Size(127, 24)
        Me.ColorScaleButton.TabIndex = 0
        Me.ColorScaleButton.Text = "Color Scale"
        '
        'UserDefinedPanel
        '
        Me.UserDefinedPanel.Controls.Add(Me.PresetUserToGrayScale)
        Me.UserDefinedPanel.Controls.Add(Me.PresetUserToColorScale)
        Me.UserDefinedPanel.Controls.Add(Me.UserDefinedInstructions)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser90up)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser8090)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser7080)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser6070)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser5060)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser4050)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser3040)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser2030)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser1020)
        Me.UserDefinedPanel.Controls.Add(Me.FillUser0010)
        Me.UserDefinedPanel.Location = New System.Drawing.Point(143, 16)
        Me.UserDefinedPanel.Name = "UserDefinedPanel"
        Me.UserDefinedPanel.Size = New System.Drawing.Size(328, 128)
        Me.UserDefinedPanel.TabIndex = 6
        '
        'PresetUserToGrayScale
        '
        Me.PresetUserToGrayScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PresetUserToGrayScale.Location = New System.Drawing.Point(8, 40)
        Me.PresetUserToGrayScale.Name = "PresetUserToGrayScale"
        Me.PresetUserToGrayScale.Size = New System.Drawing.Size(312, 23)
        Me.PresetUserToGrayScale.TabIndex = 12
        Me.PresetUserToGrayScale.Text = "Preset User Defined Colors to Gray Scale"
        '
        'PresetUserToColorScale
        '
        Me.PresetUserToColorScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PresetUserToColorScale.Location = New System.Drawing.Point(8, 8)
        Me.PresetUserToColorScale.Name = "PresetUserToColorScale"
        Me.PresetUserToColorScale.Size = New System.Drawing.Size(312, 23)
        Me.PresetUserToColorScale.TabIndex = 11
        Me.PresetUserToColorScale.Text = "Preset User Defined Colors to Color Scale"
        '
        'UserDefinedInstructions
        '
        Me.UserDefinedInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserDefinedInstructions.Location = New System.Drawing.Point(8, 104)
        Me.UserDefinedInstructions.Name = "UserDefinedInstructions"
        Me.UserDefinedInstructions.Size = New System.Drawing.Size(312, 20)
        Me.UserDefinedInstructions.TabIndex = 10
        Me.UserDefinedInstructions.Text = "Press button to change User Defined color."
        Me.UserDefinedInstructions.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FillUser90up
        '
        Me.FillUser90up.Location = New System.Drawing.Point(296, 72)
        Me.FillUser90up.Name = "FillUser90up"
        Me.FillUser90up.Size = New System.Drawing.Size(24, 23)
        Me.FillUser90up.TabIndex = 9
        '
        'FillUser8090
        '
        Me.FillUser8090.Location = New System.Drawing.Point(264, 72)
        Me.FillUser8090.Name = "FillUser8090"
        Me.FillUser8090.Size = New System.Drawing.Size(24, 23)
        Me.FillUser8090.TabIndex = 8
        '
        'FillUser7080
        '
        Me.FillUser7080.Location = New System.Drawing.Point(232, 72)
        Me.FillUser7080.Name = "FillUser7080"
        Me.FillUser7080.Size = New System.Drawing.Size(24, 23)
        Me.FillUser7080.TabIndex = 7
        '
        'FillUser6070
        '
        Me.FillUser6070.Location = New System.Drawing.Point(200, 72)
        Me.FillUser6070.Name = "FillUser6070"
        Me.FillUser6070.Size = New System.Drawing.Size(24, 23)
        Me.FillUser6070.TabIndex = 6
        '
        'FillUser5060
        '
        Me.FillUser5060.Location = New System.Drawing.Point(168, 72)
        Me.FillUser5060.Name = "FillUser5060"
        Me.FillUser5060.Size = New System.Drawing.Size(24, 23)
        Me.FillUser5060.TabIndex = 5
        '
        'FillUser4050
        '
        Me.FillUser4050.Location = New System.Drawing.Point(136, 72)
        Me.FillUser4050.Name = "FillUser4050"
        Me.FillUser4050.Size = New System.Drawing.Size(24, 23)
        Me.FillUser4050.TabIndex = 4
        '
        'FillUser3040
        '
        Me.FillUser3040.Location = New System.Drawing.Point(104, 72)
        Me.FillUser3040.Name = "FillUser3040"
        Me.FillUser3040.Size = New System.Drawing.Size(24, 23)
        Me.FillUser3040.TabIndex = 3
        '
        'FillUser2030
        '
        Me.FillUser2030.Location = New System.Drawing.Point(72, 72)
        Me.FillUser2030.Name = "FillUser2030"
        Me.FillUser2030.Size = New System.Drawing.Size(24, 23)
        Me.FillUser2030.TabIndex = 2
        '
        'FillUser1020
        '
        Me.FillUser1020.Location = New System.Drawing.Point(40, 72)
        Me.FillUser1020.Name = "FillUser1020"
        Me.FillUser1020.Size = New System.Drawing.Size(24, 23)
        Me.FillUser1020.TabIndex = 1
        '
        'FillUser0010
        '
        Me.FillUser0010.Location = New System.Drawing.Point(8, 72)
        Me.FillUser0010.Name = "FillUser0010"
        Me.FillUser0010.Size = New System.Drawing.Size(24, 23)
        Me.FillUser0010.TabIndex = 0
        '
        'ColorDialog
        '
        Me.ColorDialog.AnyColor = True
        Me.ColorDialog.SolidColorOnly = True
        '
        'UserPreferences
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(514, 375)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.OkayButton)
        Me.Controls.Add(Me.UserPreferenceTabs)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserPreferences"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Preferences"
        Me.FilesTab.ResumeLayout(False)
        Me.DataFolderBox.ResumeLayout(False)
        Me.DataFolderBox.PerformLayout()
        Me.LogDiagFolderBox.ResumeLayout(False)
        Me.LogDiagFolderBox.PerformLayout()
        Me.StartupTab.ResumeLayout(False)
        Me.StartupTab.PerformLayout()
        Me.ProjectBox.ResumeLayout(False)
        Me.ProjectBox.PerformLayout()
        Me.UnitsTab.ResumeLayout(False)
        Me.UnitsGroup.ResumeLayout(False)
        Me.EnglishBox.ResumeLayout(False)
        Me.MetricBox.ResumeLayout(False)
        Me.UserPreferenceTabs.ResumeLayout(False)
        Me.ViewsTab.ResumeLayout(False)
        Me.ResultsGroup.ResumeLayout(False)
        Me.DialogsTab.ResumeLayout(False)
        Me.DefaultValuesGroup.ResumeLayout(False)
        Me.GraphsTab.ResumeLayout(False)
        Me.GraphOptionsBox.ResumeLayout(False)
        Me.GraphOptionsBox.PerformLayout()
        Me.LineColorBox.ResumeLayout(False)
        Me.ContoursTab.ResumeLayout(False)
        Me.ContourOptionsBox.ResumeLayout(False)
        Me.ContourOptionsBox.PerformLayout()
        Me.ContourColorsGroup.ResumeLayout(False)
        Me.GrayScalePanel.ResumeLayout(False)
        Me.ColorScalePanel.ResumeLayout(False)
        Me.UserDefinedPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Language Translation
    '
    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Properties "

#Region " Application Properties "

    Private mApplicationVersion As String
    ReadOnly Property ApplicationVersion() As String
        Get
            Return mApplicationVersion
        End Get
    End Property

    Private mProjectNomenclature As ProjectNomenclatures = Globals.ProjectNomenclatures.FarmField
    ReadOnly Property ProjectNomenclature() As ProjectNomenclatures
        Get
            Return mProjectNomenclature
        End Get
    End Property

#End Region

#Region " Startup Properties "

    Private mFarmName As String
    ReadOnly Property DefaultFarmName() As String
        Get
            Return mFarmName
        End Get
    End Property

    Private mFarmOwner As String
    ReadOnly Property DefaultFarmOwner() As String
        Get
            Return mFarmOwner
        End Get
    End Property

    Private mEvaluator As String
    ReadOnly Property DefaultEvaluator() As String
        Get
            Return mEvaluator
        End Get
    End Property

    Private mOpenPreviousFile As Boolean
    Public Property OpenPreviousFile() As Boolean
        Get
            Return mOpenPreviousFile
        End Get
        Set(ByVal Value As Boolean)
            mOpenPreviousFile = Value
            Me.AutoOpenPreviousFile.Checked = mOpenPreviousFile
        End Set
    End Property

#End Region

#Region " Files Properties "

    Private mLogFolder As String
    ReadOnly Property DefaultLogFolder() As String
        Get
            '
            ' Exception may be caused if looking at CD Drive with no CD
            '
            Try
                If (mLogFolder = String.Empty) Then
                    ResetLogFolder()
                End If

                Dim _di As DirectoryInfo = New DirectoryInfo(mLogFolder)

                If (_di.Exists) Then
                    If ((_di.Attributes And FileAttributes.Directory) = FileAttributes.Directory) Then
                        ' Log Folder exists & is a directory
                        Return mLogFolder
                    End If
                End If

            Catch ex As Exception
                ' Just fall through to error handling code below
            End Try

            ' Set log folder back to its default and warn the user
            Dim _logFolder As String = mLogFolder

            ResetLogFolder()

            MsgBox(_logFolder + Chr(13) + Chr(13) _
                 + "          Does not exist or is not a directory" + Chr(13) + Chr(13) + _
                   mLogFolder + Chr(13) + Chr(13) _
                 + "          Is being used intead", _
                   MsgBoxStyle.OkOnly, _
                   "User Preferences - Default Log Folder Error")

            Return mLogFolder
        End Get
    End Property

    Private mDataFolder As String
    ReadOnly Property DefaultDataFolder() As String
        Get
            '
            ' Exception may be caused if looking at CD Drive with no CD
            '
            Try
                If (mDataFolder = String.Empty) Then
                    ResetDataFolder()
                End If

                Dim _di As DirectoryInfo = New DirectoryInfo(mDataFolder)

                If (_di.Exists) Then
                    If ((_di.Attributes And FileAttributes.Directory) = FileAttributes.Directory) Then
                        ' Data Folder exists & is a directory
                        Return mDataFolder
                    End If
                End If

            Catch ex As Exception
                ' Just fall through to error handling code below
            End Try

            ' Set data folder back to its default and warn the user
            Dim _dataFolder As String = mDataFolder

            ResetDataFolder()

            MsgBox(_dataFolder + Chr(13) + Chr(13) _
                 + "          Does not exist or is not a directory" + Chr(13) + Chr(13) + _
                   mDataFolder + Chr(13) + Chr(13) _
                 + "          Is being used intead", _
                   MsgBoxStyle.OkOnly, _
                   "User Preferences - Default Data Folder Error")

            Return mDataFolder
        End Get
    End Property

#End Region

#Region " Views Properties "

    Private mResultsView As ResultsViews
    Public Property ResultsView() As ResultsViews
        Get
            Return mResultsView
        End Get
        Set(ByVal Value As ResultsViews)
            mResultsView = Value
            Select Case (mResultsView)
                Case Globals.ResultsViews.PortraitPage
                    Me.PortraitPage.Checked = True
                Case Else ' Assume Globals.ResultsViews.GraphsOnly
                    Me.GraphsOnly.Checked = True
            End Select
        End Set
    End Property

    Private mShowSimulationAnimation As Boolean
    Public Property ShowSimulationAnimation() As Boolean
        Get
            Return mShowSimulationAnimation
        End Get
        Set(ByVal Value As Boolean)
            mShowSimulationAnimation = Value
            Me.ShowSimulationAnimationButton.Checked = mShowSimulationAnimation
        End Set
    End Property

#End Region

#Region " Dialogs Properties "

    Private mDefaultValueResponse As DefaultValueResponses
    ReadOnly Property DefaultValueResponse() As DefaultValueResponses
        Get
            Return mDefaultValueResponse
        End Get
    End Property

#End Region

#Region " Units Properties "

#Region " Metric "

    Private mMetricOptions As Boolean
    ReadOnly Property MetricOptionsEnabled() As Boolean
        Get
            Return mMetricOptions
        End Get
    End Property

    Private mMetricFlowRate As Units
    ReadOnly Property DefaultMetricFlowRate() As Units
        Get
            Return mMetricFlowRate
        End Get
    End Property

    Private mMetricFieldSlope As Units
    ReadOnly Property DefaultMetricFieldSlope() As Units
        Get
            Return mMetricFieldSlope
        End Get
    End Property

    Private mMetricFurrowShape As Units
    ReadOnly Property DefaultMetricFurrowShape() As Units
        Get
            Return mMetricFurrowShape
        End Get
    End Property

    Private mMetricWaterDepth As Units
    ReadOnly Property DefaultMetricWaterDepth() As Units
        Get
            Return mMetricWaterDepth
        End Get
    End Property

#End Region

#Region " English "

    Private mEnglishOptions As Boolean
    ReadOnly Property EnglishOptionsEnabled() As Boolean
        Get
            Return mEnglishOptions
        End Get
    End Property

    Private mEnglishFlowRate As Units
    ReadOnly Property DefaultEnglishFlowRate() As Units
        Get
            Return mEnglishFlowRate
        End Get
    End Property

    Private mEnglishFieldSlope As Units
    ReadOnly Property DefaultEnglishFieldSlope() As Units
        Get
            Return mEnglishFieldSlope
        End Get
    End Property

    Private mEnglishFurrowShape As Units
    ReadOnly Property DefaultEnglishFurrowShape() As Units
        Get
            Return mEnglishFurrowShape
        End Get
    End Property

    Private mEnglishWaterDepth As Units
    ReadOnly Property DefaultEnglishWaterDepth() As Units
        Get
            Return mEnglishWaterDepth
        End Get
    End Property

#End Region

    Private mTimeUnits As Units
    ReadOnly Property DefaultTimeUnits() As Units
        Get
            Return mTimeUnits
        End Get
    End Property

#End Region

#Region " Graph Properties "

    Private mColor0 As Drawing.Color
    ReadOnly Property Color0() As Drawing.Color
        Get
            Return mColor0
        End Get
    End Property

    Private mColor1 As Drawing.Color
    ReadOnly Property Color1() As Drawing.Color
        Get
            Return mColor1
        End Get
    End Property

    Private mColor2 As Drawing.Color
    ReadOnly Property Color2() As Drawing.Color
        Get
            Return mColor2
        End Get
    End Property

    Private mColor3 As Drawing.Color
    ReadOnly Property Color3() As Drawing.Color
        Get
            Return mColor3
        End Get
    End Property

    Private mColor4 As Drawing.Color
    ReadOnly Property Color4() As Drawing.Color
        Get
            Return mColor4
        End Get
    End Property

    Private mColor5 As Drawing.Color
    ReadOnly Property Color5() As Drawing.Color
        Get
            Return mColor5
        End Get
    End Property

    Private mColor6 As Drawing.Color
    ReadOnly Property Color6() As Drawing.Color
        Get
            Return mColor6
        End Get
    End Property

    Private mColor7 As Drawing.Color
    ReadOnly Property Color7() As Drawing.Color
        Get
            Return mColor7
        End Get
    End Property

    Private mColor8 As Drawing.Color
    ReadOnly Property Color8() As Drawing.Color
        Get
            Return mColor8
        End Get
    End Property

    Private mColor9 As Drawing.Color
    ReadOnly Property Color9() As Drawing.Color
        Get
            Return mColor9
        End Get
    End Property

    Public Function ColorN(ByVal _n As Integer) As Drawing.Color
        _n = _n Mod 10
        Select Case _n
            Case 1
                Return Color1
            Case 2
                Return Color2
            Case 3
                Return Color3
            Case 4
                Return Color4
            Case 5
                Return Color5
            Case 6
                Return Color6
            Case 7
                Return Color7
            Case 8
                Return Color8
            Case 9
                Return Color9
            Case Else
                Return Color0
        End Select
    End Function

    Private mDisplayTitle As Boolean
    Public Property DisplayTitle() As Boolean
        Get
            Return mDisplayTitle
        End Get
        Set(ByVal Value As Boolean)
            mDisplayTitle = Value
            Me.DisplayTitleButton.Checked = mDisplayTitle
        End Set
    End Property

    Private mDisplaySubtitles As Boolean
    Public Property DisplaySubtitles() As Boolean
        Get
            Return mDisplaySubtitles
        End Get
        Set(ByVal Value As Boolean)
            mDisplaySubtitles = Value
            Me.DisplaySubtitlesButton.Checked = mDisplaySubtitles
        End Set
    End Property

    Private mDisplayAxisLabels As Boolean
    Public Property DisplayAxisLabels() As Boolean
        Get
            Return mDisplayAxisLabels
        End Get
        Set(ByVal Value As Boolean)
            mDisplayAxisLabels = Value
            Me.DisplayAxisLabelsButton.Checked = mDisplayAxisLabels
        End Set
    End Property

    Private mInstalledFonts As Drawing.Text.InstalledFontCollection = New Drawing.Text.InstalledFontCollection
    Private mSelectedFont As String
    Public ReadOnly Property SelectedFont() As String
        Get
            Return mSelectedFont
        End Get
    End Property

    Private mFontAdjustment As Integer = 0
    Public ReadOnly Property FontAdjustment() As Integer
        Get
            Return mFontAdjustment
        End Get
    End Property

#End Region

#Region " Contour Properties "

    Private mFillColors As FillColors
    Public Property FillColors() As FillColors
        Get
            Return mFillColors
        End Get
        Set(ByVal Value As FillColors)
            mFillColors = Value
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Me.ColorScaleButton.Checked = True
                    Me.GrayScalePanel.Hide()
                    Me.UserDefinedPanel.Hide()
                    Me.ColorScalePanel.Show()
                Case Globals.FillColors.GrayScale
                    Me.GrayScaleButton.Checked = True
                    Me.UserDefinedPanel.Hide()
                    Me.ColorScalePanel.Hide()
                    Me.GrayScalePanel.Show()
                Case Globals.FillColors.UserDefined
                    Me.UserDefinedButton.Checked = True
                    Me.GrayScalePanel.Hide()
                    Me.ColorScalePanel.Hide()
                    Me.UserDefinedPanel.Show()
                Case Else ' Assume Globals.FillColors.NoFill
                    Me.NoFillButton.Checked = True
                    Me.ColorScalePanel.Hide()
                    Me.GrayScalePanel.Hide()
                    Me.UserDefinedPanel.Hide()
            End Select
        End Set
    End Property

    Private mFillColor0 As Drawing.Color
    ReadOnly Property FillColor0() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(0)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(0)
                Case Globals.FillColors.UserDefined
                    Return mFillColor0
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Private mFillColor1 As Drawing.Color
    ReadOnly Property FillColor1() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(1)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(1)
                Case Globals.FillColors.UserDefined
                    Return mFillColor1
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Private mFillColor2 As Drawing.Color
    ReadOnly Property FillColor2() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(2)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(2)
                Case Globals.FillColors.UserDefined
                    Return mFillColor2
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Private mFillColor3 As Drawing.Color
    ReadOnly Property FillColor3() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(3)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(3)
                Case Globals.FillColors.UserDefined
                    Return mFillColor3
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Private mFillColor4 As Drawing.Color
    ReadOnly Property FillColor4() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(4)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(4)
                Case Globals.FillColors.UserDefined
                    Return mFillColor4
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Private mFillColor5 As Drawing.Color
    ReadOnly Property FillColor5() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(5)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(5)
                Case Globals.FillColors.UserDefined
                    Return mFillColor5
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Private mFillColor6 As Drawing.Color
    ReadOnly Property FillColor6() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(6)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(6)
                Case Globals.FillColors.UserDefined
                    Return mFillColor6
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Private mFillColor7 As Drawing.Color
    ReadOnly Property FillColor7() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(7)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(7)
                Case Globals.FillColors.UserDefined
                    Return mFillColor7
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Private mFillColor8 As Drawing.Color
    ReadOnly Property FillColor8() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(8)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(8)
                Case Globals.FillColors.UserDefined
                    Return mFillColor8
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Private mFillColor9 As Drawing.Color
    ReadOnly Property FillColor9() As Drawing.Color
        Get
            Select Case (mFillColors)
                Case Globals.FillColors.ColorScale
                    Return Globals.ColorScaleLevels(9)
                Case Globals.FillColors.GrayScale
                    Return Globals.GrayScaleLevels(9)
                Case Globals.FillColors.UserDefined
                    Return mFillColor9
            End Select
            Return Drawing.Color.Transparent
        End Get
    End Property

    Public Function FillColorN(ByVal _n As Integer) As Drawing.Color
        _n = _n Mod 10
        Select Case _n
            Case 1
                Return FillColor1
            Case 2
                Return FillColor2
            Case 3
                Return FillColor3
            Case 4
                Return FillColor4
            Case 5
                Return FillColor5
            Case 6
                Return FillColor6
            Case 7
                Return FillColor7
            Case 8
                Return FillColor8
            Case 9
                Return FillColor9
            Case Else
                Return FillColor0
        End Select
    End Function

    Private mCalculatePrecisionContours As Boolean
    Public Property CalculatePrecisionContours() As Boolean
        Get
            Return mCalculatePrecisionContours
        End Get
        Set(ByVal Value As Boolean)
            mCalculatePrecisionContours = Value
            Me.PrecisionContoursButton.Checked = mCalculatePrecisionContours
            Me.StandardContoursButton.Checked = Not mCalculatePrecisionContours
        End Set
    End Property

    Private mDisplayMinorContours As Boolean
    Public Property DisplayMinorContours() As Boolean
        Get
            Return mDisplayMinorContours
        End Get
        Set(ByVal Value As Boolean)
            mDisplayMinorContours = Value
            Me.DisplayMinorContoursButton.Checked = mDisplayMinorContours
        End Set
    End Property

    Private mDisplayContourKey As Boolean
    Public Property DisplayContourKey() As Boolean
        Get
            Return mDisplayContourKey
        End Get
        Set(ByVal Value As Boolean)
            mDisplayContourKey = Value
            Me.DisplayContourKeyButton.Checked = mDisplayContourKey
        End Set
    End Property

    Private mDisplayContourLabels As Boolean
    Public Property DisplayContourLabels() As Boolean
        Get
            Return mDisplayContourLabels
        End Get
        Set(ByVal Value As Boolean)
            mDisplayContourLabels = Value
            Me.DisplayContourLabelsButton.Checked = mDisplayContourLabels
        End Set
    End Property

    Private mDisplayContourPoints As Boolean
    Public Property DisplayContourPoints() As Boolean
        Get
            Return mDisplayContourPoints
        End Get
        Set(ByVal Value As Boolean)
            mDisplayContourPoints = Value
            Me.DisplayContourPointsButton.Checked = mDisplayContourPoints
        End Set
    End Property

#End Region

#End Region

#Region " Initialization Section "
    '
    ' Shared Instance() method for obtaining reference to User Preferences
    '
    '
    Private Shared mUserPreferences As UserPreferences = Nothing
    Public Shared Function Instance() As UserPreferences
        If (mUserPreferences Is Nothing) Then
            mUserPreferences = New UserPreferences
        End If
        Return mUserPreferences
    End Function
    '
    ' Initialize the User Preferences dialog box
    '
    Private Sub InitializeUserPreferences()

        Me.Text = mDictionary.ControlText(Me)

        ApplicationInitialization()

        ' Initialize values by Tab Page
        StartupInitialization()
        FilesInitialization()
        ViewInitialization()
        DialogInitialization()
        UnitsInitialization()
        GraphInitialization()
        ContourInitialization()

        ReadFromRegistry()

    End Sub
    '
    ' Initialize the Application properties
    '
    Private Sub ApplicationInitialization()
        mApplicationVersion = String.Empty
    End Sub
    '
    ' Initialize the Startup preferences
    '
    Private Sub StartupInitialization()

        ' Default Farm Name
        mFarmName = String.Empty
        FarmName.Text = mFarmName

        ' Default Farm Owner
        mFarmOwner = String.Empty
        FarmOwner.Text = mFarmOwner

        ' Default Evaluator
        mEvaluator = String.Empty
        Evaluator.Text = mEvaluator

        ' Default Open Previous File
        OpenPreviousFile = DefaultOpenPreviousFile

    End Sub
    '
    ' Initialize the Files preferences
    '
    Private Sub FilesInitialization()
        ' Default Log & Diagnostics Folder
        ResetLogFolder()
    End Sub
    '
    ' Initialize the Views preferences
    '
    Private Sub ViewInitialization()
        ' Default Results View
        ResultsView = Globals.DefaultResultsView

        ' View Enables
        ShowSimulationAnimation = DefaultShowSimulationAnimation

    End Sub
    '
    ' Initialize the Dialog preferences
    '
    Private Sub DialogInitialization()
        ' Default Value Response
        mDefaultValueResponse = DefaultValueResponse

        Select Case (mDefaultValueResponse)
            Case Globals.DefaultValueResponses.UnconditionallyAccept
                UnconditionallyAccept.Checked = True
            Case Globals.DefaultValueResponses.RequireConfirmation
                RequireConfirmation.Checked = True
            Case Else
                Debug.Assert(False)
        End Select

    End Sub
    '
    ' Initialize the Units preferences
    '
    Private Sub UnitsInitialization()
        Dim _idx As Integer

        ' Time Units
        Me.TimeUnits.Items.Clear()
        _idx = 0
        For Each txt As String In UnitsText
            If ((Units.SystemTimeLow <= _idx) And (_idx <= Units.SystemTimeHigh)) Then
                TimeUnits.Items.Add(txt)
            End If
            _idx += 1
        Next

        ' Metric Options
        MetricFlowRateUnits.Items.Clear()
        _idx = 0
        For Each txt As String In UnitsText
            If ((Units.FlowRateMetricLow <= _idx) And (_idx <= Units.FlowRateMetricHigh)) Then
                MetricFlowRateUnits.Items.Add(txt)
            End If
            _idx += 1
        Next

        MetricFieldSlopeUnits.Items.Clear()
        _idx = 0
        For Each txt As String In UnitsText
            If ((Units.SlopeMetricLow <= _idx) And (_idx <= Units.SlopeMetricHigh)) Then
                MetricFieldSlopeUnits.Items.Add(txt)
            End If
            _idx += 1
        Next

        MetricFurrowShapeUnits.Items.Clear()
        MetricFurrowShapeUnits.Items.Add(UnitsText(Units.Meters))
        MetricFurrowShapeUnits.Items.Add(UnitsText(Units.Centimeters))
        MetricFurrowShapeUnits.Items.Add(UnitsText(Units.Millimeters))

        MetricWaterDepthUnits.Items.Clear()
        MetricWaterDepthUnits.Items.Add(UnitsText(Units.Meters))
        MetricWaterDepthUnits.Items.Add(UnitsText(Units.Centimeters))
        MetricWaterDepthUnits.Items.Add(UnitsText(Units.Millimeters))

        ' English Options
        EnglishFlowRateUnits.Items.Clear()
        _idx = 0
        For Each txt As String In UnitsText
            If ((Units.FlowRateEnglishLow <= _idx) And (_idx <= Units.FlowRateEnglishHigh)) Then
                EnglishFlowRateUnits.Items.Add(txt)
            End If
            _idx += 1
        Next

        EnglishFieldSlopeUnits.Items.Clear()
        _idx = 0
        For Each txt As String In UnitsText
            If ((Units.SlopeEnglishLow <= _idx) And (_idx <= Units.SlopeEnglishHigh)) Then
                EnglishFieldSlopeUnits.Items.Add(txt)
            End If
            _idx += 1
        Next

        EnglishFurrowShapeUnits.Items.Clear()
        EnglishFurrowShapeUnits.Items.Add(UnitsText(Units.Feet))
        EnglishFurrowShapeUnits.Items.Add(UnitsText(Units.Inches))

        EnglishWaterDepthUnits.Items.Clear()
        EnglishWaterDepthUnits.Items.Add(UnitsText(Units.Feet))
        EnglishWaterDepthUnits.Items.Add(UnitsText(Units.Inches))

        ' Set default initial values
        Metric.Checked = True
        EnglishBox.Enabled = False

        mMetricOptions = True
        mEnglishOptions = False

        MetricFlowRateUnits.SelectedIndex = 1
        MetricFieldSlopeUnits.SelectedIndex = 0
        MetricFurrowShapeUnits.SelectedIndex = 2
        MetricWaterDepthUnits.SelectedIndex = 2

        EnglishFlowRateUnits.SelectedIndex = 0
        EnglishFieldSlopeUnits.SelectedIndex = 0
        EnglishFurrowShapeUnits.SelectedIndex = 1
        EnglishWaterDepthUnits.SelectedIndex = 1

        TimeUnits.SelectedIndex = 1

    End Sub
    '
    ' Initialize the Graph preferences
    '
    Private Sub GraphInitialization()

        ' Graph line colors
        mColor0 = Drawing.Color.Black

        mColor1 = Drawing.Color.Black
        Me.Color1Sample.BackColor = Color1

        mColor2 = Drawing.Color.Magenta
        Me.Color2Sample.BackColor = Color2

        mColor3 = Drawing.Color.DarkOrchid
        Me.Color3Sample.BackColor = Color3

        mColor4 = Drawing.Color.Blue
        Me.Color4Sample.BackColor = Color4

        mColor5 = Drawing.Color.YellowGreen
        Me.Color5Sample.BackColor = Color5

        mColor6 = Drawing.Color.DarkGoldenrod
        Me.Color6Sample.BackColor = Color6

        mColor7 = Drawing.Color.Orange
        Me.Color7Sample.BackColor = Color7

        mColor8 = Drawing.Color.Red
        Me.Color8Sample.BackColor = Color8

        mColor9 = Drawing.Color.Crimson
        Me.Color9Sample.BackColor = Color9

        ' Axis labels
        Me.DisplayTitle = DefaultDisplayTitle
        Me.DisplaySubtitles = DefaultDisplaySubtitles
        Me.DisplayAxisLabels = DefaultDisplayAxisLabels

        ' Font & size
        mSelectedFont = Me.Font.FontFamily.Name
        Me.InstalledFonts.Items.Clear()
        For Each _family As FontFamily In mInstalledFonts.Families
            Dim _name As String = _family.Name

            Try
                ' Check if Regular font can be generated from this name
                Me.FontSample.Font = New Font(_name, Me.FontSample.Font.Size)
                Me.InstalledFonts.Items.Add(_name)
            Catch ex As Exception
            End Try
        Next
        Me.InstalledFonts.SelectedItem = mSelectedFont

        mFontAdjustment = 0
        Me.FontSize.Items.Clear()
        Me.FontSize.Items.Add("-2")
        Me.FontSize.Items.Add("-1")
        Me.FontSize.Items.Add(mDictionary.tNormal.Translated)
        Me.FontSize.Items.Add("+1")
        Me.FontSize.Items.Add("+2")
        Me.FontSize.SelectedIndex = mFontAdjustment + 2

    End Sub
    '
    ' Initialize the Contour preferences
    '
    Private Sub ContourInitialization()
        ' Contour Calculation Options
        CalculatePrecisionContours = DefaultCalculatePrecisionContours

        ' Contour Display Options
        DisplayMinorContours = DefaultDisplayMinorContours
        DisplayContourKey = DefaultDisplayContourKey
        DisplayContourLabels = DefaultDisplayContourLabels
        DisplayContourPoints = DefaultDisplayContourPoints

        ' Default Fill Colors
        FillColors = Globals.DefaultFillColors

        ' Contour Fill Colors
        Me.FillColor0010.BackColor = Globals.ColorScaleLevels(0)
        Me.FillColor1020.BackColor = Globals.ColorScaleLevels(1)
        Me.FillColor2030.BackColor = Globals.ColorScaleLevels(2)
        Me.FillColor3040.BackColor = Globals.ColorScaleLevels(3)
        Me.FillColor4050.BackColor = Globals.ColorScaleLevels(4)
        Me.FillColor5060.BackColor = Globals.ColorScaleLevels(5)
        Me.FillColor6070.BackColor = Globals.ColorScaleLevels(6)
        Me.FillColor7080.BackColor = Globals.ColorScaleLevels(7)
        Me.FillColor8090.BackColor = Globals.ColorScaleLevels(8)
        Me.FillColor90up.BackColor = Globals.ColorScaleLevels(9)

        Me.FillGray0010.BackColor = Globals.GrayScaleLevels(0)
        Me.FillGray1020.BackColor = Globals.GrayScaleLevels(1)
        Me.FillGray2030.BackColor = Globals.GrayScaleLevels(2)
        Me.FillGray3040.BackColor = Globals.GrayScaleLevels(3)
        Me.FillGray4050.BackColor = Globals.GrayScaleLevels(4)
        Me.FillGray5060.BackColor = Globals.GrayScaleLevels(5)
        Me.FillGray6070.BackColor = Globals.GrayScaleLevels(6)
        Me.FillGray7080.BackColor = Globals.GrayScaleLevels(7)
        Me.FillGray8090.BackColor = Globals.GrayScaleLevels(8)
        Me.FillGray90up.BackColor = Globals.GrayScaleLevels(9)

        Me.FillUser0010.BackColor = Globals.ColorScaleLevels(0)
        Me.FillUser1020.BackColor = Globals.ColorScaleLevels(1)
        Me.FillUser2030.BackColor = Globals.ColorScaleLevels(2)
        Me.FillUser3040.BackColor = Globals.ColorScaleLevels(3)
        Me.FillUser4050.BackColor = Globals.ColorScaleLevels(4)
        Me.FillUser5060.BackColor = Globals.ColorScaleLevels(5)
        Me.FillUser6070.BackColor = Globals.ColorScaleLevels(6)
        Me.FillUser7080.BackColor = Globals.ColorScaleLevels(7)
        Me.FillUser8090.BackColor = Globals.ColorScaleLevels(8)
        Me.FillUser90up.BackColor = Globals.ColorScaleLevels(9)

    End Sub

#End Region

#Region " Methods "
    '
    ' Reset Default Folders
    '
    Private Sub ResetLogFolder()
        mLogFolder = Application.UserAppDataPath
        LogFolder.Text = mLogFolder
    End Sub

    Private Sub ResetDataFolder()
        mDataFolder = Application.UserAppDataPath
        DataFolder.Text = mDataFolder
    End Sub

#End Region

#Region " Startup Tab Events "

    Private Sub AutoOpenPreviousFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AutoOpenPreviousFile.CheckedChanged
        OpenPreviousFile = AutoOpenPreviousFile.Checked
    End Sub

#End Region

#Region " Files Tab Events "
    '
    ' Load & Diagnostics Folder
    '
    Private Sub ResetLogFolderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ResetLogFolderButton.Click
        ResetLogFolder()
    End Sub

    Private Sub BrowseLogFolderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BrowseLogFolderButton.Click

        Dim result As DialogResult = FolderBrowserDialog.ShowDialog()

        If (result = DialogResult.OK) Then
            mLogFolder = FolderBrowserDialog.SelectedPath
            LogFolder.Text = mLogFolder
        End If

    End Sub
    '
    ' Data Folder
    '
    Private Sub ResetDataFolderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ResetDataFolderButton.Click
        ResetDataFolder()
    End Sub

    Private Sub BrowseDataFolderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BrowseDataFolderButton.Click

        Dim result As DialogResult = FolderBrowserDialog.ShowDialog()

        If (result = DialogResult.OK) Then
            mDataFolder = FolderBrowserDialog.SelectedPath
            DataFolder.Text = mDataFolder
        End If

    End Sub

#End Region

#Region " Views Tab Events "

    Private Sub PortraitPage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PortraitPage.CheckedChanged
        If (PortraitPage.Checked) Then
            ResultsView = Globals.ResultsViews.PortraitPage
        End If
    End Sub

    Private Sub GraphsOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GraphsOnly.CheckedChanged
        If (GraphsOnly.Checked) Then
            ResultsView = Globals.ResultsViews.GraphsOnly
        End If
    End Sub

    Private Sub SimulationAnimationButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowSimulationAnimationButton.CheckedChanged
        ShowSimulationAnimation = ShowSimulationAnimationButton.Checked
    End Sub

#End Region

#Region " Dialogs Tab Events "

    Private Sub UnconditionallyAccept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles UnconditionallyAccept.CheckedChanged
        If (UnconditionallyAccept.Checked) Then
            mDefaultValueResponse = Globals.DefaultValueResponses.UnconditionallyAccept
        End If
    End Sub

    Private Sub RequireConfirmation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RequireConfirmation.CheckedChanged
        If (RequireConfirmation.Checked) Then
            mDefaultValueResponse = Globals.DefaultValueResponses.RequireConfirmation
        End If
    End Sub

#End Region

#Region " Units Tab Events "

#Region " Metric "

    Private Sub MetricRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Metric.CheckedChanged
        If Metric.Checked Then
            MetricBox.Enabled = True
            EnglishBox.Enabled = False
            mMetricOptions = True
            mEnglishOptions = False
        End If
    End Sub

    Private Sub MetricFlowRateCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetricFlowRateUnits.SelectedIndexChanged
        If MetricFlowRateUnits.SelectedIndex = 0 Then
            mMetricFlowRate = UnitsDefinition.Units.Cms
        ElseIf MetricFlowRateUnits.SelectedIndex = 1 Then
            mMetricFlowRate = UnitsDefinition.Units.Lps
        ElseIf MetricFlowRateUnits.SelectedIndex = 2 Then
            mMetricFlowRate = UnitsDefinition.Units.Lpm
        End If
    End Sub

    Private Sub MetricFieldSlopeCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetricFieldSlopeUnits.SelectedIndexChanged
        If MetricFieldSlopeUnits.SelectedIndex = 0 Then
            mMetricFieldSlope = UnitsDefinition.Units.MetersPerMeter
        ElseIf MetricFieldSlopeUnits.SelectedIndex = 1 Then
            mMetricFieldSlope = UnitsDefinition.Units.MetersPer100Meters
        End If
    End Sub

    Private Sub MetricFurrowShapeCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetricFurrowShapeUnits.SelectedIndexChanged
        If MetricFurrowShapeUnits.SelectedIndex = 0 Then
            mMetricFurrowShape = UnitsDefinition.Units.Meters
        ElseIf MetricFurrowShapeUnits.SelectedIndex = 1 Then
            mMetricFurrowShape = UnitsDefinition.Units.Centimeters
        ElseIf MetricFurrowShapeUnits.SelectedIndex = 2 Then
            mMetricFurrowShape = UnitsDefinition.Units.Millimeters
        End If
    End Sub

    Private Sub MetricWaterDepthCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MetricWaterDepthUnits.SelectedIndexChanged
        If MetricWaterDepthUnits.SelectedIndex = 0 Then
            mMetricWaterDepth = UnitsDefinition.Units.Meters
        ElseIf MetricWaterDepthUnits.SelectedIndex = 1 Then
            mMetricWaterDepth = UnitsDefinition.Units.Centimeters
        ElseIf MetricWaterDepthUnits.SelectedIndex = 2 Then
            mMetricWaterDepth = UnitsDefinition.Units.Millimeters
        End If
    End Sub

#End Region

#Region " English "

    Private Sub EnglishRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles English.CheckedChanged
        If Me.English.Checked Then
            EnglishBox.Enabled = True
            MetricBox.Enabled = False
            mMetricOptions = False
            mEnglishOptions = True
        End If
    End Sub

    Private Sub EnglishFlowRateCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EnglishFlowRateUnits.SelectedIndexChanged
        If EnglishFlowRateUnits.SelectedIndex = 0 Then
            mEnglishFlowRate = UnitsDefinition.Units.Cfs
        ElseIf EnglishFlowRateUnits.SelectedIndex = 1 Then
            mEnglishFlowRate = UnitsDefinition.Units.Gpm
        End If
    End Sub

    Private Sub EnglishFieldSlopeCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EnglishFieldSlopeUnits.SelectedIndexChanged
        If EnglishFieldSlopeUnits.SelectedIndex = 0 Then
            mEnglishFieldSlope = UnitsDefinition.Units.FeetPerFoot
        ElseIf EnglishFieldSlopeUnits.SelectedIndex = 1 Then
            mEnglishFieldSlope = UnitsDefinition.Units.FeetPer100Feet
        End If
    End Sub

    Private Sub EnglishFurrowShapeCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EnglishFurrowShapeUnits.SelectedIndexChanged
        If EnglishFurrowShapeUnits.SelectedIndex = 0 Then
            mEnglishFurrowShape = UnitsDefinition.Units.Feet
        ElseIf EnglishFurrowShapeUnits.SelectedIndex = 1 Then
            mEnglishFurrowShape = UnitsDefinition.Units.Inches
        End If
    End Sub

    Private Sub EnglishWaterDepthCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EnglishWaterDepthUnits.SelectedIndexChanged
        If EnglishWaterDepthUnits.SelectedIndex = 0 Then
            mEnglishWaterDepth = UnitsDefinition.Units.Feet
        ElseIf EnglishWaterDepthUnits.SelectedIndex = 1 Then
            mEnglishWaterDepth = UnitsDefinition.Units.Inches
        End If
    End Sub

#End Region

    Private Sub TimeUnitsCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TimeUnits.SelectedIndexChanged
        If TimeUnits.SelectedIndex = 0 Then
            mTimeUnits = UnitsDefinition.Units.Minutes
        ElseIf TimeUnits.SelectedIndex = 1 Then
            mTimeUnits = UnitsDefinition.Units.Hours
        End If
    End Sub

#End Region

#Region " Graph Tab Events "

    Private Sub Color1Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Color1Button.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = Color1
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mColor1 = ColorDialog.Color
            Me.Color1Sample.BackColor = Color1
        End If
    End Sub

    Private Sub Color2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Color2Button.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = Color2
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mColor2 = ColorDialog.Color
            Me.Color2Sample.BackColor = Color2
        End If
    End Sub

    Private Sub Color3Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Color3Button.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = Color3
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mColor3 = ColorDialog.Color
            Me.Color3Sample.BackColor = Color3
        End If
    End Sub

    Private Sub Color4Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Color4Button.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = Color4
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mColor4 = ColorDialog.Color
            Me.Color4Sample.BackColor = Color4
        End If
    End Sub

    Private Sub Color5Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Color5Button.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = Color5
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mColor5 = ColorDialog.Color
            Me.Color5Sample.BackColor = Color5
        End If
    End Sub

    Private Sub Color6Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Color6Button.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = Color6
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mColor6 = ColorDialog.Color
            Me.Color6Sample.BackColor = Color6
        End If
    End Sub

    Private Sub Color7Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Color7Button.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = Color7
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mColor7 = ColorDialog.Color
            Me.Color7Sample.BackColor = Color7
        End If
    End Sub

    Private Sub Color8Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Color8Button.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = Color8
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mColor8 = ColorDialog.Color
            Me.Color8Sample.BackColor = Color8
        End If
    End Sub

    Private Sub Color9Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Color9Button.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = Color9
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mColor9 = ColorDialog.Color
            Me.Color9Sample.BackColor = Color9
        End If
    End Sub

    Private Sub DisplayTitleButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DisplayTitleButton.CheckedChanged
        DisplayTitle = DisplayTitleButton.Checked
    End Sub

    Private Sub DisplaySubtitlesButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DisplaySubtitlesButton.CheckedChanged
        DisplaySubtitles = DisplaySubtitlesButton.Checked
    End Sub

    Private Sub DisplayAxisLabelsButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DisplayAxisLabelsButton.CheckedChanged
        DisplayAxisLabels = DisplayAxisLabelsButton.Checked
    End Sub

    Private Sub InstalledFonts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles InstalledFonts.SelectedIndexChanged
        mSelectedFont = Me.InstalledFonts.SelectedItem
        Try
            Me.FontSample.Font = New Font(mSelectedFont, Me.FontSample.Font.Size)
            Me.FontSample.Text = mDictionary.tSampleText.Translated
        Catch ex As Exception
            Me.InstalledFonts.Items.Remove(mSelectedFont)
            mSelectedFont = Me.Font.FontFamily.Name
            Me.InstalledFonts.SelectedItem = mSelectedFont
        End Try
    End Sub

    Private Sub FontSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FontSize.SelectedIndexChanged
        mFontAdjustment = Me.FontSize.SelectedIndex - 2
    End Sub

#End Region

#Region " Contour Tab Events "

    Private Sub StandardContoursButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles StandardContoursButton.CheckedChanged
        If (StandardContoursButton.Checked = True) Then
            CalculatePrecisionContours = False
        End If
    End Sub

    Private Sub PrecisionContoursButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PrecisionContoursButton.CheckedChanged
        If (PrecisionContoursButton.Checked = True) Then
            CalculatePrecisionContours = True
        End If
    End Sub

    Private Sub DisplayMinorContoursButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DisplayMinorContoursButton.CheckedChanged
        DisplayMinorContours = DisplayMinorContoursButton.Checked
    End Sub

    Private Sub DisplayContourKeyButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DisplayContourKeyButton.CheckedChanged
        DisplayContourKey = DisplayContourKeyButton.Checked
    End Sub

    Private Sub DisplayContourLabelsButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DisplayContourLabelsButton.CheckedChanged
        DisplayContourLabels = DisplayContourLabelsButton.Checked
    End Sub

    Private Sub DisplayContourPointsButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DisplayContourPointsButton.CheckedChanged
        DisplayContourPoints = DisplayContourPointsButton.Checked
    End Sub

    Private Sub ColorScaleButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ColorScaleButton.CheckedChanged
        If (ColorScaleButton.Checked) Then
            Me.FillColors = Globals.FillColors.ColorScale
        End If
    End Sub

    Private Sub GrayScaleButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles GrayScaleButton.CheckedChanged
        If (GrayScaleButton.Checked) Then
            Me.FillColors = Globals.FillColors.GrayScale
        End If
    End Sub

    Private Sub UserDefinedButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles UserDefinedButton.CheckedChanged
        If (UserDefinedButton.Checked) Then
            Me.FillColors = Globals.FillColors.UserDefined
        End If
    End Sub

    Private Sub NoFillButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NoFillButton.CheckedChanged
        If (NoFillButton.Checked) Then
            Me.FillColors = Globals.FillColors.NoFill
        End If
    End Sub

    Private Sub PresetUserToColorScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PresetUserToColorScale.Click

        mFillColor0 = Globals.ColorScaleLevels(0)
        Me.FillUser0010.BackColor = mFillColor0

        mFillColor1 = Globals.ColorScaleLevels(1)
        Me.FillUser1020.BackColor = mFillColor1

        mFillColor2 = Globals.ColorScaleLevels(2)
        Me.FillUser2030.BackColor = mFillColor2

        mFillColor3 = Globals.ColorScaleLevels(3)
        Me.FillUser3040.BackColor = mFillColor3

        mFillColor4 = Globals.ColorScaleLevels(4)
        Me.FillUser4050.BackColor = mFillColor4

        mFillColor5 = Globals.ColorScaleLevels(5)
        Me.FillUser5060.BackColor = mFillColor5

        mFillColor6 = Globals.ColorScaleLevels(6)
        Me.FillUser6070.BackColor = mFillColor6

        mFillColor7 = Globals.ColorScaleLevels(7)
        Me.FillUser7080.BackColor = mFillColor7

        mFillColor8 = Globals.ColorScaleLevels(8)
        Me.FillUser8090.BackColor = mFillColor8

        mFillColor9 = Globals.ColorScaleLevels(9)
        Me.FillUser90up.BackColor = mFillColor9

    End Sub

    Private Sub PresetUserToGrayScale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PresetUserToGrayScale.Click

        mFillColor0 = Globals.GrayScaleLevels(0)
        Me.FillUser0010.BackColor = mFillColor0

        mFillColor1 = Globals.GrayScaleLevels(1)
        Me.FillUser1020.BackColor = mFillColor1

        mFillColor2 = Globals.GrayScaleLevels(2)
        Me.FillUser2030.BackColor = mFillColor2

        mFillColor3 = Globals.GrayScaleLevels(3)
        Me.FillUser3040.BackColor = mFillColor3

        mFillColor4 = Globals.GrayScaleLevels(4)
        Me.FillUser4050.BackColor = mFillColor4

        mFillColor5 = Globals.GrayScaleLevels(5)
        Me.FillUser5060.BackColor = mFillColor5

        mFillColor6 = Globals.GrayScaleLevels(6)
        Me.FillUser6070.BackColor = mFillColor6

        mFillColor7 = Globals.GrayScaleLevels(7)
        Me.FillUser7080.BackColor = mFillColor7

        mFillColor8 = Globals.GrayScaleLevels(8)
        Me.FillUser8090.BackColor = mFillColor8

        mFillColor9 = Globals.GrayScaleLevels(9)
        Me.FillUser90up.BackColor = mFillColor9

    End Sub

    Private Sub FillUser0010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser0010.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor0
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor0 = ColorDialog.Color
            Me.FillUser0010.BackColor = mFillColor0
        End If
    End Sub

    Private Sub FillUser1020_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser1020.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor1
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor1 = ColorDialog.Color
            Me.FillUser1020.BackColor = mFillColor1
        End If
    End Sub

    Private Sub FillUser2030_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser2030.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor2
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor2 = ColorDialog.Color
            Me.FillUser2030.BackColor = mFillColor2
        End If
    End Sub

    Private Sub FillUser3040_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser3040.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor3
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor3 = ColorDialog.Color
            Me.FillUser3040.BackColor = mFillColor3
        End If
    End Sub

    Private Sub FillUser4050_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser4050.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor4
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor4 = ColorDialog.Color
            Me.FillUser4050.BackColor = mFillColor4
        End If
    End Sub

    Private Sub FillUser5060_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser5060.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor5
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor5 = ColorDialog.Color
            Me.FillUser5060.BackColor = mFillColor5
        End If
    End Sub

    Private Sub FillUser6070_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser6070.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor6
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor6 = ColorDialog.Color
            Me.FillUser6070.BackColor = mFillColor6
        End If
    End Sub

    Private Sub FillUser7080_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser7080.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor7
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor7 = ColorDialog.Color
            Me.FillUser7080.BackColor = mFillColor7
        End If
    End Sub

    Private Sub FillUser8090_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser8090.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor8
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor8 = ColorDialog.Color
            Me.FillUser8090.BackColor = mFillColor8
        End If
    End Sub

    Private Sub FillUser90up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FillUser90up.Click
        ' Set the initial color select to the current color
        ColorDialog.Color = mFillColor9
        ' Update the text box color if the user clicks OK 
        If (ColorDialog.ShowDialog() = DialogResult.OK) Then
            mFillColor9 = ColorDialog.Color
            Me.FillUser90up.BackColor = mFillColor9
        End If
    End Sub

#End Region

#Region " Form Events "

    'This sub is called when the form is changed from
    'Show to hide or hide to show
    Private Shadows Sub VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        If Me.Visible = True Then
            FarmName.Text = String.Empty
            FarmOwner.Text = String.Empty
            Evaluator.Text = String.Empty

            ReadFromRegistry()
        End If
    End Sub

    Private Shadows Sub Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        'Cancels closing event
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CancelButton.Click
        Me.Hide()
    End Sub

    Private Sub OkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkayButton.Click
        Dim saveCursor As Cursor = Me.Cursor
        Me.Cursor = Cursors.WaitCursor
        WriteToRegistry()
        'WinSRFR.LoadUserPreferences()
        Me.Cursor = saveCursor
        Me.Hide()
    End Sub

    Private Sub UserPreferences_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
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

#Region " Write To Registry Section "

    ' Call the appropriate functions to write all of the preferences to the registry
    Public Sub WriteToRegistry()

        Try
            ' Get the Current User / Software subkey
            Dim _parentKey As RegistryKey = Registry.CurrentUser
            Dim _subKey As RegistryKey = _parentKey.OpenSubKey("Software", True)

            If Not (_subKey Is Nothing) Then

                ' Open the Company / Product keys
                _subKey = _subKey.CreateSubKey(Application.CompanyName)
                If Not (_subKey Is Nothing) Then
                    _subKey = _subKey.CreateSubKey(Application.ProductName)
                    If Not (_subKey Is Nothing) Then

                        ' Write the User Preferences to the registry
                        WriteApplicationToRegistry(_subKey)
                        WriteStartupToRegistry(_subKey)
                        WriteFilesToRegistry(_subKey)
                        WriteViewToRegistry(_subKey)
                        WriteDialogToRegistry(_subKey)
                        WriteUnitsToRegistry(_subKey)
                        WriteGraphToRegistry(_subKey)
                        WriteContourToRegistry(_subKey)

                    End If
                End If
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.ToString)
        End Try

    End Sub

    ' This sub writes the Application properties to the registry
    Private Sub WriteApplicationToRegistry(ByRef _parentKey As RegistryKey)

        On Error GoTo ErrorHandler

        ' Write the Application properties to the Registry
        mApplicationVersion = Application.ProductVersion
        _parentKey.SetValue("Version", mApplicationVersion)

        Exit Sub

ErrorHandler:
        ' Check to see if it is a null reference error
        ' If so ignore it and goto the next item
        ' Error message number 5 is null reference
        If Not (Err.Number = 5) Then
            Debug.Assert(False, Err.Description)
        End If
        Resume Next

    End Sub

    ' This sub writes the Startup tab preferences to the registry
    Private Sub WriteStartupToRegistry(ByRef _parentKey As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get the Startup subkey
        Dim _subKey As RegistryKey = _parentKey.CreateSubKey("Startup")

        ' Write the Startup preferences to the Registry
        Dim _integer As Integer

        mFarmName = FarmName.Text
        _subKey.SetValue("DefaultFarmName", mFarmName)

        mFarmOwner = FarmOwner.Text
        _subKey.SetValue("DefaultFarmOwner", mFarmOwner)

        mEvaluator = Evaluator.Text
        _subKey.SetValue("DefaultEvaluator", mEvaluator)

        _integer = CInt(OpenPreviousFile)
        _subKey.SetValue("OpenPreviousFile", _integer)

        Exit Sub

ErrorHandler:
        ' Check to see if it is a null reference error
        ' If so ignore it and goto the next item
        ' Error message number 5 is null reference
        If Not (Err.Number = 5) Then
            Debug.Assert(False, Err.Description)
        End If
        Resume Next

    End Sub

    ' This sub writes the Files tab preferences to the registry
    Private Sub WriteFilesToRegistry(ByRef _parentKey As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get the Files subkey
        Dim _subKey As RegistryKey = _parentKey.CreateSubKey("Files")

        ' Write the Files preferences to the Registry
        mLogFolder = LogFolder.Text
        _subKey.SetValue("DefaultLogFolder", mLogFolder)

        mDataFolder = DataFolder.Text
        _subKey.SetValue("DefaultDataFolder", mDataFolder)

        Exit Sub

ErrorHandler:
        ' Check to see if it is a null reference error
        ' If so ignore it and goto the next item
        ' Error message number 5 is null reference
        If Not (Err.Number = 5) Then
            Debug.Assert(False, Err.Description)
        End If
        Resume Next

    End Sub

    ' This sub writes the view tab preferences to the registry
    Private Sub WriteViewToRegistry(ByRef _parentKey As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get the View subkey
        Dim _subKey As RegistryKey = _parentKey.CreateSubKey("View")

        ' Write the View preferences to the Registry
        Dim _integer As Integer

        _integer = ResultsView
        _subKey.SetValue("ResultsView", _integer)

        _integer = CInt(ShowSimulationAnimation)
        _subKey.SetValue("ShowSimulationAnimation", _integer)

        Exit Sub

ErrorHandler:
        ' Check to see if it is a null reference error
        ' If so ignore it and goto the next item
        ' Error message number 5 is null reference
        If Not (Err.Number = 5) Then
            Debug.Assert(False, Err.Description)
        End If
        Resume Next

    End Sub

    ' This sub writes the dialog tab preferences to the registry
    Private Sub WriteDialogToRegistry(ByRef _parentKey As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get the Dialog subkey
        Dim _subKey As RegistryKey = _parentKey.CreateSubKey("Dialog")

        ' Write the Dialog preferences to the Registry
        Dim _integer As Integer

        _integer = mDefaultValueResponse
        _subKey.SetValue("DefaultValueResponse", _integer)

        Exit Sub

ErrorHandler:
        ' Check to see if it is a null reference error
        ' If so ignore it and goto the next item
        ' Error message number 5 is null reference
        If Not (Err.Number = 5) Then
            Debug.Assert(False, Err.Description)
        End If
        Resume Next

    End Sub

    ' This sub writes the units tab preferences to the registry
    Private Sub WriteUnitsToRegistry(ByRef _parentKey As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get the Units subkey
        Dim _subKey As RegistryKey = _parentKey.CreateSubKey("Units")

        ' Write the Units preferences to the Registry
        Dim _integer As Integer

        _integer = CInt(mMetricOptions)
        _subKey.SetValue("MetricOptions", _integer)

        _integer = CInt(mEnglishOptions)
        _subKey.SetValue("EnglishOptions", _integer)

        _integer = mMetricFlowRate
        _subKey.SetValue("MetricFlowRate", _integer)

        _integer = mEnglishFlowRate
        _subKey.SetValue("EnglishFlowRate", _integer)

        _integer = mMetricFieldSlope
        _subKey.SetValue("MetricFieldSlope", _integer)

        _integer = mEnglishFieldSlope
        _subKey.SetValue("EnglishFieldSlope", _integer)

        _integer = mMetricFurrowShape
        _subKey.SetValue("MetricFurrowShape", _integer)

        _integer = mEnglishFurrowShape
        _subKey.SetValue("EnglishFurrowShape", _integer)

        _integer = mMetricWaterDepth
        _subKey.SetValue("MetricWaterDepth", _integer)

        _integer = mEnglishWaterDepth
        _subKey.SetValue("EnglishWaterDepth", _integer)

        _integer = mTimeUnits
        _subKey.SetValue("TimeUnits", _integer)

        Exit Sub

ErrorHandler:
        ' Check to see if it is a null reference error
        ' If so ignore it and goto the next item
        ' Error message number 5 is null reference
        If Not (Err.Number = 5) Then
            Debug.Assert(False, Err.Description)
        End If
        Resume Next

    End Sub

    ' This sub writes the graph tab preferences to the registry
    Private Sub WriteGraphToRegistry(ByRef _parentKey As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get the Graph subkey
        Dim _subKey As RegistryKey = _parentKey.CreateSubKey("Graph")

        ' Write the Graph preferences to the Registry
        Dim _integer As Integer

        _integer = CInt(DisplayTitle)
        _subKey.SetValue("DisplayTitle", _integer)

        _integer = CInt(DisplaySubtitles)
        _subKey.SetValue("DisplaySubtitles", _integer)

        _integer = CInt(DisplayAxisLabels)
        _subKey.SetValue("DisplayAxisLabels", _integer)

        mSelectedFont = Me.InstalledFonts.SelectedItem
        _subKey.SetValue("SelectedFont", mSelectedFont)

        mFontAdjustment = Me.FontSize.SelectedIndex - 2
        _subKey.SetValue("FontAdjustment", mFontAdjustment)

        ' Get the Color subkey
        _subKey = _parentKey.CreateSubKey("Color")

        _subKey.SetValue("Color0", mColor0.ToArgb)
        _subKey.SetValue("Color1", mColor1.ToArgb)
        _subKey.SetValue("Color2", mColor2.ToArgb)
        _subKey.SetValue("Color3", mColor3.ToArgb)
        _subKey.SetValue("Color4", mColor4.ToArgb)
        _subKey.SetValue("Color5", mColor5.ToArgb)
        _subKey.SetValue("Color6", mColor6.ToArgb)
        _subKey.SetValue("Color7", mColor7.ToArgb)
        _subKey.SetValue("Color8", mColor8.ToArgb)
        _subKey.SetValue("Color9", mColor9.ToArgb)

        Exit Sub

ErrorHandler:
        ' Check to see if it is a null reference error
        ' If so ignore it and goto the next item
        ' Error message number 5 is null reference
        If Not (Err.Number = 5) Then
            Debug.Assert(False, Err.Description)
        End If
        Resume Next

    End Sub

    ' This sub writes the contour tab preferences to the registry
    Private Sub WriteContourToRegistry(ByRef _parentKey As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get the Contour subkey
        Dim _subKey As RegistryKey = _parentKey.CreateSubKey("Contour")

        ' Write the Contour preferences to the Registry
        Dim _integer As Integer

        _integer = FillColors
        _subKey.SetValue("FillColors", _integer)

        _integer = CInt(CalculatePrecisionContours)
        _subKey.SetValue("CalculatePrecisionContours", _integer)

        _integer = CInt(DisplayMinorContours)
        _subKey.SetValue("DisplayMinorContours", _integer)

        _integer = CInt(DisplayContourKey)
        _subKey.SetValue("DisplayContourKey", _integer)

        _integer = CInt(DisplayContourLabels)
        _subKey.SetValue("DisplayContourLabels", _integer)

        _integer = CInt(DisplayContourPoints)
        _subKey.SetValue("DisplayContourPoints", _integer)

        ' Get the Color subkey
        _subKey = _parentKey.CreateSubKey("Color")

        _subKey.SetValue("FillColor0", mFillColor0.ToArgb)
        _subKey.SetValue("FillColor1", mFillColor1.ToArgb)
        _subKey.SetValue("FillColor2", mFillColor2.ToArgb)
        _subKey.SetValue("FillColor3", mFillColor3.ToArgb)
        _subKey.SetValue("FillColor4", mFillColor4.ToArgb)
        _subKey.SetValue("FillColor5", mFillColor5.ToArgb)
        _subKey.SetValue("FillColor6", mFillColor6.ToArgb)
        _subKey.SetValue("FillColor7", mFillColor7.ToArgb)
        _subKey.SetValue("FillColor8", mFillColor8.ToArgb)
        _subKey.SetValue("FillColor9", mFillColor9.ToArgb)

        Exit Sub

ErrorHandler:
        ' Check to see if it is a null reference error
        ' If so ignore it and goto the next item
        ' Error message number 5 is null reference
        If Not (Err.Number = 5) Then
            Debug.Assert(False, Err.Description)
        End If
        Resume Next

    End Sub

#End Region

#Region " Read From Registry Section "

    'This function calls all the appropriate functions to read all of
    'The preferences from the registry
    Private Sub ReadFromRegistry()

        Try
            ' Open the Current User / Software keys
            Dim _parentKey As RegistryKey = Registry.CurrentUser
            Dim _subKey As RegistryKey = _parentKey.OpenSubKey("Software", True)

            If Not (_subKey Is Nothing) Then

                ' Open the Company / Product keys
                _subKey = _subKey.CreateSubKey(Application.CompanyName)
                If Not (_subKey Is Nothing) Then
                    _subKey = _subKey.CreateSubKey(Application.ProductName)
                    If Not (_subKey Is Nothing) Then

                        ' Read the User Preferences from the Registry
                        ReadApplicationFromRegistry(_subKey)
                        ReadStartupFromRegistry(_subKey)
                        ReadFilesFromRegistry(_subKey)
                        ReadViewFromRegistry(_subKey)
                        ReadDialogFromRegistry(_subKey)
                        ReadUnitsFromRegistry(_subKey)
                        ReadGraphFromRegistry(_subKey)
                        ReadContourFromRegistry(_subKey)

                    End If
                End If
            End If

        Catch ex As Exception
            Debug.Assert(False, ex.ToString)
        End Try

    End Sub

    ' This sub reads the Application properties from the registry
    Private Sub ReadApplicationFromRegistry(ByRef _parent As RegistryKey)

        On Error GoTo ErrorHandler

        ' Read Application Version
        mApplicationVersion = CStr(_parent.GetValue("Version", String.Empty))

        ' Read Project Nomenclature selections
        Dim _nomen As ProjectNomenclatures = CType(_parent.GetValue(sProjectNomenclature, DefaultProjectNomenclature), ProjectNomenclatures)
        If ((ProjectNomenclatures.LowLimit < _nomen) And (_nomen < ProjectNomenclatures.HighLimit)) Then
            mProjectNomenclature = _nomen
        End If

        Select Case (mProjectNomenclature)
            Case Globals.ProjectNomenclatures.FarmField
                ProjectBox.Text = mDictionary.tDefaultFarmNameOwner.Translated
                ProjectNameLabel.Text = mDictionary.tFarmName.Translated
                ProjectOwnerLabel.Text = mDictionary.tFarmOwner.Translated
            Case Globals.ProjectNomenclatures.ProjectCase
                ProjectBox.Text = mDictionary.tDefaultProjectNameOwner.Translated
                ProjectNameLabel.Text = mDictionary.tProjectName.Translated
                ProjectOwnerLabel.Text = mDictionary.tProjectOwner.Translated
        End Select

        Exit Sub
ErrorHandler:
        Debug.Assert(False, Err.Description)
        Resume Next
    End Sub

    ' This sub reads the Startup preferences from the registry
    Private Sub ReadStartupFromRegistry(ByRef _parent As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get Startup key
        Dim _subKey As RegistryKey = _parent.CreateSubKey("Startup")

        If Not (_subKey Is Nothing) Then

            mFarmName = CStr(_subKey.GetValue("DefaultFarmName", String.Empty))
            mFarmOwner = CStr(_subKey.GetValue("DefaultFarmOwner", String.Empty))
            mEvaluator = CStr(_subKey.GetValue("DefaultEvaluator", String.Empty))

            FarmName.Text = mFarmName
            FarmOwner.Text = mFarmOwner
            Evaluator.Text = mEvaluator

            OpenPreviousFile = CBool(_subKey.GetValue("OpenPreviousFile", DefaultOpenPreviousFile))

        End If

        Exit Sub
ErrorHandler:
        Debug.Assert(False, Err.Description)
        Resume Next
    End Sub

    ' This sub reads the Files preferences from the registry
    Private Sub ReadFilesFromRegistry(ByRef _parent As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get Files key
        Dim _subKey As RegistryKey = _parent.CreateSubKey("Files")

        If Not (_subKey Is Nothing) Then

            ' Log Folder
            If (mApplicationVersion = Application.ProductVersion) Then
                ' Registry has been updated by this version
                mLogFolder = CStr(_subKey.GetValue("DefaultLogFolder", String.Empty))
                If (mLogFolder = String.Empty) Then
                    ResetLogFolder()
                End If
            Else
                ' Registry has NOT been udpated by this version
                ResetLogFolder()
            End If

            LogFolder.Text = mLogFolder

            ' Data Folder
            If (mApplicationVersion = Application.ProductVersion) Then
                ' Registry has been updated by this version
                mDataFolder = CStr(_subKey.GetValue("DefaultDataFolder", String.Empty))
                If (mDataFolder = String.Empty) Then
                    ResetDataFolder()
                End If
            Else
                ' Registry has NOT been udpated by this version
                ResetDataFolder()
            End If

            DataFolder.Text = mDataFolder

        End If

        Exit Sub
ErrorHandler:
        Debug.Assert(False, Err.Description)
        Resume Next
    End Sub

    ' This sub reads the View preferences from the registry
    Private Sub ReadViewFromRegistry(ByRef _parent As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get View key
        Dim _subKey As RegistryKey = _parent.CreateSubKey("View")

        If Not (_subKey Is Nothing) Then

            Dim _resultsView As ResultsViews = CType(_subKey.GetValue("ResultsView", DefaultResultsView), ResultsViews)
            If ((ResultsViews.LowLimit < _resultsView) And (_resultsView < ResultsViews.HighLimit)) Then
                ResultsView = _resultsView
            End If

            ShowSimulationAnimation = CBool(_subKey.GetValue("ShowSimulationAnimation", DefaultShowSimulationAnimation))

        End If

        Exit Sub
ErrorHandler:
        Debug.Assert(False, Err.Description)
        Resume Next
    End Sub

    ' This sub reads the Dialog preferences from the registry
    Private Sub ReadDialogFromRegistry(ByRef _parent As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get Dialog key
        Dim _subKey As RegistryKey = _parent.CreateSubKey("Dialog")

        If Not (_subKey Is Nothing) Then

            Dim _response As DefaultValueResponses = CType(_subKey.GetValue("DefaultValueResponse", DefaultValueResponse), DefaultValueResponses)
            If ((DefaultValueResponses.LowLimit < _response) And (_response < DefaultValueResponses.HighLimit)) Then
                mDefaultValueResponse = _response
                Select Case (mDefaultValueResponse)
                    Case Globals.DefaultValueResponses.UnconditionallyAccept
                        UnconditionallyAccept.Checked = True
                    Case Globals.DefaultValueResponses.RequireConfirmation
                        RequireConfirmation.Checked = True
                End Select
            End If

        End If

        Exit Sub
ErrorHandler:
        Debug.Assert(False, Err.Description)
        Resume Next
    End Sub

    ' This sub reads the Units preferences from the registry
    Private Sub ReadUnitsFromRegistry(ByRef _parent As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get Units key
        Dim _subKey As RegistryKey = _parent.CreateSubKey("Units")

        If Not (_subKey Is Nothing) Then

            mMetricOptions = CBool(_subKey.GetValue("MetricOptions", True))
            Metric.Checked = mMetricOptions

            mEnglishOptions = CBool(_subKey.GetValue("EnglishOptions", False))
            English.Checked = mEnglishOptions

            Dim _units As Units = CType(_subKey.GetValue("MetricFlowRate", Units.Lps), Units)
            If ((Units.FlowRateMetricLow <= _units) And (_units <= Units.FlowRateMetricHigh)) Then
                mMetricFlowRate = _units
                MetricFlowRateUnits.SelectedIndex = mMetricFlowRate - Units.FlowRateMetricLow
            End If

            _units = CType(_subKey.GetValue("EnglishFlowRate", Units.Gpm), Units)
            If ((Units.FlowRateEnglishLow <= _units) And (_units <= Units.FlowRateEnglishHigh)) Then
                mEnglishFlowRate = _units
                EnglishFlowRateUnits.SelectedIndex = mEnglishFlowRate - Units.FlowRateEnglishLow
            End If

            _units = CType(_subKey.GetValue("MetricFieldSlope", Units.MetersPerMeter), Units)
            If ((Units.SlopeMetricLow <= _units) And (_units <= Units.SlopeMetricHigh)) Then
                mMetricFieldSlope = _units
                MetricFieldSlopeUnits.SelectedIndex = mMetricFieldSlope - Units.SlopeMetricLow
            End If

            _units = CType(_subKey.GetValue("EnglishFieldSlope", Units.FeetPerFoot), Units)
            If ((Units.SlopeEnglishLow <= _units) And (_units <= Units.SlopeEnglishHigh)) Then
                mEnglishFieldSlope = _units
                EnglishFieldSlopeUnits.SelectedIndex = mEnglishFieldSlope - Units.SlopeEnglishLow
            End If

            _units = CType(_subKey.GetValue("MetricFurrowShape", Units.Millimeters), Units)
            Select Case (_units)
                Case Units.Meters
                    mMetricFurrowShape = _units
                    MetricFurrowShapeUnits.SelectedIndex = 0
                Case Units.Centimeters
                    mMetricFurrowShape = _units
                    MetricFurrowShapeUnits.SelectedIndex = 1
                Case Units.Millimeters
                    mMetricFurrowShape = _units
                    MetricFurrowShapeUnits.SelectedIndex = 2
            End Select

            _units = CType(_subKey.GetValue("EnglishFurrowShape", Units.Inches), Units)
            Select Case (_units)
                Case Units.Feet
                    mEnglishFurrowShape = _units
                    EnglishFurrowShapeUnits.SelectedIndex = 0
                Case Units.Inches
                    mEnglishFurrowShape = _units
                    EnglishFurrowShapeUnits.SelectedIndex = 1
            End Select

            _units = CType(_subKey.GetValue("MetricWaterDepth", Units.Millimeters), Units)
            Select Case (_units)
                Case Units.Meters
                    mMetricWaterDepth = _units
                    MetricWaterDepthUnits.SelectedIndex = 0
                Case Units.Centimeters
                    mMetricWaterDepth = _units
                    MetricWaterDepthUnits.SelectedIndex = 1
                Case Units.Millimeters
                    mMetricWaterDepth = _units
                    MetricWaterDepthUnits.SelectedIndex = 2
            End Select

            _units = CType(_subKey.GetValue("EnglishWaterDepth", Units.Inches), Units)
            Select Case (_units)
                Case Units.Feet
                    mEnglishWaterDepth = _units
                    EnglishWaterDepthUnits.SelectedIndex = 0
                Case Units.Inches
                    mEnglishWaterDepth = _units
                    EnglishWaterDepthUnits.SelectedIndex = 1
            End Select

            _units = CType(_subKey.GetValue("TimeUnits", Units.Hours), Units)
            If ((Units.SystemTimeLow <= _units) And (_units <= Units.SystemTimeHigh)) Then
                mTimeUnits = _units
                TimeUnits.SelectedIndex = mTimeUnits - Units.SystemTimeLow
            End If

        End If

        Exit Sub
ErrorHandler:
        Debug.Assert(False, Err.Description)
        Resume Next

    End Sub

    ' This sub reads the Graph preferences from the registry
    Private Sub ReadGraphFromRegistry(ByRef _parent As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get Graph key
        Dim _subKey As RegistryKey = _parent.CreateSubKey("Graph")

        If Not (_subKey Is Nothing) Then

            DisplayTitle = CBool(_subKey.GetValue("DisplayTitle", DefaultDisplayTitle))
            DisplaySubtitles = CBool(_subKey.GetValue("DisplaySubtitles", DefaultDisplaySubtitles))
            DisplayAxisLabels = CBool(_subKey.GetValue("DisplayAxisLabels", DefaultDisplayAxisLabels))

            mSelectedFont = CStr(_subKey.GetValue("SelectedFont", Me.Font.FontFamily.Name))
            Me.InstalledFonts.SelectedItem = mSelectedFont
            Me.FontSample.Font = New Font(mSelectedFont, Me.FontSample.Font.Size)

            mFontAdjustment = CInt(_subKey.GetValue("FontAdjustment", 0))
            mFontAdjustment = Math.Max(mFontAdjustment, -2)
            mFontAdjustment = Math.Min(mFontAdjustment, +2)
            Me.FontSize.SelectedIndex = mFontAdjustment + 2

        End If

        ' Get Color key
        _subKey = _parent.CreateSubKey("Color")

        If Not (_subKey Is Nothing) Then

            Dim _argb As Integer

            _argb = CInt(_subKey.GetValue("Color0", mColor0.ToArgb))
            mColor0 = Color.FromArgb(_argb)

            _argb = CInt(_subKey.GetValue("Color1", mColor1.ToArgb))
            mColor0 = Color.FromArgb(_argb)
            Color1Sample.BackColor = mColor1

            _argb = CInt(_subKey.GetValue("Color2", mColor2.ToArgb))
            mColor2 = Color.FromArgb(_argb)
            Color2Sample.BackColor = mColor2

            _argb = CInt(_subKey.GetValue("Color3", mColor3.ToArgb))
            mColor3 = Color.FromArgb(_argb)
            Color3Sample.BackColor = mColor3

            _argb = CInt(_subKey.GetValue("Color4", mColor4.ToArgb))
            mColor4 = Color.FromArgb(_argb)
            Color4Sample.BackColor = mColor4

            _argb = CInt(_subKey.GetValue("Color5", mColor5.ToArgb))
            mColor5 = Color.FromArgb(_argb)
            Color5Sample.BackColor = mColor5

            _argb = CInt(_subKey.GetValue("Color6", mColor6.ToArgb))
            mColor6 = Color.FromArgb(_argb)
            Color6Sample.BackColor = mColor6

            _argb = CInt(_subKey.GetValue("Color7", mColor7.ToArgb))
            mColor7 = Color.FromArgb(_argb)
            Color7Sample.BackColor = mColor7

            _argb = CInt(_subKey.GetValue("Color8", mColor8.ToArgb))
            mColor8 = Color.FromArgb(_argb)
            Color8Sample.BackColor = mColor8

            _argb = CInt(_subKey.GetValue("Color9", mColor9.ToArgb))
            mColor9 = Color.FromArgb(_argb)
            Color9Sample.BackColor = mColor9

        End If

        Exit Sub
ErrorHandler:
        Debug.Assert(False, Err.Description)
        Resume Next

    End Sub

    ' This sub reads the Contour preferences from the registry
    Private Sub ReadContourFromRegistry(ByRef _parent As RegistryKey)

        On Error GoTo ErrorHandler

        ' Get Contour key
        Dim _subKey As RegistryKey = _parent.CreateSubKey("Contour")

        If Not (_subKey Is Nothing) Then

            Dim _fillColors As FillColors = CType(_subKey.GetValue("FillColors", DefaultFillColors), FillColors)
            If ((FillColors.LowLimit < _fillColors) And (_fillColors < FillColors.HighLimit)) Then
                FillColors = _fillColors
            End If

            CalculatePrecisionContours = CBool(_subKey.GetValue("CalculatePrecisionContours", DefaultCalculatePrecisionContours))

            DisplayMinorContours = CBool(_subKey.GetValue("DisplayMinorContours", DefaultDisplayMinorContours))
            DisplayContourKey = CBool(_subKey.GetValue("DisplayContourKey", DefaultDisplayContourKey))
            DisplayContourLabels = CBool(_subKey.GetValue("DisplayContourLabels", DefaultDisplayContourLabels))
            DisplayContourPoints = CBool(_subKey.GetValue("DisplayContourPoints", DefaultDisplayContourPoints))

        End If

        ' Get Color key
        _subKey = _parent.CreateSubKey("Color")

        If Not (_subKey Is Nothing) Then

            Dim _argb As Integer

            _argb = CInt(_subKey.GetValue("FillColor0", mFillColor0.ToArgb))
            mFillColor0 = Color.FromArgb(_argb)
            Me.FillUser0010.BackColor = mFillColor0

            _argb = CInt(_subKey.GetValue("FillColor1", mFillColor1.ToArgb))
            mFillColor1 = Color.FromArgb(_argb)
            Me.FillUser1020.BackColor = mFillColor1

            _argb = CInt(_subKey.GetValue("FillColor2", mFillColor2.ToArgb))
            mFillColor2 = Color.FromArgb(_argb)
            Me.FillUser2030.BackColor = mFillColor2

            _argb = CInt(_subKey.GetValue("FillColor3", mFillColor3.ToArgb))
            mFillColor3 = Color.FromArgb(_argb)
            Me.FillUser3040.BackColor = mFillColor3

            _argb = CInt(_subKey.GetValue("FillColor4", mFillColor4.ToArgb))
            mFillColor4 = Color.FromArgb(_argb)
            Me.FillUser4050.BackColor = mFillColor4

            _argb = CInt(_subKey.GetValue("FillColor5", mFillColor5.ToArgb))
            mFillColor5 = Color.FromArgb(_argb)
            Me.FillUser5060.BackColor = mFillColor5

            _argb = CInt(_subKey.GetValue("FillColor6", mFillColor6.ToArgb))
            mFillColor6 = Color.FromArgb(_argb)
            Me.FillUser6070.BackColor = mFillColor6

            _argb = CInt(_subKey.GetValue("FillColor7", mFillColor7.ToArgb))
            mFillColor7 = Color.FromArgb(_argb)
            Me.FillUser7080.BackColor = mFillColor7

            _argb = CInt(_subKey.GetValue("FillColor8", mFillColor8.ToArgb))
            mFillColor8 = Color.FromArgb(_argb)
            Me.FillUser8090.BackColor = mFillColor8

            _argb = CInt(_subKey.GetValue("FillColor9", mFillColor9.ToArgb))
            mFillColor9 = Color.FromArgb(_argb)
            Me.FillUser90up.BackColor = mFillColor9

        End If

        Exit Sub
ErrorHandler:
        Debug.Assert(False, Err.Description)
        Resume Next

    End Sub

#End Region

End Class
