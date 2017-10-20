/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\Seeds\InsertNinja.sql
:r .\Seeds\InsertShop.sql
:r .\Seeds\InsertTypeOfEquipment.sql
:r .\Seeds\InsertTypeOfStatistic.sql
:r .\Seeds\InsertEquipment.sql
:r .\Seeds\InsertEquipmentStatistic.sql
:r .\Seeds\InsertInventory.sql 
