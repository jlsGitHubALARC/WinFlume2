
'*************************************************************************************************************
' ctl_ProbePenetrationAnalysis - UI for Propbe Penetration infiltration analyses
'*************************************************************************************************************
Imports System
Imports DataStore

Public Class ctl_ProbePenetrationAnalysis
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
    Friend WithEvents ProbePenetrationBox As DataStore.ctl_GroupBox
    Friend WithEvents ProbePenetrationDescription As DataStore.ctl_Label
    Friend WithEvents ProbePenetrationInstructions As DataStore.ctl_Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ProbePenetrationBox = New DataStore.ctl_GroupBox
        Me.ProbePenetrationInstructions = New DataStore.ctl_Label
        Me.ProbePenetrationDescription = New DataStore.ctl_Label
        Me.ProbePenetrationBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProbePenetrationBox
        '
        Me.ProbePenetrationBox.AccessibleDescription = "Evaluates the performance of an irrigation using probed infiltrated depth measure" & _
            "ments.  Infilitration characteristics are not estimated."
        Me.ProbePenetrationBox.AccessibleName = "Probe Penetration Analysis"
        Me.ProbePenetrationBox.Controls.Add(Me.ProbePenetrationInstructions)
        Me.ProbePenetrationBox.Controls.Add(Me.ProbePenetrationDescription)
        Me.ProbePenetrationBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProbePenetrationBox.Location = New System.Drawing.Point(8, 6)
        Me.ProbePenetrationBox.Name = "ProbePenetrationBox"
        Me.ProbePenetrationBox.Size = New System.Drawing.Size(400, 414)
        Me.ProbePenetrationBox.TabIndex = 3
        Me.ProbePenetrationBox.TabStop = False
        Me.ProbePenetrationBox.Text = "Probe Penetration Analysis"
        '
        'ProbePenetrationInstructions
        '
        Me.ProbePenetrationInstructions.BackColor = System.Drawing.SystemColors.Control
        Me.ProbePenetrationInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProbePenetrationInstructions.Location = New System.Drawing.Point(40, 144)
        Me.ProbePenetrationInstructions.Name = "ProbePenetrationInstructions"
        Me.ProbePenetrationInstructions.Size = New System.Drawing.Size(320, 48)
        Me.ProbePenetrationInstructions.TabIndex = 1
        Me.ProbePenetrationInstructions.Text = "Press the Summarize Analysis button to generate a performance analysis for this i" & _
            "rrigation."
        Me.ProbePenetrationInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProbePenetrationDescription
        '
        Me.ProbePenetrationDescription.BackColor = System.Drawing.SystemColors.Control
        Me.ProbePenetrationDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProbePenetrationDescription.Location = New System.Drawing.Point(56, 64)
        Me.ProbePenetrationDescription.Name = "ProbePenetrationDescription"
        Me.ProbePenetrationDescription.Size = New System.Drawing.Size(288, 40)
        Me.ProbePenetrationDescription.TabIndex = 0
        Me.ProbePenetrationDescription.Text = "The Probe Penetration Analysis does not estimate Infiltration Parameters."
        Me.ProbePenetrationDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ctl_ProbePenetrationAnalysis
        '
        Me.Controls.Add(Me.ProbePenetrationBox)
        Me.Name = "ctl_ProbePenetrationAnalysis"
        Me.Size = New System.Drawing.Size(415, 423)
        Me.ProbePenetrationBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize

        Try
            ' Adjust control heights
            Dim ctrlHeight As Integer = Me.Height

            Me.ProbePenetrationBox.Height = ctrlHeight - 9

        Catch ex As Exception

        End Try

    End Sub

#End Region

End Class
