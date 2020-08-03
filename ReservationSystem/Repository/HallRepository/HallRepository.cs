using System.Collections.Generic;
using System.Data;
using ReservationSystem.Exceptions;
using ReservationSystem.Models.DomainModels;
using ReservationSystem.Services.ServiceResponse;

namespace ReservationSystem.Repository.HallRepository
{
    /// <summary>
    /// Класс, описывающий репозиторий залов
    /// </summary>
    /// <inheritdoc cref="IHallRepository"/>
    public class HallRepository : IHallRepository
    {
        private readonly Db _db;

        public HallRepository(Db db)
        {
            _db = db;
        }

        public IEnumerable<Hall> GetHallsByCinemaId(int cinemaId)
        {
            return _db.GetList("GetHallsByCinemaId", HallFromReader, new DbParam("@CinemaId", cinemaId));
        }
        
        public Hall GetHallById(int hallId)
        {
            return _db.GetItem("GetHallById", HallFromReader, new DbParam("@HallId", hallId))
                   ?? throw new ObjectNotFoundException(WarningMessages.HallNotFound);
        }

        private static Hall HallFromReader(IDataReader reader)
        {
			return new Hall
			{
				Id = reader.GetIntOrZero("Id"),
				Name = reader.GetString("Name"),
				Description = reader.GetString("Description"),
				PlacesCount = reader.GetIntOrZero("PlacesCount"),
				CinemaId = reader.GetIntOrZero("CinemaId")
            };
        }
    }
}