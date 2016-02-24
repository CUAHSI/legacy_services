ALTER TABLE [dbo].[series]
    ADD CONSTRAINT [DF_series_AddedDate] DEFAULT (getdate()) FOR [AddedDate];

