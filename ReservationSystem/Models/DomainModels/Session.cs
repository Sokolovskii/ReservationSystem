using System;

namespace ReservationSystem.Models.DomainModels
{
    /// <summary>
    /// Модель описывающая сеанс кинотеатра
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Id сеанса
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Время начала сеанса 
        /// </summary>
        public TimeSpan TimeOfBegin { get; set; }
        
        /// <summary>
        /// Время конца сеанса
        /// </summary>
        public TimeSpan TimeOfEnd { get; set; }
        
        /// <summary>
        /// Дата сеанса
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Id Зала кинотеатра, в котором будет происходить сеанс
        /// </summary>
        public int HallId { get; set; }
        
        /// <summary>
        /// Id фильма, который будет показываться во время сессии
        /// </summary>
        public int FilmId { get; set; }

        /// <summary>
        ///Стоимость сеанса 
        /// </summary>
        public float Cost { get; set; }
    }
}