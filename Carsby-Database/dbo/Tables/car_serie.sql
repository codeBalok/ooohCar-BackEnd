CREATE TABLE [dbo].[car_serie] (
    [id_car_serie]      INT           IDENTITY (1, 1) NOT NULL,
    [id_car_model]      INT           NOT NULL,
    [id_car_generation] INT           NULL,
    [name]              VARCHAR (255) NOT NULL,
    [date_create]       BIGINT        NOT NULL,
    [date_update]       BIGINT        NOT NULL,
    [id_car_type]       INT           NOT NULL,
    [TRIAL129]          CHAR (1)      NULL,
    CONSTRAINT [pk_car_serie] PRIMARY KEY CLUSTERED ([id_car_serie] ASC),
    CONSTRAINT [fk_car_serie_car_generation] FOREIGN KEY ([id_car_generation]) REFERENCES [dbo].[car_generation] ([id_car_generation]),
    CONSTRAINT [fk_car_serie_car_model] FOREIGN KEY ([id_car_model]) REFERENCES [dbo].[car_model] ([id_car_model]),
    CONSTRAINT [fk_car_serie_car_type] FOREIGN KEY ([id_car_type]) REFERENCES [dbo].[car_type] ([id_car_type])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_serie';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_serie', @level2type = N'COLUMN', @level2name = N'id_car_serie';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_serie', @level2type = N'COLUMN', @level2name = N'id_car_model';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_serie', @level2type = N'COLUMN', @level2name = N'id_car_generation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_serie', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_serie', @level2type = N'COLUMN', @level2name = N'date_create';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_serie', @level2type = N'COLUMN', @level2name = N'date_update';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_serie', @level2type = N'COLUMN', @level2name = N'id_car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_serie', @level2type = N'COLUMN', @level2name = N'TRIAL129';

