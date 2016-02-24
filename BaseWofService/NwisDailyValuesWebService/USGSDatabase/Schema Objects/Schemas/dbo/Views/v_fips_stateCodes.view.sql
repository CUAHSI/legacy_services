
CREATE VIEW [dbo].[v_fips_stateCodes]
WITH SCHEMABINDING 
AS
SELECT DISTINCT FIPS_st_cd, State_alpha
FROM         dbo.All_fips55
