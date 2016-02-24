CREATE VIEW dbo.dv_series_odm
AS
SELECT     sitePOR.site_no AS siteID, sitePOR.agency_cd AS usgs_agency, 
                      CASE WHEN dbo.USGS_sitefile.agency_cd = 'USGS' THEN dbo.USGS_sitefile.site_no ELSE dbo.USGS_sitefile.site_no + '/agency=' + dbo.USGS_sitefile.agency_cd END
                       AS SiteCode, dbo.USGS_sitefile.station_nm AS siteName, 1 AS TimeSupport, 104 AS TimeUnitsId, 'day' AS TimeUnitsName, CONVERT(varchar(255), NULL) 
                      AS MethodName, NULL AS MethodID, 1 AS SourceID, 'USGS' AS Organization, 'USGS NWIS Daily Values' AS SourceDescription, NULL AS QualityControlLevelID, 
                      CASE WHEN datediff(year, CAST('2010-03-01' AS datetime), sitePOR.EndDateTime) >= 0 AND datediff(month, CAST('2010-03-01' AS datetime), sitePOR.EndDateTime) 
                      >= 0 THEN GetDate() ELSE sitePOR.EndDateTime END AS EndDateTime, sitePOR.stat_cd AS usgs_stat_cd, odm_variables.VariableName, 
                      CASE WHEN odm_variables.SampleMedium IS NULL THEN 'Unknown' ELSE odm_variables.SampleMedium END AS SampleMedium, odm_variables.ValueType, 
                      odm_variables.isRegular, odm_variables.GeneralCategory, odm_variables.NoDataValue, odm_variables.VariableUnitsID, odm_variables.DataType, 
                      odm_variables.VariableVocabulary, 'NWISDV' AS SiteVocabulary, 'NWIS:' + dbo.USGS_sitefile.site_no AS hs_siteCode, 
                      'NWISDV:' + dbo.USGS_sitefile.site_no AS ws_siteCode, 'd' AS TimeUnitsAbbreviation, odm_variables.VariableCode, sitePOR.parm_cd AS usgs_parm_cd, 
                      odm_variables.VariableUnitsAbbreviation, odm_variables.VariableUnitsName, odm_variables.VariableUnitsType, CONVERT(datetime, sitePOR.beginDateTime) 
                      AS beginDateTime, sitePOR.ValueCount
FROM         dbo.dv_seriesPOR_odm AS sitePOR INNER loop JOIN
                      dbo.USGS_sitefile ON sitePOR.site_no = dbo.USGS_sitefile.site_no AND sitePOR.agency_cd = dbo.USGS_sitefile.agency_cd INNER JOIN
                      dbo.dv_variables_odm AS odm_variables ON sitePOR.parm_cd = odm_variables.parm_cd AND sitePOR.stat_cd = odm_variables.stat_cd

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[29] 4[23] 2[23] 3) )"
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
         Begin Table = "sitePOR"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 271
               Right = 193
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "USGS_sitefile"
            Begin Extent = 
               Top = 6
               Left = 304
               Bottom = 261
               Right = 493
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "odm_variables"
            Begin Extent = 
               Top = 6
               Left = 531
               Bottom = 114
               Right = 734
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
      Begin ColumnWidths = 35
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
      End
   End
   Begin CriteriaPane =', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'dv_series_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'Begin ColumnWidths = 11
         Column = 2010
         Alias = 1395
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'dv_series_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'dv_series_odm';

