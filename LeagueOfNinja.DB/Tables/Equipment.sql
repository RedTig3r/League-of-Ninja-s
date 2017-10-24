﻿CREATE TABLE [dbo].[Equipment]
(
	[EquitmentId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
    [EquipmentValue] INT NOT NULL, 
	[EquitmentType] nvarchar(50) NOT NULL, 
	[ShopId] INT NOT NULL,
    CONSTRAINT [FK_Equipment_TypeOfEquitment] FOREIGN KEY ([EquitmentType]) REFERENCES [dbo].[TypeOfEquipment]([EquitmentType])  ON DELETE CASCADE, 
    CONSTRAINT [FK_Equipment_Shop] FOREIGN KEY ([ShopId]) REFERENCES [dbo].[Shop]([ShopId])
)
