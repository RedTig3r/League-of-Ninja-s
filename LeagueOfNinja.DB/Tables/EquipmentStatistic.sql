CREATE TABLE [dbo].[EquipmentStatistic]
(
	[EquitmentId] INT NULL,
	[StatisticType] NVARCHAR(50) NULL,
	[StatisticValue] INT NOT NULL,

	
	CONSTRAINT [FK_EquipmentState_Equipment] FOREIGN KEY ([EquitmentId]) REFERENCES [dbo].[Equipment] ([EquitmentId])  ON DELETE CASCADE,
	CONSTRAINT  [FK_EquipmentState_TypOfStatistic]  FOREIGN KEY ([StatisticType]) REFERENCES [dbo].[TypOfStatistic] ([StatisticType])  ON DELETE CASCADE, 
)
