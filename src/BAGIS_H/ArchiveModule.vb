Imports BAGIS_ClassLibrary
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesGDB
Imports System.ComponentModel
Imports System.IO
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.DataManagementTools

Module ArchiveModule

    Public Function BA_CopyAOIForExport(ByVal aoiFolder As String) As BA_ReturnCode

        '8. Create param/methods folder
        '9. Copy param/methods/*.xml to new param/methods folder
        '10. Create folder for each valid hru under zones folder 
        '11. Create hru_name.gdb in each folder
        '12. Copy grid, grid_v and grid_zones_v (if present) to destination
        '13. Copy log.xml
        '14. Copy entire param.gdb

        'Dim dirZones As New DirectoryInfo(zonesDirectory)
        'Dim dirZonesArr As DirectoryInfo() = Nothing
        'Dim zoneCount As Integer
        'If dirZones.Exists Then
        '    dirZonesArr = dirZones.GetDirectories
        '    If dirZonesArr IsNot Nothing Then zoneCount = dirZonesArr.Length
        'End If
        'If dirZonesArr IsNot Nothing Then
        '    Dim item As LayerListItem
        '    For Each dri In dirZonesArr
        '        Dim hruFilePath As String = BA_GetHruPathGDB(m_aoi.FilePath, PublicPath.HruDirectory, dri.Name) & BA_EnumDescription(PublicPath.HruGrid)
        '        Dim hruXmlFilePath As String = BA_GetHruPath(m_aoi.FilePath, PublicPath.HruDirectory, dri.Name) & BA_EnumDescription(PublicPath.HruXml)
        '        ' Add hru to the list if the grid exists
        '        If BA_File_Exists(hruFilePath, WorkspaceType.Geodatabase, esriDatasetType.esriDTRasterDataset) And _
        '           BA_File_ExistsWindowsIO(hruXmlFilePath) Then
        '        End If
        '    Next dri
        'End If

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
                    File.Copy(mapsDir & BA_EnumDescription(PublicPath.AnalysisXml), newMapsDir & BA_EnumDescription(PublicPath.AnalysisXml))
                End If
                If System.IO.File.Exists(mapsDir & BA_EnumDescription(PublicPath.MapParameters)) Then
                    File.Copy(mapsDir & BA_EnumDescription(PublicPath.MapParameters), newMapsDir & BA_EnumDescription(PublicPath.MapParameters))
                End If
            End If
        End If
    End Function

End Module
