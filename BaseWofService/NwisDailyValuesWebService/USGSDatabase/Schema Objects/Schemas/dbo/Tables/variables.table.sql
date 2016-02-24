CREATE TABLE [dbo].[variables] (
    [VariableID]      INT            NOT NULL,
    [VariableName]    NVARCHAR (200) NULL,
    [VariableCode]    NVARCHAR (50)  NULL,
    [SampleMedium]    NVARCHAR (50)  NULL,
    [ValueType]       NVARCHAR (50)  NULL,
    [IsRegular]       BIT            NOT NULL,
    [TimeSupport]     INT            NULL,
    [TimeUnitsID]     INT            NULL,
    [DataType]        NVARCHAR (100) NULL,
    [GeneralCategory] NVARCHAR (50)  NULL,
    [NoDataValue]     FLOAT          NULL,
    [networkId]       INT            NULL,
    [VariableUnitsID] INT            NULL,
    [mediumCode]      NCHAR (10)     NULL
);

