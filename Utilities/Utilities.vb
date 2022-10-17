
'*************************************************************************************************************
' Utilities - General purpose utilities
'*************************************************************************************************************
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Collections.Generic

Module Utilities

#Region " Math Utilities "
    '
    ' Compare two numbers for being 'This Close'
    '
    Public Function ThisClose(ByVal Int1 As Integer,
                              ByVal Int2 As Integer,
                              ByVal Tolerance As Integer) As Boolean

        If (Int1 < Int2 - Tolerance) Then
            Return False
        ElseIf (Int2 + Tolerance < Int1) Then
            Return False
        End If

        Return True
    End Function

    Public Function ThisClose(ByVal Single1 As Single,
                              ByVal Single2 As Single,
                              ByVal Tolerance As Single) As Boolean

        If (Single1 < Single2 - Tolerance) Then
            Return False
        ElseIf (Single2 + Tolerance < Single1) Then
            Return False
        End If

        Return True
    End Function

    Public Function ThisClose(ByVal Double1 As Double,
                              ByVal Double2 As Double,
                              ByVal Tolerance As Double) As Boolean

        If (Double1 < Double2 - Tolerance) Then
            Return False
        ElseIf (Double2 + Tolerance < Double1) Then
            Return False
        End If

        Return True
    End Function
    '
    ' Find the Floor/Ceiling array entry for a given value
    '
    Public Function FloorValue(ByVal DblArray As Double(), ByVal DblValue As Double) As Double
        For idx As Integer = DblArray.Length - 1 To 0 Step -1
            FloorValue = DblArray(idx)
            If (FloorValue <= DblValue) Then
                Exit For
            End If
        Next idx
    End Function

    Public Function CeilingValue(ByVal DblArray As Double(), ByVal DblValue As Double) As Double
        For idx As Integer = 0 To DblArray.Length - 1
            CeilingValue = DblArray(idx)
            If (DblValue <= CeilingValue) Then
                Exit For
            End If
        Next idx
    End Function
    '
    ' Min/Max values in array
    '
    Public Function MinX(ByVal Array() As PointF) As Single
        MinX = Single.MaxValue

        If (Array IsNot Nothing) Then
            If (0 < Array.Length) Then
                For Each ptf As PointF In Array
                    If (MinX > ptf.X) Then
                        MinX = ptf.X
                    End If
                Next
            End If
        End If
    End Function

    Public Function MaxX(ByVal Array() As PointF) As Single
        MaxX = Single.MinValue

        If (Array IsNot Nothing) Then
            If (0 < Array.Length) Then
                For Each ptf As PointF In Array
                    If (MaxX < ptf.X) Then
                        MaxX = ptf.X
                    End If
                Next
            End If
        End If
    End Function

    Public Function MinY(ByVal Array() As PointF) As Single
        MinY = Single.MaxValue

        If (Array IsNot Nothing) Then
            If (0 < Array.Length) Then
                For Each ptf As PointF In Array
                    If (MinY > ptf.Y) Then
                        MinY = ptf.Y
                    End If
                Next
            End If
        End If
    End Function

    Public Function MaxY(ByVal Array() As PointF) As Single
        MaxY = Single.MinValue

        If (Array IsNot Nothing) Then
            If (0 < Array.Length) Then
                For Each ptf As PointF In Array
                    If (MaxY < ptf.Y) Then
                        MaxY = ptf.Y
                    End If
                Next
            End If
        End If
    End Function

#End Region

#Region " String Utilities "
    '
    ' Determine if a string is contained within an array of strings
    '
    Public Function IsElementOf(ByVal Text As String, ByVal TextArray() As String) As Integer
        If Not (TextArray Is Nothing) Then
            If (0 < TextArray.Length) Then
                For idx As Integer = 0 To TextArray.Length - 1
                    If (0 = String.Compare(TextArray(idx), Text)) Then
                        Return idx
                    End If
                Next
            End If
        End If

        Return -1
    End Function
    '
    ' Justify (left | right) a string to fit within a longer string
    '
    Public Function LeftJustifyFill(ByVal Text As String, ByVal Len As Integer,
                                    Optional ByVal Pre As String = "", Optional ByVal Post As String = "") As String
        Text = Pre & Text & Post
        If (Text.Length < Len) Then
            Text = Text.PadRight(Len, " "c)
        End If
        Text = Text.Substring(0, Len)
        Return Text
    End Function

    Public Function RightJustifyFill(ByVal Text As String, ByVal Len As Integer,
                                     Optional ByVal Pre As String = "", Optional ByVal Post As String = "") As String
        Text = Pre & Text & Post
        If (Text.Length < Len) Then
            Text = Text.PadLeft(Len, " "c)
        End If
        Text = Text.Substring(0, Len)
        Return Text
    End Function
    '
    ' Function RandomString() - return a randomly generated string
    '
    Public Function RandomString() As String
        RandomString = Path.GetRandomFileName()
        RandomString = RandomString.Replace(".", "")
    End Function
    '
    ' Function IsOdd()  - returns true if Integer is Odd
    ' Function IsEven() -    "      "   "     "    " Even
    '
    Public Function IsOdd(ByVal Int1 As Integer) As Boolean
        Return IsEven(Int1) = False
    End Function

    Public Function IsEven(ByVal Int1 As Integer) As Boolean
        Return Int1 Mod 2 = 0
    End Function
    '
    ' Function MeasureString() - compute display string size more accurately than Graphics.MeasureString()
    '
    ' Modified code from:
    ' http://simplyvisualbasic.blogspot.com/2011/08/get-exact-width-of-string-using.html
    '
    Public Function MeasureString(ByVal dGraphics As Graphics, ByVal dText As String, ByVal dFont As Font) As RectangleF
        Dim dRange As CharacterRange() = {New CharacterRange(0, dText.Length)}
        Dim dRegion As Region() = New Region(0) {}
        Dim dFormat As New StringFormat()

        dFormat.SetMeasurableCharacterRanges(dRange)

        Dim dRect As New RectangleF(0, 0, Integer.MaxValue, Integer.MaxValue)
        dRegion = dGraphics.MeasureCharacterRanges(dText, dFont, dRect, dFormat)
        dRect = dRegion(0).GetBounds(dGraphics)

        MeasureString = dRect
    End Function
    '
    ' Word Wrap text to fit in specified length
    '
    Public Function WordWrap(ByVal Text As String, ByVal MaxWidth As Integer) As String
        WordWrap = ""

        Try
            ' Make all line terminators vbCr
            Text = Text.Replace(vbCrLf, vbCr)
            Text = Text.Replace(vbLf, vbCr)

            ' Separate individual lines
            Dim lines As String() = Text.Split(vbCr.ToCharArray)

            For Each line As String In lines
                If (line.Length <= MaxWidth) Then ' line fits in width; use as is
                    WordWrap &= line & vbCrLf
                Else ' line is too long; wrap it
                    ' Parse individual words
                    Dim words As String() = line.Split(" ".ToCharArray)

                    Dim wrapLine As String = ""
                    Dim wrapLen As Integer = wrapLine.Length

                    ' Recombine words to wrap within width
                    For Each word As String In words
                        If (wrapLen + word.Length <= MaxWidth) Then ' word fits in width; concatenate it
                            wrapLine &= word & " "
                        Else ' word does not fit; wrap line is complete, start a new one
                            WordWrap &= wrapLine & vbCrLf
                            wrapLine = word & " "
                        End If
                        wrapLen = wrapLine.Length
                    Next word

                    WordWrap &= wrapLine & vbCrLf

                End If
            Next line

        Catch ex As Exception
            WordWrap = ""
        End Try
    End Function

#End Region

#Region " Sorting Utilities "
    '
    ' Swap values such that (value1 <=> value2)
    '
    Public Sub Swap(ByRef Int1 As Integer, ByRef Int2 As Integer)
        Dim temp As Integer = Int1
        Int1 = Int2
        Int2 = temp
    End Sub

    Public Sub Swap(ByRef Single1 As Single, ByRef Single2 As Single)
        Dim temp As Single = Single1
        Single1 = Single2
        Single2 = temp
    End Sub

    Public Sub Swap(ByRef Double1 As Double, ByRef Double2 As Double)
        Dim temp As Double = Double1
        Double1 = Double2
        Double2 = temp
    End Sub
    '
    ' Order values such that (value1 <= value2)
    '
    Public Sub Order(ByRef Int1 As Integer, ByRef Int2 As Integer)
        If (Int2 < Int1) Then
            Swap(Int1, Int2)
        End If
    End Sub

    Public Sub Order(ByRef Single1 As Single, ByRef Single2 As Single)
        If (Single2 < Single1) Then
            Swap(Single1, Single2)
        End If
    End Sub

    Public Sub Order(ByRef Double1 As Double, ByRef Double2 As Double)
        If (Double2 < Double1) Then
            Swap(Double1, Double2)
        End If
    End Sub

#End Region

#Region " Misc. Utilities "

    Public Function BitSet(ByVal Bits As Integer, ByVal Bit As Integer) As Boolean
        BitSet = True
        If ((Bits And Bit) = 0) Then
            BitSet = False
        End If
    End Function

#End Region

End Module
