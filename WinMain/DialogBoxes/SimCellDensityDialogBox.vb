
'*************************************************************************************************************
' Cell Density - selects the default distance (X) cell density for the simulation
'*************************************************************************************************************
Imports DataStore

Public Class SimCellDensityDialogBox
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _unit As Unit)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeSimCellDensityDialogBox(_unit)

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
    Friend WithEvents CellDensityGroup As DataStore.ctl_GroupBox
    Friend WithEvents NumericValue As DataStore.ctl_RadioButton
    Friend WithEvents ExtraFineGrid As DataStore.ctl_RadioButton
    Friend WithEvents FineGrid As DataStore.ctl_RadioButton
    Friend WithEvents MediumGrid As DataStore.ctl_RadioButton
    Friend WithEvents CoarseGrid As DataStore.ctl_RadioButton
    Friend WithEvents NumericCellDensity As System.Windows.Forms.NumericUpDown
    Friend WithEvents OkCellDensity As DataStore.ctl_Button
    Friend WithEvents CancelCellDensity As DataStore.ctl_Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.CellDensityGroup = New DataStore.ctl_GroupBox
        Me.NumericCellDensity = New System.Windows.Forms.NumericUpDown
        Me.CoarseGrid = New DataStore.ctl_RadioButton
        Me.MediumGrid = New DataStore.ctl_RadioButton
        Me.FineGrid = New DataStore.ctl_RadioButton
        Me.ExtraFineGrid = New DataStore.ctl_RadioButton
        Me.NumericValue = New DataStore.ctl_RadioButton
        Me.OkCellDensity = New DataStore.ctl_Button
        Me.CancelCellDensity = New DataStore.ctl_Button
        Me.CellDensityGroup.SuspendLayout()
        CType(Me.NumericCellDensity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CellDensityGroup
        '
        Me.CellDensityGroup.AccessibleDescription = "Selects the number of cells to use during the simulation run."
        Me.CellDensityGroup.AccessibleName = "Cell Density"
        Me.CellDensityGroup.Controls.Add(Me.NumericCellDensity)
        Me.CellDensityGroup.Controls.Add(Me.CoarseGrid)
        Me.CellDensityGroup.Controls.Add(Me.MediumGrid)
        Me.CellDensityGroup.Controls.Add(Me.FineGrid)
        Me.CellDensityGroup.Controls.Add(Me.ExtraFineGrid)
        Me.CellDensityGroup.Controls.Add(Me.NumericValue)
        Me.CellDensityGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CellDensityGroup.Location = New System.Drawing.Point(16, 16)
        Me.CellDensityGroup.Name = "CellDensityGroup"
        Me.CellDensityGroup.Size = New System.Drawing.Size(259, 168)
        Me.CellDensityGroup.TabIndex = 0
        Me.CellDensityGroup.TabStop = False
        Me.CellDensityGroup.Text = "Cell Density (Solution Grid)"
        '
        'NumericCellDensity
        '
        Me.NumericCellDensity.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericCellDensity.Location = New System.Drawing.Point(179, 128)
        Me.NumericCellDensity.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericCellDensity.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericCellDensity.Name = "NumericCellDensity"
        Me.NumericCellDensity.Size = New System.Drawing.Size(64, 23)
        Me.NumericCellDensity.TabIndex = 5
        Me.NumericCellDensity.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'CoarseGrid
        '
        Me.CoarseGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CoarseGrid.Location = New System.Drawing.Point(16, 24)
        Me.CoarseGrid.Name = "CoarseGrid"
        Me.CoarseGrid.Size = New System.Drawing.Size(227, 24)
        Me.CoarseGrid.TabIndex = 0
        Me.CoarseGrid.Text = "&20 - Coarse"
        '
        'MediumGrid
        '
        Me.MediumGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MediumGrid.Location = New System.Drawing.Point(16, 48)
        Me.MediumGrid.Name = "MediumGrid"
        Me.MediumGrid.Size = New System.Drawing.Size(227, 24)
        Me.MediumGrid.TabIndex = 1
        Me.MediumGrid.Text = "&40 - Medium"
        '
        'FineGrid
        '
        Me.FineGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FineGrid.Location = New System.Drawing.Point(16, 72)
        Me.FineGrid.Name = "FineGrid"
        Me.FineGrid.Size = New System.Drawing.Size(227, 24)
        Me.FineGrid.TabIndex = 2
        Me.FineGrid.Text = "&60 - Fine"
        '
        'ExtraFineGrid
        '
        Me.ExtraFineGrid.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtraFineGrid.Location = New System.Drawing.Point(16, 96)
        Me.ExtraFineGrid.Name = "ExtraFineGrid"
        Me.ExtraFineGrid.Size = New System.Drawing.Size(227, 24)
        Me.ExtraFineGrid.TabIndex = 3
        Me.ExtraFineGrid.Text = "&80 - Extra Fine"
        '
        'NumericValue
        '
        Me.NumericValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericValue.Location = New System.Drawing.Point(16, 128)
        Me.NumericValue.Name = "NumericValue"
        Me.NumericValue.Size = New System.Drawing.Size(153, 24)
        Me.NumericValue.TabIndex = 4
        Me.NumericValue.Text = "&Numeric Value"
        '
        'OkCellDensity
        '
        Me.OkCellDensity.AccessibleDescription = "Accepts the cell density changes."
        Me.OkCellDensity.AccessibleName = "OK Button"
        Me.OkCellDensity.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.OkCellDensity.Enabled = False
        Me.OkCellDensity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkCellDensity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OkCellDensity.Location = New System.Drawing.Point(16, 201)
        Me.OkCellDensity.Name = "OkCellDensity"
        Me.OkCellDensity.Size = New System.Drawing.Size(80, 24)
        Me.OkCellDensity.TabIndex = 1
        Me.OkCellDensity.Text = "&Ok"
        Me.OkCellDensity.UseVisualStyleBackColor = False
        '
        'CancelCellDensity
        '
        Me.CancelCellDensity.AccessibleDescription = "Rejects the cell density changes."
        Me.CancelCellDensity.AccessibleName = "Cancel Button"
        Me.CancelCellDensity.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelCellDensity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelCellDensity.Location = New System.Drawing.Point(195, 201)
        Me.CancelCellDensity.Name = "CancelCellDensity"
        Me.CancelCellDensity.Size = New System.Drawing.Size(80, 24)
        Me.CancelCellDensity.TabIndex = 2
        Me.CancelCellDensity.Text = "&Cancel"
        '
        'SimCellDensityDialogBox
        '
        Me.AccessibleDescription = "Allows editing of the cell density used during a simulation run."
        Me.AccessibleName = "Simulation Cell Density Dialog Box"
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.ClientSize = New System.Drawing.Size(292, 237)
        Me.Controls.Add(Me.OkCellDensity)
        Me.Controls.Add(Me.CancelCellDensity)
        Me.Controls.Add(Me.CellDensityGroup)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SimCellDensityDialogBox"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simulation Cell Density"
        Me.CellDensityGroup.ResumeLayout(False)
        CType(Me.NumericCellDensity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Member Data "

    Private mMyStore As ObjectNode
    Private mSrfrCriteria As SrfrCriteria

    Private mCellDensity As Integer

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Initialization "
    '
    ' Initialize the dialog box controls using values from the specified irrigation Unit
    '
    Private Sub InitializeSimCellDensityDialogBox(ByVal _unit As Unit)

        If (_unit IsNot Nothing) Then

            Me.Text = mDictionary.ControlText(Me)

            ' Get references from Unit
            mMyStore = _unit.MyStore
            mSrfrCriteria = _unit.SrfrCriteriaRef

            ' Get the Cell Density
            mCellDensity = mSrfrCriteria.CellDensity.Value

            If (mCellDensity < NumericCellDensity.Minimum) Then
                mCellDensity = NumericCellDensity.Minimum
            End If

            If (mCellDensity > NumericCellDensity.Maximum) Then
                mCellDensity = NumericCellDensity.Maximum
            End If

            ' Update the Numeric Cell Density value
            NumericCellDensity.Value = mCellDensity
            NumericCellDensity.Enabled = False

            ' Update the radio buttons
            If (mCellDensity = CellDensities.Coarse) Then
                CoarseGrid.Checked = True
            ElseIf (mCellDensity = CellDensities.Medium) Then
                MediumGrid.Checked = True
            ElseIf (mCellDensity = CellDensities.Fine) Then
                FineGrid.Checked = True
            ElseIf (mCellDensity = CellDensities.ExtraFine) Then
                ExtraFineGrid.Checked = True
            Else
                NumericValue.Checked = True
                NumericCellDensity.Enabled = True
            End If

            ' Load the UI with these values
            UpdateCellDensity()
        End If

    End Sub

#End Region

#Region " UI Methods "
    '
    ' Update the Cell Density selections
    '
    Private Sub UpdateCellDensity()

        If (mSrfrCriteria IsNot Nothing) Then

            ' Update the Numeric Cell Density value
            NumericCellDensity.Value = mCellDensity
            NumericCellDensity.Refresh()

            ' Update the OK buttons
            If Not (mCellDensity = mSrfrCriteria.CellDensity.Value) Then
                ' Something has changed; enable OK button
                OkCellDensity.Enabled = True
            Else
                OkCellDensity.Enabled = False
            End If
        End If

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub CoarseGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CoarseGrid.CheckedChanged
        If (CoarseGrid.Checked) Then
            mCellDensity = CellDensities.Coarse
            NumericCellDensity.Enabled = False
            UpdateCellDensity()
        End If
    End Sub

    Private Sub MediumGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MediumGrid.CheckedChanged
        If (MediumGrid.Checked) Then
            mCellDensity = CellDensities.Medium
            NumericCellDensity.Enabled = False
            UpdateCellDensity()
        End If
    End Sub

    Private Sub FineGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FineGrid.CheckedChanged
        If (FineGrid.Checked) Then
            mCellDensity = CellDensities.Fine
            NumericCellDensity.Enabled = False
            UpdateCellDensity()
        End If
    End Sub

    Private Sub ExtraFineGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ExtraFineGrid.CheckedChanged
        If (ExtraFineGrid.Checked) Then
            mCellDensity = CellDensities.ExtraFine
            NumericCellDensity.Enabled = False
            UpdateCellDensity()
        End If
    End Sub

    Private Sub NumericValue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NumericValue.CheckedChanged
        If (NumericValue.Checked) Then
            mCellDensity = NumericCellDensity.Value
            NumericCellDensity.Enabled = True
            UpdateCellDensity()
        End If
    End Sub

    Private Sub NumericCellDensity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles NumericCellDensity.ValueChanged
        If (NumericValue.Checked) Then
            mCellDensity = NumericCellDensity.Value
            UpdateCellDensity()
        End If
    End Sub

    Private Sub OkCellDensity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OkCellDensity.Click
        '
        ' Save the new Cell Density value
        '
        Dim _cellDensity As DataStore.IntegerParameter = mSrfrCriteria.CellDensity
        If Not (_cellDensity.Value = mCellDensity) Then

            ' Mark this as an Undo point
            Dim undoText As String = Me.Text.Replace("&", "")
            mMyStore.MarkForUndo(undoText)

            _cellDensity.Value = mCellDensity
            _cellDensity.Source = DataStore.Globals.ValueSources.UserEntered
            mSrfrCriteria.CellDensity = _cellDensity
        End If

        ' Close the dialog box
        Me.Close()

    End Sub

    Private Sub SimCellDensityDialogBox_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:SimulationInputs", 1600)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:SimulationInputs", 1600)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class
