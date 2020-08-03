import sessionExampleRepository from './SessionExampleRepository'
import { Session, PartialFilm, PlaceInHall } from './DataClasses'
import { ServiceResponceGeneric, ServiceResponceNonGeneric, ServiseResponceCode } from './ServiceResponce'

class ExampleModalManager {
    public sessionId: number;
    public filmId: number;
    public session: Session;
    public film: PartialFilm;
    public places: PlaceInHall[];

    public CloseModal() {
        let modal = document.getElementById("sessionModalExample") as HTMLDialogElement;
        modal.close();
    }

    public ShowModal() {
        let modal = document.getElementById("sessionModalExample") as HTMLDialogElement;
        modal.showModal();
    }

    public async GetPlaces() {
        let result = await sessionExampleRepository.GetListPlaces(this.sessionId);
        if (result.code !== 0) {
            alert(result.message);
        }
        else {
            this.places = result.data as PlaceInHall[];
        }
    }

    public async GetFilm() {
        const result = await sessionExampleRepository.GetFilm(this.filmId);
        if (result.code !== ServiseResponceCode.Ok) {
            alert(result.message);
        }
        else {
            this.film = result.data as PartialFilm;
        }
    }

    public async GetSession() {
        const result = await sessionExampleRepository.GetSession(this.sessionId);
        if (result.code !== ServiseResponceCode.Ok) {
            alert(result.message);
        }
        else {
            this.session = result.data as Session;
        }
    }
}