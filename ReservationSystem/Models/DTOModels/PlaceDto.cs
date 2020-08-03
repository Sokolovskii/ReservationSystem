using System.Runtime.Serialization;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Models.DTOModels
{
    [DataContract]
    public class PlaceDto
    {
        /// <summary>
        /// Id места в зале
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Ряд в зале
        /// </summary>
        [DataMember(Name = "row")]
        public int Row { get; set; }
        
        /// <summary>
        /// Место в зале
        /// </summary>
        [DataMember(Name = "column")]
        public  int Column { get; set; }

        /// <summary>
        /// Id пользователя, занявшего место (если значение равно 0, значит никем не занято)
        /// </summary>
        [DataMember(Name = "userId")]
        public int UserId { get; set; }

        /// <summary>
        /// Конструктор для конвертации из объекта доменной модели
        /// </summary>
        public PlaceDto(PlaceInHall placeInHall)
        {
            Id = placeInHall.Id;
            Row = placeInHall.Row;
            Column = placeInHall.Column;
        }
    }
}