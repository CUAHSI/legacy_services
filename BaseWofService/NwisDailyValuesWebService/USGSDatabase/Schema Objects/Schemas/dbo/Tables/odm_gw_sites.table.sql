CREATE TABLE [dbo].[odm_gw_sites] (
    [SiteID]                       VARCHAR (16)   NULL,
    [SiteCode]                     VARCHAR (32)   NULL,
    [SiteName]                     VARCHAR (100)  NULL,
    [Latitude]                     VARCHAR (20)   NULL,
    [Longitude]                    VARCHAR (20)   NULL,
    [LatLongDatumID]               INT            NULL,
    [Elevation_m]                  VARCHAR (8)    NULL,
    [VerticalDatum]                VARCHAR (16)   NULL,
    [PosAccuracy_m]                INT            NULL,
    [County]                       NVARCHAR (252) NULL,
    [State]                        NVARCHAR (2)   NULL,
    [Comments]                     INT            NULL,
    [odws_timeZoneName]            VARCHAR (8)    NULL,
    [odws_UsesDaylightSavingsTime] VARCHAR (2)    NULL,
    [usgs_State_fipCode]           VARCHAR (2)    NULL,
    [Usgs_County_fipsCode]         VARCHAR (3)    NULL,
    [usgs_agency]                  VARCHAR (8)    NULL,
    [SiteVocabulary]               VARCHAR (6)    NOT NULL,
    [hs_SiteCode]                  VARCHAR (23)   NULL,
    [usgs_huc]                     VARCHAR (20)   NULL,
    [HUCNUMERIC]                   VARCHAR (30)   NULL
);

