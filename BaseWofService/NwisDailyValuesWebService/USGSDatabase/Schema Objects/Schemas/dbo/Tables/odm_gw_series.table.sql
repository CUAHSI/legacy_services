﻿CREATE TABLE [dbo].[odm_gw_series] (
    [siteID]                    VARCHAR (16)   NULL,
    [SiteCode]                  VARCHAR (32)   NULL,
    [siteName]                  VARCHAR (100)  NULL,
    [VariableCode]              VARCHAR (66)   NULL,
    [VariableID]                INT            NOT NULL,
    [VariableName]              NVARCHAR (200) NULL,
    [SampleMedium]              NVARCHAR (50)  NULL,
    [ValueType]                 VARCHAR (17)   NOT NULL,
    [GeneralCategory]           NVARCHAR (50)  NULL,
    [MethodID]                  INT            NULL,
    [MethodName]                VARCHAR (255)  NULL,
    [SourceID]                  INT            NOT NULL,
    [Organization]              VARCHAR (4)    NOT NULL,
    [SourceDescription]         VARCHAR (9)    NOT NULL,
    [QualityControlLevelID]     VARCHAR (1)    NOT NULL,
    [beginDateTime]             DATE           NULL,
    [EndDateTime]               DATE           NULL,
    [ValueCount]                INT            NULL,
    [usgs_agency]               VARCHAR (8)    NULL,
    [QualityControlLevelName]   VARCHAR (8)    NOT NULL,
    [SiteVocabulary]            VARCHAR (6)    NOT NULL,
    [VariableVocabulary]        VARCHAR (6)    NOT NULL,
    [hs_variableCode]           VARCHAR (71)   NULL,
    [hs_siteCode]               VARCHAR (21)   NULL,
    [ws_variableCode]           VARCHAR (73)   NULL,
    [ws_siteCode]               VARCHAR (23)   NULL,
    [IsRegular]                 VARCHAR (4)    NOT NULL,
    [DataType]                  VARCHAR (8)    NOT NULL,
    [TimeSupport]               INT            NOT NULL,
    [TimeUnitsID]               INT            NOT NULL,
    [TimeUnitsAbbreviation]     VARCHAR (1)    NOT NULL,
    [TimeUnitsName]             VARCHAR (3)    NOT NULL,
    [VariableUnitsAbbreviation] NVARCHAR (50)  NULL,
    [VariableUnitsType]         NVARCHAR (50)  NULL,
    [VariableUnitsName]         NVARCHAR (50)  NULL,
    [VariableUnitsID]           INT            NULL
);

