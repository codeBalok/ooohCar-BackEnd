CREATE TABLE [dbo].[VehicleCategory] (
    [VehicleCategoryId] INT           NOT NULL,
    [VehicleType]       VARCHAR (250) NULL,
    [IsActive]          BIT           NULL,
    [CreatedBy]         INT           NOT NULL,
    [CreatedDate]       DATETIME      NOT NULL,
    [UpdatedBy]         INT           NULL,
    [UpdatedDate]       DATETIME      NULL,
    CONSTRAINT [PK_VehicleCategory] PRIMARY KEY CLUSTERED ([VehicleCategoryId] ASC)
);

