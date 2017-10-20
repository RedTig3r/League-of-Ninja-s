MERGE INTO dbo.Inventory AS Target
USING (values
	(1,3),
	(1,6),
	(1,9),
	(1,12),
	(1,15),
			

	(2,3),
	(2,6),
	(2,9),
	(2,12),
	(2,15),
	
	(3,null)
)AS Source (NinjaId, EquitmentId)
On Target.NinjaId = Source.NinjaId
and Target.EquitmentId = Source.EquitmentId 
WHEN NOT MATCHED BY TARGET THEN
	INSERT (NinjaId, EquitmentId)
	VALUES (NinjaId, EquitmentId)
WHEN MATCHED THEN
	UPDATE SET
		NinjaId = Source.NinjaId,
		EquitmentId = Source.EquitmentId;