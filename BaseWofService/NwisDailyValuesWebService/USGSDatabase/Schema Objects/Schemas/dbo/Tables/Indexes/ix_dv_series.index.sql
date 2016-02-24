CREATE NONCLUSTERED INDEX [ix_dv_series]
    ON [dbo].[series]([agency_cd] ASC, [site_no] ASC, [parm_cd] ASC, [stat_cd] ASC, [medium_grp_cd] ASC, [site_tp_cd] ASC)
    INCLUDE([count_nu], [beginDate], [endDate]) WHERE ([data_type_cd]='dv') WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0)
    ON [PRIMARY];

