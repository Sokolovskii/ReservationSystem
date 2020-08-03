USE [ReservationSystem]
GO
/****** Object:  StoredProcedure [dbo].[GetSessionsForHallInCinema]    Script Date: 18.06.2020 13:10:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--====================================
--Autor: sokolovskiy alexander
--Create Date: 09.06.2020
--Description: Возвращает список сессий для конкретного зала
--====================================

CREATE PROCEDURE [dbo].[GetSessionsForHallInCinema]
	@HallId INT
AS
	SELECT s.Id, s.Date, s.TimeOfBegin, s.TimeOfEnd, s.Cost, f.Id AS FilmId FROM ReservationSystemSession s
	JOIN ReservationSystemFilm f ON s.FilmId = f.Id
	JOIN ReservationSystemHall h ON h.Id = s.HallId
	WHERE h.Id = @HallId
