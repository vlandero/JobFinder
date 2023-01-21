// public class FinderResponseLoginDTO : UserResponseLoginDTO<Finder>
//     {

import UserResponseLogin from "./UserResponseLogin.model";

export default class FinderResponseLogin extends UserResponseLogin {
    resume?: string;
    about?: string;
    skills!: string[];
}