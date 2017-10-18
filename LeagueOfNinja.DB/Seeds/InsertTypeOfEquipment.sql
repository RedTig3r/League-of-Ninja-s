MERGE INTO dbo.TypeOfEquipment AS Target
USING (values
	('Shoulders'),
	('Chest'),
	('Belt'),
	('Legs'),
	('Boots')
)AS Source (TypeOfEquipmentId)
On Target.TypeOfEquipmentId = Source.TypeOfEquipmentId
WHEN NOT MATCHED BY TARGET THEN
	INSERT (TypeOfEquipmentId)
	VALUES (TypeOfEquipmentId);

