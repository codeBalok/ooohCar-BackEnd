CREATE TABLE [dbo].[Condition] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Condition]   NVARCHAR (250) NULL,
    [IsActive]    BIT            NULL,
    [CreatedBy]   INT            NULL,
    [CreatedDate] DATETIME       NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    CONSTRAINT [PK_Condition] PRIMARY KEY CLUSTERED ([Id] ASC)
);

