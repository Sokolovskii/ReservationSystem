namespace ReservationSystem.Models.DomainModels
{
    /// <summary>
    /// Модель, описывающая кинотеатр
    /// </summary>
    public class Cinema
    {
        /// <summary>
        /// Идентификатор кинотеатра
        /// </summary>
        public int Id { get; set;}

        /// <summary>
        /// Название кинотеатра
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание кинотеатра
        /// </summary>
        public string Description { get; set; }

    }
}