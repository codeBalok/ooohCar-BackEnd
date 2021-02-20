CREATE TABLE [dbo].[Price] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Amount]      DECIMAL (18, 2) NULL,
    [IsActive]    BIT             NULL,
    [CreatedBy]   INT             NOT NULL,
    [CreatedDate] DATETIME        NOT NULL,
    [UpdatedBy]   INT             NULL,
    [UpdatedDate] DATETIME        NULL,
    CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED ([Id] ASC)
);

