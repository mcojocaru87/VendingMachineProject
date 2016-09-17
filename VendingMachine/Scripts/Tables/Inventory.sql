CREATE TABLE [dbo].[Inventory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [InStock] INT NOT NULL
)
