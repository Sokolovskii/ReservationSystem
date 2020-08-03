import { DialogModalManager } from "./DialogModalManager"
import personManager from "./PersonManager";
declare let window: any;

window.onload = function () {
    const buttons = document.getElementsByClassName("reservationButton");
    for (let i = 0; i < buttons.length; i++) {
        const button = buttons[i] as HTMLElement;
        button.onclick = async function () {
            window.manager = new DialogModalManager(+button.dataset.sessionid, +button.dataset.filmid);
            await window.manager.RenderModal();
        }
    }
    if(personManager.getCookie("currentUserId") !== undefined){
        ActiveUserToolBar();
        for (let i = 0; i < buttons.length; i++) {
            const button = buttons[i] as HTMLButtonElement;
            button.disabled = false;
        }
        document.getElementById("userName").innerText = personManager.getCookie("userName");
        document.getElementById("closeSessionModal").onclick = function () { window.manager.CloseModal(); }
        document.getElementById("cancelReservationModal").onclick = function () { window.manager.CancelReservation(); }
        document.getElementById("unreservationModal").onclick = function () { window.manager.UnreservePlaces(); }
        document.getElementById("reservePlaces").onclick = function () { window.manager.ReservePlaces(); }
    }
    else{
        InactiveUserToolBar();
        for (let i = 0; i < buttons.length; i++) {
            const button = buttons[i] as HTMLButtonElement;
            button.disabled = true;
        }
    }
    
    if(document.getElementById("demoHallModal")!==null){
        document.getElementById("demoHallModalOpen").onclick = function(){(<HTMLDialogElement>document.getElementById("demoHallModal")).showModal();}
        document.getElementById("closeDemoHallModal").onclick = function(){(<HTMLDialogElement>document.getElementById("demoHallModal")).close();}
    }
    
    
    document.getElementById("logIn").onclick = function() {personManager.openLogInModal()}
    document.getElementById("closeLogInModal").onclick = function(){personManager.closeLogInModal()}
    
    document.getElementById("register").onclick = function(){
        personManager.deleteAllCookies();
        InactiveUserToolBar()
        personManager.openRegistrationModal()
    }
    document.getElementById("closeRegistrationModal").onclick = function(){personManager.closeRegistrationModal()}
    
    document.getElementById("submitRegistrationModal").onclick = async function() {
        await personManager.SignIn();
        ActiveUserToolBar();
        for (let i = 0; i < buttons.length; i++) {
            const button = buttons[i] as HTMLButtonElement;
            button.disabled = false;
        }
    }
    
    document.getElementById("submitLogInModal").onclick = async function(){
        await personManager.Login();
        ActiveUserToolBar();
        for (let i = 0; i < buttons.length; i++) {
            const button = buttons[i] as HTMLButtonElement;
            button.disabled = false;
        }
    }
    document.getElementById("logout").onclick = function(){
        personManager.deleteAllCookies();
        InactiveUserToolBar();
        for (let i = 0; i < buttons.length; i++) {
            const button = buttons[i] as HTMLButtonElement;
            button.disabled = true;
        }
    }
}

function ActiveUserToolBar(){
    document.getElementById("toolBarUserInfo").className="toolBarElement";
    document.getElementById("toolBarLogin").className = "toolBarElementInvisible";
    document.getElementById("toolBarRegister").className = "toolBarElementInvisible";
}

function InactiveUserToolBar(){
    document.getElementById("toolBarUserInfo").className="toolBarElementInvisible";
    document.getElementById("toolBarLogin").className = "toolBarElement";
    document.getElementById("toolBarRegister").className = "toolBarElement";
}
