CREATE TABLE [dbo].[Ninja]
(
	[NinjaId] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NULL, 
    [Money] INT NULL, 
    CONSTRAINT [FK_Ninja_Inventory] FOREIGN KEY ([NinjaId]) REFERENCES [dbo].[Inventory]([InventoryId]), 
    CONSTRAINT [FK_Ninja_NinjaGear] FOREIGN KEY ([NinjaId]) REFERENCES [dbo].[NinjaGear]([NinjaGearId]) 
)
