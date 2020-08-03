var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { DialogModalManager } from "./DialogModalManager";
import personManager from "./PersonManager";
window.onload = function () {
    const buttons = document.getElementsByClassName("reservationButton");
    for (let i = 0; i < buttons.length; i++) {
        const button = buttons[i];
        button.onclick = function () {
            return __awaiter(this, void 0, void 0, function* () {
                window.manager = new DialogModalManager(+button.dataset.sessionid, +button.dataset.filmid);
                yield window.manager.RenderModal();
            });
        };
    }
    if (personManager.getCookie("currentUserId") !== undefined) {
        ActiveUserToolBar();
        for (let i = 0; i < buttons.length; i++) {
            const button = buttons[i];
            button.disabled = false;
        }
        document.getElementById("userName").innerText = personManager.getCookie("userName");
        document.getElementById("closeSessionModal").onclick = function () { window.manager.CloseModal(); };
        document.getElementById("cancelReservationModal").onclick = function () { window.manager.CancelReservation(); };
        document.getElementById("unreservationModal").onclick = function () { window.manager.UnreservePlaces(); };
        document.getElementById("reservePlaces").onclick = function () { window.manager.ReservePlaces(); };
    }
    else {
        InactiveUserToolBar();
        for (let i = 0; i < buttons.length; i++) {
            const button = buttons[i];
            button.disabled = true;
        }
    }
    if (document.getElementById("demoHallModal") !== null) {
        document.getElementById("demoHallModalOpen").onclick = function () { document.getElementById("demoHallModal").showModal(); };
        document.getElementById("closeDemoHallModal").onclick = function () { document.getElementById("demoHallModal").close(); };
    }
    document.getElementById("logIn").onclick = function () { personManager.openLogInModal(); };
    document.getElementById("closeLogInModal").onclick = function () { personManager.closeLogInModal(); };
    document.getElementById("register").onclick = function () {
        personManager.deleteAllCookies();
        InactiveUserToolBar();
        personManager.openRegistrationModal();
    };
    document.getElementById("closeRegistrationModal").onclick = function () { personManager.closeRegistrationModal(); };
    document.getElementById("submitRegistrationModal").onclick = function () {
        return __awaiter(this, void 0, void 0, function* () {
            yield personManager.SignIn();
            ActiveUserToolBar();
            for (let i = 0; i < buttons.length; i++) {
                const button = buttons[i];
                button.disabled = false;
            }
        });
    };
    document.getElementById("submitLogInModal").onclick = function () {
        return __awaiter(this, void 0, void 0, function* () {
            yield personManager.Login();
            ActiveUserToolBar();
            for (let i = 0; i < buttons.length; i++) {
                const button = buttons[i];
                button.disabled = false;
            }
        });
    };
    document.getElementById("logout").onclick = function () {
        personManager.deleteAllCookies();
        InactiveUserToolBar();
        for (let i = 0; i < buttons.length; i++) {
            const button = buttons[i];
            button.disabled = true;
        }
    };
};
function ActiveUserToolBar() {
    document.getElementById("toolBarUserInfo").className = "toolBarElement";
    document.getElementById("toolBarLogin").className = "toolBarElementInvisible";
    document.getElementById("toolBarRegister").className = "toolBarElementInvisible";
}
function InactiveUserToolBar() {
    document.getElementById("toolBarUserInfo").className = "toolBarElementInvisible";
    document.getElementById("toolBarLogin").className = "toolBarElement";
    document.getElementById("toolBarRegister").className = "toolBarElement";
}
//# sourceMappingURL=Main.js.map