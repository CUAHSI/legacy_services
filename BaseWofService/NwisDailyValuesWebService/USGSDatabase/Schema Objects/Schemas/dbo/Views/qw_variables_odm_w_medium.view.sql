CREATE VIEW [dbo].[qw_variables_odm_w_medium]
WITH SCHEMABINDING 
AS
SELECT     dbo.variables.VariableID, usedVariables.parm_cd + CASE WHEN medium_grp_cd IS NULL 
                      THEN '' ELSE '/SampleMedium=' + CASE WHEN medium_grp_cd = 'oth' THEN 'Other' WHEN medium_grp_cd = 'sed' THEN 'Sediment' WHEN medium_grp_cd = 'wat' THEN
                       'Water' WHEN medium_grp_cd = 'bio' THEN 'Tissue' WHEN medium_grp_cd = 'soi' THEN 'Soil' WHEN medium_grp_cd = 'air' THEN 'Air' ELSE medium_grp_cd END END
                       + CASE WHEN usedVariables.Count = 1 THEN '' ELSE '' END AS VariableCode, dbo.variables.VariableName, 
                      CASE WHEN medium_grp_cd = 'oth' THEN 'Other' WHEN medium_grp_cd = 'sed' THEN 'Sediment' WHEN medium_grp_cd = 'wat' THEN 'Water' WHEN medium_grp_cd
                       = 'bio' THEN 'Tissue' WHEN medium_grp_cd = 'soi' THEN 'Soil' WHEN medium_grp_cd = 'air' THEN 'Air' ELSE medium_grp_cd END AS SampleMedium, 
                      'Sample' AS ValueType, 'false' AS IsRegular, 0 AS TimeSupport, 102 AS TimeUnitsID, 'Sproadic' AS DataType, dbo.variables.GeneralCategory, 
                      dbo.variables.NoDataValue, dbo.variables.VariableUnitsID, usedVariables.medium_grp_cd AS MediumCode, 'NWISQW' AS VariableVocabulary, 
                      'm' AS TimeUnitsAbbreviation, 'minute' AS TimeUnitsName, dbo.Units.UnitAbbreviation AS VariableUnitsAbbreviation, dbo.Units.UnitType AS VariableUnitsType, 
                      dbo.Units.Units AS VariableUnitsName, usedVariables.parm_cd, usedVariables.medium_grp_cd
FROM         dbo.variables INNER JOIN
                          (SELECT     parm_cd, medium_grp_cd, COUNT(parm_cd) AS Count
                            FROM          dbo.series
                            WHERE      (data_type_cd = 'qw')
                            GROUP BY parm_cd, medium_grp_cd) AS usedVariables ON dbo.variables.VariableCode = usedVariables.parm_cd LEFT OUTER JOIN
                      dbo.Units ON dbo.variables.VariableUnitsID = dbo.Units.UnitID

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[23] 4[15] 2[35] 3) )"
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
         Begin Table = "variables"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Units"
            Begin Extent = 
               Top = 6
               Left = 427
               Bottom = 114
               Right = 587
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "usedVariables"
            Begin Extent = 
               Top = 6
               Left = 238
               Bottom = 99
               Right = 393
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
      Begin ColumnWidths = 26
         Width = 284
         Width = 1500
         Width = 3360
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
         Width = 1860
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
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 2220
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOr', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'qw_variables_odm_w_medium';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'der = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'qw_variables_odm_w_medium';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'qw_variables_odm_w_medium';

