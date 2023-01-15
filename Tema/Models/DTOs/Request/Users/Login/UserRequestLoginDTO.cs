﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tema.Models.DTOs.Request.Users.Login
{
    public class UserRequestLoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [JsonConstructor]
        public UserRequestLoginDTO() { }

    }
}
