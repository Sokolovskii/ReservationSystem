USE [ReservationSystem]
GO
/****** Object:  StoredProcedure [dbo].[GetInfoAboutCinema]    Script Date: 09.06.2020 11:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--==================================
--Author: sokolovskiy alexander
--Create Date: 09.06.2020
--Description: Возвращает кинотеатр по id
--==================================

CREATE PROCEDURE [dbo].[GetCinemaById]
	@CinemaId INT
AS
	SELECT c.Id, c.Name, c.Description FROM ReservationSystemCinema c
	WHERE c.Id = @CinemaId