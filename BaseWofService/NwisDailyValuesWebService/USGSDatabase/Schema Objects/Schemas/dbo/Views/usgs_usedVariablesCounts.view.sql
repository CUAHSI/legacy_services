
CREATE VIEW [dbo].[usgs_usedVariablesCounts]
WITH SCHEMABINDING 
AS
SELECT     data_type_cd, parm_cd, ISNULL(stat_cd, '') AS stat_cd, ISNULL(loc_web_ds, '') AS loc_web_ds, medium_grp_cd, COUNT_BIG(*) AS count
FROM         dbo.series
WHERE     (parm_cd IS NOT NULL) AND (NOT (parm_cd = '00000'))
GROUP BY data_type_cd, parm_cd, stat_cd, loc_web_ds, medium_grp_cd

