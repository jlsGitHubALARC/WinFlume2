
'*************************************************************************************************************
' Class:    PrecisionContourCell
'
' PrecisionContourCell adds Precision Contour generation to the baseclass Standard Contour generation.
'*************************************************************************************************************
Imports DataStore

Public Class PrecisionContourCell
    Inherits ContourCell

#Region " Member Data "

    Private mAnalysis As Analysis

#End Region

#Region " Properties "

    Public Property Precision() As ContourPrecision = ContourPrecision.Standard

#End Region

#Region " Constructor "

    Public Sub New(ByVal analysis As Analysis, ByVal row As Integer, ByVal col As Integer, _
                   ByVal tl As ContourPoint, ByVal tr As ContourPoint, _
                   ByVal bl As ContourPoint, ByVal br As ContourPoint, _
                   ByVal c As ContourPoint)
        ' Call baseclass constructor
        MyBase.New(row, col, tl, tr, bl, br, c)
        ' Save references to associated Unit & Analysis
        mAnalysis = analysis
    End Sub

#End Region

#Region " Methods "

    Protected Overrides Function ValuePoint( _
                ByVal a As ContourPoint, ByVal b As ContourPoint, _
                ByVal idx As Integer, ByVal value As Single, ByVal zTolerance As Single, _
                ByRef c As ContourPoint) As Boolean

        ' If Precision Contours are selected; call the Analysis function, if possible
        If (mAnalysis IsNot Nothing) Then
            If ((Me.Precision = ContourPrecision.Precise) _
             Or (mAnalysis.Precision = ContourPrecision.Precise)) Then
                Return mAnalysis.ValuePoint(a, b, idx, value, zTolerance, c)
            End If
        End If

        Return MyBase.ValuePoint(a, b, idx, value, zTolerance, c)

    End Function

    Protected Overrides Function LimitPoint( _
                ByVal a As ContourPoint, ByVal b As ContourPoint, _
                ByRef c As ContourPoint) As Boolean

        ' If Precision Contours are selected; call the Analysis function, if possible
        If (mAnalysis IsNot Nothing) Then
            If ((Me.Precision = ContourPrecision.Precise) _
             Or (mAnalysis.Precision = ContourPrecision.Precise)) Then
                Return mAnalysis.LimitPoint(a, b, c)
            End If
        End If

        Return MyBase.LimitPoint(a, b, c)

    End Function

#End Region

End Class
