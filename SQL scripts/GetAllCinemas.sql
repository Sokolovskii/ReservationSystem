USE [ReservationSystem]
GO

--=======================
--Author: Sokolovskiy Alexander
--Create Date: 11.06.2020
--Description: Возвращает список всех кинотеатров
--=======================
CREATE PROCEDURE GetAllCinemas
AS
	SELECT c.Id, c.Name, c.Description FROM ReservationSystemCinema c