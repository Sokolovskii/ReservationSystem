using System.Collections.Generic;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.ServiceResponse;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.HallService
{
    /// <summary>
    /// Интерфейс, описывающий класс сервисов для контроллера залов
    /// </summary>
    public interface IHallService
    {
        /// <summary>
        /// Возвращает зал по Id
        /// </summary>
        ServiceResponse<HallDto> GetHallById(int hallId);

        /// <summary>
        /// Возвращает список сессий для зала по его Id
        /// </summary>
        ServiceResponse<IEnumerable<SessionDto>> GetSessionsToHall(int hallId);

        /// <summary>
        /// Возвращает респонс со списком краткой информации по фильмам по Id зала
        /// </summary>
        ServiceResponse<IEnumerable<PartialFilmDto>> GetPartialFilmsByHallId(int hallId);

        ServiceResponse<IEnumerable<PlaceDto>> GetPlacesByHallId(int hallId);
    }
}