/* this includes all rows from duplicated sites*/
CREATE VIEW dbo.chk_dupe_sites_detailed
AS
SELECT     a.agency_cd, a.site_no, a.station_nm, a.site_tp_cd, a.lat_va, a.long_va, a.dec_lat_va, a.dec_long_va, a.coord_meth_cd, a.coord_acy_cd, a.coord_datum_cd, 
                      a.dec_coord_datum_cd, a.district_cd, a.state_cd, a.county_cd, a.country_cd, a.land_net_ds, a.map_nm, a.map_scale_fc, a.alt_va, a.alt_meth_cd, a.alt_acy_va, 
                      a.alt_datum_cd, a.huc_cd, a.basin_cd, a.topo_cd, a.instruments_cd, a.construction_dt, a.inventory_dt, a.drain_area_va, a.contrib_drain_area_va, a.tz_cd, 
                      a.local_time_fg, a.reliability_cd, a.gw_file_cd, a.nat_aqfr_cd, a.aqfr_cd, a.aqfr_type_cd, a.well_depth_va, a.hole_depth_va, a.depth_src_cd, a.project_no
FROM         dbo.USGS_sitefile AS a INNER JOIN
                          (SELECT     site_no, agency_cd, site_tp_cd, count
                            FROM          dbo.chk_dup_site_no_agency_all) AS B ON a.site_no = B.site_no AND a.agency_cd = B.agency_cd AND a.site_tp_cd = B.site_tp_cd

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 6
               Left = 265
               Bottom = 114
               Right = 416
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'chk_dupe_sites_detailed';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'chk_dupe_sites_detailed';

