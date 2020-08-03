using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Services.PersonService;
using ReservationSystem.Services.ServiceResponse.Generic;
using ReservationSystem.Services.ServiceResponse.NonGeneric;


namespace ReservationSystem.Controllers.PersonController
{
    /// <summary>
    /// АПИ пользователя
    /// </summary>
    [Route("api/person")]
    public class PersonControllerAPI : ControllerBase
    {

        private readonly IPersonService _personService;
        
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="personService">Сервисы пользователя</param>
        public PersonControllerAPI(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Возвращает респонс с пользователем без пароля в случае успешной авторизации
        /// </summary>
        /// <param name="person">Объект пользователя</param>
        [HttpPost("getUser")]
        public ServiceResponse<PersonPassLessDto> GetUser([FromBody]PersonDto person) => _personService.GetUser(person);

        /// <summary>
        /// Меняет имя пользователя и отправляет респонс с кодом операции
        /// </summary>
        /// <param name="person">Объект пользователя</param>
        [HttpPost("changeName")]
        public ServiceResponse ChangeName([FromBody]PersonPassLessDto person) => _personService.ChangeName(person);

        /// <summary>
        /// Меняет хэш пароля пользователя и отправляет респонс с кодом операции
        /// </summary>
        /// <param name="person">Объект пользователя</param>
        [HttpPost("changePassHash")]
        public ServiceResponse ChangePassHash([FromBody]PersonDto person) => _personService.ChangePassHash(person);

        /// <summary>
        /// Удаляет аккаунт пользователя
        /// </summary>
        /// <param name="person">Объект пользователя</param>
        [HttpPost("deleteAccount")]
        public ServiceResponse DeleteAccount([FromBody]PersonPassLessDto person) => _personService.DeleteAccount(person);

        /// <summary>
        /// Создает аккаунт пользователя
        /// </summary>
        /// <param name="person">Объект пользователя</param>
        [HttpPost("createAccount")]
        public ServiceResponse<PersonPassLessDto> CreateAccount([FromBody]PersonDto person) => _personService.CreateAccount(person);
    }
}