using Microsoft.AspNetCore.Mvc;

namespace ReservationSystem.Controllers.PersonController
{
    /// <summary>
    /// Контроллер пользовательского представления
    /// </summary>
    [Route("person")]
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult Person()
        {
            return View();
        }

    }
}