CREATE TABLE [dbo].[Tray]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NVARCHAR(50) NOT NULL, 
    [SortOrder] INT NOT NULL
)
