
'*****************************************************************************************************************
' Class:    ctl_TrapezoidTable overrides ctl_DataTableParameter to allow Trapezoid Table specific extensions
'
Imports DataStore
Imports DataStore.DataStore

Public Class ctl_TrapezoidTable
    Inherits ctl_DataTableParameter

#Region " Object References "

    Private mDictionary As Dictionary = Dictionary.Instance

    Protected mUnit As Unit
    Public mWinSRFR As WinSRFR
    Protected mSystemGeometry As SystemGeometry
    Public Property Unit() As Unit
        Get
            Return mUnit
        End Get
        Set(ByVal value As Unit)
            mUnit = value
            If (mUnit IsNot Nothing) Then
                mWinSRFR = mUnit.WorldRef.FieldRef.FarmRef.WinSrfrRef
                mSystemGeometry = mUnit.SystemGeometryRef
            Else
                mWinSRFR = Nothing
                mSystemGeometry = Nothing
            End If
        End Set
    End Property

#End Region

#Region " UI Event Handlers "

    Protected Sub TrapezoidRowContextMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles RowContextMenu.Popup

        RowContextMenu.MenuItems.Add("-")
        RowContextMenu.MenuItems.Add(mDictionary.tTrapezoidFromFieldData.Translated, _
                                     New EventHandler(AddressOf TrapezoidFromFieldData_Click))
    End Sub

    Protected Sub TrapezoidFromFieldData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles TrapezoidFromFieldData.Click (menu items are dynamically created by ...Menu_Popup()

        If (mUnit IsNot Nothing) Then
            Dim _furrowFieldData As FurrowFieldData = New FurrowFieldData(mUnit)

            ' Load dialog with values in current display units
            _furrowFieldData.TopSectionWidth = mSystemGeometry.TopSectionWidth.GetValue
            _furrowFieldData.MiddleSectionWidth = mSystemGeometry.MiddleSectionWidth.GetValue
            _furrowFieldData.BottomSectionWidth = mSystemGeometry.BottomSectionWidth.GetValue
            _furrowFieldData.SectionDepth = mSystemGeometry.SectionDepth.GetValue

            _furrowFieldData.ProfilometerTable = mSystemGeometry.ProfilometerTable.Value
            _furrowFieldData.NumberOfRods = mSystemGeometry.NoOfRods.Value
            _furrowFieldData.RodSpacing = mSystemGeometry.RodSpacing.GetValue

            _furrowFieldData.DepthWidthTable = mSystemGeometry.DepthWidthTable.Value

            _furrowFieldData.FurrowFieldDataType = CType(mSystemGeometry.FurrowFieldDataType.Value, FurrowFieldDataTypes)
            _furrowFieldData.FurrowShape = FurrowShapes.Trapezoid

            UpdateTranslation(_furrowFieldData, mWinSRFR.Language)

            ' Display dialog box to user
            Dim _dialogResult As DialogResult = _furrowFieldData.ShowDialog
            If (_dialogResult = DialogResult.OK) Then

                ' Get currently selected row
                Dim tableParameter As DataTableParameter = mProperty.GetDataTableParameter()
                Dim table As DataTable = tableParameter.Value
                Dim row As DataRow = table.Rows(mRowSelected)

                ' Update / save new row values
                row.Item(1) = SiValue(_furrowFieldData.TrapezoidBottomWidth, mUnitsSystem.DepthUnits)
                row.Item(2) = _furrowFieldData.TrapezoidSideSlope
                row.Item(3) = SiValue(_furrowFieldData.TrapezoidMaximumDepth, mUnitsSystem.DepthUnits)
                SaveDataTable(table, mDictionary.tTrapezoidFieldData.Translated)

                Dim _double As DoubleParameter = Nothing
                Dim _integer As IntegerParameter = Nothing
                Dim _table As DataTableParameter = Nothing

                ' Save the DB's Furrow Field Data Type
                _integer = mSystemGeometry.FurrowFieldDataType
                _integer.Value = _furrowFieldData.FurrowFieldDataType
                _integer.Source = ValueSources.UserEntered
                mSystemGeometry.FurrowFieldDataType = _integer

                ' Save the selected field type's data
                Select Case (_furrowFieldData.FurrowFieldDataType)

                    Case FurrowFieldDataTypes.WidthTable

                        _double = mSystemGeometry.TopSectionWidth
                        _double.SetValue(_furrowFieldData.TopSectionWidth)
                        _double.Source = ValueSources.UserEntered
                        mSystemGeometry.TopSectionWidth = _double

                        _double = mSystemGeometry.MiddleSectionWidth
                        _double.SetValue(_furrowFieldData.MiddleSectionWidth)
                        _double.Source = ValueSources.UserEntered
                        mSystemGeometry.MiddleSectionWidth = _double

                        _double = mSystemGeometry.BottomSectionWidth
                        _double.SetValue(_furrowFieldData.BottomSectionWidth)
                        _double.Source = ValueSources.UserEntered
                        mSystemGeometry.BottomSectionWidth = _double

                        _double = mSystemGeometry.SectionDepth
                        _double.SetValue(_furrowFieldData.SectionDepth)
                        _double.Source = ValueSources.UserEntered
                        mSystemGeometry.SectionDepth = _double

                    Case FurrowFieldDataTypes.ProfilometerTable

                        _table = mSystemGeometry.ProfilometerTable
                        _table.Value = _furrowFieldData.ProfilometerTable
                        _table.Source = ValueSources.UserEntered
                        mSystemGeometry.ProfilometerTable = _table

                        _integer = mSystemGeometry.NoOfRods
                        _integer.Value = _furrowFieldData.NumberOfRods
                        _integer.Source = ValueSources.UserEntered
                        mSystemGeometry.NoOfRods = _integer

                        _double = mSystemGeometry.RodSpacing
                        _double.SetValue(_furrowFieldData.RodSpacing)
                        _double.Source = ValueSources.UserEntered
                        mSystemGeometry.RodSpacing = _double

                    Case FurrowFieldDataTypes.DepthWidthTable

                        _table = mSystemGeometry.DepthWidthTable
                        _table.Value = _furrowFieldData.DepthWidthTable
                        _table.Source = ValueSources.UserEntered
                        mSystemGeometry.DepthWidthTable = _table

                End Select

            End If
        End If

    End Sub

#End Region

End Class
