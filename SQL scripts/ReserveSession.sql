USE [ReservationSystem]
GO

--====================================
--Autor: Sokolovskiy Alexander
--Create date: 08.06.2020
--Description: добаваляет бронь для юзера
--====================================

CREATE PROCEDURE ReserveSession
	@PlaceId INT,
	@UserId INT,
	@SessionId INT
AS
	INSERT ReservationSystemPlaceSessionUser VALUES
	(@PlaceId,@SessionId,@UserId)
	



