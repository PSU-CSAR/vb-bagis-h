Imports BAGIS_ClassLibrary
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesGDB
Imports System.ComponentModel
Imports System.IO
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.DataManagementTools
Imports ESRI.ArcGIS.esriSystem
'Imports System.IO.Packaging

Module ArchiveModule

    Public Function BA_CopyAOIForExport(ByVal aoiFolder As String) As BA_ReturnCode
        '// Do we need to archive params folder? methods?
        '8. Create param/methods folder
        '9. Copy param/methods/*.xml to new param/methods folder

        '15. BA_ZipFile
    End Function

    Public Function BA_ZipHrus(ByVal aoiFolder As String, ByVal archive As IZipArchive) As BA_ReturnCode
        Dim zonesDirectory As String = aoiFolder & BA_EnumDescription(PublicPath.HruDirectory)
        Dim dirZones As New DirectoryInfo(zonesDirectory)
        Dim dirZonesArr As DirectoryInfo() = Nothing
        Dim zoneCount As Integer
        If dirZones.Exists Then
            dirZonesArr = dirZones.GetDirectories
            If dirZonesArr IsNot Nothing Then zoneCount = dirZonesArr.Length
        End If
        Dim wsf As IWorkspaceFactory2 = New FileGDBWorkspaceFactory
        Try
            If dirZonesArr IsNot Nothing Then
                For Each dri In dirZonesArr
                    '1. Create _hruGDB
                    '2. Copy files to new .gdb (including param.gdb)
                    Dim hruFolder As String = BA_GetHruPath(aoiFolder, PublicPath.HruDirectory, dri.Name)
                    Dim tempGdbName As String = "_" & dri.Name & ".gdb"
                    Dim success As BA_ReturnCode = BA_CreateFileGdb(hruFolder, tempGdbName)
                    If success = BA_ReturnCode.Success Then
                        Dim targetGDB As String = hruFolder & "\" & tempGdbName
                        Dim sourceGDB As String = BA_GetHruPathGDB(aoiFolder, PublicPath.HruDirectory, dri.Name)
                        Dim hruFilePath As String = sourceGDB & BA_EnumDescription(PublicPath.HruGrid)
                        Dim hruXmlFilePath As String = BA_GetHruPath(aoiFolder, PublicPath.HruDirectory, dri.Name) & BA_EnumDescription(PublicPath.HruXml)
                        ' Add hru to the list if the grid exists
                        If BA_File_Exists(hruFilePath, WorkspaceType.Geodatabase, esriDatasetType.esriDTRasterDataset) And _
                           BA_File_ExistsWindowsIO(hruXmlFilePath) Then
                            'grid
                            success = BA_Copy(hruFilePath, targetGDB & BA_EnumDescription(PublicPath.HruGrid))
                            'grid_v
                            If BA_File_Exists(sourceGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruVector), False, True), WorkspaceType.Geodatabase, esriDatasetType.esriDTFeatureClass) Then
                                success = BA_CopyFeatures(sourceGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruVector), False, True), targetGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruVector), False, True))
                            End If
                            'grid_zones_v
                            If BA_File_Exists(sourceGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruZonesVector), False, True), WorkspaceType.Geodatabase, esriDatasetType.esriDTFeatureClass) Then
                                success = BA_CopyFeatures(sourceGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruZonesVector), False, True), targetGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruZonesVector), False, True))
                            End If
                            'Add _hru.gdb with 3 files to archive
                            Dim hruFiles As String() = Directory.GetFiles(targetGDB)
                            For Each nFile As String In hruFiles
                                'Debug.Print("Adding file " & nFile)
                                archive.AddFile(nFile)
                            Next
                            'Delete _hru.gdb
                            success = BA_Remove_WorkspaceGP(targetGDB)
                            'log.xml
                            archive.AddFile(hruXmlFilePath)
                            'Checks first to see if param.gdb exists
                            Dim paramGdbPath As String = BA_GetHruPath(aoiFolder, PublicPath.HruDirectory, dri.Name) & BA_EnumDescription(PublicPath.BagisParamGdb)
                            If wsf.IsWorkspace(paramGdbPath) Then
                                Dim files As String() = Directory.GetFiles(paramGdbPath)
                                For Each nFile As String In files
                                    'Debug.Print("Adding file " & nFile)
                                    archive.AddFile(nFile)
                                Next
                            End If
                        End If
                    End If
                Next dri
            End If
            Return BA_ReturnCode.Success
        Catch ex As Exception
            Debug.Print("BA_ZipHrus Exception: " + ex.Message)
            Return BA_ReturnCode.UnknownError
        Finally

        End Try
    End Function

    Public Function BA_ZipGeodatabases(ByVal sourceFolder As String, ByVal archive As IZipArchive) As BA_ReturnCode
 
        Try
            For Each pName In [Enum].GetValues(GetType(GeodatabaseNames))
                Dim EnumConstant As [Enum] = pName
                Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
                Dim aattr() As DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
                Dim gdbName As String = aattr(0).Description
                Dim files As String() = Directory.GetFiles(sourceFolder & "\" & gdbName)
                For Each nFile As String In files
                    'Debug.Print("Adding file " & nFile)
                    archive.AddFile(nFile)
                Next
            Next
            Return BA_ReturnCode.Success
        Catch ex As Exception
            Debug.Print("BA_ZipGeodatabases exception" & ex.Message)
            Return BA_ReturnCode.UnknownError
        End Try
    End Function

    Public Function BA_ZipMiscFiles(ByVal sourceFolder As String, ByVal archive As IZipArchive) As BA_ReturnCode
        'aoi_streams.shp
        Dim success As BA_ReturnCode = BA_ZipShapefile(sourceFolder & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.AoiStreamsVector), True, True), archive)
        If success <> BA_ReturnCode.Success Then
            Dim strMessage As String = "One or more components were missing from " & vbCrLf
            strMessage = strMessage & sourceFolder & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.AoiStreamsVector), True, True) & vbCrLf
            strMessage = strMessage & "The file may not be uploaded correctly. The .shp, .shx, .prj, and .dbf files should all be present."
            Windows.Forms.MessageBox.Show(strMessage, "Missing files", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
        End If
        Dim mapsDir As String = sourceFolder & BA_EnumDescription(PublicPath.Maps)
        If System.IO.Directory.Exists(mapsDir) Then
            If System.IO.File.Exists(mapsDir & BA_EnumDescription(PublicPath.AnalysisXml)) Then
                archive.AddFile(mapsDir & BA_EnumDescription(PublicPath.AnalysisXml))
            End If
            If System.IO.File.Exists(mapsDir & BA_EnumDescription(PublicPath.MapParameters)) Then
                archive.AddFile(mapsDir & BA_EnumDescription(PublicPath.MapParameters))
            End If
        End If
        '@ToDo: We may or may not need to create the /aoi/param folder depending on if we archive the methods folder
    End Function

    Public Function BA_ZipShapefile(ByVal shapefilePath As String, ByVal archive As IZipArchive) As BA_ReturnCode
        Dim success As BA_ReturnCode = BA_ReturnCode.Success
        If BA_Shapefile_Exists(shapefilePath) Then
            'Returns the shapefile name without .shp
            Dim shapeRoot As String = BA_StandardizeShapefileName(shapefilePath, False, True)
            Dim parentPath As String = "PleaseReturn"
            Dim file1 As String = BA_GetBareName(shapefilePath, parentPath)
            archive.AddFile(shapefilePath)  'Add .shp
            If File.Exists(parentPath & shapeRoot & ".shx") Then
                archive.AddFile(parentPath & shapeRoot & ".shx")     'Add .shx
            Else
                success = BA_ReturnCode.ReadError
            End If
            If File.Exists(parentPath & shapeRoot & ".dbf") Then
                archive.AddFile(parentPath & shapeRoot & ".dbf")     'Add .dbf
            Else
                success = BA_ReturnCode.ReadError
            End If
            If File.Exists(parentPath & shapeRoot & ".prj") Then
                archive.AddFile(parentPath & shapeRoot & ".prj")     'Add .prj
            Else
                success = BA_ReturnCode.ReadError
            End If
            Return success
        End If
        Return success
    End Function

    Public Function BA_UnzipAoi(ByVal zipFilePath As String, ByVal outputPath As String) As BA_ReturnCode
        Dim archive As IZipArchive = New ZipArchive()
        Try
            'Check to see if the outputPath exists; If so, delete folder and contents so we don't mix old/new
            If BA_Folder_ExistsWindowsIO(outputPath) Then BA_Remove_Folder(outputPath)
            Dim parentPath As String = "PleaseReturn"
            Dim aoiFolder As String = BA_GetBareName(outputPath, parentPath)
            If Not String.IsNullOrEmpty(parentPath) Then
                archive.OpenArchive(zipFilePath)
                Dim contents As IEnumBSTR = archive.GetFileNames
                Dim filePath As String = contents.Next
                Do While Not String.IsNullOrEmpty(filePath)
                    archive.ExtractFile(filePath, parentPath)
                    filePath = contents.Next()
                Loop
                Return BA_ReturnCode.Success
            Else
                Return BA_ReturnCode.WriteError
            End If
        Catch ex As Exception
            Debug.Print("BA_UnzipAoi exception: " & ex.Message)
            Return BA_ReturnCode.UnknownError
        Finally
            archive.CloseArchive()      'Always close the archive
        End Try
    End Function

End Module
