
CREATE VIEW [dbo].[uv_variables_odm_w_method]
AS
SELECT     dbo.variables.VariableID, usedVariables.VariableCode + CASE WHEN usedVariables.loc_web_ds IS NULL 
                      THEN '' ELSE '/method=' + usedVariables.loc_web_ds END AS VariableCode, dbo.variables.VariableName, dbo.variables.SampleMedium, 'Unknown' AS ValueType, 
                      'true' AS IsRegular, 15 AS TimeSupport, 102 AS TimeUnitsID, 'Continuous' AS DataType, dbo.variables.GeneralCategory, dbo.variables.NoDataValue, 
                      dbo.variables.networkId, dbo.variables.VariableUnitsID, dbo.variables.mediumCode, 'NWISUV' AS VariableVocabulary, 'm' AS TimeUnitsAbbreviation, 
                      'minute' AS TimeUnitsName, dbo.Units.UnitAbbreviation AS VariableUnitsAbbreviation, dbo.Units.UnitType AS VariableUnitsType, 
                      dbo.Units.Units AS VariableUnitsName, usedVariables.VariableCode AS parm_cd, usedVariables.loc_web_ds
FROM         dbo.variables INNER JOIN
                          (SELECT     parm_cd AS VariableCode, loc_web_ds, COUNT(parm_cd) AS Count
                            FROM          dbo.series
                            WHERE      (data_type_cd = 'uv')
                            GROUP BY parm_cd, loc_web_ds) AS usedVariables ON dbo.variables.VariableCode = usedVariables.VariableCode LEFT OUTER JOIN
                      dbo.Units ON dbo.variables.VariableUnitsID = dbo.Units.UnitID
WHERE     (dbo.variables.VariableID IS NOT NULL)

