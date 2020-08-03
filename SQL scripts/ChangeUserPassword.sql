USE [ReservationSystem]
GO

--====================================
--Autor: Sokolovskiy Alexander
--Create date: 08.06.2020
--Description: Меняет хэш пароля юзера
--====================================

CREATE PROCEDURE ChangeUserPassword
	@UserId INT,
	@PassHash NVARCHAR(255)
AS
	UPDATE ReservationSystemUser 
	SET
		[PassHash] = @PassHash 
	WHERE Id = @UserId