
'*************************************************************************************************************
' NrcsIntakeFamilyOptions - 
'*************************************************************************************************************
Public Class NrcsIntakeFamilyOptions
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal soilCropProperties As SoilCropProperties)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitNrcsIntakeFamilyOptions(soilCropProperties)

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
    Friend WithEvents KostiakovParametersGroup As DataStore.ctl_GroupBox
    Friend WithEvents ApproximateByBestFit As DataStore.ctl_RadioButton
    Friend WithEvents DescribeByNrcsFormula As DataStore.ctl_RadioButton
    Friend WithEvents OkOptions As DataStore.ctl_Button
    Friend WithEvents CancelOptions As DataStore.ctl_Button
    Friend WithEvents NrcsDescription1 As DataStore.ctl_Label
    Friend WithEvents BestFitDescription1 As DataStore.ctl_Label
    Friend WithEvents BestFitDescription2 As DataStore.ctl_Label
    Friend WithEvents NrcsDescription2 As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.KostiakovParametersGroup = New DataStore.ctl_GroupBox
        Me.ApproximateByBestFit = New DataStore.ctl_RadioButton
        Me.BestFitDescription1 = New DataStore.ctl_Label
        Me.BestFitDescription2 = New DataStore.ctl_Label
        Me.DescribeByNrcsFormula = New DataStore.ctl_RadioButton
        Me.NrcsDescription1 = New DataStore.ctl_Label
        Me.NrcsDescription2 = New DataStore.ctl_Label
        Me.OkOptions = New DataStore.ctl_Button
        Me.CancelOptions = New DataStore.ctl_Button
        Me.KostiakovParametersGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'KostiakovParametersGroup
        '
        Me.KostiakovParametersGroup.AccessibleDescription = "Selects method for generating the Kostiakov Parameters k, a & c"
        Me.KostiakovParametersGroup.AccessibleName = "Kostiakov Parameters for NRCS Intake Family"
        Me.KostiakovParametersGroup.Controls.Add(Me.ApproximateByBestFit)
        Me.KostiakovParametersGroup.Controls.Add(Me.BestFitDescription1)
        Me.KostiakovParametersGroup.Controls.Add(Me.BestFitDescription2)
        Me.KostiakovParametersGroup.Controls.Add(Me.DescribeByNrcsFormula)
        Me.KostiakovParametersGroup.Controls.Add(Me.NrcsDescription1)
        Me.KostiakovParametersGroup.Controls.Add(Me.NrcsDescription2)
        Me.KostiakovParametersGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KostiakovParametersGroup.Location = New System.Drawing.Point(16, 16)
        Me.KostiakovParametersGroup.Name = "KostiakovParametersGroup"
        Me.KostiakovParametersGroup.Size = New System.Drawing.Size(432, 184)
        Me.KostiakovParametersGroup.TabIndex = 0
        Me.KostiakovParametersGroup.TabStop = False
        Me.KostiakovParametersGroup.Text = "&Kostiakov Parameters for NRCS Intake Family"
        '
        'ApproximateByBestFit
        '
        Me.ApproximateByBestFit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApproximateByBestFit.Location = New System.Drawing.Point(16, 32)
        Me.ApproximateByBestFit.Name = "ApproximateByBestFit"
        Me.ApproximateByBestFit.Size = New System.Drawing.Size(408, 24)
        Me.ApproximateByBestFit.TabIndex = 0
        Me.ApproximateByBestFit.Text = "Approximate by Best Fit   -   k*t^a"
        '
        'BestFitDescription1
        '
        Me.BestFitDescription1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BestFitDescription1.Location = New System.Drawing.Point(32, 56)
        Me.BestFitDescription1.Name = "BestFitDescription1"
        Me.BestFitDescription1.Size = New System.Drawing.Size(392, 24)
        Me.BestFitDescription1.TabIndex = 1
        Me.BestFitDescription1.Text = "NRCS Intake Family approximated by Kostiakov k && a."
        Me.BestFitDescription1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'BestFitDescription2
        '
        Me.BestFitDescription2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BestFitDescription2.Location = New System.Drawing.Point(32, 80)
        Me.BestFitDescription2.Name = "BestFitDescription2"
        Me.BestFitDescription2.Size = New System.Drawing.Size(392, 23)
        Me.BestFitDescription2.TabIndex = 2
        Me.BestFitDescription2.Text = "(i.e. no c term in equation)"
        '
        'DescribeByNrcsFormula
        '
        Me.DescribeByNrcsFormula.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescribeByNrcsFormula.Location = New System.Drawing.Point(16, 104)
        Me.DescribeByNrcsFormula.Name = "DescribeByNrcsFormula"
        Me.DescribeByNrcsFormula.Size = New System.Drawing.Size(408, 24)
        Me.DescribeByNrcsFormula.TabIndex = 3
        Me.DescribeByNrcsFormula.Text = "Describe by   -   k*t^a + c     where c = 7 mm"
        '
        'NrcsDescription1
        '
        Me.NrcsDescription1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsDescription1.Location = New System.Drawing.Point(32, 128)
        Me.NrcsDescription1.Name = "NrcsDescription1"
        Me.NrcsDescription1.Size = New System.Drawing.Size(392, 24)
        Me.NrcsDescription1.TabIndex = 4
        Me.NrcsDescription1.Text = "NRCS Intake Family specifies the k, a && c terms."
        Me.NrcsDescription1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'NrcsDescription2
        '
        Me.NrcsDescription2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NrcsDescription2.Location = New System.Drawing.Point(32, 152)
        Me.NrcsDescription2.Name = "NrcsDescription2"
        Me.NrcsDescription2.Size = New System.Drawing.Size(392, 23)
        Me.NrcsDescription2.TabIndex = 5
        Me.NrcsDescription2.Text = "(c is always 7 mm)"
        '
        'OkOptions
        '
        Me.OkOptions.AccessibleDescription = "Accepts the options changes."
        Me.OkOptions.AccessibleName = "OK Button"
        Me.OkOptions.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OkOptions.Enabled = False
        Me.OkOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkOptions.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OkOptions.Location = New System.Drawing.Point(16, 208)
        Me.OkOptions.Name = "OkOptions"
        Me.OkOptions.Size = New System.Drawing.Size(75, 24)
        Me.OkOptions.TabIndex = 1
        Me.OkOptions.Text = "&Ok"
        Me.OkOptions.UseVisualStyleBackColor = False
        '
        'CancelOptions
        '
        Me.CancelOptions.AccessibleDescription = "Rejects the options changes."
        Me.CancelOptions.AccessibleName = "Cancel Button"
        Me.CancelOptions.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelOptions.Location = New System.Drawing.Point(373, 208)
        Me.CancelOptions.Name = "CancelOptions"
        Me.CancelOptions.Size = New System.Drawing.Size(75, 24)
        Me.CancelOptions.TabIndex = 2
        Me.CancelOptions.Text = "&Cancel"
        '
        'NrcsIntakeFamilyOptions
        '
        Me.AcceptButton = Me.OkOptions
        Me.AccessibleDescription = "Dialog box provides options pertaining to the NRCS Intake infiltration families."
        Me.AccessibleName = "NRCS Intake Family Options"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.CancelOptions
        Me.ClientSize = New System.Drawing.Size(466, 239)
        Me.Controls.Add(Me.OkOptions)
        Me.Controls.Add(Me.CancelOptions)
        Me.Controls.Add(Me.KostiakovParametersGroup)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NrcsIntakeFamilyOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NRCS Intake Family Options"
        Me.KostiakovParametersGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    Private mSoilCropProperties As SoilCropProperties
    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Properties "

    Private mNrcsToKostiakovMethod As NrcsToKostiakovMethods
    Public ReadOnly Property NrcsToKostiakovMethod() As NrcsToKostiakovMethods
        Get
            Return mNrcsToKostiakovMethod
        End Get
    End Property

#End Region

#Region " Initialization "

    Private Sub InitNrcsIntakeFamilyOptions(ByVal _soilCropProperties As SoilCropProperties)

        If (_soilCropProperties IsNot Nothing) Then
            mSoilCropProperties = _soilCropProperties
            mNrcsToKostiakovMethod = CType(mSoilCropProperties.NrcsToKostiakovMethod.Value, NrcsToKostiakovMethods)

            Me.Text = mDictionary.ControlText(Me)

            Select Case (mNrcsToKostiakovMethod)
                Case NrcsToKostiakovMethods.ApproximateByBestFit
                    Me.ApproximateByBestFit.Checked = True
                Case Else ' Assume NrcsToKostiakovMethods.DescribeByNrcsFormula
                    Me.DescribeByNrcsFormula.Checked = True
            End Select
        End If

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub SetNrcsToKostiakovMethod(ByVal nrcsToKostiakovMethod As NrcsToKostiakovMethods)

        mNrcsToKostiakovMethod = nrcsToKostiakovMethod

        If Not (mSoilCropProperties Is Nothing) Then
            If Not (mSoilCropProperties.NrcsToKostiakovMethod.Value = mNrcsToKostiakovMethod) Then
                Me.OkOptions.Enabled = True
            Else
                Me.OkOptions.Enabled = False
            End If
        End If

    End Sub

    Private Sub ApproximateByBestFit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ApproximateByBestFit.CheckedChanged
        If (ApproximateByBestFit.Checked) Then
            SetNrcsToKostiakovMethod(NrcsToKostiakovMethods.ApproximateByBestFit)
        End If
    End Sub

    Private Sub DescribeByNrcsFormula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DescribeByNrcsFormula.CheckedChanged
        If (DescribeByNrcsFormula.Checked) Then
            SetNrcsToKostiakovMethod(NrcsToKostiakovMethods.DescribeByNrcsFormula)
        End If
    End Sub

    Private Sub OkOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkOptions.Click
        ' Set OK result & close the dialog box
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub NrcsIntakeFamilyOptions_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:BorderInfiltration", 1100)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:BorderInfiltration", 1100)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class
