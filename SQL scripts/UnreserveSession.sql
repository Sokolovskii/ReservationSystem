USE [ReservationSystem]
GO
/****** Object:  StoredProcedure [dbo].[UnreserveSession]    Script Date: 16.06.2020 19:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=========================
--Author: Sokolovskiy Alexander
--Create Date: 08.06.2020
--Description: Отменяет бронь юзера
--=========================

CREATE PROCEDURE [dbo].[UnreserveSession]
	@UserId INT,
	@SessionId INT
AS
	DELETE ReservationSystemPlaceSessionUser 
	WHERE SessionId = @SessionId
	AND UserId = @UserId

	