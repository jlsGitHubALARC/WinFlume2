<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutWinFlumeDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutWinFlumeDialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.USBR_URL = New System.Windows.Forms.LinkLabel()
        Me.ARS_URL = New System.Windows.Forms.LinkLabel()
        Me.ILRI_URL = New System.Windows.Forms.LinkLabel()
        Me.WinFlumeAffiliations = New WinFlume.ctl_Label()
        Me.WinFlumeDescription = New WinFlume.ctl_Label()
        Me.FlumePicture = New WinFlume.ctl_PictureBox()
        Me.ILRI_Logo = New WinFlume.ctl_PictureBox()
        Me.ALARC_Logo = New WinFlume.ctl_PictureBox()
        Me.USBR_Logo = New WinFlume.ctl_PictureBox()
        Me.ILRI_Label2 = New WinFlume.ctl_Label()
        Me.ILRI_Label1 = New WinFlume.ctl_Label()
        Me.USDA_Label2 = New WinFlume.ctl_Label()
        Me.USDA_Label1 = New WinFlume.ctl_Label()
        Me.USBR_Label2 = New WinFlume.ctl_Label()
        Me.USBR_Label1 = New WinFlume.ctl_Label()
        Me.WinFlume_URL = New System.Windows.Forms.LinkLabel()
        Me.WinFlumeVersionLabel = New WinFlume.ctl_Label()
        Me.DetailsButton = New System.Windows.Forms.Button()
        Me.ReleaseDateLabel = New WinFlume.ctl_Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.FlumePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ILRI_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ALARC_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USBR_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'USBR_URL
        '
        resources.ApplyResources(Me.USBR_URL, "USBR_URL")
        Me.USBR_URL.Name = "USBR_URL"
        Me.USBR_URL.TabStop = True
        '
        'ARS_URL
        '
        resources.ApplyResources(Me.ARS_URL, "ARS_URL")
        Me.ARS_URL.Name = "ARS_URL"
        Me.ARS_URL.TabStop = True
        '
        'ILRI_URL
        '
        resources.ApplyResources(Me.ILRI_URL, "ILRI_URL")
        Me.ILRI_URL.Name = "ILRI_URL"
        Me.ILRI_URL.TabStop = True
        '
        'WinFlumeAffiliations
        '
        Me.WinFlumeAffiliations.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.WinFlumeAffiliations, "WinFlumeAffiliations")
        Me.WinFlumeAffiliations.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WinFlumeAffiliations.Name = "WinFlumeAffiliations"
        '
        'WinFlumeDescription
        '
        Me.WinFlumeDescription.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.WinFlumeDescription, "WinFlumeDescription")
        Me.WinFlumeDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.WinFlumeDescription.Name = "WinFlumeDescription"
        '
        'FlumePicture
        '
        Me.FlumePicture.Image = Global.WinFlume.My.Resources.Resources.SplashPhoto
        resources.ApplyResources(Me.FlumePicture, "FlumePicture")
        Me.FlumePicture.Name = "FlumePicture"
        Me.FlumePicture.TabStop = False
        '
        'ILRI_Logo
        '
        Me.ILRI_Logo.Image = Global.WinFlume.My.Resources.Resources.ILRI
        resources.ApplyResources(Me.ILRI_Logo, "ILRI_Logo")
        Me.ILRI_Logo.Name = "ILRI_Logo"
        Me.ILRI_Logo.TabStop = False
        '
        'ALARC_Logo
        '
        Me.ALARC_Logo.Image = Global.WinFlume.My.Resources.Resources.ARS
        resources.ApplyResources(Me.ALARC_Logo, "ALARC_Logo")
        Me.ALARC_Logo.Name = "ALARC_Logo"
        Me.ALARC_Logo.TabStop = False
        '
        'USBR_Logo
        '
        Me.USBR_Logo.Image = Global.WinFlume.My.Resources.Resources.USBR
        resources.ApplyResources(Me.USBR_Logo, "USBR_Logo")
        Me.USBR_Logo.Name = "USBR_Logo"
        Me.USBR_Logo.TabStop = False
        '
        'ILRI_Label2
        '
        resources.ApplyResources(Me.ILRI_Label2, "ILRI_Label2")
        Me.ILRI_Label2.Name = "ILRI_Label2"
        '
        'ILRI_Label1
        '
        resources.ApplyResources(Me.ILRI_Label1, "ILRI_Label1")
        Me.ILRI_Label1.Name = "ILRI_Label1"
        '
        'USDA_Label2
        '
        resources.ApplyResources(Me.USDA_Label2, "USDA_Label2")
        Me.USDA_Label2.Name = "USDA_Label2"
        '
        'USDA_Label1
        '
        resources.ApplyResources(Me.USDA_Label1, "USDA_Label1")
        Me.USDA_Label1.Name = "USDA_Label1"
        '
        'USBR_Label2
        '
        resources.ApplyResources(Me.USBR_Label2, "USBR_Label2")
        Me.USBR_Label2.Name = "USBR_Label2"
        '
        'USBR_Label1
        '
        resources.ApplyResources(Me.USBR_Label1, "USBR_Label1")
        Me.USBR_Label1.Name = "USBR_Label1"
        '
        'WinFlume_URL
        '
        resources.ApplyResources(Me.WinFlume_URL, "WinFlume_URL")
        Me.WinFlume_URL.Name = "WinFlume_URL"
        Me.WinFlume_URL.TabStop = True
        '
        'WinFlumeVersionLabel
        '
        resources.ApplyResources(Me.WinFlumeVersionLabel, "WinFlumeVersionLabel")
        Me.WinFlumeVersionLabel.Name = "WinFlumeVersionLabel"
        '
        'DetailsButton
        '
        resources.ApplyResources(Me.DetailsButton, "DetailsButton")
        Me.DetailsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.DetailsButton.Name = "DetailsButton"
        '
        'ReleaseDateLabel
        '
        resources.ApplyResources(Me.ReleaseDateLabel, "ReleaseDateLabel")
        Me.ReleaseDateLabel.Name = "ReleaseDateLabel"
        '
        'AboutWinFlumeDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.ReleaseDateLabel)
        Me.Controls.Add(Me.DetailsButton)
        Me.Controls.Add(Me.WinFlumeVersionLabel)
        Me.Controls.Add(Me.WinFlume_URL)
        Me.Controls.Add(Me.WinFlumeAffiliations)
        Me.Controls.Add(Me.WinFlumeDescription)
        Me.Controls.Add(Me.FlumePicture)
        Me.Controls.Add(Me.ILRI_URL)
        Me.Controls.Add(Me.ARS_URL)
        Me.Controls.Add(Me.USBR_URL)
        Me.Controls.Add(Me.ILRI_Logo)
        Me.Controls.Add(Me.ALARC_Logo)
        Me.Controls.Add(Me.USBR_Logo)
        Me.Controls.Add(Me.ILRI_Label2)
        Me.Controls.Add(Me.ILRI_Label1)
        Me.Controls.Add(Me.USDA_Label2)
        Me.Controls.Add(Me.USDA_Label1)
        Me.Controls.Add(Me.USBR_Label2)
        Me.Controls.Add(Me.USBR_Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutWinFlumeDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.FlumePicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ILRI_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ALARC_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USBR_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents USBR_Label1 As ctl_Label
    Friend WithEvents USBR_Label2 As ctl_Label
    Friend WithEvents USDA_Label2 As ctl_Label
    Friend WithEvents USDA_Label1 As ctl_Label
    Friend WithEvents ILRI_Label2 As ctl_Label
    Friend WithEvents ILRI_Label1 As ctl_Label
    Friend WithEvents USBR_Logo As ctl_PictureBox
    Friend WithEvents ALARC_Logo As ctl_PictureBox
    Friend WithEvents ILRI_Logo As ctl_PictureBox
    Friend WithEvents USBR_URL As LinkLabel
    Friend WithEvents ARS_URL As LinkLabel
    Friend WithEvents ILRI_URL As LinkLabel
    Friend WithEvents FlumePicture As ctl_PictureBox
    Friend WithEvents WinFlumeDescription As ctl_Label
    Friend WithEvents WinFlumeAffiliations As ctl_Label
    Friend WithEvents WinFlume_URL As LinkLabel
    Friend WithEvents WinFlumeVersionLabel As ctl_Label
    Friend WithEvents DetailsButton As Button
    Friend WithEvents ReleaseDateLabel As ctl_Label
End Class
