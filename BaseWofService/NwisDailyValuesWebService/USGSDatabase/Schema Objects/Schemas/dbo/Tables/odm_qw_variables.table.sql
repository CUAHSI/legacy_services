CREATE TABLE [dbo].[odm_qw_variables] (
    [VariableID]                INT            NOT NULL,
    [VariableCode]              VARCHAR (9)    NULL,
    [VariableName]              NVARCHAR (200) NULL,
    [SampleMedium]              INT            NULL,
    [ValueType]                 VARCHAR (6)    NOT NULL,
    [IsRegular]                 VARCHAR (5)    NOT NULL,
    [TimeSupport]               INT            NOT NULL,
    [TimeUnitsID]               INT            NOT NULL,
    [DataType]                  VARCHAR (8)    NOT NULL,
    [GeneralCategory]           NVARCHAR (50)  NULL,
    [NoDataValue]               FLOAT          NULL,
    [VariableUnitsID]           INT            NULL,
    [MediumCode]                INT            NULL,
    [VariableVocabulary]        VARCHAR (6)    NOT NULL,
    [TimeUnitsAbbreviation]     VARCHAR (1)    NOT NULL,
    [TimeUnitsName]             VARCHAR (6)    NOT NULL,
    [VariableUnitsAbbreviation] NVARCHAR (50)  NULL,
    [VariableUnitsType]         NVARCHAR (50)  NULL,
    [VariableUnitsName]         NVARCHAR (50)  NULL,
    [parm_cd]                   VARCHAR (8)    NULL
);

