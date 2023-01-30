import CompanyRequest from "./CompanyRequest.model";
import UserRequestRegister from "./UserRequestRegister.model";


export default class SeekerRequestRegister extends UserRequestRegister {
    company!: CompanyRequest;
    created!: boolean;
}