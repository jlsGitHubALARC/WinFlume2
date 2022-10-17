
'*************************************************************************************************************
' Class RatingComparisonGraph - Graph for displaying the Rating Comparison data
'*************************************************************************************************************
Imports System
Imports System.Windows

Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog            ' Unit conversion support

Public Class RatingComparisonGraph
    Inherits ctl_Graph2D

#Region " Member Data "
    '
    ' Rating Comparison Graph data
    '
    Private MeasuredCurve As DataTable = Nothing
    Private TheoreticalCurve As DataTable = Nothing
    Private ComparisonCurves As DataSet = Nothing

    Private GraphYMin As Single
    Private GraphYMax As Single

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

#End Region

#Region " Update Rating Comparison Graph "

    '*********************************************************************************************************
    ' Sub UpdateRatingComparisonGraph - update comparison graph
    '
    ' Input(s):     RatingResults       - array of Flume calcuated rating results
    '               MeasuredDataTable   - array of user input HQ measurements
    '*********************************************************************************************************
    Public Sub UpdateRatingComparisonGraph(ByVal RatingResults() As RatingResultsType,
                                           ByVal MeasuredDataTable() As MeasuredDataType)
        ' RatingResults(0) is Nothing
        Debug.Assert(RatingResults.Length = MeasuredDataTable.Length + 1)

        Dim numPoints As Integer = MeasuredDataTable.Length

        Dim UiUnitsQ As String = UnitsDialog.UiDischargeUnitsText
        Dim ColNameQ As String = My.Resources.Discharge & ", Q (" & UiUnitsQ & ")"
        Dim UiUnitsH As String = UnitsDialog.UiLengthUnitsText
        Dim ColNameH As String = My.Resources.Head & " (" & UiUnitsH & ")"

        Dim siValue, uiValue As Single
        '
        ' Update Measured Data curve
        '
        If (MeasuredCurve IsNot Nothing) Then
            MeasuredCurve.Rows.Clear()
            MeasuredCurve.Columns.Clear()
            MeasuredCurve.Dispose()
            MeasuredCurve = Nothing
        End If

        MeasuredCurve = New DataTable(My.Resources.MeasuredDischarge)
        MeasuredCurve.Columns.Add(ColNameQ, GetType(Single))
        MeasuredCurve.Columns.Add(ColNameH, GetType(Single))
        MeasuredCurve.ExtendedProperties.Add("Symbol", "o")
        MeasuredCurve.Columns(1).ExtendedProperties.Add("Key", My.Resources.MeasuredData)

        For pdx As Integer = 0 To numPoints - 1
            Dim measRow As DataRow = MeasuredCurve.NewRow
            siValue = MeasuredDataTable(pdx).Flow
            uiValue = UnitsDialog.UiValue(siValue, UiUnitsQ)
            measRow(0) = uiValue
            siValue = MeasuredDataTable(pdx).Head
            uiValue = UnitsDialog.UiValue(siValue, UiUnitsH)
            measRow(1) = uiValue
            MeasuredCurve.Rows.Add(measRow)
        Next
        '
        ' Update Theoretical Data curve
        '
        If (TheoreticalCurve IsNot Nothing) Then
            TheoreticalCurve.Rows.Clear()
            TheoreticalCurve.Columns.Clear()
            TheoreticalCurve.Dispose()
            TheoreticalCurve = Nothing
        End If

        TheoreticalCurve = New DataTable(My.Resources.TheoreticalDischarge)
        TheoreticalCurve.Columns.Add(ColNameQ, GetType(Single))
        TheoreticalCurve.Columns.Add(ColNameH, GetType(Single))
        TheoreticalCurve.Columns(1).ExtendedProperties.Add("Key", My.Resources.RatingCurveComputed)

        For pdx As Integer = 1 To numPoints
            Dim theoRow As DataRow = TheoreticalCurve.NewRow
            siValue = RatingResults(pdx).Q
            uiValue = UnitsDialog.UiValue(siValue, UiUnitsQ)
            theoRow(0) = uiValue
            siValue = RatingResults(pdx).H1
            uiValue = UnitsDialog.UiValue(siValue, UiUnitsH)
            theoRow(1) = uiValue
            TheoreticalCurve.Rows.Add(theoRow)
        Next
        '
        ' Build DataSet to graph
        '
        If (ComparisonCurves IsNot Nothing) Then
            ComparisonCurves.Tables.Clear()
            ComparisonCurves.Dispose()
            ComparisonCurves = Nothing
        End If

        ComparisonCurves = New DataSet(mFlume.Description.Trim)
        ComparisonCurves.Tables.Add(MeasuredCurve)
        ComparisonCurves.Tables.Add(TheoreticalCurve)

        Me.InitializeGraph2D(ComparisonCurves)
        'Me.MinY = GraphYMin
        'Me.MaxY = GraphYMax

        Me.DrawImage()

    End Sub

#End Region

End Class
