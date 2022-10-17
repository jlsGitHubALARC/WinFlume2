
'*************************************************************************************************************
' Class DefineCanalControl  - UserControl for displaying & editing the Canal properties
'*************************************************************************************************************
Public Class DefineCanalControl

#Region " Member Data "
    '
    ' WinFlume's top-level User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm

#End Region

#Region " UI Methods "

    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)

        mWinFlumeForm = WinFlume
        Me.UpdateUI()

    End Sub

    Private mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()
        If Not (Me.Visible) Then
            Return
        End If

        If (mWinFlumeForm IsNot Nothing) Then

            If Not (mUpdatingUI) Then
                mUpdatingUI = True

                If (Me.Width - Me.VerticalSplitter.SplitterDistance > WinFlumeForm.MaxSideBarWidth) Then
                    Me.VerticalSplitter.SplitterDistance = Me.Width - WinFlumeForm.MaxSideBarWidth
                End If

                Me.BottomProfileControl.UpdateUI(mWinFlumeForm)
                Me.SideBarControl.UpdateUI(mWinFlumeForm)

                Me.ApproachChannelControl.UpdateUI(mWinFlumeForm)
                Me.TailwaterChannelControl.UpdateUI(mWinFlumeForm)
                Me.DischargeTailwaterControl.UpdateUI(mWinFlumeForm)
                Me.FreeboardRequirementControl.UpdateUI(mWinFlumeForm)

                If (WinFlumeForm.LocateSubtabs = TabAlignment.Top) Then
                    Me.DefineCanalTabControl.Alignment = TabAlignment.Top
                Else
                    Me.DefineCanalTabControl.Alignment = TabAlignment.Bottom
                End If

                mUpdatingUI = False
            End If
        End If
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Resize handlers
    '*********************************************************************************************************
    Private Sub Mybase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Resize
        Me.UpdateUI()
    End Sub

    Private Sub HorizontalSplitter_SplitterMoved(ByVal sender As System.Object, ByVal e As SplitterEventArgs) _
    Handles HorizontalSplitter.SplitterMoved
        Me.UpdateUI()
    End Sub

    Private Sub VerticalSplitter_SplitterMoved(ByVal sender As System.Object, ByVal e As SplitterEventArgs) _
    Handles VerticalSplitter.SplitterMoved
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub DefineCanalTabControl_ValueChanged() Handles DefineCanalTabControl.ValueChanged
        If (mWinFlumeForm IsNot Nothing) Then
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

#End Region

End Class
