
'**********************************************************************************************
' Help About Dialog Box
'
Imports Srfr.SrfrAPI
Imports PrintingUi

Public Class HelpAbout
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeHelpAbout()

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
    Friend WithEvents UsdaPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents HelpAboutText As System.Windows.Forms.RichTextBox
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents AlarcPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsdaLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents ArsLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents CitationLabel As System.Windows.Forms.Label
    Friend WithEvents CitationText As System.Windows.Forms.TextBox
    Friend WithEvents AlarcLinkLabel As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelpAbout))
        Me.UsdaPictureBox = New System.Windows.Forms.PictureBox
        Me.HelpAboutText = New System.Windows.Forms.RichTextBox
        Me.AlarcLinkLabel = New System.Windows.Forms.LinkLabel
        Me.OkButton = New System.Windows.Forms.Button
        Me.AlarcPictureBox = New System.Windows.Forms.PictureBox
        Me.UsdaLinkLabel = New System.Windows.Forms.LinkLabel
        Me.ArsLinkLabel = New System.Windows.Forms.LinkLabel
        Me.CitationLabel = New System.Windows.Forms.Label
        Me.CitationText = New System.Windows.Forms.TextBox
        CType(Me.UsdaPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AlarcPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsdaPictureBox
        '
        Me.UsdaPictureBox.Image = CType(resources.GetObject("UsdaPictureBox.Image"), System.Drawing.Image)
        Me.UsdaPictureBox.Location = New System.Drawing.Point(16, 136)
        Me.UsdaPictureBox.Name = "UsdaPictureBox"
        Me.UsdaPictureBox.Size = New System.Drawing.Size(88, 112)
        Me.UsdaPictureBox.TabIndex = 0
        Me.UsdaPictureBox.TabStop = False
        '
        'HelpAboutText
        '
        Me.HelpAboutText.BackColor = System.Drawing.SystemColors.Control
        Me.HelpAboutText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.HelpAboutText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpAboutText.Location = New System.Drawing.Point(120, 136)
        Me.HelpAboutText.Name = "HelpAboutText"
        Me.HelpAboutText.ReadOnly = True
        Me.HelpAboutText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.HelpAboutText.Size = New System.Drawing.Size(304, 176)
        Me.HelpAboutText.TabIndex = 0
        Me.HelpAboutText.TabStop = False
        Me.HelpAboutText.Text = ""
        '
        'AlarcLinkLabel
        '
        Me.AlarcLinkLabel.Location = New System.Drawing.Point(16, 320)
        Me.AlarcLinkLabel.Name = "AlarcLinkLabel"
        Me.AlarcLinkLabel.Size = New System.Drawing.Size(408, 23)
        Me.AlarcLinkLabel.TabIndex = 3
        Me.AlarcLinkLabel.TabStop = True
        Me.AlarcLinkLabel.Text = "Arid-Land Agricultural Research Center"
        Me.AlarcLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OkButton
        '
        Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OkButton.Location = New System.Drawing.Point(176, 445)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(88, 24)
        Me.OkButton.TabIndex = 4
        Me.OkButton.Text = "&Ok"
        '
        'AlarcPictureBox
        '
        Me.AlarcPictureBox.Image = CType(resources.GetObject("AlarcPictureBox.Image"), System.Drawing.Image)
        Me.AlarcPictureBox.Location = New System.Drawing.Point(16, 8)
        Me.AlarcPictureBox.Name = "AlarcPictureBox"
        Me.AlarcPictureBox.Size = New System.Drawing.Size(402, 114)
        Me.AlarcPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.AlarcPictureBox.TabIndex = 4
        Me.AlarcPictureBox.TabStop = False
        '
        'UsdaLinkLabel
        '
        Me.UsdaLinkLabel.Location = New System.Drawing.Point(16, 256)
        Me.UsdaLinkLabel.Name = "UsdaLinkLabel"
        Me.UsdaLinkLabel.Size = New System.Drawing.Size(88, 23)
        Me.UsdaLinkLabel.TabIndex = 1
        Me.UsdaLinkLabel.TabStop = True
        Me.UsdaLinkLabel.Text = "USDA"
        Me.UsdaLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ArsLinkLabel
        '
        Me.ArsLinkLabel.Location = New System.Drawing.Point(16, 288)
        Me.ArsLinkLabel.Name = "ArsLinkLabel"
        Me.ArsLinkLabel.Size = New System.Drawing.Size(88, 23)
        Me.ArsLinkLabel.TabIndex = 2
        Me.ArsLinkLabel.TabStop = True
        Me.ArsLinkLabel.Text = "ARS"
        Me.ArsLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CitationLabel
        '
        Me.CitationLabel.AutoSize = True
        Me.CitationLabel.Location = New System.Drawing.Point(10, 355)
        Me.CitationLabel.Name = "CitationLabel"
        Me.CitationLabel.Size = New System.Drawing.Size(416, 17)
        Me.CitationLabel.TabIndex = 5
        Me.CitationLabel.Text = "When referencing this software, please use the following citation:"
        Me.CitationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CitationText
        '
        Me.CitationText.Location = New System.Drawing.Point(16, 378)
        Me.CitationText.Multiline = True
        Me.CitationText.Name = "CitationText"
        Me.CitationText.Size = New System.Drawing.Size(402, 55)
        Me.CitationText.TabIndex = 6
        Me.CitationText.Text = "Bautista, E., Schlegel, J.L., and Strelkoff, T.S.  WinSRFR 4.1 - User Manual. USD" & _
            "A-ARS Arid Land Agricultural Research Center.  21881 N. Cardon Lane, Maricopa, A" & _
            "Z, USA, September, 2012."
        '
        'HelpAbout
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.CancelButton = Me.OkButton
        Me.ClientSize = New System.Drawing.Size(437, 475)
        Me.Controls.Add(Me.CitationText)
        Me.Controls.Add(Me.CitationLabel)
        Me.Controls.Add(Me.ArsLinkLabel)
        Me.Controls.Add(Me.UsdaLinkLabel)
        Me.Controls.Add(Me.AlarcPictureBox)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.AlarcLinkLabel)
        Me.Controls.Add(Me.HelpAboutText)
        Me.Controls.Add(Me.UsdaPictureBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HelpAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About WinWRFR"
        CType(Me.UsdaPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AlarcPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Initialization "

    Private Sub InitializeHelpAbout()

        HelpAboutText.Clear()

        AppendBoldText(HelpAboutText, Application.ProductName & " " & Application.ProductVersion & ", ")
        AppendBoldLine(HelpAboutText, Srfr.SrfrAPI.AssemblyTitle)
        AppendBoldLine(HelpAboutText, "Built: " & WinSRFR.BuildDateTime.ToLongDateString)
        AdvanceLine(HelpAboutText)
        AppendBoldLine(HelpAboutText, DepartmentName)
        AdvanceLine(HelpAboutText)
        AppendBoldLine(HelpAboutText, ServiceName)
        AdvanceLine(HelpAboutText)
        AppendBoldLine(HelpAboutText, CenterName)
        AppendBoldLine(HelpAboutText, CenterAddress)
        AppendBoldLine(HelpAboutText, CenterCity & ", " & CenterState & " " & CenterZipCode)

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub UsdaLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As LinkLabelLinkClickedEventArgs) _
    Handles UsdaLinkLabel.LinkClicked
        ' Mark link as visited
        Me.UsdaLinkLabel.Links(UsdaLinkLabel.Links.IndexOf(e.Link)).Visited = True
        ' Display USDA web page
        Try ' default browser
            System.Diagnostics.Process.Start(URL_USDA)
        Catch ex1 As Exception
            Try ' Internet Explorer
                System.Diagnostics.Process.Start("IExplore", URL_USDA)
            Catch ex2 As Exception
                Try ' Chrome
                    System.Diagnostics.Process.Start("Chrome", URL_USDA)
                Catch ex3 As Exception
                End Try
            End Try
        End Try
    End Sub

    Private Sub ArsLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As LinkLabelLinkClickedEventArgs) _
    Handles ArsLinkLabel.LinkClicked
        ' Mark link as visited
        Me.ArsLinkLabel.Links(ArsLinkLabel.Links.IndexOf(e.Link)).Visited = True
        ' Display ARS web page
        Try ' default browser
            System.Diagnostics.Process.Start(URL_ARS)
        Catch ex1 As Exception
            Try ' Internet Explorer
                System.Diagnostics.Process.Start("IExplore", URL_ARS)
            Catch ex2 As Exception
                Try ' Chrome
                    System.Diagnostics.Process.Start("Chrome", URL_ARS)
                Catch ex3 As Exception
                End Try
            End Try
        End Try
    End Sub

    Private Sub AlarcLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As LinkLabelLinkClickedEventArgs) _
    Handles AlarcLinkLabel.LinkClicked
        ' Mark link as visited
        Me.AlarcLinkLabel.Links(AlarcLinkLabel.Links.IndexOf(e.Link)).Visited = True
        ' Display ALARC web page
        Try ' default browser
            System.Diagnostics.Process.Start(URL_ALARC)
        Catch ex1 As Exception
            Try ' Internet Explorer
                System.Diagnostics.Process.Start("IExplore", URL_ALARC)
            Catch ex2 As Exception
                Try ' Chrome
                    System.Diagnostics.Process.Start("Chrome", URL_ALARC)
                Catch ex3 As Exception
                End Try
            End Try
        End Try
    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkButton.Click
        Me.Close()
    End Sub

#End Region

End Class
