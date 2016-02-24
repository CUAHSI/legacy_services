CREATE VIEW dbo.qw_sites_odm
AS
SELECT     sites.site_no AS SiteID, CASE WHEN sites.agency_cd = 'USGS' THEN sites.site_no ELSE sites.site_no + '/agency=' + sites.agency_cd END AS SiteCode, 
                      sites.station_nm AS SiteName, sites.dec_lat_va AS Latitude, sites.dec_long_va AS Longitude, dbo.SpatialReferences.SpatialReferenceID AS LatLongDatumID, 
                      sites.alt_va AS Elevation_m, sites.alt_datum_cd AS VerticalDatum, NULL AS PosAccuracy_m, dbo.v_fips_countyCodes.County, dbo.v_fips_countyCodes.State, NULL 
                      AS Comments, sites.tz_cd AS odws_timeZoneName, sites.local_time_fg AS odws_UsesDaylightSavingsTime, sites.state_cd AS usgs_State_fipCode, 
                      sites.county_cd AS Usgs_County_fipsCode, sites.agency_cd AS usgs_agency, 'NWISQW' AS SiteVocabulary, 'NWISQW:' + sites.site_no AS hs_SiteCode, 
                      sites.huc_cd AS usgs_huc, CASE len(HUC_CD) WHEN 0 THEN NULL ELSE sites.huc_cd + CASE len(rtrim(ltrim(basin_cd))) 
                      WHEN 0 THEN '0000' WHEN 2 THEN Basin_cd + '00' WHEN 4 THEN Basin_cd ELSE '0000' END END AS HUCNUMERIC, sites.agency_cd, sites.site_no
FROM         dbo.USGS_sitefile AS sites INNER JOIN
                          (SELECT DISTINCT site_no, agency_cd
                            FROM          dbo.series
                            WHERE      (data_type_cd = 'qw')) AS sitesUsed ON sites.site_no = sitesUsed.site_no AND sites.agency_cd = sitesUsed.agency_cd LEFT OUTER JOIN
                      dbo.v_fips_countyCodes ON sites.county_cd = dbo.v_fips_countyCodes.FIPS_county_cd AND sites.state_cd = dbo.v_fips_countyCodes.FIPS_st_cd LEFT OUTER JOIN
                      dbo.SpatialReferences ON sites.dec_coord_datum_cd = dbo.SpatialReferences.Name
WHERE     (NOT (sites.dec_lat_va = '0')) AND (NOT (sites.dec_long_va = '0'))

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[33] 4[27] 2[22] 3) )"
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
         Begin Table = "sites"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 303
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 26
         End
         Begin Table = "sitesUsed"
            Begin Extent = 
               Top = 6
               Left = 265
               Bottom = 84
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "v_fips_countyCodes"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 114
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SpatialReferences"
            Begin Extent = 
               Top = 6
               Left = 650
               Bottom = 114
               Right = 823
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
      Begin ColumnWidths = 22
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'qw_sites_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'Column = 1440
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
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'qw_sites_odm';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'qw_sites_odm';

