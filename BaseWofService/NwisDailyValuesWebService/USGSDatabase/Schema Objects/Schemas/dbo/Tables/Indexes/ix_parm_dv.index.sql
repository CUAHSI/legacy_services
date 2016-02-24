CREATE NONCLUSTERED INDEX [ix_parm_dv]
    ON [dbo].[series]([parm_cd] ASC, [stat_cd] ASC)
    INCLUDE([loc_web_ds], [medium_grp_cd]) WHERE ([data_type_cd]='dv') WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0)
    ON [PRIMARY];

