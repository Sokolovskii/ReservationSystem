using System.Collections.Generic;
using System.Data;
using ReservationSystem.Exceptions;
using ReservationSystem.Models.DomainModels;
using ReservationSystem.Services.ServiceResponse;

namespace ReservationSystem.Repository.SessionRepository
{
    /// <summary>
    /// Класс, описывающий репозиторий сессии
    /// </summary>
    /// <inheritdoc cref="ISessionRepository"/>
    public class SessionRepository : ISessionRepository
    {
        private readonly Db _db;

        /// <summary>
        /// .ctor
        /// </summary>
        public SessionRepository(Db db)
        {
            _db = db;
        }

        public Session GetSessionById(int sessionId)
        {
            return _db.GetItem("GetSessionById", SessionFromReader, new DbParam("@SessionId", sessionId))
                   ?? throw new ObjectNotFoundException(WarningMessages.SessionNotFound);
        }

        public IEnumerable<Session> GetSessionsForFilmInCinema(int filmId, int cinemaId)
        {
			return _db.GetList("GetSessionsForFilmInCinema", SessionForFilmFromReader,
				new DbParam("@FilmId", filmId), new DbParam("@CinemaId", cinemaId));
        }

        public IEnumerable<Session> GetSessionsForHall(int hallId)
        {
			return _db.GetList("GetSessionsForHallInCinema", SessionForHallFromReader,
                new DbParam("@hallId", hallId));
		}

        private static Session SessionForFilmFromReader(IDataReader reader)
        {
            return new Session
            {
                Id = reader.GetIntOrZero("Id"),
                Date = reader.GetDate("Date"),
                TimeOfBegin = reader.GetTime("TimeOfBegin"),
                TimeOfEnd = reader.GetTime("TimeOfEnd"),
                Cost = reader.GetIntOrZero("Cost"),
                HallId = reader.GetIntOrZero("HallId")
            };
        }
        
        private static Session SessionForHallFromReader(IDataReader reader)
        {
            return new Session
            {
                Id = reader.GetIntOrZero("Id"),
                Date = reader.GetDate("Date"),
                TimeOfBegin = reader.GetTime("TimeOfBegin"),
                TimeOfEnd = reader.GetTime("TimeOfEnd"),
                Cost = reader.GetIntOrZero("Cost"),
                FilmId = reader.GetIntOrZero("FilmId")
            };
        }

        private static Session SessionFromReader(IDataReader reader)
        {
            return new Session
            {
                Id = reader.GetIntOrZero("Id"),
                Date = reader.GetDate("Date"),
                TimeOfBegin = reader.GetTime("TimeOfBegin"),
                TimeOfEnd = reader.GetTime("TimeOfEnd"),
                Cost = reader.GetIntOrZero("Cost"),
                FilmId = reader.GetIntOrZero("FilmId"),
                HallId = reader.GetIntOrZero("HallId")
            };
        }
    }
}