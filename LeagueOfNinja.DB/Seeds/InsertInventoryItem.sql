MERGE INTO dbo.InventoryItem AS Target
USING (values
	(1,3,1),
	(1,6,1),
	(1,9,1),
	(1,12,1),
	(1,15,1),
			

	(2,3,1),
	(2,6,1),
	(2,9,1),
	(2,12,1),
	(2,15,1)
)AS Source (NinjaId, EquipmentId, IsUsingEquitment)
On Target.NinjaId = Source.NinjaId
and Target.EquipmentId = Source.EquipmentId 
WHEN NOT MATCHED BY TARGET THEN
	INSERT (NinjaId, EquipmentId, IsUsingEquitment)
	VALUES (NinjaId, EquipmentId, IsUsingEquitment)
WHEN MATCHED THEN
	UPDATE SET
		NinjaId = Source.NinjaId,
		EquipmentId = Source.EquipmentId,
		IsUsingEquitment = Source.IsUsingEquitment;