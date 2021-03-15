
'**********************************************************************************************
' Roughness Goodness of Fit form
'
' Displays a Roughness Goodness of Fit (i.e. 2D Graph) along with controls to select the
' X & Y contour values for the GoodnessOfFitGraph.
'
Imports DataStore

Public Class RoughnessGoodnessOfFit
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal worldWindow As WorldWindow)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitRoughnessGoodnessOfFit(worldWindow)

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
    Friend WithEvents RoughnessControlPanel As DataStore.ctl_Panel
    Friend WithEvents ManningNBox As DataStore.ctl_GroupBox
    Friend WithEvents ManningNValue As ExNumericUpDown
    Friend WithEvents ManningNLabel As System.Windows.Forms.Label
    Friend WithEvents InstructionsPanel As DataStore.ctl_Panel
    Friend WithEvents Instructions1 As DataStore.ctl_Label
    Friend WithEvents Instructions2 As DataStore.ctl_Label
    Friend WithEvents ManningRangeLabel As System.Windows.Forms.Label
    Friend WithEvents ManningRangeValue As WinMain.ExNumericUpDown
    Friend WithEvents ChiBox As DataStore.ctl_GroupBox
    Friend WithEvents ChiRangeLabel As System.Windows.Forms.Label
    Friend WithEvents ChiRangeValue As WinMain.ExNumericUpDown
    Friend WithEvents ChiValueLabel As System.Windows.Forms.Label
    Friend WithEvents ChiValue As WinMain.ExNumericUpDown
    Friend WithEvents ChiValueUnits As System.Windows.Forms.Label
    Friend WithEvents ChiRangeUnits As System.Windows.Forms.Label
    Friend WithEvents MethodBox As DataStore.ctl_GroupBox
    Friend WithEvents PbiasButton As DataStore.ctl_RadioButton
    Friend WithEvents NseButton As DataStore.ctl_RadioButton
    Friend WithEvents GofPanel As DataStore.ctl_Panel
    Friend WithEvents ButtonPanel As ctl_Panel
    Friend WithEvents ComputeButton As ctl_Button
    Friend WithEvents SaveIt As ctl_Button
    Friend WithEvents CancelIt As ctl_Button
    Friend WithEvents GoodnessOfFitGraph As WinMain.grf_XYGraph
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RoughnessGoodnessOfFit))
        Me.RoughnessControlPanel = New DataStore.ctl_Panel()
        Me.MethodBox = New DataStore.ctl_GroupBox()
        Me.PbiasButton = New DataStore.ctl_RadioButton()
        Me.NseButton = New DataStore.ctl_RadioButton()
        Me.ChiBox = New DataStore.ctl_GroupBox()
        Me.ChiRangeUnits = New System.Windows.Forms.Label()
        Me.ChiValueUnits = New System.Windows.Forms.Label()
        Me.ChiRangeLabel = New System.Windows.Forms.Label()
        Me.ChiRangeValue = New WinMain.ExNumericUpDown()
        Me.ChiValueLabel = New System.Windows.Forms.Label()
        Me.ChiValue = New WinMain.ExNumericUpDown()
        Me.ManningNBox = New DataStore.ctl_GroupBox()
        Me.ManningRangeLabel = New System.Windows.Forms.Label()
        Me.ManningRangeValue = New WinMain.ExNumericUpDown()
        Me.ManningNLabel = New System.Windows.Forms.Label()
        Me.ManningNValue = New WinMain.ExNumericUpDown()
        Me.GoodnessOfFitGraph = New WinMain.grf_XYGraph()
        Me.InstructionsPanel = New DataStore.ctl_Panel()
        Me.Instructions1 = New DataStore.ctl_Label()
        Me.Instructions2 = New DataStore.ctl_Label()
        Me.GofPanel = New DataStore.ctl_Panel()
        Me.ButtonPanel = New DataStore.ctl_Panel()
        Me.ComputeButton = New DataStore.ctl_Button()
        Me.SaveIt = New DataStore.ctl_Button()
        Me.CancelIt = New DataStore.ctl_Button()
        Me.RoughnessControlPanel.SuspendLayout()
        Me.MethodBox.SuspendLayout()
        Me.ChiBox.SuspendLayout()
        CType(Me.ChiRangeValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChiValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ManningNBox.SuspendLayout()
        CType(Me.ManningRangeValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManningNValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GoodnessOfFitGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InstructionsPanel.SuspendLayout()
        Me.GofPanel.SuspendLayout()
        Me.ButtonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RoughnessControlPanel
        '
        Me.RoughnessControlPanel.AccessibleDescription = "Selects the Manning n values where the Roughness Goodness of Fit is calculated."
        Me.RoughnessControlPanel.AccessibleName = "Manning n controls"
        Me.RoughnessControlPanel.Controls.Add(Me.MethodBox)
        Me.RoughnessControlPanel.Controls.Add(Me.ChiBox)
        Me.RoughnessControlPanel.Controls.Add(Me.ManningNBox)
        Me.RoughnessControlPanel.Location = New System.Drawing.Point(3, 50)
        Me.RoughnessControlPanel.Name = "RoughnessControlPanel"
        Me.RoughnessControlPanel.Size = New System.Drawing.Size(458, 145)
        Me.RoughnessControlPanel.TabIndex = 1
        '
        'MethodBox
        '
        Me.MethodBox.AccessibleDescription = "Selects the Chi value and range for the Goodness of Fit curves."
        Me.MethodBox.AccessibleName = "Sayre-Albertson Chi"
        Me.MethodBox.Controls.Add(Me.PbiasButton)
        Me.MethodBox.Controls.Add(Me.NseButton)
        Me.MethodBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MethodBox.Location = New System.Drawing.Point(8, 74)
        Me.MethodBox.Name = "MethodBox"
        Me.MethodBox.Size = New System.Drawing.Size(430, 64)
        Me.MethodBox.TabIndex = 1
        Me.MethodBox.TabStop = False
        Me.MethodBox.Text = "Goodness-of-Fit Indicator"
        '
        'PbiasButton
        '
        Me.PbiasButton.AutoSize = True
        Me.PbiasButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PbiasButton.Location = New System.Drawing.Point(240, 30)
        Me.PbiasButton.Name = "PbiasButton"
        Me.PbiasButton.Size = New System.Drawing.Size(159, 21)
        Me.PbiasButton.TabIndex = 1
        Me.PbiasButton.TabStop = True
        Me.PbiasButton.Text = "Percent Bias (PBIAS)"
        Me.PbiasButton.UseVisualStyleBackColor = True
        '
        'NseButton
        '
        Me.NseButton.AutoSize = True
        Me.NseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NseButton.Location = New System.Drawing.Point(30, 30)
        Me.NseButton.Name = "NseButton"
        Me.NseButton.Size = New System.Drawing.Size(169, 21)
        Me.NseButton.TabIndex = 0
        Me.NseButton.TabStop = True
        Me.NseButton.Text = "Nash-Sutcliffe E (NSE)"
        Me.NseButton.UseVisualStyleBackColor = True
        '
        'ChiBox
        '
        Me.ChiBox.AccessibleDescription = "Selects the Chi value and range for the Goodness of Fit curves."
        Me.ChiBox.AccessibleName = "Sayre-Albertson Chi"
        Me.ChiBox.Controls.Add(Me.ChiRangeUnits)
        Me.ChiBox.Controls.Add(Me.ChiValueUnits)
        Me.ChiBox.Controls.Add(Me.ChiRangeLabel)
        Me.ChiBox.Controls.Add(Me.ChiRangeValue)
        Me.ChiBox.Controls.Add(Me.ChiValueLabel)
        Me.ChiBox.Controls.Add(Me.ChiValue)
        Me.ChiBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChiBox.Location = New System.Drawing.Point(8, 5)
        Me.ChiBox.Name = "ChiBox"
        Me.ChiBox.Size = New System.Drawing.Size(430, 64)
        Me.ChiBox.TabIndex = 2
        Me.ChiBox.TabStop = False
        Me.ChiBox.Text = "Sayre-Albertson Chi"
        '
        'ChiRangeUnits
        '
        Me.ChiRangeUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChiRangeUnits.Location = New System.Drawing.Point(385, 25)
        Me.ChiRangeUnits.Name = "ChiRangeUnits"
        Me.ChiRangeUnits.Size = New System.Drawing.Size(33, 24)
        Me.ChiRangeUnits.TabIndex = 5
        Me.ChiRangeUnits.Text = "mm"
        Me.ChiRangeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChiValueUnits
        '
        Me.ChiValueUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChiValueUnits.Location = New System.Drawing.Point(165, 25)
        Me.ChiValueUnits.Name = "ChiValueUnits"
        Me.ChiValueUnits.Size = New System.Drawing.Size(33, 24)
        Me.ChiValueUnits.TabIndex = 3
        Me.ChiValueUnits.Text = "mm"
        Me.ChiValueUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChiRangeLabel
        '
        Me.ChiRangeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChiRangeLabel.Location = New System.Drawing.Point(214, 25)
        Me.ChiRangeLabel.Name = "ChiRangeLabel"
        Me.ChiRangeLabel.Size = New System.Drawing.Size(95, 24)
        Me.ChiRangeLabel.TabIndex = 3
        Me.ChiRangeLabel.Text = "&Range +/-"
        Me.ChiRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChiRangeValue
        '
        Me.ChiRangeValue.AccessibleDescription = "Selects the range around Chi"
        Me.ChiRangeValue.AccessibleName = "Chi Range"
        Me.ChiRangeValue.DecimalPlaces = 3
        Me.ChiRangeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChiRangeValue.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.ChiRangeValue.Location = New System.Drawing.Point(315, 26)
        Me.ChiRangeValue.Name = "ChiRangeValue"
        Me.ChiRangeValue.Size = New System.Drawing.Size(64, 23)
        Me.ChiRangeValue.TabIndex = 4
        Me.ChiRangeValue.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'ChiValueLabel
        '
        Me.ChiValueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChiValueLabel.Location = New System.Drawing.Point(11, 25)
        Me.ChiValueLabel.Name = "ChiValueLabel"
        Me.ChiValueLabel.Size = New System.Drawing.Size(80, 24)
        Me.ChiValueLabel.TabIndex = 1
        Me.ChiValueLabel.Text = "&Chi"
        Me.ChiValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChiValue
        '
        Me.ChiValue.AccessibleDescription = "Enter the base Chi value"
        Me.ChiValue.AccessibleName = "Chi"
        Me.ChiValue.DecimalPlaces = 3
        Me.ChiValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChiValue.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.ChiValue.Location = New System.Drawing.Point(96, 26)
        Me.ChiValue.Name = "ChiValue"
        Me.ChiValue.Size = New System.Drawing.Size(64, 23)
        Me.ChiValue.TabIndex = 2
        Me.ChiValue.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'ManningNBox
        '
        Me.ManningNBox.AccessibleDescription = "Selects the Chi value and range for the Goodness of Fit curves."
        Me.ManningNBox.AccessibleName = "Manning n"
        Me.ManningNBox.Controls.Add(Me.ManningRangeLabel)
        Me.ManningNBox.Controls.Add(Me.ManningRangeValue)
        Me.ManningNBox.Controls.Add(Me.ManningNLabel)
        Me.ManningNBox.Controls.Add(Me.ManningNValue)
        Me.ManningNBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManningNBox.Location = New System.Drawing.Point(8, 5)
        Me.ManningNBox.Name = "ManningNBox"
        Me.ManningNBox.Size = New System.Drawing.Size(430, 64)
        Me.ManningNBox.TabIndex = 2
        Me.ManningNBox.TabStop = False
        Me.ManningNBox.Text = "Manning n"
        '
        'ManningRangeLabel
        '
        Me.ManningRangeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManningRangeLabel.Location = New System.Drawing.Point(214, 25)
        Me.ManningRangeLabel.Name = "ManningRangeLabel"
        Me.ManningRangeLabel.Size = New System.Drawing.Size(95, 24)
        Me.ManningRangeLabel.TabIndex = 3
        Me.ManningRangeLabel.Text = "&Range +/-"
        Me.ManningRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ManningRangeValue
        '
        Me.ManningRangeValue.AccessibleDescription = "Selects the range around Manning n"
        Me.ManningRangeValue.AccessibleName = "Manning n Range"
        Me.ManningRangeValue.DecimalPlaces = 3
        Me.ManningRangeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManningRangeValue.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.ManningRangeValue.Location = New System.Drawing.Point(315, 26)
        Me.ManningRangeValue.Maximum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.ManningRangeValue.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.ManningRangeValue.Name = "ManningRangeValue"
        Me.ManningRangeValue.Size = New System.Drawing.Size(64, 23)
        Me.ManningRangeValue.TabIndex = 4
        Me.ManningRangeValue.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'ManningNLabel
        '
        Me.ManningNLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManningNLabel.Location = New System.Drawing.Point(10, 25)
        Me.ManningNLabel.Name = "ManningNLabel"
        Me.ManningNLabel.Size = New System.Drawing.Size(100, 24)
        Me.ManningNLabel.TabIndex = 1
        Me.ManningNLabel.Text = "&Manning n"
        Me.ManningNLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ManningNValue
        '
        Me.ManningNValue.AccessibleDescription = "Enter the base Manning n value"
        Me.ManningNValue.AccessibleName = "Manning n"
        Me.ManningNValue.DecimalPlaces = 3
        Me.ManningNValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ManningNValue.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.ManningNValue.Location = New System.Drawing.Point(114, 26)
        Me.ManningNValue.Maximum = New Decimal(New Integer() {4, 0, 0, 65536})
        Me.ManningNValue.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.ManningNValue.Name = "ManningNValue"
        Me.ManningNValue.Size = New System.Drawing.Size(64, 23)
        Me.ManningNValue.TabIndex = 2
        Me.ManningNValue.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'GoodnessOfFitGraph
        '
        Me.GoodnessOfFitGraph.AccessibleDescription = "A copyable bitmap image of the Roughness Goodness of Fit."
        Me.GoodnessOfFitGraph.AccessibleName = "Roughness Goodness of Fit"
        Me.GoodnessOfFitGraph.BottomTitleAdjY = 0!
        Me.GoodnessOfFitGraph.CopyDataSet = Nothing
        Me.GoodnessOfFitGraph.CurveControlIsOn = False
        Me.GoodnessOfFitGraph.DisplayKey = False
        Me.GoodnessOfFitGraph.FontAdjustment = 0!
        Me.GoodnessOfFitGraph.FontName = "Microsoft Sans Serif"
        Me.GoodnessOfFitGraph.FontSize = 10.0!
        Me.GoodnessOfFitGraph.GraphSymbols = Nothing
        Me.GoodnessOfFitGraph.HorizontalKeys = False
        Me.GoodnessOfFitGraph.HorzLines = Nothing
        Me.GoodnessOfFitGraph.LastCurve = -1
        Me.GoodnessOfFitGraph.LeftTitleAdjX = 0!
        Me.GoodnessOfFitGraph.Location = New System.Drawing.Point(3, 195)
        Me.GoodnessOfFitGraph.MaxX = 0R
        Me.GoodnessOfFitGraph.MaxY = 0R
        Me.GoodnessOfFitGraph.MinX = 0R
        Me.GoodnessOfFitGraph.MinY = 0R
        Me.GoodnessOfFitGraph.Name = "GoodnessOfFitGraph"
        Me.GoodnessOfFitGraph.NewHotspotKeys = True
        Me.GoodnessOfFitGraph.PosDirX = GraphingUI.ctl_Graph2D.PositiveDirection.PosRight
        Me.GoodnessOfFitGraph.PosDirY = GraphingUI.ctl_Graph2D.PositiveDirection.PosUp
        Me.GoodnessOfFitGraph.RightTitleAdjX = 0!
        Me.GoodnessOfFitGraph.Size = New System.Drawing.Size(448, 284)
        Me.GoodnessOfFitGraph.TabIndex = 3
        Me.GoodnessOfFitGraph.TabStop = False
        Me.GoodnessOfFitGraph.Text = "Bitmap Diagram"
        Me.GoodnessOfFitGraph.TextLines = Nothing
        Me.GoodnessOfFitGraph.TitleAdjY = 0!
        Me.GoodnessOfFitGraph.TopTitleAdjY = 0!
        Me.GoodnessOfFitGraph.UnitsX = DataStore.UnitsDefinition.Units.None
        Me.GoodnessOfFitGraph.UnitsY = DataStore.UnitsDefinition.Units.None
        Me.GoodnessOfFitGraph.VertLabels = Nothing
        Me.GoodnessOfFitGraph.VertLines = Nothing
        Me.GoodnessOfFitGraph.VLabelPos = Nothing
        '
        'InstructionsPanel
        '
        Me.InstructionsPanel.Controls.Add(Me.Instructions1)
        Me.InstructionsPanel.Controls.Add(Me.Instructions2)
        Me.InstructionsPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.InstructionsPanel.Location = New System.Drawing.Point(0, 0)
        Me.InstructionsPanel.Name = "InstructionsPanel"
        Me.InstructionsPanel.Size = New System.Drawing.Size(464, 50)
        Me.InstructionsPanel.TabIndex = 0
        '
        'Instructions1
        '
        Me.Instructions1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Instructions1.Location = New System.Drawing.Point(0, 0)
        Me.Instructions1.Name = "Instructions1"
        Me.Instructions1.Size = New System.Drawing.Size(464, 23)
        Me.Instructions1.TabIndex = 0
        Me.Instructions1.Text = "Enter test values for the roughness coefficient"
        Me.Instructions1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Instructions2
        '
        Me.Instructions2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Instructions2.Location = New System.Drawing.Point(0, 27)
        Me.Instructions2.Name = "Instructions2"
        Me.Instructions2.Size = New System.Drawing.Size(464, 23)
        Me.Instructions2.TabIndex = 1
        Me.Instructions2.Text = "Compute indicator values for each flow depth measurement station"
        Me.Instructions2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GofPanel
        '
        Me.GofPanel.Controls.Add(Me.ButtonPanel)
        Me.GofPanel.Controls.Add(Me.InstructionsPanel)
        Me.GofPanel.Controls.Add(Me.RoughnessControlPanel)
        Me.GofPanel.Controls.Add(Me.GoodnessOfFitGraph)
        Me.GofPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GofPanel.Location = New System.Drawing.Point(0, 0)
        Me.GofPanel.Name = "GofPanel"
        Me.GofPanel.Size = New System.Drawing.Size(464, 541)
        Me.GofPanel.TabIndex = 4
        '
        'ButtonPanel
        '
        Me.ButtonPanel.AccessibleDescription = "Selects the Manning n values where the Roughness Goodness of Fit is calculated."
        Me.ButtonPanel.AccessibleName = "Manning n controls"
        Me.ButtonPanel.Controls.Add(Me.ComputeButton)
        Me.ButtonPanel.Controls.Add(Me.SaveIt)
        Me.ButtonPanel.Controls.Add(Me.CancelIt)
        Me.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonPanel.Location = New System.Drawing.Point(0, 498)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(464, 43)
        Me.ButtonPanel.TabIndex = 2
        '
        'ComputeButton
        '
        Me.ComputeButton.AccessibleDescription = "Runs the simulation to generate the Goodness of Fit curves"
        Me.ComputeButton.AccessibleName = "Compute Curves"
        Me.ComputeButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ComputeButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComputeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ComputeButton.Location = New System.Drawing.Point(19, 9)
        Me.ComputeButton.Name = "ComputeButton"
        Me.ComputeButton.Size = New System.Drawing.Size(150, 24)
        Me.ComputeButton.TabIndex = 13
        Me.ComputeButton.Text = "&Compute"
        Me.ComputeButton.UseVisualStyleBackColor = False
        '
        'SaveIt
        '
        Me.SaveIt.AccessibleDescription = "Saves the selected roughness parameters and Goodness of Fit curves."
        Me.SaveIt.AccessibleName = "Save Button"
        Me.SaveIt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SaveIt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveIt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SaveIt.Location = New System.Drawing.Point(293, 9)
        Me.SaveIt.Name = "SaveIt"
        Me.SaveIt.Size = New System.Drawing.Size(72, 24)
        Me.SaveIt.TabIndex = 14
        Me.SaveIt.Text = "&Save"
        Me.SaveIt.UseVisualStyleBackColor = False
        '
        'CancelIt
        '
        Me.CancelIt.AccessibleDescription = "Closes the dialog box without saving the results."
        Me.CancelIt.AccessibleName = "Cancel Button"
        Me.CancelIt.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelIt.Location = New System.Drawing.Point(373, 9)
        Me.CancelIt.Name = "CancelIt"
        Me.CancelIt.Size = New System.Drawing.Size(72, 24)
        Me.CancelIt.TabIndex = 15
        Me.CancelIt.Text = "&Cancel"
        '
        'RoughnessGoodnessOfFit
        '
        Me.AcceptButton = Me.SaveIt
        Me.AccessibleDescription = "Generates Goodness of Fit curves to allow comparison of roughness parameter selec" &
    "tions."
        Me.AccessibleName = "Roughness Goodness of Fit"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelIt
        Me.ClientSize = New System.Drawing.Size(464, 541)
        Me.Controls.Add(Me.GofPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(470, 570)
        Me.Name = "RoughnessGoodnessOfFit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Roughness Analysis"
        Me.RoughnessControlPanel.ResumeLayout(False)
        Me.MethodBox.ResumeLayout(False)
        Me.MethodBox.PerformLayout()
        Me.ChiBox.ResumeLayout(False)
        CType(Me.ChiRangeValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChiValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ManningNBox.ResumeLayout(False)
        CType(Me.ManningRangeValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManningNValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GoodnessOfFitGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InstructionsPanel.ResumeLayout(False)
        Me.GofPanel.ResumeLayout(False)
        Me.ButtonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    ' References
    Private mWorldWindow As WorldWindow
    Private mWinSRFR As WinSRFR
    Private mUnit As Unit
    Private mEventCriteria As EventCriteria
    Private mSystemGeometry As SystemGeometry
    Private mInflowManagement As InflowManagement
    Private mSoilCropProperties As SoilCropProperties
    Private mAnalysis As Analysis
    Private mEVALUE As EVALUE

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    Private mDictionary As Dictionary = Dictionary.Instance

    ' Object data
    Private mGofAverage As Double

#End Region

#Region " Properties "

    Private mRoughnessMethod As RoughnessMethods = RoughnessMethods.ManningN
    Public Property RoughnessMethod() As RoughnessMethods
        Get
            Return mRoughnessMethod
        End Get
        Set(ByVal value As RoughnessMethods)
            mRoughnessMethod = value

            Select Case (mRoughnessMethod)
                Case RoughnessMethods.SayreAlbertson
                    Me.ManningNBox.Hide()
                    Me.ChiBox.Show()
                Case Else ' Assume Manning n
                    Me.ChiBox.Hide()
                    Me.ManningNBox.Show()
            End Select
        End Set
    End Property

    Private mGoodnessOfFitMethod As GoodnessOfFitMethods = GoodnessOfFitMethods.NashSutcliffeE
    Public Property GoodnessOfFitMethod() As GoodnessOfFitMethods
        Get
            If (Me.NseButton.Checked) Then
                mGoodnessOfFitMethod = GoodnessOfFitMethods.NashSutcliffeE
            Else
                mGoodnessOfFitMethod = GoodnessOfFitMethods.PercentBias
            End If
            Return mGoodnessOfFitMethod
        End Get
        Set(ByVal value As Globals.GoodnessOfFitMethods)
            mGoodnessOfFitMethod = value
            If (mGoodnessOfFitMethod = GoodnessOfFitMethods.NashSutcliffeE) Then
                Me.NseButton.Checked = True
            Else
                Me.PbiasButton.Checked = True
            End If
        End Set
    End Property

    Private mNseCurves As DataTable = Nothing
    Public ReadOnly Property NseCurves() As DataTable
        Get
            Return mNseCurves
        End Get
    End Property

    Private mPbiasCurves As DataTable = Nothing
    Public ReadOnly Property PbiasCurves() As DataTable
        Get
            Return mPbiasCurves
        End Get
    End Property

    Private mManningN As Double = Srfr.Globals.Ndef
    Public Property ManningN() As Double
        Get
            mManningN = CDbl(Me.ManningNValue.Value)
            Return mManningN
        End Get
        Set(ByVal value As Double)
            mManningN = value
            Me.ManningNValue.Value = CDec(mManningN)
            Me.ManningNValue.Maximum = mWinSRFR.Nmax
            Me.ManningNValue.Minimum = mWinSRFR.Nmin
            Me.ManningNValue.DecimalPlaces = 3
            Me.ManningNValue.Increment = Srfr.Globals.Ninc

            Me.ManningRangeValue.DecimalPlaces = Me.ManningNValue.DecimalPlaces
            Me.ManningRangeValue.Increment = Me.ManningNValue.Increment
            Me.ManningRangeValue.Value = Me.ManningNValue.Increment
            Me.ManningRangeValue.Maximum = Me.ManningNValue.Increment * 100
            Me.ManningRangeValue.Minimum = Me.ManningNValue.Increment
        End Set
    End Property

    Private mManningNRange As Double = Srfr.Globals.Ninc
    Public Property ManningNRange() As Double
        Get
            mManningNRange = CDbl(Me.ManningRangeValue.Value)
            Return mManningNRange
        End Get
        Set(ByVal value As Double)
            If (value < Me.ManningRangeValue.Minimum) Then
                value = Me.ManningRangeValue.Minimum
            End If
            If (value > Me.ManningRangeValue.Maximum) Then
                value = Me.ManningRangeValue.Maximum
            End If
            mManningNRange = value
            Me.ManningRangeValue.Value = CDec(mManningNRange)
        End Set
    End Property

    Private mChi As Double = Srfr.Globals.ChiDef
    Public Property Chi() As Double
        Get
            Dim chiUnits As Units = mUnitsSystem.DepthUnits

            mChi = SiValue(CDbl(Me.ChiValue.Value), chiUnits)

            If (mChi < mWinSRFR.ChiMin * 1.001) Then
                mChi = mWinSRFR.ChiMin
            End If
            If (mChi > mWinSRFR.ChiMax * 0.999) Then
                mChi = mWinSRFR.ChiMax
            End If

            Return mChi
        End Get
        Set(ByVal value As Double)
            Dim chiUnits As Units = mUnitsSystem.DepthUnits
            Dim chiUnitsText As String = UnitsText(chiUnits)

            mChi = value

            If (mChi < mWinSRFR.ChiMin * 1.001) Then
                mChi = mWinSRFR.ChiMin
            End If
            If (mChi > mWinSRFR.ChiMax * 0.999) Then
                mChi = mWinSRFR.ChiMax
            End If

            Me.ChiValue.Value = UnitValue(CDec(mChi), chiUnits)
            Me.ChiValue.Maximum = UnitValue(mWinSRFR.ChiMax, chiUnits)
            Me.ChiValue.Minimum = UnitValue(mWinSRFR.ChiMin, chiUnits)

            Me.ChiValueUnits.Text = chiUnitsText
            Me.ChiRangeUnits.Text = chiUnitsText

            Select Case (chiUnits)
                Case Units.Millimeters
                    Me.ChiValue.DecimalPlaces = 0
                    Me.ChiValue.Increment = 1.0
                Case Units.Centimeters
                    Me.ChiValue.DecimalPlaces = 1
                    Me.ChiValue.Increment = 0.1
                Case Units.Meters
                    Me.ChiValue.DecimalPlaces = 3
                    Me.ChiValue.Increment = 0.001
                Case Units.Inches
                    Me.ChiValue.DecimalPlaces = 2
                    Me.ChiValue.Increment = 0.01
                Case Units.Feet
                    Me.ChiValue.DecimalPlaces = 2
                    Me.ChiValue.Increment = 0.01
                Case Else
                    Debug.Assert(False)
            End Select

            Me.ChiRangeValue.DecimalPlaces = Me.ChiValue.DecimalPlaces
            Me.ChiRangeValue.Increment = Me.ChiValue.Increment
            Me.ChiRangeValue.Value = Me.ChiValue.Increment
            Me.ChiRangeValue.Maximum = Me.ChiValue.Increment * 100
            Me.ChiRangeValue.Minimum = Me.ChiValue.Increment

        End Set
    End Property

    Private mChiRange As Double = Srfr.ChiMin / 2.0
    Public Property ChiRange() As Double
        Get
            Dim chiUnits As Units = mUnitsSystem.DepthUnits

            mChiRange = SiValue(CDbl(Me.ChiRangeValue.Value), chiUnits)
            Return mChiRange
        End Get
        Set(ByVal value As Double)
            Dim chiUnits As Units = mUnitsSystem.DepthUnits

            If (value < SiValue(CDbl(Me.ChiRangeValue.Minimum), chiUnits)) Then
                value = SiValue(CDbl(Me.ChiRangeValue.Minimum), chiUnits)
            End If
            If (value > SiValue(CDbl(Me.ChiRangeValue.Maximum), chiUnits)) Then
                value = SiValue(CDbl(Me.ChiRangeValue.Maximum), chiUnits)
            End If
            mChiRange = value
            Me.ChiRangeValue.Value = UnitValue(mChiRange, chiUnits)
        End Set
    End Property

#End Region

#Region " Methods "

    '*********************************************************************************************************
    ' Sub UpdateGoodnessOfFitTable() - Update the Goodness of Fit table using selected method
    '
    ' Input(s):     GofTable    - Goodness-of-Fit table
    '               GofMethod   -     "     "  "  method (NSE | PBIAS)
    '               SimNumber   - the number (i.e. index) of the Simulation run
    '*********************************************************************************************************
    Private Sub UpdateGoodnessOfFitTable(ByVal GofTable As DataTable, ByVal GofMethod As GoodnessOfFitMethods,
                                         ByVal SimNumber As Integer)
        '
        ' Get/validate the data required for Goodness of Fit calculations
        '
        Dim StationsTable As DataTable = mInflowManagement.MeasurementStations.Value
        Dim stationCount As Integer = StationsTable.Rows.Count

        ' Get the user-entered Station Flow Depth Hydrographs
        Dim usrFlowDepthSet As DataSet = mInflowManagement.StationsFlowDepths.Value
        Dim usrFlowDepthCount As Integer = usrFlowDepthSet.Tables.Count
        If Not (usrFlowDepthCount = stationCount) Then
            Debug.Assert(False)
            Return
        End If

        ' Get the corresponding simulation Flow Depth Hydrographs
        Dim srfrIrrigation As Srfr.Irrigation = mWorldWindow.SrfrAPI.Irrigation

        Dim simFlowDepthSet As DataSet = New DataSet
        mEventCriteria.ResetSimFlowDepthsRoughness(simFlowDepthSet)

        ' Get one simulation Flow Depth Hydrograph for every Station
        For sdx As Integer = 0 To stationCount - 1

            ' Get Station's location
            Dim advRow As DataRow = StationsTable.Rows(sdx)
            Dim staDist As Double = advRow.Item(sDistanceX)
            Dim tableName As String = "Y @ " & LengthString(staDist)

            ' Get/save matching Flow Depth Hydrograph for Simulation
            Dim simHydro As DataTable = srfrIrrigation.Hydrographs("Y", staDist)
            simHydro.TableName = tableName

            simFlowDepthSet.Tables.Add(simHydro)

        Next sdx
        '
        ' Update Goodness-Of-Fit table of Flow Depth Hydrograph comparisons
        '
        Dim gofCount As Integer = GofTable.Rows.Count

        ' Check if goodness-of-fit table was reset
        Dim gofReset As Boolean = False
        If (0 = gofCount) Then ' table was reset
            gofReset = True
        Else ' not reset; validate size
            If Not (gofCount = stationCount) Then
                Debug.Assert(False)
                Return
            End If
        End If

        ' Validate that simulation exists for column
        If (GofTable.Columns.Count <= SimNumber) Then
            Debug.Assert(False)
            Return
        End If
        '
        ' One goodness-of-fit value for every Station
        '
        mGofAverage = 0.0

        For sdx As Integer = 0 To stationCount - 1

            ' Get Station's location
            Dim staRow As DataRow = StationsTable.Rows(sdx)
            Dim staDist As Double = staRow.Item(sDistanceX)

            ' Get Flow Depth Hydrograph for Station
            Dim staHydro As DataTable = usrFlowDepthSet.Tables(sdx)
            Dim staTimes As ArrayList = GetDataColumn(staHydro, 0)              ' Times
            Dim staDepths As ArrayList = GetDataColumn(staHydro, 1)             ' Flow Depths

            ' Get matching Flow Depth Hydrograph for Simulation (times must match)
            Dim simHydro As DataTable = simFlowDepthSet.Tables(sdx)
            Dim simDepths As ArrayList = DoubleColumnByTimes(simHydro, nTimeX, staTimes, 1)

            Dim goodnessOfFit As Double = 0.0

            ' Use selected update method
            Select Case (GofMethod)

                Case GoodnessOfFitMethods.IndexOfAgreementD ' d

                    Dim _mse As Double = MSE(staDepths, simDepths)
                    Dim _pe As Double = PE(staDepths, simDepths)
                    Dim _n As Integer = simDepths.Count
                    Dim _d As Double = 1.0 - _n * _mse / _pe

                    goodnessOfFit = _d

                Case GoodnessOfFitMethods.PercentBias ' PBIAS

                    Dim _pbias As Double = PBIAS(staDepths, simDepths)

                    goodnessOfFit = _pbias

                Case GoodnessOfFitMethods.RMSEstandardRatio ' RSR

                    Dim _rmse As Double = RMSE(staDepths, simDepths)
                    Dim _stdev As Double = STDEV(staDepths)
                    Dim _rsr As Double = _rmse / _stdev

                    goodnessOfFit = _rsr

                Case Else ' Assume GoodnessOfFitMethods.NashSutcliffeE ' NSE

                    Dim _sumxmy2 As Double = SUMXMY2(staDepths, simDepths)
                    Dim _devsq As Double = DEVSQ(staDepths)
                    Dim _nse As Double = 1 - (_sumxmy2 / _devsq)

                    goodnessOfFit = _nse
            End Select

            ' Sum goodness-of-fit values for average calculation
            mGofAverage += goodnessOfFit

            ' Save goodness of fit in specified Simulation's column
            If (gofReset) Then ' generate new DataRow
                Dim gofRow As DataRow = GofTable.NewRow
                gofRow.Item(0) = staDist
                gofRow.Item(SimNumber) = goodnessOfFit
                GofTable.Rows.Add(gofRow)
            Else ' use existing DataRow
                Dim gofRow As DataRow = GofTable.Rows(sdx)
                gofRow.Item(SimNumber) = goodnessOfFit
            End If

        Next sdx

        ' Compute average goodness-of-fit
        mGofAverage /= stationCount

        Me.BringToFront()

    End Sub

#End Region

#Region " Initialization "
    '
    ' Initialize the Roughness Goodness of Fit
    '
    Private Sub InitRoughnessGoodnessOfFit(ByVal worldWindow As WorldWindow)
        ' Save the input arguments
        mWorldWindow = worldWindow

        ' Get references to current Unit & Analysis
        If (mWorldWindow IsNot Nothing) Then
            mUnit = mWorldWindow.DisplayedUnit
            If (mUnit IsNot Nothing) Then
                mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef
                mEventCriteria = mUnit.EventCriteriaRef
                mSystemGeometry = mUnit.SystemGeometryRef
                mInflowManagement = mUnit.InflowManagementRef
                mSoilCropProperties = mUnit.SoilCropPropertiesRef
            Else
                Return
            End If

            mAnalysis = mWorldWindow.CurrentAnalysis
            If (mAnalysis.GetType Is GetType(EVALUE)) Then
                mEVALUE = DirectCast(mAnalysis, EVALUE)
            End If
        End If

        ' Disable the Save button
        Me.SaveIt.Enabled = False

    End Sub

#End Region

#Region " Update Graphics "

    Private Sub UpdateGraphics()

        Try ' catch, but ignore exceptions drawing graphs

            Dim gofTable As DataTable = Nothing

            If (Me.NseButton.Checked) Then ' graph NSE curves
                gofTable = mNseCurves.Copy
                gofTable.ExtendedProperties.Add("LeftAxisTitle", "NSE")
            Else ' graph PBIAS curves
                gofTable = mPbiasCurves.Copy
                gofTable.ExtendedProperties.Add("LeftAxisTitle", "PBIAS (%)")
            End If

            ' Set curve drawing properties
            gofTable.ExtendedProperties.Add("Symbol", "O")
            gofTable.ExtendedProperties.Add("Fill O", True)
            gofTable.ExtendedProperties.Add("Line", True)

            ' Remove undefined columns; setup Keys for defined ones
            Dim gofRow As DataRow = gofTable.Rows(0)
            Dim colName As String

            If (gofRow.Item(3).GetType Is GetType(DBNull)) Then
                gofTable.Columns.RemoveAt(3)
            Else
                colName = gofTable.Columns(3).ColumnName
                gofTable.Columns(3).ExtendedProperties.Add("Key", True)
                gofTable.Columns(3).ExtendedProperties.Add("Key Text", colName)
                gofTable.Columns(3).ExtendedProperties.Add("Symbol", "O")
                gofTable.Columns(3).ExtendedProperties.Add("Line", True)
            End If

            If (gofRow.Item(2).GetType Is GetType(DBNull)) Then
                gofTable.Columns.RemoveAt(2)
            Else
                colName = gofTable.Columns(2).ColumnName
                gofTable.Columns(2).ExtendedProperties.Add("Key", True)
                gofTable.Columns(2).ExtendedProperties.Add("Key Text", colName)
                gofTable.Columns(2).ExtendedProperties.Add("Symbol", "O")
                gofTable.Columns(2).ExtendedProperties.Add("Line", True)
            End If

            If (gofRow.Item(1).GetType Is GetType(DBNull)) Then
                gofTable.Columns.RemoveAt(1)
            Else
                colName = gofTable.Columns(1).ColumnName
                gofTable.Columns(1).ExtendedProperties.Add("Key", True)
                gofTable.Columns(1).ExtendedProperties.Add("Key Text", colName)
                gofTable.Columns(1).ExtendedProperties.Add("Symbol", "O")
                gofTable.Columns(1).ExtendedProperties.Add("Line", True)
            End If

            ' Graph requires DataSet not DataTable
            Dim gofDataSet As DataSet = New DataSet(gofTable.TableName)
            gofDataSet.Tables.Add(gofTable)

            Me.GoodnessOfFitGraph.NewHotspotKeys = True
            Me.GoodnessOfFitGraph.InitializeGraph2D(gofDataSet)
            Me.GoodnessOfFitGraph.UnitsX = Units.Meters
            Me.GoodnessOfFitGraph.UnitsY = Units.None
            Me.GoodnessOfFitGraph.Name = mDictionary.tGoodnessOfFit.Translated
            Me.GoodnessOfFitGraph.DisplayKey = True
            Me.GoodnessOfFitGraph.HorizontalKeys = True
            Me.GoodnessOfFitGraph.ClearVertLines()
            Me.GoodnessOfFitGraph.DrawImage()

            Me.BringToFront()

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " UI Event Handler(s) "

    Private Sub NseButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NseButton.CheckedChanged
        If (NseButton.Checked) Then ' NSE button checked; update graphics
            UpdateGraphics()
        End If
    End Sub

    Private Sub PbiasButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PbiasButton.CheckedChanged
        If (PbiasButton.Checked) Then ' PBIAS button checked; update graphics
            UpdateGraphics()
        End If
    End Sub

    Private Sub ChiValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ChiValue.ValueChanged
        Me.SaveIt.Enabled = False
    End Sub

    Private Sub ManningNValue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ManningNValue.ValueChanged
        Me.SaveIt.Enabled = False
    End Sub

    Private Sub ComputeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ComputeButton.Click
        If (mEVALUE IsNot Nothing) Then

            ' Initialize goodness-of-fit curves
            mPbiasCurves = New DataTable
            mPbiasCurves.TableName = GoodnessOfFitMethodSelections(GoodnessOfFitMethods.PercentBias).Value
            mPbiasCurves.Columns.Add("Station (m)", GetType(Double))
            mPbiasCurves.Columns.Add("Sim 1", GetType(Double))
            mPbiasCurves.Columns.Add("Sim 2", GetType(Double))
            mPbiasCurves.Columns.Add("Sim 3", GetType(Double))

            mNseCurves = New DataTable
            mNseCurves.TableName = GoodnessOfFitMethodSelections(GoodnessOfFitMethods.NashSutcliffeE).Value
            mNseCurves.Columns.Add("Station (m)", GetType(Double))
            mNseCurves.Columns.Add("Sim 1", GetType(Double))
            mNseCurves.Columns.Add("Sim 2", GetType(Double))
            mNseCurves.Columns.Add("Sim 3", GetType(Double))

            ' Run Simulation once for each column in table
            Dim colName As String = ""

            Select Case (mSoilCropProperties.RoughnessMethod.Value)
                Case RoughnessMethods.SayreAlbertson
                    mEVALUE.AdjustManningN = False
                    mEVALUE.AdjustSayreAlbertsonChi = True

                    ' Lower-end of range first
                    mEVALUE.SayreAlbertsonChi = Me.Chi - Me.ChiRange
                    If (mEVALUE.SayreAlbertsonChi = mWinSRFR.ChiMin) Then
                        Dim title As String = mDictionary.tSayreChi.Translated
                        Dim msg As String = mDictionary.tMinLimitSayreChi.Translated & Chr(10) & Chr(10)
                        msg &= mDictionary.tMinimum.Translated & " = " & DepthString(mWinSRFR.ChiMin)
                        MsgBox(msg, MsgBoxStyle.Exclamation, title)
                    End If
                    mEVALUE.RunSimulation()

                    Me.UpdateGoodnessOfFitTable(mNseCurves, GoodnessOfFitMethods.NashSutcliffeE, 1)
                    colName = "Chi=" & DepthString(mEVALUE.SayreAlbertsonChi)
                    colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                    mNseCurves.Columns(1).ColumnName = colName

                    Me.UpdateGoodnessOfFitTable(mPbiasCurves, GoodnessOfFitMethods.PercentBias, 1)
                    colName = "Chi=" & DepthString(mEVALUE.SayreAlbertsonChi)
                    colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                    mPbiasCurves.Columns(1).ColumnName = colName

                    Me.UpdateGraphics()

                    ' Upper-end of range next
                    mEVALUE.SayreAlbertsonChi = Me.Chi + Me.ChiRange
                    If (mEVALUE.SayreAlbertsonChi = mWinSRFR.ChiMax) Then
                        Dim title As String = mDictionary.tSayreChi.Translated
                        Dim msg As String = mDictionary.tMaxLimitSayreChi.Translated & Chr(10) & Chr(10)
                        msg &= mDictionary.tMaximum.Translated & " = " & DepthString(mWinSRFR.ChiMax)
                        MsgBox(msg, MsgBoxStyle.Exclamation, title)
                    End If
                    mEVALUE.RunSimulation()

                    Me.UpdateGoodnessOfFitTable(mNseCurves, GoodnessOfFitMethods.NashSutcliffeE, 3)
                    colName = "Chi=" & DepthString(mEVALUE.SayreAlbertsonChi)
                    colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                    mNseCurves.Columns(3).ColumnName = colName

                    Me.UpdateGoodnessOfFitTable(mPbiasCurves, GoodnessOfFitMethods.PercentBias, 3)
                    colName = "Chi=" & DepthString(mEVALUE.SayreAlbertsonChi)
                    colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                    mPbiasCurves.Columns(3).ColumnName = colName

                    Me.UpdateGraphics()

                    ' Middle of range last; if not already run
                    If ((mWinSRFR.ChiMin < Me.Chi) And (Me.Chi < mWinSRFR.ChiMax)) Then
                        mEVALUE.SayreAlbertsonChi = Me.Chi
                        mEVALUE.RunSimulation()

                        Me.UpdateGoodnessOfFitTable(mNseCurves, GoodnessOfFitMethods.NashSutcliffeE, 2)
                        colName = "Chi=" & DepthString(mEVALUE.SayreAlbertsonChi)
                        colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                        mNseCurves.Columns(2).ColumnName = colName

                        Me.UpdateGoodnessOfFitTable(mPbiasCurves, GoodnessOfFitMethods.PercentBias, 2)
                        colName = "Chi=" & DepthString(mEVALUE.SayreAlbertsonChi)
                        colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                        mPbiasCurves.Columns(2).ColumnName = colName

                        Me.UpdateGraphics()
                    End If

                Case Else ' Assume Manning n
                    mEVALUE.AdjustSayreAlbertsonChi = False
                    mEVALUE.AdjustManningN = True

                    ' Lower-end of range first
                    mEVALUE.ManningN = Me.ManningN - Me.ManningNRange
                    If (mEVALUE.ManningN = mWinSRFR.Nmin) Then
                        Dim title As String = mDictionary.tManningN.Translated
                        Dim msg As String = mDictionary.tMinLimitManningN.Translated & Chr(10) & Chr(10)
                        msg &= mDictionary.tMinimum.Translated & " = " & mWinSRFR.Nmin.ToString
                        MsgBox(msg, MsgBoxStyle.Exclamation, title)
                    End If
                    mEVALUE.RunSimulation()

                    Me.UpdateGoodnessOfFitTable(mNseCurves, GoodnessOfFitMethods.NashSutcliffeE, 1)
                    colName = "n=" & Format(mEVALUE.ManningN, "0.0##")
                    colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                    mNseCurves.Columns(1).ColumnName = colName

                    Me.UpdateGoodnessOfFitTable(mPbiasCurves, GoodnessOfFitMethods.PercentBias, 1)
                    colName = "n=" & Format(mEVALUE.ManningN, "0.0##")
                    colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                    mPbiasCurves.Columns(1).ColumnName = colName

                    Me.UpdateGraphics()

                    ' Upper-end of range next
                    mEVALUE.ManningN = Me.ManningN + Me.ManningNRange
                    If (mEVALUE.ManningN = mWinSRFR.Nmax) Then
                        Dim title As String = mDictionary.tManningN.Translated
                        Dim msg As String = mDictionary.tMaxLimitManningN.Translated & Chr(10) & Chr(10)
                        msg &= mDictionary.tMaximum.Translated & " = " & mWinSRFR.Nmax.ToString
                        MsgBox(msg, MsgBoxStyle.Exclamation, title)
                    End If
                    mEVALUE.RunSimulation()

                    Me.UpdateGoodnessOfFitTable(mNseCurves, GoodnessOfFitMethods.NashSutcliffeE, 3)
                    colName = "n=" & Format(mEVALUE.ManningN, "0.0##")
                    colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                    mNseCurves.Columns(3).ColumnName = colName

                    Me.UpdateGoodnessOfFitTable(mPbiasCurves, GoodnessOfFitMethods.PercentBias, 3)
                    colName = "n=" & Format(mEVALUE.ManningN, "0.0##")
                    colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                    mPbiasCurves.Columns(3).ColumnName = colName

                    Me.UpdateGraphics()

                    ' Middle of range last; if not already run
                    If ((mWinSRFR.Nmin < Me.ManningN) And (Me.ManningN < mWinSRFR.Nmax)) Then
                        mEVALUE.ManningN = Me.ManningN
                        mEVALUE.RunSimulation()

                        Me.UpdateGoodnessOfFitTable(mNseCurves, GoodnessOfFitMethods.NashSutcliffeE, 2)
                        colName = "n=" & Format(mEVALUE.ManningN, "0.0##")
                        colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                        mNseCurves.Columns(2).ColumnName = colName

                        Me.UpdateGoodnessOfFitTable(mPbiasCurves, GoodnessOfFitMethods.PercentBias, 2)
                        colName = "n=" & Format(mEVALUE.ManningN, "0.0##")
                        colName &= ", Avg= " & Format(mGofAverage, "0.0#")
                        mPbiasCurves.Columns(2).ColumnName = colName

                        Me.UpdateGraphics()
                    End If
            End Select

            mEVALUE.AdjustManningN = False
            mEVALUE.AdjustSayreAlbertsonChi = False

            Me.SaveIt.Enabled = True

        End If
    End Sub

    Private Sub CancelIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CancelIt.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SaveIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles SaveIt.Click
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub RoughnessGoodnessOfFit_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:EvalueAnalysis", 3300)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:EvalueAnalysis", 3300)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub RoughnessGoodnessOfFit_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        Dim dbWidth As Single = GofPanel.Width
        Dim dbHeight As Single = GofPanel.Height

        ' Center controls below instructions
        Me.RoughnessControlPanel.Width = dbWidth - Me.Margin.Horizontal

        ' Graph is below controls
        Me.GoodnessOfFitGraph.Width = dbWidth - Me.Margin.Horizontal
        Me.GoodnessOfFitGraph.Height = dbHeight - Me.InstructionsPanel.Height _
            - Me.RoughnessControlPanel.Height - Me.ButtonPanel.Height

        Me.UpdateGraphics()
    End Sub

    Private Sub RoughnessGoodnessOfFit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        Me.BringToFront()
    End Sub

#End Region

End Class
