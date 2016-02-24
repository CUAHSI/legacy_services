CREATE VIEW [dbo].[v_fips_countyCodes]
WITH SCHEMABINDING 
AS
SELECT DISTINCT FIPS_st_cd, FIPS_county_cd, County_name AS County, State_alpha AS State
FROM         dbo.All_fips55
