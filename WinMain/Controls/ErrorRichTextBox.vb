
'**********************************************************************************************
' Class:    ErrorRichTextBox
'
' Desc: Adds error display functionality to a RichTextBox for WinSRFR Analyses.
'
Imports PrintingUi

Public Class ErrorRichTextBox
    Inherits System.Windows.Forms.RichTextBox

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'ErrorRichTextBox
        '
        Me.ReadOnly = True

    End Sub

#End Region

#Region " Member Data "

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Methods "

    Public Sub DisplayLine(ByVal _text As String)
        Try
            AppendLine(Me, _text)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DisplayBoldLine(ByVal _text As String)
        Try
            AppendBoldLine(Me, _text)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DisplayUnderlineLine(ByVal _text As String)
        Try
            AppendUnderlineLine(Me, _text)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DisplayBoldUnderlineLine(ByVal _text As String)
        Try
            AppendBoldUnderlineLine(Me, _text)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DisplayError(ByVal _id As String, ByVal _detail As String)

        ' Add a specific Error to the display
        AppendBoldText(Me, mDictionary.tError.Translated & " - ")
        Try
            AppendLine(Me, _id)
            AdvanceLine(Me)
            AppendLine(Me, _detail)
        Catch ex As Exception
        End Try
        AdvanceLine(Me)

    End Sub

    Public Sub DisplayErrors(ByVal _analysis As Analysis, ByVal _showDetails As Boolean)

        If Not (_analysis Is Nothing) Then
            ' Display entry for each Execution Error
            For Each _error As Analysis.ErrorWarningItem In _analysis.ExecutionErrorItems
                Dim _count As Integer = _error.Count
                Dim _id As String = _error.ID
                Dim _detail As String = _error.Detail

                AppendBoldText(Me, mDictionary.tError.Translated & " - ")
                Try
                    If (1 = _count) Then
                        AppendLine(Me, _id)
                    Else
                        AppendLine(Me, _id + " (" + _count.ToString + "x)")
                    End If
                    ' Add Error Details if requested
                    If (_showDetails) Then
                        Try
                            AdvanceLine(Me)
                            AppendLine(Me, _detail)
                        Catch ex As Exception
                        End Try
                    End If
                Catch ex As Exception
                End Try
                AdvanceLine(Me)
            Next

            ' Display entry for each Setup Error
            For Each _error As Analysis.ErrorWarningItem In _analysis.SetupErrorItems
                Dim _count As Integer = _error.Count
                Dim _id As String = _error.ID
                Dim _detail As String = _error.Detail

                AppendBoldText(Me, mDictionary.tError.Translated & " - ")
                Try
                    If (1 = _count) Then
                        AppendLine(Me, _id)
                    Else
                        AppendLine(Me, _id + " (" + _count.ToString + "x)")
                    End If
                    ' Add Error Details if requested
                    If (_showDetails) Then
                        Try
                            AdvanceLine(Me)
                            AppendLine(Me, _detail)
                        Catch ex As Exception
                        End Try
                    End If
                Catch ex As Exception
                End Try
                AdvanceLine(Me)
            Next
        End If

    End Sub

    Public Sub DisplayWarning(ByVal _id As String, ByVal _detail As String)

        ' Add a specific Warning to the display
        AppendBoldText(Me, mDictionary.tWarning.Translated & " - ")
        Try
            AppendLine(Me, _id)
            AdvanceLine(Me)
            AppendLine(Me, _detail)
        Catch ex As Exception
        End Try
        AdvanceLine(Me)

    End Sub

    Public Sub DisplayWarnings(ByVal _analysis As Analysis, ByVal _showDetails As Boolean)

        If Not (_analysis Is Nothing) Then
            ' Display entry for each Execution Warning
            For Each _warning As Analysis.ErrorWarningItem In _analysis.ExecutionWarningItems
                Dim _count As Integer = _warning.Count
                Dim _id As String = _warning.ID
                Dim _detail As String = _warning.Detail

                AppendBoldText(Me, mDictionary.tWarning.Translated & " - ")
                Try
                    If (0 < _id.Length) Then
                        If (1 = _count) Then
                            AppendLine(Me, _id)
                        Else
                            AppendLine(Me, _id + "(" + _count.ToString + "x)")
                        End If
                        AdvanceLine(Me)
                    End If
                    ' Add Warning Details if requested
                    If (_showDetails) Then
                        Try
                            AppendLine(Me, _detail)
                        Catch ex As Exception
                        End Try
                    End If
                Catch ex As Exception
                End Try
                AdvanceLine(Me)
            Next

            ' Display entry for each Setup Warning
            For Each _warning As Analysis.ErrorWarningItem In _analysis.SetupWarningItems
                Dim _count As Integer = _warning.Count
                Dim _id As String = _warning.ID
                Dim _detail As String = _warning.Detail

                AppendBoldText(Me, mDictionary.tWarning.Translated & " - ")
                Try
                    If (0 < _id.Length) Then
                        If (1 = _count) Then
                            AppendLine(Me, _id)
                        Else
                            AppendLine(Me, _id + "(" + _count.ToString + "x)")
                        End If
                        AdvanceLine(Me)
                    End If
                    ' Add Warning Details if requested
                    If (_showDetails) Then
                        Try
                            AppendLine(Me, _detail)
                        Catch ex As Exception
                        End Try
                    End If
                Catch ex As Exception
                End Try
                AdvanceLine(Me)
            Next
        End If

    End Sub

    Public Sub DisplayErrorsAndWarnings(ByVal _analysis As Analysis, ByVal _details As Boolean)
        Me.Clear()
        Me.DisplayErrors(_analysis, _details)
        Me.DisplayWarnings(_analysis, _details)
    End Sub

#End Region

End Class
