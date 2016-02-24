﻿CREATE NONCLUSTERED INDEX [ix_site_agency]
    ON [dbo].[USGS_sitefile]([site_no] ASC, [agency_cd] ASC)
    INCLUDE([station_nm], [site_tp_cd]) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0)
    ON [PRIMARY];
