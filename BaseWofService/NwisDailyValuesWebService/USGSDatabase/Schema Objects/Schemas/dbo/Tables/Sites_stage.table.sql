CREATE TABLE [dbo].[Sites_stage] (
    [SiteCode]          VARCHAR (101) NOT NULL,
    [SiteName]          VARCHAR (200) NULL,
    [Latitude]          FLOAT         NULL,
    [Longitude]         FLOAT         NULL,
    [LatLongDatumID]    VARCHAR (150) NULL,
    [Elevation_m]       REAL          NULL,
    [VerticalDatum]     VARCHAR (50)  NULL,
    [LocalX]            FLOAT         NULL,
    [LocalY]            FLOAT         NULL,
    [LocalProjectionID] INT           NULL,
    [PosAccuracy_m]     REAL          NULL,
    [StateName]         VARCHAR (120) NULL,
    [County]            VARCHAR (50)  NULL,
    [Comments]          VARCHAR (150) NULL,
    [OrganizationName]  VARCHAR (80)  NULL,
    [HUC]               VARCHAR (12)  NULL,
    [HUCnumeric]        DECIMAL (18)  NULL,
    [NetworkID]         INT           NOT NULL
) WITH (DATA_COMPRESSION = PAGE);

