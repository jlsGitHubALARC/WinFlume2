﻿
Public Class GettingStarted
    Inherits WizardStep

    Friend WithEvents GettingStartedPanel1 As Panel
    Friend WithEvents GettingStartedPanel2 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GettingStarted))
        Me.GettingStartedPanel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GettingStartedPanel2 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.StepPanel1.SuspendLayout()
        Me.StepPanel2.SuspendLayout()
        Me.GettingStartedPanel1.SuspendLayout()
        Me.GettingStartedPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StepPanel1
        '
        Me.StepPanel1.Controls.Add(Me.GettingStartedPanel1)
        '
        'StepPanel2
        '
        Me.StepPanel2.Controls.Add(Me.GettingStartedPanel2)
        '
        'GettingStartedPanel1
        '
        Me.GettingStartedPanel1.Controls.Add(Me.TextBox1)
        resources.ApplyResources(Me.GettingStartedPanel1, "GettingStartedPanel1")
        Me.GettingStartedPanel1.Name = "GettingStartedPanel1"
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'GettingStartedPanel2
        '
        Me.GettingStartedPanel2.Controls.Add(Me.TextBox2)
        resources.ApplyResources(Me.GettingStartedPanel2, "GettingStartedPanel2")
        Me.GettingStartedPanel2.Name = "GettingStartedPanel2"
        '
        'TextBox2
        '
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.Name = "TextBox2"
        '
        'GettingStarted
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "GettingStarted"
        Me.StepPanel1.ResumeLayout(False)
        Me.StepPanel2.ResumeLayout(False)
        Me.GettingStartedPanel1.ResumeLayout(False)
        Me.GettingStartedPanel1.PerformLayout()
        Me.GettingStartedPanel2.ResumeLayout(False)
        Me.GettingStartedPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    '
    ' The code above is generated by the Visual Studio Designer; do not edit it
    '
    ' The code below is added by the programmer to implement the Wizard Step
    '
    Public Sub New(ByVal WinFlume As WinFlumeForm, ByVal Flume As Flume.FlumeType)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        mWinFlume = WinFlume
        mFlume = Flume
    End Sub

    Public Overrides Function Panel1() As Panel
        Return Me.GettingStartedPanel1
    End Function

    Public Overrides Function Panel2() As Panel
        Return Me.GettingStartedPanel2
    End Function

    Public Overrides Function NextButton() As Boolean
        '
        ' Update the user's Winflume User Name
        '
        Dim username As String = WinFlumeForm.Username.Trim
        Dim dbUsername As New db_GetStringValue(username) With {
            .Title = My.Resources.EnterUsername,
            .Instructions = My.Resources.Username & ":"}
        Dim result As DialogResult = dbUsername.ShowDialog()
        If (result = DialogResult.OK) Then
            username = dbUsername.Value
            WinFlumeForm.Username = username
        End If

        Return MyBase.NextButton()
    End Function

End Class