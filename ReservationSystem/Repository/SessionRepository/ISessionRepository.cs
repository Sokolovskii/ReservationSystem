using System.Collections.Generic;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Repository.SessionRepository
{
    /// <summary>
    /// Интерфейс, описывающий репозиторий сессий
    /// </summary>
    public interface ISessionRepository
    {
        /// <summary>
        /// Возвращает список сессий для фильма в кинотеатре
        /// </summary>
        IEnumerable<Session> GetSessionsForFilmInCinema(int filmId, int cinemaId);

        /// <summary>
        /// Возвращает список сессий для зала
        /// </summary>
        IEnumerable<Session> GetSessionsForHall(int hallId);

        /// <summary>
        /// Возвращает сессию по Id
        /// </summary>
        Session GetSessionById(int sessionId);
    }
}