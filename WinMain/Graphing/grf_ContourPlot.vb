
'**********************************************************************************************
' grf_ContourPlot provides enhanced graphics support for drawing Contour Plots.
'
' The graph is drawn as a Bitmap.
'
Imports DataStore
Imports DataStore.DataStore
Imports GraphingUI

Public Class grf_ContourPlot
    Inherits ctl_Contour2D

#Region " Member Data "
    '
    ' Reference to World Window presenting the contours
    '
    Private mWorldWindow As WorldWindow

    Private mDictionary As Dictionary = Dictionary.Instance

#End Region

#Region " Contructor(s) "

    Public Sub New(ByVal worldWindow As WorldWindow, _
                   ByVal contourParameter As ContourParameter, _
                   ByVal parameterName As String, _
                   ByVal parameterIndex As Integer)
        MyBase.New(contourParameter, parameterName, parameterIndex)

        mWorldWindow = worldWindow

        Me.FontName = WinSRFR.UserPreferences.SelectedFont
        Me.FontAdjustment = WinSRFR.UserPreferences.FontAdjustment

    End Sub

#End Region

#Region " UI Event Handlers "

#Region " Mouse Events "

    Protected Overrides Sub PictureBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        ' Handles MyBase.PictureBox_MouseMove

        ' Get reference to the contour graph
        Dim _countourPlot As grf_ContourPlot = DirectCast(sender, grf_ContourPlot)

        Try
            ' Don't bother handling mouse event if graph is not visible
            If (_countourPlot.Visible) Then
                Dim name As String = _countourPlot.ParameterName
                Dim rect As Rectangle = _countourPlot.ContourRect
                Dim grid As ContourGrid = _countourPlot.ContourGrid

                ' Is mouse within the contour plot?
                If (rect.Contains(e.X, e.Y)) Then

                    ' Get cursor position within contour rectangle
                    Dim xCursor As Integer = e.X - rect.X
                    Dim yCursor As Integer = rect.Y + rect.Height - e.Y

                    ' Convert position to SI data values
                    Dim x As Double = mMinX + ((mMaxX - mMinX) * xCursor) / rect.Width
                    Dim y As Double = mMinY + ((mMaxY - mMinY) * yCursor) / rect.Height

                    ' Make sure calculated values are still within contour rectangle
                    If ((x < mMinX) Or (mMaxX < x)) Then
                        Debug.Assert(False)
                        Exit Try
                    End If

                    If ((y < mMinY) Or (mMaxY < y)) Then
                        Debug.Assert(False)
                        Exit Try
                    End If

                    If ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then
                        '
                        ' Shift-mouse selects convas objects in baseclass
                        '
                        Exit Try
                    ElseIf ((Control.ModifierKeys And Keys.Control) = Keys.Control) Then
                        '
                        ' Ctrl-mouse redraws Water Distribution Diagram if it is being displayed
                        '
                        If (mWorldWindow.WDD IsNot Nothing) Then
                            ' Turn off tooltip
                            _countourPlot.ToolTip.Active = False
                            ' Graph Water Distribution Diagram
                            mWorldWindow.WDD.SetXY(x, y)
                        End If

                        ' Show cursor
                        _countourPlot.Cursor = Cursors.Cross

                        ' Mouse event handled here; don't pass it on
                        Return
                    Else
                        '
                        ' Standard mouse move displays position tooltip
                        '
                        ' Convert position SI values to display values
                        Dim xUnits As Units = grid.Point(0, 0).X.DisplayUnits
                        Dim yUnits As Units = grid.Point(0, 0).Y.DisplayUnits

                        Dim xText As String = UnitTextWithUnits(x, xUnits)
                        Dim yText As String = UnitTextWithUnits(y, yUnits)

                        ' Build basic tooltip; i.e. no value just position
                        Dim toolTip As String = grid.ColName + " = " + xText + Chr(10) _
                                              + grid.RowName + " = " + yText

                        ' Get & display parameter value; there may not be a value to display
                        Dim idx As Integer = grid.ValueIndex(name)
                        If (0 <= idx) Then

                            ' Get SI parameter value
                            Dim _analysis As Analysis = mWorldWindow.CurrentAnalysis
                            If (_analysis IsNot Nothing) Then
                                Dim _unit As Unit = _analysis.Unit
                                Dim _systemGeometry As SystemGeometry = _unit.SystemGeometryRef
                                Dim _borderCriteria As BorderCriteria = _unit.BorderCriteriaRef

                                ' Get the Contour Point at the mouse position
                                Dim _contourPoint As ContourPoint = _analysis.GetContourPoint(x, y, NumWddPoints)
                                If (_contourPoint IsNot Nothing) Then
                                    ' Display the Contour's value if it exists
                                    If (idx < _contourPoint.Z.Count) Then

                                        ' Get the Z parameter for this contour; idx selects Z parameter
                                        Dim z As SingleParameter = DirectCast(_contourPoint.Z(idx), SingleParameter)
                                        Dim zValue As Single = z.Value
                                        Dim zUnits As Units = z.Units

                                        ' Convert SI value to display value
                                        zUnits = mUnitsSystem.DisplayUnits(zUnits)
                                        Dim zText As String = UnitTextWithUnits(zValue, zUnits)

                                        ' Add value to position tooltip
                                        toolTip += Chr(10) + name + " = " + zText

                                        ' Add error/warning message, if one exists; error has priority
                                        If (_contourPoint.HasError) Then
                                            toolTip += "**"
                                            toolTip += Chr(10) + " **" + _contourPoint.ErrMsg
                                        ElseIf (_contourPoint.HasWarning) Then
                                            toolTip += "*"
                                            toolTip += Chr(10) + " *" + _contourPoint.WarnMsg
                                        End If

                                    End If ' Z Parameter exists for this contour
                                End If ' Contour Point was calculated
                            End If ' Analysis exists
                        End If ' Parameter is available

                        ' Show cursor
                        _countourPlot.Cursor = Cursors.Cross

                        ' Show tooltip
                        _countourPlot.ToolTip.Active = True
                        _countourPlot.ToolTip.ShowAlways = True
                        _countourPlot.ToolTip.SetToolTip(_countourPlot, toolTip)

                        ' Mouse event handled here; don't pass it on
                        Return
                    End If
                End If ' Mouse is within contour rectangle

                ' Outside contour plot, turn tooltip off
                _countourPlot.ToolTip.Active = False
            End If

        Catch ex As Exception
        End Try

        ' If not handled here, let the base class
        MyBase.PictureBox_MouseMove(sender, e)

    End Sub

    Protected Sub ChooseSolution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles ChooseSolution.Click (menu items are dynamically created by PictureBoxMenu_Popup()

        ' Mouse position within contour graph
        Dim xPos As Integer = mMousePoint.X - mContourRect.X
        Dim yPos As Integer = mContourRect.Y + mContourRect.Height - mMousePoint.Y

        ' Mouse value within contour graph
        Dim xVal As Double = mMinX + ((mMaxX - mMinX) * xPos) / mContourRect.Width
        Dim yVal As Double = mMinY + ((mMaxY - mMinY) * yPos) / mContourRect.Height

        ' Use the Water Distribution Diagram to choose the Solution
        If (mWorldWindow.WDD IsNot Nothing) Then
            mWorldWindow.WDD.Dispose()
            mWorldWindow.WDD = Nothing
        End If

        mWorldWindow.WDD = New WaterDistributionDiagram(mWorldWindow, xVal, yVal)
        UpdateTranslation(mWorldWindow.WDD, mWorldWindow.WinSrfr.Language)
        mWorldWindow.WDD.Show()

    End Sub

    Protected Overrides Sub PictureBoxMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Handles MyBase.PictureBoxMenu_Popup

        ' Have base case start popup
        MyBase.PictureBoxMenu_Popup(sender, e)

        ' Add popup menu items
        If Not (Me.Image Is Nothing) Then
            PictureBoxMenu.MenuItems.Add("-")   ' Separator
            PictureBoxMenu.MenuItems.Add(mDictionary.tChooseSolutionAtPoint.Translated & "...", _
                                          New EventHandler(AddressOf ChooseSolution_Click))
        End If

    End Sub

#End Region

#End Region

End Class
