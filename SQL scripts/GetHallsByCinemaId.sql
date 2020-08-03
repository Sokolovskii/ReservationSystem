USE [ReservationSystem]
GO
/****** Object:  StoredProcedure [dbo].[GetHallsByCinemaId]    Script Date: 11.06.2020 12:56:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================
--Author:Sokolovskiy Alexander
--Create Date: 10.06.2020
--Description: Возвращает список залов по Id кинотеатра
--=============================

CREATE PROCEDURE [dbo].[GetHallsByCinemaId]
	@CinemaId INT
AS
	SELECT h.Id, h.Name,h.Description,h.PlacesCount FROM ReservationSystemCinema c
	JOIN ReservationSystemHall h ON h.CinemaId = c.Id
	WHERE c.Id = @CinemaId