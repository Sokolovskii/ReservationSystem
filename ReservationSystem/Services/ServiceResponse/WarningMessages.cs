namespace ReservationSystem.Services.ServiceResponse
{
    /// <summary>
    /// Класс типовых сообщений об ошибках
    /// </summary>
    public static class WarningMessages
    {
        public const string PlaceAlreadyReserved = "Место уже было забронировано, выберите другое место и повторите запрос";

        public const string LoginHasInBase =
            "Пользователь с таким логином уже существует, введите другой логин и повторите запрос";

        public const string LoginOrPassNotEqual = "Введен неверный логин или пароль, уточните данные и повторите запрос";

        public const string PlaceAlreadyUnreserved =
            "Место уже было разбронировано, выберите другое место и повторите запрос";

        public const string SessionsForThisFilmNotFound = "Сессии для этого фильма не были найдены";

        public const string PlacesForThisSessionNotFound = "Места для данного сеанса не были найдены";

        public const string HallsForCinemaNotFound = "Залы для этого кинотеатра не были найдены";

        public const string CinemasNotFound = "Кинотеатры не были найдены";

        public const string PersonWasDelete = "Пользователь уже был удален";

        public const string SessionsForHallNotFound = "Сеансы для данного зала не были найдены";

        public const string FilmsForCinemaNotFound = "Фильмы для данного кинотеатра не найдены";

        public const string CinemaNotFound =
            "Кинотеатр по вашему запросу не найден, уточните данные и повторите запрос";

        public const string HallNotFound = "Зал по вашему запросу не найден, уточните данные и повторите запрос";

        public const string SessionNotFound = "Сеанс по вашему запросу не найден, уточните данные и повторите запрос";

        public const string PlaceNotFound = "Место по вашему запросу не найдено, уточните данные и повторите запрос";

        public const string FilmNotFound = "Фильм по вашему запросу не найден, уточните данные и повторите запрос";

        public const string PersonNotFound =
            "Пользователь по вашему запросу не найден, уточните данные и повторите запрос";
    }
}