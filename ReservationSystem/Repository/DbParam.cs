namespace ReservationSystem.Repository
{
    /// <summary>
    /// Класс, описывающий пару Название-Значение для параметров хранимых процедур в sql
    /// </summary>
    public class DbParam
    {
        /// <summary>
        /// Название параметра
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Значение параметра
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Конструктор, который получает значения названия и значения и присваевает их полям
        /// </summary>
        /// <param name="name">Название параметра</param>
        /// <param name="value">Значение параметра</param>
        public DbParam(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}