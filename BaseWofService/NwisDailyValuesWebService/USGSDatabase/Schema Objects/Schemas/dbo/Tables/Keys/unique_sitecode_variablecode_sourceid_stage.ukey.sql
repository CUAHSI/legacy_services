﻿ALTER TABLE [dbo].[SeriesCatalog_stage]
    ADD CONSTRAINT [unique_sitecode_variablecode_sourceid_stage] UNIQUE NONCLUSTERED ([SeriesCode] ASC, [SourceID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];

