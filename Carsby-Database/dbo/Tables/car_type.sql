CREATE TABLE [dbo].[car_type] (
    [id_car_type] INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (255) NOT NULL,
    [TRIAL152]    CHAR (1)      NULL,
    CONSTRAINT [pk_car_type] PRIMARY KEY CLUSTERED ([id_car_type] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_type', @level2type = N'COLUMN', @level2name = N'id_car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_type', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_type', @level2type = N'COLUMN', @level2name = N'TRIAL152';

