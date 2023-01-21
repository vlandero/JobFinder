import CompanyResponse from "./CompanyResponse.model";
import UserRequestRegister from "./UserRequestRegister.model";


export default class SeekerRequestRegister extends UserRequestRegister {
    company!: CompanyResponse;
    created!: boolean;
}