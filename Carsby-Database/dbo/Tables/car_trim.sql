CREATE TABLE [dbo].[car_trim] (
    [id_car_trim]           INT           IDENTITY (1, 1) NOT NULL,
    [id_car_serie]          INT           NOT NULL,
    [id_car_model]          INT           NOT NULL,
    [name]                  VARCHAR (255) NOT NULL,
    [start_production_year] INT           NULL,
    [end_production_year]   INT           NULL,
    [date_create]           BIGINT        NOT NULL,
    [date_update]           BIGINT        NOT NULL,
    [id_car_type]           INT           NOT NULL,
    [TRIAL148]              CHAR (1)      NULL,
    CONSTRAINT [pk_car_trim] PRIMARY KEY CLUSTERED ([id_car_trim] ASC),
    CONSTRAINT [fk_car_trim_car_model] FOREIGN KEY ([id_car_model]) REFERENCES [dbo].[car_model] ([id_car_model]),
    CONSTRAINT [fk_car_trim_car_serie] FOREIGN KEY ([id_car_serie]) REFERENCES [dbo].[car_serie] ([id_car_serie]),
    CONSTRAINT [fk_car_trim_car_type] FOREIGN KEY ([id_car_type]) REFERENCES [dbo].[car_type] ([id_car_type])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'id_car_trim';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'id_car_serie';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'id_car_model';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'start_production_year';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'end_production_year';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'date_create';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'date_update';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'id_car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_trim', @level2type = N'COLUMN', @level2name = N'TRIAL148';

