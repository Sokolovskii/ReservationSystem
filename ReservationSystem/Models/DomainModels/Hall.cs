namespace ReservationSystem.Models.DomainModels
{
    /// <summary>
    /// Модель, описывающая зал кинотеатра
    /// </summary>
    public class Hall
    {
        /// <summary>
        ///Id зала 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название зала
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание зала кинотеатра
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Количество мест в зале
        /// </summary>
        public int PlacesCount { get; set; }


		/// <summary>
		/// Id кинотеатра, в котором находится зал
		/// </summary>
		public int CinemaId { get; set; }

	}
}