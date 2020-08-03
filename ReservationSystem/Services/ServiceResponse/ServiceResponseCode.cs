namespace ReservationSystem.Services.ServiceResponse
{
    /// <summary>
    /// Перечисление возможных кодов для ответа от сервиса
    /// </summary>
    public enum ServiceResponseCode
    {
        Ok = 0,              // Сервис отработал без ошибок
        Warning = 1,         // Сервис отработал с типовой ошибкой, которая была предусмотрена
        Exсeption = 2        // Сервис вызвал исключение, которое не было предусмотрено
    }
}