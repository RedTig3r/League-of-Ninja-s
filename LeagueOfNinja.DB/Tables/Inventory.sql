CREATE TABLE [dbo].[Inventory]
(
	[NinjaId] INT NOT NULL,
	[EquitmentId] INT NULL,


	CONSTRAINT [FK_Inventory_Ninja] FOREIGN KEY ([NinjaId]) REFERENCES [dbo].[Ninja] ([NinjaId]),
	CONSTRAINT  [FK_CompetitionTeam_Equitment]  FOREIGN KEY ([EquitmentId]) REFERENCES [dbo].[Equipment] ([EquitmentId]), 


)
