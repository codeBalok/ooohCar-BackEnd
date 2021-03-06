﻿CREATE TABLE [dbo].[Make_Image] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [MakeId]    INT            NULL,
    [ImageName] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Make_Image] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Make_Image_ToTable] FOREIGN KEY ([MakeId]) REFERENCES [car_make]([id_car_make])
);

