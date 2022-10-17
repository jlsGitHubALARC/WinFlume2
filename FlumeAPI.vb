
'*************************************************************************************************************
' Class FlumeAPI - a wrapper around the Flume DLL for handling inconsistencies between the new WinFlume
'                  UI and the Flume.dll functionality.
'
' Flume.dll provides minimal support for the six added (May/June 2019) cross-sections (Sill-In-Trapezoid,
'   Trapezoid-In-Trapezoid, Sill-In-Rectangle, Rectangle-In-Rectangle, Sill-In-VShape, Trapezoid-In-VShape):
'
'       Flume Class/Module      Support for new cross-sections
'       ------------------      ------------------------------
'       Globals                 Shape numbers (sh...) and string descriptors added
'       FlumeType               Area, TopWidth, WettedPerimeter, SectionDescription, etc. functions extended
'       Design                  NO support
'       Hydraulics              NO support
'
' Although the Design Class & Hydraulics Module do not support these new cross-sections, the support provided
' is sufficient to implement the functionality required. This class, together with WinFlumeDesign and
' WinFlumeSectionType provide the supported needed to use Flume.dll to provide the functionality required
' by the six new cross-sections.
'*************************************************************************************************************
Imports Flume
Imports Flume.Globals

Public Class FlumeAPI

#Region " Properties "

    Protected mFlume As Flume.FlumeType                     ' Flume.dll data accessor
    Public Sub SetFlume(ByVal Flume As Flume.FlumeType)
        mFlume = Flume
    End Sub

#End Region

#Region " Constructor(s) "

    Public Sub New(ByVal Flume As Flume.FlumeType)
        If (Flume IsNot Nothing) Then
            mFlume = Flume
        Else
            Debug.Assert(False)
        End If
    End Sub

#End Region

#Region " ContractionAdjustment "

    '*********************************************************************************************************
    ' Property ContractionAdjustment - API function for managing FlumeType.ContractionAdjustment
    '
    ' New WinFlume cross-section        Flume.dll support cross-section
    ' --------------------------        -------------------------------
    '  Sill-In-Trapezoid                 Trapezoid
    '  Trapezoid-In-Trapezoid            Trapezoid
    '  Sill-In-Rectangle                 Rectangle
    '  Rectangle-In-Rectangle            Rectangle
    '  Sill-In-VShape                    Trapezoid
    '  Trapezoid-In-VShape               Trapezoid
    '
    ' These six WinFlume cross-sections support Raise/Lower Inner Section but the Flume.dll does not for
    ' Trapezoid & Rectangle.  Raise/Lower Inner Section must be exchanged for Raise/Lower Entire Section.
    '*********************************************************************************************************
    Public Property ContractionAdjustment As Integer
        Get
            ContractionAdjustment = mFlume.ContractionAdjustment

            If (WinFlumeForm.ControlMatchedToApproach) Then ' validate contraction option

                Select Case (mFlume.Section(cControl).Shape)
                    Case shSillInTrapezoid, shSillInRectangle, shSillInVShaped

                        ContractionAdjustment = RaiseSillHeight ' only one option

                    Case shSimpleTrapezoid, shVShaped ' , shCircle, shUShaped, shParabola

                        ContractionAdjustment = RaiseLowerEntireSection ' only one option

                    Case shTrapezoidInTrapezoid, shRectangleInRectangle, shTrapezoidInVShaped

                        If (ContractionAdjustment = RaiseLowerEntireSection) Then ' exchange
                            ContractionAdjustment = RaiseLowerInnerSection
                        End If

                    Case shCircleInCircle, shParabolaInParabola, shUShapedInUShaped, shVShapedInVShaped

                        If (ContractionAdjustment = RaiseLowerEntireSection) Then ' exchange
                            ContractionAdjustment = RaiseLowerInnerSection
                        End If
                End Select
            End If
        End Get
        Set(value As Integer) ' might be RaiseLowerInnerSection

            Select Case (mFlume.Section(cControl).Shape)
                Case shSillInTrapezoid, shTrapezoidInTrapezoid,
                     shSillInRectangle, shRectangleInRectangle,
                     shSillInVShaped, shTrapezoidInVShaped,
                     shCircleInCircle, shParabolaInParabola,
                     shUShapedInUShaped, shVShapedInVShaped

                    If (value = RaiseLowerInnerSection) Then ' exchange
                        value = RaiseLowerEntireSection
                    End If
            End Select

            mFlume.ContractionAdjustment = value
        End Set
    End Property

#End Region

#Region " Flume Methods "

    '*********************************************************************************************************
    ' Wrapper methods for Flume.FLL methods called the the WinFlume UI.
    '
    ' These methods translate the WinFlumeSectionType object, which supports the six new Control Section
    ' cross-sections, into the FlumeType object that performs the required calculations.
    '
    ' 1) Save a copy of the Control Section's WinFlumeSectionType object
    ' 2) Instantiate the corresponding SectionType object
    ' 3) Execute the Flume Sub | Function
    ' 4) Restore the saved WinflumeSectionType object
    '
    ' Note - WinFlumeSectionType is a subclass of SectionType
    '*********************************************************************************************************
    Public Sub FixLengths()
        Dim ctrlSection As SectionType = mFlume.Section(cControl) ' reference to SectionType object
        If (ctrlSection.GetType Is GetType(WinFlumeSectionType)) Then ' translation required
            Dim winFlumeCtrlSection As WinFlumeSectionType = DirectCast(ctrlSection, WinFlumeSectionType)
            Dim savFlumeCtrlSection = New WinFlumeSectionType(winFlumeCtrlSection)
            Me.XlateCtrlSection(mFlume)
            mFlume.FixLengths()
            mFlume.Section(cControl) = savFlumeCtrlSection
        Else
            mFlume.FixLengths()
        End If
    End Sub

    Public Sub HtoQ(ByVal SMALLh1!, ByRef Q!, ByRef QIdeal!, ByRef FroudeNumber!,
            ByRef TotalLoss!, ByRef H1!, ByRef UpstreamVelocity!, ByRef VelocityCoefficient!,
            ByRef AllowedTailwaterDepth!, ByRef ModularLimit!, ByRef ActualTWDepth!, ByRef ActualTWEGL!,
            ByRef Submergence!, ByRef ErrFound As Boolean, ByRef ErrArray() As Boolean)

        Dim ctrlSection As SectionType = mFlume.Section(cControl) ' reference to SectionType object
        If (ctrlSection.GetType Is GetType(WinFlumeSectionType)) Then ' translation required
            Dim winFlumeCtrlSection As WinFlumeSectionType = DirectCast(ctrlSection, WinFlumeSectionType)
            Dim savFlumeCtrlSection = New WinFlumeSectionType(winFlumeCtrlSection)
            Me.XlateCtrlSection(mFlume)
            mFlume.HtoQ(SMALLh1, Q, QIdeal, FroudeNumber, TotalLoss, H1, UpstreamVelocity,
                        VelocityCoefficient, AllowedTailwaterDepth, ModularLimit, ActualTWDepth,
                        ActualTWEGL, Submergence, ErrFound, ErrArray)
            mFlume.Section(cControl) = savFlumeCtrlSection
        Else
            mFlume.HtoQ(SMALLh1, Q, QIdeal, FroudeNumber, TotalLoss, H1, UpstreamVelocity,
                        VelocityCoefficient, AllowedTailwaterDepth, ModularLimit, ActualTWDepth,
                        ActualTWEGL, Submergence, ErrFound, ErrArray)
        End If
    End Sub

    Public Sub QtoH(ByVal Q!, ByRef ErrFound As Boolean, ByRef ErrArray() As Boolean,
             ByRef SMALLh1!, ByRef FroudeNumber!, ByRef TotalLoss!, ByRef H1!, ByRef UpstreamVelocity!,
             ByRef VelocityCoefficient!, ByRef AllowedTailwaterDepth!, ByRef ModularLimit!,
             ByRef ActualTWDepth!, ByRef ActualTWEGL!, ByRef Submergence!, ByRef U!, ByRef Yc!)

        Dim ctrlSection As SectionType = mFlume.Section(cControl) ' reference to SectionType object
        If (ctrlSection.GetType Is GetType(WinFlumeSectionType)) Then ' translation required
            Dim winFlumeCtrlSection As WinFlumeSectionType = DirectCast(ctrlSection, WinFlumeSectionType)
            Dim savFlumeCtrlSection = New WinFlumeSectionType(winFlumeCtrlSection)
            Me.XlateCtrlSection(mFlume)
            mFlume.QtoH(Q, ErrFound, ErrArray, SMALLh1, FroudeNumber, TotalLoss, H1, UpstreamVelocity,
                    VelocityCoefficient, AllowedTailwaterDepth, ModularLimit, ActualTWDepth, ActualTWEGL,
                    Submergence, U, Yc)
            mFlume.Section(cControl) = savFlumeCtrlSection
        Else
            mFlume.QtoH(Q, ErrFound, ErrArray, SMALLh1, FroudeNumber, TotalLoss, H1, UpstreamVelocity,
                    VelocityCoefficient, AllowedTailwaterDepth, ModularLimit, ActualTWDepth, ActualTWEGL,
                    Submergence, U, Yc)
        End If
    End Sub

#End Region

#Region " Utilities "

    '*********************************************************************************************************
    ' Function XlateCtrlSection() - translate WinFlume cross-section into Flume supported cross-section
    '*********************************************************************************************************
    Protected Sub XlateCtrlSection(ByVal WinFlumeType As FlumeType)
        '
        ' Ensure Control cross-section is one that is supported by Flume.dll
        '
        Dim ctrlSection As SectionType = WinFlumeType.Section(cControl) ' reference to SectionType object
        With ctrlSection
            '
            ' Define the Flume SectionType that will correctly support the WinFlumeSectionType calculations
            '
            ' NOTE - order of execution is important:
            '   e.g. - TopWidth depends on Shape of WinFlumeSectionType
            '
            Select Case (.Shape) ' of WinFlumeSectionType
                Case shSillInTrapezoid, shSillInVShaped
                    Dim TW As Single = .TopWidth(0, False)      ' Width of Sill of WinFlumeSectionType 
                    .BottomWidth = TW                           '  becomes Bottom Width of Flume's
                    .Shape = shSimpleTrapezoid                  '  Simple Trapezoid Shape

                Case shTrapezoidInTrapezoid, shTrapezoidInVShaped
                    .Shape = shSimpleTrapezoid

                Case shSillInRectangle, shRectangleInRectangle
                    .Shape = shRectangular

                Case shCircleInCircle
                    .Shape = shCircle

                Case shParabolaInParabola
                    .Shape = shParabola

                Case shUShapedInUShaped
                    .Shape = shUShaped

                Case shVShapedInVShaped
                    .Shape = shVShaped

                Case shTrapezoidInRectangle
                    .Shape = shComplexTrapezoid
            End Select
        End With
    End Sub

#End Region
End Class
