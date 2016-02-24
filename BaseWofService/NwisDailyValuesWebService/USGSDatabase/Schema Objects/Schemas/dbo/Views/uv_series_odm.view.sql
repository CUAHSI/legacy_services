﻿CREATE VIEW dbo.uv_series_odm
AS
SELECT     dbo.USGS_sitefile.site_no AS siteID, 
                      CASE WHEN dbo.USGS_sitefile.agency_cd = 'USGS' THEN dbo.USGS_sitefile.site_no ELSE dbo.USGS_sitefile.site_no + '/agency=' + dbo.USGS_sitefile.agency_cd END
                       AS SiteCode, dbo.USGS_sitefile.station_nm AS siteName, variableView.VariableCode, variableView.VariableID, variableView.VariableName, 
                      variableView.SampleMedium, variableView.ValueType, variableView.GeneralCategory, CONVERT(varchar(255), NULL) AS MethodName, 1 AS SourceID, 
                      'USGS' AS Organization, 'USGS NWIS' AS SourceDescription, '0' AS QualityControlLevelID, sitePOR.beginDateTime, GETDATE() AS EndDateTime, sitePOR.ValueCount, 
                      dbo.USGS_sitefile.agency_cd AS usgs_agency, 'raw data' AS QualityControlLevelName, 'NWISUV' AS SiteVocabulary, 'NWISUV' AS VariableVocabulary, 
                      'NWIS:' + variableView.VariableCode AS hs_variableCode, 'NWIS:' + dbo.USGS_sitefile.site_no AS hs_siteCode, 
                      'NWISUV:' + variableView.VariableCode AS ws_variableCode, 'NWISUV:' + dbo.USGS_sitefile.site_no AS ws_siteCode, variableView.IsRegular, variableView.DataType,
                       variableView.TimeSupport, variableView.TimeUnitsID, variableView.TimeUnitsAbbreviation, variableView.TimeUnitsName, variableView.VariableUnitsAbbreviation, 
                      variableView.VariableUnitsType, variableView.VariableUnitsName, variableView.VariableUnitsID
FROM         dbo.uv_seriesPOR_odm AS sitePOR INNER JOIN
                      dbo.USGS_sitefile ON sitePOR.site_no = dbo.USGS_sitefile.site_no AND sitePOR.agency_cd = dbo.USGS_sitefile.agency_cd INNER JOIN
                      dbo.uv_variables_odm AS variableView ON sitePOR.parm_cd = variableView.parm_cd

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[34] 4[17] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "USGS_sitefile"
            Begin Extent = 
               Top = 21
               Left = 552
               Bottom = 285
               Right = 736
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "sitePOR"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 193
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "variableView"
            Begin Extent = 
               Top = 6
               Left = 231
               Bottom = 114
               Right = 434
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 37
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'uv_series_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2595
         Alias = 1845
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'uv_series_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'uv_series_odm';
