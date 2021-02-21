CREATE TABLE [dbo].[car_option_value] (
    [id_car_option_value] INT      IDENTITY (1, 1) NOT NULL,
    [id_car_option]       INT      NOT NULL,
    [id_car_equipment]    INT      NOT NULL,
    [is_base]             SMALLINT DEFAULT ((1)) NOT NULL,
    [date_create]         BIGINT   NOT NULL,
    [date_update]         BIGINT   NOT NULL,
    [id_car_type]         INT      NOT NULL,
    [TRIAL122]            CHAR (1) NULL,
    CONSTRAINT [pk_car_option_value] PRIMARY KEY CLUSTERED ([id_car_option_value] ASC),
    CONSTRAINT [fk_car_option_value_car_equipment] FOREIGN KEY ([id_car_equipment]) REFERENCES [dbo].[car_equipment] ([id_car_equipment]),
    CONSTRAINT [fk_car_option_value_car_option] FOREIGN KEY ([id_car_option]) REFERENCES [dbo].[car_option] ([id_car_option]),
    CONSTRAINT [fk_car_option_value_car_type] FOREIGN KEY ([id_car_type]) REFERENCES [dbo].[car_type] ([id_car_type])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option_value';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option_value', @level2type = N'COLUMN', @level2name = N'id_car_option_value';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option_value', @level2type = N'COLUMN', @level2name = N'id_car_option';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option_value', @level2type = N'COLUMN', @level2name = N'id_car_equipment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option_value', @level2type = N'COLUMN', @level2name = N'is_base';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option_value', @level2type = N'COLUMN', @level2name = N'date_create';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option_value', @level2type = N'COLUMN', @level2name = N'date_update';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option_value', @level2type = N'COLUMN', @level2name = N'id_car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_option_value', @level2type = N'COLUMN', @level2name = N'TRIAL122';

