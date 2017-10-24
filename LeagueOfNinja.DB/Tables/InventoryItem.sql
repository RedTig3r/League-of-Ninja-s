CREATE TABLE [dbo].[InventoryItem]
(


	[NinjaId] INT NOT NULL,
	[EquipmentId] INT NOT NULL,
	[IsUsingEquitment] BIT NOT NULL, 
	PRIMARY KEY ([NinjaId], [EquipmentId]),
	CONSTRAINT [FK_Inventory_Ninja] FOREIGN KEY ([NinjaId]) REFERENCES [dbo].[Ninja] ([NinjaId])  ON DELETE CASCADE,
	CONSTRAINT  [FK_Inventory_Equitment]  FOREIGN KEY ([EquipmentId]) REFERENCES [dbo].[Equipment] ([EquipmentId])  ON DELETE CASCADE, 


)
