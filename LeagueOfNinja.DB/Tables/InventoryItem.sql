CREATE TABLE [dbo].[InventoryItem]
(


	[NinjaId] INT NULL,
	[EquipmentId] INT NULL,
	[IsUsingEquitment] BIT NOT NULL, 

	CONSTRAINT [FK_Inventory_Ninja] FOREIGN KEY ([NinjaId]) REFERENCES [dbo].[Ninja] ([NinjaId])  ON DELETE CASCADE,
	CONSTRAINT  [FK_Inventory_Equitment]  FOREIGN KEY ([EquipmentId]) REFERENCES [dbo].[Equipment] ([EquipmentId])  ON DELETE CASCADE, 


)
