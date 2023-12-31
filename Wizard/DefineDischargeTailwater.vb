﻿
Public Class DefineDischargeTailwater
    Inherits WizardStep

    Friend WithEvents DischargeTailwaterPanel1 As Panel
    Friend WithEvents DischargeTailwaterPanel2 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DefineDischargeTailwater))
        Me.DischargeTailwaterPanel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DischargeTailwaterPanel2 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.StepPanel1.SuspendLayout()
        Me.StepPanel2.SuspendLayout()
        Me.DischargeTailwaterPanel1.SuspendLayout()
        Me.DischargeTailwaterPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StepPanel1
        '
        Me.StepPanel1.Controls.Add(Me.DischargeTailwaterPanel1)
        '
        'StepPanel2
        '
        Me.StepPanel2.Controls.Add(Me.DischargeTailwaterPanel2)
        '
        'DischargeTailwaterPanel1
        '
        Me.DischargeTailwaterPanel1.Controls.Add(Me.TextBox1)
        resources.ApplyResources(Me.DischargeTailwaterPanel1, "DischargeTailwaterPanel1")
        Me.DischargeTailwaterPanel1.Name = "DischargeTailwaterPanel1"
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'DischargeTailwaterPanel2
        '
        Me.DischargeTailwaterPanel2.Controls.Add(Me.TextBox2)
        resources.ApplyResources(Me.DischargeTailwaterPanel2, "DischargeTailwaterPanel2")
        Me.DischargeTailwaterPanel2.Name = "DischargeTailwaterPanel2"
        '
        'TextBox2
        '
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.Name = "TextBox2"
        '
        'DefineDischargeTailwater
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "DefineDischargeTailwater"
        Me.StepPanel1.ResumeLayout(False)
        Me.StepPanel2.ResumeLayout(False)
        Me.DischargeTailwaterPanel1.ResumeLayout(False)
        Me.DischargeTailwaterPanel1.PerformLayout()
        Me.DischargeTailwaterPanel2.ResumeLayout(False)
        Me.DischargeTailwaterPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    '
    ' The code above is generated by the Visual Studio Designer; do not edit it
    '
    ' The code below is added by the programmer.
    '
    Public Sub New(ByVal WinFlume As WinFlumeForm, ByVal Flume As Flume.FlumeType)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        mWinFlume = WinFlume
        mFlume = Flume
    End Sub

    Public Overrides Function Panel1() As Panel
        Return Me.DischargeTailwaterPanel1
    End Function

    Public Overrides Function Panel2() As Panel
        Return Me.DischargeTailwaterPanel2
    End Function

    Public Overrides Function StartStep() As Boolean
        mWinFlume.WinFlumeTabControl.SelectTab(mWinFlume.DefineCanalTab)
        Dim defineCanal As DefineCanalControl = mWinFlume.GetDefineCanalControl
        defineCanal.DefineCanalTabControl.SelectTab(defineCanal.DischargeTailwaterTab)
        Return MyBase.StartStep()
    End Function

End Class
