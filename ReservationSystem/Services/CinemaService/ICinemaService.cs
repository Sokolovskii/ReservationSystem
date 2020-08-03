using System.Collections.Generic;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.ServiceResponse;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.CinemaService
{
    /// <summary>
    /// Интерфейс, описывающий класс сервисов контроллера кинотеатра
    /// </summary>
    public interface ICinemaService
    {
        /// <summary>
        /// Возвращает кинотеатр по его Id
        /// </summary>
        ServiceResponse<CinemaDto> GetCinemaById(int cinemaId);

        /// <summary>
        /// Возвращает список фильмов для кинотеатра по его Id
        /// </summary>
        ServiceResponse<IEnumerable<PartialFilmDto>> GetFilmsByCinemaId(int cinemaId);

        /// <summary>
        /// Возвращает список залов по Id кинотеатра
        /// </summary>
        ServiceResponse<IEnumerable<PartialHallDto>> GetHallsByCinemaId(int cinemaId);

        /// <summary>
        /// Возвращает список Id всех кинотеатров в базе
        /// </summary>
        ServiceResponse<IEnumerable<CinemaDto>> GetAllCinemas();
    }
}