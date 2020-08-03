using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.ServiceResponse;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.PersonService
{
    /// <summary>
    /// Интерфейс, описывающий класс сервисов контроллера пользователей
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Проводит проверку логина и пароля и в случае успеха отдает объект пользователя наверх
        /// </summary>
        /// <returns>Объект пользователя без пароля</returns>
        ServiceResponse<PersonPassLessDto> GetUser(PersonDto personDto);
        
        /// <summary>
        /// Меняет имя пользователя
        /// </summary>
        ServiceResponse.NonGeneric.ServiceResponse ChangeName(PersonPassLessDto personDto);

        /// <summary>
        /// Меняет хэш проля пользователя
        /// </summary>
        ServiceResponse.NonGeneric.ServiceResponse ChangePassHash(PersonDto personDto);

        /// <summary>
        /// Удаляет аккаунт пользователя
        /// </summary>
        ServiceResponse.NonGeneric.ServiceResponse DeleteAccount(PersonPassLessDto personDto);

        /// <summary>
        /// Создает аккаунт пользователя
        /// </summary>
        ServiceResponse<PersonPassLessDto> CreateAccount(PersonDto personDto);
    }
}