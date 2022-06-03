<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctl_SensitivityAnalysisStructured
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
        Me.InputFileBox = New DataStore.ctl_GroupBox()
        Me.InputInstructions = New DataStore.ctl_Label()
        Me.BrowseInputFileButton = New DataStore.ctl_Button()
        Me.InputFilename = New System.Windows.Forms.TextBox()
        Me.DependentVariablesGroup = New DataStore.ctl_GroupBox()
        Me.ZeroDepVarRadioButton = New DataStore.ctl_RadioButton()
        Me.Dependent4GroupBox = New DataStore.ctl_GroupBox()
        Me.Dep4SelParamLabel = New DataStore.ctl_Label()
        Me.Dep4SelParamValue = New DataStore.ctl_SelectParameter()
        Me.Dep4ParamGroupLabel = New DataStore.ctl_Label()
        Me.Dep4ParamGroupValue = New DataStore.ctl_SelectParameter()
        Me.Dependent3GroupBox = New DataStore.ctl_GroupBox()
        Me.Dep3SelParamLabel = New DataStore.ctl_Label()
        Me.Dep3SelParamValue = New DataStore.ctl_SelectParameter()
        Me.Dep3ParamGroupLabel = New DataStore.ctl_Label()
        Me.Dep3ParamGroupValue = New DataStore.ctl_SelectParameter()
        Me.Dependent2GroupBox = New DataStore.ctl_GroupBox()
        Me.Dep2SelParamLabel = New DataStore.ctl_Label()
        Me.Dep2SelParamValue = New DataStore.ctl_SelectParameter()
        Me.Dep2ParamGroupLabel = New DataStore.ctl_Label()
        Me.Dep2ParamGroupValue = New DataStore.ctl_SelectParameter()
        Me.FourDepVarRadioButton = New DataStore.ctl_RadioButton()
        Me.ThreeDepVarRadioButton = New DataStore.ctl_RadioButton()
        Me.TwoDepVarRadioButton = New DataStore.ctl_RadioButton()
        Me.OneDepVarRadioButton = New DataStore.ctl_RadioButton()
        Me.NumDepVarsLabel = New DataStore.ctl_Label()
        Me.Dependent1GroupBox = New DataStore.ctl_GroupBox()
        Me.Dep1SelParamLabel = New DataStore.ctl_Label()
        Me.Dep1SelParamValue = New DataStore.ctl_SelectParameter()
        Me.Dep1ParamGroupLabel = New DataStore.ctl_Label()
        Me.Dep1ParamGroupValue = New DataStore.ctl_SelectParameter()
        Me.IndependentVariablesGroup = New DataStore.ctl_GroupBox()
        Me.Independent2GroupBox = New DataStore.ctl_GroupBox()
        Me.NumInd2Increments = New DataStore.ctl_IntegerParameter()
        Me.Ind2UnitsText = New System.Windows.Forms.Label()
        Me.MaxInd2Value = New System.Windows.Forms.TextBox()
        Me.MinInd2Value = New System.Windows.Forms.TextBox()
        Me.TcoToLabel = New System.Windows.Forms.Label()
        Me.TcoNumIncsLabal = New System.Windows.Forms.Label()
        Me.Indep2SelParamLabel = New DataStore.ctl_Label()
        Me.Indep2ParamValue = New DataStore.ctl_SelectParameter()
        Me.Indep2ParamGroupLabel = New DataStore.ctl_Label()
        Me.Indep2GroupValue = New DataStore.ctl_SelectParameter()
        Me.CutoffTimeRange = New DataStore.ctl_Label()
        Me.TwoIndVarRadioButton = New DataStore.ctl_RadioButton()
        Me.OneIndVarRadioButton = New DataStore.ctl_RadioButton()
        Me.NoIndVarsLabel = New DataStore.ctl_Label()
        Me.Independent1GroupBox = New DataStore.ctl_GroupBox()
        Me.NumInd1Increments = New DataStore.ctl_IntegerParameter()
        Me.Ind1UnitsText = New System.Windows.Forms.Label()
        Me.MaxInd1Value = New System.Windows.Forms.TextBox()
        Me.MinInd1Value = New System.Windows.Forms.TextBox()
        Me.QinNumIncsLabel = New System.Windows.Forms.Label()
        Me.Indep1SelParamLabel = New DataStore.ctl_Label()
        Me.Indep1ParamValue = New DataStore.ctl_SelectParameter()
        Me.Indep1ParamGroupLabel = New DataStore.ctl_Label()
        Me.Indep1GroupValue = New DataStore.ctl_SelectParameter()
        Me.QinToLabel = New System.Windows.Forms.Label()
        Me.QinRangeLabel = New DataStore.ctl_Label()
        Me.OutputFileBox = New DataStore.ctl_GroupBox()
        Me.SaveButton = New DataStore.ctl_Button()
        Me.OutputInstructions = New DataStore.ctl_Label()
        Me.BrowseOutputFileName = New DataStore.ctl_Button()
        Me.OutputFileName = New System.Windows.Forms.TextBox()
        Me.InputFileBox.SuspendLayout()
        Me.DependentVariablesGroup.SuspendLayout()
        Me.Dependent4GroupBox.SuspendLayout()
        Me.Dependent3GroupBox.SuspendLayout()
        Me.Dependent2GroupBox.SuspendLayout()
        Me.Dependent1GroupBox.SuspendLayout()
        Me.IndependentVariablesGroup.SuspendLayout()
        Me.Independent2GroupBox.SuspendLayout()
        Me.Independent1GroupBox.SuspendLayout()
        Me.OutputFileBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'InputFileBox
        '
        Me.InputFileBox.AccessibleDescription = "Specifies the default directory for WinSRFR log & diagnostic files."
        Me.InputFileBox.AccessibleName = "Default Log Folder"
        Me.InputFileBox.Controls.Add(Me.InputInstructions)
        Me.InputFileBox.Controls.Add(Me.BrowseInputFileButton)
        Me.InputFileBox.Controls.Add(Me.InputFilename)
        Me.InputFileBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputFileBox.Location = New System.Drawing.Point(15, 500)
        Me.InputFileBox.Name = "InputFileBox"
        Me.InputFileBox.Size = New System.Drawing.Size(745, 90)
        Me.InputFileBox.TabIndex = 3
        Me.InputFileBox.TabStop = False
        Me.InputFileBox.Text = "&Input File (Created by WinSRFR for Sensitivity Analysis)"
        '
        'InputInstructions
        '
        Me.InputInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputInstructions.Location = New System.Drawing.Point(16, 25)
        Me.InputInstructions.Name = "InputInstructions"
        Me.InputInstructions.Size = New System.Drawing.Size(677, 21)
        Me.InputInstructions.TabIndex = 0
        Me.InputInstructions.Text = "Enter the name of the .txt or .csv Tabulated Script input file to save"
        '
        'BrowseInputFileButton
        '
        Me.BrowseInputFileButton.AccessibleDescription = "Browses for location to save script input file"
        Me.BrowseInputFileButton.AccessibleName = "Browse Input File Folder"
        Me.BrowseInputFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseInputFileButton.Location = New System.Drawing.Point(656, 51)
        Me.BrowseInputFileButton.Name = "BrowseInputFileButton"
        Me.BrowseInputFileButton.Size = New System.Drawing.Size(90, 30)
        Me.BrowseInputFileButton.TabIndex = 2
        Me.BrowseInputFileButton.Text = "&Browse"
        '
        'InputFilename
        '
        Me.InputFilename.AccessibleDescription = "WinSRFR's log & diagnostic folder."
        Me.InputFilename.AccessibleName = "Log Folder"
        Me.InputFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputFilename.Location = New System.Drawing.Point(16, 50)
        Me.InputFilename.Name = "InputFilename"
        Me.InputFilename.Size = New System.Drawing.Size(634, 26)
        Me.InputFilename.TabIndex = 1
        '
        'DependentVariablesGroup
        '
        Me.DependentVariablesGroup.Controls.Add(Me.ZeroDepVarRadioButton)
        Me.DependentVariablesGroup.Controls.Add(Me.Dependent4GroupBox)
        Me.DependentVariablesGroup.Controls.Add(Me.Dependent3GroupBox)
        Me.DependentVariablesGroup.Controls.Add(Me.Dependent2GroupBox)
        Me.DependentVariablesGroup.Controls.Add(Me.FourDepVarRadioButton)
        Me.DependentVariablesGroup.Controls.Add(Me.ThreeDepVarRadioButton)
        Me.DependentVariablesGroup.Controls.Add(Me.TwoDepVarRadioButton)
        Me.DependentVariablesGroup.Controls.Add(Me.OneDepVarRadioButton)
        Me.DependentVariablesGroup.Controls.Add(Me.NumDepVarsLabel)
        Me.DependentVariablesGroup.Controls.Add(Me.Dependent1GroupBox)
        Me.DependentVariablesGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DependentVariablesGroup.Location = New System.Drawing.Point(395, 9)
        Me.DependentVariablesGroup.Name = "DependentVariablesGroup"
        Me.DependentVariablesGroup.Size = New System.Drawing.Size(364, 483)
        Me.DependentVariablesGroup.TabIndex = 2
        Me.DependentVariablesGroup.TabStop = False
        Me.DependentVariablesGroup.Text = "&Dependent Variables"
        '
        'ZeroDepVarRadioButton
        '
        Me.ZeroDepVarRadioButton.AutoSize = True
        Me.ZeroDepVarRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZeroDepVarRadioButton.Location = New System.Drawing.Point(120, 25)
        Me.ZeroDepVarRadioButton.Name = "ZeroDepVarRadioButton"
        Me.ZeroDepVarRadioButton.Size = New System.Drawing.Size(39, 24)
        Me.ZeroDepVarRadioButton.TabIndex = 4
        Me.ZeroDepVarRadioButton.TabStop = True
        Me.ZeroDepVarRadioButton.Text = "0"
        Me.ZeroDepVarRadioButton.UseVisualStyleBackColor = True
        '
        'Dependent4GroupBox
        '
        Me.Dependent4GroupBox.Controls.Add(Me.Dep4SelParamLabel)
        Me.Dependent4GroupBox.Controls.Add(Me.Dep4SelParamValue)
        Me.Dependent4GroupBox.Controls.Add(Me.Dep4ParamGroupLabel)
        Me.Dependent4GroupBox.Controls.Add(Me.Dep4ParamGroupValue)
        Me.Dependent4GroupBox.Location = New System.Drawing.Point(5, 376)
        Me.Dependent4GroupBox.Name = "Dependent4GroupBox"
        Me.Dependent4GroupBox.Size = New System.Drawing.Size(369, 100)
        Me.Dependent4GroupBox.TabIndex = 2
        Me.Dependent4GroupBox.TabStop = False
        Me.Dependent4GroupBox.Text = "Dependent Variable &4"
        '
        'Dep4SelParamLabel
        '
        Me.Dep4SelParamLabel.AutoSize = True
        Me.Dep4SelParamLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dep4SelParamLabel.Location = New System.Drawing.Point(6, 63)
        Me.Dep4SelParamLabel.Name = "Dep4SelParamLabel"
        Me.Dep4SelParamLabel.Size = New System.Drawing.Size(120, 20)
        Me.Dep4SelParamLabel.TabIndex = 2
        Me.Dep4SelParamLabel.Text = "Sel. Parameter"
        '
        'Dep4SelParamValue
        '
        Me.Dep4SelParamValue.ApplicationValue = -1
        Me.Dep4SelParamValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Dep4SelParamValue.EnableSaveActions = False
        Me.Dep4SelParamValue.FormattingEnabled = True
        Me.Dep4SelParamValue.IsCalculated = False
        Me.Dep4SelParamValue.Items.AddRange(New Object() {"CharacteristivcnfiltrationTime", "Kostiakova-CharTime"})
        Me.Dep4SelParamValue.Location = New System.Drawing.Point(135, 60)
        Me.Dep4SelParamValue.Name = "Dep4SelParamValue"
        Me.Dep4SelParamValue.SelectedIndexSet = False
        Me.Dep4SelParamValue.Size = New System.Drawing.Size(216, 28)
        Me.Dep4SelParamValue.TabIndex = 3
        '
        'Dep4ParamGroupLabel
        '
        Me.Dep4ParamGroupLabel.AutoSize = True
        Me.Dep4ParamGroupLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dep4ParamGroupLabel.Location = New System.Drawing.Point(6, 26)
        Me.Dep4ParamGroupLabel.Name = "Dep4ParamGroupLabel"
        Me.Dep4ParamGroupLabel.Size = New System.Drawing.Size(109, 20)
        Me.Dep4ParamGroupLabel.TabIndex = 0
        Me.Dep4ParamGroupLabel.Text = "Param Group"
        '
        'Dep4ParamGroupValue
        '
        Me.Dep4ParamGroupValue.ApplicationValue = -1
        Me.Dep4ParamGroupValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Dep4ParamGroupValue.EnableSaveActions = False
        Me.Dep4ParamGroupValue.FormattingEnabled = True
        Me.Dep4ParamGroupValue.IsCalculated = False
        Me.Dep4ParamGroupValue.Items.AddRange(New Object() {"System Geometry", "Roughness", "Infiltration", "Inflow / Runoff"})
        Me.Dep4ParamGroupValue.Location = New System.Drawing.Point(134, 23)
        Me.Dep4ParamGroupValue.Name = "Dep4ParamGroupValue"
        Me.Dep4ParamGroupValue.SelectedIndexSet = False
        Me.Dep4ParamGroupValue.Size = New System.Drawing.Size(217, 28)
        Me.Dep4ParamGroupValue.TabIndex = 1
        '
        'Dependent3GroupBox
        '
        Me.Dependent3GroupBox.Controls.Add(Me.Dep3SelParamLabel)
        Me.Dependent3GroupBox.Controls.Add(Me.Dep3SelParamValue)
        Me.Dependent3GroupBox.Controls.Add(Me.Dep3ParamGroupLabel)
        Me.Dependent3GroupBox.Controls.Add(Me.Dep3ParamGroupValue)
        Me.Dependent3GroupBox.Location = New System.Drawing.Point(5, 270)
        Me.Dependent3GroupBox.Name = "Dependent3GroupBox"
        Me.Dependent3GroupBox.Size = New System.Drawing.Size(369, 100)
        Me.Dependent3GroupBox.TabIndex = 1
        Me.Dependent3GroupBox.TabStop = False
        Me.Dependent3GroupBox.Text = "Dependent Varialble &3"
        '
        'Dep3SelParamLabel
        '
        Me.Dep3SelParamLabel.AutoSize = True
        Me.Dep3SelParamLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dep3SelParamLabel.Location = New System.Drawing.Point(6, 63)
        Me.Dep3SelParamLabel.Name = "Dep3SelParamLabel"
        Me.Dep3SelParamLabel.Size = New System.Drawing.Size(120, 20)
        Me.Dep3SelParamLabel.TabIndex = 2
        Me.Dep3SelParamLabel.Text = "Sel. Parameter"
        '
        'Dep3SelParamValue
        '
        Me.Dep3SelParamValue.ApplicationValue = -1
        Me.Dep3SelParamValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Dep3SelParamValue.EnableSaveActions = False
        Me.Dep3SelParamValue.FormattingEnabled = True
        Me.Dep3SelParamValue.IsCalculated = False
        Me.Dep3SelParamValue.Items.AddRange(New Object() {"CharacteristivcnfiltrationTime", "Kostiakova-CharTime"})
        Me.Dep3SelParamValue.Location = New System.Drawing.Point(135, 60)
        Me.Dep3SelParamValue.Name = "Dep3SelParamValue"
        Me.Dep3SelParamValue.SelectedIndexSet = False
        Me.Dep3SelParamValue.Size = New System.Drawing.Size(216, 28)
        Me.Dep3SelParamValue.TabIndex = 3
        '
        'Dep3ParamGroupLabel
        '
        Me.Dep3ParamGroupLabel.AutoSize = True
        Me.Dep3ParamGroupLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dep3ParamGroupLabel.Location = New System.Drawing.Point(6, 26)
        Me.Dep3ParamGroupLabel.Name = "Dep3ParamGroupLabel"
        Me.Dep3ParamGroupLabel.Size = New System.Drawing.Size(109, 20)
        Me.Dep3ParamGroupLabel.TabIndex = 0
        Me.Dep3ParamGroupLabel.Text = "Param Group"
        '
        'Dep3ParamGroupValue
        '
        Me.Dep3ParamGroupValue.ApplicationValue = -1
        Me.Dep3ParamGroupValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Dep3ParamGroupValue.EnableSaveActions = False
        Me.Dep3ParamGroupValue.FormattingEnabled = True
        Me.Dep3ParamGroupValue.IsCalculated = False
        Me.Dep3ParamGroupValue.Items.AddRange(New Object() {"System Geometry", "Roughness", "Infiltration", "Inflow / Runoff"})
        Me.Dep3ParamGroupValue.Location = New System.Drawing.Point(134, 23)
        Me.Dep3ParamGroupValue.Name = "Dep3ParamGroupValue"
        Me.Dep3ParamGroupValue.SelectedIndexSet = False
        Me.Dep3ParamGroupValue.Size = New System.Drawing.Size(217, 28)
        Me.Dep3ParamGroupValue.TabIndex = 1
        '
        'Dependent2GroupBox
        '
        Me.Dependent2GroupBox.Controls.Add(Me.Dep2SelParamLabel)
        Me.Dependent2GroupBox.Controls.Add(Me.Dep2SelParamValue)
        Me.Dependent2GroupBox.Controls.Add(Me.Dep2ParamGroupLabel)
        Me.Dependent2GroupBox.Controls.Add(Me.Dep2ParamGroupValue)
        Me.Dependent2GroupBox.Location = New System.Drawing.Point(5, 162)
        Me.Dependent2GroupBox.Name = "Dependent2GroupBox"
        Me.Dependent2GroupBox.Size = New System.Drawing.Size(369, 100)
        Me.Dependent2GroupBox.TabIndex = 0
        Me.Dependent2GroupBox.TabStop = False
        Me.Dependent2GroupBox.Text = "Dependent Variable &2"
        '
        'Dep2SelParamLabel
        '
        Me.Dep2SelParamLabel.AutoSize = True
        Me.Dep2SelParamLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dep2SelParamLabel.Location = New System.Drawing.Point(6, 63)
        Me.Dep2SelParamLabel.Name = "Dep2SelParamLabel"
        Me.Dep2SelParamLabel.Size = New System.Drawing.Size(120, 20)
        Me.Dep2SelParamLabel.TabIndex = 2
        Me.Dep2SelParamLabel.Text = "Sel. Parameter"
        '
        'Dep2SelParamValue
        '
        Me.Dep2SelParamValue.ApplicationValue = -1
        Me.Dep2SelParamValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Dep2SelParamValue.EnableSaveActions = False
        Me.Dep2SelParamValue.FormattingEnabled = True
        Me.Dep2SelParamValue.IsCalculated = False
        Me.Dep2SelParamValue.Items.AddRange(New Object() {"CharacteristivcnfiltrationTime", "Kostiakova-CharTime"})
        Me.Dep2SelParamValue.Location = New System.Drawing.Point(135, 60)
        Me.Dep2SelParamValue.Name = "Dep2SelParamValue"
        Me.Dep2SelParamValue.SelectedIndexSet = False
        Me.Dep2SelParamValue.Size = New System.Drawing.Size(216, 28)
        Me.Dep2SelParamValue.TabIndex = 3
        '
        'Dep2ParamGroupLabel
        '
        Me.Dep2ParamGroupLabel.AutoSize = True
        Me.Dep2ParamGroupLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dep2ParamGroupLabel.Location = New System.Drawing.Point(6, 26)
        Me.Dep2ParamGroupLabel.Name = "Dep2ParamGroupLabel"
        Me.Dep2ParamGroupLabel.Size = New System.Drawing.Size(109, 20)
        Me.Dep2ParamGroupLabel.TabIndex = 0
        Me.Dep2ParamGroupLabel.Text = "Param Group"
        '
        'Dep2ParamGroupValue
        '
        Me.Dep2ParamGroupValue.ApplicationValue = -1
        Me.Dep2ParamGroupValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Dep2ParamGroupValue.EnableSaveActions = False
        Me.Dep2ParamGroupValue.FormattingEnabled = True
        Me.Dep2ParamGroupValue.IsCalculated = False
        Me.Dep2ParamGroupValue.Items.AddRange(New Object() {"System Geometry", "Roughness", "Infiltration", "Inflow / Runoff"})
        Me.Dep2ParamGroupValue.Location = New System.Drawing.Point(134, 23)
        Me.Dep2ParamGroupValue.Name = "Dep2ParamGroupValue"
        Me.Dep2ParamGroupValue.SelectedIndexSet = False
        Me.Dep2ParamGroupValue.Size = New System.Drawing.Size(217, 28)
        Me.Dep2ParamGroupValue.TabIndex = 1
        '
        'FourDepVarRadioButton
        '
        Me.FourDepVarRadioButton.AutoSize = True
        Me.FourDepVarRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FourDepVarRadioButton.Location = New System.Drawing.Point(320, 25)
        Me.FourDepVarRadioButton.Name = "FourDepVarRadioButton"
        Me.FourDepVarRadioButton.Size = New System.Drawing.Size(39, 24)
        Me.FourDepVarRadioButton.TabIndex = 8
        Me.FourDepVarRadioButton.TabStop = True
        Me.FourDepVarRadioButton.Text = "4"
        Me.FourDepVarRadioButton.UseVisualStyleBackColor = True
        '
        'ThreeDepVarRadioButton
        '
        Me.ThreeDepVarRadioButton.AutoSize = True
        Me.ThreeDepVarRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThreeDepVarRadioButton.Location = New System.Drawing.Point(270, 25)
        Me.ThreeDepVarRadioButton.Name = "ThreeDepVarRadioButton"
        Me.ThreeDepVarRadioButton.Size = New System.Drawing.Size(39, 24)
        Me.ThreeDepVarRadioButton.TabIndex = 7
        Me.ThreeDepVarRadioButton.TabStop = True
        Me.ThreeDepVarRadioButton.Text = "3"
        Me.ThreeDepVarRadioButton.UseVisualStyleBackColor = True
        '
        'TwoDepVarRadioButton
        '
        Me.TwoDepVarRadioButton.AutoSize = True
        Me.TwoDepVarRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TwoDepVarRadioButton.Location = New System.Drawing.Point(220, 25)
        Me.TwoDepVarRadioButton.Name = "TwoDepVarRadioButton"
        Me.TwoDepVarRadioButton.Size = New System.Drawing.Size(39, 24)
        Me.TwoDepVarRadioButton.TabIndex = 6
        Me.TwoDepVarRadioButton.TabStop = True
        Me.TwoDepVarRadioButton.Text = "2"
        Me.TwoDepVarRadioButton.UseVisualStyleBackColor = True
        '
        'OneDepVarRadioButton
        '
        Me.OneDepVarRadioButton.AutoSize = True
        Me.OneDepVarRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OneDepVarRadioButton.Location = New System.Drawing.Point(170, 25)
        Me.OneDepVarRadioButton.Name = "OneDepVarRadioButton"
        Me.OneDepVarRadioButton.Size = New System.Drawing.Size(39, 24)
        Me.OneDepVarRadioButton.TabIndex = 5
        Me.OneDepVarRadioButton.TabStop = True
        Me.OneDepVarRadioButton.Text = "1"
        Me.OneDepVarRadioButton.UseVisualStyleBackColor = True
        '
        'NumDepVarsLabel
        '
        Me.NumDepVarsLabel.AutoSize = True
        Me.NumDepVarsLabel.Location = New System.Drawing.Point(10, 26)
        Me.NumDepVarsLabel.Name = "NumDepVarsLabel"
        Me.NumDepVarsLabel.Size = New System.Drawing.Size(80, 20)
        Me.NumDepVarsLabel.TabIndex = 3
        Me.NumDepVarsLabel.Text = "Number:"
        '
        'Dependent1GroupBox
        '
        Me.Dependent1GroupBox.Controls.Add(Me.Dep1SelParamLabel)
        Me.Dependent1GroupBox.Controls.Add(Me.Dep1SelParamValue)
        Me.Dependent1GroupBox.Controls.Add(Me.Dep1ParamGroupLabel)
        Me.Dependent1GroupBox.Controls.Add(Me.Dep1ParamGroupValue)
        Me.Dependent1GroupBox.Location = New System.Drawing.Point(5, 55)
        Me.Dependent1GroupBox.Name = "Dependent1GroupBox"
        Me.Dependent1GroupBox.Size = New System.Drawing.Size(369, 100)
        Me.Dependent1GroupBox.TabIndex = 9
        Me.Dependent1GroupBox.TabStop = False
        Me.Dependent1GroupBox.Text = "Dependent Variable &1"
        '
        'Dep1SelParamLabel
        '
        Me.Dep1SelParamLabel.AutoSize = True
        Me.Dep1SelParamLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dep1SelParamLabel.Location = New System.Drawing.Point(6, 63)
        Me.Dep1SelParamLabel.Name = "Dep1SelParamLabel"
        Me.Dep1SelParamLabel.Size = New System.Drawing.Size(120, 20)
        Me.Dep1SelParamLabel.TabIndex = 2
        Me.Dep1SelParamLabel.Text = "Sel. Parameter"
        '
        'Dep1SelParamValue
        '
        Me.Dep1SelParamValue.ApplicationValue = -1
        Me.Dep1SelParamValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Dep1SelParamValue.EnableSaveActions = False
        Me.Dep1SelParamValue.FormattingEnabled = True
        Me.Dep1SelParamValue.IsCalculated = False
        Me.Dep1SelParamValue.Items.AddRange(New Object() {"CharacteristivcnfiltrationTime", "Kostiakova-CharTime"})
        Me.Dep1SelParamValue.Location = New System.Drawing.Point(135, 60)
        Me.Dep1SelParamValue.Name = "Dep1SelParamValue"
        Me.Dep1SelParamValue.SelectedIndexSet = False
        Me.Dep1SelParamValue.Size = New System.Drawing.Size(216, 28)
        Me.Dep1SelParamValue.TabIndex = 3
        '
        'Dep1ParamGroupLabel
        '
        Me.Dep1ParamGroupLabel.AutoSize = True
        Me.Dep1ParamGroupLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dep1ParamGroupLabel.Location = New System.Drawing.Point(6, 26)
        Me.Dep1ParamGroupLabel.Name = "Dep1ParamGroupLabel"
        Me.Dep1ParamGroupLabel.Size = New System.Drawing.Size(109, 20)
        Me.Dep1ParamGroupLabel.TabIndex = 0
        Me.Dep1ParamGroupLabel.Text = "Param Group"
        '
        'Dep1ParamGroupValue
        '
        Me.Dep1ParamGroupValue.ApplicationValue = -1
        Me.Dep1ParamGroupValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Dep1ParamGroupValue.EnableSaveActions = False
        Me.Dep1ParamGroupValue.FormattingEnabled = True
        Me.Dep1ParamGroupValue.IsCalculated = False
        Me.Dep1ParamGroupValue.Items.AddRange(New Object() {"System Geometry", "Roughness", "Infiltration", "Inflow / Runoff"})
        Me.Dep1ParamGroupValue.Location = New System.Drawing.Point(134, 23)
        Me.Dep1ParamGroupValue.Name = "Dep1ParamGroupValue"
        Me.Dep1ParamGroupValue.SelectedIndexSet = True
        Me.Dep1ParamGroupValue.Size = New System.Drawing.Size(217, 28)
        Me.Dep1ParamGroupValue.TabIndex = 1
        '
        'IndependentVariablesGroup
        '
        Me.IndependentVariablesGroup.Controls.Add(Me.Independent2GroupBox)
        Me.IndependentVariablesGroup.Controls.Add(Me.TwoIndVarRadioButton)
        Me.IndependentVariablesGroup.Controls.Add(Me.OneIndVarRadioButton)
        Me.IndependentVariablesGroup.Controls.Add(Me.NoIndVarsLabel)
        Me.IndependentVariablesGroup.Controls.Add(Me.Independent1GroupBox)
        Me.IndependentVariablesGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IndependentVariablesGroup.Location = New System.Drawing.Point(14, 9)
        Me.IndependentVariablesGroup.Name = "IndependentVariablesGroup"
        Me.IndependentVariablesGroup.Size = New System.Drawing.Size(372, 483)
        Me.IndependentVariablesGroup.TabIndex = 1
        Me.IndependentVariablesGroup.TabStop = False
        Me.IndependentVariablesGroup.Text = "&Independent Variables"
        '
        'Independent2GroupBox
        '
        Me.Independent2GroupBox.Controls.Add(Me.NumInd2Increments)
        Me.Independent2GroupBox.Controls.Add(Me.Ind2UnitsText)
        Me.Independent2GroupBox.Controls.Add(Me.MaxInd2Value)
        Me.Independent2GroupBox.Controls.Add(Me.MinInd2Value)
        Me.Independent2GroupBox.Controls.Add(Me.TcoToLabel)
        Me.Independent2GroupBox.Controls.Add(Me.TcoNumIncsLabal)
        Me.Independent2GroupBox.Controls.Add(Me.Indep2SelParamLabel)
        Me.Independent2GroupBox.Controls.Add(Me.Indep2ParamValue)
        Me.Independent2GroupBox.Controls.Add(Me.Indep2ParamGroupLabel)
        Me.Independent2GroupBox.Controls.Add(Me.Indep2GroupValue)
        Me.Independent2GroupBox.Controls.Add(Me.CutoffTimeRange)
        Me.Independent2GroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Independent2GroupBox.Location = New System.Drawing.Point(6, 263)
        Me.Independent2GroupBox.Name = "Independent2GroupBox"
        Me.Independent2GroupBox.Size = New System.Drawing.Size(361, 183)
        Me.Independent2GroupBox.TabIndex = 4
        Me.Independent2GroupBox.TabStop = False
        Me.Independent2GroupBox.Text = "Independent Variable &2"
        '
        'NumInd2Increments
        '
        Me.NumInd2Increments.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumInd2Increments.IsCalculated = False
        Me.NumInd2Increments.Location = New System.Drawing.Point(190, 149)
        Me.NumInd2Increments.Name = "NumInd2Increments"
        Me.NumInd2Increments.Size = New System.Drawing.Size(104, 24)
        Me.NumInd2Increments.TabIndex = 10
        Me.NumInd2Increments.ValueBackColor = System.Drawing.SystemColors.Window
        Me.NumInd2Increments.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.NumInd2Increments.ValueText = ""
        '
        'Ind2UnitsText
        '
        Me.Ind2UnitsText.AutoSize = True
        Me.Ind2UnitsText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ind2UnitsText.Location = New System.Drawing.Point(267, 111)
        Me.Ind2UnitsText.Name = "Ind2UnitsText"
        Me.Ind2UnitsText.Size = New System.Drawing.Size(48, 20)
        Me.Ind2UnitsText.TabIndex = 8
        Me.Ind2UnitsText.Text = "Units"
        '
        'MaxInd2Value
        '
        Me.MaxInd2Value.Location = New System.Drawing.Point(190, 108)
        Me.MaxInd2Value.Name = "MaxInd2Value"
        Me.MaxInd2Value.Size = New System.Drawing.Size(71, 26)
        Me.MaxInd2Value.TabIndex = 7
        '
        'MinInd2Value
        '
        Me.MinInd2Value.Location = New System.Drawing.Point(81, 108)
        Me.MinInd2Value.Name = "MinInd2Value"
        Me.MinInd2Value.Size = New System.Drawing.Size(71, 26)
        Me.MinInd2Value.TabIndex = 5
        '
        'TcoToLabel
        '
        Me.TcoToLabel.AutoSize = True
        Me.TcoToLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcoToLabel.Location = New System.Drawing.Point(161, 110)
        Me.TcoToLabel.Name = "TcoToLabel"
        Me.TcoToLabel.Size = New System.Drawing.Size(23, 20)
        Me.TcoToLabel.TabIndex = 6
        Me.TcoToLabel.Text = "to"
        '
        'TcoNumIncsLabal
        '
        Me.TcoNumIncsLabal.AutoSize = True
        Me.TcoNumIncsLabal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcoNumIncsLabal.Location = New System.Drawing.Point(8, 149)
        Me.TcoNumIncsLabal.Name = "TcoNumIncsLabal"
        Me.TcoNumIncsLabal.Size = New System.Drawing.Size(175, 20)
        Me.TcoNumIncsLabal.TabIndex = 9
        Me.TcoNumIncsLabal.Text = "Number of Increments"
        '
        'Indep2SelParamLabel
        '
        Me.Indep2SelParamLabel.AutoSize = True
        Me.Indep2SelParamLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Indep2SelParamLabel.Location = New System.Drawing.Point(8, 72)
        Me.Indep2SelParamLabel.Name = "Indep2SelParamLabel"
        Me.Indep2SelParamLabel.Size = New System.Drawing.Size(120, 20)
        Me.Indep2SelParamLabel.TabIndex = 2
        Me.Indep2SelParamLabel.Text = "Sel. Parameter"
        '
        'Indep2ParamValue
        '
        Me.Indep2ParamValue.ApplicationValue = -1
        Me.Indep2ParamValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Indep2ParamValue.EnableSaveActions = False
        Me.Indep2ParamValue.FormattingEnabled = True
        Me.Indep2ParamValue.IsCalculated = False
        Me.Indep2ParamValue.Items.AddRange(New Object() {"CharacteristivcnfiltrationTime", "Kostiakova-CharTime"})
        Me.Indep2ParamValue.Location = New System.Drawing.Point(137, 69)
        Me.Indep2ParamValue.Name = "Indep2ParamValue"
        Me.Indep2ParamValue.SelectedIndexSet = False
        Me.Indep2ParamValue.Size = New System.Drawing.Size(216, 28)
        Me.Indep2ParamValue.TabIndex = 3
        '
        'Indep2ParamGroupLabel
        '
        Me.Indep2ParamGroupLabel.AutoSize = True
        Me.Indep2ParamGroupLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Indep2ParamGroupLabel.Location = New System.Drawing.Point(8, 35)
        Me.Indep2ParamGroupLabel.Name = "Indep2ParamGroupLabel"
        Me.Indep2ParamGroupLabel.Size = New System.Drawing.Size(109, 20)
        Me.Indep2ParamGroupLabel.TabIndex = 0
        Me.Indep2ParamGroupLabel.Text = "Param Group"
        '
        'Indep2GroupValue
        '
        Me.Indep2GroupValue.ApplicationValue = -1
        Me.Indep2GroupValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Indep2GroupValue.EnableSaveActions = False
        Me.Indep2GroupValue.FormattingEnabled = True
        Me.Indep2GroupValue.IsCalculated = False
        Me.Indep2GroupValue.Items.AddRange(New Object() {"System Geometry", "Roughness", "Infiltration", "Inflow / Runoff"})
        Me.Indep2GroupValue.Location = New System.Drawing.Point(136, 32)
        Me.Indep2GroupValue.Name = "Indep2GroupValue"
        Me.Indep2GroupValue.SelectedIndexSet = True
        Me.Indep2GroupValue.Size = New System.Drawing.Size(217, 28)
        Me.Indep2GroupValue.TabIndex = 1
        '
        'CutoffTimeRange
        '
        Me.CutoffTimeRange.AutoSize = True
        Me.CutoffTimeRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffTimeRange.Location = New System.Drawing.Point(8, 114)
        Me.CutoffTimeRange.Name = "CutoffTimeRange"
        Me.CutoffTimeRange.Size = New System.Drawing.Size(57, 20)
        Me.CutoffTimeRange.TabIndex = 4
        Me.CutoffTimeRange.Text = "Range"
        '
        'TwoIndVarRadioButton
        '
        Me.TwoIndVarRadioButton.AutoSize = True
        Me.TwoIndVarRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TwoIndVarRadioButton.Location = New System.Drawing.Point(150, 25)
        Me.TwoIndVarRadioButton.Name = "TwoIndVarRadioButton"
        Me.TwoIndVarRadioButton.Size = New System.Drawing.Size(39, 24)
        Me.TwoIndVarRadioButton.TabIndex = 2
        Me.TwoIndVarRadioButton.TabStop = True
        Me.TwoIndVarRadioButton.Text = "2"
        Me.TwoIndVarRadioButton.UseVisualStyleBackColor = True
        '
        'OneIndVarRadioButton
        '
        Me.OneIndVarRadioButton.AutoSize = True
        Me.OneIndVarRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OneIndVarRadioButton.Location = New System.Drawing.Point(100, 25)
        Me.OneIndVarRadioButton.Name = "OneIndVarRadioButton"
        Me.OneIndVarRadioButton.Size = New System.Drawing.Size(39, 24)
        Me.OneIndVarRadioButton.TabIndex = 1
        Me.OneIndVarRadioButton.TabStop = True
        Me.OneIndVarRadioButton.Text = "1"
        Me.OneIndVarRadioButton.UseVisualStyleBackColor = True
        '
        'NoIndVarsLabel
        '
        Me.NoIndVarsLabel.AutoSize = True
        Me.NoIndVarsLabel.Location = New System.Drawing.Point(10, 26)
        Me.NoIndVarsLabel.Name = "NoIndVarsLabel"
        Me.NoIndVarsLabel.Size = New System.Drawing.Size(80, 20)
        Me.NoIndVarsLabel.TabIndex = 0
        Me.NoIndVarsLabel.Text = "Number:"
        '
        'Independent1GroupBox
        '
        Me.Independent1GroupBox.Controls.Add(Me.NumInd1Increments)
        Me.Independent1GroupBox.Controls.Add(Me.Ind1UnitsText)
        Me.Independent1GroupBox.Controls.Add(Me.MaxInd1Value)
        Me.Independent1GroupBox.Controls.Add(Me.MinInd1Value)
        Me.Independent1GroupBox.Controls.Add(Me.QinNumIncsLabel)
        Me.Independent1GroupBox.Controls.Add(Me.Indep1SelParamLabel)
        Me.Independent1GroupBox.Controls.Add(Me.Indep1ParamValue)
        Me.Independent1GroupBox.Controls.Add(Me.Indep1ParamGroupLabel)
        Me.Independent1GroupBox.Controls.Add(Me.Indep1GroupValue)
        Me.Independent1GroupBox.Controls.Add(Me.QinToLabel)
        Me.Independent1GroupBox.Controls.Add(Me.QinRangeLabel)
        Me.Independent1GroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Independent1GroupBox.Location = New System.Drawing.Point(5, 55)
        Me.Independent1GroupBox.Name = "Independent1GroupBox"
        Me.Independent1GroupBox.Size = New System.Drawing.Size(361, 183)
        Me.Independent1GroupBox.TabIndex = 3
        Me.Independent1GroupBox.TabStop = False
        Me.Independent1GroupBox.Text = "Independent Variable &1"
        '
        'NumInd1Increments
        '
        Me.NumInd1Increments.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumInd1Increments.IsCalculated = False
        Me.NumInd1Increments.Location = New System.Drawing.Point(191, 149)
        Me.NumInd1Increments.Name = "NumInd1Increments"
        Me.NumInd1Increments.Size = New System.Drawing.Size(104, 24)
        Me.NumInd1Increments.TabIndex = 10
        Me.NumInd1Increments.ValueBackColor = System.Drawing.SystemColors.Window
        Me.NumInd1Increments.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.NumInd1Increments.ValueText = ""
        '
        'Ind1UnitsText
        '
        Me.Ind1UnitsText.AutoSize = True
        Me.Ind1UnitsText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ind1UnitsText.Location = New System.Drawing.Point(268, 112)
        Me.Ind1UnitsText.Name = "Ind1UnitsText"
        Me.Ind1UnitsText.Size = New System.Drawing.Size(48, 20)
        Me.Ind1UnitsText.TabIndex = 8
        Me.Ind1UnitsText.Text = "Units"
        '
        'MaxInd1Value
        '
        Me.MaxInd1Value.Location = New System.Drawing.Point(191, 109)
        Me.MaxInd1Value.Name = "MaxInd1Value"
        Me.MaxInd1Value.Size = New System.Drawing.Size(71, 26)
        Me.MaxInd1Value.TabIndex = 7
        '
        'MinInd1Value
        '
        Me.MinInd1Value.Location = New System.Drawing.Point(82, 109)
        Me.MinInd1Value.Name = "MinInd1Value"
        Me.MinInd1Value.Size = New System.Drawing.Size(71, 26)
        Me.MinInd1Value.TabIndex = 5
        '
        'QinNumIncsLabel
        '
        Me.QinNumIncsLabel.AutoSize = True
        Me.QinNumIncsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QinNumIncsLabel.Location = New System.Drawing.Point(8, 149)
        Me.QinNumIncsLabel.Name = "QinNumIncsLabel"
        Me.QinNumIncsLabel.Size = New System.Drawing.Size(175, 20)
        Me.QinNumIncsLabel.TabIndex = 9
        Me.QinNumIncsLabel.Text = "Number of Increments"
        '
        'Indep1SelParamLabel
        '
        Me.Indep1SelParamLabel.AutoSize = True
        Me.Indep1SelParamLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Indep1SelParamLabel.Location = New System.Drawing.Point(8, 72)
        Me.Indep1SelParamLabel.Name = "Indep1SelParamLabel"
        Me.Indep1SelParamLabel.Size = New System.Drawing.Size(120, 20)
        Me.Indep1SelParamLabel.TabIndex = 2
        Me.Indep1SelParamLabel.Text = "Sel. Parameter"
        '
        'Indep1ParamValue
        '
        Me.Indep1ParamValue.ApplicationValue = -1
        Me.Indep1ParamValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Indep1ParamValue.EnableSaveActions = False
        Me.Indep1ParamValue.FormattingEnabled = True
        Me.Indep1ParamValue.IsCalculated = False
        Me.Indep1ParamValue.Items.AddRange(New Object() {"CharacteristivcnfiltrationTime", "Kostiakova-CharTime"})
        Me.Indep1ParamValue.Location = New System.Drawing.Point(137, 69)
        Me.Indep1ParamValue.Name = "Indep1ParamValue"
        Me.Indep1ParamValue.SelectedIndexSet = False
        Me.Indep1ParamValue.Size = New System.Drawing.Size(216, 28)
        Me.Indep1ParamValue.TabIndex = 3
        '
        'Indep1ParamGroupLabel
        '
        Me.Indep1ParamGroupLabel.AutoSize = True
        Me.Indep1ParamGroupLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Indep1ParamGroupLabel.Location = New System.Drawing.Point(8, 35)
        Me.Indep1ParamGroupLabel.Name = "Indep1ParamGroupLabel"
        Me.Indep1ParamGroupLabel.Size = New System.Drawing.Size(109, 20)
        Me.Indep1ParamGroupLabel.TabIndex = 0
        Me.Indep1ParamGroupLabel.Text = "Param Group"
        '
        'Indep1GroupValue
        '
        Me.Indep1GroupValue.ApplicationValue = -1
        Me.Indep1GroupValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Indep1GroupValue.EnableSaveActions = False
        Me.Indep1GroupValue.FormattingEnabled = True
        Me.Indep1GroupValue.IsCalculated = False
        Me.Indep1GroupValue.Items.AddRange(New Object() {"System Geometry", "Roughness", "Infiltration", "Inflow / Runoff"})
        Me.Indep1GroupValue.Location = New System.Drawing.Point(136, 32)
        Me.Indep1GroupValue.Name = "Indep1GroupValue"
        Me.Indep1GroupValue.SelectedIndexSet = True
        Me.Indep1GroupValue.Size = New System.Drawing.Size(217, 28)
        Me.Indep1GroupValue.TabIndex = 1
        '
        'QinToLabel
        '
        Me.QinToLabel.AutoSize = True
        Me.QinToLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QinToLabel.Location = New System.Drawing.Point(162, 111)
        Me.QinToLabel.Name = "QinToLabel"
        Me.QinToLabel.Size = New System.Drawing.Size(23, 20)
        Me.QinToLabel.TabIndex = 6
        Me.QinToLabel.Text = "to"
        '
        'QinRangeLabel
        '
        Me.QinRangeLabel.AutoSize = True
        Me.QinRangeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QinRangeLabel.Location = New System.Drawing.Point(8, 111)
        Me.QinRangeLabel.Name = "QinRangeLabel"
        Me.QinRangeLabel.Size = New System.Drawing.Size(57, 20)
        Me.QinRangeLabel.TabIndex = 4
        Me.QinRangeLabel.Text = "Range"
        '
        'OutputFileBox
        '
        Me.OutputFileBox.AccessibleDescription = "Specifies the default directory for WinSRFR log & diagnostic files."
        Me.OutputFileBox.AccessibleName = "Default Log Folder"
        Me.OutputFileBox.Controls.Add(Me.SaveButton)
        Me.OutputFileBox.Controls.Add(Me.OutputInstructions)
        Me.OutputFileBox.Controls.Add(Me.BrowseOutputFileName)
        Me.OutputFileBox.Controls.Add(Me.OutputFileName)
        Me.OutputFileBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputFileBox.Location = New System.Drawing.Point(15, 595)
        Me.OutputFileBox.Name = "OutputFileBox"
        Me.OutputFileBox.Size = New System.Drawing.Size(745, 110)
        Me.OutputFileBox.TabIndex = 4
        Me.OutputFileBox.TabStop = False
        Me.OutputFileBox.Text = "&Output File"
        '
        'SaveButton
        '
        Me.SaveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.Location = New System.Drawing.Point(560, 82)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(90, 30)
        Me.SaveButton.TabIndex = 3
        Me.SaveButton.Text = "&Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'OutputInstructions
        '
        Me.OutputInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputInstructions.Location = New System.Drawing.Point(16, 25)
        Me.OutputInstructions.Name = "OutputInstructions"
        Me.OutputInstructions.Size = New System.Drawing.Size(677, 21)
        Me.OutputInstructions.TabIndex = 0
        Me.OutputInstructions.Text = "Enter the name of the .txt or .csv Tabulated Script output file"
        '
        'BrowseOutputFileName
        '
        Me.BrowseOutputFileName.AccessibleDescription = "Browses for location to save script output file"
        Me.BrowseOutputFileName.AccessibleName = "Browse Output File Name"
        Me.BrowseOutputFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseOutputFileName.Location = New System.Drawing.Point(656, 51)
        Me.BrowseOutputFileName.Name = "BrowseOutputFileName"
        Me.BrowseOutputFileName.Size = New System.Drawing.Size(90, 30)
        Me.BrowseOutputFileName.TabIndex = 2
        Me.BrowseOutputFileName.Text = "&Browse"
        '
        'OutputFileName
        '
        Me.OutputFileName.AccessibleDescription = "WinSRFR's log & diagnostic folder."
        Me.OutputFileName.AccessibleName = "Log Folder"
        Me.OutputFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputFileName.Location = New System.Drawing.Point(16, 50)
        Me.OutputFileName.Name = "OutputFileName"
        Me.OutputFileName.Size = New System.Drawing.Size(634, 26)
        Me.OutputFileName.TabIndex = 1
        '
        'ctl_SensitivityAnalysisStructured
        '
        Me.AccessibleDescription = "Collection of controls for defining the irrigation parameters and ranges for Sens" &
    "itivity Analysis"
        Me.AccessibleName = "Sensitivity Analysis Setup Control"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OutputFileBox)
        Me.Controls.Add(Me.InputFileBox)
        Me.Controls.Add(Me.DependentVariablesGroup)
        Me.Controls.Add(Me.IndependentVariablesGroup)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_SensitivityAnalysisStructured"
        Me.Size = New System.Drawing.Size(770, 710)
        Me.InputFileBox.ResumeLayout(False)
        Me.InputFileBox.PerformLayout()
        Me.DependentVariablesGroup.ResumeLayout(False)
        Me.DependentVariablesGroup.PerformLayout()
        Me.Dependent4GroupBox.ResumeLayout(False)
        Me.Dependent4GroupBox.PerformLayout()
        Me.Dependent3GroupBox.ResumeLayout(False)
        Me.Dependent3GroupBox.PerformLayout()
        Me.Dependent2GroupBox.ResumeLayout(False)
        Me.Dependent2GroupBox.PerformLayout()
        Me.Dependent1GroupBox.ResumeLayout(False)
        Me.Dependent1GroupBox.PerformLayout()
        Me.IndependentVariablesGroup.ResumeLayout(False)
        Me.IndependentVariablesGroup.PerformLayout()
        Me.Independent2GroupBox.ResumeLayout(False)
        Me.Independent2GroupBox.PerformLayout()
        Me.Independent1GroupBox.ResumeLayout(False)
        Me.Independent1GroupBox.PerformLayout()
        Me.OutputFileBox.ResumeLayout(False)
        Me.OutputFileBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents InputFileBox As DataStore.ctl_GroupBox
    Friend WithEvents InputInstructions As DataStore.ctl_Label
    Friend WithEvents BrowseInputFileButton As DataStore.ctl_Button
    Friend WithEvents InputFilename As TextBox
    Friend WithEvents DependentVariablesGroup As DataStore.ctl_GroupBox
    Friend WithEvents Dependent4GroupBox As DataStore.ctl_GroupBox
    Friend WithEvents Dep4SelParamLabel As DataStore.ctl_Label
    Friend WithEvents Dep4SelParamValue As DataStore.ctl_SelectParameter
    Friend WithEvents Dep4ParamGroupLabel As DataStore.ctl_Label
    Friend WithEvents Dep4ParamGroupValue As DataStore.ctl_SelectParameter
    Friend WithEvents Dependent3GroupBox As DataStore.ctl_GroupBox
    Friend WithEvents Dep3SelParamLabel As DataStore.ctl_Label
    Friend WithEvents Dep3SelParamValue As DataStore.ctl_SelectParameter
    Friend WithEvents Dep3ParamGroupLabel As DataStore.ctl_Label
    Friend WithEvents Dep3ParamGroupValue As DataStore.ctl_SelectParameter
    Friend WithEvents Dependent2GroupBox As DataStore.ctl_GroupBox
    Friend WithEvents Dep2SelParamLabel As DataStore.ctl_Label
    Friend WithEvents Dep2SelParamValue As DataStore.ctl_SelectParameter
    Friend WithEvents Dep2ParamGroupLabel As DataStore.ctl_Label
    Friend WithEvents Dep2ParamGroupValue As DataStore.ctl_SelectParameter
    Friend WithEvents FourDepVarRadioButton As DataStore.ctl_RadioButton
    Friend WithEvents ThreeDepVarRadioButton As DataStore.ctl_RadioButton
    Friend WithEvents TwoDepVarRadioButton As DataStore.ctl_RadioButton
    Friend WithEvents OneDepVarRadioButton As DataStore.ctl_RadioButton
    Friend WithEvents NumDepVarsLabel As DataStore.ctl_Label
    Friend WithEvents Dependent1GroupBox As DataStore.ctl_GroupBox
    Friend WithEvents Dep1SelParamLabel As DataStore.ctl_Label
    Friend WithEvents Dep1SelParamValue As DataStore.ctl_SelectParameter
    Friend WithEvents Dep1ParamGroupLabel As DataStore.ctl_Label
    Friend WithEvents Dep1ParamGroupValue As DataStore.ctl_SelectParameter
    Friend WithEvents IndependentVariablesGroup As DataStore.ctl_GroupBox
    Friend WithEvents TwoIndVarRadioButton As DataStore.ctl_RadioButton
    Friend WithEvents OneIndVarRadioButton As DataStore.ctl_RadioButton
    Friend WithEvents NoIndVarsLabel As DataStore.ctl_Label
    Friend WithEvents Independent1GroupBox As DataStore.ctl_GroupBox
    Friend WithEvents QinRangeLabel As DataStore.ctl_Label
    Friend WithEvents OutputFileBox As DataStore.ctl_GroupBox
    Friend WithEvents OutputInstructions As DataStore.ctl_Label
    Friend WithEvents BrowseOutputFileName As DataStore.ctl_Button
    Friend WithEvents OutputFileName As TextBox
    Friend WithEvents Independent2GroupBox As DataStore.ctl_GroupBox
    Friend WithEvents TcoNumIncsLabal As Label
    Friend WithEvents Indep2SelParamLabel As DataStore.ctl_Label
    Friend WithEvents Indep2ParamValue As DataStore.ctl_SelectParameter
    Friend WithEvents Indep2ParamGroupLabel As DataStore.ctl_Label
    Friend WithEvents Indep2GroupValue As DataStore.ctl_SelectParameter
    Friend WithEvents CutoffTimeRange As DataStore.ctl_Label
    Friend WithEvents QinNumIncsLabel As Label
    Friend WithEvents Indep1SelParamLabel As DataStore.ctl_Label
    Friend WithEvents Indep1ParamValue As DataStore.ctl_SelectParameter
    Friend WithEvents Indep1ParamGroupLabel As DataStore.ctl_Label
    Friend WithEvents Indep1GroupValue As DataStore.ctl_SelectParameter
    Friend WithEvents QinToLabel As Label
    Friend WithEvents Ind2UnitsText As Label
    Friend WithEvents MaxInd2Value As TextBox
    Friend WithEvents MinInd2Value As TextBox
    Friend WithEvents TcoToLabel As Label
    Friend WithEvents Ind1UnitsText As Label
    Friend WithEvents MaxInd1Value As TextBox
    Friend WithEvents MinInd1Value As TextBox
    Friend WithEvents SaveButton As DataStore.ctl_Button
    Friend WithEvents ZeroDepVarRadioButton As DataStore.ctl_RadioButton
    Friend WithEvents NumInd1Increments As DataStore.ctl_IntegerParameter
    Friend WithEvents NumInd2Increments As DataStore.ctl_IntegerParameter
End Class
