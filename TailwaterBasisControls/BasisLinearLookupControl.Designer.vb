<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BasisLinearLookupControl
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LinearLookupTable = New WinFlume.ctl_DataGridView()
        Me.Discharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TailwaterLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControlPanel = New WinFlume.ctl_Panel()
        Me.InsertRowButton = New WinFlume.ctl_Button()
        Me.SortTableButton = New WinFlume.ctl_Button()
        Me.DeleteRowButton = New WinFlume.ctl_Button()
        Me.AddRowButton = New WinFlume.ctl_Button()
        Me.HelpLabel = New WinFlume.ctl_Label()
        CType(Me.LinearLookupTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'LinearLookupTable
        '
        Me.LinearLookupTable.AccessibleDescription = "Copyable table of data"
        Me.LinearLookupTable.AccessibleName = "Linear Lookup Table"
        Me.LinearLookupTable.AllowUserToAddRows = False
        Me.LinearLookupTable.AllowUserToDeleteRows = False
        Me.LinearLookupTable.AllowUserToResizeColumns = False
        Me.LinearLookupTable.AllowUserToResizeRows = False
        Me.LinearLookupTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.LinearLookupTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.LinearLookupTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LinearLookupTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.LinearLookupTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LinearLookupTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Discharge, Me.TailwaterLevel})
        Me.LinearLookupTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LinearLookupTable.GridColor = System.Drawing.Color.Black
        Me.LinearLookupTable.Location = New System.Drawing.Point(0, 0)
        Me.LinearLookupTable.MultiSelect = False
        Me.LinearLookupTable.Name = "LinearLookupTable"
        Me.LinearLookupTable.RowHeadersVisible = False
        Me.LinearLookupTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.LinearLookupTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.LinearLookupTable.Size = New System.Drawing.Size(307, 100)
        Me.LinearLookupTable.TabIndex = 0
        '
        'Discharge
        '
        Me.Discharge.HeaderText = "Discharge"
        Me.Discharge.Name = "Discharge"
        '
        'TailwaterLevel
        '
        Me.TailwaterLevel.HeaderText = "Tailwater Level"
        Me.TailwaterLevel.Name = "TailwaterLevel"
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.InsertRowButton)
        Me.ControlPanel.Controls.Add(Me.SortTableButton)
        Me.ControlPanel.Controls.Add(Me.DeleteRowButton)
        Me.ControlPanel.Controls.Add(Me.AddRowButton)
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ControlPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ControlPanel.Location = New System.Drawing.Point(307, 0)
        Me.ControlPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(140, 100)
        Me.ControlPanel.TabIndex = 1
        '
        'InsertRowButton
        '
        Me.InsertRowButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.InsertRowButton.Location = New System.Drawing.Point(10, 2)
        Me.InsertRowButton.Name = "InsertRowButton"
        Me.InsertRowButton.Size = New System.Drawing.Size(120, 23)
        Me.InsertRowButton.TabIndex = 0
        Me.InsertRowButton.Text = "Insert Row"
        Me.InsertRowButton.UseVisualStyleBackColor = False
        '
        'SortTableButton
        '
        Me.SortTableButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.SortTableButton.Location = New System.Drawing.Point(10, 74)
        Me.SortTableButton.Name = "SortTableButton"
        Me.SortTableButton.Size = New System.Drawing.Size(120, 23)
        Me.SortTableButton.TabIndex = 3
        Me.SortTableButton.Text = "Sort Table"
        Me.SortTableButton.UseVisualStyleBackColor = False
        '
        'DeleteRowButton
        '
        Me.DeleteRowButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DeleteRowButton.Location = New System.Drawing.Point(10, 50)
        Me.DeleteRowButton.Name = "DeleteRowButton"
        Me.DeleteRowButton.Size = New System.Drawing.Size(120, 23)
        Me.DeleteRowButton.TabIndex = 2
        Me.DeleteRowButton.Text = "Delete Row"
        Me.DeleteRowButton.UseVisualStyleBackColor = False
        '
        'AddRowButton
        '
        Me.AddRowButton.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.AddRowButton.Location = New System.Drawing.Point(10, 26)
        Me.AddRowButton.Name = "AddRowButton"
        Me.AddRowButton.Size = New System.Drawing.Size(120, 23)
        Me.AddRowButton.TabIndex = 1
        Me.AddRowButton.Text = "Add Row"
        Me.AddRowButton.UseVisualStyleBackColor = False
        '
        'HelpLabel
        '
        Me.HelpLabel.BackColor = System.Drawing.SystemColors.Info
        Me.HelpLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HelpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpLabel.Location = New System.Drawing.Point(0, 100)
        Me.HelpLabel.Name = "HelpLabel"
        Me.HelpLabel.Size = New System.Drawing.Size(447, 40)
        Me.HelpLabel.TabIndex = 2
        Me.HelpLabel.Text = "Tailwater levels should be specified relative to the invert of the downstream cha" &
    "nnel"
        Me.HelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BasisLinearLookupControl
        '
        Me.AccessibleDescription = ""
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Controls.Add(Me.LinearLookupTable)
        Me.Controls.Add(Me.ControlPanel)
        Me.Controls.Add(Me.HelpLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "BasisLinearLookupControl"
        Me.Size = New System.Drawing.Size(447, 140)
        CType(Me.LinearLookupTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HelpLabel As WinFlume.ctl_Label
    Friend WithEvents LinearLookupTable As ctl_DataGridView
    Friend WithEvents Discharge As DataGridViewTextBoxColumn
    Friend WithEvents TailwaterLevel As DataGridViewTextBoxColumn
    Friend WithEvents AddRowButton As ctl_Button
    Friend WithEvents DeleteRowButton As ctl_Button
    Friend WithEvents ControlPanel As ctl_Panel
    Friend WithEvents InsertRowButton As ctl_Button
    Friend WithEvents SortTableButton As ctl_Button
End Class
