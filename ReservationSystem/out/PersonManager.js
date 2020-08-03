var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { ServiseResponceCode } from './ServiceResponce';
import personRepository from './PersonRepository';
class PersonManager {
    constructor() {
        this.RegistrationModal = document.getElementById("RegistrationModal");
        this.LogInModal = document.getElementById("LogInModal");
    }
    getCookie(name) {
        let matches = document.cookie.match(new RegExp("(?:^|; )" + name.replace(/([.$?*|{}()\[\]\\\/+^])/g, '\\$1') + "=([^;]*)"));
        return matches ? decodeURIComponent(matches[1]) : undefined;
    }
    setCookie(name, value, options = {}) {
        options = {
            path: '/',
            'max-age': 3600
        };
        let updatedCookie = encodeURIComponent(name) + "=" + encodeURIComponent(value);
        for (let optionKey in options) {
            updatedCookie += "; " + optionKey;
            let optionValue = options[optionKey];
            if (optionValue !== true) {
                updatedCookie += "=" + optionValue;
            }
        }
        document.cookie = updatedCookie;
    }
    deleteAllCookies() {
        var cookies = document.cookie.split(";");
        for (var i = 0; i < cookies.length; i++) {
            const cookie = cookies[i];
            var eqPos = cookie.indexOf("=");
            var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
            document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
        }
    }
    Login() {
        return __awaiter(this, void 0, void 0, function* () {
            const login = PersonManager.GetElementValueById("loginInput");
            const password = PersonManager.GetElementValueById("passwordInput");
            if (PersonManager.ValidateInputs(login, password)) {
                const response = yield personRepository.Login(login, password);
                if (response.code !== ServiseResponceCode.Ok) {
                    if (response.code === ServiseResponceCode.Error) {
                        alert("Произошла непредвиденная ошибка, попытайтесь снова");
                    }
                    if (response.code === ServiseResponceCode.Warning) {
                        alert(response.message);
                    }
                    return;
                }
                this.setCookie("currentUserId", response.data.id);
                this.setCookie("userName", response.data.name);
                this.setCookie("login", response.data.login);
                this.closeLogInModal();
                document.getElementById("userName").innerText = personManager.getCookie("userName");
            }
            return;
        });
    }
    SignIn() {
        return __awaiter(this, void 0, void 0, function* () {
            const name = PersonManager.GetElementValueById("nameRegister");
            const login = PersonManager.GetElementValueById("loginRegister");
            const password = PersonManager.GetElementValueById("passwordRegister");
            const confirmPassword = PersonManager.GetElementValueById("ConfirmPasswordRegister");
            if (PersonManager.ValidateRegisterInputs(name, login, password, confirmPassword)) {
                if (password == confirmPassword) {
                    const response = yield personRepository.SignIn(name, login, password);
                    if (response.code !== ServiseResponceCode.Ok) {
                        if (response.code === ServiseResponceCode.Error) {
                            alert("Произошла непредвиденная ошибка, попытайтесь снова");
                        }
                        if (response.code === ServiseResponceCode.Warning) {
                            alert(response.message);
                        }
                        return;
                    }
                    this.setCookie("currentUserId", response.data.id);
                    this.setCookie("userName", response.data.name);
                    this.setCookie("login", response.data.login);
                    this.closeRegistrationModal();
                    document.getElementById("userName").innerText = personManager.getCookie("userName");
                }
                else {
                    alert("Пароли не совпали, повторите попытку");
                }
            }
        });
    }
    static ValidateInputs(login, password) {
        if (login == "" || password == "") {
            alert("Не введен логин или пароль");
            return false;
        }
        return true;
    }
    static ValidateRegisterInputs(name, login, password, confirmPassword) {
        if (login == "" || password == "" || name == "" || confirmPassword == "") {
            alert("Не заполнено какое то из полей ввода, повторите попытку");
            return false;
        }
        return true;
    }
    static GetElementValueById(id) {
        return document.getElementById(id).value;
    }
    closeRegistrationModal() {
        document.getElementById("nameRegister").value = "";
        document.getElementById("loginRegister").value = "";
        document.getElementById("passwordRegister").value = "";
        document.getElementById("ConfirmPasswordRegister").value = "";
        this.RegistrationModal.close();
    }
    closeLogInModal() {
        document.getElementById("loginInput").value = "";
        document.getElementById("passwordInput").value = "";
        this.LogInModal.close();
    }
    openRegistrationModal() {
        this.RegistrationModal.showModal();
    }
    openLogInModal() {
        this.LogInModal.showModal();
    }
}
const personManager = new PersonManager();
export default personManager;
//# sourceMappingURL=PersonManager.js.map