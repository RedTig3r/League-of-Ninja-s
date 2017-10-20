MERGE INTO dbo.TypeOfEquipment AS Target
USING (values
	('Shoulders'),
	('Chest'),
	('Belt'),
	('Legs'),
	('Boots')
)AS Source (EquitmentType)
On Target.EquitmentType = Source.EquitmentType
WHEN NOT MATCHED BY TARGET THEN
	INSERT (EquitmentType)
	VALUES (EquitmentType)
WHEN MATCHED THEN
	UPDATE SET
		EquitmentType = Source.EquitmentType;




