
'*************************************************************************************************************
' Class ctl_HydrusTableParameter - special ctl_DataTableParameter for HYDRUS projects
'*************************************************************************************************************
Imports DataStore
Imports System.Runtime.Serialization

<Serializable()> _
Public Class ctl_HydrusTableParameter
    Inherits ctl_DataTableParameter

    Public mDictionary As Dictionary = Dictionary.Instance

    Protected Overrides Sub AdjustColumnWidths()

        ' Adjust the DataGrid's column widths to fill the available parent space
        mAdjustingColumnSizes = True

        If (mTableStyle.GridColumnStyles.Count = 2) Then

            Dim _clientWidth As Integer = ClientWidth()
            Dim _distWidth As Integer = 70
            Dim _columnStyle As DataGridTextBoxColumn

            _columnStyle = mTableStyle.GridColumnStyles(0)
            _columnStyle.Width = _distWidth

            _columnStyle = mTableStyle.GridColumnStyles(1)
            _columnStyle.Width = _clientWidth - _distWidth

        End If

        mAdjustingColumnSizes = False

    End Sub

    Public Overrides Sub EditMenu_Popup(ByVal _editMenuItem As MenuItem)
        MyBase.EditMenu_Popup(_editMenuItem)

        _editMenuItem.MenuItems.Add("-")
        _editMenuItem.MenuItems.Add(mDictionary.tBrowseForProject.Translated, New EventHandler(AddressOf BrowseForProject_Click))
    End Sub

    Protected Overrides Sub RowContextMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.RowContextMenu_Popup(sender, e)

        RowContextMenu.MenuItems.Add("-")
        RowContextMenu.MenuItems.Add(mDictionary.tBrowseForProject.Translated, New EventHandler(AddressOf BrowseForProject_Click))
    End Sub

    Protected Sub BrowseForProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles BrowseForProject.Click (menu items are dynamically created by ...Menu_Popup()

        ' Get currently selected row's HYDRUS project folder
        Dim tableParameter As DataTableParameter = mProperty.GetDataTableParameter()
        Dim hydrusTable As DataTable = tableParameter.Value
        Dim hydrusRow As DataRow = hydrusTable.Rows(mRowSelected)
        Dim hydrusPath As String = hydrusRow.Item(1)

        ' If none specified, or it's default, use WinSRFR project folder, if any
        If ((hydrusPath = "") Or (hydrusPath.Contains(DefaultHydrusRowFilename))) Then
            hydrusPath = WinSRFR.FilePath
            Dim lastBackslash As Integer = hydrusPath.LastIndexOf("\")
            If (0 < lastBackslash) Then
                hydrusPath = hydrusPath.Substring(0, lastBackslash)
            Else
                hydrusPath = ""
            End If
        End If

        ' Create/initialize FolderBrowserDialog so user can choose HYDRUS Project folder
        Dim browser As FolderBrowserDialog = New FolderBrowserDialog
        browser.SelectedPath = hydrusPath

        ' Show browser dialog and get user's response
        Dim result As DialogResult = browser.ShowDialog

        ' Check if HYDRUS project folder was selected
        If (result = DialogResult.OK) Then
            hydrusRow.Item(1) = browser.SelectedPath
            SaveDataTable(hydrusTable, mDictionary.tHydrusProjectChange.Translated)
        End If

    End Sub

End Class
