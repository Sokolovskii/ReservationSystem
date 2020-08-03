USE [ReservationSystem]
GO
/****** Object:  StoredProcedure [dbo].[GetInfoAboutSessions]    Script Date: 09.06.2020 11:22:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--====================================
--Autor: sokolovskiy alexander
--Create Date: 09.06.2020
--Description: Возвращает список сессий для конкретного фильма и кинотеатра
--====================================

CREATE PROCEDURE [dbo].[GetSessionsForFilmInCinema]
	@FilmId INT,
	@CinemaId INT
AS
	SELECT s.Id, s.Date, s.TimeOfBegin, s.TimeOfEnd, h.Name as HallName FROM ReservationSystemSession s
	JOIN ReservationSystemFilm f ON s.FilmId = f.Id
	JOIN ReservationSystemHall h ON h.Id = s.HallId
	JOIN ReservationSystemCinema c ON c.Id = h.CinemaId
	WHERE f.Id = @FilmId AND h.CinemaId = @CinemaId