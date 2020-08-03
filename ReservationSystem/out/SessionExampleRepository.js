import { GetRequest } from './GetPostRequest';
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
const sessionExampleRepository = new SessionExampleRepository();
export default sessionExampleRepository;
//# sourceMappingURL=SessionExampleRepository.js.map