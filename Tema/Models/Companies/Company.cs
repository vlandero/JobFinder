﻿using Tema.Models.Base;
using Tema.Models.Users.Seeker;

namespace Tema.Models.Companies
{
    public class Company : BaseEntity, ICompany
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<Seeker> Employees { get; set; }
        public Guid CreatorId { get; set; }
    }
}
