import UserRequestRegister from "./UserRequestRegister.model";

export default class FinderRequestRegister extends UserRequestRegister {
    about?: string;
    skills!: string[];
}