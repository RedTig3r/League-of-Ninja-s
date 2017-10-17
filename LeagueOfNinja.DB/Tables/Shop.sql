CREATE TABLE [dbo].[Shop]
(
	[ShopId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [EquipmentId] INT NOT NULL, 
    CONSTRAINT [FK_Shop_Equipment] FOREIGN KEY ([EquipmentId]) REFERENCES [dbo].[Equipment]([EquipmentId])
)
