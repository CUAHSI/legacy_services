
CREATE VIEW [dbo].[qw_seriesPOR__odm_w_medium]
AS
SELECT     agency_cd, site_no, parm_cd, medium_grp_cd, site_tp_cd, MIN(beginDate) AS beginDateTime, COUNT(medium_grp_cd) AS mediumCount, MAX(endDate) AS endDateTime, 
                      MAX(count_nu) AS ValueCount
FROM         dbo.series AS sitesPOR
WHERE     (data_type_cd = 'qw')
GROUP BY site_no, parm_cd, agency_cd, medium_grp_cd, site_tp_cd

