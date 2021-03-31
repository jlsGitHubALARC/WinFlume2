
'*************************************************************************************************************
' Class RunContourSimulations - Run SRFR simulations for specified Operations Contour using background threads
'
'
'*************************************************************************************************************
Imports Srfr
Imports Srfr.SrfrAPI
Imports Srfr.SolutionModel

Public Class RunContourSimulations

#Region " Member Data "
    '
    ' SRFR support for running Simulations in the background
    '
    Friend SrfrRunMgr As SrfrRunManager                 ' Run Manager for background threads
    Private SrfrSim As Srfr.SrfrSimulation              ' Package for running background simulations
    Private NumThreads As Integer
    '
    ' Application variables
    '
    Private RunNo As Integer = 0                       ' SRFR run number

    Private Running As Boolean = False
    Friend Sub StopExecution()
        Running = False
    End Sub

#End Region

#Region " Properties "

    Public Property SrfrStatusMessage As String
        Get
            Return Me.SrfrStatus.Text
        End Get
        Set(value As String)
            Me.SrfrStatus.Text = value
        End Set
    End Property

    Public Property ProgressMessage As String
        Get
            Return Me.ProgressLabel.Text
        End Get
        Set(value As String)
            Me.ProgressLabel.Text = value
        End Set
    End Property

#End Region

#Region " Initialization "

    Private Sub RunContourSimulations_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load

        SrfrRunMgr = New SrfrRunManager                 ' Create Run Manager for background threads

        NumThreads = SrfrRunMgr.SrfrSims.Length         ' Get max number of available background threads

        ' Create the SRFR Threading Controls for background thread simulations
        Dim margin As Integer = 15
        Dim locY As Integer = margin
        For Each SrfrSim In SrfrRunMgr.SrfrSims
            SrfrSim.uiControl = New SrfrThreadControl With {
                .Location = New Point(margin, locY)
            }
            locY += SrfrSim.uiControl.Height + margin

            Me.SrfrControlsPanel.Controls.Add(SrfrSim.uiControl)
        Next SrfrSim

        SrfrStatusMessage = "Running SRFR Simulations using " _
                            & SrfrRunMgr.SrfrSims.Length.ToString _
                            & " background threads "

    End Sub

#End Region

#Region " Methods "

    Public Sub WaitforSrfrSimsToComplete()
        While (0 < SrfrRunMgr.SimsRunningCount)
            Application.DoEvents()
        End While
    End Sub

    Public Function GetAvailableSrfrSimulation() As Srfr.SrfrSimulation

        ' Wait for available background thread
        While (NumThreads <= SrfrRunMgr.SimsRunningCount)
            Application.DoEvents()
        End While

        SrfrSim = SrfrRunMgr.AvailableSrfrSim()
        Debug.Assert(SrfrSim IsNot Nothing)

        Return SrfrSim
    End Function

#End Region

#Region " UI Event Handles "

    Private Sub AbortButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles AbortButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

End Class
