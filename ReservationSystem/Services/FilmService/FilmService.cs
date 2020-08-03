using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Repository.FilmRepository;
using ReservationSystem.Repository.HallRepository;
using ReservationSystem.Repository.SessionRepository;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.FilmService
{
    /// <summary>
    /// Класс сервисов для контроллера фильмов
    /// </summary>
    /// <inheritdoc cref="IFilmService"/>>
    public class FilmService : BaseService, IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IHallRepository _hallRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="loggerFactory">Поставщик логгера</param>
        /// <param name="filmRepository">Репозиторий фильмов</param>
        /// <param name="sessionRepository">Репозиторий сессий</param>
        /// <param name="hallRepository">Репозиторий залов</param>
        public FilmService(ILoggerFactory loggerFactory, IFilmRepository filmRepository, ISessionRepository sessionRepository, IHallRepository hallRepository) : base(loggerFactory.CreateLogger<FilmService>())
        {
            _filmRepository = filmRepository;
            _sessionRepository = sessionRepository;
            _hallRepository = hallRepository;
        }
        
        public ServiceResponse<FilmDto> GetFilmById(int filmId)
        {
            _logger.LogInformation($"Вход в метод FilmService.GetFilmById c параметром {filmId}");
            
            return Execute(() =>
            {
                var filmDto = new FilmDto(_filmRepository.GetFilmById(filmId));
                return ServiceResponse<FilmDto>.Ok(filmDto);
            });
        }

        public ServiceResponse<IEnumerable<SessionDto>> GetSessionsToFilmInCinema(int filmId, int cinemaId)
        {
            _logger.LogInformation($"Вход в метод FilmService.GetSessionsToFilmInCinema c параметрами {filmId}, {cinemaId}");
            
            return Execute(() =>
            {
                var sessions = _sessionRepository.GetSessionsForFilmInCinema(filmId, cinemaId);
                
                var listSessionDtos = sessions.Select(session => new SessionDto(session));
                return ServiceResponse<IEnumerable<SessionDto>>.Ok(listSessionDtos);
            });
        }

        public ServiceResponse<IEnumerable<PartialHallDto>> GetHallsByCinemaId(int cinemaId)
        {
            _logger.LogInformation($"Вход в метод FilmService.GetHallsByCinemaId c параметром {cinemaId}");
            return Execute(() =>
            {
                var halls = _hallRepository.GetHallsByCinemaId(cinemaId);
                var listHallsDtos = halls.Select(hall => new PartialHallDto(hall));
                return ServiceResponse<IEnumerable<PartialHallDto>>.Ok(listHallsDtos);
            });
        }
    }
}