CREATE TABLE [dbo].[car_option] (
    [id_car_option] INT           IDENTITY (1, 1) NOT NULL,
    [name]          VARCHAR (255) NULL,
    [id_parent]     INT           NULL,
    [date_create]   BIGINT        NOT NULL,
    [date_update]   BIGINT        NOT NULL,
    [id_car_type]   INT           NOT NULL,
    [TRIAL119]      CHAR (1)      NULL,
    CONSTRAINT [pk_car_option] PRIMARY KEY CLUSTERED ([id_car_option] ASC),
    CONSTRAINT [fk_car_option_car_option] FOREIGN KEY ([id_parent]) REFERENCES [dbo].[car_option] ([id_car_option]),
    CONSTRAINT [fk_car_option_car_type] FOREIGN KEY ([id_car_type]) REFERENCES [dbo].[car_type] ([id_car_type])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option', @level2type = N'COLUMN', @level2name = N'id_car_option';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option', @level2type = N'COLUMN', @level2name = N'id_parent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option', @level2type = N'COLUMN', @level2name = N'date_create';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option', @level2type = N'COLUMN', @level2name = N'date_update';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option', @level2type = N'COLUMN', @level2name = N'id_car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option', @level2type = N'COLUMN', @level2name = N'TRIAL119';

