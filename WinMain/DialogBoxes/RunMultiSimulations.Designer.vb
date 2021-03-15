<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RunMultiSimulations
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
        Me.RunMultiButton = New DataStore.ctl_Button
        Me.TitleLabel = New DataStore.ctl_Label
        Me.CloseButton = New DataStore.ctl_Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.OutputFileBox = New DataStore.ctl_GroupBox
        Me.ClearResultsFile = New DataStore.ctl_CheckParameter
        Me.OutputInstructions = New DataStore.ctl_Label
        Me.BrowseOutputFileButton = New DataStore.ctl_Button
        Me.OutputFilename = New System.Windows.Forms.TextBox
        Me.InputFileBox = New DataStore.ctl_GroupBox
        Me.InputInstructions = New DataStore.ctl_Label
        Me.BrowseInputFileButton = New DataStore.ctl_Button
        Me.InputFilename = New System.Windows.Forms.TextBox
        Me.ShowMessageOnError = New DataStore.ctl_CheckParameter
        Me.OutputFileBox.SuspendLayout()
        Me.InputFileBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'RunMultiButton
        '
        Me.RunMultiButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RunMultiButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RunMultiButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RunMultiButton.Location = New System.Drawing.Point(10, 353)
        Me.RunMultiButton.Name = "RunMultiButton"
        Me.RunMultiButton.Size = New System.Drawing.Size(231, 28)
        Me.RunMultiButton.TabIndex = 3
        Me.RunMultiButton.Text = "&Run Simulations"
        Me.RunMultiButton.UseVisualStyleBackColor = False
        '
        'TitleLabel
        '
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.TitleLabel.Location = New System.Drawing.Point(12, 13)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(472, 32)
        Me.TitleLabel.TabIndex = 0
        Me.TitleLabel.Text = "Run Mulitple Simulations (File Driven)"
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CloseButton
        '
        Me.CloseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CloseButton.Location = New System.Drawing.Point(407, 353)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 28)
        Me.CloseButton.TabIndex = 4
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'OutputFileBox
        '
        Me.OutputFileBox.AccessibleDescription = "Specifies the default directory for WinSRFR log & diagnostic files."
        Me.OutputFileBox.AccessibleName = "Default Log Folder"
        Me.OutputFileBox.Controls.Add(Me.ClearResultsFile)
        Me.OutputFileBox.Controls.Add(Me.OutputInstructions)
        Me.OutputFileBox.Controls.Add(Me.BrowseOutputFileButton)
        Me.OutputFileBox.Controls.Add(Me.OutputFilename)
        Me.OutputFileBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputFileBox.Location = New System.Drawing.Point(10, 190)
        Me.OutputFileBox.Name = "OutputFileBox"
        Me.OutputFileBox.Size = New System.Drawing.Size(472, 115)
        Me.OutputFileBox.TabIndex = 2
        Me.OutputFileBox.TabStop = False
        Me.OutputFileBox.Text = "&Output File"
        '
        'ClearResultsFile
        '
        Me.ClearResultsFile.AutoSize = True
        Me.ClearResultsFile.Location = New System.Drawing.Point(16, 80)
        Me.ClearResultsFile.Name = "ClearResultsFile"
        Me.ClearResultsFile.Size = New System.Drawing.Size(172, 21)
        Me.ClearResultsFile.TabIndex = 4
        Me.ClearResultsFile.Text = "Pre-&clear output file"
        Me.ClearResultsFile.UseVisualStyleBackColor = True
        '
        'OutputInstructions
        '
        Me.OutputInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputInstructions.Location = New System.Drawing.Point(16, 25)
        Me.OutputInstructions.Name = "OutputInstructions"
        Me.OutputInstructions.Size = New System.Drawing.Size(440, 21)
        Me.OutputInstructions.TabIndex = 3
        Me.OutputInstructions.Text = "Enter the name of the .txt of .csv Tabulated Script output file."
        '
        'BrowseOutputFileButton
        '
        Me.BrowseOutputFileButton.AccessibleDescription = "Browses for WinSRFR's log & diagnostic folder."
        Me.BrowseOutputFileButton.AccessibleName = "Browse Log Folder"
        Me.BrowseOutputFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseOutputFileButton.Location = New System.Drawing.Point(384, 80)
        Me.BrowseOutputFileButton.Name = "BrowseOutputFileButton"
        Me.BrowseOutputFileButton.Size = New System.Drawing.Size(72, 25)
        Me.BrowseOutputFileButton.TabIndex = 1
        Me.BrowseOutputFileButton.Text = "&Browse"
        '
        'OutputFilename
        '
        Me.OutputFilename.AccessibleDescription = "WinSRFR's log & diagnostic folder."
        Me.OutputFilename.AccessibleName = "Log Folder"
        Me.OutputFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputFilename.Location = New System.Drawing.Point(16, 50)
        Me.OutputFilename.Name = "OutputFilename"
        Me.OutputFilename.Size = New System.Drawing.Size(440, 23)
        Me.OutputFilename.TabIndex = 0
        '
        'InputFileBox
        '
        Me.InputFileBox.AccessibleDescription = "Specifies the default directory for WinSRFR log & diagnostic files."
        Me.InputFileBox.AccessibleName = "Default Log Folder"
        Me.InputFileBox.Controls.Add(Me.InputInstructions)
        Me.InputFileBox.Controls.Add(Me.BrowseInputFileButton)
        Me.InputFileBox.Controls.Add(Me.InputFilename)
        Me.InputFileBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputFileBox.Location = New System.Drawing.Point(10, 57)
        Me.InputFileBox.Name = "InputFileBox"
        Me.InputFileBox.Size = New System.Drawing.Size(472, 115)
        Me.InputFileBox.TabIndex = 1
        Me.InputFileBox.TabStop = False
        Me.InputFileBox.Text = "&Input File"
        '
        'InputInstructions
        '
        Me.InputInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputInstructions.Location = New System.Drawing.Point(16, 25)
        Me.InputInstructions.Name = "InputInstructions"
        Me.InputInstructions.Size = New System.Drawing.Size(440, 21)
        Me.InputInstructions.TabIndex = 0
        Me.InputInstructions.Text = "Enter the name of the .txt or .csv Tabulated Script input file."
        '
        'BrowseInputFileButton
        '
        Me.BrowseInputFileButton.AccessibleDescription = "Browses for WinSRFR's log & diagnostic folder."
        Me.BrowseInputFileButton.AccessibleName = "Browse Log Folder"
        Me.BrowseInputFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseInputFileButton.Location = New System.Drawing.Point(384, 80)
        Me.BrowseInputFileButton.Name = "BrowseInputFileButton"
        Me.BrowseInputFileButton.Size = New System.Drawing.Size(72, 25)
        Me.BrowseInputFileButton.TabIndex = 2
        Me.BrowseInputFileButton.Text = "&Browse"
        '
        'InputFilename
        '
        Me.InputFilename.AccessibleDescription = "WinSRFR's log & diagnostic folder."
        Me.InputFilename.AccessibleName = "Log Folder"
        Me.InputFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputFilename.Location = New System.Drawing.Point(16, 50)
        Me.InputFilename.Name = "InputFilename"
        Me.InputFilename.Size = New System.Drawing.Size(440, 23)
        Me.InputFilename.TabIndex = 1
        '
        'ShowMessageOnError
        '
        Me.ShowMessageOnError.AutoSize = True
        Me.ShowMessageOnError.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ShowMessageOnError.Location = New System.Drawing.Point(10, 326)
        Me.ShowMessageOnError.Name = "ShowMessageOnError"
        Me.ShowMessageOnError.Size = New System.Drawing.Size(231, 21)
        Me.ShowMessageOnError.TabIndex = 5
        Me.ShowMessageOnError.Text = "Show message on first error"
        Me.ShowMessageOnError.UseVisualStyleBackColor = True
        '
        'RunMultiSimulations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 393)
        Me.Controls.Add(Me.ShowMessageOnError)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.RunMultiButton)
        Me.Controls.Add(Me.OutputFileBox)
        Me.Controls.Add(Me.InputFileBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.HelpButton = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RunMultiSimulations"
        Me.Text = "Run Multiple Simulations"
        Me.OutputFileBox.ResumeLayout(False)
        Me.OutputFileBox.PerformLayout()
        Me.InputFileBox.ResumeLayout(False)
        Me.InputFileBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InputFileBox As DataStore.ctl_GroupBox
    Friend WithEvents BrowseInputFileButton As DataStore.ctl_Button
    Friend WithEvents InputFilename As System.Windows.Forms.TextBox
    Friend WithEvents OutputFileBox As DataStore.ctl_GroupBox
    Friend WithEvents BrowseOutputFileButton As DataStore.ctl_Button
    Friend WithEvents OutputFilename As System.Windows.Forms.TextBox
    Friend WithEvents InputInstructions As DataStore.ctl_Label
    Friend WithEvents OutputInstructions As DataStore.ctl_Label
    Friend WithEvents ClearResultsFile As DataStore.ctl_CheckParameter
    Friend WithEvents RunMultiButton As DataStore.ctl_Button
    Friend WithEvents TitleLabel As DataStore.ctl_Label
    Friend WithEvents CloseButton As DataStore.ctl_Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ShowMessageOnError As DataStore.ctl_CheckParameter
End Class
