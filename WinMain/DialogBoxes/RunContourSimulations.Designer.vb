<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RunContourSimulations
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
        Me.RunSrfrPanel = New System.Windows.Forms.Panel()
        Me.SrfrControlsPanel = New System.Windows.Forms.Panel()
        Me.ControlPanel = New System.Windows.Forms.Panel()
        Me.StatusPanel = New System.Windows.Forms.Panel()
        Me.SrfrStatus = New System.Windows.Forms.Label()
        Me.ProgressPanel = New System.Windows.Forms.Panel()
        Me.ProgressLabel = New System.Windows.Forms.Label()
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        Me.AbortButton = New System.Windows.Forms.Button()
        Me.RunSrfrPanel.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        Me.StatusPanel.SuspendLayout()
        Me.ProgressPanel.SuspendLayout()
        Me.ButtonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RunSrfrPanel
        '
        Me.RunSrfrPanel.Controls.Add(Me.SrfrControlsPanel)
        Me.RunSrfrPanel.Controls.Add(Me.ControlPanel)
        Me.RunSrfrPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RunSrfrPanel.Location = New System.Drawing.Point(0, 0)
        Me.RunSrfrPanel.Name = "RunSrfrPanel"
        Me.RunSrfrPanel.Size = New System.Drawing.Size(632, 403)
        Me.RunSrfrPanel.TabIndex = 1
        '
        'SrfrControlsPanel
        '
        Me.SrfrControlsPanel.AutoScroll = True
        Me.SrfrControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SrfrControlsPanel.Location = New System.Drawing.Point(0, 0)
        Me.SrfrControlsPanel.Name = "SrfrControlsPanel"
        Me.SrfrControlsPanel.Size = New System.Drawing.Size(632, 360)
        Me.SrfrControlsPanel.TabIndex = 1
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.StatusPanel)
        Me.ControlPanel.Controls.Add(Me.ButtonPanel)
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ControlPanel.Location = New System.Drawing.Point(0, 360)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(632, 43)
        Me.ControlPanel.TabIndex = 0
        '
        'StatusPanel
        '
        Me.StatusPanel.Controls.Add(Me.SrfrStatus)
        Me.StatusPanel.Controls.Add(Me.ProgressPanel)
        Me.StatusPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StatusPanel.Location = New System.Drawing.Point(0, 0)
        Me.StatusPanel.Name = "StatusPanel"
        Me.StatusPanel.Size = New System.Drawing.Size(541, 43)
        Me.StatusPanel.TabIndex = 1
        '
        'SrfrStatus
        '
        Me.SrfrStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SrfrStatus.Location = New System.Drawing.Point(0, 0)
        Me.SrfrStatus.Name = "SrfrStatus"
        Me.SrfrStatus.Size = New System.Drawing.Size(417, 43)
        Me.SrfrStatus.TabIndex = 1
        Me.SrfrStatus.Text = "SRFR Status"
        Me.SrfrStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgressPanel
        '
        Me.ProgressPanel.Controls.Add(Me.ProgressLabel)
        Me.ProgressPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ProgressPanel.Location = New System.Drawing.Point(417, 0)
        Me.ProgressPanel.Name = "ProgressPanel"
        Me.ProgressPanel.Size = New System.Drawing.Size(124, 43)
        Me.ProgressPanel.TabIndex = 0
        '
        'ProgressLabel
        '
        Me.ProgressLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressLabel.Location = New System.Drawing.Point(0, 0)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.Size = New System.Drawing.Size(124, 43)
        Me.ProgressLabel.TabIndex = 0
        Me.ProgressLabel.Text = "Progress"
        Me.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonPanel
        '
        Me.ButtonPanel.Controls.Add(Me.AbortButton)
        Me.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonPanel.Location = New System.Drawing.Point(541, 0)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(91, 43)
        Me.ButtonPanel.TabIndex = 0
        '
        'AbortButton
        '
        Me.AbortButton.Location = New System.Drawing.Point(7, 9)
        Me.AbortButton.Name = "AbortButton"
        Me.AbortButton.Size = New System.Drawing.Size(75, 28)
        Me.AbortButton.TabIndex = 0
        Me.AbortButton.Text = "Abort"
        Me.AbortButton.UseVisualStyleBackColor = True
        '
        'RunContourSimulations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 403)
        Me.Controls.Add(Me.RunSrfrPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RunContourSimulations"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Run Contour Simulations"
        Me.RunSrfrPanel.ResumeLayout(False)
        Me.ControlPanel.ResumeLayout(False)
        Me.StatusPanel.ResumeLayout(False)
        Me.ProgressPanel.ResumeLayout(False)
        Me.ButtonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RunSrfrPanel As Panel
    Friend WithEvents ControlPanel As Panel
    Friend WithEvents ButtonPanel As Panel
    Friend WithEvents AbortButton As Button
    Friend WithEvents StatusPanel As Panel
    Friend WithEvents ProgressPanel As Panel
    Friend WithEvents SrfrStatus As Label
    Friend WithEvents ProgressLabel As Label
    Friend WithEvents SrfrControlsPanel As Panel
End Class
