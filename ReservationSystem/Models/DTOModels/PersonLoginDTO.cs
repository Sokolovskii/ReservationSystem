using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ReservationSystem.Models.DTOModels
{
	[DataContract]
	public class PersonLoginDTO
	{
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
