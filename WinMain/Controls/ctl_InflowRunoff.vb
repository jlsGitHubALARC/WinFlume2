
'**********************************************************************************************
' ctl_InflowRunoff - UI for viewing & editing the Inflow Management data
'
' Note - ctl_InflowRunoff is a slimmed-down version of ctl_InflowManagement. It is meant to be
'        used in the Evaluation World. The position of the controls are rearranged to better
'        match other Evaluation World input tabs.  An Instructions field is added to guide the
'        user during data entry.
'
' Only Standard Hydrograph & Tabulated Inflow are supported (no Surge, Cablegation or Drainback)
'
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI
Imports PrintingUI

Public Class ctl_InflowRunoff
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
    Friend WithEvents HydrographGraphicsPanel As DataStore.ctl_Panel
    Friend WithEvents InflowHydrograph As GraphingUI.ex_PictureBox
    Friend WithEvents InflowRunoffLabel As DataStore.ctl_Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents InflowStatsPanel As DataStore.ctl_Panel
    Friend WithEvents AppliedDepthLabel As System.Windows.Forms.Label
    Friend WithEvents AppliedDepthValue As System.Windows.Forms.Label
    Friend WithEvents InflowGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents InflowMethodControl As DataStore.ctl_SelectParameter
    Friend WithEvents StdHydroPanel As DataStore.ctl_Panel
    Friend WithEvents StdHydroControl As WinMain.ctl_StdHydro
    Friend WithEvents TabulatedInflowPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedInflowControl As DataStore.ctl_DataTableParameter
    Friend WithEvents RunoffGroupBox As DataStore.ctl_GroupBox
    Friend WithEvents TabulatedRunoffControl As DataStore.ctl_DataTableParameter
    Friend WithEvents DownstreamRunoffGroup As DataStore.ctl_GroupBox
    Friend WithEvents OpenEndButton As DataStore.ctl_RadioButton
    Friend WithEvents InflowRunoffStatsPanel As DataStore.ctl_Panel
    Friend WithEvents RunoffDepthLabel As DataStore.ctl_Label
    Friend WithEvents MinusLabel As System.Windows.Forms.Label
    Friend WithEvents InfiltratedDepthLabel As DataStore.ctl_Label
    Friend WithEvents EqualsLabel2 As System.Windows.Forms.Label
    Friend WithEvents DepthAppliedControl As System.Windows.Forms.Label
    Friend WithEvents DepthAppliedLabel As DataStore.ctl_Label
    Friend WithEvents InfiltratedDepthControl As System.Windows.Forms.Label
    Friend WithEvents RunoffDepthControl As System.Windows.Forms.Label
    Friend WithEvents AverageDepthsLabel As DataStore.ctl_Label
    Friend WithEvents InflowRunoffInstructions As WinMain.ErrorRichTextBox
    Friend WithEvents RunoffMeasurementsBox As DataStore.ctl_GroupBox
    Friend WithEvents RunoffHydrographCheck As DataStore.ctl_CheckParameter
    Friend WithEvents UseRunoffCheck As DataStore.ctl_CheckParameter
    Friend WithEvents RunoffPartialHydrograph As DataStore.ctl_CheckParameter
    Friend WithEvents InflowPartialHydrograph As DataStore.ctl_CheckParameter
    Friend WithEvents BlockedEndButton As DataStore.ctl_RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.HydrographGraphicsPanel = New DataStore.ctl_Panel
        Me.InflowHydrograph = New GraphingUI.ex_PictureBox
        Me.InflowRunoffLabel = New DataStore.ctl_Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.InflowStatsPanel = New DataStore.ctl_Panel
        Me.AppliedDepthValue = New System.Windows.Forms.Label
        Me.AppliedDepthLabel = New System.Windows.Forms.Label
        Me.InflowGroupBox = New DataStore.ctl_GroupBox
        Me.TabulatedInflowPanel = New DataStore.ctl_Panel
        Me.InflowPartialHydrograph = New DataStore.ctl_CheckParameter
        Me.TabulatedInflowControl = New DataStore.ctl_DataTableParameter
        Me.InflowMethodControl = New DataStore.ctl_SelectParameter
        Me.StdHydroPanel = New DataStore.ctl_Panel
        Me.StdHydroControl = New WinMain.ctl_StdHydro
        Me.RunoffGroupBox = New DataStore.ctl_GroupBox
        Me.RunoffPartialHydrograph = New DataStore.ctl_CheckParameter
        Me.RunoffMeasurementsBox = New DataStore.ctl_GroupBox
        Me.UseRunoffCheck = New DataStore.ctl_CheckParameter
        Me.RunoffHydrographCheck = New DataStore.ctl_CheckParameter
        Me.TabulatedRunoffControl = New DataStore.ctl_DataTableParameter
        Me.DownstreamRunoffGroup = New DataStore.ctl_GroupBox
        Me.OpenEndButton = New DataStore.ctl_RadioButton
        Me.BlockedEndButton = New DataStore.ctl_RadioButton
        Me.AverageDepthsLabel = New DataStore.ctl_Label
        Me.RunoffDepthControl = New System.Windows.Forms.Label
        Me.InfiltratedDepthControl = New System.Windows.Forms.Label
        Me.DepthAppliedLabel = New DataStore.ctl_Label
        Me.DepthAppliedControl = New System.Windows.Forms.Label
        Me.EqualsLabel2 = New System.Windows.Forms.Label
        Me.InfiltratedDepthLabel = New DataStore.ctl_Label
        Me.MinusLabel = New System.Windows.Forms.Label
        Me.RunoffDepthLabel = New DataStore.ctl_Label
        Me.InflowRunoffStatsPanel = New DataStore.ctl_Panel
        Me.InflowRunoffInstructions = New WinMain.ErrorRichTextBox
        Me.HydrographGraphicsPanel.SuspendLayout()
        CType(Me.InflowHydrograph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InflowStatsPanel.SuspendLayout()
        Me.InflowGroupBox.SuspendLayout()
        Me.TabulatedInflowPanel.SuspendLayout()
        CType(Me.TabulatedInflowControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StdHydroPanel.SuspendLayout()
        Me.RunoffGroupBox.SuspendLayout()
        Me.RunoffMeasurementsBox.SuspendLayout()
        CType(Me.TabulatedRunoffControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DownstreamRunoffGroup.SuspendLayout()
        Me.InflowRunoffStatsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'HydrographGraphicsPanel
        '
        Me.HydrographGraphicsPanel.Controls.Add(Me.InflowHydrograph)
        Me.HydrographGraphicsPanel.Location = New System.Drawing.Point(460, 4)
        Me.HydrographGraphicsPanel.Name = "HydrographGraphicsPanel"
        Me.HydrographGraphicsPanel.Size = New System.Drawing.Size(315, 150)
        Me.HydrographGraphicsPanel.TabIndex = 3
        '
        'InflowHydrograph
        '
        Me.InflowHydrograph.AccessibleDescription = "A copyable bitmap image"
        Me.InflowHydrograph.AccessibleName = "Inflow / Runoff Hydrographs"
        Me.InflowHydrograph.Location = New System.Drawing.Point(3, 3)
        Me.InflowHydrograph.Name = "InflowHydrograph"
        Me.InflowHydrograph.Size = New System.Drawing.Size(309, 144)
        Me.InflowHydrograph.TabIndex = 16
        Me.InflowHydrograph.TabStop = False
        Me.InflowHydrograph.Text = "Bitmap Diagram"
        '
        'InflowRunoffLabel
        '
        Me.InflowRunoffLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRunoffLabel.Location = New System.Drawing.Point(10, 4)
        Me.InflowRunoffLabel.Name = "InflowRunoffLabel"
        Me.InflowRunoffLabel.Size = New System.Drawing.Size(444, 24)
        Me.InflowRunoffLabel.TabIndex = 0
        Me.InflowRunoffLabel.Text = "Inflow / Runoff"
        Me.InflowRunoffLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'InflowStatsPanel
        '
        Me.InflowStatsPanel.AccessibleDescription = "Summary of inflow measurements."
        Me.InflowStatsPanel.AccessibleName = "Inflow summary"
        Me.InflowStatsPanel.Controls.Add(Me.AppliedDepthValue)
        Me.InflowStatsPanel.Controls.Add(Me.AppliedDepthLabel)
        Me.InflowStatsPanel.Location = New System.Drawing.Point(460, 158)
        Me.InflowStatsPanel.Name = "InflowStatsPanel"
        Me.InflowStatsPanel.Size = New System.Drawing.Size(316, 95)
        Me.InflowStatsPanel.TabIndex = 4
        '
        'AppliedDepthValue
        '
        Me.AppliedDepthValue.Location = New System.Drawing.Point(220, 28)
        Me.AppliedDepthValue.Name = "AppliedDepthValue"
        Me.AppliedDepthValue.Size = New System.Drawing.Size(80, 23)
        Me.AppliedDepthValue.TabIndex = 1
        Me.AppliedDepthValue.Text = "100 mm"
        Me.AppliedDepthValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AppliedDepthLabel
        '
        Me.AppliedDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppliedDepthLabel.Location = New System.Drawing.Point(5, 28)
        Me.AppliedDepthLabel.Name = "AppliedDepthLabel"
        Me.AppliedDepthLabel.Size = New System.Drawing.Size(210, 23)
        Me.AppliedDepthLabel.TabIndex = 0
        Me.AppliedDepthLabel.Text = "Depth Applied (Dapp):"
        Me.AppliedDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InflowGroupBox
        '
        Me.InflowGroupBox.AccessibleDescription = "Measurements describing the flow of water onto the field."
        Me.InflowGroupBox.AccessibleName = "Inflow"
        Me.InflowGroupBox.Controls.Add(Me.TabulatedInflowPanel)
        Me.InflowGroupBox.Controls.Add(Me.InflowMethodControl)
        Me.InflowGroupBox.Controls.Add(Me.StdHydroPanel)
        Me.InflowGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowGroupBox.Location = New System.Drawing.Point(10, 30)
        Me.InflowGroupBox.Name = "InflowGroupBox"
        Me.InflowGroupBox.Size = New System.Drawing.Size(228, 386)
        Me.InflowGroupBox.TabIndex = 1
        Me.InflowGroupBox.TabStop = False
        Me.InflowGroupBox.Text = "&Inflow"
        '
        'TabulatedInflowPanel
        '
        Me.TabulatedInflowPanel.AccessibleDescription = "Specifies the inflow as a table of time and rate values."
        Me.TabulatedInflowPanel.AccessibleName = "Tabulated Inflow"
        Me.TabulatedInflowPanel.Controls.Add(Me.InflowPartialHydrograph)
        Me.TabulatedInflowPanel.Controls.Add(Me.TabulatedInflowControl)
        Me.TabulatedInflowPanel.Location = New System.Drawing.Point(3, 60)
        Me.TabulatedInflowPanel.Name = "TabulatedInflowPanel"
        Me.TabulatedInflowPanel.Size = New System.Drawing.Size(222, 322)
        Me.TabulatedInflowPanel.TabIndex = 2
        '
        'InflowPartialHydrograph
        '
        Me.InflowPartialHydrograph.AccessibleDescription = "Checkbox indicating the Inflow Table is incomplete."
        Me.InflowPartialHydrograph.AccessibleName = "Inflow Partial Hydrograph"
        Me.InflowPartialHydrograph.AlwaysChecked = False
        Me.InflowPartialHydrograph.AutoSize = True
        Me.InflowPartialHydrograph.ErrorMessage = Nothing
        Me.InflowPartialHydrograph.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowPartialHydrograph.Location = New System.Drawing.Point(11, 295)
        Me.InflowPartialHydrograph.Name = "InflowPartialHydrograph"
        Me.InflowPartialHydrograph.Size = New System.Drawing.Size(146, 21)
        Me.InflowPartialHydrograph.TabIndex = 1
        Me.InflowPartialHydrograph.Text = "&Partial Hydrograph"
        Me.InflowPartialHydrograph.UncheckAttemptMessage = Nothing
        Me.InflowPartialHydrograph.UseVisualStyleBackColor = True
        '
        'TabulatedInflowControl
        '
        Me.TabulatedInflowControl.AccessibleDescription = "Table for entering tabulated inflow."
        Me.TabulatedInflowControl.AccessibleName = "Inflow Table"
        Me.TabulatedInflowControl.AllRowsFixed = False
        Me.TabulatedInflowControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedInflowControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedInflowControl.CaptionText = "Inflow Table"
        Me.TabulatedInflowControl.CausesValidation = False
        Me.TabulatedInflowControl.ColumnWidthRatios = Nothing
        Me.TabulatedInflowControl.DataMember = ""
        Me.TabulatedInflowControl.EnableSaveActions = False
        Me.TabulatedInflowControl.FirstColumnIncreases = True
        Me.TabulatedInflowControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedInflowControl.FirstColumnMinimum = 0
        Me.TabulatedInflowControl.FirstRowFixed = True
        Me.TabulatedInflowControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedInflowControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedInflowControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedInflowControl.Location = New System.Drawing.Point(11, 80)
        Me.TabulatedInflowControl.MaxRows = 250
        Me.TabulatedInflowControl.MinRows = 2
        Me.TabulatedInflowControl.Name = "TabulatedInflowControl"
        Me.TabulatedInflowControl.SecondColumnIncreases = False
        Me.TabulatedInflowControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedInflowControl.SecondColumnMinimum = 0
        Me.TabulatedInflowControl.Size = New System.Drawing.Size(200, 212)
        Me.TabulatedInflowControl.TabIndex = 0
        Me.TabulatedInflowControl.TableReadonly = False
        '
        'InflowMethodControl
        '
        Me.InflowMethodControl.AccessibleDescription = "Selects the mechanism used to deliver water to the field."
        Me.InflowMethodControl.AccessibleName = "Inflow Method"
        Me.InflowMethodControl.ApplicationValue = -1
        Me.InflowMethodControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InflowMethodControl.EnableSaveActions = False
        Me.InflowMethodControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowMethodControl.IsCalculated = False
        Me.InflowMethodControl.ItemHeight = 16
        Me.InflowMethodControl.Location = New System.Drawing.Point(14, 25)
        Me.InflowMethodControl.Name = "InflowMethodControl"
        Me.InflowMethodControl.SelectedIndexSet = False
        Me.InflowMethodControl.Size = New System.Drawing.Size(200, 24)
        Me.InflowMethodControl.TabIndex = 1
        '
        'StdHydroPanel
        '
        Me.StdHydroPanel.AccessibleDescription = "Specifies the Inflow Rate, Cutoff and Cutback Options associated with the Standar" & _
            "d Hydograph method."
        Me.StdHydroPanel.AccessibleName = "Standard Hydrograph"
        Me.StdHydroPanel.Controls.Add(Me.StdHydroControl)
        Me.StdHydroPanel.Location = New System.Drawing.Point(3, 60)
        Me.StdHydroPanel.Name = "StdHydroPanel"
        Me.StdHydroPanel.Size = New System.Drawing.Size(222, 322)
        Me.StdHydroPanel.TabIndex = 2
        '
        'StdHydroControl
        '
        Me.StdHydroControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StdHydroControl.Location = New System.Drawing.Point(3, 3)
        Me.StdHydroControl.Margin = New System.Windows.Forms.Padding(4)
        Me.StdHydroControl.Name = "StdHydroControl"
        Me.StdHydroControl.Size = New System.Drawing.Size(216, 290)
        Me.StdHydroControl.TabIndex = 0
        '
        'RunoffGroupBox
        '
        Me.RunoffGroupBox.AccessibleDescription = "Measurements describing the flow of water off the field."
        Me.RunoffGroupBox.AccessibleName = "Runoff"
        Me.RunoffGroupBox.Controls.Add(Me.RunoffPartialHydrograph)
        Me.RunoffGroupBox.Controls.Add(Me.RunoffMeasurementsBox)
        Me.RunoffGroupBox.Controls.Add(Me.TabulatedRunoffControl)
        Me.RunoffGroupBox.Controls.Add(Me.DownstreamRunoffGroup)
        Me.RunoffGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunoffGroupBox.Location = New System.Drawing.Point(244, 30)
        Me.RunoffGroupBox.Name = "RunoffGroupBox"
        Me.RunoffGroupBox.Size = New System.Drawing.Size(210, 386)
        Me.RunoffGroupBox.TabIndex = 2
        Me.RunoffGroupBox.TabStop = False
        Me.RunoffGroupBox.Text = "&Runoff"
        '
        'RunoffPartialHydrograph
        '
        Me.RunoffPartialHydrograph.AccessibleDescription = "Checkbox indicating the Runoff Table is incomplete."
        Me.RunoffPartialHydrograph.AccessibleName = "Runoff Partial Hydrograph"
        Me.RunoffPartialHydrograph.AlwaysChecked = False
        Me.RunoffPartialHydrograph.AutoSize = True
        Me.RunoffPartialHydrograph.ErrorMessage = Nothing
        Me.RunoffPartialHydrograph.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunoffPartialHydrograph.Location = New System.Drawing.Point(11, 355)
        Me.RunoffPartialHydrograph.Name = "RunoffPartialHydrograph"
        Me.RunoffPartialHydrograph.Size = New System.Drawing.Size(146, 21)
        Me.RunoffPartialHydrograph.TabIndex = 4
        Me.RunoffPartialHydrograph.Text = "P&artial Hydrograph"
        Me.RunoffPartialHydrograph.UncheckAttemptMessage = Nothing
        Me.RunoffPartialHydrograph.UseVisualStyleBackColor = True
        '
        'RunoffMeasurementsBox
        '
        Me.RunoffMeasurementsBox.AccessibleDescription = "Selects if runoff data is available and if it should be used for volume balance c" & _
            "alculations."
        Me.RunoffMeasurementsBox.AccessibleName = "Field Measurements"
        Me.RunoffMeasurementsBox.Controls.Add(Me.UseRunoffCheck)
        Me.RunoffMeasurementsBox.Controls.Add(Me.RunoffHydrographCheck)
        Me.RunoffMeasurementsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunoffMeasurementsBox.Location = New System.Drawing.Point(5, 70)
        Me.RunoffMeasurementsBox.Name = "RunoffMeasurementsBox"
        Me.RunoffMeasurementsBox.Size = New System.Drawing.Size(200, 66)
        Me.RunoffMeasurementsBox.TabIndex = 2
        Me.RunoffMeasurementsBox.TabStop = False
        Me.RunoffMeasurementsBox.Text = "Field Measurements"
        '
        'UseRunoffCheck
        '
        Me.UseRunoffCheck.AlwaysChecked = False
        Me.UseRunoffCheck.AutoSize = True
        Me.UseRunoffCheck.ErrorMessage = Nothing
        Me.UseRunoffCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseRunoffCheck.Location = New System.Drawing.Point(15, 40)
        Me.UseRunoffCheck.Name = "UseRunoffCheck"
        Me.UseRunoffCheck.Size = New System.Drawing.Size(173, 21)
        Me.UseRunoffCheck.TabIndex = 1
        Me.UseRunoffCheck.Text = "&Use for VB calculations"
        Me.UseRunoffCheck.UncheckAttemptMessage = Nothing
        Me.UseRunoffCheck.UseVisualStyleBackColor = True
        '
        'RunoffHydrographCheck
        '
        Me.RunoffHydrographCheck.AlwaysChecked = False
        Me.RunoffHydrographCheck.AutoSize = True
        Me.RunoffHydrographCheck.ErrorMessage = Nothing
        Me.RunoffHydrographCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunoffHydrographCheck.Location = New System.Drawing.Point(15, 20)
        Me.RunoffHydrographCheck.Name = "RunoffHydrographCheck"
        Me.RunoffHydrographCheck.Size = New System.Drawing.Size(147, 21)
        Me.RunoffHydrographCheck.TabIndex = 0
        Me.RunoffHydrographCheck.Text = "I &Have Runoff Data"
        Me.RunoffHydrographCheck.UncheckAttemptMessage = Nothing
        Me.RunoffHydrographCheck.UseVisualStyleBackColor = True
        '
        'TabulatedRunoffControl
        '
        Me.TabulatedRunoffControl.AccessibleDescription = "Table for entering tabulated runoff."
        Me.TabulatedRunoffControl.AccessibleName = "Runoff Table"
        Me.TabulatedRunoffControl.AllRowsFixed = False
        Me.TabulatedRunoffControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.TabulatedRunoffControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.TabulatedRunoffControl.CaptionText = "Runoff Table"
        Me.TabulatedRunoffControl.CausesValidation = False
        Me.TabulatedRunoffControl.ColumnWidthRatios = Nothing
        Me.TabulatedRunoffControl.DataMember = ""
        Me.TabulatedRunoffControl.EnableSaveActions = False
        Me.TabulatedRunoffControl.FirstColumnIncreases = True
        Me.TabulatedRunoffControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedRunoffControl.FirstColumnMinimum = 0
        Me.TabulatedRunoffControl.FirstRowFixed = False
        Me.TabulatedRunoffControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabulatedRunoffControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TabulatedRunoffControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.TabulatedRunoffControl.Location = New System.Drawing.Point(11, 140)
        Me.TabulatedRunoffControl.MaxRows = 250
        Me.TabulatedRunoffControl.MinRows = 0
        Me.TabulatedRunoffControl.Name = "TabulatedRunoffControl"
        Me.TabulatedRunoffControl.SecondColumnIncreases = False
        Me.TabulatedRunoffControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedRunoffControl.SecondColumnMinimum = 0
        Me.TabulatedRunoffControl.Size = New System.Drawing.Size(188, 212)
        Me.TabulatedRunoffControl.TabIndex = 3
        Me.TabulatedRunoffControl.TableReadonly = False
        '
        'DownstreamRunoffGroup
        '
        Me.DownstreamRunoffGroup.AccessibleDescription = "Selects whether or not runoff is allowed."
        Me.DownstreamRunoffGroup.AccessibleName = "Downstream Condition"
        Me.DownstreamRunoffGroup.Controls.Add(Me.OpenEndButton)
        Me.DownstreamRunoffGroup.Controls.Add(Me.BlockedEndButton)
        Me.DownstreamRunoffGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownstreamRunoffGroup.Location = New System.Drawing.Point(5, 20)
        Me.DownstreamRunoffGroup.Name = "DownstreamRunoffGroup"
        Me.DownstreamRunoffGroup.Size = New System.Drawing.Size(200, 44)
        Me.DownstreamRunoffGroup.TabIndex = 1
        Me.DownstreamRunoffGroup.TabStop = False
        Me.DownstreamRunoffGroup.Text = "Downstream Condition"
        '
        'OpenEndButton
        '
        Me.OpenEndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenEndButton.Location = New System.Drawing.Point(8, 15)
        Me.OpenEndButton.Name = "OpenEndButton"
        Me.OpenEndButton.Size = New System.Drawing.Size(95, 24)
        Me.OpenEndButton.TabIndex = 0
        Me.OpenEndButton.Text = "&Open End"
        '
        'BlockedEndButton
        '
        Me.BlockedEndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockedEndButton.Location = New System.Drawing.Point(109, 15)
        Me.BlockedEndButton.Name = "BlockedEndButton"
        Me.BlockedEndButton.Size = New System.Drawing.Size(87, 24)
        Me.BlockedEndButton.TabIndex = 1
        Me.BlockedEndButton.Text = "Bloc&ked"
        '
        'AverageDepthsLabel
        '
        Me.AverageDepthsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AverageDepthsLabel.Location = New System.Drawing.Point(21, 4)
        Me.AverageDepthsLabel.Name = "AverageDepthsLabel"
        Me.AverageDepthsLabel.Size = New System.Drawing.Size(208, 23)
        Me.AverageDepthsLabel.TabIndex = 1
        Me.AverageDepthsLabel.Text = "Average Depths:"
        Me.AverageDepthsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RunoffDepthControl
        '
        Me.RunoffDepthControl.AccessibleDescription = "Displays average depth of runoff water."
        Me.RunoffDepthControl.AccessibleName = "Runoff Depth"
        Me.RunoffDepthControl.Location = New System.Drawing.Point(230, 48)
        Me.RunoffDepthControl.Name = "RunoffDepthControl"
        Me.RunoffDepthControl.Size = New System.Drawing.Size(80, 23)
        Me.RunoffDepthControl.TabIndex = 5
        Me.RunoffDepthControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InfiltratedDepthControl
        '
        Me.InfiltratedDepthControl.AccessibleDescription = "Displays average depth of water that infiltrated into field as Depth Applied - Ru" & _
            "noff Depth."
        Me.InfiltratedDepthControl.AccessibleName = "Infiltrated Depth"
        Me.InfiltratedDepthControl.Location = New System.Drawing.Point(230, 68)
        Me.InfiltratedDepthControl.Name = "InfiltratedDepthControl"
        Me.InfiltratedDepthControl.Size = New System.Drawing.Size(80, 23)
        Me.InfiltratedDepthControl.TabIndex = 7
        Me.InfiltratedDepthControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DepthAppliedLabel
        '
        Me.DepthAppliedLabel.Location = New System.Drawing.Point(16, 28)
        Me.DepthAppliedLabel.Name = "DepthAppliedLabel"
        Me.DepthAppliedLabel.Size = New System.Drawing.Size(210, 23)
        Me.DepthAppliedLabel.TabIndex = 2
        Me.DepthAppliedLabel.Text = "Depth Applied (Dapp):"
        Me.DepthAppliedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DepthAppliedControl
        '
        Me.DepthAppliedControl.AccessibleDescription = "Displays average depth of water applied to the field."
        Me.DepthAppliedControl.AccessibleName = "Depth Applied"
        Me.DepthAppliedControl.Location = New System.Drawing.Point(230, 28)
        Me.DepthAppliedControl.Name = "DepthAppliedControl"
        Me.DepthAppliedControl.Size = New System.Drawing.Size(80, 23)
        Me.DepthAppliedControl.TabIndex = 3
        Me.DepthAppliedControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EqualsLabel2
        '
        Me.EqualsLabel2.Location = New System.Drawing.Point(7, 68)
        Me.EqualsLabel2.Name = "EqualsLabel2"
        Me.EqualsLabel2.Size = New System.Drawing.Size(16, 23)
        Me.EqualsLabel2.TabIndex = 35
        Me.EqualsLabel2.Text = "="
        Me.EqualsLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InfiltratedDepthLabel
        '
        Me.InfiltratedDepthLabel.Location = New System.Drawing.Point(27, 68)
        Me.InfiltratedDepthLabel.Name = "InfiltratedDepthLabel"
        Me.InfiltratedDepthLabel.Size = New System.Drawing.Size(200, 23)
        Me.InfiltratedDepthLabel.TabIndex = 6
        Me.InfiltratedDepthLabel.Text = "Depth Infiltrated (Dinf):"
        Me.InfiltratedDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MinusLabel
        '
        Me.MinusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinusLabel.Location = New System.Drawing.Point(7, 49)
        Me.MinusLabel.Name = "MinusLabel"
        Me.MinusLabel.Size = New System.Drawing.Size(16, 23)
        Me.MinusLabel.TabIndex = 37
        Me.MinusLabel.Text = "-"
        Me.MinusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RunoffDepthLabel
        '
        Me.RunoffDepthLabel.Location = New System.Drawing.Point(27, 48)
        Me.RunoffDepthLabel.Name = "RunoffDepthLabel"
        Me.RunoffDepthLabel.Size = New System.Drawing.Size(200, 23)
        Me.RunoffDepthLabel.TabIndex = 4
        Me.RunoffDepthLabel.Text = "Runoff (Dro):"
        Me.RunoffDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InflowRunoffStatsPanel
        '
        Me.InflowRunoffStatsPanel.AccessibleDescription = "Summary of inflow and runoff measurements."
        Me.InflowRunoffStatsPanel.AccessibleName = "Inflow / Runoff summary"
        Me.InflowRunoffStatsPanel.Controls.Add(Me.RunoffDepthLabel)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.MinusLabel)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.InfiltratedDepthLabel)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.EqualsLabel2)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.DepthAppliedControl)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.DepthAppliedLabel)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.InfiltratedDepthControl)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.RunoffDepthControl)
        Me.InflowRunoffStatsPanel.Controls.Add(Me.AverageDepthsLabel)
        Me.InflowRunoffStatsPanel.Location = New System.Drawing.Point(460, 158)
        Me.InflowRunoffStatsPanel.Name = "InflowRunoffStatsPanel"
        Me.InflowRunoffStatsPanel.Size = New System.Drawing.Size(316, 95)
        Me.InflowRunoffStatsPanel.TabIndex = 4
        '
        'InflowRunoffInstructions
        '
        Me.InflowRunoffInstructions.AccessibleDescription = "Summary of the input and use of inflow and runoff measurements."
        Me.InflowRunoffInstructions.AccessibleName = "Inflow / Runoff summary"
        Me.InflowRunoffInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.InflowRunoffInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.InflowRunoffInstructions.Location = New System.Drawing.Point(460, 260)
        Me.InflowRunoffInstructions.Name = "InflowRunoffInstructions"
        Me.InflowRunoffInstructions.ReadOnly = True
        Me.InflowRunoffInstructions.Size = New System.Drawing.Size(312, 156)
        Me.InflowRunoffInstructions.TabIndex = 5
        Me.InflowRunoffInstructions.Text = ""
        '
        'ctl_InflowRunoff
        '
        Me.AccessibleDescription = "Measurements describing the flow of water on and off field."
        Me.AccessibleName = "Inflow / Runoff"
        Me.Controls.Add(Me.InflowRunoffInstructions)
        Me.Controls.Add(Me.InflowGroupBox)
        Me.Controls.Add(Me.HydrographGraphicsPanel)
        Me.Controls.Add(Me.InflowRunoffLabel)
        Me.Controls.Add(Me.RunoffGroupBox)
        Me.Controls.Add(Me.InflowRunoffStatsPanel)
        Me.Controls.Add(Me.InflowStatsPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_InflowRunoff"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.HydrographGraphicsPanel.ResumeLayout(False)
        CType(Me.InflowHydrograph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InflowStatsPanel.ResumeLayout(False)
        Me.InflowGroupBox.ResumeLayout(False)
        Me.TabulatedInflowPanel.ResumeLayout(False)
        Me.TabulatedInflowPanel.PerformLayout()
        CType(Me.TabulatedInflowControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StdHydroPanel.ResumeLayout(False)
        Me.RunoffGroupBox.ResumeLayout(False)
        Me.RunoffGroupBox.PerformLayout()
        Me.RunoffMeasurementsBox.ResumeLayout(False)
        Me.RunoffMeasurementsBox.PerformLayout()
        CType(Me.TabulatedRunoffControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DownstreamRunoffGroup.ResumeLayout(False)
        Me.InflowRunoffStatsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' References to model objects
    '
    Private mUnit As Unit
    Private mWorld As World
    Private mField As Field
    Private mFarm As Farm
    Private WithEvents mWinSRFR As WinSRFR

    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mEventCriteria As EventCriteria

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance

    Private mDictionary As Dictionary
    Private mMyStore As DataStore.ObjectNode
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish links to model objects and update UI
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal worldWindow As WorldWindow)

        Debug.Assert(_unit IsNot Nothing)

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        mWorldWindow = worldWindow

        ' Link the contained controls to their models & store
        Me.OpenEndButton.LinkToModel(mMyStore, mSystemGeometry.DownstreamConditionProperty, DownstreamConditions.OpenEnd)
        Me.BlockedEndButton.LinkToModel(mMyStore, mSystemGeometry.DownstreamConditionProperty, DownstreamConditions.BlockedEnd)

        Me.RunoffHydrographCheck.LinkToModel(mMyStore, mInflowManagement.RunoffMeasuredProperty)
        Me.UseRunoffCheck.LinkToModel(mMyStore, mInflowManagement.RunoffUsedProperty)

        Me.InflowMethodControl.LinkToModel(mMyStore, mInflowManagement.InflowMethodProperty)

        ' Inflow controls
        Me.StdHydroControl.LinkToModel(mUnit)

        ' Tabulated Inflow control
        Me.TabulatedInflowControl.LinkToModel(mMyStore, mInflowManagement.TabulatedInflowProperty)
        Me.TabulatedInflowControl.UpdateUI()

        Me.InflowPartialHydrograph.LinkToModel(mMyStore, mInflowManagement.TabulatedInflowIncompleteProperty)

        ' Tabulated Runoff control
        Me.TabulatedRunoffControl.LinkToModel(mMyStore, mInflowManagement.TabulatedRunoffProperty)
        Me.TabulatedRunoffControl.UpdateUI()

        Me.RunoffPartialHydrograph.LinkToModel(mMyStore, mInflowManagement.TabulatedRunoffIncompleteProperty)

        ' Update language translation
        UpdateLanguage()

        ' Update this control's User Interface
        UpdateUI()

    End Sub
    '
    ' WinSRFR changes
    '
    Private Sub WinSRFR_Updated(ByVal reason As WinSRFR.Reasons) _
    Handles mWinSRFR.WinSrfrUpdated

        Select Case reason
            Case WinSRFR.Reasons.Language
                UpdateLanguage()
        End Select
    End Sub
    '
    ' Update UI when DataStore changes
    '
    Private Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateUI()
    End Sub

    Private Sub EventCriteria_PropertyChanged(ByVal _reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateUI()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        ' Update the UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then
            UpdateCrossSection()
            UpdateInflow()
            UpdateRunoff()

            StdHydroControl.UpdateUI()

            UpdateInstructions()
            UpdateGraphics()
        End If
    End Sub
    '
    ' Update the display of the Cross Section related UI
    '
    Private Sub UpdateCrossSection()
        Dim name As String = mSystemGeometry.CrossSectionName()
        Me.InflowRunoffLabel.Text = name
    End Sub
    '
    ' Update the Inflow method selection list & selection
    '
    Private Sub UpdateInflow()

        ' Update selection list
        Dim inflowMethod As Integer = mInflowManagement.InflowMethod.Value
        Dim selection As String = String.Empty
        Dim idx As Integer = 0

        InflowMethodControl.Clear()

        Dim ok As Boolean = mInflowManagement.GetFirstInflowMethodSelection(selection)
        While (selection IsNot Nothing)
            If (ok) Then
                InflowMethodControl.Add(selection, idx, True)
            ElseIf (inflowMethod = idx) Then
                InflowMethodControl.Add(selection, idx, False)
            End If
            ok = mInflowManagement.GetNextInflowMethodSelection(selection)
            idx += 1
        End While

        ' Update selection
        InflowMethodControl.UpdateUI()

        ' Hide / Show corresponding UI panels
        Select Case mInflowManagement.InflowMethod.Value

            Case InflowMethods.TabulatedInflow
                StdHydroPanel.Hide()
                TabulatedInflowPanel.Show()

                Dim eventType As EventAnalysisTypes = mEventCriteria.EventAnalysisType.Value
                If (eventType = EventAnalysisTypes.MerriamKellerAnalysis) Then
                    Me.InflowPartialHydrograph.Hide()
                Else
                    Me.InflowPartialHydrograph.Show()
                End If

                TabulatedInflowControl.UpdateUI()
                TabulatedRunoffControl.UpdateUI()

            Case Else ' Assume StandardHydrograph
                TabulatedInflowPanel.Hide()
                StdHydroPanel.Show()

                TabulatedRunoffControl.UpdateUI()
        End Select

    End Sub
    '
    ' Update display of Runoff table
    '
    Private Sub UpdateRunoff()

        ' Can't have Runoff if downstream end is blocked
        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
            RunoffPartialHydrograph.Hide()
            TabulatedRunoffControl.Hide()
            InflowRunoffStatsPanel.Hide()
            RunoffMeasurementsBox.Hide()
            InflowStatsPanel.Show()
        Else
            InflowStatsPanel.Hide()
            RunoffMeasurementsBox.Show()
            InflowRunoffStatsPanel.Show()

            Dim eventType As EventAnalysisTypes = mEventCriteria.EventAnalysisType.Value
            Select Case (eventType)

                Case EventAnalysisTypes.InfiltratedProfileAnalysis
                    RunoffMeasured(EventCriteria.Prerequisites.Useful)
                Case EventAnalysisTypes.TwoPointAnalysis
                    RunoffMeasured(EventCriteria.Prerequisites.Useful)
                Case EventAnalysisTypes.MerriamKellerAnalysis
                    If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
                        RunoffMeasured(EventCriteria.Prerequisites.Required)
                    Else ' BlockedEnd
                        RunoffMeasured(EventCriteria.Prerequisites.NotUsed)
                    End If
                Case EventAnalysisTypes.EvalueAnalysis
                    If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
                        RunoffMeasured(EventCriteria.Prerequisites.UsefulVB)
                    Else ' BlockedEnd
                        RunoffMeasured(EventCriteria.Prerequisites.NotUsed)
                    End If
                Case EventAnalysisTypes.ErosionAnalysis
                    RunoffMeasured(EventCriteria.Prerequisites.NotUsed)
                Case Else
                    Debug.Assert(False, "Support for this Event Analysis Type must be added")
            End Select

            RunoffMeasured(mEventCriteria.RunoffPrereq)

            If (RunoffHydrographCheck.Enabled And RunoffHydrographCheck.Checked) Then

                TabulatedRunoffControl.Show()

                If (eventType = EventAnalysisTypes.MerriamKellerAnalysis) Then
                    Me.RunoffPartialHydrograph.Hide()
                Else
                    Me.RunoffPartialHydrograph.Show()
                End If
            Else
                RunoffPartialHydrograph.Hide()
                TabulatedRunoffControl.Hide()
            End If
        End If

    End Sub

    Private Sub RunoffControlErrorProviderSetError(ByVal ErrMsg As String)
        If (Me.Visible) Then
            Me.ErrorProvider.SetError(TabulatedRunoffControl, ErrMsg)
        Else
            Me.ErrorProvider.SetError(TabulatedRunoffControl, "")
        End If
    End Sub

    Private Sub RunoffMeasured(ByVal Prerequisite As EventCriteria.Prerequisites)

        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
            Prerequisite = EventCriteria.Prerequisites.NotUsed
        End If

        mEventCriteria.RunoffPrereq = Prerequisite

        Dim measured As Boolean = mInflowManagement.RunoffMeasured.Value
        Dim used As Boolean = True ' Used control is only for EVALUE
        If (mEventCriteria.EventAnalysisType.Value = EventAnalysisTypes.EvalueAnalysis) Then
            used = mInflowManagement.RunoffUsed.Value
        End If

        ' Control the display / use of the Measured checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.Required, EventCriteria.Prerequisites.RequiredVB

                Me.RunoffHydrographCheck.Enabled = True
                Me.RunoffHydrographCheck.Visible = True
                Me.RunoffHydrographCheck.AlwaysChecked = True ' set uncheck message also
                Me.RunoffHydrographCheck.UncheckAttemptMessage = mDictionary.tRunoffRequired.Translated

                If ((Not measured) Or (Not used)) Then
                    Me.RunoffHydrographCheck.ErrorMessage = mDictionary.tRunoffRequired.Translated
                Else
                    Me.RunoffHydrographCheck.ErrorMessage = ""
                End If

            Case EventCriteria.Prerequisites.Useful, EventCriteria.Prerequisites.UsefulVB

                Me.RunoffHydrographCheck.Enabled = True
                Me.RunoffHydrographCheck.Visible = True
                Me.RunoffHydrographCheck.AlwaysChecked = False
                Me.RunoffHydrographCheck.ErrorMessage = ""

            Case Else ' EventCriteria.Prerequisites.NotUsed

                Me.RunoffHydrographCheck.Enabled = False
                Me.RunoffHydrographCheck.Visible = False
                Me.RunoffHydrographCheck.AlwaysChecked = False
                Me.RunoffHydrographCheck.ErrorMessage = ""

        End Select

        ' Control the display / use of the Used checkbox
        Select Case (Prerequisite)

            Case EventCriteria.Prerequisites.RequiredVB

                Me.UseRunoffCheck.Enabled = True
                Me.UseRunoffCheck.Visible = True
                Me.UseRunoffCheck.AlwaysChecked = True ' set uncheck message also
                Me.UseRunoffCheck.UncheckAttemptMessage = Me.RunoffHydrographCheck.UncheckAttemptMessage

            Case EventCriteria.Prerequisites.UsefulVB

                Me.UseRunoffCheck.Enabled = Me.RunoffHydrographCheck.Enabled And Me.RunoffHydrographCheck.Checked
                Me.UseRunoffCheck.Visible = Me.RunoffHydrographCheck.Enabled And Me.RunoffHydrographCheck.Checked
                Me.UseRunoffCheck.AlwaysChecked = False

            Case Else

                Me.UseRunoffCheck.Enabled = False
                Me.UseRunoffCheck.Visible = False
                Me.UseRunoffCheck.AlwaysChecked = False

        End Select

    End Sub
    '
    ' Update instructions for entering inflow/runoff data
    '
    Private Sub UpdateInstructions()
        InflowRunoffInstructions.Clear()
        InflowRunoffInstructions.SelectionAlignment = HorizontalAlignment.Left

        AppendBoldText(InflowRunoffInstructions, mDictionary.tInflow.Translated & " - ")
        AppendLine(InflowRunoffInstructions, mDictionary.tInflowInstructions.Translated)
        AdvanceLine(InflowRunoffInstructions)

        If (mInflowManagement.AppliedVolumeForField <= 0.0) Then ' No inflow specified
            AppendBoldText(InflowRunoffInstructions, mDictionary.tError.Translated & " - ")
            AppendLine(InflowRunoffInstructions, mDictionary.tNoInflowSpecified.Translated)
            AdvanceLine(InflowRunoffInstructions)
        End If

        If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
            AppendBoldText(InflowRunoffInstructions, mDictionary.tRunoff.Translated & " - ")
            AppendLine(InflowRunoffInstructions, mDictionary.tRunoffInstructions.Translated)
            AdvanceLine(InflowRunoffInstructions)

            If (Me.RunoffHydrographCheck.Enabled And Me.RunoffHydrographCheck.Checked) Then
                If (mInflowManagement.RunoffVolumeForField <= 0.0) Then
                    AppendBoldText(InflowRunoffInstructions, mDictionary.tWarning.Translated & " - ")
                    AppendLine(InflowRunoffInstructions, mDictionary.tNoRunoffVolumeSpecified.Translated)
                    AdvanceLine(InflowRunoffInstructions)
                End If
            End If
        End If

        Dim eventType As EventAnalysisTypes = mEventCriteria.EventAnalysisType.Value
        If Not (eventType = EventAnalysisTypes.MerriamKellerAnalysis) Then
            AppendText(InflowRunoffInstructions, mDictionary.tInflowRunoffInstruct1.Translated & " ")
        End If

        AppendText(InflowRunoffInstructions, mDictionary.tInflowRunoffInstruct2.Translated & " ")
        AppendLine(InflowRunoffInstructions, mDictionary.tInflowRunoffInstruct3.Translated)
        AdvanceLine(InflowRunoffInstructions)

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me, WinSRFR.Language)
        UpdateUI()
    End Sub

#End Region

#Region " Inflow Management Graphics "
    '
    ' Update the Inflow Management graphics
    '
    Private Sub UpdateGraphics()

        If (mUnit IsNot Nothing) Then
            ' Enclose all graphics code in Try Catch block to ignore exceptions
            Try
                Select Case mInflowManagement.InflowMethod.Value

                    Case InflowMethods.TabulatedInflow
                        Dim _tabulatedInflow As DataTable = mInflowManagement.TabulatedInflow.Value
                        GraphTabulatedInflow(InflowHydrograph, _tabulatedInflow)

                    Case Else ' Assume InflowMethods.StandardHydrograph
                        GraphHydrograph(InflowHydrograph)
                End Select

            Catch ex As Exception
                ' Ignore exceptions
            End Try
        End If

    End Sub
    '
    ' Graphics for Standard Hydrograph
    '
    Private Sub GraphHydrograph(ByVal _pictureBox As PictureBox)

        ' Get the Hydrograph values
        Dim _length As Double = mSystemGeometry.Length.Value
        Dim _width As Double = mSystemGeometry.WidthForCrossSection

        Dim _inflowRate As Double = mInflowManagement.InflowRate.Value
        Dim _cutbackRate As Double = _inflowRate * mInflowManagement.CutbackRateRatio.Value

        Dim _cutoffTime As Double = mInflowManagement.CutoffTime.Value
        Dim _cutbackTime As Double = _cutoffTime * mInflowManagement.CutbackTimeRatio.Value

        Dim _cutoffLocation As Double = _length * mInflowManagement.CutoffLocationRatio.Value
        Dim _cutbackLocation As Double = _length * mInflowManagement.CutbackLocationRatio.Value

        Dim _cutbackMethod As CutbackMethods = CType(mInflowManagement.CutbackMethod.Value, CutbackMethods)
        Dim _cutoffMethod As CutoffMethods = CType(mInflowManagement.CutoffMethod.Value, CutoffMethods)

        Dim _appliedVolume As Double = mInflowManagement.AppliedVolumeForField
        Dim _infiltratedVolume As Double = mInflowManagement.InfiltratedVolumeForField

        Dim _averageInflowRate As Double = _appliedVolume / _cutoffTime

        ' Tabulated Runoff is only valid in the Evaluation world
        Dim _tabulatedRunoff As DataTable = Nothing
        Dim _runoffVolume As Double = 0.0
        Dim _maxRunoffTime As Double = 0.0
        Dim _maxRunoff As Double = 0.0
        If (mUnit.UnitType.Value = WorldTypes.EventWorld) Then
            _tabulatedRunoff = mInflowManagement.TabulatedRunoff.Value
            If (_tabulatedRunoff IsNot Nothing) Then
                _maxRunoffTime = DataColumnMax(_tabulatedRunoff, nTimeX)
                _maxRunoff = DataColumnMax(_tabulatedRunoff, nRunoffX)
                _runoffVolume = mInflowManagement.RunoffVolumeForField
            End If
        End If

        Dim _maxTime As Double = MathMax(_cutoffTime, _maxRunoffTime)
        Dim _maxFlowRate As Double = MathMax(_inflowRate, _maxRunoff)

        Dim _volumeLabel As String = String.Empty
        Dim _avgInflowLabel As String = String.Empty

        ' Get drawing tools
        Dim _black As Pen = BlackPen1()
        Dim _grayBrush As SolidBrush = DarkGraySolidBrush()

        ' Highlight color is halfway between White and Background colors
        Dim _r As Integer = CInt((Color.White.R / 2) + (Me.BackColor.R / 2))
        Dim _g As Integer = CInt((Color.White.G / 2) + (Me.BackColor.G / 2))
        Dim _b As Integer = CInt((Color.White.B / 2) + (Me.BackColor.B / 2))
        Dim _highlight As Brush = New SolidBrush(Color.FromArgb(_r, _g, _b))

        ' Create a bitmap for the graphics
        Dim _bitmap As Bitmap = New Bitmap(_pictureBox.Width, _pictureBox.Height)
        Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

        ' Fill the bitmap with the background color
        _graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, _pictureBox.Width, _pictureBox.Height)
        '
        ' Define & draw the Axes for the Hydrograph
        '
        Dim _offset As Integer = 16 ' Offset into bitmap for axes
        Dim _quadrant As QuadrantSelections = QuadrantSelections.UpperRight

        ' X-axis information (Time)
        Dim _xAxis As Axis

        ' Y-axis information (Flow Rate)
        Dim _yAxis As Axis
        _yAxis.AxisLabel = mDictionary.tFlowRate.Translated
        _yAxis.MaxValue = _maxFlowRate
        _yAxis.MaxLabel = FlowRateString(_maxFlowRate, 0)
        '
        ' Define & draw the Hydrograph 'curve'
        '
        Dim x1, x2 As Double
        Dim _xPoints As ArrayList = New ArrayList
        Dim _yPoints As ArrayList = New ArrayList

        ' Graphics is dependent on the Cutback & Cutoff methods
        Select Case _cutoffMethod

            Case Globals.CutoffMethods.TimeBased

                Select Case _cutbackMethod

                    Case CutbackMethods.NoCutback
                        x1 = 0.0

                    Case CutbackMethods.TimeBased
                        x1 = _cutbackTime

                    Case CutbackMethods.DistanceBased
                        x1 = _cutoffTime * 0.5

                End Select

                x2 = _cutoffTime

                ' Define X axis
                _xAxis.AxisLabel = mDictionary.tTime.Translated
                _xAxis.MaxValue = _maxTime
                _xAxis.MaxLabel = TimeString(_maxTime, 0)

            Case Else ' Assume distance based

                Select Case _cutbackMethod

                    Case CutbackMethods.NoCutback
                        x1 = 0.0

                    Case CutbackMethods.TimeBased
                        x1 = 0.0

                    Case CutbackMethods.DistanceBased
                        x1 = _cutbackLocation

                End Select

                x2 = _cutoffLocation

                ' Define X axis
                _xAxis.AxisLabel = mDictionary.tDistance.Translated
                _xAxis.MaxValue = _length
                _xAxis.MaxLabel = mInflowManagement.Unit.SystemGeometryRef.Length.ValueString

        End Select

        DrawAxes(_bitmap, _quadrant, _xAxis, _yAxis, _offset, Me.Font)

        _xPoints.Add(0.0)
        _yPoints.Add(_inflowRate * 0.9)

        If (0.0 < x1) Then
            _xPoints.Add(x1 * 0.97)
            _yPoints.Add(_inflowRate * 0.9)

            _xPoints.Add(x1 * 0.97)
            _yPoints.Add(_cutbackRate * 0.9)
        End If

        _xPoints.Add(x2 * 0.97)
        _yPoints.Add(_yPoints(_yPoints.Count - 1))

        _xPoints.Add(x2 * 0.97)
        _yPoints.Add(0.0)

        ' Draw the Hydrograph
        If ((_cutoffMethod = Globals.CutoffMethods.TimeBased) _
          And (_cutbackMethod = Globals.CutbackMethods.DistanceBased)) Then
            Dim _x1 As Double = CDbl(_xPoints(1)) * 0.9
            Dim _y1 As Double = CDbl(_yPoints(1))
            Dim _x2 As Double = CDbl(_xPoints(2)) * 1.1
            Dim _y2 As Double = CDbl(_yPoints(2))
            FillRect(_bitmap, _quadrant, _highlight, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
            DrawRect(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
        End If

        If (1 < _yPoints.Count) Then
            For _line As Integer = 0 To _yPoints.Count - 2
                Dim _x1 As Double = CDbl(_xPoints(_line))
                Dim _y1 As Double = CDbl(_yPoints(_line))
                Dim _x2 As Double = CDbl(_xPoints(_line + 1))
                Dim _y2 As Double = CDbl(_yPoints(_line + 1))
                DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
            Next _line
        End If
        '
        ' Define & draw the Tabulated Runoff 'curve', if there is Runoff
        '
        If (_tabulatedRunoff IsNot Nothing) Then
            If (0 < _tabulatedRunoff.Rows.Count) Then

                _xPoints.Clear()
                _yPoints.Clear()

                Dim _time1 As Double = CDbl(_tabulatedRunoff.Rows(0).Item(nTimeX))
                Dim _flow1 As Double = CDbl(_tabulatedRunoff.Rows(0).Item(nInflowX))

                _xPoints.Add(_time1 * 0.97)
                _yPoints.Add(_flow1 * 0.9)

                For _idx As Integer = 1 To _tabulatedRunoff.Rows.Count - 1

                    Dim _time2 As Double = CDbl(_tabulatedRunoff.Rows(_idx).Item(nTimeX))
                    Dim _flow2 As Double = CDbl(_tabulatedRunoff.Rows(_idx).Item(nInflowX))

                    _xPoints.Add(_time2 * 0.97)
                    _yPoints.Add(_flow2 * 0.9)

                    _time1 = _time2
                    _flow1 = _flow2
                Next

                If Not (0.0 = _flow1) Then
                    _xPoints.Add(_time1 * 0.97)
                    _yPoints.Add(0.0 * 0.9)
                End If

                For _line As Integer = 0 To _yPoints.Count - 2
                    Dim _x1 As Double = CDbl(_xPoints(_line))
                    Dim _y1 As Double = CDbl(_yPoints(_line))
                    Dim _x2 As Double = CDbl(_xPoints(_line + 1))
                    Dim _y2 As Double = CDbl(_yPoints(_line + 1))
                    DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
                Next _line
            End If
        End If
        '
        ' Update the Inflow-Outflow Mass Balance data
        '
        If (Me.InflowPartialHydrograph.Checked Or Me.RunoffPartialHydrograph.Checked) Then
            Me.AppliedDepthLabel.Text = mDictionary.tMeasuredOrFinalAppliedDepth.Translated
            Me.DepthAppliedLabel.Text = mDictionary.tMeasuredOrFinalAppliedDepth.Translated
            Me.RunoffDepthLabel.Text = mDictionary.tMeasuredOrFinalRunoffDepth.Translated
            Me.MinusLabel.Hide()
            Me.EqualsLabel2.Hide()
            Me.InfiltratedDepthLabel.Hide()
            Me.InfiltratedDepthControl.Hide()
        Else
            Me.AppliedDepthLabel.Text = mDictionary.tFinalAppliedDepth.Translated
            Me.DepthAppliedLabel.Text = mDictionary.tFinalAppliedDepth.Translated
            Me.RunoffDepthLabel.Text = mDictionary.tFinalRunoffDepth.Translated
            Me.InfiltratedDepthLabel.Text = mDictionary.tFinalInfiltratedDepth.Translated
            Me.MinusLabel.Show()
            Me.EqualsLabel2.Show()
            Me.InfiltratedDepthLabel.Show()
            Me.InfiltratedDepthControl.Show()
        End If

        Dim _area As Double = mSystemGeometry.FieldArea

        Dim _appliedDepth As Double = _appliedVolume / _area
        Dim _runoffDepth As Double = _runoffVolume / _area
        Dim _infiltratedDepth As Double = _infiltratedVolume / _area

        DepthAppliedControl.Text = DepthString(_appliedDepth, 0)
        AppliedDepthValue.Text = DepthString(_appliedDepth, 0)
        If (0 < _runoffDepth) Then
            RunoffDepthControl.Text = DepthString(_runoffDepth, 0)
            InfiltratedDepthControl.Text = DepthString(_infiltratedDepth, 0)
        Else
            RunoffDepthControl.Text = "N/A"
            InfiltratedDepthControl.Text = "N/A"
        End If
        '
        ' Add water volume data to graph
        '
        If (_xAxis.MaxLabel = "TBD") Then
            _volumeLabel = mDictionary.tInflow.Translated + ": TBD"
            _avgInflowLabel = "Qavg: TBD"
        Else
            If (0.0 < _appliedVolume) Then
                _volumeLabel = mDictionary.tInflow.Translated + ": " + FieldVolumeString(_appliedVolume, 0)

                If (0.0 < _runoffVolume) Then
                    _volumeLabel += " ;  " + mDictionary.tRunoff.Translated + ": " + FieldVolumeString(_runoffVolume, 0)
                End If

                _avgInflowLabel = "Qavg: " + FlowRateString(_averageInflowRate, 0)
            End If
        End If

        Dim _size As SizeF = _graphics.MeasureString(_volumeLabel, Me.Font)
        _graphics.DrawString(_volumeLabel, Me.Font, _grayBrush, _
                            _bitmap.Width - _size.Width + 6, 0)

        If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
            If Not (_avgInflowLabel Is Nothing) Then
                _size = _graphics.MeasureString(_avgInflowLabel, Me.Font)
                _graphics.DrawString(_avgInflowLabel, Me.Font, _grayBrush, _
                                    _offset + 16, _bitmap.Height - (3 * _size.Height))
            End If
        End If
        '
        ' Copy the new bitmap into the image (this prevents flicker)
        '
        If (_pictureBox.Image IsNot Nothing) Then
            _pictureBox.Image.Dispose()
            _pictureBox.Image = Nothing
        End If

        _pictureBox.Image = _bitmap

    End Sub
    '
    ' Graphics for Tabulated Inflow
    '
    Private Sub GraphTabulatedInflow(ByVal _pictureBox As PictureBox, ByVal _tabulatedInflow As DataTable)

        ' Get the Tabulated Inflow values
        Dim _length As Double = mSystemGeometry.Length.Value
        Dim _width As Double = mSystemGeometry.WidthForCrossSection

        Dim _maxInflowTime As Double = DataColumnMax(_tabulatedInflow, nTimeX)
        Dim _maxInflow As Double = DataColumnMax(_tabulatedInflow, nInflowX)

        Dim _appliedVolume As Double = mInflowManagement.AppliedVolumeForField
        Dim _infiltratedVolume As Double = mInflowManagement.InfiltratedVolumeForField

        Dim _averageInflowRate As Double = _appliedVolume / _maxInflowTime

        ' Tabluated Runoff is only valid in the Evaluation world
        Dim _tabulatedRunoff As DataTable = Nothing
        Dim _maxRunoffTime As Double = 0.0
        Dim _maxRunoff As Double = 0.0
        Dim _runoffVolume As Double = 0.0
        If (mUnit.UnitType.Value = WorldTypes.EventWorld) Then
            _tabulatedRunoff = mInflowManagement.TabulatedRunoff.Value
            If (_tabulatedRunoff IsNot Nothing) Then
                _maxRunoffTime = DataColumnMax(_tabulatedRunoff, nTimeX)
                _maxRunoff = DataColumnMax(_tabulatedRunoff, nRunoffX)
                _runoffVolume = mInflowManagement.RunoffVolumeForField
            End If
        End If

        Dim _maxTime As Double = MathMax(_maxInflowTime, _maxRunoffTime)
        Dim _maxFlowRate As Double = MathMax(_maxInflow, _maxRunoff)

        ' Get drawing tools
        Dim _black As Pen = BlackPen1()
        Dim _grayBrush As SolidBrush = DarkGraySolidBrush()

        ' Create a bitmap for the graphics
        Dim _bitmap As Bitmap = New Bitmap(_pictureBox.Width, _pictureBox.Height)
        Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

        ' Fill the bitmap with the background color
        _graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, _pictureBox.Width, _pictureBox.Height)
        '
        ' Define & draw the Axes for the Hydrograph
        '
        Dim _offset As Integer = 16 ' Offset into bitmap for axes
        Dim _quadrant As QuadrantSelections = QuadrantSelections.UpperRight

        ' X-axis information (Time)
        Dim _xAxis As Axis
        _xAxis.AxisLabel = mDictionary.tTime.Translated
        _xAxis.MaxValue = _maxTime
        _xAxis.MaxLabel = TimeString(_maxTime, 0)

        ' Y-axis information (Inflow Rate)
        Dim _yAxis As Axis
        _yAxis.AxisLabel = mDictionary.tFlowRate.Translated
        _yAxis.MaxValue = _maxFlowRate
        _yAxis.MaxLabel = FlowRateString(_maxFlowRate, 0)

        DrawAxes(_bitmap, _quadrant, _xAxis, _yAxis, _offset, Me.Font)
        '
        ' Define & draw the Tabulated Inflow 'curve'
        '
        Dim _xPoints As ArrayList = New ArrayList
        Dim _yPoints As ArrayList = New ArrayList

        Dim _time1 As Double
        Dim _flow1 As Double

        If (_tabulatedInflow IsNot Nothing) Then

            _time1 = CDbl(_tabulatedInflow.Rows(0).Item(nTimeX))
            _flow1 = CDbl(_tabulatedInflow.Rows(0).Item(nInflowX))

            _xPoints.Add(_time1 * 0.97)
            _yPoints.Add(_flow1 * 0.9)

            For _idx As Integer = 1 To _tabulatedInflow.Rows.Count - 1

                Dim _time2 As Double = CDbl(_tabulatedInflow.Rows(_idx).Item(nTimeX))
                Dim _flow2 As Double = CDbl(_tabulatedInflow.Rows(_idx).Item(nInflowX))

                _xPoints.Add(_time2 * 0.97)
                _yPoints.Add(_flow2 * 0.9)

                _time1 = _time2
                _flow1 = _flow2
            Next
        End If

        Dim eventType As EventAnalysisTypes = mEventCriteria.EventAnalysisType.Value
        If (eventType = EventAnalysisTypes.MerriamKellerAnalysis) Then ' Full hydrograph assumed
            If Not (0.0 = _flow1) Then
                _xPoints.Add(_time1 * 0.97)
                _yPoints.Add(0.0 * 0.9)
            End If
        Else
            If (mInflowManagement.InflowComplete) Then ' Full hydrograph input
                If Not (0.0 = _flow1) Then
                    _xPoints.Add(_time1 * 0.97)
                    _yPoints.Add(0.0 * 0.9)
                End If
            End If
        End If

        For _line As Integer = 0 To _yPoints.Count - 2
            Dim _x1 As Double = CDbl(_xPoints(_line))
            Dim _y1 As Double = CDbl(_yPoints(_line))
            Dim _x2 As Double = CDbl(_xPoints(_line + 1))
            Dim _y2 As Double = CDbl(_yPoints(_line + 1))
            DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
        Next _line
        '
        ' Define & draw the Tabulated Runoff 'curve', if there is Runoff
        '
        If Not (_tabulatedRunoff Is Nothing) Then
            If (0 < _tabulatedRunoff.Rows.Count) Then

                _xPoints.Clear()
                _yPoints.Clear()

                _time1 = CDbl(_tabulatedRunoff.Rows(0).Item(nTimeX))
                _flow1 = CDbl(_tabulatedRunoff.Rows(0).Item(nInflowX))

                _xPoints.Add(_time1 * 0.97)
                _yPoints.Add(_flow1 * 0.9)

                For _idx As Integer = 1 To _tabulatedRunoff.Rows.Count - 1

                    Dim _time2 As Double = CDbl(_tabulatedRunoff.Rows(_idx).Item(nTimeX))
                    Dim _flow2 As Double = CDbl(_tabulatedRunoff.Rows(_idx).Item(nInflowX))

                    _xPoints.Add(_time2 * 0.97)
                    _yPoints.Add(_flow2 * 0.9)

                    _time1 = _time2
                    _flow1 = _flow2
                Next

                If (eventType = EventAnalysisTypes.MerriamKellerAnalysis) Then ' Full hydrograph assumed
                    If Not (0.0 = _flow1) Then
                        _xPoints.Add(_time1 * 0.97)
                        _yPoints.Add(0.0 * 0.9)
                    End If
                Else
                    If (mInflowManagement.RunoffComplete) Then ' Full hydrograph input
                        If Not (0.0 = _flow1) Then
                            _xPoints.Add(_time1 * 0.97)
                            _yPoints.Add(0.0 * 0.9)
                        End If
                    End If
                End If

                For _line As Integer = 0 To _yPoints.Count - 2
                    Dim _x1 As Double = CDbl(_xPoints(_line))
                    Dim _y1 As Double = CDbl(_yPoints(_line))
                    Dim _x2 As Double = CDbl(_xPoints(_line + 1))
                    Dim _y2 As Double = CDbl(_yPoints(_line + 1))
                    DrawLine(_bitmap, _quadrant, _black, _xAxis, _yAxis, _offset, _x1, _y1, _x2, _y2)
                Next _line
            End If
        End If
        '
        ' Update the Inflow-Outflow Mass Balance data
        '
        If (Me.InflowPartialHydrograph.Checked Or Me.RunoffPartialHydrograph.Checked) Then
            Me.AppliedDepthLabel.Text = mDictionary.tMeasuredOrFinalAppliedDepth.Translated
            Me.DepthAppliedLabel.Text = mDictionary.tMeasuredOrFinalAppliedDepth.Translated
            Me.RunoffDepthLabel.Text = mDictionary.tMeasuredOrFinalRunoffDepth.Translated
            Me.MinusLabel.Hide()
            Me.EqualsLabel2.Hide()
            Me.InfiltratedDepthLabel.Hide()
            Me.InfiltratedDepthControl.Hide()
        Else
            Me.AppliedDepthLabel.Text = mDictionary.tFinalAppliedDepth.Translated
            Me.DepthAppliedLabel.Text = mDictionary.tFinalAppliedDepth.Translated
            Me.RunoffDepthLabel.Text = mDictionary.tFinalRunoffDepth.Translated
            Me.InfiltratedDepthLabel.Text = mDictionary.tFinalInfiltratedDepth.Translated
            Me.MinusLabel.Show()
            Me.EqualsLabel2.Show()
            Me.InfiltratedDepthLabel.Show()
            Me.InfiltratedDepthControl.Show()
        End If

        Dim _area As Double = mSystemGeometry.FieldArea

        Dim _appliedDepth As Double = _appliedVolume / _area
        Dim _runoffDepth As Double = _runoffVolume / _area
        Dim _infiltratedDepth As Double = _infiltratedVolume / _area

        DepthAppliedControl.Text = DepthString(_appliedDepth, 0)
        AppliedDepthValue.Text = DepthString(_appliedDepth, 0)

        If (0 < _runoffDepth) Then
            RunoffDepthControl.Text = DepthString(_runoffDepth, 0)
            InfiltratedDepthControl.Text = DepthString(_infiltratedDepth, 0)
        Else
            RunoffDepthControl.Text = "N/A"
            InfiltratedDepthControl.Text = "N/A"
        End If
        '
        ' Add water volume data to graph
        '
        If (0.0 < _appliedVolume) Then

            Dim _volumeLabel As String = mDictionary.tInflow.Translated + ": " + FieldVolumeString(_appliedVolume, 0)

            If (0.0 < _runoffVolume) Then
                _volumeLabel += " ;  " + mDictionary.tRunoff.Translated + ": " + FieldVolumeString(_runoffVolume, 0)
            End If

            Dim _avgInflowLabel As String = "Qavg: " + FlowRateString(_averageInflowRate, 0)

            Dim _size As SizeF = _graphics.MeasureString(_volumeLabel, Me.Font)
            _graphics.DrawString(_volumeLabel, Me.Font, _grayBrush, _
                                _bitmap.Width - _size.Width + 6, 0)

            _size = _graphics.MeasureString(_avgInflowLabel, Me.Font)
            _graphics.DrawString(_avgInflowLabel, Me.Font, _grayBrush, _
                                _offset + 16, _bitmap.Height - (3 * _size.Height))
        End If
        '
        ' Copy the new bitmap into the image (this prevents flicker)
        '
        If (_pictureBox.Image IsNot Nothing) Then
            _pictureBox.Image.Dispose()
            _pictureBox.Image = Nothing
        End If

        _pictureBox.Image = _bitmap

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        '
        ' Adjust contained controls to match new height & width
        '

        ' Inflow
        Me.InflowGroupBox.Height = Me.Height - Me.InflowGroupBox.Location.Y - 5
        Me.TabulatedInflowPanel.Height = Me.InflowGroupBox.Height - Me.TabulatedInflowPanel.Location.Y - 5

        Dim partialLoc As Point = Me.InflowPartialHydrograph.Location
        partialLoc.Y = Me.TabulatedInflowPanel.Height - Me.InflowPartialHydrograph.Height + 3
        Me.InflowPartialHydrograph.Location = partialLoc

        Me.TabulatedInflowControl.Height = Me.TabulatedInflowPanel.Height - Me.TabulatedInflowControl.Location.Y _
                                         - Me.InflowPartialHydrograph.Height
        ' Runoff
        Me.RunoffGroupBox.Height = Me.Height - Me.RunoffGroupBox.Location.Y - 5

        partialLoc = Me.RunoffPartialHydrograph.Location
        partialLoc.Y = Me.RunoffGroupBox.Height - Me.RunoffPartialHydrograph.Height - 2
        Me.RunoffPartialHydrograph.Location = partialLoc

        Me.TabulatedRunoffControl.Height = Me.RunoffGroupBox.Height - Me.TabulatedRunoffControl.Location.Y _
                                         - Me.RunoffPartialHydrograph.Height - 5
        ' Graph
        Dim graphLoc As Point = New Point(Me.HydrographGraphicsPanel.Location.X, 2)
        Me.HydrographGraphicsPanel.Location = graphLoc

        Dim graphHeight As Integer = ((Me.Height - Me.InflowStatsPanel.Height) / 2) - 4
        Dim graphWidth As Integer = Me.Width - graphLoc.X

        Me.HydrographGraphicsPanel.Height = graphHeight - 4
        Me.HydrographGraphicsPanel.Width = graphWidth - 3

        Me.InflowHydrograph.Location = New Point(2, 2)
        Me.InflowHydrograph.Height = graphHeight - 6
        Me.InflowHydrograph.Width = graphWidth - 6
        UpdateGraphics()

        ' Statistics (Height is fixed)
        Dim statsLoc As Point = New Point(Me.InflowStatsPanel.Location.X, graphLoc.Y + graphHeight + 2)
        Me.InflowStatsPanel.Location = statsLoc
        Me.InflowStatsPanel.Width = graphWidth

        Me.InflowRunoffStatsPanel.Location = statsLoc
        Me.InflowRunoffStatsPanel.Width = graphWidth

        ' Instructions
        Dim instrLoc As Point = Me.InflowRunoffInstructions.Location
        Me.InflowRunoffInstructions.Location = New Point(instrLoc.X, statsLoc.Y + Me.InflowStatsPanel.Height + 2)
        Me.InflowRunoffInstructions.Height = graphHeight - 4
        Me.InflowRunoffInstructions.Width = graphWidth - 3

    End Sub

    Private Sub TabulatedInflowControl_ControlValueChanged() _
    Handles TabulatedInflowControl.ControlValueChanged
        UpdateInstructions()
        UpdateGraphics()
        mWorldWindow.UpdateResultsControls()
    End Sub

    Private Sub TabulatedRunoffControl_ControlValueChanged() _
    Handles TabulatedRunoffControl.ControlValueChanged
        UpdateInstructions()
        UpdateGraphics()
        mWorldWindow.UpdateResultsControls()
    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

End Class
