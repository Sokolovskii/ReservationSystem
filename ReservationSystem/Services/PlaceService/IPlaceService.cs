using System.Collections.Generic;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.ServiceResponse;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.PlaceService
{
    /// <summary>
    /// Интерфейс, описывающий класс сервисов для контроллера мест в зале
    /// </summary>
    public interface IPlaceService
    {
        /// <summary>
        /// Возвращает DTO сессии по ее Id
        /// </summary>
        ServiceResponse<SessionDto> GetSessionById(int userId);

        /// <summary>
        /// Возвращает DTO неполного фильма по его Id
        /// </summary>
        ServiceResponse<PartialFilmDto> GetPartialFilmById(int filmId);

        /// <summary>
        /// озвращает список DTO мест в зале по Id сессии
        /// </summary>
        ServiceResponse<IEnumerable<PlaceInHallDto>> GetPlacesBySessionId(int sessionId);

        /// <summary>
        /// Бронирует места для пользователя на сессию
        /// </summary>
        ServiceResponse.NonGeneric.ServiceResponse ReservePlaces(int[] placeIds, int sessionId, int userId);

        /// <summary>
        /// Отменяет бронь мест для пользователя на сессию
        /// </summary>
        ServiceResponse.NonGeneric.ServiceResponse UnreserveSession(int sessionId, int userId);
    }
}