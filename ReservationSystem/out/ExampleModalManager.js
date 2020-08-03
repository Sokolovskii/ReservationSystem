var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import sessionExampleRepository from './SessionExampleRepository';
import { ServiseResponceCode } from './ServiceResponce';
class ExampleModalManager {
    CloseModal() {
        let modal = document.getElementById("sessionModalExample");
        modal.close();
    }
    ShowModal() {
        let modal = document.getElementById("sessionModalExample");
        modal.showModal();
    }
    GetPlaces() {
        return __awaiter(this, void 0, void 0, function* () {
            let result = yield sessionExampleRepository.GetListPlaces(this.sessionId);
            if (result.code !== 0) {
                alert(result.message);
            }
            else {
                this.places = result.data;
            }
        });
    }
    GetFilm() {
        return __awaiter(this, void 0, void 0, function* () {
            const result = yield sessionExampleRepository.GetFilm(this.filmId);
            if (result.code !== ServiseResponceCode.Ok) {
                alert(result.message);
            }
            else {
                this.film = result.data;
            }
        });
    }
    GetSession() {
        return __awaiter(this, void 0, void 0, function* () {
            const result = yield sessionExampleRepository.GetSession(this.sessionId);
            if (result.code !== ServiseResponceCode.Ok) {
                alert(result.message);
            }
            else {
                this.session = result.data;
            }
        });
    }
}
//# sourceMappingURL=ExampleModalManager.js.map