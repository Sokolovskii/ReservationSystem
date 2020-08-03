USE [ReservationSystem]
GO
/****** Object:  StoredProcedure [dbo].[GetInfoAboutSessionInHall]    Script Date: 17.06.2020 10:58:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--====================================
--Autor: Sokolovskiy Alexander
--Create date: 08.06.2020
--Description: Возвращает информацию о местах в зале для конкретной сессии
--====================================

CREATE PROCEDURE [dbo].[GetInfoAboutSessionInHall]
	@SessionId INT
AS
		SELECT p.Id AS PlaceId,
		p.[Row],
		p.[Column],
		psu.UserId
	FROM ReservationSystemSession s
	JOIN ReservationSystemHall h ON h.Id = s.HallId
	JOIN ReservationSystemPlaces p ON p.HallId = h.Id
	LEFT JOIN ReservationSystemPlaceSessionUser psu ON p.Id = psu.PlaceId and s.Id = psu.SessionId
	WHERE s.Id = @SessionId
	GROUP BY p.Id, p.[Row], p.[Column], psu.UserId
