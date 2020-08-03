using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ReservationSystem.Models.DTOModels;
using ReservationSystem.Repository.CinemaRepository;
using ReservationSystem.Repository.FilmRepository;
using ReservationSystem.Repository.HallRepository;
using ReservationSystem.Services.ServiceResponse.Generic;

namespace ReservationSystem.Services.CinemaService
{
    ///<summary>
    ///Класс сервисов кинотеатра
    /// </summary>
    /// <inheritdoc cref="ICinemaService"/>
    public class CinemaService : BaseService, ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IHallRepository _hallRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="loggerFactory">Поставщик логгера</param>
        /// <param name="cinemaRepository">Репозиторий кинотеатра</param>
        /// <param name="filmRepository">Репозиторий фильмов</param>
        /// <param name="hallRepository">Репозиторий залов</param>
        public CinemaService(ILoggerFactory loggerFactory, ICinemaRepository cinemaRepository, IFilmRepository filmRepository, IHallRepository hallRepository) : base(loggerFactory.CreateLogger<CinemaService>())
        {
            _cinemaRepository = cinemaRepository;
            _filmRepository = filmRepository;
            _hallRepository = hallRepository;
        }

        public ServiceResponse<CinemaDto> GetCinemaById(int cinemaId)
        {
            _logger.LogInformation($"Вход в метод CinemaService.GetCinemaById c параметром {cinemaId}");
            return Execute(() =>
            {
                var cinemaDto = new CinemaDto(_cinemaRepository.GetCinemaById(cinemaId));
                return ServiceResponse<CinemaDto>.Ok(cinemaDto);
            });
        }

        public ServiceResponse<IEnumerable<PartialFilmDto>> GetFilmsByCinemaId(int cinemaId)
        {
            _logger.LogInformation($"Вход в метод CinemaService.GetFilmsByCinemaId c параметром {cinemaId}");
            return Execute(() =>
            {
                var films = _filmRepository.GetFilmsByCinemaId(cinemaId);
                
                var listPartialFilmDtos = films.Select(film => new PartialFilmDto(film));

                return ServiceResponse<IEnumerable<PartialFilmDto>>.Ok(listPartialFilmDtos);
            });
        }

        public ServiceResponse<IEnumerable<PartialHallDto>> GetHallsByCinemaId(int cinemaId)
        {
            _logger.LogInformation($"Вход в метод CinemaService.GetHallsByCinemaId c параметром {cinemaId}");
            return Execute(() =>
            {
                var halls = _hallRepository.GetHallsByCinemaId(cinemaId);
                
                var listPartialHallDtos = halls.Select(hall => new PartialHallDto(hall));

                return ServiceResponse<IEnumerable<PartialHallDto>>.Ok(listPartialHallDtos);
            });
        }

        public ServiceResponse<IEnumerable<CinemaDto>> GetAllCinemas()
        {
            _logger.LogInformation($"Вход в метод CinemaService.GetAllCinemas");
            return Execute(() =>
            {
                var cinemas = _cinemaRepository.GetAllCinemas();
                
                var listCinemaDtos = cinemas.Select(cinema => new CinemaDto(cinema));
                return ServiceResponse<IEnumerable<CinemaDto>>.Ok(listCinemaDtos);
            });
        }
    }
}