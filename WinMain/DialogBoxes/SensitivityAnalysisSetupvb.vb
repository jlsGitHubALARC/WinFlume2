
'************************************************************************************************************
'
'************************************************************************************************************
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows

Imports DataStore
Imports GraphingUI
Imports PrintingUI

Public Class SensitivityAnalysisSetupvb

#Region " Member Data "

    Private mWorldWindow As WorldWindow

    Protected WithEvents mScriptRecorder As ScriptRecorder
    Public ReadOnly Property ScriptRecorder() As ScriptRecorder
        Get
            Return mScriptRecorder
        End Get
    End Property

#End Region

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByRef pWorldWindow As WorldWindow)
        Me.New()

        ' Add any initialization after the InitializeComponent() call.
        mWorldWindow = pWorldWindow
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BrowseInputFileButton_Click(sender As Object, e As EventArgs)

    End Sub
    '
    ' Print / Print Preview
    '
    'Private Sub PrintResultsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    'Handles PrintResultsItem.Click
    '    Print(sender, e)
    'End Sub

    'Private Sub PreviewResultsItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    'Handles PreviewResultsItem.Click
    '    PrintPreview(sender, e)
    'End Sub

End Class
