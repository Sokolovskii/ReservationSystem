USE [ReservationSystem]
GO
--====================================
--Autor: Sokolovskiy Alexander
--Create date: 08.06.2020
--Description: Добавляет нового пользователя в БД
--====================================

CREATE PROCEDURE AddNewUser
	@UserName NVARCHAR(100),
	@Login NVARCHAR(100),
	@PassHash NVARCHAR(255)
AS
	INSERT ReservationSystemUser VALUES
	(@UserName, @Login, @PassHash,0)