using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Repository.PersonRepository
{
    /// <summary>
    /// Интерфейс, описывающий репозиторий пользователя
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Возвращает пользователя по логину
        /// </summary>
        Person GetPersonByLogin(string login);

        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        void DeletePerson(int userId);

        /// <summary>
        /// Меняет имя пользователя
        /// </summary>
        void ChangePersonName(int userId, string newUserName);

        /// <summary>
        /// Меняет хэш пароля пользователя
        /// </summary>
        void ChangePersonPassHash(int userId, string newPassHash);

        /// <summary>
        /// Добавляет нового пользователя
        /// </summary>
        Person AddNewPerson(string userName, string login, string passHash);
    }
}