
'*************************************************************************************************************
' ctl_ErosionAnalysis - UI for Erosion Parameter estimation analyses
'*************************************************************************************************************
Imports System
Imports DataStore

Public Class ctl_ErosionAnalysis
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
    Friend WithEvents ErosionAnalysisBox As DataStore.ctl_GroupBox
    Friend WithEvents ErosionAnalysisDescription As DataStore.ctl_Label
    Friend WithEvents ErosionAnalysisInstructions As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ErosionAnalysisBox = New DataStore.ctl_GroupBox
        Me.ErosionAnalysisInstructions = New DataStore.ctl_Label
        Me.ErosionAnalysisDescription = New DataStore.ctl_Label
        Me.ErosionAnalysisBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErosionAnalysisBox
        '
        Me.ErosionAnalysisBox.AccessibleDescription = "Evaluates the performance of an irrigation using probed infiltrated depth measure" & _
            "ments.  Infilitration characteristics are not estimated."
        Me.ErosionAnalysisBox.AccessibleName = "Probe Penetration Analysis"
        Me.ErosionAnalysisBox.Controls.Add(Me.ErosionAnalysisInstructions)
        Me.ErosionAnalysisBox.Controls.Add(Me.ErosionAnalysisDescription)
        Me.ErosionAnalysisBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErosionAnalysisBox.Location = New System.Drawing.Point(8, 8)
        Me.ErosionAnalysisBox.Name = "ErosionAnalysisBox"
        Me.ErosionAnalysisBox.Size = New System.Drawing.Size(400, 416)
        Me.ErosionAnalysisBox.TabIndex = 5
        Me.ErosionAnalysisBox.TabStop = False
        Me.ErosionAnalysisBox.Text = "Erosion Parameter Estimation"
        '
        'ErosionAnalysisInstructions
        '
        Me.ErosionAnalysisInstructions.BackColor = System.Drawing.SystemColors.Control
        Me.ErosionAnalysisInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErosionAnalysisInstructions.Location = New System.Drawing.Point(56, 144)
        Me.ErosionAnalysisInstructions.Name = "ErosionAnalysisInstructions"
        Me.ErosionAnalysisInstructions.Size = New System.Drawing.Size(288, 40)
        Me.ErosionAnalysisInstructions.TabIndex = 1
        Me.ErosionAnalysisInstructions.Text = "Press the Estimate Erosion Parameters button to estimate the erosion parameters."
        Me.ErosionAnalysisInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErosionAnalysisDescription
        '
        Me.ErosionAnalysisDescription.BackColor = System.Drawing.SystemColors.Control
        Me.ErosionAnalysisDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErosionAnalysisDescription.Location = New System.Drawing.Point(56, 64)
        Me.ErosionAnalysisDescription.Name = "ErosionAnalysisDescription"
        Me.ErosionAnalysisDescription.Size = New System.Drawing.Size(288, 40)
        Me.ErosionAnalysisDescription.TabIndex = 0
        Me.ErosionAnalysisDescription.Text = "The Erosion Parameter Analysis uses estimates of Infiltration Parameters."
        Me.ErosionAnalysisDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctl_ErosionAnalysis
        '
        Me.Controls.Add(Me.ErosionAnalysisBox)
        Me.Name = "ctl_ErosionAnalysis"
        Me.Size = New System.Drawing.Size(415, 425)
        Me.ErosionAnalysisBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
