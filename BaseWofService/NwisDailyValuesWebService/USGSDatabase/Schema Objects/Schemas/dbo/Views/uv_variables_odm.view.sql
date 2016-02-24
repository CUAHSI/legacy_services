CREATE VIEW [dbo].[uv_variables_odm]
AS
SELECT     dbo.variables.VariableID, usedVariables.VariableCode, dbo.variables.VariableName, dbo.variables.SampleMedium, 'Unknown' AS ValueType, 'true' AS IsRegular, 
                      15 AS TimeSupport, 102 AS TimeUnitsID, 'Continuous' AS DataType, dbo.variables.GeneralCategory, dbo.variables.NoDataValue, dbo.variables.networkId, 
                      dbo.variables.VariableUnitsID, dbo.variables.mediumCode, 'NWISUV' AS VariableVocabulary, 'm' AS TimeUnitsAbbreviation, 'minute' AS TimeUnitsName, 
                      dbo.Units.UnitAbbreviation AS VariableUnitsAbbreviation, dbo.Units.UnitType AS VariableUnitsType, dbo.Units.Units AS VariableUnitsName, 
                      usedVariables.VariableCode AS parm_cd
FROM         dbo.variables INNER JOIN
                          (SELECT     parm_cd AS VariableCode, COUNT(parm_cd) AS Count
                            FROM          dbo.series
                            WHERE      (data_type_cd = 'uv')
                            GROUP BY parm_cd) AS usedVariables ON dbo.variables.VariableCode = usedVariables.VariableCode LEFT OUTER JOIN
                      dbo.Units ON dbo.variables.VariableUnitsID = dbo.Units.UnitID
WHERE     (dbo.variables.VariableID IS NOT NULL)

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[18] 4[31] 2[26] 3) )"
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
               Bottom = 144
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
               Bottom = 84
               Right = 389
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
      Begin ColumnWidths = 23
         Width = 284
         Width = 1500
         Width = 2355
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
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1845
         Alias = 1800
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'uv_variables_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'uv_variables_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'uv_variables_odm';

