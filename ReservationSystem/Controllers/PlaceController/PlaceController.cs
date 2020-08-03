using Microsoft.AspNetCore.Mvc;

namespace ReservationSystem.Controllers.PlaceController
{
    /// <summary>
    /// Контроллер представления мест в зале
    /// </summary>
    [Route("place")]
    public class PlaceController : Controller
    {
        [HttpGet]
        public IActionResult Place()
        {
            return View();
        }
    }
}