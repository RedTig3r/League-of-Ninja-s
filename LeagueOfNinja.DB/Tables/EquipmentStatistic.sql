CREATE TABLE [dbo].[EquipmentStatistic]
(
	[EquipmentId] INT NULL,
	[StatisticType] NVARCHAR(50) NULL,
	[StatisticValue] INT NOT NULL,

	
	CONSTRAINT [FK_EquipmentState_Equipment] FOREIGN KEY ([EquipmentId]) REFERENCES [dbo].[Equipment] ([EquipmentId])  ON DELETE CASCADE,
	CONSTRAINT  [FK_EquipmentState_TypOfStatistic]  FOREIGN KEY ([StatisticType]) REFERENCES [dbo].[TypOfStatistic] ([StatisticType])  ON DELETE CASCADE, 
)
