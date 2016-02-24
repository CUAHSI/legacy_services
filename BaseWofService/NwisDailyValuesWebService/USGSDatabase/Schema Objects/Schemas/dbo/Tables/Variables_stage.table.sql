CREATE TABLE [dbo].[Variables_stage] (
    [Variable]        NVARCHAR (100) NULL,
    [UnitID]          INT            NULL,
    [SampleMedium]    NVARCHAR (50)  NULL,
    [ValueType]       NVARCHAR (50)  NULL,
    [IsRegular]       BIT            NULL,
    [TimeSupport]     INT            NULL,
    [TimeUnitID]      INT            NULL,
    [DataType]        NVARCHAR (50)  NULL,
    [GeneralCategory] NVARCHAR (50)  NULL,
    [AltVariableCode] VARCHAR (50)   NULL,
    [AltVariableName] VARCHAR (200)  NULL,
    [AltUnits]        VARCHAR (100)  NULL,
    [networkId]       INT            NULL
);

