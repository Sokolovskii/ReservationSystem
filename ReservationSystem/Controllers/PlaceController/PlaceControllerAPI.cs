using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.PlaceService;
using ReservationSystem.Services.ServiceResponse.Generic;
using ReservationSystem.Services.ServiceResponse.NonGeneric;

namespace ReservationSystem.Controllers.PlaceController
{
    /// <summary>
    /// АПИ мест в зале
    /// </summary>
    [Route("api/place")]
    public class PlaceControllerAPI : ControllerBase
    {
        private readonly IPlaceService _placeService;
        
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="placeService">Сервисы мест в зале</param>
        public PlaceControllerAPI(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        /// <summary>
        /// Возвращает респонс со списком мест по Id сессии
        /// </summary>
        /// <param name="sessionId">Id сессии</param>
        [HttpGet("getInfoAboutPlaces")]
        public ServiceResponse<IEnumerable<PlaceInHallDto>> GetPlacesBySessionId(int sessionId) => _placeService.GetPlacesBySessionId(sessionId);

        /// <summary>
        /// Возвращает респонс с сессией по ее Id
        /// </summary>
        /// <param name="sessionId">Id сессии</param>
        [HttpGet("GetSessionbyId")]
        public ServiceResponse<SessionDto> GetSessionById(int sessionId) => _placeService.GetSessionById(sessionId);

        /// <summary>
        /// Возвращает респонс с краткой информацией по фильму по его Id
        /// </summary>
        /// <param name="filmId"></param>
        [HttpGet("GetPartialFilmById")]
        public ServiceResponse<PartialFilmDto> GetPartialFilmById(int filmId) => _placeService.GetPartialFilmById(filmId);

        ///  <summary>
        ///  Бронирует множество мест и возвращает успешный респонс, если места были зарезервированы
        ///  </summary>
        ///  <param name="sessionsToReserve">Массив сессий для бронирования</param>

        [HttpPost("ReserveSessions")]
        public ServiceResponse ReserveSessions([FromBody]SessionsToReserveDTO sessionsToReserve) => _placeService.ReservePlaces(sessionsToReserve.placeIds, sessionsToReserve.sessionId,sessionsToReserve.userId);

        /// <summary>
        /// Отменяет бронь для пользователя на конкретную сессию и возвращает успешный респонс, если места были разбронированны
        /// </summary>
        ///  <param name="sessionToUnreserved">Сессия и пользователь для отмены брони</param>
        [HttpPost("UnreserveSessions")]
        public ServiceResponse UnreserveSessions([FromBody]SessionToUnreservedDTO sessionToUnreserved) => _placeService.UnreserveSession(sessionToUnreserved.sessionId, sessionToUnreserved.userId);
    }
}