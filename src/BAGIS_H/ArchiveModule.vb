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

    Public Function BA_CreateTempZipFolder(ByVal aoiFolder As String, ByVal newFolderName As String) As BA_ReturnCode
        Dim parentFolder As String = "PleaseReturn"
        Dim file1 As String = BA_GetBareName(aoiFolder, parentFolder)
        Dim newFolderPath As String = parentFolder & newFolderName
        'Delete previous temp directory if it exists
        If System.IO.Directory.Exists(newFolderPath) Then System.IO.Directory.Delete(newFolderPath, True)
        Dim newPath As String = BA_CreateFolder(parentFolder, newFolderName)
        If String.IsNullOrEmpty(newPath) Then
            Return BA_ReturnCode.WriteError
        Else
            Return BA_ReturnCode.Success
        End If
    End Function

    Public Function BA_CopyGeodatabases(ByVal sourceFolder, ByVal targetFolder) As BA_ReturnCode
        Dim GP As ESRI.ArcGIS.Geoprocessor.Geoprocessor = New ESRI.ArcGIS.Geoprocessor.Geoprocessor()
        Dim pResult As ESRI.ArcGIS.Geoprocessing.IGeoProcessorResult = Nothing
        Dim tool As Copy = New Copy
        GP.OverwriteOutput = True
        GP.AddOutputsToMap = False
        Try
            For Each pName In [Enum].GetValues(GetType(GeodatabaseNames))
                Dim EnumConstant As [Enum] = pName
                Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
                Dim aattr() As DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
                Dim gdbName As String = aattr(0).Description
                tool.in_data = sourceFolder & "\" & gdbName
                tool.out_data = targetFolder & "\" & gdbName
                pResult = GP.Execute(tool, Nothing)
            Next
            Return BA_ReturnCode.Success
        Catch ex As Exception
            For c As Integer = 0 To GP.MessageCount - 1
                Debug.Print("GP error: " & GP.GetMessage(c))
            Next
            If GP.MessageCount > 0 Then
                Debug.Print("BA_CopyGeodatabases Geoprocessor error: " + GP.GetMessages(2))
            Else
                Debug.Print("BA_CopyGeodatabases Exception: " + ex.Message)
            End If
            Return BA_ReturnCode.UnknownError
        Finally
            GP = Nothing
            pResult = Nothing
            tool = Nothing
        End Try
    End Function

    Public Function BA_CopyMiscFiles(ByVal sourceFolder As String, ByVal targetFolder As String) As BA_ReturnCode
        'aoi_streams.shp
        Dim streamLinks As String = sourceFolder & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.AoiStreamsVector), True, True)
        If BA_Shapefile_Exists(streamLinks) Then
            Dim targetLinks As String = targetFolder & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.AoiStreamsVector), True, True)
            BA_CopyFeatures(streamLinks, targetLinks)
        End If
        Dim mapsDir As String = sourceFolder & BA_EnumDescription(PublicPath.Maps)
        If System.IO.Directory.Exists(mapsDir) Then
            Dim parentPath As String = "Please return"
            Dim newMapsDir As String = BA_CreateFolder(targetFolder, BA_EnumDescription(PublicPath.Maps))
            If Not String.IsNullOrEmpty(newMapsDir) Then
                If System.IO.File.Exists(mapsDir & BA_EnumDescription(PublicPath.AnalysisXml)) Then
                    File.Copy(mapsDir & BA_EnumDescription(PublicPath.AnalysisXml), newMapsDir & BA_EnumDescription(PublicPath.AnalysisXml), True)
                End If
                If System.IO.File.Exists(mapsDir & BA_EnumDescription(PublicPath.MapParameters)) Then
                    File.Copy(mapsDir & BA_EnumDescription(PublicPath.MapParameters), newMapsDir & BA_EnumDescription(PublicPath.MapParameters), True)
                End If
            End If
        End If
        '@ToDo: We may or may not need to create the /aoi/param folder depending on if we archive the methods folder
    End Function

    Public Function BA_CopyHrus(ByVal aoiFolder As String, ByVal targetFolder As String) As BA_ReturnCode
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
                'Create zones folder
                Directory.CreateDirectory(targetFolder & BA_EnumDescription(PublicPath.HruDirectory))
                For Each dri In dirZonesArr
                    Dim sourceGDB As String = BA_GetHruPathGDB(aoiFolder, PublicPath.HruDirectory, dri.Name)
                    Dim hruFilePath As String = sourceGDB & BA_EnumDescription(PublicPath.HruGrid)
                    Dim hruXmlFilePath As String = BA_GetHruPath(aoiFolder, PublicPath.HruDirectory, dri.Name) & BA_EnumDescription(PublicPath.HruXml)
                    ' Add hru to the list if the grid exists
                    If BA_File_Exists(hruFilePath, WorkspaceType.Geodatabase, esriDatasetType.esriDTRasterDataset) And _
                       BA_File_ExistsWindowsIO(hruXmlFilePath) Then
                        Dim targetHruDir As String = targetFolder & BA_EnumDescription(PublicPath.HruDirectory) & "\" & dri.Name
                        Directory.CreateDirectory(targetHruDir)
                        'create gdb in hru-name folder
                        Dim success As BA_ReturnCode = BA_CreateFileGdb(targetHruDir, dri.Name & ".gdb")
                        If success = BA_ReturnCode.Success Then
                            Dim targetGDB As String = BA_GetHruPathGDB(targetFolder, PublicPath.HruDirectory, dri.Name)
                            'grid
                            success = BA_Copy(sourceGDB & BA_EnumDescription(PublicPath.HruGrid), targetGDB & BA_EnumDescription(PublicPath.HruGrid))
                            'grid_v
                            If BA_File_Exists(sourceGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruVector), False, True), WorkspaceType.Geodatabase, esriDatasetType.esriDTFeatureClass) Then
                                success = BA_CopyFeatures(sourceGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruVector), False, True), targetGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruVector), False, True))
                            End If
                            'grid_zones_v
                            If BA_File_Exists(sourceGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruZonesVector), False, True), WorkspaceType.Geodatabase, esriDatasetType.esriDTFeatureClass) Then
                                success = BA_CopyFeatures(sourceGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruZonesVector), False, True), targetGDB & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.HruZonesVector), False, True))
                            End If
                            'log.xml
                            File.Copy(hruXmlFilePath, BA_GetHruPath(targetFolder, PublicPath.HruDirectory, dri.Name) & BA_EnumDescription(PublicPath.HruXml))
                            'Checks first to see if param.gdb exists
                            If wsf.IsWorkspace(BA_GetHruPath(aoiFolder, PublicPath.HruDirectory, dri.Name) & BA_EnumDescription(PublicPath.BagisParamGdb)) Then
                                success = BA_Copy(BA_GetHruPath(aoiFolder, PublicPath.HruDirectory, dri.Name) & BA_EnumDescription(PublicPath.BagisParamGdb), BA_GetHruPath(targetFolder, PublicPath.HruDirectory, dri.Name) & BA_EnumDescription(PublicPath.BagisParamGdb))
                            End If
                        End If
                    End If
                Next dri
            End If
            Return BA_ReturnCode.Success
        Catch ex As Exception
            Debug.Print("BA_CopyHrus Exception: " + ex.Message)
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
        'Dim streamLinks As String = sourceFolder & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.AoiStreamsVector), True, True)
        'If BA_Shapefile_Exists(streamLinks) Then
        '    Dim targetLinks As String = targetFolder & BA_StandardizeShapefileName(BA_EnumDescription(PublicPath.AoiStreamsVector), True, True)
        '    BA_CopyFeatures(streamLinks, targetLinks)
        'End If
        Dim mapsDir As String = sourceFolder & BA_EnumDescription(PublicPath.Maps)
        If System.IO.Directory.Exists(mapsDir) Then
            If System.IO.File.Exists(mapsDir & BA_EnumDescription(PublicPath.AnalysisXml)) Then
                'File.Copy(mapsDir & BA_EnumDescription(PublicPath.AnalysisXml), newMapsDir & BA_EnumDescription(PublicPath.AnalysisXml), True)
            End If
            If System.IO.File.Exists(mapsDir & BA_EnumDescription(PublicPath.MapParameters)) Then
                archive.AddFile(mapsDir & BA_EnumDescription(PublicPath.MapParameters))
            End If
        End If
        '@ToDo: We may or may not need to create the /aoi/param folder depending on if we archive the methods folder
    End Function

End Module
