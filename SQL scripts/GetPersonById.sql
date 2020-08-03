USE [ReservationSystem]
GO

--==============================
--Autor: sokolovskiy alexander
--Create Date: 09.06.2020
--Description: Возвращает пользователя по Id при условии, что он не удален
--==============================

CREATE PROCEDURE GetPersonById
	@UserId INT
AS
	SELECT u.Id, u.Login, u.Name, u.PassHash FROM ReservationSystemUser u
	WHERE u.Id = @UserId AND RemovedFlag = 0