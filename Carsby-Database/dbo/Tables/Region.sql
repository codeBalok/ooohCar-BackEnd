CREATE TABLE [dbo].[Region] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (250) NULL,
    [LocationId]  INT            NULL,
    [IsActive]    BIT            NULL,
    [CreatedBy]   INT            NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    CONSTRAINT [PK_Region1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Region_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([Id])
);

