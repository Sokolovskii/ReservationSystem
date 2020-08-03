USE[ReservationSystem]
GO


BEGIN 
IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ReservationSystemCinema')

CREATE TABLE ReservationSystemCinema
	(
		[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		[Name] NVARCHAR(100) NOT NULL,
		[Description] nvarchar(max) not null
	)
END
GO

BEGIN
IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ReservationSystemUser')

CREATE TABLE ReservationSystemUser
	(
		[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		[Name] NVARCHAR(100) NOT NULL,
		[Login] NVARCHAR(100) NOT NULL,
		[PassHash] NVARCHAR(255) NOT NULL,
		[RemovedFlag] BIT NOT NULL
	)
END
Go

BEGIN
IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ReservationSystemFilm')

CREATE TABLE ReservationSystemFilm
	(
		[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		[Name] NVARCHAR(100) NOT NULL,
		[Genre] NVARCHAR(150) NOT NULL,
		[Duration] SMALLINT NOT NULL,
		[Description] NVARCHAR(MAX) NOT NULL,
		[Contry] NVARCHAR(60) NOT NULL,
		[Producer] NVARCHAR(100) NOT NULL,
		[YearOfProduction] SMALLINT NOT NULL
	)
END
GO

BEGIN
IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ReservationSystemHall')

CREATE TABLE ReservationSystemHall
	(
		[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		[Name] NVARCHAR(100) NOT NULL,
		[Description] NVARCHAR(MAX) NOT NULL,
		[PlacesCount] SMALLINT NOT NULL,
		[CinemaId] INT NOT NULL,

		CONSTRAINT FK_ReservationSystemHall FOREIGN KEY(CinemaId) REFERENCES dbo.ReservationSystemCinema(Id)
	)
END
GO

BEGIN
IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ReservationSystemSession')

CREATE TABLE ReservationSystemSession
	(
		[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		[Date] DATE NOT NULL,
		[TimeOfBegin] TIME NOT NULL,
		[TimeOfEnd] TIME NOT NULL, 
		[Cost] SMALLINT NOT NULL,
		[HallId] INT NOT NULL,
		[FilmId] INT NOT NULL,

		UNIQUE([TimeOfBegin],[HallId],[FilmId]),

		CONSTRAINT FK_ReservationSystemSession_Hall FOREIGN KEY(HallId) REFERENCES dbo.ReservationSystemHall(Id),
		CONSTRAINT FK_ReservationSystemSession_Film FOREIGN KEY(FilmId) REFERENCES dbo.ReservationSystemFilm(Id)
	)
END
GO

BEGIN
IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ReservationSystemPlaces')

CREATE TABLE ReservationSystemPlaces
	(
		[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		[Row] SMALLINT NOT NULL,
		[Column] SMALLINT NOT NULL,
		[HallId] INT NOT NULL,

		CONSTRAINT FK_ReservationSystemPlaces_Hall FOREIGN KEY(HallId) REFERENCES dbo.ReservationSystemHall(Id),
	)
END
GO

BEGIN
IF NOT EXISTS(SELECT*FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'ReservationSystemPlaceSessionUser')

CREATE TABLE ReservationSystemPlaceSessionUser
	(
		[PlaceId] INT NOT NULL,
		[SessionId] INT NOT NULL,
		[UserId] INT NOT NULL,

		CONSTRAINT FK_ReservationSystemSession_Place FOREIGN KEY(PlaceId) REFERENCES dbo.ReservationSystemPlaces(Id),
		CONSTRAINT FK_ReservationSystemSession_Session FOREIGN KEY(SessionId) REFERENCES dbo.ReservationSystemSession(Id),
		CONSTRAINT FK_ReservationSystemSession_User FOREIGN KEY(UserId) REFERENCES dbo.ReservationSystemUser(Id),

		UNIQUE([PlaceId],[SessionId])
	)
END

