CREATE TABLE [dbo].[Model] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (250) NOT NULL,
    [YearId]      INT            NOT NULL,
    [MakeId]      INT            NOT NULL,
    [IsActive]    BIT            NULL,
    [CreatedBy]   INT            NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    [Popular]     BIT            NULL,
    CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Make_Id] FOREIGN KEY ([MakeId]) REFERENCES [dbo].[Make] ([Id]),
    CONSTRAINT [FK_Year_Id] FOREIGN KEY ([YearId]) REFERENCES [dbo].[Year] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Model_MakeId]
    ON [dbo].[Model]([MakeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Model_YearId]
    ON [dbo].[Model]([YearId] ASC);

