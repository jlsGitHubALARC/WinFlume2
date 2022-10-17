
'*************************************************************************************************************
' Class WizardStep - baseclass for all WinFlume Wizard steps
'*************************************************************************************************************
Public Class WizardStep

#Region " Member Data "

    Protected mWinFlume As WinFlumeForm         ' Main WinFlume UI window
    Protected mFlume As Flume.FlumeType         ' Flume.dll data

#End Region

#Region " Wizard Step Interface "

    '*********************************************************************************************************
    ' Overridable Function Panel1() / Panel2() - subclass SHOULD override these methods to return the step
    '                                            specific panels.  The baseclass' StepPanel1 and StepPanel2
    '                                            provide areas for a subclass to insert its UI
    '
    ' Note - if a subclass does not override these methods to return its own Panel, the baseclass' Panel(s)
    ' will be displayed and will be blank.
    '*********************************************************************************************************
    Public Overridable Function Panel1() As Panel
        Return Me.StepPanel1
    End Function

    Public Overridable Function Panel2() As Panel
        Return Me.StepPanel2
    End Function

    '*********************************************************************************************************
    ' Overridable Functions for a subclass to use to implement its step functionality
    '
    ' Each of these methods is called by the FlumeWizard as the user progresses through the Wizard.
    ' Subclasses may override any/all methods to implement their particular step.
    '
    ' StartStep()       - called when step is selected; allows subclass' step to setup WinFlume UI
    ' EndStep()         - called prior to next step being started
    ' HelpButton()      - called when 'Help' button is pressed
    ' NextButton()      - called when 'Next >' button is pressed; see GettingStarted for sample use
    ' PrevButton()      - called when '< Prev' button is pressed
    '*********************************************************************************************************
    Public Overridable Function StartStep() As Boolean
        StartStep = True
    End Function

    Public Overridable Function EndStep() As Boolean
        EndStep = True
    End Function

    Public Overridable Function HelpButton() As Boolean
        HelpButton = True
    End Function

    Public Overridable Function NextButton() As Boolean
        NextButton = True
    End Function

    Public Overridable Function PrevButton() As Boolean
        PrevButton = True
    End Function

#End Region

End Class
