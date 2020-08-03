using System.Collections.Generic;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Repository.HallRepository
{
    /// <summary>
    /// Интерфейс, описывающий репозиторий залов
    /// </summary>
    public interface IHallRepository
    {
        /// <summary>
        /// Возвращает список залов по Id кинотеатра
        /// </summary>
        IEnumerable<Hall> GetHallsByCinemaId(int cinemaId);

        /// <summary>
        /// Возвращает зал по ID
        /// </summary>
        Hall GetHallById(int hallId);
    }
}