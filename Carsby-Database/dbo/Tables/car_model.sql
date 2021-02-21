CREATE TABLE [dbo].[car_model] (
    [id_car_model] INT           IDENTITY (1, 1) NOT NULL,
    [id_car_make]  INT           NOT NULL,
    [name]         VARCHAR (255) NOT NULL,
    [date_create]  BIGINT        NOT NULL,
    [date_update]  BIGINT        NOT NULL,
    [id_car_type]  INT           NOT NULL,
    [TRIAL116]     CHAR (1)      NULL,
    CONSTRAINT [pk_car_model] PRIMARY KEY CLUSTERED ([id_car_model] ASC),
    CONSTRAINT [fk_car_model_car_make] FOREIGN KEY ([id_car_make]) REFERENCES [dbo].[car_make] ([id_car_make]),
    CONSTRAINT [fk_car_model_car_type] FOREIGN KEY ([id_car_type]) REFERENCES [dbo].[car_type] ([id_car_type])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_model';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_model', @level2type = N'COLUMN', @level2name = N'id_car_model';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_model', @level2type = N'COLUMN', @level2name = N'id_car_make';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_model', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_model', @level2type = N'COLUMN', @level2name = N'date_create';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_model', @level2type = N'COLUMN', @level2name = N'date_update';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_model', @level2type = N'COLUMN', @level2name = N'id_car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_model', @level2type = N'COLUMN', @level2name = N'TRIAL116';

