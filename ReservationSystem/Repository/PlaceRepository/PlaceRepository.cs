using System.Collections.Generic;
using System.Data;
using ReservationSystem.Exceptions;
using ReservationSystem.Models.DomainModels;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.ServiceResponse;

namespace ReservationSystem.Repository.PlaceRepository
{
    /// <summary>
    /// Класс, описывающий репозиторий места в зале
    /// </summary>
    /// <inheritdoc cref="IPlaceRepository"/>
    public class PlaceRepository : IPlaceRepository
    {
        private readonly Db _db;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="db"></param>
        public PlaceRepository(Db db)
        {
            _db = db;
        }

        public IEnumerable<PlaceInHall> GetInfoAboutSessionInHall(int sessionId)
        {
            return _db.GetList("GetInfoAboutSessionInHall", PlaceInHallFromReader,
                new DbParam("@SessionId", sessionId))
                   ?? throw new ObjectNotFoundException(WarningMessages.PlacesForThisSessionNotFound);
        }

        public IEnumerable<PlaceInHall> GetPlacesByHallId(int hallId)
        {
            return _db.GetList("GetPlacesByHallId", PlaceFromReader, new DbParam("@HallId", hallId))
                   ?? throw new ObjectNotFoundException(WarningMessages.PlaceNotFound);
        }

        public PlaceInHall GetPlaceById(int placeId, int sessionId)
        {
            var place = _db.GetItem("GetPlaceById", PlaceInHallFromReader, new DbParam("@PlaceId", placeId),
                new DbParam("@SessionId", sessionId));

            return place ?? throw new ObjectNotFoundException(WarningMessages.PlaceNotFound);
        }

        public void ReserveSessionInHall(int placeId, int userId, int sessionId)
        {
            _db.ExecuteNonQuery("ReserveSession",
                new DbParam("@PlaceId", placeId),
                new DbParam("@UserId", userId),new DbParam("@SessionId", sessionId) );
        }
        
        public void UnreserveSessionInHall(int userId, int sessionId)
        {
            _db.ExecuteNonQuery("UnreserveSession", 
                new DbParam("@UserId", userId), new DbParam("@SessionId", sessionId));
        }

        private static PlaceInHall PlaceInHallFromReader(IDataReader reader)
        {
            return new PlaceInHall
            {
                Id = reader.GetIntOrZero("PlaceId"),
                Row = reader.GetIntOrZero("Row"),
                Column = reader.GetIntOrZero("Column"),
                UserId = reader.GetIntOrZero("UserId")
            };
        }

        private static PlaceInHall PlaceFromReader(IDataReader reader)
        {
            return new PlaceInHall
            {
                Id = reader.GetIntOrZero("Id"),
                Row = reader.GetIntOrZero("Row"),
                Column = reader.GetIntOrZero("Column")
            };
        }
    }
}