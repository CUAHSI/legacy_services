CREATE TABLE [dbo].[nwis_tomezones] (
    [timeZoneID]        INT           NOT NULL,
    [usgs_timeZoneCode] NVARCHAR (10) NOT NULL,
    [timeZoneName]      NVARCHAR (50) NULL,
    [timeZoneOffset]    FLOAT         NULL,
    [CreatedOn]         DATETIME      NOT NULL
);

