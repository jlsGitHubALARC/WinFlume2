<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnitsDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnitsDialog))
        Me.ButtonTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Convert_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.DischargeGroup = New System.Windows.Forms.GroupBox()
        Me.MillionGallonsDayAbbrev = New System.Windows.Forms.Label()
        Me.MillionGallonsDayButton = New System.Windows.Forms.RadioButton()
        Me.MegalitersDayAbbrev = New System.Windows.Forms.Label()
        Me.MegalitersDayButton = New System.Windows.Forms.RadioButton()
        Me.MegalitersHourAbbrev = New System.Windows.Forms.Label()
        Me.MegalitersHourButton = New System.Windows.Forms.RadioButton()
        Me.MinersInchCoAbbrev = New System.Windows.Forms.Label()
        Me.MinersInchCoButton = New System.Windows.Forms.RadioButton()
        Me.MinersInchIdAbbrev = New System.Windows.Forms.Label()
        Me.MinersInchIdButton = New System.Windows.Forms.RadioButton()
        Me.MinersInchAzAbbrev = New System.Windows.Forms.Label()
        Me.MinersInchAzButton = New System.Windows.Forms.RadioButton()
        Me.AcreFeetHourAbbrev = New System.Windows.Forms.Label()
        Me.AcreFeetHourButton = New System.Windows.Forms.RadioButton()
        Me.GallonsMinuteAbbrev = New System.Windows.Forms.Label()
        Me.GallonsMinuteButton = New System.Windows.Forms.RadioButton()
        Me.CubicFeetSecondAbbrev = New System.Windows.Forms.Label()
        Me.CubicFeetSecondButton = New System.Windows.Forms.RadioButton()
        Me.LitersSecondAbbrev = New System.Windows.Forms.Label()
        Me.LitersSecondButton = New System.Windows.Forms.RadioButton()
        Me.CubicMetersSecondAbbrev = New System.Windows.Forms.Label()
        Me.CubicMetersSecondButton = New System.Windows.Forms.RadioButton()
        Me.WaterVelocityGroup = New System.Windows.Forms.GroupBox()
        Me.FeetSecondAbbrev = New System.Windows.Forms.Label()
        Me.FeetSecondButton = New System.Windows.Forms.RadioButton()
        Me.MetersSecondAbbrev = New System.Windows.Forms.Label()
        Me.MetersSecondButton = New System.Windows.Forms.RadioButton()
        Me.LengthHeightGroup = New System.Windows.Forms.GroupBox()
        Me.CentimetersAbbrev = New System.Windows.Forms.Label()
        Me.CentimetersButton = New System.Windows.Forms.RadioButton()
        Me.InchesAbbrev = New System.Windows.Forms.Label()
        Me.InchesButton = New System.Windows.Forms.RadioButton()
        Me.MillimetersAbbrev = New System.Windows.Forms.Label()
        Me.MillimetersButton = New System.Windows.Forms.RadioButton()
        Me.FeetAbbrev = New System.Windows.Forms.Label()
        Me.FeetButton = New System.Windows.Forms.RadioButton()
        Me.MetersAbbrev = New System.Windows.Forms.Label()
        Me.MetersButton = New System.Windows.Forms.RadioButton()
        Me.ButtonTableLayoutPanel.SuspendLayout()
        Me.DischargeGroup.SuspendLayout()
        Me.WaterVelocityGroup.SuspendLayout()
        Me.LengthHeightGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonTableLayoutPanel
        '
        Me.ButtonTableLayoutPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonTableLayoutPanel.ColumnCount = 3
        Me.ButtonTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.47619!))
        Me.ButtonTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.52381!))
        Me.ButtonTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.ButtonTableLayoutPanel.Controls.Add(Me.Convert_Button, 0, 0)
        Me.ButtonTableLayoutPanel.Controls.Add(Me.Cancel_Button, 2, 0)
        Me.ButtonTableLayoutPanel.Controls.Add(Me.OK_Button, 1, 0)
        Me.ButtonTableLayoutPanel.Location = New System.Drawing.Point(117, 267)
        Me.ButtonTableLayoutPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonTableLayoutPanel.Name = "ButtonTableLayoutPanel"
        Me.ButtonTableLayoutPanel.RowCount = 1
        Me.ButtonTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.ButtonTableLayoutPanel.Size = New System.Drawing.Size(564, 73)
        Me.ButtonTableLayoutPanel.TabIndex = 0
        '
        'Convert_Button
        '
        Me.Convert_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Convert_Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Convert_Button.Location = New System.Drawing.Point(13, 11)
        Me.Convert_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Convert_Button.Name = "Convert_Button"
        Me.Convert_Button.Size = New System.Drawing.Size(252, 50)
        Me.Convert_Button.TabIndex = 2
        Me.Convert_Button.Text = "Change Display Units, but &Retain Numerical Values for Current Flume"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cancel_Button.Location = New System.Drawing.Point(471, 22)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(81, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "&Cancel"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.OK_Button.Location = New System.Drawing.Point(291, 11)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(156, 50)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "&Convert Flume Design to New Display Units"
        '
        'DischargeGroup
        '
        Me.DischargeGroup.AccessibleDescription = "Units selection for discharge values"
        Me.DischargeGroup.AccessibleName = "Discharge"
        Me.DischargeGroup.Controls.Add(Me.MillionGallonsDayAbbrev)
        Me.DischargeGroup.Controls.Add(Me.MillionGallonsDayButton)
        Me.DischargeGroup.Controls.Add(Me.MegalitersDayAbbrev)
        Me.DischargeGroup.Controls.Add(Me.MegalitersDayButton)
        Me.DischargeGroup.Controls.Add(Me.MegalitersHourAbbrev)
        Me.DischargeGroup.Controls.Add(Me.MegalitersHourButton)
        Me.DischargeGroup.Controls.Add(Me.MinersInchCoAbbrev)
        Me.DischargeGroup.Controls.Add(Me.MinersInchCoButton)
        Me.DischargeGroup.Controls.Add(Me.MinersInchIdAbbrev)
        Me.DischargeGroup.Controls.Add(Me.MinersInchIdButton)
        Me.DischargeGroup.Controls.Add(Me.MinersInchAzAbbrev)
        Me.DischargeGroup.Controls.Add(Me.MinersInchAzButton)
        Me.DischargeGroup.Controls.Add(Me.AcreFeetHourAbbrev)
        Me.DischargeGroup.Controls.Add(Me.AcreFeetHourButton)
        Me.DischargeGroup.Controls.Add(Me.GallonsMinuteAbbrev)
        Me.DischargeGroup.Controls.Add(Me.GallonsMinuteButton)
        Me.DischargeGroup.Controls.Add(Me.CubicFeetSecondAbbrev)
        Me.DischargeGroup.Controls.Add(Me.CubicFeetSecondButton)
        Me.DischargeGroup.Controls.Add(Me.LitersSecondAbbrev)
        Me.DischargeGroup.Controls.Add(Me.LitersSecondButton)
        Me.DischargeGroup.Controls.Add(Me.CubicMetersSecondAbbrev)
        Me.DischargeGroup.Controls.Add(Me.CubicMetersSecondButton)
        Me.DischargeGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.DischargeGroup.Location = New System.Drawing.Point(240, 10)
        Me.DischargeGroup.Name = "DischargeGroup"
        Me.DischargeGroup.Size = New System.Drawing.Size(440, 250)
        Me.DischargeGroup.TabIndex = 3
        Me.DischargeGroup.TabStop = False
        Me.DischargeGroup.Text = "&Discharge"
        '
        'MillionGallonsDayAbbrev
        '
        Me.MillionGallonsDayAbbrev.AutoSize = True
        Me.MillionGallonsDayAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MillionGallonsDayAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MillionGallonsDayAbbrev.Location = New System.Drawing.Point(350, 222)
        Me.MillionGallonsDayAbbrev.Name = "MillionGallonsDayAbbrev"
        Me.MillionGallonsDayAbbrev.Size = New System.Drawing.Size(35, 17)
        Me.MillionGallonsDayAbbrev.TabIndex = 21
        Me.MillionGallonsDayAbbrev.Text = "mgd"
        '
        'MillionGallonsDayButton
        '
        Me.MillionGallonsDayButton.AutoSize = True
        Me.MillionGallonsDayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MillionGallonsDayButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MillionGallonsDayButton.Location = New System.Drawing.Point(5, 220)
        Me.MillionGallonsDayButton.Name = "MillionGallonsDayButton"
        Me.MillionGallonsDayButton.Size = New System.Drawing.Size(146, 21)
        Me.MillionGallonsDayButton.TabIndex = 20
        Me.MillionGallonsDayButton.TabStop = True
        Me.MillionGallonsDayButton.Text = "Million Gallons/Day"
        Me.MillionGallonsDayButton.UseVisualStyleBackColor = True
        '
        'MegalitersDayAbbrev
        '
        Me.MegalitersDayAbbrev.AutoSize = True
        Me.MegalitersDayAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MegalitersDayAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MegalitersDayAbbrev.Location = New System.Drawing.Point(350, 202)
        Me.MegalitersDayAbbrev.Name = "MegalitersDayAbbrev"
        Me.MegalitersDayAbbrev.Size = New System.Drawing.Size(54, 17)
        Me.MegalitersDayAbbrev.TabIndex = 19
        Me.MegalitersDayAbbrev.Text = "ML/day"
        '
        'MegalitersDayButton
        '
        Me.MegalitersDayButton.AutoSize = True
        Me.MegalitersDayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MegalitersDayButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MegalitersDayButton.Location = New System.Drawing.Point(5, 200)
        Me.MegalitersDayButton.Name = "MegalitersDayButton"
        Me.MegalitersDayButton.Size = New System.Drawing.Size(120, 21)
        Me.MegalitersDayButton.TabIndex = 18
        Me.MegalitersDayButton.TabStop = True
        Me.MegalitersDayButton.Text = "Megaliters/Day"
        Me.MegalitersDayButton.UseVisualStyleBackColor = True
        '
        'MegalitersHourAbbrev
        '
        Me.MegalitersHourAbbrev.AutoSize = True
        Me.MegalitersHourAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MegalitersHourAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MegalitersHourAbbrev.Location = New System.Drawing.Point(350, 182)
        Me.MegalitersHourAbbrev.Name = "MegalitersHourAbbrev"
        Me.MegalitersHourAbbrev.Size = New System.Drawing.Size(44, 17)
        Me.MegalitersHourAbbrev.TabIndex = 17
        Me.MegalitersHourAbbrev.Text = "ML/hr"
        '
        'MegalitersHourButton
        '
        Me.MegalitersHourButton.AutoSize = True
        Me.MegalitersHourButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MegalitersHourButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MegalitersHourButton.Location = New System.Drawing.Point(5, 180)
        Me.MegalitersHourButton.Name = "MegalitersHourButton"
        Me.MegalitersHourButton.Size = New System.Drawing.Size(288, 21)
        Me.MegalitersHourButton.TabIndex = 16
        Me.MegalitersHourButton.TabStop = True
        Me.MegalitersHourButton.Text = "Megaliters/Hour (Cubic Dekameters/hour)"
        Me.MegalitersHourButton.UseVisualStyleBackColor = True
        '
        'MinersInchCoAbbrev
        '
        Me.MinersInchCoAbbrev.AutoSize = True
        Me.MinersInchCoAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MinersInchCoAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MinersInchCoAbbrev.Location = New System.Drawing.Point(350, 162)
        Me.MinersInchCoAbbrev.Name = "MinersInchCoAbbrev"
        Me.MinersInchCoAbbrev.Size = New System.Drawing.Size(77, 17)
        Me.MinersInchCoAbbrev.TabIndex = 15
        Me.MinersInchCoAbbrev.Text = "CO miner's"
        '
        'MinersInchCoButton
        '
        Me.MinersInchCoButton.AutoSize = True
        Me.MinersInchCoButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MinersInchCoButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MinersInchCoButton.Location = New System.Drawing.Point(5, 160)
        Me.MinersInchCoButton.Name = "MinersInchCoButton"
        Me.MinersInchCoButton.Size = New System.Drawing.Size(253, 21)
        Me.MinersInchCoButton.TabIndex = 14
        Me.MinersInchCoButton.TabStop = True
        Me.MinersInchCoButton.Text = "Miner's Inch (Colorado) - 38.4 MI/cfs"
        Me.MinersInchCoButton.UseVisualStyleBackColor = True
        '
        'MinersInchIdAbbrev
        '
        Me.MinersInchIdAbbrev.AutoSize = True
        Me.MinersInchIdAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MinersInchIdAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MinersInchIdAbbrev.Location = New System.Drawing.Point(350, 142)
        Me.MinersInchIdAbbrev.Name = "MinersInchIdAbbrev"
        Me.MinersInchIdAbbrev.Size = New System.Drawing.Size(70, 17)
        Me.MinersInchIdAbbrev.TabIndex = 13
        Me.MinersInchIdAbbrev.Text = "ID miner's"
        '
        'MinersInchIdButton
        '
        Me.MinersInchIdButton.AutoSize = True
        Me.MinersInchIdButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MinersInchIdButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MinersInchIdButton.Location = New System.Drawing.Point(5, 140)
        Me.MinersInchIdButton.Name = "MinersInchIdButton"
        Me.MinersInchIdButton.Size = New System.Drawing.Size(219, 21)
        Me.MinersInchIdButton.TabIndex = 12
        Me.MinersInchIdButton.TabStop = True
        Me.MinersInchIdButton.Text = "Miner's Inch (Idaho) - 50 MI/cfs"
        Me.MinersInchIdButton.UseVisualStyleBackColor = True
        '
        'MinersInchAzAbbrev
        '
        Me.MinersInchAzAbbrev.AutoSize = True
        Me.MinersInchAzAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MinersInchAzAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MinersInchAzAbbrev.Location = New System.Drawing.Point(350, 122)
        Me.MinersInchAzAbbrev.Name = "MinersInchAzAbbrev"
        Me.MinersInchAzAbbrev.Size = New System.Drawing.Size(75, 17)
        Me.MinersInchAzAbbrev.TabIndex = 11
        Me.MinersInchAzAbbrev.Text = "AZ miner's"
        '
        'MinersInchAzButton
        '
        Me.MinersInchAzButton.AutoSize = True
        Me.MinersInchAzButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MinersInchAzButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MinersInchAzButton.Location = New System.Drawing.Point(5, 120)
        Me.MinersInchAzButton.Name = "MinersInchAzButton"
        Me.MinersInchAzButton.Size = New System.Drawing.Size(232, 21)
        Me.MinersInchAzButton.TabIndex = 10
        Me.MinersInchAzButton.TabStop = True
        Me.MinersInchAzButton.Text = "Miner's Inch (Arizona) - 40 MI/cfs"
        Me.MinersInchAzButton.UseVisualStyleBackColor = True
        '
        'AcreFeetHourAbbrev
        '
        Me.AcreFeetHourAbbrev.AutoSize = True
        Me.AcreFeetHourAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.AcreFeetHourAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AcreFeetHourAbbrev.Location = New System.Drawing.Point(350, 102)
        Me.AcreFeetHourAbbrev.Name = "AcreFeetHourAbbrev"
        Me.AcreFeetHourAbbrev.Size = New System.Drawing.Size(53, 17)
        Me.AcreFeetHourAbbrev.TabIndex = 9
        Me.AcreFeetHourAbbrev.Text = "ac-ft/hr"
        '
        'AcreFeetHourButton
        '
        Me.AcreFeetHourButton.AutoSize = True
        Me.AcreFeetHourButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.AcreFeetHourButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AcreFeetHourButton.Location = New System.Drawing.Point(5, 100)
        Me.AcreFeetHourButton.Name = "AcreFeetHourButton"
        Me.AcreFeetHourButton.Size = New System.Drawing.Size(123, 21)
        Me.AcreFeetHourButton.TabIndex = 8
        Me.AcreFeetHourButton.TabStop = True
        Me.AcreFeetHourButton.Text = "Acre-Feet/Hour"
        Me.AcreFeetHourButton.UseVisualStyleBackColor = True
        '
        'GallonsMinuteAbbrev
        '
        Me.GallonsMinuteAbbrev.AutoSize = True
        Me.GallonsMinuteAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GallonsMinuteAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GallonsMinuteAbbrev.Location = New System.Drawing.Point(350, 82)
        Me.GallonsMinuteAbbrev.Name = "GallonsMinuteAbbrev"
        Me.GallonsMinuteAbbrev.Size = New System.Drawing.Size(35, 17)
        Me.GallonsMinuteAbbrev.TabIndex = 7
        Me.GallonsMinuteAbbrev.Text = "gpm"
        '
        'GallonsMinuteButton
        '
        Me.GallonsMinuteButton.AutoSize = True
        Me.GallonsMinuteButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GallonsMinuteButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GallonsMinuteButton.Location = New System.Drawing.Point(5, 80)
        Me.GallonsMinuteButton.Name = "GallonsMinuteButton"
        Me.GallonsMinuteButton.Size = New System.Drawing.Size(120, 21)
        Me.GallonsMinuteButton.TabIndex = 6
        Me.GallonsMinuteButton.TabStop = True
        Me.GallonsMinuteButton.Text = "Gallons/Minute"
        Me.GallonsMinuteButton.UseVisualStyleBackColor = True
        '
        'CubicFeetSecondAbbrev
        '
        Me.CubicFeetSecondAbbrev.AutoSize = True
        Me.CubicFeetSecondAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CubicFeetSecondAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CubicFeetSecondAbbrev.Location = New System.Drawing.Point(350, 62)
        Me.CubicFeetSecondAbbrev.Name = "CubicFeetSecondAbbrev"
        Me.CubicFeetSecondAbbrev.Size = New System.Drawing.Size(26, 17)
        Me.CubicFeetSecondAbbrev.TabIndex = 5
        Me.CubicFeetSecondAbbrev.Text = "cfs"
        '
        'CubicFeetSecondButton
        '
        Me.CubicFeetSecondButton.AutoSize = True
        Me.CubicFeetSecondButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CubicFeetSecondButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CubicFeetSecondButton.Location = New System.Drawing.Point(5, 60)
        Me.CubicFeetSecondButton.Name = "CubicFeetSecondButton"
        Me.CubicFeetSecondButton.Size = New System.Drawing.Size(145, 21)
        Me.CubicFeetSecondButton.TabIndex = 4
        Me.CubicFeetSecondButton.TabStop = True
        Me.CubicFeetSecondButton.Text = "Cubic Feet/Second"
        Me.CubicFeetSecondButton.UseVisualStyleBackColor = True
        '
        'LitersSecondAbbrev
        '
        Me.LitersSecondAbbrev.AutoSize = True
        Me.LitersSecondAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LitersSecondAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LitersSecondAbbrev.Location = New System.Drawing.Point(350, 42)
        Me.LitersSecondAbbrev.Name = "LitersSecondAbbrev"
        Me.LitersSecondAbbrev.Size = New System.Drawing.Size(22, 17)
        Me.LitersSecondAbbrev.TabIndex = 3
        Me.LitersSecondAbbrev.Text = "l/s"
        '
        'LitersSecondButton
        '
        Me.LitersSecondButton.AutoSize = True
        Me.LitersSecondButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LitersSecondButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LitersSecondButton.Location = New System.Drawing.Point(5, 40)
        Me.LitersSecondButton.Name = "LitersSecondButton"
        Me.LitersSecondButton.Size = New System.Drawing.Size(113, 21)
        Me.LitersSecondButton.TabIndex = 2
        Me.LitersSecondButton.TabStop = True
        Me.LitersSecondButton.Text = "Liters/Second"
        Me.LitersSecondButton.UseVisualStyleBackColor = True
        '
        'CubicMetersSecondAbbrev
        '
        Me.CubicMetersSecondAbbrev.AutoSize = True
        Me.CubicMetersSecondAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CubicMetersSecondAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CubicMetersSecondAbbrev.Location = New System.Drawing.Point(350, 22)
        Me.CubicMetersSecondAbbrev.Name = "CubicMetersSecondAbbrev"
        Me.CubicMetersSecondAbbrev.Size = New System.Drawing.Size(35, 17)
        Me.CubicMetersSecondAbbrev.TabIndex = 1
        Me.CubicMetersSecondAbbrev.Text = "m³/s"
        '
        'CubicMetersSecondButton
        '
        Me.CubicMetersSecondButton.AutoSize = True
        Me.CubicMetersSecondButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CubicMetersSecondButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CubicMetersSecondButton.Location = New System.Drawing.Point(5, 20)
        Me.CubicMetersSecondButton.Name = "CubicMetersSecondButton"
        Me.CubicMetersSecondButton.Size = New System.Drawing.Size(160, 21)
        Me.CubicMetersSecondButton.TabIndex = 0
        Me.CubicMetersSecondButton.TabStop = True
        Me.CubicMetersSecondButton.Text = "Cubic Meters/Second"
        Me.CubicMetersSecondButton.UseVisualStyleBackColor = True
        '
        'WaterVelocityGroup
        '
        Me.WaterVelocityGroup.AccessibleDescription = "Units selection for velocity values"
        Me.WaterVelocityGroup.AccessibleName = "Water Velocity"
        Me.WaterVelocityGroup.Controls.Add(Me.FeetSecondAbbrev)
        Me.WaterVelocityGroup.Controls.Add(Me.FeetSecondButton)
        Me.WaterVelocityGroup.Controls.Add(Me.MetersSecondAbbrev)
        Me.WaterVelocityGroup.Controls.Add(Me.MetersSecondButton)
        Me.WaterVelocityGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.WaterVelocityGroup.Location = New System.Drawing.Point(10, 190)
        Me.WaterVelocityGroup.Name = "WaterVelocityGroup"
        Me.WaterVelocityGroup.Size = New System.Drawing.Size(220, 70)
        Me.WaterVelocityGroup.TabIndex = 2
        Me.WaterVelocityGroup.TabStop = False
        Me.WaterVelocityGroup.Text = "&Velocity"
        '
        'FeetSecondAbbrev
        '
        Me.FeetSecondAbbrev.AutoSize = True
        Me.FeetSecondAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.FeetSecondAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FeetSecondAbbrev.Location = New System.Drawing.Point(156, 42)
        Me.FeetSecondAbbrev.Name = "FeetSecondAbbrev"
        Me.FeetSecondAbbrev.Size = New System.Drawing.Size(27, 17)
        Me.FeetSecondAbbrev.TabIndex = 3
        Me.FeetSecondAbbrev.Text = "ft/s"
        '
        'FeetSecondButton
        '
        Me.FeetSecondButton.AutoSize = True
        Me.FeetSecondButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.FeetSecondButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FeetSecondButton.Location = New System.Drawing.Point(5, 40)
        Me.FeetSecondButton.Name = "FeetSecondButton"
        Me.FeetSecondButton.Size = New System.Drawing.Size(106, 21)
        Me.FeetSecondButton.TabIndex = 2
        Me.FeetSecondButton.TabStop = True
        Me.FeetSecondButton.Text = "Feet/Second"
        Me.FeetSecondButton.UseVisualStyleBackColor = True
        '
        'MetersSecondAbbrev
        '
        Me.MetersSecondAbbrev.AutoSize = True
        Me.MetersSecondAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MetersSecondAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MetersSecondAbbrev.Location = New System.Drawing.Point(156, 22)
        Me.MetersSecondAbbrev.Name = "MetersSecondAbbrev"
        Me.MetersSecondAbbrev.Size = New System.Drawing.Size(30, 17)
        Me.MetersSecondAbbrev.TabIndex = 1
        Me.MetersSecondAbbrev.Text = "m/s"
        '
        'MetersSecondButton
        '
        Me.MetersSecondButton.AutoSize = True
        Me.MetersSecondButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MetersSecondButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MetersSecondButton.Location = New System.Drawing.Point(5, 20)
        Me.MetersSecondButton.Name = "MetersSecondButton"
        Me.MetersSecondButton.Size = New System.Drawing.Size(121, 21)
        Me.MetersSecondButton.TabIndex = 0
        Me.MetersSecondButton.TabStop = True
        Me.MetersSecondButton.Text = "Meters/Second"
        Me.MetersSecondButton.UseVisualStyleBackColor = True
        '
        'LengthHeightGroup
        '
        Me.LengthHeightGroup.AccessibleDescription = "Units selection for length and height values"
        Me.LengthHeightGroup.AccessibleName = "Length and Height"
        Me.LengthHeightGroup.Controls.Add(Me.CentimetersAbbrev)
        Me.LengthHeightGroup.Controls.Add(Me.CentimetersButton)
        Me.LengthHeightGroup.Controls.Add(Me.InchesAbbrev)
        Me.LengthHeightGroup.Controls.Add(Me.InchesButton)
        Me.LengthHeightGroup.Controls.Add(Me.MillimetersAbbrev)
        Me.LengthHeightGroup.Controls.Add(Me.MillimetersButton)
        Me.LengthHeightGroup.Controls.Add(Me.FeetAbbrev)
        Me.LengthHeightGroup.Controls.Add(Me.FeetButton)
        Me.LengthHeightGroup.Controls.Add(Me.MetersAbbrev)
        Me.LengthHeightGroup.Controls.Add(Me.MetersButton)
        Me.LengthHeightGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LengthHeightGroup.Location = New System.Drawing.Point(10, 10)
        Me.LengthHeightGroup.Name = "LengthHeightGroup"
        Me.LengthHeightGroup.Size = New System.Drawing.Size(220, 130)
        Me.LengthHeightGroup.TabIndex = 1
        Me.LengthHeightGroup.TabStop = False
        Me.LengthHeightGroup.Text = "&Length && Height"
        '
        'CentimetersAbbrev
        '
        Me.CentimetersAbbrev.AutoSize = True
        Me.CentimetersAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CentimetersAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CentimetersAbbrev.Location = New System.Drawing.Point(156, 102)
        Me.CentimetersAbbrev.Name = "CentimetersAbbrev"
        Me.CentimetersAbbrev.Size = New System.Drawing.Size(26, 17)
        Me.CentimetersAbbrev.TabIndex = 9
        Me.CentimetersAbbrev.Text = "cm"
        '
        'CentimetersButton
        '
        Me.CentimetersButton.AutoSize = True
        Me.CentimetersButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.CentimetersButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CentimetersButton.Location = New System.Drawing.Point(5, 100)
        Me.CentimetersButton.Name = "CentimetersButton"
        Me.CentimetersButton.Size = New System.Drawing.Size(101, 21)
        Me.CentimetersButton.TabIndex = 8
        Me.CentimetersButton.TabStop = True
        Me.CentimetersButton.Text = "Centimeters"
        Me.CentimetersButton.UseVisualStyleBackColor = True
        '
        'InchesAbbrev
        '
        Me.InchesAbbrev.AutoSize = True
        Me.InchesAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.InchesAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.InchesAbbrev.Location = New System.Drawing.Point(156, 82)
        Me.InchesAbbrev.Name = "InchesAbbrev"
        Me.InchesAbbrev.Size = New System.Drawing.Size(19, 17)
        Me.InchesAbbrev.TabIndex = 7
        Me.InchesAbbrev.Text = "in"
        '
        'InchesButton
        '
        Me.InchesButton.AutoSize = True
        Me.InchesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.InchesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.InchesButton.Location = New System.Drawing.Point(5, 80)
        Me.InchesButton.Name = "InchesButton"
        Me.InchesButton.Size = New System.Drawing.Size(67, 21)
        Me.InchesButton.TabIndex = 6
        Me.InchesButton.TabStop = True
        Me.InchesButton.Text = "Inches"
        Me.InchesButton.UseVisualStyleBackColor = True
        '
        'MillimetersAbbrev
        '
        Me.MillimetersAbbrev.AutoSize = True
        Me.MillimetersAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MillimetersAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MillimetersAbbrev.Location = New System.Drawing.Point(156, 62)
        Me.MillimetersAbbrev.Name = "MillimetersAbbrev"
        Me.MillimetersAbbrev.Size = New System.Drawing.Size(30, 17)
        Me.MillimetersAbbrev.TabIndex = 5
        Me.MillimetersAbbrev.Text = "mm"
        '
        'MillimetersButton
        '
        Me.MillimetersButton.AutoSize = True
        Me.MillimetersButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MillimetersButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MillimetersButton.Location = New System.Drawing.Point(5, 60)
        Me.MillimetersButton.Name = "MillimetersButton"
        Me.MillimetersButton.Size = New System.Drawing.Size(92, 21)
        Me.MillimetersButton.TabIndex = 4
        Me.MillimetersButton.TabStop = True
        Me.MillimetersButton.Text = "Millimeters"
        Me.MillimetersButton.UseVisualStyleBackColor = True
        '
        'FeetAbbrev
        '
        Me.FeetAbbrev.AutoSize = True
        Me.FeetAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.FeetAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FeetAbbrev.Location = New System.Drawing.Point(156, 42)
        Me.FeetAbbrev.Name = "FeetAbbrev"
        Me.FeetAbbrev.Size = New System.Drawing.Size(16, 17)
        Me.FeetAbbrev.TabIndex = 3
        Me.FeetAbbrev.Text = "ft"
        '
        'FeetButton
        '
        Me.FeetButton.AutoSize = True
        Me.FeetButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.FeetButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FeetButton.Location = New System.Drawing.Point(5, 40)
        Me.FeetButton.Name = "FeetButton"
        Me.FeetButton.Size = New System.Drawing.Size(54, 21)
        Me.FeetButton.TabIndex = 2
        Me.FeetButton.TabStop = True
        Me.FeetButton.Text = "Feet"
        Me.FeetButton.UseVisualStyleBackColor = True
        '
        'MetersAbbrev
        '
        Me.MetersAbbrev.AutoSize = True
        Me.MetersAbbrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MetersAbbrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MetersAbbrev.Location = New System.Drawing.Point(156, 22)
        Me.MetersAbbrev.Name = "MetersAbbrev"
        Me.MetersAbbrev.Size = New System.Drawing.Size(19, 17)
        Me.MetersAbbrev.TabIndex = 1
        Me.MetersAbbrev.Text = "m"
        '
        'MetersButton
        '
        Me.MetersButton.AutoSize = True
        Me.MetersButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.MetersButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MetersButton.Location = New System.Drawing.Point(5, 20)
        Me.MetersButton.Name = "MetersButton"
        Me.MetersButton.Size = New System.Drawing.Size(69, 21)
        Me.MetersButton.TabIndex = 0
        Me.MetersButton.TabStop = True
        Me.MetersButton.Text = "Meters"
        Me.MetersButton.UseVisualStyleBackColor = True
        '
        'UnitsDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AccessibleDescription = "Selects units for displaying and entering values"
        Me.AccessibleName = "Flume Design Units Dialog"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(694, 355)
        Me.Controls.Add(Me.DischargeGroup)
        Me.Controls.Add(Me.WaterVelocityGroup)
        Me.Controls.Add(Me.LengthHeightGroup)
        Me.Controls.Add(Me.ButtonTableLayoutPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UnitsDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Flume Design Units"
        Me.TopMost = True
        Me.ButtonTableLayoutPanel.ResumeLayout(False)
        Me.DischargeGroup.ResumeLayout(False)
        Me.DischargeGroup.PerformLayout()
        Me.WaterVelocityGroup.ResumeLayout(False)
        Me.WaterVelocityGroup.PerformLayout()
        Me.LengthHeightGroup.ResumeLayout(False)
        Me.LengthHeightGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents LengthHeightGroup As System.Windows.Forms.GroupBox
    Friend WithEvents MetersButton As System.Windows.Forms.RadioButton
    Friend WithEvents CentimetersAbbrev As System.Windows.Forms.Label
    Friend WithEvents CentimetersButton As System.Windows.Forms.RadioButton
    Friend WithEvents InchesAbbrev As System.Windows.Forms.Label
    Friend WithEvents InchesButton As System.Windows.Forms.RadioButton
    Friend WithEvents MillimetersAbbrev As System.Windows.Forms.Label
    Friend WithEvents MillimetersButton As System.Windows.Forms.RadioButton
    Friend WithEvents FeetAbbrev As System.Windows.Forms.Label
    Friend WithEvents FeetButton As System.Windows.Forms.RadioButton
    Friend WithEvents MetersAbbrev As System.Windows.Forms.Label
    Friend WithEvents WaterVelocityGroup As System.Windows.Forms.GroupBox
    Friend WithEvents FeetSecondAbbrev As System.Windows.Forms.Label
    Friend WithEvents FeetSecondButton As System.Windows.Forms.RadioButton
    Friend WithEvents MetersSecondAbbrev As System.Windows.Forms.Label
    Friend WithEvents MetersSecondButton As System.Windows.Forms.RadioButton
    Friend WithEvents DischargeGroup As System.Windows.Forms.GroupBox
    Friend WithEvents LitersSecondAbbrev As System.Windows.Forms.Label
    Friend WithEvents LitersSecondButton As System.Windows.Forms.RadioButton
    Friend WithEvents CubicMetersSecondAbbrev As System.Windows.Forms.Label
    Friend WithEvents CubicMetersSecondButton As System.Windows.Forms.RadioButton
    Friend WithEvents MillionGallonsDayAbbrev As System.Windows.Forms.Label
    Friend WithEvents MillionGallonsDayButton As System.Windows.Forms.RadioButton
    Friend WithEvents MegalitersDayAbbrev As System.Windows.Forms.Label
    Friend WithEvents MegalitersDayButton As System.Windows.Forms.RadioButton
    Friend WithEvents MegalitersHourAbbrev As System.Windows.Forms.Label
    Friend WithEvents MegalitersHourButton As System.Windows.Forms.RadioButton
    Friend WithEvents MinersInchCoAbbrev As System.Windows.Forms.Label
    Friend WithEvents MinersInchCoButton As System.Windows.Forms.RadioButton
    Friend WithEvents MinersInchIdAbbrev As System.Windows.Forms.Label
    Friend WithEvents MinersInchIdButton As System.Windows.Forms.RadioButton
    Friend WithEvents MinersInchAzAbbrev As System.Windows.Forms.Label
    Friend WithEvents MinersInchAzButton As System.Windows.Forms.RadioButton
    Friend WithEvents AcreFeetHourAbbrev As System.Windows.Forms.Label
    Friend WithEvents AcreFeetHourButton As System.Windows.Forms.RadioButton
    Friend WithEvents GallonsMinuteAbbrev As System.Windows.Forms.Label
    Friend WithEvents GallonsMinuteButton As System.Windows.Forms.RadioButton
    Friend WithEvents CubicFeetSecondAbbrev As System.Windows.Forms.Label
    Friend WithEvents CubicFeetSecondButton As System.Windows.Forms.RadioButton
    Friend WithEvents Convert_Button As Button
End Class
