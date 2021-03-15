
'*************************************************************************************************************
' Class SelectMeasurementStations - select measurement stations from elevation table distances
'*************************************************************************************************************
Imports System.Windows.Forms

Imports DataStore

Public Class SelectMeasurementStations

#Region " Member Data "

    Private mSelectionProperty As PropertyNode = New PropertyNode
    Private mSelectionParameter As DataTableParameter
    Private mSelectionDataTable As DataTable

    Private mSelections As String() = {"No", "Station"}
    Private Const SelNo As Integer = 0
    Private Const SelSta As Integer = 1

#End Region

#Region " Properties "

    Private mElevationTable As DataTable
    Public Property ElevationTable() As DataTable
        Get
            Return mElevationTable
        End Get
        Set(ByVal value As DataTable)
            mElevationTable = value
        End Set
    End Property

    Private mStationsTable As DataTable
    Public Property StationsTable() As DataTable
        Get
            Return mStationsTable
        End Get
        Set(ByVal value As DataTable)
            mStationsTable = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Sub Initialize()

        If ((mElevationTable IsNot Nothing) And (mStationsTable IsNot Nothing)) Then
            Dim elevColumns As Integer = mElevationTable.Columns.Count
            Dim elevRows As Integer = mElevationTable.Rows.Count

            ' Build selection table based on Elevation Table
            mSelectionDataTable = New DataTable("Selected Measurement Stations")
            mSelectionDataTable.Columns.Add("Select", GetType(String))

            Me.SelectionList.CaptionText = mSelectionDataTable.TableName

            For Each elevCol As DataColumn In mElevationTable.Columns
                Dim colName As String = elevCol.ColumnName
                Dim colType As Type = elevCol.DataType

                mSelectionDataTable.Columns.Add(colName, colType)
            Next elevCol

            ' Add rows from Elevation Table to selection table
            For Each elevRow As DataRow In mElevationTable.Rows
                Dim dist As Double = elevRow.Item(0)
                Dim elev As Double = elevRow.Item(1)

                Dim selRow As DataRow = mSelectionDataTable.NewRow

                ' Mark previously selected station locations
                Dim staRow As DataRow = GetDataRow(mStationsTable, 0, dist, OneDecimeter)
                If (staRow Is Nothing) Then
                    selRow.Item(0) = mSelections(SelNo)
                Else
                    selRow.Item(0) = mSelections(SelSta)
                End If

                For edx As Integer = 0 To elevColumns - 1
                    selRow.Item(edx + 1) = elevRow.Item(edx)
                Next edx

                mSelectionDataTable.Rows.Add(selRow)

            Next elevRow

            ' Create data structure behind ctl_DataTableParameter
            mSelectionParameter = New DataTableParameter(mSelectionDataTable)
            mSelectionProperty.SetParameter(mSelectionParameter)

            ' Initialize ctl_DataTableParameter & update its UI
            Me.SelectionList.LinkToModel(Nothing, mSelectionProperty)
            Me.SelectionList.SelectionColumn("Select") = mSelections
            Me.SelectionList.ReadonlyColumn(sDistanceX) = True
            Me.SelectionList.ReadonlyColumn(sElevationX) = True
            Me.SelectionList.UpdateUI()

        End If

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub SelectMeasurementStations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        Dim curCell As DataGridCell = Me.SelectionList.CurrentCell
        curCell.ColumnNumber += 1
        Me.SelectionList.CurrentCell = curCell
    End Sub

    Private Sub ClearAll_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ClearAll_Button.Click
        For Each selRow As DataRow In mSelectionDataTable.Rows
            selRow.Item(0) = mSelections(SelNo)
        Next selRow
        Me.SelectionList.UpdateUI()
    End Sub

    Private Sub SelectAll_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SelectAll_Button.Click
        For Each selRow As DataRow In mSelectionDataTable.Rows
            selRow.Item(0) = mSelections(SelSta)
        Next selRow
        Me.SelectionList.UpdateUI()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OK_Button.Click

        ' Get updated selection list
        mSelectionParameter = mSelectionProperty.GetDataTableParameter
        mSelectionDataTable = mSelectionParameter.Value

        ' Build new Measurement Station table from selected items
        mStationsTable.Rows.Clear()

        For Each selRow As DataRow In mSelectionDataTable.Rows
            If (selRow.Item(0) = mSelections(SelSta)) Then
                Dim staRow As DataRow = mStationsTable.NewRow
                staRow.Item(0) = selRow.Item(1)
                staRow.Item(1) = selRow.Item(2)
                mStationsTable.Rows.Add(staRow)
            End If
        Next selRow

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectStations_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:EvalueInputs", 1100)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:EvalueInputs", 1100)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class
