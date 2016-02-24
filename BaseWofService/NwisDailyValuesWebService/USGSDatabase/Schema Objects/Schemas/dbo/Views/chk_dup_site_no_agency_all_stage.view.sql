
CREATE VIEW [dbo].[chk_dup_site_no_agency_all_stage]
AS
SELECT     site_no, agency_cd, site_tp_cd, COUNT(state_cd) AS count
FROM         dbo.USGS_sitefile_stage
GROUP BY site_no, agency_cd, site_tp_cd
HAVING      (COUNT(state_cd) > 1)

