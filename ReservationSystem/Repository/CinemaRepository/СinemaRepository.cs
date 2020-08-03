using System.Collections.Generic;
using System.Data;
using ReservationSystem.Exceptions;
using ReservationSystem.Models.DomainModels;
using ReservationSystem.Services.ServiceResponse;

namespace ReservationSystem.Repository.CinemaRepository
{
    /// <summary>
    /// Класс, описывающий репозиторий кинотеатров
    /// </summary>
    /// <inheritdoc cref="ICinemaRepository"/>
    public class CinemaRepository : ICinemaRepository
    {
        private readonly Db _db;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="db"></param>
        public CinemaRepository(Db db)
        {
            _db = db;
        }
        
        public IEnumerable<Cinema> GetAllCinemas()
        {
            return _db.GetList("GetAllCinemas", CinemaFromReader);
            
        }

        public Cinema GetCinemaById(int cinemaId)
        {
            return _db.GetItem("GetCinemaById", CinemaFromReader,
                new DbParam("@CinemaId", cinemaId))
                   ?? throw new ObjectNotFoundException(WarningMessages.CinemaNotFound);
        }
        

        private static Cinema CinemaFromReader(IDataReader reader)
        {
            return new Cinema
            {
                Id = reader.GetIntOrZero("Id"),
                Description = reader.GetString("Description"),
                Name = reader.GetString("Name")
            };
        }
    }
}



