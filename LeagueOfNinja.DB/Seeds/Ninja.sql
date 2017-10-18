MERGE INTO dbo.Ninja AS Target
USING (values
	(1, 'Barend Chocotoetje', 3000,1),
	(2, 'Kenny SlideShadow', 3000,2)
) AS Source (NinjaId, Name, Money)
ON Target.NinjaId = Source.NinjaId
When Not MATCHED BY TARGET THEN
	INSERT (NinjaId, Name, Money)
	VALUES (NinjaId, Name, Money)
WHEN MATCHED THEN 
	UPDATE SET	
		Name = Source.Name,
		Money = Source.Money;
