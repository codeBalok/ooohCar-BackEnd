CREATE TABLE [dbo].[Vehicle] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (250)  NOT NULL,
    [Odometers]           NVARCHAR (250)  NOT NULL,
    [BodyTypeId]          INT             NOT NULL,
    [VIN]                 NVARCHAR (250)  NULL,
    [ModelId]             INT             NULL,
    [Price]               DECIMAL (18, 2) NULL,
    [CategoryId]          INT             NULL,
    [RegistrationPlate]   NVARCHAR (250)  NULL,
    [VehicalTypeId]       INT             NULL,
    [LocationId]          INT             NULL,
    [FuelTypeId]          INT             NULL,
    [TransmissionId]      INT             NULL,
    [CylindersId]         INT             NULL,
    [FuelEconomyId]       INT             NULL,
    [EngineDescriptionId] INT             NULL,
    [MakeId]              INT             NULL,
    [Variant]             INT             NULL,
    [ConditionId]         INT             NULL,
    [Kilometer]           INT             NULL,
    [EngineSizeId]        INT             NULL,
    [AirConditioning]     VARCHAR (50)    NULL,
    [DriveTrain]          VARCHAR (100)   NULL,
    [IsActive]            BIT             NULL,
    [CreatedBy]           INT             NOT NULL,
    [CreatedDate]         DATETIME        NULL,
    [UpdatedBy]           INT             NULL,
    [UpdatedDate]         DATETIME        NULL,
    [AuctionGrade]        VARCHAR (100)   NULL,
    [ColourId]            INT             NULL,
    [IsRegistered]        VARCHAR (50)    NULL,
    [SellerTypeId]        INT             NULL,
    [VehicleCategoryId]   INT             NULL,
    [VehicleImageId]      INT             NULL,
    [YearId]              INT             NULL,
    [TowId] INT NULL, 
    [PowerId] INT NULL, 
    [PowerToWeightId] INT NULL, 
    [InductionTurboId] INT NULL, 
    [DriveTypeId] INT NULL, 
    [DoorsId] INT NULL, 
    [SeatsId] INT NULL, 
    [LifeStylesId] INT NULL, 
    [CertifiedInspectedId] INT NULL, 
    CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Body_Type] FOREIGN KEY ([BodyTypeId]) REFERENCES [dbo].[BodyType] ([Id]),
    CONSTRAINT [FK_Category_Id] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
    CONSTRAINT [FK_Cylinders] FOREIGN KEY ([CylindersId]) REFERENCES [dbo].[Cylinders] ([Id]),
    CONSTRAINT [FK_Engin_Description] FOREIGN KEY ([EngineDescriptionId]) REFERENCES [dbo].[EngineDescription] ([Id]),
    CONSTRAINT [FK_Engine_Size] FOREIGN KEY ([EngineSizeId]) REFERENCES [dbo].[EngineSize] ([Id]),
    CONSTRAINT [FK_Fuel_Economy] FOREIGN KEY ([FuelEconomyId]) REFERENCES [dbo].[FuelEconomy] ([Id]),
    CONSTRAINT [FK_Fuel_Type] FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[FuelType] ([Id]),
    CONSTRAINT [FK_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([Id]),
    CONSTRAINT [FK_Transmission] FOREIGN KEY ([TransmissionId]) REFERENCES [dbo].[Transmission] ([Id]),
    CONSTRAINT [FK_Vehicle_Colour] FOREIGN KEY ([ColourId]) REFERENCES [dbo].[Colour] ([Id]),
    CONSTRAINT [FK_Vehicle_Condition] FOREIGN KEY ([ConditionId]) REFERENCES [dbo].[Condition] ([Id]),
    CONSTRAINT [FK_Vehicle_Make] FOREIGN KEY ([MakeId]) REFERENCES [dbo].[Make] ([Id]),
    CONSTRAINT [FK_Vehicle_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[Model] ([Id]),
    CONSTRAINT [FK_Vehicle_SellerType] FOREIGN KEY ([SellerTypeId]) REFERENCES [dbo].[SellerType] ([Id]),
    CONSTRAINT [FK_Vehicle_Type] FOREIGN KEY ([VehicalTypeId]) REFERENCES [dbo].[VehicleType] ([Id]),
    CONSTRAINT [FK_Vehicle_Variant] FOREIGN KEY ([Variant]) REFERENCES [dbo].[Variant] ([Id]),
    CONSTRAINT [FK_Vehicle_VehicleCategory] FOREIGN KEY ([VehicleCategoryId]) REFERENCES [dbo].[VehicleCategory] ([VehicleCategoryId]),
    CONSTRAINT [FK_Vehicle_VehicleImage] FOREIGN KEY ([VehicleImageId]) REFERENCES [dbo].[VehicleImage] ([Id]),
    CONSTRAINT [FK_Vehicle_Year] FOREIGN KEY ([YearId]) REFERENCES [dbo].[Year] ([Id]), 
    CONSTRAINT [FK_Vehicle_Tow] FOREIGN KEY([TowId]) REFERENCES [dbo].[Tow] ([Id]),
    CONSTRAINT [FK_Vehicle_Power] FOREIGN KEY([PowerId]) REFERENCES [dbo].[Power] ([Id]),
    CONSTRAINT [FK_Vehicle_PowerToWeight] FOREIGN KEY([PowerToWeightId]) REFERENCES [dbo].[PowerToWeight] ([Id]),
    CONSTRAINT [FK_Vehicle_InductionTurbo] FOREIGN KEY([InductionTurboId]) REFERENCES [dbo].[InductionTurbo] ([Id]),
    CONSTRAINT [FK_Vehicle_Doors] FOREIGN KEY([DoorsId]) REFERENCES [dbo].[Doors] ([Id]),
    CONSTRAINT [FK_Vehicle_Seats] FOREIGN KEY([SeatsId]) REFERENCES [dbo].[Seats] ([Id]),
    CONSTRAINT [FK_Vehicle_LifeStyles] FOREIGN KEY([LifeStylesId]) REFERENCES [dbo].[LifeStyles] ([Id]),
    CONSTRAINT [FK_Vehicle_CertifiedInspected] FOREIGN KEY([CertifiedInspectedId]) REFERENCES [dbo].[CertifiedInspected] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_BodyTypeId]
    ON [dbo].[Vehicle]([BodyTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_CategoryId]
    ON [dbo].[Vehicle]([CategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_ColourId]
    ON [dbo].[Vehicle]([ColourId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_ConditionId]
    ON [dbo].[Vehicle]([ConditionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_CylindersId]
    ON [dbo].[Vehicle]([CylindersId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_EngineDescriptionId]
    ON [dbo].[Vehicle]([EngineDescriptionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_EngineSizeId]
    ON [dbo].[Vehicle]([EngineSizeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_FuelEconomyId]
    ON [dbo].[Vehicle]([FuelEconomyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_FuelTypeId]
    ON [dbo].[Vehicle]([FuelTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_LocationId]
    ON [dbo].[Vehicle]([LocationId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_MakeId]
    ON [dbo].[Vehicle]([MakeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_ModelId]
    ON [dbo].[Vehicle]([ModelId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_SellerTypeId]
    ON [dbo].[Vehicle]([SellerTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_TransmissionId]
    ON [dbo].[Vehicle]([TransmissionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_Variant]
    ON [dbo].[Vehicle]([Variant] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_VehicalTypeId]
    ON [dbo].[Vehicle]([VehicalTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_VehicleCategoryId]
    ON [dbo].[Vehicle]([VehicleCategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_VehicleImageId]
    ON [dbo].[Vehicle]([VehicleImageId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_YearId]
    ON [dbo].[Vehicle]([YearId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_TowId] 
    ON [dbo].[Vehicle]([TowId] ASC);

GO 
CREATE NONCLUSTERED INDEX [IX_Vehicle_PowerId]
  ON [dbo].[Vehicle]([PowerId] ASC);

GO

CREATE NONCLUSTERED INDEX [IX_Vehicle_PowerToWeightId] 
 ON [dbo].[Vehicle]([PowerToWeightId] ASC);
 
GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_InductionTurboId] 
  ON [dbo].[Vehicle]([InductionTurboId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Vehicle_DriveTypeId]
ON [dbo].[Vehicle](	[DriveTypeId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_DoorsId]
ON [dbo].[Vehicle](	[DoorsId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_SeatsId]
ON [dbo].[Vehicle](	[SeatsId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_LifeStylesId]
ON [dbo].[Vehicle](	[LifeStylesId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_CertifiedInspectedId]
ON [dbo].[Vehicle](	[CertifiedInspectedId] ASC);
