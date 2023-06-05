<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlternativeDesignsControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlternativeDesignsControl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.DesignOptionSelection = New WinFlume.ctl_Label()
        Me.DesignOptionLabel = New WinFlume.ctl_Label()
        Me.FormInstructions = New WinFlume.ctl_Label()
        Me.ViewAsDialogButton = New System.Windows.Forms.Button()
        Me.ControlSectionShape = New WinFlume.ctl_Label()
        Me.ControlSectionLabel = New WinFlume.ctl_Label()
        Me.StatusLabel = New WinFlume.ctl_Label()
        Me.ReviewDesignsTable = New WinFlume.ctl_DataGridView()
        Me.SillHeightColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControlWidthColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FroudNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FreeboardAtQmaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TailwaterAtQmaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TailwaterAtQminColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccuracyAtQmaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccuracyAtQminColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HeadLossCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActualHeadLossColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActualFroudeNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExtraFreeboardColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubmergenceProtectionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstimatedRandomErrorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControlPanel.SuspendLayout()
        CType(Me.ReviewDesignsTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.DesignOptionSelection)
        Me.ControlPanel.Controls.Add(Me.DesignOptionLabel)
        Me.ControlPanel.Controls.Add(Me.FormInstructions)
        Me.ControlPanel.Controls.Add(Me.ViewAsDialogButton)
        Me.ControlPanel.Controls.Add(Me.ControlSectionShape)
        Me.ControlPanel.Controls.Add(Me.ControlSectionLabel)
        resources.ApplyResources(Me.ControlPanel, "ControlPanel")
        Me.ControlPanel.Name = "ControlPanel"
        '
        'DesignOptionSelection
        '
        Me.DesignOptionSelection.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.DesignOptionSelection, "DesignOptionSelection")
        Me.DesignOptionSelection.Name = "DesignOptionSelection"
        '
        'DesignOptionLabel
        '
        resources.ApplyResources(Me.DesignOptionLabel, "DesignOptionLabel")
        Me.DesignOptionLabel.Name = "DesignOptionLabel"
        '
        'FormInstructions
        '
        resources.ApplyResources(Me.FormInstructions, "FormInstructions")
        Me.FormInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.FormInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FormInstructions.Name = "FormInstructions"
        '
        'ViewAsDialogButton
        '
        resources.ApplyResources(Me.ViewAsDialogButton, "ViewAsDialogButton")
        Me.ViewAsDialogButton.Name = "ViewAsDialogButton"
        Me.ViewAsDialogButton.UseVisualStyleBackColor = True
        '
        'ControlSectionShape
        '
        resources.ApplyResources(Me.ControlSectionShape, "ControlSectionShape")
        Me.ControlSectionShape.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ControlSectionShape.Name = "ControlSectionShape"
        '
        'ControlSectionLabel
        '
        resources.ApplyResources(Me.ControlSectionLabel, "ControlSectionLabel")
        Me.ControlSectionLabel.Name = "ControlSectionLabel"
        '
        'StatusLabel
        '
        Me.StatusLabel.BackColor = System.Drawing.Color.LightBlue
        resources.ApplyResources(Me.StatusLabel, "StatusLabel")
        Me.StatusLabel.Name = "StatusLabel"
        '
        'ReviewDesignsTable
        '
        resources.ApplyResources(Me.ReviewDesignsTable, "ReviewDesignsTable")
        Me.ReviewDesignsTable.AllowUserToAddRows = False
        Me.ReviewDesignsTable.AllowUserToDeleteRows = False
        Me.ReviewDesignsTable.AllowUserToResizeColumns = False
        Me.ReviewDesignsTable.AllowUserToResizeRows = False
        Me.ReviewDesignsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.ReviewDesignsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.ReviewDesignsTable.CausesValidation = False
        Me.ReviewDesignsTable.ClipboardColHeaders = Nothing
        Me.ReviewDesignsTable.ClipboardColUnits = Nothing
        Me.ReviewDesignsTable.ClipboardRows = Nothing
        Me.ReviewDesignsTable.ClipboardText = Nothing
        Me.ReviewDesignsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReviewDesignsTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ReviewDesignsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReviewDesignsTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SillHeightColumn, Me.ControlWidthColumn, Me.FroudNumberColumn, Me.FreeboardAtQmaxColumn, Me.TailwaterAtQmaxColumn, Me.TailwaterAtQminColumn, Me.AccuracyAtQmaxColumn, Me.AccuracyAtQminColumn, Me.HeadLossCommentColumn, Me.ActualHeadLossColumn, Me.ActualFroudeNumberColumn, Me.ExtraFreeboardColumn, Me.SubmergenceProtectionColumn, Me.EstimatedRandomErrorColumn})
        Me.ReviewDesignsTable.GridColor = System.Drawing.Color.Black
        Me.ReviewDesignsTable.MultiSelect = False
        Me.ReviewDesignsTable.Name = "ReviewDesignsTable"
        Me.ReviewDesignsTable.ReadOnly = True
        Me.ReviewDesignsTable.RowHeadersVisible = False
        Me.ReviewDesignsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ReviewDesignsTable.TableColUnits = Nothing
        '
        'SillHeightColumn
        '
        Me.SillHeightColumn.Frozen = True
        resources.ApplyResources(Me.SillHeightColumn, "SillHeightColumn")
        Me.SillHeightColumn.Name = "SillHeightColumn"
        Me.SillHeightColumn.ReadOnly = True
        '
        'ControlWidthColumn
        '
        Me.ControlWidthColumn.Frozen = True
        resources.ApplyResources(Me.ControlWidthColumn, "ControlWidthColumn")
        Me.ControlWidthColumn.Name = "ControlWidthColumn"
        Me.ControlWidthColumn.ReadOnly = True
        '
        'FroudNumberColumn
        '
        resources.ApplyResources(Me.FroudNumberColumn, "FroudNumberColumn")
        Me.FroudNumberColumn.Name = "FroudNumberColumn"
        Me.FroudNumberColumn.ReadOnly = True
        '
        'FreeboardAtQmaxColumn
        '
        resources.ApplyResources(Me.FreeboardAtQmaxColumn, "FreeboardAtQmaxColumn")
        Me.FreeboardAtQmaxColumn.Name = "FreeboardAtQmaxColumn"
        Me.FreeboardAtQmaxColumn.ReadOnly = True
        '
        'TailwaterAtQmaxColumn
        '
        resources.ApplyResources(Me.TailwaterAtQmaxColumn, "TailwaterAtQmaxColumn")
        Me.TailwaterAtQmaxColumn.Name = "TailwaterAtQmaxColumn"
        Me.TailwaterAtQmaxColumn.ReadOnly = True
        '
        'TailwaterAtQminColumn
        '
        resources.ApplyResources(Me.TailwaterAtQminColumn, "TailwaterAtQminColumn")
        Me.TailwaterAtQminColumn.Name = "TailwaterAtQminColumn"
        Me.TailwaterAtQminColumn.ReadOnly = True
        '
        'AccuracyAtQmaxColumn
        '
        resources.ApplyResources(Me.AccuracyAtQmaxColumn, "AccuracyAtQmaxColumn")
        Me.AccuracyAtQmaxColumn.Name = "AccuracyAtQmaxColumn"
        Me.AccuracyAtQmaxColumn.ReadOnly = True
        '
        'AccuracyAtQminColumn
        '
        resources.ApplyResources(Me.AccuracyAtQminColumn, "AccuracyAtQminColumn")
        Me.AccuracyAtQminColumn.Name = "AccuracyAtQminColumn"
        Me.AccuracyAtQminColumn.ReadOnly = True
        '
        'HeadLossCommentColumn
        '
        resources.ApplyResources(Me.HeadLossCommentColumn, "HeadLossCommentColumn")
        Me.HeadLossCommentColumn.Name = "HeadLossCommentColumn"
        Me.HeadLossCommentColumn.ReadOnly = True
        '
        'ActualHeadLossColumn
        '
        resources.ApplyResources(Me.ActualHeadLossColumn, "ActualHeadLossColumn")
        Me.ActualHeadLossColumn.Name = "ActualHeadLossColumn"
        Me.ActualHeadLossColumn.ReadOnly = True
        '
        'ActualFroudeNumberColumn
        '
        resources.ApplyResources(Me.ActualFroudeNumberColumn, "ActualFroudeNumberColumn")
        Me.ActualFroudeNumberColumn.Name = "ActualFroudeNumberColumn"
        Me.ActualFroudeNumberColumn.ReadOnly = True
        '
        'ExtraFreeboardColumn
        '
        resources.ApplyResources(Me.ExtraFreeboardColumn, "ExtraFreeboardColumn")
        Me.ExtraFreeboardColumn.Name = "ExtraFreeboardColumn"
        Me.ExtraFreeboardColumn.ReadOnly = True
        '
        'SubmergenceProtectionColumn
        '
        resources.ApplyResources(Me.SubmergenceProtectionColumn, "SubmergenceProtectionColumn")
        Me.SubmergenceProtectionColumn.Name = "SubmergenceProtectionColumn"
        Me.SubmergenceProtectionColumn.ReadOnly = True
        '
        'EstimatedRandomErrorColumn
        '
        resources.ApplyResources(Me.EstimatedRandomErrorColumn, "EstimatedRandomErrorColumn")
        Me.EstimatedRandomErrorColumn.Name = "EstimatedRandomErrorColumn"
        Me.EstimatedRandomErrorColumn.ReadOnly = True
        '
        'AlternativeDesignsControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.ReviewDesignsTable)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.ControlPanel)
        Me.Name = "AlternativeDesignsControl"
        Me.ControlPanel.ResumeLayout(False)
        Me.ControlPanel.PerformLayout()
        CType(Me.ReviewDesignsTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ControlPanel As WinFlume.ctl_Panel
    Friend WithEvents ControlSectionShape As WinFlume.ctl_Label
    Friend WithEvents ControlSectionLabel As WinFlume.ctl_Label
    Friend WithEvents StatusLabel As ctl_Label
    Friend WithEvents ReviewDesignsTable As ctl_DataGridView
    Friend WithEvents FormInstructions As ctl_Label
    Friend WithEvents SillHeightColumn As DataGridViewTextBoxColumn
    Friend WithEvents ControlWidthColumn As DataGridViewTextBoxColumn
    Friend WithEvents FroudNumberColumn As DataGridViewTextBoxColumn
    Friend WithEvents FreeboardAtQmaxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TailwaterAtQmaxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TailwaterAtQminColumn As DataGridViewTextBoxColumn
    Friend WithEvents AccuracyAtQmaxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AccuracyAtQminColumn As DataGridViewTextBoxColumn
    Friend WithEvents HeadLossCommentColumn As DataGridViewTextBoxColumn
    Friend WithEvents ActualHeadLossColumn As DataGridViewTextBoxColumn
    Friend WithEvents ActualFroudeNumberColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExtraFreeboardColumn As DataGridViewTextBoxColumn
    Friend WithEvents SubmergenceProtectionColumn As DataGridViewTextBoxColumn
    Friend WithEvents EstimatedRandomErrorColumn As DataGridViewTextBoxColumn
    Friend WithEvents ViewAsDialogButton As Button
    Friend WithEvents DesignOptionSelection As ctl_Label
    Friend WithEvents DesignOptionLabel As ctl_Label
End Class
