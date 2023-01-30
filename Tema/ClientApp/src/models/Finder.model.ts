import Application from "./Application.model";
import User from "./User.model";

export default class Finder extends User{
    resume?: string;
    about?: string;
    skills!: string[];
    applications!: Application[];
}