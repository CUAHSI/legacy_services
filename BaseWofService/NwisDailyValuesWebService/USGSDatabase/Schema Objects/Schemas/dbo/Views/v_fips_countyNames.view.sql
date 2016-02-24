CREATE VIEW [dbo].[v_fips_countyNames]
WITH SCHEMABINDING 
AS
SELECT DISTINCT County_name, FIPS_county_cd
FROM         dbo.All_fips55