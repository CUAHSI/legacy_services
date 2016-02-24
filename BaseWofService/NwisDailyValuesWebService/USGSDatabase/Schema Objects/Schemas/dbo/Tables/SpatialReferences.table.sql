CREATE TABLE [dbo].[SpatialReferences] (
    [SpatialReferenceID] INT            NOT NULL,
    [EPSGCode]           NVARCHAR (50)  NULL,
    [Name]               NVARCHAR (150) NULL,
    [IsGeographic]       BIT            NULL,
    [Notes]              NVARCHAR (500) NULL
);

