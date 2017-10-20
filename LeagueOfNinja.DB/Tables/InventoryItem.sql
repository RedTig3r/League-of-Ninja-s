CREATE TABLE [dbo].[InventoryItem]
(


	[NinjaId] INT NOT NULL,
	[EquitmentId] INT NOT NULL,
	[IsUsingEquitment] BIT NOT NULL, 
    PRIMARY KEY ([NinjaId], [EquitmentId]),

	CONSTRAINT [FK_Inventory_Ninja] FOREIGN KEY ([NinjaId]) REFERENCES [dbo].[Ninja] ([NinjaId]),
	CONSTRAINT  [FK_Inventory_Equitment]  FOREIGN KEY ([EquitmentId]) REFERENCES [dbo].[Equipment] ([EquitmentId]), 


)
