CREATE TABLE [dbo].[Doors] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (250) NOT NULL,
    [IsActive]    BIT            NULL,
    [CreatedBy]   INT            NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    CONSTRAINT [PK_Doors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

