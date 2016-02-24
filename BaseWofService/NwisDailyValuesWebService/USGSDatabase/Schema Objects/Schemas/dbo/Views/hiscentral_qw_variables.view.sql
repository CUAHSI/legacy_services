
CREATE VIEW [dbo].[hiscentral_qw_variables]
AS
SELECT     CONVERT(nvarchar(100), VariableName) AS Variable, VariableUnitsID AS UnitID, CONVERT(nvarchar(50), SampleMedium) AS SampleMedium, CONVERT(nvarchar(50), 
                      ValueType) AS ValueType, IsRegular, TimeSupport, TimeUnitsID AS TimeUnitID, CONVERT(nvarchar(50), DataType) AS DataType, CONVERT(nvarchar(50), 
                      GeneralCategory) AS GeneralCategory, CONVERT(nvarchar(50), VariableVocabulary + ':' + VariableCode) AS AltVariableCode, CONVERT(nvarchar(200), VariableName) 
                      AS AltVariableName, CONVERT(nvarchar(100), VariableUnitsAbbreviation) AS AltUnits, 2 AS networkId
FROM         dbo.odm_qw_variables AS vars

