using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.HallService;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Controllers.HallController
{
    /// <summary>
    /// API кинозала
    /// </summary>
    [Route("api/hall")]
    public class HallControllerAPI : ControllerBase
    {
        private readonly IHallService _hallService;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="hallService">Сервисы залов</param>
        public HallControllerAPI(IHallService hallService)
        {
            _hallService = hallService;
        }

        /// <summary>
        /// Возвращает респонс с залом по его Id
        /// </summary>
        /// <param name="hallId">Id зала</param>
        [HttpGet("GetHallById")]
        public ServiceResponse<HallDto> GetHallById(int hallId) => _hallService.GetHallById(hallId);

        /// <summary>
        /// Возвращает респонс со списком сессий для зала
        /// </summary>
        /// <param name="hallId">Id зала</param>
        [HttpGet("GetSessionsToHall")]
        public ServiceResponse<IEnumerable<SessionDto>> GetSessionsToHall(int hallId) => _hallService.GetSessionsToHall(hallId);

        /// <summary>
        /// Возвращает респонс со списком краткой информации о фильмах по Id кинотеатра
        /// </summary>
        /// <param name="hallId">Id зала</param>
        [HttpGet("GetPartialFilmById")]
        public ServiceResponse<IEnumerable<PartialFilmDto>> GetPartialFilmsByHallId(int hallId) => _hallService.GetPartialFilmsByHallId(hallId);
    }
}