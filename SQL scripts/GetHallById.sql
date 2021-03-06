USE [ReservationSystem]
GO
/****** Object:  StoredProcedure [dbo].[GetInfoAboutHalls]    Script Date: 09.06.2020 11:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=================================
--Autor: Sokolovskiy Alexander
--Create Date: 09.06.2020
--Description: Возвращает зал по Id
--=================================

CREATE PROCEDURE [dbo].[GetHallById]
	@HallId INT
AS
	SELECT h.Id, h.Name, h.Description, h.PlacesCount, h.CinemaId FROM ReservationSystemHall h
	WHERE h.Id = @HallId