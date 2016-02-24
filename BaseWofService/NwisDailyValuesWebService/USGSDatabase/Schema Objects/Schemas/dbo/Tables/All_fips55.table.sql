CREATE TABLE [dbo].[All_fips55] (
    [Feature_id]     INT            NULL,
    [FIPS_st_cd]     INT            NULL,
    [FIPS_place_cd]  INT            NULL,
    [Feat_class]     NVARCHAR (30)  NULL,
    [FIPS_class]     NVARCHAR (2)   NULL,
    [Feat_name]      NVARCHAR (252) NULL,
    [State_alpha]    NVARCHAR (2)   NULL,
    [County_seq]     INT            NULL,
    [FIPS_county_cd] INT            NULL,
    [County_name]    NVARCHAR (252) NULL,
    [Primary_lat]    REAL           NULL,
    [Primary_lon]    REAL           NULL
);

