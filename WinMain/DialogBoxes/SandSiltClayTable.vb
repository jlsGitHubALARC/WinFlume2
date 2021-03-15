
'*************************************************************************************************************
' Dialog Box: SandSiltClayTable
'
'   SandSiltClayTable provides the UI for viewing & editing Sediment Components table
'*************************************************************************************************************
Imports DataStore

Public Class SandSiltClayTable
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal unit As Unit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.InitializeSandSiltClay(unit)

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents SandSievePanel As DataStore.ctl_Panel
    Friend WithEvents SandPct As System.Windows.Forms.NumericUpDown
    Friend WithEvents SandSizeLabel As DataStore.ctl_Label
    Friend WithEvents SandSieveLabel As DataStore.ctl_Label
    Friend WithEvents SandBox As System.Windows.Forms.Button
    Friend WithEvents OkButton As DataStore.ctl_Button
    Friend WithEvents Cancel As DataStore.ctl_Button
    Friend WithEvents SoilImages As System.Windows.Forms.ImageList
    Friend WithEvents ClayImage As System.Windows.Forms.Label
    Friend WithEvents SiltClayImage As System.Windows.Forms.Label
    Friend WithEvents SandSiltClayImage As System.Windows.Forms.Label
    Friend WithEvents SiltSievePanel As DataStore.ctl_Panel
    Friend WithEvents SiltPct As System.Windows.Forms.NumericUpDown
    Friend WithEvents SiltSizeLabel As DataStore.ctl_Label
    Friend WithEvents SiltSieveLabel As DataStore.ctl_Label
    Friend WithEvents SiltBox As System.Windows.Forms.Button
    Friend WithEvents ClayLabel As DataStore.ctl_Label
    Friend WithEvents ClaySizeLabel As DataStore.ctl_Label
    Friend WithEvents TotalLabel As DataStore.ctl_Label
    Friend WithEvents ClayPct As System.Windows.Forms.Label
    Friend WithEvents SandSpecificGravityLabel As DataStore.ctl_Label
    Friend WithEvents SandSpecificGravity As System.Windows.Forms.NumericUpDown
    Friend WithEvents SiltSpecificGravityLabel As DataStore.ctl_Label
    Friend WithEvents SiltSpecificGravity As System.Windows.Forms.NumericUpDown
    Friend WithEvents InstructionsPanel As DataStore.ctl_Panel
    Friend WithEvents Instructions As DataStore.ctl_Label
    Friend WithEvents SandSieveItem As DataStore.ctl_Label
    Friend WithEvents SiltSieveItem As DataStore.ctl_Label
    Friend WithEvents TotalValue As System.Windows.Forms.Label
    Friend WithEvents ClayItem As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SandSiltClayTable))
        Me.SandSievePanel = New DataStore.ctl_Panel
        Me.SandPct = New System.Windows.Forms.NumericUpDown
        Me.SandSizeLabel = New DataStore.ctl_Label
        Me.SandSieveLabel = New DataStore.ctl_Label
        Me.SandBox = New System.Windows.Forms.Button
        Me.OkButton = New DataStore.ctl_Button
        Me.Cancel = New DataStore.ctl_Button
        Me.ClayImage = New System.Windows.Forms.Label
        Me.SoilImages = New System.Windows.Forms.ImageList(Me.components)
        Me.SiltClayImage = New System.Windows.Forms.Label
        Me.SandSiltClayImage = New System.Windows.Forms.Label
        Me.SiltSievePanel = New DataStore.ctl_Panel
        Me.SiltPct = New System.Windows.Forms.NumericUpDown
        Me.SiltSizeLabel = New DataStore.ctl_Label
        Me.SiltSieveLabel = New DataStore.ctl_Label
        Me.SiltBox = New System.Windows.Forms.Button
        Me.ClayLabel = New DataStore.ctl_Label
        Me.ClaySizeLabel = New DataStore.ctl_Label
        Me.TotalLabel = New DataStore.ctl_Label
        Me.ClayPct = New System.Windows.Forms.Label
        Me.SandSpecificGravityLabel = New DataStore.ctl_Label
        Me.SandSpecificGravity = New System.Windows.Forms.NumericUpDown
        Me.SiltSpecificGravityLabel = New DataStore.ctl_Label
        Me.SiltSpecificGravity = New System.Windows.Forms.NumericUpDown
        Me.InstructionsPanel = New DataStore.ctl_Panel
        Me.ClayItem = New DataStore.ctl_Label
        Me.SiltSieveItem = New DataStore.ctl_Label
        Me.SandSieveItem = New DataStore.ctl_Label
        Me.Instructions = New DataStore.ctl_Label
        Me.TotalValue = New System.Windows.Forms.Label
        Me.SandSievePanel.SuspendLayout()
        CType(Me.SandPct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SiltSievePanel.SuspendLayout()
        CType(Me.SiltPct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SandSpecificGravity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SiltSpecificGravity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InstructionsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'SandSievePanel
        '
        Me.SandSievePanel.Controls.Add(Me.SandPct)
        Me.SandSievePanel.Controls.Add(Me.SandSizeLabel)
        Me.SandSievePanel.Controls.Add(Me.SandSieveLabel)
        Me.SandSievePanel.Controls.Add(Me.SandBox)
        Me.SandSievePanel.Location = New System.Drawing.Point(8, 136)
        Me.SandSievePanel.Name = "SandSievePanel"
        Me.SandSievePanel.Size = New System.Drawing.Size(365, 32)
        Me.SandSievePanel.TabIndex = 2
        '
        'SandPct
        '
        Me.SandPct.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SandPct.DecimalPlaces = 1
        Me.SandPct.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.SandPct.Location = New System.Drawing.Point(108, 8)
        Me.SandPct.Maximum = New Decimal(New Integer() {998, 0, 0, 65536})
        Me.SandPct.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.SandPct.Name = "SandPct"
        Me.SandPct.Size = New System.Drawing.Size(56, 19)
        Me.SandPct.TabIndex = 1
        Me.SandPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.SandPct.Value = New Decimal(New Integer() {555, 0, 0, 65536})
        '
        'SandSizeLabel
        '
        Me.SandSizeLabel.Location = New System.Drawing.Point(176, 8)
        Me.SandSizeLabel.Name = "SandSizeLabel"
        Me.SandSizeLabel.Size = New System.Drawing.Size(178, 24)
        Me.SandSizeLabel.TabIndex = 3
        Me.SandSizeLabel.Text = "% coarser than 50 microns"
        Me.SandSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SandSieveLabel
        '
        Me.SandSieveLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SandSieveLabel.Location = New System.Drawing.Point(1, 8)
        Me.SandSieveLabel.Name = "SandSieveLabel"
        Me.SandSieveLabel.Size = New System.Drawing.Size(88, 23)
        Me.SandSieveLabel.TabIndex = 0
        Me.SandSieveLabel.Text = "&Sand Sieve"
        Me.SandSieveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SandBox
        '
        Me.SandBox.BackColor = System.Drawing.SystemColors.ControlDark
        Me.SandBox.Enabled = False
        Me.SandBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SandBox.Location = New System.Drawing.Point(96, 8)
        Me.SandBox.Name = "SandBox"
        Me.SandBox.Size = New System.Drawing.Size(76, 23)
        Me.SandBox.TabIndex = 2
        Me.SandBox.UseVisualStyleBackColor = False
        '
        'OkButton
        '
        Me.OkButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OkButton.Location = New System.Drawing.Point(16, 344)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 24)
        Me.OkButton.TabIndex = 15
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(287, 344)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(75, 24)
        Me.Cancel.TabIndex = 16
        Me.Cancel.Text = "&Cancel"
        '
        'ClayImage
        '
        Me.ClayImage.ImageIndex = 0
        Me.ClayImage.ImageList = Me.SoilImages
        Me.ClayImage.Location = New System.Drawing.Point(112, 232)
        Me.ClayImage.Name = "ClayImage"
        Me.ClayImage.Size = New System.Drawing.Size(64, 32)
        Me.ClayImage.TabIndex = 7
        '
        'SoilImages
        '
        Me.SoilImages.ImageStream = CType(resources.GetObject("SoilImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.SoilImages.TransparentColor = System.Drawing.Color.Transparent
        Me.SoilImages.Images.SetKeyName(0, "")
        Me.SoilImages.Images.SetKeyName(1, "")
        Me.SoilImages.Images.SetKeyName(2, "")
        '
        'SiltClayImage
        '
        Me.SiltClayImage.ImageIndex = 1
        Me.SiltClayImage.ImageList = Me.SoilImages
        Me.SiltClayImage.Location = New System.Drawing.Point(112, 168)
        Me.SiltClayImage.Name = "SiltClayImage"
        Me.SiltClayImage.Size = New System.Drawing.Size(64, 32)
        Me.SiltClayImage.TabIndex = 3
        Me.SiltClayImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SandSiltClayImage
        '
        Me.SandSiltClayImage.ImageIndex = 2
        Me.SandSiltClayImage.ImageList = Me.SoilImages
        Me.SandSiltClayImage.Location = New System.Drawing.Point(112, 104)
        Me.SandSiltClayImage.Name = "SandSiltClayImage"
        Me.SandSiltClayImage.Size = New System.Drawing.Size(64, 32)
        Me.SandSiltClayImage.TabIndex = 1
        '
        'SiltSievePanel
        '
        Me.SiltSievePanel.Controls.Add(Me.SiltPct)
        Me.SiltSievePanel.Controls.Add(Me.SiltSizeLabel)
        Me.SiltSievePanel.Controls.Add(Me.SiltSieveLabel)
        Me.SiltSievePanel.Controls.Add(Me.SiltBox)
        Me.SiltSievePanel.Location = New System.Drawing.Point(8, 200)
        Me.SiltSievePanel.Name = "SiltSievePanel"
        Me.SiltSievePanel.Size = New System.Drawing.Size(365, 32)
        Me.SiltSievePanel.TabIndex = 6
        '
        'SiltPct
        '
        Me.SiltPct.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SiltPct.DecimalPlaces = 1
        Me.SiltPct.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.SiltPct.Location = New System.Drawing.Point(108, 8)
        Me.SiltPct.Maximum = New Decimal(New Integer() {998, 0, 0, 65536})
        Me.SiltPct.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.SiltPct.Name = "SiltPct"
        Me.SiltPct.Size = New System.Drawing.Size(56, 19)
        Me.SiltPct.TabIndex = 1
        Me.SiltPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.SiltPct.Value = New Decimal(New Integer() {333, 0, 0, 65536})
        '
        'SiltSizeLabel
        '
        Me.SiltSizeLabel.Location = New System.Drawing.Point(176, 8)
        Me.SiltSizeLabel.Name = "SiltSizeLabel"
        Me.SiltSizeLabel.Size = New System.Drawing.Size(181, 24)
        Me.SiltSizeLabel.TabIndex = 3
        Me.SiltSizeLabel.Text = "% coarser than 8 microns"
        Me.SiltSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SiltSieveLabel
        '
        Me.SiltSieveLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SiltSieveLabel.Location = New System.Drawing.Point(1, 8)
        Me.SiltSieveLabel.Name = "SiltSieveLabel"
        Me.SiltSieveLabel.Size = New System.Drawing.Size(88, 23)
        Me.SiltSieveLabel.TabIndex = 0
        Me.SiltSieveLabel.Text = "S&ilt Sieve"
        Me.SiltSieveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SiltBox
        '
        Me.SiltBox.BackColor = System.Drawing.SystemColors.ControlDark
        Me.SiltBox.Enabled = False
        Me.SiltBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SiltBox.Location = New System.Drawing.Point(96, 8)
        Me.SiltBox.Name = "SiltBox"
        Me.SiltBox.Size = New System.Drawing.Size(76, 23)
        Me.SiltBox.TabIndex = 2
        Me.SiltBox.UseVisualStyleBackColor = False
        '
        'ClayLabel
        '
        Me.ClayLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClayLabel.Location = New System.Drawing.Point(8, 264)
        Me.ClayLabel.Name = "ClayLabel"
        Me.ClayLabel.Size = New System.Drawing.Size(88, 23)
        Me.ClayLabel.TabIndex = 10
        Me.ClayLabel.Text = "Clay"
        Me.ClayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ClaySizeLabel
        '
        Me.ClaySizeLabel.Location = New System.Drawing.Point(184, 264)
        Me.ClaySizeLabel.Name = "ClaySizeLabel"
        Me.ClaySizeLabel.Size = New System.Drawing.Size(131, 23)
        Me.ClaySizeLabel.TabIndex = 12
        Me.ClaySizeLabel.Text = "% remainder"
        Me.ClaySizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TotalLabel
        '
        Me.TotalLabel.Location = New System.Drawing.Point(8, 296)
        Me.TotalLabel.Name = "TotalLabel"
        Me.TotalLabel.Size = New System.Drawing.Size(89, 23)
        Me.TotalLabel.TabIndex = 13
        Me.TotalLabel.Text = "Total"
        Me.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ClayPct
        '
        Me.ClayPct.Location = New System.Drawing.Point(128, 264)
        Me.ClayPct.Name = "ClayPct"
        Me.ClayPct.Size = New System.Drawing.Size(40, 23)
        Me.ClayPct.TabIndex = 11
        Me.ClayPct.Text = "11.2"
        Me.ClayPct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SandSpecificGravityLabel
        '
        Me.SandSpecificGravityLabel.Location = New System.Drawing.Point(190, 168)
        Me.SandSpecificGravityLabel.Name = "SandSpecificGravityLabel"
        Me.SandSpecificGravityLabel.Size = New System.Drawing.Size(125, 23)
        Me.SandSpecificGravityLabel.TabIndex = 4
        Me.SandSpecificGravityLabel.Text = "Specific &Gravity"
        Me.SandSpecificGravityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SandSpecificGravity
        '
        Me.SandSpecificGravity.DecimalPlaces = 2
        Me.SandSpecificGravity.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.SandSpecificGravity.Location = New System.Drawing.Point(321, 168)
        Me.SandSpecificGravity.Maximum = New Decimal(New Integer() {999, 0, 0, 131072})
        Me.SandSpecificGravity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SandSpecificGravity.Name = "SandSpecificGravity"
        Me.SandSpecificGravity.Size = New System.Drawing.Size(48, 23)
        Me.SandSpecificGravity.TabIndex = 5
        Me.SandSpecificGravity.Value = New Decimal(New Integer() {265, 0, 0, 131072})
        '
        'SiltSpecificGravityLabel
        '
        Me.SiltSpecificGravityLabel.Location = New System.Drawing.Point(187, 232)
        Me.SiltSpecificGravityLabel.Name = "SiltSpecificGravityLabel"
        Me.SiltSpecificGravityLabel.Size = New System.Drawing.Size(128, 23)
        Me.SiltSpecificGravityLabel.TabIndex = 8
        Me.SiltSpecificGravityLabel.Text = "Specific G&ravity"
        Me.SiltSpecificGravityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SiltSpecificGravity
        '
        Me.SiltSpecificGravity.DecimalPlaces = 2
        Me.SiltSpecificGravity.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.SiltSpecificGravity.Location = New System.Drawing.Point(321, 232)
        Me.SiltSpecificGravity.Maximum = New Decimal(New Integer() {999, 0, 0, 131072})
        Me.SiltSpecificGravity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SiltSpecificGravity.Name = "SiltSpecificGravity"
        Me.SiltSpecificGravity.Size = New System.Drawing.Size(48, 23)
        Me.SiltSpecificGravity.TabIndex = 9
        Me.SiltSpecificGravity.Value = New Decimal(New Integer() {265, 0, 0, 131072})
        '
        'InstructionsPanel
        '
        Me.InstructionsPanel.BackColor = System.Drawing.SystemColors.Info
        Me.InstructionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.InstructionsPanel.Controls.Add(Me.ClayItem)
        Me.InstructionsPanel.Controls.Add(Me.SiltSieveItem)
        Me.InstructionsPanel.Controls.Add(Me.SandSieveItem)
        Me.InstructionsPanel.Controls.Add(Me.Instructions)
        Me.InstructionsPanel.Location = New System.Drawing.Point(16, 8)
        Me.InstructionsPanel.Name = "InstructionsPanel"
        Me.InstructionsPanel.Size = New System.Drawing.Size(346, 88)
        Me.InstructionsPanel.TabIndex = 0
        '
        'ClayItem
        '
        Me.ClayItem.Location = New System.Drawing.Point(0, 60)
        Me.ClayItem.Name = "ClayItem"
        Me.ClayItem.Size = New System.Drawing.Size(328, 23)
        Me.ClayItem.TabIndex = 3
        Me.ClayItem.Text = "3) Remainder is Clay"
        Me.ClayItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SiltSieveItem
        '
        Me.SiltSieveItem.Location = New System.Drawing.Point(0, 42)
        Me.SiltSieveItem.Name = "SiltSieveItem"
        Me.SiltSieveItem.Size = New System.Drawing.Size(328, 23)
        Me.SiltSieveItem.TabIndex = 2
        Me.SiltSieveItem.Text = "2) Silt Sieve (8 microns)"
        Me.SiltSieveItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SandSieveItem
        '
        Me.SandSieveItem.Location = New System.Drawing.Point(0, 24)
        Me.SandSieveItem.Name = "SandSieveItem"
        Me.SandSieveItem.Size = New System.Drawing.Size(328, 23)
        Me.SandSieveItem.TabIndex = 1
        Me.SandSieveItem.Text = "1) Sand Sieve (50 microns)"
        Me.SandSieveItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Instructions
        '
        Me.Instructions.Location = New System.Drawing.Point(0, 0)
        Me.Instructions.Name = "Instructions"
        Me.Instructions.Size = New System.Drawing.Size(328, 23)
        Me.Instructions.TabIndex = 0
        Me.Instructions.Text = "Enter percentage of soil retained by each sieve:"
        Me.Instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TotalValue
        '
        Me.TotalValue.Location = New System.Drawing.Point(120, 296)
        Me.TotalValue.Name = "TotalValue"
        Me.TotalValue.Size = New System.Drawing.Size(69, 23)
        Me.TotalValue.TabIndex = 14
        Me.TotalValue.Text = "100.0 %"
        Me.TotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SandSiltClayTable
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(374, 375)
        Me.Controls.Add(Me.TotalValue)
        Me.Controls.Add(Me.InstructionsPanel)
        Me.Controls.Add(Me.SiltSpecificGravity)
        Me.Controls.Add(Me.SiltSpecificGravityLabel)
        Me.Controls.Add(Me.SandSpecificGravity)
        Me.Controls.Add(Me.SandSpecificGravityLabel)
        Me.Controls.Add(Me.ClayPct)
        Me.Controls.Add(Me.TotalLabel)
        Me.Controls.Add(Me.ClaySizeLabel)
        Me.Controls.Add(Me.ClayLabel)
        Me.Controls.Add(Me.SiltSievePanel)
        Me.Controls.Add(Me.SandSiltClayImage)
        Me.Controls.Add(Me.SiltClayImage)
        Me.Controls.Add(Me.ClayImage)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.SandSievePanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SandSiltClayTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sand / Clay / Silt Sediment Components Table"
        Me.SandSievePanel.ResumeLayout(False)
        CType(Me.SandPct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SiltSievePanel.ResumeLayout(False)
        CType(Me.SiltPct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SandSpecificGravity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SiltSpecificGravity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InstructionsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    Private mUnit As Unit
    Private mSoilCropProperties As SoilCropProperties
    Private mSedimentComponents As DataTableParameter
    Private mSedimentTable As DataTable

    Private mSandPct As Double
    Private mSiltPct As Double
    Private mClayPct As Double

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Initialization "

    Private Sub InitializeSandSiltClay(ByVal unit As Unit)

        If (unit IsNot Nothing) Then
            mUnit = unit
            mSoilCropProperties = mUnit.SoilCropPropertiesRef

            mSedimentComponents = mSoilCropProperties.SedimentComponents

            If (mSedimentComponents IsNot Nothing) Then

                Me.Text = mDictionary.ControlText(Me)

                mSedimentTable = mSedimentComponents.Value
                If (mSedimentTable Is Nothing) Then
                    mSoilCropProperties.ResetSedimentComponents(mSedimentTable)
                End If
                If (0 = mSedimentTable.Rows.Count) Then
                    mSoilCropProperties.ResetSedimentComponents(mSedimentTable)
                End If

                ' Get Sand / Silt / Clay data from Sediment Components table
                Dim row As DataRow = mSedimentTable.Rows(0)
                Dim pct As Double = row.Item(sPercentRetainedX)
                Dim sg As Double = row.Item(sSpecificGravityX)

                Me.SandPct.Value = pct * 100.0
                Me.SandSpecificGravity.Value = sg

                If (1 < mSedimentTable.Rows.Count) Then
                    row = mSedimentTable.Rows(1)
                    pct = row.Item(sPercentRetainedX)
                    sg = row.Item(sSpecificGravityX)

                    Me.SiltPct.Value = pct * 100.0
                    Me.SiltSpecificGravity.Value = sg
                Else
                    Me.SiltPct.Value = (100.0 - Me.SandPct.Value) / 2.0
                    Me.SiltSpecificGravity.Value = sg
                End If

                UpdateClayPct()

            Else
                Debug.Assert(False, "Sediment Components is Nothing")
            End If
        End If

    End Sub

#End Region

#Region " Methods "

    Private Sub UpdateSandPct()
        mSandPct = Me.SandPct.Value
        Me.UpdateClayPct()

        If (mClayPct < 0.1) Then
            mSiltPct = 99.9 - mSandPct
            Me.SiltPct.Value = mSiltPct
            Me.UpdateClayPct()
        End If
    End Sub

    Private Sub UpdateSiltPct()
        mSiltPct = Me.SiltPct.Value
        Me.UpdateClayPct()

        If (mClayPct < 0.1) Then
            mSandPct = 99.9 - mSiltPct
            Me.SandPct.Value = mSandPct
            Me.UpdateClayPct()
        End If
    End Sub

    Private Sub UpdateClayPct()
        mClayPct = 100.0 - mSandPct - mSiltPct
        Me.ClayPct.Text = Format(mClayPct, "00.0")
    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub SandPct_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SandPct.ValueChanged
        Me.UpdateSandPct()
    End Sub

    Private Sub SandPct_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SandPct.Leave
        Me.UpdateSandPct()
    End Sub

    Private Sub SiltPct_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SiltPct.ValueChanged
        Me.UpdateSiltPct()
    End Sub

    Private Sub SiltPct_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SiltPct.Leave
        Me.UpdateSiltPct()
    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkButton.Click

        ' Remove previous data
        mSedimentTable.Columns.Clear()
        mSedimentTable.Rows.Clear()

        ' Add columns
        mSedimentTable.Columns.Add(sPercentRetainedX, GetType(Double))
        mSedimentTable.Columns.Add(sSieveSizeX, GetType(Double))
        mSedimentTable.Columns.Add(sSpecificGravityX, GetType(String))

        ' Add rows of user data
        Dim row As DataRow

        row = mSedimentTable.NewRow
        row.Item(sPercentRetainedX) = mSandPct / 100.0
        row.Item(sSieveSizeX) = FiftyMicrons
        row.Item(sSpecificGravityX) = Me.SandSpecificGravity.Value
        mSedimentTable.Rows.Add(row)

        row = mSedimentTable.NewRow
        row.Item(sPercentRetainedX) = mSiltPct / 100.0
        row.Item(sSieveSizeX) = EightMicrons
        row.Item(sSpecificGravityX) = Me.SiltSpecificGravity.Value
        mSedimentTable.Rows.Add(row)

        ' Store new Sediment Components table in DataStore
        Dim undoText As String = Me.Text.Replace("&", "")
        mUnit.MyStore.MarkForUndo(undoText)

        mSedimentComponents.Value = mSedimentTable
        mSedimentComponents.Source = ValueSources.UserEntered
        mSoilCropProperties.SedimentComponents = mSedimentComponents

        Me.Close()

    End Sub

    Private Sub SandSiltClayTable_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("", 0)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("", 0)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class
