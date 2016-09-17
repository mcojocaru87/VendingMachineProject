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
-- Populate Tray Table
INSERT INTO dbo.Tray
SELECT 'First Tray', 1
WHERE NOT EXISTS (SELECT 1 FROM dbo.Tray WHERE SortOrder = 1)

GO

INSERT INTO dbo.Tray
SELECT 'Second Tray', 2
WHERE NOT EXISTS (SELECT 1 FROM dbo.Tray WHERE SortOrder = 2)

GO

INSERT INTO dbo.Tray
SELECT 'Third Tray', 3
WHERE NOT EXISTS (SELECT 1 FROM dbo.Tray WHERE SortOrder = 3)
-- END Populate Tray Table

GO

-- Populate Product Table
INSERT INTO dbo.Product
SELECT 'Coke', 2.50
WHERE NOT EXISTS (SELECT 1 FROM dbo.Product WHERE Name = 'Coke')

GO

INSERT INTO dbo.Product
SELECT 'Pepsi', 2.50
WHERE NOT EXISTS (SELECT 1 FROM dbo.Product WHERE Name = 'Pepsi')

GO

INSERT INTO dbo.Product
SELECT 'Water', 3.00
WHERE NOT EXISTS (SELECT 1 FROM dbo.Product WHERE Name = 'Water')
-- End Populate Product Table

GO

-- Populate Inventory Table
INSERT INTO dbo.Inventory
SELECT 1, 10
WHERE NOT EXISTS (SELECT 1 FROM dbo.Inventory WHERE ProductId = 1)

GO

INSERT INTO dbo.Inventory
SELECT 2, 10
WHERE NOT EXISTS (SELECT 1 FROM dbo.Inventory WHERE ProductId = 2)

GO

INSERT INTO dbo.Inventory
SELECT 3, 10
WHERE NOT EXISTS (SELECT 1 FROM dbo.Inventory WHERE ProductId = 3)
-- End Inventory Product Table

GO

-- Populate TrayProduct Table
INSERT INTO dbo.TrayProduct
SELECT 1, 1
WHERE NOT EXISTS (SELECT 1 FROM dbo.TrayProduct WHERE TrayId = 1)

GO

INSERT INTO dbo.TrayProduct
SELECT 2, 2
WHERE NOT EXISTS (SELECT 1 FROM dbo.TrayProduct WHERE TrayId = 2)

GO

INSERT INTO dbo.TrayProduct
SELECT 3, 3
WHERE NOT EXISTS (SELECT 1 FROM dbo.TrayProduct WHERE TrayId = 3)
-- End TrayProduct Product Table

GO