using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ReservationSystem.Models.DomainModels;

namespace ReservationSystem.Models.DTOModels
{
    /// <summary>
    /// Модель DTO для сессии
    /// </summary>
    [DataContract]
    public class SessionDto
    {
        /// <summary>
        /// Id сеанса
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Время начала сеанса 
        /// </summary>
        [JsonProperty("timeOfBegin")]
        public string TimeOfBegin { get; set; }
        
        /// <summary>
        /// Время конца сеанса
        /// </summary>
        [JsonProperty("timeOfEnd")]
        public string TimeOfEnd { get; set; }
        
        /// <summary>
        /// Дата сеанса
        /// </summary>
        [DataMember(Name = "date")]
        public string Date { get; set; }

        /// <summary>
        ///Стоимость сеанса 
        /// </summary>
        [DataMember(Name = "cost")]
        public float Cost { get; set; }

        /// <summary>
        /// Id зала
        /// </summary>
        [DataMember(Name = "hallId")] 
        public int HallId { get; set; }
        
        /// <summary>
        /// Id фильма
        /// </summary>
        [DataMember(Name = "FilmId")]
        public int FilmId { get; set; }
        
        /// <summary>
        /// Конструктор для конвертации из объекта доменной модели
        /// </summary>
        public SessionDto(Session session)
        {
            Id = session.Id;
            TimeOfBegin = session.TimeOfBegin.ToString();
            TimeOfEnd = session.TimeOfEnd.ToString();
			Date = session.Date.ToShortDateString().ToString();
            Cost = session.Cost;
            HallId = session.HallId;
            FilmId = session.FilmId;
        }
    }
}