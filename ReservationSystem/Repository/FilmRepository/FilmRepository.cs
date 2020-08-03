using System.Collections.Generic;
using System.Data;
using ReservationSystem.Exceptions;
using ReservationSystem.Models.DomainModels;
using ReservationSystem.Services.ServiceResponse;

namespace ReservationSystem.Repository.FilmRepository
{
    /// <summary>
    /// Класс, описывающий репозиторий фильма
    /// </summary>
    /// <inheritdoc cref="IFilmRepository"/>
    public class FilmRepository : IFilmRepository
    {
        private readonly Db _db;
        /// <summary>
        /// .ctor
        /// </summary>
        public FilmRepository(Db db)
        {
            _db = db;
        }

        public IEnumerable<Film> GetFilmsByCinemaId(int cinemaId)
        {
            return _db.GetList("GetFilmsByCinemaId", FilmFromReader,
                new DbParam("@CinemaId", cinemaId));
        }
        
        public IEnumerable<Film> GetFilmsByHallId(int hallId)
        {
            return _db.GetList("GetFilmsByHallId", FilmFromReader,
                new DbParam("@HallId", hallId));
        }

        public Film GetFilmById(int filmId)
        {
            return _db.GetItem("GetFilmById", FilmFromReader,
                new DbParam("@FilmId", filmId))
                   ?? throw new ObjectNotFoundException(WarningMessages.FilmNotFound);
        }
        
        private static Film FilmFromReader(IDataReader reader)
        {
            
            return new Film
            {
                Id = reader.GetIntOrZero("Id"),
                Name = reader.GetString("Name"),
                Genre = reader.GetString("Genre"),
                Description = reader.GetString("Description"),
                Duration = reader.GetIntOrZero("Duration"),
                Producer = reader.GetString("Producer"),
                Country = reader.GetString("Contry"),
                YearOfProduction = reader.GetIntOrZero("YearOfProduction")
            };
            
        }
    }
}