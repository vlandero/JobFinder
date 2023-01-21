// public string? Resume { get; set; }
//         public string? About { get; set; }
//         public List<ApplicationDTO> Applications { get; set; }
//         public List<string> Skills { get; set; }

import Application from "./Application.model";
import User from "./User.model";

export default class Finder extends User{
    resume?: string;
    about?: string;
    skills!: string[];
    applications!: Application[];
}