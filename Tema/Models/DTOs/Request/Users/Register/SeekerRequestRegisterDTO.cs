﻿using System.Text.Json.Serialization;
using Tema.Models.DTOs.Companies;

namespace Tema.Models.DTOs.Request.Users.Register
{
    public class SeekerRequestRegisterDTO : UserRequestRegisterDTO
    {
        public CompanyRequestDTO CompanyDTO { get; set; }
        public bool Created { get; set; }
        [JsonConstructor]
        public SeekerRequestRegisterDTO() { }


    }
}
