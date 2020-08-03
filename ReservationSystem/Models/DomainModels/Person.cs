namespace ReservationSystem.Models.DomainModels
{
    /// <summary>
    /// Модель, описывающая пользователя
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }
        
        /// <summary>
        /// Хэш пароля пользователя
        /// </summary>
        public string PassHash { get; set; }
    }
}