
'*************************************************************************************************************
' Class BasisManningControl - UserControl for displaying & editing Tailwater Basis Manning values
'*************************************************************************************************************
Public Class BasisManningControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mSection As Flume.SectionType = Nothing

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Approach cross section
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                             ' Flume data
        If (mFlume Is Nothing) Then
            Return
        End If

        ' Update Tailwater Basis controls
        Me.ManningN.SiDefaultValue = WinFlumeForm.DefaultFlume.TailwaterN
        Me.ManningN.SiValue = mFlume.TailwaterN
        Me.ManningN.Label = Me.ManningNLabel.Text

        Dim ErrMsg As String = ""
        If (mFlume.TailwaterN <= 0) Then
            ErrMsg = My.Resources.MsgManningnLeZero
        End If
        Me.ManningN.SetError(ErrMsg)

        Me.BedSlope.SiDefaultValue = WinFlumeForm.DefaultFlume.Gradient
        Me.BedSlope.SiValue = mFlume.Gradient
        Me.BedSlope.SiUnits = WinFlumeForm.SiSlopeUnitsText
        Me.BedSlope.Label = Me.BedSlopeLabel.Text

        ErrMsg = ""
        If (mFlume.Gradient <= 0) Then
            ErrMsg = My.Resources.MsgBedSlopeLeZero
        End If
        Me.BedSlope.SetError(ErrMsg)

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Load event handler
    '*********************************************************************************************************
    Private Sub BasisManningControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        Me.FillManningTreeNodes(Me.ManningsTree.Nodes)
    End Sub

    Private Sub FillManningTreeNodes(ByVal Nodes As TreeNodeCollection)
        If (Nodes IsNot Nothing) Then
            If (0 < Nodes.Count) Then
                For Each tNode As TreeNode In Nodes
                    If (tNode.Tag IsNot Nothing) Then
                        tNode.Text &= "   n=" & CStr(tNode.Tag)
                    End If

                    FillManningTreeNodes(tNode.Nodes)
                Next tNode
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Manning n TreeView event handlers
    '*********************************************************************************************************
    Private Sub ManningsTree_NodeMouseClick(ByVal sender As System.Object, ByVal e As TreeNodeMouseClickEventArgs) _
    Handles ManningsTree.NodeMouseClick
        If (sender.GetType Is GetType(TreeView)) Then
            Dim tView As TreeView = DirectCast(sender, TreeView)
            If (e.Node IsNot Nothing) Then
                Dim tNode As TreeNode = e.Node
                If (tNode.Tag IsNot Nothing) Then
                    If (tNode.Tag.GetType Is GetType(String)) Then
                        Dim tagStr As String = DirectCast(tNode.Tag, String)
                        Me.ManningN.UiValueText(tagStr)
                    End If
                End If
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Protected Sub ManningN_ValueChanged() Handles ManningN.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim manningN As Single = Me.ManningN.SiValue
            If Not (mFlume.TailwaterN = manningN) Then
                mFlume.TailwaterN = manningN
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Protected Sub BedSlope_ValueChanged() Handles BedSlope.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim gradient As Single = Me.BedSlope.SiValue
            If Not (mFlume.Gradient = gradient) Then
                mFlume.Gradient = gradient
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub BasisManningControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub BasisManningControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize

        Dim loc As Point = Me.ManningsTree.Location
        loc.X = Me.BedSlope.Location.X + Me.BedSlope.Width + 2 * Me.Margin.Horizontal
        Me.ManningsTree.Width = Me.Width - loc.X

    End Sub

#End Region

End Class
