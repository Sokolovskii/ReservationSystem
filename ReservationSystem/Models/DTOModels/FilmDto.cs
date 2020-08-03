using System.Runtime.Serialization;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель DTO для фильма
    /// </summary>
    [DataContract]
    public class FilmDto
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
        /// Описание фильма
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Страна-производитель фильма
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; set; }
        
        /// <summary>
        /// Режиссер фильма
        /// </summary>
        [DataMember(Name = "producer")]
        public string Producer { get; set; }
        
        /// <summary>
        /// Год производства фильма
        /// </summary>
        [DataMember(Name = "yearOfProduction")]
        public int YearOfProduction { get; set; }

        /// <summary>
        /// Конструктор для конвертации из объекта доменной модели
        /// </summary>
        public FilmDto(Film film)
        {
            Id = film.Id;
            Name = film.Name;
            Genre = film.Genre;
            Duration = film.Duration;
            Description = film.Description;
            Country = film.Country;
            Producer = film.Producer;
            YearOfProduction = film.YearOfProduction;
        }
    }
}