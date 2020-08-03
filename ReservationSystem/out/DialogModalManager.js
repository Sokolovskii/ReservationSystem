var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import * as $ from 'jquery';
import * as jsrender from 'jsrender';
import sessionModalRepository from './SessionModalRepository';
import { PlaceInHall } from './DataClasses';
import { ServiseResponceCode } from './ServiceResponce';
import personManager from "./PersonManager";
export class DialogModalManager {
    constructor(sessionId, filmId) {
        this.modal = document.getElementById("sessionModal");
        this.placesElement = document.getElementById("TableTemptateModal");
        this.sessionElement = document.getElementById("sessionTempModal");
        this.sessionId = sessionId;
        this.filmId = filmId;
        this.selectedPlaces = [];
    }
    ReservePlaces() {
        return __awaiter(this, void 0, void 0, function* () {
            const placeIds = this.selectedPlaces.map(function (place) {
                return place.id;
            });
            let result = yield sessionModalRepository.ReserveSession(placeIds, this.sessionId, +personManager.getCookie("currentUserId"));
            if (result.code !== ServiseResponceCode.Ok) {
                if (result.code === ServiseResponceCode.Error) {
                    alert("Произошла непредвиденная ошибка, попытайтесь снова");
                }
                if (result.code === ServiseResponceCode.Warning) {
                    alert(result.message);
                }
            }
            this.CloseModal();
        });
    }
    CancelReservation() {
        const places = document.getElementsByClassName("selectedPlace");
        const count = places.length;
        for (let i = 0; i < count; i++) {
            places[0].className = "sessionTableCell";
        }
        this.selectedPlaces = [];
    }
    CloseModal() {
        this.selectedPlaces = [];
        this.placesElement.innerHTML = "";
        this.sessionElement.innerHTML = "";
        this.modal.close();
    }
    UnreservePlaces() {
        return __awaiter(this, void 0, void 0, function* () {
            let result = yield sessionModalRepository.UnreserveSession(this.sessionId, +personManager.getCookie("currentUserId"));
            if (result.code !== ServiseResponceCode.Ok) {
                if (result.code === ServiseResponceCode.Error) {
                    alert("Произошла непредвиденная ошибка, попытайтесь снова");
                }
                if (result.code === ServiseResponceCode.Warning) {
                    alert(result.message);
                }
            }
            this.CloseModal();
        });
    }
    SelectPlace(event, id, row, column) {
        const place = new PlaceInHall(id, row, column, +personManager.getCookie("currentUserId"));
        this.selectedPlaces.push(place);
        const element = event.target;
        element.className = "selectedPlace";
    }
    GetPlaces() {
        return __awaiter(this, void 0, void 0, function* () {
            let result = yield sessionModalRepository.GetListPlaces(this.sessionId);
            if (result.code !== ServiseResponceCode.Ok) {
                if (result.code === ServiseResponceCode.Error) {
                    alert("Произошла непредвиденная ошибка, попытайтесь снова");
                }
                if (result.code === ServiseResponceCode.Warning) {
                    alert(result.message);
                }
            }
            else {
                this.places = result.data;
            }
        });
    }
    GetFilm() {
        return __awaiter(this, void 0, void 0, function* () {
            const result = yield sessionModalRepository.GetFilm(this.filmId);
            if (result.code !== ServiseResponceCode.Ok) {
                if (result.code === ServiseResponceCode.Error) {
                    alert("Произошла непредвиденная ошибка, попытайтесь снова");
                }
                if (result.code === ServiseResponceCode.Warning) {
                    alert(result.message);
                }
            }
            else {
                this.film = result.data;
            }
        });
    }
    GetSession() {
        return __awaiter(this, void 0, void 0, function* () {
            const result = yield sessionModalRepository.GetSession(this.sessionId);
            if (result.code !== ServiseResponceCode.Ok) {
                if (result.code === ServiseResponceCode.Error) {
                    alert("Произошла непредвиденная ошибка, попытайтесь снова");
                }
                if (result.code === ServiseResponceCode.Warning) {
                    alert(result.message);
                }
            }
            else {
                this.session = result.data;
            }
        });
    }
    RenderModal() {
        return __awaiter(this, void 0, void 0, function* () {
            let responseSession = yield fetch('/Templates/sessionTemplate.html');
            const sessionTemplate = yield responseSession.text();
            jsrender($);
            const tmpl = jsrender.templates(sessionTemplate);
            console.log(sessionTemplate);
            const responseRow = yield fetch('/Templates/rowTemplate.html');
            const rowTemplate = yield responseRow.text();
            const rowtmpl = jsrender.templates(rowTemplate);
            yield this.GetFilm();
            yield this.GetPlaces();
            yield this.GetSession();
            console.log("info:");
            const data = {
                "session": this.session,
                "film": this.film
            };
            console.log(data);
            this.sessionElement.innerHTML = tmpl.render(data);
            const maxRows = Math.max.apply(null, this.places.map(function (place) {
                return place.row;
            }));
            for (let i = 1; i <= maxRows; i++) {
                let row = this.places.filter(place => place.row == i);
                console.log(row);
                const dataPlaces = {
                    CurrentUserId: +personManager.getCookie("currentUserId"),
                    Places: row
                };
                console.log(rowtmpl.render(dataPlaces));
                this.placesElement.innerHTML += rowtmpl.render(dataPlaces);
            }
            this.modal.showModal();
        });
    }
}
//# sourceMappingURL=DialogModalManager.js.map