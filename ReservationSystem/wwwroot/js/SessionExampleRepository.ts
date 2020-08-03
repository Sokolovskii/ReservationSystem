import { GetRequest } from './GetPostRequest'
import { ServiceResponceGeneric, ServiceResponceNonGeneric, ServiseResponceCode } from './ServiceResponce'

class SessionExampleRepository {

    public GetSession<Session>(sessionId: number): Promise<ServiceResponceGeneric<Session>> {
        const data = {
            "sessionId": sessionId
        }
        return GetRequest("api/place/GetSessionbyId", data);
    }

    public GetListPlaces<PlaceInHall>(sessionId: number): Promise<ServiceResponceGeneric<PlaceInHall>> {
        const data = {
            "sessionId": sessionId
        }
        return GetRequest("api/place/getInfoAboutPlaces", data);
    }

    public GetFilm<PartialFilm>(filmId: number): Promise<ServiceResponceGeneric<PartialFilm>> {
        const data = {
            "filmId": filmId
        }
        return GetRequest("api/place/GetSessionbyId", data);
    }
}

const sessionExampleRepository = new SessionExampleRepository();
export default sessionExampleRepository;