using System.Runtime.Serialization;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель DTO для кинотеатра
    /// </summary>
    [DataContract]
    public class CinemaDto
    {
        /// <summary>
        /// Идентификатор кинотеатра
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set;}

        /// <summary>
        /// Название кинотеатра
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Описание кинотеатра
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Конструктор для конвертации из объекта доменной модели
        /// </summary>
        public CinemaDto(Cinema cinema)
        {
            Id = cinema.Id;
            Name = cinema.Name;
            Description = cinema.Description;
        }
    }
}