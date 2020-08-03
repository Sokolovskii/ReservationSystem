class SessionModalRepository {
    GetSession(data) {
        return GetRequest("api/place/GetSessionbyId", data);
    }
    GetListPlaces(data) {
        return GetRequest("api/place/getInfoAboutPlaces", data);
    }
    ReserveSession(data) {
        return PostRequest("api/place/ReserveSessions", data);
    }
    UnreserveSession(data) {
        return PostRequest("api/place/UnreserveSessions", data);
    }
}
//# sourceMappingURL=SessionModalRepository.js.map