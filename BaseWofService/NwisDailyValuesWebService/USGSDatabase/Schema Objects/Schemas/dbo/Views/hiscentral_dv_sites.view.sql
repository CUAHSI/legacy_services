
CREATE VIEW [dbo].[hiscentral_dv_sites]
AS
SELECT     CONVERT(nvarchar(101), SiteVocabulary + ':' + SiteCode) AS SiteCode, CONVERT(nvarchar(200), SiteName) AS SiteName, Latitude, Longitude, CONVERT(varchar(150), 
                      LatLongDatumID) AS LatLongDatumID, CASE WHEN ISNUMERIC(Elevation_m) = 1 THEN CONVERT(real, Elevation_m) ELSE NULL END AS Elevation_m, 
                      CONVERT(varchar(50), VerticalDatum) AS VerticalDatum, CAST(NULL AS float) AS LocalX, CAST(NULL AS float) AS LocalY, CAST(NULL AS int) AS LocalProjectionID, 
                      PosAccuracy_m, CONVERT(varchar(120), State) AS StateName, CONVERT(varchar(252), County) AS county, CONVERT(varchar(150), Comments) AS Comments, 
                      CONVERT(varchar(80), 'USGS agency:' + usgs_agency) AS OrganizationName, CONVERT(varchar(12), usgs_huc) AS HUC, CONVERT(decimal(18, 0), HUCNUMERIC) 
                      AS HUCnumeric, 1 AS NetworkID
FROM         dbo.odm_dv_sites AS sites

