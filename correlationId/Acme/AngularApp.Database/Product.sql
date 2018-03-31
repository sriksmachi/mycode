CREATE TABLE [dbo].[Product]
(
	[ProductId] INT NOT NULL PRIMARY KEY, 
    [ProductName] NVARCHAR(50) NULL, 
    [ProductCode] NVARCHAR(10) NULL, 
    [Price] DECIMAL NULL, 
    [ReleaseDate] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [StarRating] FLOAT NULL, 
    [ImageUrl] NVARCHAR(200) NULL
)
