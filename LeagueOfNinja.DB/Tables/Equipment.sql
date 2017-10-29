CREATE TABLE [dbo].[Equipment]
(
	[EquipmentId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(50) NOT NULL,
    [EquipmentValue] INT NOT NULL, 
	[EquipmentType] nvarchar(50) NOT NULL, 
    [Strength] INT NOT NULL, 
    [Intelligence] INT NOT NULL, 
	[Agility] INT NOT NULL, 


)
