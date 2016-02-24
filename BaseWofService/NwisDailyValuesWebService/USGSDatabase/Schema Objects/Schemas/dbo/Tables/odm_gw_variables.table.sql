﻿CREATE TABLE [dbo].[odm_gw_variables] (
    [VariableID]                INT            NOT NULL,
    [VariableCode]              VARCHAR (66)   NULL,
    [VariableName]              NVARCHAR (200) NULL,
    [SampleMedium]              NVARCHAR (50)  NULL,
    [ValueType]                 VARCHAR (17)   NOT NULL,
    [IsRegular]                 VARCHAR (4)    NOT NULL,
    [TimeSupport]               INT            NOT NULL,
    [TimeUnitsID]               INT            NOT NULL,
    [DataType]                  VARCHAR (8)    NOT NULL,
    [GeneralCategory]           NVARCHAR (50)  NULL,
    [NoDataValue]               FLOAT          NULL,
    [networkId]                 INT            NULL,
    [VariableUnitsID]           INT            NULL,
    [mediumCode]                NCHAR (10)     NULL,
    [VariableVocabulary]        VARCHAR (6)    NOT NULL,
    [TimeUnitsAbbreviation]     VARCHAR (1)    NOT NULL,
    [TimeUnitsName]             VARCHAR (3)    NOT NULL,
    [VariableUnitsAbbreviation] NVARCHAR (50)  NULL,
    [VariableUnitsType]         NVARCHAR (50)  NULL,
    [VariableUnitsName]         NVARCHAR (50)  NULL,
    [hs_variableCode]           NVARCHAR (55)  NULL,
    [hs_newVariableCode]        NVARCHAR (57)  NULL,
    [seriesCount]               INT            NULL
);

