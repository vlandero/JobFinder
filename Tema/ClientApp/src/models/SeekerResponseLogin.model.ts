import CompanyResponse from "./CompanyResponse.model";
import UserResponseLogin from "./UserResponseLogin.model";


export default class SeekerResponseLogin extends UserResponseLogin {
    company!: CompanyResponse;
}