
'*************************************************************************************************************
' Class RatingEquationGraph - Graph for displaying the Rating Equation data
'*************************************************************************************************************
Imports Flume

Imports WinFlume.UnitsDialog            ' Unit conversion support

Public Class RatingEquationGraph
    Inherits ctl_Graph2D

#Region " Member Data "
    '
    ' Rating Equation Graph data
    '
    Private ComputedCurve As DataTable = Nothing
    Private FitCurve As DataTable = Nothing
    Private RatingEquationCurves As DataSet = Nothing

    Private AxisMin As Single
    Private AxisMax As Single

#End Region

#Region " Properties "
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Friend Property FlumeRef() As Flume.FlumeType
        Get
            Return mFlume
        End Get
        Set(ByVal value As Flume.FlumeType)
            mFlume = value
        End Set
    End Property

    Private mK1 As Single
    Public Property K1() As Single
        Get
            Return mK1
        End Get
        Set(ByVal value As Single)
            mK1 = value
        End Set
    End Property

    Private mK2 As Single
    Public Property K2() As Single
        Get
            Return mK2
        End Get
        Set(ByVal value As Single)
            mK2 = value
        End Set
    End Property

    Private mU As Single
    Public Property U() As Single
        Get
            Return mU
        End Get
        Set(ByVal value As Single)
            mU = value
        End Set
    End Property

    Public Function QEquationString() As String
        QEquationString = Format(K1, "0.000")
        QEquationString &= " * (h1 + "
        QEquationString &= Format(K2, "0.00000")
        QEquationString &= ") ^ "
        QEquationString &= Format(U, "0.000")

        Dim logInt As Integer

        Dim K1sigfigs As Integer = 3
        If (K1 <> 0) Then
            logInt = CInt(Math.Ceiling(Math.Log10(Math.Abs(K1))))
            K1sigfigs = maxint(4 - logInt, 0)
        End If

        Dim K2sigfigs As Integer = 3
        If (K2 <> 0) Then
            logInt = CInt(Math.Ceiling(Math.Log10(Math.Abs(K2))))
            K2sigfigs = maxint(4 - logInt, 0)
        End If

        Dim Usigfigs As Integer = 3
        If (U <> 0) Then
            logInt = CInt(Math.Ceiling(Math.Log10(Math.Abs(U))))
            Usigfigs = maxint(4 - logInt, 0)
        End If

        Dim K1fmt As String = "########0." & New String("0"c, K1sigfigs)
        Dim K2fmt As String = "########0." & New String("0"c, K2sigfigs)
        Dim Ufmt As String = "########0." & New String("0"c, Usigfigs)

        QEquationString = Format(K1, K1fmt)
        QEquationString &= " * (h1 + " & Format(K2, K2fmt)
        QEquationString &= ") ^ " & Format(U, Ufmt)
    End Function

#End Region

#Region " Update Rating Equation Graph "

    Friend Sub UpdateRatingEquationGraph(ByVal RatingResults() As RatingResultsType)

        Dim headUnits As String = My.Resources.HeadAtGage & "(m)"
        Dim dischargeUnits As String = My.Resources.Discharge & " (m³/s)"

        If (ComputedCurve IsNot Nothing) Then
            ComputedCurve.Rows.Clear()
            ComputedCurve.Columns.Clear()
            ComputedCurve.Dispose()
            ComputedCurve = Nothing
        End If
        ComputedCurve = New DataTable(My.Resources.ComputedByWinFlume)
        ComputedCurve.Columns.Add(dischargeUnits, GetType(Single))
        ComputedCurve.Columns.Add(headUnits, GetType(Single))

        If (FitCurve IsNot Nothing) Then
            FitCurve.Rows.Clear()
            FitCurve.Columns.Clear()
            FitCurve.Dispose()
            FitCurve = Nothing
        End If
        FitCurve = New DataTable(My.Resources.CurveFittedEquation)
        FitCurve.Columns.Add(dischargeUnits, GetType(Single))
        FitCurve.Columns.Add(headUnits, GetType(Single))

        Dim lUnits As LengthUnits = UiLengthUnits
        Dim qUnits As DischargeUnits = UiDischargeUnits

        For Each RatingResult As RatingResultsType In RatingResults
            If (RatingResult IsNot Nothing) Then

                Dim rowString(5) As String

                With RatingResult

                    Dim sih1 As Single = .SMALLh1
                    Dim uih1 As Single = UiLengthValue(sih1, lUnits)

                    Dim siQ As Single = .Q
                    Dim uiQ As Single = UiDischargeValue(siQ, qUnits)

                    ' K1, K2 & U are based on UI units not SI units
                    Dim uiQ_fit As Single = CSng(K1 * (maxsingle(uih1 + K2, 0.0!)) ^ U)

                    Dim dRow As DataRow = ComputedCurve.NewRow
                    dRow.Item(0) = uiQ
                    dRow.Item(1) = uih1
                    ComputedCurve.Rows.Add(dRow)

                    dRow = FitCurve.NewRow
                    dRow.Item(0) = uiQ_fit
                    dRow.Item(1) = uih1
                    FitCurve.Rows.Add(dRow)

                End With

            End If
        Next RatingResult

        RatingEquationCurves = New DataSet(mFlume.Description.Trim)
        If (ComputedCurve IsNot Nothing) Then
            Dim key As String = ComputedCurve.TableName
            ComputedCurve.Columns(1).ExtendedProperties.Add("Key", key)
            ComputedCurve.ExtendedProperties.Add("Symbol", "o")
            RatingEquationCurves.Tables.Add(ComputedCurve)
        End If
        If (FitCurve IsNot Nothing) Then
            Dim key As String = FitCurve.TableName
            key &= Chr(13) & "Q = " & QEquationString()
            FitCurve.Columns(1).ExtendedProperties.Add("Key", key)
            RatingEquationCurves.Tables.Add(FitCurve)
        End If

        Me.InitializeGraph2D(RatingEquationCurves)

        'Me.MinY = AxisMin
        'Me.MaxY = AxisMax

        Me.DrawImage()

    End Sub

#End Region

End Class
