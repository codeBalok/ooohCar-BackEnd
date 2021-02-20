CREATE TABLE [dbo].[SellerType] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [SellerType]  VARCHAR (250) NULL,
    [IsActive]    BIT           NULL,
    [CreatedBy]   INT           NULL,
    [CreatedDate] DATETIME      NULL,
    [UpdatedBy]   INT           NULL,
    [UpdatedDate] DATETIME      NULL,
    CONSTRAINT [PK_SellerType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

