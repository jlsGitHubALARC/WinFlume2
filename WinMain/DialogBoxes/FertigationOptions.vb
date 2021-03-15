
'*************************************************************************************************************
' FertigationOptions - Fertigation Options dialog box
'*************************************************************************************************************
Imports Srfr.SoluteTransport

Public Class FertigationOptions

#Region " Member Data "

    Private mDictionary As Dictionary = Dictionary.Instance

    Private mWinSRFR As WinSRFR = Nothing

#End Region

#Region " Properties "
    '
    ' Properties to get/set UI values
    '
    Public Property CharacteristicType() As CharacteristicTypes
        Get
            If (Me.PieceWiseButton.Checked) Then
                Return CharacteristicTypes.PieceWise
            Else
                Return CharacteristicTypes.Continuous
            End If
        End Get
        Set(ByVal value As CharacteristicTypes)
            If (value = CharacteristicTypes.PieceWise) Then
                Me.PieceWiseButton.Checked = True
            Else
                Me.ContinuousButton.Checked = True
            End If

            Me.UpdateUI()
        End Set
    End Property

    Public Property EnableDispersion() As Boolean
        Get
            Return Me.EnableFertigationDispersion.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.EnableFertigationDispersion.Checked = value

            Me.UpdateUI()
        End Set
    End Property

    Public Property AdvectionInterpolationMethod() As AdvectionInterpolationMethods
        Get
            If (Me.AkimaButton.Checked) Then
                Return AdvectionInterpolationMethods.AkimaSpline
            Else
                Return AdvectionInterpolationMethods.CubicSpline
            End If
        End Get
        Set(ByVal value As AdvectionInterpolationMethods)
            If (value = AdvectionInterpolationMethods.AkimaSpline) Then
                Me.AkimaButton.Checked = True
            Else
                Me.CubicButton.Checked = True
            End If

            Me.UpdateUI()
        End Set
    End Property

    Public Property DispersivityCoefficientMethod() As DispersivityCoefficientMethods
        Get
            If (Me.FischerButton.Checked) Then
                Return DispersivityCoefficientMethods.Fischer
            ElseIf (Me.ElderButton.Checked) Then
                Return DispersivityCoefficientMethods.Elder
            ElseIf Me.DengButton.Checked Then
                Return DispersivityCoefficientMethods.Deng
            ElseIf Me.RutherfordButton.Checked Then
                Return DispersivityCoefficientMethods.Rutherford
            Else
                Return DispersivityCoefficientMethods.SpecifiedKx
            End If
        End Get
        Set(ByVal value As DispersivityCoefficientMethods)
            If (value = DispersivityCoefficientMethods.Fischer) Then
                Me.FischerButton.Checked = True
            ElseIf (value = DispersivityCoefficientMethods.Elder) Then
                Me.ElderButton.Checked = True
            ElseIf (value = DispersivityCoefficientMethods.Deng) Then
                Me.DengButton.Checked = True
            ElseIf (value = DispersivityCoefficientMethods.Rutherford) Then
                Me.RutherfordButton.Checked = True
            Else
                Me.SpecifiedKxButton.Checked = True
            End If

            Me.UpdateUI()
        End Set
    End Property

    Public ReadOnly Property ElderCe() As Double
        Get
            Return Me.ElderCeControl.Value
        End Get
    End Property

    Public ReadOnly Property SpecifiedKx As Double
        Get
            Return Me.KxControl.Value
        End Get
    End Property

#End Region

#Region " Initialization "

    Dim mInitializing As Boolean = False
    Public Sub InitUI(ByVal Fertigation As Fertigation, ByVal MyStore As DataStore.ObjectNode, _
                      ByVal WinSRFRref As WinSRFR)
        If ((Fertigation IsNot Nothing) And (MyStore IsNot Nothing) And (WinSRFRref IsNot Nothing)) Then
            mInitializing = True

            Me.Text = mDictionary.ControlText(Me)

            Me.ElderCeControl.LinkToModel(MyStore, Fertigation.ElderCeProperty)
            Me.KxControl.LinkToModel(MyStore, Fertigation.SpecifiedKxProperty)

            mWinSRFR = WinSRFRref

            mInitializing = False
        End If
    End Sub

#End Region

#Region " Methods "

    Private Sub UpdateUI()
        If ((mWinSRFR Is Nothing) Or (mInitializing)) Then
            Return
        End If

        If (mWinSRFR.UserLevel = UserLevels.Research) Then ' Research level user

            Me.AdvectionMethodGroup.Show()

            Me.DengButton.Show()
            Me.FischerButton.Show()
            Me.RutherfordButton.Show()

            Me.ContinuousButton.Show()
            Me.PieceWiseButton.Show()

            If (Me.ContinuousButton.Checked) Then ' Continuous Characteristics
                Me.EnableFertigationDispersion.Enabled = False
                Me.EnableFertigationDispersion.Checked = False
                Me.AdvectionMethodGroup.Enabled = False
                Me.DispersivityCoefficientGroup.Enabled = False
            Else ' Piece-Wise Characteristics
                Me.EnableFertigationDispersion.Enabled = True
                Me.AdvectionMethodGroup.Enabled = True

                If (Me.EnableFertigationDispersion.Checked = True) Then
                    Me.DispersivityCoefficientGroup.Enabled = True

                    Me.CeLabel.Enabled = Me.ElderButton.Checked
                    Me.ElderCeControl.Enabled = Me.ElderButton.Checked

                    Me.KxControl.Enabled = Me.SpecifiedKxButton.Checked
                Else
                    Me.DispersivityCoefficientGroup.Enabled = False
                End If
            End If

        Else ' not Research user

            Me.AdvectionMethodGroup.Hide()

            Me.EnableFertigationDispersion.Enabled = True

            Me.DengButton.Hide()
            Me.FischerButton.Hide()
            Me.RutherfordButton.Hide()

            Me.ContinuousButton.Hide()
            Me.PieceWiseButton.Hide()

            If (Me.EnableFertigationDispersion.Checked) Then ' force Piece-Wise
                Me.ContinuousButton.Enabled = False
                Me.PieceWiseButton.Enabled = True
                Me.PieceWiseButton.Checked = True

                Me.AdvectionMethodGroup.Enabled = True
                Me.DispersivityCoefficientGroup.Enabled = True

                Me.CeLabel.Enabled = Me.ElderButton.Checked
                Me.ElderCeControl.Enabled = Me.ElderButton.Checked

                Me.KxControl.Enabled = Me.SpecifiedKxButton.Checked

            Else ' force Continuous
                Me.PieceWiseButton.Enabled = False
                Me.ContinuousButton.Enabled = True
                Me.ContinuousButton.Checked = True

                Me.AdvectionMethodGroup.Enabled = False
                Me.DispersivityCoefficientGroup.Enabled = False
            End If
        End If

    End Sub

#End Region

#Region " UI Event Handlers "

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PieceWiseButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles PieceWiseButton.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub ContinuousButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ContinuousButton.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub EnableFertigationDispersion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles EnableFertigationDispersion.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub AkimaButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles AkimaButton.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub CubicButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CubicButton.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub FischerButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FischerButton.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub ElderButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles ElderButton.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub DengButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles DengButton.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub RutherfordButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RutherfordButton.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub SpecifiedKxButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SpecifiedKxButton.CheckedChanged
        Me.UpdateUI()
    End Sub

    Private Sub FertigationOptions_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.HelpButtonClicked
        WinSRFR.ShowDialogPdfHelpManual("sec:SoluteTransport", 0)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            WinSRFR.ShowDialogPdfHelpManual("sec:SoluteTransport", 0)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

End Class
