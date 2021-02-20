CREATE TABLE [dbo].[Comment] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Comment]     NVARCHAR (MAX) NOT NULL,
    [VehicleId]   INT            NULL,
    [UserId]      INT            NULL,
    [UserType]    NVARCHAR (50)  NULL,
    [IsActive]    BIT            NULL,
    [CreatedBy]   INT            NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [UpdatedBy]   INT            NULL,
    [UpdatedDate] DATETIME       NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([Id] ASC)
);

