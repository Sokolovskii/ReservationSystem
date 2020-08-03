USE[ReservationSystem]
GO

--=============================
--Author: Sokolovskiy Alexander
--Create Date: 10.06.2020
--Decription: Возвращает место по Id с указанием занятости на сессию
--=============================

CREATE PROCEDURE GetPlaceById
	@PlaceId INT,
	@SessionId INT
AS
	SELECT p.Id, p.Row, p.[Column], psu.UserId FROM ReservationSystemPlaces p
	JOIN ReservationSystemPlaceSessionUser psu ON psu.PlaceId = p.Id
	WHERE psu.SessionId = @SessionId