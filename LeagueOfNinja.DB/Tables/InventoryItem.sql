CREATE TABLE [dbo].[InventoryItem]
(


	[NinjaId] INT NULL,
	[EquitmentId] INT NULL,
	[IsUsingEquitment] BIT NOT NULL, 

	CONSTRAINT [FK_Inventory_Ninja] FOREIGN KEY ([NinjaId]) REFERENCES [dbo].[Ninja] ([NinjaId])  ON DELETE CASCADE,
	CONSTRAINT  [FK_Inventory_Equitment]  FOREIGN KEY ([EquitmentId]) REFERENCES [dbo].[Equipment] ([EquitmentId])  ON DELETE CASCADE, 


)
