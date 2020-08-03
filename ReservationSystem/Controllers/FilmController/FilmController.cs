using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.FilmService;

namespace ReservationSystem.Controllers.FilmController
{
    /// <summary>
    /// Контроллер страницы фильма
    /// </summary>
    [Route("film")]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="filmService">Сервисы фильмов</param>
        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        
        /// <summary>
        /// Возвращает представление с фильмом и списком сессий для него
        /// </summary>
        /// <param name="filmId">Id фильма</param>
        /// <param name="cinemaId">Id кинотеатра</param>
        [HttpGet]
        public IActionResult Film(int filmId, int cinemaId)
        {
            var filmView = new FilmViewDto
            {
				Sessions = _filmService.GetSessionsToFilmInCinema(filmId, cinemaId),
				Film = _filmService.GetFilmById(filmId),
                Halls = _filmService.GetHallsByCinemaId(cinemaId)
            };
            return View(filmView);
        }

        public IActionResult Error()
        {
            return View("ErrorView");
        }
    }
}