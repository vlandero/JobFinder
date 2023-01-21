import JobResponse from "./JobResponse.model";

export default class CompanyResponse {
    name!: string;
    description!: string;
    location!: string;
    logo?: string;
    listedJobs!: JobResponse[];
}