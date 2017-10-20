MERGE INTO dbo.Shop AS Target
USING (values
	(1, 'Super Awesome Ninja Shop'),
	(2, 'Black market')
)AS Source (ShopId, Name)
On Target.ShopId = Source.ShopId
WHEN NOT MATCHED BY TARGET THEN
	INSERT (ShopId, Name)
	VALUES (ShopId, Name)
WHEN MATCHED THEN
	UPDATE SET
		ShopId = Source.ShopId,
		Name = Source.Name;