import { GetRequest, PostRequest } from './GetPostRequest';
class SessionModalRepository {
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
    ReserveSession(placeIds, sessionId, userId) {
        const data = {
            "placeIds": placeIds,
            "sessionId": sessionId,
            "userId": userId
        };
        return PostRequest("api/place/ReserveSessions", data);
    }
    UnreserveSession(sessionId, userId) {
        const data = {
            "sessionId": sessionId,
            "userId": userId
        };
        return PostRequest("api/place/UnreserveSessions", data);
    }
    GetFilm(filmId) {
        const data = {
            "filmId": filmId
        };
        return GetRequest("api/place/GetPartialFilmById", data);
    }
}
const sessionModalRepository = new SessionModalRepository();
export default sessionModalRepository;
//# sourceMappingURL=SessionModalRepository.js.map