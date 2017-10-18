MERGE INTO dbo.Ninja AS Target
USING (values
 (1, 'Barieee Batsbak', 3000, 1),
 (2, 'Kenny SlideShadow', 3000, 1)
) AS Source (NinjaId, Name, Money, ShopId)
ON Target.NinjaId = Source.NinjaId
When Not MATCHED BY TARGET THEN
 INSERT (NinjaId, Name, Money, ShopId)
 VALUES (NinjaId, Name, Money, ShopId)
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name,
		Money = Source.Money,
		ShopId = Source.ShopId;