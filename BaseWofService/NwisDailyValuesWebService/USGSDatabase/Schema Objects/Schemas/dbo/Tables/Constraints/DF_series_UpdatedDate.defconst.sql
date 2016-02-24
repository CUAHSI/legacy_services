ALTER TABLE [dbo].[series]
    ADD CONSTRAINT [DF_series_UpdatedDate] DEFAULT (getdate()) FOR [UpdatedDate];

