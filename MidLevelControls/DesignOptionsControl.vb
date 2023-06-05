
'*************************************************************************************************************
' Class DesignOptionsControl - UserControl for displaying & editing the Design Evaluation Options
'*************************************************************************************************************
Imports Flume.Globals

Imports WinFlume.UnitsDialog            ' Unit conversion support
Imports WinFlume.WinFlumeSectionType

Public Class DesignOptionsControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    Private mReplacedAlternativeDesignOption As Boolean = False
    '
    ' Flume DLL accessors
    '
    Private mFlume As Flume.FlumeType = Nothing
    Private mFlumeAPI As FlumeAPI = Nothing
    '
    ' Design Options Control data
    '
    Private mIncrementUnitsOrder As LengthUnits() = {LengthUnits.Meters,
                                                     LengthUnits.Feet,
                                                     LengthUnits.Millimeters,
                                                     LengthUnits.Inches,
                                                     LengthUnits.Centimeters}
    '
    ' Available Design Options by Control Section shape
    '
    ' Note - array is indexed using the Control Section's shape (e.g. shSimpleTrapezoid, shSillInCircle)
    '
    Private mDesignOptions As Integer() = {MethodOfContraction.RaiseLowerSillHeight _
                                         + MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.VarySideContraction,         ' shSimpleTrapezoid
                                           MethodOfContraction.RaiseLowerSillHeight _
                                         + MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.VarySideContraction,         ' shRectangular
                                           MethodOfContraction.RaiseLowerSillHeight _
                                         + MethodOfContraction.RaiseLowerEntireSection,     ' shVShaped
                                           MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.VarySideContraction,         ' shCircle
                                           MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.VarySideContraction,         ' shUShaped
                                           MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.VarySideContraction,         ' shParabola
                                           MethodOfContraction.RaiseLowerSillHeight _
                                         + MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.VarySideContraction _
                                         + MethodOfContraction.RaiseLowerInnerSection,      ' shComplexTrapezoid
                                           MethodOfContraction.RaiseLowerSillHeight _
                                         + MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.RaiseLowerInnerSection _
                                         + MethodOfContraction.VarySideContraction,         ' shTrapezoidInCircle
                                           MethodOfContraction.RaiseLowerSillHeight _
                                         + MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.RaiseLowerInnerSection _
                                         + MethodOfContraction.VarySideContraction,
                                           MethodOfContraction.RaiseLowerSillHeight _       ' shTrapezoidInUShaped
                                         + MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.RaiseLowerInnerSection,
                                           MethodOfContraction.RaiseLowerSillHeight _       ' shTrapezoidInParabola
                                         + MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.RaiseLowerInnerSection,
                                           MethodOfContraction.RaiseLowerSillHeight,        ' shSillInCircle
                                           MethodOfContraction.RaiseLowerSillHeight _       ' shSillInUShaped
                                         + MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.RaiseLowerInnerSection,
                                           MethodOfContraction.VarySideContraction,         ' shSillInParabola
                                           MethodOfContraction.RaiseLowerEntireSection _
                                         + MethodOfContraction.RaiseLowerInnerSection _
                                         + MethodOfContraction.VarySideContraction}         ' shVInRectangle

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Design Evaluation Options
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        mReplacedAlternativeDesignOption = False
        Me.UpdateUI()
    End Sub

    Private mUpdatingUI As Boolean = False
    Private Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume accessors
        If (mFlume Is Nothing) Then
            Return
        End If

        mFlumeAPI = WinFlumeForm.GetFlumeAPI
        If (mFlumeAPI Is Nothing) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Return
        End If
        mUpdatingUI = True

        ' Load Increment Units drop-down list
        Me.DesignIncrementUnits.Items.Clear()
        For Each IncUnits As LengthUnits In mIncrementUnitsOrder
            Me.DesignIncrementUnits.Items.Add(LengthUnitsNames(IncUnits))
        Next IncUnits

        Me.DesignIncrementUnits.DefaultValue = WinFlumeForm.DefaultFlume.DesignIncrementUnitsIndex
        Me.DesignIncrementUnits.Value = mFlume.DesignIncrementUnitsIndex

        ' Update Design Evaluation Options controls
        Dim SiDesignIncr As Single = mFlume.DesignIncrementValue
        Dim UiIncrUnits As LengthUnits = mIncrementUnitsOrder(mFlume.DesignIncrementUnitsIndex)
        Me.DesignIncrement.SiDefaultValue = UiLengthValue(WinFlumeForm.DefaultFlume.DesignIncrementValue, UiIncrUnits)
        Me.DesignIncrement.UiValue = UiLengthValue(SiDesignIncr, UiIncrUnits)
        Me.DesignIncrement.Label = Me.DesignIncrementLabel.Text

        Me.AdjustSillHeight.Label = My.Resources.ControlSectionAdjustment
        Me.AdjustSillHeight.RbValue = RaiseSillHeight
        Me.AdjustSillHeight.UiValue = mFlumeAPI.ContractionAdjustment

        Me.AdjustEntireSection.Label = My.Resources.ControlSectionAdjustment
        Me.AdjustEntireSection.RbValue = RaiseLowerEntireSection
        Me.AdjustEntireSection.UiValue = mFlumeAPI.ContractionAdjustment

        Me.AdjustInnerSection.Label = My.Resources.ControlSectionAdjustment
        Me.AdjustInnerSection.RbValue = RaiseLowerInnerSection
        Me.AdjustInnerSection.UiValue = mFlumeAPI.ContractionAdjustment

        Me.AdjustSideContraction.Label = My.Resources.ControlSectionAdjustment
        Me.AdjustSideContraction.RbValue = VarySideContraction
        Me.AdjustSideContraction.UiValue = mFlumeAPI.ContractionAdjustment

        Dim ctrlSection As Flume.SectionType = mFlume.Section(cControl)
        Dim designOptions As Integer

        If (mFlume.CrestType = MovableCrest) Then
            ' Limit Method of Contaction to Vary Side Contraction only
            designOptions = MethodOfContraction.VarySideContraction
        Else
            ' Method(s) of Contraction depend on whether Control is new UI supported cross-section
            If (ctrlSection.GetType Is GetType(WinFlumeSectionType)) Then
                ' New UI supported cross-section
                Dim WinFlumeSection As WinFlumeSectionType = DirectCast(ctrlSection, WinFlumeSectionType)
                designOptions = WinFlumeSection.MethodsOfContraction
            Else ' mSection.GetType Is GetType(Flume.SectionType)
                ' Flume.dll supported cross-section
                Dim ctrlShape As Integer = ctrlSection.Shape
                Debug.Assert(ctrlShape - 1 < mDesignOptions.Length)
                designOptions = mDesignOptions(ctrlShape - 1)
            End If
        End If

        Me.AdjustSillHeight.Enabled = BitSet(designOptions, MethodOfContraction.RaiseLowerSillHeight)
        Me.AdjustEntireSection.Enabled = BitSet(designOptions, MethodOfContraction.RaiseLowerEntireSection)
        Me.AdjustInnerSection.Enabled = BitSet(designOptions, MethodOfContraction.RaiseLowerInnerSection)
        Me.AdjustSideContraction.Enabled = BitSet(designOptions, MethodOfContraction.VarySideContraction)

        ' Add/Remove design options
        Dim shape As Integer = mFlume.Section(cControl).Shape

        If (Not WinFlumeForm.ControlMatchedToApproach) Then     ' NOT matched
            Select Case shape
                Case shRectangular
                    Me.AdjustSillHeight.Enabled = False
                Case shVShaped
                    Me.AdjustSillHeight.Enabled = False
                    Me.AdjustEntireSection.Enabled = True
                    Me.AdjustInnerSection.Enabled = False
                    Me.AdjustSideContraction.Enabled = False
                Case shVInRectangle
                    Me.AdjustSillHeight.Enabled = False
                    Me.AdjustEntireSection.Enabled = True
                    Me.AdjustInnerSection.Enabled = True
                    Me.AdjustSideContraction.Enabled = True
                Case shComplexTrapezoid
                    Me.AdjustSillHeight.Enabled = True
                Case shTrapezoidInUShaped
                    Me.AdjustSideContraction.Enabled = True
                Case shTrapezoidInParabola
                    Me.AdjustSideContraction.Enabled = True
            End Select
        End If

        ' Validate Adjustment Selection is valid. If not, selecte a valid one.
        If (mReplacedAlternativeDesignOption = False) Then
            Dim OldAdjSelection As Integer = mFlume.ContractionAdjustment
            Dim NewAdjSelection As Integer = 0

            If (Not Me.AdjustSillHeight.Enabled) And (Me.AdjustSillHeight.Checked) Then
                ' Disabled and checked = invalid combination
                If (Me.AdjustEntireSection.Enabled) Then
                    NewAdjSelection = RaiseLowerEntireSection
                    Me.AdjustEntireSection.Checked = True
                ElseIf (Me.AdjustInnerSection.Enabled) Then
                    NewAdjSelection = RaiseLowerInnerSection
                    Me.AdjustInnerSection.Checked = True
                ElseIf (Me.AdjustSideContraction.Enabled) Then
                    NewAdjSelection = VarySideContraction
                    Me.AdjustSideContraction.Checked = True
                End If
            End If

            If (Not Me.AdjustEntireSection.Enabled) And (Me.AdjustEntireSection.Checked) Then
                ' Disabled and checked = invalid combination
                If (Me.AdjustSillHeight.Enabled) Then
                    NewAdjSelection = RaiseSillHeight
                    Me.AdjustSillHeight.Checked = True
                ElseIf (Me.AdjustInnerSection.Enabled) Then
                    NewAdjSelection = RaiseLowerInnerSection
                    Me.AdjustInnerSection.Checked = True
                ElseIf (Me.AdjustSideContraction.Enabled) Then
                    NewAdjSelection = VarySideContraction
                    Me.AdjustSideContraction.Checked = True
                End If
            End If

            If (Not Me.AdjustInnerSection.Enabled) And (Me.AdjustInnerSection.Checked) Then
                ' Disabled and checked = invalid combination
                If (Me.AdjustEntireSection.Enabled) Then
                    NewAdjSelection = RaiseLowerEntireSection
                    Me.AdjustEntireSection.Checked = True
                ElseIf (Me.AdjustSillHeight.Enabled) Then
                    NewAdjSelection = RaiseSillHeight
                    Me.AdjustSillHeight.Checked = True
                ElseIf (Me.AdjustSideContraction.Enabled) Then
                    NewAdjSelection = VarySideContraction
                    Me.AdjustSideContraction.Checked = True
                End If
            End If

            If (Not Me.AdjustSideContraction.Enabled) And (Me.AdjustSideContraction.Checked) Then
                ' Disabled and checked = invalid combination
                If (Me.AdjustEntireSection.Enabled) Then
                    NewAdjSelection = RaiseLowerEntireSection
                    Me.AdjustEntireSection.Checked = True
                ElseIf (Me.AdjustInnerSection.Enabled) Then
                    NewAdjSelection = RaiseLowerInnerSection
                    Me.AdjustInnerSection.Checked = True
                ElseIf (Me.AdjustSillHeight.Enabled) Then
                    NewAdjSelection = RaiseSillHeight
                    Me.AdjustSillHeight.Checked = True
                End If
            End If

            If (NewAdjSelection <> 0) And (OldAdjSelection <> NewAdjSelection) Then

                mFlume.ContractionAdjustment = NewAdjSelection
                '
                ' Display message informing user that the Alternative Design option in the currently opened file
                ' is no longer supported and was replaced with a supported method.
                '
                Dim title As String = "Alternative Design Option is no longer supported"

                Dim msg As String = "This Design Option is no longer supported:" & vbCrLf & vbCrLf

                Select Case OldAdjSelection
                    Case RaiseSillHeight
                        msg &= "    Raise or Lower Height of Sill"
                    Case RaiseLowerEntireSection
                        msg &= "    Raise or Lower Entire Section"
                    Case RaiseLowerInnerSection
                        msg &= "    Raise or Lower Inner Section"
                    Case VarySideContraction
                        msg &= "    Vasy Side Contraction"
                End Select

                msg &= vbCrLf & vbCrLf

                msg &= "This Design Option replaces the unsupported option:" & vbCrLf & vbCrLf

                Select Case NewAdjSelection
                    Case RaiseSillHeight
                        msg &= "    Raise or Lower Height of Sill"
                    Case RaiseLowerEntireSection
                        msg &= "    Raise or Lower Entire Section"
                    Case RaiseLowerInnerSection
                        msg &= "    Raise or Lower Inner Section"
                    Case VarySideContraction
                        msg &= "    Vasy Side Contraction"
                End Select

                MsgBox(msg, MsgBoxStyle.Information, title)

            End If

            mReplacedAlternativeDesignOption = True
        End If

        mUpdatingUI = False
    End Sub

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Protected Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        Me.UpdateUI()
    End Sub

    Protected Sub LengthUnitsChanged() Handles mWinFlumeForm.LengthUnitsChanged
        Me.UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub DesignIncrement_ValueChanged() Handles DesignIncrement.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            ' Convert UI value to SI; units are non-standard so they must be handled here
            Dim UiIncrUnits As LengthUnits = mIncrementUnitsOrder(Me.DesignIncrementUnits.SelectedIndex)
            Dim UiDesignIncr As Single = Me.DesignIncrement.UiValue()
            Dim SIDesignIncr As Single = SiLengthValue(UiDesignIncr, UiIncrUnits)
            If Not (mFlume.DesignIncrementValue = SIDesignIncr) Then
                mFlume.DesignIncrementValue = SIDesignIncr
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub DesignIncrementUnits_ValueChanged() Handles DesignIncrementUnits.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            Dim UiIncrUnits As Integer = Me.DesignIncrementUnits.SelectedIndex
            If Not (mFlume.DesignIncrementUnitsIndex = UiIncrUnits) Then
                mFlume.DesignIncrementUnitsIndex = UiIncrUnits
                mWinFlumeForm.RaiseFlumeDataChanged()
            End If
        End If
    End Sub

    Private Sub AdjustSillHeight_ValueChanged(ByVal NewValue As Integer) _
    Handles AdjustSillHeight.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                If Not (mFlumeAPI.ContractionAdjustment = NewValue) Then
                    mFlumeAPI.ContractionAdjustment = NewValue
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Private Sub AdjustEntireSection_ValueChanged(ByVal NewValue As Integer) _
    Handles AdjustEntireSection.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                If Not (mFlumeAPI.ContractionAdjustment = NewValue) Then
                    mFlumeAPI.ContractionAdjustment = NewValue
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Private Sub AdjustInnerSection_ValueChanged(ByVal NewValue As Integer) _
    Handles AdjustInnerSection.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                If Not (mFlumeAPI.ContractionAdjustment = NewValue) Then
                    mFlumeAPI.ContractionAdjustment = NewValue
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Private Sub AdjustSideContraction_ValueChanged(ByVal NewValue As Integer) _
    Handles AdjustSideContraction.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                If Not (mFlumeAPI.ContractionAdjustment = NewValue) Then
                    mFlumeAPI.ContractionAdjustment = NewValue
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub DesignOptionsControl_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub DesignOptionsControl_Resize(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Resize

    End Sub

#End Region

End Class
