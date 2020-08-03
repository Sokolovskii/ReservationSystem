using System.Collections.Generic;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель для представления Hall.cshtml
    /// </summary>
    public class HallViewDto
    {
        /// <summary>
        /// Зал, который был запрошен
        /// </summary>
        public ServiceResponse<HallDto> Hall { get; set; }
        
        /// <summary>
        /// Список сессий, проводимых в этом зале
        /// </summary>
        public ServiceResponse<IEnumerable<SessionDto>> Sessions { get; set; }
        
        /// <summary>
        /// Список фильмов, которые показывают в этом зале
        /// </summary>
        public ServiceResponse<IEnumerable<PartialFilmDto>> Films { get; set; }
        
        public ServiceResponse<IEnumerable<PlaceDto>> Places { get; set; }
    }
}