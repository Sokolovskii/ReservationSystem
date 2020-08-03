namespace ReservationSystem.Services.ServiceResponse.NonGeneric
{
    /// Класс, описывающий сущность, включающую в себя код операции и сообщение об ошибке, если таковая есть
    public class ServiceResponse
    {
        /// <summary>
        /// Код выполнения команды
        /// </summary>
        public ServiceResponseCode Code { get; protected set; }
        
        /// <summary>
        /// Сообщение об ошибке, если таковая есть
        /// </summary>
        public string Message { get; protected set; }

        /// <summary>
        /// Собирает успешный респонс
        /// </summary>
        /// <returns></returns>
        public static ServiceResponse Ok()
        {
            return new ServiceResponse
            {
                Code = ServiceResponseCode.Ok,
                Message = string.Empty
            };
        }

        /// <summary>
        /// Собирает респонс с предупреждением
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        public static ServiceResponse Warning(string message)
        {
            return new ServiceResponse
            {
                Code = ServiceResponseCode.Warning,
                Message = message
            };
        }

        /// <summary>
        /// Собирает респонс с исключением
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        public static ServiceResponse Fail(string message)
        {
            return new ServiceResponse
            {
                Code = ServiceResponseCode.Exсeption,
                Message = message
            };
        }
    }
}