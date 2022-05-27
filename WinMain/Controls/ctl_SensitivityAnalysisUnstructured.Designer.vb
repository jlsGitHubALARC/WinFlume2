<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctl_SensitivityAnalysisUnstructured
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
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
        'OutputFileBox
        '
        Me.OutputFileBox.AccessibleDescription = "Specifies the default directory for WinSRFR log & diagnostic files."
        Me.OutputFileBox.AccessibleName = "Default Log Folder"
        Me.OutputFileBox.Controls.Add(Me.ClearResultsFile)
        Me.OutputFileBox.Controls.Add(Me.OutputInstructions)
        Me.OutputFileBox.Controls.Add(Me.BrowseOutputFileButton)
        Me.OutputFileBox.Controls.Add(Me.OutputFilename)
        Me.OutputFileBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputFileBox.Location = New System.Drawing.Point(15, 610)
        Me.OutputFileBox.Name = "OutputFileBox"
        Me.OutputFileBox.Size = New System.Drawing.Size(710, 115)
        Me.OutputFileBox.TabIndex = 1
        Me.OutputFileBox.TabStop = False
        Me.OutputFileBox.Text = "&Output File"
        '
        'ClearResultsFile
        '
        Me.ClearResultsFile.AlwaysChecked = False
        Me.ClearResultsFile.AutoSize = True
        Me.ClearResultsFile.ErrorMessage = Nothing
        Me.ClearResultsFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearResultsFile.Location = New System.Drawing.Point(15, 80)
        Me.ClearResultsFile.Name = "ClearResultsFile"
        Me.ClearResultsFile.Size = New System.Drawing.Size(178, 22)
        Me.ClearResultsFile.TabIndex = 3
        Me.ClearResultsFile.Text = "Pre-&clear output file"
        Me.ClearResultsFile.UncheckAttemptMessage = Nothing
        Me.ClearResultsFile.UseVisualStyleBackColor = True
        '
        'OutputInstructions
        '
        Me.OutputInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputInstructions.Location = New System.Drawing.Point(16, 25)
        Me.OutputInstructions.Name = "OutputInstructions"
        Me.OutputInstructions.Size = New System.Drawing.Size(610, 21)
        Me.OutputInstructions.TabIndex = 0
        Me.OutputInstructions.Text = "Enter the name of the .txt of .csv Tabulated Script output file"
        '
        'BrowseOutputFileButton
        '
        Me.BrowseOutputFileButton.AccessibleDescription = "Browses for WinSRFR's log & diagnostic folder."
        Me.BrowseOutputFileButton.AccessibleName = "Browse Log Folder"
        Me.BrowseOutputFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseOutputFileButton.Location = New System.Drawing.Point(632, 50)
        Me.BrowseOutputFileButton.Name = "BrowseOutputFileButton"
        Me.BrowseOutputFileButton.Size = New System.Drawing.Size(72, 25)
        Me.BrowseOutputFileButton.TabIndex = 2
        Me.BrowseOutputFileButton.Text = "&Browse"
        '
        'OutputFilename
        '
        Me.OutputFilename.AccessibleDescription = "WinSRFR's log & diagnostic folder."
        Me.OutputFilename.AccessibleName = "Log Folder"
        Me.OutputFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputFilename.Location = New System.Drawing.Point(16, 50)
        Me.OutputFilename.Name = "OutputFilename"
        Me.OutputFilename.Size = New System.Drawing.Size(610, 26)
        Me.OutputFilename.TabIndex = 1
        '
        'InputFileBox
        '
        Me.InputFileBox.AccessibleDescription = "Specifies the default directory for WinSRFR log & diagnostic files."
        Me.InputFileBox.AccessibleName = "Default Log Folder"
        Me.InputFileBox.Controls.Add(Me.InputInstructions)
        Me.InputFileBox.Controls.Add(Me.BrowseInputFileButton)
        Me.InputFileBox.Controls.Add(Me.InputFilename)
        Me.InputFileBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputFileBox.Location = New System.Drawing.Point(15, 510)
        Me.InputFileBox.Name = "InputFileBox"
        Me.InputFileBox.Size = New System.Drawing.Size(710, 90)
        Me.InputFileBox.TabIndex = 0
        Me.InputFileBox.TabStop = False
        Me.InputFileBox.Text = "&Input File"
        '
        'InputInstructions
        '
        Me.InputInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputInstructions.Location = New System.Drawing.Point(16, 25)
        Me.InputInstructions.Name = "InputInstructions"
        Me.InputInstructions.Size = New System.Drawing.Size(610, 21)
        Me.InputInstructions.TabIndex = 0
        Me.InputInstructions.Text = "Enter the name of the .txt or .csv Tabulated Script input file"
        '
        'BrowseInputFileButton
        '
        Me.BrowseInputFileButton.AccessibleDescription = "Browses for WinSRFR's log & diagnostic folder."
        Me.BrowseInputFileButton.AccessibleName = "Browse Log Folder"
        Me.BrowseInputFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrowseInputFileButton.Location = New System.Drawing.Point(632, 50)
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
        Me.InputFilename.Size = New System.Drawing.Size(610, 26)
        Me.InputFilename.TabIndex = 1
        '
        'ctl_SensitivityAnalysisUnstructured
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OutputFileBox)
        Me.Controls.Add(Me.InputFileBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_SensitivityAnalysisUnstructured"
        Me.Size = New System.Drawing.Size(735, 735)
        Me.OutputFileBox.ResumeLayout(False)
        Me.OutputFileBox.PerformLayout()
        Me.InputFileBox.ResumeLayout(False)
        Me.InputFileBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

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
