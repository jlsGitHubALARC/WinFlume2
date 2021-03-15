<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_SurfaceVolumeEstimated
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
        Me.components = New System.ComponentModel.Container
        Me.EstimatedSurfaceVolumesControl = New DataStore.ctl_DataTableParameter
        Me.SurfaceVolumeInstructions = New WinMain.ErrorRichTextBox
        Me.EW2ptSurfaceVolumesControl = New DataStore.ctl_DataTableParameter
        Me.RoughnessControl = New WinMain.ctl_RoughnessLite
        CType(Me.EstimatedSurfaceVolumesControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EW2ptSurfaceVolumesControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EstimatedSurfaceVolumesControl
        '
        Me.EstimatedSurfaceVolumesControl.AllRowsFixed = False
        Me.EstimatedSurfaceVolumesControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.EstimatedSurfaceVolumesControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.EstimatedSurfaceVolumesControl.CaptionText = "Estimated Surface Volumes"
        Me.EstimatedSurfaceVolumesControl.CausesValidation = False
        Me.EstimatedSurfaceVolumesControl.ColumnWidthRatios = Nothing
        Me.EstimatedSurfaceVolumesControl.DataMember = ""
        Me.EstimatedSurfaceVolumesControl.EnableSaveActions = False
        Me.EstimatedSurfaceVolumesControl.FirstColumnIncreases = True
        Me.EstimatedSurfaceVolumesControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.EstimatedSurfaceVolumesControl.FirstColumnMinimum = 0
        Me.EstimatedSurfaceVolumesControl.FirstRowFixed = True
        Me.EstimatedSurfaceVolumesControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimatedSurfaceVolumesControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.EstimatedSurfaceVolumesControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EstimatedSurfaceVolumesControl.Location = New System.Drawing.Point(370, 7)
        Me.EstimatedSurfaceVolumesControl.MaxRows = 50
        Me.EstimatedSurfaceVolumesControl.MinRows = 0
        Me.EstimatedSurfaceVolumesControl.Name = "EstimatedSurfaceVolumesControl"
        Me.EstimatedSurfaceVolumesControl.PasteDisabled = False
        Me.EstimatedSurfaceVolumesControl.SecondColumnIncreases = False
        Me.EstimatedSurfaceVolumesControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.EstimatedSurfaceVolumesControl.SecondColumnMinimum = 0
        Me.EstimatedSurfaceVolumesControl.Size = New System.Drawing.Size(406, 184)
        Me.EstimatedSurfaceVolumesControl.TabIndex = 2
        Me.EstimatedSurfaceVolumesControl.TableReadonly = False
        '
        'SurfaceVolumeInstructions
        '
        Me.SurfaceVolumeInstructions.AccessibleDescription = "Instructions and help for entering station flow depth data"
        Me.SurfaceVolumeInstructions.AccessibleName = "Flow Depth Measurements Instructions"
        Me.SurfaceVolumeInstructions.BackColor = System.Drawing.SystemColors.Info
        Me.SurfaceVolumeInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SurfaceVolumeInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SurfaceVolumeInstructions.ForeColor = System.Drawing.SystemColors.InfoText
        Me.SurfaceVolumeInstructions.Location = New System.Drawing.Point(370, 198)
        Me.SurfaceVolumeInstructions.Margin = New System.Windows.Forms.Padding(4)
        Me.SurfaceVolumeInstructions.Name = "SurfaceVolumeInstructions"
        Me.SurfaceVolumeInstructions.ReadOnly = True
        Me.SurfaceVolumeInstructions.Size = New System.Drawing.Size(406, 185)
        Me.SurfaceVolumeInstructions.TabIndex = 4
        Me.SurfaceVolumeInstructions.TabStop = False
        Me.SurfaceVolumeInstructions.Text = ""
        '
        'EW2ptSurfaceVolumesControl
        '
        Me.EW2ptSurfaceVolumesControl.AllRowsFixed = False
        Me.EW2ptSurfaceVolumesControl.CaptionBackColor = System.Drawing.SystemColors.Info
        Me.EW2ptSurfaceVolumesControl.CaptionForeColor = System.Drawing.SystemColors.InfoText
        Me.EW2ptSurfaceVolumesControl.CaptionText = "Estimated Surface Volumes"
        Me.EW2ptSurfaceVolumesControl.CausesValidation = False
        Me.EW2ptSurfaceVolumesControl.ColumnWidthRatios = Nothing
        Me.EW2ptSurfaceVolumesControl.DataMember = ""
        Me.EW2ptSurfaceVolumesControl.EnableSaveActions = False
        Me.EW2ptSurfaceVolumesControl.FirstColumnIncreases = True
        Me.EW2ptSurfaceVolumesControl.FirstColumnMaximum = 1.7976931348623157E+308
        Me.EW2ptSurfaceVolumesControl.FirstColumnMinimum = 0
        Me.EW2ptSurfaceVolumesControl.FirstRowFixed = True
        Me.EW2ptSurfaceVolumesControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EW2ptSurfaceVolumesControl.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.EW2ptSurfaceVolumesControl.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EW2ptSurfaceVolumesControl.Location = New System.Drawing.Point(370, 7)
        Me.EW2ptSurfaceVolumesControl.MaxRows = 50
        Me.EW2ptSurfaceVolumesControl.MinRows = 0
        Me.EW2ptSurfaceVolumesControl.Name = "EW2ptSurfaceVolumesControl"
        Me.EW2ptSurfaceVolumesControl.PasteDisabled = False
        Me.EW2ptSurfaceVolumesControl.SecondColumnIncreases = False
        Me.EW2ptSurfaceVolumesControl.SecondColumnMaximum = 1.7976931348623157E+308
        Me.EW2ptSurfaceVolumesControl.SecondColumnMinimum = 0
        Me.EW2ptSurfaceVolumesControl.Size = New System.Drawing.Size(406, 184)
        Me.EW2ptSurfaceVolumesControl.TabIndex = 3
        Me.EW2ptSurfaceVolumesControl.TableReadonly = False
        '
        'RoughnessControl
        '
        Me.RoughnessControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoughnessControl.Location = New System.Drawing.Point(4, 0)
        Me.RoughnessControl.Name = "RoughnessControl"
        Me.RoughnessControl.Size = New System.Drawing.Size(360, 383)
        Me.RoughnessControl.TabIndex = 0
        '
        'ctl_SurfaceVolumeEstimated
        '
        Me.AccessibleDescription = "Surface volumes estimated at various locations down the field."
        Me.AccessibleName = "Surface Volume (Estimated)"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.EW2ptSurfaceVolumesControl)
        Me.Controls.Add(Me.SurfaceVolumeInstructions)
        Me.Controls.Add(Me.EstimatedSurfaceVolumesControl)
        Me.Controls.Add(Me.RoughnessControl)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctl_SurfaceVolumeEstimated"
        Me.Size = New System.Drawing.Size(780, 400)
        CType(Me.EstimatedSurfaceVolumesControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EW2ptSurfaceVolumesControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RoughnessControl As WinMain.ctl_RoughnessLite
    Friend WithEvents EstimatedSurfaceVolumesControl As DataStore.ctl_DataTableParameter
    Friend WithEvents SurfaceVolumeInstructions As WinMain.ErrorRichTextBox
    Friend WithEvents EW2ptSurfaceVolumesControl As DataStore.ctl_DataTableParameter

End Class
