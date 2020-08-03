USE[ReservationSystem]
GO

--============================
--Author:sokolovskiy alexander
--Create Date: 09.06.2020
--Description: возвращает список фильмов для кинотеатра по его id
--============================

CREATE PROCEDURE GetFilmsByCinemaId
	@CinemaId INT
AS
SELECT 
	f.Id, 
	f.Name, 
	f.Genre,
	f.Description, 
	f.Duration, 
	f.Producer, 
	f.Contry, 
	f.YearOfProduction
FROM [dbo].[ReservationSystemCinema] c
	JOIN [dbo].[ReservationSystemHall] h on c.Id = h.CinemaId
	JOIN [dbo].[ReservationSystemSession] s on s.HallId = h.Id
	JOIN [dbo].[ReservationSystemFilm] f on f.Id = s.FilmId
	WHERE c.Id = @CinemaId
	GROUP BY 	f.Id, 
		f.Name, 
		f.Genre,
		f.Description, 
		f.Duration, 
		f.Producer, 
		f.Contry, 
		f.YearOfProduction


	
