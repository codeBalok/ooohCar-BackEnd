CREATE TABLE [dbo].[ModelColour] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [ModelId]     INT      NULL,
    [ColourId]    INT      NULL,
    [IsActive]    BIT      NULL,
    [CreatedBy]   INT      NOT NULL,
    [CreatedDate] DATETIME NOT NULL,
    [UpdatedBy]   INT      NULL,
    [UpdatedDate] DATETIME NULL,
    CONSTRAINT [PK_ModelColour] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ModelColour_Colour] FOREIGN KEY ([ColourId]) REFERENCES [dbo].[Colour] ([Id]),
    CONSTRAINT [FK_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[Model] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ModelColour_ColourId]
    ON [dbo].[ModelColour]([ColourId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ModelColour_ModelId]
    ON [dbo].[ModelColour]([ModelId] ASC);

