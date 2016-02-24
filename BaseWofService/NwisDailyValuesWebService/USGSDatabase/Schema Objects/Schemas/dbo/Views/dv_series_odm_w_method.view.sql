
CREATE VIEW [dbo].[dv_series_odm_w_method]
AS
SELECT     dbo.USGS_sitefile.site_no AS siteID, dbo.USGS_sitefile.agency_cd AS usgs_agency, 
                      CASE WHEN dbo.USGS_sitefile.agency_cd = 'USGS' THEN dbo.USGS_sitefile.site_no ELSE dbo.USGS_sitefile.site_no + '/agency=' + dbo.USGS_sitefile.agency_cd END
                       AS SiteCode, dbo.USGS_sitefile.station_nm AS siteName, 1 AS TimeSupport, 104 AS TimeUnitsId, 'day' AS TimeUnitsName, CONVERT(varchar(255), NULL) 
                      AS MethodName, NULL AS MethodID, 1 AS SourceID, 'USGS' AS Organization, 'USGS NWIS Daily Values' AS SourceDescription, NULL AS QualityControlLevelID, 
                      sitePOR.beginDate AS BeginDateTime, CASE WHEN datediff(year, CAST('2010-03-01' AS datetime), sitePOR.EndDate) >= 0 AND datediff(month, 
                      CAST('2010-03-01' AS datetime), sitePOR.EndDate) >= 0 THEN GetDate() ELSE sitePOR.EndDate END AS EndDateTime, sitePOR.count_nu AS ValueCount, 
                      sitePOR.stat_cd AS usgs_stat_cd, odm_variables.VariableName, CASE WHEN odm_variables.SampleMedium IS NULL 
                      THEN 'Unknown' ELSE odm_variables.SampleMedium END AS SampleMedium, odm_variables.ValueType, odm_variables.isRegular, 
                      odm_variables.GeneralCategory, odm_variables.NoDataValue, odm_variables.VariableUnitsID, odm_variables.DataType, odm_variables.VariableVocabulary, 
                      'NWISDV' AS SiteVocabulary, 'NWIS:' + dbo.USGS_sitefile.site_no AS hs_siteCode, 'NWISDV:' + dbo.USGS_sitefile.site_no AS ws_siteCode, 
                      'd' AS TimeUnitsAbbreviation, odm_variables.VariableCode AS VariableCode, odm_variables.loc_web_ds, sitePOR.parm_cd AS usgs_parm_cd, 
                      odm_variables.VariableUnitsAbbreviation, odm_variables.VariableUnitsName, odm_variables.VariableUnitsType
FROM         dbo.series AS sitePOR INNER JOIN
                      dbo.USGS_sitefile ON sitePOR.site_no = dbo.USGS_sitefile.site_no INNER JOIN
                      dbo.odm_dv_variables_wMethod AS odm_variables ON sitePOR.parm_cd = odm_variables.parameter_cd AND sitePOR.stat_cd = odm_variables.stat_cd AND 
                      ISNULL(sitePOR.loc_web_ds, '') = ISNULL(odm_variables.loc_web_ds, '')
WHERE     (sitePOR.data_type_cd = 'dv')

