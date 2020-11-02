CREATE TABLE [dbo].[Table]
(
	[UserID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [First Name] NVARCHAR(50) NOT NULL, 
    [Last Name] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIME NOT NULL
)
