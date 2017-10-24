CREATE TABLE [dbo].[EquipmentStatistic]
(
	[EquipmentId] INT NOT NULL,
	[StatisticType] NVARCHAR(50) NOT NULL,
	[StatisticValue] INT NOT NULL,
     PRIMARY KEY ([EquipmentId], [StatisticType]),
	
	CONSTRAINT [FK_EquipmentState_Equipment] FOREIGN KEY ([EquipmentId]) REFERENCES [dbo].[Equipment] ([EquipmentId])  ON DELETE CASCADE,
	CONSTRAINT  [FK_EquipmentState_TypOfStatistic]  FOREIGN KEY ([StatisticType]) REFERENCES [dbo].[TypOfStatistic] ([StatisticType])  ON DELETE CASCADE, 
)
