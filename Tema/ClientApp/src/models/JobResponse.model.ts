import Finder from "./Finder.model";

export default class JobResponse{
    postId!: number;
    name!: string;
    description!: string;
    category!: string;
    location!: string;
    salary?: string;
    creatorEmail!: string;
    Applicants!: Finder[];
    dateCreated!: Date;
}