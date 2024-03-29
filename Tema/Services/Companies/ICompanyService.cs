﻿using Tema.Models.Companies;
using Tema.Services.Generic;

namespace Tema.Services.Companies
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<Company> GetByName(string name);
        Company GetByNameSync(string name);
        Company GetCompanyFromSeeker(string email);
    }
}
