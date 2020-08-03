using System.Collections.Generic;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Repository.CinemaRepository
{
    /// <summary>
    /// Интерфейс, описывающий репозиторий кинотеатра
    /// </summary>
    public interface ICinemaRepository
    {
        /// <summary>
        /// Возвращает клиенту кинотеатр по Id
        /// </summary>
        Cinema GetCinemaById(int cinemaId);

        /// <summary>
        /// Возвращает коллекцию всех кинотеатров
        /// </summary>
        IEnumerable<Cinema> GetAllCinemas();
    }
}