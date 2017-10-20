MERGE INTO dbo.Equipment AS Target
USING (values
 (1,'Super Shoulders', 1000, 'Shoulders',1),
 (2,'Normal Shoulders', 500, 'Shoulders',1),
 (3,'Noob Shoulders', 100, 'Shoulders',1),

 (4,'Super Chest', 1000, 'Chest',1),
 (5, 'Normal Shoulders',500, 'Chest',1),
 (6,'Noob Shoulders', 100, 'Chest',1),

 (7, 'Super Belt',1000, 'Belt',1),
  (8,'Normal Shoulders', 500, 'Belt',1),
  (9, 'Noob Shoulders',100, 'Belt',1),

   (10, 'Super Legs',1000, 'Legs',1),
  (11,'Normal Shoulders', 500, 'Legs',1),
  (12,'Noob Shoulders', 100, 'Legs',1),

   (13,'Super Boots', 1000, 'Boots',1),
  (14,'Normal Shoulders', 500, 'Boots',1),
  (15, 'Noob Shoulders',100, 'Boots',1)
) AS Source (EquitmentId, Name, EquipmentValue, EquitmentType, ShopId)
ON Target.EquitmentId = Source.EquitmentId
When Not MATCHED BY TARGET THEN
 INSERT (EquitmentId, Name, EquipmentValue, EquitmentType, ShopId)
 VALUES (EquitmentId, Name, EquipmentValue, EquitmentType, ShopId)
WHEN MATCHED THEN
	UPDATE SET
		EquitmentId = Source.EquitmentId,
		Name = Source.Name,
		EquipmentValue = Source.EquipmentValue,
		EquitmentType = Source.EquitmentType,
		ShopId = Source.ShopId;