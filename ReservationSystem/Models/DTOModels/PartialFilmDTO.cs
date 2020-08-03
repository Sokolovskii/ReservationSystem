using System.Runtime.Serialization;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель DTO для частично описанного фильма
    /// </summary>
    [DataContract]
    public class PartialFilmDto
    {
        /// <summary>
        /// Id фильма
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        /// <summary>
        /// Название фильма
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Жанр фильма
        /// </summary>
        [DataMember(Name = "genre")]
        public string Genre { get; set; }

        /// <summary>
        /// Продолжительность фильма
        /// </summary>
        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Конструктор для конвертации из объекта доменной модели
        /// </summary>
        public PartialFilmDto(Film film)
        {
            Id = film.Id;
            Name = film.Name;
            Genre = film.Genre;
            Duration = film.Duration;
        }
    }
}