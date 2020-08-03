using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.CinemaService;

namespace ReservationSystem.Controllers.CinemaController
{
    /// <summary>
    /// Контроллер страниц списка кинотеатров и конкретного кинотеатра
    /// </summary>
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="cinemaService">Сервисы кинотеатра</param>
        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
        
        /// <summary>
        /// Возвращает представление со списком кинотеатров
        /// </summary>
        public IActionResult Cinemas()
        {
            var cinemas = new CinemasViewDto
            {
                Cinemas = _cinemaService.GetAllCinemas()
            }; 
            return View(cinemas);
        }

        /// <summary>
        /// Возвращает представление с информацией по конкретному кинотеатру по его Id
        /// </summary>
        /// <param name="cinemaId">Id кинотеатра</param>
        public IActionResult Cinema(int cinemaId)
        {
			var aaa = _cinemaService.GetHallsByCinemaId(cinemaId);
            var cinema = new CinemaViewDto
            {
                Cinema = _cinemaService.GetCinemaById(cinemaId),
                FilmList = _cinemaService.GetFilmsByCinemaId(cinemaId),
                HallList = _cinemaService.GetHallsByCinemaId(cinemaId)
            };
            return View(cinema);
        }
        
        public IActionResult Error()
        {
            return View("ErrorView");
        }
    }
}