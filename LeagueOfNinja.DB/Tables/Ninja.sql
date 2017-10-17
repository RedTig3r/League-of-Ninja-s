CREATE TABLE [dbo].[Ninja]
(
	[NinjaId] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NOT NULL, 
    [Money] INT NOT NULL, 
    CONSTRAINT [FK_Ninja_Inventory] FOREIGN KEY ([NinjaId]) REFERENCES [dbo].[Inventory]([InventoryId]), 
    CONSTRAINT [FK_Ninja_Shop] FOREIGN KEY ([NinjaId]) REFERENCES [dbo].[Shop]([ShopId]), 
)
