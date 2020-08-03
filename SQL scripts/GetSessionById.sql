USE [ReservationSystem]
GO

--===========================
--Author: Sokolovskiy Alexander
--Create Date: 16.06.2020
--Description: Возвращает сессию по ее ID
--===========================

CREATE PROCEDURE GetSessionById
	@Sessionid INT
AS
	SELECT 
	s.Id, 
	s.Date,
	s.TimeOfBegin,
	s.TimeOfEnd,
	s.Cost,
	s.HallId,
	s.FilmId
		FROM ReservationSystemSession s
		WHERE s.Id = @Sessionid