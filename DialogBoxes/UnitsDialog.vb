
'*************************************************************************************************************
' Class UnitsDialog - dialog box for selecting the units for the WinFlume application
'
' The UnitsDialog is used to:
'   1) Set the default units in the Registry
'   2) Load the default units from the Registry for a new project
'   3) Change/convert units for the current project
'
' The UnitsDialog provides:
'   1) User selection of the various units to use throughout WinFlume
'   2) Localization of name & abbreviation strings for the units
'       a) The Length, Velocity & Discharge strings are localized using the UnitsDialog designer
'       b) The Time & Slope strings are localized using My.Resources
'*************************************************************************************************************
Imports Flume
Imports Flume.FlumeType

Public Class UnitsDialog

#Region " Constants & Enumerations "

    Enum UnitsDialogModes
        SetDefaultUnits
        SetNewProjectUnits
        ChangeProjectUnits
    End Enum

#End Region

#Region " Member Data "

    ' Variables to save original dialog configuration
    Private mDlgTitle As String
    Private mBtnConvertText As String
    Private mBtnOkLoc As Point
    Private mBtnOkSize As Size
    Private mBtnOkText As String
    Private mBtnCancelText As String

#End Region

#Region " Constructor(s) "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Load localized Length names/abbreviations from UnitsDialog UI
        Debug.Assert(LengthUnitsNames.Length = LengthUnitsAbbreviations.Length)
        LengthUnitsNames(0) = Me.MetersButton.Text
        LengthUnitsNames(1) = Me.FeetButton.Text
        LengthUnitsNames(2) = Me.MillimetersButton.Text
        LengthUnitsNames(3) = Me.InchesButton.Text
        LengthUnitsNames(4) = Me.CentimetersButton.Text
        LengthUnitsAbbreviations(0) = Me.MetersAbbrev.Text
        LengthUnitsAbbreviations(1) = Me.FeetAbbrev.Text
        LengthUnitsAbbreviations(2) = Me.MillimetersAbbrev.Text
        LengthUnitsAbbreviations(3) = Me.InchesAbbrev.Text
        LengthUnitsAbbreviations(4) = Me.CentimetersAbbrev.Text

        ' Load localized Velocity names/abbreviations from UnitsDialog UI
        Debug.Assert(VelocityUnitsNames.Length = VelocityUnitsAbbreviations.Length)
        VelocityUnitsNames(0) = Me.MetersSecondButton.Text
        VelocityUnitsNames(1) = Me.FeetSecondButton.Text
        VelocityUnitsAbbreviations(0) = Me.MetersSecondAbbrev.Text
        VelocityUnitsAbbreviations(1) = Me.FeetSecondAbbrev.Text

        ' Load localized Discharge names/abbreviations from UnitsDialog UI
        Debug.Assert(DischargeUnitsNames.Length = DischargeUnitsAbbreviations.Length)
        DischargeUnitsNames(0) = Me.CubicMetersSecondButton.Text
        DischargeUnitsNames(1) = Me.LitersSecondButton.Text
        DischargeUnitsNames(2) = Me.CubicFeetSecondButton.Text
        DischargeUnitsNames(3) = Me.GallonsMinuteButton.Text
        DischargeUnitsNames(4) = Me.AcreFeetHourButton.Text
        DischargeUnitsNames(5) = Me.MinersInchAzButton.Text
        DischargeUnitsNames(6) = Me.MinersInchIdButton.Text
        DischargeUnitsNames(7) = Me.MinersInchCoButton.Text
        DischargeUnitsNames(8) = Me.MegalitersHourButton.Text
        DischargeUnitsNames(9) = Me.MegalitersDayButton.Text
        DischargeUnitsNames(10) = Me.MillionGallonsDayButton.Text
        DischargeUnitsAbbreviations(0) = Me.CubicMetersSecondAbbrev.Text
        DischargeUnitsAbbreviations(1) = Me.LitersSecondAbbrev.Text
        DischargeUnitsAbbreviations(2) = Me.CubicFeetSecondAbbrev.Text
        DischargeUnitsAbbreviations(3) = Me.GallonsMinuteAbbrev.Text
        DischargeUnitsAbbreviations(4) = Me.AcreFeetHourAbbrev.Text
        DischargeUnitsAbbreviations(5) = Me.MinersInchAzAbbrev.Text
        DischargeUnitsAbbreviations(6) = Me.MinersInchIdAbbrev.Text
        DischargeUnitsAbbreviations(7) = Me.MinersInchCoAbbrev.Text
        DischargeUnitsAbbreviations(8) = Me.MegalitersHourAbbrev.Text
        DischargeUnitsAbbreviations(9) = Me.MegalitersDayAbbrev.Text
        DischargeUnitsAbbreviations(10) = Me.MillionGallonsDayAbbrev.Text

        ' Load localized Time names/abbreviations from My.Resources
        TimeUnitsNames(0) = My.Resources.Seconds
        TimeUnitsNames(1) = My.Resources.Minutes
        TimeUnitsNames(2) = My.Resources.Hours
        TimeUnitsNames(3) = My.Resources.Days
        TimeUnitsAbbreviations(0) = My.Resources.sec
        TimeUnitsAbbreviations(1) = My.Resources.min
        TimeUnitsAbbreviations(2) = My.Resources.hr
        TimeUnitsAbbreviations(3) = My.Resources.day

        ' Load localized Slope names/abbreviations from My.Resources
        SlopeUnitsNames(0) = My.Resources.MetersPerMeter
        SlopeUnitsNames(1) = My.Resources.FeetPerFeet
        SlopeUnitsAbbreviations(0) = My.Resources.MpM
        SlopeUnitsAbbreviations(1) = My.Resources.FtpFt

        ' Save the original Title / Button text
        mDlgTitle = Me.Text
        mBtnConvertText = Me.Convert_Button.Text
        mBtnOkText = Me.OK_Button.Text
        mBtnOkLoc = Me.OK_Button.Location
        mBtnOkSize = Me.OK_Button.Size
        mBtnCancelText = Me.Cancel_Button.Text

    End Sub

#End Region

#Region " Properties "

    Public Property Flume As FlumeType                      ' Current Flume data structure

    Private Property SelectedLengthUnits As LengthUnits
        Set(value As LengthUnits)
            Select Case (value)
                Case LengthUnits.Centimeters
                    Me.CentimetersButton.Checked = True
                Case LengthUnits.Feet
                    Me.FeetButton.Checked = True
                Case LengthUnits.Inches
                    Me.InchesButton.Checked = True
                Case LengthUnits.Millimeters
                    Me.MillimetersButton.Checked = True
                Case Else
                    Me.MetersButton.Checked = True
            End Select
        End Set
        Get
            If (Me.CentimetersButton.Checked) Then
                Return LengthUnits.Centimeters
            End If
            If (Me.FeetButton.Checked) Then
                Return LengthUnits.Feet
            End If
            If (Me.InchesButton.Checked) Then
                Return LengthUnits.Inches
            End If
            If (Me.MillimetersButton.Checked) Then
                Return LengthUnits.Millimeters
            End If

            Return LengthUnits.Meters
        End Get
    End Property

    Private Property SelectedVelocityUnits As VelocityUnits
        Set(value As VelocityUnits)
            Select Case (value)
                Case VelocityUnits.FeetPerSecond
                    Me.FeetSecondButton.Checked = True
                Case Else
                    Me.MetersSecondButton.Checked = True
            End Select
        End Set
        Get
            If (Me.FeetSecondButton.Checked) Then
                Return VelocityUnits.FeetPerSecond
            End If

            Return VelocityUnits.MetersPerSecond
        End Get
    End Property

    Private Property SelectedDischargeUnits As DischargeUnits
        Set(value As DischargeUnits)
            Select Case (value)
                Case DischargeUnits.AcreFeetPerHour
                    Me.AcreFeetHourButton.Checked = True
                Case DischargeUnits.CubicFeetPerSecond
                    Me.CubicFeetSecondButton.Checked = True
                Case DischargeUnits.GallonsPerMinute
                    Me.GallonsMinuteButton.Checked = True
                Case DischargeUnits.LitersPerSecond
                    Me.LitersSecondButton.Checked = True
                Case DischargeUnits.MegalitersPerDay
                    Me.MegalitersDayButton.Checked = True
                Case DischargeUnits.MegalitersPerHour
                    Me.MegalitersHourButton.Checked = True
                Case DischargeUnits.MillionGallonsPerDay
                    Me.MillionGallonsDayButton.Checked = True
                Case DischargeUnits.MinersInchesAZ
                    Me.MinersInchAzButton.Checked = True
                Case DischargeUnits.MinersInchesCO
                    Me.MinersInchCoButton.Checked = True
                Case DischargeUnits.MinersInchesID
                    Me.MinersInchIdButton.Checked = True
                Case Else
                    Me.CubicMetersSecondButton.Checked = True
            End Select
        End Set
        Get
            If (Me.AcreFeetHourButton.Checked) Then
                Return DischargeUnits.AcreFeetPerHour
            End If
            If (Me.CubicFeetSecondButton.Checked) Then
                Return DischargeUnits.CubicFeetPerSecond
            End If
            If (Me.GallonsMinuteButton.Checked) Then
                Return DischargeUnits.GallonsPerMinute
            End If
            If (Me.LitersSecondButton.Checked) Then
                Return DischargeUnits.LitersPerSecond
            End If
            If (Me.MegalitersDayButton.Checked) Then
                Return DischargeUnits.MegalitersPerDay
            End If
            If (Me.MegalitersHourButton.Checked) Then
                Return DischargeUnits.MegalitersPerHour
            End If
            If (Me.MillionGallonsDayButton.Checked) Then
                Return DischargeUnits.MillionGallonsPerDay
            End If
            If (Me.MinersInchAzButton.Checked) Then
                Return DischargeUnits.MinersInchesAZ
            End If
            If (Me.MinersInchCoButton.Checked) Then
                Return DischargeUnits.MinersInchesCO
            End If
            If (Me.MinersInchIdButton.Checked) Then
                Return DischargeUnits.MinersInchesID
            End If

            Return DischargeUnits.CubicMetersPerSecond
        End Get
    End Property

    ' Set the UnitsDialog to the correct mode of operation
    Private mDialogMode As UnitsDialogModes = UnitsDialogModes.ChangeProjectUnits
    Public Property DialogMode As UnitsDialogModes
        Set(value As UnitsDialogModes)
            mDialogMode = value
            Select Case (mDialogMode)
                Case UnitsDialogModes.SetDefaultUnits
                    Me.Text = My.Resources.SelectDefaultUnits
                    Me.Convert_Button.Visible = False
                    Me.OK_Button.Text = "&" & My.Resources.SaveSelectedUnitsAsDefaults
                    Me.OK_Button.Location = mBtnOkLoc
                    Me.OK_Button.Size = mBtnOkSize
                    ReadRegistryUnits()
                Case UnitsDialogModes.SetNewProjectUnits
                    Me.Text = mDlgTitle
                    Me.Convert_Button.Visible = False
                    Me.OK_Button.Text = "&Ok"
                    Me.OK_Button.Location = Me.Cancel_Button.Location
                    Me.OK_Button.Size = Me.Cancel_Button.Size
                    ReadRegistryUnits()
                Case UnitsDialogModes.ChangeProjectUnits
                    Me.Text = mDlgTitle
                    Me.Convert_Button.Visible = True
                    Me.Convert_Button.Text = mBtnConvertText
                    Me.OK_Button.Text = mBtnOkText
                    Me.OK_Button.Location = mBtnOkLoc
                    Me.OK_Button.Size = mBtnOkSize
                    Me.Cancel_Button.Text = mBtnCancelText
                    UpdateButtons()
            End Select
        End Set
        Get
            Return mDialogMode
        End Get
    End Property

#End Region

#Region " Registry Read/Save "

    ' Read / Save selectable units to / from the Registry
    Public Sub ReadRegistryUnits()
        Dim regVal As Integer = RegistryInteger("LengthUnits")
        SelectedLengthUnits = DirectCast(regVal, UnitsDialog.LengthUnits)
        regVal = RegistryInteger("VelocityUnits")
        SelectedVelocityUnits = DirectCast(regVal, UnitsDialog.VelocityUnits)
        regVal = RegistryInteger("DischargeUnits")
        SelectedDischargeUnits = DirectCast(regVal, UnitsDialog.DischargeUnits)
    End Sub

    Public Sub SaveRegistryUnits()
        RegistryInteger("LengthUnits") = SelectedLengthUnits
        RegistryInteger("VelocityUnits") = SelectedVelocityUnits
        RegistryInteger("DischargeUnits") = SelectedDischargeUnits
    End Sub

#End Region

#Region " Time Units "

    Public Enum TimeUnits
        Seconds
        Minutes
        Hours
        Days
    End Enum

    ' These time names & abbreviations are replaced in the New() constructor
    Public Shared TimeUnitsNames As String() = {"Seconds", "Minutes", "Hours", "Days"}
    Public Shared TimeUnitsAbbreviations As String() = {"sec", "min", "hr", "day"}

    Public Const SecondsPerMinute As Single = 60.0
    Public Const MinutesPerHour As Single = 60.0
    Public Const SecondsPerHour As Single = SecondsPerMinute * MinutesPerHour
    Public Const HoursPerDay As Single = 24.0
    Public Const MinutesPerDay As Single = MinutesPerHour * HoursPerDay
    Public Const SecondsPerDay As Single = MinutesPerDay * SecondsPerMinute

    Public Shared SecondsPerUnit As Single() = {1, SecondsPerMinute, SecondsPerHour, SecondsPerDay}

#End Region

#Region " Length & Depth Units "

    Public Enum LengthUnits
        Meters
        Feet
        Millimeters
        Inches
        Centimeters
    End Enum

    ' These length/depth names & abbreviations are replaced in the New() constructor
    Public Shared LengthUnitsNames As String() = {"Meters", "Feet", "Millimeters", "Inches", "Centimeters"}
    Public Shared LengthUnitsAbbreviations As String() = {"m", "ft", "mm", "in", "cm"}
    Public Shared LengthFormatStyles As String() = {"0.0###", "0.0##", "0.0", "0.0#", "0.0#"}

    Public Const CentimeterPerInch As Single = 2.54
    Public Const CentimetersPerMeter As Single = 100.0
    Public Const MillimetersPerMeter As Single = 1000.0
    Public Const InchesPerMeter As Single = CentimetersPerMeter / CentimeterPerInch
    Public Const InchesPerFoot As Single = 12.0
    Public Const FeetPerMeter As Single = InchesPerMeter / InchesPerFoot
    '
    ' SI Length support
    '
    Private Const mSiLengthUnits As LengthUnits = LengthUnits.Meters
    Public Shared Function SiLengthUnits() As LengthUnits
        SiLengthUnits = mSiLengthUnits
    End Function

    Public Shared Function SiLengthUnitsText() As String
        SiLengthUnitsText = LengthUnitsAbbreviations(SiLengthUnits)
    End Function

    Public Shared Function SiLengthFormatStyle() As String
        SiLengthFormatStyle = LengthFormatStyles(SiLengthUnits)
    End Function

    Public Shared Function SiLengthValue(ByVal UiValue As Single, ByVal UiUnits As LengthUnits) As Single
        SiLengthValue = UiValue

        Select Case (UiUnits)
            Case LengthUnits.Feet
                SiLengthValue = UiValue / FeetPerMeter
            Case LengthUnits.Millimeters
                SiLengthValue = UiValue / MillimetersPerMeter
            Case LengthUnits.Inches
                SiLengthValue = UiValue / InchesPerMeter
            Case LengthUnits.Centimeters
                SiLengthValue = UiValue / CentimetersPerMeter
        End Select
    End Function
    '
    ' UI Length support
    '
    Public Shared Property UiLengthUnits() As LengthUnits = LengthUnits.Meters

    Public Shared Function LengthUnitsFromText(ByVal UnitsText As String) As LengthUnits
        LengthUnitsFromText = LengthUnits.Meters

        If (LengthUnitsAbbreviations.Contains(UnitsText)) Then
            Dim ldx As Integer = Array.IndexOf(LengthUnitsAbbreviations, UnitsText)
            LengthUnitsFromText = DirectCast(ldx, LengthUnits)
        End If
    End Function

    Public Shared Function ParseLengthUnits(ByVal Text As String) As LengthUnits
        ParseLengthUnits = LengthUnits.Meters

        Dim tokens As String() = Text.Split(" (){}".ToCharArray)
        For Each token As String In tokens
            If (LengthUnitsAbbreviations.Contains(token)) Then
                ParseLengthUnits = LengthUnitsFromText(token)
                Exit For
            End If
        Next token
    End Function

    Public Shared Function UiLengthUnitsText() As String
        UiLengthUnitsText = LengthUnitsAbbreviations(UiLengthUnits)
    End Function

    Public Shared Function UiLengthFormatStyle() As String
        UiLengthFormatStyle = LengthFormatStyles(UiLengthUnits)
    End Function

    Public Shared Function UiLengthValue(ByVal SiValue As Single, ByVal UiUnits As LengthUnits) As Single
        UiLengthValue = SiValue ' Assume LengthUnits.Meters

        Select Case (UiUnits)
            Case LengthUnits.Feet
                UiLengthValue = SiValue * FeetPerMeter
            Case LengthUnits.Millimeters
                UiLengthValue = SiValue * MillimetersPerMeter
            Case LengthUnits.Inches
                UiLengthValue = SiValue * InchesPerMeter
            Case LengthUnits.Centimeters
                UiLengthValue = SiValue * CentimetersPerMeter
        End Select
    End Function

    Public Shared Function UiLengthValue(ByVal SiValue As Single) As Single
        UiLengthValue = UiLengthValue(SiValue, UiLengthUnits)
    End Function

#End Region

#Region " Slope Units "

    Public Enum SlopeUnits
        MetersPerMeter
        FeetPerFoot
    End Enum

    ' These slope names & abbreviations are replaced in the New() constructor
    Public Shared SlopeUnitsNames As String() = {"MetersPerMeter", "FeetPerFeet"}
    Public Shared SlopeUnitsAbbreviations As String() = {"m/m", "ft/ft"}
    Public Shared SlopeFormatStyles As String() = {"0.0###", "0.0###"}
    '
    ' SI Slope support
    '
    Private Const mSiSlopeUnits As SlopeUnits = SlopeUnits.MetersPerMeter
    Public Shared Function SiSlopeUnits() As SlopeUnits
        SiSlopeUnits = mSiSlopeUnits
    End Function

    Public Shared Function SiSlopeUnitsText() As String
        SiSlopeUnitsText = SlopeUnitsAbbreviations(SiSlopeUnits)
    End Function

    Public Shared Function SiSlopeFormatStyle() As String
        SiSlopeFormatStyle = SlopeFormatStyles(SiSlopeUnits)
    End Function

    Public Shared Function SiSlopeValue(ByVal UiValue As Single, ByVal UiUnits As SlopeUnits) As Single
        SiSlopeValue = UiValue
    End Function
    '
    ' UI Slope support
    '
    Public Shared Property UiSlopeUnits() As SlopeUnits = SlopeUnits.MetersPerMeter

    Public Shared Function SlopeUnitsFromText(ByVal UnitsText As String) As SlopeUnits
        SlopeUnitsFromText = SlopeUnits.MetersPerMeter

        If (SlopeUnitsAbbreviations.Contains(UnitsText)) Then
            Dim ldx As Integer = Array.IndexOf(SlopeUnitsAbbreviations, UnitsText)
            SlopeUnitsFromText = DirectCast(ldx, SlopeUnits)
        End If
    End Function

    Public Shared Function ParseSlopeUnits(ByVal Text As String) As SlopeUnits
        ParseSlopeUnits = SlopeUnits.MetersPerMeter

        Dim tokens As String() = Text.Split(" (){}".ToCharArray)
        For Each token As String In tokens
            If (SlopeUnitsAbbreviations.Contains(token)) Then
                ParseSlopeUnits = SlopeUnitsFromText(token)
                Exit For
            End If
        Next token
    End Function

    Public Shared Function UiSlopeUnitsText() As String
        UiSlopeUnitsText = SlopeUnitsAbbreviations(UiSlopeUnits)
    End Function

    Public Shared Function UiSlopeFormatStyle() As String
        UiSlopeFormatStyle = SlopeFormatStyles(UiSlopeUnits)
    End Function

    Public Shared Function UiSlopeValue(ByVal SiValue As Single, ByVal UiUnits As SlopeUnits) As Single
        UiSlopeValue = SiValue
    End Function

    Public Shared Function UiSlopeValue(ByVal SiValue As Single) As Single
        UiSlopeValue = UiSlopeValue(SiValue, UiSlopeUnits)
    End Function

#End Region

#Region " Velocity Units "

    Public Enum VelocityUnits
        MetersPerSecond
        FeetPerSecond
    End Enum

    ' These velocity names & abbreviations are replaced in the New() constructor
    Public Shared VelocityUnitsNames As String() = {"Meters/Second", "Feet/Second"}
    Public Shared VelocityUnitsAbbreviations As String() = {"m/s", "ft/s"}
    Public Shared VelocityFormatStyles As String() = {"0.0###", "0.0##"}
    '
    ' SI Velocity support
    '
    Private Const mSiVelocityUnits As VelocityUnits = VelocityUnits.MetersPerSecond
    Public Shared Function SiVelocityUnits() As VelocityUnits
        SiVelocityUnits = mSiVelocityUnits
    End Function

    Public Shared Function SiVelocityUnitsText() As String
        SiVelocityUnitsText = VelocityUnitsAbbreviations(SiVelocityUnits)
    End Function

    Public Shared Function SiVelocityFormatStyle() As String
        SiVelocityFormatStyle = VelocityFormatStyles(SiVelocityUnits)
    End Function

    Public Shared Function SiVelocityValue(ByVal UiValue As Single, ByVal UiUnits As VelocityUnits) As Single
        SiVelocityValue = UiValue

        Select Case (UiUnits)
            Case VelocityUnits.FeetPerSecond
                SiVelocityValue = UiValue / FeetPerMeter
        End Select
    End Function
    '
    ' UI Velocity support
    '
    Public Shared Property UiVelocityUnits() As VelocityUnits = VelocityUnits.MetersPerSecond

    Public Shared Function VelocityUnitsFromText(ByVal UnitsText As String) As VelocityUnits
        VelocityUnitsFromText = VelocityUnits.MetersPerSecond

        If (VelocityUnitsAbbreviations.Contains(UnitsText)) Then
            Dim ldx As Integer = Array.IndexOf(VelocityUnitsAbbreviations, UnitsText)
            VelocityUnitsFromText = DirectCast(ldx, VelocityUnits)
        End If
    End Function

    Public Shared Function ParseVelocityUnits(ByVal Text As String) As VelocityUnits
        ParseVelocityUnits = VelocityUnits.MetersPerSecond

        Dim tokens As String() = Text.Split(" (){}".ToCharArray)
        For Each token As String In tokens
            If (VelocityUnitsAbbreviations.Contains(token)) Then
                ParseVelocityUnits = VelocityUnitsFromText(token)
                Exit For
            End If
        Next token
    End Function

    Public Shared Function UiVelocityUnitsText() As String
        UiVelocityUnitsText = VelocityUnitsAbbreviations(UiVelocityUnits)
    End Function

    Public Shared Function UiVelocityFormatStyle() As String
        UiVelocityFormatStyle = VelocityFormatStyles(UiVelocityUnits)
    End Function

    Public Shared Function UiVelocityValue(ByVal SiValue As Single, ByVal UiUnits As VelocityUnits) As Single
        UiVelocityValue = SiValue ' Assume VelocityUnits.MetersPerSecond

        Select Case (UiUnits)
            Case VelocityUnits.FeetPerSecond
                UiVelocityValue = SiValue * FeetPerMeter
        End Select
    End Function

    Public Shared Function UiVelocityValue(ByVal SiValue As Single) As Single
        UiVelocityValue = UiVelocityValue(SiValue, UiVelocityUnits)
    End Function

#End Region

#Region " Discharge (flow rate) Units "

    Public Enum DischargeUnits
        CubicMetersPerSecond
        LitersPerSecond
        CubicFeetPerSecond
        GallonsPerMinute
        AcreFeetPerHour
        MinersInchesAZ
        MinersInchesID
        MinersInchesCO
        MegalitersPerHour
        MegalitersPerDay
        MillionGallonsPerDay
    End Enum

    ' These discharge names & abbreviations are replaced in the New() constructor
    Public Shared DischargeUnitsNames As String() = {"Cubic Meters/Second", "Liters/Second", "Cubic Feet/Second",
                                                     "Gallons/Minute", "Acre-Feet/Hour",
                                                     "Miner's Inch (AZ)", "Miner's Inch (ID)", "Miner's Inch (CO)",
                                                     "Megaliters/Hour", "Megaliters/Day", "Million Gallons/Day"}
    Public Shared DischargeUnitsAbbreviations As String() = {"m³/s", "l/s", "cfs",
                                                             "gpm", "ac-ft/hr",
                                                             "MI (AZ)", "MI (ID)", "MI (CO)",
                                                             "ML/hr", "ML/day", "mgd"}
    Public Shared DischargeFormatStyles As String() = {"0.0###", "0.0#", "0.0##",
                                                       "0.0#", "0.0",
                                                       "0.0#", "0.0#", "0.0#",
                                                       "0.0", "0.0", "0.0"}

    Public Const LitersPerCubicMeter As Single = 1000.0
    Public Const CubicMetersPerMegaLiter As Single = 1000.0
    Public Const CubicFeetPerCubicMeter As Single = FeetPerMeter ^ 3
    Public Const GallonsPerCubicFoot As Single = 7.48052
    Public Const GallonsPerCubicMeter As Single = GallonsPerCubicFoot * CubicFeetPerCubicMeter
    Public Const AcreFt As Single = 43560.0
    Public Const CubicMetersPerAcreFt As Single = AcreFt / CubicFeetPerCubicMeter
    '
    ' SI Discharge support
    '
    Private Const mSiDischargeUnits As DischargeUnits = DischargeUnits.CubicMetersPerSecond
    Public Shared Function SiDischargeUnits() As DischargeUnits
        SiDischargeUnits = mSiDischargeUnits
    End Function

    Public Shared Function SiDischargeUnitsText() As String
        SiDischargeUnitsText = DischargeUnitsAbbreviations(SiDischargeUnits)
    End Function

    Public Shared Function SiDischargeFormatStyle() As String
        SiDischargeFormatStyle = DischargeFormatStyles(SiDischargeUnits)
    End Function

    Public Shared Function SiDischargeValue(ByVal UiValue As Single, ByVal UiUnits As DischargeUnits) As Single
        SiDischargeValue = UiValue

        Select Case (UiUnits)
            Case DischargeUnits.LitersPerSecond
                SiDischargeValue = UiValue / LitersPerCubicMeter
            Case DischargeUnits.CubicFeetPerSecond
                SiDischargeValue = UiValue / CubicFeetPerCubicMeter
            Case DischargeUnits.GallonsPerMinute
                SiDischargeValue = UiValue / SecondsPerMinute / GallonsPerCubicMeter
            Case DischargeUnits.AcreFeetPerHour
                SiDischargeValue = UiValue * CubicMetersPerAcreFt / SecondsPerHour
            Case DischargeUnits.MinersInchesAZ
                SiDischargeValue = UiValue / CubicFeetPerCubicMeter / 40.0!
            Case DischargeUnits.MinersInchesID
                SiDischargeValue = UiValue / CubicFeetPerCubicMeter / 50.0!
            Case DischargeUnits.MinersInchesCO
                SiDischargeValue = UiValue / CubicFeetPerCubicMeter / 38.4!
            Case DischargeUnits.MegalitersPerHour
                SiDischargeValue = UiValue * CubicMetersPerMegaLiter / SecondsPerHour
            Case DischargeUnits.MegalitersPerDay
                SiDischargeValue = UiValue * CubicMetersPerMegaLiter / SecondsPerDay
            Case DischargeUnits.MillionGallonsPerDay
                SiDischargeValue = UiValue * 1000000.0! / SecondsPerDay / GallonsPerCubicMeter
        End Select
    End Function
    '
    ' UI Discharge support
    '
    Public Shared Property UiDischargeUnits() As DischargeUnits = DischargeUnits.CubicMetersPerSecond

    Public Shared Function DischargeUnitsFromText(ByVal UnitsText As String) As DischargeUnits
        DischargeUnitsFromText = DischargeUnits.CubicMetersPerSecond

        If (DischargeUnitsAbbreviations.Contains(UnitsText)) Then
            Dim ldx As Integer = Array.IndexOf(DischargeUnitsAbbreviations, UnitsText)
            DischargeUnitsFromText = DirectCast(ldx, DischargeUnits)
        End If
    End Function

    Public Shared Function ParseDischargeUnits(ByVal Text As String) As DischargeUnits
        ParseDischargeUnits = DischargeUnits.CubicMetersPerSecond

        Dim tokens As String() = Text.Split(" (){}".ToCharArray)
        For Each token As String In tokens
            If (DischargeUnitsAbbreviations.Contains(token)) Then
                ParseDischargeUnits = DischargeUnitsFromText(token)
                Exit For
            End If
        Next token
    End Function

    Public Shared Function UiDischargeUnitsText() As String
        UiDischargeUnitsText = DischargeUnitsAbbreviations(UiDischargeUnits)
    End Function

    Public Shared Function UiDischargeFormatStyle() As String
        UiDischargeFormatStyle = DischargeFormatStyles(UiDischargeUnits)
    End Function

    Public Shared Function UiDischargeValue(ByVal SiValue As Single, ByVal UiUnits As DischargeUnits) As Single
        UiDischargeValue = SiValue ' Assume DischargeUnits.CubicMetersPerSecond

        Select Case (UiUnits)
            Case DischargeUnits.LitersPerSecond
                UiDischargeValue = SiValue * LitersPerCubicMeter
            Case DischargeUnits.CubicFeetPerSecond
                UiDischargeValue = SiValue * CubicFeetPerCubicMeter
            Case DischargeUnits.GallonsPerMinute
                UiDischargeValue = SiValue * SecondsPerMinute * GallonsPerCubicMeter
            Case DischargeUnits.AcreFeetPerHour
                UiDischargeValue = SiValue * SecondsPerHour / CubicMetersPerAcreFt
            Case DischargeUnits.MinersInchesAZ
                UiDischargeValue = SiValue * CubicFeetPerCubicMeter * 40.0!
            Case DischargeUnits.MinersInchesID
                UiDischargeValue = SiValue * CubicFeetPerCubicMeter * 50.0!
            Case DischargeUnits.MinersInchesCO
                UiDischargeValue = SiValue * CubicFeetPerCubicMeter * 38.4!
            Case DischargeUnits.MegalitersPerHour
                UiDischargeValue = SiValue * SecondsPerHour / CubicMetersPerMegaLiter
            Case DischargeUnits.MegalitersPerDay
                UiDischargeValue = SiValue * SecondsPerDay / CubicMetersPerMegaLiter
            Case DischargeUnits.MillionGallonsPerDay
                UiDischargeValue = SiValue * SecondsPerDay * GallonsPerCubicMeter / 1000000.0!
        End Select
    End Function

    Public Shared Function UiDischargeValue(ByVal SiValue As Single) As Single
        UiDischargeValue = UiDischargeValue(SiValue, UiDischargeUnits)
    End Function

#End Region

#Region " Formatting Methods "
    '
    ' SI formatting
    '
    Public Shared Function SiFormatStyle(ByVal SiUnits As String) As String
        SiFormatStyle = "0.0###"
        If (LengthUnitsAbbreviations.Contains(SiUnits)) Then
            SiFormatStyle = SiLengthFormatStyle()
        ElseIf (SlopeUnitsAbbreviations.Contains(SiUnits)) Then
            SiFormatStyle = SiSlopeFormatStyle()
        ElseIf (VelocityUnitsAbbreviations.Contains(SiUnits)) Then
            SiFormatStyle = SiVelocityFormatStyle()
        ElseIf (DischargeUnitsAbbreviations.Contains(SiUnits)) Then
            SiFormatStyle = SiDischargeFormatStyle()
        End If
    End Function

    Public Shared Function SiValue(ByVal UiValue As Single, ByVal UiUnits As String) As Single
        SiValue = UiValue
        If (LengthUnitsAbbreviations.Contains(UiUnits)) Then
            Dim lUnits As UnitsDialog.LengthUnits = UnitsDialog.LengthUnitsFromText(UiUnits)
            SiValue = UnitsDialog.SiLengthValue(UiValue, lUnits)
        ElseIf (VelocityUnitsAbbreviations.Contains(UiUnits)) Then
            Dim vUnits As UnitsDialog.VelocityUnits = UnitsDialog.VelocityUnitsFromText(UiUnits)
            SiValue = UnitsDialog.SiVelocityValue(UiValue, vUnits)
        ElseIf (DischargeUnitsAbbreviations.Contains(UiUnits)) Then
            Dim dUnits As UnitsDialog.DischargeUnits = UnitsDialog.DischargeUnitsFromText(UiUnits)
            SiValue = UnitsDialog.SiDischargeValue(UiValue, dUnits)
        End If
    End Function

    Public Shared Function SiValueText(ByVal SiValue As Single, ByVal SiUnits As String) As String
        Dim style As String = SiFormatStyle(SiUnits)
        SiValueText = Format(SiValue, style)
    End Function

    Public Shared Function SiUnitsText(ByVal SiUnits As String) As String
        SiUnitsText = SiUnits
        If (LengthUnitsAbbreviations.Contains(SiUnits)) Then
            SiUnitsText = SiLengthUnitsText()
        ElseIf (SlopeUnitsAbbreviations.Contains(SiUnits)) Then
            SiUnitsText = SiSlopeUnitsText()
        ElseIf (VelocityUnitsAbbreviations.Contains(SiUnits)) Then
            SiUnitsText = SiVelocityUnitsText()
        ElseIf (DischargeUnitsAbbreviations.Contains(SiUnits)) Then
            SiUnitsText = SiDischargeUnitsText()
        End If
    End Function

    Public Shared Function SiValueUnitsText(ByVal SiValue As Single, ByVal SiUnits As String) As String
        Return SiValueText(SiValue, SiUnits) & " " & SiUnitsText(SiUnits)
    End Function
    '
    ' UI formatting
    '
    Public Shared Function UiFormatStyle(ByVal SiUnits As String) As String
        UiFormatStyle = "0.0###"
        If (LengthUnitsAbbreviations.Contains(SiUnits)) Then
            UiFormatStyle = UiLengthFormatStyle()
        ElseIf (SlopeUnitsAbbreviations.Contains(SiUnits)) Then
            UiFormatStyle = UiSlopeFormatStyle()
        ElseIf (VelocityUnitsAbbreviations.Contains(SiUnits)) Then
            UiFormatStyle = UiVelocityFormatStyle()
        ElseIf (DischargeUnitsAbbreviations.Contains(SiUnits)) Then
            UiFormatStyle = UiDischargeFormatStyle()
        End If
    End Function

    Public Shared Function UiValue(ByVal SiValue As Single, ByVal SiUnits As String) As Single
        UiValue = SiValue
        If (LengthUnitsAbbreviations.Contains(SiUnits)) Then
            UiValue = UiLengthValue(SiValue)
        ElseIf (SlopeUnitsAbbreviations.Contains(SiUnits)) Then
            UiValue = UiSlopeValue(SiValue)
        ElseIf (VelocityUnitsAbbreviations.Contains(SiUnits)) Then
            UiValue = UiVelocityValue(SiValue)
        ElseIf (DischargeUnitsAbbreviations.Contains(SiUnits)) Then
            UiValue = UiDischargeValue(SiValue)
        End If
    End Function

    Public Shared Function UiValueText(ByVal SiValue As Single, ByVal SiUnits As String) As String
        Dim UiUnits As String = UiUnitsText(SiUnits)
        Dim style As String = UiFormatStyle(UiUnits)
        Dim value As Single = UiValue(SiValue, SiUnits)
        UiValueText = Format(value, style)
    End Function

    Public Shared Function UiUnitsText(ByVal SiUnits As String) As String
        UiUnitsText = SiUnits
        If (LengthUnitsAbbreviations.Contains(SiUnits)) Then
            UiUnitsText = UiLengthUnitsText()
        ElseIf (SlopeUnitsAbbreviations.Contains(SiUnits)) Then
            UiUnitsText = UiSlopeUnitsText()
        ElseIf (VelocityUnitsAbbreviations.Contains(SiUnits)) Then
            UiUnitsText = UiVelocityUnitsText()
        ElseIf (DischargeUnitsAbbreviations.Contains(SiUnits)) Then
            UiUnitsText = UiDischargeUnitsText()
        End If
    End Function

    Public Shared Function UiValueUnitsText(ByVal SiValue As Single, ByVal SiUnits As String) As String
        Return UiValueText(SiValue, SiUnits) & " " & UiUnitsText(SiUnits)
    End Function

#End Region

#Region " Methods "

    ' Update radio button selections based on current selected units
    Private Sub UpdateButtons()

        ' Update Length units selection
        Select Case (UiLengthUnits)
            Case LengthUnits.Feet
                Me.FeetButton.Checked = True
            Case LengthUnits.Millimeters
                Me.MillimetersButton.Checked = True
            Case LengthUnits.Inches
                Me.InchesButton.Checked = True
            Case LengthUnits.Centimeters
                Me.CentimetersButton.Checked = True
            Case Else ' assume LengthUnits.Meters
                Me.MetersButton.Checked = True
        End Select

        ' Update Velocity units selection
        Select Case (UiVelocityUnits)
            Case VelocityUnits.FeetPerSecond
                Me.FeetSecondButton.Checked = True
            Case Else ' assume VelocityUnits.MetersPerSecond
                Me.MetersSecondButton.Checked = True
        End Select

        ' Update Discharge units selection
        Select Case (UiDischargeUnits)
            Case DischargeUnits.LitersPerSecond
                Me.LitersSecondButton.Checked = True
            Case DischargeUnits.CubicFeetPerSecond
                Me.CubicFeetSecondButton.Checked = True
            Case DischargeUnits.GallonsPerMinute
                Me.GallonsMinuteButton.Checked = True
            Case DischargeUnits.AcreFeetPerHour
                Me.AcreFeetHourButton.Checked = True
            Case DischargeUnits.MinersInchesAZ
                Me.MinersInchAzButton.Checked = True
            Case DischargeUnits.MinersInchesID
                Me.MinersInchIdButton.Checked = True
            Case DischargeUnits.MinersInchesCO
                Me.MinersInchCoButton.Checked = True
            Case DischargeUnits.MegalitersPerHour
                Me.MegalitersHourButton.Checked = True
            Case DischargeUnits.MegalitersPerDay
                Me.MegalitersDayButton.Checked = True
            Case DischargeUnits.MillionGallonsPerDay
                Me.MillionGallonsDayButton.Checked = True
            Case Else ' assume DischargeUnits.CubicMetersPerSecond
                Me.CubicMetersSecondButton.Checked = True
        End Select
    End Sub

    ' Convert the Flume data values to new units so the UI displayed values remain unchanged
    Private Sub ConvertFlume()

        Dim LConversion As Single = UiLengthValue(1, UiLengthUnits)
        Dim VConversion As Single = UiVelocityValue(1, UiVelocityUnits)
        Dim QConversion As Single = UiDischargeValue(1, UiDischargeUnits)

        ' Update Length & Slope units
        If (Me.MetersButton.Checked) Then
            LConversion /= UiLengthValue(1, LengthUnits.Meters)
        ElseIf (Me.FeetButton.Checked) Then
            LConversion /= UiLengthValue(1, LengthUnits.Feet)
        ElseIf (Me.MillimetersButton.Checked) Then
            LConversion /= UiLengthValue(1, LengthUnits.Millimeters)
        ElseIf (Me.InchesButton.Checked) Then
            LConversion /= UiLengthValue(1, LengthUnits.Inches)
        ElseIf (Me.CentimetersButton.Checked) Then
            LConversion /= UiLengthValue(1, LengthUnits.Centimeters)
        End If

        ' Update Velocity units
        If (Me.MetersSecondButton.Checked) Then
            VConversion /= UiVelocityValue(1, VelocityUnits.MetersPerSecond)
        ElseIf (Me.FeetSecondButton.Checked) Then
            VConversion /= UiVelocityValue(1, VelocityUnits.FeetPerSecond)
        End If

        ' Update Discharge units
        If (Me.CubicMetersSecondButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.CubicMetersPerSecond)
        ElseIf (Me.LitersSecondButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.LitersPerSecond)
        ElseIf (Me.CubicFeetSecondButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.CubicFeetPerSecond)
        ElseIf (Me.GallonsMinuteButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.GallonsPerMinute)
        ElseIf (Me.AcreFeetHourButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.AcreFeetPerHour)
        ElseIf (Me.MinersInchAzButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.MinersInchesAZ)
        ElseIf (Me.MinersInchIdButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.MinersInchesID)
        ElseIf (Me.MinersInchCoButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.MinersInchesCO)
        ElseIf (Me.MegalitersHourButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.MegalitersPerHour)
        ElseIf (Me.MegalitersDayButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.MegalitersPerDay)
        ElseIf (Me.MillionGallonsDayButton.Checked) Then
            QConversion /= UiDischargeValue(1, DischargeUnits.MillionGallonsPerDay)
        End If

        ConvertFlumeValues(Me.Flume, LConversion, VConversion, QConversion)

    End Sub

    ' Update the selected units based on the radio button selections
    Public Sub UpdateUnits()

        ' Update Length & Slope units
        If (Me.MetersButton.Checked) Then
            UiLengthUnits = LengthUnits.Meters
            UiSlopeUnits = SlopeUnits.MetersPerMeter
        ElseIf (Me.FeetButton.Checked) Then
            UiLengthUnits = LengthUnits.Feet
            UiSlopeUnits = SlopeUnits.FeetPerFoot
        ElseIf (Me.MillimetersButton.Checked) Then
            UiLengthUnits = LengthUnits.Millimeters
            UiSlopeUnits = SlopeUnits.MetersPerMeter
        ElseIf (Me.InchesButton.Checked) Then
            UiLengthUnits = LengthUnits.Inches
            UiSlopeUnits = SlopeUnits.FeetPerFoot
        ElseIf (Me.CentimetersButton.Checked) Then
            UiLengthUnits = LengthUnits.Centimeters
            UiSlopeUnits = SlopeUnits.MetersPerMeter
        End If

        ' Update Velocity units
        If (Me.MetersSecondButton.Checked) Then
            UiVelocityUnits = VelocityUnits.MetersPerSecond
        ElseIf (Me.FeetSecondButton.Checked) Then
            UiVelocityUnits = VelocityUnits.FeetPerSecond
        End If

        ' Update Discharge units
        If (Me.CubicMetersSecondButton.Checked) Then
            UiDischargeUnits = DischargeUnits.CubicMetersPerSecond
        ElseIf (Me.LitersSecondButton.Checked) Then
            UiDischargeUnits = DischargeUnits.LitersPerSecond
        ElseIf (Me.CubicFeetSecondButton.Checked) Then
            UiDischargeUnits = DischargeUnits.CubicFeetPerSecond
        ElseIf (Me.GallonsMinuteButton.Checked) Then
            UiDischargeUnits = DischargeUnits.GallonsPerMinute
        ElseIf (Me.AcreFeetHourButton.Checked) Then
            UiDischargeUnits = DischargeUnits.AcreFeetPerHour
        ElseIf (Me.MinersInchAzButton.Checked) Then
            UiDischargeUnits = DischargeUnits.MinersInchesAZ
        ElseIf (Me.MinersInchIdButton.Checked) Then
            UiDischargeUnits = DischargeUnits.MinersInchesID
        ElseIf (Me.MinersInchCoButton.Checked) Then
            UiDischargeUnits = DischargeUnits.MinersInchesCO
        ElseIf (Me.MegalitersHourButton.Checked) Then
            UiDischargeUnits = DischargeUnits.MegalitersPerHour
        ElseIf (Me.MegalitersDayButton.Checked) Then
            UiDischargeUnits = DischargeUnits.MegalitersPerDay
        ElseIf (Me.MillionGallonsDayButton.Checked) Then
            UiDischargeUnits = DischargeUnits.MillionGallonsPerDay
        End If

    End Sub

#End Region

#Region " Event Handlers "

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles OK_Button.Click
        If (mDialogMode = UnitsDialogModes.SetDefaultUnits) Then
            ' Save the new units to the Registry but do not update the current Flume units
            SaveRegistryUnits()
        Else
            ' Update the current Flume units but do not update the Registry
            UpdateUnits()
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Convert_Button_Click(sender As Object, e As EventArgs) _
        Handles Convert_Button.Click
        ConvertFlume()      ' Convert current Flume values so UI values remain unchanged
        UpdateUnits()       ' Update the current flume units
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

End Class
