
'*************************************************************************************************************
' Class WinFlumeForm - The main Form for WinFlume
'*************************************************************************************************************
Imports System.IO
Imports System.Windows
Imports System.Threading
Imports System.Globalization
Imports System.Drawing.Printing

Imports Microsoft.Win32     ' For Registry Access

Imports Flume
Imports WinFlume.WinFlumeSectionType

Public Class WinFlumeForm

#Region " Constants & Enumerations "

    'Surface Roughnesses (values are in meters)
    Public Enum SurfaceRoughnesses
        Glass
        MetalSmooth
        MetalRough
        Wood
        ConcreteSmooth
        ConcreteRough
        GelCoatFiberglass
    End Enum

    Public cmRoughness As Single() = {0.000005, 0.00006, 0.0005, 0.0005, 0.00015, 0.0015, (0.00006 + 0.0005) / 2}

    Public Enum StandardCustomChoices
        Standard
        Custom
    End Enum

    ' Gage Descriptions (values are in meters)
    Public Enum GageDescriptions
        PointGage
        DipStick
        StaffFrLow
        StaffInStillFrMed
        StaffInStillFrHigh
        StaffNoStillFrMed
        StaffNoStillFrHigh
        PressureBulb
        BubbleGage
        FloatRecorder
    End Enum

    Public hError As Single() = {0.0001, 0.001, 0.004, 0.005, 0.007, 0.007, 0.015, 0.02, 0.01, 0.005}

    ' Freeboard Limit Types
    Public Enum FreeboardLimitTypes     ' Values match Flume.dll usage
        DistanceLimit = 1
        PercentageLimit = 2
    End Enum

    '*********************************************************************************************************
    ' Table controlling matching the Control Section to the Approach Channel based on:
    '   Technical note:  Matching Approach Section2016-05-16.docx; Author: Bert Clemmens
    '
    ' WinFlumeSectionType is subclassed from Flume.SectionType
    '*********************************************************************************************************
    Public ApproachControlMatchTypes() As WinFlumeSectionType =
        {New WinFlumeSectionType(shSimpleTrapezoid, shSillInTrapezoid, 0,
                                  MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                                + MatchConstraint.OuterShapeMatchesApproachChannel,
                                  MethodOfContraction.RaiseLowerSillHeight),
         New WinFlumeSectionType(shSimpleTrapezoid, shTrapezoidInTrapezoid, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel _
                               + MatchConstraint.InnerSideSlopeMatchesApproach,
                                 MethodOfContraction.RaiseLowerSillHeight _
                               + MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shSimpleTrapezoid, shComplexTrapezoid, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shRectangular, shSillInRectangle, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerSillHeight),
         New WinFlumeSectionType(shRectangular, shVInRectangle, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerInnerSection),
         New WinFlumeSectionType(shRectangular, shTrapezoidInRectangle, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerSillHeight _
                               + MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shRectangular, shRectangleInRectangle, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shVShaped, shSillInVShaped, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerSillHeight),
         New WinFlumeSectionType(shVShaped, shVShapedInVShaped, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerInnerSection),
         New WinFlumeSectionType(shVShaped, shTrapezoidInVShaped, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel _
                               + MatchConstraint.InnerSideSlopeMatchesApproach,
                                 MethodOfContraction.RaiseLowerSillHeight _
                               + MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shCircle, shSillInCircle, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerSillHeight),
         New WinFlumeSectionType(shCircle, shTrapezoidInCircle, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerSillHeight _
                               + MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shUShaped, shSillInUShaped, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerSillHeight),
         New WinFlumeSectionType(shUShaped, shTrapezoidInUShaped, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerSillHeight _
                               + MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shUShaped, shUShapedInUShaped, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shParabola, shSillInParabola, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerSillHeight),
         New WinFlumeSectionType(shParabola, shTrapezoidInParabola, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerSillHeight _
                               + MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shParabola, shParabolaInParabola, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction),
         New WinFlumeSectionType(shComplexTrapezoid, shComplexTrapezoid, 0,
                                 MatchConstraint.InnerSillHeightMatchesProfileSillHeight _
                               + MatchConstraint.OuterShapeMatchesApproachChannel,
                                 MethodOfContraction.RaiseLowerInnerSection _
                               + MethodOfContraction.VarySideContraction)}

    Public CrossSectionShapeNames() As String =
        {SectionString(0), SectionString(1), SectionString(2), SectionString(3), SectionString(4),
         SectionString(5), SectionString(6), SectionString(7), SectionString(8), SectionString(9),
         SectionString(10), SectionString(11), SectionString(12), SectionString(13), SectionString(14),
         SectionString(15), SectionString(16), SectionString(17), SectionString(18), SectionString(19),
         SectionString(20), SectionString(21), SectionString(22), SectionString(23), SectionString(24),
         SectionString(25)}

    ' User interface
    Public Const MaxSideBarWidth As Integer = 500

    ' Windows messages redefined from WinUser.h
    Private Const HTCLIENT As Integer = &H1
    Private Const HTCAPTION As Integer = &H2
    Private Const WM_WINDOWPOSCHANGING As Integer = &H46
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1

    Private Const WM_MOUSEMOVE As Integer = &H200
    Private Const WM_LBUTTONDOWN As Integer = &H201
    Private Const WM_LBUTTONUP As Integer = &H202
    Private Const WM_LBUTTONDBLCLK As Integer = &H203
    Private Const WM_RBUTTONDOWN As Integer = &H204
    Private Const WM_RBUTTONUP As Integer = &H205
    Private Const WM_RBUTTONDBLCLK As Integer = &H206
    Private Const WM_MBUTTONDOWN As Integer = &H207
    Private Const WM_MBUTTONUP As Integer = &H208
    Private Const WM_MBUTTONDBLCLK As Integer = &H209

#End Region

#Region " Member Classes "

    Friend Class UndoRedoItem
        Public ParentName As String
        Public ControlName As String
        Public UndoText As String
        Public UndoValue As Object
        Public Timestamp As DateTime
        Public Sub New(ByVal ParentName As String, ByVal ControlName As String,
                       ByVal UndoText As String, ByVal UndoValue As Object,
                       Optional ByVal Timestamp As DateTime = Nothing)
            Me.ParentName = ParentName
            Me.ControlName = ControlName
            Me.UndoText = UndoText
            Me.UndoValue = UndoValue

            If (Timestamp = Nothing) Then
                Me.Timestamp = DateTime.Now
            Else
                Me.Timestamp = Timestamp
            End If
        End Sub

    End Class

    Friend UndoStack As List(Of UndoRedoItem) = Nothing
    Friend RedoStack As List(Of UndoRedoItem) = Nothing

#End Region

#Region " Member Data "
    '
    ' Units conversion & display
    '
    Private mUnitsDialog As UnitsDialog = Nothing
    Private mLengthUnits As UnitsDialog.LengthUnits = UnitsDialog.LengthUnits.Meters
    '
    ' Undo/Redo
    '
    Private mInUndo As Boolean = False
    Private mInRedo As Boolean = False
    '
    ' Popup What's This? help
    '
    Private mWhatsThisHelp As Boolean = False
    Private mOldCursor As Cursor = Nothing
    Private mHelpPopup As Windows.Forms.RichTextBox = Nothing
    '
    ' Help & Manual
    '
    Private mPdfViewer As PdfViewerDialog = Nothing
    '
    ' Menus
    '
    Private mCopyGraphDataText As String
    Private mSaveGraphDataText As String
    Private mCopyGraphImageText As String
    Private mSaveGraphImageText As String
    Private mCopyTableDataText As String
    Private mPasteTableDataText As String
    Private mSaveTableDataText As String

#End Region

#Region " Properties "
    '
    ' Current file name and path
    '   File name is only the name; no path (may be "" for New Projects)
    '
    Private Const DefaultFileName As String = "WinFlume Design.flm"

    Private mFileName As String = String.Empty
    Public ReadOnly Property FileName() As String
        Get
            Return mFileName
        End Get
    End Property

    Private mFilePath As String = String.Empty
    Public Property FilePath() As String
        Get
            Return mFilePath
        End Get
        Set(ByVal Value As String)
            mFileName = Value.Substring(Value.LastIndexOf("\") + 1)
            mFilePath = Value
        End Set
    End Property
    '
    ' Examples File List
    '
    Private mExamplesFileList As ArrayList = New ArrayList
    Public ReadOnly Property ExamplesFileList() As ArrayList
        Get
            Return mExamplesFileList
        End Get
    End Property
    '
    ' Most Recently Used (MRU) Project List (stored in the Registry)
    '
    Private Const mMaxMruFiles As Integer = 9
    Private Shared mMruProjectList As ArrayList = New ArrayList
    Public Shared ReadOnly Property MruProjectList() As ArrayList
        Get
            Return mMruProjectList
        End Get
    End Property
    '
    ' Fixed width fonts to use by UI
    '
    Protected mFixedFontName As String = "Courier New"
    Protected mFixedFontSize As Single = 11.0!

    Protected mFixedFontWidth As Single = 104.619339!       ' Sizes based on "Courier New", 11.0! string
    Protected mFixedFontHeight As Single = 18.4479122!

    Public ReadOnly Property FixedFont() As Font
        Get
            ' Create un-scaled Font
            FixedFont = New Font(mFixedFontName, mFixedFontSize, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

            ' Determine if scaling might be necessary to accomodate current DPI resolution
            Dim _bitmap As Bitmap = New Bitmap(10, 10)
            Dim _graphics As Graphics = Graphics.FromImage(_bitmap)

            Dim regSize As SizeF = _graphics.MeasureString(mFixedFontName, FixedFont)

            Dim scaledWidth As Single = CSng(Math.Round((mFixedFontWidth * mFixedFontSize / regSize.Width), 3))
            Dim scaledHeight As Single = CSng(Math.Round((mFixedFontHeight * mFixedFontSize / regSize.Height), 3))
            Debug.Assert(scaledWidth = scaledHeight)

            ' Create DPI scaled Font
            FixedFont = New Font(mFixedFontName, scaledWidth, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        End Get
    End Property

    Public ReadOnly Property FixedBold() As Font
        Get
            Dim fixedRegular As Font = Me.FixedFont
            FixedBold = New Font(fixedRegular, FontStyle.Bold)
        End Get
    End Property

    Public ReadOnly Property WinFont As Font
        Get
            Return Me.Font
        End Get
    End Property

    Public ReadOnly Property WinBoldFont As Font
        Get
            WinBoldFont = New Font(Me.Font, FontStyle.Bold)
        End Get
    End Property

    Public Property Message1 As String = ""
    Public Property Message2 As String = ""

#End Region

#Region " User Preferences "

    Public Shared Property Username As String
        Get
            Username = RegistryString(sUsername)

            If (Username = "") Then
                Username = Environment.UserName
            End If
        End Get
        Set(value As String)
            RegistryString(sUsername) = value
        End Set
    End Property

    Public Shared Property RatingParametersToShow() As Integer
        Get
            RatingParametersToShow = RegistryInteger(sRatingParametersToShow)
        End Get
        Set(ByVal value As Integer)
            RegistryInteger(sRatingParametersToShow) = value
        End Set
    End Property

    Public Shared Property MeasuredParametersToShow() As Integer
        Get
            MeasuredParametersToShow = RegistryInteger(sMeasuredParametersToShow)
        End Get
        Set(ByVal value As Integer)
            RegistryInteger(sMeasuredParametersToShow) = value
        End Set
    End Property

    Public Shared Property LocateTabs As Integer
        Get
            LocateTabs = RegistryInteger(sLocateTabs)
        End Get
        Set(value As Integer)
            RegistryInteger(sLocateTabs) = value
        End Set
    End Property

    Public Shared Property LocateSubtabs As Integer
        Get
            LocateSubtabs = RegistryInteger(sLocateSubtabs)
        End Get
        Set(value As Integer)
            RegistryInteger(sLocateSubtabs) = value
        End Set
    End Property

    Public Shared Property RatingGraphItem1() As Integer
        Get
            RatingGraphItem1 = RegistryInteger(sRatingGraphItem1)
        End Get
        Set(ByVal value As Integer)
            RegistryInteger(sRatingGraphItem1) = value
        End Set
    End Property

    Public Shared Property RatingGraphItem2() As Integer
        Get
            RatingGraphItem2 = RegistryInteger(sRatingGraphItem2)
        End Get
        Set(ByVal value As Integer)
            RegistryInteger(sRatingGraphItem2) = value
        End Set
    End Property

    Public Shared Property RatingGraphItem3() As Integer
        Get
            RatingGraphItem3 = RegistryInteger(sRatingGraphItem3)
        End Get
        Set(ByVal value As Integer)
            RegistryInteger(sRatingGraphItem3) = value
        End Set
    End Property

    Public Shared Property HorzViewSize As Integer
        Get
            HorzViewSize = RegistryInteger(sHorzViewSize)
        End Get
        Set(value As Integer)
            RegistryInteger(sHorzViewSize) = value
        End Set
    End Property

    Public Shared Property VertViewSize As Integer
        Get
            VertViewSize = RegistryInteger(sVertViewSize)
        End Get
        Set(value As Integer)
            RegistryInteger(sVertViewSize) = value
        End Set
    End Property

    Public Shared Property SideBarShow As Integer
        Get
            SideBarShow = RegistryInteger(sSideBarShow)
        End Get
        Set(value As Integer)
            RegistryInteger(sSideBarShow) = value
        End Set
    End Property

    Public Shared Property RatingGraphSyncAxes() As Boolean
        Get
            RatingGraphSyncAxes = RegistryBoolean(sRatingGraphSyncAxes)
        End Get
        Set(ByVal value As Boolean)
            RegistryBoolean(sRatingGraphSyncAxes) = value
        End Set
    End Property

    Public Shared Property ShowMaxWSP() As Boolean
        Get
            ShowMaxWSP = RegistryBoolean(sShowMaxWSP)
        End Get
        Set(ByVal value As Boolean)
            RegistryBoolean(sShowMaxWSP) = value
        End Set
    End Property

    Public Shared Property ShowMinWSP() As Boolean
        Get
            ShowMinWSP = RegistryBoolean(sShowMinWSP)
        End Get
        Set(ByVal value As Boolean)
            RegistryBoolean(sShowMinWSP) = value
        End Set
    End Property

#End Region

#Region " Constructor(s) "

    Public Enum WinFlumeLanguages
        enUS
        esMX
        zhCN
    End Enum

    Public Property WinFlumeLanguage() As WinFlumeLanguages = WinFlumeLanguages.enUS

    Public Sub New()

        ' Culture must be set BEFORE call to InitializeComponent()
        Select Case WinFlumeLanguage
            Case WinFlumeLanguages.esMX
                Thread.CurrentThread.CurrentCulture = New CultureInfo("es-MX")
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-MX")
            Case WinFlumeLanguages.zhCN
                Thread.CurrentThread.CurrentCulture = New CultureInfo("zh-CN")
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("zh-CN")
            Case Else ' Assume WinFlumeLanguages.enUS
                'Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
                'Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")
        End Select

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Type all your code here! This code will be executed before the "FormLoad" if you call your new form

        ' Load the Units Dialog; it supports all UI/SI unit conversions
        mUnitsDialog = New UnitsDialog

        ' Load the Examples File List
        LoadExamplesFileList()

        ' Load the Most Recently Used (MRU) file list
        LoadMruProjectList()

        ' Set initial window size
        If (HorzViewSize < 800) Then
            HorzViewSize = 1024
        End If
        If (VertViewSize < 600) Then
            VertViewSize = 768
        End If

        Me.Size = New Size(HorzViewSize, VertViewSize)

        ' Instantiate the default Flume 
        mDefaultFlume = New Flume.FlumeType

        ' Customize toolbar
        Me.WhatsThisButton.Visible = DebuggerIsAttached()

        ' Load starting status messages
        Me.StatusMessage1.Text = My.Resources.UseFileNew
        Me.StatusMessage2.Text = My.Resources.UserFileOpen

    End Sub

#End Region

#Region " Shared Access "
    '
    ' Access to Flume.dll objects & events
    '
    Private Shared mFileFlume As Flume.FlumeType = Nothing      ' Flume data as read from file
    Friend Shared Function FileFlume() As Flume.FlumeType
        Return mFileFlume
    End Function

    Private Shared mFlume As Flume.FlumeType = Nothing          ' Current active Flume data
    Friend Shared Function Flume() As Flume.FlumeType
        Return mFlume
    End Function

    Private Shared mFlumeAPI As FlumeAPI = Nothing
    Friend Shared Function GetFlumeAPI() As FlumeAPI
        Return mFlumeAPI
    End Function

    Friend Shared Function NewFlumeType(ByVal OldFlume As Flume.FlumeType) As Flume.FlumeType
        NewFlumeType = New FlumeType(OldFlume)
        ' Maintain type of Control Section
        If (OldFlume.Section(cControl).GetType Is GetType(WinFlumeSectionType)) Then
            Dim ControlSection As WinFlumeSectionType = DirectCast(OldFlume.Section(cControl), WinFlumeSectionType)
            NewFlumeType.Section(cControl) = New WinFlumeSectionType(ControlSection)
        End If
    End Function

    Friend Shared Sub SetFlume(ByVal NewFlume As Flume.FlumeType)
        If (NewFlume IsNot Nothing) Then
            mFlume = NewFlume
            mFlumeAPI.SetFlume(mFlume)
        End If
    End Sub

    Private Shared mDefaultFlume As Flume.FlumeType = Nothing
    Friend Shared Function DefaultFlume() As Flume.FlumeType
        Return mDefaultFlume
    End Function

    Friend Shared Function ControlMatchedToApproach() As Boolean
        ControlMatchedToApproach = False
        If (mFlume IsNot Nothing) Then
            ControlMatchedToApproach = mFlume.ControlMatchedToApproach
        End If
    End Function

    Friend Shared Function TailwaterMatchedToApproach() As Boolean
        TailwaterMatchedToApproach = False
        If (mFlume IsNot Nothing) Then
            TailwaterMatchedToApproach = mFlume.TailwaterMatchedToApproach
        End If
    End Function

    Friend Shared Function MatchedControlShape() As Integer
        MatchedControlShape = 0
        If (mFlume IsNot Nothing) Then
            MatchedControlShape = mFlume.MatchedControlShape
        End If
    End Function

    Friend Shared Property D1visible As Boolean = False

#End Region

#Region " Friend Methods "

#Region " Identification "

    ' WinFlume's Name & Version
    Public Shared Function WinFlumeName() As String
        Return Application.ProductName
    End Function

    Public Shared Function WinFlumeVersion() As String
        WinFlumeVersion = Application.ProductVersion
    End Function

    ' Environment
    Public Shared Function DebuggerIsAttached() As Boolean
        Return System.Diagnostics.Debugger.IsAttached
    End Function

#End Region

#Region " File I/O "

    Private Function NewFlumeFile() As DialogResult

        Dim newFlume = New NewFlumeDialog

        Dim newResult As DialogResult = newFlume.ShowDialog()
        If (newResult = DialogResult.OK) Then
            If (newFlume.CopyOfFlumeButton.Checked) Then ' start with file values
                Dim openResult As DialogResult = OpenFlumeFile()
                If (openResult = DialogResult.OK) Then
                    Me.FilePath = ""
                    mFlume.Description = My.Resources.CopyOf & " " & mFlume.Description
                    mFileFlume = Nothing            ' no associated file
                    ClearUndoStack()                ' reset the undo/redo stacks
                    ClearRedoStack()
                Else
                    Return DialogResult.Cancel
                End If
            Else ' use default values
                Me.FilePath = ""
                mFlume = New FlumeType              ' instantiate new Flume
                mFlume.Section(cControl).D1 = mFlume.SillHeight

                mUnitsDialog.ReadRegistryUnits()    ' default units from Registry
                mUnitsDialog.UpdateUnits()

                mFileFlume = Nothing                ' no associated file

                ClearUndoStack()                    ' reset the undo/redo stacks
                ClearRedoStack()
            End If

            mFlumeAPI = New FlumeAPI(mFlume)        ' instantiate the Flume API

            ResetTabs()                             ' reset the initial UI tabs

            If (newFlume.UseFlumeWizardCheckBox.Checked) Then
                ShowWizard()
            End If

            Return DialogResult.OK
        End If

        Return DialogResult.Cancel
    End Function

    Private Function OpenFlumeFile() As DialogResult

        ' Create / initialize OpenFileDialog to request a path and file name to open
        Dim openFile As New OpenFileDialog

        If (FileName = String.Empty) Then
            openFile.FileName = DefaultFileName
        Else
            openFile.FileName = FileName
        End If

        openFile.DefaultExt = "*.flm"
        openFile.Filter = Application.ProductName + " Files|*.flm"

        ' Let user choose WinFlume file to open
        Dim result As DialogResult = openFile.ShowDialog()
        If (result = DialogResult.OK) Then
            Dim flumeFile As String = openFile.FileName
            Return OpenFlumeFile(flumeFile)
        End If

        Return DialogResult.Cancel
    End Function

    Private Function OpenFlumeFile(ByVal FlumeFile As String) As DialogResult

        If (FlumeFile IsNot Nothing) Then
            If (0 < FlumeFile.Length) Then

                Me.FilePath = FlumeFile

                Dim oldTypes As Flume.OldTypes = New Flume.OldTypes

                ' Load Flume data from file
                Dim success As Boolean = oldTypes.GetFlumeStruct(mFilePath, mFileFlume)
                If (success) Then
                    Me.LoadUnitsFromFlume(mFileFlume) ' Update Units Dialog with new units

                    mFileFlume.SetUnitFactors(mFileFlume.LUnits, mFileFlume.VUnits, mFileFlume.QUnits)

                    ' Create active Flume data object for application
                    mFlume = New FlumeType(mFileFlume)
                    mFlume.SetUnitFactors(mFlume.LUnits, mFlume.VUnits, mFlume.QUnits)

                    ' Set flag indicating whether or not D1 is visible in Approach / Tailwater cross-sections
                    If ((0 < mFlume.Section(cApproach).D1) Or (0 < mFlume.Section(cTailwater).D1)) Then
                        D1visible = True
                    Else
                        D1visible = False
                    End If

                    ' If required, promote Control's Flume.SectionType to WinFlumeSectionType
                    If (mFlume.ControlMatchedToApproach) Then
                        If (mFlume.MatchedControlShape < shSimpleTrapezoid) Then ' not defined; define it
                            mFlume.MatchedControlShape = mFlume.Section(cControl).Shape
                        End If

                        ' Ensure newest matched shape is selected
                        Select Case (mFlume.MatchedControlShape)
                            Case shSimpleTrapezoid
                                mFlume.MatchedControlShape = shTrapezoidInTrapezoid
                            Case shRectangular
                                mFlume.MatchedControlShape = shRectangleInRectangle
                            Case shVShaped
                                mFlume.MatchedControlShape = shVShapedInVShaped
                            Case shCircle
                                mFlume.MatchedControlShape = shCircleInCircle
                            Case shUShaped
                                mFlume.MatchedControlShape = shUShapedInUShaped
                            Case shParabola
                                mFlume.MatchedControlShape = shParabolaInParabola
                        End Select

                        Dim winflumeSection = New WinFlumeSectionType(mFlume.Section(cControl))
                        LoadWinFlumeSectionType(winflumeSection,
                                                mFlume.Section(cApproach).Shape,
                                                mFlume.MatchedControlShape,
                                                mFlume.Section(cTailwater).Shape)

                        winflumeSection.Shape = mFlume.MatchedControlShape
                        winflumeSection.D1 = mFlume.SillHeight

                        mFlume.Section(cControl) = winflumeSection
                    End If

                    mFlumeAPI = New FlumeAPI(mFlume)    ' instantiate the Flume API

                    ResetTabs()                         ' reset the initial UI tabs

                    Me.ClearUndoStack()                 ' reset the undo/redo stacks
                    Me.ClearRedoStack()

                    ' Add this file to the Most Recently Used (MRU) file list
                    AddFileToMruProjectList(FilePath)

                    Return DialogResult.OK
                Else
                    mFileFlume = Nothing
                    mFlume = Nothing
                End If

            End If
        End If

        Return DialogResult.Cancel
    End Function

    Friend Sub CloseFlumeFile()
        Me.FilePath = ""
        mFileFlume = Nothing
        mFlume = Nothing
        ClearUndoStack()        ' reset the undo/redo stacks
        ClearRedoStack()
    End Sub

    Friend Sub SaveFlumeFile(ByVal FilePath As String, Optional ByVal FileVersion As Short = 9)

        If (FilePath.Trim = "") Then
            SaveAsFlumeFile(FileVersion)
        Else
            Try
                Dim oldTypes As Flume.OldTypes = New Flume.OldTypes
                Dim success As Boolean = oldTypes.PutFlumeStruct(FilePath, mFlume, FileVersion)
                If (success) Then
                    Me.FilePath = FilePath
                    mFileFlume = NewFlumeType(mFlume)

                    ClearUndoStack()        ' reset the undo/redo stacks
                    ClearRedoStack()

                    ' Add this file to the Most Recently Used (MRU) file list
                    AddFileToMruProjectList(FilePath)
                End If

            Catch ex As Exception
                MsgBox(FilePath, MsgBoxStyle.OkOnly, My.Resources.SaveError & " - " & My.Resources.FileCannotBeWritten)
            Finally
                UpdateToolbar()
            End Try
        End If

    End Sub

    Friend Sub SaveAsFlumeFile(Optional ByVal FileVersion As Short = 9)

        ' Create a SaveFileDialog to request a path and file name to save to
        Dim saveFile As New SaveFileDialog

        ' Initialize the SaveFileDialog to specify WinFlume extensions
        If (FileName = String.Empty) Then
            saveFile.FileName = DefaultFileName
        Else
            saveFile.FileName = Me.FilePath
        End If

        saveFile.DefaultExt = "*.flm"
        saveFile.Filter = Application.ProductName + " Files|*.flm"

        ' Determine if user selected a file name from the SaveFileDialog
        If ((saveFile.ShowDialog() = DialogResult.OK) _
        And (saveFile.FileName.Length) > 0) Then

            Dim filePath As String = saveFile.FileName

            Try
                ' Can't save to ReadOnly files
                If Not (Dir(filePath) = String.Empty) Then
                    ' File exists
                    If ((GetAttr(filePath) And vbReadOnly) = vbReadOnly) Then
                        ' File exists and is ReadOnly; it can't be written to
                        MsgBox(filePath, MsgBoxStyle.OkOnly, My.Resources.SaveError & " - " & My.Resources.FileIsReadonly)
                        Return
                    End If
                End If

                Me.SaveFlumeFile(filePath, FileVersion)

                Me.Text = WinFlumeName() & " " & WinFlumeVersion() & " - " & Me.FilePath

            Catch ex As Exception
                ' File exists but can't be written to
                MsgBox(filePath, MsgBoxStyle.OkOnly, My.Resources.SaveError & " - " & My.Resources.FileCannotBeWritten)
            Finally
                UpdateToolbar()
            End Try

        End If

    End Sub
    '
    ' Verify the file contains up to date data
    '
    Friend Function VerifySaved() As Boolean

        Dim fileNew As Boolean = False
        Dim fileOpen As Boolean = False
        Dim flumeChanged As Boolean = False

        If ((mFlume IsNot Nothing) And (mFileFlume Is Nothing)) Then
            fileNew = True
            flumeChanged = True
        End If

        If ((mFlume IsNot Nothing) And (mFileFlume IsNot Nothing)) Then
            fileOpen = True
            flumeChanged = FlumeType.ChangedFlume(mFlume, mFileFlume)
        End If

        ' If the data has changed, ask if it should be saved
        If (flumeChanged) Then

            ' Ask user if they want to save the currently unsaved data
            ' Confirm delete
            Dim msg As String = My.Resources.SaveChanges
            Dim title As String = My.Resources.SaveConfirmation
            Dim style As MsgBoxStyle = MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel

            ' Display message box
            Dim result As MsgBoxResult = MsgBox(msg, style, title)

            If (result = MsgBoxResult.Yes) Then ' user wants to save changes
                If (FileName = String.Empty) Then ' no current file name, prompt for one
                    SaveAsFlumeFile()
                Else ' have current file name, use it
                    SaveFlumeFile(Me.FilePath)
                End If

            ElseIf (result = MsgBoxResult.No) Then ' user does not want to save changes
                Return True
            Else ' must be MsgBoxResult.Cancel
                Return False
            End If
        End If

        Return True

    End Function

    Public Sub ResetTabs()
        Me.WinFlumeTabControl.SelectedIndex = 0
        Me.DefineCanalControl.DefineCanalTabControl.SelectedIndex = 0
        Me.DefineControlControl.DefineControlTabControl.SelectedIndex = 0
        Me.DesignControl.DesignControlTabControl.SelectedIndex = 0
        Me.CalibrationControl.CalibrationControlTabControl.SelectedIndex = 0
        Me.DataComparisonControl.DataComparisonControlTabControl.SelectedIndex = 0
        'Me.WallGageControl.WallGageControlTabControl.SelectedIndex = 0
        Me.DrawingsReportsControl.DrawingsReportsControlTabControl.SelectedIndex = 0
    End Sub

#End Region

#Region " Units "
    '
    ' Synchronize with Flume.dll
    '
    Friend Sub LoadUnitsFromFlume(ByVal Flume As FlumeType)

        If (Flume Is Nothing) Then ' can't update without reference to Flume data
            Return
        End If

        Select Case (Flume.LUnits)
            Case cFeet
                UnitsDialog.UiLengthUnits = UnitsDialog.LengthUnits.Feet
            Case cMM
                UnitsDialog.UiLengthUnits = UnitsDialog.LengthUnits.Millimeters
            Case cInches
                UnitsDialog.UiLengthUnits = UnitsDialog.LengthUnits.Inches
            Case cCM
                UnitsDialog.UiLengthUnits = UnitsDialog.LengthUnits.Centimeters
            Case Else ' assume cMeters
                UnitsDialog.UiLengthUnits = UnitsDialog.LengthUnits.Meters
        End Select
        mLengthUnits = UnitsDialog.UiLengthUnits
        Select Case (Flume.VUnits)
            Case cFPS
                UnitsDialog.UiVelocityUnits = UnitsDialog.VelocityUnits.FeetPerSecond
            Case Else ' assume cMPS
                UnitsDialog.UiVelocityUnits = UnitsDialog.VelocityUnits.MetersPerSecond
        End Select

        Select Case (Flume.QUnits)
            Case cLPS
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.LitersPerSecond
            Case cCFS
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.CubicFeetPerSecond
            Case cGPM
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.GallonsPerMinute
            Case cACFTHR
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.AcreFeetPerHour
            Case cMI40
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MinersInchesAZ
            Case cMI50
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MinersInchesID
            Case cMIColo
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MinersInchesCO
            Case cDAM3HR
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MegalitersPerHour
            Case cMGD
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MillionGallonsPerDay
            Case cMLday
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MegalitersPerDay
            Case Else ' assume cCMS
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.CubicMetersPerSecond
        End Select

    End Sub

    Friend Sub LoadFlumeWithUnits(ByVal Flume As FlumeType)

        If (Flume Is Nothing) Then ' can't update without reference to Flume data
            Return
        End If

        Select Case (UnitsDialog.UiLengthUnits)
            Case UnitsDialog.LengthUnits.Feet
                Flume.LUnits = cFeet
            Case UnitsDialog.LengthUnits.Millimeters
                Flume.LUnits = cMM
            Case UnitsDialog.LengthUnits.Inches
                Flume.LUnits = cInches
            Case Else ' assume UnitsDialog.LengthUnits.Centimeters
                Flume.LUnits = cCM
        End Select
        If Not (mLengthUnits = UnitsDialog.UiLengthUnits) Then
            mLengthUnits = UnitsDialog.UiLengthUnits
            Select Case (CInt(mLengthUnits)) ' set values in SI length units (meters)
                Case cFeet
                    Flume.DesignIncrementValue = 0.1 * 0.3048        ' 1/10 foot
                Case cMM
                    Flume.DesignIncrementValue = 0.001               ' 1 mm
                Case cInches
                    Flume.DesignIncrementValue = 0.25 * 0.3048 / 12  ' 1/4 inch
                Case Else ' assume centimeters
                    Flume.DesignIncrementValue = 0.01                ' 1 cm
            End Select
            Flume.DesignIncrementUnitsIndex = Flume.LUnits
            RaiseLengthUnitsChanged()
        End If

        Select Case (UnitsDialog.UiVelocityUnits)
            Case UnitsDialog.VelocityUnits.FeetPerSecond
                Flume.VUnits = cFPS
            Case Else ' assume UnitsDialog.VelocityUnits.MetersPerSecond
                Flume.VUnits = cMPS
        End Select

        Select Case (UnitsDialog.UiDischargeUnits)
            Case UnitsDialog.DischargeUnits.LitersPerSecond
                Flume.QUnits = cLPS
            Case UnitsDialog.DischargeUnits.CubicFeetPerSecond
                Flume.QUnits = cCFS
            Case UnitsDialog.DischargeUnits.GallonsPerMinute
                Flume.QUnits = cGPM
            Case UnitsDialog.DischargeUnits.AcreFeetPerHour
                Flume.QUnits = cACFTHR
            Case UnitsDialog.DischargeUnits.MinersInchesAZ
                Flume.QUnits = cMI40
            Case UnitsDialog.DischargeUnits.MinersInchesID
                Flume.QUnits = cMI50
            Case UnitsDialog.DischargeUnits.MinersInchesCO
                Flume.QUnits = cMIColo
            Case UnitsDialog.DischargeUnits.MegalitersPerHour
                Flume.QUnits = cDAM3HR
            Case UnitsDialog.DischargeUnits.MillionGallonsPerDay
                Flume.QUnits = cMGD
            Case UnitsDialog.DischargeUnits.MegalitersPerDay
                Flume.QUnits = cMLday
            Case Else ' assume UnitsDialog.DischargeUnits.CubicMetersPerSecond
                Flume.QUnits = cCMS
        End Select

        Select Case (Flume.QUnits)
            Case cLPS
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.LitersPerSecond
            Case cCFS
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.CubicFeetPerSecond
            Case cGPM
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.GallonsPerMinute
            Case cACFTHR
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.AcreFeetPerHour
            Case cMI40
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MinersInchesAZ
            Case cMI50
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MinersInchesID
            Case cMIColo
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MinersInchesCO
            Case cDAM3HR
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MegalitersPerHour
            Case cMGD
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MillionGallonsPerDay
            Case cMLday
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.MegalitersPerDay
            Case Else ' assume cCMS
                UnitsDialog.UiDischargeUnits = UnitsDialog.DischargeUnits.CubicMetersPerSecond
        End Select

        Flume.SetUnitFactors(Flume.LUnits, Flume.VUnits, Flume.QUnits)

    End Sub
    '
    ' Length & Depth Units
    '
    Friend Shared Function SiLengthUnits() As UnitsDialog.LengthUnits
        SiLengthUnits = UnitsDialog.LengthUnits.Meters
    End Function

    Friend Shared Function SiLengthUnitsText() As String
        SiLengthUnitsText = UnitsDialog.LengthUnitsAbbreviations(SiLengthUnits)
    End Function

    Friend Shared Function UiLengthUnits() As UnitsDialog.LengthUnits
        UiLengthUnits = UnitsDialog.UiLengthUnits
    End Function

    Friend Shared Function UiLengthUnitsText() As String
        UiLengthUnitsText = UnitsDialog.UiLengthUnitsText
    End Function
    '
    ' Slope Units
    '
    Friend Shared Function SiSlopeUnits() As UnitsDialog.SlopeUnits
        SiSlopeUnits = UnitsDialog.SlopeUnits.MetersPerMeter
    End Function

    Friend Shared Function SiSlopeUnitsText() As String
        SiSlopeUnitsText = UnitsDialog.SlopeUnitsAbbreviations(SiSlopeUnits)
    End Function

    Friend Shared Function UiSlopeUnits() As UnitsDialog.SlopeUnits
        UiSlopeUnits = UnitsDialog.UiSlopeUnits
    End Function

    Friend Shared Function UiSlopeUnitsText() As String
        UiSlopeUnitsText = UnitsDialog.UiSlopeUnitsText
    End Function
    '
    ' Velocity Units
    '
    Friend Shared Function SiVelocityUnits() As UnitsDialog.VelocityUnits
        SiVelocityUnits = UnitsDialog.VelocityUnits.MetersPerSecond
    End Function

    Friend Shared Function SiVelocityUnitsText() As String
        SiVelocityUnitsText = UnitsDialog.VelocityUnitsAbbreviations(SiVelocityUnits)
    End Function

    Friend Shared Function UiVelocityUnits() As UnitsDialog.VelocityUnits
        UiVelocityUnits = UnitsDialog.UiVelocityUnits
    End Function

    Friend Shared Function UiVelocityUnitsText() As String
        UiVelocityUnitsText = UnitsDialog.UiVelocityUnitsText()
    End Function
    '
    ' Discharge (flow rate) units
    '
    Friend Shared Function SiDischargeUnits() As UnitsDialog.DischargeUnits
        SiDischargeUnits = UnitsDialog.DischargeUnits.CubicMetersPerSecond
    End Function

    Friend Shared Function SiDischargeUnitsText() As String
        SiDischargeUnitsText = UnitsDialog.DischargeUnitsAbbreviations(SiDischargeUnits)
    End Function

    Friend Shared Function UiDischargeUnits() As UnitsDialog.DischargeUnits
        UiDischargeUnits = UnitsDialog.UiDischargeUnits()
    End Function

    Friend Shared Function UiDischargeUnitsText() As String
        UiDischargeUnitsText = UnitsDialog.UiDischargeUnitsText()
    End Function

#End Region

#Region " Undo / Redo "
    '
    ' Undo
    '
    Friend Sub ClearUndoStack()
        If (UndoStack IsNot Nothing) Then
            UndoStack.Clear()
            UndoStack = Nothing
        End If
    End Sub

    Friend Sub AddUndoItem(ByVal UndoItem As UndoRedoItem)
        If (UndoStack Is Nothing) Then
            UndoStack = New List(Of UndoRedoItem)
        End If
        UndoStack.Insert(0, UndoItem)
    End Sub

    Friend Sub AddUndoItem(ByVal ParentName As String, ByVal ControlName As String,
                           ByVal UndoText As String, ByVal UndoValue As Object)
        If (UndoStack Is Nothing) Then
            UndoStack = New List(Of UndoRedoItem)
        End If
        Dim undoItem As UndoRedoItem = New UndoRedoItem(ParentName, ControlName, UndoText, UndoValue)
        UndoStack.Insert(0, undoItem)
    End Sub

    Friend Sub RemoveLastUndoItem()
        If (UndoStack IsNot Nothing) Then
            UndoStack.RemoveAt(0)
        End If
    End Sub

    Friend Sub Undo()
        mInUndo = True

        If (UndoStack IsNot Nothing) Then
            If (0 < UndoStack.Count) Then
                Dim undoItem As UndoRedoItem = UndoStack.Item(0)
                UndoStack.RemoveAt(0)
                If (undoItem IsNot Nothing) Then ' Perform Undo operation

                    ' Start by checking WinFlumeForm operation (e.g. menu items)
                    If (undoItem.ParentName = Me.Name) Then
                        If (undoItem.ControlName = GetRatingTableControl().Name) Then
                            Me.UndoRatingTableDialog(undoItem)
                            mInUndo = False
                            Return
                        ElseIf (undoItem.ControlName = GetRatingEquationControl().Name) Then
                            Me.UndoRatingEquationDialog(undoItem)
                            mInUndo = False
                            Return
                        ElseIf (undoItem.ControlName = GetDitchridersTableControl().Name) Then
                            Me.UndoDitchridersTableDialog(undoItem)
                            mInUndo = False
                            Return
                        ElseIf (undoItem.ControlName = GetAlternativeDesignsControl().Name) Then
                            Me.UndoAlternativeDesignsDialog(undoItem)
                            mInUndo = False
                            Return
                        End If
                    End If

                    ' Then check for matching Control
                    Dim undoCtrl As Control = FindControl(Me, undoItem.ParentName, undoItem.ControlName)
                    If (undoCtrl IsNot Nothing) Then
                        If (undoCtrl.GetType Is GetType(ctl_Button)) Then
                            Dim buttonCtrl As ctl_Button = DirectCast(undoCtrl, ctl_Button)
                            buttonCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_CheckBox)) Then
                            Dim checkCtrl As ctl_CheckBox = DirectCast(undoCtrl, ctl_CheckBox)
                            checkCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_ComboBox)) Then
                            Dim comboCtrl As ctl_ComboBox = DirectCast(undoCtrl, ctl_ComboBox)
                            comboCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_RadioButton)) Then
                            Dim radioCtrl As ctl_RadioButton = DirectCast(undoCtrl, ctl_RadioButton)
                            radioCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_Single)) Then
                            Dim singleCtrl As ctl_Single = DirectCast(undoCtrl, ctl_Single)
                            singleCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_SingleUnits)) Then
                            Dim singleCtrl As ctl_SingleUnits = DirectCast(undoCtrl, ctl_SingleUnits)
                            singleCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_Single6Units)) Then
                            Dim single6Ctrl As ctl_Single6Units = DirectCast(undoCtrl, ctl_Single6Units)
                            single6Ctrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_TabControl)) Then
                            Dim tabCtrl As ctl_TabControl = DirectCast(undoCtrl, ctl_TabControl)
                            tabCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_TextBox)) Then
                            Dim textCtrl As ctl_TextBox = DirectCast(undoCtrl, ctl_TextBox)
                            textCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_Precision)) Then
                            Dim precCtrl As ctl_Precision = DirectCast(undoCtrl, ctl_Precision)
                            precCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_DataGridView)) Then
                            Dim gridCtrl As ctl_DataGridView = DirectCast(undoCtrl, ctl_DataGridView)
                            gridCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        ElseIf (undoCtrl.GetType Is GetType(ctl_SingleUpDown)) Then
                            Dim gridCtrl As ctl_SingleUpDown = DirectCast(undoCtrl, ctl_SingleUpDown)
                            gridCtrl.Undo(undoItem.ParentName, undoItem.ControlName, undoItem.UndoValue)
                        Else
                            Debug.Assert(False, "Undo support for type needs to be added")
                        End If
                    Else
                        Debug.Assert(False, "Undo Control not found")
                    End If
                Else
                    Debug.Assert(False, "Undo Item is Nothing")
                End If
            End If ' Undo Stack is empty
        End If ' Undo Stack is Nothing

        mInUndo = False
    End Sub

    Friend Function InUndo() As Boolean
        Return mInUndo
    End Function
    '
    ' Redo
    '
    Friend Sub ClearRedoStack()
        If (RedoStack IsNot Nothing) Then
            RedoStack.Clear()
            RedoStack = Nothing
        End If
    End Sub

    Friend Sub AddRedoItem(ByVal RedoItem As UndoRedoItem)
        If (RedoStack Is Nothing) Then
            RedoStack = New List(Of UndoRedoItem)
        End If
        RedoStack.Insert(0, RedoItem)
    End Sub

    Friend Sub AddRedoItem(ByVal ParentName As String, ByVal ControlName As String,
                           ByVal RedoText As String, ByVal RedoValue As Object)
        If (RedoStack Is Nothing) Then
            RedoStack = New List(Of UndoRedoItem)
        End If
        Dim redoItem As UndoRedoItem = New UndoRedoItem(ParentName, ControlName, RedoText, RedoValue)
        RedoStack.Insert(0, redoItem)
    End Sub

    Friend Sub Redo()
        mInRedo = True

        If (RedoStack IsNot Nothing) Then
            If (0 < RedoStack.Count) Then
                Dim redoItem As UndoRedoItem = RedoStack.Item(0)
                RedoStack.RemoveAt(0)
                If (redoItem IsNot Nothing) Then ' Perform Redo operation

                    ' Start by checking WinFlumeForm operation (e.g. menu items)
                    If (redoItem.ParentName = Me.Name) Then
                        If (redoItem.ControlName = GetRatingTableControl().Name) Then
                            Me.RedoRatingTableDialog(redoItem)
                            mInRedo = False
                            Return
                        ElseIf (redoItem.ControlName = GetRatingEquationControl().Name) Then
                            Me.RedoRatingEquationDialog(redoItem)
                            mInRedo = False
                            Return
                        ElseIf (redoItem.ControlName = GetDitchridersTableControl().Name) Then
                            Me.RedoDitchridersTableDialog(redoItem)
                            mInRedo = False
                            Return
                        ElseIf (redoItem.ControlName = GetAlternativeDesignsControl().Name) Then
                            Me.RedoAlternativeDesignsDialog(redoItem)
                            mInRedo = False
                            Return
                        End If
                    End If

                    ' Then check for matching Control
                    Dim redoCtrl As Control = FindControl(Me, redoItem.ParentName, redoItem.ControlName)
                    If (redoCtrl IsNot Nothing) Then
                        If (redoCtrl.GetType Is GetType(ctl_Button)) Then
                            Dim buttonCtrl As ctl_Button = DirectCast(redoCtrl, ctl_Button)
                            buttonCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_CheckBox)) Then
                            Dim checkCtrl As ctl_CheckBox = DirectCast(redoCtrl, ctl_CheckBox)
                            checkCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_ComboBox)) Then
                            Dim comboCtrl As ctl_ComboBox = DirectCast(redoCtrl, ctl_ComboBox)
                            comboCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_RadioButton)) Then
                            Dim radioCtrl As ctl_RadioButton = DirectCast(redoCtrl, ctl_RadioButton)
                            radioCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_Single)) Then
                            Dim singleCtrl As ctl_Single = DirectCast(redoCtrl, ctl_Single)
                            singleCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_SingleUnits)) Then
                            Dim singleCtrl As ctl_SingleUnits = DirectCast(redoCtrl, ctl_SingleUnits)
                            singleCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_Single6Units)) Then
                            Dim single6Ctrl As ctl_Single6Units = DirectCast(redoCtrl, ctl_Single6Units)
                            single6Ctrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_TabControl)) Then
                            Dim tabCtrl As ctl_TabControl = DirectCast(redoCtrl, ctl_TabControl)
                            tabCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_TextBox)) Then
                            Dim textCtrl As ctl_TextBox = DirectCast(redoCtrl, ctl_TextBox)
                            textCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_Precision)) Then
                            Dim precCtrl As ctl_Precision = DirectCast(redoCtrl, ctl_Precision)
                            precCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_DataGridView)) Then
                            Dim gridCtrl As ctl_DataGridView = DirectCast(redoCtrl, ctl_DataGridView)
                            gridCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        ElseIf (redoCtrl.GetType Is GetType(ctl_SingleUpDown)) Then
                            Dim gridCtrl As ctl_SingleUpDown = DirectCast(redoCtrl, ctl_SingleUpDown)
                            gridCtrl.Redo(redoItem.ParentName, redoItem.ControlName, redoItem.UndoValue)
                        Else
                            Debug.Assert(False, "Redo support for type needs to be added")
                        End If
                    Else
                        Debug.Assert(False, "Redo Control not found")
                    End If
                Else
                    Debug.Assert(False, "Redo Item is Nothing")
                End If
            End If ' Redo Stack is empty
        End If ' Redo Stack is Nothing

        mInRedo = False
    End Sub

    Friend Function InRedo() As Boolean
        Return mInRedo
    End Function

#End Region

#Region " What's This Help "

    Friend Sub StartWhatsThisHelp(ByVal _form As System.Windows.Forms.Form)
        ' Capture mouse events; see override of WndProc()
        _form.Capture = True
        ' Save current cursor then display help cursor (arrow & question mark)
        mOldCursor = _form.Cursor
        _form.Cursor = Cursors.Help
    End Sub

    Friend Sub PauseWhatsThisHelp(ByVal _form As System.Windows.Forms.Form)
        ' Restore old cursor
        _form.Cursor = mOldCursor
    End Sub

    Friend Sub StopWhatsThisHelp(ByVal _form As System.Windows.Forms.Form)
        ' Release mouse events
        _form.Capture = False
        ' Restore old cursor
        _form.Cursor = mOldCursor
    End Sub

    Friend Function WhatsThisHelp(ByRef m As Message, ByVal _form As System.Windows.Forms.Form) As Boolean
        '
        ' Form must be 'Active' for What's This Help
        '
        If Not (Form.ActiveForm Is _form) Then
            Return False
        End If

        If (mHelpPopup Is Nothing) Then
            '
            ' Display What's This Help for this control
            '
            Dim _mouseScreen As Point = _form.PointToScreen(New Point(m.LParam.ToInt32))
            Dim _mouseClient As Point = _form.PointToClient(_mouseScreen)

            Dim _parent As Control = _form
            Dim _ctrl As Control = _form.GetChildAtPoint(_mouseClient)

            Dim _title As String = Me.AccessibleName
            Dim _desc As String = Me.AccessibleDescription

            If Not (_form.AccessibleName Is Nothing) Then
                If Not (_form.AccessibleName = String.Empty) Then
                    _title = _form.AccessibleName
                    _desc = _form.AccessibleDescription
                End If
            End If
            '
            ' Scan all controls under the mouse for the most specific help text
            '
            Do While Not (_ctrl Is Nothing)
                '
                ' If the control is hidden; find the visible one at this point
                '
                If Not (_ctrl.Visible) Then

                    ' Scan the parent's control list
                    For _idx As Integer = 0 To _parent.Controls.Count - 1
                        _ctrl = _parent.Controls(_idx)
                        If (_ctrl.Visible) Then
                            ' Control is visible; is it under the mouse?
                            _mouseClient = _ctrl.PointToClient(_mouseScreen)
                            If (_ctrl.ClientRectangle.Contains(_mouseClient)) Then
                                ' Control is under the mouse; this is it!
                                Exit For
                            End If
                        End If
                    Next _idx

                End If
                '
                ' If this control has an Accessible Name & Description; get them
                '
                If (_ctrl.Visible) Then
                    If Not (_ctrl.AccessibleName Is Nothing) Then
                        If Not (_ctrl.AccessibleName = String.Empty) Then
                            _title = _ctrl.AccessibleName
                            _desc = _ctrl.AccessibleDescription
                        End If
                    End If
                    '
                    ' Continue looking down the control hierarchy
                    '
                    _mouseClient = _ctrl.PointToClient(_mouseScreen)
                    _parent = _ctrl
                    _ctrl = _ctrl.GetChildAtPoint(_mouseClient)
                Else
                    Exit Do
                End If
            Loop
            '
            ' Build the popup help message
            '
            If (_title Is Nothing) Then
                _title = Me.AccessibleName
                _desc = Me.AccessibleDescription
            Else
                If (_desc Is Nothing) Then
                    _desc = String.Empty
                End If
            End If

            ' Calculate popup window width
            Dim _width As Integer = _title.Length * Me.FontHeight()
            If (_width < _form.Width / 3) Then
                _width = CInt(_form.Width / 3) ' Minimum of 1/3 application width
            End If
            If (_form.Width / 2 < _width) Then
                _width = CInt(_form.Width / 2) ' Maximum of 1/2 application width
            End If

            ' Calculate approx. number of lines to display
            Dim _lines As Integer = CInt(((1.5 * _desc.Length) / (_width / (Me.FontHeight() / 2.5))) + 2)
            If (_lines < 3) Then
                _lines = 3 ' Minimum of 3 lines
            End If

            _lines = _lines + LineCount(_desc, CChar(vbCr)) - 1

            ' Calculate popup window height
            Dim _height As Integer = _lines * (Me.FontHeight() + 3)

            ' Calculate popup window position
            _mouseClient = _form.PointToClient(_mouseScreen)
            _mouseClient.Y = _mouseClient.Y + 20
            _mouseClient.X = _mouseClient.X + 10

            If (_mouseClient.Y < 0) Then
                _mouseClient.Y = 0 ' Must be within the view
            End If

            If (_form.Width < (_mouseClient.X + _width)) Then
                _mouseClient.X = _mouseClient.X - _width ' Can't be off right
            End If
            If (_form.Height - 40 < (_mouseClient.Y + _height)) Then
                _mouseClient.Y = _mouseClient.Y - _height - 40 ' Can't be off low
            End If

            ' Build the popup using a RichTextBox
            mHelpPopup = New RichTextBox With {
                .Width = _width,
                .Height = _height,
                .Location = _mouseClient,
                .BackColor = System.Drawing.Color.LightCyan,
                .ScrollBars = RichTextBoxScrollBars.None
            }

            ' Add to controls and display it
            _form.Controls.Add(mHelpPopup)
            mHelpPopup.BringToFront()
            mHelpPopup.Show()

            ' Load with the accessibility text
            AppendBoldLine(mHelpPopup, _title)
            AdvanceLine(mHelpPopup)
            AppendText(mHelpPopup, _desc)

            Return True

        Else
            '
            ' Take down What's This Help
            '
            mHelpPopup.Clear()
            mHelpPopup.Hide()
            _form.Controls.Remove(mHelpPopup)
            mHelpPopup.Dispose()
            mHelpPopup = Nothing

            Return False

        End If

    End Function

#End Region

#Region " UI "

    Friend Sub UpdateUI()
        If (mFlume Is Nothing) Then
            Me.Text = WinFlumeName() & " " & WinFlumeVersion()
            Me.WinFlumeTabControl.Hide()
        Else
            If (Me.FilePath = "") Then
                Me.Text = WinFlumeName() & " " & WinFlumeVersion() & " - New Project"
            Else
                Me.Text = WinFlumeName() & " " & WinFlumeVersion() & " - " & Me.FilePath
            End If

            Me.WinFlumeTabControl.Show()

            Me.DefineCanalControl.UpdateUI(Me)
            Me.DefineControlControl.UpdateUI(Me)
            Me.DesignControl.UpdateUI(Me)
            Me.CalibrationControl.UpdateUI(Me)
            Me.WallGageControl.UpdateUI(Me)
            Me.DataComparisonControl.UpdateUI(Me)
            Me.DrawingsReportsControl.UpdateUI(Me)
        End If

        If (LocateTabs = TabAlignment.Top) Then
            Me.WinFlumeTabControl.Alignment = TabAlignment.Top
        Else
            Me.WinFlumeTabControl.Alignment = TabAlignment.Bottom
        End If

        Me.UpdateToolbar()
        Me.UpdateStatusBar()
    End Sub

    Friend Sub UpdateStatusBar()
        If (mFlume Is Nothing) Then
            Me.StatusMessage1.Text = My.Resources.UseFileNew
            Me.StatusMessage2.Text = My.Resources.UserFileOpen
        Else ' Flume is defined
            If (ControlMatchedToApproach() And TailwaterMatchedToApproach()) Then
                Me.StatusMessage1.Text = My.Resources.CtrlTailMatchedToApproach
            ElseIf (ControlMatchedToApproach()) Then
                Me.StatusMessage1.Text = My.Resources.ControlMatchedToApproach
            ElseIf (TailwaterMatchedToApproach()) Then
                Me.StatusMessage1.Text = My.Resources.TailwaterMatchedToApproach
            Else
                Me.StatusMessage1.Text = "--> " & My.Resources.ProceeedDownTabs & " -->"
            End If

            Me.StatusMessage2.Text = Message2
        End If
    End Sub

    Friend Sub UpdateToolbar()

        If (mFlume IsNot Nothing) Then
            Dim FlumeChanged As Boolean = FlumeType.ChangedFlume(mFlume, mFileFlume)
            Me.SaveFileButton.Enabled = FlumeChanged

            Me.ViewWizardButton.Enabled = True
            Me.CanalDataButton.Enabled = True
            Me.ControlDataButton.Enabled = True
            Me.AlternativeDesignsButton.Enabled = True
            Me.RatingTableButton.Enabled = True
            Me.RatingEquationButton.Enabled = True
            Me.MeasuredDataButton.Enabled = True
            Me.WallGagesButton.Enabled = True
            Me.DrawingsReportsButton.Enabled = True
        Else
            Me.SaveFileButton.Enabled = False
            Me.ViewWizardButton.Enabled = False
            Me.CanalDataButton.Enabled = False
            Me.ControlDataButton.Enabled = False
            Me.AlternativeDesignsButton.Enabled = False
            Me.RatingTableButton.Enabled = False
            Me.RatingEquationButton.Enabled = False
            Me.MeasuredDataButton.Enabled = False
            Me.WallGagesButton.Enabled = False
            Me.DrawingsReportsButton.Enabled = False
        End If

        If (UndoStack IsNot Nothing) Then
            If (0 < UndoStack.Count) Then
                Me.UndoButton.Enabled = True
            Else
                Me.UndoButton.Enabled = False
            End If
        Else
            Me.UndoButton.Enabled = False
        End If

        If (RedoStack IsNot Nothing) Then
            If (0 < RedoStack.Count) Then
                Me.RedoButton.Enabled = True
            Else
                Me.RedoButton.Enabled = False
            End If
        Else
            Me.RedoButton.Enabled = False
        End If

        If (mFlume IsNot Nothing) Then

            Dim crestType As Integer = mFlume.CrestType
            If (crestType = MovableCrest) Then
                Me.CrestTypeSelection.Value = 1
            Else
                Me.CrestTypeSelection.Value = 0
            End If

            Dim revNum As Integer = mFlume.Revision
            Me.RevisionNumber.Text = My.Resources.Revision & " " & revNum.ToString
        Else
            Me.RevisionNumber.Text = My.Resources.Revision & " #"
        End If

        Dim loc As Point = Me.RevisionNumber.Location
        loc.X = Me.ToolBar.Width - Me.RevisionNumber.Width - Me.ToolBar.Margin.Horizontal
        Me.RevisionNumber.Location = loc

    End Sub

    Friend Function FindControl(ByVal ParentControl As Control, ByVal ParentName As String,
                                ByVal ControlName As String) As Control
        FindControl = Nothing

        If (ParentControl.Name = ParentName) Then ' Control could be here
            If (ParentControl.Visible) Then
                For Each ctrl As Control In ParentControl.Controls
                    If (ctrl.Name = ControlName) Then ' Found it
                        FindControl = ctrl
                        Exit Function
                    End If
                Next ctrl
            End If
        End If

        ' Keep looking in contained Controls
        For Each ctrl As Control In ParentControl.Controls
            FindControl = FindControl(ctrl, ParentName, ControlName)
            If (FindControl IsNot Nothing) Then
                Exit Function
            End If
        Next ctrl

    End Function

    Friend Sub ShowFlumeSketch()
        Dim sketch As DefinitionSketchDialog = New DefinitionSketchDialog

        If (mFlume IsNot Nothing) Then
            If (mFlume.CrestType = MovableCrest) Then
                sketch.ViewMovableButton.Checked = True
            Else
                sketch.ViewStationaryButton.Checked = True
            End If
        Else
            sketch.ViewStationaryButton.Checked = True
        End If

        Dim results As DialogResult = sketch.ShowDialog
    End Sub
    '
    ' Access to Main Tab Pages & Controls
    '
    Friend Function GetMainTabPages() As TabControl.TabPageCollection
        Return Me.WinFlumeTabControl.TabPages
    End Function

    Friend Function GetDefineCanalControl() As DefineCanalControl
        Return Me.DefineCanalControl
    End Function

    Friend Function GetDefineControlControl() As DefineControlControl
        Return Me.DefineControlControl
    End Function

    Friend Function GetDesignControl() As DesignControl
        Return Me.DesignControl
    End Function

    Friend Function GetCalibrationControl() As CalibrationControl
        Return Me.CalibrationControl
    End Function

    Friend Function GetDataComparisonControl() As DataComparisonControl
        Return Me.DataComparisonControl
    End Function

    Friend Function GetWallGageControl() As WallGageControl
        Return Me.WallGageControl
    End Function

    Friend Function GetDrawingsReportsControl() As DrawingsReportsControl
        Return Me.DrawingsReportsControl
    End Function
    '
    ' Access to Sub TabPages & Controls
    '
    Friend Function GetSubTabPages() As TabControl.TabPageCollection
        If (Me.DefineCanalControl.Visible) Then
            Return Me.DefineCanalControl.DefineCanalTabControl.TabPages
        ElseIf (Me.DefineControlControl.Visible) Then
            Return Me.DefineControlControl.DefineControlTabControl.TabPages
        ElseIf (Me.DesignControl.Visible) Then
            Return Me.DesignControl.DesignControlTabControl.TabPages
        ElseIf (Me.CalibrationControl.Visible) Then
            Return Me.CalibrationControl.CalibrationControlTabControl.TabPages
        ElseIf (Me.DataComparisonControl.Visible) Then
            Return Me.DataComparisonControl.DataComparisonControlTabControl.TabPages
        ElseIf (Me.WallGageControl.Visible) Then
            'Return Me.WallGageControl.WallGageControlTabControl.TabPages
        ElseIf (Me.DrawingsReportsControl.Visible) Then
            Return Me.DrawingsReportsControl.DrawingsReportsControlTabControl.TabPages
        End If

        Return Nothing
    End Function

    Friend Function GetSubTabControl() As TabControl
        If (Me.DefineCanalControl.Visible) Then
            Return Me.DefineCanalControl.DefineCanalTabControl
        ElseIf (Me.DefineControlControl.Visible) Then
            Return Me.DefineControlControl.DefineControlTabControl
        ElseIf (Me.DesignControl.Visible) Then
            Return Me.DesignControl.DesignControlTabControl
        ElseIf (Me.CalibrationControl.Visible) Then
            Return Me.CalibrationControl.CalibrationControlTabControl
        ElseIf (Me.DataComparisonControl.Visible) Then
            Return Me.DataComparisonControl.DataComparisonControlTabControl
        ElseIf (Me.WallGageControl.Visible) Then
            'Return Me.WallGageControl.WallGageControlTabControl
        ElseIf (Me.DrawingsReportsControl.Visible) Then
            Return Me.DrawingsReportsControl.DrawingsReportsControlTabControl
        End If

        Return Nothing
    End Function

    Friend Function GetAlternativeDesignsControl() As AlternativeDesignsControl
        Return GetDesignControl.AlternativeDesignsControl
    End Function

    Friend Function GetMeasuredDataEntryControl() As MeasuredDataEntryControl
        Return GetDataComparisonControl.MeasuredDataEntryControl
    End Function

    Friend Function GetTableChoicesControl() As TableChoicesControl
        Return GetCalibrationControl.TableChoicesControl
    End Function

    Friend Function GetRatingTableControl() As RatingTableControl
        Return GetCalibrationControl.RatingTableControl
    End Function

    Friend Function GetRatingEquationControl() As RatingEquationControl
        Return GetCalibrationControl.RatingEquationControl
    End Function

    Friend Function GetDitchridersTableControl() As DitchridersTableControl
        Return GetCalibrationControl.DitchridersTableControl
    End Function

    'Friend Function GetFixedHeadDataControl() As FixedHeadDataControl
    '    Return Me.WallGageControl.FixedHeadDataControl
    'End Function

    'Friend Function GetFixedDischargeDataControl() As FixedDischargeDataControl
    '    Return Me.WallGageControl.FixedDischargeDataControl
    'End Function

    'Friend Function GetWallGagePlotControl() As WallGagePlotsControl
    '    Return Me.WallGageControl.WallGagePlotsControl
    'End Function

    Friend Function GetBottomProfileControl() As BottomProfileControl
        Return Me.DefineCanalControl.BottomProfileControl
    End Function

    Friend Function GetSideBardControl() As SideBarControl
        Return Me.DefineCanalControl.SideBarControl
    End Function

    Friend Function GetUpstreamViewControl() As UpstreamViewControl
        Return GetSideBardControl.GetUpstreamViewControl
    End Function

    Friend Function GetDownstreamViewControl() As DownstreamViewControl
        Return GetSideBardControl.GetDownstreamViewControl
    End Function

    Friend Function GetApproachCrossSectionControl() As CrossSectionControl
        Dim approachShape As Integer = mFlume.Section(cApproach).Shape
        Dim approachCtrl As CrossSectionControl = GetDefineCanalControl.ApproachChannelControl.GetCrossSectionControl(approachShape)
        If (approachCtrl Is Nothing) Then
            Select Case (approachShape)
                Case shCircle
                    approachCtrl = New CircleControl(cApproach)
                Case shComplexTrapezoid
                    approachCtrl = New ComplexTrapezoidControl(cApproach)
                Case shParabola
                    approachCtrl = New ParabolaControl(cApproach)
                Case shRectangular
                    approachCtrl = New RectangularControl(cApproach)
                Case shSimpleTrapezoid
                    approachCtrl = New SimpleTrapezoidControl(cApproach)
                Case shUShaped
                    approachCtrl = New UShapedControl(cApproach)
                Case shVShaped
                    approachCtrl = New VShapedControl(cApproach)
                Case Else
                    Debug.Assert(False)
            End Select
        End If
        Return approachCtrl
    End Function

    Friend Function GetControlCrossSectionControl() As CrossSectionControl
        Dim controlShape As Integer = mFlume.Section(cControl).Shape
        Dim controlCtrl As CrossSectionControl = GetDefineControlControl.ControlSectionControl.GetCrossSectionControl(controlShape)
        If (controlCtrl Is Nothing) Then
            Select Case (controlShape)
                Case shCircle
                    controlCtrl = New CircleControl(cControl)
                Case shCircleInCircle
                    controlCtrl = New CircleInCircleControl(cControl)
                Case shComplexTrapezoid
                    controlCtrl = New ComplexTrapezoidControl(cControl)
                Case shParabola
                    controlCtrl = New ParabolaControl(cControl)
                Case shParabolaInParabola
                    controlCtrl = New ParabolaInParabolaControl(cControl)
                Case shRectangular
                    controlCtrl = New RectangularControl(cControl)
                Case shSillInCircle
                    controlCtrl = New SillInCircleControl(cControl)
                Case shSillInParabola
                    controlCtrl = New SillInParabolaControl(cControl)
                Case shSillInUShaped
                    controlCtrl = New SillInUShapedControl(cControl)
                Case shSimpleTrapezoid
                    controlCtrl = New SimpleTrapezoidControl(cControl)
                Case shTrapezoidInCircle
                    controlCtrl = New TrapezoidInCircleControl(cControl)
                Case shTrapezoidInParabola
                    controlCtrl = New TrapezoidInParabolaControl(cControl)
                Case shTrapezoidInUShaped
                    controlCtrl = New TrapezoidInUShapedControl(cControl)
                Case shUShaped
                    controlCtrl = New UShapedControl(cControl)
                Case shUShapedInUShaped
                    controlCtrl = New UShapedInUShapedControl(cControl)
                Case shVInRectangle
                    controlCtrl = New VinRectangleControl(cControl)
                Case shVShaped
                    controlCtrl = New VShapedControl(cControl)
                Case shVShapedInVShaped
                    controlCtrl = New VShapedInVShapedControl(cControl)
                Case shSillInTrapezoid
                    controlCtrl = New SillInTrapezoidControl(cControl)
                Case shTrapezoidInTrapezoid
                    controlCtrl = New TrapezoidInTrapezoidControl(cControl)
                Case shSillInRectangle
                    controlCtrl = New SillInRectangleControl(cControl)
                Case shRectangleInRectangle
                    controlCtrl = New RectangleInRectangleControl(cControl)
                Case shSillInVShaped
                    controlCtrl = New SillInVShapedControl(cControl)
                Case shTrapezoidInVShaped
                    controlCtrl = New TrapezoidInVShapedControl(cControl)
                Case shTrapezoidInRectangle
                    controlCtrl = New TrapezoidInRectangleControl(cControl)
                Case Else
                    Debug.Assert(False)
            End Select
        End If
        Return controlCtrl
    End Function

    Friend Function GetTailwaterCrossSectionControl() As CrossSectionControl
        Dim tailwaterShape As Integer = mFlume.Section(cTailwater).Shape
        Dim tailwaterCtrl As CrossSectionControl = GetDefineCanalControl.TailwaterChannelControl.GetCrossSectionControl(tailwaterShape)
        If (tailwaterCtrl Is Nothing) Then
            Select Case (tailwaterShape)
                Case shCircle
                    tailwaterCtrl = New CircleControl(cTailwater)
                Case shComplexTrapezoid
                    tailwaterCtrl = New ComplexTrapezoidControl(cTailwater)
                Case shParabola
                    tailwaterCtrl = New ParabolaControl(cTailwater)
                Case shRectangular
                    tailwaterCtrl = New RectangularControl(cTailwater)
                Case shSimpleTrapezoid
                    tailwaterCtrl = New SimpleTrapezoidControl(cTailwater)
                Case shUShaped
                    tailwaterCtrl = New UShapedControl(cTailwater)
                Case shVShaped
                    tailwaterCtrl = New VShapedControl(cTailwater)
                Case Else
                    Debug.Assert(False)
            End Select
        End If
        Return tailwaterCtrl
    End Function

#End Region

#Region " Printing "

    '*********************************************************************************************************
    ' Function PrintResults() - common function across WinFlume for displaying the PrintDialog
    '
    ' Input(s):     PrintDialog     - the specific Print Dialog unique Gages or Reports
    '               CurrentPage     - page number for the CurrentPage option
    '               PageRange()     - 2 entry array containing the First/Last page numbers to print
    '
    ' Output(s):    PageRange()     - array containing the selected page numbers to print
    '
    ' Returns:      Boolean         - True if print selection is valid
    '*********************************************************************************************************
    Friend Function PrintResults(ByVal PrintDialog As Forms.PrintDialog, ByVal CurrentPage As Integer,
                                 ByRef PageRange() As Integer) As Boolean

        If ((PrintDialog Is Nothing) Or (PageRange.Length < 2)) Then ' invalid parameters
            Debug.Assert(False)
            Return False
        End If

        ' Start with full page range
        Dim FromPage As Integer = PageRange(0)
        Dim ToPage As Integer = PageRange(1)

        If (ToPage < FromPage) Then ' there is nothing to print
            Return False
        End If

        ' Display the PrintDialog
        PrintDialog.UseEXDialog = True
        PrintDialog.AllowCurrentPage = True
        PrintDialog.AllowPrintToFile = True
        PrintDialog.AllowSelection = True
        PrintDialog.AllowSomePages = True
        PrintDialog.PrinterSettings.FromPage = FromPage
        PrintDialog.PrinterSettings.ToPage = ToPage

        If (PrintDialog.ShowDialog() = DialogResult.OK) Then

            If (PrintDialog.PrinterSettings.PrintRange = PrintRange.AllPages) Then
                ' Full range of pages
                ReDim PageRange(ToPage - FromPage)
                For pdx As Integer = 0 To PageRange.Length - 1
                    PageRange(pdx) = FromPage + pdx
                Next pdx

            ElseIf (PrintDialog.PrinterSettings.PrintRange = PrintRange.SomePages) Then
                ' Start of range
                If (0 < PrintDialog.PrinterSettings.FromPage) Then
                    If (PrintDialog.PrinterSettings.FromPage <= ToPage) Then
                        FromPage = PrintDialog.PrinterSettings.FromPage
                    End If
                End If
                ' End of range
                If (0 < PrintDialog.PrinterSettings.ToPage) Then
                    If (PrintDialog.PrinterSettings.ToPage <= ToPage) Then
                        ToPage = PrintDialog.PrinterSettings.ToPage
                    End If
                End If
                ' Order range correctly
                If (ToPage < FromPage) Then
                    Swap(ToPage, FromPage)
                End If

                ' Partial range of pages
                ReDim PageRange(ToPage - FromPage)
                For pdx As Integer = 0 To PageRange.Length - 1
                    PageRange(pdx) = FromPage + pdx
                Next pdx

            ElseIf (PrintDialog.PrinterSettings.PrintRange = PrintRange.Selection) Then
                ' Range is a set of pages
                Dim getSelection As db_GetStringValue = New db_GetStringValue("") With {
                    .Title = My.Resources.PrintSelection,
                    .Instructions = My.Resources.EnterPageSelection & "  "
                }
                getSelection.Instructions &= My.Resources.Example & ":  1,3,5-7"

                While (True)
                    Dim dlgResults As DialogResult = getSelection.ShowDialog()
                    If (dlgResults = Forms.DialogResult.OK) Then
                        ' Validate selection; Exit Try when error is found
                        Try
                            Dim selection As String = getSelection.Value.Trim
                            Dim ranges() As String = selection.Split(",".ToCharArray)

                            ReDim PageRange(-1)
                            For Each range As String In ranges
                                range = range.Trim
                                If (range = "") Then ' nothing between ,,
                                    Exit Try
                                Else
                                    Dim pages() As String = range.Split("-".ToCharArray)
                                    If (pages.Length = 0) Then ' only a '-'
                                        Exit Try
                                    ElseIf (pages.Length = 1) Then ' a single page
                                        Dim pageNo As Integer = Integer.Parse(pages(0))
                                        Dim numPages As Integer = PageRange.Length
                                        ReDim Preserve PageRange(numPages)
                                        PageRange(numPages) = pageNo
                                    ElseIf (pages.Length = 2) Then ' a page range
                                        Dim fromNo As Integer = Integer.Parse(pages(0))
                                        Dim toNo As Integer = Integer.Parse(pages(1))
                                        If (fromNo < toNo) Then
                                            For pdx As Integer = fromNo To toNo
                                                Dim numPages As Integer = PageRange.Length
                                                ReDim Preserve PageRange(numPages)
                                                PageRange(numPages) = pdx
                                            Next pdx
                                        ElseIf (fromNo = toNo) Then
                                            Dim numPages As Integer = PageRange.Length
                                            ReDim Preserve PageRange(numPages)
                                            PageRange(numPages) = fromNo
                                        Else ' toNo < fromNo
                                            Exit Try
                                        End If
                                    Else ' 3+ number in range
                                        Exit Try
                                    End If
                                End If
                            Next range

                            Exit While ' no errors in selections

                        Catch ex As Exception
                        End Try

                        getSelection.Instructions = My.Resources.ErrorPageSelection & "      "
                        getSelection.Instructions &= My.Resources.Example & ":  1,3,5-7"

                    ElseIf (dlgResults = Forms.DialogResult.Cancel) Then
                        Return False
                    End If
                End While ' (True)

            ElseIf (PrintDialog.PrinterSettings.PrintRange = PrintRange.CurrentPage) Then
                ' Range is one page
                ReDim PageRange(0)
                PageRange(0) = CurrentPage
            End If

        Else ' not DialogResult.OK
            Return False
        End If

        Return True
    End Function

#End Region

#Region " Examples File List "

    Private Sub LoadExamplesFileList()

        Dim examplesDirectory As String = Application.CommonAppDataPath + "\Examples"
        examplesDirectory = examplesDirectory.Replace("USBR / USDA", "USDA")

        If (mExamplesFileList Is Nothing) Then
            mExamplesFileList = New ArrayList
        Else
            mExamplesFileList.Clear()
        End If

        If (Directory.Exists(examplesDirectory)) Then
            ' Create a reference to the Examples directory.
            Dim di As New DirectoryInfo(examplesDirectory)
            ' Create an array representing the files in the current directory.
            Dim fi As FileInfo() = di.GetFiles()
            ' Save the names of the files in the Examples directory.
            Dim fiTemp As FileInfo
            For Each fiTemp In fi
                If (fiTemp.Extension.ToLower = ".flm") Then
                    mExamplesFileList.Add(fiTemp.Name)
                End If
            Next fiTemp
        End If

    End Sub

#End Region

#End Region

#Region " Flume Validation "

#Region " Bottom Profile "

    Friend Shared Function ValidateChannelDepth(ByRef ChannelDepth As Single) As Boolean
        Dim valid As Boolean = True

        If (mFlume.CrestType = MovableCrest) Then
            If (ChannelDepth < mFlume.OperatingDepth) Then
                Dim title As String = My.Resources.ChannelDepthLessThanOperatingDepth
                Dim msg As String = My.Resources.MsgCDltOD
                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                If (result = MsgBoxResult.Yes) Then
                    ChannelDepth = mFlume.OperatingDepth
                Else
                    valid = False
                End If
            End If
        Else ' StationaryCrest
            If (ChannelDepth < mFlume.SillHeight) Then
                Dim title As String = My.Resources.ChannelDepthLessThanSillHeight
                Dim msg As String = My.Resources.MsgCDltSH
                Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
                If (result = MsgBoxResult.Yes) Then
                    ChannelDepth = mFlume.SillHeight
                Else
                    valid = False
                End If
            End If
        End If

        Return valid
    End Function

    Friend Shared Function ValidateSillHeight(ByRef SillHeight As Single) As Boolean
        Dim valid As Boolean = True

        If (SillHeight > mFlume.ChannelDepth) Then
            Dim title As String = My.Resources.SillHeightGreaterThanChannelDepth
            Dim msg As String = My.Resources.MsgSHgtCD
            Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
            If (result = MsgBoxResult.Yes) Then
                SillHeight = mFlume.ChannelDepth
            Else
                valid = False
            End If
        End If

        Return valid
    End Function

    Friend Shared Function ValidateOperatingDepth(ByRef OperatingDepth As Single) As Boolean
        Dim valid As Boolean = True

        If (OperatingDepth > mFlume.ChannelDepth) Then
            Dim title As String = My.Resources.OperatingDepthGreaterThanChannelDepth
            Dim msg As String = My.Resources.MsgODgtCD
            Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.YesNo, title)
            If (result = MsgBoxResult.Yes) Then
                OperatingDepth = mFlume.ChannelDepth
            Else
                valid = False
            End If
        End If

        Return valid
    End Function

#End Region

#Region " Define Canal "

    Friend Shared Function ValidateTailwaterCalculationMethod() As Boolean
        Dim valid As Boolean = True

        Dim title As String = My.Resources.TailwaterBasis
        Dim msg As String = ""

        Select Case (mFlume.TailwaterBasis)
            Case TailwaterBasisManning
                title = My.Resources.TailwaterBasisManning
                If (mFlume.TailwaterN <= 0) Then
                    msg &= My.Resources.MsgManningnLeZero & vbCrLf
                    valid = False
                End If
                If (mFlume.Gradient <= 0) Then
                    msg &= My.Resources.MsgBedSlopeLeZero & vbCrLf
                    valid = False
                End If
            Case TailwaterBasis1QH
                title = My.Resources.TailwaterBasis1QH
                If (mFlume.TailwaterQ(0) <= 0) Then
                    msg &= My.Resources.MsgDischargeLeZero & vbCrLf
                    valid = False
                End If
                If (mFlume.TailwaterH(0) <= 0) Then
                    msg &= My.Resources.MsgLevelLeZero & vbCrLf
                    valid = False
                End If
            Case TailwaterBasis2QHPower
                title = My.Resources.TailwaterBasis2QHPower
                If (0 < mFlume.TailwaterQ(1)) And
                   (mFlume.TailwaterQ(1) < mFlume.TailwaterQ(2)) Then

                    If (0 < mFlume.TailwaterH(1)) And
                       (mFlume.TailwaterH(1) < mFlume.TailwaterH(2)) Then
                        ' OK
                    Else
                        msg &= My.Resources.MsgQandHmustIncrease & vbCrLf
                        valid = False
                    End If
                Else
                    msg &= My.Resources.MsgQandHmustIncrease & vbCrLf
                    valid = False
                End If
            Case TailwaterBasis3QH
                title = My.Resources.TailwaterBasis3QH
                If (mFlume.TailwaterQ(3) < mFlume.TailwaterQ(4)) And
                   (mFlume.TailwaterQ(4) < mFlume.TailwaterQ(5)) Then

                    If (mFlume.TailwaterH(3) < mFlume.TailwaterH(4)) And
                       (mFlume.TailwaterH(4) < mFlume.TailwaterH(5)) Then
                        ' OK
                    Else
                        msg &= My.Resources.MsgQandHmustIncrease & vbCrLf
                        valid = False
                    End If
                Else
                    msg &= My.Resources.MsgQandHmustIncrease & vbCrLf
                    valid = False
                End If
            Case TailwaterBasisLinearLookupTable
                title = My.Resources.TailwaterBasisLinearLookupTable

                ' Get valid (i.e. not erased) HQ value pairs
                Dim HQTable(LOOKUP_TABLE_SIZE) As HQLookupDataType
                Dim tdx As Integer = 0

                For Each HQ As HQLookupDataType In mFlume.HQLookup
                    With HQ
                        If (Not .QErased) And (Not .HErased) Then ' HQ pair has valid data
                            HQTable(tdx) = HQ
                            tdx += 1
                        End If
                    End With
                Next HQ

                ' Validate HQ value pairs; may not have enough entries
                If (tdx < 2) Then
                    msg &= My.Resources.MsgInvalidLookupTable & vbCrLf
                    valid = False
                Else
                    ReDim Preserve HQTable(tdx - 1)
                    Dim HQ0 As HQLookupDataType = HQTable(0)

                    For tdx = 1 To HQTable.Length - 1
                        Dim HQ1 As HQLookupDataType = HQTable(tdx)
                        If (HQ1.H <= HQ0.H) Or (HQ1.Q <= HQ0.Q) Then
                            msg &= My.Resources.MsgQandHmustIncrease & vbCrLf
                            valid = False
                            Exit For
                        End If

                        HQ0 = HQ1
                    Next tdx
                End If
        End Select

        If Not (valid) Then
            msg &= vbCrLf & My.Resources.EditDischargeTailwaterTab
            MsgBox(msg, MsgBoxStyle.Critical, title)
        End If

        Return valid
    End Function

    Friend Shared Function ValidateTailwaterLevels() As Boolean
        Dim valid As Boolean = True

        Dim title As String = My.Resources.TailwaterLevel
        Dim msg As String = ""

        Dim CD As Single = mFlume.ChannelDepth

        Dim y2Qmin As Single = mFlume.MinTailwater
        Dim y2Qmax As Single = mFlume.MaxTailwater
        If (CD < y2Qmin) Or (CD < y2Qmax) Then
            msg &= My.Resources.TailwaterLevel & " > " & My.Resources.ChannelDepth & vbCrLf
            valid = False
        ElseIf (y2Qmin <= 0) Or (y2Qmax <= 0) Then
            msg &= My.Resources.InvalidTailwaterLevel & vbCrLf
            valid = False
        End If

        If Not (valid) Then
            msg &= vbCrLf & My.Resources.EditChannelDepth
            msg &= vbCrLf & " or "
            msg &= vbCrLf & My.Resources.EditDischargeTailwaterTab
            MsgBox(msg, MsgBoxStyle.Critical, title)
        End If

        Return valid
    End Function

#End Region

#End Region

#Region " MRU Project List "
    '
    ' Add file to the MRU list
    '
    Private Sub AddFileToMruProjectList(ByVal MruFile As String)

        ' If file is already in the list; remove it
        For Each listFile As String In mMruProjectList
            If (MruFile = listFile) Then
                mMruProjectList.Remove(listFile)
                Exit For
            End If
        Next

        ' Add this new file to the head of the list
        mMruProjectList.Insert(0, MruFile)

        ' Save the new list to the Registry
        SaveMruProjectList()

    End Sub
    '
    ' Load MRU list from the Registry
    '
    Private Sub LoadMruProjectList()
        Try
            mMruProjectList.Clear()     ' Clear current MRU list

            ' Open Current User / Software key
            Dim productKey As RegistryKey = CurProductSubkey()
            If (productKey IsNot Nothing) Then

                ' Open MRU's key
                Dim mruKey As RegistryKey = productKey.CreateSubKey("MRU")
                If (mruKey IsNot Nothing) Then

                    ' Read MRU List
                    For idx As Integer = 1 To mMaxMruFiles

                        ' Get next file path
                        Dim mruFile As String = CStr(mruKey.GetValue(idx.ToString, String.Empty))

                        ' If file still exists, add it to the list
                        If Not (mruFile = String.Empty) Then
                            If File.Exists(mruFile) Then
                                If Not (mMruProjectList.Contains(mruFile)) Then
                                    mMruProjectList.Add(mruFile)
                                Else ' File already in list; delete it from the MRU list
                                    mruKey.DeleteValue(idx.ToString)
                                End If
                            Else ' File doesn't exist; delete it from the MRU list
                                mruKey.DeleteValue(idx.ToString)
                            End If
                        End If
                    Next idx

                End If
            End If

        Catch ex As Exception
            ' Ignore any errors; proceed without the MRU list
        End Try

    End Sub
    '
    ' Save MRU list to the Registry
    '
    Private Sub SaveMruProjectList()
        Try
            ' Open Current User / Software key
            Dim productKey As RegistryKey = CurProductSubkey()
            If (productKey IsNot Nothing) Then

                ' Open MRU's key
                Dim mruKey As RegistryKey = productKey.CreateSubKey("MRU")
                If (mruKey IsNot Nothing) Then

                    ' Write the MRU List (max of mMaxMruFiles entries)
                    Dim idx As Integer = 1
                    For Each mruFile As String In mMruProjectList

                        mruKey.SetValue(idx.ToString, mruFile)
                        idx += 1

                        If (mMaxMruFiles < idx) Then
                            Exit For
                        End If
                    Next mruFile

                End If
            End If

        Catch ex As Exception
            ' Ignore any errors; proceed without the MRU list
        End Try

    End Sub

#End Region

#Region " Menu Utilities "

#Region " ex_PictureBox "
    '
    ' Search the specified control and all its sub-controls for ex_PictureBoxes.
    '
    ' Add all visible ex_PictureBoxes to the specified menu.
    '
    Private Sub AddPictureBoxCopyItems(ByVal PictureBoxMenuItem As ToolStripMenuItem,
                                       ByVal SearchControl As Control)
        Try
            If (SearchControl.Visible) Then ' only search visible controls

                ' Is this control an ex_PictureBox?
                If ((SearchControl.GetType Is GetType(ex_PictureBox)) _
                 Or (SearchControl.GetType.IsSubclassOf(GetType(ex_PictureBox)))) Then

                    Dim exPictureBox As ex_PictureBox = DirectCast(SearchControl, ex_PictureBox)
                    If (exPictureBox IsNot Nothing) Then
                        If (exPictureBox.Image IsNot Nothing) Then
                            ' Skip small images (i.e. icons)
                            If ((20 <= exPictureBox.Image.Width) Or (20 <= exPictureBox.Image.Height)) Then
                                ' Add copy image as menu item
                                If Not (SearchControl.AccessibleName = String.Empty) Then
                                    mCopyGraphImageText = SearchControl.AccessibleName
                                Else
                                    mCopyGraphImageText = SearchControl.Name
                                End If

                                PictureBoxMenuItem.DropDownItems.Add(mCopyGraphImageText, Nothing, AddressOf CopyImage_Click)
                            End If
                        End If
                    End If
                Else
                    ' No, search its contained controls for ex_PictureBoxes
                    For Each ctrl As Control In SearchControl.Controls
                        AddPictureBoxCopyItems(PictureBoxMenuItem, ctrl)
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub
    '
    ' Copy Image to Clipboard
    '
    Private Sub CopyImage_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Handles CopyImage.Click (menu items are dynamically created by AddPictureBoxCopyItems()

        Debug.Assert(sender.GetType Is GetType(ToolStripMenuItem))

        ' Get PictureBox associated with menu item
        Dim exPictureBox As ex_PictureBox = FindExPictureBox(mCopyGraphImageText, Me)

        ' Copy Image from PictureBox to Clipboard
        If (exPictureBox IsNot Nothing) Then
            If (exPictureBox.Image IsNot Nothing) Then
                Clipboard.SetDataObject(exPictureBox.Image)
            End If
        End If

    End Sub
    '
    ' Search the specified control and all its sub-controls for ex_PictureBoxes.
    '
    ' Add all visible ex_PictureBoxes to the specified menu.
    '
    Private Sub AddPictureBoxSaveItems(ByVal PictureBoxMenu As ToolStripMenuItem,
                                       ByVal SearchControl As Control)
        Try
            If (SearchControl.Visible) Then ' only search visible controls

                ' Is this control an ex_PictureBox?
                If ((SearchControl.GetType Is GetType(ex_PictureBox)) _
                 Or (SearchControl.GetType.IsSubclassOf(GetType(ex_PictureBox)))) Then

                    Dim exPictureBox As ex_PictureBox = DirectCast(SearchControl, ex_PictureBox)
                    If (exPictureBox IsNot Nothing) Then
                        If (exPictureBox.Image IsNot Nothing) Then
                            ' Skip small images (i.e. icons)
                            If ((20 <= exPictureBox.Image.Width) Or (20 <= exPictureBox.Image.Height)) Then
                                ' Add image as menu item
                                Dim saveImageItem As New ToolStripMenuItem
                                If Not (SearchControl.AccessibleName = String.Empty) Then
                                    saveImageItem.Text = SearchControl.AccessibleName
                                Else
                                    saveImageItem.Text = SearchControl.Name
                                End If

                                mSaveGraphImageText = saveImageItem.Text

                                saveImageItem.DropDownItems.Add("Bitmap (*.bmp)...", Nothing, AddressOf SaveImage_Click)
                                saveImageItem.DropDownItems.Add("GIF (*.gif)...", Nothing, AddressOf SaveImage_Click)
                                saveImageItem.DropDownItems.Add("JPEG (*.jpeg)...", Nothing, AddressOf SaveImage_Click)
                                saveImageItem.DropDownItems.Add("Tiff (*.tiff)...", Nothing, AddressOf SaveImage_Click)

                                PictureBoxMenu.DropDownItems.Add(saveImageItem)
                            End If
                        End If
                    End If
                Else
                    ' No, search its contained controls for ex_PictureBoxes
                    For Each ctrl As Control In SearchControl.Controls
                        AddPictureBoxSaveItems(PictureBoxMenu, ctrl)
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub
    '
    ' Save Image to data file
    '
    Private Sub SaveImage_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Handles SaveImage.Click (menu items are dynamically created by AddPictureBoxSaveItems()

        Debug.Assert(sender.GetType Is GetType(ToolStripMenuItem))

        ' Get PictureBox associated with menu item
        Dim exPictureBox As ex_PictureBox = FindExPictureBox(mSaveGraphImageText, Me)
        If (exPictureBox IsNot Nothing) Then

            ' Get menu item that was clicked
            Dim saveImageItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
            Dim saveTypeName As String = saveImageItem.Text

            ' Save Image from PictureBox to data file
            If (exPictureBox.Image IsNot Nothing) Then
                If (saveTypeName.StartsWith("GIF")) Then
                    exPictureBox.SaveImageAsFile(Imaging.ImageFormat.Gif)
                ElseIf (saveTypeName.StartsWith("JPEG")) Then
                    exPictureBox.SaveImageAsFile(Imaging.ImageFormat.Jpeg)
                ElseIf (saveTypeName.StartsWith("Tiff")) Then
                    exPictureBox.SaveImageAsFile(Imaging.ImageFormat.Tiff)
                Else ' assume "BMP"
                    exPictureBox.SaveImageAsFile(Imaging.ImageFormat.Bmp)
                End If
            End If
        End If

    End Sub
    '
    ' Find the requested ExPictureBox by its name.
    '
    Private Function FindExPictureBox(ByVal PictureBoxName As String,
                                      ByVal SearchControl As Control) As ex_PictureBox
        Try
            If (SearchControl.Visible) Then ' Only search visible controls

                ' Is this control an ex_PictureBox
                If ((SearchControl.GetType Is GetType(ex_PictureBox)) _
                 Or (SearchControl.GetType.IsSubclassOf(GetType(ex_PictureBox)))) Then

                    ' Yes, is it the one we are looking for?
                    If ((SearchControl.AccessibleName = PictureBoxName) _
                 Or (SearchControl.Text = PictureBoxName)) Then
                        ' Yes, return it
                        Dim exPictureBox As ex_PictureBox = DirectCast(SearchControl, ex_PictureBox)
                        Return exPictureBox
                    End If
                Else
                    ' No, search contained controls
                    For Each ctrl As Control In SearchControl.Controls
                        Dim exPictureBox As ex_PictureBox = FindExPictureBox(PictureBoxName, ctrl)
                        If (exPictureBox IsNot Nothing) Then
                            Return exPictureBox
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        Return Nothing
    End Function

#End Region

#Region " ctl_Graph2D "
    '
    ' Search the specified control and all its sub-controls for ctl_Graph2D.
    '
    ' Add all visible ctl_Graph2D to the specified menu.
    '
    Friend Sub AddGraph2DCopyItems(ByVal Graph2DMenuItem As ToolStripMenuItem,
                                   ByVal SearchControl As Control)
        Try
            If (SearchControl.Visible) Then ' only search visible controls

                ' Is this control a ctl_Graph2D
                If ((SearchControl.GetType Is GetType(ctl_Graph2D)) _
                 Or (SearchControl.GetType.IsSubclassOf(GetType(ctl_Graph2D)))) Then

                    If Not (SearchControl.AccessibleName = String.Empty) Then
                        mCopyGraphDataText = SearchControl.AccessibleName
                    Else
                        mCopyGraphDataText = SearchControl.Name
                    End If

                    Graph2DMenuItem.DropDownItems.Add(mCopyGraphDataText, Nothing, AddressOf CopyData_Click)
                Else
                    ' No, search its contained controls for ctl_Graph2D
                    For Each Ctrl As Control In SearchControl.Controls
                        AddGraph2DCopyItems(Graph2DMenuItem, Ctrl)
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub
    '
    ' Copy Data from ctl_Graph2D to Clipboard
    '
    Private Sub CopyData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles CopyData.Click (menu items are dynamically created by AddGraph2DCopyItems()

        Debug.Assert(sender.GetType Is GetType(ToolStripMenuItem))

        ' Get ctl_Graph2D associated with menu item
        Dim ctlGraph2D As ctl_Graph2D = FindCtlGraph2D(mCopyGraphDataText, Me)

        ' Copy graph data to Clipboard
        If (ctlGraph2D IsNot Nothing) Then
            ctlGraph2D.CopyDataToClipboard()
        End If
    End Sub
    '
    ' Find the requested ctl_Graph2D by its name.
    '
    Friend Function FindCtlGraph2D(ByVal Graph2DName As String,
                                   ByVal SearchControl As Control) As ctl_Graph2D
        Try
            If (SearchControl.Visible) Then ' only search visible controls

                ' Is this control an ctl_Graph2D
                If ((SearchControl.GetType Is GetType(ctl_Graph2D)) _
                 Or (SearchControl.GetType.IsSubclassOf(GetType(ctl_Graph2D)))) Then

                    ' Yes, is it the one we are looking for?
                    If ((SearchControl.AccessibleName = Graph2DName) _
                 Or (SearchControl.Text = Graph2DName)) Then
                        ' Yes, return it
                        Dim ctlGraph2D As ctl_Graph2D = DirectCast(SearchControl, ctl_Graph2D)
                        Return ctlGraph2D
                    End If
                Else
                    ' No, search contained controls
                    For Each ctrl As Control In SearchControl.Controls
                        Dim ctlGraph2D As ctl_Graph2D = FindCtlGraph2D(Graph2DName, ctrl)
                        If (ctlGraph2D IsNot Nothing) Then
                            Return ctlGraph2D
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        Return Nothing
    End Function

#End Region

#Region " ctl_DataGridView "
    '
    ' Search the specified control and all its sub-controls for ctl_DataGridView.
    '
    ' Add all visible ctl_DataGridView to the specified menu.
    '
    Friend Sub AddTableDataCopyItems(ByVal DataGridViewMenuItem As ToolStripMenuItem,
                                     ByVal SearchControl As Control)
        Try
            If (SearchControl.Visible) Then ' only search visible controls

                ' Is this control a ctl_DataGridView
                If ((SearchControl.GetType Is GetType(ctl_DataGridView)) _
                 Or (SearchControl.GetType.IsSubclassOf(GetType(ctl_DataGridView)))) Then

                    If Not (SearchControl.AccessibleName = String.Empty) Then
                        mCopyTableDataText = SearchControl.AccessibleName
                    Else
                        mCopyTableDataText = SearchControl.Name
                    End If

                    DataGridViewMenuItem.DropDownItems.Add(mCopyTableDataText, Nothing, AddressOf CopyTableData_Click)
                Else
                    ' No, search its contained controls for ctl_DataGridView
                    For Each Ctrl As Control In SearchControl.Controls
                        AddTableDataCopyItems(DataGridViewMenuItem, Ctrl)
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub CopyTableData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles CopyTableData.Click (menu items are dynamically created by AddTableDataCopyItems()

        Debug.Assert(sender.GetType Is GetType(ToolStripMenuItem))

        ' Get ctl_DataGridView associated with menu item
        Dim ctlDataGridView As ctl_DataGridView = FindCtlDataGridView(mCopyTableDataText, Me)
        If (ctlDataGridView IsNot Nothing) Then ' copy graph data to Clipboard
            ctlDataGridView.CopyToClipboard()
        End If
    End Sub

    Friend Sub AddTableDataPasteItems(ByVal DataGridViewMenuItem As ToolStripMenuItem,
                                      ByVal SearchControl As Control)
        Try
            If (SearchControl.Visible) Then ' only search visible controls

                ' Is this control a ctl_DataGridView
                If ((SearchControl.GetType Is GetType(ctl_DataGridView)) _
                 Or (SearchControl.GetType.IsSubclassOf(GetType(ctl_DataGridView)))) Then

                    If Not (SearchControl.AccessibleName = String.Empty) Then
                        mPasteTableDataText = SearchControl.AccessibleName
                    Else
                        mPasteTableDataText = SearchControl.Name
                    End If

                    Dim gridView As ctl_DataGridView = DirectCast(SearchControl, ctl_DataGridView)
                    If (gridView.CanPasteFromClipboard) Then
                        DataGridViewMenuItem.DropDownItems.Add(mPasteTableDataText, Nothing, AddressOf PasteTableData_Click)
                    End If
                Else
                    ' No, search its contained controls for ctl_DataGridView
                    For Each Ctrl As Control In SearchControl.Controls
                        AddTableDataPasteItems(DataGridViewMenuItem, Ctrl)
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub PasteTableData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles PasteTableData.Click (menu items are dynamically created by AddTableDataCopyItems()

        Debug.Assert(sender.GetType Is GetType(ToolStripMenuItem))

        ' Get ctl_DataGridView associated with menu item
        Dim ctlDataGridView As ctl_DataGridView = FindCtlDataGridView(mPasteTableDataText, Me)
        If (ctlDataGridView IsNot Nothing) Then ' copy graph data to Clipboard
            ctlDataGridView.RaisePasteTableEvent()
        End If
    End Sub
    '
    ' Search the specified control and all its sub-controls for ctl_DataGridView.
    '
    ' Add all visible ctl_DataGridView to the specified menu.
    '
    Private Sub AddTableDataSaveItems(ByVal DataGridViewMenuItem As ToolStripMenuItem,
                                      ByVal SearchControl As Control)
        Try
            If (SearchControl.Visible) Then ' only search visible controls

                ' Is this control an ctl_DataGridView?
                If ((SearchControl.GetType Is GetType(ctl_DataGridView)) _
             Or (SearchControl.GetType.IsSubclassOf(GetType(ctl_DataGridView)))) Then

                    If Not (SearchControl.AccessibleName = String.Empty) Then
                        mSaveTableDataText = SearchControl.AccessibleName
                    Else
                        mSaveTableDataText = SearchControl.Name
                    End If

                    DataGridViewMenuItem.DropDownItems.Add(mSaveTableDataText, Nothing, AddressOf SaveTableData_Click)
                Else
                    ' No, search its contained controls for ctl_DataGridView
                    For Each ctrl As Control In SearchControl.Controls
                        AddTableDataSaveItems(DataGridViewMenuItem, ctrl)
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub
    '
    ' Save Table to data file
    '
    Private Sub SaveTableData_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Handles SaveTableData.Click (menu items are dynamically created by AddTableDataSaveItems()

        Debug.Assert(sender.GetType Is GetType(ToolStripMenuItem))

        ' Get ctl_DataGridView associated with menu item
        Dim ctlDataGridView As ctl_DataGridView = FindCtlDataGridView(mSaveTableDataText, Me)
        If (ctlDataGridView IsNot Nothing) Then ' save table data to File
            ctlDataGridView.ExportToFile()
        End If
    End Sub
    '
    ' Find the requested ctl_DataGridView by its name.
    '
    Friend Function FindCtlDataGridView(ByVal DataGridViewName As String,
                                        ByVal SearchControl As Control) As ctl_DataGridView
        Try
            If (SearchControl.Visible) Then ' only search visible controls

                ' Is this control an ctl_DataGridView
                If ((SearchControl.GetType Is GetType(ctl_DataGridView)) _
                 Or (SearchControl.GetType.IsSubclassOf(GetType(ctl_DataGridView)))) Then

                    ' Yes, is it the one we are looking for?
                    If ((SearchControl.AccessibleName = DataGridViewName) _
                 Or (SearchControl.Name = DataGridViewName)) Then
                        ' Yes, return it
                        Dim ctlDataGridView As ctl_DataGridView = DirectCast(SearchControl, ctl_DataGridView)
                        Return ctlDataGridView
                    End If
                Else
                    ' No, search contained controls
                    For Each ctrl As Control In SearchControl.Controls
                        Dim ctlDataGridView As ctl_DataGridView = FindCtlDataGridView(DataGridViewName, ctrl)
                        If (ctlDataGridView IsNot Nothing) Then
                            Return ctlDataGridView
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

        Return Nothing
    End Function

#End Region

#End Region

#Region " Events & Handlers "

#Region " Events "

    Friend Event FlumeDataChanged()
    Friend Sub RaiseFlumeDataChanged()
        If (mFlume IsNot Nothing) Then
            mFlume.UpdateMinMaxTailwater()  ' Min/Max Tailwater are ubiquitous
        End If

        RaiseEvent FlumeDataChanged()
        Me.UpdateToolbar()
        Me.UpdateStatusBar()
    End Sub

    Friend Event LengthUnitsChanged()
    Friend Sub RaiseLengthUnitsChanged()
        RaiseEvent LengthUnitsChanged()
    End Sub

#End Region

#Region " UI Events "

    '*********************************************************************************************************
    ' WinFlumeForm_Shown event occurs whenever WinFlume form is first shown
    '*********************************************************************************************************
    Private Sub WinFlumeForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim startFlume = New StartFlumeDialog
        While (True)
            Dim result As DialogResult = startFlume.ShowDialog          ' Give user options for selecting file
            If (result = DialogResult.OK) Then
                If (startFlume.OpenLastFlumeButton.Checked) Then
                    If (0 < mMruProjectList.Count) Then
                        Dim mruPath As String = CStr(mMruProjectList(0))
                        result = OpenFlumeFile(mruPath)                     ' Open last file
                    Else
                        result = OpenFlumeFile()                            ' Open other file
                    End If
                ElseIf (startFlume.OpenOtherFlumeButton.Checked) Then
                    result = OpenFlumeFile()                                ' Open other file
                ElseIf (startFlume.CreateNewFlumeButton.Checked) Then
                    result = NewFlumeFile()                                 ' Create new file
                Else
                    Debug.Assert(False)
                End If
                If (result = DialogResult.OK) Then
                    UpdateUI()
                    Exit While
                End If
            ElseIf (result = DialogResult.Cancel) Then
                Exit While
            End If
        End While
    End Sub

    '*********************************************************************************************************
    ' ValueChanged event handlers for contained Controls
    '
    ' Event handlers check if its corresponding Flume value has changed; if so, the Flume value is updated
    ' and an event is raised to let others know of the change.
    '*********************************************************************************************************
    Private Sub WinFlumeTabControl_ValueChanged() Handles WinFlumeTabControl.ValueChanged
        RaiseFlumeDataChanged()
    End Sub

    Private Sub WinFlumeTabControl_Deselecting(sender As Object, e As TabControlCancelEventArgs) _
        Handles WinFlumeTabControl.Deselecting
        If (WinFlumeTabControl.SelectedTab.Text = "Define Canal") Then
            If (ValidateTailwaterCalculationMethod()) Then
                If (ValidateTailwaterLevels()) Then

                Else
                    e.Cancel = True
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    '*********************************************************************************************************
    ' Sub MyBase_Resize() - resize contained Controls to match new size
    '*********************************************************************************************************
    Private Sub MyBase_Resize(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Resize
        Dim loc As Point = Me.RevisionNumber.Location
        loc.X = Me.ToolBar.Width - Me.RevisionNumber.Width - Me.ToolBar.Margin.Horizontal
        Me.RevisionNumber.Location = loc
    End Sub

#End Region

#Region " File Menu "

    Private Sub FileMenu_DropDownOpening(sender As Object, e As EventArgs) _
        Handles FileMenu.DropDownOpening

        Dim fileNew As Boolean = False
        Dim fileOpen As Boolean = False
        Dim flumeChanged As Boolean = False

        If ((mFlume IsNot Nothing) And (mFileFlume Is Nothing)) Then
            fileNew = True
        End If

        If ((mFlume IsNot Nothing) And (mFileFlume IsNot Nothing)) Then
            fileOpen = True
            flumeChanged = FlumeType.ChangedFlume(mFlume, mFileFlume)
        End If

        Me.FileCloseItem.Enabled = fileNew Or fileOpen
        Me.FileSaveAsItem.Enabled = fileNew Or fileOpen
        Me.FileSaveItem.Enabled = flumeChanged
        Me.FilePrintGageItem.Enabled = fileNew Or fileOpen
        Me.FilePrintReportItem.Enabled = fileNew Or fileOpen
        Me.FileExportAsItem.Enabled = fileNew Or fileOpen

        Me.FileExportGraphImageItem.DropDownItems.Clear()
        AddPictureBoxSaveItems(Me.FileExportGraphImageItem, Me)
        Me.FileExportGraphImageItem.Enabled = 0 < Me.FileExportGraphImageItem.DropDownItems.Count

        Me.FileExportTableDataItem.DropDownItems.Clear()
        AddTableDataSaveItems(Me.FileExportTableDataItem, Me)
        Me.FileExportTableDataItem.Enabled = 0 < Me.FileExportTableDataItem.DropDownItems.Count

        ' Populate the Example File List
        FileExamplesItem.Visible = False
        FileExamplesItem.DropDownItems.Clear()

        Dim idx As Integer = 1
        Dim item As String
        For Each file As String In mExamplesFileList
            FileExamplesItem.Visible = True

            If (idx < 10) Then ' use numeric (1-9) prefix
                item = "&" + Chr(Asc("1") + idx - 1) + " - " + file
            Else ' use alpha (a-z) prefix
                item = "&" + Chr(Asc("a") + idx - 10) + " - " + file
            End If

            FileExamplesItem.DropDownItems.Add(item, Nothing,
                                               New EventHandler(AddressOf ExampleFileItem_Click))

            idx += 1
            If (35 < idx) Then
                Exit For
            End If
        Next file

        ' Populate the MRU Project List
        FileRecentItem.Enabled = False
        FileRecentItem.DropDownItems.Clear()

        idx = 1
        For Each MRU As String In mMruProjectList
            FileRecentItem.Enabled = True
            FileRecentItem.DropDownItems.Add("&" + idx.ToString + " - " + MRU, Nothing,
                                             New EventHandler(AddressOf MruFileItem_Click))
            idx += 1

            If (mMaxMruFiles < idx) Then
                Exit For
            End If
        Next

    End Sub

    ' Menu items
    Private Sub FileNewItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileNewItem.Click
        If (VerifySaved()) Then
            NewFlumeFile()
            UpdateUI()
        End If
    End Sub

    Private Sub FileOpenItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileOpenItem.Click
        If (VerifySaved()) Then
            OpenFlumeFile()
            UpdateUI()
        End If
    End Sub

    Private Sub FileCloseItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileCloseItem.Click
        If (VerifySaved()) Then
            CloseFlumeFile()
            UpdateUI()
        End If
    End Sub

    Private Sub FileSaveItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileSaveItem.Click
        SaveFlumeFile(Me.FilePath)
    End Sub

    Private Sub FileSaveAsItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileSaveAsItem.Click
        SaveAsFlumeFile()
    End Sub

    Private Sub ExampleFileItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles ExampleFileItem.Click (menu items are dynamically created by FileMenu_Popup()

        If (sender.GetType Is GetType(ToolStripMenuItem)) Then
            Dim examplesDirectory As String = Application.CommonAppDataPath + "\Examples\"
            examplesDirectory = examplesDirectory.Replace("USBR / USDA", "USDA")

            Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

            ' Get the selected File Path
            Dim menuText As String = menuItem.Text
            Dim filePath As String = examplesDirectory + menuText.Substring(5)

            If (VerifySaved()) Then
                CloseFlumeFile()
                OpenFlumeFile(filePath)
                UpdateUI()
            End If
        End If

    End Sub

    Private Sub MruFileItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles MruFileItem.Click (menu items are dynamically created by FileMenu_DropDownOpening()

        If (sender.GetType Is GetType(ToolStripMenuItem)) Then
            Dim mruItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

            ' Get the selected File Path
            Dim mruText As String = mruItem.Text
            Dim mruPath As String = mruText.Substring(5)

            If (VerifySaved()) Then
                CloseFlumeFile()
                OpenFlumeFile(mruPath)
                UpdateUI()
            End If
        End If
    End Sub

    Private Sub FileExportAsV7Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileExportAsV7Item.Click
        SaveAsFlumeFile(7)
    End Sub

    Private Sub FileExportAsV6Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileExportAsV6Item.Click
        SaveAsFlumeFile(6)
    End Sub

    Private Sub FileExportAsV5Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileExportAsV5Item.Click
        SaveAsFlumeFile(5)
    End Sub

    Private Sub FileExportAsV4Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileExportAsV4Item.Click
        SaveAsFlumeFile(4)
    End Sub

    Private Sub FileExportAsV3Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileExportAsV3Item.Click
        SaveAsFlumeFile(3)
    End Sub

    Private Sub FileExportAsV2Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileExportAsV2Item.Click
        SaveAsFlumeFile(2)
    End Sub

    Private Sub FileExportAsV1Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileExportAsV1Item.Click
        SaveAsFlumeFile(1)
    End Sub

    Private Sub PrintFixedHeadIntervalGageItem_Click(sender As Object, e As EventArgs) _
        Handles PrintFixedHeadIntervalGageItem.Click
        'Dim wallGageCtrl As WallGagePlotsControl = Me.GetWallGagePlotControl
        Dim wallGageCtrl As WallGageControl = Me.GetWallGageControl
        wallGageCtrl.PrintFixedHeadGage()
    End Sub

    Private Sub PrintFixedDischargeIntervalGageItem_Click(sender As Object, e As EventArgs) _
        Handles PrintFixedDischargeIntervalGageItem.Click
        'Dim wallGageCtrl As WallGagePlotsControl = Me.GetWallGagePlotControl
        Dim wallGageCtrl As WallGageControl = Me.GetWallGageControl
        wallGageCtrl.PrintFixedDischargeGage()
    End Sub

    Private Sub FilePrintReportItem_Click(sender As Object, e As EventArgs) _
        Handles FilePrintReportItem.Click
        Dim reportsCtrl As DrawingsReportsControl = Me.GetDrawingsReportsControl
        reportsCtrl.UpdateUI(Me, True)
        reportsCtrl.Print()
    End Sub

    Private Sub FileExitItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles FileExitItem.Click
        If (VerifySaved()) Then
            Application.Exit() ' Exit the program
        End If
    End Sub

    Private Sub MyBase_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles MyBase.Closing
        If Not (VerifySaved()) Then
            e.Cancel = True
        End If
    End Sub

#End Region

#Region " Edit Menu "

    Private Sub EditMenu_DropDownOpening(sender As Object, e As EventArgs) _
        Handles EditMenu.DropDownOpening

        If (UndoStack IsNot Nothing) Then
            If (0 < UndoStack.Count) Then
                Me.EditUndoItem.Enabled = True
            Else
                Me.EditUndoItem.Enabled = False
            End If
        Else
            Me.EditUndoItem.Enabled = False
        End If

        If (RedoStack IsNot Nothing) Then
            If (0 < RedoStack.Count) Then
                Me.EditRedoItem.Enabled = True
            Else
                Me.EditRedoItem.Enabled = False
            End If
        Else
            Me.EditRedoItem.Enabled = False
        End If

        Me.EditCopyGraphBtimapItem.DropDownItems.Clear()
        AddPictureBoxCopyItems(Me.EditCopyGraphBtimapItem, Me)
        Me.EditCopyGraphBtimapItem.Enabled = 0 < Me.EditCopyGraphBtimapItem.DropDownItems.Count

        Me.EditCopyGraphDataItem.DropDownItems.Clear()
        AddGraph2DCopyItems(Me.EditCopyGraphDataItem, Me)
        Me.EditCopyGraphDataItem.Enabled = 0 < Me.EditCopyGraphDataItem.DropDownItems.Count

        Me.EditCopyTableDataItem.DropDownItems.Clear()
        AddTableDataCopyItems(Me.EditCopyTableDataItem, Me)
        Me.EditCopyTableDataItem.Enabled = 0 < Me.EditCopyTableDataItem.DropDownItems.Count

        Me.EditPasteTableDataItem.DropDownItems.Clear()
        AddTableDataPasteItems(Me.EditPasteTableDataItem, Me)
        Me.EditPasteTableDataItem.Enabled = 0 < Me.EditPasteTableDataItem.DropDownItems.Count
    End Sub

    Private Sub UndoContextMenu_Popup(ByVal sender As Object, ByVal e As EventArgs) _
        Handles UndoContextMenu.Popup
        UndoContextMenu.MenuItems.Clear()

        If (UndoStack IsNot Nothing) Then
            If (0 < UndoStack.Count) Then
                For Each undoItem As UndoRedoItem In UndoStack
                    UndoContextMenu.MenuItems.Add(undoItem.UndoText, AddressOf EditUndoItems_Click)
                Next
            End If
        End If

        UndoContextMenu.MenuItems.Add("Undo 1 Action", AddressOf EditUndoItem_Click)
    End Sub

    Private Sub RedoContextMenu_Popup(ByVal sender As Object, ByVal e As EventArgs) _
        Handles RedoContextMenu.Popup
        RedoContextMenu.MenuItems.Clear()

        If (RedoStack IsNot Nothing) Then
            If (0 < RedoStack.Count) Then
                For Each redoItem As UndoRedoItem In RedoStack
                    RedoContextMenu.MenuItems.Add(redoItem.UndoText, AddressOf EditRedoItems_Click)
                Next
            End If
        End If

        RedoContextMenu.MenuItems.Add("Redo 1 Action", AddressOf EditRedoItem_Click)
    End Sub

    Private Sub EditUndoItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles EditUndoItem.Click
        Undo()
    End Sub

    Private Sub EditUndoItems_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Handles EditUndoItems.Click
        If (sender.GetType Is GetType(MenuItem)) Then
            Dim item As MenuItem = DirectCast(sender, MenuItem)

            For cnt As Integer = 0 To item.Index
                Undo()
            Next
        End If
    End Sub

    Private Sub EditRedoItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles EditRedoItem.Click
        Redo()
    End Sub

    Private Sub EditRedoItems_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Handles EditRedoItems.Click
        If (sender.GetType Is GetType(MenuItem)) Then
            Dim item As MenuItem = DirectCast(sender, MenuItem)

            For cnt As Integer = 0 To item.Index
                Redo()
            Next
        End If
    End Sub

#End Region

#Region " View Menu "

    Private Sub ViewMenu_DropDownOpening(sender As Object, e As EventArgs) _
        Handles ViewMenu.DropDownOpening

        Dim fileOpened As Boolean = (mFlume IsNot Nothing)

        ViewAsDialogItem.Enabled = fileOpened
        ViewTabItem.Enabled = fileOpened
        ViewSubtabItem.Enabled = fileOpened
        ViewWizardItem.Enabled = fileOpened

        If (fileOpened) Then
            ' Populate View Tab List
            ViewTabItem.DropDownItems.Clear()

            Dim idx As Integer = 1
            Dim mainPages As TabControl.TabPageCollection = GetMainTabPages()
            If (mainPages IsNot Nothing) Then
                For Each page As TabPage In GetMainTabPages()
                    Dim tabName As String = page.Text
                    ViewTabItem.DropDownItems.Add("&" + idx.ToString + " - " + tabName, Nothing,
                                          New EventHandler(AddressOf ViewTabItem_Click))
                    idx += 1
                Next page
            End If

            ' Populate View Subtab List
            ViewSubtabItem.DropDownItems.Clear()

            idx = 1
            Dim tabPages As TabControl.TabPageCollection = GetSubTabPages()
            If (tabPages IsNot Nothing) Then
                For Each page As TabPage In GetSubTabPages()
                    Dim tabName As String = page.Text
                    ViewSubtabItem.DropDownItems.Add("&" + idx.ToString + " - " + tabName, Nothing,
                                             New EventHandler(AddressOf ViewSubtabItem_Click))
                    idx += 1
                Next page
                ViewSubtabItem.Enabled = True
            Else
                ViewSubtabItem.Enabled = False
            End If
        End If
    End Sub

    Private Sub ViewRefreshItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ViewRefreshItem.Click
        UpdateUI()
    End Sub

    Private Sub ViewSizeItem_DropDownOpening(sender As Object, e As EventArgs) _
        Handles ViewSizeItem.DropDownOpening
        ' Get View Size dimensions
        Dim horzSize As Integer = Me.Width
        Dim vertSize As Integer = Me.Height

        ViewSize800x600Item.Checked = False
        ViewSize900x675Item.Checked = False
        ViewSize1024x768Item.Checked = False
        ViewSizeCustomItem.Checked = False

        ViewSizeCustomItem.Visible = False

        If ((horzSize = 800) And (vertSize = 600)) Then
            ViewSize800x600Item.Checked = True
        ElseIf ((horzSize = 900) And (vertSize = 675)) Then
            ViewSize900x675Item.Checked = True
        ElseIf ((horzSize = 1024) And (vertSize = 768)) Then
            ViewSize1024x768Item.Checked = True
        Else
            ViewSizeCustomItem.Text = My.Resources.Custom & " (" & horzSize.ToString & "x" & vertSize.ToString & ")"
            ViewSizeCustomItem.Visible = True
            If ((horzSize = HorzViewSize) And (vertSize = VertViewSize)) Then
                ViewSizeCustomItem.Checked = True
            End If
        End If
    End Sub

    Private Sub ViewSize800x600Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ViewSize800x600Item.Click
        HorzViewSize = 800
        VertViewSize = 600
        Me.Size = New Size(800, 600)
    End Sub

    Private Sub ViewSize900x675Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ViewSize900x675Item.Click
        HorzViewSize = 900
        VertViewSize = 675
        Me.Size = New Size(900, 675)
    End Sub

    Private Sub ViewSize1024x768Item_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ViewSize1024x768Item.Click
        HorzViewSize = 1024
        VertViewSize = 768
        Me.Size = New Size(1024, 768)
    End Sub

    Private Sub ViewSizeCustomItem_Click(sender As Object, e As EventArgs) _
        Handles ViewSizeCustomItem.Click
        HorzViewSize = Me.Width
        VertViewSize = Me.Height
        Me.Size = New Size(HorzViewSize, VertViewSize)
    End Sub

    Private Sub ViewDefinitionSketchItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ViewDefinitionSketchItem.Click
        ShowFlumeSketch()
    End Sub

    Private Sub ViewTabItem_Click(sender As Object, e As EventArgs) _
        Handles ViewTabItem.Click
        Try
            Dim tabItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

            Dim tabText As String = tabItem.Text
            Dim tabNum As String = tabText.Substring(1, 1)
            Dim tabName As String = tabText.Substring(5)
            Dim tabIdx As Integer = Integer.Parse(tabNum) - 1

            Me.WinFlumeTabControl.SelectTab(tabIdx)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub ViewSubtabItem_Click(sender As Object, e As EventArgs) _
        Handles ViewSubtabItem.Click
        Try
            Dim tabItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

            Dim tabText As String = tabItem.Text
            Dim tabNum As String = tabText.Substring(1, 1)
            Dim tabName As String = tabText.Substring(5)
            Dim tabIdx As Integer = Integer.Parse(tabNum) - 1

            Dim subTab As TabControl = GetSubTabControl()
            subTab.SelectTab(tabIdx)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub ViewWizardItem_Click(sender As Object, e As EventArgs) _
        Handles ViewWizardItem.Click
        If (mFlume IsNot Nothing) Then
            ShowWizard()
        End If
    End Sub

    Friend Sub ShowWizard()
        Dim wizard = New FlumeWizard(Me, mFlume)

        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim wizLoc As Point = Me.PointToScreen(New Point(0, 0))
        If (wizard.Width < wizLoc.X) Then
            wizLoc.X -= wizard.Width
        Else
            wizLoc.X += Me.Width

            If (screenWidth < wizLoc.X + wizard.Width) Then
                wizLoc.X = screenWidth - wizard.Width
            End If
        End If
        'wizard.Height = Me.Height
        wizard.Location = wizLoc
        wizard.Show()
    End Sub

#End Region

#Region " View as Dialog "

#Region " Rating Table "

    Private RTsize As Size = New Size(0, 0)

    Private Sub ViewRatingTableItem_Click(sender As Object, e As EventArgs) _
        Handles ViewRatingTableItem.Click
        ViewRatingTableAsDialog()
    End Sub

    Friend Sub ViewRatingTableAsDialog()
        Try
            ' Display the Rating Table control in a Dialog
            If ((RTsize.Height = 0) Or (RTsize.Width = 0)) Then
                RTsize = Me.Size
            End If

            Dim ctrl As RatingTableControl = New RatingTableControl(Me, True)
            ctrl.UpdateUI(Me)
            ctrl.ViewAsDialogButton.Hide()

            Dim db As ControlViewerDialog = New ControlViewerDialog(ctrl) With {
            .Size = RTsize,
            .Text = My.Resources.RatingTable
            }

            Dim result As DialogResult = db.ShowDialog()
            If (result = DialogResult.OK) Then
                Dim dialogData As RatingTableControl.DialogData = ctrl.GetDialogData
                If (dialogData IsNot Nothing) Then
                    If (dialogData.Changed) Then
                        ' Establish Undo point with the current values
                        Dim undoText As String = My.Resources.Dialog & " - " & My.Resources.RatingTable
                        Dim undoData As New RatingTableControl.DialogData
                        Me.AddUndoItem(Me.Name, ctrl.Name, undoText, undoData)
                        Me.ClearRedoStack() ' Clear Redo stack in Click handler only
                        ' Save dialog values as new current values
                        dialogData.Save()
                        ' Raise the changed data event
                        Me.RaiseFlumeDataChanged()
                    End If
                End If
            End If

            RTsize = db.Size
            ctrl = Nothing
            db = Nothing
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub UndoRatingTableDialog(ByVal UndoItem As UndoRedoItem)
        Debug.Assert(Me.InUndo, "Not in Undo")
        If (UndoItem.UndoValue.GetType Is GetType(RatingTableControl.DialogData)) Then
            ' Establish Redo point with the current values
            Dim redoText As String = My.Resources.Dialog & " - " & My.Resources.RatingTable
            Dim redoData As New RatingTableControl.DialogData
            Me.AddRedoItem(Me.Name, UndoItem.ControlName, redoText, redoData)
            ' Set undo values as new current values
            Dim undoData As RatingTableControl.DialogData = DirectCast(UndoItem.UndoValue, RatingTableControl.DialogData)
            undoData.Save()
            ' Raise the changed data event
            Me.RaiseFlumeDataChanged()
        Else
            Debug.Assert(False, "Undo - Invalid dialog data")
        End If
    End Sub

    Private Sub RedoRatingTableDialog(ByVal RedoItem As UndoRedoItem)
        Debug.Assert(Me.InRedo, "Not in Redo")
        If (RedoItem.UndoValue.GetType Is GetType(RatingTableControl.DialogData)) Then
            ' Establish Undo point with the current values
            Dim undoText As String = My.Resources.Dialog & " - " & My.Resources.RatingTable
            Dim undoData As New RatingTableControl.DialogData
            Me.AddUndoItem(Me.Name, RedoItem.ControlName, undoText, undoData)
            ' Set redo values as new current values
            Dim redoData As RatingTableControl.DialogData = DirectCast(RedoItem.UndoValue, RatingTableControl.DialogData)
            redoData.Save()
            ' Raise the changed data event
            Me.RaiseFlumeDataChanged()
        Else
            Debug.Assert(False, "Redo - Invalid dialog data")
        End If
    End Sub

#End Region

#Region " Rating Equation "

    Private RETsize As Size = New Size(0, 0)

    Private Sub ViewRatingEquationTableItem_Click(sender As Object, e As EventArgs) _
        Handles ViewRatingEquationTableItem.Click
        ViewRatingEquationAsDialog()
    End Sub

    Friend Sub ViewRatingEquationAsDialog()
        Try
            ' Display the Rating Equation Table control in a Dialog
            If ((RETsize.Height = 0) Or (RETsize.Width = 0)) Then
                RETsize = Me.Size
            End If

            Dim ctrl As RatingEquationControl = New RatingEquationControl(Me, True)
            ctrl.UpdateUI(Me)
            ctrl.ViewAsDialogButton.Hide()

            Dim db As ControlViewerDialog = New ControlViewerDialog(ctrl) With {
            .Size = RETsize,
            .Text = My.Resources.RatingEquation
            }

            Dim result As DialogResult = db.ShowDialog()
            If (result = DialogResult.OK) Then
                Dim dialogData As RatingEquationControl.DialogData = ctrl.GetDialogData
                If (dialogData IsNot Nothing) Then
                    If (dialogData.Changed) Then
                        ' Establish Undo point with the current values
                        Dim undoText As String = My.Resources.Dialog & " - " & My.Resources.RatingEquation
                        Dim undoData As New RatingEquationControl.DialogData(mFlume)
                        Me.AddUndoItem(Me.Name, ctrl.Name, undoText, undoData)
                        Me.ClearRedoStack() ' Clear Redo stack in Click handler only
                        ' Save dialog values as new current values
                        dialogData.Save()
                        ' Raise the changed data event
                        Me.RaiseFlumeDataChanged()
                    End If
                End If
            End If

            RETsize = Me.Size
            ctrl = Nothing
            db = Nothing
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub UndoRatingEquationDialog(ByVal UndoItem As UndoRedoItem)
        Debug.Assert(Me.InUndo, "Not in Undo")
        If (UndoItem.UndoValue.GetType Is GetType(RatingEquationControl.DialogData)) Then
            ' Establish Redo point with the current values
            Dim redoText As String = My.Resources.Dialog & " - " & My.Resources.RatingEquation
            Dim redoData As New RatingEquationControl.DialogData(mFlume)
            Me.AddRedoItem(Me.Name, UndoItem.ControlName, redoText, redoData)
            ' Set undo values as new current values
            Dim undoData As RatingEquationControl.DialogData = DirectCast(UndoItem.UndoValue, RatingEquationControl.DialogData)
            undoData.Save()
            ' Raise the changed data event
            Me.RaiseFlumeDataChanged()
        Else
            Debug.Assert(False, "Undo - Invalid dialog data")
        End If
    End Sub

    Private Sub RedoRatingEquationDialog(ByVal RedoItem As UndoRedoItem)
        Debug.Assert(Me.InRedo, "Not in Redo")
        If (RedoItem.UndoValue.GetType Is GetType(RatingEquationControl.DialogData)) Then
            ' Establish Undo point with the current values
            Dim undoText As String = My.Resources.Dialog & " - " & My.Resources.RatingEquation
            Dim undoData As New RatingEquationControl.DialogData(mFlume)
            Me.AddUndoItem(Me.Name, RedoItem.ControlName, undoText, undoData)
            ' Set redo values as new current values
            Dim redoData As RatingEquationControl.DialogData = DirectCast(RedoItem.UndoValue, RatingEquationControl.DialogData)
            redoData.Save()
            ' Raise the changed data event
            Me.RaiseFlumeDataChanged()
        Else
            Debug.Assert(False, "Redo - Invalid dialog data")
        End If
    End Sub

#End Region

#Region " Ditchrider's Table "

    Private DRTsize As Size = New Size(0, 0)

    Private Sub ViewDitchridersTableItem_Click(sender As Object, e As EventArgs) _
        Handles ViewDitchridersTableItem.Click
        ViewDitchridersTableAsDialog()
    End Sub

    Friend Sub ViewDitchridersTableAsDialog()
        Try
            ' Display the Ditch Rider's Table control in a Dialog
            If ((DRTsize.Height = 0) Or (DRTsize.Width = 0)) Then
                DRTsize = Me.Size
            End If

            Dim ctrl As DitchridersTableControl = New DitchridersTableControl(Me, True)
            ctrl.UpdateUI(Me)
            ctrl.ViewAsDialogButton.Hide()

            Dim db As ControlViewerDialog = New ControlViewerDialog(ctrl) With {
            .Size = DRTsize,
            .Text = My.Resources.DitchridersTable
            }

            Dim result As DialogResult = db.ShowDialog()
            If (result = DialogResult.OK) Then
                Dim dialogData As DitchridersTableControl.DialogData = ctrl.GetDialogData
                If (dialogData IsNot Nothing) Then
                    If (dialogData.Changed) Then
                        ' Establish Undo point with the current values
                        Dim undoText As String = My.Resources.Dialog & " - " & My.Resources.DitchridersTable
                        Dim undoData As New DitchridersTableControl.DialogData(mFlume)
                        Me.AddUndoItem(Me.Name, ctrl.Name, undoText, undoData)
                        Me.ClearRedoStack() ' Clear Redo stack in Click handler only
                        ' Save dialog values as new current values
                        dialogData.Save()
                        ' Raise the changed data event
                        Me.RaiseFlumeDataChanged()
                    End If
                End If
            End If

            DRTsize = db.Size
            ctrl = Nothing
            db = Nothing
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub UndoDitchridersTableDialog(ByVal UndoItem As UndoRedoItem)
        Debug.Assert(Me.InUndo, "Not in Undo")
        If (UndoItem.UndoValue.GetType Is GetType(DitchridersTableControl.DialogData)) Then
            ' Establish Redo point with the current values
            Dim redoText As String = My.Resources.Dialog & " - " & My.Resources.DitchridersTable
            Dim redoData As New DitchridersTableControl.DialogData(mFlume)
            Me.AddRedoItem(Me.Name, UndoItem.ControlName, redoText, redoData)
            ' Set undo values as new current values
            Dim undoData As DitchridersTableControl.DialogData = DirectCast(UndoItem.UndoValue, DitchridersTableControl.DialogData)
            undoData.Save()
            ' Raise the changed data event
            Me.RaiseFlumeDataChanged()
        Else
            Debug.Assert(False, "Undo - Invalid dialog data")
        End If
    End Sub

    Private Sub RedoDitchridersTableDialog(ByVal RedoItem As UndoRedoItem)
        Debug.Assert(Me.InRedo, "Not in Redo")
        If (RedoItem.UndoValue.GetType Is GetType(DitchridersTableControl.DialogData)) Then
            ' Establish Undo point with the current values
            Dim undoText As String = My.Resources.Dialog & " - " & My.Resources.DitchridersTable
            Dim undoData As New DitchridersTableControl.DialogData(mFlume)
            Me.AddUndoItem(Me.Name, RedoItem.ControlName, undoText, undoData)
            ' Set redo values as new current values
            Dim redoData As DitchridersTableControl.DialogData = DirectCast(RedoItem.UndoValue, DitchridersTableControl.DialogData)
            redoData.Save()
            ' Raise the changed data event
            Me.RaiseFlumeDataChanged()
        Else
            Debug.Assert(False, "Redo - Invalid dialog data")
        End If
    End Sub

#End Region

#Region " Alternative Designs "

    Dim RPDsize As Size = New Size(0, 0)

    Private Sub AlternativeDesignsItem_Click(sender As Object, e As EventArgs) _
        Handles AlternativeDesignsItem.Click
        AlternativeDesignsAsDialog()
    End Sub

    Friend Sub AlternativeDesignsAsDialog()
        Try
            ' Display the Alternative Designs control in a Dialog
            If ((RPDsize.Height = 0) Or (RPDsize.Width = 0)) Then
                RPDsize = Me.Size
            End If

            Dim ctrl As AlternativeDesignsControl = New AlternativeDesignsControl(Me)
            ctrl.MakeSelectedCurrentButton.Text &= " " & My.Resources.ThenCloseDialog & "."
            ctrl.UpdateUI(Me)
            ctrl.ViewAsDialogButton.Hide()

            Dim db As ControlViewerDialog = New ControlViewerDialog(ctrl) With {
            .Size = RPDsize,
            .Text = My.Resources.AlternativeDesigns
            }

            ctrl.Dialog = db

            db.OK_Button.Hide()
            db.Cancel_Button.Text = My.Resources.Close

            Dim result As DialogResult = db.ShowDialog()
            If (result = DialogResult.OK) Then
                If (ctrl.SelectedFlume IsNot Nothing) Then ' a new Flume was selected
                    ' Setup Undo point
                    Dim undoText As String = My.Resources.Dialog & " - " & My.Resources.AlternativeDesigns
                    AddUndoItem(Me.Name, ctrl.Name, undoText, mFlume)

                    SetFlume(ctrl.SelectedFlume) ' Set selected Flume as new application Flume
                    RaiseFlumeDataChanged() ' Inform others of change
                End If
            End If

            RPDsize = db.Size
            ctrl = Nothing
            db = Nothing
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub UndoAlternativeDesignsDialog(ByVal UndoItem As UndoRedoItem)
        Debug.Assert(Me.InUndo, "Not in Undo")
        If (UndoItem.UndoValue.GetType Is GetType(Flume.FlumeType)) Then
            ' Establish Redo point with the current values
            Dim redoText As String = My.Resources.Dialog & " - " & My.Resources.AlternativeDesigns
            Dim redoData As Flume.FlumeType = mFlume
            Me.AddRedoItem(Me.Name, UndoItem.ControlName, redoText, redoData)
            ' Set undo values as new current values
            Dim undoVal As FlumeType = DirectCast(UndoItem.UndoValue, FlumeType)
            SetFlume(undoVal)
            RaiseFlumeDataChanged() ' Inform others of change
        Else
            Debug.Assert(False, "Undo - Invalid dialog data")
        End If
    End Sub

    Private Sub RedoAlternativeDesignsDialog(ByVal RedoItem As UndoRedoItem)
        Debug.Assert(Me.InRedo, "Not in Redo")
        If (RedoItem.UndoValue.GetType Is GetType(Flume.FlumeType)) Then
            ' Establish Undo point with the current values
            Dim undoText As String = My.Resources.Dialog & " - " & My.Resources.AlternativeDesigns
            Dim undoData As Flume.FlumeType = mFlume
            Me.AddUndoItem(Me.Name, RedoItem.ControlName, undoText, undoData)
            ' Set redo values as new current values
            Dim redoVal As FlumeType = DirectCast(RedoItem.UndoValue, FlumeType)
            SetFlume(redoVal)
            RaiseFlumeDataChanged() ' Inform others of change
        Else
            Debug.Assert(False, "Redo - Invalid dialog data")
        End If
    End Sub

#End Region

#Region " Rating Comparison "

    Private RCsize As Size = New Size(0, 0)

    Private Sub ViewRatingComparisonTableItem_Click(sender As Object, e As EventArgs) _
        Handles ViewRatingComparisonTableItem.Click
        ViewRatingComparisonTableAsDialog()
    End Sub

    Friend Sub ViewRatingComparisonTableAsDialog()
        Try
            ' Display the Rating Comparison Table control in a Dialog
            If ((RCsize.Height = 0) Or (RCsize.Width = 0)) Then
                RCsize = Me.Size
            End If

            Dim ctrl As RatingComparisonControl = New RatingComparisonControl(Me, True)
            ctrl.UpdateUI(Me)
            ctrl.ViewAsDialogButton.Hide()

            Dim db As ControlViewerDialog = New ControlViewerDialog(ctrl) With {
            .Size = RCsize,
            .Text = My.Resources.RatingComparisonTable
            }
            db.OK_Button.Hide()
            db.Cancel_Button.Text = My.Resources.Close

            Dim result As DialogResult = db.ShowDialog()
            If (result = DialogResult.OK) Then
                ' nothing to do
            End If

            RCsize = db.Size
            ctrl = Nothing
            db = Nothing
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

#End Region

#End Region

#Region " Options Menu "

    Private Sub OptionsMenu_DropDownOpening(sender As Object, e As EventArgs) _
        Handles OptionsMenu.DropDownOpening

        OptionsMenuLocateTabsTop.Checked = (LocateTabs = TabAlignment.Top)
        OptionsMenuLocateTabsBottom.Checked = (LocateTabs = TabAlignment.Bottom)

        OptionsMenuLocateSubtabsMiddle.Checked = (LocateSubtabs = TabAlignment.Top)
        OptionsMenuLocateSubtabsBottom.Checked = (LocateSubtabs = TabAlignment.Bottom)

    End Sub

    Private Sub OptionsDefaultUnitsItem_Click(sender As Object, e As EventArgs) _
        Handles OptionsDefaultUnitsItem.Click
        Dim results As DialogResult = ShowUnitsDialog(UnitsDialog.UnitsDialogModes.SetDefaultUnits)
    End Sub

    Private Sub OptionsFlumeUnitsItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles OptionsFlumeUnitsItem.Click
        Dim results As DialogResult = ShowUnitsDialog(UnitsDialog.UnitsDialogModes.ChangeProjectUnits)
    End Sub

    Friend Function ShowUnitsDialog(ByVal DialogMode As UnitsDialog.UnitsDialogModes) As DialogResult
        mUnitsDialog.Flume = mFlume
        mUnitsDialog.DialogMode = DialogMode
        Dim results As DialogResult = mUnitsDialog.ShowDialog
        If (results = DialogResult.OK) Then
            LoadFlumeWithUnits(mFlume)
            UpdateUI()
        End If
        Return results
    End Function

    Private Sub OptionsMenuLocateTabsTop_Click(sender As Object, e As EventArgs) _
        Handles OptionsMenuLocateTabsTop.Click
        LocateTabs = TabAlignment.Top
        UpdateUI()
    End Sub

    Private Sub OptionsMenuLocateTabsBottom_Click(sender As Object, e As EventArgs) _
        Handles OptionsMenuLocateTabsBottom.Click
        LocateTabs = TabAlignment.Bottom
        UpdateUI()
    End Sub

    Private Sub OptionsMenuLocateSubtabsMiddle_Click(sender As Object, e As EventArgs) _
        Handles OptionsMenuLocateSubtabsMiddle.Click
        LocateSubtabs = TabAlignment.Top
        UpdateUI()
    End Sub

    Private Sub OptionsMenuLocateSubtabsBottom_Click(sender As Object, e As EventArgs) _
        Handles OptionsMenuLocateSubtabsBottom.Click
        LocateSubtabs = TabAlignment.Bottom
        UpdateUI()
    End Sub

#End Region

#Region " Help Menu "

    Private Sub HelpMenu_DropDownOpening(sender As Object, e As EventArgs) _
        Handles HelpMenu.DropDownOpening
        Dim F1TextString As String = F1Text()
        Me.F1HelpItem.Text = F1TextString

        Me.HelpWhatsThisItem.Visible = DebuggerIsAttached()
    End Sub

    Private Sub HelpWhatsThisItem_Click(ByVal sender As Object, ByVal e As EventArgs) _
    Handles HelpWhatsThisItem.Click
        mWhatsThisHelp = True
        StartWhatsThisHelp(Me)
    End Sub
    '
    ' Stop What's This Help when window is de-activated
    '  Note - Mouse capture is lost when window is de-activated
    '
    Protected Overrides Sub OnDeactivate(ByVal e As EventArgs)
        ' If What's This Help is active; stop it
        If (mWhatsThisHelp) Then
            StopWhatsThisHelp(Me)
        End If
        ' Call base class method to continue Windows message processing
        MyBase.OnDeactivate(e)
    End Sub
    '
    ' WndProc() - override of WndProc for intercepting Windows messages
    '
    Protected Overrides Sub WndProc(ByRef m As Message)
        ' Intercept all Windows messages prior to system handling;
        '  Look for events of interest
        Select Case (m.Msg)

            Case WM_LBUTTONUP, WM_RBUTTONUP, WM_MBUTTONUP ' Button up messages

                If (mWhatsThisHelp = True) Then
                    ' Process the What's This Help request
                    mWhatsThisHelp = WhatsThisHelp(m, Me)

                    If (mWhatsThisHelp) Then
                        PauseWhatsThisHelp(Me)
                    Else
                        StopWhatsThisHelp(Me)
                    End If

                    ' Absorb this event; don't let system process it
                    Return
                End If

        End Select
        '
        ' Call base class method to continue Windows message processing
        '
        MyBase.WndProc(m)

    End Sub

    Private Sub HelpAboutItem_Click(sender As Object, e As EventArgs) Handles HelpAboutItem.Click
        Dim db As New AboutWinFlumeDialog
        db.ShowDialog()
    End Sub
    '
    ' PDF Manual based Help
    '
    Private Sub ShowPdfHelpManual(Optional ByVal Destination As String = "")
        Try
            If (mPdfViewer Is Nothing) Then
                mPdfViewer = New PdfViewerDialog With {
                .Text = "WinFlume2 User Manual",
                .Height = Me.Height,
                .Width = Me.Width
                }
                mPdfViewer.PdfViewer.LoadFile("WinFlume2_UserManual.pdf")
                mPdfViewer.PdfViewer.setPageMode("none")
                mPdfViewer.PdfViewer.gotoFirstPage()
                mPdfViewer.PdfViewer.setViewScroll("FitH", 0)
            End If
            If (Destination IsNot Nothing) Then
                If (Destination = "") Then
                    mPdfViewer.PdfViewer.gotoFirstPage()
                Else
                    mPdfViewer.PdfViewer.setNamedDest(Destination)
                    If (Destination.StartsWith("ch:")) Then
                        mPdfViewer.PdfViewer.setViewScroll("FitH", 0)
                    End If
                End If
            Else
                mPdfViewer.PdfViewer.gotoFirstPage()
            End If
            mPdfViewer.Show()
            mPdfViewer.BringToFront()
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Sub

    Private Sub HelpViewUserManualItem_Click(sender As Object, e As EventArgs) _
        Handles HelpViewUserManualItem.Click
        ShowPdfHelpManual("")
    End Sub

    Private Sub HelpIntroductionItem_Click(sender As Object, e As EventArgs) _
        Handles HelpIntroductionItem.Click
        ShowPdfHelpManual("ch:Introduction")
    End Sub

    Private Sub HelpUserInterfaceItem_Click(sender As Object, e As EventArgs) _
        Handles HelpUserInterfaceItem.Click
        ShowPdfHelpManual("ch:GUI")
    End Sub

    Private Sub HelpPrinciplesDesignItem_Click(sender As Object, e As EventArgs) _
        Handles HelpPrinciplesDesignItem.Click
        ShowPdfHelpManual("ch:Principles")
    End Sub

    Private Sub HelpFlumeDesignItem_Click(sender As Object, e As EventArgs) _
        Handles HelpFlumeDesignItem.Click
        ShowPdfHelpManual("ch:Design")
    End Sub

    Private Sub BottomProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BottomProfileToolStripMenuItem.Click
        ShowPdfHelpManual("sec:AdjustDimensions")
    End Sub

    Private Sub EndViewsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles EndViewsToolStripMenuItem.Click
        ShowPdfHelpManual("sec:EndViews")
    End Sub

    Private Function F1Text() As String
        F1Text = ""
        If (mFlume IsNot Nothing) Then
            Dim catTab As TabPage = Me.WinFlumeTabControl.SelectedTab
            F1Text = catTab.Text
        End If
    End Function

    '*********************************************************************************************************
    ' Function F1Dest() - return the Destination tag for the current WinFlume subtab
    '*********************************************************************************************************
    Private Function F1Dest() As String
        F1Dest = ""
        Try
            If (mFlume IsNot Nothing) Then
                Dim catTab As TabPage = Me.WinFlumeTabControl.SelectedTab
                Dim catName As String = catTab.Name

                Select Case (catName)
                    Case "DefineCanalTab"
                        Dim defineCanal As DefineCanalControl = DirectCast(catTab.Controls(0), DefineCanalControl)
                        Dim subTabCtrl As TabControl = defineCanal.DefineCanalTabControl
                        Dim subTab As TabPage = subTabCtrl.SelectedTab
                        Dim subName As String = subTab.Name

                        Select Case (subName)
                            Case "ApproachChannelTab"
                                F1Dest = "sec:DefineApproach"
                            Case "TailwaterChannelTab"
                                F1Dest = "sec:DefineTailwater"
                            Case "DischargeTailwaterTab"
                                F1Dest = "sec:DefineTailwater"
                            Case "FreeboardRequirementTab"
                                F1Dest = "sec:RequiredFreeboard"
                            Case Else
                                Debug.Assert(False)
                                F1Dest = "sec:DefineCanal"
                        End Select
                    Case "DefineControlTab"
                        Dim defineControl As DefineControlControl = DirectCast(catTab.Controls(0), DefineControlControl)
                        Dim subTabCtrl As TabControl = defineControl.DefineControlTabControl
                        Dim subTab As TabPage = subTabCtrl.SelectedTab
                        Dim subName As String = subTab.Name

                        Select Case (subName)
                            Case "FlumeCrestTab"
                                F1Dest = "sec:FlumeCrest"
                            Case "HeadMeasurementTab"
                                F1Dest = "sec:HeadMeasurement"
                            Case "ControlSectionTab"
                                F1Dest = "sec:ControlSection"
                            Case "DesignReviewTab"
                                F1Dest = "sec:DesignReview"
                            Case Else
                                F1Dest = "sec:DefineControl"
                        End Select
                    Case "DesignTab"
                        Dim designControl As DesignControl = DirectCast(catTab.Controls(0), DesignControl)
                        Dim subTabCtrl As TabControl = designControl.DesignControlTabControl
                        Dim subTab As TabPage = subTabCtrl.SelectedTab
                        Dim subName As String = subTab.Name

                        Select Case (subName)
                            Case "DesignOptionsTab"
                                F1Dest = "sec:DesignOptions"
                            Case "AlternativeDesignsTab"
                                F1Dest = "sec:ReviewDesigns"
                            Case Else
                                Debug.Assert(False)
                                F1Dest = "sec:DesignModule"
                        End Select
                    Case "CalibrationTab"
                        Dim calibrationControl As CalibrationControl = DirectCast(catTab.Controls(0), CalibrationControl)
                        Dim subTabCtrl As TabControl = calibrationControl.CalibrationControlTabControl
                        Dim subTab As TabPage = subTabCtrl.SelectedTab
                        Dim subName As String = subTab.Name

                        Select Case (subName)
                            Case "TableChoicesTab"
                                F1Dest = "sec:CalibrationOptions"
                            Case "RatingTableTab"
                                F1Dest = "sec:RatingTable"
                            Case "RatingEquationTableTab"
                                F1Dest = "sec:RatingEquation"
                            Case "DitchridersTableTab"
                                F1Dest = "sec:Ditchrider"
                            Case Else
                                Debug.Assert(False)
                                F1Dest = "sec:CalibrationModule"
                        End Select
                    Case "WallGagesTab"
                        F1Dest = "sec:WallGages"
                    Case "DataComparisonTab"
                        F1Dest = "sec:DataComparison"
                    Case "DrawingsReportsTab"
                        F1Dest = "sec:Reports"
                End Select
            End If
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try
    End Function

    Private Sub F1HelpItem_Click(sender As Object, e As EventArgs) _
        Handles F1HelpItem.Click
        Dim F1DestString As String = F1Dest()
        ShowPdfHelpManual(F1DestString)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If (keyData = Keys.F1) Then
            Dim F1DestString As String = F1Dest()
            ShowPdfHelpManual(F1DestString)
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region

#Region " Toolbar Buttons "

    Private Sub ToolBar_ButtonClick(ByVal sender As Object, ByVal e As ToolBarButtonClickEventArgs) _
        Handles ToolBar.ButtonClick

        Select Case ToolBar.Buttons.IndexOf(e.Button)
            Case 0 ' New Project
                If (VerifySaved()) Then
                    NewFlumeFile()
                    UpdateUI()
                End If
            Case 1 ' Open Project
                If (VerifySaved()) Then
                    OpenFlumeFile()
                    UpdateUI()
                End If
            Case 2 ' Save Project
                SaveFlumeFile(Me.FilePath)
            Case 3 ' Separator
                Debug.Assert(False, "Separator being used as button")
            Case 4 ' Undo
                Undo()
            Case 5 ' Redo
                Redo()
            Case 6 ' Separator
                Debug.Assert(False, "Separator being used as button")
            Case 7 ' What's This Help
                mWhatsThisHelp = True
                StartWhatsThisHelp(Me)
            Case 8 ' Separator
                Debug.Assert(False, "Separator being used as button")
            Case 9 ' View Wizard
                If (mFlume IsNot Nothing) Then
                    ShowWizard()
                End If
            Case 10 ' Separator
                Debug.Assert(False, "Separator being used as button")
            Case 11 ' Canal Data
                If (mFlume IsNot Nothing) Then
                    Me.WinFlumeTabControl.SelectTab(0)
                    Dim subTab As TabControl = GetSubTabControl()
                    subTab.SelectTab(3)
                End If
            Case 12 ' Control Data
                If (mFlume IsNot Nothing) Then
                    Me.WinFlumeTabControl.SelectTab(1)
                    Dim subTab As TabControl = GetSubTabControl()
                    subTab.SelectTab(0)
                End If
            Case 13 ' Alternative Designs
                If (mFlume IsNot Nothing) Then
                    Me.WinFlumeTabControl.SelectTab(2)
                    Dim subTab As TabControl = GetSubTabControl()
                    subTab.SelectTab(1)
                End If
            Case 14 ' Rating Table
                If (mFlume IsNot Nothing) Then
                    Me.WinFlumeTabControl.SelectTab(3)
                    Dim subTab As TabControl = GetSubTabControl()
                    subTab.SelectTab(0)
                End If
            Case 15 ' Rating Equation
                If (mFlume IsNot Nothing) Then
                    Me.WinFlumeTabControl.SelectTab(3)
                    Dim subTab As TabControl = GetSubTabControl()
                    subTab.SelectTab(2)
                End If
            Case 16 ' Wall Gages
                If (mFlume IsNot Nothing) Then
                    Me.WinFlumeTabControl.SelectTab(4)
                    ' Wall Gage tab has no subtabs
                End If
            Case 17 ' Measured Data
                If (mFlume IsNot Nothing) Then
                    Me.WinFlumeTabControl.SelectTab(5)
                    Dim subTab As TabControl = GetSubTabControl()
                    subTab.SelectTab(0)
                End If
            Case 18 ' Drawings & Reports
                If (mFlume IsNot Nothing) Then
                    Me.WinFlumeTabControl.SelectTab(6)
                    Dim subTab As TabControl = GetSubTabControl()
                    subTab.SelectTab(0)
                End If
            Case Else
                Debug.Assert(False, "Invalid toolbar button")
        End Select
    End Sub

    Private Sub SketchButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles SketchButton.Click
        ShowFlumeSketch()
    End Sub

    Private Sub CrestTypeSelection_ValueChanged() Handles CrestTypeSelection.ValueChanged
        If (mFlume IsNot Nothing) Then
            mFlume.CrestType = CrestTypeSelection.Value + 1
            Select Case (mFlume.CrestType)
                Case StationaryCrest
                    ' Nothing to do
                Case MovableCrest
                    ' Control Section limited to Rectangular or V-in-Rectangle
                    Dim cSection = mFlume.Section(cControl)                     ' Control Section data
                    If Not (cSection.Shape = shVInRectangle) Then
                        cSection.Shape = shRectangular
                    End If
                Case Else
                    Debug.Assert(False, "Invalid Crest Type")
            End Select
            RaiseFlumeDataChanged()
        End If
    End Sub

#End Region

#End Region

End Class
