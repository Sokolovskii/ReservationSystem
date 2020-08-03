using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Repository.FilmRepository;
using ReservationSystem.Repository.HallRepository;
using ReservationSystem.Repository.PlaceRepository;
using ReservationSystem.Repository.SessionRepository;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.HallService
{
    /// <summary>
    /// Класс сервисов для контроллера залов
    /// </summary>
    /// <inheritdoc cref="IHallService"/>
    public class HallService : BaseService, IHallService
    {
        private readonly IHallRepository _hallRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IPlaceRepository _placeRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="loggerFactory">Поставщик логгера</param>
        /// <param name="hallRepository">Репозиторий залов</param>
        /// <param name="sessionRepository">Репозиторий сессий</param>
        /// <param name="filmRepository">Репозиторий фильмов</param>
        public HallService(ILoggerFactory loggerFactory, IHallRepository hallRepository, ISessionRepository sessionRepository, IFilmRepository filmRepository, IPlaceRepository placeRepository) : base(loggerFactory.CreateLogger<HallService>())
        {
            _hallRepository = hallRepository;
            _sessionRepository = sessionRepository;
            _filmRepository = filmRepository;
            _placeRepository = placeRepository;
        }
        
        public ServiceResponse<HallDto> GetHallById(int hallId)
        {
            _logger.LogInformation($"Вход в метод HallService.GetHallById c параметром {hallId}");
            
            return Execute(() =>
            {
                var hallDto = new HallDto(_hallRepository.GetHallById(hallId));
                
                return ServiceResponse<HallDto>.Ok(hallDto);
            });
        }

        public ServiceResponse<IEnumerable<SessionDto>> GetSessionsToHall(int hallId)
        {
            _logger.LogInformation($"Вход в метод HallService.GetSessionsToHall c параметром {hallId}");
            
            return Execute(() =>
            {
                var sessions = _sessionRepository.GetSessionsForHall(hallId);
                
                var listSessionDtos = sessions.Select(session => new SessionDto(session));
                
                return ServiceResponse<IEnumerable<SessionDto>>.Ok(listSessionDtos);
            });
        }

        public ServiceResponse<IEnumerable<PartialFilmDto>> GetPartialFilmsByHallId(int hallId)
        {
            _logger.LogInformation($"Вход в метод HallService.GetPartialFilmByCinemaId c параметром {hallId}");
            return Execute(() =>
            {
                var films = _filmRepository.GetFilmsByHallId(hallId);
                var listFilmmDtos = films.Select((film => new PartialFilmDto(film)));
                return ServiceResponse<IEnumerable<PartialFilmDto>>.Ok(listFilmmDtos);
            });
        }

        public ServiceResponse<IEnumerable<PlaceDto>> GetPlacesByHallId(int hallId)
        {
            _logger.LogInformation($"вход в метод HallService.GetPlacesInHallByHallId с параметром{hallId}");
            return Execute(() =>
            {
                var places = _placeRepository.GetPlacesByHallId(hallId);
                var placesDtos = places.Select(place => new PlaceDto(place));
                return ServiceResponse<IEnumerable<PlaceDto>>.Ok(placesDtos);
            });
        }
    }
}