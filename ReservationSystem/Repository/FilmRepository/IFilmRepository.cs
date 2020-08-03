using System.Collections.Generic;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Repository.FilmRepository
{
    /// <summary>
    /// Интерфейс, описывающий репозиторий фильмов
    /// </summary>
    public interface IFilmRepository
    {
        /// <summary>
        /// Возвращает коллекцию фильмов по ID кинотеатра
        /// </summary>
        IEnumerable<Film> GetFilmsByCinemaId(int cinemaId);

        /// <summary>
        /// Возвращает список фильмов по Id зала
        /// </summary>
        IEnumerable<Film> GetFilmsByHallId(int hallId);

        /// <summary>
        /// Возвращает фильм по Id
        /// </summary>
        Film GetFilmById(int filmId);
    }
}