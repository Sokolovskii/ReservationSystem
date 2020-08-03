import { PostRequest } from './GetPostRequest';
class PersonRepository {
    Login(login, password) {
        const data = {
            "login": login,
            "passHash": password
        };
        return PostRequest("api/person/getUser", data);
    }
    SignIn(userName, login, password) {
        const data = {
            "name": userName,
            "login": login,
            "passHash": password,
        };
        return PostRequest("api/person/createAccount", data);
    }
    ChangePassHash(id, newPassword) {
        const data = {
            "id": id,
            "passHash": newPassword
        };
        return PostRequest("api/person/changePassHash", data);
    }
    ChangeNmae(id, newName) {
        const data = {
            "id": id,
            "name": newName
        };
        return PostRequest("api/person/changeName", data);
    }
    DeleteAccount(id) {
        const data = {
            "id": id
        };
        return PostRequest("api/person/deleteAccount", data);
    }
}
const personRepository = new PersonRepository();
export default personRepository;
//# sourceMappingURL=PersonRepository.js.map