CREATE VIEW [dbo].[qw_series_odm_w_medium]
AS
SELECT     sitePOR.site_no AS siteID, CASE WHEN sitePOR.agency_cd = 'USGS' THEN sitePOR.site_no ELSE sitePOR.site_no + '/agency=' + sitePOR.agency_cd END AS SiteCode,
                       sitePOR.station_nm AS siteName, variableView.VariableCode, variableView.VariableID, variableView.VariableName, variableView.SampleMedium, 
                      variableView.ValueType, variableView.GeneralCategory, NULL AS MethodID, CONVERT(varchar(255), NULL) AS MethodName, 1 AS SourceID, 'USGS' AS Organization, 
                      'USGS NWIS' AS SourceDescription, '0' AS QualityControlLevelID, sitePOR.beginDate AS beginDateTime, sitePOR.endDate AS EndDateTime, 
                      sitePOR.count_nu AS ValueCount, sitePOR.agency_cd AS usgs_agency, 'raw data' AS QualityControlLevelName, 'NWISQW' AS SiteVocabulary, 
                      'NWISWQ' AS VariableVocabulary, 'NWISQW:' + variableView.VariableCode AS ws_variableCode, 'NWISQW:' + sitePOR.site_no AS ws_siteCode, 
                      variableView.IsRegular, variableView.DataType, variableView.TimeSupport, variableView.TimeUnitsID, variableView.TimeUnitsAbbreviation, 
                      variableView.TimeUnitsName, variableView.VariableUnitsAbbreviation, variableView.VariableUnitsType, variableView.VariableUnitsName, 
                      variableView.VariableUnitsID
FROM         dbo.series AS sitePOR INNER JOIN
                      dbo.odm_qw_variables AS variableView ON sitePOR.parm_cd = variableView.parm_cd AND ISNULL(sitePOR.medium_grp_cd, '') 
                      = ISNULL(variableView.medium_grp_cd, '')
WHERE     (sitePOR.data_type_cd = 'qw')

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[10] 2[31] 3) )"
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
               Bottom = 114
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "variableView"
            Begin Extent = 
               Top = 6
               Left = 259
               Bottom = 114
               Right = 462
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
      Begin ColumnWidths = 9
         Width = 284
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
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'qw_series_odm_w_medium';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'qw_series_odm_w_medium';

