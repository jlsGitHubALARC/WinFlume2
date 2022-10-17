
'*************************************************************************************************************
' Class WinFlumeDesign - subclass of the Flume.Design class to support added UI cross-sections
'*************************************************************************************************************
Imports Flume

Public Class WinFlumeDesign
    Inherits Flume.Design

    '*********************************************************************************************************
    ' Overrides of Flume.Design functions that morph a new WinFlume cross-section to a Flume supported
    ' cross-section prior to calling the baseclass method
    '*********************************************************************************************************

#Region " Flume Design API "

    '*********************************************************************************************************
    ' Overrides of Design Review functions that morph a new WinFlume cross-section to a Flume supported
    ' cross-section prior to calling the baseclass method
    '
    ' These functions create the various text-based design reviews for displaying on the UI
    '*********************************************************************************************************
    Public Overrides Function VeryBriefDesignReview(ThisFlume As FlumeType, DesignResult As DesignResultType,
                                     BooleanCriteria() As Boolean, ByRef HeadlossComment As String) As String
        Dim ToFlumeType As FlumeType = Me.ToFlumeType(ThisFlume)
        Return MyBase.VeryBriefDesignReview(ToFlumeType, DesignResult, BooleanCriteria, HeadlossComment)
    End Function

    Public Overrides Function BriefDesignReview(ThisFlume As FlumeType, DesignResult As DesignResultType,
                                     BooleanCriteria() As Boolean, ByRef HeadlossComment As String) As String
        Dim ToFlumeType As FlumeType = Me.ToFlumeType(ThisFlume)
        Return MyBase.BriefDesignReview(ToFlumeType, DesignResult, BooleanCriteria, HeadlossComment)
    End Function

    Public Overrides Function DesignReview1of3(ThisFlume As FlumeType, ProgVersion As String) As String
        Dim ToFlumeType As FlumeType = Me.ToFlumeType(ThisFlume)
        Return MyBase.DesignReview1of3(ToFlumeType, ProgVersion)
    End Function

    Public Overrides Function DesignReview2of3(ThisFlume As FlumeType, ProgVersion As String) As String
        Dim ToFlumeType As FlumeType = Me.ToFlumeType(ThisFlume)
        Return MyBase.DesignReview2of3(ToFlumeType, ProgVersion)
    End Function

    Public Overrides Function DesignReview3of3(ThisFlume As FlumeType, ProgVersion As String) As String
        Dim ToFlumeType As FlumeType = Me.ToFlumeType(ThisFlume)
        Return MyBase.DesignReview3of3(ToFlumeType, ProgVersion)
    End Function

    '*********************************************************************************************************
    ' Sub EvaluateDesigns() - generates the table of alternative designs then validates they meet the perhaps
    '                         more restrictive UI limits
    '*********************************************************************************************************
    Public Overrides Sub EvaluateDesigns(WorkingFlume As FlumeType, ByRef NumGood As Integer,
                                         ByRef DesignStillPossible As Boolean, ByRef UserCanceled As Boolean)
        Dim ToFlumeType As FlumeType = Me.ToFlumeType(WorkingFlume)
        MyBase.EvaluateDesigns(ToFlumeType, NumGood, DesignStillPossible, UserCanceled)

        ' When the Control Section is 'matched' with the Approach Channel, the list of alternative designs
        ' must be validated against the Approach Channel cross-section
        Dim ctrlSection As SectionType = WorkingFlume.Section(cControl)
        If (ctrlSection.GetType Is GetType(WinFlumeSectionType)) Then
            Me.ValidateDesigns(ToFlumeType, NumGood, DesignStillPossible, UserCanceled)
        End If
    End Sub

#End Region

#Region " ToFlumeType "

    '*********************************************************************************************************
    ' Function ToFlumeType() - morph WinFlume cross-section into Flume supported cross-section
    '
    ' Note - this function serves two purposes:
    '   1) substitute the corresponding Flume supported cross-section for the new WinFlume cross-section
    '           shSillInTrapezoid, shSillInVShaped, shTrapezoidInTrapezoid, shTrapezoidInVShaped
    '               use shSimpleTrapezoid
    '           shSillInRectangle, shRectangleInRectangle
    '               use shRectangular
    '           shTrapezoidInRectangle
    '               use shComplexTrapezoid
    '           shCircleInCircle, shParabolaInParabola, shUShapedInUShape, shVShapedInVShape
    '               use base shape
    '   2) correct/exchange invalid contraction method selections
    '*********************************************************************************************************
    Protected Function ToFlumeType(ByVal WinFlumeType As FlumeType) As FlumeType

        ' Instantiate new FlumeType from input WinFlumeType
        ToFlumeType = New FlumeType(WinFlumeType)
        '
        ' Ensure Control cross-section is one that is supported by Flume.dll
        '
        Dim TW As Single
        Dim ctrlSection As SectionType = ToFlumeType.Section(cControl)
        With ctrlSection
            '
            ' Set the Flume SectionType that will correctly support the WinFlumeSectionType calculations
            '
            ' NOTE - execution order is important (e.g. - TopWidth depends on Shape of WinFlumeSectionType):
            '
            Select Case (.Shape) ' of WinFlumeSectionType
                Case shSillInTrapezoid, shSillInVShaped
                    TW = .TopWidth(0, False)    ' Width of Sill of WinFlumeSectionType 
                    .BottomWidth = TW           '  becomes Bottom Width of Flume's
                    .Shape = shSimpleTrapezoid  '  Simple Trapezoid Shape

                    ToFlumeType.ContractionAdjustment = RaiseSillHeight

                Case shTrapezoidInTrapezoid, shTrapezoidInVShaped
                    .Shape = shSimpleTrapezoid

                    If (ToFlumeType.ContractionAdjustment = RaiseLowerInnerSection) Then ' exchange
                        ToFlumeType.ContractionAdjustment = RaiseLowerEntireSection
                    End If

                Case shSillInRectangle
                    .Shape = shRectangular

                    ToFlumeType.ContractionAdjustment = RaiseSillHeight

                Case shRectangleInRectangle
                    .Shape = shRectangular

                    If (ToFlumeType.ContractionAdjustment = RaiseSillHeight) _
                    Or (ToFlumeType.ContractionAdjustment = RaiseLowerInnerSection) Then ' exchange
                        ToFlumeType.ContractionAdjustment = RaiseLowerEntireSection
                    End If

                Case shSimpleTrapezoid, shRectangular, shCircle, shUShaped, shParabola

                    If (ToFlumeType.ContractionAdjustment = RaiseLowerInnerSection) Then ' exchange
                        ToFlumeType.ContractionAdjustment = RaiseLowerEntireSection
                    End If

                Case shVShaped

                    If (ToFlumeType.ContractionAdjustment = VarySideContraction) _
                    Or (ToFlumeType.ContractionAdjustment = RaiseLowerInnerSection) Then ' exchange
                        ToFlumeType.ContractionAdjustment = RaiseLowerEntireSection
                    End If

                Case shCircleInCircle
                    .Shape = shCircle

                    If (ToFlumeType.ContractionAdjustment = RaiseLowerInnerSection) Then ' exchange
                        ToFlumeType.ContractionAdjustment = RaiseLowerEntireSection
                    End If

                Case shParabolaInParabola
                    .Shape = shParabola

                    If (ToFlumeType.ContractionAdjustment = RaiseLowerInnerSection) Then ' exchange
                        ToFlumeType.ContractionAdjustment = RaiseLowerEntireSection
                    End If

                Case shUShapedInUShaped
                    .Shape = shUShaped

                    If (ToFlumeType.ContractionAdjustment = RaiseLowerInnerSection) Then ' exchange
                        ToFlumeType.ContractionAdjustment = RaiseLowerEntireSection
                    End If

                Case shVShapedInVShaped
                    .Shape = shVShaped

                    If (ToFlumeType.ContractionAdjustment = RaiseLowerInnerSection) Then ' exchange
                        ToFlumeType.ContractionAdjustment = RaiseLowerEntireSection
                    End If

                Case shTrapezoidInRectangle
                    .Shape = shComplexTrapezoid

            End Select
        End With

    End Function

#End Region

#Region " Validate Designs "

    '*********************************************************************************************************
    ' Sub ValidateDesigns() - validate alternative designs fit within Approach Channel
    '
    ' Removes all alternative designs from EvaluationFlumes that do not meet the 'matching' constraints. If none
    ' are left, a message is displayed to the user.
    '*********************************************************************************************************
    Protected Sub ValidateDesigns(ByVal ToFlumeType As FlumeType, ByRef NumGood As Integer,
                                  ByRef DesignStillPossible As Boolean, ByRef UserCanceled As Boolean)

        Dim apprChannel As SectionType = ToFlumeType.Section(cApproach)

        ' Get canal properties
        Dim chanDepth As Single = ToFlumeType.ChannelDepth

        ' Get cross-section dimensions from Approach Channel
        Dim apprDiam As Single = apprChannel.DiameterFocalD
        Dim apprFocalDist As Single = apprChannel.DiameterFocalD
        Dim apprTopWidth As Single = apprChannel.TopWidth(chanDepth, False)
        
        ' Convert Evaluation Flumes array to a List for easier manipulation
        Dim flumeList As List(Of FlumeType) = EvaluationFlumes.ToList

        ' Scan list of flumes and remove those that extend beyond the Approach Channel
        Dim N As Integer = flumeList.Count
        While (1 < N)

            Dim flumeRemoved As Boolean = False
            For ftx As Integer = 1 To N - 1
                ' Get next Control Section design to check
                Dim sillHeight As Single = flumeList(ftx).SillHeight
                Dim ctrlSection As SectionType = flumeList(ftx).Section(cControl)
                ' Get cross-section dismenstion from Control Section
                Dim ctrlDiam As Single = ctrlSection.DiameterFocalD
                Dim ctrlFocalDist As Single = ctrlSection.DiameterFocalD
                Dim ctrlTopWidth As Single = ctrlSection.TopWidth(chanDepth - sillHeight, False)

                ' Criteria to check is cross-section dependent
                Select Case ToFlumeType.Section(cControl).Shape
                    Case shCircle, shCircleInCircle,
                         shUShaped, shUShapedInUShaped
                        If (apprDiam < ctrlDiam) Then
                            flumeList.RemoveAt(ftx)
                            flumeRemoved = True
                            Exit For
                        End If
                    Case shParabola, shParabolaInParabola
                        If (apprFocalDist < ctrlFocalDist) Then
                            flumeList.RemoveAt(ftx)
                            flumeRemoved = True
                            Exit For
                        End If
                    Case shRectangular, shRectangleInRectangle, shTrapezoidInRectangle,
                         shSimpleTrapezoid, shTrapezoidInTrapezoid, shTrapezoidInVShaped
                        If (apprTopWidth < ctrlTopWidth) Then
                            flumeList.RemoveAt(ftx)
                            flumeRemoved = True
                            Exit For
                        End If
                End Select
            Next ftx

            If Not (flumeRemoved) Then ' nothing removed; the rest are ok
                Exit While
            End If
            N = flumeList.Count
        End While ' (1 < N)

        Debug.Assert(1 <= N)

        If (N <= 1) Then ' no valid Flumes remain in list; let user know
            Dim msg As String = My.Resources.NoAlternativeDesignsFound & vbCrLf & vbCrLf
            msg &= My.Resources.ControlSection & " "

            Select Case ToFlumeType.Section(cControl).Shape
                Case shCircle, shCircleInCircle, shUShaped, shUShapedInUShaped
                    msg &= My.Resources.Diameter & " <= " & My.Resources.ApproachChannel & " "
                    msg &= My.Resources.Diameter & " (" & apprDiam.ToString & ")"
                Case shParabola, shParabolaInParabola
                    msg &= My.Resources.FocalDistance & " <= " & My.Resources.ApproachChannel & " "
                    msg &= My.Resources.FocalDistance & " (" & apprFocalDist.ToString & ")"
                Case shRectangular, shRectangleInRectangle, shSimpleTrapezoid, shTrapezoidInTrapezoid
                    msg &= My.Resources.TopWidth & " <= " & My.Resources.ApproachChannel & " "
                    msg &= My.Resources.TopWidth & " (" & apprTopWidth.ToString & ")"
            End Select

            Dim result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.OkOnly, My.Resources.AlternativeDesigns)
        End If

        ' Convert Flume List back to Evaluation Flumes array
        EvaluationFlumes = flumeList.ToArray

    End Sub

#End Region

End Class
