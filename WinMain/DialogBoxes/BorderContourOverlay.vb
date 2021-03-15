
'*************************************************************************************************************
' Contour Overlay - allows user to add a Contour Overlay tab to Design / Operations results
'
' The contours to overlay are selected using check boxes; the order of selection determines what colors will
' be used; colors are selected in order from the user preferences & displayed as contours are selected.
'*************************************************************************************************************
Public Class BorderContourOverlay
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _unit As Unit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeContourOverlay(_unit)

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
    Friend WithEvents ContourSelectionBox As DataStore.ctl_GroupBox
    Friend WithEvents DuSelected As System.Windows.Forms.CheckBox
    Friend WithEvents PaeSelected As System.Windows.Forms.CheckBox
    Friend WithEvents RoSelected As System.Windows.Forms.CheckBox
    Friend WithEvents DpSelected As System.Windows.Forms.CheckBox
    Friend WithEvents DappSelected As System.Windows.Forms.CheckBox
    Friend WithEvents TcoSelected As System.Windows.Forms.CheckBox
    Friend WithEvents MinorLabel As DataStore.ctl_Label
    Friend WithEvents PaeMinorSelected As System.Windows.Forms.CheckBox
    Friend WithEvents DappMinorSelected As System.Windows.Forms.CheckBox
    Friend WithEvents DuMinorSelected As System.Windows.Forms.CheckBox
    Friend WithEvents RoMinorSelected As System.Windows.Forms.CheckBox
    Friend WithEvents DpMinorSelected As System.Windows.Forms.CheckBox
    Friend WithEvents TcoMinorSelected As System.Windows.Forms.CheckBox
    Friend WithEvents MajorLabel As DataStore.ctl_Label
    Friend WithEvents PaeNo As System.Windows.Forms.Label
    Friend WithEvents DuNo As System.Windows.Forms.Label
    Friend WithEvents RoNo As System.Windows.Forms.Label
    Friend WithEvents DpNo As System.Windows.Forms.Label
    Friend WithEvents DappNo As System.Windows.Forms.Label
    Friend WithEvents TcoNo As System.Windows.Forms.Label
    Friend WithEvents OkayButton As DataStore.ctl_Button
    Friend WithEvents CancelItButton As DataStore.ctl_Button
    Friend WithEvents AddOverlayTab As DataStore.ctl_CheckParameter
    Friend WithEvents RSelected As System.Windows.Forms.CheckBox
    Friend WithEvents DlqminSelected As System.Windows.Forms.CheckBox
    Friend WithEvents RNo As System.Windows.Forms.Label
    Friend WithEvents DlqminNo As System.Windows.Forms.Label
    Friend WithEvents RMinorSelected As System.Windows.Forms.CheckBox
    Friend WithEvents AdNo As System.Windows.Forms.Label
    Friend WithEvents AdMinorSelected As System.Windows.Forms.CheckBox
    Friend WithEvents AdSelected As System.Windows.Forms.CheckBox
    Friend WithEvents TxaNo As System.Windows.Forms.Label
    Friend WithEvents TxaMinorSelected As System.Windows.Forms.CheckBox
    Friend WithEvents TxaSelected As System.Windows.Forms.CheckBox
    Friend WithEvents DlqminMinorSelected As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ContourSelectionBox = New DataStore.ctl_GroupBox
        Me.RNo = New System.Windows.Forms.Label
        Me.TcoNo = New System.Windows.Forms.Label
        Me.DlqminNo = New System.Windows.Forms.Label
        Me.DappNo = New System.Windows.Forms.Label
        Me.DpNo = New System.Windows.Forms.Label
        Me.RoNo = New System.Windows.Forms.Label
        Me.DuNo = New System.Windows.Forms.Label
        Me.PaeNo = New System.Windows.Forms.Label
        Me.MajorLabel = New DataStore.ctl_Label
        Me.RMinorSelected = New System.Windows.Forms.CheckBox
        Me.TcoMinorSelected = New System.Windows.Forms.CheckBox
        Me.DlqminMinorSelected = New System.Windows.Forms.CheckBox
        Me.DpMinorSelected = New System.Windows.Forms.CheckBox
        Me.RoMinorSelected = New System.Windows.Forms.CheckBox
        Me.DuMinorSelected = New System.Windows.Forms.CheckBox
        Me.DappMinorSelected = New System.Windows.Forms.CheckBox
        Me.PaeMinorSelected = New System.Windows.Forms.CheckBox
        Me.MinorLabel = New DataStore.ctl_Label
        Me.RSelected = New System.Windows.Forms.CheckBox
        Me.TcoSelected = New System.Windows.Forms.CheckBox
        Me.DlqminSelected = New System.Windows.Forms.CheckBox
        Me.DappSelected = New System.Windows.Forms.CheckBox
        Me.DpSelected = New System.Windows.Forms.CheckBox
        Me.RoSelected = New System.Windows.Forms.CheckBox
        Me.DuSelected = New System.Windows.Forms.CheckBox
        Me.PaeSelected = New System.Windows.Forms.CheckBox
        Me.OkayButton = New DataStore.ctl_Button
        Me.CancelItButton = New DataStore.ctl_Button
        Me.AddOverlayTab = New DataStore.ctl_CheckParameter
        Me.TxaNo = New System.Windows.Forms.Label
        Me.TxaMinorSelected = New System.Windows.Forms.CheckBox
        Me.TxaSelected = New System.Windows.Forms.CheckBox
        Me.AdNo = New System.Windows.Forms.Label
        Me.AdMinorSelected = New System.Windows.Forms.CheckBox
        Me.AdSelected = New System.Windows.Forms.CheckBox
        Me.ContourSelectionBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContourSelectionBox
        '
        Me.ContourSelectionBox.Controls.Add(Me.AdNo)
        Me.ContourSelectionBox.Controls.Add(Me.AdMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.AdSelected)
        Me.ContourSelectionBox.Controls.Add(Me.TxaNo)
        Me.ContourSelectionBox.Controls.Add(Me.TxaMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.TxaSelected)
        Me.ContourSelectionBox.Controls.Add(Me.RNo)
        Me.ContourSelectionBox.Controls.Add(Me.TcoNo)
        Me.ContourSelectionBox.Controls.Add(Me.DlqminNo)
        Me.ContourSelectionBox.Controls.Add(Me.DappNo)
        Me.ContourSelectionBox.Controls.Add(Me.DpNo)
        Me.ContourSelectionBox.Controls.Add(Me.RoNo)
        Me.ContourSelectionBox.Controls.Add(Me.DuNo)
        Me.ContourSelectionBox.Controls.Add(Me.PaeNo)
        Me.ContourSelectionBox.Controls.Add(Me.MajorLabel)
        Me.ContourSelectionBox.Controls.Add(Me.RMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.TcoMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.DlqminMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.DpMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.RoMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.DuMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.DappMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.PaeMinorSelected)
        Me.ContourSelectionBox.Controls.Add(Me.MinorLabel)
        Me.ContourSelectionBox.Controls.Add(Me.RSelected)
        Me.ContourSelectionBox.Controls.Add(Me.TcoSelected)
        Me.ContourSelectionBox.Controls.Add(Me.DlqminSelected)
        Me.ContourSelectionBox.Controls.Add(Me.DappSelected)
        Me.ContourSelectionBox.Controls.Add(Me.DpSelected)
        Me.ContourSelectionBox.Controls.Add(Me.RoSelected)
        Me.ContourSelectionBox.Controls.Add(Me.DuSelected)
        Me.ContourSelectionBox.Controls.Add(Me.PaeSelected)
        Me.ContourSelectionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContourSelectionBox.Location = New System.Drawing.Point(16, 56)
        Me.ContourSelectionBox.Name = "ContourSelectionBox"
        Me.ContourSelectionBox.Size = New System.Drawing.Size(251, 324)
        Me.ContourSelectionBox.TabIndex = 1
        Me.ContourSelectionBox.TabStop = False
        Me.ContourSelectionBox.Text = "&Select Contours to Overlay"
        '
        'RNo
        '
        Me.RNo.Location = New System.Drawing.Point(6, 290)
        Me.RNo.Name = "RNo"
        Me.RNo.Size = New System.Drawing.Size(34, 23)
        Me.RNo.TabIndex = 29
        Me.RNo.Text = "10"
        Me.RNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TcoNo
        '
        Me.TcoNo.Location = New System.Drawing.Point(16, 266)
        Me.TcoNo.Name = "TcoNo"
        Me.TcoNo.Size = New System.Drawing.Size(24, 23)
        Me.TcoNo.TabIndex = 26
        Me.TcoNo.Text = "9"
        Me.TcoNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DlqminNo
        '
        Me.DlqminNo.Location = New System.Drawing.Point(16, 216)
        Me.DlqminNo.Name = "DlqminNo"
        Me.DlqminNo.Size = New System.Drawing.Size(24, 23)
        Me.DlqminNo.TabIndex = 20
        Me.DlqminNo.Text = "7"
        Me.DlqminNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DappNo
        '
        Me.DappNo.Location = New System.Drawing.Point(16, 192)
        Me.DappNo.Name = "DappNo"
        Me.DappNo.Size = New System.Drawing.Size(24, 23)
        Me.DappNo.TabIndex = 17
        Me.DappNo.Text = "6"
        Me.DappNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DpNo
        '
        Me.DpNo.Location = New System.Drawing.Point(16, 168)
        Me.DpNo.Name = "DpNo"
        Me.DpNo.Size = New System.Drawing.Size(24, 23)
        Me.DpNo.TabIndex = 14
        Me.DpNo.Text = "5"
        Me.DpNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RoNo
        '
        Me.RoNo.Location = New System.Drawing.Point(16, 144)
        Me.RoNo.Name = "RoNo"
        Me.RoNo.Size = New System.Drawing.Size(24, 23)
        Me.RoNo.TabIndex = 11
        Me.RoNo.Text = "4"
        Me.RoNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DuNo
        '
        Me.DuNo.Location = New System.Drawing.Point(16, 96)
        Me.DuNo.Name = "DuNo"
        Me.DuNo.Size = New System.Drawing.Size(24, 23)
        Me.DuNo.TabIndex = 5
        Me.DuNo.Text = "2"
        Me.DuNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PaeNo
        '
        Me.PaeNo.Location = New System.Drawing.Point(16, 72)
        Me.PaeNo.Name = "PaeNo"
        Me.PaeNo.Size = New System.Drawing.Size(24, 23)
        Me.PaeNo.TabIndex = 2
        Me.PaeNo.Text = "1"
        Me.PaeNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MajorLabel
        '
        Me.MajorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MajorLabel.Location = New System.Drawing.Point(56, 30)
        Me.MajorLabel.Name = "MajorLabel"
        Me.MajorLabel.Size = New System.Drawing.Size(83, 44)
        Me.MajorLabel.TabIndex = 0
        Me.MajorLabel.Text = "Major contours"
        '
        'RMinorSelected
        '
        Me.RMinorSelected.Enabled = False
        Me.RMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RMinorSelected.Location = New System.Drawing.Point(153, 290)
        Me.RMinorSelected.Name = "RMinorSelected"
        Me.RMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.RMinorSelected.TabIndex = 31
        '
        'TcoMinorSelected
        '
        Me.TcoMinorSelected.Enabled = False
        Me.TcoMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcoMinorSelected.Location = New System.Drawing.Point(153, 266)
        Me.TcoMinorSelected.Name = "TcoMinorSelected"
        Me.TcoMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.TcoMinorSelected.TabIndex = 28
        '
        'DlqminMinorSelected
        '
        Me.DlqminMinorSelected.Enabled = False
        Me.DlqminMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DlqminMinorSelected.Location = New System.Drawing.Point(153, 216)
        Me.DlqminMinorSelected.Name = "DlqminMinorSelected"
        Me.DlqminMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.DlqminMinorSelected.TabIndex = 22
        '
        'DpMinorSelected
        '
        Me.DpMinorSelected.Enabled = False
        Me.DpMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpMinorSelected.Location = New System.Drawing.Point(153, 168)
        Me.DpMinorSelected.Name = "DpMinorSelected"
        Me.DpMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.DpMinorSelected.TabIndex = 16
        '
        'RoMinorSelected
        '
        Me.RoMinorSelected.Enabled = False
        Me.RoMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoMinorSelected.Location = New System.Drawing.Point(153, 144)
        Me.RoMinorSelected.Name = "RoMinorSelected"
        Me.RoMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.RoMinorSelected.TabIndex = 13
        '
        'DuMinorSelected
        '
        Me.DuMinorSelected.Enabled = False
        Me.DuMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DuMinorSelected.Location = New System.Drawing.Point(153, 96)
        Me.DuMinorSelected.Name = "DuMinorSelected"
        Me.DuMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.DuMinorSelected.TabIndex = 7
        '
        'DappMinorSelected
        '
        Me.DappMinorSelected.Enabled = False
        Me.DappMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DappMinorSelected.Location = New System.Drawing.Point(153, 192)
        Me.DappMinorSelected.Name = "DappMinorSelected"
        Me.DappMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.DappMinorSelected.TabIndex = 19
        '
        'PaeMinorSelected
        '
        Me.PaeMinorSelected.Enabled = False
        Me.PaeMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaeMinorSelected.Location = New System.Drawing.Point(153, 72)
        Me.PaeMinorSelected.Name = "PaeMinorSelected"
        Me.PaeMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.PaeMinorSelected.TabIndex = 4
        '
        'MinorLabel
        '
        Me.MinorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinorLabel.Location = New System.Drawing.Point(145, 30)
        Me.MinorLabel.Name = "MinorLabel"
        Me.MinorLabel.Size = New System.Drawing.Size(83, 44)
        Me.MinorLabel.TabIndex = 1
        Me.MinorLabel.Text = "Minor contours"
        '
        'RSelected
        '
        Me.RSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RSelected.Location = New System.Drawing.Point(56, 290)
        Me.RSelected.Name = "RSelected"
        Me.RSelected.Size = New System.Drawing.Size(72, 24)
        Me.RSelected.TabIndex = 30
        Me.RSelected.Text = "XR"
        '
        'TcoSelected
        '
        Me.TcoSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcoSelected.Location = New System.Drawing.Point(56, 266)
        Me.TcoSelected.Name = "TcoSelected"
        Me.TcoSelected.Size = New System.Drawing.Size(72, 24)
        Me.TcoSelected.TabIndex = 27
        Me.TcoSelected.Text = "Tco"
        '
        'DlqminSelected
        '
        Me.DlqminSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DlqminSelected.Location = New System.Drawing.Point(56, 216)
        Me.DlqminSelected.Name = "DlqminSelected"
        Me.DlqminSelected.Size = New System.Drawing.Size(72, 24)
        Me.DlqminSelected.TabIndex = 21
        Me.DlqminSelected.Text = "Dlq/min"
        '
        'DappSelected
        '
        Me.DappSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DappSelected.Location = New System.Drawing.Point(56, 192)
        Me.DappSelected.Name = "DappSelected"
        Me.DappSelected.Size = New System.Drawing.Size(72, 24)
        Me.DappSelected.TabIndex = 18
        Me.DappSelected.Text = "Dapp"
        '
        'DpSelected
        '
        Me.DpSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DpSelected.Location = New System.Drawing.Point(56, 168)
        Me.DpSelected.Name = "DpSelected"
        Me.DpSelected.Size = New System.Drawing.Size(72, 24)
        Me.DpSelected.TabIndex = 15
        Me.DpSelected.Text = "DP"
        '
        'RoSelected
        '
        Me.RoSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoSelected.Location = New System.Drawing.Point(56, 144)
        Me.RoSelected.Name = "RoSelected"
        Me.RoSelected.Size = New System.Drawing.Size(72, 24)
        Me.RoSelected.TabIndex = 12
        Me.RoSelected.Text = "RO"
        '
        'DuSelected
        '
        Me.DuSelected.AccessibleDescription = "Include the DU min or lq contours"
        Me.DuSelected.AccessibleName = "DU min / lq"
        Me.DuSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DuSelected.Location = New System.Drawing.Point(56, 96)
        Me.DuSelected.Name = "DuSelected"
        Me.DuSelected.Size = New System.Drawing.Size(72, 24)
        Me.DuSelected.TabIndex = 6
        Me.DuSelected.Text = "DU"
        '
        'PaeSelected
        '
        Me.PaeSelected.AccessibleDescription = "Include the PAE min or lq contours"
        Me.PaeSelected.AccessibleName = "PAE min / lq"
        Me.PaeSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaeSelected.Location = New System.Drawing.Point(56, 72)
        Me.PaeSelected.Name = "PaeSelected"
        Me.PaeSelected.Size = New System.Drawing.Size(72, 24)
        Me.PaeSelected.TabIndex = 3
        Me.PaeSelected.Text = "PAE"
        '
        'OkayButton
        '
        Me.OkayButton.AutoSize = True
        Me.OkayButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OkayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkayButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OkayButton.Location = New System.Drawing.Point(16, 392)
        Me.OkayButton.Name = "OkayButton"
        Me.OkayButton.Size = New System.Drawing.Size(80, 27)
        Me.OkayButton.TabIndex = 2
        Me.OkayButton.Text = "&Ok"
        Me.OkayButton.UseVisualStyleBackColor = False
        '
        'CancelItButton
        '
        Me.CancelItButton.AutoSize = True
        Me.CancelItButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelItButton.Location = New System.Drawing.Point(187, 392)
        Me.CancelItButton.Name = "CancelItButton"
        Me.CancelItButton.Size = New System.Drawing.Size(80, 27)
        Me.CancelItButton.TabIndex = 3
        Me.CancelItButton.Text = "&Cancel"
        '
        'AddOverlayTab
        '
        Me.AddOverlayTab.AlwaysChecked = False
        Me.AddOverlayTab.ErrorMessage = Nothing
        Me.AddOverlayTab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddOverlayTab.Location = New System.Drawing.Point(16, 16)
        Me.AddOverlayTab.Name = "AddOverlayTab"
        Me.AddOverlayTab.Size = New System.Drawing.Size(266, 24)
        Me.AddOverlayTab.TabIndex = 0
        Me.AddOverlayTab.Text = "&Add Overlay Tab to Results"
        Me.AddOverlayTab.UncheckAttemptMessage = Nothing
        '
        'TxaNo
        '
        Me.TxaNo.Location = New System.Drawing.Point(16, 240)
        Me.TxaNo.Name = "TxaNo"
        Me.TxaNo.Size = New System.Drawing.Size(24, 23)
        Me.TxaNo.TabIndex = 23
        Me.TxaNo.Text = "8"
        Me.TxaNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxaMinorSelected
        '
        Me.TxaMinorSelected.Enabled = False
        Me.TxaMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxaMinorSelected.Location = New System.Drawing.Point(153, 240)
        Me.TxaMinorSelected.Name = "TxaMinorSelected"
        Me.TxaMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.TxaMinorSelected.TabIndex = 25
        '
        'TxaSelected
        '
        Me.TxaSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxaSelected.Location = New System.Drawing.Point(56, 240)
        Me.TxaSelected.Name = "TxaSelected"
        Me.TxaSelected.Size = New System.Drawing.Size(72, 24)
        Me.TxaSelected.TabIndex = 24
        Me.TxaSelected.Text = "Txa"
        '
        'AdNo
        '
        Me.AdNo.Location = New System.Drawing.Point(16, 120)
        Me.AdNo.Name = "AdNo"
        Me.AdNo.Size = New System.Drawing.Size(24, 23)
        Me.AdNo.TabIndex = 8
        Me.AdNo.Text = "3"
        Me.AdNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AdMinorSelected
        '
        Me.AdMinorSelected.Enabled = False
        Me.AdMinorSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdMinorSelected.Location = New System.Drawing.Point(153, 120)
        Me.AdMinorSelected.Name = "AdMinorSelected"
        Me.AdMinorSelected.Size = New System.Drawing.Size(24, 24)
        Me.AdMinorSelected.TabIndex = 10
        '
        'AdSelected
        '
        Me.AdSelected.AccessibleDescription = "Include the AD min or lq contours"
        Me.AdSelected.AccessibleName = "AD min / lq"
        Me.AdSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdSelected.Location = New System.Drawing.Point(56, 120)
        Me.AdSelected.Name = "AdSelected"
        Me.AdSelected.Size = New System.Drawing.Size(72, 24)
        Me.AdSelected.TabIndex = 9
        Me.AdSelected.Text = "AD"
        '
        'BorderContourOverlay
        '
        Me.AcceptButton = Me.OkayButton
        Me.AccessibleDescription = "Selects which contours to overlay within the Overlay Results tab."
        Me.AccessibleName = "Contour Overlay Selection"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelItButton
        Me.ClientSize = New System.Drawing.Size(284, 431)
        Me.Controls.Add(Me.AddOverlayTab)
        Me.Controls.Add(Me.CancelItButton)
        Me.Controls.Add(Me.OkayButton)
        Me.Controls.Add(Me.ContourSelectionBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BorderContourOverlay"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contour Overlay Selections"
        Me.ContourSelectionBox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Member Data "

    Private mDictionary As Dictionary = Dictionary.Instance
    Private mUserPreferences As UserPreferences = UserPreferences.Instance

#End Region

#Region " Properties "

    Private mUnit As Unit                                           ' Unit containing contour data
    Public ReadOnly Property Unit() As Unit
        Get
            Return mUnit
        End Get
    End Property

    Private mOverlayEnabled As Boolean = False                      ' Has user enabled the overlay tab?
    Public Property OverlayEnabled() As Boolean
        Get
            Return mOverlayEnabled
        End Get
        Set(ByVal Value As Boolean)
            mOverlayEnabled = Value
        End Set
    End Property

    Private mMajorOverlays As ArrayList = New ArrayList             ' User selected major overlays
    Public Property MajorOverlays() As ArrayList
        Get
            Return mMajorOverlays
        End Get
        Set(ByVal Value As ArrayList)
            mMajorOverlays = Value
        End Set
    End Property

    Private mMinorOverlays As ArrayList = New ArrayList             ' User selected minor overlays
    Public Property MinorOverlays() As ArrayList
        Get
            Return mMinorOverlays
        End Get
        Set(ByVal Value As ArrayList)
            mMinorOverlays = Value
        End Set
    End Property

    Private mSelectionChanged As Boolean = False                    ' Flag indicating user selections have changed
    Private Property SelectionChanged() As Boolean
        Get
            Return mSelectionChanged
        End Get
        Set(ByVal Value As Boolean)
            mSelectionChanged = Value
            Me.OkayButton.Enabled = mSelectionChanged
        End Set
    End Property

    Public ReadOnly Property NoOfPages() As Integer                 ' Number of pages for Contour Overlay results
        Get
            Dim _noOfPages As Integer = 0
            If (mUnit IsNot Nothing) Then
                If (Me.OverlayEnabled) Then
                    If (0 < Me.MajorOverlays.Count) Then
                        _noOfPages = 1
                    End If
                End If
            End If
            Return _noOfPages
        End Get
    End Property

#End Region

#Region " Initialization "

    Public Sub InitializeContourOverlay(ByVal _unit As Unit)

        If (_unit IsNot Nothing) Then
            mUnit = _unit

            ' Set UI to match World Type & Cross Section
            Select Case (_unit.UnitType.Value)

                Case Globals.WorldTypes.DesignWorld

                    ' Tco & R available
                    Me.TcoSelected.Enabled = True
                    Me.TcoMinorSelected.Enabled = True

                Case Globals.WorldTypes.OperationsWorld

                    ' Only R available; not Tco
                    Me.TcoSelected.Enabled = False
                    Me.TcoMinorSelected.Enabled = False

            End Select

            ' No Runoff if Blocked End
            If (mUnit.SystemGeometryRef.DownstreamCondition.Value = DownstreamConditions.BlockedEnd) Then
                Me.RoSelected.Enabled = False
                Me.RoMinorSelected.Enabled = False
            Else
                Me.RoSelected.Enabled = True
                Me.RoMinorSelected.Enabled = True
            End If

            ' Initialize the UI
            UpdateUI()
            SelectionChanged = False
        End If

    End Sub

#End Region

#Region " Methods "
    '
    ' Add / Remove Major / Minor Overlays from their respective lists
    '
    Private Sub AddMajorOverlay(ByVal _param As PerformanceParameters)
        If Not (mUpdatingUI) Then
            mMajorOverlays.Add(_param)
            UpdateUI()
        End If
    End Sub

    Private Sub RemoveMajorOverlay(ByVal _param As PerformanceParameters)
        If Not (mUpdatingUI) Then
            mMajorOverlays.Remove(_param)
            UpdateUI()
        End If
    End Sub

    Private Sub AddMinorOverlay(ByVal _param As PerformanceParameters)
        If Not (mUpdatingUI) Then
            mMinorOverlays.Add(_param)
            UpdateUI()
        End If
    End Sub

    Private Sub RemoveMinorOverlay(ByVal _param As PerformanceParameters)
        If Not (mUpdatingUI) Then
            mMinorOverlays.Remove(_param)
            UpdateUI()
        End If
    End Sub
    '
    ' Update the UI
    '
    Private mUpdatingUI As Boolean = False
    Private Sub UpdateUI()
        ' Disable additional calls to UpdateUI() until this call is done
        mUpdatingUI = True

        Me.Text = mDictionary.ControlText(Me)

        ' Flag that a selection has changed; enables Ok button
        SelectionChanged = True

        ' Check / uncheck 'Add Overlays...'
        If (mOverlayEnabled) Then
            AddOverlayTab.Checked = True
            ContourSelectionBox.Enabled = True
        Else
            AddOverlayTab.Checked = False
            ContourSelectionBox.Enabled = False
        End If

        ' Order & check the selected major contours
        Dim _userPreferences As UserPreferences = UserPreferences.Instance
        Dim _n As Integer = 1
        For Each _param As PerformanceParameters In mMajorOverlays
            Select Case (_param)
                Case Globals.PerformanceParameters.PAE
                    PaeNo.Text = _n.ToString
                    PaeNo.ForeColor = _userPreferences.ColorN(_n)
                    PaeNo.BackColor = System.Drawing.SystemColors.Window
                    PaeSelected.Checked = True
                    PaeMinorSelected.Enabled = True
                Case Globals.PerformanceParameters.DU
                    DuNo.Text = _n.ToString
                    DuNo.ForeColor = _userPreferences.ColorN(_n)
                    DuNo.BackColor = System.Drawing.SystemColors.Window
                    DuSelected.Checked = True
                    DuMinorSelected.Enabled = True
                Case Globals.PerformanceParameters.AD
                    AdNo.Text = _n.ToString
                    AdNo.ForeColor = _userPreferences.ColorN(_n)
                    AdNo.BackColor = System.Drawing.SystemColors.Window
                    AdSelected.Checked = True
                    AdMinorSelected.Enabled = True
                Case Globals.PerformanceParameters.RO
                    RoNo.Text = _n.ToString
                    RoNo.ForeColor = _userPreferences.ColorN(_n)
                    RoNo.BackColor = System.Drawing.SystemColors.Window
                    RoSelected.Checked = True
                    RoMinorSelected.Enabled = True
                Case Globals.PerformanceParameters.DP
                    DpNo.Text = _n.ToString
                    DpNo.ForeColor = _userPreferences.ColorN(_n)
                    DpNo.BackColor = System.Drawing.SystemColors.Window
                    DpSelected.Checked = True
                    DpMinorSelected.Enabled = True
                Case Globals.PerformanceParameters.Dapp
                    DappNo.Text = _n.ToString
                    DappNo.ForeColor = _userPreferences.ColorN(_n)
                    DappNo.BackColor = System.Drawing.SystemColors.Window
                    DappSelected.Checked = True
                    DappMinorSelected.Enabled = True
                Case Globals.PerformanceParameters.Dlqmin
                    DlqminNo.Text = _n.ToString
                    DlqminNo.ForeColor = _userPreferences.ColorN(_n)
                    DlqminNo.BackColor = System.Drawing.SystemColors.Window
                    DlqminSelected.Checked = True
                    DlqminMinorSelected.Enabled = True
                Case Globals.PerformanceParameters.Txa
                    TxaNo.Text = _n.ToString
                    TxaNo.ForeColor = _userPreferences.ColorN(_n)
                    TxaNo.BackColor = System.Drawing.SystemColors.Window
                    TxaSelected.Checked = True
                    TxaMinorSelected.Enabled = True
                Case Globals.PerformanceParameters.Tco
                    TcoNo.Text = _n.ToString
                    TcoNo.ForeColor = _userPreferences.ColorN(_n)
                    TcoNo.BackColor = System.Drawing.SystemColors.Window
                    TcoSelected.Checked = True
                    TcoMinorSelected.Enabled = True
                Case Globals.PerformanceParameters.R
                    RNo.Text = _n.ToString
                    RNo.ForeColor = _userPreferences.ColorN(_n)
                    RNo.BackColor = System.Drawing.SystemColors.Window
                    RSelected.Checked = True
                    RMinorSelected.Enabled = True
                Case Else
                    Debug.Assert(False)
            End Select

            _n += 1
        Next

        ' Uncheck the unselected major contours
        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.PAE)) Then
            PaeNo.Text = String.Empty
            PaeNo.ForeColor = System.Drawing.SystemColors.Control
            PaeNo.BackColor = System.Drawing.SystemColors.Control
            PaeSelected.Checked = False
            PaeMinorSelected.Enabled = False
        End If

        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.DU)) Then
            DuNo.Text = String.Empty
            DuNo.ForeColor = System.Drawing.SystemColors.Control
            DuNo.BackColor = System.Drawing.SystemColors.Control
            DuSelected.Checked = False
            DuMinorSelected.Enabled = False
        End If

        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.AD)) Then
            AdNo.Text = String.Empty
            AdNo.ForeColor = System.Drawing.SystemColors.Control
            AdNo.BackColor = System.Drawing.SystemColors.Control
            AdSelected.Checked = False
            AdMinorSelected.Enabled = False
        End If

        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.RO)) Then
            RoNo.Text = String.Empty
            RoNo.ForeColor = System.Drawing.SystemColors.Control
            RoNo.BackColor = System.Drawing.SystemColors.Control
            RoSelected.Checked = False
            RoMinorSelected.Enabled = False
        End If

        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.DP)) Then
            DpNo.Text = String.Empty
            DpNo.ForeColor = System.Drawing.SystemColors.Control
            DpNo.BackColor = System.Drawing.SystemColors.Control
            DpSelected.Checked = False
            DpMinorSelected.Enabled = False
        End If

        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.Dapp)) Then
            DappNo.Text = String.Empty
            DappNo.ForeColor = System.Drawing.SystemColors.Control
            DappNo.BackColor = System.Drawing.SystemColors.Control
            DappSelected.Checked = False
            DappMinorSelected.Enabled = False
        End If

        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.Dlqmin)) Then
            DlqminNo.Text = String.Empty
            DlqminNo.ForeColor = System.Drawing.SystemColors.Control
            DlqminNo.BackColor = System.Drawing.SystemColors.Control
            DlqminSelected.Checked = False
            DlqminMinorSelected.Enabled = False
        End If

        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.Txa)) Then
            TxaNo.Text = String.Empty
            TxaNo.ForeColor = System.Drawing.SystemColors.Control
            TxaNo.BackColor = System.Drawing.SystemColors.Control
            TxaSelected.Checked = False
            TxaMinorSelected.Enabled = False
        End If

        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.Tco)) Then
            TcoNo.Text = String.Empty
            TcoNo.ForeColor = System.Drawing.SystemColors.Control
            TcoNo.BackColor = System.Drawing.SystemColors.Control
            TcoSelected.Checked = False
            TcoMinorSelected.Enabled = False
        End If

        If Not (mMajorOverlays.Contains(Globals.PerformanceParameters.R)) Then
            RNo.Text = String.Empty
            RNo.ForeColor = System.Drawing.SystemColors.Control
            RNo.BackColor = System.Drawing.SystemColors.Control
            RSelected.Checked = False
            RMinorSelected.Enabled = False
        End If

        ' Check / uncheck the unselected minor contours
        If (mUserPreferences.DisplayMinorContours) Then
            PaeMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.PAE)
            DuMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.DU)
            AdMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.AD)
            RoMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.RO)
            DpMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.DP)
            DlqminMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.Dlqmin)
            DappMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.Dapp)
            TxaMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.Txa)
            TcoMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.Tco)
            RMinorSelected.Checked = mMinorOverlays.Contains(Globals.PerformanceParameters.R)

        Else ' no Minor Contours
            PaeMinorSelected.Enabled = False
            DuMinorSelected.Enabled = False
            AdMinorSelected.Enabled = False
            RoMinorSelected.Enabled = False
            DpMinorSelected.Enabled = False
            DlqminMinorSelected.Enabled = False
            DappMinorSelected.Enabled = False
            TxaMinorSelected.Enabled = False
            TcoMinorSelected.Enabled = False
            RMinorSelected.Enabled = False

            PaeMinorSelected.Checked = False
            DuMinorSelected.Checked = False
            AdMinorSelected.Checked = False
            RoMinorSelected.Checked = False
            DpMinorSelected.Checked = False
            DlqminMinorSelected.Checked = False
            DappMinorSelected.Checked = False
            TxaMinorSelected.Checked = False
            TcoMinorSelected.Checked = False
            RMinorSelected.Checked = False
        End If

        ' Raise event to other objects can adjust to changes
        RaiseEvent OverlayChanged()

        ' Allow another call to UpdateUI()
        mUpdatingUI = False
    End Sub

#End Region

#Region " Events & Handlers "

    Public Event OverlayChanged()

    Private Sub AddOverlayTab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AddOverlayTab.CheckedChanged
        mOverlayEnabled = AddOverlayTab.Checked
        UpdateUI()
    End Sub
    '
    ' PAE - Potentail Application Efficiency
    '
    Private Sub PaeSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PaeSelected.CheckedChanged
        If (PaeSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.PAE)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.PAE)
        End If
    End Sub

    Private Sub PaeMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PaeMinorSelected.CheckedChanged
        If (PaeMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.PAE)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.PAE)
        End If
    End Sub
    '
    ' DU - Distribution Uniformity
    '
    Private Sub DuSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DuSelected.CheckedChanged
        If (DuSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.DU)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.DU)
        End If
    End Sub

    Private Sub DuMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DuMinorSelected.CheckedChanged
        If (DuMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.DU)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.DU)
        End If
    End Sub
    '
    ' AD - Adequacy
    '
    Private Sub AdSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AdSelected.CheckedChanged
        If (AdSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.AD)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.AD)
        End If
    End Sub

    Private Sub AdMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AdMinorSelected.CheckedChanged
        If (AdMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.AD)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.AD)
        End If
    End Sub
    '
    ' RO - Runoff
    '
    Private Sub RoSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RoSelected.CheckedChanged
        If (RoSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.RO)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.RO)
        End If
    End Sub

    Private Sub RoMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RoMinorSelected.CheckedChanged
        If (RoMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.RO)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.RO)
        End If
    End Sub
    '
    ' DP - Deep Percolation
    '
    Private Sub DpSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DpSelected.CheckedChanged
        If (DpSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.DP)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.DP)
        End If
    End Sub

    Private Sub DpMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DpMinorSelected.CheckedChanged
        If (DpMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.DP)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.DP)
        End If
    End Sub
    '
    ' Dapp - Application Depth
    '
    Private Sub DappSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DappSelected.CheckedChanged
        If (DappSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.Dapp)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.Dapp)
        End If
    End Sub

    Private Sub DappMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DappMinorSelected.CheckedChanged
        If (DappMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.Dapp)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.Dapp)
        End If
    End Sub
    '
    ' Low-Quarter or Minimum Depth
    '
    Private Sub DlqminSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DlqminSelected.CheckedChanged
        If (DlqminSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.Dlqmin)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.Dlqmin)
        End If
    End Sub

    Private Sub DlqminMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DlqminMinorSelected.CheckedChanged
        If (DlqminMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.Dlqmin)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.Dlqmin)
        End If
    End Sub
    '
    ' Txa - Max Advance Time
    '
    Private Sub TxaSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TxaSelected.CheckedChanged
        If (TxaSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.Txa)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.Txa)
        End If
    End Sub

    Private Sub TxaMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TxaMinorSelected.CheckedChanged
        If (TxaMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.Txa)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.Txa)
        End If
    End Sub
    '
    ' Tco - Cutoff Time
    '
    Private Sub TcoSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TcoSelected.CheckedChanged
        If (TcoSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.Tco)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.Tco)
        End If
    End Sub

    Private Sub TcoMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TcoMinorSelected.CheckedChanged
        If (TcoMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.Tco)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.Tco)
        End If
    End Sub
    '
    ' R - Cutoff Position
    '
    Private Sub RSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RSelected.CheckedChanged
        If (RSelected.Checked) Then
            AddMajorOverlay(Globals.PerformanceParameters.R)
        Else
            RemoveMajorOverlay(Globals.PerformanceParameters.R)
        End If
    End Sub

    Private Sub RMinorSelected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RMinorSelected.CheckedChanged
        If (RMinorSelected.Checked) Then
            AddMinorOverlay(Globals.PerformanceParameters.R)
        Else
            RemoveMinorOverlay(Globals.PerformanceParameters.R)
        End If
    End Sub
    '
    ' Dialog box buttons
    '
    Private Sub OkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkayButton.Click
        ' Set OK result & close the dialog box
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BorderContourOverlay_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("ch:OperationsContourConfiguration", 0)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("ch:OperationsContourConfiguration", 250)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class
