using System.Runtime.Serialization;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель DTO для частично описанного зала
    /// </summary>
    [DataContract]
    public class PartialHallDto
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
        /// Конструктор для конвертации из объекта доменной модели
        /// </summary>
        public PartialHallDto(Hall hall)
        {
            Id = hall.Id;
            Name = hall.Name;
        }
    }
}