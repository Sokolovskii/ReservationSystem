import * as $ from 'jquery'
import * as jsrender from 'jsrender'
import sessionModalRepository from './SessionModalRepository'
import {PartialFilm, PlaceInHall, Session} from './DataClasses'
import {ServiseResponceCode} from './ServiceResponce'
import personManager from "./PersonManager";


export class DialogModalManager {
        public sessionId: number;
        public filmId: number;
        public session: Session;
        public film: PartialFilm;
        public places: PlaceInHall[];
        public selectedPlaces: PlaceInHall[];
        public modal = document.getElementById("sessionModal") as HTMLDialogElement;
        public placesElement = document.getElementById("TableTemptateModal");
        public sessionElement = document.getElementById("sessionTempModal");

        constructor(sessionId: number, filmId: number) {
            this.sessionId = sessionId;
            this.filmId = filmId;
            this.selectedPlaces = [];
        }

        public async ReservePlaces() {
            const placeIds = this.selectedPlaces.map(function (place) {
                return place.id
            });
            let result = await sessionModalRepository.ReserveSession(placeIds, this.sessionId,  +personManager.getCookie("currentUserId"));
            if (result.code !== ServiseResponceCode.Ok) {
                if(result.code === ServiseResponceCode.Error){alert("Произошла непредвиденная ошибка, попытайтесь снова");}
                if(result.code === ServiseResponceCode.Warning){alert(result.message);}
            }
            this.CloseModal();
        }

        public CancelReservation() {
            const places = document.getElementsByClassName("selectedPlace");
            const count = places.length
            for (let i = 0; i < count; i++) {
                places[0].className = "sessionTableCell";
            }
            this.selectedPlaces = [];
        }

        public CloseModal() {
            this.selectedPlaces = [];
            this.placesElement.innerHTML = "";
            this.sessionElement.innerHTML = "";
            this.modal.close();
        }

        public async UnreservePlaces() {
            let result = await sessionModalRepository.UnreserveSession(this.sessionId, +personManager.getCookie("currentUserId"));
            if (result.code !== ServiseResponceCode.Ok) {
                if(result.code === ServiseResponceCode.Error){alert("Произошла непредвиденная ошибка, попытайтесь снова");}
                if(result.code === ServiseResponceCode.Warning){alert(result.message);}
            }
            this.CloseModal()
        }

        public SelectPlace(event: Event, id: number, row: number, column: number) {
            const place = new PlaceInHall(id, row, column,  +personManager.getCookie("currentUserId"));
            this.selectedPlaces.push(place);
            const element = event.target as HTMLElement;
            element.className = "selectedPlace";
        }

        public async GetPlaces() {
            let result = await sessionModalRepository.GetListPlaces(this.sessionId);
            if (result.code !== ServiseResponceCode.Ok) {
                if(result.code === ServiseResponceCode.Error){alert("Произошла непредвиденная ошибка, попытайтесь снова");}
                if(result.code === ServiseResponceCode.Warning){alert(result.message);}
            }
            else {
                this.places = result.data;
            }
        }

        public async GetFilm() {
            const result = await sessionModalRepository.GetFilm(this.filmId);
            if (result.code !== ServiseResponceCode.Ok) {
                if(result.code === ServiseResponceCode.Error){alert("Произошла непредвиденная ошибка, попытайтесь снова");}
                if(result.code === ServiseResponceCode.Warning){alert(result.message);}
            }
            else {
                this.film = result.data;
            }
        }

        public async GetSession() {
            const result = await sessionModalRepository.GetSession(this.sessionId);
            if (result.code !== ServiseResponceCode.Ok) {
                if(result.code === ServiseResponceCode.Error){alert("Произошла непредвиденная ошибка, попытайтесь снова");}
                if(result.code === ServiseResponceCode.Warning){alert(result.message);}
            }
            else {
                this.session = result.data;
            }
        }

        public async RenderModal() {

            let responseSession = await fetch('/Templates/sessionTemplate.html');
            const sessionTemplate = await responseSession.text();
            jsrender($);
            const tmpl = jsrender.templates(sessionTemplate);
            console.log(sessionTemplate);

            const responseRow = await fetch('/Templates/rowTemplate.html');
            const rowTemplate = await responseRow.text();
            const rowtmpl = jsrender.templates(rowTemplate);

            await this.GetFilm();
            await this.GetPlaces();
            await this.GetSession();

            console.log("info:")
            const data = {
                "session": this.session,
                "film": this.film
            }
            console.log(data);
            this.sessionElement.innerHTML = tmpl.render(data);

            const maxRows = Math.max.apply(null, this.places.map(function (place) {
                return place.row;
            }));
            for (let i = 1; i <= maxRows; i++) {
                let row = this.places.filter(place => place.row == i)
                console.log(row);
                const dataPlaces = {
                    CurrentUserId: +personManager.getCookie("currentUserId"),
                    Places: row
                }
                console.log(rowtmpl.render(dataPlaces));
                this.placesElement.innerHTML += rowtmpl.render(dataPlaces);
            }
            this.modal.showModal();
        }
    }


