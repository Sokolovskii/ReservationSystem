using System.Collections.Generic;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Repository.PlaceRepository
{
    /// <summary>
    /// интерфейс, описывающий репозиторий мест
    /// </summary>
    public interface IPlaceRepository
    {
        /// <summary>
        /// Возвращает информацию о местах в конкретном зале в конкретный сеанс
        /// </summary>
        IEnumerable<PlaceInHall> GetInfoAboutSessionInHall(int sessionId);

        /// <summary>
        /// Возвращает список мест по Id зала
        /// </summary>
        IEnumerable<PlaceInHall> GetPlacesByHallId(int hallId);

        /// <summary>
        /// Возвращает место по его Id с указанием занятости на сессию
        /// </summary>
        PlaceInHall GetPlaceById(int placeId, int sessionId);

        /// <summary>
        /// Бронирование мест в кинозале
        /// </summary>
        void ReserveSessionInHall(int placeId, int userId, int sessionId);

        /// <summary>
        /// Отмена броней в зале
        /// </summary>
        void UnreserveSessionInHall(int userId, int sessionId);

    }
}