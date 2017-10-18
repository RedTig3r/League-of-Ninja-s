MERGE INTO dbo.Inventory AS Target
USING (values
	(1),
	(2)
)AS Source (InventoryId)
On Target.InventoryId = Source.InventoryId
WHEN NOT MATCHED BY TARGET THEN
	INSERT (InventoryId)
	VALUES (InventoryId);