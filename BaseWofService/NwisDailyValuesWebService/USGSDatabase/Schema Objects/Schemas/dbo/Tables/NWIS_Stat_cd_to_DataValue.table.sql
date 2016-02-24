CREATE TABLE [dbo].[NWIS_Stat_cd_to_DataValue] (
    [stat_cd]         NVARCHAR (50)  NOT NULL,
    [USGSDescription] NVARCHAR (100) NULL,
    [DataType]        NVARCHAR (50)  NULL,
    [isDataType]      BIT            NULL,
    [isTimeReference] BIT            NULL,
    [Time]            NVARCHAR (50)  NULL
);

