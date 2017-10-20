MERGE INTO dbo.Ninja AS Target
USING (values
 (1, 'Barieee Batsbak', 1000),
 (2, 'Kenny SlideShadow', 1000),
  (3, 'Naked ninja', 5000)
) AS Source (NinjaId, Name, Money)
ON Target.NinjaId = Source.NinjaId
When Not MATCHED BY TARGET THEN
 INSERT (NinjaId, Name, Money)
 VALUES (NinjaId, Name, Money)
WHEN MATCHED THEN
	UPDATE SET
		NinjaId = Source.NinjaId,
		Name = Source.Name,
		Money = Source.Money;