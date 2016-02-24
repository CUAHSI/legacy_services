CREATE TABLE [dbo].[nwis_translate_usgs_parm_list_units] (
    [varTranslateID]       INT           NOT NULL,
    [odm_UnitAbbreviation] NVARCHAR (50) NULL,
    [usgs_parm_unt_tx]     NVARCHAR (50) NOT NULL,
    [MatchBy]              NVARCHAR (50) NULL,
    [MatchDate]            DATETIME      NULL
);

