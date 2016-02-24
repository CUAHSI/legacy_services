CREATE NONCLUSTERED INDEX [is_datatype]
    ON [dbo].[series]([data_type_cd] ASC)
    INCLUDE([agency_cd], [site_no], [parm_cd], [stat_cd], [loc_web_ds], [medium_grp_cd], [count_nu], [beginDate], [endDate]) WHERE ([parm_cd] IS NOT NULL AND [parm_cd]<>'00000') WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0)
    ON [PRIMARY];

