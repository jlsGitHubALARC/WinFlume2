<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FertigationOptions
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.DispersivityCoefficientGroup = New DataStore.ctl_GroupBox()
        Me.KxControl = New DataStore.ctl_DoubleUpDownParameter()
        Me.SpecifiedKxButton = New DataStore.ctl_RadioButton()
        Me.ElderCeControl = New DataStore.ctl_DoubleUpDownParameter()
        Me.CeLabel = New DataStore.ctl_Label()
        Me.RutherfordButton = New DataStore.ctl_RadioButton()
        Me.DengButton = New DataStore.ctl_RadioButton()
        Me.ElderButton = New DataStore.ctl_RadioButton()
        Me.FischerButton = New DataStore.ctl_RadioButton()
        Me.AdvectionMethodGroup = New DataStore.ctl_GroupBox()
        Me.CubicButton = New DataStore.ctl_RadioButton()
        Me.AkimaButton = New DataStore.ctl_RadioButton()
        Me.TrackSoluteGroup = New DataStore.ctl_GroupBox()
        Me.EnableFertigationDispersion = New DataStore.ctl_CheckParameter()
        Me.ContinuousButton = New DataStore.ctl_RadioButton()
        Me.PieceWiseButton = New DataStore.ctl_RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.DispersivityCoefficientGroup.SuspendLayout()
        Me.AdvectionMethodGroup.SuspendLayout()
        Me.TrackSoluteGroup.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(283, 285)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(195, 36)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 0
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
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'DispersivityCoefficientGroup
        '
        Me.DispersivityCoefficientGroup.Controls.Add(Me.KxControl)
        Me.DispersivityCoefficientGroup.Controls.Add(Me.SpecifiedKxButton)
        Me.DispersivityCoefficientGroup.Controls.Add(Me.ElderCeControl)
        Me.DispersivityCoefficientGroup.Controls.Add(Me.CeLabel)
        Me.DispersivityCoefficientGroup.Controls.Add(Me.RutherfordButton)
        Me.DispersivityCoefficientGroup.Controls.Add(Me.DengButton)
        Me.DispersivityCoefficientGroup.Controls.Add(Me.ElderButton)
        Me.DispersivityCoefficientGroup.Controls.Add(Me.FischerButton)
        Me.DispersivityCoefficientGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DispersivityCoefficientGroup.Location = New System.Drawing.Point(15, 88)
        Me.DispersivityCoefficientGroup.Name = "DispersivityCoefficientGroup"
        Me.DispersivityCoefficientGroup.Size = New System.Drawing.Size(463, 100)
        Me.DispersivityCoefficientGroup.TabIndex = 2
        Me.DispersivityCoefficientGroup.TabStop = False
        Me.DispersivityCoefficientGroup.Text = "Dispersivity Coefficient (Kx) Method"
        '
        'KxControl
        '
        Me.KxControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KxControl.DialogMode = True
        Me.KxControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KxControl.IsCalculated = False
        Me.KxControl.IsInteger = False
        Me.KxControl.Location = New System.Drawing.Point(120, 65)
        Me.KxControl.Margin = New System.Windows.Forms.Padding(4)
        Me.KxControl.Name = "KxControl"
        Me.KxControl.Size = New System.Drawing.Size(95, 24)
        Me.KxControl.TabIndex = 7
        Me.KxControl.ToBeCalculated = True
        Me.KxControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KxControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KxControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        '
        'SpecifiedKxButton
        '
        Me.SpecifiedKxButton.AutoSize = True
        Me.SpecifiedKxButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpecifiedKxButton.Location = New System.Drawing.Point(10, 64)
        Me.SpecifiedKxButton.Name = "SpecifiedKxButton"
        Me.SpecifiedKxButton.Size = New System.Drawing.Size(103, 21)
        Me.SpecifiedKxButton.TabIndex = 1
        Me.SpecifiedKxButton.Text = "&Specified Kx"
        Me.SpecifiedKxButton.UseVisualStyleBackColor = True
        '
        'ElderCeControl
        '
        Me.ElderCeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.ElderCeControl.DialogMode = True
        Me.ElderCeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElderCeControl.IsCalculated = False
        Me.ElderCeControl.IsInteger = False
        Me.ElderCeControl.Location = New System.Drawing.Point(120, 25)
        Me.ElderCeControl.Margin = New System.Windows.Forms.Padding(4)
        Me.ElderCeControl.Name = "ElderCeControl"
        Me.ElderCeControl.Size = New System.Drawing.Size(95, 24)
        Me.ElderCeControl.TabIndex = 6
        Me.ElderCeControl.ToBeCalculated = True
        Me.ElderCeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.ElderCeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.ElderCeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        '
        'CeLabel
        '
        Me.CeLabel.AutoSize = True
        Me.CeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CeLabel.Location = New System.Drawing.Point(87, 26)
        Me.CeLabel.Name = "CeLabel"
        Me.CeLabel.Size = New System.Drawing.Size(25, 17)
        Me.CeLabel.TabIndex = 5
        Me.CeLabel.Text = "Ce"
        '
        'RutherfordButton
        '
        Me.RutherfordButton.AutoSize = True
        Me.RutherfordButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RutherfordButton.Location = New System.Drawing.Point(344, 73)
        Me.RutherfordButton.Name = "RutherfordButton"
        Me.RutherfordButton.Size = New System.Drawing.Size(94, 21)
        Me.RutherfordButton.TabIndex = 4
        Me.RutherfordButton.Text = "&Rutherford"
        Me.RutherfordButton.UseVisualStyleBackColor = True
        '
        'DengButton
        '
        Me.DengButton.AutoSize = True
        Me.DengButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DengButton.Location = New System.Drawing.Point(344, 19)
        Me.DengButton.Name = "DengButton"
        Me.DengButton.Size = New System.Drawing.Size(60, 21)
        Me.DengButton.TabIndex = 2
        Me.DengButton.Text = "&Deng"
        Me.DengButton.UseVisualStyleBackColor = True
        '
        'ElderButton
        '
        Me.ElderButton.AutoSize = True
        Me.ElderButton.Checked = True
        Me.ElderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElderButton.Location = New System.Drawing.Point(10, 24)
        Me.ElderButton.Name = "ElderButton"
        Me.ElderButton.Size = New System.Drawing.Size(59, 21)
        Me.ElderButton.TabIndex = 0
        Me.ElderButton.TabStop = True
        Me.ElderButton.Text = "&Elder"
        Me.ElderButton.UseVisualStyleBackColor = True
        '
        'FischerButton
        '
        Me.FischerButton.AutoSize = True
        Me.FischerButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FischerButton.Location = New System.Drawing.Point(344, 46)
        Me.FischerButton.Name = "FischerButton"
        Me.FischerButton.Size = New System.Drawing.Size(72, 21)
        Me.FischerButton.TabIndex = 3
        Me.FischerButton.Text = "&Fischer"
        Me.FischerButton.UseVisualStyleBackColor = True
        '
        'AdvectionMethodGroup
        '
        Me.AdvectionMethodGroup.Controls.Add(Me.CubicButton)
        Me.AdvectionMethodGroup.Controls.Add(Me.AkimaButton)
        Me.AdvectionMethodGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdvectionMethodGroup.Location = New System.Drawing.Point(15, 216)
        Me.AdvectionMethodGroup.Name = "AdvectionMethodGroup"
        Me.AdvectionMethodGroup.Size = New System.Drawing.Size(463, 50)
        Me.AdvectionMethodGroup.TabIndex = 1
        Me.AdvectionMethodGroup.TabStop = False
        Me.AdvectionMethodGroup.Text = "Advection Interpolation Method"
        '
        'CubicButton
        '
        Me.CubicButton.AutoSize = True
        Me.CubicButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CubicButton.Location = New System.Drawing.Point(100, 22)
        Me.CubicButton.Name = "CubicButton"
        Me.CubicButton.Size = New System.Drawing.Size(104, 21)
        Me.CubicButton.TabIndex = 1
        Me.CubicButton.Text = "&Cubic Spline"
        Me.CubicButton.UseVisualStyleBackColor = True
        '
        'AkimaButton
        '
        Me.AkimaButton.AutoSize = True
        Me.AkimaButton.Checked = True
        Me.AkimaButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AkimaButton.Location = New System.Drawing.Point(10, 22)
        Me.AkimaButton.Name = "AkimaButton"
        Me.AkimaButton.Size = New System.Drawing.Size(64, 21)
        Me.AkimaButton.TabIndex = 0
        Me.AkimaButton.TabStop = True
        Me.AkimaButton.Text = "&Akima"
        Me.AkimaButton.UseVisualStyleBackColor = True
        '
        'TrackSoluteGroup
        '
        Me.TrackSoluteGroup.Controls.Add(Me.EnableFertigationDispersion)
        Me.TrackSoluteGroup.Controls.Add(Me.ContinuousButton)
        Me.TrackSoluteGroup.Controls.Add(Me.PieceWiseButton)
        Me.TrackSoluteGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrackSoluteGroup.Location = New System.Drawing.Point(15, 8)
        Me.TrackSoluteGroup.Name = "TrackSoluteGroup"
        Me.TrackSoluteGroup.Size = New System.Drawing.Size(463, 74)
        Me.TrackSoluteGroup.TabIndex = 0
        Me.TrackSoluteGroup.TabStop = False
        Me.TrackSoluteGroup.Text = "Track Solute &Using ..."
        '
        'EnableFertigationDispersion
        '
        Me.EnableFertigationDispersion.AlwaysChecked = False
        Me.EnableFertigationDispersion.AutoSize = True
        Me.EnableFertigationDispersion.Checked = True
        Me.EnableFertigationDispersion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EnableFertigationDispersion.ErrorMessage = Nothing
        Me.EnableFertigationDispersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnableFertigationDispersion.Location = New System.Drawing.Point(298, 23)
        Me.EnableFertigationDispersion.Name = "EnableFertigationDispersion"
        Me.EnableFertigationDispersion.Size = New System.Drawing.Size(142, 21)
        Me.EnableFertigationDispersion.TabIndex = 2
        Me.EnableFertigationDispersion.Text = "Enable Dispersion"
        Me.EnableFertigationDispersion.UncheckAttemptMessage = Nothing
        Me.EnableFertigationDispersion.UseVisualStyleBackColor = True
        '
        'ContinuousButton
        '
        Me.ContinuousButton.AutoSize = True
        Me.ContinuousButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContinuousButton.Location = New System.Drawing.Point(10, 42)
        Me.ContinuousButton.Name = "ContinuousButton"
        Me.ContinuousButton.Size = New System.Drawing.Size(194, 21)
        Me.ContinuousButton.TabIndex = 1
        Me.ContinuousButton.Text = "&Continuous Characteristics"
        Me.ContinuousButton.UseVisualStyleBackColor = True
        '
        'PieceWiseButton
        '
        Me.PieceWiseButton.AutoSize = True
        Me.PieceWiseButton.Checked = True
        Me.PieceWiseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PieceWiseButton.Location = New System.Drawing.Point(10, 22)
        Me.PieceWiseButton.Name = "PieceWiseButton"
        Me.PieceWiseButton.Size = New System.Drawing.Size(194, 21)
        Me.PieceWiseButton.TabIndex = 0
        Me.PieceWiseButton.TabStop = True
        Me.PieceWiseButton.Text = "&Piece-Wise Characteristics"
        Me.PieceWiseButton.UseVisualStyleBackColor = True
        '
        'FertigationOptions
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(494, 330)
        Me.Controls.Add(Me.DispersivityCoefficientGroup)
        Me.Controls.Add(Me.AdvectionMethodGroup)
        Me.Controls.Add(Me.TrackSoluteGroup)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FertigationOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fertigation Options"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.DispersivityCoefficientGroup.ResumeLayout(False)
        Me.DispersivityCoefficientGroup.PerformLayout()
        Me.AdvectionMethodGroup.ResumeLayout(False)
        Me.AdvectionMethodGroup.PerformLayout()
        Me.TrackSoluteGroup.ResumeLayout(False)
        Me.TrackSoluteGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DispersivityCoefficientGroup As DataStore.ctl_GroupBox
    Friend WithEvents ElderCeControl As DataStore.ctl_DoubleUpDownParameter
    Friend WithEvents CeLabel As DataStore.ctl_Label
    Friend WithEvents RutherfordButton As DataStore.ctl_RadioButton
    Friend WithEvents DengButton As DataStore.ctl_RadioButton
    Friend WithEvents ElderButton As DataStore.ctl_RadioButton
    Friend WithEvents FischerButton As DataStore.ctl_RadioButton
    Friend WithEvents AdvectionMethodGroup As DataStore.ctl_GroupBox
    Friend WithEvents CubicButton As DataStore.ctl_RadioButton
    Friend WithEvents AkimaButton As DataStore.ctl_RadioButton
    Friend WithEvents TrackSoluteGroup As DataStore.ctl_GroupBox
    Friend WithEvents EnableFertigationDispersion As DataStore.ctl_CheckParameter
    Friend WithEvents ContinuousButton As DataStore.ctl_RadioButton
    Friend WithEvents PieceWiseButton As DataStore.ctl_RadioButton
    Friend WithEvents KxControl As DataStore.ctl_DoubleUpDownParameter
    Friend WithEvents SpecifiedKxButton As DataStore.ctl_RadioButton
End Class
