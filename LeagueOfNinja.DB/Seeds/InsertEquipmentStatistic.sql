MERGE dbo.EquipmentStatistic AS Target  
USING (values 
	(1, 'Strength', 20),
	(1, 'Intelligence', 10),
	(1, 'Agility', -5),

	(2, 'Strength', 10),
	(2, 'Intelligence', 5),

	(3, 'Agility', 2),

	(4, 'Strength', 5),
	(4, 'Intelligence', 20),
	(4, 'Agility', 10),

	(5, 'Intelligence', 5),
	(5, 'Agility', 10),

	(6, 'Intelligence', 4),

	(7, 'Strength', 20),
	(7, 'Intelligence', -10),
	(7, 'Agility', 5),

	(8, 'Intelligence', -2),
	(8, 'Agility', 2),
	
	(9, 'Strength', 2),
	(9, 'Intelligence', -1),
	(9, 'Agility', 1),
	 
	(10, 'Strength', 20),
	(10, 'Intelligence', -3),
	(10, 'Agility', 20),
	
	(11, 'Strength', 7),
	(11, 'Agility', 12),	

	(12, 'Agility', 8),
	
	(13, 'Strength', -2),
	(13, 'Intelligence', -5),
	(13, 'Agility', 30),
	
	(14, 'Strength', -2),
	(14, 'Agility', 12),

	(15, 'Agility', 3)
) AS Source (EquipmentId, StatisticType,StatisticValue)  
ON Target.EquipmentId = Source.EquipmentId  
and Target.StatisticType = Source.StatisticType
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (EquipmentId, StatisticType,StatisticValue)  
	VALUES (EquipmentId, StatisticType,StatisticValue)
WHEN MATCHED THEN
	UPDATE SET
		EquipmentId = Source.EquipmentId,
		StatisticType = Source.StatisticType,
		StatisticValue = Source.StatisticValue;