﻿ALTER TABLE [dbo].[Variables_stage]
    ADD CONSTRAINT [unique_altvariable_networkid_stage] UNIQUE NONCLUSTERED ([AltVariableCode] ASC, [networkId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];

