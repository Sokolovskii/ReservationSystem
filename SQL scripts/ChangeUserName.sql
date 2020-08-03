USE [ReservationSystem]
GO

--====================================
--Autor: Sokolovskiy Alexander
--Create date: 08.06.2020
--Description: Изменяет никнейм юзера
--====================================

CREATE PROCEDURE ChangeUserName
	@UserId INT,
	@UserName NVARCHAR(100)
AS
	UPDATE ReservationSystemUser 
	SET
		[Name] = @UserName 
	WHERE Id = @UserId