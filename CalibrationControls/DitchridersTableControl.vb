
'*************************************************************************************************************
' Class DitchridersTableControl - UserControl for displaying the Ditchrider's Table
'
' Note - this control operates in two modes dependant on the value of DialogMode:
'       1) DialogMode - user changes are limited to the Dialog until the user closes the Dialog via the
'                       'Ok' button. At that point, the calling method will apply the changes.
'       2) Application Mode - user changes are applied immediately.
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Imports WinFlume.UnitsDialog    ' Unit conversion support

Public Class DitchridersTableControl

#Region " Member Data "
    '
    ' WinFlume User Interface
    '
    Private WithEvents mWinFlumeForm As WinFlumeForm
    '
    ' Flume data & methods
    '
    Private mFlume As Flume.FlumeType = Nothing
    '
    ' Ditchrider's table
    '
    Private mTable As ctl_DataGridView = Nothing
    Public Function DitchRidersTableGridView() As ctl_DataGridView
        Return mTable
    End Function

    Private Property HdigitsUI As Integer                   ' Number of h1 precision digits

    Private Property RatingResults As RatingResultsType()
    Private Property TableErrors As Boolean()

    Private Qformat As String = "0.000"

#End Region

#Region " Dialog Mode "

    Private Property DialogMode As Boolean              ' Dialog / Application mode switch
    '
    ' Class to hold the local Dialog data while in DialogMode
    '
    Public Class DialogData
        Public RatingHMin As Single
        Public RatingHMax As Single
        Public DitchIncrement As Single
        Public DitchZ As Single
        Public DitchShowSlope As Boolean

        Private mFlume As FlumeType = Nothing

        ' GEt the Ditchrider's data from the Flume object during construction
        Public Sub New(ByVal Flume As FlumeType)
            mFlume = Flume
            If (mFlume IsNot Nothing) Then
                Me.RatingHMin = mFlume.RatingHMin
                Me.RatingHMax = mFlume.RatingHMax
                Me.DitchIncrement = mFlume.DitchIncrement
                Me.DitchZ = mFlume.DitchZ
                Me.DitchShowSlope = mFlume.DitchShowSlope
            End If
        End Sub

        ' Check if any data has changed
        Public Function Changed() As Boolean
            If (mFlume IsNot Nothing) Then
                Changed = True
                Do
                    If (Me.RatingHMin <> mFlume.RatingHMin) Then Exit Do
                    If (Me.RatingHMax <> mFlume.RatingHMax) Then Exit Do
                    If (Me.DitchIncrement <> mFlume.DitchIncrement) Then Exit Do
                    If (Me.DitchZ <> mFlume.DitchZ) Then Exit Do
                    If (Me.DitchShowSlope <> mFlume.DitchShowSlope) Then Exit Do
                    Changed = False
                Loop Until True
            Else
                Changed = False
            End If
        End Function

        ' Save the Ditchrider's data back into the Flume object
        Public Sub Save()
            If (mFlume IsNot Nothing) Then
                mFlume.RatingHMin = Me.RatingHMin
                mFlume.RatingHMax = Me.RatingHMax
                mFlume.DitchIncrement = Me.DitchIncrement
                mFlume.DitchZ = Me.DitchZ
                mFlume.DitchShowSlope = Me.DitchShowSlope
            End If
        End Sub

    End Class

    Public mDialogData As DialogData = Nothing
    Public Function GetDialogData() As DialogData
        Return mDialogData
    End Function

#End Region

#Region " Properties "
    '
    ' Ditchrider's properties
    '
    Private Property HminSI As Single                       ' Flow Depth (h1) min/max
        Get
            If (Me.DialogMode) Then ' get local selection
                HminSI = mDialogData.RatingHMin
            Else ' Application mode; get Flume selection
                HminSI = mFlume.RatingHMin
            End If
        End Get
        Set(value As Single)
            If (Me.DialogMode) Then ' set local selection
                mDialogData.RatingHMin = value
            Else ' Application mode; set Flume selection
                mFlume.RatingHMin = value
            End If
        End Set
    End Property

    Private Property HminUI As Single

    Private Property HmaxSI As Single
        Get
            If (Me.DialogMode) Then ' get local selection
                HmaxSI = mDialogData.RatingHMax
            Else ' Application mode; get Flume selection
                HmaxSI = mFlume.RatingHMax
            End If
        End Get
        Set(value As Single)
            If (Me.DialogMode) Then ' set local selection
                mDialogData.RatingHMax = value
            Else ' Application mode; set Flume selection
                mFlume.RatingHMax = value
            End If
        End Set
    End Property
    Private Property HmaxUI As Single

    Private Property DitchIncrementSI As Single
        Get
            If (Me.DialogMode) Then ' get local selection
                DitchIncrementSI = mDialogData.DitchIncrement
            Else ' Application mode; get Flume selection
                DitchIncrementSI = mFlume.DitchIncrement
            End If

            'Use previous increment value or figure out a reasonable first value
            If (DitchIncrementSI <= 0) Then ' must be given a reasonable value
                Dim HminUI As Single = UiLengthValue(Me.HminSI)
                Dim HmaxUI As Single = UiLengthValue(Me.HmaxSI)
                DitchIncrementSI = (HmaxUI - HminUI) / 200
            End If

            'Normalize to integer orders of magnitude
            If (0 < DitchIncrementSI) Then
                Select Case (UiLengthUnits)
                    Case LengthUnits.Feet, LengthUnits.Inches ' English - units are feet
                        DitchIncrementUI = UiLengthValue(DitchIncrementSI, LengthUnits.Feet)

                        Dim diDbl As Double = Math.Log10(DitchIncrementUI)
                        Dim diInt As Integer = CInt(diDbl)

                        DitchIncrementUI = CSng(10 ^ diInt)

                        DitchIncrementSI = SiLengthValue(DitchIncrementUI, LengthUnits.Feet)

                    Case Else ' Metric - units are meters

                        Dim diDbl As Double = Math.Log10(DitchIncrementSI)
                        Dim diInt As Integer = CInt(diDbl)

                        DitchIncrementSI = CSng(10 ^ diInt)
                End Select
            Else
                DitchIncrementSI = 0
            End If

        End Get
        Set(value As Single)
            If (Me.DialogMode) Then ' set local selection
                mDialogData.DitchIncrement = value
            Else ' Application mode; set Flume selection
                mFlume.DitchIncrement = value
            End If
        End Set
    End Property

    Private Property DitchIncrementUI As Single

    Private Property DitchZ As Single                       ' Gage slope
        Get
            If (Me.DialogMode) Then ' get local selection
                DitchZ = mDialogData.DitchZ
            Else ' Application mode; get Flume selection
                DitchZ = mFlume.DitchZ
            End If
        End Get
        Set(value As Single)
            If (value <= 0) Then
                Dim approachSection As SectionType = mFlume.Section(cApproach)
                Select Case (approachSection.Shape)
                    Case shSimpleTrapezoid, shVShaped
                        value = approachSection.Z1
                    Case shComplexTrapezoid
                        value = approachSection.Z3
                    Case Else
                        value = 0
                End Select
            End If

            If (Me.DialogMode) Then ' set local selection
                mDialogData.DitchZ = value
            Else ' Application mode; set Flume selection
                mFlume.DitchZ = value
            End If
        End Set
    End Property

    Private Property DitchShowSlope As Boolean
        Get
            If (Me.DialogMode) Then ' get local selection
                DitchShowSlope = mDialogData.DitchShowSlope
            Else ' Application mode; get Flume selection
                DitchShowSlope = mFlume.DitchShowSlope
            End If
        End Get
        Set(value As Boolean)
            If (Me.DialogMode) Then ' set local selection
                mDialogData.DitchShowSlope = value
            Else ' Application mode; set Flume selection
                mFlume.DitchShowSlope = value
            End If
        End Set
    End Property

    Public Function Caption(ByVal DitchShowSlope As Boolean) As String
        Caption = My.Resources.Discharges & " (" & UiDischargeUnitsText() & ")"
        Caption &= " " & My.Resources.per & " "
        If (DitchShowSlope) Then
            Caption &= My.Resources.SlopeDistance
        Else
            Caption &= My.Resources.HeadDepth
        End If
        Caption &= " (" & UiLengthUnitsText() & ")"
    End Function

#End Region

#Region " Constructor(s) "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DialogMode = False
        Me.MinimumHeadSingle.UndoEnabled = False
        Me.MaximumHeadSingle.UndoEnabled = False
        Me.ColumnIncrement.UndoEnabled = False
        Me.ShowSlopeDistsCheckBox.UndoEnabled = False
        Me.GageSlopeSingle.UndoEnabled = False

        mTable = New ctl_DataGridView(Me.Font) With {
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
            .AllowUserToDeleteRows = False,
            .AllowUserToAddRows = False,
            .AllowUserToOrderColumns = False,
            .AllowUserToResizeColumns = False,
            .AllowUserToResizeRows = False,
            .ReadOnly = True,
            .RowHeadersVisible = True,
            .RowHeadersWidth = 70,
            .SelectionMode = DataGridViewSelectionMode.CellSelect,
            .AccessibleName = My.Resources.DitchridersTable,
            .AccessibleDescription = My.Resources.CopyableTableOfData
        }

        With mTable
            ' Use 9-point / bold font for header text
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 67
            .ColumnHeadersDefaultCellStyle.Font = New Font(Me.Font.FontFamily, 9, FontStyle.Bold)
        End With

    End Sub

    Public Sub New(ByVal FlumeForm As WinFlumeForm, ByVal DialogMode As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mWinFlumeForm = FlumeForm
        mFlume = WinFlumeForm.Flume
        Me.DialogMode = DialogMode
        Me.MinimumHeadSingle.UndoEnabled = False
        Me.MaximumHeadSingle.UndoEnabled = False
        Me.ColumnIncrement.UndoEnabled = False
        Me.ShowSlopeDistsCheckBox.UndoEnabled = False
        Me.GageSlopeSingle.UndoEnabled = False

        If (Me.DialogMode) Then
            mDialogData = New DialogData(mFlume)
        End If

        mTable = New ctl_DataGridView(Me.Font) With {
            .AllowDrop = False,
            .AllowUserToDeleteRows = False,
            .AllowUserToAddRows = False,
            .AllowUserToOrderColumns = False,
            .AllowUserToResizeColumns = False,
            .AllowUserToResizeRows = False,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
            .ReadOnly = True,
            .RowHeadersVisible = True,
            .RowHeadersWidth = 80,
            .SelectionMode = DataGridViewSelectionMode.CellSelect,
            .AccessibleName = My.Resources.DitchridersTable,
            .AccessibleDescription = My.Resources.CopyableTableOfData
        }
    End Sub

#End Region

#Region " UI Methods "

    '*********************************************************************************************************
    ' Sub UpdateUI() - Update UI to display selected Rating Table Choices
    '*********************************************************************************************************
    Public Sub UpdateUI(ByVal WinFlume As WinFlumeForm)
        mWinFlumeForm = WinFlume
        Me.UpdateUI()
    End Sub

    Private mUpdatingUI As Boolean = False
    Protected Sub UpdateUI()

        mFlume = WinFlumeForm.Flume                                         ' Flume data

        ' Don't update UI until initialization is complete and control is visible
        If ((mFlume Is Nothing) Or (mTable Is Nothing) Or (Not (Me.Visible))) Then
            Return
        End If

        If (mUpdatingUI) Then ' prevent recursive calls
            Return
        End If
        mUpdatingUI = True
        '
        ' Update controls
        '
        Dim choicesControl As TableChoicesControl = mWinFlumeForm.GetTableChoicesControl
        choicesControl.ValidateSmartRange(mFlume)

        UpdateControls()

        Dim loc As Point = Me.ViewAsDialogButton.Location
        loc.X = Me.Width - Me.ViewAsDialogButton.Width - 2
        Me.ViewAsDialogButton.Location = loc
        '
        ' Setup the ditchrider's table
        '
        If Not (Me.DataPanel.Controls.Contains(mTable)) Then
            Me.DataPanel.Controls.Clear()
            Me.DataPanel.Controls.Add(mTable)
        End If
        '
        ' Update ditchrider's table
        '
        UpdateDitchridersTable()

        mUpdatingUI = False
    End Sub

    '*********************************************************************************************************
    ' Sub UpdateControls() - Update the control values on the Ditchrider's Table tab
    '*********************************************************************************************************
    Private Sub UpdateControls()
        '
        ' Get SI values from Flume, generate UI values then update the controls
        '
        HminUI = UiLengthValue(Me.HminSI)
        Me.MinimumHeadSingle.SiUnits = LengthUnitsAbbreviations(LengthUnits.Meters)
        Me.MinimumHeadSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.RatingHMin
        Me.MinimumHeadSingle.SiValue = HminSI
        Me.MinimumHeadSingle.Label = Me.MinimumHeadLabel.Text

        HmaxUI = UiLengthValue(Me.HmaxSI)
        Me.MaximumHeadSingle.SiUnits = LengthUnitsAbbreviations(LengthUnits.Meters)
        Me.MaximumHeadSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.RatingHMax
        Me.MaximumHeadSingle.SiValue = HmaxSI
        Me.MaximumHeadSingle.Label = Me.MaximumHeadLabel.Text

        DitchIncrementUI = UiLengthValue(Me.DitchIncrementSI)
        Me.ColumnIncrement.UnitsText = UiLengthUnitsText()
        Me.ColumnIncrement.Precision = DitchIncrementUI
        Me.ColumnIncrement.Label = Me.ColumnIncrementLabel.Text
        DitchIncrementUI = Me.ColumnIncrement.Precision
        Me.DitchIncrementSI = SiLengthValue(DitchIncrementUI, UiLengthUnits)

        Me.ShowSlopeDistsCheckBox.Value = Me.DitchShowSlope
        Me.Z_Label.Enabled = Me.DitchShowSlope
        Me.GageSlopeSingle.Enabled = Me.DitchShowSlope

        Me.GageSlopeSingle.SiDefaultValue = WinFlumeForm.DefaultFlume.DitchZ
        Me.GageSlopeSingle.SiValue = Me.DitchZ
        Me.GageSlopeSingle.Label = My.Resources.GageSlope

        Me.TableCaption.Text = Caption(Me.DitchShowSlope)

    End Sub

    '*********************************************************************************************************
    ' Sub UpdateDitchridersTable() - update the ditchrider's table
    '*********************************************************************************************************
    Public Sub UpdateDitchridersTable()
        '
        ' Get SI values from Flume & generate UI values
        '
        HminUI = UiLengthValue(Me.HminSI)
        HmaxUI = UiLengthValue(Me.HmaxSI)

        DitchIncrementUI = UiLengthValue(Me.DitchIncrementSI)
        DitchIncrementUI = Me.ColumnIncrement.Precision
        Me.DitchIncrementSI = SiLengthValue(DitchIncrementUI, UiLengthUnits)

        DitchZ = mFlume.DitchZ
        '
        ' Adjust values for RatingTable() calculation
        '
        HdigitsUI = CInt(Math.Log10(1.0 / DitchIncrementUI))      ' Number of digits of precision for Depth/Slope

        Dim precision As Double = 1 / 10 ^ (HdigitsUI + 1)

        ' Min/Max table entries are based on UI units (m | ft)
        Dim tmin As Double = Math.Round(HminUI / DitchIncrementUI, HdigitsUI + 1)
        tmin = Math.Ceiling(tmin - precision)
        tmin = Math.Round(tmin * DitchIncrementUI, HdigitsUI)
        HminUI = CSng(tmin)

        Dim tmax As Double = Math.Round(HmaxUI / DitchIncrementUI, HdigitsUI + 1)
        tmax = Math.Floor(tmax + precision)
        tmax = Math.Round(tmax * DitchIncrementUI, HdigitsUI)
        HmaxUI = CSng(tmax)

        ' Rating table calculations are based on SI units (m)
        HminSI = SiLengthValue(HminUI, UiLengthUnits)
        HmaxSI = SiLengthValue(HmaxUI, UiLengthUnits)

        ReDim RatingResults(1)
        ReDim TableErrors(MaxHydErrors)

        With mTable
            .Rows.Clear()
            .Columns.Clear()
            .ColumnCount = 10

            Dim minColWidth As Integer = CInt((.Width - .RowHeadersWidth) / 10) - 2
            minColWidth = maxint(minColWidth, HdigitsUI * 16)
            minColWidth = maxint(minColWidth, 50)

            ' Define table's columns
            For col As Integer = 0 To 9
                .Columns(col).HeaderText = FixedFormat(col * DitchIncrementUI, HdigitsUI)
                .Columns(col).Width = minColWidth
            Next col
        End With
        '
        ' Update ditchrider's table
        '
        If (0 < DitchIncrementUI) Then
            If (Me.DitchShowSlope) Then
                UpdateSlopeTable()
            Else
                UpdateDepthTable()
            End If
        Else
            Debug.Assert(False)
        End If

    End Sub

    '*********************************************************************************************************
    ' Sub UpdateDepthTable() - update the depth table
    '*********************************************************************************************************
    Private Sub UpdateDepthTable()

        ' Generate the Rating Results table for the user input flow depth values
        mFlume.MakeRating(HQTable, False, HminSI, HmaxSI, DitchIncrementSI, RatingResults, TableErrors)

        Dim Qmin, Qmax As Single
        MinMaxQ(RatingResults, Qmin, Qmax)
        Qmin = UiDischargeValue(Qmin)
        Qmax = UiDischargeValue(Qmax)
        If (Qmax < 10) Then
            Qformat = "0.000"
        ElseIf (Qmax < 100) Then
            Qformat = "0.00"
        ElseIf (Qmax < 1000) Then
            Qformat = "0.0"
        Else
            Qformat = "0"
        End If

        Dim rowMinUI As Single = CSng(Math.Round(HminUI, HdigitsUI + 1))
        rowMinUI = rowMinUI / (DitchIncrementUI * 10)
        rowMinUI = CSng(Math.Floor(Math.Round(rowMinUI, 2)))
        rowMinUI = rowMinUI * DitchIncrementUI * 10
        rowMinUI = CSng(Math.Round(rowMinUI, HdigitsUI))

        Debug.Assert(rowMinUI <= HminUI)

        With mTable

            Dim rowHdr1 As String = My.Resources.Head
            Dim rowHdr2 As String = "h1"
            .ColumnHeadersHeight = 40
            .TopLeftHeaderCell.Value = rowHdr1 & Chr(13) & rowHdr2

            ' Load table values
            Dim rdx As Integer = 0
            Dim tdx As Integer = 1
            Dim ditchRow() As String = {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "}

            Dim rowValUI As Single = rowMinUI
            Dim nxtRowUI As Single = CSng(Math.Round(rowValUI + DitchIncrementUI * 10, HdigitsUI))

            While ((rowValUI <= HmaxUI) And (tdx < RatingResults.Length))
                Dim ditchResults As RatingResultsType = RatingResults(tdx)
                If (ditchResults IsNot Nothing) Then
                    Dim h1SI As Single = ditchResults.SMALLh1
                    Dim h1UI As Single = CSng(Math.Round(UiLengthValue(h1SI), HdigitsUI))
                    Dim QSI As Single = ditchResults.Q
                    Dim QUI As Single = UiDischargeValue(QSI)

                    If ((h1UI < 0) Or (HmaxUI < h1UI)) Then
                        Exit While
                    End If

                    If (nxtRowUI <= h1UI) Then
                        mTable.Rows.Add(ditchRow)
                        mTable.Rows.Item(rdx).HeaderCell.Value = FixedFormat(rowValUI, HdigitsUI - 1)
                        rdx += 1
                        ditchRow = New String() {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "}
                        rowValUI = nxtRowUI
                        nxtRowUI = CSng(Math.Round(rowValUI + DitchIncrementUI * 10, HdigitsUI))
                    End If

                    Dim colValUI As Single = h1UI - rowValUI
                    If (0 <= colValUI) Then
                        Dim cdx As Integer = CInt(Math.Round(colValUI / DitchIncrementUI))
                        If (cdx < ditchRow.Length) Then
                            If (ditchResults.FatalError) Then
                                ditchRow(cdx) = My.Resources.FATAL
                            ElseIf (ditchResults.NonFatalError) Then
                                ditchRow(cdx) = "*" & Format(QUI, Qformat)
                            Else
                                ditchRow(cdx) = Format(QUI, Qformat)
                            End If
                        End If
                    End If
                Else
                    Debug.Assert(False)
                End If

                tdx += 1
            End While

            If Not (ditchRow(0) = " ") Then
                mTable.Rows.Add(ditchRow)
                mTable.Rows.Item(rdx).HeaderCell.Value = rowValUI.ToString
            End If

            ' Update status
            Me.StatusPanel.Title.Text = My.Resources.AllWarningMessagesForThisTable
            Me.StatusPanel.StatusBox.Clear()

            Dim edx As Integer = 0
            Dim errText As String = ""
            For Each errBool In TableErrors
                If (errBool) Then
                    If (edx < 10) Then
                        errText &= " "
                    End If
                    errText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
                End If
                edx += 1
            Next errBool

            Me.StatusPanel.StatusBox.Text = errText

        End With

    End Sub

    '*********************************************************************************************************
    ' Sub UpdateSlopeTable() - update the slope table
    '*********************************************************************************************************
    Private Sub UpdateSlopeTable()

        ' Calculate Slope Distance values based on Flow Depth values
        Dim S0factr As Double = 1 + DitchZ ^ 2
        Dim S0minUI As Single = CSng(Math.Sqrt(S0factr * HminUI ^ 2))
        Dim S0maxUI As Single = CSng(Math.Sqrt(S0factr * HmaxUI ^ 2))

        ' Min/Max table entries are based on UI units (m | ft)
        S0minUI = CSng(Math.Round(S0minUI, HdigitsUI + 1))
        S0minUI = CSng(Math.Round(Math.Ceiling(S0minUI / DitchIncrementUI) * DitchIncrementUI, HdigitsUI))
        S0maxUI = CSng(Math.Round(S0maxUI, HdigitsUI + 1))
        S0maxUI = CSng(Math.Round(Math.Floor(S0maxUI / DitchIncrementUI) * DitchIncrementUI, HdigitsUI))

        ' MakeRating() requires parameters in SI units (m)
        HminUI = CSng(Math.Sqrt(S0minUI ^ 2 / S0factr))
        HmaxUI = CSng(Math.Sqrt(S0maxUI ^ 2 / S0factr))

        HminSI = SiLengthValue(HminUI, UiLengthUnits)
        HmaxSI = SiLengthValue(HmaxUI, UiLengthUnits)

        Dim S0incUI As Single = CSng(Math.Sqrt(DitchIncrementUI ^ 2 / S0factr))
        Dim S0incSI As Single = SiLengthValue(S0incUI, UiLengthUnits)

        ' Generate the Rating Results table for the calculated slope depths values
        mFlume.MakeRating(HQTable, False, HminSI, HmaxSI, S0incSI, RatingResults, TableErrors)

        Dim Qmin, Qmax As Single
        MinMaxQ(RatingResults, Qmin, Qmax)
        Qmin = UiDischargeValue(Qmin)
        Qmax = UiDischargeValue(Qmax)
        If (Qmax < 10) Then
            Qformat = "0.000"
        ElseIf (Qmax < 100) Then
            Qformat = "0.00"
        ElseIf (Qmax < 1000) Then
            Qformat = "0.0"
        Else
            Qformat = "0"
        End If

        Dim rowMinUI As Single = CSng(Math.Round(S0minUI, HdigitsUI + 1))
        rowMinUI = rowMinUI / (DitchIncrementUI * 10)
        rowMinUI = CSng(Math.Floor(Math.Round(rowMinUI, 2)))
        rowMinUI = rowMinUI * DitchIncrementUI * 10
        rowMinUI = CSng(Math.Round(rowMinUI, HdigitsUI))

        Debug.Assert(rowMinUI <= S0minUI)

        With mTable

            Dim Zstr As String = DitchZ.ToString
            Dim rowHdr1 As String = My.Resources.Slope
            Dim rowHdr2 As String = My.Resources.Distance
            Dim rowHdr3 As String = "(" & Zstr & ":1)"
            .ColumnHeadersHeight = 60
            .TopLeftHeaderCell.Value = rowHdr1 & Chr(13) & rowHdr2 & Chr(13) & rowHdr3

            ' Load table values
            Dim rdx As Integer = 0
            Dim tdx As Integer = 1
            Dim ditchRow() As String = {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "}

            Dim rowValUI As Single = rowMinUI
            Dim nxtRowUI As Single = CSng(Math.Round(rowValUI + DitchIncrementUI * 10, HdigitsUI))

            While ((rowValUI <= S0maxUI) And (tdx < RatingResults.Length))
                Dim ditchResults As RatingResultsType = RatingResults(tdx)
                If (ditchResults IsNot Nothing) Then
                    Dim h1SI As Single = ditchResults.SMALLh1
                    Dim S0SI As Single = CSng(Math.Sqrt(S0factr * h1SI ^ 2))
                    Dim S0UI As Single = CSng(Math.Round(UiLengthValue(S0SI), HdigitsUI))
                    Dim QSI As Single = ditchResults.Q
                    Dim QUI As Single = UiDischargeValue(QSI)

                    If (S0maxUI < S0UI) Then
                        Exit While
                    End If

                    If (nxtRowUI <= S0UI) Then
                        mTable.Rows.Add(ditchRow)
                        mTable.Rows.Item(rdx).HeaderCell.Value = FixedFormat(rowValUI, HdigitsUI - 1)
                        rdx += 1
                        ditchRow = New String() {" ", " ", " ", " ", " ", " ", " ", " ", " ", " "}
                        rowValUI = nxtRowUI
                        nxtRowUI = CSng(Math.Round(rowValUI + DitchIncrementUI * 10, HdigitsUI))
                    End If

                    Dim colValUI As Single = S0UI - rowValUI
                    Dim cdx As Integer = CInt(Math.Round(colValUI / DitchIncrementUI))

                    If (ditchResults.FatalError) Then
                        ditchRow(cdx) = My.Resources.FATAL
                    ElseIf (ditchResults.NonFatalError) Then
                        ditchRow(cdx) = "*" & Format(QUI, Qformat)
                    Else
                        ditchRow(cdx) = Format(QUI, Qformat)
                    End If
                Else
                    Debug.Assert(False)
                End If

                tdx += 1
            End While

            If Not (ditchRow(0) = " ") Then
                mTable.Rows.Add(ditchRow)
                mTable.Rows.Item(rdx).HeaderCell.Value = rowValUI.ToString
            End If

            ' Update status
            Me.StatusPanel.Title.Text = My.Resources.AllWarningMessagesForThisTable
            Me.StatusPanel.StatusBox.Clear()

            Dim edx As Integer = 0
            Dim errText As String = ""
            For Each errBool In TableErrors
                If (errBool) Then
                    If (edx < 10) Then
                        errText &= " "
                    End If
                    errText &= edx.ToString & " - " & HydErrorMsg(edx) & vbCrLf
                End If
                edx += 1
            Next errBool

            Me.StatusPanel.StatusBox.Text = errText

        End With

    End Sub

    '*********************************************************************************************************
    ' Sub MinMaxQ() - find the min/max Q values in the RatingResults table
    '
    ' Input(s):     RatingResults   - table of RatingResults from MakeRating()
    '
    ' Output(s):    Qmin            - minimum Q value in table
    '               Qmax            - maximum "   "    "   "
    '*********************************************************************************************************
    Private Sub MinMaxQ(ByVal RatingResults As RatingResultsType(), ByRef Qmin As Single, ByRef Qmax As Single)
        Qmin = Single.MaxValue
        Qmax = Single.MinValue

        If (RatingResults IsNot Nothing) Then
            For Each RatingResult As RatingResultsType In RatingResults
                If (RatingResult IsNot Nothing) Then
                    If (Qmin > RatingResult.Q) Then
                        Qmin = RatingResult.Q
                    End If
                    If (Qmax < RatingResult.Q) Then
                        Qmax = RatingResult.Q
                    End If
                End If
            Next
        End If
    End Sub

    Private Function FixedFormat(ByVal Val As Single, ByVal Digits As Integer) As String
        Select Case Digits
            Case 0
                FixedFormat = Format(Val, "0")
            Case 1
                FixedFormat = Format(Val, "0.0")
            Case 2
                FixedFormat = Format(Val, "0.00")
            Case 3
                FixedFormat = Format(Val, "0.000")
            Case 4
                FixedFormat = Format(Val, "0.0000")
            Case 5
                FixedFormat = Format(Val, "0.00000")
            Case Else
                FixedFormat = Format(Val)
        End Select
    End Function

#End Region

#Region " Event Handlers "

    '*********************************************************************************************************
    ' FlumeDataChanged event handler
    '*********************************************************************************************************
    Private Sub FlumeDataChanged() Handles mWinFlumeForm.FlumeDataChanged
        UpdateUI()
    End Sub

    Private Sub DitchridersTableControl_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.VisibleChanged
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Protected Sub MinimumHeadSingle_ValueChanged() Handles MinimumHeadSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                Me.HminSI = Me.MinimumHeadSingle.SiValue
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Protected Sub MaximumHeadSingle_ValueChanged() Handles MaximumHeadSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                Me.HmaxSI = Me.MaximumHeadSingle.SiValue
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Protected Sub ColumnIncrement_ValueChanged() Handles ColumnIncrement.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                DitchIncrementUI = Me.ColumnIncrement.Precision
                Me.DitchIncrementSI = SiLengthValue(DitchIncrementUI, UiLengthUnits)
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Protected Sub ShowSlopeDistsCheckBox_ValueChanged() Handles ShowSlopeDistsCheckBox.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                Me.DitchShowSlope = Me.ShowSlopeDistsCheckBox.Value
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    Protected Sub GageSlopeSingle_ValueChanged() Handles GageSlopeSingle.ValueChanged
        If ((mWinFlumeForm IsNot Nothing) And (mFlume IsNot Nothing)) Then
            If Not (mUpdatingUI) Then
                Me.DitchZ = Me.GageSlopeSingle.SiValue
                If (Me.DialogMode) Then
                    UpdateUI()
                Else
                    mWinFlumeForm.RaiseFlumeDataChanged()
                End If
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub MyBase_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub MyBase_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Resize
        UpdateUI()
    End Sub

    '*********************************************************************************************************
    ' Sub ViewAsDialogButton_Click() - display table/graph as dialog box
    '*********************************************************************************************************
    Private Sub ViewAsDialogButton_Click(sender As Object, e As EventArgs) _
        Handles ViewAsDialogButton.Click
        mWinFlumeForm.ViewDitchridersTableAsDialog()
    End Sub

#End Region

End Class
