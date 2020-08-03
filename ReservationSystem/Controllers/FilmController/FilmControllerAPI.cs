using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.FilmService;
using ReservationSystem.Services.ServiceResponse.Generic;


namespace ReservationSystem.Controllers.FilmController
{
    /// <summary>
    /// API фильмов
    /// </summary>
    [Route("api/film")]
    public class FilmControllerAPI : ControllerBase
    {
        private readonly IFilmService _filmService;
        
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="filmService">Сервисы фильмов</param>
        public FilmControllerAPI(IFilmService filmService)
        {
            _filmService = filmService;
        }

        /// <summary>
        /// Возвращает респонс с фильмом по Id
        /// </summary>
        [HttpGet("GetFilmById")]
        public ServiceResponse<FilmDto> GetFilmById(int filmId) => _filmService.GetFilmById(filmId);
        
        /// <summary>
        /// Возвращает респонс со списком сессий для фильма по его Id и Id кинотеатра
        /// </summary>
        [HttpGet("GetSessionsForFilmInCinema")]
        public ServiceResponse<IEnumerable<SessionDto>> GetSessionsForFilmInCinema(int filmId, int cinemaId) => _filmService.GetSessionsToFilmInCinema(filmId, cinemaId);

        /// <summary>
        /// Возвращает респонс с краткой информацией по залу по его Id
        /// </summary>
        [HttpGet("GetPartialHallById")]
        public ServiceResponse<IEnumerable<PartialHallDto>> GetPartialHallById(int hallId) => _filmService.GetHallsByCinemaId(hallId);
    }
}