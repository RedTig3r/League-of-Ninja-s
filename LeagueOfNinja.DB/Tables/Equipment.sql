CREATE TABLE [dbo].[Equipment]
(
	[EquipmentId] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NULL, 
    [Price] INT NULL, 
    [Strength] INT NULL, 
    [Intelligence] INT NULL, 
    [Agility] INT NULL, 
    [Type] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Equipment_TypeOfEquipment] FOREIGN KEY ([Type]) REFERENCES [dbo].[TypeOfEquipment]([TypeOfEquipmentId]), 

  
)
