import CompanyResponse from "./CompanyResponse.model";
import JobResponse from "./JobResponse.model";
import User from "./User.model";

export default class Seeker extends User {
    company!: CompanyResponse;
    listedJobs!: JobResponse[];
    isCreator!: boolean;
}