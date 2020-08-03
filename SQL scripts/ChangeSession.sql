USE [ReservationSystem]
GO
--====================================
--Autor: Sokolovskiy Alexander
--Create date: 08.06.2020
--Description: Изменяет параметры сессии для актуального пользователя
--====================================
CREATE PROCEDURE ChangeSession
	@OldPlaceId INT,
	@NewPlaceId INT,
	@UserId INT,
	@SessionId INT
AS
	UPDATE ReservationSystemPlaceSessionUser
	SET 
		[PlaceId] = @NewPlaceId
	WHERE PlaceId = @OldPlaceId
	AND SessionId = @SessionId
	AND UserId = @UserId