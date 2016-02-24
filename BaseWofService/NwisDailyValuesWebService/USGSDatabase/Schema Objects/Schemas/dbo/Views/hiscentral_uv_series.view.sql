
CREATE VIEW [dbo].[hiscentral_uv_series]
AS
SELECT     CONVERT(varchar(101), SiteVocabulary + ':' + SiteCode) AS SiteCode, CONVERT(varchar(200), siteName) AS SiteName, CONVERT(varchar(20), VariableCode) 
                      AS VariableCodeSmall, CONVERT(varchar(200), VariableName) AS AltVariableName, VariableUnitsID, CONVERT(varchar(100), VariableUnitsName) 
                      AS VariableUnitsName, CONVERT(varchar(100), SampleMedium) AS SampleMedium, CONVERT(varchar(150), ValueType) AS ValueType, beginDateTime, EndDateTime, 
                      ValueCount, NULL AS GeneralCategory, NULL AS UTCOffset, 3 AS SourceID, CONVERT(nvarchar(100), VariableVocabulary + ':' + VariableCode) AS VariableCode, 
                      CONVERT(nvarchar(255), SiteVocabulary + ':' + SiteCode + '|' + VariableVocabulary + ':' + VariableCode) AS SeriesCode
FROM         dbo.odm_uv_series

