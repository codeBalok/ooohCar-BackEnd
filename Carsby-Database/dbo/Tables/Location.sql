﻿CREATE TABLE [dbo].[Location] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (250) NOT NULL,
    [IsActive]    BIT            NULL,
    [CreatedBy]   INT            NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([Id] ASC)
);
