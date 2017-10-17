CREATE TABLE [dbo].[Equipment]
(
	[EquipmentId] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Price] INT NOT NULL, 
    [Strength] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
    [Agility] INT NOT NULL, 
    [Type] NVARCHAR(50) NOT NULL, 
    [ShopId] INT NOT NULL, 
    CONSTRAINT [FK_Equipment_TypeOfEquipment] FOREIGN KEY ([Type]) REFERENCES [dbo].[TypeOfEquipment]([TypeOfEquipmentId]), 
	CONSTRAINT [FK_Equipment_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([ShopId])
)
