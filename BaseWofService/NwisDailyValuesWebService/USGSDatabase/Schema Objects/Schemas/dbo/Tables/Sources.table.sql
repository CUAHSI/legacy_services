CREATE TABLE [dbo].[Sources] (
    [SourceID]     INT            NOT NULL,
    [Organization] NVARCHAR (50)  NULL,
    [Description]  NVARCHAR (255) NULL,
    [Link]         NTEXT          NULL,
    [ContactName]  NVARCHAR (50)  NULL,
    [Phone]        NVARCHAR (50)  NULL,
    [Email]        NVARCHAR (50)  NULL,
    [Address]      NVARCHAR (50)  NULL,
    [City]         NVARCHAR (50)  NULL,
    [State]        NVARCHAR (50)  NULL,
    [ZipCode]      NVARCHAR (50)  NULL,
    [MetaDataID]   INT            NULL
);

