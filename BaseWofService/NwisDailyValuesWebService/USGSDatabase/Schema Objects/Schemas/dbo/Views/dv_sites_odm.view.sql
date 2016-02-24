CREATE VIEW [dbo].[dv_sites_odm]
AS
SELECT DISTINCT 
                      dbo.USGS_sitefile.site_no AS SiteID, dbo.USGS_sitefile.agency_cd AS usgs_agency, 
                      CASE WHEN dbo.USGS_sitefile.agency_cd = 'USGS' THEN dbo.USGS_sitefile.site_no ELSE dbo.USGS_sitefile.site_no + '/agency=' + dbo.USGS_sitefile.agency_cd END
                       AS SiteCode, dbo.USGS_sitefile.station_nm AS SiteName, dbo.USGS_sitefile.dec_lat_va AS Latitude, dbo.USGS_sitefile.dec_long_va AS Longitude, 
                      dbo.SpatialReferences.SpatialReferenceID AS LatLongDatumID, dbo.USGS_sitefile.alt_va AS Elevation_m, dbo.USGS_sitefile.alt_datum_cd AS VerticalDatum, NULL 
                      AS PosAccuracy_m, dbo.v_fips_countyCodes.County, dbo.v_fips_countyCodes.State, NULL AS Comments, dbo.USGS_sitefile.tz_cd AS odws_timeZoneAbbreviation, 
                      dbo.USGS_sitefile.local_time_fg AS usgs_UsesDaylightSavingsTime, dbo.USGS_sitefile.state_cd AS usgs_State_fipCode, 
                      dbo.USGS_sitefile.county_cd AS Usgs_County_fipsCode, 'NWISDV' AS SiteVocabulary, dbo.usgs_station_type_cd.usgs_station_type, 
                      'NWISDV:' + dbo.USGS_sitefile.site_no AS hs_SiteCode, dbo.USGS_sitefile.huc_cd AS usgs_huc, CASE len(HUC_CD) WHEN 0 THEN NULL 
                      ELSE dbo.USGS_sitefile.huc_cd + CASE len(rtrim(ltrim(basin_cd))) 
                      WHEN 0 THEN '0000' WHEN 2 THEN Basin_cd + '00' WHEN 4 THEN Basin_cd ELSE '0000' END END AS HUCNUMERIC
FROM         dbo.USGS_sitefile INNER JOIN
                          (SELECT DISTINCT site_no, agency_cd
                            FROM          dbo.series
                            WHERE      (data_type_cd = 'dv')) AS sitesUsed ON dbo.USGS_sitefile.site_no = sitesUsed.site_no LEFT OUTER JOIN
                      dbo.usgs_station_type_cd ON dbo.USGS_sitefile.site_tp_cd = dbo.usgs_station_type_cd.station_type_cd LEFT OUTER JOIN
                      dbo.v_fips_countyCodes ON dbo.USGS_sitefile.county_cd = dbo.v_fips_countyCodes.FIPS_county_cd AND 
                      dbo.USGS_sitefile.state_cd = dbo.v_fips_countyCodes.FIPS_st_cd LEFT OUTER JOIN
                      dbo.SpatialReferences ON dbo.USGS_sitefile.dec_coord_datum_cd = dbo.SpatialReferences.Name

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[22] 4[22] 2[29] 3) )"
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
               Top = 6
               Left = 38
               Bottom = 114
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "usgs_station_type_cd"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 99
               Right = 623
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "v_fips_countyCodes"
            Begin Extent = 
               Top = 6
               Left = 661
               Bottom = 54
               Right = 812
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SpatialReferences"
            Begin Extent = 
               Top = 54
               Left = 265
               Bottom = 162
               Right = 438
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sitesUsed"
            Begin Extent = 
               Top = 102
               Left = 476
               Bottom = 180
               Right = 627
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
         Width = 1500', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'dv_sites_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'Width = 1500
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'dv_sites_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'dv_sites_odm';

