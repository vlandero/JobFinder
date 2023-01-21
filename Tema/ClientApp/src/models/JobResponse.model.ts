export default class JobResponse{
    postId!: number;
    name!: string;
    description!: string;
    category!: string;
    location!: string;
    salary?: string;
    creatorEmail!: string;
    dateCreated!: Date;
}