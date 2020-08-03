USE[ReservationSystem]
GO

--==================================
--Autor: Sokolovskiy Alexander
--Create Date: 09.06.2020
--Description: Возвращает фильм по ID
--==================================

CREATE PROCEDURE GetFilmById
	@FilmId INT
AS
	SELECT f.Id, f.Name, f.Genre ,f.Description, f.Duration, f.Producer ,f.Contry, f.YearOfProduction FROM ReservationSystemFilm f
	WHERE f.Id = @FilmId