class SessionExampleRepository {
    GetSession(sessionId) {
        const data = {
            "sessionId": sessionId
        };
        return GetRequest("api/place/GetSessionbyId", data);
    }
    GetListPlaces(sessionId) {
        const data = {
            "sessionId": sessionId
        };
        return GetRequest("api/place/getInfoAboutPlaces", data);
    }
    GetFilm(filmId) {
        const data = {
            "filmId": filmId
        };
        return GetRequest("api/place/GetSessionbyId", data);
    }
}
//# sourceMappingURL=SessionExampleRepository.js.map