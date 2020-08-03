using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Repository.FilmRepository;
using ReservationSystem.Repository.PlaceRepository;
using ReservationSystem.Repository.SessionRepository;
using ReservationSystem.Services.ServiceResponse;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.PlaceService
{
    /// <summary>
    /// Класс сервисов для контроллера мест в зале
    /// </summary>
    /// <inheritdoc cref="IPlaceService"/>
    public class PlaceService : BaseService, IPlaceService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ISessionRepository _sessionRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="loggerFactory">Поставщик логгера</param>
        /// <param name="placeRepository">Репозиторий мест</param>
        /// <param name="sessionRepository">Репозиторий сессии</param>
        /// <param name="filmRepository">репозиторий фильма</param>
        public PlaceService(ILoggerFactory loggerFactory, IPlaceRepository placeRepository, ISessionRepository sessionRepository, IFilmRepository filmRepository) : base(loggerFactory.CreateLogger<PlaceService>())
        {
            _placeRepository = placeRepository;
            _sessionRepository = sessionRepository;
            _filmRepository = filmRepository;
        }

        public ServiceResponse<SessionDto> GetSessionById(int sessionId)
        {
            _logger.LogInformation($"Вход в метод PlaceService.GetSessionById c параметром {sessionId}");
            
            return Execute(() =>
            {
                var sessionDto = new SessionDto(_sessionRepository.GetSessionById(sessionId));
                return ServiceResponse<SessionDto>.Ok(sessionDto);
            });
        }

        public ServiceResponse<PartialFilmDto> GetPartialFilmById(int filmId)
        {
            _logger.LogTrace($"Вход в метод HallService.GetSessionsToHall c параметром {filmId}");
            return Execute(() =>
            {
                var film = _filmRepository.GetFilmById(filmId);
                return ServiceResponse<PartialFilmDto>.Ok(new PartialFilmDto(film));
            });
        }

        public ServiceResponse<IEnumerable<PlaceInHallDto>> GetPlacesBySessionId(int sessionId)
        {
            _logger.LogInformation($"Вход в метод PlaceService.GetPlacesBySessionId c параметром {sessionId}");
            
            return Execute(() =>
            {
                var places = _placeRepository.GetInfoAboutSessionInHall(sessionId);
                
                var listPlaceInHallDtos = places.Select(place => new PlaceInHallDto(place));

                return ServiceResponse<IEnumerable<PlaceInHallDto>>.Ok(listPlaceInHallDtos);
            });
        }

        public ServiceResponse.NonGeneric.ServiceResponse ReservePlaces(int[] placeIds, int sessionId, int userId)
        {
            _logger.LogInformation($"Вход в метод PlaceService.ReservePlaces");
            return Execute(()=>
                {
                    var places = _placeRepository.GetInfoAboutSessionInHall(sessionId);
                    
                    if (placeIds.Any(pr=> places.All(ps => ps.Id != pr)))
                        return ServiceResponse.NonGeneric.ServiceResponse.Warning(WarningMessages.PlaceNotFound);
                    

                    if (placeIds.Any(pr=> places.Any(ps=>ps.Id == pr && ps.UserId != 0)))
                        return ServiceResponse.NonGeneric.ServiceResponse.Warning(WarningMessages
                            .PlaceAlreadyReserved);
                    

                    foreach (var placeId in placeIds)
                    {
                        _placeRepository.ReserveSessionInHall(placeId, userId, sessionId);
                    }

                    return ServiceResponse.NonGeneric.ServiceResponse.Ok();
                });
        }

        public ServiceResponse.NonGeneric.ServiceResponse UnreserveSession(int sessionId, int userId)
        {
            _logger.LogInformation($"Вход в метод PlaceService.UnreserveSession");
            return Execute(() =>
                {
                    _placeRepository.UnreserveSessionInHall(userId, sessionId);
                    return ServiceResponse.NonGeneric.ServiceResponse.Ok();
                });
        }
    }
}