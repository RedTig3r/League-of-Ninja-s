CREATE TABLE [dbo].[EquipmentInventory]
(
	[EquipmentId] INT NOT NULL, 
    [InventoryId] INT NOT NULL, 
    CONSTRAINT [FK_EquipmentInventory_Equipment] FOREIGN KEY ([EquipmentId]) REFERENCES [dbo].[Equipment]([EquipmentId]), 
	CONSTRAINT [FK_EquipmentInventory_Inventory] FOREIGN KEY ([InventoryId]) REFERENCES [dbo].[Inventory]([InventoryId]), 
)
