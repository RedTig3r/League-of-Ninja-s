CREATE TABLE [dbo].[Equipment]
(
	[EquitmentId] INT NOT NULL PRIMARY KEY,
	[Name] nvarchar(50) NOT NULL,
    [EquipmentValue] INT NOT NULL, 
	[EquitmentType] nvarchar(50) NOT NULL, 
	[ShopId] INT NOT NULL,
    CONSTRAINT [FK_Equipment_TypeOfEquitment] FOREIGN KEY ([EquitmentType]) REFERENCES [dbo].[TypeOfEquipment]([EquitmentType]), 
    CONSTRAINT [FK_Equipment_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([ShopId])
)
