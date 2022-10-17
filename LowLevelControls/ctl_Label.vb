
'*************************************************************************************************************
' Class ctl_RadioButton - UI control for displaying/editing a Radio Box
'*************************************************************************************************************
Public Class ctl_Label

    Private InitialText As String = ""              ' Initial Text (possibly with Alt Key selector (i.e. "&")

    '*********************************************************************************************************
    ' Property Text - override of MyBase property; saves Initial Text loaded into label during initialization
    '
    ' Initial Text is the text set using the Designer.  This text is Localizable so the Alt Key selection is
    ' language dependent.
    '*********************************************************************************************************
    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            If (InitialText = "") Then ' save Initial Text
                InitialText = value
            End If
            MyBase.Text = value
        End Set
    End Property

    '*********************************************************************************************************
    ' Function BaseText() - return Initial Text without Alt Key selector
    '*********************************************************************************************************
    Public Function BaseText() As String
        Dim txt As String = InitialText
        While txt.Contains("&")
            Dim pos As Integer = txt.IndexOf("&")
            txt = txt.Remove(pos, 1)
        End While
        Return txt
    End Function

    '*********************************************************************************************************
    ' Sub ShowValue() - show Initial Text & Symbol & Value
    '
    ' Input(s):     Value       - value string
    '               Symbol      - symbol   "
    '*********************************************************************************************************
    Public Sub ShowValue(ByVal Value As String, Optional ByVal Symbol As String = "")
        Dim valueText As String = InitialText

        If (Symbol IsNot Nothing) Then
            If (0 < Symbol.Length) Then
                valueText &= ", " & Symbol
            End If
        End If

        If (Value IsNot Nothing) Then
            If (0 < Value.Length) Then
                valueText &= " = " & Value
            End If
        End If

        MyBase.Text = valueText
    End Sub

End Class
