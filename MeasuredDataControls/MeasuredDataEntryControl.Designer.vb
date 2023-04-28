<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MeasuredDataEntryControl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeasuredDataEntryControl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RatingTableParametersBox = New WinFlume.ctl_GroupBox()
        Me.H2H1Label = New WinFlume.ctl_Label()
        Me.y2Label = New WinFlume.ctl_Label()
        Me.h2Label2 = New WinFlume.ctl_Label()
        Me.h2Label1 = New WinFlume.ctl_Label()
        Me.CvLabel = New WinFlume.ctl_Label()
        Me.CdLabel = New WinFlume.ctl_Label()
        Me.V1Table = New WinFlume.ctl_Label()
        Me.y1Label = New WinFlume.ctl_Label()
        Me.H1Label = New WinFlume.ctl_Label()
        Me.H1LLabel = New WinFlume.ctl_Label()
        Me.H1H2Label = New WinFlume.ctl_Label()
        Me.FrLabel = New WinFlume.ctl_Label()
        Me.ModularLimitCheckBox = New WinFlume.ctl_CheckBox()
        Me.SubmergenceRatioCheckBox = New WinFlume.ctl_CheckBox()
        Me.ActualTailwaterDepthCheckBox = New WinFlume.ctl_CheckBox()
        Me.ActualTailwaterHeadCheckBox = New WinFlume.ctl_CheckBox()
        Me.MaxAllowableTailwaterHeadCheckBox = New WinFlume.ctl_CheckBox()
        Me.ClearAllButton = New WinFlume.ctl_Button()
        Me.SelectAllButton = New WinFlume.ctl_Button()
        Me.VelocityCoefficientCheckBox = New WinFlume.ctl_CheckBox()
        Me.DischargeCoefficientCheckBox = New WinFlume.ctl_CheckBox()
        Me.UpstreamVelocityCheckBox = New WinFlume.ctl_CheckBox()
        Me.UpstreamDepthCheckBox = New WinFlume.ctl_CheckBox()
        Me.UpstreamEnergyHeadCheckBox = New WinFlume.ctl_CheckBox()
        Me.HeadToCrestLengthRatioCheckBox = New WinFlume.ctl_CheckBox()
        Me.RequiredHeadLossCheckBox = New WinFlume.ctl_CheckBox()
        Me.FroudeNumberCheckBox = New WinFlume.ctl_CheckBox()
        Me.MeasuredDataBox = New WinFlume.ctl_GroupBox()
        Me.MeasuredDataTable = New WinFlume.ctl_DataGridView()
        Me.Head = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Discharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.InsertRowButton = New WinFlume.ctl_Button()
        Me.SortTableButton = New WinFlume.ctl_Button()
        Me.DeleteRowButton = New WinFlume.ctl_Button()
        Me.AddRowButton = New WinFlume.ctl_Button()
        Me.RatingTableParametersBox.SuspendLayout()
        Me.MeasuredDataBox.SuspendLayout()
        CType(Me.MeasuredDataTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RatingTableParametersBox
        '
        Me.RatingTableParametersBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.RatingTableParametersBox.Controls.Add(Me.H2H1Label)
        Me.RatingTableParametersBox.Controls.Add(Me.y2Label)
        Me.RatingTableParametersBox.Controls.Add(Me.h2Label2)
        Me.RatingTableParametersBox.Controls.Add(Me.h2Label1)
        Me.RatingTableParametersBox.Controls.Add(Me.CvLabel)
        Me.RatingTableParametersBox.Controls.Add(Me.CdLabel)
        Me.RatingTableParametersBox.Controls.Add(Me.V1Table)
        Me.RatingTableParametersBox.Controls.Add(Me.y1Label)
        Me.RatingTableParametersBox.Controls.Add(Me.H1Label)
        Me.RatingTableParametersBox.Controls.Add(Me.H1LLabel)
        Me.RatingTableParametersBox.Controls.Add(Me.H1H2Label)
        Me.RatingTableParametersBox.Controls.Add(Me.FrLabel)
        Me.RatingTableParametersBox.Controls.Add(Me.ModularLimitCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.SubmergenceRatioCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.ActualTailwaterDepthCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.ActualTailwaterHeadCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.MaxAllowableTailwaterHeadCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.ClearAllButton)
        Me.RatingTableParametersBox.Controls.Add(Me.SelectAllButton)
        Me.RatingTableParametersBox.Controls.Add(Me.VelocityCoefficientCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.DischargeCoefficientCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.UpstreamVelocityCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.UpstreamDepthCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.UpstreamEnergyHeadCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.HeadToCrestLengthRatioCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.RequiredHeadLossCheckBox)
        Me.RatingTableParametersBox.Controls.Add(Me.FroudeNumberCheckBox)
        resources.ApplyResources(Me.RatingTableParametersBox, "RatingTableParametersBox")
        Me.RatingTableParametersBox.Name = "RatingTableParametersBox"
        Me.RatingTableParametersBox.TabStop = False
        '
        'H2H1Label
        '
        resources.ApplyResources(Me.H2H1Label, "H2H1Label")
        Me.H2H1Label.Name = "H2H1Label"
        Me.H2H1Label.Tag = "13"
        '
        'y2Label
        '
        resources.ApplyResources(Me.y2Label, "y2Label")
        Me.y2Label.Name = "y2Label"
        Me.y2Label.Tag = "12"
        '
        'h2Label2
        '
        resources.ApplyResources(Me.h2Label2, "h2Label2")
        Me.h2Label2.Name = "h2Label2"
        Me.h2Label2.Tag = "11"
        '
        'h2Label1
        '
        resources.ApplyResources(Me.h2Label1, "h2Label1")
        Me.h2Label1.Name = "h2Label1"
        Me.h2Label1.Tag = "10"
        '
        'CvLabel
        '
        resources.ApplyResources(Me.CvLabel, "CvLabel")
        Me.CvLabel.Name = "CvLabel"
        Me.CvLabel.Tag = "9"
        '
        'CdLabel
        '
        resources.ApplyResources(Me.CdLabel, "CdLabel")
        Me.CdLabel.Name = "CdLabel"
        Me.CdLabel.Tag = "8"
        '
        'V1Table
        '
        resources.ApplyResources(Me.V1Table, "V1Table")
        Me.V1Table.Name = "V1Table"
        Me.V1Table.Tag = "7"
        '
        'y1Label
        '
        resources.ApplyResources(Me.y1Label, "y1Label")
        Me.y1Label.Name = "y1Label"
        Me.y1Label.Tag = "6"
        '
        'H1Label
        '
        resources.ApplyResources(Me.H1Label, "H1Label")
        Me.H1Label.Name = "H1Label"
        Me.H1Label.Tag = "5"
        '
        'H1LLabel
        '
        resources.ApplyResources(Me.H1LLabel, "H1LLabel")
        Me.H1LLabel.Name = "H1LLabel"
        Me.H1LLabel.Tag = "4"
        '
        'H1H2Label
        '
        resources.ApplyResources(Me.H1H2Label, "H1H2Label")
        Me.H1H2Label.Name = "H1H2Label"
        Me.H1H2Label.Tag = "3"
        '
        'FrLabel
        '
        resources.ApplyResources(Me.FrLabel, "FrLabel")
        Me.FrLabel.Name = "FrLabel"
        Me.FrLabel.Tag = "2"
        '
        'ModularLimitCheckBox
        '
        resources.ApplyResources(Me.ModularLimitCheckBox, "ModularLimitCheckBox")
        Me.ModularLimitCheckBox.Name = "ModularLimitCheckBox"
        Me.ModularLimitCheckBox.Tag = "17"
        Me.ModularLimitCheckBox.UseVisualStyleBackColor = True
        Me.ModularLimitCheckBox.Value = False
        '
        'SubmergenceRatioCheckBox
        '
        resources.ApplyResources(Me.SubmergenceRatioCheckBox, "SubmergenceRatioCheckBox")
        Me.SubmergenceRatioCheckBox.Name = "SubmergenceRatioCheckBox"
        Me.SubmergenceRatioCheckBox.Tag = "16"
        Me.SubmergenceRatioCheckBox.UseVisualStyleBackColor = True
        Me.SubmergenceRatioCheckBox.Value = False
        '
        'ActualTailwaterDepthCheckBox
        '
        resources.ApplyResources(Me.ActualTailwaterDepthCheckBox, "ActualTailwaterDepthCheckBox")
        Me.ActualTailwaterDepthCheckBox.Name = "ActualTailwaterDepthCheckBox"
        Me.ActualTailwaterDepthCheckBox.Tag = "15"
        Me.ActualTailwaterDepthCheckBox.UseVisualStyleBackColor = True
        Me.ActualTailwaterDepthCheckBox.Value = False
        '
        'ActualTailwaterHeadCheckBox
        '
        resources.ApplyResources(Me.ActualTailwaterHeadCheckBox, "ActualTailwaterHeadCheckBox")
        Me.ActualTailwaterHeadCheckBox.Name = "ActualTailwaterHeadCheckBox"
        Me.ActualTailwaterHeadCheckBox.Tag = "14"
        Me.ActualTailwaterHeadCheckBox.UseVisualStyleBackColor = True
        Me.ActualTailwaterHeadCheckBox.Value = False
        '
        'MaxAllowableTailwaterHeadCheckBox
        '
        resources.ApplyResources(Me.MaxAllowableTailwaterHeadCheckBox, "MaxAllowableTailwaterHeadCheckBox")
        Me.MaxAllowableTailwaterHeadCheckBox.Name = "MaxAllowableTailwaterHeadCheckBox"
        Me.MaxAllowableTailwaterHeadCheckBox.Tag = "13"
        Me.MaxAllowableTailwaterHeadCheckBox.UseVisualStyleBackColor = True
        Me.MaxAllowableTailwaterHeadCheckBox.Value = False
        '
        'ClearAllButton
        '
        Me.ClearAllButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.ClearAllButton, "ClearAllButton")
        Me.ClearAllButton.Name = "ClearAllButton"
        Me.ClearAllButton.UseVisualStyleBackColor = False
        '
        'SelectAllButton
        '
        Me.SelectAllButton.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.SelectAllButton, "SelectAllButton")
        Me.SelectAllButton.Name = "SelectAllButton"
        Me.SelectAllButton.UseVisualStyleBackColor = False
        '
        'VelocityCoefficientCheckBox
        '
        resources.ApplyResources(Me.VelocityCoefficientCheckBox, "VelocityCoefficientCheckBox")
        Me.VelocityCoefficientCheckBox.Name = "VelocityCoefficientCheckBox"
        Me.VelocityCoefficientCheckBox.Tag = "12"
        Me.VelocityCoefficientCheckBox.UseVisualStyleBackColor = True
        Me.VelocityCoefficientCheckBox.Value = False
        '
        'DischargeCoefficientCheckBox
        '
        resources.ApplyResources(Me.DischargeCoefficientCheckBox, "DischargeCoefficientCheckBox")
        Me.DischargeCoefficientCheckBox.Name = "DischargeCoefficientCheckBox"
        Me.DischargeCoefficientCheckBox.Tag = "11"
        Me.DischargeCoefficientCheckBox.UseVisualStyleBackColor = True
        Me.DischargeCoefficientCheckBox.Value = False
        '
        'UpstreamVelocityCheckBox
        '
        resources.ApplyResources(Me.UpstreamVelocityCheckBox, "UpstreamVelocityCheckBox")
        Me.UpstreamVelocityCheckBox.Name = "UpstreamVelocityCheckBox"
        Me.UpstreamVelocityCheckBox.Tag = "10"
        Me.UpstreamVelocityCheckBox.UseVisualStyleBackColor = True
        Me.UpstreamVelocityCheckBox.Value = False
        '
        'UpstreamDepthCheckBox
        '
        resources.ApplyResources(Me.UpstreamDepthCheckBox, "UpstreamDepthCheckBox")
        Me.UpstreamDepthCheckBox.Name = "UpstreamDepthCheckBox"
        Me.UpstreamDepthCheckBox.Tag = "9"
        Me.UpstreamDepthCheckBox.UseVisualStyleBackColor = True
        Me.UpstreamDepthCheckBox.Value = False
        '
        'UpstreamEnergyHeadCheckBox
        '
        resources.ApplyResources(Me.UpstreamEnergyHeadCheckBox, "UpstreamEnergyHeadCheckBox")
        Me.UpstreamEnergyHeadCheckBox.Name = "UpstreamEnergyHeadCheckBox"
        Me.UpstreamEnergyHeadCheckBox.Tag = "8"
        Me.UpstreamEnergyHeadCheckBox.UseVisualStyleBackColor = True
        Me.UpstreamEnergyHeadCheckBox.Value = False
        '
        'HeadToCrestLengthRatioCheckBox
        '
        resources.ApplyResources(Me.HeadToCrestLengthRatioCheckBox, "HeadToCrestLengthRatioCheckBox")
        Me.HeadToCrestLengthRatioCheckBox.Name = "HeadToCrestLengthRatioCheckBox"
        Me.HeadToCrestLengthRatioCheckBox.Tag = "7"
        Me.HeadToCrestLengthRatioCheckBox.UseVisualStyleBackColor = True
        Me.HeadToCrestLengthRatioCheckBox.Value = False
        '
        'RequiredHeadLossCheckBox
        '
        resources.ApplyResources(Me.RequiredHeadLossCheckBox, "RequiredHeadLossCheckBox")
        Me.RequiredHeadLossCheckBox.Name = "RequiredHeadLossCheckBox"
        Me.RequiredHeadLossCheckBox.Tag = "6"
        Me.RequiredHeadLossCheckBox.UseVisualStyleBackColor = True
        Me.RequiredHeadLossCheckBox.Value = False
        '
        'FroudeNumberCheckBox
        '
        resources.ApplyResources(Me.FroudeNumberCheckBox, "FroudeNumberCheckBox")
        Me.FroudeNumberCheckBox.Name = "FroudeNumberCheckBox"
        Me.FroudeNumberCheckBox.Tag = "5"
        Me.FroudeNumberCheckBox.UseVisualStyleBackColor = True
        Me.FroudeNumberCheckBox.Value = False
        '
        'MeasuredDataBox
        '
        Me.MeasuredDataBox.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.MeasuredDataBox, "MeasuredDataBox")
        Me.MeasuredDataBox.Controls.Add(Me.MeasuredDataTable)
        Me.MeasuredDataBox.Controls.Add(Me.ControlPanel)
        Me.MeasuredDataBox.Name = "MeasuredDataBox"
        Me.MeasuredDataBox.TabStop = False
        '
        'MeasuredDataTable
        '
        resources.ApplyResources(Me.MeasuredDataTable, "MeasuredDataTable")
        Me.MeasuredDataTable.AllowUserToAddRows = False
        Me.MeasuredDataTable.AllowUserToDeleteRows = False
        Me.MeasuredDataTable.AllowUserToResizeColumns = False
        Me.MeasuredDataTable.AllowUserToResizeRows = False
        Me.MeasuredDataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.MeasuredDataTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.MeasuredDataTable.CausesValidation = False
        Me.MeasuredDataTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MeasuredDataTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MeasuredDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MeasuredDataTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Head, Me.Discharge})
        Me.MeasuredDataTable.GridColor = System.Drawing.Color.Black
        Me.MeasuredDataTable.MultiSelect = False
        Me.MeasuredDataTable.Name = "MeasuredDataTable"
        Me.MeasuredDataTable.RowHeadersVisible = False
        Me.MeasuredDataTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.MeasuredDataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        '
        'Head
        '
        resources.ApplyResources(Me.Head, "Head")
        Me.Head.Name = "Head"
        '
        'Discharge
        '
        resources.ApplyResources(Me.Discharge, "Discharge")
        Me.Discharge.Name = "Discharge"
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.InsertRowButton)
        Me.ControlPanel.Controls.Add(Me.SortTableButton)
        Me.ControlPanel.Controls.Add(Me.DeleteRowButton)
        Me.ControlPanel.Controls.Add(Me.AddRowButton)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'InsertRowButton
        '
        Me.InsertRowButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.InsertRowButton, "InsertRowButton")
        Me.InsertRowButton.Name = "InsertRowButton"
        Me.InsertRowButton.UseVisualStyleBackColor = False
        '
        'SortTableButton
        '
        Me.SortTableButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.SortTableButton, "SortTableButton")
        Me.SortTableButton.Name = "SortTableButton"
        Me.SortTableButton.UseVisualStyleBackColor = False
        '
        'DeleteRowButton
        '
        Me.DeleteRowButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.DeleteRowButton, "DeleteRowButton")
        Me.DeleteRowButton.Name = "DeleteRowButton"
        Me.DeleteRowButton.UseVisualStyleBackColor = False
        '
        'AddRowButton
        '
        Me.AddRowButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.AddRowButton, "AddRowButton")
        Me.AddRowButton.Name = "AddRowButton"
        Me.AddRowButton.UseVisualStyleBackColor = False
        '
        'MeasuredDataEntryControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.RatingTableParametersBox)
        Me.Controls.Add(Me.MeasuredDataBox)
        Me.Name = "MeasuredDataEntryControl"
        Me.RatingTableParametersBox.ResumeLayout(False)
        Me.RatingTableParametersBox.PerformLayout()
        Me.MeasuredDataBox.ResumeLayout(False)
        CType(Me.MeasuredDataTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MeasuredDataBox As ctl_GroupBox
    Friend WithEvents RatingTableParametersBox As ctl_GroupBox
    Friend WithEvents H2H1Label As ctl_Label
    Friend WithEvents y2Label As ctl_Label
    Friend WithEvents h2Label2 As ctl_Label
    Friend WithEvents h2Label1 As ctl_Label
    Friend WithEvents CvLabel As ctl_Label
    Friend WithEvents CdLabel As ctl_Label
    Friend WithEvents V1Table As ctl_Label
    Friend WithEvents y1Label As ctl_Label
    Friend WithEvents H1Label As ctl_Label
    Friend WithEvents H1LLabel As ctl_Label
    Friend WithEvents H1H2Label As ctl_Label
    Friend WithEvents FrLabel As ctl_Label
    Friend WithEvents ModularLimitCheckBox As ctl_CheckBox
    Friend WithEvents SubmergenceRatioCheckBox As ctl_CheckBox
    Friend WithEvents ActualTailwaterDepthCheckBox As ctl_CheckBox
    Friend WithEvents ActualTailwaterHeadCheckBox As ctl_CheckBox
    Friend WithEvents MaxAllowableTailwaterHeadCheckBox As ctl_CheckBox
    Friend WithEvents ClearAllButton As ctl_Button
    Friend WithEvents SelectAllButton As ctl_Button
    Friend WithEvents VelocityCoefficientCheckBox As ctl_CheckBox
    Friend WithEvents DischargeCoefficientCheckBox As ctl_CheckBox
    Friend WithEvents UpstreamVelocityCheckBox As ctl_CheckBox
    Friend WithEvents UpstreamDepthCheckBox As ctl_CheckBox
    Friend WithEvents UpstreamEnergyHeadCheckBox As ctl_CheckBox
    Friend WithEvents HeadToCrestLengthRatioCheckBox As ctl_CheckBox
    Friend WithEvents RequiredHeadLossCheckBox As ctl_CheckBox
    Friend WithEvents FroudeNumberCheckBox As ctl_CheckBox
    Friend WithEvents ControlPanel As ctl_Panel
    Friend WithEvents InsertRowButton As ctl_Button
    Friend WithEvents SortTableButton As ctl_Button
    Friend WithEvents DeleteRowButton As ctl_Button
    Friend WithEvents AddRowButton As ctl_Button
    Friend WithEvents MeasuredDataTable As ctl_DataGridView
    Friend WithEvents Head As DataGridViewTextBoxColumn
    Friend WithEvents Discharge As DataGridViewTextBoxColumn
End Class
