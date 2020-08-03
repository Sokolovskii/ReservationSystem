import {ServiseResponceCode} from './ServiceResponce'
import personRepository from './PersonRepository'
import {Person} from "./DataClasses";

class PersonManager {

    public RegistrationModal = document.getElementById("RegistrationModal") as HTMLDialogElement
    
    public LogInModal = document.getElementById("LogInModal") as HTMLDialogElement
    
    public getCookie(name) {
        let matches = document.cookie.match(new RegExp(
            "(?:^|; )" + name.replace(/([.$?*|{}()\[\]\\\/+^])/g, '\\$1') + "=([^;]*)"
        ));
        return matches ? decodeURIComponent(matches[1]) : undefined;
    }

    private setCookie(name, value, options = {}) {

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
    
    public deleteAllCookies() {
        var cookies = document.cookie.split(";");

        for (var i = 0; i < cookies.length; i++) {
            const cookie = cookies[i];
            var eqPos = cookie.indexOf("=");
            var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
            document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
        }
    }
    
    public async Login(){
        const login = PersonManager.GetElementValueById("loginInput");
        const password = PersonManager.GetElementValueById("passwordInput");
        if(PersonManager.ValidateInputs(login,password)){
            const response = await personRepository.Login(login, password);
            if (response.code !== ServiseResponceCode.Ok) {
                if(response.code === ServiseResponceCode.Error){alert("Произошла непредвиденная ошибка, попытайтесь снова");}
                if(response.code === ServiseResponceCode.Warning){alert(response.message);}
                return
            }
            this.setCookie("currentUserId", response.data.id);
            this.setCookie("userName", response.data.name);
            this.setCookie("login", response.data.login);
            
            this.closeLogInModal();

            document.getElementById("userName").innerText = personManager.getCookie("userName");
        }
        return
    }
    
    public async SignIn(){
        const name = PersonManager.GetElementValueById("nameRegister");
        const login = PersonManager.GetElementValueById("loginRegister");
        const password = PersonManager.GetElementValueById("passwordRegister");
        const confirmPassword = PersonManager.GetElementValueById("ConfirmPasswordRegister");
        
        if(PersonManager.ValidateRegisterInputs(name,login,password,confirmPassword)){
            if(password == confirmPassword){
                const response = await personRepository.SignIn(name,login,password);
                if (response.code !== ServiseResponceCode.Ok) {
                    if(response.code === ServiseResponceCode.Error){alert("Произошла непредвиденная ошибка, попытайтесь снова");}
                    if(response.code === ServiseResponceCode.Warning){alert(response.message);}
                    return
                }
                this.setCookie("currentUserId", response.data.id);
                this.setCookie("userName", response.data.name);
                this.setCookie("login", response.data.login);
                
                this.closeRegistrationModal();

                document.getElementById("userName").innerText = personManager.getCookie("userName");
            }
            else{
                alert("Пароли не совпали, повторите попытку")
            }
        }
    }
    
    private static ValidateInputs(login:string, password:string):boolean{

        if(login == "" || password == ""){
            alert("Не введен логин или пароль")
            return false
        }
        return true
    }

    private static ValidateRegisterInputs(name: string, login:string, password:string, confirmPassword:string):boolean{

        if(login == "" || password == ""||name==""||confirmPassword==""){
            alert("Не заполнено какое то из полей ввода, повторите попытку")
            return false
        }
        return true
    }
    
    private static GetElementValueById(id:string){
        return (<HTMLInputElement>document.getElementById(id)).value;
    }
    
    public closeRegistrationModal(){
        (<HTMLInputElement>document.getElementById("nameRegister")).value="";
        (<HTMLInputElement>document.getElementById("loginRegister")).value="";
        (<HTMLInputElement>document.getElementById("passwordRegister")).value="";
        (<HTMLInputElement>document.getElementById("ConfirmPasswordRegister")).value="";
        this.RegistrationModal.close();
    }

    public closeLogInModal(){
        (<HTMLInputElement>document.getElementById("loginInput")).value="";
        (<HTMLInputElement>document.getElementById("passwordInput")).value="";
        this.LogInModal.close();
    }
    
    public openRegistrationModal(){
        this.RegistrationModal.showModal();
    }
    
    public openLogInModal(){
        this.LogInModal.showModal();
    }
    
}

const personManager = new PersonManager();
export default personManager;