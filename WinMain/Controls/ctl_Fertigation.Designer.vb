<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_Fertigation
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
        Me.components = New System.ComponentModel.Container
        Me.FertigationBox = New DataStore.ctl_GroupBox
        Me.FertigationWarnings = New WinMain.ErrorRichTextBox
        Me.FertigationOptionsButton = New DataStore.ctl_Button
        Me.InjectionRateGraph = New GraphingUI.ex_PictureBox
        Me.InjectionSummaryLabel = New System.Windows.Forms.Label
        Me.InjectionPointBox = New DataStore.ctl_GroupBox
        Me.TankConcentrationControl = New DataStore.ctl_DoubleParameter
        Me.TankConcentrationLabel = New DataStore.ctl_Label
        Me.TabulatedPulsePanel = New DataStore.ctl_Panel
        Me.InjectionRateTable = New DataStore.ctl_DataTableParameter
        Me.FertigationBox.SuspendLayout()
        CType(Me.InjectionRateGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InjectionPointBox.SuspendLayout()
        Me.TabulatedPulsePanel.SuspendLayout()
        CType(Me.InjectionRateTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FertigationBox
        '
        Me.FertigationBox.Controls.Add(Me.FertigationWarnings)
        Me.FertigationBox.Controls.Add(Me.FertigationOptionsButton)
        Me.FertigationBox.Controls.Add(Me.InjectionRateGraph)
        Me.FertigationBox.Controls.Add(Me.InjectionSummaryLabel)
        Me.FertigationBox.Controls.Add(Me.InjectionPointBox)
        Me.FertigationBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FertigationBox.Location = New System.Drawing.Point(8, 8)
        Me.FertigationBox.Name = "FertigationBox"
        Me.FertigationBox.Size = New System.Drawing.Size(760, 416)
        Me.FertigationBox.TabIndex = 0
        Me.FertigationBox.TabStop = False
        Me.FertigationBox.Text = "Fertigation"
        '
        'FertigationWarnings
        '
        Me.FertigationWarnings.BackColor = System.Drawing.SystemColors.Info
        Me.FertigationWarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FertigationWarnings.Location = New System.Drawing.Point(298, 206)
        Me.FertigationWarnings.Name = "FertigationWarnings"
        Me.FertigationWarnings.ReadOnly = True
        Me.FertigationWarnings.Size = New System.Drawing.Size(456, 78)
        Me.FertigationWarnings.TabIndex = 8
        Me.FertigationWarnings.Text = ""
        '
        'FertigationOptionsButton
        '
        Me.FertigationOptionsButton.AccessibleDescription = "Provides access to options for fertigation calculations."
        Me.FertigationOptionsButton.AccessibleName = "Fertigation Options"
        Me.FertigationOptionsButton.AutoSize = True
        Me.FertigationOptionsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FertigationOptionsButton.Location = New System.Drawing.Point(595, 378)
        Me.FertigationOptionsButton.Name = "FertigationOptionsButton"
        Me.FertigationOptionsButton.Size = New System.Drawing.Size(157, 27)
        Me.FertigationOptionsButton.TabIndex = 6
        Me.FertigationOptionsButton.Text = "Fertigation &Options"
        Me.FertigationOptionsButton.UseVisualStyleBackColor = True
        '
        'InjectionRateGraph
        '
        Me.InjectionRateGraph.AccessibleDescription = "A copyable bitmap image"
        Me.InjectionRateGraph.AccessibleName = "Bitmap Diagram"
        Me.InjectionRateGraph.Location = New System.Drawing.Point(298, 23)
        Me.InjectionRateGraph.Name = "InjectionRateGraph"
        Me.InjectionRateGraph.Size = New System.Drawing.Size(456, 138)
        Me.InjectionRateGraph.TabIndex = 5
        Me.InjectionRateGraph.TabStop = False
        Me.InjectionRateGraph.Text = "Bitmap Diagram"
        '
        'InjectionSummaryLabel
        '
        Me.InjectionSummaryLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InjectionSummaryLabel.Location = New System.Drawing.Point(298, 166)
        Me.InjectionSummaryLabel.Name = "InjectionSummaryLabel"
        Me.InjectionSummaryLabel.Size = New System.Drawing.Size(447, 24)
        Me.InjectionSummaryLabel.TabIndex = 1
        Me.InjectionSummaryLabel.Text = "Injection Summary"
        Me.InjectionSummaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InjectionPointBox
        '
        Me.InjectionPointBox.Controls.Add(Me.TankConcentrationControl)
        Me.InjectionPointBox.Controls.Add(Me.TankConcentrationLabel)
        Me.InjectionPointBox.Controls.Add(Me.TabulatedPulsePanel)
        Me.InjectionPointBox.Location = New System.Drawing.Point(10, 23)
        Me.InjectionPointBox.Name = "InjectionPointBox"
        Me.InjectionPointBox.Size = New System.Drawing.Size(275, 385)
        Me.InjectionPointBox.TabIndex = 0
        Me.InjectionPointBox.TabStop = False
        Me.InjectionPointBox.Text = "Injection Point"
        '
        'TankConcentrationControl
        '
        Me.TankConcentrationControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.TankConcentrationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TankConcentrationControl.IsCalculated = False
        Me.TankConcentrationControl.IsInteger = False
        Me.TankConcentrationControl.Location = New System.Drawing.Point(165, 23)
        Me.TankConcentrationControl.MaxErrMsg = ""
        Me.TankConcentrationControl.MinErrMsg = ""
        Me.TankConcentrationControl.Name = "TankConcentrationControl"
        Me.TankConcentrationControl.Size = New System.Drawing.Size(104, 24)
        Me.TankConcentrationControl.TabIndex = 1
        Me.TankConcentrationControl.ToBeCalculated = True
        Me.TankConcentrationControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.TankConcentrationControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.TankConcentrationControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.TankConcentrationControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.TankConcentrationControl.ValueText = ""
        '
        'TankConcentrationLabel
        '
        Me.TankConcentrationLabel.AutoSize = True
        Me.TankConcentrationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TankConcentrationLabel.Location = New System.Drawing.Point(9, 26)
        Me.TankConcentrationLabel.Name = "TankConcentrationLabel"
        Me.TankConcentrationLabel.Size = New System.Drawing.Size(132, 17)
        Me.TankConcentrationLabel.TabIndex = 0
        Me.TankConcentrationLabel.Text = "Tank &Concentration"
        Me.TankConcentrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabulatedPulsePanel
        '
        Me.TabulatedPulsePanel.Controls.Add(Me.InjectionRateTable)
        Me.TabulatedPulsePanel.Location = New System.Drawing.Point(12, 53)
        Me.TabulatedPulsePanel.Name = "TabulatedPulsePanel"
        Me.TabulatedPulsePanel.Size = New System.Drawing.Size(250, 326)
        Me.TabulatedPulsePanel.TabIndex = 13
        '
        'InjectionRateTable
        '
        Me.InjectionRateTable.AllRowsFixed = False
        Me.InjectionRateTable.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.InjectionRateTable.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.InjectionRateTable.CaptionText = "Injection Table"
        Me.InjectionRateTable.CausesValidation = False
        Me.InjectionRateTable.ColumnWidthRatios = Nothing
        Me.InjectionRateTable.DataMember = ""
        Me.InjectionRateTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InjectionRateTable.EnableSaveActions = False
        Me.InjectionRateTable.FirstColumnIncreases = True
        Me.InjectionRateTable.FirstColumnMaximum = 1.7976931348623157E+308
        Me.InjectionRateTable.FirstColumnMinimum = 0
        Me.InjectionRateTable.FirstRowFixed = False
        Me.InjectionRateTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InjectionRateTable.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.InjectionRateTable.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.InjectionRateTable.Location = New System.Drawing.Point(0, 0)
        Me.InjectionRateTable.MaxRows = 50
        Me.InjectionRateTable.MinRows = 0
        Me.InjectionRateTable.Name = "InjectionRateTable"
        Me.InjectionRateTable.PasteDisabled = False
        Me.InjectionRateTable.SecondColumnIncreases = False
        Me.InjectionRateTable.SecondColumnMaximum = 1.7976931348623157E+308
        Me.InjectionRateTable.SecondColumnMinimum = 0
        Me.InjectionRateTable.Size = New System.Drawing.Size(250, 326)
        Me.InjectionRateTable.TabIndex = 0
        Me.InjectionRateTable.TableReadonly = False
        '
        'ctl_Fertigation
        '
        Me.AccessibleDescription = "Specifies how the fertigation solute is injected into the irrigation water."
        Me.AccessibleName = "Fertigation Injection"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.FertigationBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_Fertigation"
        Me.Size = New System.Drawing.Size(780, 430)
        Me.FertigationBox.ResumeLayout(False)
        Me.FertigationBox.PerformLayout()
        CType(Me.InjectionRateGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InjectionPointBox.ResumeLayout(False)
        Me.InjectionPointBox.PerformLayout()
        Me.TabulatedPulsePanel.ResumeLayout(False)
        CType(Me.InjectionRateTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FertigationBox As DataStore.ctl_GroupBox
    Friend WithEvents InjectionPointBox As DataStore.ctl_GroupBox
    Friend WithEvents TankConcentrationControl As DataStore.ctl_DoubleParameter
    Friend WithEvents TankConcentrationLabel As DataStore.ctl_Label
    Friend WithEvents TabulatedPulsePanel As DataStore.ctl_Panel
    Friend WithEvents InjectionRateTable As DataStore.ctl_DataTableParameter
    Friend WithEvents InjectionSummaryLabel As System.Windows.Forms.Label
    Friend WithEvents InjectionRateGraph As GraphingUI.ex_PictureBox
    Friend WithEvents FertigationOptionsButton As DataStore.ctl_Button
    Friend WithEvents FertigationWarnings As WinMain.ErrorRichTextBox

End Class
