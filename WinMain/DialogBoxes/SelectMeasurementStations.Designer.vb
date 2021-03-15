<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectMeasurementStations
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Instructions = New DataStore.ctl_Label
        Me.SelectionList = New DataStore.ctl_DataTableParameter
        Me.ClearAll_Button = New DataStore.ctl_Button
        Me.SelectAll_Button = New DataStore.ctl_Button
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SelectionList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(191, 426)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(195, 36)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 10
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(101, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
        Me.Cancel_Button.TabIndex = 11
        Me.Cancel_Button.Text = "Cancel"
        '
        'Instructions
        '
        Me.Instructions.BackColor = System.Drawing.SystemColors.Info
        Me.Instructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Instructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Instructions.Location = New System.Drawing.Point(10, 10)
        Me.Instructions.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Instructions.Name = "Instructions"
        Me.Instructions.Size = New System.Drawing.Size(374, 54)
        Me.Instructions.TabIndex = 1
        Me.Instructions.Text = "Use the Select column to choose Measurement Station locations from the System Geo" & _
            "metry's Elevation Table."
        '
        'SelectionList
        '
        Me.SelectionList.AllRowsFixed = False
        Me.SelectionList.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.SelectionList.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.SelectionList.CausesValidation = False
        Me.SelectionList.ColumnWidthRatios = Nothing
        Me.SelectionList.DataMember = ""
        Me.SelectionList.EnableSaveActions = False
        Me.SelectionList.FirstColumnIncreases = True
        Me.SelectionList.FirstColumnMaximum = 1.7976931348623157E+308
        Me.SelectionList.FirstColumnMinimum = 0
        Me.SelectionList.FirstRowFixed = True
        Me.SelectionList.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectionList.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.SelectionList.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.SelectionList.Location = New System.Drawing.Point(10, 74)
        Me.SelectionList.MaxRows = 50
        Me.SelectionList.MinRows = 0
        Me.SelectionList.Name = "SelectionList"
        Me.SelectionList.PasteDisabled = False
        Me.SelectionList.SecondColumnIncreases = False
        Me.SelectionList.SecondColumnMaximum = 1.7976931348623157E+308
        Me.SelectionList.SecondColumnMinimum = 0
        Me.SelectionList.Size = New System.Drawing.Size(374, 340)
        Me.SelectionList.TabIndex = 2
        Me.SelectionList.TableReadonly = False
        '
        'ClearAll_Button
        '
        Me.ClearAll_Button.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClearAll_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClearAll_Button.Location = New System.Drawing.Point(10, 430)
        Me.ClearAll_Button.Name = "ClearAll_Button"
        Me.ClearAll_Button.Size = New System.Drawing.Size(81, 28)
        Me.ClearAll_Button.TabIndex = 3
        Me.ClearAll_Button.Text = "Clear All"
        Me.ClearAll_Button.UseVisualStyleBackColor = False
        '
        'SelectAll_Button
        '
        Me.SelectAll_Button.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SelectAll_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SelectAll_Button.Location = New System.Drawing.Point(97, 430)
        Me.SelectAll_Button.Name = "SelectAll_Button"
        Me.SelectAll_Button.Size = New System.Drawing.Size(81, 28)
        Me.SelectAll_Button.TabIndex = 4
        Me.SelectAll_Button.Text = "Select All"
        Me.SelectAll_Button.UseVisualStyleBackColor = False
        '
        'SelectMeasurementStations
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(394, 472)
        Me.Controls.Add(Me.SelectAll_Button)
        Me.Controls.Add(Me.ClearAll_Button)
        Me.Controls.Add(Me.SelectionList)
        Me.Controls.Add(Me.Instructions)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectMeasurementStations"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Measurement Stations"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.SelectionList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Instructions As DataStore.ctl_Label
    Friend WithEvents SelectionList As DataStore.ctl_DataTableParameter
    Friend WithEvents ClearAll_Button As DataStore.ctl_Button
    Friend WithEvents SelectAll_Button As DataStore.ctl_Button

End Class
