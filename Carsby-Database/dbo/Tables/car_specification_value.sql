CREATE TABLE [dbo].[car_specification_value] (
    [id_car_specification_value] INT           IDENTITY (1, 1) NOT NULL,
    [id_car_trim]                INT           NOT NULL,
    [id_car_specification]       INT           NOT NULL,
    [value]                      VARCHAR (500) NOT NULL,
    [unit]                       VARCHAR (255) NULL,
    [date_create]                BIGINT        NOT NULL,
    [date_update]                BIGINT        NOT NULL,
    [id_car_type]                INT           NOT NULL,
    [TRIAL132]                   CHAR (1)      NULL,
    CONSTRAINT [pk_car_specification_value] PRIMARY KEY CLUSTERED ([id_car_specification_value] ASC),
    CONSTRAINT [fk_car_specification_value_car_specification] FOREIGN KEY ([id_car_specification]) REFERENCES [dbo].[car_specification] ([id_car_specification]),
    CONSTRAINT [fk_car_specification_value_car_trim] FOREIGN KEY ([id_car_trim]) REFERENCES [dbo].[car_trim] ([id_car_trim]),
    CONSTRAINT [fk_car_specification_value_car_type] FOREIGN KEY ([id_car_type]) REFERENCES [dbo].[car_type] ([id_car_type])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value', @level2type = N'COLUMN', @level2name = N'id_car_specification_value';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value', @level2type = N'COLUMN', @level2name = N'id_car_trim';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value', @level2type = N'COLUMN', @level2name = N'id_car_specification';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value', @level2type = N'COLUMN', @level2name = N'value';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value', @level2type = N'COLUMN', @level2name = N'unit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value', @level2type = N'COLUMN', @level2name = N'date_create';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value', @level2type = N'COLUMN', @level2name = N'date_update';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value', @level2type = N'COLUMN', @level2name = N'id_car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_specification_value', @level2type = N'COLUMN', @level2name = N'TRIAL132';

