
'*************************************************************************************************************
' ControlViewerDialog - Dialog for viewing a User Control.
'*************************************************************************************************************
Public Class ControlViewerDialog

#Region " Member Data "
    '
    ' Popup What's This? help
    '
    Private mWhatsThisHelp As Boolean = False
    Private mOldCursor As Cursor = Nothing
    Private mHelpPopup As Windows.Forms.RichTextBox = Nothing
    '
    ' Help & Manual
    '
    Private WithEvents mPdfViewer As PdfViewerDialog = Nothing
    '
    ' Menus
    '
    Private mCopyGraphDataText As String
    Private mSaveGraphDataText As String
    Private mCopyGraphImageText As String
    Private mSaveGraphImageText As String
    Private mCopyTableDataText As String
    Private mSaveTableDataText As String

#End Region

#Region " Constructor(s) "

    Public Sub New(ByVal UserCtrl As UserControl)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SuspendLayout()
        Me.ViewerPanel.SuspendLayout()
        Me.ViewerPanel.Controls.Add(UserCtrl)
        UserCtrl.Dock = DockStyle.Fill
        Me.ViewerPanel.ResumeLayout()
        Me.ResumeLayout()

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

        Return Nothing

    End Function

#End Region

#Region " ctl_Graph2D "
    '
    ' Search the specified control and all its sub-controls for ctl_Graph2D.
    '
    ' Add all visible ctl_Graph2D to the specified menu.
    '
    Public Sub AddGraph2DCopyItems(ByVal Graph2DMenuItem As ToolStripMenuItem,
                                   ByVal SearchControl As Control)

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
    Public Function FindCtlGraph2D(ByVal Graph2DName As String,
                                   ByVal SearchControl As Control) As ctl_Graph2D

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

        Return Nothing

    End Function

#End Region

#Region " ctl_DataGridView "
    '
    ' Search the specified control and all its sub-controls for ctl_DataGridView.
    '
    ' Add all visible ctl_DataGridView to the specified menu.
    '
    Public Sub AddTableDataCopyItems(ByVal DataGridViewMenuItem As ToolStripMenuItem,
                                     ByVal SearchControl As Control)

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

    End Sub
    '
    ' Copy Data from ctl_DataGridView to Clipboard
    '
    Private Sub CopyTableData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Handles CopyTableData.Click (menu items are dynamically created by AddTableDataCopyItems()

        Debug.Assert(sender.GetType Is GetType(ToolStripMenuItem))

        ' Get ctl_DataGridView associated with menu item
        Dim ctlDataGridView As ctl_DataGridView = FindCtlDataGridView(mCopyTableDataText, Me)
        If (ctlDataGridView IsNot Nothing) Then ' copy graph data to Clipboard
            ctlDataGridView.CopyToClipboard()
        End If
    End Sub
    '
    ' Search the specified control and all its sub-controls for ctl_DataGridView.
    '
    ' Add all visible ctl_DataGridView to the specified menu.
    '
    Private Sub AddTableDataSaveItems(ByVal DataGridViewMenuItem As ToolStripMenuItem,
                                      ByVal SearchControl As Control)

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
    Public Function FindCtlDataGridView(ByVal DataGridViewName As String,
                                        ByVal SearchControl As Control) As ctl_DataGridView

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

        Return Nothing

    End Function

#End Region

#End Region

#Region " Event Handlers "

#Region " Dialog Controls "

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region " File Menu "

    Private Sub FileMenu_DropDownOpening(sender As Object, e As EventArgs) _
        Handles FileMenu.DropDownOpening

        Me.FileExportGraphImageItem.DropDownItems.Clear()
        AddPictureBoxSaveItems(Me.FileExportGraphImageItem, Me)
        Me.FileExportGraphImageItem.Enabled = 0 < Me.FileExportGraphImageItem.DropDownItems.Count

        Me.FileExportTableDataItem.DropDownItems.Clear()
        AddTableDataSaveItems(Me.FileExportTableDataItem, Me)
        Me.FileExportTableDataItem.Enabled = 0 < Me.FileExportTableDataItem.DropDownItems.Count

    End Sub

    Private Sub FileCloseItem_Click(sender As Object, e As EventArgs) _
        Handles FileCloseItem.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FileExitItem_Click(sender As Object, e As EventArgs) _
        Handles FileExitItem.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

#End Region

#Region " Edit Menu "

    Private Sub EditMenu_DropDownOpening(sender As Object, e As EventArgs) _
        Handles EditMenu.DropDownOpening

        Me.EditCopyGraphBtimapItem.DropDownItems.Clear()
        AddPictureBoxCopyItems(Me.EditCopyGraphBtimapItem, Me)
        Me.EditCopyGraphBtimapItem.Enabled = 0 < Me.EditCopyGraphBtimapItem.DropDownItems.Count

        Me.EditCopyGraphDataItem.DropDownItems.Clear()
        AddGraph2DCopyItems(Me.EditCopyGraphDataItem, Me)
        Me.EditCopyGraphDataItem.Enabled = 0 < Me.EditCopyGraphDataItem.DropDownItems.Count

        Me.EditCopyTableDataItem.DropDownItems.Clear()
        AddTableDataCopyItems(Me.EditCopyTableDataItem, Me)
        Me.EditCopyTableDataItem.Enabled = 0 < Me.EditCopyTableDataItem.DropDownItems.Count
    End Sub

#End Region

#End Region

End Class
