import CompanyRequest from "./CompanyRequest.model";
import UserRequestRegister from "./UserRequestRegister.model";


export default class SeekerRequestRegister extends UserRequestRegister {
    companyDto!: CompanyRequest;
    created!: boolean;
}