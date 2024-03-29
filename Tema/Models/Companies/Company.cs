﻿using System.ComponentModel.DataAnnotations;
using Tema.Models.Base;
using Tema.Models.Users.Seeker;

namespace Tema.Models.Companies
{
    public class Company : BaseEntity, ICompany
    {
        public string? Logo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public List<Seeker>? Employees { get; set; }
        public Guid CreatorId { get; set; }
    }
}
