CREATE TABLE [dbo].[car_generation] (
    [id_car_generation] INT           IDENTITY (1, 1) NOT NULL,
    [id_car_model]      INT           NOT NULL,
    [name]              VARCHAR (255) NOT NULL,
    [year_begin]        VARCHAR (255) NULL,
    [year_end]          VARCHAR (255) NULL,
    [date_create]       BIGINT        NOT NULL,
    [date_update]       BIGINT        NOT NULL,
    [id_car_type]       INT           NOT NULL,
    [TRIAL112]          CHAR (1)      NULL,
    CONSTRAINT [pk_car_generation] PRIMARY KEY CLUSTERED ([id_car_generation] ASC),
    CONSTRAINT [fk_car_generation_car_model] FOREIGN KEY ([id_car_model]) REFERENCES [dbo].[car_model] ([id_car_model]),
    CONSTRAINT [fk_car_generation_car_type] FOREIGN KEY ([id_car_type]) REFERENCES [dbo].[car_type] ([id_car_type])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation', @level2type = N'COLUMN', @level2name = N'id_car_generation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation', @level2type = N'COLUMN', @level2name = N'id_car_model';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation', @level2type = N'COLUMN', @level2name = N'year_begin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation', @level2type = N'COLUMN', @level2name = N'year_end';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation', @level2type = N'COLUMN', @level2name = N'date_create';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation', @level2type = N'COLUMN', @level2name = N'date_update';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation', @level2type = N'COLUMN', @level2name = N'id_car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_generation', @level2type = N'COLUMN', @level2name = N'TRIAL112';

