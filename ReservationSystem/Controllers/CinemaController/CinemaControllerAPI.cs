using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.CinemaService;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Controllers.CinemaController
{
    /// <summary>
    /// API кинотеатра
    /// </summary>
    [Route("api/[controller]")]
    public class CinemaControllerAPI : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="cinemaService">Сервисы кинотеатра</param>
        public CinemaControllerAPI(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
        
        /// <summary>
        /// Возвращает респонс со списком всех кинотеатров
        /// </summary>
        [HttpGet("GetAllCinemas")]
        public ServiceResponse<IEnumerable<CinemaDto>> GetAllCinemas() => _cinemaService.GetAllCinemas();

        /// <summary>
        /// Возвращает респонс со списком кратких описаний фильмов по Id кинотеатра
        /// </summary>
        /// <param name="cinemaId">Id кинотеатра</param>
        [HttpGet("GetFilmsByCinemaId")]
        public ServiceResponse<IEnumerable<PartialFilmDto>> GetFilmsByCinemaId(int cinemaId) => _cinemaService.GetFilmsByCinemaId(cinemaId);

        /// <summary>
        /// Возвращает респонс со списком залов по Id кинотеатра
        /// </summary>
        /// <param name="cinemaId">Id кинотеатра</param>
        [HttpGet("GetHallsByCinemaId")]
        public ServiceResponse<IEnumerable<PartialHallDto>> GetHallsByCinemaId(int cinemaId) => _cinemaService.GetHallsByCinemaId(cinemaId);

        /// <summary>
        /// Возвращает респонс с кинотеатром по его Id
        /// </summary>
        /// <param name="cinemaId">Id кинотеатра</param>
        [HttpGet("GetCinemaById")]
        public ServiceResponse<CinemaDto> GetCinemaById(int cinemaId) => _cinemaService.GetCinemaById(cinemaId);
    }
}