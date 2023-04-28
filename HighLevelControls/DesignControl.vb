
'*************************************************************************************************************
' Class DesignControl - UserControl for displaying & editing the Design properties
'*************************************************************************************************************
Public Class DesignControl

#Region " Member Data "
    '
    ' WinFlume's top-level User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm

    Enum DesignTabSelection
        DesignOptions = 0
        AlternationDesigns = 1
    End Enum

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' UpdateUI() - Update the Design Control's User Interface
    '
    ' Input(s):     WinFlume - reference to the top-level WinFlume form
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Private mUpdatingUI As Boolean = False      ' Flag used to prevent UpdateUI from recursivly calling itself
    Protected Sub UpdateUI()
        If Not (Me.Visible) Then    ' Only update UI when control is visible
            Return
        End If

        If (mWinFlumeForm IsNot Nothing) Then

            If Not (mUpdatingUI) Then
                mUpdatingUI = True

                If (Me.Width - Me.VerticalSplitter.SplitterDistance > WinFlumeForm.MaxSideBarWidth) Then
                    Me.VerticalSplitter.SplitterDistance = Me.Width - WinFlumeForm.MaxSideBarWidth
                End If

                ' Update the Controls contained in the DeSign Control tab
                Me.BottomProfileControl.UpdateUI(mWinFlumeForm)
                Me.SideBarControl.UpdateUI(mWinFlumeForm)

                Me.DesignOptionsControl.UpdateUI(mWinFlumeForm)
                Me.AlternativeDesignsControl.UpdateUI(mWinFlumeForm)

                If (WinFlumeForm.LocateSubtabs = TabAlignment.Top) Then
                    Me.DesignControlTabControl.Alignment = TabAlignment.Top
                Else
                    Me.DesignControlTabControl.Alignment = TabAlignment.Bottom
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
    Private Sub DesignControlTabControl_ValueChanged() _
        Handles DesignControlTabControl.ValueChanged

        If (mWinFlumeForm IsNot Nothing) Then
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If

    End Sub

#End Region

End Class
