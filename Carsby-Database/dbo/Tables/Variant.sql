CREATE TABLE [dbo].[Variant] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Varient]     NVARCHAR (250) NULL,
    [ModelId]     INT            NULL,
    [IsActive]    BIT            NULL,
    [CreatedBy]   INT            NULL,
    [CreatedDate] DATETIME       NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    [Popular]     BIT            NULL,
    CONSTRAINT [PK_Variant] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Variant_Model] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[Model] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Variant_ModelId]
    ON [dbo].[Variant]([ModelId] ASC);

