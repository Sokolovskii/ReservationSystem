import { GetRequest, PostRequest } from './GetPostRequest'
import { Person} from './DataClasses'
import { ServiceResponceGeneric, ServiceResponceNonGeneric } from './ServiceResponce'
class PersonRepository {

    public Login(login: string, password: string): Promise<ServiceResponceGeneric<Person>> {

        const data = {
            "login": login,
            "passHash": password
        };
        return PostRequest<Person>("api/person/getUser", data);
    }

    public SignIn(userName: string, login: string, password: string): Promise<ServiceResponceGeneric<Person>> {
        const data = {
            "name": userName,
            "login": login,
            "passHash": password,
        }
        return PostRequest<Person>("api/person/createAccount",data)
    }

    public ChangePassHash(id: number, newPassword: string): Promise<ServiceResponceNonGeneric> {
        const data = {
            "id": id,
            "passHash": newPassword
        }
        return PostRequest("api/person/changePassHash", data)
    }

    public ChangeNmae(id: number, newName: string): Promise<ServiceResponceNonGeneric> {
        const data = {
            "id": id,
            "name": newName
        }
        return PostRequest("api/person/changeName", data)
    }

    public DeleteAccount(id: number): Promise<ServiceResponceNonGeneric> {
        const data = {
            "id": id
        }
        return PostRequest("api/person/deleteAccount",data)
    }
}

const personRepository = new PersonRepository();
export default personRepository;