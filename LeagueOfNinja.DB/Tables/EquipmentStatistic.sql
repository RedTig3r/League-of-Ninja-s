CREATE TABLE [dbo].[EquipmentStatistic]
(
	[EquitmentId] INT NOT NULL,
	[StatisticType] NVARCHAR(50) NOT NULL,
	[StatisticValue] INT NOT NULL,

	
	CONSTRAINT [FK_EquipmentState_Equipment] FOREIGN KEY ([EquitmentId]) REFERENCES [dbo].[Equipment] ([EquitmentId]),
	CONSTRAINT  [FK_EquipmentState_TypOfStatistic]  FOREIGN KEY ([StatisticType]) REFERENCES [dbo].[TypOfStatistic] ([StatisticType]), 
)
