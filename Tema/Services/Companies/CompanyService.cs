using Tema.Models.Companies;
using Tema.Repositories.CompaniesRepository;
using Tema.Repositories.GenericRepository;
using Tema.Services.Generic;

namespace Tema.Services.Companies
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(IGenericRepository<Company> repo ,ICompanyRepository companyRepository) : base(repo)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> GetByName(string name)
        {
            return await _companyRepository.GetByName(name);
        }
        public Company GetByNameSync(string name)
        {
            return _companyRepository.GetByNameSync(name);
        }
        public Company GetCompanyFromSeeker(string email)
        {
            System.Diagnostics.Debug.WriteLine("GetCompanyFromSeeker "+ email);

            return _companyRepository.GetCompanyFromSeeker(email);
        }

    }
}
