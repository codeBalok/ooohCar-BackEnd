CREATE TABLE [dbo].[Images] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Image]       NVARCHAR (MAX) NULL,
    [ModelId]     INT            NULL,
    [IsActive]    BIT            NULL,
    [CreatedBy]   INT            NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Images_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[Model] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Images_ModelId]
    ON [dbo].[Images]([ModelId] ASC);

