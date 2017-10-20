MERGE INTO dbo.TypOfStatistic AS Target
USING (values
	('Strength'),
	('Intelligence'),
	('Agility')
)AS Source (StatisticType)
On Target.StatisticType = Source.StatisticType
WHEN NOT MATCHED BY TARGET THEN
	INSERT (StatisticType)
	VALUES (StatisticType)
WHEN MATCHED THEN
	UPDATE SET
		StatisticType = Source.StatisticType;