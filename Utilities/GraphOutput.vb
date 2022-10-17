
Public Module GraphOutput

#Region " Cartesian Coordinate Graphics "

#Region " Graphics Drawing Tools w/ High Contrast support "
    '
    ' Brushes
    '
    Public Function BlackSolidBrush() As SolidBrush
        Return New SolidBrush(System.Drawing.Color.Black)
    End Function

    Public Function BlueSolidBrush() As SolidBrush
        Return New SolidBrush(System.Drawing.Color.Blue)
    End Function

    Public Function WhiteSolidBrush() As SolidBrush
        Return New SolidBrush(System.Drawing.Color.White)
    End Function

    Public Function GraySolidBrush() As SolidBrush
        If (SystemInformation.HighContrast) Then
            Return New SolidBrush(System.Drawing.SystemColors.ControlText)
        Else
            Return New SolidBrush(System.Drawing.Color.Gray)
        End If
    End Function

    Public Function DarkGraySolidBrush() As SolidBrush
        If (SystemInformation.HighContrast) Then
            Return New SolidBrush(System.Drawing.SystemColors.ControlText)
        Else
            Return New SolidBrush(System.Drawing.Color.FromArgb(64, 64, 64))
        End If
    End Function

    Public Function LightGraySemiTransparentBrush() As SolidBrush
        If (SystemInformation.HighContrast) Then
            Return New SolidBrush(System.Drawing.SystemColors.ControlText)
        Else
            Return New SolidBrush(System.Drawing.Color.FromArgb(32, 16, 16, 16))
        End If
    End Function

    Public Function MediumGraySemiTransparentBrush() As SolidBrush
        If (SystemInformation.HighContrast) Then
            Return New SolidBrush(System.Drawing.SystemColors.ControlText)
        Else
            Return New SolidBrush(System.Drawing.Color.FromArgb(64, 32, 32, 32))
        End If
    End Function
    '
    ' Pens
    '
    Public Function BlackPen1() As Pen
        Return New Pen(System.Drawing.Color.Black, 1)
    End Function

    Public Function BlackPen2() As Pen
        Return New Pen(System.Drawing.Color.Black, 2)
    End Function

    Public Function BlackDashedPen1() As Pen
        Dim dashedPen As Pen = New Pen(System.Drawing.Color.Black, 1)
        dashedPen.DashStyle = Drawing2D.DashStyle.Dash
        Return dashedPen
    End Function

    Public Function BlackDashedPen2() As Pen
        Dim dashedPen As Pen = New Pen(System.Drawing.Color.Black, 2)
        dashedPen.DashStyle = Drawing2D.DashStyle.Dash
        Return dashedPen
    End Function

    Public Function BluePen1() As Pen
        Return New Pen(System.Drawing.Color.Blue, 1)
    End Function

    Public Function BluePen2() As Pen
        Return New Pen(System.Drawing.Color.Blue, 2)
    End Function

    Public Function HalfBluePen2() As Pen
        Dim A As Integer = 255
        Dim R As Integer = 184
        Dim G As Integer = 184
        Dim B As Integer = 255
        HalfBluePen2 = New Pen(Color.FromArgb(A, R, G, B), 2)
    End Function

    Public Function BrownPen1() As Pen
        Return New Pen(System.Drawing.Color.Brown, 1)
    End Function

    Public Function BrownPen2() As Pen
        Return New Pen(System.Drawing.Color.Brown, 2)
    End Function

    Public Function WhitePen1() As Pen
        Return New Pen(System.Drawing.Color.White, 1)
    End Function

    Public Function WhitePen2() As Pen
        Return New Pen(System.Drawing.Color.White, 2)
    End Function

    Public Function DarkGrayPen1() As Pen
        If (SystemInformation.HighContrast) Then
            Return New Pen(System.Drawing.SystemColors.ControlText)
        Else
            Return New Pen(System.Drawing.SystemColors.ControlDark)
        End If
    End Function

    Public Function DarkGrayPen2() As Pen
        If (SystemInformation.HighContrast) Then
            Return New Pen(System.Drawing.SystemColors.ControlText, 2)
        Else
            Return New Pen(System.Drawing.SystemColors.ControlDark, 2)
        End If
    End Function

    Public Function GrayPen1() As Pen
        If (SystemInformation.HighContrast) Then
            Return New Pen(System.Drawing.SystemColors.ControlText)
        Else
            Return New Pen(System.Drawing.SystemColors.Control)
        End If
    End Function

    Public Function GrayPen2() As Pen
        If (SystemInformation.HighContrast) Then
            Return New Pen(System.Drawing.SystemColors.ControlText, 2)
        Else
            Return New Pen(System.Drawing.SystemColors.Control, 2)
        End If
    End Function

    Public Function LightGrayPen() As Pen
        If (SystemInformation.HighContrast) Then
            Return New Pen(System.Drawing.SystemColors.ControlText)
        Else
            Return New Pen(System.Drawing.SystemColors.ControlLight)
        End If
    End Function

    Public Function LightGrayPen2() As Pen
        If (SystemInformation.HighContrast) Then
            Return New Pen(System.Drawing.SystemColors.ControlText, 2)
        Else
            Return New Pen(System.Drawing.SystemColors.ControlLight, 2)
        End If
    End Function

#End Region

#End Region

End Module
