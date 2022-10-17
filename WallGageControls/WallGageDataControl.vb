
'*************************************************************************************************************
' Class WallGageDataControl - UserControl for displaying & editing the Wall Gage Data
'*************************************************************************************************************
Imports System
Imports System.Windows

Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog    ' Unit conversion support

Public Class WallGageDataControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mSection As Flume.SectionType = Nothing

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Rating Table Choices
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data
        If ((mFlume Is Nothing) Or (Not (Me.Visible))) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Debug.Assert(False)
            Return
        End If
        mUpdatingUI = True

        Try
            Dim SiLunits As String = SiLengthUnitsText()
            Dim UiLunits As String = UiLengthUnitsText()

            Dim SiQunits As String = SiDischargeUnitsText()
            Dim UiQunits As String = UiDischargeUnitsText()

            Dim headColumnText As String = ""
            Dim distanceColumnText As String = ""
            Dim dischargeColumnText As String = ""
            Dim zRatio As String = mFlume.WGageZ.ToString & ":1 "

            If (mFlume.WGageRef = 0) Then ' Sill-Referenced
                headColumnText = My.Resources.SillReferenced
                distanceColumnText = My.Resources.SillReferenced
            Else ' Bottom-Referenced
                headColumnText = My.Resources.BottomReferenced
                distanceColumnText = My.Resources.BottomReferenced
            End If

            headColumnText &= vbCrLf & My.Resources.Head & " (" & UiLunits & ")"
            headColumnText &= vbCrLf & My.Resources.Vertical.ToLower

            distanceColumnText &= vbCrLf & My.Resources.Distance & " (" & UiLunits & ")"
            distanceColumnText &= vbCrLf & My.Resources.Slope.ToLower & " " & zRatio

            dischargeColumnText &= vbCrLf & My.Resources.Discharge
            dischargeColumnText &= vbCrLf & "(" & UiQunits & ")"

            Me.FixedHeadIntervalTable.Columns(0).HeaderText = headColumnText
            Me.FixedHeadIntervalTable.Columns(1).HeaderText = distanceColumnText
            Me.FixedHeadIntervalTable.Columns(2).HeaderText = dischargeColumnText

            Me.FixedDischargeIntervalTable.Columns(0).HeaderText = dischargeColumnText
            Me.FixedDischargeIntervalTable.Columns(1).HeaderText = headColumnText
            Me.FixedDischargeIntervalTable.Columns(2).HeaderText = distanceColumnText

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        mUpdatingUI = False
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub MyBase_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    Private Sub Mybase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize

        Dim dataWidth As Integer = Me.DataPanel.Width
        Dim dataHeight As Integer = Me.DataPanel.Height
        Dim boxWidth As Integer = CInt(dataWidth / 2) - Me.Margin.Horizontal
        Dim boxHeight As Integer = dataHeight - Me.Margin.Vertical

        Me.FixedHeadIntervalBox.Width = boxWidth
        Me.FixedHeadIntervalBox.Height = boxHeight

        Dim loc As Point = Me.FixedDischargeIntervalBox.Location
        loc.X = Me.FixedHeadIntervalBox.Width + Me.Margin.Horizontal * 2
        Me.FixedDischargeIntervalBox.Location = loc
        Me.FixedDischargeIntervalBox.Width = boxWidth
        Me.FixedDischargeIntervalBox.Height = boxHeight
    End Sub

#End Region

End Class
