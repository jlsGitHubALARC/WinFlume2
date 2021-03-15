
'**********************************************************************************************
' Control class: ctl_SoilCropProperties
'
'   ctl_SoilCropProperties provides the UI for viewing & editing Infiltration & Roughness by
'   combining ctl_Infiltration & ctl_Roughness into one control
'
Imports DataStore

Public Class ctl_SoilCropProperties
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
    Public WithEvents InfiltrationControl As WinMain.ctl_Infiltration
    Friend WithEvents InfiltrationNotAvailableMessage As System.Windows.Forms.TextBox
    Friend WithEvents RoughnessNotAvailableMessage As System.Windows.Forms.TextBox
    Friend WithEvents RoughnessControl As WinMain.ctl_Roughness
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.InfiltrationNotAvailableMessage = New System.Windows.Forms.TextBox
        Me.RoughnessNotAvailableMessage = New System.Windows.Forms.TextBox
        Me.RoughnessControl = New WinMain.ctl_Roughness
        Me.InfiltrationControl = New WinMain.ctl_Infiltration
        Me.SuspendLayout()
        '
        'InfiltrationNotAvailableMessage
        '
        Me.InfiltrationNotAvailableMessage.BackColor = System.Drawing.SystemColors.Info
        Me.InfiltrationNotAvailableMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationNotAvailableMessage.ForeColor = System.Drawing.SystemColors.InfoText
        Me.InfiltrationNotAvailableMessage.Location = New System.Drawing.Point(456, 56)
        Me.InfiltrationNotAvailableMessage.Multiline = True
        Me.InfiltrationNotAvailableMessage.Name = "InfiltrationNotAvailableMessage"
        Me.InfiltrationNotAvailableMessage.Size = New System.Drawing.Size(248, 80)
        Me.InfiltrationNotAvailableMessage.TabIndex = 4
        Me.InfiltrationNotAvailableMessage.TabStop = False
        Me.InfiltrationNotAvailableMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RoughnessNotAvailableMessage
        '
        Me.RoughnessNotAvailableMessage.BackColor = System.Drawing.SystemColors.Info
        Me.RoughnessNotAvailableMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessNotAvailableMessage.ForeColor = System.Drawing.SystemColors.InfoText
        Me.RoughnessNotAvailableMessage.Location = New System.Drawing.Point(72, 56)
        Me.RoughnessNotAvailableMessage.Multiline = True
        Me.RoughnessNotAvailableMessage.Name = "RoughnessNotAvailableMessage"
        Me.RoughnessNotAvailableMessage.Size = New System.Drawing.Size(248, 80)
        Me.RoughnessNotAvailableMessage.TabIndex = 2
        Me.RoughnessNotAvailableMessage.TabStop = False
        Me.RoughnessNotAvailableMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RoughnessControl
        '
        Me.RoughnessControl.AccessibleDescription = "Inputs for describing the resistance the surface water encounters as it flows dow" & _
            "n the field."
        Me.RoughnessControl.AccessibleName = "Roughness"
        Me.RoughnessControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessControl.Location = New System.Drawing.Point(8, 0)
        Me.RoughnessControl.MinimumSize = New System.Drawing.Size(368, 420)
        Me.RoughnessControl.Name = "RoughnessControl"
        Me.RoughnessControl.Size = New System.Drawing.Size(368, 420)
        Me.RoughnessControl.TabIndex = 1
        '
        'InfiltrationControl
        '
        Me.InfiltrationControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfiltrationControl.Location = New System.Drawing.Point(376, 0)
        Me.InfiltrationControl.MatchingCurve = Nothing
        Me.InfiltrationControl.MinimumSize = New System.Drawing.Size(400, 420)
        Me.InfiltrationControl.Name = "InfiltrationControl"
        Me.InfiltrationControl.Size = New System.Drawing.Size(400, 420)
        Me.InfiltrationControl.TabIndex = 3
        '
        'ctl_SoilCropProperties
        '
        Me.AccessibleDescription = "Roughness and Infiltration parameter input."
        Me.AccessibleName = "Soil Crop Properties"
        Me.Controls.Add(Me.RoughnessControl)
        Me.Controls.Add(Me.InfiltrationControl)
        Me.Controls.Add(Me.RoughnessNotAvailableMessage)
        Me.Controls.Add(Me.InfiltrationNotAvailableMessage)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ctl_SoilCropProperties"
        Me.Size = New System.Drawing.Size(780, 422)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Control / Model Linkage "
    '
    ' Establish link to model object and update UI with its data
    '
    Private mMyStore As ObjectNode
    Private mUnit As Unit
    Private mWorldWindow As WorldWindow
    Private mDictionary As Dictionary = Dictionary.Instance

    Public Sub LinkToModel(ByVal _unit As Unit, ByVal _worldForm As WorldWindow)

        Debug.Assert((_unit IsNot Nothing), "Unit is Nothing")

        ' Link this control to its model
        mUnit = _unit
        mWorldWindow = _worldForm
        mMyStore = mUnit.MyStore

        ' Link contained controls to their models
        InfiltrationControl.LinkToModel(mUnit, mWorldWindow)
        RoughnessControl.LinkToModel(mUnit)

        ' Update this control's User Interface
        Me.Dock = DockStyle.Fill

        UpdateUI()

    End Sub

#End Region

#Region " UI Update Methods "
    '
    ' Update UI with values from linked model object
    '
    Public Sub UpdateUI()
        If (ParentCtrlNotVisible(Me.Parent)) Then ' Control is not visible; don't update it
            Return
        End If

        ' Update the UI only if it is linked to a model object
        If (mUnit IsNot Nothing) Then
            InfiltrationControl.UpdateUI()
            RoughnessControl.UpdateUI()

            Me.InfiltrationNotAvailableMessage.Text = mDictionary.tUseAnalysisTabs.Translated
            Me.RoughnessNotAvailableMessage.Text = mDictionary.tRoughnessDefinitionNotAvailable.Translated
        End If
    End Sub

#End Region

#Region " UI Event Handers "

    Private Sub SoilCropProperties_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        Me.RoughnessControl.Height = MyBase.Height - MyBase.Margin.Top - MyBase.Margin.Bottom

        Me.InfiltrationControl.Height = MyBase.Height - MyBase.Margin.Top - MyBase.Margin.Bottom
        Me.InfiltrationControl.Width = MyBase.Width - Me.RoughnessControl.Width - MyBase.Margin.Left - MyBase.Margin.Right

    End Sub
    '
    ' Make sure UI is up to date whenever it becomes visible
    '
    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

#End Region

End Class
