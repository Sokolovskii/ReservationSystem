using System.Collections.Generic;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.ServiceResponse;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.FilmService
{
    /// <summary>
    /// Интерфейс, описывающий класс сервисов для контроллера фильмов
    /// </summary>
    public interface IFilmService
    {
        /// <summary>
        /// Возвращает фильм по Id
        /// </summary>
        ServiceResponse<FilmDto> GetFilmById(int filmId);

        /// <summary>
        /// Возвращает список сессий по id фильма и кинотеатра
        /// </summary>
        ServiceResponse<IEnumerable<SessionDto>> GetSessionsToFilmInCinema(int filmId, int cinemaId);

        /// <summary>
        /// Возвращает коллекцию сокращенной информации по всем залам в кинотеатре
        /// </summary>
        ServiceResponse<IEnumerable<PartialHallDto>> GetHallsByCinemaId(int cinemaId);
    }
}