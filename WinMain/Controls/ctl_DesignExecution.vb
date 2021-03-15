
'*************************************************************************************************************
' ctl_DesignExecution - Design World's Execution Tab UI
'*************************************************************************************************************
Imports DataStore
Imports DataStore.DataStore
Imports PrintingUI

Public Class ctl_DesignExecution
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
    Friend WithEvents ErrorsWarningsLabel As DataStore.ctl_Label
    Friend WithEvents RunDesignButton As DataStore.ctl_Button
    Friend WithEvents ExecutionErrorsWarnings As WinMain.ErrorRichTextBox
    Friend WithEvents NoErrorsWarningsLabel As DataStore.ctl_Label
    Friend WithEvents DesignAnalysisBox As DataStore.ctl_GroupBox
    Friend WithEvents TuningFactorsBox As DataStore.ctl_GroupBox
    Friend WithEvents Phi3Label As System.Windows.Forms.Label
    Friend WithEvents Phi3Control As DataStore.ctl_DoubleParameter
    Friend WithEvents Arrow1 As System.Windows.Forms.Label
    Friend WithEvents EstimationPointLabel As DataStore.ctl_Label
    Friend WithEvents ContourLengthPointControl As DataStore.ctl_DoubleParameter
    Friend WithEvents Phi0Label As System.Windows.Forms.Label
    Friend WithEvents Phi0Control As DataStore.ctl_DoubleParameter
    Friend WithEvents EstimateTuningFactorsButton As DataStore.ctl_Button
    Friend WithEvents Phi2Label As System.Windows.Forms.Label
    Friend WithEvents Phi1Label As System.Windows.Forms.Label
    Friend WithEvents SigmaYControl As DataStore.ctl_DoubleParameter
    Friend WithEvents SigmaYLabel As System.Windows.Forms.Label
    Friend WithEvents Phi2Control As DataStore.ctl_DoubleParameter
    Friend WithEvents Phi1Control As DataStore.ctl_DoubleParameter
    Friend WithEvents ContourWidthPointControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ContourInflowRatePointControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ContourDefinitionBox As DataStore.ctl_GroupBox
    Friend WithEvents AddContourOverlays As DataStore.ctl_Button
    Friend WithEvents ShowMinorContours As DataStore.ctl_CheckParameter
    Friend WithEvents PrecisionContoursOption As DataStore.ctl_RadioButton
    Friend WithEvents StandardContoursOption As DataStore.ctl_RadioButton
    Friend WithEvents ContourGridSizeControl As DataStore.ctl_SelectParameter
    Friend WithEvents ContourGridSizeLabel As DataStore.ctl_Label
    Friend WithEvents LengthPanel As DataStore.ctl_Panel
    Friend WithEvents MaxLengthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ToLabel6 As DataStore.ctl_Label
    Friend WithEvents MinLengthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents FieldLengthLabel As DataStore.ctl_Label
    Friend WithEvents WidthPanel As DataStore.ctl_Panel
    Friend WithEvents ToLabel4 As DataStore.ctl_Label
    Friend WithEvents MaxWidthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MinWidthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents WidthLabel As DataStore.ctl_Label
    Friend WithEvents InflowRatePanel As DataStore.ctl_Panel
    Friend WithEvents ToLabel5 As DataStore.ctl_Label
    Friend WithEvents InflowRateLabel As DataStore.ctl_Label
    Friend WithEvents MaxInflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MinInflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents DesignParametersBox As DataStore.ctl_GroupBox
    Friend WithEvents ReflectsLabel As DataStore.ctl_Label
    Friend WithEvents RequiredDepthControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RequiredDepthLabel As DataStore.ctl_Label
    Friend WithEvents DepthCriteriaControl As DataStore.ctl_SelectParameter
    Friend WithEvents DepthCriteriaLabel As DataStore.ctl_Label
    Friend WithEvents InflowRateOption As DataStore.ctl_RadioButton
    Friend WithEvents EnableDiagnosticsControl As DataStore.ctl_CheckParameter
    Friend WithEvents MinDepthCriterionText As DataStore.ctl_Label
    Friend WithEvents rLabel As System.Windows.Forms.Label
    Friend WithEvents rControl As DataStore.ctl_DoubleParameter
    Friend WithEvents ResetPointButton As DataStore.ctl_Button
    Friend WithEvents WidthOption As DataStore.ctl_RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RunControlBox = New DataStore.ctl_GroupBox()
        Me.SolutionModelBox = New DataStore.ctl_GroupBox()
        Me.EnableDiagnosticsControl = New DataStore.ctl_CheckParameter()
        Me.CellDensityLabel = New DataStore.ctl_Label()
        Me.CellDensityControl = New DataStore.ctl_IntegerParameter()
        Me.SolutionModelControl = New DataStore.ctl_SelectParameter()
        Me.ErrorsWarningsLabel = New DataStore.ctl_Label()
        Me.RunDesignButton = New DataStore.ctl_Button()
        Me.ExecutionErrorsWarnings = New WinMain.ErrorRichTextBox()
        Me.NoErrorsWarningsLabel = New DataStore.ctl_Label()
        Me.DesignAnalysisBox = New DataStore.ctl_GroupBox()
        Me.TuningFactorsBox = New DataStore.ctl_GroupBox()
        Me.ResetPointButton = New DataStore.ctl_Button()
        Me.rLabel = New System.Windows.Forms.Label()
        Me.rControl = New DataStore.ctl_DoubleParameter()
        Me.Phi3Label = New System.Windows.Forms.Label()
        Me.Phi3Control = New DataStore.ctl_DoubleParameter()
        Me.Arrow1 = New System.Windows.Forms.Label()
        Me.EstimationPointLabel = New DataStore.ctl_Label()
        Me.ContourLengthPointControl = New DataStore.ctl_DoubleParameter()
        Me.Phi0Label = New System.Windows.Forms.Label()
        Me.Phi0Control = New DataStore.ctl_DoubleParameter()
        Me.EstimateTuningFactorsButton = New DataStore.ctl_Button()
        Me.Phi2Label = New System.Windows.Forms.Label()
        Me.Phi1Label = New System.Windows.Forms.Label()
        Me.SigmaYControl = New DataStore.ctl_DoubleParameter()
        Me.SigmaYLabel = New System.Windows.Forms.Label()
        Me.Phi2Control = New DataStore.ctl_DoubleParameter()
        Me.Phi1Control = New DataStore.ctl_DoubleParameter()
        Me.ContourWidthPointControl = New DataStore.ctl_DoubleParameter()
        Me.ContourInflowRatePointControl = New DataStore.ctl_DoubleParameter()
        Me.ContourDefinitionBox = New DataStore.ctl_GroupBox()
        Me.AddContourOverlays = New DataStore.ctl_Button()
        Me.ShowMinorContours = New DataStore.ctl_CheckParameter()
        Me.PrecisionContoursOption = New DataStore.ctl_RadioButton()
        Me.StandardContoursOption = New DataStore.ctl_RadioButton()
        Me.ContourGridSizeControl = New DataStore.ctl_SelectParameter()
        Me.ContourGridSizeLabel = New DataStore.ctl_Label()
        Me.LengthPanel = New DataStore.ctl_Panel()
        Me.MaxLengthControl = New DataStore.ctl_DoubleParameter()
        Me.ToLabel6 = New DataStore.ctl_Label()
        Me.MinLengthControl = New DataStore.ctl_DoubleParameter()
        Me.FieldLengthLabel = New DataStore.ctl_Label()
        Me.WidthPanel = New DataStore.ctl_Panel()
        Me.ToLabel4 = New DataStore.ctl_Label()
        Me.MaxWidthControl = New DataStore.ctl_DoubleParameter()
        Me.MinWidthControl = New DataStore.ctl_DoubleParameter()
        Me.WidthLabel = New DataStore.ctl_Label()
        Me.InflowRatePanel = New DataStore.ctl_Panel()
        Me.ToLabel5 = New DataStore.ctl_Label()
        Me.InflowRateLabel = New DataStore.ctl_Label()
        Me.MaxInflowRateControl = New DataStore.ctl_DoubleParameter()
        Me.MinInflowRateControl = New DataStore.ctl_DoubleParameter()
        Me.DesignParametersBox = New DataStore.ctl_GroupBox()
        Me.MinDepthCriterionText = New DataStore.ctl_Label()
        Me.ReflectsLabel = New DataStore.ctl_Label()
        Me.RequiredDepthControl = New DataStore.ctl_DoubleParameter()
        Me.RequiredDepthLabel = New DataStore.ctl_Label()
        Me.DepthCriteriaControl = New DataStore.ctl_SelectParameter()
        Me.DepthCriteriaLabel = New DataStore.ctl_Label()
        Me.InflowRateOption = New DataStore.ctl_RadioButton()
        Me.WidthOption = New DataStore.ctl_RadioButton()
        Me.RunControlBox.SuspendLayout()
        Me.SolutionModelBox.SuspendLayout()
        Me.DesignAnalysisBox.SuspendLayout()
        Me.TuningFactorsBox.SuspendLayout()
        Me.ContourDefinitionBox.SuspendLayout()
        Me.LengthPanel.SuspendLayout()
        Me.WidthPanel.SuspendLayout()
        Me.InflowRatePanel.SuspendLayout()
        Me.DesignParametersBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'RunControlBox
        '
        Me.RunControlBox.AccessibleDescription = "Provides the Run Button and Status"
        Me.RunControlBox.AccessibleName = "Run Control"
        Me.RunControlBox.Controls.Add(Me.SolutionModelBox)
        Me.RunControlBox.Controls.Add(Me.ErrorsWarningsLabel)
        Me.RunControlBox.Controls.Add(Me.RunDesignButton)
        Me.RunControlBox.Controls.Add(Me.ExecutionErrorsWarnings)
        Me.RunControlBox.Controls.Add(Me.NoErrorsWarningsLabel)
        Me.RunControlBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunControlBox.Location = New System.Drawing.Point(550, 7)
        Me.RunControlBox.Name = "RunControlBox"
        Me.RunControlBox.Size = New System.Drawing.Size(224, 408)
        Me.RunControlBox.TabIndex = 1
        Me.RunControlBox.TabStop = False
        Me.RunControlBox.Text = "Run Control"
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
        Me.SolutionModelBox.Location = New System.Drawing.Point(8, 24)
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
        Me.EnableDiagnosticsControl.Location = New System.Drawing.Point(8, 77)
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
        Me.SolutionModelControl.Size = New System.Drawing.Size(184, 24)
        Me.SolutionModelControl.TabIndex = 0
        '
        'ErrorsWarningsLabel
        '
        Me.ErrorsWarningsLabel.Location = New System.Drawing.Point(8, 160)
        Me.ErrorsWarningsLabel.Name = "ErrorsWarningsLabel"
        Me.ErrorsWarningsLabel.Size = New System.Drawing.Size(208, 23)
        Me.ErrorsWarningsLabel.TabIndex = 2
        Me.ErrorsWarningsLabel.Text = "Errors && Warnings"
        Me.ErrorsWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RunDesignButton
        '
        Me.RunDesignButton.AccessibleDescription = "Press to execute the Design."
        Me.RunDesignButton.AccessibleName = "Run Button"
        Me.RunDesignButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RunDesignButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RunDesignButton.Location = New System.Drawing.Point(27, 135)
        Me.RunDesignButton.Name = "RunDesignButton"
        Me.RunDesignButton.Size = New System.Drawing.Size(173, 24)
        Me.RunDesignButton.TabIndex = 1
        Me.RunDesignButton.Text = "&Run Design"
        Me.RunDesignButton.UseVisualStyleBackColor = False
        '
        'ExecutionErrorsWarnings
        '
        Me.ExecutionErrorsWarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExecutionErrorsWarnings.Location = New System.Drawing.Point(8, 184)
        Me.ExecutionErrorsWarnings.Name = "ExecutionErrorsWarnings"
        Me.ExecutionErrorsWarnings.ReadOnly = True
        Me.ExecutionErrorsWarnings.Size = New System.Drawing.Size(208, 218)
        Me.ExecutionErrorsWarnings.TabIndex = 3
        Me.ExecutionErrorsWarnings.Text = ""
        '
        'NoErrorsWarningsLabel
        '
        Me.NoErrorsWarningsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoErrorsWarningsLabel.Location = New System.Drawing.Point(16, 184)
        Me.NoErrorsWarningsLabel.Name = "NoErrorsWarningsLabel"
        Me.NoErrorsWarningsLabel.Size = New System.Drawing.Size(192, 23)
        Me.NoErrorsWarningsLabel.TabIndex = 3
        Me.NoErrorsWarningsLabel.Text = "None"
        Me.NoErrorsWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DesignAnalysisBox
        '
        Me.DesignAnalysisBox.AccessibleDescription = "Specifies the design criteria for running a Design."
        Me.DesignAnalysisBox.AccessibleName = "Design Selections"
        Me.DesignAnalysisBox.Controls.Add(Me.TuningFactorsBox)
        Me.DesignAnalysisBox.Controls.Add(Me.ContourDefinitionBox)
        Me.DesignAnalysisBox.Controls.Add(Me.DesignParametersBox)
        Me.DesignAnalysisBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignAnalysisBox.Location = New System.Drawing.Point(6, 7)
        Me.DesignAnalysisBox.Name = "DesignAnalysisBox"
        Me.DesignAnalysisBox.Size = New System.Drawing.Size(536, 408)
        Me.DesignAnalysisBox.TabIndex = 0
        Me.DesignAnalysisBox.TabStop = False
        Me.DesignAnalysisBox.Text = "Design Analysis"
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
        Me.TuningFactorsBox.Controls.Add(Me.Arrow1)
        Me.TuningFactorsBox.Controls.Add(Me.EstimationPointLabel)
        Me.TuningFactorsBox.Controls.Add(Me.ContourLengthPointControl)
        Me.TuningFactorsBox.Controls.Add(Me.Phi0Label)
        Me.TuningFactorsBox.Controls.Add(Me.Phi0Control)
        Me.TuningFactorsBox.Controls.Add(Me.EstimateTuningFactorsButton)
        Me.TuningFactorsBox.Controls.Add(Me.Phi2Label)
        Me.TuningFactorsBox.Controls.Add(Me.Phi1Label)
        Me.TuningFactorsBox.Controls.Add(Me.SigmaYControl)
        Me.TuningFactorsBox.Controls.Add(Me.SigmaYLabel)
        Me.TuningFactorsBox.Controls.Add(Me.Phi2Control)
        Me.TuningFactorsBox.Controls.Add(Me.Phi1Control)
        Me.TuningFactorsBox.Controls.Add(Me.ContourWidthPointControl)
        Me.TuningFactorsBox.Controls.Add(Me.ContourInflowRatePointControl)
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
        Me.ResetPointButton.TabIndex = 4
        Me.ResetPointButton.Text = "&Reset Point"
        '
        'rLabel
        '
        Me.rLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rLabel.Location = New System.Drawing.Point(8, 343)
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
        Me.rControl.Location = New System.Drawing.Point(72, 343)
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
        Me.Phi3Label.Location = New System.Drawing.Point(8, 320)
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
        Me.Phi3Control.Location = New System.Drawing.Point(72, 320)
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
        'Arrow1
        '
        Me.Arrow1.Location = New System.Drawing.Point(8, 216)
        Me.Arrow1.Name = "Arrow1"
        Me.Arrow1.Size = New System.Drawing.Size(0, 0)
        Me.Arrow1.TabIndex = 13
        Me.Arrow1.Text = "<---"
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
        'ContourLengthPointControl
        '
        Me.ContourLengthPointControl.AccessibleDescription = "Length to be used when tuning the Design."
        Me.ContourLengthPointControl.AccessibleName = "Tuning Point Length"
        Me.ContourLengthPointControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ContourLengthPointControl.IsCalculated = False
        Me.ContourLengthPointControl.IsInteger = False
        Me.ContourLengthPointControl.Location = New System.Drawing.Point(48, 55)
        Me.ContourLengthPointControl.MaxErrMsg = ""
        Me.ContourLengthPointControl.MinErrMsg = ""
        Me.ContourLengthPointControl.Name = "ContourLengthPointControl"
        Me.ContourLengthPointControl.Size = New System.Drawing.Size(92, 24)
        Me.ContourLengthPointControl.TabIndex = 1
        Me.ContourLengthPointControl.ToBeCalculated = True
        Me.ContourLengthPointControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ContourLengthPointControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ContourLengthPointControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ContourLengthPointControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ContourLengthPointControl.ValueText = ""
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
        Me.EstimateTuningFactorsButton.AccessibleDescription = "Press to compute the tuning factors using a simulation of the irrigation."
        Me.EstimateTuningFactorsButton.AccessibleName = "Compute Tuning Factors"
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
        Me.Phi2Label.Location = New System.Drawing.Point(8, 298)
        Me.Phi2Label.Name = "Phi2Label"
        Me.Phi2Label.Size = New System.Drawing.Size(64, 23)
        Me.Phi2Label.TabIndex = 12
        Me.Phi2Label.Text = "Phi 2"
        Me.Phi2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Phi1Label
        '
        Me.Phi1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phi1Label.Location = New System.Drawing.Point(8, 276)
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
        Me.Phi2Control.Location = New System.Drawing.Point(72, 298)
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
        Me.Phi1Control.Location = New System.Drawing.Point(72, 276)
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
        'ContourWidthPointControl
        '
        Me.ContourWidthPointControl.AccessibleDescription = "Width to be used when tuning the Design."
        Me.ContourWidthPointControl.AccessibleName = "Tuning Point Width"
        Me.ContourWidthPointControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ContourWidthPointControl.IsCalculated = False
        Me.ContourWidthPointControl.IsInteger = False
        Me.ContourWidthPointControl.Location = New System.Drawing.Point(48, 80)
        Me.ContourWidthPointControl.MaxErrMsg = ""
        Me.ContourWidthPointControl.MinErrMsg = ""
        Me.ContourWidthPointControl.Name = "ContourWidthPointControl"
        Me.ContourWidthPointControl.Size = New System.Drawing.Size(92, 24)
        Me.ContourWidthPointControl.TabIndex = 2
        Me.ContourWidthPointControl.ToBeCalculated = True
        Me.ContourWidthPointControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ContourWidthPointControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ContourWidthPointControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ContourWidthPointControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ContourWidthPointControl.ValueText = ""
        '
        'ContourInflowRatePointControl
        '
        Me.ContourInflowRatePointControl.AccessibleDescription = "Inflow Rate to be used when tuning the Design."
        Me.ContourInflowRatePointControl.AccessibleName = "Tuning Point Inflow Rate"
        Me.ContourInflowRatePointControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ContourInflowRatePointControl.IsCalculated = False
        Me.ContourInflowRatePointControl.IsInteger = False
        Me.ContourInflowRatePointControl.Location = New System.Drawing.Point(48, 80)
        Me.ContourInflowRatePointControl.MaxErrMsg = ""
        Me.ContourInflowRatePointControl.MinErrMsg = ""
        Me.ContourInflowRatePointControl.Name = "ContourInflowRatePointControl"
        Me.ContourInflowRatePointControl.Size = New System.Drawing.Size(92, 24)
        Me.ContourInflowRatePointControl.TabIndex = 14
        Me.ContourInflowRatePointControl.ToBeCalculated = True
        Me.ContourInflowRatePointControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ContourInflowRatePointControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ContourInflowRatePointControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.ContourInflowRatePointControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.ContourInflowRatePointControl.ValueText = ""
        '
        'ContourDefinitionBox
        '
        Me.ContourDefinitionBox.AccessibleDescription = "The configuration for the Result's contour graphs"
        Me.ContourDefinitionBox.AccessibleName = "Contour Definition"
        Me.ContourDefinitionBox.Controls.Add(Me.AddContourOverlays)
        Me.ContourDefinitionBox.Controls.Add(Me.ShowMinorContours)
        Me.ContourDefinitionBox.Controls.Add(Me.PrecisionContoursOption)
        Me.ContourDefinitionBox.Controls.Add(Me.StandardContoursOption)
        Me.ContourDefinitionBox.Controls.Add(Me.ContourGridSizeControl)
        Me.ContourDefinitionBox.Controls.Add(Me.ContourGridSizeLabel)
        Me.ContourDefinitionBox.Controls.Add(Me.LengthPanel)
        Me.ContourDefinitionBox.Controls.Add(Me.WidthPanel)
        Me.ContourDefinitionBox.Controls.Add(Me.InflowRatePanel)
        Me.ContourDefinitionBox.Location = New System.Drawing.Point(8, 203)
        Me.ContourDefinitionBox.Name = "ContourDefinitionBox"
        Me.ContourDefinitionBox.Size = New System.Drawing.Size(352, 199)
        Me.ContourDefinitionBox.TabIndex = 1
        Me.ContourDefinitionBox.TabStop = False
        Me.ContourDefinitionBox.Text = "Contour Configuration"
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
        Me.ShowMinorContours.AccessibleDescription = "Adds minor contours to the results."
        Me.ShowMinorContours.AccessibleName = "Show Minor Contours"
        Me.ShowMinorContours.AlwaysChecked = False
        Me.ShowMinorContours.ErrorMessage = Nothing
        Me.ShowMinorContours.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowMinorContours.Location = New System.Drawing.Point(176, 136)
        Me.ShowMinorContours.Name = "ShowMinorContours"
        Me.ShowMinorContours.Size = New System.Drawing.Size(168, 24)
        Me.ShowMinorContours.TabIndex = 6
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
        Me.PrecisionContoursOption.TabIndex = 5
        Me.PrecisionContoursOption.Text = "&Precision Contours"
        '
        'StandardContoursOption
        '
        Me.StandardContoursOption.AccessibleDescription = "Selects standard contour computation (less precise / faster execution)"
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
        Me.ContourGridSizeControl.AccessibleDescription = "Specifies the number of grid points to base the contours on."
        Me.ContourGridSizeControl.AccessibleName = "Contour Grid Size"
        Me.ContourGridSizeControl.ApplicationValue = -1
        Me.ContourGridSizeControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ContourGridSizeControl.EnableSaveActions = False
        Me.ContourGridSizeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContourGridSizeControl.IsCalculated = False
        Me.ContourGridSizeControl.Location = New System.Drawing.Point(176, 96)
        Me.ContourGridSizeControl.Name = "ContourGridSizeControl"
        Me.ContourGridSizeControl.SelectedIndexSet = False
        Me.ContourGridSizeControl.Size = New System.Drawing.Size(136, 24)
        Me.ContourGridSizeControl.TabIndex = 3
        '
        'ContourGridSizeLabel
        '
        Me.ContourGridSizeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContourGridSizeLabel.Location = New System.Drawing.Point(8, 96)
        Me.ContourGridSizeLabel.Name = "ContourGridSizeLabel"
        Me.ContourGridSizeLabel.Size = New System.Drawing.Size(162, 23)
        Me.ContourGridSizeLabel.TabIndex = 2
        Me.ContourGridSizeLabel.Text = "Contour &Grid Size"
        Me.ContourGridSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LengthPanel
        '
        Me.LengthPanel.AccessibleDescription = "Specifies the range of lengths for the contour plots"
        Me.LengthPanel.AccessibleName = "Furrow Set Length"
        Me.LengthPanel.Controls.Add(Me.MaxLengthControl)
        Me.LengthPanel.Controls.Add(Me.ToLabel6)
        Me.LengthPanel.Controls.Add(Me.MinLengthControl)
        Me.LengthPanel.Controls.Add(Me.FieldLengthLabel)
        Me.LengthPanel.Location = New System.Drawing.Point(8, 24)
        Me.LengthPanel.Name = "LengthPanel"
        Me.LengthPanel.Size = New System.Drawing.Size(336, 32)
        Me.LengthPanel.TabIndex = 0
        '
        'MaxLengthControl
        '
        Me.MaxLengthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MaxLengthControl.IsCalculated = False
        Me.MaxLengthControl.IsInteger = False
        Me.MaxLengthControl.Location = New System.Drawing.Point(240, 4)
        Me.MaxLengthControl.MaxErrMsg = ""
        Me.MaxLengthControl.MinErrMsg = ""
        Me.MaxLengthControl.Name = "MaxLengthControl"
        Me.MaxLengthControl.Size = New System.Drawing.Size(92, 24)
        Me.MaxLengthControl.TabIndex = 3
        Me.MaxLengthControl.ToBeCalculated = True
        Me.MaxLengthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MaxLengthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MaxLengthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MaxLengthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxLengthControl.ValueText = ""
        '
        'ToLabel6
        '
        Me.ToLabel6.AutoSize = True
        Me.ToLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToLabel6.Location = New System.Drawing.Point(219, 5)
        Me.ToLabel6.Name = "ToLabel6"
        Me.ToLabel6.Size = New System.Drawing.Size(17, 15)
        Me.ToLabel6.TabIndex = 2
        Me.ToLabel6.Text = "to"
        Me.ToLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MinLengthControl
        '
        Me.MinLengthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MinLengthControl.IsCalculated = False
        Me.MinLengthControl.IsInteger = False
        Me.MinLengthControl.Location = New System.Drawing.Point(152, 4)
        Me.MinLengthControl.MaxErrMsg = ""
        Me.MinLengthControl.MinErrMsg = ""
        Me.MinLengthControl.Name = "MinLengthControl"
        Me.MinLengthControl.Size = New System.Drawing.Size(64, 24)
        Me.MinLengthControl.TabIndex = 1
        Me.MinLengthControl.ToBeCalculated = True
        Me.MinLengthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MinLengthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MinLengthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MinLengthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MinLengthControl.ValueText = ""
        '
        'FieldLengthLabel
        '
        Me.FieldLengthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FieldLengthLabel.Location = New System.Drawing.Point(8, 5)
        Me.FieldLengthLabel.Name = "FieldLengthLabel"
        Me.FieldLengthLabel.Size = New System.Drawing.Size(138, 23)
        Me.FieldLengthLabel.TabIndex = 0
        Me.FieldLengthLabel.Text = "Field Length, &L"
        Me.FieldLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WidthPanel
        '
        Me.WidthPanel.AccessibleDescription = "Specifies the range of widths for the contour plots"
        Me.WidthPanel.AccessibleName = "Furrow Set Width"
        Me.WidthPanel.Controls.Add(Me.ToLabel4)
        Me.WidthPanel.Controls.Add(Me.MaxWidthControl)
        Me.WidthPanel.Controls.Add(Me.MinWidthControl)
        Me.WidthPanel.Controls.Add(Me.WidthLabel)
        Me.WidthPanel.Location = New System.Drawing.Point(8, 56)
        Me.WidthPanel.Name = "WidthPanel"
        Me.WidthPanel.Size = New System.Drawing.Size(336, 32)
        Me.WidthPanel.TabIndex = 1
        '
        'ToLabel4
        '
        Me.ToLabel4.AutoSize = True
        Me.ToLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToLabel4.Location = New System.Drawing.Point(219, 5)
        Me.ToLabel4.Name = "ToLabel4"
        Me.ToLabel4.Size = New System.Drawing.Size(17, 15)
        Me.ToLabel4.TabIndex = 2
        Me.ToLabel4.Text = "to"
        Me.ToLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MaxWidthControl
        '
        Me.MaxWidthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MaxWidthControl.IsCalculated = False
        Me.MaxWidthControl.IsInteger = False
        Me.MaxWidthControl.Location = New System.Drawing.Point(240, 4)
        Me.MaxWidthControl.MaxErrMsg = ""
        Me.MaxWidthControl.MinErrMsg = ""
        Me.MaxWidthControl.Name = "MaxWidthControl"
        Me.MaxWidthControl.Size = New System.Drawing.Size(92, 24)
        Me.MaxWidthControl.TabIndex = 3
        Me.MaxWidthControl.ToBeCalculated = True
        Me.MaxWidthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MaxWidthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MaxWidthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MaxWidthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MaxWidthControl.ValueText = ""
        '
        'MinWidthControl
        '
        Me.MinWidthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MinWidthControl.IsCalculated = False
        Me.MinWidthControl.IsInteger = False
        Me.MinWidthControl.Location = New System.Drawing.Point(152, 4)
        Me.MinWidthControl.MaxErrMsg = ""
        Me.MinWidthControl.MinErrMsg = ""
        Me.MinWidthControl.Name = "MinWidthControl"
        Me.MinWidthControl.Size = New System.Drawing.Size(64, 24)
        Me.MinWidthControl.TabIndex = 1
        Me.MinWidthControl.ToBeCalculated = True
        Me.MinWidthControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MinWidthControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MinWidthControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MinWidthControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MinWidthControl.ValueText = ""
        '
        'WidthLabel
        '
        Me.WidthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WidthLabel.Location = New System.Drawing.Point(8, 4)
        Me.WidthLabel.Name = "WidthLabel"
        Me.WidthLabel.Size = New System.Drawing.Size(138, 23)
        Me.WidthLabel.TabIndex = 0
        Me.WidthLabel.Text = "Furrow Set &Width"
        Me.WidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InflowRatePanel
        '
        Me.InflowRatePanel.AccessibleDescription = "Specifies the range of inflow rates for the contour plots"
        Me.InflowRatePanel.AccessibleName = "Furrow Set Inflow Rate"
        Me.InflowRatePanel.Controls.Add(Me.ToLabel5)
        Me.InflowRatePanel.Controls.Add(Me.InflowRateLabel)
        Me.InflowRatePanel.Controls.Add(Me.MaxInflowRateControl)
        Me.InflowRatePanel.Controls.Add(Me.MinInflowRateControl)
        Me.InflowRatePanel.Location = New System.Drawing.Point(8, 56)
        Me.InflowRatePanel.Name = "InflowRatePanel"
        Me.InflowRatePanel.Size = New System.Drawing.Size(336, 32)
        Me.InflowRatePanel.TabIndex = 1
        '
        'ToLabel5
        '
        Me.ToLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToLabel5.Location = New System.Drawing.Point(220, 4)
        Me.ToLabel5.Name = "ToLabel5"
        Me.ToLabel5.Size = New System.Drawing.Size(16, 23)
        Me.ToLabel5.TabIndex = 2
        Me.ToLabel5.Text = "to"
        Me.ToLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InflowRateLabel
        '
        Me.InflowRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRateLabel.Location = New System.Drawing.Point(8, 5)
        Me.InflowRateLabel.Name = "InflowRateLabel"
        Me.InflowRateLabel.Size = New System.Drawing.Size(144, 23)
        Me.InflowRateLabel.TabIndex = 0
        Me.InflowRateLabel.Text = "Furrow Set Inflow &Rate"
        Me.InflowRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MaxInflowRateControl
        '
        Me.MaxInflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MaxInflowRateControl.IsCalculated = False
        Me.MaxInflowRateControl.IsInteger = False
        Me.MaxInflowRateControl.Location = New System.Drawing.Point(240, 4)
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
        Me.MinInflowRateControl.Location = New System.Drawing.Point(152, 4)
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
        'DesignParametersBox
        '
        Me.DesignParametersBox.AccessibleDescription = "The primary inputs for the Design Analysis"
        Me.DesignParametersBox.AccessibleName = "Contour Options"
        Me.DesignParametersBox.Controls.Add(Me.MinDepthCriterionText)
        Me.DesignParametersBox.Controls.Add(Me.ReflectsLabel)
        Me.DesignParametersBox.Controls.Add(Me.RequiredDepthControl)
        Me.DesignParametersBox.Controls.Add(Me.RequiredDepthLabel)
        Me.DesignParametersBox.Controls.Add(Me.DepthCriteriaControl)
        Me.DesignParametersBox.Controls.Add(Me.DepthCriteriaLabel)
        Me.DesignParametersBox.Controls.Add(Me.InflowRateOption)
        Me.DesignParametersBox.Controls.Add(Me.WidthOption)
        Me.DesignParametersBox.Location = New System.Drawing.Point(8, 24)
        Me.DesignParametersBox.Name = "DesignParametersBox"
        Me.DesignParametersBox.Size = New System.Drawing.Size(352, 165)
        Me.DesignParametersBox.TabIndex = 0
        Me.DesignParametersBox.TabStop = False
        Me.DesignParametersBox.Text = "Contour Options"
        '
        'MinDepthCriterionText
        '
        Me.MinDepthCriterionText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinDepthCriterionText.Location = New System.Drawing.Point(36, 99)
        Me.MinDepthCriterionText.Name = "MinDepthCriterionText"
        Me.MinDepthCriterionText.Size = New System.Drawing.Size(276, 41)
        Me.MinDepthCriterionText.TabIndex = 8
        Me.MinDepthCriterionText.Text = "Design analyses use exclusively the minimum depth as the depth criterion."
        Me.MinDepthCriterionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ReflectsLabel
        '
        Me.ReflectsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectsLabel.Location = New System.Drawing.Point(4, 139)
        Me.ReflectsLabel.Name = "ReflectsLabel"
        Me.ReflectsLabel.Size = New System.Drawing.Size(336, 23)
        Me.ReflectsLabel.TabIndex = 9
        Me.ReflectsLabel.Text = "This box reflects choices made on previous tabs."
        Me.ReflectsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RequiredDepthControl
        '
        Me.RequiredDepthControl.AccessibleDescription = "The required infiltration depth."
        Me.RequiredDepthControl.AccessibleName = "Required Depth"
        Me.RequiredDepthControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RequiredDepthControl.IsCalculated = False
        Me.RequiredDepthControl.IsInteger = False
        Me.RequiredDepthControl.Location = New System.Drawing.Point(234, 70)
        Me.RequiredDepthControl.MaxErrMsg = ""
        Me.RequiredDepthControl.MinErrMsg = ""
        Me.RequiredDepthControl.Name = "RequiredDepthControl"
        Me.RequiredDepthControl.Size = New System.Drawing.Size(112, 24)
        Me.RequiredDepthControl.TabIndex = 5
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
        Me.RequiredDepthLabel.Location = New System.Drawing.Point(8, 70)
        Me.RequiredDepthLabel.Name = "RequiredDepthLabel"
        Me.RequiredDepthLabel.Size = New System.Drawing.Size(220, 23)
        Me.RequiredDepthLabel.TabIndex = 4
        Me.RequiredDepthLabel.Text = "Required Depth, &Dreq"
        Me.RequiredDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DepthCriteriaControl
        '
        Me.DepthCriteriaControl.AccessibleDescription = "Specifies what depth should be used during the calculations."
        Me.DepthCriteriaControl.AccessibleName = "Depth Criteria"
        Me.DepthCriteriaControl.ApplicationValue = -1
        Me.DepthCriteriaControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DepthCriteriaControl.EnableSaveActions = False
        Me.DepthCriteriaControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthCriteriaControl.IsCalculated = False
        Me.DepthCriteriaControl.Location = New System.Drawing.Point(152, 107)
        Me.DepthCriteriaControl.Name = "DepthCriteriaControl"
        Me.DepthCriteriaControl.SelectedIndexSet = False
        Me.DepthCriteriaControl.Size = New System.Drawing.Size(144, 24)
        Me.DepthCriteriaControl.TabIndex = 7
        '
        'DepthCriteriaLabel
        '
        Me.DepthCriteriaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepthCriteriaLabel.Location = New System.Drawing.Point(33, 107)
        Me.DepthCriteriaLabel.Name = "DepthCriteriaLabel"
        Me.DepthCriteriaLabel.Size = New System.Drawing.Size(113, 23)
        Me.DepthCriteriaLabel.TabIndex = 6
        Me.DepthCriteriaLabel.Text = "Depth Criteria"
        Me.DepthCriteriaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InflowRateOption
        '
        Me.InflowRateOption.AccessibleDescription = ""
        Me.InflowRateOption.AccessibleName = ""
        Me.InflowRateOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRateOption.Location = New System.Drawing.Point(24, 19)
        Me.InflowRateOption.Name = "InflowRateOption"
        Me.InflowRateOption.Size = New System.Drawing.Size(204, 24)
        Me.InflowRateOption.TabIndex = 0
        Me.InflowRateOption.Text = "Length and &Width"
        '
        'WidthOption
        '
        Me.WidthOption.AccessibleDescription = ""
        Me.WidthOption.AccessibleName = ""
        Me.WidthOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WidthOption.Location = New System.Drawing.Point(24, 43)
        Me.WidthOption.Name = "WidthOption"
        Me.WidthOption.Size = New System.Drawing.Size(204, 24)
        Me.WidthOption.TabIndex = 2
        Me.WidthOption.Text = "Length and Inflow &Rate"
        '
        'ctl_DesignExecution
        '
        Me.Controls.Add(Me.RunControlBox)
        Me.Controls.Add(Me.DesignAnalysisBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_DesignExecution"
        Me.Size = New System.Drawing.Size(776, 422)
        Me.RunControlBox.ResumeLayout(False)
        Me.SolutionModelBox.ResumeLayout(False)
        Me.DesignAnalysisBox.ResumeLayout(False)
        Me.TuningFactorsBox.ResumeLayout(False)
        Me.ContourDefinitionBox.ResumeLayout(False)
        Me.LengthPanel.ResumeLayout(False)
        Me.LengthPanel.PerformLayout()
        Me.WidthPanel.ResumeLayout(False)
        Me.WidthPanel.PerformLayout()
        Me.InflowRatePanel.ResumeLayout(False)
        Me.DesignParametersBox.ResumeLayout(False)
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

    Private mDesignWorld As DesignWorld

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Public Sub LinkToModel(ByVal _unit As Unit, ByVal _world As DesignWorld)

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

        mDesignWorld = _world
        mMyStore = mUnit.MyStore
        mDictionary = Dictionary.Instance

        ' Link the contained controls to their models & store
        Me.SolutionModelControl.LinkToModel(mMyStore, mSrfrCriteria.SolutionModelProperty)
        Me.CellDensityControl.LinkToModel(mMyStore, mSrfrCriteria.CellDensityProperty)
        Me.EnableDiagnosticsControl.LinkToModel(mMyStore, mSrfrCriteria.EnableDiagnosticsProperty)

        Me.RequiredDepthControl.LinkToModel(mMyStore, mInflowManagement.RequiredDepthProperty)
        Me.DepthCriteriaControl.LinkToModel(mMyStore, mBorderCriteria.InfiltratedDepthCriterionProperty)

        Me.MinLengthControl.LinkToModel(mMyStore, mBorderCriteria.MinContourLengthProperty)
        Me.MaxLengthControl.LinkToModel(mMyStore, mBorderCriteria.MaxContourLengthProperty)
        Me.MinWidthControl.LinkToModel(mMyStore, mBorderCriteria.MinContourWidthProperty)
        Me.MaxWidthControl.LinkToModel(mMyStore, mBorderCriteria.MaxContourWidthProperty)
        Me.MinInflowRateControl.LinkToModel(mMyStore, mBorderCriteria.MinContourInflowRateProperty)
        Me.MaxInflowRateControl.LinkToModel(mMyStore, mBorderCriteria.MaxContourInflowRateProperty)
        Me.ContourGridSizeControl.LinkToModel(mMyStore, mBorderCriteria.GridResolutionProperty)

        ' Furrow parameters
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

        Me.ContourLengthPointControl.LinkToModel(mMyStore, mBorderCriteria.ContourLengthPointProperty)
        Me.ContourWidthPointControl.LinkToModel(mMyStore, mBorderCriteria.ContourWidthPointProperty)
        Me.ContourInflowRatePointControl.LinkToModel(mMyStore, mBorderCriteria.ContourInflowRatePointProperty)

        ' Update language translation
        UpdateLanguage()

        ' Update the control's User Interface
        UpdateUI()

    End Sub

#End Region

#Region " Update UI Methods "

#Region " Design World "
    '
    ' Update the Design World's UI
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mUnit IsNot Nothing) Then
            '
            ' Update System Criteria
            '
            UpdateCrossSection()
            UpdateDepthCriteria()
            UpdateDesignCriteria()

            ' Update SRFR Solution Model & Cell Density
            UpdateSolutionModel()
        End If

    End Sub
    '
    ' Update the Results Control (Buttons)
    '
    Public Sub EnableRunButtons()
        Me.RunDesignButton.Enabled = True
        Me.EstimateTuningFactorsButton.Enabled = True
    End Sub

    Public Sub DisableRunButtons()
        Me.RunDesignButton.Enabled = False
        Me.EstimateTuningFactorsButton.Enabled = False
    End Sub
    '
    ' Update Solution Model selection list & selection
    '
    Private Sub UpdateSolutionModel()
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

    Private Sub AddDesignExecutionErrorWarning(ByVal _type As String,
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

    Private Sub AddDesignExecutionWarning(ByVal _title As String, ByVal _details As String)
        AddDesignExecutionErrorWarning(mDictionary.tWarning.Translated, _title, _details)
    End Sub

    Private Sub AddDesignExecutionError(ByVal _title As String, ByVal _details As String)
        AddDesignExecutionErrorWarning(mDictionary.tError.Translated, _title, _details)
    End Sub

    Public Sub UpdateDesignSetupErrorsWarnings(ByVal analysis As DesignAnalysis)
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
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
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
                    ' Execution Tab
                    DesignAnalysisBox.Text = mDictionary.tBasinBorderDesign.Translated

                    'WidthOption.Text = mDictionary.tBorderWidth.Translated + ", &W"
                    'InflowRateOption.Text = mDictionary.tBorderInflowRate.Translated + ", &Q"

                    WidthLabel.Text = mDictionary.tBorderWidth.Translated
                    InflowRateLabel.Text = mDictionary.tBorderInflowRate.Translated

                    Me.Phi0Control.LinkToModel(mMyStore, mBorderCriteria.Phi0BordersProperty)
                    Me.Phi1Control.LinkToModel(mMyStore, mBorderCriteria.Phi1BordersProperty)
                    Me.Phi2Control.LinkToModel(mMyStore, mBorderCriteria.Phi2BordersProperty)
                    Me.Phi3Control.LinkToModel(mMyStore, mBorderCriteria.Phi3BordersProperty)

                Case Else ' Assume Furrow
                    ' Execution Tab
                    DesignAnalysisBox.Text = mDictionary.tFurrowDesign.Translated

                    'WidthOption.Text = mDictionary.tFurrowSetWidth.Translated + ", &W"
                    'InflowRateOption.Text = mDictionary.tFurrowSetInflowRate.Translated + ", &Q"

                    WidthLabel.Text = mDictionary.tFurrowSetWidth.Translated
                    InflowRateLabel.Text = mDictionary.tFurrowSetInflowRate.Translated

                    Me.Phi0Control.LinkToModel(mMyStore, mBorderCriteria.Phi0FurrowsProperty)
                    Me.Phi1Control.LinkToModel(mMyStore, mBorderCriteria.Phi1FurrowsProperty)
                    Me.Phi2Control.LinkToModel(mMyStore, mBorderCriteria.Phi2FurrowsProperty)
                    Me.Phi3Control.LinkToModel(mMyStore, mBorderCriteria.Phi3FurrowsProperty)

            End Select
        End If
    End Sub

#End Region

#Region " Basin / Border / Furrow Contour Design "
    '
    ' Depth Criteria
    '
    Private Sub UpdateDepthCriteria()
        If Not (mBorderCriteria Is Nothing) Then

            ' Update Depth Criteria selection list
            DepthCriteriaControl.Clear()

            Dim _sel As String = mBorderCriteria.GetFirstInfiltratedDepthCriteriaSelection
            Dim _idx As Integer = 0
            While Not (_sel Is Nothing)
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
    ' Update the UI's Border Design Criteria
    '
    Private Sub UpdateDesignCriteria()
        If Not (mBorderCriteria Is Nothing) Then

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
            While Not (_sel Is Nothing)
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

            Select Case (mBorderCriteria.DesignOption.Value)
                Case DesignOptions.WidthGiven
                    Me.WidthOption.Checked = True

                    Me.WidthPanel.Hide()
                    Me.InflowRatePanel.Show()

                    Me.ContourWidthPointControl.Hide()
                    Me.ContourInflowRatePointControl.Show()

                Case Else ' Assume DesignOptions.InflowRateGiven
                    Me.InflowRateOption.Checked = True

                    Me.InflowRatePanel.Hide()
                    Me.WidthPanel.Show()

                    Me.ContourInflowRatePointControl.Hide()
                    Me.ContourWidthPointControl.Show()

            End Select

        End If
    End Sub

#End Region

#End Region

#Region " UI Event Handlers "

#Region " Basin / Border / Furrow Execution "
    '
    ' Design Option
    '
    Private Sub SelectDesignOption(ByVal _option As DesignOptions)
        If Not (mBorderCriteria Is Nothing) Then
            ' Update Design Option only if the value has changed
            If Not (mBorderCriteria.DesignOption.Value = _option) Then

                ' Set the new value if it has changed
                Dim _designOption As IntegerParameter = mBorderCriteria.DesignOption
                If Not (_designOption.Value = _option) Then
                    mMyStore.MarkForUndo(mDictionary.tDesignOptionChange.ToString)
                    _designOption.Value = _option
                    _designOption.Source = DataStore.Globals.ValueSources.UserEntered
                    mBorderCriteria.DesignOption = _designOption
                End If

            End If
        End If
    End Sub

    Private Sub WidthOption_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) _
    Handles WidthOption.CheckedChanged
        If (WidthOption.Checked) Then
            SelectDesignOption(DesignOptions.WidthGiven)
        End If
    End Sub

    Private Sub InflowRateOption_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) _
    Handles InflowRateOption.CheckedChanged
        If (InflowRateOption.Checked) Then
            SelectDesignOption(DesignOptions.InflowRateGiven)
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
    ' Note - For Design, default tuning point is mid-point of right edge
    '
    Private Sub SetContourLengthPoint(Optional ByVal Reset As Boolean = False)
        Dim lengthPoint As DoubleParameter = mBorderCriteria.ContourLengthPoint
        If Not (lengthPoint.Source = ValueSources.UserEntered) Then
            Reset = True
        End If

        If (Reset) Then
            Dim minLength As Double = mBorderCriteria.MinContourLength.Value
            Dim maxLength As Double = mBorderCriteria.MaxContourLength.Value
            Dim midLength As Double = (minLength + maxLength) / 2

            Dim S0 As Double = mSystemGeometry.AverageSlope

            If (S0 <= MaximumLevelSlope) Then ' Level Basin
                lengthPoint.Value = midLength ' Center
            Else ' Sloping Border
                lengthPoint.Value = maxLength ' Right edge
            End If

            lengthPoint.Source = ValueSources.Calculated
            mBorderCriteria.ContourLengthPoint = lengthPoint
        End If
    End Sub

    Private Sub SetContourWidthPoint(Optional ByVal Reset As Boolean = False)
        Dim widthPoint As DoubleParameter = mBorderCriteria.ContourWidthPoint
        If Not (widthPoint.Source = ValueSources.UserEntered) Then
            Reset = True
        End If

        If (Reset) Then
            Dim minWidth As Double = mBorderCriteria.MinContourWidth.Value
            Dim maxWidth As Double = mBorderCriteria.MaxContourWidth.Value
            widthPoint.Value = (minWidth + maxWidth) / 2.0 ' Horizontal mid-point
            widthPoint.Source = ValueSources.Calculated
            mBorderCriteria.ContourWidthPoint = widthPoint
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
            inflowRate.Value = (minInflowRate + maxInflowRate) / 2.0 ' Horizontal mid-point
            inflowRate.Source = ValueSources.Calculated
            mBorderCriteria.ContourInflowRatePoint = inflowRate
        End If
    End Sub

    Private Sub MinLengthControl_ControlValueChanged() _
    Handles MinLengthControl.ControlValueChanged
        SetContourLengthPoint()
    End Sub

    Private Sub MaxLengthControl_ControlValueChanged() _
    Handles MaxLengthControl.ControlValueChanged
        SetContourLengthPoint()
        MinLengthControl.AltUnits = MaxLengthControl.AltUnits
    End Sub

    Private Sub MinWidthControl_ControlValueChanged() _
    Handles MinWidthControl.ControlValueChanged
        SetContourWidthPoint()
    End Sub

    Private Sub MaxWidthControl_ControlValueChanged() _
    Handles MaxWidthControl.ControlValueChanged
        SetContourWidthPoint()
        MinWidthControl.AltUnits = MaxWidthControl.AltUnits
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

    Private Sub ResetPointButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ResetPointButton.Click
        SetContourLengthPoint(True)
        SetContourWidthPoint(True)
        SetContourInflowRatePoint(True)
    End Sub

#End Region

#Region " Run Control "

    Private Sub EstimateTuningFactorsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EstimateTuningFactorsButton.Click
        Me.Focus()
        mDesignWorld.EstimateDesignTuningFactors()
    End Sub

    Private Sub RunDesignButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RunDesignButton.Click
        Me.Focus()
        mDesignWorld.Run()
    End Sub

    Private Sub AddContourOverlays_Click(ByVal sender As System.Object, ByVal e As EventArgs) _
    Handles AddContourOverlays.Click
        Me.Focus()
        mDesignWorld.AddContourOverlays()
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
