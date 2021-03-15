
'*************************************************************************************************************
' ctl_MerriamKeller - UI for Merriam-Keller irrigation event analyses
'*************************************************************************************************************
Imports System
Imports DataStore
Imports PrintingUI
Imports Srfr.SrfrAPI

Public Class ctl_MerriamKeller
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
    Friend WithEvents ModifiedKostiakovBox As DataStore.ctl_GroupBox
    Friend WithEvents MK_bControl As WinMain.ctl_KostiakovBParameter
    Friend WithEvents MK_aControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MK_kValue As System.Windows.Forms.Label
    Friend WithEvents MK_cControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MK_kLabel As System.Windows.Forms.Label
    Friend WithEvents MK_cLabel As System.Windows.Forms.Label
    Friend WithEvents MK_bLabel As System.Windows.Forms.Label
    Friend WithEvents MK_aLabel As System.Windows.Forms.Label
    Friend WithEvents TR_aValue As System.Windows.Forms.Label
    Friend WithEvents TR_kLabel As System.Windows.Forms.Label
    Friend WithEvents TR_aLabel As System.Windows.Forms.Label
    Friend WithEvents TR_kValue As System.Windows.Forms.Label
    Friend WithEvents EstimateTimeRatedFamily As DataStore.ctl_Button
    Friend WithEvents SelectNrcsFamily As DataStore.ctl_Button
    Friend WithEvents NRCS_Instructions As DataStore.ctl_Label
    Friend WithEvents TR_Instructions As DataStore.ctl_Label
    Friend WithEvents Nrcs_aValue As System.Windows.Forms.Label
    Friend WithEvents Nrcs_cValue As System.Windows.Forms.Label
    Friend WithEvents Nrcs_kLabel As System.Windows.Forms.Label
    Friend WithEvents Nrcs_cLabel As System.Windows.Forms.Label
    Friend WithEvents Nrcs_aLabel As System.Windows.Forms.Label
    Friend WithEvents Nrcs_kValue As System.Windows.Forms.Label
    Friend WithEvents SelectedNrcsInfiltrationFamily As DataStore.ctl_Label
    Friend WithEvents EstimatedTimeRatedFamily As DataStore.ctl_Label
    Friend WithEvents NrcsIntakeFamilyBox As DataStore.ctl_GroupBox
    Friend WithEvents NrcsIntakeFamilyLabel As DataStore.ctl_Label
    Friend WithEvents TimeRatedIntakeFamilyBox As DataStore.ctl_GroupBox
    Friend WithEvents TimeRatedFamilyLabel As DataStore.ctl_Label
    Friend WithEvents CharacteristicTimeBox As DataStore.ctl_GroupBox
    Friend WithEvents KostiakovFunctionBox As DataStore.ctl_GroupBox
    Friend WithEvents BranchFunctionBox As DataStore.ctl_GroupBox
    Friend WithEvents EstimateMK As DataStore.ctl_Button
    Friend WithEvents MK_Description As DataStore.ctl_Label
    Friend WithEvents EstimateKF As DataStore.ctl_Button
    Friend WithEvents KF_Description As DataStore.ctl_Label
    Friend WithEvents KF_kLabel As System.Windows.Forms.Label
    Friend WithEvents KF_aControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KF_aLabel As System.Windows.Forms.Label
    Friend WithEvents KF_kValue As System.Windows.Forms.Label
    Friend WithEvents EstimateKT As DataStore.ctl_Button
    Friend WithEvents KT_Description As DataStore.ctl_Label
    Friend WithEvents KT_kLabel As System.Windows.Forms.Label
    Friend WithEvents KT_aControl As DataStore.ctl_DoubleParameter
    Friend WithEvents KT_aLabel As System.Windows.Forms.Label
    Friend WithEvents KT_kValue As System.Windows.Forms.Label
    Friend WithEvents KT_DepthLabel As DataStore.ctl_Label
    Friend WithEvents KT_DepthValue As DataStore.ctl_Label
    Friend WithEvents KT_TimeValue As DataStore.ctl_Label
    Friend WithEvents KT_TimeLabel As DataStore.ctl_Label
    Friend WithEvents BF_kLabel As System.Windows.Forms.Label
    Friend WithEvents BF_cLabel As System.Windows.Forms.Label
    Friend WithEvents BF_bLabel As System.Windows.Forms.Label
    Friend WithEvents BF_aLabel As System.Windows.Forms.Label
    Friend WithEvents BF_cControl As DataStore.ctl_DoubleParameter
    Friend WithEvents EstimateBF As DataStore.ctl_Button
    Friend WithEvents BF_Description As DataStore.ctl_Label
    Friend WithEvents BF_bControl As WinMain.ctl_KostiakovBParameter
    Friend WithEvents BF_aControl As DataStore.ctl_DoubleParameter
    Friend WithEvents MerriamKellerBox As DataStore.ctl_GroupBox
    Friend WithEvents WettedPerimeterControl As DataStore.ctl_SelectParameter
    Friend WithEvents WettedPerimeterLabel As DataStore.ctl_Label
    Friend WithEvents InfiltrationEquationControl As DataStore.ctl_SelectParameter
    Friend WithEvents InfiltrationEquationLabel As DataStore.ctl_Label
    Friend WithEvents RefInflowPanel As DataStore.ctl_Panel
    Friend WithEvents RefInflowRateControl As DataStore.ctl_DoubleParameter
    Friend WithEvents RefInflowLabel As DataStore.ctl_Label
    Friend WithEvents BF_BranchTimeValue As DataStore.ctl_Label
    Friend WithEvents BF_BranchTimeControl As DataStore.ctl_DoubleParameter
    Friend WithEvents BF_BranchTimeSet As DataStore.ctl_CheckParameter
    Friend WithEvents BF_kValue As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ModifiedKostiakovBox = New DataStore.ctl_GroupBox
        Me.MK_cControl = New DataStore.ctl_DoubleParameter
        Me.EstimateMK = New DataStore.ctl_Button
        Me.MK_Description = New DataStore.ctl_Label
        Me.MK_kLabel = New System.Windows.Forms.Label
        Me.MK_aControl = New DataStore.ctl_DoubleParameter
        Me.MK_cLabel = New System.Windows.Forms.Label
        Me.MK_bLabel = New System.Windows.Forms.Label
        Me.MK_aLabel = New System.Windows.Forms.Label
        Me.MK_kValue = New System.Windows.Forms.Label
        Me.NrcsIntakeFamilyBox = New DataStore.ctl_GroupBox
        Me.SelectedNrcsInfiltrationFamily = New DataStore.ctl_Label
        Me.NrcsIntakeFamilyLabel = New DataStore.ctl_Label
        Me.NRCS_Instructions = New DataStore.ctl_Label
        Me.SelectNrcsFamily = New DataStore.ctl_Button
        Me.Nrcs_aValue = New System.Windows.Forms.Label
        Me.Nrcs_cValue = New System.Windows.Forms.Label
        Me.Nrcs_kLabel = New System.Windows.Forms.Label
        Me.Nrcs_cLabel = New System.Windows.Forms.Label
        Me.Nrcs_aLabel = New System.Windows.Forms.Label
        Me.Nrcs_kValue = New System.Windows.Forms.Label
        Me.TimeRatedIntakeFamilyBox = New DataStore.ctl_GroupBox
        Me.EstimatedTimeRatedFamily = New DataStore.ctl_Label
        Me.TimeRatedFamilyLabel = New DataStore.ctl_Label
        Me.TR_aValue = New System.Windows.Forms.Label
        Me.TR_kLabel = New System.Windows.Forms.Label
        Me.TR_aLabel = New System.Windows.Forms.Label
        Me.TR_kValue = New System.Windows.Forms.Label
        Me.EstimateTimeRatedFamily = New DataStore.ctl_Button
        Me.TR_Instructions = New DataStore.ctl_Label
        Me.CharacteristicTimeBox = New DataStore.ctl_GroupBox
        Me.KT_TimeValue = New DataStore.ctl_Label
        Me.KT_TimeLabel = New DataStore.ctl_Label
        Me.KT_DepthValue = New DataStore.ctl_Label
        Me.KT_DepthLabel = New DataStore.ctl_Label
        Me.EstimateKT = New DataStore.ctl_Button
        Me.KT_Description = New DataStore.ctl_Label
        Me.KT_kLabel = New System.Windows.Forms.Label
        Me.KT_aControl = New DataStore.ctl_DoubleParameter
        Me.KT_aLabel = New System.Windows.Forms.Label
        Me.KT_kValue = New System.Windows.Forms.Label
        Me.KostiakovFunctionBox = New DataStore.ctl_GroupBox
        Me.EstimateKF = New DataStore.ctl_Button
        Me.KF_Description = New DataStore.ctl_Label
        Me.KF_kLabel = New System.Windows.Forms.Label
        Me.KF_aControl = New DataStore.ctl_DoubleParameter
        Me.KF_aLabel = New System.Windows.Forms.Label
        Me.KF_kValue = New System.Windows.Forms.Label
        Me.BranchFunctionBox = New DataStore.ctl_GroupBox
        Me.BF_cControl = New DataStore.ctl_DoubleParameter
        Me.EstimateBF = New DataStore.ctl_Button
        Me.BF_Description = New DataStore.ctl_Label
        Me.BF_kLabel = New System.Windows.Forms.Label
        Me.BF_aControl = New DataStore.ctl_DoubleParameter
        Me.BF_cLabel = New System.Windows.Forms.Label
        Me.BF_bLabel = New System.Windows.Forms.Label
        Me.BF_aLabel = New System.Windows.Forms.Label
        Me.BF_kValue = New System.Windows.Forms.Label
        Me.MerriamKellerBox = New DataStore.ctl_GroupBox
        Me.RefInflowPanel = New DataStore.ctl_Panel
        Me.RefInflowLabel = New DataStore.ctl_Label
        Me.RefInflowRateControl = New DataStore.ctl_DoubleParameter
        Me.InfiltrationEquationControl = New DataStore.ctl_SelectParameter
        Me.InfiltrationEquationLabel = New DataStore.ctl_Label
        Me.WettedPerimeterControl = New DataStore.ctl_SelectParameter
        Me.WettedPerimeterLabel = New DataStore.ctl_Label
        Me.BF_BranchTimeValue = New DataStore.ctl_Label
        Me.BF_BranchTimeControl = New DataStore.ctl_DoubleParameter
        Me.BF_BranchTimeSet = New DataStore.ctl_CheckParameter
        Me.BF_bControl = New WinMain.ctl_KostiakovBParameter
        Me.MK_bControl = New WinMain.ctl_KostiakovBParameter
        Me.ModifiedKostiakovBox.SuspendLayout()
        Me.NrcsIntakeFamilyBox.SuspendLayout()
        Me.TimeRatedIntakeFamilyBox.SuspendLayout()
        Me.CharacteristicTimeBox.SuspendLayout()
        Me.KostiakovFunctionBox.SuspendLayout()
        Me.BranchFunctionBox.SuspendLayout()
        Me.MerriamKellerBox.SuspendLayout()
        Me.RefInflowPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ModifiedKostiakovBox
        '
        Me.ModifiedKostiakovBox.AccessibleDescription = "Estimate the Modified Kostiakov Formula infiltration parameters."
        Me.ModifiedKostiakovBox.AccessibleName = "Modified Kostiakov Formula"
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_cControl)
        Me.ModifiedKostiakovBox.Controls.Add(Me.EstimateMK)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_Description)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_kLabel)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_bControl)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_aControl)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_cLabel)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_bLabel)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_aLabel)
        Me.ModifiedKostiakovBox.Controls.Add(Me.MK_kValue)
        Me.ModifiedKostiakovBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModifiedKostiakovBox.Location = New System.Drawing.Point(6, 185)
        Me.ModifiedKostiakovBox.Name = "ModifiedKostiakovBox"
        Me.ModifiedKostiakovBox.Size = New System.Drawing.Size(358, 213)
        Me.ModifiedKostiakovBox.TabIndex = 10
        Me.ModifiedKostiakovBox.TabStop = False
        Me.ModifiedKostiakovBox.Text = "Parameters"
        '
        'MK_cControl
        '
        Me.MK_cControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_cControl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MK_cControl.IsCalculated = False
        Me.MK_cControl.IsInteger = False
        Me.MK_cControl.Location = New System.Drawing.Point(38, 85)
        Me.MK_cControl.MaxErrMsg = ""
        Me.MK_cControl.MinErrMsg = ""
        Me.MK_cControl.Name = "MK_cControl"
        Me.MK_cControl.Size = New System.Drawing.Size(120, 24)
        Me.MK_cControl.TabIndex = 7
        Me.MK_cControl.ToBeCalculated = True
        Me.MK_cControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_cControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_cControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_cControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_cControl.ValueText = ""
        '
        'EstimateMK
        '
        Me.EstimateMK.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstimateMK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimateMK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstimateMK.Location = New System.Drawing.Point(176, 49)
        Me.EstimateMK.Name = "EstimateMK"
        Me.EstimateMK.Size = New System.Drawing.Size(176, 48)
        Me.EstimateMK.TabIndex = 8
        Me.EstimateMK.Text = "Accept a, b, && c values and &Estimate k"
        Me.EstimateMK.UseVisualStyleBackColor = False
        '
        'MK_Description
        '
        Me.MK_Description.BackColor = System.Drawing.SystemColors.Control
        Me.MK_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_Description.Location = New System.Drawing.Point(8, 165)
        Me.MK_Description.Name = "MK_Description"
        Me.MK_Description.Size = New System.Drawing.Size(344, 40)
        Me.MK_Description.TabIndex = 11
        Me.MK_Description.Text = "Estimate k based on the irrigation's Infiltrated Volume && Opportunity Times and " & _
            "your estimates for a, b, && c."
        '
        'MK_kLabel
        '
        Me.MK_kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_kLabel.Location = New System.Drawing.Point(6, 113)
        Me.MK_kLabel.Name = "MK_kLabel"
        Me.MK_kLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_kLabel.TabIndex = 9
        Me.MK_kLabel.Text = "k"
        Me.MK_kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_aControl
        '
        Me.MK_aControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_aControl.IsCalculated = False
        Me.MK_aControl.IsInteger = False
        Me.MK_aControl.Location = New System.Drawing.Point(38, 33)
        Me.MK_aControl.MaxErrMsg = ""
        Me.MK_aControl.MinErrMsg = ""
        Me.MK_aControl.Name = "MK_aControl"
        Me.MK_aControl.Size = New System.Drawing.Size(120, 24)
        Me.MK_aControl.TabIndex = 3
        Me.MK_aControl.ToBeCalculated = True
        Me.MK_aControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_aControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_aControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_aControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_aControl.ValueText = ""
        '
        'MK_cLabel
        '
        Me.MK_cLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_cLabel.Location = New System.Drawing.Point(6, 85)
        Me.MK_cLabel.Name = "MK_cLabel"
        Me.MK_cLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_cLabel.TabIndex = 6
        Me.MK_cLabel.Text = "&c"
        Me.MK_cLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_bLabel
        '
        Me.MK_bLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_bLabel.Location = New System.Drawing.Point(6, 59)
        Me.MK_bLabel.Name = "MK_bLabel"
        Me.MK_bLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_bLabel.TabIndex = 4
        Me.MK_bLabel.Text = "&b"
        Me.MK_bLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_aLabel
        '
        Me.MK_aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MK_aLabel.Location = New System.Drawing.Point(6, 33)
        Me.MK_aLabel.Name = "MK_aLabel"
        Me.MK_aLabel.Size = New System.Drawing.Size(24, 23)
        Me.MK_aLabel.TabIndex = 2
        Me.MK_aLabel.Text = "&a"
        Me.MK_aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MK_kValue
        '
        Me.MK_kValue.Location = New System.Drawing.Point(38, 113)
        Me.MK_kValue.Name = "MK_kValue"
        Me.MK_kValue.Size = New System.Drawing.Size(120, 23)
        Me.MK_kValue.TabIndex = 10
        Me.MK_kValue.Text = "24.3 mm/hr^a"
        Me.MK_kValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NrcsIntakeFamilyBox
        '
        Me.NrcsIntakeFamilyBox.AccessibleDescription = "Estimate the NRCS Intake Family infiltration parameters."
        Me.NrcsIntakeFamilyBox.AccessibleName = "NRCS Intake Family"
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.SelectedNrcsInfiltrationFamily)
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.NrcsIntakeFamilyLabel)
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.NRCS_Instructions)
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.SelectNrcsFamily)
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.Nrcs_aValue)
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.Nrcs_cValue)
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.Nrcs_kLabel)
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.Nrcs_cLabel)
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.Nrcs_aLabel)
        Me.NrcsIntakeFamilyBox.Controls.Add(Me.Nrcs_kValue)
        Me.NrcsIntakeFamilyBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsIntakeFamilyBox.Location = New System.Drawing.Point(6, 185)
        Me.NrcsIntakeFamilyBox.Name = "NrcsIntakeFamilyBox"
        Me.NrcsIntakeFamilyBox.Size = New System.Drawing.Size(358, 213)
        Me.NrcsIntakeFamilyBox.TabIndex = 10
        Me.NrcsIntakeFamilyBox.TabStop = False
        Me.NrcsIntakeFamilyBox.Text = "Parameters"
        '
        'SelectedNrcsInfiltrationFamily
        '
        Me.SelectedNrcsInfiltrationFamily.Location = New System.Drawing.Point(216, 37)
        Me.SelectedNrcsInfiltrationFamily.Name = "SelectedNrcsInfiltrationFamily"
        Me.SelectedNrcsInfiltrationFamily.Size = New System.Drawing.Size(138, 23)
        Me.SelectedNrcsInfiltrationFamily.TabIndex = 1
        Me.SelectedNrcsInfiltrationFamily.Text = "1.5"
        Me.SelectedNrcsInfiltrationFamily.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NrcsIntakeFamilyLabel
        '
        Me.NrcsIntakeFamilyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsIntakeFamilyLabel.Location = New System.Drawing.Point(6, 37)
        Me.NrcsIntakeFamilyLabel.Name = "NrcsIntakeFamilyLabel"
        Me.NrcsIntakeFamilyLabel.Size = New System.Drawing.Size(202, 23)
        Me.NrcsIntakeFamilyLabel.TabIndex = 0
        Me.NrcsIntakeFamilyLabel.Text = "NRCS Intake Family"
        Me.NrcsIntakeFamilyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NRCS_Instructions
        '
        Me.NRCS_Instructions.BackColor = System.Drawing.SystemColors.Control
        Me.NRCS_Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NRCS_Instructions.Location = New System.Drawing.Point(8, 165)
        Me.NRCS_Instructions.Name = "NRCS_Instructions"
        Me.NRCS_Instructions.Size = New System.Drawing.Size(344, 40)
        Me.NRCS_Instructions.TabIndex = 9
        Me.NRCS_Instructions.Text = "Estimate the NRCS Intake Family based on the irrigation's Infiltrated Volume && O" & _
            "pportunity Times."
        '
        'SelectNrcsFamily
        '
        Me.SelectNrcsFamily.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SelectNrcsFamily.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectNrcsFamily.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.SelectNrcsFamily.Location = New System.Drawing.Point(32, 70)
        Me.SelectNrcsFamily.Name = "SelectNrcsFamily"
        Me.SelectNrcsFamily.Size = New System.Drawing.Size(176, 48)
        Me.SelectNrcsFamily.TabIndex = 2
        Me.SelectNrcsFamily.Text = "&Estimate NRCS Intake Family"
        Me.SelectNrcsFamily.UseVisualStyleBackColor = False
        '
        'Nrcs_aValue
        '
        Me.Nrcs_aValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nrcs_aValue.Location = New System.Drawing.Point(248, 83)
        Me.Nrcs_aValue.Name = "Nrcs_aValue"
        Me.Nrcs_aValue.Size = New System.Drawing.Size(106, 23)
        Me.Nrcs_aValue.TabIndex = 6
        Me.Nrcs_aValue.Text = "0.5"
        Me.Nrcs_aValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Nrcs_cValue
        '
        Me.Nrcs_cValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nrcs_cValue.Location = New System.Drawing.Point(248, 103)
        Me.Nrcs_cValue.Name = "Nrcs_cValue"
        Me.Nrcs_cValue.Size = New System.Drawing.Size(106, 23)
        Me.Nrcs_cValue.TabIndex = 8
        Me.Nrcs_cValue.Text = "7 mm"
        Me.Nrcs_cValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Nrcs_kLabel
        '
        Me.Nrcs_kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nrcs_kLabel.Location = New System.Drawing.Point(216, 63)
        Me.Nrcs_kLabel.Name = "Nrcs_kLabel"
        Me.Nrcs_kLabel.Size = New System.Drawing.Size(24, 23)
        Me.Nrcs_kLabel.TabIndex = 3
        Me.Nrcs_kLabel.Text = "k"
        Me.Nrcs_kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Nrcs_cLabel
        '
        Me.Nrcs_cLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nrcs_cLabel.Location = New System.Drawing.Point(216, 103)
        Me.Nrcs_cLabel.Name = "Nrcs_cLabel"
        Me.Nrcs_cLabel.Size = New System.Drawing.Size(24, 23)
        Me.Nrcs_cLabel.TabIndex = 7
        Me.Nrcs_cLabel.Text = "c"
        Me.Nrcs_cLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Nrcs_aLabel
        '
        Me.Nrcs_aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nrcs_aLabel.Location = New System.Drawing.Point(216, 83)
        Me.Nrcs_aLabel.Name = "Nrcs_aLabel"
        Me.Nrcs_aLabel.Size = New System.Drawing.Size(24, 23)
        Me.Nrcs_aLabel.TabIndex = 5
        Me.Nrcs_aLabel.Text = "a"
        Me.Nrcs_aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Nrcs_kValue
        '
        Me.Nrcs_kValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nrcs_kValue.Location = New System.Drawing.Point(248, 63)
        Me.Nrcs_kValue.Name = "Nrcs_kValue"
        Me.Nrcs_kValue.Size = New System.Drawing.Size(106, 23)
        Me.Nrcs_kValue.TabIndex = 4
        Me.Nrcs_kValue.Text = "24.3 mm/hr^a"
        Me.Nrcs_kValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimeRatedIntakeFamilyBox
        '
        Me.TimeRatedIntakeFamilyBox.AccessibleDescription = "Estimate the Time-Rate Intake Family infiltration parameters."
        Me.TimeRatedIntakeFamilyBox.AccessibleName = "Time-Rate Intake Family"
        Me.TimeRatedIntakeFamilyBox.Controls.Add(Me.EstimatedTimeRatedFamily)
        Me.TimeRatedIntakeFamilyBox.Controls.Add(Me.TimeRatedFamilyLabel)
        Me.TimeRatedIntakeFamilyBox.Controls.Add(Me.TR_aValue)
        Me.TimeRatedIntakeFamilyBox.Controls.Add(Me.TR_kLabel)
        Me.TimeRatedIntakeFamilyBox.Controls.Add(Me.TR_aLabel)
        Me.TimeRatedIntakeFamilyBox.Controls.Add(Me.TR_kValue)
        Me.TimeRatedIntakeFamilyBox.Controls.Add(Me.EstimateTimeRatedFamily)
        Me.TimeRatedIntakeFamilyBox.Controls.Add(Me.TR_Instructions)
        Me.TimeRatedIntakeFamilyBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeRatedIntakeFamilyBox.Location = New System.Drawing.Point(6, 185)
        Me.TimeRatedIntakeFamilyBox.Name = "TimeRatedIntakeFamilyBox"
        Me.TimeRatedIntakeFamilyBox.Size = New System.Drawing.Size(358, 213)
        Me.TimeRatedIntakeFamilyBox.TabIndex = 10
        Me.TimeRatedIntakeFamilyBox.TabStop = False
        Me.TimeRatedIntakeFamilyBox.Text = "Parameters"
        '
        'EstimatedTimeRatedFamily
        '
        Me.EstimatedTimeRatedFamily.Location = New System.Drawing.Point(216, 38)
        Me.EstimatedTimeRatedFamily.Name = "EstimatedTimeRatedFamily"
        Me.EstimatedTimeRatedFamily.Size = New System.Drawing.Size(138, 23)
        Me.EstimatedTimeRatedFamily.TabIndex = 1
        Me.EstimatedTimeRatedFamily.Text = "10.5 hr"
        Me.EstimatedTimeRatedFamily.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimeRatedFamilyLabel
        '
        Me.TimeRatedFamilyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeRatedFamilyLabel.Location = New System.Drawing.Point(6, 38)
        Me.TimeRatedFamilyLabel.Name = "TimeRatedFamilyLabel"
        Me.TimeRatedFamilyLabel.Size = New System.Drawing.Size(202, 23)
        Me.TimeRatedFamilyLabel.TabIndex = 0
        Me.TimeRatedFamilyLabel.Text = "Time-Rated Intake Family"
        Me.TimeRatedFamilyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TR_aValue
        '
        Me.TR_aValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_aValue.Location = New System.Drawing.Point(248, 94)
        Me.TR_aValue.Name = "TR_aValue"
        Me.TR_aValue.Size = New System.Drawing.Size(106, 23)
        Me.TR_aValue.TabIndex = 6
        Me.TR_aValue.Text = "0.5"
        Me.TR_aValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TR_kLabel
        '
        Me.TR_kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_kLabel.Location = New System.Drawing.Point(216, 70)
        Me.TR_kLabel.Name = "TR_kLabel"
        Me.TR_kLabel.Size = New System.Drawing.Size(24, 23)
        Me.TR_kLabel.TabIndex = 3
        Me.TR_kLabel.Text = "k"
        Me.TR_kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TR_aLabel
        '
        Me.TR_aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_aLabel.Location = New System.Drawing.Point(216, 94)
        Me.TR_aLabel.Name = "TR_aLabel"
        Me.TR_aLabel.Size = New System.Drawing.Size(24, 23)
        Me.TR_aLabel.TabIndex = 5
        Me.TR_aLabel.Text = "a"
        Me.TR_aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TR_kValue
        '
        Me.TR_kValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_kValue.Location = New System.Drawing.Point(248, 70)
        Me.TR_kValue.Name = "TR_kValue"
        Me.TR_kValue.Size = New System.Drawing.Size(106, 23)
        Me.TR_kValue.TabIndex = 4
        Me.TR_kValue.Text = "24.3 mm/hr^a"
        Me.TR_kValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EstimateTimeRatedFamily
        '
        Me.EstimateTimeRatedFamily.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstimateTimeRatedFamily.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimateTimeRatedFamily.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstimateTimeRatedFamily.Location = New System.Drawing.Point(32, 70)
        Me.EstimateTimeRatedFamily.Name = "EstimateTimeRatedFamily"
        Me.EstimateTimeRatedFamily.Size = New System.Drawing.Size(176, 48)
        Me.EstimateTimeRatedFamily.TabIndex = 2
        Me.EstimateTimeRatedFamily.Text = "&Estimate Time-Rated Intake Family"
        Me.EstimateTimeRatedFamily.UseVisualStyleBackColor = False
        '
        'TR_Instructions
        '
        Me.TR_Instructions.BackColor = System.Drawing.SystemColors.Control
        Me.TR_Instructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TR_Instructions.Location = New System.Drawing.Point(8, 165)
        Me.TR_Instructions.Name = "TR_Instructions"
        Me.TR_Instructions.Size = New System.Drawing.Size(344, 40)
        Me.TR_Instructions.TabIndex = 10
        Me.TR_Instructions.Text = "Estimate the Time-Rated Intake Family based on the irrigation's Infiltrated Volum" & _
            "e && Opportunity Times."
        '
        'CharacteristicTimeBox
        '
        Me.CharacteristicTimeBox.AccessibleDescription = "Estimate the Characteristic Time infiltration parameters."
        Me.CharacteristicTimeBox.AccessibleName = "Characteristic Time"
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_TimeValue)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_TimeLabel)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_DepthValue)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_DepthLabel)
        Me.CharacteristicTimeBox.Controls.Add(Me.EstimateKT)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_Description)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_kLabel)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_aControl)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_aLabel)
        Me.CharacteristicTimeBox.Controls.Add(Me.KT_kValue)
        Me.CharacteristicTimeBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CharacteristicTimeBox.Location = New System.Drawing.Point(6, 185)
        Me.CharacteristicTimeBox.Name = "CharacteristicTimeBox"
        Me.CharacteristicTimeBox.Size = New System.Drawing.Size(358, 213)
        Me.CharacteristicTimeBox.TabIndex = 10
        Me.CharacteristicTimeBox.TabStop = False
        Me.CharacteristicTimeBox.Text = "Parameters"
        '
        'KT_TimeValue
        '
        Me.KT_TimeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_TimeValue.Location = New System.Drawing.Point(249, 109)
        Me.KT_TimeValue.Name = "KT_TimeValue"
        Me.KT_TimeValue.Size = New System.Drawing.Size(104, 23)
        Me.KT_TimeValue.TabIndex = 9
        Me.KT_TimeValue.Text = "13.57 hr"
        Me.KT_TimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KT_TimeLabel
        '
        Me.KT_TimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_TimeLabel.Location = New System.Drawing.Point(17, 109)
        Me.KT_TimeLabel.Name = "KT_TimeLabel"
        Me.KT_TimeLabel.Size = New System.Drawing.Size(224, 23)
        Me.KT_TimeLabel.TabIndex = 8
        Me.KT_TimeLabel.Text = "Characteristic Infiiltration Time"
        Me.KT_TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KT_DepthValue
        '
        Me.KT_DepthValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_DepthValue.Location = New System.Drawing.Point(249, 87)
        Me.KT_DepthValue.Name = "KT_DepthValue"
        Me.KT_DepthValue.Size = New System.Drawing.Size(104, 23)
        Me.KT_DepthValue.TabIndex = 7
        Me.KT_DepthValue.Text = "100 mm"
        Me.KT_DepthValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KT_DepthLabel
        '
        Me.KT_DepthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_DepthLabel.Location = New System.Drawing.Point(17, 87)
        Me.KT_DepthLabel.Name = "KT_DepthLabel"
        Me.KT_DepthLabel.Size = New System.Drawing.Size(224, 23)
        Me.KT_DepthLabel.TabIndex = 6
        Me.KT_DepthLabel.Text = "Characteristic Infiltration Depth"
        Me.KT_DepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EstimateKT
        '
        Me.EstimateKT.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstimateKT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimateKT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstimateKT.Location = New System.Drawing.Point(176, 31)
        Me.EstimateKT.Name = "EstimateKT"
        Me.EstimateKT.Size = New System.Drawing.Size(178, 48)
        Me.EstimateKT.TabIndex = 5
        Me.EstimateKT.Text = "Accept a and &Estimate k"
        Me.EstimateKT.UseVisualStyleBackColor = False
        '
        'KT_Description
        '
        Me.KT_Description.BackColor = System.Drawing.SystemColors.Control
        Me.KT_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_Description.Location = New System.Drawing.Point(8, 165)
        Me.KT_Description.Name = "KT_Description"
        Me.KT_Description.Size = New System.Drawing.Size(344, 40)
        Me.KT_Description.TabIndex = 10
        Me.KT_Description.Text = "Estimate k based on the irrigation's Infiltrated Volume && Opportunity Times and " & _
            "your estimate for a."
        '
        'KT_kLabel
        '
        Me.KT_kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_kLabel.Location = New System.Drawing.Point(6, 59)
        Me.KT_kLabel.Name = "KT_kLabel"
        Me.KT_kLabel.Size = New System.Drawing.Size(24, 23)
        Me.KT_kLabel.TabIndex = 3
        Me.KT_kLabel.Text = "k"
        Me.KT_kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KT_aControl
        '
        Me.KT_aControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KT_aControl.IsCalculated = False
        Me.KT_aControl.IsInteger = False
        Me.KT_aControl.Location = New System.Drawing.Point(38, 33)
        Me.KT_aControl.MaxErrMsg = ""
        Me.KT_aControl.MinErrMsg = ""
        Me.KT_aControl.Name = "KT_aControl"
        Me.KT_aControl.Size = New System.Drawing.Size(120, 24)
        Me.KT_aControl.TabIndex = 2
        Me.KT_aControl.ToBeCalculated = True
        Me.KT_aControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KT_aControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KT_aControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KT_aControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KT_aControl.ValueText = ""
        '
        'KT_aLabel
        '
        Me.KT_aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KT_aLabel.Location = New System.Drawing.Point(6, 33)
        Me.KT_aLabel.Name = "KT_aLabel"
        Me.KT_aLabel.Size = New System.Drawing.Size(24, 23)
        Me.KT_aLabel.TabIndex = 1
        Me.KT_aLabel.Text = "&a"
        Me.KT_aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KT_kValue
        '
        Me.KT_kValue.Location = New System.Drawing.Point(38, 59)
        Me.KT_kValue.Name = "KT_kValue"
        Me.KT_kValue.Size = New System.Drawing.Size(120, 23)
        Me.KT_kValue.TabIndex = 4
        Me.KT_kValue.Text = "24.3 mm/hr^a"
        Me.KT_kValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KostiakovFunctionBox
        '
        Me.KostiakovFunctionBox.AccessibleDescription = "Estimate the Kostiakov Formula infiltration parameters."
        Me.KostiakovFunctionBox.AccessibleName = "Kostiakov Formula"
        Me.KostiakovFunctionBox.Controls.Add(Me.EstimateKF)
        Me.KostiakovFunctionBox.Controls.Add(Me.KF_Description)
        Me.KostiakovFunctionBox.Controls.Add(Me.KF_kLabel)
        Me.KostiakovFunctionBox.Controls.Add(Me.KF_aControl)
        Me.KostiakovFunctionBox.Controls.Add(Me.KF_aLabel)
        Me.KostiakovFunctionBox.Controls.Add(Me.KF_kValue)
        Me.KostiakovFunctionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostiakovFunctionBox.Location = New System.Drawing.Point(6, 185)
        Me.KostiakovFunctionBox.Name = "KostiakovFunctionBox"
        Me.KostiakovFunctionBox.Size = New System.Drawing.Size(358, 213)
        Me.KostiakovFunctionBox.TabIndex = 10
        Me.KostiakovFunctionBox.TabStop = False
        Me.KostiakovFunctionBox.Text = "Parameters"
        '
        'EstimateKF
        '
        Me.EstimateKF.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstimateKF.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimateKF.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstimateKF.Location = New System.Drawing.Point(176, 49)
        Me.EstimateKF.Name = "EstimateKF"
        Me.EstimateKF.Size = New System.Drawing.Size(176, 48)
        Me.EstimateKF.TabIndex = 4
        Me.EstimateKF.Text = "Accept a and &Estimate k"
        Me.EstimateKF.UseVisualStyleBackColor = False
        '
        'KF_Description
        '
        Me.KF_Description.BackColor = System.Drawing.SystemColors.Control
        Me.KF_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KF_Description.Location = New System.Drawing.Point(8, 165)
        Me.KF_Description.Name = "KF_Description"
        Me.KF_Description.Size = New System.Drawing.Size(344, 40)
        Me.KF_Description.TabIndex = 7
        Me.KF_Description.Text = "Estimate k based on the irrigation's Infiltrated Volume && Opportunity Times and " & _
            "your estimate for a."
        '
        'KF_kLabel
        '
        Me.KF_kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KF_kLabel.Location = New System.Drawing.Point(6, 75)
        Me.KF_kLabel.Name = "KF_kLabel"
        Me.KF_kLabel.Size = New System.Drawing.Size(24, 23)
        Me.KF_kLabel.TabIndex = 5
        Me.KF_kLabel.Text = "k"
        Me.KF_kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KF_aControl
        '
        Me.KF_aControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.KF_aControl.IsCalculated = False
        Me.KF_aControl.IsInteger = False
        Me.KF_aControl.Location = New System.Drawing.Point(38, 51)
        Me.KF_aControl.MaxErrMsg = ""
        Me.KF_aControl.MinErrMsg = ""
        Me.KF_aControl.Name = "KF_aControl"
        Me.KF_aControl.Size = New System.Drawing.Size(120, 24)
        Me.KF_aControl.TabIndex = 3
        Me.KF_aControl.ToBeCalculated = True
        Me.KF_aControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.KF_aControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.KF_aControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.KF_aControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.KF_aControl.ValueText = ""
        '
        'KF_aLabel
        '
        Me.KF_aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KF_aLabel.Location = New System.Drawing.Point(6, 51)
        Me.KF_aLabel.Name = "KF_aLabel"
        Me.KF_aLabel.Size = New System.Drawing.Size(24, 23)
        Me.KF_aLabel.TabIndex = 2
        Me.KF_aLabel.Text = "&a"
        Me.KF_aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KF_kValue
        '
        Me.KF_kValue.Location = New System.Drawing.Point(38, 75)
        Me.KF_kValue.Name = "KF_kValue"
        Me.KF_kValue.Size = New System.Drawing.Size(120, 23)
        Me.KF_kValue.TabIndex = 6
        Me.KF_kValue.Text = "24.3 mm/hr^a"
        Me.KF_kValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BranchFunctionBox
        '
        Me.BranchFunctionBox.AccessibleDescription = "Estimate the Branch Function infiltration parameters."
        Me.BranchFunctionBox.AccessibleName = "Branch Function"
        Me.BranchFunctionBox.Controls.Add(Me.BF_BranchTimeValue)
        Me.BranchFunctionBox.Controls.Add(Me.BF_BranchTimeControl)
        Me.BranchFunctionBox.Controls.Add(Me.BF_BranchTimeSet)
        Me.BranchFunctionBox.Controls.Add(Me.BF_cControl)
        Me.BranchFunctionBox.Controls.Add(Me.EstimateBF)
        Me.BranchFunctionBox.Controls.Add(Me.BF_Description)
        Me.BranchFunctionBox.Controls.Add(Me.BF_kLabel)
        Me.BranchFunctionBox.Controls.Add(Me.BF_bControl)
        Me.BranchFunctionBox.Controls.Add(Me.BF_aControl)
        Me.BranchFunctionBox.Controls.Add(Me.BF_cLabel)
        Me.BranchFunctionBox.Controls.Add(Me.BF_bLabel)
        Me.BranchFunctionBox.Controls.Add(Me.BF_aLabel)
        Me.BranchFunctionBox.Controls.Add(Me.BF_kValue)
        Me.BranchFunctionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BranchFunctionBox.Location = New System.Drawing.Point(6, 185)
        Me.BranchFunctionBox.Name = "BranchFunctionBox"
        Me.BranchFunctionBox.Size = New System.Drawing.Size(358, 213)
        Me.BranchFunctionBox.TabIndex = 10
        Me.BranchFunctionBox.TabStop = False
        Me.BranchFunctionBox.Text = "Parameters"
        '
        'BF_cControl
        '
        Me.BF_cControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_cControl.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BF_cControl.IsCalculated = False
        Me.BF_cControl.IsInteger = False
        Me.BF_cControl.Location = New System.Drawing.Point(38, 85)
        Me.BF_cControl.MaxErrMsg = ""
        Me.BF_cControl.MinErrMsg = ""
        Me.BF_cControl.Name = "BF_cControl"
        Me.BF_cControl.Size = New System.Drawing.Size(120, 24)
        Me.BF_cControl.TabIndex = 7
        Me.BF_cControl.ToBeCalculated = True
        Me.BF_cControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_cControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_cControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_cControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_cControl.ValueText = ""
        '
        'EstimateBF
        '
        Me.EstimateBF.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstimateBF.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimateBF.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstimateBF.Location = New System.Drawing.Point(176, 49)
        Me.EstimateBF.Name = "EstimateBF"
        Me.EstimateBF.Size = New System.Drawing.Size(176, 48)
        Me.EstimateBF.TabIndex = 8
        Me.EstimateBF.Text = "Accept a, b, && c values and &Estimate k"
        Me.EstimateBF.UseVisualStyleBackColor = False
        '
        'BF_Description
        '
        Me.BF_Description.BackColor = System.Drawing.SystemColors.Control
        Me.BF_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_Description.Location = New System.Drawing.Point(8, 165)
        Me.BF_Description.Name = "BF_Description"
        Me.BF_Description.Size = New System.Drawing.Size(344, 40)
        Me.BF_Description.TabIndex = 12
        Me.BF_Description.Text = "Estimate k based on the irrigation's Infiltrated Volume && Opportunity Times and " & _
            "your estimates for a, b, && c."
        '
        'BF_kLabel
        '
        Me.BF_kLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_kLabel.Location = New System.Drawing.Point(6, 138)
        Me.BF_kLabel.Name = "BF_kLabel"
        Me.BF_kLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_kLabel.TabIndex = 9
        Me.BF_kLabel.Text = "k"
        Me.BF_kLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_aControl
        '
        Me.BF_aControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_aControl.IsCalculated = False
        Me.BF_aControl.IsInteger = False
        Me.BF_aControl.Location = New System.Drawing.Point(38, 33)
        Me.BF_aControl.MaxErrMsg = ""
        Me.BF_aControl.MinErrMsg = ""
        Me.BF_aControl.Name = "BF_aControl"
        Me.BF_aControl.Size = New System.Drawing.Size(120, 24)
        Me.BF_aControl.TabIndex = 3
        Me.BF_aControl.ToBeCalculated = True
        Me.BF_aControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_aControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_aControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_aControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_aControl.ValueText = ""
        '
        'BF_cLabel
        '
        Me.BF_cLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_cLabel.Location = New System.Drawing.Point(6, 85)
        Me.BF_cLabel.Name = "BF_cLabel"
        Me.BF_cLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_cLabel.TabIndex = 6
        Me.BF_cLabel.Text = "&c"
        Me.BF_cLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_bLabel
        '
        Me.BF_bLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_bLabel.Location = New System.Drawing.Point(6, 59)
        Me.BF_bLabel.Name = "BF_bLabel"
        Me.BF_bLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_bLabel.TabIndex = 4
        Me.BF_bLabel.Text = "&b"
        Me.BF_bLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_aLabel
        '
        Me.BF_aLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_aLabel.Location = New System.Drawing.Point(6, 33)
        Me.BF_aLabel.Name = "BF_aLabel"
        Me.BF_aLabel.Size = New System.Drawing.Size(24, 23)
        Me.BF_aLabel.TabIndex = 2
        Me.BF_aLabel.Text = "&a"
        Me.BF_aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_kValue
        '
        Me.BF_kValue.Location = New System.Drawing.Point(38, 138)
        Me.BF_kValue.Name = "BF_kValue"
        Me.BF_kValue.Size = New System.Drawing.Size(120, 23)
        Me.BF_kValue.TabIndex = 10
        Me.BF_kValue.Text = "24.3 mm/hr^a"
        Me.BF_kValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MerriamKellerBox
        '
        Me.MerriamKellerBox.AccessibleDescription = "Evaluate the performance of an irrigation to determine the field's infiltration c" & _
            "haracteristics."
        Me.MerriamKellerBox.AccessibleName = "Merriam-Keller Solution"
        Me.MerriamKellerBox.Controls.Add(Me.RefInflowPanel)
        Me.MerriamKellerBox.Controls.Add(Me.InfiltrationEquationControl)
        Me.MerriamKellerBox.Controls.Add(Me.InfiltrationEquationLabel)
        Me.MerriamKellerBox.Controls.Add(Me.WettedPerimeterControl)
        Me.MerriamKellerBox.Controls.Add(Me.WettedPerimeterLabel)
        Me.MerriamKellerBox.Controls.Add(Me.BranchFunctionBox)
        Me.MerriamKellerBox.Controls.Add(Me.ModifiedKostiakovBox)
        Me.MerriamKellerBox.Controls.Add(Me.KostiakovFunctionBox)
        Me.MerriamKellerBox.Controls.Add(Me.TimeRatedIntakeFamilyBox)
        Me.MerriamKellerBox.Controls.Add(Me.NrcsIntakeFamilyBox)
        Me.MerriamKellerBox.Controls.Add(Me.CharacteristicTimeBox)
        Me.MerriamKellerBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MerriamKellerBox.Location = New System.Drawing.Point(4, 4)
        Me.MerriamKellerBox.Name = "MerriamKellerBox"
        Me.MerriamKellerBox.Size = New System.Drawing.Size(370, 410)
        Me.MerriamKellerBox.TabIndex = 0
        Me.MerriamKellerBox.TabStop = False
        Me.MerriamKellerBox.Text = "Infiltration Function"
        '
        'RefInflowPanel
        '
        Me.RefInflowPanel.AccessibleDescription = ""
        Me.RefInflowPanel.AccessibleName = ""
        Me.RefInflowPanel.Controls.Add(Me.RefInflowLabel)
        Me.RefInflowPanel.Controls.Add(Me.RefInflowRateControl)
        Me.RefInflowPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowPanel.Location = New System.Drawing.Point(9, 86)
        Me.RefInflowPanel.Name = "RefInflowPanel"
        Me.RefInflowPanel.Size = New System.Drawing.Size(351, 30)
        Me.RefInflowPanel.TabIndex = 6
        '
        'RefInflowLabel
        '
        Me.RefInflowLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowLabel.Location = New System.Drawing.Point(2, 3)
        Me.RefInflowLabel.Name = "RefInflowLabel"
        Me.RefInflowLabel.Size = New System.Drawing.Size(238, 23)
        Me.RefInflowLabel.TabIndex = 1
        Me.RefInflowLabel.Text = "&Reference Inflow Rate"
        Me.RefInflowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RefInflowRateControl
        '
        Me.RefInflowRateControl.AccessibleDescription = "Specifies the reference inflow rate."
        Me.RefInflowRateControl.AccessibleName = "Reference Inflow Rate"
        Me.RefInflowRateControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.RefInflowRateControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefInflowRateControl.IsCalculated = False
        Me.RefInflowRateControl.IsInteger = False
        Me.RefInflowRateControl.Location = New System.Drawing.Point(246, 3)
        Me.RefInflowRateControl.MaxErrMsg = ""
        Me.RefInflowRateControl.MinErrMsg = ""
        Me.RefInflowRateControl.Name = "RefInflowRateControl"
        Me.RefInflowRateControl.Size = New System.Drawing.Size(102, 24)
        Me.RefInflowRateControl.TabIndex = 2
        Me.RefInflowRateControl.ToBeCalculated = True
        Me.RefInflowRateControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.RefInflowRateControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.RefInflowRateControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.RefInflowRateControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.RefInflowRateControl.ValueText = ""
        '
        'InfiltrationEquationControl
        '
        Me.InfiltrationEquationControl.AccessibleDescription = "Selects the Infiltration Function for entering the infiltration parameters.  The " & _
            "Dialogs tab under User Preferences controls operation when a new method is selec" & _
            "ted."
        Me.InfiltrationEquationControl.AccessibleName = "Infiltration Function"
        Me.InfiltrationEquationControl.ApplicationValue = -1
        Me.InfiltrationEquationControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InfiltrationEquationControl.EnableSaveActions = False
        Me.InfiltrationEquationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationEquationControl.IsCalculated = False
        Me.InfiltrationEquationControl.Location = New System.Drawing.Point(140, 54)
        Me.InfiltrationEquationControl.Name = "InfiltrationEquationControl"
        Me.InfiltrationEquationControl.SelectedIndexSet = False
        Me.InfiltrationEquationControl.Size = New System.Drawing.Size(224, 24)
        Me.InfiltrationEquationControl.TabIndex = 4
        '
        'InfiltrationEquationLabel
        '
        Me.InfiltrationEquationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationEquationLabel.Location = New System.Drawing.Point(6, 54)
        Me.InfiltrationEquationLabel.Name = "InfiltrationEquationLabel"
        Me.InfiltrationEquationLabel.Size = New System.Drawing.Size(131, 23)
        Me.InfiltrationEquationLabel.TabIndex = 3
        Me.InfiltrationEquationLabel.Text = "&Infiltration Equation"
        Me.InfiltrationEquationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WettedPerimeterControl
        '
        Me.WettedPerimeterControl.AccessibleDescription = "Selects the method for describing the wetted perimeter."
        Me.WettedPerimeterControl.AccessibleName = "Wetted Perimeter"
        Me.WettedPerimeterControl.ApplicationValue = -1
        Me.WettedPerimeterControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WettedPerimeterControl.EnableSaveActions = True
        Me.WettedPerimeterControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WettedPerimeterControl.IsCalculated = False
        Me.WettedPerimeterControl.Location = New System.Drawing.Point(140, 25)
        Me.WettedPerimeterControl.Name = "WettedPerimeterControl"
        Me.WettedPerimeterControl.SelectedIndexSet = False
        Me.WettedPerimeterControl.Size = New System.Drawing.Size(224, 24)
        Me.WettedPerimeterControl.TabIndex = 2
        '
        'WettedPerimeterLabel
        '
        Me.WettedPerimeterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WettedPerimeterLabel.Location = New System.Drawing.Point(6, 25)
        Me.WettedPerimeterLabel.Name = "WettedPerimeterLabel"
        Me.WettedPerimeterLabel.Size = New System.Drawing.Size(131, 23)
        Me.WettedPerimeterLabel.TabIndex = 1
        Me.WettedPerimeterLabel.Text = "&Wetted Perimeter"
        Me.WettedPerimeterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BF_BranchTimeValue
        '
        Me.BF_BranchTimeValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BF_BranchTimeValue.Location = New System.Drawing.Point(145, 110)
        Me.BF_BranchTimeValue.Name = "BF_BranchTimeValue"
        Me.BF_BranchTimeValue.Size = New System.Drawing.Size(128, 24)
        Me.BF_BranchTimeValue.TabIndex = 14
        Me.BF_BranchTimeValue.Text = "Tb"
        Me.BF_BranchTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BF_BranchTimeControl
        '
        Me.BF_BranchTimeControl.AccessibleDescription = "Time at which the Branch Function switches from the 'k^a+c' term to the 'b' term." & _
            ""
        Me.BF_BranchTimeControl.AccessibleName = "Branch Time"
        Me.BF_BranchTimeControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_BranchTimeControl.IsCalculated = False
        Me.BF_BranchTimeControl.IsInteger = False
        Me.BF_BranchTimeControl.Location = New System.Drawing.Point(145, 110)
        Me.BF_BranchTimeControl.MaxErrMsg = ""
        Me.BF_BranchTimeControl.MinErrMsg = ""
        Me.BF_BranchTimeControl.Name = "BF_BranchTimeControl"
        Me.BF_BranchTimeControl.Size = New System.Drawing.Size(128, 24)
        Me.BF_BranchTimeControl.TabIndex = 15
        Me.BF_BranchTimeControl.ToBeCalculated = True
        Me.BF_BranchTimeControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_BranchTimeControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_BranchTimeControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_BranchTimeControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_BranchTimeControl.ValueText = ""
        '
        'BF_BranchTimeSet
        '
        Me.BF_BranchTimeSet.AccessibleDescription = "Selects whether the Branch Time is entered by the user or calculated by WinSRFR."
        Me.BF_BranchTimeSet.AccessibleName = "Branch Time Select"
        Me.BF_BranchTimeSet.AlwaysChecked = False
        Me.BF_BranchTimeSet.ErrorMessage = Nothing
        Me.BF_BranchTimeSet.Location = New System.Drawing.Point(13, 112)
        Me.BF_BranchTimeSet.Name = "BF_BranchTimeSet"
        Me.BF_BranchTimeSet.Size = New System.Drawing.Size(131, 23)
        Me.BF_BranchTimeSet.TabIndex = 13
        Me.BF_BranchTimeSet.Text = "Branch &Time"
        Me.BF_BranchTimeSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BF_BranchTimeSet.UncheckAttemptMessage = Nothing
        Me.BF_BranchTimeSet.UseVisualStyleBackColor = True
        '
        'BF_bControl
        '
        Me.BF_bControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.BF_bControl.IsCalculated = False
        Me.BF_bControl.IsInteger = False
        Me.BF_bControl.Location = New System.Drawing.Point(38, 59)
        Me.BF_bControl.MaxErrMsg = ""
        Me.BF_bControl.MinErrMsg = ""
        Me.BF_bControl.Name = "BF_bControl"
        Me.BF_bControl.Size = New System.Drawing.Size(120, 24)
        Me.BF_bControl.TabIndex = 5
        Me.BF_bControl.ToBeCalculated = True
        Me.BF_bControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.BF_bControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.BF_bControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.BF_bControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.BF_bControl.ValueText = ""
        '
        'MK_bControl
        '
        Me.MK_bControl.AltUnits = DataStore.UnitsDefinition.Units.None
        Me.MK_bControl.IsCalculated = False
        Me.MK_bControl.IsInteger = False
        Me.MK_bControl.Location = New System.Drawing.Point(38, 59)
        Me.MK_bControl.MaxErrMsg = ""
        Me.MK_bControl.MinErrMsg = ""
        Me.MK_bControl.Name = "MK_bControl"
        Me.MK_bControl.Size = New System.Drawing.Size(120, 24)
        Me.MK_bControl.TabIndex = 5
        Me.MK_bControl.ToBeCalculated = True
        Me.MK_bControl.UnitsBackColor = System.Drawing.SystemColors.Control
        Me.MK_bControl.UnitsForeColor = System.Drawing.SystemColors.ControlText
        Me.MK_bControl.ValueBackColor = System.Drawing.SystemColors.Window
        Me.MK_bControl.ValueForeColor = System.Drawing.SystemColors.WindowText
        Me.MK_bControl.ValueText = ""
        '
        'ctl_MerriamKeller
        '
        Me.Controls.Add(Me.MerriamKellerBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_MerriamKeller"
        Me.Size = New System.Drawing.Size(379, 420)
        Me.ModifiedKostiakovBox.ResumeLayout(False)
        Me.NrcsIntakeFamilyBox.ResumeLayout(False)
        Me.TimeRatedIntakeFamilyBox.ResumeLayout(False)
        Me.CharacteristicTimeBox.ResumeLayout(False)
        Me.KostiakovFunctionBox.ResumeLayout(False)
        Me.BranchFunctionBox.ResumeLayout(False)
        Me.MerriamKellerBox.ResumeLayout(False)
        Me.RefInflowPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "
    '
    ' Access to Merriam-Keller Analysis
    '
    Private mMerriamKeller As MerriamKeller
    Private mCalculating As Boolean = False
    '
    ' Access to DataStore
    '
    Private mUnit As Unit
    Private mWorld As World = Nothing
    Private mField As Field = Nothing
    Private mFarm As Farm = Nothing
    Private mWinSRFR As WinSRFR = Nothing
    Private mMyStore As DataStore.ObjectNode

    Private WithEvents mEventCriteria As EventCriteria
    Private WithEvents mSrfrCriteria As SrfrCriteria
    Private WithEvents mSystemGeometry As SystemGeometry
    Private WithEvents mInflowManagement As InflowManagement
    Private WithEvents mSoilCropProperties As SoilCropProperties
    Private WithEvents mUnitControl As UnitControl

    Private mDictionary As Dictionary = Dictionary.Instance
    '
    ' Access to UI
    '
    Private mWorldWindow As WorldWindow
    '
    ' Merriam-Keller data
    '
    Private mInitializing As Boolean = False

#End Region

#Region " Properties "

    Private mResultsAreValid As Boolean
    Public ReadOnly Property ResultsAreValid() As Boolean
        Get
            Return mResultsAreValid
        End Get
    End Property

#End Region

#Region " Control / Model Linkage "

    Public Sub LinkToModel(ByVal unit As Unit, ByVal worldWindow As WorldWindow, _
                           ByVal merriamKeller As MerriamKeller)

        If (unit IsNot Nothing) Then

            mInitializing = True

            ' Save input references
            mUnit = unit
            mWorld = mUnit.WorldRef
            mField = mWorld.FieldRef
            mFarm = mField.FarmRef
            mWinSRFR = mFarm.WinSrfrRef
            mMyStore = mUnit.MyStore

            mEventCriteria = mUnit.EventCriteriaRef
            mSrfrCriteria = mUnit.SrfrCriteriaRef
            mSystemGeometry = mUnit.SystemGeometryRef
            mInflowManagement = mUnit.InflowManagementRef
            mSoilCropProperties = mUnit.SoilCropPropertiesRef
            mUnitControl = mUnit.UnitControlRef

            mWorldWindow = worldWindow
            mMerriamKeller = merriamKeller

            ' Link the contained controls to their models & store
            WettedPerimeterControl.LinkToModel(mMyStore, mSoilCropProperties.WettedPerimeterMethodProperty)
            InfiltrationEquationControl.LinkToModel(mMyStore, mSoilCropProperties.InfiltrationFunctionProperty)

            Me.RefInflowRateControl.LinkToModel(mMyStore, mEventCriteria.ReferenceFlowRateProperty)

            Me.KT_aControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_KTProperty)

            Me.KF_aControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_KFProperty)

            Me.MK_aControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_MKProperty)
            Me.MK_bControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovB_MKProperty)
            Me.MK_cControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovC_MKProperty)

            Me.BF_aControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovA_BFProperty)
            Me.BF_bControl.LinkToModel(mMyStore, mSoilCropProperties.BranchB_BFProperty)
            Me.BF_cControl.LinkToModel(mMyStore, mSoilCropProperties.KostiakovC_BFProperty)
            Me.BF_BranchTimeSet.LinkToModel(mMyStore, mSoilCropProperties.BranchTimeSetProperty)
            Me.BF_BranchTimeControl.LinkToModel(mMyStore, mSoilCropProperties.BranchTime_BFProperty)

            mInitializing = False

        End If

        UpdateUI()

    End Sub

#End Region

#Region " UI Update Methods "

    Public Sub UpdateUI()
        If (CtrlNotVisible(Me)) Then ' Control is not visible; don't update it
            Return
        End If

        If (mMerriamKeller Is Nothing) Then
            Return
        End If

        Dim _eventType As EventAnalysisTypes = mEventCriteria.EventAnalysisType.Value
        If Not (_eventType = EventAnalysisTypes.MerriamKellerAnalysis) Then
            Return
        End If
        If (mInitializing) Then
            Return
        End If
        '
        ' Update Wetted Perimeter & Infiltration Equation controls
        '
        UpdateWettedPerimeterMethod()   ' WP now 1st
        UpdateInfiltrationEquation()    ' IE 2nd
        '
        ' Get the selected Merriam-Keller Option
        '
        Dim _infiltrationFunction As InfiltrationFunctions = _
            CType(mSoilCropProperties.InfiltrationFunction.Value, InfiltrationFunctions)

        ' Hide all options to start
        Me.NrcsIntakeFamilyBox.Hide()
        Me.TimeRatedIntakeFamilyBox.Hide()
        Me.CharacteristicTimeBox.Hide()
        Me.KostiakovFunctionBox.Hide()
        Me.ModifiedKostiakovBox.Hide()
        Me.BranchFunctionBox.Hide()

        ' Update UI to match selected option
        Select Case (_infiltrationFunction)

            Case InfiltrationFunctions.NRCSIntakeFamily

                Me.NrcsIntakeFamilyBox.Show()
                UpdateNrcsIntakeFamily()
                Me.NrcsIntakeFamilyBox.Refresh()

            Case InfiltrationFunctions.TimeRatedIntakeFamily

                Me.TimeRatedIntakeFamilyBox.Show()
                UpdateTimeRatedInfiltrationFamily()
                Me.TimeRatedIntakeFamilyBox.Refresh()

            Case InfiltrationFunctions.CharacteristicInfiltrationTime

                Me.CharacteristicTimeBox.Show()
                UpdateCharacteristicTime()
                Me.CharacteristicTimeBox.Refresh()

            Case InfiltrationFunctions.KostiakovFormula

                Me.KostiakovFunctionBox.Show()
                UpdateKostiakovFunction()
                Me.KostiakovFunctionBox.Refresh()

            Case InfiltrationFunctions.ModifiedKostiakovFormula

                Me.ModifiedKostiakovBox.Show()
                UpdateModifiedKostiakov()
                Me.ModifiedKostiakovBox.Refresh()

            Case InfiltrationFunctions.BranchFunction

                Me.BranchFunctionBox.Show()
                UpdateBranchFunction()
                Me.BranchFunctionBox.Refresh()

                If (mSoilCropProperties.BranchTimeSet.Value) Then ' Branch Time is set by user
                    Me.BF_BranchTimeValue.Hide()
                    Me.BF_BranchTimeControl.Show()
                Else ' Branch Time is calculated
                    Me.BF_BranchTimeControl.Hide()
                    Dim bt As Double = mSoilCropProperties.BranchTime
                    Me.BF_BranchTimeValue.Text = DataStore.TimeString(bt)
                    Me.BF_BranchTimeValue.Show()
                End If

        End Select

        ' Reference Inflow is a Research level option
        If (WinSRFR.UserLevel = UserLevels.Research) Then
            RefInflowPanel.Show()
        Else
            RefInflowPanel.Hide()
        End If

    End Sub

    Private Function MerriamKellerCanBeExecuted() As Boolean
        MerriamKellerCanBeExecuted = False
        If (mMerriamKeller IsNot Nothing) Then
            If (mSystemGeometry.DownstreamCondition.Value = DownstreamConditions.OpenEnd) Then
                If (mInflowManagement.InflowDataAvailable And mInflowManagement.RunoffDataAvailable) Then
                    MerriamKellerCanBeExecuted = True
                End If
            Else ' Blocked-End
                If (mInflowManagement.InflowDataAvailable) Then
                    MerriamKellerCanBeExecuted = True
                End If
            End If
        End If
    End Function
    '
    ' Update display of Wetted Perimeter Method
    '
    Private Sub UpdateWettedPerimeterMethod()

        If (mMerriamKeller IsNot Nothing) Then

            ' Wetted Perimeter only applies to Furrows
            If (mSystemGeometry.CrossSection.Value = CrossSections.Furrow) Then

                mMerriamKeller.LoadWettedPerimeterControl(WettedPerimeterControl)

                WettedPerimeterLabel.Show()
                WettedPerimeterControl.UpdateUI()
                WettedPerimeterControl.Show()

            Else ' Basin / Border

                Me.WettedPerimeterLabel.Hide()
                Me.WettedPerimeterControl.Hide()

            End If
        End If

    End Sub
    '
    ' Update the Infiltration Equation selection list & selection
    '
    Private Sub UpdateInfiltrationEquation()

        If (mMerriamKeller IsNot Nothing) Then
            mMerriamKeller.LoadInfiltrationEquationControl(InfiltrationEquationControl)
            InfiltrationEquationControl.UpdateUI()
        End If

    End Sub

    Private Sub UpdateNrcsIntakeFamily()

        If (mMerriamKeller IsNot Nothing) Then

            Dim nrcsChanged As DateTime = mSoilCropProperties.Infiltration.Timestamp

            If ((mUnit.DataHasChangedSince(nrcsChanged)) _
            And (Not mUnit.ResultsAreValid)) Then
                mResultsAreValid = False

                ' Display/Enable the 'Select' button if any dependant value has changed
                Me.SelectNrcsFamily.Visible = True
                Me.SelectNrcsFamily.Enabled = Me.MerriamKellerCanBeExecuted

                ' Display all values as 'errored'
                Me.SelectedNrcsInfiltrationFamily.Text = String.Empty
                Me.SelectedNrcsInfiltrationFamily.BackColor = DataStore.Globals.BackColor_Errored

                Me.Nrcs_kValue.Text = String.Empty
                Me.Nrcs_kValue.BackColor = DataStore.Globals.BackColor_Errored

                Me.Nrcs_aValue.Text = String.Empty
                Me.Nrcs_aValue.BackColor = DataStore.Globals.BackColor_Errored

                Me.Nrcs_cValue.Text = String.Empty
                Me.Nrcs_cValue.BackColor = DataStore.Globals.BackColor_Errored
            Else
                mResultsAreValid = True

                ' Hide the 'Select' button
                Me.SelectNrcsFamily.Visible = False

                ' Display selected NRCS Intake Family
                Dim family As NrcsIntakeValues = NrcsIntakeValuesTable(mSoilCropProperties.NrcsIntakeFamily.Value)
                Dim name As String = family.Name

                Me.SelectedNrcsInfiltrationFamily.Text = name
                Me.SelectedNrcsInfiltrationFamily.BackColor = SystemColors.Control

                ' Display corresponding k, a & c
                Dim k As Double = mSoilCropProperties.KostiakovK
                Dim a As Double = mSoilCropProperties.KostiakovA
                Dim c As Double = mSoilCropProperties.KostiakovC

                Dim kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
                Me.Nrcs_kValue.Text = KostiakovKParameter.KostiakovKString(k, a, kunits, 0)
                Me.Nrcs_kValue.BackColor = SystemColors.Control

                Me.Nrcs_aValue.Text = Format(a, "0.00#")
                Me.Nrcs_aValue.BackColor = SystemColors.Control

                Me.Nrcs_cValue.Text = DepthString(c, 0)
                Me.Nrcs_cValue.BackColor = SystemColors.Control
            End If
        End If

    End Sub

    Private Sub UpdateTimeRatedInfiltrationFamily()

        If (mMerriamKeller IsNot Nothing) Then

            Dim timeRatedChanged As DateTime = mSoilCropProperties.Infiltration.Timestamp

            If ((mUnit.DataHasChangedSince(timeRatedChanged)) _
            And (Not mUnit.ResultsAreValid)) Then
                mResultsAreValid = False

                ' Display the 'Estimate' button if any dependant value has changed
                Me.EstimateTimeRatedFamily.Visible = True
                Me.EstimateTimeRatedFamily.Enabled = Me.MerriamKellerCanBeExecuted

                ' Display all values as 'errored'
                Me.EstimatedTimeRatedFamily.Text = String.Empty
                Me.EstimatedTimeRatedFamily.BackColor = DataStore.Globals.BackColor_Errored

                Me.TR_kValue.Text = String.Empty
                Me.TR_kValue.BackColor = DataStore.Globals.BackColor_Errored

                Me.TR_aValue.Text = String.Empty
                Me.TR_aValue.BackColor = DataStore.Globals.BackColor_Errored
            Else
                mResultsAreValid = True

                ' Hide the 'Estimate' button
                Me.EstimateTimeRatedFamily.Visible = False

                ' Display estimated Time-Rated Intake Family
                Dim time As Double = mSoilCropProperties.InfiltrationTime_TR.Value

                Me.EstimatedTimeRatedFamily.Text = mSoilCropProperties.InfiltrationTime_TR.ValueString
                Me.EstimatedTimeRatedFamily.BackColor = SystemColors.Control

                ' Display corresponding k & a
                Dim k As Double = mSoilCropProperties.KostiakovK
                Dim a As Double = mSoilCropProperties.KostiakovA

                Dim kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits
                Me.TR_kValue.Text = KostiakovKParameter.KostiakovKString(k, a, kunits, 0)
                Me.TR_kValue.BackColor = SystemColors.Control

                Me.TR_aValue.Text = Format(a, "0.00#")
                Me.TR_aValue.BackColor = SystemColors.Control
            End If
        End If

    End Sub

    Private Sub UpdateCharacteristicTime()

        If (mMerriamKeller IsNot Nothing) Then

            Dim kChangedTime As DateTime = mSoilCropProperties.Infiltration.Timestamp

            If ((mUnit.DataHasChangedSince(kChangedTime)) _
            And (Not mUnit.ResultsAreValid)) Then
                mResultsAreValid = False

                ' Display the 'Estimate' button if any dependant value has changed
                Me.EstimateKT.Visible = True
                Me.EstimateKT.Enabled = Me.MerriamKellerCanBeExecuted

                Me.KT_kValue.Text = String.Empty
                Me.KT_kValue.BackColor = DataStore.Globals.BackColor_Errored

                Me.KT_DepthValue.Text = String.Empty
                Me.KT_DepthValue.BackColor = DataStore.Globals.BackColor_Errored

                Me.KT_TimeValue.Text = String.Empty
                Me.KT_TimeValue.BackColor = DataStore.Globals.BackColor_Errored
            Else
                mResultsAreValid = True

                ' Display the 'Estimate' button if all calculated values are default
                If (mSoilCropProperties.KostiakovA_KT.Source = ValueSources.Defaulted) Then
                    Me.EstimateKT.Visible = True

                    Me.KT_kValue.Text = String.Empty
                    Me.KT_kValue.BackColor = DataStore.Globals.BackColor_Errored

                    Me.KT_DepthValue.Text = String.Empty
                    Me.KT_DepthValue.BackColor = DataStore.Globals.BackColor_Errored

                    Me.KT_TimeValue.Text = String.Empty
                    Me.KT_TimeValue.BackColor = DataStore.Globals.BackColor_Errored
                Else
                    ' Hide the 'Estimate' button
                    Me.EstimateKT.Visible = False

                    ' Display Characteristic Depth & Time
                    Dim _depth As DoubleParameter = mSoilCropProperties.InfiltrationDepth_KT
                    Me.KT_DepthValue.Text = _depth.ValueString
                    Me.KT_DepthValue.BackColor = SystemColors.Control

                    Dim _time As DoubleParameter = mSoilCropProperties.InfiltrationTime_KT
                    Me.KT_TimeValue.Text = _time.ValueString
                    Me.KT_TimeValue.BackColor = SystemColors.Control

                    ' Display Kostiakov k value; indicate error if negative or zero
                    Dim _a As Double = mSoilCropProperties.KostiakovA_KT.Value
                    Dim _k As Double = KostiakovK(_depth.Value, _time.Value, _a)
                    Dim _kunits As KostiakovKParameter.K_Units = KostiakovKParameter.DisplayUnits

                    Me.KT_kValue.Text = KostiakovKParameter.KostiakovKString(_k, _a, _kunits, 0)
                    Me.KT_kValue.BackColor = SystemColors.Control

                    If (_k <= 0.0) Then
                        Me.KT_kValue.BackColor = DataStore.Globals.BackColor_Errored
                    Else
                        Me.KT_kValue.BackColor = SystemColors.Control
                    End If
                End If
            End If

            If Not (mWorldWindow Is Nothing) Then
                mWorldWindow.UpdateResultsControls()
            End If
        End If

    End Sub

    Private Sub UpdateKostiakovFunction()

        If (mMerriamKeller IsNot Nothing) Then

            Dim kChangedTime As DateTime = mSoilCropProperties.Infiltration.Timestamp

            If ((mUnit.DataHasChangedSince(kChangedTime)) _
            And (Not mUnit.ResultsAreValid)) Then
                mResultsAreValid = False

                ' Display the 'Estimate' button if any dependant value has changed
                Me.EstimateKF.Visible = True
                Me.EstimateKF.Enabled = Me.MerriamKellerCanBeExecuted

                Me.KF_kValue.Text = String.Empty
                Me.KF_kValue.BackColor = DataStore.Globals.BackColor_Errored
            Else
                mResultsAreValid = True

                ' Display the 'Estimate' button if all values are default
                If (mSoilCropProperties.KostiakovA_KF.Source = ValueSources.Defaulted) Then
                    Me.EstimateKF.Visible = True
                    Me.EstimateKF.Enabled = Me.MerriamKellerCanBeExecuted

                    Me.KF_kValue.Text = String.Empty
                    Me.KF_kValue.BackColor = DataStore.Globals.BackColor_Errored
                Else
                    ' Hide the 'Estimate' button
                    Me.EstimateKF.Visible = False

                    ' Display Kostiakov k value; indicate error if negative or zero
                    Dim _k As KostiakovKParameter = mSoilCropProperties.KostiakovK_KF
                    Me.KF_kValue.Text = _k.ValueString

                    If (_k.Value <= 0.0) Then
                        Me.KF_kValue.BackColor = DataStore.Globals.BackColor_Errored
                    Else
                        Me.KF_kValue.BackColor = SystemColors.Control
                    End If
                End If
            End If

            If (mWorldWindow IsNot Nothing) Then
                mWorldWindow.UpdateResultsControls()
            End If
        End If

    End Sub

    Private Sub UpdateModifiedKostiakov()

        If (mMerriamKeller IsNot Nothing) Then

            Dim kChangedTime As DateTime = mSoilCropProperties.Infiltration.Timestamp

            If ((mUnit.DataHasChangedSince(kChangedTime)) _
            And (Not mUnit.ResultsAreValid)) Then
                mResultsAreValid = False

                ' Display the 'Estimate' button if any dependant value has changed
                Me.EstimateMK.Visible = True
                Me.EstimateMK.Enabled = Me.MerriamKellerCanBeExecuted

                Me.MK_kValue.Text = String.Empty
                Me.MK_kValue.BackColor = DataStore.Globals.BackColor_Errored
            Else
                mResultsAreValid = True

                ' Display the 'Estimate' button if all values are default
                If ((mSoilCropProperties.KostiakovA_MK.Source = ValueSources.Defaulted) _
                And (mSoilCropProperties.KostiakovB_MK.Source = ValueSources.Defaulted) _
                And (mSoilCropProperties.KostiakovC_MK.Source = ValueSources.Defaulted)) Then
                    Me.EstimateMK.Visible = True
                    Me.EstimateMK.Enabled = Me.MerriamKellerCanBeExecuted

                    Me.MK_kValue.Text = String.Empty
                    Me.MK_kValue.BackColor = DataStore.Globals.BackColor_Errored
                Else
                    ' Hide the 'Estimate' button
                    Me.EstimateMK.Visible = False

                    ' Display Kostiakov k value; indicate error if negative or zero
                    Dim _k As KostiakovKParameter = mSoilCropProperties.KostiakovK_MK
                    Me.MK_kValue.Text = _k.ValueString

                    If (_k.Value <= 0.0) Then
                        Me.MK_kValue.BackColor = DataStore.Globals.BackColor_Errored
                    Else
                        Me.MK_kValue.BackColor = SystemColors.Control
                    End If
                End If
            End If

            If Not (mWorldWindow Is Nothing) Then
                mWorldWindow.UpdateResultsControls()
            End If
        End If

    End Sub

    Private Sub UpdateBranchFunction()

        If (mMerriamKeller IsNot Nothing) Then

            Dim kChangedTime As DateTime = mSoilCropProperties.Infiltration.Timestamp

            If ((mUnit.DataHasChangedSince(kChangedTime)) _
            And (Not mUnit.ResultsAreValid)) Then
                mResultsAreValid = False

                ' Display the 'Estimate' button if any dependant value has changed
                Me.EstimateBF.Visible = True
                Me.EstimateBF.Enabled = Me.MerriamKellerCanBeExecuted

                Me.BF_kValue.Text = String.Empty
                Me.BF_kValue.BackColor = DataStore.Globals.BackColor_Errored
            Else
                mResultsAreValid = True

                ' Display the 'Estimate' button if all values are default
                If ((mSoilCropProperties.KostiakovA_BF.Source = ValueSources.Defaulted) _
                And (mSoilCropProperties.BranchB_BF.Source = ValueSources.Defaulted) _
                And (mSoilCropProperties.KostiakovC_BF.Source = ValueSources.Defaulted)) Then
                    Me.EstimateBF.Visible = True
                    Me.EstimateBF.Enabled = Me.MerriamKellerCanBeExecuted

                    Me.BF_kValue.Text = String.Empty
                    Me.BF_kValue.BackColor = DataStore.Globals.BackColor_Errored
                Else
                    ' Hide the 'Estimate' button
                    Me.EstimateBF.Visible = False

                    ' Display Kostiakov k value; indicate error if negative or zero
                    Dim _k As KostiakovKParameter = mSoilCropProperties.KostiakovK_BF
                    Me.BF_kValue.Text = _k.ValueString

                    If (_k.Value <= 0.0) Then
                        Me.BF_kValue.BackColor = DataStore.Globals.BackColor_Errored
                    Else
                        Me.BF_kValue.BackColor = SystemColors.Control
                    End If
                End If
            End If

            If (mWorldWindow IsNot Nothing) Then
                mWorldWindow.UpdateResultsControls()
            End If
        End If

    End Sub

#End Region

#Region " Model Event Handlers "
    '
    ' When references Model object data changes, update the UI to match
    '
    Private Sub EventCriteria_PropertyChanged(ByVal reason As EventCriteria.Reasons) _
    Handles mEventCriteria.PropertyDataChanged
        If Not (mCalculating Or mMerriamKeller.Running) Then
            UpdateUI()
        End If
    End Sub

    Private Sub SrfrCriteria_PropertyChanged(ByVal reason As SrfrCriteria.Reasons) _
    Handles mSrfrCriteria.PropertyDataChanged
        If Not (mCalculating Or mMerriamKeller.Running) Then
            UpdateUI()
        End If
    End Sub

    Private Sub SystemGeometry_PropertyChanged(ByVal reason As SystemGeometry.Reasons) _
    Handles mSystemGeometry.PropertyDataChanged
        If Not (mCalculating Or mMerriamKeller.Running) Then
            UpdateUI()
        End If
    End Sub

    Private Sub SoilCropProperties_PropertyChanged(ByVal reason As SoilCropProperties.Reasons) _
    Handles mSoilCropProperties.PropertyDataChanged
        If Not (mCalculating Or mMerriamKeller.Running) Then
            UpdateUI()
        End If
    End Sub

    Private Sub InflowManagement_PropertyChanged(ByVal reason As InflowManagement.Reasons) _
    Handles mInflowManagement.PropertyDataChanged
        If Not (mCalculating Or mMerriamKeller.Running) Then
            UpdateUI()
        End If
    End Sub

    Private Sub UnitControl_PropertyChanged(ByVal reason As UnitControl.Reasons) _
    Handles mUnitControl.PropertyDataUpdated
        If Not (mCalculating Or mMerriamKeller.Running) Then
            UpdateUI()
        End If
    End Sub

#End Region

#Region " UI Event Handlers "

#Region " Wetted Perimeter Control Event Handlers "
    '
    ' Selectively, display/match New Wetted Perimeter dialog box on Wetted Perimeter changes
    '
    Private Sub WettedPerimeterControl_PreSaveAction(ByRef selection As Integer, ByRef saveOk As Boolean) _
    Handles WettedPerimeterControl.PreSaveAction
        saveOk = False
        If (mMerriamKeller IsNot Nothing) Then
            mMerriamKeller.WettedPerimeterMessage(selection)
            saveOk = True
        End If
    End Sub

    Private Sub WettedPerimeterControl_ControlValueChanged() _
    Handles WettedPerimeterControl.ControlValueChanged
        Dim WPparam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod
        Dim WPmethod As WettedPerimeterMethods = WPparam.Value

        Dim IEparam As IntegerParameter = mSoilCropProperties.InfiltrationFunction

        Select Case (WPmethod)

            Case WettedPerimeterMethods.LocalWettedPerimeter
                ' Only choice for Local Wetted Perimeter is Warrick/Creen-Ampt
                IEparam.Value = InfiltrationFunctions.WarrickGreenAmpt

            Case WettedPerimeterMethods.NrcsEmpiricalFunction
                ' Only choice is NRCS
                IEparam.Value = InfiltrationFunctions.NRCSIntakeFamily

            Case WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter
                ' Must be Kostiakov, Branch or Time-Rated
                If ((IEparam.Value = InfiltrationFunctions.KostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.BranchFunction) _
                 Or (IEparam.Value = InfiltrationFunctions.TimeRatedIntakeFamily)) Then
                    IEparam.Value = mSoilCropProperties.InfiltrationFunction.Value
                Else
                    IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula
                End If

            Case Else ' Assume WettedPerimeterMethods.FurrowSpacing
                ' Must be Kostiakov, Branch or Characteristic
                If ((IEparam.Value = InfiltrationFunctions.KostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula) _
                 Or (IEparam.Value = InfiltrationFunctions.BranchFunction) _
                 Or (IEparam.Value = InfiltrationFunctions.CharacteristicInfiltrationTime)) Then
                    IEparam.Value = mSoilCropProperties.InfiltrationFunction.Value
                Else
                    IEparam.Value = InfiltrationFunctions.ModifiedKostiakovFormula
                End If


        End Select

        If Not (IEparam.Value = mSoilCropProperties.InfiltrationFunction.Value) Then
            IEparam.Source = ValueSources.Calculated
            mSoilCropProperties.InfiltrationFunction = IEparam
            mSoilCropProperties.InfiltrationFunctionProperty.RecordCommand()
        End If

        If (mMerriamKeller IsNot Nothing) Then
            mMerriamKeller.ConvertWettedPerimeter()
        End If
    End Sub

#End Region

#Region " Infiltration Method Control Event Handlers "

    Private Sub InfiltrationFunctionControl_ControlValueChanged() _
    Handles InfiltrationEquationControl.ControlValueChanged

        ' For Furrows, Wetted Perimeter must match the Infiltration Method
        If (mUnit.CrossSection = CrossSections.Furrow) Then
            Dim WPparam As IntegerParameter = mSoilCropProperties.WettedPerimeterMethod

            Select Case (mSoilCropProperties.InfiltrationFunction.Value)

                Case InfiltrationFunctions.NRCSIntakeFamily
                    ' NRCS Intake Family should use NRCS Empirical Function
                    WPparam.Value = WettedPerimeterMethods.NrcsEmpiricalFunction

                Case InfiltrationFunctions.CharacteristicInfiltrationTime
                    ' Characteristic Infiltration Time should use Furrow Spacing
                    WPparam.Value = WettedPerimeterMethods.FurrowSpacing

                Case InfiltrationFunctions.TimeRatedIntakeFamily
                    ' Time-Rated Families should use Representative Upstream Wetted Perimeter
                    WPparam.Value = WettedPerimeterMethods.RepresentativeUpstreamWettedPerimeter

                Case InfiltrationFunctions.Hydrus1D
                    Debug.Assert(False, "HYDRUS-1D not supported")

                Case InfiltrationFunctions.WarrickGreenAmpt
                    ' Warrick Green-Ampt handles Wetted Perimeter itself (i.e. Local)
                    WPparam.Value = WettedPerimeterMethods.LocalWettedPerimeter

                Case Else ' Kostiakov, Branch, Green-Ampt, etc.
                    ' These should not use NRCS Wetted Perimeter
                    If (WPparam.Value = WettedPerimeterMethods.NrcsEmpiricalFunction) Then
                        WPparam.Value = WettedPerimeterMethods.FurrowSpacing
                    End If
            End Select

            If Not (WPparam.Value = mSoilCropProperties.WettedPerimeterMethod.Value) Then
                WPparam.Source = DataStore.Globals.ValueSources.Calculated
                mSoilCropProperties.WettedPerimeterMethod = WPparam
                mSoilCropProperties.WettedPerimeterMethodProperty.RecordCommand()
            End If
        End If

    End Sub

#End Region

#Region " NRCS Intake Family "

    Private Sub SelectNrcsFamily_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles SelectNrcsFamily.Click
        If (mMerriamKeller IsNot Nothing) Then
            Dim undoText As String = SelectNrcsFamily.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)

            ' Select the nearest NRCS Intake Family
            mCalculating = True
            Dim ok As Boolean = mMerriamKeller.SelectNrcsIntakeFamily()
            If Not (ok) Then
                mMerriamKeller.DisplayErrors()
            End If
            mCalculating = False

            ' Display the new NRCS Intake Family
            Me.UpdateNrcsIntakeFamily()
        End If
    End Sub

#End Region

#Region " Time-Rated Intake Family "

    Private Sub EstimateTimeRatedFamily_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles EstimateTimeRatedFamily.Click
        If (mMerriamKeller IsNot Nothing) Then
            Dim undoText As String = EstimateTimeRatedFamily.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)

            ' Calculate & save the Time-Rated Intake Family
            mCalculating = True
            Dim ok As Boolean = mMerriamKeller.CalcTimeRatedIntakeFamily()
            If Not (ok) Then
                mMerriamKeller.DisplayErrors()
            End If
            mCalculating = False

            ' Display the new Time-Rated Intake Family
            Me.UpdateTimeRatedInfiltrationFamily()
        End If
    End Sub

#End Region

#Region " Characteristic Infiltration Time "

    Private Sub EstimateKT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EstimateKT.Click
        If (mMerriamKeller IsNot Nothing) Then
            Dim undoText As String = EstimateKT.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)

            ' Estimate Characteristic Infiltration Time k
            mCalculating = True
            Dim ok As Boolean = mMerriamKeller.EstimateCharacteristicTimeK()
            If Not (ok) Then
                mMerriamKeller.DisplayErrors()
            End If
            mCalculating = False

            ' Display the new Kostiakov k
            UpdateCharacteristicTime()
        End If
    End Sub

#End Region

#Region " Kostiakov Function "

    Private Sub EstimateKF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EstimateKF.Click
        If (mMerriamKeller IsNot Nothing) Then
            Dim undoText As String = EstimateKF.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)

            ' Estimate Kostiakov Function k
            mCalculating = True
            Dim ok As Boolean = mMerriamKeller.EstimateKostiakovFormulaK()
            If Not (ok) Then
                mMerriamKeller.DisplayErrors()
            End If
            mCalculating = False

            ' Display the new Kostiakov k
            UpdateKostiakovFunction()
        End If
    End Sub

#End Region

#Region " Modified Kostiakov "

    Private Sub EstimateMK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EstimateMK.Click
        If (mMerriamKeller IsNot Nothing) Then
            Dim undoText As String = EstimateMK.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)

            ' Estimate Modified Kostiakov k
            mCalculating = True
            Dim ok As Boolean = mMerriamKeller.EstimateModifiedKostiakovK()
            If Not (ok) Then
                mMerriamKeller.DisplayErrors()
            End If
            mCalculating = False

            ' Display the new Kostiakov k
            UpdateModifiedKostiakov()
        End If
    End Sub

#End Region

#Region " Branch Function "

    Private Sub EstimateBF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EstimateBF.Click
        If (mMerriamKeller IsNot Nothing) Then
            Dim undoText As String = EstimateBF.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)

            ' Estimate Branch Function k
            mCalculating = True
            Dim ok As Boolean = mMerriamKeller.EstimateBranchFunctionK()
            If Not (ok) Then
                mMerriamKeller.DisplayErrors()
            End If
            mCalculating = False

            ' Display the new Kostiakov k
            Me.UpdateBranchFunction()
        End If
    End Sub

#End Region

#Region " Merriam-Keller "
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

#End Region

End Class
