CREATE TABLE [dbo].[Ninja]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NULL, 
    [Money] INT NULL, 
    CONSTRAINT [FK_Ninja_Inventory] FOREIGN KEY ([Id]) REFERENCES [dbo].[Inventory]([Id]) 
)
