using System.Collections.Generic;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель для представления Cinema.cshtml
    /// </summary>
    public class CinemaViewDto
    {
        /// <summary>
        /// Кинотеатр, который был запрошен
        /// </summary>
        public ServiceResponse<CinemaDto> Cinema { get; set; }
        
        /// <summary>
        /// Список фильмов, которые представлены к показу
        /// </summary>
        public ServiceResponse<IEnumerable<PartialFilmDto>> FilmList { get; set; }
        
        /// <summary>
        /// Список залов в кинотеатре
        /// </summary>
        public ServiceResponse<IEnumerable<PartialHallDto>> HallList { get; set; }
    }
}