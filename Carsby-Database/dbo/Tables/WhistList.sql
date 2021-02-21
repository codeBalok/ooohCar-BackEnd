CREATE TABLE [dbo].[WhistList] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [VehicleId]   INT            NULL,
    [UserID]      NVARCHAR (450) NULL,
    [IsFavourite] BIT            NULL,
    CONSTRAINT [PK_WhistList] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_WhistList_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

