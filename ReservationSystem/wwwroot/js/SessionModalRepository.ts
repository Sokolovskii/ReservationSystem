import { GetRequest, PostRequest } from './GetPostRequest'
import { Session, PartialFilm, PlaceInHall } from './DataClasses'
import { ServiceResponceGeneric, ServiceResponceNonGeneric, ServiseResponceCode } from './ServiceResponce'

class SessionModalRepository {

    public GetSession(sessionId: number): Promise<ServiceResponceGeneric<Session>> {
        const data = {
            "sessionId": sessionId
        }
        return GetRequest<Session>("api/place/GetSessionbyId", data);
    }

    public GetListPlaces(sessionId: number): Promise<ServiceResponceGeneric<PlaceInHall[]>> {
        const data = {
            "sessionId": sessionId
        }
        return GetRequest<PlaceInHall[]>("api/place/getInfoAboutPlaces", data);
    }

    public ReserveSession(placeIds: number[], sessionId: number, userId: number): Promise<ServiceResponceNonGeneric> {
        const data = {
            "placeIds": placeIds,
            "sessionId": sessionId,
            "userId": userId
        }
        return PostRequest("api/place/ReserveSessions", data)
    }

    public UnreserveSession(sessionId: number, userId: number): Promise<ServiceResponceNonGeneric> {
        const data = {
            "sessionId": sessionId,
            "userId": userId
        }
        return PostRequest("api/place/UnreserveSessions", data)
    }

    public GetFilm(filmId: number): Promise<ServiceResponceGeneric<PartialFilm>> {
        const data = {
            "filmId": filmId
        }
        return GetRequest<PartialFilm>("api/place/GetPartialFilmById", data);
    }
}

const sessionModalRepository = new SessionModalRepository();
export default sessionModalRepository;