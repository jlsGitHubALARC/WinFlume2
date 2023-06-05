
'*************************************************************************************************************
' Class SideBarControl  - UserControl for displaying the upstream/downstream views & the design review
'*************************************************************************************************************
Imports System.Windows

Imports Flume

Public Class SideBarControl

#Region " Constants & Enumerations "

    Public Enum SideBarModes
        ShowAllViews
        ShowEndViews
        ShowDesignReview
    End Enum

#End Region

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Protected WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume & Section data
    '
    Protected mFlume As Flume.FlumeType = Nothing
    Protected mSection As Flume.SectionType = Nothing
    '
    ' Support for drawing cross section graphics
    '
    Protected mViewPort As RectangleF = New RectangleF
    '
    ' Drawing tools
    '
    Protected mBlackDashedPen1 As Pen = BlackDashedPen1()
    Protected mBlackBrush As Brush = BlackSolidBrush()
    Protected mBold As Font = New Font(Me.Font, FontStyle.Bold)
    '
    ' UI values
    '
    Protected mSelectSideBarsHeight As Integer

#End Region

#Region " Properties "

    ' Graphing selections
    Protected mPen1 As Drawing.Pen = BlackPen1()
    Public Property Pen1() As Drawing.Pen
        Get
            Return mPen1
        End Get
        Set(ByVal value As Drawing.Pen)
            mPen1 = value
        End Set
    End Property

    Protected mPen2 As Drawing.Pen = BlackPen2()
    Public Property Pen2() As Drawing.Pen
        Get
            Return mPen2
        End Get
        Set(ByVal value As Drawing.Pen)
            mPen2 = value
        End Set
    End Property

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI()    - update Bottom Profile UI
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume                ' Access to top level methods / events
        Me.UpstreamView.UpdateUI(mWinFlumeForm)
        Me.DownstreamView.UpdateUI(mWinFlumeForm)
        Me.UpdateUI()
    End Sub

    Protected mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()
        If (mWinFlumeForm IsNot Nothing) Then
            mFlume = WinFlumeForm.Flume         ' Flume data

            mUpdatingUI = True
            Select Case (WinFlumeForm.SideBarShow)
                Case SideBarModes.ShowEndViews
                    Me.ShowEndViews.Checked = True
                Case SideBarModes.ShowDesignReview
                    Me.ShowDesignReview.Checked = True
                Case Else ' assume SideBarModes.ShowAllViews
                    Me.ShowAll.Checked = True
            End Select
            mUpdatingUI = False

            Me.Invalidate()                     ' Causes OnPaint() to be called
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub UpdateSideBar()       - draw side bar graphics and re-position controls
    '*********************************************************************************************************
    Protected Sub UpdateSideBar(ByVal eGraphics As System.Drawing.Graphics)

        If (mFlume Is Nothing) Then ' Can't update until Flume data is available
            Return
        End If

        Try
            ' Update display of SelectSideBars control
            Dim loc As Point = Me.SelectSideBars.Location
            loc.Y = Me.Height - Me.SelectSideBars.Height - loc.X
            Me.SelectSideBars.Location = loc
            Me.SelectSideBars.Width = Me.Width - 2 * loc.X

            ' Only show Design Review selection when Alternative Designs tab is selected
            Dim ReviewDesignCtrl As AlternativeDesignsControl = mWinFlumeForm.GetAlternativeDesignsControl
            If (ReviewDesignCtrl.Visible) Then
                Me.SelectSideBars.Height = 0
            Else
                Me.SelectSideBars.Height = mSelectSideBarsHeight
            End If

            loc = New Point(Me.ShowEndViews.Location.X, Me.ShowEndViews.Location.Y)
            loc.X += Me.ShowEndViews.Width + 4
            Me.ShowDesignReview.Location = loc

            loc = New Point(Me.ShowDesignReview.Location.X, Me.ShowDesignReview.Location.Y)
            loc.X += Me.ShowDesignReview.Width + 4
            If (loc.X + Me.ShowAll.Width > Me.Width) Then
                loc.X = Me.Width - Me.ShowAll.Width
            End If
            Me.ShowAll.Location = loc

            ' Get size of space remaining for Side Bar displays
            Dim siz As Size = Me.Size
            siz.Height -= Me.SelectSideBars.Height
            '
            ' Update display of Side Bars
            '
            Dim sideBarView As Integer = WinFlumeForm.SideBarShow
            ' Only show Design Review selection when Alternative Designs tab is selected
            If (Me.SelectSideBars.Height = 0) Then
                sideBarView = SideBarModes.ShowDesignReview
            End If

            Select Case (sideBarView)
                Case SideBarModes.ShowEndViews

                    Me.UpstreamView.Show()
                    Me.DownstreamView.Show()
                    Me.DesignReviewPanel.Hide()

                    siz.Height = CInt(siz.Height / 2)

                    Me.UpstreamView.Location = New Point(0, 0)
                    Me.UpstreamView.Size = New Size(siz.Width, siz.Height - 1)

                    Me.DownstreamView.Location = New Point(0, siz.Height)
                    Me.DownstreamView.Size = New Size(siz.Width, siz.Height - 3)

                    Me.UpstreamView.Invalidate()
                    Me.DownstreamView.Invalidate()

                Case SideBarModes.ShowDesignReview

                    Me.UpstreamView.Hide()
                    Me.DownstreamView.Hide()
                    Me.DesignReviewPanel.Show()

                    Me.DesignReviewPanel.Location = New Point(0, 0)
                    Me.DesignReviewPanel.Size = New Size(siz.Width, siz.Height)

                    Me.UpdateDesignReview()

                Case Else ' assume SideBarModes.ShowAllViews

                    Me.UpstreamView.Show()
                    Me.DownstreamView.Show()
                    Me.DesignReviewPanel.Show()

                    siz.Height = CInt(siz.Height / 3)

                    Me.UpstreamView.Location = New Point(0, 0)
                    Me.UpstreamView.Size = New Size(siz.Width, siz.Height - 1)

                    Me.DownstreamView.Location = New Point(0, siz.Height)
                    Me.DownstreamView.Size = New Size(siz.Width, siz.Height - 1)

                    Me.DesignReviewPanel.Location = New Point(0, CInt(2 * siz.Height))
                    Me.DesignReviewPanel.Size = New Size(siz.Width, siz.Height)

                    Me.UpstreamView.Invalidate()
                    Me.DownstreamView.Invalidate()
                    Me.UpdateDesignReview()

            End Select

        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub

    Public Function GetUpstreamViewControl() As UpstreamViewControl
        Return Me.UpstreamView
    End Function

    Public Function GetDownstreamViewControl() As DownstreamViewControl
        Return Me.DownstreamView
    End Function

#End Region

#Region " Design Review "

    '*********************************************************************************************************
    ' Sub UpdateDesignReview() - update the Design Review text
    '
    ' Note - what design review text is shown is dependent of the state of the UI
    '       1) if the Alternative Design tab is selected:
    '           Show the Brief Design Review for the Highlighted Design
    '       2) for all other tabs:
    '           Show the Very Brief Design Review
    '*********************************************************************************************************
    Protected Sub UpdateDesignReview()

        Dim WinFlumeDesign = New WinFlumeDesign
        Dim DesignResult = New DesignResultType
        Dim Criteria(6) As Boolean
        Dim HeadlossComment As String = ""
        Dim DesignReview As String

        Dim AlternativeDesignsCtrl As AlternativeDesignsControl = mWinFlumeForm.GetAlternativeDesignsControl

        If (Me.Visible) Then

            If (AlternativeDesignsCtrl.Visible) Then
                AlternativeDesignsCtrl.UpdateUI(mWinFlumeForm)

                If (AlternativeDesignsCtrl.ExactMatch) Then
                    ' Show Brief Design Review for Highlighted Design from Alternative Designs
                    'DesignReview = AlternativeDesignsCtrl.BriefDesignReview
                    DesignReview = WinFlumeDesign.VeryBriefDesignReview(mFlume, DesignResult, Criteria, HeadlossComment)
                    DesignReview = DesignReview.Replace("     Max allowed", vbCrLf & "              Max allowed")
                    DesignReview = DesignReview.Replace("     Min allowed", vbCrLf & "              Min allowed")
                    DesignReview = DesignReview.Replace("     Min for accuracy", vbCrLf & "         Min for accuracy")
                    DesignReview = My.Resources.StatusOfHighlightedDesign & vbCrLf & vbCrLf & DesignReview
                Else
                    DesignReview = "Current design is outside the design table range."
                    DesignReview &= vbCrLf & vbCrLf
                    DesignReview &= "Select an Alternative Design from the table."
                End If

            Else
                ' Show Very Brief Design Review for current design
                DesignReview = WinFlumeDesign.VeryBriefDesignReview(mFlume, DesignResult, Criteria, HeadlossComment)

                Dim DesignControl As DesignControl = mWinFlumeForm.GetDesignControl
                If (DesignControl.Visible) Then
                    DesignReview &= vbCrLf & vbCrLf

                    DesignReview &= "Before proceeding to the Alternative Designs tab, we recommend saving the Base Design to file"
                End If
            End If

            Me.DesignReviewText.BackColor = SystemColors.Info
            Me.DesignReviewText.Text = DesignReview
        End If

    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Sub OnPaint()     - ensure contained Controls are correctly positioned when Control is re-painted
    '*********************************************************************************************************
    Protected Overrides Sub OnPaint(ByVal e As Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.UpdateSideBar(e.Graphics)
    End Sub

    '*********************************************************************************************************
    ' CheckedChanged event handlers for contained Controls
    '*********************************************************************************************************
    Private Sub ShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowAll.CheckedChanged
        If (ShowAll.Checked) Then
            If Not (mUpdatingUI) Then
                WinFlumeForm.SideBarShow = SideBarModes.ShowAllViews
                Me.UpdateUI()
            End If
        End If
    End Sub

    Private Sub ShowEndViews_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowEndViews.CheckedChanged
        If (ShowEndViews.Checked) Then
            If Not (mUpdatingUI) Then
                WinFlumeForm.SideBarShow = SideBarModes.ShowEndViews
                Me.UpdateUI()
            End If
        End If
    End Sub

    Private Sub ShowDesignReview_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ShowDesignReview.CheckedChanged
        If (ShowDesignReview.Checked) Then
            If Not (mUpdatingUI) Then
                WinFlumeForm.SideBarShow = SideBarModes.ShowDesignReview
                Me.UpdateUI()
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI(WinFlumeForm)
    End Sub

    Private Sub SideBarControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mSelectSideBarsHeight = Me.SelectSideBars.Height
    End Sub

#End Region

End Class
