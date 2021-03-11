CREATE TABLE [dbo].[VehicleImage] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Image]       NVARCHAR (MAX) NULL,
    [VehicleId]     INT            NULL,
    [IsActive]    BIT            NULL,
    [CreatedBy]   INT            NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    CONSTRAINT [PK_VehicleImage] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_VehicleImage_Vehicle] FOREIGN KEY ([Id]) REFERENCES [Vehicle]([Id])
);

