MERGE INTO dbo.TypeOfEquipment AS Target
USING (values
	('Shoulders'),
	('Chest'),
	('Belt'),
	('Legs'),
	('Boots')
)AS Source (EquipmentType)
On Target.EquipmentType = Source.EquipmentType
WHEN NOT MATCHED BY TARGET THEN
	INSERT (EquipmentType)
	VALUES (EquipmentType)
WHEN MATCHED THEN
	UPDATE SET
		EquipmentType = Source.EquipmentType;




