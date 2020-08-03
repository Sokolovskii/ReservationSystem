using System.Runtime.Serialization;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель DTO для пользователя
    /// </summary>
    [DataContract]
    public class PersonDto
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
		/// Хэш пароля пользователя
		/// </summary>
		[DataMember(Name = "passHash")]
		public string PassHash { get; set; }

	}
}