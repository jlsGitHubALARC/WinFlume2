
'*************************************************************************************************************
' ctl_OperationsExecution - Operations World's Execution Tab UI
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_OperationsExecution
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents RunControlBox As DataStore.ctl_GroupBox
    Friend WithEvents SolutionModelBox As DataStore.ctl_GroupBox
    Friend WithEvents CellDensityLabel As DataStore.ctl_Label
    Friend WithEvents CellDensityControl As DataStore.ctl_IntegerParameter
    Friend WithEvents SolutionModelControl As DataStore.ctl_SelectParameter
    Friend WithEvents ExecutionErrorsWarnings As WinMain.ErrorRichTextBox
    Friend WithEvents NoErrorsWarningsLabel As DataStore.ctl_Label
    Friend WithEvents ErrorsWarningsLabel As DataStore.ctl_Label
    Friend WithEvents RunOperationsButton As DataStore.ctl_Button
    Friend WithEvents ExecutionBox As DataStore.ctl_GroupBox
    Friend WithEvents TuningFactorsBox As DataStore.ctl_GroupBox
    Friend WithEvents Phi3Label As System.Windows.Forms.Label
    Friend WithEvents Phi3Control As DataStore.ctl_DoubleParameter
    Friend WithEvents EstimationPointLabel As DataStore.ctl_Label
    Friend WithEvents ContourInflowRatePointControl As DataStore.ctl_DoubleParameter
    Friend WithEvents Phi0Label As System.Windows.Forms.Label
    Friend WithEvents Phi0Control As DataStore.ctl_DoubleParameter
    Friend WithEvents EstimateTuningFactorsButton As DataStore.ctl_Button
    Friend WithEvents Phi2Label As System.Windows.Forms.Label
    Friend WithEvents Phi1Label As System.Windows.Forms.Label
    Friend WithEvents SigmaYControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SigmaYLabel As System.Windows.Forms.Label
    Friend WithEvents Phi2Control As DataStore.ctl_DoubleParameter
    Friend WithEvents Phi1Control As DataStore.ctl_DoubleParameter
    Friend WithEvents ContourCutoffTimePointControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ContourRangesBox As DataStore.ctl_GroupBox
    Friend WithEvents AddContourOverlays As DataStore.ctl_Button
    Friend WithEvents ShowMinorContours As DataStore.ctl_CheckParameter
    Friend WithEvents PrecisionContoursOption As DataStore.ctl_RadioButton
    Friend WithEvents StandardContoursOption As DataStore.ctl_RadioButton
    Friend WithEvents ContourGridSizeControl As DataStore.ctl_SelectParameter
    Friend WithEvents ContourGridSizeLabel As DataStore.ctl_Label
    Friend WithEvents InflowRateRangePanel As DataStore.ctl_Panel
    Friend WithEvents InflowRateToLabel As DataStore.ctl_Label
    Friend WithEvents InflowRateLabel As DataStore.ctl_Label
    Friend WithEvents MaxInflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MinInflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffTimeRangePanel As DataStore.ctl_Panel
    Friend WithEvents MaxCutoffTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffTimeToLabel As DataStore.ctl_Label
    Friend WithEvents MinCutoffTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffTimeLabel As DataStore.ctl_Label
    Friend WithEvents CutoffDistanceRangePanel As DataStore.ctl_Panel
    Friend WithEvents MaxCutoffdistanceControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MinCutoffDistanceControl As DataStore.ctl_DoubleParameter
    Friend WithEvents CutoffDistanceLabel As DataStore.ctl_Label
    Friend WithEvents OperationsParametersBox As DataStore.ctl_GroupBox
    Friend WithEvents RequiredDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RequiredDepthLabel As DataStore.ctl_Label
    Friend WithEvents ReflectsLabel As DataStore.ctl_Label
    Friend WithEvents DepthCriteriaControl As DataStore.ctl_SelectParameter
    Friend WithEvents DepthCriteriaExLabel As DataStore.ctl_Label
    Friend WithEvents EnableDiagnosticsControl As DataStore.ctl_CheckParameter
    Friend WithEvents BorderOperationsPanel As DataStore.ctl_Panel
    Friend WithEvents FurrowOperationsPanel As DataStore.ctl_Panel
    Friend WithEvents FurrowsPerSetOption As DataStore.ctl_RadioButton
    Friend WithEvents FurrowSetInflowRateOption As DataStore.ctl_RadioButton
    Friend WithEvents FurrowsPerSetRangePanel As DataStore.ctl_Panel
    Friend WithEvents FurrowsPerSetToLabel As DataStore.ctl_Label
    Friend WithEvents MaxFurrowsPerSetControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MinFurrowsPerSetControl As DataStore.ctl_DoubleParameter
    Friend WithEvents FurrowsPerSetLabel As DataStore.ctl_Label
    Friend WithEvents ContourFurrowsPerSetPointControl As DataStore.ctl_DoubleParameter
    Friend WithEvents rLabel As System.Windows.Forms.Label
    Friend WithEvents rControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ResetPointButton As DataStore.ctl_Button
    Friend WithEvents SrfrSimulations As ctl_RadioButton
    Friend WithEvents VolumeBalanceCalculations As ctl_RadioButton
    Friend WithEvents CutoffDistanceToLabel As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RunControlBox = New DataStore.ctl_GroupBox()
        Me.SrfrSimulations = New DataStore.ctl_RadioButton()
        Me.VolumeBalanceCalculations = New DataStore.ctl_RadioButton()
        Me.SolutionModelBox = New DataStore.ctl_GroupBox()
        Me.EnableDiagnosticsControl = New DataStore.ctl_CheckParameter()
        Me.CellDensityLabel = New DataStore.ctl_Label()
        Me.CellDensityControl = New DataStore.ctl_IntegerParameter()
        Me.SolutionModelControl = New DataStore.ctl_SelectParameter()
        Me.ExecutionErrorsWarnings = New WinMain.ErrorRichTextBox()
        Me.NoErrorsWarningsLabel = New DataStore.ctl_Label()
        Me.ErrorsWarningsLabel = New DataStore.ctl_Label()
        Me.RunOperationsButton = New DataStore.ctl_Button()
        Me.ExecutionBox = New DataStore.ctl_GroupBox()
        Me.TuningFactorsBox = New DataStore.ctl_GroupBox()
        Me.ResetPointButton = New DataStore.ctl_Button()
        Me.rLabel = New System.Windows.Forms.Label()
        Me.rControl = New DataStore.ctl_DoubleParameter()
        Me.Phi3Label = New System.Windows.Forms.Label()
        Me.Phi3Control = New DataStore.ctl_DoubleParameter()
        Me.EstimationPointLabel = New DataStore.ctl_Label()
        Me.Phi0Label = New System.Windows.Forms.Label()
        Me.Phi0Control = New DataStore.ctl_DoubleParameter()
        Me.EstimateTuningFactorsButton = New DataStore.ctl_Button()
        Me.Phi2Label = New System.Windows.Forms.Label()
        Me.Phi1Label = New System.Windows.Forms.Label()
        Me.SigmaYControl = New DataStore.ctl_DoubleParameter()
        Me.SigmaYLabel = New System.Windows.Forms.Label()
        Me.Phi2Control = New DataStore.ctl_DoubleParameter()
        Me.Phi1Control = New DataStore.ctl_DoubleParameter()
        Me.ContourCutoffTimePointControl = New DataStore.ctl_DoubleParameter()
        Me.ContourInflowRatePointControl = New DataStore.ctl_DoubleParameter()
        Me.ContourFurrowsPerSetPointControl = New DataStore.ctl_DoubleParameter()
        Me.ContourRangesBox = New DataStore.ctl_GroupBox()
        Me.AddContourOverlays = New DataStore.ctl_Button()
        Me.ShowMinorContours = New DataStore.ctl_CheckParameter()
        Me.PrecisionContoursOption = New DataStore.ctl_RadioButton()
        Me.StandardContoursOption = New DataStore.ctl_RadioButton()
        Me.ContourGridSizeControl = New DataStore.ctl_SelectParameter()
        Me.ContourGridSizeLabel = New DataStore.ctl_Label()
        Me.CutoffTimeRangePanel = New DataStore.ctl_Panel()
        Me.MaxCutoffTimeControl = New DataStore.ctl_DoubleParameter()
        Me.CutoffTimeToLabel = New DataStore.ctl_Label()
        Me.MinCutoffTimeControl = New DataStore.ctl_DoubleParameter()
        Me.CutoffTimeLabel = New DataStore.ctl_Label()
        Me.CutoffDistanceRangePanel = New DataStore.ctl_Panel()
        Me.MaxCutoffdistanceControl = New DataStore.ctl_DoubleParameter()
        Me.CutoffDistanceToLabel = New DataStore.ctl_Label()
        Me.MinCutoffDistanceControl = New DataStore.ctl_DoubleParameter()
        Me.CutoffDistanceLabel = New DataStore.ctl_Label()
        Me.FurrowsPerSetRangePanel = New DataStore.ctl_Panel()
        Me.FurrowsPerSetToLabel = New DataStore.ctl_Label()
        Me.MaxFurrowsPerSetControl = New DataStore.ctl_DoubleParameter()
        Me.MinFurrowsPerSetControl = New DataStore.ctl_DoubleParameter()
        Me.FurrowsPerSetLabel = New DataStore.ctl_Label()
        Me.InflowRateRangePanel = New DataStore.ctl_Panel()
        Me.InflowRateToLabel = New DataStore.ctl_Label()
        Me.InflowRateLabel = New DataStore.ctl_Label()
        Me.MaxInflowRateControl = New DataStore.ctl_DoubleParameter()
        Me.MinInflowRateControl = New DataStore.ctl_DoubleParameter()
        Me.OperationsParametersBox = New DataStore.ctl_GroupBox()
        Me.RequiredDepthControl = New DataStore.ctl_DoubleParameter()
        Me.RequiredDepthLabel = New DataStore.ctl_Label()
        Me.ReflectsLabel = New DataStore.ctl_Label()
        Me.DepthCriteriaControl = New DataStore.ctl_SelectParameter()
        Me.DepthCriteriaExLabel = New DataStore.ctl_Label()
        Me.FurrowOperationsPanel = New DataStore.ctl_Panel()
        Me.FurrowSetInflowRateOption = New DataStore.ctl_RadioButton()
        Me.FurrowsPerSetOption = New DataStore.ctl_RadioButton()
        Me.BorderOperationsPanel = New DataStore.ctl_Panel()
        Me.RunControlBox.SuspendLayout()
        Me.SolutionModelBox.SuspendLayout()
        Me.ExecutionBox.SuspendLayout()
        Me.TuningFactorsBox.SuspendLayout()
        Me.ContourRangesBox.SuspendLayout()
        Me.CutoffTimeRangePanel.SuspendLayout()
        Me.CutoffDistanceRangePanel.SuspendLayout()
        Me.FurrowsPerSetRangePanel.SuspendLayout()
        Me.InflowRateRangePanel.SuspendLayout()
        Me.OperationsParametersBox.SuspendLayout()
        Me.FurrowOperationsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RunControlBox
        '
        Me.RunControlBox.AccessibleDescription = "Provides the Run Button and Status"
        Me.RunControlBox.AccessibleName = "Run Control"
        Me.RunControlBox.Controls.Add(Me.SrfrSimulations)
        Me.RunControlBox.Controls.Add(Me.VolumeBalanceCalculations)
        Me.RunControlBox.Controls.Add(Me.SolutionModelBox)
        Me.RunControlBox.Controls.Add(Me.ExecutionErrorsWarnings)
        Me.RunControlBox.Controls.Add(Me.NoErrorsWarningsLabel)
        Me.RunControlBox.Controls.Add(Me.ErrorsWarningsLabel)
        Me.RunControlBox.Controls.Add(Me.RunOperationsButton)
        Me.RunControlBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunControlBox.Location = New System.Drawing.Point(550, 7)
        Me.RunControlBox.Name = "RunControlBox"
        Me.RunControlBox.Size = New System.Drawing.Size(224, 408)
        Me.RunControlBox.TabIndex = 1
        Me.RunControlBox.TabStop = False
        Me.RunControlBox.Text = "Run Control"
        '
        'SrfrSimulations
        '
        Me.SrfrSimulations.AccessibleDescription = "Selects precision contour computation (runs slower)"
        Me.SrfrSimulations.AccessibleName = "Precision Contours"
        Me.SrfrSimulations.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SrfrSimulations.Location = New System.Drawing.Point(20, 180)
        Me.SrfrSimulations.Name = "SrfrSimulations"
        Me.SrfrSimulations.Size = New System.Drawing.Size(195, 24)
        Me.SrfrSimulations.TabIndex = 8
        Me.SrfrSimulations.Text = "&SRFR Simulations"
        '
        'VolumeBalanceCalculations
        '
        Me.VolumeBalanceCalculations.AccessibleDescription = "Selects standard contour computation (faster execution)"
        Me.VolumeBalanceCalculations.AccessibleName = "Standard Contours"
        Me.VolumeBalanceCalculations.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VolumeBalanceCalculations.Location = New System.Drawing.Point(20, 158)
        Me.VolumeBalanceCalculations.Name = "VolumeBalanceCalculations"
        Me.VolumeBalanceCalculations.Size = New System.Drawing.Size(195, 24)
        Me.VolumeBalanceCalculations.TabIndex = 7
        Me.VolumeBalanceCalculations.Text = "&Volume Balance"
        '
        'SolutionModelBox
        '
        Me.SolutionModelBox.AccessibleDescription = "Selects the simulation model to be used when verifying estimated infiltration par" &
    "ameters."
        Me.SolutionModelBox.AccessibleName = "Simulation Solution Model"
        Me.SolutionModelBox.Controls.Add(Me.EnableDiagnosticsControl)
        Me.SolutionModelBox.Controls.Add(Me.CellDensityLabel)
        Me.SolutionModelBox.Controls.Add(Me.CellDensityControl)
        Me.SolutionModelBox.Controls.Add(Me.SolutionModelControl)
        Me.SolutionModelBox.Location = New System.Drawing.Point(8, 23)
        Me.SolutionModelBox.Name = "SolutionModelBox"
        Me.SolutionModelBox.Size = New System.Drawing.Size(208, 103)
        Me.SolutionModelBox.TabIndex = 0
        Me.SolutionModelBox.TabStop = False
        Me.SolutionModelBox.Text = "Simulation S&olution Model"
        '
        'EnableDiagnosticsControl
        '
        Me.EnableDiagnosticsControl.AlwaysChecked = False
        Me.EnableDiagnosticsControl.ErrorMessage = Nothing
        Me.EnableDiagnosticsControl.Location = New System.Drawing.Point(11, 77)
        Me.EnableDiagnosticsControl.Name = "EnableDiagnosticsControl"
        Me.EnableDiagnosticsControl.Size = New System.Drawing.Size(192, 21)
        Me.EnableDiagnosticsControl.TabIndex = 3
        Me.EnableDiagnosticsControl.Text = "E&nable Diagnostics"
        Me.EnableDiagnosticsControl.UncheckAttemptMessage = Nothing
        Me.EnableDiagnosticsControl.UseVisualStyleBackColor = True
        '
        'CellDensityLabel
        '
        Me.CellDensityLabel.Location = New System.Drawing.Point(6, 50)
        Me.CellDensityLabel.Name = "CellDensityLabel"
        Me.CellDensityLabel.Size = New System.Drawing.Size(116, 23)
        Me.CellDensityLabel.TabIndex = 1
        Me.CellDensityLabel.Text = "&Cell Density"
        Me.CellDensityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CellDensityControl
        '
        Me.CellDensityControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CellDensityControl.IsCalculated = True
        Me.CellDensityControl.Location = New System.Drawing.Point(128, 50)
        Me.CellDensityControl.Name = "CellDensityControl"
        Me.CellDensityControl.Size = New System.Drawing.Size(72, 24)
        Me.CellDensityControl.TabIndex = 2
        Me.CellDensityControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.CellDensityControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.CellDensityControl.ValueText = ""
        '
        'SolutionModelControl
        '
        Me.SolutionModelControl.AccessibleDescription = "Selects the Simulation Solution Model to use when running the Simulation."
        Me.SolutionModelControl.AccessibleName = "Solution Model"
        Me.SolutionModelControl.ApplicationValue = -1
        Me.SolutionModelControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SolutionModelControl.EnableSaveActions = False
        Me.SolutionModelControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SolutionModelControl.IsCalculated = True
        Me.SolutionModelControl.Location = New System.Drawing.Point(8, 21)
        Me.SolutionModelControl.Name = "SolutionModelControl"
        Me.SolutionModelControl.SelectedIndexSet = False
        Me.SolutionModelControl.Size = New System.Drawing.Size(184, 28)
        Me.SolutionModelControl.TabIndex = 0
        '
        'ExecutionErrorsWarnings
        '
        Me.ExecutionErrorsWarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExecutionErrorsWarnings.Location = New System.Drawing.Point(8, 231)
        Me.ExecutionErrorsWarnings.Name = "ExecutionErrorsWarnings"
        Me.ExecutionErrorsWarnings.ReadOnly = True
        Me.ExecutionErrorsWarnings.Size = New System.Drawing.Size(208, 177)
        Me.ExecutionErrorsWarnings.TabIndex = 3
        Me.ExecutionErrorsWarnings.Text = ""
        '
        'NoErrorsWarningsLabel
        '
        Me.NoErrorsWarningsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoErrorsWarningsLabel.Location = New System.Drawing.Point(8, 235)
        Me.NoErrorsWarningsLabel.Name = "NoErrorsWarningsLabel"
        Me.NoErrorsWarningsLabel.Size = New System.Drawing.Size(208, 23)
        Me.NoErrorsWarningsLabel.TabIndex = 3
        Me.NoErrorsWarningsLabel.Text = "None"
        Me.NoErrorsWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorsWarningsLabel
        '
        Me.ErrorsWarningsLabel.Location = New System.Drawing.Point(8, 208)
        Me.ErrorsWarningsLabel.Name = "ErrorsWarningsLabel"
        Me.ErrorsWarningsLabel.Size = New System.Drawing.Size(208, 23)
        Me.ErrorsWarningsLabel.TabIndex = 2
        Me.ErrorsWarningsLabel.Text = "Errors && Warnings"
        Me.ErrorsWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RunOperationsButton
        '
        Me.RunOperationsButton.AccessibleDescription = "Press to execute the analysis."
        Me.RunOperationsButton.AccessibleName = "Run Button"
        Me.RunOperationsButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RunOperationsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RunOperationsButton.Location = New System.Drawing.Point(6, 133)
        Me.RunOperationsButton.Name = "RunOperationsButton"
        Me.RunOperationsButton.Size = New System.Drawing.Size(209, 24)
        Me.RunOperationsButton.TabIndex = 1
        Me.RunOperationsButton.Text = "&Run using:"
        Me.RunOperationsButton.UseVisualStyleBackColor = False
        '
        'ExecutionBox
        '
        Me.ExecutionBox.AccessibleDescription = "The main criteria for analyzing an Operations function."
        Me.ExecutionBox.AccessibleName = "Operations Analysis"
        Me.ExecutionBox.Controls.Add(Me.TuningFactorsBox)
        Me.ExecutionBox.Controls.Add(Me.ContourRangesBox)
        Me.ExecutionBox.Controls.Add(Me.OperationsParametersBox)
        Me.ExecutionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExecutionBox.Location = New System.Drawing.Point(6, 7)
        Me.ExecutionBox.Name = "ExecutionBox"
        Me.ExecutionBox.Size = New System.Drawing.Size(536, 408)
        Me.ExecutionBox.TabIndex = 0
        Me.ExecutionBox.TabStop = False
        Me.ExecutionBox.Text = "Operations Analysis"
        '
        'TuningFactorsBox
        '
        Me.TuningFactorsBox.AccessibleDescription = "Factors used to 'tune' the Design Analysis to the unsteady-flow simulation."
        Me.TuningFactorsBox.AccessibleName = "Tuning Factors"
        Me.TuningFactorsBox.Controls.Add(Me.ResetPointButton)
        Me.TuningFactorsBox.Controls.Add(Me.rLabel)
        Me.TuningFactorsBox.Controls.Add(Me.rControl)
        Me.TuningFactorsBox.Controls.Add(Me.Phi3Label)
        Me.TuningFactorsBox.Controls.Add(Me.Phi3Control)
        Me.TuningFactorsBox.Controls.Add(Me.EstimationPointLabel)
        Me.TuningFactorsBox.Controls.Add(Me.Phi0Label)
        Me.TuningFactorsBox.Controls.Add(Me.Phi0Control)
        Me.TuningFactorsBox.Controls.Add(Me.EstimateTuningFactorsButton)
        Me.TuningFactorsBox.Controls.Add(Me.Phi2Label)
        Me.TuningFactorsBox.Controls.Add(Me.Phi1Label)
        Me.TuningFactorsBox.Controls.Add(Me.SigmaYControl)
        Me.TuningFactorsBox.Controls.Add(Me.SigmaYLabel)
        Me.TuningFactorsBox.Controls.Add(Me.Phi2Control)
        Me.TuningFactorsBox.Controls.Add(Me.Phi1Control)
        Me.TuningFactorsBox.Controls.Add(Me.ContourCutoffTimePointControl)
        Me.TuningFactorsBox.Controls.Add(Me.ContourInflowRatePointControl)
        Me.TuningFactorsBox.Controls.Add(Me.ContourFurrowsPerSetPointControl)
        Me.TuningFactorsBox.Location = New System.Drawing.Point(368, 24)
        Me.TuningFactorsBox.Name = "TuningFactorsBox"
        Me.TuningFactorsBox.Size = New System.Drawing.Size(160, 378)
        Me.TuningFactorsBox.TabIndex = 2
        Me.TuningFactorsBox.TabStop = False
        Me.TuningFactorsBox.Text = "Tuning Factors"
        '
        'ResetPointButton
        '
        Me.ResetPointButton.AccessibleDescription = "Press to reset tuning point to recommended value."
        Me.ResetPointButton.AccessibleName = "Reset Tuning Point"
        Me.ResetPointButton.Location = New System.Drawing.Point(6, 141)
        Me.ResetPointButton.Name = "ResetPointButton"
        Me.ResetPointButton.Size = New System.Drawing.Size(148, 24)
        Me.ResetPointButton.TabIndex = 5
        Me.ResetPointButton.Text = "R&eset Point"
        '
        'rLabel
        '
        Me.rLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rLabel.Location = New System.Drawing.Point(8, 346)
        Me.rLabel.Name = "rLabel"
        Me.rLabel.Size = New System.Drawing.Size(64, 23)
        Me.rLabel.TabIndex = 16
        Me.rLabel.Text = "r"
        Me.rLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rControl
        '
        Me.rControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.rControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rControl.IsCalculated = False
        Me.rControl.IsInteger = False
        Me.rControl.Location = New System.Drawing.Point(72, 346)
        Me.rControl.MaxErrMsg = ""
        Me.rControl.MinErrMsg = ""
        Me.rControl.Name = "rControl"
        Me.rControl.Size = New System.Drawing.Size(80, 24)
        Me.rControl.TabIndex = 17
        Me.rControl.ToBeCalculated = True
        Me.rControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.rControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.rControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.rControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.rControl.ValueText = ""
        '
        'Phi3Label
        '
        Me.Phi3Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phi3Label.Location = New System.Drawing.Point(8, 323)
        Me.Phi3Label.Name = "Phi3Label"
        Me.Phi3Label.Size = New System.Drawing.Size(64, 23)
        Me.Phi3Label.TabIndex = 14
        Me.Phi3Label.Text = "Phi 3"
        Me.Phi3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Phi3Control
        '
        Me.Phi3Control.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.Phi3Control.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phi3Control.IsCalculated = False
        Me.Phi3Control.IsInteger = False
        Me.Phi3Control.Location = New System.Drawing.Point(72, 323)
        Me.Phi3Control.MaxErrMsg = ""
        Me.Phi3Control.MinErrMsg = ""
        Me.Phi3Control.Name = "Phi3Control"
        Me.Phi3Control.Size = New System.Drawing.Size(80, 24)
        Me.Phi3Control.TabIndex = 15
        Me.Phi3Control.ToBeCalculated = True
        Me.Phi3Control.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.Phi3Control.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.Phi3Control.ValueBackColor = System.Drawing.SystemColors.Window
        Me.Phi3Control.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.Phi3Control.ValueText = ""
        '
        'EstimationPointLabel
        '
        Me.EstimationPointLabel.Location = New System.Drawing.Point(6, 25)
        Me.EstimationPointLabel.Name = "EstimationPointLabel"
        Me.EstimationPointLabel.Size = New System.Drawing.Size(150, 24)
        Me.EstimationPointLabel.TabIndex = 0
        Me.EstimationPointLabel.Text = "T&uning Point"
        Me.EstimationPointLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Phi0Label
        '
        Me.Phi0Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phi0Label.Location = New System.Drawing.Point(8, 254)
        Me.Phi0Label.Name = "Phi0Label"
        Me.Phi0Label.Size = New System.Drawing.Size(64, 23)
        Me.Phi0Label.TabIndex = 8
        Me.Phi0Label.Text = "Phi 0"
        Me.Phi0Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Phi0Control
        '
        Me.Phi0Control.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.Phi0Control.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phi0Control.IsCalculated = False
        Me.Phi0Control.IsInteger = False
        Me.Phi0Control.Location = New System.Drawing.Point(72, 254)
        Me.Phi0Control.MaxErrMsg = ""
        Me.Phi0Control.MinErrMsg = ""
        Me.Phi0Control.Name = "Phi0Control"
        Me.Phi0Control.Size = New System.Drawing.Size(80, 24)
        Me.Phi0Control.TabIndex = 9
        Me.Phi0Control.ToBeCalculated = True
        Me.Phi0Control.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.Phi0Control.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.Phi0Control.ValueBackColor = System.Drawing.SystemColors.Window
        Me.Phi0Control.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.Phi0Control.ValueText = ""
        '
        'EstimateTuningFactorsButton
        '
        Me.EstimateTuningFactorsButton.AccessibleDescription = "Press to estimate the tuning factors using a simulation of the irrigation."
        Me.EstimateTuningFactorsButton.AccessibleName = "Estimate Tuning Factors"
        Me.EstimateTuningFactorsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimateTuningFactorsButton.Location = New System.Drawing.Point(6, 113)
        Me.EstimateTuningFactorsButton.Name = "EstimateTuningFactorsButton"
        Me.EstimateTuningFactorsButton.Size = New System.Drawing.Size(148, 24)
        Me.EstimateTuningFactorsButton.TabIndex = 3
        Me.EstimateTuningFactorsButton.Text = "&Compute"
        '
        'Phi2Label
        '
        Me.Phi2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phi2Label.Location = New System.Drawing.Point(8, 300)
        Me.Phi2Label.Name = "Phi2Label"
        Me.Phi2Label.Size = New System.Drawing.Size(64, 23)
        Me.Phi2Label.TabIndex = 12
        Me.Phi2Label.Text = "Phi 2"
        Me.Phi2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Phi1Label
        '
        Me.Phi1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phi1Label.Location = New System.Drawing.Point(8, 277)
        Me.Phi1Label.Name = "Phi1Label"
        Me.Phi1Label.Size = New System.Drawing.Size(64, 23)
        Me.Phi1Label.TabIndex = 10
        Me.Phi1Label.Text = "Phi 1"
        Me.Phi1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SigmaYControl
        '
        Me.SigmaYControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.SigmaYControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SigmaYControl.IsCalculated = False
        Me.SigmaYControl.IsInteger = False
        Me.SigmaYControl.Location = New System.Drawing.Point(72, 228)
        Me.SigmaYControl.MaxErrMsg = ""
        Me.SigmaYControl.MinErrMsg = ""
        Me.SigmaYControl.Name = "SigmaYControl"
        Me.SigmaYControl.Size = New System.Drawing.Size(80, 24)
        Me.SigmaYControl.TabIndex = 7
        Me.SigmaYControl.ToBeCalculated = True
        Me.SigmaYControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.SigmaYControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.SigmaYControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.SigmaYControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.SigmaYControl.ValueText = ""
        '
        'SigmaYLabel
        '
        Me.SigmaYLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SigmaYLabel.Location = New System.Drawing.Point(8, 228)
        Me.SigmaYLabel.Name = "SigmaYLabel"
        Me.SigmaYLabel.Size = New System.Drawing.Size(64, 23)
        Me.SigmaYLabel.TabIndex = 6
        Me.SigmaYLabel.Text = "Sigma &Y"
        Me.SigmaYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Phi2Control
        '
        Me.Phi2Control.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.Phi2Control.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phi2Control.IsCalculated = False
        Me.Phi2Control.IsInteger = False
        Me.Phi2Control.Location = New System.Drawing.Point(72, 300)
        Me.Phi2Control.MaxErrMsg = ""
        Me.Phi2Control.MinErrMsg = ""
        Me.Phi2Control.Name = "Phi2Control"
        Me.Phi2Control.Size = New System.Drawing.Size(80, 24)
        Me.Phi2Control.TabIndex = 13
        Me.Phi2Control.ToBeCalculated = True
        Me.Phi2Control.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.Phi2Control.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.Phi2Control.ValueBackColor = System.Drawing.SystemColors.Window
        Me.Phi2Control.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.Phi2Control.ValueText = ""
        '
        'Phi1Control
        '
        Me.Phi1Control.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.Phi1Control.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phi1Control.IsCalculated = False
        Me.Phi1Control.IsInteger = False
        Me.Phi1Control.Location = New System.Drawing.Point(72, 277)
        Me.Phi1Control.MaxErrMsg = ""
        Me.Phi1Control.MinErrMsg = ""
        Me.Phi1Control.Name = "Phi1Control"
        Me.Phi1Control.Size = New System.Drawing.Size(80, 24)
        Me.Phi1Control.TabIndex = 11
        Me.Phi1Control.ToBeCalculated = True
        Me.Phi1Control.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.Phi1Control.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.Phi1Control.ValueBackColor = System.Drawing.SystemColors.Window
        Me.Phi1Control.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.Phi1Control.ValueText = ""
        '
        'ContourCutoffTimePointControl
        '
        Me.ContourCutoffTimePointControl.AccessibleDescription = "Cutoff Time used when tuning the Operations calculations."
        Me.ContourCutoffTimePointControl.AccessibleName = "Cutoff Time"
        Me.ContourCutoffTimePointControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ContourCutoffTimePointControl.IsCalculated = False
        Me.ContourCutoffTimePointControl.IsInteger = False
        Me.ContourCutoffTimePointControl.Location = New System.Drawing.Point(48, 80)
        Me.ContourCutoffTimePointControl.MaxErrMsg = ""
        Me.ContourCutoffTimePointControl.MinErrMsg = ""
        Me.ContourCutoffTimePointControl.Name = "ContourCutoffTimePointControl"
        Me.ContourCutoffTimePointControl.Size = New System.Drawing.Size(104, 24)
        Me.ContourCutoffTimePointControl.TabIndex = 2
        Me.ContourCutoffTimePointControl.ToBeCalculated = True
        Me.ContourCutoffTimePointControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ContourCutoffTimePointControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ContourCutoffTimePointControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ContourCutoffTimePointControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ContourCutoffTimePointControl.ValueText = ""
        '
        'ContourInflowRatePointControl
        '
        Me.ContourInflowRatePointControl.AccessibleDescription = "Inflow Rate used when tuning the Operations calculations."
        Me.ContourInflowRatePointControl.AccessibleName = "Inflow Rate"
        Me.ContourInflowRatePointControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ContourInflowRatePointControl.IsCalculated = False
        Me.ContourInflowRatePointControl.IsInteger = False
        Me.ContourInflowRatePointControl.Location = New System.Drawing.Point(48, 55)
        Me.ContourInflowRatePointControl.MaxErrMsg = ""
        Me.ContourInflowRatePointControl.MinErrMsg = ""
        Me.ContourInflowRatePointControl.Name = "ContourInflowRatePointControl"
        Me.ContourInflowRatePointControl.Size = New System.Drawing.Size(104, 24)
        Me.ContourInflowRatePointControl.TabIndex = 1
        Me.ContourInflowRatePointControl.ToBeCalculated = True
        Me.ContourInflowRatePointControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ContourInflowRatePointControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ContourInflowRatePointControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ContourInflowRatePointControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ContourInflowRatePointControl.ValueText = ""
        '
        'ContourFurrowsPerSetPointControl
        '
        Me.ContourFurrowsPerSetPointControl.AccessibleDescription = "Furrows Per Set used when tuning the Operations calculations."
        Me.ContourFurrowsPerSetPointControl.AccessibleName = "Furrows Per Set"
        Me.ContourFurrowsPerSetPointControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ContourFurrowsPerSetPointControl.IsCalculated = False
        Me.ContourFurrowsPerSetPointControl.IsInteger = False
        Me.ContourFurrowsPerSetPointControl.Location = New System.Drawing.Point(48, 55)
        Me.ContourFurrowsPerSetPointControl.MaxErrMsg = ""
        Me.ContourFurrowsPerSetPointControl.MinErrMsg = ""
        Me.ContourFurrowsPerSetPointControl.Name = "ContourFurrowsPerSetPointControl"
        Me.ContourFurrowsPerSetPointControl.Size = New System.Drawing.Size(104, 24)
        Me.ContourFurrowsPerSetPointControl.TabIndex = 1
        Me.ContourFurrowsPerSetPointControl.ToBeCalculated = True
        Me.ContourFurrowsPerSetPointControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ContourFurrowsPerSetPointControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ContourFurrowsPerSetPointControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ContourFurrowsPerSetPointControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ContourFurrowsPerSetPointControl.ValueText = ""
        '
        'ContourRangesBox
        '
        Me.ContourRangesBox.AccessibleDescription = "The configuration for the Result's contour graphs"
        Me.ContourRangesBox.AccessibleName = "Contour Definition"
        Me.ContourRangesBox.Controls.Add(Me.AddContourOverlays)
        Me.ContourRangesBox.Controls.Add(Me.ShowMinorContours)
        Me.ContourRangesBox.Controls.Add(Me.PrecisionContoursOption)
        Me.ContourRangesBox.Controls.Add(Me.StandardContoursOption)
        Me.ContourRangesBox.Controls.Add(Me.ContourGridSizeControl)
        Me.ContourRangesBox.Controls.Add(Me.ContourGridSizeLabel)
        Me.ContourRangesBox.Controls.Add(Me.CutoffTimeRangePanel)
        Me.ContourRangesBox.Controls.Add(Me.CutoffDistanceRangePanel)
        Me.ContourRangesBox.Controls.Add(Me.FurrowsPerSetRangePanel)
        Me.ContourRangesBox.Controls.Add(Me.InflowRateRangePanel)
        Me.ContourRangesBox.Location = New System.Drawing.Point(8, 203)
        Me.ContourRangesBox.Name = "ContourRangesBox"
        Me.ContourRangesBox.Size = New System.Drawing.Size(352, 199)
        Me.ContourRangesBox.TabIndex = 1
        Me.ContourRangesBox.TabStop = False
        Me.ContourRangesBox.Text = "Contour Configuration"
        '
        'AddContourOverlays
        '
        Me.AddContourOverlays.AccessibleDescription = "Press to add a tab page of overlaying contours"
        Me.AddContourOverlays.AccessibleName = "Contour Overlay"
        Me.AddContourOverlays.Location = New System.Drawing.Point(176, 168)
        Me.AddContourOverlays.Name = "AddContourOverlays"
        Me.AddContourOverlays.Size = New System.Drawing.Size(168, 24)
        Me.AddContourOverlays.TabIndex = 7
        Me.AddContourOverlays.Text = "Contour &Overlay"
        '
        'ShowMinorContours
        '
        Me.ShowMinorContours.AccessibleDescription = "Selects the calculation and display of minor contours"
        Me.ShowMinorContours.AccessibleName = "Show Minor Contours"
        Me.ShowMinorContours.AlwaysChecked = False
        Me.ShowMinorContours.ErrorMessage = Nothing
        Me.ShowMinorContours.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowMinorContours.Location = New System.Drawing.Point(176, 136)
        Me.ShowMinorContours.Name = "ShowMinorContours"
        Me.ShowMinorContours.Size = New System.Drawing.Size(168, 24)
        Me.ShowMinorContours.TabIndex = 5
        Me.ShowMinorContours.Text = "Calc. &Minor Contours"
        Me.ShowMinorContours.UncheckAttemptMessage = Nothing
        '
        'PrecisionContoursOption
        '
        Me.PrecisionContoursOption.AccessibleDescription = "Selects precision contour computation (runs slower)"
        Me.PrecisionContoursOption.AccessibleName = "Precision Contours"
        Me.PrecisionContoursOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecisionContoursOption.Location = New System.Drawing.Point(10, 160)
        Me.PrecisionContoursOption.Name = "PrecisionContoursOption"
        Me.PrecisionContoursOption.Size = New System.Drawing.Size(160, 24)
        Me.PrecisionContoursOption.TabIndex = 6
        Me.PrecisionContoursOption.Text = "&Precision Contours"
        '
        'StandardContoursOption
        '
        Me.StandardContoursOption.AccessibleDescription = "Selects standard contour computation (faster execution)"
        Me.StandardContoursOption.AccessibleName = "Standard Contours"
        Me.StandardContoursOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StandardContoursOption.Location = New System.Drawing.Point(10, 136)
        Me.StandardContoursOption.Name = "StandardContoursOption"
        Me.StandardContoursOption.Size = New System.Drawing.Size(160, 24)
        Me.StandardContoursOption.TabIndex = 4
        Me.StandardContoursOption.Text = "&Standard Contours"
        '
        'ContourGridSizeControl
        '
        Me.ContourGridSizeControl.AccessibleDescription = "The number of grid points to base the contours on."
        Me.ContourGridSizeControl.AccessibleName = "Contour Grid Size"
        Me.ContourGridSizeControl.ApplicationValue = -1
        Me.ContourGridSizeControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ContourGridSizeControl.EnableSaveActions = False
        Me.ContourGridSizeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContourGridSizeControl.IsCalculated = False
        Me.ContourGridSizeControl.Location = New System.Drawing.Point(178, 96)
        Me.ContourGridSizeControl.Name = "ContourGridSizeControl"
        Me.ContourGridSizeControl.SelectedIndexSet = False
        Me.ContourGridSizeControl.Size = New System.Drawing.Size(136, 28)
        Me.ContourGridSizeControl.TabIndex = 3
        '
        'ContourGridSizeLabel
        '
        Me.ContourGridSizeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContourGridSizeLabel.Location = New System.Drawing.Point(10, 96)
        Me.ContourGridSizeLabel.Name = "ContourGridSizeLabel"
        Me.ContourGridSizeLabel.Size = New System.Drawing.Size(162, 23)
        Me.ContourGridSizeLabel.TabIndex = 2
        Me.ContourGridSizeLabel.Text = "Contour &Grid Size"
        Me.ContourGridSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutoffTimeRangePanel
        '
        Me.CutoffTimeRangePanel.AccessibleDescription = "Specifies the Cutoff Time range for the result's contours."
        Me.CutoffTimeRangePanel.AccessibleName = "Cutoff Time"
        Me.CutoffTimeRangePanel.Controls.Add(Me.MaxCutoffTimeControl)
        Me.CutoffTimeRangePanel.Controls.Add(Me.CutoffTimeToLabel)
        Me.CutoffTimeRangePanel.Controls.Add(Me.MinCutoffTimeControl)
        Me.CutoffTimeRangePanel.Controls.Add(Me.CutoffTimeLabel)
        Me.CutoffTimeRangePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffTimeRangePanel.Location = New System.Drawing.Point(4, 56)
        Me.CutoffTimeRangePanel.Name = "CutoffTimeRangePanel"
        Me.CutoffTimeRangePanel.Size = New System.Drawing.Size(340, 32)
        Me.CutoffTimeRangePanel.TabIndex = 1
        '
        'MaxCutoffTimeControl
        '
        Me.MaxCutoffTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MaxCutoffTimeControl.IsCalculated = False
        Me.MaxCutoffTimeControl.IsInteger = False
        Me.MaxCutoffTimeControl.Location = New System.Drawing.Point(244, 4)
        Me.MaxCutoffTimeControl.MaxErrMsg = ""
        Me.MaxCutoffTimeControl.MinErrMsg = ""
        Me.MaxCutoffTimeControl.Name = "MaxCutoffTimeControl"
        Me.MaxCutoffTimeControl.Size = New System.Drawing.Size(92, 24)
        Me.MaxCutoffTimeControl.TabIndex = 3
        Me.MaxCutoffTimeControl.ToBeCalculated = True
        Me.MaxCutoffTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MaxCutoffTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MaxCutoffTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MaxCutoffTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxCutoffTimeControl.ValueText = ""
        '
        'CutoffTimeToLabel
        '
        Me.CutoffTimeToLabel.Location = New System.Drawing.Point(223, 5)
        Me.CutoffTimeToLabel.Name = "CutoffTimeToLabel"
        Me.CutoffTimeToLabel.Size = New System.Drawing.Size(20, 23)
        Me.CutoffTimeToLabel.TabIndex = 2
        Me.CutoffTimeToLabel.Text = "to"
        Me.CutoffTimeToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MinCutoffTimeControl
        '
        Me.MinCutoffTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MinCutoffTimeControl.IsCalculated = False
        Me.MinCutoffTimeControl.IsInteger = False
        Me.MinCutoffTimeControl.Location = New System.Drawing.Point(156, 4)
        Me.MinCutoffTimeControl.MaxErrMsg = ""
        Me.MinCutoffTimeControl.MinErrMsg = ""
        Me.MinCutoffTimeControl.Name = "MinCutoffTimeControl"
        Me.MinCutoffTimeControl.Size = New System.Drawing.Size(64, 24)
        Me.MinCutoffTimeControl.TabIndex = 1
        Me.MinCutoffTimeControl.ToBeCalculated = True
        Me.MinCutoffTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MinCutoffTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MinCutoffTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MinCutoffTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MinCutoffTimeControl.ValueText = ""
        '
        'CutoffTimeLabel
        '
        Me.CutoffTimeLabel.Location = New System.Drawing.Point(3, 5)
        Me.CutoffTimeLabel.Name = "CutoffTimeLabel"
        Me.CutoffTimeLabel.Size = New System.Drawing.Size(149, 23)
        Me.CutoffTimeLabel.TabIndex = 0
        Me.CutoffTimeLabel.Text = "Cutoff &Time"
        Me.CutoffTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CutoffDistanceRangePanel
        '
        Me.CutoffDistanceRangePanel.AccessibleDescription = "Specifies the Cutoff Distance range for the result's contours."
        Me.CutoffDistanceRangePanel.AccessibleName = "Cutoff Distance"
        Me.CutoffDistanceRangePanel.Controls.Add(Me.MaxCutoffdistanceControl)
        Me.CutoffDistanceRangePanel.Controls.Add(Me.CutoffDistanceToLabel)
        Me.CutoffDistanceRangePanel.Controls.Add(Me.MinCutoffDistanceControl)
        Me.CutoffDistanceRangePanel.Controls.Add(Me.CutoffDistanceLabel)
        Me.CutoffDistanceRangePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CutoffDistanceRangePanel.Location = New System.Drawing.Point(8, 56)
        Me.CutoffDistanceRangePanel.Name = "CutoffDistanceRangePanel"
        Me.CutoffDistanceRangePanel.Size = New System.Drawing.Size(336, 32)
        Me.CutoffDistanceRangePanel.TabIndex = 1
        '
        'MaxCutoffdistanceControl
        '
        Me.MaxCutoffdistanceControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MaxCutoffdistanceControl.IsCalculated = False
        Me.MaxCutoffdistanceControl.IsInteger = False
        Me.MaxCutoffdistanceControl.Location = New System.Drawing.Point(240, 4)
        Me.MaxCutoffdistanceControl.MaxErrMsg = ""
        Me.MaxCutoffdistanceControl.MinErrMsg = ""
        Me.MaxCutoffdistanceControl.Name = "MaxCutoffdistanceControl"
        Me.MaxCutoffdistanceControl.Size = New System.Drawing.Size(88, 24)
        Me.MaxCutoffdistanceControl.TabIndex = 3
        Me.MaxCutoffdistanceControl.ToBeCalculated = True
        Me.MaxCutoffdistanceControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MaxCutoffdistanceControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MaxCutoffdistanceControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MaxCutoffdistanceControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxCutoffdistanceControl.ValueText = ""
        '
        'CutoffDistanceToLabel
        '
        Me.CutoffDistanceToLabel.Location = New System.Drawing.Point(220, 5)
        Me.CutoffDistanceToLabel.Name = "CutoffDistanceToLabel"
        Me.CutoffDistanceToLabel.Size = New System.Drawing.Size(16, 23)
        Me.CutoffDistanceToLabel.TabIndex = 2
        Me.CutoffDistanceToLabel.Text = "to"
        Me.CutoffDistanceToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MinCutoffDistanceControl
        '
        Me.MinCutoffDistanceControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MinCutoffDistanceControl.IsCalculated = False
        Me.MinCutoffDistanceControl.IsInteger = False
        Me.MinCutoffDistanceControl.Location = New System.Drawing.Point(152, 4)
        Me.MinCutoffDistanceControl.MaxErrMsg = ""
        Me.MinCutoffDistanceControl.MinErrMsg = ""
        Me.MinCutoffDistanceControl.Name = "MinCutoffDistanceControl"
        Me.MinCutoffDistanceControl.Size = New System.Drawing.Size(64, 24)
        Me.MinCutoffDistanceControl.TabIndex = 1
        Me.MinCutoffDistanceControl.ToBeCalculated = True
        Me.MinCutoffDistanceControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MinCutoffDistanceControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MinCutoffDistanceControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MinCutoffDistanceControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MinCutoffDistanceControl.ValueText = ""
        '
        'CutoffDistanceLabel
        '
        Me.CutoffDistanceLabel.AccessibleName = ""
        Me.CutoffDistanceLabel.Location = New System.Drawing.Point(8, 5)
        Me.CutoffDistanceLabel.Name = "CutoffDistanceLabel"
        Me.CutoffDistanceLabel.Size = New System.Drawing.Size(144, 23)
        Me.CutoffDistanceLabel.TabIndex = 0
        Me.CutoffDistanceLabel.Text = "Cutoff Distance"
        Me.CutoffDistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FurrowsPerSetRangePanel
        '
        Me.FurrowsPerSetRangePanel.AccessibleDescription = "Specifies the Furrows Per Set range for the result's contours."
        Me.FurrowsPerSetRangePanel.AccessibleName = "Furrows Per Set"
        Me.FurrowsPerSetRangePanel.Controls.Add(Me.FurrowsPerSetToLabel)
        Me.FurrowsPerSetRangePanel.Controls.Add(Me.MaxFurrowsPerSetControl)
        Me.FurrowsPerSetRangePanel.Controls.Add(Me.MinFurrowsPerSetControl)
        Me.FurrowsPerSetRangePanel.Controls.Add(Me.FurrowsPerSetLabel)
        Me.FurrowsPerSetRangePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowsPerSetRangePanel.Location = New System.Drawing.Point(4, 24)
        Me.FurrowsPerSetRangePanel.Name = "FurrowsPerSetRangePanel"
        Me.FurrowsPerSetRangePanel.Size = New System.Drawing.Size(340, 32)
        Me.FurrowsPerSetRangePanel.TabIndex = 8
        '
        'FurrowsPerSetToLabel
        '
        Me.FurrowsPerSetToLabel.AutoSize = True
        Me.FurrowsPerSetToLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowsPerSetToLabel.Location = New System.Drawing.Point(224, 5)
        Me.FurrowsPerSetToLabel.Name = "FurrowsPerSetToLabel"
        Me.FurrowsPerSetToLabel.Size = New System.Drawing.Size(23, 20)
        Me.FurrowsPerSetToLabel.TabIndex = 2
        Me.FurrowsPerSetToLabel.Text = "to"
        Me.FurrowsPerSetToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MaxFurrowsPerSetControl
        '
        Me.MaxFurrowsPerSetControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MaxFurrowsPerSetControl.IsCalculated = False
        Me.MaxFurrowsPerSetControl.IsInteger = False
        Me.MaxFurrowsPerSetControl.Location = New System.Drawing.Point(244, 4)
        Me.MaxFurrowsPerSetControl.MaxErrMsg = ""
        Me.MaxFurrowsPerSetControl.MinErrMsg = ""
        Me.MaxFurrowsPerSetControl.Name = "MaxFurrowsPerSetControl"
        Me.MaxFurrowsPerSetControl.Size = New System.Drawing.Size(92, 24)
        Me.MaxFurrowsPerSetControl.TabIndex = 3
        Me.MaxFurrowsPerSetControl.ToBeCalculated = True
        Me.MaxFurrowsPerSetControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MaxFurrowsPerSetControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MaxFurrowsPerSetControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MaxFurrowsPerSetControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxFurrowsPerSetControl.ValueText = ""
        '
        'MinFurrowsPerSetControl
        '
        Me.MinFurrowsPerSetControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MinFurrowsPerSetControl.IsCalculated = False
        Me.MinFurrowsPerSetControl.IsInteger = False
        Me.MinFurrowsPerSetControl.Location = New System.Drawing.Point(156, 4)
        Me.MinFurrowsPerSetControl.MaxErrMsg = ""
        Me.MinFurrowsPerSetControl.MinErrMsg = ""
        Me.MinFurrowsPerSetControl.Name = "MinFurrowsPerSetControl"
        Me.MinFurrowsPerSetControl.Size = New System.Drawing.Size(64, 24)
        Me.MinFurrowsPerSetControl.TabIndex = 1
        Me.MinFurrowsPerSetControl.ToBeCalculated = True
        Me.MinFurrowsPerSetControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MinFurrowsPerSetControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MinFurrowsPerSetControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MinFurrowsPerSetControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MinFurrowsPerSetControl.ValueText = ""
        '
        'FurrowsPerSetLabel
        '
        Me.FurrowsPerSetLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowsPerSetLabel.Location = New System.Drawing.Point(2, 4)
        Me.FurrowsPerSetLabel.Name = "FurrowsPerSetLabel"
        Me.FurrowsPerSetLabel.Size = New System.Drawing.Size(150, 23)
        Me.FurrowsPerSetLabel.TabIndex = 0
        Me.FurrowsPerSetLabel.Text = "Furrows &Per Set"
        Me.FurrowsPerSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InflowRateRangePanel
        '
        Me.InflowRateRangePanel.AccessibleDescription = "Specifies the Inflow Rate range for the result's contours."
        Me.InflowRateRangePanel.AccessibleName = "Furrow Set Inflow Rate"
        Me.InflowRateRangePanel.Controls.Add(Me.InflowRateToLabel)
        Me.InflowRateRangePanel.Controls.Add(Me.InflowRateLabel)
        Me.InflowRateRangePanel.Controls.Add(Me.MaxInflowRateControl)
        Me.InflowRateRangePanel.Controls.Add(Me.MinInflowRateControl)
        Me.InflowRateRangePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRateRangePanel.Location = New System.Drawing.Point(4, 24)
        Me.InflowRateRangePanel.Name = "InflowRateRangePanel"
        Me.InflowRateRangePanel.Size = New System.Drawing.Size(340, 32)
        Me.InflowRateRangePanel.TabIndex = 0
        '
        'InflowRateToLabel
        '
        Me.InflowRateToLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRateToLabel.Location = New System.Drawing.Point(223, 5)
        Me.InflowRateToLabel.Name = "InflowRateToLabel"
        Me.InflowRateToLabel.Size = New System.Drawing.Size(20, 23)
        Me.InflowRateToLabel.TabIndex = 2
        Me.InflowRateToLabel.Text = "to"
        Me.InflowRateToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InflowRateLabel
        '
        Me.InflowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRateLabel.Location = New System.Drawing.Point(2, 4)
        Me.InflowRateLabel.Name = "InflowRateLabel"
        Me.InflowRateLabel.Size = New System.Drawing.Size(150, 23)
        Me.InflowRateLabel.TabIndex = 0
        Me.InflowRateLabel.Text = "Furrow Set Inflow R&ate"
        Me.InflowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MaxInflowRateControl
        '
        Me.MaxInflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MaxInflowRateControl.IsCalculated = False
        Me.MaxInflowRateControl.IsInteger = False
        Me.MaxInflowRateControl.Location = New System.Drawing.Point(244, 4)
        Me.MaxInflowRateControl.MaxErrMsg = ""
        Me.MaxInflowRateControl.MinErrMsg = ""
        Me.MaxInflowRateControl.Name = "MaxInflowRateControl"
        Me.MaxInflowRateControl.Size = New System.Drawing.Size(92, 24)
        Me.MaxInflowRateControl.TabIndex = 3
        Me.MaxInflowRateControl.ToBeCalculated = True
        Me.MaxInflowRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MaxInflowRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MaxInflowRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MaxInflowRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxInflowRateControl.ValueText = ""
        '
        'MinInflowRateControl
        '
        Me.MinInflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MinInflowRateControl.IsCalculated = False
        Me.MinInflowRateControl.IsInteger = False
        Me.MinInflowRateControl.Location = New System.Drawing.Point(156, 4)
        Me.MinInflowRateControl.MaxErrMsg = ""
        Me.MinInflowRateControl.MinErrMsg = ""
        Me.MinInflowRateControl.Name = "MinInflowRateControl"
        Me.MinInflowRateControl.Size = New System.Drawing.Size(64, 24)
        Me.MinInflowRateControl.TabIndex = 1
        Me.MinInflowRateControl.ToBeCalculated = True
        Me.MinInflowRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MinInflowRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MinInflowRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MinInflowRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MinInflowRateControl.ValueText = ""
        '
        'OperationsParametersBox
        '
        Me.OperationsParametersBox.AccessibleDescription = "The primary inputs for the Operations Analysis"
        Me.OperationsParametersBox.AccessibleName = "Operations Parameters"
        Me.OperationsParametersBox.Controls.Add(Me.RequiredDepthControl)
        Me.OperationsParametersBox.Controls.Add(Me.RequiredDepthLabel)
        Me.OperationsParametersBox.Controls.Add(Me.ReflectsLabel)
        Me.OperationsParametersBox.Controls.Add(Me.DepthCriteriaControl)
        Me.OperationsParametersBox.Controls.Add(Me.DepthCriteriaExLabel)
        Me.OperationsParametersBox.Controls.Add(Me.FurrowOperationsPanel)
        Me.OperationsParametersBox.Controls.Add(Me.BorderOperationsPanel)
        Me.OperationsParametersBox.Location = New System.Drawing.Point(8, 24)
        Me.OperationsParametersBox.Name = "OperationsParametersBox"
        Me.OperationsParametersBox.Size = New System.Drawing.Size(352, 165)
        Me.OperationsParametersBox.TabIndex = 0
        Me.OperationsParametersBox.TabStop = False
        Me.OperationsParametersBox.Text = "Contour Options"
        '
        'RequiredDepthControl
        '
        Me.RequiredDepthControl.AccessibleDescription = ""
        Me.RequiredDepthControl.AccessibleName = ""
        Me.RequiredDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RequiredDepthControl.IsCalculated = False
        Me.RequiredDepthControl.IsInteger = False
        Me.RequiredDepthControl.Location = New System.Drawing.Point(234, 78)
        Me.RequiredDepthControl.MaxErrMsg = ""
        Me.RequiredDepthControl.MinErrMsg = ""
        Me.RequiredDepthControl.Name = "RequiredDepthControl"
        Me.RequiredDepthControl.Size = New System.Drawing.Size(112, 24)
        Me.RequiredDepthControl.TabIndex = 3
        Me.RequiredDepthControl.ToBeCalculated = True
        Me.RequiredDepthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.RequiredDepthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.RequiredDepthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.RequiredDepthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.RequiredDepthControl.ValueText = ""
        '
        'RequiredDepthLabel
        '
        Me.RequiredDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequiredDepthLabel.Location = New System.Drawing.Point(8, 78)
        Me.RequiredDepthLabel.Name = "RequiredDepthLabel"
        Me.RequiredDepthLabel.Size = New System.Drawing.Size(208, 23)
        Me.RequiredDepthLabel.TabIndex = 4
        Me.RequiredDepthLabel.Text = "Required Depth, &Dreq"
        Me.RequiredDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ReflectsLabel
        '
        Me.ReflectsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectsLabel.Location = New System.Drawing.Point(4, 139)
        Me.ReflectsLabel.Name = "ReflectsLabel"
        Me.ReflectsLabel.Size = New System.Drawing.Size(342, 23)
        Me.ReflectsLabel.TabIndex = 8
        Me.ReflectsLabel.Text = "This box reflects choices made on previous tabs."
        Me.ReflectsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DepthCriteriaControl
        '
        Me.DepthCriteriaControl.AccessibleDescription = "Specifies what contour depth should be displayed in the Results."
        Me.DepthCriteriaControl.AccessibleName = "Depth Criteria"
        Me.DepthCriteriaControl.ApplicationValue = -1
        Me.DepthCriteriaControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DepthCriteriaControl.EnableSaveActions = False
        Me.DepthCriteriaControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthCriteriaControl.IsCalculated = False
        Me.DepthCriteriaControl.Location = New System.Drawing.Point(162, 109)
        Me.DepthCriteriaControl.Name = "DepthCriteriaControl"
        Me.DepthCriteriaControl.SelectedIndexSet = False
        Me.DepthCriteriaControl.Size = New System.Drawing.Size(136, 28)
        Me.DepthCriteriaControl.TabIndex = 7
        '
        'DepthCriteriaExLabel
        '
        Me.DepthCriteriaExLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthCriteriaExLabel.Location = New System.Drawing.Point(8, 109)
        Me.DepthCriteriaExLabel.Name = "DepthCriteriaExLabel"
        Me.DepthCriteriaExLabel.Size = New System.Drawing.Size(152, 23)
        Me.DepthCriteriaExLabel.TabIndex = 6
        Me.DepthCriteriaExLabel.Text = "Dept&h to Display"
        Me.DepthCriteriaExLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FurrowOperationsPanel
        '
        Me.FurrowOperationsPanel.Controls.Add(Me.FurrowSetInflowRateOption)
        Me.FurrowOperationsPanel.Controls.Add(Me.FurrowsPerSetOption)
        Me.FurrowOperationsPanel.Location = New System.Drawing.Point(4, 17)
        Me.FurrowOperationsPanel.Name = "FurrowOperationsPanel"
        Me.FurrowOperationsPanel.Size = New System.Drawing.Size(342, 58)
        Me.FurrowOperationsPanel.TabIndex = 1
        '
        'FurrowSetInflowRateOption
        '
        Me.FurrowSetInflowRateOption.AutoSize = True
        Me.FurrowSetInflowRateOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowSetInflowRateOption.Location = New System.Drawing.Point(9, 29)
        Me.FurrowSetInflowRateOption.Name = "FurrowSetInflowRateOption"
        Me.FurrowSetInflowRateOption.Size = New System.Drawing.Size(264, 24)
        Me.FurrowSetInflowRateOption.TabIndex = 1
        Me.FurrowSetInflowRateOption.TabStop = True
        Me.FurrowSetInflowRateOption.Text = "&Furrows per set and cutoff time"
        Me.FurrowSetInflowRateOption.UseVisualStyleBackColor = True
        '
        'FurrowsPerSetOption
        '
        Me.FurrowsPerSetOption.AutoSize = True
        Me.FurrowsPerSetOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FurrowsPerSetOption.Location = New System.Drawing.Point(9, 7)
        Me.FurrowsPerSetOption.Name = "FurrowsPerSetOption"
        Me.FurrowsPerSetOption.Size = New System.Drawing.Size(223, 24)
        Me.FurrowsPerSetOption.TabIndex = 0
        Me.FurrowsPerSetOption.TabStop = True
        Me.FurrowsPerSetOption.Text = "&Inflow rate and cutoff time"
        Me.FurrowsPerSetOption.UseVisualStyleBackColor = True
        '
        'BorderOperationsPanel
        '
        Me.BorderOperationsPanel.Location = New System.Drawing.Point(4, 17)
        Me.BorderOperationsPanel.Name = "BorderOperationsPanel"
        Me.BorderOperationsPanel.Size = New System.Drawing.Size(342, 58)
        Me.BorderOperationsPanel.TabIndex = 1
        '
        'ctl_OperationsExecution
        '
        Me.Controls.Add(Me.RunControlBox)
        Me.Controls.Add(Me.ExecutionBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_OperationsExecution"
        Me.Size = New System.Drawing.Size(776, 422)
        Me.RunControlBox.ResumeLayout(False)
        Me.SolutionModelBox.ResumeLayout(False)
        Me.ExecutionBox.ResumeLayout(False)
        Me.TuningFactorsBox.ResumeLayout(False)
        Me.ContourRangesBox.ResumeLayout(False)
        Me.CutoffTimeRangePanel.ResumeLayout(False)
        Me.CutoffDistanceRangePanel.ResumeLayout(False)
        Me.FurrowsPerSetRangePanel.ResumeLayout(False)
        Me.FurrowsPerSetRangePanel.PerformLayout()
        Me.InflowRateRangePanel.ResumeLayout(False)
        Me.OperationsParametersBox.ResumeLayout(False)
        Me.FurrowOperationsPanel.ResumeLayout(False)
        Me.FurrowOperationsPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm

    Private mDictionary As Dictionary
    Private mMyStore As DataStore.ObjectNode

    Private WithEvents mWinSRFR As WinSRFR
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mSubsurfaceFlow As SubsurfaceFlow

    Private WithEvents mBorderCriteria As BorderCriteria
    Private WithEvents mSrfrCriteria As SrfrCriteria

    Private mOperationsWorld As OperationsWorld

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Public Sub LinkToModel(ByVal _unit As Unit, ByVal _world As OperationsWorld)

        Debug.Assert(Not (_unit Is Nothing), "Unit is Nothing")
        Debug.Assert(Not (_world Is Nothing), "Design World is Nothing")

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mSubsurfaceFlow = mUnit.SubsurfaceFlowRef

        mBorderCriteria = mUnit.BorderCriteriaRef
        mSrfrCriteria = mUnit.SrfrCriteriaRef

        mOperationsWorld = _world
        mMyStore = mUnit.MyStore
        mDictionary = Dictionary.Instance

        ' Link the contained controls to their models & store
        Me.SolutionModelControl.LinkToModel(mMyStore, mSrfrCriteria.SolutionModelProperty)
        Me.CellDensityControl.LinkToModel(mMyStore, mSrfrCriteria.CellDensityProperty)
        Me.EnableDiagnosticsControl.LinkToModel(mMyStore, mSrfrCriteria.EnableDiagnosticsProperty)

        Me.RequiredDepthControl.LinkToModel(mMyStore, mInflowManagement.RequiredDepthProperty)
        Me.DepthCriteriaControl.LinkToModel(mMyStore, mBorderCriteria.InfiltratedDepthCriterionProperty)

        Me.MinCutoffTimeControl.LinkToModel(mMyStore, mBorderCriteria.MinContourCutoffTimeProperty)
        Me.MaxCutoffTimeControl.LinkToModel(mMyStore, mBorderCriteria.MaxContourCutoffTimeProperty)
        Me.MinCutoffDistanceControl.LinkToModel(mMyStore, mBorderCriteria.MinContourCutoffLocationRatioProperty)
        Me.MaxCutoffdistanceControl.LinkToModel(mMyStore, mBorderCriteria.MaxContourCutoffLocationRatioProperty)
        Me.MinInflowRateControl.LinkToModel(mMyStore, mBorderCriteria.MinContourInflowRateProperty)
        Me.MaxInflowRateControl.LinkToModel(mMyStore, mBorderCriteria.MaxContourInflowRateProperty)
        Me.MinFurrowsPerSetControl.LinkToModel(mMyStore, mBorderCriteria.MinContourFurrowsPerSetProperty)
        Me.MaxFurrowsPerSetControl.LinkToModel(mMyStore, mBorderCriteria.MaxContourFurrowsPerSetProperty)

        Me.ContourGridSizeControl.LinkToModel(mMyStore, mBorderCriteria.GridResolutionProperty)
        Me.ContourInflowRatePointControl.LinkToModel(mMyStore, mBorderCriteria.ContourInflowRatePointProperty)
        Me.ContourFurrowsPerSetPointControl.LinkToModel(mMyStore, mBorderCriteria.ContourFurrowsPerSetPointProperty)
        Me.ContourCutoffTimePointControl.LinkToModel(mMyStore, mBorderCriteria.ContourCutoffTimePointProperty)

        ' Tuning parameters
        Me.SigmaYControl.IsCalculated = True
        Me.SigmaYControl.LinkToModel(mMyStore, mBorderCriteria.SigmaYProperty)

        Me.Phi0Control.IsCalculated = True
        Me.Phi1Control.IsCalculated = True
        Me.Phi2Control.IsCalculated = True
        Me.Phi3Control.IsCalculated = True
        Me.rControl.IsCalculated = True

        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Me.Phi0Control.LinkToModel(mMyStore, mBorderCriteria.Phi0FurrowsProperty)
            Me.Phi1Control.LinkToModel(mMyStore, mBorderCriteria.Phi1FurrowsProperty)
            Me.Phi2Control.LinkToModel(mMyStore, mBorderCriteria.Phi2FurrowsProperty)
            Me.Phi3Control.LinkToModel(mMyStore, mBorderCriteria.Phi3FurrowsProperty)
            Me.rControl.LinkToModel(mMyStore, mBorderCriteria.PwrAdvRFurrowsProperty)
        Else ' Basin / Border
            Me.Phi0Control.LinkToModel(mMyStore, mBorderCriteria.Phi0BordersProperty)
            Me.Phi1Control.LinkToModel(mMyStore, mBorderCriteria.Phi1BordersProperty)
            Me.Phi2Control.LinkToModel(mMyStore, mBorderCriteria.Phi2BordersProperty)
            Me.Phi3Control.LinkToModel(mMyStore, mBorderCriteria.Phi3BordersProperty)
            Me.rControl.LinkToModel(mMyStore, mBorderCriteria.PwrAdvRBordersProperty)
        End If

        Me.VolumeBalanceCalculations.LinkToModel(mMyStore, mBorderCriteria.OperationsMethodProperty, OperationsMethod.VolumeBalance)
        Me.SrfrSimulations.LinkToModel(mMyStore, mBorderCriteria.OperationsMethodProperty, OperationsMethod.SrfrSimulations)

        ' Update language translation
        UpdateLanguage()

        ' Update the control's User Interface
        UpdateUI()

    End Sub

#End Region

#Region " Update UI Methods "

#Region " Operations World "
    '
    ' Update the Operations World's UI
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mUnit IsNot Nothing) Then
            '
            ' Update Operations controls
            UpdateDepthCriteria()

            ' Update the System definition
            UpdateCrossSection()

            If (mUnit.CrossSection = CrossSections.Furrow) Then
                ' Furrow Operations only supports Time-Based Cutoff
                Me.CutoffDistanceRangePanel.Hide()
                Me.CutoffTimeRangePanel.Show()
            Else
                ' Basin & Border Operations support Time & Distance-Based Cutoff
                Dim cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)
                Select Case (cutoffMethod)
                    Case CutoffMethods.DistanceBased
                        Me.CutoffTimeRangePanel.Hide()
                        Me.CutoffDistanceRangePanel.Show()
                    Case Else ' Assume CutoffMethods.TimeBased
                        Me.CutoffDistanceRangePanel.Hide()
                        Me.CutoffTimeRangePanel.Show()
                End Select
            End If

            If (mBorderCriteria.OperationsMethod.Value = OperationsMethod.SrfrSimulations) Then
                Me.StandardContoursOption.Hide()
                Me.PrecisionContoursOption.Hide()
                Me.TuningFactorsBox.Hide()
            Else ' VolumeBalanceCalculations
                Me.StandardContoursOption.Show()
                Me.PrecisionContoursOption.Show()
                Me.TuningFactorsBox.Show()
            End If

            ' Update SRFR Solution Model & Cell Density
            UpdateSolutionModel()

        End If

    End Sub
    '
    ' Update the Results Control (Buttons)
    '
    Public Sub EnableRunButtons()
        Me.RunOperationsButton.Enabled = True
        Me.EstimateTuningFactorsButton.Enabled = True
    End Sub

    Public Sub DisableRunButtons()
        Me.RunOperationsButton.Enabled = False
        Me.EstimateTuningFactorsButton.Enabled = False
    End Sub
    '
    ' Update Solution Model selection list & selection
    '
    Public Sub UpdateSolutionModel()
        If Not (mSrfrCriteria Is Nothing) Then
            Dim _simModel As Integer = mSrfrCriteria.SolutionModel.Value

            ' Enable / disable access to SRFR controls
            Select Case (WinSRFR.UserLevel)
                Case UserLevels.Standard
                    ' Solution Model & Cell Density always set for Standard User
                    Me.SolutionModelControl.IsCalculated = True
                    Me.CellDensityControl.IsCalculated = True
                    Me.EnableDiagnosticsControl.Visible = False
                Case UserLevels.Advanced
                    ' Solution Model & Cell Density always available for Advanced User
                    Me.SolutionModelControl.IsCalculated = False
                    Me.CellDensityControl.IsCalculated = False
                    Me.EnableDiagnosticsControl.Visible = False
                Case Else ' Research
                    ' Solution Model & Cell Density always available for Research
                    Me.SolutionModelControl.IsCalculated = False
                    Me.CellDensityControl.IsCalculated = False
                    Me.EnableDiagnosticsControl.Visible = True
            End Select

            If (WinSRFR.DebuggerIsAttached) Then
                Me.EnableDiagnosticsControl.Visible = True
            End If

            ' Update selection list
            Dim _sel As String = String.Empty
            Dim _idx As Integer = 0

            Me.SolutionModelControl.Clear()

            Dim _selOk As Boolean = mSrfrCriteria.GetFirstSolutionModelSelection(_sel)
            While Not (_sel Is Nothing)
                If (_selOk) Then
                    Me.SolutionModelControl.Add(_sel, _idx, True)
                ElseIf (_simModel = _idx) Then
                    Me.SolutionModelControl.Add(_sel, _idx, False)
                End If
                _selOk = mSrfrCriteria.GetNextSolutionModelSelection(_sel)
                _idx += 1
            End While

            ' Update controls
            Me.SolutionModelControl.UpdateUI()
            Me.CellDensityControl.UpdateUI()
        End If
    End Sub

    Public Sub AddOperationsExecutionErrorWarning(ByVal _type As String,
                                                  ByVal _title As String,
                                                  ByVal _details As String)

        Dim _richTextBox As RichTextBox = CType(ExecutionErrorsWarnings, RichTextBox)

        AppendBoldLine(_richTextBox, _type + ":")
        AdvanceLine(_richTextBox)
        AppendLine(_richTextBox, _title)
        AdvanceLine(_richTextBox)
        AppendLine(_richTextBox, _details)
        AdvanceLine(_richTextBox)

    End Sub

    Private Sub AddOperationsExecutionWarning(ByVal _title As String, ByVal _details As String)
        AddOperationsExecutionErrorWarning(mDictionary.tWarning.Translated, _title, _details)
    End Sub

    Private Sub AddOperationsExecutionError(ByVal _title As String, ByVal _details As String)
        AddOperationsExecutionErrorWarning(mDictionary.tError.Translated, _title, _details)
    End Sub

    Public Sub UpdateOperationsSetupErrorsWarnings(ByVal analysis As OperationsAnalysis)
        If ((mUnit IsNot Nothing) And (analysis IsNot Nothing)) Then
            ' Check Analysis errors & warnings
            analysis.UpdateSetupErrorsAndWarnings()

            ' Display Design errors & warnings
            Me.ExecutionErrorsWarnings.Clear()

            If (analysis.HasSetupErrorsOrWarnings) Then
                Me.ExecutionErrorsWarnings.DisplayErrorsAndWarnings(analysis, True)
                Me.ExecutionErrorsWarnings.Show()
            ElseIf (0 < mUnit.UnitControlRef.RunCount.Value) Then
                Me.ExecutionErrorsWarnings.DisplayWarning(mDictionary.tAnalysisHasAlreadyBeenRunID.Translated,
                                                          mDictionary.tAnalysisHasAlreadyBeenRunDetail.Translated)
                Me.ExecutionErrorsWarnings.Show()
            Else
                Me.ExecutionErrorsWarnings.Hide()
            End If
        End If
    End Sub

#End Region

#Region " System Type "
    '
    ' Update the UI's Cross Section
    '
    Private Sub UpdateCrossSection()
        If Not (mSystemGeometry Is Nothing) Then
            ' Hide/Show/Limit controls & check to appropriate item
            Select Case (mSystemGeometry.CrossSection.Value)

                Case CrossSections.Basin, CrossSections.Border

                    UpdateOperationsCriteria()

                    ' Execution Tab
                    Me.FurrowOperationsPanel.Hide()
                    Me.BorderOperationsPanel.Show()

                    ExecutionBox.Text = mDictionary.tBasinBorderOperations.Translated

                    InflowRateLabel.Text = mDictionary.tBorderInflowRate.Translated

                    Me.Phi0Control.LinkToModel(mMyStore, mBorderCriteria.Phi0BordersProperty)
                    Me.Phi1Control.LinkToModel(mMyStore, mBorderCriteria.Phi1BordersProperty)
                    Me.Phi2Control.LinkToModel(mMyStore, mBorderCriteria.Phi2BordersProperty)
                    Me.Phi3Control.LinkToModel(mMyStore, mBorderCriteria.Phi3BordersProperty)

                Case Else ' Assume Furrow

                    UpdateOperationsCriteria()

                    ' Execution Tab
                    Me.BorderOperationsPanel.Hide()
                    Me.FurrowOperationsPanel.Show()

                    ExecutionBox.Text = mDictionary.tFurrowOperations.Translated

                    InflowRateLabel.Text = mDictionary.tFurrowSetInflowRate.Translated

                    Me.Phi0Control.LinkToModel(mMyStore, mBorderCriteria.Phi0FurrowsProperty)
                    Me.Phi1Control.LinkToModel(mMyStore, mBorderCriteria.Phi1FurrowsProperty)
                    Me.Phi2Control.LinkToModel(mMyStore, mBorderCriteria.Phi2FurrowsProperty)
                    Me.Phi3Control.LinkToModel(mMyStore, mBorderCriteria.Phi3FurrowsProperty)

            End Select
        End If
    End Sub

#End Region

#Region " Basin / Border / Furrow Operations "
    '
    ' Depth Criteria
    '
    Private Sub UpdateDepthCriteria()
        If (mBorderCriteria IsNot Nothing) Then

            ' Update Depth Criteria selection list
            DepthCriteriaControl.Clear()

            Dim _sel As String = mBorderCriteria.GetFirstInfiltratedDepthCriteriaSelection
            Dim _idx As Integer = 0
            While (_sel IsNot Nothing)
                If Not (_sel = String.Empty) Then
                    DepthCriteriaControl.Add(_sel, _idx)
                End If

                _sel = mBorderCriteria.GetNextInfiltratedDepthCriteriaSelection
                _idx += 1
            End While

            ' Update selection
            DepthCriteriaControl.UpdateUI()
        End If
    End Sub
    '
    ' Update the UI's Border Operations Criteria
    '
    Private Sub UpdateOperationsCriteria()
        If (mBorderCriteria IsNot Nothing) Then

            ' Update Contour Precision selection
            If (WinSRFR.UserPreferences.CalculatePrecisionContours = True) Then
                PrecisionContoursOption.Checked = True
            Else
                StandardContoursOption.Checked = True
            End If

            ' Update Depth Criteria selection list
            ContourGridSizeControl.Clear()

            Dim _sel As String = mBorderCriteria.GetFirstGridResolutionSelection
            Dim _idx As Integer = 0
            While (_sel IsNot Nothing)
                If Not (_sel = String.Empty) Then
                    ContourGridSizeControl.Add(_sel, _idx)
                End If

                _sel = mBorderCriteria.GetNextGridResolutionSelection
                _idx += 1
            End While

            ' Update selection
            ContourGridSizeControl.UpdateUI()

            ' Update Show Minor Contours
            ShowMinorContours.Checked = WinSRFR.UserPreferences.DisplayMinorContours

            ' Update Furrow Operations Criteria
            Select Case (mBorderCriteria.OperationsOption.Value)
                Case OperationsOptions.WidthGiven
                    Me.FurrowsPerSetOption.Checked = True

                    Me.FurrowsPerSetRangePanel.Hide()
                    Me.InflowRateRangePanel.Show()

                    Me.ContourFurrowsPerSetPointControl.Hide()
                    Me.ContourInflowRatePointControl.Show()

                Case Else ' Assume OperationsOptions.InflowRateGiven
                    Me.FurrowSetInflowRateOption.Checked = True

                    Me.InflowRateRangePanel.Hide()
                    Me.FurrowsPerSetRangePanel.Show()

                    Me.ContourInflowRatePointControl.Hide()
                    Me.ContourFurrowsPerSetPointControl.Show()

            End Select

        End If
    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#End Region

#Region " UI Event Handlers "

#Region " Basin / Border / Furrow Execution "
    '
    ' Furrow Operations Options
    '
    Private Sub SelectOperationsOption(ByVal _option As OperationsOptions)
        If Not (mBorderCriteria Is Nothing) Then
            ' Update Operations Option only if the value has changed
            If Not (mBorderCriteria.OperationsOption.Value = _option) Then

                ' Set the new value if it has changed
                Dim _operationsOption As IntegerParameter = mBorderCriteria.OperationsOption
                If Not (_operationsOption.Value = _option) Then
                    mMyStore.MarkForUndo(mDictionary.tOperationsOptionChange.ToString)
                    _operationsOption.Value = _option
                    _operationsOption.Source = DataStore.Globals.ValueSources.UserEntered
                    mBorderCriteria.OperationsOption = _operationsOption
                End If

            End If
        End If
    End Sub

    Private Sub FurrowsPerSetOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FurrowsPerSetOption.CheckedChanged
        If (FurrowsPerSetOption.Checked) Then
            SelectOperationsOption(OperationsOptions.WidthGiven)
        End If
    End Sub

    Private Sub FurrowSetInflowRateOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FurrowSetInflowRateOption.CheckedChanged
        If (FurrowSetInflowRateOption.Checked) Then
            SelectOperationsOption(OperationsOptions.InflowRateGiven)
        End If
    End Sub
    '
    ' Contour Precision
    '
    Private Sub StandardContoursOption_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) _
    Handles StandardContoursOption.CheckedChanged
        If (StandardContoursOption.Checked) Then
            WinSRFR.UserPreferences.CalculatePrecisionContours = False
            WinSRFR.UserPreferences.WriteToRegistry()
        End If
    End Sub

    Private Sub PrecisionContoursOption_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) _
    Handles PrecisionContoursOption.CheckedChanged
        If (PrecisionContoursOption.Checked) Then
            WinSRFR.UserPreferences.CalculatePrecisionContours = True
            WinSRFR.UserPreferences.WriteToRegistry()
        End If
    End Sub
    '
    ' Minor Contours
    '
    Private Sub ShowMinorContours_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) _
    Handles ShowMinorContours.CheckedChanged
        WinSRFR.UserPreferences.DisplayMinorContours = ShowMinorContours.Checked
        WinSRFR.UserPreferences.WriteToRegistry()
    End Sub
    '
    ' Contour Range changes
    '
    ' Default tuning point is center point
    '
    Private Sub SetContourCutoffTimePoint(Optional ByVal Reset As Boolean = False)
        Dim width As DoubleParameter = mBorderCriteria.ContourCutoffTimePoint
        If Not (width.Source = ValueSources.UserEntered) Then
            Reset = True
        End If

        If (Reset) Then
            Dim minCutoffTime As Double = mBorderCriteria.MinContourCutoffTime.Value
            Dim maxCutoffTime As Double = mBorderCriteria.MaxContourCutoffTime.Value
            width.Value = (minCutoffTime + maxCutoffTime) / 2.0 ' Mid-point
            width.Source = ValueSources.Calculated
            mBorderCriteria.ContourCutoffTimePoint = width
        End If
    End Sub

    Private Sub SetContourInflowRatePoint(Optional ByVal Reset As Boolean = False)
        Dim inflowRate As DoubleParameter = mBorderCriteria.ContourInflowRatePoint
        If Not (inflowRate.Source = ValueSources.UserEntered) Then
            Reset = True
        End If

        If (Reset) Then
            Dim minInflowRate As Double = mBorderCriteria.MinContourInflowRate.Value
            Dim maxInflowRate As Double = mBorderCriteria.MaxContourInflowRate.Value
            inflowRate.Value = (minInflowRate + maxInflowRate) / 2.0 ' Mid-point
            inflowRate.Source = ValueSources.Calculated
            mBorderCriteria.ContourInflowRatePoint = inflowRate
        End If
    End Sub

    Private Sub SetContourFurrowsPerSetPoint(Optional ByVal Reset As Boolean = False)
        Dim furrowsPerSet As DoubleParameter = mBorderCriteria.ContourFurrowsPerSetPoint
        If Not (furrowsPerSet.Source = ValueSources.UserEntered) Then
            Reset = True
        End If

        If (Reset) Then
            Dim minFurrowsPerSet As Double = mBorderCriteria.MinContourFurrowsPerSet.Value
            Dim maxFurrowsPerSet As Double = mBorderCriteria.MaxContourFurrowsPerSet.Value
            furrowsPerSet.Value = Math.Floor((minFurrowsPerSet + maxFurrowsPerSet) / 2.0) ' Mid-point
            furrowsPerSet.Source = ValueSources.Calculated
            mBorderCriteria.ContourFurrowsPerSetPoint = furrowsPerSet
        End If
    End Sub

    Private Sub MinCutoffTimeControl_ControlValueChanged() _
    Handles MinCutoffTimeControl.ControlValueChanged
        SetContourCutoffTimePoint()
    End Sub

    Private Sub MaxCutoffTimeControl_ControlValueChanged() _
    Handles MaxCutoffTimeControl.ControlValueChanged
        SetContourCutoffTimePoint()
        MinCutoffTimeControl.AltUnits = MaxCutoffTimeControl.AltUnits
    End Sub

    Private Sub MinInflowRateControl_ControlValueChanged() _
    Handles MinInflowRateControl.ControlValueChanged
        SetContourInflowRatePoint()
    End Sub

    Private Sub MaxInflowRateControl_ControlValueChanged() _
    Handles MaxInflowRateControl.ControlValueChanged
        SetContourInflowRatePoint()
        MinInflowRateControl.AltUnits = MaxInflowRateControl.AltUnits
    End Sub

    Private Sub MinFurrowsPerSetControl_ControlValueChanged() _
    Handles MinFurrowsPerSetControl.ControlValueChanged
        SetContourFurrowsPerSetPoint()
    End Sub

    Private Sub MaxFurrowsPerSetControl_ControlValueChanged() _
    Handles MaxFurrowsPerSetControl.ControlValueChanged
        SetContourFurrowsPerSetPoint()
    End Sub

    Private Sub ResetPointButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ResetPointButton.Click
        SetContourCutoffTimePoint(True)
        SetContourInflowRatePoint(True)
        SetContourFurrowsPerSetPoint(True)
    End Sub

#End Region

#Region " Run Control "

    Private Sub EstimateTuningFactorsButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) _
        Handles EstimateTuningFactorsButton.Click
        Me.Focus()
        mOperationsWorld.EstimateOperationsTuningFactors()
    End Sub

    Private Sub RunOperationsButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) _
        Handles RunOperationsButton.Click
        Me.Focus()
        If (mBorderCriteria.OperationsMethod.Value = OperationsMethod.VolumeBalance) Then
            mOperationsWorld.RunOperationsAnalysis(OperationsMethod.VolumeBalance)
        Else ' SRFR Simulations
            mOperationsWorld.RunOperationsAnalysis(OperationsMethod.SrfrSimulations)
        End If
    End Sub

    Private Sub AddContourOverlays_Click(ByVal sender As System.Object, ByVal e As EventArgs) _
        Handles AddContourOverlays.Click
        Me.Focus()
        mOperationsWorld.AddContourOverlays()
    End Sub

#End Region

#Region " Misc. "
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

#End Region

End Class
