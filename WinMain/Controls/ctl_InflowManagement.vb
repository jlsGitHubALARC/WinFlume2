
'**********************************************************************************************
' ctl_InflowManagement
'
'   ctl_InflowManagement provides the UI for viewing & editing the Inflow Management data
'
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI

Public Class ctl_InflowManagement
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
    Friend WithEvents InflowMethodLabel As DataStore.ctl_Label
    Friend WithEvents StandardHydrographPanel As DataStore.ctl_Panel
    Friend WithEvents SurgePanel As DataStore.ctl_Panel
    Friend WithEvents CablegationPanel As DataStore.ctl_Panel
    Friend WithEvents TabulatedInflowPanel As DataStore.ctl_Panel
    Friend WithEvents InflowMethodControl As DataStore.ctl_SelectParameter
    Friend WithEvents HydrographGraphicsPanel As DataStore.ctl_Panel
    Friend WithEvents InflowHydrograph As GraphingUI.ex_PictureBox
    Friend WithEvents TabulatedInflowControl As DataStore.ctl_DataTableParameter
    Friend WithEvents InflowRunoffLabel As DataStore.ctl_Label
    Friend WithEvents UpstreamDrainbackBox As DataStore.ctl_GroupBox
    Friend WithEvents DrawdownTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents DrawDownTimeLabel As DataStore.ctl_Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents StandardHydrographControl As WinMain.ctl_StandardHydrograph
    Friend WithEvents SurgeInflowControl As WinMain.ctl_SurgeInflow
    Friend WithEvents CablegationInflowControl As WinMain.ctl_Cablegation
    Friend WithEvents InflowStatsPanel As DataStore.ctl_Panel
    Friend WithEvents AppliedDepthLabel As System.Windows.Forms.Label
    Friend WithEvents AppliedDepthValue As System.Windows.Forms.Label
    Friend WithEvents EnableDrainbackControl As DataStore.ctl_CheckParameter
    Friend WithEvents Surge2InfiltrationMethodGroup As DataStore.ctl_GroupBox
    Friend WithEvents IzunoPodmoreButton As DataStore.ctl_RadioButton
    Friend WithEvents DownstreamRunoffGroup As DataStore.ctl_GroupBox
    Friend WithEvents OpenEndButton As DataStore.ctl_RadioButton
    Friend WithEvents BlockedEndButton As DataStore.ctl_RadioButton
    Friend WithEvents BlairSmerdonButton As DataStore.ctl_RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.InflowMethodLabel = New DataStore.ctl_Label
        Me.StandardHydrographPanel = New DataStore.ctl_Panel
        Me.StandardHydrographControl = New WinMain.ctl_StandardHydrograph
        Me.SurgePanel = New DataStore.ctl_Panel
        Me.SurgeInflowControl = New WinMain.ctl_SurgeInflow
        Me.CablegationPanel = New DataStore.ctl_Panel
        Me.CablegationInflowControl = New WinMain.ctl_Cablegation
        Me.TabulatedInflowPanel = New DataStore.ctl_Panel
        Me.TabulatedInflowControl = New DataStore.ctl_DataTableParameter
        Me.InflowMethodControl = New DataStore.ctl_SelectParameter
        Me.HydrographGraphicsPanel = New DataStore.ctl_Panel
        Me.InflowHydrograph = New GraphingUI.ex_PictureBox
        Me.InflowRunoffLabel = New DataStore.ctl_Label
        Me.UpstreamDrainbackBox = New DataStore.ctl_GroupBox
        Me.EnableDrainbackControl = New DataStore.ctl_CheckParameter
        Me.DrawdownTimeControl = New DataStore.ctl_DoubleParameter
        Me.DrawDownTimeLabel = New DataStore.ctl_Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.InflowStatsPanel = New DataStore.ctl_Panel
        Me.AppliedDepthValue = New System.Windows.Forms.Label
        Me.AppliedDepthLabel = New System.Windows.Forms.Label
        Me.Surge2InfiltrationMethodGroup = New DataStore.ctl_GroupBox
        Me.IzunoPodmoreButton = New DataStore.ctl_RadioButton
        Me.BlairSmerdonButton = New DataStore.ctl_RadioButton
        Me.DownstreamRunoffGroup = New DataStore.ctl_GroupBox
        Me.OpenEndButton = New DataStore.ctl_RadioButton
        Me.BlockedEndButton = New DataStore.ctl_RadioButton
        Me.StandardHydrographPanel.SuspendLayout()
        Me.SurgePanel.SuspendLayout()
        Me.CablegationPanel.SuspendLayout()
        Me.TabulatedInflowPanel.SuspendLayout()
        CType(Me.TabulatedInflowControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HydrographGraphicsPanel.SuspendLayout()
        CType(Me.InflowHydrograph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UpstreamDrainbackBox.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InflowStatsPanel.SuspendLayout()
        Me.Surge2InfiltrationMethodGroup.SuspendLayout()
        Me.DownstreamRunoffGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'InflowMethodLabel
        '
        Me.InflowMethodLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowMethodLabel.Location = New System.Drawing.Point(3, 34)
        Me.InflowMethodLabel.Name = "InflowMethodLabel"
        Me.InflowMethodLabel.Size = New System.Drawing.Size(143, 23)
        Me.InflowMethodLabel.TabIndex = 5
        Me.InflowMethodLabel.Text = "&Inflow Method"
        Me.InflowMethodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StandardHydrographPanel
        '
        Me.StandardHydrographPanel.AccessibleDescription = "Specifies the Inflow Rate, Cutoff and Cutback Options associated with the Standar" & _
            "d Hydograph method."
        Me.StandardHydrographPanel.AccessibleName = "Standard Hydrograph"
        Me.StandardHydrographPanel.Controls.Add(Me.StandardHydrographControl)
        Me.StandardHydrographPanel.Location = New System.Drawing.Point(8, 64)
        Me.StandardHydrographPanel.Name = "StandardHydrographPanel"
        Me.StandardHydrographPanel.Size = New System.Drawing.Size(340, 300)
        Me.StandardHydrographPanel.TabIndex = 12
        '
        'StandardHydrographControl
        '
        Me.StandardHydrographControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StandardHydrographControl.Location = New System.Drawing.Point(3, 3)
        Me.StandardHydrographControl.Margin = New System.Windows.Forms.Padding(4)
        Me.StandardHydrographControl.Name = "StandardHydrographControl"
        Me.StandardHydrographControl.Size = New System.Drawing.Size(335, 295)
        Me.StandardHydrographControl.TabIndex = 0
        '
        'SurgePanel
        '
        Me.SurgePanel.AccessibleDescription = "Parameters describing surge inflow."
        Me.SurgePanel.AccessibleName = "Surge"
        Me.SurgePanel.Controls.Add(Me.SurgeInflowControl)
        Me.SurgePanel.Location = New System.Drawing.Point(8, 64)
        Me.SurgePanel.Name = "SurgePanel"
        Me.SurgePanel.Size = New System.Drawing.Size(340, 300)
        Me.SurgePanel.TabIndex = 12
        '
        'SurgeInflowControl
        '
        Me.SurgeInflowControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurgeInflowControl.Location = New System.Drawing.Point(2, 2)
        Me.SurgeInflowControl.Margin = New System.Windows.Forms.Padding(4)
        Me.SurgeInflowControl.Name = "SurgeInflowControl"
        Me.SurgeInflowControl.Size = New System.Drawing.Size(335, 295)
        Me.SurgeInflowControl.TabIndex = 0
        '
        'CablegationPanel
        '
        Me.CablegationPanel.AccessibleDescription = "Parameters describing Cablegation inflow."
        Me.CablegationPanel.AccessibleName = "Cablegation"
        Me.CablegationPanel.Controls.Add(Me.CablegationInflowControl)
        Me.CablegationPanel.Location = New System.Drawing.Point(8, 64)
        Me.CablegationPanel.Name = "CablegationPanel"
        Me.CablegationPanel.Size = New System.Drawing.Size(340, 300)
        Me.CablegationPanel.TabIndex = 12
        '
        'CablegationInflowControl
        '
        Me.CablegationInflowControl.AccessibleDescription = "Display and edit cablegation inflow parameters"
        Me.CablegationInflowControl.AccessibleName = "Cablegation Inflow"
        Me.CablegationInflowControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CablegationInflowControl.Location = New System.Drawing.Point(3, 2)
        Me.CablegationInflowControl.Margin = New System.Windows.Forms.Padding(4)
        Me.CablegationInflowControl.Name = "CablegationInflowControl"
        Me.CablegationInflowControl.Size = New System.Drawing.Size(335, 295)
        Me.CablegationInflowControl.TabIndex = 0
        '
        'TabulatedInflowPanel
        '
        Me.TabulatedInflowPanel.AccessibleDescription = "Specifies the inflow as a table of time and rate values."
        Me.TabulatedInflowPanel.AccessibleName = "Tabulated Inflow"
        Me.TabulatedInflowPanel.Controls.Add(Me.TabulatedInflowControl)
        Me.TabulatedInflowPanel.Location = New System.Drawing.Point(8, 64)
        Me.TabulatedInflowPanel.Name = "TabulatedInflowPanel"
        Me.TabulatedInflowPanel.Size = New System.Drawing.Size(336, 296)
        Me.TabulatedInflowPanel.TabIndex = 12
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
        Me.TabulatedInflowControl.Location = New System.Drawing.Point(142, 7)
        Me.TabulatedInflowControl.MaxRows = 250
        Me.TabulatedInflowControl.MinRows = 2
        Me.TabulatedInflowControl.Name = "TabulatedInflowControl"
        Me.TabulatedInflowControl.SecondColumnIncreases = False
        Me.TabulatedInflowControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.TabulatedInflowControl.SecondColumnMinimum = 0
        Me.TabulatedInflowControl.Size = New System.Drawing.Size(188, 286)
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
        Me.InflowMethodControl.Location = New System.Drawing.Point(150, 33)
        Me.InflowMethodControl.Name = "InflowMethodControl"
        Me.InflowMethodControl.SelectedIndexSet = False
        Me.InflowMethodControl.Size = New System.Drawing.Size(188, 24)
        Me.InflowMethodControl.TabIndex = 6
        '
        'HydrographGraphicsPanel
        '
        Me.HydrographGraphicsPanel.AccessibleDescription = "Hydrograph of field's inflow."
        Me.HydrographGraphicsPanel.AccessibleName = "Inflow Graph"
        Me.HydrographGraphicsPanel.Controls.Add(Me.InflowHydrograph)
        Me.HydrographGraphicsPanel.Location = New System.Drawing.Point(360, 4)
        Me.HydrographGraphicsPanel.Name = "HydrographGraphicsPanel"
        Me.HydrographGraphicsPanel.Size = New System.Drawing.Size(415, 212)
        Me.HydrographGraphicsPanel.TabIndex = 13
        '
        'InflowHydrograph
        '
        Me.InflowHydrograph.AccessibleDescription = "A copyable bitmap image"
        Me.InflowHydrograph.AccessibleName = "Inflow Hydrograph"
        Me.InflowHydrograph.Location = New System.Drawing.Point(8, 8)
        Me.InflowHydrograph.Name = "InflowHydrograph"
        Me.InflowHydrograph.Size = New System.Drawing.Size(400, 200)
        Me.InflowHydrograph.TabIndex = 16
        Me.InflowHydrograph.TabStop = False
        Me.InflowHydrograph.Text = "Bitmap Diagram"
        '
        'InflowRunoffLabel
        '
        Me.InflowRunoffLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InflowRunoffLabel.Location = New System.Drawing.Point(16, 4)
        Me.InflowRunoffLabel.Name = "InflowRunoffLabel"
        Me.InflowRunoffLabel.Size = New System.Drawing.Size(312, 24)
        Me.InflowRunoffLabel.TabIndex = 0
        Me.InflowRunoffLabel.Text = "Inflow / Runoff"
        Me.InflowRunoffLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UpstreamDrainbackBox
        '
        Me.UpstreamDrainbackBox.AccessibleDescription = "Parameters describing the drainback of water at the upstgrem end after cutoff."
        Me.UpstreamDrainbackBox.AccessibleName = "Upstream Drainback"
        Me.UpstreamDrainbackBox.Controls.Add(Me.EnableDrainbackControl)
        Me.UpstreamDrainbackBox.Controls.Add(Me.DrawdownTimeControl)
        Me.UpstreamDrainbackBox.Controls.Add(Me.DrawDownTimeLabel)
        Me.UpstreamDrainbackBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpstreamDrainbackBox.Location = New System.Drawing.Point(360, 306)
        Me.UpstreamDrainbackBox.Name = "UpstreamDrainbackBox"
        Me.UpstreamDrainbackBox.Size = New System.Drawing.Size(406, 52)
        Me.UpstreamDrainbackBox.TabIndex = 1
        Me.UpstreamDrainbackBox.TabStop = False
        Me.UpstreamDrainbackBox.Text = "Upstream Drainback"
        '
        'EnableDrainbackControl
        '
        Me.EnableDrainbackControl.AlwaysChecked = False
        Me.EnableDrainbackControl.ErrorMessage = Nothing
        Me.EnableDrainbackControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnableDrainbackControl.Location = New System.Drawing.Point(15, 21)
        Me.EnableDrainbackControl.Name = "EnableDrainbackControl"
        Me.EnableDrainbackControl.Size = New System.Drawing.Size(105, 23)
        Me.EnableDrainbackControl.TabIndex = 0
        Me.EnableDrainbackControl.Text = "&Drainback"
        Me.EnableDrainbackControl.UncheckAttemptMessage = Nothing
        Me.EnableDrainbackControl.UseVisualStyleBackColor = True
        '
        'DrawdownTimeControl
        '
        Me.DrawdownTimeControl.AccessibleDescription = "The drainback draw down time after cutoff that defines the start of recession at " & _
            "the upstream end of the field."
        Me.DrawdownTimeControl.AccessibleName = "Draw Down Time"
        Me.DrawdownTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.DrawdownTimeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DrawdownTimeControl.IsCalculated = False
        Me.DrawdownTimeControl.IsInteger = False
        Me.DrawdownTimeControl.Location = New System.Drawing.Point(262, 20)
        Me.DrawdownTimeControl.MaxErrMsg = ""
        Me.DrawdownTimeControl.MinErrMsg = ""
        Me.DrawdownTimeControl.Name = "DrawdownTimeControl"
        Me.DrawdownTimeControl.Size = New System.Drawing.Size(108, 24)
        Me.DrawdownTimeControl.TabIndex = 2
        Me.DrawdownTimeControl.ToBeCalculated = True
        Me.DrawdownTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.DrawdownTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.DrawdownTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.DrawdownTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.DrawdownTimeControl.ValueText = ""
        '
        'DrawDownTimeLabel
        '
        Me.DrawDownTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DrawDownTimeLabel.Location = New System.Drawing.Point(120, 20)
        Me.DrawDownTimeLabel.Name = "DrawDownTimeLabel"
        Me.DrawDownTimeLabel.Size = New System.Drawing.Size(137, 23)
        Me.DrawDownTimeLabel.TabIndex = 1
        Me.DrawDownTimeLabel.Text = "&Draw Down Time"
        Me.DrawDownTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'InflowStatsPanel
        '
        Me.InflowStatsPanel.AccessibleDescription = "Summary of inflow onto the field."
        Me.InflowStatsPanel.AccessibleName = "Inflow summary"
        Me.InflowStatsPanel.Controls.Add(Me.AppliedDepthValue)
        Me.InflowStatsPanel.Controls.Add(Me.AppliedDepthLabel)
        Me.InflowStatsPanel.Location = New System.Drawing.Point(360, 215)
        Me.InflowStatsPanel.Name = "InflowStatsPanel"
        Me.InflowStatsPanel.Size = New System.Drawing.Size(416, 76)
        Me.InflowStatsPanel.TabIndex = 23
        '
        'AppliedDepthValue
        '
        Me.AppliedDepthValue.Location = New System.Drawing.Point(167, 8)
        Me.AppliedDepthValue.Name = "AppliedDepthValue"
        Me.AppliedDepthValue.Size = New System.Drawing.Size(100, 23)
        Me.AppliedDepthValue.TabIndex = 1
        Me.AppliedDepthValue.Text = "= 100 mm"
        Me.AppliedDepthValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AppliedDepthLabel
        '
        Me.AppliedDepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppliedDepthLabel.Location = New System.Drawing.Point(6, 8)
        Me.AppliedDepthLabel.Name = "AppliedDepthLabel"
        Me.AppliedDepthLabel.Size = New System.Drawing.Size(160, 23)
        Me.AppliedDepthLabel.TabIndex = 0
        Me.AppliedDepthLabel.Text = "Applied Depth (Dapp)"
        Me.AppliedDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Surge2InfiltrationMethodGroup
        '
        Me.Surge2InfiltrationMethodGroup.AccessibleDescription = "Infiltration method to use for all surges after the first surge."
        Me.Surge2InfiltrationMethodGroup.AccessibleName = "Surge 2 Plus Infiltration Method"
        Me.Surge2InfiltrationMethodGroup.Controls.Add(Me.IzunoPodmoreButton)
        Me.Surge2InfiltrationMethodGroup.Controls.Add(Me.BlairSmerdonButton)
        Me.Surge2InfiltrationMethodGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Surge2InfiltrationMethodGroup.Location = New System.Drawing.Point(8, 364)
        Me.Surge2InfiltrationMethodGroup.Name = "Surge2InfiltrationMethodGroup"
        Me.Surge2InfiltrationMethodGroup.Size = New System.Drawing.Size(340, 52)
        Me.Surge2InfiltrationMethodGroup.TabIndex = 13
        Me.Surge2InfiltrationMethodGroup.TabStop = False
        Me.Surge2InfiltrationMethodGroup.Text = "Surge 2+ Infiltration Method"
        '
        'IzunoPodmoreButton
        '
        Me.IzunoPodmoreButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IzunoPodmoreButton.Location = New System.Drawing.Point(160, 21)
        Me.IzunoPodmoreButton.Name = "IzunoPodmoreButton"
        Me.IzunoPodmoreButton.Size = New System.Drawing.Size(174, 25)
        Me.IzunoPodmoreButton.TabIndex = 1
        Me.IzunoPodmoreButton.TabStop = True
        Me.IzunoPodmoreButton.Text = "I&zuno-Podmore (0 < b)"
        Me.IzunoPodmoreButton.UseVisualStyleBackColor = True
        '
        'BlairSmerdonButton
        '
        Me.BlairSmerdonButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlairSmerdonButton.Location = New System.Drawing.Point(11, 21)
        Me.BlairSmerdonButton.Name = "BlairSmerdonButton"
        Me.BlairSmerdonButton.Size = New System.Drawing.Size(132, 25)
        Me.BlairSmerdonButton.TabIndex = 0
        Me.BlairSmerdonButton.TabStop = True
        Me.BlairSmerdonButton.Text = "&Blair-Smerdon"
        Me.BlairSmerdonButton.UseVisualStyleBackColor = True
        '
        'DownstreamRunoffGroup
        '
        Me.DownstreamRunoffGroup.AccessibleDescription = "Selects whether or not runoff is allowed."
        Me.DownstreamRunoffGroup.AccessibleName = "Downstream Condition"
        Me.DownstreamRunoffGroup.Controls.Add(Me.OpenEndButton)
        Me.DownstreamRunoffGroup.Controls.Add(Me.BlockedEndButton)
        Me.DownstreamRunoffGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownstreamRunoffGroup.Location = New System.Drawing.Point(360, 364)
        Me.DownstreamRunoffGroup.Name = "DownstreamRunoffGroup"
        Me.DownstreamRunoffGroup.Size = New System.Drawing.Size(406, 52)
        Me.DownstreamRunoffGroup.TabIndex = 25
        Me.DownstreamRunoffGroup.TabStop = False
        Me.DownstreamRunoffGroup.Text = "Downstream Condition"
        '
        'OpenEndButton
        '
        Me.OpenEndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenEndButton.Location = New System.Drawing.Point(15, 21)
        Me.OpenEndButton.Name = "OpenEndButton"
        Me.OpenEndButton.Size = New System.Drawing.Size(105, 24)
        Me.OpenEndButton.TabIndex = 0
        Me.OpenEndButton.Text = "&Open End"
        '
        'BlockedEndButton
        '
        Me.BlockedEndButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlockedEndButton.Location = New System.Drawing.Point(147, 21)
        Me.BlockedEndButton.Name = "BlockedEndButton"
        Me.BlockedEndButton.Size = New System.Drawing.Size(92, 24)
        Me.BlockedEndButton.TabIndex = 1
        Me.BlockedEndButton.Text = "Bloc&ked"
        '
        'ctl_InflowManagement
        '
        Me.Controls.Add(Me.StandardHydrographPanel)
        Me.Controls.Add(Me.TabulatedInflowPanel)
        Me.Controls.Add(Me.UpstreamDrainbackBox)
        Me.Controls.Add(Me.DownstreamRunoffGroup)
        Me.Controls.Add(Me.Surge2InfiltrationMethodGroup)
        Me.Controls.Add(Me.HydrographGraphicsPanel)
        Me.Controls.Add(Me.SurgePanel)
        Me.Controls.Add(Me.InflowRunoffLabel)
        Me.Controls.Add(Me.InflowMethodControl)
        Me.Controls.Add(Me.InflowMethodLabel)
        Me.Controls.Add(Me.InflowStatsPanel)
        Me.Controls.Add(Me.CablegationPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_InflowManagement"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.StandardHydrographPanel.ResumeLayout(False)
        Me.SurgePanel.ResumeLayout(False)
        Me.CablegationPanel.ResumeLayout(False)
        Me.TabulatedInflowPanel.ResumeLayout(False)
        CType(Me.TabulatedInflowControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HydrographGraphicsPanel.ResumeLayout(False)
        CType(Me.InflowHydrograph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UpstreamDrainbackBox.ResumeLayout(False)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InflowStatsPanel.ResumeLayout(False)
        Me.Surge2InfiltrationMethodGroup.ResumeLayout(False)
        Me.DownstreamRunoffGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Properties "

    Public Property Title() As String
        Get
            Return InflowRunoffLabel.Text
        End Get
        Set(ByVal Value As String)
            InflowRunoffLabel.Text = Value
        End Set
    End Property

#End Region

#Region " Control / Model Linkage "
    '
    ' References to model objects
    '
    Private mUnit As Unit = Nothing
    Private mWorld As World = Nothing
    Private mField As Field = Nothing
    Private mFarm As Farm = Nothing
    Private mDictionary As Dictionary = Nothing
    Private mMyStore As DataStore.ObjectNode = Nothing

    Private WithEvents mWinSRFR As WinSRFR = Nothing
    Private WithEvents mSystemGeometry As SystemGeometry = Nothing
    Private WithEvents mSoilCropProperties As SoilCropProperties = Nothing
    Private WithEvents mInflowManagement As InflowManagement = Nothing
    Private WithEvents mEventCriteria As EventCriteria = Nothing

    Private WithEvents mUnitsSystem As UnitsSystem = UnitsSystem.Instance
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Establish links to model objects and update UI
    '
    Public Sub LinkToModel(ByVal _unit As Unit, ByVal _worldWindow As WorldWindow)

        Debug.Assert(_unit IsNot Nothing)
        Debug.Assert(_worldWindow IsNot Nothing)

        ' Link this control to its data model and store
        mUnit = _unit
        mWorld = mUnit.WorldRef
        mField = mWorld.FieldRef
        mFarm = mField.FarmRef
        mWinSRFR = mFarm.WinSrfrRef

        mSystemGeometry = mUnit.SystemGeometryRef
        mSoilCropProperties = mUnit.SoilCropPropertiesRef
        mInflowManagement = mUnit.InflowManagementRef
        mEventCriteria = mUnit.EventCriteriaRef

        mDictionary = Dictionary.Instance
        mMyStore = mUnit.MyStore

        ' Access to UI
        mWorldWindow = _worldWindow

        ' Link the contained controls to their models & store
        Me.OpenEndButton.LinkToModel(mMyStore, mSystemGeometry.DownstreamConditionProperty, DownstreamConditions.OpenEnd)
        Me.BlockedEndButton.LinkToModel(mMyStore, mSystemGeometry.DownstreamConditionProperty, DownstreamConditions.BlockedEnd)

        Me.InflowMethodControl.LinkToModel(mMyStore, mInflowManagement.InflowMethodProperty)

        ' Inflow controls
        Me.StandardHydrographControl.LinkToModel(mUnit)
        Me.SurgeInflowControl.LinkToModel(mUnit)
        Me.CablegationInflowControl.LinkToModel(mUnit)

        ' Drainback controls
        Me.EnableDrainbackControl.LinkToModel(mMyStore, mSystemGeometry.UpstreamConditionProperty)
        Me.DrawdownTimeControl.LinkToModel(mMyStore, mInflowManagement.DrawDownTimeProperty)

        ' Tabulated Inflow control
        Me.TabulatedInflowControl.LinkToModel(mMyStore, mInflowManagement.TabulatedInflowProperty)
        Me.TabulatedInflowControl.UpdateUI()

        ' Surge Infiltration controls
        Me.BlairSmerdonButton.LinkToModel(mMyStore, mSoilCropProperties.Surge2InfiltrationMethodProperty, Surge2InfiltrationMethods.BlairSmerdon)
        Me.IzunoPodmoreButton.LinkToModel(mMyStore, mSoilCropProperties.Surge2InfiltrationMethodProperty, Surge2InfiltrationMethods.IzunoPodmore)

        ' Update language translation
        UpdateLanguage()

        ' Update this control's User Interface
        Me.Dock = DockStyle.Fill

        UpdateUI()

    End Sub
    '
    ' Update UI when Inflow Management values change
    '
    Private Sub InflowManagement_PropertyChanged(ByVal _reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when System Geometry changes
    '
    Private Sub SystemGeometry_PropertyChanged(ByVal _reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Soil Crop Properties changes
    '
    Private Sub SoilCropProperties_PropertyChanged(ByVal _reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI when Event Criteria changes
    '
    Private Sub EventCriteria_PropertyChanged(ByVal _reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        UpdateUI()
    End Sub
    '
    ' Update UI graphics when Units change
    '
    Private Sub UnitsSystem_UpdateUnits(ByVal _reason As UnitsSystem.Reason) _
    Handles mUnitsSystem.UpdateUnits
        UpdateGraphics()
    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        ' Update the UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then
            UpdateCrossSection()
            UpdateInflowMethod()

            StandardHydrographControl.UpdateUI()
            SurgeInflowControl.UpdateUI()

            UpdateSurge2InfiltrationMethod()
            UpdateDrainback()
            UpdateGraphics()
        End If
    End Sub
    '
    ' Update the display of the Cross Section related UI
    '
    Private Sub UpdateCrossSection()

        ' Inflow controls' text vary by Cross Section
        Dim _crossSection As String = mSystemGeometry.CrossSectionName()

        Me.Title = _crossSection & " " & mDictionary.tInflow.Translated

    End Sub
    '
    ' Update the Inflow Method selection list & selection
    '
    Private Sub UpdateInflowMethod()

        ' Update selection list
        Dim inflowMethod As Integer = mInflowManagement.InflowMethod.Value
        Dim _sel As String = String.Empty
        Dim _idx As Integer = 0

        InflowMethodControl.Clear()

        Dim _selOk As Boolean = mInflowManagement.GetFirstInflowMethodSelection(_sel)
        While Not (_sel Is Nothing)
            If (_selOk) Then
                InflowMethodControl.Add(_sel, _idx, True)
            ElseIf (inflowMethod = _idx) Then
                InflowMethodControl.Add(_sel, _idx, False)
            End If
            _selOk = mInflowManagement.GetNextInflowMethodSelection(_sel)
            _idx += 1
        End While

        ' Update selection
        InflowMethodControl.UpdateUI()

        ' Hide / Show correspnding UI panels
        Select Case mInflowManagement.InflowMethod.Value

            Case InflowMethods.Surge
                TabulatedInflowPanel.Hide()
                CablegationPanel.Hide()
                StandardHydrographPanel.Hide()
                SurgePanel.Show()

            Case InflowMethods.Cablegation
                SurgePanel.Hide()
                TabulatedInflowPanel.Hide()
                StandardHydrographPanel.Hide()
                CablegationPanel.Show()

            Case InflowMethods.TabulatedInflow
                SurgePanel.Hide()
                CablegationPanel.Hide()
                StandardHydrographPanel.Hide()
                TabulatedInflowPanel.Show()

                TabulatedInflowControl.UpdateUI()

            Case Else ' Assume StandardHydrograph
                SurgePanel.Hide()
                CablegationPanel.Hide()
                TabulatedInflowPanel.Hide()
                StandardHydrographPanel.Show()

        End Select

    End Sub
    '
    ' Update Surge 2+ Infiltration selection
    '
    Private Sub UpdateSurge2InfiltrationMethod()

        ' Surge 2+ is for Surge Inflow selection only
        If ((Not mWinSRFR.UserLevel = UserLevels.Standard) And (mUnit.UnitType.Value = WorldTypes.SimulationWorld)) Then

            If ((mInflowManagement.InflowMethod.Value = InflowMethods.Surge)) Then
                Me.Surge2InfiltrationMethodGroup.Show()

                If (0.0 < mSoilCropProperties.KostiakovB) Then
                    Me.IzunoPodmoreButton.Enabled = True
                Else
                    Me.IzunoPodmoreButton.Enabled = False
                End If
            Else
                Me.Surge2InfiltrationMethodGroup.Hide()
            End If

        Else ' Standard UserLevel or Not Simulation World
            Me.Surge2InfiltrationMethodGroup.Hide()
        End If

    End Sub
    '
    ' Update Drainback selection
    '
    Private Sub UpdateDrainback()

        ' Drainback has limits on its availability
        Dim hideDrainback As Boolean = True
        Dim disableDrainback As Boolean = False

        ' Drainback is only for Research User in Simulation World
        If ((mWinSRFR.UserLevel = UserLevels.Research) And (mUnit.UnitType.Value = WorldTypes.SimulationWorld)) Then

            'If Not (mSystemGeometry.AverageSlope = 0.0) Then ' Slope must be 0.0
            '    disableDrainback = True
            'End If

            'If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then ' End must be Blocked
            '    disableDrainback = True
            'End If

            Select Case (mInflowManagement.InflowMethod.Value)

                ' Drainback is an available option for Standard Hydrograph wo/Cutback
                Case InflowMethods.StandardHydrograph

                    hideDrainback = False

                    If Not (mInflowManagement.CutbackMethod.Value = CutbackMethods.NoCutback) Then
                        disableDrainback = True
                    End If

                    ' Drainback is an available option for Tabulated Inflow
                Case InflowMethods.TabulatedInflow

                    hideDrainback = False

            End Select
        End If

        If (hideDrainback) Then
            Me.UpstreamDrainbackBox.Hide()
        Else
            Me.UpstreamDrainbackBox.Show()
            Me.UpstreamDrainbackBox.BringToFront()

            If (disableDrainback) Then
                Me.EnableDrainbackControl.Enabled = False
                Me.DrawDownTimeLabel.Enabled = False
                Me.DrawdownTimeControl.Enabled = False
                Me.DrawDownTimeLabel.Visible = False
                Me.DrawdownTimeControl.Visible = False
            Else
                Me.EnableDrainbackControl.Enabled = True

                ' Draw Down Time available only if Drainback
                If (mSystemGeometry.UpstreamCondition.Value = UpstreamConditions.DrainbackAfterCutoff) Then
                    Me.DrawDownTimeLabel.Enabled = True
                    Me.DrawdownTimeControl.Enabled = True
                    Me.DrawDownTimeLabel.Visible = True
                    Me.DrawdownTimeControl.Visible = True
                Else ' No Drainback
                    Me.DrawDownTimeLabel.Enabled = False
                    Me.DrawdownTimeControl.Enabled = False
                    Me.DrawDownTimeLabel.Visible = False
                    Me.DrawdownTimeControl.Visible = False
                End If
            End If
        End If

    End Sub
    '
    ' Update the current language translation
    '
    Private Sub UpdateLanguage()
        UpdateTranslation(Me)
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

                    Case InflowMethods.Surge
                        GraphSurgeInflow(InflowHydrograph)

                    Case InflowMethods.Cablegation
                        Dim _tabulatedInflow As DataTable = mInflowManagement.CablegationInflowTable
                        GraphTabulatedInflow(InflowHydrograph, _tabulatedInflow)

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

        Dim _maxTime As Double = _cutoffTime
        Dim _maxFlowRate As Double = _inflowRate

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

        If (mInflowManagement.InflowRateProperty.ToBeCalculated) Then
            _yAxis.MaxLabel = "TBD"
        Else
            _yAxis.MaxLabel = FlowRateString(_maxFlowRate, 0)
        End If
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

                If (mInflowManagement.CutoffTimeProperty.ToBeCalculated) Then
                    _xAxis.MaxLabel = "TBD"
                Else
                    _xAxis.MaxLabel = TimeString(_maxTime, 0)
                End If

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

                If (mInflowManagement.Unit.SystemGeometryRef.LengthProperty.ToBeCalculated) Then
                    _xAxis.MaxLabel = "TBD"
                Else
                    _xAxis.MaxLabel = mInflowManagement.Unit.SystemGeometryRef.Length.ValueString
                End If

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
        ' Update the Inflow-Outflow Mass Balance data
        '
        Dim _area As Double = mSystemGeometry.FieldArea

        If (0 < _area) Then
            If Not (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                If Not (mSystemGeometry.WidthProperty.ToBeCalculated) Then
                    Dim _appliedDepth As Double = _appliedVolume / _area
                    AppliedDepthLabel.Text = mDictionary.tAppliedDepth.Translated & " (Dapp)"
                    AppliedDepthValue.Text = "= " & DepthString(_appliedDepth, 0)
                End If
            End If
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

        Dim _maxTime As Double = _maxInflowTime
        Dim _maxFlowRate As Double = _maxInflow

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

        If Not (_tabulatedInflow Is Nothing) Then

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
        '
        ' Update the Inflow-Outflow Mass Balance data
        '
        Dim _area As Double = mSystemGeometry.FieldArea

        If (0 < _area) Then
            If Not (mSystemGeometry.LengthProperty.ToBeCalculated) Then
                If Not (mSystemGeometry.WidthProperty.ToBeCalculated) Then
                    Dim _appliedDepth As Double = _appliedVolume / _area
                    AppliedDepthLabel.Text = mDictionary.tAppliedDepth.Translated & " (Dapp)"
                    AppliedDepthValue.Text = "= " & DepthString(_appliedDepth, 0)
                End If
            End If
        End If
        '
        ' Add water volume data to graph
        '
        If (0.0 < _appliedVolume) Then

            Dim _volumeLabel As String = mDictionary.tInflow.Translated + ": " + FieldVolumeString(_appliedVolume, 0)

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
    '
    ' Graphics for Surge Inflow
    '
    Private Sub GraphSurgeInflow(ByVal _pictureBox As PictureBox)

        ' Get Surge Inflow values
        Dim L As Double = mSystemGeometry.Length.Value
        Dim Tco As Double = mInflowManagement.Cutoff
        Dim Qin As Double = mInflowManagement.SurgeInflowRate.Value
        Dim Qmax As Double = mInflowManagement.MaximumInflowRateForField
        Dim Qavg As Double = mInflowManagement.AverageInflowRateForField
        Dim Vapp As Double = mInflowManagement.AppliedVolumeForField
        Dim Area As Double = mSystemGeometry.FieldArea
        Dim Dapp As Double = Vapp / Area

        Dim numSurges As Double = mInflowManagement.NumberOfSurges.Value
        Dim startTime As Double = 0.0
        Dim onTime As Double = mInflowManagement.SurgeOnTime.Value
        Dim endTime As Double = startTime + onTime

        ' Get drawing tools
        Dim blackPen As Pen = BlackPen1()
        Dim grayBrush As SolidBrush = DarkGraySolidBrush()
        Dim whiteBrush As SolidBrush = WhiteSolidBrush()
        Dim bgPen As Pen = New Pen(Me.BackColor)
        Dim bgBrush As SolidBrush = New SolidBrush(Me.BackColor)
        Dim size As SizeF

        ' Create a bitmap for the graphics
        Dim _bitmap As Bitmap = New Bitmap(_pictureBox.Width, _pictureBox.Height)
        Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

        ' Fill the bitmap with the background color
        _graphics.FillRectangle(bgBrush, 0, 0, _pictureBox.Width, _pictureBox.Height)
        '
        ' Define & draw the Axes for the Hydrograph
        '
        Dim offset As Integer = 16 ' Offset into bitmap for axes
        Dim quadrant As QuadrantSelections = QuadrantSelections.UpperRight

        ' X-axis information (Time)
        Dim xAxis As Axis
        xAxis.AxisLabel = mDictionary.tTime.Translated
        xAxis.MaxValue = Tco
        xAxis.MaxLabel = TimeString(Tco, 0)

        ' Y-axis information (Inflow Rate)
        Dim yAxis As Axis
        yAxis.AxisLabel = mDictionary.tFlowRate.Translated
        yAxis.MaxValue = Qmax
        yAxis.MaxLabel = FlowRateString(Qmax, 0)

        DrawAxes(_bitmap, quadrant, xAxis, yAxis, offset, Me.Font)

        ' Scale value(s) to fit graphics area
        Qin *= 0.9
        '
        ' Draw the specific Surge Inflow
        '
        Select Case mInflowManagement.SurgeStrategy.Value

            Case SurgeStrategies.UniformTime

                ' Draw each Uniform Time Surge
                While (startTime < Tco)
                    DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, 0.0, startTime, Qin)

                    If (endTime < Tco) Then
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, Qin, endTime, Qin)
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, endTime, Qin, endTime, 0.0)
                    Else
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, Qin, Tco, Qin)
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, Tco, Qin, Tco, 0.0)
                    End If

                    startTime = endTime + onTime
                    endTime = startTime + onTime
                End While

            Case SurgeStrategies.TabulatedTime

                ' Draw each Tabulated Time Surge
                Dim surgeTable As DataTable = mInflowManagement.SurgeTimesTable.Value
                If (surgeTable IsNot Nothing) Then
                    For Each row As DataRow In surgeTable.Rows
                        startTime = row.Item(sStartTimeX)
                        endTime = row.Item(sEndTimeX)

                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, 0.0, startTime, Qin)
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, Qin, endTime, Qin)
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, endTime, Qin, endTime, 0.0)
                    Next
                End If

            Case Else ' Location Surges

                ' Draw Location Surges in 1st half of graph
                If (mInflowManagement.SurgeStrategy.Value = SurgeStrategies.UniformLocation) Then

                    Dim width As Double = Tco / 4 / numSurges
                    endTime = startTime + width

                    For sdx As Integer = 1 To numSurges
                        FillRect(_bitmap, quadrant, whiteBrush, xAxis, yAxis, offset, startTime, Qin, endTime, 0.0)
                        DrawRect(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, Qin, endTime, 0.0)
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime + (width / 2), Qin, startTime + (width / 2), 0.0)

                        startTime = endTime + width
                        endTime = startTime + width
                    Next
                Else
                    Dim surgeTable As DataTable = mInflowManagement.SurgeLocationsTable.Value
                    If (surgeTable IsNot Nothing) Then
                        Dim lastR As Double = 0.0

                        For Each row As DataRow In surgeTable.Rows
                            Dim R As Double = row.Item(sLocationX)
                            Dim width As Double = Tco / 4 * (R - lastR)
                            lastR = R

                            endTime = startTime + width

                            FillRect(_bitmap, quadrant, whiteBrush, xAxis, yAxis, offset, startTime, Qin, endTime, 0.0)
                            DrawRect(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, Qin, endTime, 0.0)
                            DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime + (width / 2), Qin, startTime + (width / 2), 0.0)

                            startTime = endTime + width
                        Next
                    End If
                End If

                ' Draw Uniform Time Surges in 2nd half of graph
                startTime = Tco / 2
                endTime = startTime + onTime

                While (startTime < Tco)
                    DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, 0.0, startTime, Qin)

                    If (endTime < Tco) Then
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, Qin, endTime, Qin)
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, endTime, Qin, endTime, 0.0)
                    Else
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, startTime, Qin, Tco, Qin)
                        DrawLine(_bitmap, quadrant, blackPen, xAxis, yAxis, offset, Tco, Qin, Tco, 0.0)
                    End If

                    startTime = endTime + onTime
                    endTime = startTime + onTime
                End While

                Dim noGraph As String = mDictionary.tRepresentativeLocationSurgeGraph.Translated
                size = _graphics.MeasureString(noGraph, Me.Font)
                _graphics.DrawString(noGraph, Me.Font, grayBrush, ((_bitmap.Width - size.Width) / 2.0), _bitmap.Height / 2.0)

        End Select
        '
        ' Add water volume data to graph
        '
        Dim volumeLabel As String = mDictionary.tInflow.Translated & ": ???"
        Dim avgInflowLabel As String = "Qavg: ???"

        If (0.0 < Vapp) Then
            volumeLabel = mDictionary.tInflow.Translated + ": " + FieldVolumeString(Vapp, 0)
            avgInflowLabel = "Qavg: " + FlowRateString(Qavg, 0)
        End If

        size = _graphics.MeasureString(volumeLabel, Me.Font)
        _graphics.DrawString(volumeLabel, Me.Font, grayBrush, _bitmap.Width - size.Width + 6, 0)

        size = _graphics.MeasureString(avgInflowLabel, Me.Font)
        _graphics.DrawString(avgInflowLabel, Me.Font, grayBrush, (_bitmap.Width - size.Width) / 2, 0)

        ' Add Applied Depth data under graph
        AppliedDepthLabel.Text = mDictionary.tAppliedDepth.Translated & " (Dapp)"

        If (0.0 < Dapp) Then
            AppliedDepthValue.Text = "= " & DepthString(Dapp, 0)
        Else
            AppliedDepthValue.Text = "= ???"
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

#Region " Model Event Handlers "
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

#End Region

#Region " UI Event Handlers "

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        ' Tabulated inflow
        Me.TabulatedInflowPanel.Height = Me.Height - Me.TabulatedInflowPanel.Location.Y - 4
        Me.TabulatedInflowControl.Height = Me.TabulatedInflowPanel.Height - 8

        ' Graphics
        Me.HydrographGraphicsPanel.Width = Me.Width - Me.HydrographGraphicsPanel.Location.X - 4
        Me.InflowHydrograph.Width = Me.HydrographGraphicsPanel.Width - 8
        UpdateGraphics()

    End Sub

    Private Sub TabulatedInflowControl_ControlValueChanged() _
    Handles TabulatedInflowControl.ControlValueChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub

    Private Sub SurgeInflowControl_ControlChanged(ByVal reason As ctl_SurgeInflow.Reasons) _
    Handles SurgeInflowControl.ControlChanged
        mWorldWindow.UpdateResultsControls()
        UpdateGraphics()
    End Sub
    '
    ' Make sure UI is up to date whenever it become visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

End Class
