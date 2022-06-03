<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_SensitivityAnalysisUnstructured
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ShowMessageOnError = New DataStore.ctl_CheckParameter()
        Me.CloseButton = New DataStore.ctl_Button()
        Me.RunMultiButton = New DataStore.ctl_Button()
        Me.OutputFileBox = New DataStore.ctl_GroupBox()
        Me.ClearResultsFile = New DataStore.ctl_CheckParameter()
        Me.OutputInstructions = New DataStore.ctl_Label()
        Me.BrowseOutputFileButton = New DataStore.ctl_Button()
        Me.OutputFilename = New System.Windows.Forms.TextBox()
        Me.InputFileBox = New DataStore.ctl_GroupBox()
        Me.InputInstructions = New DataStore.ctl_Label()
        Me.BrowseInputFileButton = New DataStore.ctl_Button()
        Me.InputFilename = New System.Windows.Forms.TextBox()
        Me.OutputFileBox.SuspendLayout()
        Me.InputFileBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ShowMessageOnError
        '
        Me.ShowMessageOnError.AlwaysChecked = False
        Me.ShowMessageOnError.AutoSize = True
        Me.ShowMessageOnError.ErrorMessage = Nothing
        Me.ShowMessageOnError.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ShowMessageOnError.Location = New System.Drawing.Point(24, 570)
        Me.ShowMessageOnError.Margin = New System.Windows.Forms.Padding(4)
        Me.ShowMessageOnError.Name = "ShowMessageOnError"
        Me.ShowMessageOnError.Size = New System.Drawing.Size(270, 24)
        Me.ShowMessageOnError.TabIndex = 11
        Me.ShowMessageOnError.Text = "Show message on first error"
        Me.ShowMessageOnError.UncheckAttemptMessage = Nothing
        Me.ShowMessageOnError.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CloseButton.Location = New System.Drawing.Point(553, 604)
        Me.CloseButton.Margin = New System.Windows.Forms.Padding(4)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(90, 30)
        Me.CloseButton.TabIndex = 10
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'RunMultiButton
        '
        Me.RunMultiButton.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.RunMultiButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RunMultiButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RunMultiButton.Location = New System.Drawing.Point(24, 604)
        Me.RunMultiButton.Margin = New System.Windows.Forms.Padding(4)
        Me.RunMultiButton.Name = "RunMultiButton"
        Me.RunMultiButton.Size = New System.Drawing.Size(289, 35)
        Me.RunMultiButton.TabIndex = 9
        Me.RunMultiButton.Text = "&Run Simulations"
        Me.RunMultiButton.UseVisualStyleBackColor = False
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
        Me.OutputFileBox.Location = New System.Drawing.Point(4, 319)
        Me.OutputFileBox.Margin = New System.Windows.Forms.Padding(4)
        Me.OutputFileBox.Name = "OutputFileBox"
        Me.OutputFileBox.Padding = New System.Windows.Forms.Padding(4)
        Me.OutputFileBox.Size = New System.Drawing.Size(745, 125)
        Me.OutputFileBox.TabIndex = 8
        Me.OutputFileBox.TabStop = False
        Me.OutputFileBox.Text = "&Output File"
        '
        'ClearResultsFile
        '
        Me.ClearResultsFile.AlwaysChecked = False
        Me.ClearResultsFile.AutoSize = True
        Me.ClearResultsFile.ErrorMessage = Nothing
        Me.ClearResultsFile.Location = New System.Drawing.Point(20, 91)
        Me.ClearResultsFile.Margin = New System.Windows.Forms.Padding(4)
        Me.ClearResultsFile.Name = "ClearResultsFile"
        Me.ClearResultsFile.Size = New System.Drawing.Size(199, 24)
        Me.ClearResultsFile.TabIndex = 4
        Me.ClearResultsFile.Text = "Pre-&clear output file"
        Me.ClearResultsFile.UncheckAttemptMessage = Nothing
        Me.ClearResultsFile.UseVisualStyleBackColor = True
        '
        'OutputInstructions
        '
        Me.OutputInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputInstructions.Location = New System.Drawing.Point(20, 27)
        Me.OutputInstructions.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.OutputInstructions.Name = "OutputInstructions"
        Me.OutputInstructions.Size = New System.Drawing.Size(550, 26)
        Me.OutputInstructions.TabIndex = 3
        Me.OutputInstructions.Text = "Enter the name of the .txt of .csv Tabulated Script output file."
        '
        'BrowseOutputFileButton
        '
        Me.BrowseOutputFileButton.AccessibleDescription = "Browses for WinSRFR's log & diagnostic folder."
        Me.BrowseOutputFileButton.AccessibleName = "Browse Log Folder"
        Me.BrowseOutputFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseOutputFileButton.Location = New System.Drawing.Point(647, 52)
        Me.BrowseOutputFileButton.Margin = New System.Windows.Forms.Padding(4)
        Me.BrowseOutputFileButton.Name = "BrowseOutputFileButton"
        Me.BrowseOutputFileButton.Size = New System.Drawing.Size(90, 30)
        Me.BrowseOutputFileButton.TabIndex = 1
        Me.BrowseOutputFileButton.Text = "&Browse"
        '
        'OutputFilename
        '
        Me.OutputFilename.AccessibleDescription = "WinSRFR's log & diagnostic folder."
        Me.OutputFilename.AccessibleName = "Log Folder"
        Me.OutputFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputFilename.Location = New System.Drawing.Point(20, 56)
        Me.OutputFilename.Margin = New System.Windows.Forms.Padding(4)
        Me.OutputFilename.Name = "OutputFilename"
        Me.OutputFilename.Size = New System.Drawing.Size(619, 26)
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
        Me.InputFileBox.Location = New System.Drawing.Point(4, 153)
        Me.InputFileBox.Margin = New System.Windows.Forms.Padding(4)
        Me.InputFileBox.Name = "InputFileBox"
        Me.InputFileBox.Padding = New System.Windows.Forms.Padding(4)
        Me.InputFileBox.Size = New System.Drawing.Size(745, 90)
        Me.InputFileBox.TabIndex = 7
        Me.InputFileBox.TabStop = False
        Me.InputFileBox.Text = "&Input File"
        '
        'InputInstructions
        '
        Me.InputInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputInstructions.Location = New System.Drawing.Point(20, 24)
        Me.InputInstructions.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.InputInstructions.Name = "InputInstructions"
        Me.InputInstructions.Size = New System.Drawing.Size(550, 26)
        Me.InputInstructions.TabIndex = 0
        Me.InputInstructions.Text = "Enter the name of the .txt or .csv Tabulated Script input file."
        '
        'BrowseInputFileButton
        '
        Me.BrowseInputFileButton.AccessibleDescription = "Browses for WinSRFR's log & diagnostic folder."
        Me.BrowseInputFileButton.AccessibleName = "Browse Log Folder"
        Me.BrowseInputFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseInputFileButton.Location = New System.Drawing.Point(647, 47)
        Me.BrowseInputFileButton.Margin = New System.Windows.Forms.Padding(4)
        Me.BrowseInputFileButton.Name = "BrowseInputFileButton"
        Me.BrowseInputFileButton.Size = New System.Drawing.Size(90, 30)
        Me.BrowseInputFileButton.TabIndex = 2
        Me.BrowseInputFileButton.Text = "&Browse"
        '
        'InputFilename
        '
        Me.InputFilename.AccessibleDescription = "WinSRFR's log & diagnostic folder."
        Me.InputFilename.AccessibleName = "Log Folder"
        Me.InputFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputFilename.Location = New System.Drawing.Point(20, 50)
        Me.InputFilename.Margin = New System.Windows.Forms.Padding(4)
        Me.InputFilename.Name = "InputFilename"
        Me.InputFilename.Size = New System.Drawing.Size(619, 26)
        Me.InputFilename.TabIndex = 1
        '
        'ctl_SensitivityAnalysisUnstructured
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ShowMessageOnError)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.RunMultiButton)
        Me.Controls.Add(Me.OutputFileBox)
        Me.Controls.Add(Me.InputFileBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_SensitivityAnalysisUnstructured"
        Me.Size = New System.Drawing.Size(770, 710)
        Me.OutputFileBox.ResumeLayout(False)
        Me.OutputFileBox.PerformLayout()
        Me.InputFileBox.ResumeLayout(False)
        Me.InputFileBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ShowMessageOnError As DataStore.ctl_CheckParameter
    Friend WithEvents CloseButton As DataStore.ctl_Button
    Friend WithEvents RunMultiButton As DataStore.ctl_Button
    Friend WithEvents OutputFileBox As DataStore.ctl_GroupBox
    Friend WithEvents ClearResultsFile As DataStore.ctl_CheckParameter
    Friend WithEvents OutputInstructions As DataStore.ctl_Label
    Friend WithEvents BrowseOutputFileButton As DataStore.ctl_Button
    Friend WithEvents OutputFilename As TextBox
    Friend WithEvents InputFileBox As DataStore.ctl_GroupBox
    Friend WithEvents InputInstructions As DataStore.ctl_Label
    Friend WithEvents BrowseInputFileButton As DataStore.ctl_Button
    Friend WithEvents InputFilename As TextBox
End Class
