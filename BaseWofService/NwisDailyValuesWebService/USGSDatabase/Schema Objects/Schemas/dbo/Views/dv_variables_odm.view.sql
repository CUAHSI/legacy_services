CREATE VIEW [dbo].[dv_variables_odm]
AS
SELECT     dbo.variables.VariableID, CASE WHEN dbo.NWIS_Stat_cd_to_DataValue.DataType IS NULL THEN CASE WHEN usedVariables.stat_cd IS NULL 
                      THEN dbo.variables.VariableCode ELSE RTRIM(LTRIM(usedVariables.parm_cd)) 
                      + '/statistic=' + usedVariables.stat_cd END ELSE RTRIM(LTRIM(dbo.variables.VariableCode)) 
                      + '/DataType=' + dbo.NWIS_Stat_cd_to_DataValue.DataType END AS VariableCode, dbo.variables.VariableName, dbo.variables.SampleMedium, 
                      'Field Observation' AS ValueType, CONVERT(Bit, 1) AS isRegular, '1' AS TimeSupport, '104' AS TimeUnitsID, dbo.variables.GeneralCategory, 
                      dbo.variables.NoDataValue, dbo.variables.networkId, dbo.variables.VariableUnitsID, dbo.variables.mediumCode, usedVariables.stat_cd, 
                      dbo.NWIS_Stat_cd_to_DataValue.DataType, 'd' AS TimeUnitsAbbreviation, 'day' AS TimeUnitsName, 'NWISDV' AS VariableVocabulary, 
                      'NWIS:' + RTRIM(dbo.variables.VariableCode) AS hs_variableCode, CASE WHEN dbo.NWIS_Stat_cd_to_DataValue.DataType IS NULL 
                      THEN CASE WHEN usedVariables.stat_cd IS NULL THEN dbo.variables.VariableCode ELSE RTRIM(LTRIM(usedVariables.parm_cd)) 
                      + '/statistic=' + usedVariables.stat_cd END ELSE RTRIM(LTRIM(dbo.variables.VariableCode)) 
                      + '/DataType=' + dbo.NWIS_Stat_cd_to_DataValue.DataType END AS hs_newVariableCode, dbo.Units.UnitAbbreviation AS VariableUnitsAbbreviation, 
                      dbo.Units.Units AS VariableUnitsName, dbo.Units.UnitType AS VariableUnitsType, usedVariables.parm_cd
FROM         dbo.variables INNER JOIN
                          (SELECT     parm_cd, stat_cd
                            FROM          dbo.series
                            WHERE      (data_type_cd = 'dv')
                            GROUP BY parm_cd, stat_cd) AS usedVariables ON dbo.variables.VariableCode = usedVariables.parm_cd INNER JOIN
                      dbo.NWIS_Stat_cd_to_DataValue ON usedVariables.stat_cd = dbo.NWIS_Stat_cd_to_DataValue.stat_cd INNER JOIN
                      dbo.Units ON dbo.variables.VariableUnitsID = dbo.Units.UnitID
WHERE     (dbo.variables.VariableID IS NOT NULL)

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[24] 4[19] 2[37] 3) )"
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
         Top = -192
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
         Begin Table = "NWIS_Stat_cd_to_DataValue"
            Begin Extent = 
               Top = 6
               Left = 427
               Bottom = 114
               Right = 586
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Units"
            Begin Extent = 
               Top = 84
               Left = 238
               Bottom = 192
               Right = 398
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "usedVariables"
            Begin Extent = 
               Top = 271
               Left = 168
               Bottom = 349
               Right = 319
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
      Begin ColumnWidths = 25
         Width = 284
         Width = 1500
         Width = 3270
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
         Width = 150', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'dv_variables_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'0
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'dv_variables_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'dv_variables_odm';

