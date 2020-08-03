var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
class DialogModalManager {
    ReservePlaces() {
        return __awaiter(this, void 0, void 0, function* () {
            const data = {
                "placeIds": this.selectedPlaces,
                "sessionId": this.sessionId,
                "userId": 1
            };
            let result = yield this.repository.ReserveSession(data);
            if (result.code !== 0) {
                alert(result.message);
            }
        });
    }
    CancelReservation() {
        const places = document.getElementsByClassName("selectedPlace");
        for (let i = 0; i <= places.length; i++) {
            places[i].className = "defaultPlace";
        }
    }
    CloseModal() {
        let modal = document.getElementById("sessionModal");
        modal.close();
    }
    UnreservePlaces() {
        return __awaiter(this, void 0, void 0, function* () {
            const data = {
                "sessionId": this.sessionId,
                "userId": 1
            };
            let result = yield this.repository.UnreserveSession(data);
            if (result.code !== ServiseResponceCode.Ok) {
                alert(result.message);
            }
        });
    }
    ShowModal() {
        let modal = document.getElementById("sessionModal");
        modal.showModal();
    }
    SelectPlace(event, id, row, column) {
        const place = new PlaceInHall(id, row, column, 0);
        this.selectedPlaces.push(place);
        const element = event.target;
        element.className = "selectedPlace";
    }
    GetPlaces() {
        return __awaiter(this, void 0, void 0, function* () {
            const data = {
                "sessionId": this.sessionId
            };
            let result = yield this.repository.GetListPlaces(data);
            if (result.code !== 0) {
                alert(result.message);
            }
            else {
                this.places = result.data;
            }
        });
    }
}
//# sourceMappingURL=DialogModalManager.js.map