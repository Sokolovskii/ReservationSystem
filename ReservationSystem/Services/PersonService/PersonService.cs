using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReservationSystem.Models.DomainModels;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Repository.PersonRepository;
using ReservationSystem.Services.ServiceResponse;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.PersonService
{
    /// <summary>
    /// Класс сервисов для контроллера пользователей
    /// </summary>
    /// <inheritdoc cref="IPersonService"/>
    public class PersonService : BaseService, IPersonService
    {
        private readonly IPersonRepository _personRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="loggerFactory">Поставщик логгера</param>
        /// <param name="personRepository">Репозиторий пользователя</param>
        public PersonService(ILoggerFactory loggerFactory, IPersonRepository personRepository) : base(loggerFactory.CreateLogger<PersonService>())
        {
            _personRepository = personRepository;
        }

        public ServiceResponse<PersonPassLessDto> GetUser(PersonDto personDto)
        {
            _logger.LogInformation($"Вход в метод PersonService.GetUser c параметром {personDto}");
            
            return Execute(() =>
            {
                var user = _personRepository.GetPersonByLogin(personDto.Login);
                return ValidateAccount(user, personDto.Login, personDto.PassHash);
            });
        }

        public ServiceResponse.NonGeneric.ServiceResponse ChangeName(PersonPassLessDto personDto)
        {
            _logger.LogInformation($"Вход в метод PersonService.ChangeName c параметром {personDto}");
            return Execute(() =>
            {
                _personRepository.ChangePersonName(personDto.Id, personDto.Name);
                return ServiceResponse.NonGeneric.ServiceResponse.Ok();
            });
        }

        public ServiceResponse.NonGeneric.ServiceResponse ChangePassHash(PersonDto personDto)
        {
            _logger.LogInformation($"Вход в метод PersonService.ChangePassHash c параметром {personDto}");
            return Execute(() =>
            {
                _personRepository.ChangePersonPassHash(personDto.Id, personDto.PassHash);
                return ServiceResponse.NonGeneric.ServiceResponse.Ok();
            });
        }

        public ServiceResponse.NonGeneric.ServiceResponse DeleteAccount(PersonPassLessDto personDto)
        {
            _logger.LogInformation($"Вход в метод PersonService.DeleteAccount c параметром {personDto}");
            return Execute(() =>
            {
                _personRepository.DeletePerson(personDto.Id);
                return ServiceResponse.NonGeneric.ServiceResponse.Ok();
            });
        }

        public ServiceResponse<PersonPassLessDto> CreateAccount(PersonDto personDto)
        {
            _logger.LogInformation($"Вход в метод PersonService.CreateAccount c параметром {personDto}");
            return Execute(()=>
            {
                var person = _personRepository.AddNewPerson(personDto.Name, personDto.Login, personDto.PassHash);
                return ServiceResponse<PersonPassLessDto>.Ok(new PersonPassLessDto(person));
            });
        }

        private static ServiceResponse<PersonPassLessDto> ValidateAccount(Person person ,string login, string passHash)
        {
            return person.Login == login && person.PassHash == passHash
                ? ServiceResponse<PersonPassLessDto>.Ok(new PersonPassLessDto(person))
                : ServiceResponse<PersonPassLessDto>.Warning(WarningMessages.LoginOrPassNotEqual);
        }
    }
}