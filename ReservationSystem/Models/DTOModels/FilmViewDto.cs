using System.Collections.Generic;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель для представления Film.cshtml
    /// </summary>
    public class FilmViewDto
    {
        /// <summary>
        /// Фильм, который был запрошен
        /// </summary>
        public ServiceResponse<FilmDto> Film { get; set; }
        
        /// <summary>
        /// Список сеансов, на которых показывают фильм
        /// </summary>
        public ServiceResponse<IEnumerable<SessionDto>> Sessions { get; set; }
        
        /// <summary>
        /// Список залов, в которых проходят сеансы
        /// </summary>
        public ServiceResponse<IEnumerable<PartialHallDto>> Halls { get; set; }
    }
}