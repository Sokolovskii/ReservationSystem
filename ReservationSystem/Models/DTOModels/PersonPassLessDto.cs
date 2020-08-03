using System.Runtime.Serialization;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель DTO для пользователя, не содержащая пароля
    /// </summary>
    [DataContract]
    public class PersonPassLessDto
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [DataMember(Name = "login")]
        public string Login { get; set; }
        
        /// <summary>
        /// .ctor
        /// </summary>
        public PersonPassLessDto() {}

        /// <summary>
        /// Конструктор для конвертации из объекта доменной модели
        /// </summary>
        public PersonPassLessDto(Person person)
        {
            Id = person.Id;
            Name = person.Name;
            Login = person.Login;
        }
    }
}