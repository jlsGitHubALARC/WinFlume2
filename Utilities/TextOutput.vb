
'**********************************************************************************************
' Printing Utilities
'
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Module TextOutput

    <DllImport("user32.dll")> _
    Private Function SendMessage(ByVal hWnd As IntPtr, _
                                 ByVal wMsg As Int32, _
                                 ByVal wParam As Int32, _
                                 ByVal lParam As Int32) As Int32

    End Function

    Private Const EM_GETLINECOUNT As Integer = &HBA&

#Region " String Utilities "
    '
    ' Count the number of lines in a String
    '
    Public Function LineCount(ByVal Str As String) As Integer
        Dim _lines As Integer = 0

        For _idx As Integer = 0 To Str.Length - 1
            Dim _chr As Char = Str.Chars(_idx)
            If (_chr = ChrW(13)) Then
                _lines = _lines + 1
            End If
        Next _idx

        If (_lines = 0) Then
            _lines = 1
        End If

        Return _lines

    End Function

    Public Function CenterText(ByVal Str As String, ByVal Len As Integer) As String
        If (Str.Length < Len) Then
            Dim offset As Integer = CInt((Len - Str.Length) / 2)
            CenterText = StrDup(offset, " ") & Str
        Else
            CenterText = Str.Substring(Len)
        End If
    End Function

    Public Function LeftJustifyText(ByVal Str As String, ByVal Len As Integer) As String
        If (Str.Length < Len) Then
            Dim pad As Integer = Len - Str.Length
            LeftJustifyText = Str & StrDup(pad, " ")
        Else
            LeftJustifyText = Str.Substring(0, Len)
        End If
    End Function

    Public Function RightJustifyText(ByVal Str As String, ByVal Len As Integer) As String
        If (Str.Length < Len) Then
            Dim offset As Integer = Len - Str.Length
            RightJustifyText = StrDup(offset, " ") & Str
        Else
            RightJustifyText = Str.Substring(0, Len)
        End If
    End Function

    Public Function LineCount(ByVal Str As String, Optional ByVal lf As Char = CChar(vbCrLf)) As Integer
        LineCount = 0

        If (Str IsNot Nothing) Then
            For Each chr As Char In Str.ToCharArray
                If (chr = lf) Then
                    LineCount += 1
                End If
            Next chr
            If (LineCount = 0) Then
                LineCount = 1
            End If
        End If
    End Function

#End Region

#Region " RichTextBox Utilities "
    '
    ' Support for tab-like capability
    '
    Private mTabsEnabled As Boolean = False
    Public Property TabsEnabled() As Boolean
        Get
            Return mTabsEnabled
        End Get
        Set(ByVal value As Boolean)
            mTabsEnabled = value
            mCharPos = 0
        End Set
    End Property

    Private mCharPos As Integer = 0
    Public ReadOnly Property CharPos() As Integer
        Get
            Return mCharPos
        End Get
    End Property

    Public Sub TabTo(ByRef RTB As RichTextBox, ByVal TabStop As Integer)
        If (mTabsEnabled) Then
            If (mCharPos < TabStop) Then
                AppendTextRight(RTB, "", TabStop - mCharPos)
            End If
        End If
    End Sub
    '
    ' Advance line(s) in RichTextBox
    '
    Public Sub AdvanceLine(ByRef RTB As RichTextBox)

        If Not (RTB Is Nothing) Then
            ' Use the font from the RichTextBox
            Dim _fontFamily As FontFamily = RTB.SelectionFont.FontFamily
            Dim _fontSize As Single = RTB.SelectionFont.Size

            ' Append <CR>
            RTB.SelectionFont = New Font(_fontFamily, _fontSize)
            RTB.SelectedText = ControlChars.Cr

            mCharPos = 0 ' Reset character position to beginning of line
        Else
            Debug.Assert(False, "RichTextBox is Nothing")
        End If

    End Sub

    Public Sub AdvanceLines(ByRef RTB As RichTextBox, ByVal Count As Integer)
        ' Advance count lines
        While (0 < Count)
            AdvanceLine(RTB)
            Count = Count - 1
        End While
    End Sub
    '
    ' Count the lines in the RichTextBox
    '
    Public Function CountLines(ByRef RTB As RichTextBox) As Integer
        Dim _lineCount As Int32 = 0

        If Not (RTB Is Nothing) Then
            _lineCount = SendMessage(RTB.Handle, EM_GETLINECOUNT, 0, 0&)
        Else
            Debug.Assert(False, "RichTextBox is Nothing")
        End If

        Return _lineCount
    End Function
    '
    ' Append text to RichTextBox
    '
    Public Sub AppendText(ByRef RTB As RichTextBox, ByVal Text As String, ByVal Style As FontStyle)

        If Not (RTB Is Nothing) Then
            If Not (Text Is Nothing) Then
                If Not (Text = String.Empty) Then
                    ' Use the font from the RichTextBox
                    Dim _fontFamily As FontFamily = RTB.SelectionFont.FontFamily
                    Dim _fontSize As Single = RTB.SelectionFont.Size

                    ' Append text
                    RTB.SelectionFont = New Font(_fontFamily, _fontSize, Style)
                    RTB.SelectedText = Text

                    If (mTabsEnabled) Then
                        mCharPos += Text.Length
                    End If
                End If
            Else
                Debug.Assert(False, "Text is Nothing")
            End If
        Else
            Debug.Assert(False, "RichTextBox is Nothing")
        End If

    End Sub

    Public Sub AppendText(ByRef RTB As RichTextBox, ByVal Text As String)
        Dim _style As FontStyle = FontStyle.Regular
        AppendText(RTB, Text, _style)
    End Sub

    Public Sub AppendText(ByRef RTB As RichTextBox, ByVal Text As String, ByVal Length As Integer)
        AppendTextLeft(RTB, Text, Length)
    End Sub

    Public Sub AppendSymbol(ByRef RTB As RichTextBox, ByVal Text As String)

        If Not (RTB Is Nothing) Then
            If Not (Text Is Nothing) Then
                If Not (Text = String.Empty) Then
                    ' Save current Font
                    Dim _font As Font = RTB.SelectionFont

                    ' Append text using "Symbol" Font
                    RTB.SelectionFont = New Font("Symbol", 14, FontStyle.Regular)
                    RTB.SelectedText = Text

                    If (mTabsEnabled) Then
                        mCharPos += Text.Length
                    End If

                    ' Restore Font
                    RTB.SelectionFont = _font
                End If
            Else
                Debug.Assert(False, "Text is Nothing")
            End If
        Else
            Debug.Assert(False, "RichTextBox is Nothing")
        End If

    End Sub

    Public Sub AppendTextLeft(ByRef RTB As RichTextBox, ByVal Text As String, ByVal Length As Integer)
        ' Ensure text is at least as long as length by left-justifying text
        If Not (Text Is Nothing) Then
            While (Text.Length < Length)
                Text = Text + " "
            End While
        Else
            Debug.Assert(False, "Text is Nothing")
        End If

        Dim _style As FontStyle = FontStyle.Regular
        AppendText(RTB, Text, _style)
    End Sub

    Public Sub AppendTextRight(ByRef RTB As RichTextBox, ByVal Text As String, ByVal Length As Integer)
        ' Ensure text is at least as long as length by right-justifying text
        If Not (Text Is Nothing) Then
            While (Text.Length < Length)
                Text = " " + Text
            End While
        Else
            Debug.Assert(False, "Text is Nothing")
        End If

        Dim _style As FontStyle = FontStyle.Regular
        AppendText(RTB, Text, _style)
    End Sub

    Public Sub AppendBoldText(ByRef RTB As RichTextBox, ByVal Text As String)
        Dim _style As FontStyle = FontStyle.Bold
        AppendText(RTB, Text, _style)
    End Sub

    Public Sub AppendItalicText(ByRef RTB As RichTextBox, ByVal Text As String)
        Dim _style As FontStyle = FontStyle.Italic
        AppendText(RTB, Text, _style)
    End Sub

    Public Sub AppendUnderlineText(ByRef RTB As RichTextBox, ByVal Text As String)
        Dim _style As FontStyle = FontStyle.Underline
        AppendText(RTB, Text, _style)
    End Sub

    Public Sub AppendBoldUnderlineText(ByRef RTB As RichTextBox, ByVal Text As String)
        Dim _style As FontStyle = FontStyle.Bold Or FontStyle.Underline
        AppendText(RTB, Text, _style)
    End Sub
    '
    ' Append line to RichTextBox
    '
    Public Sub AppendLine(ByRef RTB As RichTextBox, ByVal Text As String)
        ' Append the text then advance the line
        AppendText(RTB, Text)
        AdvanceLine(RTB)
    End Sub

    Public Sub AppendBoldLine(ByRef RTB As RichTextBox, ByVal Text As String)
        ' Append the text then advance the line
        AppendBoldText(RTB, Text)
        AdvanceLine(RTB)
    End Sub

    Public Sub AppendItalicLine(ByRef RTB As RichTextBox, ByVal Text As String)
        ' Append the text then advance the line
        AppendItalicText(RTB, Text)
        AdvanceLine(RTB)
    End Sub

    Public Sub AppendUnderlineLine(ByRef RTB As RichTextBox, ByVal Text As String)
        ' Append the text then advance the line
        AppendUnderlineText(RTB, Text)
        AdvanceLine(RTB)
    End Sub

    Public Sub AppendBoldUnderlineLine(ByRef RTB As RichTextBox, ByVal Text As String)
        ' Append the text then advance the line
        AppendBoldUnderlineText(RTB, Text)
        AdvanceLine(RTB)
    End Sub

#End Region

End Module
