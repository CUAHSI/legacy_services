
CREATE VIEW [dbo].[uv_series_odm_w_method]
AS
SELECT     dbo.USGS_sitefile.site_no AS siteID, 
                      CASE WHEN dbo.USGS_sitefile.agency_cd = 'USGS' THEN dbo.USGS_sitefile.site_no ELSE dbo.USGS_sitefile.site_no + '/agency=' + dbo.USGS_sitefile.agency_cd END
                       AS SiteCode, dbo.USGS_sitefile.station_nm AS siteName, variableView.VariableCode, variableView.VariableID, variableView.VariableName, 
                      variableView.SampleMedium, variableView.ValueType, variableView.GeneralCategory, NULL AS MethodID, CONVERT(varchar(255), NULL) AS MethodName, 
                      1 AS SourceID, 'USGS' AS Organization, 'USGS NWIS' AS SourceDescription, '0' AS QualityControlLevelID, DATEADD(DAY, - 120, GETDATE()) AS beginDateTime, 
                      GETDATE() AS EndDateTime, 120 * 24 * 4 AS ValueCount, dbo.USGS_sitefile.agency_cd AS usgs_agency, 'raw data' AS QualityControlLevelName, 
                      'NWISUV' AS SiteVocabulary, 'NWISUV' AS VariableVocabulary, 'NWIS:' + variableView.VariableCode AS hs_variableCode, 
                      'NWIS:' + dbo.USGS_sitefile.site_no AS hs_siteCode, 'NWISUV:' + variableView.VariableCode AS ws_variableCode, 
                      'NWISUV:' + dbo.USGS_sitefile.site_no AS ws_siteCode, variableView.IsRegular, variableView.DataType, variableView.TimeSupport, variableView.TimeUnitsID, 
                      variableView.TimeUnitsAbbreviation, variableView.TimeUnitsName, variableView.VariableUnitsAbbreviation, variableView.VariableUnitsType, 
                      variableView.VariableUnitsName, variableView.VariableUnitsID
FROM         dbo.series AS sitePOR INNER JOIN
                      dbo.USGS_sitefile ON sitePOR.site_no = dbo.USGS_sitefile.site_no AND sitePOR.agency_cd = dbo.USGS_sitefile.agency_cd INNER JOIN
                      dbo.odm_uv_variables_w_method AS variableView ON sitePOR.parm_cd = variableView.parm_cd AND sitePOR.parm_cd = variableView.parm_cd AND 
                      ISNULL(sitePOR.loc_web_ds, '') = ISNULL(variableView.loc_web_ds, '')
WHERE     (sitePOR.data_type_cd = 'uv')

