CREATE TABLE [dbo].[car_equipment] (
    [id_car_equipment] INT           IDENTITY (1, 1) NOT NULL,
    [id_car_trim]      INT           NOT NULL,
    [name]             VARCHAR (255) NOT NULL,
    [year]             INT           NULL,
    [date_create]      BIGINT        NOT NULL,
    [date_update]      BIGINT        NOT NULL,
    [id_car_type]      INT           NOT NULL,
    [TRIAL109]         CHAR (1)      NULL,
    CONSTRAINT [pk_car_equipment] PRIMARY KEY CLUSTERED ([id_car_equipment] ASC),
    CONSTRAINT [fk_car_equipment_car_type] FOREIGN KEY ([id_car_type]) REFERENCES [dbo].[car_type] ([id_car_type])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_equipment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_equipment', @level2type = N'COLUMN', @level2name = N'id_car_equipment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_equipment', @level2type = N'COLUMN', @level2name = N'id_car_trim';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_equipment', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_equipment', @level2type = N'COLUMN', @level2name = N'year';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_equipment', @level2type = N'COLUMN', @level2name = N'date_create';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_equipment', @level2type = N'COLUMN', @level2name = N'date_update';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_equipment', @level2type = N'COLUMN', @level2name = N'id_car_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TRIAL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'car_equipment', @level2type = N'COLUMN', @level2name = N'TRIAL109';

