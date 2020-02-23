Drop table [dbo].[Teams]
GO

CREATE TABLE [dbo].[Teams]
(
	[TeamId] INT NOT NULL PRIMARY KEY, 
    [TeamName] NVARCHAR(50) NOT NULL, 
    [Location] NVARCHAR(50) NULL, 
    [TimeZone] NVARCHAR(50) NOT NULL
)
GO

DROP TABLE [dbo].[Games]
GO

CREATE TABLE [dbo].[Games]
(
	[GameId] INT NOT NULL PRIMARY KEY,
    [TeamId] INT FOREIGN KEY REFERENCES Teams(TeamId),
    [StartTime] DATETIME NOT NULL,
    [Location] NVARCHAR(50) NOT NULL,   
    [Description] NVARCHAR(MAX) NULL
)

GO

Drop table [dbo].[Players]
GO

CREATE TABLE [dbo].[Players] (
    [PlayerId]     INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (MAX) NOT NULL,
    [LastName]     NVARCHAR (MAX) NOT NULL,
    [Position]     NVARCHAR (MAX) NULL,
    [JerseyNumber] INT            NOT NULL,
    [PhoneNumber]  NVARCHAR (MAX) NOT NULL,
    [Status]       NVARCHAR (MAX) NOT NULL,
    [TeamId]       INT FOREIGN KEY REFERENCES Teams(TeamId)
    CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED ([PlayerId] ASC)
);

GO

DROP TABLE [dbo].[Attendances]
GO

CREATE TABLE [dbo].[Attendances]
(
    [AttendanceId]  INT NOT NULL PRIMARY KEY,
    [GameId]        INT NOT NULL FOREIGN KEY REFERENCES Games(GameId),
    [PlayerId]      INT NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
    [Status]        INT NOT NULL,
    [Note]          NVARCHAR(50) NULL
);

GO