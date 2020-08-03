using System.Runtime.Serialization;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель DTO для зала
    /// </summary>
    [DataContract]
    public class HallDto
    {
        /// <summary>
        ///Id зала 
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Название зала
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Описание зала кинотеатра
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Количество мест в зале
        /// </summary>
        [DataMember(Name = "placesCount")]
        public int PlacesCount { get; set; }

		/// <summary>
		/// Id кинотеатра, в котором находится зал
		/// </summary>
		[DataMember(Name="cinemaId")]
		public int CinemaId { get; set; }

        /// <summary>
        /// Конструктор для конвертации из объекта доменной модели
        /// </summary>
        public HallDto(Hall hall)
        {
            Id = hall.Id;
            Name = hall.Name;
            Description = hall.Description;
            PlacesCount = hall.PlacesCount;
			CinemaId = hall.CinemaId;
        }
    }
}