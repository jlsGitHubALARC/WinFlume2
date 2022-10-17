
'*************************************************************************************************************
' Class RatingTableGraph - Graph for displaying the Rating Table data
'*************************************************************************************************************
Imports WinFlume.RatingTableControl
Imports Flume

Public Class RatingTableGraph
    Inherits ctl_Graph2D2Y

#Region " Member Data "
    '
    ' Rating Table Graph data
    '
    Private LeftAxisChoice1 As GraphChoice = Nothing
    Private LeftAxisChoice2 As GraphChoice = Nothing
    Private RightAxisChoice1 As GraphChoice = Nothing

    Private LeftAxisCurves As DataTable = Nothing
    Private RightAxisCurves As DataTable = Nothing
    Private RatingCurves As DataSet = Nothing

    Private LeftAxisMin As Single
    Private LeftAxisMax As Single

    Private RightAxisMin As Single
    Private RightAxisMax As Single

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

    Private mGraphList As List(Of GraphChoice) = Nothing
    Friend Property GraphList() As List(Of GraphChoice)
        Get
            Return mGraphList
        End Get
        Set(ByVal value As List(Of GraphChoice))
            mGraphList = value
        End Set
    End Property

    Private mSyncYAxesSelect As Boolean = False
    Friend Property SyncYAxesSelect() As Boolean
        Get
            Return mSyncYAxesSelect
        End Get
        Set(ByVal value As Boolean)
            mSyncYAxesSelect = value
        End Set
    End Property

#End Region

#Region " Update Rating Table Graph "

    Friend Sub UpdateRatingTableGraph(ByVal regGraphItem1 As Integer, ByVal regGraphItem2 As Integer,
                                      ByVal regGraphItem3 As Integer, ByVal RatingResults() As RatingResultsType)
        '
        ' Update the Rating Graph
        '
        If (LeftAxisCurves IsNot Nothing) Then
            LeftAxisCurves.Rows.Clear()
            LeftAxisCurves.Columns.Clear()
            LeftAxisCurves.Dispose()
            LeftAxisCurves = Nothing
        End If

        LeftAxisChoice1 = GraphList(regGraphItem1)
        HQcurve(RatingResults, LeftAxisChoice1, LeftAxisCurves, LeftAxisMin, LeftAxisMax)

        LeftAxisChoice2 = GraphList(regGraphItem2)
        HQcurve(RatingResults, LeftAxisChoice2, LeftAxisCurves, LeftAxisMin, LeftAxisMax)

        If (RightAxisCurves IsNot Nothing) Then
            RightAxisCurves.Rows.Clear()
            RightAxisCurves.Columns.Clear()
            RightAxisCurves.Dispose()
            RightAxisCurves = Nothing
        End If

        RightAxisChoice1 = GraphList(regGraphItem3)
        HQcurve(RatingResults, RightAxisChoice1, RightAxisCurves, RightAxisMin, RightAxisMax)

        If (LeftAxisCurves Is Nothing) Then
            GraphYMin = RightAxisMin
            GraphYMax = RightAxisMax
        ElseIf (RightAxisCurves Is Nothing) Then
            GraphYMin = LeftAxisMin
            GraphYMax = LeftAxisMax
        Else
            GraphYMin = Math.Min(LeftAxisMin, RightAxisMin)
            GraphYMax = Math.Max(LeftAxisMax, RightAxisMax)
        End If

        RatingCurves = New DataSet(mFlume.Description.Trim)
        If (LeftAxisCurves IsNot Nothing) Then
            LeftAxisCurves.TableName = "Left Axis"
            RatingCurves.Tables.Add(LeftAxisCurves)
        End If

        If (RightAxisCurves IsNot Nothing) Then
            RightAxisCurves.TableName = "Right Axis"
            RightAxisCurves.ExtendedProperties.Add("Symbol", "o")
            RightAxisCurves.ExtendedProperties.Add("Line", True)
            RatingCurves.Tables.Add(RightAxisCurves)
        End If

        Me.InitializeGraph2D2Y(RatingCurves)

        If (SyncYAxesSelect) Then
            Me.MinY = GraphYMin
            Me.MaxY = GraphYMax

            Me.MinY2 = GraphYMin
            Me.MaxY2 = GraphYMax
        Else
            Me.MinY = LeftAxisMin
            Me.MaxY = LeftAxisMax

            If (RightAxisMin < RightAxisMax) Then
                Me.MinY2 = RightAxisMin
                Me.MaxY2 = RightAxisMax
            Else
                Me.MinY2 = LeftAxisMin
                Me.MaxY2 = LeftAxisMax
            End If
        End If

        Me.DrawImage()

    End Sub

    Private Sub HQcurve(ByVal RatingResults() As RatingResultsType, ByVal Choice As GraphChoice, _
                        ByRef Curve As DataTable, ByRef CurveMin As Single, ByRef CurveMax As Single)

        ' Validate inputs
        If ((RatingResults Is Nothing) Or (Choice Is Nothing)) Then
            Exit Sub
        End If

        If (Choice.Rating = RatingResultsEnum.None) Then
            Exit Sub
        End If

        Dim UiUnitsX As String = UnitsDialog.UiDischargeUnitsText
        Dim ColNameX As String = My.Resources.Discharge & ", Q (" & UiUnitsX & ")"
        Dim UiUnitsY As String = UnitsDialog.UiUnitsText(Choice.SiUnits)
        Dim ColNameY As String = Choice.NameSymbol & " (" & UiUnitsY & ")"

        ' If no Curve input, create one with X & Y columns
        If (Curve Is Nothing) Then
            Curve = New DataTable("H-Q Graph")
            Curve.Columns.Add(ColNameX, GetType(Single))
            Curve.Columns.Add(ColNameY, GetType(Single))
            CurveMin = Single.MaxValue
            CurveMax = Single.MinValue
        Else ' add another Y column
            Curve.Columns.Add(ColNameY, GetType(Single))
        End If

        Dim cdx As Integer = Curve.Columns.Count - 1    ' Next column for Rating data
        Dim rdx As Integer = 0                          ' Next row     "    "     "

        For Each RatingResult As RatingResultsType In RatingResults
            If (RatingResult IsNot Nothing) Then

                Dim siValue As Single = Single.NaN

                With RatingResult

                    Select Case (Choice.Rating)
                        Case RatingResultsEnum.ActualTailwaterDepth
                            siValue = .ActualTailwaterDepth
                        Case RatingResultsEnum.Cd
                            siValue = .Cd
                        Case RatingResultsEnum.Cv
                            siValue = .Cv
                        Case RatingResultsEnum.Froude
                            siValue = .Froude
                        Case RatingResultsEnum.H1
                            siValue = .H1
                        Case RatingResultsEnum.HLRatio
                            siValue = .HLRatio
                        Case RatingResultsEnum.MaxTailwater
                            siValue = .MaxTailwater
                        Case RatingResultsEnum.ModularLimit
                            siValue = .ModularLimit
                        Case RatingResultsEnum.Q
                            siValue = .Q
                        Case RatingResultsEnum.ReqEnergyLoss
                            siValue = .ReqEnergyLoss
                        Case RatingResultsEnum.SMALLh1
                            siValue = .SMALLh1
                        Case RatingResultsEnum.smallh2
                            siValue = .smallh2
                        Case RatingResultsEnum.Submergence
                            siValue = .Submergence
                        Case RatingResultsEnum.V1
                            siValue = .V1
                        Case RatingResultsEnum.y1
                            siValue = .y1
                        Case Else
                            Debug.Assert(False)
                            siValue = 0
                    End Select
                End With

                Dim uiValue As Single = UnitsDialog.UiValue(siValue, Choice.SiUnits)

                If (CurveMin > uiValue) Then
                    CurveMin = uiValue
                End If
                If (CurveMax < uiValue) Then
                    CurveMax = uiValue
                End If

                If (Curve.Columns.Count = 2) Then ' this is a new Curve table
                    Dim siQ As Single = RatingResult.Q
                    Dim uiQ As Single = UnitsDialog.UiDischargeValue(siQ)

                    Dim HQrow As DataRow = Curve.NewRow
                    HQrow(0) = uiQ
                    HQrow(1) = uiValue
                    Curve.Rows.Add(HQrow)
                Else ' Curve already contains data, add to it
                    Dim HQrow As DataRow = Curve.Rows(rdx)
                    HQrow(cdx) = uiValue
                    rdx += 1
                End If

            End If ' (RatingResult IsNot Nothing)
        Next RatingResult

    End Sub

#End Region

End Class
