CREATE TABLE [dbo].[SeriesCatalog_stage] (
    [SeriesID]          INT            IDENTITY (1, 1) NOT NULL,
    [SiteCode]          VARCHAR (101)  NULL,
    [SiteName]          VARCHAR (200)  NULL,
    [VariableCodeSmall] VARCHAR (20)   NULL,
    [VariableName]      VARCHAR (200)  NULL,
    [VariableUnitsID]   INT            NULL,
    [VariableUnitsName] VARCHAR (100)  NULL,
    [SampleMedium]      VARCHAR (100)  NULL,
    [ValueType]         VARCHAR (150)  NULL,
    [BeginDateTime]     DATETIME       NOT NULL,
    [EndDateTime]       DATETIME       NOT NULL,
    [Valuecount]        INT            NOT NULL,
    [GeneralCategory]   INT            NULL,
    [UTCOffset]         INT            NULL,
    [SourceID]          INT            NOT NULL,
    [VariableCode]      NVARCHAR (100) NULL,
    [SeriesCode]        NVARCHAR (255) NULL
) WITH (DATA_COMPRESSION = PAGE);

