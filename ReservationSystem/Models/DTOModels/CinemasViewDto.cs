using System.Collections.Generic;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Models.DTOModels
{
    public class CinemasViewDto
    {
        public ServiceResponse<IEnumerable<CinemaDto>> Cinemas { get; set; }
    }
}