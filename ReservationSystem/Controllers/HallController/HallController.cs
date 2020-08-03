using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.HallService;

namespace ReservationSystem.Controllers.HallController
{
    /// <summary>
    /// Контроллер страницы зала
    /// </summary>
    [Route("hall")]
    public class HallController : Controller
    {
        private readonly IHallService _hallService;
        
        /// <summary>
        /// .ctor
        /// </summary>
        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }
        
        /// <summary>
        /// Возвращает представление с информацией о зале и сеансах в нем
        /// </summary>
        /// <param name="hallId">Id зала</param>
        [HttpGet]
        public IActionResult Hall(int hallId)
        {
            var hallView = new HallViewDto
            {
                Hall = _hallService.GetHallById(hallId),
                Sessions = _hallService.GetSessionsToHall(hallId),
                Films = _hallService.GetPartialFilmsByHallId(hallId),
                Places = _hallService.GetPlacesByHallId(hallId)
            };
            return View(hallView);
        }

        public IActionResult Error()
        {
            return View("ErrorView");
        }
    }
}