namespace ReservationSystem.Models.DomainModels
{
    /// <summary>
    /// Модель описывающая фильм
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Id фильма
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название фильма
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Жанр фильма
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Продолжительность фильма
        /// </summary>
        public int Duration { get; set; }
        
        /// <summary>
        /// Описание фильма
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Страна-производитель фильма
        /// </summary>
        public string Country { get; set; }
        
        /// <summary>
        /// Режиссер фильма
        /// </summary>
        public string Producer { get; set; }
        
        /// <summary>
        /// Год производства фильма
        /// </summary>
        public int YearOfProduction { get; set; } 
    }
}