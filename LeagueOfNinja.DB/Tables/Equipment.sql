CREATE TABLE [dbo].[Equipment]
(
	[EquipmentId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
    [EquipmentValue] INT NOT NULL, 
	[EquipmentType] nvarchar(50) NOT NULL, 
    CONSTRAINT [FK_Equipment_TypeOfEquipment] FOREIGN KEY ([EquipmentType]) REFERENCES [dbo].[TypeOfEquipment]([EquipmentType])  ON DELETE CASCADE, 
)
