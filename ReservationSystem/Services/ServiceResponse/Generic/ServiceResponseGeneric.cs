namespace ReservationSystem.Services.ServiceResponse.Generic
{
    /// <summary>
    /// Класс, описывающий сущность, включающую в себя код операции, данные и сообщение об ошибке, если таковая есть
    /// </summary>
    public class ServiceResponse<T> : NonGeneric.ServiceResponse
    {
        /// <summary>
        /// Данные, необходимые для передачи
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Метод, собирающий успешный респонс с передачей данных наверх
        /// </summary>
        /// <param name="data">Данные для передачи</param>
        public static ServiceResponse<T> Ok(T data)
        {
            return new ServiceResponse<T>
            {
                Code = ServiceResponseCode.Ok,
                Data = data,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Собирает респонс с предупреждением
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        public new static ServiceResponse<T> Warning(string message)
        {
            return new ServiceResponse<T>
            {
                Code = ServiceResponseCode.Warning,
                Message = message,
                Data = default
            };
        }

        /// <summary>
        /// Собирает респонс с исключением
        /// </summary>
        /// <param name="message">Сообщение об исключении</param>
        public new static ServiceResponse<T> Fail(string message)
        {
            return new ServiceResponse<T>
            {
                Code = ServiceResponseCode.Exсeption,
                Message = message,
                Data = default
            };
        }
    }
}