namespace ReservationSystem.Models.DomainModels
{
    /// <summary>
    /// Модель, описывающая место в зале кинотеатра
    /// </summary>
    public class PlaceInHall
    {
        /// <summary>
        /// Id места в зале
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Ряд в зале
        /// </summary>
        public int Row { get; set; }
        
        /// <summary>
        /// Место в зале
        /// </summary>
        public  int Column { get; set; }

        /// <summary>
        /// Id пользователя, занявшего место (если значение равно 0, значит никем не занято)
        /// </summary>
        public int UserId { get; set; }
        
    }
}