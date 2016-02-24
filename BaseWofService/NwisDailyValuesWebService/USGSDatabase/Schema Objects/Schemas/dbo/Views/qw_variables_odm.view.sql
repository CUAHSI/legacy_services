
CREATE VIEW [dbo].[qw_variables_odm]
WITH SCHEMABINDING 
AS
SELECT     dbo.variables.VariableID, usedVariables.parm_cd 
                       + CASE WHEN usedVariables.Count = 1 THEN '' ELSE '' END AS VariableCode, dbo.variables.VariableName, 
                     null AS SampleMedium, 
                      'Sample' AS ValueType, 'false' AS IsRegular, 0 AS TimeSupport, 102 AS TimeUnitsID, 'Sproadic' AS DataType, dbo.variables.GeneralCategory, 
                      dbo.variables.NoDataValue, dbo.variables.VariableUnitsID, null as MediumCode, 'NWISQW' AS VariableVocabulary, 
                      'm' AS TimeUnitsAbbreviation, 'minute' AS TimeUnitsName, dbo.Units.UnitAbbreviation AS VariableUnitsAbbreviation, dbo.Units.UnitType AS VariableUnitsType, 
                      dbo.Units.Units AS VariableUnitsName, usedVariables.parm_cd
FROM         dbo.variables INNER JOIN
                          (SELECT     parm_cd, COUNT(parm_cd) AS Count
                            FROM          dbo.series
                            WHERE      (data_type_cd = 'qw')
                            GROUP BY parm_cd) AS usedVariables ON dbo.variables.VariableCode = usedVariables.parm_cd LEFT OUTER JOIN
                      dbo.Units ON dbo.variables.VariableUnitsID = dbo.Units.UnitID

