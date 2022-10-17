
'*************************************************************************************************************
' Class DefineControlControl - UserControl for displaying & editing the Control properties
'*************************************************************************************************************
Public Class DefineControlControl

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

                Me.FlumeCrestControl.UpdateUI(mWinFlumeForm)
                Me.HeadMeasurementControl.UpdateUI(mWinFlumeForm)
                Me.ControlSectionControl.UpdateUI(mWinFlumeForm)

                ' Update the Flume Design Review
                Dim WinFlumeDesign As WinFlumeDesign = New WinFlumeDesign
                Dim flume As Flume.FlumeType = WinFlumeForm.Flume         ' Flume data
                Dim version As String = WinFlumeForm.WinFlumeName() & " " & WinFlumeForm.WinFlumeVersion()
                Dim rptPage1 As String = WinFlumeDesign.DesignReview1of3(flume, version)
                Me.FlumeDesignReview.Rtf.WordWrap = False
                Dim rtfFont As Font = Me.FlumeDesignReview.Rtf.Font
                Me.FlumeDesignReview.Rtf.Font = New Font(rtfFont.FontFamily, 10, rtfFont.Style)
                Me.FlumeDesignReview.Rtf.ScrollBars = RichTextBoxScrollBars.None
                Me.FlumeDesignReview.Rtf.Text = rptPage1

                If (WinFlumeForm.LocateSubtabs = TabAlignment.Top) Then
                    Me.DefineControlTabControl.Alignment = TabAlignment.Top
                Else
                    Me.DefineControlTabControl.Alignment = TabAlignment.Bottom
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
    ' Resize / Visible handlers
    '*********************************************************************************************************
    Private Sub Mybase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Resize
        Me.UpdateUI()
    End Sub

    Private Sub MyBase_VisibleChanged(sender As Object, e As EventArgs) _
        Handles MyBase.VisibleChanged
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
    Private Sub DefineControlTabControl_ValueChanged() Handles DefineControlTabControl.ValueChanged
        If (mWinFlumeForm IsNot Nothing) Then
            mWinFlumeForm.RaiseFlumeDataChanged()
        End If
    End Sub

#End Region

End Class
