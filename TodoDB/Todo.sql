CREATE TABLE [dbo].[Todo]
(
	[TaskNo] INT NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(50) NULL, 
    [Description] VARCHAR(150) NULL, 
    [StartDate] DATETIME NOT NULL, 
    [DueDate] DATETIME NULL, 
    [Priority] INT NULL, 
    [Status] CHAR(10) NULL
)
