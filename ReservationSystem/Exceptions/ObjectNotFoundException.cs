using System;

namespace ReservationSystem.Exceptions
{
    /// <summary>
    /// Исключение, вызванное отсутствием объекта в базе данных
    /// </summary>
    public class ObjectNotFoundException : Exception
    {
        /// <summary>
        /// Конструктор исключения с сообщением
        /// </summary>
        public ObjectNotFoundException(string message) : base(message)
        { }
    }
}