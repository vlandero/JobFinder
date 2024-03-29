﻿using Tema.Models.Jobs;
using Tema.Models.ManyToMany;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.Users.Finder
{
    public class Finder : User, IFinder
    {
        public string? Resume { get; set; }
        public string? About { get; set; }
        public List<string> Skills { get; set; }
        public List<Applicant> JobApplications { get; set; }
    }
}
