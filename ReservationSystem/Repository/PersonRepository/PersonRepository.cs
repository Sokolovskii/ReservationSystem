using System.Data;
using ReservationSystem.Exceptions;
using ReservationSystem.Models.DomainModels;
using ReservationSystem.Services.ServiceResponse;

namespace ReservationSystem.Repository.PersonRepository
{
    /// <summary>
    /// Класс репозитория пользователя
    /// </summary>
    /// <inheritdoc cref="IPersonRepository"/>
    public class PersonRepository : IPersonRepository
    {
        private readonly Db _db;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="db"></param>
        public PersonRepository(Db db)
        {
            _db = db;
        }

        public Person GetPersonByLogin(string login)
        {
            return _db.GetItem("GetPersonByLogin", PersonFromReader, new DbParam("@Login", login))
                   ?? throw new ObjectNotFoundException(WarningMessages.PersonNotFound);
        }

        public void DeletePerson(int userId)
        {
            _db.ExecuteNonQuery("DeleteUser",new DbParam("@UserId", userId));
        }

        public void ChangePersonName(int userId, string newUserName)
        {
            _db.ExecuteNonQuery("ChangeUserName",
                new DbParam("@UserId", userId),new DbParam("@UserName", newUserName));
        }

        public void ChangePersonPassHash(int userId, string newPassHash)
        {
            _db.ExecuteNonQuery("ChangeUserPassword",
                new DbParam("@UserId", userId),new DbParam("@PassHash", newPassHash));
        }

        public Person AddNewPerson(string name, string login, string passHash)
        {
            var personWithId = _db.GetItem("AddNewUser", PersonFromReaderWithOnlyId,
                new DbParam("@UserName", name), new DbParam("@Login", login),new DbParam("@PassHash", passHash));
            personWithId.Login = login;
            personWithId.Name = name;
            return personWithId;
        }

        private static Person PersonFromReader(IDataReader reader)
        {
            return new Person
            {
                Id = reader.GetIntOrZero("Id"),
                Login = reader.GetString("Login"),
                PassHash = reader.GetString("PassHash"),
                Name = reader.GetString("Name")
            };
        }

        private static Person PersonFromReaderWithOnlyId(IDataReader reader)
        {
            return new Person
            {
                Id = reader.GetIntOrZero("Id")
            };
        }
    }
}