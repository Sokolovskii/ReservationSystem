USE[ReservationSystem]
GO

--========================
--Author:Sokolovskiy Alexander
--Create Date:02.07.2020
--Description: Возвращает Места по Id Зала
--========================

CREATE PROCEDURE GetPlacesByHallId
	@HallId INT
AS
	SELECT p.Id, p.Row, p.[Column] FROM ReservationSystemHall h
	JOIN ReservationSystemPlaces p on p.HallId = h.Id
	WHERE h.Id = @HallId