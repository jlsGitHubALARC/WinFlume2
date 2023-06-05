
'*************************************************************************************************************
' Class MatchControlDialog
'*************************************************************************************************************
Imports Flume
Imports WinFlume.WinFlumeSectionType

Public Class MatchControlDialog

#Region " Member Data "

    Private mFlume As FlumeType = Nothing

    Private mMatchTypes() As WinFlumeSectionType
    Private mMatchTypeIndex As Integer = 0

#End Region

#Region " Properties "

    Public Property ApproachChannelShape As Integer
    Public Property ControlSectionShape As Integer

    Public Property ApproachControlMatchTypes As WinFlumeSectionType()

    Public Property ControlSectionType As WinFlumeSectionType = Nothing
    Public Property SelectedMatchText As String

#End Region

#Region " Constructor(s) "

    Public Sub New(ByVal Flume As FlumeType,
                   ByVal ApproachControlMatchTypes As WinFlumeSectionType())

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mFlume = Flume

        Me.ApproachChannelShape = mFlume.Section(cApproach).Shape
        Me.ControlSectionShape = mFlume.Section(cControl).Shape
        Me.ApproachControlMatchTypes = ApproachControlMatchTypes

    End Sub

#End Region

#Region " Methods "

    Private Sub UpdateUI()

        Dim approachChannel As SectionType = mFlume.Section(cApproach)
        Dim controlSection As SectionType = mFlume.Section(cControl)

        ControlSectionType = Nothing
        SelectedMatchText = ""
        If (ControlSectionShape = CInt(Me.ShapeButton1.Tag)) Then
            ControlSectionType = mMatchTypes(0)
            SelectedMatchText = Me.ShapeButton1.Text
        ElseIf (ControlSectionShape = CInt(Me.ShapeButton2.Tag)) Then
            ControlSectionType = mMatchTypes(1)
            SelectedMatchText = Me.ShapeButton2.Text
        ElseIf (ControlSectionShape = CInt(Me.ShapeButton3.Tag)) Then
            ControlSectionType = mMatchTypes(2)
            SelectedMatchText = Me.ShapeButton3.Text
        ElseIf (ControlSectionShape = CInt(Me.ShapeButton4.Tag)) Then
            ControlSectionType = mMatchTypes(3)
            SelectedMatchText = Me.ShapeButton4.Text
        End If

        ' Update Message Box
        Me.MessageBox.Clear()
        Me.MessageBox.SelectionAlignment = HorizontalAlignment.Center

        If (ControlSectionType Is Nothing) Then ' No match button is checked
            Me.OK_Button.Enabled = False
            AdvanceLine(Me.MessageBox)
            AppendLine(Me.MessageBox, Me.ControlShapeGroup.Text)
        Else ' A match button is checked
            Me.OK_Button.Enabled = True
            Dim matchConstraints As Integer = ControlSectionType.MatchConstraints
            Dim methodsOfContraction As Integer = ControlSectionType.MethodsOfContraction

            AppendBoldLine(Me.MessageBox, SelectedMatchText)
            AdvanceLine(Me.MessageBox)

            Me.MessageBox.SelectionAlignment = HorizontalAlignment.Left

            If (BitSet(methodsOfContraction, MethodOfContraction.RaiseLowerSillHeight)) Then
                AppendLine(Me.MessageBox, My.Resources.SillInShapeOption)
            ElseIf (BitSet(methodsOfContraction, MethodOfContraction.RaiseLowerEntireSection)) Then
                AppendLine(Me.MessageBox, My.Resources.SimpleShapeOption)
            ElseIf (BitSet(methodsOfContraction, MethodOfContraction.VarySideContraction)) Then
                AppendText(Me.MessageBox, My.Resources.VariableBottomAndSideContraction)
                If (BitSet(matchConstraints, MatchConstraint.InnerSideSlopeMatchesApproach)) Then
                    AppendLine(Me.MessageBox, " " & My.Resources.ControlSideSlopeMatchesApproach)
                Else
                    AdvanceLine(Me.MessageBox)
                End If
            Else
                AppendLine(Me.MessageBox, My.Resources.VariableBottomContraction)
            End If
            AdvanceLine(Me.MessageBox)

            AppendBoldLine(Me.MessageBox, My.Resources.Constraints)
            If (BitSet(matchConstraints, MatchConstraint.InnerSillHeightMatchesProfileSillHeight)) Then
                AppendLine(Me.MessageBox, "   " & My.Resources.InnerSillHeightMatchesProfile)
            End If
            If (BitSet(matchConstraints, MatchConstraint.SectionHeightMatchesProfileSillHeight)) Then
                AppendLine(Me.MessageBox, "   " & My.Resources.SectionHeightMatchesProfile)
            End If
            If (BitSet(matchConstraints, MatchConstraint.OuterHeightProfileSillMinusInnerSill)) Then
                AppendLine(Me.MessageBox, "   " & My.Resources.OuterHeightProfileSillMinusInnerSill)
            End If
            If (BitSet(matchConstraints, MatchConstraint.OuterShapeMatchesApproachChannel)) Then
                AppendLine(Me.MessageBox, "   " & My.Resources.OuterShapeMatchesApproachChannel)
            End If
            If (BitSet(matchConstraints, MatchConstraint.ShapeMatchesApproachChannel)) Then
                AppendLine(Me.MessageBox, "   " & My.Resources.ShapeMatchesApproachChannel)
            End If

            AppendBoldLine(Me.MessageBox, My.Resources.MethodsOfContraction)
            If (BitSet(methodsOfContraction, MethodOfContraction.RaiseLowerSillHeight)) Then
                AppendLine(Me.MessageBox, "   " & My.Resources.RaiseLowerSillHeight)
            End If
            If (BitSet(methodsOfContraction, MethodOfContraction.RaiseLowerEntireSection)) Then
                AppendLine(Me.MessageBox, "   " & My.Resources.RaiseLowerEntireSection)
            End If
            If (BitSet(methodsOfContraction, MethodOfContraction.RaiseLowerInnerSection)) Then
                AppendLine(Me.MessageBox, "   " & My.Resources.RaiseLowerInnerSection)
            End If
            If (BitSet(methodsOfContraction, MethodOfContraction.VarySideContraction)) Then
                AppendLine(Me.MessageBox, "   " & My.Resources.VarySideContraction)
            End If
        End If
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' Event Handlers
    '*********************************************************************************************************
    Private Sub MatchControlDialog_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

        For Each MatchType As WinFlumeSectionType In ApproachControlMatchTypes
            With MatchType
                If (.ApproachShape = ApproachChannelShape) Then
                    If (mMatchTypes Is Nothing) Then
                        mMatchTypes = {New WinFlumeSectionType(MatchType)}
                        mMatchTypeIndex = 1
                    Else
                        ReDim Preserve mMatchTypes(mMatchTypes.Length)
                        mMatchTypes(mMatchTypeIndex) = New WinFlumeSectionType(MatchType)
                        mMatchTypeIndex += 1
                    End If
                End If
            End With
        Next

        If (0 < mMatchTypes.Length) Then
            ShapeButton1.Visible = True
            ShapeButton1.Tag = mMatchTypes(0).ControlShape
            ShapeButton1.Text = WinFlumeForm.CrossSectionShapeNames(mMatchTypes(0).ControlShape)
            ShapeButton1.Checked = True
        Else
            ShapeButton1.Visible = False
        End If

        If (1 < mMatchTypes.Length) Then
            ShapeButton2.Visible = True
            ShapeButton2.Tag = mMatchTypes(1).ControlShape
            ShapeButton2.Text = WinFlumeForm.CrossSectionShapeNames(mMatchTypes(1).ControlShape)
        Else
            ShapeButton2.Visible = False
        End If

        If (2 < mMatchTypes.Length) Then
            ShapeButton3.Visible = True
            ShapeButton3.Tag = mMatchTypes(2).ControlShape
            ShapeButton3.Text = WinFlumeForm.CrossSectionShapeNames(mMatchTypes(2).ControlShape)
        Else
            ShapeButton3.Visible = False
        End If

        If (3 < mMatchTypes.Length) Then
            ShapeButton4.Visible = True
            ShapeButton4.Tag = mMatchTypes(3).ControlShape
            ShapeButton4.Text = WinFlumeForm.CrossSectionShapeNames(mMatchTypes(3).ControlShape)
        Else
            ShapeButton4.Visible = False
        End If

        UpdateUI()

    End Sub

    Private Sub ShapeButton1_CheckedChanged(sender As Object, e As EventArgs) _
        Handles ShapeButton1.CheckedChanged
        If (ShapeButton1.Checked) Then
            ControlSectionShape = CInt(ShapeButton1.Tag)
            UpdateUI()
        End If
    End Sub

    Private Sub ShapeButton2_CheckedChanged(sender As Object, e As EventArgs) _
        Handles ShapeButton2.CheckedChanged
        If (ShapeButton2.Checked) Then
            ControlSectionShape = CInt(ShapeButton2.Tag)
            UpdateUI()
        End If
    End Sub

    Private Sub ShapeButton3_CheckedChanged(sender As Object, e As EventArgs) _
        Handles ShapeButton3.CheckedChanged
        If (ShapeButton3.Checked) Then
            ControlSectionShape = CInt(ShapeButton3.Tag)
            UpdateUI()
        End If
    End Sub

    Private Sub ShapeButton4_CheckedChanged(sender As Object, e As EventArgs) _
        Handles ShapeButton4.CheckedChanged
        If (ShapeButton4.Checked) Then
            ControlSectionShape = CInt(ShapeButton4.Tag)
            UpdateUI()
        End If
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) _
        Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        Dim approachChannel As Flume.SectionType = mFlume.Section(cApproach)
        Dim controlSection As SectionType = mFlume.Section(cControl)

        If (ControlSectionType IsNot Nothing) Then
            With ControlSectionType
                .LoadFlumeSectionType(approachChannel)
                .Shape = .ControlShape
                .OuterBottomWidth = approachChannel.BottomWidth

                If (BitSet(.MatchConstraints, MatchConstraint.InnerSillHeightMatchesProfileSillHeight)) Then
                    .D1 = mFlume.SillHeight
                End If

                ' Handle special cases
                Select Case (.Shape)
                    Case shTrapezoidInUShaped, shTrapezoidInCircle, shTrapezoidInParabola
                        .BottomWidth = .DiameterFocalD / 2
                    Case shTrapezoidInVShaped
                        Dim SW As Single = approachChannel.TopWidth(.D1, False)
                        .BottomWidth = SW / 2
                    Case shRectangleInRectangle
                        .BottomWidth = .OuterBottomWidth / 2
                    Case shCircle, shUShaped
                        .DiameterFocalD = approachChannel.DiameterFocalD / 2
                    Case shSillInTrapezoid, shTrapezoidInTrapezoid, shComplexTrapezoid, shTrapezoidInRectangle
                        If (approachChannel.Shape = shSimpleTrapezoid) Then
                            .OuterBottomWidth = approachChannel.BottomWidth
                        Else
                            .OuterBottomWidth = approachChannel.OuterBottomWidth
                        End If
                        .BottomWidth = controlSection.BottomWidth
                        .Z3 = approachChannel.Z1
                End Select
            End With
        End If

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) _
        Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

End Class